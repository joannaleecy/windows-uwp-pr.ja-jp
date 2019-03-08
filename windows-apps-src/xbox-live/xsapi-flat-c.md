---
title: Xbox Live の C Api
description: Xbox Live サービスとの対話に使用できるフラット C API モデルについて説明します。
ms.date: 06/05/2018
ms.topic: article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、c、xsapi
ms.localizationpriority: medium
ms.openlocfilehash: a1c73661b561d586f9e28957c7caa6a1b1f9cb03
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597527"
---
# <a name="introduction-to-the-xbox-live-c-apis"></a><span data-ttu-id="88964-104">Xbox Live の C Api の概要</span><span class="sxs-lookup"><span data-stu-id="88964-104">Introduction to the Xbox Live C APIs</span></span>

<span data-ttu-id="88964-105">2018 年 6 月では、新しいフラット C API レイヤーは XSAPI に追加されました。</span><span class="sxs-lookup"><span data-stu-id="88964-105">In June, 2018, a new flat C API layer was added to XSAPI.</span></span> <span data-ttu-id="88964-106">この新しい API レイヤーは、C++ と WinRT API レイヤーで発生したいくつかの問題を解決します。</span><span class="sxs-lookup"><span data-stu-id="88964-106">This new API layer solves some issues that occurred with the C++ and WinRT API layers.</span></span>

<span data-ttu-id="88964-107">C API が XSAPI のすべての機能をまだ扱っていないが、その他の機能が取り組んでいます。</span><span class="sxs-lookup"><span data-stu-id="88964-107">The C API does not yet cover all XSAPI features, but additional features are being worked on.</span></span> <span data-ttu-id="88964-108">すべて 3 API レイヤー、C、C++、および WinRT は引き続きサポートし、時間の経過と共に追加の機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="88964-108">All 3 API layers, C, C++, and WinRT will continue to be supported and have additional features added over time.</span></span>

> [!NOTE]
> <span data-ttu-id="88964-109">C Api 現在でのみ使用 Xbox Developer Kit (XDK) を使用するタイトル。</span><span class="sxs-lookup"><span data-stu-id="88964-109">The C APIs currently only work with titles that use the Xbox Developer Kit (XDK).</span></span> <span data-ttu-id="88964-110">この時点でゲームを UWP はサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="88964-110">They do not support UWP games at this time.</span></span>

## <a name="features-covered-by-the-c-apis"></a><span data-ttu-id="88964-111">C Api で説明されている機能</span><span class="sxs-lookup"><span data-stu-id="88964-111">Features covered by the C APIs</span></span>

<span data-ttu-id="88964-112">現在、C API は、次の機能とサービスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="88964-112">The C API currently supports the following features and services:</span></span>

- <span data-ttu-id="88964-113">成績</span><span class="sxs-lookup"><span data-stu-id="88964-113">Achievements</span></span>
- <span data-ttu-id="88964-114">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="88964-114">Presence</span></span>
- <span data-ttu-id="88964-115">Profile</span><span class="sxs-lookup"><span data-stu-id="88964-115">Profile</span></span>
- <span data-ttu-id="88964-116">ソーシャル</span><span class="sxs-lookup"><span data-stu-id="88964-116">Social</span></span>
- <span data-ttu-id="88964-117">Social Manager</span><span class="sxs-lookup"><span data-stu-id="88964-117">Social Manager</span></span>

## <a name="benefits-of-the-c-api-for-xsapi"></a><span data-ttu-id="88964-118">XSAPI の C API の利点</span><span class="sxs-lookup"><span data-stu-id="88964-118">Benefits of the C API for XSAPI</span></span>

- <span data-ttu-id="88964-119">XSAPI を呼び出すときに、メモリの割り当てを制御するタイトルを使用できます。</span><span class="sxs-lookup"><span data-stu-id="88964-119">Allows titles to control the memory allocations when calling XSAPI.</span></span>
- <span data-ttu-id="88964-120">スレッド処理 XSAPI を呼び出すときに完全に制御するタイトルを使用できます。</span><span class="sxs-lookup"><span data-stu-id="88964-120">Allows titles to gain full control of thread handling when calling XSAPI.</span></span>
- <span data-ttu-id="88964-121">新しい HTTP ライブラリを libHttpClient、ゲーム開発者向けに設計を使用します。</span><span class="sxs-lookup"><span data-stu-id="88964-121">Uses a new HTTP library, libHttpClient, designed for game developers.</span></span>

<span data-ttu-id="88964-122">C++ の XSAPI と共に C Api を使用できますが、C++ Api を使用した上記の利点を利用できません。</span><span class="sxs-lookup"><span data-stu-id="88964-122">You can use the C APIs alongside C++ XSAPI, but you will not gain the previously listed benefits with the C++ APIs.</span></span>

### <a name="managing-memory-allocations"></a><span data-ttu-id="88964-123">メモリ割り当ての管理</span><span class="sxs-lookup"><span data-stu-id="88964-123">Managing memory allocations</span></span>

<span data-ttu-id="88964-124">新しい C API を使用して、メモリを割り当てるときに呼び出す XSAPI 関数コールバックを指定できます。</span><span class="sxs-lookup"><span data-stu-id="88964-124">With the new C API, you can now specify a function callback that XSAPI will call whenever it tries to allocate memory.</span></span> <span data-ttu-id="88964-125">関数コールバックを指定しない場合、XSAPI は標準的なメモリ割り当てルーチンを使用します。</span><span class="sxs-lookup"><span data-stu-id="88964-125">If you do not specify function callbacks, XSAPI will use standard memory allocation routines.</span></span>

