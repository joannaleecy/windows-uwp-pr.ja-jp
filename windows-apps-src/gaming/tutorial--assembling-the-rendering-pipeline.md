---
author: joannaleecy
title: レンダリングの概要
description: グラフィックスを表示するレンダリング パイプラインをアセンブルする方法について説明します。 レンダリングの概要。
ms.assetid: 1da3670b-2067-576f-da50-5eba2f88b3e6
ms.author: joanlee
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, レンダリング
ms.localizationpriority: medium
ms.openlocfilehash: 7e8df200e8e989015834608d38cb8dfb0d36917b
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7299778"
---
# <a name="rendering-framework-i-intro-to-rendering"></a><span data-ttu-id="461d0-105">レンダリング フレームワーク I: レンダリングの概要</span><span class="sxs-lookup"><span data-stu-id="461d0-105">Rendering framework I: Intro to rendering</span></span>

<span data-ttu-id="461d0-106">これまでのトピックでは、Windows ランタイムで動作するユニバーサル Windows プラットフォーム (UWP) ゲームを構築する方法、ステート マシンを定義してゲームのフローを処理する方法について説明してきました。</span><span class="sxs-lookup"><span data-stu-id="461d0-106">We've covered how to structure a Universal Windows Platform (UWP) game and how to define a state machine to handle the flow of the game in the earlier topics.</span></span> <span data-ttu-id="461d0-107">ここでは、レンダリング フレームワークをアセンブルする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="461d0-107">Now, it's time to learn how to assemble the rendering framework.</span></span> <span data-ttu-id="461d0-108">サンプル ゲームで Direct3D11 (通常は DirectX 11 と呼ばれます) を使用してゲームのシーンをレンダリングする方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="461d0-108">Let's look at how the sample game renders the game scene using Direct3D11 (commonly known as DirectX 11).</span></span>

>[!Note]
><span data-ttu-id="461d0-109">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-109">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="461d0-110">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="461d0-110">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="461d0-111">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461d0-111">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

<span data-ttu-id="461d0-112">Direct3D 11 には、ゲームなどのグラフィックス負荷の高いアプリケーションの 3D グラフィックスを作成するために使用できる高パフォーマンスのグラフィックス ハードウェアの高度な機能へのアクセスを提供する API のセットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="461d0-112">Direct3D 11 contains a set of APIs that provide access to the advanced features of high-performance graphic hardware that can be used to create 3D graphics for graphic intensive applications such as games.</span></span>

<span data-ttu-id="461d0-113">画面上のゲームのグラフィックのレンダリングは、基本的に画面上のフレームのシーケンスのレンダリングです。</span><span class="sxs-lookup"><span data-stu-id="461d0-113">Rendering game graphics on-screen is basically rendering a sequence of frames on-screen.</span></span> <span data-ttu-id="461d0-114">各フレームでは、ビューに基づいて、シーンに表示されているオブジェクトをレンダリングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-114">In each frame, you have to render objects that are visible in the scene, based on the view.</span></span> 

<span data-ttu-id="461d0-115">フレームをレンダリングするには、画面に表示できるように、必要なシーンの情報をハードウェアに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-115">In order to render a frame, you have to pass the required scene information to the hardware so that it can be displayed on the screen.</span></span> <span data-ttu-id="461d0-116">何かを画面に表示するには、ゲームの実行を開始すると同時にレンダリングを開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-116">If you want to have anything displayed on screen, you need to start rendering as soon as the game starts running.</span></span>

## <a name="objective"></a><span data-ttu-id="461d0-117">目標</span><span class="sxs-lookup"><span data-stu-id="461d0-117">Objective</span></span>

<span data-ttu-id="461d0-118">基本的なレンダリング フレームワークを設定して、UWP DirectX ゲームのグラフィックス出力を表示する方法は、大きく次の 3 つの手順にグループ分けすることができます。</span><span class="sxs-lookup"><span data-stu-id="461d0-118">To set up a basic rendering framework to display the graphics output for a UWP DirectX game, you can loosely group them into these three steps.</span></span>

 1. <span data-ttu-id="461d0-119">グラフィックス インターフェイスへの接続を確立する</span><span class="sxs-lookup"><span data-stu-id="461d0-119">Establish a connection to the graphics interface</span></span>
 2. <span data-ttu-id="461d0-120">グラフィックスを描画するために必要なリソースを作成する</span><span class="sxs-lookup"><span data-stu-id="461d0-120">Create the resources needed to draw the graphics</span></span>
 3. <span data-ttu-id="461d0-121">フレームをレンダリングすることによってグラフィックスを表示する</span><span class="sxs-lookup"><span data-stu-id="461d0-121">Display the graphics by rendering the frame</span></span>

<span data-ttu-id="461d0-122">この記事では、手順 1 と 3 を取り上げて、グラフィックスをレンダリングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="461d0-122">This article explains how graphics are rendered, covering steps 1 and 3.</span></span>

<span data-ttu-id="461d0-123">「[レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)」では手順 2 を取り上げて、レンダリング フレームワークを設定する方法と、レンダリングの前にデータを準備する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="461d0-123">[Rendering framework II: Game rendering](tutorial-game-rendering.md) covers step 2; how to set up the rendering framework and how data is prepared before rendering can happen.</span></span>

## <a name="get-started"></a><span data-ttu-id="461d0-124">概要</span><span class="sxs-lookup"><span data-stu-id="461d0-124">Get started</span></span>

<span data-ttu-id="461d0-125">作業を開始する前に、基本的なグラフィックスとレンダリングの概念を理解しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-125">Before you begin, you should familiarize yourself with the basic graphics and rendering concepts.</span></span> <span data-ttu-id="461d0-126">Direct3D とレンダリングを使用して初めて開発を行う場合は、この記事で使用するグラフィックスとレンダリング用語の簡単な説明については、「[用語と概念](#terms-and-concepts)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-126">If you're new to Direct3D and rendering, see [Terms and concepts](#terms-and-concepts) for a brief description of the graphics and rendering terms used in this article.</span></span>

<span data-ttu-id="461d0-127">このゲームでは、__GameRenderer__ クラス オブジェクトがこのサンプル ゲームのレンダラーを表します。</span><span class="sxs-lookup"><span data-stu-id="461d0-127">For this game, the __GameRenderer__ class object represents the renderer for this sample game.</span></span>  <span data-ttu-id="461d0-128">レンダラーは、ゲームの視覚効果を生成するために使用する、すべての Direct3D 11 オブジェクトと Direct2D オブジェクトの作成と保持を担当します。</span><span class="sxs-lookup"><span data-stu-id="461d0-128">It's responsible for creating and maintaining all the Direct3D 11 and Direct2D objects used to generate the game visuals.</span></span>  <span data-ttu-id="461d0-129">また、レンダリングするオブジェクトのリストとヘッドアップ ディスプレイ (HUD) 用にゲームの状態を取得するために使用される __Simple3DGame__ オブジェクトへの参照も保持します。</span><span class="sxs-lookup"><span data-stu-id="461d0-129">It also maintains a reference to the __Simple3DGame__ object used to retrieve the list of objects to render as well as status of the game for the Heads Up Display (HUD).</span></span> 

<span data-ttu-id="461d0-130">このチュートリアルでは、ゲームの 3D オブジェクトのレンダリングに重点を置いています。</span><span class="sxs-lookup"><span data-stu-id="461d0-130">In this part of the tutorial, we'll focus on rendering 3D objects in the game.</span></span>

## <a name="establish-a-connection-to-the-graphics-interface"></a><span data-ttu-id="461d0-131">グラフィックス インターフェイスへの接続を確立する</span><span class="sxs-lookup"><span data-stu-id="461d0-131">Establish a connection to the graphics interface</span></span>

