---
xx.xxxxxxx: YXYXYYYY-XYYX-YXYY-XXXX-YXXYYXXXYXYY
xxxxx: Xxxxx xxxx xxxx xxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxx xxxxxxxxx xxxx x Xxxxxxxxx Xxxxxxx xxx. Xxxx xxxxx xxxx xxxxx xxx xx xxxxx xxxxxxxx xxxxx.
---
# Xxxxx xxxx xxxx xxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226489)
-   [**Xxxxxxx.XX.Xxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243325)
-   [**XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243314)

Xxxxx xxx xx xxxxx xxxxxxxxx xxxx x Xxxxxxxxx Xxxxxxx xxx. Xxxx xxxxx xxxx xxxxx xxx xx xxxxx xxxxxxxx xxxxx. Xxx xxxx xxxxxxxx xxxxxxx xx xxx xxxxx xxxxxxx XX, xxx [Xxxxxxxxx xxx xxxxx xxxxxxx XX](customize-the-print-preview-ui.md).

**Xxx**  Xxxx xx xxx xxxxxxxx xx xxxx xxxxx xxx xxxxx xx xxx xxxxx xxxxxx. Xx xxx xxx xxxx xxxx, xxxxxxxx xxx [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984) xxxx xxx [Xxxxxxx-xxxxxxxxx-xxxxxxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=619979) xx XxxXxx.

## Xxxxxxxx xxx xxxxxxxx

Xxx xxxxx xxxx xx xxx xxxxxxxx xx xxxx xxx xx xx xxxxxxxx xxx xxx Xxxxx xxxxxxxx. Xxxx xxx xxxx xx xxxx xx xxxxx xxxxxx xxxx xxxxx xxx xxxx xxxx xxxxxxxx xx xx xxxx xx xxxxx. Xxxx xxx xxxxxx xxxx xx xxxxxxxxx xx xxx xxxx xxx xx xxxxxxxxxx xxx xxxxxxxx. Xx xxx xxxxxx xx xxxx xxx xxx xxxxxxxxxx xxx xxxxxxxx, xx xxxx xxxxxxxxxx xxx xxxxxxxx xxxx xx xxxxx. Xx xx xx xxxxxxxx xx xxxxxxx xxxxxx, xxx xxxx xxxxxx xxxx xxxxxxxx xxx x xxx Xxxxx xxxxxxxx xxxx xx xxxxx.

**Xxx**  Xx xxx xxxx xx xxxxxxx xxxxxxxx xxxx xxxx xxxx xxx xxxx xx xxxx xxx, xxx xxx xxx xxxx xxxxx xxxx xx x xxxxxx xxxxxx xxxxx xxx xxxx xxxx xxx xxxxx xxxxx xx. Xxx xx xxxxxxx xx xxx xx xx xxxx, xxx xxx `PrintHelper` xxxxx xx xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984).

Xxxxx, xxxxxxx xxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226426) xxx [**XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243314). Xxx **XxxxxXxxxxxx** xxxx xx xx xxx [**Xxxxxxx.Xxxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226489) xxxxxxxxx xxxxx xxxx xxxxx xx xxxxxxx xxxxx Xxxxxxx xxxxxxxx xxxxxxxxxxxxx. Xxx **XxxxxXxxxxxxx** xxxx xx xx xxx [**Xxxxxxx.XX.Xxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243325) xxxxxxxxx xxxxx xxxx xxxxx xxxxx xxxx xxxxxxx xxxxxxxxx XXXX xxxxxxx xxx xxxxxxxx. Xxx xxx xxxx xx xxxxxx xx xxxxx xxxx xxxxxxxx xxxx xx xxxxxx xxx xxxxxxxxx **xxxxx** xx **Xxxxxxx** xxxxxxxxxx xx xxxx xxxx.

```csharp
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
```

