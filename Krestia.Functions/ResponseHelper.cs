using System;
using System.Diagnostics;
using System.Linq;
using Krestia.Core;
using Krestia.Web.Common;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using WCEtymology = Krestia.Web.Common.Etymology;

namespace Krestia.Functions;

public static class ResponseHelper {
   public static WordResponse ToWordResponse(this Types.Word word) {
      var inflectedForms = Inflections.rules
         .Where(rule => rule.Item1.Contains(word.WordType)).Select(rule =>
            new InflectedForm {
               FormName = FormatInflection(rule.Item2),
               FormSpelling = word.Spelling + rule.Item3,
            });
      var contextMeaning = (word.AdditionalInfo as Types.AdditionalInfo.Verb)?.Item.Syntax;
      var exampleUsages =
         word.ExampleUsages?.Select(u => Tuple.Create(u.Text, u.Translation));
      var syllables =
         Phonotactics.splitIntoSyllables(word.Spelling, withSuffix: false).ResultValue;

      return new WordResponse {
         Spelling = word.Spelling,
         Syllables = syllables,
         Gloss = OptionModule.ToObj(word.Gloss),
         Meaning = word.Meaning,
         QuantifiedMeaning = OptionModule.ToObj(word.QuantifiedMeaning),
         WordType = FormatWordType(word.WordType),
         InflectedForms = inflectedForms,
         Syntax = contextMeaning,
         ExpandedForm = OptionModule.ToObj(word.ExpandedForm),
         ExampleUsages = exampleUsages,
         Remark = OptionModule.ToObj(word.Remarks),
         Etymology = OptionModule.IsSome(word.Etymology)
            ? ConvertEtymology(word.Etymology.Value)
            : null,
      };
   }

   internal static string WordCategory(this Types.Word word) {
      return word.WordType.Tag switch {
         Types.WordType.Tags.Verb0 => "Verbs",
         Types.WordType.Tags.Verb1 => "Verbs",
         Types.WordType.Tags.Verb2 => "Verbs",
         Types.WordType.Tags.Verb3 => "Verbs",
         Types.WordType.Tags.Verb12 => "Verbs",
         Types.WordType.Tags.Verb13 => "Verbs",
         Types.WordType.Tags.Verb23 => "Verbs",
         Types.WordType.Tags.Verb123 => "Verbs",
         Types.WordType.Tags.Noun => "Nouns",
         Types.WordType.Tags.AssociativeNoun => "Nouns",
         Types.WordType.Tags.TerminalDigit => "Digits",
         Types.WordType.Tags.NonTerminalDigit => "Digits",
         _ => FormatWordType(word.WordType) + "s",
      };
   }

   internal static string FormatInflectionStep(Types.Inflection inflection) {
      return inflection.Tag switch {
         Types.Inflection.Tags.Argument1 => "A1",
         Types.Inflection.Tags.Argument2 => "A2",
         Types.Inflection.Tags.Argument3 => "A3",
         Types.Inflection.Tags.Definite => "DEF",
         Types.Inflection.Tags.Desiderative => "DES",
         Types.Inflection.Tags.Existence => "EXS",
         Types.Inflection.Tags.Gerund => "GER",
         Types.Inflection.Tags.Hortative => "HOR",
         Types.Inflection.Tags.Hypothetical => "HYP",
         Types.Inflection.Tags.Imperative => "IMP",
         Types.Inflection.Tags.Intention => "INT",
         Types.Inflection.Tags.Lone => "LON",
         Types.Inflection.Tags.Optative => "OPT",
         Types.Inflection.Tags.Partial1 => "P1",
         Types.Inflection.Tags.Partial2 => "P2",
         Types.Inflection.Tags.Partial3 => "P3",
         Types.Inflection.Tags.Perfect => "PER",
         Types.Inflection.Tags.Possession => "POS",
         Types.Inflection.Tags.Prefixed => "PRE",
         Types.Inflection.Tags.Progressive => "PRO",
         Types.Inflection.Tags.Quality => "QUA",
         Types.Inflection.Tags.Shift2 => "S2",
         Types.Inflection.Tags.Shift3 => "S3",
         Types.Inflection.Tags.AttributiveIdentity => "AID",
         Types.Inflection.Tags.PredicativeIdentity => "PID",
         _ => throw new ArgumentOutOfRangeException(
            $"Invalid inflection: {inflection}"),
      };
   }

   private static string FormatWordType(Types.WordType wordType) {
      return wordType.Tag switch {
         Types.WordType.Tags.Verb0 => "0-verb",
         Types.WordType.Tags.Verb1 => "1-verb",
         Types.WordType.Tags.Verb12 => "1-2-verb",
         Types.WordType.Tags.Verb123 => "1-2-3-verb",
         Types.WordType.Tags.Verb13 => "1-3-verb",
         Types.WordType.Tags.Verb2 => "2-verb",
         Types.WordType.Tags.Verb3 => "3-verb",
         Types.WordType.Tags.Verb23 => "2-3-verb",
         Types.WordType.Tags.AssociativeNoun => "Associative noun",
         Types.WordType.Tags.TerminalDigit => "Digit",
         Types.WordType.Tags.NonTerminalDigit => "Digit",
         _ => wordType.ToString(),
      };
   }

   private static string FormatInflection(Types.Inflection inflection) {
      return inflection.Tag switch {
         Types.Inflection.Tags.Argument1 => "Argument 1",
         Types.Inflection.Tags.Argument2 => "Argument 2",
         Types.Inflection.Tags.Argument3 => "Argument 3",
         Types.Inflection.Tags.Partial1 => "Partial 1",
         Types.Inflection.Tags.Partial2 => "Partial 2",
         Types.Inflection.Tags.Partial3 => "Partial 3",
         Types.Inflection.Tags.Shift1 => "Shift 1",
         Types.Inflection.Tags.Shift2 => "Shift 2",
         Types.Inflection.Tags.Shift3 => "Shift 3",
         Types.Inflection.Tags.AttributiveIdentity => "Attributive identity",
         Types.Inflection.Tags.PredicativeIdentity => "Predicative identity",
         _ => inflection.ToString(),
      };
   }

   private static WCEtymology ConvertEtymology(Types.Etymology etymology) {
      return etymology switch {
         Types.Etymology.Clipping clipping => new Etymology { Clipping = clipping.Item },
         Types.Etymology.Combination combination => new Etymology
            { Combination = ListModule.ToArray(combination.Item) },
         Types.Etymology.Contraction contraction => new Etymology { Contraction = contraction.Item },
         Types.Etymology.Copy copy => new Etymology { Copy = copy.Item },
         Types.Etymology.Derivation derivation => new Etymology { Derivation = derivation.Item },
         Types.Etymology.Foreign foreign => new Etymology { Foreign = foreign.Item },
         Types.Etymology.Metaphor metaphor => new Etymology { Metaphor = metaphor.Item },
         Types.Etymology.Variant variant => new Etymology { Variant = variant.Item },
         _ => throw new UnreachableException(),
      };
   }
}