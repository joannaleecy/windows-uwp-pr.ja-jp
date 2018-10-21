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
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5160186"
---
# <a name="migration-from-game-chat-to-game-chat-2"></a><span data-ttu-id="8606f-104">ゲーム チャットからゲーム チャット 2 への移行</span><span class="sxs-lookup"><span data-stu-id="8606f-104">Migration from Game Chat to Game Chat 2</span></span>

<span data-ttu-id="8606f-105">このドキュメントでは、ゲーム チャットとゲーム チャット 2 の類似点と、ゲーム チャットからゲーム チャット 2 に移行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8606f-105">This document details the similarities between Game Chat and Game Chat 2 and how to migrate from Game Chat to Game Chat 2.</span></span> <span data-ttu-id="8606f-106">そのため、ゲーム チャット 2 への移行を検討している、既存のゲーム チャットの実装を含むタイトルを対象としています。</span><span class="sxs-lookup"><span data-stu-id="8606f-106">As such, it is for titles that have an existing Game Chat implementation that wish to migrate to Game Chat 2.</span></span> <span data-ttu-id="8606f-107">既存のゲーム チャットの実装がない場合は、「[ゲーム チャット 2 の使用](using-game-chat-2.md)」から開始することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8606f-107">If you don't already have a Game Chat implementation, the suggested starting point is [Using Game Chat 2](using-game-chat-2.md).</span></span> <span data-ttu-id="8606f-108">ここでは、以下のトピックについて説明します。</span><span class="sxs-lookup"><span data-stu-id="8606f-108">This document contains the following topics:</span></span>

