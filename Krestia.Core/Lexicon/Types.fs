module Krestia.Core.Lexicon.Types

type WordType =
   | Noun
   | AssociativeNoun
   | Verb1
   | Verb2
   | Verb3
   | Verb12
   | Verb13
   | Verb23
   | Verb123
   | Verb0
   | Pronoun
   | Modifier
   | Name
   | NonTerminalDigit
   | TerminalDigit
   | Compound
   | Keyword
   
type Etymology =
   | Combination of string list
   
type ExampleUsage =
   { Text: string
     Translation: string }

type VerbInfo =
   { Syntax: string
     SlotRemarks: string option list }

type ModifierAttachment =
   { WordType: WordType
     Remarks: string option }
   
type ModifierInfo =
   { ModifiableTypes: Set<WordType>
     Attachments: ModifierAttachment list }

[<RequireQualifiedAccess>]
type AdditionalInfo =
   | Verb of VerbInfo
   | Modifier of ModifierInfo
   | NoInfo

type Word =
   { Spelling: string
     Meaning: string
     QuantifiedMeaning: string option
     Gloss: string option
     ExpandedForm: string option
     Etymology: Etymology option
     Remarks: string option
     ExampleUsages: ExampleUsage list
     Domains: string list
     AdditionalInfo: AdditionalInfo
     WordType: WordType }

type Lexicon = { Words: Word list }
