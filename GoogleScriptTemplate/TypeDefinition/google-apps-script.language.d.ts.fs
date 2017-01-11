namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Language =
        type [<AllowNullLiteral>] LanguageApp =
            abstract translate: text: string * sourceLanguage: string * targetLanguage: string -> string
            abstract translate: text: string * sourceLanguage: string * targetLanguage: string * advancedArgs: obj -> string

//type [<Erase>]Globals =
//    [<Global>] static member LanguageApp with get(): GoogleAppsScript.Language.LanguageApp = jsNative and set(v: GoogleAppsScript.Language.LanguageApp): unit = jsNative

