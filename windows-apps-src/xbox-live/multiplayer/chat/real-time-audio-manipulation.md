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
# <a name="real-time-audio-manipulation"></a><span data-ttu-id="956a2-104">リアルタイム オーディオ操作</span><span class="sxs-lookup"><span data-stu-id="956a2-104">Real-time audio manipulation</span></span>

<span data-ttu-id="956a2-105">ゲームのチャット 2 は、自身に検査してプレーヤーのチャットのオーディオ データを操作するチャット オーディオ パイプラインに挿入するためのオプションを開発者に提供します。</span><span class="sxs-lookup"><span data-stu-id="956a2-105">Game Chat 2 gives developers the option to insert themselves into the chat audio pipeline to inspect and manipulate the players' chat audio data.</span></span> <span data-ttu-id="956a2-106">これは、ゲームでおもしろいオーディオ エフェクトをプレイヤーの声に適用するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="956a2-106">This can be useful for applying interesting audio effects to players' voices in game.</span></span> <span data-ttu-id="956a2-107">ゲーム チャット 2 のオーディオの操作のパイプラインは、オーディオ データをポーリングすることができますのオーディオ ストリーム オブジェクトを介して連携。</span><span class="sxs-lookup"><span data-stu-id="956a2-107">Game Chat 2's audio manipulation pipeline is interacted with through audio stream objects that can be polled for audio data.</span></span> <span data-ttu-id="956a2-108">コールバックを使うのとは対照的に、このモデルでは開発者にとって最も便利な処理スレッドでオーディオを検査または操作できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-108">As opposed to using callbacks, this model allows developers to inspect or manipulate audio on whatever processing thread is most convenient for them.</span></span>

<span data-ttu-id="956a2-109">以下では、リアルタイム オーディオ操作の使用方法を簡単に説明します。次のトピックがあります。</span><span class="sxs-lookup"><span data-stu-id="956a2-109">A brief walkthrough using real-time audio manipulation is featured below, containing the following topics:</span></span>

