---
author: PatrickFarley
ms.assetid: 9A0F1852-A76B-4F43-ACFC-2CC56AAD1C03
title: アプリからの印刷
description: ユニバーサル Windows アプリからドキュメントを印刷する方法について説明します。 また、このトピックでは特定のページを印刷する方法も示します。
ms.author: pafarley
ms.date: 01/29/2018
ms.topic: article
keywords: windows 10, uwp, 印刷
ms.localizationpriority: medium
ms.openlocfilehash: b35d11e9dcf1e79296e0eeaff85c975c24d65920
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6452212"
---
# <a name="print-from-your-app"></a><span data-ttu-id="946b8-105">アプリからの印刷</span><span class="sxs-lookup"><span data-stu-id="946b8-105">Print from your app</span></span>



**<span data-ttu-id="946b8-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="946b8-106">Important APIs</span></span>**

-   [**<span data-ttu-id="946b8-107">Windows.Graphics.Printing</span><span class="sxs-lookup"><span data-stu-id="946b8-107">Windows.Graphics.Printing</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226489)
-   [**<span data-ttu-id="946b8-108">Windows.UI.Xaml.Printing</span><span class="sxs-lookup"><span data-stu-id="946b8-108">Windows.UI.Xaml.Printing</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR243325)
-   [**<span data-ttu-id="946b8-109">PrintDocument</span><span class="sxs-lookup"><span data-stu-id="946b8-109">PrintDocument</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR243314)

<span data-ttu-id="946b8-110">ユニバーサル Windows アプリからドキュメントを印刷する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="946b8-110">Learn how to print documents from a Universal Windows app.</span></span> <span data-ttu-id="946b8-111">また、このトピックでは特定のページを印刷する方法も示します。</span><span class="sxs-lookup"><span data-stu-id="946b8-111">This topic also shows how to print specific pages.</span></span> <span data-ttu-id="946b8-112">印刷プレビュー UI の高度な変更については、「[印刷プレビュー UI のカスタマイズ](customize-the-print-preview-ui.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="946b8-112">For more advanced changes to the print preview UI, see [Customize the print preview UI](customize-the-print-preview-ui.md).</span></span>

> [!TIP]
> <span data-ttu-id="946b8-113">このトピックに含まれる例のほとんどは、印刷サンプルを基盤としています。</span><span class="sxs-lookup"><span data-stu-id="946b8-113">Most of the examples in this topic are based on the print sample.</span></span> <span data-ttu-id="946b8-114">完全なコードを確認するには、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619984)から[ユニバーサル Windows プラットフォーム (UWP) 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619979)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="946b8-114">To see the full code, download the [Universal Windows Platform (UWP) print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984) from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub.</span></span>

## <a name="register-for-printing"></a><span data-ttu-id="946b8-115">印刷の登録</span><span class="sxs-lookup"><span data-stu-id="946b8-115">Register for printing</span></span>

<span data-ttu-id="946b8-116">アプリに印刷機能を追加する最初の手順は、印刷コントラクトへの登録です。</span><span class="sxs-lookup"><span data-stu-id="946b8-116">The first step to add printing to your app is to register for the Print contract.</span></span> <span data-ttu-id="946b8-117">アプリは、ユーザーによる印刷を可能にするすべての画面でこの処理を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="946b8-117">Your app must do this on every screen from which you want your user to be able to print.</span></span> <span data-ttu-id="946b8-118">ユーザーに表示される画面のみ、印刷登録を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="946b8-118">Only the screen that is displayed to the user can be registered for printing.</span></span> <span data-ttu-id="946b8-119">アプリの画面を印刷登録した場合は、画面終了時に印刷登録を解除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="946b8-119">If one screen of your app has registered for printing, it must unregister for printing when it exits.</span></span> <span data-ttu-id="946b8-120">別の画面で置き換えられる場合は、その画面が開いたときに画面を新しい印刷コントラクトに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="946b8-120">If it is replaced by another screen, the next screen must register for a new Print contract when it opens.</span></span>

