---
title: XIM 帯域外予約
author: KevinAsgari
description: 帯域外予約を介した専用チャット ソリューションとして Xbox Integrated Multiplayer (XIM) を使用する方法について説明します。
ms.assetid: 0ed26d19-defb-414d-a414-c4877bd0ed37
ms.author: kevinasg
ms.date: 01/28/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Xbox Integrated Multiplayer, XIM, チャット
ms.localizationpriority: medium
ms.openlocfilehash: b5e67e75a981a6abc88b877983e544293055e90b
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5739629"
---
# <a name="using-xim-as-a-dedicated-chat-solution-via-out-of-band-reservations"></a>帯域外予約を介した専用チャット ソリューションとしての XIM の使用

ほとんどのアプリでは、プレイヤーが集まるあらゆる場面の処理に XIM を使います。 一般的なマルチプレイヤー シナリオ全体をサポートするために必要なすべての機能を集めていることが、"Xbox 統合マルチプレイヤー" と呼ばれる理由です。 ただし、専用のインターネット サーバーを使用して、独自のマルチプレイヤー ソリューションを実装している一部のアプリでも、信頼性の高い、待機時間の短い、コストの低いピア ツー ピア チャットの通信を利用できます。 XIM ではこのようなニーズを把握し、拡張モードをサポートしています。これを利用すると、XIM API 外で必要になる外部プレーヤー管理機能を補強する XIM のピア通信を簡素化できます。 ソーシャルの手段やマッチメイキングを通じた XIM ネットワークへの移動ではなく、プレイヤーが "予約" して移動します。予約は "帯域外" 通信で外部プレーヤーのランデブー メカニズムにより特定のユーザーに保証されたプレースホルダーです。

移行処理を除くと、帯域外予約を使用して管理される XIM ネットワークは実質的に、他の XIM ネットワークと同じです。 すべての通信機能は同様に動作します。 ただし、マッチメイキングとソーシャル探索 API メソッドは、帯域外予約を使用して管理する XIM ネットワークに対して無効にする必要があります。これは、アプリの外部の実装と競合する可能性があるためです。 たとえば、このような XIM ネットワークから招待を送信することはできません。

>単純なエンド ツー エンド ソリューションを提供できるように XIM は最適化されています。 そのため、すべての複雑なトポロジまたはシナリオに、帯域外の予約がうまく利用できるとは限りません。 XIM の通信機能を活用できるか、またはその方法について質問がある場合は、Microsoft の担当者にお問い合わせください。

以降のトピックでは、XIM で帯域外予約を活用する方法について説明します。 "標準的な" XIM の使用方法は前のセクションで説明されているものとほとんど変わりがないため、説明は一部省略されています。 詳しくは、「[XIM の使用](using-xim.md)」をご覧ください。

トピック:

