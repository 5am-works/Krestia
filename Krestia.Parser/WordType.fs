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
   | Digit
   | Predicate

type Inflection =
   | Definite
   | Possession
   | PredicativeIdentity
   | AttributiveIdentityPrefix
   | AttributiveIdentityPostfix
   | Gerund
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
   | Shift2
   | Shift3
   | Reflection
   | Reflection1
   | Reflection3
   | Reflection0
   | Quality
   | Uninflectable