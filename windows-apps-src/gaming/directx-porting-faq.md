---
author: mtoepke
title: DirectX 11 の移植に関する FAQ
description: ユニバーサル Windows プラットフォーム (UWP) へのゲームの移植についてよく寄せられる質問に対してお答えします。
ms.assetid: 79c3b4c0-86eb-5019-97bb-5feee5667a2d
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, DirectX 11
ms.openlocfilehash: 7dda21925e31785e0ce7c3dfc72ba173b8686743
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243297"
---
# <a name="directx-11-porting-faq"></a><span data-ttu-id="0f3a9-104">DirectX 11 の移植に関する FAQ</span><span class="sxs-lookup"><span data-stu-id="0f3a9-104">DirectX 11 porting FAQ</span></span>


<span data-ttu-id="0f3a9-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="0f3a9-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="0f3a9-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="0f3a9-107">ユニバーサル Windows プラットフォーム (UWP) へのゲームの移植についてよく寄せられる質問に対してお答えします。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-107">Answers to frequently-asked questions about porting games to Universal Windows Platform (UWP).</span></span>

## <a name="is-porting-my-game-going-to-be-a-set-of-search-and-replace-operations-on-api-methods-or-do-i-need-to-plan-for-a-more-thoughtful-porting-process"></a><span data-ttu-id="0f3a9-108">ゲームの移植作業は、API メソッドを検索して置き換える作業になりますか。それとも、より慎重な移植プロセスを計画する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-108">Is porting my game going to be a set of search-and-replace operations on API methods, or do I need to plan for a more thoughtful porting process?</span></span>


<span data-ttu-id="0f3a9-109">Direct3D 11 は Direct3D 9 からの大幅なアップグレードです。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-109">Direct3D 11 is a significant upgrade from Direct3D 9.</span></span> <span data-ttu-id="0f3a9-110">仮想化されたグラフィックス アダプターとそのコンテキストのための独立した API や、デバイス リソースのポリモーフィズムの新しいレイヤーなど、いくつかのパラダイム シフトがあります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-110">There are several paradigm shifts, including separate APIs for the virtualized graphics adapter and its context as well as a new layer of polymorphism for device resources.</span></span> <span data-ttu-id="0f3a9-111">ゲームでは、グラフィックス ハードウェアを実質的に同じ方法で使い続けることができますが、新しい Direct3D 11 API のアーキテクチャについて学び、正しい API コンポーネントが使われるようにグラフィックス コードの各部分を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-111">Your game can still use graphics hardware in essentially the same way, but you'll need to learn about the new Direct3D 11 API architecture and update each part of your graphics code to use the correct API components.</span></span> <span data-ttu-id="0f3a9-112">「[DirectX 9 からの DirectX 11 と Windows ストアへの移行](porting-considerations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-112">See [Porting concepts and considerations](porting-considerations.md).</span></span>

## <a name="what-is-the-new-device-context-for-am-i-supposed-to-replace-my-direct3d-9-device-with-the-direct3d-11-device-the-device-context-or-both"></a><span data-ttu-id="0f3a9-113">新しいデバイス コンテキストの用途は何ですか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-113">What is the new device context for?</span></span> <span data-ttu-id="0f3a9-114">自分の Direct3D 9 デバイスを Direct3D 11 デバイスに置き換えたり、Direct3D 9 デバイス コンテキストを Direct3D 11 デバイス コンテキストに置き換えたりする必要はありますか。その両方が必要でしょうか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-114">Am I supposed to replace my Direct3D 9 device with the Direct3D 11 device, the device context, or both?</span></span>


<span data-ttu-id="0f3a9-115">Direct3D デバイスは、ビデオ メモリにリソースを作成するために使われます。一方、デバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-115">The Direct3D device is now used to create resources in video memory, while the device context is used to set pipeline state and generate rendering commands.</span></span> <span data-ttu-id="0f3a9-116">詳しくは、「[Direct3D 9 と Direct3D 11 の間の重要な変更点](understand-direct3d-11-1-concepts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-116">For more info see: [What are the most important changes since Direct3D 9?](understand-direct3d-11-1-concepts.md)</span></span>

##  <a name="do-i-have-to-update-my-game-timer-for-uwp"></a><span data-ttu-id="0f3a9-117">UWP 向けのゲーム タイマーを更新する必要はありますか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-117">Do I have to update my game timer for UWP?</span></span>


