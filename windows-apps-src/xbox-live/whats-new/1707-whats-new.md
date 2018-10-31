---
title: Xbox Live API の新規事項 - July 2017
author: KevinAsgari
description: Xbox Live API の新規事項 - July 2017
ms.assetid: ''
ms.author: kevinasg
ms.date: 07/16/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 新規事項, july 2017
ms.localizationpriority: medium
ms.openlocfilehash: def86d10ce050ed795710f68c4b6ff175dd34799
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5836583"
---
# <a name="whats-new-for-the-xbox-live-apis---july-2017"></a><span data-ttu-id="31379-104">Xbox Live API の新規事項 - July 2017</span><span class="sxs-lookup"><span data-stu-id="31379-104">What's new for the Xbox Live APIs - July 2017</span></span>

<span data-ttu-id="31379-105">June 2017 リリースで追加された内容については、「[新規事項 - June 2017](1706-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="31379-105">Please see the [What's New - June 2017](1706-whats-new.md) article for what was added in the June 2017 release.</span></span>

<span data-ttu-id="31379-106">[Xbox Live API GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="31379-106">You can also check the [Xbox Live API GitHub commit history](https://github.com/Microsoft/xbox-live-api/commits/master) to see all of the recent code changes to the Xbox Live APIs.</span></span>

## <a name="xbox-live-features"></a><span data-ttu-id="31379-107">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="31379-107">Xbox Live features</span></span>

### <a name="multiplayer-updates"></a><span data-ttu-id="31379-108">マルチプレイヤーの更新</span><span class="sxs-lookup"><span data-stu-id="31379-108">Multiplayer updates</span></span>

<span data-ttu-id="31379-109">アクティビティ ハンドルと検索ハンドルの照会の応答にカスタム セッション プロパティが含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="31379-109">Querying activity handles and search handles now includes the custom session properties in the response.</span></span>

### <a name="tournaments"></a><span data-ttu-id="31379-110">トーナメント</span><span class="sxs-lookup"><span data-stu-id="31379-110">Tournaments</span></span>

<span data-ttu-id="31379-111">トーナメントをサポートするための新しい API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="31379-111">New APIs have been added to support tournaments.</span></span> <span data-ttu-id="31379-112">xbox::services::tournaments::tournament_service クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="31379-112">You can now use the xbox::services::tournaments::tournament_service class to access the tournaments service from your title.</span></span>
<span data-ttu-id="31379-113">これらの新しいトーナメント API では、以下のシナリオが可能になります。</span><span class="sxs-lookup"><span data-stu-id="31379-113">These new tournament APIs enable the following scenarios:</span></span>
* <span data-ttu-id="31379-114">サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。</span><span class="sxs-lookup"><span data-stu-id="31379-114">Query the service to find all existing tournaments for the current title.</span></span>
* <span data-ttu-id="31379-115">サービスからトーナメントに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="31379-115">Retrieve details about a tournament from the service.</span></span>
* <span data-ttu-id="31379-116">サービスをクエリしてトーナメントのチームの一覧を取得する。</span><span class="sxs-lookup"><span data-stu-id="31379-116">Query the service to retrieve a list of teams for a tournament.</span></span>
* <span data-ttu-id="31379-117">サービスからトーナメントのチームに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="31379-117">Retrieve details about the teams for a tournament from the service.</span></span>
* <span data-ttu-id="31379-118">リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。</span><span class="sxs-lookup"><span data-stu-id="31379-118">Track changes to tournaments and teams by using Real Time Activity (RTA) subscriptions.</span></span>
