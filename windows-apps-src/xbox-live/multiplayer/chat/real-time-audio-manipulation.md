---
title: リアルタイム オーディオ操作
author: KevinAsgari
description: ゲーム チャット 2 によってキャプチャされたチャット オーディオを操作および処理する方法について説明します。
ms.author: kevinasg
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信, バッファー操作, オーディオ操作
ms.localizationpriority: low
ms.openlocfilehash: 43be2692b53ac7036d4bf67659fafde913d52a95
ms.sourcegitcommit: 1eabcf511c7c7803a19eb31f600c6ac4a0067786
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
---
# <a name="real-time-audio-manipulation"></a>リアルタイム オーディオ操作

ゲーム チャット 2 (GC2) では、開発者が GC2 をチャット オーディオ パイプラインに挿入して、プレイヤーのチャット オーディオ データを検査および操作することができます。 これは、ゲームでおもしろいオーディオ エフェクトをプレイヤーの声に適用するのに役立ちます。 GC2 のオーディオ操作パイプラインは、オーディオ データ用にポーリングできるオーディオ ストリーム オブジェクトを使って操作できます。 コールバックを使うのとは対照的に、このモデルでは開発者にとって最も便利な処理スレッドでオーディオを検査または操作できます。

以下では、リアルタイム オーディオ操作の使用方法を簡単に説明します。次のトピックがあります。