1. [新しい帯域外予約による XIM ネットワークへの移行](#moving)
1. [帯域外予約を使用して管理される XIM ネットワークへのプレーヤーの追加](#adding)
1. [帯域外予約を使用して管理される XIM ネットワークでのチャット ターゲットの構成](#targets)
1. [帯域外予約を使用して管理される XIM ネットワークからのプレイヤーの削除](#remove)
1. [帯域外予約を使用して管理される XIM ネットワークのクリーンアップ](#clean)

## <a name="moving-to-a-new-out-of-band-reservation-xim-network"></a>新しい帯域外予約による XIM ネットワークへの移行 

帯域外予約の使用を開始するには、このモードで作成された新しい XIM ネットワークに、集まった参加者の 1 人を移動する必要があります。 参加しているピア デバイスはどれを選択してもかまいません。 このプロセスを開始するための自然な選択として、ゲーム ホストやサーバーの使用が考えられますが、これは必須ではありません。 接続セットアップの時間を最短にするために、"Open" ネットワーク アクセス タイプであるデバイスを選ぶことをお勧めします。 詳しくは、`Windows::Networking::XboxLive` プラットフォームのドキュメントをご覧ください。

帯域外予約を通じて管理されているネットワークへの移動は、XIM を初期化し、標準の XIM 使用のチュートリアルで示されているように、特定のローカル Xbox ユーザー ID を宣言することによって行われます。`xim::move_to_new_network()` のようなメソッドを呼び出すのではなく、`xim::move_to_network_using_out_of_band_reservation()` を予約文字列に null を設定して呼び出します。 次に、例を示します。

```cpp
 xim::singleton_instance().initialize(myServiceConfigurationId, myTitleId);
 xim::singleton_instance().set_intended_local_xbox_user_ids(1, &myXuid);
 xim::singleton_instance().move_to_network_using_out_of_band_reservation(nullptr);
```

標準的な `xim_move_to_network_starting_state_change`、`xim_player_joined_state_change`、および `xim_move_to_network_succeeded_state_change` は、通常の `xim::start_processing_state_changes()` と `xim::finish_processing_state_changes()` の間で状態変化を処理中に、時間の経過と共に提供されます。 次に、例を示します。

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
             MyHandlePlayerJoined(static_cast<const xim_player_joined_state_change *>(stateChange));
             break;
         }

         case xim_state_change_type::player_left:
         {
             MyHandlePlayerLeft(static_cast<const xim_player_left_state_change *>(stateChange));*
             break;
         }

         ...
     }
 }
 xim::singleton_instance().finish_processing_state_changes(stateChanges);
```

最初のデバイスが状態変更を処理し、プレイヤーを正常に XIM ネットワークに移動したあと、その他のユーザーの予約を作成する必要があります。

## <a name="adding-players-to-a-xim-network-managed-using-out-of-band-reservations"></a>帯域外予約を使用して管理される XIM ネットワークへのプレーヤーの追加 

帯域外予約を使用して管理される XIM ネットワークは、`xim::allowed_player_joins()` メソッドから常に `xim_allowed_player_joins::out_of_band_reservation` の値を、レポートします。`xim::create_out_of_band_reservation()` を呼び出すことによって Xbox ユーザー ID に対してスポットが予約されたプレイヤーを除く、すべてのプレイヤーに対して閉じられています。 `xim::create_out_of_band_reservation()`  は、ユーザーの配列を取得し、一度にまたは時間の経過と共に、集まった外部プレーヤーに、このような予約を作成できます。 また、XIM ネットワークに参加しているプレイヤーが既にあるユーザーは無視されるため、追加の Xbox ユーザー ID の完全な代替セットまたはデルタ変更 (便利な方) を提供することもできます。 次の例では、'xboxUserIdCount' 数値要素を持つ配列変数 'xboxUserIds' に Xbox ユーザー ID の文字列ポインターのセットがすべて揃っていることを前提にしています。

```cpp
 xim::singleton_instance().create_out_of_band_reservation(xboxUserIdCount, xboxUserIds);
```

これにより、指定された Xbox ユーザー ID に対して予約を作成するための非同期プロセスが開始されます。 操作が完了すると、XIM は成功または失敗を報告する `xim_create_out_of_band_reservation_completed_state_change` を生成します。 成功した場合、システムで予約文字列を使って、操作に提供される Xbox ユーザー ID を生成できるようになります。 正常に作成された予約文字列は、一定の時間のみ有効です。 その時間は `xim_create_out_of_band_reservation_completed_state_change` 内で返されます。

有効な予約文字列を使うと、XIM の外部でプレイヤーの収集に使用される "帯域外" 外部メカニズムを使って、文字列をそれらの列挙に分散できます。 たとえば、マルチプレイヤー セッション ディレクトリ (MPSD) の Xbox Live サービスを使っている場合、この文字列をセッション ドキュメント内のカスタム プロパティとして書き込めます (注: 予約文字列には、エスケープまたは Base64 エンコードなしで、JSON で安全に使えるように、限られた文字セットを使用)。

他のユーザーも、`xim::move_to_network_using_out_of_band_reservation()` に渡すパラメーターとして予約文字列を使用すると、XIM ネットワークへの移行を開始できます。 次の例では、予約文字列を 'reservationString' という変数に抽出したものと想定しています。

```cpp
xim::singleton_instance().move_to_network_using_out_of_band_reservation(reservationString);

```

null ポインターが予約文字列に指定されている最初のデバイスと同様に移動動作は非同期で実行されます。 移動により、状態変化 `xim_move_to_network_starting_state_change`、`xim_player_joined_state_change`、`xim_move_to_network_succeeded_state_change` が生成されます。 移動が成功した場合は、ローカルおよびリモートの両方のプレイヤーが追加されます。 XIM ネットワークの既存のネットワークでは、これらの新しいプレイヤーに対する `xim_player_joined_state_change` も提供されます。 この時点で、この XIM ネットワーク内の異なるデバイスのプレイヤー間で音声およびテキスト チャット通信が自動的に有効になります (プライバシーとポリシーで許容される場合)。

無効な予約文字列のために移動操作に失敗すると、XIM は理由 `xim_network_exit_reason::invalid_reservation` で `xim_network_exited_state_change` を返します。 この問題が発生するのには、いくつかの理由が考えられます。

1. タイトルは、ホスト デバイスで `xim_create_out_of_band_reservation_completed_state_change` が返される前にリモート デバイスで `xim::move_to_network_using_out_of_band_reservation()` を呼び出そうとします。
1. タイトルは、予約の期限が切れた後にリモート デバイスで `xim::move_to_network_using_out_of_band_reservation()` を呼び出そうとします。
1. タイトルは、リモート デバイスで `xim::move_to_network_using_out_of_band_reservation()` を複数回呼び出そうとしますが、`xim::create_out_of_band_reservation()` は 1 回だけ呼び出します。

成功か失敗に関係なく、予約はそれらを使う移動操作によって消費されます。 そのため、使用が試みられるたびに、ホストは `xim::create_out_of_band_reservation()` を再度呼び出すことで新しい予約文字列を生成する必要があります。

## <a name="configuring-chat-targets-in-a-xim-network-managed-using-out-of-band-reservations"></a>帯域外予約を使って管理される XIM ネットワークでのチャット ターゲットの構成

帯域外予約を使用して管理されている XIM ネットワークは、チャットのコミュニケーションに関して従来の XIM ネットワークと同様に動作します。 競争力のあるシナリオをサポートするために、新しく作成した XIM ネットワークが、同じチームのメンバーであるプレーヤーとのチャットだけをサポートするように自動的に構成されます。つまり、既定では、`xim::chat_targets()` で報告される構成値は `xim_chat_targets::same_team_index_only` です。 `xim::set_chat_targets()` を呼び出すことにより、どのユーザーも (プライバシーとポリシーで許容される範囲で) すべてのユーザーに話しかけられるように変更できます。 次の例の先頭では、XIM ネットワークですべてのユーザーが利用できるように `xim_chat_targets::all_players` 値を使用しています。

```cpp
xim::singleton_instance().set_chat_targets(xim_chat_targets::all_players);
```

すべての参加者に新しいターゲット設定が有効であると通知されるのは、`xim_chat_targets_changed_state_change` が提供されたときです。

帯域外予約を使用して管理される XIM ネットワーク内のすべてのプレイヤーが最初は同じチーム インデックス値、ゼロで構成されています。 つまり、`xim_chat_targets::same_team_index_only` の構成は、既定では `xim_chat_targets::all_players` と区別できません。 ただし、ローカル プレイヤーのチーム インデックスは、`xim_player::xim_local::set_team_index()` を呼び出していつでも変更できます。 以下の例では、新しいチーム インデックス値として 1 が設定されるように、プレイヤーのポインター 'localPlayer' を構成します。

```cpp
 localPlayer->local()->set_team_index(1);
```

プレイヤーに新しいチーム インデックス値が設定された場合、すべてのデバイスは、プレイヤーの xim_player_team_index_changed_state_change を受信することで通知されます。 現在のチャット ターゲットの構成が xim_chat_targets::same_team_index_only の場合は、その同じ新しいチーム インデックスを持つ他のプレーヤーに、(プライバシーとポリシーで許容される範囲で) 変更元プレーヤーからの音声とテキスト チャットが届き始めます (逆方向も同様)。 古いチーム インデックスを持つプレイヤーについては、このようなチャット コミュニケーションのやり取りが停止になります。 現在のチャット ターゲットの構成が xim_chat_targets::all_players の場合は、チーム インデックスは誰が誰とチャットできるかに影響しません。

## <a name="removing-players-from-a-xim-network-managed-using-out-of-band-reservations"></a>帯域外予約を使用して管理される XIM ネットワークからのプレイヤーの削除 

帯域外予約を使用するときは、プレイヤーの名簿を外部で管理するため、場合によってはプレイヤーを XIM ネットワークから削除する必要があります。 一般的な方法は、XIM ネットワークと予約を作成するために使用されたゲームのホストをアプリで活用して、プレーヤーの削除も管理することで、`xim::kick_player()` を呼び出して実行します。 これにより、指定されたプレーヤーと同じデバイス上のすべてのプレイヤーが XIM ネットワークから削除されます。 次の例は、アプリで、'playerToRemove' 変数で示される `xim_player` オブジェクトを削除することを前提にしています。

```cpp
xim::singleton_instance().kick_player(playerToRemove);
```

該当する (複数の) プレイヤー全員に必要な `xim_player_left_state_change` とネットワークから除外されていることを示す `xim_network_exited_state_change` が送られます。 代わりに、各プレイヤーが `xim::leave_network()` を呼び出しても、自身で同じようにネットワークから退出できます。

XIM のピア ツー ピア通信ではいつでも、環境の問題により XIM ネットワークからプレイヤーが退出したと見なされる可能性があることに注意してください。 "要求に基づかない" `xim_player_left_state_change` を処理し、XIM の状態と外部プレーヤー管理スキームとの矛盾を調整できるように、アプリ側で適切に準備する必要があります。

## <a name="cleaning-up-a-xim-network-managed-using-out-of-band-reservations"></a>帯域外予約を使用して管理される XIM ネットワークのクリーンアップ 

XIM からまだ除外されていないプレイヤーが、xim::initialize() と `xim::set_intended_local_xbox_user_ids()` だけが呼び出された状態に戻ることを希望する場合は、`xim::leave_network()` メソッドを使って開始できます。

```cpp
xim::singleton_instance().leave_network();
```

これにより、非同期的に他の参加者の切断が開始されます。 これにより、リモート デバイスに対してローカル プレーヤーの `xim_player_left_state_change`、ローカルデバイスに対してローカルまたはリモートの各プレーヤーの `xim_player_left_state_change` が送られます。 すべての切断処理が正常に完了したら、最終の `xim_network_exited_state_change` が提供されます。 その後、アプリで `xim::cleanup()` を呼び出してリソースをすべて解放し、未初期化状態に戻すことができます。

```cpp
 xim::singleton_instance().cleanup();
```

`xim_network_exited_state_change` がまだ送信されていない場合は、`xim::leave_network()` を呼び出し、`xim_network_exited_state_change` を待機して、XIM ネットワークを正常終了することを強くお勧めします。 `xim::cleanup()` を直接呼び出すと、残りの参加者が "消えた" デバイスに送ったメッセージがタイムアウトするのを待機している間、通信パフォーマンスの問題を引き起こす可能性があります。
