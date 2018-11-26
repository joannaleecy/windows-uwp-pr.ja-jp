---
title: DirectX 11 の移植に関する FAQ
description: ユニバーサル Windows プラットフォーム (UWP) へのゲームの移植についてよく寄せられる質問に対してお答えします。
ms.assetid: 79c3b4c0-86eb-5019-97bb-5feee5667a2d
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 11
ms.localizationpriority: medium
ms.openlocfilehash: 31c165d47beea8ee0e31a3213bdd0dbf0c2bc3d7
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7692643"
---
# <a name="directx-11-porting-faq"></a><span data-ttu-id="6c0d4-104">DirectX 11 の移植に関する FAQ</span><span class="sxs-lookup"><span data-stu-id="6c0d4-104">DirectX 11 porting FAQ</span></span>




<span data-ttu-id="6c0d4-105">ユニバーサル Windows プラットフォーム (UWP) へのゲームの移植についてよく寄せられる質問に対してお答えします。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-105">Answers to frequently-asked questions about porting games to Universal Windows Platform (UWP).</span></span>

## <a name="is-porting-my-game-going-to-be-a-set-of-search-and-replace-operations-on-api-methods-or-do-i-need-to-plan-for-a-more-thoughtful-porting-process"></a><span data-ttu-id="6c0d4-106">ゲームの移植作業は、API メソッドを検索して置き換える作業になりますか。それとも、より慎重な移植プロセスを計画する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-106">Is porting my game going to be a set of search-and-replace operations on API methods, or do I need to plan for a more thoughtful porting process?</span></span>


<span data-ttu-id="6c0d4-107">Direct3D 11 は Direct3D 9 からの大幅なアップグレードです。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-107">Direct3D 11 is a significant upgrade from Direct3D 9.</span></span> <span data-ttu-id="6c0d4-108">仮想化されたグラフィックス アダプターとそのコンテキストのための独立した API や、デバイス リソースのポリモーフィズムの新しいレイヤーなど、いくつかのパラダイム シフトがあります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-108">There are several paradigm shifts, including separate APIs for the virtualized graphics adapter and its context as well as a new layer of polymorphism for device resources.</span></span> <span data-ttu-id="6c0d4-109">ゲームでは、グラフィックス ハードウェアを実質的に同じ方法で使い続けることができますが、新しい Direct3D 11 API のアーキテクチャについて学び、正しい API コンポーネントが使われるようにグラフィックス コードの各部分を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-109">Your game can still use graphics hardware in essentially the same way, but you'll need to learn about the new Direct3D 11 API architecture and update each part of your graphics code to use the correct API components.</span></span> <span data-ttu-id="6c0d4-110">「[DirectX 9 からの DirectX 11 と Windows ストアへの移行](porting-considerations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-110">See [Porting concepts and considerations](porting-considerations.md).</span></span>

## <a name="what-is-the-new-device-context-for-am-i-supposed-to-replace-my-direct3d-9-device-with-the-direct3d-11-device-the-device-context-or-both"></a><span data-ttu-id="6c0d4-111">新しいデバイス コンテキストの用途は何ですか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-111">What is the new device context for?</span></span> <span data-ttu-id="6c0d4-112">自分の Direct3D 9 デバイスを Direct3D 11 デバイスに置き換えたり、Direct3D 9 デバイス コンテキストを Direct3D 11 デバイス コンテキストに置き換えたりする必要はありますか。その両方が必要でしょうか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-112">Am I supposed to replace my Direct3D 9 device with the Direct3D 11 device, the device context, or both?</span></span>


<span data-ttu-id="6c0d4-113">Direct3D デバイスは、ビデオ メモリにリソースを作成するために使われます。一方、デバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-113">The Direct3D device is now used to create resources in video memory, while the device context is used to set pipeline state and generate rendering commands.</span></span> <span data-ttu-id="6c0d4-114">詳しくは、「[Direct3D 9 と Direct3D 11 の間の重要な変更点](understand-direct3d-11-1-concepts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-114">For more info see: [What are the most important changes since Direct3D 9?](understand-direct3d-11-1-concepts.md)</span></span>

##  <a name="do-i-have-to-update-my-game-timer-for-uwp"></a><span data-ttu-id="6c0d4-115">UWP 向けのゲーム タイマーを更新する必要はありますか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-115">Do I have to update my game timer for UWP?</span></span>


