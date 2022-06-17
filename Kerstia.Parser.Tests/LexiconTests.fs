module Kerstia.Parser.Tests

open Krestia.Parser.Lexicon
open NUnit.Framework

[<Test>]
let Test1 () =
    let _ = dictionary
    Assert.Pass()