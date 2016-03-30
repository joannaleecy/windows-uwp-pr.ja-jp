---
Xxxxxxxxxxx: X xxxxxxxx xxxx xxxx x xxxx xxxx xxx xxxxxxxx xxxx x xxxxxxxx xxxx xxxx xxx xxxxxxxx xx xxxxx, xxxx, xx xxxxxx.
xxxxx: Xxxxxxxx xxxx
xx.xxxxxxx: xYxxYxxY-YxYx-YYYx-xYxY-YxYxYYYxYxYY
xxxxx: Xxxxxxxx xxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxx xxxx

X xxxxxxxx xxxx xxxx x xxxx xxxx xxx xxxxxxxx xxxx x xxxxxxxx xxxx xxxx xxx xxxxxxxx xx xxxxx, xxxx, xx xxxxxx. X xxxx xxx xxxxxx x xxxxxx xxxx xx x xxxxx xx xxxxx. Xx xxxxx'x xxxx x xxxxxx xxxxxxx xxx xxx xxxxxxxx xx xxxxxx xxxxxxx. 

<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

- [**XxxxxxxxXxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)
- [**Xxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.date.aspx)

## Xx xxxx xxx xxxxx xxxxxxx?
Xxx x xxxxxxxx xxxx xx xxx x xxxx xxxx x xxxxxx xxxx xx x xxxxx xx xxxxx xxxx xx xxxxxx xxxxxxx xxxxxxxx.

Xx xxx xxxx xx xxx x xxxx xxxxxx xxxxxxxx xxxxx xx xxx xxxx, xxx xxxx xxx x xxxxxxxx xxxx. Xx xxx xxxx xx xxx x xxxx xxxx xxxx x xxxxxx xxxx xxx xxx’x xxxx x xxxxxxxx xx xx xxxxxx xxxxxxx, xxxxxxxx xxxxx x [xxxxxxxx xxxx xxxxxx](calendar-date-picker.md) xx [xxxx xxxxxx](date-picker.md) xxxxxxx.

Xxx xxxx xxxx xxxxx xxxxxxxx xxx xxxxx xxxxxxx, xxx xxx [Xxxx xxx xxxx xxxxxxxx](date-and-time.md) xxxxxxx.

## Xxxxxxxx

Xxx xxxxxxxx xxxx xx xxxx xx xx Y xxxxxxxx xxxxx: xxx xxxxx xxxx, xxxx xxxx, xxx xxxxxx xxxx. Xx xxxxxxx, xx xxxxxx xxxx xxx xxxxx xxxx xxxx. Xxx xxx xxxxxxx x xxxxxxx xxxx xx xxxxxxx xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.displaymode.aspx) xxxxxxxx.

![Xxx Y xxxxx xx x xxxxxxxx xxxx](images/calendar-view-3-views.png)

Xxxxx xxxxx xxx xxxxxx xx xxx xxxxx xxxx xx xxxx xxx xxxx xxxx, xxx xxxxx xxx xxxxxx xx xxx xxxx xxxx xx xxxx xxx xxxxxx xxxx. Xxxxx xxxx x xxxx xx xxx xxxxxx xxxx xx xxxxxx xx xxx xxxx xxxx, xxx xxxx x xxxxx xx xxx xxxx xxxx xx xxxxxx xx xxx xxxxx xxxx. Xxx xxx xxxxxx xx xxx xxxx xx xxx xxxxxx xxxxxxxx xxxxxxx xx xxxxxxxx xx xxxxx, xx xxxx, xx xx xxxxxx. 

## Xxxxxx x xxxxxxxx xxxx

Xxxx xxxxxxx xxxxx xxx xx xxxxxx x xxxxxx xxxxxxxx xxxx.

```xaml
<CalendarView/>
```

Xxx xxxxxxxxx xxxxxxxx xxxx xxxxx xxxx xxxx:

![Xxxxxxx xx xxxxxxxx xxxx](images/controls_calendar_monthview.png)

### Xxxxxxxxx xxxxx

Xx xxxxxxx, xxx [**XxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectionmode.aspx) xxxxxxxx xx xxx xx **Xxxxxx**. Xxxx xxxx x xxxx xxxx x xxxxxx xxxx xx xxx xxxxxxxx. Xxx XxxxxxxxxXxxx xx **Xxxx** xx xxxxxxx xxxx xxxxxxxxx. 

Xxx XxxxxxxxxXxxx xx **Xxxxxxxx** xx xxx x xxxx xxxxxx xxxxxxxx xxxxx. Xxx xxx xxxxxx xxxxxxxx xxxxx xxxxxxxxxxxxxxxx xx xxxxxx [XxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx)/[XxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) xxxxxxx xx xxx [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddates.aspx) xxxxxxxxxx, xx xxxxx xxxx:

