---
xx.xxxxxxx: YYYYYXYX-XXYY-YXYY-XXYY-YYYYYYYYYYYY
xxxxx: Xxxxxxxxx xxx xxxxx xxxxxxx XX
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxxx xxx xx xxxxxxxxx xxx xxxxx xxxxxxx xxx xxxxxxxx xx xxx xxxxx xxxxxxx XX.
---
# Xxxxxxxxx xxx xxxxx xxxxxxx XX

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226489)
-   [**Xxxxxxx.XX.Xxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243325)
-   [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226426)

Xxxx xxxxxxx xxxxxxxxx xxx xx xxxxxxxxx xxx xxxxx xxxxxxx xxx xxxxxxxx xx xxx xxxxx xxxxxxx XX. Xxx xxxx xxxx xxxxx xxxxxxxx, xxx [Xxxxx xxxx xxxx xxx](print-from-your-app.md).

**Xxx**  Xxxx xx xxx xxxxxxxx xx xxxx xxxxx xxx xxxxx xx xxx xxxxx xxxxxx. Xx xxx xxx xxxx xxxx, xxxxxxxx xxx [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984) xxxx xxx [Xxxxxxx-xxxxxxxxx-xxxxxxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=619979) xx XxxXxx.

 

## Xxxxxxxxx xxxxx xxxxxxx

Xx xxxxxxx, xxx xxxxx xxxxxxx XX xxxxx xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR226478), [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226479), xxx [**Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226486) xxxxx xxxxxxx. Xx xxxxxxxx xx xxxxx, xxxxx xxx xxxxxxx xxxxx xxxxxx xxxxxxx xxxxxxx xxxx xxx xxx xxx xx xxx xxxxx xxxxxxx XX:

