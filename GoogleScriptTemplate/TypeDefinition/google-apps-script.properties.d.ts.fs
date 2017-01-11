namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Properties =
        type [<AllowNullLiteral>] Properties =
            abstract deleteAllProperties: unit -> Properties
            abstract deleteProperty: key: string -> Properties
            abstract getKeys: unit -> ResizeArray<string>
            abstract getProperties: unit -> obj
            abstract getProperty: key: string -> string
            abstract setProperties: properties: obj -> Properties
            abstract setProperties: properties: obj * deleteAllOthers: bool -> Properties
            abstract setProperty: key: string * value: string -> Properties

        and [<AllowNullLiteral>] PropertiesService =
            abstract getDocumentProperties: unit -> Properties
            abstract getScriptProperties: unit -> Properties
            abstract getUserProperties: unit -> Properties

        and [<AllowNullLiteral>] ScriptProperties =
            abstract deleteAllProperties: unit -> ScriptProperties
            abstract deleteProperty: key: string -> ScriptProperties
            abstract getKeys: unit -> ResizeArray<string>
            abstract getProperties: unit -> obj
            abstract getProperty: key: string -> string
            abstract setProperties: properties: obj -> ScriptProperties
            abstract setProperties: properties: obj * deleteAllOthers: bool -> ScriptProperties
            abstract setProperty: key: string * value: string -> ScriptProperties

        and [<AllowNullLiteral>] UserProperties =
            abstract deleteAllProperties: unit -> UserProperties
            abstract deleteProperty: key: string -> UserProperties
            abstract getKeys: unit -> ResizeArray<string>
            abstract getProperties: unit -> obj
            abstract getProperty: key: string -> string
            abstract setProperties: properties: obj -> UserProperties
            abstract setProperties: properties: obj * deleteAllOthers: bool -> UserProperties
            abstract setProperty: key: string * value: string -> UserProperties

//type [<Erase>]Globals =
//    [<Global>] static member PropertiesService with get(): GoogleAppsScript.Properties.PropertiesService = jsNative and set(v: GoogleAppsScript.Properties.PropertiesService): unit = jsNative
//    [<Global>] static member ScriptProperties with get(): GoogleAppsScript.Properties.ScriptProperties = jsNative and set(v: GoogleAppsScript.Properties.ScriptProperties): unit = jsNative
//    [<Global>] static member UserProperties with get(): GoogleAppsScript.Properties.UserProperties = jsNative and set(v: GoogleAppsScript.Properties.UserProperties): unit = jsNative

