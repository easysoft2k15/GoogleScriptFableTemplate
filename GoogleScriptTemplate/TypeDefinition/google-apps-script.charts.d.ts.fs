namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Charts =
        type [<AllowNullLiteral>] AreaChartBuilder =
            abstract build: unit -> Chart
            abstract reverseCategories: unit -> AreaChartBuilder
            abstract setBackgroundColor: cssValue: string -> AreaChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> AreaChartBuilder
            abstract setDataSourceUrl: url: string -> AreaChartBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> AreaChartBuilder
            abstract setDataTable: table: DataTableSource -> AreaChartBuilder
            abstract setDataViewDefinition: dataViewDefinition: DataViewDefinition -> AreaChartBuilder
            abstract setDimensions: width: Integer * height: Integer -> AreaChartBuilder
            abstract setLegendPosition: position: Position -> AreaChartBuilder
            abstract setLegendTextStyle: textStyle: TextStyle -> AreaChartBuilder
            abstract setOption: option: string * value: obj -> AreaChartBuilder
            abstract setPointStyle: style: PointStyle -> AreaChartBuilder
            abstract setRange: start: float * ``end``: float -> AreaChartBuilder
            abstract setStacked: unit -> AreaChartBuilder
            abstract setTitle: chartTitle: string -> AreaChartBuilder
            abstract setTitleTextStyle: textStyle: TextStyle -> AreaChartBuilder
            abstract setXAxisTextStyle: textStyle: TextStyle -> AreaChartBuilder
            abstract setXAxisTitle: title: string -> AreaChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: TextStyle -> AreaChartBuilder
            abstract setYAxisTextStyle: textStyle: TextStyle -> AreaChartBuilder
            abstract setYAxisTitle: title: string -> AreaChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: TextStyle -> AreaChartBuilder
            abstract useLogScale: unit -> AreaChartBuilder

        and [<AllowNullLiteral>] BarChartBuilder =
            abstract build: unit -> Chart
            abstract reverseCategories: unit -> BarChartBuilder
            abstract reverseDirection: unit -> BarChartBuilder
            abstract setBackgroundColor: cssValue: string -> BarChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> BarChartBuilder
            abstract setDataSourceUrl: url: string -> BarChartBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> BarChartBuilder
            abstract setDataTable: table: DataTableSource -> BarChartBuilder
            abstract setDataViewDefinition: dataViewDefinition: DataViewDefinition -> BarChartBuilder
            abstract setDimensions: width: Integer * height: Integer -> BarChartBuilder
            abstract setLegendPosition: position: Position -> BarChartBuilder
            abstract setLegendTextStyle: textStyle: TextStyle -> BarChartBuilder
            abstract setOption: option: string * value: obj -> BarChartBuilder
            abstract setRange: start: float * ``end``: float -> BarChartBuilder
            abstract setStacked: unit -> BarChartBuilder
            abstract setTitle: chartTitle: string -> BarChartBuilder
            abstract setTitleTextStyle: textStyle: TextStyle -> BarChartBuilder
            abstract setXAxisTextStyle: textStyle: TextStyle -> BarChartBuilder
            abstract setXAxisTitle: title: string -> BarChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: TextStyle -> BarChartBuilder
            abstract setYAxisTextStyle: textStyle: TextStyle -> BarChartBuilder
            abstract setYAxisTitle: title: string -> BarChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: TextStyle -> BarChartBuilder
            abstract useLogScale: unit -> BarChartBuilder

        and [<AllowNullLiteral>] CategoryFilterBuilder =
            abstract build: unit -> Control
            abstract setAllowMultiple: allowMultiple: bool -> CategoryFilterBuilder
            abstract setAllowNone: allowNone: bool -> CategoryFilterBuilder
            abstract setAllowTyping: allowTyping: bool -> CategoryFilterBuilder
            abstract setCaption: caption: string -> CategoryFilterBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> CategoryFilterBuilder
            abstract setDataTable: table: DataTableSource -> CategoryFilterBuilder
            abstract setFilterColumnIndex: columnIndex: Integer -> CategoryFilterBuilder
            abstract setFilterColumnLabel: columnLabel: string -> CategoryFilterBuilder
            abstract setLabel: label: string -> CategoryFilterBuilder
            abstract setLabelSeparator: labelSeparator: string -> CategoryFilterBuilder
            abstract setLabelStacking: orientation: Orientation -> CategoryFilterBuilder
            abstract setSelectedValuesLayout: layout: PickerValuesLayout -> CategoryFilterBuilder
            abstract setSortValues: sortValues: bool -> CategoryFilterBuilder
            abstract setValues: values: ResizeArray<string> -> CategoryFilterBuilder

        and [<AllowNullLiteral>] Chart =
            abstract getAs: contentType: string -> Base.Blob
            abstract getBlob: unit -> Base.Blob
            abstract getId: unit -> string
            abstract getOptions: unit -> ChartOptions
            abstract getType: unit -> string
            abstract setId: id: string -> Chart

        and [<AllowNullLiteral>] ChartOptions =
            abstract get: option: string -> obj

        and ChartType =
            | AREA = 0
            | BAR = 1
            | COLUMN = 2
            | LINE = 3
            | PIE = 4
            | SCATTER = 5
            | TABLE = 6

        and [<AllowNullLiteral>] Charts =
            abstract ChartType: ChartType with get, set
            abstract ColumnType: ColumnType with get, set
            abstract CurveStyle: CurveStyle with get, set
            abstract MatchType: MatchType with get, set
            abstract Orientation: Orientation with get, set
            abstract PickerValuesLayout: PickerValuesLayout with get, set
            abstract PointStyle: PointStyle with get, set
            abstract Position: Position with get, set
            abstract newAreaChart: unit -> AreaChartBuilder
            abstract newBarChart: unit -> BarChartBuilder
            abstract newCategoryFilter: unit -> CategoryFilterBuilder
            abstract newColumnChart: unit -> ColumnChartBuilder
            abstract newDashboardPanel: unit -> DashboardPanelBuilder
            abstract newDataTable: unit -> DataTableBuilder
            abstract newDataViewDefinition: unit -> DataViewDefinitionBuilder
            abstract newLineChart: unit -> LineChartBuilder
            abstract newNumberRangeFilter: unit -> NumberRangeFilterBuilder
            abstract newPieChart: unit -> PieChartBuilder
            abstract newScatterChart: unit -> ScatterChartBuilder
            abstract newStringFilter: unit -> StringFilterBuilder
            abstract newTableChart: unit -> TableChartBuilder
            abstract newTextStyle: unit -> TextStyleBuilder

        and [<AllowNullLiteral>] ColumnChartBuilder =
            abstract build: unit -> Chart
            abstract reverseCategories: unit -> ColumnChartBuilder
            abstract setBackgroundColor: cssValue: string -> ColumnChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> ColumnChartBuilder
            abstract setDataSourceUrl: url: string -> ColumnChartBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> ColumnChartBuilder
            abstract setDataTable: table: DataTableSource -> ColumnChartBuilder
            abstract setDataViewDefinition: dataViewDefinition: DataViewDefinition -> ColumnChartBuilder
            abstract setDimensions: width: Integer * height: Integer -> ColumnChartBuilder
            abstract setLegendPosition: position: Position -> ColumnChartBuilder
            abstract setLegendTextStyle: textStyle: TextStyle -> ColumnChartBuilder
            abstract setOption: option: string * value: obj -> ColumnChartBuilder
            abstract setRange: start: float * ``end``: float -> ColumnChartBuilder
            abstract setStacked: unit -> ColumnChartBuilder
            abstract setTitle: chartTitle: string -> ColumnChartBuilder
            abstract setTitleTextStyle: textStyle: TextStyle -> ColumnChartBuilder
            abstract setXAxisTextStyle: textStyle: TextStyle -> ColumnChartBuilder
            abstract setXAxisTitle: title: string -> ColumnChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: TextStyle -> ColumnChartBuilder
            abstract setYAxisTextStyle: textStyle: TextStyle -> ColumnChartBuilder
            abstract setYAxisTitle: title: string -> ColumnChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: TextStyle -> ColumnChartBuilder
            abstract useLogScale: unit -> ColumnChartBuilder

        and ColumnType =
            | DATE = 0
            | NUMBER = 1
            | STRING = 2

        and [<AllowNullLiteral>] Control =
            abstract getId: unit -> string
            abstract getType: unit -> string
            abstract setId: id: string -> Control

        and CurveStyle =
            | NORMAL = 0
            | SMOOTH = 1

        and [<AllowNullLiteral>] DashboardPanel =
            abstract add: widget: UI.Widget -> DashboardPanel
            abstract getId: unit -> string
            abstract getType: unit -> string
            abstract setId: id: string -> DashboardPanel

        and [<AllowNullLiteral>] DashboardPanelBuilder =
            abstract bind: control: Control * chart: Chart * controls: ResizeArray<Control> * charts: ResizeArray<Chart> -> DashboardPanelBuilder
            abstract build: unit -> DashboardPanel
            abstract setDataTable: tableBuilder: DataTableBuilder -> DashboardPanelBuilder
            abstract setDataTable: source: DataTableSource -> DashboardPanelBuilder

        and [<AllowNullLiteral>] DataTable =
            interface end

        and [<AllowNullLiteral>] DataTableBuilder =
            abstract addColumn: ``type``: ColumnType * label: string -> DataTableBuilder
            abstract addRow: values: ResizeArray<obj> -> DataTableBuilder
            abstract build: unit -> DataTable
            abstract setValue: row: Integer * column: Integer * value: obj -> DataTableBuilder

        and [<AllowNullLiteral>] DataTableSource =
            abstract getDataTable: unit -> DataTable

        and [<AllowNullLiteral>] DataViewDefinition =
            interface end

        and [<AllowNullLiteral>] DataViewDefinitionBuilder =
            abstract build: unit -> DataViewDefinition
            abstract setColumns: columns: ResizeArray<obj> -> DataViewDefinitionBuilder

        and [<AllowNullLiteral>] LineChartBuilder =
            abstract build: unit -> Chart
            abstract reverseCategories: unit -> LineChartBuilder
            abstract setBackgroundColor: cssValue: string -> LineChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> LineChartBuilder
            abstract setCurveStyle: style: CurveStyle -> LineChartBuilder
            abstract setDataSourceUrl: url: string -> LineChartBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> LineChartBuilder
            abstract setDataTable: table: DataTableSource -> LineChartBuilder
            abstract setDataViewDefinition: dataViewDefinition: DataViewDefinition -> LineChartBuilder
            abstract setDimensions: width: Integer * height: Integer -> LineChartBuilder
            abstract setLegendPosition: position: Position -> LineChartBuilder
            abstract setLegendTextStyle: textStyle: TextStyle -> LineChartBuilder
            abstract setOption: option: string * value: obj -> LineChartBuilder
            abstract setPointStyle: style: PointStyle -> LineChartBuilder
            abstract setRange: start: float * ``end``: float -> LineChartBuilder
            abstract setTitle: chartTitle: string -> LineChartBuilder
            abstract setTitleTextStyle: textStyle: TextStyle -> LineChartBuilder
            abstract setXAxisTextStyle: textStyle: TextStyle -> LineChartBuilder
            abstract setXAxisTitle: title: string -> LineChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: TextStyle -> LineChartBuilder
            abstract setYAxisTextStyle: textStyle: TextStyle -> LineChartBuilder
            abstract setYAxisTitle: title: string -> LineChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: TextStyle -> LineChartBuilder
            abstract useLogScale: unit -> LineChartBuilder

        and MatchType =
            | EXACT = 0
            | PREFIX = 1
            | ANY = 2

        and [<AllowNullLiteral>] NumberRangeFilterBuilder =
            abstract build: unit -> Control
            abstract setDataTable: tableBuilder: DataTableBuilder -> NumberRangeFilterBuilder
            abstract setDataTable: table: DataTableSource -> NumberRangeFilterBuilder
            abstract setFilterColumnIndex: columnIndex: Integer -> NumberRangeFilterBuilder
            abstract setFilterColumnLabel: columnLabel: string -> NumberRangeFilterBuilder
            abstract setLabel: label: string -> NumberRangeFilterBuilder
            abstract setLabelSeparator: labelSeparator: string -> NumberRangeFilterBuilder
            abstract setLabelStacking: orientation: Orientation -> NumberRangeFilterBuilder
            abstract setMaxValue: maxValue: Integer -> NumberRangeFilterBuilder
            abstract setMinValue: minValue: Integer -> NumberRangeFilterBuilder
            abstract setOrientation: orientation: Orientation -> NumberRangeFilterBuilder
            abstract setShowRangeValues: showRangeValues: bool -> NumberRangeFilterBuilder
            abstract setTicks: ticks: Integer -> NumberRangeFilterBuilder

        and Orientation =
            | HORIZONTAL = 0
            | VERTICAL = 1

        and PickerValuesLayout =
            | ASIDE = 0
            | BELOW = 1
            | BELOW_WRAPPING = 2
            | BELOW_STACKED = 3

        and [<AllowNullLiteral>] PieChartBuilder =
            abstract build: unit -> Chart
            abstract reverseCategories: unit -> PieChartBuilder
            abstract set3D: unit -> PieChartBuilder
            abstract setBackgroundColor: cssValue: string -> PieChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> PieChartBuilder
            abstract setDataSourceUrl: url: string -> PieChartBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> PieChartBuilder
            abstract setDataTable: table: DataTableSource -> PieChartBuilder
            abstract setDataViewDefinition: dataViewDefinition: DataViewDefinition -> PieChartBuilder
            abstract setDimensions: width: Integer * height: Integer -> PieChartBuilder
            abstract setLegendPosition: position: Position -> PieChartBuilder
            abstract setLegendTextStyle: textStyle: TextStyle -> PieChartBuilder
            abstract setOption: option: string * value: obj -> PieChartBuilder
            abstract setTitle: chartTitle: string -> PieChartBuilder
            abstract setTitleTextStyle: textStyle: TextStyle -> PieChartBuilder

        and PointStyle =
            | NONE = 0
            | TINY = 1
            | MEDIUM = 2
            | LARGE = 3
            | HUGE = 4

        and Position =
            | TOP = 0
            | RIGHT = 1
            | BOTTOM = 2
            | NONE = 3

        and [<AllowNullLiteral>] ScatterChartBuilder =
            abstract build: unit -> Chart
            abstract setBackgroundColor: cssValue: string -> ScatterChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> ScatterChartBuilder
            abstract setDataSourceUrl: url: string -> ScatterChartBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> ScatterChartBuilder
            abstract setDataTable: table: DataTableSource -> ScatterChartBuilder
            abstract setDataViewDefinition: dataViewDefinition: DataViewDefinition -> ScatterChartBuilder
            abstract setDimensions: width: Integer * height: Integer -> ScatterChartBuilder
            abstract setLegendPosition: position: Position -> ScatterChartBuilder
            abstract setLegendTextStyle: textStyle: TextStyle -> ScatterChartBuilder
            abstract setOption: option: string * value: obj -> ScatterChartBuilder
            abstract setPointStyle: style: PointStyle -> ScatterChartBuilder
            abstract setTitle: chartTitle: string -> ScatterChartBuilder
            abstract setTitleTextStyle: textStyle: TextStyle -> ScatterChartBuilder
            abstract setXAxisLogScale: unit -> ScatterChartBuilder
            abstract setXAxisRange: start: float * ``end``: float -> ScatterChartBuilder
            abstract setXAxisTextStyle: textStyle: TextStyle -> ScatterChartBuilder
            abstract setXAxisTitle: title: string -> ScatterChartBuilder
            abstract setXAxisTitleTextStyle: textStyle: TextStyle -> ScatterChartBuilder
            abstract setYAxisLogScale: unit -> ScatterChartBuilder
            abstract setYAxisRange: start: float * ``end``: float -> ScatterChartBuilder
            abstract setYAxisTextStyle: textStyle: TextStyle -> ScatterChartBuilder
            abstract setYAxisTitle: title: string -> ScatterChartBuilder
            abstract setYAxisTitleTextStyle: textStyle: TextStyle -> ScatterChartBuilder

        and [<AllowNullLiteral>] StringFilterBuilder =
            abstract build: unit -> Control
            abstract setCaseSensitive: caseSensitive: bool -> StringFilterBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> StringFilterBuilder
            abstract setDataTable: table: DataTableSource -> StringFilterBuilder
            abstract setFilterColumnIndex: columnIndex: Integer -> StringFilterBuilder
            abstract setFilterColumnLabel: columnLabel: string -> StringFilterBuilder
            abstract setLabel: label: string -> StringFilterBuilder
            abstract setLabelSeparator: labelSeparator: string -> StringFilterBuilder
            abstract setLabelStacking: orientation: Orientation -> StringFilterBuilder
            abstract setMatchType: matchType: MatchType -> StringFilterBuilder
            abstract setRealtimeTrigger: realtimeTrigger: bool -> StringFilterBuilder

        and [<AllowNullLiteral>] TableChartBuilder =
            abstract build: unit -> Chart
            abstract enablePaging: enablePaging: bool -> TableChartBuilder
            abstract enablePaging: pageSize: Integer -> TableChartBuilder
            abstract enablePaging: pageSize: Integer * startPage: Integer -> TableChartBuilder
            abstract enableRtlTable: rtlEnabled: bool -> TableChartBuilder
            abstract enableSorting: enableSorting: bool -> TableChartBuilder
            abstract setDataSourceUrl: url: string -> TableChartBuilder
            abstract setDataTable: tableBuilder: DataTableBuilder -> TableChartBuilder
            abstract setDataTable: table: DataTableSource -> TableChartBuilder
            abstract setDataViewDefinition: dataViewDefinition: DataViewDefinition -> TableChartBuilder
            abstract setDimensions: width: Integer * height: Integer -> TableChartBuilder
            abstract setFirstRowNumber: number: Integer -> TableChartBuilder
            abstract setInitialSortingAscending: column: Integer -> TableChartBuilder
            abstract setInitialSortingDescending: column: Integer -> TableChartBuilder
            abstract setOption: option: string * value: obj -> TableChartBuilder
            abstract showRowNumberColumn: showRowNumber: bool -> TableChartBuilder
            abstract useAlternatingRowStyle: alternate: bool -> TableChartBuilder

        and [<AllowNullLiteral>] TextStyle =
            abstract getColor: unit -> string
            abstract getFontName: unit -> string
            abstract getFontSize: unit -> float

        and [<AllowNullLiteral>] TextStyleBuilder =
            abstract build: unit -> TextStyle
            abstract setColor: cssValue: string -> TextStyleBuilder
            abstract setFontName: fontName: string -> TextStyleBuilder
            abstract setFontSize: fontSize: float -> TextStyleBuilder

//type [<Erase>]Globals =
//    [<Global>] static member Charts with get(): GoogleAppsScript.Charts.Charts = jsNative and set(v: GoogleAppsScript.Charts.Charts): unit = jsNative

