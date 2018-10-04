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
ms.openlocfilehash: eeb30b5ad83c44ac4a6feb1471dc31a2e33730a1
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4315443"
---
# <a name="programming-the-real-time-activity-service-using-c-apis"></a><span data-ttu-id="7db15-104">C++ API を使用したリアルタイム アクティビティ サービスのプログラミング</span><span class="sxs-lookup"><span data-stu-id="7db15-104">Programming the Real-Time Activity Service using C++ APIs</span></span>

<span data-ttu-id="7db15-105">この記事は、次のセクションで構成されています。</span><span class="sxs-lookup"><span data-stu-id="7db15-105">This article contains the following sections</span></span>

* <span data-ttu-id="7db15-106">Xbox Live からのリアルタイム アクティビティ サービスへの接続</span><span class="sxs-lookup"><span data-stu-id="7db15-106">Connecting to the Real-Time Activity Service from Xbox Live</span></span>
* <span data-ttu-id="7db15-107">リアルタイム アクティビティ サービスからの切断</span><span class="sxs-lookup"><span data-stu-id="7db15-107">Disconnected from the Real-Time Activity Service</span></span>
* <span data-ttu-id="7db15-108">統計の作成</span><span class="sxs-lookup"><span data-stu-id="7db15-108">Creating a statistic</span></span>
* <span data-ttu-id="7db15-109">リアルタイム アクティビティからの統計へのサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="7db15-109">Subscribing to a statistic from the Real-Time Activity</span></span>
* <span data-ttu-id="7db15-110">リアルタイム アクティビティ サービスからの統計へのサブスクライブの解除</span><span class="sxs-lookup"><span data-stu-id="7db15-110">Unsubscribing from a statistic from the Real-Time Activity service</span></span>
* <span data-ttu-id="7db15-111">サンプル</span><span class="sxs-lookup"><span data-stu-id="7db15-111">Sample</span></span>

## <a name="connecting-to-the-real-time-activity-service-from-xbox-live"></a><span data-ttu-id="7db15-112">Xbox Live からのリアルタイム アクティビティ サービスへの接続</span><span class="sxs-lookup"><span data-stu-id="7db15-112">Connecting to the Real-Time Activity Service from Xbox Live</span></span>

<span data-ttu-id="7db15-113">アプリケーションは、リアルタイム アクティビティ (RTA) サービスに接続して、Xbox Live からイベント情報を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7db15-113">Applications must connect to the Real-Time Activity (RTA) service to get event information from Xbox Live.</span></span> <span data-ttu-id="7db15-114">ここでは、そうした接続の作成方法を示します。</span><span class="sxs-lookup"><span data-stu-id="7db15-114">This topic shows how to make such a connection.</span></span>

> [!NOTE]
> <span data-ttu-id="7db15-115">このトピックの例では、1 人のユーザーのメソッド呼び出しを示します。</span><span class="sxs-lookup"><span data-stu-id="7db15-115">The examples used in this topic indicate method calls for one user.</span></span> <span data-ttu-id="7db15-116">ただし、タイトルは、リアルタイム アクティビティ (RTA) サービスに対する接続と接続解除を行うすべてのユーザーに対してこれらの呼び出しを行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7db15-116">However, your title must make these calls for all users to connect to and disconnect from the Real-Time Activity (RTA) service.</span></span>

### <a name="connecting-to-the-real-time-activity-service"></a><span data-ttu-id="7db15-117">リアルタイム アクティビティ サービスへの接続</span><span class="sxs-lookup"><span data-stu-id="7db15-117">Connecting to the Real-Time Activity service</span></span>

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

### <a name="creating-a-statistic"></a><span data-ttu-id="7db15-118">統計の作成</span><span class="sxs-lookup"><span data-stu-id="7db15-118">Creating a statistic</span></span>

<span data-ttu-id="7db15-119">XDK デベロッパーである場合やクロスプレイ タイトルの開発を行う場合は、XDP で統計を作成します。</span><span class="sxs-lookup"><span data-stu-id="7db15-119">You create statistics on XDP if you are an XDK developer or working on a cross-play title.</span></span>  <span data-ttu-id="7db15-120">Windows 10 で実行される純粋な UWP を作成する場合は、デベロッパー センターで統計を作成します。</span><span class="sxs-lookup"><span data-stu-id="7db15-120">You create statistic on Dev Center if you are making a pure UWP running on Windows 10.</span></span>

#### <a name="xdk-developers"></a><span data-ttu-id="7db15-121">XDK の開発者</span><span class="sxs-lookup"><span data-stu-id="7db15-121">XDK developers</span></span>