<span data-ttu-id="0f3a9-118">[**QueryPerformanceCounter**](https://msdn.microsoft.com/library/windows/desktop/ms644904) と [**QueryPerformanceFrequency**](https://msdn.microsoft.com/library/windows/desktop/ms644905) は、引き続き UWP アプリのゲーム タイマーを実装する最適な手段です。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-118">[**QueryPerformanceCounter**](https://msdn.microsoft.com/library/windows/desktop/ms644904), along with [**QueryPerformanceFrequency**](https://msdn.microsoft.com/library/windows/desktop/ms644905), is still the best way to implement a game timer for UWP apps.</span></span>

<span data-ttu-id="0f3a9-119">タイマーと UWP アプリのライフサイクルのニュアンスに注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-119">You should be aware of a nuance with timers and the UWP app lifecycle.</span></span> <span data-ttu-id="0f3a9-120">中断と再開は、プレーヤーによるデスクトップ ゲームの再起動とは異なります。ゲームでは、最後にプレイされていた時点のスナップショットを再開します。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-120">Suspend/resume is different from a player re-launching a desktop game because your game will resume a snapshot in time from when the game was last played.</span></span> <span data-ttu-id="0f3a9-121">数週間など、長時間経過した場合は、ゲーム タイマーの実装は適切に動作しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-121">If a large amount of time has passed - for example, a few weeks - some game timer implementations might not behave gracefully.</span></span> <span data-ttu-id="0f3a9-122">ゲームの再開時にアプリのライフサイクル イベントを使ってタイマーをリセットできます。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-122">You can use app lifecycle events to reset your timer when the game resumes.</span></span>

<span data-ttu-id="0f3a9-123">まだ RDTSC 命令を使っているゲームはアップグレードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-123">Games that still use the RDTSC instruction need to upgrade.</span></span> <span data-ttu-id="0f3a9-124">「[ゲームのタイミングとマルチコア プロセッサ](https://msdn.microsoft.com/library/windows/desktop/ee417693)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-124">See [Game Timing and Multicore Processors](https://msdn.microsoft.com/library/windows/desktop/ee417693).</span></span>

## <a name="my-game-code-is-based-on-d3dx-and-dxut-is-there-anything-available-that-can-help-me-migrate-my-code"></a><span data-ttu-id="0f3a9-125">自分のゲーム コードは D3DX と DXUT に基づいています。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-125">My game code is based on D3DX and DXUT.</span></span> <span data-ttu-id="0f3a9-126">コードの移植に役立つものはありますか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-126">Is there anything available that can help me migrate my code?</span></span>


<span data-ttu-id="0f3a9-127">[DirectX ツール キット (DirectXTK)](http://go.microsoft.com/fwlink/p/?LinkID=248929) コミュニティのプロジェクトには、Direct3D 11 で利用できるヘルパー クラスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-127">The [DirectX Tool Kit (DirectXTK)](http://go.microsoft.com/fwlink/p/?LinkID=248929) community project offers helper classes for use with Direct3D 11.</span></span>

##  <a name="how-do-i-maintain-code-paths-for-the-desktop-and-the-windows-store"></a><span data-ttu-id="0f3a9-128">デスクトップと Windows ストアのコード パスを維持する方法を教えてください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-128">How do I maintain code paths for the desktop and the Windows Store?</span></span>


<span data-ttu-id="0f3a9-129">Chuck Walbourn 氏による[ゲームの二重用途のコーディング手法](http://go.microsoft.com/fwlink/p/?LinkID=286210)に関する記事シリーズで、デスクトップと Windows ストア コード パスの間でコードを共有する方法のガイダンスが提供されています。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-129">Chuck Walbourn's article series titled [Dual-use Coding Techniques for Games](http://go.microsoft.com/fwlink/p/?LinkID=286210) offers guidance on sharing code between the desktop and the Windows Store code paths.</span></span>

##  <a name="how-do-i-load-image-resources-in-my-directx-uwp-app"></a><span data-ttu-id="0f3a9-130">DirectX UWP アプリの画像リソースを読み込む方法を教えてください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-130">How do I load image resources in my DirectX UWP app?</span></span>


<span data-ttu-id="0f3a9-131">画像を読み込むための API パスは 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-131">There are two API paths for loading images:</span></span>

-   <span data-ttu-id="0f3a9-132">コンテンツ パイプラインは Direct3D のテクスチャ リソースとして使われる DDS ファイルに画像を変換します。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-132">The content pipeline converts images into DDS files used as Direct3D texture resources.</span></span> <span data-ttu-id="0f3a9-133">「[ゲームまたはアプリケーションでの 3-D アセットの使用](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-133">See [Using 3-D Assets in Your Game or App](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx).</span></span>
-   <span data-ttu-id="0f3a9-134">[Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902) を使うと、さまざまな形式から画像を読み込むことができます。このコンポーネントは、Direct2D ビットマップや、Direct3D のテクスチャ リソースに使用できます。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-134">The [Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902) can be used to load images from a variety of formats, and can be used for Direct2D bitmaps as well as Direct3D texture resources.</span></span>

<span data-ttu-id="0f3a9-135">[DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) または [DirectXTex](http://go.microsoft.com/fwlink/p/?LinkID=248926) の DDSTextureLoader と WICTextureLoader を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-135">You can also use the DDSTextureLoader, and the WICTextureLoader, from the [DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) or [DirectXTex](http://go.microsoft.com/fwlink/p/?LinkID=248926).</span></span>

## <a name="where-is-the-directx-sdk"></a><span data-ttu-id="0f3a9-136">DirectX SDK の場所</span><span class="sxs-lookup"><span data-stu-id="0f3a9-136">Where is the DirectX SDK?</span></span>


<span data-ttu-id="0f3a9-137">DirectX SDK は Windows SDK に同梱されています。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-137">The DirectX SDK is included as part of the Windows SDK.</span></span> <span data-ttu-id="0f3a9-138">Windows SDK に同梱されていない最新の DirectX SDK は、2010 年 6 月のものです。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-138">The most recent DirectX SDK that was separate from the Windows SDK was in June 2010.</span></span> <span data-ttu-id="0f3a9-139">Direct3D サンプルは、他の Windows アプリ サンプルと共にコード ギャラリーにあります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-139">Direct3D samples are in the Code Gallery along with the rest of the Windows app samples.</span></span>

## <a name="what-about-directx-redistributables"></a><span data-ttu-id="0f3a9-140">DirectX の再頒布可能パッケージについて教えてください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-140">What about DirectX redistributables?</span></span>


<span data-ttu-id="0f3a9-141">Windows SDK の大半のコンポーネントは、サポートされているバージョンの OS に含まれていますが、DLL コンポーネントは含まれていません (DirectXMath など)。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-141">The vast majority of components in the Windows SDK are already included in supported versions of the OS, or have no DLL component (such as DirectXMath).</span></span> <span data-ttu-id="0f3a9-142">UWP アプリで使うことができるすべての Direct3D API コンポーネントは、ゲームで既に使用できる状態です。再頒布する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-142">All Direct3D API components that UWP apps can use will already available to your game; you don't need to be redistribute them.</span></span>

<span data-ttu-id="0f3a9-143">Win32 デスクトップ アプリケーションは引き続き DirectSetup を使います。そのため、ゲームのデスクトップ バージョンをアップグレードする場合は、「[ゲーム開発者向けの Direct3D 11 の展開](https://msdn.microsoft.com/library/windows/desktop/ee416644)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-143">Win32 desktop applications still use DirectSetup, so if you are also upgrading the desktop version of your game see [Direct3D 11 Deployment for Game Developers](https://msdn.microsoft.com/library/windows/desktop/ee416644).</span></span>

## <a name="is-there-any-way-i-can-update-my-desktop-code-to-directx-11-before-moving-away-from-effects"></a><span data-ttu-id="0f3a9-144">Effects から離れる前にデスクトップ コードを DirectX 11 に更新する方法はありますか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-144">Is there any way I can update my desktop code to DirectX 11 before moving away from Effects?</span></span>


<span data-ttu-id="0f3a9-145">[Direct3D 11 向けの Effects の更新に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=271568)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-145">See the [Effects for Direct3D 11 Update](http://go.microsoft.com/fwlink/p/?LinkId=271568).</span></span> <span data-ttu-id="0f3a9-146">Effects 11 は、レガシ DirectX SDK ヘッダーへの依存を排除します。移植のサポート用に作成されたものであり、デスクトップ アプリでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-146">Effects 11 helps remove dependencies on legacy DirectX SDK headers; it's intended for use as a porting aid and can only be used with desktop apps.</span></span>

##  <a name="is-there-a-path-for-porting-my-directx-8-game-to-uwp"></a><span data-ttu-id="0f3a9-147">UWP に DirectX 8 ゲームを移植するためのパスはありますか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-147">Is there a path for porting my DirectX 8 game to UWP?</span></span>


<span data-ttu-id="0f3a9-148">はい、あります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-148">Yes:</span></span>

-   <span data-ttu-id="0f3a9-149">「[Direct3D 9 への変換](https://msdn.microsoft.com/library/windows/desktop/bb204851)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-149">Read [Converting to Direct3D 9](https://msdn.microsoft.com/library/windows/desktop/bb204851).</span></span>
-   <span data-ttu-id="0f3a9-150">ゲームに固定パイプラインが残っていないことを確かめます。「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-150">Make sure your game has no remnants of the fixed pipeline - see [Deprecated Features](https://msdn.microsoft.com/library/windows/desktop/cc308047).</span></span>
-   <span data-ttu-id="0f3a9-151">次に、DirectX 9 移植パスに従います。「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-151">Then take the DirectX 9 porting path: [Port from D3D 9 to UWP](walkthrough--simple-port-from-direct3d-9-to-11-1.md).</span></span>

##  <a name="can-i-port-my-directx-10-or-11-game-to-uwp"></a><span data-ttu-id="0f3a9-152">UWP に DirectX 10 または 11 ゲームを移植することはできますか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-152">Can I port my DirectX 10 or 11 game to UWP?</span></span>


<span data-ttu-id="0f3a9-153">DirectX 10.x と 11 のデスクトップ ゲームは、UWP に簡単に移植できます。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-153">DirectX 10.x and 11 desktop games are easy to port to UWP.</span></span> <span data-ttu-id="0f3a9-154">「[Direct3D 11 への移行](https://msdn.microsoft.com/library/windows/desktop/ff476190)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-154">See [Migrating to Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476190).</span></span>

## <a name="how-do-i-choose-the-right-display-device-in-a-multi-monitor-system"></a><span data-ttu-id="0f3a9-155">マルチモニター システムで適切なディスプレイ デバイスを選ぶにはどうすればよいですか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-155">How do I choose the right display device in a multi-monitor system?</span></span>


<span data-ttu-id="0f3a9-156">アプリを表示するモニターはユーザーが選びます。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-156">The user selects which monitor your app is displayed on.</span></span> <span data-ttu-id="0f3a9-157">最初のパラメーターを **nullptr** に設定して [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出すことで、Windows が正しいアダプターを提供できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-157">Let Windows provide the correct adapter by calling [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) with the first parameter set to **nullptr**.</span></span> <span data-ttu-id="0f3a9-158">次にデバイスの [**IDXGIDevice interface**](https://msdn.microsoft.com/library/windows/desktop/bb174527) を取得し、[**GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) を呼び出して、DXGI アダプターを使ってスワップ チェーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-158">Then get the device's [**IDXGIDevice interface**](https://msdn.microsoft.com/library/windows/desktop/bb174527), call [**GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) and use the DXGI adapter to create the swap chain.</span></span>

## <a name="how-do-i-turn-on-antialiasing"></a><span data-ttu-id="0f3a9-159">アンチエイリアシングをオンにするにはどうすればよいですか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-159">How do I turn on antialiasing?</span></span>


<span data-ttu-id="0f3a9-160">Direct3D デバイスを作成するとアンチエイリアシング (マルチサンプリング) が有効になります。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-160">Antialiasing (multisampling) is enabled when you create the Direct3D device.</span></span> <span data-ttu-id="0f3a9-161">[**CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499) を呼び出してマルチサンプリングのサポートを列挙し、[**CreateSurface**](https://msdn.microsoft.com/library/windows/desktop/bb174530) を呼び出すときに [**DXGI\_SAMPLE\_DESC structure**](https://msdn.microsoft.com/library/windows/desktop/bb173072) でマルチサンプリングのオプションを設定します。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-161">Enumerate multisampling support by calling [**CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499), then set multisample options in the [**DXGI\_SAMPLE\_DESC structure**](https://msdn.microsoft.com/library/windows/desktop/bb173072) when you call [**CreateSurface**](https://msdn.microsoft.com/library/windows/desktop/bb174530).</span></span>

## <a name="my-game-renders-using-multithreading-andor-deferred-rendering-what-do-i-need-to-know-for-direct3d-11"></a><span data-ttu-id="0f3a9-162">自分のゲームでは、マルチスレッドや遅延レンダリングを使ってレンダリングを行います。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-162">My game renders using multithreading and/or deferred rendering.</span></span> <span data-ttu-id="0f3a9-163">Direct3D 11 向けに何を把握しておく必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-163">What do I need to know for Direct3D 11?</span></span>


<span data-ttu-id="0f3a9-164">まず、「[Direct3D 11 でのマルチスレッドの概要](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-164">Visit [Introduction to Multithreading in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476891) to get started.</span></span> <span data-ttu-id="0f3a9-165">主な違いの一覧については、「[Direct3D のバージョン間におけるスレッドの違い](https://msdn.microsoft.com/library/windows/desktop/ff476890)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-165">For a list of key differences, see [Threading Differences between Direct3D Versions](https://msdn.microsoft.com/library/windows/desktop/ff476890).</span></span> <span data-ttu-id="0f3a9-166">遅延レンダリングでは*イミディエイト コンテキスト*ではなくデバイスの*遅延コンテキスト*が使われることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-166">Note that deferred rendering uses a device *deferred context* instead of an *immediate context*.</span></span>

## <a name="where-can-i-read-more-about-the-programmable-pipeline-since-direct3d-9"></a><span data-ttu-id="0f3a9-167">Direct3D 9 以降のプログラム可能なパイプラインに関する詳しい情報はどこにありますか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-167">Where can I read more about the programmable pipeline since Direct3D 9?</span></span>


<span data-ttu-id="0f3a9-168">次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-168">Visit the following topics:</span></span>

-   [<span data-ttu-id="0f3a9-169">HLSL 用プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="0f3a9-169">Programming Guide for HLSL</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb509635)
-   [<span data-ttu-id="0f3a9-170">Direct3D 10 のよく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="0f3a9-170">Direct3D 10 Frequently Asked Questions</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee416643)

## <a name="what-should-i-use-instead-of-the-x-file-format-for-my-models"></a><span data-ttu-id="0f3a9-171">モデルには .x ファイル形式の代わりに何を使えばよいですか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-171">What should I use instead of the .x file format for my models?</span></span>


<span data-ttu-id="0f3a9-172">.x ファイル形式に代わる公式のファイル形式はありませんが、サンプルの多くで SDKMesh 形式を利用しています。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-172">While we don’t have an official replacement for the .x file format, many of the samples utilize the SDKMesh format.</span></span> <span data-ttu-id="0f3a9-173">Visual Studio には、一般的な形式を CMO ファイルにコンパイルする[コンテンツ パイプライン](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)があります。CMO ファイルは、Visual Studio 3D スターター キットのコードか、[DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) を使って読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-173">Visual Studio also has a [content pipeline](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx) that compiles several popular formats into CMO files that can be loaded with code from the Visual Studio 3D starter kit, or loaded using the [DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929).</span></span>

## <a name="how-do-i-debug-my-shaders"></a><span data-ttu-id="0f3a9-174">シェーダーをデバッグするにはどうしたらよいですか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-174">How do I debug my shaders?</span></span>


<span data-ttu-id="0f3a9-175">Microsoft Visual Studio 2015 には、DirectX グラフィックスの診断ツールが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-175">Microsoft Visual Studio 2015 includes diagnostic tools for DirectX graphics.</span></span> <span data-ttu-id="0f3a9-176">「[DirectX グラフィックスのデバッグ](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-176">See [Debugging DirectX Graphics](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx).</span></span>

##  <a name="what-is-the-direct3d-11-equivalent-for-x-function"></a><span data-ttu-id="0f3a9-177">*x* 関数に相当する Direct3D 11 の要素は何ですか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-177">What is the Direct3D 11 equivalent for *x* function?</span></span>


<span data-ttu-id="0f3a9-178">「DirectX 11 API への DirectX 9 の機能のマッピング」の「[関数のマッピング](feature-mapping.md#function-mapping)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-178">See the [function mapping](feature-mapping.md#function-mapping) provided in Map DirectX 9 features to DirectX 11 APIs.</span></span>

##  <a name="what-is-the-dxgiformat-equivalent-of-y-surface-format"></a><span data-ttu-id="0f3a9-179">*y* サーフェス形式に相当する DXGI_FORMAT の要素は何ですか。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-179">What is the DXGI\_FORMAT equivalent of *y* surface format?</span></span>


<span data-ttu-id="0f3a9-180">「DirectX 11 API への DirectX 9 の機能のマッピング」の「[サーフェス形式のマッピング](feature-mapping.md#surface-format-mapping)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f3a9-180">See the [surface format mapping](feature-mapping.md#surface-format-mapping) provided in Map DirectX 9 features to DirectX 11 APIs.</span></span>

 

 




