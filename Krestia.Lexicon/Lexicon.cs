using System.Collections.Immutable;

namespace Krestia.Lexicon;

public class Lexicon {
   public List<Word> Nouns { get; set; } = new();
   public List<Word> Verbs { get; set; } = new();
}

public class Word {
   public string Spelling { get; set; } = "";
   public string Meaning { get; set; } = "";
   public string Gloss { get; set; } = "";
   public List<string> Roots { get; set; } = new();
   public string? Remarks { get; set; }
}