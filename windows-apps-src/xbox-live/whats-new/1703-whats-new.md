---
title: Xbox Live SDK の新規事項 - March 2017
author: KevinAsgari
description: Xbox Live SDK の新規事項 - March 2017
ms.assetid: 03180585-6f87-4929-acfc-750bd78988a0
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: cd57ea928db2a04dd4117af439c42666a5d3734e
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4317385"
---
# <a name="whats-new-for-the-xbox-live-sdk---march-2017"></a><span data-ttu-id="28904-104">Xbox Live SDK の新規事項 - March 2017</span><span class="sxs-lookup"><span data-stu-id="28904-104">What's new for the Xbox Live SDK - March 2017</span></span>

<span data-ttu-id="28904-105">December 2016 リリースで追加された内容については、「[新規事項 - December 2016](1612-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="28904-105">Please see the [What's New - December 2016](1612-whats-new.md) article for what was added in the December 2016 release.</span></span>

## <a name="xbox-services-api"></a><span data-ttu-id="28904-106">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="28904-106">Xbox Services API</span></span>

### <a name="data-platform-2017"></a><span data-ttu-id="28904-107">データ プラットフォーム 2017</span><span class="sxs-lookup"><span data-stu-id="28904-107">Data Platform 2017</span></span>

<span data-ttu-id="28904-108">簡略化された統計 API が導入されました。</span><span class="sxs-lookup"><span data-stu-id="28904-108">We have introduced a simplified Stats API.</span></span>  <span data-ttu-id="28904-109">これまでは XDP またはデベロッパー センターで定義された統計の規則に対応したイベントを送信する必要があり、これらによってクラウドの統計値を更新していました。</span><span class="sxs-lookup"><span data-stu-id="28904-109">Traditionally you had to send events corresponding to stat rules defined on XDP or Dev Center and these would update the stat values in the cloud.</span></span>  <span data-ttu-id="28904-110">このモデルを統計 2013 といいます。</span><span class="sxs-lookup"><span data-stu-id="28904-110">We refer to this model as Stats 2013.</span></span>

<span data-ttu-id="28904-111">統計 2017 では、タイトルが統計値を制御します。</span><span class="sxs-lookup"><span data-stu-id="28904-111">With Stats 2017, your title is now in control of your stat values.</span></span>  <span data-ttu-id="28904-112">最新の統計値のある API を呼び出すだけで、統計値がイベントを必要とせずに直接サービスに送信されます。</span><span class="sxs-lookup"><span data-stu-id="28904-112">You simply call an API with the most recent stat value, and that gets sent to the service directly without the need for events.</span></span>  <span data-ttu-id="28904-113">これは、新しい `StatsManager` API を使用するもので、詳細は「[プレイヤー統計](../leaderboards-and-stats-2017/player-stats.md)」に記載されています。</span><span class="sxs-lookup"><span data-stu-id="28904-113">This uses the new `StatsManager` API and you can read more in [Player Stats](../leaderboards-and-stats-2017/player-stats.md)</span></span>

### <a name="github"></a><span data-ttu-id="28904-114">GitHub</span><span class="sxs-lookup"><span data-stu-id="28904-114">GitHub</span></span>

<span data-ttu-id="28904-115">Xbox Live API (XSAPI) は、GitHub ([https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api)) に公開されています。</span><span class="sxs-lookup"><span data-stu-id="28904-115">Xbox Live API (XSAPI) is now available on GitHub at [https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api).</span></span>  <span data-ttu-id="28904-116">XDK に付属のバイナリまたは NuGet パッケージとしての使用も推奨していますが、ソースを使用したり、ソース コードに貢献していただくことも歓迎します。</span><span class="sxs-lookup"><span data-stu-id="28904-116">Using the binaries that come with the XDK or as NuGet packages is still recommended, however you are welcome to use the source and we welcome source code contributions.</span></span>  

## <a name="xbox-live-creators-program"></a><span data-ttu-id="28904-117">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="28904-117">Xbox Live Creators Program</span></span>

<span data-ttu-id="28904-118">Xbox Live クリエーターズ プログラムは、幅広い対象デベロッパーに Xbox Live 機能のサブセットを提供するデベロッパー プログラムです。</span><span class="sxs-lookup"><span data-stu-id="28904-118">The Xbox Live Creators Program is a developer program offering a subset of Xbox Live functionality to a broader developer audience.</span></span>  <span data-ttu-id="28904-119">既に ID@Xbox プログラムを使用している場合には、これによる影響はありません。</span><span class="sxs-lookup"><span data-stu-id="28904-119">If you are already in the ID@Xbox program, this will not have any impact on you.</span></span>

<span data-ttu-id="28904-120">プログラムの詳細については、「[開発者プログラムの概要](../developer-program-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="28904-120">You can read more about the program in [Developer Program Overview](../developer-program-overview.md).</span></span>

## <a name="documentation"></a><span data-ttu-id="28904-121">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="28904-121">Documentation</span></span>

<span data-ttu-id="28904-122">以下の新しい記事があります</span><span class="sxs-lookup"><span data-stu-id="28904-122">There are the following new articles</span></span>

| <span data-ttu-id="28904-123">記事</span><span class="sxs-lookup"><span data-stu-id="28904-123">Article</span></span> | <span data-ttu-id="28904-124">説明</span><span class="sxs-lookup"><span data-stu-id="28904-124">Description</span></span> |
|---------|-------------|
|[<span data-ttu-id="28904-125">Xbox Live サービス構成</span><span class="sxs-lookup"><span data-stu-id="28904-125">Xbox Live Service Configuration</span></span>](../xbox-live-service-configuration.md) | <span data-ttu-id="28904-126">Xbox Live タイトル用のサービス構成の実行に関する最新情報</span><span class="sxs-lookup"><span data-stu-id="28904-126">Updated information on doing service configuration for your Xbox Live Title</span></span>
| [<span data-ttu-id="28904-127">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="28904-127">Configure Xbox Live in Unity</span></span>](../get-started-with-creators/configure-xbox-live-in-unity.md) | <span data-ttu-id="28904-128">Xbox Live クリエーターズ プログラムのデベロッパー向けの Unity セットアップに関する新しい情報</span><span class="sxs-lookup"><span data-stu-id="28904-128">New information on Unity setup for Xbox Live Creators Program developers</span></span> |
| [<span data-ttu-id="28904-129">Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="28904-129">Xbox Live Sandboxes</span></span>](../xbox-live-sandboxes.md) | <span data-ttu-id="28904-130">Xbox Live サンド ボックスとコンテンツの分離の簡易ガイド</span><span class="sxs-lookup"><span data-stu-id="28904-130">A simplified guide to Xbox Live sandboxes and content isolation</span></span> |
| [<span data-ttu-id="28904-131">Xbox Live テスト アカウント</span><span class="sxs-lookup"><span data-stu-id="28904-131">Xbox Live Test Accounts</span></span>](../xbox-live-test-accounts.md) | <span data-ttu-id="28904-132">テスト アカウントの機能と Windows デベロッパー センターでのそれらの作成方法に関する情報</span><span class="sxs-lookup"><span data-stu-id="28904-132">Information about how test accounts work, and how to create them on Windows Dev Center</span></span> |
