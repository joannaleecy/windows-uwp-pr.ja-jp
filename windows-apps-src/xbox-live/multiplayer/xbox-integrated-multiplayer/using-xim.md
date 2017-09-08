---
title: "XIM の使用"
author: KevinAsgari
description: "ゲームに Xbox Integrated Multiplayer (XIM) を実装する方法について説明します。"
ms.assetid: f5a2c68b-b1f9-4533-9282-41c31eab2487
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, Xbox One, Xbox Integrated Multiplayer"
ms.openlocfilehash: 09c33d8b7c92ee8c17631de340ab0c2cb4e1c9da
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="using-xim"></a>XIM の使用

XIM の使用に関する概要を紹介します。トピックの内容は次のとおりです。

1. [前提条件](#prereq)
2. [初期化および起動](#init)
3. [非同期操作および状態変更の処理](#async)
4. [xim_player の基本的な処理](#player)
5. [フレンド参加の有効化とフレンドの招待](#invites)
6. [メッセージの送信と受信](#send)
7. [マッチメイキングの概要および別の XIM ネットワークへの移動](#basicmatch)
8. [XIM ネットワークの退出およびクリーンアップ](#leave)
9. [チャットの操作](#chat)
10. [カスタム プレイヤーおよびネットワーク プロパティの設定](#properties)
11. [プレーヤーごとのスキルまたはロールによるマッチメイキング](#roles)
12. [プレーヤーのチームおよびチャット ターゲットの設定](#teams)
13. [プレイヤー スロットの自動バックグラウンド設定 ("バックフィル" マッチメイキング)](#backfill)
14. [サーバーのロール、"ホスト移行"、XIM 権限](#authority)

## <a name="prerequisites-a-nameprereq"></a>前提条件<a name="prereq">

XIM のコーディングを始めるには、2 つの前提条件があります。 まず、標準のマルチプレイヤー ネットワーキング機能を使用してアプリの AppXManifest を設定し、その "ネットワーク マニフェスト" を構成して、XIM で使用するのに必要なトラフィック パターン テンプレートを宣言する必要があります。

> AppXManifest 機能およびネットワーク マニフェストについては、プラットフォームのドキュメントの各セクションで詳しく説明されています。また、貼り付ける XIM 固有の XML は、「[XIM プロジェクト構成](xim-manifest.md)」で確認できます。

次に、割り当て済みの Xbox Live タイトル ID と、サービス構成 ID の 2 つのアプリケーション ID 情報を使用できるようにする必要があります。これらは、Xbox Live サービスにアクセスするためにアプリケーションのプロビジョニングの一部として提供されます。 これらの取得に関する詳細については、マイクロソフトの担当者にお問い合わせください。 これらの情報は、初期化時に使用されます。

XIM をコンパイルするには、プライマリ ヘッダー XboxIntegratedMultiplayer.h を含める必要があります。 適切にリンクするには、プロジェクト内の 1 つ以上のコンパイル ユニットにも XboxIntegratedMultiplayerImpl.h を含める必要があります (スタブ関数実装は小さく、コンパイラーで "インライン" として生成しやすいため、一般的なプリコンパイル済みヘッダーをお勧めします)。

XIM インターフェイスでは、プロジェクトのコンパイルにおいて、C++/CX と従来の C++ のいずれかを選択する必要がなく、どちらも使用できます。 また、この実装では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。

## <a name="initialization-and-startup-a-nameinit"></a>初期化および起動 <a name="init">

ライブラリーの操作を開始するには、Xbox Live サービス構成 ID の文字列とタイトル ID 番号を使用して XIM オブジェクト シングルトンを初期化します。 Xbox Services API も使用している場合は、これらを `xbox::services::xbox_live_app_config` から取得すると便利な場合があります。 次の例では、これらの値はそれぞれ "myServiceConfigurationId" および "myTitleId" 変数に既に存在するものと想定しています。

```cpp
xim::singleton_instance().initialize(myServiceConfigurationId, myTitleId);
```

初期化した後は、参加するローカル デバイスに現在存在しているすべてのユーザーの Xbox ユーザー ID 文字列をアプリで取得し、`xim::set_intended_local_xbox_user_ids()` の呼び出しに渡す必要があります。 次のサンプル コードでは、1 人のユーザーがコントローラーのボタンを押してプレイする意図を示し、そのユーザーに関連付けられた Xbox ユーザー ID 文字列は "myXuid" 変数に既に取得されているものとします。

```cpp
xim::singleton_instance().set_intended_local_xbox_user_ids(1, &myXuid);
```

`xim::set_intended_local_xbox_user_ids()` を呼び出すとすぐに、XIM ネットワークに追加する必要のあるローカル ユーザーに関連付けられている Xbox ユーザー ID が設定されます。 この Xbox ユーザー ID のリストは、`xim::set_intended_local_xbox_user_ids()` の別の呼び出しによってリストが変更されるまで、以降のすべてのネットワーク操作で使用されます。

この例では、XIM ネットワークはまだ存在していないため、XIM ネットワークへの移動を開始してプロセスを開始する必要があります。 ユーザーが特定の XIM ネットワークをまだ想定していない場合のベスト プラクティスは、単に、新しい空のネットワークに移動することです。そのネットワークは、ユーザーのフレンドの参加を許可することで、次のマルチプレイヤー アクティビティ (一緒にマッチメイキングに入る、など) を共同で選択できる一種の "ロビー" になります。 次に、以前に追加したローカル ユーザーのみが最大で 8 プレイヤーが参加できる空の XIM ネットワークに移動を開始する例を示します。

```cpp
xim::singleton_instance().move_to_new_network(8, xim_players_to_move::bring_only_local_players);
```
非同期の移動操作が開始し、最終的な結果は状態変化を定期的に処理することで確認できます。

## <a name="asynchronous-operations-and-processing-state-changes-a-nameasync"></a>非同期操作および状態変更の処理 <a name="async">

XIM の中核的な動作は、アプリによる `xim::start_processing_state_changes()` メソッドと `xim::finish_processing_state_changes()` メソッドの定期的かつ頻繁な呼び出しです。 これらのメソッドを使用して、XIM はアプリがマルチプレイヤーの状態の更新を処理する準備ができた通知を受け取り、更新を提供します。 これらのメソッドは、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。 XIM API は、このシングル スレッド パターン用に実際に最適化されています。 これら 2 つの関数の外部では状態が変化しないことが保証されているため、直接的かつ効率的に使用できます。

同じ理由から、XIM API によって返されるオブジェクトがすべてスレッドセーフであるとは見なさないでください**。 ライブラリには内部的なマルチスレッド保護機能がありますが、別のスレッドが `xim::start_processing_state_changes()` または `xim::finish_processing_state_changes()` を呼び出してそのプレイヤー リストに関連付けられているメモリーを変更している可能性がある間に、あるスレッドで任意の値にアクセスする必要がある場合は (たとえば、`xim::players()` リストの処理)、独自のロック処理を実装する必要があります。

`xim::start_processing_state_changes()` を呼び出すと、キューに入っているすべての更新が `xim_state_change` 構造体ポインターの配列で報告されます。 アプリでは、配列を反復処理し、より具体的な型の基本構造を検査して、基本的な構造体の型を対応する詳細な型にキャストしてから、その更新を適切に処理する必要があります。 現在使用可能なすべての `xim_state_change` 構造体が終了した後は、`xim::finish_processing_state_changes()` を呼び出すことによってその配列を XIM に戻してリソースを解放する必要があります。 次に、例を示します。

```cpp
uint32_t stateChangeCount;
xim_state_change_array stateChanges;
xim::singleton_instance().start_processing_state_changes(&stateChangeCount, &stateChanges);
for (uint32_t stateChangeIndex = 0; stateChangeIndex < stateChangeCount; stateChangeIndex++)
{
   const xim_state_change * stateChange = stateChanges[stateChangeIndex];
   switch (stateChange->state_change_type)
   {
       case xim_state_change_type::player_joined:
       {
           MyHandlePlayerJoined(static_cast<const xim_player_joined_state_change*>(stateChange));
           break;
        }

       case xim_state_change_type::player_left:
       {
           MyHandlePlayerLeft(static_cast<const xim_player_left_state_change*>(stateChange));
           break;
       }

       ...
    }
 }
 xim::singleton_instance().finish_processing_state_changes(stateChanges);
```

これで基本的な処理ループができたので、`xim::move_to_new_network()` の初期操作に関連する状態変化を処理できます。 すべての XIM ネットワーク移動操作は、`xim_move_to_network_starting_state_change` で開始します。 何らかの理由で移動が失敗した場合、アプリは `xim_network_exited_state_change` を受け取ります。これは、タイトルが XIM ネットワークに移動しないようにする、または現在の XIM ネットワークからタイトルを切断する、非同期重大エラーに対する共通のエラー処理メカニズムです。 移動が成功した場合は、すべての状態が終了され、すべてのプレイヤーが XIM ネットワークに正常に追加された後、移動は `xim_move_to_network_succeeded_state_change` で完了します。

## <a name="basic-ximplayer-handling-a-nameplayer"></a>xim_player の基本的な処理 <a name="player">

1 人のローカル ユーザーを新しい XIM ネットワークに移動する例が成功したとすると、アプリはローカル `xim_player` オブジェクトの `xim_player_joined_state_change` も提供されています。 プレイヤー インスタンス自体が有効である限り、このオブジェクト ポインターは有効であり、対応する `xim_player_left_state_change` が提供され `xim::finish_processing_state_changes()` を介して返されるまで、有効な状態が維持されます。 アプリはすべての `xim_player_left_state_change` に対して常に `xim_player_joined_state_change` を提供されます。 `xim::get_players()` を使用することで、いつでも XIM ネットワークのすべての `xim_player` オブジェクトの配列を取得することもできます。

`xim_player` オブジェクトには、多くの役に立つメソッドがあります。たとえば、`xim_player::gamertag()` は、プレイヤーに関連付けられている現在の Xbox Live ゲーマータグ文字列を表示用に取得します。 `xim_player` がデバイスに対してローカルである場合は、ローカル プレイヤーだけが使用できるメソッドである `xim_player::local()` から null ではない `xim_player::xim_local` オブジェクトのポインターも報告します。

もちろん、プレイヤーにとって最も重要な状態は XIM が知っている共通の情報ではなく、特定のアプリで追跡する必要のある情報であり、それに対しては独自のオブジェクトがある可能性があるため、`xim_player` オブジェクトをそれにリンクして、XIM が `xim_player` を報告するときはいつでも、カスタム プレイヤー コンテキスト ポインターを設定して検索を実行することなく状態をすばやく取得できます。 次の例では、プライベート状態に対するポインターは変数 "myPlayerStateObject" 内にあり、新しく追加される `xim_player` オブジェクトは変数 "newXimPlayer" 内にあるものとします。

```cpp
newXimPlayer->set_custom_player_context(myPlayerStateObject);
```

これは、指定されたポインター値をプレイヤー オブジェクトでローカルに保存します (メモリーが有効でないときにリモート デバイスにネットワーク経由で転送されることはありません)。 その後は、カスタム コンテキストを取得して、次の例のようにオブジェクトにキャストすることによって、いつでもオブジェクトに戻ることができます。

```cpp
myPlayerStateObject = reinterpret_cast<MyPlayerState *>(newXimPlayer->custom_player_context());
```

このカスタム プレイヤー コンテキスト ポインターはいつでも変更できます。

この基本プレイヤー処理により、ローカル ユーザーとの既存のソーシャル関係を通してリモート ユーザーがこの XIM ネットワークに参加できるようにすることができます。

## <a name="enabling-friends-to-join-and-inviting-thema-nameinvites"></a>フレンド参加の有効化とフレンドの招待<a name="invites">

プライバシーとセキュリティのため、すべての新しい XIM ネットワークは既定では追加プレイヤーが参加できないように自動的に構成されるので、アプリ側で明示的に許可する必要があります。 次の例では、xim::set_allowed_player_joins() を使用して、プレイヤーとして参加する新しいローカル ユーザー、および招待されている、または "フォロー" されている (Xbox Live ソーシャル関係) ユーザーの許可を開始する方法を示します。

```cpp
xim::singleton_instance().set_allowed_player_joins(xim_allowed_player_joins::local_invited_or_followed);
```

これは非同期的に発生します。 完了すると、`xim_allowed_player_joins_changed_state_change` が提供され、値が既定値の `xim_allowed_player_joins::none` から変化したことが通知されます。 新しい値は、`xim::allowed_player_joins()` を使用して照会できます。

ローカル プレイヤーはこの XIM ネットワークに参加するようリモート ユーザーに招待を送信できるようになります。 これは、`xim_player::xim_local::show_invite_ui()` を呼び出してシステム招待 UI を起動してローカル ユーザーにユーザーを選択して招待を送信できるようにすることによって実現されます。 このことは、次の例で示されています。変数 'ximPlayer' は有効なローカル `xim_player` を指しているものとします。

```cpp
ximPlayer->local()->show_invite_ui();
```

システム招待 UI が表示され、ユーザーが招待を送信すると (またはそれ以外で UI を閉じると)、`xim_show_invite_ui_completed_state_change` が提供されます。 または、アプリは `xim_player::xim_local::invite_users()` を使って招待を直接送信できます。 どちらの方法でも、リモート ユーザーはサインインしている場所で Xbox Live 招待メッセージを受け取り、受け入れることができます。 これにより、まだ実行していない場合はデバイスでアプリが起動され、同じ XIM ネットワークに移動するために使用できるイベント引数で "プロトコルのアクティブ化" を行います。 アクティブ化自体について詳しくは、プラットフォームのドキュメントをご覧ください。 次の例では、イベント引数を取得し、`xim::extract_protocol_activation_information()` を呼び出して XIM に適用可能かどうかを確認する方法を示します。未処理の URI 文字列を `Windows::ApplicationModel::Activation::ProtocolActivatedEventArgs` から変数 "uriString" に既に取得してあるものとします。

```cpp
xim_protocol_activation_information activationInfo;
bool isXimActivation;
isXimActivation = xim::singleton_instance().extract_protocol_activation_information(uriString, &activationInfo);

```

XIM のアクティブ化の場合、設定された `xim_protocol_activation_information` 構造体の "local_xbox_user_id" フィールドで示されているローカル ユーザーがサインインしていて、`xim::set_intended_local_xbox_user_ids()` に指定されているユーザーに含まれることを確認する必要があります。 その後、同じ URI 文字列を使用して `xim::move_to_network_using_protocol_activated_event_args()` を呼び出すことで、指定された XIM ネットワークへの移動を開始できます。 次に、例を示します。

```cpp
xim::singleton_instance().move_to_network_using_protocol_activated_event_args(uriString);
```

"フォローされている" リモート ユーザーはシステム UI でローカル ユーザーのプレイヤー カードに移動し、招待なしに自分だけで参加の試みを開始できることにも注意してください (前に示したように、そのようなプレイヤーの参加を許可してあるものとします)。 アプリでは招待の場合と同じようにプロトコルのアクティブ化が行され、異なる処理は必要ありません。

プロトコルのアクティブ化を使用した XIM ネットワークへの移動は、前述の手順で行った新しい XIM ネットワークへの移動と同じです。 唯一の違いは、移動が成功すると、移動中のデバイスによって、適用可能なプレイヤーを表すローカルとリモート両方のプレイヤーに `xim_player_joined_state_change` 構造体が送信されることです。 また当然、既に XIM ネットワークに存在していたデバイスが移動することはありませんが、`xim_player_joined_state_change` 構造体がさらに送信されると、新しいデバイスのユーザーがプレイヤーとして追加されます。


この時点で、音声通信およびテキスト チャット通信は、この XIM ネットワーク内の各デバイスのプレイヤー間で自動的に有効になっています。 これで、マルチプレイヤーおよび送信するアプリ固有メッセージの準備が整います。

## <a name="sending-and-receiving-messages-a-namesend"></a>メッセージの送信と受信 <a name="send">

XIM とその基になっているコンポーネントによって、インターネット経由で手間をかけずに安全な通信チャネルを確立することができるため、接続の問題や、一部のプレイヤーが受信できない可能性があることを心配する必要はありません。 ピア ツー ピア接続の基盤に問題がある場合、XIM ネットワークへの移動は成功しません。 問題がなければ、すべての `xim_player` が、すべてのデバイスのアプリのすべてのインスタンスに通知され、どのデバイスにもメッセージを送信できるようになります。 次の例では、"sendingPlayer" 変数は有効なローカル プレイヤー オブジェクトへのポインターであり、(特定のプレイヤーの配列を渡さないことで) XIM ネットワークのすべてのプレイヤー (ローカルまたはリモート) に、保証されたシーケンシャル配信でメッセージ構造体 "msgData" を送信するものとします。

```cpp
sendingPlayer->local()->send_data_to_other_players(sizeof(msgData), &msgData, 0, nullptr, xim_send_type::guaranteed_and_sequential);
```

メッセージのすべての受信者には、データのコピーへのポインターおよびメッセージを送信してローカルに受信する対応する xim_player オブジェクトへのポインターを含む xim_player_to_player_data_received_state_change が提供されます。

もちろん保証されたシーケンシャル配信は便利ですが、インターネットでパケットがドロップされたりパケットの順序が正しくない場合は XIM は再送信または遅延する必要があるため、効率的ではない送信タイプでもあります。 アプリがパケットのドロップや順序の間違いを許容できるメッセージに対しては他の送信タイプの使用を検討してください。

メッセージ データはリモート コンピューターから送られてくるので、データ形式を明確に定義し (特定のバイト オーダー ("エンディアン") でマルチバイト値をパッキングするなど)、処理する前にデータを検証するのがベスト プラクティスです。 XIM はネットワーク レベルのセキュリティを提供しているため、暗号化や署名スキームを追加実装することはできませんが、アプリケーションのバグから保護したり、異なるバージョンのアプリケーション プロトコルに共存できるように、堅牢な "多重防御" を行うことは常に有益です (開発時や、コンテンツ更新時など)。

ユーザーのインターネット接続も、常に変わり続ける限られたリソースです。 必ず、有益なメッセージ データ形式を使用し、すべての UI フレームを送信するような設計にしないでください。 2 人のプレイヤー間における現在のパスの品質の詳細は、`xim_player::network_path_information()` メソッドを呼び出して確認できます。 以下の例では、`xim_network_path_information` 構造体のポインターを取得し、'remotePlayer' 変数に含まれる `xim_player` ポインターを操作します。

```cpp
 const xim_network_path_information * networkPathInfo = remotePlayer->network_path_information();
```

返される構造体には、予想される往復遅延時間に加え、接続上の理由から現時点で追加データを送信できないためにローカルのキューに入ったままのメッセージ数が含まれます。 キューがバックアップ中であると表示される場合は、データの送信速度を抑える必要があります。

## <a name="basic-matchmaking-and-moving-to-another-xim-network-with-others-a-namebasicmatch"></a>マッチメイキングの概要および別の XIM ネットワークへの移動 <a name="basicmatch">

フレンドのグループのゲーム体験を拡張するには、Xbox Live マッチメイキング サービスを使用して、共通の関心に基づき、世界中の対戦相手がいる XIM ネットワークにプレイヤーを移動します。 最も基本的な方法は、データの設定された `xim_matchmaking_configuration` 構造体を使用して、いずれかのデバイスで `xim::move_to_network_using_matchmaking()` を呼び出し、現在の XIM ネットワークからプレイヤーを移動することです。 以下の例では、no-teams free-for-all 用に合計 8 人のプレイヤーを探すように構成されたマッチメイキング (8 人見つからない場合は、2 ～ 7 人でも許容可能) を使用して移動を開始します。このとき、MYGAMEMODE_DEATHMATCH の値 (この値は、同一値を指定した他のプレイヤーのみと一致します) で定義されるアプリ固有のゲームモード定数 uint64_t を使用し、ソーシャルな方法で参加したすべてのプレイヤーを現在の XIM ネットワークから移動します。

```cpp
xim_matchmaking_configuration matchmakingConfiguration = { 0 };
matchmakingConfiguration.team_matchmaking_mode = xim_team_matchmaking_mode::no_teams_8_players_minimum_2;
matchmakingConfiguration.custom_game_mode = MYGAMEMODE_DEATHMATCH;

xim::singleton_instance().move_to_network_using_matchmaking(matchmakingConfiguration, xim_players_to_move::bring_existing_social_players);
```

前述の移動のように、これにより、すべてのデバイスに最初の `xim_move_to_network_starting_state_change` が送信され、成功すると、`xim_move_to_network_succeeded_state_change` が送信されます。 この場合は XIM ネットワーク間で移動するため、ローカルユーザーおよびリモートユーザー向けに追加された既存の `xim_player` オブジェクトが存在している点が異なり、このオブジェクトはすべてのプレイヤーを新しい XIM ネットワークにまとめて移動するために保持されます。 マッチメイキングの進行中 (`xim::move_to_network_using_matchmaking()` とも呼ばれるマッチメイキング プールのプレイヤー数によって時間がかかる場合がある)、このネットワーク間のチャットおよびデータ通信は、中断されることなく引き続き使用できます。 ユーザーに現在のステータスを通知し続けるために、`xim_matchmaking_progress_updated_state_change` は、この操作が終わるまで定期的に送信されます。 一致すると、一般的な `xim_player_joined_state_change` を使用してユーザーが XIM ネットワークに追加され、移動は完了します。

この "マッチメイキング型" プレイヤーのセットを使用したマルチプレイヤー体験が完了すると、他のマッチメイキングのラウンドを使用して他の XIM ネットワークに移動することができるこのプロセスを繰り返せるようになります。 `xim::move_to_network_using_matchmaking()` 操作を介して参加した各プレイヤーによって、同 XIM ネットワーク内に `xim_player` オブジェクトが存在しないことを表す `xim_player_left_state_change` が送信されます。また、新しいマッチメイキングが行われている間、ソーシャル機能 `xim::move_to_network_using_protocol_activated_event_args()` または `xim::move_to_network_using_joinable_xbox_user_id()` を介して参加したプレイヤーのみ残ります  (再度 `xim_players_to_move::bring_existing_social_players` を指定した場合。`xim_players_to_move::bring_only_local_players` を指定した場合はリモート プレイヤーからも切断され、ローカル プレイヤーのみが残ります)。 2 回目の移動操作が完了すると、別の見知らぬユーザーの集合が追加されます。

または、マッチメイキング型でないプレイヤー (またはローカル プレイヤー) のみ新しい XIM ネットワークに完全に移動してから、次のマッチメイキング構成/マルチプレイヤー アクティビティを決めることができます。 次の例では、XIM ネットワークに最大 8 人のプレイヤーを集めるために、再度デバイスの呼び出し `xim::move_to_new_network()` を行います。ただし、今回はソーシャル機能を使用して参加した既存プレイヤーも移動します。

```cpp
xim::singleton_instance().move_to_new_network(8, xim_players_to_move::bring_existing_social_players);
```

参加中のすべてのデバイスに、`xim_move_to_network_starting_state_change` および `xim_move_to_network_succeeded_state_change` が送信され、加えてマッチメイキング型の残ったプレイヤーには `xim_player_left_state_change` が送信されます (同様に、移動中の各プレイヤーのデバイスにも、`xim_player_left_state_change` が送信されます)。

この方法で、必要な回数だけマッチメイキングを使用して (または使用せずに)、引き続き XIM ネットワーク間で移動できます。

パフォーマンス上、Xbox Live サービスは、直接ピア ツー ピア接続を確立できないデバイス上でプレイヤーのグループのマッチングを試行することはありません。 標準の Xbox Live マルチプレイヤーをサポートするように適切に構成されていないネットワーク環境で開発している場合は、マッチメイキング条件に適合するプレイヤーが十分に存在しており、全員が同じローカル環境にあるデバイスを使用してこの環境内で移動することが確かでも、マッチングに成功することなく `xim::move_to_network_using_matchmaking()` 操作がいつまでも続くことがあります。 必ずネットワーク設定領域/Xbox アプリケーションでマルチプレイヤーの接続テストを実行し、特に "Strict NAT" についての問題を報告する場合の推奨事項に従ってください。 ただし、ネットワーク管理者が環境に必要な変更を行うことができない場合は、Xbox One 開発キットでテストのブロックを解除できます。そのためには、"Open NAT" デバイスを 一切指定せずに "ストリクト NAT" デバイスをマッチングできるように XIM を構成します。 これを行うには、すべての Xbox One 本体上の "title scratch" ドライブのルートに "xim_disable_matchmaking_nat_rule" と呼ばれるファイル (内容は問いません) を配置します。 配置する方法のひとつとして、アプリを起動する前に XDK コマンド プロンプトから以下を実行し、プレースホルダー "{console_name_or_ip_address}" を適宜各コンソールに置き換える方法があります。

```bat

echo.>%TEMP%\emptyfile.txt
copy %TEMP%\emptyfile.txt \\{console_name_or_ip_address}\TitleScratch\xim_disable_matchmaking_nat_rule
del %TEMP%\emptyfile.txt

```

この開発上の回避策は、現在 Xbox One 排他リソース アプリケーションでのみ使用することができ、ユニバーサル Windows アプリで使用することはできません。 また、コンソールでこの設定を使用している場合は、ネットワーク環境にかかわらず、ファイルが存在しないデバイスにマッチングすることはないため、ファイルは、あらゆる場所で追加または削除することができます。

## <a name="leaving-a-xim-network-and-cleaning-up-a-nameleave"></a>XIM ネットワークの退出およびクリーンアップ <a name="leave">

ローカル ユーザーが XIM ネットワークに参加している場合、新しい XIM ネットワークに戻るだけで、ローカル ユーザー、招待ユーザー、"フォローされている" ユーザーはその XIM ネットワークに参加できるため、引き続きフレンドと協力して次のアクティビティーに進むことができます。 しかし、ユーザーがマルチプレイヤー経験の大半を終えている場合、アプリは、XIM ネットワークの退出を開始し、`xim::initialize()` および `xim::set_intended_local_xbox_user_ids()` が呼び出されたかのように、その状態に戻る場合があります。 この処理を実行するには、`xim::leave_network()` メソッドを使います。

```cpp
xim::singleton_instance().leave_network();
```

このメソッドでは、他の参加者から非同期的に切断するプロセスを正常に開始します。 これにより、リモート デバイスに対してローカル プレーヤーの `xim_player_left_state_change`、ローカルデバイスに対してローカルまたはリモートの各プレーヤーの `xim_player_left_state_change` が送られます。 すべての接続操作が完了すると、最後に `xim_network_exited_state_change` が送信されます。 その後、アプリで `xim::cleanup()` を呼び出してリソースをすべて解放し、未初期化状態に戻すことができます。

```cpp
xim::singleton_instance().cleanup();
```

`xim_network_exited_state_change` がまだ送信されていない場合は、`xim::leave_network()` を呼び出し、`xim_network_exited_state_change` を待機して、XIM ネットワークを正常終了することを強くお勧めします。 `xim::cleanup()` を直接呼び出すと、残りの参加者が "消えた" デバイスに送ったメッセージがタイムアウトするのを待機している間、通信パフォーマンスの問題を引き起こす可能性があります。

## <a name="working-with-chat-a-namechat"></a>チャットの操作 <a name="chat">

XIM ネットワーク内のプレイヤー間の音声およびテキスト チャット通信は、自動的に有効になります。 XIM は、すべての音声ヘッドセットとマイクのハードウェアとの通信を操作します。 チャットを使用するために必要な設定はアプリにありませんが、テキスト チャットに関する要件が 1 つあります。入力および表示をサポートしていることです。 テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、プレイヤーはこのシステムで、音声合成の支援技術を使用する場合があるためです。 同様に、プレイヤーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。 ローカル プレーヤーがこれらの設定を検出できるようにするには、`xim_player::xim_local::chat_text_to_speech_conversion_preference_enabled()` および `xim_player::xim_local::chat_speech_to_text_conversion_preference_enabled()` メソッドをそれぞれ呼び出します。必要に応じて、テキストのメカニズムを有効にすることもできます。 ただし、テキスト入力および表示オプションを常に有効にすることを検討してください。


> `Windows::Xbox::UI::Accessability` は、テキストから音声の変換支援技術を搭載したゲーム内のテキストチャットを単純にレンダリングできるように特別に設計された Xbox One のクラスです。

現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `xim_player::xim_local::send_chat_text()` メソッドに渡します。 以下のコードは、'localPlayer' 変数によって指定されたローカルの `xim_player` オブジェクトからハード コードされたサンプル文字列の送信を示します。

```cpp
localPlayer->local()->send_chat_text(L"Example chat text");
```

このチャット テキストは、発信元のローカル プレイヤーからチャット通信を受信できる、XIM ネットワーク内のすべてのプレイヤーに送信されます。 また、音声に合成され、`xim_chat_text_received_state_change` として送信されることもあります。 アプリは、受け取ったテキスト文字列のコピーを作成し、発信元プレイヤーの ID の一部と共に、適切な長さの時間 (またはスクロール可能なウインドウで) 表示する必要があります。

チャットに関するベスト プラクティスは他にもいくつかあります。 特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。 これを行うには、`xim_player::chat_indicator()` を呼び出し、プレイヤーのチャットの現在の瞬間的なステータスを表す `xim_player_chat_indicator` を取得します。 次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'ximPlayer' 変数で指定した `xim_player` オブジェクトのインジケーター値の取得を示します。

```cpp
switch (ximPlayer->chat_indicator())
{
   case xim_player_chat_indicator::silent:
   {
       iconToShow = Icon_InactiveSpeaker;
       break;
   }

   case xim_player_chat_indicator::talking:
   {
       iconToShow = Icon_ActiveSpeaker;
       break;
   }

   case xim_player_chat_indicator::muted:
   {
       iconToShow = Icon_MutedSpeaker;
       break;
   }
   ...
}
```

`xim_player::chat_indicator()` によって報告される値は、プレイヤーの発声開始から終了までを頻繁に変更することを想定しています。 そのため、すべての UI フレームをポーリングできるように設計されています。

もう 1 つのベスト プラクティスは、プレイヤーをミュートできるようにすることです。 XIM では、ユーザーはプレイヤー カードを使用してシステムを自動的にミュートできますが、`xim_player::set_chat_muted()` メソッドを経由してゲーム UI 内で実行されるゲーム固有の一時的なミュートをアプリでもサポートしている必要があります。 以下の例では、'remotePlayer 変数でリモートの `xim_player` オブジェクトを指定し、ミュートを開始します。これにより、ボイス チャットが聞こえず、テキスト チャットを受け取らない状態になります。

```cpp
remotePlayer->set_chat_muted(true);
```

ミュートは、すぐに適用され、`xim_state_change` とは関連付けられません。 取り消すには、false 値を指定して `xim_player::set_chat_muted()` を再度呼び出します。 以下の例では、'remotePlayer' 変数によって指定されているリモートの `xim_player` オブジェクトのミュートを解除します。

```cpp
remotePlayer->set_chat_muted(false);
```

そのプレイヤーで新しい XIM ネットワークに移動する場合など、`xim_player` が存在している限り、ミュート設定は引き続き有効です。 プレーヤーが退出し、同じユーザーが (新しい `xim_player` インスタンスとして) 再参加する場合は、保持されません。

プレイヤーは、通常、ミュートを解除した状態で開始します。 ゲームプレイ上の理由から、ミュートした状態でプレイヤーを開始する場合は、該当する `xim_player_joined_state_change` の処理を終了する前に、`xim_player` オブジェクトの `xim_player::set_chat_muted()` を呼び出します。これにより、XIM では、無期限にプレイヤーから音声オーディオが聞こえなくなります。

リモート プレーヤーが XIM ネットワークに参加すると、プレイヤーの評判に基づいて、自動ミュート チェックが行われます。 プレイヤーに不適切な評判のフラグがある場合、プレイヤーは自動的にミュートされます。 ミュートは、ローカル状態にのみ影響を及ぼすため、プレイヤーがネットワーク間を移動する場合は変更されません。 評判ベースの自動ミュート チェックは 1 度のみ行われ、`xim_player` が有効である限り、再評価されることはありません。


## <a name="configuring-custom-player-and-network-properties-a-nameproperties"></a>カスタム プレイヤーおよびネットワーク プロパティの設定 <a name="properties">

メソッドの受信者や、そのメソッドでパケットの損失などを処理する日時や方法を大部分コントロールできるため、ほとんどのアプリにおいて、データ交換には `xim_player::xim_local::send_data_to_other_players()` メソッドが使用されます。 ただし、プレイヤーにとっては、基本的でまれな変更ステータスを最小限の手間で他者と共有した方が好都合である場合があります。 たとえば、すべてのプレイヤーがゲーム内の表現をレンダリングするために使用するマルチプレイヤーを入力する前に選択したキャラクター モデルを表す文字列は、各プレイヤーによって変更される場合があります。 XIM では、便利な "カスタム プレイヤー プロパティ" 機能が提供されています。この機能では、アプリ定義の名前と値による NULL 終了の文字列ペアをローカル プレイヤーに適用し、これらが変更されると自動的にすべてのデバイスに伝達できます。 XIM ネットワークに参加し、追加したプレイヤーが表示されると、現在の値も自動的に、新しく追加したデバイスに適用されます。 これらを設定するには、'localPlayer' 変数によって指定されるローカルの `xim_player` オブジェクトに値 "brute" を含めるように "model" という名前のプロパティを設定し、名前と値の文字列を使用して、`xim_player::xim_local::set_player_custom_property()` を呼び出します。

```cpp
localPlayer->local()->set_player_custom_property(L"model", L"brute");
```

プレイヤーのプロパティを変更すると、`xim_player_custom_properties_changed_state_change` がすべてのデバイスに送信され、変更されているプロパティの名前に警告が通知されます。 指定された名前の値は、`xim_player::get_player_custom_property()` を使用して、ローカルまたはリモートで、どのプレイヤーも取得することができます。 以下の例は、'ximPlayer' 変数で指定された `xim_player` から、"model" という名前のプロパティの値を取得しています。

```cpp
PCWSTR modelName = ximPlayer->get_player_custom_property(L"model");
```

指定のプロパティ名に新しい値を設定すると、既存の値は置き換えられ、null 値の文字列ポインターは、空の値文字列と同様に処理されます。つまり、まだ指定されていないプロパティと同様です。 それ以外の場合、名前および値は、XIM で解釈されません。必要に応じて文字列の内容を検証するアプリによって異なります。

この便利な機能は、"カスタム ネットワーク プロパティ" を使用して、XIM ネットワーク全体で使用することもできます。 `xim::set_network_custom_property()` を使用して XIM シングルトン オブジェクトで設定されている場合を除き、カスタム ネットワーク プロパティと同様に使用できます。 以下の例では、値が "stronghold" になるように "map" プロパティを設定しています。

```cpp
xim::singleton_instance().set_network_custom_property(L"map", L"stronghold");
```

ネットワークのプロパティを変更すると、`xim_network_custom_properties_changed_state_change` がすべてのデバイスに送信され、変更されているプロパティの名前に警告が通知されます。 指定した名前の値は、以下の例で "map" というプロパティの値を取得しているように、`xim::get_network_custom_property()` を使用して取得できます。

```cpp
PCWSTR mapName = xim::singleton_instance().get_network_custom_property(L"map");
```
カスタム プレーヤーのプロパティと同じように、指定されたカスタム ネットワーク プロパティ名の値を設定すると、既存の値に置き換えられ、null 値、未設定値、またはクリアされた値は、常に非 null の空の文字列として処理されます。

ある XIM ネットワークから別の XIM ネットワークに移動すると、カスタム プレイヤー プロパティはリセットされ、新しく作成された XIM ネットワークは、常にプロパティが設定されていない状態で開始されます。 ただし、既存の XIM ネットワークに参加する新しいプレイヤーには、既存のプレイヤーおよび XIM ネットワーク自体に設定されているカスタム プロパティが表示されます。

プレイヤーおよびネットワークのカスタム プロパティは、頻繁に変化しない状態を補助するために使用します。 これらの内部的な同期オーバーヘッドは `xim_player::xim_local::send_data_to_other_players()` メソッドより大きくなるため、プレーヤーの位置が高速で入れ替わるような状態では、直接送信を使用する必要があります。

## <a name="matchmaking-using-per-player-skill-or-role-a-nameroles"></a>プレーヤーごとのスキルまたはロールによるマッチメイキング <a name="roles">

固有のアプリ指定のゲーム モードの共通の関心を使用したプレイヤーのマッチングは、優れた基本戦略です。 利用可能なプレイヤーのプールが大きくなるにつれて、ベテラン プレイヤーが、他のベテランと正当な対戦を楽しめるように、ゲームの個人スキル、または体験に基づいて、マッチプレイヤーを考慮する必要がありますが、新しいプレイヤーは、同様の能力の他者と対戦することで、レベルを上げることができます。 これを行うにはまず、マッチメイキングを使用して XIM ネットワークに移動する前に、`xim_player::xim_local::set_matchmaking_configuration()` の呼び出しで指定されるプレイヤーごとのマッチメイキング設定構造体で、すべてのローカル プレイヤーにスキル レベルを提供します。 スキル レベルはアプリ固有の概念であり、数が XIM で解釈されることはありません。例外として、マッチメイキングでまず同一のスキル値を持つプレイヤーを探してから、定期的に +/- 10 単位で検索対象の増減を行い、そのスキル範囲内でスキル値を宣言する他のプレイヤーを探すことができます。 以下の例では、ローカルの `xim_player` オブジェクトを想定しています。このオブジェクトのポインターは 'localPlayer' であり、ローカルまたは Xbox Live のストレージから 'playerSkillValue' と呼ばれる変数に対して取得されたアプリ固有のスキル値 uint32_t が格納されます。

```cpp

 xim_player_matchmaking_configuration playerMatchmakingConfiguration = { 0 };
 playerMatchmakingConfiguration.skill = playerSkillValue;

 localPlayer->local()->set_matchmaking_configuration(&playerMatchmakingConfiguration);
```

これが完了すると、この `xim_player` によってプレイヤーごとのマッチメイキング設定が変更されたことを示す `xim_player_matchmaking_configuration_changed_state_change` が、すべての参加者に送信されます。 新しい値を取得するには、`xim_player::matchmaking_configuration()` を呼び出します。

すべてのプレイヤーに null 以外のマッチメイキング設定が適用されたら、`xim::move_to_network_using_matchmaking()` に指定された `xim_matchmaking_configuration` 構造体の require_player_matchmaking_configuration フィールドに true 値を指定してマッチメイキングを使用することで XIM に移動できます。 以下の例では、no-teams free-for-all 用に 合計 2 ～ 8 人のプレイヤーを探すマッチメイキング構成を追加します。このとき、MYGAMEMODE_DEATHMATCH の値で定義されるアプリ固有のゲーム モード定数である uint64_t を使用します。この値は、同一値を指定した他のプレイヤーのみと一致し、使用するにはプレイヤーごとのマッチメイキング構成が必要になります。

```cpp
xim_matchmaking_configuration matchmakingConfiguration = { 0 };
matchmakingConfiguration.team_matchmaking_mode = xim_team_matchmaking_mode::no_teams_8_players_minimum_2;
matchmakingConfiguration.custom_game_mode = MYGAMEMODE_DEATHMATCH;
matchmakingConfiguration.require_player_matchmaking_configuration = true;
```

この構造体が `xim::move_to_network_using_matchmaking()` に送信されると、移動するプレイヤーによって、null 以外の `xim_player_matchmaking_configuration` ポインターを使用して `xim_player::xim_local::set_matchmaking_configuration()` が呼び出されている限り、この移動操作は正常に開始されます。 これが行われていないプレイヤーがいる場合、マッチメイキング処理は一時停止され、`xim_matchmaking_status::waiting_for_player_matchmaking_configuration` 値が指定された `xim_matchmaking_progress_updated_state_change` がすべての参加者に送信されます。 これには、マッチメイキングが完了する前に、事前に送信された招待または他のソーシャルな手段 (`xim::move_to_network_using_joinable_xbox_user_id` の呼び出しなど) で、XIM ネットワークに途中参加したプレイヤーも含まれます。 すべてのプレイヤーが `xim_player_matchmaking_configuration` 構造体を送信した時点で、マッチメイキングが再開されます。

プレイヤーごとのマッチメイキング設定を使用してユーザーのマッチメイキング体験を高める方法には、必要なプレイヤー ロールを使用する方法があります。 これは、さまざまな協力型プレイ スタイルを提案するキャラクター タイプを選択できるゲームに最も適しています。つまり、ゲーム内のグラフィカル表現をただ変更するのではなく、防御型 "ヒーラー" に対して近距離型の "メレー" 攻撃や遠距離型の "レンジ" 攻撃のサポートなど、補完的で影響の強い属性を制御するようなものを指します。 ユーザーのパーソナリティは、専門分野としてプレイする場合があるということを意味します。 しかし、各ロールを満たす者が存在せずに、機能的に目的を完了させることができないようにゲームが設計されている場合は、任意のプレイヤーをまとめてマッチングさせるよりもそのようなプレイヤーをまとめてマッチングさせ、集まった時点でプレイヤー間でプレイ スタイルを検討する方が望ましい場合があります。 これを行うには、指定のプレイヤーの `xim_player_matchmaking_configuration` 構造体で指定される各ロールを表す一意のビット フラグを最初に定義します。 以下の例では、ローカルの `xim_player` オブジェクトに対して、アプリ固有のロール値である MYROLEBITFLAG_HEALER uint8_t を設定します。このポインターは、'localPlayer' になります。

```cpp

xim_player_matchmaking_configuration playerMatchmakingConfiguration = { 0 };
playerMatchmakingConfiguration.roles = MYROLEBITFLAG_HEALER;

localPlayer->local()->set_matchmaking_configuration(&playerMatchmakingConfiguration);

```

上記のスキルで示されたとおり、このプレイヤーに対する `xim_player_matchmaking_configuration_changed_state_change` がすべての参加者に送信されます。 `xim::move_to_network_using_matchmaking()` に指定されたグローバル構造体 `xim_matchmaking_configuration` には、ビットごとの OR を使用して結合されたすべての必要なロール フラグや、require_player_matchmaking_configuration フィールドに対する true 値が含まれます。 以下の例では、no-teams free-for-all 用に合計 3 人のプレイヤーを探すマッチメイキング構成を追加します。このとき、MYGAMEMODE_COOPERATIVE の値で定義されるアプリ固有のゲーム モード定数 uint64_t を使用します。この値は、同一値を指定した他のプレイヤーのみと一致します。プレイヤーごとにマッチメイキング構成が設定され、アプリ固有の uint8_t の 3 つのロール ビット フラグ MYROLEBITFLAG_HEALER、MYROLEBITFLAG_MELEE、MYROLEBITFLAG_RANGE がそれぞれ 1 人以上のプレイヤーに割り当てられている必要があります。

```cpp
xim_matchmaking_configuration matchmakingConfiguration = { 0 };
matchmakingConfiguration.team_matchmaking_mode = xim_team_matchmaking_mode::no_teams_3_players_minimum_3;
matchmakingConfiguration.custom_game_mode = MYGAMEMODE_COOPERATIVE;
matchmakingConfiguration.required_roles = MYROLEBITFLAG_HEALER | MYROLEBITFLAG_MELEE | MYROLEBITFLAG_RANGE;
matchmakingConfiguration.require_player_matchmaking_configuration = true;
```

この構造体が `xim::move_to_network_using_matchmaking()` に送信されると、上記のように移動操作が開始されます。

スキルとロールは、同時に使用することができます。 いずれかのみ指定する場合は、他の構造体に値 0 を指定します。 これは、`xim_player_matchmaking_configuration` スキル値が 0 であると宣言しているすべてのプレイヤーが常に互いに一致するためであり、`xim_matchmaking_configuration` の required_roles フィールドにゼロ以外のビットが存在しない場合は、一致させるためのロール ビットは必要ありません。

`xim::move_to_network_using_matchmaking()` や、その他すべての XIM ネットワークの移動操作が完了すると、すべてのプレイヤーの `xim_player_matchmaking_configuration` 構造体は、自動的に null ポインターにクリアされます (付随して `xim_player_matchmaking_configuration_changed_state_change` 通知が送信されます)。 プレイヤーごとの設定が必要なマッチメイキングを使用して、別の XIM ネットワークに移動する場合、常に最新の情報を含む新しい構造体のポインターで、再度 `xim_player::xim_local::set_matchmaking_configuration()` を呼び出します。


## <a name="player-teams-and-configuring-chat-targets-a-nameteams"></a>プレーヤーのチームおよびチャット ターゲットの設定 <a name="teams">

マルチプレイヤーのゲームでは、プレイヤーを相手チームに組み込むことも必要になります。 XIM では、指定の設定で 2 つ以上のチームを要求する `xim_team_matchmaking_mode` 値を使用してマッチメイキングを行う際にチームを割り当てやすくなります。 以下の例では、2 チーム 4 人ずつ (4 人見つからない場合は 1 ～ 3 人でも許容可能) の合計 8 人のプレイヤーを探すように構成されたマッチメイキングを使用して移動を開始します。このとき、MYGAMEMODE_CAPTURETHEFLAG の値 (この値は、同一値を指定した他のプレイヤーのみと一致します) によって定義されるアプリ固有のゲーム モード定数 uint64_t を使用し、ソーシャルな方法で参加したすべてのプレイヤーを現在の XIM ネットワークから移動します。

```cpp
xim_matchmaking_configuration matchmakingConfiguration = { 0 };
matchmakingConfiguration.team_matchmaking_mode = two_teams_4v4_minimum_1_per_team;
matchmakingConfiguration.custom_game_mode = MYGAMEMODE_CAPTURETHEFLAG;

xim::singleton_instance().move_to_network_using_matchmaking(matchmakingConfiguration, xim_players_to_move::bring_existing_social_players);
```

このような XIM ネットワークの移動操作が完了すると、リクエストされたチーム数に対応して、プレイヤーに 1 から {n} のチーム インデックス値が割り当てられます。 プレイヤーのチーム インデックスの値は、`xim_player::team_index()` を使用して取得されます。 以下の例では、ポインターが 'ximPlayer' 変数にある xim_player オブジェクトのチーム インデックスを取得します。

```cpp
uint8_t playerTeamIndex = ximPlayer->team_index();
```

Xbox Live のマッチメイキング サービスでは、(プレイヤーによる否定的な行動の機会を制限するだけではなく) 望ましいユーザー エクスペリエンスを実現するために、一緒に XIM ネットワークに移動する複数のプレイヤーが別々のチームに分割されることはありません。

マッチメイキングによって最初に割り当てられているチームのインデックス値は単なる推奨値であり、アプリではいつでも `xim_player::xim_local::set_team_index()` を使用してローカル プレイヤーの値を変更できます。 これは、マッチメイキングを一切使用していない XIM ネットワークで呼び出すこともできます。 以下の例では、新しいチーム インデックス値として 1 が設定されるように、プレイヤーのポインター 'localPlayer' を構成します。

```cpp
localPlayer->local()->set_team_index(1);
```

プレイヤーに新しいチーム インデックス値が設定された場合、すべてのデバイスは、プレイヤーの `xim_player_team_index_changed_state_change` を受信することで通知されます。

2 つ以上のチームで `xim_team_matchmaking_mode` を使用している場合、`xim::move_to_network_using_matchmaking()` の呼び出しで、プレイヤーにチームインデックス値 0 が割り当てられることはありません。 これは、他の構成や種類の移動操作 (招待の承認によるプロトコルのアクティブ化など) で XIM ネットワークに追加されるプレイヤーと対照的です。これらのプレイヤーには、常にチーム インデックス値 0 が割り当てられます。 インデックス 0 のチームを特別な "未割り当て" チームとして扱うと便利な場合があります。

特定のチーム インデックス値の本当の意味は、アプリごとに設定できます。 チャット ターゲット構成の同等比較に使用する場合を除き、XIM によるチーム インデックス値の解釈は行われません。 `xim::chat_targets()` で報告されたチャット ターゲット構成が現在 `xim_chat_targets::same_team_index_only` であれば、プレイヤーが相手とチャット通信を行うのは、`xim_player::team_index()` で報告された同一値が両者に設定されている (加えて、プライバシー/ポリシーで許可される) 場合のみです。

競争力のあるシナリオを堅実にサポートするために、新しく作成された XIM ネットワークは既定値が `xim_chat_targets::same_team_index_only` になるように自動的に構成されます。 ただし、対戦後の "ロビー" などで、負けた相手チームとのチャットが望まれることもあります。 プライバシーやポリシーで許可されていれば、すべてのユーザーがほかのすべてのユーザーと対話できるように XIM を設定するには、`xim::set_chat_targets()` を呼び出します。 以下のサンプルでは、`xim_chat_targets::all_players` 値が使用されるように、XIM ネットワーク内のすべての参加者を設定します。

```cpp
xim::singleton_instance().set_chat_targets(xim_chat_targets::all_players);
```

新しいターゲット設定が有効になった場合、すべての参加者は、`xim_chat_targets_changed_state_change` を受信することで通知されます。

前述のように、XIM ネットワークのほとんどの移動タイプで、最初はインデックス値 0 がすべてのプレイヤーに割り当てられます。 これは、既定では `xim_chat_targets::same_team_index_only` の設定を `xim_chat_targets::all_players` と区別できない可能性が高いことを意味します。 ただし、マッチメイキング構成の `xim_team_matchmaking_mode` 値で 2 つ以上のチームが宣言されている場合、マッチメイキングを使用して XIM ネットワークに移動するプレイヤーには異なるチーム インデックス値が設定されます。 また、`xim_player::xim_local::set_team_index()` は、上記のようにいつでも呼び出すことができます。 アプリでこれらのメソッドのいずれかを使用して、0 以外のチーム インデックス値を使用している場合は、必ずチャットのターゲット設定を適切に管理してください。

マッチメイキングでは、チームとは別に各プレイヤーに必要なロールが評価されます。 チームはプレイヤーに割り当てられたロールではなくプレイヤーの数で調整されるため、マッチメイキング構成条件として、チームと必要なロールの両方を同時に使用することはお勧めできません。

## <a name="automatic-background-filling-of-player-slots-backfill-matchmaking-a-namebackfill"></a>プレイヤー スロットの自動バックグラウンド設定 ("バックフィル" マッチメイキング) <a name="backfill">

異なるプレイヤー グループが同時に `xim::move_to_network_using_matchmaking()` を呼び出すことで、Xbox Live マッチメイキング サービスで新しく最適な XIM ネットワークをすばやく構成するための柔軟性が最大になります。 ただし、ゲームプレイ シナリオによっては、特定の XIM ネットワークが変更されない状態で維持する必要があり、追加プレイヤーのマッチメイキングが行われるのは空いているプレイヤー スロットを満たす場合のみというケースもあります。 XIM では、`xim::set_backfill_matchmaking_configuration()` メソッドを使用して自動バックグラウンド設定モードで動作するマッチメイキングの構成 ("バックフィリング") もサポートされます。 以下の例では、バックフィル マッチメイキングを構成して、no-teams free-for-all 用に合計 8 人のプレイヤーを探します (8 人見つからない場合は、2 ～ 7 人でも許容可能)。このとき、MYGAMEMODE_DEATHMATCH の値 (この値は、同一値を指定した他のプレイヤーのみと一致します) で定義されるアプリ固有のゲーム モード定数 uint64_t を使用します。

```cpp
 xim_matchmaking_configuration matchmakingConfiguration = { 0 };
 matchmakingConfiguration.team_matchmaking_mode = xim_team_matchmaking_mode::no_teams_8_players_minimum_2;
 matchmakingConfiguration.custom_game_mode = MYGAMEMODE_DEATHMATCH;

 xim::singleton_instance().set_backfill_matchmaking_configuration(&matchmakingConfiguration);
```

これにより、通常の方法で `xim::move_to_network_using_matchmaking()` を呼び出すデバイスが既存の XIM ネットワークを利用できるようになります。 これらのデバイスでは、動作の変更がありません。 バックフィリング中の XIM ネットワークにいる参加者は移動できませんが、これらの参加者には、バックフィルが有効になったことを表す <`xim_backfill_matchmaking_configuration_changed_state_change` や複数の `xim_matchmaking_progress_updated_state_change` 通知 (該当する場合) が送信されます。 マッチメイキングで見つかったプレイヤーは、通常の `xim_player_joined_state_change` を使用して XIM ネットワークに追加されます。

バックフィル マッチメイキングは無期限に進行状態になります (XIM ネットワークで既に最大プレイヤー数が `xim_team_matchmaking_mode` 値で指定されている場合はプレイヤーが追加されることはありません)。 バックフィルは、null ポインターで `xim::set_backfill_matchmaking_configuration()` を再度呼び出して無効にすることができます。

```cpp
 xim::singleton_instance().set_backfill_matchmaking_configuration(nullptr);
```

対応する `xim_backfill_matchmaking_configuration_changed_state_change` がすべてのデバイスに送信され、この非同期処理が完了すると、マッチメイキングされたプレイヤーがこれ以上 XIM ネットワークに追加されないことを表す `xim_matchmaking_status::none` で最終的な `xim_matchmaking_progress_updated_state_change` が送信されます。

2 つ以上のチームを宣言する `xim_team_matchmaking_mode` を使用してバックフィル マッチメイキングを有効にする場合、既存のすべてのプレイヤーに有効なチームインデックス値 (1 ～チーム数) が必要になります。 これには、`xim_player::xim_local::set_team_index()` を呼び出してカスタム値を指定したプレイヤーや、招待または他のソーシャルな手段 (例: `xim::move_to_network_using_joinable_xbox_user_id` の呼び出し) によって参加して既定のインデックス値 0 が追加されたプレイヤーも含まれます。 有効なチームインデックス値を持つプレイヤーがいない場合、マッチメイキング処理は保留され、`xim_matchmaking_status::waiting_for_player_team_index` 値が指定された `xim_matchmaking_progress_updated_state_change` がすべての参加者に送信されます。 すべてのプレイヤーについて、`xim_player::xim_local::set_team_index()` でチーム インデックス値が指定または修正されると、バックフィル マッチメイキングが再開されます。

同様に、require_player_matchmaking_configuration フィールドでロールまたはスキルが true に設定されている `xim_matchmaking_configuration` 構造体を使用してバックフィル マッチメイキングを有効にする場合、すべてのプレイヤーについて、プレイヤーごとのマッチメイキング構成が null 以外に指定されている必要があります。 これが行われていないプレイヤーがいる場合、マッチメイキング処理は一時停止され、`xim_matchmaking_status::waiting_for_player_matchmaking_configuration` 値が指定された `xim_matchmaking_progress_updated_state_change` がすべての参加者に送信されます。 すべてのプレイヤーが `xim_player_matchmaking_configuration` 構造体を送信した時点で、バックフィル マッチメイキングが再開されます。

## <a name="the-role-of-servers-host-migration-and-xim-authorities-a-nameauthority"></a>サーバーのロール、"ホスト移行"、XIM 権限<a name="authority">

XIM ネットワークは、クライアント/サーバー モデルなどではなく、完全に接続されたピア メッシュのデバイスです。 プレイヤーは、API を通じて他のプレイヤーに直接送信することができます。xim::set_network_custom_property()、xim::set_allowed_player_joins()、xim::set_chat_targets() など、XIM ネットワーク全体の状態に影響を及ぼすメソッドはすべて、参加中のデバイスから呼び出すことができます。 複数の参加者によって同一の XIM ネットワーク状態を同時に変更できないようにアプリ側で設定されていない場合、XIM は、last-write-wins のシンプルな競合解決を使用します。 つまり、XIM では、"サーバー" または "ホスト" というロールの概念が強制されません。 また、独自の概念 (および XIM ネットワーク退出時に他の参加者にロールを移行する関連プロセス ("ホスト移行" とも呼ばれる)) を定義するアプリが制限されることもありません。

一部のアプリにとって、ゲームのホストは、全く単純なソーシャル構造です。 フレンドが参加できるようにユーザーがマルチプレイヤー体験を開始すると、そのユーザーは、グループ全体の代わりに、現在のゲームプレイ ルール、マップなどの設定を管理します。 他のアプリにとっては、基本的な通信ルールという表現が適しています。 これによって、別々のプレイヤーによって生成されたゲームの状態が競合しても簡単に解決できます (たとえば、リアルタイム入力を優先することで、どちらのプレイヤーの状態が有効になるかが決まるなど)。 プレイヤーが自由なタイミングで参加および退出する状況で (ネットワーク エラーによる場合も含めて)、単一デバイスで途切れることのないユーザー エクスペリエンスを維持して安定性を確保し、信頼性の高いゲーム状態を管理することは難しい場合があります。このため XIM は、アプリを支援するオプションの `xim_authority` オブジェクトを使用して設計されています。

XIM オーソリティは、ネットワークの最高品質、安定性、プレイヤーの評判などの動的な要素に基づいて自動的に選択された XIM ネットワーク内の単一デバイスを表します。 XIM ネットワーク内の参加者はすべて、以下の例のように `xim_authority::is_local()` を照会することで、この役割が現在ローカル デバイスに割り当てられているかどうかを判断することができます。

```cpp
 bool authorityIsLocal = xim::singleton_instance().authority()->is_local();
```

どのプレイヤー グループが照会しても、xim_authority がローカルであると報告するのは、XIM ネットワーク内の単一デバイスのみです。 アプリにおけるオーソリティ固有の動作 (例: 短い待機時間、または他からのパケット移動が悪意をもってブロックされている場合は常にローカル シミュレーションに従う) が悪用される可能性を抑えるために、どのデバイスがオーソリティになるかを憶測したり、そのようなデバイスをユーザーに示したりしないでください。

今後のソフトウェア リリースでは、アプリは `xim_player::xim_local::send_data_to_authority()` メソッドを使用して `xim_authority` を対象とするメッセージを直接送信し、そこからのメッセージを直接受け取ることができるようになります。 XIM では、移行プロセス中にも `xim_state_change` 通知とデータ バッファー交換が提供されるようになります。 ただし、このソフトウェア リリースでは、これらの機能は用意されていません。 `xim_authority::is_local()` 以外のすべての `xim_authority` メソッドと `xim_player::xim_local::send_data_to_authority()` メソッドは実装されていないため、呼び出すと例外がスローされます。 xim_authority に関するご質問は、マイクロソフトの担当者にお問い合わせください。
