---
Description: Develop a global-ready app by appropriately formatting dates, times, numbers, and currencies.
title: Use global-ready formats
ms.assetid: 6ECE8BA4-9A7D-49A6-81EE-AB2BE7F0254F
label: Use global-ready formats
template: detail.hbs
---

# <span id="dev_globalizing.use_global-ready_formats"></span>Use global-ready formats


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Important APIs**

-   [**Windows.Globalization.Calendar**](https://msdn.microsoft.com/library/windows/apps/br206724)
-   [**Windows.Globalization.DateTimeFormatting**](https://msdn.microsoft.com/library/windows/apps/br206859)
-   [**Windows.Globalization.NumberFormatting**](https://msdn.microsoft.com/library/windows/apps/br226136)

Develop a global-ready app by appropriately formatting dates, times, numbers, and currencies. This permits you to adapt it later for additional cultures, regions, and languages in the global market.

## <span id="Introduction"></span><span id="introduction"></span><span id="INTRODUCTION"></span>Introduction


Many app developers naturally create their apps thinking only of their own language and culture. But when the app begins to grow into other markets, adapting the app for new languages and regions can be difficult in unexpected ways. For example, dates, times, numbers, calendars, currency, telephone numbers, units of measurement, and paper sizes are all items that can be displayed differently in different cultures or languages.

The process of adapting to new markets can be simplified by taking a few things into account as you develop your app.

## <span id="Prerequisites"></span><span id="prerequisites"></span><span id="PREREQUISITES"></span>Prerequisites


[Plan for a global market](https://msdn.microsoft.com/library/windows/apps/hh465405)
## <span id="Tasks"></span><span id="tasks"></span><span id="TASKS"></span>Tasks


1.  **Format dates and times appropriately.**

    There are many different ways to properly display dates and times. Different regions and cultures use different conventions for the order of day and month in the date, for the separation of hours and minutes in the time, and even for what punctuation is used as a separator. In addition, dates may be displayed in various long formats ("Wednesday, March 28, 2012") or short formats ("3/28/12"), which can vary across cultures. And of course, the names and abbreviations for the days of the week and months of the year differ for every language.

    If you need to allow users to choose a date or select a time, use the standard [date and time picker](https://msdn.microsoft.com/library/windows/apps/hh465466) controls. These will automatically use the date and time formats for the user's preferred language and region.

    If you need to display dates or times yourself, use [**Date/Time**](https://msdn.microsoft.com/library/windows/apps/br206859) and [**Number**](https://msdn.microsoft.com/library/windows/apps/br226136) formatters to automatically display the user's preferred format for dates, times and numbers. The code below formats a given DateTime by using the preferred language and region. For example, if the current date is 3 June 2012, the formatter gives "6/3/2012", if the user prefers English (United States), but it gives "03.06.2012" if the user prefers German (Germany):

    **C#**
    ```    CSharp
    // Use the Windows.Globalization.DateTimeFormatting.DateTimeFormatter class
    // to display dates and times using basic formatters.

    // Formatters for dates and times, using shortdate format.
    var sdatefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shortdate");
    var stimefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shorttime");

    // Obtain the date that will be formatted.
    var dateToFormat = DateTime.Now;

    // Perform the actual formatting.
    var sdate = sdatefmt.Format(dateToFormat);
    var stime = stimefmt.Format(dateToFormat);

    // Results for display.
    var results = "Short Date: " + sdate + "\n" +
                  "Short Time: " + stime;
    ```
    **JavaScript**
    ```    JavaScript
    // Use the Windows.Globalization.DateTimeFormatting.DateTimeFormatter class
    // to display dates and times using basic formatters.

    // Formatters for dates and times, using shortdate format.
    var sdatefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shortdate");
    var stimefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shorttime");

    // Obtain the date that will be formatted.
    var dateToFormat = new Date();

    // Perform the actual formatting.
    var sdate = sdatefmt.format(dateToFormat);
    var stime = stimefmt.format(dateToFormat);

    // Results for display.
    var results = "Short Date: " + sdate + "\n" +
                  "Short Time: " + stime;
    ```

2.  **Format numbers and currencies appropriately.**

    Different cultures format numbers differently. Format differences may include how many decimal digits to display, what characters to use as decimal separators, and what currency symbol to use. Use [**NumberFormatting**](https://msdn.microsoft.com/library/windows/apps/br226136) to display decimal, percent, or permille numbers, and currencies. In most cases you simply display numbers or currencies according to the user's current preferences. But you may also use the formatters to display a currency for a particular region or format.

    The code below gives an example of how to display currencies per the user's preferred language and region, or for a specific given currency system:

    **C#**
    ```    CSharp
    // This scenario uses the Windows.Globalization.NumberFormatting.CurrencyFormatter class
    // to format a number as a currency.

    // Determine the current user's default currency.
    var userCurrency = Windows.System.UserProfile.GlobalizationPreferences.Currencies[0];

    // Number to be formatted.
    var fractionalNumber = 12345.67;

    // Currency formatter using the current user's preference settings for number formatting.
    var userCurrencyFormat = new Windows.Globalization.NumberFormatting.CurrencyFormatter(userCurrency);
    var currencyDefault = userCurrencyFormat.Format(fractionalNumber);

    // Create a formatter initialized to a specific currency,
    // in this case US Dollar (specified as an ISO 4217 code) 
    // but with the default number formatting for the current user.
    var currencyFormatUSD = new Windows.Globalization.NumberFormatting.CurrencyFormatter("USD"); 
    var currencyUSD = currencyFormatUSD.Format(fractionalNumber);

    // Create a formatter initialized to a specific currency.
    // In this case it's the Euro with the default number formatting for France.
    var currencyFormatEuroFR = new Windows.Globalization.NumberFormatting.CurrencyFormatter("EUR", new[] { "fr-FR" }, "FR");
    var currencyEuroFR = currencyFormatEuroFR.Format(fractionalNumber);

    // Results for display.
    var results = "Fixed number (" + fractionalNumber + ")\n" +
                  "With user&#39;s default currency: " + currencyDefault + "\n" +
                  "Formatted US Dollar: " + currencyUSD + "\n" +
                  "Formatted Euro (fr-FR defaults): " + currencyEuroFR;
    ```
    **JavaScript**
    ```    JavaScript
    // This scenario uses the Windows.Globalization.NumberFormatting.CurrencyFormatter class
    // to format a number as a currency.

    // Determine the current user's default currency.
    var userCurrency = Windows.System.UserProfile.GlobalizationPreferences.currencies;

    // Number to be formatted.
    var fractionalNumber = 12345.67;

    // Currency formatter using the current user's preference settings for number formatting.
    var userCurrencyFormat = new Windows.Globalization.NumberFormatting.CurrencyFormatter(userCurrency);
    var currencyDefault = userCurrencyFormat.format(fractionalNumber);

    // Create a formatter initialized to a specific currency,
    // in this case US Dollar (specified as an ISO 4217 code) 
    // but with the default number formatting for the current user.
    var currencyFormatUSD = new Windows.Globalization.NumberFormatting.CurrencyFormatter("USD"); 
    var currencyUSD = currencyFormatUSD.format(fractionalNumber);

    // Create a formatter initialized to a specific currency.
    // In this case it's the Euro with the default number formatting for France.
    var currencyFormatEuroFR = new Windows.Globalization.NumberFormatting.CurrencyFormatter("EUR", ["fr-FR"], "FR");
    var currencyEuroFR = currencyFormatEuroFR.format(fractionalNumber);

    // Results for display.
    var results = "Fixed number (" + fractionalNumber + ")\n" +
                  "With user&#39;s default currency: " + currencyDefault + "\n" +
                  "Formatted US Dollar: " + currencyUSD + "\n" +
                  "Formatted Euro (fr-FR defaults): " + currencyEuroFR;
    ```

3.  **Use a culturally appropriate calendar.**

    The calendar differs across regions and languages. The Gregorian calendar is not the default for every region. Users in some regions may choose alternate calendars, such as the Japanese era calendar or Arabic lunar calendars. Dates and times on the calendar are also sensitive to different time zones and daylight saving time.

    Use the standard [date and time picker](https://msdn.microsoft.com/library/windows/apps/hh465466) controls to allow users to choose a date, to ensure that the preferred calendar format is used. For more complex scenarios, where working directly with operations on calendar dates may be required, Windows.Globalization provides a [**Calendar**](https://msdn.microsoft.com/library/windows/apps/br206724) class that gives an appropriate calendar representation for the given culture, region, and calendar type.

4.  **Respect the user's Language and Cultural Preferences.**

    For scenarios where you provide different functionality based on the user's language, region, or cultural preferences, Windows gives you a way to access those preferences, through [**Windows.System.UserProfile.GlobalizationPreferences**](https://msdn.microsoft.com/library/windows/apps/br241825). When needed, use the **GlobalizationPreferences** class to get the value of the user's current geographic region, preferred languages, preferred currencies, and so on.

## <span id="related_topics"></span>Related topics


* [Plan for a global market](https://msdn.microsoft.com/library/windows/apps/hh465405)
* [Guidelines for date and time controls](https://msdn.microsoft.com/library/windows/apps/hh465466)

**Reference**
* [**Windows.Globalization.Calendar**](https://msdn.microsoft.com/library/windows/apps/br206724)
* [**Windows.Globalization.DateTimeFormatting**](https://msdn.microsoft.com/library/windows/apps/br206859)
* [**Windows.Globalization.NumberFormatting**](https://msdn.microsoft.com/library/windows/apps/br226136)
* [**Windows.System.UserProfile.GlobalizationPreferences**](https://msdn.microsoft.com/library/windows/apps/br241825)

**Samples**
* [Calendar details and math sample](http://go.microsoft.com/fwlink/p/?linkid=231636)
* [Date and time formatting sample](http://go.microsoft.com/fwlink/p/?linkid=231618)
* [Globalization preferences sample](http://go.microsoft.com/fwlink/p/?linkid=231608)
* [Number formatting and parsing sample](http://go.microsoft.com/fwlink/p/?linkid=231620)
 

 





<!--HONumber=Mar16_HO1-->


