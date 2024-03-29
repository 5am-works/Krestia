﻿module Krestia.Core.Types

open System

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

type Inflection =
   | Definite
   | Possession
   | PredicativeIdentity
   | AttributiveIdentity
   | Gerund
   | Instance
   | Existence
   | Lone
   | Progressive
   | Perfect
   | Intention
   | Hypothetical
   | Desiderative
   | Imperative
   | Hortative
   | Optative
   | Argument1
   | Argument2
   | Argument3
   | Shift1
   | Shift2
   | Shift3
   | Partial1
   | Partial2
   | Partial3
   | Quality
   | Uninflectable
   | Prefixed

type VerbAttribute =
   | Negation
   | Capacity

type Etymology =
   | Combination of string list
   | Variant of string
   | Metaphor of string
   | Clipping of string
   | Copy of string
   | Contraction of string
   | Foreign of string
   | Derivation of string

type ExampleUsage = { Text: string; Translation: string }

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

type Lexicon =
   { Words: Word list
     RelatedWords: string list list }

let private nounEndings =
   [ "pa"
     "pe"
     "pi"
     "ta"
     "te"
     "ti"
     "ka"
     "ke"
     "ki"
     "ma"
     "me"
     "mi"
     "na"
     "ne"
     "ni" ]

let findWordTypeOf (spelling: string) =
   match spelling with
   | "mi"
   | "po"
   | "vo"
   | "no"
   | "te"
   | "si"
   | "li"
   | "so"
   | "ke"
   | "gi" -> Some NonTerminalDigit
   | "mira"
   | "pona"
   | "vora"
   | "nona"
   | "tera"
   | "sina"
   | "lira"
   | "sona"
   | "kera"
   | "gina" -> Some TerminalDigit
   | _ when spelling.Chars 0 |> Char.IsUpper -> Some Name
   | _ when spelling.EndsWith('m') -> Some Verb0
   | _ when spelling.EndsWith('s') -> Some Verb1
   | _ when spelling.EndsWith('t') -> Some Verb12
   | _ when spelling.EndsWith('p') -> Some Verb123
   | _ when spelling.EndsWith('g') -> Some Verb2
   | _ when spelling.EndsWith('n') -> Some Verb3
   | _ when spelling.EndsWith('v') -> Some Verb23
   | _ when spelling.EndsWith('k') -> Some Verb13
   | _ when spelling.EndsWith('l') -> Some Modifier
   | _ when spelling.EndsWith("dre") || spelling.EndsWith("gre") -> Some AssociativeNoun
   | _ when List.exists (fun (suffix: string) -> spelling.EndsWith suffix) nounEndings -> Some Noun
   | _ -> None

let isVerb word =
   match word.WordType with
   | Verb0
   | Verb1
   | Verb2
   | Verb3
   | Verb12
   | Verb13
   | Verb23
   | Verb123 -> true
   | _ -> false