Xxx [**XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243314) xxxxx xx xxxx xx xxxxxx xxxx xx xxx xxxxxxxxxxx xxxxxxx xxx xxx xxx xxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226426), xxx xx xxxxxxx xxxxxxx xxxxxxxxx xx xxx xxx. Xxxxxx xxxxxxxxxxxx, xxxxxx xxxxxxxxx xx **XxxxxXxxxxxx** xxx **XxxxxXxxxxxxx** xxx xxxxxxxx xxxxxxxx xxx xxxxx xxxxxxxx xxxxxx.

Xx xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984), xxxxxxxxxxxx xx xxxxxxxxx xx xxx `RegisterForPrinting` xxxxxx.

```csharp
public virtual void RegisterForPrinting()
{
   printDocument = new PrintDocument();
   printDocumentSource = printDocument.DocumentSource;
   printDocument.Paginate += CreatePrintPreviewPages;
   printDocument.GetPreviewPage += GetPrintPreviewPage;
   printDocument.AddPages += AddPrintPages;

   PrintManager printMan = PrintManager.GetForCurrentView();
   printMan.PrintTaskRequested += PrintTaskRequested;
}
```

Xxxx xxx xxxx xxxx xx x xxxx xxxx xxxxxxxx, xx xxxxxxxxx xxx xxxxxxxxxxxx xxxxxx xxx `OnNavigatedTo` xxxxxx.

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
   // Initalize common helper class and register for printing
   printHelper = new PrintHelper(this);
   printHelper.RegisterForPrinting();

   // Initialize print content for this scenario
   printHelper.PreparePrintContent(new PageToPrint());

   // Tell the user how to print
   MainPage.Current.NotifyUser("Print contract registered with customization, use the Print button to print.", NotifyType.StatusMessage);
}
```

Xxxx xxx xxxx xxxxxx xxx xxxx, xxxxxxxxxx xxx xxxxxxxx xxxxx xxxxxxxx. Xx xxx xxxx x xxxxxxxx-xxxx xxx xxx xxx'x xxxxxxxxxx xxxxxxxx, xx xxxxxxxxx xx xxxxxx xxxx xxx xxxx xxxxxx xxx xxxx xxx xxxx xxxxx xxxx xx xx.

```csharp
protected override void OnNavigatedFrom(NavigationEventArgs e)
{
   if (printHelper != null)
   {
         printHelper.UnregisterForPrinting();
   }
}
```
## Xxxxxx x xxxxx xxxxxx

Xxx x xxxxx xxxxxx xx xxxx xxx'x xxxxxx xxxxx xxx'x xxxx xx xx xxxxxx. Xxxx xxxx xxxx xx xxxxx'x xxxxxxxxx xxxx xxx xxxxxxx xxxx xxx xxxx xx xxxxx.

```xml
<Button x:Name="InvokePrintingButton" Content="Print" Click="OnPrintButtonClick"/>
```

Xxxx, xxx xx xxxxx xxxxxxx xx xxxx xxx'x xxxx xx xxxxxx xxx xxxxx xxxxx. Xxx xxx [**XxxxXxxxxXXXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printmanager.showprintuiasync) xxxxxx xx xxxxx xxxxxxxx xxxx xxxx xxx. **XxxxXxxxxXXXxxxx** xx xx xxxxxxxxxxxx xxxxxx xxxx xxxxxxxx xxx xxxxxxxxxxx xxxxxxxx xxxxxx. Xx xxxxxxxx xxx'x xx xxxxxxxxx xx xxxx xxxx, xxx xxxxxx xxxx xxxxx xx xxxxxxxxx. Xx xxxxxxxxx xxxxxxxx xxxxx xxxxxxxxxx xxx xxxxxxx xxx xxxx xxxx xxxx xxxxxxxx xxx'x xxxxxxx, xx xxxxx xxxx.

```csharp
async private void OnPrintButtonClick(object sender, RoutedEventArgs e)
{
    try
    {
        // Show print UI
        await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync();

    }
    catch
    {
        // Printing cannot proceed at this time
        ContentDialog noPrintingDialog = new ContentDialog()
        {
            Title = "Printing error",
            Content = "\nSorry, printing can' t proceed at this time.", PrimaryButtonText = "OK"
        };
        await noPrintingDialog.ShowAsync();
    }
}
```

Xx xxxx xxxxxxx, x xxxxx xxxxxx xx xxxxxxxxx xx xxx xxxxx xxxxxxx xxx x xxxxxx xxxxx. Xx xxx xxxxxx xxxxxx xx xxxxxxxxx (xxxxxxx xxxxxxxx xxx'x xx xxxxxxxxx xx xxxx xxxx), x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn633972) xxxxxxx xxxxxxx xxx xxxx xx xxx xxxxxxxxx.

## Xxxxxx xxxx xxx'x xxxxxxx

Xxxx **XxxxXxxxxXXXxxxx** xx xxxxxx, xxx [**XxxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206597) xxxxx xx xxxxxx. Xxx **XxxxxXxxxXxxxxxxxx** xxxxx xxxxxxx xxxxx xx xxxx xxxx xxxxxxx x [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR226436) xx xxxxxxx xxx [**XxxxxXxxxXxxxxxx.XxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR226436request_createprinttask) xxxxxx xxx xxxxxx xxx xxxxx xxx xxx xxxxx xxxx xxx xxx xxxx xx x [**XxxxxXxxxXxxxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printtask.source) xxxxxxxx. Xxxxxx xxxx xx xxxx xxxxxxx, xxx **XxxxxXxxxXxxxxxXxxxxxxxxXxxxxxx** xx xxxxxxx xxxxxx. Xxx **XxxxxXxxxXxxxxxXxxxxxxxxXxxxxxx** xxxxxxxx xxx xxxxxxxxx xxxxxxx xxx xxxxxxxx xxx xx xxxxxxxxx xxxxx.

Xx xxxx xxxxxxx, x xxxxxxxxxx xxxxxxx xx xxxx xxxxxxx xx xxxxx xxxxxx. Xx'x x xxxx xxxx xx xxxxxx xxxxxxxxxx xxxxxx xxxxxxx xxxx xxxx xxx xxx xxx xxx xxxx xxxx xx xx xxxxx xxxxxxxx xxx xxxxxxx xxxxxxxx xxxxxxxxx. Xxxxxxxx, xxxx xxx xxxxx xxx xxx xxxxxxxxxx xxxxx xx xxxxxxxx xxxxxxxxxx xxxxx xxx xxx xxxx xx xxxx xxxxx xxx xxxxx xxx xx xxxxxxxxxx.

```csharp
protected virtual void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
{
   PrintTask printTask = null;
   printTask = e.Request.CreatePrintTask("C# Printing SDK Sample", sourceRequested =>
   {
         // Print Task event handler is invoked when the print job is completed.
         printTask.Completed += async (s, args) =>
         {
            // Notify the user when the print operation fails.
            if (args.Completion == PrintTaskCompletion.Failed)
            {
               await scenarioPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
               {
                     MainPage.Current.NotifyUser("Failed to print.", NotifyType.ErrorMessage);
               });
            }
         };

         sourceRequested.SetSource(printDocumentSource);
   });
}
```

Xxxxx xxx xxxxx xxxx xx xxxxxxx, xxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226426) xxxxxxxx x xxxxxxxxxx xx xxxxx xxxxx xx xxxx xx xxx xxxxx xxxxxxx XX xx xxxxxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.paginate) xxxxx. Xxxx xxxxxxxxxxx xxxx xxx **Xxxxxxxx** xxxxxx xx xxx **XXxxxxXxxxxxxXxxxXxxxxxxxxx** xxxxxxxxx. Xxx xxxxx xxxxxxx xxx xxxxxxx xxxxxx xxxxxxxxxxxx xxxx xx xxxxxx xx xxxx xxxx.

**Xxxxxxxxx**  Xx xxx xxxx xxxxxxx xxxxx xxxxxxxx, xxx xxxxxxxx xxxxx xxxxxxx xxxx xx xxxxxx xxxxx xx xxxxx xxx xx xxxxxx xxx xxxxxxx. Xxx xxx xxxx xxxx xxxxxxxxxx, xx xxxxxxxxx xxxxxxxx xxx xxxxxxxx xxxxxx xxx xxxxxx xxx xxxxxxx xxx xxxxx xxxxxxxxxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xx'x xxx xxxxxxxxx.

Xx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.paginate) xxxxx xxxxxxx (xxx `CreatePrintPreviewPages` xxxxxx xx xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984)), xxxxxx xxx xxxxx xx xxxx xx xxx xxxxx xxxxxxx XX xxx xx xxxx xx xxx xxxxxxx. Xxx xxxx xxx xxx xx xxxxxxx xxxx xxx'x xxxxxxx xxx xxxxxxxx xx xxxxxxxx xx xxxx xxx xxx xxx xxxxxxx xxx xxxxx. Xxxxx xx xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984) xxxxxx xxxx xx xxx xxx xx xxxxxxx xxx xxxxxxx xxx xxxxxxxx.

```csharp
protected virtual void CreatePrintPreviewPages(object sender, PaginateEventArgs e)
{
   // Clear the cache of preview pages
   printPreviewPages.Clear();

   // Clear the print canvas of preview pages
   PrintCanvas.Children.Clear();

   // This variable keeps track of the last RichTextBlockOverflow element that was added to a page which will be printed
   RichTextBlockOverflow lastRTBOOnPage;

   // Get the PrintTaskOptions
   PrintTaskOptions printingOptions = ((PrintTaskOptions)e.PrintTaskOptions);

   // Get the page description to deterimine how big the page is
   PrintPageDescription pageDescription = printingOptions.GetPageDescription(0);

   // We know there is at least one page to be printed. passing null as the first parameter to
   // AddOnePrintPreviewPage tells the function to add the first page.
   lastRTBOOnPage = AddOnePrintPreviewPage(null, pageDescription);

   // We know there are more pages to be added as long as the last RichTextBoxOverflow added to a print preview
   // page has extra content
   while (lastRTBOOnPage.HasOverflowContent &amp;&amp; lastRTBOOnPage.Visibility == Windows.UI.Xaml.Visibility.Visible)
   {
         lastRTBOOnPage = AddOnePrintPreviewPage(lastRTBOOnPage, pageDescription);
   }

   if (PreviewPagesCreated != null)
   {
         PreviewPagesCreated.Invoke(printPreviewPages, null);
   }

   PrintDocument printDoc = (PrintDocument)sender;

   // Report the number of preview pages created
   printDoc.SetPreviewPageCount(printPreviewPages.Count, PreviewPageCountType.Intermediate);
}
```

Xxxx x xxxxxxxxxx xxxx xx xx xx xxxxx xx xxx xxxxx xxxxxxx xxxxxx, xxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226426) xxxxxx xxx [**XxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.getpreviewpage) xxxxx. Xxxx xxxxxxxxxxx xxxx xxx **XxxxXxxx** xxxxxx xx xxx **XXxxxxXxxxxxxXxxxXxxxxxxxxx** xxxxxxxxx. Xxx xxxxx xxxxxxx xxx xxxxxxx xxxxxx xxxxxxxxxxxx xxxx xx xxxxxx xx xxxx xxxx.

Xx xxx [**XxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.getpreviewpage) xxxxx xxxxxxx (xxx `GetPrintPreviewPage` xxxxxx xx xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984)), xxx xxx xxxxxxxxxxx xxxx xx xxx xxxxx xxxxxxxx.

```csharp
protected virtual void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
{
   PrintDocument printDoc = (PrintDocument)sender;
   printDoc.SetPreviewPage(e.PageNumber, printPreviewPages[e.PageNumber - 1]);
}
```

Xxxxxxx, xxxx xxx xxxx xxxxxx xxx xxxxx xxxxxx, xxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226426) xxxxxxxx xxx xxxxx xxxxxxxxxx xx xxxxx xx xxxx xx xxx xxxxxxx xx xxxxxxx xxx **XxxxXxxxxxxx** xxxxxx xx xxx **XXxxxxxxxXxxxXxxxxx** xxxxxxxxx. Xx XXXX, xxxx xxxxxx xxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.addpages) xxxxx. Xxx xxxxx xxxxxxx xxx xxxxxxx xxxxxx xxxxxxxxxxxx xxxx xx xxxxxx xx xxxx xxxx.

Xx xxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.addpages) xxxxx xxxxxxx (xxx `AddPrintPages` xxxxxx xx xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984)), xxx xxxxx xxxx xxx xxxx xxxxxxxxxx xx xxx [**XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243314) xxxxxx xx xx xxxx xx xxx xxxxxxx. Xx x xxxx xxxxxxxxx xxxxxxxxxx xxxxx xx x xxxxx xx xxxxx xx xxxxx, xxx xxx xxxx xxxxxxxxxxx xxxx xx xxx xxxx xxx xxxxx xxxx xxxx xxxxxxxx xx xxxx xx xxx xxxxxxx.

```csharp
protected virtual void AddPrintPages(object sender, AddPagesEventArgs e)
{
   // Loop over all of the preview pages and add each one to  add each page to be printied
   for (int i = 0; i < printPreviewPages.Count; i++)
   {
         // We should have all pages ready at this point...
         printDocument.AddPage(printPreviewPages[i]);
   }

   PrintDocument printDoc = (PrintDocument)sender;

   // Indicate that all of the print pages have been provided
   printDoc.AddPagesComplete();
}
```

## Xxxxxxx xxxxx xxxxxxx

Xxxx xxxxxxx xxxxx xxxxxxx. Xx xx xxxxxxx, xxxx xxxxxxx xxxx xxxxxxxx xxx xx xxx xxx xxxx xxxxx xxxxxx xx xxxxx xxxxxxxx xx xxxxxxxx xxxxx. Xxx xxxx xxxxxxxx xxxxxxx, xxx [Xxxxxxxxx xxx xxxxx xxxxxxx XX](customize-the-print-preview-ui.md).

Xxxx xxxx xxxxxxx x xxx xxxxx xxxxxx, xxxxxxx x xxxx xx xxxxxx xxxx xxx xxxxxx xxxxxxxx, xxx xxxx xxxx xxx xxxxxx xx xxx xxxxx xxxxxxx XX. Xxx xxxx xxxxx xxxxxx xxx xxxxx xxxxxxxx:

| Xxxxxx xxxx          | Xxxxxx | 
|----------------------|--------|
| **Xxxxx xxx**        | Xxxxx xxx xxxxx xx xxx xxxxxxxx. |
| **Xxxxx Xxxxxxxxx**  | Xxxxx xxxx xxx xxxxxxx xxx xxxx xxxxxxxx. | 
| **Xxxxx Xxxxx**      | Xxxxxxx xx xxxx xxxxxxx xxxx xxxxx xxx xxxx xxx xxxxx xxx xxxxx xx xxxxx. |
 
Xxxxx, xxxxxx xxx [**XxxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206597) xxxxx xxxxxxx xx xxx xxx xxxx xx xxx x [**XxxxxXxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh701256) xxxxxx.

```csharp
PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(printTask.Options);
```

Xxxxx xxx xxxx xx xxxxxxx xxxx xxx xxxxx xx xxx xxxxx xxxxxxx XX xxx xxx xxx xxxxxxx xxxx xxx xxxx xx xxxxxxx xxxx xxx xxxx xxxxx xx xxxxx xxxx xxx xxx.

**Xxxx**  Xxx xxxxxxx xxxxxx xx xxx xxxxx xxxxxxx XX xx xxx xxxx xxxxx xxxx xxx xxxxxxxx, xxxx xxx xxxxx xxxxxx xxxxx xx xxx xxx xx xxx xxxxxx.

```csharp
IList<string> displayedOptions = printDetailedOptions.DisplayedOptions;

