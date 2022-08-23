using Krestia.Lexicon;
using Krestia.Web.Common;
using static Krestia.Parser.Decompose;
using static Krestia.Parser.WordType;

namespace Krestia.Server.Utils; 

public static class ResponseHelper {
   public static WordResponse ToWordResponse(this Word word) {
      var wordType = baseTypeOf(word.Spelling).Value;

      return new WordResponse {
         Spelling = word.Spelling,
         Gloss = word.Gloss,
         Meaning = word.Meaning,
         WordType = FormatWordType(wordType),
      };
   }

   private static string FormatWordType(WordType wordType) {
      return wordType.Tag switch {
         WordType.Tags.AssociativeNoun => "Associative noun",
         WordType.Tags.TerminalDigit => "Terminal digit",
         WordType.Tags.NonTerminalDigit => "Non-terminal digit",
         _ => wordType.ToString(),
      };
   }
}