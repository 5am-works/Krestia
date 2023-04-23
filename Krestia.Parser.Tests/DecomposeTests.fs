module Krestia.Core.Tests.DecomposeTests

open NUnit.Framework
open Krestia.Core.Types
open Krestia.Core.Decompose

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

   [<Test>]
   member this.GlatrosaaRegression() =
      let result = decompose "glatrosaa"

      Assert.That(
         result,
         Is.EqualTo(
            Some(
               { BaseWord = "glat"
                 WordType = Verb12
                 Steps = [ Partial2; Argument1 ]
                 VerbAttributes = [] }
            )
         )
      )
