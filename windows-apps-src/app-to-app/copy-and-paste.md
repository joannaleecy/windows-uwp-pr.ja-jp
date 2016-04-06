---
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、クリップボードを使用してコピーと貼り付けをサポートする方法について説明します。
title: コピーと貼り付け
ms.assetid: E882DC15-E12D-4420-B49D-F495BB484BEE
---
#コピーと貼り付け

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、クリップボードを使用してコピーと貼り付けをサポートする方法について説明します。 コピーと貼り付けはアプリ間やアプリ内でデータを交換するための古典的な方法であり、クリップボード操作はほとんどすべてのアプリである程度サポートできます。

## 組み込みのクリップボード サポートの確認


多くの場合、クリップボード操作をサポートするためのコードを記述する必要はありません。 アプリの作成に使うことができる既定の XAML コントロールの多くは、クリップボード操作をサポートしています。 使用可能なコントロールについて詳しくは、「[コントロールの一覧][ControlsList]」をご覧ください。

## 準備

まず、アプリに [**Windows.ApplicationModel.DataTransfer**][DataTransfer] 名前空間を含めます。 次に、[**DataPackage**][DataPackage] オブジェクトのインスタンスを追加します。 このオブジェクトには、ユーザーがコピーするデータと開発者が含めるプロパティ (説明など) の両方が格納されます。

<!-- For some reason, the snippets in this file are all inline in the WDCML topic. Suggest moving to VS project with rest of snippets. -->
```cs
DataPackage dataPackage = new DataPackage();
```

## コピーと切り取り

コピーと切り取り (移動とも呼ばれます) には、ほぼ同じ機能があります。 [**DataPackage.RequestedOperation**][RequestedOperation] プロパティを使用して、必要な操作を選択します。

```cs
// コピー 
dataPackage.RequestedOperation = DataPackageOperation.Copy;
// または切り取り
dataPackage.RequestedOperation = DataPackageOperation.Move;
```

次に、ユーザーが選択したデータを [**DataPackage**][DataPackage] オブジェクトに追加できます。 このデータが **DataPackage** クラスでサポートされている場合は、**DataPackage** オブジェクトの対応するメソッドを使うことができます。 テキストを追加する方法を次に示します。

```cs
dataPackage.SetText("Hello World!");
```

最後に、静的な [**Clipboard.SetContent**][SetContent] メソッドを呼び出すことによって [**DataPackage**][DataPackage] をクリップボードに追加します。

```cs
Clipboard.SetContent(dataPackage);
```
## 貼り付け

クリップボードの内容を取得するには、静的な [**Clipboard.GetContent**][GetContent] メソッドを呼び出します。 このメソッドは、コンテンツを含む [**DataPackageView**][DataPackageView] を返します。 このオブジェクトは、コンテンツが読み取り専用であることを除いて [**DataPackage**][DataPackage] オブジェクトとほぼ同じです。 このオブジェクトがあれば、[**AvailableFormats**][AvailableFormats] または [**Contains**][Contains] のメソッドを使って使用可能な形式を特定できます。 その後、対応する **DataPackageView** メソッドを呼び出してデータを取得できます。

```cs
DataPackageView dataPackageView = Clipboard.GetContent();
if (dataPackageView.Contains(StandardDataFormats.Text))
{
    string text = await dataPackageView.GetTextAsync();
    // この例のテキストを出力するには、TextBlock コントロールが必要です
    TextOutput.Text = "Clipboard now contains: " + text;
}
```

## クリップボードへの変更の追跡

コピーと貼り付けのコマンドに加えて、クリップボードへの変更を追跡することもできます。 これを行うには、クリップボードの [**Clipboard.ContentChanged**][ContentChanged] イベントを処理します。

```cs
Clipboard.ContentChanged += (s, e) => 
{
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        string text = await dataPackageView.GetTextAsync();
        // To output the text from this example, you need a TextBlock control
        TextOutput.Text = "Clipboard now contains: " + text;
    }
}
```

<!-- LINKS --> 
[DataTransfer]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.aspx 
[DataPackage]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.aspx 
[DataPackageView]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.aspx
[DataPackagePropertySet]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackagepropertyset.aspx 
[DataRequest]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.aspx 
[DataRequested]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx 
[FailWithDisplayText]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.failwithdisplaytext.aspx
[ShowShareUi]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.showshareui.aspx
[RequestedOperation]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.requestedoperation.aspx 
[ControlsList]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/mt185406.aspx 
[SetContent]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.setcontent.aspx 
[GetContent]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.getcontent.aspx
[AvailableFormats]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.availableformats.aspx 
[Contains]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.contains.aspx
[ContentChanged]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.contentchanged.aspx 



<!--HONumber=Mar16_HO1-->


