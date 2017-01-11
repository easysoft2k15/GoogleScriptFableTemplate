namespace GoogleAppsScript

open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Base =
        type [<AllowNullLiteral>] Blob =
            abstract copyBlob: unit -> Blob
            abstract getAs: contentType: string -> Blob
            abstract getBytes: unit -> ResizeArray<Byte>
            abstract getContentType: unit -> string
            abstract getDataAsString: unit -> string
            abstract getDataAsString: charset: string -> string
            abstract getName: unit -> string
            abstract isGoogleType: unit -> bool
            abstract setBytes: data: ResizeArray<Byte> -> Blob
            abstract setContentType: contentType: string -> Blob
            abstract setContentTypeFromExtension: unit -> Blob
            abstract setDataFromString: string: string -> Blob
            abstract setDataFromString: string: string * charset: string -> Blob
            abstract setName: name: string -> Blob
            abstract getAllBlobs: unit -> ResizeArray<Blob>

        and [<AllowNullLiteral>] BlobSource =
            abstract getAs: contentType: string -> Blob
            abstract getBlob: unit -> Blob

        and [<AllowNullLiteral>] Browser =
            abstract Buttons: ButtonSet with get, set
            abstract inputBox: prompt: string -> string
            abstract inputBox: prompt: string * buttons: ButtonSet -> string
            abstract inputBox: title: string * prompt: string * buttons: ButtonSet -> string
            abstract msgBox: prompt: string -> string
            abstract msgBox: prompt: string * buttons: ButtonSet -> string
            abstract msgBox: title: string * prompt: string * buttons: ButtonSet -> string

        and Button =
            | CLOSE = 0
            | OK = 1
            | CANCEL = 2
            | YES = 3
            | NO = 4

        and ButtonSet =
            | OK = 0
            | OK_CANCEL = 1
            | YES_NO = 2
            | YES_NO_CANCEL = 3

        and [<AllowNullLiteral>] Logger =
            abstract clear: unit -> unit
            abstract getLog: unit -> string
            abstract log: data: obj -> Logger
            abstract log: format: string * [<ParamArray>] values: obj[] -> Logger

        and [<AllowNullLiteral>] Menu =
            abstract addItem: caption: string * functionName: string -> Menu
            abstract addSeparator: unit -> Menu
            abstract addSubMenu: menu: Menu -> Menu
            abstract addToUi: unit -> unit

        and MimeType =
            | GOOGLE_APPS_SCRIPT = 0
            | GOOGLE_DRAWINGS = 1
            | GOOGLE_DOCS = 2
            | GOOGLE_FORMS = 3
            | GOOGLE_SHEETS = 4
            | GOOGLE_SLIDES = 5
            | FOLDER = 6
            | BMP = 7
            | GIF = 8
            | JPEG = 9
            | PNG = 10
            | SVG = 11
            | PDF = 12
            | CSS = 13
            | CSV = 14
            | HTML = 15
            | JAVASCRIPT = 16
            | PLAIN_TEXT = 17
            | RTF = 18
            | OPENDOCUMENT_GRAPHICS = 19
            | OPENDOCUMENT_PRESENTATION = 20
            | OPENDOCUMENT_SPREADSHEET = 21
            | OPENDOCUMENT_TEXT = 22
            | MICROSOFT_EXCEL = 23
            | MICROSOFT_EXCEL_LEGACY = 24
            | MICROSOFT_POWERPOINT = 25
            | MICROSOFT_POWERPOINT_LEGACY = 26
            | MICROSOFT_WORD = 27
            | MICROSOFT_WORD_LEGACY = 28
            | ZIP = 29

        and Month =
            | JANUARY = 0
            | FEBRUARY = 1
            | MARCH = 2
            | APRIL = 3
            | MAY = 4
            | JUNE = 5
            | JULY = 6
            | AUGUST = 7
            | SEPTEMBER = 8
            | OCTOBER = 9
            | NOVEMBER = 10
            | DECEMBER = 11

        and [<AllowNullLiteral>] PromptResponse =
            abstract getResponseText: unit -> string
            abstract getSelectedButton: unit -> Button

        and [<AllowNullLiteral>] Session =
            abstract getActiveUser: unit -> User
            abstract getActiveUserLocale: unit -> string
            abstract getEffectiveUser: unit -> User
            abstract getScriptTimeZone: unit -> string
            abstract getTimeZone: unit -> string
            abstract getUser: unit -> User

        and [<AllowNullLiteral>] Ui =
            abstract Button: Button with get, set
            abstract ButtonSet: ButtonSet with get, set
            abstract alert: prompt: string -> Button
            abstract alert: prompt: string * buttons: ButtonSet -> Button
            abstract alert: title: string * prompt: string * buttons: ButtonSet -> Button
            abstract createAddonMenu: unit -> Menu
            abstract createMenu: caption: string -> Menu
            abstract prompt: prompt: string -> PromptResponse
            abstract prompt: prompt: string * buttons: ButtonSet -> PromptResponse
            abstract prompt: title: string * prompt: string * buttons: ButtonSet -> PromptResponse
            abstract showModalDialog: userInterface: obj * title: string -> unit
            abstract showModelessDialog: userInterface: obj * title: string -> unit
            abstract showSidebar: userInterface: obj -> unit
            abstract showDialog: userInterface: obj -> unit

        and User =
            abstract getEmail: unit -> string
            abstract getUserLoginId: unit -> string

        and Weekday =
            | SUNDAY = 0
            | MONDAY = 1
            | TUESDAY = 2
            | WEDNESDAY = 3
            | THURSDAY = 4
            | FRIDAY = 5
            | SATURDAY = 6

//type [<Erase>]Globals =
//    [<Global>] static member Browser with get(): GoogleAppsScript.Base.Browser = jsNative and set(v: GoogleAppsScript.Base.Browser): unit = jsNative
//    [<Global>] static member Logger with get(): GoogleAppsScript.Base.Logger = jsNative and set(v: GoogleAppsScript.Base.Logger): unit = jsNative
//    [<Global>] static member Session with get(): GoogleAppsScript.Base.Session = jsNative and set(v: GoogleAppsScript.Base.Session): unit = jsNative
