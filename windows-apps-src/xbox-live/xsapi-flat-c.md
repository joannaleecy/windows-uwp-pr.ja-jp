---
title: Xbox Live C Api
author: KevinAsgari
description: Xbox Live サービスとのやり取りに使用できるフラット C API モデルについて説明します。
ms.author: kevinasg
ms.date: 06/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox、ゲーム、uwp、windows 10, xbox one、c、xsapi
ms.localizationpriority: medium
ms.openlocfilehash: ac47d3877c44cfa9891753c49be8a5749fba9185
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5159043"
---
# <a name="introduction-to-the-xbox-live-c-apis"></a><span data-ttu-id="fe069-104">Xbox Live C Api の概要</span><span class="sxs-lookup"><span data-stu-id="fe069-104">Introduction to the Xbox Live C APIs</span></span>

<span data-ttu-id="fe069-105">2018 年 6 月の新しいフラット C API レイヤーは、XSAPI に追加されました。</span><span class="sxs-lookup"><span data-stu-id="fe069-105">In June, 2018, a new flat C API layer was added to XSAPI.</span></span> <span data-ttu-id="fe069-106">この新しい API レイヤーでは、C++ と WinRT API レイヤーで発生したいくつかの問題を解決します。</span><span class="sxs-lookup"><span data-stu-id="fe069-106">This new API layer solves some issues that occurred with the C++ and WinRT API layers.</span></span>

<span data-ttu-id="fe069-107">C++ API は、XSAPI のすべての機能をまだ対応していませんが、作業中は追加の機能です。</span><span class="sxs-lookup"><span data-stu-id="fe069-107">The C API does not yet cover all XSAPI features, but additional features are being worked on.</span></span> <span data-ttu-id="fe069-108">すべて 3 API レイヤー、C、C++ と WinRT は引き続きサポートされているし、時間の経過と共に追加機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="fe069-108">All 3 API layers, C, C++, and WinRT will continue to be supported and have additional features added over time.</span></span>

> [!NOTE]
> <span data-ttu-id="fe069-109">C++ Api は、現在のみ動作 Xbox 開発キット (XDK) を使用するタイトルにします。</span><span class="sxs-lookup"><span data-stu-id="fe069-109">The C APIs currently only work with titles that use the Xbox Developer Kit (XDK).</span></span> <span data-ttu-id="fe069-110">この時点で UWP ゲームはサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="fe069-110">They do not support UWP games at this time.</span></span>

## <a name="features-covered-by-the-c-apis"></a><span data-ttu-id="fe069-111">C++ Api で取り上げた機能</span><span class="sxs-lookup"><span data-stu-id="fe069-111">Features covered by the C APIs</span></span>

<span data-ttu-id="fe069-112">現在、C API では、次の機能とサービス サポートしています。</span><span class="sxs-lookup"><span data-stu-id="fe069-112">The C API currently supports the following features and services:</span></span>

- <span data-ttu-id="fe069-113">実績</span><span class="sxs-lookup"><span data-stu-id="fe069-113">Achievements</span></span>
- <span data-ttu-id="fe069-114">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="fe069-114">Presence</span></span>
- <span data-ttu-id="fe069-115">プロファイル</span><span class="sxs-lookup"><span data-stu-id="fe069-115">Profile</span></span>
- <span data-ttu-id="fe069-116">ソーシャル</span><span class="sxs-lookup"><span data-stu-id="fe069-116">Social</span></span>
- <span data-ttu-id="fe069-117">Social Manager</span><span class="sxs-lookup"><span data-stu-id="fe069-117">Social Manager</span></span>

## <a name="benefits-of-the-c-api-for-xsapi"></a><span data-ttu-id="fe069-118">Xsapi C API のメリット</span><span class="sxs-lookup"><span data-stu-id="fe069-118">Benefits of the C API for XSAPI</span></span>

