---
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、クリップボードを使用してコピーと貼り付けをサポートする方法について説明します。
title: コピーと貼り付け
ms.assetid: E882DC15-E12D-4420-B49D-F495BB484BEE
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ca01be87619dc88cc39b0c2906d9689768c0fa46
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1662572"
---
# <a name="copy-and-paste"></a><span data-ttu-id="7da74-104">コピーと貼り付け</span><span class="sxs-lookup"><span data-stu-id="7da74-104">Copy and paste</span></span>

<span data-ttu-id="7da74-105">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、クリップボードを使用してコピーと貼り付けをサポートする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7da74-105">This article explains how to support copy and paste in Universal Windows Platform (UWP) apps using the clipboard.</span></span> <span data-ttu-id="7da74-106">コピーと貼り付けはアプリ間やアプリ内でデータを交換するための古典的な方法であり、クリップボード操作はほとんどすべてのアプリである程度サポートできます。</span><span class="sxs-lookup"><span data-stu-id="7da74-106">Copy and paste is the classic way to exchange data either between apps, or within an app, and almost every app can support clipboard operations to some degree.</span></span>

## <a name="check-for-built-in-clipboard-support"></a><span data-ttu-id="7da74-107">組み込みのクリップボード サポートの確認</span><span class="sxs-lookup"><span data-stu-id="7da74-107">Check for built-in clipboard support</span></span>

<span data-ttu-id="7da74-108">多くの場合、クリップボード操作をサポートするためのコードを記述する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7da74-108">In many cases, you do not need to write code to support clipboard operations.</span></span> <span data-ttu-id="7da74-109">アプリの作成に使うことができる既定の XAML コントロールの多くは、クリップボード操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7da74-109">Many of the default XAML controls you can use to create apps already support clipboard operations.</span></span> 

## <a name="get-set-up"></a><span data-ttu-id="7da74-110">準備</span><span class="sxs-lookup"><span data-stu-id="7da74-110">Get set up</span></span>

<span data-ttu-id="7da74-111">まず、アプリに [**Windows.ApplicationModel.DataTransfer**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer) 名前空間を含めます。</span><span class="sxs-lookup"><span data-stu-id="7da74-111">First, include the [**Windows.ApplicationModel.DataTransfer**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer) namespace in your app.</span></span> <span data-ttu-id="7da74-112">次に、[**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) オブジェクトのインスタンスを追加します。</span><span class="sxs-lookup"><span data-stu-id="7da74-112">Then, add an instance of the [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) object.</span></span> <span data-ttu-id="7da74-113">このオブジェクトには、ユーザーがコピーするデータと開発者が含めるプロパティ (説明など) の両方が格納されます。</span><span class="sxs-lookup"><span data-stu-id="7da74-113">This object contains both the data the user wants to copy and any properties (such as a description) that you want to include.</span></span>

<!-- For some reason, the snippets in this file are all inline in the WDCML topic. Suggest moving to VS project with rest of snippets. -->
```cs
DataPackage dataPackage = new DataPackage();
```

<!-- AuthenticateAsync-->

## <a name="copy-and-cut"></a><span data-ttu-id="7da74-114">コピーと切り取り</span><span class="sxs-lookup"><span data-stu-id="7da74-114">Copy and cut</span></span>

<span data-ttu-id="7da74-115">コピーと切り取り (*移動*とも呼ばれます) には、ほぼ同じ機能があります。</span><span class="sxs-lookup"><span data-stu-id="7da74-115">Copy and cut (also referred to as *move*) work almost exactly the same.</span></span> <span data-ttu-id="7da74-116">[**RequestedOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage.RequestedOperation) プロパティを使用して、必要な操作を選択します。</span><span class="sxs-lookup"><span data-stu-id="7da74-116">Choose which operation you want by using the [**RequestedOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage.RequestedOperation) property.</span></span>

```cs
// copy 
dataPackage.RequestedOperation = DataPackageOperation.Copy;
// or cut
dataPackage.RequestedOperation = DataPackageOperation.Move;
```
## <a name="drag-and-drop"></a><span data-ttu-id="7da74-117">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="7da74-117">Drag and drop</span></span>

<span data-ttu-id="7da74-118">次に、ユーザーが選択したデータを [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) オブジェクトに追加できます。</span><span class="sxs-lookup"><span data-stu-id="7da74-118">Next, you can add the data that a user has selected to the [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) object.</span></span> <span data-ttu-id="7da74-119">このデータが **DataPackage** クラスでサポートされている場合は、**DataPackage** オブジェクトの対応するメソッドを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="7da74-119">If this data is supported by the **DataPackage** class, you can use one of the corresponding methods in the **DataPackage** object.</span></span> <span data-ttu-id="7da74-120">テキストを追加する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7da74-120">Here's how to add text:</span></span>

```cs
dataPackage.SetText("Hello World!");
```

<span data-ttu-id="7da74-121">最後に、静的な [**SetContent**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(Windows.ApplicationModel.DataTransfer.DataPackage)) メソッドを呼び出すことによって [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) をクリップボードに追加します。</span><span class="sxs-lookup"><span data-stu-id="7da74-121">The last step is to add the [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) to the clipboard by calling the static [**SetContent**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(Windows.ApplicationModel.DataTransfer.DataPackage)) method.</span></span>

```cs
Clipboard.SetContent(dataPackage);
```
## <a name="paste"></a><span data-ttu-id="7da74-122">貼り付け</span><span class="sxs-lookup"><span data-stu-id="7da74-122">Paste</span></span>

