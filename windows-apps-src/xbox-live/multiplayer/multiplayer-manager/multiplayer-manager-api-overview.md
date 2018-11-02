---
title: Multiplayer Manager API の概要
author: KevinAsgari
description: Xbox Live Multiplayer Manager API について説明します。
ms.assetid: 658babf5-d43e-4f5d-a5c5-18c08fe69a66
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, Multiplayer Manager
ms.localizationpriority: medium
ms.openlocfilehash: 142a09bca9c33aa53a4e034c08bb405ac7b75fce
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5937987"
---
# <a name="multiplayer-manager-api-overview"></a>Multiplayer Manager API の概要

このページでは、Multiplayer Manager API の概要とゲームでの使用方法について説明します。 API 内で特に重要なクラスとメソッドも紹介します。 詳細な API 情報については、リファレンス ドキュメントを参照してください。 アプリケーションでのこれらの API の使用例については、Multiplayer サンプルを参照してください。

## <a name="namespace"></a>名前空間
Multiplayer Manager クラスは、次に示す名前空間に含まれています。

| 言語 | 名前空間 |
| --- | --- |
| C++/CX | Microsoft::Xbox::Services::Multiplayer::Manager |
| C++ | xbox::services::multiplayer::manager |

以下の一覧は、理解しておく必要のある主なクラスです。