-   [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226476)
-   [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226477)
-   [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226480)
-   [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226481)
-   [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/BR226482)
-   [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR226483)
-   [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR226484)
-   [**XXx**](https://msdn.microsoft.com/library/windows/apps/BR226485)
-   [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226487)
-   [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226488)

Xxxxx xxxxxxx xxx xxxxxxx xx xxx [**XxxxxxxxXxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226475) xxxxx. Xxx xxx xxx xx xx xxxxxx xxxxxxx xxxx xxx xxxx xx xxxxxxx xxxxxxxxx xx xxx xxxxx xxxxxxx XX. Xxx xxx xxxx xxxxxx xxx xxxxx xx xxxxx xxxx xxxxxx, xxx xxx xxx xxxxxxx xxxxxxxx xxxx xxx xxxxx xx xxx xxxx.

Xxxxxxx, xxx xxxxxxxxxxxxx xxxx xxx xxxx xx xxxxx xxxx xxxxxx xxxxxx xxxx xxx xxxxx xxxxxxx XX. Xxx xxxx xxx xxxxxx xxxxxx xxx xx xxx xxxxxxx xxxx xxx xxxxxxx xxxxxxxx xx xxxxxxx **Xxxx xxxxxxxx** xx xxx xxxxx xxxxxxx XX.

**Xxxx**  Xxxxxxxx xxxx xxx xxx xxxxxxx xxx xxxxx xxxxxxx xx xx xxxxxxxxx, xxxx xxxxx xxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxx xxx xxxxx xx xxx xxxxx xxxxxxx XX. Xxx xxxxx XX xxx'x xxxx xxxxxxx xxxx xxx xxxxxxxx xxxxxxx xxxxx'x xxxxxxx.

 

### Xxxxxx xxx xxxxxxx xx xxxxxxx

Xxxx xxx xxx'x xxxxxx xx xxxxxx, xx xxxxxxxxx xxx xxx Xxxxx xxxxxxxx. Xxxx xx xxxx xxxxxxxxxxxx xxxxxxxx xxxxxxxx xxx [**XxxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206597) xxxxx xxxxxxx. Xxx xxxx xx xxxxxxxxx xxx xxxxxxx xxxxxxxxx xx xxx xxxxx xxxxxxx XX xx xxxxx xx xxx **XxxxxXxxxXxxxxxxxx** xxxxx xxxxxxx.

Xxxxxx xxx [**XxxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206597) xxxxx xxxxxxx xx xxxxxxx xxx [**xxxxxXxxx.xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226469) xxxxxxxxxxxx xxxx xxxxxxxxx xxx xxxxx xxxxxxxx xxxx xxx xxxx xx xxxxxxx xx xxx xxxxx xxxxxxx XX.Xxx xxx xxxxxx xx xxxx xxx xxx xxxxx xxx xxxx xx xxxx x xxxxxxxxxx xxxx xx xxxxx xxxxxxx, xxxxxxxx xxx **XxxxxXxxxXxxxxxxxx** xxxxx xxxxxxx xx xxx xxxxxx xxxxx xx xxxxxxx xxxx xxxx xxxxxxxxx xxx xxxxxxx xx xxxxxxx xxxx xxx xxxxxx xx xxxxxxx.

``` csharp
protected override void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
{
   PrintTask printTask = null;
   printTask = e.Request.CreatePrintTask(&quot;C# Printing SDK Sample&quot;, sourceRequestedArgs =&gt;
   {
         IList&lt;string&gt; displayedOptions = printTask.Options.DisplayedOptions;

         // Choose the printer options to be shown.
         // The order in which the options are appended determines the order in which they appear in the UI
         displayedOptions.Clear();
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Copies);
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Orientation);
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.MediaSize);
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Collation);
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Duplex);

         // Preset the default value of the printer option
         printTask.Options.MediaSize = PrintMediaSize.NorthAmericaLegal;

         // Print Task event handler is invoked when the print job is completed.
         printTask.Completed += async (s, args) =&gt;
         {
            // Notify the user when the print operation fails.
            if (args.Completion == PrintTaskCompletion.Failed)
            {
               await scenarioPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =&gt;
               {
                     MainPage.Current.NotifyUser(&quot;Failed to print.&quot;, NotifyType.ErrorMessage);
               });
            }
         };

         sourceRequestedArgs.SetSource(printDocumentSource);
   });
}
```

**Xxxxxxxxx**  Xxxxxxx [**xxxxxxxxxXxxxxxx.xxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226453)() xxxxxxx xxx xx xxx xxxxx xxxxxxx xxxx xxx xxxxx xxxxxxx XX, xxxxxxxxx xxx **Xxxx xxxxxxxx** xxxx. Xx xxxx xx xxxxxx xxx xxxxxxx xxxx xxx xxxx xx xxxx xx xxx xxxxx xxxxxxx XX.

### Xxxxxxx xxxxxxx xxxxxxx

Xxx xxx xxxx xxx xxx xxxxxxx xxxxxx xx xxx xxxxxxx xx xxx xxxxx xxxxxxx XX. Xxx xxxxxxxxx xxxx xx xxxx, xxxx xxx xxxx xxxxxxx, xxxx xxx xxxxxxx xxxxx xx xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR226483) xxxxxx.

``` csharp
         // Preset the default value of the printer option
         printTask.Options.MediaSize = PrintMediaSize.NorthAmericaLegal;
```         

## Xxx xxx xxxxx xxxxxxx

Xxxx xxxxxxx xxxxx xxx xx xxxxxx x xxx xxxxx xxxxxx, xxxxxx x xxxx xx xxxxxx xxxx xxx xxxxxx xxxxxxxx, xxx xxxx xxx xxx xxxxxx xx xxx xxxxx xxxxxxx. Xx xx xxx xxxxxxxx xxxxxxx, xxx xxx xxx xxxxx xxxxxx xx xxx [**XxxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206597) xxxxx xxxxxxx.

Xxxxx, xxx x [**XxxxxXxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh701256) xxxxxx. Xxxx xx xxxx xx xxx xxx xxx xxxxx xxxxxx xx xxx xxxxx xxxxxxx XX. Xxxx xxxxx xxx xxxx xx xxxxxxx xxxx xxx xxxxx xx xxx xxxxx xxxxxxx XX xxx xxx xxx xxxxxxx xxxx xxx xxxx xx xxxxxxx xxxx xxx xxxx xxxxx xx xxxxx xxxx xxx xxx. Xxxxx xxxx, xxxxxx xxx xxx xxxxx xxxxxx xxx xxxxxxxxxx xxx xxxx xx xxxxxx xxxxxx. Xxxxxxx, xxx xxx xxx xxxxxx xxx xxxxxx x xxxxxxx xxx xxx **XxxxxxXxxxxxx** xxxxx.

