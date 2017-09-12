---
description: "この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトをサポートする方法について説明します。"
title: "データの共有"
ms.assetid: 32287F5E-EB86-4B98-97FF-8F6228D06782
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: fe6da350fbfe006b55e90aee8c12da90967f5711
ms.sourcegitcommit: 23cda44f10059bcaef38ae73fd1d7c8b8330c95e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/19/2017
---
# <a name="share-data"></a><span data-ttu-id="c3182-104">データの共有</span><span class="sxs-lookup"><span data-stu-id="c3182-104">Share data</span></span>

<span data-ttu-id="c3182-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="c3182-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="c3182-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="c3182-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="c3182-107">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトをサポートする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c3182-107">This article explains how to support the Share contract in a Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="c3182-108">共有コントラクトは、テキスト、リンク、写真、ビデオなどのデータをアプリ間ですばやく共有するための簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="c3182-108">The Share contract is an easy way to quickly share data, such as text, links, photos, and videos, between apps.</span></span> <span data-ttu-id="c3182-109">たとえば、ユーザーがソーシャル ネットワーキング アプリを使って友人と Web ページを共有する場合や、後で参照するためにリンクをメモ帳アプリで保存する場合があります。</span><span class="sxs-lookup"><span data-stu-id="c3182-109">For example, a user might want to share a webpage with their friends using a social networking app, or save a link in a notes app to refer to later.</span></span>

## <a name="set-up-an-event-handler"></a><span data-ttu-id="c3182-110">イベント ハンドラーのセットアップ</span><span class="sxs-lookup"><span data-stu-id="c3182-110">Set up an event handler</span></span>

<span data-ttu-id="c3182-111">ユーザーが共有を呼び出したときに呼び出される [**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) イベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="c3182-111">Add a [**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) event handler to be called whenever a user invokes share.</span></span> <span data-ttu-id="c3182-112">このイベントは、ユーザーがアプリ内のコントロール (ボタンやアプリ バー コマンドなど) をタップした場合に発生します。ユーザーがあるレベルをクリアしてハイ スコアを獲得した場合など、特定のシナリオで自動的に発生することもあります。</span><span class="sxs-lookup"><span data-stu-id="c3182-112">This can occur either when the user taps a control in your app (such as a button or app bar command) or automatically in a specific scenario (if the user finishes a level and gets a high score, for example).</span></span>

