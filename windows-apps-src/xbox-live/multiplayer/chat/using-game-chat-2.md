---
title: "ゲーム チャット 2 の使用"
author: KevinAsgari
description: "Xbox Live ゲーム チャット 2 を使用して、ゲームに音声通信を追加する方法について説明します。"
ms.author: tomco
ms.date: 06-14-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信"
ms.openlocfilehash: 19cf4f24eb1f720acc2f72019979300cbd2b9e01
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="using-game-chat-2"></a><span data-ttu-id="ccccf-104">ゲーム チャット 2 の使用</span><span class="sxs-lookup"><span data-stu-id="ccccf-104">Using Game Chat 2</span></span>

<span data-ttu-id="ccccf-105">ゲーム チャット 2 (GC2) の使用に関する概要を紹介します。トピックの内容は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ccccf-105">This is a brief walkthrough on using Game Chat 2 (GC2), containing the following topics:</span></span>

1. [<span data-ttu-id="ccccf-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="ccccf-106">Prerequisites</span></span>](#prereq)
2. [<span data-ttu-id="ccccf-107">初期化</span><span class="sxs-lookup"><span data-stu-id="ccccf-107">Initialization</span></span>](#init)
3. [<span data-ttu-id="ccccf-108">ユーザーの構成</span><span class="sxs-lookup"><span data-stu-id="ccccf-108">Configuring users</span></span>](#config)
4. [<span data-ttu-id="ccccf-109">データ フレームの処理</span><span class="sxs-lookup"><span data-stu-id="ccccf-109">Processing data frames</span></span>](#data)
5. [<span data-ttu-id="ccccf-110">状態変更の処理</span><span class="sxs-lookup"><span data-stu-id="ccccf-110">Processing state changes</span></span>](#state)
6. [<span data-ttu-id="ccccf-111">テキスト チャット</span><span class="sxs-lookup"><span data-stu-id="ccccf-111">Text chat</span></span>](#text)
7. [<span data-ttu-id="ccccf-112">ユーザー補助</span><span class="sxs-lookup"><span data-stu-id="ccccf-112">Accessibility</span></span>](#access)
8. [<span data-ttu-id="ccccf-113">UI</span><span class="sxs-lookup"><span data-stu-id="ccccf-113">UI</span></span>](#UI)
9. [<span data-ttu-id="ccccf-114">ミュート</span><span class="sxs-lookup"><span data-stu-id="ccccf-114">Muting</span></span>](#mute)
10. [<span data-ttu-id="ccccf-115">悪い評判の自動ミュート</span><span class="sxs-lookup"><span data-stu-id="ccccf-115">Bad reputation auto-mute</span></span>](#automute)
11. [<span data-ttu-id="ccccf-116">権限とプライバシー</span><span class="sxs-lookup"><span data-stu-id="ccccf-116">Privilege and privacy</span></span>](#priv)
12. [<span data-ttu-id="ccccf-117">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="ccccf-117">Cleanup</span></span>](#cleanup)
13. [<span data-ttu-id="ccccf-118">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="ccccf-118">How to configure popular scenarios</span></span>](#how-to-configure-popular-scenarios)

## <a name="prerequisites-a-nameprereq"></a><span data-ttu-id="ccccf-119">前提条件<a name="prereq"></span><span class="sxs-lookup"><span data-stu-id="ccccf-119">Prerequisites <a name="prereq"></span></span>

<span data-ttu-id="ccccf-120">GC2 をコンパイルするには、プライマリ ヘッダー GameChat2.h を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-120">Compiling GC2 requires including the primary GameChat2.h header.</span></span> <span data-ttu-id="ccccf-121">適切にリンクするには、プロジェクト内の 1 つ以上のコンパイル ユニットにも GameChat2Impl.h を含める必要があります (スタブ関数実装は小さく、コンパイラーで "インライン" として生成しやすいため、一般的なプリコンパイル済みヘッダーをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="ccccf-121">In order to link properly, your project must also include GameChat2Impl.h in at least one compilation unit (a common precompiled header is recommended since these stub function implementations are small and easy for the compiler to generate as "inline").</span></span>

<span data-ttu-id="ccccf-122">GC2 インターフェイスでは、プロジェクトのコンパイルにおいて、C++/CX と従来の C++ のいずれかを選択する必要がなく、どちらも使用できます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-122">The GC2 interface does not require a project to choose between compiling with C++/CX versus traditional C++; it can be used with either.</span></span> <span data-ttu-id="ccccf-123">また、この実装では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-123">The implementation also doesn't throw exceptions as a means of non-fatal error reporting so you can consume it easily from exception-free projects if preferred.</span></span>

## <a name="initialization-a-nameinit"></a><span data-ttu-id="ccccf-124">初期化 <a name="init"></span><span class="sxs-lookup"><span data-stu-id="ccccf-124">Initialization <a name="init"></span></span>

<span data-ttu-id="ccccf-125">GC2 オブジェクト シングルトンをシングルトンの初期化の有効期間を適用するパラメーターで初期化することで、ライブラリの操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-125">You begin interacting with the library by initializing the GC2 object singleton with parameters that apply the lifetime of the singleton's initialization.</span></span>

```cpp
chat_manager::singleton_instance().initialize(...);
```

## <a name="configuring-users-a-nameconfig"></a><span data-ttu-id="ccccf-126">ユーザーの構成 <a name="config"></span><span class="sxs-lookup"><span data-stu-id="ccccf-126">Configuring users <a name="config"></span></span>

<span data-ttu-id="ccccf-127">インスタンスが初期化されたら、ゲーム チャット インスタンスにローカル ユーザーを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-127">Once the instance is initialized, you must add the local users to the Game Chat instance.</span></span> <span data-ttu-id="ccccf-128">この例では、ユーザー A はローカル ユーザーを表します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-128">In this example, User A will represent a local user.</span></span>

```cpp
chat_user* chatUserA = chat_manager::add_local_user(<user_a_xuid>);
```

<span data-ttu-id="ccccf-129">また、リモート ユーザーと識別子 (リモート ユーザーがいるリモート "エンドポイント" を表すために使用) を追加する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-129">You must also add the remote users and identifiers that will be used to represent the remote "Endpoint" that the user is on.</span></span> <span data-ttu-id="ccccf-130">"エンドポイント" は、リモート デバイスで実行されているアプリのインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="ccccf-130">An "Endpoint" is an instance of the app running on a remote device.</span></span> <span data-ttu-id="ccccf-131">この例では、ユーザー B がエンドポイント X に、ユーザー C と D がエンドポイント Y にいます。エンドポイント X には識別子 "1" が任意に割り当てられ、エンドポイント Y には識別子 "2" が任意に割り当てられています。</span><span class="sxs-lookup"><span data-stu-id="ccccf-131">In this example, User B is on Endpoint X, Users C and D are on Endpoint Y. Endpoint X is arbitrarily assigned identifier "1" and Endpoint Y is arbitrarily assigned identifier "2".</span></span> <span data-ttu-id="ccccf-132">次の呼び出しを使って、GC2 にリモート ユーザーを通知します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-132">You inform GC2 of the remote users with these calls:</span></span>

```cpp
chat_user* chatUserB = chat_manager::add_local_user(<user_b_xuid>, 1);
chat_user* chatUserC = chat_manager::add_local_user(<user_c_xuid>, 2);
chat_user* chatUserD = chat_manager::add_local_user(<user_d_xuid>, 2);
```

<span data-ttu-id="ccccf-133">これで、各リモート ユーザーとローカル ユーザーとの間の通信リレーションシップが構成されました。</span><span class="sxs-lookup"><span data-stu-id="ccccf-133">Now you configure the communication relationship between each remote user and the local user.</span></span> <span data-ttu-id="ccccf-134">この例では、ユーザー A とユーザー B が同じチームに属しており、双方向通信が許可されていると仮定します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-134">In this example, suppose that User A and User B are on the same team and bidirectional communication is allowed.</span></span> `c_communicationRelationshipSendAndReceiveAll` <span data-ttu-id="ccccf-135">は、GameChat2.h で定義されている双方向通信を表す定数です。</span><span class="sxs-lookup"><span data-stu-id="ccccf-135">is a constant defined in GameChat2.h to represent bi-directional communication.</span></span> <span data-ttu-id="ccccf-136">ユーザー A のユーザー B に対するリレーションシップを次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-136">Set User A's relationship to User B with:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
```

<span data-ttu-id="ccccf-137">次に、ユーザー C とユーザー D は "観戦者" であり、ユーザー A を一覧に表示することはできますが、会話は許可されていないと仮定します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-137">Now supposed that User C and D are 'spectators' and should be allowed to list to User A, but not speak.</span></span> `c_communicationRelationshipSendAll` <span data-ttu-id="ccccf-138">は、GameChat2.h で定義されているこの一方向通信を表す定数です。</span><span class="sxs-lookup"><span data-stu-id="ccccf-138">is a constant defined in GameChat2.h to represent this unidirectional communication.</span></span> <span data-ttu-id="ccccf-139">リレーションシップを次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-139">Set the relationships with:</span></span>


```cpp
chatUserA->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAll);
```

<span data-ttu-id="ccccf-140">ローカル ユーザーと通信できないリモート ユーザーがいる場合、それは正常です。</span><span class="sxs-lookup"><span data-stu-id="ccccf-140">If there are any remote users that can't communicate with any local users - that's okay!</span></span> <span data-ttu-id="ccccf-141">これは、ユーザーがチームを決定中か、会話チャネルを任意に変更できるシナリオで発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-141">This may be expected in scenarios where users are determining teams or can change speaking channels arbitrarily.</span></span> <span data-ttu-id="ccccf-142">GC2 がキャッシュするのは追加されたユーザーの情報 (プライバシー リレーションシップと評判) だけなので、すべてのユーザー候補について、そのユーザーが特定のインスタンスのローカル ユーザーと会話できない場合でも、GC2 に通知すると役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-142">GC2 will only cache information (e.g. privacy relationships and reputation) for users that have been added, so it's useful to inform GC2 of all possible users even if they can't speak to any local users at a particular instance.</span></span>

## <a name="processing-data-frames-a-namedata"></a><span data-ttu-id="ccccf-143">データ フレームの処理 <a name="data"></span><span class="sxs-lookup"><span data-stu-id="ccccf-143">Processing data frames <a name="data"></span></span>

<span data-ttu-id="ccccf-144">GC2 には独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-144">GC2 does not have its own transport layer; this must be provided by the app.</span></span> <span data-ttu-id="ccccf-145">このプラグインは、アプリによる `chat_manager::start_processing_data_frames()` メソッドと `chat_manager::finish_processing_data_frames()` メソッドの定期的かつ頻繁な呼び出しです。</span><span class="sxs-lookup"><span data-stu-id="ccccf-145">This plugin is managed by the app's regular, frequent calls to the `chat_manager::start_processing_data_frames()` and `chat_manager::finish_processing_data_frames()` pair of methods.</span></span> <span data-ttu-id="ccccf-146">これらのメソッドを使用して、GC2 は発信データをアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-146">These methods are how GC2 provides outgoing data to the app.</span></span> <span data-ttu-id="ccccf-147">これらは専用のネットワーク スレッドで頻繁にポーリングできるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="ccccf-147">They're designed to operate quickly such that they can be polled frequently on a dedicated networking thread.</span></span> <span data-ttu-id="ccccf-148">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべてのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-148">This provides a convenient place to retrieve all queued data without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="ccccf-149">`chat_manager::start_processing_data_frames()` を呼び出すと、キューに入っているすべてのデータが `game_chat_data_frame` 構造体ポインターの配列で報告されます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-149">When `chat_manager::start_processing_data_frames()` is called, all queued data is reported in an array of `game_chat_data_frame` structure pointers.</span></span> <span data-ttu-id="ccccf-150">アプリでは、配列を反復処理し、ターゲット "エンドポイント" を検査し、アプリのネットワーク層を使用してデータを適切なリモート アプリ インスタンスに配信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-150">Apps should iterate over the array, inspect the target "endpoints", and use the app's networking layer to deliver the data to the appropriate remote app instances.</span></span> <span data-ttu-id="ccccf-151">すべての `game_chat_data_frame` 構造体が終了した後は、`chat_manager:finish_processing_data_frames()` を呼び出すことによってその配列を GC2 に戻してリソースを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-151">Once finished with all the `game_chat_data_frame` structures, the array should be passed back to GC2 to release the resources by calling `chat_manager:finish_processing_data_frames()`.</span></span> <span data-ttu-id="ccccf-152">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-152">For example:</span></span>

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

<span data-ttu-id="ccccf-153">データ フレームの処理頻度が高いほど、エンド ユーザーの感じるオーディオの遅延は低くなります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-153">The more frequently the data frames are processed, the lower the audio latency apparent to the end user will be.</span></span> <span data-ttu-id="ccccf-154">オーディオは 40 ミリ秒のデータ フレームに結合されます。これは、推奨されるポーリング期間です。</span><span class="sxs-lookup"><span data-stu-id="ccccf-154">The audio is coalesced into 40 ms data frames; this is the suggested polling period.</span></span>

## <a name="processing-state-changes-a-namestate"></a><span data-ttu-id="ccccf-155">状態変更の処理 <a name="state"></span><span class="sxs-lookup"><span data-stu-id="ccccf-155">Processing state changes <a name="state"></span></span>

<span data-ttu-id="ccccf-156">GC2 では、アプリによる `chat_manager::start_processing_data_frames()` メソッドの `chat_manager::finish_processing_data_frames()` 定期的かつ頻繁な呼び出しを通じて、受信したテキスト メッセージなどの更新をアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-156">GC2 provides updates to the app, such as received text messages, through the app's regular, frequent calls to the `chat_manager::start_processing_data_frames()` and `chat_manager::finish_processing_data_frames()` pair of methods.</span></span> <span data-ttu-id="ccccf-157">これらのメソッドは、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="ccccf-157">They're designed to operate quickly such that they can be called every graphics frame in your UI rendering loop.</span></span> <span data-ttu-id="ccccf-158">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-158">This provides a convenient place to retrieve all queued changes without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="ccccf-159">`chat_manager::start_processing_data_frames()` を呼び出すと、キューに入っているすべての更新が `game_chat_state_change` 構造体ポインターの配列で報告されます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-159">When `chat_manager::start_processing_data_frames()` is called, all queued updates are reported in an array of `game_chat_state_change` structure pointers.</span></span> <span data-ttu-id="ccccf-160">アプリでは、配列を反復処理し、より具体的な型の基本構造を検査して、基本的な構造体を対応する詳細な型にキャストしてから、その更新を適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-160">Apps should iterate over the array, inspect the base structure for its more specific type, cast the base structure to the corresponding more detailed type, and then handle that update as appropriate.</span></span> <span data-ttu-id="ccccf-161">現在使用可能なすべての `game_chat_state_change` オブジェクトが終了した後は、`chat_manager::finish_processing_state_changes()` を呼び出すことによってその配列を GC2 に戻してリソースを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-161">Once finished with all `game_chat_state_change` objects currently available, that array should be passed back to GC2 to release the resources by calling `chat_manager::finish_processing_state_changes()`.</span></span> <span data-ttu-id="ccccf-162">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-162">For example:</span></span>

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

## <a name="text-chat-a-nametext"></a><span data-ttu-id="ccccf-163">テキスト チャット <a name="text"></span><span class="sxs-lookup"><span data-stu-id="ccccf-163">Text chat <a name="text"></span></span>

<span data-ttu-id="ccccf-164">テキスト チャットを送信するには、`chat_user::chat_user_local::send_chat_text()` を使用します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-164">To send text chat, use `chat_user::chat_user_local::send_chat_text()`.</span></span> <span data-ttu-id="ccccf-165">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-165">For example:</span></span>

```cpp
chatUserA->local()->send_chat_text(L"Hello");
```

<span data-ttu-id="ccccf-166">GC2 では、このメッセージを含むデータ フレームを生成します。このデータ フレームのターゲット エンドポイントは、ローカル ユーザーからテキストを受信するように構成されたユーザーに関連付けられたものになります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-166">GC2 will generate a data frame containing this message; the target endpoints for the data frame will be those associated with users that have been configured to receive text from the local user.</span></span> <span data-ttu-id="ccccf-167">リモート エンドポイントでデータが処理されると、メッセージは `game_chat_text_chat_received_state_change` を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-167">When the data is processed by the remote endpoints, the message will be exposed via a `game_chat_text_chat_received_state_change`.</span></span> <span data-ttu-id="ccccf-168">ボイス チャットと同様に、テキスト チャットでは権限とプライバシーの制限が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-168">As with voice chat, privilege and privacy restrictions are respected for text chat.</span></span> <span data-ttu-id="ccccf-169">ユーザーの間で、テキスト チャットを許可するように構成されているが、権限またはプライバシーの制限によって通信が許可されていない場合、テキスト メッセージは失われます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-169">If a pair of users have been configured to allow text chat, but privilege or privacy restrictions disallow that communication, the text message will be dropped.</span></span>

<span data-ttu-id="ccccf-170">ユーザー補助のために、テキスト チャットの入力と表示のサポートが必要です (詳細については、「[ユーザー補助](#access)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="ccccf-170">Supporting text chat input and display is required for accessibility (see [Accessibility](#access) for more details).</span></span>

## <a name="accessibility-a-nameaccess"></a><span data-ttu-id="ccccf-171">ユーザー補助 <a name="access"></span><span class="sxs-lookup"><span data-stu-id="ccccf-171">Accessibility <a name="access"></span></span>

<span data-ttu-id="ccccf-172">テキスト チャットの入力と表示をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-172">Supporting text chat input and display is required.</span></span> <span data-ttu-id="ccccf-173">テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、ユーザーはこのシステムで、音声合成の支援技術を使用する場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="ccccf-173">Text input is required because, even on platforms or game genres that historically haven't had widespread physical keyboard use, users may configure the system to use text-to-speech assistive technologies.</span></span> <span data-ttu-id="ccccf-174">同様に、ユーザーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-174">Similarly, text display is required because users may configure the system to use speech-to-text.</span></span> <span data-ttu-id="ccccf-175">ローカル ユーザーがこれらの設定を検出できるようにするには、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` および `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` メソッドをそれぞれ呼び出します。必要に応じて、テキストのメカニズムを有効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-175">These preferences can be detected on local users by calling the `chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` and `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` methods respectively, and you may wish to conditionally enable text mechanisms.</span></span>

### <a name="text-to-speech"></a><span data-ttu-id="ccccf-176">音声合成</span><span class="sxs-lookup"><span data-stu-id="ccccf-176">Text-to-speech</span></span>

<span data-ttu-id="ccccf-177">ユーザーが音声合成を有効にしていると、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` は 'true' を返します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-177">When a user has text-to-speech enabled, `chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` will return 'true'.</span></span> <span data-ttu-id="ccccf-178">この状態が検出されると、アプリではテキスト入力の方法を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-178">When this state is detected, the app must provide a method of text input.</span></span> <span data-ttu-id="ccccf-179">現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `chat_user::chat_user_local::synthesize_text_to_speech()` メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-179">Once you have the text input provided by a real or virtual keyboard, pass the string to the `chat_user::chat_user_local::synthesize_text_to_speech()` method.</span></span> <span data-ttu-id="ccccf-180">GC2 では、文字列を検出し、ユーザーの利用可能な音声設定に基づいてオーディオ データを合成します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-180">GC2 will detect and synthesize audio data based on the string and the user's accessible voice preference.</span></span> <span data-ttu-id="ccccf-181">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-181">For example:</span></span>

```cpp
chat_userA->local()->synthesize_text_to_speech(L"Hello");
```

<span data-ttu-id="ccccf-182">この操作の一環として合成されたオーディオは、このローカル ユーザーからオーディオを受信するように構成されたユーザー全員に転送されます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-182">The audio synthesized as part of this operation will be transported to all users that have been configured to receive audio from this local user.</span></span> <span data-ttu-id="ccccf-183">音声合成を有効にしていないユーザーから `chat_user::chat_user_local::synthesize_text_to_speech()` が呼び出された場合、GC2 では何も実行しません。</span><span class="sxs-lookup"><span data-stu-id="ccccf-183">If `chat_user::chat_user_local::synthesize_text_to_speech()` is called on a user who does not have text-to-speech enabled GC2 will take no action.</span></span>

### <a name="speech-to-text"></a><span data-ttu-id="ccccf-184">音声テキスト変換</span><span class="sxs-lookup"><span data-stu-id="ccccf-184">Speech-to-text</span></span>

<span data-ttu-id="ccccf-185">ユーザーが音声テキスト変換を有効にしていると、`chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` は true を返します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-185">When a user has speech-to-text enabled, `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` will return true.</span></span> <span data-ttu-id="ccccf-186">この状態が検出されると、アプリは変換されたチャット メッセージに関連付けられた UI を提供する準備ができている必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-186">When this state is detected, the app must be prepared to provide UI associated with transcribed chat messages.</span></span> <span data-ttu-id="ccccf-187">GC では各リモート ユーザーのオーディオを自動的に変換して、`game_chat_transcribed_chat_received_state_change` を通じて公開します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-187">GC will automatically transcribe each remote user's audio and expose it via a `game_chat_transcribed_chat_received_state_change`.</span></span>

> `Windows::Xbox::UI::Accessibility` <span data-ttu-id="ccccf-188">は、音声からテキストの変換支援技術を搭載したゲーム内のテキストチャットを単純にレンダリングできるように特別に設計された Xbox One のクラスです。</span><span class="sxs-lookup"><span data-stu-id="ccccf-188">is an Xbox One class specifically designed to provide simple rendering of in-game text chat with a focus on speech-to-text assistive technologies.</span></span>

### <a name="speech-to-text-performance-considerations"></a><span data-ttu-id="ccccf-189">音声テキスト変換のパフォーマンスに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="ccccf-189">Speech-to-text performance considerations</span></span>

<span data-ttu-id="ccccf-190">音声テキスト変換が有効の場合、各リモート デバイスの GC2 インスタンスでは音声サービス エンドポイントとの Web ソケット接続を開始します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-190">When speech-to-text is enabled, the GC2 instance on each remote device initiates a web socket connection with the speech services endpoint.</span></span> <span data-ttu-id="ccccf-191">各リモート GC2 クライアントではこの WebSocket を通じて音声サービス エンドポイントにオーディオをアップロードします。音声サービス エンドポイントでは随時、トランスクリプション メッセージをリモート デバイスに返します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-191">Each remote GC2 client uploads audio to the speech services endpoint through this websocket; the speech services endpoint occasionally returns a transcription message to the remote device.</span></span> <span data-ttu-id="ccccf-192">その後、リモート デバイスではトランスクリプション メッセージ (つまり、テキスト メッセージ) をローカル デバイスに送信します。ローカル デバイスでは、GC2 からアプリにテキスト メッセージが提供され、表示されます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-192">The remote device then sends the transcription message (i.e. a text message) to the local device, where the transcribed message is given by GC2 to the app to render.</span></span>

<span data-ttu-id="ccccf-193">そのため、音声テキスト変換の主なパフォーマンス コストは、ネットワーク使用率です。</span><span class="sxs-lookup"><span data-stu-id="ccccf-193">Therefore, the primary performance cost of speech-to-text is network usage.</span></span> <span data-ttu-id="ccccf-194">ネットワーク トラフィックの大半はエンコードされたオーディオのアップロードです。</span><span class="sxs-lookup"><span data-stu-id="ccccf-194">Most of the network traffic is the upload of encoded audio.</span></span> <span data-ttu-id="ccccf-195">"通常" のボイス チャット パスで GC2 によってエンコード済みのオーディオが WebSocket によってアップロードされます。アプリでは `chat_manager::set_audio_encoding_type_and_bitrate` を通じてビットレートを制御します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-195">The websocket uploads audio that has already been encoded by GC2 in the “normal” voice chat path; the app has control over the bitrate via `chat_manager::set_audio_encoding_type_and_bitrate`.</span></span>

## <a name="ui-a-nameui"></a><span data-ttu-id="ccccf-196">UI <a name="UI"></span><span class="sxs-lookup"><span data-stu-id="ccccf-196">UI <a name="UI"></span></span>

<span data-ttu-id="ccccf-197">特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ccccf-197">It's recommended that anywhere players are shown, particularly in a list of gamertags such as a scoreboard, that you also display muted/speaking icons as feedback for the user.</span></span> <span data-ttu-id="ccccf-198">これを行うには、`chat_user::chat_indicator()` を呼び出し、プレイヤーのチャットの現在の瞬間的なステータスを表す `game_chat_user_chat_indicator` を取得します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-198">This is done by calling `chat_user::chat_indicator()` to retrieve a `game_chat_user_chat_indicator` representing the current, instantaneous status of chat for that player.</span></span> <span data-ttu-id="ccccf-199">次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'chatUserA' 変数で指定した `chat_user` オブジェクトのインジケーター値の取得を示します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-199">The following example demonstrates retrieving the indicator value for a `chat_user` object pointed to by the variable 'chatUserA' to determine a particular icon constant value to assign to an 'iconToShow' variable:</span></span>

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

<span data-ttu-id="ccccf-200">`xim_player::chat_indicator()` によって報告される値は、プレイヤーの発声開始から終了までを頻繁に変更することを想定しています。</span><span class="sxs-lookup"><span data-stu-id="ccccf-200">The value reported by `xim_player::chat_indicator()` is expected to change frequently as players start and stop talking, for example.</span></span> <span data-ttu-id="ccccf-201">そのため、すべての UI フレームをポーリングできるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="ccccf-201">It is designed to support apps polling it every UI frame as a result.</span></span>

## <a name="muting-a-namemute"></a><span data-ttu-id="ccccf-202">ミュート <a name="mute"></span><span class="sxs-lookup"><span data-stu-id="ccccf-202">Muting <a name="mute"></span></span>

<span data-ttu-id="ccccf-203">`chat_user::chat_user_local::set_microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-203">The `chat_user::chat_user_local::set_microphone_muted()` method can be used to toggle the mute state of a local user's microphone.</span></span> <span data-ttu-id="ccccf-204">マイクがミュート状態の場合、マイクからオーディオはキャプチャされません。</span><span class="sxs-lookup"><span data-stu-id="ccccf-204">When the microphone is muted, no audio from that microphone will be captured.</span></span> <span data-ttu-id="ccccf-205">ユーザーが Kinect などの共有デバイスを使用している場合、ミュート状態はすべてのユーザーに適用されます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-205">If the user is on a shared device, such as Kinect, the mute state applies to all users.</span></span>

<span data-ttu-id="ccccf-206">`chat_user::chat_user_local::set_remote_user_muted()` メソッドを使用すると、特定のローカル ユーザーに関連するリモート ユーザーのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-206">The `chat_user::chat_user_local::set_remote_user_muted()` method can be used to toggle the mute state of a remote user in relation to a particular local user.</span></span> <span data-ttu-id="ccccf-207">リモート ユーザーがミュート状態の場合、ローカル ユーザーにはそのリモート ユーザーの音声は聞こえません。また、そのリモート ユーザーからのテキスト メッセージを受信しません。</span><span class="sxs-lookup"><span data-stu-id="ccccf-207">When the remote user is muted, the local user won't hear any audio or receive any text messages from the remote user.</span></span>

## <a name="bad-reputation-auto-mute-a-nameautomute"></a><span data-ttu-id="ccccf-208">悪い評判の自動ミュート <a name="automute"></span><span class="sxs-lookup"><span data-stu-id="ccccf-208">Bad reputation auto-mute <a name="automute"></span></span>

<span data-ttu-id="ccccf-209">通常、リモート ユーザーはミュートを解除した状態で開始します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-209">Typically remote users will start off unmuted.</span></span> <span data-ttu-id="ccccf-210">(1) リモート ユーザーがローカル ユーザーのフレンドではなく、(2) リモート ユーザーに悪い評判のフラグがある場合、GC2 ではユーザーをミュート状態で開始します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-210">GC2 will start the users in a muted state when (1) the remote user isn't friends with the local user, and (2) the remote user has a bad reputation flag.</span></span> <span data-ttu-id="ccccf-211">この操作によってユーザーがミュートされている場合、`chat_user::chat_indicator()` は `game_chat_user_chat_indicator::reputation_restricted` を返します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-211">When users are muted due to this operation, `chat_user::chat_indicator()` will return `game_chat_user_chat_indicator::reputation_restricted`.</span></span> <span data-ttu-id="ccccf-212">この状態は、そのリモート ユーザーをターゲット ユーザーとして含む `chat_user::chat_user_local::set_remote_user_muted()` の最初の呼び出しでオーバーライドされます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-212">This state will be overriden by the first call to `chat_user::chat_user_local::set_remote_user_muted()` that includes the remote user as the target user.</span></span>

## <a name="privilege-and-privacy-a-namepriv"></a><span data-ttu-id="ccccf-213">権限とプライバシー <a name="priv"></span><span class="sxs-lookup"><span data-stu-id="ccccf-213">Privilege and privacy <a name="priv"></span></span>

<span data-ttu-id="ccccf-214">ゲームによって構成される通信リレーションシップの上に、GC2 は権限とプライバシーの制限を強制します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-214">On top of the communication relationship configured by the game, GC2 enforces privilege and privacy restrictions.</span></span> <span data-ttu-id="ccccf-215">GC2 では、ユーザーが最初に追加されると、権限とプライバシーの制限の参照を実行します。この操作が完了するまで、ユーザーの `chat_user::chat_indicator()` は常に `game_chat_user_chat_indicator::silent` を返します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-215">GC2 performs privilege and privacy restriction lookups when a user is first added; the user's `chat_user::chat_indicator()` will always return `game_chat_user_chat_indicator::silent` until those operations complete.</span></span> <span data-ttu-id="ccccf-216">ユーザーの通信が権限またはプライバシーの制限による影響を受ける場合、ユーザーの `chat_user::chat_indicator()` は `game_chat_user_chat_indicator::platform_restricted` を返します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-216">If communication with a user is affected by a privilege or privacy restriciton, the user's `chat_user::chat_indicator()` will return `game_chat_user_chat_indicator::platform_restricted`.</span></span>

`chat_user::chat_user_local::get_effective_communication_relationship()` <span data-ttu-id="ccccf-217">を使用すると、不完全な権限とプライバシーの操作によってユーザーが通信できない場合の区別に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-217">can be used to help distinguish when users can't commnicate due to incomplete privilege and privacy operations.</span></span> <span data-ttu-id="ccccf-218">これを使用すると、GC2 によって強制される通信リレーションシップが `game_chat_communication_relationship_flags` の形式で返されます。また、リレーションシップが構成されたリレーションシップと等しくない理由が `game_chat_communication_relationship_adjuster` の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-218">It returns the communication relationship enforced by GC2 in the form of `game_chat_communication_relationship_flags` and the reason the relationship may not be equal to the configured relationship in the form of `game_chat_communication_relationship_adjuster`.</span></span> <span data-ttu-id="ccccf-219">たとえば、参照操作が進行中の場合、`game_chat_communication_relationship_adjuster` は `game_chat_communication_relationship_adjuster::intializing` になります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-219">For example, if the lookup operations are still in progress, the `game_chat_communication_relationship_adjuster` will be `game_chat_communication_relationship_adjuster::intializing`.</span></span> <span data-ttu-id="ccccf-220">この方法は、開発シナリオとデバッグ シナリオで使用することを想定しています。UI に影響を与えるために使用しないでください (「[UI](#UI)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="ccccf-220">This method is expected to be used in development and debugging scenarios; it should not be used to influence UI (see [UI](#UI)).</span></span>

## <a name="cleanup-a-namecleanup"></a><span data-ttu-id="ccccf-221">クリーンアップ <a name="cleanup"></span><span class="sxs-lookup"><span data-stu-id="ccccf-221">Cleanup <a name="cleanup"></span></span>

<span data-ttu-id="ccccf-222">アプリで GC2 を介した通信が不要になった場合は、`chat_manager::cleanup()` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-222">When the app no longer needs communications via GC2, you should call `chat_manager::cleanup()`.</span></span> <span data-ttu-id="ccccf-223">これにより、GC2 で通信の管理に割り当てられたリソースを解放できます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-223">This allows GC2 to reclaim resources that were allocated to manage the communications.</span></span>

## <a name="how-to-configure-popular-scenarios"></a><span data-ttu-id="ccccf-224">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="ccccf-224">How to configure popular scenarios</span></span>

### <a name="push-to-talk"></a><span data-ttu-id="ccccf-225">プッシュして話しかける</span><span class="sxs-lookup"><span data-stu-id="ccccf-225">Push-to-talk</span></span>

<span data-ttu-id="ccccf-226">プッシュして話しかける機能は、`chat_user::chat_user_local::set_microphone_muted()` を使用して実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-226">Push-to-talk should be implemented with `chat_user::chat_user_local::set_microphone_muted()`.</span></span> <span data-ttu-id="ccccf-227">会話を許可するには `set_microphone_muted(false)` を呼び出し、制限するには `set_microphone_muted(true)` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-227">Call `set_microphone_muted(false)` to allow speech and `set_microphone_muted(true)` to restrict it.</span></span> <span data-ttu-id="ccccf-228">この方法を使用すると、GC2 からの応答遅延時間が最少限になります。</span><span class="sxs-lookup"><span data-stu-id="ccccf-228">This method will provide the lowest latency response from GC2.</span></span>

### <a name="teams"></a><span data-ttu-id="ccccf-229">チーム</span><span class="sxs-lookup"><span data-stu-id="ccccf-229">Teams</span></span>

<span data-ttu-id="ccccf-230">ユーザー A とユーザー B が青チーム、ユーザー C とユーザー D が赤チームに属しているとします。</span><span class="sxs-lookup"><span data-stu-id="ccccf-230">Suppose that User A and User B are on Team Blue, and User C and User D are on Team Red.</span></span> <span data-ttu-id="ccccf-231">各ユーザーは、アプリの一意のインスタンスに含まれます。</span><span class="sxs-lookup"><span data-stu-id="ccccf-231">Each user is in a unique instance of the app.</span></span>

<span data-ttu-id="ccccf-232">ユーザー A のデバイス:</span><span class="sxs-lookup"><span data-stu-id="ccccf-232">On User A's device:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
chatUserA->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserA->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

<span data-ttu-id="ccccf-233">ユーザー B のデバイス:</span><span class="sxs-lookup"><span data-stu-id="ccccf-233">On User B's device:</span></span>

```cpp
chatUserB->local()->set_communication_relationship(chatUserA, c_communicationRelationshipSendAndReceiveAll);
chatUserB->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserB->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

<span data-ttu-id="ccccf-234">ユーザー C のデバイス:</span><span class="sxs-lookup"><span data-stu-id="ccccf-234">On User C's device:</span></span>

```cpp
chatUserC->local()->set_communication_relationship(chatUserA, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAndReceiveAll);
```

<span data-ttu-id="ccccf-235">ユーザー D のデバイス:</span><span class="sxs-lookup"><span data-stu-id="ccccf-235">On User D's device:</span></span>

```cpp
chatUserD->local()->set_communication_relationship(chatUserA, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAndReceiveAll);
```

<!--TODO: Include table?-->

### <a name="broadcast"></a><span data-ttu-id="ccccf-236">配信</span><span class="sxs-lookup"><span data-stu-id="ccccf-236">Broadcast</span></span>

<span data-ttu-id="ccccf-237">ユーザー A が指示を出すリーダーで、ユーザー B、C、D は指示を聞くだけと仮定します。</span><span class="sxs-lookup"><span data-stu-id="ccccf-237">Suppose that User A is the leader giving orders and Users B, C, and D can only listen.</span></span> <span data-ttu-id="ccccf-238">各プレイヤーは、一意のデバイスを使用しています。</span><span class="sxs-lookup"><span data-stu-id="ccccf-238">Each player is on a unique device.</span></span>

<span data-ttu-id="ccccf-239">ユーザー A のデバイス:</span><span class="sxs-lookup"><span data-stu-id="ccccf-239">On User A's device:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAll);
```

<span data-ttu-id="ccccf-240">ユーザー B のデバイス:</span><span class="sxs-lookup"><span data-stu-id="ccccf-240">On User B's device:</span></span>

```cpp
chatUserB->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserB->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserB->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

<span data-ttu-id="ccccf-241">ユーザー C のデバイス:</span><span class="sxs-lookup"><span data-stu-id="ccccf-241">On User C's device:</span></span>

```cpp
chatUserC->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserC->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

<span data-ttu-id="ccccf-242">ユーザー D のデバイス:</span><span class="sxs-lookup"><span data-stu-id="ccccf-242">On User D's device:</span></span>

```cpp
chatUserD->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserD->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
```

<!--TODO: Include table?-->
