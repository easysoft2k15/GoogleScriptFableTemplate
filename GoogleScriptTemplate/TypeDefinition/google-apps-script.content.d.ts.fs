namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Content =
        type [<AllowNullLiteral>] ContentService =
            abstract MimeType: MimeType with get, set
            abstract createTextOutput: unit -> TextOutput
            abstract createTextOutput: content: string -> TextOutput

        and MimeType =
            | ATOM = 0
            | CSV = 1
            | ICAL = 2
            | JAVASCRIPT = 3
            | JSON = 4
            | RSS = 5
            | TEXT = 6
            | VCARD = 7
            | XML = 8

        and [<AllowNullLiteral>] TextOutput =
            abstract append: addedContent: string -> TextOutput
            abstract clear: unit -> TextOutput
            abstract downloadAsFile: filename: string -> TextOutput
            abstract getContent: unit -> string
            abstract getFileName: unit -> string
            abstract getMimeType: unit -> MimeType
            abstract setContent: content: string -> TextOutput
            abstract setMimeType: mimeType: MimeType -> TextOutput

//type [<Erase>]Globals =
//    [<Global>] static member ContentService with get(): GoogleAppsScript.Content.ContentService = jsNative and set(v: GoogleAppsScript.Content.ContentService): unit = jsNative

