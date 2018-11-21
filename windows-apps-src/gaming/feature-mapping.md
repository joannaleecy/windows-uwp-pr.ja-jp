---
author: mtoepke
title: DirectX 11 API への DirectX 9 の機能のマッピング
description: Direct3D 9 ゲームで使う機能が Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) にどのように変換されるかについて説明します。
ms.assetid: 3aa8a114-4e47-ae0a-9447-88ba324377b8
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 9, DirectX 11, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 8dcf1749f1e7db4d514466d6a753d6f8cace5713
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7444500"
---
# <a name="map-directx-9-features-to-directx-11-apis"></a><span data-ttu-id="a0f62-104">DirectX 11 API への DirectX 9 の機能のマッピング</span><span class="sxs-lookup"><span data-stu-id="a0f62-104">Map DirectX 9 features to DirectX 11 APIs</span></span>



**<span data-ttu-id="a0f62-105">概要</span><span class="sxs-lookup"><span data-stu-id="a0f62-105">Summary</span></span>**

-   [<span data-ttu-id="a0f62-106">DirectX の移植の計画</span><span class="sxs-lookup"><span data-stu-id="a0f62-106">Plan your DirectX port</span></span>](plan-your-directx-port.md)
-   [<span data-ttu-id="a0f62-107">Direct3D 9 と Direct3D 11 の間の重要な変更点</span><span class="sxs-lookup"><span data-stu-id="a0f62-107">Important changes from Direct3D 9 to Direct3D 11</span></span>](understand-direct3d-11-1-concepts.md)
-   <span data-ttu-id="a0f62-108">機能のマッピング</span><span class="sxs-lookup"><span data-stu-id="a0f62-108">Feature mapping</span></span>


<span data-ttu-id="a0f62-109">Direct3D 9 ゲームで使う機能が Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) にどのように変換されるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-109">Understand how the features your Direct3D 9 game uses will translate to Direct3D 11 and the Universal Windows Platform (UWP).</span></span>

## <a name="mapping-direct3d-9-to-directx-11-apis"></a><span data-ttu-id="a0f62-110">DirectX 11 API への Direct3D 9 のマッピング</span><span class="sxs-lookup"><span data-stu-id="a0f62-110">Mapping Direct3D 9 to DirectX 11 APIs</span></span>


<span data-ttu-id="a0f62-111">[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) はこれまでと同じく DirectX グラフィックスの土台ですが、API は DirectX 9 以降変更されています。</span><span class="sxs-lookup"><span data-stu-id="a0f62-111">[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) is still the foundation of DirectX graphics, but the API has changed since DirectX 9:</span></span>

