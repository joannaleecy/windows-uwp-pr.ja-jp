---
title: Xbox Live SDK の新規事項 - September 2015
author: KevinAsgari
description: Xbox Live SDK の新規事項 - September 2015
ms.assetid: 84b82fde-f6f3-4dc2-b2df-c7c7313a2cc3
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 7e348254e7e1d7ab233ee1a82e7223a57ebd2781
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4353567"
---
# <a name="whats-new-for-the-xbox-live-sdk---september-2015"></a><span data-ttu-id="509a6-104">Xbox Live SDK の新規事項 - September 2015</span><span class="sxs-lookup"><span data-stu-id="509a6-104">What's new for the Xbox Live SDK - September 2015</span></span>

<span data-ttu-id="509a6-105">August 2015 リリースで追加された内容については、「[新規事項 - August 2015](1508-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="509a6-105">Please see the [What's New - August 2015](1508-whats-new.md) article for what was added in the August 2015 release.</span></span>

<span data-ttu-id="509a6-106">Xbox Live SDK の September リリースには以下の更新が含まれています。</span><span class="sxs-lookup"><span data-stu-id="509a6-106">The September release of the Xbox Live SDK includes the following updates:</span></span>

## <a name="os-and-tool-support"></a><span data-ttu-id="509a6-107">OS とツールのサポート</span><span class="sxs-lookup"><span data-stu-id="509a6-107">OS and tool support</span></span> ##
<span data-ttu-id="509a6-108">Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="509a6-108">The Xbox Live SDK supports Windows 10 RTM [Version 10.0.10240] and Visual Studio 2015 RTM [Version 14.0.23107.0].</span></span>

## <a name="contextual-search-apis"></a><span data-ttu-id="509a6-109">コンテキスト検索 API</span><span class="sxs-lookup"><span data-stu-id="509a6-109">Contextual Search APIs</span></span>
* <span data-ttu-id="509a6-110">タイトルやアプリケーションが、選択したリアルタイム統計情報を使ってゲームのブロードキャストを検索できるようにします。</span><span class="sxs-lookup"><span data-stu-id="509a6-110">Enable your title or application to search for broadcasts from your game(s) with real time stats of your choosing.</span></span>
* <span data-ttu-id="509a6-111">Microsoft::Xbox::Services::ContextualSearch の新しい API をご覧ください</span><span class="sxs-lookup"><span data-stu-id="509a6-111">Please see the new APIs in Microsoft::Xbox::Services::ContextualSearch</span></span>

## <a name="app-insights-for-events"></a><span data-ttu-id="509a6-112">イベントの App Insights</span><span class="sxs-lookup"><span data-stu-id="509a6-112">App Insights for Events</span></span>

| <span data-ttu-id="509a6-113">注</span><span class="sxs-lookup"><span data-stu-id="509a6-113">Note</span></span> |
|------|
| <span data-ttu-id="509a6-114">App Insights は、UWP タイトルにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="509a6-114">App Insights only applies to UWP titles.</span></span>  <span data-ttu-id="509a6-115">XDK タイトルを開発している場合、このセクションは適用されません</span><span class="sxs-lookup"><span data-stu-id="509a6-115">If you are developing a XDK title, this section does not apply to you</span></span> |

<p/>

* <span data-ttu-id="509a6-116">write_in_game_event() を使って書き込まれたイベントは、AppInsights を使って表示できます</span><span class="sxs-lookup"><span data-stu-id="509a6-116">Events written using write_in_game_event() can be viewed using AppInsights</span></span>
* <span data-ttu-id="509a6-117">これに関するドキュメントは今後公開される予定です。それまでの間、DAM を使ってアクセスしてください</span><span class="sxs-lookup"><span data-stu-id="509a6-117">Documentation will be coming on this in the future, in the meantime please work with your DAM to get access</span></span>

## <a name="logging"></a><span data-ttu-id="509a6-118">ログ記録</span><span class="sxs-lookup"><span data-stu-id="509a6-118">Logging</span></span>
* <span data-ttu-id="509a6-119">service_call_logging_config in xbox::services::experimental</span><span class="sxs-lookup"><span data-stu-id="509a6-119">service_call_logging_config in xbox::services::experimental</span></span>
* <span data-ttu-id="509a6-120">コンソールで via xbTrace.exe を通じたトレースを開始および停止するには、service_call_logging_config クラスで register_for_protocol_activation を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="509a6-120">To start and stop traces via xbTrace.exe on the console, you have to call register_for_protocol_activation on the service_call_logging_config class.</span></span>  <span data-ttu-id="509a6-121">この呼び出しは、ゲームの初期化中に 1 回行います。</span><span class="sxs-lookup"><span data-stu-id="509a6-121">Make this call once during your game initialization.</span></span>

## <a name="resync-for-rta"></a><span data-ttu-id="509a6-122">RTA の再同期</span><span class="sxs-lookup"><span data-stu-id="509a6-122">Resync for RTA</span></span>
* <span data-ttu-id="509a6-123">ユーザー情報が古い可能性があると RTA サービスが判断した場合、再同期が行われることがあります。</span><span class="sxs-lookup"><span data-stu-id="509a6-123">Resync may occur when the RTA service believes that the users information may be out of date</span></span>
* <span data-ttu-id="509a6-124">タイトルは、サブスクライブしているサブスクリプションの対応する HTTP 呼び出しを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="509a6-124">Titles should call corresponding HTTP calls for the subscriptions that they are subscribed to</span></span>
* <span data-ttu-id="509a6-125">タイトルが再サブスクライブする必要はありません</span><span class="sxs-lookup"><span data-stu-id="509a6-125">Titles do not have to resubscribe</span></span>
* <span data-ttu-id="509a6-126">xbox::services::real_time_activity_service::add_resync_handler が追加されました</span><span class="sxs-lookup"><span data-stu-id="509a6-126">Added xbox::services::real_time_activity_service::add_resync_handler</span></span>
* <span data-ttu-id="509a6-127">xbox::services::real_time_activity_service::remove_resync_handler が削除されました</span><span class="sxs-lookup"><span data-stu-id="509a6-127">Removed xbox::services::real_time_activity_service::remove_resync_handler</span></span>
* <span data-ttu-id="509a6-128">http_status_429_too_many_requests が追加されました</span><span class="sxs-lookup"><span data-stu-id="509a6-128">Added http_status_429_too_many_requests</span></span>
* <span data-ttu-id="509a6-129">このエラー状況は、送信した http 要求が多すぎるためにタイトルのスロットリングが発生しているときに見られます</span><span class="sxs-lookup"><span data-stu-id="509a6-129">This error condition will be seen when a title is being throttled for sending too many http requests</span></span>

## <a name="documentation"></a><span data-ttu-id="509a6-130">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="509a6-130">Documentation</span></span>
* <span data-ttu-id="509a6-131">Xbox Live Services API 2.0 への移行</span><span class="sxs-lookup"><span data-stu-id="509a6-131">Migrating to Xbox Live Services API 2.0</span></span>
* <span data-ttu-id="509a6-132">エラー処理</span><span class="sxs-lookup"><span data-stu-id="509a6-132">Error Handling</span></span>
* <span data-ttu-id="509a6-133">Windows 10 での Xbox Live 認証</span><span class="sxs-lookup"><span data-stu-id="509a6-133">Xbox Live Authentication in Windows 10</span></span>
* <span data-ttu-id="509a6-134">コンテキスト検索</span><span class="sxs-lookup"><span data-stu-id="509a6-134">Contextual Search</span></span>
