using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Krestia.Core;
using Krestia.Web.Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.FSharp.Core;
using static Krestia.Core.Lexicon.Lexicon;

namespace Krestia.Functions;

public static class Functions {
   [Function("SearchFunction")]
   public static async Task<HttpResponseData> Search(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "search/{query}")]
      HttpRequestData request, string query) {
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
      var response = request.CreateResponse();
      await response.WriteAsJsonAsync(new SearchResponse {
         Results = words.ToList(),
         DecomposedResults = decomposedResults.ToList(),
      });
      return response;
   }

   [Function("GetWordFunction")]
   public static async Task<HttpResponseData> GetWord(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "word/{word}")]
      HttpRequestData request, string word) {
      var result = lexicon.Find(word);
      if (result == null) {
         return request.CreateResponse(HttpStatusCode.NotFound);
      }

      var response = request.CreateResponse();
      await response.WriteAsJsonAsync(result.ToWordResponse());
      return response;
   }

   [Function("AlphabeticalWordListFunction")]
   public static async Task<HttpResponseData> GetAlphabeticalWordList(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get",
         Route = "wordlist/alphabetical")]
      HttpRequestData request) {
      var words =
         from word in lexicon.Words
         orderby word.Spelling
         select new WordWithMeaning(word.Spelling, word.Meaning);
      var response = request.CreateResponse();
      await response.WriteAsJsonAsync(words);
      return response;
   }

   [Function("WordTypeWordListFunction")]
   public static async Task<HttpResponseData> GetWordTypeWordList(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get",
         Route = "wordlist/wordtype")]
      HttpRequestData request) {
      var words =
         from word in lexicon.Words
         group word by word.WordCategory()
         into wordType
         select wordType;
      var results = words.ToDictionary(
         group => group.Key,
         group => group.Select(word =>
            new WordWithMeaning(word.Spelling, word.Meaning)));
      var response = request.CreateResponse();
      await response.WriteAsJsonAsync(response);
      return response;
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