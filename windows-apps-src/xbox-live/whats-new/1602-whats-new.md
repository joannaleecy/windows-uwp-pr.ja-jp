---
title: Xbox Live SDK の新規事項 - February 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - February 2016
ms.assetid: 7ff34ea4-f07d-4584-98e4-13977994ccca
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 9180642d324146667425d6031143430dc499b5b9
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4470858"
---
# <a name="whats-new-for-the-xbox-live-sdk---february-2016"></a><span data-ttu-id="64f86-104">Xbox Live SDK の新規事項 - February 2016</span><span class="sxs-lookup"><span data-stu-id="64f86-104">What's new for the Xbox Live SDK - February 2016</span></span>

<span data-ttu-id="64f86-105">1510 で追加された内容については、「[新規事項 - October 2015](1510-whats-new.md)」の記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="64f86-105">Please see the [What's New - October 2015](1510-whats-new.md) article for what was added in 1510</span></span>

## <a name="os-and-tool-support"></a><span data-ttu-id="64f86-106">OS とツールのサポート</span><span class="sxs-lookup"><span data-stu-id="64f86-106">OS and tool support</span></span>
<span data-ttu-id="64f86-107">Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="64f86-107">The Xbox Live SDK supports Windows 10 RTM [Version 10.0.10240] and Visual Studio 2015 RTM [Version 14.0.23107.0].</span></span>

## <a name="throttling"></a><span data-ttu-id="64f86-108">抑制 (スロットリング)</span><span class="sxs-lookup"><span data-stu-id="64f86-108">Throttling</span></span>
- <span data-ttu-id="64f86-109">間もなくほとんどの Xbox Live サービスに、きめ細かなスロットリングが導入される予定です。</span><span class="sxs-lookup"><span data-stu-id="64f86-109">Fine-grained throttling will soon be rolled out to most Xbox Live Services.</span></span>  <span data-ttu-id="64f86-110">Xbox Service API (XSAPI) が再試行を自動的に処理し、開発中にスロットリングされている呼び出しについて通知します。</span><span class="sxs-lookup"><span data-stu-id="64f86-110">Xbox Service API (XSAPI) will automatically handle retries and inform you of calls that are throttled during development.</span></span>  <span data-ttu-id="64f86-111">詳細については、ドキュメントの記事「[ベスト プラクティス: Xbox Live の呼び出し](../using-xbox-live/best-practices/best-practices-for-calling-xbox-live.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="64f86-111">More details can be found in the [Best Practices Calling Xbox Live](../using-xbox-live/best-practices/best-practices-for-calling-xbox-live.md) article in the Documentation.</span></span>

## <a name="leaderboards"></a><span data-ttu-id="64f86-112">スコアボード</span><span class="sxs-lookup"><span data-stu-id="64f86-112">Leaderboards</span></span>
- <span data-ttu-id="64f86-113">GetLeaderboard API によって複数列のランキングにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="64f86-113">Multicolumn leaderboards can now be accessed by the GetLeaderboard API.</span></span> <span data-ttu-id="64f86-114">追加する列の名前のベクトルを指定した場合、それらの列が存在する場合、結果では列のベクトルに内容が格納されます。</span><span class="sxs-lookup"><span data-stu-id="64f86-114">If you provide a vector of the names of the additional columns, the vector of columns on the result will be filled out if those columns exist.</span></span>

## <a name="documentation"></a><span data-ttu-id="64f86-115">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="64f86-115">Documentation</span></span>
- <span data-ttu-id="64f86-116">[Application Insights](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/event-driven-data-platform/application-insights) のドキュメントが提供されています。</span><span class="sxs-lookup"><span data-stu-id="64f86-116">[Application Insights](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/event-driven-data-platform/application-insights) documentation is here.</span></span>  <span data-ttu-id="64f86-117">無料の Azure アカウントで Application Insights を使って、ほぼリアルタイムにデータ プラットフォームのイベントを表示できます。</span><span class="sxs-lookup"><span data-stu-id="64f86-117">You can use Application Insights with a free Azure account to view Data Platform events in near-realtime.</span></span>  <span data-ttu-id="64f86-118">この機能は現在、デスクトップの Windows 10 上で実行されている UWP アプリケーションに対してのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="64f86-118">This functionality is currently only available for UWP applications running on Windows 10 on the desktop.</span></span>
- <span data-ttu-id="64f86-119">データ プラットフォーム イベントを送信するためのラッパーを生成する方法について説明している、UWP デベロッパーに向けた Xbox 共通イベント ツールのドキュメントが更新されました。</span><span class="sxs-lookup"><span data-stu-id="64f86-119">Updated documentation on the Xbox Common Events Tool for UWP developers discussing how to generate wrappers for sending Data Platform events.</span></span>  <span data-ttu-id="64f86-120">これは任意であり、WriteInGameEvent API を引き続き使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="64f86-120">Please note that this is optional and you can continue to use the WriteInGameEvent API if you prefer.</span></span>
- <span data-ttu-id="64f86-121">Fiddler を使ってデータ プラットフォーム イベントをデバッグすることに関する情報が提供されています。このツールを使って、それらのイベントが正常に送信されていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="64f86-121">Using Fiddler to debug Data Platform events and make sure they are properly being sent.</span></span>  <span data-ttu-id="64f86-122">このツールは UWP イベント専用です。</span><span class="sxs-lookup"><span data-stu-id="64f86-122">This is only for UWP events.</span></span>
- <span data-ttu-id="64f86-123">Live トレース分析ツールのためにログを収集する方法に関する情報が提供されています。</span><span class="sxs-lookup"><span data-stu-id="64f86-123">Information on how to collect logs for the Live Trace Analyzer tool is available.</span></span>  <span data-ttu-id="64f86-124">「[Xbox Live サービスへの呼び出しを分析する](../tools/analyze-service-calls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64f86-124">See the [Analyze calls to Xbox Live Services](../tools/analyze-service-calls.md) article.</span></span>