-   <span data-ttu-id="a0f62-112">Microsoft DirectX Graphic Infrastructure (DXGI) はグラフィックス アダプターを設定するために使われます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-112">Microsoft DirectX Graphics Infrastructure (DXGI) is used to set up graphics adapters.</span></span> <span data-ttu-id="a0f62-113">バッファー形式の選択、スワップ チェーンの作成、フレームの表示、共有リソースの作成には [DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534) を使います。</span><span class="sxs-lookup"><span data-stu-id="a0f62-113">Use [DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534) to select buffer formats, create swap chains, present frames, and create shared resources.</span></span> <span data-ttu-id="a0f62-114">「[DXGI の概要](https://msdn.microsoft.com/library/windows/desktop/bb205075)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-114">See [DXGI Overview](https://msdn.microsoft.com/library/windows/desktop/bb205075).</span></span>
-   <span data-ttu-id="a0f62-115">Direct3D のデバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-115">A Direct3D device context is used to set pipeline state and generate rendering commands.</span></span> <span data-ttu-id="a0f62-116">ほとんどのサンプルではイミディエイト コンテキストを使ってデバイスに直接レンダリングしていますが、Direct3D 11 ではマルチスレッド レンダリングもサポートされており、その場合は遅延コンテキストが使われます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-116">Most of our samples use an immediate context to render directly to the device; Direct3D 11 also supports multithreaded rendering, in which case deferred contexts are used.</span></span> <span data-ttu-id="a0f62-117">「[Direct3D 11 のデバイスについて](https://msdn.microsoft.com/library/windows/desktop/ff476880)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-117">See [Introduction to a Device in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476880).</span></span>
-   <span data-ttu-id="a0f62-118">一部の機能は非推奨になっていますが、特に固定関数パイプラインが推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="a0f62-118">Some features have been deprecated, most notably the fixed function pipeline.</span></span> <span data-ttu-id="a0f62-119">「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-119">See [Deprecated Features](https://msdn.microsoft.com/library/windows/desktop/cc308047).</span></span>

<span data-ttu-id="a0f62-120">Direct3D 11 の機能の完全な一覧については、「[Direct3D 11 の機能](https://msdn.microsoft.com/library/windows/desktop/ff476342)」と「[Direct3D 11 の機能](https://msdn.microsoft.com/library/windows/desktop/hh404562)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-120">For a full list of Direct3D 11 features, see [Direct3D 11 Features](https://msdn.microsoft.com/library/windows/desktop/ff476342) and [Direct3D 11 Features](https://msdn.microsoft.com/library/windows/desktop/hh404562).</span></span>

## <a name="moving-from-direct2d-9-to-direct2d-11"></a><span data-ttu-id="a0f62-121">Direct2D 9 から Direct2D 11 への移行</span><span class="sxs-lookup"><span data-stu-id="a0f62-121">Moving from Direct2D 9 to Direct2D 11</span></span>


<span data-ttu-id="a0f62-122">[Direct2D (Windows)](https://msdn.microsoft.com/library/windows/desktop/dd370990) は、これまでどおり DirectX グラフィックスと Windows の重要な一部です。</span><span class="sxs-lookup"><span data-stu-id="a0f62-122">[Direct2D (Windows)](https://msdn.microsoft.com/library/windows/desktop/dd370990) is still an important part of DirectX graphics and Windows.</span></span> <span data-ttu-id="a0f62-123">これまでどおり Direct2D を使って 2D ゲームを描画したり、Direct3D の上にオーバーレイ (HUD) を描画したりできます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-123">You can still use Direct2D to draw 2D games, and to draw overlays (HUDs) on top of Direct3D.</span></span>

<span data-ttu-id="a0f62-124">Direct2D は Direct3D の上で実行されます。2D ゲームは API を使って実装できます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-124">Direct2D runs on top of Direct3D; 2D games can be implemented using either API.</span></span> <span data-ttu-id="a0f62-125">たとえば、Direct3D を使って実装される 2D ゲームでは、正投影を使ったり、Z 値を設定してプリミティブの描画の順序を制御したり、ピクセル シェーダーを使って特殊効果を追加したりできます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-125">For example, a 2D game implemented using Direct3D can use orthographic projection, set Z-values to control the drawing order of primitives, and use pixel shaders to add special effects.</span></span>

<span data-ttu-id="a0f62-126">Direct2D は Direct3D に基づいているため、DXGI とデバイス コンテキストも使います。</span><span class="sxs-lookup"><span data-stu-id="a0f62-126">Since Direct2D is based on Direct3D it also uses DXGI and device contexts.</span></span> <span data-ttu-id="a0f62-127">「[Direct2D API の概要](https://msdn.microsoft.com/library/windows/desktop/dd317121)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-127">See [Direct2D API Overview](https://msdn.microsoft.com/library/windows/desktop/dd317121).</span></span>

<span data-ttu-id="a0f62-128">[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) API は、Direct2D を使って書式付きテキストのサポートを追加します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-128">The [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) API adds support for formatted text using Direct2D.</span></span> <span data-ttu-id="a0f62-129">「[DirectWrite の紹介](https://msdn.microsoft.com/library/windows/desktop/dd371554)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-129">See [Introducing DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd371554).</span></span>

## <a name="replace-deprecated-helper-libraries"></a><span data-ttu-id="a0f62-130">推奨されなくなったヘルパー ライブラリの置き換え</span><span class="sxs-lookup"><span data-stu-id="a0f62-130">Replace deprecated helper libraries</span></span>


<span data-ttu-id="a0f62-131">D3DX と DXUT は推奨されなくなったため、UWP ゲームでは使うことができません。</span><span class="sxs-lookup"><span data-stu-id="a0f62-131">D3DX and DXUT are deprecated and cannot be used by UWP games.</span></span> <span data-ttu-id="a0f62-132">これらのヘルパー ライブラリでは、テクスチャの読み込みやメッシュの読み込みなどのタスク用にリソースが提供されていました。</span><span class="sxs-lookup"><span data-stu-id="a0f62-132">These helper libraries provided resources for tasks such as texture loading and mesh loading.</span></span>

-   <span data-ttu-id="a0f62-133">「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」では、ウィンドウの設定、Direct3D の初期化、基本的な 3D レンダリングの方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-133">The [Simple port from Direct3D 9 to UWP](walkthrough--simple-port-from-direct3d-9-to-11-1.md) walkthrough demonstrates how to set up a window, initialize Direct3D, and do basic 3D rendering.</span></span>
-   <span data-ttu-id="a0f62-134">「[DirectX を使った単純なユニバーサル Windows プラットフォーム (UWP) ゲームの作成](tutorial--create-your-first-uwp-directx-game.md)」では、グラフィックス、ファイルの読み込み、UI、コントロール、サウンドなど、一般的なゲーム プログラミング タスクを示します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-134">The [Simple UWP game with DirectX](tutorial--create-your-first-uwp-directx-game.md) walkthrough demonstrates common game programming tasks including graphics, loading files, UI, controls, and sound.</span></span>
-   <span data-ttu-id="a0f62-135">[DirectX ツール キット](http://go.microsoft.com/fwlink/p/?LinkID=248929) コミュニティのプロジェクトには、Direct3D 11 および UWP アプリで利用できるヘルパー クラスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="a0f62-135">The [DirectX Tool Kit](http://go.microsoft.com/fwlink/p/?LinkID=248929) community project offers helper classes for use with Direct3D 11 and UWP apps.</span></span>

## <a name="move-shader-programs-from-fx-to-hlsl"></a><span data-ttu-id="a0f62-136">FX から HLSL へのシェーダー プログラムの移行</span><span class="sxs-lookup"><span data-stu-id="a0f62-136">Move shader programs from FX to HLSL</span></span>


<span data-ttu-id="a0f62-137">Effects を含め、D3DX ユーティリティ ライブラリ (D3DX 9、D3DX 10、D3DX 11) は、UWP では推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="a0f62-137">The D3DX utility library (D3DX 9, D3DX 10, and D3DX 11), including Effects, is deprecated for UWP.</span></span> <span data-ttu-id="a0f62-138">UWP のすべての DirectX ゲームは、Effects を使わずに、[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561) を使ってグラフィックス パイプラインを実行します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-138">All DirectX games for UWP drive the graphics pipeline using [HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561) without Effects.</span></span>

<span data-ttu-id="a0f62-139">Visual Studio は、シェーダー オブジェクトをコンパイルするために FXC をバックグラウンドで使います。</span><span class="sxs-lookup"><span data-stu-id="a0f62-139">Visual Studio still uses FXC under the hood to compile shader objects.</span></span> <span data-ttu-id="a0f62-140">UWP ゲームのシェーダーは事前にコンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-140">UWP game shaders are compiled ahead of time.</span></span> <span data-ttu-id="a0f62-141">バイトコードは実行時に読み込まれ、各シェーダー リソースは適切なレンダリング パスの間にグラフィックス パイプラインにバインドされます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-141">The bytecode is loaded at runtime, then each shader resource is bound to the graphics pipeline during the appropriate rendering pass.</span></span> <span data-ttu-id="a0f62-142">シェーダーを独自の別の .HLSL ファイルに移し、レンダリング テクノロジを C++ コードで実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0f62-142">Shaders should be moved to their own separate .HLSL files and rendering techniques should be implemented in your C++ code.</span></span>

<span data-ttu-id="a0f62-143">シェーダー リソースの読み込みの概要については、「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-143">For a quick look at loading shader resources see [Simple port from Direct3D 9 to UWP](walkthrough--simple-port-from-direct3d-9-to-11-1.md).</span></span>

<span data-ttu-id="a0f62-144">Direct3D 11 ではシェーダー モデル 5 が導入されましたが、これには Direct3D 機能レベル 11\_0 以上が必要です。</span><span class="sxs-lookup"><span data-stu-id="a0f62-144">Direct3D 11 introduced Shader Model 5, which requires Direct3D feature level 11\_0 (or above).</span></span> <span data-ttu-id="a0f62-145">「[Direct3D 11 の HLSL シェーダー モデル 5 の機能](https://msdn.microsoft.com/library/windows/desktop/ff471419)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-145">See [HLSL Shader Model 5 Features for Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff471419).</span></span>

## <a name="replace-xnamath-and-d3dxmath"></a><span data-ttu-id="a0f62-146">XNAMath と D3DXMath の置き換え</span><span class="sxs-lookup"><span data-stu-id="a0f62-146">Replace XNAMath and D3DXMath</span></span>


<span data-ttu-id="a0f62-147">XNAMath (または D3DXMath) を使ったコードは [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) に移行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0f62-147">Code using XNAMath (or D3DXMath) should be migrated to [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833).</span></span> <span data-ttu-id="a0f62-148">DirectXMath には、x86、x64、ARM の間で移植可能な型が含まれています。</span><span class="sxs-lookup"><span data-stu-id="a0f62-148">DirectXMath includes types that are portable across x86, x64, and ARM.</span></span> <span data-ttu-id="a0f62-149">「[XNA Math ライブラリからのコードの移行](https://msdn.microsoft.com/library/windows/desktop/ee418730)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-149">See [Code Migration from the XNA Math Library](https://msdn.microsoft.com/library/windows/desktop/ee418730).</span></span>

<span data-ttu-id="a0f62-150">DirectXMath の浮動小数点型はシェーダーで使うと便利です。</span><span class="sxs-lookup"><span data-stu-id="a0f62-150">Note that DirectXMath float types are convenient for use with shaders.</span></span> <span data-ttu-id="a0f62-151">たとえば、[**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) と [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) は、定数バッファーのデータの整列に便利です。</span><span class="sxs-lookup"><span data-stu-id="a0f62-151">For example [**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) and [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) conveniently align data for constant buffers.</span></span>

## <a name="replace-directsound-with-xaudio2-and-background-audio"></a><span data-ttu-id="a0f62-152">XAudio2 (とバックグラウンド オーディオ) への DirectSound の置き換え</span><span class="sxs-lookup"><span data-stu-id="a0f62-152">Replace DirectSound with XAudio2 (and background audio)</span></span>


<span data-ttu-id="a0f62-153">DirectSound では、UWP はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a0f62-153">DirectSound is not supported for UWP:</span></span>

-   <span data-ttu-id="a0f62-154">ゲームにサウンド効果を追加するには [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) を使います。</span><span class="sxs-lookup"><span data-stu-id="a0f62-154">Use [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) to add sound effects to your game.</span></span>

##  <a name="replace-directinput-with-xinput-and-uwp-apis"></a><span data-ttu-id="a0f62-155">XInput と UWP API への DirectInput の置き換え</span><span class="sxs-lookup"><span data-stu-id="a0f62-155">Replace DirectInput with XInput and UWP APIs</span></span>


<span data-ttu-id="a0f62-156">DirectInput では、UWP はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a0f62-156">DirectInput is not supported for UWP:</span></span>

-   <span data-ttu-id="a0f62-157">マウス、キーボード、タッチ入力には [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の入力イベント コールバックを使います。</span><span class="sxs-lookup"><span data-stu-id="a0f62-157">Use [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) input event callbacks for mouse, keyboard, and touch input.</span></span>
-   <span data-ttu-id="a0f62-158">ゲーム コントローラーのサポート (とゲーム コントローラーのヘッドセットのサポート) には [XInput](https://msdn.microsoft.com/library/windows/desktop/ee417001) 1.4 を使います。</span><span class="sxs-lookup"><span data-stu-id="a0f62-158">Use [XInput](https://msdn.microsoft.com/library/windows/desktop/ee417001) 1.4 for game controller support (and game controller headset support).</span></span> <span data-ttu-id="a0f62-159">デスクトップと UWP に共有コード ベースを使う場合は、下位互換性について、「[XInput のバージョン](https://msdn.microsoft.com/library/windows/desktop/hh405051)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-159">If you are using a shared code base for desktop and UWP, see [XInput Versions](https://msdn.microsoft.com/library/windows/desktop/hh405051) for information on backwards compatibility.</span></span>
-   <span data-ttu-id="a0f62-160">ゲームでアプリ バーを使う必要がある場合は、[**EdgeGesture**](https://msdn.microsoft.com/library/windows/apps/hh701600) イベントに登録します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-160">Register for [**EdgeGesture**](https://msdn.microsoft.com/library/windows/apps/hh701600) events if your game needs to use the app bar.</span></span>

## <a name="use-microsoft-media-foundation-instead-of-directshow"></a><span data-ttu-id="a0f62-161">DirectShow の代わりに Microsoft メディア ファンデーションを使う</span><span class="sxs-lookup"><span data-stu-id="a0f62-161">Use Microsoft Media Foundation instead of DirectShow</span></span>


<span data-ttu-id="a0f62-162">DirectShow は DirectX API (または Windows API) にはもう含まれていません。</span><span class="sxs-lookup"><span data-stu-id="a0f62-162">DirectShow is no longer part of the DirectX API (or the Windows API).</span></span> <span data-ttu-id="a0f62-163">[Microsoft メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197)は共有サーフェイスを使って Direct3D にビデオ コンテンツを提供します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-163">[Microsoft Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197) provides video content to Direct3D using shared surfaces.</span></span> <span data-ttu-id="a0f62-164">「[Direct3D 11 のビデオ API](https://msdn.microsoft.com/library/windows/desktop/hh447677)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-164">See [Direct3D 11 Video APIs](https://msdn.microsoft.com/library/windows/desktop/hh447677).</span></span>

## <a name="replace-directplay-with-networking-code"></a><span data-ttu-id="a0f62-165">ネットワーク コードへの DirectPlay の置き換え</span><span class="sxs-lookup"><span data-stu-id="a0f62-165">Replace DirectPlay with networking code</span></span>


<span data-ttu-id="a0f62-166">Microsoft DirectPlay は推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="a0f62-166">Microsoft DirectPlay has been deprecated.</span></span> <span data-ttu-id="a0f62-167">ゲームでネットワーク サービスを使う場合は、UWP の要件に準拠しているネットワーク コードを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0f62-167">If your game uses network services, you need to provide networking code that complies with UWP requirements.</span></span> <span data-ttu-id="a0f62-168">次の API を使います。</span><span class="sxs-lookup"><span data-stu-id="a0f62-168">Use the following APIs:</span></span>

-   [<span data-ttu-id="a0f62-169">UWP アプリの Win32 と COM (ネットワーク) (Windows)</span><span class="sxs-lookup"><span data-stu-id="a0f62-169">Win32 and COM for UWP apps (networking) (Windows)</span></span>](https://msdn.microsoft.com/library/windows/apps/br205759)
-   [**<span data-ttu-id="a0f62-170">Windows.Networking 名前空間 (Windows)</span><span class="sxs-lookup"><span data-stu-id="a0f62-170">Windows.Networking namespace (Windows)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br207124)
-   [**<span data-ttu-id="a0f62-171">Windows.Networking.Sockets 名前空間 (Windows)</span><span class="sxs-lookup"><span data-stu-id="a0f62-171">Windows.Networking.Sockets namespace (Windows)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226960)
-   [**<span data-ttu-id="a0f62-172">Windows.Networking.Connectivity 名前空間 (Windows)</span><span class="sxs-lookup"><span data-stu-id="a0f62-172">Windows.Networking.Connectivity namespace (Windows)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br207308)
-   [**<span data-ttu-id="a0f62-173">Windows.ApplicationModel.Background 名前空間 (Windows)</span><span class="sxs-lookup"><span data-stu-id="a0f62-173">Windows.ApplicationModel.Background namespace (Windows)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224847)

<span data-ttu-id="a0f62-174">次の記事は、ネットワーク機能を追加し、アプリのパッケージ マニフェストでネットワークのサポートを宣言するうえで役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-174">The following articles help you add networking features and declare support for networking in your app's package manifest.</span></span>

-   [<span data-ttu-id="a0f62-175">ソケットを使った接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)</span><span class="sxs-lookup"><span data-stu-id="a0f62-175">Connecting with sockets (UWP apps using C#/VB/C++ and XAML) (Windows)</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452976)
-   [<span data-ttu-id="a0f62-176">WebSocket を使った接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)</span><span class="sxs-lookup"><span data-stu-id="a0f62-176">Connecting with WebSockets (UWP apps using C#/VB/C++ and XAML) (Windows)</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh994396)
-   [<span data-ttu-id="a0f62-177">Web サービスへの接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)</span><span class="sxs-lookup"><span data-stu-id="a0f62-177">Connecting to web services (UWP apps using C#/VB/C++ and XAML) (Windows)</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh761504)
-   [<span data-ttu-id="a0f62-178">ネットワークの基本</span><span class="sxs-lookup"><span data-stu-id="a0f62-178">Networking basics</span></span>](https://msdn.microsoft.com/library/windows/apps/mt280233)

<span data-ttu-id="a0f62-179">アプリの中断中は、すべての UWP アプリ (ゲームを含む) で特定の種類のバックグラウンド タスクを使って接続を維持します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-179">Note that all UWP apps (including games) use specific types of background tasks to maintain connectivity while the app is suspended.</span></span> <span data-ttu-id="a0f62-180">中断されている間、ゲームが接続状態を保存する必要がある場合は、「[ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-180">If your game needs to maintain connection state while suspended see [Networking basics](https://msdn.microsoft.com/library/windows/apps/mt280233).</span></span>

## <a name="function-mapping"></a><span data-ttu-id="a0f62-181">関数のマッピング</span><span class="sxs-lookup"><span data-stu-id="a0f62-181">Function mapping</span></span>


<span data-ttu-id="a0f62-182">Direct3D 9 から Direct3D 11 にコードの変換を行う場合は、次の表を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-182">Use the following table to help convert code from Direct3D 9 to Direct3D 11.</span></span> <span data-ttu-id="a0f62-183">これは、デバイスとデバイス コンテキストの区別にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-183">This can also help distinguish between the device and device context.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="a0f62-184">Direct3D9</span><span class="sxs-lookup"><span data-stu-id="a0f62-184">Direct3D9</span></span></th>
<th align="left"><span data-ttu-id="a0f62-185">相当する Direct3D 11 の要素</span><span class="sxs-lookup"><span data-stu-id="a0f62-185">Direct3D 11 Equivalent</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174336"><span data-ttu-id="a0f62-186">IDirect3DDevice9</span><span class="sxs-lookup"><span data-stu-id="a0f62-186">IDirect3DDevice9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280493"><span data-ttu-id="a0f62-187">ID3D11Device2</span><span class="sxs-lookup"><span data-stu-id="a0f62-187">ID3D11Device2</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280498"><span data-ttu-id="a0f62-188">ID3D11DeviceContext2</span><span class="sxs-lookup"><span data-stu-id="a0f62-188">ID3D11DeviceContext2</span></span></a></p>
<p><span data-ttu-id="a0f62-189">グラフィックス パイプラインのステージについては、「<a href="https://msdn.microsoft.com/library/windows/desktop/ff476882">グラフィックス パイプライン</a>」で説明されています。</span><span class="sxs-lookup"><span data-stu-id="a0f62-189">The graphics pipeline stages are described in <a href="https://msdn.microsoft.com/library/windows/desktop/ff476882">Graphics Pipeline</a>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174300"><span data-ttu-id="a0f62-190">IDirect3D9</span><span class="sxs-lookup"><span data-stu-id="a0f62-190">IDirect3D9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404556"><span data-ttu-id="a0f62-191">IDXGIFactory2</span><span class="sxs-lookup"><span data-stu-id="a0f62-191">IDXGIFactory2</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404537"><span data-ttu-id="a0f62-192">IDXGIAdapter2</span><span class="sxs-lookup"><span data-stu-id="a0f62-192">IDXGIAdapter2</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280345"><span data-ttu-id="a0f62-193">IDXGIDevice3</span><span class="sxs-lookup"><span data-stu-id="a0f62-193">IDXGIDevice3</span></span></a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174423"><span data-ttu-id="a0f62-194">IDirect3DDevice9::Present</span><span class="sxs-lookup"><span data-stu-id="a0f62-194">IDirect3DDevice9::Present</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh446797"><span data-ttu-id="a0f62-195">IDXGISwapChain1::Present1</span><span class="sxs-lookup"><span data-stu-id="a0f62-195">IDXGISwapChain1::Present1</span></span></a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174472"><span data-ttu-id="a0f62-196">IDirect3DDevice9::TestCooperativeLevel</span><span class="sxs-lookup"><span data-stu-id="a0f62-196">IDirect3DDevice9::TestCooperativeLevel</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="a0f62-197">DXGI_PRESENT_TEST フラグを設定して <a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-197">Call <a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> with the DXGI_PRESENT_TEST flag set.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174322"><span data-ttu-id="a0f62-198">IDirect3DBaseTexture9</span><span class="sxs-lookup"><span data-stu-id="a0f62-198">IDirect3DBaseTexture9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205909"><span data-ttu-id="a0f62-199">IDirect3DTexture9</span><span class="sxs-lookup"><span data-stu-id="a0f62-199">IDirect3DTexture9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174329"><span data-ttu-id="a0f62-200">IDirect3DCubeTexture9</span><span class="sxs-lookup"><span data-stu-id="a0f62-200">IDirect3DCubeTexture9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205941"><span data-ttu-id="a0f62-201">IDirect3DVolumeTexture9</span><span class="sxs-lookup"><span data-stu-id="a0f62-201">IDirect3DVolumeTexture9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205865"><span data-ttu-id="a0f62-202">IDirect3DIndexBuffer9</span><span class="sxs-lookup"><span data-stu-id="a0f62-202">IDirect3DIndexBuffer9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205915"><span data-ttu-id="a0f62-203">IDirect3DVertexBuffer9</span><span class="sxs-lookup"><span data-stu-id="a0f62-203">IDirect3DVertexBuffer9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476351"><span data-ttu-id="a0f62-204">ID3D11Buffer</span><span class="sxs-lookup"><span data-stu-id="a0f62-204">ID3D11Buffer</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476633"><span data-ttu-id="a0f62-205">ID3D11Texture1D</span><span class="sxs-lookup"><span data-stu-id="a0f62-205">ID3D11Texture1D</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476635"><span data-ttu-id="a0f62-206">ID3D11Texture2D</span><span class="sxs-lookup"><span data-stu-id="a0f62-206">ID3D11Texture2D</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476637"><span data-ttu-id="a0f62-207">ID3D11Texture3D</span><span class="sxs-lookup"><span data-stu-id="a0f62-207">ID3D11Texture3D</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476628"><span data-ttu-id="a0f62-208">ID3D11ShaderResourceView</span><span class="sxs-lookup"><span data-stu-id="a0f62-208">ID3D11ShaderResourceView</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476582"><span data-ttu-id="a0f62-209">ID3D11RenderTargetView</span><span class="sxs-lookup"><span data-stu-id="a0f62-209">ID3D11RenderTargetView</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476377"><span data-ttu-id="a0f62-210">ID3D11DepthStencilView</span><span class="sxs-lookup"><span data-stu-id="a0f62-210">ID3D11DepthStencilView</span></span></a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205922"><span data-ttu-id="a0f62-211">IDirect3DVertexShader9</span><span class="sxs-lookup"><span data-stu-id="a0f62-211">IDirect3DVertexShader9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205869"><span data-ttu-id="a0f62-212">IDirect3DPixelShader9</span><span class="sxs-lookup"><span data-stu-id="a0f62-212">IDirect3DPixelShader9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476641"><span data-ttu-id="a0f62-213">ID3D11VertexShader</span><span class="sxs-lookup"><span data-stu-id="a0f62-213">ID3D11VertexShader</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476576"><span data-ttu-id="a0f62-214">ID3D11PixelShader</span><span class="sxs-lookup"><span data-stu-id="a0f62-214">ID3D11PixelShader</span></span></a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205919"><span data-ttu-id="a0f62-215">IDirect3DVertexDeclaration9</span><span class="sxs-lookup"><span data-stu-id="a0f62-215">IDirect3DVertexDeclaration9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476575"><span data-ttu-id="a0f62-216">ID3D11InputLayout</span><span class="sxs-lookup"><span data-stu-id="a0f62-216">ID3D11InputLayout</span></span></a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205805"><span data-ttu-id="a0f62-217">IDirect3DDevice9::SetRenderState</span><span class="sxs-lookup"><span data-stu-id="a0f62-217">IDirect3DDevice9::SetRenderState</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205806"><span data-ttu-id="a0f62-218">IDirect3DDevice9::SetSamplerState</span><span class="sxs-lookup"><span data-stu-id="a0f62-218">IDirect3DDevice9::SetSamplerState</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404571"><span data-ttu-id="a0f62-219">ID3D11BlendState1</span><span class="sxs-lookup"><span data-stu-id="a0f62-219">ID3D11BlendState1</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476375"><span data-ttu-id="a0f62-220">ID3D11DepthStencilState</span><span class="sxs-lookup"><span data-stu-id="a0f62-220">ID3D11DepthStencilState</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/hh446828"><span data-ttu-id="a0f62-221">ID3D11RasterizerState1</span><span class="sxs-lookup"><span data-stu-id="a0f62-221">ID3D11RasterizerState1</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476588"><span data-ttu-id="a0f62-222">ID3D11SamplerState</span><span class="sxs-lookup"><span data-stu-id="a0f62-222">ID3D11SamplerState</span></span></a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174369"><span data-ttu-id="a0f62-223">IDirect3DDevice9::DrawIndexedPrimitive</span><span class="sxs-lookup"><span data-stu-id="a0f62-223">IDirect3DDevice9::DrawIndexedPrimitive</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174371"><span data-ttu-id="a0f62-224">IDirect3DDevice9::DrawPrimitive</span><span class="sxs-lookup"><span data-stu-id="a0f62-224">IDirect3DDevice9::DrawPrimitive</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476407"><span data-ttu-id="a0f62-225">ID3D11DeviceContext::Draw</span><span class="sxs-lookup"><span data-stu-id="a0f62-225">ID3D11DeviceContext::Draw</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476409"><span data-ttu-id="a0f62-226">ID3D11DeviceContext::DrawIndexed</span><span class="sxs-lookup"><span data-stu-id="a0f62-226">ID3D11DeviceContext::DrawIndexed</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173566"><span data-ttu-id="a0f62-227">ID3D11DeviceContext::DrawIndexedInstanced</span><span class="sxs-lookup"><span data-stu-id="a0f62-227">ID3D11DeviceContext::DrawIndexedInstanced</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173567"><span data-ttu-id="a0f62-228">ID3D11DeviceContext::DrawInstanced</span><span class="sxs-lookup"><span data-stu-id="a0f62-228">ID3D11DeviceContext::DrawInstanced</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173590"><span data-ttu-id="a0f62-229">ID3D11DeviceContext::IASetPrimitiveTopology</span><span class="sxs-lookup"><span data-stu-id="a0f62-229">ID3D11DeviceContext::IASetPrimitiveTopology</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173564"><span data-ttu-id="a0f62-230">ID3D11DeviceContext::DrawAuto</span><span class="sxs-lookup"><span data-stu-id="a0f62-230">ID3D11DeviceContext::DrawAuto</span></span></a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174350"><span data-ttu-id="a0f62-231">IDirect3DDevice9::BeginScene</span><span class="sxs-lookup"><span data-stu-id="a0f62-231">IDirect3DDevice9::BeginScene</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174375"><span data-ttu-id="a0f62-232">IDirect3DDevice9::EndScene</span><span class="sxs-lookup"><span data-stu-id="a0f62-232">IDirect3DDevice9::EndScene</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174372"><span data-ttu-id="a0f62-233">IDirect3DDevice9::DrawPrimitiveUP</span><span class="sxs-lookup"><span data-stu-id="a0f62-233">IDirect3DDevice9::DrawPrimitiveUP</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174370"><span data-ttu-id="a0f62-234">IDirect3DDevice9::DrawIndexedPrimitiveUP</span><span class="sxs-lookup"><span data-stu-id="a0f62-234">IDirect3DDevice9::DrawIndexedPrimitiveUP</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="a0f62-235">直接相当する要素はなし</span><span class="sxs-lookup"><span data-stu-id="a0f62-235">No direct equivalent</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174470"><span data-ttu-id="a0f62-236">IDirect3DDevice9::ShowCursor</span><span class="sxs-lookup"><span data-stu-id="a0f62-236">IDirect3DDevice9::ShowCursor</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174429"><span data-ttu-id="a0f62-237">IDirect3DDevice9::SetCursorPosition</span><span class="sxs-lookup"><span data-stu-id="a0f62-237">IDirect3DDevice9::SetCursorPosition</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174430"><span data-ttu-id="a0f62-238">IDirect3DDevice9::SetCursorProperties</span><span class="sxs-lookup"><span data-stu-id="a0f62-238">IDirect3DDevice9::SetCursorProperties</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="a0f62-239">標準的なカーソル API を使います。</span><span class="sxs-lookup"><span data-stu-id="a0f62-239">Use standard cursor APIs.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174425"><span data-ttu-id="a0f62-240">IDirect3DDevice9::Reset</span><span class="sxs-lookup"><span data-stu-id="a0f62-240">IDirect3DDevice9::Reset</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="a0f62-241">LOST デバイスと POOL_MANAGED はもう存在しません。</span><span class="sxs-lookup"><span data-stu-id="a0f62-241">LOST device and POOL_MANAGED no longer exist.</span></span> <span data-ttu-id="a0f62-242"><a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> は戻り値 <a href="https://msdn.microsoft.com/library/windows/desktop/bb509553">DXGI_ERROR_DEVICE_REMOVED</a> で失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a0f62-242"><a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> can fail with a <a href="https://msdn.microsoft.com/library/windows/desktop/bb509553">DXGI_ERROR_DEVICE_REMOVED</a> return value.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174373"><span data-ttu-id="a0f62-243">IDirect3DDevice9:DrawRectPatch</span><span class="sxs-lookup"><span data-stu-id="a0f62-243">IDirect3DDevice9:DrawRectPatch</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174374"><span data-ttu-id="a0f62-244">IDirect3DDevice9:DrawTriPatch</span><span class="sxs-lookup"><span data-stu-id="a0f62-244">IDirect3DDevice9:DrawTriPatch</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174421"><span data-ttu-id="a0f62-245">IDirect3DDevice9:LightEnable</span><span class="sxs-lookup"><span data-stu-id="a0f62-245">IDirect3DDevice9:LightEnable</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174422"><span data-ttu-id="a0f62-246">IDirect3DDevice9:MultiplyTransform</span><span class="sxs-lookup"><span data-stu-id="a0f62-246">IDirect3DDevice9:MultiplyTransform</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205798"><span data-ttu-id="a0f62-247">IDirect3DDevice9:SetLight</span><span class="sxs-lookup"><span data-stu-id="a0f62-247">IDirect3DDevice9:SetLight</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174437"><span data-ttu-id="a0f62-248">IDirect3DDevice9:SetMaterial</span><span class="sxs-lookup"><span data-stu-id="a0f62-248">IDirect3DDevice9:SetMaterial</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174438"><span data-ttu-id="a0f62-249">IDirect3DDevice9:SetNPatchMode</span><span class="sxs-lookup"><span data-stu-id="a0f62-249">IDirect3DDevice9:SetNPatchMode</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174463"><span data-ttu-id="a0f62-250">IDirect3DDevice9:SetTransform</span><span class="sxs-lookup"><span data-stu-id="a0f62-250">IDirect3DDevice9:SetTransform</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174433"><span data-ttu-id="a0f62-251">IDirect3DDevice9:SetFVF</span><span class="sxs-lookup"><span data-stu-id="a0f62-251">IDirect3DDevice9:SetFVF</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174462"><span data-ttu-id="a0f62-252">IDirect3DDevice9:SetTextureStageState</span><span class="sxs-lookup"><span data-stu-id="a0f62-252">IDirect3DDevice9:SetTextureStageState</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="a0f62-253">固定関数パイプラインは推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="a0f62-253">The fixed-function pipeline has been deprecated.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174308"><span data-ttu-id="a0f62-254">IDirect3DDevice9:CheckDepthStencilMatch</span><span class="sxs-lookup"><span data-stu-id="a0f62-254">IDirect3DDevice9:CheckDepthStencilMatch</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174309"><span data-ttu-id="a0f62-255">IDirect3DDevice9:CheckDeviceFormat</span><span class="sxs-lookup"><span data-stu-id="a0f62-255">IDirect3DDevice9:CheckDeviceFormat</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174320"><span data-ttu-id="a0f62-256">IDirect3DDevice9:GetDeviceCaps</span><span class="sxs-lookup"><span data-stu-id="a0f62-256">IDirect3DDevice9:GetDeviceCaps</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205859"><span data-ttu-id="a0f62-257">IDirect3DDevice9:ValidateDevice</span><span class="sxs-lookup"><span data-stu-id="a0f62-257">IDirect3DDevice9:ValidateDevice</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="a0f62-258">互換性ビットは機能レベルに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-258">Capability bits are replaced with feature levels.</span></span> <span data-ttu-id="a0f62-259">特定の機能レベルでは、いくつかの形式と機能の使用のみオプションです。</span><span class="sxs-lookup"><span data-stu-id="a0f62-259">Only a few format and feature usage cases are optional for any given feature level.</span></span> <span data-ttu-id="a0f62-260">これは <a href="https://msdn.microsoft.com/library/windows/desktop/ff476497">ID3D11Device::CheckFeatureSupport</a> と <a href="https://msdn.microsoft.com/library/windows/desktop/bb173536">ID3D11Device::CheckFormatSupport</a> でチェックできます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-260">These can be checked with <a href="https://msdn.microsoft.com/library/windows/desktop/ff476497">ID3D11Device::CheckFeatureSupport</a> and <a href="https://msdn.microsoft.com/library/windows/desktop/bb173536">ID3D11Device::CheckFormatSupport</a>.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="surface-format-mapping"></a><span data-ttu-id="a0f62-261">サーフェス形式のマッピング</span><span class="sxs-lookup"><span data-stu-id="a0f62-261">Surface format mapping</span></span>


<span data-ttu-id="a0f62-262">Direct3D 9 形式から DXGI 形式への変換を行う場合は、次の表を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="a0f62-262">Use the following table to convert Direct3D 9 formats into DXGI formats.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="a0f62-263">Direct3D 9 形式</span><span class="sxs-lookup"><span data-stu-id="a0f62-263">Direct3D 9 Format</span></span></th>
<th align="left"><span data-ttu-id="a0f62-264">Direct3D 11 形式</span><span class="sxs-lookup"><span data-stu-id="a0f62-264">Direct3D 11 Format</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-265">D3DFMT_UNKNOWN</span><span class="sxs-lookup"><span data-stu-id="a0f62-265">D3DFMT_UNKNOWN</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-266">DXGI_FORMAT_UNKNOWN</span><span class="sxs-lookup"><span data-stu-id="a0f62-266">DXGI_FORMAT_UNKNOWN</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-267">D3DFMT_R8G8B8</span><span class="sxs-lookup"><span data-stu-id="a0f62-267">D3DFMT_R8G8B8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-268">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-268">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-269">D3DFMT_A8R8G8B8</span><span class="sxs-lookup"><span data-stu-id="a0f62-269">D3DFMT_A8R8G8B8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-270">DXGI_FORMAT_B8G8R8A8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-270">DXGI_FORMAT_B8G8R8A8_UNORM</span></span></p>
<p><span data-ttu-id="a0f62-271">DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="a0f62-271">DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-272">D3DFMT_X8R8G8B8</span><span class="sxs-lookup"><span data-stu-id="a0f62-272">D3DFMT_X8R8G8B8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-273">DXGI_FORMAT_B8G8R8X8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-273">DXGI_FORMAT_B8G8R8X8_UNORM</span></span></p>
<p><span data-ttu-id="a0f62-274">DXGI_FORMAT_B8G8R8X8_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="a0f62-274">DXGI_FORMAT_B8G8R8X8_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-275">D3DFMT_R5G6B5</span><span class="sxs-lookup"><span data-stu-id="a0f62-275">D3DFMT_R5G6B5</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-276">DXGI_FORMAT_B5G6R5_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-276">DXGI_FORMAT_B5G6R5_UNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-277">D3DFMT_X1R5G5B5</span><span class="sxs-lookup"><span data-stu-id="a0f62-277">D3DFMT_X1R5G5B5</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-278">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-278">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-279">D3DFMT_A1R5G5B5</span><span class="sxs-lookup"><span data-stu-id="a0f62-279">D3DFMT_A1R5G5B5</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-280">DXGI_FORMAT_B5G5R5A1_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-280">DXGI_FORMAT_B5G5R5A1_UNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-281">D3DFMT_A4R4G4B4</span><span class="sxs-lookup"><span data-stu-id="a0f62-281">D3DFMT_A4R4G4B4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-282">DXGI_FORMAT_B4G4R4A4_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-282">DXGI_FORMAT_B4G4R4A4_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-283">D3DFMT_R3G3B2</span><span class="sxs-lookup"><span data-stu-id="a0f62-283">D3DFMT_R3G3B2</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-284">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-284">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-285">D3DFMT_A8</span><span class="sxs-lookup"><span data-stu-id="a0f62-285">D3DFMT_A8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-286">DXGI_FORMAT_A8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-286">DXGI_FORMAT_A8_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-287">D3DFMT_A8R3G3B2</span><span class="sxs-lookup"><span data-stu-id="a0f62-287">D3DFMT_A8R3G3B2</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-288">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-288">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-289">D3DFMT_X4R4G4B4</span><span class="sxs-lookup"><span data-stu-id="a0f62-289">D3DFMT_X4R4G4B4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-290">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-290">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-291">D3DFMT_A2B10G10R10</span><span class="sxs-lookup"><span data-stu-id="a0f62-291">D3DFMT_A2B10G10R10</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-292">DXGI_FORMAT_R10G10B10A2</span><span class="sxs-lookup"><span data-stu-id="a0f62-292">DXGI_FORMAT_R10G10B10A2</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-293">D3DFMT_A8B8G8R8</span><span class="sxs-lookup"><span data-stu-id="a0f62-293">D3DFMT_A8B8G8R8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-294">DXGI_FORMAT_R8G8B8A8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-294">DXGI_FORMAT_R8G8B8A8_UNORM</span></span></p>
<p><span data-ttu-id="a0f62-295">DXGI_FORMAT_R8G8B8A8_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="a0f62-295">DXGI_FORMAT_R8G8B8A8_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-296">D3DFMT_X8B8G8R8</span><span class="sxs-lookup"><span data-stu-id="a0f62-296">D3DFMT_X8B8G8R8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-297">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-297">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-298">D3DFMT_G16R16</span><span class="sxs-lookup"><span data-stu-id="a0f62-298">D3DFMT_G16R16</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-299">DXGI_FORMAT_R16G16_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-299">DXGI_FORMAT_R16G16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-300">D3DFMT_A2R10G10B10</span><span class="sxs-lookup"><span data-stu-id="a0f62-300">D3DFMT_A2R10G10B10</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-301">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-301">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-302">D3DFMT_A16B16G16R16</span><span class="sxs-lookup"><span data-stu-id="a0f62-302">D3DFMT_A16B16G16R16</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-303">DXGI_FORMAT_R16G16B16A16_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-303">DXGI_FORMAT_R16G16B16A16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-304">D3DFMT_A8P8</span><span class="sxs-lookup"><span data-stu-id="a0f62-304">D3DFMT_A8P8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-305">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-305">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-306">D3DFMT_P8</span><span class="sxs-lookup"><span data-stu-id="a0f62-306">D3DFMT_P8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-307">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-307">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-308">D3DFMT_L8</span><span class="sxs-lookup"><span data-stu-id="a0f62-308">D3DFMT_L8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-309">DXGI_FORMAT_R8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-309">DXGI_FORMAT_R8_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-310">
<strong>注:</strong>  direct3d9 の動作を取得するのには、その他のコンポーネントを赤を複製するシェーダーで .r スウィズルを使用します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-310">
<strong>Note</strong> Use .r swizzle in shader to duplicate red to other components to get Direct3D 9 behavior.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-311">D3DFMT_A8L8</span><span class="sxs-lookup"><span data-stu-id="a0f62-311">D3DFMT_A8L8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-312">DXGI_FORMAT_R8G8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-312">DXGI_FORMAT_R8G8_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-313">
<strong>注:</strong> 赤を複製し、direct3d9 の動作を取得するアルファ成分を緑を移動するシェーダーでスウィズル .rrrg を使用します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-313">
<strong>Note</strong> Use swizzle .rrrg in shader to duplicate red and move green to the alpha components to get Direct3D 9 behavior.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-314">D3DFMT_A4L4</span><span class="sxs-lookup"><span data-stu-id="a0f62-314">D3DFMT_A4L4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-315">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-315">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-316">D3DFMT_V8U8</span><span class="sxs-lookup"><span data-stu-id="a0f62-316">D3DFMT_V8U8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-317">DXGI_FORMAT_R8G8_SNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-317">DXGI_FORMAT_R8G8_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-318">D3DFMT_L6V5U5</span><span class="sxs-lookup"><span data-stu-id="a0f62-318">D3DFMT_L6V5U5</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-319">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-319">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-320">D3DFMT_X8L8V8U8</span><span class="sxs-lookup"><span data-stu-id="a0f62-320">D3DFMT_X8L8V8U8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-321">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-321">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-322">D3DFMT_Q8W8V8U8</span><span class="sxs-lookup"><span data-stu-id="a0f62-322">D3DFMT_Q8W8V8U8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-323">DXGI_FORMAT_R8G8B8A8_SNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-323">DXGI_FORMAT_R8G8B8A8_SNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-324">D3DFMT_V16U16</span><span class="sxs-lookup"><span data-stu-id="a0f62-324">D3DFMT_V16U16</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-325">DXGI_FORMAT_R16G16_SNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-325">DXGI_FORMAT_R16G16_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-326">D3DFMT_W11V11U10</span><span class="sxs-lookup"><span data-stu-id="a0f62-326">D3DFMT_W11V11U10</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-327">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-327">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-328">D3DFMT_A2W10V10U10</span><span class="sxs-lookup"><span data-stu-id="a0f62-328">D3DFMT_A2W10V10U10</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-329">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-329">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-330">D3DFMT_UYVY</span><span class="sxs-lookup"><span data-stu-id="a0f62-330">D3DFMT_UYVY</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-331">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-331">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-332">D3DFMT_R8G8_B8G8</span><span class="sxs-lookup"><span data-stu-id="a0f62-332">D3DFMT_R8G8_B8G8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-333">DXGI_FORMAT_G8R8_G8B8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-333">DXGI_FORMAT_G8R8_G8B8_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-334">
<strong>注:</strong>  direct3d9 でのデータは 255.0f、スケール アップされたが、これは、シェーダーで処理できます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-334">
<strong>Note</strong> In Direct3D 9 the data was scaled up by 255.0f, but this can be handled in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-335">D3DFMT_YUY2</span><span class="sxs-lookup"><span data-stu-id="a0f62-335">D3DFMT_YUY2</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-336">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-336">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-337">D3DFMT_G8R8_G8B8</span><span class="sxs-lookup"><span data-stu-id="a0f62-337">D3DFMT_G8R8_G8B8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-338">DXGI_FORMAT_R8G8_B8G8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-338">DXGI_FORMAT_R8G8_B8G8_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-339">
<strong>注:</strong>  direct3d9 でのデータは 255.0f、スケール アップされたが、これは、シェーダーで処理できます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-339">
<strong>Note</strong> In Direct3D 9 the data was scaled up by 255.0f, but this can be handled in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-340">D3DFMT_DXT1</span><span class="sxs-lookup"><span data-stu-id="a0f62-340">D3DFMT_DXT1</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-341">DXGI_FORMAT_BC1_UNORM と DXGI_FORMAT_BC1_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="a0f62-341">DXGI_FORMAT_BC1_UNORM & DXGI_FORMAT_BC1_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-342">D3DFMT_DXT2</span><span class="sxs-lookup"><span data-stu-id="a0f62-342">D3DFMT_DXT2</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-343">DXGI_FORMAT_BC1_UNORM と DXGI_FORMAT_BC1_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="a0f62-343">DXGI_FORMAT_BC1_UNORM & DXGI_FORMAT_BC1_UNORM_SRGB</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-344">
<strong>注:</strong>  DXT1 と DXT2 は同じ API とハードウェアの観点からです。</span><span class="sxs-lookup"><span data-stu-id="a0f62-344">
<strong>Note</strong> DXT1 and DXT2 are the same from an API/hardware perspective.</span></span> <span data-ttu-id="a0f62-345">唯一の違いは、プリマルチプライ済みアルファが使われるかどうかです。これはアプリケーションで追跡でき、別の形式は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="a0f62-345">The only difference is whether premultiplied alpha is used, which can be tracked by an application and doesn't need a separate format.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-346">D3DFMT_DXT3</span><span class="sxs-lookup"><span data-stu-id="a0f62-346">D3DFMT_DXT3</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-347">DXGI_FORMAT_BC2_UNORM と DXGI_FORMAT_BC2_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="a0f62-347">DXGI_FORMAT_BC2_UNORM & DXGI_FORMAT_BC2_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-348">D3DFMT_DXT4</span><span class="sxs-lookup"><span data-stu-id="a0f62-348">D3DFMT_DXT4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-349">DXGI_FORMAT_BC2_UNORM と DXGI_FORMAT_BC2_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="a0f62-349">DXGI_FORMAT_BC2_UNORM & DXGI_FORMAT_BC2_UNORM_SRGB</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-350">
<strong>注:</strong>  DXT3 と DXT4 は同じ API とハードウェアの観点からです。</span><span class="sxs-lookup"><span data-stu-id="a0f62-350">
<strong>Note</strong> DXT3 and DXT4 are the same from an API/hardware perspective.</span></span> <span data-ttu-id="a0f62-351">唯一の違いは、プリマルチプライ済みアルファが使われるかどうかです。これはアプリケーションで追跡でき、別の形式は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="a0f62-351">The only difference is whether premultiplied alpha is used, which can be tracked by an application and doesn't need a separate format.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-352">D3DFMT_DXT5</span><span class="sxs-lookup"><span data-stu-id="a0f62-352">D3DFMT_DXT5</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-353">DXGI_FORMAT_BC3_UNORM と DXGI_FORMAT_BC3_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="a0f62-353">DXGI_FORMAT_BC3_UNORM & DXGI_FORMAT_BC3_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-354">D3DFMT_D16 と D3DFMT_D16_LOCKABLE</span><span class="sxs-lookup"><span data-stu-id="a0f62-354">D3DFMT_D16 & D3DFMT_D16_LOCKABLE</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-355">DXGI_FORMAT_D16_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-355">DXGI_FORMAT_D16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-356">D3DFMT_D32</span><span class="sxs-lookup"><span data-stu-id="a0f62-356">D3DFMT_D32</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-357">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-357">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-358">D3DFMT_D15S1</span><span class="sxs-lookup"><span data-stu-id="a0f62-358">D3DFMT_D15S1</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-359">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-359">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-360">D3DFMT_D24S8</span><span class="sxs-lookup"><span data-stu-id="a0f62-360">D3DFMT_D24S8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-361">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-361">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-362">D3DFMT_D24X8</span><span class="sxs-lookup"><span data-stu-id="a0f62-362">D3DFMT_D24X8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-363">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-363">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-364">D3DFMT_D24X4S4</span><span class="sxs-lookup"><span data-stu-id="a0f62-364">D3DFMT_D24X4S4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-365">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-365">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-366">D3DFMT_D16</span><span class="sxs-lookup"><span data-stu-id="a0f62-366">D3DFMT_D16</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-367">DXGI_FORMAT_D16_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-367">DXGI_FORMAT_D16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-368">D3DFMT_D32F_LOCKABLE</span><span class="sxs-lookup"><span data-stu-id="a0f62-368">D3DFMT_D32F_LOCKABLE</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-369">DXGI_FORMAT_D32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-369">DXGI_FORMAT_D32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-370">D3DFMT_D24FS8</span><span class="sxs-lookup"><span data-stu-id="a0f62-370">D3DFMT_D24FS8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-371">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-371">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-372">D3DFMT_S1D15</span><span class="sxs-lookup"><span data-stu-id="a0f62-372">D3DFMT_S1D15</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-373">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-373">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-374">D3DFMT_S8D24</span><span class="sxs-lookup"><span data-stu-id="a0f62-374">D3DFMT_S8D24</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-375">DXGI_FORMAT_D24_UNORM_S8_UINT</span><span class="sxs-lookup"><span data-stu-id="a0f62-375">DXGI_FORMAT_D24_UNORM_S8_UINT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-376">D3DFMT_X8D24</span><span class="sxs-lookup"><span data-stu-id="a0f62-376">D3DFMT_X8D24</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-377">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-377">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-378">D3DFMT_X4S4D24</span><span class="sxs-lookup"><span data-stu-id="a0f62-378">D3DFMT_X4S4D24</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-379">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-379">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-380">D3DFMT_L16</span><span class="sxs-lookup"><span data-stu-id="a0f62-380">D3DFMT_L16</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-381">DXGI_FORMAT_R16_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-381">DXGI_FORMAT_R16_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-382">
<strong>注:</strong>  D3D9 の動作を取得するには、その他のコンポーネントを赤を複製するシェーダーで .r スウィズルを使用します。</span><span class="sxs-lookup"><span data-stu-id="a0f62-382">
<strong>Note</strong> Use .r swizzle in shader to duplicate red to other components to get D3D9 behavior.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-383">D3DFMT_INDEX16</span><span class="sxs-lookup"><span data-stu-id="a0f62-383">D3DFMT_INDEX16</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-384">DXGI_FORMAT_R16_UINT</span><span class="sxs-lookup"><span data-stu-id="a0f62-384">DXGI_FORMAT_R16_UINT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-385">D3DFMT_INDEX32</span><span class="sxs-lookup"><span data-stu-id="a0f62-385">D3DFMT_INDEX32</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-386">DXGI_FORMAT_R32_UINT</span><span class="sxs-lookup"><span data-stu-id="a0f62-386">DXGI_FORMAT_R32_UINT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-387">D3DFMT_Q16W16V16U16</span><span class="sxs-lookup"><span data-stu-id="a0f62-387">D3DFMT_Q16W16V16U16</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-388">DXGI_FORMAT_R16G16B16A16_SNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-388">DXGI_FORMAT_R16G16B16A16_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-389">D3DFMT_MULTI2_ARGB8</span><span class="sxs-lookup"><span data-stu-id="a0f62-389">D3DFMT_MULTI2_ARGB8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-390">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-390">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-391">D3DFMT_R16F</span><span class="sxs-lookup"><span data-stu-id="a0f62-391">D3DFMT_R16F</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-392">DXGI_FORMAT_R16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-392">DXGI_FORMAT_R16_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-393">D3DFMT_G16R16F</span><span class="sxs-lookup"><span data-stu-id="a0f62-393">D3DFMT_G16R16F</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-394">DXGI_FORMAT_R16G16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-394">DXGI_FORMAT_R16G16_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-395">D3DFMT_A16B16G16R16F</span><span class="sxs-lookup"><span data-stu-id="a0f62-395">D3DFMT_A16B16G16R16F</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-396">DXGI_FORMAT_R16G16B16A16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-396">DXGI_FORMAT_R16G16B16A16_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-397">D3DFMT_R32F</span><span class="sxs-lookup"><span data-stu-id="a0f62-397">D3DFMT_R32F</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-398">DXGI_FORMAT_R32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-398">DXGI_FORMAT_R32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-399">D3DFMT_G32R32F</span><span class="sxs-lookup"><span data-stu-id="a0f62-399">D3DFMT_G32R32F</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-400">DXGI_FORMAT_R32G32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-400">DXGI_FORMAT_R32G32_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-401">D3DFMT_A32B32G32R32F</span><span class="sxs-lookup"><span data-stu-id="a0f62-401">D3DFMT_A32B32G32R32F</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-402">DXGI_FORMAT_R32G32B32A32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-402">DXGI_FORMAT_R32G32B32A32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-403">D3DFMT_CxV8U8</span><span class="sxs-lookup"><span data-stu-id="a0f62-403">D3DFMT_CxV8U8</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-404">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-404">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-405">D3DDECLTYPE_FLOAT1</span><span class="sxs-lookup"><span data-stu-id="a0f62-405">D3DDECLTYPE_FLOAT1</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-406">DXGI_FORMAT_R32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-406">DXGI_FORMAT_R32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-407">D3DDECLTYPE_FLOAT2</span><span class="sxs-lookup"><span data-stu-id="a0f62-407">D3DDECLTYPE_FLOAT2</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-408">DXGI_FORMAT_R32G32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-408">DXGI_FORMAT_R32G32_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-409">D3DDECLTYPE_FLOAT3</span><span class="sxs-lookup"><span data-stu-id="a0f62-409">D3DDECLTYPE_FLOAT3</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-410">DXGI_FORMAT_R32G32B32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-410">DXGI_FORMAT_R32G32B32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-411">D3DDECLTYPE_FLOAT4</span><span class="sxs-lookup"><span data-stu-id="a0f62-411">D3DDECLTYPE_FLOAT4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-412">DXGI_FORMAT_R32G32B32A32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-412">DXGI_FORMAT_R32G32B32A32_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-413">D3DDECLTYPED3DCOLOR</span><span class="sxs-lookup"><span data-stu-id="a0f62-413">D3DDECLTYPED3DCOLOR</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-414">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-414">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-415">D3DDECLTYPE_UBYTE4</span><span class="sxs-lookup"><span data-stu-id="a0f62-415">D3DDECLTYPE_UBYTE4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-416">DXGI_FORMAT_R8G8B8A8_UINT</span><span class="sxs-lookup"><span data-stu-id="a0f62-416">DXGI_FORMAT_R8G8B8A8_UINT</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-417">
<strong>注:</strong>  、シェーダーは UINT 値を取得しますが、浮動小数点値が必要な場合は、direct3d9 スタイル (0.0 f、1.0 f.255.f)、UINT をシェーダーで float32 に変換できます。</span><span class="sxs-lookup"><span data-stu-id="a0f62-417">
<strong>Note</strong> The shader gets UINT values, but if Direct3D 9 style integral floats are needed (0.0f, 1.0f... 255.f), UINT can just be converted to float32 in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-418">D3DDECLTYPE_SHORT2</span><span class="sxs-lookup"><span data-stu-id="a0f62-418">D3DDECLTYPE_SHORT2</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-419">DXGI_FORMAT_R16G16_SINT</span><span class="sxs-lookup"><span data-stu-id="a0f62-419">DXGI_FORMAT_R16G16_SINT</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-420">
<strong>注:</strong>  、シェーダーは SINT 値を取得しますが、だけ SINT をシェーダーで float32 に変換する direct3d9 スタイルの integral が必要な場合です。</span><span class="sxs-lookup"><span data-stu-id="a0f62-420">
<strong>Note</strong> The shader gets SINT values, but if Direct3D 9 style integral floats are needed, SINT can just be converted to float32 in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-421">D3DDECLTYPE_SHORT4</span><span class="sxs-lookup"><span data-stu-id="a0f62-421">D3DDECLTYPE_SHORT4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-422">DXGI_FORMAT_R16G16B16A16_SINT</span><span class="sxs-lookup"><span data-stu-id="a0f62-422">DXGI_FORMAT_R16G16B16A16_SINT</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-423">
<strong>注:</strong>  、シェーダーは SINT 値を取得しますが、だけ SINT をシェーダーで float32 に変換する direct3d9 スタイルの integral が必要な場合です。</span><span class="sxs-lookup"><span data-stu-id="a0f62-423">
<strong>Note</strong> The shader gets SINT values, but if Direct3D 9 style integral floats are needed, SINT can just be converted to float32 in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-424">D3DDECLTYPE_UBYTE4N</span><span class="sxs-lookup"><span data-stu-id="a0f62-424">D3DDECLTYPE_UBYTE4N</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-425">DXGI_FORMAT_R8G8B8A8_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-425">DXGI_FORMAT_R8G8B8A8_UNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-426">D3DDECLTYPE_SHORT2N</span><span class="sxs-lookup"><span data-stu-id="a0f62-426">D3DDECLTYPE_SHORT2N</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-427">DXGI_FORMAT_R16G16_SNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-427">DXGI_FORMAT_R16G16_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-428">D3DDECLTYPE_SHORT4N</span><span class="sxs-lookup"><span data-stu-id="a0f62-428">D3DDECLTYPE_SHORT4N</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-429">DXGI_FORMAT_R16G16B16A16_SNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-429">DXGI_FORMAT_R16G16B16A16_SNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-430">D3DDECLTYPE_USHORT2N</span><span class="sxs-lookup"><span data-stu-id="a0f62-430">D3DDECLTYPE_USHORT2N</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-431">DXGI_FORMAT_R16G16_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-431">DXGI_FORMAT_R16G16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-432">D3DDECLTYPE_USHORT4N</span><span class="sxs-lookup"><span data-stu-id="a0f62-432">D3DDECLTYPE_USHORT4N</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-433">DXGI_FORMAT_R16G16B16A16_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-433">DXGI_FORMAT_R16G16B16A16_UNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-434">D3DDECLTYPE_UDEC3</span><span class="sxs-lookup"><span data-stu-id="a0f62-434">D3DDECLTYPE_UDEC3</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-435">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-435">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-436">D3DDECLTYPE_DEC3N</span><span class="sxs-lookup"><span data-stu-id="a0f62-436">D3DDECLTYPE_DEC3N</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-437">使用できません</span><span class="sxs-lookup"><span data-stu-id="a0f62-437">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-438">D3DDECLTYPE_FLOAT16_2</span><span class="sxs-lookup"><span data-stu-id="a0f62-438">D3DDECLTYPE_FLOAT16_2</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-439">DXGI_FORMAT_R16G16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-439">DXGI_FORMAT_R16G16_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-440">D3DDECLTYPE_FLOAT16_4</span><span class="sxs-lookup"><span data-stu-id="a0f62-440">D3DDECLTYPE_FLOAT16_4</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-441">DXGI_FORMAT_R16G16B16A16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="a0f62-441">DXGI_FORMAT_R16G16B16A16_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="a0f62-442">FourCC 'ATI1'</span><span class="sxs-lookup"><span data-stu-id="a0f62-442">FourCC 'ATI1'</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-443">DXGI_FORMAT_BC4_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-443">DXGI_FORMAT_BC4_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-444">
<strong>注:</strong> 機能レベル 10.0 以降が必要です</span><span class="sxs-lookup"><span data-stu-id="a0f62-444">
<strong>Note</strong> Requires Feature Level 10.0 or later</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="a0f62-445">FourCC 'ATI2'</span><span class="sxs-lookup"><span data-stu-id="a0f62-445">FourCC 'ATI2'</span></span></p></td>
<td align="left"><p><span data-ttu-id="a0f62-446">DXGI_FORMAT_BC5_UNORM</span><span class="sxs-lookup"><span data-stu-id="a0f62-446">DXGI_FORMAT_BC5_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="a0f62-447">
<strong>注:</strong> 機能レベル 10.0 以降が必要です</span><span class="sxs-lookup"><span data-stu-id="a0f62-447">
<strong>Note</strong> Requires Feature Level 10.0 or later</span></span>
</div>
<div>
 
</div></td>
</tr>
</tbody>
</table>

 

 

 




