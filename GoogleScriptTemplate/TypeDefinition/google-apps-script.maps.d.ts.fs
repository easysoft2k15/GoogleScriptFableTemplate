namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Maps =
        type Avoid =
            | TOLLS = 0
            | HIGHWAYS = 1

        and Color =
            | BLACK = 0
            | BROWN = 1
            | GREEN = 2
            | PURPLE = 3
            | YELLOW = 4
            | BLUE = 5
            | GRAY = 6
            | ORANGE = 7
            | RED = 8
            | WHITE = 9

        and [<AllowNullLiteral>] DirectionFinder =
            abstract addWaypoint: latitude: float * longitude: float -> DirectionFinder
            abstract addWaypoint: address: string -> DirectionFinder
            abstract clearWaypoints: unit -> DirectionFinder
            abstract getDirections: unit -> obj
            abstract setAlternatives: useAlternatives: bool -> DirectionFinder
            abstract setArrive: time: DateTime -> DirectionFinder
            abstract setAvoid: avoid: string -> DirectionFinder
            abstract setDepart: time: DateTime -> DirectionFinder
            abstract setDestination: latitude: float * longitude: float -> DirectionFinder
            abstract setDestination: address: string -> DirectionFinder
            abstract setLanguage: language: string -> DirectionFinder
            abstract setMode: mode: string -> DirectionFinder
            abstract setOptimizeWaypoints: optimizeOrder: bool -> DirectionFinder
            abstract setOrigin: latitude: float * longitude: float -> DirectionFinder
            abstract setOrigin: address: string -> DirectionFinder
            abstract setRegion: region: string -> DirectionFinder

        and [<AllowNullLiteral>] DirectionFinderEnums =
            abstract Avoid: Avoid with get, set
            abstract Mode: Mode with get, set

        and [<AllowNullLiteral>] ElevationSampler =
            abstract sampleLocation: latitude: float * longitude: float -> obj
            abstract sampleLocations: points: ResizeArray<float> -> obj
            abstract sampleLocations: encodedPolyline: string -> obj
            abstract samplePath: points: ResizeArray<float> * numSamples: Integer -> obj
            abstract samplePath: encodedPolyline: string * numSamples: Integer -> obj

        and Format =
            | PNG = 0
            | PNG8 = 1
            | PNG32 = 2
            | GIF = 3
            | JPG = 4
            | JPG_BASELINE = 5

        and [<AllowNullLiteral>] Geocoder =
            abstract geocode: address: string -> obj
            abstract reverseGeocode: latitude: float * longitude: float -> obj
            abstract reverseGeocode: swLatitude: float * swLongitude: float * neLatitude: float * neLongitude: float -> obj
            abstract setBounds: swLatitude: float * swLongitude: float * neLatitude: float * neLongitude: float -> Geocoder
            abstract setLanguage: language: string -> Geocoder
            abstract setRegion: region: string -> Geocoder

        and [<AllowNullLiteral>] Maps =
            abstract DirectionFinder: DirectionFinderEnums with get, set
            abstract StaticMap: StaticMapEnums with get, set
            abstract decodePolyline: polyline: string -> ResizeArray<float>
            abstract encodePolyline: points: ResizeArray<float> -> string
            abstract newDirectionFinder: unit -> DirectionFinder
            abstract newElevationSampler: unit -> ElevationSampler
            abstract newGeocoder: unit -> Geocoder
            abstract newStaticMap: unit -> StaticMap
            abstract setAuthentication: clientId: string * signingKey: string -> unit

        and MarkerSize =
            | TINY = 0
            | MID = 1
            | SMALL = 2

        and Mode =
            | DRIVING = 0
            | WALKING = 1
            | BICYCLING = 2
            | TRANSIT = 3

        and [<AllowNullLiteral>] StaticMap =
            abstract addAddress: address: string -> StaticMap
            abstract addMarker: latitude: float * longitude: float -> StaticMap
            abstract addMarker: address: string -> StaticMap
            abstract addPath: points: ResizeArray<float> -> StaticMap
            abstract addPath: polyline: string -> StaticMap
            abstract addPoint: latitude: float * longitude: float -> StaticMap
            abstract addVisible: latitude: float * longitude: float -> StaticMap
            abstract addVisible: address: string -> StaticMap
            abstract beginPath: unit -> StaticMap
            abstract clearMarkers: unit -> StaticMap
            abstract clearPaths: unit -> StaticMap
            abstract clearVisibles: unit -> StaticMap
            abstract endPath: unit -> StaticMap
            abstract getAs: contentType: string -> Base.Blob
            abstract getBlob: unit -> Base.Blob
            abstract getMapImage: unit -> ResizeArray<Byte>
            abstract getMapUrl: unit -> string
            abstract setCenter: latitude: float * longitude: float -> StaticMap
            abstract setCenter: address: string -> StaticMap
            abstract setCustomMarkerStyle: imageUrl: string * useShadow: bool -> StaticMap
            abstract setFormat: format: string -> StaticMap
            abstract setLanguage: language: string -> StaticMap
            abstract setMapType: mapType: string -> StaticMap
            abstract setMarkerStyle: size: string * color: string * label: string -> StaticMap
            abstract setMobile: useMobileTiles: bool -> StaticMap
            abstract setPathStyle: weight: Integer * color: string * fillColor: string -> StaticMap
            abstract setSize: width: Integer * height: Integer -> StaticMap
            abstract setZoom: zoom: Integer -> StaticMap

        and [<AllowNullLiteral>] StaticMapEnums =
            abstract Color: Color with get, set
            abstract Format: Format with get, set
            abstract MarkerSize: MarkerSize with get, set
            abstract Type: Type with get, set

        and Type =
            | ROADMAP = 0
            | SATELLITE = 1
            | TERRAIN = 2
            | HYBRID = 3

//type [<Erase>]Globals =
//    [<Global>] static member Maps with get(): GoogleAppsScript.Maps.Maps = jsNative and set(v: GoogleAppsScript.Maps.Maps): unit = jsNative


