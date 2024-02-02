﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# ItalianWorkDaysUtils.HowManyItalianOfficeDaysBetweenDates Method

**Declaring Type:** [ItalianWorkDaysUtils](../index.md)  
**Namespace:** [DavideBorghi.ItalianDotNetDateTimeUtils](../../index.md)  
**Assembly:** DavideBorghi.ItalianDotNetDateTimeUtils  
**Assembly Version:** 2.0.0+11b385815d24cc7747d25bd6e9b11b068538c4b2

Gets the number of Italian office days between two given dates, removing weekends and Italian national and local holidays.

```csharp
public static int HowManyItalianOfficeDaysBetweenDates(DateTime startDate, DateTime endDate);
```

## Parameters

`startDate`  DateTime

The start date.

`endDate`  DateTime

The end date.

## Returns

int

The number of Italian office days between two dates.

## Exceptions

ArgumentException

Thrown when provided start date is after given end date.

ArgumentException

Thrown when one or both of the provided dates' year is before 1946.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*