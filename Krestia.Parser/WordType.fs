module Krestia.Parser.WordType

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