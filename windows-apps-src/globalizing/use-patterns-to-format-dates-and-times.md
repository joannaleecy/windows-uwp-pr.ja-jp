---
Xxxxxxxxxxx: Xxx xxx Xxxxxxx.Xxxxxxxxxxxxx.XxxxXxxxXxxxxxxxxx XXX xxxx xxxxxx xxxxxxxx xx xxxxxxx xxxxx xxx xxxxx xx xxxxxxx xxx xxxxxx xxx xxxx.
xxxxx: Xxx xxxxxxxx xx xxxxxx xxxxx xxx xxxxx
xx.xxxxxxx: YYYYYYXY-YXXY-YXYY-YXYX-YXYYXXXYXYXX
xxxxx: Xxx xxxxxxxx xx xxxxxx xxxxx xxx xxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxx xxxxxxxx xx xxxxxx xxxxx xxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.Xxxxxxxxxxxxx.XxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206859)
-   [**XxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206828)
-   [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br206576)

Xxx xxx [**Xxxxxxx.Xxxxxxxxxxxxx.XxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206859) XXX xxxx xxxxxx xxxxxxxx xx xxxxxxx xxxxx xxx xxxxx xx xxxxxxx xxx xxxxxx xxx xxxx.

## <span id="Introduction">
            </span>
            <span id="introduction">
            </span>
            <span id="INTRODUCTION">
            </span>Xxxxxxxxxxxx


[
            **Xxxxxxx.Xxxxxxxxxxxxx.XxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206859) xxxxxxxx xxxxxxx xxxx xx xxxxxxxx xxxxxx xxxxx xxx xxxxx xxx xxxxxxxxx xxx xxxxxxx xxxxxx xxx xxxxx. Xxx xxx xxx xxxxxxxx xxxxxxx xxx xxxx, xxxxx, xxx, xxx xx xx, xx xxx xxx xxx xxxxxxxx xxxxxx xxxxxxxxx, xxxx xx "xxxxxxxx" xx "xxxxx xxx".

Xxx xxxx xxx xxxx xxxx xxxxxxx xxxx xxx xxxxx xxx xxxxxx xx xxx xxxxxxxxxxxx xx xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br206576) xxxxxx xxx xxxx xx xxxxxxx, xxx xxx xxx x xxxxxxx xxxxxx xxx xxx xxxxxx xxxxxxxx xxxxxxxxx, xxxxxx x "xxxxxxx". Xxx xxxxxxx xxxxxx xxxxxx xxx xx xxxxxx xxxxxxxxxx xxxxxxxxxxxx xx x **XxxxXxxx** xxxxxx—xxxx xxx xxxxx xxxx, xx xxxx xxx xxxx xxxxx, xxx xxxxxxx—xx xxxxx xx xxxxxxx xxxx xx xxxxxxxx xxxxxx xxxxxx xxx xxxxxx. Xxxxxxxxxxx, xxx xxxxxxx xxx xx xxxxxxxxx xx xxxxx xx xxxxx xxxxxxxxx xxx xxxxxxx.

**Xxxx**  Xxxx xx xx xxxxxxxx xx xxxxxx xxxxxxxx. Xxx x xxxx xxxxxxxx xxxxxxxxxx xx xxxxxx xxxxxxxxx xxx xxxxxx xxxxxxxx xxx xxx Xxxxxxx xxxxxxx xx xxx [**XxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206828) xxxxx.

 

## <span id="What_you_need_to_know">
            </span>
            <span id="what_you_need_to_know">
            </span>
            <span id="WHAT_YOU_NEED_TO_KNOW">
            </span>Xxxx xxx xxxx xx xxxx


Xx'x xxxxxxxxx xx xxxx xxxx xxxx xxx xxx xxxxxxxx, xxx xxx xxxxxxxx x xxxxxx xxxxxx xxxx xx xxx xxxxxxxxxx xx xx xxxxx xxxxxx xxxxxxxx. Xxx xxxxxxx, xxxxxxxx xxx "xxxxx xxx" xxxxxxxx:

**X#**
```CSharp
var datefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
```
**XxxxXxxxxx**
```JavaScript
var datefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
```

Xxxx xxxxxxx x xxxxxxxxx xxxxx xx xxx xxxxxxxx xxx xxxxxx xxxxx xx xxx xxxxxxx xxxxxxx. Xxxxxxxxx, xx xxxxxx xxxxxxxx xxx xxxxx xxx xxx xxxxxxxx xx xx xxxxxxxxxxx xxxxxx xxxxxx. Xxx xxxxxxx, xx xxxxxxxx "Xxxxxxx Y" xxx Xxxxxxx (XX), xxx "Y xxxxxxx" xxx Xxxxxx (Xxxxxx) xxx "Y月Y日" xxx Xxxxxxxx. Xxxx xx xxxxxxx xxx xxxxxxxx xx xxxxx xx x xxxxxxx-xxxxxxxx xxxxxxx xxxxxx, xxxxx xxx xx xxxxxxxx xxx xxx xxxxxxx xxxxxxxx:

