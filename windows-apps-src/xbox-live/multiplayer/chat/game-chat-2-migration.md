---
title: ゲーム チャット 2 への移行
author: KevinAsgari
description: 既存のゲーム チャット コードをゲーム チャット 2 を使用するように移行する方法について説明します。
ms.author: kevinasg
ms.date: 5/2/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信
ms.localizationpriority: medium
ms.openlocfilehash: 7695fda4502f8359491e5fb822e59bc91a20e0c7
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3962377"
---
# <a name="migration-from-game-chat-to-game-chat-2"></a>ゲーム チャットからゲーム チャット 2 への移行

このドキュメントでは、ゲーム チャットとゲーム チャット 2 の類似点と、ゲーム チャットからゲーム チャット 2 に移行する方法について説明します。 そのため、ゲーム チャット 2 への移行を検討している、既存のゲーム チャットの実装を含むタイトルを対象としています。 既存のゲーム チャットの実装がない場合は、「[ゲーム チャット 2 の使用](using-game-chat-2.md)」から開始することをお勧めします。 ここでは、以下のトピックについて説明します。

1. [はじめに](#preface)
2. [前提条件](#prerequisites)
3. [初期化](#initialization)
4. [ユーザーの構成](#configuring-users)
5. [データの処理](#processing-data)
6. [イベントの処理](#processing-events)
7. [テキスト チャット](#text-chat)
8. [ユーザー補助](#accessibility)
9. [UI](#UI)
10. [ミュート](#muting)
11. [悪い評判の自動ミュート](#bad-reputation-auto-mute)
12. [権限とプライバシー](#privilege-and-privacy)
13. [クリーンアップ](#cleanup)
14. [エラー モデルとデバッグ](#failure-model-and-debugging)
15. [一般的なシナリオの構成方法](#how-to-configure-popular-scenarios)
16. [プリエンコードおよびポストデコード オーディオ操作](#pre-encode-and-post-decode-audio-manipulation)

## <a name="preface"></a>はじめに

元のゲーム チャット API は、チャット ユーザーと音声チャンネルの概念を公開し、Xbox Live のゲーム内ボイス チャット シナリオの実装を支援する WinRT API でした。 ゲーム チャット API はチャット API を基に構築されています。チャット API 自体もユーザー チャットと音声チャンネルの概念を公開する WinRT API でしたが、必要なオーディオ デバイスの管理は低レベルでした。 ゲーム チャット 2 は、元のゲーム チャット API とチャット API の後継です。チーム内のコミュニケーションなどの基本的なチャット シナリオについては、よりシンプルな API となり、同時にブロードキャスト スタイルのコミュニケーションやリアルタイムのオーディオ操作などの高度なチャット シナリオでは、より高い柔軟性を提供するように設計されています。 ゲーム チャットとゲーム チャット 2 はいずれも同じニッチな用途に対応しています。各 API は Xbox Live 対応のゲーム内ボイス チャットを統合するための便利なメソッドを提供する一方で、タイトルは、ゲーム チャットやゲーム チャット 2 のリモート インスタンスとの間でデータ パケットを送受信するためのトランスポート層を提供します。

ゲーム チャット 2 API は、元のゲーム チャット API やチャット API に比べて多くの利点があります。 その要点のいくつかを以下に示します。
* "チャンネル" モデルに制限されない柔軟性の高いユーザー指向の API。
* データ ソースとデータ受信側の両方でのパケット フィルタ リングにより帯域幅が向上。
* アプリで構成可能なアフィニティを使用して有効期間が長い 2 つのスレッドを内部制限。
* C++ と WinRT の両方の形式で利用可能な API。
* "do work" パターンに沿った簡略化された消費モデル。
* カスタム アロケーターを通じてゲーム チャット 2 の割り当てをリダイレクトするメモリ フック。
* より便利なクロスプラットフォーム開発エクスペリエンスを実現する、同一 UWP + 排他リソース アプリケーション (ERA) ヘッダー。

このドキュメントでは、ゲーム チャットとゲーム チャット 2 の類似点と、ゲーム チャットからゲーム チャット 2 C++ API に移行する方法について説明します。 ゲーム チャットからゲーム チャット 2 WinRT API への移行に関心がある場合は、このドキュメントでゲーム チャットの概念をゲーム チャット 2 にマップする方法を理解してから、WinRT に固有のパターンについて、「[ゲーム チャット 2 (WinRT プロジェクション) の使用](using-game-chat-2-winrt.md)」を参照してください。 このドキュメントで示す元のゲーム チャットのサンプル コードでは、C++/CX を使用します。

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

### <a name="game-chat"></a>ゲーム チャット

元のゲーム チャットとの対話は、`ChatManager` クラスを通じて実行されます。 次の例では、既定のパラメーターを使用して `ChatManager` インスタンスを作成する方法を示します。

```cpp
auto chatManager = ref new ChatManager();
```

### <a name="game-chat-2"></a>ゲーム チャット 2

ゲーム チャット 2 とのすべての対話は、ゲーム チャット 2 の `chat_manager` シングルトンを通じて実行されます。 ライブラリに対して意味のある操作を行う前に、このシングルトンを初期化する必要があります。 シングルトンの初期化時に、ローカルとリモートの最大同時チャット ユーザー数を指定する必要があります。これは、ゲーム チャット 2 が、予想されたユーザー数に比例してメモリを事前に割り当てるためです。 次の例では、ローカルとリモートの最大同時チャット ユーザー数が 4 人である場合に、シングルトン インスタンスを初期化する方法を示します。

```cpp
chat_manager::singleton_instance().initialize(4);
```

同様に、初期化中に指定できるいくつかのオプション パラメーターがあります。リモート チャット ユーザーの既定のレンダリング ボリュームや、ゲーム チャット 2 で自動的に音声テキスト変換を実行するかどうかなどです。 これらのパラメーターの詳細については、`chat_manager::initialize()` のドキュメントを参照してください。

## <a name="configuring-users"></a>ユーザーの構成

### <a name="game-chat"></a>ゲーム チャット

元のゲーム チャット API へのローカル ユーザーの追加は、`ChatManager::AddLocalUserToChatChannelAsync()` を通じて実行されます。 複数のチャット チャンネルにユーザーを追加するには、それぞれ別のチャンネルを指定する、複数の呼び出しが必要です。 次の例では、チャンネル 0 に xuid が "myXuid" であるユーザーを追加する方法を示します。

```cpp
auto asyncOperation = chatManager->AddLocalUserToChatChannelAsync(0, L"myXuid");
```

リモート ユーザーは、直接、インスタンスには追加されません。 タイトルのネットワークにリモート デバイスが表示されると、タイトルはリモート デバイスを表すオブジェクトを作成し、`ChatManager::HandleNewRemoteConsole()` を通じてゲーム チャットに新しいデバイスを通知します。 タイトルは、`CompareUniqueConsoleIdentifiersHandler` を実装することによって、リモート デバイスを表すオブジェクトをゲーム チャットと比較するメソッドを提供する必要もあります。 次の例では、このデリゲートをゲーム チャットに提供する方法を示します。`Platform::String` オブジェクトを使用してリモート デバイスを表しており、`L"1"` で表される新しいデバイスがタイトルのネットワークに参加したと仮定しています。

```cpp
auto token = chatManager->OnCompareUniqueConsoleIdentifiers +=
    ref new CompareUniqueConsoleIdentifiersHandler(
        [this](Platform::Object^ obj1, Platform::Object^ obj2)
    {
        return (static_cast<Platform::String^>(obj1)->Equals(static_cast<Platform::String^>(obj2)));
    });

...

Platform::String^ newDeviceIdentifier = ref new Platform::String(L"1");
chatManager->HandleNewRemoteConsole(newDeviceIdentifier);
```

ゲーム チャットは、このデバイスについて通知されると、すべてのローカル ユーザーに関する情報を含むパケットを生成し、リモート デバイスのゲーム チャット インスタンスに送信するために、これらのパケットをタイトルに提供します。 同様に、リモート デバイス上のゲーム チャットは、タイトルがゲーム チャットのローカル インスタンスを送信する先のリモート デバイス上のユーザー関する情報を含むパケットを精製します。 ローカル インスタンスが新しいリモート ユーザーに関する情報を含むパケットを受信すると、新しいリモート ユーザーは、`ChatManager::GetUsers()` 経由で利用可能なローカル インスタンスのユーザーのリストに追加されます。

ゲーム チャットのインスタンスからユーザーの削除は、`ChatManager::RemoveLocalUserFromChatChannelAsync()` と次の呼び出しを通じて実行されます。 `ChatManager::RemoveRemoteConsoleAsync()`

### <a name="game-chat-2"></a>ゲーム チャット 2

ゲーム チャット 2 へのローカル ユーザーの追加は、`chat_manager::add_local_user()` を通じて同期的に実行されます。 この例では、ユーザー A は、Xbox ユーザー ID が `L"myLocalXboxUserId"` であるローカル ユーザーを表します。

```cpp
chat_user* chatUserA = chat_manager::singleton_instance().add_local_user(L"myLocalXboxUserId");
```

ユーザーは特定のチャンネルには追加されないことに注意してください。ゲーム チャット 2 では、チャンネルではなく「コミュニケーション関係」の概念を使用して、ユーザーが互いに話したり、聞いたりできるかどうかを管理します。 コミュニケーション関係を構成する方法は、このセクションで後で説明します。

ローカル ユーザーと同様に、リモート ユーザーは同期的にローカルのゲーム チャット 2 インスタンスに追加されます。 これと同時に、リモート ユーザーは、リモート デバイスを表すために使用される識別子に関連付けられる必要があります。 ゲーム チャット 2 では、リモート デバイスで実行されているアプリのインスタンスを "エンドポイント" と呼びます。 この例では、ユーザー B は、整数 `1` で表されるエンドポイントで Xbox ユーザー ID `L"remoteXboxUserId"` を持つユーザーです。

```cpp
chat_user* chatUserB = chat_manager::singleton_instance().add_remote_user(L"remoteXboxUserId", 1);
```

ユーザーがインスタンスに追加されたら、各リモート ユーザーと各ローカル ユーザーの間に「コミュニケーション関係」を構成する必要があります。 この例では、ユーザー A とユーザー B が同じチームに属しており、双方向通信が許可されていると仮定します。 `c_communicationRelationshiSendAndReceiveAll` は、GameChat2.h で定義されている、双方向通信を表す定数です。 この関係は、次のようにして構成できます。

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
```

最後の点として、ユーザー B がゲームを終了したため、ローカル ゲーム チャット インスタンスから削除する必要があるとします。 これは、次の呼び出しで同期的に実行されます。

```cpp
chat_manager::singleton_instance().remove_user(chatUserD);
```

さらに詳しい例や個々の API メソッドのリファレンスについては、「[ゲーム チャット 2 の使用 - ユーザーの構成](using-game-chat-2.md#configuring-users)」を参照してください。

## <a name="processing-data"></a>データの処理

### <a name="game-chat"></a>ゲーム チャット

ゲーム チャットには独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。 送信パケットは、`OnOutgoingChatPacketReady` イベントをサブスクライブし、パケットの送信先とトランスポートの要件を決定する引数を検査することによって処理されます。 次の例は、イベントをサブスクライブし、タイトルで実装されている `HandleOutgoingPacket()` メソッドに引数を転送する方法を示しています。

```cpp
auto token = chatManager->OnOutgoingChatPacketReady +=
    ref new Windows::Foundation::EventHandler<Microsoft::Xbox::GameChat::ChatPacketEventArgs^>(
        [this](Platform::Object^, Microsoft::Xbox::GameChat::ChatPacketEventArgs^ args)
    {
        this->HandleOutgoingPacket(args);
    });
```

受信パケットは、`ChatManager::ProcessingIncomingChatMessage()` を通じてゲーム チャットに送信されます。 未処理のパケット バッファーとリモート デバイス識別子を指定する必要があります。 次の例は、ローカルの `packetBuffer` に保存されているパケットと、ローカル変数 `remoteIdentifier` に保存されているリモート デバイス識別子を送信する方法を示しています。

```cpp
Platform::String^ remoteIdentifier = /* The identifier associated with the device that generated this packet */
Windows::Storage::Streams::IBuffer^ packetBuffer = /* The incoming chat packet */

chatManager->ProcessIncomingChatMessage(packetBuffer, remoteIdentifier);
```

### <a name="game-chat-2"></a>ゲーム チャット 2

同様に、ゲーム チャット 2 には独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。 送信パケットは、アプリによる `chat_manager::start_processing_data_frames()` メソッドと `chat_manager::finish_processing_data_frames()` メソッドの定期的かつ頻繁な呼び出しによって処理されます。 これらのメソッドを使用して、ゲーム チャット 2 は発信データをアプリに提供します。 これらは専用のネットワーク スレッドで頻繁にポーリングできるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべてのデータを取得できます。

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

受信データは、`chat_manager::processing_incoming_data()` を通じてゲーム チャット 2 に送信されます。 データ バッファーとリモート エンドポイント識別子を指定する必要があります。 次の例は、ローカル変数 `dataFrame` に保存されているデータ パケットと、ローカル変数 `remoteEndpointIdentifier` に保存されているリモート エンドポイント識別子を送信する方法を示しています。

```cpp
uin64_t remoteEndpointIdentier = /* The identifier associated with the endpoint that generated this packet */
uint32_t dataFrameSize = /* The size of the incoming data frame, in bytes */
uint8_t* dataFrame = /* A pointer to the buffer containing the incoming data */

chatManager::singleton_instance().process_incoming_data(remoteEndpointIdentifier, dataFrameSize, dataFrame);
```

## <a name="processing-events"></a>イベントの処理

### <a name="game-chat"></a>ゲーム チャット

ゲーム チャットでは、イベント生成モデルを使用して、関心のあるできごとが発生したことをアプリに通知します。たとえば、テキスト メッセージの受信や、ユーザーのアクセシビリティの基本設定の変更です。 アプリは、関心のある各イベントをサブスクライブし、イベントのハンドラーを実装する必要があります。 次の例は、`OnTextMessageReceived` イベントをサブスクライブし、アプリで実装されている `OnTextChatReceived()` または `OnTranscribedChatReceived()` メソッドに引数を転送する方法を示しています。

```cpp
auto token = chatManager->OnTextMessageReceived +=
    ref new Windows::Foundation::EventHandler<Microsoft::Xbox::GameChat::TextMessageReceivedEventArgs^>(
        [this](Platform::Object^, Microsoft::Xbox::GameChat::TextMessageReceivedEventArgs^ args)
    {
        if (args->ChatTextMessageType != ChatTextMessageType::TranscribedSpeechMessage)
        {
            this->OnTextChatReceived(args);
        }
        else
        {
            this->OnTranscribedChatReceived(args);
        }
    });
```

### <a name="game-chat-2"></a>ゲーム チャット 2

ゲーム チャット 2 では、アプリによる `chat_manager::start_processing_state_changes()` メソッドと `chat_manager::finish_processing_state_changes()` メソッドの定期的かつ頻繁な呼び出しを通じて、受信したテキスト メッセージなどの更新をアプリに提供します。 これらのメソッドは、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。

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

### <a name="game-chat"></a>ゲーム チャット

ゲーム チャットでテキスト チャットを送信するには、`GameChatUser::GenerateTextMessage()` を使用できます。 次の例は、`chatUser` 変数によって表されるローカル チャット ユーザーにチャット テキスト メッセージを送信する方法を示しています。

```cpp
chatUser->GenerateTextMessage(L"Hello", false);
```

2 番目のブール値パラメーターは、音声合成変換を制御します。 詳細については、「[ユーザー補助](#accessibility)」を参照してください。次に、ゲーム チャットは、このメッセージを含むチャット パケットを生成します。 ゲーム チャットのリモート インスタンスには、`OnTextMessageReceived` イベント経由でテキスト メッセージが通知されます。

### <a name="game-chat-2"></a>ゲーム チャット 2

ゲーム チャット 2 でテキスト チャットを送信するには、`chat_user::chat_user_local::send_chat_text()` を使用します。 次の例は、`chatUser` 変数によって表されるローカル チャット ユーザーにチャット テキスト メッセージを送信する方法を示しています。

```cpp
chatUser->local()->send_chat_text(L"Hello");
```

ゲーム チャット 2 では、このメッセージを含むデータ フレームを生成します。このデータ フレームのターゲット エンドポイントは、ローカル ユーザーからテキストを受信するように構成されたユーザーに関連付けられたものになります。 リモート エンドポイントでデータが処理されると、メッセージは `game_chat_text_chat_received_state_change` を通じて公開されます。 ボイス チャットと同様に、テキスト チャットでは権限とプライバシーの制限が考慮されます。 ユーザーの間で、テキスト チャットを許可するように構成されているが、権限またはプライバシーの制限によって通信が許可されていない場合、テキスト メッセージは通知なしで失われます。

ユーザー補助のために、テキスト チャットの入力と表示のサポートが必要です (詳細については、「[ユーザー補助](#accessibility)」を参照してください)。

## <a name="accessibility"></a>ユーザー補助

テキスト チャットの入力と表示のサポートは、ゲーム チャットおよびゲーム チャット 2 の両方に必要です。 テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、ユーザーはこのシステムで、音声合成の支援技術を使用する場合があるためです。 同様に、ユーザーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。 ゲーム チャットおよびゲーム チャット 2 はいずれも、ユーザーのユーザー補助の設定を検出して考慮するメソッドを提供します。これらの設定に基づいて、条件付きでテキストのメカニズムを有効にすることができます。

### <a name="text-to-speech---game-chat"></a>音声合成 - ゲーム チャット

ユーザーが音声合成を有効にしていると、`GameChatUser::HasRequestedSynthesizedAudio()` は true を返します。 この状態が検出されると、`GameChatUser::GenerateTextMessage()` は、ローカルのユーザーに関連付けられているオーディオ ストリームに挿入されている音声合成のオーディオを生成します。 次の例は、`chatUser` 変数によって表されるローカル ユーザーにチャット テキスト メッセージを送信する方法を示しています。

```cpp
chatUser->GenerateTextMessage(L"Hello", true);
```

2 番目のブール値パラメーターは、アプリが音声テキスト変換の基本設定を上書きすることを許可するために使用されます。'true' は、ユーザーの音声合成の基本設定が有効になっている場合に、ゲーム チャットがオン税構成のオーディオを生成する必要があることを示します。'false' は、ゲーム チャットがメッセージから音声合成のオーディオを生成しないことを示します。

### <a name="text-to-speech---game-chat-2"></a>音声合成 - ゲーム チャット 2

ユーザーが音声合成を有効にしていると、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` は 'true' を返します。 この状態が検出されると、アプリではテキスト入力の方法を提供する必要があります。 現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `chat_user::chat_user_local::synthesize_text_to_speech()` メソッドに渡します。 ゲーム チャット 2 では、文字列を検出し、ユーザーの利用可能な音声設定に基づいてオーディオ データを合成します。 次に、例を示します。

```cpp
chat_userA->local()->synthesize_text_to_speech(L"Hello");
```

この操作の一環として合成されたオーディオは、このローカル ユーザーからオーディオを受信するように構成されたユーザー全員に転送されます。 音声合成を有効にしていないユーザーから `chat_user::chat_user_local::synthesize_text_to_speech()` が呼び出された場合、ゲーム チャット 2 では何も実行しません。

### <a name="speech-to-text---game-chat"></a>音声テキスト変換 - ゲーム チャット

ユーザーが音声テキスト変換を有効にしていると、`GameChatUser::HasRequestSynthesizedAudio()` は 'true' を返します。 この状態が検出されると、ゲーム チャットは自動的に各リモート ユーザーの音声をテキストに変換し、`OnTextMessageReceived` イベントを通じて公開します。 テキストに変換されたメッセージを受信したために `OnTextMessageReceived` イベントが発生すると、`TextMessageReceivedEventArgs` はメッセージの種類として `ChatTextMessageType::TranscribedSpeechMessage` を示します。

### <a name="speech-to-text---game-chat-2"></a>音声テキスト変換 - ゲーム チャット 2

ユーザーが音声テキスト変換を有効にしていると、`chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` は true を返します。 この状態が検出されると、アプリは変換されたチャット メッセージに関連付けられた UI を提供する準備ができている必要があります。 ゲーム チャット 2 では各リモート ユーザーのオーディオを自動的に変換して、`game_chat_transcribed_chat_received_state_change` を通じて公開します。

> `Windows::Xbox::UI::Accessibility` は、音声テキスト変換支援技術を搭載したゲーム内のテキストチャットを単純にレンダリングできるように特別に設計された Xbox One のクラスです。

音声テキスト変換のパフォーマンスに関する考慮事項の詳細については、「[ゲーム チャット 2 の使用 - 音声テキスト変換のパフォーマンスに関する考慮事項](using-game-chat-2.md#speech-to-text-performance-considerations)」を参照してください。

## <a name="ui"></a>UI

特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。 ゲーム チャット 2 には、表示する適切な UI 要素を簡単に判断する方法を提供する一体化したインジケーターが導入されています。

### <a name="game-chat"></a>ゲーム チャット

`GameChatUser` には、適切な UI 要素を判断するときに一般的に検査される 3 つのプロパティ `GameChatUser::TalkingMode`、`GameChatUser::IsMuted`、`GameChatUser::RestrictionMode` があります。 次の例では、'chatUser' 変数によって指定される `GameChatUser` オブジェクトから `iconToShow` 変数に割り当てる特定のアイコンの定数値を決定するためのヒューリスティックを示します。

```cpp
if (chatUser->RestrictionMode != None)
{
    if (!chatUser->IsMuted)
    {
        if (chatUser->TalkingMode != NotTalking)
        {
            iconToShow = Icon_ActiveSpeaker;
        }
        else
        {
            iconToShow = Icon_InactiveSpeaker;
        }
    }
    else
    {
        iconToShow = Icon_MutedSpeaker;
    }
}
else
{
    iconToShow = Icon_RestrictedSpeaker;
}
```

### <a name="game-chat-2"></a>ゲーム チャット 2

ゲーム チャット 2 には、プレイヤーのチャットについて現在の瞬間的なステータスを表すために使用される、一体化された `game_chat_user_chat_indicator` があります。 この値は、`chat_user::chat_indicator()` を呼び出すことによって取得されます。 次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'chatUser' 変数で指定した `chat_user` オブジェクトのインジケーター値の取得を示します。

```cpp
switch (chatUser->chat_indicator())
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

## <a name="muting"></a>ミュート

## <a name="game-chat"></a>ゲーム チャット

ゲーム チャットでのユーザーのミュートとミュート解除は、それぞれ `ChatManager::MuteUserFromAllChannels()` または `ChatManager::UnMuteUIserFromAllChannels()` の呼び出しによって実行されます。 ユーザーのミュート状態は、`GameChatUser::IsMuted` または `GameChatUser::IsLocalUserMuted` を調べることによって取得できます。

## <a name="game-chat-2"></a>ゲーム チャット 2

`chat_user::chat_user_local::set_microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を切り替えることができます。 マイクがミュート状態の場合、マイクからオーディオはキャプチャされません。 ユーザーが Kinect などの共有デバイスを使用している場合、ミュート状態はすべてのユーザーに適用されます。

`chat_user::chat_user_local::microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を取得することができます。 このメソッドは、ローカル ユーザーのマイクが `chat_user::chat_user_local::set_microphone_muted()` の呼び出しを通じてソフトウェアでミュートされているかどうかのみ反映しています。たとえば、ユーザーのヘッドセットのボタンを通じてハードウェアのミュートが制御されていることは反映していません。 ゲーム チャット 2 を通じてユーザーのオーディオ デバイスのハードウェアのミュート状態を取得するメソッドはありません。

`chat_user::chat_user_local::set_remote_user_muted()` メソッドを使用すると、特定のローカル ユーザーに関連するリモート ユーザーのミュート状態を切り替えることができます。 リモート ユーザーがミュート状態の場合、ローカル ユーザーにはそのリモート ユーザーの音声は聞こえません。また、そのリモート ユーザーからのテキスト メッセージを受信しません。

## <a name="bad-reputation-auto-mute"></a>悪い評判の自動ミュート

通常、リモート ユーザーはミュートを解除した状態で開始します。 ゲーム チャットとゲーム チャット 2 にはいずれも "悪い評判の自動ミュート" 機能があります。 これは、(1) リモート ユーザーがローカル ユーザーのフレンドではなく、(2) リモート ユーザーに悪い評判のフラグがある場合、そのユーザーはミュート状態で開始されることを意味します。 ゲーム チャット 2 では、この機能によりユーザーがミュートされているときに、フィードバックを提供します。 詳細については、「[ゲーム チャット 2 の使用 - 悪い評判の自動ミュート](using-game-chat-2.md#bad-reputation-auto-mute)」を参照してください。

## <a name="privilege-and-privacy"></a>権限とプライバシー

ゲームによって管理されるチャンネルとコミュニケーション関係に対して、ゲーム チャットとゲーム チャット 2 はいずれも Xbox Live の権限とプライバシーの制限を適用します。 さらに、ゲーム チャット 2 では、正確に制限がオーディオの方向にどのように影響しているかを判断するための診断情報を提供します (例: オーディオの制限が単方向か双方向か)。

### <a name="game-chat"></a>ゲーム チャット

ゲーム チャットは、`RestrictionMode` プロパティを通じて、権限とプライバシーの情報を公開していました。 これは、`GameChatUser::RestrictionMode` を調べることによって取得できます。

### <a name="game-chat-2"></a>ゲーム チャット 2

ゲーム チャット 2 では、ユーザーが最初に追加されると、権限とプライバシーの制限の参照を実行します。この操作が完了するまで、ユーザーの `chat_user::chat_indicator()` は常に `game_chat_user_chat_indicator::silent` を返します。 ユーザーの通信が権限またはプライバシーの制限による影響を受ける場合、ユーザーの `chat_user::chat_indicator()` は `game_chat_user_chat_indicator::platform_restricted` を返します。 プラットフォーム通信制限は、音声チャットとテキスト チャットの両方に適用されます。テキスト チャットがプラットフォーム制限によりブロックされて音声チャットが制限されないインスタンスはなく、その逆もありません。

`chat_user::chat_user_local::get_effective_communication_relationship()` を使用すると、不完全な権限とプライバシーの操作によってユーザーが通信できない場合の区別に役立ちます。 これを使用すると、ゲーム チャット 2 によって強制される通信リレーションシップが `game_chat_communication_relationship_flags` の形式で返されます。また、リレーションシップが構成されたリレーションシップと等しくない理由が `game_chat_communication_relationship_adjuster` の形式で返されます。 たとえば、参照操作が進行中の場合、`game_chat_communication_relationship_adjuster` は `game_chat_communication_relationship_adjuster::intializing` になります。 この方法は、開発シナリオとデバッグ シナリオで使用することを想定しています。UI に影響を与えるために使用しないでください (「[UI](#UI)」を参照してください)。

## <a name="cleanup"></a>クリーンアップ

元のゲーム チャットの `ChatManager` は WinRT ランタイム クラスであり、参照がカウントされるインターフェイスです。 そのため、最後の参照カウントが 0 になったときに、そのメモリ リソースは再利用され、クリーンアップされます。 ゲーム チャット 2 の C++ API との対話はシングルトン インスタンスを通じて実行されます。アプリでゲーム チャット 2 経由での通信が不要になった場合、`chat_manager::cleanup()` を呼び出す必要があります。 これにより、ゲーム チャット 2 では、通信の管理に割り当てられたすべてのリソースを直ちに解放できます。 ゲーム チャット 2 の WinRT API とリソース管理について詳しくは、「[ゲーム チャット 2 (WinRT プロジェクション) の使用](using-game-chat-2-winrt.md#cleanup)」を参照してください。

## <a name="failure-model-and-debugging"></a>エラー モデルとデバッグ

元のゲーム チャットは WinRT API であるため、例外を使用してエラーを報告していました。 致命的ではないエラーや警告は、オプションのデバッグ コールバックで報告されます。 ゲーム チャット 2 の C++ API では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。 ただし、ゲーム チャット 2 は致命的なエラーを通知するために例外をスローします。 これらのエラーは、インスタンスを初期化する前にゲーム チャット インスタンスにユーザーを追加したり、ゲーム チャット インスタンスから削除された後にユーザー オブジェクトにアクセスしたりなど、API の誤用によるものです。 これらのエラーは開発の早い段階で検出することが期待され、ゲーム チャット 2 との対話に使用されるパターンを変更して修正することができます。 このようなエラーが発生した場合、例外が発生する前に、エラーの原因に関するヒントがデバッガーに出力されます。 ゲーム チャット 2 の WinRT API は、例外を使用してエラーを報告する WinRT パターンに従います。

## <a name="how-to-configure-popular-scenarios"></a>一般的なシナリオの構成方法

プッシュして話しかける、チーム、ブロードキャスト スタイルの通信シナリオなど、一般的なシナリオを構成する方法の例については、「[ゲーム チャット 2 の使用 - 一般的なシナリオの構成方法](using-game-chat-2.md#how-to-configure-popular-scenarios)」を参照してください。

## <a name="pre-encode-and-post-decode-audio-manipulation"></a>プリエンコードおよびポストデコード オーディオ操作

元のゲーム チャットでは、`OnPreEncodeAudioBuffer` イベントと `OnPostDecodeAudioBuffers` イベントを通じて、未処理のマイク オーディオへのアクセスを許可することにより、オーディオ操作を許可していました。 ゲーム チャット 2 では、ポーリング モデルを使用してこの機能を公開します。 詳しくは、「[リアルタイム オーディオ操作](real-time-audio-manipulation.md)」をご覧ください。
