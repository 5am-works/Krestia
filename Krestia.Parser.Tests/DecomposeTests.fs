module Krestia.Parser.Tests.DecomposeTests

open NUnit.Framework
open Krestia.Parser.WordType
open Krestia.Parser.Decompose

[<TestFixture>]
type DecomposeTests() =
   [<Test>]
   member this.testNouns() =
      let result = decompose "kunas"

      Assert.That(
         result,
         Is.EqualTo(
            Some(
               { BaseWord = "kuna"
                 WordType = Noun
                 Steps = [ PredicativeIdentity ]
                 VerbAttributes = [] }
            )
         )
      )
