---
title: ゲーム チャット 2 への移行
description: 既存のゲーム チャット コードをゲーム チャット 2 を使用するように移行する方法について説明します。
ms.date: 05/02/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信
ms.localizationpriority: medium
ms.openlocfilehash: e963210091694a07114f10d5a3dc531a353621df
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653587"
---
# <a name="migration-from-game-chat-to-game-chat-2"></a><span data-ttu-id="0bbeb-104">ゲーム チャットからゲーム チャット 2 への移行</span><span class="sxs-lookup"><span data-stu-id="0bbeb-104">Migration from Game Chat to Game Chat 2</span></span>

<span data-ttu-id="0bbeb-105">このドキュメントでは、ゲーム チャットとゲーム チャット 2 の類似点と、ゲーム チャットからゲーム チャット 2 に移行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-105">This document details the similarities between Game Chat and Game Chat 2 and how to migrate from Game Chat to Game Chat 2.</span></span> <span data-ttu-id="0bbeb-106">そのため、ゲーム チャット 2 への移行を検討している、既存のゲーム チャットの実装を含むタイトルを対象としています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-106">As such, it is for titles that have an existing Game Chat implementation that wish to migrate to Game Chat 2.</span></span> <span data-ttu-id="0bbeb-107">既存のゲーム チャットの実装がない場合は、「[ゲーム チャット 2 の使用](using-game-chat-2.md)」から開始することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-107">If you don't already have a Game Chat implementation, the suggested starting point is [Using Game Chat 2](using-game-chat-2.md).</span></span> 

## <a name="preface"></a><span data-ttu-id="0bbeb-108">はじめに</span><span class="sxs-lookup"><span data-stu-id="0bbeb-108">Preface</span></span>

<span data-ttu-id="0bbeb-109">元のゲーム チャット API は、チャット ユーザーと音声チャンネルの概念を公開し、Xbox Live のゲーム内ボイス チャット シナリオの実装を支援する WinRT API でした。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-109">The original Game Chat API is a WinRT API that exposed a concept of chat users and voice channels to assist in the implementation of Xbox Live in-game voice chat scenarios.</span></span> <span data-ttu-id="0bbeb-110">ゲーム チャット API はチャット API を基に構築されています。チャット API 自体もユーザー チャットと音声チャンネルの概念を公開する WinRT API でしたが、必要なオーディオ デバイスの管理は低レベルでした。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-110">The Game Chat API is built on top of the Chat API, which itself is a WinRT API that exposed a concept of chat users and voice channels while requiring low-level management of audio devices.</span></span> <span data-ttu-id="0bbeb-111">ゲーム チャット 2 は、元のゲーム チャット API とチャット API の後継です。チーム内のコミュニケーションなどの基本的なチャット シナリオについては、よりシンプルな API となり、同時にブロードキャスト スタイルのコミュニケーションやリアルタイムのオーディオ操作などの高度なチャット シナリオでは、より高い柔軟性を提供するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-111">Game Chat 2 is the successor to the original Game Chat and Chat APIs - it was designed to be a simpler API for basic chat scenarios, such as team communication, while simultaneously providing more flexibility for advanced chat scenarios, such as broadcast-style communication and real-time audio manipulation.</span></span> <span data-ttu-id="0bbeb-112">ゲーム チャットとゲーム チャット 2 はいずれも同じニッチな用途に対応しています。各 API は Xbox Live 対応のゲーム内ボイス チャットを統合するための便利なメソッドを提供する一方で、タイトルは、ゲーム チャットやゲーム チャット 2 のリモート インスタンスとの間でデータ パケットを送受信するためのトランスポート層を提供します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-112">Both Game Chat and Game Chat 2 fill the same niche: the APIs each provide a convenient method for integrating Xbox Live enabled, in-game voice chat, while the title provides a transport layer for transmitting data packets to and from remote instances of Game Chat or Game Chat 2.</span></span>

<span data-ttu-id="0bbeb-113">ゲーム チャット 2 API は、元のゲーム チャット API やチャット API に比べて多くの利点があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-113">The Game Chat 2 API has many advantages over the original Game Chat and Chat APIs.</span></span> <span data-ttu-id="0bbeb-114">その要点のいくつかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-114">Some highlights include:</span></span>
* <span data-ttu-id="0bbeb-115">"チャンネル" モデルに制限されない柔軟性の高いユーザー指向の API。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-115">A flexible user-oriented API that is not restricted to the "channel" model.</span></span>
* <span data-ttu-id="0bbeb-116">データ ソースとデータ受信側の両方でのパケット フィルタ リングにより帯域幅が向上。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-116">Bandwidth improvements due to packet filtering by both data sources and data receivers.</span></span>
* <span data-ttu-id="0bbeb-117">アプリで構成可能なアフィニティを使用して有効期間が長い 2 つのスレッドを内部制限。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-117">An internal restriction to 2 long-lived threads with app-configurable affinity.</span></span>
* <span data-ttu-id="0bbeb-118">C++ と WinRT の両方の形式で利用可能な API。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-118">An API available in both C++ and WinRT forms.</span></span>
* <span data-ttu-id="0bbeb-119">"do work" パターンに沿った簡略化された消費モデル。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-119">Simplified consumption model aligning with a "do work" pattern.</span></span>
* <span data-ttu-id="0bbeb-120">カスタム アロケーターを通じてゲーム チャット 2 の割り当てをリダイレクトするメモリ フック。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-120">Memory hooks to redirect Game Chat 2 allocations through a custom allocator.</span></span>
* <span data-ttu-id="0bbeb-121">より便利なクロスプラットフォーム開発エクスペリエンスを実現する、同一 UWP + 排他リソース アプリケーション (ERA) ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-121">Identical UWP + Exclusive Resource Application (ERA) headers for a more convenient cross-plat development experience.</span></span>

<span data-ttu-id="0bbeb-122">このドキュメントでは、ゲーム チャットとゲーム チャット 2 の類似点と、ゲーム チャットからゲーム チャット 2 C++ API に移行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-122">This document details the similarities between Game Chat and Game Chat 2 and how to migrate from Game Chat to the Game Chat 2 C++ API.</span></span> <span data-ttu-id="0bbeb-123">ゲーム チャットからゲーム チャット 2 WinRT API への移行に関心がある場合は、このドキュメントでゲーム チャットの概念をゲーム チャット 2 にマップする方法を理解してから、WinRT に固有のパターンについて、「[ゲーム チャット 2 (WinRT プロジェクション) の使用](using-game-chat-2-winrt.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-123">If you are interested in migration from Game Chat to the Game Chat 2 WinRT API, it is suggested that you read this document to understand how to map Game Chat concepts to Game Chat 2, and then see [Using Game Chat 2 WinRT Projections](using-game-chat-2-winrt.md) for the patterns specific to WinRT.</span></span> <span data-ttu-id="0bbeb-124">このドキュメントで示す元のゲーム チャットのサンプル コードでは、C++/CX を使用します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-124">The sample code for the original Game Chat in this document will use C++/CX.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="0bbeb-125">前提条件</span><span class="sxs-lookup"><span data-stu-id="0bbeb-125">Prerequisites</span></span>

<span data-ttu-id="0bbeb-126">ゲーム チャット 2 のコーディングを始める前に、"マイク" デバイス機能を宣言するアプリの AppXManifest を構成している必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-126">Before you get started coding with Game Chat 2, you must have configured your app's AppXManifest to declare the "microphone" device capability.</span></span> <span data-ttu-id="0bbeb-127">AppXManifest 機能については、プラットフォームのドキュメントの各セクションで詳しく説明されています。次のスニペットは、パッケージ/機能ノードの下に存在している必要があり、存在しないとチャットがブロックされる "マイク" デバイス機能ノードを示しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-127">AppXManifest capabilities are described in more detail in their respective sections of the platform documentation; the following snippet shows the "microphone" device capability node that should exist under the Package/Capabilities node or else chat will be blocked:</span></span>

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

