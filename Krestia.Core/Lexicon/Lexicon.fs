module Krestia.Core.Lexicon.Lexicon

open Krestia.Core.Types
open Krestia.Core.Lexicon.LexiconHelpers

let lexicon =
   lexicon {
      word "grema" {
         meaning "world, plane of existence"
         gloss "world"
      }

      word "kuna" {
         meaning "water"
         quantified "drop of water"
      }

      word "trena" {
         meaning "stone (material)"
         gloss "stone"
      }

      word "poski" { meaning "fire" }

      word "duna" {
         meaning "sand"
         quantified "grain of sand"
      }

      word "ritma" {
         meaning "ash"
         quantified "ash particle"
      }

      word "lite" {
         meaning "night, nighttime"
         gloss "night"
      }

      word "mika" {
         meaning "day (24-hour period)"
         gloss "day"
      }

      word "mina" {
         meaning "daytime"
         gloss "day"
      }

      word "luvema" {
         meaning "rain"
         quantified "raindrop"
         gloss "rain"
      }

      word "lurika" { meaning "cloud" }

      word "seskoma" {
         meaning "snow"
         quantified "snowflake"
      }

      word "gelume" {
         meaning "air"
         quantified "atmosphere"
      }

      word "belime" {
         meaning "wind"
         quantified "gust of wind"
         etymology (Combination [ "bep"; "gelume" ])
      }

      word "lunata" {
         meaning "star (astronomical)"
         gloss "star"
      }

      word "gremi" {
         meaning "sky"
         etymology (Variant "grema")
      }

      word "temita" {
         meaning "mountain, hill"
         gloss "mountain"
      }

      word "kunata" {
         meaning "ocean, sea"
         gloss "ocean"
         etymology (Variant "kuna")
      }

      word "tatrete" { meaning "person, human" }
      word "breka" { meaning "male" }
      word "grike" { meaning "female" }
      word "tote" { meaning "child" }

      word "grita" {
         meaning "girl"
         expanded "tote grikel"
      }

      word "breta" {
         meaning "boy"
         expanded "tote brekal"
      }

      word "rone" {
         meaning "here"
         remarks "Refers to the location of the speaker"
      }

      word "prine" {
         meaning "away from here"
         remarks "Refers to anywhere where the speaker is not"
         gloss "away"
         example "leratae prine" "Go away!"
      }

      word "krite" { meaning "this" }
      word "prete" { meaning "that" }

      word "beseti" {
         meaning "zodiac sign"
         domains [ "Tatreta" ]
      }

      word "enita" { meaning "sheep" }
      word "kilite" { meaning "cattle" }
      word "glinki" { meaning "crab" }
      word "norite" { meaning "lion" }
      word "preta" { meaning "scale (weight)" }
      word "livopi" { meaning "scorpion" }
      word "remiti" { meaning "fish" }
      word "lepa" { meaning "apple" }
      word "meki" { meaning "tree" }
      word "soponi" { meaning "pain" }
      word "kumoma" { meaning "today" }
      word "almeki" { meaning "healthy" }
      word "golepi" { meaning "quiet" }
      word "meka" { meaning "red" }

      word "krena" {
         meaning "light (radiation)"
         remarks "Refers to light itself, and not any light emitters (e.g. lamps)"
      }

      word "kreta" {
         meaning "light (fixture)"
         etymology (Derivation "krena")
      }

      word "leti" { meaning "word" }

      word "moka" {
         meaning "open, public"
         gloss "open"
      }

      word "rena" {
         meaning "dream"
         remarks "Refers to unfulfilled wishes"
      }

      word "lumi" {
         meaning "forever, eternal"
         gloss "forever"
      }

      word "romote" { meaning "summer" }
      word "rinome" { meaning "winter" }

      word "epi" {
         meaning "I (first-person pronoun), we (when plural)"
         gloss "1P"
      }

      word "eti" {
         meaning "you (second-person pronoun)"
         gloss "2P"
         expanded "esika sil"
      }

      word "eki" {
         meaning "he, she, it, they (third-person pronoun)"
         gloss "3P"
      }

      word "todre" { meaning "parent of" }

      word "bodre" {
         meaning "father of"
         expanded "todri brekal"
      }

      word "gedre" {
         meaning "mother of"
         expanded "todri grikel"
      }

      word "ligre" { meaning "name of" }

      word "votogre" {
         meaning "twin of"
         example "Revi votogris Rivi" "Revi is the twin of Rivi."
         etymology (Combination [ "vora"; "tote" ])
      }

      word "liredre" { meaning "eye of" }
      word "ligre" { meaning "name of" }
      word "pregre" { meaning "weight of" }

      word "literas" {
         meaning "to die"
         gloss "die"
         syntax "{0} dies"
         etymology (Metaphor "lite")
      }

      word "luvem" {
         meaning "to rain"
         gloss "rain"
         syntax "it rains"
         expanded "gimesraam luvema"
      }

      word "gimet" {
         meaning "to fall"
         gloss "fall"
         syntax "{0} falls to {1}"
      }

      word "seskom" {
         meaning "to snow"
         gloss "snow"
         syntax "it snows"
         expanded "gimesraam seskoma"
      }

      word "bep" {
         meaning "to move"
         gloss "move"
         syntax "{0} moves {1} to {2}"
      }

      word "delat" {
         meaning "to be equal to"
         gloss "equal"
         syntax "{0} is equal to {1}"
      }

      word "liret" {
         meaning "to be named"
         syntax "{0} has the name {1}/{0} is called {1}"
      }

      word "lerat" {
         meaning "to go"
         syntax "{0} goes to {1}"
      }

      word "lemos" {
         meaning "to come"
         syntax "{0} comes"
         expanded "eratros rone"
         remarks "Refers to going to the location of the speaker. For other places, use \"erat\" instead."
      }

      word "metet" {
         meaning "to stand"
         syntax "{0} is standing at/on {1}"
      }

      word "volot" {
         meaning "to sit"
         syntax "{0} is sitting at/on {1}"
      }

      word "geset" {
         meaning "to lie down, to lay"
         gloss "lie"
         syntax "{0} is laying down at/on {1}"
      }

      word "livet" {
         meaning "to look at"
         gloss "look"
         syntax "{0} looks at {1}"
      }

      word "verot" {
         meaning "to listen to"
         gloss "listen"
         syntax "{0} listens to {1}"
      }

      word "demit" {
         meaning "to play, to have fun"
         gloss "play"
         syntax "{0} plays {1}"
      }

      word "belep" {
         meaning "to give"
         syntax "{0} gives {1} to {2}"
      }

      word "merit" {
         meaning "to know, to be familiar with"
         syntax "{0} knows about {1}"
      }

      word "bup" {
         meaning "to speak, to say"
         syntax "{0} says {1} to {2}"
      }

      word "tesip" {
         meaning "to push, to press"
         syntax "{0} pushes/presses {1} against/towards {2}"
      }

      word "posip" {
         meaning "to pull, to draw"
         syntax "{0} pulls/draws {1} away from {2}"
      }

      word "silip" {
         meaning "to shoot"
         syntax "{0} shoots {1} towards {2}"
      }

      word "moris" {
         meaning "to flash, to flicker, to fade in and out"
         syntax "{0} flashes"
         gloss "flash"
      }

      word "nobret" {
         meaning "to differ from"
         syntax "{0} is different from {1}"
         gloss "differ"
      }

      word "ramet" {
         meaning "to fade away, to gradually disappear"
         syntax "{0} fades away from {1}"
         gloss "fade"
      }

      word "Luna" {
         meaning "the sun (of Earth)"
         etymology (Clipping "lunata")
      }
      word "Rima" {
         meaning "the moon (of Earth)"
         etymology (Clipping "rimata")
      }

      word "Enita" {
         meaning "Aries (zodiac)"
         etymology (Copy "enita")
         domains [ "Tatreta" ]
      }

      word "Kilito" {
         meaning "Taurus (zodiac)"
         etymology (Variant "kilite")
         domains [ "Tatreta" ]
      }

      word "Votogre" {
         meaning "Gemini (zodiac)"
         etymology (Copy "votogre")
         domains [ "Tatreta" ]
      }

      word "Gliniki" {
         meaning "Cancer (zodiac)"
         etymology (Copy "gliniki")
         domains [ "Tatreta" ]
      }

      word "Norita" {
         meaning "Leo (zodiac)"
         etymology (Copy "norite")
         domains [ "Tatreta" ]
      }

      word "Astarea" {
         meaning "Virgo (zodiac)"
         etymology (Foreign "astraea")
         domains [ "Tatreta" ]
      }

      word "Preta" {
         meaning "Libra (zodiac)"
         etymology (Copy "Preta")
         domains [ "Tatreta" ]
      }

      word "Livopi" {
         meaning "Scorpio (zodiac)"
         etymology (Copy "livopi")
         domains [ "Tatreta" ]
      }

      word "Silisa" {
         meaning "Sagittarius (zodiac)"
         etymology (Derivation "silisaa")
         domains [ "Tatreta" ]
      }

      word "Kaprikorno" {
         meaning "Capricorn (zodiac)"
         etymology (Derivation "kaprikorno")
         domains [ "Tatreta" ]
      }

      word "Glakuna" {
         meaning "Aquarius (zodiac)"
         etymology (Contraction "glatrosaa kuna")
         domains [ "Tatreta" ]
      }

      word "Remivora" {
         meaning "Pisces (zodiac)"
         etymology (Contraction "remiti sel vora")
         domains [ "Tatreta" ]
      }

      word "mi" {
         meaning "0, significant zero (non-terminal)"
         gloss "0"
      }

      word "mira" {
         meaning "0, significant zero (terminal)"
         gloss "0"
      }

      word "po" {
         meaning "1, one (non-terminal)"
         gloss "1"
      }

      word "pona" {
         meaning "1, one (terminal)"
         gloss "1"
      }

      word "vo" {
         meaning "2, two (non-terminal)"
         gloss "2"
      }

      word "vora" {
         meaning "2, two (terminal)"
         gloss "2"
      }

      word "no" {
         meaning "3, three (non-terminal)"
         gloss "3"
      }

      word "nona" {
         meaning "3, three (terminal)"
         gloss "3"
      }

      word "te" {
         meaning "4, four (non-terminal)"
         gloss "4"
      }

      word "tera" {
         meaning "4, four (terminal)"
         gloss "4"
      }

      word "si" {
         meaning "5, five (non-terminal)"
         gloss "5"
      }

      word "sina" {
         meaning "5, five (terminal)"
         gloss "5"
      }

      word "li" {
         meaning "6, six (non-terminal)"
         gloss "6"
      }

      word "lira" {
         meaning "6, six (terminal)"
         gloss "6"
      }

      word "so" {
         meaning "7, seven (non-terminal)"
         gloss "7"
      }

      word "sona" {
         meaning "7, seven (terminal)"
         gloss "7"
      }

      word "ke" {
         meaning "8, eight (non-terminal)"
         gloss "8"
      }

      word "kera" {
         meaning "8, eight (terminal)"
         gloss "8"
      }

      word "gi" {
         meaning "9, nine (non-terminal)"
         gloss "9"
      }

      word "gina" {
         meaning "9, nine (terminal)"
         gloss "9"
      }
   }

let printLexicon () = printfn $"{lexicon}"
