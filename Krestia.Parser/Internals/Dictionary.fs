module Krestia.Parser.Internals.Dictionary

open Krestia.Parser.WordType

type Word =
   { Spelling: string
     Meaning: string
     Gloss: string
     Roots: string list
     Remarks: string option }

type Noun =
   { WordInfo: Word
     FullForm: string option }

type Verb =
   { WordInfo: Word
     TemplateMeaning: string
     ArgumentRemarks: string option list
     FullForm: string option }

type Modifier =
   { WordInfo: Word
     CanModifyTypes: WordType list
     AttachmentTypes: WordType list
     AttachmentRemarks: string option list }

type Dictionary() = class end

type DictionaryBuilder() =
   [<CustomOperation("noun")>]
   member _.Noun(spelling: string) = ()
   member _.Yield() = ()
   member _.Zero() = Dictionary()
   
let lexicon = DictionaryBuilder()