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

   [HttpGet("word/{word}")]
   [Produces(typeof(WordResponse))]
   public IActionResult GetWord(string word) {
      var result = _wordIndex.Find(word);
      if (result is null) {
         return NotFound();
      }

      return Ok(result.ToWordResponse());
   }
}