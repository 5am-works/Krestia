namespace Krestia.Web.Common;

public class WordResponse {
   private List<string>? _categories;

   public string Spelling { get; init; } = null!;

   public string? Stem { get; init; }

   public Etymology? Etymology { get; init; }

   public string? Meaning { get; init; }

   public string? QuantifiedMeaning { get; init; }

   public string? Gloss { get; init; }

   public string? Remark { get; init; }

   public List<string>? Categories {
      get => _categories ?? new List<string>();
      set => _categories = value;
   }

   public string? WordType { get; init; }

   public IEnumerable<string>? Syllables { get; init; }

   public IEnumerable<InflectedForm> InflectedForms { get; init; } = null!;

   public IEnumerable<string?>? Slots { get; init; }

   public string? Syntax { get; init; }

   public IEnumerable<string>? CanModifyWordTypes { get; init; }

   public IEnumerable<string>? AttachmentInflections { get; init; }

   public string? ExpandedForm { get; init; }

   public IEnumerable<Tuple<string, string>>? ExampleUsages { get; init; }
}

public class Etymology {
   public string? Clipping { get; init; }
   public string? Variant { get; init; }
   public string? Metaphor { get; init; }
   public string[]? Combination { get; init; }
   public string? Copy { get; init; }
   public string? Contraction { get; init; }
   public string? Foreign { get; init; }
   public string? Derivation { get; init; }
}

public class InflectedForm {
   public string FormName { get; init; } = null!;
   public string FormSpelling { get; init; } = null!;
}