- <span data-ttu-id="fe069-119">タイトルを XSAPI を呼び出すと、メモリ割り当てを制御できます。</span><span class="sxs-lookup"><span data-stu-id="fe069-119">Allows titles to control the memory allocations when calling XSAPI.</span></span>
- <span data-ttu-id="fe069-120">タイトル XSAPI を呼び出すときの処理スレッドの完全な制御を取得できます。</span><span class="sxs-lookup"><span data-stu-id="fe069-120">Allows titles to gain full control of thread handling when calling XSAPI.</span></span>
- <span data-ttu-id="fe069-121">新しい HTTP ライブラリ、libHttpClient、ゲーム開発者向けに設計されたを使用します。</span><span class="sxs-lookup"><span data-stu-id="fe069-121">Uses a new HTTP library, libHttpClient, designed for game developers.</span></span>

<span data-ttu-id="fe069-122">と共に C++ XSAPI C Api を使用することができますが、C++ Api を使って、上記の利点を利用するはできません。</span><span class="sxs-lookup"><span data-stu-id="fe069-122">You can use the C APIs alongside C++ XSAPI, but you will not gain the previously listed benefits with the C++ APIs.</span></span>

### <a name="managing-memory-allocations"></a><span data-ttu-id="fe069-123">メモリ割り当てを管理します。</span><span class="sxs-lookup"><span data-stu-id="fe069-123">Managing memory allocations</span></span>

<span data-ttu-id="fe069-124">新しい C++ API を使った、XSAPI がメモリを割り当てることがしようとしたときに呼び出す関数コールバックを指定できます。</span><span class="sxs-lookup"><span data-stu-id="fe069-124">With the new C API, you can now specify a function callback that XSAPI will call whenever it tries to allocate memory.</span></span> <span data-ttu-id="fe069-125">関数コールバックを指定しない場合、XSAPI は標準的なメモリ割り当てルーチンを使用します。</span><span class="sxs-lookup"><span data-stu-id="fe069-125">If you do not specify function callbacks, XSAPI will use standard memory allocation routines.</span></span>

<span data-ttu-id="fe069-126">メモリ ルーチンを手動で指定するには、次の操作を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="fe069-126">To manually specify your memory routines, you can do the following:</span></span>

- <span data-ttu-id="fe069-127">ゲームの起動時には。</span><span class="sxs-lookup"><span data-stu-id="fe069-127">At the start of the game:</span></span>
  - <span data-ttu-id="fe069-128">呼び出す`XblMemSetFunctions(memAllocFunc, memFreeFunc)`を割り当てると、メモリを解放して割り当てコールバックを指定します。</span><span class="sxs-lookup"><span data-stu-id="fe069-128">Call `XblMemSetFunctions(memAllocFunc, memFreeFunc)` to specify the allocation callbacks for assigning and releasing memory.</span></span>
  - <span data-ttu-id="fe069-129">呼び出す`XblInitialize()`ライブラリのインスタンスを初期化します。</span><span class="sxs-lookup"><span data-stu-id="fe069-129">Call `XblInitialize()` to initialize the library instance.</span></span>  
- <span data-ttu-id="fe069-130">ゲームが実行中します。</span><span class="sxs-lookup"><span data-stu-id="fe069-130">While the game is running:</span></span>
  - <span data-ttu-id="fe069-131">新しい C++ Api のいずれかの XSAPI でした呼び出しを割り当てるまたは指定されたメモリ処理コールバックの呼び出しを XSAPI により、メモリを解放します。</span><span class="sxs-lookup"><span data-stu-id="fe069-131">Calling any of the new C APIs in XSAPI that allocate or free memory will cause XSAPI to call the specified memory handling callbacks.</span></span>  
