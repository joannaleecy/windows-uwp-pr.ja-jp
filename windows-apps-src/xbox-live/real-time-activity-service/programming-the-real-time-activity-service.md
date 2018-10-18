---
title: リアルタイム アクティビティ サービスのプログラミング
author: KevinAsgari
description: C++ API を使った Xbox Live リアルタイム アクティビティ サービスのプログラミングについて説明します。
ms.assetid: 98cdcb1f-41d8-43db-98fc-6647755d3b17
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リアルタイム アクティビティ
ms.localizationpriority: medium
ms.openlocfilehash: 57793a01ebd4c97130df6a476b447a99d78c990e
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4754543"
---
# <a name="programming-the-real-time-activity-service-using-c-apis"></a><span data-ttu-id="8be1e-104">C++ API を使用したリアルタイム アクティビティ サービスのプログラミング</span><span class="sxs-lookup"><span data-stu-id="8be1e-104">Programming the Real-Time Activity Service using C++ APIs</span></span>

<span data-ttu-id="8be1e-105">この記事は、次のセクションで構成されています。</span><span class="sxs-lookup"><span data-stu-id="8be1e-105">This article contains the following sections</span></span>

* <span data-ttu-id="8be1e-106">Xbox Live からのリアルタイム アクティビティ サービスへの接続</span><span class="sxs-lookup"><span data-stu-id="8be1e-106">Connecting to the Real-Time Activity Service from Xbox Live</span></span>
* <span data-ttu-id="8be1e-107">リアルタイム アクティビティ サービスからの切断</span><span class="sxs-lookup"><span data-stu-id="8be1e-107">Disconnected from the Real-Time Activity Service</span></span>
* <span data-ttu-id="8be1e-108">統計の作成</span><span class="sxs-lookup"><span data-stu-id="8be1e-108">Creating a statistic</span></span>
* <span data-ttu-id="8be1e-109">リアルタイム アクティビティからの統計へのサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="8be1e-109">Subscribing to a statistic from the Real-Time Activity</span></span>
* <span data-ttu-id="8be1e-110">リアルタイム アクティビティ サービスからの統計へのサブスクライブの解除</span><span class="sxs-lookup"><span data-stu-id="8be1e-110">Unsubscribing from a statistic from the Real-Time Activity service</span></span>
* <span data-ttu-id="8be1e-111">サンプル</span><span class="sxs-lookup"><span data-stu-id="8be1e-111">Sample</span></span>

## <a name="connecting-to-the-real-time-activity-service-from-xbox-live"></a><span data-ttu-id="8be1e-112">Xbox Live からのリアルタイム アクティビティ サービスへの接続</span><span class="sxs-lookup"><span data-stu-id="8be1e-112">Connecting to the Real-Time Activity Service from Xbox Live</span></span>

<span data-ttu-id="8be1e-113">アプリケーションは、リアルタイム アクティビティ (RTA) サービスに接続して、Xbox Live からイベント情報を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8be1e-113">Applications must connect to the Real-Time Activity (RTA) service to get event information from Xbox Live.</span></span> <span data-ttu-id="8be1e-114">ここでは、そうした接続の作成方法を示します。</span><span class="sxs-lookup"><span data-stu-id="8be1e-114">This topic shows how to make such a connection.</span></span>

> [!NOTE]
> <span data-ttu-id="8be1e-115">このトピックの例では、1 人のユーザーのメソッド呼び出しを示します。</span><span class="sxs-lookup"><span data-stu-id="8be1e-115">The examples used in this topic indicate method calls for one user.</span></span> <span data-ttu-id="8be1e-116">ただし、タイトルは、リアルタイム アクティビティ (RTA) サービスに対する接続と接続解除を行うすべてのユーザーに対してこれらの呼び出しを行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="8be1e-116">However, your title must make these calls for all users to connect to and disconnect from the Real-Time Activity (RTA) service.</span></span>

### <a name="connecting-to-the-real-time-activity-service"></a><span data-ttu-id="8be1e-117">リアルタイム アクティビティ サービスへの接続</span><span class="sxs-lookup"><span data-stu-id="8be1e-117">Connecting to the Real-Time Activity service</span></span>

```cpp
void Example_RealTimeActivity_ConnectAsync()
{
    // Get the list of users from the system, and create an Xbox Live context from the first.
    // This user's authentication token will be used for the service requests.

    // Note, only retrieve an XboxLiveContext for a given user *once*.  Otherwise you may encounter unpredictable behavior.
    std::shared_ptr<xbox_live_context> xboxLiveContext = std::make_shared<xbox_live_context>(User::Users->GetAt(0));

    xboxLiveContext->real_time_activity_service()->activate();
}
```

### <a name="creating-a-statistic"></a><span data-ttu-id="8be1e-118">統計の作成</span><span class="sxs-lookup"><span data-stu-id="8be1e-118">Creating a statistic</span></span>