1. [<span data-ttu-id="8606f-109">はじめに</span><span class="sxs-lookup"><span data-stu-id="8606f-109">Preface</span></span>](#preface)
2. [<span data-ttu-id="8606f-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="8606f-110">Prerequisites</span></span>](#prerequisites)
3. [<span data-ttu-id="8606f-111">初期化</span><span class="sxs-lookup"><span data-stu-id="8606f-111">Initialization</span></span>](#initialization)
4. [<span data-ttu-id="8606f-112">ユーザーの構成</span><span class="sxs-lookup"><span data-stu-id="8606f-112">Configuring Users</span></span>](#configuring-users)
5. [<span data-ttu-id="8606f-113">データの処理</span><span class="sxs-lookup"><span data-stu-id="8606f-113">Processing data</span></span>](#processing-data)
6. [<span data-ttu-id="8606f-114">イベントの処理</span><span class="sxs-lookup"><span data-stu-id="8606f-114">Processing events</span></span>](#processing-events)
7. [<span data-ttu-id="8606f-115">テキスト チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-115">Text chat</span></span>](#text-chat)
8. [<span data-ttu-id="8606f-116">ユーザー補助</span><span class="sxs-lookup"><span data-stu-id="8606f-116">Accessibility</span></span>](#accessibility)
9. [<span data-ttu-id="8606f-117">UI</span><span class="sxs-lookup"><span data-stu-id="8606f-117">UI</span></span>](#UI)
10. [<span data-ttu-id="8606f-118">ミュート</span><span class="sxs-lookup"><span data-stu-id="8606f-118">Muting</span></span>](#muting)
11. [<span data-ttu-id="8606f-119">悪い評判の自動ミュート</span><span class="sxs-lookup"><span data-stu-id="8606f-119">Bad reputation auto-mute</span></span>](#bad-reputation-auto-mute)
12. [<span data-ttu-id="8606f-120">権限とプライバシー</span><span class="sxs-lookup"><span data-stu-id="8606f-120">Privilege and privacy</span></span>](#privilege-and-privacy)
13. [<span data-ttu-id="8606f-121">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="8606f-121">Cleanup</span></span>](#cleanup)
14. [<span data-ttu-id="8606f-122">エラー モデルとデバッグ</span><span class="sxs-lookup"><span data-stu-id="8606f-122">Failure model and debugging</span></span>](#failure-model-and-debugging)
15. [<span data-ttu-id="8606f-123">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="8606f-123">How to configure popular scenarios</span></span>](#how-to-configure-popular-scenarios)
16. [<span data-ttu-id="8606f-124">プリエンコードおよびポストデコード オーディオ操作</span><span class="sxs-lookup"><span data-stu-id="8606f-124">Pre-encode and post-decode audio manipulation</span></span>](#pre-encode-and-post-decode-audio-manipulation)

## <a name="preface"></a><span data-ttu-id="8606f-125">はじめに</span><span class="sxs-lookup"><span data-stu-id="8606f-125">Preface</span></span>

<span data-ttu-id="8606f-126">元のゲーム チャット API は、チャット ユーザーと音声チャンネルの概念を公開し、Xbox Live のゲーム内ボイス チャット シナリオの実装を支援する WinRT API でした。</span><span class="sxs-lookup"><span data-stu-id="8606f-126">The original Game Chat API is a WinRT API that exposed a concept of chat users and voice channels to assist in the implementation of Xbox Live in-game voice chat scenarios.</span></span> <span data-ttu-id="8606f-127">ゲーム チャット API はチャット API を基に構築されています。チャット API 自体もユーザー チャットと音声チャンネルの概念を公開する WinRT API でしたが、必要なオーディオ デバイスの管理は低レベルでした。</span><span class="sxs-lookup"><span data-stu-id="8606f-127">The Game Chat API is built on top of the Chat API, which itself is a WinRT API that exposed a concept of chat users and voice channels while requiring low-level management of audio devices.</span></span> <span data-ttu-id="8606f-128">ゲーム チャット 2 は、元のゲーム チャット API とチャット API の後継です。チーム内のコミュニケーションなどの基本的なチャット シナリオについては、よりシンプルな API となり、同時にブロードキャスト スタイルのコミュニケーションやリアルタイムのオーディオ操作などの高度なチャット シナリオでは、より高い柔軟性を提供するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="8606f-128">Game Chat 2 is the successor to the original Game Chat and Chat APIs - it was designed to be a simpler API for basic chat scenarios, such as team communication, while simultaneously providing more flexibility for advanced chat scenarios, such as broadcast-style communication and real-time audio manipulation.</span></span> <span data-ttu-id="8606f-129">ゲーム チャットとゲーム チャット 2 はいずれも同じニッチな用途に対応しています。各 API は Xbox Live 対応のゲーム内ボイス チャットを統合するための便利なメソッドを提供する一方で、タイトルは、ゲーム チャットやゲーム チャット 2 のリモート インスタンスとの間でデータ パケットを送受信するためのトランスポート層を提供します。</span><span class="sxs-lookup"><span data-stu-id="8606f-129">Both Game Chat and Game Chat 2 fill the same niche: the APIs each provide a convenient method for integrating Xbox Live enabled, in-game voice chat, while the title provides a transport layer for transmitting data packets to and from remote instances of Game Chat or Game Chat 2.</span></span>

<span data-ttu-id="8606f-130">ゲーム チャット 2 API は、元のゲーム チャット API やチャット API に比べて多くの利点があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-130">The Game Chat 2 API has many advantages over the original Game Chat and Chat APIs.</span></span> <span data-ttu-id="8606f-131">その要点のいくつかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-131">Some highlights include:</span></span>
* <span data-ttu-id="8606f-132">"チャンネル" モデルに制限されない柔軟性の高いユーザー指向の API。</span><span class="sxs-lookup"><span data-stu-id="8606f-132">A flexible user-oriented API that is not restricted to the "channel" model.</span></span>
* <span data-ttu-id="8606f-133">データ ソースとデータ受信側の両方でのパケット フィルタ リングにより帯域幅が向上。</span><span class="sxs-lookup"><span data-stu-id="8606f-133">Bandwidth improvements due to packet filtering by both data sources and data receivers.</span></span>
* <span data-ttu-id="8606f-134">アプリで構成可能なアフィニティを使用して有効期間が長い 2 つのスレッドを内部制限。</span><span class="sxs-lookup"><span data-stu-id="8606f-134">An internal restriction to 2 long-lived threads with app-configurable affinity.</span></span>
* <span data-ttu-id="8606f-135">C++ と WinRT の両方の形式で利用可能な API。</span><span class="sxs-lookup"><span data-stu-id="8606f-135">An API available in both C++ and WinRT forms.</span></span>
* <span data-ttu-id="8606f-136">"do work" パターンに沿った簡略化された消費モデル。</span><span class="sxs-lookup"><span data-stu-id="8606f-136">Simplified consumption model aligning with a "do work" pattern.</span></span>
* <span data-ttu-id="8606f-137">カスタム アロケーターを通じてゲーム チャット 2 の割り当てをリダイレクトするメモリ フック。</span><span class="sxs-lookup"><span data-stu-id="8606f-137">Memory hooks to redirect Game Chat 2 allocations through a custom allocator.</span></span>
* <span data-ttu-id="8606f-138">より便利なクロスプラットフォーム開発エクスペリエンスを実現する、同一 UWP + 排他リソース アプリケーション (ERA) ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="8606f-138">Identical UWP + Exclusive Resource Application (ERA) headers for a more convenient cross-plat development experience.</span></span>

<span data-ttu-id="8606f-139">このドキュメントでは、ゲーム チャットとゲーム チャット 2 の類似点と、ゲーム チャットからゲーム チャット 2 C++ API に移行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8606f-139">This document details the similarities between Game Chat and Game Chat 2 and how to migrate from Game Chat to the Game Chat 2 C++ API.</span></span> <span data-ttu-id="8606f-140">ゲーム チャットからゲーム チャット 2 WinRT API への移行に関心がある場合は、このドキュメントでゲーム チャットの概念をゲーム チャット 2 にマップする方法を理解してから、WinRT に固有のパターンについて、「[ゲーム チャット 2 (WinRT プロジェクション) の使用](using-game-chat-2-winrt.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8606f-140">If you are interested in migration from Game Chat to the Game Chat 2 WinRT API, it is suggested that you read this document to understand how to map Game Chat concepts to Game Chat 2, and then see [Using Game Chat 2 WinRT Projections](using-game-chat-2-winrt.md) for the patterns specific to WinRT.</span></span> <span data-ttu-id="8606f-141">このドキュメントで示す元のゲーム チャットのサンプル コードでは、C++/CX を使用します。</span><span class="sxs-lookup"><span data-stu-id="8606f-141">The sample code for the original Game Chat in this document will use C++/CX.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="8606f-142">前提条件</span><span class="sxs-lookup"><span data-stu-id="8606f-142">Prerequisites</span></span>

<span data-ttu-id="8606f-143">ゲーム チャット 2 のコーディングを始める前に、"マイク" デバイス機能を宣言するアプリの AppXManifest を構成している必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-143">Before you get started coding with Game Chat 2, you must have configured your app's AppXManifest to declare the "microphone" device capability.</span></span> <span data-ttu-id="8606f-144">AppXManifest 機能については、プラットフォームのドキュメントの各セクションで詳しく説明されています。次のスニペットは、パッケージ/機能ノードの下に存在している必要があり、存在しないとチャットがブロックされる "マイク" デバイス機能ノードを示しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-144">AppXManifest capabilities are described in more detail in their respective sections of the platform documentation; the following snippet shows the "microphone" device capability node that should exist under the Package/Capabilities node or else chat will be blocked:</span></span>

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

<span data-ttu-id="8606f-145">ゲーム チャット 2 をコンパイルするには、プライマリ ヘッダー GameChat2.h を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-145">Compiling Game Chat 2 requires including the primary GameChat2.h header.</span></span> <span data-ttu-id="8606f-146">適切にリンクするには、プロジェクト内の 1 つ以上のコンパイル ユニットにも GameChat2Impl.h を含める必要があります (スタブ関数実装は小さく、コンパイラーで "インライン" として生成しやすいため、一般的なプリコンパイル済みヘッダーをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="8606f-146">In order to link properly, your project must also include GameChat2Impl.h in at least one compilation unit (a common precompiled header is recommended since these stub function implementations are small and easy for the compiler to generate as "inline").</span></span>

<span data-ttu-id="8606f-147">ゲーム チャット 2 インターフェイスでは、プロジェクトのコンパイルにおいて、C++/CX と従来の C++ のいずれかを選択する必要がなく、どちらも使用できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-147">The Game Chat 2 interface does not require a project to choose between compiling with C++/CX versus traditional C++; it can be used with either.</span></span> <span data-ttu-id="8606f-148">また、この実装では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-148">The implementation also doesn't throw exceptions as a means of non-fatal error reporting so you can consume it easily from exception-free projects if preferred.</span></span> <span data-ttu-id="8606f-149">ただし、この実装は、致命的なエラーの報告を手段として例外をスローします (詳しくは「[エラー モデル](#failure)」を参照)。</span><span class="sxs-lookup"><span data-stu-id="8606f-149">The implementation does, however, throw exceptions as a means of fatal error reporting (see [Failure model](#failure) for more detail).</span></span>

## <a name="initialization"></a><span data-ttu-id="8606f-150">初期化</span><span class="sxs-lookup"><span data-stu-id="8606f-150">Initialization</span></span>

### <a name="game-chat"></a><span data-ttu-id="8606f-151">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-151">Game Chat</span></span>

<span data-ttu-id="8606f-152">元のゲーム チャットとの対話は、`ChatManager` クラスを通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-152">Interacting with the original Game Chat is done through the `ChatManager` class.</span></span> <span data-ttu-id="8606f-153">次の例では、既定のパラメーターを使用して `ChatManager` インスタンスを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-153">The following example shows how to construct a `ChatManager` instance using default parameters:</span></span>

```cpp
auto chatManager = ref new ChatManager();
```

### <a name="game-chat-2"></a><span data-ttu-id="8606f-154">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-154">Game Chat 2</span></span>

<span data-ttu-id="8606f-155">ゲーム チャット 2 とのすべての対話は、ゲーム チャット 2 の `chat_manager` シングルトンを通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-155">All interaction with Game Chat 2 is done through Game Chat 2's `chat_manager` singleton.</span></span> <span data-ttu-id="8606f-156">ライブラリに対して意味のある操作を行う前に、このシングルトンを初期化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-156">The singleton must be initialized before any meaningful interaction with the library can occur.</span></span> <span data-ttu-id="8606f-157">シングルトンの初期化時に、ローカルとリモートの最大同時チャット ユーザー数を指定する必要があります。これは、ゲーム チャット 2 が、予想されたユーザー数に比例してメモリを事前に割り当てるためです。</span><span class="sxs-lookup"><span data-stu-id="8606f-157">The singleton requires that the maximum number of concurrent local and remote chat users be specified at initialization time; this is because Game Chat 2 pre-allocates memory proportional to the expected number of users.</span></span> <span data-ttu-id="8606f-158">次の例では、ローカルとリモートの最大同時チャット ユーザー数が 4 人である場合に、シングルトン インスタンスを初期化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-158">The following example shows how to intialize the singleton instance when the maximum number of concurrent local and remote chat users will be four:</span></span>

```cpp
chat_manager::singleton_instance().initialize(4);
```

<span data-ttu-id="8606f-159">同様に、初期化中に指定できるいくつかのオプション パラメーターがあります。リモート チャット ユーザーの既定のレンダリング ボリュームや、ゲーム チャット 2 で自動的に音声テキスト変換を実行するかどうかなどです。</span><span class="sxs-lookup"><span data-stu-id="8606f-159">There are several optional parameters that can be specified during initialization as well, such as the default render volume of remote chat users and whether Game Chat 2 should perform automatic speech-to-text conversion.</span></span> <span data-ttu-id="8606f-160">これらのパラメーターの詳細については、`chat_manager::initialize()` のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="8606f-160">For more detail on these parameters, refer to the documentation of `chat_manager::initialize()`.</span></span>

## <a name="configuring-users"></a><span data-ttu-id="8606f-161">ユーザーの構成</span><span class="sxs-lookup"><span data-stu-id="8606f-161">Configuring users</span></span>

### <a name="game-chat"></a><span data-ttu-id="8606f-162">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-162">Game Chat</span></span>

<span data-ttu-id="8606f-163">元のゲーム チャット API へのローカル ユーザーの追加は、`ChatManager::AddLocalUserToChatChannelAsync()` を通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-163">Adding local users to the original Game Chat API is done through `ChatManager::AddLocalUserToChatChannelAsync()`.</span></span> <span data-ttu-id="8606f-164">複数のチャット チャンネルにユーザーを追加するには、それぞれ別のチャンネルを指定する、複数の呼び出しが必要です。</span><span class="sxs-lookup"><span data-stu-id="8606f-164">Adding the user to multiple chat channels requires multiple calls, each specifying a different channel.</span></span> <span data-ttu-id="8606f-165">次の例では、チャンネル 0 に xuid が "myXuid" であるユーザーを追加する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-165">The following example shows how to add the user with xuid "myXuid" to channel 0:</span></span>

```cpp
auto asyncOperation = chatManager->AddLocalUserToChatChannelAsync(0, L"myXuid");
```

<span data-ttu-id="8606f-166">リモート ユーザーは、直接、インスタンスには追加されません。</span><span class="sxs-lookup"><span data-stu-id="8606f-166">Remote users are not added to the instance directly.</span></span> <span data-ttu-id="8606f-167">タイトルのネットワークにリモート デバイスが表示されると、タイトルはリモート デバイスを表すオブジェクトを作成し、`ChatManager::HandleNewRemoteConsole()` を通じてゲーム チャットに新しいデバイスを通知します。</span><span class="sxs-lookup"><span data-stu-id="8606f-167">When a remote device appears in the title's network, the title creates an object that represents the remote device and informs Game Chat of the new device via `ChatManager::HandleNewRemoteConsole()`.</span></span> <span data-ttu-id="8606f-168">タイトルは、`CompareUniqueConsoleIdentifiersHandler` を実装することによって、リモート デバイスを表すオブジェクトをゲーム チャットと比較するメソッドを提供する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="8606f-168">The title must also provide a method of comparing the objects representing the remote devices to Game Chat by implementing `CompareUniqueConsoleIdentifiersHandler`.</span></span> <span data-ttu-id="8606f-169">次の例では、このデリゲートをゲーム チャットに提供する方法を示します。`Platform::String` オブジェクトを使用してリモート デバイスを表しており、`L"1"` で表される新しいデバイスがタイトルのネットワークに参加したと仮定しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-169">The following example shows how to provide this delegate to Game Chat, assuming `Platform::String` objects are used to represent remote devices and a new device represented by string `L"1"` has joined the title's network:</span></span>

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

<span data-ttu-id="8606f-170">ゲーム チャットは、このデバイスについて通知されると、すべてのローカル ユーザーに関する情報を含むパケットを生成し、リモート デバイスのゲーム チャット インスタンスに送信するために、これらのパケットをタイトルに提供します。</span><span class="sxs-lookup"><span data-stu-id="8606f-170">Once Game Chat has been informed of this device, it will generate packets containing information about any local users and provide these packets to the title for transmission to the Game Chat instance on the remote device.</span></span> <span data-ttu-id="8606f-171">同様に、リモート デバイス上のゲーム チャットは、タイトルがゲーム チャットのローカル インスタンスを送信する先のリモート デバイス上のユーザー関する情報を含むパケットを精製します。</span><span class="sxs-lookup"><span data-stu-id="8606f-171">Similarly, the Game Chat instance on the remote device will generate packets containing information about users on that remote device that the title will transmit to the local instance of Game Chat.</span></span> <span data-ttu-id="8606f-172">ローカル インスタンスが新しいリモート ユーザーに関する情報を含むパケットを受信すると、新しいリモート ユーザーは、`ChatManager::GetUsers()` 経由で利用可能なローカル インスタンスのユーザーのリストに追加されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-172">When the local instance receives packets containing information about new remote users, the new remote users are added to the local instance's list of users, available through `ChatManager::GetUsers()`.</span></span>

<span data-ttu-id="8606f-173">ゲーム チャットのインスタンスからユーザーの削除は、`ChatManager::RemoveLocalUserFromChatChannelAsync()` と次の呼び出しを通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-173">Removing users from the Game Chat instance is performed through similar calls to `ChatManager::RemoveLocalUserFromChatChannelAsync()` and</span></span> `ChatManager::RemoveRemoteConsoleAsync()`

### <a name="game-chat-2"></a><span data-ttu-id="8606f-174">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-174">Game Chat 2</span></span>

<span data-ttu-id="8606f-175">ゲーム チャット 2 へのローカル ユーザーの追加は、`chat_manager::add_local_user()` を通じて同期的に実行されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-175">Adding local users to Game Chat 2 is done synchronously through `chat_manager::add_local_user()`.</span></span> <span data-ttu-id="8606f-176">この例では、ユーザー A は、Xbox ユーザー ID が `L"myLocalXboxUserId"` であるローカル ユーザーを表します。</span><span class="sxs-lookup"><span data-stu-id="8606f-176">In this example, User A will represent a local user with Xbox User Id `L"myLocalXboxUserId"`:</span></span>

```cpp
chat_user* chatUserA = chat_manager::singleton_instance().add_local_user(L"myLocalXboxUserId");
```

<span data-ttu-id="8606f-177">ユーザーは特定のチャンネルには追加されないことに注意してください。ゲーム チャット 2 では、チャンネルではなく「コミュニケーション関係」の概念を使用して、ユーザーが互いに話したり、聞いたりできるかどうかを管理します。</span><span class="sxs-lookup"><span data-stu-id="8606f-177">Notice that the user is not added to a particular channel - Game Chat 2 uses a concept of "communication relationships" rather than channels to manage whether users can speak to and hear each other.</span></span> <span data-ttu-id="8606f-178">コミュニケーション関係を構成する方法は、このセクションで後で説明します。</span><span class="sxs-lookup"><span data-stu-id="8606f-178">The method of configuring communication relationships is addressed later in this section.</span></span>

<span data-ttu-id="8606f-179">ローカル ユーザーと同様に、リモート ユーザーは同期的にローカルのゲーム チャット 2 インスタンスに追加されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-179">Similar to local users, remote users are added synchronously to the local Game Chat 2 instance.</span></span> <span data-ttu-id="8606f-180">これと同時に、リモート ユーザーは、リモート デバイスを表すために使用される識別子に関連付けられる必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-180">The remote users must simultaneously be associated with identifiers that will be used to represent the remote device.</span></span> <span data-ttu-id="8606f-181">ゲーム チャット 2 では、リモート デバイスで実行されているアプリのインスタンスを "エンドポイント" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="8606f-181">Game Chat 2 refers to an instance of the app running on a remote device as an "Endpoint".</span></span> <span data-ttu-id="8606f-182">この例では、ユーザー B は、整数 `1` で表されるエンドポイントで Xbox ユーザー ID `L"remoteXboxUserId"` を持つユーザーです。</span><span class="sxs-lookup"><span data-stu-id="8606f-182">In this example, User B will be a user with Xbox User Id `L"remoteXboxUserId"` on an endpoint represented by the integer `1`.</span></span>

```cpp
chat_user* chatUserB = chat_manager::singleton_instance().add_remote_user(L"remoteXboxUserId", 1);
```

<span data-ttu-id="8606f-183">ユーザーがインスタンスに追加されたら、各リモート ユーザーと各ローカル ユーザーの間に「コミュニケーション関係」を構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-183">Once the users have been added to the instance, you should configure the "communication relationship" between each remote user and each local user.</span></span> <span data-ttu-id="8606f-184">この例では、ユーザー A とユーザー B が同じチームに属しており、双方向通信が許可されていると仮定します。</span><span class="sxs-lookup"><span data-stu-id="8606f-184">In this example, suppose that User A and User B are on the same team and bidirectional communication is allowed.</span></span> `c_communicationRelationshiSendAndReceiveAll` <span data-ttu-id="8606f-185">は、GameChat2.h で定義されている、双方向通信を表す定数です。</span><span class="sxs-lookup"><span data-stu-id="8606f-185">is a constant defined in GameChat2.h to represent bi-directional communication.</span></span> <span data-ttu-id="8606f-186">この関係は、次のようにして構成できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-186">The relationship can be configured with:</span></span>

```cpp
chatUserA->local()->set_communication_relationship(chatUserB, c_communicationRelationshipSendAndReceiveAll);
```

<span data-ttu-id="8606f-187">最後の点として、ユーザー B がゲームを終了したため、ローカル ゲーム チャット インスタンスから削除する必要があるとします。</span><span class="sxs-lookup"><span data-stu-id="8606f-187">Finally, suppose that User B has left the game and should be removed from the local Game Chat instance.</span></span> <span data-ttu-id="8606f-188">これは、次の呼び出しで同期的に実行されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-188">That is performed synchronously with the following call:</span></span>

```cpp
chat_manager::singleton_instance().remove_user(chatUserD);
```

<span data-ttu-id="8606f-189">さらに詳しい例や個々の API メソッドのリファレンスについては、「[ゲーム チャット 2 の使用 - ユーザーの構成](using-game-chat-2.md#configuring-users)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8606f-189">Refer to [Using Game Chat 2 - Configuring Users](using-game-chat-2.md#configuring-users) for more detailed examples or the reference for individual API methods for more information.</span></span>

## <a name="processing-data"></a><span data-ttu-id="8606f-190">データの処理</span><span class="sxs-lookup"><span data-stu-id="8606f-190">Processing data</span></span>

### <a name="game-chat"></a><span data-ttu-id="8606f-191">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-191">Game Chat</span></span>

<span data-ttu-id="8606f-192">ゲーム チャットには独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-192">Game Chat does not have its own transport layer; this must be provided by the app.</span></span> <span data-ttu-id="8606f-193">送信パケットは、`OnOutgoingChatPacketReady` イベントをサブスクライブし、パケットの送信先とトランスポートの要件を決定する引数を検査することによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-193">Outgoing packets are handled by subscribing to the `OnOutgoingChatPacketReady` event and inspecting the arguments to determine the packet destination and transport requirements.</span></span> <span data-ttu-id="8606f-194">次の例は、イベントをサブスクライブし、タイトルで実装されている `HandleOutgoingPacket()` メソッドに引数を転送する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-194">The following example shows how to subscribe to the event and forward the arguments the `HandleOutgoingPacket()` method implemented by the title:</span></span>

```cpp
auto token = chatManager->OnOutgoingChatPacketReady +=
    ref new Windows::Foundation::EventHandler<Microsoft::Xbox::GameChat::ChatPacketEventArgs^>(
        [this](Platform::Object^, Microsoft::Xbox::GameChat::ChatPacketEventArgs^ args)
    {
        this->HandleOutgoingPacket(args);
    });
```

<span data-ttu-id="8606f-195">受信パケットは、`ChatManager::ProcessingIncomingChatMessage()` を通じてゲーム チャットに送信されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-195">Incoming packets are submitted to Game Chat via `ChatManager::ProcessingIncomingChatMessage()`.</span></span> <span data-ttu-id="8606f-196">未処理のパケット バッファーとリモート デバイス識別子を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-196">The raw packet buffer and the remote device identifier must be provided.</span></span> <span data-ttu-id="8606f-197">次の例は、ローカルの `packetBuffer` に保存されているパケットと、ローカル変数 `remoteIdentifier` に保存されているリモート デバイス識別子を送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-197">The following example shows how to submit a packet that is stored in the local `packetBuffer` and remote device identifier stored in the local variable `remoteIdentifier`.</span></span>

```cpp
Platform::String^ remoteIdentifier = /* The identifier associated with the device that generated this packet */
Windows::Storage::Streams::IBuffer^ packetBuffer = /* The incoming chat packet */

chatManager->ProcessIncomingChatMessage(packetBuffer, remoteIdentifier);
```

### <a name="game-chat-2"></a><span data-ttu-id="8606f-198">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-198">Game Chat 2</span></span>

<span data-ttu-id="8606f-199">同様に、ゲーム チャット 2 には独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-199">Similarly, Game Chat 2 does not have its own transport layer; this must be provided by the app.</span></span> <span data-ttu-id="8606f-200">送信パケットは、アプリによる `chat_manager::start_processing_data_frames()` メソッドと `chat_manager::finish_processing_data_frames()` メソッドの定期的かつ頻繁な呼び出しによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-200">Outgoing packets are handled by the app's regular, frequent calls to the `chat_manager::start_processing_data_frames()` and `chat_manager::finish_processing_data_frames()` pair of methods.</span></span> <span data-ttu-id="8606f-201">これらのメソッドを使用して、ゲーム チャット 2 は発信データをアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="8606f-201">These methods are how Game Chat 2 provides outgoing data to the app.</span></span> <span data-ttu-id="8606f-202">これらは専用のネットワーク スレッドで頻繁にポーリングできるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="8606f-202">They're designed to operate quickly such that they can be polled frequently on a dedicated networking thread.</span></span> <span data-ttu-id="8606f-203">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべてのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-203">This provides a convenient place to retrieve all queued data without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="8606f-204">`chat_manager::start_processing_data_frames()` を呼び出すと、キューに入っているすべてのデータが `game_chat_data_frame` 構造体ポインターの配列で報告されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-204">When `chat_manager::start_processing_data_frames()` is called, all queued data is reported in an array of `game_chat_data_frame` structure pointers.</span></span> <span data-ttu-id="8606f-205">アプリでは、配列を反復処理し、ターゲット "エンドポイント" を検査し、アプリのネットワーク層を使用してデータを適切なリモート アプリ インスタンスに配信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-205">Apps should iterate over the array, inspect the target "endpoints", and use the app's networking layer to deliver the data to the appropriate remote app instances.</span></span> <span data-ttu-id="8606f-206">すべての `game_chat_data_frame` 構造体が終了した後は、`chat_manager:finish_processing_data_frames()` を呼び出すことによってその配列をゲーム チャット 2 に戻してリソースを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-206">Once finished with all the `game_chat_data_frame` structures, the array should be passed back to Game Chat 2 to release the resources by calling `chat_manager:finish_processing_data_frames()`.</span></span> <span data-ttu-id="8606f-207">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-207">For example:</span></span>

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

<span data-ttu-id="8606f-208">データ フレームの処理頻度が高いほど、エンド ユーザーの感じるオーディオの遅延は低くなります。</span><span class="sxs-lookup"><span data-stu-id="8606f-208">The more frequently the data frames are processed, the lower the audio latency apparent to the end user will be.</span></span> <span data-ttu-id="8606f-209">オーディオは 40 ミリ秒のデータ フレームに結合されます。これは、推奨されるポーリング期間です。</span><span class="sxs-lookup"><span data-stu-id="8606f-209">The audio is coalesced into 40 ms data frames; this is the suggested polling period.</span></span>

<span data-ttu-id="8606f-210">受信データは、`chat_manager::processing_incoming_data()` を通じてゲーム チャット 2 に送信されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-210">Incoming data is submitted to Game Chat 2 via `chat_manager::processing_incoming_data()`.</span></span> <span data-ttu-id="8606f-211">データ バッファーとリモート エンドポイント識別子を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-211">The data buffer and the remote endpoint identifier must be provided.</span></span> <span data-ttu-id="8606f-212">次の例は、ローカル変数 `dataFrame` に保存されているデータ パケットと、ローカル変数 `remoteEndpointIdentifier` に保存されているリモート エンドポイント識別子を送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-212">The following example shows how to submit a data packet that is stored in the local variable `dataFrame` and the remote endpoint identifier stored in the local variable `remoteEndpointIdentifier`:</span></span>

```cpp
uin64_t remoteEndpointIdentier = /* The identifier associated with the endpoint that generated this packet */
uint32_t dataFrameSize = /* The size of the incoming data frame, in bytes */
uint8_t* dataFrame = /* A pointer to the buffer containing the incoming data */

chatManager::singleton_instance().process_incoming_data(remoteEndpointIdentifier, dataFrameSize, dataFrame);
```

## <a name="processing-events"></a><span data-ttu-id="8606f-213">イベントの処理</span><span class="sxs-lookup"><span data-stu-id="8606f-213">Processing events</span></span>

### <a name="game-chat"></a><span data-ttu-id="8606f-214">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-214">Game Chat</span></span>

<span data-ttu-id="8606f-215">ゲーム チャットでは、イベント生成モデルを使用して、関心のあるできごとが発生したことをアプリに通知します。たとえば、テキスト メッセージの受信や、ユーザーのアクセシビリティの基本設定の変更です。</span><span class="sxs-lookup"><span data-stu-id="8606f-215">Game Chat uses an eventing model to inform the app when something of interest occurs - such as the receipt of a text message or the changing of a user's accessibility preference.</span></span> <span data-ttu-id="8606f-216">アプリは、関心のある各イベントをサブスクライブし、イベントのハンドラーを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-216">The app must subscribe to and implement a handler for each event of interest.</span></span> <span data-ttu-id="8606f-217">次の例は、`OnTextMessageReceived` イベントをサブスクライブし、アプリで実装されている `OnTextChatReceived()` または `OnTranscribedChatReceived()` メソッドに引数を転送する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-217">This example shows how to subscribe to the `OnTextMessageReceived` event and forward the arguments to the `OnTextChatReceived()` or `OnTranscribedChatReceived()` methods implemented by the app:</span></span>

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

### <a name="game-chat-2"></a><span data-ttu-id="8606f-218">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-218">Game Chat 2</span></span>

<span data-ttu-id="8606f-219">ゲーム チャット 2 では、アプリによる `chat_manager::start_processing_state_changes()` メソッドと `chat_manager::finish_processing_state_changes()` メソッドの定期的かつ頻繁な呼び出しを通じて、受信したテキスト メッセージなどの更新をアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="8606f-219">Game Chat 2 provides updates to the app, such as received text messages, through the app's regular, frequent calls to the `chat_manager::start_processing_state_changes()` and `chat_manager::finish_processing_state_changes()` pair of methods.</span></span> <span data-ttu-id="8606f-220">これらのメソッドは、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="8606f-220">They're designed to operate quickly such that they can be called every graphics frame in your UI rendering loop.</span></span> <span data-ttu-id="8606f-221">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-221">This provides a convenient place to retrieve all queued changes without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="8606f-222">`chat_manager::start_processing_state_changes()` を呼び出すと、キューに入っているすべての更新が `game_chat_state_change` 構造体ポインターの配列で報告されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-222">When `chat_manager::start_processing_state_changes()` is called, all queued updates are reported in an array of `game_chat_state_change` structure pointers.</span></span> <span data-ttu-id="8606f-223">アプリでは、配列を反復処理し、より具体的な型の基本構造を検査して、基本的な構造体を対応する詳細な型にキャストしてから、その更新を適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-223">Apps should iterate over the array, inspect the base structure for its more specific type, cast the base structure to the corresponding more detailed type, and then handle that update as appropriate.</span></span> <span data-ttu-id="8606f-224">現在使用可能なすべての `game_chat_state_change` オブジェクトが終了した後は、`chat_manager::finish_processing_state_changes()` を呼び出すことによってその配列をゲーム チャット 2 に戻してリソースを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-224">Once finished with all `game_chat_state_change` objects currently available, that array should be passed back to Game Chat 2 to release the resources by calling `chat_manager::finish_processing_state_changes()`.</span></span> <span data-ttu-id="8606f-225">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-225">For example:</span></span>

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

<span data-ttu-id="8606f-226">`chat_manager::remove_user()` は、ユーザー オブジェクトに関連付けられたメモリをすぐに無効にし、状態変更にユーザー オブジェクトへのポインターが含まれていることがあるため、状態変更の処理中に `chat_manager::remove_user()` を呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="8606f-226">Because `chat_manager::remove_user()` immediately invalidates the memory associated with a user object, and state changes may contain pointers to user objects, `chat_manager::remove_user()` must not be called while processing state changes.</span></span>

## <a name="text-chat"></a><span data-ttu-id="8606f-227">テキスト チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-227">Text chat</span></span>

### <a name="game-chat"></a><span data-ttu-id="8606f-228">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-228">Game Chat</span></span>

<span data-ttu-id="8606f-229">ゲーム チャットでテキスト チャットを送信するには、`GameChatUser::GenerateTextMessage()` を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-229">To send text chat with Game Chat, `GameChatUser::GenerateTextMessage()` can be used.</span></span> <span data-ttu-id="8606f-230">次の例は、`chatUser` 変数によって表されるローカル チャット ユーザーにチャット テキスト メッセージを送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-230">The following example shows how to send a chat text message with a local chat user represented by the `chatUser` variable:</span></span>

```cpp
chatUser->GenerateTextMessage(L"Hello", false);
```

<span data-ttu-id="8606f-231">2 番目のブール値パラメーターは、音声合成変換を制御します。</span><span class="sxs-lookup"><span data-stu-id="8606f-231">The second boolean parameter controls text-to-speech conversion.</span></span> <span data-ttu-id="8606f-232">詳細については、「[ユーザー補助](#accessibility)」を参照してください。次に、ゲーム チャットは、このメッセージを含むチャット パケットを生成します。</span><span class="sxs-lookup"><span data-stu-id="8606f-232">For more details, see [Accessibility](#accessibilityGame Chat then generates a chat packet containing this message.</span></span> <span data-ttu-id="8606f-233">ゲーム チャットのリモート インスタンスには、`OnTextMessageReceived` イベント経由でテキスト メッセージが通知されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-233">Remote instances of Game Chat will be notified of the text message via the `OnTextMessageReceived` event.</span></span>

### <a name="game-chat-2"></a><span data-ttu-id="8606f-234">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-234">Game Chat 2</span></span>

<span data-ttu-id="8606f-235">ゲーム チャット 2 でテキスト チャットを送信するには、`chat_user::chat_user_local::send_chat_text()` を使用します。</span><span class="sxs-lookup"><span data-stu-id="8606f-235">To send text chat with Game Chat 2, use `chat_user::chat_user_local::send_chat_text()`.</span></span> <span data-ttu-id="8606f-236">次の例は、`chatUser` 変数によって表されるローカル チャット ユーザーにチャット テキスト メッセージを送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-236">This following example shows how to send a chat text message with a local chat user represented by the `chatUser` variable:</span></span>

```cpp
chatUser->local()->send_chat_text(L"Hello");
```

<span data-ttu-id="8606f-237">ゲーム チャット 2 では、このメッセージを含むデータ フレームを生成します。このデータ フレームのターゲット エンドポイントは、ローカル ユーザーからテキストを受信するように構成されたユーザーに関連付けられたものになります。</span><span class="sxs-lookup"><span data-stu-id="8606f-237">Game Chat 2 will generate a data frame containing this message; the target endpoints for the data frame will be those associated with users that have been configured to receive text from the local user.</span></span> <span data-ttu-id="8606f-238">リモート エンドポイントでデータが処理されると、メッセージは `game_chat_text_chat_received_state_change` を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-238">When the data is processed by the remote endpoints, the message will be exposed via a `game_chat_text_chat_received_state_change`.</span></span> <span data-ttu-id="8606f-239">ボイス チャットと同様に、テキスト チャットでは権限とプライバシーの制限が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-239">As with voice chat, privilege and privacy restrictions are respected for text chat.</span></span> <span data-ttu-id="8606f-240">ユーザーの間で、テキスト チャットを許可するように構成されているが、権限またはプライバシーの制限によって通信が許可されていない場合、テキスト メッセージは通知なしで失われます。</span><span class="sxs-lookup"><span data-stu-id="8606f-240">If a pair of users have been configured to allow text chat, but privilege or privacy restrictions disallow that communication, the text message will be silently dropped.</span></span>

<span data-ttu-id="8606f-241">ユーザー補助のために、テキスト チャットの入力と表示のサポートが必要です (詳細については、「[ユーザー補助](#accessibility)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="8606f-241">Supporting text chat input and display is required for accessibility (see [Accessibility](#accessibility) for more details).</span></span>

## <a name="accessibility"></a><span data-ttu-id="8606f-242">ユーザー補助</span><span class="sxs-lookup"><span data-stu-id="8606f-242">Accessibility</span></span>

<span data-ttu-id="8606f-243">テキスト チャットの入力と表示のサポートは、ゲーム チャットおよびゲーム チャット 2 の両方に必要です。</span><span class="sxs-lookup"><span data-stu-id="8606f-243">Supporting text chat input and display is required for both Game Chat and Game Chat 2.</span></span> <span data-ttu-id="8606f-244">テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、ユーザーはこのシステムで、音声合成の支援技術を使用する場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="8606f-244">Text input is required because, even on platforms or game genres that historically haven't had widespread physical keyboard use, users may configure the system to use text-to-speech assistive technologies.</span></span> <span data-ttu-id="8606f-245">同様に、ユーザーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-245">Similarly, text display is required because users may configure the system to use speech-to-text.</span></span> <span data-ttu-id="8606f-246">ゲーム チャットおよびゲーム チャット 2 はいずれも、ユーザーのユーザー補助の設定を検出して考慮するメソッドを提供します。これらの設定に基づいて、条件付きでテキストのメカニズムを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="8606f-246">Both Game Chat and Game Chat 2 provide methods of detecting and respecting a user's accessibility preferences; you may wish to conditionally enable text mechanisms based on these settings.</span></span>

### <a name="text-to-speech---game-chat"></a><span data-ttu-id="8606f-247">音声合成 - ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-247">Text-to-speech - Game Chat</span></span>

<span data-ttu-id="8606f-248">ユーザーが音声合成を有効にしていると、`GameChatUser::HasRequestedSynthesizedAudio()` は true を返します。</span><span class="sxs-lookup"><span data-stu-id="8606f-248">When a user has text-to-speech enabled, `GameChatUser::HasRequestedSynthesizedAudio()` will return true.</span></span> <span data-ttu-id="8606f-249">この状態が検出されると、`GameChatUser::GenerateTextMessage()` は、ローカルのユーザーに関連付けられているオーディオ ストリームに挿入されている音声合成のオーディオを生成します。</span><span class="sxs-lookup"><span data-stu-id="8606f-249">When this state is detected, `GameChatUser::GenerateTextMessage()` will additionally generate text-to-speech audio that is inserted into the audio stream associated with the local user.</span></span> <span data-ttu-id="8606f-250">次の例は、`chatUser` 変数によって表されるローカル ユーザーにチャット テキスト メッセージを送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8606f-250">The following example shows how to send a chat text message with a local user represented by the `chatUser` variable:</span></span>

```cpp
chatUser->GenerateTextMessage(L"Hello", true);
```

<span data-ttu-id="8606f-251">2 番目のブール値パラメーターは、アプリが音声テキスト変換の基本設定を上書きすることを許可するために使用されます。'true' は、ユーザーの音声合成の基本設定が有効になっている場合に、ゲーム チャットがオン税構成のオーディオを生成する必要があることを示します。'false' は、ゲーム チャットがメッセージから音声合成のオーディオを生成しないことを示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-251">The second boolean parameter is used to allow the app to override the speech-to-text preference - 'true' indicates that Game Chat should generate text-to-speech audio when the user's text-to-speech preference has been enabled, while 'false' indicates that Game Chat should never generate text-to-speech audio from the message.</span></span>

### <a name="text-to-speech---game-chat-2"></a><span data-ttu-id="8606f-252">音声合成 - ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-252">Text-to-speech - Game Chat 2</span></span>

<span data-ttu-id="8606f-253">ユーザーが音声合成を有効にしていると、`chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` は 'true' を返します。</span><span class="sxs-lookup"><span data-stu-id="8606f-253">When a user has text-to-speech enabled, `chat_user::chat_user_local::text_to_speech_conversion_preference_enabled()` will return 'true'.</span></span> <span data-ttu-id="8606f-254">この状態が検出されると、アプリではテキスト入力の方法を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-254">When this state is detected, the app must provide a method of text input.</span></span> <span data-ttu-id="8606f-255">現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `chat_user::chat_user_local::synthesize_text_to_speech()` メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="8606f-255">Once you have the text input provided by a real or virtual keyboard, pass the string to the `chat_user::chat_user_local::synthesize_text_to_speech()` method.</span></span> <span data-ttu-id="8606f-256">ゲーム チャット 2 では、文字列を検出し、ユーザーの利用可能な音声設定に基づいてオーディオ データを合成します。</span><span class="sxs-lookup"><span data-stu-id="8606f-256">Game Chat 2 will detect and synthesize audio data based on the string and the user's accessible voice preference.</span></span> <span data-ttu-id="8606f-257">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-257">For example:</span></span>

```cpp
chat_userA->local()->synthesize_text_to_speech(L"Hello");
```

<span data-ttu-id="8606f-258">この操作の一環として合成されたオーディオは、このローカル ユーザーからオーディオを受信するように構成されたユーザー全員に転送されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-258">The audio synthesized as part of this operation will be transported to all users that have been configured to receive audio from this local user.</span></span> <span data-ttu-id="8606f-259">音声合成を有効にしていないユーザーから `chat_user::chat_user_local::synthesize_text_to_speech()` が呼び出された場合、ゲーム チャット 2 では何も実行しません。</span><span class="sxs-lookup"><span data-stu-id="8606f-259">If `chat_user::chat_user_local::synthesize_text_to_speech()` is called on a user who does not have text-to-speech enabled Game Chat 2 will take no action.</span></span>

### <a name="speech-to-text---game-chat"></a><span data-ttu-id="8606f-260">音声テキスト変換 - ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-260">Speech-to-text - Game Chat</span></span>

<span data-ttu-id="8606f-261">ユーザーが音声テキスト変換を有効にしていると、`GameChatUser::HasRequestSynthesizedAudio()` は 'true' を返します。</span><span class="sxs-lookup"><span data-stu-id="8606f-261">When a user has speech-to-text enabled, `GameChatUser::HasRequestSynthesizedAudio()` will return 'true'.</span></span> <span data-ttu-id="8606f-262">この状態が検出されると、ゲーム チャットは自動的に各リモート ユーザーの音声をテキストに変換し、`OnTextMessageReceived` イベントを通じて公開します。</span><span class="sxs-lookup"><span data-stu-id="8606f-262">When this state is detected, Game Chat will automatically transcribe the audio of each remote user's audio and expose it via the `OnTextMessageReceived` event.</span></span> <span data-ttu-id="8606f-263">テキストに変換されたメッセージを受信したために `OnTextMessageReceived` イベントが発生すると、`TextMessageReceivedEventArgs` はメッセージの種類として `ChatTextMessageType::TranscribedSpeechMessage` を示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-263">When the `OnTextMessageReceived` event fires due to the receipt of a transcription message, the `TextMessageReceivedEventArgs` will indicate a message type of `ChatTextMessageType::TranscribedSpeechMessage`.</span></span>

### <a name="speech-to-text---game-chat-2"></a><span data-ttu-id="8606f-264">音声テキスト変換 - ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-264">Speech-to-text - Game Chat 2</span></span>

<span data-ttu-id="8606f-265">ユーザーが音声テキスト変換を有効にしていると、`chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` は true を返します。</span><span class="sxs-lookup"><span data-stu-id="8606f-265">When a user has speech-to-text enabled, `chat_user::chat_user_local::speech_to_text_conversion_preference_enabled()` will return true.</span></span> <span data-ttu-id="8606f-266">この状態が検出されると、アプリは変換されたチャット メッセージに関連付けられた UI を提供する準備ができている必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-266">When this state is detected, the app must be prepared to provide UI associated with transcribed chat messages.</span></span> <span data-ttu-id="8606f-267">ゲーム チャット 2 では各リモート ユーザーのオーディオを自動的に変換して、`game_chat_transcribed_chat_received_state_change` を通じて公開します。</span><span class="sxs-lookup"><span data-stu-id="8606f-267">Game Chat 2 will automatically transcribe each remote user's audio and expose it via a `game_chat_transcribed_chat_received_state_change`.</span></span>

> `Windows::Xbox::UI::Accessibility` <span data-ttu-id="8606f-268">は、音声テキスト変換支援技術を搭載したゲーム内のテキストチャットを単純にレンダリングできるように特別に設計された Xbox One のクラスです。</span><span class="sxs-lookup"><span data-stu-id="8606f-268">is an Xbox One class specifically designed to provide simple rendering of in-game text chat with a focus on speech-to-text assistive technologies.</span></span>

<span data-ttu-id="8606f-269">音声テキスト変換のパフォーマンスに関する考慮事項の詳細については、「[ゲーム チャット 2 の使用 - 音声テキスト変換のパフォーマンスに関する考慮事項](using-game-chat-2.md#speech-to-text-performance-considerations)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8606f-269">Refer to [Using Game Chat 2 - Speech-to-text performance considerations](using-game-chat-2.md#speech-to-text-performance-considerations) for more details on speech-to-text performance considerations.</span></span>

## <a name="ui"></a><span data-ttu-id="8606f-270">UI</span><span class="sxs-lookup"><span data-stu-id="8606f-270">UI</span></span>

<span data-ttu-id="8606f-271">特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8606f-271">It's recommended that anywhere players are shown, particularly in a list of gamertags such as a scoreboard, that you also display muted/speaking icons as feedback for the user.</span></span> <span data-ttu-id="8606f-272">ゲーム チャット 2 には、表示する適切な UI 要素を簡単に判断する方法を提供する一体化したインジケーターが導入されています。</span><span class="sxs-lookup"><span data-stu-id="8606f-272">Game Chat 2 introduces a coalesced indicator that provides a simpler means of determining the appropriate UI elements to show.</span></span>

### <a name="game-chat"></a><span data-ttu-id="8606f-273">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-273">Game Chat</span></span>

<span data-ttu-id="8606f-274">`GameChatUser` には、適切な UI 要素を判断するときに一般的に検査される 3 つのプロパティ `GameChatUser::TalkingMode`、`GameChatUser::IsMuted`、`GameChatUser::RestrictionMode` があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-274">A `GameChatUser` has three properties that are commonly inspected when determining appropriate UI elements - `GameChatUser::TalkingMode`, `GameChatUser::IsMuted`, and `GameChatUser::RestrictionMode`.</span></span> <span data-ttu-id="8606f-275">次の例では、'chatUser' 変数によって指定される `GameChatUser` オブジェクトから `iconToShow` 変数に割り当てる特定のアイコンの定数値を決定するためのヒューリスティックを示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-275">The following example demonstrates a possible heuristic for determining a particular icon constant vlaue to assign to an `iconToShow` variable from a `GameChatUser` object pointed to by the variable 'chatUser'.</span></span>

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

### <a name="game-chat-2"></a><span data-ttu-id="8606f-276">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-276">Game Chat 2</span></span>

<span data-ttu-id="8606f-277">ゲーム チャット 2 には、プレイヤーのチャットについて現在の瞬間的なステータスを表すために使用される、一体化された `game_chat_user_chat_indicator` があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-277">Game Chat 2 has a coalesced `game_chat_user_chat_indicator` used to represent the current, instantaneous status of chat for a player.</span></span> <span data-ttu-id="8606f-278">この値は、`chat_user::chat_indicator()` を呼び出すことによって取得されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-278">This value is retrieved by calling `chat_user::chat_indicator()`.</span></span> <span data-ttu-id="8606f-279">次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'chatUser' 変数で指定した `chat_user` オブジェクトのインジケーター値の取得を示します。</span><span class="sxs-lookup"><span data-stu-id="8606f-279">The following example demonstrates retrieving the indicator value for a `chat_user` object pointed to by the variable 'chatUser' to determine a particular icon constant value to assign to an 'iconToShow' variable:</span></span>

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

## <a name="muting"></a><span data-ttu-id="8606f-280">ミュート</span><span class="sxs-lookup"><span data-stu-id="8606f-280">Muting</span></span>

## <a name="game-chat"></a><span data-ttu-id="8606f-281">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-281">Game Chat</span></span>

<span data-ttu-id="8606f-282">ゲーム チャットでのユーザーのミュートとミュート解除は、それぞれ `ChatManager::MuteUserFromAllChannels()` または `ChatManager::UnMuteUIserFromAllChannels()` の呼び出しによって実行されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-282">Muting or unmuting a user in Game Chat is performed through a call to `ChatManager::MuteUserFromAllChannels()` or `ChatManager::UnMuteUIserFromAllChannels()`, respectively.</span></span> <span data-ttu-id="8606f-283">ユーザーのミュート状態は、`GameChatUser::IsMuted` または `GameChatUser::IsLocalUserMuted` を調べることによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-283">The mute state of a user can be retrieved by inspecting `GameChatUser::IsMuted` or `GameChatUser::IsLocalUserMuted`.</span></span>

## <a name="game-chat-2"></a><span data-ttu-id="8606f-284">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-284">Game Chat 2</span></span>

<span data-ttu-id="8606f-285">`chat_user::chat_user_local::set_microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="8606f-285">The `chat_user::chat_user_local::set_microphone_muted()` method can be used to toggle the mute state of a local user's microphone.</span></span> <span data-ttu-id="8606f-286">マイクがミュート状態の場合、マイクからオーディオはキャプチャされません。</span><span class="sxs-lookup"><span data-stu-id="8606f-286">When the microphone is muted, no audio from that microphone will be captured.</span></span> <span data-ttu-id="8606f-287">ユーザーが Kinect などの共有デバイスを使用している場合、ミュート状態はすべてのユーザーに適用されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-287">If the user is on a shared device, such as Kinect, the mute state applies to all users.</span></span>

<span data-ttu-id="8606f-288">`chat_user::chat_user_local::microphone_muted()` メソッドを使用すると、ローカル ユーザーのマイクのミュート状態を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="8606f-288">The `chat_user::chat_user_local::microphone_muted()` method can be used to retrieve the mute state of a local user's microphone.</span></span> <span data-ttu-id="8606f-289">このメソッドは、ローカル ユーザーのマイクが `chat_user::chat_user_local::set_microphone_muted()` の呼び出しを通じてソフトウェアでミュートされているかどうかのみ反映しています。たとえば、ユーザーのヘッドセットのボタンを通じてハードウェアのミュートが制御されていることは反映していません。</span><span class="sxs-lookup"><span data-stu-id="8606f-289">This method only reflects whether the local user's microphone has been muted in software via a call to `chat_user::chat_user_local::set_microphone_muted()`; this method does not reflect a hardware mute controlled, for instance, via a button on the user's headset.</span></span> <span data-ttu-id="8606f-290">ゲーム チャット 2 を通じてユーザーのオーディオ デバイスのハードウェアのミュート状態を取得するメソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="8606f-290">There is no method for retrieving the hardware mute state of a user's audio device through Game Chat 2.</span></span>

<span data-ttu-id="8606f-291">`chat_user::chat_user_local::set_remote_user_muted()` メソッドを使用すると、特定のローカル ユーザーに関連するリモート ユーザーのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="8606f-291">The `chat_user::chat_user_local::set_remote_user_muted()` method can be used to toggle the mute state of a remote user in relation to a particular local user.</span></span> <span data-ttu-id="8606f-292">リモート ユーザーがミュート状態の場合、ローカル ユーザーにはそのリモート ユーザーの音声は聞こえません。また、そのリモート ユーザーからのテキスト メッセージを受信しません。</span><span class="sxs-lookup"><span data-stu-id="8606f-292">When the remote user is muted, the local user won't hear any audio or receive any text messages from the remote user.</span></span>

## <a name="bad-reputation-auto-mute"></a><span data-ttu-id="8606f-293">悪い評判の自動ミュート</span><span class="sxs-lookup"><span data-stu-id="8606f-293">Bad reputation auto-mute</span></span>

<span data-ttu-id="8606f-294">通常、リモート ユーザーはミュートを解除した状態で開始します。</span><span class="sxs-lookup"><span data-stu-id="8606f-294">Typically, remote users will start off unmuted.</span></span> <span data-ttu-id="8606f-295">ゲーム チャットとゲーム チャット 2 にはいずれも "悪い評判の自動ミュート" 機能があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-295">Both Game Chat and Game Chat 2 have a "bad reputation auto-mute" feature.</span></span> <span data-ttu-id="8606f-296">これは、(1) リモート ユーザーがローカル ユーザーのフレンドではなく、(2) リモート ユーザーに悪い評判のフラグがある場合、そのユーザーはミュート状態で開始されることを意味します。</span><span class="sxs-lookup"><span data-stu-id="8606f-296">This means that users will start off in a muted state when (1) the remote user isn't friends with a local user, and (2) the remote user has a bad reputation flag.</span></span> <span data-ttu-id="8606f-297">ゲーム チャット 2 では、この機能によりユーザーがミュートされているときに、フィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="8606f-297">Game Chat 2 provides feedback when a user is muted due to this feature.</span></span> <span data-ttu-id="8606f-298">詳細については、「[ゲーム チャット 2 の使用 - 悪い評判の自動ミュート](using-game-chat-2.md#bad-reputation-auto-mute)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8606f-298">Refer to [Using Game Chat 2 - Bad reputation auto-mute](using-game-chat-2.md#bad-reputation-auto-mute) for more information.</span></span>

## <a name="privilege-and-privacy"></a><span data-ttu-id="8606f-299">権限とプライバシー</span><span class="sxs-lookup"><span data-stu-id="8606f-299">Privilege and privacy</span></span>

<span data-ttu-id="8606f-300">ゲームによって管理されるチャンネルとコミュニケーション関係に対して、ゲーム チャットとゲーム チャット 2 はいずれも Xbox Live の権限とプライバシーの制限を適用します。</span><span class="sxs-lookup"><span data-stu-id="8606f-300">Both Game Chat and Game Chat 2 enforce Xbox Live privilege and privacy restrictions on top of any channel or communication relationships managed by the app.</span></span> <span data-ttu-id="8606f-301">さらに、ゲーム チャット 2 では、正確に制限がオーディオの方向にどのように影響しているかを判断するための診断情報を提供します (例: オーディオの制限が単方向か双方向か)。</span><span class="sxs-lookup"><span data-stu-id="8606f-301">Game Chat 2 additionally provides diagnostic information to determine exactly how the restriction is impacting the direction of audio (e.g. whether audio an audio restriction is uni- or bi-directional).</span></span>

### <a name="game-chat"></a><span data-ttu-id="8606f-302">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="8606f-302">Game Chat</span></span>

<span data-ttu-id="8606f-303">ゲーム チャットは、`RestrictionMode` プロパティを通じて、権限とプライバシーの情報を公開していました。</span><span class="sxs-lookup"><span data-stu-id="8606f-303">Game Chat exposed privilege and privacy information throught the `RestrictionMode` property.</span></span> <span data-ttu-id="8606f-304">これは、`GameChatUser::RestrictionMode` を調べることによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-304">It can be retrieved by inspecting `GameChatUser::RestrictionMode`.</span></span>

### <a name="game-chat-2"></a><span data-ttu-id="8606f-305">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="8606f-305">Game Chat 2</span></span>

<span data-ttu-id="8606f-306">ゲーム チャット 2 では、ユーザーが最初に追加されると、権限とプライバシーの制限の参照を実行します。この操作が完了するまで、ユーザーの `chat_user::chat_indicator()` は常に `game_chat_user_chat_indicator::silent` を返します。</span><span class="sxs-lookup"><span data-stu-id="8606f-306">Game Chat 2 performs privilege and privacy restriction lookups when a user is first added; the user's `chat_user::chat_indicator()` will always return `game_chat_user_chat_indicator::silent` until those operations complete.</span></span> <span data-ttu-id="8606f-307">ユーザーの通信が権限またはプライバシーの制限による影響を受ける場合、ユーザーの `chat_user::chat_indicator()` は `game_chat_user_chat_indicator::platform_restricted` を返します。</span><span class="sxs-lookup"><span data-stu-id="8606f-307">If communication with a user is affected by a privilege or privacy restriction, the user's `chat_user::chat_indicator()` will return `game_chat_user_chat_indicator::platform_restricted`.</span></span> <span data-ttu-id="8606f-308">プラットフォーム通信制限は、音声チャットとテキスト チャットの両方に適用されます。テキスト チャットがプラットフォーム制限によりブロックされて音声チャットが制限されないインスタンスはなく、その逆もありません。</span><span class="sxs-lookup"><span data-stu-id="8606f-308">Platform communication restrictions apply to both voice and text chat; there will never be an instance where text chat is blocked by a platform restriction but voice chat is not, or vice versa.</span></span>

`chat_user::chat_user_local::get_effective_communication_relationship()` <span data-ttu-id="8606f-309">を使用すると、不完全な権限とプライバシーの操作によってユーザーが通信できない場合の区別に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="8606f-309">can be used to help distinguish when users can't communicate due to incomplete privilege and privacy operations.</span></span> <span data-ttu-id="8606f-310">これを使用すると、ゲーム チャット 2 によって強制される通信リレーションシップが `game_chat_communication_relationship_flags` の形式で返されます。また、リレーションシップが構成されたリレーションシップと等しくない理由が `game_chat_communication_relationship_adjuster` の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-310">It returns the communication relationship enforced by Game Chat 2 in the form of `game_chat_communication_relationship_flags` and the reason the relationship may not be equal to the configured relationship in the form of `game_chat_communication_relationship_adjuster`.</span></span> <span data-ttu-id="8606f-311">たとえば、参照操作が進行中の場合、`game_chat_communication_relationship_adjuster` は `game_chat_communication_relationship_adjuster::intializing` になります。</span><span class="sxs-lookup"><span data-stu-id="8606f-311">For example, if the lookup operations are still in progress, the `game_chat_communication_relationship_adjuster` will be `game_chat_communication_relationship_adjuster::intializing`.</span></span> <span data-ttu-id="8606f-312">この方法は、開発シナリオとデバッグ シナリオで使用することを想定しています。UI に影響を与えるために使用しないでください (「[UI](#UI)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="8606f-312">This method is expected to be used in development and debugging scenarios; it should not be used to influence UI (see [UI](#UI)).</span></span>

## <a name="cleanup"></a><span data-ttu-id="8606f-313">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="8606f-313">Cleanup</span></span>

<span data-ttu-id="8606f-314">元のゲーム チャットの `ChatManager` は WinRT ランタイム クラスであり、参照がカウントされるインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="8606f-314">The original Game Chat's `ChatManager` is a WinRT runtime class - a reference counted interface.</span></span> <span data-ttu-id="8606f-315">そのため、最後の参照カウントが 0 になったときに、そのメモリ リソースは再利用され、クリーンアップされます。</span><span class="sxs-lookup"><span data-stu-id="8606f-315">As such, it's memory resources are reclaimed when the last reference count drops to zero and it cleans up.</span></span> <span data-ttu-id="8606f-316">ゲーム チャット 2 の C++ API との対話はシングルトン インスタンスを通じて実行されます。アプリでゲーム チャット 2 経由での通信が不要になった場合、`chat_manager::cleanup()` を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="8606f-316">Interaction with Game Chat 2's C++ API is done through a singleton instance; when the app no longer needs communications via Game Chat 2, you should call `chat_manager::cleanup()`.</span></span> <span data-ttu-id="8606f-317">これにより、ゲーム チャット 2 では、通信の管理に割り当てられたすべてのリソースを直ちに解放できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-317">This allows Game Chat 2 immediately release all resources that were allocated to manage communications.</span></span> <span data-ttu-id="8606f-318">ゲーム チャット 2 の WinRT API とリソース管理について詳しくは、「[ゲーム チャット 2 (WinRT プロジェクション) の使用](using-game-chat-2-winrt.md#cleanup)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8606f-318">For details on Game Chat 2's WinRT API and resource management, see [Using Game Chat 2 WinRT Projections](using-game-chat-2-winrt.md#cleanup).</span></span>

## <a name="failure-model-and-debugging"></a><span data-ttu-id="8606f-319">エラー モデルとデバッグ</span><span class="sxs-lookup"><span data-stu-id="8606f-319">Failure model and debugging</span></span>

<span data-ttu-id="8606f-320">元のゲーム チャットは WinRT API であるため、例外を使用してエラーを報告していました。</span><span class="sxs-lookup"><span data-stu-id="8606f-320">The original Game Chat is a WinRT API; thus, it reported errors through exceptions.</span></span> <span data-ttu-id="8606f-321">致命的ではないエラーや警告は、オプションのデバッグ コールバックで報告されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-321">Non-fatal errors or warnings are reported through an optional debug callback.</span></span> <span data-ttu-id="8606f-322">ゲーム チャット 2 の C++ API では、致命的ではないエラーの報告手段として例外をスローしないため、必要な場合には、例外が発生しないプロジェクトから簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="8606f-322">Game Chat 2's C++ API doesn't throw exceptions as a means of non-fatal error reporting so you can consume it easily from exception-free projects if preferred.</span></span> <span data-ttu-id="8606f-323">ただし、ゲーム チャット 2 は致命的なエラーを通知するために例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="8606f-323">Game Chat 2 does, however, throw exceptions to inform about fatal errors.</span></span> <span data-ttu-id="8606f-324">これらのエラーは、インスタンスを初期化する前にゲーム チャット インスタンスにユーザーを追加したり、ゲーム チャット インスタンスから削除された後にユーザー オブジェクトにアクセスしたりなど、API の誤用によるものです。</span><span class="sxs-lookup"><span data-stu-id="8606f-324">These errors are a result of API misuse, such as adding a user to the Game Chat instance before initializing the instance or accessing a user object after it has been removed from the Game Chat instance.</span></span> <span data-ttu-id="8606f-325">これらのエラーは開発の早い段階で検出することが期待され、ゲーム チャット 2 との対話に使用されるパターンを変更して修正することができます。</span><span class="sxs-lookup"><span data-stu-id="8606f-325">These errors are expected to be caught early in development and can be corrected by modifying the pattern used to interact with Game Chat 2.</span></span> <span data-ttu-id="8606f-326">このようなエラーが発生した場合、例外が発生する前に、エラーの原因に関するヒントがデバッガーに出力されます。</span><span class="sxs-lookup"><span data-stu-id="8606f-326">When such an error occurs, a hint as to what caused the error is printed to the debugger before the exception is raised.</span></span> <span data-ttu-id="8606f-327">ゲーム チャット 2 の WinRT API は、例外を使用してエラーを報告する WinRT パターンに従います。</span><span class="sxs-lookup"><span data-stu-id="8606f-327">Game Chat 2's WinRT API follows the WinRT pattern of reporting errors through exceptions.</span></span>

## <a name="how-to-configure-popular-scenarios"></a><span data-ttu-id="8606f-328">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="8606f-328">How to configure popular scenarios</span></span>

<span data-ttu-id="8606f-329">プッシュして話しかける、チーム、ブロードキャスト スタイルの通信シナリオなど、一般的なシナリオを構成する方法の例については、「[ゲーム チャット 2 の使用 - 一般的なシナリオの構成方法](using-game-chat-2.md#how-to-configure-popular-scenarios)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8606f-329">Refer to [Using Game Chat 2 - How to configure popular scenarios](using-game-chat-2.md#how-to-configure-popular-scenarios) for examples on how to configure popular scenarios such as push-to-talk, teams, and broadcast-style communication scenarios.</span></span>

## <a name="pre-encode-and-post-decode-audio-manipulation"></a><span data-ttu-id="8606f-330">プリエンコードおよびポストデコード オーディオ操作</span><span class="sxs-lookup"><span data-stu-id="8606f-330">Pre-encode and post-decode audio manipulation</span></span>

<span data-ttu-id="8606f-331">元のゲーム チャットでは、`OnPreEncodeAudioBuffer` イベントと `OnPostDecodeAudioBuffers` イベントを通じて、未処理のマイク オーディオへのアクセスを許可することにより、オーディオ操作を許可していました。</span><span class="sxs-lookup"><span data-stu-id="8606f-331">The original Game Chat allowed for audio manipulation by allowing access to raw microphone audio through the `OnPreEncodeAudioBuffer` and `OnPostDecodeAudioBuffers` events.</span></span> <span data-ttu-id="8606f-332">ゲーム チャット 2 では、ポーリング モデルを使用してこの機能を公開します。</span><span class="sxs-lookup"><span data-stu-id="8606f-332">Game Chat 2 exposes this feature through a polling model.</span></span> <span data-ttu-id="8606f-333">詳しくは、「[リアルタイム オーディオ操作](real-time-audio-manipulation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8606f-333">For more information, refer to [Real-time audio manipulation](real-time-audio-manipulation.md).</span></span>
