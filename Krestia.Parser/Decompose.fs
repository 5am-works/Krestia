module Krestia.Parser.Decompose

open System
open WordType

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

let nonTerminalDigits =
   [ "mi"
     "po"
     "vo"
     "no"
     "te"
     "si"
     "li"
     "so"
     "ke"
     "gi" ]
   |> Set.ofList

let terminalDigits =
   [ "mira"
     "pona"
     "vora"
     "nona"
     "tera"
     "sina"
     "lira"
     "sona"
     "kera"
     "gina" ]
   |> Set.ofList

let isNoun (word: string) =
   nounEndings
   |> List.tryFind word.EndsWith
   |> Option.map (fun _ -> Noun)

let isAssociativeNoun (word: string) =
   if word.EndsWith("dri") || word.EndsWith("gri") then
      Some AssociativeNoun
   else
      None

let isNonTerminalDigit (word: string) =
   if Set.contains word nonTerminalDigits then
      Some NonTerminalDigit
   else
      None

let isTerminalDigit (word: string) =
   if Set.contains word terminalDigits then
      Some TerminalDigit
   else
      None

let isKeyword _ = None

let isName (word: string) =
   if Char.IsUpper(word.Chars(0)) then
      Some Name
   else
      None

let isPronoun (word: string) =
   if word.StartsWith('h') then
      Some Pronoun
   else
      None

let isVerb (word: string) =
   let last = word.Chars(word.Length - 1)

   match last with
   | 'm' -> Some Verb0
   | 's' -> Some Verb1
   | 't' -> Some Verb12
   | 'p' -> Some Verb123
   | 'g' -> Some Verb2
   | 'v' -> Some Verb23
   | 'n' -> Some Verb3
   | 'k' -> Some Verb13
   | _ -> None

let isModifier (word: string) =
   if word.EndsWith('l') then
      Some Modifier
   else
      None

let isCompound (word: string) =
   if word.EndsWith("li") && word <> "li" then
      Some Compound
   else
      None

let private predicates =
   [ isName
     isKeyword
     isPronoun
     isTerminalDigit
     isNonTerminalDigit
     isNoun
     isAssociativeNoun
     isVerb
     isModifier
     isCompound ]

let baseTypeOf word =
   List.tryPick (fun p -> p word) predicates