1. [<span data-ttu-id="956a2-110">オーディオ操作パイプラインを初期化しています</span><span class="sxs-lookup"><span data-stu-id="956a2-110">Initializing the audio manipulation pipeline</span></span>](#initializing-the-audio-manipulation-pipeline)
2. [<span data-ttu-id="956a2-111">オーディオ ストリームの状態変更の処理</span><span class="sxs-lookup"><span data-stu-id="956a2-111">Processing audio stream state changes</span></span>](#processing-audio-stream-state-changes)
3. [<span data-ttu-id="956a2-112">チャットのオーディオをエンコード済みの操作</span><span class="sxs-lookup"><span data-stu-id="956a2-112">Manipulating pre-encode chat audio</span></span>](#manipulating-pre-encode-chat-audio-data)
4. [<span data-ttu-id="956a2-113">チャットのオーディオをデコード後の操作</span><span class="sxs-lookup"><span data-stu-id="956a2-113">Manipulating post-decode chat audio</span></span>](#manipulating-post-decode-chat-audio-data)
5. [<span data-ttu-id="956a2-114">チャットのユーザー有効期間</span><span class="sxs-lookup"><span data-stu-id="956a2-114">Chat user lifetimes</span></span>](#chat-user-lifetimes)

## <a name="initializing-the-audio-manipulation-pipeline"></a><span data-ttu-id="956a2-115">オーディオ操作パイプラインの初期化</span><span class="sxs-lookup"><span data-stu-id="956a2-115">Initializing the audio manipulation pipeline</span></span>

<span data-ttu-id="956a2-116">既定では、ゲームのチャット 2 がリアルタイムの音声操作を有効になりません。</span><span class="sxs-lookup"><span data-stu-id="956a2-116">Game Chat 2 by default will not enable real-time audio manipulation.</span></span> <span data-ttu-id="956a2-117">リアルタイムの音声操作を有効にするアプリする必要があります指定なオーディオの操作のどのフォームで有効になっている`chat_manager::initialize()`audioManipulationMode パラメーターを設定します。</span><span class="sxs-lookup"><span data-stu-id="956a2-117">To enable real-time audio manipulation, the app must specify which form(s) of audio manipulation it would like enabled in `chat_manager::initialize()` by setting the audioManipulationMode parameter.</span></span>

<span data-ttu-id="956a2-118">現在のところ、次のオーディオ操作形式がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="956a2-118">Currently, the following audio manipulation forms are supported:</span></span>

* <span data-ttu-id="956a2-119">`game_chat_audio_manipulation_mode_flags::none` -オーディオの操作を無効にします。</span><span class="sxs-lookup"><span data-stu-id="956a2-119">`game_chat_audio_manipulation_mode_flags::none` - Disables audio manipulation.</span></span> <span data-ttu-id="956a2-120">これは既定の構成です。</span><span class="sxs-lookup"><span data-stu-id="956a2-120">This is the default configuration.</span></span> <span data-ttu-id="956a2-121">このモードでは、チャット オーディオが常時流し込まれます。</span><span class="sxs-lookup"><span data-stu-id="956a2-121">In this mode, chat audio will flow uninterrupted.</span></span>
* <span data-ttu-id="956a2-122">`game_chat_audio_manipulation_mode_flags::pre_encode_stream_manipulation` をオーディオ操作の事前エンコード有効にします。</span><span class="sxs-lookup"><span data-stu-id="956a2-122">`game_chat_audio_manipulation_mode_flags::pre_encode_stream_manipulation` - Enables pre-encode audio manipulation.</span></span> <span data-ttu-id="956a2-123">このモードでは、ローカル ユーザーによって生成されたすべてのチャット オーディオが、エンコード前にオーディオ操作パイプラインを通じて取り込まれます。</span><span class="sxs-lookup"><span data-stu-id="956a2-123">In this mode, all chat audio generated by local users will be fed through the audio manipulation pipeline before it is encoded.</span></span> <span data-ttu-id="956a2-124">アプリは、チャットのオーディオ データを検査して、操作しないのみが、場合でもエンコードして送信できるように、ゲームのチャット 2 に変更されていないオーディオ バッファーを送信するアプリの責任ではまだします。</span><span class="sxs-lookup"><span data-stu-id="956a2-124">Even if the app is only inspecting the chat audio data and not manipulating it, it is still the app's responsibility to submit the unaltered audio buffers back to Game Chat 2 so that they can be encoded and transmitted.</span></span>
* <span data-ttu-id="956a2-125">`game_chat_audio_manipulation_mode_flags::post_decode_stream_manipulation` -有効では、オーディオ操作後デコードします。</span><span class="sxs-lookup"><span data-stu-id="956a2-125">`game_chat_audio_manipulation_mode_flags::post_decode_stream_manipulation` - Enables post-decode audio manipulation.</span></span> <span data-ttu-id="956a2-126">このモードでは、受信側がレンダリングされる前に、デコード後にリモート ユーザーから受信したすべてのチャット オーディオ オーディオ操作パイプラインを介して与えられます。</span><span class="sxs-lookup"><span data-stu-id="956a2-126">In this mode, all chat audio received from remote users will be fed through the audio manipulation pipeline after it is decoded by the receiver but before it is rendered.</span></span> <span data-ttu-id="956a2-127">アプリは、チャットのオーディオ データを検査して、操作しないのみが、場合でもを混在させるし、表示できるように、ゲームのチャット 2 に変更されていないオーディオ バッファーを送信するアプリの責任ではまだします。</span><span class="sxs-lookup"><span data-stu-id="956a2-127">Even if the app is only inspecting the chat audio data and not manipulating it, it is still the app's responsibility to mix and submit the unaltered audio buffers back to Game Chat 2 so that they can be rendered.</span></span>

## <a name="processing-audio-stream-state-changes"></a><span data-ttu-id="956a2-128">オーディオ ストリームの状態の変化の処理</span><span class="sxs-lookup"><span data-stu-id="956a2-128">Processing audio stream state changes</span></span>

<span data-ttu-id="956a2-129">ゲームのチャット 2 からオーディオ ストリームの状態に更新プログラムを提供する`game_chat_stream_state_change`構造体。</span><span class="sxs-lookup"><span data-stu-id="956a2-129">Game Chat 2 provides updates to the state of audio streams through `game_chat_stream_state_change` structures.</span></span> <span data-ttu-id="956a2-130">これらの更新には、更新されたストリームとその更新内容に関する情報が格納されています。</span><span class="sxs-lookup"><span data-stu-id="956a2-130">These updates store information about which stream has been updated and how it has been updated.</span></span> <span data-ttu-id="956a2-131">`chat_manager::start_processing_stream_state_changes()` および `chat_manager::finish_processing_stream_state_changes()` のメソッド ペアを呼び出すことにより、これらの更新をポーリングできます。</span><span class="sxs-lookup"><span data-stu-id="956a2-131">These updates can be polled for through calls to the `chat_manager::start_processing_stream_state_changes()` and `chat_manager::finish_processing_stream_state_changes()` pair of methods.</span></span> <span data-ttu-id="956a2-132">このメソッド ペアは、キューに入れられた最新のオーディオ ストリームの状態の更新すべてを `game_chat_stream_state_change` 構造体ポインターの配列として提供します。</span><span class="sxs-lookup"><span data-stu-id="956a2-132">This pair of methods provides all of the latest, queued audio stream state updates as an array of `game_chat_stream_state_change` structure pointers.</span></span> <span data-ttu-id="956a2-133">アプリは、配列を反復処理し、各更新を適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-133">Apps should iterate over the array and handle each update appropriately.</span></span> <span data-ttu-id="956a2-134">1 回使用可能なすべて`game_chat_stream_state_change`更新プログラムが処理されて、その配列を渡すチャット 2 ~ ゲームに戻る必要があります`chat_manager::finish_processing_stream_state_changes()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-134">Once all available `game_chat_stream_state_change` updates have been handled, that array should be passed back to Game Chat 2 through `chat_manager::finish_processing_stream_state_changes()`.</span></span> <span data-ttu-id="956a2-135">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="956a2-135">For example:</span></span>

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

## <a name="manipulating-pre-encode-chat-audio-data"></a><span data-ttu-id="956a2-136">プリエンコード チャット オーディオ データの操作</span><span class="sxs-lookup"><span data-stu-id="956a2-136">Manipulating pre-encode chat audio data</span></span>

<span data-ttu-id="956a2-137">ゲームのチャット 2 を通じてユーザーがローカルのチャット オーディオ データの事前エンコードへのアクセスを提供する、`pre_encode_audio_stream`クラス。</span><span class="sxs-lookup"><span data-stu-id="956a2-137">Game Chat 2 provides access to pre-encode chat audio data for local users through the `pre_encode_audio_stream` class.</span></span>

### <a name="stream-lifetime"></a><span data-ttu-id="956a2-138">ストリームの有効期間</span><span class="sxs-lookup"><span data-stu-id="956a2-138">Stream Lifetime</span></span>
<span data-ttu-id="956a2-139">新しい`pre_encode_audio_stream`インスタンスが使用するアプリの準備ができて、経由で配信されることを`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_created`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-139">When a new `pre_encode_audio_stream` instance is ready for the app to use, it will be delivered through a `game_chat_stream_state_change` structure with it's `state_change_type` field set to `game_chat_stream_state_change_type::pre_encode_audio_stream_created`.</span></span> <span data-ttu-id="956a2-140">オーディオ ストリームが使用可能になるゲーム チャット 2 にこのストリームの状態の変更が返されると、オーディオの操作を事前にエンコードします。</span><span class="sxs-lookup"><span data-stu-id="956a2-140">Once this stream state change is returned to Game Chat 2, the audio stream will become available for pre-encode audio manipulation.</span></span>

<span data-ttu-id="956a2-141">既存`pre_encode_audio_stream`がオーディオの操作を使用して、使用不可能、アプリが通知されますを通じて、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_closed`。</span><span class="sxs-lookup"><span data-stu-id="956a2-141">When an existing `pre_encode_audio_stream` becomes unavailable to use for audio manipulation, the app will be notified through a `game_chat_stream_state_change` structure with it's `state_change_type` field set to `game_chat_stream_state_change_type::pre_encode_audio_stream_closed`.</span></span> <span data-ttu-id="956a2-142">アプリは、この機会にこのオーディオ ストリームに関連付けられたリソースのクリーンアップを開始できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-142">This is the app's opportunity to start cleaning up the resources associated with this audio stream.</span></span> <span data-ttu-id="956a2-143">オーディオ ストリームが使用できなくなりますゲーム チャット 2 にこのストリームの状態の変更が返されると、オーディオの操作を事前にエンコードします。</span><span class="sxs-lookup"><span data-stu-id="956a2-143">Once this stream state change is returned to Game Chat 2, the audio stream will become unavailable for pre-encode audio manipulation.</span></span>

<span data-ttu-id="956a2-144">閉じているときに`pre_encode_audio_stream`がすべてのリソースが戻ると、ストリームが破棄され、を通じて、アプリが通知されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-144">When a closed `pre_encode_audio_stream` has all of it's resources returned, the stream will be destroyed and the app will be notified through a `game_chat_stream_state_change` structure with it's `state_change_type` field set to `game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed`.</span></span> <span data-ttu-id="956a2-145">このストリームへの参照またはポインターをすべてクリーンアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-145">Any references or pointers to this stream should be cleaned up.</span></span> <span data-ttu-id="956a2-146">このストリームの状態の変更がゲームのチャット 2 に返されると、オーディオ ストリームのメモリは無効になります。</span><span class="sxs-lookup"><span data-stu-id="956a2-146">Once this stream state change is returned to Game Chat 2, the audio stream memory will become invalid.</span></span>

### <a name="stream-users"></a><span data-ttu-id="956a2-147">ストリーム ユーザー</span><span class="sxs-lookup"><span data-stu-id="956a2-147">Stream Users</span></span>
<span data-ttu-id="956a2-148">ストリームに関連付けられているユーザーのリストは、`pre_encode_audio_stream::get_users()` を使って検査できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-148">The list of users associated with a stream can be inspected using `pre_encode_audio_stream::get_users()`.</span></span>

### <a name="audio-formats"></a><span data-ttu-id="956a2-149">オーディオ形式</span><span class="sxs-lookup"><span data-stu-id="956a2-149">Audio Formats</span></span>
<span data-ttu-id="956a2-150">使用してゲームのチャット 2 から、アプリを取得するバッファーのオーディオ形式を検査できる`pre_encode_audio_stream::get_pre_processed_format()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-150">The audio format of the buffers the app retrieves from Game Chat 2 can be inspected using `pre_encode_audio_stream::get_pre_processed_format()`.</span></span> <span data-ttu-id="956a2-151">前処理されたオーディオ形式は常にモノラルになります。</span><span class="sxs-lookup"><span data-stu-id="956a2-151">The pre-processed audio format will always be mono.</span></span> <span data-ttu-id="956a2-152">アプリは、32 ビット浮動小数点値、16 ビット整数値、および 32 ビット整数値として表されるデータを処理することを予期する必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-152">The app should expect to handle data represented as 32-bit floats, 16-bit integers, and 32-bit integers.</span></span>

<span data-ttu-id="956a2-153">アプリは、オーディオ形式にエンコードすると、転送を使用して送信される操作のバッファーのゲームのチャット 2 を伝える必要があります`pre_encode_audio_stream::set_processed_format()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-153">The app must inform Game Chat 2 of the audio format of the manipulated buffers that are being submitted to it for encoding and transmission using `pre_encode_audio_stream::set_processed_format()`.</span></span> <span data-ttu-id="956a2-154">プリエンコード オーディオ ストリームの処理形式は、以下の前提条件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-154">Processed formats for pre-encode audio streams must meet these pre-conditions:</span></span>

* <span data-ttu-id="956a2-155">形式はモノラルでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="956a2-155">The format must be mono.</span></span>
* <span data-ttu-id="956a2-156">形式は 32 ビット浮動小数点 PCM、32 ビット整数 PCM、または 16 ビット整数 PCM 形式である必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-156">The format must be 32-bit float PCM, 32-bit integer PCM, or 16-bit integer PCM formats.</span></span>
* <span data-ttu-id="956a2-157">形式のサンプル レートは、そのプラットフォームに基づく前提条件に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-157">The format's sample rate must follow pre-conditions based on it's platform.</span></span> <span data-ttu-id="956a2-158">Xbox One ERA では、8 kHz、12 kHz、16 kHz、および 24 kHz のサンプル レートがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="956a2-158">Xbox One ERA supports 8kHz, 12kHz, 16kHz, and 24kHz sample rates.</span></span> <span data-ttu-id="956a2-159">Xbox One および PC 用の UWP では、8 kHz、12 kHz、16 kHz、24 kHz、32 kHz、44.1 kHz、および 48 kHz のサンプル レートがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="956a2-159">UWP for Xbox One and PC supports 8kHz, 12kHz, 16kHz, 24kHz, 32kHz, 44.1kHz, and 48kHz sample rates.</span></span>

### <a name="retrieving-and-submitting-audio"></a><span data-ttu-id="956a2-160">オーディオの取得と送信</span><span class="sxs-lookup"><span data-stu-id="956a2-160">Retrieving and Submitting Audio</span></span>
<span data-ttu-id="956a2-161">アプリは、プリエンコード オーディオ ストリームで、`pre_encode_audio_stream::get_available_buffer_count()` を使って処理可能なバッファーの数を照会できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-161">Apps can query pre-encode audio streams for the number of available buffers to process using `pre_encode_audio_stream::get_available_buffer_count()`.</span></span> <span data-ttu-id="956a2-162">この情報は、バッファーの最小数が使用可能になるまでアプリがオーディオ処理を延期する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-162">This information can be used if the app would like to delay audio processing until a minimum number of buffers are available.</span></span> <span data-ttu-id="956a2-163">キューに入れることができるバッファーはプリエンコード オーディオ ストリームごとに 10 個だけであり、オーディオの遅延によりオーディオ パイプラインに待機時間が生じるため、キュー内のバッファーが 4 個を超える前にアプリがプリエンコード オーディオ ストリームをドレインすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="956a2-163">Only 10 buffers will be queued on each pre-encode audio stream and audio delays will introduce latency in the audio pipeline, so it's recommended that apps drain their pre-encode audio streams before they queue more than 4 buffers.</span></span>

<span data-ttu-id="956a2-164">アプリは、`pre_encode_audio_stream::get_next_buffer()` を使ってプリエンコード オーディオ ストリームからオーディオ バッファーを取得できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-164">Apps can retrieve audio buffers from a pre-encode audio stream using `pre_encode_audio_stream::get_next_buffer()`.</span></span> <span data-ttu-id="956a2-165">新しいオーディオ バッファーは、平均で 40 ミリ秒に 1 回使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="956a2-165">New audio buffers will be available on average, once every 40ms.</span></span> <span data-ttu-id="956a2-166">このメソッドによって返されるバッファーは、使い終わったら `pre_encode_audio_stream::return_buffer()` にリリースされる必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-166">Buffers returned by this method must be released to `pre_encode_audio_stream::return_buffer()` when they are done being used.</span></span> <span data-ttu-id="956a2-167">プリエンコード オーディオ ストリームには、キューに入れられたバッファーまたは返されていないバッファーが任意の時点で最大 10 個存在することができます。</span><span class="sxs-lookup"><span data-stu-id="956a2-167">A maximum of 10 queued or unreturned buffers can exist at any given time for a pre-encode audio stream.</span></span> <span data-ttu-id="956a2-168">この制限に達すると、未処理のバッファーの一部が返されるまで、プレイヤーのオーディオ ソースからキャプチャされた新しいバッファーが破棄されます。</span><span class="sxs-lookup"><span data-stu-id="956a2-168">Once this limit is reached, new buffers captured from the player's audio source will be dropped until some of the outstanding buffers are returned.</span></span>

<span data-ttu-id="956a2-169">アプリは、エンコードと転送を使用してゲームのチャット 2 に、検査と操作のバッファーを送信できます`pre_encode_audio_stream::submit_buffer()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-169">Apps can submit their inspected and manipulated buffers back to Game Chat 2 for encoding and transmission using `pre_encode_audio_stream::submit_buffer()`.</span></span> <span data-ttu-id="956a2-170">ゲームのチャット 2 にインプレースとな場所のオーディオ操作がサポートされている場合にバッファーが送信されるので`pre_encode_audio_stream::submit_buffer()`から取得した同じバッファーを必ずしも`pre_encode_audio_stream::get_next_buffer()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-170">Game Chat 2 supports in-place and out-of-place audio manipulation, so the buffers submitted to `pre_encode_audio_stream::submit_buffer()` do not necessarily have to be the same buffers retrieved from `pre_encode_audio_stream::get_next_buffer()`.</span></span> <span data-ttu-id="956a2-171">これらの送信バッファーのプライバシー/特権は、このストリームに関連付けられているユーザーに基づいて適用されます。</span><span class="sxs-lookup"><span data-stu-id="956a2-171">Privacy/privilege for these submitted buffers will be applied based on the users associated with this stream.</span></span> <span data-ttu-id="956a2-172">40 ミリ秒ごとに、このストリームから取得される次の 40 ミリ秒間のオーディオがエンコードされて転送されます。</span><span class="sxs-lookup"><span data-stu-id="956a2-172">Every 40ms, the next 40ms of audio from this stream will be encoded and transmitted.</span></span> <span data-ttu-id="956a2-173">オーディオの中断を防ぐため、連続して聞こえるオーディオのバッファーは一定のレートでこのストリームに送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-173">To prevent audio hiccups, buffers for audio that should be heard continuously should be submitted to this stream at a constant rate.</span></span>

### <a name="stream-contexts"></a><span data-ttu-id="956a2-174">ストリーム コンテキスト</span><span class="sxs-lookup"><span data-stu-id="956a2-174">Stream Contexts</span></span>
<span data-ttu-id="956a2-175">アプリは、`pre_encode_audio_stream::set_custom_stream_context()` と `pre_encode_audio_stream::custom_stream_context()` を使って、プリエンコード オーディオ ストリームでカスタム ポインター サイズのコンテキスト値を管理できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-175">Apps can manage custom pointer-sized context values on pre-encode audio streams using `pre_encode_audio_stream::set_custom_stream_context()` and `pre_encode_audio_stream::custom_stream_context()`.</span></span> <span data-ttu-id="956a2-176">これらのカスタム ストリーム コンテキストはゲーム チャット 2 のオーディオ ストリームと補助データ間のマッピングを作成するために役立ちます。 メタデータ、ゲームの状態などのストリーム。</span><span class="sxs-lookup"><span data-stu-id="956a2-176">These custom stream contexts are helpful for creating mappings between Game Chat 2's audio streams and auxillary data: stream metadata, game state, etc.</span></span>

### <a name="example"></a><span data-ttu-id="956a2-177">例</span><span class="sxs-lookup"><span data-stu-id="956a2-177">Example</span></span>
<span data-ttu-id="956a2-178">1 つのオーディオ処理フレームでプリエンコード オーディオ ストリームを使う方法に関する簡単なエンド ツー エンドのサンプルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="956a2-178">Here's a simplified end-to-end sample for how to use pre-encode audio streams in one audio processing frame:</span></span>

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

## <a name="manipulating-post-decode-chat-audio-data"></a><span data-ttu-id="956a2-179">ポストデコード チャット オーディオ データの操作</span><span class="sxs-lookup"><span data-stu-id="956a2-179">Manipulating post-decode chat audio data</span></span>

<span data-ttu-id="956a2-180">ゲームのチャット 2 を介してチャット オーディオ データをデコード後へのアクセスを提供します、`post_decode_audio_source_stream`と`post_decode_audio_sink_stream`クラスをユーザーがチャット オーディオの各ローカル受信側のリモート ユーザーからのオーディオを一意に操作可能性がありますようにします。</span><span class="sxs-lookup"><span data-stu-id="956a2-180">Game Chat 2 provides access to post-decode chat audio data through the `post_decode_audio_source_stream` and `post_decode_audio_sink_stream` classes, so that users may manipulate audio from remote users uniquely for each local receiver of chat audio.</span></span>

### <a name="sources-and-sinks"></a><span data-ttu-id="956a2-181">ソースとシンク</span><span class="sxs-lookup"><span data-stu-id="956a2-181">Sources and sinks</span></span>
<span data-ttu-id="956a2-182">Pre-encode パイプラインとは異なり、モデルを扱うオーディオ データをデコード後の分割されて 2 つのクラス:`post_decode_audio_source_stream`と`post_decode_audio_sink_stream`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-182">Unlike the pre-encode pipeline, the model for dealing with post-decode audio data is split across two classes: `post_decode_audio_source_stream` and `post_decode_audio_sink_stream`.</span></span> <span data-ttu-id="956a2-183">取得できるリモート ユーザーからのデコードされたオーディオ`post_decode_audio_source_stream`オブジェクト、操作、およびに送信される`post_decode_audio_sink_stream`レンダリング オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="956a2-183">Decoded audio from remote users can be retrieved from `post_decode_audio_source_stream` objects, manipulated, and sent to `post_decode_audio_sink_stream` objects for rendering.</span></span> <span data-ttu-id="956a2-184">これにより、ゲーム チャット 2 の間の統合、デコード後オーディオ処理パイプラインと便利なオーディオのミドルウェアの。</span><span class="sxs-lookup"><span data-stu-id="956a2-184">This allows for integration between Game Chat 2's post-decode audio processing pipeline and helpful audio middleware.</span></span>

### <a name="stream-lifetime"></a><span data-ttu-id="956a2-185">ストリームの有効期間</span><span class="sxs-lookup"><span data-stu-id="956a2-185">Stream Lifetime</span></span>
<span data-ttu-id="956a2-186">新しい`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`インスタンスが使用するアプリの準備ができて、経由で配信されることを`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_created`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream_created`、それぞれします。</span><span class="sxs-lookup"><span data-stu-id="956a2-186">When a new `post_decode_audio_source_stream` or `post_decode_audio_sink_stream` instance is ready for the app to use, it will be delivered through a `game_chat_stream_state_change` structure with it's `state_change_type` field set to `game_chat_stream_state_change_type::post_decode_audio_source_stream_created` or `game_chat_stream_state_change_type::post_decode_audio_sink_stream_created`, respectively.</span></span> <span data-ttu-id="956a2-187">オーディオ ストリームが使用可能になるゲーム チャット 2 にこのストリームの状態の変更が返されると、オーディオの操作を後にデコードします。</span><span class="sxs-lookup"><span data-stu-id="956a2-187">Once this stream state change is returned to Game Chat 2, the audio stream will become available for post-decode audio manipulation.</span></span>

<span data-ttu-id="956a2-188">既存`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`になりますオーディオの操作を使用して、使用不可能、アプリが通知されますを通じて、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_closed`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream`、それぞれします。</span><span class="sxs-lookup"><span data-stu-id="956a2-188">When an existing `post_decode_audio_source_stream` or `post_decode_audio_sink_stream` becomes unavailable to use for audio manipulation, the app will be notified through a `game_chat_stream_state_change` structure with it's `state_change_type` field set to `game_chat_stream_state_change_type::post_decode_audio_source_stream_closed` or `game_chat_stream_state_change_type::post_decode_audio_sink_stream`, respectively.</span></span> <span data-ttu-id="956a2-189">アプリは、この機会にこのオーディオ ストリームに関連付けられたリソースのクリーンアップを開始できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-189">This is the app's opportunity to start cleaning up the resources associated with this audio stream.</span></span> <span data-ttu-id="956a2-190">オーディオ ストリームが使用できなくなりますゲーム チャット 2 にこのストリームの状態の変更が返されると、オーディオの操作を後にデコードします。</span><span class="sxs-lookup"><span data-stu-id="956a2-190">Once this stream state change is returned to Game Chat 2, the audio stream will become unavailable for post-decode audio manipulation.</span></span> <span data-ttu-id="956a2-191">ソースのストリーム バッファーがありませんがキューの操作にことを意味します。</span><span class="sxs-lookup"><span data-stu-id="956a2-191">For source streams, this means that no more buffers will be queued for manipulation.</span></span> <span data-ttu-id="956a2-192">シンクのストリーム バッファーは表示されなくを送信することを意味します。</span><span class="sxs-lookup"><span data-stu-id="956a2-192">For sink streams, this means that submitted buffers will no longer be rendered.</span></span>

<span data-ttu-id="956a2-193">閉じているときに`post_decode_audio_source_stream`または`post_decode_audio_sink_stream`がすべてのリソースが戻ると、ストリームが破棄され、を通じて、アプリが通知されます、`game_chat_stream_state_change`構造体の`state_change_type`フィールドに設定`game_chat_stream_state_change_type::post_decode_audio_source_stream_destroyed`または`game_chat_stream_state_change_type::post_decode_audio_sink_stream_destroyed`、それぞれします。</span><span class="sxs-lookup"><span data-stu-id="956a2-193">When a closed `post_decode_audio_source_stream` or `post_decode_audio_sink_stream` has all of it's resources returned, the stream will be destroyed and the app will be notified through a `game_chat_stream_state_change` structure with it's `state_change_type` field set to `game_chat_stream_state_change_type::post_decode_audio_source_stream_destroyed` or `game_chat_stream_state_change_type::post_decode_audio_sink_stream_destroyed`, respectively.</span></span> <span data-ttu-id="956a2-194">このストリームへの参照またはポインターをすべてクリーンアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-194">Any references or pointers to this stream should be cleaned up.</span></span> <span data-ttu-id="956a2-195">このストリームの状態の変更がゲームのチャット 2 に返されると、オーディオ ストリームのメモリは無効になります。</span><span class="sxs-lookup"><span data-stu-id="956a2-195">Once this stream state change is returned to Game Chat 2, the audio stream memory will become invalid.</span></span>

### <a name="stream-users"></a><span data-ttu-id="956a2-196">ストリーム ユーザー</span><span class="sxs-lookup"><span data-stu-id="956a2-196">Stream Users</span></span>
<span data-ttu-id="956a2-197">使用して post-decode ソース ストリームに関連付けられているリモート ユーザーの一覧を検査できる`post_decode_audio_source_stream::get_users()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-197">The list of remote users associated with a post-decode source stream can be inspected using `post_decode_audio_source_stream::get_users()`.</span></span> <span data-ttu-id="956a2-198">使用して post-decode シンクのストリームに関連付けられているローカル ユーザーの一覧を検査できる`post_decode_audio_sink_stream::get_users()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-198">The list of local users associated with a post-decode sink stream can be inspected using `post_decode_audio_sink_stream::get_users()`.</span></span>

### <a name="audio-formats"></a><span data-ttu-id="956a2-199">オーディオ形式</span><span class="sxs-lookup"><span data-stu-id="956a2-199">Audio Formats</span></span>
<span data-ttu-id="956a2-200">使用してゲームのチャット 2 から、アプリを取得するバッファーのオーディオ形式を検査できる`post_decode_audio_source_stream::get_pre_processed_format()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-200">The audio format of the buffers the app retrieves from Game Chat 2 can be inspected using `post_decode_audio_source_stream::get_pre_processed_format()`.</span></span> <span data-ttu-id="956a2-201">前処理されたオーディオ形式は、mono の 16 ビット整数 PCM 常になります。</span><span class="sxs-lookup"><span data-stu-id="956a2-201">The pre-processed audio format will always be mono, 16-bit integer PCM.</span></span>

<span data-ttu-id="956a2-202">アプリは、ゲームのレンダリングを使用するために送信される操作のバッファーのオーディオ形式の 2 のチャットを伝える必要があります`post_decode_audio_sink_stream::set_processed_format()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-202">The app must inform Game Chat 2 of the audio format of the manipulated buffers that are being submitted to it for rendering using `post_decode_audio_sink_stream::set_processed_format()`.</span></span> <span data-ttu-id="956a2-203">処理された形式のオーディオをデコード後シンク ストリームは、これらの前提条件を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-203">Processed formats for post-decode audio sink streams must meet these pre-conditions:</span></span>

* <span data-ttu-id="956a2-204">形式は、64 個未満のチャネルが必要です。</span><span class="sxs-lookup"><span data-stu-id="956a2-204">The format must have less than 64 channels.</span></span>
* <span data-ttu-id="956a2-205">形式は、16 ビット整数 PCM (最適)、20 ビット整数の PCM (24 ビット コンテナー) を 24 ビットの整数 PCM、32 ビット整数 PCM、または 32 ビット浮動小数点 PCM (16 ビット整数の PCM の後に希望の形式) である必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-205">The format must be 16-bit integer PCM (optimal), 20-bit integer PCM (in a 24-bit container), 24-bit integer PCM, 32-bit integer PCM, or 32-bit float PCM (preferred format after 16-bit integer PCM).</span></span> 
* <span data-ttu-id="956a2-206">形式のサンプル レートは、1 秒あたり 1000、200000 のサンプル間でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="956a2-206">The format's sample rate must be between 1000 and 200000 samples per second.</span></span>

### <a name="retrieving-and-submitting-audio"></a><span data-ttu-id="956a2-207">オーディオの取得と送信</span><span class="sxs-lookup"><span data-stu-id="956a2-207">Retrieving and Submitting Audio</span></span>
<span data-ttu-id="956a2-208">アプリがクエリできるオーディオ ソース ストリームを使用して処理する使用可能なバッファーの数をデコード後`post_decode_audio_source_stream::get_available_buffer_count()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-208">Apps can query post-decode audio source streams for the number of available buffers to process using `post_decode_audio_source_stream::get_available_buffer_count()`.</span></span> <span data-ttu-id="956a2-209">この情報は、バッファーの最小数が使用可能になるまでアプリがオーディオ処理を延期する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="956a2-209">This information can be used if the app would like to delay audio processing until a minimum number of buffers are available.</span></span> <span data-ttu-id="956a2-210">10 個のバッファーは各キューに配置後オーディオ ソース ストリームのデコードし、オーディオの遅延は、アプリがドレインすることをお勧め、オーディオのパイプラインでの待機時間が発生の前に、4 つ以上のバッファーをキュー、後のオーディオ ストリームをデコードします。</span><span class="sxs-lookup"><span data-stu-id="956a2-210">Only 10 buffers will be queued on each post-decode audio source stream and audio delays will introduce latency in the audio pipeline, so it's recommended that apps drain their post-decode audio streams before they queue more than 4 buffers.</span></span>

<span data-ttu-id="956a2-211">アプリからのオーディオのバッファーを取得できるを使用してオーディオ ソース ストリームのデコード後`post_decode_audio_source_stream::get_next_buffer()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-211">Apps can retrieve audio buffers from a post-decode audio source stream using `post_decode_audio_source_stream::get_next_buffer()`.</span></span> <span data-ttu-id="956a2-212">新しいオーディオ バッファーは、平均で 40 ミリ秒に 1 回使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="956a2-212">New audio buffers will be available on average, once every 40ms.</span></span> <span data-ttu-id="956a2-213">このメソッドによって返されるバッファーは、使い終わったら `post_decode_audio_source_stream::return_buffer()` にリリースされる必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-213">Buffers returned by this method must be released to `post_decode_audio_source_stream::return_buffer()` when they are done being used.</span></span> <span data-ttu-id="956a2-214">最大 10 個のキューに置かれたまたは unreturned バッファーは、特定の時点に存在できる、ポスト オーディオ ソース ストリームのデコードします。</span><span class="sxs-lookup"><span data-stu-id="956a2-214">A maximum of 10 queued or unreturned buffers can exist at any given time for a post-decode audio source stream.</span></span> <span data-ttu-id="956a2-215">この制限に達すると、リモート プレーヤーから新しいのデコードされたバッファーは未解決のバッファーの一部が返されるまでに削除されます。</span><span class="sxs-lookup"><span data-stu-id="956a2-215">Once this limit is reached, new decoded buffers from the remote player will be dropped until some of the outstanding buffers are returned.</span></span>

<span data-ttu-id="956a2-216">チャット 2 ~ ゲームに戻るの検査と操作のバッファーのレンダリングを使用するためのシンクのオーディオ ストリームのデコード後のアプリを送信できる`post_decode_audio_sink_stream::submit_mixed_buffer()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-216">Apps can submit their inspected and manipulated buffers back to Game Chat 2 through post-decode audio sink streams for rendering using `post_decode_audio_sink_stream::submit_mixed_buffer()`.</span></span> <span data-ttu-id="956a2-217">ゲームのチャット 2 にインプレースとな場所のオーディオ操作がサポートされている場合にバッファーが送信されるので`post_decode_audio_sink_stream::submit_mixed_buffer()`から取得した同じバッファーを必ずしも`post_decode_audio_source_stream::get_next_buffer()`します。</span><span class="sxs-lookup"><span data-stu-id="956a2-217">Game Chat 2 supports in-place and out-of-place audio manipulation, so the buffers submitted to `post_decode_audio_sink_stream::submit_mixed_buffer()` do not necessarily have to be the same buffers retrieved from `post_decode_audio_source_stream::get_next_buffer()`.</span></span> <span data-ttu-id="956a2-218">すべての 40 オーディオのストリームからの次の 40 がレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="956a2-218">Every 40ms, the next 40ms of audio from this stream will be rendered.</span></span> <span data-ttu-id="956a2-219">オーディオの中断を防ぐため、連続して聞こえるオーディオのバッファーは一定のレートでこのストリームに送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="956a2-219">To prevent audio hiccups, buffers for audio that should be heard continuously should be submitted to this stream at a constant rate.</span></span>

### <a name="privacy-and-mixing"></a><span data-ttu-id="956a2-220">プライバシーとの混合</span><span class="sxs-lookup"><span data-stu-id="956a2-220">Privacy and Mixing</span></span>
<span data-ttu-id="956a2-221">Post-decode パイプラインのソース シンク モデルでは、ため、アプリの責任から取得したバッファーを混在させることが`post_decode_audio_source_stream`オブジェクトし、を混在バッファーを送信`post_decode_audio_sink_stream`レンダリング オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="956a2-221">Because of the post-decode pipeline's source-sink model, it is the app's responsibility to mix the buffers retrieved from `post_decode_audio_source_stream` objects and submit the mixed buffers to `post_decode_audio_sink_stream` objects for rendering.</span></span> <span data-ttu-id="956a2-222">つまりミックスには、適切なプライバシーと適用の特権を使用して実行するアプリの責任です。</span><span class="sxs-lookup"><span data-stu-id="956a2-222">This also means that it is the app's responsibility to perform the mix with proper privacy and privilege enforced.</span></span> <span data-ttu-id="956a2-223">ゲームのチャット 2 では`post_decode_audio_sink_stream::can_receive_audio_from_source_stream()`簡単かつ効率的にこの情報の照会します。</span><span class="sxs-lookup"><span data-stu-id="956a2-223">Game Chat 2 provides `post_decode_audio_sink_stream::can_receive_audio_from_source_stream()` to make querying for this information simple and efficient.</span></span>

### <a name="chat-indicators"></a><span data-ttu-id="956a2-224">チャットの評価指標</span><span class="sxs-lookup"><span data-stu-id="956a2-224">Chat indicators</span></span>

<span data-ttu-id="956a2-225">オーディオをデコード後の操作には、各ユーザーのチャット インジケーターの状態は変わりません。</span><span class="sxs-lookup"><span data-stu-id="956a2-225">Post-decode audio manipulation will not effect the chat indicator state for each user.</span></span> <span data-ttu-id="956a2-226">たとえば、リモート ユーザーがミュートされてとは、オーディオは、アプリに提供されますが、そのリモート ユーザーのチャット インジケーターがミュートされても示します。</span><span class="sxs-lookup"><span data-stu-id="956a2-226">For instance, when a remote user is muted, the audio will be provided to the app, but the chat indicator for that remote user will still indicate muted.</span></span> <span data-ttu-id="956a2-227">リモート ユーザーと対話するとき、オーディオが提供されますが、アプリは、そのユーザーからオーディオを含むオーディオを混在させるかどうかに関係なくと通信をチャット インジケーターが表示されます。</span><span class="sxs-lookup"><span data-stu-id="956a2-227">When a remote user is talking, their audio will be provided, but the chat indicator will indicate talking regardless of whether the app provides an audio mix containing audio from that user.</span></span> <span data-ttu-id="956a2-228">UI とチャット インジケーターの詳細については、次を参照してください。[を使用してゲームのチャット 2](using-game-chat-2.md#ui)します。</span><span class="sxs-lookup"><span data-stu-id="956a2-228">For more information on UI and the chat indicator, see [Using Game Chat 2](using-game-chat-2.md#ui).</span></span> <span data-ttu-id="956a2-229">ユーザーがオーディオのミックス内に存在するかを決定する余分なアプリに固有の制限を使用する場合は、ゲーム チャット 2 によって提供されるチャット インジケーターを読み取るときに、その同じ制限を考慮するアプリの責任です。</span><span class="sxs-lookup"><span data-stu-id="956a2-229">If extra app-specific restrictions are used to determine which users are present in an audio mix, it is the app's responsibility to consider those same restrictions when it is reading the chat indicators provided by Game Chat 2.</span></span>

### <a name="stream-contexts"></a><span data-ttu-id="956a2-230">ストリーム コンテキスト</span><span class="sxs-lookup"><span data-stu-id="956a2-230">Stream Contexts</span></span>
<span data-ttu-id="956a2-231">アプリは、カスタムのポインター-サイズのコンテキストの値を管理できますを使用して、オーディオ ストリームのデコード後で、`set_custom_stream_context()`と`custom_stream_context()`メソッド。</span><span class="sxs-lookup"><span data-stu-id="956a2-231">Apps can manage custom pointer-sized context values on post-decode audio streams using the `set_custom_stream_context()` and `custom_stream_context()` methods.</span></span> <span data-ttu-id="956a2-232">これらのカスタム ストリーム コンテキストはゲーム チャット 2 のオーディオ ストリームと補助データ間のマッピングを作成するために役立ちます。 メタデータ、ゲームの状態などのストリーム。</span><span class="sxs-lookup"><span data-stu-id="956a2-232">These custom stream contexts are helpful for creating mappings between Game Chat 2's audio streams and auxillary data: stream metadata, game state, etc.</span></span>

### <a name="example"></a><span data-ttu-id="956a2-233">例</span><span class="sxs-lookup"><span data-stu-id="956a2-233">Example</span></span>
<span data-ttu-id="956a2-234">ここで使用する方法が簡略化されたエンド ツー エンド サンプルは、1 つのオーディオ処理フレームでオーディオ ストリームのデコード後。</span><span class="sxs-lookup"><span data-stu-id="956a2-234">Here's a simplified end-to-end sample for how to use post-decode audio streams in one audio processing frame:</span></span>

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

## <a name="chat-user-lifetimes"></a><span data-ttu-id="956a2-235">チャット ユーザーの有効期間</span><span class="sxs-lookup"><span data-stu-id="956a2-235">Chat user lifetimes</span></span>

<span data-ttu-id="956a2-236">リアルタイム オーディオ操作を有効にすると、チャット ユーザーの有効期間に影響が及びます。</span><span class="sxs-lookup"><span data-stu-id="956a2-236">Enabling real-time audio manipulation will affect the lifetimes of chat users.</span></span> <span data-ttu-id="956a2-237">`chat_manager::remove_user(chatUserX)` が呼び出された場合、chatUserX によってポイントされた chat_user オブジェクトは、chatUserX を参照するすべてのオーディオ ストリームが破棄されるまで有効なままです。</span><span class="sxs-lookup"><span data-stu-id="956a2-237">If `chat_manager::remove_user(chatUserX)` is called, the chat_user object pointed to by chatUserX will remain valid until all audio streams that reference chatUserX have been destroyed.</span></span> <span data-ttu-id="956a2-238">次のシナリオを考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="956a2-238">Consider the following scenario:</span></span>

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