<span data-ttu-id="0bbeb-128">ゲーム チャット 2 をコンパイルするには、プライマリ ヘッダー GameChat2.h を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-128">Compiling Game Chat 2 requires including the primary GameChat2.h header.</span></span> <span data-ttu-id="0bbeb-129">適切にリンクするには、プロジェクト内の 1 つ以上のコンパイル ユニットにも GameChat2Impl.h を含める必要があります (スタブ関数実装は小さく、コンパイラーで "インライン" として生成しやすいため、一般的なプリコンパイル済みヘッダーをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-129">In order to link properly, your project must also include GameChat2Impl.h in at least one compilation unit (a common precompiled header is recommended since these stub function implementations are small and easy for the compiler to generate as "inline").</span></span>

<span data-ttu-id="0bbeb-130">ゲーム チャット 2 インターフェイスでは、プロジェクトのコンパイルにおいて、C++/CX と従来の C++ のいずれかを選択する必要がなく、どちらも使用できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-130">The Game Chat 2 interface does not require a project to choose between compiling with C++/CX versus traditional C++; it can be used with either.</span></span> <span data-ttu-id="0bbeb-131">また、この実装では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-131">The implementation also doesn't throw exceptions as a means of non-fatal error reporting so you can consume it easily from exception-free projects if preferred.</span></span> <span data-ttu-id="0bbeb-132">ただし、この実装は、致命的なエラーの報告を手段として例外をスローします (詳しくは「[エラー モデル](#failure-model-and-debugging)」を参照)。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-132">The implementation does, however, throw exceptions as a means of fatal error reporting (see [Failure model](#failure-model-and-debugging) for more detail).</span></span>

## <a name="initialization"></a><span data-ttu-id="0bbeb-133">初期化</span><span class="sxs-lookup"><span data-stu-id="0bbeb-133">Initialization</span></span>

### <a name="game-chat"></a><span data-ttu-id="0bbeb-134">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-134">Game Chat</span></span>

<span data-ttu-id="0bbeb-135">元のゲーム チャットとの対話は、`ChatManager` クラスを通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-135">Interacting with the original Game Chat is done through the `ChatManager` class.</span></span> <span data-ttu-id="0bbeb-136">次の例では、既定のパラメーターを使用して `ChatManager` インスタンスを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-136">The following example shows how to construct a `ChatManager` instance using default parameters:</span></span>

```cpp
auto chatManager = ref new ChatManager();
```

### <a name="game-chat-2"></a><span data-ttu-id="0bbeb-137">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-137">Game Chat 2</span></span>

<span data-ttu-id="0bbeb-138">ゲーム チャット 2 とのすべての対話は、ゲーム チャット 2 の `chat_manager` シングルトンを通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-138">All interaction with Game Chat 2 is done through Game Chat 2's `chat_manager` singleton.</span></span> <span data-ttu-id="0bbeb-139">ライブラリに対して意味のある操作を行う前に、このシングルトンを初期化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-139">The singleton must be initialized before any meaningful interaction with the library can occur.</span></span> <span data-ttu-id="0bbeb-140">シングルトンの初期化時に、ローカルとリモートの最大同時チャット ユーザー数を指定する必要があります。これは、ゲーム チャット 2 が、予想されたユーザー数に比例してメモリを事前に割り当てるためです。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-140">The singleton requires that the maximum number of concurrent local and remote chat users be specified at initialization time; this is because Game Chat 2 pre-allocates memory proportional to the expected number of users.</span></span> <span data-ttu-id="0bbeb-141">次の例では、ローカルとリモートの最大同時チャット ユーザー数が 4 人である場合に、シングルトン インスタンスを初期化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-141">The following example shows how to intialize the singleton instance when the maximum number of concurrent local and remote chat users will be four:</span></span>

```cpp
chat_manager::singleton_instance().initialize(4);
```

<span data-ttu-id="0bbeb-142">同様に、初期化中に指定できるいくつかのオプション パラメーターがあります。リモート チャット ユーザーの既定のレンダリング ボリュームや、ゲーム チャット 2 で自動的に音声テキスト変換を実行するかどうかなどです。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-142">There are several optional parameters that can be specified during initialization as well, such as the default render volume of remote chat users and whether Game Chat 2 should perform automatic speech-to-text conversion.</span></span> <span data-ttu-id="0bbeb-143">これらのパラメーターの詳細については、`chat_manager::initialize()` のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-143">For more detail on these parameters, refer to the documentation of `chat_manager::initialize()`.</span></span>

## <a name="configuring-users"></a><span data-ttu-id="0bbeb-144">ユーザーの構成</span><span class="sxs-lookup"><span data-stu-id="0bbeb-144">Configuring users</span></span>

### <a name="game-chat"></a><span data-ttu-id="0bbeb-145">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-145">Game Chat</span></span>

<span data-ttu-id="0bbeb-146">元のゲーム チャット API へのローカル ユーザーの追加は、`ChatManager::AddLocalUserToChatChannelAsync()` を通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-146">Adding local users to the original Game Chat API is done through `ChatManager::AddLocalUserToChatChannelAsync()`.</span></span> <span data-ttu-id="0bbeb-147">複数のチャット チャンネルにユーザーを追加するには、それぞれ別のチャンネルを指定する、複数の呼び出しが必要です。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-147">Adding the user to multiple chat channels requires multiple calls, each specifying a different channel.</span></span> <span data-ttu-id="0bbeb-148">次の例では、チャンネル 0 に xuid が "myXuid" であるユーザーを追加する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-148">The following example shows how to add the user with xuid "myXuid" to channel 0:</span></span>

```cpp
auto asyncOperation = chatManager->AddLocalUserToChatChannelAsync(0, L"myXuid");
```

<span data-ttu-id="0bbeb-149">リモート ユーザーは、直接、インスタンスには追加されません。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-149">Remote users are not added to the instance directly.</span></span> <span data-ttu-id="0bbeb-150">タイトルのネットワークにリモート デバイスが表示されると、タイトルはリモート デバイスを表すオブジェクトを作成し、`ChatManager::HandleNewRemoteConsole()` を通じてゲーム チャットに新しいデバイスを通知します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-150">When a remote device appears in the title's network, the title creates an object that represents the remote device and informs Game Chat of the new device via `ChatManager::HandleNewRemoteConsole()`.</span></span> <span data-ttu-id="0bbeb-151">タイトルは、`CompareUniqueConsoleIdentifiersHandler` を実装することによって、リモート デバイスを表すオブジェクトをゲーム チャットと比較するメソッドを提供する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-151">The title must also provide a method of comparing the objects representing the remote devices to Game Chat by implementing `CompareUniqueConsoleIdentifiersHandler`.</span></span> <span data-ttu-id="0bbeb-152">次の例では、このデリゲートをゲーム チャットに提供する方法を示します。`Platform::String` オブジェクトを使用してリモート デバイスを表しており、`L"1"` で表される新しいデバイスがタイトルのネットワークに参加したと仮定しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-152">The following example shows how to provide this delegate to Game Chat, assuming `Platform::String` objects are used to represent remote devices and a new device represented by string `L"1"` has joined the title's network:</span></span>

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

<span data-ttu-id="0bbeb-153">ゲーム チャットは、このデバイスについて通知されると、すべてのローカル ユーザーに関する情報を含むパケットを生成し、リモート デバイスのゲーム チャット インスタンスに送信するために、これらのパケットをタイトルに提供します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-153">Once Game Chat has been informed of this device, it will generate packets containing information about any local users and provide these packets to the title for transmission to the Game Chat instance on the remote device.</span></span> <span data-ttu-id="0bbeb-154">同様に、リモート デバイス上のゲーム チャットは、タイトルがゲーム チャットのローカル インスタンスを送信する先のリモート デバイス上のユーザー関する情報を含むパケットを精製します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-154">Similarly, the Game Chat instance on the remote device will generate packets containing information about users on that remote device that the title will transmit to the local instance of Game Chat.</span></span> <span data-ttu-id="0bbeb-155">ローカル インスタンスが新しいリモート ユーザーに関する情報を含むパケットを受信すると、新しいリモート ユーザーは、`ChatManager::GetUsers()` 経由で利用可能なローカル インスタンスのユーザーのリストに追加されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-155">When the local instance receives packets containing information about new remote users, the new remote users are added to the local instance's list of users, available through `ChatManager::GetUsers()`.</span></span>

