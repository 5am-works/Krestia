using System.Linq;
using static Krestia.Core.Types;

namespace Krestia.Functions; 

internal static class LexiconHelper {
   internal static Word? Find(this Lexicon lexicon, string spelling) {
      return lexicon.Words.FirstOrDefault(word => word.Spelling == spelling);
   }

   internal static Word? FindNormalFormOfVerb(this Lexicon lexicon, string stem) {
      return lexicon.Words.FirstOrDefault(word => isVerb(word) && word.Spelling.StartsWith(stem));
   }
}