**X#**
```CSharp
var monthdaypattern = datefmt.Patterns;
```
**XxxxXxxxxx**
```JavaScript
var monthdaypattern = datefmt.patterns;
```

Xxxx xxxxxx xxxxxxxxx xxxxxxx xxxxxxxxx xx xxx xxxxxxxx xxx xxxxxx xx xxx xxxxxxxxx. Xxxx xxxx xxxxxxxxx xxxxxxx xxx xxx xxxxxxxxx xxxxxxxxxxxx, xx xxxxxxxxx xxxxxx, xxxx xx xxxxxxx xxxxxxxxxx xxxxxxxxxx xxx xxxxxxx:

``` syntax
En-US: "{month.full} {day.integer}"
Fr-FR: "{day.integer} {month.full}"
Ja-JP: "{month.integer}月{day.integer}日"
```

Xxx xxx xxx xxxxxxxx xx xxxxxxxxx x xxxxxx [**XxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206828), xxx xxxxxxxx xxxx xxx xxxxx xx xxx XX Xxxxxxx xxxxxxx:

**X#**
```CSharp
var datefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("{month.full} {day.integer}");
```
**XxxxXxxxxx**
```JavaScript
var datefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("{month.full} {day.integer}");
```

Xxxxxxx xxxxxxx xxxxxxx-xxxxxxxx xxxxxx xxx xxx xxxxxxxxxx xxxxxxxxxxxx xxxxxx xxx xxxxxxxx {}. Xxx xxxx xxx xxxxxxx xxxxxx, xxx xxxxxxxxxxx xxxxx xx xxxxxxxxx. Xxx xxx xxxxxxxxx xxxx xxx xxx xxx, xxxxx xxx xxx xx xxxxxxxxxx xxxxxxxxxxx:

``` syntax
En-US: January 1
Fr-FR: janvier 1 (inappropriate for France; non-standard order)
Ja-JP: 1月1 (inappropriate for Japan; the day symbol is missing)
```

Xxxxxxxxxxx, xxxxxxxx xxx xxx xxxxxxxxxx xx xxxxxx xxxxxxxxxx xxxx xxxx. Xxxxxxxxx xx xxxxxxx xxx xxxxxx xxxxx xxxxxxxx xxxxxxx, xxxxx xxxxxx x xxxxxx xxxxxxxx. Xxxxxxx xxxxxxx xxx xxxxxx xx xxx xxxxxxxxxx xx xxxxxxxxxxx xxxx xxxxxxx. Xxxxxxxxx, xxx xxxxxx xxxx xxx xxx xxxxxxx xxxxxx xxx xxxxxxxxxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br206576)x xxxx:

-   Xxx xxx xxx xxxxxxxxx xx x xxxxxxxxxx xxxxxx xxx x xxxxxx.
-   Xxx xx xxx xxxx xxx xxxxxx xx xxxxxx xxxx xxxxxxx-xxxxxxxx xxxxxxxx.
-   Xxx xxxxxxxxxxxx xxxxxx xxx xxxxxxx xx xx xxxxxxxxx xxxxxx xxxxxxxx.
-   Xxx xxxxxx xx xxxxxxxx xxx xxxxxxx.

Xx xxxxxxxxx xxx xxxxxxxxxxx xxxxxxx xxx xxxxxxxx xxxxxx xxxxxxxxx xxx xxx-xxxxxxxx xxxxxx xxxxxxxx:

**Xxxxxx xxxxxxxxx, xxxx xx "xxxxx xxx":**

-   Xxxxxxxxxx xxxxxxxxxxxxxx xx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br206576) xxxxxx xxxx xxxxxxxx xxxxxx xxx xxx xxxxx xxx xxx xxx, xx xxxx xxxxx.
-   Xxxxxxxxxx xx xxxxxx x xxxxx xxxxxxxx xxxxxx xxxxxx xxx xxxxxxxx-xxxxxx xxxxxx xxxxxxxxx xx Xxxxxxx.
-   Xxxxxxxxxx xx xxxx xxx x xxxxxxxxxx-xxxxxxxxxxx xxxxxxxxx xxxxxx xxx xxx xxxxx xxxxxxxx-xxxxxx.
-   Xxx xxx xxxxxxxxxxxx xx xxxxxxxxxxxx xxx xxxxx. Xxx xxxxxxx, xxxxx xx xx xxxxxx xxxxxxxx xxx "xxxxxxxxx xxx".

**Xxxxxx xxxxxxxx, xxxx xx "{xxxxx.xxxx} {xxx.xxxxxxx}":**

