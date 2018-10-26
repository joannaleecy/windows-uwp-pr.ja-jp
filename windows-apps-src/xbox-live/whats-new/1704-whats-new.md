---
title: Xbox Live API の新規事項 - April 2017
author: KevinAsgari
description: Xbox Live API の新規事項 - April 2017
ms.assetid: ''
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live、Xbox、ゲーム、UWP、Windows 10、Xbox One、アリーナ、トーナメント
ms.localizationpriority: medium
ms.openlocfilehash: e223c0c9bfca3b516d7eb623aba968cc8b547747
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5552368"
---
# <a name="whats-new-for-the-xbox-live-apis---april-2017"></a><span data-ttu-id="918ef-104">Xbox Live API の新規事項 - April 2017</span><span class="sxs-lookup"><span data-stu-id="918ef-104">What's new for the Xbox Live APIs - April 2017</span></span>

<span data-ttu-id="918ef-105">March 2017 リリースで追加された内容については、「[新規事項 - March 2017](1703-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="918ef-105">Please see the [What's New - March 2017](1703-whats-new.md) article for what was added in the March 2017 release.</span></span>

## <a name="xbox-services-apis"></a><span data-ttu-id="918ef-106">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="918ef-106">Xbox Services APIs</span></span>

### <a name="visual-studio-2017"></a><span data-ttu-id="918ef-107">Visual Studio 2017</span><span class="sxs-lookup"><span data-stu-id="918ef-107">Visual Studio 2017</span></span>

<span data-ttu-id="918ef-108">Xbox Live API は、ユニバーサル Windows プラットフォーム (UWP) および Xbox One タイトルのために Visual Studio 2017 をサポートするように更新されました。</span><span class="sxs-lookup"><span data-stu-id="918ef-108">The Xbox Live APIs have been updated to support Visual Studio 2017, for both Universal Windows Platform (UWP) and Xbox One titles.</span></span>

### <a name="tournaments"></a><span data-ttu-id="918ef-109">トーナメント</span><span class="sxs-lookup"><span data-stu-id="918ef-109">Tournaments</span></span>

<span data-ttu-id="918ef-110">トーナメントをサポートするための新しい API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="918ef-110">New APIs have been added to support tournaments.</span></span> <span data-ttu-id="918ef-111">`xbox::services::tournaments::tournament_service` クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="918ef-111">You can now use the `xbox::services::tournaments::tournament_service` class to access the tournaments service from your title.</span></span>

<span data-ttu-id="918ef-112">これらの新しいトーナメント API では、以下のシナリオが可能になります。</span><span class="sxs-lookup"><span data-stu-id="918ef-112">These new tournament APIs enable the following scenarios:</span></span>

* <span data-ttu-id="918ef-113">サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。</span><span class="sxs-lookup"><span data-stu-id="918ef-113">Query the service to find all existing tournaments for the current title.</span></span>
* <span data-ttu-id="918ef-114">サービスからトーナメントに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="918ef-114">Retrieve details about a tournament from the service.</span></span>
* <span data-ttu-id="918ef-115">サービスをクエリしてトーナメントのチームの一覧を取得する。</span><span class="sxs-lookup"><span data-stu-id="918ef-115">Query the service to retrieve a list of teams for a tournament.</span></span>
* <span data-ttu-id="918ef-116">サービスからトーナメントのチームに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="918ef-116">Retrieve details about the teams for a tournament from the service.</span></span>
* <span data-ttu-id="918ef-117">リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。</span><span class="sxs-lookup"><span data-stu-id="918ef-117">Track changes to tournaments and teams by using Real Time Activity (RTA) subscriptions.</span></span>
