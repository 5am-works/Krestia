module Krestia.Core.Lexicon.LexiconHelpers

open Krestia.Core.Lexicon.Types

let private newWord spelling meaning wordType =
   { Spelling = spelling
     Meaning = meaning
     QuantifiedMeaning = None
     Gloss = None
     ExpandedForm = None
     Etymology = None
     Remarks = None
     ExampleUsages = []
     Domains = []
     AdditionalInfo = AdditionalInfo.NoInfo
     WordType = wordType }

type NounBuilder(spelling: string) =
   member _.Yield _ = ()

   [<CustomOperation("meaning")>]
   member _.DefineMeaning((), meaning: string) =
      newWord spelling meaning Noun

   [<CustomOperation("qualified")>]
   member _.DefineQualifiedMeaning(noun: Word, qualified: string) =
      { noun with QuantifiedMeaning = Some qualified }

let noun spelling = NounBuilder spelling

type VerbBuilder(spelling: string) =
   let verbType =
      match spelling with
      | _ when spelling.EndsWith("m") -> Verb0
      | _ when spelling.EndsWith("s") -> Verb1
      | _ when spelling.EndsWith("t") -> Verb12
      | _ when spelling.EndsWith("p") -> Verb123
      | _ when spelling.EndsWith("g") -> Verb2
      | _ when spelling.EndsWith("n") -> Verb3
      | _ when spelling.EndsWith("v") -> Verb23
      | _ when spelling.EndsWith("k") -> Verb13
      | _ -> failwith $"Not a verb: {spelling}"

   member _.Yield _ = ()

   [<CustomOperation("meaning")>]
   member _.DefineMeaning((), meaning: string) : Word =
      newWord spelling meaning verbType

let verb spelling = VerbBuilder spelling

type LexiconBuilder() =
   member _.Yield word = word
   member _.Run(lexicon: Lexicon) = lexicon

   member _.Delay(f: unit -> Lexicon) = f ()
   member _.Delay(f: unit -> Word) =
      { Words = [ f () ] }

   member _.Combine(word: Word, lexicon: Lexicon) =
      { lexicon with Words = word :: lexicon.Words }

let lexicon = LexiconBuilder()