> [!TIP]
> <span data-ttu-id="946b8-121">アプリで複数ページからの印刷をサポートする必要がある場合は、この印刷コードを共通の基底ヘルパー クラスに入れ、アプリ ページでそれを再利用させることができます。</span><span class="sxs-lookup"><span data-stu-id="946b8-121">If you need to support printing from more than one page in your app, you can put this print code in a common helper class and have your app pages reuse it.</span></span> <span data-ttu-id="946b8-122">この方法の例については、[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)に挙げられている `PrintHelper` クラスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="946b8-122">For an example of how to do this, see the `PrintHelper` class in the [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984).</span></span>

<span data-ttu-id="946b8-123">まず、[**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) と [**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="946b8-123">First, declare the [**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) and [**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314).</span></span> <span data-ttu-id="946b8-124">他の Windows 印刷機能をサポートするタイプと共に、**PrintManager** タイプが [**Windows.Graphics.Printing**](https://msdn.microsoft.com/library/windows/apps/BR226489) 名前空間内に指定されています。</span><span class="sxs-lookup"><span data-stu-id="946b8-124">The **PrintManager** type is in the [**Windows.Graphics.Printing**](https://msdn.microsoft.com/library/windows/apps/BR226489) namespace along with types to support other Windows printing functionality.</span></span> <span data-ttu-id="946b8-125">XAML コンテンツの印刷準備をサポートする他のタイプと共に、**PrintDocument** タイプが [**Windows.UI.Xaml.Printing**](https://msdn.microsoft.com/library/windows/apps/BR243325) 名前空間内に指定されています。</span><span class="sxs-lookup"><span data-stu-id="946b8-125">The **PrintDocument** type is in the [**Windows.UI.Xaml.Printing**](https://msdn.microsoft.com/library/windows/apps/BR243325) namespace along with other types that support preparing XAML content for printing.</span></span> <span data-ttu-id="946b8-126">次の **using** ステートメントまたは **Imports** ステートメントをページに追加することで、印刷コードを簡単に記述できます。</span><span class="sxs-lookup"><span data-stu-id="946b8-126">You can make it easier to write your printing code by adding the following **using** or **Imports** statements to your page.</span></span>

```csharp
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
```

<span data-ttu-id="946b8-127">[**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314) クラスはアプリと [**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) 間の多くの対話を処理しますが、独自のコールバックがいくつか公開されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-127">The [**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314) class is used to handle much of the interaction between the app and the [**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426), but it exposes several callbacks of its own.</span></span> <span data-ttu-id="946b8-128">登録中に **PrintManager** と **PrintDocument** のインスタンスを作成し、それらの印刷イベントのハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="946b8-128">During registration, create instances of **PrintManager** and **PrintDocument** and register handlers for their printing events.</span></span>

<span data-ttu-id="946b8-129">[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)では、登録は `RegisterForPrinting` メソッドによって実行されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-129">In the [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984), registration is performed by the `RegisterForPrinting` method.</span></span>

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

<span data-ttu-id="946b8-130">ユーザーが印刷のサポートされているページに移動すると、`OnNavigatedTo` メソッド内で登録を開始します。</span><span class="sxs-lookup"><span data-stu-id="946b8-130">When the user goes to a page that supports printing, it initiates the registration within the `OnNavigatedTo` method.</span></span>

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

<span data-ttu-id="946b8-131">ユーザーがページから離れた時点で、印刷イベント ハンドラーを切り離します。</span><span class="sxs-lookup"><span data-stu-id="946b8-131">When the user leaves the page, disconnect the printing event handlers.</span></span> <span data-ttu-id="946b8-132">複数ページ アプリが存在し、印刷を切断しないと、ユーザーがページからいったん移動してそのページに戻ってきたときに例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="946b8-132">If you have a multiple-page app and don't disconnect printing, an exception is thrown when the user leaves the page and then comes back to it.</span></span>

```csharp
protected override void OnNavigatedFrom(NavigationEventArgs e)
{
   if (printHelper != null)
   {
         printHelper.UnregisterForPrinting();
   }
}
```
## <a name="create-a-print-button"></a><span data-ttu-id="946b8-133">印刷ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="946b8-133">Create a print button</span></span>

<span data-ttu-id="946b8-134">アプリの画面の任意の場所に印刷ボタンを追加します。</span><span class="sxs-lookup"><span data-stu-id="946b8-134">Add a print button to your app's screen where you'd like it to appear.</span></span> <span data-ttu-id="946b8-135">印刷するコンテンツの妨げにならないようにします。</span><span class="sxs-lookup"><span data-stu-id="946b8-135">Make sure that it doesn't interfere with the content that you want to print.</span></span>

```xml
<Button x:Name="InvokePrintingButton" Content="Print" Click="OnPrintButtonClick"/>
```

<span data-ttu-id="946b8-136">次に、クリック イベントを処理するイベント ハンドラーをアプリのコードに追加します。</span><span class="sxs-lookup"><span data-stu-id="946b8-136">Next, add an event handler to your app's code to handle the click event.</span></span> <span data-ttu-id="946b8-137">[**ShowPrintUIAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printmanager.showprintuiasync) メソッドを使用してアプリからの印刷を開始します。</span><span class="sxs-lookup"><span data-stu-id="946b8-137">Use the [**ShowPrintUIAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printmanager.showprintuiasync) method to start printing from your app.</span></span> <span data-ttu-id="946b8-138">**ShowPrintUIAsync** は適切な印刷ウィンドウを表示する非同期メソッドです。</span><span class="sxs-lookup"><span data-stu-id="946b8-138">**ShowPrintUIAsync** is an asynchronous method that displays the appropriate printing window.</span></span> <span data-ttu-id="946b8-139">印刷をサポートするデバイス上でアプリが実行されていることを確認する (およびサポートされていないケースに対処する) ために、先に [**IsSupported**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Printing.PrintManager.IsSupported) メソッドを呼び出すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="946b8-139">We recommend calling the [**IsSupported**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Printing.PrintManager.IsSupported) method first in order to check that the app is being run on a device that supports printing (and handle the case in which it is not).</span></span> <span data-ttu-id="946b8-140">その時点でなんらかの理由で印刷を実行できない場合は、**ShowPrintUIAsync** は例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="946b8-140">If printing can't be performed at that time for any other reason, **ShowPrintUIAsync** will throw an exception.</span></span> <span data-ttu-id="946b8-141">印刷を続行できない場合は、これらの例外をキャッチして、ユーザーに知らせることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="946b8-141">We recommend catching these exceptions and letting the user know when printing can't proceed.</span></span>

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

<span data-ttu-id="946b8-142">この例では、ボタン クリックのイベント ハンドラーに印刷ウィンドウが表示されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-142">In this example, a print window is displayed in the event handler for a button click.</span></span> <span data-ttu-id="946b8-143">メソッドによって例外がスローされる場合 (その時点で印刷を実行することができないため)、[**ContentDialog**](https://msdn.microsoft.com/library/windows/apps/Dn633972) コントロールによってその状況がユーザーに通知されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-143">If the method throws an exception (because printing can't be performed at that time), a [**ContentDialog**](https://msdn.microsoft.com/library/windows/apps/Dn633972) control informs the user of the situation.</span></span>

## <a name="format-your-apps-content"></a><span data-ttu-id="946b8-144">アプリのコンテンツの書式設定</span><span class="sxs-lookup"><span data-stu-id="946b8-144">Format your app's content</span></span>

<span data-ttu-id="946b8-145">**ShowPrintUIAsync** が呼び出されると、[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="946b8-145">When **ShowPrintUIAsync** is called, the [**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) event is raised.</span></span> <span data-ttu-id="946b8-146">この手順に示す **PrintTaskRequested** イベント ハンドラーは、[**PrintTaskRequest.CreatePrintTask**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printtaskrequest.createprinttask.aspx) メソッドを呼び出して [**PrintTask**](https://msdn.microsoft.com/library/windows/apps/BR226436) を作成し、印刷ページのタイトルと [**PrintTaskSourceRequestedHandler**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printtask.source) デリゲートの名前を渡します。</span><span class="sxs-lookup"><span data-stu-id="946b8-146">The **PrintTaskRequested** event handler shown in this step creates a [**PrintTask**](https://msdn.microsoft.com/library/windows/apps/BR226436) by calling the [**PrintTaskRequest.CreatePrintTask**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printtaskrequest.createprinttask.aspx) method and passes the title for the print page and the name of a [**PrintTaskSourceRequestedHandler**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.printtask.source) delegate.</span></span> <span data-ttu-id="946b8-147">この例では、**PrintTaskSourceRequestedHandler** がインラインで定義されています。</span><span class="sxs-lookup"><span data-stu-id="946b8-147">Notice that in this example, the **PrintTaskSourceRequestedHandler** is defined inline.</span></span> <span data-ttu-id="946b8-148">**PrintTaskSourceRequestedHandler** は、印刷用の書式付きコンテンツを用意します (後述)。</span><span class="sxs-lookup"><span data-stu-id="946b8-148">The **PrintTaskSourceRequestedHandler** provides the formatted content for printing and is described later.</span></span>

<span data-ttu-id="946b8-149">この例では、エラーを捕捉するために完了ハンドラーも定義されています。</span><span class="sxs-lookup"><span data-stu-id="946b8-149">In this example, a completion handler is also defined to catch errors.</span></span> <span data-ttu-id="946b8-150">エラー発生の有無をユーザーに知らせ、考えられる解決策を提供することが可能になるため、完了イベントを処理することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="946b8-150">It's a good idea to handle completion events because then your app can let the user know if an error occurred and provide possible solutions.</span></span> <span data-ttu-id="946b8-151">同様に、完了イベントを使うと、印刷ジョブが正常に終了した後でユーザーが実行する手順を提示することができます。</span><span class="sxs-lookup"><span data-stu-id="946b8-151">Likewise, your app could use the completion event to indicate subsequent steps for the user to take after the print job is successful.</span></span>

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

<span data-ttu-id="946b8-152">印刷タスクが作られた後、[**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) は [**Paginate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.paginate) イベントを発生させることによって、印刷プレビュー UI に表示するために印刷ページのコレクションを要求します。</span><span class="sxs-lookup"><span data-stu-id="946b8-152">After the print task is created, the [**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) requests a collection of print pages to show in the print preview UI by raising the [**Paginate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.paginate) event.</span></span> <span data-ttu-id="946b8-153">これは、**IPrintPreviewPageCollection** インターフェイスの **Paginate** メソッドに対応します。</span><span class="sxs-lookup"><span data-stu-id="946b8-153">This corresponds with the **Paginate** method of the **IPrintPreviewPageCollection** interface.</span></span> <span data-ttu-id="946b8-154">登録時に作成したイベント ハンドラーは、この時点で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-154">The event handler you created during registration will be called at this time.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="946b8-155">ユーザーが印刷設定を変更すると、ページ設定イベント ハンドラーがもう一度呼び出されてコンテンツを再配置できます。</span><span class="sxs-lookup"><span data-stu-id="946b8-155">If the user changes print settings, the paginate event handler will be called again to allow you to reflow the content.</span></span> <span data-ttu-id="946b8-156">優良なユーザー エクスペリエンスのため、マイクロソフトではコンテンツを再配置する前に設定を確認し、ページ付けされたコンテンツの不必要な再初期化を避けることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="946b8-156">For the best user experience, we recommend checking the settings before you reflow the content and avoid reinitializing the paginated content when it's not necessary.</span></span>

<span data-ttu-id="946b8-157">[**Paginate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.paginate) イベント ハンドラー ([UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)内の `CreatePrintPreviewPages` メソッド) で、印刷プレビュー UI に表示されてプリンターに送信されるページを作ります。</span><span class="sxs-lookup"><span data-stu-id="946b8-157">In the [**Paginate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.paginate) event handler (the `CreatePrintPreviewPages` method in the [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984)), create the pages to show in the print preview UI and to send to the printer.</span></span> <span data-ttu-id="946b8-158">アプリのコンテンツの印刷準備のために使うコードは、アプリと印刷するコンテンツに固有です。</span><span class="sxs-lookup"><span data-stu-id="946b8-158">The code you use to prepare your app's content for printing is specific to your app and the content you print.</span></span> <span data-ttu-id="946b8-159">コンテンツを印刷用に書式設定する方法については、[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)のソース コードを参照してください。</span><span class="sxs-lookup"><span data-stu-id="946b8-159">Refer to the [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984) source code to see how it formats its content for printing.</span></span>

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

<span data-ttu-id="946b8-160">特定のページが印刷プレビュー ウィンドウに表示されると、[**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) によって [**GetPreviewPage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.getpreviewpage) イベントが生成されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-160">When a particular page is to be shown in the print preview window, the [**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) raises the [**GetPreviewPage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.getpreviewpage) event.</span></span> <span data-ttu-id="946b8-161">これは、**IPrintPreviewPageCollection** インターフェイスの **MakePage** メソッドに対応します。</span><span class="sxs-lookup"><span data-stu-id="946b8-161">This corresponds with the **MakePage** method of the **IPrintPreviewPageCollection** interface.</span></span> <span data-ttu-id="946b8-162">登録時に作成したイベント ハンドラーは、この時点で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-162">The event handler you created during registration will be called at this time.</span></span>

<span data-ttu-id="946b8-163">[**GetPreviewPage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.getpreviewpage) イベント ハンドラー ([UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)内の `GetPrintPreviewPage` メソッド) で、適切なページを印刷ドキュメントに設定します。</span><span class="sxs-lookup"><span data-stu-id="946b8-163">In the [**GetPreviewPage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.getpreviewpage) event handler (the `GetPrintPreviewPage` method in the [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984)), set the appropriate page on the print document.</span></span>

```csharp
protected virtual void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
{
   PrintDocument printDoc = (PrintDocument)sender;
   printDoc.SetPreviewPage(e.PageNumber, printPreviewPages[e.PageNumber - 1]);
}
```

<span data-ttu-id="946b8-164">最後に、ユーザーが印刷ボタンをクリックすると、[**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) によって **IDocumentPageSource** インターフェイスの **MakeDocument** メソッドが呼び出され、プリンターに送信するページの最終コレクションが要求されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-164">Finally, once the user clicks the print button, the [**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426) requests the final collection of pages to send to the printer by calling the **MakeDocument** method of the **IDocumentPageSource** interface.</span></span> <span data-ttu-id="946b8-165">XAML では、これによって [**AddPages**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.addpages) イベントが生成されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-165">In XAML, this raises the [**AddPages**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.addpages) event.</span></span> <span data-ttu-id="946b8-166">登録時に作成したイベント ハンドラーは、この時点で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-166">The event handler you created during registration will be called at this time.</span></span>

<span data-ttu-id="946b8-167">[**AddPages**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.addpages) イベント ハンドラー ([UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)内の `AddPrintPages` メソッド) で、ページ コレクションから、プリンターに送られる [**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314) オブジェクトにページを追加します。</span><span class="sxs-lookup"><span data-stu-id="946b8-167">In the [**AddPages**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.printing.printdocument.addpages) event handler (the `AddPrintPages` method in the [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984)), add pages from the page collection to the [**PrintDocument**](https://msdn.microsoft.com/library/windows/apps/BR243314) object to be sent to the printer.</span></span> <span data-ttu-id="946b8-168">印刷する特定ページまたはページ範囲がユーザーによって指定される場合は、プリンターに実際に送られるページだけを追加するためにその情報をここで使います。</span><span class="sxs-lookup"><span data-stu-id="946b8-168">If a user specifies particular pages or a range of pages to print, you use that information here to add only the pages that will actually be sent to the printer.</span></span>

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

## <a name="prepare-print-options"></a><span data-ttu-id="946b8-169">印刷オプションの準備</span><span class="sxs-lookup"><span data-stu-id="946b8-169">Prepare print options</span></span>

<span data-ttu-id="946b8-170">次に、印刷オプションを準備します。</span><span class="sxs-lookup"><span data-stu-id="946b8-170">Next prepare print options.</span></span> <span data-ttu-id="946b8-171">たとえば、このセクションでは特定のページの印刷を許可するためにページ範囲オプションを設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="946b8-171">As an example, this section will describe how to set the page range option to allow printing of specific pages.</span></span> <span data-ttu-id="946b8-172">詳細なオプションについては、「[印刷プレビュー UI のカスタマイズ](customize-the-print-preview-ui.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="946b8-172">For more advanced options, see [Customize the print preview UI](customize-the-print-preview-ui.md).</span></span>

<span data-ttu-id="946b8-173">この手順では、新しい印刷オプションを作成し、オプションがサポートする値の一覧を定義して、印刷プレビュー UI にオプションを追加します。</span><span class="sxs-lookup"><span data-stu-id="946b8-173">This step creates a new print option, defines a list of values that the option supports, and then adds the option to the print preview UI.</span></span> <span data-ttu-id="946b8-174">ページ範囲オプションでは次の設定を指定できます。</span><span class="sxs-lookup"><span data-stu-id="946b8-174">The page range option has these settings:</span></span>

| <span data-ttu-id="946b8-175">オプション名</span><span class="sxs-lookup"><span data-stu-id="946b8-175">Option name</span></span>          | <span data-ttu-id="946b8-176">アクション</span><span class="sxs-lookup"><span data-stu-id="946b8-176">Action</span></span> |
|----------------------|--------|
| **<span data-ttu-id="946b8-177">Print all</span><span class="sxs-lookup"><span data-stu-id="946b8-177">Print all</span></span>**        | <span data-ttu-id="946b8-178">ドキュメントのすべてのページを印刷します。</span><span class="sxs-lookup"><span data-stu-id="946b8-178">Print all pages in the document.</span></span>|
| **<span data-ttu-id="946b8-179">Print Selection</span><span class="sxs-lookup"><span data-stu-id="946b8-179">Print Selection</span></span>**  | <span data-ttu-id="946b8-180">ユーザーが選んだ内容のみを印刷します。</span><span class="sxs-lookup"><span data-stu-id="946b8-180">Print only the content the user selected.</span></span>|
| **<span data-ttu-id="946b8-181">Print Range</span><span class="sxs-lookup"><span data-stu-id="946b8-181">Print Range</span></span>**      | <span data-ttu-id="946b8-182">ユーザーが印刷するページを入力できる編集コントロールを表示します。</span><span class="sxs-lookup"><span data-stu-id="946b8-182">Display an edit control into which the user can enter the pages to print.</span></span>|

<span data-ttu-id="946b8-183">まず、[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベント ハンドラーを変更し、[**PrintTaskOptionDetails**](https://msdn.microsoft.com/library/windows/apps/Hh701256) オブジェクトを取得するコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="946b8-183">First, modify the [**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) event handler to add the code to get a [**PrintTaskOptionDetails**](https://msdn.microsoft.com/library/windows/apps/Hh701256) object.</span></span>

```csharp
PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(printTask.Options);
```

<span data-ttu-id="946b8-184">印刷プレビュー UI に表示されるオプションの一覧をクリアし、ユーザーがアプリから印刷する場合に表示するオプションを追加します。</span><span class="sxs-lookup"><span data-stu-id="946b8-184">Clear the list of options that are shown in the print preview UI and add the options that you want to display when the user wants to print from the app.</span></span>

> [!NOTE]
> <span data-ttu-id="946b8-185">オプションは、追加された順番で印刷プレビュー UI に表示されます。したがって、最初のオプションがウィンドウの最上部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-185">The options appear in the print preview UI in the same order they are appended, with the first option shown at the top of the window.</span></span>

```csharp
IList<string> displayedOptions = printDetailedOptions.DisplayedOptions;

displayedOptions.Clear();
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Copies);
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Orientation);
displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.ColorMode);
```

<span data-ttu-id="946b8-186">新しい印刷オプションを作成し、オプションの値の一覧を初期化します。</span><span class="sxs-lookup"><span data-stu-id="946b8-186">Create the new print option and initialize the list of option values.</span></span>

```csharp
// Create a new list option
PrintCustomItemListOptionDetails pageFormat = printDetailedOptions.CreateItemListOption("PageRange", "Page Range");
pageFormat.AddItem("PrintAll", "Print all");
pageFormat.AddItem("PrintSelection", "Print Selection");
pageFormat.AddItem("PrintRange", "Print Range");
```

<span data-ttu-id="946b8-187">カスタム印刷オプションを追加し、イベント ハンドラーを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="946b8-187">Add your custom print option and assign the event handler.</span></span> <span data-ttu-id="946b8-188">カスタム オプションは最後に追加されるため、オプションの一覧の最下部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-188">The custom option is appended last so that it appears at the bottom of the list of options.</span></span> <span data-ttu-id="946b8-189">ただし、カスタム オプションは一覧のどこにでも配置可能です。必ずしもカスタム印刷オプションを最後に追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="946b8-189">But you can put it anywhere in the list, custom print options don't need to be added last.</span></span>

```csharp
// Add the custom option to the option list
displayedOptions.Add("PageRange");

// Create new edit option
PrintCustomTextOptionDetails pageRangeEdit = printDetailedOptions.CreateTextOption("PageRangeEdit", "Range");

// Register the handler for the option change event
printDetailedOptions.OptionChanged += printDetailedOptions_OptionChanged;
```

<span data-ttu-id="946b8-190">[**CreateTextOption**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.optiondetails.printtaskoptiondetails.createtextoption) メソッドによって **[範囲]** ボックスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-190">The [**CreateTextOption**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing.optiondetails.printtaskoptiondetails.createtextoption) method creates the **Range** text box.</span></span> <span data-ttu-id="946b8-191">これは、ユーザーが **[印刷範囲]** オプションを選んだときに印刷対象となるページを入力する場所です。</span><span class="sxs-lookup"><span data-stu-id="946b8-191">This is where the user enters the specific pages they want to print when they select the **Print Range** option.</span></span>

## <a name="handle-print-option-changes"></a><span data-ttu-id="946b8-192">印刷オプションの変更の処理</span><span class="sxs-lookup"><span data-stu-id="946b8-192">Handle print option changes</span></span>

<span data-ttu-id="946b8-193">**OptionChanged** イベント ハンドラーは主に次の 2 つを実行します。</span><span class="sxs-lookup"><span data-stu-id="946b8-193">The **OptionChanged** event handler does two things.</span></span> <span data-ttu-id="946b8-194">まず、ユーザーが選んだページ範囲オプションに応じて、ページ範囲のテキスト編集フィールドの表示/非表示を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="946b8-194">First, it shows and hides the text edit field for the page range depending on the page range option that the user selected.</span></span> <span data-ttu-id="946b8-195">そして、ページ範囲ボックスに入力されたテキストをテストして、ドキュメントの有効ページ範囲であるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="946b8-195">Second, it tests the text entered into the page range text box to make sure that it represents a valid page range for the document.</span></span>

<span data-ttu-id="946b8-196">この例は、[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)による変更イベントの処理方法を示します。</span><span class="sxs-lookup"><span data-stu-id="946b8-196">This example shows how the [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984) handles change events.</span></span>

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
> <span data-ttu-id="946b8-197">[Range] ボックスにユーザーが入力したページ範囲を解析する方法について詳しくは、[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)の `GetPagesInRange` メソッドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="946b8-197">See the `GetPagesInRange` method in the [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984) for details on how to parse the page range the user enters in the Range text box.</span></span>

## <a name="preview-selected-pages"></a><span data-ttu-id="946b8-198">選んだページのプレビュー</span><span class="sxs-lookup"><span data-stu-id="946b8-198">Preview selected pages</span></span>

<span data-ttu-id="946b8-199">アプリのコンテンツ印刷用の書式設定は、アプリの特性とコンテンツによって異なります。</span><span class="sxs-lookup"><span data-stu-id="946b8-199">How you format your app's content for printing depends on the nature of your app and its content.</span></span> <span data-ttu-id="946b8-200">[UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)では、印刷ヘルパー クラスを使ってそのコンテンツの書式を印刷用に設定しています。</span><span class="sxs-lookup"><span data-stu-id="946b8-200">The [UWP print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984) uses a print helper class to format its content for printing.</span></span>

<span data-ttu-id="946b8-201">ページのサブセットを印刷するとき、印刷プレビューでコンテンツを表示する方法はいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="946b8-201">When printing a subset of the pages, there are several ways to show the content in the print preview.</span></span> <span data-ttu-id="946b8-202">指定されたページ範囲をどのような方法で印刷プレビューに表示するかに関係なく、印刷出力には、選ばれたページだけが含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="946b8-202">Regardless of the method you chose to show the page range in the print preview, the printed output must contain only the selected pages.</span></span>

-   <span data-ttu-id="946b8-203">ページ範囲が指定されているかどうかに関係なく印刷プレビューにすべてのページを表示し、実際にどのページを印刷するかはユーザーの判断に委ねます。</span><span class="sxs-lookup"><span data-stu-id="946b8-203">Show all the pages in the print preview whether a page range is specified or not, leaving the user to know which pages will actually be printed.</span></span>
-   <span data-ttu-id="946b8-204">ユーザーがページ範囲で選んだページだけを印刷プレビューに表示し、ページ範囲が変更されるたびに、表示を最新の情報に更新します。</span><span class="sxs-lookup"><span data-stu-id="946b8-204">Show only the pages selected by the user's page range in the print preview, updating the display whenever the user changes the page range.</span></span>
-   <span data-ttu-id="946b8-205">すべてのページを印刷プレビューに表示します。ただし、ユーザーが選んだページ範囲に含まれていないページは灰色で表示されます。</span><span class="sxs-lookup"><span data-stu-id="946b8-205">Show all the pages in print preview, but grey out the pages that are not in page range selected by the user.</span></span>

## <a name="related-topics"></a><span data-ttu-id="946b8-206">関連トピック</span><span class="sxs-lookup"><span data-stu-id="946b8-206">Related topics</span></span>

* [<span data-ttu-id="946b8-207">印刷のガイドラインの設計</span><span class="sxs-lookup"><span data-stu-id="946b8-207">Design guidelines for printing</span></span>](https://msdn.microsoft.com/library/windows/apps/Hh868178)
* [<span data-ttu-id="946b8-208">//Build 2015 のビデオ: Windows 10 で印刷するアプリの開発</span><span class="sxs-lookup"><span data-stu-id="946b8-208">//Build 2015 video: Developing apps that print in Windows 10</span></span>](https://channel9.msdn.com/Events/Build/2015/2-94)
* [<span data-ttu-id="946b8-209">UWP 印刷サンプル</span><span class="sxs-lookup"><span data-stu-id="946b8-209">UWP print sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619984)
