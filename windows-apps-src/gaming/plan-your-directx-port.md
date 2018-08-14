---
author: mtoepke
title: DirectX の移植の計画
description: DirectX 9 から DirectX 11 とユニバーサル Windows プラットフォーム (UWP) へのゲーム移植プロジェクトを計画してください。グラフィックス コードのアップグレードと、Windows ランタイム環境へのゲームの配置が必要です。
ms.assetid: 3c0c33ca-5d15-ae12-33f8-9b5d8da08155
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, DirectX, 移植
ms.openlocfilehash: e255bceae44ace0722a2df0c53d60ec0f8fa35fe
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243179"
---
# <a name="plan-your-directx-port"></a><span data-ttu-id="f0b28-104">DirectX の移植の計画</span><span class="sxs-lookup"><span data-stu-id="f0b28-104">Plan your DirectX port</span></span>


<span data-ttu-id="f0b28-105">\[ Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="f0b28-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="f0b28-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="f0b28-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

**<span data-ttu-id="f0b28-107">要約</span><span class="sxs-lookup"><span data-stu-id="f0b28-107">Summary</span></span>**

-   <span data-ttu-id="f0b28-108">DirectX の移植の計画</span><span class="sxs-lookup"><span data-stu-id="f0b28-108">Plan your DirectX port</span></span>
-   [<span data-ttu-id="f0b28-109">Direct3D 9 と Direct3D 11 の間の重要な変更点</span><span class="sxs-lookup"><span data-stu-id="f0b28-109">Important changes from Direct3D 9 to Direct3D 11</span></span>](understand-direct3d-11-1-concepts.md)
-   [<span data-ttu-id="f0b28-110">機能のマッピング</span><span class="sxs-lookup"><span data-stu-id="f0b28-110">Feature mapping</span></span>](feature-mapping.md)


<span data-ttu-id="f0b28-111">DirectX 9 から DirectX 11 とユニバーサル Windows プラットフォーム (UWP) へのゲーム移植プロジェクトを計画してください。グラフィックス コードのアップグレードと、Windows ランタイム環境へのゲームの配置が必要です。</span><span class="sxs-lookup"><span data-stu-id="f0b28-111">Plan your game porting project from DirectX 9 to DirectX 11 and Universal Windows Platform (UWP): upgrade your graphics code, and put your game in the Windows Runtime environment.</span></span>

## <a name="plan-to-port-graphics-code"></a><span data-ttu-id="f0b28-112">グラフィックス コードの移植の計画</span><span class="sxs-lookup"><span data-stu-id="f0b28-112">Plan to port graphics code</span></span>


<span data-ttu-id="f0b28-113">UWP へのゲームの移植を開始する前に、ゲームに Direct3D 8 の要素が残っていない状態にすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="f0b28-113">Before you begin porting your game to UWP, it's important to ensure that your game does not have any holdovers from Direct3D 8.</span></span> <span data-ttu-id="f0b28-114">ゲームに固定関数パイプラインが残っていないことを確かめてください。</span><span class="sxs-lookup"><span data-stu-id="f0b28-114">Ensure that your game doesn't have any remnants of the fixed function pipeline.</span></span> <span data-ttu-id="f0b28-115">固定パイプライン機能など、推奨されなくなった機能の全一覧については、「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f0b28-115">For a complete list of deprecated features, including fixed pipeline functionality, see [Deprecated Features](https://msdn.microsoft.com/library/windows/desktop/cc308047).</span></span>

<span data-ttu-id="f0b28-116">Direct3D 9 から Direct3D 11 へのアップグレードは、変更箇所を探して置き換える作業にとどまりません。</span><span class="sxs-lookup"><span data-stu-id="f0b28-116">Upgrading from Direct3D 9 to Direct3D 11 is more than a search-and-replace change.</span></span> <span data-ttu-id="f0b28-117">Direct3D デバイス、デバイス コンテキスト、グラフィックス インフラストラクチャの違いを把握し、Direct3D 9 以降のその他の重要な変更について理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-117">You need to know the difference between the Direct3D device, device context, and graphics infrastructure, and learn about other important changes since Direct3D 9.</span></span> <span data-ttu-id="f0b28-118">このセクションの他のトピックを読むことで、このプロセスを開始できます。</span><span class="sxs-lookup"><span data-stu-id="f0b28-118">You can start this process by reading the other topics in this section.</span></span>

<span data-ttu-id="f0b28-119">D3DX と DXUT のヘルパー ライブラリは、独自のヘルパー ライブラリか、コミュニティ ツールに置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-119">You must replace the D3DX and DXUT helper libraries with your own helper libraries, or with community tools.</span></span> <span data-ttu-id="f0b28-120">詳しくは、「[DirectX 11 API への DirectX 9 の機能のマッピング](feature-mapping.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f0b28-120">See the [Feature mapping](feature-mapping.md) section for more info.</span></span>

> <span data-ttu-id="f0b28-121">**注:** [DirectX Tool Kit](http://go.microsoft.com/fwlink/p/?LinkID=248929) または [DirectXTex](http://go.microsoft.com/fwlink/p/?LinkID=248926) を使うと、D3DX と DXUT で実現されていた機能の一部を置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="f0b28-121">**Note**   You can use the [DirectX Tool Kit](http://go.microsoft.com/fwlink/p/?LinkID=248929) or [DirectXTex](http://go.microsoft.com/fwlink/p/?LinkID=248926) to replace some functionality that was formerly provided by D3DX and DXUT.</span></span>

 

<span data-ttu-id="f0b28-122">アセンブリ言語で記述されたシェーダーは、シェーダー モデル 4 レベル 9\_1 または 9\_3 の機能を使って HLSL にアップグレードする必要があります。また、Effects ライブラリ向けに記述されたシェーダーは、より新しいバージョンの HLSL 構文に更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-122">Shaders written in assembly language should be upgraded to HLSL using shader model 4 level 9\_1 or 9\_3 functionality, and shaders written for the Effects library will need to be updated to a more recent version of HLSL syntax.</span></span> <span data-ttu-id="f0b28-123">詳しくは、「[DirectX 11 API への DirectX 9 の機能のマッピング](feature-mapping.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f0b28-123">See the [Feature mapping](feature-mapping.md) section for more info.</span></span>

<span data-ttu-id="f0b28-124">さまざまな [Direct3D 機能レベル](https://msdn.microsoft.com/library/windows/desktop/ff476876)について確かめてください。</span><span class="sxs-lookup"><span data-stu-id="f0b28-124">Get familiar with the different [Direct3D feature levels](https://msdn.microsoft.com/library/windows/desktop/ff476876).</span></span> <span data-ttu-id="f0b28-125">機能レベルは、既知の機能のセットを定義することで、幅広いビデオ ハードウェアを分類するものです。</span><span class="sxs-lookup"><span data-stu-id="f0b28-125">Feature levels classify a wide range of video hardware by defining sets of known functionality.</span></span> <span data-ttu-id="f0b28-126">各セットは 9.1 ～ 11.2 のバージョンの Direct3D にほぼ対応しています。</span><span class="sxs-lookup"><span data-stu-id="f0b28-126">Each set roughly corresponds to versions of Direct3D, from 9.1 through 11.2.</span></span> <span data-ttu-id="f0b28-127">すべての機能レベルで DirectX 11 API を使います。</span><span class="sxs-lookup"><span data-stu-id="f0b28-127">All feature levels use the DirectX 11 API.</span></span>

## <a name="plan-to-port-win32-ui-code-to-corewindow"></a><span data-ttu-id="f0b28-128">CoreWindow への Win32 UI コードの移植の計画</span><span class="sxs-lookup"><span data-stu-id="f0b28-128">Plan to port Win32 UI code to CoreWindow</span></span>


<span data-ttu-id="f0b28-129">UWP アプリは、[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) と呼ばれる、アプリ コンテナーに対して作成されるウィンドウで実行されます。</span><span class="sxs-lookup"><span data-stu-id="f0b28-129">UWP apps run in a window created for an app container, called a [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225).</span></span> <span data-ttu-id="f0b28-130">ゲームでは、デスクトップのウィンドウよりも必要な実装の詳細が少ない [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) からの継承によってウィンドウを制御します。</span><span class="sxs-lookup"><span data-stu-id="f0b28-130">Your game controls the window by inheriting from [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478), which requires less implementation details than a desktop window.</span></span> <span data-ttu-id="f0b28-131">ゲームのメイン ループは [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドにあります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-131">Your game's main loop will be in the [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) method.</span></span>

<span data-ttu-id="f0b28-132">UWP アプリのライフサイクルはデスクトップ アプリとは大きく異なります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-132">The lifecycle of a UWP app is very different from a desktop app.</span></span> <span data-ttu-id="f0b28-133">ゲームの保存は頻繁に行う必要があります。中断イベントが発生したときに、アプリで実行中のコードを停止できる時間が限られているうえ、アプリの再開時には、プレーヤーが中断時の状態からすぐにゲームを再開できるようにする必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="f0b28-133">You'll need to save the game often, because when a suspend event happens your app only has a limited amount of time to stop running code, and you want to make sure the player can get back to where they were right away when your app resumes.</span></span> <span data-ttu-id="f0b28-134">ゲームの保存は、再開時に連続したゲームプレイ エクスペリエンスを維持できるだけの頻度で行う必要があります。ただし、フレームレートに影響したり、ゲームに引っかかりをもたらしたりしない程度にしてください。</span><span class="sxs-lookup"><span data-stu-id="f0b28-134">Games should save just often enough to maintain a continuous gameplay experience from resume, but not so often that the game saves impact framerate or cause the game to stutter.</span></span> <span data-ttu-id="f0b28-135">ゲームは、ゲームが終了状態から再開されたときに、必要に応じてゲームの状態を読み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-135">Your game will potentially need to load game state when the game resumes from a terminated state.</span></span>

<span data-ttu-id="f0b28-136">[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/ee415571) は、D3DXMath と XNAMath の代わりになり、数学演算ライブラリが必要になったときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="f0b28-136">[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/ee415571) can be used as a replacement for D3DXMath and XNAMath, and it can come in handy if you need a math library.</span></span> <span data-ttu-id="f0b28-137">DirectXMath には、高速かつ移植可能なデータ型と、シェーダーで利用できるように整列およびパッキングされた型があります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-137">DirectXMath has fast, portable data types, and types that are aligned and packed for use with shaders.</span></span>

<span data-ttu-id="f0b28-138">[インタロック API](https://msdn.microsoft.com/library/windows/desktop/dd405529) などのネイティブ ライブラリは、ARM の組み込みメソッドをサポートするために拡張されました。</span><span class="sxs-lookup"><span data-stu-id="f0b28-138">Native libraries such as the [Interlocked API](https://msdn.microsoft.com/library/windows/desktop/dd405529) have been expanded to support ARM intrinsics.</span></span> <span data-ttu-id="f0b28-139">ゲームでインタロック API を使う場合は、DirectX 11 と UWP でも使い続けることができます。</span><span class="sxs-lookup"><span data-stu-id="f0b28-139">If your game uses interlocked APIs, you can keep using them in DirectX 11 and UWP.</span></span>

<span data-ttu-id="f0b28-140">Microsoft のテンプレートとコード サンプルでは新しい C++ 機能が使われており、馴染みがない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-140">Our templates and code samples use new C++ features that you might not be familiar with yet.</span></span> <span data-ttu-id="f0b28-141">たとえば、UI スレッドをブロックすることなく Direct3D リソースを読み込むために、非同期メソッドが[**ラムダ式**](https://msdn.microsoft.com/library/windows/apps/dd293608.aspx)と共に使われます。</span><span class="sxs-lookup"><span data-stu-id="f0b28-141">For example, asynchronous methods are used with [**lambda expressions**](https://msdn.microsoft.com/library/windows/apps/dd293608.aspx) to load Direct3D resources without blocking the UI thread.</span></span>

<span data-ttu-id="f0b28-142">頻繁に使う 2 つの概念があります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-142">There are two concepts you'll use often:</span></span>

-   <span data-ttu-id="f0b28-143">マネージ リファレンス ([**^ 演算子**](https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspx)) と [**マネージ クラス**](https://msdn.microsoft.com/library/windows/apps/6w96b5h7.aspx) (ref クラス) は、Windows ランタイムの基本となる部分です。</span><span class="sxs-lookup"><span data-stu-id="f0b28-143">Managed references ([**^ operator**](https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspx)) and [**managed classes**](https://msdn.microsoft.com/library/windows/apps/6w96b5h7.aspx) (ref classes) are a fundamental part of the Windows Runtime.</span></span> <span data-ttu-id="f0b28-144">Windows ランタイム コンポーネントとのインターフェイスとして機能するマネージ ref クラスを使う必要があります。具体的には、[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) などです。詳しくはチュートリアルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f0b28-144">You will need to use managed ref classes to interface with Windows Runtime components, for example [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) (more on that in the walkthrough).</span></span>
-   <span data-ttu-id="f0b28-145">Direct3D 11 の COM インターフェイスを操作する場合は、[**Microsoft::WRL::ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) テンプレート型を使うと COM ポインターが使いやすくなります。</span><span class="sxs-lookup"><span data-stu-id="f0b28-145">When working with Direct3D 11 COM interfaces, use the [**Microsoft::WRL::ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) template type to make COM pointers easier to use.</span></span>

 

 




