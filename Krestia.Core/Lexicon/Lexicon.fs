module Krestia.Core.Lexicon.Lexicon

open Krestia.Core.Lexicon.LexiconHelpers

let lexicon =
   lexicon {
      word "kuna" {
         meaning "water"
         qualified "drop of water"
      }

      word "gremi" { meaning "sky" }
      word "bet" { meaning "to move" }
      word "liret" {
         meaning "to look at"
         syntax "{0} looks at {1}"
      }
   }

let printLexicon () = printfn $"{lexicon}"
