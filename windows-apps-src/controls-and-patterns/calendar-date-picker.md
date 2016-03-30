---
Xxxxxxxxxxx: Xxx xxxxxxxx xxxx xxxxxx xx x xxxx xxxx xxxxxxx xxxx’x xxxxxxxxx xxx xxxxxxx x xxxxxx xxxx xxxx x xxxxxxxx xxxx xxxxx xxxxxxxxxx xxxxxxxxxxx xxxx xxx xxx xx xxx xxxx xx xxxxxxxx xx xxx xxxxxxxx xx xxxxxxxxx.
xxxxx: Xxxxxxxx xxxx xxxxxx
xx.xxxxxxx: YxYYYYxY-YYYx-YYYY-xxYY-YxYYxxYYxxYY
xxxxx: Xxxxxxxx xxxx xxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxx xxxx xxxxxx

Xxx xxxxxxxx xxxx xxxxxx xx x xxxx xxxx xxxxxxx xxxx’x xxxxxxxxx xxx xxxxxxx x xxxxxx xxxx xxxx x xxxxxxxx xxxx xxxxx xxxxxxxxxx xxxxxxxxxxx xxxx xxx xxx xx xxx xxxx xx xxxxxxxx xx xxx xxxxxxxx xx xxxxxxxxx. Xxx xxx xxxxxx xxx xxxxxxxx xx xxxxxxx xxxxxxxxxx xxxxxxx xx xx xxxxx xxxxxxxxx xxxxx.

<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**XxxxXxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)
-   [**Xxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.time.aspx)

## Xx xxxx xxx xxxxx xxxxxxx?
Xxx x **xxxxxxxx xxxx xxxxxx** xx xxx x xxxx xxxx x xxxxxx xxxx xxxx x xxxxxxxxxx xxxxxxxx xxxx. Xxx xx xxx xxxxxx xxxx xxxxxxxx xx xxxxxxxxxxx xx xxxxxxxxx xxxx.

Xx xxx x xxxx xxxx x xxxxx xxxx, xxxx xx x xxxx xx xxxxx, xxxxx xxx xxxxxxx xx xxx xxxxxxxx xx xxx xxxxxxxxx, xxxxxxxx xxxxx x [**xxxx xxxxxx**](date-picker.md).

Xxx xxxx xxxx xxxxx xxxxxxxx xxx xxxxx xxxxxxx, xxx xxx [Xxxx xxx xxxx xxxxxxxx](date-and-time.md) xxxxxxx.

## Xxxxxxxx

Xxx xxxxx xxxxx xxxxxxxx xxxxxxxxxxx xxxx xx x xxxx xxx xxx xxxx xxx; xxxxxxxxx, xx xxxxxxxx xxx xxxxxx xxxx. Xxxx xxx xxxx xxxxxxx xxx xxxxx xxxxx, x xxxxxxxx xxxx xxxxxxx xxx xxx xxxx xx xxxx x xxxx xxxxxxxxx. Xxx xxxxxxxx xxxx xxxxxxxx xxxxx XX; xx xxxxx'x xxxx xxxxx XX xxx xx xxx xxx.

![Xxxxxxx xx xxxxxxxx xxxx xxxxxx](images/calendar-date-picker-2-views.png)

## Xxxxxx x xxxx xxxxxx

```xaml
<CalendarDatePicker x:Name="arrivalCalendarDatePicker" Header="Arrival date"/>
```

```csharp
CalendarDatePicker arrivalCalendarDatePicker = new CalendarDatePicker();
arrivalCalendarDatePicker.Header = "Arrival date";
```

Xxx xxxxxxxxx xxxxxxxx xxxx xxxxxx xxxxx xxxx xxxx:

![Xxxxxxx xx xxxxxxxx xxxx xxxxxx](images/calendar-date-picker-closed.png)

Xxx xxxxxxxx xxxx xxxxxx xxx xx xxxxxxxx [**XxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx) xxx xxxxxxx x xxxx. X xxxxxx xx XxxxxxxxXxxx xxxxxxxxxx, xxxx [**XxXxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.istodayhighlighted.aspx) xxx [**XxxxxXxxXxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.firstdayofweek.aspx), xxxxx xx XxxxxxxxXxxxXxxxxx xxx xxx xxxxxxxxx xx xxx xxxxxxxx XxxxxxxxXxxx xx xxx xxx xxxxxx xx. 

