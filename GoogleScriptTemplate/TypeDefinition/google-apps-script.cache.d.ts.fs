namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Cache =
        type [<AllowNullLiteral>] Cache =
            abstract get: key: string -> string
            abstract getAll: keys: ResizeArray<string> -> obj
            abstract put: key: string * value: string -> unit
            abstract put: key: string * value: string * expirationInSeconds: Integer -> unit
            abstract putAll: values: obj -> unit
            abstract putAll: values: obj * expirationInSeconds: Integer -> unit
            abstract remove: key: string -> unit
            abstract removeAll: keys: ResizeArray<string> -> unit

        and [<AllowNullLiteral>] CacheService =
            abstract getDocumentCache: unit -> Cache
            abstract getScriptCache: unit -> Cache
            abstract getUserCache: unit -> Cache

//type [<Erase>]Globals =
//    [<Global>] static member CacheService with get(): GoogleAppsScript.Cache.CacheService = jsNative and set(v: GoogleAppsScript.Cache.CacheService): unit = jsNative


