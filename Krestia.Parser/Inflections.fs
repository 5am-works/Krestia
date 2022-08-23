module Krestia.Parser.Inflections

open WordType

type InflectionRule =
   | InflectionRule of WordType list * Inflection * string * WordType * bool

let private ir baseTypes inflection suffix newType isTerminal =
   InflectionRule(baseTypes, inflection, suffix, newType, isTerminal)

let private noun inflection suffix newType isTerminal =
   ir [ Noun ] inflection suffix newType isTerminal

let private each wordTypes inflection suffix isTerminal =
   wordTypes
   |> List.map (fun t -> ir [ t ] inflection suffix t isTerminal)

let private verbEach inflection suffix isTerminal =
   each
      [ Verb0
        Verb1
        Verb12
        Verb123
        Verb13
        Verb2
        Verb23
        Verb3 ]
      inflection
      suffix
      isTerminal

let private verb inflection suffix newType isTerminal =
   ir
      [ Verb0
        Verb1
        Verb12
        Verb123
        Verb13
        Verb2
        Verb23
        Verb3 ]
      inflection
      suffix
      newType
      isTerminal

let nounRules =
   [ noun Possession "nsa" Noun false
     noun AttributiveIdentity "l" Modifier true
     noun PredicativeIdentity "s" Verb1 false
     noun Quality "re" Noun false
     noun Lone "m" Verb0 false ]

let uniformVerbRules =
   [ verb Gerund "ea" Noun true ]

let singularVerbRules =
   [ ir [ Verb1 ] Partial1 "raam" Verb0 false
     ir [ Verb12 ] Partial1 "raag" Verb2 false
     ir [ Verb123 ] Partial1 "raav" Verb23 false
     ir [ Verb13 ] Partial1 "raan" Verb3 false
     ir [ Verb2 ] Partial2 "rom" Verb0 false
     ir [ Verb12 ] Partial2 "ros" Verb1 false
     ir [ Verb123 ] Partial2 "rok" Verb13 false
     ir [ Verb23 ] Partial2 "ron" Verb3 false
     ir [ Verb3 ] Partial3 "rum" Verb0 false
     ir [ Verb13 ] Partial3 "rus" Verb1 false
     ir [ Verb123 ] Partial3 "rut" Verb12 false
     ir [ Verb23 ] Partial3 "rug" Verb2 false
     ir [ Verb12 ] Shift2 "ret" Verb12 false
     ir [ Verb123 ] Shift2 "rep" Verb123 false
     ir [ Verb13 ] Shift3 "rak" Verb13 false
     ir [ Verb123 ] Shift3 "rap" Verb123 false
     ir [ Verb23 ] Shift3 "rav" Verb23 false
     ir [ Verb1; Verb12; Verb123; Verb13 ] Argument1 "aa" Noun false
     ir [ Verb2; Verb12; Verb23; Verb123 ] Argument2 "o" Noun false
     ir [ Verb3; Verb13; Verb23; Verb123 ] Argument3 "u" Noun false ]

let rules =
   List.concat [ nounRules
                 verbEach Perfect "io" true
                 verbEach Hypothetical "ia" true
                 verbEach Intention "ela" true
                 verbEach Desiderative "ila" true
                 each [ Verb1; Verb12; Verb123; Verb13 ] Imperative "ei" true
                 verbEach Optative "ie" true
                 each [ Verb1; Verb12; Verb123; Verb13 ] Hortative "oa" true
                 uniformVerbRules
                 singularVerbRules ]
