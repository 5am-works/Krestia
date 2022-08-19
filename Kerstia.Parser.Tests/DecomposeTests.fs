﻿module Kerstia.Parser.Tests.DecomposeTests

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
         Is.EqualTo(Some("kuna", Noun, [ PredicativeIdentity ]))
      )