displayedOptions.Clear();
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Copies);
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Orientation);
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.ColorMode);
```

Xxxxxx xxx xxx xxxxx xxxxxx xxx xxxxxxxxxx xxx xxxx xx xxxxxx xxxxxx.

```csharp
// Create a new list option
PrintCustomItemListOptionDetails pageFormat = printDetailedOptions.CreateItemListOption("PageRange", "Page Range");
pageFormat.AddItem("PrintAll", "Print all");
pageFormat.AddItem("PrintSelection", "Print Selection");
pageFormat.AddItem("PrintRange", "Print Range");
```

Xxx xxxx xxxxxx xxxxx xxxxxx xxx xxxxxx xxx xxxxx xxxxxxx. Xxx xxxxxx xxxxxx xx xxxxxxxx xxxx xx xxxx xx xxxxxxx xx xxx xxxxxx xx xxx xxxx xx xxxxxxx. Xxx xxx xxx xxx xx xxxxxxxx xx xxx xxxx, xxxxxx xxxxx xxxxxxx xxx'x xxxx xx xx xxxxx xxxx.

```csharp
// Add the custom option to the option list
displayedOptions.Add("PageRange");

// Create new edit option
PrintCustomTextOptionDetails pageRangeEdit = printDetailedOptions.CreateTextOption("PageRangeEdit", "Range");

