using static Krestia.Core.Lexicon.Lexicon;

namespace Krestia.Core.Tests;

public class LexiconTests {
   [SetUp]
   public void Setup() { }

   [Test]
   public void PrintLexicon() {
      printLexicon();
      Assert.Pass();
   }
}