<span data-ttu-id="0bbeb-156">同様の呼び出しを通じて実行は、ゲームのチャット インスタンスからユーザーを削除する`ChatManager::RemoveLocalUserFromChatChannelAsync()`と `ChatManager::RemoveRemoteConsoleAsync()`</span><span class="sxs-lookup"><span data-stu-id="0bbeb-156">Removing users from the Game Chat instance is performed through similar calls to `ChatManager::RemoveLocalUserFromChatChannelAsync()` and `ChatManager::RemoveRemoteConsoleAsync()`</span></span>

### <a name="game-chat-2"></a><span data-ttu-id="0bbeb-157">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-157">Game Chat 2</span></span>

<span data-ttu-id="0bbeb-158">ゲーム チャット 2 へのローカル ユーザーの追加は、`chat_manager::add_local_user()` を通じて同期的に実行されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-158">Adding local users to Game Chat 2 is done synchronously through `chat_manager::add_local_user()`.</span></span> <span data-ttu-id="0bbeb-159">この例では、ユーザー A は、Xbox ユーザー ID が `L"myLocalXboxUserId"` であるローカル ユーザーを表します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-159">In this example, User A will represent a local user with Xbox User Id `L"myLocalXboxUserId"`:</span></span>

```cpp
chat_user* chatUserA = chat_manager::singleton_instance().add_local_user(L"myLocalXboxUserId");
```

<span data-ttu-id="0bbeb-160">ユーザーは特定のチャンネルには追加されないことに注意してください。ゲーム チャット 2 では、チャンネルではなく「コミュニケーション関係」の概念を使用して、ユーザーが互いに話したり、聞いたりできるかどうかを管理します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-160">Notice that the user is not added to a particular channel - Game Chat 2 uses a concept of "communication relationships" rather than channels to manage whether users can speak to and hear each other.</span></span> <span data-ttu-id="0bbeb-161">コミュニケーション関係を構成する方法は、このセクションで後で説明します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-161">The method of configuring communication relationships is addressed later in this section.</span></span>

<span data-ttu-id="0bbeb-162">ローカル ユーザーと同様に、リモート ユーザーは同期的にローカルのゲーム チャット 2 インスタンスに追加されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-162">Similar to local users, remote users are added synchronously to the local Game Chat 2 instance.</span></span> <span data-ttu-id="0bbeb-163">これと同時に、リモート ユーザーは、リモート デバイスを表すために使用される識別子に関連付けられる必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-163">The remote users must simultaneously be associated with identifiers that will be used to represent the remote device.</span></span> <span data-ttu-id="0bbeb-164">ゲーム チャット 2 では、リモート デバイスで実行されているアプリのインスタンスを "エンドポイント" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-164">Game Chat 2 refers to an instance of the app running on a remote device as an "Endpoint".</span></span> <span data-ttu-id="0bbeb-165">この例では、ユーザー B は、整数 `1` で表されるエンドポイントで Xbox ユーザー ID `L"remoteXboxUserId"` を持つユーザーです。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-165">In this example, User B will be a user with Xbox User Id `L"remoteXboxUserId"` on an endpoint represented by the integer `1`.</span></span>

```cpp
chat_user* chatUserB = chat_manager::singleton_instance().add_remote_user(L"remoteXboxUserId", 1);
```

<span data-ttu-id="0bbeb-166">ユーザーがインスタンスに追加されたら、各リモート ユーザーと各ローカル ユーザーの間に「コミュニケーション関係」を構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-166">Once the users have been added to the instance, you should configure the "communication relationship" between each remote user and each local user.</span></span> <span data-ttu-id="0bbeb-167">この例では、ユーザー A とユーザー B が同じチームに属しており、双方向通信が許可されていると仮定します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-167">In this example, suppose that User A and User B are on the same team and bidirectional communication is allowed.</span></span> <span data-ttu-id="0bbeb-168">`c_communicationRelationshiSendAndReceiveAll` GameChat2.h 双方向通信を表すための定数を定義します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-168">`c_communicationRelationshiSendAndReceiveAll` is a constant defined in GameChat2.h to represent bi-directional communication.</span></span> <span data-ttu-id="0bbeb-169">この関係は、次のようにして構成できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-169">The relationship can be configured with:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
```

<span data-ttu-id="0bbeb-170">最後の点として、ユーザー B がゲームを終了したため、ローカル ゲーム チャット インスタンスから削除する必要があるとします。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-170">Finally, suppose that User B has left the game and should be removed from the local Game Chat instance.</span></span> <span data-ttu-id="0bbeb-171">これは、次の呼び出しで同期的に実行されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-171">That is performed synchronously with the following call:</span></span>

```cpp
chat_manager::singleton_instance().remove_user(chatUserD);
```

<span data-ttu-id="0bbeb-172">さらに詳しい例や個々の API メソッドのリファレンスについては、「[ゲーム チャット 2 の使用 - ユーザーの構成](using-game-chat-2.md#configuring-users)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-172">Refer to [Using Game Chat 2 - Configuring Users](using-game-chat-2.md#configuring-users) for more detailed examples or the reference for individual API methods for more information.</span></span>

## <a name="processing-data"></a><span data-ttu-id="0bbeb-173">データの処理</span><span class="sxs-lookup"><span data-stu-id="0bbeb-173">Processing data</span></span>

### <a name="game-chat"></a><span data-ttu-id="0bbeb-174">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-174">Game Chat</span></span>

<span data-ttu-id="0bbeb-175">ゲーム チャットには独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-175">Game Chat does not have its own transport layer; this must be provided by the app.</span></span> <span data-ttu-id="0bbeb-176">送信パケットは、`OnOutgoingChatPacketReady` イベントをサブスクライブし、パケットの送信先とトランスポートの要件を決定する引数を検査することによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-176">Outgoing packets are handled by subscribing to the `OnOutgoingChatPacketReady` event and inspecting the arguments to determine the packet destination and transport requirements.</span></span> <span data-ttu-id="0bbeb-177">次の例は、イベントをサブスクライブし、タイトルで実装されている `HandleOutgoingPacket()` メソッドに引数を転送する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-177">The following example shows how to subscribe to the event and forward the arguments the `HandleOutgoingPacket()` method implemented by the title:</span></span>

```cpp
auto token = chatManager->OnOutgoingChatPacketReady +=
    ref new Windows::Foundation::EventHandler<Microsoft::Xbox::GameChat::ChatPacketEventArgs^>(
        [this](Platform::Object^, Microsoft::Xbox::GameChat::ChatPacketEventArgs^ args)
    {
        this->HandleOutgoingPacket(args);
    });
```

<span data-ttu-id="0bbeb-178">受信パケットは、`ChatManager::ProcessingIncomingChatMessage()` を通じてゲーム チャットに送信されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-178">Incoming packets are submitted to Game Chat via `ChatManager::ProcessingIncomingChatMessage()`.</span></span> <span data-ttu-id="0bbeb-179">未処理のパケット バッファーとリモート デバイス識別子を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-179">The raw packet buffer and the remote device identifier must be provided.</span></span> <span data-ttu-id="0bbeb-180">次の例は、ローカルの `packetBuffer` に保存されているパケットと、ローカル変数 `remoteIdentifier` に保存されているリモート デバイス識別子を送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-180">The following example shows how to submit a packet that is stored in the local `packetBuffer` and remote device identifier stored in the local variable `remoteIdentifier`.</span></span>

```cpp
Platform::String^ remoteIdentifier = /* The identifier associated with the device that generated this packet */
Windows::Storage::Streams::IBuffer^ packetBuffer = /* The incoming chat packet */

