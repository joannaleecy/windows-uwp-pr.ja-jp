---
title: ゲーム チャット 2 の使用
author: KevinAsgari
description: Xbox Live ゲーム チャット 2 を使用して、ゲームに音声通信を追加する方法について説明します。
ms.author: kevinasg
ms.date: 3/20/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信
ms.localizationpriority: medium
ms.openlocfilehash: e3042d7dac5fd9ef3e99c874dc4ca1937db94fff
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7119222"
---
# <a name="using-game-chat-2-c"></a><span data-ttu-id="e1f8b-104">ゲーム チャット 2 の使用 (C++)</span><span class="sxs-lookup"><span data-stu-id="e1f8b-104">Using Game Chat 2 (C++)</span></span>

<span data-ttu-id="e1f8b-105">ここでは、ゲーム チャット 2 の C++ API の使用方法について概要を紹介します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-105">This is a brief walkthrough on using Game Chat 2's C++ API.</span></span> <span data-ttu-id="e1f8b-106">C# を通じたゲーム チャット 2 へのアクセスを予定しているゲーム開発者は、[ゲーム チャット 2 WinRT プロジェクションの使用に関するページ](using-game-chat-2-winrt.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-106">Game developers wanting to access Game Chat 2 through C# should see [Use Game Chat 2 WinRT Projections](using-game-chat-2-winrt.md).</span></span>