<span data-ttu-id="6c0d4-116">[**QueryPerformanceCounter**](https://msdn.microsoft.com/library/windows/desktop/ms644904) と [**QueryPerformanceFrequency**](https://msdn.microsoft.com/library/windows/desktop/ms644905) は、引き続き UWP アプリのゲーム タイマーを実装する最適な手段です。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-116">[**QueryPerformanceCounter**](https://msdn.microsoft.com/library/windows/desktop/ms644904), along with [**QueryPerformanceFrequency**](https://msdn.microsoft.com/library/windows/desktop/ms644905), is still the best way to implement a game timer for UWP apps.</span></span>

<span data-ttu-id="6c0d4-117">タイマーと UWP アプリのライフサイクルのニュアンスに注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-117">You should be aware of a nuance with timers and the UWP app lifecycle.</span></span> <span data-ttu-id="6c0d4-118">中断と再開は、プレーヤーによるデスクトップ ゲームの再起動とは異なります。ゲームでは、最後にプレイされていた時点のスナップショットを再開します。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-118">Suspend/resume is different from a player re-launching a desktop game because your game will resume a snapshot in time from when the game was last played.</span></span> <span data-ttu-id="6c0d4-119">数週間など、長時間経過した場合は、ゲーム タイマーの実装は適切に動作しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-119">If a large amount of time has passed - for example, a few weeks - some game timer implementations might not behave gracefully.</span></span> <span data-ttu-id="6c0d4-120">ゲームの再開時にアプリのライフサイクル イベントを使ってタイマーをリセットできます。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-120">You can use app lifecycle events to reset your timer when the game resumes.</span></span>

<span data-ttu-id="6c0d4-121">まだ RDTSC 命令を使っているゲームはアップグレードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-121">Games that still use the RDTSC instruction need to upgrade.</span></span> <span data-ttu-id="6c0d4-122">「[ゲームのタイミングとマルチコア プロセッサ](https://msdn.microsoft.com/library/windows/desktop/ee417693)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-122">See [Game Timing and Multicore Processors](https://msdn.microsoft.com/library/windows/desktop/ee417693).</span></span>

## <a name="my-game-code-is-based-on-d3dx-and-dxut-is-there-anything-available-that-can-help-me-migrate-my-code"></a><span data-ttu-id="6c0d4-123">自分のゲーム コードは D3DX と DXUT に基づいています。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-123">My game code is based on D3DX and DXUT.</span></span> <span data-ttu-id="6c0d4-124">コードの移植に役立つものはありますか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-124">Is there anything available that can help me migrate my code?</span></span>


<span data-ttu-id="6c0d4-125">[DirectX ツール キット (DirectXTK)](http://go.microsoft.com/fwlink/p/?LinkID=248929) コミュニティのプロジェクトには、Direct3D 11 で利用できるヘルパー クラスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-125">The [DirectX Tool Kit (DirectXTK)](http://go.microsoft.com/fwlink/p/?LinkID=248929) community project offers helper classes for use with Direct3D 11.</span></span>

##  <a name="how-do-i-maintain-code-paths-for-the-desktop-and-the-microsoft-store"></a><span data-ttu-id="6c0d4-126">デスクトップと Microsoft Store のコード パスを維持する方法</span><span class="sxs-lookup"><span data-stu-id="6c0d4-126">How do I maintain code paths for the desktop and the Microsoft Store?</span></span>


<span data-ttu-id="6c0d4-127">Chuck Walbourn 記事シリーズで[ゲームの二重用途のコーディング手法](http://go.microsoft.com/fwlink/p/?LinkID=286210)では、デスクトップと Microsoft ストア コード パスの間でコードを共有に関するガイダンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-127">Chuck Walbourn's article series titled [Dual-use Coding Techniques for Games](http://go.microsoft.com/fwlink/p/?LinkID=286210) offers guidance on sharing code between the desktop and the Microsoft Store code paths.</span></span>

##  <a name="how-do-i-load-image-resources-in-my-directx-uwp-app"></a><span data-ttu-id="6c0d4-128">DirectX UWP アプリの画像リソースを読み込む方法を教えてください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-128">How do I load image resources in my DirectX UWP app?</span></span>


<span data-ttu-id="6c0d4-129">画像を読み込むための API パスは 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-129">There are two API paths for loading images:</span></span>

-   <span data-ttu-id="6c0d4-130">コンテンツ パイプラインは Direct3D のテクスチャ リソースとして使われる DDS ファイルに画像を変換します。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-130">The content pipeline converts images into DDS files used as Direct3D texture resources.</span></span> <span data-ttu-id="6c0d4-131">「[ゲームまたはアプリケーションでの 3-D アセットの使用](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-131">See [Using 3-D Assets in Your Game or App](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx).</span></span>
-   <span data-ttu-id="6c0d4-132">[Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902) を使うと、さまざまな形式から画像を読み込むことができます。このコンポーネントは、Direct2D ビットマップや、Direct3D のテクスチャ リソースに使用できます。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-132">The [Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902) can be used to load images from a variety of formats, and can be used for Direct2D bitmaps as well as Direct3D texture resources.</span></span>

<span data-ttu-id="6c0d4-133">[DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) または [DirectXTex](http://go.microsoft.com/fwlink/p/?LinkID=248926) の DDSTextureLoader と WICTextureLoader を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-133">You can also use the DDSTextureLoader, and the WICTextureLoader, from the [DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) or [DirectXTex](http://go.microsoft.com/fwlink/p/?LinkID=248926).</span></span>

## <a name="where-is-the-directx-sdk"></a><span data-ttu-id="6c0d4-134">DirectX SDK の場所</span><span class="sxs-lookup"><span data-stu-id="6c0d4-134">Where is the DirectX SDK?</span></span>


<span data-ttu-id="6c0d4-135">DirectX SDK は Windows SDK に同梱されています。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-135">The DirectX SDK is included as part of the Windows SDK.</span></span> <span data-ttu-id="6c0d4-136">Windows SDK に同梱されていない最新の DirectX SDK は、2010 年 6 月のものです。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-136">The most recent DirectX SDK that was separate from the Windows SDK was in June 2010.</span></span> <span data-ttu-id="6c0d4-137">Direct3D サンプルは、他の Windows アプリ サンプルと共にコード ギャラリーにあります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-137">Direct3D samples are in the Code Gallery along with the rest of the Windows app samples.</span></span>

## <a name="what-about-directx-redistributables"></a><span data-ttu-id="6c0d4-138">DirectX の再頒布可能パッケージについて教えてください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-138">What about DirectX redistributables?</span></span>


<span data-ttu-id="6c0d4-139">Windows SDK の大半のコンポーネントは、サポートされているバージョンの OS に含まれていますが、DLL コンポーネントは含まれていません (DirectXMath など)。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-139">The vast majority of components in the Windows SDK are already included in supported versions of the OS, or have no DLL component (such as DirectXMath).</span></span> <span data-ttu-id="6c0d4-140">UWP アプリで使うことができるすべての Direct3D API コンポーネントは、ゲームで既に使用できる状態です。再頒布する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-140">All Direct3D API components that UWP apps can use will already available to your game; you don't need to be redistribute them.</span></span>

<span data-ttu-id="6c0d4-141">Win32 デスクトップ アプリケーションは引き続き DirectSetup を使います。そのため、ゲームのデスクトップ バージョンをアップグレードする場合は、「[ゲーム開発者向けの Direct3D 11 の展開](https://msdn.microsoft.com/library/windows/desktop/ee416644)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-141">Win32 desktop applications still use DirectSetup, so if you are also upgrading the desktop version of your game see [Direct3D 11 Deployment for Game Developers](https://msdn.microsoft.com/library/windows/desktop/ee416644).</span></span>

## <a name="is-there-any-way-i-can-update-my-desktop-code-to-directx-11-before-moving-away-from-effects"></a><span data-ttu-id="6c0d4-142">Effects から離れる前にデスクトップ コードを DirectX 11 に更新する方法はありますか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-142">Is there any way I can update my desktop code to DirectX 11 before moving away from Effects?</span></span>


<span data-ttu-id="6c0d4-143">[Direct3D 11 向けの Effects の更新に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=271568)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-143">See the [Effects for Direct3D 11 Update](http://go.microsoft.com/fwlink/p/?LinkId=271568).</span></span> <span data-ttu-id="6c0d4-144">Effects 11 は、レガシ DirectX SDK ヘッダーへの依存を排除します。移植のサポート用に作成されたものであり、デスクトップ アプリでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-144">Effects 11 helps remove dependencies on legacy DirectX SDK headers; it's intended for use as a porting aid and can only be used with desktop apps.</span></span>

##  <a name="is-there-a-path-for-porting-my-directx-8-game-to-uwp"></a><span data-ttu-id="6c0d4-145">UWP に DirectX 8 ゲームを移植するためのパスはありますか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-145">Is there a path for porting my DirectX 8 game to UWP?</span></span>


<span data-ttu-id="6c0d4-146">はい、あります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-146">Yes:</span></span>

-   <span data-ttu-id="6c0d4-147">「[Direct3D 9 への変換](https://msdn.microsoft.com/library/windows/desktop/bb204851)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-147">Read [Converting to Direct3D 9](https://msdn.microsoft.com/library/windows/desktop/bb204851).</span></span>
-   <span data-ttu-id="6c0d4-148">ゲームに固定パイプラインが残っていないことを確かめます。「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-148">Make sure your game has no remnants of the fixed pipeline - see [Deprecated Features](https://msdn.microsoft.com/library/windows/desktop/cc308047).</span></span>
-   <span data-ttu-id="6c0d4-149">次に、DirectX 9 移植パスに従います。「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-149">Then take the DirectX 9 porting path: [Port from D3D 9 to UWP](walkthrough--simple-port-from-direct3d-9-to-11-1.md).</span></span>

##  <a name="can-i-port-my-directx-10-or-11-game-to-uwp"></a><span data-ttu-id="6c0d4-150">UWP に DirectX 10 または 11 ゲームを移植することはできますか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-150">Can I port my DirectX 10 or 11 game to UWP?</span></span>


<span data-ttu-id="6c0d4-151">DirectX 10.x と 11 のデスクトップ ゲームは、UWP に簡単に移植できます。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-151">DirectX 10.x and 11 desktop games are easy to port to UWP.</span></span> <span data-ttu-id="6c0d4-152">「[Direct3D 11 への移行](https://msdn.microsoft.com/library/windows/desktop/ff476190)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-152">See [Migrating to Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476190).</span></span>

## <a name="how-do-i-choose-the-right-display-device-in-a-multi-monitor-system"></a><span data-ttu-id="6c0d4-153">マルチモニター システムで適切なディスプレイ デバイスを選ぶにはどうすればよいですか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-153">How do I choose the right display device in a multi-monitor system?</span></span>


<span data-ttu-id="6c0d4-154">アプリを表示するモニターはユーザーが選びます。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-154">The user selects which monitor your app is displayed on.</span></span> <span data-ttu-id="6c0d4-155">最初のパラメーターを **nullptr** に設定して [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出すことで、Windows が正しいアダプターを提供できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-155">Let Windows provide the correct adapter by calling [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) with the first parameter set to **nullptr**.</span></span> <span data-ttu-id="6c0d4-156">次にデバイスの [**IDXGIDevice interface**](https://msdn.microsoft.com/library/windows/desktop/bb174527) を取得し、[**GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) を呼び出して、DXGI アダプターを使ってスワップ チェーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-156">Then get the device's [**IDXGIDevice interface**](https://msdn.microsoft.com/library/windows/desktop/bb174527), call [**GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) and use the DXGI adapter to create the swap chain.</span></span>

## <a name="how-do-i-turn-on-antialiasing"></a><span data-ttu-id="6c0d4-157">アンチエイリアシングをオンにするにはどうすればよいですか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-157">How do I turn on antialiasing?</span></span>


<span data-ttu-id="6c0d4-158">Direct3D デバイスを作成するとアンチエイリアシング (マルチサンプリング) が有効になります。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-158">Antialiasing (multisampling) is enabled when you create the Direct3D device.</span></span> <span data-ttu-id="6c0d4-159">[**CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499) を呼び出してマルチサンプリングのサポートを列挙し、[**CreateSurface**](https://msdn.microsoft.com/library/windows/desktop/bb174530) を呼び出すときに [**DXGI\_SAMPLE\_DESC structure**](https://msdn.microsoft.com/library/windows/desktop/bb173072) でマルチサンプリングのオプションを設定します。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-159">Enumerate multisampling support by calling [**CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499), then set multisample options in the [**DXGI\_SAMPLE\_DESC structure**](https://msdn.microsoft.com/library/windows/desktop/bb173072) when you call [**CreateSurface**](https://msdn.microsoft.com/library/windows/desktop/bb174530).</span></span>

## <a name="my-game-renders-using-multithreading-andor-deferred-rendering-what-do-i-need-to-know-for-direct3d-11"></a><span data-ttu-id="6c0d4-160">自分のゲームでは、マルチスレッドや遅延レンダリングを使ってレンダリングを行います。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-160">My game renders using multithreading and/or deferred rendering.</span></span> <span data-ttu-id="6c0d4-161">Direct3D 11 向けに何を把握しておく必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-161">What do I need to know for Direct3D 11?</span></span>


<span data-ttu-id="6c0d4-162">まず、「[Direct3D 11 でのマルチスレッドの概要](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-162">Visit [Introduction to Multithreading in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476891) to get started.</span></span> <span data-ttu-id="6c0d4-163">主な違いの一覧については、「[Direct3D のバージョン間におけるスレッドの違い](https://msdn.microsoft.com/library/windows/desktop/ff476890)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-163">For a list of key differences, see [Threading Differences between Direct3D Versions](https://msdn.microsoft.com/library/windows/desktop/ff476890).</span></span> <span data-ttu-id="6c0d4-164">遅延レンダリングでは*イミディエイト コンテキスト*ではなくデバイスの*遅延コンテキスト*が使われることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-164">Note that deferred rendering uses a device *deferred context* instead of an *immediate context*.</span></span>

## <a name="where-can-i-read-more-about-the-programmable-pipeline-since-direct3d-9"></a><span data-ttu-id="6c0d4-165">Direct3D 9 以降のプログラム可能なパイプラインに関する詳しい情報はどこにありますか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-165">Where can I read more about the programmable pipeline since Direct3D 9?</span></span>


<span data-ttu-id="6c0d4-166">次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-166">Visit the following topics:</span></span>

-   [<span data-ttu-id="6c0d4-167">HLSL 用プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="6c0d4-167">Programming Guide for HLSL</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb509635)
-   [<span data-ttu-id="6c0d4-168">Direct3D 10 のよく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="6c0d4-168">Direct3D 10 Frequently Asked Questions</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee416643)

## <a name="what-should-i-use-instead-of-the-x-file-format-for-my-models"></a><span data-ttu-id="6c0d4-169">モデルには .x ファイル形式の代わりに何を使えばよいですか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-169">What should I use instead of the .x file format for my models?</span></span>


<span data-ttu-id="6c0d4-170">.x ファイル形式に代わる公式のファイル形式はありませんが、サンプルの多くで SDKMesh 形式を利用しています。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-170">While we don’t have an official replacement for the .x file format, many of the samples utilize the SDKMesh format.</span></span> <span data-ttu-id="6c0d4-171">Visual Studio には、一般的な形式を CMO ファイルにコンパイルする[コンテンツ パイプライン](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)があります。CMO ファイルは、Visual Studio 3D スターター キットのコードか、[DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) を使って読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-171">Visual Studio also has a [content pipeline](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx) that compiles several popular formats into CMO files that can be loaded with code from the Visual Studio 3D starter kit, or loaded using the [DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929).</span></span>

## <a name="how-do-i-debug-my-shaders"></a><span data-ttu-id="6c0d4-172">シェーダーをデバッグするにはどうしたらよいですか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-172">How do I debug my shaders?</span></span>


<span data-ttu-id="6c0d4-173">Microsoft Visual Studio2015 には、DirectX グラフィックスの診断ツールが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-173">Microsoft Visual Studio2015 includes diagnostic tools for DirectX graphics.</span></span> <span data-ttu-id="6c0d4-174">「[DirectX グラフィックスのデバッグ](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-174">See [Debugging DirectX Graphics](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx).</span></span>

##  <a name="what-is-the-direct3d-11-equivalent-for-x-function"></a><span data-ttu-id="6c0d4-175">*x* 関数に相当する Direct3D 11 の要素は何ですか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-175">What is the Direct3D 11 equivalent for *x* function?</span></span>


<span data-ttu-id="6c0d4-176">「DirectX 11 API への DirectX 9 の機能のマッピング」の「[関数のマッピング](feature-mapping.md#function-mapping)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-176">See the [function mapping](feature-mapping.md#function-mapping) provided in Map DirectX 9 features to DirectX 11 APIs.</span></span>

##  <a name="what-is-the-dxgiformat-equivalent-of-y-surface-format"></a><span data-ttu-id="6c0d4-177">*y* サーフェス形式に相当する DXGI_FORMAT の要素は何ですか。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-177">What is the DXGI\_FORMAT equivalent of *y* surface format?</span></span>


<span data-ttu-id="6c0d4-178">「DirectX 11 API への DirectX 9 の機能のマッピング」の「[サーフェス形式のマッピング](feature-mapping.md#surface-format-mapping)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6c0d4-178">See the [surface format mapping](feature-mapping.md#surface-format-mapping) provided in Map DirectX 9 features to DirectX 11 APIs.</span></span>

 

 