chatManager->ProcessIncomingChatMessage(packetBuffer, remoteIdentifier);
```

### <a name="game-chat-2"></a><span data-ttu-id="0bbeb-181">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-181">Game Chat 2</span></span>

<span data-ttu-id="0bbeb-182">同様に、ゲーム チャット 2 には独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-182">Similarly, Game Chat 2 does not have its own transport layer; this must be provided by the app.</span></span> <span data-ttu-id="0bbeb-183">送信パケットは、アプリによる `chat_manager::start_processing_data_frames()` メソッドと `chat_manager::finish_processing_data_frames()` メソッドの定期的かつ頻繁な呼び出しによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-183">Outgoing packets are handled by the app's regular, frequent calls to the `chat_manager::start_processing_data_frames()` and `chat_manager::finish_processing_data_frames()` pair of methods.</span></span> <span data-ttu-id="0bbeb-184">これらのメソッドを使用して、ゲーム チャット 2 は発信データをアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-184">These methods are how Game Chat 2 provides outgoing data to the app.</span></span> <span data-ttu-id="0bbeb-185">これらは専用のネットワーク スレッドで頻繁にポーリングできるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-185">They're designed to operate quickly such that they can be polled frequently on a dedicated networking thread.</span></span> <span data-ttu-id="0bbeb-186">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべてのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-186">This provides a convenient place to retrieve all queued data without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="0bbeb-187">`chat_manager::start_processing_data_frames()` を呼び出すと、キューに入っているすべてのデータが `game_chat_data_frame` 構造体ポインターの配列で報告されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-187">When `chat_manager::start_processing_data_frames()` is called, all queued data is reported in an array of `game_chat_data_frame` structure pointers.</span></span> <span data-ttu-id="0bbeb-188">アプリでは、配列を反復処理し、ターゲット "エンドポイント" を検査し、アプリのネットワーク層を使用してデータを適切なリモート アプリ インスタンスに配信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-188">Apps should iterate over the array, inspect the target "endpoints", and use the app's networking layer to deliver the data to the appropriate remote app instances.</span></span> <span data-ttu-id="0bbeb-189">すべての `game_chat_data_frame` 構造体が終了した後は、`chat_manager:finish_processing_data_frames()` を呼び出すことによってその配列をゲーム チャット 2 に戻してリソースを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-189">Once finished with all the `game_chat_data_frame` structures, the array should be passed back to Game Chat 2 to release the resources by calling `chat_manager:finish_processing_data_frames()`.</span></span> <span data-ttu-id="0bbeb-190">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-190">For example:</span></span>

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

<span data-ttu-id="0bbeb-191">データ フレームの処理頻度が高いほど、エンド ユーザーの感じるオーディオの遅延は低くなります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-191">The more frequently the data frames are processed, the lower the audio latency apparent to the end user will be.</span></span> <span data-ttu-id="0bbeb-192">オーディオは 40 ミリ秒のデータ フレームに結合されます。これは、推奨されるポーリング期間です。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-192">The audio is coalesced into 40 ms data frames; this is the suggested polling period.</span></span>

<span data-ttu-id="0bbeb-193">受信データは、`chat_manager::processing_incoming_data()` を通じてゲーム チャット 2 に送信されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-193">Incoming data is submitted to Game Chat 2 via `chat_manager::processing_incoming_data()`.</span></span> <span data-ttu-id="0bbeb-194">データ バッファーとリモート エンドポイント識別子を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-194">The data buffer and the remote endpoint identifier must be provided.</span></span> <span data-ttu-id="0bbeb-195">次の例は、ローカル変数 `dataFrame` に保存されているデータ パケットと、ローカル変数 `remoteEndpointIdentifier` に保存されているリモート エンドポイント識別子を送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-195">The following example shows how to submit a data packet that is stored in the local variable `dataFrame` and the remote endpoint identifier stored in the local variable `remoteEndpointIdentifier`:</span></span>

```cpp
uin64_t remoteEndpointIdentier = /* The identifier associated with the endpoint that generated this packet */
uint32_t dataFrameSize = /* The size of the incoming data frame, in bytes */
uint8_t* dataFrame = /* A pointer to the buffer containing the incoming data */

