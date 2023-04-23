module Krestia.Core.Tests.WordTypeTests

open Krestia.Core.Lexicon.Lexicon
open Krestia.Core.Decompose
open Krestia.Core.Types
open NUnit.Framework

[<TestFixture>]
type LexiconTests() =
   [<Test>]
   member this.TestAllWords() =
      for word in lexicon.Words do
         let decomposed = decompose word.Spelling

         Assert.That(
            Option.isSome decomposed,
            Is.True,
            "Failed to decompose {0}",
            word.Spelling
         )

   member private this.testWordType (expected: WordType) (word: Word) =
      let spelling = word.Spelling

      match baseTypeOf word.Spelling with
      | Some _ ->
         decompose spelling
         |> Option.map (fun result ->
            let baseWord = result.BaseWord
            let actualType = result.WordType
            let inflections = result.Steps
            if baseWord <> word.Spelling then
               let collidedWord = List.tryFind (fun word -> word.Spelling = baseWord) lexicon.Words

               match collidedWord with
               | Some _ ->

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
