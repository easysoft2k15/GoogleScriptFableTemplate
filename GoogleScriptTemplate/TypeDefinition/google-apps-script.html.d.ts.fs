namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module HTML =
        type [<AllowNullLiteral>] HtmlOutput =
            abstract append: addedContent: string -> HtmlOutput
            abstract appendUntrusted: addedContent: string -> HtmlOutput
            abstract asTemplate: unit -> HtmlTemplate
            abstract clear: unit -> HtmlOutput
            abstract getAs: contentType: string -> Base.Blob
            abstract getBlob: unit -> Base.Blob
            abstract getContent: unit -> string
            abstract getHeight: unit -> Integer
            abstract getTitle: unit -> string
            abstract getWidth: unit -> Integer
            abstract setContent: content: string -> HtmlOutput
            abstract setHeight: height: Integer -> HtmlOutput
            abstract setSandboxMode: mode: SandboxMode -> HtmlOutput
            abstract setTitle: title: string -> HtmlOutput
            abstract setWidth: width: Integer -> HtmlOutput

        and [<AllowNullLiteral>] HtmlService =
            abstract SandboxMode: SandboxMode with get, set
            abstract createHtmlOutput: unit -> HtmlOutput
            abstract createHtmlOutput: blob: Base.BlobSource -> HtmlOutput
            abstract createHtmlOutput: html: string -> HtmlOutput
            abstract createHtmlOutputFromFile: filename: string -> HtmlOutput
            abstract createTemplate: blob: Base.BlobSource -> HtmlTemplate
            abstract createTemplate: html: string -> HtmlTemplate
            abstract createTemplateFromFile: filename: string -> HtmlTemplate
            abstract getUserAgent: unit -> string

        and [<AllowNullLiteral>] HtmlTemplate =
            abstract evaluate: unit -> HtmlOutput
            abstract getCode: unit -> string
            abstract getCodeWithComments: unit -> string
            abstract getRawContent: unit -> string

        and SandboxMode =
            | EMULATED = 0
            | IFRAME = 1
            | NATIVE = 2

//type [<Erase>]Globals =
//    [<Global>] static member HtmlService with get(): GoogleAppsScript.HTML.HtmlService = jsNative and set(v: GoogleAppsScript.HTML.HtmlService): unit = jsNative

