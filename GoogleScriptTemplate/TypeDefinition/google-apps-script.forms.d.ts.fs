namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Forms =
        type Alignment =
            | LEFT = 0
            | CENTER = 1
            | RIGHT = 2

        and [<AllowNullLiteral>] CheckboxItem =
            abstract createChoice: value: string -> Choice
            abstract createResponse: responses: ResizeArray<string> -> ItemResponse
            abstract duplicate: unit -> CheckboxItem
            abstract getChoices: unit -> ResizeArray<Choice>
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract hasOtherOption: unit -> bool
            abstract isRequired: unit -> bool
            abstract setChoiceValues: values: ResizeArray<string> -> CheckboxItem
            abstract setChoices: choices: ResizeArray<Choice> -> CheckboxItem
            abstract setHelpText: text: string -> CheckboxItem
            abstract setRequired: enabled: bool -> CheckboxItem
            abstract setTitle: title: string -> CheckboxItem
            abstract showOtherOption: enabled: bool -> CheckboxItem

        and [<AllowNullLiteral>] Choice =
            abstract getGotoPage: unit -> PageBreakItem
            abstract getPageNavigationType: unit -> PageNavigationType
            abstract getValue: unit -> string

        and [<AllowNullLiteral>] DateItem =
            abstract createResponse: response: DateTime -> ItemResponse
            abstract duplicate: unit -> DateItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract includesYear: unit -> bool
            abstract isRequired: unit -> bool
            abstract setHelpText: text: string -> DateItem
            abstract setIncludesYear: enableYear: bool -> DateItem
            abstract setRequired: enabled: bool -> DateItem
            abstract setTitle: title: string -> DateItem

        and [<AllowNullLiteral>] DateTimeItem =
            abstract createResponse: response: DateTime -> ItemResponse
            abstract duplicate: unit -> DateTimeItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract includesYear: unit -> bool
            abstract isRequired: unit -> bool
            abstract setHelpText: text: string -> DateTimeItem
            abstract setIncludesYear: enableYear: bool -> DateTimeItem
            abstract setRequired: enabled: bool -> DateTimeItem
            abstract setTitle: title: string -> DateTimeItem

        and DestinationType =
            | SPREADSHEET = 0

        and [<AllowNullLiteral>] DurationItem =
            abstract createResponse: hours: Integer * minutes: Integer * seconds: Integer -> ItemResponse
            abstract duplicate: unit -> DurationItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract isRequired: unit -> bool
            abstract setHelpText: text: string -> DurationItem
            abstract setRequired: enabled: bool -> DurationItem
            abstract setTitle: title: string -> DurationItem

        and [<AllowNullLiteral>] Form =
            abstract addCheckboxItem: unit -> CheckboxItem
            abstract addDateItem: unit -> DateItem
            abstract addDateTimeItem: unit -> DateTimeItem
            abstract addDurationItem: unit -> DurationItem
            abstract addEditor: emailAddress: string -> Form
            abstract addEditor: user: Base.User -> Form
            abstract addEditors: emailAddresses: ResizeArray<string> -> Form
            abstract addGridItem: unit -> GridItem
            abstract addImageItem: unit -> ImageItem
            abstract addListItem: unit -> ListItem
            abstract addMultipleChoiceItem: unit -> MultipleChoiceItem
            abstract addPageBreakItem: unit -> PageBreakItem
            abstract addParagraphTextItem: unit -> ParagraphTextItem
            abstract addScaleItem: unit -> ScaleItem
            abstract addSectionHeaderItem: unit -> SectionHeaderItem
            abstract addTextItem: unit -> TextItem
            abstract addTimeItem: unit -> TimeItem
            abstract addVideoItem: unit -> VideoItem
            abstract canEditResponse: unit -> bool
            abstract collectsEmail: unit -> bool
            abstract createResponse: unit -> FormResponse
            abstract deleteAllResponses: unit -> Form
            abstract deleteItem: index: Integer -> unit
            abstract deleteItem: item: Item -> unit
            abstract getConfirmationMessage: unit -> string
            abstract getCustomClosedFormMessage: unit -> string
            abstract getDescription: unit -> string
            abstract getDestinationId: unit -> string
            abstract getDestinationType: unit -> DestinationType
            abstract getEditUrl: unit -> string
            abstract getEditors: unit -> ResizeArray<Base.User>
            abstract getId: unit -> string
            abstract getItemById: id: Integer -> Item
            abstract getItems: unit -> ResizeArray<Item>
            abstract getItems: itemType: ItemType -> ResizeArray<Item>
            abstract getPublishedUrl: unit -> string
            abstract getResponse: responseId: string -> FormResponse
            abstract getResponses: unit -> ResizeArray<FormResponse>
            abstract getResponses: timestamp: DateTime -> ResizeArray<FormResponse>
            abstract getShuffleQuestions: unit -> bool
            abstract getSummaryUrl: unit -> string
            abstract getTitle: unit -> string
            abstract hasLimitOneResponsePerUser: unit -> bool
            abstract hasProgressBar: unit -> bool
            abstract hasRespondAgainLink: unit -> bool
            abstract isAcceptingResponses: unit -> bool
            abstract isPublishingSummary: unit -> bool
            abstract moveItem: from: Integer * ``to``: Integer -> Item
            abstract moveItem: item: Item * toIndex: Integer -> Item
            abstract removeDestination: unit -> Form
            abstract removeEditor: emailAddress: string -> Form
            abstract removeEditor: user: Base.User -> Form
            abstract requiresLogin: unit -> bool
            abstract setAcceptingResponses: enabled: bool -> Form
            abstract setAllowResponseEdits: enabled: bool -> Form
            abstract setCollectEmail: collect: bool -> Form
            abstract setConfirmationMessage: message: string -> Form
            abstract setCustomClosedFormMessage: message: string -> Form
            abstract setDescription: description: string -> Form
            abstract setDestination: ``type``: DestinationType * id: string -> Form
            abstract setLimitOneResponsePerUser: enabled: bool -> Form
            abstract setProgressBar: enabled: bool -> Form
            abstract setPublishingSummary: enabled: bool -> Form
            abstract setRequireLogin: requireLogin: bool -> Form
            abstract setShowLinkToRespondAgain: enabled: bool -> Form
            abstract setShuffleQuestions: shuffle: bool -> Form
            abstract setTitle: title: string -> Form
            abstract shortenFormUrl: url: string -> string

        and [<AllowNullLiteral>] FormApp =
            abstract Alignment: Alignment with get, set
            abstract DestinationType: DestinationType with get, set
            abstract ItemType: ItemType with get, set
            abstract PageNavigationType: PageNavigationType with get, set
            abstract create: title: string -> Form
            abstract getActiveForm: unit -> Form
            abstract getUi: unit -> Base.Ui
            abstract openById: id: string -> Form
            abstract openByUrl: url: string -> Form

        and [<AllowNullLiteral>] FormResponse =
            abstract getEditResponseUrl: unit -> string
            abstract getId: unit -> string
            abstract getItemResponses: unit -> ResizeArray<ItemResponse>
            abstract getRespondentEmail: unit -> string
            abstract getResponseForItem: item: Item -> ItemResponse
            abstract getTimestamp: unit -> DateTime
            abstract submit: unit -> FormResponse
            abstract toPrefilledUrl: unit -> string
            abstract withItemResponse: response: ItemResponse -> FormResponse

        and [<AllowNullLiteral>] GridItem =
            abstract createResponse: responses: ResizeArray<string> -> ItemResponse
            abstract duplicate: unit -> GridItem
            abstract getColumns: unit -> ResizeArray<string>
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getRows: unit -> ResizeArray<string>
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract isRequired: unit -> bool
            abstract setColumns: columns: ResizeArray<string> -> GridItem
            abstract setHelpText: text: string -> GridItem
            abstract setRequired: enabled: bool -> GridItem
            abstract setRows: rows: ResizeArray<string> -> GridItem
            abstract setTitle: title: string -> GridItem

        and [<AllowNullLiteral>] ImageItem =
            abstract duplicate: unit -> ImageItem
            abstract getAlignment: unit -> Alignment
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getImage: unit -> Base.Blob
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract getWidth: unit -> Integer
            abstract setAlignment: alignment: Alignment -> ImageItem
            abstract setHelpText: text: string -> ImageItem
            abstract setImage: image: Base.BlobSource -> ImageItem
            abstract setTitle: title: string -> ImageItem
            abstract setWidth: width: Integer -> ImageItem

        and [<AllowNullLiteral>] Item =
            abstract asCheckboxItem: unit -> CheckboxItem
            abstract asDateItem: unit -> DateItem
            abstract asDateTimeItem: unit -> DateTimeItem
            abstract asDurationItem: unit -> DurationItem
            abstract asGridItem: unit -> GridItem
            abstract asImageItem: unit -> ImageItem
            abstract asListItem: unit -> ListItem
            abstract asMultipleChoiceItem: unit -> MultipleChoiceItem
            abstract asPageBreakItem: unit -> PageBreakItem
            abstract asParagraphTextItem: unit -> ParagraphTextItem
            abstract asScaleItem: unit -> ScaleItem
            abstract asSectionHeaderItem: unit -> SectionHeaderItem
            abstract asTextItem: unit -> TextItem
            abstract asTimeItem: unit -> TimeItem
            abstract asVideoItem: unit -> VideoItem
            abstract duplicate: unit -> Item
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract setHelpText: text: string -> Item
            abstract setTitle: title: string -> Item

        and [<AllowNullLiteral>] ItemResponse =
            abstract getItem: unit -> Item
            abstract getResponse: unit -> obj

        and ItemType =
            | CHECKBOX = 0
            | DATE = 1
            | DATETIME = 2
            | DURATION = 3
            | GRID = 4
            | IMAGE = 5
            | LIST = 6
            | MULTIPLE_CHOICE = 7
            | PAGE_BREAK = 8
            | PARAGRAPH_TEXT = 9
            | SCALE = 10
            | SECTION_HEADER = 11
            | TEXT = 12
            | TIME = 13

        and [<AllowNullLiteral>] ListItem =
            abstract createChoice: value: string -> Choice
            abstract createChoice: value: string * navigationItem: PageBreakItem -> Choice
            abstract createChoice: value: string * navigationType: PageNavigationType -> Choice
            abstract createResponse: response: string -> ItemResponse
            abstract duplicate: unit -> ListItem
            abstract getChoices: unit -> ResizeArray<Choice>
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract isRequired: unit -> bool
            abstract setChoiceValues: values: ResizeArray<string> -> ListItem
            abstract setChoices: choices: ResizeArray<Choice> -> ListItem
            abstract setHelpText: text: string -> ListItem
            abstract setRequired: enabled: bool -> ListItem
            abstract setTitle: title: string -> ListItem

        and [<AllowNullLiteral>] MultipleChoiceItem =
            abstract createChoice: value: string -> Choice
            abstract createChoice: value: string * navigationItem: PageBreakItem -> Choice
            abstract createChoice: value: string * navigationType: PageNavigationType -> Choice
            abstract createResponse: response: string -> ItemResponse
            abstract duplicate: unit -> MultipleChoiceItem
            abstract getChoices: unit -> ResizeArray<Choice>
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract hasOtherOption: unit -> bool
            abstract isRequired: unit -> bool
            abstract setChoiceValues: values: ResizeArray<string> -> MultipleChoiceItem
            abstract setChoices: choices: ResizeArray<Choice> -> MultipleChoiceItem
            abstract setHelpText: text: string -> MultipleChoiceItem
            abstract setRequired: enabled: bool -> MultipleChoiceItem
            abstract setTitle: title: string -> MultipleChoiceItem
            abstract showOtherOption: enabled: bool -> MultipleChoiceItem

        and [<AllowNullLiteral>] PageBreakItem =
            abstract duplicate: unit -> PageBreakItem
            abstract getGoToPage: unit -> PageBreakItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getPageNavigationType: unit -> PageNavigationType
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract setGoToPage: goToPageItem: PageBreakItem -> PageBreakItem
            abstract setGoToPage: navigationType: PageNavigationType -> PageBreakItem
            abstract setHelpText: text: string -> PageBreakItem
            abstract setTitle: title: string -> PageBreakItem

        and PageNavigationType =
            | CONTINUE = 0
            | GO_TO_PAGE = 1
            | RESTART = 2
            | SUBMIT = 3

        and [<AllowNullLiteral>] ParagraphTextItem =
            abstract createResponse: response: string -> ItemResponse
            abstract duplicate: unit -> ParagraphTextItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract isRequired: unit -> bool
            abstract setHelpText: text: string -> ParagraphTextItem
            abstract setRequired: enabled: bool -> ParagraphTextItem
            abstract setTitle: title: string -> ParagraphTextItem

        and [<AllowNullLiteral>] ScaleItem =
            abstract createResponse: response: Integer -> ItemResponse
            abstract duplicate: unit -> ScaleItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getLeftLabel: unit -> string
            abstract getLowerBound: unit -> Integer
            abstract getRightLabel: unit -> string
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract getUpperBound: unit -> Integer
            abstract isRequired: unit -> bool
            abstract setBounds: lower: Integer * upper: Integer -> ScaleItem
            abstract setHelpText: text: string -> ScaleItem
            abstract setLabels: lower: string * upper: string -> ScaleItem
            abstract setRequired: enabled: bool -> ScaleItem
            abstract setTitle: title: string -> ScaleItem

        and [<AllowNullLiteral>] SectionHeaderItem =
            abstract duplicate: unit -> SectionHeaderItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract setHelpText: text: string -> SectionHeaderItem
            abstract setTitle: title: string -> SectionHeaderItem

        and [<AllowNullLiteral>] TextItem =
            abstract createResponse: response: string -> ItemResponse
            abstract duplicate: unit -> TextItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract isRequired: unit -> bool
            abstract setHelpText: text: string -> TextItem
            abstract setRequired: enabled: bool -> TextItem
            abstract setTitle: title: string -> TextItem

        and [<AllowNullLiteral>] TimeItem =
            abstract createResponse: hour: Integer * minute: Integer -> ItemResponse
            abstract duplicate: unit -> TimeItem
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract isRequired: unit -> bool
            abstract setHelpText: text: string -> TimeItem
            abstract setRequired: enabled: bool -> TimeItem
            abstract setTitle: title: string -> TimeItem

        and [<AllowNullLiteral>] VideoItem =
            abstract duplicate: unit -> VideoItem
            abstract getAlignment: unit -> Alignment
            abstract getHelpText: unit -> string
            abstract getId: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getTitle: unit -> string
            abstract getType: unit -> ItemType
            abstract getWidth: unit -> Integer
            abstract setAlignment: alignment: Alignment -> VideoItem
            abstract setHelpText: text: string -> VideoItem
            abstract setTitle: title: string -> VideoItem
            abstract setVideoUrl: youtubeUrl: string -> VideoItem
            abstract setWidth: width: Integer -> VideoItem

//type [<Erase>]Globals =
//    [<Global>] static member FormApp with get(): GoogleAppsScript.Forms.FormApp = jsNative and set(v: GoogleAppsScript.Forms.FormApp): unit = jsNative