1. [オーディオ操作パイプラインの初期化](#initializing-the-audio-manipulation-pipeline)
2. [オーディオ ストリームの状態の変化の処理](#processing-audio-stream-state-changes)
3. [プリエンコード チャット オーディオの操作](#manipulating-pre-encode-chat-audio-data)
4. [ポストデコード チャット オーディオの操作](#manipulating-post-decode-chat-audio-data)
5. [チャット ユーザーの有効期間](#chat-user-lifetimes)

## <a name="initializing-the-audio-manipulation-pipeline"></a>オーディオ操作パイプラインの初期化

GC2 では、リアルタイム オーディオ操作は既定で有効になりません。 リアルタイム オーディオ操作を有効にするには、アプリが `chat_manager::initialize()` で有効にするオーディオ操作の形式を指定する必要があります。

現在のところ、次のオーディオ操作形式がサポートされています。

* `game_chat_audio_manipulation_mode_flags::none` - オーディオ操作を無効にします。 これは既定の構成です。 このモードでは、チャット オーディオが常時流し込まれます。
* `game_chat_audio_manipulation_mode_flags::pre_encode_stream_manipulation` - プリエンコード オーディオ操作を有効にします。 このモードでは、ローカル ユーザーによって生成されたすべてのチャット オーディオが、エンコード前にオーディオ操作パイプラインを通じて取り込まれます。 アプリがチャット オーディオ データを操作せずに検査するだけであっても、変更されていないオーディオ バッファーをエンコードして転送できるように GC2 に戻す責任はアプリにあります。
* `game_chat_audio_manipulation_mode_flags::post_decode_stream_manipulation` - ポストデコード オーディオ操作を有効にします。 このモードは現在開発中のため、使用しないでください。

## <a name="processing-audio-stream-state-changes"></a>オーディオ ストリームの状態の変化の処理

GC2 は、`game_chat_stream_state_change` 構造体を通じてオーディオ ストリームの状態を更新します。 これらの更新には、更新されたストリームとその更新内容に関する情報が格納されています。 `chat_manager::start_processing_stream_state_changes` および `chat_manager::finish_processing_stream_state_changes` のメソッド ペアを呼び出すことにより、これらの更新をポーリングできます。 このメソッド ペアは、キューに入れられた最新のオーディオ ストリームの状態の更新すべてを `game_chat_stream_state_change` 構造体ポインターの配列として提供します。 アプリは、配列を反復処理し、各更新を適切に処理する必要があります。 利用可能な `game_chat_stream_state_change` の更新がすべて処理されたら、`chat_manager::finish_processing_stream_state_changes()` を通じてその配列を GC2 に戻す必要があります。 次に、例を示します。

```cpp
uint32_t streamStateChangeCount;
game_chat_stream_state_change_array streamStateChanges;
chat_manager::singleton_instance().start_processing_stream_state_changes(&streamStateChangeCount, &streamStateChanges);

for (uint32_t streamStateChangeIndex = 0; streamStateChangeIndex < streamStateChangeCount; ++streamStateChangeIndex)
{
    switch (streamStateChanges[streamStateChangeIndex]->state_change_type)
    {
        case game_chat_stream_state_change_type::pre_encode_audio_stream_created:
        {
            HandlePreEncodeAudioStreamCreated(streamStateChanges[streamStateChangeIndex].preEncodeAudioStream);
            break;
        }

        case Xs::game_chat_2::game_chat_stream_state_change_type::pre_encode_audio_stream_closed:
        {
            HandlePreEncodeAudioStreamClosed(streamStateChanges[streamStateChangeIndex].preEncodeAudioStream);
            break;
        }

        ...
    }
}
chat_manager::singleton_instance().finish_processing_stream_state_changes(streamStateChanges);
```

## <a name="manipulating-pre-encode-chat-audio-data"></a>プリエンコード チャット オーディオ データの操作

GC2 は、`pre_encode_audio_stream` クラスを通じてローカル ユーザーにプリエンコード チャット オーディオ データへのアクセスを提供します。

### <a name="stream-lifetime"></a>ストリームの有効期間
アプリが新しい `pre_encode_audio_stream` インスタンスを使う準備ができると、その型フィールドが `game_chat_stream_state_change_type::pre_encode_audio_stream_created` に設定され、`game_chat_stream_state_change` 構造体を通じて配信されます。 このストリーム状態の変化が GC2 に返されると、オーディオ ストリームではプリエンコード オーディオ操作を実行可能になります。

既存の `pre_encode_audio_stream` をオーディオ操作に使用できなくなると、`game_chat_stream_state_change` 構造体を通じてアプリに通知されます。型フィールドは `game_chat_stream_state_change_type::pre_encode_audio_stream_closed` に設定されます。 アプリは、この機会にこのオーディオ ストリームに関連付けられたリソースのクリーンアップを開始できます。 このストリーム状態の変化が GC2 に返されると、オーディオ ストリームではプリエンコード オーディオ操作を実行できなくなります。

閉じられた `pre_encode_audio_stream` にそのリソースがすべて返されると、ストリームが破棄され、`game_chat_stream_state_change` 構造体を通じてアプリに通知されます。その型フィールドは、`game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed` に設定されます。 このストリームへの参照またはポインターをすべてクリーンアップする必要があります。 このストリーム状態の変化が GC2 に返されると、オーディオ ストリーム メモリが無効になります。

### <a name="stream-users"></a>ストリーム ユーザー
ストリームに関連付けられているユーザーのリストは、`pre_encode_audio_stream::get_users()` を使って検査できます。

### <a name="audio-formats"></a>オーディオ形式
アプリが GC2 から取得するバッファーのオーディオ形式は、`pre_encode_audio_stream::get_pre_processed_format()` を使って検査できます。 前処理されたオーディオ形式は常にモノラルになります。 アプリは、32 ビット浮動小数点値、16 ビット整数値、および 32 ビット整数値として表されるデータを処理することを予期する必要があります。

アプリは、`pre_encode_audio_stream::set_processed_format()` を使って、エンコードのために自身に転送されている操作対象バッファーのオーディオ形式について GC2 に通知する必要があります。 プリエンコード オーディオ ストリームの処理形式は、以下の前提条件を満たしている必要があります。

* 形式はモノラルでなければなりません。
* 形式は 32 ビット浮動小数点 PCM、32 ビット整数 PCM、または 16 ビット整数 PCM 形式である必要があります。
* 形式のサンプル レートは、そのプラットフォームに基づく前提条件に従う必要があります。 Xbox One ERA では、8 kHz、12 kHz、16 kHz、および 24 kHz のサンプル レートがサポートされています。 Xbox One および PC 用の UWP では、8 kHz、12 kHz、16 kHz、24 kHz、32 kHz、44.1 kHz、および 48 kHz のサンプル レートがサポートされています。

### <a name="retrieving-and-submitting-audio"></a>オーディオの取得と送信
アプリは、プリエンコード オーディオ ストリームで、`pre_encode_audio_stream::get_available_buffer_count()` を使って処理可能なバッファーの数を照会できます。 この情報は、バッファーの最小数が使用可能になるまでアプリがオーディオ処理を延期する場合に使用できます。 キューに入れることができるバッファーはプリエンコード オーディオ ストリームごとに 10 個だけであり、オーディオの遅延によりオーディオ パイプラインに待機時間が生じるため、キュー内のバッファーが 4 個を超える前にアプリがプリエンコード オーディオ ストリームをドレインすることをお勧めします。

アプリは、`pre_encode_audio_stream::get_next_buffer()` を使ってプリエンコード オーディオ ストリームからオーディオ バッファーを取得できます。 新しいオーディオ バッファーは、平均で 40 ミリ秒に 1 回使用可能になります。 このメソッドによって返されるバッファーは、使い終わったら `pre_encode_audio_stream::return_buffer()` にリリースされる必要があります。 プリエンコード オーディオ ストリームには、キューに入れられたバッファーまたは返されていないバッファーが任意の時点で最大 10 個存在することができます。 この制限に達すると、未処理のバッファーの一部が返されるまで、プレイヤーのオーディオ ソースからキャプチャされた新しいバッファーが破棄されます。

アプリは、`pre_encode_audio_stream::submit_buffer()` を使って、エンコードおよび転送のために検査および操作済みのバッファーを GC2 に戻すことができます。 GC2 では、インプレースおよびアウト オブ プレースのオーディオ操作がサポートされるため、`pre_encode_audio_stream::submit_buffer()` に送信されるバッファーは必ずしも `pre_encode_audio_stream::get_next_buffer()` から取得されるバッファーと同じである必要はありません。 これらの送信バッファーのプライバシー/特権は、このストリームに関連付けられているユーザーに基づいて適用されます。 40 ミリ秒ごとに、このストリームから取得される次の 40 ミリ秒間のオーディオがエンコードされて転送されます。 オーディオの中断を防ぐため、連続して聞こえるオーディオのバッファーは一定のレートでこのストリームに送信する必要があります。

### <a name="stream-contexts"></a>ストリーム コンテキスト
アプリは、`pre_encode_audio_stream::set_custom_stream_context()` と `pre_encode_audio_stream::custom_stream_context()` を使って、プリエンコード オーディオ ストリームでカスタム ポインター サイズのコンテキスト値を管理できます。 これらのカスタム ストリーム コンテキストは、GC2 のオーディオ ストリームと補助データ (ストリームのメタデータ、ゲームの状態など) のマッピングを作成するのに役立ちます。

### <a name="example"></a>例
1 つのオーディオ処理フレームでプリエンコード オーディオ ストリームを使う方法に関する簡単なエンド ツー エンドのサンプルを次に示します。

```cpp
uint32_t streamStateChangeCount;
game_chat_stream_state_change_array streamStateChanges;
chat_manager::singleton_instance().start_processing_stream_state_changes(&streamStateChangeCount, &streamStateChanges);

for (uint32_t streamStateChangeIndex = 0; streamStateChangeIndex < streamStateChangeCount; ++streamStateChangeIndex)
{
    switch (streamStateChanges[streamStateChangeIndex]->state_change_type)
    {
        case game_chat_stream_state_change_type::pre_encode_audio_stream_created:
        {
            stream->set_processed_audio_format(...);
            stream->set_custom_stream_context(...);
            HandlePreEncodeAudioStreamCreated(streamStateChanges[streamStateChangeIndex].preEncodeAudioStream);
            break;
        }

        case Xs::game_chat_2::game_chat_stream_state_change_type::pre_encode_audio_stream_closed:
        {
            HandlePreEncodeAudioStreamClosed(streamStateChanges[streamStateChangeIndex].preEncodeAudioStream);
            break;
        }

        case Xs::game_chat_2::game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed:
        {
            HandlePreEncodeAudioStreamDestroyed(streamStateChanges[streamStateChangeIndex].preEncodeAudioStream);
            break;
        }

        ...
    }
}
chat_manager::singleton_instance().finish_processing_stream_state_changes(streamStateChanges);

uint32_t preEncodeAudioStreamCount;
pre_encode_audio_stream_array preEncodeAudioStreams;
chat_manager::singleton_instance().get_pre_encode_audio_streams(&preEncodeAudioStreamCount, &preEncodeAudioStreams);
for (uint32_t preEncodeAudioStreamIndex = 0; preEncodeAudioStreamIndex < preEncodeAudioStreamCount; ++preEncodeAudioStreamIndex)
{
    pre_encode_audio_stream* stream = preEncodeAudioStreams[preEncodeAudioStreamIndex];
    StreamContext* context = reinterpret_cast<StreamContext*>(stream->custom_stream_context());

    game_chat_audio_format audio_format = stream->get_pre_processed_format();

    uint32_t preProcessedBufferByteCount;
    void* preProcessedBuffer;
    stream->get_next_buffer(&preProcessedBufferByteCount, &preProcessedBuffer);

    while (preProcessedBuffer != nullptr)
    {
        void* processedBuffer = nullptr;
        switch (audio_format.bits_per_sample)
        {
            case 16:
            {
                assert (audio_format.sample_type == game_chat_sample_type::integer);
                processedBuffer = ManipulateChatBuffer<int16_t>(preProcessedBufferByteCount, preProcessedBuffer, context);
                break;
            }
            case 32:
            {
                switch (audio_format.sample_type)
                {
                    case game_chat_sample_type::integer:
                    {
                        processedBuffer = ManipulateChatBuffer<int32_t>(preProcessedBufferByteCount, preProcessedBuffer, context);
                        break;
                    }
                    case game_chat_sample_type::ieee_float:
                    {
                        processedBuffer = ManipulateChatBuffer<float>(preProcessedBufferByteCount, preProcessedBuffer, context);
                        break;
                    }
                    default:
                    {
                        assert(false);
                        break;
                    }
                }
                break;
            }
            default:
            {
                assert(false);
                break;
            }
        }
        // processedBuffer can be the same as preProcessedBuffer (in-place manipulation) or it can be a buffer of
        // memory not managed by GC2 (out-of-place manipulation).
        stream->submit_buffer(processedBuffer);
        // Only return buffers retrieved from GC2. Do not return foreign memory to return_buffer.
        stream->return_buffer(preProcessedBuffer);
        stream->get_next_buffer(&preProcessedBufferByteCount, &preProcessedBuffer);
    }
}

Sleep(audioProcessingPeriodInMilliseconds);
```

## <a name="manipulating-post-decode-chat-audio-data"></a>ポストデコード チャット オーディオ データの操作

現在のところ、この機能は開発中です。 ポストデコード オーディオ操作インターフェイスを呼び出すと、エラーが発生します。

## <a name="chat-user-lifetimes"></a>チャット ユーザーの有効期間

リアルタイム オーディオ操作を有効にすると、チャット ユーザーの有効期間に影響が及びます。 `chat_manager::remove_user(chatUserX)` が呼び出された場合、chatUserX によってポイントされた chat_user オブジェクトは、chatUserX を参照するすべてのオーディオ ストリームが破棄されるまで有効なままです。 次のシナリオを考えてみましょう。

```cpp
// At somepoint a chat user, chatUserX, leaves the game session.
chat_manager::singleton_instance().remove_user(chatUserX);

// chatUserX is still valid, but to avoid further synchronization, prevent non-audio-stream use of chatUserX
chatUserX = nullptr;

// On the audio processing thread...
uint32_t streamStateChangeCount;
game_chat_stream_state_change_array streamStateChanges;
chat_manager::singleton_instance().start_processing_stream_state_changes(&streamStateChangeCount, &streamStateChanges);
for (uint32_t streamStateChangeIndex = 0; streamStateChangeIndex < streamStateChangeCount; ++streamStateChangeIndex)
{
    switch (streamStateChanges[streamStateChangeIndex]->state_change_type)
    {
        ...

        // All of the streams associated with chatUserX will close.
        case Xs::game_chat_2::game_chat_stream_state_change_type::pre_encode_audio_stream_closed:
        {
            CleanupPreEncodeAudioStreamResources(streamStateChanges[streamStateChangeIndex].preEncodeAudioStream);
            break;
        }

        ...
    }
}
chat_manager::singleton_instance().finish_processing_stream_state_changes(streamStateChanges);

// The next time the app processes stream state changes...
uint32_t streamStateChangeCount;
game_chat_stream_state_change_array streamStateChanges;
chat_manager::singleton_instance().start_processing_stream_state_changes(&streamStateChangeCount, &streamStateChanges);
for (uint32_t streamStateChangeIndex = 0; streamStateChangeIndex < streamStateChangeCount; ++streamStateChangeIndex)
{
    switch (streamStateChanges[streamStateChangeIndex]->state_change_type)
    {
        ...

        case Xs::game_chat_2::game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed:
        {
            uint32_t chatUserCount;
            Xs::game_chat_2::chat_user_array chatUsers;
            streamStateChanges[streamStateChangeIndex].preEncodeAudioStream->get_users(&chatUserCount, &chatUsers);
            assert(chatUserCount != 0);
            for (uint32_t chatUserIndex = 0; chatUserIndex < chatUserCount; ++chatUserIndex)
            {
                // chat_user objects such as chatUserX will still be valid while the destroyed state change is being processed.
                Log(chatUsers[chatUserIndex]->xbox_user_id());
            }
            break;
        }

        ...
    }
}
chat_manager::singleton_instance().finish_processing_stream_state_changes(streamStateChanges);
// Once the all destroyed state changes have been processed for all streams associated with chatUserX, it's memory will be invalidated.
// Do not call methods on chatUserX, e.g. chatUserX->xbox_user_id()
```
