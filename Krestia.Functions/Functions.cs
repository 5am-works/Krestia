using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Krestia.Core;
using Krestia.Core.Lexicon;
using Krestia.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.FSharp.Core;
using Newtonsoft.Json;
using static Krestia.Core.Lexicon.Lexicon;

namespace Krestia.Functions;

public static class Functions {
   [FunctionName("TestFunction")]
   public static async Task<IActionResult> RunAsync(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
      HttpRequest req, ILogger log) {
      log.LogInformation("C# HTTP trigger function processed a request");

      string? name = req.Query["name"];

      var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      dynamic data = JsonConvert.DeserializeObject(requestBody);
      name ??= data?.name;

      return name != null
         ? new OkObjectResult($"Hello, {name}")
         : new BadRequestObjectResult(
            "Please pass a name on the query string or in the request body");
   }

   [FunctionName("SearchFunction")]
   [Produces(typeof(SearchResponse))]
   public static IActionResult Search(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get",
         Route = "search/{query}")]
      HttpRequest request, string query) {
      var lowercase = query.ToLowerInvariant();
      var decomposedResults = DecomposeWords(query);

      var words =
         from word in lexicon.Words
         where word.Spelling.Contains(lowercase,
                  StringComparison.InvariantCultureIgnoreCase) ||
               word.Meaning.Contains(lowercase,
                  StringComparison.InvariantCultureIgnoreCase) ||
               OptionModule.ToObj(word.QuantifiedMeaning)?.Contains(lowercase,
                  StringComparison.InvariantCultureIgnoreCase) == true
         orderby Relevance(word, query)
         select new WordWithMeaning(word.Spelling, word.Meaning);
      return new OkObjectResult(new SearchResponse {
         Results = words.ToList(),
         DecomposedResults = decomposedResults.ToList(),
      });
   }

   [FunctionName("GetWordFunction")]
   [Produces(typeof(WordResponse))]
   public static IActionResult GetWord(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "word/{word}")]
      HttpRequest request, string word) {
      var result = lexicon.Find(word);
      if (result == null) {
         return new NotFoundResult();
      }

      return new OkObjectResult(result.ToWordResponse());
   }

   [FunctionName("AlphabeticalWordListFunction")]
   [Produces(typeof(IEnumerable<WordWithMeaning>))]
   public static IActionResult GetAlphabeticalWordList(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get",
         Route = "wordlist/alphabetical")]
      HttpRequest request) {
      var words =
         from word in lexicon.Words
         orderby word.Spelling
         select new WordWithMeaning(word.Spelling, word.Meaning);
      return new OkObjectResult(words);
   }

   [FunctionName("WordTypeWordListFunction")]
   [Produces(typeof(Dictionary<string, IEnumerable<WordWithMeaning>>))]
   public static IActionResult GetWordTypeWordList(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get",
         Route = "wordlist/wordtype")]
      HttpRequest request) {
      var words =
         from word in lexicon.Words
         group word by word.WordCategory()
         into wordType
         select wordType;
      var results = words.ToDictionary(
         group => group.Key,
         group => group.Select(word =>
            new WordWithMeaning(word.Spelling, word.Meaning)));
      return new OkObjectResult(results);
   }

   private static IEnumerable<DecomposedResult> DecomposeWords(string query) {
      var words = query.Split(' ');

      foreach (var word in words) {
         var result = Decompose.decompose(word);
         DecomposedResult decomposedResult;
         try {
            var decomposedWord = result.Value;
            var baseWord = decomposedWord.BaseWord;
            var steps = decomposedWord.Steps;
            var verbType = Decompose.isVerb(baseWord);
            Types.Word? originalWord = null;
            if (OptionModule.IsSome(verbType)) {
               var stem = baseWord[..^1];
               var normalWord = lexicon.FindNormalFormOfVerb(stem);
               if (normalWord != null) {
                  var normalType = Decompose.isVerb(normalWord.Spelling)
                     .Value;
                  if (Decompose.isReducedForm(verbType.Value, normalType)) {
                     originalWord = normalWord;
                  }
               }
            }

            var dictionaryEntry = lexicon.Find(baseWord);
            if (dictionaryEntry != null || originalWord is not null) {
               decomposedResult = new DecomposedResult(word,
                  OptionModule.ToObj(
                     dictionaryEntry?.Gloss ?? dictionaryEntry?.Meaning ??
                     originalWord?.Gloss ?? originalWord?.Meaning),
                  baseWord, originalWord?.Spelling,
                  steps.Select(ResponseHelper.FormatInflectionStep).ToList());
            } else {
               decomposedResult = new DecomposedResult(word);
            }
         } catch (NullReferenceException) {
            decomposedResult = new DecomposedResult(word);
         }

         yield return decomposedResult;
      }
   }

   private static int Relevance(Types.Word word, string query) {
      if (word.Spelling == query) return 0;
      if (word.Spelling.StartsWith(query)) return 1;
      if (word.Meaning == query) return 2;
      if (word.Meaning.StartsWith(query)) return 3;
      return Regex.IsMatch(word.Meaning, $"\\b{query}\\b",
         RegexOptions.IgnoreCase)
         ? 4
         : int.MaxValue;
   }
}