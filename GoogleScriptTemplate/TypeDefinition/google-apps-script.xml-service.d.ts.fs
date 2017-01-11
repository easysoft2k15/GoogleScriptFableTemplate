namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module XML_Service =
        type [<AllowNullLiteral>] Attribute =
            abstract getName: unit -> string
            abstract getNamespace: unit -> Namespace
            abstract getValue: unit -> string
            abstract setName: name: string -> Attribute
            abstract setNamespace: ``namespace``: Namespace -> Attribute
            abstract setValue: value: string -> Attribute

        and [<AllowNullLiteral>] Cdata =
            abstract append: text: string -> Text
            abstract detach: unit -> Content
            abstract getParentElement: unit -> Element
            abstract getText: unit -> string
            abstract getValue: unit -> string
            abstract setText: text: string -> Text

        and [<AllowNullLiteral>] Comment =
            abstract detach: unit -> Content
            abstract getParentElement: unit -> Element
            abstract getText: unit -> string
            abstract getValue: unit -> string
            abstract setText: text: string -> Comment

        and [<AllowNullLiteral>] Content =
            abstract asCdata: unit -> Cdata
            abstract asComment: unit -> Comment
            abstract asDocType: unit -> DocType
            abstract asElement: unit -> Element
            abstract asEntityRef: unit -> EntityRef
            abstract asProcessingInstruction: unit -> ProcessingInstruction
            abstract asText: unit -> Text
            abstract detach: unit -> Content
            abstract getParentElement: unit -> Element
            abstract getType: unit -> ContentType
            abstract getValue: unit -> string

        and ContentType =
            | CDATA = 0
            | COMMENT = 1
            | DOCTYPE = 2
            | ELEMENT = 3
            | ENTITYREF = 4
            | PROCESSINGINSTRUCTION = 5
            | TEXT = 6

        and [<AllowNullLiteral>] DocType =
            abstract detach: unit -> Content
            abstract getElementName: unit -> string
            abstract getInternalSubset: unit -> string
            abstract getParentElement: unit -> Element
            abstract getPublicId: unit -> string
            abstract getSystemId: unit -> string
            abstract getValue: unit -> string
            abstract setElementName: name: string -> DocType
            abstract setInternalSubset: data: string -> DocType
            abstract setPublicId: id: string -> DocType
            abstract setSystemId: id: string -> DocType

        and [<AllowNullLiteral>] Document =
            abstract addContent: content: Content -> Document
            abstract addContent: index: Integer * content: Content -> Document
            abstract cloneContent: unit -> ResizeArray<Content>
            abstract detachRootElement: unit -> Element
            abstract getAllContent: unit -> ResizeArray<Content>
            abstract getContent: index: Integer -> Content
            abstract getContentSize: unit -> Integer
            abstract getDescendants: unit -> ResizeArray<Content>
            abstract getDocType: unit -> DocType
            abstract getRootElement: unit -> Element
            abstract hasRootElement: unit -> bool
            abstract removeContent: unit -> ResizeArray<Content>
            abstract removeContent: content: Content -> bool
            abstract removeContent: index: Integer -> Content
            abstract setDocType: docType: DocType -> Document
            abstract setRootElement: element: Element -> Document

        and [<AllowNullLiteral>] Element =
            abstract addContent: content: Content -> Element
            abstract addContent: index: Integer * content: Content -> Element
            abstract cloneContent: unit -> ResizeArray<Content>
            abstract detach: unit -> Content
            abstract getAllContent: unit -> ResizeArray<Content>
            abstract getAttribute: name: string -> Attribute
            abstract getAttribute: name: string * ``namespace``: Namespace -> Attribute
            abstract getAttributes: unit -> ResizeArray<Attribute>
            abstract getChild: name: string -> Element
            abstract getChild: name: string * ``namespace``: Namespace -> Element
            abstract getChildText: name: string -> string
            abstract getChildText: name: string * ``namespace``: Namespace -> string
            abstract getChildren: unit -> ResizeArray<Element>
            abstract getChildren: name: string -> ResizeArray<Element>
            abstract getChildren: name: string * ``namespace``: Namespace -> ResizeArray<Element>
            abstract getContent: index: Integer -> Content
            abstract getContentSize: unit -> Integer
            abstract getDescendants: unit -> ResizeArray<Content>
            abstract getDocument: unit -> Document
            abstract getName: unit -> string
            abstract getNamespace: unit -> Namespace
            abstract getNamespace: prefix: string -> Namespace
            abstract getParentElement: unit -> Element
            abstract getQualifiedName: unit -> string
            abstract getText: unit -> string
            abstract getValue: unit -> string
            abstract isAncestorOf: other: Element -> bool
            abstract isRootElement: unit -> bool
            abstract removeAttribute: attribute: Attribute -> bool
            abstract removeAttribute: attributeName: string -> bool
            abstract removeAttribute: attributeName: string * ``namespace``: Namespace -> bool
            abstract removeContent: unit -> ResizeArray<Content>
            abstract removeContent: content: Content -> bool
            abstract removeContent: index: Integer -> Content
            abstract setAttribute: attribute: Attribute -> Element
            abstract setAttribute: name: string * value: string -> Element
            abstract setAttribute: name: string * value: string * ``namespace``: Namespace -> Element
            abstract setName: name: string -> Element
            abstract setNamespace: ``namespace``: Namespace -> Element
            abstract setText: text: string -> Element

        and [<AllowNullLiteral>] EntityRef =
            abstract detach: unit -> Content
            abstract getName: unit -> string
            abstract getParentElement: unit -> Element
            abstract getPublicId: unit -> string
            abstract getSystemId: unit -> string
            abstract getValue: unit -> string
            abstract setName: name: string -> EntityRef
            abstract setPublicId: id: string -> EntityRef
            abstract setSystemId: id: string -> EntityRef

        and [<AllowNullLiteral>] Format =
            abstract format: document: Document -> string
            abstract format: element: Element -> string
            abstract setEncoding: encoding: string -> Format
            abstract setIndent: indent: string -> Format
            abstract setLineSeparator: separator: string -> Format
            abstract setOmitDeclaration: omitDeclaration: bool -> Format
            abstract setOmitEncoding: omitEncoding: bool -> Format

        and [<AllowNullLiteral>] Namespace =
            abstract getPrefix: unit -> string
            abstract getURI: unit -> string

        and [<AllowNullLiteral>] ProcessingInstruction =
            abstract detach: unit -> Content
            abstract getData: unit -> string
            abstract getParentElement: unit -> Element
            abstract getTarget: unit -> string
            abstract getValue: unit -> string

        and [<AllowNullLiteral>] Text =
            abstract append: text: string -> Text
            abstract detach: unit -> Content
            abstract getParentElement: unit -> Element
            abstract getText: unit -> string
            abstract getValue: unit -> string
            abstract setText: text: string -> Text

        and [<AllowNullLiteral>] XmlService =
            abstract ContentTypes: ContentType with get, set
            abstract createCdata: text: string -> Cdata
            abstract createComment: text: string -> Comment
            abstract createDocType: elementName: string -> DocType
            abstract createDocType: elementName: string * systemId: string -> DocType
            abstract createDocType: elementName: string * publicId: string * systemId: string -> DocType
            abstract createDocument: unit -> Document
            abstract createDocument: rootElement: Element -> Document
            abstract createElement: name: string -> Element
            abstract createElement: name: string * ``namespace``: Namespace -> Element
            abstract createText: text: string -> Text
            abstract getCompactFormat: unit -> Format
            abstract getNamespace: uri: string -> Namespace
            abstract getNamespace: prefix: string * uri: string -> Namespace
            abstract getNoNamespace: unit -> Namespace
            abstract getPrettyFormat: unit -> Format
            abstract getRawFormat: unit -> Format
            abstract getXmlNamespace: unit -> Namespace
            abstract parse: xml: string -> Document

//type [<Erase>]Globals =
//    [<Global>] static member XmlService with get(): GoogleAppsScript.XML_Service.XmlService = jsNative and set(v: GoogleAppsScript.XML_Service.XmlService): unit = jsNative

