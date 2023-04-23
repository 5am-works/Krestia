module Krestia.Core.Decompose

open System
open Krestia.Core.Inflections
open Krestia.Core.Types

type DecomposedWord =
   { BaseWord: string
     WordType: WordType
     Steps: Inflection list
     VerbAttributes: VerbAttribute list }

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

let uninflectableWordTypes =
   [ Pronoun
     TerminalDigit
     NonTerminalDigit
     Name ]
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

let private specialPredicates =
   [ isName
     isKeyword
     isPronoun
     isTerminalDigit
     isNonTerminalDigit ]

let private standardPredicates =
   [ isNoun
     isAssociativeNoun
     isVerb
     isModifier
     isCompound ]

let baseTypeOf word =
   List.tryPick (fun p -> p word) predicates
   
let isReducedForm reducedType originalType =
   match originalType with
   | Verb123 -> reducedType <> Verb123
   | Verb12 -> reducedType = Verb0 || reducedType = Verb1 || reducedType = Verb2
   | Verb13 -> reducedType = Verb0 || reducedType = Verb1 || reducedType = Verb3
   | Verb23 -> reducedType = Verb0 || reducedType = Verb2 || reducedType = Verb3
   | Verb1 | Verb2 | Verb3 -> reducedType = Verb0
   | Verb0 -> false
   | _ -> failwith $"Not a verb type {originalType}"

let rec private tryMatch
   (word: string)
   requiredWordType
   (InflectionRule (baseTypes, inflection, suffix, newType, isTerminal))
   =
   if not (word.EndsWith(suffix)) then
      None
   elif isTerminal && Option.isSome requiredWordType then
      None
   elif Option.map (List.contains newType) requiredWordType
        |> Option.defaultValue true then
      let remaining =
         word.Substring(0, word.Length - suffix.Length)

      decomposeStep remaining (Some baseTypes)
      |> Option.filter (fun (_, wordType, _) ->
         not
         <| Set.contains wordType uninflectableWordTypes)
      |> Option.map (fun (baseWord, wordType, inflections) ->
         (baseWord, wordType, inflection :: inflections))
   else
      None

and private decomposeStep
   word
   requiredWordType
   : (string * WordType * Inflection list) option =
   specialPredicates
   |> List.tryPick (fun f -> f word)
   |> Option.map (fun wordType -> (word, wordType, []))
   |> Option.orElseWith (fun () ->
      rules
      |> List.tryPick (tryMatch word requiredWordType)
      |> Option.orElseWith (fun () ->
         baseTypeOf word
         |> Option.filter (fun wordType ->
            requiredWordType
            |> Option.map (List.contains wordType)
            |> Option.defaultValue true)
         |> Option.map (fun wordType -> (word, wordType, []))))

let decompose word =
   decomposeStep word None
   |> Option.map (fun (word, wordType, steps) ->
      { BaseWord = word
        WordType = wordType
        Steps = List.rev steps
        VerbAttributes = [] })
