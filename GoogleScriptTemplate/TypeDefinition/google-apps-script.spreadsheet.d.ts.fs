namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Spreadsheet =
        type [<AllowNullLiteral>] ContainerInfo =
            abstract getAnchorColumn: unit -> Integer
            abstract getAnchorRow: unit -> Integer
            abstract getOffsetX: unit -> Integer
            abstract getOffsetY: unit -> Integer

        and [<AllowNullLiteral>] DataValidation =
            abstract copy: unit -> DataValidationBuilder
            abstract getAllowInvalid: unit -> bool
            abstract getCriteriaType: unit -> DataValidationCriteria
            abstract getCriteriaValues: unit -> ResizeArray<obj>
            abstract getHelpText: unit -> string

        and [<AllowNullLiteral>] DataValidationBuilder =
            abstract build: unit -> DataValidation
            abstract copy: unit -> DataValidationBuilder
            abstract getAllowInvalid: unit -> bool
            abstract getCriteriaType: unit -> DataValidationCriteria
            abstract getCriteriaValues: unit -> ResizeArray<obj>
            abstract getHelpText: unit -> string
            abstract requireDate: unit -> DataValidationBuilder
            abstract requireDateAfter: date: DateTime -> DataValidationBuilder
            abstract requireDateBefore: date: DateTime -> DataValidationBuilder
            abstract requireDateBetween: start: DateTime * ``end``: DateTime -> DataValidationBuilder
            abstract requireDateEqualTo: date: DateTime -> DataValidationBuilder
            abstract requireDateNotBetween: start: DateTime * ``end``: DateTime -> DataValidationBuilder
            abstract requireDateOnOrAfter: date: DateTime -> DataValidationBuilder
            abstract requireDateOnOrBefore: date: DateTime -> DataValidationBuilder
            abstract requireFormulaSatisfied: formula: string -> DataValidationBuilder
            abstract requireNumberBetween: start: float * ``end``: float -> DataValidationBuilder
            abstract requireNumberEqualTo: number: float -> DataValidationBuilder
            abstract requireNumberGreaterThan: number: float -> DataValidationBuilder
            abstract requireNumberGreaterThanOrEqualTo: number: float -> DataValidationBuilder
            abstract requireNumberLessThan: number: float -> DataValidationBuilder
            abstract requireNumberLessThanOrEqualTo: number: float -> DataValidationBuilder
            abstract requireNumberNotBetween: start: float * ``end``: float -> DataValidationBuilder
            abstract requireNumberNotEqualTo: number: float -> DataValidationBuilder
            abstract requireTextContains: text: string -> DataValidationBuilder
            abstract requireTextDoesNotContain: text: string -> DataValidationBuilder
            abstract requireTextEqualTo: text: string -> DataValidationBuilder
            abstract requireTextIsEmail: unit -> DataValidationBuilder
            abstract requireTextIsUrl: unit -> DataValidationBuilder
            abstract requireValueInList: values: ResizeArray<string> -> DataValidationBuilder
            abstract requireValueInList: values: ResizeArray<string> * showDropdown: bool -> DataValidationBuilder
            abstract requireValueInRange: range: Range -> DataValidationBuilder
            abstract requireValueInRange: range: Range * showDropdown: bool -> DataValidationBuilder
            abstract setAllowInvalid: allowInvalidData: bool -> DataValidationBuilder
            abstract setHelpText: helpText: string -> DataValidationBuilder
            abstract withCriteria: criteria: DataValidationCriteria * args: ResizeArray<obj> -> DataValidationBuilder

        and DataValidationCriteria =
            | DATE_AFTER = 0
            | DATE_BEFORE = 1
            | DATE_BETWEEN = 2
            | DATE_EQUAL_TO = 3
            | DATE_IS_VALID_DATE = 4
            | DATE_NOT_BETWEEN = 5
            | DATE_ON_OR_AFTER = 6
            | DATE_ON_OR_BEFORE = 7
            | NUMBER_BETWEEN = 8
            | NUMBER_EQUAL_TO = 9
            | NUMBER_GREATER_THAN = 10
            | NUMBER_GREATER_THAN_OR_EQUAL_TO = 11
            | NUMBER_LESS_THAN = 12
            | NUMBER_LESS_THAN_OR_EQUAL_TO = 13
            | NUMBER_NOT_BETWEEN = 14
            | NUMBER_NOT_EQUAL_TO = 15
            | TEXT_CONTAINS = 16
            | TEXT_DOES_NOT_CONTAIN = 17
            | TEXT_EQUAL_TO = 18
            | TEXT_IS_VALID_EMAIL = 19
            | TEXT_IS_VALID_URL = 20
            | VALUE_IN_LIST = 21
            | VALUE_IN_RANGE = 22
            | CUSTOM_FORMULA = 23

        and [<AllowNullLiteral>] EmbeddedAreaChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedAreaChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedAreaChartBuilder
            abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedAreaChartBuilder
            abstract setLegendPosition: position: Charts.Position -> EmbeddedAreaChartBuilder
            abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract setOption: option: string * value: obj -> EmbeddedChartBuilder
            abstract setPointStyle: style: Charts.PointStyle -> EmbeddedAreaChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedAreaChartBuilder
            abstract setStacked: unit -> EmbeddedAreaChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedAreaChartBuilder
            abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedAreaChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedAreaChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract useLogScale: unit -> EmbeddedAreaChartBuilder

        and [<AllowNullLiteral>] EmbeddedBarChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedBarChartBuilder
            abstract reverseDirection: unit -> EmbeddedBarChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedBarChartBuilder
            abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedBarChartBuilder
            abstract setLegendPosition: position: Charts.Position -> EmbeddedBarChartBuilder
            abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract setOption: option: string * value: obj -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedBarChartBuilder
            abstract setStacked: unit -> EmbeddedBarChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedBarChartBuilder
            abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedBarChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedBarChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract useLogScale: unit -> EmbeddedBarChartBuilder

        and [<AllowNullLiteral>] EmbeddedChart =
            abstract getAs: contentType: string -> Base.Blob
            abstract getBlob: unit -> Base.Blob
            abstract getContainerInfo: unit -> ContainerInfo
            abstract getId: unit -> string
            abstract getOptions: unit -> Charts.ChartOptions
            abstract getRanges: unit -> ResizeArray<Range>
            abstract getType: unit -> string
            abstract modify: unit -> EmbeddedChartBuilder
            abstract setId: id: string -> Charts.Chart

        and [<AllowNullLiteral>] EmbeddedChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder

        and [<AllowNullLiteral>] EmbeddedColumnChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedColumnChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedColumnChartBuilder
            abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedColumnChartBuilder
            abstract setLegendPosition: position: Charts.Position -> EmbeddedColumnChartBuilder
            abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract setOption: option: string * value: obj -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedColumnChartBuilder
            abstract setStacked: unit -> EmbeddedColumnChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedColumnChartBuilder
            abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedColumnChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedColumnChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract useLogScale: unit -> EmbeddedColumnChartBuilder

        and [<AllowNullLiteral>] EmbeddedLineChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedLineChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedLineChartBuilder
            abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedLineChartBuilder
            abstract setCurveStyle: style: Charts.CurveStyle -> EmbeddedLineChartBuilder
            abstract setLegendPosition: position: Charts.Position -> EmbeddedLineChartBuilder
            abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract setOption: option: string * value: obj -> EmbeddedChartBuilder
            abstract setPointStyle: style: Charts.PointStyle -> EmbeddedLineChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedLineChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedLineChartBuilder
            abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedLineChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedLineChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract useLogScale: unit -> EmbeddedLineChartBuilder

        and [<AllowNullLiteral>] EmbeddedPieChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedPieChartBuilder
            abstract set3D: unit -> EmbeddedPieChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedPieChartBuilder
            abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedPieChartBuilder
            abstract setLegendPosition: position: Charts.Position -> EmbeddedPieChartBuilder
            abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedPieChartBuilder
            abstract setOption: option: string * value: obj -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedPieChartBuilder
            abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedPieChartBuilder

        and [<AllowNullLiteral>] EmbeddedScatterChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedScatterChartBuilder
            abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedScatterChartBuilder
            abstract setLegendPosition: position: Charts.Position -> EmbeddedScatterChartBuilder
            abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setOption: option: string * value: obj -> EmbeddedChartBuilder
            abstract setPointStyle: style: Charts.PointStyle -> EmbeddedScatterChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedScatterChartBuilder
            abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setXAxisLogScale: unit -> EmbeddedScatterChartBuilder
            abstract setXAxisRange: start: float * ``end``: float -> EmbeddedScatterChartBuilder
            abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedScatterChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setYAxisLogScale: unit -> EmbeddedScatterChartBuilder
            abstract setYAxisRange: start: float * ``end``: float -> EmbeddedScatterChartBuilder
            abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedScatterChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder

        and [<AllowNullLiteral>] EmbeddedTableChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract enablePaging: enablePaging: bool -> EmbeddedTableChartBuilder
            abstract enablePaging: pageSize: Integer -> EmbeddedTableChartBuilder
            abstract enablePaging: pageSize: Integer * startPage: Integer -> EmbeddedTableChartBuilder
            abstract enableRtlTable: rtlEnabled: bool -> EmbeddedTableChartBuilder
            abstract enableSorting: enableSorting: bool -> EmbeddedTableChartBuilder
            abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setFirstRowNumber: number: Integer -> EmbeddedTableChartBuilder
            abstract setInitialSortingAscending: column: Integer -> EmbeddedTableChartBuilder
            abstract setInitialSortingDescending: column: Integer -> EmbeddedTableChartBuilder
            abstract setOption: option: string * value: obj -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract showRowNumberColumn: showRowNumber: bool -> EmbeddedTableChartBuilder
            abstract useAlternatingRowStyle: alternate: bool -> EmbeddedTableChartBuilder

        and [<AllowNullLiteral>] PageProtection =
            abstract addUser: email: string -> unit
            abstract getUsers: unit -> ResizeArray<string>
            abstract isProtected: unit -> bool
            abstract removeUser: user: string -> unit
            abstract setProtected: protection: bool -> unit

        and [<AllowNullLiteral>] Protection =
            abstract addEditor: emailAddress: string -> Protection
            abstract addEditor: user: Base.User -> Protection
            abstract addEditors: emailAddresses: ResizeArray<string> -> Protection
            abstract canDomainEdit: unit -> bool
            abstract canEdit: unit -> bool
            abstract getDescription: unit -> string
            abstract getEditors: unit -> ResizeArray<Base.User>
            abstract getProtectionType: unit -> ProtectionType
            abstract getRange: unit -> Range
            abstract getRangeName: unit -> string
            abstract getUnprotectedRanges: unit -> ResizeArray<Range>
            abstract isWarningOnly: unit -> bool
            abstract remove: unit -> unit
            abstract removeEditor: emailAddress: string -> Protection
            abstract removeEditor: user: Base.User -> Protection
            abstract removeEditors: emailAddresses: ResizeArray<string> -> Protection
            abstract setDescription: description: string -> Protection
            abstract setDomainEdit: editable: bool -> Protection
            abstract setRange: range: Range -> Protection
            abstract setRangeName: rangeName: string -> Protection
            abstract setUnprotectedRanges: ranges: ResizeArray<Range> -> Protection
            abstract setWarningOnly: warningOnly: bool -> Protection

        and ProtectionType =
            | RANGE = 0
            | SHEET = 1

        and [<AllowNullLiteral>] Range =
            abstract activate: unit -> Range
            abstract breakApart: unit -> Range
            abstract canEdit: unit -> bool
            abstract clear: unit -> Range
            abstract clear: options: obj -> Range
            abstract clearContent: unit -> Range
            abstract clearDataValidations: unit -> Range
            abstract clearFormat: unit -> Range
            abstract clearNote: unit -> Range
            abstract copyFormatToRange: gridId: Integer * column: Integer * columnEnd: Integer * row: Integer * rowEnd: Integer -> unit
            abstract copyFormatToRange: sheet: Sheet * column: Integer * columnEnd: Integer * row: Integer * rowEnd: Integer -> unit
            abstract copyTo: destination: Range -> unit
            abstract copyTo: destination: Range * options: obj -> unit
            abstract copyValuesToRange: gridId: Integer * column: Integer * columnEnd: Integer * row: Integer * rowEnd: Integer -> unit
            abstract copyValuesToRange: sheet: Sheet * column: Integer * columnEnd: Integer * row: Integer * rowEnd: Integer -> unit
            abstract getA1Notation: unit -> string
            abstract getBackground: unit -> string
            abstract getBackgrounds: unit -> ResizeArray<ResizeArray<string>>
            abstract getCell: row: Integer * column: Integer -> Range
            abstract getColumn: unit -> Integer
            abstract getDataSourceUrl: unit -> string
            abstract getDataTable: unit -> Charts.DataTable
            abstract getDataTable: firstRowIsHeader: bool -> Charts.DataTable
            abstract getDataValidation: unit -> DataValidation
            abstract getDataValidations: unit -> ResizeArray<ResizeArray<DataValidation>>
            abstract getFontColor: unit -> string
            abstract getFontColors: unit -> ResizeArray<ResizeArray<string>>
            abstract getFontFamilies: unit -> ResizeArray<ResizeArray<string>>
            abstract getFontFamily: unit -> string
            abstract getFontLine: unit -> string
            abstract getFontLines: unit -> ResizeArray<ResizeArray<string>>
            abstract getFontSize: unit -> Integer
            abstract getFontSizes: unit -> ResizeArray<ResizeArray<Integer>>
            abstract getFontStyle: unit -> string
            abstract getFontStyles: unit -> ResizeArray<ResizeArray<string>>
            abstract getFontWeight: unit -> string
            abstract getFontWeights: unit -> ResizeArray<ResizeArray<string>>
            abstract getFormula: unit -> string
            abstract getFormulaR1C1: unit -> string
            abstract getFormulas: unit -> ResizeArray<ResizeArray<string>>
            abstract getFormulasR1C1: unit -> ResizeArray<ResizeArray<string>>
            abstract getGridId: unit -> Integer
            abstract getHeight: unit -> Integer
            abstract getHorizontalAlignment: unit -> string
            abstract getHorizontalAlignments: unit -> ResizeArray<ResizeArray<string>>
            abstract getLastColumn: unit -> Integer
            abstract getLastRow: unit -> Integer
            abstract getNote: unit -> string
            abstract getNotes: unit -> ResizeArray<ResizeArray<string>>
            abstract getNumColumns: unit -> Integer
            abstract getNumRows: unit -> Integer
            abstract getNumberFormat: unit -> string
            abstract getNumberFormats: unit -> ResizeArray<ResizeArray<string>>
            abstract getRow: unit -> Integer
            abstract getRowIndex: unit -> Integer
            abstract getSheet: unit -> Sheet
            abstract getValue: unit -> obj
            abstract getValues: unit -> ResizeArray<ResizeArray<obj>>
            abstract getVerticalAlignment: unit -> string
            abstract getVerticalAlignments: unit -> ResizeArray<ResizeArray<string>>
            abstract getWidth: unit -> Integer
            abstract getWrap: unit -> bool
            abstract getWraps: unit -> ResizeArray<ResizeArray<Boolean>>
            abstract isBlank: unit -> bool
            abstract isEndColumnBounded: unit -> bool
            abstract isEndRowBounded: unit -> bool
            abstract isStartColumnBounded: unit -> bool
            abstract isStartRowBounded: unit -> bool
            abstract merge: unit -> Range
            abstract mergeAcross: unit -> Range
            abstract mergeVertically: unit -> Range
            abstract moveTo: target: Range -> unit
            abstract offset: rowOffset: Integer * columnOffset: Integer -> Range
            abstract offset: rowOffset: Integer * columnOffset: Integer * numRows: Integer -> Range
            abstract offset: rowOffset: Integer * columnOffset: Integer * numRows: Integer * numColumns: Integer -> Range
            abstract protect: unit -> Protection
            abstract setBackground: color: string -> Range
            abstract setBackgroundRGB: red: Integer * green: Integer * blue: Integer -> Range
            abstract setBackgrounds: color: ResizeArray<ResizeArray<string>> -> Range
            abstract setBorder: top: bool * left: bool * bottom: bool * right: bool * vertical: bool * horizontal: bool -> Range
            abstract setDataValidation: rule: DataValidation -> Range
            abstract setDataValidations: rules: ResizeArray<ResizeArray<DataValidation>> -> Range
            abstract setFontColor: color: string -> Range
            abstract setFontColors: colors: ResizeArray<ResizeArray<obj>> -> Range
            abstract setFontFamilies: fontFamilies: ResizeArray<ResizeArray<obj>> -> Range
            abstract setFontFamily: fontFamily: string -> Range
            abstract setFontLine: fontLine: string -> Range
            abstract setFontLines: fontLines: ResizeArray<ResizeArray<obj>> -> Range
            abstract setFontSize: size: Integer -> Range
            abstract setFontSizes: sizes: ResizeArray<ResizeArray<obj>> -> Range
            abstract setFontStyle: fontStyle: string -> Range
            abstract setFontStyles: fontStyles: ResizeArray<ResizeArray<obj>> -> Range
            abstract setFontWeight: fontWeight: string -> Range
            abstract setFontWeights: fontWeights: ResizeArray<ResizeArray<obj>> -> Range
            abstract setFormula: formula: string -> Range
            abstract setFormulaR1C1: formula: string -> Range
            abstract setFormulas: formulas: ResizeArray<ResizeArray<string>> -> Range
            abstract setFormulasR1C1: formulas: ResizeArray<ResizeArray<string>> -> Range
            abstract setHorizontalAlignment: alignment: string -> Range
            abstract setHorizontalAlignments: alignments: ResizeArray<ResizeArray<obj>> -> Range
            abstract setNote: note: string -> Range
            abstract setNotes: notes: ResizeArray<ResizeArray<obj>> -> Range
            abstract setNumberFormat: numberFormat: string -> Range
            abstract setNumberFormats: numberFormats: ResizeArray<ResizeArray<obj>> -> Range
            abstract setValue: value: obj -> Range
            abstract setValues: values: ResizeArray<ResizeArray<obj>> -> Range
            abstract setVerticalAlignment: alignment: string -> Range
            abstract setVerticalAlignments: alignments: ResizeArray<ResizeArray<obj>> -> Range
            abstract setWrap: isWrapEnabled: bool -> Range
            abstract setWraps: isWrapEnabled: ResizeArray<ResizeArray<obj>> -> Range
            abstract sort: sortSpecObj: obj -> Range

        and [<AllowNullLiteral>] Sheet =
            abstract activate: unit -> Sheet
            abstract appendRow: rowContents: ResizeArray<obj> -> Sheet
            abstract autoResizeColumn: columnPosition: Integer -> Sheet
            abstract clear: unit -> Sheet
            abstract clear: options: obj -> Sheet
            abstract clearContents: unit -> Sheet
            abstract clearFormats: unit -> Sheet
            abstract clearNotes: unit -> Sheet
            abstract copyTo: spreadsheet: Spreadsheet -> Sheet
            abstract deleteColumn: columnPosition: Integer -> Sheet
            abstract deleteColumns: columnPosition: Integer * howMany: Integer -> unit
            abstract deleteRow: rowPosition: Integer -> Sheet
            abstract deleteRows: rowPosition: Integer * howMany: Integer -> unit
            abstract getActiveCell: unit -> Range
            abstract getActiveRange: unit -> Range
            abstract getCharts: unit -> ResizeArray<EmbeddedChart>
            abstract getColumnWidth: columnPosition: Integer -> Integer
            abstract getDataRange: unit -> Range
            abstract getFrozenColumns: unit -> Integer
            abstract getFrozenRows: unit -> Integer
            abstract getIndex: unit -> Integer
            abstract getLastColumn: unit -> Integer
            abstract getLastRow: unit -> Integer
            abstract getMaxColumns: unit -> Integer
            abstract getMaxRows: unit -> Integer
            abstract getName: unit -> string
            abstract getParent: unit -> Spreadsheet
            abstract getProtections: ``type``: ProtectionType -> ResizeArray<Protection>
            abstract getRange: row: Integer * column: Integer -> Range
            abstract getRange: row: Integer * column: Integer * numRows: Integer -> Range
            abstract getRange: row: Integer * column: Integer * numRows: Integer * numColumns: Integer -> Range
            abstract getRange: a1Notation: string -> Range
            abstract getRowHeight: rowPosition: Integer -> Integer
            abstract getSheetId: unit -> Integer
            abstract getSheetName: unit -> string
            abstract getSheetValues: startRow: Integer * startColumn: Integer * numRows: Integer * numColumns: Integer -> ResizeArray<ResizeArray<obj>>
            abstract hideColumn: column: Range -> unit
            abstract hideColumns: columnIndex: Integer -> unit
            abstract hideColumns: columnIndex: Integer * numColumns: Integer -> unit
            abstract hideRow: row: Range -> unit
            abstract hideRows: rowIndex: Integer -> unit
            abstract hideRows: rowIndex: Integer * numRows: Integer -> unit
            abstract hideSheet: unit -> Sheet
            abstract insertChart: chart: EmbeddedChart -> unit
            abstract insertColumnAfter: afterPosition: Integer -> Sheet
            abstract insertColumnBefore: beforePosition: Integer -> Sheet
            abstract insertColumns: columnIndex: Integer -> unit
            abstract insertColumns: columnIndex: Integer * numColumns: Integer -> unit
            abstract insertColumnsAfter: afterPosition: Integer * howMany: Integer -> Sheet
            abstract insertColumnsBefore: beforePosition: Integer * howMany: Integer -> Sheet
            abstract insertImage: blob: Base.Blob * column: Integer * row: Integer -> unit
            abstract insertImage: blob: Base.Blob * column: Integer * row: Integer * offsetX: Integer * offsetY: Integer -> unit
            abstract insertImage: url: string * column: Integer * row: Integer -> unit
            abstract insertImage: url: string * column: Integer * row: Integer * offsetX: Integer * offsetY: Integer -> unit
            abstract insertRowAfter: afterPosition: Integer -> Sheet
            abstract insertRowBefore: beforePosition: Integer -> Sheet
            abstract insertRows: rowIndex: Integer -> unit
            abstract insertRows: rowIndex: Integer * numRows: Integer -> unit
            abstract insertRowsAfter: afterPosition: Integer * howMany: Integer -> Sheet
            abstract insertRowsBefore: beforePosition: Integer * howMany: Integer -> Sheet
            abstract isSheetHidden: unit -> bool
            abstract newChart: unit -> EmbeddedChartBuilder
            abstract protect: unit -> Protection
            abstract removeChart: chart: EmbeddedChart -> unit
            abstract setActiveRange: range: Range -> Range
            abstract setActiveSelection: range: Range -> Range
            abstract setActiveSelection: a1Notation: string -> Range
            abstract setColumnWidth: columnPosition: Integer * width: Integer -> Sheet
            abstract setFrozenColumns: columns: Integer -> unit
            abstract setFrozenRows: rows: Integer -> unit
            abstract setName: name: string -> Sheet
            abstract setRowHeight: rowPosition: Integer * height: Integer -> Sheet
            abstract showColumns: columnIndex: Integer -> unit
            abstract showColumns: columnIndex: Integer * numColumns: Integer -> unit
            abstract showRows: rowIndex: Integer -> unit
            abstract showRows: rowIndex: Integer * numRows: Integer -> unit
            abstract showSheet: unit -> Sheet
            abstract sort: columnPosition: Integer -> Sheet
            abstract sort: columnPosition: Integer * ascending: bool -> Sheet
            abstract unhideColumn: column: Range -> unit
            abstract unhideRow: row: Range -> unit
            abstract updateChart: chart: EmbeddedChart -> unit
            abstract getSheetProtection: unit -> PageProtection
            abstract setSheetProtection: permissions: PageProtection -> unit

        and [<AllowNullLiteral>] Spreadsheet =
            abstract addEditor: emailAddress: string -> Spreadsheet
            abstract addEditor: user: Base.User -> Spreadsheet
            abstract addEditors: emailAddresses: ResizeArray<string> -> Spreadsheet
            abstract addMenu: name: string * subMenus: ResizeArray<obj> -> unit
            abstract addViewer: emailAddress: string -> Spreadsheet
            abstract addViewer: user: Base.User -> Spreadsheet
            abstract addViewers: emailAddresses: ResizeArray<string> -> Spreadsheet
            abstract appendRow: rowContents: ResizeArray<obj> -> Sheet
            abstract autoResizeColumn: columnPosition: Integer -> Sheet
            abstract copy: name: string -> Spreadsheet
            abstract deleteActiveSheet: unit -> Sheet
            abstract deleteColumn: columnPosition: Integer -> Sheet
            abstract deleteColumns: columnPosition: Integer * howMany: Integer -> unit
            abstract deleteRow: rowPosition: Integer -> Sheet
            abstract deleteRows: rowPosition: Integer * howMany: Integer -> unit
            abstract deleteSheet: sheet: Sheet -> unit
            abstract duplicateActiveSheet: unit -> Sheet
            abstract getActiveCell: unit -> Range
            abstract getActiveRange: unit -> Range
            abstract getActiveSheet: unit -> Sheet
            abstract getAs: contentType: string -> Base.Blob
            abstract getBlob: unit -> Base.Blob
            abstract getColumnWidth: columnPosition: Integer -> Integer
            abstract getDataRange: unit -> Range
            abstract getEditors: unit -> ResizeArray<Base.User>
            abstract getFormUrl: unit -> string
            abstract getFrozenColumns: unit -> Integer
            abstract getFrozenRows: unit -> Integer
            abstract getId: unit -> string
            abstract getLastColumn: unit -> Integer
            abstract getLastRow: unit -> Integer
            abstract getName: unit -> string
            abstract getNumSheets: unit -> Integer
            abstract getOwner: unit -> Base.User
            abstract getProtections: ``type``: ProtectionType -> ResizeArray<Protection>
            abstract getRange: a1Notation: string -> Range
            abstract getRangeByName: name: string -> Range
            abstract getRowHeight: rowPosition: Integer -> Integer
            abstract getSheetByName: name: string -> Sheet
            abstract getSheetId: unit -> Integer
            abstract getSheetName: unit -> string
            abstract getSheetValues: startRow: Integer * startColumn: Integer * numRows: Integer * numColumns: Integer -> ResizeArray<ResizeArray<obj>>
            abstract getSheets: unit -> ResizeArray<Sheet>
            abstract getSpreadsheetLocale: unit -> string
            abstract getSpreadsheetTimeZone: unit -> string
            abstract getUrl: unit -> string
            abstract getViewers: unit -> ResizeArray<Base.User>
            abstract hideColumn: column: Range -> unit
            abstract hideRow: row: Range -> unit
            abstract insertColumnAfter: afterPosition: Integer -> Sheet
            abstract insertColumnBefore: beforePosition: Integer -> Sheet
            abstract insertColumnsAfter: afterPosition: Integer * howMany: Integer -> Sheet
            abstract insertColumnsBefore: beforePosition: Integer * howMany: Integer -> Sheet
            abstract insertImage: blob: Base.Blob * column: Integer * row: Integer -> unit
            abstract insertImage: blob: Base.Blob * column: Integer * row: Integer * offsetX: Integer * offsetY: Integer -> unit
            abstract insertImage: url: string * column: Integer * row: Integer -> unit
            abstract insertImage: url: string * column: Integer * row: Integer * offsetX: Integer * offsetY: Integer -> unit
            abstract insertRowAfter: afterPosition: Integer -> Sheet
            abstract insertRowBefore: beforePosition: Integer -> Sheet
            abstract insertRowsAfter: afterPosition: Integer * howMany: Integer -> Sheet
            abstract insertRowsBefore: beforePosition: Integer * howMany: Integer -> Sheet
            abstract insertSheet: unit -> Sheet
            abstract insertSheet: sheetIndex: Integer -> Sheet
            abstract insertSheet: sheetIndex: Integer * options: obj -> Sheet
            abstract insertSheet: options: obj -> Sheet
            abstract insertSheet: sheetName: string -> Sheet
            abstract insertSheet: sheetName: string * sheetIndex: Integer -> Sheet
            abstract insertSheet: sheetName: string * sheetIndex: Integer * options: obj -> Sheet
            abstract insertSheet: sheetName: string * options: obj -> Sheet
            abstract moveActiveSheet: pos: Integer -> unit
            abstract removeEditor: emailAddress: string -> Spreadsheet
            abstract removeEditor: user: Base.User -> Spreadsheet
            abstract removeMenu: name: string -> unit
            abstract removeNamedRange: name: string -> unit
            abstract removeViewer: emailAddress: string -> Spreadsheet
            abstract removeViewer: user: Base.User -> Spreadsheet
            abstract rename: newName: string -> unit
            abstract renameActiveSheet: newName: string -> unit
            abstract setActiveRange: range: Range -> Range
            abstract setActiveSelection: range: Range -> Range
            abstract setActiveSelection: a1Notation: string -> Range
            abstract setActiveSheet: sheet: Sheet -> Sheet
            abstract setColumnWidth: columnPosition: Integer * width: Integer -> Sheet
            abstract setFrozenColumns: columns: Integer -> unit
            abstract setFrozenRows: rows: Integer -> unit
            abstract setNamedRange: name: string * range: Range -> unit
            abstract setRowHeight: rowPosition: Integer * height: Integer -> Sheet
            abstract setSpreadsheetLocale: locale: string -> unit
            abstract setSpreadsheetTimeZone: timezone: string -> unit
            abstract show: userInterface: obj -> unit
            abstract sort: columnPosition: Integer -> Sheet
            abstract sort: columnPosition: Integer * ascending: bool -> Sheet
            abstract toast: msg: string -> unit
            abstract toast: msg: string * title: string -> unit
            abstract toast: msg: string * title: string * timeoutSeconds: float -> unit
            abstract unhideColumn: column: Range -> unit
            abstract unhideRow: row: Range -> unit
            abstract updateMenu: name: string * subMenus: ResizeArray<obj> -> unit
            abstract getSheetProtection: unit -> PageProtection
            abstract isAnonymousView: unit -> bool
            abstract isAnonymousWrite: unit -> bool
            abstract setAnonymousAccess: anonymousReadAllowed: bool * anonymousWriteAllowed: bool -> unit
            abstract setSheetProtection: permissions: PageProtection -> unit

        and [<AllowNullLiteral>] SpreadsheetApp =
            abstract DataValidationCriteria: DataValidationCriteria with get, set
            abstract ProtectionType: ProtectionType with get, set
            abstract create: name: string -> Spreadsheet
            abstract create: name: string * rows: Integer * columns: Integer -> Spreadsheet
            abstract flush: unit -> unit
            abstract getActive: unit -> Spreadsheet
            abstract getActiveRange: unit -> Range
            abstract getActiveSheet: unit -> Sheet
            abstract getActiveSpreadsheet: unit -> Spreadsheet
            abstract getUi: unit -> Base.Ui
            abstract newDataValidation: unit -> DataValidationBuilder
            abstract ``open``: file: Drive.File -> Spreadsheet
            abstract openById: id: string -> Spreadsheet
            abstract openByUrl: url: string -> Spreadsheet
            abstract setActiveRange: range: Range -> Range
            abstract setActiveSheet: sheet: Sheet -> Sheet
            abstract setActiveSpreadsheet: newActiveSpreadsheet: Spreadsheet -> unit

//type [<Erase>]Globals =
//    [<Global>] static member SpreadsheetApp with get(): GoogleAppsScript.Spreadsheet.SpreadsheetApp = jsNative and set(v: GoogleAppsScript.Spreadsheet.SpreadsheetApp): unit = jsNative