1. [<span data-ttu-id="e1f8b-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="e1f8b-107">Prerequisites</span></span>](#prerequisites)
2. [<span data-ttu-id="e1f8b-108">初期化</span><span class="sxs-lookup"><span data-stu-id="e1f8b-108">Initialization</span></span>](#initialization)
3. [<span data-ttu-id="e1f8b-109">ユーザーの構成</span><span class="sxs-lookup"><span data-stu-id="e1f8b-109">Configuring users</span></span>](#configuring-users)
4. [<span data-ttu-id="e1f8b-110">データ フレームの処理</span><span class="sxs-lookup"><span data-stu-id="e1f8b-110">Processing data frames</span></span>](#processing-data-frames)
5. [<span data-ttu-id="e1f8b-111">状態変更の処理</span><span class="sxs-lookup"><span data-stu-id="e1f8b-111">Processing state changes</span></span>](#processing-state-changes)
6. [<span data-ttu-id="e1f8b-112">テキスト チャット</span><span class="sxs-lookup"><span data-stu-id="e1f8b-112">Text chat</span></span>](#text-chat)
7. [<span data-ttu-id="e1f8b-113">ユーザー補助</span><span class="sxs-lookup"><span data-stu-id="e1f8b-113">Accessibility</span></span>](#accessibility)
8. [<span data-ttu-id="e1f8b-114">UI</span><span class="sxs-lookup"><span data-stu-id="e1f8b-114">UI</span></span>](#ui)
9. [<span data-ttu-id="e1f8b-115">ミュート</span><span class="sxs-lookup"><span data-stu-id="e1f8b-115">Muting</span></span>](#muting)
10. [<span data-ttu-id="e1f8b-116">悪い評判の自動ミュート</span><span class="sxs-lookup"><span data-stu-id="e1f8b-116">Bad reputation auto-mute</span></span>](#bad-reputation-auto-mute)
11. [<span data-ttu-id="e1f8b-117">権限とプライバシー</span><span class="sxs-lookup"><span data-stu-id="e1f8b-117">Privilege and privacy</span></span>](#privilege-and-privacy)
12. [<span data-ttu-id="e1f8b-118">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="e1f8b-118">Cleanup</span></span>](#cleanup)
13. [<span data-ttu-id="e1f8b-119">エラー モデル</span><span class="sxs-lookup"><span data-stu-id="e1f8b-119">Failure model</span></span>](#failure-model)
14. [<span data-ttu-id="e1f8b-120">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="e1f8b-120">How to configure popular scenarios</span></span>](#how-to-configure-popular-scenarios)

## <a name="prerequisites"></a><span data-ttu-id="e1f8b-121">前提条件</span><span class="sxs-lookup"><span data-stu-id="e1f8b-121">Prerequisites</span></span>

<span data-ttu-id="e1f8b-122">ゲーム チャット 2 のコーディングを始める前に、"マイク" デバイス機能を宣言するアプリの AppXManifest を構成している必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-122">Before you get started coding with Game Chat 2, you must have configured your app's AppXManifest to declare the "microphone" device capability.</span></span> <span data-ttu-id="e1f8b-123">AppXManifest 機能については、プラットフォームのドキュメントの各セクションで詳しく説明されています。次のスニペットは、パッケージ/機能ノードの下に存在している必要があり、存在しないとチャットがブロックされる "マイク" デバイス機能ノードを示しています。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-123">AppXManifest capabilities are described in more detail in their respective sections of the platform documentation; the following snippet shows the "microphone" device capability node that should exist under the Package/Capabilities node or else chat will be blocked:</span></span>

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

<span data-ttu-id="e1f8b-124">ゲーム チャット 2 をコンパイルするには、プライマリ ヘッダー GameChat2.h を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-124">Compiling Game Chat 2 requires including the primary GameChat2.h header.</span></span> <span data-ttu-id="e1f8b-125">適切にリンクするには、プロジェクト内の 1 つ以上のコンパイル ユニットにも GameChat2Impl.h を含める必要があります (スタブ関数実装は小さく、コンパイラーで "インライン" として生成しやすいため、一般的なプリコンパイル済みヘッダーをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-125">In order to link properly, your project must also include GameChat2Impl.h in at least one compilation unit (a common precompiled header is recommended since these stub function implementations are small and easy for the compiler to generate as "inline").</span></span>

<span data-ttu-id="e1f8b-126">ゲーム チャット 2 インターフェイスでは、プロジェクトのコンパイルにおいて、C++/CX と従来の C++ のいずれかを選択する必要がなく、どちらも使用できます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-126">The Game Chat 2 interface does not require a project to choose between compiling with C++/CX versus traditional C++; it can be used with either.</span></span> <span data-ttu-id="e1f8b-127">また、この実装では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-127">The implementation also doesn't throw exceptions as a means of non-fatal error reporting so you can consume it easily from exception-free projects if preferred.</span></span> <span data-ttu-id="e1f8b-128">ただし、この実装は、致命的なエラーの報告を手段として例外をスローします (詳しくは「[エラー モデル](#failure)」を参照)。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-128">The implementation does, however, throw exceptions as a means of fatal error reporting (see [Failure model](#failure) for more detail).</span></span>

## <a name="initialization"></a><span data-ttu-id="e1f8b-129">初期化</span><span class="sxs-lookup"><span data-stu-id="e1f8b-129">Initialization</span></span>

<span data-ttu-id="e1f8b-130">ゲーム チャット 2 シングルトン インスタンスをシングルトンの初期化の有効期間を適用するパラメーターで初期化することで、ライブラリの操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-130">You begin interacting with the library by initializing the Game Chat 2 singleton instance with parameters that apply to the lifetime of the singleton's initialization.</span></span>

```cpp
chat_manager::singleton_instance().initialize(...);
```

## <a name="configuring-users"></a><span data-ttu-id="e1f8b-131">ユーザーの構成</span><span class="sxs-lookup"><span data-stu-id="e1f8b-131">Configuring users</span></span>

<span data-ttu-id="e1f8b-132">インスタンスが初期化されたら、ゲーム チャット 2 インスタンスにローカル ユーザーを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-132">Once the instance is initialized, you must add the local users to the Game Chat 2 instance.</span></span> <span data-ttu-id="e1f8b-133">この例では、ユーザー A はローカル ユーザーを表します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-133">In this example, User A will represent a local user.</span></span>

```cpp
chat_user* chatUserA = chat_manager::singleton_instance().add_local_user(<user_a_xuid>);
```

<span data-ttu-id="e1f8b-134">また、リモート ユーザーと識別子 (リモート ユーザーがいるリモート "エンドポイント" を表すために使用) を追加する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-134">You must also add the remote users and identifiers that will be used to represent the remote "Endpoint" that the user is on.</span></span> <span data-ttu-id="e1f8b-135">"エンドポイント" は、リモート デバイスで実行されているアプリのインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-135">An "Endpoint" is an instance of the app running on a remote device.</span></span> <span data-ttu-id="e1f8b-136">この例では、ユーザー B がエンドポイント X に、ユーザー C と D がエンドポイント Y にいます。エンドポイント X には識別子 "1" が任意に割り当てられ、エンドポイント Y には識別子 "2" が任意に割り当てられています。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-136">In this example, User B is on Endpoint X, Users C and D are on Endpoint Y. Endpoint X is arbitrarily assigned identifier "1" and Endpoint Y is arbitrarily assigned identifier "2".</span></span> <span data-ttu-id="e1f8b-137">次の呼び出しを使って、ゲーム チャット 2 にリモート ユーザーを通知します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-137">You inform Game Chat 2 of the remote users with these calls:</span></span>

```cpp
chat_user* chatUserB = chat_manager::singleton_instance().add_remote_user(<user_b_xuid>, 1);
chat_user* chatUserC = chat_manager::singleton_instance().add_remote_user(<user_c_xuid>, 2);
chat_user* chatUserD = chat_manager::singleton_instance().add_remote_user(<user_d_xuid>, 2);
```

<span data-ttu-id="e1f8b-138">これで、各リモート ユーザーとローカル ユーザーとの間の通信リレーションシップが構成されました。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-138">Now you configure the communication relationship between each remote user and the local user.</span></span> <span data-ttu-id="e1f8b-139">この例では、ユーザー A とユーザー B が同じチームに属しており、双方向通信が許可されていると仮定します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-139">In this example, suppose that User A and User B are on the same team and bidirectional communication is allowed.</span></span> `c_communicationRelationshipSendAndReceiveAll` <span data-ttu-id="e1f8b-140">は、GameChat2.h で定義されている双方向通信を表す定数です。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-140">is a constant defined in GameChat2.h to represent bi-directional communication.</span></span> <span data-ttu-id="e1f8b-141">ユーザー A のユーザー B に対するリレーションシップを次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-141">Set User A's relationship to User B with:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
```

<span data-ttu-id="e1f8b-142">次に、ユーザー C とユーザー D は "観戦者" であり、ユーザー A を一覧に表示することはできますが、会話は許可されていないと仮定します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-142">Now suppose that Users C and D are 'spectators' and should be allowed to listen to User A, but not speak.</span></span> `c_communicationRelationshipSendAll` <span data-ttu-id="e1f8b-143">は、GameChat2.h で定義されているこの一方向通信を表す定数です。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-143">is a constant defined in GameChat2.h to represent this unidirectional communication.</span></span> <span data-ttu-id="e1f8b-144">リレーションシップを次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-144">Set the relationships with:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAll);
```

<span data-ttu-id="e1f8b-145">任意の時点で、シングルトン インスタンスに追加されているがローカル ユーザーと通信できるように構成されていないリモート ユーザーがいても問題ありません。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-145">If at any point there are remote users that have been added to the singleton instance but haven't been configured to communicate with any local users - that's okay!</span></span> <span data-ttu-id="e1f8b-146">これは、ユーザーがチームを決定中か、会話チャネルを任意に変更できるシナリオで発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-146">This may be expected in scenarios where users are determining teams or can change speaking channels arbitrarily.</span></span> <span data-ttu-id="e1f8b-147">ゲーム チャット 2 がキャッシュするのは、インスタンスに追加されたユーザーの情報 (プライバシー リレーションシップと評判) だけであるため、すべてのユーザー候補について、そのユーザーが特定の時点でローカル ユーザーと会話できない場合でも、ゲーム チャット 2 に通知すると役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-147">Game Chat 2 will only cache information (e.g. privacy relationships and reputation) for users that have been added to the instance, so it's useful to inform Game Chat 2 of all possible users even if they can't speak to any local users at a particular point in time.</span></span>

<span data-ttu-id="e1f8b-148">最後の点として、ユーザー D がゲームを終了したため、ローカル ゲーム チャット 2 インスタンスから削除する必要があるとします。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-148">Finally, suppose that User D has left the game and should be removed from the local Game Chat 2 instance.</span></span> <span data-ttu-id="e1f8b-149">これは、次の呼び出しで実行できます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-149">That can be done with the following call:</span></span>

```cpp
chat_manager::singleton_instance().remove_user(chatUserD);
```

<span data-ttu-id="e1f8b-150">`chat_manager::remove_user()` を呼び出すと、ユーザー オブジェクトが無効になることがあります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-150">Calling `chat_manager::remove_user()` may invalidate the user object.</span></span> <span data-ttu-id="e1f8b-151">[リアルタイム オーディオ操作](real-time-audio-manipulation.md)を使っている場合、詳しくは[チャット ユーザーの有効期限](real-time-audio-manipulation.md#chat-user-lifetimes)に関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-151">If you are using [real-time audio manipulation](real-time-audio-manipulation.md), please refer to the [Chat user lifetimes](real-time-audio-manipulation.md#chat-user-lifetimes) documentation for further information.</span></span> <span data-ttu-id="e1f8b-152">それ以外の場合、`chat_manager::remove_user()` が呼び出されるとすぐにユーザー オブジェクトは無効になります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-152">Otherwise, the user object is invalidated immediately when `chat_manager::remove_user()` is called.</span></span> <span data-ttu-id="e1f8b-153">ユーザーを削除するタイミングの微妙な制限について詳しくは、「[状態変更の処理](#state)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-153">A subtle restriction on when users can be removed is detailed in [Processing state changes](#state).</span></span>

## <a name="processing-data-frames"></a><span data-ttu-id="e1f8b-154">データ フレームの処理</span><span class="sxs-lookup"><span data-stu-id="e1f8b-154">Processing data frames</span></span>

<span data-ttu-id="e1f8b-155">ゲーム チャット 2 には独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-155">Game Chat 2 does not have its own transport layer; this must be provided by the app.</span></span> <span data-ttu-id="e1f8b-156">このプラグインは、アプリによる `chat_manager::start_processing_data_frames()` メソッドと `chat_manager::finish_processing_data_frames()` メソッドの定期的かつ頻繁な呼び出しです。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-156">This plugin is managed by the app's regular, frequent calls to the `chat_manager::start_processing_data_frames()` and `chat_manager::finish_processing_data_frames()` pair of methods.</span></span> <span data-ttu-id="e1f8b-157">これらのメソッドを使用して、ゲーム チャット 2 は発信データをアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-157">These methods are how Game Chat 2 provides outgoing data to the app.</span></span> <span data-ttu-id="e1f8b-158">これらは専用のネットワーク スレッドで頻繁にポーリングできるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-158">They're designed to operate quickly such that they can be polled frequently on a dedicated networking thread.</span></span> <span data-ttu-id="e1f8b-159">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべてのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-159">This provides a convenient place to retrieve all queued data without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="e1f8b-160">`chat_manager::start_processing_data_frames()` を呼び出すと、キューに入っているすべてのデータが `game_chat_data_frame` 構造体ポインターの配列で報告されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-160">When `chat_manager::start_processing_data_frames()` is called, all queued data is reported in an array of `game_chat_data_frame` structure pointers.</span></span> <span data-ttu-id="e1f8b-161">アプリでは、配列を反復処理し、ターゲット "エンドポイント" を検査し、アプリのネットワーク層を使用してデータを適切なリモート アプリ インスタンスに配信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-161">Apps should iterate over the array, inspect the target "endpoints", and use the app's networking layer to deliver the data to the appropriate remote app instances.</span></span> <span data-ttu-id="e1f8b-162">すべての `game_chat_data_frame` 構造体が終了した後は、`chat_manager:finish_processing_data_frames()` を呼び出すことによってその配列をゲーム チャット 2 に戻してリソースを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-162">Once finished with all the `game_chat_data_frame` structures, the array should be passed back to Game Chat 2 to release the resources by calling `chat_manager:finish_processing_data_frames()`.</span></span> <span data-ttu-id="e1f8b-163">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-163">For example:</span></span>

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

<span data-ttu-id="e1f8b-164">データ フレームの処理頻度が高いほど、エンド ユーザーの感じるオーディオの遅延は低くなります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-164">The more frequently the data frames are processed, the lower the audio latency apparent to the end user will be.</span></span> <span data-ttu-id="e1f8b-165">オーディオは 40 ミリ秒のデータ フレームに結合されます。これは、推奨されるポーリング期間です。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-165">The audio is coalesced into 40 ms data frames; this is the suggested polling period.</span></span>

## <a name="processing-state-changes"></a><span data-ttu-id="e1f8b-166">状態変更の処理</span><span class="sxs-lookup"><span data-stu-id="e1f8b-166">Processing state changes</span></span>

<span data-ttu-id="e1f8b-167">ゲーム チャット 2 では、アプリによる `chat_manager::start_processing_state_changes()` メソッドの `chat_manager::finish_processing_state_changes()` 定期的かつ頻繁な呼び出しを通じて、受信したテキスト メッセージなどの更新をアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-167">Game Chat 2 provides updates to the app, such as received text messages, through the app's regular, frequent calls to the `chat_manager::start_processing_state_changes()` and `chat_manager::finish_processing_state_changes()` pair of methods.</span></span> <span data-ttu-id="e1f8b-168">これらのメソッドは、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-168">They're designed to operate quickly such that they can be called every graphics frame in your UI rendering loop.</span></span> <span data-ttu-id="e1f8b-169">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-169">This provides a convenient place to retrieve all queued changes without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="e1f8b-170">`chat_manager::start_processing_state_changes()` を呼び出すと、キューに入っているすべての更新が `game_chat_state_change` 構造体ポインターの配列で報告されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-170">When `chat_manager::start_processing_state_changes()` is called, all queued updates are reported in an array of `game_chat_state_change` structure pointers.</span></span> <span data-ttu-id="e1f8b-171">アプリでは、配列を反復処理し、より具体的な型の基本構造を検査して、基本的な構造体を対応する詳細な型にキャストしてから、その更新を適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-171">Apps should iterate over the array, inspect the base structure for its more specific type, cast the base structure to the corresponding more detailed type, and then handle that update as appropriate.</span></span> <span data-ttu-id="e1f8b-172">現在使用可能なすべての `game_chat_state_change` オブジェクトが終了した後は、`chat_manager::finish_processing_state_changes()` を呼び出すことによってその配列をゲーム チャット 2 に戻してリソースを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-172">Once finished with all `game_chat_state_change` objects currently available, that array should be passed back to Game Chat 2 to release the resources by calling `chat_manager::finish_processing_state_changes()`.</span></span> <span data-ttu-id="e1f8b-173">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-173">For example:</span></span>

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

<span data-ttu-id="e1f8b-174">`chat_manager::remove_user()` は、ユーザー オブジェクトに関連付けられたメモリをすぐに無効にし、状態変更にユーザー オブジェクトへのポインターが含まれていることがあるため、状態変更の処理中に `chat_manager::remove_user()` を呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-174">Because `chat_manager::remove_user()` immediately invalidates the memory associated with a user object, and state changes may contain pointers to user objects, `chat_manager::remove_user()` must not be called while processing state changes.</span></span>

## <a name="text-chat"></a><span data-ttu-id="e1f8b-175">テキスト チャット</span><span class="sxs-lookup"><span data-stu-id="e1f8b-175">Text chat</span></span>

<span data-ttu-id="e1f8b-176">テキスト チャットを送信するには、`chat_user::chat_user_local::send_chat_text()` を使用します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-176">To send text chat, use `chat_user::chat_user_local::send_chat_text()`.</span></span> <span data-ttu-id="e1f8b-177">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-177">For example:</span></span>

```cpp
chatUserA->local()->send_chat_text(L"Hello");
```

<span data-ttu-id="e1f8b-178">ゲーム チャット 2 では、このメッセージを含むデータ フレームを生成します。このデータ フレームのターゲット エンドポイントは、ローカル ユーザーからテキストを受信するように構成されたユーザーに関連付けられたものになります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-178">Game Chat 2 will generate a data frame containing this message; the target endpoints for the data frame will be those associated with users that have been configured to receive text from the local user.</span></span> <span data-ttu-id="e1f8b-179">リモート エンドポイントでデータが処理されると、メッセージは `game_chat_text_chat_received_state_change` を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-179">When the data is processed by the remote endpoints, the message will be exposed via a `game_chat_text_chat_received_state_change`.</span></span> <span data-ttu-id="e1f8b-180">ボイス チャットと同様に、テキスト チャットでは権限とプライバシーの制限が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-180">As with voice chat, privilege and privacy restrictions are respected for text chat.</span></span> <span data-ttu-id="e1f8b-181">ユーザーの間で、テキスト チャットを許可するように構成されているが、権限またはプライバシーの制限によって通信が許可されていない場合、テキスト メッセージは失われます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-181">If a pair of users have been configured to allow text chat, but privilege or privacy restrictions disallow that communication, the text message will be dropped.</span></span>

<span data-ttu-id="e1f8b-182">ユーザー補助のために、テキスト チャットの入力と表示のサポートが必要です (詳細については、「[ユーザー補助](#access)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-182">Supporting text chat input and display is required for accessibility (see [Accessibility](#access) for more details).</span></span>

## <a name="accessibility"></a><span data-ttu-id="e1f8b-183">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="e1f8b-183">Accessibility</span></span>

<span data-ttu-id="e1f8b-184">テキスト チャットの入力と表示をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-184">Supporting text chat input and display is required.</span></span> <span data-ttu-id="e1f8b-185">テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、ユーザーはこのシステムで、音声合成の支援技術を使用する場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-185">Text input is required because, even on platforms or game genres that historically haven't had widespread physical keyboard use, users may configure the system to use text-to-speech assistive technologies.</span></span> <span data-ttu-id="e1f8b-186">同様に、ユーザーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-186">Similarly, text display is required because users may configure the system to use speech-to-text.</span></span> <span data-ttu-id="e1f8b-187">ローカル ユーザーがこれらの設定を検出できるようにするには、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` および `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` メソッドをそれぞれ呼び出します。必要に応じて、テキストのメカニズムを有効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-187">These preferences can be detected on local users by calling the `chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` and `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` methods respectively, and you may wish to conditionally enable text mechanisms.</span></span>

### <a name="text-to-speech"></a><span data-ttu-id="e1f8b-188">音声合成</span><span class="sxs-lookup"><span data-stu-id="e1f8b-188">Text-to-speech</span></span>

<span data-ttu-id="e1f8b-189">ユーザーが音声合成を有効にしていると、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` は 'true' を返します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-189">When a user has text-to-speech enabled, `chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` will return 'true'.</span></span> <span data-ttu-id="e1f8b-190">この状態が検出されると、アプリではテキスト入力の方法を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-190">When this state is detected, the app must provide a method of text input.</span></span> <span data-ttu-id="e1f8b-191">現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `chat_user::chat_user_local::synthesize_text_to_speech()` メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-191">Once you have the text input provided by a real or virtual keyboard, pass the string to the `chat_user::chat_user_local::synthesize_text_to_speech()` method.</span></span> <span data-ttu-id="e1f8b-192">ゲーム チャット 2 では、文字列を検出し、ユーザーの利用可能な音声設定に基づいてオーディオ データを合成します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-192">Game Chat 2 will detect and synthesize audio data based on the string and the user's accessible voice preference.</span></span> <span data-ttu-id="e1f8b-193">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-193">For example:</span></span>

```cpp
chat_userA->local()->synthesize_text_to_speech(L"Hello");
```

<span data-ttu-id="e1f8b-194">この操作の一環として合成されたオーディオは、このローカル ユーザーからオーディオを受信するように構成されたユーザー全員に転送されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-194">The audio synthesized as part of this operation will be transported to all users that have been configured to receive audio from this local user.</span></span> <span data-ttu-id="e1f8b-195">音声合成を有効にしていないユーザーから `chat_user::chat_user_local::synthesize_text_to_speech()` が呼び出された場合、ゲーム チャット 2 では何も実行しません。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-195">If `chat_user::chat_user_local::synthesize_text_to_speech()` is called on a user who does not have text-to-speech enabled Game Chat 2 will take no action.</span></span>

### <a name="speech-to-text"></a><span data-ttu-id="e1f8b-196">音声テキスト変換</span><span class="sxs-lookup"><span data-stu-id="e1f8b-196">Speech-to-text</span></span>

<span data-ttu-id="e1f8b-197">ユーザーが音声テキスト変換を有効にしていると、`chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` は true を返します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-197">When a user has speech-to-text enabled, `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` will return true.</span></span> <span data-ttu-id="e1f8b-198">この状態が検出されると、アプリは変換されたチャット メッセージに関連付けられた UI を提供する準備ができている必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-198">When this state is detected, the app must be prepared to provide UI associated with transcribed chat messages.</span></span> <span data-ttu-id="e1f8b-199">ゲーム チャット 2 では各リモート ユーザーのオーディオを自動的に変換して、`game_chat_transcribed_chat_received_state_change` を通じて公開します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-199">Game Chat 2 will automatically transcribe each remote user's audio and expose it via a `game_chat_transcribed_chat_received_state_change`.</span></span>

> `Windows::Xbox::UI::Accessibility` <span data-ttu-id="e1f8b-200">は、音声からテキストの変換支援技術を搭載したゲーム内のテキストチャットを単純にレンダリングできるように特別に設計された Xbox One のクラスです。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-200">is an Xbox One class specifically designed to provide simple rendering of in-game text chat with a focus on speech-to-text assistive technologies.</span></span>

### <a name="speech-to-text-performance-considerations"></a><span data-ttu-id="e1f8b-201">音声テキスト変換のパフォーマンスに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="e1f8b-201">Speech-to-text performance considerations</span></span>

<span data-ttu-id="e1f8b-202">音声テキスト変換が有効の場合、各リモート デバイスのゲーム チャット 2 インスタンスでは音声サービス エンドポイントとの Web ソケット接続を開始します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-202">When speech-to-text is enabled, the Game Chat 2 instance on each remote device initiates a web socket connection with the speech services endpoint.</span></span> <span data-ttu-id="e1f8b-203">各リモート ゲーム チャット 2 クライアントではこの WebSocket を通じて音声サービス エンドポイントにオーディオをアップロードします。音声サービス エンドポイントでは随時、トランスクリプション メッセージをリモート デバイスに返します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-203">Each remote Game Chat 2 client uploads audio to the speech services endpoint through this websocket; the speech services endpoint occasionally returns a transcription message to the remote device.</span></span> <span data-ttu-id="e1f8b-204">その後、リモート デバイスではトランスクリプション メッセージ (つまり、テキスト メッセージ) をローカル デバイスに送信します。ローカル デバイスでは、ゲーム チャット 2 からアプリにテキスト メッセージが提供され、表示されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-204">The remote device then sends the transcription message (i.e. a text message) to the local device, where the transcribed message is given by Game Chat 2 to the app to render.</span></span>

<span data-ttu-id="e1f8b-205">そのため、音声テキスト変換の主なパフォーマンス コストは、ネットワーク使用率です。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-205">Therefore, the primary performance cost of speech-to-text is network usage.</span></span> <span data-ttu-id="e1f8b-206">ネットワーク トラフィックの大半はエンコードされたオーディオのアップロードです。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-206">Most of the network traffic is the upload of encoded audio.</span></span> <span data-ttu-id="e1f8b-207">"通常" のボイス チャット パスでゲーム チャット 2 によってエンコード済みのオーディオが WebSocket によってアップロードされます。アプリでは `chat_manager::set_audio_encoding_type_and_bitrate` を通じてビットレートを制御します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-207">The websocket uploads audio that has already been encoded by Game Chat 2 in the “normal” voice chat path; the app has control over the bitrate via `chat_manager::set_audio_encoding_type_and_bitrate`.</span></span>

## <a name="ui"></a><span data-ttu-id="e1f8b-208">UI </span><span class="sxs-lookup"><span data-stu-id="e1f8b-208">UI</span></span>

<span data-ttu-id="e1f8b-209">特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-209">It's recommended that anywhere players are shown, particularly in a list of gamertags such as a scoreboard, that you also display muted/speaking icons as feedback for the user.</span></span> <span data-ttu-id="e1f8b-210">これを行うには、`chat_user::chat_indicator()` を呼び出し、プレイヤーのチャットの現在の瞬間的なステータスを表す `game_chat_user_chat_indicator` を取得します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-210">This is done by calling `chat_user::chat_indicator()` to retrieve a `game_chat_user_chat_indicator` representing the current, instantaneous status of chat for that player.</span></span> <span data-ttu-id="e1f8b-211">次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'chatUserA' 変数で指定した `chat_user` オブジェクトのインジケーター値の取得を示します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-211">The following example demonstrates retrieving the indicator value for a `chat_user` object pointed to by the variable 'chatUserA' to determine a particular icon constant value to assign to an 'iconToShow' variable:</span></span>

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

<span data-ttu-id="e1f8b-212">`xim_player::chat_indicator()` によって報告される値は、プレイヤーの発声開始から終了までを頻繁に変更することを想定しています。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-212">The value reported by `xim_player::chat_indicator()` is expected to change frequently as players start and stop talking, for example.</span></span> <span data-ttu-id="e1f8b-213">そのため、すべての UI フレームをポーリングできるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-213">It is designed to support apps polling it every UI frame as a result.</span></span>

## <a name="muting"></a><span data-ttu-id="e1f8b-214">ミュート </span><span class="sxs-lookup"><span data-stu-id="e1f8b-214">Muting</span></span>

<span data-ttu-id="e1f8b-215">`chat_user::chat_user_local::set_microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-215">The `chat_user::chat_user_local::set_microphone_muted()` method can be used to toggle the mute state of a local user's microphone.</span></span> <span data-ttu-id="e1f8b-216">マイクがミュート状態の場合、マイクからオーディオはキャプチャされません。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-216">When the microphone is muted, no audio from that microphone will be captured.</span></span> <span data-ttu-id="e1f8b-217">ユーザーが Kinect などの共有デバイスを使用している場合、ミュート状態はすべてのユーザーに適用されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-217">If the user is on a shared device, such as Kinect, the mute state applies to all users.</span></span>

<span data-ttu-id="e1f8b-218">`chat_user::chat_user_local::microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-218">The `chat_user::chat_user_local::microphone_muted()` method can be used to retrieve the mute state of a local user's microphone.</span></span> <span data-ttu-id="e1f8b-219">このメソッドは、ローカル ユーザーのマイクが `chat_user::chat_user_local::set_microphone_muted()` の呼び出しを通じてソフトウェアでミュートされているかどうかのみ反映しています。たとえば、ユーザーのヘッドセットのボタンを通じてハードウェアのミュートが制御されていることは反映していません。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-219">This method only reflects whether the local user's microphone has been muted in software via a call to `chat_user::chat_user_local::set_microphone_muted()`; this method does not reflect a hardware mute controlled, for instance, via a button on the user's headset.</span></span> <span data-ttu-id="e1f8b-220">ゲーム チャット 2 を通じてユーザーのオーディオ デバイスのハードウェアのミュート状態を取得するメソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-220">There is no method for retrieving the hardware mute state of a user's audio device through Game Chat 2.</span></span>

<span data-ttu-id="e1f8b-221">`chat_user::chat_user_local::set_remote_user_muted()` メソッドを使用すると、特定のローカル ユーザーに関連するリモート ユーザーのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-221">The `chat_user::chat_user_local::set_remote_user_muted()` method can be used to toggle the mute state of a remote user in relation to a particular local user.</span></span> <span data-ttu-id="e1f8b-222">リモート ユーザーがミュート状態の場合、ローカル ユーザーにはそのリモート ユーザーの音声は聞こえません。また、そのリモート ユーザーからのテキスト メッセージを受信しません。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-222">When the remote user is muted, the local user won't hear any audio or receive any text messages from the remote user.</span></span>

## <a name="bad-reputation-auto-mute"></a><span data-ttu-id="e1f8b-223">悪い評判の自動ミュート</span><span class="sxs-lookup"><span data-stu-id="e1f8b-223">Bad reputation auto-mute</span></span>

<span data-ttu-id="e1f8b-224">通常、リモート ユーザーはミュートを解除した状態で開始します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-224">Typically, remote users will start off unmuted.</span></span> <span data-ttu-id="e1f8b-225">(1) リモート ユーザーがローカル ユーザーのフレンドではなく、(2) リモート ユーザーに悪い評判のフラグがある場合、ゲーム チャット 2 ではユーザーをミュート状態で開始します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-225">Game Chat 2 will start the users in a muted state when (1) the remote user isn't friends with the local user, and (2) the remote user has a bad reputation flag.</span></span> <span data-ttu-id="e1f8b-226">この操作によってユーザーがミュートされている場合、`chat_user::chat_indicator()` は `game_chat_user_chat_indicator::reputation_restricted` を返します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-226">When users are muted due to this operation, `chat_user::chat_indicator()` will return `game_chat_user_chat_indicator::reputation_restricted`.</span></span> <span data-ttu-id="e1f8b-227">この状態は、そのリモート ユーザーをターゲット ユーザーとして含む `chat_user::chat_user_local::set_remote_user_muted()` の最初の呼び出しでオーバーライドされます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-227">This state will be overridden by the first call to `chat_user::chat_user_local::set_remote_user_muted()` that includes the remote user as the target user.</span></span>

## <a name="privilege-and-privacy"></a><span data-ttu-id="e1f8b-228">権限とプライバシー </span><span class="sxs-lookup"><span data-stu-id="e1f8b-228">Privilege and privacy</span></span>

<span data-ttu-id="e1f8b-229">ゲームによって構成される通信リレーションシップの上に、ゲーム チャット 2 は権限とプライバシーの制限を強制します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-229">On top of the communication relationship configured by the game, Game Chat 2 enforces privilege and privacy restrictions.</span></span> <span data-ttu-id="e1f8b-230">ゲーム チャット 2 では、ユーザーが最初に追加されると、権限とプライバシーの制限の参照を実行します。この操作が完了するまで、ユーザーの `chat_user::chat_indicator()` は常に `game_chat_user_chat_indicator::silent` を返します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-230">Game Chat 2 performs privilege and privacy restriction lookups when a user is first added; the user's `chat_user::chat_indicator()` will always return `game_chat_user_chat_indicator::silent` until those operations complete.</span></span> <span data-ttu-id="e1f8b-231">ユーザーの通信が権限またはプライバシーの制限による影響を受ける場合、ユーザーの `chat_user::chat_indicator()` は `game_chat_user_chat_indicator::platform_restricted` を返します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-231">If communication with a user is affected by a privilege or privacy restriction, the user's `chat_user::chat_indicator()` will return `game_chat_user_chat_indicator::platform_restricted`.</span></span> <span data-ttu-id="e1f8b-232">プラットフォーム通信制限は、音声チャットとテキスト チャットの両方に適用されます。テキスト チャットがプラットフォーム制限によりブロックされて音声チャットが制限されないインスタンスはなく、その逆もありません。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-232">Platform communication restrictions apply to both voice and text chat; there will never be an instance where text chat is blocked by a platform restriction but voice chat is not, or vice versa.</span></span>

`chat_user::chat_user_local::get_effective_communication_relationship()` <span data-ttu-id="e1f8b-233">を使用すると、不完全な権限とプライバシーの操作によってユーザーが通信できない場合の区別に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-233">can be used to help distinguish when users can't communicate due to incomplete privilege and privacy operations.</span></span> <span data-ttu-id="e1f8b-234">これを使用すると、ゲーム チャット 2 によって強制される通信リレーションシップが `game_chat_communication_relationship_flags` の形式で返されます。また、リレーションシップが構成されたリレーションシップと等しくない理由が `game_chat_communication_relationship_adjuster` の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-234">It returns the communication relationship enforced by Game Chat 2 in the form of `game_chat_communication_relationship_flags` and the reason the relationship may not be equal to the configured relationship in the form of `game_chat_communication_relationship_adjuster`.</span></span> <span data-ttu-id="e1f8b-235">たとえば、参照操作が進行中の場合、`game_chat_communication_relationship_adjuster` は `game_chat_communication_relationship_adjuster::intializing` になります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-235">For example, if the lookup operations are still in progress, the `game_chat_communication_relationship_adjuster` will be `game_chat_communication_relationship_adjuster::intializing`.</span></span> <span data-ttu-id="e1f8b-236">この方法は、開発シナリオとデバッグ シナリオで使用することを想定しています。UI に影響を与えるために使用しないでください (「[UI](#UI)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-236">This method is expected to be used in development and debugging scenarios; it should not be used to influence UI (see [UI](#UI)).</span></span>

## <a name="cleanup"></a><span data-ttu-id="e1f8b-237">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="e1f8b-237">Cleanup</span></span>

<span data-ttu-id="e1f8b-238">アプリでゲーム チャット 2 を介した通信が不要になった場合は、`chat_manager::cleanup()` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-238">When the app no longer needs communications via Game Chat 2, you should call `chat_manager::cleanup()`.</span></span> <span data-ttu-id="e1f8b-239">これにより、ゲーム チャット 2 で通信の管理に割り当てられたリソースを解放できます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-239">This allows Game Chat 2 to reclaim resources that were allocated to manage the communications.</span></span>

## <a name="failure-model"></a><span data-ttu-id="e1f8b-240">エラー モデル</span><span class="sxs-lookup"><span data-stu-id="e1f8b-240">Failure model</span></span>

<span data-ttu-id="e1f8b-241">また、ゲーム チャット 2 の実装では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-241">The Game Chat 2 implementation doesn't throw exceptions as a means of non-fatal error reporting so you can consume it easily from exception-free projects if preferred.</span></span> <span data-ttu-id="e1f8b-242">ただし、ゲーム チャット 2 は致命的なエラーを通知するために例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-242">Game Chat 2 does, however, throw exceptions to inform about fatal errors.</span></span> <span data-ttu-id="e1f8b-243">これらのエラーは、インスタンスを初期化する前にゲーム チャット インスタンスにユーザーを追加したり、ゲーム チャット 2 インスタンスから削除された後にユーザー オブジェクトにアクセスしたりなど、API の誤用によるものです。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-243">These errors are a result of API misuse, such as adding a user to the Game Chat instance before initializing the instance or accessing a user object after it has been removed from the Game Chat 2 instance.</span></span> <span data-ttu-id="e1f8b-244">これらのエラーは開発の早い段階で検出することが期待され、ゲーム チャット 2 との対話に使用されるパターンを変更して修正することができます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-244">These errors are expected to be caught early in development and can be corrected by modifying the pattern used to interact with Game Chat 2.</span></span> <span data-ttu-id="e1f8b-245">このようなエラーが発生した場合、例外が発生する前に、エラーの原因に関するヒントがデバッガーに出力されます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-245">When such an error occurs, a hint as to what caused the error is printed to the debugger before the exception is raised.</span></span>

## <a name="how-to-configure-popular-scenarios"></a><span data-ttu-id="e1f8b-246">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="e1f8b-246">How to configure popular scenarios</span></span>

### <a name="push-to-talk"></a><span data-ttu-id="e1f8b-247">プッシュして話しかける</span><span class="sxs-lookup"><span data-stu-id="e1f8b-247">Push-to-talk</span></span>

<span data-ttu-id="e1f8b-248">プッシュして話しかける機能は、`chat_user::chat_user_local::set_microphone_muted()` を使用して実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-248">Push-to-talk should be implemented with `chat_user::chat_user_local::set_microphone_muted()`.</span></span> <span data-ttu-id="e1f8b-249">会話を許可するには `set_microphone_muted(false)` を呼び出し、制限するには `set_microphone_muted(true)` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-249">Call `set_microphone_muted(false)` to allow speech and `set_microphone_muted(true)` to restrict it.</span></span> <span data-ttu-id="e1f8b-250">この方法を使用すると、ゲーム チャット 2 からの応答遅延時間が最少限になります。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-250">This method will provide the lowest latency response from Game Chat 2.</span></span>

### <a name="teams"></a><span data-ttu-id="e1f8b-251">チーム</span><span class="sxs-lookup"><span data-stu-id="e1f8b-251">Teams</span></span>

<span data-ttu-id="e1f8b-252">ユーザー A とユーザー B が青チーム、ユーザー C とユーザー D が赤チームに属しているとします。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-252">Suppose that User A and User B are on Team Blue, and User C and User D are on Team Red.</span></span> <span data-ttu-id="e1f8b-253">各ユーザーは、アプリの一意のインスタンスに含まれます。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-253">Each user is in a unique instance of the app.</span></span>

<span data-ttu-id="e1f8b-254">ユーザー A のデバイス:</span><span class="sxs-lookup"><span data-stu-id="e1f8b-254">On User A's device:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
chatUserA->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserA->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

<span data-ttu-id="e1f8b-255">ユーザー B のデバイス:</span><span class="sxs-lookup"><span data-stu-id="e1f8b-255">On User B's device:</span></span>

```cpp
chatUserB->local()->set_communication_relationship(chatUserA, c_communicationRelationshipSendAndReceiveAll);
chatUserB->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserB->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

<span data-ttu-id="e1f8b-256">ユーザー C のデバイス:</span><span class="sxs-lookup"><span data-stu-id="e1f8b-256">On User C's device:</span></span>

```cpp
chatUserC->local()->set_communication_relationship(chatUserA, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAndReceiveAll);
```

<span data-ttu-id="e1f8b-257">ユーザー D のデバイス:</span><span class="sxs-lookup"><span data-stu-id="e1f8b-257">On User D's device:</span></span>

```cpp
chatUserD->local()->set_communication_relationship(chatUserA, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAndReceiveAll);
```

### <a name="broadcast"></a><span data-ttu-id="e1f8b-258">配信</span><span class="sxs-lookup"><span data-stu-id="e1f8b-258">Broadcast</span></span>

<span data-ttu-id="e1f8b-259">ユーザー A が指示を出すリーダーで、ユーザー B、C、D は指示を聞くだけと仮定します。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-259">Suppose that User A is the leader giving orders and Users B, C, and D can only listen.</span></span> <span data-ttu-id="e1f8b-260">各プレイヤーは、一意のデバイスを使用しています。</span><span class="sxs-lookup"><span data-stu-id="e1f8b-260">Each player is on a unique device.</span></span>

<span data-ttu-id="e1f8b-261">ユーザー A のデバイス:</span><span class="sxs-lookup"><span data-stu-id="e1f8b-261">On User A's device:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserC, c_communicationRelationshipSendAll);
chatUserA->local()->set_communication_relationship(chatUserD, c_communicationRelationshipSendAll);
```

<span data-ttu-id="e1f8b-262">ユーザー B のデバイス:</span><span class="sxs-lookup"><span data-stu-id="e1f8b-262">On User B's device:</span></span>

```cpp
chatUserB->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserB->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
chatUserB->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

<span data-ttu-id="e1f8b-263">ユーザー C のデバイス:</span><span class="sxs-lookup"><span data-stu-id="e1f8b-263">On User C's device:</span></span>

```cpp
chatUserC->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserC->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserC->local()->set_communication_relationship(chatUserD, game_chat_communication_relationship_flags::none);
```

<span data-ttu-id="e1f8b-264">ユーザー D のデバイス:</span><span class="sxs-lookup"><span data-stu-id="e1f8b-264">On User D's device:</span></span>

```cpp
chatUserD->local()->set_communication_relationship(chatUserA, c_communicationRelationshipReceiveAll);
chatUserD->local()->set_communication_relationship(chatUserB, game_chat_communication_relationship_flags::none);
chatUserD->local()->set_communication_relationship(chatUserC, game_chat_communication_relationship_flags::none);
```
