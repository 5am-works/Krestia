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

let private slotCount word =
   match word.WordType with
   | Verb0 -> 0
   | Verb1 -> 1
   | Verb2
   | Verb12 -> 2
   | Verb3
   | Verb13
   | Verb23
   | Verb123 -> 3
   | _ -> failwith $"Not a verb: {word.Spelling}"

type WordBuilder(spelling: string, wordType: WordType) =
   member _.Yield _ = ()

   member _.Run(word: Word) =
      if isVerb word then
         match word.AdditionalInfo with
         | AdditionalInfo.Verb _ -> ()
         | _ -> failwith $"{spelling} needs verb info"

      word

   [<CustomOperation("meaning")>]
   member _.DefineMeaning((), meaning: string) = newWord spelling meaning wordType

   [<CustomOperation("qualified")>]
   member _.DefineQualifiedMeaning(word: Word, qualified: string) =
      { word with
         QuantifiedMeaning = Some qualified }

   [<CustomOperation("gloss")>]
   member _.DefineGloss(word: Word, gloss: string) = { word with Gloss = Some gloss }

   [<CustomOperation("expanded")>]
   member _.DefineExpandedForm(word: Word, expanded: string) =
      { word with
         ExpandedForm = Some expanded }

   [<CustomOperation("etymology")>]
   member _.DefineEtymology(word: Word, etymology: Etymology) =
      { word with Etymology = Some etymology }

   [<CustomOperation("remarks")>]
   member _.DefineRemarks(word: Word, remarks: string) = { word with Remarks = Some remarks }

   [<CustomOperation("example")>]
   member _.AddExampleUsage(word: Word, exampleText: string, translation: string) =
      { word with
         ExampleUsages =
            { Text = exampleText
              Translation = translation }
            :: word.ExampleUsages }

   [<CustomOperation("domains")>]
   member _.DefineDomains(word: Word, domains: string list) = { word with Domains = domains }

   [<CustomOperation("syntax")>]
   member _.DefineSyntax(word: Word, syntax: string) =
      match word.AdditionalInfo with
      | AdditionalInfo.NoInfo when isVerb word ->
         { word with
            AdditionalInfo = AdditionalInfo.Verb { Syntax = syntax; SlotRemarks = [] } }
      | _ when isVerb word -> failwith $"Verb info already defined for {spelling}"
      | _ -> failwith $"Cannot attach verb info to {spelling}"

   [<CustomOperation("slotRemarks")>]
   member _.DefineSlotRemarks(word: Word, remarks: string option list) =
      match word.AdditionalInfo with
      | AdditionalInfo.Modifier _
      | AdditionalInfo.NoInfo -> failwith $"{spelling} has no verb info defined"
      | AdditionalInfo.Verb verbInfo ->
         if remarks.Length <> slotCount word then
            failwith $"{spelling} does not have the correct number of slot remarks"
         else
            AdditionalInfo.Verb { verbInfo with SlotRemarks = remarks }

   [<CustomOperation("modifies")>]
   member _.DefineModifiableTypes(word: Word, types: WordType list) =
      match word.AdditionalInfo with
      | AdditionalInfo.NoInfo when word.WordType = Modifier ->
         { word with
            AdditionalInfo =
               AdditionalInfo.Modifier
                  { ModifiableTypes = Set.ofList types
                    Attachments = [] } }
      | AdditionalInfo.Modifier _ -> failwith $"{spelling} already has modifier info attached"
      | _ -> failwith $"{spelling} is not a modifier"

   [<CustomOperation("attachments")>]
   member _.DefineAttachments(word: Word, attachment: (WordType * string option) list) =
      match word.AdditionalInfo with
      | AdditionalInfo.Modifier modifierInfo ->
         { word with
            AdditionalInfo =
               AdditionalInfo.Modifier
                  { modifierInfo with
                     Attachments =
                        attachment
                        |> List.map (fun (wordType, remarks) ->
                           { WordType = wordType
                             Remarks = remarks }) } }
      | _ -> failwith $"{spelling} has no modifier info for attachments"

let word (spelling: string) =
   match findWordTypeOf spelling with
   | Some wordType -> WordBuilder(spelling, wordType)
   | None -> failwith $"Invalid word: {spelling}"

let verbInfo syntax = { Syntax = syntax; SlotRemarks = [] }

type LexiconBuilder() =
   member _.Yield word = word
   member _.Run(lexicon: Lexicon) = lexicon

   member _.Delay(_: unit -> unit) = { Words = []; RelatedWords = [] }
   member _.Delay(f: unit -> Lexicon) = f ()
   member _.Delay(f: unit -> Word) = { Words = [ f () ]; RelatedWords = [] }

   member _.Combine(word: Word, lexicon: Lexicon) =
      { lexicon with
         Words = word :: lexicon.Words }
      
   [<CustomOperation("related")>]
   member _.DefineRelatedWords(lexicon: Lexicon, words: string list) =
      { lexicon with RelatedWords = words :: lexicon.RelatedWords }

let lexicon = LexiconBuilder()
