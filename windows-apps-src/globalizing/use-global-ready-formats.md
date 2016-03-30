---
Xxxxxxxxxxx: Xxxxxxx x xxxxxx-xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxxxx xxxxx, xxxxx, xxxxxxx, xxx xxxxxxxxxx.
xxxxx: Xxx xxxxxx-xxxxx xxxxxxx
xx.xxxxxxx: YXXXYXXY-YXYX-YYXY-YYXX-XXYXXYXYYYYX
xxxxx: Xxx xxxxxx-xxxxx xxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# <span id="dev_globalizing.use_global-ready_formats">
            </span>Xxx xxxxxx-xxxxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.Xxxxxxxxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206724)
-   [**Xxxxxxx.Xxxxxxxxxxxxx.XxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206859)
-   [**Xxxxxxx.Xxxxxxxxxxxxx.XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226136)

Xxxxxxx x xxxxxx-xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxxxx xxxxx, xxxxx, xxxxxxx, xxx xxxxxxxxxx. Xxxx xxxxxxx xxx xx xxxxx xx xxxxx xxx xxxxxxxxxx xxxxxxxx, xxxxxxx, xxx xxxxxxxxx xx xxx xxxxxx xxxxxx.

## <span id="Introduction">
            </span>
            <span id="introduction">
            </span>
            <span id="INTRODUCTION">
            </span>Xxxxxxxxxxxx


Xxxx xxx xxxxxxxxxx xxxxxxxxx xxxxxx xxxxx xxxx xxxxxxxx xxxx xx xxxxx xxx xxxxxxxx xxx xxxxxxx. Xxx xxxx xxx xxx xxxxxx xx xxxx xxxx xxxxx xxxxxxx, xxxxxxxx xxx xxx xxx xxx xxxxxxxxx xxx xxxxxxx xxx xx xxxxxxxxx xx xxxxxxxxxx xxxx. Xxx xxxxxxx, xxxxx, xxxxx, xxxxxxx, xxxxxxxxx, xxxxxxxx, xxxxxxxxx xxxxxxx, xxxxx xx xxxxxxxxxxx, xxx xxxxx xxxxx xxx xxx xxxxx xxxx xxx xx xxxxxxxxx xxxxxxxxxxx xx xxxxxxxxx xxxxxxxx xx xxxxxxxxx.

Xxx xxxxxxx xx xxxxxxxx xx xxx xxxxxxx xxx xx xxxxxxxxxx xx xxxxxx x xxx xxxxxx xxxx xxxxxxx xx xxx xxxxxxx xxxx xxx.

## <span id="Prerequisites">
            </span>
            <span id="prerequisites">
            </span>
            <span id="PREREQUISITES">
            </span>Xxxxxxxxxxxxx


[Xxxx xxx x xxxxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465405)
## <span id="Tasks">
            </span>
            <span id="tasks">
            </span>
            <span id="TASKS">
            </span>Xxxxx


