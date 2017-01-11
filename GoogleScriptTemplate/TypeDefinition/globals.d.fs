namespace GoogleAppsScript

open Fable.Core
open Fable.Import.JS

type [<Erase>]Globals =
    [<Emit("Browser")>]
    [<Global>] static member Browser: Browser = jsNative
    [<Emit("Logger")>]
    [<Global>] static member Logger: Logger = jsNative
    [<Emit("Session")>]
    [<Global>] static member Session: Session = jsNative
    [<Emit("CacheService")>]
    [<Global>] static member CacheService:CacheService  = jsNative
    [<Emit("UiApp")>]
    [<Global>] static member UiApp: UiApp = jsNative
    [<Emit("CalendarApp")>]
    [<Global>] static member CalendarApp:CalendarApp  = jsNative
    [<Emit("Charts")>]
    [<Global>] static member Charts:Charts = jsNative
    [<Emit("ContactsApp")>]
    [<Global>] static member ContactsApp:ContactsApp = jsNative
    [<Emit("ContentService")>]
    [<Global>] static member ContentService:ContentService = jsNative
    [<Emit("DocumentApp")>]
    [<Global>] static member DocumentApp:DocumentApp = jsNative
    [<Emit("DriveApp")>]
    [<Global>] static member DriveApp:DriveApp = jsNative
    [<Emit("FormApp")>]
    [<Global>] static member FormApp:FormApp = jsNative
    [<Emit("GmailApp")>]
    [<Global>] static member GmailApp:GmailApp = jsNative
    [<Emit("GroupsApp")>]
    [<Global>] static member GroupsApp:GroupsApp = jsNative
    [<Emit("HtmlService")>]
    [<Global>] static member HtmlService:HtmlService = jsNative
    [<Emit("Jdbc")>]
    [<Global>] static member Jdbc:Jdbc  = jsNative
    [<Emit("LanguageApp")>]
    [<Global>] static member LanguageApp:LanguageApp = jsNative
    [<Emit("LockService")>]
    [<Global>] static member LockService:LockService = jsNative
    [<Emit("MailApp")>]
    [<Global>] static member MailApp:MailApp = jsNative
    [<Emit("Maps")>]
    [<Global>] static member Maps:Maps = jsNative
    [<Emit("LinearOptimizationService")>]
    [<Global>] static member LinearOptimizationService:LinearOptimizationService = jsNative
    [<Emit("PropertiesService")>]
    [<Global>] static member PropertiesService:PropertiesService = jsNative
    [<Emit("ScriptProperties")>]
    [<Global>] static member ScriptProperties:ScriptProperties = jsNative
    [<Emit("UserProperties")>]
    [<Global>] static member UserProperties:UserProperties  = jsNative
    [<Emit("SpreadsheetApp")>]
    [<Global>] static member SpreadsheetApp:SpreadsheetApp = jsNative
    [<Emit("ScriptApp")>]
    [<Global>] static member ScriptApp:ScriptApp = jsNative
    [<Emit("SitesApp")>]
    [<Global>] static member SitesApp:SitesApp = jsNative
    [<Emit("UrlFetchApp")>]
    [<Global>] static member UrlFetchApp:UrlFetchApp = jsNative
    [<Emit("Charset")>]
    [<Global>] static member Charset:Charset = jsNative
    [<Emit("DigestAlgorithm")>]
    [<Global>] static member DigestAlgorithm:DigestAlgorithm = jsNative
    [<Emit("MacAlgorithm")>]
    [<Global>] static member MacAlgorithm:MacAlgorithm  = jsNative
    [<Emit("Utilities")>]
    [<Global>] static member Utilities:Utilities  = jsNative
    [<Emit("XmlService")>]
    [<Global>] static member XmlService:XmlService = jsNative

