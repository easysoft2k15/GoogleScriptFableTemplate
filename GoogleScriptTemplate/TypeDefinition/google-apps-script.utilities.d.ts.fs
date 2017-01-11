namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Utilities =
        type Charset =
            | US_ASCII = 0
            | UTF_8 = 1

        and DigestAlgorithm =
            | MD2 = 0
            | MD5 = 1
            | SHA_1 = 2
            | SHA_256 = 3
            | SHA_384 = 4
            | SHA_512 = 5

        and MacAlgorithm =
            | HMAC_MD5 = 0
            | HMAC_SHA_1 = 1
            | HMAC_SHA_256 = 2
            | HMAC_SHA_384 = 3
            | HMAC_SHA_512 = 4

        and [<AllowNullLiteral>] Utilities =
            abstract Charset: Charset with get, set
            abstract DigestAlgorithm: DigestAlgorithm with get, set
            abstract MacAlgorithm: MacAlgorithm with get, set
            abstract base64Decode: encoded: string -> ResizeArray<Byte>
            abstract base64Decode: encoded: string * charset: Charset -> ResizeArray<Byte>
            abstract base64DecodeWebSafe: encoded: string -> ResizeArray<Byte>
            abstract base64DecodeWebSafe: encoded: string * charset: Charset -> ResizeArray<Byte>
            abstract base64Encode: data: ResizeArray<Byte> -> string
            abstract base64Encode: data: string -> string
            abstract base64Encode: data: string * charset: Charset -> string
            abstract base64EncodeWebSafe: data: ResizeArray<Byte> -> string
            abstract base64EncodeWebSafe: data: string -> string
            abstract base64EncodeWebSafe: data: string * charset: Charset -> string
            abstract computeDigest: algorithm: DigestAlgorithm * value: string -> ResizeArray<Byte>
            abstract computeDigest: algorithm: DigestAlgorithm * value: string * charset: Charset -> ResizeArray<Byte>
            abstract computeHmacSha256Signature: value: string * key: string -> ResizeArray<Byte>
            abstract computeHmacSha256Signature: value: string * key: string * charset: Charset -> ResizeArray<Byte>
            abstract computeHmacSignature: algorithm: MacAlgorithm * value: string * key: string -> ResizeArray<Byte>
            abstract computeHmacSignature: algorithm: MacAlgorithm * value: string * key: string * charset: Charset -> ResizeArray<Byte>
            abstract computeRsaSha256Signature: value: string * key: string -> ResizeArray<Byte>
            abstract computeRsaSha256Signature: value: string * key: string * charset: Charset -> ResizeArray<Byte>
            abstract formatDate: date: DateTime * timeZone: string * format: string -> string
            abstract formatString: template: string * [<ParamArray>] args: obj[] -> string
            abstract newBlob: data: ResizeArray<Byte> -> Base.Blob
            abstract newBlob: data: ResizeArray<Byte> * contentType: string -> Base.Blob
            abstract newBlob: data: ResizeArray<Byte> * contentType: string * name: string -> Base.Blob
            abstract newBlob: data: string -> Base.Blob
            abstract newBlob: data: string * contentType: string -> Base.Blob
            abstract newBlob: data: string * contentType: string * name: string -> Base.Blob
            abstract parseCsv: csv: string -> ResizeArray<ResizeArray<string>>
            abstract parseCsv: csv: string * delimiter: Char -> ResizeArray<ResizeArray<string>>
            abstract sleep: milliseconds: Integer -> unit
            abstract unzip: blob: Base.BlobSource -> ResizeArray<Base.Blob>
            abstract zip: blobs: ResizeArray<Base.BlobSource> -> Base.Blob
            abstract zip: blobs: ResizeArray<Base.BlobSource> * name: string -> Base.Blob
            abstract jsonParse: jsonString: string -> obj
            abstract jsonStringify: obj: obj -> string

//type [<Erase>]Globals =
//    [<Global>] static member Charset with get(): GoogleAppsScript.Utilities.Charset = jsNative and set(v: GoogleAppsScript.Utilities.Charset): unit = jsNative
//    [<Global>] static member DigestAlgorithm with get(): GoogleAppsScript.Utilities.DigestAlgorithm = jsNative and set(v: GoogleAppsScript.Utilities.DigestAlgorithm): unit = jsNative
//    [<Global>] static member MacAlgorithm with get(): GoogleAppsScript.Utilities.MacAlgorithm = jsNative and set(v: GoogleAppsScript.Utilities.MacAlgorithm): unit = jsNative
//    [<Global>] static member Utilities with get(): GoogleAppsScript.Utilities.Utilities = jsNative and set(v: GoogleAppsScript.Utilities.Utilities): unit = jsNative

