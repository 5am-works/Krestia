module Krestia.Core.Phonotactics

open System

type Letter =
   | Consonant of char
   | Vowel of char

let private normalize (word: string) =
   word.Replace("aa", "ɒ").ToLowerInvariant()

let private categorizeLetter letter =
   match letter with
   | 'i' | 'e' | 'a' | 'u' | 'o' | 'ɒ' -> Vowel letter
   | _ -> Consonant letter

let private verbSuffixes =
   [ 'm'; 's'; 't'; 'g'; 'v'; 'n'; 'k'; 'p' ] |> Set.ofList

let private removeSuffix (word: string) =
   if (Char.IsUpper(word.Chars(0)) || word.StartsWith('h')) then
      word
   else if (word.EndsWith("dri") || word.EndsWith("gri")) then
      word.Substring(0, word.Length - 3)
   else if verbSuffixes.Contains(word.Chars(word.Length - 1)) then
      word.Substring(0, word.Length - 1)
   else
      word

let private categorizeLetters = List.map categorizeLetter

let splitIntoSyllables (word: string) (withSuffix: bool) = 
   let normalized =
      (if withSuffix then word else removeSuffix word)
      |> normalize
   let rec dividiAk firstSyllable (letters: Letter list): Result<string list, string> =
      match letters with
      // CCVC
      | Consonant k1 :: Consonant k2 :: Vowel v :: Consonant kf :: Consonant kk2 :: restantaj ->
         if firstSyllable then
            dividiAk false (Consonant(kk2) :: restantaj)
            |> Result.map (fun restantajSilaboj ->
                  String.Concat([ k1; k2; v; kf ])
                  :: restantajSilaboj)
         else
            Error "Vorto ne rajtas komenci per du Consonantj"
      | [ Consonant k1; Consonant k2; Vowel v; Consonant kf ] ->
         if firstSyllable
         then [ String.Concat([ k1; k2; v; kf ]) ] |> Ok
         else Error "Vorto ne rajtas komenci per du Consonantj"
      // CCV
      | Consonant k1 :: Consonant k2 :: Vowel v :: Consonant kf :: Vowel v2 :: restantaj ->
         if firstSyllable then
            dividiAk false (Consonant(kf) :: Vowel(v2) :: restantaj)
            |> Result.map (fun restantajSilaboj -> String.Concat([ k1; k2; v ]) :: restantajSilaboj)
         else
            Error "Vorto ne rajtas komenci per du Consonantj"
      | Consonant k1 :: Consonant k2 :: Vowel v :: Vowel v2 :: restantaj ->
         if firstSyllable then
            dividiAk false (Vowel(v2) :: restantaj)
            |> Result.map (fun restantajSilaboj -> String.Concat([ k1; k2; v ]) :: restantajSilaboj)
         else
            Error "Vorto ne rajtas komenci per du Consonantj"
      | [ Consonant k1; Consonant k2; Vowel v ] ->
         if firstSyllable
         then [ String.Concat([ k1; k2; v ]) ] |> Ok
         else Error "Vorto ne rajtas komenci per du Consonantj"
      // CVC
      | Consonant k1 :: Vowel v :: Consonant kf :: Consonant kk2 :: restantaj ->
         dividiAk false (Consonant(kk2) :: restantaj)
         |> Result.map (fun restantajSilaboj -> String.Concat([ k1; v; kf ]) :: restantajSilaboj)
      | [ Consonant k1; Vowel v; Consonant kf ] -> [ String.Concat([ k1; v; kf ]) ] |> Ok
      // CV
      | Consonant k1 :: Vowel v :: Consonant kk2 :: Vowel v2 :: restantaj ->
         dividiAk false (Consonant(kk2) :: Vowel(v2) :: restantaj)
         |> Result.map (fun restantajSilaboj -> String.Concat([ k1; v ]) :: restantajSilaboj)
      | Consonant k1 :: Vowel v :: Vowel v2 :: restantaj ->
         dividiAk false (Vowel(v2) :: restantaj)
         |> Result.map (fun restantajSilaboj -> String.Concat([ k1; v ]) :: restantajSilaboj)
      | [ Consonant k1; Vowel v ] -> [ String.Concat([ k1; v ]) ] |> Ok
      // VC
      | Vowel v :: Consonant kf :: Consonant kk2 :: restantaj ->
         dividiAk false (Consonant(kk2) :: restantaj)
         |> Result.map (fun restantajSilaboj -> String.Concat([ v; kf ]) :: restantajSilaboj)
      | [ Vowel v; Consonant kf ] -> [ String.Concat([ v; kf ]) ] |> Ok
      // V
      | Vowel v :: Consonant kf :: Vowel v2 :: restantaj ->
         dividiAk false (Consonant(kf) :: Vowel(v2) :: restantaj)
         |> Result.map (fun restantajSilaboj -> v.ToString() :: restantajSilaboj)
      | Vowel v :: Vowel v2 :: restantaj ->
         dividiAk false (Vowel(v2) :: restantaj)
         |> Result.map (fun restantajSilaboj -> v.ToString() :: restantajSilaboj)
      | [ Vowel v ] -> [ v.ToString() ] |> Ok
      // Eraro
      | [] -> Ok []
      | _ -> Error $"Cannot split %A{letters}"

   dividiAk
      true
      (normalized.ToCharArray()
       |> List.ofArray
       |> categorizeLetters)