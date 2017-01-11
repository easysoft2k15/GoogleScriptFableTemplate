#I @"node_modules\fable-core"
#r "node_modules/fable-core/Fable.Core.dll"

#load @"..\TypeDefinition\google-apps-script.types.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.base.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.cache.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.calendar.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.ui.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.charts.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.contacts.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.content.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.document.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.drive.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.forms.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.gmail.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.groups.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.html.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.jdbc.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.language.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.lock.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.mail.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.maps.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.optimization.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.properties.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.spreadsheet.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.script.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.sites.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.url-fetch.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.utilities.d.ts.fs"
#load @"..\TypeDefinition\google-apps-script.xml-service.d.ts.fs"
#load @"..\TypeDefinition\Globals.d.fs"

open Fable.Core
open GoogleAppsScript

type FileIterator with
    member x.ToList()=
        let mutable l=[]
        while(x.hasNext()) do
            l <- x.next()::l
        l

let testArray()=
    [1..10]
    |> List.map (fun i -> Globals.Logger.log i)

let getDriveFiles()=
    Globals.DriveApp.getFiles().ToList()
    |> List.map (fun f -> Globals.Logger.log (f.getName()))

testArray();

getDriveFiles();


    