```csharp
calendarView1.SelectedDates.Add(DateTimeOffset.Now);
calendarView1.SelectedDates.Add(new DateTime(1977, 1, 5));
```

X xxxx xxx xxxxxxxx x xxxxxxxx xxxx xx xxxxxxxx xx xxxxxxx xx xx xxx xxxxxxxx xxxx.

Xxx xxx xxxxxx xxx [**XxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddateschanged.aspx) xxxxx xx xx xxxxxxxx xxxx xxx [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddates.aspx) xxxxxxxxxx xxx xxxxxxx.

> **Xxxx**&xxxx;&xxxx;Xxx xxxxxxxxx xxxx xxxxx xxxx xxxxxx, xxx [XxxxXxxx xxx Xxxxxxxx xxxxxx](date-and-time.md#datetime-and-calendar-values) xx xxx Xxxx xxx xxxx xxxxxxxx xxxxxxx.

### Xxxxxxxxxxx xxx xxxxxxxx xxxx'x xxxxxxxxxx

Xxx xxxxxxxx xxxx xx xxxxxxxx xx xxxx XXXX xxxxxxxx xxxxxxx xx xxx XxxxxxxXxxxxxxx xxx xxxxxx xxxxxxxx xxxxxxxx xxxxxxxx xx xxx xxxxxxx. 
- Xxx XXXX xxxxxxxx xxxxxxx xx xxx xxxxxxx xxxxxxxx xxxxxxx xxx xxxxxx xxxx xxxxxxxx xxx xxxxxxx, xxx xxxxxx, xxxxxxxx xxx xxxx xxxxxxx, xxx XxxXxXxxx xxxxxxxx. Xxx xxx xxxxx xxx xx-xxxxxxxx xxxxx xxxxxxxx xxxx xxx XXXX xxxxxxx. 
- Xxx xxxxxxxx xxxx xx xxxxxxxx xx [**XxxxxxxxXxxxXxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) xxxxxxx. Xxx xxx’x xxxxx xx xx-xxxxxxxx xxxxx xxxxxxxx, xxx xxxxxxx xxxxxxxxxx xxx xxxxxxxx xx xxx xxx xx xxxxxxxxx xxxxx xxxxxxxxxx.

Xxxx xxxxxxx xxxxx xxx xxxxxxxx xxxx xxxx xx xxx xxxxx xxxx xx xxx xxxxxxxx. Xxx xxxx xxxx, xxx xxx Xxxxxxx xx xxx [**XxxxxxxxXxxxXxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) xxxxx.

![Xxx xxxxxxxx xx x xxxxxxxx xxxxx xxxx](images/calendar-view-month-elements.png)

Xxxx xxxxx xxxxx xxx xxxxxxxxxx xxx xxx xxxxxx xx xxxxxx xxx xxxxxxxxxx xx xxxxxxxx xxxxxxxx.

Xxxxxxx | Xxxxxxxxxx
--------|-----------
XxxXxXxxx | [XxxXxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayofweekformat.aspx)  
XxxxxxxxXxxx | [XxxxxxxxXxxxXxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritembackground.aspx), [XxxxxxxxXxxxXxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemborderbrush.aspx), [XxxxxxxxXxxxXxxxxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemborderthickness.aspx), [XxxxxxxxXxxxXxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemforeground.aspx)  
XxxXxxx | [XxxXxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontfamily.aspx), [XxxXxxxXxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontsize.aspx), [XxxXxxxXxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontstyle.aspx), [XxxXxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontweight.aspx), [XxxxxxxxxxXxxXxxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.horizontaldayitemalignment.aspx), [XxxxxxxxXxxXxxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.verticaldayitemalignment.aspx), [XxxxxxxxXxxxXxxXxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendarviewdayitemstyle.aspx)  
XxxxxXxxxXxxx (xx xxx xxxx xxx xxxxxx xxxxx, xxxxxxxxxx xx XxxXxxx) | [XxxxxXxxxXxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontfamily.aspx), [XxxxxXxxxXxxxXxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontsize.aspx), [XxxxxXxxxXxxxXxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontstyle.aspx), [XxxxxXxxxXxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontweight.aspx)  
XxxxxXxXxxxxXxxxx | [XxxxxXxXxxxxXxxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontfamily.aspx), [XxxxxXxXxxxxXxxxxXxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontsize.aspx), [XxxxxXxXxxxxXxxxxXxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontstyle.aspx), [XxxxxXxXxxxxXxxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontweight.aspx), [XxxxxxxxxxXxxxxXxXxxxxXxxxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.horizontalfirstofmonthlabelalignment.aspx), [XxxxxxxxXxxxxXxXxxxxXxxxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.verticalfirstofmonthlabelalignment.aspx), [XxXxxxxXxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.isgrouplabelvisible.aspx)  
XxxxxxxXxxxXxxxxxXxxxx (xx xxx xxxx xxx xxxxxx xxxxx, xxxxxxxxxx xx XxxxxXxXxxxxXxxxx) | [XxxxxXxXxxxXxxxxxXxxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontfamily.aspx), [XxxxxXxXxxxXxxxxxXxxxxXxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontsize.aspx), [XxxxxXxXxxxXxxxxxXxxxxXxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontstyle.aspx), [XxxxxXxXxxxXxxxxxXxxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontweight.aspx)  
Xxxxxx Xxxxx Xxxxxxx | [XxxxxXxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.focusborderbrush.aspx), [XxxxxXxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.hoverborderbrush.aspx), [XxxxxxxXxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.pressedborderbrush.aspx), [XxxxxxxxXxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedborderbrush.aspx), [XxxxxxxxXxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedforeground.aspx), [XxxxxxxxXxxxxXxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedhoverborderbrush.aspx), [XxxxxxxxXxxxxxxXxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedpressedborderbrush.aspx)  
XxxxxXxxxx | [XxXxxXxXxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.isoutofscopeenabled.aspx), [XxxXxXxxxxXxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.outofscopebackground.aspx), [XxxXxXxxxxXxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.outofscopeforeground.aspx)  
Xxxxx | [XxXxxxxXxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.istodayhighlighted.aspx), [XxxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.todayfontweight.aspx), [XxxxxXxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.todayforeground.aspx)  

 Xx xxxxxxx, xxx xxxxx xxxx xxxxx Y xxxxx xx x xxxx. Xxx xxx xxxxxx xxx xxxxxx xx xxxxx xxxxx xx xxxxxxx xxx [**XxxxxxXxXxxxxXxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.numberofweeksinview.aspx) xxxxxxxx. Xxx xxxxxxx xxxxxx xx xxxxx xx xxxx xx Y; xxx xxxxxxx xx Y.

Xx xxxxxxx, xxx xxxx xxx xxxxxx xxxxx xxxx xx x YxY xxxx. Xx xxxxxx xxx xxxxxx xx xxxx xx xxxxxxx, xxxx [**XxxXxxxXxxxxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.setyeardecadedisplaydimensions.aspx) xxxx xxx xxxx xxxxxxx xxxxxx xx xxxx xxx xxxxxxx. Xxxx xxxx xxxxxx xxx xxxx xxx xxxx xxx xxxx xxx xxxxxx xxxxx.

Xxxx, xxx xxxx xxx xxxxxx xxxxx xxx xxx xx xxxx xx x YxY xxxx.

```csharp
calendarView1.SetYearDecadeDisplayDimensions(3, 4);
```

Xx xxxxxxx, xxx xxxxxxx xxxx xxxxx xx xxx xxxxxxxx xxxx xx YYY xxxxx xxxxx xx xxx xxxxxxx xxxx, xxx xxx xxxxxxx xxxx xxxxx xx YYY xxxxx xxxx xxx xxxxxxx xxxx. Xxx xxx xxxxxx xxx xxxxxxx xxx xxxxxxx xxxxx xxxx xxx xxxxxxxx xxxxx xx xxxxxxx xxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.mindate.aspx) xxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.maxdate.aspx) xxxxxxxxxx.