[!code-cs[<span data-ttu-id="c3182-113">メイン</span><span class="sxs-lookup"><span data-stu-id="c3182-113">Main</span></span>](./code/share_data/cs/MainPage.xaml.cs#SnippetPrepareToShare)]

<span data-ttu-id="c3182-114">[**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) イベントが発生すると、アプリは [**DataRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest) オブジェクトを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="c3182-114">When a [**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) event occurs, your app receives a [**DataRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest) object.</span></span> <span data-ttu-id="c3182-115">このオブジェクトに含まれている [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) を使って、ユーザーが共有するコンテンツを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="c3182-115">This contains a [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) that you can use to provide the content that the user wants to share.</span></span> <span data-ttu-id="c3182-116">共有するデータとタイトルを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c3182-116">You must provide a title and data to share.</span></span> <span data-ttu-id="c3182-117">説明は省略することもできますが、指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c3182-117">A description is optional, but recommended.</span></span>

[!code-cs[<span data-ttu-id="c3182-118">メイン</span><span class="sxs-lookup"><span data-stu-id="c3182-118">Main</span></span>](./code/share_data/cs/MainPage.xaml.cs#SnippetCreateRequest)]

## <a name="choose-data"></a><span data-ttu-id="c3182-119">データの選択</span><span class="sxs-lookup"><span data-stu-id="c3182-119">Choose data</span></span>

<span data-ttu-id="c3182-120">次のようなさまざまな種類のデータを共有することができます。</span><span class="sxs-lookup"><span data-stu-id="c3182-120">You can share various types of data, including:</span></span>

-   <span data-ttu-id="c3182-121">プレーンテキスト</span><span class="sxs-lookup"><span data-stu-id="c3182-121">Plain text</span></span>
-   <span data-ttu-id="c3182-122">Uniform Resource Identifier (URI)</span><span class="sxs-lookup"><span data-stu-id="c3182-122">Uniform Resource Identifiers (URIs)</span></span>
-   <span data-ttu-id="c3182-123">HTML</span><span class="sxs-lookup"><span data-stu-id="c3182-123">HTML</span></span>
-   <span data-ttu-id="c3182-124">書式付きテキスト</span><span class="sxs-lookup"><span data-stu-id="c3182-124">Formatted text</span></span>
-   <span data-ttu-id="c3182-125">ビットマップ</span><span class="sxs-lookup"><span data-stu-id="c3182-125">Bitmaps</span></span>
-   <span data-ttu-id="c3182-126">プレーンテキスト</span><span class="sxs-lookup"><span data-stu-id="c3182-126">Plain text</span></span>
-   <span data-ttu-id="c3182-127">ファイル</span><span class="sxs-lookup"><span data-stu-id="c3182-127">Files</span></span>
-   <span data-ttu-id="c3182-128">開発者が定義したカスタム データ</span><span class="sxs-lookup"><span data-stu-id="c3182-128">Custom developer-defined data</span></span>

<span data-ttu-id="c3182-129">[**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) オブジェクトには、これらの 1 つ以上の形式を任意に組み合わせて格納することができます。</span><span class="sxs-lookup"><span data-stu-id="c3182-129">The [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) object can contain one or more of these formats, in any combination.</span></span> <span data-ttu-id="c3182-130">次の例は、テキストの共有を示しています。</span><span class="sxs-lookup"><span data-stu-id="c3182-130">The following example demonstrates sharing text.</span></span>

[!code-cs[<span data-ttu-id="c3182-131">メイン</span><span class="sxs-lookup"><span data-stu-id="c3182-131">Main</span></span>](./code/share_data/cs/MainPage.xaml.cs#SnippetSetContent)]

## <a name="set-properties"></a><span data-ttu-id="c3182-132">プロパティの設定</span><span class="sxs-lookup"><span data-stu-id="c3182-132">Set properties</span></span>

<span data-ttu-id="c3182-133">共有用にデータをパッケージ化するときに、共有されるコンテンツの情報を追加で提供するさまざまなプロパティを指定できます。</span><span class="sxs-lookup"><span data-stu-id="c3182-133">When you package data for sharing, you can supply a variety of properties that provide additional information about the content being shared.</span></span> <span data-ttu-id="c3182-134">これらのプロパティは、ターゲット アプリでのユーザー エクスペリエンスを高めるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c3182-134">These properties help target apps improve the user experience.</span></span> <span data-ttu-id="c3182-135">たとえば、ユーザーが複数のアプリでコンテンツを共有している場合に、説明があると便利です。</span><span class="sxs-lookup"><span data-stu-id="c3182-135">For example, a description helps when the user is sharing content with more than one app.</span></span> <span data-ttu-id="c3182-136">画像や Web ページへのリンクを共有する場合にサムネイルを追加すると、ユーザーが視覚的に確認できます。</span><span class="sxs-lookup"><span data-stu-id="c3182-136">Adding a thumbnail when sharing an image or a link to a web page provides a visual reference to the user.</span></span> <span data-ttu-id="c3182-137">詳しくは、「[**DataPackagePropertySet**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackagePropertySet)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c3182-137">For more information, see [**DataPackagePropertySet**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackagePropertySet).</span></span>

<span data-ttu-id="c3182-138">タイトルを除くすべてのプロパティは任意です。</span><span class="sxs-lookup"><span data-stu-id="c3182-138">All properties except the title are optional.</span></span> <span data-ttu-id="c3182-139">タイトルのプロパティは必須です。必ず設定してください。</span><span class="sxs-lookup"><span data-stu-id="c3182-139">The title property is mandatory and must be set.</span></span>

[!code-cs[<span data-ttu-id="c3182-140">メイン</span><span class="sxs-lookup"><span data-stu-id="c3182-140">Main</span></span>](./code/share_data/cs/MainPage.xaml.cs#SnippetSetProperties)]

## <a name="launch-the-share-ui"></a><span data-ttu-id="c3182-141">共有 UI の起動</span><span class="sxs-lookup"><span data-stu-id="c3182-141">Launch the share UI</span></span>

<span data-ttu-id="c3182-142">共有用の UI は、システムによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="c3182-142">A UI for sharing is provided by the system.</span></span> <span data-ttu-id="c3182-143">起動するには、[**ShowShareUI**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3182-143">To launch it, call the [**ShowShareUI**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI) method.</span></span>

[!code-cs[<span data-ttu-id="c3182-144">メイン</span><span class="sxs-lookup"><span data-stu-id="c3182-144">Main</span></span>](./code/share_data/cs/MainPage.xaml.cs#SnippetShowUI)]

## <a name="handle-errors"></a><span data-ttu-id="c3182-145">エラーの処理</span><span class="sxs-lookup"><span data-stu-id="c3182-145">Handle errors</span></span>

<span data-ttu-id="c3182-146">ほとんどの場合、コンテンツの共有は難しいプロセスではありません。</span><span class="sxs-lookup"><span data-stu-id="c3182-146">In most cases, sharing content is a straightforward process.</span></span> <span data-ttu-id="c3182-147">しかし、どのような場合であっても、予期しない問題が発生することは必ずあります。</span><span class="sxs-lookup"><span data-stu-id="c3182-147">However, there's always a chance that something unexpected could happen.</span></span> <span data-ttu-id="c3182-148">たとえば、共有するコンテンツをユーザーが選ぶ必要がある状況で、ユーザーが選んでいない場合などです。</span><span class="sxs-lookup"><span data-stu-id="c3182-148">For example, the app might require the user to select content for sharing but the user didn't select any.</span></span> <span data-ttu-id="c3182-149">このような状況を処理するには、[**FailWithDisplayText**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest.FailWithDisplayText(System.String)) メソッドを使います。このメソッドでは、問題が発生すると、ユーザーにメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c3182-149">To handle these situations, use the [**FailWithDisplayText**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest.FailWithDisplayText(System.String)) method, which will display a message to the user if something goes wrong.</span></span>

## <a name="delay-share-with-delegates"></a><span data-ttu-id="c3182-150">デリゲートによる共有の遅延</span><span class="sxs-lookup"><span data-stu-id="c3182-150">Delay share with delegates</span></span>

<span data-ttu-id="c3182-151">場合によっては、ユーザーが共有するデータをすぐに準備しても効果的でないことがあります。</span><span class="sxs-lookup"><span data-stu-id="c3182-151">Sometimes, it might not make sense to prepare the data that the user wants to share right away.</span></span> <span data-ttu-id="c3182-152">たとえば、複数の異なる形式の大きな画像ファイルの送信をサポートしているアプリの場合、ユーザーが選択する前にこれらの画像をすべて作成することは非効率的です。</span><span class="sxs-lookup"><span data-stu-id="c3182-152">For example, if your app supports sending a large image file in several different possible formats, it's inefficient to create all those images before the user makes their selection.</span></span>

<span data-ttu-id="c3182-153">この問題を解決するために、[**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) にはデリゲートも格納できます。デリゲートとは、受け取る側のアプリでデータを要求するときに呼び出される関数です。</span><span class="sxs-lookup"><span data-stu-id="c3182-153">To solve this problem, a [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) can contain a delegate — a function that is called when the receiving app requests data.</span></span> <span data-ttu-id="c3182-154">リソースを大量に消費するデータを共有する場合はデリゲートを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c3182-154">We recommend using a delegate any time that the data a user wants to share is resource-intensive.</span></span>

<!-- For some reason, this snippet was inline in the WDCML topic. Suggest moving to VS project with rest of snippets. -->
```cs
async void OnDeferredImageRequestedHandler(DataProviderRequest request)
{
    // Provide updated bitmap data using delayed rendering
    if (this.imageStream != null)
    {
        DataProviderDeferral deferral = request.GetDeferral();
        InMemoryRandomAccessStream inMemoryStream = new InMemoryRandomAccessStream();

        // Decode the image.
        BitmapDecoder imageDecoder = await BitmapDecoder.CreateAsync(this.imageStream);

        // Re-encode the image at 50% width and height.
        BitmapEncoder imageEncoder = await BitmapEncoder.CreateForTranscodingAsync(inMemoryStream, imageDecoder);
        imageEncoder.BitmapTransform.ScaledWidth = (uint)(imageDecoder.OrientedPixelHeight * 0.5);
        imageEncoder.BitmapTransform.ScaledHeight = (uint)(imageDecoder.OrientedPixelHeight * 0.5);
        await imageEncoder.FlushAsync();

        request.SetData(RandomAccessStreamReference.CreateFromStream(inMemoryStream));
        deferral.Complete();
    }
}
```

## <a name="see-also"></a><span data-ttu-id="c3182-155">関連項目</span><span class="sxs-lookup"><span data-stu-id="c3182-155">See also</span></span> 

* [<span data-ttu-id="c3182-156">アプリ間通信</span><span class="sxs-lookup"><span data-stu-id="c3182-156">App-to-app communication</span></span>](index.md)
* [<span data-ttu-id="c3182-157">データの受信</span><span class="sxs-lookup"><span data-stu-id="c3182-157">Receive data</span></span>](receive-data.md)
* [<span data-ttu-id="c3182-158">DataPackage</span><span class="sxs-lookup"><span data-stu-id="c3182-158">DataPackage</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.aspx)
* [<span data-ttu-id="c3182-159">DataPackagePropertySet</span><span class="sxs-lookup"><span data-stu-id="c3182-159">DataPackagePropertySet</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackagepropertyset.aspx)
* [<span data-ttu-id="c3182-160">DataRequest</span><span class="sxs-lookup"><span data-stu-id="c3182-160">DataRequest</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.aspx)
* [<span data-ttu-id="c3182-161">DataRequested</span><span class="sxs-lookup"><span data-stu-id="c3182-161">DataRequested</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx)
* [<span data-ttu-id="c3182-162">FailWithDisplayText</span><span class="sxs-lookup"><span data-stu-id="c3182-162">FailWithDisplayText</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.failwithdisplaytext.aspx)
* [<span data-ttu-id="c3182-163">ShowShareUi</span><span class="sxs-lookup"><span data-stu-id="c3182-163">ShowShareUi</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.showshareui.aspx)
 

