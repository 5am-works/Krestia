﻿namespace Krestia.Web.Common;

public class SearchResponse {
   public string? DecomposedWord { get; init; }
   public string? Lemma { get; init; }
   public IReadOnlyList<WordWithMeaning> Results { get; init; }
   public string? Gloss { get; init; }
   public IReadOnlyList<DecomposedResult> DecomposedResults { get; init; }
   public double? NumberResult { get; set; }

   public SearchResponse() {
      Results = new List<WordWithMeaning>();
      DecomposedResults = Array.Empty<DecomposedResult>();
   }

   public bool IsEmpty =>
      !Results.Any() && DecomposedWord is null && Lemma is null &&
      Gloss is null && DecomposedResults.All(r => r.IsEmpty) && NumberResult is null;
}

public readonly struct WordWithMeaning {
   public string Spelling { get; init; }
   public string Meaning { get; init; }

   public WordWithMeaning(string spelling, string meaning) {
      Spelling = spelling;
      Meaning = meaning;
   }
}

public readonly struct DecomposedResult {
   public string SearchedWord { get; init; }
   public string? Meaning { get; init; }
   public string? BaseWord { get; init; }
   public string? OriginalWord { get; init; }

   public IReadOnlyList<string> Steps { get; init; }

   public DecomposedResult(string searchedWord, string? meaning = null,
      string? baseWord = null, string? originalWord = null,
      IReadOnlyList<string>? steps = null) {
      SearchedWord = searchedWord;
      Meaning = meaning;
      BaseWord = baseWord;
      OriginalWord = originalWord;
      Steps = steps ?? new List<string>();
   }

   public bool IsEmpty =>
      Meaning is null && BaseWord is null && Steps.Count == 0;
}