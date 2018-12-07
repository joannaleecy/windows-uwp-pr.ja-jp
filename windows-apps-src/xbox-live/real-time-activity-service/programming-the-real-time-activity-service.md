---
title: リアルタイム アクティビティ サービスのプログラミング
description: C++ API を使った Xbox Live リアルタイム アクティビティ サービスのプログラミングについて説明します。
ms.assetid: 98cdcb1f-41d8-43db-98fc-6647755d3b17
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リアルタイム アクティビティ
ms.localizationpriority: medium
ms.openlocfilehash: f8846d57343f4f7262bbeea2cec03465fa23b2ab
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8740451"
---
# <a name="programming-the-real-time-activity-service-using-c-apis"></a>C++ API を使用したリアルタイム アクティビティ サービスのプログラミング

この記事は、次のセクションで構成されています。

* Xbox Live からのリアルタイム アクティビティ サービスへの接続
* リアルタイム アクティビティ サービスからの切断
* 統計の作成
* リアルタイム アクティビティからの統計へのサブスクライブ
* リアルタイム アクティビティ サービスからの統計へのサブスクライブの解除
* サンプル

## <a name="connecting-to-the-real-time-activity-service-from-xbox-live"></a>Xbox Live からのリアルタイム アクティビティ サービスへの接続

アプリケーションは、リアルタイム アクティビティ (RTA) サービスに接続して、Xbox Live からイベント情報を取得する必要があります。 ここでは、そうした接続の作成方法を示します。

> [!NOTE]
> このトピックの例では、1 人のユーザーのメソッド呼び出しを示します。 ただし、タイトルは、リアルタイム アクティビティ (RTA) サービスに対する接続と接続解除を行うすべてのユーザーに対してこれらの呼び出しを行う必要があります。

### <a name="connecting-to-the-real-time-activity-service"></a>リアルタイム アクティビティ サービスへの接続

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

### <a name="creating-a-statistic"></a>統計の作成

XDK デベロッパーである場合やクロスプレイ タイトルの開発を行う場合は、XDP で統計を作成します。  Windows 10 で実行される純粋な UWP を作成している場合は、パートナー センターで統計を作成します。

#### <a name="xdk-developers"></a>XDK の開発者

XDP で統計を作成する方法については、[XDP のドキュメント](https://developer.xboxlive.com/en-us/xdphelp/development/xdpdocs/Pages/setting_up_service_configuration_10_27_15_a.aspx#events)を参照してください。  統計を作成してイベントを定義したら、[XCETool](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/atoc_xce_jun15.aspx) を実行して、アプリケーションが使用するヘッダーを生成する必要があります。  このヘッダーには、統計を変更するイベントを送信するために呼び出すことができる関数が含まれています。

#### <a name="uwp-developers"></a>UWP の開発者

クロスプレイ タイトルではない Windows 10 での UWP を開発している場合は、[パートナー センター](https://partner.microsoft.com/dashboard)で統計を定義します。 パートナー センターで統計を構成する方法については、[パートナー センターの統計の構成の資料](../leaderboards-and-stats-2017/player-stats-configure-2017.md)を読みます。

> [!NOTE]
> 統計 2013年の開発者は、[パートナー センター](https://partner.microsoft.com/dashboard)で[統計 2013年の構成](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/windows-configure-stats-2013)に関する情報について、担当の DAM に連絡する必要があります。

### <a name="disconnecting-from-the-real-time-activity-service"></a>リアルタイム アクティビティ サービスからの切断

```cpp
void Example_RealTimeActivity_Disconnect()
{
    // Get the list of users from the system, and create an Xbox Live context from the first.
    // This user's authentication token will be used for the service requests.
    std::shared_ptr<xbox_live_context> xboxLiveContext = std::make_shared<xbox_live_context>(User::Users->GetAt(0));

    xboxLiveContext->real_time_activity_service()->deactivate();
}
```

## <a name="subscribing-to-a-statistic-from-the-real-time-activity"></a>リアルタイム アクティビティからの統計へのサブスクライブ

アプリケーションをリアルタイム アクティビティ (RTA) Xbox デベロッパー ポータル (XDP) またはパートナー センターで構成された統計情報を変更するときに、更新プログラムを取得するをサブスクライブします。

### <a name="subscribing-to-a-statistic-from-the-real-time-activity-service"></a>リアルタイム アクティビティ サービスからの統計へのサブスクライブ

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
        L"xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx",    // Get SCID from "Product Details" page in XDP or the Xbox Live Setup page in Partner Center
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

## <a name="unsubscribing-from-a-statistic-from-the-real-time-activity-service"></a>リアルタイム アクティビティ サービスからの統計へのサブスクライブの解除

アプリケーションはリアルタイム アクティビティ (RTA) サービスからの統計にサブスクライブして、統計が変化したときに最新情報を取得します。 更新が不要になったら、サブスクリプションを終了できます。このトピックのコードではその方法を示します。

### <a name="unsubscribing-from-a-real-time-services-statistic"></a>リアルタイム サービス統計のサブスクライブ解除

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
> リアルタイム アクティビティ サービスは、2 つの時間の使用後切断は、コードはこれを検出し、まだ必要な場合は、リアルタイム アクティビティ サービスへの接続を再確立できる必要があります。 これは、主に、認証トークンの有効期限が更新されることを確認します。
> 
> クライアントは、マルチプレイヤー セッションは、RTA を使用し、30 秒間の切断された、マルチプレイヤー セッション Directory(MPSD) RTA セッションが閉じられるし、セッションからユーザーが開始を検出します。 RTA クライアントが接続が閉じられたときに検出し、再接続を開始 MPSD セッションを終了する前にサブスクライブすることです。