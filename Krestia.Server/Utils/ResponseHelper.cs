using Krestia.Lexicon;
using Krestia.Parser;
using Krestia.Web.Common;
using static Krestia.Parser.Decompose;
using WordType = Krestia.Parser.WordType;

namespace Krestia.Server.Utils;

public static class ResponseHelper {
   public static WordResponse ToWordResponse(this Word word) {
      var wordType = baseTypeOf(word.Spelling).Value;
      var inflectedForms = Inflections.rules
         .Where(rule => rule.Item1.Contains(wordType)).Select(rule =>
            Tuple.Create(FormatInflection(rule.Item2),
               word.Spelling + rule.Item3));
      var contextMeaning = (word as Verb)?.Context;
      var fullForm = (word as Verb)?.ExpandedForm;

      return new WordResponse {
         Spelling = word.Spelling,
         Gloss = word.Gloss,
         Meaning = word.Meaning,
         WordType = FormatWordType(wordType),
         InflectedForms = inflectedForms,
         Syntax = contextMeaning,
         ExpandedForm = fullForm,
      };
   }

   internal static string FormatWordType(WordType.WordType wordType) {
      return wordType.Tag switch {
         WordType.WordType.Tags.Verb0 => "0-verb",
         WordType.WordType.Tags.Verb1 => "1-verb",
         WordType.WordType.Tags.Verb12 => "1-2-verb",
         WordType.WordType.Tags.Verb123 => "1-2-3-verb",
         WordType.WordType.Tags.Verb13 => "1-3-verb",
         WordType.WordType.Tags.Verb2 => "2-verb",
         WordType.WordType.Tags.Verb3 => "3-verb",
         WordType.WordType.Tags.Verb23 => "2-3-verb",
         WordType.WordType.Tags.AssociativeNoun => "Associative noun",
         WordType.WordType.Tags.TerminalDigit => "Terminal digit",
         WordType.WordType.Tags.NonTerminalDigit => "Non-terminal digit",
         _ => wordType.ToString(),
      };
   }

   private static string FormatInflection(WordType.Inflection inflection) {
      return inflection.Tag switch {
         WordType.Inflection.Tags.Argument1 => "Argument 1",
         WordType.Inflection.Tags.Argument2 => "Argument 2",
         WordType.Inflection.Tags.Argument3 => "Argument 3",
         WordType.Inflection.Tags.Partial1 => "Partial 1",
         WordType.Inflection.Tags.Partial2 => "Partial 2",
         WordType.Inflection.Tags.Partial3 => "Partial 3",
         WordType.Inflection.Tags.Shift2 => "Shift 2",
         WordType.Inflection.Tags.Shift3 => "Shift 3",
         WordType.Inflection.Tags.AttributiveIdentity => "Attributive identity",
         WordType.Inflection.Tags.PredicativeIdentity => "Predicative identity",
         _ => inflection.ToString(),
      };
   }
}