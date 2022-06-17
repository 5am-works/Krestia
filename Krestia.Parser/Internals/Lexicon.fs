module Krestia.Parser.Internals.Dictionary

open System.Collections.Generic
open Krestia.Parser.WordType

type NounInfo = { FullForm: string option }

type VerbInfo =
    { FullForm: string option
      TemplateMeaning: string
      ArgumentRemarks: string option list }

type ModifierInfo =
    { CanModifyTypes: WordType list
      AttachmentTypes: WordType list
      AttachmentRemarks: string option list option }

type WordTypeInfo =
    | Noun of NounInfo
    | Verb of VerbInfo
    | Modifier of ModifierInfo
    | SpecialWord

type Word =
    { Spelling: string
      Meaning: string
      Gloss: string
      Roots: string list
      Remarks: string option
      WordTypeInfo: WordTypeInfo }

type Lexicon() =
    let entries = Dictionary()

    member this.AddWord(word: Word) = entries.Add(word.Spelling, word)

type DictionaryBuilder() =
    [<CustomOperation("noun")>]
    member _.AddNoun(lexicon: Lexicon, spelling, meaning, gloss, ?roots, ?remarks, ?fullForm) =
        let noun =
            { Spelling = spelling
              Meaning = meaning
              Gloss = gloss
              Roots = defaultArg roots []
              Remarks = remarks
              WordTypeInfo = Noun { FullForm = fullForm } }

        lexicon.AddWord(noun)
        lexicon

    [<CustomOperation("verb")>]
    member _.AddVerb
        (
            lexicon: Lexicon,
            spelling,
            meaning,
            gloss,
            templateMeaning,
            roots,
            remarks,
            fullForm,
            argumentRemarks
        ) =
        let verb =
            { Spelling = spelling
              Meaning = meaning
              Gloss = gloss
              Roots = roots
              Remarks = remarks
              WordTypeInfo =
                Verb
                    { FullForm = fullForm
                      TemplateMeaning = templateMeaning
                      ArgumentRemarks = argumentRemarks } }

        lexicon.AddWord(verb)
        lexicon

    [<CustomOperation("modifier")>]
    member _.AddModifier
        (
            lexicon: Lexicon,
            spelling,
            meaning,
            gloss,
            canModifyTypes,
            attachmentTypes,
            roots,
            ?remarks,
            ?attachmentRemarks
        ) =
        let modifier =
            { Spelling = spelling
              Meaning = meaning
              Gloss = gloss
              Roots = roots
              Remarks = remarks
              WordTypeInfo =
                Modifier
                    { AttachmentRemarks = attachmentRemarks
                      CanModifyTypes = canModifyTypes
                      AttachmentTypes = attachmentTypes } }

        lexicon.AddWord(modifier)
        lexicon

    [<CustomOperation("word")>]
    member _.AddWord(lexicon: Lexicon, spelling, meaning, gloss, ?roots, ?remarks) =
        let word =
            { Spelling = spelling
              Meaning = meaning
              Gloss = gloss
              Roots = defaultArg roots []
              Remarks = remarks
              WordTypeInfo = SpecialWord }

        lexicon.AddWord(word)
        lexicon

    member _.Yield a =
        printf $"{a}"
        Lexicon()

let lexicon = DictionaryBuilder()
