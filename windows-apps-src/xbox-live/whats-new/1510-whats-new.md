---
title: Xbox Live SDK の新規事項 - October 2015
author: KevinAsgari
description: Xbox Live SDK の新規事項 - October 2015
ms.assetid: 052be4aa-5f18-4eb7-ba5f-80c5f5cab6f2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 09f8fe60cf30ee14b9b0e0c8f1c1c98feef1fa59
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6279400"
---
# <a name="whats-new-for-the-xbox-live-sdk---october-2015"></a><span data-ttu-id="6c9b1-104">Xbox Live SDK の新規事項 - October 2015</span><span class="sxs-lookup"><span data-stu-id="6c9b1-104">What's new for the Xbox Live SDK - October 2015</span></span>

<span data-ttu-id="6c9b1-105">September 2015 リリースで追加された内容については、「[新規事項 - September 2015](1509-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-105">Please see the [What's New - September 2015](1509-whats-new.md) article for what was added in the September 2015 release.</span></span>


## <a name="os-and-tool-support"></a><span data-ttu-id="6c9b1-106">OS とツールのサポート</span><span class="sxs-lookup"><span data-stu-id="6c9b1-106">OS and tool support</span></span>
<span data-ttu-id="6c9b1-107">Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-107">The Xbox Live SDK supports Windows 10 RTM [Version 10.0.10240] and Visual Studio 2015 RTM [Version 14.0.23107.0].</span></span>

## <a name="social-manager"></a><span data-ttu-id="6c9b1-108">Social Manager</span><span class="sxs-lookup"><span data-stu-id="6c9b1-108">Social Manager</span></span>
* <span data-ttu-id="6c9b1-109">Social Manager は、Xbox Live Social API を簡単に使用できるようにするためのものです。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-109">The Social Manager is intended to ease the use of the Xbox Live social APIs.</span></span>  <span data-ttu-id="6c9b1-110">ユーザーのソーシャル グラフをインテリジェントにキャッシュし、より単純な API などを提供します。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-110">It will intelligently cache a user's social graph, provide a simpler API and more.</span></span>  <span data-ttu-id="6c9b1-111">詳細についてはドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-111">Please see the documentation for more information.</span></span>

## <a name="samples"></a><span data-ttu-id="6c9b1-112">サンプル</span><span class="sxs-lookup"><span data-stu-id="6c9b1-112">Samples</span></span>
* <span data-ttu-id="6c9b1-113">API の使い方がわかる新しい Social Manager サンプルがあります。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-113">We have a new Social Manager sample demonstrating the API.</span></span>

## <a name="tools"></a><span data-ttu-id="6c9b1-114">ツール</span><span class="sxs-lookup"><span data-stu-id="6c9b1-114">Tools</span></span>
* <span data-ttu-id="6c9b1-115">Xbox Live Trace Analyzer が Xbox Live SDK に含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-115">The Xbox Live Trace Analyzer is now included in the Xbox Live SDK.</span></span>  <span data-ttu-id="6c9b1-116">「[Xbox Live サービスへの呼び出しを分析する](../tools/analyze-service-calls.md)」の説明に従ってトレースを収集した後、Live Trace Analyzer を実行して、繰り返されている呼び出しや呼び出しの頻度などについての統計情報を見ることにより、タイトルでの Xbox Live の使用方法が最適であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-116">Collect traces as described in the [Analyze calls to Xbox Live Services](../tools/analyze-service-calls.md), and then run the Live Trace Analyzer to ensure your title is using Xbox Live in an optimal way by viewing statistics about repeated calls, call frequency, and more.</span></span>

## <a name="bug-fixes"></a><span data-ttu-id="6c9b1-117">バグ修正</span><span class="sxs-lookup"><span data-stu-id="6c9b1-117">Bug Fixes</span></span>
* <span data-ttu-id="6c9b1-118">HTTP ソケット操作の既定のタイムアウトが、5 分から 30 秒に変更されました。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-118">Changed default timeout for HTTP socket operations to 30 seconds from 5 minutes.</span></span>  <span data-ttu-id="6c9b1-119">タイトル ストレージのアップロードやダウンロードの呼び出しのような時間のかかる HTTP ソケット操作については、タイムアウトは 5 分のままになっています。</span><span class="sxs-lookup"><span data-stu-id="6c9b1-119">For long running HTTP socket operations such as Title Storage upload and download calls, those remain using a 5 minute timeout.</span></span>

## <a name="documentation"></a><span data-ttu-id="6c9b1-120">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="6c9b1-120">Documentation</span></span>
* <span data-ttu-id="6c9b1-121">Social Manager の概要が追加されました</span><span class="sxs-lookup"><span data-stu-id="6c9b1-121">Introduction to the Social Manager added</span></span>
* <span data-ttu-id="6c9b1-122">Multiplayer Manager の概要が更新されました</span><span class="sxs-lookup"><span data-stu-id="6c9b1-122">Introduction to the Multiplayer Manager updated</span></span>