<span data-ttu-id="8be1e-119">XDK デベロッパーである場合やクロスプレイ タイトルの開発を行う場合は、XDP で統計を作成します。</span><span class="sxs-lookup"><span data-stu-id="8be1e-119">You create statistics on XDP if you are an XDK developer or working on a cross-play title.</span></span>  <span data-ttu-id="8be1e-120">Windows 10 で実行される純粋な UWP を作成する場合は、デベロッパー センターで統計を作成します。</span><span class="sxs-lookup"><span data-stu-id="8be1e-120">You create statistic on Dev Center if you are making a pure UWP running on Windows 10.</span></span>

#### <a name="xdk-developers"></a><span data-ttu-id="8be1e-121">XDK の開発者</span><span class="sxs-lookup"><span data-stu-id="8be1e-121">XDK developers</span></span>

<span data-ttu-id="8be1e-122">XDP で統計を作成する方法については、[XDP のドキュメント](https://developer.xboxlive.com/en-us/xdphelp/development/xdpdocs/Pages/setting_up_service_configuration_10_27_15_a.aspx#events)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8be1e-122">For information on how to create a stat on XDP, please see the [XDP Documentation](https://developer.xboxlive.com/en-us/xdphelp/development/xdpdocs/Pages/setting_up_service_configuration_10_27_15_a.aspx#events).</span></span>  <span data-ttu-id="8be1e-123">統計を作成してイベントを定義したら、[XCETool](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/atoc_xce_jun15.aspx) を実行して、アプリケーションが使用するヘッダーを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8be1e-123">After you have created your stat and defined your events, you will need to run the [XCETool](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/atoc_xce_jun15.aspx) to generate a header used by your application.</span></span>  <span data-ttu-id="8be1e-124">このヘッダーには、統計を変更するイベントを送信するために呼び出すことができる関数が含まれています。</span><span class="sxs-lookup"><span data-stu-id="8be1e-124">This header contains functions you can call to send events that modify stats.</span></span>

#### <a name="uwp-developers"></a><span data-ttu-id="8be1e-125">UWP の開発者</span><span class="sxs-lookup"><span data-stu-id="8be1e-125">UWP developers</span></span>

<span data-ttu-id="8be1e-126">クロスプレイ タイトルではない Windows 10 で UWP を開発している場合は、 [Windows デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)で統計を定義します。</span><span class="sxs-lookup"><span data-stu-id="8be1e-126">If you are developing a UWP on Windows 10 that is not a cross-play title, you define your stats on [Windows Dev Center](https://developer.microsoft.com/dashboard/windows/overview).</span></span> <span data-ttu-id="8be1e-127">デベロッパー センターで統計を構成する方法については、[デベロッパー センターの統計の構成の資料](../leaderboards-and-stats-2017/player-stats-configure-2017.md)を読みます。</span><span class="sxs-lookup"><span data-stu-id="8be1e-127">Read the [Dev Center stats configuration article](../leaderboards-and-stats-2017/player-stats-configure-2017.md) to learn how to configure stats on Dev Center.</span></span>

> [!NOTE]
> <span data-ttu-id="8be1e-128">統計 2013年の開発者は、[デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)で[統計 2013年構成](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/windows-configure-stats-2013)については、担当の DAM に連絡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8be1e-128">Stats 2013 developer will need to contact their DAM for information concerning [Stats 2013 configuration](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/windows-configure-stats-2013) on [Dev Center](https://developer.microsoft.com/dashboard/windows/overview).</span></span>

### <a name="disconnecting-from-the-real-time-activity-service"></a><span data-ttu-id="8be1e-129">リアルタイム アクティビティ サービスからの切断</span><span class="sxs-lookup"><span data-stu-id="8be1e-129">Disconnecting from the Real-Time Activity service</span></span>

```cpp
void Example_RealTimeActivity_Disconnect()
{
    // Get the list of users from the system, and create an Xbox Live context from the first.
    // This user's authentication token will be used for the service requests.
    std::shared_ptr<xbox_live_context> xboxLiveContext = std::make_shared<xbox_live_context>(User::Users->GetAt(0));

    xboxLiveContext->real_time_activity_service()->deactivate();
}
```

## <a name="subscribing-to-a-statistic-from-the-real-time-activity"></a><span data-ttu-id="8be1e-130">リアルタイム アクティビティからの統計へのサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="8be1e-130">Subscribing to a statistic from the Real-Time Activity</span></span>

<span data-ttu-id="8be1e-131">アプリケーションをリアルタイム アクティビティ (RTA) Xbox デベロッパー ポータル (XDP) または Windows デベロッパー センターで構成された統計情報を変更するときに、更新プログラムを取得するをサブスクライブします。</span><span class="sxs-lookup"><span data-stu-id="8be1e-131">Applications subscribe to a Real-Time Activity (RTA) to get updates when the statistics configured in Xbox Developer Portal (XDP) or Windows Dev Center change.</span></span>

### <a name="subscribing-to-a-statistic-from-the-real-time-activity-service"></a><span data-ttu-id="8be1e-132">リアルタイム アクティビティ サービスからの統計へのサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="8be1e-132">Subscribing to a statistic from the Real-Time Activity service</span></span>

```cpp
void Example_RealTimeActivity_SubscribeToStatisticChangeAsync()
{
    // Obtain xboxLiveContext as shown in the connect function.  Then add a handler to be called on statistic changes.
    function_context statisticsChangeContext = xboxLiveContext->user_statistics_service().add_statistic_changed_handler(
        [](statistic_change_event_args args )
        {
            // Called on statistic change.  Inspect args to see which one.
            DebugPrint("%S %S", args.latest_statistic().statistic_name().c_str(), args.latest_statistic().value().c_str());
        }
    );

    // Call to subscribe to an individual statistic.  Once the subscription is complete, the handler will be called with the initial value of the statistic.
    auto statisticResults = xboxLiveContext->user_statistics_service().subscribe_to_statistic_change(
        User::Users->GetAt(0)->XboxUserId->Data(),
        L"xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx",    // Get SCID from "Product Details" page in XDP or the Xbox Live Setup page in Dev Center
         L"YourStat"
        );

    std::shared_ptr<statistic_change_subscription> statisticsChangeSubscription;

    if(!statisticResults.err())
    {
        statisticsChangeSubscription = statisticResults.payload();
    }
    else
    {
        DebugPrint("Error calling SubscribeToStatistic: %S", statisticResults.err_message().c_str());
    }
}
```

## <a name="unsubscribing-from-a-statistic-from-the-real-time-activity-service"></a><span data-ttu-id="8be1e-133">リアルタイム アクティビティ サービスからの統計へのサブスクライブの解除</span><span class="sxs-lookup"><span data-stu-id="8be1e-133">Unsubscribing from a statistic from the Real-Time Activity service</span></span>

<span data-ttu-id="8be1e-134">アプリケーションはリアルタイム アクティビティ (RTA) サービスからの統計にサブスクライブして、統計が変化したときに最新情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="8be1e-134">Applications subscribe to a statistic from the Real-Time Activity (RTA) service to get updates when the statistic changes.</span></span> <span data-ttu-id="8be1e-135">更新が不要になったら、サブスクリプションを終了できます。このトピックのコードではその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="8be1e-135">When these updates are no longer needed, the subscription can be terminated, and the code in this topic shows how to do that.</span></span>

### <a name="unsubscribing-from-a-real-time-services-statistic"></a><span data-ttu-id="8be1e-136">リアルタイム サービス統計のサブスクライブ解除</span><span class="sxs-lookup"><span data-stu-id="8be1e-136">Unsubscribing from a real-time services statistic</span></span>

```cpp
void Example_RealTimeActivity_UnsubscribeFromStatisticChangeAsync()
{
    // statisticsChangeSubscription from the Example_RealTimeActivity_SubscribeToStatisticChangeAsync function.
    xboxLiveContext->user_statistics_service().unsubscribe_from_statistic_change(
        statisticsChangeSubscription
        );
}
```

> [!IMPORTANT]
> <span data-ttu-id="8be1e-137">リアルタイム アクティビティ サービスは、2 つの時間の使用後切断は、コードはこれを検出し、まだ必要な場合は、リアルタイム アクティビティ サービスへの接続を再確立できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="8be1e-137">The Real-Time Activity service will disconnect after two hours of use, your code must be able to detect this and re-establish a connection to the Real-Time Activity service if it is still needed.</span></span> <span data-ttu-id="8be1e-138">これは主に、有効期限が認証トークンを更新することです。</span><span class="sxs-lookup"><span data-stu-id="8be1e-138">This is done primarily to ensure that auth tokens are refreshed upon expiration.</span></span>
> 
> <span data-ttu-id="8be1e-139">クライアントがマルチプレイヤー セッションは、RTA を使用して、30 秒間の切断された場合は、マルチプレイヤー セッション Directory(MPSD)、RTA セッションが閉じられ、セッションからユーザーが開始を検出します。</span><span class="sxs-lookup"><span data-stu-id="8be1e-139">If a client uses RTA for multiplayer sessions, and is disconnected for thirty seconds, the Multiplayer Session Directory(MPSD) detects that the RTA session is closed, and kicks the user out of the session.</span></span> <span data-ttu-id="8be1e-140">RTA クライアント接続が閉じられたときを検出し、再接続を開始して MPSD セッションを終了する前にサブスクライブすることです。</span><span class="sxs-lookup"><span data-stu-id="8be1e-140">It's up to the RTA client to detect when the connection is closed and initiate a reconnect and resubscribe before MPSD ends the session.</span></span>