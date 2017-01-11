namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Document =
        type Attribute =
            | BACKGROUND_COLOR = 0
            | BOLD = 1
            | BORDER_COLOR = 2
            | BORDER_WIDTH = 3
            | CODE = 4
            | FONT_FAMILY = 5
            | FONT_SIZE = 6
            | FOREGROUND_COLOR = 7
            | HEADING = 8
            | HEIGHT = 9
            | HORIZONTAL_ALIGNMENT = 10
            | INDENT_END = 11
            | INDENT_FIRST_LINE = 12
            | INDENT_START = 13
            | ITALIC = 14
            | GLYPH_TYPE = 15
            | LEFT_TO_RIGHT = 16
            | LINE_SPACING = 17
            | LINK_URL = 18
            | LIST_ID = 19
            | MARGIN_BOTTOM = 20
            | MARGIN_LEFT = 21
            | MARGIN_RIGHT = 22
            | MARGIN_TOP = 23
            | NESTING_LEVEL = 24
            | MINIMUM_HEIGHT = 25
            | PADDING_BOTTOM = 26
            | PADDING_LEFT = 27
            | PADDING_RIGHT = 28
            | PADDING_TOP = 29
            | PAGE_HEIGHT = 30
            | PAGE_WIDTH = 31
            | SPACING_AFTER = 32
            | SPACING_BEFORE = 33
            | STRIKETHROUGH = 34
            | UNDERLINE = 35
            | VERTICAL_ALIGNMENT = 36
            | WIDTH = 37

        and [<AllowNullLiteral>] Body =
            abstract appendHorizontalRule: unit -> HorizontalRule
            abstract appendImage: image: Base.BlobSource -> InlineImage
            abstract appendImage: image: InlineImage -> InlineImage
            abstract appendListItem: listItem: ListItem -> ListItem
            abstract appendListItem: text: string -> ListItem
            abstract appendPageBreak: unit -> PageBreak
            abstract appendPageBreak: pageBreak: PageBreak -> PageBreak
            abstract appendParagraph: paragraph: Paragraph -> Paragraph
            abstract appendParagraph: text: string -> Paragraph
            abstract appendTable: unit -> Table
            abstract appendTable: cells: ResizeArray<ResizeArray<string>> -> Table
            abstract appendTable: table: Table -> Table
            abstract clear: unit -> Body
            abstract copy: unit -> Body
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getImages: unit -> ResizeArray<InlineImage>
            abstract getListItems: unit -> ResizeArray<ListItem>
            abstract getMarginBottom: unit -> float
            abstract getMarginLeft: unit -> float
            abstract getMarginRight: unit -> float
            abstract getMarginTop: unit -> float
            abstract getNumChildren: unit -> Integer
            abstract getPageHeight: unit -> float
            abstract getPageWidth: unit -> float
            abstract getParagraphs: unit -> ResizeArray<Paragraph>
            abstract getParent: unit -> ContainerElement
            abstract getTables: unit -> ResizeArray<Table>
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract insertHorizontalRule: childIndex: Integer -> HorizontalRule
            abstract insertImage: childIndex: Integer * image: Base.BlobSource -> InlineImage
            abstract insertImage: childIndex: Integer * image: InlineImage -> InlineImage
            abstract insertListItem: childIndex: Integer * listItem: ListItem -> ListItem
            abstract insertListItem: childIndex: Integer * text: string -> ListItem
            abstract insertPageBreak: childIndex: Integer -> PageBreak
            abstract insertPageBreak: childIndex: Integer * pageBreak: PageBreak -> PageBreak
            abstract insertParagraph: childIndex: Integer * paragraph: Paragraph -> Paragraph
            abstract insertParagraph: childIndex: Integer * text: string -> Paragraph
            abstract insertTable: childIndex: Integer -> Table
            abstract insertTable: childIndex: Integer * cells: ResizeArray<ResizeArray<string>> -> Table
            abstract insertTable: childIndex: Integer * table: Table -> Table
            abstract removeChild: child: Element -> Body
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> Body
            abstract setMarginBottom: marginBottom: float -> Body
            abstract setMarginLeft: marginLeft: float -> Body
            abstract setMarginRight: marginRight: float -> Body
            abstract setMarginTop: marginTop: float -> Body
            abstract setPageHeight: pageHeight: float -> Body
            abstract setPageWidth: pageWidth: float -> Body
            abstract setText: text: string -> Body
            abstract setTextAlignment: textAlignment: TextAlignment -> Body
            abstract getFootnotes: unit -> ResizeArray<Footnote>
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getPreviousSibling: unit -> Element
            abstract isAtDocumentEnd: unit -> bool
            abstract setLinkUrl: url: string -> Body

        and [<AllowNullLiteral>] Bookmark =
            abstract getId: unit -> string
            abstract getPosition: unit -> Position
            abstract remove: unit -> unit

        and [<AllowNullLiteral>] ContainerElement =
            abstract asBody: unit -> Body
            abstract asEquation: unit -> Equation
            abstract asFooterSection: unit -> FooterSection
            abstract asFootnoteSection: unit -> FootnoteSection
            abstract asHeaderSection: unit -> HeaderSection
            abstract asListItem: unit -> ListItem
            abstract asParagraph: unit -> Paragraph
            abstract asTable: unit -> Table
            abstract asTableCell: unit -> TableCell
            abstract asTableOfContents: unit -> TableOfContents
            abstract asTableRow: unit -> TableRow
            abstract clear: unit -> ContainerElement
            abstract copy: unit -> ContainerElement
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> ContainerElement
            abstract removeFromParent: unit -> ContainerElement
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> ContainerElement
            abstract setLinkUrl: url: string -> ContainerElement
            abstract setTextAlignment: textAlignment: TextAlignment -> ContainerElement

        and [<AllowNullLiteral>] Document =
            abstract addBookmark: position: Position -> Bookmark
            abstract addEditor: emailAddress: string -> Document
            abstract addEditor: user: Base.User -> Document
            abstract addEditors: emailAddresses: ResizeArray<string> -> Document
            abstract addFooter: unit -> FooterSection
            abstract addHeader: unit -> HeaderSection
            abstract addNamedRange: name: string * range: Range -> NamedRange
            abstract addViewer: emailAddress: string -> Document
            abstract addViewer: user: Base.User -> Document
            abstract addViewers: emailAddresses: ResizeArray<string> -> Document
            abstract getAs: contentType: string -> Base.Blob
            abstract getBlob: unit -> Base.Blob
            abstract getBody: unit -> Body
            abstract getBookmark: id: string -> Bookmark
            abstract getBookmarks: unit -> ResizeArray<Bookmark>
            abstract getCursor: unit -> Position
            abstract getEditors: unit -> ResizeArray<Base.User>
            abstract getFooter: unit -> FooterSection
            abstract getFootnotes: unit -> ResizeArray<Footnote>
            abstract getHeader: unit -> HeaderSection
            abstract getId: unit -> string
            abstract getName: unit -> string
            abstract getNamedRangeById: id: string -> NamedRange
            abstract getNamedRanges: unit -> ResizeArray<NamedRange>
            abstract getNamedRanges: name: string -> ResizeArray<NamedRange>
            abstract getSelection: unit -> Range
            abstract getUrl: unit -> string
            abstract getViewers: unit -> ResizeArray<Base.User>
            abstract newPosition: element: Element * offset: Integer -> Position
            abstract newRange: unit -> RangeBuilder
            abstract removeEditor: emailAddress: string -> Document
            abstract removeEditor: user: Base.User -> Document
            abstract removeViewer: emailAddress: string -> Document
            abstract removeViewer: user: Base.User -> Document
            abstract saveAndClose: unit -> unit
            abstract setCursor: position: Position -> Document
            abstract setName: name: string -> Document
            abstract setSelection: range: Range -> Document

        and [<AllowNullLiteral>] DocumentApp =
            abstract Attribute: Attribute with get, set
            abstract ElementType: ElementType with get, set
            abstract FontFamily: FontFamily with get, set
            abstract GlyphType: GlyphType with get, set
            abstract HorizontalAlignment: HorizontalAlignment with get, set
            abstract ParagraphHeading: ParagraphHeading with get, set
            abstract TextAlignment: TextAlignment with get, set
            abstract VerticalAlignment: VerticalAlignment with get, set
            abstract create: name: string -> Document
            abstract getActiveDocument: unit -> Document
            abstract getUi: unit -> Base.Ui
            abstract openById: id: string -> Document
            abstract openByUrl: url: string -> Document

        and [<AllowNullLiteral>] Element =
            abstract asBody: unit -> Body
            abstract asEquation: unit -> Equation
            abstract asEquationFunction: unit -> EquationFunction
            abstract asEquationFunctionArgumentSeparator: unit -> EquationFunctionArgumentSeparator
            abstract asEquationSymbol: unit -> EquationSymbol
            abstract asFooterSection: unit -> FooterSection
            abstract asFootnote: unit -> Footnote
            abstract asFootnoteSection: unit -> FootnoteSection
            abstract asHeaderSection: unit -> HeaderSection
            abstract asHorizontalRule: unit -> HorizontalRule
            abstract asInlineDrawing: unit -> InlineDrawing
            abstract asInlineImage: unit -> InlineImage
            abstract asListItem: unit -> ListItem
            abstract asPageBreak: unit -> PageBreak
            abstract asParagraph: unit -> Paragraph
            abstract asTable: unit -> Table
            abstract asTableCell: unit -> TableCell
            abstract asTableOfContents: unit -> TableOfContents
            abstract asTableRow: unit -> TableRow
            abstract asText: unit -> Text
            abstract copy: unit -> Element
            abstract getAttributes: unit -> obj
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> Element
            abstract removeFromParent: unit -> Element
            abstract setAttributes: attributes: obj -> Element

        and ElementType =
            | BODY_SECTION = 0
            | COMMENT_SECTION = 1
            | DOCUMENT = 2
            | EQUATION = 3
            | EQUATION_FUNCTION = 4
            | EQUATION_FUNCTION_ARGUMENT_SEPARATOR = 5
            | EQUATION_SYMBOL = 6
            | FOOTER_SECTION = 7
            | FOOTNOTE = 8
            | FOOTNOTE_SECTION = 9
            | HEADER_SECTION = 10
            | HORIZONTAL_RULE = 11
            | INLINE_DRAWING = 12
            | INLINE_IMAGE = 13
            | LIST_ITEM = 14
            | PAGE_BREAK = 15
            | PARAGRAPH = 16
            | TABLE = 17
            | TABLE_CELL = 18
            | TABLE_OF_CONTENTS = 19
            | TABLE_ROW = 20
            | TEXT = 21
            | UNSUPPORTED = 22

        and [<AllowNullLiteral>] Equation =
            abstract clear: unit -> Equation
            abstract copy: unit -> Equation
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> Equation
            abstract removeFromParent: unit -> Equation
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> Equation
            abstract setLinkUrl: url: string -> Equation
            abstract setTextAlignment: textAlignment: TextAlignment -> Equation

        and [<AllowNullLiteral>] EquationFunction =
            abstract clear: unit -> EquationFunction
            abstract copy: unit -> EquationFunction
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getCode: unit -> string
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> EquationFunction
            abstract removeFromParent: unit -> EquationFunction
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> EquationFunction
            abstract setLinkUrl: url: string -> EquationFunction
            abstract setTextAlignment: textAlignment: TextAlignment -> EquationFunction

        and [<AllowNullLiteral>] EquationFunctionArgumentSeparator =
            abstract copy: unit -> EquationFunctionArgumentSeparator
            abstract getAttributes: unit -> obj
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> EquationFunctionArgumentSeparator
            abstract removeFromParent: unit -> EquationFunctionArgumentSeparator
            abstract setAttributes: attributes: obj -> EquationFunctionArgumentSeparator

        and [<AllowNullLiteral>] EquationSymbol =
            abstract copy: unit -> EquationSymbol
            abstract getAttributes: unit -> obj
            abstract getCode: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> EquationSymbol
            abstract removeFromParent: unit -> EquationSymbol
            abstract setAttributes: attributes: obj -> EquationSymbol

        and FontFamily =
            | AMARANTH = 0
            | ARIAL = 1
            | ARIAL_BLACK = 2
            | ARIAL_NARROW = 3
            | ARVO = 4
            | CALIBRI = 5
            | CAMBRIA = 6
            | COMIC_SANS_MS = 7
            | CONSOLAS = 8
            | CORSIVA = 9
            | COURIER_NEW = 10
            | DANCING_SCRIPT = 11
            | DROID_SANS = 12
            | DROID_SERIF = 13
            | GARAMOND = 14
            | GEORGIA = 15
            | GLORIA_HALLELUJAH = 16
            | GREAT_VIBES = 17
            | LOBSTER = 18
            | MERRIWEATHER = 19
            | PACIFICO = 20
            | PHILOSOPHER = 21
            | POIRET_ONE = 22
            | QUATTROCENTO = 23
            | ROBOTO = 24
            | SHADOWS_INTO_LIGHT = 25
            | SYNCOPATE = 26
            | TAHOMA = 27
            | TIMES_NEW_ROMAN = 28
            | TREBUCHET_MS = 29
            | UBUNTU = 30
            | VERDANA = 31

        and [<AllowNullLiteral>] FooterSection =
            abstract appendHorizontalRule: unit -> HorizontalRule
            abstract appendImage: image: Base.BlobSource -> InlineImage
            abstract appendImage: image: InlineImage -> InlineImage
            abstract appendListItem: listItem: ListItem -> ListItem
            abstract appendListItem: text: string -> ListItem
            abstract appendParagraph: paragraph: Paragraph -> Paragraph
            abstract appendParagraph: text: string -> Paragraph
            abstract appendTable: unit -> Table
            abstract appendTable: cells: ResizeArray<ResizeArray<string>> -> Table
            abstract appendTable: table: Table -> Table
            abstract clear: unit -> FooterSection
            abstract copy: unit -> FooterSection
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getImages: unit -> ResizeArray<InlineImage>
            abstract getListItems: unit -> ResizeArray<ListItem>
            abstract getNumChildren: unit -> Integer
            abstract getParagraphs: unit -> ResizeArray<Paragraph>
            abstract getParent: unit -> ContainerElement
            abstract getTables: unit -> ResizeArray<Table>
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract insertHorizontalRule: childIndex: Integer -> HorizontalRule
            abstract insertImage: childIndex: Integer * image: Base.BlobSource -> InlineImage
            abstract insertImage: childIndex: Integer * image: InlineImage -> InlineImage
            abstract insertListItem: childIndex: Integer * listItem: ListItem -> ListItem
            abstract insertListItem: childIndex: Integer * text: string -> ListItem
            abstract insertParagraph: childIndex: Integer * paragraph: Paragraph -> Paragraph
            abstract insertParagraph: childIndex: Integer * text: string -> Paragraph
            abstract insertTable: childIndex: Integer -> Table
            abstract insertTable: childIndex: Integer * cells: ResizeArray<ResizeArray<string>> -> Table
            abstract insertTable: childIndex: Integer * table: Table -> Table
            abstract removeChild: child: Element -> FooterSection
            abstract removeFromParent: unit -> FooterSection
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> FooterSection
            abstract setText: text: string -> FooterSection
            abstract setTextAlignment: textAlignment: TextAlignment -> FooterSection
            abstract getFootnotes: unit -> ResizeArray<Footnote>
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getPreviousSibling: unit -> Element
            abstract isAtDocumentEnd: unit -> bool
            abstract setLinkUrl: url: string -> FooterSection

        and [<AllowNullLiteral>] Footnote =
            abstract copy: unit -> Footnote
            abstract getAttributes: unit -> obj
            abstract getFootnoteContents: unit -> FootnoteSection
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract removeFromParent: unit -> Footnote
            abstract setAttributes: attributes: obj -> Footnote

        and [<AllowNullLiteral>] FootnoteSection =
            abstract appendParagraph: paragraph: Paragraph -> Paragraph
            abstract appendParagraph: text: string -> Paragraph
            abstract clear: unit -> FootnoteSection
            abstract copy: unit -> FootnoteSection
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getParagraphs: unit -> ResizeArray<Paragraph>
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract insertParagraph: childIndex: Integer * paragraph: Paragraph -> Paragraph
            abstract insertParagraph: childIndex: Integer * text: string -> Paragraph
            abstract removeChild: child: Element -> FootnoteSection
            abstract removeFromParent: unit -> FootnoteSection
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> FootnoteSection
            abstract setText: text: string -> FootnoteSection
            abstract setTextAlignment: textAlignment: TextAlignment -> FootnoteSection
            abstract getFootnotes: unit -> ResizeArray<Footnote>
            abstract getLinkUrl: unit -> string
            abstract isAtDocumentEnd: unit -> bool
            abstract setLinkUrl: url: string -> FootnoteSection

        and GlyphType =
            | BULLET = 0
            | HOLLOW_BULLET = 1
            | SQUARE_BULLET = 2
            | NUMBER = 3
            | LATIN_UPPER = 4
            | LATIN_LOWER = 5
            | ROMAN_UPPER = 6
            | ROMAN_LOWER = 7

        and [<AllowNullLiteral>] HeaderSection =
            abstract appendHorizontalRule: unit -> HorizontalRule
            abstract appendImage: image: Base.BlobSource -> InlineImage
            abstract appendImage: image: InlineImage -> InlineImage
            abstract appendListItem: listItem: ListItem -> ListItem
            abstract appendListItem: text: string -> ListItem
            abstract appendParagraph: paragraph: Paragraph -> Paragraph
            abstract appendParagraph: text: string -> Paragraph
            abstract appendTable: unit -> Table
            abstract appendTable: cells: ResizeArray<ResizeArray<string>> -> Table
            abstract appendTable: table: Table -> Table
            abstract clear: unit -> HeaderSection
            abstract copy: unit -> HeaderSection
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getImages: unit -> ResizeArray<InlineImage>
            abstract getListItems: unit -> ResizeArray<ListItem>
            abstract getNumChildren: unit -> Integer
            abstract getParagraphs: unit -> ResizeArray<Paragraph>
            abstract getParent: unit -> ContainerElement
            abstract getTables: unit -> ResizeArray<Table>
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract insertHorizontalRule: childIndex: Integer -> HorizontalRule
            abstract insertImage: childIndex: Integer * image: Base.BlobSource -> InlineImage
            abstract insertImage: childIndex: Integer * image: InlineImage -> InlineImage
            abstract insertListItem: childIndex: Integer * listItem: ListItem -> ListItem
            abstract insertListItem: childIndex: Integer * text: string -> ListItem
            abstract insertParagraph: childIndex: Integer * paragraph: Paragraph -> Paragraph
            abstract insertParagraph: childIndex: Integer * text: string -> Paragraph
            abstract insertTable: childIndex: Integer -> Table
            abstract insertTable: childIndex: Integer * cells: ResizeArray<ResizeArray<string>> -> Table
            abstract insertTable: childIndex: Integer * table: Table -> Table
            abstract removeChild: child: Element -> HeaderSection
            abstract removeFromParent: unit -> HeaderSection
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> HeaderSection
            abstract setText: text: string -> HeaderSection
            abstract setTextAlignment: textAlignment: TextAlignment -> HeaderSection
            abstract getFootnotes: unit -> ResizeArray<Footnote>
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getPreviousSibling: unit -> Element
            abstract isAtDocumentEnd: unit -> bool
            abstract setLinkUrl: url: string -> HeaderSection

        and HorizontalAlignment =
            | LEFT = 0
            | CENTER = 1
            | RIGHT = 2
            | JUSTIFY = 3

        and [<AllowNullLiteral>] HorizontalRule =
            abstract copy: unit -> HorizontalRule
            abstract getAttributes: unit -> obj
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract removeFromParent: unit -> HorizontalRule
            abstract setAttributes: attributes: obj -> HorizontalRule

        and [<AllowNullLiteral>] InlineDrawing =
            abstract copy: unit -> InlineDrawing
            abstract getAttributes: unit -> obj
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> InlineDrawing
            abstract removeFromParent: unit -> InlineDrawing
            abstract setAttributes: attributes: obj -> InlineDrawing

        and [<AllowNullLiteral>] InlineImage =
            abstract copy: unit -> InlineImage
            abstract getAs: contentType: string -> Base.Blob
            abstract getAttributes: unit -> obj
            abstract getBlob: unit -> Base.Blob
            abstract getHeight: unit -> Integer
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract getWidth: unit -> Integer
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> InlineImage
            abstract removeFromParent: unit -> InlineImage
            abstract setAttributes: attributes: obj -> InlineImage
            abstract setHeight: height: Integer -> InlineImage
            abstract setLinkUrl: url: string -> InlineImage
            abstract setWidth: width: Integer -> InlineImage

        and [<AllowNullLiteral>] ListItem =
            abstract appendHorizontalRule: unit -> HorizontalRule
            abstract appendInlineImage: image: Base.BlobSource -> InlineImage
            abstract appendInlineImage: image: InlineImage -> InlineImage
            abstract appendPageBreak: unit -> PageBreak
            abstract appendPageBreak: pageBreak: PageBreak -> PageBreak
            abstract appendText: text: string -> Text
            abstract appendText: text: Text -> Text
            abstract clear: unit -> ListItem
            abstract copy: unit -> ListItem
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAlignment: unit -> HorizontalAlignment
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getGlyphType: unit -> GlyphType
            abstract getHeading: unit -> ParagraphHeading
            abstract getIndentEnd: unit -> float
            abstract getIndentFirstLine: unit -> float
            abstract getIndentStart: unit -> float
            abstract getLineSpacing: unit -> float
            abstract getLinkUrl: unit -> string
            abstract getListId: unit -> string
            abstract getNestingLevel: unit -> Integer
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getSpacingAfter: unit -> float
            abstract getSpacingBefore: unit -> float
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract insertHorizontalRule: childIndex: Integer -> HorizontalRule
            abstract insertInlineImage: childIndex: Integer * image: Base.BlobSource -> InlineImage
            abstract insertInlineImage: childIndex: Integer * image: InlineImage -> InlineImage
            abstract insertPageBreak: childIndex: Integer -> PageBreak
            abstract insertPageBreak: childIndex: Integer * pageBreak: PageBreak -> PageBreak
            abstract insertText: childIndex: Integer * text: string -> Text
            abstract insertText: childIndex: Integer * text: Text -> Text
            abstract isAtDocumentEnd: unit -> bool
            abstract isLeftToRight: unit -> bool
            abstract merge: unit -> ListItem
            abstract removeChild: child: Element -> ListItem
            abstract removeFromParent: unit -> ListItem
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAlignment: alignment: HorizontalAlignment -> ListItem
            abstract setAttributes: attributes: obj -> ListItem
            abstract setGlyphType: glyphType: GlyphType -> ListItem
            abstract setHeading: heading: ParagraphHeading -> ListItem
            abstract setIndentEnd: indentEnd: float -> ListItem
            abstract setIndentFirstLine: indentFirstLine: float -> ListItem
            abstract setIndentStart: indentStart: float -> ListItem
            abstract setLeftToRight: leftToRight: bool -> ListItem
            abstract setLineSpacing: multiplier: float -> ListItem
            abstract setLinkUrl: url: string -> ListItem
            abstract setListId: listItem: ListItem -> ListItem
            abstract setNestingLevel: nestingLevel: Integer -> ListItem
            abstract setSpacingAfter: spacingAfter: float -> ListItem
            abstract setSpacingBefore: spacingBefore: float -> ListItem
            abstract setText: text: string -> unit
            abstract setTextAlignment: textAlignment: TextAlignment -> ListItem

        and [<AllowNullLiteral>] NamedRange =
            abstract getId: unit -> string
            abstract getName: unit -> string
            abstract getRange: unit -> Range
            abstract remove: unit -> unit

        and [<AllowNullLiteral>] PageBreak =
            abstract copy: unit -> PageBreak
            abstract getAttributes: unit -> obj
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract removeFromParent: unit -> PageBreak
            abstract setAttributes: attributes: obj -> PageBreak

        and [<AllowNullLiteral>] Paragraph =
            abstract appendHorizontalRule: unit -> HorizontalRule
            abstract appendInlineImage: image: Base.BlobSource -> InlineImage
            abstract appendInlineImage: image: InlineImage -> InlineImage
            abstract appendPageBreak: unit -> PageBreak
            abstract appendPageBreak: pageBreak: PageBreak -> PageBreak
            abstract appendText: text: string -> Text
            abstract appendText: text: Text -> Text
            abstract clear: unit -> Paragraph
            abstract copy: unit -> Paragraph
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAlignment: unit -> HorizontalAlignment
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getHeading: unit -> ParagraphHeading
            abstract getIndentEnd: unit -> float
            abstract getIndentFirstLine: unit -> float
            abstract getIndentStart: unit -> float
            abstract getLineSpacing: unit -> float
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getSpacingAfter: unit -> float
            abstract getSpacingBefore: unit -> float
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract insertHorizontalRule: childIndex: Integer -> HorizontalRule
            abstract insertInlineImage: childIndex: Integer * image: Base.BlobSource -> InlineImage
            abstract insertInlineImage: childIndex: Integer * image: InlineImage -> InlineImage
            abstract insertPageBreak: childIndex: Integer -> PageBreak
            abstract insertPageBreak: childIndex: Integer * pageBreak: PageBreak -> PageBreak
            abstract insertText: childIndex: Integer * text: string -> Text
            abstract insertText: childIndex: Integer * text: Text -> Text
            abstract isAtDocumentEnd: unit -> bool
            abstract isLeftToRight: unit -> bool
            abstract merge: unit -> Paragraph
            abstract removeChild: child: Element -> Paragraph
            abstract removeFromParent: unit -> Paragraph
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAlignment: alignment: HorizontalAlignment -> Paragraph
            abstract setAttributes: attributes: obj -> Paragraph
            abstract setHeading: heading: ParagraphHeading -> Paragraph
            abstract setIndentEnd: indentEnd: float -> Paragraph
            abstract setIndentFirstLine: indentFirstLine: float -> Paragraph
            abstract setIndentStart: indentStart: float -> Paragraph
            abstract setLeftToRight: leftToRight: bool -> Paragraph
            abstract setLineSpacing: multiplier: float -> Paragraph
            abstract setLinkUrl: url: string -> Paragraph
            abstract setSpacingAfter: spacingAfter: float -> Paragraph
            abstract setSpacingBefore: spacingBefore: float -> Paragraph
            abstract setText: text: string -> unit
            abstract setTextAlignment: textAlignment: TextAlignment -> Paragraph

        and ParagraphHeading =
            | NORMAL = 0
            | HEADING1 = 1
            | HEADING2 = 2
            | HEADING3 = 3
            | HEADING4 = 4
            | HEADING5 = 5
            | HEADING6 = 6
            | TITLE = 7
            | SUBTITLE = 8

        and [<AllowNullLiteral>] Position =
            abstract getElement: unit -> Element
            abstract getOffset: unit -> Integer
            abstract getSurroundingText: unit -> Text
            abstract getSurroundingTextOffset: unit -> Integer
            abstract insertBookmark: unit -> Bookmark
            abstract insertInlineImage: image: Base.BlobSource -> InlineImage
            abstract insertText: text: string -> Text

        and [<AllowNullLiteral>] Range =
            abstract getRangeElements: unit -> ResizeArray<RangeElement>
            abstract getSelectedElements: unit -> ResizeArray<RangeElement>

        and [<AllowNullLiteral>] RangeBuilder =
            abstract addElement: element: Element -> RangeBuilder
            abstract addElement: textElement: Text * startOffset: Integer * endOffsetInclusive: Integer -> RangeBuilder
            abstract addElementsBetween: startElement: Element * endElementInclusive: Element -> RangeBuilder
            abstract addElementsBetween: startTextElement: Text * startOffset: Integer * endTextElementInclusive: Text * endOffsetInclusive: Integer -> RangeBuilder
            abstract addRange: range: Range -> RangeBuilder
            abstract build: unit -> Range
            abstract getRangeElements: unit -> ResizeArray<RangeElement>
            abstract getSelectedElements: unit -> ResizeArray<RangeElement>

        and [<AllowNullLiteral>] RangeElement =
            abstract getElement: unit -> Element
            abstract getEndOffsetInclusive: unit -> Integer
            abstract getStartOffset: unit -> Integer
            abstract isPartial: unit -> bool

        and [<AllowNullLiteral>] Table =
            abstract appendTableRow: unit -> TableRow
            abstract appendTableRow: tableRow: TableRow -> TableRow
            abstract clear: unit -> Table
            abstract copy: unit -> Table
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getBorderColor: unit -> string
            abstract getBorderWidth: unit -> float
            abstract getCell: rowIndex: Integer * cellIndex: Integer -> TableCell
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getColumnWidth: columnIndex: Integer -> float
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getNumRows: unit -> Integer
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getRow: rowIndex: Integer -> TableRow
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract insertTableRow: childIndex: Integer -> TableRow
            abstract insertTableRow: childIndex: Integer * tableRow: TableRow -> TableRow
            abstract isAtDocumentEnd: unit -> bool
            abstract removeChild: child: Element -> Table
            abstract removeFromParent: unit -> Table
            abstract removeRow: rowIndex: Integer -> TableRow
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> Table
            abstract setBorderColor: color: string -> Table
            abstract setBorderWidth: width: float -> Table
            abstract setColumnWidth: columnIndex: Integer * width: float -> Table
            abstract setLinkUrl: url: string -> Table
            abstract setTextAlignment: textAlignment: TextAlignment -> Table

        and [<AllowNullLiteral>] TableCell =
            abstract appendHorizontalRule: unit -> HorizontalRule
            abstract appendImage: image: Base.BlobSource -> InlineImage
            abstract appendImage: image: InlineImage -> InlineImage
            abstract appendListItem: listItem: ListItem -> ListItem
            abstract appendListItem: text: string -> ListItem
            abstract appendParagraph: paragraph: Paragraph -> Paragraph
            abstract appendParagraph: text: string -> Paragraph
            abstract appendTable: unit -> Table
            abstract appendTable: cells: ResizeArray<ResizeArray<string>> -> Table
            abstract appendTable: table: Table -> Table
            abstract clear: unit -> TableCell
            abstract copy: unit -> TableCell
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getBackgroundColor: unit -> string
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getPaddingBottom: unit -> float
            abstract getPaddingLeft: unit -> float
            abstract getPaddingRight: unit -> float
            abstract getPaddingTop: unit -> float
            abstract getParent: unit -> ContainerElement
            abstract getParentRow: unit -> TableRow
            abstract getParentTable: unit -> Table
            abstract getPreviousSibling: unit -> Element
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract getVerticalAlignment: unit -> VerticalAlignment
            abstract getWidth: unit -> float
            abstract insertHorizontalRule: childIndex: Integer -> HorizontalRule
            abstract insertImage: childIndex: Integer * image: Base.BlobSource -> InlineImage
            abstract insertImage: childIndex: Integer * image: InlineImage -> InlineImage
            abstract insertListItem: childIndex: Integer * listItem: ListItem -> ListItem
            abstract insertListItem: childIndex: Integer * text: string -> ListItem
            abstract insertParagraph: childIndex: Integer * paragraph: Paragraph -> Paragraph
            abstract insertParagraph: childIndex: Integer * text: string -> Paragraph
            abstract insertTable: childIndex: Integer -> Table
            abstract insertTable: childIndex: Integer * cells: ResizeArray<ResizeArray<string>> -> Table
            abstract insertTable: childIndex: Integer * table: Table -> Table
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> TableCell
            abstract removeChild: child: Element -> TableCell
            abstract removeFromParent: unit -> TableCell
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> TableCell
            abstract setBackgroundColor: color: string -> TableCell
            abstract setLinkUrl: url: string -> TableCell
            abstract setPaddingBottom: paddingBottom: float -> TableCell
            abstract setPaddingLeft: paddingLeft: float -> TableCell
            abstract setPaddingRight: paddingTop: float -> TableCell
            abstract setPaddingTop: paddingTop: float -> TableCell
            abstract setText: text: string -> TableCell
            abstract setTextAlignment: textAlignment: TextAlignment -> TableCell
            abstract setVerticalAlignment: alignment: VerticalAlignment -> TableCell
            abstract setWidth: width: float -> TableCell

        and [<AllowNullLiteral>] TableOfContents =
            abstract clear: unit -> TableOfContents
            abstract copy: unit -> TableOfContents
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getLinkUrl: unit -> string
            abstract getNextSibling: unit -> Element
            abstract getNumChildren: unit -> Integer
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract removeFromParent: unit -> TableOfContents
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> TableOfContents
            abstract setLinkUrl: url: string -> TableOfContents
            abstract setTextAlignment: textAlignment: TextAlignment -> TableOfContents

        and [<AllowNullLiteral>] TableRow =
            abstract appendTableCell: unit -> TableCell
            abstract appendTableCell: textContents: string -> TableCell
            abstract appendTableCell: tableCell: TableCell -> TableCell
            abstract clear: unit -> TableRow
            abstract copy: unit -> TableRow
            abstract editAsText: unit -> Text
            abstract findElement: elementType: ElementType -> RangeElement
            abstract findElement: elementType: ElementType * from: RangeElement -> RangeElement
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getCell: cellIndex: Integer -> TableCell
            abstract getChild: childIndex: Integer -> Element
            abstract getChildIndex: child: Element -> Integer
            abstract getLinkUrl: unit -> string
            abstract getMinimumHeight: unit -> Integer
            abstract getNextSibling: unit -> Element
            abstract getNumCells: unit -> Integer
            abstract getNumChildren: unit -> Integer
            abstract getParent: unit -> ContainerElement
            abstract getParentTable: unit -> Table
            abstract getPreviousSibling: unit -> Element
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getType: unit -> ElementType
            abstract insertTableCell: childIndex: Integer -> TableCell
            abstract insertTableCell: childIndex: Integer * textContents: string -> TableCell
            abstract insertTableCell: childIndex: Integer * tableCell: TableCell -> TableCell
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> TableRow
            abstract removeCell: cellIndex: Integer -> TableCell
            abstract removeChild: child: Element -> TableRow
            abstract removeFromParent: unit -> TableRow
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: attributes: obj -> TableRow
            abstract setLinkUrl: url: string -> TableRow
            abstract setMinimumHeight: minHeight: Integer -> TableRow
            abstract setTextAlignment: textAlignment: TextAlignment -> TableRow

        and [<AllowNullLiteral>] Text =
            abstract appendText: text: string -> Text
            abstract copy: unit -> Text
            abstract deleteText: startOffset: Integer * endOffsetInclusive: Integer -> Text
            abstract editAsText: unit -> Text
            abstract findText: searchPattern: string -> RangeElement
            abstract findText: searchPattern: string * from: RangeElement -> RangeElement
            abstract getAttributes: unit -> obj
            abstract getAttributes: offset: Integer -> obj
            abstract getBackgroundColor: unit -> string
            abstract getBackgroundColor: offset: Integer -> string
            abstract getFontFamily: unit -> string
            abstract getFontFamily: offset: Integer -> string
            abstract getFontSize: unit -> Integer
            abstract getFontSize: offset: Integer -> Integer
            abstract getForegroundColor: unit -> string
            abstract getForegroundColor: offset: Integer -> string
            abstract getLinkUrl: unit -> string
            abstract getLinkUrl: offset: Integer -> string
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getText: unit -> string
            abstract getTextAlignment: unit -> TextAlignment
            abstract getTextAlignment: offset: Integer -> TextAlignment
            abstract getTextAttributeIndices: unit -> ResizeArray<Integer>
            abstract getType: unit -> ElementType
            abstract insertText: offset: Integer * text: string -> Text
            abstract isAtDocumentEnd: unit -> bool
            abstract isBold: unit -> bool
            abstract isBold: offset: Integer -> bool
            abstract isItalic: unit -> bool
            abstract isItalic: offset: Integer -> bool
            abstract isStrikethrough: unit -> bool
            abstract isStrikethrough: offset: Integer -> bool
            abstract isUnderline: unit -> bool
            abstract isUnderline: offset: Integer -> bool
            abstract merge: unit -> Text
            abstract removeFromParent: unit -> Text
            abstract replaceText: searchPattern: string * replacement: string -> Element
            abstract setAttributes: startOffset: Integer * endOffsetInclusive: Integer * attributes: obj -> Text
            abstract setAttributes: attributes: obj -> Text
            abstract setBackgroundColor: startOffset: Integer * endOffsetInclusive: Integer * color: string -> Text
            abstract setBackgroundColor: color: string -> Text
            abstract setBold: bold: bool -> Text
            abstract setBold: startOffset: Integer * endOffsetInclusive: Integer * bold: bool -> Text
            abstract setFontFamily: startOffset: Integer * endOffsetInclusive: Integer * fontFamilyName: string -> Text
            abstract setFontFamily: fontFamilyName: string -> Text
            abstract setFontSize: size: Integer -> Text
            abstract setFontSize: startOffset: Integer * endOffsetInclusive: Integer * size: Integer -> Text
            abstract setForegroundColor: startOffset: Integer * endOffsetInclusive: Integer * color: string -> Text
            abstract setForegroundColor: color: string -> Text
            abstract setItalic: italic: bool -> Text
            abstract setItalic: startOffset: Integer * endOffsetInclusive: Integer * italic: bool -> Text
            abstract setLinkUrl: startOffset: Integer * endOffsetInclusive: Integer * url: string -> Text
            abstract setLinkUrl: url: string -> Text
            abstract setStrikethrough: strikethrough: bool -> Text
            abstract setStrikethrough: startOffset: Integer * endOffsetInclusive: Integer * strikethrough: bool -> Text
            abstract setText: text: string -> Text
            abstract setTextAlignment: startOffset: Integer * endOffsetInclusive: Integer * textAlignment: TextAlignment -> Text
            abstract setTextAlignment: textAlignment: TextAlignment -> Text
            abstract setUnderline: underline: bool -> Text
            abstract setUnderline: startOffset: Integer * endOffsetInclusive: Integer * underline: bool -> Text

        and TextAlignment =
            | NORMAL = 0
            | SUPERSCRIPT = 1
            | SUBSCRIPT = 2

        and [<AllowNullLiteral>] UnsupportedElement =
            abstract copy: unit -> UnsupportedElement
            abstract getAttributes: unit -> obj
            abstract getNextSibling: unit -> Element
            abstract getParent: unit -> ContainerElement
            abstract getPreviousSibling: unit -> Element
            abstract getType: unit -> ElementType
            abstract isAtDocumentEnd: unit -> bool
            abstract merge: unit -> UnsupportedElement
            abstract removeFromParent: unit -> UnsupportedElement
            abstract setAttributes: attributes: obj -> UnsupportedElement

        and VerticalAlignment =
            | BOTTOM = 0
            | CENTER = 1
            | TOP = 2

//type [<Erase>]Globals =
//    [<Global>] static member DocumentApp with get(): GoogleAppsScript.Document.DocumentApp = jsNative and set(v: GoogleAppsScript.Document.DocumentApp): unit = jsNative