<span data-ttu-id="461d0-132">レンダリング用のハードウェアにアクセスする方法については、UWP フレームワークの記事にある [__App::Initialize__](tutorial--building-the-games-uwp-app-framework.md#appinitialize-method) の説明を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-132">To access to the hardware for rendering, see the UWP framework article under [__App::Initialize__](tutorial--building-the-games-uwp-app-framework.md#appinitialize-method).</span></span>

<span data-ttu-id="461d0-133">__make\_shared 関数__は ([以下](#appinitialize-method)に示すように) [__DX::DeviceResources__](#dxdeviceresources) への __shared\_ptr__ を作成するために使用されます。これもデバイスへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="461d0-133">The __make\_shared function__, as shown [below](#appinitialize-method), is used to create a __shared\_ptr__ to [__DX::DeviceResources__](#dxdeviceresources), which also provides access to the device.</span></span> 

<span data-ttu-id="461d0-134">Direct3D 11 では、[デバイス](#device)を使用して、オブジェクトの割り当てと破棄、プリミティブのレンダリング、グラフィックス ドライバー経由のグラフィックス カードとの通信を行います。</span><span class="sxs-lookup"><span data-stu-id="461d0-134">In Direct3D 11, a [device](#device) is used to allocate and destroy objects, render primitives, and communicate with the graphics card through the graphics driver.</span></span>

### <a name="appinitialize-method"></a><span data-ttu-id="461d0-135">App::Initialize メソッド</span><span class="sxs-lookup"><span data-stu-id="461d0-135">App::Initialize method</span></span>

```cpp
void App::Initialize(
    CoreApplicationView^ applicationView
    )
{
    //...

    // At this point we have access to the device. 
    // We can create the device-dependent resources.
    m_deviceResources = std::make_shared<DX::DeviceResources>();
}
```

## <a name="display-the-graphics-by-rendering-the-frame"></a><span data-ttu-id="461d0-136">フレームをレンダリングすることによってグラフィックスを表示する</span><span class="sxs-lookup"><span data-stu-id="461d0-136">Display the graphics by rendering the frame</span></span>

<span data-ttu-id="461d0-137">ゲームのシーンは、ゲームが起動したときにレンダリングされる必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-137">The game scene needs to render when the game is launched.</span></span> <span data-ttu-id="461d0-138">レンダリングのための手順は、以下に示すように、[__GameMain::Run__](#gameamainrun-method) メソッド内で始まります。</span><span class="sxs-lookup"><span data-stu-id="461d0-138">The instructions for rendering start in the  [__GameMain::Run__](#gameamainrun-method) method, as shown below.</span></span>

<span data-ttu-id="461d0-139">単純なフローは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="461d0-139">The simple flow is:</span></span>
1. __<span data-ttu-id="461d0-140">Update</span><span class="sxs-lookup"><span data-stu-id="461d0-140">Update</span></span>__
2. __<span data-ttu-id="461d0-141">Render</span><span class="sxs-lookup"><span data-stu-id="461d0-141">Render</span></span>__
3. __<span data-ttu-id="461d0-142">Present</span><span class="sxs-lookup"><span data-stu-id="461d0-142">Present</span></span>__

### <a name="gamemainrun-method"></a><span data-ttu-id="461d0-143">GameMain::Run メソッド</span><span class="sxs-lookup"><span data-stu-id="461d0-143">GameMain::Run method</span></span>

```cpp
// Comparing this to App::Run() in the DirectX 11 App template
void GameMain::Run()
{
    while (!m_windowClosed)
    {
        if (m_visible) // if the window is visible
        {
            // Added: Switching different game states since this game sample is more complex
            switch (m_updateState) 
            {

                // ...
                CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
                // 1. Update
                // Also exist in DirectX 11 App template: Update loop to get the latest game changes
                Update();
                
                // 2. Render
                // Present also in DirectX 11 App template: Prepare to render
                m_renderer->Render();
                
                // 3. Present
                // Present also in DirectX 11 App template: Present the 
                // contents of the swap chain to the screen.
                m_deviceResources->Present(); 
                
                // Added: resetting a variable we've added to indicate that 
                // render has been done and no longer needed to render
                m_renderNeeded = false; 
            }
        }
        else
        {   
            // Present also in DirectX 11 App template
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending); 
        }
    }
    m_game->OnSuspending();  // exiting due to window close. Make sure to save state.
}
```

### <a name="update"></a><span data-ttu-id="461d0-144">Update</span><span class="sxs-lookup"><span data-stu-id="461d0-144">Update</span></span>

<span data-ttu-id="461d0-145">[__App::Update__ および __GameMain::Update__](tutorial-game-flow-management.md#appupdate-method) メソッドで、ゲームの状態がどのように更新される化については、「[ゲームのフロー管理](tutorial-game-flow-management.md)」の記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-145">See the [Game flow management](tutorial-game-flow-management.md) article for more information about how game states are updated in the [__App::Update__ and __GameMain::Update__](tutorial-game-flow-management.md#appupdate-method) method.</span></span>

### <a name="render"></a><span data-ttu-id="461d0-146">Render</span><span class="sxs-lookup"><span data-stu-id="461d0-146">Render</span></span>

<span data-ttu-id="461d0-147">レンダリングは、__GameMain::Run__ で [__GameRenderer::Render__](#gamerendererrender-method) メソッドを呼び出すことによって実装されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-147">Rendering is implemented by calling the [__GameRenderer::Render__](#gamerendererrender-method) method in __GameMain::Run__.</span></span>

<span data-ttu-id="461d0-148">[ステレオ レンダリング](#stereo-rendering) が有効な場合、右目用と左目用の 2 つのレンダリング パスがあります。</span><span class="sxs-lookup"><span data-stu-id="461d0-148">If [stereo rendering](#stereo-rendering) is enabled, there are two rendering passes: one for the right eye and one for the left eye.</span></span> <span data-ttu-id="461d0-149">各レンダリング パスで、レンダー ターゲットと[深度ステンシル ビュー](#depth-stencil-view)をデバイスにバインドします。</span><span class="sxs-lookup"><span data-stu-id="461d0-149">In each rendering pass, we bind the render target and the [depth-stencil view](#depth-stencil-view) to the device.</span></span> <span data-ttu-id="461d0-150">後で深度ステンシル ビューをクリアします。</span><span class="sxs-lookup"><span data-stu-id="461d0-150">We also clear the depth-stencil view afterward.</span></span>

> [!Note]
> <span data-ttu-id="461d0-151">ステレオ レンダリングは、頂点のインスタンス化やジオメトリ シェーダーを使用する単一パス ステレオなど、他の方法で実現することもできます。</span><span class="sxs-lookup"><span data-stu-id="461d0-151">Stereo rendering can be achieved using other methods such as single pass stereo using vertex instancing or geometry shaders.</span></span> <span data-ttu-id="461d0-152">2 つのレンダリング パスを使用する方法は時間がかかりますが、ステレオ レンダリングを実現するのに便利な方法です。</span><span class="sxs-lookup"><span data-stu-id="461d0-152">The two rendering pass method is a slower, but more convenient way to achieve stereo rendering.</span></span>

<span data-ttu-id="461d0-153">ゲームが作成され、リソースが読み込まれたら、レンダリング パスごとに 1 回、[射影行列](#projection-transform-matrix)を更新します。</span><span class="sxs-lookup"><span data-stu-id="461d0-153">Once the game exists and resources are loaded, update the [projection matrix](#projection-transform-matrix), once per rendering pass.</span></span> <span data-ttu-id="461d0-154">オブジェクトは、各ビューで若干異なります。</span><span class="sxs-lookup"><span data-stu-id="461d0-154">Objects are slightly different from each view.</span></span> <span data-ttu-id="461d0-155">次に、[グラフィックス レンダリング パイプライン](#rendering-pipeline)を設定します。</span><span class="sxs-lookup"><span data-stu-id="461d0-155">Next, set up the [graphics rendering pipeline](#rendering-pipeline).</span></span> 

> [!Note]
> <span data-ttu-id="461d0-156">リソースを読み込む方法については、「[DirectX グラフィックス リソースの作成と読み込み](tutorial-game-rendering.md#create-and-load-directx-graphic-resources)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-156">See [Create and load DirectX graphic resources](tutorial-game-rendering.md#create-and-load-directx-graphic-resources) for more information on how resources are loaded.</span></span>

<span data-ttu-id="461d0-157">このゲーム サンプルでは、レンダラーは、すべてのオブジェクトについて標準の頂点レイアウトを使用するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="461d0-157">In this game sample, the renderer is designed to use a standard vertex layout across all objects.</span></span> <span data-ttu-id="461d0-158">これにより、シェーダーの設計が簡素化され、オブジェクトのジオメトリに関係なく、シェーダー間で簡単に切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="461d0-158">This simplifies the shader design and allows for easy changes between shaders, independent of the objects' geometry.</span></span>

#### <a name="gamerendererrender-method"></a><span data-ttu-id="461d0-159">GameRenderer::Render メソッド</span><span class="sxs-lookup"><span data-stu-id="461d0-159">GameRenderer::Render method</span></span>

<span data-ttu-id="461d0-160">入力頂点レイアウトを使用する Direct3D コンテキストを設定します。</span><span class="sxs-lookup"><span data-stu-id="461d0-160">Set the Direct3D context to use an input vertex layout.</span></span> <span data-ttu-id="461d0-161">入力レイアウト オブジェクトは、頂点バッファー データを[レンダリング パイプライン](#rendering-pipeline)にストリーミングする方法を記述します。</span><span class="sxs-lookup"><span data-stu-id="461d0-161">Input-layout objects describe how vertex buffer data is streamed into the [rendering pipeline](#rendering-pipeline).</span></span> 

<span data-ttu-id="461d0-162">次に、以前に定義した[定数バッファー](#constant-buffers)を使用する Direct3D コンテキストを設定します。この定数バッファーは、[頂点シェーダー](#vertex-shaders-and-pixel-shaders)のパイプライン ステージと[ピクセル シェーダー](#vertex-shaders-and-pixel-shaders)のパイプライン ステージで使用されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-162">Next, we set the Direct3D context to use the [constant buffers](#constant-buffers) defined earlier, that are used by the [vertex shader](#vertex-shaders-and-pixel-shaders) pipeline stage and the [pixel shader](#vertex-shaders-and-pixel-shaders) pipeline stage.</span></span> 

> [!Note]
> <span data-ttu-id="461d0-163">定数バッファーの定義の詳細については、「[レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-163">See [Rendering framework II: Game rendering](tutorial-game-rendering.md) for more information about definition of the constant buffers.</span></span>

<span data-ttu-id="461d0-164">同じ入力レイアウトと一連の定数バッファーが、パイプライン内のすべてのシェーダーで使用されるため、設定はフレームごとに 1 回です。</span><span class="sxs-lookup"><span data-stu-id="461d0-164">Because the same input layout and set of constant buffers is used for all shaders that are in the pipeline, it's set up once per frame.</span></span>

```cpp
void GameRenderer::Render()
{
    bool stereoEnabled = m_deviceResources->GetStereoState();

    auto d3dContext = m_deviceResources->GetD3DDeviceContext();
    auto d2dContext = m_deviceResources->GetD2DDeviceContext();

    int renderingPasses = 1;
    if (stereoEnabled)
    {
        renderingPasses = 2;
    }

    for (int i = 0; i < renderingPasses; i++)
    {
        // Iterate through the number of rendering passes to be completed.
        // 2 rendering passes if stereo is enabled
        if (i > 0)
        {
            // Doing the Right Eye View.
            ID3D11RenderTargetView *const targets[1] = { m_deviceResources->GetBackBufferRenderTargetViewRight() };

            // Resets render targets to the screen.
            // OMSetRenderTargets binds 2 things to the device.
            // 1. Binds one render target atomically to the device.
            // 2. Binds the depth-stencil view, as returned by the GetDepthStencilView method, to the device.
            // For more info, go to: https://msdn.microsoft.com/library/windows/desktop/ff476464.aspx

            d3dContext->OMSetRenderTargets(1, targets, m_deviceResources->GetDepthStencilView());
            
            // Clears the depth stencil view.
            // A depth stencil view contains the format and buffer to hold depth and stencil info.
            // For more info about depth stencil view, go to: 
            // https://docs.microsoft.com/windows/uwp/graphics-concepts/depth-stencil-view--dsv-
            // A depth buffer is used to store depth information to control which areas of 
            // polygons are rendered rather than hidden from view. To learn more about a depth buffer,
            // go to: https://docs.microsoft.com/windows/uwp/graphics-concepts/depth-buffers
            // A stencil buffer is used to mask pixels in an image, to produce special effects. 
            // The mask determines whether a pixel is drawn or not,
            // by setting the bit to a 1 or 0. To learn more about a stencil buffer,
            // go to: https://docs.microsoft.com/windows/uwp/graphics-concepts/stencil-buffers

            d3dContext->ClearDepthStencilView(m_deviceResources->GetDepthStencilView(), D3D11_CLEAR_DEPTH, 1.0f, 0);
            
            // d2d -- Discussed later
            d2dContext->SetTarget(m_deviceResources->GetD2DTargetBitmapRight());
        }
        else
        {
            // Doing the Mono or Left Eye View.
            // As compared to the right eye:
            // m_deviceResources->GetBackBufferRenderTargetView instead of GetBackBufferRenderTargetViewRight
            ID3D11RenderTargetView *const targets[1] = { m_deviceResources->GetBackBufferRenderTargetView() }; 
            
            // Same as the Right Eye View.
            d3dContext->OMSetRenderTargets(1, targets, m_deviceResources->GetDepthStencilView());
            d3dContext->ClearDepthStencilView(m_deviceResources->GetDepthStencilView(), D3D11_CLEAR_DEPTH, 1.0f, 0);
            
            // d2d -- Discussed later under Adding UI
            d2dContext->SetTarget(m_deviceResources->GetD2DTargetBitmap()); 
        }

        // Render the scene objects
        if (m_game != nullptr && m_gameResourcesLoaded && m_levelResourcesLoaded)
        {
            // This section is only used after the game state has been initialized and all device
            // resources needed for the game have been created and associated with the game objects.
            if (stereoEnabled)
            {
                // When doing stereo, it is necessary to update the projection matrix once per rendering pass.

                auto orientation = m_deviceResources->GetOrientationTransform3D();

                ConstantBufferChangeOnResize changesOnResize;

                // Apply either a left or right eye projection, which is an offset from the middle
                XMStoreFloat4x4(
                    &changesOnResize.projection,
                    XMMatrixMultiply(
                        XMMatrixTranspose(
                            i == 0 ?
                            m_game->GameCamera()->LeftEyeProjection() :
                            m_game->GameCamera()->RightEyeProjection()
                            ),
                        XMMatrixTranspose(XMLoadFloat4x4(&orientation))
                        )
                    );

                d3dContext->UpdateSubresource(
                    m_constantBufferChangeOnResize.Get(),
                    0,
                    nullptr,
                    &changesOnResize,
                    0,
                    0
                    );
            }

            // Update variables that change once per frame.
            ConstantBufferChangesEveryFrame constantBufferChangesEveryFrame;
            XMStoreFloat4x4(
                &constantBufferChangesEveryFrame.view,
                XMMatrixTranspose(m_game->GameCamera()->View())
                );
            d3dContext->UpdateSubresource(
                m_constantBufferChangesEveryFrame.Get(),
                0,
                nullptr,
                &constantBufferChangesEveryFrame,
                0,
                0
                );

            // Setup the graphics pipeline. This sample uses the same InputLayout and set of
            // constant buffers for all shaders, so they only need to be set once per frame.
            // For more info about the graphics or rendering pipeline, 
            // go to https://msdn.microsoft.com/library/windows/desktop/ff476882.aspx

            // IASetInputLayout binds an input-layout object to the input-assembler (IA) stage. 
            // Input-layout objects describe how vertex buffer data is streamed into the IA pipeline stage.
            // Set up the Direct3D context to use this vertex layout.
            // For more info, go to: https://msdn.microsoft.com/library/windows/desktop/ff476454.aspx
            d3dContext->IASetInputLayout(m_vertexLayout.Get());

            // VSSetConstantBuffers sets the constant buffers used by the vertex shader pipeline stage.
            // Set up the Direct3D context to use these constant buffers.
            // For more info, go to: https://msdn.microsoft.com/library/windows/desktop/ff476491.aspx

            d3dContext->VSSetConstantBuffers(0, 1, m_constantBufferNeverChanges.GetAddressOf());
            d3dContext->VSSetConstantBuffers(1, 1, m_constantBufferChangeOnResize.GetAddressOf());
            d3dContext->VSSetConstantBuffers(2, 1, m_constantBufferChangesEveryFrame.GetAddressOf());
            d3dContext->VSSetConstantBuffers(3, 1, m_constantBufferChangesEveryPrim.GetAddressOf());

            // Sets the constant buffers used by the pixel shader pipeline stage. 
            // For more info, go to: https://msdn.microsoft.com/library/windows/desktop/ff476470.aspx

            d3dContext->PSSetConstantBuffers(2, 1, m_constantBufferChangesEveryFrame.GetAddressOf());
            d3dContext->PSSetConstantBuffers(3, 1, m_constantBufferChangesEveryPrim.GetAddressOf());
            d3dContext->PSSetSamplers(0, 1, m_samplerLinear.GetAddressOf());

            auto objects = m_game->RenderObjects();
            for (auto object = objects.begin(); object != objects.end(); object++)
            {
                // The 3D object render method handles the rendering.
                // For more info, see Primitive rendering below.
                (*object)->Render(d3dContext, m_constantBufferChangesEveryPrim.Get()); /
            }
        }
        else
        {
            const float ClearColor[4] = {0.5f, 0.5f, 0.8f, 1.0f};

            // Only need to clear the background when not rendering the full 3D scene since
            // the 3D world is a fully enclosed box and the dynamics prevents the camera from
            // moving outside this space.
            if (i > 0)
            {
                // Doing the Right Eye View.
                d3dContext->ClearRenderTargetView(m_deviceResources->GetBackBufferRenderTargetViewRight(), ClearColor);
            }
            else
            {
                // Doing the Mono or Left Eye View.
                d3dContext->ClearRenderTargetView(m_deviceResources->GetBackBufferRenderTargetView(), ClearColor);
            }
        }

        // Start of 2D rendering
        d3dContext->BeginEventInt(L"D2D BeginDraw", 1);
        d2dContext->BeginDraw();

        // ...
    }
}
```

### <a name="primitive-rendering"></a><span data-ttu-id="461d0-165">プリミティブのレンダリング</span><span class="sxs-lookup"><span data-stu-id="461d0-165">Primitive rendering</span></span>

<span data-ttu-id="461d0-166">シーンをレンダリングする場合は、レンダリングする必要があるすべてのオブジェクトをループ処理します。</span><span class="sxs-lookup"><span data-stu-id="461d0-166">When rendering the scene, you loop through all the objects that need to be rendered.</span></span> <span data-ttu-id="461d0-167">次の手順は、オブジェクト (プリミティブ) ごとに繰り返されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-167">The steps below are repeated for each object (primitive).</span></span>

* <span data-ttu-id="461d0-168">モデルの[ワールド変換行列](#world-transform-matrix)とマテリアルの情報を使用して定数バッファー (__m\_constantBufferChangesEveryPrim__) を更新します。</span><span class="sxs-lookup"><span data-stu-id="461d0-168">Update the constant buffer(__m\_constantBufferChangesEveryPrim__) with the model's [world transformation matrix](#world-transform-matrix) and material information.</span></span>
* <span data-ttu-id="461d0-169">__m\_constantBufferChangesEveryPrim__ には、各オブジェクトのパラメーターが格納されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-169">The  __m\_constantBufferChangesEveryPrim__ contains parameters for each object.</span></span>  <span data-ttu-id="461d0-170">ワールド変換行列に渡されるオブジェクトや、照明の計算の色と鏡面反射指数などのマテリアルのプロパティが含まれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-170">It includes the object to world transformation matrix as well as material properties like color and specular exponent for lighting calculations.</span></span>
* <span data-ttu-id="461d0-171">[レンダリング パイプライン](#rendering-pipeline)の入力アセンブラー (IA) ステージにストリーミングされるメッシュ オブジェクトのデータ用に入力頂点レイアウトを使用する Direct3D コンテキストを設定します。</span><span class="sxs-lookup"><span data-stu-id="461d0-171">Set Direct3D context to use the input vertex layout for the mesh object data to be streamed into the input-assembler (IA) stage of the [rendering pipeline](#rendering-pipeline)</span></span>
* <span data-ttu-id="461d0-172">IA ステージで[インデックス バッファー](#index-buffer)を使用する Direct3D コンテキストを設定します。</span><span class="sxs-lookup"><span data-stu-id="461d0-172">Set Direct3D context to use an [index buffer](#index-buffer) in the IA stage.</span></span> <span data-ttu-id="461d0-173">プリミティブの情報 (型、データの順序) を提供します。</span><span class="sxs-lookup"><span data-stu-id="461d0-173">Provide the primitive info: type, data order.</span></span>
* <span data-ttu-id="461d0-174">インデックス付きの、インスタンス化されていないプリミティブを描画する描画呼び出しを送信します。</span><span class="sxs-lookup"><span data-stu-id="461d0-174">Submit a draw call to draw the indexed, non-instanced primitive.</span></span> <span data-ttu-id="461d0-175">__GameObject::Render__ メソッドは、特定のプリミティブに固有のデータでプリミティブ[定数バッファー](#constant-buffer-or-shader-constant-buffer)を更新します。</span><span class="sxs-lookup"><span data-stu-id="461d0-175">The __GameObject::Render__ method updates the primitive [constant buffer](#constant-buffer-or-shader-constant-buffer) with the data specific to a given primitive.</span></span> <span data-ttu-id="461d0-176">これにより、各プリミティブのジオメトリを描画するコンテキストで __DrawIndexed__ 呼び出しが行われます。</span><span class="sxs-lookup"><span data-stu-id="461d0-176">This results in a __DrawIndexed__ call on the context to draw the geometry of that each primitive.</span></span> <span data-ttu-id="461d0-177">特に、この描画呼び出しは、定数バッファー データによってパラメーター化されたとおり、コマンドとデータをグラフィックス処理装置 (GPU) のキューに入れます。</span><span class="sxs-lookup"><span data-stu-id="461d0-177">Specifically, this draw call queues commands and data to the graphics processing unit (GPU), as parameterized by the constant buffer data.</span></span> <span data-ttu-id="461d0-178">各描画呼び出しは、頂点ごとに 1 回[頂点シェーダー](#vertex-shaders-and-pixel-shaders)を実行し、次にプリミティブの各三角形のピクセルごとに 1 回[ピクセル シェーダー](#vertex-shaders-and-pixel-shaders)を実行します。</span><span class="sxs-lookup"><span data-stu-id="461d0-178">Each draw call executes the [vertex shader](#vertex-shaders-and-pixel-shaders) one time per vertex, and then the [pixel shader](#vertex-shaders-and-pixel-shaders) one time for every pixel of each triangle in the primitive.</span></span> <span data-ttu-id="461d0-179">テクスチャは、ピクセル シェーダーがレンダリングの実行に使う状態の一部です。</span><span class="sxs-lookup"><span data-stu-id="461d0-179">The textures are part of the state that the pixel shader uses to do the rendering.</span></span>

<span data-ttu-id="461d0-180">複数の定数バッファーを使用する理由は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="461d0-180">Reasons for multiple constant buffers:</span></span>
    * <span data-ttu-id="461d0-181">ゲームでは複数の定数バッファーが使われますが、これらのバッファーはプリミティブごとに 1 回更新するだけで済みます。</span><span class="sxs-lookup"><span data-stu-id="461d0-181">The game uses multiple constant buffers but only needs to update these buffers one time per primitive.</span></span> <span data-ttu-id="461d0-182">前述のように、定数バッファーは、プリミティブごとに実行されるシェーダーに対する入力のようなものです。</span><span class="sxs-lookup"><span data-stu-id="461d0-182">As mentioned earlier, constant buffers are like inputs to the shaders that run for each primitive.</span></span> <span data-ttu-id="461d0-183">静的なデータ (__m\_constantBufferNeverChanges__) もあれば、カメラの位置のようにフレームで一定のデータ (__m\_constantBufferChangesEveryFrame__) もあれば、色やテクスチャなどのようにプリミティブに固有のデータ (__m\_constantBufferChangesEveryPrim__) もあります。</span><span class="sxs-lookup"><span data-stu-id="461d0-183">Some data is static (__m\_constantBufferNeverChanges__); some data is constant over the frame (__m\_constantBufferChangesEveryFrame__), like the position of the camera; and some data is specific to the primitive, like its color and textures (__m\_constantBufferChangesEveryPrim__)</span></span>
    * <span data-ttu-id="461d0-184">ゲーム [レンダラー](#renderer)はこれらの入力を別個の定数バッファーに分けて、CPU や GPU が使うメモリ帯域幅を最適化します。</span><span class="sxs-lookup"><span data-stu-id="461d0-184">The game [renderer](#renderer) separates these inputs into different constant buffers to optimize the memory bandwidth that the CPU and GPU use.</span></span> <span data-ttu-id="461d0-185">この方法は、GPU が追跡する必要のあるデータ量を最小限に抑えるのにも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="461d0-185">This approach also helps to minimize the amount of data the GPU needs to keep track of.</span></span> <span data-ttu-id="461d0-186">GPU にはコマンドの大きいキューがあり、ゲームが __Draw__ を呼び出すたびに、そのコマンドは関連するデータと共にキューに入れられます。</span><span class="sxs-lookup"><span data-stu-id="461d0-186">The GPU has a big queue of commands, and each time the game calls __Draw__, that command is queued along with the data associated with it.</span></span> <span data-ttu-id="461d0-187">ゲームがプリミティブ定数バッファーを更新して、次の __Draw__ コマンドを発行すると、グラフィックス ドライバーはこの次のコマンドと関連するデータをキューに追加します。</span><span class="sxs-lookup"><span data-stu-id="461d0-187">When the game updates the primitive constant buffer and issues the next __Draw__ command, the graphics driver adds this next command and the associated data to the queue.</span></span> <span data-ttu-id="461d0-188">ゲームで 100 のプリミティブを描画する場合、キューに定数バッファー データの 100 のコピーが存在する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-188">If the game draws 100 primitives, it could potentially have 100 copies of the constant buffer data in the queue.</span></span> <span data-ttu-id="461d0-189">ゲームから GPU に送るデータ量を最小限に抑えるために、ゲームでは、各プリミティブの更新情報のみを含む個別のプリミティブ定数バッファーを使用します。</span><span class="sxs-lookup"><span data-stu-id="461d0-189">To minimize the amount of data the game is sending to the GPU, the game uses a separate primitive constant buffer that only contains the updates for each primitive.</span></span>

#### <a name="gameobjectrender-method"></a><span data-ttu-id="461d0-190">GameObject::Render メソッド</span><span class="sxs-lookup"><span data-stu-id="461d0-190">GameObject::Render method</span></span>

```cpp
void GameObject::Render(
    _In_ ID3D11DeviceContext *context,
    _In_ ID3D11Buffer *primitiveConstantBuffer
    )
{
    if (!m\_active || (m\_mesh == nullptr) || (m_normalMaterial == nullptr))
    {
        return;
    }

    ConstantBufferChangesEveryPrim constantBuffer;

    // Put the model matrix info into a constant buffer, in world matrix.
    XMStoreFloat4x4(
        &constantBuffer.worldMatrix,
        XMMatrixTranspose(ModelMatrix())
        );

    // Check to see which material to use on the object.
    // If a collision (a hit) is detected, GameObject::Render checks the current context, which 
    // indicates whether the target has been hit by an ammo sphere. If the target has been hit, 
    // this method applies a hit material, which reverses the colors of the rings of the target to 
    // indicate a successful hit to the player. Otherwise, it applies the default material 
    // with the same method. In both cases, it sets the material by calling Material::RenderSetup, 
    // which sets the appropriate constants into the constant buffer. Then, it calls 
    // ID3D11DeviceContext::PSSetShaderResources to set the corresponding texture resource for the 
    // pixel shader, and ID3D11DeviceContext::VSSetShader and ID3D11DeviceContext::PSSetShader 
    // to set the vertex shader and pixel shader objects themselves, respectively.

    if (m_hit && m_hitMaterial != nullptr)
    {
        m_hitMaterial->RenderSetup(context, &constantBuffer);
    }
    else
    {
        m_normalMaterial->RenderSetup(context, &constantBuffer);
    }

    // Update the primitive constant buffer with the object model's info.
    context->UpdateSubresource(primitiveConstantBuffer, 0, nullptr, &constantBuffer, 0, 0);

    // Render the mesh.
    // See MeshObject::Render method below.
    m_mesh->Render(context);
}

#### MeshObject::Render method

void MeshObject::Render(\_In\_ ID3D11DeviceContext *context)
{
    // PNTVertex is a struct. stride provides us the size required for all the mesh data
    // struct PNTVertex
    //{
    //  DirectX::XMFLOAT3 position;
    //  DirectX::XMFLOAT3 normal;
    //  DirectX::XMFLOAT2 textureCoordinate;
    //};
    uint32 stride = sizeof(PNTVertex);
    uint32 offset = 0;

    // Similar to the main render loop.
    // Input-layout objects describe how vertex buffer data is streamed into the IA pipeline stage.
    context->IASetVertexBuffers(0, 1, m_vertexBuffer.GetAddressOf(), &stride, &offset);

    // IASetIndexBuffer binds an index buffer to the input-assembler stage.
    // For more info, go to: https://msdn.microsoft.com/library/windows/desktop/ff476453.aspx
    context->IASetIndexBuffer(m_indexBuffer.Get(), DXGI_FORMAT_R16_UINT, 0);

    // Binds information about the primitive type, and data order that describes input data for the input assembler stage.
    // For more info, go to: https://msdn.microsoft.com/library/windows/desktop/ff476455.aspx
    context->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

    // Draw indexed, non-instanced primitives. A draw API submits work to the rendering pipeline.
    // For more info, go to: https://msdn.microsoft.com/library/windows/desktop/ff476409.aspx
    context->DrawIndexed(m_indexCount, 0, 0);
}
```

### <a name="present"></a><span data-ttu-id="461d0-191">Present</span><span class="sxs-lookup"><span data-stu-id="461d0-191">Present</span></span>

<span data-ttu-id="461d0-192">__DX::DeviceResources::Present__ メソッドを呼び出して、配置した内容をバッファーに格納し、表示します。</span><span class="sxs-lookup"><span data-stu-id="461d0-192">We call the __DX::DeviceResources::Present__ method to put the contents we've placed in the buffers and display it.</span></span>

<span data-ttu-id="461d0-193">ユーザーにフレームを表示するために使用されるバッファーのコレクションという意味で、スワップ チェーンという用語を使用します。</span><span class="sxs-lookup"><span data-stu-id="461d0-193">We use the term swap chain for a collection of buffers that are used for displaying frames to the user.</span></span> <span data-ttu-id="461d0-194">アプリケーションが表示する新しいフレームを提供するたびに、スワップ チェーンの最初のバッファーが、表示されているバッファーの場所を取得します。</span><span class="sxs-lookup"><span data-stu-id="461d0-194">Each time an application presents a new frame for display, the first buffer in the swap chain takes the place of the displayed buffer.</span></span> <span data-ttu-id="461d0-195">このプロセスは、スワップまたはフリップと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-195">This process is called swapping or flipping.</span></span> <span data-ttu-id="461d0-196">詳しくは、「[スワップ チェーン](../graphics-concepts/swap-chains.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461d0-196">For more information, see [Swap chains](../graphics-concepts/swap-chains.md).</span></span>

* <span data-ttu-id="461d0-197">__IDXGISwapChain1__ インターフェイスの __Present__ メソッドは、[DXGI](#dxgi) に対して垂直同期 (VSync) までブロックするよう指示し、アプリケーションを次の VSync までスリープ状態にします。</span><span class="sxs-lookup"><span data-stu-id="461d0-197">__IDXGISwapChain1__ interface's __Present__ method the instructs [DXGI](#dxgi) to block until Vertical Synchronization (VSync), putting the application to sleep until the next VSync.</span></span> <span data-ttu-id="461d0-198">これによって、画面に表示されないフレームのレンダリングによるサイクルの無駄をなくします。</span><span class="sxs-lookup"><span data-stu-id="461d0-198">This ensures you don't waste any cycles rendering frames that will never be displayed to the screen.</span></span>
* <span data-ttu-id="461d0-199">__ID3D11DeviceContext3__ インターフェイスの __DiscardView__ メソッドは、[レンダー ターゲット](#render-target)の内容を破棄します。</span><span class="sxs-lookup"><span data-stu-id="461d0-199">__ID3D11DeviceContext3__ interface's __DiscardView__ method discards the contents of the [render target](#render-target).</span></span> <span data-ttu-id="461d0-200">これは、既存の内容が完全に上書きされる場合にのみ有効な操作です。</span><span class="sxs-lookup"><span data-stu-id="461d0-200">This is a valid operation only when the existing contents will be entirely overwritten.</span></span> <span data-ttu-id="461d0-201">dirty rect や scroll rect を使用する場合は、この呼び出しを削除してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-201">If dirty or scroll rects are used, this call should be removed.</span></span>
* <span data-ttu-id="461d0-202">同じ __DiscardView__ メソッドを使用して、[深度/ステンシル](#depth-stencil)の内容を破棄します。</span><span class="sxs-lookup"><span data-stu-id="461d0-202">Using the same __DiscardView__ method, discard the contents of the [depth-stencil](#depth-stencil).</span></span>
* <span data-ttu-id="461d0-203">[デバイス](#device)が削除される場合は、__HandleDeviceLost__ メソッドを使用してシナリオを管理します。</span><span class="sxs-lookup"><span data-stu-id="461d0-203">__HandleDeviceLost__ method is used to manage the scenario if the [device](#device) is removed.</span></span> <span data-ttu-id="461d0-204">切断またはドライバーのアップグレードによってデバイスが削除された場合は、すべてのデバイス リソースを作成し直す必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-204">If the device was removed either by a disconnection or a driver upgrade, you must recreate all device resources.</span></span> <span data-ttu-id="461d0-205">詳細については、「[Direct3D 11 でのデバイス削除シナリオの処理](handling-device-lost-scenarios.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-205">For more information, see [Handle device removed scenarios in Direct3D 11](handling-device-lost-scenarios.md).</span></span>

> [!Tip]
> <span data-ttu-id="461d0-206">滑らかなフレーム レートを実現するには、フレームのレンダリングの作業量が、VSync 間の時間に収まることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-206">To achieve a smooth frame rate, you must ensure that the amount of work to render a frame fits the time between VSyncs.</span></span>

```cpp
// Present the contents of the swap chain to the screen.
void DX::DeviceResources::Present()
{
    // The first argument instructs DXGI to block until VSync, putting the application
    // to sleep until the next VSync. This ensures we don't waste any cycles rendering
    // frames that will never be displayed to the screen.
    HRESULT hr = m_swapChain->Present(1, 0);

    // Discard the contents of the render target.
    // This is a valid operation only when the existing contents will be entirely
    // overwritten. If dirty or scroll rects are used, this call should be removed.
    m_d3dContext->DiscardView(m_d3dRenderTargetView.Get());

    // Discard the contents of the depth-stencil.
    m_d3dContext->DiscardView(m_d3dDepthStencilView.Get());

    // If the device was removed either by a disconnection or a driver upgrade, we 
    // must recreate all device resources.
    // For more info about how to handle a device lost scenario, go to:
    // https://docs.microsoft.com/windows/uwp/gaming/handling-device-lost-scenarios
    if (hr == DXGI_ERROR_DEVICE_REMOVED || hr == DXGI_ERROR_DEVICE_RESET)
    {
        HandleDeviceLost();
    }
    else
    {
        DX::ThrowIfFailed(hr);
    }
}
```

## <a name="next-steps"></a><span data-ttu-id="461d0-207">次の手順</span><span class="sxs-lookup"><span data-stu-id="461d0-207">Next steps</span></span>

<span data-ttu-id="461d0-208">この記事では、ディスプレイにグラフィックスをレンダリングする方法を説明し、使用されるレンダリング用語の一部について簡単に説明しました。</span><span class="sxs-lookup"><span data-stu-id="461d0-208">This article explained how graphics is rendered on the display and provided a short description for some of the rendering terms used.</span></span> <span data-ttu-id="461d0-209">「[レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)」では、レンダリングの詳細や、レンダリングする前に必要なデータを準備する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="461d0-209">Learn more about rendering in the [Rendering framework II: Game rendering](tutorial-game-rendering.md) article, and learn how to prepare the data needed before rendering.</span></span>

## <a name="terms-and-concepts"></a><span data-ttu-id="461d0-210">用語と概念</span><span class="sxs-lookup"><span data-stu-id="461d0-210">Terms and concepts</span></span>

### <a name="simple-game-scene"></a><span data-ttu-id="461d0-211">シンプルなゲームのシーン</span><span class="sxs-lookup"><span data-stu-id="461d0-211">Simple game scene</span></span>

<span data-ttu-id="461d0-212">シンプルなゲームのシーンは、数個のオブジェクトといくつかの光源で構成されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-212">A simple game scene is made up of a few objects with several light sources.</span></span>

<span data-ttu-id="461d0-213">オブジェクトのシェイプは、空間の一連の X、Y、Z 座標で定義されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-213">An object's shape is defined by a set of X, Y, Z coordinates in space.</span></span> <span data-ttu-id="461d0-214">ゲーム ワールド内の実際のレンダリングの位置は、位置の X、Y、Z 座標に変換行列を適用することで決定できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-214">The actual render location in the game world can be determined by applying a transformation matrix to the positional X, Y, Z coordinates.</span></span> <span data-ttu-id="461d0-215">一連のテクスチャ座標 (マテリアルをオブジェクトに適用する方法を指定する U と V) が含まれる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="461d0-215">It may also have a set of texture coordinates - U and V which specifies how a material is applied to the object.</span></span> <span data-ttu-id="461d0-216">これはオブジェクトのサーフェスのプロパティを定義し、これを使ってオブジェクトがテニス ボールのような粗いサーフェスを持つのか、ボーリングの球のように滑らかな光沢のあるサーフェスを持つのかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-216">This defines the surface properties of the object and gives you the ability to see if an object has a rough surface like a tennis ball or a smooth glossy surface like a bowling ball.</span></span>

<span data-ttu-id="461d0-217">シーンとオブジェクトの情報は、レンダリング フレームワークでフレームごとにシーンを再作成し、シーンをディスプレイ モニターに表示するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-217">Scene and object info are used by the rendering framework to recreate the scene frame by frame, making it come alive on your display monitor.</span></span>

### <a name="rendering-pipeline"></a><span data-ttu-id="461d0-218">レンダリング パイプライン</span><span class="sxs-lookup"><span data-stu-id="461d0-218">Rendering pipeline</span></span>

<span data-ttu-id="461d0-219">レンダリング パイプラインは、3D シーンの情報が画面に表示される画像に変換されるプロセスです。</span><span class="sxs-lookup"><span data-stu-id="461d0-219">The rendering pipeline is the process in which 3D scene info is translated to an image displayed on screen.</span></span> <span data-ttu-id="461d0-220">Direct3D 11 では、このパイプラインはプログラミング可能です。</span><span class="sxs-lookup"><span data-stu-id="461d0-220">In Direct3D 11, this pipeline is programmable.</span></span> <span data-ttu-id="461d0-221">レンダリングのニーズをサポートするために、ステージを適合させることができます。</span><span class="sxs-lookup"><span data-stu-id="461d0-221">You can adapt the stages to support your rendering needs.</span></span> <span data-ttu-id="461d0-222">一般的なシェーダー コアの機能を利用するステージは、HLSL プログラミング言語を使用することによってプログラミングできます。</span><span class="sxs-lookup"><span data-stu-id="461d0-222">Stages that feature common shader cores are programmable by using the HLSL programming language.</span></span> <span data-ttu-id="461d0-223">これは、グラフィックス レンダリング パイプラインまたは単にパイプラインとも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-223">It is also known as the graphics rendering pipeline or simply pipeline.</span></span>

<span data-ttu-id="461d0-224">このパイプラインを作成するには、以下についての知識が必要です。</span><span class="sxs-lookup"><span data-stu-id="461d0-224">To help you create this pipeline, you need to be familiar with:</span></span>
* <span data-ttu-id="461d0-225">[HLSL](#HLSL)。</span><span class="sxs-lookup"><span data-stu-id="461d0-225">[HLSL](#HLSL).</span></span> <span data-ttu-id="461d0-226">UWP DirectX ゲームでは、HLSL シェーダー モデル 5.1 以上を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="461d0-226">We recommend the use of HLSL Shader Model 5.1 and above for UWP DirectX games.</span></span>
* [<span data-ttu-id="461d0-227">シェーダー</span><span class="sxs-lookup"><span data-stu-id="461d0-227">Shaders</span></span>](#Shaders)
* [<span data-ttu-id="461d0-228">頂点シェーダーとピクセル シェーダー</span><span class="sxs-lookup"><span data-stu-id="461d0-228">Vertex shaders and pixel shaders</span></span>](#vertext-shaders-pixel-shaders)
* [<span data-ttu-id="461d0-229">シェーダー ステージ</span><span class="sxs-lookup"><span data-stu-id="461d0-229">Shader stages</span></span>](#shader-stages)
* [<span data-ttu-id="461d0-230">さまざまなシェーダー ファイル形式</span><span class="sxs-lookup"><span data-stu-id="461d0-230">Various shader file formats</span></span>](#various-shader-file-formats)

<span data-ttu-id="461d0-231">詳細については、[Direct3D 11 のレンダリング パイプラインに関するページ](https://msdn.microsoft.com/library/windows/desktop/dn643746.aspx)と[グラフィックス パイプラインに関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476882.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-231">For more information, see [Understand the Direct3D 11 rendering pipeline](https://msdn.microsoft.com/library/windows/desktop/dn643746.aspx) and [Graphics pipeline](https://msdn.microsoft.com/library/windows/desktop/ff476882.aspx).</span></span>

#### <a name="hlsl"></a><span data-ttu-id="461d0-232">HLSL</span><span class="sxs-lookup"><span data-stu-id="461d0-232">HLSL</span></span>

<span data-ttu-id="461d0-233">HLSL は、DirectX 用の上位レベル シェーダー言語です。</span><span class="sxs-lookup"><span data-stu-id="461d0-233">HLSL is the High Level Shading Language for DirectX.</span></span> <span data-ttu-id="461d0-234">HLSL を使用して、Direct3D パイプライン用の C に似たプログラミング可能なシェーダーを作成できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-234">Using HLSL, you can create C like programmable shaders for the Direct3D pipeline.</span></span> <span data-ttu-id="461d0-235">詳しくは、「[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461d0-235">For more information, see [HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561.aspx).</span></span>

#### <a name="shaders"></a><span data-ttu-id="461d0-236">シェーダー</span><span class="sxs-lookup"><span data-stu-id="461d0-236">Shaders</span></span>

<span data-ttu-id="461d0-237">シェーダーは、レンダリングするときのオブジェクトのサーフェスの表示方法を決定する命令のセットと考えることができます。</span><span class="sxs-lookup"><span data-stu-id="461d0-237">Shaders can be thought of as a set of instructions that determine how the surface of an object appears when rendered.</span></span> <span data-ttu-id="461d0-238">HLSL を使用してプログラミングされるシェーダーは、HLSL シェーダーと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-238">Those that are programmed using HLSL are known as HLSL shaders.</span></span> <span data-ttu-id="461d0-239">[HLSL])(#hlsl) シェーダーのソース コード ファイルには、.hlsl というファイル拡張子が付きます。</span><span class="sxs-lookup"><span data-stu-id="461d0-239">Source code files for [HLSL])(#hlsl) shaders have .hlsl file extension.</span></span> <span data-ttu-id="461d0-240">これらのシェーダーは、作成時または実行時にコンパイルでき、実行時に適切なパイプライン ステージに設定できます。コンパイルされたシェーダー オブジェクトには、.cso というファイル拡張子が付きます。</span><span class="sxs-lookup"><span data-stu-id="461d0-240">These shaders can be compiled at author-time or at runtime, and set at runtime into the appropriate pipeline stage; a compiled shader object has a .cso file extension.</span></span>

<span data-ttu-id="461d0-241">Direct3D 9 シェーダーは、シェーダー モデル 1、シェーダー モデル 2、シェーダー モデル 3 を使用して設計できます。Direct3D 10 シェーダーは、シェーダー モデル 4 でのみ設計できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-241">Direct3D 9 shaders can be designed using shader model 1, shader model 2 and shader model 3; Direct3D 10 shaders can only be designed on shader model 4.</span></span> <span data-ttu-id="461d0-242">Direct3D 11 シェーダーは、シェーダー モデル 5 で設計できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-242">Direct3D 11 shaders can be designed on shader model 5.</span></span> <span data-ttu-id="461d0-243">Direct3D 11.3 および Direct3D 12 シェーダーは、シェーダー モデル 5.1 で設計できます。Direct3D 12 シェーダーは、シェーダー モデル 6 でも設計できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-243">Direct3D 11.3 and Direct3D 12 can be designed on shader model 5.1, and Direct3D 12 can also be designed on shader model 6.</span></span>

#### <a name="vertex-shaders-and-pixel-shaders"></a><span data-ttu-id="461d0-244">頂点シェーダーとピクセル シェーダー</span><span class="sxs-lookup"><span data-stu-id="461d0-244">Vertex shaders and pixel shaders</span></span>

<span data-ttu-id="461d0-245">データは、プリミティブのストリームとしてグラフィックス パイプラインに入り、頂点シェーダーやピクセル シェーダーなどさまざまなシェーダーによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-245">Data enters the graphics pipeline as a stream of primitives and is processed by various shaders such as the vertex shaders and pixel shaders.</span></span> 

<span data-ttu-id="461d0-246">頂点シェーダーは、通常、変換、スキン、照明の適用などの操作を実行することによって、頂点を処理します。</span><span class="sxs-lookup"><span data-stu-id="461d0-246">Vertex shaders processes vertices, typically performing operations such as transformations, skinning, and lighting.</span></span>  <span data-ttu-id="461d0-247">ピクセル シェーダーは、ピクセル単位の照明や後処理など、豊富なシェーディング手法を実現します。</span><span class="sxs-lookup"><span data-stu-id="461d0-247">Pixel shaders enables rich shading techniques such as per-pixel lighting and post-processing.</span></span> <span data-ttu-id="461d0-248">ピクセル シェーダーは、定数変数、テクスチャ データ、補間された頂点単位の値などのデータを組み合わせて、ピクセル単位の出力を生成します。</span><span class="sxs-lookup"><span data-stu-id="461d0-248">It combines constant variables, texture data, interpolated per-vertex values, and other data to produce per-pixel outputs.</span></span> 

#### <a name="shader-stages"></a><span data-ttu-id="461d0-249">シェーダー ステージ</span><span class="sxs-lookup"><span data-stu-id="461d0-249">Shader stages</span></span>

<span data-ttu-id="461d0-250">このプリミティブのストリームを処理するために定義されたさまざまなシェーダーのシーケンスは、レンダリング パイプラインのシェーダー ステージと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-250">A sequence of these various shaders defined to process this stream of primitives is known as shader stages in a rendering pipeline.</span></span> <span data-ttu-id="461d0-251">実際のステージは、Direct3D のバージョンによって異なりますが、通常は、頂点、ジオメトリ、ピクセルのステージが含まれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-251">The actual stages depend on the version of Direct3D, but usually include the vertex, geometry, and pixel stages.</span></span> <span data-ttu-id="461d0-252">テセレーション用のハル シェーダーやドメイン シェーダー、計算シェーダーなど、他のステージもあります。</span><span class="sxs-lookup"><span data-stu-id="461d0-252">There are also other stages, such as the hull and domain shaders for tessellation, and the compute shader.</span></span> <span data-ttu-id="461d0-253">これらステージはすべて、[HLSL])(#hlsl) を使用して完全にプログラミングできます。</span><span class="sxs-lookup"><span data-stu-id="461d0-253">All these stages are completely programmable using the [HLSL])(#hlsl).</span></span> <span data-ttu-id="461d0-254">詳細については、[グラフィックス パイプラインに関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476882.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-254">For more information, see [Graphics pipeline](https://msdn.microsoft.com/library/windows/desktop/ff476882.aspx).</span></span>

#### <a name="various-shader-file-formats"></a><span data-ttu-id="461d0-255">さまざまなシェーダー ファイル形式</span><span class="sxs-lookup"><span data-stu-id="461d0-255">Various shader file formats</span></span>

<span data-ttu-id="461d0-256">シェーダー コード ファイルの拡張子は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="461d0-256">Shader code file extensions:</span></span>
    * <span data-ttu-id="461d0-257">.hlsl という拡張子を持つファイルは、[HLSL])(#hlsl) ソース コードを保持します。</span><span class="sxs-lookup"><span data-stu-id="461d0-257">A file with the .hlsl extension holds [HLSL])(#hlsl) source code.</span></span>
    * <span data-ttu-id="461d0-258">.cso という拡張子を持つファイルは、コンパイル済みシェーダー オブジェクトを保持します。</span><span class="sxs-lookup"><span data-stu-id="461d0-258">A file with the .cso extension holds a compiled shader object.</span></span>
    * <span data-ttu-id="461d0-259">.h という拡張子を持つファイルはヘッダー ファイルですが、シェーダー コードのコンテキストでは、このヘッダー ファイルはシェーダー データを保持するバイト配列を定義します。</span><span class="sxs-lookup"><span data-stu-id="461d0-259">A file with the .h extension is a header file, but in a shader code context, this header file defines a byte array that holds shader data.</span></span>
    * <span data-ttu-id="461d0-260">.hlsli という拡張子を持つファイルは、定数バッファーの形式を格納します。</span><span class="sxs-lookup"><span data-stu-id="461d0-260">A file with the .hlsli extension contains the format of the constant buffers.</span></span> <span data-ttu-id="461d0-261">ゲーム サンプルでは、このファイルは __Shaders__>__ConstantBuffers.hlsli__ です。</span><span class="sxs-lookup"><span data-stu-id="461d0-261">In the game sample, the file is __Shaders__>__ConstantBuffers.hlsli__.</span></span>

> [!Note]
> <span data-ttu-id="461d0-262">シェーダーを埋め込むには、実行時に .cso ファイルを読み込むか、または実行可能コードに .h ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="461d0-262">You would embed the shader either by loading a .cso file at runtime or adding the .h file in your executable code.</span></span> <span data-ttu-id="461d0-263">ただし、同じシェーダーで両方を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="461d0-263">But you would not use both for the same shader.</span></span>

### <a name="deeper-understanding-of-directx"></a><span data-ttu-id="461d0-264">DirectX に関する高度な知識</span><span class="sxs-lookup"><span data-stu-id="461d0-264">Deeper understanding of DirectX</span></span>

<span data-ttu-id="461d0-265">Direct3D 11 は、ゲームなどのグラフィックスを多用するアプリケーションのグラフィックスを作成するのに役立つ一連の API です。このようなアプリケーションでは、負荷の高い計算を処理するために優れたグラフィックス カードを使用します。</span><span class="sxs-lookup"><span data-stu-id="461d0-265">Direct3D 11 is a set of APIs that can help us create graphics for graphics intensive applications like games, where we want to have a good graphics card to process intensive computation.</span></span> <span data-ttu-id="461d0-266">このセクションでは、Direct3D 11 グラフィックス プログラミングの概念 (リソース、サブリソース、デバイス、デバイス コンテキスト) について簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="461d0-266">This section briefly explains the Direct3D 11 graphics programming concepts: resource, subresource, device, and device context.</span></span>

#### <a name="resource"></a><span data-ttu-id="461d0-267">リソース</span><span class="sxs-lookup"><span data-stu-id="461d0-267">Resource</span></span>

<span data-ttu-id="461d0-268">グラフィックス プログラミングに関する経験が浅い場合は、リソース (デバイス リソースとも呼ばれる) は、テクスチャ、位置、色など、オブジェクトをレンダリングする方法に関する情報と考えてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="461d0-268">For those who are new, you can think of resources (also known as device resources) as info on how to render an object like texture, position, color.</span></span> <span data-ttu-id="461d0-269">リソースは、パイプラインにデータを提供し、シーン内でレンダリングされる対象を定義します。</span><span class="sxs-lookup"><span data-stu-id="461d0-269">Resources provide data to the pipeline and define what is rendered during your scene.</span></span> <span data-ttu-id="461d0-270">リソースは、ゲーム メディアから読み込むことも、実行時に動的に作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="461d0-270">Resources can be loaded from your game media or created dynamically at run time.</span></span>

<span data-ttu-id="461d0-271">リソースは、実際には、Direct3D [パイプライン](#rendering-pipeline)からアクセスできるメモリ内の領域です。</span><span class="sxs-lookup"><span data-stu-id="461d0-271">A resource is, in fact, an area in memory that can be accessed by the Direct3D [pipeline](#rendering-pipeline).</span></span> <span data-ttu-id="461d0-272">パイプラインでメモリに効率的にアクセスするには、パイプラインに渡すデータ (入力ジオメトリ、シェーダー リソース、テクスチャなど) をリソースに格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-272">In order for the pipeline to access memory efficiently, data that is provided to the pipeline (such as input geometry, shader resources, and textures) must be stored in a resource.</span></span> <span data-ttu-id="461d0-273">すべての Direct3D リソースの派生元となるリソースは 2 種類あります。バッファーとテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="461d0-273">There are two types of resources from which all Direct3D resources derive: a buffer or a texture.</span></span> <span data-ttu-id="461d0-274">各パイプライン ステージでは最大 128 個のリソースをアクティブにできます。</span><span class="sxs-lookup"><span data-stu-id="461d0-274">Up to 128 resources can be active for each pipeline stage.</span></span> <span data-ttu-id="461d0-275">詳しくは、「[リソース](../graphics-concepts/resources.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461d0-275">For more information, see [Resources](../graphics-concepts/resources.md).</span></span>

#### <a name="subresource"></a><span data-ttu-id="461d0-276">サブリソース</span><span class="sxs-lookup"><span data-stu-id="461d0-276">Subresource</span></span>

<span data-ttu-id="461d0-277">サブリソースという用語はリソースのサブセットを指します。</span><span class="sxs-lookup"><span data-stu-id="461d0-277">The term subresource refers to a subset of a resource.</span></span> <span data-ttu-id="461d0-278">Direct3D は、リソース全体を参照することも、リソースのサブセットを参照することもできます。</span><span class="sxs-lookup"><span data-stu-id="461d0-278">Direct3D can reference an entire resource or it can reference subsets of a resource.</span></span> <span data-ttu-id="461d0-279">詳しくは、「[サブリソース](../graphics-concepts/resource-types.md#subresources)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461d0-279">For more information, see [Subresource](../graphics-concepts/resource-types.md#subresources).</span></span>

#### <a name="depth-stencil"></a><span data-ttu-id="461d0-280">深度/ステンシル</span><span class="sxs-lookup"><span data-stu-id="461d0-280">Depth-stencil</span></span>

<span data-ttu-id="461d0-281">深度/ステンシル リソースには、深度とステンシルの情報を保持するための形式とバッファーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-281">A depth-stencil resource contains the format and buffer to hold depth and stencil information.</span></span> <span data-ttu-id="461d0-282">このリソースは、テクスチャー リソースを使用して作成されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-282">It is created using a texture resource.</span></span> <span data-ttu-id="461d0-283">深度/ステンシル リソースを作成する方法について詳しくは、「[深度/ステンシル機能の構成](https://msdn.microsoft.com/library/windows/desktop/bb205074.aspx)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-283">For more information on how to create a depth-stencil resource, see [Configuring Depth-Stencil Functionality](https://msdn.microsoft.com/library/windows/desktop/bb205074.aspx).</span></span> <span data-ttu-id="461d0-284">深度/ステンシル リソースにアクセスするには、[ID3D11DepthStencilView](https://msdn.microsoft.com/library/windows/desktop/ff476377.aspx) インターフェイスを使って実装される深度/ステンシル ビュー使用します。</span><span class="sxs-lookup"><span data-stu-id="461d0-284">We access the depth-stencil resource through the depth-stencil view implemented using the [ID3D11DepthStencilView](https://msdn.microsoft.com/library/windows/desktop/ff476377.aspx) interface.</span></span>

<span data-ttu-id="461d0-285">深度情報は、ビューから隠すのではなくレンダリングする多角形の領域を示します。</span><span class="sxs-lookup"><span data-stu-id="461d0-285">Depth info tells us which areas of polygons are rendered rather than hidden from view.</span></span> <span data-ttu-id="461d0-286">ステンシル情報は、マスクするピクセルを示します。</span><span class="sxs-lookup"><span data-stu-id="461d0-286">Stencil info tells us which pixels are masked.</span></span> <span data-ttu-id="461d0-287">ステンシル情報は、ピクセルを描画するかどうかを決定する (ビットを 1 または 0 に設定する) ため、特殊効果を生成するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-287">It can be used to produce special effects since it determines whether a pixel is drawn or not; sets the bit to a 1 or 0.</span></span> 

<span data-ttu-id="461d0-288">詳細については、「[深度ステンシル ビュー](../graphics-concepts/depth-stencil-view--dsv-.md)」、「[深度バッファー](../graphics-concepts/depth-buffers.md)」、「[ステンシル バッファー](../graphics-concepts/stencil-buffers.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-288">For more information, see: [Depth-stencil view](../graphics-concepts/depth-stencil-view--dsv-.md), [depth buffer](../graphics-concepts/depth-buffers.md), and [stencil buffer](../graphics-concepts/stencil-buffers.md).</span></span>

#### <a name="render-target"></a><span data-ttu-id="461d0-289">レンダー ターゲット</span><span class="sxs-lookup"><span data-stu-id="461d0-289">Render target</span></span>

<span data-ttu-id="461d0-290">レンダー ターゲットは、レンダリング パスの最後に書き込むことができるリソースです。</span><span class="sxs-lookup"><span data-stu-id="461d0-290">A render target is a resource that we can write to at the end of a render pass.</span></span> <span data-ttu-id="461d0-291">通常、[ID3D11Device::CreateRenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476517.aspx) メソッドで、入力パラメーターとしてスワップ チェーン バック バッファー (これもリソースです) を使用して作成されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-291">It is commonly created using the [ID3D11Device::CreateRenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476517.aspx) method using the swap chain back buffer (which is also a resource) as the input parameter.</span></span> 

<span data-ttu-id="461d0-292">各レンダー ターゲットには、対応する深度/ステンシル ビューも必要です。これは、レンダー ターゲットを使用する前に、[OMSetRenderTargets](https://msdn.microsoft.com/library/windows/desktop/ff476464.aspx) を使用してレンダー ターゲットを設定するときに、深度/ステンシル ビューも必要となるためです。</span><span class="sxs-lookup"><span data-stu-id="461d0-292">Each render target should also have a corresponding depth-stencil view because when we use [OMSetRenderTargets](https://msdn.microsoft.com/library/windows/desktop/ff476464.aspx) to set the render target before using it, it requires also a depth-stencil view.</span></span> <span data-ttu-id="461d0-293">レンダー ターゲット リソースにアクセスするには、[ID3D11RenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476582.aspx) インターフェイスを使用して実装されるレンダー ターゲット ビューを使用します。</span><span class="sxs-lookup"><span data-stu-id="461d0-293">We access the render target resource through the render target view implemented using the [ID3D11RenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476582.aspx) interface.</span></span> 

#### <a name="device"></a><span data-ttu-id="461d0-294">デバイス</span><span class="sxs-lookup"><span data-stu-id="461d0-294">Device</span></span>

<span data-ttu-id="461d0-295">Direct3D 11 の使用経験が浅い場合は、デバイスは、オブジェクトの割り当てと破棄、プリミティブのレンダリング、グラフィックス ドライバー経由のグラフィックス カードとの通信を行うための方法であると考えることができます。</span><span class="sxs-lookup"><span data-stu-id="461d0-295">For those who are new to Direct3D 11, you can imagine a device as a way to allocate and destroy objects, render primitives, and communicate with the graphics card through the graphics driver.</span></span> 

<span data-ttu-id="461d0-296">より正確に説明すると、Direct3D デバイスは Direct3D のレンダリング コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="461d0-296">For a more precise explanation, a Direct3D device is the rendering component of Direct3D.</span></span> <span data-ttu-id="461d0-297">デバイスは、レンダリングの状態をカプセル化して格納します。また、変換や照明の操作、サーフェスへのイメージのラスタライズを実行します。</span><span class="sxs-lookup"><span data-stu-id="461d0-297">A device encapsulates and stores the rendering state, performs transformations and lighting operations, and rasterizes an image to a surface.</span></span> <span data-ttu-id="461d0-298">詳しくは、「[デバイス](../graphics-concepts/devices.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461d0-298">For more information, see [Devices](../graphics-concepts/devices.md)</span></span>

<span data-ttu-id="461d0-299">デバイスは、[ID3D11Device](https://msdn.microsoft.com/library/windows/desktop/ff476379.aspx) インターフェイスによって表されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-299">A device is represented by the [ID3D11Device](https://msdn.microsoft.com/library/windows/desktop/ff476379.aspx) interface.</span></span> <span data-ttu-id="461d0-300">つまり、ID3D11Device インターフェイスは仮想ディスプレイ アダプターを表し、デバイスによって所有されるリソースを作成するために使用します。</span><span class="sxs-lookup"><span data-stu-id="461d0-300">In other words, the ID3D11Device interface represents a virtual display adapter and is used to create resources that are owned by a device.</span></span> 

<span data-ttu-id="461d0-301">ID3D11Device には複数のバージョンがあり、[ID3D11Device5](https://msdn.microsoft.com/library/windows/desktop/mt492478.aspx) が最新バージョンで、ID3D11Device4 に新しいメソッドが追加されています。</span><span class="sxs-lookup"><span data-stu-id="461d0-301">Note that there are different versions of ID3D11Device, [ID3D11Device5](https://msdn.microsoft.com/library/windows/desktop/mt492478.aspx) is the latest version and adds new methods to those in ID3D11Device4.</span></span> <span data-ttu-id="461d0-302">Direct3D が基になるハードウェアと通信する方法の詳細については、[Windows Device Driver Model (WDDM) アーキテクチャに関するページ](https://docs.microsoft.com/windows-hardware/drivers/display/windows-vista-and-later-display-driver-model-architecture)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-302">For more information on how Direct3D communicates with the underlying hardware, see [Windows Device Driver Model (WDDM) architecture](https://docs.microsoft.com/windows-hardware/drivers/display/windows-vista-and-later-display-driver-model-architecture).</span></span>

<span data-ttu-id="461d0-303">各アプリケーションには少なくとも 1 つのデバイスが必要であり、ほとんどのアプリケーションは 1 つだけデバイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="461d0-303">Each application must have at least one device, most applications only create one device.</span></span> <span data-ttu-id="461d0-304">コンピューターにインストールされているいずれかのハードウェア ドライバーについてデバイスを作成するには、__D3D11CreateDevice__ または __D3D11CreateDeviceAndSwapChain__ を呼び出して、D3D\_DRIVER\_TYPE フラグでドライバーの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="461d0-304">Create a device for one of the hardware drivers installed on your machine by calling __D3D11CreateDevice__ or __D3D11CreateDeviceAndSwapChain__ and specifying the driver type with the D3D\_DRIVER\_TYPE flag.</span></span> <span data-ttu-id="461d0-305">各デバイスでは、必要な機能に応じて、1 つまたは複数のデバイス コンテキストを使用できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-305">Each device can use one or more device contexts, depending on the functionality desired.</span></span> <span data-ttu-id="461d0-306">詳細については、[D3D11CreateDevice 関数に関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476082.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-306">For more information, see [D3D11CreateDevice function](https://msdn.microsoft.com/library/windows/desktop/ff476082.aspx).</span></span>

#### <a name="device-context"></a><span data-ttu-id="461d0-307">デバイス コンテキスト</span><span class="sxs-lookup"><span data-stu-id="461d0-307">Device context</span></span>

<span data-ttu-id="461d0-308">デバイス コンテキストは、[パイプライン](#rendering-pipeline)の状態を設定し、[デバイス](#device)によって所有される[リソース](#resource)を使用してレンダリング コマンドを生成するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-308">A device context is used to set [pipeline](#rendering-pipeline) state and generate rendering commands using the [resources](#resource) owned by a [device](#device).</span></span> 

<span data-ttu-id="461d0-309">Direct3D 11 は 2 種類のデバイス コンテキストを実装します。1 つは即時レンダリング用で、もう 1 つは遅延レンダリング用です。いずれのコンテキストも [ID3D11DeviceContext](https://msdn.microsoft.com/library/windows/desktop/ff476385.aspx) インターフェイスを使用して表されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-309">Direct3D 11 implements two types of device contexts, one for immediate rendering and the other for deferred rendering; both contexts are represented with an [ID3D11DeviceContext](https://msdn.microsoft.com/library/windows/desktop/ff476385.aspx) interface.</span></span>  

<span data-ttu-id="461d0-310">__ID3D11DeviceContext__ インターフェイスには複数のバージョンがあり、__ID3D11DeviceContext4__ は __ID3D11DeviceContext3__ に新しいメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="461d0-310">The __ID3D11DeviceContext__ interfaces have different versions; __ID3D11DeviceContext4__ adds new methods to those in __ID3D11DeviceContext3__.</span></span>

<span data-ttu-id="461d0-311">注: __ID3D11DeviceContext4__ は Windows 10 Creators Update で導入され、__ID3D11DeviceContext__ インターフェイスの最新バージョンです。</span><span class="sxs-lookup"><span data-stu-id="461d0-311">Note: __ID3D11DeviceContext4__ is introduced in the Windows 10 Creators Update and is the latest version of the __ID3D11DeviceContext__ interface.</span></span> <span data-ttu-id="461d0-312">Windows 10 Creators Update を対象とするアプリケーションでは、以前のバージョンではなく、このインターフェイスを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-312">Applications targeting Windows 10 Creators Update should use this interface instead of earlier versions.</span></span> <span data-ttu-id="461d0-313">詳しくは、[ID3D11DeviceContext4 に関するページ](https://msdn.microsoft.com/library/windows/desktop/mt492481.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-313">For more information, see [ID3D11DeviceContext4](https://msdn.microsoft.com/library/windows/desktop/mt492481.aspx).</span></span>

#### <a name="dxdeviceresources"></a><span data-ttu-id="461d0-314">DX::DeviceResources</span><span class="sxs-lookup"><span data-stu-id="461d0-314">DX::DeviceResources</span></span>

<span data-ttu-id="461d0-315">__DX::DeviceResources__ クラスは、__DeviceResources.cpp__/__.h__ ファイルに含まれており、すべての DirectX デバイス リソースを制御します。</span><span class="sxs-lookup"><span data-stu-id="461d0-315">The __DX::DeviceResources__ class is in the __DeviceResources.cpp__/__.h__ files and controls all of DirectX device resources.</span></span> <span data-ttu-id="461d0-316">サンプル ゲーム プロジェクトおよび DirectX 11 アプリ テンプレート プロジェクトでは、これらのファイルは __Commons__ フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="461d0-316">In the sample game project and the DirectX 11 App template project, these files are in the __Commons__ folder.</span></span> <span data-ttu-id="461d0-317">Visual Studio 2015 以降で、新しい DirectX 11 アプリ テンプレート プロジェクトを作成するときに、これらのファイルの最新バージョンを取り込むことができます。</span><span class="sxs-lookup"><span data-stu-id="461d0-317">You can grab the latest version of these files when you create a new DirectX 11 App template project in Visual Studio 2015 or later.</span></span>

### <a name="buffer"></a><span data-ttu-id="461d0-318">バッファー</span><span class="sxs-lookup"><span data-stu-id="461d0-318">Buffer</span></span>

<span data-ttu-id="461d0-319">バッファー リソースは完全に型指定されたデータのコレクションであり、複数の要素にグループ化されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-319">A buffer resource is a collection of fully typed data grouped into elements.</span></span> <span data-ttu-id="461d0-320">バッファーを使用して、さまざまなデータを格納できます。たとえば、位置ベクトル、法線ベクトル、頂点バッファー内のテクスチャ座標、インデックス バッファー内のインデックス、デバイスの状態などのデータが格納されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-320">You can use buffers to store a wide variety of data, including position vectors, normal vectors, texture coordinates in a vertex buffer, indexes in an index buffer, or device state.</span></span> <span data-ttu-id="461d0-321">バッファー要素には、圧縮済みデータ値 (R8G8B8A8 サーフェス値)、単一の 8 ビット整数、または 4 つの 32 ビット浮動小数点値を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="461d0-321">Buffer elements can include packed data values (like R8G8B8A8 surface values), single 8-bit integers, or four 32-bit floating point values.</span></span>

<span data-ttu-id="461d0-322">利用可能なバッファーには、頂点バッファー、インデックス バッファー、定数バッファーの 3 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-322">There are three types of buffers available: Vertex buffer, index buffer, and constant buffer.</span></span>

#### <a name="vertex-buffer"></a><span data-ttu-id="461d0-323">頂点バッファー</span><span class="sxs-lookup"><span data-stu-id="461d0-323">Vertex Buffer</span></span>

<span data-ttu-id="461d0-324">ジオメトリの定義に使われる頂点データが格納されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-324">Contains the vertex data used to define your geometry.</span></span> <span data-ttu-id="461d0-325">頂点データには、位置座標、色データ、テクスチャ座標データ、法線データなどが含まれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-325">Vertex data includes position coordinates, color data, texture coordinate data, normal data, and so on.</span></span> 

#### <a name="index-buffer"></a><span data-ttu-id="461d0-326">インデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="461d0-326">Index Buffer</span></span>

<span data-ttu-id="461d0-327">頂点バッファーへの整数オフセットが格納されます。このバッファーは、より効率的なプリミティブのレンダリングに使われます。</span><span class="sxs-lookup"><span data-stu-id="461d0-327">Contains integer offsets into vertex buffers and are used to render primitives more efficiently.</span></span> <span data-ttu-id="461d0-328">インデックス バッファーは 16 ビットまたは 32 ビットの連続するインデックスを格納します。各インデックスは頂点バッファーの頂点を識別するのに使用されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-328">An index buffer contains a sequential set of 16-bit or 32-bit indices; each index is used to identify a vertex in a vertex buffer.</span></span>

#### <a name="constant-buffer-or-shader-constant-buffer"></a><span data-ttu-id="461d0-329">定数バッファーまたはシェーダー定数バッファー</span><span class="sxs-lookup"><span data-stu-id="461d0-329">Constant Buffer or shader-constant buffer</span></span>

<span data-ttu-id="461d0-330">シェーダー データをパイプラインに効率的に提供できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-330">Allows you to efficiently supply shader data to the pipeline.</span></span> <span data-ttu-id="461d0-331">定数バッファーは、各プリミティブについて実行され、レンダリング パイプラインのストリーム出力ステージの結果を格納するシェーダーの入力として使用できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-331">You can use constant buffers as inputs to the shaders that run for each primitive and store results of the stream-output stage of the rendering pipeline.</span></span> <span data-ttu-id="461d0-332">定数バッファーは、概念的には要素が 1 つの頂点バッファーに似ています。</span><span class="sxs-lookup"><span data-stu-id="461d0-332">Conceptually, a constant buffer looks just like a single-element vertex buffer.</span></span>

#### <a name="design-and-implementation-of-buffers"></a><span data-ttu-id="461d0-333">バッファーの設計と実装</span><span class="sxs-lookup"><span data-stu-id="461d0-333">Design and implementation of buffers</span></span>

<span data-ttu-id="461d0-334">バッファーはデータ型に基づいて設計できます。たとえば、ゲームのサンプルでは、静的データ用に 1 つのバッファー、フレームで一定のデータ用に別のバッファー、プリミティブに固有のデータ用にまた別のバッファーを作成します。</span><span class="sxs-lookup"><span data-stu-id="461d0-334">You can design buffers based on the data type, for example, like in our game sample, one buffer is created for static data, another for data that's constant over the frame, and another for data that's specific to a primitive.</span></span>

<span data-ttu-id="461d0-335">すべてのバッファーの種類は __ID3D11Buffer__ インターフェイスによってカプセル化され、__ID3D11Device::CreateBuffer__ を呼び出すことによってバッファー リソースを作成できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-335">All buffer types are encapsulated by the __ID3D11Buffer__ interface and you can create a buffer resource by calling __ID3D11Device::CreateBuffer__.</span></span> <span data-ttu-id="461d0-336">ただし、バッファーにアクセスするには、その前にバッファーがパイプラインにバインドされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-336">But a buffer must be bound to the pipeline before it can be accessed.</span></span> <span data-ttu-id="461d0-337">バッファーは、読み取りのために同時に複数のパイプライン ステージにバインドできます。</span><span class="sxs-lookup"><span data-stu-id="461d0-337">Buffers can be bound to multiple pipeline stages simultaneously for reading.</span></span> <span data-ttu-id="461d0-338">バッファーは、書き込みのために単一のパイプライン ステージにバインドすることもできます。ただし、同じバッファーを読み取りと書き込みのために同時にバインドすることはできません。</span><span class="sxs-lookup"><span data-stu-id="461d0-338">A buffer can also be bound to a single pipeline stage for writing; however, the same buffer cannot be bound for reading and writing simultaneously.</span></span>

<span data-ttu-id="461d0-339">次のようなステージにバッファーをバインドします。</span><span class="sxs-lookup"><span data-stu-id="461d0-339">Bind buffers to the:</span></span>
    * <span data-ttu-id="461d0-340">入力アセンブラー ステージ。そのためには、__ID3D11DeviceContext__ の __ID3D11DeviceContext::IASetVertexBuffers__ メソッドや __ID3D11DeviceContext::IASetIndexBuffer__ メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="461d0-340">Input-assembler stage by calling __ID3D11DeviceContext__ methods like __ID3D11DeviceContext::IASetVertexBuffers__ and __ID3D11DeviceContext::IASetIndexBuffer__</span></span>
    * <span data-ttu-id="461d0-341">ストリーム出力ステージ。そのためには、__ID3D11DeviceContext::SOSetTargets__ を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="461d0-341">Stream-output stage by calling __ID3D11DeviceContext::SOSetTargets__</span></span>
    * <span data-ttu-id="461d0-342">シェーダー ステージ。そのためには、__ID3D11DeviceContext::VSSetConstantBuffers__ などのシェーダー メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="461d0-342">Shader stage by calling shader methods, like __ID3D11DeviceContext::VSSetConstantBuffers__</span></span>

<span data-ttu-id="461d0-343">詳しくは、「[Direct3D 11 のバッファーについて](https://msdn.microsoft.com/library/windows/desktop/ff476898.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461d0-343">For more information, see [Introduction to buffers in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476898.aspx).</span></span>

### <a name="dxgi"></a><span data-ttu-id="461d0-344">DXGI</span><span class="sxs-lookup"><span data-stu-id="461d0-344">DXGI</span></span>

<span data-ttu-id="461d0-345">Microsoft DirectX グラフィックス インフラストラクチャ (DXGI) は、direct3d10 で必要とされる低レベルのタスクの一部をカプセル化 WindowsVista で導入された新しいサブシステム 10.1、11、11.1 します。</span><span class="sxs-lookup"><span data-stu-id="461d0-345">Microsoft DirectX Graphics Infrastructure (DXGI) is a new subsystem that was introduced with WindowsVista that encapsulates some of the low-level tasks that are needed by Direct3D 10, 10.1, 11, and 11.1.</span></span> <span data-ttu-id="461d0-346">マルチスレッド アプリケーションで DXGI を使用する場合、デッドロックが発生しないように特に注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-346">Special care must be taken when using DXGI in a multithreaded application to ensure that deadlocks do not occur.</span></span> <span data-ttu-id="461d0-347">詳細については、[DirectX グラフィックス インフラストラクチャ (DXGI): ベスト プラクティスのマルチスレッドに関する説明](https://msdn.microsoft.com/library/windows/desktop/ee417025.aspx#multithreading_and_dxgi)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-347">For more info, see [DirectX Graphics Infrastructure (DXGI): Best Practices- Multithreading](https://msdn.microsoft.com/library/windows/desktop/ee417025.aspx#multithreading_and_dxgi)</span></span>

### <a name="feature-level"></a><span data-ttu-id="461d0-348">機能レベル</span><span class="sxs-lookup"><span data-stu-id="461d0-348">Feature Level</span></span>

<span data-ttu-id="461d0-349">機能レベルは、最新または既存のコンピューターで多様なビデオ カードを処理するために、Direct3D 11 で導入された概念です。</span><span class="sxs-lookup"><span data-stu-id="461d0-349">Feature level is a concept introduced in Direct3D 11 to handle the diversity of video cards in new and existing machines.</span></span> <span data-ttu-id="461d0-350">機能レベルは、明確に定義されたグラフィックス処理装置 (GPU) 機能のセットです。</span><span class="sxs-lookup"><span data-stu-id="461d0-350">A feature level is a well defined set of graphics processing unit (GPU) functionality.</span></span> 

<span data-ttu-id="461d0-351">各ビデオ カードは、インストールされている GPU に応じて、特定のレベルの DirectX の機能を実装します。</span><span class="sxs-lookup"><span data-stu-id="461d0-351">Each video card implements a certain level of DirectX functionality depending on the GPUs installed.</span></span> <span data-ttu-id="461d0-352">以前のバージョンの Microsoft Direct3D では、ビデオ カードが実装しているバージョンを検出し、それに応じてアプリケーションをプログラミングすることができました。</span><span class="sxs-lookup"><span data-stu-id="461d0-352">In prior versions of Microsoft Direct3D, you could find out the version of Direct3D the video card implemented, and then program your application accordingly.</span></span> 

<span data-ttu-id="461d0-353">機能レベルを使用すると、デバイスを作成するときに、必要な機能レベルのデバイスを作成してみることができます。</span><span class="sxs-lookup"><span data-stu-id="461d0-353">With feature level, when you create a device, you can attempt to create a device for the feature level that you want to request.</span></span> <span data-ttu-id="461d0-354">デバイスの作成に成功した場合は、その機能レベルが存在します。失敗した場合は、ハードウェアはその機能レベルをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="461d0-354">If the device creation works, that feature level exists, if not, the hardware does not support that feature level.</span></span> <span data-ttu-id="461d0-355">低い機能レベルでデバイスを再作成してみることも、アプリケーションの終了を選択することもできます。</span><span class="sxs-lookup"><span data-stu-id="461d0-355">You can either try to recreate a device at a lower feature level or you can choose to exit the application.</span></span> <span data-ttu-id="461d0-356">たとえば、12\_0 機能レベルでは、Direct3D 11.3 や Direct3D 12、およびシェーダー モデル 5.1 が必要です。</span><span class="sxs-lookup"><span data-stu-id="461d0-356">For instance, the 12\_0 feature level requires Direct3D 11.3 or Direct3D 12, and shader model 5.1.</span></span> <span data-ttu-id="461d0-357">詳細については、[Direct3D の各機能レベルの概要に関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476876.aspx#Overview)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-357">For more information, see [Direct3D feature levels: Overview for each feature level](https://msdn.microsoft.com/library/windows/desktop/ff476876.aspx#Overview).</span></span>

<span data-ttu-id="461d0-358">機能レベルを使用して、Direct3D9 や Microsoft Direct3D10、Direct3D11 では、アプリケーションを開発し、9、10、11 のハードウェア (一部例外あり) で実行できます。</span><span class="sxs-lookup"><span data-stu-id="461d0-358">Using feature levels, you can develop an application for Direct3D9, Microsoft Direct3D10, or Direct3D11, and then run it on 9, 10, or 11 hardware (with some exceptions).</span></span> <span data-ttu-id="461d0-359">詳細については、[Direct3D の機能レベルに関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476876.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-359">For more information, see [Direct3D feature levels](https://msdn.microsoft.com/library/windows/desktop/ff476876.aspx).</span></span>

### <a name="stereo-rendering"></a><span data-ttu-id="461d0-360">ステレオ レンダリング</span><span class="sxs-lookup"><span data-stu-id="461d0-360">Stereo rendering</span></span>

<span data-ttu-id="461d0-361">ステレオ レンダリングは奥行き感を強化するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-361">Stereo rendering is used to enhance the illusion of depth.</span></span> <span data-ttu-id="461d0-362">左目の視点から画像と右目の視点からの画像の 2 つの画像を使用して、ディスプレイの画面にシーンを表示します。</span><span class="sxs-lookup"><span data-stu-id="461d0-362">It uses two images, one from the left eye and the other from the right eye to display a scene on the display screen.</span></span> 

<span data-ttu-id="461d0-363">数学的には、ステレオ射影行列を適用することによってこれを実現します。ステレオ射影行列は、通常のモノラル射影行列を水平方向にわずかに右および左にオフセットしたものです。</span><span class="sxs-lookup"><span data-stu-id="461d0-363">Mathematically, we apply a stereo projection matrix, which is a slight horizontal offset to the right and to the left, of the regular mono projection matrix to achieve this.</span></span>

<span data-ttu-id="461d0-364">このゲーム サンプルでは、ステレオ レンダリングを実現するために、次の 2 つのレンダリング パスを実行しました。</span><span class="sxs-lookup"><span data-stu-id="461d0-364">We did two rendering passes to achieve stereo rendering in this game sample:</span></span>
* <span data-ttu-id="461d0-365">右側のレンダー ターゲットにバインドし、右の射影を適用したのち、プリミティブ オブジェクトを描画します。</span><span class="sxs-lookup"><span data-stu-id="461d0-365">Bind to right render target, apply right projection, then draw the primitive object.</span></span>
* <span data-ttu-id="461d0-366">左側のレンダー ターゲットにバインドし、左の射影を適用したのち、プリミティブ オブジェクトを描画します。</span><span class="sxs-lookup"><span data-stu-id="461d0-366">Bind to left render target, apply left projection, then draw the primitive object.</span></span>

### <a name="camera-and-coordinate-space"></a><span data-ttu-id="461d0-367">カメラと座標空間</span><span class="sxs-lookup"><span data-stu-id="461d0-367">Camera and coordinate space</span></span>

<span data-ttu-id="461d0-368">ゲームには、独自の座標系でワールドを更新するためのコードがあります (ワールド空間またはシーン空間と呼ばれることもあります)。</span><span class="sxs-lookup"><span data-stu-id="461d0-368">The game has the code in place to update the world in its own coordinate system (sometimes called the world space or scene space).</span></span> <span data-ttu-id="461d0-369">カメラを含むすべてのオブジェクトはこの空間に配置されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-369">All objects, including the camera, are positioned and oriented in this space.</span></span> <span data-ttu-id="461d0-370">詳細については、「[座標系](../graphics-concepts/coordinate-systems.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-370">For more information, see [Coordinate systems](../graphics-concepts/coordinate-systems.md).</span></span>

<span data-ttu-id="461d0-371">頂点シェーダーは、次のアルゴリズムを使って (V はベクター、M は行列を表す) モデル座標からデバイス座標への変換を行います。</span><span class="sxs-lookup"><span data-stu-id="461d0-371">A vertex shader does the heavy lifting of converting from the model coordinates to device coordinates with the following algorithm (where V is a vector and M is a matrix).</span></span>

<span data-ttu-id="461d0-372">V(device) = V(model) x M(model-to-world) x M(world-to-view) x M(view-to-device)。</span><span class="sxs-lookup"><span data-stu-id="461d0-372">V(device) = V(model) x M(model-to-world) x M(world-to-view) x M(view-to-device).</span></span>

<span data-ttu-id="461d0-373">この場合</span><span class="sxs-lookup"><span data-stu-id="461d0-373">where:</span></span> 
* <span data-ttu-id="461d0-374">M(model-to-world) はモデル座標からワールド座標への変換行列であり、[ワールド変換行列](#world-transform-matrix)とも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-374">M(model-to-world) is a transformation matrix for model coordinates to world coordinates, also known as the [World transform matrix](#world-transform-matrix).</span></span> <span data-ttu-id="461d0-375">これは、プリミティブによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-375">This is provided by the primitive.</span></span>
* <span data-ttu-id="461d0-376">M(world-to-view) はワールド座標からビュー座標への変換行列であり、[ビュー変換行列](#view-transform-matrix)とも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-376">M(world-to-view) is a transformation matrix for world coordinates to view coordinates, also known as the [View transform matrix](#view-transform-matrix).</span></span>
    * <span data-ttu-id="461d0-377">これは、カメラのビュー行列によって提供されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-377">This is provided by the view matrix of the camera.</span></span> <span data-ttu-id="461d0-378">これは、カメラの位置とルック ベクター (カメラからシーンを直接ポイントする "ルック アット" ベクターとシーンに対して垂直かつ上向きの "ルック アップ" ベクター) によって定義されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-378">It's defined by the camera's position along with the look vectors (the "look at" vector that points directly into the scene from the camera, and the "look up" vector that is upwards perpendicular to it)</span></span>
    * <span data-ttu-id="461d0-379">サンプル ゲームでは、__m\_viewMatrix__ はビュー変換行列であり、__Camera::SetViewParams__ を使用して計算されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-379">In the sample game, __m\_viewMatrix__ is the view transformation matrix and is calculated using __Camera::SetViewParams__</span></span> 
* <span data-ttu-id="461d0-380">M(view-to-device) はビュー座標からデバイス座標への変換行列であり、[射影変換行列](#projection-transform-matrix)とも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-380">M(view-to-device) is a transformation matrix for view coordinates to device coordinates, also known as the [Projection transform matrix](#projection-transform-matrix)</span></span>
    * <span data-ttu-id="461d0-381">これは、カメラの射影によって提供されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-381">This is provided by the projection of the camera.</span></span> <span data-ttu-id="461d0-382">その空間のどれくらいの量が実際に最終的なシーンに表示されるかについての情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="461d0-382">It provides info how much of that space is actually visible in the final scene.</span></span> <span data-ttu-id="461d0-383">視野 (FoV)、縦横比、クリッピング面によって、射影変換行列が定義されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-383">The Field of View (FoV), aspect ratio, and clipping planes define the projection transform matrix.</span></span>
    * <span data-ttu-id="461d0-384">サンプル ゲームでは、__m\_projectionMatrix__ は、__Camera::SetProjParams__ を使用して計算された、射影座標への変換を定義します (ステレオ射影の場合は、それぞれの目のビューに 1 つずつ、2 つの射影行列を使用します)。</span><span class="sxs-lookup"><span data-stu-id="461d0-384">In the sample game, __m\_projectionMatrix__ defines transformation to the projection coordinates, calculated using __Camera::SetProjParams__ (For stereo projection, you use two projection matrices: one for each eye's view.)</span></span> 

<span data-ttu-id="461d0-385">VertexShader.hlsl のシェーダー コードがこれらのベクターや行列と共に定数バッファーから読み込まれ、各頂点に対してこの変換を実行します。</span><span class="sxs-lookup"><span data-stu-id="461d0-385">The shader code in VertexShader.hlsl is loaded with these vectors and matrices from the constant buffers, and performs this transformation for every vertex.</span></span>

### <a name="coordinate-transformation"></a><span data-ttu-id="461d0-386">座標変換</span><span class="sxs-lookup"><span data-stu-id="461d0-386">Coordinate transformation</span></span>

<span data-ttu-id="461d0-387">Direct3D では、3 つの変換を使用して 3D モデル座標をピクセル座標 (スクリーン空間) に変更します。</span><span class="sxs-lookup"><span data-stu-id="461d0-387">Direct3D uses three transformations to change your 3D model coordinates into pixel coordinates (screen space).</span></span> <span data-ttu-id="461d0-388">これらの変換は、ワールド変換、ビュー変換、射影変換です。</span><span class="sxs-lookup"><span data-stu-id="461d0-388">These transformations are world transform, view transform, and projection transform.</span></span> <span data-ttu-id="461d0-389">詳細については、「[変換の概要](../graphics-concepts/transform-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-389">For more info, go to [Transform overview](../graphics-concepts/transform-overview.md).</span></span>

#### <a name="world-transform-matrix"></a><span data-ttu-id="461d0-390">ワールド変換行列</span><span class="sxs-lookup"><span data-stu-id="461d0-390">World transform matrix</span></span>

<span data-ttu-id="461d0-391">ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。ワールド空間では、頂点はシーン内のすべてのオブジェクトに共通の原点を基準として相対的に定義されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-391">A world transform changes coordinates from model space, where vertices are defined relative to a model's local origin, to world space, where vertices are defined relative to an origin common to all the objects in a scene.</span></span> <span data-ttu-id="461d0-392">基本的に、ワールド変換はモデルをワールド空間に配置します。そのため、このように呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-392">In essence, the world transform places a model into the world; hence its name.</span></span> <span data-ttu-id="461d0-393">詳細については、「[ワールド変換](../graphics-concepts/world-transform.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-393">For more information, see [World transform](../graphics-concepts/world-transform.md).</span></span>

####  <a name="view-transform-matrix"></a><span data-ttu-id="461d0-394">ビュー変換行列</span><span class="sxs-lookup"><span data-stu-id="461d0-394">View transform matrix</span></span>

<span data-ttu-id="461d0-395">ビュー変換は、ビューアーをワールド空間に配置し、頂点をカメラ空間に変換します。</span><span class="sxs-lookup"><span data-stu-id="461d0-395">The view transform locates the viewer in world space, transforming vertices into camera space.</span></span> <span data-ttu-id="461d0-396">カメラ空間では、カメラつまりビューアーは原点に位置し、Z 軸の正方向を向いています。</span><span class="sxs-lookup"><span data-stu-id="461d0-396">In camera space, the camera, or viewer, is at the origin, looking in the positive z-direction.</span></span> <span data-ttu-id="461d0-397">詳細については、「[ビュー変換](../graphics-concepts/view-transform.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-397">For more info, go to [View transform](../graphics-concepts/view-transform.md).</span></span>

####  <a name="projection-transform-matrix"></a><span data-ttu-id="461d0-398">射影変換行列</span><span class="sxs-lookup"><span data-stu-id="461d0-398">Projection transform matrix</span></span>

<span data-ttu-id="461d0-399">射影変換では、視錐台を立方体に変換します。</span><span class="sxs-lookup"><span data-stu-id="461d0-399">The projection transform converts the viewing frustum to a cuboid shape.</span></span> <span data-ttu-id="461d0-400">視錐台とは、ビューポートのカメラに対して相対的に配置された、シーン内の 3D ボリュームです。</span><span class="sxs-lookup"><span data-stu-id="461d0-400">A viewing frustum is a 3D volume in a scene positioned relative to the viewport's camera.</span></span> <span data-ttu-id="461d0-401">ビューポートとは、3D シーンが投影される 2D の四角形です。</span><span class="sxs-lookup"><span data-stu-id="461d0-401">A viewport is a 2D rectangle into which a 3D scene is projected.</span></span> <span data-ttu-id="461d0-402">詳細については、「[ビューポートとクリッピング](../graphics-concepts/viewports-and-clipping.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-402">For more information, see [Viewports and clipping](../graphics-concepts/viewports-and-clipping.md)</span></span>

<span data-ttu-id="461d0-403">視錐台の近くの端は遠くの端よりも小さいので、このトランスフォームにはカメラの近くのオブジェクトを拡大するという効果があり、これによってシーンに遠近感が生まれます。</span><span class="sxs-lookup"><span data-stu-id="461d0-403">Because the near end of the viewing frustum is smaller than the far end, this has the effect of expanding objects that are near to the camera; this is how perspective is applied to the scene.</span></span> <span data-ttu-id="461d0-404">したがって、プレイヤーに近いオブジェクトは大きく表示され、遠くにあるオブジェクトは小さく表示されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-404">So objects that are closer to the player, appear larger; objects that are further away, appear smaller.</span></span>

<span data-ttu-id="461d0-405">数学的には、射影変換は、通常、スケーリングおよび遠近法の両方の行列です。</span><span class="sxs-lookup"><span data-stu-id="461d0-405">Mathematically, the projection transform is a matrix that is typically both a scale and perspective projection.</span></span> <span data-ttu-id="461d0-406">カメラのレンズと同様に機能します。</span><span class="sxs-lookup"><span data-stu-id="461d0-406">It functions like the lens of a camera.</span></span> <span data-ttu-id="461d0-407">詳細については、「[射影変換](../graphics-concepts/projection-transform.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-407">For more information, see [Projection transform](../graphics-concepts/projection-transform.md).</span></span>

### <a name="sampler-state"></a><span data-ttu-id="461d0-408">サンプラーの状態</span><span class="sxs-lookup"><span data-stu-id="461d0-408">Sampler state</span></span>

<span data-ttu-id="461d0-409">サンプラーの状態は、テクスチャのアドレス指定モード、フィルター、詳細レベルを使用して、テクスチャ データをサンプリングする方法を決定します。</span><span class="sxs-lookup"><span data-stu-id="461d0-409">Sampler state determines how texture data is sampled using texture addressing modes, filtering, and level of detail.</span></span> <span data-ttu-id="461d0-410">サンプリングは、テクスチャ ピクセル、つまりテクセルがテクスチャから読み取られるたびに実行されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-410">Sampling is done each time a texture pixel, or texel, is read from a texture.</span></span>

<span data-ttu-id="461d0-411">テクスチャには、テクセル、つまりテクスチャ ピクセルの配列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="461d0-411">A texture contains an array of texels, or texture pixels.</span></span> <span data-ttu-id="461d0-412">各テクセルの位置は (u, v) で表されます。u が幅、v が高さで、テクスチャの幅と高さに基づいて、0 ～ 1 にマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="461d0-412">The position of each texel is denoted by (u,v), where u is the width and v is the height, and is mapped between 0 and 1 based on the texture width and height.</span></span> <span data-ttu-id="461d0-413">結果として得られるテクスチャ座標は、テクスチャをサンプリングするときに、テクセルのアドレス指定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-413">The resulting texture coordinates are used to address a texel when sampling a texture.</span></span>

<span data-ttu-id="461d0-414">テクスチャ座標が 0 未満または 1 を超える場合、テクスチャ アドレス モードは、テクスチャ座標がテクセル位置を指定する方法を定義します。</span><span class="sxs-lookup"><span data-stu-id="461d0-414">When texture coordinates are below 0 or above 1, the texture address mode defines how the texture coordinate addresses a texel location.</span></span> <span data-ttu-id="461d0-415">たとえば、__TextureAddressMode.Clamp__ を使用する場合、0 ～ 1 の範囲外の座標は、サンプリングの前に、最大値 1 および最小値 0 にクランプされます。</span><span class="sxs-lookup"><span data-stu-id="461d0-415">For example, when using __TextureAddressMode.Clamp__, any coordinate outside the 0-1 range is clamped to a maximum value of 1, and minimum value of 0 before sampling.</span></span>

<span data-ttu-id="461d0-416">テクスチャがポリゴンに対して大きすぎる場合や小さすぎる場合は、テクスチャは空間に合わせてフィルタリングされます。</span><span class="sxs-lookup"><span data-stu-id="461d0-416">If the texture is too large or too small for the polygon, the texture is filtered to fit the space.</span></span> <span data-ttu-id="461d0-417">拡大フィルターはテクスチャを拡大し、縮小フィルターは小さな領域に収まるようにテクスチャを縮小します。</span><span class="sxs-lookup"><span data-stu-id="461d0-417">A magnification filter enlarges a texture, a minification filter reduces the texture to fit into a smaller area.</span></span> <span data-ttu-id="461d0-418">テクスチャの拡大では、サンプル テクセルが 1 つまたは複数のアドレスに繰り返され、ぼやけた画像が生成されます。</span><span class="sxs-lookup"><span data-stu-id="461d0-418">Texture magnification repeats the sample texel for one or more addresses which yields a blurrier image.</span></span> <span data-ttu-id="461d0-419">テクスチャの縮小では、1 つ以上のテクセルの値が 1 つの値に結合する必要があるためより複雑です。</span><span class="sxs-lookup"><span data-stu-id="461d0-419">Texture minification is more complicated because it requires combining more than one texel value into a single value.</span></span> <span data-ttu-id="461d0-420">これによって、テクスチャ データに応じてエイリアシングやぎざぎざのエッジが発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="461d0-420">This can cause aliasing or jagged edges depending on the texture data.</span></span> <span data-ttu-id="461d0-421">縮小の最も一般的なアプローチでは、ミップマップを使用します。</span><span class="sxs-lookup"><span data-stu-id="461d0-421">The most popular approach for minification is to use a mipmap.</span></span> <span data-ttu-id="461d0-422">ミップマップは、複数レベルのテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="461d0-422">A mipmap is a multi-level texture.</span></span> <span data-ttu-id="461d0-423">各レベルのサイズは、上のレベルよりも 2 の累乗だけ小さくなり、最終的には 1 x 1 のテクスチャになります。</span><span class="sxs-lookup"><span data-stu-id="461d0-423">The size of each level is a power-of-two smaller than the previous level down to a 1x1 texture.</span></span> <span data-ttu-id="461d0-424">縮小を使用すると、ゲームはレンダリング時に必要なサイズに最も近いミップマップ レベルを選択します。</span><span class="sxs-lookup"><span data-stu-id="461d0-424">When minification is used, a game chooses the mipmap level closest to the size that is needed at render time.</span></span> 

### <a name="basicloader"></a><span data-ttu-id="461d0-425">BasicLoader</span><span class="sxs-lookup"><span data-stu-id="461d0-425">BasicLoader</span></span>

<span data-ttu-id="461d0-426">__BasicLoader__ は、ディスク上のファイルからのシェーダー、テクスチャ、メッシュの読み込みをサポートする、単純なローダー クラスです。</span><span class="sxs-lookup"><span data-stu-id="461d0-426">__BasicLoader__ is a simple loader class that provides support for loading shaders, textures, and meshes from files on disk.</span></span> <span data-ttu-id="461d0-427">同期メソッドと非同期メソッドの両方を提供します。</span><span class="sxs-lookup"><span data-stu-id="461d0-427">It provides both synchronous and asynchronous methods.</span></span> <span data-ttu-id="461d0-428">このゲーム サンプルでは、BasicLoader.h/.cpp ファイルは __Commons__ フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="461d0-428">In this game sample, the BasicLoader.h/.cpp files are found in the __Commons__ folder.</span></span>

<span data-ttu-id="461d0-429">詳細については、[BasicLoader](complete-code-for-basicloader.md) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461d0-429">For more information, see [Basic Loader](complete-code-for-basicloader.md).</span></span>