1.  **Xxxxxx xxxxx xxx xxxxx xxxxxxxxxxxxx.**

    Xxxxx xxx xxxx xxxxxxxxx xxxx xx xxxxxxxx xxxxxxx xxxxx xxx xxxxx. Xxxxxxxxx xxxxxxx xxx xxxxxxxx xxx xxxxxxxxx xxxxxxxxxxx xxx xxx xxxxx xx xxx xxx xxxxx xx xxx xxxx, xxx xxx xxxxxxxxxx xx xxxxx xxx xxxxxxx xx xxx xxxx, xxx xxxx xxx xxxx xxxxxxxxxxx xx xxxx xx x xxxxxxxxx. Xx xxxxxxxx, xxxxx xxx xx xxxxxxxxx xx xxxxxxx xxxx xxxxxxx ("Xxxxxxxxx, Xxxxx YY, YYYY") xx xxxxx xxxxxxx ("Y/YY/YY"), xxxxx xxx xxxx xxxxxx xxxxxxxx. Xxx xx xxxxxx, xxx xxxxx xxx xxxxxxxxxxxxx xxx xxx xxxx xx xxx xxxx xxx xxxxxx xx xxx xxxx xxxxxx xxx xxxxx xxxxxxxx.

    Xx xxx xxxx xx xxxxx xxxxx xx xxxxxx x xxxx xx xxxxxx x xxxx, xxx xxx xxxxxxxx [xxxx xxx xxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465466) xxxxxxxx. Xxxxx xxxx xxxxxxxxxxxxx xxx xxx xxxx xxx xxxx xxxxxxx xxx xxx xxxx'x xxxxxxxxx xxxxxxxx xxx xxxxxx.

    Xx xxx xxxx xx xxxxxxx xxxxx xx xxxxx xxxxxxxx, xxx [**Xxxx/Xxxx**](https://msdn.microsoft.com/library/windows/apps/br206859) xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226136) xxxxxxxxxx xx xxxxxxxxxxxxx xxxxxxx xxx xxxx'x xxxxxxxxx xxxxxx xxx xxxxx, xxxxx xxx xxxxxxx. Xxx xxxx xxxxx xxxxxxx x xxxxx XxxxXxxx xx xxxxx xxx xxxxxxxxx xxxxxxxx xxx xxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx xxxx xx Y Xxxx YYYY, xxx xxxxxxxxx xxxxx "Y/Y/YYYY", xx xxx xxxx xxxxxxx Xxxxxxx (Xxxxxx Xxxxxx), xxx xx xxxxx "YY.YY.YYYY" xx xxx xxxx xxxxxxx Xxxxxx (Xxxxxxx):

    **X#**
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
    **XxxxXxxxxx**
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

2.  **Xxxxxx xxxxxxx xxx xxxxxxxxxx xxxxxxxxxxxxx.**

    Xxxxxxxxx xxxxxxxx xxxxxx xxxxxxx xxxxxxxxxxx. Xxxxxx xxxxxxxxxxx xxx xxxxxxx xxx xxxx xxxxxxx xxxxxx xx xxxxxxx, xxxx xxxxxxxxxx xx xxx xx xxxxxxx xxxxxxxxxx, xxx xxxx xxxxxxxx xxxxxx xx xxx. Xxx [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226136) xx xxxxxxx xxxxxxx, xxxxxxx, xx xxxxxxxx xxxxxxx, xxx xxxxxxxxxx. Xx xxxx xxxxx xxx xxxxxx xxxxxxx xxxxxxx xx xxxxxxxxxx xxxxxxxxx xx xxx xxxx'x xxxxxxx xxxxxxxxxxx. Xxx xxx xxx xxxx xxx xxx xxxxxxxxxx xx xxxxxxx x xxxxxxxx xxx x xxxxxxxxxx xxxxxx xx xxxxxx.

    Xxx xxxx xxxxx xxxxx xx xxxxxxx xx xxx xx xxxxxxx xxxxxxxxxx xxx xxx xxxx'x xxxxxxxxx xxxxxxxx xxx xxxxxx, xx xxx x xxxxxxxx xxxxx xxxxxxxx xxxxxx:

    **X#**
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
    **XxxxXxxxxx**
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

3.  **Xxx x xxxxxxxxxx xxxxxxxxxxx xxxxxxxx.**

    Xxx xxxxxxxx xxxxxxx xxxxxx xxxxxxx xxx xxxxxxxxx. Xxx Xxxxxxxxx xxxxxxxx xx xxx xxx xxxxxxx xxx xxxxx xxxxxx. Xxxxx xx xxxx xxxxxxx xxx xxxxxx xxxxxxxxx xxxxxxxxx, xxxx xx xxx Xxxxxxxx xxx xxxxxxxx xx Xxxxxx xxxxx xxxxxxxxx. Xxxxx xxx xxxxx xx xxx xxxxxxxx xxx xxxx xxxxxxxxx xx xxxxxxxxx xxxx xxxxx xxx xxxxxxxx xxxxxx xxxx.

    Xxx xxx xxxxxxxx [xxxx xxx xxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465466) xxxxxxxx xx xxxxx xxxxx xx xxxxxx x xxxx, xx xxxxxx xxxx xxx xxxxxxxxx xxxxxxxx xxxxxx xx xxxx. Xxx xxxx xxxxxxx xxxxxxxxx, xxxxx xxxxxxx xxxxxxxx xxxx xxxxxxxxxx xx xxxxxxxx xxxxx xxx xx xxxxxxxx, Xxxxxxx.Xxxxxxxxxxxxx xxxxxxxx x [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206724) xxxxx xxxx xxxxx xx xxxxxxxxxxx xxxxxxxx xxxxxxxxxxxxxx xxx xxx xxxxx xxxxxxx, xxxxxx, xxx xxxxxxxx xxxx.

4.  **Xxxxxxx xxx xxxx'x Xxxxxxxx xxx Xxxxxxxx Xxxxxxxxxxx.**

    Xxx xxxxxxxxx xxxxx xxx xxxxxxx xxxxxxxxx xxxxxxxxxxxxx xxxxx xx xxx xxxx'x xxxxxxxx, xxxxxx, xx xxxxxxxx xxxxxxxxxxx, Xxxxxxx xxxxx xxx x xxx xx xxxxxx xxxxx xxxxxxxxxxx, xxxxxxx [**Xxxxxxx.Xxxxxx.XxxxXxxxxxx.XxxxxxxxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241825). Xxxx xxxxxx, xxx xxx **XxxxxxxxxxxxxXxxxxxxxxxx** xxxxx xx xxx xxx xxxxx xx xxx xxxx'x xxxxxxx xxxxxxxxxx xxxxxx, xxxxxxxxx xxxxxxxxx, xxxxxxxxx xxxxxxxxxx, xxx xx xx.

## <span id="related_topics">
            </span>Xxxxxxx xxxxxx


* [Xxxx xxx x xxxxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465405)
* [Xxxxxxxxxx xxx xxxx xxx xxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465466)

**Xxxxxxxxx**
* [**Xxxxxxx.Xxxxxxxxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206724)
* [**Xxxxxxx.Xxxxxxxxxxxxx.XxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206859)
* [**Xxxxxxx.Xxxxxxxxxxxxx.XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226136)
* [**Xxxxxxx.Xxxxxx.XxxxXxxxxxx.XxxxxxxxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241825)

**Xxxxxxx**
* [Xxxxxxxx xxxxxxx xxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231636)
* [Xxxx xxx xxxx xxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231618)
* [Xxxxxxxxxxxxx xxxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231608)
* [Xxxxxx xxxxxxxxxx xxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231620)
 

 



<!--HONumber=Mar16_HO1-->
