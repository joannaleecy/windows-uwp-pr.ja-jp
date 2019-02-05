---
title: DirectX 11 API への DirectX 9 の機能のマッピング
description: Direct3D 9 ゲームで使う機能が Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) にどのように変換されるかについて説明します。
ms.assetid: 3aa8a114-4e47-ae0a-9447-88ba324377b8
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 9, DirectX 11, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 0cfaa071ea0182ef5fac264e85d919be5744d15d
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9050675"
---
# <a name="map-directx-9-features-to-directx-11-apis"></a><span data-ttu-id="06c22-104">DirectX 11 API への DirectX 9 の機能のマッピング</span><span class="sxs-lookup"><span data-stu-id="06c22-104">Map DirectX 9 features to DirectX 11 APIs</span></span>



**<span data-ttu-id="06c22-105">概要</span><span class="sxs-lookup"><span data-stu-id="06c22-105">Summary</span></span>**

-   [<span data-ttu-id="06c22-106">DirectX の移植の計画</span><span class="sxs-lookup"><span data-stu-id="06c22-106">Plan your DirectX port</span></span>](plan-your-directx-port.md)
-   [<span data-ttu-id="06c22-107">Direct3D 9 と Direct3D 11 の間の重要な変更点</span><span class="sxs-lookup"><span data-stu-id="06c22-107">Important changes from Direct3D 9 to Direct3D 11</span></span>](understand-direct3d-11-1-concepts.md)
-   <span data-ttu-id="06c22-108">機能のマッピング</span><span class="sxs-lookup"><span data-stu-id="06c22-108">Feature mapping</span></span>


<span data-ttu-id="06c22-109">Direct3D 9 ゲームで使う機能が Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) にどのように変換されるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="06c22-109">Understand how the features your Direct3D 9 game uses will translate to Direct3D 11 and the Universal Windows Platform (UWP).</span></span>

## <a name="mapping-direct3d-9-to-directx-11-apis"></a><span data-ttu-id="06c22-110">DirectX 11 API への Direct3D 9 のマッピング</span><span class="sxs-lookup"><span data-stu-id="06c22-110">Mapping Direct3D 9 to DirectX 11 APIs</span></span>


<span data-ttu-id="06c22-111">[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) はこれまでと同じく DirectX グラフィックスの土台ですが、API は DirectX 9 以降変更されています。</span><span class="sxs-lookup"><span data-stu-id="06c22-111">[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) is still the foundation of DirectX graphics, but the API has changed since DirectX 9:</span></span>