<span data-ttu-id="88964-126">ルーチンは、メモリを手動で指定するには、次の操作を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="88964-126">To manually specify your memory routines, you can do the following:</span></span>

- <span data-ttu-id="88964-127">ゲームの先頭には。</span><span class="sxs-lookup"><span data-stu-id="88964-127">At the start of the game:</span></span>
  - <span data-ttu-id="88964-128">呼び出す`XblMemSetFunctions(memAllocFunc, memFreeFunc)`割り当てと解放をメモリの割り当てのコールバックを指定します。</span><span class="sxs-lookup"><span data-stu-id="88964-128">Call `XblMemSetFunctions(memAllocFunc, memFreeFunc)` to specify the allocation callbacks for assigning and releasing memory.</span></span>
  - <span data-ttu-id="88964-129">呼び出す`XblInitialize()`ライブラリのインスタンスを初期化します。</span><span class="sxs-lookup"><span data-stu-id="88964-129">Call `XblInitialize()` to initialize the library instance.</span></span>  
- <span data-ttu-id="88964-130">ゲームの実行: 中</span><span class="sxs-lookup"><span data-stu-id="88964-130">While the game is running:</span></span>
  - <span data-ttu-id="88964-131">呼び出す新しい C Api のいずれかで XSAPI を割り当てるまたは XSAPI を指定されたメモリ処理のコールバックを呼び出すと、メモリを解放します。</span><span class="sxs-lookup"><span data-stu-id="88964-131">Calling any of the new C APIs in XSAPI that allocate or free memory will cause XSAPI to call the specified memory handling callbacks.</span></span>  
- <span data-ttu-id="88964-132">ゲームが終了します。</span><span class="sxs-lookup"><span data-stu-id="88964-132">When the game exits:</span></span>
  - <span data-ttu-id="88964-133">呼び出す`XblCleanup()`XSAPI ライブラリに関連付けられているすべてのリソースを解放します。</span><span class="sxs-lookup"><span data-stu-id="88964-133">Call `XblCleanup()` to reclaim all resources associated with the XSAPI library.</span></span>
  - <span data-ttu-id="88964-134">ゲームのカスタム メモリ マネージャーをクリーンアップします。</span><span class="sxs-lookup"><span data-stu-id="88964-134">Clean up your game's custom memory manager.</span></span>

### <a name="managing-asynchronous-threads"></a><span data-ttu-id="88964-135">非同期のスレッドを管理します。</span><span class="sxs-lookup"><span data-stu-id="88964-135">Managing asynchronous threads</span></span>

<span data-ttu-id="88964-136">C API には、開発者がスレッド処理モデルを完全に制御できるパターンを呼び出して新しい非同期のスレッドが導入されています。</span><span class="sxs-lookup"><span data-stu-id="88964-136">The C API introduces a new asynchronous thread calling pattern that allows developers full control over the threading model.</span></span> <span data-ttu-id="88964-137">詳細については、次を参照してください。 [XSAPI の呼び出しパターンは、C レイヤーの非同期呼び出しをフラット](flatc-async-patterns.md)します。</span><span class="sxs-lookup"><span data-stu-id="88964-137">For more information, see [Calling pattern for XSAPI flat C layer async calls](flatc-async-patterns.md).</span></span>

## <a name="migrating-code-to-use-c-xsapi"></a><span data-ttu-id="88964-138">C XSAPI を使用するコードの移行</span><span class="sxs-lookup"><span data-stu-id="88964-138">Migrating code to use C XSAPI</span></span>

<span data-ttu-id="88964-139">一度に 1 つの機能を移行することをお勧めします。 プロジェクトでは、XSAPI C++ Api と共に XSAPI C Api を使用できます。</span><span class="sxs-lookup"><span data-stu-id="88964-139">The XSAPI C APIs can be used alongside the XSAPI C++ APIs in a project, so we recommend that you migrate one feature at a time.</span></span>

<span data-ttu-id="88964-140">C Api および C++ Api 機能は変更されませんのでだけ異なるエントリ ポイントでの common core の実際にはシン ラッパーであります。</span><span class="sxs-lookup"><span data-stu-id="88964-140">The C APIs and C++ APIs are really just thin wrappers around a common core, just with different entry points, so the functionality should be unchanged.</span></span> <span data-ttu-id="88964-141">ただし、C Api のみ利用できますカスタム メモリとスレッドの管理機能。</span><span class="sxs-lookup"><span data-stu-id="88964-141">However, only the C APIs can take advantage of the custom memory and thread management features.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="88964-142">C Api を使用した XSAPI WinRT Api を混在させることはできません。</span><span class="sxs-lookup"><span data-stu-id="88964-142">You cannot mix XSAPI WinRT APIs with the C APIs.</span></span>

## <a name="where-to-view-the-c-apis"></a><span data-ttu-id="88964-143">C Api を表示します。</span><span class="sxs-lookup"><span data-stu-id="88964-143">Where to view the C APIs</span></span>

- [<span data-ttu-id="88964-144">C API ヘッダー ファイル</span><span class="sxs-lookup"><span data-stu-id="88964-144">C API header files</span></span>](https://github.com/Microsoft/xbox-live-api/tree/master/Include/xsapi-c)
- [<span data-ttu-id="88964-145">新しい C Api を使用してサンプル コード</span><span class="sxs-lookup"><span data-stu-id="88964-145">Sample code using the new C APIs</span></span>](https://github.com/Microsoft/xbox-live-api/tree/master/InProgressSamples/Social/Xbox/C)
- [<span data-ttu-id="88964-146">libHttpClient</span><span class="sxs-lookup"><span data-stu-id="88964-146">libHttpClient</span></span>](https://github.com/Microsoft/libHttpClient)
