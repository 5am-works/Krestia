using NUnit.Framework;

namespace Krestia.Lexicon.Tests;

public class Tests {
   private Lexicon lexicon = null!;

   [SetUp]
   public void Setup() {
      lexicon = LexiconLoader.Load();
   }

   [Test]
   public void Test1() {
      Assert.Pass();
   }
}