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
ms.sourcegitcommit: 7efffcc715a4be26f0cf7f7e249653d8c356319b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/30/2018
ms.locfileid: "3112510"
---
# <a name="customize-the-print-preview-ui"></a>印刷プレビュー UI のカスタマイズ



**重要な API**

-   [**Windows.Graphics.Printing**](https://msdn.microsoft.com/library/windows/apps/BR226489)
-   [**Windows.UI.Xaml.Printing**](https://msdn.microsoft.com/library/windows/apps/BR243325)
-   [**PrintManager**](https://msdn.microsoft.com/library/windows/apps/BR226426)

このセクションでは、印刷プレビュー UI の印刷オプションや設定をカスタマイズする方法について説明します。 印刷機能の詳細については、「[アプリからの印刷](print-from-your-app.md)」を参照してください。

**ヒント:** このトピックに含まれる例のほとんどは、印刷サンプルを基盤としています。 完全なコードを確認するには、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619984)から[ユニバーサル Windows プラットフォーム (UWP) 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619979)をダウンロードしてください。

 

## <a name="customize-print-options"></a>印刷オプションのカスタマイズ

既定では、印刷プレビュー UI には [**ColorMode**](https://msdn.microsoft.com/library/windows/apps/BR226478)、[**Copies**](https://msdn.microsoft.com/library/windows/apps/BR226479)、および [**Orientation**](https://msdn.microsoft.com/library/windows/apps/BR226486) の印刷オプションが表示されます。 これらに加え、印刷プレビュー UI に追加できるその他の一般的なプリンター オプションがいくつか用意されています。

-   [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR226476)
-   [**Collation**](https://msdn.microsoft.com/library/windows/apps/BR226477)
-   [**Duplex**](https://msdn.microsoft.com/library/windows/apps/BR226480)
-   [**HolePunch**](https://msdn.microsoft.com/library/windows/apps/BR226481)
-   [**InputBin**](https://msdn.microsoft.com/library/windows/apps/BR226482)
-   [**MediaSize**](https://msdn.microsoft.com/library/windows/apps/BR226483)
-   [**MediaType**](https://msdn.microsoft.com/library/windows/apps/BR226484)
-   [**NUp**](https://msdn.microsoft.com/library/windows/apps/BR226485)
-   [**PrintQuality**](https://msdn.microsoft.com/library/windows/apps/BR226487)
-   [**Staple**](https://msdn.microsoft.com/library/windows/apps/BR226488)

これらのオプションは、[**StandardPrintTaskOptions**](https://msdn.microsoft.com/library/windows/apps/BR226475) クラスで定義されます。 印刷プレビュー UI に表示されるオプションの一覧へのオプションの追加や、この一覧からのオプションの削除ができます。 また、オプションが表示される順序の変更や、ユーザーに表示される既定の設定の構成もできます。

ただし、この方法を使って加えた変更は、印刷プレビュー UI にのみ影響します。 ユーザーは印刷プレビュー UI で **[その他の設定]** をタップすることで、プリンターでサポートされているすべてのオプションにいつでもアクセスできます。

**注:** アプリでは、どの印刷オプションも表示するように指定できますが、選んだプリンターでサポートされているオプションのみが印刷プレビュー UI に表示されます。 印刷 UI には、選んだプリンターでサポートされないオプションは表示されません。

 

### <a name="define-the-options-to-display"></a>表示するオプションの定義

アプリの画面が読み込まれると、印刷コントラクトに登録されます。 その登録には、[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベント ハンドラーの定義が含まれています。 印刷プレビュー UI に表示されるオプションをカスタマイズするコードは、**PrintTaskRequested** イベント ハンドラーに追加します。

[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベント ハンドラーを変更して、印刷プレビュー UI に表示する印刷設定を構成する [**printTask.options**](https://msdn.microsoft.com/library/windows/apps/BR226469) 命令を含めます。印刷オプションのカスタマイズ リストを表示するアプリの画面の場合は、ヘルパー クラスの **PrintTaskRequested** イベント ハンドラーを上書きし、この画面が印刷されるときに表示するオプションを指定するコードを含めます。

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

**重要:** [**displayedOptions.clear**](https://msdn.microsoft.com/library/windows/apps/BR226453)() を呼び出すと、**[その他の設定]** リンクを含むすべての印刷オプションが印刷プレビュー UI から削除されます。 印刷プレビュー UI に表示するオプションを必ず追加してください。

### <a name="specify-default-options"></a>既定のオプションの指定

印刷プレビュー UI には、オプションの既定値を設定することもできます。 次のコード行は前の例から抜粋したものであり、[**MediaSize**](https://msdn.microsoft.com/library/windows/apps/BR226483) オプションの既定値を設定しています。

``` csharp
         // Preset the default value of the printer option
         printTask.Options.MediaSize = PrintMediaSize.NorthAmericaLegal;
```         

## <a name="add-new-print-options"></a>新しい印刷オプションの追加

このセクションでは、新しい印刷オプションを作成し、オプションがサポートする値の一覧を定義して、印刷プレビューにオプションを追加する方法について説明します。 前のセクションと同様に、[**PrintTaskRequested**](https://msdn.microsoft.com/library/windows/apps/br206597) イベント ハンドラーに新しい印刷オプションを追加します。

まず、[**PrintTaskOptionDetails**](https://msdn.microsoft.com/library/windows/apps/Hh701256) オブジェクトを取得します。 これは、印刷プレビュー UI に新しい印刷オプションを追加するために使用します。 次に、印刷プレビュー UI に表示されるオプションの一覧をクリアし、ユーザーがアプリから印刷する場合に表示するオプションを追加します。 その後、新しい印刷オプションを作成し、オプションの値の一覧を初期化します。 最後に、新しいオプションを追加して **OptionChanged** イベントのハンドラーを割り当てます。

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

オプションは、追加された順番で印刷プレビュー UI に表示されます。したがって、最初のオプションがウィンドウの最上部に表示されます。 この例では、カスタム オプションは最後に追加されるため、オプションの一覧の最下部に表示されます。 ただし、カスタム オプションは一覧のどこにでも配置可能です。必ずしもカスタム印刷オプションを最後に追加する必要はありません。

ユーザーがカスタム オプションの選択オプションを変更した場合は、印刷プレビューの画像を更新する必要があります。 印刷プレビュー UI の画像を再描画するには、次の例のように、[**InvalidatePreview**](https://msdn.microsoft.com/library/windows/apps/Hh702146) メソッドを呼び出します。

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

## <a name="related-topics"></a>関連トピック

* [印刷のガイドラインの設計](https://msdn.microsoft.com/library/windows/apps/Hh868178)
* [//Build 2015 のビデオ: Windows 10 で印刷するアプリの開発](https://channel9.msdn.com/Events/Build/2015/2-94)
* [UWP 印刷サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619984)
