---
title: Xbox Live の C++ Api
author: KevinAsgari
description: Xbox Live サービスとのやり取りに使用できるフラット C API モデルについて説明します。
ms.author: kevinasg
ms.date: 06/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム、uwp、windows 10, xbox one, c, xsapi
ms.localizationpriority: medium
ms.openlocfilehash: ac47d3877c44cfa9891753c49be8a5749fba9185
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4207539"
---
# <a name="introduction-to-the-xbox-live-c-apis"></a><span data-ttu-id="28e3b-104">Xbox Live の C++ Api の概要</span><span class="sxs-lookup"><span data-stu-id="28e3b-104">Introduction to the Xbox Live C APIs</span></span>

<span data-ttu-id="28e3b-105">2018 年 6 月の新しいフラット C API レイヤーは、XSAPI に追加されました。</span><span class="sxs-lookup"><span data-stu-id="28e3b-105">In June, 2018, a new flat C API layer was added to XSAPI.</span></span> <span data-ttu-id="28e3b-106">この新しい API レイヤーでは、C++ と WinRT API レイヤーで発生したいくつかの問題を解決します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-106">This new API layer solves some issues that occurred with the C++ and WinRT API layers.</span></span>

<span data-ttu-id="28e3b-107">C++ API は、XSAPI のすべての機能をまだ対応していませんが、作業中は追加の機能。</span><span class="sxs-lookup"><span data-stu-id="28e3b-107">The C API does not yet cover all XSAPI features, but additional features are being worked on.</span></span> <span data-ttu-id="28e3b-108">すべて 3 API レイヤー、C、C++ と WinRT は引き続きサポートされているし、時間の経過と共に新しい機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-108">All 3 API layers, C, C++, and WinRT will continue to be supported and have additional features added over time.</span></span>

> [!NOTE]
> <span data-ttu-id="28e3b-109">C++ Api は、現在のみ動作 Xbox 開発キット (XDK) を使用するタイトルにします。</span><span class="sxs-lookup"><span data-stu-id="28e3b-109">The C APIs currently only work with titles that use the Xbox Developer Kit (XDK).</span></span> <span data-ttu-id="28e3b-110">この時点で UWP ゲームはサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="28e3b-110">They do not support UWP games at this time.</span></span>

## <a name="features-covered-by-the-c-apis"></a><span data-ttu-id="28e3b-111">C++ Api で取り上げた機能</span><span class="sxs-lookup"><span data-stu-id="28e3b-111">Features covered by the C APIs</span></span>

<span data-ttu-id="28e3b-112">現在、C API には、次の機能とサービスがサポートしています。</span><span class="sxs-lookup"><span data-stu-id="28e3b-112">The C API currently supports the following features and services:</span></span>

- <span data-ttu-id="28e3b-113">実績</span><span class="sxs-lookup"><span data-stu-id="28e3b-113">Achievements</span></span>
- <span data-ttu-id="28e3b-114">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="28e3b-114">Presence</span></span>
- <span data-ttu-id="28e3b-115">プロファイル</span><span class="sxs-lookup"><span data-stu-id="28e3b-115">Profile</span></span>
- <span data-ttu-id="28e3b-116">ソーシャル</span><span class="sxs-lookup"><span data-stu-id="28e3b-116">Social</span></span>
- <span data-ttu-id="28e3b-117">Social Manager</span><span class="sxs-lookup"><span data-stu-id="28e3b-117">Social Manager</span></span>

## <a name="benefits-of-the-c-api-for-xsapi"></a><span data-ttu-id="28e3b-118">Xsapi C API のメリット</span><span class="sxs-lookup"><span data-stu-id="28e3b-118">Benefits of the C API for XSAPI</span></span>

- <span data-ttu-id="28e3b-119">タイトルを XSAPI を呼び出すときにメモリ割り当てを制御できます。</span><span class="sxs-lookup"><span data-stu-id="28e3b-119">Allows titles to control the memory allocations when calling XSAPI.</span></span>
- <span data-ttu-id="28e3b-120">により、タイトルを XSAPI を呼び出すときの処理スレッドの完全な制御を取得します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-120">Allows titles to gain full control of thread handling when calling XSAPI.</span></span>
- <span data-ttu-id="28e3b-121">新しい HTTP ライブラリ、libHttpClient、ゲーム開発者向けに設計されたを使用します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-121">Uses a new HTTP library, libHttpClient, designed for game developers.</span></span>

<span data-ttu-id="28e3b-122">と共に C++ XSAPI C Api を使用することができますが、C++ Api を使って上記のメリットを獲得はできません。</span><span class="sxs-lookup"><span data-stu-id="28e3b-122">You can use the C APIs alongside C++ XSAPI, but you will not gain the previously listed benefits with the C++ APIs.</span></span>

### <a name="managing-memory-allocations"></a><span data-ttu-id="28e3b-123">メモリ割り当てを管理します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-123">Managing memory allocations</span></span>

<span data-ttu-id="28e3b-124">新しい C++ API を使った、XSAPI がメモリを割り当てることがしようとしたときに呼び出す関数コールバックを指定できます。</span><span class="sxs-lookup"><span data-stu-id="28e3b-124">With the new C API, you can now specify a function callback that XSAPI will call whenever it tries to allocate memory.</span></span> <span data-ttu-id="28e3b-125">関数コールバックを指定しない場合、XSAPI は標準的なメモリ割り当てルーチンを使用します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-125">If you do not specify function callbacks, XSAPI will use standard memory allocation routines.</span></span>