//    [<Global>] static member Browser with get(): Base.Browser = jsNative and set(v: Base.Browser): unit = jsNative
//    [<Global>] static member Logger with get(): Base.Logger = jsNative and set(v: Base.Logger): unit = jsNative
//    [<Global>] static member Session with get(): Base.Session = jsNative and set(v: Base.Session): unit = jsNative
//    [<Global>] static member CacheService with get(): GoogleAppsScript.Cache.CacheService = jsNative and set(v: GoogleAppsScript.Cache.CacheService): unit = jsNative
//    [<Global>] static member UiApp with get(): GoogleAppsScript.UI.UiApp = jsNative and set(v: GoogleAppsScript.UI.UiApp): unit = jsNative
//    [<Global>] static member CalendarApp with get(): GoogleAppsScript.Calendar.CalendarApp = jsNative and set(v: GoogleAppsScript.Calendar.CalendarApp): unit = jsNative
//    [<Global>] static member Charts with get(): GoogleAppsScript.Charts.Charts = jsNative and set(v: GoogleAppsScript.Charts.Charts): unit = jsNative
//    [<Global>] static member ContactsApp with get(): GoogleAppsScript.Contacts.ContactsApp = jsNative and set(v: GoogleAppsScript.Contacts.ContactsApp): unit = jsNative
//    [<Global>] static member ContentService with get(): GoogleAppsScript.Content.ContentService = jsNative and set(v: GoogleAppsScript.Content.ContentService): unit = jsNative
//    [<Global>] static member DocumentApp with get(): GoogleAppsScript.Document.DocumentApp = jsNative and set(v: GoogleAppsScript.Document.DocumentApp): unit = jsNative
//    [<Global>] static member DriveApp with get(): GoogleAppsScript.Drive.DriveApp = jsNative and set(v: GoogleAppsScript.Drive.DriveApp): unit = jsNative
//    [<Global>] static member FormApp with get(): GoogleAppsScript.Forms.FormApp = jsNative and set(v: GoogleAppsScript.Forms.FormApp): unit = jsNative
//    [<Global>] static member GmailApp with get(): GoogleAppsScript.Gmail.GmailApp = jsNative and set(v: GoogleAppsScript.Gmail.GmailApp): unit = jsNative
//    [<Global>] static member GroupsApp with get(): GoogleAppsScript.Groups.GroupsApp = jsNative and set(v: GoogleAppsScript.Groups.GroupsApp): unit = jsNative
//    [<Global>] static member HtmlService with get(): GoogleAppsScript.HTML.HtmlService = jsNative and set(v: GoogleAppsScript.HTML.HtmlService): unit = jsNative
//    [<Global>] static member Jdbc with get(): GoogleAppsScript.JDBC.Jdbc = jsNative and set(v: GoogleAppsScript.JDBC.Jdbc): unit = jsNative
//    [<Global>] static member LanguageApp with get(): GoogleAppsScript.Language.LanguageApp = jsNative and set(v: GoogleAppsScript.Language.LanguageApp): unit = jsNative
//    [<Global>] static member LockService with get(): GoogleAppsScript.Lock.LockService = jsNative and set(v: GoogleAppsScript.Lock.LockService): unit = jsNative
//    [<Global>] static member MailApp with get(): GoogleAppsScript.Mail.MailApp = jsNative and set(v: GoogleAppsScript.Mail.MailApp): unit = jsNative
//    [<Global>] static member Maps with get(): GoogleAppsScript.Maps.Maps = jsNative and set(v: GoogleAppsScript.Maps.Maps): unit = jsNative
//    [<Global>] static member LinearOptimizationService with get(): GoogleAppsScript.Optimization.LinearOptimizationService = jsNative and set(v: GoogleAppsScript.Optimization.LinearOptimizationService): unit = jsNative
//    [<Global>] static member PropertiesService with get(): GoogleAppsScript.Properties.PropertiesService = jsNative and set(v: GoogleAppsScript.Properties.PropertiesService): unit = jsNative
//    [<Global>] static member ScriptProperties with get(): GoogleAppsScript.Properties.ScriptProperties = jsNative and set(v: GoogleAppsScript.Properties.ScriptProperties): unit = jsNative
//    [<Global>] static member UserProperties with get(): GoogleAppsScript.Properties.UserProperties = jsNative and set(v: GoogleAppsScript.Properties.UserProperties): unit = jsNative
//    [<Global>] static member SpreadsheetApp with get(): GoogleAppsScript.Spreadsheet.SpreadsheetApp = jsNative and set(v: GoogleAppsScript.Spreadsheet.SpreadsheetApp): unit = jsNative
//    [<Global>] static member ScriptApp with get(): GoogleAppsScript.Script.ScriptApp = jsNative and set(v: GoogleAppsScript.Script.ScriptApp): unit = jsNative
//    [<Global>] static member SitesApp with get(): GoogleAppsScript.Sites.SitesApp = jsNative and set(v: GoogleAppsScript.Sites.SitesApp): unit = jsNative
//    [<Global>] static member UrlFetchApp with get(): GoogleAppsScript.URL_Fetch.UrlFetchApp = jsNative and set(v: GoogleAppsScript.URL_Fetch.UrlFetchApp): unit = jsNative
//    [<Global>] static member Charset with get(): GoogleAppsScript.Utilities.Charset = jsNative and set(v: GoogleAppsScript.Utilities.Charset): unit = jsNative
//    [<Global>] static member DigestAlgorithm with get(): GoogleAppsScript.Utilities.DigestAlgorithm = jsNative and set(v: GoogleAppsScript.Utilities.DigestAlgorithm): unit = jsNative
//    [<Global>] static member MacAlgorithm with get(): GoogleAppsScript.Utilities.MacAlgorithm = jsNative and set(v: GoogleAppsScript.Utilities.MacAlgorithm): unit = jsNative
//    [<Global>] static member Utilities with get(): GoogleAppsScript.Utilities.Utilities = jsNative and set(v: GoogleAppsScript.Utilities.Utilities): unit = jsNative
//    [<Global>] static member XmlService with get(): GoogleAppsScript.XML_Service.XmlService = jsNative and set(v: GoogleAppsScript.XML_Service.XmlService): unit = jsNative


