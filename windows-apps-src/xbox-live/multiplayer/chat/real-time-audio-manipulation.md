---
title: リアルタイム オーディオ操作
description: ゲーム チャット 2 によってキャプチャされたチャット オーディオを操作および処理する方法について説明します。
ms.date: 05/10/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信, バッファー操作, オーディオ操作
ms.localizationpriority: medium
ms.openlocfilehash: 7746080ea8a9698993a679b425f41442e4a6d943
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57643897"
---
# <a name="real-time-audio-manipulation"></a>リアルタイム オーディオ操作

ゲームのチャット 2 は、自身に検査してプレーヤーのチャットのオーディオ データを操作するチャット オーディオ パイプラインに挿入するためのオプションを開発者に提供します。 これは、ゲームでおもしろいオーディオ エフェクトをプレイヤーの声に適用するのに役立ちます。 ゲーム チャット 2 のオーディオの操作のパイプラインは、オーディオ データをポーリングすることができますのオーディオ ストリーム オブジェクトを介して連携。 コールバックを使うのとは対照的に、このモデルでは開発者にとって最も便利な処理スレッドでオーディオを検査または操作できます。

以下では、リアルタイム オーディオ操作の使用方法を簡単に説明します。次のトピックがあります。

1. [オーディオ操作パイプラインを初期化しています](#initializing-the-audio-manipulation-pipeline)
2. [オーディオ ストリームの状態変更の処理](#processing-audio-stream-state-changes)
3. [チャットのオーディオをエンコード済みの操作](#manipulating-pre-encode-chat-audio-data)
4. [チャットのオーディオをデコード後の操作](#manipulating-post-decode-chat-audio-data)
5. [チャットのユーザー有効期間](#chat-user-lifetimes)

## <a name="initializing-the-audio-manipulation-pipeline"></a>オーディオ操作パイプラインの初期化

既定では、ゲームのチャット 2 がリアルタイムの音声操作を有効になりません。 リアルタイムの音声操作を有効にするアプリする必要があります指定なオーディオの操作のどのフォームで有効になっている`chat_manager::initialize()`audioManipulationMode パラメーターを設定します。

現在のところ、次のオーディオ操作形式がサポートされています。

* `game_chat_audio_manipulation_mode_flags::none` -オーディオの操作を無効にします。 これは既定の構成です。 このモードでは、チャット オーディオが常時流し込まれます。
* `game_chat_audio_manipulation_mode_flags::pre_encode_stream_manipulation` をオーディオ操作の事前エンコード有効にします。 このモードでは、ローカル ユーザーによって生成されたすべてのチャット オーディオが、エンコード前にオーディオ操作パイプラインを通じて取り込まれます。 アプリは、チャットのオーディオ データを検査して、操作しないのみが、場合でもエンコードして送信できるように、ゲームのチャット 2 に変更されていないオーディオ バッファーを送信するアプリの責任ではまだします。
* `game_chat_audio_manipulation_mode_flags::post_decode_stream_manipulation` -有効では、オーディオ操作後デコードします。 このモードでは、受信側がレンダリングされる前に、デコード後にリモート ユーザーから受信したすべてのチャット オーディオ オーディオ操作パイプラインを介して与えられます。 アプリは、チャットのオーディオ データを検査して、操作しないのみが、場合でもを混在させるし、表示できるように、ゲームのチャット 2 に変更されていないオーディオ バッファーを送信するアプリの責任ではまだします。

## <a name="processing-audio-stream-state-changes"></a>オーディオ ストリームの状態の変化の処理

ゲームのチャット 2 からオーディオ ストリームの状態に更新プログラムを提供する`game_chat_stream_state_change`構造体。 これらの更新には、更新されたストリームとその更新内容に関する情報が格納されています。 `chat_manager::start_processing_stream_state_changes()` および `chat_manager::finish_processing_stream_state_changes()` のメソッド ペアを呼び出すことにより、これらの更新をポーリングできます。 このメソッド ペアは、キューに入れられた最新のオーディオ ストリームの状態の更新すべてを `game_chat_stream_state_change` 構造体ポインターの配列として提供します。 アプリは、配列を反復処理し、各更新を適切に処理する必要があります。 1 回使用可能なすべて`game_chat_stream_state_change`更新プログラムが処理されて、その配列を渡すチャット 2 ~ ゲームに戻る必要があります`chat_manager::finish_processing_stream_state_changes()`します。 次に、例を示します。

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
            HandlePreEncodeAudioStreamCreated(streamStateChanges[streamStateChangeIndex].pre_encode_audio_stream);
            break;
        }

        case Xs::game_chat_2::game_chat_stream_state_change_type::pre_encode_audio_stream_closed:
        {
            HandlePreEncodeAudioStreamClosed(streamStateChanges[streamStateChangeIndex].pre_encode_audio_stream);
            break;
        }

        ...
    }
}
chat_manager::singleton_instance().finish_processing_stream_state_changes(streamStateChanges);
```

## <a name="manipulating-pre-encode-chat-audio-data"></a>プリエンコード チャット オーディオ データの操作

ゲームのチャット 2 を通じてユーザーがローカルのチャット オーディオ データの事前エンコードへのアクセスを提供する、`pre_encode_audio_stream`クラス。

### <a name="stream-lifetime"></a>ストリームの有効期間
新しい`pre_encode_audio_stream`インスタンスが使用するアプリの準備ができて、経由で配信されることを`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_created`します。 オーディオ ストリームが使用可能になるゲーム チャット 2 にこのストリームの状態の変更が返されると、オーディオの操作を事前にエンコードします。

既存`pre_encode_audio_stream`がオーディオの操作を使用して、使用不可能、アプリが通知されますを通じて、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_closed`。 アプリは、この機会にこのオーディオ ストリームに関連付けられたリソースのクリーンアップを開始できます。 オーディオ ストリームが使用できなくなりますゲーム チャット 2 にこのストリームの状態の変更が返されると、オーディオの操作を事前にエンコードします。

閉じているときに`pre_encode_audio_stream`がすべてのリソースが戻ると、ストリームが破棄され、を通じて、アプリが通知されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed`します。 このストリームへの参照またはポインターをすべてクリーンアップする必要があります。 このストリームの状態の変更がゲームのチャット 2 に返されると、オーディオ ストリームのメモリは無効になります。

### <a name="stream-users"></a>ストリーム ユーザー
ストリームに関連付けられているユーザーのリストは、`pre_encode_audio_stream::get_users()` を使って検査できます。

### <a name="audio-formats"></a>オーディオ形式
使用してゲームのチャット 2 から、アプリを取得するバッファーのオーディオ形式を検査できる`pre_encode_audio_stream::get_pre_processed_format()`します。 前処理されたオーディオ形式は常にモノラルになります。 アプリは、32 ビット浮動小数点値、16 ビット整数値、および 32 ビット整数値として表されるデータを処理することを予期する必要があります。

アプリは、オーディオ形式にエンコードすると、転送を使用して送信される操作のバッファーのゲームのチャット 2 を伝える必要があります`pre_encode_audio_stream::set_processed_format()`します。 プリエンコード オーディオ ストリームの処理形式は、以下の前提条件を満たしている必要があります。

* 形式はモノラルでなければなりません。
* 形式は 32 ビット浮動小数点 PCM、32 ビット整数 PCM、または 16 ビット整数 PCM 形式である必要があります。
* 形式のサンプル レートは、そのプラットフォームに基づく前提条件に従う必要があります。 Xbox One ERA では、8 kHz、12 kHz、16 kHz、および 24 kHz のサンプル レートがサポートされています。 Xbox One および PC 用の UWP では、8 kHz、12 kHz、16 kHz、24 kHz、32 kHz、44.1 kHz、および 48 kHz のサンプル レートがサポートされています。

### <a name="retrieving-and-submitting-audio"></a>オーディオの取得と送信
アプリは、プリエンコード オーディオ ストリームで、`pre_encode_audio_stream::get_available_buffer_count()` を使って処理可能なバッファーの数を照会できます。 この情報は、バッファーの最小数が使用可能になるまでアプリがオーディオ処理を延期する場合に使用できます。 キューに入れることができるバッファーはプリエンコード オーディオ ストリームごとに 10 個だけであり、オーディオの遅延によりオーディオ パイプラインに待機時間が生じるため、キュー内のバッファーが 4 個を超える前にアプリがプリエンコード オーディオ ストリームをドレインすることをお勧めします。

アプリは、`pre_encode_audio_stream::get_next_buffer()` を使ってプリエンコード オーディオ ストリームからオーディオ バッファーを取得できます。 新しいオーディオ バッファーは、平均で 40 ミリ秒に 1 回使用可能になります。 このメソッドによって返されるバッファーは、使い終わったら `pre_encode_audio_stream::return_buffer()` にリリースされる必要があります。 プリエンコード オーディオ ストリームには、キューに入れられたバッファーまたは返されていないバッファーが任意の時点で最大 10 個存在することができます。 この制限に達すると、未処理のバッファーの一部が返されるまで、プレイヤーのオーディオ ソースからキャプチャされた新しいバッファーが破棄されます。

アプリは、エンコードと転送を使用してゲームのチャット 2 に、検査と操作のバッファーを送信できます`pre_encode_audio_stream::submit_buffer()`します。 ゲームのチャット 2 にインプレースとな場所のオーディオ操作がサポートされている場合にバッファーが送信されるので`pre_encode_audio_stream::submit_buffer()`から取得した同じバッファーを必ずしも`pre_encode_audio_stream::get_next_buffer()`します。 これらの送信バッファーのプライバシー/特権は、このストリームに関連付けられているユーザーに基づいて適用されます。 40 ミリ秒ごとに、このストリームから取得される次の 40 ミリ秒間のオーディオがエンコードされて転送されます。 オーディオの中断を防ぐため、連続して聞こえるオーディオのバッファーは一定のレートでこのストリームに送信する必要があります。

### <a name="stream-contexts"></a>ストリーム コンテキスト
アプリは、`pre_encode_audio_stream::set_custom_stream_context()` と `pre_encode_audio_stream::custom_stream_context()` を使って、プリエンコード オーディオ ストリームでカスタム ポインター サイズのコンテキスト値を管理できます。 これらのカスタム ストリーム コンテキストはゲーム チャット 2 のオーディオ ストリームと補助データ間のマッピングを作成するために役立ちます。 メタデータ、ゲームの状態などのストリーム。

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
            pre_encode_audio_stream* stream = streamStateChanges[streamStateChangeIndex]->pre_encode_audio_stream;
            stream->set_processed_audio_format(...);
            stream->set_custom_stream_context(...);
            HandlePreEncodeAudioStreamCreated(stream);
            break;
        }

        case game_chat_2::game_chat_stream_state_change_type::pre_encode_audio_stream_closed:
        {
            HandlePreEncodeAudioStreamClosed(streamStateChanges[streamStateChangeIndex].pre_encode_audio_stream);
            break;
        }

        case game_chat_2::game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed:
        {
            HandlePreEncodeAudioStreamDestroyed(streamStateChanges[streamStateChangeIndex].pre_encode_audio_stream);
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
        // memory not managed by Game Chat 2 (out-of-place manipulation).
        stream->submit_buffer(processedBuffer);
        // Only return buffers retrieved from Game Chat 2. Do not return foreign memory to return_buffer.
        stream->return_buffer(preProcessedBuffer);
        stream->get_next_buffer(&preProcessedBufferByteCount, &preProcessedBuffer);
    }
}

Sleep(audioProcessingPeriodInMilliseconds);
```

## <a name="manipulating-post-decode-chat-audio-data"></a>ポストデコード チャット オーディオ データの操作

ゲームのチャット 2 を介してチャット オーディオ データをデコード後へのアクセスを提供します、`post_decode_audio_source_stream`と`post_decode_audio_sink_stream`クラスをユーザーがチャット オーディオの各ローカル受信側のリモート ユーザーからのオーディオを一意に操作可能性がありますようにします。

### <a name="sources-and-sinks"></a>ソースとシンク
Pre-encode パイプラインとは異なり、モデルを扱うオーディオ データをデコード後の分割されて 2 つのクラス:`post_decode_audio_source_stream`と`post_decode_audio_sink_stream`します。 取得できるリモート ユーザーからのデコードされたオーディオ`post_decode_audio_source_stream`オブジェクト、操作、およびに送信される`post_decode_audio_sink_stream`レンダリング オブジェクト。 これにより、ゲーム チャット 2 の間の統合、デコード後オーディオ処理パイプラインと便利なオーディオのミドルウェアの。

### <a name="stream-lifetime"></a>ストリームの有効期間
新しい`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`インスタンスが使用するアプリの準備ができて、経由で配信されることを`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_created`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream_created`、それぞれします。 オーディオ ストリームが使用可能になるゲーム チャット 2 にこのストリームの状態の変更が返されると、オーディオの操作を後にデコードします。

既存`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`になりますオーディオの操作を使用して、使用不可能、アプリが通知されますを通じて、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_closed`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream`、それぞれします。 アプリは、この機会にこのオーディオ ストリームに関連付けられたリソースのクリーンアップを開始できます。 オーディオ ストリームが使用できなくなりますゲーム チャット 2 にこのストリームの状態の変更が返されると、オーディオの操作を後にデコードします。 ソースのストリーム バッファーがありませんがキューの操作にことを意味します。 シンクのストリーム バッファーは表示されなくを送信することを意味します。

閉じているときに`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`がすべてのリソースが戻ると、ストリームが破棄され、を通じて、アプリが通知されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_destroyed`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream_destroyed`、それぞれします。 このストリームへの参照またはポインターをすべてクリーンアップする必要があります。 このストリームの状態の変更がゲームのチャット 2 に返されると、オーディオ ストリームのメモリは無効になります。

### <a name="stream-users"></a>ストリーム ユーザー
使用して post-decode ソース ストリームに関連付けられているリモート ユーザーの一覧を検査できる`post_decode_audio_source_stream::get_users()`します。 使用して post-decode シンクのストリームに関連付けられているローカル ユーザーの一覧を検査できる`post_decode_audio_sink_stream::get_users()`します。

### <a name="audio-formats"></a>オーディオ形式
使用してゲームのチャット 2 から、アプリを取得するバッファーのオーディオ形式を検査できる`post_decode_audio_source_stream::get_pre_processed_format()`します。 前処理されたオーディオ形式は、mono の 16 ビット整数 PCM 常になります。

アプリは、ゲームのレンダリングを使用するために送信される操作のバッファーのオーディオ形式の 2 のチャットを伝える必要があります`post_decode_audio_sink_stream::set_processed_format()`します。 処理された形式のオーディオをデコード後シンク ストリームは、これらの前提条件を満たす必要があります。

* 形式は、64 個未満のチャネルが必要です。
* 形式は、16 ビット整数 PCM (最適)、20 ビット整数の PCM (24 ビット コンテナー) を 24 ビットの整数 PCM、32 ビット整数 PCM、または 32 ビット浮動小数点 PCM (16 ビット整数の PCM の後に希望の形式) である必要があります。 
* 形式のサンプル レートは、1 秒あたり 1000、200000 のサンプル間でなければなりません。

### <a name="retrieving-and-submitting-audio"></a>オーディオの取得と送信
アプリがクエリできるオーディオ ソース ストリームを使用して処理する使用可能なバッファーの数をデコード後`post_decode_audio_source_stream::get_available_buffer_count()`します。 この情報は、バッファーの最小数が使用可能になるまでアプリがオーディオ処理を延期する場合に使用できます。 10 個のバッファーは各キューに配置後オーディオ ソース ストリームのデコードし、オーディオの遅延は、アプリがドレインすることをお勧め、オーディオのパイプラインでの待機時間が発生の前に、4 つ以上のバッファーをキュー、後のオーディオ ストリームをデコードします。

アプリからのオーディオのバッファーを取得できるを使用してオーディオ ソース ストリームのデコード後`post_decode_audio_source_stream::get_next_buffer()`します。 新しいオーディオ バッファーは、平均で 40 ミリ秒に 1 回使用可能になります。 このメソッドによって返されるバッファーは、使い終わったら `post_decode_audio_source_stream::return_buffer()` にリリースされる必要があります。 最大 10 個のキューに置かれたまたは unreturned バッファーは、特定の時点に存在できる、ポスト オーディオ ソース ストリームのデコードします。 この制限に達すると、リモート プレーヤーから新しいのデコードされたバッファーは未解決のバッファーの一部が返されるまでに削除されます。

チャット 2 ~ ゲームに戻るの検査と操作のバッファーのレンダリングを使用するためのシンクのオーディオ ストリームのデコード後のアプリを送信できる`post_decode_audio_sink_stream::submit_mixed_buffer()`します。 ゲームのチャット 2 にインプレースとな場所のオーディオ操作がサポートされている場合にバッファーが送信されるので`post_decode_audio_sink_stream::submit_mixed_buffer()`から取得した同じバッファーを必ずしも`post_decode_audio_source_stream::get_next_buffer()`します。 すべての 40 オーディオのストリームからの次の 40 がレンダリングされます。 オーディオの中断を防ぐため、連続して聞こえるオーディオのバッファーは一定のレートでこのストリームに送信する必要があります。

### <a name="privacy-and-mixing"></a>プライバシーとの混合
Post-decode パイプラインのソース シンク モデルでは、ため、アプリの責任から取得したバッファーを混在させることが`post_decode_audio_source_stream`オブジェクトし、を混在バッファーを送信`post_decode_audio_sink_stream`レンダリング オブジェクト。 つまりミックスには、適切なプライバシーと適用の特権を使用して実行するアプリの責任です。 ゲームのチャット 2 では`post_decode_audio_sink_stream::can_receive_audio_from_source_stream()`簡単かつ効率的にこの情報の照会します。

### <a name="chat-indicators"></a>チャットの評価指標

オーディオをデコード後の操作には、各ユーザーのチャット インジケーターの状態は変わりません。 たとえば、リモート ユーザーがミュートされてとは、オーディオは、アプリに提供されますが、そのリモート ユーザーのチャット インジケーターがミュートされても示します。 リモート ユーザーと対話するとき、オーディオが提供されますが、アプリは、そのユーザーからオーディオを含むオーディオを混在させるかどうかに関係なくと通信をチャット インジケーターが表示されます。 UI とチャット インジケーターの詳細については、次を参照してください。[を使用してゲームのチャット 2](using-game-chat-2.md#ui)します。 ユーザーがオーディオのミックス内に存在するかを決定する余分なアプリに固有の制限を使用する場合は、ゲーム チャット 2 によって提供されるチャット インジケーターを読み取るときに、その同じ制限を考慮するアプリの責任です。

### <a name="stream-contexts"></a>ストリーム コンテキスト
アプリは、カスタムのポインター-サイズのコンテキストの値を管理できますを使用して、オーディオ ストリームのデコード後で、`set_custom_stream_context()`と`custom_stream_context()`メソッド。 これらのカスタム ストリーム コンテキストはゲーム チャット 2 のオーディオ ストリームと補助データ間のマッピングを作成するために役立ちます。 メタデータ、ゲームの状態などのストリーム。

### <a name="example"></a>例
ここで使用する方法が簡略化されたエンド ツー エンド サンプルは、1 つのオーディオ処理フレームでオーディオ ストリームのデコード後。

```cpp
uint32_t streamStateChangeCount;
game_chat_stream_state_change_array streamStateChanges;
chat_manager::singleton_instance().start_processing_stream_state_changes(&streamStateChangeCount, &streamStateChanges);

for (uint32_t streamStateChangeIndex = 0; streamStateChangeIndex < streamStateChangeCount; ++streamStateChangeIndex)
{
    switch (streamStateChanges[streamStateChangeIndex]->state_change_type)
    {
        case game_chat_stream_state_change_type::post_decode_audio_source_stream_created:
        {
            post_decode_audio_source_stream* stream = streamStateChanges[streamStateChangeIndex]->post_decode_audio_source_stream;
            stream->set_custom_stream_context(...);
            HandlePostDecodeAudioSourceStreamCreated(stream);
            break;
        }

        case game_chat_stream_state_change_type::post_decode_audio_source_stream_closed:
        {
            HandlePostDecodeAudioSourceStreamClosed(stream);
            break;
        }

        case game_chat_stream_state_change_type::post_decode_audio_source_stream_destroyed:
        {
            HandlePostDecodeAudioSourceStreamDestroyed(stream);
            break;
        }

        case game_chat_stream_state_change_type::post_decode_audio_sink_stream_created:
        {
            post_decode_audio_sink_stream* stream = streamStateChanges[streamStateChangeIndex]->post_decode_audio_sink_stream;
            stream->set_custom_stream_context(...);
            stream->set_processed_format(...);
            HandlePostDecodeAudioSinkStreamCreated(stream);
            break;
        }

        case game_chat_stream_state_change_type::post_decode_audio_sink_stream_closed:
        {
            HandlePostDecodeAudioSinkStreamClosed(stream);
            break;
        }

        case game_chat_stream_state_change_type::post_decode_audio_sink_stream_destroyed:
        {
            HandlePostDecodeAudioSinkStreamDestroyed(stream);
            break;
        }

        ...
    }
}

chat_manager::singleton_instance().finish_processing_stream_state_changes(streamStateChanges);

uint32_t sourceStreamCount;
post_decode_audio_source_stream_array sourceStreams;
chatManager::singleton_instance().get_post_decode_audio_source_streams(&sourceStreamCount, &sourceStreams);

uint32_t sinkStreamCount;
post_decode_audio_sink_stream_array sinkStreams;
chatManager::singleton_instance().get_post_decode_audio_sink_streams(&sinkStreamCount, &sinkStreams);

//
// MixBuffer is a custom type defined as:
// struct MixBuffer
// {
//     uint32_t bufferByteCount;
//     void* buffer;
// };
//
std::vector<std::pair<post_decode_audio_source_stream*, MixBuffer>> cachedSourceBuffers;

for (uint32_t sourceStreamIndex = 0; sourceStreamIndex < sourceStreamCount; ++sourceStreamIndex)
{
    post_decode_audio_source_stream* sourceStream = sourceStreams[sourceStreamIndex];

    MixBuffer mixBuffer;
    sourceStream->get_next_buffer(&mixBuffer.bufferByteCount, &mixBuffer.buffer);
    if (buffer != nullptr)
    {
        // Stash the buffer to return after we are done with mixing. If this program was using audio middleware, now
        // would be an appropriate time to plumb the buffer through the middleware
        cachedSourceBuffer.push_back(std::pair<post_decode_audio_source_stream*, MixBuffer>{sourceStream, mixBuffer});
    }
}

// Loop over each sink stream, perform mixing, and submit
for (uint32_t sinkStreamIndex = 0; sinkStreamIndex < sinkStreamCount; ++sinkStreamIndex)
{
    post_decode_audio_sink_stream* sinkStream = sinkStreams[sinkStreamIndex];

    if (sinkStream->is_open())
    {
        std::vector<std::pair<MixBuffer, float>> buffersToMixForThisStream;

        for (const std::pair<post_decode_audio_source_stream, MixBuffer>& sourceBufferPair : cachedSourceBuffers)
        {
            float volume;
            if (sinkStream->can_receive_audio_from_source_stream(sourceBufferPair.first, &volume))
            {
                buffersToMixForThisStream.push_back(std::pair<MixBuffer, float>{sourceBufferPair.second, volume});
            }
        }

        if (buffersToMixForThisStream.size() > 0)
        {
            uint32_t mixedBufferByteCount;
            uint8_t* mixedBuffer;
            MixPostDecodeBuffers(buffersToMixForThisStream, &mixedBufferByteCount, &mixedBuffer);
            sinkStream->submit_mixed_buffer(mixedBufferByteCount, mixedBuffer);
        }
    }
}

// Return buffers after mix and submission
for (const std::pair<post_decode_audio_source_stream*, MixBuffer>& cachedSourceBuffer : cachedSourceBuffers)
{
    post_decode_audio_source_stream* sourceStream = cachedSourceBuffer.first;
    void* bufferToReturn = cachedSourceBuffer.second.buffer;
    sourceStream->return_buffer(bufferToReturn);
}

Sleep(audioProcessingPeriodInMilliseconds);
```

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
            CleanupPreEncodeAudioStreamResources(streamStateChanges[streamStateChangeIndex].pre_encode_audio_stream);
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
            streamStateChanges[streamStateChangeIndex].pre_encode_audio_stream->get_users(&chatUserCount, &chatUsers);
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
