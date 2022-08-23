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
      var words = _wordIndex.AllWords.AsParallel().Where(word =>
            word.Spelling.Contains(lowercase) ||
            word.Meaning.Contains(lowercase))
         .Select(word => new WordWithMeaning(word.Spelling, word.Meaning));
      return Ok(new SearchResponse {
         Results = words.OrderBy(word => Relevance(word, query)),
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

   private static int Relevance(WordWithMeaning word, string query) {
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