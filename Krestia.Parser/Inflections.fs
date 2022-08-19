module Krestia.Parser.Inflections

open WordType

type InflectionRule =
   | InflectionRule of WordType list * Inflection * string * WordType * bool

let private ir baseTypes inflection suffix newType isTerminal =
   InflectionRule(baseTypes, inflection, suffix, newType, isTerminal)

let private noun inflection suffix newType isTerminal =
   ir [ Noun ] inflection suffix newType isTerminal

let private verbEach inflection suffix isTerminal =
   [ Verb0
     Verb1
     Verb12
     Verb123
     Verb13
     Verb2
     Verb23
     Verb3 ]
   |> List.map (fun t -> ir [ t ] inflection suffix t isTerminal)

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
     noun AttributiveIdentityPostfix "l" Modifier true
     noun PredicativeIdentity "s" Verb1 false
     noun Quality "re" Noun false
     noun Lone "m" Verb0 false ]

let rules =
   List.concat [ nounRules
                 verbEach Perfect "io" true
                 verbEach Hypothetical "ia" true ]
