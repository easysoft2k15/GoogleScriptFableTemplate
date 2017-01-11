namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module URL_Fetch =
        type [<AllowNullLiteral>] HTTPResponse =
            abstract getAllHeaders: unit -> obj
            abstract getAs: contentType: string -> Base.Blob
            abstract getBlob: unit -> Base.Blob
            abstract getContent: unit -> ResizeArray<Byte>
            abstract getContentText: unit -> string
            abstract getContentText: charset: string -> string
            abstract getHeaders: unit -> obj
            abstract getResponseCode: unit -> Integer

        and [<AllowNullLiteral>] OAuthConfig =
            abstract getAccessTokenUrl: unit -> string
            abstract getAuthorizationUrl: unit -> string
            abstract getMethod: unit -> string
            abstract getParamLocation: unit -> string
            abstract getRequestTokenUrl: unit -> string
            abstract getServiceName: unit -> string
            abstract setAccessTokenUrl: url: string -> unit
            abstract setAuthorizationUrl: url: string -> unit
            abstract setConsumerKey: consumerKey: string -> unit
            abstract setConsumerSecret: consumerSecret: string -> unit
            abstract setMethod: ``method``: string -> unit
            abstract setParamLocation: location: string -> unit
            abstract setRequestTokenUrl: url: string -> unit

        and [<AllowNullLiteral>] UrlFetchApp =
            abstract fetch: url: string -> HTTPResponse
            abstract fetch: url: string * ``params``: obj -> HTTPResponse
            abstract getRequest: url: string -> obj
            abstract getRequest: url: string * ``params``: obj -> obj
            abstract addOAuthService: serviceName: string -> OAuthConfig
            abstract removeOAuthService: serviceName: string -> unit

//type [<Erase>]Globals =
//    [<Global>] static member UrlFetchApp with get(): GoogleAppsScript.URL_Fetch.UrlFetchApp = jsNative and set(v: GoogleAppsScript.URL_Fetch.UrlFetchApp): unit = jsNative

