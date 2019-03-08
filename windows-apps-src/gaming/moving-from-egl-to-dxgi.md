---
title: EGL コードと DXGI および Direct3D の比較
description: DirectX Graphics Interface (DXGI) といくつかの Direct3D API は EGL と同じ役割を果たします。 このトピックは EGL の観点から DXGI と Direct3D 11 を理解するのに役立ちます。
ms.assetid: 90f5ecf1-dd5d-fea3-bed8-57a228898d2a
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, EGL, DXGI, Direct3D
ms.localizationpriority: medium
ms.openlocfilehash: 19c857ae5274be70d19a14d5bbf47adb595b5676
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606367"
---
# <a name="compare-egl-code-to-dxgi-and-direct3d"></a><span data-ttu-id="ad61c-105">EGL コードと DXGI および Direct3D の比較</span><span class="sxs-lookup"><span data-stu-id="ad61c-105">Compare EGL code to DXGI and Direct3D</span></span>




<span data-ttu-id="ad61c-106">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="ad61c-106">**Important APIs**</span></span>

-   [<span data-ttu-id="ad61c-107">**ID3D11Device1**</span><span class="sxs-lookup"><span data-stu-id="ad61c-107">**ID3D11Device1**</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh404575)
-   [<span data-ttu-id="ad61c-108">**ID3D11DeviceContext1**</span><span class="sxs-lookup"><span data-stu-id="ad61c-108">**ID3D11DeviceContext1**</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh404598)
-   [<span data-ttu-id="ad61c-109">**CoreWindow**</span><span class="sxs-lookup"><span data-stu-id="ad61c-109">**CoreWindow**</span></span>](https://msdn.microsoft.com/library/windows/apps/br208225)

<span data-ttu-id="ad61c-110">DirectX Graphics Interface (DXGI) といくつかの Direct3D API は EGL と同じ役割を果たします。</span><span class="sxs-lookup"><span data-stu-id="ad61c-110">The DirectX Graphics Interface (DXGI) and several Direct3D APIs serve the same role as EGL.</span></span> <span data-ttu-id="ad61c-111">このトピックは EGL の観点から DXGI と Direct3D 11 を理解するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-111">This topic helps you understand DXGI and Direct3D 11 from the perspective of EGL.</span></span>

<span data-ttu-id="ad61c-112">DXGI と Direct3D は EGL に似ており、グラフィックス リソースを構成するためのメソッドや、シェーダーの描画先となり、ウィンドウに結果を表示するために使われるレンダリング コンテキストを取得するためのメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="ad61c-112">DXGI and Direct3D, like EGL, provide methods to configure graphics resources, obtain a rendering context for your shaders to draw into, and to display the results in a window.</span></span> <span data-ttu-id="ad61c-113">ただし、DXGI と Direct3D にはかなりのオプションがあるため、EGL からの移植の際には、適切に設定するための余分な作業が必要です。</span><span class="sxs-lookup"><span data-stu-id="ad61c-113">However, DXGI and Direct3D have quite a few more options, and require more effort to set up correctly when porting from EGL.</span></span>

> <span data-ttu-id="ad61c-114">**注**  このガイダンスは、こちらの EGL 1.4 の Khronos グループのオープン仕様に基づいて。[Khronos ネイティブ プラットフォーム グラフィック インターフェイス (EGL バージョン 1.4 - 2011 年 4 月 6 日) \[PDF\]](https://www.khronos.org/registry/egl/specs/eglspec.1.4.20110406.pdf)します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-114">**Note**   This guidance is based off the Khronos Group's open specification for EGL 1.4, found here: [Khronos Native Platform Graphics Interface (EGL Version 1.4 - April 6, 2011) \[PDF\]](https://www.khronos.org/registry/egl/specs/eglspec.1.4.20110406.pdf).</span></span> <span data-ttu-id="ad61c-115">その他のプラットフォームと開発言語に固有の構文の違いは、このガイダンスでは説明していません。</span><span class="sxs-lookup"><span data-stu-id="ad61c-115">Differences in syntax specific to other platforms and development languages are not covered in this guidance.</span></span>

 

## <a name="how-does-dxgi-and-direct3d-compare"></a><span data-ttu-id="ad61c-116">DXGI と Direct3D の比較方法</span><span class="sxs-lookup"><span data-stu-id="ad61c-116">How does DXGI and Direct3D compare?</span></span>


<span data-ttu-id="ad61c-117">DXGI および Direct3D と比較したときの EGL の大きなメリットは、比較的簡単にウィンドウ サーフェスへの描画を開始できることです。</span><span class="sxs-lookup"><span data-stu-id="ad61c-117">The big advantage of EGL over DXGI and Direct3D is that it is relatively simple to start drawing to a window surface.</span></span> <span data-ttu-id="ad61c-118">これは、OpenGL ES 2.0 と EGL が複数のプラットフォーム プロバイダーによって実装された仕様であるのに対し、DXGI と Direct3D はハードウェア ベンダーのドライバーが準拠する必要のある単一のリファレンスであるためです。</span><span class="sxs-lookup"><span data-stu-id="ad61c-118">This is because OpenGL ES 2.0—and therefore EGL—is a specification implemented by multiple platform providers, whereas DXGI and Direct3D are a single reference that hardware vendor drivers must conform to.</span></span> <span data-ttu-id="ad61c-119">つまり、Microsoft がやるべきことは、特定のベンダーが提供する機能のサブセットに注力したり、ベンダー固有のセットアップ コマンドをよりシンプルな API に結合することで得られた機能のサブセットに注力したりすることではなく、可能な限り幅広いベンダー機能をサポートする API のセットを実装することです。</span><span class="sxs-lookup"><span data-stu-id="ad61c-119">This means that Microsoft must implement a set of APIs that enable the broadest possible set of vendor features, rather than focusing on a functional subset offered by a specific vendor, or by combining vendor-specific setup commands into simpler APIs.</span></span> <span data-ttu-id="ad61c-120">一方、Direct3D は、非常に幅広いグラフィックス ハードウェア プラットフォームと機能レベルに対応し、プラットフォームで経験を積んだ開発者向けの柔軟性を提供する API の単一のセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-120">On the other hand, Direct3D provides a single set of APIs that cover a very broad range of graphics hardware platforms and feature levels, and offer more flexibility for developers experienced with the platform.</span></span>

<span data-ttu-id="ad61c-121">EGL と同様に、DXGI と Direct3D には次の動作のための API が用意されています。</span><span class="sxs-lookup"><span data-stu-id="ad61c-121">Like EGL, DXGI and Direct3D provide APIs for the following behaviors:</span></span>

-   <span data-ttu-id="ad61c-122">フレーム バッファーを取得し、その読み書きを行う (DXGI では "スワップ チェーン")。</span><span class="sxs-lookup"><span data-stu-id="ad61c-122">Obtaining, and reading and writing to a frame buffer (called a "swap chain" in DXGI).</span></span>
-   <span data-ttu-id="ad61c-123">フレーム バッファーを UI ウィンドウに関連付ける。</span><span class="sxs-lookup"><span data-stu-id="ad61c-123">Associating the frame buffer with a UI window.</span></span>
-   <span data-ttu-id="ad61c-124">描画の場所となるレンダリング コンテキストを取得、構成する。</span><span class="sxs-lookup"><span data-stu-id="ad61c-124">Obtaining and configuring rendering contexts in which to draw.</span></span>
-   <span data-ttu-id="ad61c-125">特定のレンダリング コンテキストのグラフィックス パイプラインにコマンドを発行する。</span><span class="sxs-lookup"><span data-stu-id="ad61c-125">Issuing commands to the graphics pipeline for a specific rendering context.</span></span>
-   <span data-ttu-id="ad61c-126">シェーダー リソースを作成して管理し、レンダリング コンテキストに関連付ける。</span><span class="sxs-lookup"><span data-stu-id="ad61c-126">Creating and managing shader resources, and associating them with a rendering content.</span></span>
-   <span data-ttu-id="ad61c-127">特定のレンダー ターゲットにレンダリングする (テクスチャなど)。</span><span class="sxs-lookup"><span data-stu-id="ad61c-127">Rendering to specific render targets (such as textures).</span></span>
-   <span data-ttu-id="ad61c-128">グラフィックス リソースを使ったレンダリングの結果でウィンドウの表示サーフェスを更新する。</span><span class="sxs-lookup"><span data-stu-id="ad61c-128">Updating the window's display surface with the results of rendering with the graphics resources.</span></span>

<span data-ttu-id="ad61c-129">グラフィックス パイプラインを構成するための基本的な Direct3D プロセスを表示するには、Microsoft Visual Studio 2015 での DirectX 11 アプリ (ユニバーサル Windows) テンプレートを確認します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-129">To see the basic Direct3D process for configuring the graphics pipeline, check out the DirectX 11 App (Universal Windows) template in Microsoft Visual Studio 2015.</span></span> <span data-ttu-id="ad61c-130">その基本レンダリング クラスは、Direct3D 11 のグラフィックス インフラストラクチャを設定し、それに基づいて基本的なリソースを構成したり、画面の回転などのユニバーサル Windows プラットフォーム (UWP) アプリの機能をサポートしたりするうえで、適切なベースラインとなります。</span><span class="sxs-lookup"><span data-stu-id="ad61c-130">The base rendering class in it provides a good baseline for setting up the Direct3D 11 graphics infrastructure and configuring basic resources on it, as well as supporting Universal Windows Platform (UWP) app features such as screen rotation.</span></span>

<span data-ttu-id="ad61c-131">EGL は Direct3D 11 と比べて API が非常に少なくなっています。プラットフォームに特定の命名規則や専門用語に慣れていないと、Direct3D 11 の理解は難しい場合があります。</span><span class="sxs-lookup"><span data-stu-id="ad61c-131">EGL has very few APIs relative to Direct3D 11, and navigating the latter can be a challenge if you aren't familiar with the naming and jargon particular to the platform.</span></span> <span data-ttu-id="ad61c-132">ここでは、初心者の役に立つ簡単な概要を示します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-132">Here's a simple overview to help you get oriented.</span></span>

<span data-ttu-id="ad61c-133">まず、基本的な EGL オブジェクトと Direct3D インターフェイスのマッピングを確かめます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-133">First, review the basic EGL object to Direct3D interface mapping:</span></span>

| <span data-ttu-id="ad61c-134">EGL のアブストラクション</span><span class="sxs-lookup"><span data-stu-id="ad61c-134">EGL abstraction</span></span> | <span data-ttu-id="ad61c-135">Direct3D での同様の表現</span><span class="sxs-lookup"><span data-stu-id="ad61c-135">Similar Direct3D representation</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|-----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="ad61c-136">**EGLDisplay**</span><span class="sxs-lookup"><span data-stu-id="ad61c-136">**EGLDisplay**</span></span>  | <span data-ttu-id="ad61c-137">UWP アプリ向けの Direct3D では、表示ハンドルは [**Windows::UI::CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) API (または HWND を公開する **ICoreWindowInterop** インターフェイス) を通じて取得されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-137">In Direct3D (for UWP apps), the display handle is obtained through the [**Windows::UI::CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) API (or the **ICoreWindowInterop** interface that exposes the HWND).</span></span> <span data-ttu-id="ad61c-138">アダプターとハードウェア構成は、それぞれ [**IDXGIAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174523) COM インターフェイスと [**IDXGIDevice1**](https://msdn.microsoft.com/library/windows/desktop/hh404543) COM インターフェイスを使って設定されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-138">The adapter and hardware configuration are set with the [**IDXGIAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174523) and [**IDXGIDevice1**](https://msdn.microsoft.com/library/windows/desktop/hh404543) COM interfaces, respectively.</span></span>                                                                                                                                                                                                                                                           |
| <span data-ttu-id="ad61c-139">**EGLSurface**</span><span class="sxs-lookup"><span data-stu-id="ad61c-139">**EGLSurface**</span></span>  | <span data-ttu-id="ad61c-140">Direct3D では、[**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556) ([**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) (表示バッファー) などの DXGI リソースを取得するために使われるファクトリ パターンの実装) を含め、特定の DXGI インターフェイスでバッファーなどのウィンドウ リソース (表示またはオフ スクリーン) を作成し、構成します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-140">In Direct3D, the buffers and other window resources (visible or offscreen) are created and configured by specific DXGI interfaces, including [**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556) (a factory pattern implementation used to acquire DXGI resources such as the[**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) (display buffers).</span></span> <span data-ttu-id="ad61c-141">グラフィックス デバイスとそのリソースを表す [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) は、[**D3D11Device::CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) で取得されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-141">The [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) that represents the graphics device and its resources, is acquired with [**D3D11Device::CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082).</span></span> <span data-ttu-id="ad61c-142">レンダー ターゲットには、[**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) インターフェイスを使います。</span><span class="sxs-lookup"><span data-stu-id="ad61c-142">For render targets, use the [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) interface.</span></span> |
| <span data-ttu-id="ad61c-143">**EGLContext**</span><span class="sxs-lookup"><span data-stu-id="ad61c-143">**EGLContext**</span></span>  | <span data-ttu-id="ad61c-144">Direct3D では、[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) インターフェイスでコマンドを構成し、グラフィックス パイプラインに発行します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-144">In Direct3D, you configure and issue commands to the graphics pipeline with the [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) interface.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| <span data-ttu-id="ad61c-145">**EGLConfig**</span><span class="sxs-lookup"><span data-stu-id="ad61c-145">**EGLConfig**</span></span>   | <span data-ttu-id="ad61c-146">Direct3D 11 では、バッファー、テクスチャ、ステンシル、シェーダーなどのグラフィックス リソースを、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) インターフェイスのメソッドで作成、構成します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-146">In Direct3D 11, you create and configure graphics resources such as a buffers, textures, stencils and shaders with methods on the [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) interface.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                      |

 

<span data-ttu-id="ad61c-147">ここで、UWP アプリ用の DXGI と Direct3D でシンプルなグラフィックスの表示、リソース、コンテキストを設定するための最も基本的なプロセスを示します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-147">Now, here's the most basic process for setting up a simple graphics display, resources and context in DXGI and Direct3D for a UWP app.</span></span>

1.  <span data-ttu-id="ad61c-148">[  **CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出してアプリの中心的な UI スレッドの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトへのハンドルを取得します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-148">Obtain a handle to the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) object for the app's core UI thread by calling [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589).</span></span>
2.  <span data-ttu-id="ad61c-149">UWP アプリの場合、[**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) で [**IDXGIAdapter2**](https://msdn.microsoft.com/library/windows/desktop/hh404537) からスワップ チェーンを取得し、手順 1. で取得した [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の参照をそれに渡します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-149">For UWP apps, acquire a swap chain from the [**IDXGIAdapter2**](https://msdn.microsoft.com/library/windows/desktop/hh404537) with [**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559), and pass it the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) reference you obtained in step 1.</span></span> <span data-ttu-id="ad61c-150">[  **IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) インスタンスが返されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-150">You will get an [**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) instance in return.</span></span> <span data-ttu-id="ad61c-151">そのスコープをレンダラー オブジェクトとそのレンダリング スレッドに設定します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-151">Scope it to your renderer object and its rendering thread.</span></span>
3.  <span data-ttu-id="ad61c-152">[  **D3D11Device::CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) メソッドを呼び出して [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) と [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) のインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-152">Obtain [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) and [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) instances by calling the [**D3D11Device::CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) method.</span></span> <span data-ttu-id="ad61c-153">そのスコープもレンダラー オブジェクトにします。</span><span class="sxs-lookup"><span data-stu-id="ad61c-153">Scope them to your renderer object as well.</span></span>
4.  <span data-ttu-id="ad61c-154">レンダラーの [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) オブジェクトのメソッドを使ってシェーダーやテクスチャなどのリソースを作成します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-154">Create shaders, textures, and other resources using methods on your renderer's [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) object.</span></span>
5.  <span data-ttu-id="ad61c-155">バッファーを定義し、シェーダーを実行して、パイプライン ステージを管理します。それには、レンダラーの [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) オブジェクトのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="ad61c-155">Define buffers, run shaders and manage the pipeline stages using methods on your renderer's [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) object.</span></span>
6.  <span data-ttu-id="ad61c-156">パイプラインが実行され、フレームがバック バッファーに描画されたら、[**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) でそれを画面に表示します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-156">When the pipeline has executed and a frame is drawn to the back buffer, present it to the screen with [**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797).</span></span>

<span data-ttu-id="ad61c-157">このプロセスについて詳しく調べるには、「[DirectX グラフィックスの概要](https://msdn.microsoft.com/library/windows/desktop/hh309467)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad61c-157">To examine this process in more detail, review [Getting started with DirectX graphics](https://msdn.microsoft.com/library/windows/desktop/hh309467).</span></span> <span data-ttu-id="ad61c-158">この記事の残りの部分では、基本的なグラフィックス パイプラインの設定と管理に関する一般的な手順の多くについて説明します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-158">The rest of this article covers many of the common steps for basic graphics pipeline setup and management.</span></span>
> <span data-ttu-id="ad61c-159">**注**   Windows デスクトップ アプリなど、Direct3D スワップ チェーンを取得するためのさまざまな Api のある[ **D3D11Device::CreateDeviceAndSwapChain**](https://msdn.microsoft.com/library/windows/desktop/ff476083)、し、を使わない[ **CoreWindow** ](https://msdn.microsoft.com/library/windows/apps/br208225)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ad61c-159">**Note**   Windows Desktop apps have different APIs for obtaining a Direct3D swap chain, such as [**D3D11Device::CreateDeviceAndSwapChain**](https://msdn.microsoft.com/library/windows/desktop/ff476083), and do not use a [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) object.</span></span>

 

## <a name="obtaining-a-window-for-display"></a><span data-ttu-id="ad61c-160">表示のためのウィンドウの取得</span><span class="sxs-lookup"><span data-stu-id="ad61c-160">Obtaining a window for display</span></span>


<span data-ttu-id="ad61c-161">この例では、Microsoft Windows プラットフォームに固有のウィンドウ リソース用の HWND が eglGetDisplay に渡されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-161">In this example, eglGetDisplay is passed an HWND for a window resource specific to the Microsoft Windows platform.</span></span> <span data-ttu-id="ad61c-162">Apple の iOS (Cocoa) や Google の Android などの他のプラットフォームには、ウィンドウ リソースへの別のハンドルや参照があり、別の呼び出し構文が存在することもあります。</span><span class="sxs-lookup"><span data-stu-id="ad61c-162">Other platforms, such as Apple's iOS (Cocoa) and Google's Android, have different handles or references to window resources, and may have different calling syntax altogether.</span></span> <span data-ttu-id="ad61c-163">表示を取得した後で初期化し、優先する構成を設定して、描画先のバック バッファーを持つサーフェスを作成します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-163">After obtaining a display, you initialize it, set the preferred configuration, and create a surface with a back buffer you can draw into.</span></span>

<span data-ttu-id="ad61c-164">EGL を使った表示の取得と構成</span><span class="sxs-lookup"><span data-stu-id="ad61c-164">Obtaining a display and configuring it with EGL..</span></span>

``` syntax
// Obtain an EGL display object.
EGLDisplay display = eglGetDisplay(GetDC(hWnd));
if (display == EGL_NO_DISPLAY)
{
  return EGL_FALSE;
}

// Initialize the display
if (!eglInitialize(display, &majorVersion, &minorVersion))
{
  return EGL_FALSE;
}

// Obtain the display configs
if (!eglGetConfigs(display, NULL, 0, &numConfigs))
{
  return EGL_FALSE;
}

// Choose the display config
if (!eglChooseConfig(display, attribList, &config, 1, &numConfigs))
{
  return EGL_FALSE;
}

// Create a surface
surface = eglCreateWindowSurface(display, config, (EGLNativeWindowType)hWnd, NULL);
if (surface == EGL_NO_SURFACE)
{
  return EGL_FALSE;
}
```

<span data-ttu-id="ad61c-165">Direct3D では、UWP アプリのメイン ウィンドウは [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトで表されます。このオブジェクトは、Direct3D 向けに構築した "ビュー プロバイダー" の初期化プロセスの一環として [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出すことでアプリ オブジェクトから取得できます </span><span class="sxs-lookup"><span data-stu-id="ad61c-165">In Direct3D, a UWP app's main window is represented by the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) object, which can be obtained from the app object by calling [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) as part of the initialization process of the "view provider" you construct for Direct3D.</span></span> <span data-ttu-id="ad61c-166">(Direct3D XAML 相互運用機能を使用している場合、XAML フレームワークのビュー プロバイダー使用)。Direct3D ビュー プロバイダーを作成するプロセスについては[ビューを表示するアプリをセットアップする方法](https://msdn.microsoft.com/library/windows/apps/hh465077)します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-166">(If you are using Direct3D-XAML interop, you use the XAML framework's view provider.) The process for creating a Direct3D view provider is covered in [How to set up your app to display a view](https://msdn.microsoft.com/library/windows/apps/hh465077).</span></span>

<span data-ttu-id="ad61c-167">Direct3D の CoreWindow の取得</span><span class="sxs-lookup"><span data-stu-id="ad61c-167">Obtaining a CoreWindow for Direct3D.</span></span>

``` syntax
CoreWindow::GetForCurrentThread();
```

<span data-ttu-id="ad61c-168">[  **CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の参照を取得したら、ウィンドウをアクティブ化する必要があります。それにより、メイン オブジェクトの **Run** メソッドが実行され、ウィンドウ イベントの処理が開始されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-168">Once the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) reference is obtained, the window must be activated, which executes the **Run** method of your main object and begins window event processing.</span></span> <span data-ttu-id="ad61c-169">その後、作成、 [ **ID3D11Device1** ](https://msdn.microsoft.com/library/windows/desktop/hh404575)と[ **ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)、それらを使用して、基になるかを取得して[**IDXGIDevice1** ](https://msdn.microsoft.com/library/windows/desktop/ff471331)と[ **IDXGIAdapter** ](https://msdn.microsoft.com/library/windows/desktop/bb174523)取得できるように、 [ **IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556)スワップ チェーンのリソースを作成するオブジェクトに基づく、 [ **DXGI\_スワップ\_チェーン\_DESC1** ](https://msdn.microsoft.com/library/windows/desktop/hh404528)構成します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-169">After that, create an [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) and an [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598), and use them to get the underlying [**IDXGIDevice1**](https://msdn.microsoft.com/library/windows/desktop/ff471331) and [**IDXGIAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174523) so you can obtain an [**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556) object to create a swap chain resource based on your [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) configuration.</span></span>

<span data-ttu-id="ad61c-170">Direct3D の CoreWindow での DXGI スワップ チェーンの構成と設定</span><span class="sxs-lookup"><span data-stu-id="ad61c-170">Configuring and setting the DXGI swap chain on the CoreWindow for Direct3D.</span></span>

``` syntax
// Called when the CoreWindow object is created (or re-created).
void SimpleDirect3DApp::SetWindow(CoreWindow^ window)
{
  // Register event handlers with the CoreWindow object.
  // ...

  // Obtain your ID3D11Device1 and ID3D11DeviceContext1 objects
  // In this example, m_d3dDevice contains the scoped ID3D11Device1 object
  // ...

  ComPtr<IDXGIDevice1>  dxgiDevice;
  // Get the underlying DXGI device of the Direct3D device.
  m_d3dDevice.As(&dxgiDevice);

  ComPtr<IDXGIAdapter> dxgiAdapter;
  dxgiDevice->GetAdapter(&dxgiAdapter);

  ComPtr<IDXGIFactory2> dxgiFactory;
  dxgiAdapter->GetParent(
    __uuidof(IDXGIFactory2), 
    &dxgiFactory);

  DXGI_SWAP_CHAIN_DESC1 swapChainDesc = {0};
  swapChainDesc.Width = static_cast<UINT>(m_d3dRenderTargetSize.Width); // Match the size of the window.
  swapChainDesc.Height = static_cast<UINT>(m_d3dRenderTargetSize.Height);
  swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM; // This is the most common swap chain format.
  swapChainDesc.Stereo = false;
  swapChainDesc.SampleDesc.Count = 1; // Don't use multi-sampling.
  swapChainDesc.SampleDesc.Quality = 0;
  swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
  swapChainDesc.BufferCount = 2; // Use double-buffering to minimize latency.
  swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // All UWP apps must use this SwapEffect.
  swapChainDesc.Flags = 0;

  // ...

  Windows::UI::Core::CoreWindow^ window = m_window.Get();
  dxgiFactory->CreateSwapChainForCoreWindow(
    m_d3dDevice.Get(),
    reinterpret_cast<IUnknown*>(window),
    &swapChainDesc,
    nullptr, // Allow on all displays.
    &m_swapChainCoreWindow);
}
```

<span data-ttu-id="ad61c-171">フレームを表示する準備をした後で [**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-171">Call the [**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) method after you prepare a frame in order to display it.</span></span>

<span data-ttu-id="ad61c-172">Direct3D 11 には、EGLSurface と同じアブストラクションがないことに注意してください </span><span class="sxs-lookup"><span data-stu-id="ad61c-172">Note that in Direct3D 11, there isn't an abstraction identical to EGLSurface.</span></span> <span data-ttu-id="ad61c-173">(ある[ **IDXGISurface1**](https://msdn.microsoft.com/library/windows/desktop/ff471343)、異なる方法で使用されます)。最も近い概念的なものは、 [ **ID3D11RenderTargetView** ](https://msdn.microsoft.com/library/windows/desktop/ff476582)テクスチャの割り当てに使用するオブジェクト ([**ID3D11Texture2D** ](https://msdn.microsoft.com/library/windows/desktop/ff476635)) として、バック バッファー、シェーダーのパイプラインに図形を描画します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-173">(There is [**IDXGISurface1**](https://msdn.microsoft.com/library/windows/desktop/ff471343), but it is used differently.) The closest conceptual approximation is the [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) object that we use to assign a texture ([**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635)) as the back buffer that our shader pipeline will draw into.</span></span>

<span data-ttu-id="ad61c-174">Direct3D 11 でのスワップ チェーンのバック バッファーの設定</span><span class="sxs-lookup"><span data-stu-id="ad61c-174">Setting up the back buffer for the swap chain in Direct3D 11</span></span>

``` syntax
ComPtr<ID3D11RenderTargetView>    m_d3dRenderTargetViewWin; // scoped to renderer object

// ...

ComPtr<ID3D11Texture2D> backBuffer2;
    
m_swapChainCoreWindow->GetBuffer(0, IID_PPV_ARGS(&backBuffer2));

m_d3dDevice->CreateRenderTargetView(
  backBuffer2.Get(),
  nullptr,
    &m_d3dRenderTargetViewWin);
```

<span data-ttu-id="ad61c-175">ウィンドウが作成されたときや、ウィンドウのサイズが変更されたときに、その都度以下のコードを呼び出すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ad61c-175">A good practice is to call this code whenever the window is created or changes size.</span></span> <span data-ttu-id="ad61c-176">レンダリング中には、頂点バッファーやシェーダーなどの他のサブリソースを設定する前に、[**ID3D11DeviceContext1::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) でレンダー ターゲット ビューを設定します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-176">During rendering, set the render target view with [**ID3D11DeviceContext1::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) before setting up any other subresources like vertex buffers or shaders.</span></span>

``` syntax
// Set the render target for the draw operation.
m_d3dContext->OMSetRenderTargets(
        1,
        d3dRenderTargetView.GetAddressOf(),
        nullptr);
```

## <a name="creating-a-rendering-context"></a><span data-ttu-id="ad61c-177">レンダリング コンテキストの作成</span><span class="sxs-lookup"><span data-stu-id="ad61c-177">Creating a rendering context</span></span>


<span data-ttu-id="ad61c-178">EGL 1.4 では、"表示" は、ウィンドウ リソースのセットを表します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-178">In EGL 1.4, a "display" represents a set of window resources.</span></span> <span data-ttu-id="ad61c-179">通常は、表示のための "サーフェス" を構成するために、表示オブジェクトに一連の属性を提供し、サーフェスを取得します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-179">Typically, you configure a "surface" for the display by supplying a set of attributes to the display object and getting a surface in return.</span></span> <span data-ttu-id="ad61c-180">サーフェスのコンテンツを表示するためのコンテキストを作成するには、そのコンテキストを作成したうえで、サーフェスと表示にバインドします。</span><span class="sxs-lookup"><span data-stu-id="ad61c-180">You create a context for displaying the contents of the surface by creating that context and binding it to the surface and the display.</span></span>

<span data-ttu-id="ad61c-181">呼び出しのフローは通常、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="ad61c-181">The call flow usually looks similar to this:</span></span>

-   <span data-ttu-id="ad61c-182">表示 (ウィンドウ リソース) へのハンドルを使って eglGetDisplay を呼び出し、表示オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-182">Call eglGetDisplay with the handle to a display or window resource and obtain a display object.</span></span>
-   <span data-ttu-id="ad61c-183">eglInitialize で表示を初期化します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-183">Initialize the display with eglInitialize.</span></span>
-   <span data-ttu-id="ad61c-184">使用できる表示の構成を取得し、eglGetConfigs と eglChooseConfig でそのいずれかを選びます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-184">Obtain the available display configuration and select one with eglGetConfigs and eglChooseConfig.</span></span>
-   <span data-ttu-id="ad61c-185">eglCreateWindowSurface でウィンドウ サーフェスを作成します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-185">Create a window surface with eglCreateWindowSurface.</span></span>
-   <span data-ttu-id="ad61c-186">eglCreateContext で描画用の表示コンテキストを作成します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-186">Create a display context for drawing with eglCreateContext.</span></span>
-   <span data-ttu-id="ad61c-187">eglMakeCurrent で表示とサーフェスに表示コンテキストをバインドします。</span><span class="sxs-lookup"><span data-stu-id="ad61c-187">Bind the display context to the display and the surface with eglMakeCurrent.</span></span>

<span data-ttu-id="ad61c-188">前のセクションでは EGLDisplay と EGLSurface を作成しました。次に、EGLDisplay を使ってコンテキストを作成し、そのコンテキストを表示に関連付けます。それには、構成済みの EGLSurface を使って出力をパラメーター化します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-188">n the previous section, we created the EGLDisplay and the EGLSurface, and now we use the EGLDisplay to create a context and associate that context with the display, using the configured EGLSurface to parameterize the output.</span></span>

<span data-ttu-id="ad61c-189">EGL 1.4 でのレンダリング コンテキストの取得</span><span class="sxs-lookup"><span data-stu-id="ad61c-189">Obtaining a rendering context with EGL 1.4</span></span>

```cpp
// Configure your EGLDisplay and obtain an EGLSurface here ...
// ...

// Create a drawing context from the EGLDisplay
context = eglCreateContext(display, config, EGL_NO_CONTEXT, contextAttribs);
if (context == EGL_NO_CONTEXT)
{
  return EGL_FALSE;
}   
   
// Make the context current
if (!eglMakeCurrent(display, surface, surface, context))
{
  return EGL_FALSE;
}
```

<span data-ttu-id="ad61c-190">Direct3D 11 のレンダリング コンテキストは、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) オブジェクトで表されます。これはアダプターを表し、バッファーやシェーダーなどの Direct3D リソースを作成するために利用できます。Direct3D 11 のレンダリング コンテキストは [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) オブジェクトでも表され、これを使うと、グラフィックス パイプラインを管理し、シェーダーを実行できます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-190">A rendering context in Direct3D 11 is represented by an [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) object, which represents the adapter and allows you to create Direct3D resources such as buffers and shaders; and by the [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) object, which allows you to manage the graphics pipeline and execute the shaders.</span></span>

<span data-ttu-id="ad61c-191">Direct3D の機能レベルに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ad61c-191">Be aware of Direct3D feature levels!</span></span> <span data-ttu-id="ad61c-192">これらは、DirectX 9.1 から DirectX 11 までの Direct3D ハードウェア プラットフォームをサポートするために使われます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-192">These are used to support older Direct3D hardware platforms, from DirectX 9.1 to DirectX 11.</span></span> <span data-ttu-id="ad61c-193">タブレットなど、低電力のグラフィックス ハードウェアを使う多くのプラットフォームは、DirectX 9.1 の機能にしかアクセスできません。サポートされている古いグラフィックス ハードウェアは、9.1 ～ 11 です。</span><span class="sxs-lookup"><span data-stu-id="ad61c-193">Many platforms that use low power graphics hardware, such as tablets, only have access to DirectX 9.1 features, and older supported graphics hardware could be from 9.1 through 11.</span></span>

<span data-ttu-id="ad61c-194">DXGI と Direct3D でのレンダリング コンテキストの作成</span><span class="sxs-lookup"><span data-stu-id="ad61c-194">Creating a rendering context with DXGI and Direct3D</span></span>

```cpp

// ... 

UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;
ComPtr<IDXGIDevice> dxgiDevice;

D3D_FEATURE_LEVEL featureLevels[] = 
{
        D3D_FEATURE_LEVEL_11_1,
        D3D_FEATURE_LEVEL_11_0,
        D3D_FEATURE_LEVEL_10_1,
        D3D_FEATURE_LEVEL_10_0,
        D3D_FEATURE_LEVEL_9_3,
        D3D_FEATURE_LEVEL_9_2,
        D3D_FEATURE_LEVEL_9_1
};

// Create the Direct3D 11 API device object and a corresponding context.
ComPtr<ID3D11Device> device;
ComPtr<ID3D11DeviceContext> d3dContext;

D3D11CreateDevice(
  nullptr, // Specify nullptr to use the default adapter.
  D3D_DRIVER_TYPE_HARDWARE,
  nullptr,
  creationFlags, // Set set debug and Direct2D compatibility flags.
  featureLevels, // List of feature levels this app can support.
  ARRAYSIZE(featureLevels),
  D3D11_SDK_VERSION, // Always set this to D3D11_SDK_VERSION for UWP apps.
  &device, // Returns the Direct3D device created.
  &m_featureLevel, // Returns feature level of device created.
  &d3dContext // Returns the device immediate context.
);
```

## <a name="drawing-into-a-texture-or-pixmap-resource"></a><span data-ttu-id="ad61c-195">テクスチャまたは pixmap リソースへの描画</span><span class="sxs-lookup"><span data-stu-id="ad61c-195">Drawing into a texture or pixmap resource</span></span>


<span data-ttu-id="ad61c-196">OpenGL ES 2.0 でテクスチャに描画するには、ピクセル バッファー (PBuffer) を構成します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-196">To draw into a texture with OpenGL ES 2.0, configure a pixel buffer, or PBuffer.</span></span> <span data-ttu-id="ad61c-197">それに対して EGLSurface を正常に構成して作成したら、それにレンダリング コンテキストを提供し、シェーダー パイプラインを実行してテクスチャに描画できます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-197">After you successfully a configure and create an EGLSurface for it you can supply it with a rendering context and execute the shader pipeline to draw into the texture.</span></span>

<span data-ttu-id="ad61c-198">OpenGL ES 2.0 でのピクセル バッファーへの描画</span><span class="sxs-lookup"><span data-stu-id="ad61c-198">Draw into a pixel buffer with OpenGL ES 2.0</span></span>

``` syntax
// Create a pixel buffer surface to draw into
EGLConfig pBufConfig;
EGLint totalpBufAttrs;

const EGLint pBufConfigAttrs[] =
{
    // Configure the pBuffer here...
};
 
eglChooseConfig(eglDsplay, pBufConfigAttrs, &pBufConfig, 1, &totalpBufAttrs);
EGLSurface pBuffer = eglCreatePbufferSurface(eglDisplay, pBufConfig, EGL_TEXTURE_RGBA); 
```

<span data-ttu-id="ad61c-199">Direct3D 11 では、[**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) リソースを作成してそれをレンダー ターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="ad61c-199">In Direct3D 11, you create an [**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) resource and makei it a render target.</span></span> <span data-ttu-id="ad61c-200">レンダー ターゲットを使用して、構成[ **D3D11\_レンダリング\_ターゲット\_ビュー\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476201)します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-200">Configure the render target using [**D3D11\_RENDER\_TARGET\_VIEW\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476201).</span></span> <span data-ttu-id="ad61c-201">呼び出すと、 [ **ID3D11DeviceContext::Draw** ](https://msdn.microsoft.com/library/windows/desktop/ff476407)メソッド (または類似の描画\*デバイス コンテキストでの操作)、結果はこのレンダー ターゲットを使用して、テクスチャに描画されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-201">When you call the [**ID3D11DeviceContext::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407) method(or a similar Draw\* operation on the device context) using this render target, the results are drawn into a texture.</span></span>

<span data-ttu-id="ad61c-202">Direct3D 11 でのテクスチャへの描画</span><span class="sxs-lookup"><span data-stu-id="ad61c-202">Draw into a texture with Direct3D 11</span></span>

``` syntax
ComPtr<ID3D11Texture2D> renderTarget1;

D3D11_RENDER_TARGET_VIEW_DESC renderTargetDesc = {0};
// Configure renderTargetDesc here ...

m_d3dDevice->CreateRenderTargetView(
  renderTarget1.Get(),
  nullptr,
  &m_d3dRenderTargetViewWin);

// Later, in your render loop...

// Set the render target for the draw operation.
m_d3dContext->OMSetRenderTargets(
        1,
        d3dRenderTargetView.GetAddressOf(),
        nullptr);
```

<span data-ttu-id="ad61c-203">このテクスチャは、[**ID3D11ShaderResourceView**](https://msdn.microsoft.com/library/windows/desktop/ff476628) に関連付けられている場合はシェーダーに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-203">This texture can be passed to a shader if it is associated with an [**ID3D11ShaderResourceView**](https://msdn.microsoft.com/library/windows/desktop/ff476628).</span></span>

## <a name="drawing-to-the-screen"></a><span data-ttu-id="ad61c-204">画面への描画</span><span class="sxs-lookup"><span data-stu-id="ad61c-204">Drawing to the screen</span></span>


<span data-ttu-id="ad61c-205">EGLContext を使ってバッファーの構成とデータの更新を行ったら、それにバインドされているシェーダーを実行し、glDrawElements でバック バッファーに結果を描画します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-205">Once you have used your EGLContext to configure your buffers and update your data, you run the shaders bound to it and draw the results to the back buffer with glDrawElements.</span></span> <span data-ttu-id="ad61c-206">eglSwapBuffers を呼び出してバック バッファーを表示します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-206">You display the back buffer by calling eglSwapBuffers.</span></span>

<span data-ttu-id="ad61c-207">Opengl ES 2.0:画面に描画します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-207">Open GL ES 2.0: Drawing to the screen.</span></span>

``` syntax
glDrawElements(GL_TRIANGLES, renderer->numIndices, GL_UNSIGNED_INT, 0);

eglSwapBuffers(drawContext->eglDisplay, drawContext->eglSurface);
```

<span data-ttu-id="ad61c-208">Direct3D 11 では、[**IDXGISwapChain::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) でバッファーを構成してシェーダーにバインドします。</span><span class="sxs-lookup"><span data-stu-id="ad61c-208">In Direct3D 11, you configure your buffers and bind shaders with your [**IDXGISwapChain::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797).</span></span> <span data-ttu-id="ad61c-209">いずれかを呼び出す、 [ **ID3D11DeviceContext1::Draw** ](https://msdn.microsoft.com/library/windows/desktop/ff476407) \*シェーダーを実行し、結果をスワップ チェーンのバック バッファーとして構成されているレンダー ターゲットに描画するメソッド。</span><span class="sxs-lookup"><span data-stu-id="ad61c-209">Then you call one of the [**ID3D11DeviceContext1::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407)\* methods to run the shaders and draw the results to a render target configured as the back buffer for the swap chain.</span></span> <span data-ttu-id="ad61c-210">その後、単純に **IDXGISwapChain::Present1** を呼び出してバック バッファーをディスプレイに表示します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-210">After that, you simply present the back buffer to the display by calling **IDXGISwapChain::Present1**.</span></span>

<span data-ttu-id="ad61c-211">Direct3D 11。画面に描画します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-211">Direct3D 11: Drawing to the screen.</span></span>

``` syntax

m_d3dContext->DrawIndexed(
        m_indexCount,
        0,
        0);

// ...

m_swapChainCoreWindow->Present1(1, 0, &parameters);
```

## <a name="releasing-graphics-resources"></a><span data-ttu-id="ad61c-212">グラフィックス リソースの解放</span><span class="sxs-lookup"><span data-stu-id="ad61c-212">Releasing graphics resources</span></span>


<span data-ttu-id="ad61c-213">EGL では、eglTerminate に EGLDisplay を渡して、ウィンドウ リソースを解放します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-213">In EGL, you release the window resources by passing the EGLDisplay to eglTerminate.</span></span>

<span data-ttu-id="ad61c-214">EGL 1.4 での表示の終了</span><span class="sxs-lookup"><span data-stu-id="ad61c-214">Terminating a display with EGL 1.4</span></span>

```cpp
EGLBoolean eglTerminate(eglDisplay);
```

<span data-ttu-id="ad61c-215">UWP アプリでは、[**CoreWindow::Close**](https://msdn.microsoft.com/library/windows/apps/br208260) で CoreWindow を閉じることができますが、これはセカンダリ UI ウィンドウに対してのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-215">In a UWP app, you can close the CoreWindow with [**CoreWindow::Close**](https://msdn.microsoft.com/library/windows/apps/br208260), although this can only be used for secondary UI windows.</span></span> <span data-ttu-id="ad61c-216">プライマリ UI スレッドとその関連の CoreWindow は閉じることはできません。オペレーティング システムによって有効期限切れの処理が行われます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-216">The primary UI thread and its associated CoreWindow cannot be closed; rather, they are expired by the operating system.</span></span> <span data-ttu-id="ad61c-217">ただし、セカンダリ CoreWindow が閉じると、[**CoreWindow::Closed**](https://msdn.microsoft.com/library/windows/apps/br208261) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-217">However, when a secondary CoreWindow is closed, the [**CoreWindow::Closed**](https://msdn.microsoft.com/library/windows/apps/br208261) event is raised.</span></span>

## <a name="api-reference-mapping-for-egl-to-direct3d-11"></a><span data-ttu-id="ad61c-218">EGL と Direct3D 11 のマッピングを示す API リファレンス</span><span class="sxs-lookup"><span data-stu-id="ad61c-218">API Reference mapping for EGL to Direct3D 11</span></span>


| <span data-ttu-id="ad61c-219">EGL API</span><span class="sxs-lookup"><span data-stu-id="ad61c-219">EGL API</span></span>                          | <span data-ttu-id="ad61c-220">同様の Direct3D 11 API または動作</span><span class="sxs-lookup"><span data-stu-id="ad61c-220">Similar Direct3D 11 API or behavior</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
|----------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="ad61c-221">eglBindAPI</span><span class="sxs-lookup"><span data-stu-id="ad61c-221">eglBindAPI</span></span>                       | <span data-ttu-id="ad61c-222">該当なし。</span><span class="sxs-lookup"><span data-stu-id="ad61c-222">N/A.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| <span data-ttu-id="ad61c-223">eglBindTexImage</span><span class="sxs-lookup"><span data-stu-id="ad61c-223">eglBindTexImage</span></span>                  | <span data-ttu-id="ad61c-224">[  **ID3D11Device::CreateTexture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476521) を呼び出して 2D テクスチャを設定します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-224">Call [**ID3D11Device::CreateTexture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476521) to set a 2D texture.</span></span>                                                                                                                                                                                                                                                                                                                                                                                          |
| <span data-ttu-id="ad61c-225">eglChooseConfig</span><span class="sxs-lookup"><span data-stu-id="ad61c-225">eglChooseConfig</span></span>                  | <span data-ttu-id="ad61c-226">Direct3D は一連の既定のフレーム バッファー構成を提供しません。</span><span class="sxs-lookup"><span data-stu-id="ad61c-226">Direct3D does not supply a set of default frame buffer configurations.</span></span> <span data-ttu-id="ad61c-227">スワップ チェーンの構成</span><span class="sxs-lookup"><span data-stu-id="ad61c-227">The swap chain's configuration</span></span>                                                                                                                                                                                                                                                                                                                                                                                           |
| <span data-ttu-id="ad61c-228">eglCopyBuffers</span><span class="sxs-lookup"><span data-stu-id="ad61c-228">eglCopyBuffers</span></span>                   | <span data-ttu-id="ad61c-229">バッファー データをコピーするには、[**ID3D11DeviceContext::CopyStructureCount**](https://msdn.microsoft.com/library/windows/desktop/ff476393) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-229">To copy a buffer data, call [**ID3D11DeviceContext::CopyStructureCount**](https://msdn.microsoft.com/library/windows/desktop/ff476393).</span></span> <span data-ttu-id="ad61c-230">リソースをコピーするには、[**ID3DDeviceCOntext::CopyResource**](https://msdn.microsoft.com/library/windows/desktop/ff476392) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-230">To copy a resource, call [**ID3DDeviceCOntext::CopyResource**](https://msdn.microsoft.com/library/windows/desktop/ff476392).</span></span>                                                                                                                                                                                                                                                      |
| <span data-ttu-id="ad61c-231">eglCreateContext</span><span class="sxs-lookup"><span data-stu-id="ad61c-231">eglCreateContext</span></span>                 | <span data-ttu-id="ad61c-232">Direct3D デバイス コンテキストを作成するには、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出します。これは、Direct3D デバイスへのハンドルと既定の Direct3D イミディエイト コンテキスト ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) オブジェクト) の両方を返します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-232">Create a Direct3D device context by calling [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082), which returns both a handle to a Direct3D device and a default Direct3D immediate context ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) object).</span></span> <span data-ttu-id="ad61c-233">返された [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) オブジェクトで [**ID3D11Device2::CreateDeferredContext**](https://msdn.microsoft.com/library/windows/desktop/dn280495) を呼び出して、Direct3D 遅延コンテキストを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-233">You can also create a Direct3D deferred context by calling [**ID3D11Device2::CreateDeferredContext**](https://msdn.microsoft.com/library/windows/desktop/dn280495) on the returned [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) object.</span></span> |
| <span data-ttu-id="ad61c-234">eglCreatePbufferFromClientBuffer</span><span class="sxs-lookup"><span data-stu-id="ad61c-234">eglCreatePbufferFromClientBuffer</span></span> | <span data-ttu-id="ad61c-235">すべてのバッファーは、[**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) などの Direct3D サブリソースとして、読み取りと書き込みが行われます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-235">All buffers are read and written as a Direct3D subresource, such as an [**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635).</span></span> <span data-ttu-id="ad61c-236">[  **ID3D11DeviceContext1:CopyResource**](https://msdn.microsoft.com/library/windows/desktop/ff476392) などのメソッドを使って、互換性のあるサブリソース型の間でコピーします。</span><span class="sxs-lookup"><span data-stu-id="ad61c-236">Copy from one to another compatible subresource type with a methods such as [**ID3D11DeviceContext1:CopyResource**](https://msdn.microsoft.com/library/windows/desktop/ff476392).</span></span>                                                                                                                                                                                                     |
| <span data-ttu-id="ad61c-237">eglCreatePbufferSurface</span><span class="sxs-lookup"><span data-stu-id="ad61c-237">eglCreatePbufferSurface</span></span>          | <span data-ttu-id="ad61c-238">スワップ チェーンなしで Direct3D デバイスを作成するには、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) 静的メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-238">To create a Direct3D device with no swap chain, call the static [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) method.</span></span> <span data-ttu-id="ad61c-239">Direct3D レンダー ターゲット ビューでは、[**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-239">For a Direct3D render target view, call [**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517).</span></span>                                                                                                                                                                                                                               |
| <span data-ttu-id="ad61c-240">eglCreatePixmapSurface</span><span class="sxs-lookup"><span data-stu-id="ad61c-240">eglCreatePixmapSurface</span></span>           | <span data-ttu-id="ad61c-241">スワップ チェーンなしで Direct3D デバイスを作成するには、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) 静的メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-241">To create a Direct3D device with no swap chain, call the static [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) method.</span></span> <span data-ttu-id="ad61c-242">Direct3D レンダー ターゲット ビューでは、[**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-242">For a Direct3D render target view, call [**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517).</span></span>                                                                                                                                                                                                                               |
| <span data-ttu-id="ad61c-243">eglCreateWindowSurface</span><span class="sxs-lookup"><span data-stu-id="ad61c-243">eglCreateWindowSurface</span></span>           | <span data-ttu-id="ad61c-244">[  **IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) (表示バッファー向け) と [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) (グラフィックス デバイスとそのリソースの仮想インターフェイス) を取得します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-244">Ontain an [**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) (for the display buffers) and an [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) (a virtual interface for the graphics device and its resources).</span></span> <span data-ttu-id="ad61c-245">**IDXGISwapChain1** に提供するフレーム バッファーを作成するために使用できる [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) を定義するには、**ID3D11Device1** を使います。</span><span class="sxs-lookup"><span data-stu-id="ad61c-245">Use the **ID3D11Device1** to define an [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) that you can use to create the frame buffer you supply to the **IDXGISwapChain1**.</span></span>                                                                                         |
| <span data-ttu-id="ad61c-246">eglDestroyContext</span><span class="sxs-lookup"><span data-stu-id="ad61c-246">eglDestroyContext</span></span>                | <span data-ttu-id="ad61c-247">該当なし。</span><span class="sxs-lookup"><span data-stu-id="ad61c-247">N/A.</span></span> <span data-ttu-id="ad61c-248">レンダー ターゲット ビューを削除するには、[**ID3D11DeviceContext::DiscardView1**](https://msdn.microsoft.com/library/windows/desktop/jj247573) を使います。</span><span class="sxs-lookup"><span data-stu-id="ad61c-248">Use [**ID3D11DeviceContext::DiscardView1**](https://msdn.microsoft.com/library/windows/desktop/jj247573) to get rid of a render target view.</span></span> <span data-ttu-id="ad61c-249">親 [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) を閉じるには、インスタンスを null に設定し、プラットフォームがそのリソースを再利用するまで待機します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-249">To close the parent [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598), set the instance to null and wait for the platform to reclaim its resources.</span></span> <span data-ttu-id="ad61c-250">デバイス コンテキストを直接破棄することはできません。</span><span class="sxs-lookup"><span data-stu-id="ad61c-250">You cannot destroy the device context directly.</span></span>                                                                                                                                                |
| <span data-ttu-id="ad61c-251">eglDestroySurface</span><span class="sxs-lookup"><span data-stu-id="ad61c-251">eglDestroySurface</span></span>                | <span data-ttu-id="ad61c-252">該当なし。</span><span class="sxs-lookup"><span data-stu-id="ad61c-252">N/A.</span></span> <span data-ttu-id="ad61c-253">グラフィックス リソースは、UWP アプリの CoreWindow がプラットフォームによって閉じられたときにクリーンアップされます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-253">Graphics resources are cleaned up when the UWP app's CoreWindow is closed by the platform.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                 |
| <span data-ttu-id="ad61c-254">eglGetCurrentDisplay</span><span class="sxs-lookup"><span data-stu-id="ad61c-254">eglGetCurrentDisplay</span></span>             | <span data-ttu-id="ad61c-255">現在のメイン アプリ ウィンドウへの参照を取得するには、[**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-255">Call [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) to get a reference to the current main app window.</span></span>                                                                                                                                                                                                                                                                                                                                                         |
| <span data-ttu-id="ad61c-256">eglGetCurrentSurface</span><span class="sxs-lookup"><span data-stu-id="ad61c-256">eglGetCurrentSurface</span></span>             | <span data-ttu-id="ad61c-257">これが現在の [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) です。</span><span class="sxs-lookup"><span data-stu-id="ad61c-257">This is the current [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582).</span></span> <span data-ttu-id="ad61c-258">通常、これのスコープはレンダラー オブジェクトに限定されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-258">Typically, this is scoped to your renderer object.</span></span>                                                                                                                                                                                                                                                                                                                                                         |
| <span data-ttu-id="ad61c-259">eglGetError</span><span class="sxs-lookup"><span data-stu-id="ad61c-259">eglGetError</span></span>                      | <span data-ttu-id="ad61c-260">エラーは、DirectX インターフェイスのほとんどのメソッドによって返される HRESULT として取得されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-260">Errors are obtained as HRESULTs returned by most methods on DirectX interfaces.</span></span> <span data-ttu-id="ad61c-261">メソッドから HRESULT が返されない場合は、[**GetLastError**](https://msdn.microsoft.com/library/windows/desktop/ms679360) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-261">If the method does not return an HRESULT, call [**GetLastError**](https://msdn.microsoft.com/library/windows/desktop/ms679360).</span></span> <span data-ttu-id="ad61c-262">HRESULT 値にシステム エラーに変換する、 [**HRESULT\_FROM\_WIN32**](https://msdn.microsoft.com/library/windows/desktop/ms680746) マクロ。</span><span class="sxs-lookup"><span data-stu-id="ad61c-262">To convert a system error into an HRESULT value, use the [**HRESULT\_FROM\_WIN32**](https://msdn.microsoft.com/library/windows/desktop/ms680746) macro.</span></span>                                                                                                                                                                                                  |
| <span data-ttu-id="ad61c-263">eglInitialize</span><span class="sxs-lookup"><span data-stu-id="ad61c-263">eglInitialize</span></span>                    | <span data-ttu-id="ad61c-264">現在のメイン アプリ ウィンドウへの参照を取得するには、[**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-264">Call [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) to get a reference to the current main app window.</span></span>                                                                                                                                                                                                                                                                                                                                                         |
| <span data-ttu-id="ad61c-265">eglMakeCurrent</span><span class="sxs-lookup"><span data-stu-id="ad61c-265">eglMakeCurrent</span></span>                   | <span data-ttu-id="ad61c-266">[  **ID3D11DeviceContext1::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) を使って、現在のコンテキストに描画するためのレンダー ターゲットを設定します。</span><span class="sxs-lookup"><span data-stu-id="ad61c-266">Set a render target for drawing on the current context with [**ID3D11DeviceContext1::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464).</span></span>                                                                                                                                                                                                                                                                                                                                  |
| <span data-ttu-id="ad61c-267">eglQueryContext</span><span class="sxs-lookup"><span data-stu-id="ad61c-267">eglQueryContext</span></span>                  | <span data-ttu-id="ad61c-268">該当なし。</span><span class="sxs-lookup"><span data-stu-id="ad61c-268">N/A.</span></span> <span data-ttu-id="ad61c-269">ただし、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) インスタンスからレンダリング ターゲットと一部の構成データを取得できます </span><span class="sxs-lookup"><span data-stu-id="ad61c-269">However, you may acquire rendering targets from an [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) instance, as well as some configuration data.</span></span> <span data-ttu-id="ad61c-270">(利用できるメソッドの一覧については、リンクをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="ad61c-270">(See the link for the list of available methods.)</span></span>                                                                                                                                                                                                                                                                                           |
| <span data-ttu-id="ad61c-271">eglQuerySurface</span><span class="sxs-lookup"><span data-stu-id="ad61c-271">eglQuerySurface</span></span>                  | <span data-ttu-id="ad61c-272">該当なし。</span><span class="sxs-lookup"><span data-stu-id="ad61c-272">N/A.</span></span> <span data-ttu-id="ad61c-273">ただし、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) インスタンスのメソッドからビューポートと現在のグラフィックス ハードウェアに関するデータを取得できます </span><span class="sxs-lookup"><span data-stu-id="ad61c-273">However, you may acquire data about viewports and the current graphics hardware from methods on an [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) instance.</span></span> <span data-ttu-id="ad61c-274">(利用できるメソッドの一覧については、リンクをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="ad61c-274">(See the link for the list of available methods.)</span></span>                                                                                                                                                                                                                                                                               |
| <span data-ttu-id="ad61c-275">eglReleaseTexImage</span><span class="sxs-lookup"><span data-stu-id="ad61c-275">eglReleaseTexImage</span></span>               | <span data-ttu-id="ad61c-276">該当なし。</span><span class="sxs-lookup"><span data-stu-id="ad61c-276">N/A.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| <span data-ttu-id="ad61c-277">eglReleaseThread</span><span class="sxs-lookup"><span data-stu-id="ad61c-277">eglReleaseThread</span></span>                 | <span data-ttu-id="ad61c-278">一般的な GPU マルチスレッドについては、「[マルチスレッド](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad61c-278">For general GPU multithreading, read [Multithreading](https://msdn.microsoft.com/library/windows/desktop/ff476891).</span></span>                                                                                                                                                                                                                                                                                                                                                                              |
| <span data-ttu-id="ad61c-279">eglSurfaceAttrib</span><span class="sxs-lookup"><span data-stu-id="ad61c-279">eglSurfaceAttrib</span></span>                 | <span data-ttu-id="ad61c-280">使用[ **D3D11\_レンダリング\_ターゲット\_ビュー\_DESC** ](https://msdn.microsoft.com/library/windows/desktop/ff476201) Direct3D のレンダー ターゲット ビューを構成するには</span><span class="sxs-lookup"><span data-stu-id="ad61c-280">Use [**D3D11\_RENDER\_TARGET\_VIEW\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476201) to configure a Direct3D render target view,</span></span>                                                                                                                                                                                                                                                                                                                                                               |
| <span data-ttu-id="ad61c-281">eglSwapBuffers</span><span class="sxs-lookup"><span data-stu-id="ad61c-281">eglSwapBuffers</span></span>                   | <span data-ttu-id="ad61c-282">[  **IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) を使います。</span><span class="sxs-lookup"><span data-stu-id="ad61c-282">Use [**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797).</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                     |
| <span data-ttu-id="ad61c-283">eglSwapInterval</span><span class="sxs-lookup"><span data-stu-id="ad61c-283">eglSwapInterval</span></span>                  | <span data-ttu-id="ad61c-284">「[**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad61c-284">See [**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631).</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| <span data-ttu-id="ad61c-285">eglTerminate</span><span class="sxs-lookup"><span data-stu-id="ad61c-285">eglTerminate</span></span>                     | <span data-ttu-id="ad61c-286">グラフィックス パイプラインの出力を表示するために使う CoreWindow は、オペレーティング システムによって管理されます。</span><span class="sxs-lookup"><span data-stu-id="ad61c-286">The CoreWindow used to display the output of the graphics pipeline is managed by the operating system.</span></span>                                                                                                                                                                                                                                                                                                                                                                                          |
| <span data-ttu-id="ad61c-287">eglWaitClient</span><span class="sxs-lookup"><span data-stu-id="ad61c-287">eglWaitClient</span></span>                    | <span data-ttu-id="ad61c-288">共有サーフェスについては、IDXGIKeyedMutex を使います。</span><span class="sxs-lookup"><span data-stu-id="ad61c-288">For shared surfaces, use IDXGIKeyedMutex.</span></span> <span data-ttu-id="ad61c-289">一般的な GPU マルチスレッドについては、「[マルチスレッド](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad61c-289">For general GPU multithreading, read [Multithreading](https://msdn.microsoft.com/library/windows/desktop/ff476891).</span></span>                                                                                                                                                                                                                                                                                                                                    |
| <span data-ttu-id="ad61c-290">eglWaitGL</span><span class="sxs-lookup"><span data-stu-id="ad61c-290">eglWaitGL</span></span>                        | <span data-ttu-id="ad61c-291">共有サーフェスについては、IDXGIKeyedMutex を使います。</span><span class="sxs-lookup"><span data-stu-id="ad61c-291">For shared surfaces, use IDXGIKeyedMutex.</span></span> <span data-ttu-id="ad61c-292">一般的な GPU マルチスレッドについては、「[マルチスレッド](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad61c-292">For general GPU multithreading, read [Multithreading](https://msdn.microsoft.com/library/windows/desktop/ff476891).</span></span>                                                                                                                                                                                                                                                                                                                                    |
| <span data-ttu-id="ad61c-293">eglWaitNative</span><span class="sxs-lookup"><span data-stu-id="ad61c-293">eglWaitNative</span></span>                    | <span data-ttu-id="ad61c-294">共有サーフェスについては、IDXGIKeyedMutex を使います。</span><span class="sxs-lookup"><span data-stu-id="ad61c-294">For shared surfaces, use IDXGIKeyedMutex.</span></span> <span data-ttu-id="ad61c-295">一般的な GPU マルチスレッドについては、「[マルチスレッド](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad61c-295">For general GPU multithreading, read [Multithreading](https://msdn.microsoft.com/library/windows/desktop/ff476891).</span></span>                                                                                                                                                                                                                                                                                                                                    |

 

 

 