-   Xxxxxxxxxx xxxxxxx xxxxxx xxxx xxxxxxxxx xxx xxxx xxxxx xxxx, xxxxxxxx xx x xxxxx, xxxxxxxx xx xxx xxx xxxxxxx, xx xxxx xxxxx.
-   Xxx xxx xxxxxxxxxx xx x xxxxx xxxxxxxx xxxxxx xxx xxx xxxxxxxx-xxxxxx xxxx.
-   Xxx xxxxxxxxxx xx xx xxxxxxxxxx xxxxxxxxxxx.
-   Xxx xxxxxxxxxxx xx xxxxxxxxxxxx xxx xx xxxxxxxxx, xx xxx xxxxx.

## <span id="Tasks">
            </span>
            <span id="tasks">
            </span>
            <span id="TASKS">
            </span>Xxxxx


Xxxxxxx xxx xxxx xx xxxxxxx xxx xxxxxxx xxxxx xxx xxx xxxxxxxx xxxx xxx xxxxxxx xxxx, xx x xxxxxxxx xxxxxx. Xxx xxxxxxx, xxx xxxxx xxxx XX Xxxxxxx xxxxx xx xxx xxxxxxxxx xxxx xxxx:

``` syntax
June 25 | 1:38 PM
```

Xxx xxxx xxxx xxxxxxxxxxx xx xxx "xxxxx xxx" xxxxxxxx, xxx xxx xxxx xxxx xxxxxxxxxxx xx xxx "xxxx xxxxxx" xxxxxxxx. Xx, xxx xxx xxxxxx x xxxxxx xxxxxx xxxx xxxxxxxxxxxx xxx xxxxxxxx xxxxx xxxx xx xxxxx xxxxxxxxx.

Xxxxx, xxx xxx xxxxxxxxxx xxx xxx xxxxxxxx xxxx xxx xxxx xxxxxxxxx, xxx xxxx xxx xxx xxxxxxxx xx xxxxx xxxxxxxxx:

**X#**
```CSharp
// Get formatters for the date part and the time part.
var mydate = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
var mytime = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("hour minute");

// Get the patterns from these formatters.
var mydatepattern = mydate.Patterns[0];
var mytimepattern = mytime.Patterns[0];
```
**XxxxXxxxxx**
```JavaScript
// Get formatters for the date part and the time part.
var dtf = Windows.Globalization.DateTimeFormatting;
var mydate = dtf.DateTimeFormatter("month day");
var mytime = dtf.DateTimeFormatter("hour minute");

// Get the patterns from these formatters.
var mydatepattern = mydate.patterns[0];
var mytimepattern = mytime.patterns[0];
```

Xxx xxxxxx xxxxx xxxx xxxxxx xxxxxx xx x xxxxxxxxxxx xxxxxxxx xxxxxx. Xxx xxxxxxx, xxx xxxxxx xxx Xxxxxxx (Xxxxxx Xxxxxx) xxxxx xx "{xxxx} | {xxxx}". Xxxxxxxxxx xxx xxxxxx xxxx xxxxxx xx xxxxxx. Xxx xxxxxxx, xxxx xxx xxxxxx xxx xxxxx xx xxx xxxxxxxxxxxx, xx xx xxxxx xxxx xxxxxxx xx xxxx xxxxxxxx xx xxxxxx xx xxxx xxx xxxx xxxxxxx xxx xxxx. Xx, xxxx xxx xxxxxxx "|" xxxx xxxx xxxxx xxxxxxxxx xxxxxxxxx. Xx xxxxxxx xxx xxxxxxx xxx {xxxx} xxx {xxxx} xxxxxxxx xx xxx xxxxxx xxxx xxx xxxxxxxx xxxxxxx:

**X#**
```CSharp
// Assemble the custom pattern. This string comes from a resource, and should be localizable. 
var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();
var mydateplustime = resourceLoader.GetString("date_plus_time");
mydateplustime = mydateplustime.replace("{date}", mydatepattern);
mydateplustime = mydateplustime.replace("{time}", mytimepattern);
```
**XxxxXxxxxx**
```JavaScript
// Assemble the custom pattern. This string comes from a resource, and should be localizable. 
var mydateplustime = WinJS.Resources.getString("date_plus_time");
mydateplustime = mydateplustime.replace("{date}", mydatepattern);
mydateplustime = mydateplustime.replace("{time}", mytimepattern);
```

Xxxx xxx xxx xxxxxxxxx x xxx xxxxxxxxx xxxxx xx xxx xxxxxx xxxxxxx:

**X#**
```CSharp
// Get the custom formatter.
var mydateplustimefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter(mydateplustime);
```
**XxxxXxxxxx**
```JavaScript
// Get the custom formatter.
var mydateplustimefmt = new dtf.DateTimeFormatter(mydateplustime);
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxx


* [Xxxx xxx xxxx xxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=231618)
* [**Xxxxxxx.Xxxxxxxxxxxxx.XxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206859)
* [**Xxxxxxx.Xxxxxxxxxx.XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br206576)
 

 



<!--HONumber=Mar16_HO1-->
