---
title: Xbox Live SDK の新規事項 - June 2015
author: KevinAsgari
description: Xbox Live SDK の新規事項 - June 2015
ms.assetid: 354bcd47-2564-4dd5-89e3-242bca462b35
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: dd8e905e44c4682daf0e7b0827efc8974513b828
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7166717"
---
# <a name="whats-new-for-the-xbox-live-sdk---june-2015"></a>Xbox Live SDK の新規事項 - June 2015

Xbox Live SDK の June リリースには、次の更新が含まれています。

## <a name="os-and-tool-support"></a>OS とツールのサポート ##
Xbox Live SDK で、Windows 10 と Visual Studio 2015 RC の最新の Insider ビルドがサポートされるようになりました。

## <a name="title-callable-ui-apis"></a>Title Callable UI API

| 注 |
|------|
| このセクションは、UWP タイトルにのみ適用されます。XDK タイトルは、TCUI の Windows.Xbox.UI.SystemUI クラスを参照する必要があります。  |

Xbox Live SDK に、Windows 10 PC/Mobile デバイスでストップ UI を表示するための Title Callable UI (TCUI) をサポートするラッパー API が追加されました。

これらの API は UWP アプリでのみ使うことができます。

TCUI ラッパーは、TitleCallableUI (WinRT) クラスと title_callable_ui (C++) クラスから呼び出すことができます。

ストック UI には次のものが含まれます。
* プレーヤー ピッカー UI
* ゲームへの招待ピッカー UI
* プレーヤー プロフィール カード UI
* フレンドの追加/削除 UI
* ゲーム タイトルの実績の表示 UI

新しい API の使用例については、新しい *TCUI* サンプルをご覧ください。 サンプルは、{*SDK ソースのルート*}\Samples\TCUI にあります。

## <a name="new-authentication-model-for-uwp-apps"></a>UWP アプリの新しい認証モデル
Xbox Live SDK に、Windows 10 PC/Mobile デバイスでストップ UI を表示するための Title Callable UI (TCUI) をサポートするラッパー API が追加されました。

XboxLiveUser (WinRT) クラスと xbox_live_user (C++) クラスを使ってユーザーをサインインできるようになりました。

## <a name="new-api-for-writing-events-in-uwp-apps"></a>UWP アプリでイベントを書き込むための新しい API

| 注 |
|------|
| このセクションは、UWP タイトルにのみ適用されます。  XDK 開発者の方は、[ゲーム イベント](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/event-driven-data-platform/game-events)に関する記事で XDK 固有の詳細をご覧ください  |

新しい EventsService (WinRT) クラスと events_service (C++) クラスを使うと、ユーザーの統計情報、実績、ランキングなどを更新できるゲーム内イベントを書き込むことができます。これらの新しいクラスは UWP アプリでのみ使うことができます。

## <a name="breaking-change-to-event-handlers"></a>イベント ハンドラーの重要な変更 ##
C++ SDK のすべてのイベント ハンドラーが単一の `void set_*_handler()` メソッドから `function_context add_*_handler()` メソッドと `void remove_*_handler(function_context context)` メソッドのペアに変更されました。

各 `add_*_handler()` メソッドが `function_context` オブジェクトを返すようになりました。 イベント ハンドラーを削除した場合、`function_context` オブジェクトを渡す必要があります。

次に、例を示します。
```
function_context subscriptionLostContext = xbox_live_context()->multiplayer_service().add_multiplayer_subscription_lost_handler(...);

localUser->xbox_live_context()->multiplayer_service().remove_multiplayer_subscription_lost_handler(subscriptionLostContext);
```

## <a name="new-apis-for-managing-multiplayer-scenarios"></a>マルチプレイヤー シナリオを管理するための新しい API
Xbox Live SDK に、一般的なマルチプレイヤー シナリオを管理するための C++ API のセットが追加されました。 これらの API は、xbox.services.experimental.multiplayer 名前空間に含まれています。

これらの API は、試験的な名前空間に含まれているため、フィードバックに応じて変更される可能性があります。  開発者の皆さんからのフィードバックをお待ちしています。

これらの新しい API の使用例については、新しい *MultiplayerManager* サンプルをご覧ください。 サンプルは、{*SDK ソースのルート*}\Samples\MultiplayerManager にあります。