```csharp
calendarView1.MinDate = new DateTime(2000, 1, 1);
calendarView1.MaxDate = new DateTime(2099, 12, 31);
```

### Xxxxxxxx xxxxxxxx xxx xxxxx

Xxxx xxx xx xxx xxxxxxxx xx xxxxxxxxxxx xx x [**XxxxxxxxXxxxXxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) xxxxxx. Xx xxxxxx xx xxxxxxxxxx xxx xxxx xxx xxx xxx xxxxxxxxxx xxx xxxxxxx, xxxxxx xxx [**XxxxxxxxXxxxXxxXxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendarviewdayitemchanging.aspx) xxxxx xxx xxx xxx Xxxx xxxxxxxx xx xxx xxxxx xxxx xx xxxxxx xxx XxxxxxxxXxxxXxxXxxx.

Xxx xxx xxxx x xxx xxx xxxxxxxxxx xx xxx xxxxxxxx xxxx xx xxxxxxx xxx [**XxxxxxxxXxxxXxxXxxx.XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.isblackout.aspx) xxxxxxxx xx **xxxx**. 

Xxx xxx xxxx xxxxxxxxxx xxxxxxxxxxx xxxxx xxx xxxxxxx xx xxxxxx xx x xxx xx xxxxxxx xxx [**XxxxxxxxXxxxXxxXxxx.XxxXxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/dn890067.aspx) xxxxxx. Xxx xxx xxxx xxxx Y xx YY xxxxxxx xxxx xxx xxxx xxx, xxx xxx xxx xxxxx xx xxxx xxx. 

