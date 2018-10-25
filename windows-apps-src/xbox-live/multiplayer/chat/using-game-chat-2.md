---
title: ゲーム チャット 2 の使用
author: KevinAsgari
description: Xbox Live ゲーム チャット 2 を使用して、ゲームに音声通信を追加する方法について説明します。
ms.author: kevinasg
ms.date: 3/20/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信
ms.localizationpriority: medium
ms.openlocfilehash: 15e0abfa001910621e954f4859bb4a94159c31ec
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5478813"
---
# <a name="using-game-chat-2-c"></a>ゲーム チャット 2 の使用 (C++)

ここでは、ゲーム チャット 2 の C++ API の使用方法について概要を紹介します。 C# を通じたゲーム チャット 2 へのアクセスを予定しているゲーム開発者は、[ゲーム チャット 2 WinRT プロジェクションの使用に関するページ](using-game-chat-2-winrt.md)をご覧ください。

1. [前提条件](#prerequisites)
2. [初期化](#initialization)
3. [ユーザーの構成](#configuring-users)
4. [データ フレームの処理](#processing-data-frames)
5. [状態変更の処理](#processing-state-changes)
6. [テキスト チャット](#text-chat)
7. [ユーザー補助](#accessibility)
8. [UI](#ui)
9. [ミュート](#muting)
10. [悪い評判の自動ミュート](#bad-reputation-auto-mute)
11. [権限とプライバシー](#privilege-and-privacy)
12. [クリーンアップ](#cleanup)
13. [エラー モデル](#failure-model)
14. [一般的なシナリオの構成方法](#how-to-configure-popular-scenarios)

## <a name="prerequisites"></a>前提条件

ゲーム チャット 2 のコーディングを始める前に、"マイク" デバイス機能を宣言するアプリの AppXManifest を構成している必要があります。 AppXManifest 機能については、プラットフォームのドキュメントの各セクションで詳しく説明されています。次のスニペットは、パッケージ/機能ノードの下に存在している必要があり、存在しないとチャットがブロックされる "マイク" デバイス機能ノードを示しています。

```xml
 <?xml version="1.0" encoding="utf-8"?>
 <Package ...>
   <Identity ... />
   ...
   <Capabilities>
     <DeviceCapability Name="microphone" />
   </Capabilities>
 </Package>
```

ゲーム チャット 2 をコンパイルするには、プライマリ ヘッダー GameChat2.h を含める必要があります。 適切にリンクするには、プロジェクト内の 1 つ以上のコンパイル ユニットにも GameChat2Impl.h を含める必要があります (スタブ関数実装は小さく、コンパイラーで "インライン" として生成しやすいため、一般的なプリコンパイル済みヘッダーをお勧めします)。

ゲーム チャット 2 インターフェイスでは、プロジェクトのコンパイルにおいて、C++/CX と従来の C++ のいずれかを選択する必要がなく、どちらも使用できます。 また、この実装では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。 ただし、この実装は、致命的なエラーの報告を手段として例外をスローします (詳しくは「[エラー モデル](#failure)」を参照)。

## <a name="initialization"></a>初期化

ゲーム チャット 2 シングルトン インスタンスをシングルトンの初期化の有効期間を適用するパラメーターで初期化することで、ライブラリの操作を開始します。

```cpp
chat_manager::singleton_instance().initialize(...);
```

## <a name="configuring-users"></a>ユーザーの構成

インスタンスが初期化されたら、ゲーム チャット 2 インスタンスにローカル ユーザーを追加する必要があります。 この例では、ユーザー A はローカル ユーザーを表します。

```cpp
chat_user* chatUserA = chat_manager::singleton_instance().add_local_user(<user_a_xuid>);
```

また、リモート ユーザーと識別子 (リモート ユーザーがいるリモート "エンドポイント" を表すために使用) を追加する必要もあります。 "エンドポイント" は、リモート デバイスで実行されているアプリのインスタンスです。 この例では、ユーザー B がエンドポイント X に、ユーザー C と D がエンドポイント Y にいます。エンドポイント X には識別子 "1" が任意に割り当てられ、エンドポイント Y には識別子 "2" が任意に割り当てられています。 次の呼び出しを使って、ゲーム チャット 2 にリモート ユーザーを通知します。

```cpp
chat_user* chatUserB = chat_manager::singleton_instance().add_remote_user(<user_b_xuid>, 1);
chat_user* chatUserC = chat_manager::singleton_instance().add_remote_user(<user_c_xuid>, 2);
chat_user* chatUserD = chat_manager::singleton_instance().add_remote_user(<user_d_xuid>, 2);
```

これで、各リモート ユーザーとローカル ユーザーとの間の通信リレーションシップが構成されました。 この例では、ユーザー A とユーザー B が同じチームに属しており、双方向通信が許可されていると仮定します。 `c_communicationRelationshipSendAndReceiveAll` は、GameChat2.h で定義されている双方向通信を表す定数です。 ユーザー A のユーザー B に対するリレーションシップを次のように設定します。

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
```

次に、ユーザー C とユーザー D は "観戦者" であり、ユーザー A を一覧に表示することはできますが、会話は許可されていないと仮定します。 `c_communicationRelationshipSendAll` は、GameChat2.h で定義されているこの一方向通信を表す定数です。 リレーションシップを次のように設定します。

```cpp
chatUserA->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAll);
```

任意の時点で、シングルトン インスタンスに追加されているがローカル ユーザーと通信できるように構成されていないリモート ユーザーがいても問題ありません。 これは、ユーザーがチームを決定中か、会話チャネルを任意に変更できるシナリオで発生する場合があります。 ゲーム チャット 2 がキャッシュするのは、インスタンスに追加されたユーザーの情報 (プライバシー リレーションシップと評判) だけであるため、すべてのユーザー候補について、そのユーザーが特定の時点でローカル ユーザーと会話できない場合でも、ゲーム チャット 2 に通知すると役立ちます。

最後の点として、ユーザー D がゲームを終了したため、ローカル ゲーム チャット 2 インスタンスから削除する必要があるとします。 これは、次の呼び出しで実行できます。

```cpp
chat_manager::singleton_instance().remove_user(chatUserD);
```

`chat_manager::remove_user()` を呼び出すと、ユーザー オブジェクトが無効になることがあります。 [リアルタイム オーディオ操作](real-time-audio-manipulation.md)を使っている場合、詳しくは[チャット ユーザーの有効期限](real-time-audio-manipulation.md#chat-user-lifetimes)に関するドキュメントをご覧ください。 それ以外の場合、`chat_manager::remove_user()` が呼び出されるとすぐにユーザー オブジェクトは無効になります。 ユーザーを削除するタイミングの微妙な制限について詳しくは、「[状態変更の処理](#state)」をご覧ください。

## <a name="processing-data-frames"></a>データ フレームの処理

ゲーム チャット 2 には独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。 このプラグインは、アプリによる `chat_manager::start_processing_data_frames()` メソッドと `chat_manager::finish_processing_data_frames()` メソッドの定期的かつ頻繁な呼び出しです。 これらのメソッドを使用して、ゲーム チャット 2 は発信データをアプリに提供します。 これらは専用のネットワーク スレッドで頻繁にポーリングできるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべてのデータを取得できます。

`chat_manager::start_processing_data_frames()` を呼び出すと、キューに入っているすべてのデータが `game_chat_data_frame` 構造体ポインターの配列で報告されます。 アプリでは、配列を反復処理し、ターゲット "エンドポイント" を検査し、アプリのネットワーク層を使用してデータを適切なリモート アプリ インスタンスに配信する必要があります。 すべての `game_chat_data_frame` 構造体が終了した後は、`chat_manager:finish_processing_data_frames()` を呼び出すことによってその配列をゲーム チャット 2 に戻してリソースを解放する必要があります。 次に、例を示します。

```cpp
uint32_t dataFrameCount;
game_chat_data_frame_array dataFrames;
chat_manager::singleton_instance().start_processing_data_frames(&dataFrameCount, &dataFrames);
for (uint32_t dataFrameIndex = 0; dataFrameIndex < dataFrameCount; ++dataFrameIndex)
{
    game_chat_data_frame const* dataFrame = dataFrames[dataFrameIndex];
    HandleOutgoingDataFrame(
        dataFrame->packet_byte_count,
        dataFrame->packet_buffer,
        dataFrame->target_endpoint_identifier_count,
        dataFrame->target_endpoint_identifiers,
        dataFrame->transport_requirement
        );
}
chat_manager::singleton_instance().finish_processing_data_frames(dataFrames);
```

データ フレームの処理頻度が高いほど、エンド ユーザーの感じるオーディオの遅延は低くなります。 オーディオは 40 ミリ秒のデータ フレームに結合されます。これは、推奨されるポーリング期間です。

## <a name="processing-state-changes"></a>状態変更の処理

ゲーム チャット 2 では、アプリによる `chat_manager::start_processing_state_changes()` メソッドの `chat_manager::finish_processing_state_changes()` 定期的かつ頻繁な呼び出しを通じて、受信したテキスト メッセージなどの更新をアプリに提供します。 これらのメソッドは、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。

`chat_manager::start_processing_state_changes()` を呼び出すと、キューに入っているすべての更新が `game_chat_state_change` 構造体ポインターの配列で報告されます。 アプリでは、配列を反復処理し、より具体的な型の基本構造を検査して、基本的な構造体を対応する詳細な型にキャストしてから、その更新を適切に処理する必要があります。 現在使用可能なすべての `game_chat_state_change` オブジェクトが終了した後は、`chat_manager::finish_processing_state_changes()` を呼び出すことによってその配列をゲーム チャット 2 に戻してリソースを解放する必要があります。 次に、例を示します。

```cpp
uint32_t stateChangeCount;
game_chat_state_change_array gameChatStateChanges;
chat_manager::singleton_instance().start_processing_state_changes(&stateChangeCount, &gameChatStateChanges);

for (uint32_t stateChangeIndex = 0; stateChangeIndex < stateChangeCount; ++stateChangeIndex)
{
    switch (gameChatStateChanges[stateChangeIndex]->state_change_type)
    {
        case game_chat_state_change_type::text_chat_received:
        {
            HandleTextChatReceived(static_cast<const game_chat_text_chat_received_state_change*>(gameChatStateChanges[stateChangeIndex]));
            break;
        }

        case Xs::game_chat_2::game_chat_state_change_type::transcribed_chat_received:
        {
            HandleTranscribedChatReceived(static_cast<const Xs::game_chat_2::game_chat_transcribed_chat_received_state_change*>(gameChatStateChanges[stateChangeIndex]));
            break;
        }

        ...
    }
}
chat_manager::singleton_instance().finish_processing_state_changes(gameChatStateChanges);
```

`chat_manager::remove_user()` は、ユーザー オブジェクトに関連付けられたメモリをすぐに無効にし、状態変更にユーザー オブジェクトへのポインターが含まれていることがあるため、状態変更の処理中に `chat_manager::remove_user()` を呼び出さないでください。

## <a name="text-chat"></a>テキスト チャット

テキスト チャットを送信するには、`chat_user::chat_user_local::send_chat_text()` を使用します。 次に、例を示します。

```cpp
chatUserA->local()->send_chat_text(L"Hello");
```

ゲーム チャット 2 では、このメッセージを含むデータ フレームを生成します。このデータ フレームのターゲット エンドポイントは、ローカル ユーザーからテキストを受信するように構成されたユーザーに関連付けられたものになります。 リモート エンドポイントでデータが処理されると、メッセージは `game_chat_text_chat_received_state_change` を通じて公開されます。 ボイス チャットと同様に、テキスト チャットでは権限とプライバシーの制限が考慮されます。 ユーザーの間で、テキスト チャットを許可するように構成されているが、権限またはプライバシーの制限によって通信が許可されていない場合、テキスト メッセージは失われます。

ユーザー補助のために、テキスト チャットの入力と表示のサポートが必要です (詳細については、「[ユーザー補助](#access)」を参照してください)。

## <a name="accessibility"></a>アクセシビリティ

テキスト チャットの入力と表示をサポートする必要があります。 テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、ユーザーはこのシステムで、音声合成の支援技術を使用する場合があるためです。 同様に、ユーザーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。 ローカル ユーザーがこれらの設定を検出できるようにするには、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` および `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` メソッドをそれぞれ呼び出します。必要に応じて、テキストのメカニズムを有効にすることもできます。

### <a name="text-to-speech"></a>音声合成

ユーザーが音声合成を有効にしていると、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` は 'true' を返します。 この状態が検出されると、アプリではテキスト入力の方法を提供する必要があります。 現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `chat_user::chat_user_local::synthesize_text_to_speech()` メソッドに渡します。 ゲーム チャット 2 では、文字列を検出し、ユーザーの利用可能な音声設定に基づいてオーディオ データを合成します。 次に、例を示します。

```cpp
chat_userA->local()->synthesize_text_to_speech(L"Hello");
```

この操作の一環として合成されたオーディオは、このローカル ユーザーからオーディオを受信するように構成されたユーザー全員に転送されます。 音声合成を有効にしていないユーザーから `chat_user::chat_user_local::synthesize_text_to_speech()` が呼び出された場合、ゲーム チャット 2 では何も実行しません。

### <a name="speech-to-text"></a>音声テキスト変換

ユーザーが音声テキスト変換を有効にしていると、`chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` は true を返します。 この状態が検出されると、アプリは変換されたチャット メッセージに関連付けられた UI を提供する準備ができている必要があります。 ゲーム チャット 2 では各リモート ユーザーのオーディオを自動的に変換して、`game_chat_transcribed_chat_received_state_change` を通じて公開します。

> `Windows::Xbox::UI::Accessibility` は、音声からテキストの変換支援技術を搭載したゲーム内のテキストチャットを単純にレンダリングできるように特別に設計された Xbox One のクラスです。

### <a name="speech-to-text-performance-considerations"></a>音声テキスト変換のパフォーマンスに関する考慮事項

音声テキスト変換が有効の場合、各リモート デバイスのゲーム チャット 2 インスタンスでは音声サービス エンドポイントとの Web ソケット接続を開始します。 各リモート ゲーム チャット 2 クライアントではこの WebSocket を通じて音声サービス エンドポイントにオーディオをアップロードします。音声サービス エンドポイントでは随時、トランスクリプション メッセージをリモート デバイスに返します。 その後、リモート デバイスではトランスクリプション メッセージ (つまり、テキスト メッセージ) をローカル デバイスに送信します。ローカル デバイスでは、ゲーム チャット 2 からアプリにテキスト メッセージが提供され、表示されます。

そのため、音声テキスト変換の主なパフォーマンス コストは、ネットワーク使用率です。 ネットワーク トラフィックの大半はエンコードされたオーディオのアップロードです。 "通常" のボイス チャット パスでゲーム チャット 2 によってエンコード済みのオーディオが WebSocket によってアップロードされます。アプリでは `chat_manager::set_audio_encoding_type_and_bitrate` を通じてビットレートを制御します。

## <a name="ui"></a>UI 

特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。 これを行うには、`chat_user::chat_indicator()` を呼び出し、プレイヤーのチャットの現在の瞬間的なステータスを表す `game_chat_user_chat_indicator` を取得します。 次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'chatUserA' 変数で指定した `chat_user` オブジェクトのインジケーター値の取得を示します。

```cpp
switch (chatUserA->chat_indicator())
{
   case game_chat_user_chat_indicator::silent:
   {
       iconToShow = Icon_InactiveSpeaker;
       break;
   }

   case game_chat_user_chat_indicator::talking:
   {
       iconToShow = Icon_ActiveSpeaker;
       break;
   }

   case game_chat_user_chat_indicator::local_microphone_muted:
   {
       iconToShow = Icon_MutedSpeaker;
       break;
   }
   ...
}
```

`xim_player::chat_indicator()` によって報告される値は、プレイヤーの発声開始から終了までを頻繁に変更することを想定しています。 そのため、すべての UI フレームをポーリングできるように設計されています。

## <a name="muting"></a>ミュート 

`chat_user::chat_user_local::set_microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を切り替えることができます。 マイクがミュート状態の場合、マイクからオーディオはキャプチャされません。 ユーザーが Kinect などの共有デバイスを使用している場合、ミュート状態はすべてのユーザーに適用されます。

`chat_user::chat_user_local::microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を取得することができます。 このメソッドは、ローカル ユーザーのマイクが `chat_user::chat_user_local::set_microphone_muted()` の呼び出しを通じてソフトウェアでミュートされているかどうかのみ反映しています。たとえば、ユーザーのヘッドセットのボタンを通じてハードウェアのミュートが制御されていることは反映していません。 ゲーム チャット 2 を通じてユーザーのオーディオ デバイスのハードウェアのミュート状態を取得するメソッドはありません。

`chat_user::chat_user_local::set_remote_user_muted()` メソッドを使用すると、特定のローカル ユーザーに関連するリモート ユーザーのミュート状態を切り替えることができます。 リモート ユーザーがミュート状態の場合、ローカル ユーザーにはそのリモート ユーザーの音声は聞こえません。また、そのリモート ユーザーからのテキスト メッセージを受信しません。

## <a name="bad-reputation-auto-mute"></a>悪い評判の自動ミュート

通常、リモート ユーザーはミュートを解除した状態で開始します。 (1) リモート ユーザーがローカル ユーザーのフレンドではなく、(2) リモート ユーザーに悪い評判のフラグがある場合、ゲーム チャット 2 ではユーザーをミュート状態で開始します。 この操作によってユーザーがミュートされている場合、`chat_user::chat_indicator()` は `game_chat_user_chat_indicator::reputation_restricted` を返します。 この状態は、そのリモート ユーザーをターゲット ユーザーとして含む `chat_user::chat_user_local::set_remote_user_muted()` の最初の呼び出しでオーバーライドされます。

## <a name="privilege-and-privacy"></a>権限とプライバシー 

ゲームによって構成される通信リレーションシップの上に、ゲーム チャット 2 は権限とプライバシーの制限を強制します。 ゲーム チャット 2 では、ユーザーが最初に追加されると、権限とプライバシーの制限の参照を実行します。この操作が完了するまで、ユーザーの `chat_user::chat_indicator()` は常に `game_chat_user_chat_indicator::silent` を返します。 ユーザーの通信が権限またはプライバシーの制限による影響を受ける場合、ユーザーの `chat_user::chat_indicator()` は `game_chat_user_chat_indicator::platform_restricted` を返します。 プラットフォーム通信制限は、音声チャットとテキスト チャットの両方に適用されます。テキスト チャットがプラットフォーム制限によりブロックされて音声チャットが制限されないインスタンスはなく、その逆もありません。

`chat_user::chat_user_local::get_effective_communication_relationship()` を使用すると、不完全な権限とプライバシーの操作によってユーザーが通信できない場合の区別に役立ちます。 これを使用すると、ゲーム チャット 2 によって強制される通信リレーションシップが `game_chat_communication_relationship_flags` の形式で返されます。また、リレーションシップが構成されたリレーションシップと等しくない理由が `game_chat_communication_relationship_adjuster` の形式で返されます。 たとえば、参照操作が進行中の場合、`game_chat_communication_relationship_adjuster` は `game_chat_communication_relationship_adjuster::intializing` になります。 この方法は、開発シナリオとデバッグ シナリオで使用することを想定しています。UI に影響を与えるために使用しないでください (「[UI](#UI)」を参照してください)。

## <a name="cleanup"></a>クリーンアップ

アプリでゲーム チャット 2 を介した通信が不要になった場合は、`chat_manager::cleanup()` を呼び出します。 これにより、ゲーム チャット 2 で通信の管理に割り当てられたリソースを解放できます。

## <a name="failure-model"></a>エラー モデル

また、ゲーム チャット 2 の実装では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。 ただし、ゲーム チャット 2 は致命的なエラーを通知するために例外をスローします。 これらのエラーは、インスタンスを初期化する前にゲーム チャット インスタンスにユーザーを追加したり、ゲーム チャット 2 インスタンスから削除された後にユーザー オブジェクトにアクセスしたりなど、API の誤用によるものです。 これらのエラーは開発の早い段階で検出することが期待され、ゲーム チャット 2 との対話に使用されるパターンを変更して修正することができます。 このようなエラーが発生した場合、例外が発生する前に、エラーの原因に関するヒントがデバッガーに出力されます。

## <a name="how-to-configure-popular-scenarios"></a>一般的なシナリオの構成方法

### <a name="push-to-talk"></a>プッシュして話しかける

プッシュして話しかける機能は、`chat_user::chat_user_local::set_microphone_muted()` を使用して実装する必要があります。 会話を許可するには `set_microphone_muted(false)` を呼び出し、制限するには `set_microphone_muted(true)` を呼び出します。 この方法を使用すると、ゲーム チャット 2 からの応答遅延時間が最少限になります。

### <a name="teams"></a>チーム

ユーザー A とユーザー B が青チーム、ユーザー C とユーザー D が赤チームに属しているとします。 各ユーザーは、アプリの一意のインスタンスに含まれます。

ユーザー A のデバイス:

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
chatUserA->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserA->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

ユーザー B のデバイス:

```cpp
chatUserB->local()->set_communication_relationship(chatUserA, c_communicationRelationshipSendAndReceiveAll);
chatUserB->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserB->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

ユーザー C のデバイス:

```cpp
chatUserC->local()->set_communication_relationship(chatUserA, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAndReceiveAll);
```

ユーザー D のデバイス:

```cpp
chatUserD->local()->set_communication_relationship(chatUserA, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAndReceiveAll);
```

### <a name="broadcast"></a>配信

ユーザー A が指示を出すリーダーで、ユーザー B、C、D は指示を聞くだけと仮定します。 各プレイヤーは、一意のデバイスを使用しています。

ユーザー A のデバイス:

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAll);
```

ユーザー B のデバイス:

```cpp
chatUserB->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserB->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserB->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

ユーザー C のデバイス:

```cpp
chatUserC->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserC->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

ユーザー D のデバイス:

```cpp
chatUserD->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserD->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
```
