namespace Krestia.Lexicon;

public class Lexicon {
   public Word[] Nouns { get; init; } = Array.Empty<Word>();
   public Word[] AssociativeNouns { get; init; } = Array.Empty<Word>();
   public Word[] Verbs { get; init; } = Array.Empty<Word>();
   public Word[] Names { get; init; } = Array.Empty<Word>();
   public Word[] OtherWords { get; init; } = Array.Empty<Word>();
   public string[][] RelatedWords { get; init; } = Array.Empty<string[]>();
}

public readonly struct Word {
   public Word() { }

   public string Spelling { get; init; } = null!;
   public string Meaning { get; init; } = null!;
   public string? QuantifiedMeaning { get; init; } = null; 
   public string? Gloss { get; init; } = null;
   public string? ExpandedForm { get; init; } = null;
   public Etymology? Roots { get; init; } = null;
   public string? Remarks { get; init; } = null;

   public ExampleUsage[]? ExampleUsages { get; init; } = null;

   public string Context { get; init; } = null!;

   public string[]? Domains { get; init; } = null;
}

public readonly struct Etymology {
   public string[]? Combination { get; init; }
   public string? Variant { get; init; }
   public string? Metaphor { get; init; }
   public string? Clipping { get; init; }
   public string? Copy { get; init; }
   public string? Contraction { get; init; }
   public string? Foreign { get; init; }
   public string? Derivation { get; init; }
}

public readonly struct ExampleUsage {
   public string Text { get; init; }
   public string Translation { get; init; }
}