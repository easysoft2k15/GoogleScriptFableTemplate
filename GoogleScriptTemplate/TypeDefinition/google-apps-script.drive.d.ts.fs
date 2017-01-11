namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Drive =
        type Access =
            | ANYONE = 0
            | ANYONE_WITH_LINK = 1
            | DOMAIN = 2
            | DOMAIN_WITH_LINK = 3
            | PRIVATE = 4

        and [<AllowNullLiteral>] DriveApp =
            abstract Access: Access with get, set
            abstract Permission: Permission with get, set
            abstract addFile: child: File -> Folder
            abstract addFolder: child: Folder -> Folder
            abstract continueFileIterator: continuationToken: string -> FileIterator
            abstract continueFolderIterator: continuationToken: string -> FolderIterator
            abstract createFile: blob: Base.BlobSource -> File
            abstract createFile: name: string * content: string -> File
            abstract createFile: name: string * content: string * mimeType: string -> File
            abstract createFolder: name: string -> Folder
            abstract getFileById: id: string -> File
            abstract getFiles: unit -> FileIterator
            abstract getFilesByName: name: string -> FileIterator
            abstract getFilesByType: mimeType: string -> FileIterator
            abstract getFolderById: id: string -> Folder
            abstract getFolders: unit -> FolderIterator
            abstract getFoldersByName: name: string -> FolderIterator
            abstract getRootFolder: unit -> Folder
            abstract getStorageLimit: unit -> Integer
            abstract getStorageUsed: unit -> Integer
            abstract getTrashedFiles: unit -> FileIterator
            abstract getTrashedFolders: unit -> FolderIterator
            abstract removeFile: child: File -> Folder
            abstract removeFolder: child: Folder -> Folder
            abstract searchFiles: ``params``: string -> FileIterator
            abstract searchFolders: ``params``: string -> FolderIterator

        and [<AllowNullLiteral>] File =
            abstract addCommenter: emailAddress: string -> File
            abstract addCommenter: user: Base.User -> File
            abstract addCommenters: emailAddresses: ResizeArray<string> -> File
            abstract addEditor: emailAddress: string -> File
            abstract addEditor: user: Base.User -> File
            abstract addEditors: emailAddresses: ResizeArray<string> -> File
            abstract addViewer: emailAddress: string -> File
            abstract addViewer: user: Base.User -> File
            abstract addViewers: emailAddresses: ResizeArray<string> -> File
            abstract getAccess: email: string -> Permission
            abstract getAccess: user: Base.User -> Permission
            abstract getAs: contentType: string -> Base.Blob
            abstract getBlob: unit -> Base.Blob
            abstract getDateCreated: unit -> DateTime
            abstract getDescription: unit -> string
            abstract getDownloadUrl: unit -> string
            abstract getEditors: unit -> ResizeArray<User>
            abstract getId: unit -> string
            abstract getLastUpdated: unit -> DateTime
            abstract getMimeType: unit -> string
            abstract getName: unit -> string
            abstract getOwner: unit -> User
            abstract getParents: unit -> FolderIterator
            abstract getSharingAccess: unit -> Access
            abstract getSharingPermission: unit -> Permission
            abstract getSize: unit -> Integer
            abstract getThumbnail: unit -> Base.Blob
            abstract getUrl: unit -> string
            abstract getViewers: unit -> ResizeArray<User>
            abstract isShareableByEditors: unit -> bool
            abstract isStarred: unit -> bool
            abstract isTrashed: unit -> bool
            abstract makeCopy: unit -> File
            abstract makeCopy: destination: Folder -> File
            abstract makeCopy: name: string -> File
            abstract makeCopy: name: string * destination: Folder -> File
            abstract removeCommenter: emailAddress: string -> File
            abstract removeCommenter: user: Base.User -> File
            abstract removeEditor: emailAddress: string -> File
            abstract removeEditor: user: Base.User -> File
            abstract removeViewer: emailAddress: string -> File
            abstract removeViewer: user: Base.User -> File
            abstract revokePermissions: user: string -> File
            abstract revokePermissions: user: Base.User -> File
            abstract setContent: content: string -> File
            abstract setDescription: description: string -> File
            abstract setName: name: string -> File
            abstract setOwner: emailAddress: string -> File
            abstract setOwner: user: Base.User -> File
            abstract setShareableByEditors: shareable: bool -> File
            abstract setSharing: accessType: Access * permissionType: Permission -> File
            abstract setStarred: starred: bool -> File
            abstract setTrashed: trashed: bool -> File

        and [<AllowNullLiteral>] FileIterator =
            abstract getContinuationToken: unit -> string
            abstract hasNext: unit -> bool
            abstract next: unit -> File

        and [<AllowNullLiteral>] Folder =
            abstract addEditor: emailAddress: string -> Folder
            abstract addEditor: user: Base.User -> Folder
            abstract addEditors: emailAddresses: ResizeArray<string> -> Folder
            abstract addFile: child: File -> Folder
            abstract addFolder: child: Folder -> Folder
            abstract addViewer: emailAddress: string -> Folder
            abstract addViewer: user: Base.User -> Folder
            abstract addViewers: emailAddresses: ResizeArray<string> -> Folder
            abstract createFile: blob: Base.BlobSource -> File
            abstract createFile: name: string * content: string -> File
            abstract createFile: name: string * content: string * mimeType: string -> File
            abstract createFolder: name: string -> Folder
            abstract getAccess: email: string -> Permission
            abstract getAccess: user: Base.User -> Permission
            abstract getDateCreated: unit -> DateTime
            abstract getDescription: unit -> string
            abstract getEditors: unit -> ResizeArray<User>
            abstract getFiles: unit -> FileIterator
            abstract getFilesByName: name: string -> FileIterator
            abstract getFilesByType: mimeType: string -> FileIterator
            abstract getFolders: unit -> FolderIterator
            abstract getFoldersByName: name: string -> FolderIterator
            abstract getId: unit -> string
            abstract getLastUpdated: unit -> DateTime
            abstract getName: unit -> string
            abstract getOwner: unit -> User
            abstract getParents: unit -> FolderIterator
            abstract getSharingAccess: unit -> Access
            abstract getSharingPermission: unit -> Permission
            abstract getSize: unit -> Integer
            abstract getUrl: unit -> string
            abstract getViewers: unit -> ResizeArray<User>
            abstract isShareableByEditors: unit -> bool
            abstract isStarred: unit -> bool
            abstract isTrashed: unit -> bool
            abstract removeEditor: emailAddress: string -> Folder
            abstract removeEditor: user: Base.User -> Folder
            abstract removeFile: child: File -> Folder
            abstract removeFolder: child: Folder -> Folder
            abstract removeViewer: emailAddress: string -> Folder
            abstract removeViewer: user: Base.User -> Folder
            abstract revokePermissions: user: string -> Folder
            abstract revokePermissions: user: Base.User -> Folder
            abstract searchFiles: ``params``: string -> FileIterator
            abstract searchFolders: ``params``: string -> FolderIterator
            abstract setDescription: description: string -> Folder
            abstract setName: name: string -> Folder
            abstract setOwner: emailAddress: string -> Folder
            abstract setOwner: user: Base.User -> Folder
            abstract setShareableByEditors: shareable: bool -> Folder
            abstract setSharing: accessType: Access * permissionType: Permission -> Folder
            abstract setStarred: starred: bool -> Folder
            abstract setTrashed: trashed: bool -> Folder

        and [<AllowNullLiteral>] FolderIterator =
            abstract getContinuationToken: unit -> string
            abstract hasNext: unit -> bool
            abstract next: unit -> Folder

        and Permission =
            | VIEW = 0
            | EDIT = 1
            | COMMENT = 2
            | OWNER = 3
            | NONE = 4

        and [<AllowNullLiteral>] User =
            abstract getDomain: unit -> string
            abstract getEmail: unit -> string
            abstract getName: unit -> string
            abstract getPhotoUrl: unit -> string
            abstract getUserLoginId: unit -> string

//type [<Erase>]Globals =
//    [<Global>] static member DriveApp with get(): GoogleAppsScript.Drive.DriveApp = jsNative and set(v: GoogleAppsScript.Drive.DriveApp): unit = jsNative


