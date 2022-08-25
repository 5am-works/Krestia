namespace Krestia.Lexicon;

public class Lexicon {
   public List<Word> Nouns { get; set; } = new();
   public List<Word> AssociativeNouns { get; set; } = new();
   public List<Verb> Verbs { get; set; } = new();
   public List<Word> OtherWords { get; set; } = new();
   public List<List<string>> RelatedWords { get; set; } = new();
}

public class Word {
   public string Spelling { get; set; } = null!;
   public string Meaning { get; set; } = null!;
   public string? Gloss { get; set; }
   public string? ExpandedForm { get; set; }
   public List<string> Roots { get; set; } = new();
   public string? Remarks { get; set; }
}

public class Verb : Word {
   public string Context { get; set; } = null!;
}