-   <span data-ttu-id="06c22-112">Microsoft DirectX Graphic Infrastructure (DXGI) はグラフィックス アダプターを設定するために使われます。</span><span class="sxs-lookup"><span data-stu-id="06c22-112">Microsoft DirectX Graphics Infrastructure (DXGI) is used to set up graphics adapters.</span></span> <span data-ttu-id="06c22-113">バッファー形式の選択、スワップ チェーンの作成、フレームの表示、共有リソースの作成には [DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534) を使います。</span><span class="sxs-lookup"><span data-stu-id="06c22-113">Use [DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534) to select buffer formats, create swap chains, present frames, and create shared resources.</span></span> <span data-ttu-id="06c22-114">「[DXGI の概要](https://msdn.microsoft.com/library/windows/desktop/bb205075)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-114">See [DXGI Overview](https://msdn.microsoft.com/library/windows/desktop/bb205075).</span></span>
-   <span data-ttu-id="06c22-115">Direct3D のデバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。</span><span class="sxs-lookup"><span data-stu-id="06c22-115">A Direct3D device context is used to set pipeline state and generate rendering commands.</span></span> <span data-ttu-id="06c22-116">ほとんどのサンプルではイミディエイト コンテキストを使ってデバイスに直接レンダリングしていますが、Direct3D 11 ではマルチスレッド レンダリングもサポートされており、その場合は遅延コンテキストが使われます。</span><span class="sxs-lookup"><span data-stu-id="06c22-116">Most of our samples use an immediate context to render directly to the device; Direct3D 11 also supports multithreaded rendering, in which case deferred contexts are used.</span></span> <span data-ttu-id="06c22-117">「[Direct3D 11 のデバイスについて](https://msdn.microsoft.com/library/windows/desktop/ff476880)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-117">See [Introduction to a Device in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476880).</span></span>
-   <span data-ttu-id="06c22-118">一部の機能は非推奨になっていますが、特に固定関数パイプラインが推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="06c22-118">Some features have been deprecated, most notably the fixed function pipeline.</span></span> <span data-ttu-id="06c22-119">「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-119">See [Deprecated Features](https://msdn.microsoft.com/library/windows/desktop/cc308047).</span></span>

<span data-ttu-id="06c22-120">Direct3D 11 の機能の完全な一覧については、「[Direct3D 11 の機能](https://msdn.microsoft.com/library/windows/desktop/ff476342)」と「[Direct3D 11 の機能](https://msdn.microsoft.com/library/windows/desktop/hh404562)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-120">For a full list of Direct3D 11 features, see [Direct3D 11 Features](https://msdn.microsoft.com/library/windows/desktop/ff476342) and [Direct3D 11 Features](https://msdn.microsoft.com/library/windows/desktop/hh404562).</span></span>

## <a name="moving-from-direct2d-9-to-direct2d-11"></a><span data-ttu-id="06c22-121">Direct2D 9 から Direct2D 11 への移行</span><span class="sxs-lookup"><span data-stu-id="06c22-121">Moving from Direct2D 9 to Direct2D 11</span></span>


<span data-ttu-id="06c22-122">[Direct2D (Windows)](https://msdn.microsoft.com/library/windows/desktop/dd370990) は、これまでどおり DirectX グラフィックスと Windows の重要な一部です。</span><span class="sxs-lookup"><span data-stu-id="06c22-122">[Direct2D (Windows)](https://msdn.microsoft.com/library/windows/desktop/dd370990) is still an important part of DirectX graphics and Windows.</span></span> <span data-ttu-id="06c22-123">これまでどおり Direct2D を使って 2D ゲームを描画したり、Direct3D の上にオーバーレイ (HUD) を描画したりできます。</span><span class="sxs-lookup"><span data-stu-id="06c22-123">You can still use Direct2D to draw 2D games, and to draw overlays (HUDs) on top of Direct3D.</span></span>

<span data-ttu-id="06c22-124">Direct2D は Direct3D の上で実行されます。2D ゲームは API を使って実装できます。</span><span class="sxs-lookup"><span data-stu-id="06c22-124">Direct2D runs on top of Direct3D; 2D games can be implemented using either API.</span></span> <span data-ttu-id="06c22-125">たとえば、Direct3D を使って実装される 2D ゲームでは、正投影を使ったり、Z 値を設定してプリミティブの描画の順序を制御したり、ピクセル シェーダーを使って特殊効果を追加したりできます。</span><span class="sxs-lookup"><span data-stu-id="06c22-125">For example, a 2D game implemented using Direct3D can use orthographic projection, set Z-values to control the drawing order of primitives, and use pixel shaders to add special effects.</span></span>

<span data-ttu-id="06c22-126">Direct2D は Direct3D に基づいているため、DXGI とデバイス コンテキストも使います。</span><span class="sxs-lookup"><span data-stu-id="06c22-126">Since Direct2D is based on Direct3D it also uses DXGI and device contexts.</span></span> <span data-ttu-id="06c22-127">「[Direct2D API の概要](https://msdn.microsoft.com/library/windows/desktop/dd317121)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-127">See [Direct2D API Overview](https://msdn.microsoft.com/library/windows/desktop/dd317121).</span></span>

<span data-ttu-id="06c22-128">[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) API は、Direct2D を使って書式付きテキストのサポートを追加します。</span><span class="sxs-lookup"><span data-stu-id="06c22-128">The [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) API adds support for formatted text using Direct2D.</span></span> <span data-ttu-id="06c22-129">「[DirectWrite の紹介](https://msdn.microsoft.com/library/windows/desktop/dd371554)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-129">See [Introducing DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd371554).</span></span>

## <a name="replace-deprecated-helper-libraries"></a><span data-ttu-id="06c22-130">推奨されなくなったヘルパー ライブラリの置き換え</span><span class="sxs-lookup"><span data-stu-id="06c22-130">Replace deprecated helper libraries</span></span>


<span data-ttu-id="06c22-131">D3DX と DXUT は推奨されなくなったため、UWP ゲームでは使うことができません。</span><span class="sxs-lookup"><span data-stu-id="06c22-131">D3DX and DXUT are deprecated and cannot be used by UWP games.</span></span> <span data-ttu-id="06c22-132">これらのヘルパー ライブラリでは、テクスチャの読み込みやメッシュの読み込みなどのタスク用にリソースが提供されていました。</span><span class="sxs-lookup"><span data-stu-id="06c22-132">These helper libraries provided resources for tasks such as texture loading and mesh loading.</span></span>

-   <span data-ttu-id="06c22-133">「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」では、ウィンドウの設定、Direct3D の初期化、基本的な 3D レンダリングの方法を示します。</span><span class="sxs-lookup"><span data-stu-id="06c22-133">The [Simple port from Direct3D 9 to UWP](walkthrough--simple-port-from-direct3d-9-to-11-1.md) walkthrough demonstrates how to set up a window, initialize Direct3D, and do basic 3D rendering.</span></span>
-   <span data-ttu-id="06c22-134">「[DirectX を使った単純なユニバーサル Windows プラットフォーム (UWP) ゲームの作成](tutorial--create-your-first-uwp-directx-game.md)」では、グラフィックス、ファイルの読み込み、UI、コントロール、サウンドなど、一般的なゲーム プログラミング タスクを示します。</span><span class="sxs-lookup"><span data-stu-id="06c22-134">The [Simple UWP game with DirectX](tutorial--create-your-first-uwp-directx-game.md) walkthrough demonstrates common game programming tasks including graphics, loading files, UI, controls, and sound.</span></span>
-   <span data-ttu-id="06c22-135">[DirectX ツール キット](https://go.microsoft.com/fwlink/p/?LinkID=248929) コミュニティのプロジェクトには、Direct3D 11 および UWP アプリで利用できるヘルパー クラスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="06c22-135">The [DirectX Tool Kit](https://go.microsoft.com/fwlink/p/?LinkID=248929) community project offers helper classes for use with Direct3D 11 and UWP apps.</span></span>

## <a name="move-shader-programs-from-fx-to-hlsl"></a><span data-ttu-id="06c22-136">FX から HLSL へのシェーダー プログラムの移行</span><span class="sxs-lookup"><span data-stu-id="06c22-136">Move shader programs from FX to HLSL</span></span>


<span data-ttu-id="06c22-137">Effects を含め、D3DX ユーティリティ ライブラリ (D3DX 9、D3DX 10、D3DX 11) は、UWP では推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="06c22-137">The D3DX utility library (D3DX 9, D3DX 10, and D3DX 11), including Effects, is deprecated for UWP.</span></span> <span data-ttu-id="06c22-138">UWP のすべての DirectX ゲームは、Effects を使わずに、[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561) を使ってグラフィックス パイプラインを実行します。</span><span class="sxs-lookup"><span data-stu-id="06c22-138">All DirectX games for UWP drive the graphics pipeline using [HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561) without Effects.</span></span>

<span data-ttu-id="06c22-139">Visual Studio は、シェーダー オブジェクトをコンパイルするために FXC をバックグラウンドで使います。</span><span class="sxs-lookup"><span data-stu-id="06c22-139">Visual Studio still uses FXC under the hood to compile shader objects.</span></span> <span data-ttu-id="06c22-140">UWP ゲームのシェーダーは事前にコンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="06c22-140">UWP game shaders are compiled ahead of time.</span></span> <span data-ttu-id="06c22-141">バイトコードは実行時に読み込まれ、各シェーダー リソースは適切なレンダリング パスの間にグラフィックス パイプラインにバインドされます。</span><span class="sxs-lookup"><span data-stu-id="06c22-141">The bytecode is loaded at runtime, then each shader resource is bound to the graphics pipeline during the appropriate rendering pass.</span></span> <span data-ttu-id="06c22-142">シェーダーを独自の別の .HLSL ファイルに移し、レンダリング テクノロジを C++ コードで実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="06c22-142">Shaders should be moved to their own separate .HLSL files and rendering techniques should be implemented in your C++ code.</span></span>

<span data-ttu-id="06c22-143">シェーダー リソースの読み込みの概要については、「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-143">For a quick look at loading shader resources see [Simple port from Direct3D 9 to UWP](walkthrough--simple-port-from-direct3d-9-to-11-1.md).</span></span>

<span data-ttu-id="06c22-144">Direct3D 11 ではシェーダー モデル 5 が導入されましたが、これには Direct3D 機能レベル 11\_0 以上が必要です。</span><span class="sxs-lookup"><span data-stu-id="06c22-144">Direct3D 11 introduced Shader Model 5, which requires Direct3D feature level 11\_0 (or above).</span></span> <span data-ttu-id="06c22-145">「[Direct3D 11 の HLSL シェーダー モデル 5 の機能](https://msdn.microsoft.com/library/windows/desktop/ff471419)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-145">See [HLSL Shader Model 5 Features for Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff471419).</span></span>

## <a name="replace-xnamath-and-d3dxmath"></a><span data-ttu-id="06c22-146">XNAMath と D3DXMath の置き換え</span><span class="sxs-lookup"><span data-stu-id="06c22-146">Replace XNAMath and D3DXMath</span></span>


<span data-ttu-id="06c22-147">XNAMath (または D3DXMath) を使ったコードは [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) に移行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="06c22-147">Code using XNAMath (or D3DXMath) should be migrated to [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833).</span></span> <span data-ttu-id="06c22-148">DirectXMath には、x86、x64、ARM の間で移植可能な型が含まれています。</span><span class="sxs-lookup"><span data-stu-id="06c22-148">DirectXMath includes types that are portable across x86, x64, and ARM.</span></span> <span data-ttu-id="06c22-149">「[XNA Math ライブラリからのコードの移行](https://msdn.microsoft.com/library/windows/desktop/ee418730)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-149">See [Code Migration from the XNA Math Library](https://msdn.microsoft.com/library/windows/desktop/ee418730).</span></span>

<span data-ttu-id="06c22-150">DirectXMath の浮動小数点型はシェーダーで使うと便利です。</span><span class="sxs-lookup"><span data-stu-id="06c22-150">Note that DirectXMath float types are convenient for use with shaders.</span></span> <span data-ttu-id="06c22-151">たとえば、[**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) と [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) は、定数バッファーのデータの整列に便利です。</span><span class="sxs-lookup"><span data-stu-id="06c22-151">For example [**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) and [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) conveniently align data for constant buffers.</span></span>

## <a name="replace-directsound-with-xaudio2-and-background-audio"></a><span data-ttu-id="06c22-152">XAudio2 (とバックグラウンド オーディオ) への DirectSound の置き換え</span><span class="sxs-lookup"><span data-stu-id="06c22-152">Replace DirectSound with XAudio2 (and background audio)</span></span>


<span data-ttu-id="06c22-153">DirectSound では、UWP はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="06c22-153">DirectSound is not supported for UWP:</span></span>

-   <span data-ttu-id="06c22-154">ゲームにサウンド効果を追加するには [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) を使います。</span><span class="sxs-lookup"><span data-stu-id="06c22-154">Use [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) to add sound effects to your game.</span></span>

##  <a name="replace-directinput-with-xinput-and-uwp-apis"></a><span data-ttu-id="06c22-155">XInput と UWP API への DirectInput の置き換え</span><span class="sxs-lookup"><span data-stu-id="06c22-155">Replace DirectInput with XInput and UWP APIs</span></span>


<span data-ttu-id="06c22-156">DirectInput では、UWP はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="06c22-156">DirectInput is not supported for UWP:</span></span>

-   <span data-ttu-id="06c22-157">マウス、キーボード、タッチ入力には [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の入力イベント コールバックを使います。</span><span class="sxs-lookup"><span data-stu-id="06c22-157">Use [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) input event callbacks for mouse, keyboard, and touch input.</span></span>
-   <span data-ttu-id="06c22-158">ゲーム コントローラーのサポート (とゲーム コントローラーのヘッドセットのサポート) には [XInput](https://msdn.microsoft.com/library/windows/desktop/ee417001) 1.4 を使います。</span><span class="sxs-lookup"><span data-stu-id="06c22-158">Use [XInput](https://msdn.microsoft.com/library/windows/desktop/ee417001) 1.4 for game controller support (and game controller headset support).</span></span> <span data-ttu-id="06c22-159">デスクトップと UWP に共有コード ベースを使う場合は、下位互換性について、「[XInput のバージョン](https://msdn.microsoft.com/library/windows/desktop/hh405051)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-159">If you are using a shared code base for desktop and UWP, see [XInput Versions](https://msdn.microsoft.com/library/windows/desktop/hh405051) for information on backwards compatibility.</span></span>
-   <span data-ttu-id="06c22-160">ゲームでアプリ バーを使う必要がある場合は、[**EdgeGesture**](https://msdn.microsoft.com/library/windows/apps/hh701600) イベントに登録します。</span><span class="sxs-lookup"><span data-stu-id="06c22-160">Register for [**EdgeGesture**](https://msdn.microsoft.com/library/windows/apps/hh701600) events if your game needs to use the app bar.</span></span>

## <a name="use-microsoft-media-foundation-instead-of-directshow"></a><span data-ttu-id="06c22-161">DirectShow の代わりに Microsoft メディア ファンデーションを使う</span><span class="sxs-lookup"><span data-stu-id="06c22-161">Use Microsoft Media Foundation instead of DirectShow</span></span>


<span data-ttu-id="06c22-162">DirectShow は DirectX API (または Windows API) にはもう含まれていません。</span><span class="sxs-lookup"><span data-stu-id="06c22-162">DirectShow is no longer part of the DirectX API (or the Windows API).</span></span> <span data-ttu-id="06c22-163">[Microsoft メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197)は共有サーフェイスを使って Direct3D にビデオ コンテンツを提供します。</span><span class="sxs-lookup"><span data-stu-id="06c22-163">[Microsoft Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197) provides video content to Direct3D using shared surfaces.</span></span> <span data-ttu-id="06c22-164">「[Direct3D 11 のビデオ API](https://msdn.microsoft.com/library/windows/desktop/hh447677)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-164">See [Direct3D 11 Video APIs](https://msdn.microsoft.com/library/windows/desktop/hh447677).</span></span>

## <a name="replace-directplay-with-networking-code"></a><span data-ttu-id="06c22-165">ネットワーク コードへの DirectPlay の置き換え</span><span class="sxs-lookup"><span data-stu-id="06c22-165">Replace DirectPlay with networking code</span></span>


<span data-ttu-id="06c22-166">Microsoft DirectPlay は推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="06c22-166">Microsoft DirectPlay has been deprecated.</span></span> <span data-ttu-id="06c22-167">ゲームでネットワーク サービスを使う場合は、UWP の要件に準拠しているネットワーク コードを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="06c22-167">If your game uses network services, you need to provide networking code that complies with UWP requirements.</span></span> <span data-ttu-id="06c22-168">次の API を使います。</span><span class="sxs-lookup"><span data-stu-id="06c22-168">Use the following APIs:</span></span>

-   [<span data-ttu-id="06c22-169">UWP アプリの Win32 と COM (ネットワーク) (Windows)</span><span class="sxs-lookup"><span data-stu-id="06c22-169">Win32 and COM for UWP apps (networking) (Windows)</span></span>](https://msdn.microsoft.com/library/windows/apps/br205759)
-   [**<span data-ttu-id="06c22-170">Windows.Networking 名前空間 (Windows)</span><span class="sxs-lookup"><span data-stu-id="06c22-170">Windows.Networking namespace (Windows)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br207124)
-   [**<span data-ttu-id="06c22-171">Windows.Networking.Sockets 名前空間 (Windows)</span><span class="sxs-lookup"><span data-stu-id="06c22-171">Windows.Networking.Sockets namespace (Windows)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226960)
-   [**<span data-ttu-id="06c22-172">Windows.Networking.Connectivity 名前空間 (Windows)</span><span class="sxs-lookup"><span data-stu-id="06c22-172">Windows.Networking.Connectivity namespace (Windows)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br207308)
-   [**<span data-ttu-id="06c22-173">Windows.ApplicationModel.Background 名前空間 (Windows)</span><span class="sxs-lookup"><span data-stu-id="06c22-173">Windows.ApplicationModel.Background namespace (Windows)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224847)

<span data-ttu-id="06c22-174">次の記事は、ネットワーク機能を追加し、アプリのパッケージ マニフェストでネットワークのサポートを宣言するうえで役立ちます。</span><span class="sxs-lookup"><span data-stu-id="06c22-174">The following articles help you add networking features and declare support for networking in your app's package manifest.</span></span>

-   [<span data-ttu-id="06c22-175">ソケットを使った接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)</span><span class="sxs-lookup"><span data-stu-id="06c22-175">Connecting with sockets (UWP apps using C#/VB/C++ and XAML) (Windows)</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452976)
-   [<span data-ttu-id="06c22-176">WebSocket を使った接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)</span><span class="sxs-lookup"><span data-stu-id="06c22-176">Connecting with WebSockets (UWP apps using C#/VB/C++ and XAML) (Windows)</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh994396)
-   [<span data-ttu-id="06c22-177">Web サービスへの接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)</span><span class="sxs-lookup"><span data-stu-id="06c22-177">Connecting to web services (UWP apps using C#/VB/C++ and XAML) (Windows)</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh761504)
-   [<span data-ttu-id="06c22-178">ネットワークの基本</span><span class="sxs-lookup"><span data-stu-id="06c22-178">Networking basics</span></span>](https://msdn.microsoft.com/library/windows/apps/mt280233)

<span data-ttu-id="06c22-179">アプリの中断中は、すべての UWP アプリ (ゲームを含む) で特定の種類のバックグラウンド タスクを使って接続を維持します。</span><span class="sxs-lookup"><span data-stu-id="06c22-179">Note that all UWP apps (including games) use specific types of background tasks to maintain connectivity while the app is suspended.</span></span> <span data-ttu-id="06c22-180">中断されている間、ゲームが接続状態を保存する必要がある場合は、「[ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06c22-180">If your game needs to maintain connection state while suspended see [Networking basics](https://msdn.microsoft.com/library/windows/apps/mt280233).</span></span>

## <a name="function-mapping"></a><span data-ttu-id="06c22-181">関数のマッピング</span><span class="sxs-lookup"><span data-stu-id="06c22-181">Function mapping</span></span>


<span data-ttu-id="06c22-182">Direct3D 9 から Direct3D 11 にコードの変換を行う場合は、次の表を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="06c22-182">Use the following table to help convert code from Direct3D 9 to Direct3D 11.</span></span> <span data-ttu-id="06c22-183">これは、デバイスとデバイス コンテキストの区別にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="06c22-183">This can also help distinguish between the device and device context.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="06c22-184">Direct3D9</span><span class="sxs-lookup"><span data-stu-id="06c22-184">Direct3D9</span></span></th>
<th align="left"><span data-ttu-id="06c22-185">相当する Direct3D 11 の要素</span><span class="sxs-lookup"><span data-stu-id="06c22-185">Direct3D 11 Equivalent</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174336"><span data-ttu-id="06c22-186">IDirect3DDevice9</span><span class="sxs-lookup"><span data-stu-id="06c22-186">IDirect3DDevice9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280493"><span data-ttu-id="06c22-187">ID3D11Device2</span><span class="sxs-lookup"><span data-stu-id="06c22-187">ID3D11Device2</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280498"><span data-ttu-id="06c22-188">ID3D11DeviceContext2</span><span class="sxs-lookup"><span data-stu-id="06c22-188">ID3D11DeviceContext2</span></span></a></p>
<p><span data-ttu-id="06c22-189">グラフィックス パイプラインのステージについては、「<a href="https://msdn.microsoft.com/library/windows/desktop/ff476882">グラフィックス パイプライン</a>」で説明されています。</span><span class="sxs-lookup"><span data-stu-id="06c22-189">The graphics pipeline stages are described in <a href="https://msdn.microsoft.com/library/windows/desktop/ff476882">Graphics Pipeline</a>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174300"><span data-ttu-id="06c22-190">IDirect3D9</span><span class="sxs-lookup"><span data-stu-id="06c22-190">IDirect3D9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404556"><span data-ttu-id="06c22-191">IDXGIFactory2</span><span class="sxs-lookup"><span data-stu-id="06c22-191">IDXGIFactory2</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404537"><span data-ttu-id="06c22-192">IDXGIAdapter2</span><span class="sxs-lookup"><span data-stu-id="06c22-192">IDXGIAdapter2</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280345"><span data-ttu-id="06c22-193">IDXGIDevice3</span><span class="sxs-lookup"><span data-stu-id="06c22-193">IDXGIDevice3</span></span></a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174423"><span data-ttu-id="06c22-194">IDirect3DDevice9::Present</span><span class="sxs-lookup"><span data-stu-id="06c22-194">IDirect3DDevice9::Present</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh446797"><span data-ttu-id="06c22-195">IDXGISwapChain1::Present1</span><span class="sxs-lookup"><span data-stu-id="06c22-195">IDXGISwapChain1::Present1</span></span></a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174472"><span data-ttu-id="06c22-196">IDirect3DDevice9::TestCooperativeLevel</span><span class="sxs-lookup"><span data-stu-id="06c22-196">IDirect3DDevice9::TestCooperativeLevel</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06c22-197">DXGI_PRESENT_TEST フラグを設定して <a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="06c22-197">Call <a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> with the DXGI_PRESENT_TEST flag set.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174322"><span data-ttu-id="06c22-198">IDirect3DBaseTexture9</span><span class="sxs-lookup"><span data-stu-id="06c22-198">IDirect3DBaseTexture9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205909"><span data-ttu-id="06c22-199">IDirect3DTexture9</span><span class="sxs-lookup"><span data-stu-id="06c22-199">IDirect3DTexture9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174329"><span data-ttu-id="06c22-200">IDirect3DCubeTexture9</span><span class="sxs-lookup"><span data-stu-id="06c22-200">IDirect3DCubeTexture9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205941"><span data-ttu-id="06c22-201">IDirect3DVolumeTexture9</span><span class="sxs-lookup"><span data-stu-id="06c22-201">IDirect3DVolumeTexture9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205865"><span data-ttu-id="06c22-202">IDirect3DIndexBuffer9</span><span class="sxs-lookup"><span data-stu-id="06c22-202">IDirect3DIndexBuffer9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205915"><span data-ttu-id="06c22-203">IDirect3DVertexBuffer9</span><span class="sxs-lookup"><span data-stu-id="06c22-203">IDirect3DVertexBuffer9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476351"><span data-ttu-id="06c22-204">ID3D11Buffer</span><span class="sxs-lookup"><span data-stu-id="06c22-204">ID3D11Buffer</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476633"><span data-ttu-id="06c22-205">ID3D11Texture1D</span><span class="sxs-lookup"><span data-stu-id="06c22-205">ID3D11Texture1D</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476635"><span data-ttu-id="06c22-206">ID3D11Texture2D</span><span class="sxs-lookup"><span data-stu-id="06c22-206">ID3D11Texture2D</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476637"><span data-ttu-id="06c22-207">ID3D11Texture3D</span><span class="sxs-lookup"><span data-stu-id="06c22-207">ID3D11Texture3D</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476628"><span data-ttu-id="06c22-208">ID3D11ShaderResourceView</span><span class="sxs-lookup"><span data-stu-id="06c22-208">ID3D11ShaderResourceView</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476582"><span data-ttu-id="06c22-209">ID3D11RenderTargetView</span><span class="sxs-lookup"><span data-stu-id="06c22-209">ID3D11RenderTargetView</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476377"><span data-ttu-id="06c22-210">ID3D11DepthStencilView</span><span class="sxs-lookup"><span data-stu-id="06c22-210">ID3D11DepthStencilView</span></span></a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205922"><span data-ttu-id="06c22-211">IDirect3DVertexShader9</span><span class="sxs-lookup"><span data-stu-id="06c22-211">IDirect3DVertexShader9</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205869"><span data-ttu-id="06c22-212">IDirect3DPixelShader9</span><span class="sxs-lookup"><span data-stu-id="06c22-212">IDirect3DPixelShader9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476641"><span data-ttu-id="06c22-213">ID3D11VertexShader</span><span class="sxs-lookup"><span data-stu-id="06c22-213">ID3D11VertexShader</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476576"><span data-ttu-id="06c22-214">ID3D11PixelShader</span><span class="sxs-lookup"><span data-stu-id="06c22-214">ID3D11PixelShader</span></span></a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205919"><span data-ttu-id="06c22-215">IDirect3DVertexDeclaration9</span><span class="sxs-lookup"><span data-stu-id="06c22-215">IDirect3DVertexDeclaration9</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476575"><span data-ttu-id="06c22-216">ID3D11InputLayout</span><span class="sxs-lookup"><span data-stu-id="06c22-216">ID3D11InputLayout</span></span></a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205805"><span data-ttu-id="06c22-217">IDirect3DDevice9::SetRenderState</span><span class="sxs-lookup"><span data-stu-id="06c22-217">IDirect3DDevice9::SetRenderState</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205806"><span data-ttu-id="06c22-218">IDirect3DDevice9::SetSamplerState</span><span class="sxs-lookup"><span data-stu-id="06c22-218">IDirect3DDevice9::SetSamplerState</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404571"><span data-ttu-id="06c22-219">ID3D11BlendState1</span><span class="sxs-lookup"><span data-stu-id="06c22-219">ID3D11BlendState1</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476375"><span data-ttu-id="06c22-220">ID3D11DepthStencilState</span><span class="sxs-lookup"><span data-stu-id="06c22-220">ID3D11DepthStencilState</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/hh446828"><span data-ttu-id="06c22-221">ID3D11RasterizerState1</span><span class="sxs-lookup"><span data-stu-id="06c22-221">ID3D11RasterizerState1</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476588"><span data-ttu-id="06c22-222">ID3D11SamplerState</span><span class="sxs-lookup"><span data-stu-id="06c22-222">ID3D11SamplerState</span></span></a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174369"><span data-ttu-id="06c22-223">IDirect3DDevice9::DrawIndexedPrimitive</span><span class="sxs-lookup"><span data-stu-id="06c22-223">IDirect3DDevice9::DrawIndexedPrimitive</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174371"><span data-ttu-id="06c22-224">IDirect3DDevice9::DrawPrimitive</span><span class="sxs-lookup"><span data-stu-id="06c22-224">IDirect3DDevice9::DrawPrimitive</span></span></a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476407"><span data-ttu-id="06c22-225">ID3D11DeviceContext::Draw</span><span class="sxs-lookup"><span data-stu-id="06c22-225">ID3D11DeviceContext::Draw</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476409"><span data-ttu-id="06c22-226">ID3D11DeviceContext::DrawIndexed</span><span class="sxs-lookup"><span data-stu-id="06c22-226">ID3D11DeviceContext::DrawIndexed</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173566"><span data-ttu-id="06c22-227">ID3D11DeviceContext::DrawIndexedInstanced</span><span class="sxs-lookup"><span data-stu-id="06c22-227">ID3D11DeviceContext::DrawIndexedInstanced</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173567"><span data-ttu-id="06c22-228">ID3D11DeviceContext::DrawInstanced</span><span class="sxs-lookup"><span data-stu-id="06c22-228">ID3D11DeviceContext::DrawInstanced</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173590"><span data-ttu-id="06c22-229">ID3D11DeviceContext::IASetPrimitiveTopology</span><span class="sxs-lookup"><span data-stu-id="06c22-229">ID3D11DeviceContext::IASetPrimitiveTopology</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173564"><span data-ttu-id="06c22-230">ID3D11DeviceContext::DrawAuto</span><span class="sxs-lookup"><span data-stu-id="06c22-230">ID3D11DeviceContext::DrawAuto</span></span></a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174350"><span data-ttu-id="06c22-231">IDirect3DDevice9::BeginScene</span><span class="sxs-lookup"><span data-stu-id="06c22-231">IDirect3DDevice9::BeginScene</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174375"><span data-ttu-id="06c22-232">IDirect3DDevice9::EndScene</span><span class="sxs-lookup"><span data-stu-id="06c22-232">IDirect3DDevice9::EndScene</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174372"><span data-ttu-id="06c22-233">IDirect3DDevice9::DrawPrimitiveUP</span><span class="sxs-lookup"><span data-stu-id="06c22-233">IDirect3DDevice9::DrawPrimitiveUP</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174370"><span data-ttu-id="06c22-234">IDirect3DDevice9::DrawIndexedPrimitiveUP</span><span class="sxs-lookup"><span data-stu-id="06c22-234">IDirect3DDevice9::DrawIndexedPrimitiveUP</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06c22-235">直接相当する要素はなし</span><span class="sxs-lookup"><span data-stu-id="06c22-235">No direct equivalent</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174470"><span data-ttu-id="06c22-236">IDirect3DDevice9::ShowCursor</span><span class="sxs-lookup"><span data-stu-id="06c22-236">IDirect3DDevice9::ShowCursor</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174429"><span data-ttu-id="06c22-237">IDirect3DDevice9::SetCursorPosition</span><span class="sxs-lookup"><span data-stu-id="06c22-237">IDirect3DDevice9::SetCursorPosition</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174430"><span data-ttu-id="06c22-238">IDirect3DDevice9::SetCursorProperties</span><span class="sxs-lookup"><span data-stu-id="06c22-238">IDirect3DDevice9::SetCursorProperties</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06c22-239">標準的なカーソル API を使います。</span><span class="sxs-lookup"><span data-stu-id="06c22-239">Use standard cursor APIs.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174425"><span data-ttu-id="06c22-240">IDirect3DDevice9::Reset</span><span class="sxs-lookup"><span data-stu-id="06c22-240">IDirect3DDevice9::Reset</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06c22-241">LOST デバイスと POOL_MANAGED はもう存在しません。</span><span class="sxs-lookup"><span data-stu-id="06c22-241">LOST device and POOL_MANAGED no longer exist.</span></span> <span data-ttu-id="06c22-242"><a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> は戻り値 <a href="https://msdn.microsoft.com/library/windows/desktop/bb509553">DXGI_ERROR_DEVICE_REMOVED</a> で失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="06c22-242"><a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> can fail with a <a href="https://msdn.microsoft.com/library/windows/desktop/bb509553">DXGI_ERROR_DEVICE_REMOVED</a> return value.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174373"><span data-ttu-id="06c22-243">IDirect3DDevice9:DrawRectPatch</span><span class="sxs-lookup"><span data-stu-id="06c22-243">IDirect3DDevice9:DrawRectPatch</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174374"><span data-ttu-id="06c22-244">IDirect3DDevice9:DrawTriPatch</span><span class="sxs-lookup"><span data-stu-id="06c22-244">IDirect3DDevice9:DrawTriPatch</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174421"><span data-ttu-id="06c22-245">IDirect3DDevice9:LightEnable</span><span class="sxs-lookup"><span data-stu-id="06c22-245">IDirect3DDevice9:LightEnable</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174422"><span data-ttu-id="06c22-246">IDirect3DDevice9:MultiplyTransform</span><span class="sxs-lookup"><span data-stu-id="06c22-246">IDirect3DDevice9:MultiplyTransform</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205798"><span data-ttu-id="06c22-247">IDirect3DDevice9:SetLight</span><span class="sxs-lookup"><span data-stu-id="06c22-247">IDirect3DDevice9:SetLight</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174437"><span data-ttu-id="06c22-248">IDirect3DDevice9:SetMaterial</span><span class="sxs-lookup"><span data-stu-id="06c22-248">IDirect3DDevice9:SetMaterial</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174438"><span data-ttu-id="06c22-249">IDirect3DDevice9:SetNPatchMode</span><span class="sxs-lookup"><span data-stu-id="06c22-249">IDirect3DDevice9:SetNPatchMode</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174463"><span data-ttu-id="06c22-250">IDirect3DDevice9:SetTransform</span><span class="sxs-lookup"><span data-stu-id="06c22-250">IDirect3DDevice9:SetTransform</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174433"><span data-ttu-id="06c22-251">IDirect3DDevice9:SetFVF</span><span class="sxs-lookup"><span data-stu-id="06c22-251">IDirect3DDevice9:SetFVF</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174462"><span data-ttu-id="06c22-252">IDirect3DDevice9:SetTextureStageState</span><span class="sxs-lookup"><span data-stu-id="06c22-252">IDirect3DDevice9:SetTextureStageState</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06c22-253">固定関数パイプラインは推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="06c22-253">The fixed-function pipeline has been deprecated.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174308"><span data-ttu-id="06c22-254">IDirect3DDevice9:CheckDepthStencilMatch</span><span class="sxs-lookup"><span data-stu-id="06c22-254">IDirect3DDevice9:CheckDepthStencilMatch</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174309"><span data-ttu-id="06c22-255">IDirect3DDevice9:CheckDeviceFormat</span><span class="sxs-lookup"><span data-stu-id="06c22-255">IDirect3DDevice9:CheckDeviceFormat</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174320"><span data-ttu-id="06c22-256">IDirect3DDevice9:GetDeviceCaps</span><span class="sxs-lookup"><span data-stu-id="06c22-256">IDirect3DDevice9:GetDeviceCaps</span></span></a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205859"><span data-ttu-id="06c22-257">IDirect3DDevice9:ValidateDevice</span><span class="sxs-lookup"><span data-stu-id="06c22-257">IDirect3DDevice9:ValidateDevice</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06c22-258">互換性ビットは機能レベルに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="06c22-258">Capability bits are replaced with feature levels.</span></span> <span data-ttu-id="06c22-259">特定の機能レベルでは、いくつかの形式と機能の使用のみオプションです。</span><span class="sxs-lookup"><span data-stu-id="06c22-259">Only a few format and feature usage cases are optional for any given feature level.</span></span> <span data-ttu-id="06c22-260">これは <a href="https://msdn.microsoft.com/library/windows/desktop/ff476497">ID3D11Device::CheckFeatureSupport</a> と <a href="https://msdn.microsoft.com/library/windows/desktop/bb173536">ID3D11Device::CheckFormatSupport</a> でチェックできます。</span><span class="sxs-lookup"><span data-stu-id="06c22-260">These can be checked with <a href="https://msdn.microsoft.com/library/windows/desktop/ff476497">ID3D11Device::CheckFeatureSupport</a> and <a href="https://msdn.microsoft.com/library/windows/desktop/bb173536">ID3D11Device::CheckFormatSupport</a>.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="surface-format-mapping"></a><span data-ttu-id="06c22-261">サーフェス形式のマッピング</span><span class="sxs-lookup"><span data-stu-id="06c22-261">Surface format mapping</span></span>


<span data-ttu-id="06c22-262">Direct3D 9 形式から DXGI 形式への変換を行う場合は、次の表を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="06c22-262">Use the following table to convert Direct3D 9 formats into DXGI formats.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="06c22-263">Direct3D 9 形式</span><span class="sxs-lookup"><span data-stu-id="06c22-263">Direct3D 9 Format</span></span></th>
<th align="left"><span data-ttu-id="06c22-264">Direct3D 11 形式</span><span class="sxs-lookup"><span data-stu-id="06c22-264">Direct3D 11 Format</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-265">D3DFMT_UNKNOWN</span><span class="sxs-lookup"><span data-stu-id="06c22-265">D3DFMT_UNKNOWN</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-266">DXGI_FORMAT_UNKNOWN</span><span class="sxs-lookup"><span data-stu-id="06c22-266">DXGI_FORMAT_UNKNOWN</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-267">D3DFMT_R8G8B8</span><span class="sxs-lookup"><span data-stu-id="06c22-267">D3DFMT_R8G8B8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-268">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-268">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-269">D3DFMT_A8R8G8B8</span><span class="sxs-lookup"><span data-stu-id="06c22-269">D3DFMT_A8R8G8B8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-270">DXGI_FORMAT_B8G8R8A8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-270">DXGI_FORMAT_B8G8R8A8_UNORM</span></span></p>
<p><span data-ttu-id="06c22-271">DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="06c22-271">DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-272">D3DFMT_X8R8G8B8</span><span class="sxs-lookup"><span data-stu-id="06c22-272">D3DFMT_X8R8G8B8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-273">DXGI_FORMAT_B8G8R8X8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-273">DXGI_FORMAT_B8G8R8X8_UNORM</span></span></p>
<p><span data-ttu-id="06c22-274">DXGI_FORMAT_B8G8R8X8_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="06c22-274">DXGI_FORMAT_B8G8R8X8_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-275">D3DFMT_R5G6B5</span><span class="sxs-lookup"><span data-stu-id="06c22-275">D3DFMT_R5G6B5</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-276">DXGI_FORMAT_B5G6R5_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-276">DXGI_FORMAT_B5G6R5_UNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-277">D3DFMT_X1R5G5B5</span><span class="sxs-lookup"><span data-stu-id="06c22-277">D3DFMT_X1R5G5B5</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-278">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-278">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-279">D3DFMT_A1R5G5B5</span><span class="sxs-lookup"><span data-stu-id="06c22-279">D3DFMT_A1R5G5B5</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-280">DXGI_FORMAT_B5G5R5A1_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-280">DXGI_FORMAT_B5G5R5A1_UNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-281">D3DFMT_A4R4G4B4</span><span class="sxs-lookup"><span data-stu-id="06c22-281">D3DFMT_A4R4G4B4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-282">DXGI_FORMAT_B4G4R4A4_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-282">DXGI_FORMAT_B4G4R4A4_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-283">D3DFMT_R3G3B2</span><span class="sxs-lookup"><span data-stu-id="06c22-283">D3DFMT_R3G3B2</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-284">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-284">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-285">D3DFMT_A8</span><span class="sxs-lookup"><span data-stu-id="06c22-285">D3DFMT_A8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-286">DXGI_FORMAT_A8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-286">DXGI_FORMAT_A8_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-287">D3DFMT_A8R3G3B2</span><span class="sxs-lookup"><span data-stu-id="06c22-287">D3DFMT_A8R3G3B2</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-288">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-288">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-289">D3DFMT_X4R4G4B4</span><span class="sxs-lookup"><span data-stu-id="06c22-289">D3DFMT_X4R4G4B4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-290">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-290">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-291">D3DFMT_A2B10G10R10</span><span class="sxs-lookup"><span data-stu-id="06c22-291">D3DFMT_A2B10G10R10</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-292">DXGI_FORMAT_R10G10B10A2</span><span class="sxs-lookup"><span data-stu-id="06c22-292">DXGI_FORMAT_R10G10B10A2</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-293">D3DFMT_A8B8G8R8</span><span class="sxs-lookup"><span data-stu-id="06c22-293">D3DFMT_A8B8G8R8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-294">DXGI_FORMAT_R8G8B8A8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-294">DXGI_FORMAT_R8G8B8A8_UNORM</span></span></p>
<p><span data-ttu-id="06c22-295">DXGI_FORMAT_R8G8B8A8_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="06c22-295">DXGI_FORMAT_R8G8B8A8_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-296">D3DFMT_X8B8G8R8</span><span class="sxs-lookup"><span data-stu-id="06c22-296">D3DFMT_X8B8G8R8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-297">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-297">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-298">D3DFMT_G16R16</span><span class="sxs-lookup"><span data-stu-id="06c22-298">D3DFMT_G16R16</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-299">DXGI_FORMAT_R16G16_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-299">DXGI_FORMAT_R16G16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-300">D3DFMT_A2R10G10B10</span><span class="sxs-lookup"><span data-stu-id="06c22-300">D3DFMT_A2R10G10B10</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-301">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-301">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-302">D3DFMT_A16B16G16R16</span><span class="sxs-lookup"><span data-stu-id="06c22-302">D3DFMT_A16B16G16R16</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-303">DXGI_FORMAT_R16G16B16A16_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-303">DXGI_FORMAT_R16G16B16A16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-304">D3DFMT_A8P8</span><span class="sxs-lookup"><span data-stu-id="06c22-304">D3DFMT_A8P8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-305">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-305">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-306">D3DFMT_P8</span><span class="sxs-lookup"><span data-stu-id="06c22-306">D3DFMT_P8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-307">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-307">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-308">D3DFMT_L8</span><span class="sxs-lookup"><span data-stu-id="06c22-308">D3DFMT_L8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-309">DXGI_FORMAT_R8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-309">DXGI_FORMAT_R8_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="06c22-310">
<strong>注:</strong>  direct3d9 の動作を取得するには、その他のコンポーネントを赤を複製するシェーダーで .r スウィズルを使用します。</span><span class="sxs-lookup"><span data-stu-id="06c22-310">
<strong>Note</strong> Use .r swizzle in shader to duplicate red to other components to get Direct3D 9 behavior.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-311">D3DFMT_A8L8</span><span class="sxs-lookup"><span data-stu-id="06c22-311">D3DFMT_A8L8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-312">DXGI_FORMAT_R8G8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-312">DXGI_FORMAT_R8G8_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="06c22-313">
<strong>注:</strong> 赤を複製し、direct3d9 の動作を取得するアルファ成分を緑を移動するシェーダーでスウィズル .rrrg を使用します。</span><span class="sxs-lookup"><span data-stu-id="06c22-313">
<strong>Note</strong> Use swizzle .rrrg in shader to duplicate red and move green to the alpha components to get Direct3D 9 behavior.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-314">D3DFMT_A4L4</span><span class="sxs-lookup"><span data-stu-id="06c22-314">D3DFMT_A4L4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-315">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-315">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-316">D3DFMT_V8U8</span><span class="sxs-lookup"><span data-stu-id="06c22-316">D3DFMT_V8U8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-317">DXGI_FORMAT_R8G8_SNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-317">DXGI_FORMAT_R8G8_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-318">D3DFMT_L6V5U5</span><span class="sxs-lookup"><span data-stu-id="06c22-318">D3DFMT_L6V5U5</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-319">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-319">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-320">D3DFMT_X8L8V8U8</span><span class="sxs-lookup"><span data-stu-id="06c22-320">D3DFMT_X8L8V8U8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-321">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-321">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-322">D3DFMT_Q8W8V8U8</span><span class="sxs-lookup"><span data-stu-id="06c22-322">D3DFMT_Q8W8V8U8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-323">DXGI_FORMAT_R8G8B8A8_SNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-323">DXGI_FORMAT_R8G8B8A8_SNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-324">D3DFMT_V16U16</span><span class="sxs-lookup"><span data-stu-id="06c22-324">D3DFMT_V16U16</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-325">DXGI_FORMAT_R16G16_SNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-325">DXGI_FORMAT_R16G16_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-326">D3DFMT_W11V11U10</span><span class="sxs-lookup"><span data-stu-id="06c22-326">D3DFMT_W11V11U10</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-327">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-327">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-328">D3DFMT_A2W10V10U10</span><span class="sxs-lookup"><span data-stu-id="06c22-328">D3DFMT_A2W10V10U10</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-329">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-329">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-330">D3DFMT_UYVY</span><span class="sxs-lookup"><span data-stu-id="06c22-330">D3DFMT_UYVY</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-331">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-331">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-332">D3DFMT_R8G8_B8G8</span><span class="sxs-lookup"><span data-stu-id="06c22-332">D3DFMT_R8G8_B8G8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-333">DXGI_FORMAT_G8R8_G8B8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-333">DXGI_FORMAT_G8R8_G8B8_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="06c22-334">
<strong>注:</strong>  direct3d9 でのデータは 255.0f については、スケール アップされましたが、これは、シェーダーで処理できます。</span><span class="sxs-lookup"><span data-stu-id="06c22-334">
<strong>Note</strong> In Direct3D 9 the data was scaled up by 255.0f, but this can be handled in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-335">D3DFMT_YUY2</span><span class="sxs-lookup"><span data-stu-id="06c22-335">D3DFMT_YUY2</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-336">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-336">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-337">D3DFMT_G8R8_G8B8</span><span class="sxs-lookup"><span data-stu-id="06c22-337">D3DFMT_G8R8_G8B8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-338">DXGI_FORMAT_R8G8_B8G8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-338">DXGI_FORMAT_R8G8_B8G8_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="06c22-339">
<strong>注:</strong>  direct3d9 でのデータは 255.0f については、スケール アップされましたが、これは、シェーダーで処理できます。</span><span class="sxs-lookup"><span data-stu-id="06c22-339">
<strong>Note</strong> In Direct3D 9 the data was scaled up by 255.0f, but this can be handled in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-340">D3DFMT_DXT1</span><span class="sxs-lookup"><span data-stu-id="06c22-340">D3DFMT_DXT1</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-341">DXGI_FORMAT_BC1_UNORM と DXGI_FORMAT_BC1_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="06c22-341">DXGI_FORMAT_BC1_UNORM & DXGI_FORMAT_BC1_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-342">D3DFMT_DXT2</span><span class="sxs-lookup"><span data-stu-id="06c22-342">D3DFMT_DXT2</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-343">DXGI_FORMAT_BC1_UNORM と DXGI_FORMAT_BC1_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="06c22-343">DXGI_FORMAT_BC1_UNORM & DXGI_FORMAT_BC1_UNORM_SRGB</span></span></p>
<div class="alert"><span data-ttu-id="06c22-344">
<strong>注:</strong>  DXT1 と DXT2 は、API とハードウェアの観点から同じです。</span><span class="sxs-lookup"><span data-stu-id="06c22-344">
<strong>Note</strong> DXT1 and DXT2 are the same from an API/hardware perspective.</span></span> <span data-ttu-id="06c22-345">唯一の違いは、プリマルチプライ済みアルファが使われるかどうかです。これはアプリケーションで追跡でき、別の形式は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="06c22-345">The only difference is whether premultiplied alpha is used, which can be tracked by an application and doesn't need a separate format.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-346">D3DFMT_DXT3</span><span class="sxs-lookup"><span data-stu-id="06c22-346">D3DFMT_DXT3</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-347">DXGI_FORMAT_BC2_UNORM と DXGI_FORMAT_BC2_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="06c22-347">DXGI_FORMAT_BC2_UNORM & DXGI_FORMAT_BC2_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-348">D3DFMT_DXT4</span><span class="sxs-lookup"><span data-stu-id="06c22-348">D3DFMT_DXT4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-349">DXGI_FORMAT_BC2_UNORM と DXGI_FORMAT_BC2_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="06c22-349">DXGI_FORMAT_BC2_UNORM & DXGI_FORMAT_BC2_UNORM_SRGB</span></span></p>
<div class="alert"><span data-ttu-id="06c22-350">
<strong>注:</strong>  DXT3 と DXT4 API とハードウェアの観点から同じです。</span><span class="sxs-lookup"><span data-stu-id="06c22-350">
<strong>Note</strong> DXT3 and DXT4 are the same from an API/hardware perspective.</span></span> <span data-ttu-id="06c22-351">唯一の違いは、プリマルチプライ済みアルファが使われるかどうかです。これはアプリケーションで追跡でき、別の形式は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="06c22-351">The only difference is whether premultiplied alpha is used, which can be tracked by an application and doesn't need a separate format.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-352">D3DFMT_DXT5</span><span class="sxs-lookup"><span data-stu-id="06c22-352">D3DFMT_DXT5</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-353">DXGI_FORMAT_BC3_UNORM と DXGI_FORMAT_BC3_UNORM_SRGB</span><span class="sxs-lookup"><span data-stu-id="06c22-353">DXGI_FORMAT_BC3_UNORM & DXGI_FORMAT_BC3_UNORM_SRGB</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-354">D3DFMT_D16 と D3DFMT_D16_LOCKABLE</span><span class="sxs-lookup"><span data-stu-id="06c22-354">D3DFMT_D16 & D3DFMT_D16_LOCKABLE</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-355">DXGI_FORMAT_D16_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-355">DXGI_FORMAT_D16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-356">D3DFMT_D32</span><span class="sxs-lookup"><span data-stu-id="06c22-356">D3DFMT_D32</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-357">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-357">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-358">D3DFMT_D15S1</span><span class="sxs-lookup"><span data-stu-id="06c22-358">D3DFMT_D15S1</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-359">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-359">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-360">D3DFMT_D24S8</span><span class="sxs-lookup"><span data-stu-id="06c22-360">D3DFMT_D24S8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-361">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-361">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-362">D3DFMT_D24X8</span><span class="sxs-lookup"><span data-stu-id="06c22-362">D3DFMT_D24X8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-363">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-363">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-364">D3DFMT_D24X4S4</span><span class="sxs-lookup"><span data-stu-id="06c22-364">D3DFMT_D24X4S4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-365">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-365">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-366">D3DFMT_D16</span><span class="sxs-lookup"><span data-stu-id="06c22-366">D3DFMT_D16</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-367">DXGI_FORMAT_D16_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-367">DXGI_FORMAT_D16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-368">D3DFMT_D32F_LOCKABLE</span><span class="sxs-lookup"><span data-stu-id="06c22-368">D3DFMT_D32F_LOCKABLE</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-369">DXGI_FORMAT_D32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-369">DXGI_FORMAT_D32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-370">D3DFMT_D24FS8</span><span class="sxs-lookup"><span data-stu-id="06c22-370">D3DFMT_D24FS8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-371">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-371">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-372">D3DFMT_S1D15</span><span class="sxs-lookup"><span data-stu-id="06c22-372">D3DFMT_S1D15</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-373">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-373">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-374">D3DFMT_S8D24</span><span class="sxs-lookup"><span data-stu-id="06c22-374">D3DFMT_S8D24</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-375">DXGI_FORMAT_D24_UNORM_S8_UINT</span><span class="sxs-lookup"><span data-stu-id="06c22-375">DXGI_FORMAT_D24_UNORM_S8_UINT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-376">D3DFMT_X8D24</span><span class="sxs-lookup"><span data-stu-id="06c22-376">D3DFMT_X8D24</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-377">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-377">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-378">D3DFMT_X4S4D24</span><span class="sxs-lookup"><span data-stu-id="06c22-378">D3DFMT_X4S4D24</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-379">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-379">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-380">D3DFMT_L16</span><span class="sxs-lookup"><span data-stu-id="06c22-380">D3DFMT_L16</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-381">DXGI_FORMAT_R16_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-381">DXGI_FORMAT_R16_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="06c22-382">
<strong>注:</strong>  D3D9 の動作を取得するには、その他のコンポーネントを赤を複製するシェーダーで .r スウィズルを使用します。</span><span class="sxs-lookup"><span data-stu-id="06c22-382">
<strong>Note</strong> Use .r swizzle in shader to duplicate red to other components to get D3D9 behavior.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-383">D3DFMT_INDEX16</span><span class="sxs-lookup"><span data-stu-id="06c22-383">D3DFMT_INDEX16</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-384">DXGI_FORMAT_R16_UINT</span><span class="sxs-lookup"><span data-stu-id="06c22-384">DXGI_FORMAT_R16_UINT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-385">D3DFMT_INDEX32</span><span class="sxs-lookup"><span data-stu-id="06c22-385">D3DFMT_INDEX32</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-386">DXGI_FORMAT_R32_UINT</span><span class="sxs-lookup"><span data-stu-id="06c22-386">DXGI_FORMAT_R32_UINT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-387">D3DFMT_Q16W16V16U16</span><span class="sxs-lookup"><span data-stu-id="06c22-387">D3DFMT_Q16W16V16U16</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-388">DXGI_FORMAT_R16G16B16A16_SNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-388">DXGI_FORMAT_R16G16B16A16_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-389">D3DFMT_MULTI2_ARGB8</span><span class="sxs-lookup"><span data-stu-id="06c22-389">D3DFMT_MULTI2_ARGB8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-390">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-390">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-391">D3DFMT_R16F</span><span class="sxs-lookup"><span data-stu-id="06c22-391">D3DFMT_R16F</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-392">DXGI_FORMAT_R16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-392">DXGI_FORMAT_R16_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-393">D3DFMT_G16R16F</span><span class="sxs-lookup"><span data-stu-id="06c22-393">D3DFMT_G16R16F</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-394">DXGI_FORMAT_R16G16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-394">DXGI_FORMAT_R16G16_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-395">D3DFMT_A16B16G16R16F</span><span class="sxs-lookup"><span data-stu-id="06c22-395">D3DFMT_A16B16G16R16F</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-396">DXGI_FORMAT_R16G16B16A16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-396">DXGI_FORMAT_R16G16B16A16_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-397">D3DFMT_R32F</span><span class="sxs-lookup"><span data-stu-id="06c22-397">D3DFMT_R32F</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-398">DXGI_FORMAT_R32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-398">DXGI_FORMAT_R32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-399">D3DFMT_G32R32F</span><span class="sxs-lookup"><span data-stu-id="06c22-399">D3DFMT_G32R32F</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-400">DXGI_FORMAT_R32G32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-400">DXGI_FORMAT_R32G32_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-401">D3DFMT_A32B32G32R32F</span><span class="sxs-lookup"><span data-stu-id="06c22-401">D3DFMT_A32B32G32R32F</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-402">DXGI_FORMAT_R32G32B32A32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-402">DXGI_FORMAT_R32G32B32A32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-403">D3DFMT_CxV8U8</span><span class="sxs-lookup"><span data-stu-id="06c22-403">D3DFMT_CxV8U8</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-404">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-404">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-405">D3DDECLTYPE_FLOAT1</span><span class="sxs-lookup"><span data-stu-id="06c22-405">D3DDECLTYPE_FLOAT1</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-406">DXGI_FORMAT_R32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-406">DXGI_FORMAT_R32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-407">D3DDECLTYPE_FLOAT2</span><span class="sxs-lookup"><span data-stu-id="06c22-407">D3DDECLTYPE_FLOAT2</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-408">DXGI_FORMAT_R32G32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-408">DXGI_FORMAT_R32G32_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-409">D3DDECLTYPE_FLOAT3</span><span class="sxs-lookup"><span data-stu-id="06c22-409">D3DDECLTYPE_FLOAT3</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-410">DXGI_FORMAT_R32G32B32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-410">DXGI_FORMAT_R32G32B32_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-411">D3DDECLTYPE_FLOAT4</span><span class="sxs-lookup"><span data-stu-id="06c22-411">D3DDECLTYPE_FLOAT4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-412">DXGI_FORMAT_R32G32B32A32_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-412">DXGI_FORMAT_R32G32B32A32_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-413">D3DDECLTYPED3DCOLOR</span><span class="sxs-lookup"><span data-stu-id="06c22-413">D3DDECLTYPED3DCOLOR</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-414">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-414">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-415">D3DDECLTYPE_UBYTE4</span><span class="sxs-lookup"><span data-stu-id="06c22-415">D3DDECLTYPE_UBYTE4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-416">DXGI_FORMAT_R8G8B8A8_UINT</span><span class="sxs-lookup"><span data-stu-id="06c22-416">DXGI_FORMAT_R8G8B8A8_UINT</span></span></p>
<div class="alert"><span data-ttu-id="06c22-417">
<strong>注:</strong> シェーダーは UINT 値を取得しますが、浮動小数点値が必要な場合は、direct3d9 スタイル (0.0 f、1.0 f.255.f)、UINT をシェーダーで float32 に変換できます。</span><span class="sxs-lookup"><span data-stu-id="06c22-417">
<strong>Note</strong> The shader gets UINT values, but if Direct3D 9 style integral floats are needed (0.0f, 1.0f... 255.f), UINT can just be converted to float32 in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-418">D3DDECLTYPE_SHORT2</span><span class="sxs-lookup"><span data-stu-id="06c22-418">D3DDECLTYPE_SHORT2</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-419">DXGI_FORMAT_R16G16_SINT</span><span class="sxs-lookup"><span data-stu-id="06c22-419">DXGI_FORMAT_R16G16_SINT</span></span></p>
<div class="alert"><span data-ttu-id="06c22-420">
<strong>注:</strong> シェーダーは SINT 値を取得しますが、だけ SINT をシェーダーで float32 に変換する、direct3d9 スタイルの integral が必要な場合です。</span><span class="sxs-lookup"><span data-stu-id="06c22-420">
<strong>Note</strong> The shader gets SINT values, but if Direct3D 9 style integral floats are needed, SINT can just be converted to float32 in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-421">D3DDECLTYPE_SHORT4</span><span class="sxs-lookup"><span data-stu-id="06c22-421">D3DDECLTYPE_SHORT4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-422">DXGI_FORMAT_R16G16B16A16_SINT</span><span class="sxs-lookup"><span data-stu-id="06c22-422">DXGI_FORMAT_R16G16B16A16_SINT</span></span></p>
<div class="alert"><span data-ttu-id="06c22-423">
<strong>注:</strong> シェーダーは SINT 値を取得しますが、だけ SINT をシェーダーで float32 に変換する、direct3d9 スタイルの integral が必要な場合です。</span><span class="sxs-lookup"><span data-stu-id="06c22-423">
<strong>Note</strong> The shader gets SINT values, but if Direct3D 9 style integral floats are needed, SINT can just be converted to float32 in the shader.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-424">D3DDECLTYPE_UBYTE4N</span><span class="sxs-lookup"><span data-stu-id="06c22-424">D3DDECLTYPE_UBYTE4N</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-425">DXGI_FORMAT_R8G8B8A8_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-425">DXGI_FORMAT_R8G8B8A8_UNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-426">D3DDECLTYPE_SHORT2N</span><span class="sxs-lookup"><span data-stu-id="06c22-426">D3DDECLTYPE_SHORT2N</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-427">DXGI_FORMAT_R16G16_SNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-427">DXGI_FORMAT_R16G16_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-428">D3DDECLTYPE_SHORT4N</span><span class="sxs-lookup"><span data-stu-id="06c22-428">D3DDECLTYPE_SHORT4N</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-429">DXGI_FORMAT_R16G16B16A16_SNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-429">DXGI_FORMAT_R16G16B16A16_SNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-430">D3DDECLTYPE_USHORT2N</span><span class="sxs-lookup"><span data-stu-id="06c22-430">D3DDECLTYPE_USHORT2N</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-431">DXGI_FORMAT_R16G16_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-431">DXGI_FORMAT_R16G16_UNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-432">D3DDECLTYPE_USHORT4N</span><span class="sxs-lookup"><span data-stu-id="06c22-432">D3DDECLTYPE_USHORT4N</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-433">DXGI_FORMAT_R16G16B16A16_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-433">DXGI_FORMAT_R16G16B16A16_UNORM</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-434">D3DDECLTYPE_UDEC3</span><span class="sxs-lookup"><span data-stu-id="06c22-434">D3DDECLTYPE_UDEC3</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-435">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-435">Not available</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-436">D3DDECLTYPE_DEC3N</span><span class="sxs-lookup"><span data-stu-id="06c22-436">D3DDECLTYPE_DEC3N</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-437">使用できません</span><span class="sxs-lookup"><span data-stu-id="06c22-437">Not available</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-438">D3DDECLTYPE_FLOAT16_2</span><span class="sxs-lookup"><span data-stu-id="06c22-438">D3DDECLTYPE_FLOAT16_2</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-439">DXGI_FORMAT_R16G16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-439">DXGI_FORMAT_R16G16_FLOAT</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-440">D3DDECLTYPE_FLOAT16_4</span><span class="sxs-lookup"><span data-stu-id="06c22-440">D3DDECLTYPE_FLOAT16_4</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-441">DXGI_FORMAT_R16G16B16A16_FLOAT</span><span class="sxs-lookup"><span data-stu-id="06c22-441">DXGI_FORMAT_R16G16B16A16_FLOAT</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="06c22-442">FourCC 'ATI1'</span><span class="sxs-lookup"><span data-stu-id="06c22-442">FourCC 'ATI1'</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-443">DXGI_FORMAT_BC4_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-443">DXGI_FORMAT_BC4_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="06c22-444">
<strong>注:</strong> 機能レベル 10.0 以降が必要です</span><span class="sxs-lookup"><span data-stu-id="06c22-444">
<strong>Note</strong> Requires Feature Level 10.0 or later</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="06c22-445">FourCC 'ATI2'</span><span class="sxs-lookup"><span data-stu-id="06c22-445">FourCC 'ATI2'</span></span></p></td>
<td align="left"><p><span data-ttu-id="06c22-446">DXGI_FORMAT_BC5_UNORM</span><span class="sxs-lookup"><span data-stu-id="06c22-446">DXGI_FORMAT_BC5_UNORM</span></span></p>
<div class="alert"><span data-ttu-id="06c22-447">
<strong>注:</strong> 機能レベル 10.0 以降が必要です</span><span class="sxs-lookup"><span data-stu-id="06c22-447">
<strong>Note</strong> Requires Feature Level 10.0 or later</span></span>
</div>
<div>
 
</div></td>
</tr>
</tbody>
</table>

 

 

 




