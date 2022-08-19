namespace Krestia.Lexicon;

public class WordIndex {
   private readonly Lexicon _lexicon;
   private readonly Dictionary<string, Word> _index;
   public List<Word> Nouns => _lexicon.Nouns;
   public List<Verb> Verbs => _lexicon.Verbs;
   public List<Word> AssociativeNouns => _lexicon.AssociativeNouns;
   public IEnumerable<Word> AllWords => _index.Values;

   public WordIndex() {
      _lexicon = LexiconLoader.Load();
      _index = _lexicon.Nouns
         .Concat(_lexicon.Verbs)
         .Concat(_lexicon.AssociativeNouns)
         .Concat(_lexicon.OtherWords)
         .ToDictionary(w => w.Spelling, w => w);
   }

   public Word? Find(string word) {
      return _index.ContainsKey(word) ? _index[word] : null;
   }
}