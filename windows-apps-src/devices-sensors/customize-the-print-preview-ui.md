---
author: PatrickFarley
ms.assetid: 88132B6F-FB50-4B03-BC21-233988746230
title: 印刷プレビュー UI のカスタマイズ
description: このセクションでは、印刷プレビュー UI の印刷オプションや設定をカスタマイズする方法について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 印刷
ms.localizationpriority: medium
ms.openlocfilehash: fe4086cc87699083304594eb4ccc8e7bb137b19f
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4430053"
---
# <a name="customize-the-print-preview-ui"></a><span data-ttu-id="ddc9d-104">印刷プレビュー UI のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="ddc9d-104">Customize the print preview UI</span></span>



**<span data-ttu-id="ddc9d-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="ddc9d-105">Important APIs</span></span>**

-   [**<span data-ttu-id="ddc9d-106">Windows.Graphics.Printing</span><span class="sxs-lookup"><span data-stu-id="ddc9d-106">Windows.Graphics.Printing</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226489)
-   [**<span data-ttu-id="ddc9d-107">Windows.UI.Xaml.Printing</span><span class="sxs-lookup"><span data-stu-id="ddc9d-107">Windows.UI.Xaml.Printing</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR243325)
-   [**<span data-ttu-id="ddc9d-108">PrintManager</span><span class="sxs-lookup"><span data-stu-id="ddc9d-108">PrintManager</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226426)

<span data-ttu-id="ddc9d-109">このセクションでは、印刷プレビュー UI の印刷オプションや設定をカスタマイズする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-109">This section describes how to customize the print options and settings in the print preview UI.</span></span> <span data-ttu-id="ddc9d-110">印刷機能の詳細については、「[アプリからの印刷](print-from-your-app.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-110">For more info about printing, see [Print from your app](print-from-your-app.md).</span></span>

