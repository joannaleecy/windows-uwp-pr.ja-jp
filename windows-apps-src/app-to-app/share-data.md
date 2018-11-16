---
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトをサポートする方法について説明します。
title: データの共有
ms.assetid: 32287F5E-EB86-4B98-97FF-8F6228D06782
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 63e07e56acc8767e4acbad3688c13d75527e9c6f
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6860006"
---
# <a name="share-data"></a><span data-ttu-id="fecf9-104">データの共有</span><span class="sxs-lookup"><span data-stu-id="fecf9-104">Share data</span></span>


<span data-ttu-id="fecf9-105">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトをサポートする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fecf9-105">This article explains how to support the Share contract in a Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="fecf9-106">共有コントラクトは、テキスト、リンク、写真、ビデオなどのデータをアプリ間ですばやく共有するための簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="fecf9-106">The Share contract is an easy way to quickly share data, such as text, links, photos, and videos, between apps.</span></span> <span data-ttu-id="fecf9-107">たとえば、ユーザーがソーシャル ネットワーキング アプリを使って友人と Web ページを共有する場合や、後で参照するためにリンクをメモ帳アプリで保存する場合があります。</span><span class="sxs-lookup"><span data-stu-id="fecf9-107">For example, a user might want to share a webpage with their friends using a social networking app, or save a link in a notes app to refer to later.</span></span>

## <a name="set-up-an-event-handler"></a><span data-ttu-id="fecf9-108">イベント ハンドラーのセットアップ</span><span class="sxs-lookup"><span data-stu-id="fecf9-108">Set up an event handler</span></span>

<span data-ttu-id="fecf9-109">ユーザーが共有を呼び出したときに呼び出される [**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) イベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="fecf9-109">Add a [**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) event handler to be called whenever a user invokes share.</span></span> <span data-ttu-id="fecf9-110">このイベントは、ユーザーがアプリ内のコントロール (ボタンやアプリ バー コマンドなど) をタップした場合に発生します。ユーザーがあるレベルをクリアしてハイ スコアを獲得した場合など、特定のシナリオで自動的に発生することもあります。</span><span class="sxs-lookup"><span data-stu-id="fecf9-110">This can occur either when the user taps a control in your app (such as a button or app bar command) or automatically in a specific scenario (if the user finishes a level and gets a high score, for example).</span></span>

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetPrepareToShare)]

<span data-ttu-id="fecf9-111">[**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) イベントが発生すると、アプリは [**DataRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest) オブジェクトを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="fecf9-111">When a [**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) event occurs, your app receives a [**DataRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest) object.</span></span> <span data-ttu-id="fecf9-112">このオブジェクトに含まれている [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) を使って、ユーザーが共有するコンテンツを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="fecf9-112">This contains a [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) that you can use to provide the content that the user wants to share.</span></span> <span data-ttu-id="fecf9-113">共有するデータとタイトルを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fecf9-113">You must provide a title and data to share.</span></span> <span data-ttu-id="fecf9-114">説明は省略することもできますが、指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fecf9-114">A description is optional, but recommended.</span></span>

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetCreateRequest)]

## <a name="choose-data"></a><span data-ttu-id="fecf9-115">データの選択</span><span class="sxs-lookup"><span data-stu-id="fecf9-115">Choose data</span></span>

<span data-ttu-id="fecf9-116">次のようなさまざまな種類のデータを共有することができます。</span><span class="sxs-lookup"><span data-stu-id="fecf9-116">You can share various types of data, including:</span></span>

-   <span data-ttu-id="fecf9-117">プレーンテキスト</span><span class="sxs-lookup"><span data-stu-id="fecf9-117">Plain text</span></span>
-   <span data-ttu-id="fecf9-118">Uniform Resource Identifier (URI)</span><span class="sxs-lookup"><span data-stu-id="fecf9-118">Uniform Resource Identifiers (URIs)</span></span>
-   <span data-ttu-id="fecf9-119">HTML</span><span class="sxs-lookup"><span data-stu-id="fecf9-119">HTML</span></span>
-   <span data-ttu-id="fecf9-120">書式付きテキスト</span><span class="sxs-lookup"><span data-stu-id="fecf9-120">Formatted text</span></span>
-   <span data-ttu-id="fecf9-121">ビットマップ</span><span class="sxs-lookup"><span data-stu-id="fecf9-121">Bitmaps</span></span>
-   <span data-ttu-id="fecf9-122">ファイル</span><span class="sxs-lookup"><span data-stu-id="fecf9-122">Files</span></span>
-   <span data-ttu-id="fecf9-123">開発者が定義したカスタム データ</span><span class="sxs-lookup"><span data-stu-id="fecf9-123">Custom developer-defined data</span></span>

