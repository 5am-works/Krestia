module Krestia.Core.Lexicon.LexiconHelpers

type Noun =
   { Spelling: string
     Meaning: string
     QuantifiedMeaning: string option
     Gloss: string option }

type Verb = { Spelling: string; Meaning: string }

type Lexicon = { Nouns: Noun list; Verbs: Verb list }

type NounBuilder(spelling: string) =
   member _.Yield _ = ()

   [<CustomOperation("meaning")>]
   member _.DefineMeaning((), meaning: string) =
      { Spelling = spelling
        Meaning = meaning
        QuantifiedMeaning = None
        Gloss = None }

   [<CustomOperation("qualified")>]
   member _.DefineQualifiedMeaning(noun: Noun, qualified: string) =
      { noun with
         QuantifiedMeaning = Some qualified }

let noun spelling = NounBuilder spelling

type VerbBuilder(spelling: string) =
   member _.Yield _ = ()

   [<CustomOperation("meaning")>]
   member _.DefineMeaning((), meaning: string) : Verb =
      { Spelling = spelling
        Meaning = meaning }

let verb spelling = VerbBuilder spelling

type LexiconBuilder() =
   member _.Yield word = word
   member _.Run(lexicon: Lexicon) = lexicon

   member _.Delay(f: unit -> Lexicon) = f ()
   member _.Delay(f: unit -> Noun) = { Nouns = [ f () ]; Verbs = [] }
   member _.Delay(f: unit -> Verb) = { Nouns = []; Verbs = [ f () ] }

   member _.Combine(noun: Noun, lexicon: Lexicon) =
      { lexicon with
         Nouns = noun :: lexicon.Nouns }
   
   member _.Combine(verb: Verb, lexicon: Lexicon) =
      { lexicon with Verbs = verb :: lexicon.Verbs }

let lexicon = LexiconBuilder()
