using System.Text.RegularExpressions;
using Krestia.Lexicon;
using Krestia.Server.Utils;
using Krestia.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace Krestia.Server.Controllers;

[ApiController]
[Route("api")]
public class WordController : ControllerBase {
   private readonly WordIndex _wordIndex;
   private readonly ILogger<WordController> _logger;

   public WordController(ILogger<WordController> logger) {
      _wordIndex = new WordIndex();
      _logger = logger;
   }

   [HttpGet("search/{query}")]
   [Produces(typeof(SearchResponse))]
   public IActionResult Search(string query) {
      var lowercase = query.ToLowerInvariant();
      var words =
         from word in _wordIndex.AllWords.AsParallel()
         where word.Spelling.Contains(lowercase) ||
               word.Meaning.Contains(lowercase)
         orderby Relevance(word, query)
         select new WordWithMeaning(word.Spelling, word.Meaning);
      return Ok(new SearchResponse {
         Results = words,
      });
   }

   [HttpGet("word/{word}")]
   [Produces(typeof(WordResponse))]
   public IActionResult GetWord(string word) {
      var result = _wordIndex.Find(word);
      if (result is null) {
         return NotFound();
      }

      return Ok(result.ToWordResponse());
   }

   [HttpGet("wordlist/alphabetical")]
   [Produces(typeof(IEnumerable<WordWithMeaning>))]
   public IActionResult GetAlphabeticalWordList() {
      var words =
         from word in _wordIndex.AllWords
         orderby word.Spelling
         select new WordWithMeaning(word.Spelling, word.Meaning);
      return Ok(words);
   }

   private static int Relevance(Word word, string query) {
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