using System;
using System.Linq;
using Krestia.Lexicon;
using Krestia.Parser;
using static Krestia.Parser.Decompose;
using Krestia.Web.Common;
using Etymology = Krestia.Lexicon.Etymology;
using WCEtymology = Krestia.Web.Common.Etymology;

namespace Krestia.Functions;

public static class ResponseHelper {
   public static WordResponse ToWordResponse(this Word word) {
      var wordType = baseTypeOf(word.Spelling).Value;
      var inflectedForms = Inflections.rules
         .Where(rule => rule.Item1.Contains(wordType)).Select(rule =>
            new InflectedForm {
               FormName = FormatInflection(rule.Item2),
               FormSpelling = word.Spelling + rule.Item3,
            });
      var contextMeaning = word.Context;
      var fullForm = word.ExpandedForm;
      var exampleUsages =
         word.ExampleUsages?.Select(u => Tuple.Create(u.Text, u.Translation));
      var syllables =
         Phonotactics.splitIntoSyllables(word.Spelling, withSuffix: false).ResultValue;

      return new WordResponse {
         Spelling = word.Spelling,
         Syllables = syllables,
         Gloss = word.Gloss,
         Meaning = word.Meaning,
         QuantifiedMeaning = word.QuantifiedMeaning,
         WordType = FormatWordType(wordType),
         InflectedForms = inflectedForms,
         Syntax = contextMeaning,
         ExpandedForm = fullForm,
         ExampleUsages = exampleUsages,
         Remark = word.Remarks,
         Etymology = word.Roots.HasValue
            ? ConvertEtymology(word.Roots.Value)
            : null,
      };
   }

   internal static string WordCategory(this Word word) {
      var wordType = baseTypeOf(word.Spelling).Value;
      return wordType.Tag switch {
         WordType.WordType.Tags.Verb0 => "Verbs",
         WordType.WordType.Tags.Verb1 => "Verbs",
         WordType.WordType.Tags.Verb2 => "Verbs",
         WordType.WordType.Tags.Verb3 => "Verbs",
         WordType.WordType.Tags.Verb12 => "Verbs",
         WordType.WordType.Tags.Verb13 => "Verbs",
         WordType.WordType.Tags.Verb23 => "Verbs",
         WordType.WordType.Tags.Verb123 => "Verbs",
         WordType.WordType.Tags.Noun => "Nouns",
         WordType.WordType.Tags.AssociativeNoun => "Nouns",
         WordType.WordType.Tags.TerminalDigit => "Digits",
         WordType.WordType.Tags.NonTerminalDigit => "Digits",
         _ => FormatWordType(wordType) + "s",
      };
   }

   internal static string FormatInflectionStep(WordType.Inflection inflection) {
      return inflection.Tag switch {
         WordType.Inflection.Tags.Argument1 => "A1",
         WordType.Inflection.Tags.Argument2 => "A2",
         WordType.Inflection.Tags.Argument3 => "A3",
         WordType.Inflection.Tags.Definite => "DEF",
         WordType.Inflection.Tags.Desiderative => "DES",
         WordType.Inflection.Tags.Existence => "EXS",
         WordType.Inflection.Tags.Gerund => "GER",
         WordType.Inflection.Tags.Hortative => "HOR",
         WordType.Inflection.Tags.Hypothetical => "HYP",
         WordType.Inflection.Tags.Imperative => "IMP",
         WordType.Inflection.Tags.Intention => "INT",
         WordType.Inflection.Tags.Lone => "LON",
         WordType.Inflection.Tags.Optative => "OPT",
         WordType.Inflection.Tags.Partial1 => "P1",
         WordType.Inflection.Tags.Partial2 => "P2",
         WordType.Inflection.Tags.Partial3 => "P3",
         WordType.Inflection.Tags.Perfect => "PER",
         WordType.Inflection.Tags.Possession => "POS",
         WordType.Inflection.Tags.Prefixed => "PRE",
         WordType.Inflection.Tags.Progressive => "PRO",
         WordType.Inflection.Tags.Quality => "QUA",
         WordType.Inflection.Tags.Shift2 => "S2",
         WordType.Inflection.Tags.Shift3 => "S3",
         WordType.Inflection.Tags.AttributiveIdentity => "AID",
         WordType.Inflection.Tags.PredicativeIdentity => "PID",
         _ => throw new ArgumentOutOfRangeException(
            $"Invalid inflection: {inflection}"),
      };
   }

   private static string FormatWordType(WordType.WordType wordType) {
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
         WordType.WordType.Tags.TerminalDigit => "Digit",
         WordType.WordType.Tags.NonTerminalDigit => "Digit",
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
         WordType.Inflection.Tags.Shift1 => "Shift 1",
         WordType.Inflection.Tags.Shift2 => "Shift 2",
         WordType.Inflection.Tags.Shift3 => "Shift 3",
         WordType.Inflection.Tags.AttributiveIdentity => "Attributive identity",
         WordType.Inflection.Tags.PredicativeIdentity => "Predicative identity",
         _ => inflection.ToString(),
      };
   }

   private static WCEtymology ConvertEtymology(Etymology etymology) {
      return new WCEtymology {
         Clipping = etymology.Clipping,
         Variant = etymology.Variant,
         Metaphor = etymology.Metaphor,
         Combination = etymology.Combination,
         Copy = etymology.Copy,
         Contraction = etymology.Contraction,
         Derivation = etymology.Derivation,
         Foreign = etymology.Foreign,
      };
   }
}