<span data-ttu-id="fecf9-124">[**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) オブジェクトには、これらの 1 つ以上の形式を任意に組み合わせて格納することができます。</span><span class="sxs-lookup"><span data-stu-id="fecf9-124">The [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) object can contain one or more of these formats, in any combination.</span></span> <span data-ttu-id="fecf9-125">次の例は、テキストの共有を示しています。</span><span class="sxs-lookup"><span data-stu-id="fecf9-125">The following example demonstrates sharing text.</span></span>

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetSetContent)]

## <a name="set-properties"></a><span data-ttu-id="fecf9-126">プロパティの設定</span><span class="sxs-lookup"><span data-stu-id="fecf9-126">Set properties</span></span>

<span data-ttu-id="fecf9-127">共有用にデータをパッケージ化するときに、共有されるコンテンツの情報を追加で提供するさまざまなプロパティを指定できます。</span><span class="sxs-lookup"><span data-stu-id="fecf9-127">When you package data for sharing, you can supply a variety of properties that provide additional information about the content being shared.</span></span> <span data-ttu-id="fecf9-128">これらのプロパティは、ターゲット アプリでのユーザー エクスペリエンスを高めるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="fecf9-128">These properties help target apps improve the user experience.</span></span> <span data-ttu-id="fecf9-129">たとえば、ユーザーが複数のアプリでコンテンツを共有している場合に、説明があると便利です。</span><span class="sxs-lookup"><span data-stu-id="fecf9-129">For example, a description helps when the user is sharing content with more than one app.</span></span> <span data-ttu-id="fecf9-130">画像や Web ページへのリンクを共有する場合にサムネイルを追加すると、ユーザーが視覚的に確認できます。</span><span class="sxs-lookup"><span data-stu-id="fecf9-130">Adding a thumbnail when sharing an image or a link to a web page provides a visual reference to the user.</span></span> <span data-ttu-id="fecf9-131">詳しくは、「[**DataPackagePropertySet**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackagePropertySet)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fecf9-131">For more information, see [**DataPackagePropertySet**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackagePropertySet).</span></span>

<span data-ttu-id="fecf9-132">タイトルを除くすべてのプロパティは任意です。</span><span class="sxs-lookup"><span data-stu-id="fecf9-132">All properties except the title are optional.</span></span> <span data-ttu-id="fecf9-133">タイトルのプロパティは必須です。必ず設定してください。</span><span class="sxs-lookup"><span data-stu-id="fecf9-133">The title property is mandatory and must be set.</span></span>

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetSetProperties)]

## <a name="launch-the-share-ui"></a><span data-ttu-id="fecf9-134">共有 UI の起動</span><span class="sxs-lookup"><span data-stu-id="fecf9-134">Launch the share UI</span></span>

<span data-ttu-id="fecf9-135">共有用の UI は、システムによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="fecf9-135">A UI for sharing is provided by the system.</span></span> <span data-ttu-id="fecf9-136">起動するには、[**ShowShareUI**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="fecf9-136">To launch it, call the [**ShowShareUI**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI) method.</span></span>

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetShowUI)]

## <a name="handle-errors"></a><span data-ttu-id="fecf9-137">エラーの処理</span><span class="sxs-lookup"><span data-stu-id="fecf9-137">Handle errors</span></span>

