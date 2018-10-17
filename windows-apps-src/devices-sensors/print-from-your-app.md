---
author: PatrickFarley
ms.assetid: 9A0F1852-A76B-4F43-ACFC-2CC56AAD1C03
title: アプリからの印刷
description: ユニバーサル Windows アプリからドキュメントを印刷する方法について説明します。 また、このトピックでは特定のページを印刷する方法も示します。
ms.author: pafarley
ms.date: 01/29/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 印刷
ms.localizationpriority: medium
ms.openlocfilehash: cff96c0b8daf9f3ef32815437b510a5b94641527
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4755973"
---
# <a name="print-from-your-app"></a>アプリからの印刷



**重要な API**

-   [**Windows.Graphics.Printing**](https://msdn.microsoft.com/library/windows/apps/BR226489)
-   [**Windows.UI.Xaml.Printing**](https://msdn.microsoft.com/library/windows/apps/BR243325)
-   [**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314)

ユニバーサル Windows アプリからドキュメントを印刷する方法について説明します。 また、このトピックでは特定のページを印刷する方法も示します。 印刷プレビュー UI の高度な変更については、「[印刷プレビュー UI のカスタマイズ](customize-the-print-preview-ui.md)」を参照してください。

> [!TIP]
> このトピックに含まれる例のほとんどは、印刷サンプルを基盤としています。 完全なコードを確認するには、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619984)から[ユニバーサル Windows プラットフォーム (UWP) 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619979)をダウンロードしてください。

## <a name="register-for-printing"></a>印刷の登録

アプリに印刷機能を追加する最初の手順は、印刷コントラクトへの登録です。 アプリは、ユーザーによる印刷を可能にするすべての画面でこの処理を行う必要があります。 ユーザーに表示される画面のみ、印刷登録を行うことができます。 アプリの画面を印刷登録した場合は、画面終了時に印刷登録を解除する必要があります。 別の画面で置き換えられる場合は、その画面が開いたときに画面を新しい印刷コントラクトに登録する必要があります。

> [!TIP]
> アプリで複数ページからの印刷をサポートする必要がある場合は、この印刷コードを共通の基底ヘルパー クラスに入れ、アプリ ページでそれを再利用させることができます。 この方法の例については、[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)に挙げられている `PrintHelper` クラスをご覧ください。

まず、[**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) と [**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314) を宣言します。 他の Windows 印刷機能をサポートするタイプと共に、**PrintManager** タイプが [**Windows.Graphics.Printing**](https://msdn.microsoft.com/library/windows/apps/BR226489) 名前空間内に指定されています。 XAML コンテンツの印刷準備をサポートする他のタイプと共に、**PrintDocument** タイプが [**Windows.UI.Xaml.Printing**](https://msdn.microsoft.com/library/windows/apps/BR243325) 名前空間内に指定されています。 次の **using** ステートメントまたは **Imports** ステートメントをページに追加することで、印刷コードを簡単に記述できます。

```csharp
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
```

[**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314) クラスはアプリと [**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) 間の多くの対話を処理しますが、独自のコールバックがいくつか公開されます。 登録中に **PrintManager** と **PrintDocument** のインスタンスを作成し、それらの印刷イベントのハンドラーを登録します。

[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)では、登録は `RegisterForPrinting` メソッドによって実行されます。

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

ユーザーが印刷のサポートされているページに移動すると、`OnNavigatedTo` メソッド内で登録を開始します。

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
   // Initialize common helper class and register for printing
   printHelper = new PrintHelper(this);
   printHelper.RegisterForPrinting();

   // Initialize print content for this scenario
   printHelper.PreparePrintContent(new PageToPrint());

   // Tell the user how to print
   MainPage.Current.NotifyUser("Print contract registered with customization, use the Print button to print.", NotifyType.StatusMessage);
}
```

ユーザーがページから離れた時点で、印刷イベント ハンドラーを切り離します。 複数ページ アプリが存在し、印刷を切断しないと、ユーザーがページからいったん移動してそのページに戻ってきたときに例外がスローされます。

```csharp
protected override void OnNavigatedFrom(NavigationEventArgs e)
{
   if (printHelper != null)
   {
         printHelper.UnregisterForPrinting();
   }
}
```
## <a name="create-a-print-button"></a>印刷ボタンの作成

アプリの画面の任意の場所に印刷ボタンを追加します。 印刷するコンテンツの妨げにならないようにします。

```xml
<Button x:Name="InvokePrintingButton" Content="Print" Click="OnPrintButtonClick"/>
```

次に、クリック イベントを処理するイベント ハンドラーをアプリのコードに追加します。 [**ShowPrintUIAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printmanager.showprintuiasync) メソッドを使用してアプリからの印刷を開始します。 **ShowPrintUIAsync** は適切な印刷ウィンドウを表示する非同期メソッドです。 印刷をサポートするデバイス上でアプリが実行されていることを確認する (およびサポートされていないケースに対処する) ために、先に [**IsSupported**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Printing.PrintManager.IsSupported) メソッドを呼び出すことをお勧めします。 その時点でなんらかの理由で印刷を実行できない場合は、**ShowPrintUIAsync** は例外をスローします。 印刷を続行できない場合は、これらの例外をキャッチして、ユーザーに知らせることをお勧めします。

```csharp
async private void OnPrintButtonClick(object sender, RoutedEventArgs e)
{
    if (Windows.Graphics.Printing.PrintManager.IsSupported())
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
    else
    {
        // Printing is not supported on this device
        ContentDialog noPrintingDialog = new ContentDialog()
        {
            Title = "Printing not supported",
            Content = "\nSorry, printing is not supported on this device.",PrimaryButtonText = "OK"
        };
        await noPrintingDialog.ShowAsync();
    }
}
```

この例では、ボタン クリックのイベント ハンドラーに印刷ウィンドウが表示されます。 メソッドによって例外がスローされる場合 (その時点で印刷を実行することができないため)、[**ContentDialog**](https://msdn.microsoft.com/library/windows/apps/Dn633972) コントロールによってその状況がユーザーに通知されます。

## <a name="format-your-apps-content"></a>アプリのコンテンツの書式設定

**ShowPrintUIAsync** が呼び出されると、[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベントが発生します。 この手順に示す **PrintTaskRequested** イベント ハンドラーは、[**PrintTaskRequest.CreatePrintTask**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printtaskrequest.createprinttask.aspx) メソッドを呼び出して [**PrintTask**](https://msdn.microsoft.com/library/windows/apps/BR226436) を作成し、印刷ページのタイトルと [**PrintTaskSourceRequestedHandler**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printtask.source) デリゲートの名前を渡します。 この例では、**PrintTaskSourceRequestedHandler** がインラインで定義されています。 **PrintTaskSourceRequestedHandler** は、印刷用の書式付きコンテンツを用意します (後述)。

この例では、エラーを捕捉するために完了ハンドラーも定義されています。 エラー発生の有無をユーザーに知らせ、考えられる解決策を提供することが可能になるため、完了イベントを処理することをお勧めします。 同様に、完了イベントを使うと、印刷ジョブが正常に終了した後でユーザーが実行する手順を提示することができます。

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

印刷タスクが作られた後、[**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) は [**Paginate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.paginate) イベントを発生させることによって、印刷プレビュー UI に表示するために印刷ページのコレクションを要求します。 これは、**IPrintPreviewPageCollection** インターフェイスの **Paginate** メソッドに対応します。 登録時に作成したイベント ハンドラーは、この時点で呼び出されます。

> [!IMPORTANT]
> ユーザーが印刷設定を変更すると、ページ設定イベント ハンドラーがもう一度呼び出されてコンテンツを再配置できます。 優良なユーザー エクスペリエンスのため、マイクロソフトではコンテンツを再配置する前に設定を確認し、ページ付けされたコンテンツの不必要な再初期化を避けることをお勧めします。

[**Paginate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.paginate) イベント ハンドラー ([UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)内の `CreatePrintPreviewPages` メソッド) で、印刷プレビュー UI に表示されてプリンターに送信されるページを作ります。 アプリのコンテンツの印刷準備のために使うコードは、アプリと印刷するコンテンツに固有です。 コンテンツを印刷用に書式設定する方法については、[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)のソース コードを参照してください。

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
   while (lastRTBOOnPage.HasOverflowContent && lastRTBOOnPage.Visibility == Windows.UI.Xaml.Visibility.Visible)
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

特定のページが印刷プレビュー ウィンドウに表示されると、[**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) によって [**GetPreviewPage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.getpreviewpage) イベントが生成されます。 これは、**IPrintPreviewPageCollection** インターフェイスの **MakePage** メソッドに対応します。 登録時に作成したイベント ハンドラーは、この時点で呼び出されます。

[**GetPreviewPage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.getpreviewpage) イベント ハンドラー ([UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)内の `GetPrintPreviewPage` メソッド) で、適切なページを印刷ドキュメントに設定します。

```csharp
protected virtual void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
{
   PrintDocument printDoc = (PrintDocument)sender;
   printDoc.SetPreviewPage(e.PageNumber, printPreviewPages[e.PageNumber - 1]);
}
```

最後に、ユーザーが印刷ボタンをクリックすると、[**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) によって **IDocumentPageSource** インターフェイスの **MakeDocument** メソッドが呼び出され、プリンターに送信するページの最終コレクションが要求されます。 XAML では、これによって [**AddPages**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.addpages) イベントが生成されます。 登録時に作成したイベント ハンドラーは、この時点で呼び出されます。

[**AddPages**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.addpages) イベント ハンドラー ([UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)内の `AddPrintPages` メソッド) で、ページ コレクションから、プリンターに送られる [**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314) オブジェクトにページを追加します。 印刷する特定ページまたはページ範囲がユーザーによって指定される場合は、プリンターに実際に送られるページだけを追加するためにその情報をここで使います。

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

## <a name="prepare-print-options"></a>印刷オプションの準備

次に、印刷オプションを準備します。 たとえば、このセクションでは特定のページの印刷を許可するためにページ範囲オプションを設定する方法について説明します。 詳細なオプションについては、「[印刷プレビュー UI のカスタマイズ](customize-the-print-preview-ui.md)」を参照してください。

この手順では、新しい印刷オプションを作成し、オプションがサポートする値の一覧を定義して、印刷プレビュー UI にオプションを追加します。 ページ範囲オプションでは次の設定を指定できます。

| オプション名          | アクション |
|----------------------|--------|
| **Print all**        | ドキュメントのすべてのページを印刷します。|
| **Print Selection**  | ユーザーが選んだ内容のみを印刷します。|
| **Print Range**      | ユーザーが印刷するページを入力できる編集コントロールを表示します。|

まず、[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベント ハンドラーを変更し、[**PrintTaskOptionDetails**](https://msdn.microsoft.com/library/windows/apps/Hh701256) オブジェクトを取得するコードを追加します。

```csharp
PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(printTask.Options);
```

印刷プレビュー UI に表示されるオプションの一覧をクリアし、ユーザーがアプリから印刷する場合に表示するオプションを追加します。

> [!NOTE]
> オプションは、追加された順番で印刷プレビュー UI に表示されます。したがって、最初のオプションがウィンドウの最上部に表示されます。

```csharp
IList<string> displayedOptions = printDetailedOptions.DisplayedOptions;

displayedOptions.Clear();
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Copies);
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Orientation);
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.ColorMode);
```

新しい印刷オプションを作成し、オプションの値の一覧を初期化します。

```csharp
// Create a new list option
PrintCustomItemListOptionDetails pageFormat = printDetailedOptions.CreateItemListOption("PageRange", "Page Range");
pageFormat.AddItem("PrintAll", "Print all");
pageFormat.AddItem("PrintSelection", "Print Selection");
pageFormat.AddItem("PrintRange", "Print Range");
```

カスタム印刷オプションを追加し、イベント ハンドラーを割り当てます。 カスタム オプションは最後に追加されるため、オプションの一覧の最下部に表示されます。 ただし、カスタム オプションは一覧のどこにでも配置可能です。必ずしもカスタム印刷オプションを最後に追加する必要はありません。

```csharp
// Add the custom option to the option list
displayedOptions.Add("PageRange");

