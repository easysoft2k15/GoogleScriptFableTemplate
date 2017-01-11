namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Calendar =
        type [<AllowNullLiteral>] Calendar =
            abstract createAllDayEvent: title: string * date: DateTime -> CalendarEvent
            abstract createAllDayEvent: title: string * date: DateTime * options: obj -> CalendarEvent
            abstract createAllDayEventSeries: title: string * startDate: DateTime * recurrence: EventRecurrence -> CalendarEventSeries
            abstract createAllDayEventSeries: title: string * startDate: DateTime * recurrence: EventRecurrence * options: obj -> CalendarEventSeries
            abstract createEvent: title: string * startTime: DateTime * endTime: DateTime -> CalendarEvent
            abstract createEvent: title: string * startTime: DateTime * endTime: DateTime * options: obj -> CalendarEvent
            abstract createEventFromDescription: description: string -> CalendarEvent
            abstract createEventSeries: title: string * startTime: DateTime * endTime: DateTime * recurrence: EventRecurrence -> CalendarEventSeries
            abstract createEventSeries: title: string * startTime: DateTime * endTime: DateTime * recurrence: EventRecurrence * options: obj -> CalendarEventSeries
            abstract deleteCalendar: unit -> unit
            abstract getColor: unit -> string
            abstract getDescription: unit -> string
            abstract getEventSeriesById: iCalId: string -> CalendarEventSeries
            abstract getEvents: startTime: DateTime * endTime: DateTime -> ResizeArray<CalendarEvent>
            abstract getEvents: startTime: DateTime * endTime: DateTime * options: obj -> ResizeArray<CalendarEvent>
            abstract getEventsForDay: date: DateTime -> ResizeArray<CalendarEvent>
            abstract getEventsForDay: date: DateTime * options: obj -> ResizeArray<CalendarEvent>
            abstract getId: unit -> string
            abstract getName: unit -> string
            abstract getTimeZone: unit -> string
            abstract isHidden: unit -> bool
            abstract isMyPrimaryCalendar: unit -> bool
            abstract isOwnedByMe: unit -> bool
            abstract isSelected: unit -> bool
            abstract setColor: color: string -> Calendar
            abstract setDescription: description: string -> Calendar
            abstract setHidden: hidden: bool -> Calendar
            abstract setName: name: string -> Calendar
            abstract setSelected: selected: bool -> Calendar
            abstract setTimeZone: timeZone: string -> Calendar
            abstract unsubscribeFromCalendar: unit -> unit

        and [<AllowNullLiteral>] CalendarApp =
            abstract Color: Color with get, set
            abstract GuestStatus: GuestStatus with get, set
            abstract Month: Base.Month with get, set
            abstract Visibility: Visibility with get, set
            abstract Weekday: Base.Weekday with get, set
            abstract createAllDayEvent: title: string * date: DateTime -> CalendarEvent
            abstract createAllDayEvent: title: string * date: DateTime * options: obj -> CalendarEvent
            abstract createAllDayEventSeries: title: string * startDate: DateTime * recurrence: EventRecurrence -> CalendarEventSeries
            abstract createAllDayEventSeries: title: string * startDate: DateTime * recurrence: EventRecurrence * options: obj -> CalendarEventSeries
            abstract createCalendar: name: string -> Calendar
            abstract createCalendar: name: string * options: obj -> Calendar
            abstract createEvent: title: string * startTime: DateTime * endTime: DateTime -> CalendarEvent
            abstract createEvent: title: string * startTime: DateTime * endTime: DateTime * options: obj -> CalendarEvent
            abstract createEventFromDescription: description: string -> CalendarEvent
            abstract createEventSeries: title: string * startTime: DateTime * endTime: DateTime * recurrence: EventRecurrence -> CalendarEventSeries
            abstract createEventSeries: title: string * startTime: DateTime * endTime: DateTime * recurrence: EventRecurrence * options: obj -> CalendarEventSeries
            abstract getAllCalendars: unit -> ResizeArray<Calendar>
            abstract getAllOwnedCalendars: unit -> ResizeArray<Calendar>
            abstract getCalendarById: id: string -> Calendar
            abstract getCalendarsByName: name: string -> ResizeArray<Calendar>
            abstract getColor: unit -> string
            abstract getDefaultCalendar: unit -> Calendar
            abstract getDescription: unit -> string
            abstract getEventSeriesById: iCalId: string -> CalendarEventSeries
            abstract getEvents: startTime: DateTime * endTime: DateTime -> ResizeArray<CalendarEvent>
            abstract getEvents: startTime: DateTime * endTime: DateTime * options: obj -> ResizeArray<CalendarEvent>
            abstract getEventsForDay: date: DateTime -> ResizeArray<CalendarEvent>
            abstract getEventsForDay: date: DateTime * options: obj -> ResizeArray<CalendarEvent>
            abstract getId: unit -> string
            abstract getName: unit -> string
            abstract getOwnedCalendarById: id: string -> Calendar
            abstract getOwnedCalendarsByName: name: string -> ResizeArray<Calendar>
            abstract getTimeZone: unit -> string
            abstract isHidden: unit -> bool
            abstract isMyPrimaryCalendar: unit -> bool
            abstract isOwnedByMe: unit -> bool
            abstract isSelected: unit -> bool
            abstract newRecurrence: unit -> EventRecurrence
            abstract setColor: color: string -> Calendar
            abstract setDescription: description: string -> Calendar
            abstract setHidden: hidden: bool -> Calendar
            abstract setName: name: string -> Calendar
            abstract setSelected: selected: bool -> Calendar
            abstract setTimeZone: timeZone: string -> Calendar
            abstract subscribeToCalendar: id: string -> Calendar
            abstract subscribeToCalendar: id: string * options: obj -> Calendar

        and [<AllowNullLiteral>] CalendarEvent =
            abstract addEmailReminder: minutesBefore: Integer -> CalendarEvent
            abstract addGuest: email: string -> CalendarEvent
            abstract addPopupReminder: minutesBefore: Integer -> CalendarEvent
            abstract addSmsReminder: minutesBefore: Integer -> CalendarEvent
            abstract anyoneCanAddSelf: unit -> bool
            abstract deleteEvent: unit -> unit
            abstract deleteTag: key: string -> CalendarEvent
            abstract getAllDayEndDate: unit -> DateTime
            abstract getAllDayStartDate: unit -> DateTime
            abstract getAllTagKeys: unit -> ResizeArray<string>
            abstract getCreators: unit -> ResizeArray<string>
            abstract getDateCreated: unit -> DateTime
            abstract getDescription: unit -> string
            abstract getEmailReminders: unit -> ResizeArray<Integer>
            abstract getEndTime: unit -> DateTime
            abstract getEventSeries: unit -> CalendarEventSeries
            abstract getGuestByEmail: email: string -> EventGuest
            abstract getGuestList: unit -> ResizeArray<EventGuest>
            abstract getGuestList: includeOwner: bool -> ResizeArray<EventGuest>
            abstract getId: unit -> string
            abstract getLastUpdated: unit -> DateTime
            abstract getLocation: unit -> string
            abstract getMyStatus: unit -> GuestStatus
            abstract getOriginalCalendarId: unit -> string
            abstract getPopupReminders: unit -> ResizeArray<Integer>
            abstract getSmsReminders: unit -> ResizeArray<Integer>
            abstract getStartTime: unit -> DateTime
            abstract getTag: key: string -> string
            abstract getTitle: unit -> string
            abstract getVisibility: unit -> Visibility
            abstract guestsCanInviteOthers: unit -> bool
            abstract guestsCanModify: unit -> bool
            abstract guestsCanSeeGuests: unit -> bool
            abstract isAllDayEvent: unit -> bool
            abstract isOwnedByMe: unit -> bool
            abstract isRecurringEvent: unit -> bool
            abstract removeAllReminders: unit -> CalendarEvent
            abstract removeGuest: email: string -> CalendarEvent
            abstract resetRemindersToDefault: unit -> CalendarEvent
            abstract setAllDayDate: date: DateTime -> CalendarEvent
            abstract setAnyoneCanAddSelf: anyoneCanAddSelf: bool -> CalendarEvent
            abstract setDescription: description: string -> CalendarEvent
            abstract setGuestsCanInviteOthers: guestsCanInviteOthers: bool -> CalendarEvent
            abstract setGuestsCanModify: guestsCanModify: bool -> CalendarEvent
            abstract setGuestsCanSeeGuests: guestsCanSeeGuests: bool -> CalendarEvent
            abstract setLocation: location: string -> CalendarEvent
            abstract setMyStatus: status: GuestStatus -> CalendarEvent
            abstract setTag: key: string * value: string -> CalendarEvent
            abstract setTime: startTime: DateTime * endTime: DateTime -> CalendarEvent
            abstract setTitle: title: string -> CalendarEvent
            abstract setVisibility: visibility: Visibility -> CalendarEvent

        and [<AllowNullLiteral>] CalendarEventSeries =
            abstract addEmailReminder: minutesBefore: Integer -> CalendarEventSeries
            abstract addGuest: email: string -> CalendarEventSeries
            abstract addPopupReminder: minutesBefore: Integer -> CalendarEventSeries
            abstract addSmsReminder: minutesBefore: Integer -> CalendarEventSeries
            abstract anyoneCanAddSelf: unit -> bool
            abstract deleteEventSeries: unit -> unit
            abstract deleteTag: key: string -> CalendarEventSeries
            abstract getAllTagKeys: unit -> ResizeArray<string>
            abstract getCreators: unit -> ResizeArray<string>
            abstract getDateCreated: unit -> DateTime
            abstract getDescription: unit -> string
            abstract getEmailReminders: unit -> ResizeArray<Integer>
            abstract getGuestByEmail: email: string -> EventGuest
            abstract getGuestList: unit -> ResizeArray<EventGuest>
            abstract getGuestList: includeOwner: bool -> ResizeArray<EventGuest>
            abstract getId: unit -> string
            abstract getLastUpdated: unit -> DateTime
            abstract getLocation: unit -> string
            abstract getMyStatus: unit -> GuestStatus
            abstract getOriginalCalendarId: unit -> string
            abstract getPopupReminders: unit -> ResizeArray<Integer>
            abstract getSmsReminders: unit -> ResizeArray<Integer>
            abstract getTag: key: string -> string
            abstract getTitle: unit -> string
            abstract getVisibility: unit -> Visibility
            abstract guestsCanInviteOthers: unit -> bool
            abstract guestsCanModify: unit -> bool
            abstract guestsCanSeeGuests: unit -> bool
            abstract isOwnedByMe: unit -> bool
            abstract removeAllReminders: unit -> CalendarEventSeries
            abstract removeGuest: email: string -> CalendarEventSeries
            abstract resetRemindersToDefault: unit -> CalendarEventSeries
            abstract setAnyoneCanAddSelf: anyoneCanAddSelf: bool -> CalendarEventSeries
            abstract setDescription: description: string -> CalendarEventSeries
            abstract setGuestsCanInviteOthers: guestsCanInviteOthers: bool -> CalendarEventSeries
            abstract setGuestsCanModify: guestsCanModify: bool -> CalendarEventSeries
            abstract setGuestsCanSeeGuests: guestsCanSeeGuests: bool -> CalendarEventSeries
            abstract setLocation: location: string -> CalendarEventSeries
            abstract setMyStatus: status: GuestStatus -> CalendarEventSeries
            abstract setRecurrence: recurrence: EventRecurrence * startDate: DateTime -> CalendarEventSeries
            abstract setRecurrence: recurrence: EventRecurrence * startTime: DateTime * endTime: DateTime -> CalendarEventSeries
            abstract setTag: key: string * value: string -> CalendarEventSeries
            abstract setTitle: title: string -> CalendarEventSeries
            abstract setVisibility: visibility: Visibility -> CalendarEventSeries

        and Color =
            | BLUE = 0
            | BROWN = 1
            | CHARCOAL = 2
            | CHESTNUT = 3
            | GRAY = 4
            | GREEN = 5
            | INDIGO = 6
            | LIME = 7
            | MUSTARD = 8
            | OLIVE = 9
            | ORANGE = 10
            | PINK = 11
            | PLUM = 12
            | PURPLE = 13
            | RED = 14
            | RED_ORANGE = 15
            | SEA_BLUE = 16
            | SLATE = 17
            | TEAL = 18
            | TURQOISE = 19
            | YELLOW = 20

        and [<AllowNullLiteral>] EventGuest =
            abstract getAdditionalGuests: unit -> Integer
            abstract getEmail: unit -> string
            abstract getGuestStatus: unit -> GuestStatus
            abstract getName: unit -> string
            abstract getStatus: unit -> string

        and [<AllowNullLiteral>] EventRecurrence =
            abstract addDailyExclusion: unit -> RecurrenceRule
            abstract addDailyRule: unit -> RecurrenceRule
            abstract addDate: date: DateTime -> EventRecurrence
            abstract addDateExclusion: date: DateTime -> EventRecurrence
            abstract addMonthlyExclusion: unit -> RecurrenceRule
            abstract addMonthlyRule: unit -> RecurrenceRule
            abstract addWeeklyExclusion: unit -> RecurrenceRule
            abstract addWeeklyRule: unit -> RecurrenceRule
            abstract addYearlyExclusion: unit -> RecurrenceRule
            abstract addYearlyRule: unit -> RecurrenceRule
            abstract setTimeZone: timeZone: string -> EventRecurrence

        and GuestStatus =
            | INVITED = 0
            | MAYBE = 1
            | NO = 2
            | OWNER = 3
            | YES = 4

        and [<AllowNullLiteral>] RecurrenceRule =
            abstract addDailyExclusion: unit -> RecurrenceRule
            abstract addDailyRule: unit -> RecurrenceRule
            abstract addDate: date: DateTime -> EventRecurrence
            abstract addDateExclusion: date: DateTime -> EventRecurrence
            abstract addMonthlyExclusion: unit -> RecurrenceRule
            abstract addMonthlyRule: unit -> RecurrenceRule
            abstract addWeeklyExclusion: unit -> RecurrenceRule
            abstract addWeeklyRule: unit -> RecurrenceRule
            abstract addYearlyExclusion: unit -> RecurrenceRule
            abstract addYearlyRule: unit -> RecurrenceRule
            abstract interval: interval: Integer -> RecurrenceRule
            abstract onlyInMonth: month: Base.Month -> RecurrenceRule
            abstract onlyInMonths: months: ResizeArray<Base.Month> -> RecurrenceRule
            abstract onlyOnMonthDay: day: Integer -> RecurrenceRule
            abstract onlyOnMonthDays: days: ResizeArray<Integer> -> RecurrenceRule
            abstract onlyOnWeek: week: Integer -> RecurrenceRule
            abstract onlyOnWeekday: day: Base.Weekday -> RecurrenceRule
            abstract onlyOnWeekdays: days: ResizeArray<Base.Weekday> -> RecurrenceRule
            abstract onlyOnWeeks: weeks: ResizeArray<Integer> -> RecurrenceRule
            abstract onlyOnYearDay: day: Integer -> RecurrenceRule
            abstract onlyOnYearDays: days: ResizeArray<Integer> -> RecurrenceRule
            abstract setTimeZone: timeZone: string -> EventRecurrence
            abstract times: times: Integer -> RecurrenceRule
            abstract until: endDate: DateTime -> RecurrenceRule
            abstract weekStartsOn: day: Base.Weekday -> RecurrenceRule

        and Visibility =
            | CONFIDENTIAL = 0
            | DEFAULT = 1
            | PRIVATE = 2
            | PUBLIC = 3


//type [<Erase>]Globals =
//    [<Global>] static member CalendarApp with get(): GoogleAppsScript.Calendar.CalendarApp = jsNative and set(v: GoogleAppsScript.Calendar.CalendarApp): unit = jsNative
