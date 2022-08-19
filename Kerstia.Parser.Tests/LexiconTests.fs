module Kerstia.Parser.Tests.WordTypeTests

open Krestia.Lexicon
open Krestia.Parser.Decompose
open Krestia.Parser.WordType
open NUnit.Framework

[<TestFixture>]
type LexiconTests() =
   [<DefaultValue>]
   val mutable lexicon: WordIndex

   [<SetUp>]
   member this.SetUp() = this.lexicon <- WordIndex()

   [<Test>]
   member this.TestAllWords() =
      for word in this.lexicon.AllWords do
         let decomposed = decompose word.Spelling

         Assert.That(
            Option.isSome decomposed,
            Is.True,
            "Failed to decompose {0}",
            word.Spelling
         )

   [<Test>]
   member this.testNouns() =
      Assert.Multiple (fun () ->
         for noun in this.lexicon.Nouns do
            this.testWordType Noun noun)

   [<Test>]
   member this.testAssociativeNouns() =
      Assert.Multiple (fun () ->
         for word in this.lexicon.AssociativeNouns do
            this.testWordType AssociativeNoun word)

   [<Test>]
   member this.testVerbs() =
      Assert.Multiple (fun () ->
         for verb in this.lexicon.Verbs do
            let expected =
               isVerb verb.Spelling
               |> Option.defaultWith (fun () ->
                  failwithf $"Not a verb %s{verb.Spelling}")

            this.testWordType expected verb)

   member private this.testWordType (expected: WordType) (word: Word) =
      let spelling = word.Spelling

      match baseTypeOf word.Spelling with
      | Some baseType ->
         decompose spelling
         |> Option.map (fun (baseWord, actualType, inflections) ->
            if baseWord <> word.Spelling then
               let collidedWord =
                  this.lexicon.Find(baseWord) |> Option.ofObj

               match collidedWord with
               | Some collidedWord ->

                  Assert.Fail(
                     "{0} is an inflected form of {1}, which exists in the dictionary",
                     word.Spelling,
                     baseWord
                  )
               | None ->
                  Assert.Warn(
                     "{0} is an inflected form of {1} (which does not in the dictionary but can exist as {2})",
                     word.Spelling,
                     baseWord,
                     actualType
                  )
            else
               Assert.That(
                  actualType,
                  Is.EqualTo(expected),
                  "Failure in {0}",
                  spelling
               )

               Assert.That(inflections, Is.Empty, "Failure in {0}", spelling))
         |> Option.defaultWith (fun () ->
            Assert.Fail($"Decomposition failed %s{spelling}"))
      | None -> Assert.Fail($"{word.Spelling} has an unknown type")
