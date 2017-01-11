namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Gmail =
        type [<AllowNullLiteral>] GmailApp =
            abstract createLabel: name: string -> GmailLabel
            abstract deleteLabel: label: GmailLabel -> GmailApp
            abstract getAliases: unit -> ResizeArray<string>
            abstract getChatThreads: unit -> ResizeArray<GmailThread>
            abstract getChatThreads: start: Integer * max: Integer -> ResizeArray<GmailThread>
            abstract getDraftMessages: unit -> ResizeArray<GmailMessage>
            abstract getInboxThreads: unit -> ResizeArray<GmailThread>
            abstract getInboxThreads: start: Integer * max: Integer -> ResizeArray<GmailThread>
            abstract getInboxUnreadCount: unit -> Integer
            abstract getMessageById: id: string -> GmailMessage
            abstract getMessagesForThread: thread: GmailThread -> ResizeArray<GmailMessage>
            abstract getMessagesForThreads: threads: ResizeArray<GmailThread> -> ResizeArray<ResizeArray<GmailMessage>>
            abstract getPriorityInboxThreads: unit -> ResizeArray<GmailThread>
            abstract getPriorityInboxThreads: start: Integer * max: Integer -> ResizeArray<GmailThread>
            abstract getPriorityInboxUnreadCount: unit -> Integer
            abstract getSpamThreads: unit -> ResizeArray<GmailThread>
            abstract getSpamThreads: start: Integer * max: Integer -> ResizeArray<GmailThread>
            abstract getSpamUnreadCount: unit -> Integer
            abstract getStarredThreads: unit -> ResizeArray<GmailThread>
            abstract getStarredThreads: start: Integer * max: Integer -> ResizeArray<GmailThread>
            abstract getStarredUnreadCount: unit -> Integer
            abstract getThreadById: id: string -> GmailThread
            abstract getTrashThreads: unit -> ResizeArray<GmailThread>
            abstract getTrashThreads: start: Integer * max: Integer -> ResizeArray<GmailThread>
            abstract getUserLabelByName: name: string -> GmailLabel
            abstract getUserLabels: unit -> ResizeArray<GmailLabel>
            abstract markMessageRead: message: GmailMessage -> GmailApp
            abstract markMessageUnread: message: GmailMessage -> GmailApp
            abstract markMessagesRead: messages: ResizeArray<GmailMessage> -> GmailApp
            abstract markMessagesUnread: messages: ResizeArray<GmailMessage> -> GmailApp
            abstract markThreadImportant: thread: GmailThread -> GmailApp
            abstract markThreadRead: thread: GmailThread -> GmailApp
            abstract markThreadUnimportant: thread: GmailThread -> GmailApp
            abstract markThreadUnread: thread: GmailThread -> GmailApp
            abstract markThreadsImportant: threads: ResizeArray<GmailThread> -> GmailApp
            abstract markThreadsRead: threads: ResizeArray<GmailThread> -> GmailApp
            abstract markThreadsUnimportant: threads: ResizeArray<GmailThread> -> GmailApp
            abstract markThreadsUnread: threads: ResizeArray<GmailThread> -> GmailApp
            abstract moveMessageToTrash: message: GmailMessage -> GmailApp
            abstract moveMessagesToTrash: messages: ResizeArray<GmailMessage> -> GmailApp
            abstract moveThreadToArchive: thread: GmailThread -> GmailApp
            abstract moveThreadToInbox: thread: GmailThread -> GmailApp
            abstract moveThreadToSpam: thread: GmailThread -> GmailApp
            abstract moveThreadToTrash: thread: GmailThread -> GmailApp
            abstract moveThreadsToArchive: threads: ResizeArray<GmailThread> -> GmailApp
            abstract moveThreadsToInbox: threads: ResizeArray<GmailThread> -> GmailApp
            abstract moveThreadsToSpam: threads: ResizeArray<GmailThread> -> GmailApp
            abstract moveThreadsToTrash: threads: ResizeArray<GmailThread> -> GmailApp
            abstract refreshMessage: message: GmailMessage -> GmailApp
            abstract refreshMessages: messages: ResizeArray<GmailMessage> -> GmailApp
            abstract refreshThread: thread: GmailThread -> GmailApp
            abstract refreshThreads: threads: ResizeArray<GmailThread> -> GmailApp
            abstract search: query: string -> ResizeArray<GmailThread>
            abstract search: query: string * start: Integer * max: Integer -> ResizeArray<GmailThread>
            abstract sendEmail: recipient: string * subject: string * body: string -> GmailApp
            abstract sendEmail: recipient: string * subject: string * body: string * options: obj -> GmailApp
            abstract starMessage: message: GmailMessage -> GmailApp
            abstract starMessages: messages: ResizeArray<GmailMessage> -> GmailApp
            abstract unstarMessage: message: GmailMessage -> GmailApp
            abstract unstarMessages: messages: ResizeArray<GmailMessage> -> GmailApp

        and [<AllowNullLiteral>] GmailAttachment =
            abstract copyBlob: unit -> Base.Blob
            abstract getAs: contentType: string -> Base.Blob
            abstract getBytes: unit -> ResizeArray<Byte>
            abstract getContentType: unit -> string
            abstract getDataAsString: unit -> string
            abstract getDataAsString: charset: string -> string
            abstract getName: unit -> string
            abstract getSize: unit -> Integer
            abstract isGoogleType: unit -> bool
            abstract setBytes: data: ResizeArray<Byte> -> Base.Blob
            abstract setContentType: contentType: string -> Base.Blob
            abstract setContentTypeFromExtension: unit -> Base.Blob
            abstract setDataFromString: string: string -> Base.Blob
            abstract setDataFromString: string: string * charset: string -> Base.Blob
            abstract setName: name: string -> Base.Blob
            abstract getAllBlobs: unit -> ResizeArray<Base.Blob>

        and [<AllowNullLiteral>] GmailLabel =
            abstract addToThread: thread: GmailThread -> GmailLabel
            abstract addToThreads: threads: ResizeArray<GmailThread> -> GmailLabel
            abstract deleteLabel: unit -> unit
            abstract getName: unit -> string
            abstract getThreads: unit -> ResizeArray<GmailThread>
            abstract getThreads: start: Integer * max: Integer -> ResizeArray<GmailThread>
            abstract getUnreadCount: unit -> Integer
            abstract removeFromThread: thread: GmailThread -> GmailLabel
            abstract removeFromThreads: threads: ResizeArray<GmailThread> -> GmailLabel

        and [<AllowNullLiteral>] GmailMessage =
            abstract forward: recipient: string -> GmailMessage
            abstract forward: recipient: string * options: obj -> GmailMessage
            abstract getAttachments: unit -> ResizeArray<GmailAttachment>
            abstract getBcc: unit -> string
            abstract getBody: unit -> string
            abstract getCc: unit -> string
            abstract getDate: unit -> DateTime
            abstract getFrom: unit -> string
            abstract getId: unit -> string
            abstract getPlainBody: unit -> string
            abstract getRawContent: unit -> string
            abstract getReplyTo: unit -> string
            abstract getSubject: unit -> string
            abstract getThread: unit -> GmailThread
            abstract getTo: unit -> string
            abstract isDraft: unit -> bool
            abstract isInChats: unit -> bool
            abstract isInInbox: unit -> bool
            abstract isInTrash: unit -> bool
            abstract isStarred: unit -> bool
            abstract isUnread: unit -> bool
            abstract markRead: unit -> GmailMessage
            abstract markUnread: unit -> GmailMessage
            abstract moveToTrash: unit -> GmailMessage
            abstract refresh: unit -> GmailMessage
            abstract reply: body: string -> GmailMessage
            abstract reply: body: string * options: obj -> GmailMessage
            abstract replyAll: body: string -> GmailMessage
            abstract replyAll: body: string * options: obj -> GmailMessage
            abstract star: unit -> GmailMessage
            abstract unstar: unit -> GmailMessage

        and [<AllowNullLiteral>] GmailThread =
            abstract addLabel: label: GmailLabel -> GmailThread
            abstract getFirstMessageSubject: unit -> string
            abstract getId: unit -> string
            abstract getLabels: unit -> ResizeArray<GmailLabel>
            abstract getLastMessageDate: unit -> DateTime
            abstract getMessageCount: unit -> Integer
            abstract getMessages: unit -> ResizeArray<GmailMessage>
            abstract getPermalink: unit -> string
            abstract hasStarredMessages: unit -> bool
            abstract isImportant: unit -> bool
            abstract isInChats: unit -> bool
            abstract isInInbox: unit -> bool
            abstract isInSpam: unit -> bool
            abstract isInTrash: unit -> bool
            abstract isUnread: unit -> bool
            abstract markImportant: unit -> GmailThread
            abstract markRead: unit -> GmailThread
            abstract markUnimportant: unit -> GmailThread
            abstract markUnread: unit -> GmailThread
            abstract moveToArchive: unit -> GmailThread
            abstract moveToInbox: unit -> GmailThread
            abstract moveToSpam: unit -> GmailThread
            abstract moveToTrash: unit -> GmailThread
            abstract refresh: unit -> GmailThread
            abstract removeLabel: label: GmailLabel -> GmailThread
            abstract reply: body: string -> GmailThread
            abstract reply: body: string * options: obj -> GmailThread
            abstract replyAll: body: string -> GmailThread
            abstract replyAll: body: string * options: obj -> GmailThread

//type [<Erase>]Globals =
//    [<Global>] static member GmailApp with get(): GoogleAppsScript.Gmail.GmailApp = jsNative and set(v: GoogleAppsScript.Gmail.GmailApp): unit = jsNative

