---
title: Multiplayer Manager
author: KevinAsgari
description: Xbox Live Multiplayer Manager について説明します。これは、マルチプレイヤーを簡単に実装できるように設計された高レベルの API です。
ms.assetid: f3a6c8bc-4f73-4b99-ac51-aadee73c8cfa
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bf931a2811a9a627c40a7dc45178688236437fa8
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5471932"
---
# <a name="multiplayer-manager"></a>Multiplayer Manager

Xbox Live は、タイトルにマルチプレイヤー機能を追加するための広範なサポートを提供し、ゲームで世界中の Xbox Live メンバーを接続できるようにします。  これには、多様なマッチメイキング シナリオや、進行中のフレンドのゲームにプレイヤーが参加する機能などが含まれます。 ただし、マルチプレイヤー 2015 API を直接使用して Xbox Live マルチプレイヤーを実装することは複雑な作業になる可能性があります。ベスト プラクティスに従い認定要件を満たしていることを確認するために、多くの設計とテストが必要になります。

Multiplayer Manager を使用すると、セッションとマッチメイキングを管理し、状態とイベントに基づくプログラミング モデルの提供により、ゲームにマルチプレイヤー機能を簡単に追加できます。 Multiplayer Manager は、Xbox Live ゲーム向けのマルチプレイヤー シナリオの実装を容易にするために設計された一連の API です。 Multiplayer Manager では、フレンドとのマルチプレイヤー ゲームのプレイ、ゲームへの招待の処理、途中参加の処理、マッチメイキングなどの一般的なマルチプレイヤー シナリオを念頭に置いて設計された API が提供されます。 複数のローカル ユーザーがサポートされ、サードパーティーのマッチメイキング サービスを使用する場合には、タイトルを容易にマルチプレイヤー セッション ディレクトリと統合できます。 これらのシナリオの多くは、わずか数回の API 呼び出しで実現できます。

## <a name="key-features"></a>主な機能
Multiplayer Manager API の主な機能を次に示します。