* [Multiplayer Manager クラス](#multiplayer-manager-class)
* [Multiplayer Event クラス](#multiplayer-event-class)
* [Multiplayer Member クラス](#multiplayer-member-class)
* [Multiplayer Lobby Session クラス](#multiplayer-lobby-session-class)
* [Multiplayer Game Session クラス](#multiplayer-game-session-class)

## <a name="multiplayer-manager-class-a-namemultiplayer-manager-class"></a>Multiplayer Manager クラス <a name="multiplayer-manager-class">

| 言語 | クラス |
| --- | --- |
| C++/CX | MultiplayerManager |
| C++ | multiplayer_manager |

このクラスは Multiplayer Manager と対話するためのプライマリ クラスです。 シングルトン クラスであるため、1 回だけクラスの作成と初期化を行う必要があります。
このクラスには、1 つのロビー セッション オブジェクトと 1 つのゲーム セッション オブジェクトが含まれます。

Multiplayer Manager が機能するためには、少なくとも、このクラスの `initialize()` メソッドと `do_work()` メソッドを呼び出す必要があります。

以下の表で、すべてではありませんが、このクラスの特によく使用されるメソッドとプロパティについて説明します。 説明を含む、クラス メンバーの完全な一覧については、リファレンスを参照してください。

| C++/CX | C++ | 説明 |
| --- | --- | --- |
| **メソッド** | | |
| Initialize() | initialize() | Multiplayer Manager を初期化します。 このメソッドは Multiplayer Manager を使用する前に呼び出す必要があります。 |
| DoWork() | do_work() | アプリのセッションの表示状態を更新します。 このメソッドはフレームごとに少なくとも 1 回呼び出す必要があり、ゲームでは、メソッドから返されたマルチプレイヤー イベントを処理する必要があります。 |
| JoinLobby() | join_lobby() | 参加するロビーを一意に識別するハンドル ID を使用して、またはユーザーが招待を受け入れることによってタイトルがプロトコルをアクティブ化するときに、フレンドのロビー セッションに参加する手段を提供します。 |
| JoinGameFromLobby() | join_game_from_lobby() | ロビーのゲーム セッションが存在し、空きがある場合は、それに参加します。 セッションが存在しない場合は、既存のロビー メンバーを使用して新しいゲーム セッションを作成します。 既存のロビー セッションのプロパティはゲーム セッションに移行されません。 参加後は、`game_session()::set_synchronized_*` API によってプロパティやホストを設定できます。 タイトルは、ゲーム セッションへの参加を望むすべてのクライアントで、この API を呼び出す必要があります。|
| JoinGame() | join_game() | 通常はサードパーティーのマッチメイキング サービスによって見つかるグローバルに一意なセッション名を指定して、既存のゲーム セッションに参加します。 ゲームに参加させる Xbox ユーザー ID のリストを渡すことができます。|
| FindMatch() | find_match() | Xbox Live マッチメイキングを使用してゲームを見つけ、参加します。 |
| LeaveGame() | leave_game() | ゲームから退出し、メンバーとすべてのローカル メンバーをロビーに返します。 |
| **プロパティ** | | |
| LobbySession | lobby_session() | ロビー セッションを表すオブジェクトへのハンドル。 |
| GameSession |  game_session() | ゲーム セッションを表すオブジェクトへのハンドル。 |

## <a name="multiplayer-event-class-a-namemultiplayer-event-class"></a>Multiplayer Event クラス <a name="multiplayer-event-class">

| 言語 | クラス |
| --- | --- |
| C++/CX | MultiplayerEvent |
| C++ | multiplayer_event |

`do_work()` を呼び出すと、Multiplayer Manager は、最後の `do_work()` 呼び出し以降のセッションに対する変更を表すイベントのリストを返します。 これらのイベントには、セッションへのメンバーの参加、セッションからのメンバーの退出、メンバーのプロパティの変更、ホスト クライアントの変更などの変更が含まれます。

発生し得るすべてのイベントの種類の一覧については、`multiplayer_event_type` 列挙型をご覧ください。

返されるそれぞれの `multiplayer_event` には、`event_args` が含まれます。これは、そのイベントの種類に対して適切な event_args クラスにキャストする必要があります。 たとえば、`event_type` が `member_joined` である場合は、`event_args` 参照を `member_joined_event_args` クラスにキャストします。

ゲームでは、`do_work()` の呼び出し後、必要に応じて各イベントを処理する必要があります。

## <a name="multiplayer-member-class-a-namemultiplayer-member-class"></a>Multiplayer Member クラス <a name="multiplayer-member-class">

| 言語 | クラス |
| --- | --- |
| C++/CX | MultiplayerMember |
| C++ | multiplayer_member |

このクラスは、ロビー セッションまたはゲーム セッション内のプレイヤーを表します。 クラスには、プレイヤーの XboxUserID、プレイヤーのネットワーク接続アドレス、各プレイヤーのカスタム プロパティなどを含め、メンバーに関するプロパティが含まれます。

## <a name="multiplayer-lobby-session-class-a-namemultiplayer-lobby-session-class"></a>Multiplayer Lobby Session クラス <a name="multiplayer-lobby-session-class">

| 言語 | クラス |
| --- | --- |
| C++/CX | MultiplayerLobbySession |
| C++ | multiplayer_lobby_session |

このデバイスに対してローカルなユーザーと、ゲームに招待したフレンドを管理するために使用する永続的なセッションです。 Multiplayer Manager が何らかのマルチプレイヤー操作を行うためには、ロビー セッションに少なくとも 1 人のメンバーが含まれている必要があります。 `add_local_user()` メソッドを呼び出すことで、最初に新しいロビー セッションを作成できます。

以下の表で、すべてではありませんが、このクラスの特によく使用されるメソッドとプロパティについて説明します。 説明を含む、クラス メンバーの完全な一覧については、リファレンスを参照してください。

| C++/CX | C++ | 説明 |
| --- | --- | --- |
| **メソッド** | | |
| AddLocalUser() | add_local_user() | ロビー セッションにローカル ユーザー (ローカル デバイスでサインインしたプレイヤー) を追加します。 これがロビー セッションに追加される最初のメンバーである場合、新しいロビー セッションが作成されます。 |
| RemoveLocalUser() | remove_local_user() | ロビーとゲーム セッションから、指定されたメンバーを削除します。 |
| InviteFriends() | invite_friends() | プレイヤーがフレンド リストからユーザーを選択できる標準の Xbox Live UI を開き、それらのプレイヤーをゲームに招待します。 |
| InviteUsers() | invite_users() | 指定された Xbox Live ユーザーをゲームに招待します。 |
| SetLocalMemberConnectionAddress() | set_local_member_connection_address() | ローカル メンバーのネットワーク アドレスを設定します。 ゲームはこのネットワーク アドレスを使用して、メンバー間のネットワーク通信を確立できます。 |
| SetLocalMemberProperties() | set_local_member_properties() | ローカル メンバーのカスタム プロパティを設定します。 このプロパティは JSON 文字列で保存されます。 |
| DeleteLocalMemberProperties() | delete_local_member_properties() | ローカル メンバーのカスタム プロパティを削除します。 |
| SetProperties() / SetSynchronizedProperties() | set_properties() / set_synchronized_properties() | ロビー セッションのカスタム プロパティを設定します。 このプロパティは JSON 文字列で保存されます。 プロパティがデバイス間で共有され、複数のデバイスによって同時に更新される場合は、同期されるバージョンのメソッドを使用します。 |
| IsHost() | is_host() | 現在のデバイスがロビー ホストとして動作しているかどうかを示します。 |
| SetSynchronizedHost() | set_synchronized_host() | ロビーのホストを設定します。 |
| **プロパティ** | | |
| LocalMembers | local_members() | ローカル デバイスにサインインしているメンバーのコレクション。 |
| Members | members() | ロビー セッション内にいるメンバーのコレクション。 |
| Properties | properties() | ロビー セッションのプロパティのコレクションを表す JSON オブジェクト。 |
| Host | host() | ロビーのホスト メンバー。 |


## <a name="multiplayer-game-session-class-a-namemultiplayer-game-session-class"></a>Multiplayer Game Session クラス <a name="multiplayer-game-session-class">

| 言語 | クラス |
| --- | --- |
| C++/CX | MultiplayerGameSession |
| C++ | multiplayer_game_session |

ゲーム セッションは、実際のゲームプレイのインスタンスに参加している Xbox Live メンバーのグループを表します。 これには、マッチメイキング サービスによってマッチメイキングされたプレイヤーが含まれます。

`lobby_session` のメンバーを含む新しいゲーム セッションを開始する場合は、`multiplayer_manager::join_game_from_lobby()` を呼び出すことができます。 Xbox Live マッチメイキングを使用する場合は、`multiplayer_manager::find_match()` を呼び出すことができます。 サードパーティーのマッチメイキング サービスを使用する場合は、`multiplayer_manager::join_game()` を呼び出すことができます。

以下の表で、すべてではありませんが、このクラスの特によく使用されるメソッドとプロパティについて説明します。 説明を含む、クラス メンバーの完全な一覧については、リファレンスを参照してください。

| C++/CX | C++ | 説明 |
| --- | --- | --- |
| **メソッド** | | |
| SetProperties() / SetSynchronizedProperties() | set_properties() / set_synchronized_properties() | ゲーム セッションのカスタム プロパティを設定します。 このプロパティは JSON 文字列で保存されます。 プロパティがデバイス間で共有され、複数のデバイスによって同時に更新される場合は、同期されるバージョンのメソッドを使用します。 |
| IsHost() | is_host() | 現在のデバイスがゲーム ホストとして動作しているかどうかを示します。 |
| SetSynchronizedHost() | set_synchronized_host() | ゲームのホストを設定します。 |
| **プロパティ** | | |
| Members | members() | ゲーム セッション内にいるメンバーのコレクション。 |
| Properties | properties() | ゲーム セッションのプロパティのコレクションを表す JSON オブジェクト。 |
| Host | host() | ゲームのホスト メンバー。 |