// Register the handler for the option change event
printDetailedOptions.OptionChanged += printDetailedOptions_OptionChanged;
```

Xxx [**XxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.optiondetails.printtaskoptiondetails.createtextoption) xxxxxx xxxxxxx xxx **Xxxxx** xxxx xxx. Xxxx xx xxxxx xxx xxxx xxxxxx xxx xxxxxxxx xxxxx xxxx xxxx xx xxxxx xxxx xxxx xxxxxx xxx **Xxxxx Xxxxx** xxxxxx.

## Xxxxxx xxxxx xxxxxx xxxxxxx

Xxx **XxxxxxXxxxxxx** xxxxx xxxxxxx xxxx xxx xxxxxx. Xxxxx, xx xxxxx xxx xxxxx xxx xxxx xxxx xxxxx xxx xxx xxxx xxxxx xxxxxxxxx xx xxx xxxx xxxxx xxxxxx xxxx xxx xxxx xxxxxxxx. Xxxxxx, xx xxxxx xxx xxxx xxxxxxx xxxx xxx xxxx xxxxx xxxx xxx xx xxxx xxxx xxxx xx xxxxxxxxxx x xxxxx xxxx xxxxx xxx xxx xxxxxxxx.

Xxxx xxxxxxx xxxxx xxx xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984) xxxxxxx xxxxxx xxxxxx.

```csharp
async void printDetailedOptions_OptionChanged(PrintTaskOptionDetails sender, PrintTaskOptionChangedEventArgs args)
{
   if (args.OptionId == null)
   {
         return;
   }

   string optionId = args.OptionId.ToString();

   // Handle change in Page Range Option
   if (optionId == "PageRange")
   {
         IPrintOptionDetails pageRange = sender.Options[optionId];
         string pageRangeValue = pageRange.Value.ToString();

         selectionMode = false;

         switch (pageRangeValue)
         {
            case "PrintRange":
               // Add PageRangeEdit custom option to the option list
               sender.DisplayedOptions.Add("PageRangeEdit");
               pageRangeEditVisible = true;
               await scenarioPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
               {
                     ShowContent(null);
               });
               break;
            case "PrintSelection":
               await scenarioPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
               {
                     Scenario4PageRange page = (Scenario4PageRange)scenarioPage;
                     PageToPrint pageContent = (PageToPrint)page.PrintFrame.Content;
                     ShowContent(pageContent.TextContentBlock.SelectedText);
               });
               RemovePageRangeEdit(sender);
               break;
            default:
               await scenarioPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
               {
                     ShowContent(null);
               });
               RemovePageRangeEdit(sender);
               break;
         }

         Refresh();
   }
   else if (optionId == "PageRangeEdit")
   {
         IPrintOptionDetails pageRange = sender.Options[optionId];
         // Expected range format (p1,p2...)*, (p3-p9)* ...
         if (!Regex.IsMatch(pageRange.Value.ToString(), @"^\s*\d+\s*(\-\s*\d+\s*)?(\,\s*\d+\s*(\-\s*\d+\s*)?)*$"))
         {
            pageRange.ErrorText = "Invalid Page Range (eg: 1-3, 5)";
         }
         else
         {
            pageRange.ErrorText = string.Empty;
            try
            {
               GetPagesInRange(pageRange.Value.ToString());
               Refresh();
            }
            catch (InvalidPageException ipex)
            {
               pageRange.ErrorText = ipex.Message;
            }
         }
   }
}
```

**Xxx**  Xxx xxx `GetPagesInRange` xxxxxx xx xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984) xxx xxxxxxx xx xxx xx xxxxx xxx xxxx xxxxx xxx xxxx xxxxxx xx xxx Xxxxx xxxx xxx.

## Xxxxxxx xxxxxxxx xxxxx

Xxx xxx xxxxxx xxxx xxx'x xxxxxxx xxx xxxxxxxx xxxxxxx xx xxx xxxxxx xx xxxx xxx xxx xxx xxxxxxx. Xxx [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984) xxxx x xxxxx xxxxxx xxxxx xx xxxxxx xxx xxxxxxx xxx xxxxxxxx.

Xxxx xxxxxxxx x xxxxxx xx xxx xxxxx, xxxxx xxx xxxxxxx xxxx xx xxxx xxx xxxxxxx xx xxx xxxxx xxxxxxx. Xxxxxxxxxx xx xxx xxxxxx xxx xxxxx xx xxxx xxx xxxx xxxxx xx xxx xxxxx xxxxxxx, xxx xxxxxxx xxxxxx xxxx xxxxxxx xxxx xxx xxxxxxxx xxxxx.

-   Xxxx xxx xxx xxxxx xx xxx xxxxx xxxxxxx xxxxxxx x xxxx xxxxx xx xxxxxxxxx xx xxx, xxxxxxx xxx xxxx xx xxxx xxxxx xxxxx xxxx xxxxxxxx xx xxxxxxx.
-   Xxxx xxxx xxx xxxxx xxxxxxxx xx xxx xxxx'x xxxx xxxxx xx xxx xxxxx xxxxxxx, xxxxxxxx xxx xxxxxxx xxxxxxxx xxx xxxx xxxxxxx xxx xxxx xxxxx.
-   Xxxx xxx xxx xxxxx xx xxxxx xxxxxxx, xxx xxxx xxx xxx xxxxx xxxx xxx xxx xx xxxx xxxxx xxxxxxxx xx xxx xxxx.

## Xxxxxxx xxxxxx

* [Xxxxxx xxxxxxxxxx xxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Hh868178)
* [//Xxxxx YYYY xxxxx: Xxxxxxxxxx xxxx xxxx xxxxx xx Xxxxxxx YY](https://channel9.msdn.com/Events/Build/2015/2-94)
* [XXX xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619984)

<!--HONumber=Mar16_HO1-->
