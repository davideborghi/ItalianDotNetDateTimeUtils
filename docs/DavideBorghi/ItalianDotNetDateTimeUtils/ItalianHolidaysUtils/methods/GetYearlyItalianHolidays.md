﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# ItalianHolidaysUtils.GetYearlyItalianHolidays Method

**Declaring Type:** [ItalianHolidaysUtils](../index.md)  
**Namespace:** [DavideBorghi.ItalianDotNetDateTimeUtils](../../index.md)  
**Assembly:** DavideBorghi.ItalianDotNetDateTimeUtils  
**Assembly Version:** 2.0.0+11b385815d24cc7747d25bd6e9b11b068538c4b2

Gets a DateTime list of yearly Italian holidays.

```csharp
public static IEnumerable<DateTime> GetYearlyItalianHolidays(int year);
```

## Parameters

`year`  int

The given year.

## Returns

IEnumerable\<DateTime\>

A list of yearly Italian holidays.

## Exceptions

ArgumentException

Thrown when provided year is before 1946.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*