Xxxxxxx, xxx xxx'x xxxxxx xxx [**XxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectionmode.aspx) xx xxx xxxxxxxx XxxxxxxxXxxx xx xxxxx xxxxxxxx xxxxxxxxx. Xx xxx xxxx xx xxx x xxxx xxxx xxxxxxxx xxxxx xx xxxx x xxxxxxxx xx xx xxxxxx xxxxxxx, xxxxxxxx xxxxx x xxxxxxxx xxxx xxxxxxx xx x xxxxxxxx xxxx xxxxxx. Xxx xxx [Xxxxxxxx xxxx](calendar-view.md) xxxxxxx xxx xxxx xxxx xx xxx xxx xxx xxxxxx xxx xxxxxxxx xxxxxxx.

### Xxxxxxxxx xxxxx

Xxx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.date.aspx) xxxxxxxx xx xxx xx xxx xxx xxxxxxxx xxxx. Xx xxxxxxx, xxx Xxxx xxxxxxxx xx **xxxx**. Xxxx x xxxx xxxxxxx x xxxx xx xxx xxxxxxxx xxxx, xxxx xxxxxxxx xx xxxxxxx. X xxxx xxx xxxxx xxx xxxx xx xxxxxxxx xxx xxxxxxxx xxxx xx xxx xxxxxxxx xxxx xx xxxxxxxx xx. 

Xxx xxx xxx xxx xxxx xx xxxx xxxx xxxx xxxx.

```csharp
myCalendarDatePicker.Date = new DateTime(1977, 1, 5);
```

Xxxx xxx xxx xxx Xxxx xx xxxx, xxx xxxxx xx xxxxxxxxxxx xx xxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.mindate.aspx) xxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.maxdate.aspx) xxxxxxxxxx.
- Xx **Xxxx** xx xxxxxxx xxxx **XxxXxxx**, xxx xxxxx xx xxx xx **XxxXxxx**.
- Xx **Xxxx** xx xxxxxxx xxxx **XxxXxxx**, xxx xxxxx xx xxx xx **XxxXxxx**.

Xxx xxx xxxxxx xxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.datechanged.aspx) xxxxx xx xx xxxxxxxx xxxx xxx Xxxx xxxxx xxx xxxxxxx.

> **Xxxx**&xxxx;&xxxx;Xxx xxxxxxxxx xxxx xxxxx xxxx xxxxxx, xxx [XxxxXxxx xxx Xxxxxxxx xxxxxx](date-and-time.md#datetime-and-calendar-values) xx xxx Xxxx xxx xxxx xxxxxxxx xxxxxxx.

### Xxxxxxx x xxxxxx xxx xxxxxxxxxxx xxxx

Xxx xxx xxx x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.header.aspx) (xx xxxxx) xxx [**XxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.placeholdertext.aspx) (xx xxxxxxxxx) xx xxx xxxxxxxx xxxx xxxxxx xx xxxx xxx xxxx xx xxxxxxxxxx xx xxxx xx'x xxxx xxx. Xx xxxxxxxxx xxx xxxx xx xxx xxxxxx, xxx xxx xxx xxx [**XxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.headertemplate.aspx) xxxxxxxx xxxxxxx xx Xxxxxx.

Xxx xxxxxxx xxxxxxxxxxx xxxx xx "xxxxxx x xxxx". Xxx xxx xxxxxx xxxx xx xxxxxxx xxx XxxxxxxxxxxXxxx xxxxxxxx xx xx xxxxx xxxxxx, xx xxx xxx xxxxxxx xxxxxx xxxx xx xxxxx xxxx.

```xaml
<CalendarDatePicker x:Name="arrivalCalendarDatePicker" Header="Arrival date" PlaceholderText="Choose your arrival date"/>
```


\[Xxxx xxxxxxx xxxxxxxx xxxxxxxxxxx xxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx Xxxxxxx YY. Xxx Xxxxxxx Y.Y xxxxxxxx, xxxxxx xxxxxxxx xxx [Xxxxxxx Y.Y xxxxxxxxxx XXX](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Xxxxxxx xxxxxx

* [Xxxx xxx xxxx xxxxxxxx](date-and-time.md)
* [Xxxxxxxx xxxx](calendar-view.md)
* [Xxxx xxxxxx](date-picker.md)
* [Xxxx xxxxxx](time-picker.md)
<!--HONumber=Mar16_HO1-->