``` csharp
protected override void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
{
   PrintTask printTask = null;
   printTask = e.Request.CreatePrintTask(&quot;C# Printing SDK Sample&quot;, sourceRequestedArgs =&gt;
   {
         PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(printTask.Options);
         IList&lt;string&gt; displayedOptions = printDetailedOptions.DisplayedOptions;

         // Choose the printer options to be shown.
         // The order in which the options are appended determines the order in which they appear in the UI
         displayedOptions.Clear();

         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Copies);
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Orientation);
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.ColorMode);

         // Create a new list option
         PrintCustomItemListOptionDetails pageFormat = printDetailedOptions.CreateItemListOption(&quot;PageContent&quot;, &quot;Pictures&quot;);
         pageFormat.AddItem(&quot;PicturesText&quot;, &quot;Pictures and text&quot;);
         pageFormat.AddItem(&quot;PicturesOnly&quot;, &quot;Pictures only&quot;);
         pageFormat.AddItem(&quot;TextOnly&quot;, &quot;Text only&quot;);

         // Add the custom option to the option list
         displayedOptions.Add(&quot;PageContent&quot;);

         printDetailedOptions.OptionChanged += printDetailedOptions_OptionChanged;

         // Print Task event handler is invoked when the print job is completed.
         printTask.Completed += async (s, args) =&gt;
         {
            // Notify the user when the print operation fails.
            if (args.Completion == PrintTaskCompletion.Failed)
            {
               await scenarioPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =&gt;
               {
                     MainPage.Current.NotifyUser(&quot;Failed to print.&quot;, NotifyType.ErrorMessage);
               });
            }
         };

         sourceRequestedArgs.SetSource(printDocumentSource);
   });
}
```

Xxx xxxxxxx xxxxxx xx xxx xxxxx xxxxxxx XX xx xxx xxxx xxxxx xxxx xxx xxxxxxxx, xxxx xxx xxxxx xxxxxx xxxxx xx xxx xxx xx xxx xxxxxx. Xx xxxx xxxxxxx, xxx xxxxxx xxxxxx xx xxxxxxxx xxxx xx xxxx xx xxxxxxx xx xxx xxxxxx xx xxx xxxx xx xxxxxxx. Xxxxxxx, xxx xxxxx xxx xx xxxxxxxx xx xxx xxxx; xxxxxx xxxxx xxxxxxx xxx'x xxxx xx xx xxxxx xxxx.

Xxxx xxx xxxx xxxxxxx xxx xxxxxxxx xxxxxx xx xxxx xxxxxx xxxxxx, xxxxxx xxx xxxxx xxxxxxx xxxxx. Xxxx xxx [**XxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh702146) xxxxxx xx xxxxxx xxx xxxxx xx xxx xxxxx xxxxxxx XX, xx xxxxx xxxxx.

``` csharp
async void printDetailedOptions_OptionChanged(PrintTaskOptionDetails sender, PrintTaskOptionChangedEventArgs args)
{
   // Listen for PageContent changes
   string optionId = args.OptionId as string;
   if (string.IsNullOrEmpty(optionId))
   {
         return;
   }

   if (optionId == &quot;PageContent&quot;)
   {
         await scenarioPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =&gt;
         {
            printDocument.InvalidatePreview();
         });
   }
}
```

## Xxxxxxx xxxxxx

* [Xxxxxx xxxxxxxxxx xxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Hh868178)
* [//Xxxxx YYYY xxxxx: Xxxxxxxxxx xxxx xxxx xxxxx xx Xxxxxxx YY](https://channel9.msdn.com/Events/Build/2015/2-94)
* [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984)

<!--HONumber=Mar16_HO1-->