// Create new edit option
PrintCustomTextOptionDetails pageRangeEdit = printDetailedOptions.CreateTextOption("PageRangeEdit", "Range");

// Register the handler for the option change event
printDetailedOptions.OptionChanged += printDetailedOptions_OptionChanged;
```

[**CreateTextOption**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.optiondetails.printtaskoptiondetails.createtextoption) メソッドによって **[範囲]** ボックスが作成されます。 これは、ユーザーが **[印刷範囲]** オプションを選んだときに印刷対象となるページを入力する場所です。

## <a name="handle-print-option-changes"></a>印刷オプションの変更の処理

**OptionChanged** イベント ハンドラーは主に次の 2 つを実行します。 まず、ユーザーが選んだページ範囲オプションに応じて、ページ範囲のテキスト編集フィールドの表示/非表示を切り替えます。 そして、ページ範囲ボックスに入力されたテキストをテストして、ドキュメントの有効ページ範囲であるかどうかを確認します。

この例は、[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)による変更イベントの処理方法を示します。

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

> [!TIP]
> [Range] ボックスにユーザーが入力したページ範囲を解析する方法について詳しくは、[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)の `GetPagesInRange` メソッドをご覧ください。

## <a name="preview-selected-pages"></a>選んだページのプレビュー

アプリのコンテンツ印刷用の書式設定は、アプリの特性とコンテンツによって異なります。 [UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)では、印刷ヘルパー クラスを使ってそのコンテンツの書式を印刷用に設定しています。

ページのサブセットを印刷するとき、印刷プレビューでコンテンツを表示する方法はいくつかあります。 指定されたページ範囲をどのような方法で印刷プレビューに表示するかに関係なく、印刷出力には、選ばれたページだけが含まれている必要があります。

-   ページ範囲が指定されているかどうかに関係なく印刷プレビューにすべてのページを表示し、実際にどのページを印刷するかはユーザーの判断に委ねます。
-   ユーザーがページ範囲で選んだページだけを印刷プレビューに表示し、ページ範囲が変更されるたびに、表示を最新の情報に更新します。
-   すべてのページを印刷プレビューに表示します。ただし、ユーザーが選んだページ範囲に含まれていないページは灰色で表示されます。

## <a name="related-topics"></a>関連トピック

* [印刷のガイドラインの設計](https://msdn.microsoft.com/library/windows/apps/Hh868178)
* [//Build 2015 のビデオ: Windows 10 で印刷するアプリの開発](https://channel9.msdn.com/Events/Build/2015/2-94)
* [UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)
