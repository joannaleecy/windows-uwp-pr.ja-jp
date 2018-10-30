---
title: プロトコルのアクティブ化を処理する
author: KevinAsgari
description: Xbox Live Multiplayer Manager を使用してプロトコルのアクティブ化を処理する方法について説明します。
ms.assetid: e514bcb8-4302-4eeb-8c5b-176e23f3929f
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Multiplayer Manager, プロトコルのアクティブ化
ms.localizationpriority: medium
ms.openlocfilehash: 9046686a9db1428935e834e28f02269d710cd8ad
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5757893"
---
# <a name="handle-protocol-activation"></a>プロトコルのアクティブ化を処理する

プロトコルのアクティブ化では、別の操作 (通常、プレイヤーが別のプレイヤーからのゲームの招待を受け入れたとき) への応答としてシステムが自動的にゲームを起動します。

タイトルは、次の方法でプロトコルをアクティブ化できます。

* ユーザーがゲームへの招待を受け入れたとき
* ユーザーがプレイヤーのゲーマーカードから [ゲームに参加] を選択したとき

このシナリオでは、タイトルが起動されてロビーおよびゲーム (存在する場合) に参加したときにプロトコルのアクティブ化を処理する方法について説明します。

プロセスのフローチャートについては、「[フローチャート - プロトコルのアクティブ化を処理する](mpm-flowcharts/mpm-on-protocol-activation.md)」を参照してください。

| メソッド | トリガーされるイベント |
| -----|----------------|
| `multiplayer_manager::join_lobby(IProtocolActivatedEventArgs^ args, User^)` | `join_lobby_completed_event` |
| `multiplayer_lobby_session::set_local_member_connection_address()` | `local_member_connection_address_write_completed ` |
| `multiplayer_lobby_session::set_local_member_properties()` | `member_property_changed` |

プレイヤーがゲームの招待を受け入れたとき、またはプレイヤーのゲーマーカードからフレンドのゲームに参加したとき、プロトコルのアクティブ化を使用してプレイヤーのデバイスでゲームが起動されます。 ゲームが開始したら、Multiplayer Manager はプロトコルがアクティブ化されたイベント引数を使用してロビーに参加できます。 `lobby_session()::add_local_user()` を通してローカル ユーザーを追加していない場合は、必要に応じて`join_lobby()` API によってユーザーのリストに渡すことができます。 招待されたユーザーが追加されていない場合や、追加されたユーザーではない別のユーザーが招待の対象であった場合、`join_lobby()` は失敗となり、`join_lobby_completed_event_args` の一部として招待の送信先の `invited_xbox_user_id()` が提供されます。

ロビーに参加した後は、ローカル メンバーの接続アドレスに加えて、メンバーのカスタム プロパティを設定することをお勧めします。 また、`set_synchronized_host` を使用してホストを設定することもできます (存在しない場合)。

最後に、ゲームが既に進行中であり、招待されたユーザーを受け入れる余裕がある場合、Multiplayer Manager はユーザーをゲーム セッションに自動的に参加させます。 タイトルには、適切なエラー コードとメッセージを提供する `join_game_completed` イベントによって通知されます。

**例:**

```cpp
auto result = mpInstance().join_lobby(IProtocolActivatedEventArgs^ args, users);
if (result.err())
{
  // handle error
}

string_t connectionAddress = L"1.1.1.1";
mpInstance->lobby_session()->set_local_member_connection_address(
    xboxLiveContext->user(),
    connectionAddress);
```

エラー/成功は `join_lobby_completed` イベントを介して処理されます。

**Multiplayer Manager によって実行される機能**

* RTA およびマルチプレイヤーのサブスクリプションを登録する
* ロビー セッションに参加する
 * 既存のロビー状態のクリーンアップ
 * すべてのローカル プレイヤーをアクティブとして参加させる
 * SDA をアップロードする
 * メンバーのプロパティを設定する
* セッション変更イベントに登録する
* ロビー セッションをアクティブ セッションとして設定する
* ゲーム セッションに参加する (存在する場合)
 * 転送ハンドルを使用する
