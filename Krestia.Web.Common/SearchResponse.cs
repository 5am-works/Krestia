﻿namespace Krestia.Web.Common;

public class SearchResponse {
   public string? DecomposedWord { get; set; }
   public string? Lemma { get; set; }
   public IEnumerable<WordWithMeaning> Results { get; set; }
   public string? Gloss { get; set; }
   public IEnumerable<string>? DecomposeSteps { get; set; }
   public IEnumerable<string>? GlossWords { get; set; }
   public IEnumerable<IEnumerable<string>>? GlossSteps { get; set; }
   public IEnumerable<string>? BaseWords { get; set; }
   public double? NumberResult { get; set; }

   public SearchResponse() {
      Results = new List<WordWithMeaning>();
   }

   public bool IsEmpty =>
      !Results.Any() && DecomposedWord is null && Lemma is null && Gloss is null && DecomposeSteps is null &&
      GlossWords is null && GlossSteps is null && BaseWords is null && NumberResult is null;
}

public readonly struct WordWithMeaning {
   public string Spelling { get; init; }
   public string Meaning { get; init; }

   public WordWithMeaning(string spelling, string meaning) {
      Spelling = spelling;
      Meaning = meaning;
   }
}