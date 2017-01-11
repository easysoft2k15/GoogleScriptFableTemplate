namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Mail =
        type [<AllowNullLiteral>] MailApp =
            abstract getRemainingDailyQuota: unit -> Integer
            abstract sendEmail: message: obj -> unit
            abstract sendEmail: recipient: string * subject: string * body: string -> unit
            abstract sendEmail: recipient: string * subject: string * body: string * options: obj -> unit
            abstract sendEmail: ``to``: string * replyTo: string * subject: string * body: string -> unit

//type [<Erase>]Globals =
//    [<Global>] static member MailApp with get(): GoogleAppsScript.Mail.MailApp = jsNative and set(v: GoogleAppsScript.Mail.MailApp): unit = jsNative