<span data-ttu-id="fecf9-138">ほとんどの場合、コンテンツの共有は難しいプロセスではありません。</span><span class="sxs-lookup"><span data-stu-id="fecf9-138">In most cases, sharing content is a straightforward process.</span></span> <span data-ttu-id="fecf9-139">しかし、どのような場合であっても、予期しない問題が発生することは必ずあります。</span><span class="sxs-lookup"><span data-stu-id="fecf9-139">However, there's always a chance that something unexpected could happen.</span></span> <span data-ttu-id="fecf9-140">たとえば、共有するコンテンツをユーザーが選ぶ必要がある状況で、ユーザーが選んでいない場合などです。</span><span class="sxs-lookup"><span data-stu-id="fecf9-140">For example, the app might require the user to select content for sharing but the user didn't select any.</span></span> <span data-ttu-id="fecf9-141">このような状況を処理するには、[**FailWithDisplayText**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest.FailWithDisplayText(System.String)) メソッドを使います。このメソッドでは、問題が発生すると、ユーザーにメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="fecf9-141">To handle these situations, use the [**FailWithDisplayText**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest.FailWithDisplayText(System.String)) method, which will display a message to the user if something goes wrong.</span></span>

## <a name="delay-share-with-delegates"></a><span data-ttu-id="fecf9-142">デリゲートによる共有の遅延</span><span class="sxs-lookup"><span data-stu-id="fecf9-142">Delay share with delegates</span></span>

<span data-ttu-id="fecf9-143">場合によっては、ユーザーが共有するデータをすぐに準備しても効果的でないことがあります。</span><span class="sxs-lookup"><span data-stu-id="fecf9-143">Sometimes, it might not make sense to prepare the data that the user wants to share right away.</span></span> <span data-ttu-id="fecf9-144">たとえば、複数の異なる形式の大きな画像ファイルの送信をサポートしているアプリの場合、ユーザーが選択する前にこれらの画像をすべて作成することは非効率的です。</span><span class="sxs-lookup"><span data-stu-id="fecf9-144">For example, if your app supports sending a large image file in several different possible formats, it's inefficient to create all those images before the user makes their selection.</span></span>

<span data-ttu-id="fecf9-145">この問題を解決するために、[**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) にはデリゲートも格納できます。デリゲートとは、受け取る側のアプリでデータを要求するときに呼び出される関数です。</span><span class="sxs-lookup"><span data-stu-id="fecf9-145">To solve this problem, a [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) can contain a delegate — a function that is called when the receiving app requests data.</span></span> <span data-ttu-id="fecf9-146">リソースを大量に消費するデータを共有する場合はデリゲートを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fecf9-146">We recommend using a delegate any time that the data a user wants to share is resource-intensive.</span></span>

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

## <a name="see-also"></a><span data-ttu-id="fecf9-147">関連項目</span><span class="sxs-lookup"><span data-stu-id="fecf9-147">See also</span></span> 

* [<span data-ttu-id="fecf9-148">アプリ間通信</span><span class="sxs-lookup"><span data-stu-id="fecf9-148">App-to-app communication</span></span>](index.md)
* [<span data-ttu-id="fecf9-149">データの受信</span><span class="sxs-lookup"><span data-stu-id="fecf9-149">Receive data</span></span>](receive-data.md)
* [<span data-ttu-id="fecf9-150">DataPackage</span><span class="sxs-lookup"><span data-stu-id="fecf9-150">DataPackage</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.aspx)
* [<span data-ttu-id="fecf9-151">DataPackagePropertySet</span><span class="sxs-lookup"><span data-stu-id="fecf9-151">DataPackagePropertySet</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackagepropertyset.aspx)
* [<span data-ttu-id="fecf9-152">DataRequest</span><span class="sxs-lookup"><span data-stu-id="fecf9-152">DataRequest</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.aspx)
* [<span data-ttu-id="fecf9-153">DataRequested</span><span class="sxs-lookup"><span data-stu-id="fecf9-153">DataRequested</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx)
* [<span data-ttu-id="fecf9-154">FailWithDisplayText</span><span class="sxs-lookup"><span data-stu-id="fecf9-154">FailWithDisplayText</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.failwithdisplaytext.aspx)
* [<span data-ttu-id="fecf9-155">ShowShareUi</span><span class="sxs-lookup"><span data-stu-id="fecf9-155">ShowShareUi</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.showshareui.aspx)
 

