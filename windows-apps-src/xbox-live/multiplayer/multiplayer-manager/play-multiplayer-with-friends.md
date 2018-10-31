---
title: マルチプレイヤー ゲームをフレンドとプレイする
author: KevinAsgari
description: Xbox Live Multiplayer Manager を使用して、プレイヤーがフレンドとマルチプレイヤー ゲームをプレイできるようにする方法について説明します。
ms.assetid: 6eefee0e-6c0d-473a-97e7-f3e45f574712
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, Multiplayer Manager, フローチャート
ms.localizationpriority: medium
ms.openlocfilehash: 8af1979a92821a62a625ea9d637a7dbcf9a59edb
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5824634"
---
# <a name="play-a-multiplayer-game-with-friends"></a>マルチプレイヤー ゲームをフレンドとプレイする

簡単なマルチプレイヤー シナリオの 1 つは、ゲーマーにフレンドとのオンラインでのゲーム プレイを許可することです。 このシナリオでは、Multiplayer Manager を使用して実装するために必要な基本手順を説明します。

## <a name="inviting-friends"></a>フレンドの招待

Multiplayer Manager を使用してユーザーのフレンドに招待を送信し、そのフレンドがゲームに途中参加するときの処理は 4 つのステップからなります。

1. [Multiplayer Manager を初期化する](#initialize-multiplayer-manager)
2. [ローカル ユーザーを追加することでロビー セッションを作成する](#create-lobby)
3. [フレンドに招待を送信する](#send-invites)
4. [招待を受け入れる](#accept-invites)
5. [ロビーからゲーム セッションに参加する](#join-game)

手順 1、2、3、5 は、招待を実行したデバイス上で行います。  手順 4 は通常、プロトコルのアクティブ化によるアプリ起動の後、招待されたユーザーのマシンで開始されます。

プロセスのフローチャートについては、「[フローチャート - フレンドとマルチプレイヤー/協力型ゲームをプレイする](mpm-flowcharts/mpm-play-with-friends.md)」をご覧ください。

### <a name="1-initialize-multiplayer-manager-a-nameinitialize-multiplayer-manager"></a>1) Multiplayer Manager を初期化する <a name="initialize-multiplayer-manager">

| 呼び出し | トリガーされるイベント |
|-----|----------------|
| `multiplayer_manager::initialize(lobbySessionTemplateName)` | 該当なし |

(サービス構成で構成される) 有効なセッション テンプレート名が指定されていることを前提に、Multiplayer Manager の初期化時にロビー セッション オブジェクトが自動的に作成されます。 このとき、サービスでロビー セッション インスタンスが作成されるわけではないことに注意してください。

**例:**

```cpp
auto mpInstance = multiplayer_manager::get_singleton_instance();

mpInstance->initialize(lobbySessionTemplateName);
```


### <a name="2-create-the-lobby-session-by-adding-local-usersa-namecreate-lobby"></a>2) ローカル ユーザーを追加することでロビー セッションを作成する<a name="create-lobby">

| メソッド | トリガーされるイベント |
|-----|----------------|
| `multiplayer_lobby_session::add_local_user()` | `user_added_event` |
| `multiplayer_lobby_session::set_local_member_connection_address()` | `local_member_connection_address_write_completed ` |
| `multiplayer_lobby_session::set_local_member_properties()` | `member_property_changed` |

ここでは、ローカルでサインインしている Xbox Live ユーザーをロビー セッションに追加します。 最初のユーザーが追加されたときに新しいロビーをホストします。 他のすべてのユーザーについては、セカンダリー ユーザーとして既存のロビーに追加されます。 この API は、フレンドが参加するシェルのロビーも公開します。 招待の送信、ロビーのプロパティの設定、および lobby() を介したロビー メンバーへのアクセスは、ローカル ユーザーの追加後にのみ可能です。

ロビーに参加した後は、ローカル メンバーの接続アドレスに加えて、メンバーのカスタム プロパティを設定することをお勧めします。

ローカルにサインインしたすべてのユーザーに対して、このプロセスを繰り返す必要があります。

**例: (1 人のローカル ユーザー)**

```cpp
auto mpInstance = multiplayer_manager::get_singleton_instance();

auto result = mpInstance->lobby_session()->add_local_user(xboxLiveContext->user());
if (result.err())
{
  // handle error
}

// Set member connection address
string_t connectionAddress = L"1.1.1.1";
mpInstance->lobby_session()->set_local_member_connection_address(
    xboxLiveContext->user(),
    connectionAddress);

// Set custom member properties
mpInstance->lobby_session()->set_local_member_properties(xboxLivecontext->user(), ..., ...)
```

**例: (複数のローカル ユーザー)**

```cpp
auto mpInstance = multiplayer_manager::get_singleton_instance();
string_t connectionAddress = L"1.1.1.1";

for (User^ user : User::Users)
{
  if( user->IsSignedIn )
  {
    auto result = mpInstance.lobby_session()->add_local_user(user);
    if (result.err())
    {
      // handle error
    }

    // Set member connection address
    mpInstance->lobby_session()->set_local_member_connection_address(
        xboxLiveContext->user(), connectionAddress);

    // Set custom member properties
    mpInstance->lobby_session()->set_local_member_properties(xboxLivecontext->user(), ..., ...)
  }
}

```


変更は次回の `do_work()` 呼び出しでバッチ処理されます。  
Multiplayer Manager は、ユーザーがロビー セッションに追加されるたびに `user_added` イベントを生成します。 イベントのエラー コードを調べて、そのユーザーが正常に追加されたかどうかを確認することをお勧めします。 障害が発生した場合は、障害の詳細な理由がエラー メッセージで提供されます。

**Multiplayer Manager によって実行される機能**

* リアルタイム アクティビティおよびマルチプレイヤーのサブスクリプションを Xbox Live マルチプレイヤー サービスに登録する
* ロビー セッションを作成する
* すべてのローカル プレイヤーをアクティブとして参加させる
* SDA をアップロードする
* メンバーのプロパティを設定する
* セッション変更イベントに登録する
* ロビー セッションをアクティブ セッションとして設定する

### <a name="3-send-invites-to-friends-a-namesend-invites"></a>3) フレンドに招待を送信する <a name="send-invites">

| メソッド | トリガーされるイベント |
| -----|----------------|
| `multiplayer_lobby_session::invite_friends()` | `invite_sent` |
| `multiplayer_lobby_session::invite_users()` | `invite_sent` |

次に、フレンド招待用の標準 Xbox UI を表示します。 表示される UI を使用することでプレイヤーは、フレンドまたは最近のプレイヤーを選択し、ゲームに招待できます。 プレイヤーの確認が得られたら、Multiplayer Manager は選択されたプレイヤーに招待を送信します。

ゲームでは、`invite_users()` メソッドを使用し、Xbox Live ユーザー ID によって定義された一連のユーザーに招待を送信することもできます。 これは、ストック Xbox UI の代わりに独自のゲーム内 UI を使用する場合に役立ちます。

**例:**

```cpp
auto result = mpInstance->lobby_session()->invite_friends(xboxLiveContext);
if (result.err())
{
  // handle error
}
```

**Multiplayer Manager によって実行される機能**

* Xbox ストックのタイトルが呼び出せる UI (TCUI) を表示する
* 選択されたプレイヤーに直接、招待を送信する

### <a name="4-accept-invites-a-nameaccept-invites"></a>4) 招待を受け入れる <a name="accept-invites">

| メソッド | トリガーされるイベント |
| -----|----------------|
| `multiplayer_manager::join_lobby(Windows::ApplicationModel::Activation::IProtocolActivatedEventArgs^ args)` | `join_lobby_completed_event` |
| `multiplayer_lobby_session::set_local_member_connection_address()` | `local_member_connection_address_write_completed ` |
| `multiplayer_lobby_session::set_local_member_properties()` | `member_property_changed` |

招待されたプレイヤーがゲームの招待を受け入れると、またはシェル UI でフレンドのゲームに参加すると、プロトコルのアクティブ化を使用してデバイスでゲームが起動されます。 ゲームが開始したら、Multiplayer Manager はプロトコルがアクティブ化されたイベント引数を使用してロビーに参加できます。 lobby_session()::add_local_user() を通してローカル ユーザーを追加していない場合は、必要に応じて、join_lobby() API によってユーザーのリストに渡すことができます。 招待されたユーザーが lobby_session()::add_local_user() または join_lobby() によって追加されない場合、join_lobby() は失敗し、join_lobby_completed_event_args() の一部として招待が送信された invited_xbox_user_id が提供されます。

ロビーに参加した後は、ローカル メンバーの接続アドレスに加えて、メンバーのカスタム プロパティを設定することをお勧めします。 また、set_synchronized_host を使用してホストを設定することもできます (存在しない場合)。

最後に、ゲームが既に進行中であり、招待されたユーザーを受け入れる余裕がある場合、Multiplayer Manager はユーザーをゲーム セッションに自動的に参加させます。 タイトルには、適切なエラー コードとメッセージを提供する join_game_completed イベントによって通知されます。

**例:**

```cpp
auto result = mpInstance().join_lobby(IProtocolActivatedEventArgs^ args);
if (result.err())
{
  // handle error
}

string_t connectionAddress = L"1.1.1.1";
mpInstance->lobby_session()->set_local_member_connection_address(
    xboxLiveContext->user(), connectionAddress);
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

### <a name="5-join-a-game-session-from-the-lobby-a-namejoin-game"></a>5) ロビーからゲーム セッションに参加する <a name="join-game">

| メソッド | トリガーされるイベント |
|-----|----------------|
| `multiplayer_manager::join_game_from_lobby()` | `join_game_completed_event` |

招待が受け入れられて、ホストがゲームのプレイを開始できる状態になったら、`join_game_from_lobby()` を呼び出すことによってロビー セッションのメンバーを含む新しいゲームを開始できます。

**例:**

```cpp
auto result = mpInstance.join_game_from_lobby();
if (result.err())
{
  // handle error
}
```

エラー/成功は `join_game_completed` イベントを介して処理されます。

**Multiplayer Manager によって実行される機能**

* ゲーム セッションを作成する
 * すべてのローカル プレイヤーをアクティブとして参加させる
 * SDA をアップロードする
 * メンバーのプロパティを設定する
* セッション変更イベントに登録する
* ロビー セッションを介してゲームを公開する
