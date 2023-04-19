module Krestia.Core.Lexicon.Lexicon

open Krestia.Core.Lexicon.LexiconHelpers

let lexicon =
   lexicon {
      noun "kuna" { meaning "water"; qualified "drop of water" }
      noun "gremi" { meaning "sky" }

      verb "bet" { meaning "to move" }
      verb "liret" { meaning "to look at" }
   }

let printLexicon () = printfn $"{lexicon}"
