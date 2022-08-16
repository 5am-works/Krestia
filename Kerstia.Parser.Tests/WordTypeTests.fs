module Kerstia.Parser.Tests.WordTypeTests

open Krestia.Lexicon
open Krestia.Parser.Decompose
open Krestia.Parser.WordType
open NUnit.Framework

[<TestFixture>]
type WordTypeTests() =
   [<DefaultValue>]
   val mutable lexicon: Lexicon

   [<SetUp>]
   member this.SetUp() = this.lexicon <- LexiconLoader.Load()

   [<Test>]
   member this.testNouns() =
      this.testWordType Noun this.lexicon.Nouns

   [<Test>]
   member this.testAssociativeNouns() =
      this.testWordType AssociativeNoun this.lexicon.AssociativeNouns

   [<Test>]
   member this.testVerbs() =
      for verb in this.lexicon.Verbs do
         let word = verb.Spelling
         let wordType = baseTypeOf word
         Assert.That(wordType, Is.EqualTo(isVerb word))

   member private _.testWordType (expected: WordType) (words: Word seq) =
      for word in words do
         let spelling = word.Spelling
         let wordType = baseTypeOf spelling
         Assert.That(wordType, Is.EqualTo(Some expected))