Xxxx xxx xxxx xxx xxxxx xx x xxxxxxxx. Xxxx Y xxx Y xxx xxxxxxx xxx. Xxxx Y, Y, xxx Y xxxx xxxxxxx xxxxxxx xxxx xxx.

![Xxxxxxxx xxxx xxxx xxxxxxx xxxx](images/calendar-view-density-bars.png)

### Xxxxxx xxxxxxxxx

X xxxxxxxx xxxx xxx xxxxxxx x xxxxx xxxxxx xx XxxxxxxxXxxxXxxXxxx xxxxxxx. Xx xxxx xxx XX xxxxxxxxxx xxx xxxxxx xxxxxx xxxxxxxxxx xxxxxxx xxx xxxxxxxx, xxxxxxxx xxxx xxxxxxxx xxxxxx xxxxxxxxx. Xxxx xxxx xxx xxxxx xx xxxxxxxxxx xx x xxx xxxx xxxx xxxxxx. Xx x xxx xx xxxxx xxx xx xxxx xxxxxx xxx xxx xxxxxx xxx xxxxxxxx, xx xxxx xxxx xx xxxx xxxxxx xx xxxxxxx xxx xxxxxx xxxx xxxx.

Xxxx xxxxxxx xxxxx xxxxxx xxxxxxxxx xx x xxxxxxxx xxxx xxx xxxxxxxxxx xxxxxxxxxxxx. 
- Xx xxxxx Y, xxx xxxxxxx xxx xxxx xx xxxxxxxx. 
- Xx xxxxx Y, xxx xxxxxxxx xxxxx xxxx xxx'x xx xxxxxx. Xxxx xxxxxxxx xxxx xxxxx, Xxxxxxx, xxx xxxxx xxxx xxx xxxxxxx xxxxx xxxxxx. 
- Xx xxxxx Y, xxx xxxxx xxxx xxxxxxxxxxx xxxx'x xxxxxx xxx xxx xxx. Xxx xxxx x xxxxx xxxxxxx xxx xxx xxxx xxxxxxxxx xxxxxxxxxxx xxx x xxxx xxxxxxx xxx xxx xxxx xxxxxxxxx xxxxxxxxxxx. 

Xxx `Bookings` xxxxx xx xxxx xxxxxxx xx xxxx x xxxxxxxxxx xxxxxxxxxxx xxxxxxx xxx, xxx xx xxx xxxxx.

```xaml
<CalendarView CalendarViewDayItemChanging="CalendarView_CalendarViewDayItemChanging"/>
```

```csharp
private void CalendarView_CalendarViewDayItemChanging(CalendarView sender, 
                                   CalendarViewDayItemChangingEventArgs args)
{
    // Render basic day items.
    if (args.Phase == 0)
    {
        // Register callback for next phase.
        args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
    }
    // Set blackout dates.
    else if (args.Phase == 1)
    {   
        // Blackout dates in the past, Sundays, and dates that are fully booked.
        if (args.Item.Date < DateTimeOffset.Now ||
            args.Item.Date.DayOfWeek == DayOfWeek.Sunday ||
            Bookings.HasOpenings(args.Item.Date) == false)
        {
            args.Item.IsBlackout = true;
        }
        // Register callback for next phase.
        args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
    }
    // Set density bars.
    else if (args.Phase == 2)
    {
        // Avoid unnecessary processing.
        // You don't need to set bars on past dates or Sundays.
        if (args.Item.Date > DateTimeOffset.Now &&
            args.Item.Date.DayOfWeek != DayOfWeek.Sunday)
        {
            // Get bookings for the date being rendered.
            var currentBookings = Bookings.GetBookings(args.Item.Date);

            List<Color> densityColors = new List<Color>();
            // Set a density bar color for each of the days bookings.
            // It's assumed that there can't be more than 10 bookings in a day. Otherwise,
            // further processing is needed to fit within the max of 10 density bars.
            foreach (booking in currentBookings)
            {
                if (booking.IsConfirmed == true)
                {
                    densityColors.Add(Colors.Green);
                }
                else
                {
                    densityColors.Add(Colors.Blue);
                }
            }
            args.Item.SetDensityColors(densityColors);
        }
    }
}
```
\[Xxxx xxxxxxx xxxxxxxx xxxxxxxxxxx xxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx Xxxxxxx YY. Xxx Xxxxxxx Y.Y xxxxxxxx, xxxxxx xxxxxxxx xxx [Xxxxxxx Y.Y xxxxxxxxxx XXX](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Xxxxxxx xxxxxx

* [Xxxx xxx xxxx xxxxxxxx](date-and-time.md)
* [Xxxxxxxx xxxx xxxxxx](calendar-date-picker.md)
* [Xxxx xxxxxx](date-picker.md)
* [Xxxx xxxxxx](time-picker.md)
<!--HONumber=Mar16_HO1-->
