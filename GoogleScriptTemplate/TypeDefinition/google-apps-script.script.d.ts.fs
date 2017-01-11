namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Script =
        type AuthMode =
            | NONE = 0
            | CUSTOM_FUNCTION = 1
            | LIMITED = 2
            | FULL = 3

        and [<AllowNullLiteral>] AuthorizationInfo =
            abstract getAuthorizationStatus: unit -> AuthorizationStatus
            abstract getAuthorizationUrl: unit -> string

        and AuthorizationStatus =
            | REQUIRED = 0
            | NOT_REQUIRED = 1

        and [<AllowNullLiteral>] ClockTriggerBuilder =
            abstract after: durationMilliseconds: Integer -> ClockTriggerBuilder
            abstract at: date: DateTime -> ClockTriggerBuilder
            abstract atDate: year: Integer * month: Integer * day: Integer -> ClockTriggerBuilder
            abstract atHour: hour: Integer -> ClockTriggerBuilder
            abstract create: unit -> Trigger
            abstract everyDays: n: Integer -> ClockTriggerBuilder
            abstract everyHours: n: Integer -> ClockTriggerBuilder
            abstract everyMinutes: n: Integer -> ClockTriggerBuilder
            abstract everyWeeks: n: Integer -> ClockTriggerBuilder
            abstract inTimezone: timezone: string -> ClockTriggerBuilder
            abstract nearMinute: minute: Integer -> ClockTriggerBuilder
            abstract onMonthDay: day: Integer -> ClockTriggerBuilder
            abstract onWeekDay: day: Base.Weekday -> ClockTriggerBuilder

        and [<AllowNullLiteral>] DocumentTriggerBuilder =
            abstract create: unit -> Trigger
            abstract onOpen: unit -> DocumentTriggerBuilder

        and EventType =
            | CLOCK = 0
            | ON_OPEN = 1
            | ON_EDIT = 2
            | ON_FORM_SUBMIT = 3
            | ON_CHANGE = 4

        and [<AllowNullLiteral>] FormTriggerBuilder =
            abstract create: unit -> Trigger
            abstract onFormSubmit: unit -> FormTriggerBuilder
            abstract onOpen: unit -> FormTriggerBuilder

        and InstallationSource =
            | APPS_MARKETPLACE_DOMAIN_ADD_ON = 0
            | NONE = 1
            | WEB_STORE_ADD_ON = 2

        and [<AllowNullLiteral>] ScriptApp =
            abstract AuthMode: AuthMode with get, set
            abstract AuthorizationStatus: AuthorizationStatus with get, set
            abstract EventType: EventType with get, set
            abstract InstallationSource: InstallationSource with get, set
            abstract TriggerSource: TriggerSource with get, set
            abstract WeekDay: Base.Weekday with get, set
            abstract deleteTrigger: trigger: Trigger -> unit
            abstract getAuthorizationInfo: authMode: AuthMode -> AuthorizationInfo
            abstract getInstallationSource: unit -> InstallationSource
            abstract getOAuthToken: unit -> string
            abstract getProjectKey: unit -> string
            abstract getProjectTriggers: unit -> ResizeArray<Trigger>
            abstract getService: unit -> Service
            abstract getUserTriggers: document: Document.Document -> ResizeArray<Trigger>
            abstract getUserTriggers: form: Forms.Form -> ResizeArray<Trigger>
            abstract getUserTriggers: spreadsheet: Spreadsheet.Spreadsheet -> ResizeArray<Trigger>
            abstract invalidateAuth: unit -> unit
            abstract newStateToken: unit -> StateTokenBuilder
            abstract newTrigger: functionName: string -> TriggerBuilder
            abstract getScriptTriggers: unit -> ResizeArray<Trigger>

        and Service =
            | MYSELF = 0
            | DOMAIN = 1
            | ALL = 2

        and [<AllowNullLiteral>] SpreadsheetTriggerBuilder =
            abstract create: unit -> Trigger
            abstract onChange: unit -> SpreadsheetTriggerBuilder
            abstract onEdit: unit -> SpreadsheetTriggerBuilder
            abstract onFormSubmit: unit -> SpreadsheetTriggerBuilder
            abstract onOpen: unit -> SpreadsheetTriggerBuilder

        and [<AllowNullLiteral>] StateTokenBuilder =
            abstract createToken: unit -> string
            abstract withArgument: name: string * value: string -> StateTokenBuilder
            abstract withMethod: ``method``: string -> StateTokenBuilder
            abstract withTimeout: seconds: Integer -> StateTokenBuilder

        and [<AllowNullLiteral>] Trigger =
            abstract getEventType: unit -> EventType
            abstract getHandlerFunction: unit -> string
            abstract getTriggerSource: unit -> TriggerSource
            abstract getTriggerSourceId: unit -> string
            abstract getUniqueId: unit -> string

        and [<AllowNullLiteral>] TriggerBuilder =
            abstract forDocument: document: Document.Document -> DocumentTriggerBuilder
            abstract forDocument: key: string -> DocumentTriggerBuilder
            abstract forForm: form: Forms.Form -> FormTriggerBuilder
            abstract forForm: key: string -> FormTriggerBuilder
            abstract forSpreadsheet: sheet: Spreadsheet.Spreadsheet -> SpreadsheetTriggerBuilder
            abstract forSpreadsheet: key: string -> SpreadsheetTriggerBuilder
            abstract timeBased: unit -> ClockTriggerBuilder

        and TriggerSource =
            | SPREADSHEETS = 0
            | CLOCK = 1
            | FORMS = 2
            | DOCUMENTS = 3

//type [<Erase>]Globals =
//    [<Global>] static member ScriptApp with get(): GoogleAppsScript.Script.ScriptApp = jsNative and set(v: GoogleAppsScript.Script.ScriptApp): unit = jsNative