<span data-ttu-id="7db15-122">XDP で統計を作成する方法については、[XDP のドキュメント](https://developer.xboxlive.com/en-us/xdphelp/development/xdpdocs/Pages/setting_up_service_configuration_10_27_15_a.aspx#events)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7db15-122">For information on how to create a stat on XDP, please see the [XDP Documentation](https://developer.xboxlive.com/en-us/xdphelp/development/xdpdocs/Pages/setting_up_service_configuration_10_27_15_a.aspx#events).</span></span>  <span data-ttu-id="7db15-123">統計を作成してイベントを定義したら、[XCETool](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/atoc_xce_jun15.aspx) を実行して、アプリケーションが使用するヘッダーを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7db15-123">After you have created your stat and defined your events, you will need to run the [XCETool](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/atoc_xce_jun15.aspx) to generate a header used by your application.</span></span>  <span data-ttu-id="7db15-124">このヘッダーには、統計を変更するイベントを送信するために呼び出すことができる関数が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7db15-124">This header contains functions you can call to send events that modify stats.</span></span>

#### <a name="uwp-developers"></a><span data-ttu-id="7db15-125">UWP の開発者</span><span class="sxs-lookup"><span data-stu-id="7db15-125">UWP developers</span></span>

<span data-ttu-id="7db15-126">クロスプレイ タイトルではない Windows 10 で UWP を開発している場合は、 [Windows デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)で統計を定義します。</span><span class="sxs-lookup"><span data-stu-id="7db15-126">If you are developing a UWP on Windows 10 that is not a cross-play title, you define your stats on [Windows Dev Center](https://developer.microsoft.com/dashboard/windows/overview).</span></span> <span data-ttu-id="7db15-127">デベロッパー センターで統計を構成する方法については、[デベロッパー センターの統計の構成の資料](../leaderboards-and-stats-2017/player-stats-configure-2017.md)を読みます。</span><span class="sxs-lookup"><span data-stu-id="7db15-127">Read the [Dev Center stats configuration article](../leaderboards-and-stats-2017/player-stats-configure-2017.md) to learn how to configure stats on Dev Center.</span></span>

> [!NOTE]
> <span data-ttu-id="7db15-128">統計 2013年の開発者は、デベロッパー センターで統計 2013年構成については、担当の DAM に問い合わせてくださいする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7db15-128">Stats 2013 developer will need to contact their DAM for information concerning Stats 2013 configuration on Dev Center.</span></span>

### <a name="disconnecting-from-the-real-time-activity-service"></a><span data-ttu-id="7db15-129">リアルタイム アクティビティ サービスからの切断</span><span class="sxs-lookup"><span data-stu-id="7db15-129">Disconnecting from the Real-Time Activity service</span></span>

```cpp
void Example_RealTimeActivity_Disconnect()
{
    // Get the list of users from the system, and create an Xbox Live context from the first.
    // This user's authentication token will be used for the service requests.
    std::shared_ptr<xbox_live_context> xboxLiveContext = std::make_shared<xbox_live_context>(User::Users->GetAt(0));

    xboxLiveContext->real_time_activity_service()->deactivate();
}
```

## <a name="subscribing-to-a-statistic-from-the-real-time-activity"></a><span data-ttu-id="7db15-130">リアルタイム アクティビティからの統計へのサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="7db15-130">Subscribing to a statistic from the Real-Time Activity</span></span>

<span data-ttu-id="7db15-131">アプリケーションをリアルタイム アクティビティ (RTA) Xbox デベロッパー ポータル (XDP) または Windows デベロッパー センターで構成されている統計が変化したときに、更新プログラムを入手するをサブスクライブします。</span><span class="sxs-lookup"><span data-stu-id="7db15-131">Applications subscribe to a Real-Time Activity (RTA) to get updates when the statistics configured in Xbox Developer Portal (XDP) or Windows Dev Center change.</span></span>

### <a name="subscribing-to-a-statistic-from-the-real-time-activity-service"></a><span data-ttu-id="7db15-132">リアルタイム アクティビティ サービスからの統計へのサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="7db15-132">Subscribing to a statistic from the Real-Time Activity service</span></span>

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

## <a name="unsubscribing-from-a-statistic-from-the-real-time-activity-service"></a><span data-ttu-id="7db15-133">リアルタイム アクティビティ サービスからの統計へのサブスクライブの解除</span><span class="sxs-lookup"><span data-stu-id="7db15-133">Unsubscribing from a statistic from the Real-Time Activity service</span></span>

<span data-ttu-id="7db15-134">アプリケーションはリアルタイム アクティビティ (RTA) サービスからの統計にサブスクライブして、統計が変化したときに最新情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="7db15-134">Applications subscribe to a statistic from the Real-Time Activity (RTA) service to get updates when the statistic changes.</span></span> <span data-ttu-id="7db15-135">更新が不要になったら、サブスクリプションを終了できます。このトピックのコードではその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="7db15-135">When these updates are no longer needed, the subscription can be terminated, and the code in this topic shows how to do that.</span></span>

### <a name="unsubscribing-from-a-real-time-services-statistic"></a><span data-ttu-id="7db15-136">リアルタイム サービス統計のサブスクライブ解除</span><span class="sxs-lookup"><span data-stu-id="7db15-136">Unsubscribing from a real-time services statistic</span></span>

```cpp
void Example_RealTimeActivity_UnsubscribeFromStatisticChangeAsync()
{
    // statisticsChangeSubscription from the Example_RealTimeActivity_SubscribeToStatisticChangeAsync function.
    xboxLiveContext->user_statistics_service().unsubscribe_from_statistic_change(
        statisticsChangeSubscription
        );
}
```
