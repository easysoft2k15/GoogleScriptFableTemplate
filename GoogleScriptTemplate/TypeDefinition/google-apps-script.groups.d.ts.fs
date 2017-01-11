namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Groups =
        type [<AllowNullLiteral>] Group =
            abstract getEmail: unit -> string
            abstract getRole: email: string -> Role
            abstract getRole: user: Base.User -> Role
            abstract getUsers: unit -> ResizeArray<Base.User>
            abstract hasUser: email: string -> bool
            abstract hasUser: user: Base.User -> bool

        and [<AllowNullLiteral>] GroupsApp =
            abstract Role: Role with get, set
            abstract getGroupByEmail: email: string -> Group
            abstract getGroups: unit -> ResizeArray<Group>

        and Role =
            | OWNER = 0
            | MANAGER = 1
            | MEMBER = 2
            | INVITED = 3
            | PENDING = 4

//type [<Erase>]Globals =
//    [<Global>] static member GroupsApp with get(): GoogleAppsScript.Groups.GroupsApp = jsNative and set(v: GoogleAppsScript.Groups.GroupsApp): unit = jsNative

