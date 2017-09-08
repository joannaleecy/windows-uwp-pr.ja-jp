---
title: "Xbox Live SDK の新規事項 - March 2017"
author: KevinAsgari
description: "Xbox Live SDK の新規事項 - March 2017"
ms.assetid: 03180585-6f87-4929-acfc-750bd78988a0
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one"
ms.openlocfilehash: 97505d0972622b68cbe5e5181acd9afa23f27ead
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="whats-new-for-the-xbox-live-sdk---march-2017"></a><span data-ttu-id="b5a35-104">Xbox Live SDK の新規事項 - March 2017</span><span class="sxs-lookup"><span data-stu-id="b5a35-104">What's new for the Xbox Live SDK - March 2017</span></span>

<span data-ttu-id="b5a35-105">December 2016 リリースで追加された内容については、「[新規事項 - December 2016](1612-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b5a35-105">Please see the [What's New - December 2016](1612-whats-new.md) article for what was added in the December 2016 release.</span></span>

## <a name="xbox-services-api"></a><span data-ttu-id="b5a35-106">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="b5a35-106">Xbox Services API</span></span>

### <a name="data-platform-2017"></a><span data-ttu-id="b5a35-107">データ プラットフォーム 2017</span><span class="sxs-lookup"><span data-stu-id="b5a35-107">Data Platform 2017</span></span>

<span data-ttu-id="b5a35-108">簡略化された統計 API が導入されました。</span><span class="sxs-lookup"><span data-stu-id="b5a35-108">We have introduced a simplified Stats API.</span></span>  <span data-ttu-id="b5a35-109">これまでは XDP またはデベロッパー センターで定義された統計の規則に対応したイベントを送信する必要があり、これらによってクラウドの統計値を更新していました。</span><span class="sxs-lookup"><span data-stu-id="b5a35-109">Traditionally you had to send events corresponding to stat rules defined on XDP or Dev Center and these would update the stat values in the cloud.</span></span>  <span data-ttu-id="b5a35-110">このモデルを統計 2013 といいます。</span><span class="sxs-lookup"><span data-stu-id="b5a35-110">We refer to this model as Stats 2013.</span></span>

<span data-ttu-id="b5a35-111">統計 2017 では、タイトルが統計値を制御します。</span><span class="sxs-lookup"><span data-stu-id="b5a35-111">With Stats 2017, your title is now in control of your stat values.</span></span>  <span data-ttu-id="b5a35-112">最新の統計値のある API を呼び出すだけで、統計値がイベントを必要とせずに直接サービスに送信されます。</span><span class="sxs-lookup"><span data-stu-id="b5a35-112">You simply call an API with the most recent stat value, and that gets sent to the service directly without the need for events.</span></span>  <span data-ttu-id="b5a35-113">これは、新しい `StatsManager` API を使用するもので、詳細は「[プレイヤー統計](../leaderboards-and-stats-2017/player-stats.md)」に記載されています。</span><span class="sxs-lookup"><span data-stu-id="b5a35-113">This uses the new `StatsManager` API and you can read more in [Player Stats](../leaderboards-and-stats-2017/player-stats.md)</span></span>

### <a name="github"></a><span data-ttu-id="b5a35-114">GitHub</span><span class="sxs-lookup"><span data-stu-id="b5a35-114">GitHub</span></span>

<span data-ttu-id="b5a35-115">Xbox Live API (XSAPI) が [https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api) の GitHub で利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="b5a35-115">Xbox Live API (XSAPI) is now available on GitHub at [https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api).</span></span>  <span data-ttu-id="b5a35-116">XDK に付属のバイナリまたは NuGet パッケージとしての使用も推奨していますが、ソースを使用したり、ソース コードに貢献していただくことも歓迎します。</span><span class="sxs-lookup"><span data-stu-id="b5a35-116">Using the binaries that come with the XDK or as NuGet packages is still recommended, however you are welcome to use the source and we welcome source code contributions.</span></span>  

## <a name="xbox-live-creators-program"></a><span data-ttu-id="b5a35-117">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="b5a35-117">Xbox Live Creators Program</span></span>

<span data-ttu-id="b5a35-118">Xbox Live クリエーターズ プログラムは、幅広い対象デベロッパーに Xbox Live 機能のサブセットを提供するデベロッパー プログラムです。</span><span class="sxs-lookup"><span data-stu-id="b5a35-118">The Xbox Live Creators Program is a developer program offering a subset of Xbox Live functionality to a broader developer audience.</span></span>  <span data-ttu-id="b5a35-119">既に ID@Xbox プログラムを使用している場合には、これによる影響はありません。</span><span class="sxs-lookup"><span data-stu-id="b5a35-119">If you are already in the ID@Xbox program, this will not have any impact on you.</span></span>

<span data-ttu-id="b5a35-120">プログラムの詳細については、「[開発者プログラムの概要](../developer-program-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b5a35-120">You can read more about the program in [Developer Program Overview](../developer-program-overview.md).</span></span>

## <a name="documentation"></a><span data-ttu-id="b5a35-121">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="b5a35-121">Documentation</span></span>

<span data-ttu-id="b5a35-122">以下の新しい記事があります</span><span class="sxs-lookup"><span data-stu-id="b5a35-122">There are the following new articles</span></span>

| <span data-ttu-id="b5a35-123">記事</span><span class="sxs-lookup"><span data-stu-id="b5a35-123">Article</span></span> | <span data-ttu-id="b5a35-124">説明</span><span class="sxs-lookup"><span data-stu-id="b5a35-124">Description</span></span> |
|---------|-------------|
|[<span data-ttu-id="b5a35-125">Xbox Live サービス構成</span><span class="sxs-lookup"><span data-stu-id="b5a35-125">Xbox Live Service Configuration</span></span>](../xbox-live-service-configuration.md) | <span data-ttu-id="b5a35-126">Xbox Live タイトル用のサービス構成の実行に関する最新情報</span><span class="sxs-lookup"><span data-stu-id="b5a35-126">Updated information on doing service configuration for your Xbox Live Title</span></span>
| [<span data-ttu-id="b5a35-127">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="b5a35-127">Configure Xbox Live in Unity</span></span>](../get-started-with-creators/configure-xbox-live-in-unity.md) | <span data-ttu-id="b5a35-128">Xbox Live クリエーターズ プログラムのデベロッパー向けの Unity セットアップに関する新しい情報</span><span class="sxs-lookup"><span data-stu-id="b5a35-128">New information on Unity setup for Xbox Live Creators Program developers</span></span> |
| [<span data-ttu-id="b5a35-129">Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="b5a35-129">Xbox Live Sandboxes</span></span>](../xbox-live-sandboxes.md) | <span data-ttu-id="b5a35-130">Xbox Live サンド ボックスとコンテンツの分離の簡易ガイド</span><span class="sxs-lookup"><span data-stu-id="b5a35-130">A simplified guide to Xbox Live sandboxes and content isolation</span></span> |
| [<span data-ttu-id="b5a35-131">Xbox Live テスト アカウント</span><span class="sxs-lookup"><span data-stu-id="b5a35-131">Xbox Live Test Accounts</span></span>](../xbox-live-test-accounts.md) | <span data-ttu-id="b5a35-132">テスト アカウントの機能と Windows デベロッパー センターでのそれらの作成方法に関する情報</span><span class="sxs-lookup"><span data-stu-id="b5a35-132">Information about how test accounts work, and how to create them on Windows Dev Center</span></span> |