<span data-ttu-id="ddc9d-111">**ヒント:** このトピックに含まれる例のほとんどは、印刷サンプルを基盤としています。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-111">**Tip**  Most of the examples in this topic are based on the print sample.</span></span> <span data-ttu-id="ddc9d-112">完全なコードを確認するには、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619984)から[ユニバーサル Windows プラットフォーム (UWP) 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619979)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-112">To see the full code, download the [Universal Windows Platform (UWP) print sample](http://go.microsoft.com/fwlink/p/?LinkId=619984) from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub.</span></span>

 

## <a name="customize-print-options"></a><span data-ttu-id="ddc9d-113">印刷オプションのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="ddc9d-113">Customize print options</span></span>

<span data-ttu-id="ddc9d-114">既定では、印刷プレビュー UI には [**ColorMode**](https://msdn.microsoft.com/library/windows/apps/BR226478)、[**Copies**](https://msdn.microsoft.com/library/windows/apps/BR226479)、および [**Orientation**](https://msdn.microsoft.com/library/windows/apps/BR226486) の印刷オプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-114">By default, the print preview UI shows the [**ColorMode**](https://msdn.microsoft.com/library/windows/apps/BR226478), [**Copies**](https://msdn.microsoft.com/library/windows/apps/BR226479), and [**Orientation**](https://msdn.microsoft.com/library/windows/apps/BR226486) print options.</span></span> <span data-ttu-id="ddc9d-115">これらに加え、印刷プレビュー UI に追加できるその他の一般的なプリンター オプションがいくつか用意されています。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-115">In addition to those, there are several other common printer options that you can add to the print preview UI:</span></span>

-   [**<span data-ttu-id="ddc9d-116">Binding</span><span class="sxs-lookup"><span data-stu-id="ddc9d-116">Binding</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226476)
-   [**<span data-ttu-id="ddc9d-117">Collation</span><span class="sxs-lookup"><span data-stu-id="ddc9d-117">Collation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226477)
-   [**<span data-ttu-id="ddc9d-118">Duplex</span><span class="sxs-lookup"><span data-stu-id="ddc9d-118">Duplex</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226480)
-   [**<span data-ttu-id="ddc9d-119">HolePunch</span><span class="sxs-lookup"><span data-stu-id="ddc9d-119">HolePunch</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226481)
-   [**<span data-ttu-id="ddc9d-120">InputBin</span><span class="sxs-lookup"><span data-stu-id="ddc9d-120">InputBin</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226482)
-   [**<span data-ttu-id="ddc9d-121">MediaSize</span><span class="sxs-lookup"><span data-stu-id="ddc9d-121">MediaSize</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226483)
-   [**<span data-ttu-id="ddc9d-122">MediaType</span><span class="sxs-lookup"><span data-stu-id="ddc9d-122">MediaType</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226484)
-   [**<span data-ttu-id="ddc9d-123">NUp</span><span class="sxs-lookup"><span data-stu-id="ddc9d-123">NUp</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226485)
-   [**<span data-ttu-id="ddc9d-124">PrintQuality</span><span class="sxs-lookup"><span data-stu-id="ddc9d-124">PrintQuality</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226487)
-   [**<span data-ttu-id="ddc9d-125">Staple</span><span class="sxs-lookup"><span data-stu-id="ddc9d-125">Staple</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR226488)

<span data-ttu-id="ddc9d-126">これらのオプションは、[**StandardPrintTaskOptions**](https://msdn.microsoft.com/library/windows/apps/BR226475) クラスで定義されます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-126">These options are defined in the [**StandardPrintTaskOptions**](https://msdn.microsoft.com/library/windows/apps/BR226475) class.</span></span> <span data-ttu-id="ddc9d-127">印刷プレビュー UI に表示されるオプションの一覧へのオプションの追加や、この一覧からのオプションの削除ができます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-127">You can add to or remove options from the list of options displayed in the print preview UI.</span></span> <span data-ttu-id="ddc9d-128">また、オプションが表示される順序の変更や、ユーザーに表示される既定の設定の構成もできます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-128">You can also change the order in which they appear, and set the default settings that are shown to the user.</span></span>

<span data-ttu-id="ddc9d-129">ただし、この方法を使って加えた変更は、印刷プレビュー UI にのみ影響します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-129">However, the modifications that you make by using this method affect only the print preview UI.</span></span> <span data-ttu-id="ddc9d-130">ユーザーは印刷プレビュー UI で **[その他の設定]** をタップすることで、プリンターでサポートされているすべてのオプションにいつでもアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-130">The user can always access all of the options that the printer supports by tapping **More settings** in the print preview UI.</span></span>

<span data-ttu-id="ddc9d-131">**注:** アプリでは、どの印刷オプションも表示するように指定できますが、選んだプリンターでサポートされているオプションのみが印刷プレビュー UI に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-131">**Note**  Although your app can specify any print options to be displayed, only those that are supported by the selected printer are shown in the print preview UI.</span></span> <span data-ttu-id="ddc9d-132">印刷 UI には、選んだプリンターでサポートされないオプションは表示されません。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-132">The print UI won't show options that the selected printer doesn't support.</span></span>

 

### <a name="define-the-options-to-display"></a><span data-ttu-id="ddc9d-133">表示するオプションの定義</span><span class="sxs-lookup"><span data-stu-id="ddc9d-133">Define the options to display</span></span>

<span data-ttu-id="ddc9d-134">アプリの画面が読み込まれると、印刷コントラクトに登録されます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-134">When the app's screen is loaded, it registers for the Print contract.</span></span> <span data-ttu-id="ddc9d-135">その登録には、[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベント ハンドラーの定義が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-135">Part of that registration includes defining the [**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) event handler.</span></span> <span data-ttu-id="ddc9d-136">印刷プレビュー UI に表示されるオプションをカスタマイズするコードは、**PrintTaskRequested** イベント ハンドラーに追加します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-136">The code to customize the options displayed in the print preview UI is added to the **PrintTaskRequested** event handler.</span></span>

<span data-ttu-id="ddc9d-137">[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベント ハンドラーを変更して、印刷プレビュー UI に表示する印刷設定を構成する [**printTask.options**](https://msdn.microsoft.com/library/windows/apps/BR226469) 命令を含めます。印刷オプションのカスタマイズ リストを表示するアプリの画面の場合は、ヘルパー クラスの **PrintTaskRequested** イベント ハンドラーを上書きし、この画面が印刷されるときに表示するオプションを指定するコードを含めます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-137">Modify the [**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) event handler to include the [**printTask.options**](https://msdn.microsoft.com/library/windows/apps/BR226469) instructions that configure the print settings that you want to display in the print preview UI.For the screen in your app for which you want to show a customized list of print options, override the **PrintTaskRequested** event handler in the helper class to include code that specifies the options to display when the screen is printed.</span></span>

``` csharp
protected override void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
{
   PrintTask printTask = null;
   printTask = e.Request.CreatePrintTask("C# Printing SDK Sample", sourceRequestedArgs =>
   {
         IList<string> displayedOptions = printTask.Options.DisplayedOptions;

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

         sourceRequestedArgs.SetSource(printDocumentSource);
   });
}
```

<span data-ttu-id="ddc9d-138">**重要:** [**displayedOptions.clear**](https://msdn.microsoft.com/library/windows/apps/BR226453)() を呼び出すと、**[その他の設定]** リンクを含むすべての印刷オプションが印刷プレビュー UI から削除されます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-138">**Important**  Calling [**displayedOptions.clear**](https://msdn.microsoft.com/library/windows/apps/BR226453)() removes all of the print options from the print preview UI, including the **More settings** link.</span></span> <span data-ttu-id="ddc9d-139">印刷プレビュー UI に表示するオプションを必ず追加してください。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-139">Be sure to append the options that you want to show on the print preview UI.</span></span>

### <a name="specify-default-options"></a><span data-ttu-id="ddc9d-140">既定のオプションの指定</span><span class="sxs-lookup"><span data-stu-id="ddc9d-140">Specify default options</span></span>

<span data-ttu-id="ddc9d-141">印刷プレビュー UI には、オプションの既定値を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-141">You can also set the default values of the options in the print preview UI.</span></span> <span data-ttu-id="ddc9d-142">次のコード行は前の例から抜粋したものであり、[**MediaSize**](https://msdn.microsoft.com/library/windows/apps/BR226483) オプションの既定値を設定しています。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-142">The following line of code, from the last example, sets the default value of the [**MediaSize**](https://msdn.microsoft.com/library/windows/apps/BR226483) option.</span></span>

``` csharp
         // Preset the default value of the printer option
         printTask.Options.MediaSize = PrintMediaSize.NorthAmericaLegal;
```         

## <a name="add-new-print-options"></a><span data-ttu-id="ddc9d-143">新しい印刷オプションの追加</span><span class="sxs-lookup"><span data-stu-id="ddc9d-143">Add new print options</span></span>

<span data-ttu-id="ddc9d-144">このセクションでは、新しい印刷オプションを作成し、オプションがサポートする値の一覧を定義して、印刷プレビューにオプションを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-144">This section shows how to create a new print option, define a list of values that the option supports, and then add the option to the print preview.</span></span> <span data-ttu-id="ddc9d-145">前のセクションと同様に、[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベント ハンドラーに新しい印刷オプションを追加します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-145">As in the previous section, add the new print option in the [**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) event handler.</span></span>

<span data-ttu-id="ddc9d-146">まず、[**PrintTaskOptionDetails**](https://msdn.microsoft.com/library/windows/apps/Hh701256) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-146">First, get a [**PrintTaskOptionDetails**](https://msdn.microsoft.com/library/windows/apps/Hh701256) object.</span></span> <span data-ttu-id="ddc9d-147">これは、印刷プレビュー UI に新しい印刷オプションを追加するために使用します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-147">This is used to add the new print option to the print preview UI.</span></span> <span data-ttu-id="ddc9d-148">次に、印刷プレビュー UI に表示されるオプションの一覧をクリアし、ユーザーがアプリから印刷する場合に表示するオプションを追加します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-148">Then clear the list of options that are shown in the print preview UI and add the options that you want to display when the user wants to print from the app.</span></span> <span data-ttu-id="ddc9d-149">その後、新しい印刷オプションを作成し、オプションの値の一覧を初期化します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-149">After that, create the new print option and initialize the list of option values.</span></span> <span data-ttu-id="ddc9d-150">最後に、新しいオプションを追加して **OptionChanged** イベントのハンドラーを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-150">Finally, add the new option and assign a handler for the **OptionChanged** event.</span></span>

``` csharp
protected override void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
{
   PrintTask printTask = null;
   printTask = e.Request.CreatePrintTask("C# Printing SDK Sample", sourceRequestedArgs =>
   {
         PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(printTask.Options);
         IList<string> displayedOptions = printDetailedOptions.DisplayedOptions;

         // Choose the printer options to be shown.
         // The order in which the options are appended determines the order in which they appear in the UI
         displayedOptions.Clear();

         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Copies);
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.Orientation);
         displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.ColorMode);

         // Create a new list option
         PrintCustomItemListOptionDetails pageFormat = printDetailedOptions.CreateItemListOption("PageContent", "Pictures");
         pageFormat.AddItem("PicturesText", "Pictures and text");
         pageFormat.AddItem("PicturesOnly", "Pictures only");
         pageFormat.AddItem("TextOnly", "Text only");

         // Add the custom option to the option list
         displayedOptions.Add("PageContent");

         printDetailedOptions.OptionChanged += printDetailedOptions_OptionChanged;

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

         sourceRequestedArgs.SetSource(printDocumentSource);
   });
}
```

<span data-ttu-id="ddc9d-151">オプションは、追加された順番で印刷プレビュー UI に表示されます。したがって、最初のオプションがウィンドウの最上部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-151">The options appear in the print preview UI in the same order they are appended, with the first option shown at the top of the window.</span></span> <span data-ttu-id="ddc9d-152">この例では、カスタム オプションは最後に追加されるため、オプションの一覧の最下部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-152">In this example, the custom option is appended last so that it appears at the bottom of the list of options.</span></span> <span data-ttu-id="ddc9d-153">ただし、カスタム オプションは一覧のどこにでも配置可能です。必ずしもカスタム印刷オプションを最後に追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-153">However, you could put it anywhere in the list; custom print options don't need to be added last.</span></span>

<span data-ttu-id="ddc9d-154">ユーザーがカスタム オプションの選択オプションを変更した場合は、印刷プレビューの画像を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-154">When the user changes the selected option in your custom option, update the print preview image.</span></span> <span data-ttu-id="ddc9d-155">印刷プレビュー UI の画像を再描画するには、次の例のように、[**InvalidatePreview**](https://msdn.microsoft.com/library/windows/apps/Hh702146) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ddc9d-155">Call the [**InvalidatePreview**](https://msdn.microsoft.com/library/windows/apps/Hh702146) method to redraw the image in the print preview UI, as shown below.</span></span>

``` csharp
async void printDetailedOptions_OptionChanged(PrintTaskOptionDetails sender, PrintTaskOptionChangedEventArgs args)
{
   // Listen for PageContent changes
   string optionId = args.OptionId as string;
   if (string.IsNullOrEmpty(optionId))
   {
         return;
   }

   if (optionId == "PageContent")
   {
         await scenarioPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
         {
            printDocument.InvalidatePreview();
         });
   }
}
```

## <a name="related-topics"></a><span data-ttu-id="ddc9d-156">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ddc9d-156">Related topics</span></span>

* [<span data-ttu-id="ddc9d-157">印刷のガイドラインの設計</span><span class="sxs-lookup"><span data-stu-id="ddc9d-157">Design guidelines for printing</span></span>](https://msdn.microsoft.com/library/windows/apps/Hh868178)
* [<span data-ttu-id="ddc9d-158">//Build 2015 のビデオ: Windows 10 で印刷するアプリの開発</span><span class="sxs-lookup"><span data-stu-id="ddc9d-158">//Build 2015 video: Developing apps that print in Windows 10</span></span>](https://channel9.msdn.com/Events/Build/2015/2-94)
* [<span data-ttu-id="ddc9d-159">UWP 印刷サンプル</span><span class="sxs-lookup"><span data-stu-id="ddc9d-159">UWP print sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619984)
