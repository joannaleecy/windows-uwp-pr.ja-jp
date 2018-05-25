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
# <a name="real-time-audio-manipulation"></a><span data-ttu-id="36309-104">リアルタイム オーディオ操作</span><span class="sxs-lookup"><span data-stu-id="36309-104">Real-time audio manipulation</span></span>

<span data-ttu-id="36309-105">ゲーム チャット 2 (GC2) では、開発者が GC2 をチャット オーディオ パイプラインに挿入して、プレイヤーのチャット オーディオ データを検査および操作することができます。</span><span class="sxs-lookup"><span data-stu-id="36309-105">Game Chat 2 (GC2) gives developers the option to insert themselves into the chat audio pipeline to inspect and manipulate the players' chat audio data.</span></span> <span data-ttu-id="36309-106">これは、ゲームでおもしろいオーディオ エフェクトをプレイヤーの声に適用するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="36309-106">This can be useful for applying interesting audio effects to players' voices in game.</span></span> <span data-ttu-id="36309-107">GC2 のオーディオ操作パイプラインは、オーディオ データ用にポーリングできるオーディオ ストリーム オブジェクトを使って操作できます。</span><span class="sxs-lookup"><span data-stu-id="36309-107">GC2's audio manipulation pipeline is interfaced with through audio stream objects that can be polled for audio data.</span></span> <span data-ttu-id="36309-108">コールバックを使うのとは対照的に、このモデルでは開発者にとって最も便利な処理スレッドでオーディオを検査または操作できます。</span><span class="sxs-lookup"><span data-stu-id="36309-108">As opposed to using callbacks, this model allows developers to inspect or manipulate audio on whatever processing thread is most convenient for them.</span></span>

<span data-ttu-id="36309-109">以下では、リアルタイム オーディオ操作の使用方法を簡単に説明します。次のトピックがあります。</span><span class="sxs-lookup"><span data-stu-id="36309-109">A brief walkthrough using real-time audio manipulation is featured below, containing the following topics:</span></span>

