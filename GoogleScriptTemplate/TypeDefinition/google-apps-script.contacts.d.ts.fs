namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Contacts =
        type [<AllowNullLiteral>] AddressField =
            abstract deleteAddressField: unit -> unit
            abstract getAddress: unit -> string
            abstract getLabel: unit -> obj
            abstract isPrimary: unit -> bool
            abstract setAddress: address: string -> AddressField
            abstract setAsPrimary: unit -> AddressField
            abstract setLabel: field: Field -> AddressField
            abstract setLabel: label: string -> AddressField

        and [<AllowNullLiteral>] CompanyField =
            abstract deleteCompanyField: unit -> unit
            abstract getCompanyName: unit -> string
            abstract getJobTitle: unit -> string
            abstract isPrimary: unit -> bool
            abstract setAsPrimary: unit -> CompanyField
            abstract setCompanyName: company: string -> CompanyField
            abstract setJobTitle: title: string -> CompanyField

        and [<AllowNullLiteral>] Contact =
            abstract addAddress: label: obj * address: string -> AddressField
            abstract addCompany: company: string * title: string -> CompanyField
            abstract addCustomField: label: obj * content: obj -> CustomField
            abstract addDate: label: obj * month: Base.Month * day: Integer * year: Integer -> DateField
            abstract addEmail: label: obj * address: string -> EmailField
            abstract addIM: label: obj * address: string -> IMField
            abstract addPhone: label: obj * number: string -> PhoneField
            abstract addToGroup: group: ContactGroup -> Contact
            abstract addUrl: label: obj * url: string -> UrlField
            abstract deleteContact: unit -> unit
            abstract getAddresses: unit -> ResizeArray<AddressField>
            abstract getAddresses: label: obj -> ResizeArray<AddressField>
            abstract getCompanies: unit -> ResizeArray<CompanyField>
            abstract getContactGroups: unit -> ResizeArray<ContactGroup>
            abstract getCustomFields: unit -> ResizeArray<CustomField>
            abstract getCustomFields: label: obj -> ResizeArray<CustomField>
            abstract getDates: unit -> ResizeArray<DateField>
            abstract getDates: label: obj -> ResizeArray<DateField>
            abstract getEmails: unit -> ResizeArray<EmailField>
            abstract getEmails: label: obj -> ResizeArray<EmailField>
            abstract getFamilyName: unit -> string
            abstract getFullName: unit -> string
            abstract getGivenName: unit -> string
            abstract getIMs: unit -> ResizeArray<IMField>
            abstract getIMs: label: obj -> ResizeArray<IMField>
            abstract getId: unit -> string
            abstract getInitials: unit -> string
            abstract getLastUpdated: unit -> DateTime
            abstract getMaidenName: unit -> string
            abstract getMiddleName: unit -> string
            abstract getNickname: unit -> string
            abstract getNotes: unit -> string
            abstract getPhones: unit -> ResizeArray<PhoneField>
            abstract getPhones: label: obj -> ResizeArray<PhoneField>
            abstract getPrefix: unit -> string
            abstract getPrimaryEmail: unit -> string
            abstract getShortName: unit -> string
            abstract getSuffix: unit -> string
            abstract getUrls: unit -> ResizeArray<UrlField>
            abstract getUrls: label: obj -> ResizeArray<UrlField>
            abstract removeFromGroup: group: ContactGroup -> Contact
            abstract setFamilyName: familyName: string -> Contact
            abstract setFullName: fullName: string -> Contact
            abstract setGivenName: givenName: string -> Contact
            abstract setInitials: initials: string -> Contact
            abstract setMaidenName: maidenName: string -> Contact
            abstract setMiddleName: middleName: string -> Contact
            abstract setNickname: nickname: string -> Contact
            abstract setNotes: notes: string -> Contact
            abstract setPrefix: prefix: string -> Contact
            abstract setShortName: shortName: string -> Contact
            abstract setSuffix: suffix: string -> Contact
            abstract getEmailAddresses: unit -> ResizeArray<string>
            abstract getHomeAddress: unit -> string
            abstract getHomeFax: unit -> string
            abstract getHomePhone: unit -> string
            abstract getMobilePhone: unit -> string
            abstract getPager: unit -> string
            abstract getUserDefinedField: key: string -> string
            abstract getUserDefinedFields: unit -> obj
            abstract getWorkAddress: unit -> string
            abstract getWorkFax: unit -> string
            abstract getWorkPhone: unit -> string
            abstract setHomeAddress: addr: string -> unit
            abstract setHomeFax: phone: string -> unit
            abstract setHomePhone: phone: string -> unit
            abstract setMobilePhone: phone: string -> unit
            abstract setPager: phone: string -> unit
            abstract setPrimaryEmail: primaryEmail: string -> unit
            abstract setUserDefinedField: key: string * value: string -> unit
            abstract setUserDefinedFields: o: obj -> unit
            abstract setWorkAddress: addr: string -> unit
            abstract setWorkFax: phone: string -> unit
            abstract setWorkPhone: phone: string -> unit

        and [<AllowNullLiteral>] ContactGroup =
            abstract addContact: contact: Contact -> ContactGroup
            abstract deleteGroup: unit -> unit
            abstract getContacts: unit -> ResizeArray<Contact>
            abstract getId: unit -> string
            abstract getName: unit -> string
            abstract isSystemGroup: unit -> bool
            abstract removeContact: contact: Contact -> ContactGroup
            abstract setName: name: string -> ContactGroup
            abstract getGroupName: unit -> string
            abstract setGroupName: name: string -> unit

        and [<AllowNullLiteral>] ContactsApp =
            abstract ExtendedField: ExtendedField with get, set
            abstract Field: Field with get, set
            abstract Gender: Gender with get, set
            abstract Month: Base.Month with get, set
            abstract Priority: Priority with get, set
            abstract Sensitivity: Sensitivity with get, set
            abstract createContact: givenName: string * familyName: string * email: string -> Contact
            abstract createContactGroup: name: string -> ContactGroup
            abstract deleteContact: contact: Contact -> unit
            abstract deleteContactGroup: group: ContactGroup -> unit
            abstract getContact: emailAddress: string -> Contact
            abstract getContactById: id: string -> Contact
            abstract getContactGroup: name: string -> ContactGroup
            abstract getContactGroupById: id: string -> ContactGroup
            abstract getContactGroups: unit -> ResizeArray<ContactGroup>
            abstract getContacts: unit -> ResizeArray<Contact>
            abstract getContactsByAddress: query: string -> ResizeArray<Contact>
            abstract getContactsByAddress: query: string * label: Field -> ResizeArray<Contact>
            abstract getContactsByAddress: query: string * label: string -> ResizeArray<Contact>
            abstract getContactsByCompany: query: string -> ResizeArray<Contact>
            abstract getContactsByCustomField: query: obj * label: ExtendedField -> ResizeArray<Contact>
            abstract getContactsByDate: month: Base.Month * day: Integer * label: Field -> ResizeArray<Contact>
            abstract getContactsByDate: month: Base.Month * day: Integer * year: Integer * label: Field -> ResizeArray<Contact>
            abstract getContactsByDate: month: Base.Month * day: Integer * year: Integer * label: string -> ResizeArray<Contact>
            abstract getContactsByDate: month: Base.Month * day: Integer * label: string -> ResizeArray<Contact>
            abstract getContactsByEmailAddress: query: string -> ResizeArray<Contact>
            abstract getContactsByEmailAddress: query: string * label: Field -> ResizeArray<Contact>
            abstract getContactsByEmailAddress: query: string * label: string -> ResizeArray<Contact>
            abstract getContactsByGroup: group: ContactGroup -> ResizeArray<Contact>
            abstract getContactsByIM: query: string -> ResizeArray<Contact>
            abstract getContactsByIM: query: string * label: Field -> ResizeArray<Contact>
            abstract getContactsByIM: query: string * label: string -> ResizeArray<Contact>
            abstract getContactsByJobTitle: query: string -> ResizeArray<Contact>
            abstract getContactsByName: query: string -> ResizeArray<Contact>
            abstract getContactsByName: query: string * label: Field -> ResizeArray<Contact>
            abstract getContactsByNotes: query: string -> ResizeArray<Contact>
            abstract getContactsByPhone: query: string -> ResizeArray<Contact>
            abstract getContactsByPhone: query: string * label: Field -> ResizeArray<Contact>
            abstract getContactsByPhone: query: string * label: string -> ResizeArray<Contact>
            abstract getContactsByUrl: query: string -> ResizeArray<Contact>
            abstract getContactsByUrl: query: string * label: Field -> ResizeArray<Contact>
            abstract getContactsByUrl: query: string * label: string -> ResizeArray<Contact>
            abstract findByEmailAddress: email: string -> Contact
            abstract findContactGroup: name: string -> ContactGroup
            abstract getAllContacts: unit -> ResizeArray<Contact>

        and [<AllowNullLiteral>] CustomField =
            abstract deleteCustomField: unit -> unit
            abstract getLabel: unit -> obj
            abstract getValue: unit -> obj
            abstract setLabel: field: ExtendedField -> CustomField
            abstract setLabel: label: string -> CustomField
            abstract setValue: value: obj -> CustomField

        and [<AllowNullLiteral>] DateField =
            abstract deleteDateField: unit -> unit
            abstract getDay: unit -> Integer
            abstract getLabel: unit -> obj
            abstract getMonth: unit -> Base.Month
            abstract getYear: unit -> Integer
            abstract setDate: month: Base.Month * day: Integer -> DateField
            abstract setDate: month: Base.Month * day: Integer * year: Integer -> DateField
            abstract setLabel: label: Field -> DateField
            abstract setLabel: label: string -> DateField

        and [<AllowNullLiteral>] EmailField =
            abstract deleteEmailField: unit -> unit
            abstract getAddress: unit -> string
            abstract getDisplayName: unit -> string
            abstract getLabel: unit -> obj
            abstract isPrimary: unit -> bool
            abstract setAddress: address: string -> EmailField
            abstract setAsPrimary: unit -> EmailField
            abstract setDisplayName: name: string -> EmailField
            abstract setLabel: field: Field -> EmailField
            abstract setLabel: label: string -> EmailField

        and ExtendedField =
            | HOBBY = 0
            | MILEAGE = 1
            | LANGUAGE = 2
            | GENDER = 3
            | BILLING_INFORMATION = 4
            | DIRECTORY_SERVER = 5
            | SENSITIVITY = 6
            | PRIORITY = 7
            | HOME = 8
            | WORK = 9
            | USER = 10
            | OTHER = 11

        and Field =
            | FULL_NAME = 0
            | GIVEN_NAME = 1
            | MIDDLE_NAME = 2
            | FAMILY_NAME = 3
            | MAIDEN_NAME = 4
            | NICKNAME = 5
            | SHORT_NAME = 6
            | INITIALS = 7
            | PREFIX = 8
            | SUFFIX = 9
            | HOME_EMAIL = 10
            | WORK_EMAIL = 11
            | BIRTHDAY = 12
            | ANNIVERSARY = 13
            | HOME_ADDRESS = 14
            | WORK_ADDRESS = 15
            | ASSISTANT_PHONE = 16
            | CALLBACK_PHONE = 17
            | MAIN_PHONE = 18
            | PAGER = 19
            | HOME_FAX = 20
            | WORK_FAX = 21
            | HOME_PHONE = 22
            | WORK_PHONE = 23
            | MOBILE_PHONE = 24
            | GOOGLE_VOICE = 25
            | NOTES = 26
            | GOOGLE_TALK = 27
            | AIM = 28
            | YAHOO = 29
            | SKYPE = 30
            | QQ = 31
            | MSN = 32
            | ICQ = 33
            | JABBER = 34
            | BLOG = 35
            | FTP = 36
            | PROFILE = 37
            | HOME_PAGE = 38
            | WORK_WEBSITE = 39
            | HOME_WEBSITE = 40
            | JOB_TITLE = 41
            | COMPANY = 42

        and Gender =
            | MALE = 0
            | FEMALE = 1

        and [<AllowNullLiteral>] IMField =
            abstract deleteIMField: unit -> unit
            abstract getAddress: unit -> string
            abstract getLabel: unit -> obj
            abstract isPrimary: unit -> bool
            abstract setAddress: address: string -> IMField
            abstract setAsPrimary: unit -> IMField
            abstract setLabel: field: Field -> IMField
            abstract setLabel: label: string -> IMField

        and [<AllowNullLiteral>] PhoneField =
            abstract deletePhoneField: unit -> unit
            abstract getLabel: unit -> obj
            abstract getPhoneNumber: unit -> string
            abstract isPrimary: unit -> bool
            abstract setAsPrimary: unit -> PhoneField
            abstract setLabel: field: Field -> PhoneField
            abstract setLabel: label: string -> PhoneField
            abstract setPhoneNumber: number: string -> PhoneField

        and Priority =
            | HIGH = 0
            | LOW = 1
            | NORMAL = 2

        and Sensitivity =
            | CONFIDENTIAL = 0
            | NORMAL = 1
            | PERSONAL = 2
            | PRIVATE = 3

        and [<AllowNullLiteral>] UrlField =
            abstract deleteUrlField: unit -> unit
            abstract getAddress: unit -> string
            abstract getLabel: unit -> obj
            abstract isPrimary: unit -> bool
            abstract setAddress: address: string -> UrlField
            abstract setAsPrimary: unit -> UrlField
            abstract setLabel: field: Field -> UrlField
            abstract setLabel: label: string -> UrlField

//type [<Erase>]Globals =
//    [<Global>] static member ContactsApp with get(): GoogleAppsScript.Contacts.ContactsApp = jsNative and set(v: GoogleAppsScript.Contacts.ContactsApp): unit = jsNative