chatManager::singleton_instance().process_incoming_data(remoteEndpointIdentifier, dataFrameSize, dataFrame);
```

## <a name="processing-events"></a><span data-ttu-id="0bbeb-196">イベントの処理</span><span class="sxs-lookup"><span data-stu-id="0bbeb-196">Processing events</span></span>

### <a name="game-chat"></a><span data-ttu-id="0bbeb-197">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-197">Game Chat</span></span>

<span data-ttu-id="0bbeb-198">ゲーム チャットでは、イベント生成モデルを使用して、関心のあるできごとが発生したことをアプリに通知します。たとえば、テキスト メッセージの受信や、ユーザーのアクセシビリティの基本設定の変更です。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-198">Game Chat uses an eventing model to inform the app when something of interest occurs - such as the receipt of a text message or the changing of a user's accessibility preference.</span></span> <span data-ttu-id="0bbeb-199">アプリは、関心のある各イベントをサブスクライブし、イベントのハンドラーを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-199">The app must subscribe to and implement a handler for each event of interest.</span></span> <span data-ttu-id="0bbeb-200">次の例は、`OnTextMessageReceived` イベントをサブスクライブし、アプリで実装されている `OnTextChatReceived()` または `OnTranscribedChatReceived()` メソッドに引数を転送する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-200">This example shows how to subscribe to the `OnTextMessageReceived` event and forward the arguments to the `OnTextChatReceived()` or `OnTranscribedChatReceived()` methods implemented by the app:</span></span>

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

### <a name="game-chat-2"></a><span data-ttu-id="0bbeb-201">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-201">Game Chat 2</span></span>

<span data-ttu-id="0bbeb-202">ゲーム チャット 2 では、アプリによる `chat_manager::start_processing_state_changes()` メソッドの `chat_manager::finish_processing_state_changes()` 定期的かつ頻繁な呼び出しを通じて、受信したテキスト メッセージなどの更新をアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-202">Game Chat 2 provides updates to the app, such as received text messages, through the app's regular, frequent calls to the `chat_manager::start_processing_state_changes()` and `chat_manager::finish_processing_state_changes()` pair of methods.</span></span> <span data-ttu-id="0bbeb-203">これらのメソッドは、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-203">They're designed to operate quickly such that they can be called every graphics frame in your UI rendering loop.</span></span> <span data-ttu-id="0bbeb-204">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-204">This provides a convenient place to retrieve all queued changes without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="0bbeb-205">`chat_manager::start_processing_state_changes()` を呼び出すと、キューに入っているすべての更新が `game_chat_state_change` 構造体ポインターの配列で報告されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-205">When `chat_manager::start_processing_state_changes()` is called, all queued updates are reported in an array of `game_chat_state_change` structure pointers.</span></span> <span data-ttu-id="0bbeb-206">アプリでは、配列を反復処理し、より具体的な型の基本構造を検査して、基本的な構造体を対応する詳細な型にキャストしてから、その更新を適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-206">Apps should iterate over the array, inspect the base structure for its more specific type, cast the base structure to the corresponding more detailed type, and then handle that update as appropriate.</span></span> <span data-ttu-id="0bbeb-207">現在使用可能なすべての `game_chat_state_change` オブジェクトが終了した後は、`chat_manager::finish_processing_state_changes()` を呼び出すことによってその配列をゲーム チャット 2 に戻してリソースを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-207">Once finished with all `game_chat_state_change` objects currently available, that array should be passed back to Game Chat 2 to release the resources by calling `chat_manager::finish_processing_state_changes()`.</span></span> <span data-ttu-id="0bbeb-208">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-208">For example:</span></span>

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

<span data-ttu-id="0bbeb-209">`chat_manager::remove_user()` は、ユーザー オブジェクトに関連付けられたメモリをすぐに無効にし、状態変更にユーザー オブジェクトへのポインターが含まれていることがあるため、状態変更の処理中に `chat_manager::remove_user()` を呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-209">Because `chat_manager::remove_user()` immediately invalidates the memory associated with a user object, and state changes may contain pointers to user objects, `chat_manager::remove_user()` must not be called while processing state changes.</span></span>

## <a name="text-chat"></a><span data-ttu-id="0bbeb-210">テキスト チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-210">Text chat</span></span>

### <a name="game-chat"></a><span data-ttu-id="0bbeb-211">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-211">Game Chat</span></span>

<span data-ttu-id="0bbeb-212">ゲーム チャットでテキスト チャットを送信するには、`GameChatUser::GenerateTextMessage()` を使用できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-212">To send text chat with Game Chat, `GameChatUser::GenerateTextMessage()` can be used.</span></span> <span data-ttu-id="0bbeb-213">次の例は、`chatUser` 変数によって表されるローカル チャット ユーザーにチャット テキスト メッセージを送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-213">The following example shows how to send a chat text message with a local chat user represented by the `chatUser` variable:</span></span>

```cpp
chatUser->GenerateTextMessage(L"Hello", false);
```

<span data-ttu-id="0bbeb-214">2 番目のブール値パラメーターは、音声合成変換を制御します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-214">The second boolean parameter controls text-to-speech conversion.</span></span> <span data-ttu-id="0bbeb-215">詳細については、次を参照してください。[アクセシビリティ](#accessibility)します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-215">For more details, see [Accessibility](#accessibility).</span></span> <span data-ttu-id="0bbeb-216">ゲームのチャットでは、このメッセージを格納しているチャット パケットが生成されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-216">Game Chat then generates a chat packet containing this message.</span></span> <span data-ttu-id="0bbeb-217">ゲーム チャットのリモート インスタンスには、`OnTextMessageReceived` イベント経由でテキスト メッセージが通知されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-217">Remote instances of Game Chat will be notified of the text message via the `OnTextMessageReceived` event.</span></span>

### <a name="game-chat-2"></a><span data-ttu-id="0bbeb-218">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-218">Game Chat 2</span></span>

<span data-ttu-id="0bbeb-219">ゲーム チャット 2 でテキスト チャットを送信するには、`chat_user::chat_user_local::send_chat_text()` を使用します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-219">To send text chat with Game Chat 2, use `chat_user::chat_user_local::send_chat_text()`.</span></span> <span data-ttu-id="0bbeb-220">次の例は、`chatUser` 変数によって表されるローカル チャット ユーザーにチャット テキスト メッセージを送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-220">This following example shows how to send a chat text message with a local chat user represented by the `chatUser` variable:</span></span>

```cpp
chatUser->local()->send_chat_text(L"Hello");
```

<span data-ttu-id="0bbeb-221">ゲーム チャット 2 では、このメッセージを含むデータ フレームを生成します。このデータ フレームのターゲット エンドポイントは、ローカル ユーザーからテキストを受信するように構成されたユーザーに関連付けられたものになります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-221">Game Chat 2 will generate a data frame containing this message; the target endpoints for the data frame will be those associated with users that have been configured to receive text from the local user.</span></span> <span data-ttu-id="0bbeb-222">リモート エンドポイントでデータが処理されると、メッセージは `game_chat_text_chat_received_state_change` を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-222">When the data is processed by the remote endpoints, the message will be exposed via a `game_chat_text_chat_received_state_change`.</span></span> <span data-ttu-id="0bbeb-223">ボイス チャットと同様に、テキスト チャットでは権限とプライバシーの制限が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-223">As with voice chat, privilege and privacy restrictions are respected for text chat.</span></span> <span data-ttu-id="0bbeb-224">ユーザーの間で、テキスト チャットを許可するように構成されているが、権限またはプライバシーの制限によって通信が許可されていない場合、テキスト メッセージは通知なしで失われます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-224">If a pair of users have been configured to allow text chat, but privilege or privacy restrictions disallow that communication, the text message will be silently dropped.</span></span>

<span data-ttu-id="0bbeb-225">ユーザー補助のために、テキスト チャットの入力と表示のサポートが必要です (詳細については、「[ユーザー補助](#accessibility)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-225">Supporting text chat input and display is required for accessibility (see [Accessibility](#accessibility) for more details).</span></span>

## <a name="accessibility"></a><span data-ttu-id="0bbeb-226">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="0bbeb-226">Accessibility</span></span>

<span data-ttu-id="0bbeb-227">テキスト チャットの入力と表示のサポートは、ゲーム チャットおよびゲーム チャット 2 の両方に必要です。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-227">Supporting text chat input and display is required for both Game Chat and Game Chat 2.</span></span> <span data-ttu-id="0bbeb-228">テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、ユーザーはこのシステムで、音声合成の支援技術を使用する場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-228">Text input is required because, even on platforms or game genres that historically haven't had widespread physical keyboard use, users may configure the system to use text-to-speech assistive technologies.</span></span> <span data-ttu-id="0bbeb-229">同様に、ユーザーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-229">Similarly, text display is required because users may configure the system to use speech-to-text.</span></span> <span data-ttu-id="0bbeb-230">ゲーム チャットおよびゲーム チャット 2 はいずれも、ユーザーのユーザー補助の設定を検出して考慮するメソッドを提供します。これらの設定に基づいて、条件付きでテキストのメカニズムを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-230">Both Game Chat and Game Chat 2 provide methods of detecting and respecting a user's accessibility preferences; you may wish to conditionally enable text mechanisms based on these settings.</span></span>

### <a name="text-to-speech---game-chat"></a><span data-ttu-id="0bbeb-231">音声合成 - ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-231">Text-to-speech - Game Chat</span></span>

<span data-ttu-id="0bbeb-232">ユーザーが音声合成を有効にしていると、`GameChatUser::HasRequestedSynthesizedAudio()` は true を返します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-232">When a user has text-to-speech enabled, `GameChatUser::HasRequestedSynthesizedAudio()` will return true.</span></span> <span data-ttu-id="0bbeb-233">この状態が検出されると、`GameChatUser::GenerateTextMessage()` は、ローカルのユーザーに関連付けられているオーディオ ストリームに挿入されている音声合成のオーディオを生成します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-233">When this state is detected, `GameChatUser::GenerateTextMessage()` will additionally generate text-to-speech audio that is inserted into the audio stream associated with the local user.</span></span> <span data-ttu-id="0bbeb-234">次の例は、`chatUser` 変数によって表されるローカル ユーザーにチャット テキスト メッセージを送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-234">The following example shows how to send a chat text message with a local user represented by the `chatUser` variable:</span></span>

```cpp
chatUser->GenerateTextMessage(L"Hello", true);
```

<span data-ttu-id="0bbeb-235">2 番目のブール値パラメーターは、アプリが音声テキスト変換の基本設定を上書きすることを許可するために使用されます。'true' は、ユーザーの音声合成の基本設定が有効になっている場合に、ゲーム チャットがオン税構成のオーディオを生成する必要があることを示します。'false' は、ゲーム チャットがメッセージから音声合成のオーディオを生成しないことを示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-235">The second boolean parameter is used to allow the app to override the speech-to-text preference - 'true' indicates that Game Chat should generate text-to-speech audio when the user's text-to-speech preference has been enabled, while 'false' indicates that Game Chat should never generate text-to-speech audio from the message.</span></span>

### <a name="text-to-speech---game-chat-2"></a><span data-ttu-id="0bbeb-236">音声合成 - ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-236">Text-to-speech - Game Chat 2</span></span>

<span data-ttu-id="0bbeb-237">ユーザーが音声合成を有効にしていると、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` は 'true' を返します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-237">When a user has text-to-speech enabled, `chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` will return 'true'.</span></span> <span data-ttu-id="0bbeb-238">この状態が検出されると、アプリではテキスト入力の方法を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-238">When this state is detected, the app must provide a method of text input.</span></span> <span data-ttu-id="0bbeb-239">現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `chat_user::chat_user_local::synthesize_text_to_speech()` メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-239">Once you have the text input provided by a real or virtual keyboard, pass the string to the `chat_user::chat_user_local::synthesize_text_to_speech()` method.</span></span> <span data-ttu-id="0bbeb-240">ゲーム チャット 2 では、文字列を検出し、ユーザーの利用可能な音声設定に基づいてオーディオ データを合成します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-240">Game Chat 2 will detect and synthesize audio data based on the string and the user's accessible voice preference.</span></span> <span data-ttu-id="0bbeb-241">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-241">For example:</span></span>