* 容易なセッション管理と Xbox Live マッチメイキング
* 状態とイベントに基づくプログラミング モデル
* Xbox Live のベスト プラクティスの確保およびマルチプレイヤーの XR 準拠
* Xbox One XDK および UWP タイトルのサポート
* [マルチプレイヤー 2015 のフローチャート](https://developer.xboxlive.com/en-us/platform/development/education/Documents/Xbox%20One%20Multiplayer%202015%20Developer%20Flowcharts.aspx)の実装
* 従来のマルチプレイヤー 2015 API との共存

>**重要**: 認定に合格するためには、オンライン マルチプレイヤーのために必要なイベントをゲームに実装する必要があることに変更はありません。

## <a name="overview"></a>概要
Multiplayer Manager には、いくつかの重要な概念があります。
* `lobby_session` : このデバイスに対してローカルなユーザーと、ゲームに招待したフレンドを管理するために使用する永続的なセッションです。 グループは、ゲームの複数のラウンドやマップ、レベルなどをプレイすることがあり、ロビー セッションがこのフレンドのコア グループ (デバイスにローカルのプレイヤーを含む) を追跡します。 一般に、このグループは、ホストがメニューを移動し、グループ メンバーとチャットしてどのゲーム モードをプレイするかを決めるときに形成されます。

* `game_session` : ゲームの特定のインスタンスをプレイしているプレイヤーを追跡します。 たとえば、レース、マップ、レベルです。 ロビー セッションのメンバーが含まれる `join_game_from_lobby` で新しいゲーム セッションを作成できます。  メンバーが招待を受け入れると、メンバーはロビーおよびゲーム セッションに追加されます (空きがある場合)。 マッチメイキングが有効になっている場合はゲーム セッションに他のプレイヤーを追加できますが、それらの追加プレイヤーはロビー セッションには追加されません。 これは、ゲームが終了すると、ロビー セッション内のプレイヤーはまだ一緒にいますが、マッチメイキングからの追加プレイヤーはそうではないことを意味します。

* `multiplayer_member` : ローカルまたはリモート デバイスにサインインしている個々のユーザーを表します。

* `do_work` : タイトルと Xbox Live マルチプレイヤー サービスとの間で適切なゲームの状態の更新が維持されるようにします。 最適なパフォーマンスを得るには、do_work() を頻繁に呼び出す必要があります (フレームごとに 1 回 など)。 do_work() は、ゲームで処理する `multiplayer_event` コールバック イベントのリストを提供します。

## <a name="state-machine"></a>ステート マシン
`do_work()` 呼び出しは、状態を最新に維持するために必要です。  Multiplayer Manager が機能するためには、デベロッパーが `do_work()` メソッドを定期的に呼び出す必要があります。 これを行う最も信頼性の高い方法は、フレームごとに少なくとも 1 回呼び出すことです。 `do_work()` で実行する作業がないと迅速に制御が戻るため、呼び出しの頻度が多すぎることについて心配する必要はありません。

Multiplayer Manager API によって返されるすべてのオブジェクトがスレッドセーフであるとは見なさないでください。 ただし、複数のスレッドから呼び出す場合は、スレッドの同期の実行を制御できます。 ライブラリには内部的なマルチスレッド保護機能がありますが、別のスレッドが `do_work()` を呼び出している可能性がある間に、あるスレッドで任意の値にアクセスする必要がある場合は (たとえば、members() リストの処理)、独自のロック処理を実装する必要があります。

Multiplayer Manager は、状態に基づくモデルを管理し、プレイヤーの参加、退出、またはセッションの更新が発生するとバックグラウンドでセッションを更新します。 UI スレッドとゲーム スレッドの間でスレッド同期の問題が発生しないようにするため、Multiplayer Manager は `do_work()` メソッドが呼び出されるまで、アプリのセッションの表示状態を更新しません。 従来は、セッションの変更などのイベントに関する通知をバックグラウンド スレッドで受信してから UI スレッドと同期し、それらの変更を表示する必要がありました。 Multiplayer Manager では、この処理は自動的に行われます。  必要なときにメイン スレッドで `do_work()` を呼び出して、Multiplayer Manager が自動的にバッファーリングしている、状態の最新スナップショットを取得できます。

## <a name="events-and-notifications"></a>イベントと通知
Multiplayer Manager は、重要なイベント (`multiplayer_event_type` を参照) のセットを定義し、イベントの発生時に `do_work()` メソッドを通じてタイトルに通知します  (リモート プレーヤーの参加または退出、メンバーのプロパティ変更、セッション状態の変更などのイベント)。 すべての Multiplayer Manager API は同期的です。 `do_work()` メソッドは、非同期操作が完了したときにイベントのリストを返します。 タイトルはこれらのイベントを適切に処理する必要があります。 詳しくは、`multiplayer_event` クラスのドキュメントをご覧ください。

イベントごとに、イベント タイプに応じて `event_args` を適切なイベント引数クラスにキャストし、イベントのプロパティを取得する必要があります。 次の例は、`do_work()` を使用したイベントの処理を示しています。

```cpp
auto eventQueue = mpInstance.do_work();
for (auto& event : eventQueue)
{
    switch (event.event_type())
    {
      case multiplayer_event_type::member_joined:
      {
        auto memberJoinedArgs =  std::dynamic_pointer_cast<member_joined_event_args>(event.event_args());
        HandleMemberJoined(memberJoinedArgs);
        break;
      }
      case multiplayer_event_type::session_property_changed:
      {
        auto sessionPropertyChangedArgs =  std::dynamic_pointer_cast<session_property_changed_event_args>(event.event_args());
        HandlePropertiesChanged(sessionPropertyChangedArgs);
        break;
      }
      . . .
    }
}

```

## <a name="scenarios"></a>シナリオ

このセクションでは、いくつかの一般的なシナリオと、各シナリオで呼び出すことがある API を紹介します。  Multiplayer Manager がバックグラウンドで行っていることについても説明しています。

* [フレンドとのプレイ](multiplayer-manager/play-multiplayer-with-friends.md)
* [マッチを探す](multiplayer-manager/play-multiplayer-with-matchmaking.md)
* [ゲームへの招待を送信する](multiplayer-manager/send-game-invites.md)
* [プロトコルのアクティブ化を処理する](multiplayer-manager/handle-protocol-activation.md)

API の概要については、「[Multiplayer Manager API の概要](multiplayer-manager/multiplayer-manager-api-overview.md)」をご覧ください。

## <a name="what-multiplayer-manager-does-not-do"></a>Multiplayer Manager でサポートされないこと
Multiplayer Manager によってマルチプレイヤー シナリオの実装は大幅に容易になり、デベロッパーからのデータの一部が抽象化されますが、処理できないことや、適していないことがいくつかあります。

* 大規模な (1 セッション内のプレイヤー数が 100 人を超える) セッションを必要とする、MMO やその他の種類のゲームのような、永続的なオンライン サーバー ゲーム。
* サーバー間のセッション管理。

>Multiplayer Manager は特定のネットワーク技術に縛られず、どのネットワーク レイヤーでも機能する必要があります。

## <a name="next-steps"></a>次の手順

動作する API の例については、C++ または WinRT いずれかの *Multiplayer* サンプルをご覧ください。

API ドキュメントは、Microsoft::Xbox::Services::Multiplayer::Manager 名前空間の C++ ガイドまたは WinRT ガイドにあります。  `multiplayer_manager.h` ヘッダーもご覧ください。

に関する質問やフィードバック、または Multiplayer Manager を使用して問題が発生した場合ください、担当の DAM に問い合わせてまたはフォーラムでサポート スレッドを投稿[https://forums.xboxlive.com](https://forums.xboxlive.com)します。