<span data-ttu-id="28e3b-126">メモリ ルーチンを手動で指定するには、次の操作を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="28e3b-126">To manually specify your memory routines, you can do the following:</span></span>

- <span data-ttu-id="28e3b-127">ゲームの起動時には。</span><span class="sxs-lookup"><span data-stu-id="28e3b-127">At the start of the game:</span></span>
  - <span data-ttu-id="28e3b-128">呼び出す`XblMemSetFunctions(memAllocFunc, memFreeFunc)`を割り当てると、メモリを解放して割り当てコールバックを指定します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-128">Call `XblMemSetFunctions(memAllocFunc, memFreeFunc)` to specify the allocation callbacks for assigning and releasing memory.</span></span>
  - <span data-ttu-id="28e3b-129">呼び出す`XblInitialize()`ライブラリのインスタンスを初期化します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-129">Call `XblInitialize()` to initialize the library instance.</span></span>  
- <span data-ttu-id="28e3b-130">ゲームが実行中します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-130">While the game is running:</span></span>
  - <span data-ttu-id="28e3b-131">新しい C++ Api のいずれかの XSAPI でした呼び出しの割り当てまたは XSAPI に指定されたメモリ処理コールバックの呼び出しにより、メモリを解放します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-131">Calling any of the new C APIs in XSAPI that allocate or free memory will cause XSAPI to call the specified memory handling callbacks.</span></span>  
- <span data-ttu-id="28e3b-132">ゲームが終了します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-132">When the game exits:</span></span>
  - <span data-ttu-id="28e3b-133">呼び出す`XblCleanup()`XSAPI ライブラリに関連付けられているすべてのリソースを解放します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-133">Call `XblCleanup()` to reclaim all resources associated with the XSAPI library.</span></span>
  - <span data-ttu-id="28e3b-134">ゲームのカスタム メモリ マネージャーをクリーンアップします。</span><span class="sxs-lookup"><span data-stu-id="28e3b-134">Clean up your game's custom memory manager.</span></span>

### <a name="managing-asynchronous-threads"></a><span data-ttu-id="28e3b-135">非同期のスレッドを管理します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-135">Managing asynchronous threads</span></span>

<span data-ttu-id="28e3b-136">C++ API には、呼び出しパターンにより、開発者はスレッド モデルの完全な制御を新しい非同期スレッドが導入されています。</span><span class="sxs-lookup"><span data-stu-id="28e3b-136">The C API introduces a new asynchronous thread calling pattern that allows developers full control over the threading model.</span></span> <span data-ttu-id="28e3b-137">詳細については、[呼び出しパターン XSAPI フラット C レイヤーの非同期呼び出し](flatc-async-patterns.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="28e3b-137">For more information, see [Calling pattern for XSAPI flat C layer async calls](flatc-async-patterns.md).</span></span>

## <a name="migrating-code-to-use-c-xsapi"></a><span data-ttu-id="28e3b-138">C++ XSAPI を使用するコードの移行</span><span class="sxs-lookup"><span data-stu-id="28e3b-138">Migrating code to use C XSAPI</span></span>

<span data-ttu-id="28e3b-139">XSAPI C Api は、一度に 1 つの機能を移行することをお勧めしますプロジェクトでは、XSAPI の C++ Api と共に使用できます。</span><span class="sxs-lookup"><span data-stu-id="28e3b-139">The XSAPI C APIs can be used alongside the XSAPI C++ APIs in a project, so we recommend that you migrate one feature at a time.</span></span>

<span data-ttu-id="28e3b-140">C++ Api と C++ Api 同様に、さまざまなエントリ ポイントの一般的なコアの単なるシン ラッパーはであるため、機能が変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="28e3b-140">The C APIs and C++ APIs are really just thin wrappers around a common core, just with different entry points, so the functionality should be unchanged.</span></span> <span data-ttu-id="28e3b-141">ただし、C Api のみを利用カスタム メモリとスレッドの管理機能ができます。</span><span class="sxs-lookup"><span data-stu-id="28e3b-141">However, only the C APIs can take advantage of the custom memory and thread management features.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="28e3b-142">C++ Api と XSAPI WinRT Api を混在させることはできません。</span><span class="sxs-lookup"><span data-stu-id="28e3b-142">You cannot mix XSAPI WinRT APIs with the C APIs.</span></span>

## <a name="where-to-view-the-c-apis"></a><span data-ttu-id="28e3b-143">C++ Api を表示します。</span><span class="sxs-lookup"><span data-stu-id="28e3b-143">Where to view the C APIs</span></span>

- [<span data-ttu-id="28e3b-144">C++ API のヘッダー ファイル</span><span class="sxs-lookup"><span data-stu-id="28e3b-144">C API header files</span></span>](https://github.com/Microsoft/xbox-live-api/tree/master/Include/xsapi-c)
- [<span data-ttu-id="28e3b-145">新しい C++ Api を使用するサンプル コード</span><span class="sxs-lookup"><span data-stu-id="28e3b-145">Sample code using the new C APIs</span></span>](https://github.com/Microsoft/xbox-live-api/tree/master/InProgressSamples/Social/Xbox/C)
- [<span data-ttu-id="28e3b-146">libHttpClient</span><span class="sxs-lookup"><span data-stu-id="28e3b-146">libHttpClient</span></span>](https://github.com/Microsoft/libHttpClient)