```cpp
chat_userA->local()->synthesize_text_to_speech(L"Hello");
```

<span data-ttu-id="0bbeb-242">この操作の一環として合成されたオーディオは、このローカル ユーザーからオーディオを受信するように構成されたユーザー全員に転送されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-242">The audio synthesized as part of this operation will be transported to all users that have been configured to receive audio from this local user.</span></span> <span data-ttu-id="0bbeb-243">音声合成を有効にしていないユーザーから `chat_user::chat_user_local::synthesize_text_to_speech()` が呼び出された場合、ゲーム チャット 2 では何も実行しません。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-243">If `chat_user::chat_user_local::synthesize_text_to_speech()` is called on a user who does not have text-to-speech enabled Game Chat 2 will take no action.</span></span>

### <a name="speech-to-text---game-chat"></a><span data-ttu-id="0bbeb-244">音声テキスト変換 - ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-244">Speech-to-text - Game Chat</span></span>

<span data-ttu-id="0bbeb-245">ユーザーが音声テキスト変換を有効にしていると、`GameChatUser::HasRequestSynthesizedAudio()` は 'true' を返します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-245">When a user has speech-to-text enabled, `GameChatUser::HasRequestSynthesizedAudio()` will return 'true'.</span></span> <span data-ttu-id="0bbeb-246">この状態が検出されると、ゲーム チャットは自動的に各リモート ユーザーの音声をテキストに変換し、`OnTextMessageReceived` イベントを通じて公開します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-246">When this state is detected, Game Chat will automatically transcribe the audio of each remote user's audio and expose it via the `OnTextMessageReceived` event.</span></span> <span data-ttu-id="0bbeb-247">テキストに変換されたメッセージを受信したために `OnTextMessageReceived` イベントが発生すると、`TextMessageReceivedEventArgs` はメッセージの種類として `ChatTextMessageType::TranscribedSpeechMessage` を示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-247">When the `OnTextMessageReceived` event fires due to the receipt of a transcription message, the `TextMessageReceivedEventArgs` will indicate a message type of `ChatTextMessageType::TranscribedSpeechMessage`.</span></span>

### <a name="speech-to-text---game-chat-2"></a><span data-ttu-id="0bbeb-248">音声テキスト変換 - ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-248">Speech-to-text - Game Chat 2</span></span>

<span data-ttu-id="0bbeb-249">ユーザーが音声テキスト変換を有効にしていると、`chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` は true を返します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-249">When a user has speech-to-text enabled, `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` will return true.</span></span> <span data-ttu-id="0bbeb-250">この状態が検出されると、アプリは変換されたチャット メッセージに関連付けられた UI を提供する準備ができている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-250">When this state is detected, the app must be prepared to provide UI associated with transcribed chat messages.</span></span> <span data-ttu-id="0bbeb-251">ゲーム チャット 2 では各リモート ユーザーのオーディオを自動的に変換して、`game_chat_transcribed_chat_received_state_change` を通じて公開します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-251">Game Chat 2 will automatically transcribe each remote user's audio and expose it via a `game_chat_transcribed_chat_received_state_change`.</span></span>

> <span data-ttu-id="0bbeb-252">`Windows::Xbox::UI::Accessibility` Xbox One クラス専用に作られた音声からテキストへの支援技術に重点を置いて、ゲーム内のテキストのチャットの単純なレンダリングを提供します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-252">`Windows::Xbox::UI::Accessibility` is an Xbox One class specifically designed to provide simple rendering of in-game text chat with a focus on speech-to-text assistive technologies.</span></span>

