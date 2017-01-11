namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Sites =
        type [<AllowNullLiteral>] Attachment =
            abstract deleteAttachment: unit -> unit
            abstract getAs: contentType: string -> Base.Blob
            abstract getAttachmentType: unit -> AttachmentType
            abstract getBlob: unit -> Base.Blob
            abstract getContentType: unit -> string
            abstract getDatePublished: unit -> DateTime
            abstract getDescription: unit -> string
            abstract getLastUpdated: unit -> DateTime
            abstract getParent: unit -> Page
            abstract getTitle: unit -> string
            abstract getUrl: unit -> string
            abstract setContentType: contentType: string -> Attachment
            abstract setDescription: description: string -> Attachment
            abstract setFrom: blob: Base.BlobSource -> Attachment
            abstract setParent: parent: Page -> Attachment
            abstract setTitle: title: string -> Attachment
            abstract setUrl: url: string -> Attachment

        and AttachmentType =
            | WEB = 0
            | HOSTED = 1

        and [<AllowNullLiteral>] Column =
            abstract deleteColumn: unit -> unit
            abstract getName: unit -> string
            abstract getParent: unit -> Page
            abstract setName: name: string -> Column

        and [<AllowNullLiteral>] Comment =
            abstract deleteComment: unit -> unit
            abstract getAuthorEmail: unit -> string
            abstract getAuthorName: unit -> string
            abstract getContent: unit -> string
            abstract getDatePublished: unit -> DateTime
            abstract getLastUpdated: unit -> DateTime
            abstract getParent: unit -> Page
            abstract setContent: content: string -> Comment
            abstract setParent: parent: Page -> Comment

        and [<AllowNullLiteral>] ListItem =
            abstract deleteListItem: unit -> unit
            abstract getDatePublished: unit -> DateTime
            abstract getLastUpdated: unit -> DateTime
            abstract getParent: unit -> Page
            abstract getValueByIndex: index: Integer -> string
            abstract getValueByName: name: string -> string
            abstract setParent: parent: Page -> ListItem
            abstract setValueByIndex: index: Integer * value: string -> ListItem
            abstract setValueByName: name: string * value: string -> ListItem

        and [<AllowNullLiteral>] Page =
            abstract addColumn: name: string -> Column
            abstract addHostedAttachment: blob: Base.BlobSource -> Attachment
            abstract addHostedAttachment: blob: Base.BlobSource * description: string -> Attachment
            abstract addListItem: values: ResizeArray<string> -> ListItem
            abstract addWebAttachment: title: string * description: string * url: string -> Attachment
            abstract createAnnouncement: title: string * html: string -> Page
            abstract createAnnouncement: title: string * html: string * asDraft: bool -> Page
            abstract createAnnouncementsPage: title: string * name: string * html: string -> Page
            abstract createFileCabinetPage: title: string * name: string * html: string -> Page
            abstract createListPage: title: string * name: string * html: string * columnNames: ResizeArray<string> -> Page
            abstract createPageFromTemplate: title: string * name: string * template: Page -> Page
            abstract createWebPage: title: string * name: string * html: string -> Page
            abstract deletePage: unit -> unit
            abstract getAllDescendants: unit -> ResizeArray<Page>
            abstract getAllDescendants: options: obj -> ResizeArray<Page>
            abstract getAnnouncements: unit -> ResizeArray<Page>
            abstract getAnnouncements: optOptions: obj -> ResizeArray<Page>
            abstract getAttachments: unit -> ResizeArray<Attachment>
            abstract getAttachments: optOptions: obj -> ResizeArray<Attachment>
            abstract getAuthors: unit -> ResizeArray<string>
            abstract getChildByName: name: string -> Page
            abstract getChildren: unit -> ResizeArray<Page>
            abstract getChildren: options: obj -> ResizeArray<Page>
            abstract getColumns: unit -> ResizeArray<Column>
            abstract getComments: unit -> ResizeArray<Comment>
            abstract getComments: optOptions: obj -> ResizeArray<Comment>
            abstract getDatePublished: unit -> DateTime
            abstract getHtmlContent: unit -> string
            abstract getIsDraft: unit -> bool
            abstract getLastEdited: unit -> DateTime
            abstract getLastUpdated: unit -> DateTime
            abstract getListItems: unit -> ResizeArray<ListItem>
            abstract getListItems: optOptions: obj -> ResizeArray<ListItem>
            abstract getName: unit -> string
            abstract getPageType: unit -> PageType
            abstract getParent: unit -> Page
            abstract getTextContent: unit -> string
            abstract getTitle: unit -> string
            abstract getUrl: unit -> string
            abstract isDeleted: unit -> bool
            abstract isTemplate: unit -> bool
            abstract publishAsTemplate: name: string -> Page
            abstract search: query: string -> ResizeArray<Page>
            abstract search: query: string * options: obj -> ResizeArray<Page>
            abstract setHtmlContent: html: string -> Page
            abstract setIsDraft: draft: bool -> Page
            abstract setName: name: string -> Page
            abstract setParent: parent: Page -> Page
            abstract setTitle: title: string -> Page
            abstract addComment: content: string -> Comment
            abstract getPageName: unit -> string
            abstract getSelfLink: unit -> string

        and PageType =
            | WEB_PAGE = 0
            | LIST_PAGE = 1
            | ANNOUNCEMENT = 2
            | ANNOUNCEMENTS_PAGE = 3
            | FILE_CABINET_PAGE = 4

        and [<AllowNullLiteral>] Site =
            abstract addEditor: emailAddress: string -> Site
            abstract addEditor: user: Base.User -> Site
            abstract addEditors: emailAddresses: ResizeArray<string> -> Site
            abstract addOwner: email: string -> Site
            abstract addOwner: user: Base.User -> Site
            abstract addViewer: emailAddress: string -> Site
            abstract addViewer: user: Base.User -> Site
            abstract addViewers: emailAddresses: ResizeArray<string> -> Site
            abstract createAnnouncementsPage: title: string * name: string * html: string -> Page
            abstract createFileCabinetPage: title: string * name: string * html: string -> Page
            abstract createListPage: title: string * name: string * html: string * columnNames: ResizeArray<string> -> Page
            abstract createPageFromTemplate: title: string * name: string * template: Page -> Page
            abstract createWebPage: title: string * name: string * html: string -> Page
            abstract getAllDescendants: unit -> ResizeArray<Page>
            abstract getAllDescendants: options: obj -> ResizeArray<Page>
            abstract getChildByName: name: string -> Page
            abstract getChildren: unit -> ResizeArray<Page>
            abstract getChildren: options: obj -> ResizeArray<Page>
            abstract getEditors: unit -> ResizeArray<Base.User>
            abstract getName: unit -> string
            abstract getOwners: unit -> ResizeArray<Base.User>
            abstract getSummary: unit -> string
            abstract getTemplates: unit -> ResizeArray<Page>
            abstract getTheme: unit -> string
            abstract getTitle: unit -> string
            abstract getUrl: unit -> string
            abstract getViewers: unit -> ResizeArray<Base.User>
            abstract removeEditor: emailAddress: string -> Site
            abstract removeEditor: user: Base.User -> Site
            abstract removeOwner: email: string -> Site
            abstract removeOwner: user: Base.User -> Site
            abstract removeViewer: emailAddress: string -> Site
            abstract removeViewer: user: Base.User -> Site
            abstract search: query: string -> ResizeArray<Page>
            abstract search: query: string * options: obj -> ResizeArray<Page>
            abstract setSummary: summary: string -> Site
            abstract setTheme: theme: string -> Site
            abstract setTitle: title: string -> Site
            abstract addCollaborator: email: string -> Site
            abstract addCollaborator: user: Base.User -> Site
            abstract createAnnouncement: title: string * html: string * parent: Page -> Page
            abstract createComment: inReplyTo: string * html: string * parent: Page -> Comment
            abstract createListItem: html: string * columnNames: ResizeArray<string> * values: ResizeArray<string> * parent: Page -> ListItem
            abstract createWebAttachment: title: string * url: string * parent: Page -> Attachment
            abstract deleteSite: unit -> unit
            abstract getAnnouncements: unit -> ResizeArray<Page>
            abstract getAnnouncementsPages: unit -> ResizeArray<Page>
            abstract getAttachments: unit -> ResizeArray<Attachment>
            abstract getCollaborators: unit -> ResizeArray<Base.User>
            abstract getComments: unit -> ResizeArray<Comment>
            abstract getFileCabinetPages: unit -> ResizeArray<Page>
            abstract getListItems: unit -> ResizeArray<ListItem>
            abstract getListPages: unit -> ResizeArray<Page>
            abstract getSelfLink: unit -> string
            abstract getSiteName: unit -> string
            abstract getWebAttachments: unit -> ResizeArray<Attachment>
            abstract getWebPages: unit -> ResizeArray<Page>
            abstract removeCollaborator: email: string -> Site
            abstract removeCollaborator: user: Base.User -> Site

        and [<AllowNullLiteral>] SitesApp =
            abstract AttachmentType: AttachmentType with get, set
            abstract PageType: PageType with get, set
            abstract copySite: domain: string * name: string * title: string * summary: string * site: Site -> Site
            abstract createSite: domain: string * name: string * title: string * summary: string -> Site
            abstract getActivePage: unit -> Page
            abstract getActiveSite: unit -> Site
            abstract getAllSites: domain: string -> ResizeArray<Site>
            abstract getAllSites: domain: string * start: Integer * max: Integer -> ResizeArray<Site>
            abstract getPageByUrl: url: string -> Page
            abstract getSite: name: string -> Site
            abstract getSite: domain: string * name: string -> Site
            abstract getSiteByUrl: url: string -> Site
            abstract getSites: unit -> ResizeArray<Site>
            abstract getSites: start: Integer * max: Integer -> ResizeArray<Site>
            abstract getSites: domain: string -> ResizeArray<Site>
            abstract getSites: domain: string * start: Integer * max: Integer -> ResizeArray<Site>

//type [<Erase>]Globals =
//    [<Global>] static member SitesApp with get(): GoogleAppsScript.Sites.SitesApp = jsNative and set(v: GoogleAppsScript.Sites.SitesApp): unit = jsNative