<span data-ttu-id="7da74-123">クリップボードの内容を取得するには、静的な [**GetContent**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.Clipboard.GetContent) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7da74-123">To get the contents of the clipboard, call the static [**GetContent**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.Clipboard.GetContent) method.</span></span> <span data-ttu-id="7da74-124">このメソッドは、コンテンツを含む [**DataPackageView**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackageView) を返します。</span><span class="sxs-lookup"><span data-stu-id="7da74-124">This method returns a [**DataPackageView**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackageView) that contains the content.</span></span> <span data-ttu-id="7da74-125">このオブジェクトは、コンテンツが読み取り専用であることを除いて [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) オブジェクトとほぼ同じです。</span><span class="sxs-lookup"><span data-stu-id="7da74-125">This object is almost identical to a [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) object, except that its contents are read-only.</span></span> <span data-ttu-id="7da74-126">このオブジェクトがあれば、[**AvailableFormats**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackageView.AvailableFormats) または [**Contains**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackageView.Contains(System.String)) のメソッドを使って使用可能な形式を特定できます。</span><span class="sxs-lookup"><span data-stu-id="7da74-126">With that object, you can use either the [**AvailableFormats**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackageView.AvailableFormats) or the [**Contains**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackageView.Contains(System.String)) method to identify what formats are available.</span></span> <span data-ttu-id="7da74-127">その後、対応する [**DataPackageView**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackageView) メソッドを呼び出してデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7da74-127">Then, you can call the corresponding [**DataPackageView**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackageView) method to get the data.</span></span>

```cs
async void OutputClipboardText()
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

## <a name="track-changes-to-the-clipboard"></a><span data-ttu-id="7da74-128">クリップボードへの変更の追跡</span><span class="sxs-lookup"><span data-stu-id="7da74-128">Track changes to the clipboard</span></span>

<span data-ttu-id="7da74-129">コピーと貼り付けのコマンドに加えて、クリップボードへの変更を追跡することもできます。</span><span class="sxs-lookup"><span data-stu-id="7da74-129">In addition to copy and paste commands, you may also want to track clipboard changes.</span></span> <span data-ttu-id="7da74-130">これを行うには、クリップボードの [**ContentChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.Clipboard.ContentChanged) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="7da74-130">Do this by handling the clipboard's [**ContentChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.Clipboard.ContentChanged) event.</span></span>

```cs
Clipboard.ContentChanged += async (s, e) => 
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

## <a name="see-also"></a><span data-ttu-id="7da74-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="7da74-131">See also</span></span>

* [<span data-ttu-id="7da74-132">アプリ間通信</span><span class="sxs-lookup"><span data-stu-id="7da74-132">App-to-app communication</span></span>](index.md)
* [<span data-ttu-id="7da74-133">DataTransfer</span><span class="sxs-lookup"><span data-stu-id="7da74-133">DataTransfer</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.aspx)
* [<span data-ttu-id="7da74-134">DataPackage</span><span class="sxs-lookup"><span data-stu-id="7da74-134">DataPackage</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.aspx)
* [<span data-ttu-id="7da74-135">DataPackageView</span><span class="sxs-lookup"><span data-stu-id="7da74-135">DataPackageView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.aspx)
* [<span data-ttu-id="7da74-136">DataPackagePropertySet</span><span class="sxs-lookup"><span data-stu-id="7da74-136">DataPackagePropertySet</span></span>]( https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackagepropertyset.aspx)
* [<span data-ttu-id="7da74-137">DataRequest</span><span class="sxs-lookup"><span data-stu-id="7da74-137">DataRequest</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.aspx) 
* [<span data-ttu-id="7da74-138">DataRequested</span><span class="sxs-lookup"><span data-stu-id="7da74-138">DataRequested</span></span>]( https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx)
* [<span data-ttu-id="7da74-139">FailWithDisplayText</span><span class="sxs-lookup"><span data-stu-id="7da74-139">FailWithDisplayText</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.failwithdisplaytext.aspx)
* [<span data-ttu-id="7da74-140">ShowShareUi</span><span class="sxs-lookup"><span data-stu-id="7da74-140">ShowShareUi</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.showshareui.aspx)
* [<span data-ttu-id="7da74-141">RequestedOperation</span><span class="sxs-lookup"><span data-stu-id="7da74-141">RequestedOperation</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.requestedoperation.aspx) 
* [<span data-ttu-id="7da74-142">ControlsList</span><span class="sxs-lookup"><span data-stu-id="7da74-142">ControlsList</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/mt185406.aspx)
* [<span data-ttu-id="7da74-143">SetContent</span><span class="sxs-lookup"><span data-stu-id="7da74-143">SetContent</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.setcontent.aspx)
* [<span data-ttu-id="7da74-144">GetContent</span><span class="sxs-lookup"><span data-stu-id="7da74-144">GetContent</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.getcontent.aspx)
* [<span data-ttu-id="7da74-145">AvailableFormats</span><span class="sxs-lookup"><span data-stu-id="7da74-145">AvailableFormats</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.availableformats.aspx)
* [<span data-ttu-id="7da74-146">Contains</span><span class="sxs-lookup"><span data-stu-id="7da74-146">Contains</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.contains.aspx)
* [<span data-ttu-id="7da74-147">ContentChanged</span><span class="sxs-lookup"><span data-stu-id="7da74-147">ContentChanged</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.contentchanged.aspx)

