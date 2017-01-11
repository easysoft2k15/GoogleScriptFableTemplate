namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Lock =
        type [<AllowNullLiteral>] Lock =
            abstract hasLock: unit -> bool
            abstract releaseLock: unit -> unit
            abstract tryLock: timeoutInMillis: Integer -> bool
            abstract waitLock: timeoutInMillis: Integer -> unit

        and [<AllowNullLiteral>] LockService =
            abstract getDocumentLock: unit -> Lock
            abstract getScriptLock: unit -> Lock
            abstract getUserLock: unit -> Lock

//type [<Erase>]Globals =
//    [<Global>] static member LockService with get(): GoogleAppsScript.Lock.LockService = jsNative and set(v: GoogleAppsScript.Lock.LockService): unit = jsNative