<span data-ttu-id="0bbeb-253">音声テキスト変換のパフォーマンスに関する考慮事項の詳細については、「[ゲーム チャット 2 の使用 - 音声テキスト変換のパフォーマンスに関する考慮事項](using-game-chat-2.md#speech-to-text-performance-considerations)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-253">Refer to [Using Game Chat 2 - Speech-to-text performance considerations](using-game-chat-2.md#speech-to-text-performance-considerations) for more details on speech-to-text performance considerations.</span></span>

## <a name="ui"></a><span data-ttu-id="0bbeb-254">UI</span><span class="sxs-lookup"><span data-stu-id="0bbeb-254">UI</span></span>

<span data-ttu-id="0bbeb-255">特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-255">It's recommended that anywhere players are shown, particularly in a list of gamertags such as a scoreboard, that you also display muted/speaking icons as feedback for the user.</span></span> <span data-ttu-id="0bbeb-256">ゲーム チャット 2 には、表示する適切な UI 要素を簡単に判断する方法を提供する一体化したインジケーターが導入されています。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-256">Game Chat 2 introduces a coalesced indicator that provides a simpler means of determining the appropriate UI elements to show.</span></span>

### <a name="game-chat"></a><span data-ttu-id="0bbeb-257">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-257">Game Chat</span></span>

<span data-ttu-id="0bbeb-258">`GameChatUser` には、適切な UI 要素を判断するときに一般的に検査される 3 つのプロパティ `GameChatUser::TalkingMode`、`GameChatUser::IsMuted`、`GameChatUser::RestrictionMode` があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-258">A `GameChatUser` has three properties that are commonly inspected when determining appropriate UI elements - `GameChatUser::TalkingMode`, `GameChatUser::IsMuted`, and `GameChatUser::RestrictionMode`.</span></span> <span data-ttu-id="0bbeb-259">次の例では、'chatUser' 変数によって指定される `GameChatUser` オブジェクトから `iconToShow` 変数に割り当てる特定のアイコンの定数値を決定するためのヒューリスティックを示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-259">The following example demonstrates a possible heuristic for determining a particular icon constant vlaue to assign to an `iconToShow` variable from a `GameChatUser` object pointed to by the variable 'chatUser'.</span></span>

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

### <a name="game-chat-2"></a><span data-ttu-id="0bbeb-260">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-260">Game Chat 2</span></span>

<span data-ttu-id="0bbeb-261">ゲーム チャット 2 には、プレイヤーのチャットについて現在の瞬間的なステータスを表すために使用される、一体化された `game_chat_user_chat_indicator` があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-261">Game Chat 2 has a coalesced `game_chat_user_chat_indicator` used to represent the current, instantaneous status of chat for a player.</span></span> <span data-ttu-id="0bbeb-262">この値は、`chat_user::chat_indicator()` を呼び出すことによって取得されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-262">This value is retrieved by calling `chat_user::chat_indicator()`.</span></span> <span data-ttu-id="0bbeb-263">次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'chatUser' 変数で指定した `chat_user` オブジェクトのインジケーター値の取得を示します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-263">The following example demonstrates retrieving the indicator value for a `chat_user` object pointed to by the variable 'chatUser' to determine a particular icon constant value to assign to an 'iconToShow' variable:</span></span>

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

## <a name="muting"></a><span data-ttu-id="0bbeb-264">ミュート </span><span class="sxs-lookup"><span data-stu-id="0bbeb-264">Muting</span></span>

## <a name="game-chat"></a><span data-ttu-id="0bbeb-265">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-265">Game Chat</span></span>

<span data-ttu-id="0bbeb-266">ゲーム チャットでのユーザーのミュートとミュート解除は、それぞれ `ChatManager::MuteUserFromAllChannels()` または `ChatManager::UnMuteUIserFromAllChannels()` の呼び出しによって実行されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-266">Muting or unmuting a user in Game Chat is performed through a call to `ChatManager::MuteUserFromAllChannels()` or `ChatManager::UnMuteUIserFromAllChannels()`, respectively.</span></span> <span data-ttu-id="0bbeb-267">ユーザーのミュート状態は、`GameChatUser::IsMuted` または `GameChatUser::IsLocalUserMuted` を調べることによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-267">The mute state of a user can be retrieved by inspecting `GameChatUser::IsMuted` or `GameChatUser::IsLocalUserMuted`.</span></span>

## <a name="game-chat-2"></a><span data-ttu-id="0bbeb-268">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-268">Game Chat 2</span></span>

<span data-ttu-id="0bbeb-269">`chat_user::chat_user_local::set_microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-269">The `chat_user::chat_user_local::set_microphone_muted()` method can be used to toggle the mute state of a local user's microphone.</span></span> <span data-ttu-id="0bbeb-270">マイクがミュート状態の場合、マイクからオーディオはキャプチャされません。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-270">When the microphone is muted, no audio from that microphone will be captured.</span></span> <span data-ttu-id="0bbeb-271">ユーザーが Kinect などの共有デバイスを使用している場合、ミュート状態はすべてのユーザーに適用されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-271">If the user is on a shared device, such as Kinect, the mute state applies to all users.</span></span>

<span data-ttu-id="0bbeb-272">`chat_user::chat_user_local::microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-272">The `chat_user::chat_user_local::microphone_muted()` method can be used to retrieve the mute state of a local user's microphone.</span></span> <span data-ttu-id="0bbeb-273">このメソッドは、ローカル ユーザーのマイクが `chat_user::chat_user_local::set_microphone_muted()` の呼び出しを通じてソフトウェアでミュートされているかどうかのみ反映しています。たとえば、ユーザーのヘッドセットのボタンを通じてハードウェアのミュートが制御されていることは反映していません。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-273">This method only reflects whether the local user's microphone has been muted in software via a call to `chat_user::chat_user_local::set_microphone_muted()`; this method does not reflect a hardware mute controlled, for instance, via a button on the user's headset.</span></span> <span data-ttu-id="0bbeb-274">ゲーム チャット 2 を通じてユーザーのオーディオ デバイスのハードウェアのミュート状態を取得するメソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-274">There is no method for retrieving the hardware mute state of a user's audio device through Game Chat 2.</span></span>

<span data-ttu-id="0bbeb-275">`chat_user::chat_user_local::set_remote_user_muted()` メソッドを使用すると、特定のローカル ユーザーに関連するリモート ユーザーのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-275">The `chat_user::chat_user_local::set_remote_user_muted()` method can be used to toggle the mute state of a remote user in relation to a particular local user.</span></span> <span data-ttu-id="0bbeb-276">リモート ユーザーがミュート状態の場合、ローカル ユーザーにはそのリモート ユーザーの音声は聞こえません。また、そのリモート ユーザーからのテキスト メッセージを受信しません。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-276">When the remote user is muted, the local user won't hear any audio or receive any text messages from the remote user.</span></span>

## <a name="bad-reputation-auto-mute"></a><span data-ttu-id="0bbeb-277">悪い評判の自動ミュート</span><span class="sxs-lookup"><span data-stu-id="0bbeb-277">Bad reputation auto-mute</span></span>

<span data-ttu-id="0bbeb-278">通常、リモート ユーザーはミュートを解除した状態で開始します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-278">Typically, remote users will start off unmuted.</span></span> <span data-ttu-id="0bbeb-279">ゲーム チャットとゲーム チャット 2 にはいずれも "悪い評判の自動ミュート" 機能があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-279">Both Game Chat and Game Chat 2 have a "bad reputation auto-mute" feature.</span></span> <span data-ttu-id="0bbeb-280">これは、(1) リモート ユーザーがローカル ユーザーのフレンドではなく、(2) リモート ユーザーに悪い評判のフラグがある場合、そのユーザーはミュート状態で開始されることを意味します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-280">This means that users will start off in a muted state when (1) the remote user isn't friends with a local user, and (2) the remote user has a bad reputation flag.</span></span> <span data-ttu-id="0bbeb-281">ゲーム チャット 2 では、この機能によりユーザーがミュートされているときに、フィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-281">Game Chat 2 provides feedback when a user is muted due to this feature.</span></span> <span data-ttu-id="0bbeb-282">詳細については、「[ゲーム チャット 2 の使用 - 悪い評判の自動ミュート](using-game-chat-2.md#bad-reputation-auto-mute)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-282">Refer to [Using Game Chat 2 - Bad reputation auto-mute](using-game-chat-2.md#bad-reputation-auto-mute) for more information.</span></span>

## <a name="privilege-and-privacy"></a><span data-ttu-id="0bbeb-283">権限とプライバシー</span><span class="sxs-lookup"><span data-stu-id="0bbeb-283">Privilege and privacy</span></span>

<span data-ttu-id="0bbeb-284">ゲームによって管理されるチャンネルとコミュニケーション関係に対して、ゲーム チャットとゲーム チャット 2 はいずれも Xbox Live の権限とプライバシーの制限を適用します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-284">Both Game Chat and Game Chat 2 enforce Xbox Live privilege and privacy restrictions on top of any channel or communication relationships managed by the app.</span></span> <span data-ttu-id="0bbeb-285">さらに、ゲーム チャット 2 では、正確に制限がオーディオの方向にどのように影響しているかを判断するための診断情報を提供します (例: オーディオの制限が単方向か双方向か)。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-285">Game Chat 2 additionally provides diagnostic information to determine exactly how the restriction is impacting the direction of audio (e.g. whether audio an audio restriction is uni- or bi-directional).</span></span>

### <a name="game-chat"></a><span data-ttu-id="0bbeb-286">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="0bbeb-286">Game Chat</span></span>

<span data-ttu-id="0bbeb-287">ゲームのチャットを通じて特権とプライバシーの情報を公開する、`RestrictionMode`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-287">Game Chat exposed privilege and privacy information through the `RestrictionMode` property.</span></span> <span data-ttu-id="0bbeb-288">これは、`GameChatUser::RestrictionMode` を調べることによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-288">It can be retrieved by inspecting `GameChatUser::RestrictionMode`.</span></span>

### <a name="game-chat-2"></a><span data-ttu-id="0bbeb-289">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="0bbeb-289">Game Chat 2</span></span>

<span data-ttu-id="0bbeb-290">ゲーム チャット 2 では、ユーザーが最初に追加されると、権限とプライバシーの制限の参照を実行します。この操作が完了するまで、ユーザーの `chat_user::chat_indicator()` は常に `game_chat_user_chat_indicator::silent` を返します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-290">Game Chat 2 performs privilege and privacy restriction lookups when a user is first added; the user's `chat_user::chat_indicator()` will always return `game_chat_user_chat_indicator::silent` until those operations complete.</span></span> <span data-ttu-id="0bbeb-291">ユーザーの通信が権限またはプライバシーの制限による影響を受ける場合、ユーザーの `chat_user::chat_indicator()` は `game_chat_user_chat_indicator::platform_restricted` を返します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-291">If communication with a user is affected by a privilege or privacy restriction, the user's `chat_user::chat_indicator()` will return `game_chat_user_chat_indicator::platform_restricted`.</span></span> <span data-ttu-id="0bbeb-292">プラットフォーム通信制限は、音声チャットとテキスト チャットの両方に適用されます。テキスト チャットがプラットフォーム制限によりブロックされて音声チャットが制限されないインスタンスはなく、その逆もありません。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-292">Platform communication restrictions apply to both voice and text chat; there will never be an instance where text chat is blocked by a platform restriction but voice chat is not, or vice versa.</span></span>

<span data-ttu-id="0bbeb-293">`chat_user::chat_user_local::get_effective_communication_relationship()` 不完全な権限とプライバシーに関する操作のためにユーザーが通信できない場合に区別するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-293">`chat_user::chat_user_local::get_effective_communication_relationship()` can be used to help distinguish when users can't communicate due to incomplete privilege and privacy operations.</span></span> <span data-ttu-id="0bbeb-294">これを使用すると、ゲーム チャット 2 によって強制される通信リレーションシップが `game_chat_communication_relationship_flags` の形式で返されます。また、リレーションシップが構成されたリレーションシップと等しくない理由が `game_chat_communication_relationship_adjuster` の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-294">It returns the communication relationship enforced by Game Chat 2 in the form of `game_chat_communication_relationship_flags` and the reason the relationship may not be equal to the configured relationship in the form of `game_chat_communication_relationship_adjuster`.</span></span> <span data-ttu-id="0bbeb-295">たとえば、参照操作が進行中の場合、`game_chat_communication_relationship_adjuster` は `game_chat_communication_relationship_adjuster::intializing` になります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-295">For example, if the lookup operations are still in progress, the `game_chat_communication_relationship_adjuster` will be `game_chat_communication_relationship_adjuster::intializing`.</span></span> <span data-ttu-id="0bbeb-296">この方法は、開発シナリオとデバッグ シナリオで使用することを想定しています。UI に影響を与えるために使用しないでください (「[UI](#UI)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-296">This method is expected to be used in development and debugging scenarios; it should not be used to influence UI (see [UI](#UI)).</span></span>

## <a name="cleanup"></a><span data-ttu-id="0bbeb-297">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="0bbeb-297">Cleanup</span></span>

<span data-ttu-id="0bbeb-298">元のゲーム チャットの `ChatManager` は WinRT ランタイム クラスであり、参照がカウントされるインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-298">The original Game Chat's `ChatManager` is a WinRT runtime class - a reference counted interface.</span></span> <span data-ttu-id="0bbeb-299">そのため、最後の参照カウントが 0 になったときに、そのメモリ リソースは再利用され、クリーンアップされます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-299">As such, it's memory resources are reclaimed when the last reference count drops to zero and it cleans up.</span></span> <span data-ttu-id="0bbeb-300">ゲーム チャット 2 の C++ API との対話はシングルトン インスタンスを通じて実行されます。アプリでゲーム チャット 2 経由での通信が不要になった場合、`chat_manager::cleanup()` を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-300">Interaction with Game Chat 2's C++ API is done through a singleton instance; when the app no longer needs communications via Game Chat 2, you should call `chat_manager::cleanup()`.</span></span> <span data-ttu-id="0bbeb-301">これにより、ゲーム チャット 2 では、通信の管理に割り当てられたすべてのリソースを直ちに解放できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-301">This allows Game Chat 2 immediately release all resources that were allocated to manage communications.</span></span> <span data-ttu-id="0bbeb-302">ゲーム チャット 2 の WinRT API とリソース管理について詳しくは、「[ゲーム チャット 2 (WinRT プロジェクション) の使用](using-game-chat-2-winrt.md#cleanup)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-302">For details on Game Chat 2's WinRT API and resource management, see [Using Game Chat 2 WinRT Projections](using-game-chat-2-winrt.md#cleanup).</span></span>

## <a name="failure-model-and-debugging"></a><span data-ttu-id="0bbeb-303">エラー モデルとデバッグ</span><span class="sxs-lookup"><span data-stu-id="0bbeb-303">Failure model and debugging</span></span>

<span data-ttu-id="0bbeb-304">元のゲーム チャットは WinRT API であるため、例外を使用してエラーを報告していました。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-304">The original Game Chat is a WinRT API; thus, it reported errors through exceptions.</span></span> <span data-ttu-id="0bbeb-305">致命的ではないエラーや警告は、オプションのデバッグ コールバックで報告されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-305">Non-fatal errors or warnings are reported through an optional debug callback.</span></span> <span data-ttu-id="0bbeb-306">ゲーム チャット 2 の C++ API では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-306">Game Chat 2's C++ API doesn't throw exceptions as a means of non-fatal error reporting so you can consume it easily from exception-free projects if preferred.</span></span> <span data-ttu-id="0bbeb-307">ただし、ゲーム チャット 2 は致命的なエラーを通知するために例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-307">Game Chat 2 does, however, throw exceptions to inform about fatal errors.</span></span> <span data-ttu-id="0bbeb-308">これらのエラーは、インスタンスを初期化する前にゲーム チャット インスタンスにユーザーを追加したり、ゲーム チャット インスタンスから削除された後にユーザー オブジェクトにアクセスしたりなど、API の誤用によるものです。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-308">These errors are a result of API misuse, such as adding a user to the Game Chat instance before initializing the instance or accessing a user object after it has been removed from the Game Chat instance.</span></span> <span data-ttu-id="0bbeb-309">これらのエラーは開発の早い段階で検出することが期待され、ゲーム チャット 2 との対話に使用されるパターンを変更して修正することができます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-309">These errors are expected to be caught early in development and can be corrected by modifying the pattern used to interact with Game Chat 2.</span></span> <span data-ttu-id="0bbeb-310">このようなエラーが発生した場合、例外が発生する前に、エラーの原因に関するヒントがデバッガーに出力されます。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-310">When such an error occurs, a hint as to what caused the error is printed to the debugger before the exception is raised.</span></span> <span data-ttu-id="0bbeb-311">ゲーム チャット 2 の WinRT API は、例外を使用してエラーを報告する WinRT パターンに従います。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-311">Game Chat 2's WinRT API follows the WinRT pattern of reporting errors through exceptions.</span></span>

## <a name="how-to-configure-popular-scenarios"></a><span data-ttu-id="0bbeb-312">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="0bbeb-312">How to configure popular scenarios</span></span>

<span data-ttu-id="0bbeb-313">プッシュして話しかける、チーム、ブロードキャスト スタイルの通信シナリオなど、一般的なシナリオを構成する方法の例については、「[ゲーム チャット 2 の使用 - 一般的なシナリオの構成方法](using-game-chat-2.md#how-to-configure-popular-scenarios)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-313">Refer to [Using Game Chat 2 - How to configure popular scenarios](using-game-chat-2.md#how-to-configure-popular-scenarios) for examples on how to configure popular scenarios such as push-to-talk, teams, and broadcast-style communication scenarios.</span></span>

## <a name="pre-encode-and-post-decode-audio-manipulation"></a><span data-ttu-id="0bbeb-314">プリエンコードおよびポストデコード オーディオ操作</span><span class="sxs-lookup"><span data-stu-id="0bbeb-314">Pre-encode and post-decode audio manipulation</span></span>

<span data-ttu-id="0bbeb-315">元のゲーム チャットでは、`OnPreEncodeAudioBuffer` イベントと `OnPostDecodeAudioBuffers` イベントを通じて、未処理のマイク オーディオへのアクセスを許可することにより、オーディオ操作を許可していました。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-315">The original Game Chat allowed for audio manipulation by allowing access to raw microphone audio through the `OnPreEncodeAudioBuffer` and `OnPostDecodeAudioBuffers` events.</span></span> <span data-ttu-id="0bbeb-316">ゲーム チャット 2 では、ポーリング モデルを使用してこの機能を公開します。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-316">Game Chat 2 exposes this feature through a polling model.</span></span> <span data-ttu-id="0bbeb-317">詳しくは、「[リアルタイム オーディオ操作](real-time-audio-manipulation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bbeb-317">For more information, refer to [Real-time audio manipulation](real-time-audio-manipulation.md).</span></span>
