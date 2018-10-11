---
title: リアルタイム オーディオ操作
author: KevinAsgari
description: ゲーム チャット 2 によってキャプチャされたチャット オーディオを操作および処理する方法について説明します。
ms.author: kevinasg
ms.date: 05/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信, バッファー操作, オーディオ操作
ms.localizationpriority: medium
ms.openlocfilehash: 4d5f9863bf4a023520486567de1f5feb1907b177
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4532135"
---
# <a name="real-time-audio-manipulation"></a>リアルタイム オーディオ操作

ゲーム チャット 2 は、開発者を検査して、プレイヤーのチャット オーディオ データを操作するチャット オーディオ パイプラインに挿入してオプションを示します。 これは、ゲームでおもしろいオーディオ エフェクトをプレイヤーの声に適用するのに役立ちます。 ゲーム チャット 2 のオーディオ操作パイプラインは、オーディオ データ用にポーリングできるオーディオ ストリーム オブジェクトを通じて連携します。 コールバックを使うのとは対照的に、このモデルでは開発者にとって最も便利な処理スレッドでオーディオを検査または操作できます。

以下では、リアルタイム オーディオ操作の使用方法を簡単に説明します。次のトピックがあります。

1. [オーディオ操作パイプラインの初期化](#initializing-the-audio-manipulation-pipeline)
2. [オーディオ ストリームの状態の変化の処理](#processing-audio-stream-state-changes)
3. [プリエンコード チャット オーディオの操作](#manipulating-pre-encode-chat-audio-data)
4. [ポストデコード チャット オーディオの操作](#manipulating-post-decode-chat-audio-data)
5. [チャット ユーザーの有効期間](#chat-user-lifetimes)

## <a name="initializing-the-audio-manipulation-pipeline"></a>オーディオ操作パイプラインの初期化

既定でゲーム チャット 2 はリアルタイム オーディオ操作を有効になりません。 リアルタイム オーディオ操作を有効にするアプリする必要がありますを指定するオーディオ操作の形式で有効になっている`chat_manager::initialize()`audioManipulationMode パラメーターを設定します。

現在のところ、次のオーディオ操作形式がサポートされています。

* `game_chat_audio_manipulation_mode_flags::none` - オーディオ操作を無効にします。 これは既定の構成です。 このモードでは、チャット オーディオが常時流し込まれます。
* `game_chat_audio_manipulation_mode_flags::pre_encode_stream_manipulation` - プリエンコード オーディオ操作を有効にします。 このモードでは、ローカル ユーザーによって生成されたすべてのチャット オーディオが、エンコード前にオーディオ操作パイプラインを通じて取り込まれます。 場合でも、アプリは、チャット オーディオ データを検査および操作されませんのみが、エンコードして転送できるように、ゲーム チャット 2 に改変されていないオーディオ バッファーを提出するアプリの責任ではあります。
* `game_chat_audio_manipulation_mode_flags::post_decode_stream_manipulation` - ポストデコード オーディオ操作を有効にします。 このモードは現在開発中のため、使用しないでください。

## <a name="processing-audio-stream-state-changes"></a>オーディオ ストリームの状態の変化の処理

ゲーム チャット 2 を通じてオーディオ ストリームの状態に更新プログラムを提供する`game_chat_stream_state_change`構造体。 これらの更新には、更新されたストリームとその更新内容に関する情報が格納されています。 `chat_manager::start_processing_stream_state_changes()` および `chat_manager::finish_processing_stream_state_changes()` のメソッド ペアを呼び出すことにより、これらの更新をポーリングできます。 このメソッド ペアは、キューに入れられた最新のオーディオ ストリームの状態の更新すべてを `game_chat_stream_state_change` 構造体ポインターの配列として提供します。 アプリは、配列を反復処理し、各更新を適切に処理する必要があります。 1 回使用可能なすべて`game_chat_stream_state_change`更新プログラムが処理された、を通じてゲーム チャット 2 に、その配列を渡す必要があります`chat_manager::finish_processing_stream_state_changes()`します。 例:

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

ゲーム チャット 2 プリエン コード チャット オーディオ データを通じてローカル ユーザーへのアクセスを提供する、`pre_encode_audio_stream`クラスです。

### <a name="stream-lifetime"></a>ストリームの有効期間
新しい`pre_encode_audio_stream`インスタンスは、アプリで利用できる状態になりますが、を通じて配信されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_created`します。 オーディオ ストリームを可能になりますゲーム チャット 2 にこのストリーム状態の変化が返されると、プリエン コード オーディオ操作を実行します。

既存のとき`pre_encode_audio_stream`になる提供を停止すると、オーディオ操作を使用して、アプリによって通知されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_closed`します。 アプリは、この機会にこのオーディオ ストリームに関連付けられたリソースのクリーンアップを開始できます。 ゲーム チャット 2 に、このストリーム状態の変化が返されると、オーディオ ストリームにできなくなりますプリエン コード オーディオ操作を実行します。

閉じられた`pre_encode_audio_stream`がすべてのリソースが返される、ストリームが破棄され、アプリによって通知されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed`します。 このストリームへの参照またはポインターをすべてクリーンアップする必要があります。 ゲーム チャット 2 にこのストリーム状態の変化が返されると、オーディオ ストリーム メモリが無効になります。

### <a name="stream-users"></a>ストリーム ユーザー
ストリームに関連付けられているユーザーのリストは、`pre_encode_audio_stream::get_users()` を使って検査できます。

### <a name="audio-formats"></a>オーディオ形式
アプリがゲーム チャット 2 から取得するバッファーのオーディオ形式を使って検査できます`pre_encode_audio_stream::get_pre_processed_format()`します。 前処理されたオーディオ形式は常にモノラルになります。 アプリは、32 ビット浮動小数点値、16 ビット整数値、および 32 ビット整数値として表されるデータを処理することを予期する必要があります。

アプリはそれをエンコードおよび転送を使用して送信されている操作対象のバッファーのオーディオ形式のゲーム チャット 2 に通知する必要があります`pre_encode_audio_stream::set_processed_format()`します。 プリエンコード オーディオ ストリームの処理形式は、以下の前提条件を満たしている必要があります。

* 形式はモノラルでなければなりません。
* 形式は 32 ビット浮動小数点 PCM、32 ビット整数 PCM、または 16 ビット整数 PCM 形式である必要があります。
* 形式のサンプル レートは、そのプラットフォームに基づく前提条件に従う必要があります。 Xbox One ERA では、8 kHz、12 kHz、16 kHz、および 24 kHz のサンプル レートがサポートされています。 Xbox One および PC 用の UWP では、8 kHz、12 kHz、16 kHz、24 kHz、32 kHz、44.1 kHz、および 48 kHz のサンプル レートがサポートされています。

### <a name="retrieving-and-submitting-audio"></a>オーディオの取得と送信
アプリは、プリエンコード オーディオ ストリームで、`pre_encode_audio_stream::get_available_buffer_count()` を使って処理可能なバッファーの数を照会できます。 この情報は、バッファーの最小数が使用可能になるまでアプリがオーディオ処理を延期する場合に使用できます。 キューに入れることができるバッファーはプリエンコード オーディオ ストリームごとに 10 個だけであり、オーディオの遅延によりオーディオ パイプラインに待機時間が生じるため、キュー内のバッファーが 4 個を超える前にアプリがプリエンコード オーディオ ストリームをドレインすることをお勧めします。

アプリは、`pre_encode_audio_stream::get_next_buffer()` を使ってプリエンコード オーディオ ストリームからオーディオ バッファーを取得できます。 新しいオーディオ バッファーは、平均で 40 ミリ秒に 1 回使用可能になります。 このメソッドによって返されるバッファーは、使い終わったら `pre_encode_audio_stream::return_buffer()` にリリースされる必要があります。 プリエンコード オーディオ ストリームには、キューに入れられたバッファーまたは返されていないバッファーが任意の時点で最大 10 個存在することができます。 この制限に達すると、未処理のバッファーの一部が返されるまで、プレイヤーのオーディオ ソースからキャプチャされた新しいバッファーが破棄されます。

アプリは、エンコードおよび転送の使用のゲーム チャット 2 に戻るに検査および操作済みのバッファーを送信できる`pre_encode_audio_stream::submit_buffer()`します。 ゲーム チャット 2 には、インプレースおよびアウトな場所のオーディオ操作がサポートするために送信されるバッファー`pre_encode_audio_stream::submit_buffer()`必ずしもしなくても、同じから取得されるバッファー`pre_encode_audio_stream::get_next_buffer()`します。 これらの送信バッファーのプライバシー/特権は、このストリームに関連付けられているユーザーに基づいて適用されます。 40 ミリ秒ごとに、このストリームから取得される次の 40 ミリ秒間のオーディオがエンコードされて転送されます。 オーディオの中断を防ぐため、連続して聞こえるオーディオのバッファーは一定のレートでこのストリームに送信する必要があります。

### <a name="stream-contexts"></a>ストリーム コンテキスト
アプリは、`pre_encode_audio_stream::set_custom_stream_context()` と `pre_encode_audio_stream::custom_stream_context()` を使って、プリエンコード オーディオ ストリームでカスタム ポインター サイズのコンテキスト値を管理できます。 これらのカスタム ストリーム コンテキストは、ゲーム チャット 2 のオーディオ ストリームと補助データ間のマッピングを作成するために役立ちます。 ストリームのメタデータ、ゲームの状態などです。

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

ゲーム チャット 2 を使ったチャット オーディオ データをポストデ コードへのアクセスを提供する、`post_decode_audio_source_stream`と`post_decode_audio_sink_stream`クラス、ユーザーがチャット オーディオのローカル各受信側のリモート ユーザーからのオーディオを一意に操作ができるようにします。

### <a name="sources-and-sinks"></a>ソースとシンク
Pre-encode パイプラインとは異なり、モデルの処理とポストデ コード オーディオ データの分割 2 つのクラス:`post_decode_audio_source_stream`と`post_decode_audio_sink_stream`します。 リモート ユーザーからデコードされたオーディオから取得できる`post_decode_audio_source_stream`オブジェクト、操作、およびに送信される`post_decode_audio_sink_stream`レンダリング用のオブジェクト。 これにより、ゲーム チャット 2 の間の統合は、オーディオ処理パイプラインと有用オーディオ ミドルウェアにポストデ コードのできます。

### <a name="stream-lifetime"></a>ストリームの有効期間
新しい`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`インスタンスは、アプリで利用できる状態になりますが、を通じて配信されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_created`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream_created`それぞれ、します。 オーディオ ストリームを可能になりますゲーム チャット 2 にこのストリーム状態の変化が返されると、ポストデ コード オーディオ操作します。

既存のとき`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`になる提供を停止すると、オーディオ操作を使用して、アプリによって通知されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_closed`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream`それぞれ、します。 アプリは、この機会にこのオーディオ ストリームに関連付けられたリソースのクリーンアップを開始できます。 ゲーム チャット 2 に、このストリーム状態の変化が返されると、オーディオ ストリームにできなくなりますポストデ コード オーディオ操作します。 ソースのストリーム バッファーがありませんがキューの操作にことを意味します。 シンク ストリームは、バッファーは表示されなくなったを送信することを意味します。

閉じられた`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`がすべてのリソースが返される、ストリームが破棄され、アプリによって通知されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_destroyed`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream_destroyed`それぞれ、します。 このストリームへの参照またはポインターをすべてクリーンアップする必要があります。 ゲーム チャット 2 にこのストリーム状態の変化が返されると、オーディオ ストリーム メモリが無効になります。

### <a name="stream-users"></a>ストリーム ユーザー
Post-decode ソース ストリームに関連付けられているリモート ユーザーの一覧を使って検査できます`post_decode_audio_source_stream::get_users()`します。 Post-decode シンク ストリームに関連付けられているローカル ユーザーの一覧を使って検査できます`post_decode_audio_sink_stream::get_users()`します。

### <a name="audio-formats"></a>オーディオ形式
アプリがゲーム チャット 2 から取得するバッファーのオーディオ形式を使って検査できます`post_decode_audio_source_stream::get_pre_processed_format()`します。 前処理されたオーディオ形式では、モノラル、16 ビット整数 PCM は常になります。

アプリはレンダリングを使用するために送信されている操作対象のバッファーのオーディオ形式のゲーム チャット 2 に通知する必要があります`post_decode_audio_sink_stream::set_processed_format()`します。 ポストデ コード オーディオの処理形式はシンク ストリームは、以下の前提条件を満たす必要があります。

* 形式は、64 個未満のチャネルが必要です。
* 形式は、16 ビット整数 PCM (最適な)、20 ビット整数 PCM (24 ビット コンテナー) で、24 ビット整数 PCM、32 ビット整数 PCM、または 32 ビット浮動小数点 PCM (16 ビット整数 PCM 後の優先形式) である必要があります。 
* 形式のサンプル レートは、1 秒あたり 1,000 と 200000 サンプルの間である必要があります。

### <a name="retrieving-and-submitting-audio"></a>オーディオの取得と送信
アプリを照会できますポストデ コード オーディオ ソースのストリームを使って処理可能なバッファーの数の`post_decode_audio_source_stream::get_available_buffer_count()`します。 この情報は、バッファーの最小数が使用可能になるまでアプリがオーディオ処理を延期する場合に使用できます。 10 個のバッファーが各キューに入れられますポストデ コード オーディオ ソースのストリームありオーディオ遅延によりオーディオ パイプラインに待機時間ので、アプリがドレインをお勧めしますが、4 つ以上のバッファーのキューに入れる前に、オーディオ ストリームをポストデ コードします。

アプリからオーディオ バッファーを取得できる、ポストデ コード オーディオ ソースのストリームを使用して`post_decode_audio_source_stream::get_next_buffer()`します。 新しいオーディオ バッファーは、平均で 40 ミリ秒に 1 回使用可能になります。 このメソッドによって返されるバッファーは、使い終わったら `post_decode_audio_source_stream::return_buffer()` にリリースされる必要があります。 最大で 10 のキューに入れられたバッファーまたはできます存在の任意の時点で、ポストデ コード オーディオ ソース ストリームします。 この制限に達すると、新しいデコードされたリモート プレイヤーからはまでバッファーが破棄未処理のバッファーの一部が返されます。

アプリがを通じてゲーム チャット 2 に戻るに検査および操作済みのバッファーは、レンダリングを使用するためのシンク オーディオ ストリームをポストデ コードを送信できる`post_decode_audio_sink_stream::submit_mixed_buffer()`します。 ゲーム チャット 2 には、インプレースおよびアウトな場所のオーディオ操作がサポートするために送信されるバッファー`post_decode_audio_sink_stream::submit_mixed_buffer()`必ずしもしなくても、同じから取得されるバッファー`post_decode_audio_source_stream::get_next_buffer()`します。 40 ミリ秒に、このストリームからのオーディオの次の 40 が表示されます。 オーディオの中断を防ぐため、連続して聞こえるオーディオのバッファーは一定のレートでこのストリームに送信する必要があります。

### <a name="privacy-and-mixing"></a>プライバシーとミキシング
Post-decode パイプラインのソース シンクのモデルがあるため、アプリのする責任はから取得されたバッファーを混在させる`post_decode_audio_source_stream`オブジェクトし、混合のバッファーに`post_decode_audio_sink_stream`オブジェクトをレンダリングします。 これは、適切なプライバシーと特権が適用されると、ミックスを実行するアプリの責任があることも意味します。 ゲーム チャット 2 は、`post_decode_audio_sink_stream::can_receive_audio_from_source_stream()`シンプルで効率的なは、この情報のクエリを作成します。

### <a name="chat-indicators"></a>チャット インジケーター

ポストデ コード オーディオ操作には、各ユーザーのチャット インジケーターの状態は変わりません。 たとえば、リモート ユーザーがミュートされている場合、オーディオが、アプリに提供されますが、そのリモート ユーザーのチャット インジケーターがミュートも示されます。 リモート ユーザーを説明すると、するとき、オーディオが提供されますが、チャット インジケーターは、アプリがそのユーザーからオーディオを含むオーディオのミックスを提供するかどうかに関係なく会話を示します。 UI とチャット インジケーターの詳細については、[ゲーム チャット 2 の使用](using-game-chat-2.md#ui)を参照してください。 余分なアプリに固有の制限を使用して、ユーザーがオーディオのミックスに存在するかを決定した場合、アプリのする責任は読み取りチャット インジケーターをゲーム チャット 2 によって提供されるときに、それらの同じ制限を考慮してください。

### <a name="stream-contexts"></a>ストリーム コンテキスト
アプリでカスタム ポインター サイズのコンテキスト値を管理できますを使用して、オーディオ ストリームをポストデ コードで、`set_custom_stream_context()`と`custom_stream_context()`メソッドです。 これらのカスタム ストリーム コンテキストは、ゲーム チャット 2 のオーディオ ストリームと補助データ間のマッピングを作成するために役立ちます。 ストリームのメタデータ、ゲームの状態などです。

### <a name="example"></a>例
使用する方法に関する簡単なエンド ツー エンド サンプルを次に示しますポストデ コード オーディオ ストリームで 1 つのオーディオ処理フレーム。

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