- <span data-ttu-id="fe069-132">ゲームが終了します。</span><span class="sxs-lookup"><span data-stu-id="fe069-132">When the game exits:</span></span>
  - <span data-ttu-id="fe069-133">呼び出す`XblCleanup()`XSAPI ライブラリに関連付けられているすべてのリソースを解放します。</span><span class="sxs-lookup"><span data-stu-id="fe069-133">Call `XblCleanup()` to reclaim all resources associated with the XSAPI library.</span></span>
  - <span data-ttu-id="fe069-134">ゲームのカスタム メモリ マネージャーをクリーンアップします。</span><span class="sxs-lookup"><span data-stu-id="fe069-134">Clean up your game's custom memory manager.</span></span>

### <a name="managing-asynchronous-threads"></a><span data-ttu-id="fe069-135">非同期のスレッドを管理します。</span><span class="sxs-lookup"><span data-stu-id="fe069-135">Managing asynchronous threads</span></span>

<span data-ttu-id="fe069-136">C++ API には、開発者がスレッド モデルを完全に制御できるパターンを呼び出して新しい非同期スレッドが導入されています。</span><span class="sxs-lookup"><span data-stu-id="fe069-136">The C API introduces a new asynchronous thread calling pattern that allows developers full control over the threading model.</span></span> <span data-ttu-id="fe069-137">詳細については、[呼び出しパターン XSAPI フラット C レイヤーの非同期呼び出し](flatc-async-patterns.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fe069-137">For more information, see [Calling pattern for XSAPI flat C layer async calls](flatc-async-patterns.md).</span></span>

## <a name="migrating-code-to-use-c-xsapi"></a><span data-ttu-id="fe069-138">C++ XSAPI を使用するコードの移行</span><span class="sxs-lookup"><span data-stu-id="fe069-138">Migrating code to use C XSAPI</span></span>

<span data-ttu-id="fe069-139">XSAPI C Api は、一度に 1 つの機能を移行することをお勧めしますプロジェクトでは、XSAPI の C++ Api と共に使用できます。</span><span class="sxs-lookup"><span data-stu-id="fe069-139">The XSAPI C APIs can be used alongside the XSAPI C++ APIs in a project, so we recommend that you migrate one feature at a time.</span></span>

<span data-ttu-id="fe069-140">C++ Api と C++ Api シン実際には、さまざまなエントリ ポイントでの一般的なコア ラッパーはであるため、機能が変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fe069-140">The C APIs and C++ APIs are really just thin wrappers around a common core, just with different entry points, so the functionality should be unchanged.</span></span> <span data-ttu-id="fe069-141">ただし、C Api のみを利用スレッド、カスタムのメモリの管理機能ができます。</span><span class="sxs-lookup"><span data-stu-id="fe069-141">However, only the C APIs can take advantage of the custom memory and thread management features.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="fe069-142">C++ Api と XSAPI WinRT Api を混在させることはできません。</span><span class="sxs-lookup"><span data-stu-id="fe069-142">You cannot mix XSAPI WinRT APIs with the C APIs.</span></span>

## <a name="where-to-view-the-c-apis"></a><span data-ttu-id="fe069-143">C++ Api を表示します。</span><span class="sxs-lookup"><span data-stu-id="fe069-143">Where to view the C APIs</span></span>

- [<span data-ttu-id="fe069-144">C++ API のヘッダー ファイル</span><span class="sxs-lookup"><span data-stu-id="fe069-144">C API header files</span></span>](https://github.com/Microsoft/xbox-live-api/tree/master/Include/xsapi-c)
- [<span data-ttu-id="fe069-145">新しい C++ Api を使用するサンプル コード</span><span class="sxs-lookup"><span data-stu-id="fe069-145">Sample code using the new C APIs</span></span>](https://github.com/Microsoft/xbox-live-api/tree/master/InProgressSamples/Social/Xbox/C)
- [<span data-ttu-id="fe069-146">libHttpClient</span><span class="sxs-lookup"><span data-stu-id="fe069-146">libHttpClient</span></span>](https://github.com/Microsoft/libHttpClient)