1. [<span data-ttu-id="36309-110">オーディオ操作パイプラインの初期化</span><span class="sxs-lookup"><span data-stu-id="36309-110">Initializing the audio manipulation pipeline</span></span>](#initializing-the-audio-manipulation-pipeline)
2. [<span data-ttu-id="36309-111">オーディオ ストリームの状態の変化の処理</span><span class="sxs-lookup"><span data-stu-id="36309-111">Processing audio stream state changes</span></span>](#processing-audio-stream-state-changes)
3. [<span data-ttu-id="36309-112">プリエンコード チャット オーディオの操作</span><span class="sxs-lookup"><span data-stu-id="36309-112">Manipulating pre-encode chat audio</span></span>](#manipulating-pre-encode-chat-audio-data)
4. [<span data-ttu-id="36309-113">ポストデコード チャット オーディオの操作</span><span class="sxs-lookup"><span data-stu-id="36309-113">Manipulating post-decode chat audio</span></span>](#manipulating-post-decode-chat-audio-data)
5. [<span data-ttu-id="36309-114">チャット ユーザーの有効期間</span><span class="sxs-lookup"><span data-stu-id="36309-114">Chat user lifetimes</span></span>](#chat-user-lifetimes)

## <a name="initializing-the-audio-manipulation-pipeline"></a><span data-ttu-id="36309-115">オーディオ操作パイプラインの初期化</span><span class="sxs-lookup"><span data-stu-id="36309-115">Initializing the audio manipulation pipeline</span></span>

<span data-ttu-id="36309-116">GC2 では、リアルタイム オーディオ操作は既定で有効になりません。</span><span class="sxs-lookup"><span data-stu-id="36309-116">GC2 by default will not enable real-time audio manipulation.</span></span> <span data-ttu-id="36309-117">リアルタイム オーディオ操作を有効にするには、アプリが `chat_manager::initialize()` で有効にするオーディオ操作の形式を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-117">To enable real-time audio manipulation the app must specify which form(s) of audio manipulation it would like enabled in `chat_manager::initialize()`.</span></span>

<span data-ttu-id="36309-118">現在のところ、次のオーディオ操作形式がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="36309-118">Currently, the following audio manipulation forms are supported:</span></span>

* `game_chat_audio_manipulation_mode_flags::none` <span data-ttu-id="36309-119">- オーディオ操作を無効にします。</span><span class="sxs-lookup"><span data-stu-id="36309-119">- Disables audio manipulation.</span></span> <span data-ttu-id="36309-120">これは既定の構成です。</span><span class="sxs-lookup"><span data-stu-id="36309-120">This is the default configuration.</span></span> <span data-ttu-id="36309-121">このモードでは、チャット オーディオが常時流し込まれます。</span><span class="sxs-lookup"><span data-stu-id="36309-121">In this mode, chat audio will flow uninterrupted.</span></span>
* `game_chat_audio_manipulation_mode_flags::pre_encode_stream_manipulation` <span data-ttu-id="36309-122">- プリエンコード オーディオ操作を有効にします。</span><span class="sxs-lookup"><span data-stu-id="36309-122">- Enables pre-encode audio manipulation.</span></span> <span data-ttu-id="36309-123">このモードでは、ローカル ユーザーによって生成されたすべてのチャット オーディオが、エンコード前にオーディオ操作パイプラインを通じて取り込まれます。</span><span class="sxs-lookup"><span data-stu-id="36309-123">In this mode, all chat audio generated by local users will be fed through the audio manipulation pipeline before it is encoded.</span></span> <span data-ttu-id="36309-124">アプリがチャット オーディオ データを操作せずに検査するだけであっても、変更されていないオーディオ バッファーをエンコードして転送できるように GC2 に戻す責任はアプリにあります。</span><span class="sxs-lookup"><span data-stu-id="36309-124">Even if the app is only inspecting the chat audio data and not manipulating it, it is still the  app's responsibility to submit the unaltered audio buffers back to GC2 so that they can be encoded and transmitted.</span></span>
* `game_chat_audio_manipulation_mode_flags::post_decode_stream_manipulation` <span data-ttu-id="36309-125">- ポストデコード オーディオ操作を有効にします。</span><span class="sxs-lookup"><span data-stu-id="36309-125">- Enables post-decode audio manipulation.</span></span> <span data-ttu-id="36309-126">このモードは現在開発中のため、使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="36309-126">This mode is currently in development and should not be used.</span></span>

## <a name="processing-audio-stream-state-changes"></a><span data-ttu-id="36309-127">オーディオ ストリームの状態の変化の処理</span><span class="sxs-lookup"><span data-stu-id="36309-127">Processing audio stream state changes</span></span>

<span data-ttu-id="36309-128">GC2 は、`game_chat_stream_state_change` 構造体を通じてオーディオ ストリームの状態を更新します。</span><span class="sxs-lookup"><span data-stu-id="36309-128">GC2 provides updates to the state of audio streams through `game_chat_stream_state_change` structures.</span></span> <span data-ttu-id="36309-129">これらの更新には、更新されたストリームとその更新内容に関する情報が格納されています。</span><span class="sxs-lookup"><span data-stu-id="36309-129">These updates store information about which stream has been updated and how it has been updated.</span></span> <span data-ttu-id="36309-130">`chat_manager::start_processing_stream_state_changes` および `chat_manager::finish_processing_stream_state_changes` のメソッド ペアを呼び出すことにより、これらの更新をポーリングできます。</span><span class="sxs-lookup"><span data-stu-id="36309-130">These updates can be polled for through calls to the `chat_manager::start_processing_stream_state_changes` and `chat_manager::finish_processing_stream_state_changes` pair of methods.</span></span> <span data-ttu-id="36309-131">このメソッド ペアは、キューに入れられた最新のオーディオ ストリームの状態の更新すべてを `game_chat_stream_state_change` 構造体ポインターの配列として提供します。</span><span class="sxs-lookup"><span data-stu-id="36309-131">This pair of methods provides all of the latest, queued audio stream state updates as an array of `game_chat_stream_state_change` structure pointers.</span></span> <span data-ttu-id="36309-132">アプリは、配列を反復処理し、各更新を適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-132">Apps should iterate over the array and handle each update appropriately.</span></span> <span data-ttu-id="36309-133">利用可能な `game_chat_stream_state_change` の更新がすべて処理されたら、`chat_manager::finish_processing_stream_state_changes()` を通じてその配列を GC2 に戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-133">Once all available `game_chat_stream_state_change` updates have been handled, that array should be passed back to GC2 through `chat_manager::finish_processing_stream_state_changes()`.</span></span> <span data-ttu-id="36309-134">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="36309-134">For example:</span></span>

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

## <a name="manipulating-pre-encode-chat-audio-data"></a><span data-ttu-id="36309-135">プリエンコード チャット オーディオ データの操作</span><span class="sxs-lookup"><span data-stu-id="36309-135">Manipulating pre-encode chat audio data</span></span>

<span data-ttu-id="36309-136">GC2 は、`pre_encode_audio_stream` クラスを通じてローカル ユーザーにプリエンコード チャット オーディオ データへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="36309-136">GC2 provides access to pre-encode chat audio data for local users through the `pre_encode_audio_stream` class.</span></span>

### <a name="stream-lifetime"></a><span data-ttu-id="36309-137">ストリームの有効期間</span><span class="sxs-lookup"><span data-stu-id="36309-137">Stream Lifetime</span></span>
<span data-ttu-id="36309-138">アプリが新しい `pre_encode_audio_stream` インスタンスを使う準備ができると、その型フィールドが `game_chat_stream_state_change_type::pre_encode_audio_stream_created` に設定され、`game_chat_stream_state_change` 構造体を通じて配信されます。</span><span class="sxs-lookup"><span data-stu-id="36309-138">When a new `pre_encode_audio_stream` instance is ready for the app to use, it will be delivered through a `game_chat_stream_state_change` structure with it's type field set to `game_chat_stream_state_change_type::pre_encode_audio_stream_created`.</span></span> <span data-ttu-id="36309-139">このストリーム状態の変化が GC2 に返されると、オーディオ ストリームではプリエンコード オーディオ操作を実行可能になります。</span><span class="sxs-lookup"><span data-stu-id="36309-139">Once this stream state change is returned to GC2, the audio stream will become available for pre-encode audio manipulation.</span></span>

<span data-ttu-id="36309-140">既存の `pre_encode_audio_stream` をオーディオ操作に使用できなくなると、`game_chat_stream_state_change` 構造体を通じてアプリに通知されます。型フィールドは `game_chat_stream_state_change_type::pre_encode_audio_stream_closed` に設定されます。</span><span class="sxs-lookup"><span data-stu-id="36309-140">When an existing `pre_encode_audio_stream` becomes unavailable to use for audio manipulation, the app will be notified through a `game_chat_stream_state_change` structure with it's type field set to `game_chat_stream_state_change_type::pre_encode_audio_stream_closed`.</span></span> <span data-ttu-id="36309-141">アプリは、この機会にこのオーディオ ストリームに関連付けられたリソースのクリーンアップを開始できます。</span><span class="sxs-lookup"><span data-stu-id="36309-141">This is the app's opportunity to start cleaning up the resources associated with this audio stream.</span></span> <span data-ttu-id="36309-142">このストリーム状態の変化が GC2 に返されると、オーディオ ストリームではプリエンコード オーディオ操作を実行できなくなります。</span><span class="sxs-lookup"><span data-stu-id="36309-142">Once this stream state change is returned to GC2, the audio stream will become unavailable for pre-encode audio manipulation.</span></span>

<span data-ttu-id="36309-143">閉じられた `pre_encode_audio_stream` にそのリソースがすべて返されると、ストリームが破棄され、`game_chat_stream_state_change` 構造体を通じてアプリに通知されます。その型フィールドは、`game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed` に設定されます。</span><span class="sxs-lookup"><span data-stu-id="36309-143">When a closed `pre_encode_audio_stream` has all of it's resources returned, the stream will be destroyed and the app will be notified through a `game_chat_stream_state_change` structure with it's type field set to `game_chat_stream_state_change_type::pre_encode_audio_stream_destroyed`.</span></span> <span data-ttu-id="36309-144">このストリームへの参照またはポインターをすべてクリーンアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-144">Any references or pointers to this stream should be cleaned up.</span></span> <span data-ttu-id="36309-145">このストリーム状態の変化が GC2 に返されると、オーディオ ストリーム メモリが無効になります。</span><span class="sxs-lookup"><span data-stu-id="36309-145">Once this stream state change is returned to GC2, the audio stream memory will become invalid.</span></span>

### <a name="stream-users"></a><span data-ttu-id="36309-146">ストリーム ユーザー</span><span class="sxs-lookup"><span data-stu-id="36309-146">Stream Users</span></span>
<span data-ttu-id="36309-147">ストリームに関連付けられているユーザーのリストは、`pre_encode_audio_stream::get_users()` を使って検査できます。</span><span class="sxs-lookup"><span data-stu-id="36309-147">The list of users associated with a stream can be inspected using `pre_encode_audio_stream::get_users()`.</span></span>

### <a name="audio-formats"></a><span data-ttu-id="36309-148">オーディオ形式</span><span class="sxs-lookup"><span data-stu-id="36309-148">Audio Formats</span></span>
<span data-ttu-id="36309-149">アプリが GC2 から取得するバッファーのオーディオ形式は、`pre_encode_audio_stream::get_pre_processed_format()` を使って検査できます。</span><span class="sxs-lookup"><span data-stu-id="36309-149">The audio format of the buffers the app retrieves from GC2 can be inspected using `pre_encode_audio_stream::get_pre_processed_format()`.</span></span> <span data-ttu-id="36309-150">前処理されたオーディオ形式は常にモノラルになります。</span><span class="sxs-lookup"><span data-stu-id="36309-150">The pre-processed audio format will always be mono.</span></span> <span data-ttu-id="36309-151">アプリは、32 ビット浮動小数点値、16 ビット整数値、および 32 ビット整数値として表されるデータを処理することを予期する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-151">The app should expect to handle data represented as 32-bit floats, 16-bit integers, and 32-bit integers.</span></span>

<span data-ttu-id="36309-152">アプリは、`pre_encode_audio_stream::set_processed_format()` を使って、エンコードのために自身に転送されている操作対象バッファーのオーディオ形式について GC2 に通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-152">The app must inform GC2 of the audio format of the manipulated buffers that are being submitted to it for encoding and transmission using `pre_encode_audio_stream::set_processed_format()`.</span></span> <span data-ttu-id="36309-153">プリエンコード オーディオ ストリームの処理形式は、以下の前提条件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-153">Processed formats for pre-encode audio streams must meet these pre-conditions:</span></span>

* <span data-ttu-id="36309-154">形式はモノラルでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="36309-154">The format must be mono.</span></span>
* <span data-ttu-id="36309-155">形式は 32 ビット浮動小数点 PCM、32 ビット整数 PCM、または 16 ビット整数 PCM 形式である必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-155">The format must be 32-bit float PCM, 32-bit integer PCM, or 16-bit integer PCM formats.</span></span>
* <span data-ttu-id="36309-156">形式のサンプル レートは、そのプラットフォームに基づく前提条件に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-156">The format's sample rate must follow pre-conditions based on it's platform.</span></span> <span data-ttu-id="36309-157">Xbox One ERA では、8 kHz、12 kHz、16 kHz、および 24 kHz のサンプル レートがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="36309-157">Xbox One ERA supports 8kHz, 12kHz, 16kHz, and 24kHz sample rates.</span></span> <span data-ttu-id="36309-158">Xbox One および PC 用の UWP では、8 kHz、12 kHz、16 kHz、24 kHz、32 kHz、44.1 kHz、および 48 kHz のサンプル レートがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="36309-158">UWP for Xbox One and PC supports 8kHz, 12kHz, 16kHz, 24kHz, 32kHz, 44.1kHz, and 48kHz sample rates.</span></span>

### <a name="retrieving-and-submitting-audio"></a><span data-ttu-id="36309-159">オーディオの取得と送信</span><span class="sxs-lookup"><span data-stu-id="36309-159">Retrieving and Submitting Audio</span></span>
<span data-ttu-id="36309-160">アプリは、プリエンコード オーディオ ストリームで、`pre_encode_audio_stream::get_available_buffer_count()` を使って処理可能なバッファーの数を照会できます。</span><span class="sxs-lookup"><span data-stu-id="36309-160">Apps can query pre-encode audio streams for the number of available buffers to process using `pre_encode_audio_stream::get_available_buffer_count()`.</span></span> <span data-ttu-id="36309-161">この情報は、バッファーの最小数が使用可能になるまでアプリがオーディオ処理を延期する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="36309-161">This information can be used if the app would like to delay audio processing until a minimum number of buffers are available.</span></span> <span data-ttu-id="36309-162">キューに入れることができるバッファーはプリエンコード オーディオ ストリームごとに 10 個だけであり、オーディオの遅延によりオーディオ パイプラインに待機時間が生じるため、キュー内のバッファーが 4 個を超える前にアプリがプリエンコード オーディオ ストリームをドレインすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36309-162">Only 10 buffers will be queued on each pre-encode audio stream and audio delays will introduce latency in the audio pipeline, so it's recommended that apps drain their pre-encode audio streams before they queue more than 4 buffers.</span></span>

<span data-ttu-id="36309-163">アプリは、`pre_encode_audio_stream::get_next_buffer()` を使ってプリエンコード オーディオ ストリームからオーディオ バッファーを取得できます。</span><span class="sxs-lookup"><span data-stu-id="36309-163">Apps can retrieve audio buffers from a pre-encode audio stream using `pre_encode_audio_stream::get_next_buffer()`.</span></span> <span data-ttu-id="36309-164">新しいオーディオ バッファーは、平均で 40 ミリ秒に 1 回使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="36309-164">New audio buffers will be available on average, once every 40ms.</span></span> <span data-ttu-id="36309-165">このメソッドによって返されるバッファーは、使い終わったら `pre_encode_audio_stream::return_buffer()` にリリースされる必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-165">Buffers returned by this method must be released to `pre_encode_audio_stream::return_buffer()` when they are done being used.</span></span> <span data-ttu-id="36309-166">プリエンコード オーディオ ストリームには、キューに入れられたバッファーまたは返されていないバッファーが任意の時点で最大 10 個存在することができます。</span><span class="sxs-lookup"><span data-stu-id="36309-166">A maximum of 10 queued or unreturned buffers can exist at any given time for a pre-encode audio stream.</span></span> <span data-ttu-id="36309-167">この制限に達すると、未処理のバッファーの一部が返されるまで、プレイヤーのオーディオ ソースからキャプチャされた新しいバッファーが破棄されます。</span><span class="sxs-lookup"><span data-stu-id="36309-167">Once this limit is reached, new buffers captured from the player's audio source will be dropped until some of the outstanding buffers are returned.</span></span>

<span data-ttu-id="36309-168">アプリは、`pre_encode_audio_stream::submit_buffer()` を使って、エンコードおよび転送のために検査および操作済みのバッファーを GC2 に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="36309-168">Apps can submit their inspected and manipulated buffers back to GC2 for encoding and transmission using `pre_encode_audio_stream::submit_buffer()`.</span></span> <span data-ttu-id="36309-169">GC2 では、インプレースおよびアウト オブ プレースのオーディオ操作がサポートされるため、`pre_encode_audio_stream::submit_buffer()` に送信されるバッファーは必ずしも `pre_encode_audio_stream::get_next_buffer()` から取得されるバッファーと同じである必要はありません。</span><span class="sxs-lookup"><span data-stu-id="36309-169">GC2 supports in-place and out-of-place audio manipulation, so the buffers submitted to `pre_encode_audio_stream::submit_buffer()` do not necessarily have to be the same buffers retrieved from `pre_encode_audio_stream::get_next_buffer()`.</span></span> <span data-ttu-id="36309-170">これらの送信バッファーのプライバシー/特権は、このストリームに関連付けられているユーザーに基づいて適用されます。</span><span class="sxs-lookup"><span data-stu-id="36309-170">Privacy/privilege for these submitted buffers will be applied based on the users associated with this stream.</span></span> <span data-ttu-id="36309-171">40 ミリ秒ごとに、このストリームから取得される次の 40 ミリ秒間のオーディオがエンコードされて転送されます。</span><span class="sxs-lookup"><span data-stu-id="36309-171">Every 40ms, the next 40ms of audio from this stream will be encoded and transmitted.</span></span> <span data-ttu-id="36309-172">オーディオの中断を防ぐため、連続して聞こえるオーディオのバッファーは一定のレートでこのストリームに送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36309-172">To prevent audio hiccups, buffers for audio that should be heard continuously should be submitted to this stream at a constant rate.</span></span>

### <a name="stream-contexts"></a><span data-ttu-id="36309-173">ストリーム コンテキスト</span><span class="sxs-lookup"><span data-stu-id="36309-173">Stream Contexts</span></span>
<span data-ttu-id="36309-174">アプリは、`pre_encode_audio_stream::set_custom_stream_context()` と `pre_encode_audio_stream::custom_stream_context()` を使って、プリエンコード オーディオ ストリームでカスタム ポインター サイズのコンテキスト値を管理できます。</span><span class="sxs-lookup"><span data-stu-id="36309-174">Apps can manage custom pointer-sized context values on pre-encode audio streams using `pre_encode_audio_stream::set_custom_stream_context()` and `pre_encode_audio_stream::custom_stream_context()`.</span></span> <span data-ttu-id="36309-175">これらのカスタム ストリーム コンテキストは、GC2 のオーディオ ストリームと補助データ (ストリームのメタデータ、ゲームの状態など) のマッピングを作成するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="36309-175">These custom stream contexts are helpful for creating mappings between GC2's audio streams and auxillary data: stream metadata, game state, etc.</span></span>

### <a name="example"></a><span data-ttu-id="36309-176">例</span><span class="sxs-lookup"><span data-stu-id="36309-176">Example</span></span>
<span data-ttu-id="36309-177">1 つのオーディオ処理フレームでプリエンコード オーディオ ストリームを使う方法に関する簡単なエンド ツー エンドのサンプルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="36309-177">Here's a simplified end-to-end sample for how to use pre-encode audio streams in one audio processing frame:</span></span>

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

## <a name="manipulating-post-decode-chat-audio-data"></a><span data-ttu-id="36309-178">ポストデコード チャット オーディオ データの操作</span><span class="sxs-lookup"><span data-stu-id="36309-178">Manipulating post-decode chat audio data</span></span>

<span data-ttu-id="36309-179">現在のところ、この機能は開発中です。</span><span class="sxs-lookup"><span data-stu-id="36309-179">This feature is currently in development.</span></span> <span data-ttu-id="36309-180">ポストデコード オーディオ操作インターフェイスを呼び出すと、エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="36309-180">Calling into the post-decode audio manipulation interface will cause failures.</span></span>

## <a name="chat-user-lifetimes"></a><span data-ttu-id="36309-181">チャット ユーザーの有効期間</span><span class="sxs-lookup"><span data-stu-id="36309-181">Chat user lifetimes</span></span>

<span data-ttu-id="36309-182">リアルタイム オーディオ操作を有効にすると、チャット ユーザーの有効期間に影響が及びます。</span><span class="sxs-lookup"><span data-stu-id="36309-182">Enabling real-time audio manipulation will affect the lifetimes of chat users.</span></span> <span data-ttu-id="36309-183">`chat_manager::remove_user(chatUserX)` が呼び出された場合、chatUserX によってポイントされた chat_user オブジェクトは、chatUserX を参照するすべてのオーディオ ストリームが破棄されるまで有効なままです。</span><span class="sxs-lookup"><span data-stu-id="36309-183">If `chat_manager::remove_user(chatUserX)` is called, the chat_user object pointed to by chatUserX will remain valid until all audio streams that reference chatUserX have been destroyed.</span></span> <span data-ttu-id="36309-184">次のシナリオを考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="36309-184">Consider the following scenario:</span></span>

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
