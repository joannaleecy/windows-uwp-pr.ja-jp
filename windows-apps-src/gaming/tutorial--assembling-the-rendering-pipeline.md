---
title: レンダリングの概要
description: グラフィックスを表示するレンダリング パイプラインをアセンブルする方法について説明します。 レンダリングの概要。
ms.assetid: 1da3670b-2067-576f-da50-5eba2f88b3e6
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, レンダリング
ms.localizationpriority: medium
ms.openlocfilehash: 6724aedf898706dd4c5bf728616c918d64b2fb32
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8884905"
---
# <a name="rendering-framework-i-intro-to-rendering"></a>レンダリング フレームワーク I: レンダリングの概要

これまでのトピックでは、Windows ランタイムで動作するユニバーサル Windows プラットフォーム (UWP) ゲームを構築する方法、ステート マシンを定義してゲームのフローを処理する方法について説明してきました。 ここでは、レンダリング フレームワークをアセンブルする方法について説明します。 サンプル ゲームで Direct3D11 (通常は DirectX 11 と呼ばれます) を使用してゲームのシーンをレンダリングする方法を見てみましょう。

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

Direct3D 11 には、ゲームなどのグラフィックス負荷の高いアプリケーションの 3D グラフィックスを作成するために使用できる高パフォーマンスのグラフィックス ハードウェアの高度な機能へのアクセスを提供する API のセットが含まれています。

画面上のゲームのグラフィックのレンダリングは、基本的に画面上のフレームのシーケンスのレンダリングです。 各フレームでは、ビューに基づいて、シーンに表示されているオブジェクトをレンダリングする必要があります。 

フレームをレンダリングするには、画面に表示できるように、必要なシーンの情報をハードウェアに渡す必要があります。 何かを画面に表示するには、ゲームの実行を開始すると同時にレンダリングを開始する必要があります。

## <a name="objective"></a>目標

基本的なレンダリング フレームワークを設定して、UWP DirectX ゲームのグラフィックス出力を表示する方法は、大きく次の 3 つの手順にグループ分けすることができます。

 1. グラフィックス インターフェイスへの接続を確立する
 2. グラフィックスを描画するために必要なリソースを作成する
 3. フレームをレンダリングすることによってグラフィックスを表示する

この記事では、手順 1 と 3 を取り上げて、グラフィックスをレンダリングする方法について説明します。

「[レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)」では手順 2 を取り上げて、レンダリング フレームワークを設定する方法と、レンダリングの前にデータを準備する方法について説明します。

## <a name="get-started"></a>概要

作業を開始する前に、基本的なグラフィックスとレンダリングの概念を理解しておく必要があります。 Direct3D とレンダリングを使用して初めて開発を行う場合は、この記事で使用するグラフィックスとレンダリング用語の簡単な説明については、「[用語と概念](#terms-and-concepts)」を参照してください。

このゲームでは、__GameRenderer__ クラス オブジェクトがこのサンプル ゲームのレンダラーを表します。  レンダラーは、ゲームの視覚効果を生成するために使用する、すべての Direct3D 11 オブジェクトと Direct2D オブジェクトの作成と保持を担当します。  また、レンダリングするオブジェクトのリストとヘッドアップ ディスプレイ (HUD) 用にゲームの状態を取得するために使用される __Simple3DGame__ オブジェクトへの参照も保持します。 

このチュートリアルでは、ゲームの 3D オブジェクトのレンダリングに重点を置いています。

## <a name="establish-a-connection-to-the-graphics-interface"></a>グラフィックス インターフェイスへの接続を確立する

レンダリング用のハードウェアにアクセスする方法については、UWP フレームワークの記事にある [__App::Initialize__](tutorial--building-the-games-uwp-app-framework.md#appinitialize-method) の説明を参照してください。

__make\_shared 関数__は ([以下](#appinitialize-method)に示すように) [__DX::DeviceResources__](#dxdeviceresources) への __shared\_ptr__ を作成するために使用されます。これもデバイスへのアクセスを提供します。 

Direct3D 11 では、[デバイス](#device)を使用して、オブジェクトの割り当てと破棄、プリミティブのレンダリング、グラフィックス ドライバー経由のグラフィックス カードとの通信を行います。

### <a name="appinitialize-method"></a>App::Initialize メソッド

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

## <a name="display-the-graphics-by-rendering-the-frame"></a>フレームをレンダリングすることによってグラフィックスを表示する

ゲームのシーンは、ゲームが起動したときにレンダリングされる必要があります。 レンダリングのための手順は、以下に示すように、[__GameMain::Run__](#gameamainrun-method) メソッド内で始まります。

単純なフローは次のとおりです。
1. __Update__
2. __Render__
3. __Present__

### <a name="gamemainrun-method"></a>GameMain::Run メソッド

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

### <a name="update"></a>Update

[__App::Update__ および __GameMain::Update__](tutorial-game-flow-management.md#appupdate-method) メソッドで、ゲームの状態がどのように更新される化については、「[ゲームのフロー管理](tutorial-game-flow-management.md)」の記事を参照してください。

### <a name="render"></a>Render

レンダリングは、__GameMain::Run__ で [__GameRenderer::Render__](#gamerendererrender-method) メソッドを呼び出すことによって実装されます。

[ステレオ レンダリング](#stereo-rendering) が有効な場合、右目用と左目用の 2 つのレンダリング パスがあります。 各レンダリング パスで、レンダー ターゲットと[深度ステンシル ビュー](#depth-stencil-view)をデバイスにバインドします。 後で深度ステンシル ビューをクリアします。

> [!Note]
> ステレオ レンダリングは、頂点のインスタンス化やジオメトリ シェーダーを使用する単一パス ステレオなど、他の方法で実現することもできます。 2 つのレンダリング パスを使用する方法は時間がかかりますが、ステレオ レンダリングを実現するのに便利な方法です。

ゲームが作成され、リソースが読み込まれたら、レンダリング パスごとに 1 回、[射影行列](#projection-transform-matrix)を更新します。 オブジェクトは、各ビューで若干異なります。 次に、[グラフィックス レンダリング パイプライン](#rendering-pipeline)を設定します。 

> [!Note]
> リソースを読み込む方法については、「[DirectX グラフィックス リソースの作成と読み込み](tutorial-game-rendering.md#create-and-load-directx-graphic-resources)」を参照してください。

このゲーム サンプルでは、レンダラーは、すべてのオブジェクトについて標準の頂点レイアウトを使用するように設計されています。 これにより、シェーダーの設計が簡素化され、オブジェクトのジオメトリに関係なく、シェーダー間で簡単に切り替えることができます。

#### <a name="gamerendererrender-method"></a>GameRenderer::Render メソッド

入力頂点レイアウトを使用する Direct3D コンテキストを設定します。 入力レイアウト オブジェクトは、頂点バッファー データを[レンダリング パイプライン](#rendering-pipeline)にストリーミングする方法を記述します。 

次に、以前に定義した[定数バッファー](#constant-buffers)を使用する Direct3D コンテキストを設定します。この定数バッファーは、[頂点シェーダー](#vertex-shaders-and-pixel-shaders)のパイプライン ステージと[ピクセル シェーダー](#vertex-shaders-and-pixel-shaders)のパイプライン ステージで使用されます。 

> [!Note]
> 定数バッファーの定義の詳細については、「[レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)」を参照してください。

同じ入力レイアウトと一連の定数バッファーが、パイプライン内のすべてのシェーダーで使用されるため、設定はフレームごとに 1 回です。

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

### <a name="primitive-rendering"></a>プリミティブのレンダリング

シーンをレンダリングする場合は、レンダリングする必要があるすべてのオブジェクトをループ処理します。 次の手順は、オブジェクト (プリミティブ) ごとに繰り返されます。

* モデルの[ワールド変換行列](#world-transform-matrix)とマテリアルの情報を使用して定数バッファー (__m\_constantBufferChangesEveryPrim__) を更新します。
* __m\_constantBufferChangesEveryPrim__ には、各オブジェクトのパラメーターが格納されます。  ワールド変換行列に渡されるオブジェクトや、照明の計算の色と鏡面反射指数などのマテリアルのプロパティが含まれます。
* [レンダリング パイプライン](#rendering-pipeline)の入力アセンブラー (IA) ステージにストリーミングされるメッシュ オブジェクトのデータ用に入力頂点レイアウトを使用する Direct3D コンテキストを設定します。
* IA ステージで[インデックス バッファー](#index-buffer)を使用する Direct3D コンテキストを設定します。 プリミティブの情報 (型、データの順序) を提供します。
* インデックス付きの、インスタンス化されていないプリミティブを描画する描画呼び出しを送信します。 __GameObject::Render__ メソッドは、特定のプリミティブに固有のデータでプリミティブ[定数バッファー](#constant-buffer-or-shader-constant-buffer)を更新します。 これにより、各プリミティブのジオメトリを描画するコンテキストで __DrawIndexed__ 呼び出しが行われます。 特に、この描画呼び出しは、定数バッファー データによってパラメーター化されたとおり、コマンドとデータをグラフィックス処理装置 (GPU) のキューに入れます。 各描画呼び出しは、頂点ごとに 1 回[頂点シェーダー](#vertex-shaders-and-pixel-shaders)を実行し、次にプリミティブの各三角形のピクセルごとに 1 回[ピクセル シェーダー](#vertex-shaders-and-pixel-shaders)を実行します。 テクスチャは、ピクセル シェーダーがレンダリングの実行に使う状態の一部です。

複数の定数バッファーを使用する理由は次のとおりです。
    * ゲームでは複数の定数バッファーが使われますが、これらのバッファーはプリミティブごとに 1 回更新するだけで済みます。 前述のように、定数バッファーは、プリミティブごとに実行されるシェーダーに対する入力のようなものです。 静的なデータ (__m\_constantBufferNeverChanges__) もあれば、カメラの位置のようにフレームで一定のデータ (__m\_constantBufferChangesEveryFrame__) もあれば、色やテクスチャなどのようにプリミティブに固有のデータ (__m\_constantBufferChangesEveryPrim__) もあります。
    * ゲーム [レンダラー](#renderer)はこれらの入力を別個の定数バッファーに分けて、CPU や GPU が使うメモリ帯域幅を最適化します。 この方法は、GPU が追跡する必要のあるデータ量を最小限に抑えるのにも役立ちます。 GPU にはコマンドの大きいキューがあり、ゲームが __Draw__ を呼び出すたびに、そのコマンドは関連するデータと共にキューに入れられます。 ゲームがプリミティブ定数バッファーを更新して、次の __Draw__ コマンドを発行すると、グラフィックス ドライバーはこの次のコマンドと関連するデータをキューに追加します。 ゲームで 100 のプリミティブを描画する場合、キューに定数バッファー データの 100 のコピーが存在する可能性があります。 ゲームから GPU に送るデータ量を最小限に抑えるために、ゲームでは、各プリミティブの更新情報のみを含む個別のプリミティブ定数バッファーを使用します。

#### <a name="gameobjectrender-method"></a>GameObject::Render メソッド

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

### <a name="present"></a>Present

__DX::DeviceResources::Present__ メソッドを呼び出して、配置した内容をバッファーに格納し、表示します。

ユーザーにフレームを表示するために使用されるバッファーのコレクションという意味で、スワップ チェーンという用語を使用します。 アプリケーションが表示する新しいフレームを提供するたびに、スワップ チェーンの最初のバッファーが、表示されているバッファーの場所を取得します。 このプロセスは、スワップまたはフリップと呼ばれます。 詳しくは、「[スワップ チェーン](../graphics-concepts/swap-chains.md)」をご覧ください。

* __IDXGISwapChain1__ インターフェイスの __Present__ メソッドは、[DXGI](#dxgi) に対して垂直同期 (VSync) までブロックするよう指示し、アプリケーションを次の VSync までスリープ状態にします。 これによって、画面に表示されないフレームのレンダリングによるサイクルの無駄をなくします。
* __ID3D11DeviceContext3__ インターフェイスの __DiscardView__ メソッドは、[レンダー ターゲット](#render-target)の内容を破棄します。 これは、既存の内容が完全に上書きされる場合にのみ有効な操作です。 dirty rect や scroll rect を使用する場合は、この呼び出しを削除してください。
* 同じ __DiscardView__ メソッドを使用して、[深度/ステンシル](#depth-stencil)の内容を破棄します。
* [デバイス](#device)が削除される場合は、__HandleDeviceLost__ メソッドを使用してシナリオを管理します。 切断またはドライバーのアップグレードによってデバイスが削除された場合は、すべてのデバイス リソースを作成し直す必要があります。 詳細については、「[Direct3D 11 でのデバイス削除シナリオの処理](handling-device-lost-scenarios.md)」を参照してください。

> [!Tip]
> 滑らかなフレーム レートを実現するには、フレームのレンダリングの作業量が、VSync 間の時間に収まることを確認する必要があります。

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

## <a name="next-steps"></a>次の手順

この記事では、ディスプレイにグラフィックスをレンダリングする方法を説明し、使用されるレンダリング用語の一部について簡単に説明しました。 「[レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)」では、レンダリングの詳細や、レンダリングする前に必要なデータを準備する方法について説明します。

## <a name="terms-and-concepts"></a>用語と概念

### <a name="simple-game-scene"></a>シンプルなゲームのシーン

シンプルなゲームのシーンは、数個のオブジェクトといくつかの光源で構成されます。

オブジェクトのシェイプは、空間の一連の X、Y、Z 座標で定義されます。 ゲーム ワールド内の実際のレンダリングの位置は、位置の X、Y、Z 座標に変換行列を適用することで決定できます。 一連のテクスチャ座標 (マテリアルをオブジェクトに適用する方法を指定する U と V) が含まれる場合もあります。 これはオブジェクトのサーフェスのプロパティを定義し、これを使ってオブジェクトがテニス ボールのような粗いサーフェスを持つのか、ボーリングの球のように滑らかな光沢のあるサーフェスを持つのかを確認できます。

シーンとオブジェクトの情報は、レンダリング フレームワークでフレームごとにシーンを再作成し、シーンをディスプレイ モニターに表示するために使用されます。

### <a name="rendering-pipeline"></a>レンダリング パイプライン

レンダリング パイプラインは、3D シーンの情報が画面に表示される画像に変換されるプロセスです。 Direct3D 11 では、このパイプラインはプログラミング可能です。 レンダリングのニーズをサポートするために、ステージを適合させることができます。 一般的なシェーダー コアの機能を利用するステージは、HLSL プログラミング言語を使用することによってプログラミングできます。 これは、グラフィックス レンダリング パイプラインまたは単にパイプラインとも呼ばれます。

このパイプラインを作成するには、以下についての知識が必要です。
* [HLSL](#HLSL)。 UWP DirectX ゲームでは、HLSL シェーダー モデル 5.1 以上を使用することをお勧めします。
* [シェーダー](#Shaders)
* [頂点シェーダーとピクセル シェーダー](#vertext-shaders-pixel-shaders)
* [シェーダー ステージ](#shader-stages)
* [さまざまなシェーダー ファイル形式](#various-shader-file-formats)

詳細については、[Direct3D 11 のレンダリング パイプラインに関するページ](https://msdn.microsoft.com/library/windows/desktop/dn643746.aspx)と[グラフィックス パイプラインに関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476882.aspx)を参照してください。

#### <a name="hlsl"></a>HLSL

HLSL は、DirectX 用の上位レベル シェーダー言語です。 HLSL を使用して、Direct3D パイプライン用の C に似たプログラミング可能なシェーダーを作成できます。 詳しくは、「[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561.aspx)」をご覧ください。

#### <a name="shaders"></a>シェーダー

シェーダーは、レンダリングするときのオブジェクトのサーフェスの表示方法を決定する命令のセットと考えることができます。 HLSL を使用してプログラミングされるシェーダーは、HLSL シェーダーと呼ばれます。 [HLSL])(#hlsl) シェーダーのソース コード ファイルには、.hlsl というファイル拡張子が付きます。 これらのシェーダーは、作成時または実行時にコンパイルでき、実行時に適切なパイプライン ステージに設定できます。コンパイルされたシェーダー オブジェクトには、.cso というファイル拡張子が付きます。

Direct3D 9 シェーダーは、シェーダー モデル 1、シェーダー モデル 2、シェーダー モデル 3 を使用して設計できます。Direct3D 10 シェーダーは、シェーダー モデル 4 でのみ設計できます。 Direct3D 11 シェーダーは、シェーダー モデル 5 で設計できます。 Direct3D 11.3 および Direct3D 12 シェーダーは、シェーダー モデル 5.1 で設計できます。Direct3D 12 シェーダーは、シェーダー モデル 6 でも設計できます。

#### <a name="vertex-shaders-and-pixel-shaders"></a>頂点シェーダーとピクセル シェーダー

データは、プリミティブのストリームとしてグラフィックス パイプラインに入り、頂点シェーダーやピクセル シェーダーなどさまざまなシェーダーによって処理されます。 

頂点シェーダーは、通常、変換、スキン、照明の適用などの操作を実行することによって、頂点を処理します。  ピクセル シェーダーは、ピクセル単位の照明や後処理など、豊富なシェーディング手法を実現します。 ピクセル シェーダーは、定数変数、テクスチャ データ、補間された頂点単位の値などのデータを組み合わせて、ピクセル単位の出力を生成します。 

#### <a name="shader-stages"></a>シェーダー ステージ

このプリミティブのストリームを処理するために定義されたさまざまなシェーダーのシーケンスは、レンダリング パイプラインのシェーダー ステージと呼ばれます。 実際のステージは、Direct3D のバージョンによって異なりますが、通常は、頂点、ジオメトリ、ピクセルのステージが含まれます。 テセレーション用のハル シェーダーやドメイン シェーダー、計算シェーダーなど、他のステージもあります。 これらステージはすべて、[HLSL])(#hlsl) を使用して完全にプログラミングできます。 詳細については、[グラフィックス パイプラインに関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476882.aspx)を参照してください。

#### <a name="various-shader-file-formats"></a>さまざまなシェーダー ファイル形式

シェーダー コード ファイルの拡張子は次のとおりです。
    * .hlsl という拡張子を持つファイルは、[HLSL])(#hlsl) ソース コードを保持します。
    * .cso という拡張子を持つファイルは、コンパイル済みシェーダー オブジェクトを保持します。
    * .h という拡張子を持つファイルはヘッダー ファイルですが、シェーダー コードのコンテキストでは、このヘッダー ファイルはシェーダー データを保持するバイト配列を定義します。
    * .hlsli という拡張子を持つファイルは、定数バッファーの形式を格納します。 ゲーム サンプルでは、このファイルは __Shaders__>__ConstantBuffers.hlsli__ です。

> [!Note]
> シェーダーを埋め込むには、実行時に .cso ファイルを読み込むか、または実行可能コードに .h ファイルを追加します。 ただし、同じシェーダーで両方を使用しないでください。

### <a name="deeper-understanding-of-directx"></a>DirectX に関する高度な知識

Direct3D 11 は、ゲームなどのグラフィックスを多用するアプリケーションのグラフィックスを作成するのに役立つ一連の API です。このようなアプリケーションでは、負荷の高い計算を処理するために優れたグラフィックス カードを使用します。 このセクションでは、Direct3D 11 グラフィックス プログラミングの概念 (リソース、サブリソース、デバイス、デバイス コンテキスト) について簡単に説明します。

#### <a name="resource"></a>リソース

グラフィックス プログラミングに関する経験が浅い場合は、リソース (デバイス リソースとも呼ばれる) は、テクスチャ、位置、色など、オブジェクトをレンダリングする方法に関する情報と考えてもかまいません。 リソースは、パイプラインにデータを提供し、シーン内でレンダリングされる対象を定義します。 リソースは、ゲーム メディアから読み込むことも、実行時に動的に作成することもできます。

リソースは、実際には、Direct3D [パイプライン](#rendering-pipeline)からアクセスできるメモリ内の領域です。 パイプラインでメモリに効率的にアクセスするには、パイプラインに渡すデータ (入力ジオメトリ、シェーダー リソース、テクスチャなど) をリソースに格納する必要があります。 すべての Direct3D リソースの派生元となるリソースは 2 種類あります。バッファーとテクスチャです。 各パイプライン ステージでは最大 128 個のリソースをアクティブにできます。 詳しくは、「[リソース](../graphics-concepts/resources.md)」をご覧ください。

#### <a name="subresource"></a>サブリソース

サブリソースという用語はリソースのサブセットを指します。 Direct3D は、リソース全体を参照することも、リソースのサブセットを参照することもできます。 詳しくは、「[サブリソース](../graphics-concepts/resource-types.md#subresources)」をご覧ください。

#### <a name="depth-stencil"></a>深度/ステンシル

深度/ステンシル リソースには、深度とステンシルの情報を保持するための形式とバッファーが含まれます。 このリソースは、テクスチャー リソースを使用して作成されます。 深度/ステンシル リソースを作成する方法について詳しくは、「[深度/ステンシル機能の構成](https://msdn.microsoft.com/library/windows/desktop/bb205074.aspx)」を参照してください。 深度/ステンシル リソースにアクセスするには、[ID3D11DepthStencilView](https://msdn.microsoft.com/library/windows/desktop/ff476377.aspx) インターフェイスを使って実装される深度/ステンシル ビュー使用します。

深度情報は、ビューから隠すのではなくレンダリングする多角形の領域を示します。 ステンシル情報は、マスクするピクセルを示します。 ステンシル情報は、ピクセルを描画するかどうかを決定する (ビットを 1 または 0 に設定する) ため、特殊効果を生成するために使用できます。 

詳細については、「[深度ステンシル ビュー](../graphics-concepts/depth-stencil-view--dsv-.md)」、「[深度バッファー](../graphics-concepts/depth-buffers.md)」、「[ステンシル バッファー](../graphics-concepts/stencil-buffers.md)」を参照してください。

#### <a name="render-target"></a>レンダー ターゲット

レンダー ターゲットは、レンダリング パスの最後に書き込むことができるリソースです。 通常、[ID3D11Device::CreateRenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476517.aspx) メソッドで、入力パラメーターとしてスワップ チェーン バック バッファー (これもリソースです) を使用して作成されます。 

各レンダー ターゲットには、対応する深度/ステンシル ビューも必要です。これは、レンダー ターゲットを使用する前に、[OMSetRenderTargets](https://msdn.microsoft.com/library/windows/desktop/ff476464.aspx) を使用してレンダー ターゲットを設定するときに、深度/ステンシル ビューも必要となるためです。 レンダー ターゲット リソースにアクセスするには、[ID3D11RenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476582.aspx) インターフェイスを使用して実装されるレンダー ターゲット ビューを使用します。 

#### <a name="device"></a>デバイス

Direct3D 11 の使用経験が浅い場合は、デバイスは、オブジェクトの割り当てと破棄、プリミティブのレンダリング、グラフィックス ドライバー経由のグラフィックス カードとの通信を行うための方法であると考えることができます。 

より正確に説明すると、Direct3D デバイスは Direct3D のレンダリング コンポーネントです。 デバイスは、レンダリングの状態をカプセル化して格納します。また、変換や照明の操作、サーフェスへのイメージのラスタライズを実行します。 詳しくは、「[デバイス](../graphics-concepts/devices.md)」をご覧ください。

デバイスは、[ID3D11Device](https://msdn.microsoft.com/library/windows/desktop/ff476379.aspx) インターフェイスによって表されます。 つまり、ID3D11Device インターフェイスは仮想ディスプレイ アダプターを表し、デバイスによって所有されるリソースを作成するために使用します。 

ID3D11Device には複数のバージョンがあり、[ID3D11Device5](https://msdn.microsoft.com/library/windows/desktop/mt492478.aspx) が最新バージョンで、ID3D11Device4 に新しいメソッドが追加されています。 Direct3D が基になるハードウェアと通信する方法の詳細については、[Windows Device Driver Model (WDDM) アーキテクチャに関するページ](https://docs.microsoft.com/windows-hardware/drivers/display/windows-vista-and-later-display-driver-model-architecture)を参照してください。

各アプリケーションには少なくとも 1 つのデバイスが必要であり、ほとんどのアプリケーションは 1 つだけデバイスを作成します。 コンピューターにインストールされているいずれかのハードウェア ドライバーについてデバイスを作成するには、__D3D11CreateDevice__ または __D3D11CreateDeviceAndSwapChain__ を呼び出して、D3D\_DRIVER\_TYPE フラグでドライバーの種類を指定します。 各デバイスでは、必要な機能に応じて、1 つまたは複数のデバイス コンテキストを使用できます。 詳細については、[D3D11CreateDevice 関数に関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476082.aspx)を参照してください。

#### <a name="device-context"></a>デバイス コンテキスト

デバイス コンテキストは、[パイプライン](#rendering-pipeline)の状態を設定し、[デバイス](#device)によって所有される[リソース](#resource)を使用してレンダリング コマンドを生成するために使用されます。 

Direct3D 11 は 2 種類のデバイス コンテキストを実装します。1 つは即時レンダリング用で、もう 1 つは遅延レンダリング用です。いずれのコンテキストも [ID3D11DeviceContext](https://msdn.microsoft.com/library/windows/desktop/ff476385.aspx) インターフェイスを使用して表されます。  

__ID3D11DeviceContext__ インターフェイスには複数のバージョンがあり、__ID3D11DeviceContext4__ は __ID3D11DeviceContext3__ に新しいメソッドを追加します。

注: __ID3D11DeviceContext4__ は Windows 10 Creators Update で導入され、__ID3D11DeviceContext__ インターフェイスの最新バージョンです。 Windows 10 Creators Update を対象とするアプリケーションでは、以前のバージョンではなく、このインターフェイスを使用する必要があります。 詳しくは、[ID3D11DeviceContext4 に関するページ](https://msdn.microsoft.com/library/windows/desktop/mt492481.aspx)を参照してください。

#### <a name="dxdeviceresources"></a>DX::DeviceResources

__DX::DeviceResources__ クラスは、__DeviceResources.cpp__/__.h__ ファイルに含まれており、すべての DirectX デバイス リソースを制御します。 サンプル ゲーム プロジェクトおよび DirectX 11 アプリ テンプレート プロジェクトでは、これらのファイルは __Commons__ フォルダーにあります。 Visual Studio 2015 以降で、新しい DirectX 11 アプリ テンプレート プロジェクトを作成するときに、これらのファイルの最新バージョンを取り込むことができます。

### <a name="buffer"></a>バッファー

バッファー リソースは完全に型指定されたデータのコレクションであり、複数の要素にグループ化されます。 バッファーを使用して、さまざまなデータを格納できます。たとえば、位置ベクトル、法線ベクトル、頂点バッファー内のテクスチャ座標、インデックス バッファー内のインデックス、デバイスの状態などのデータが格納されます。 バッファー要素には、圧縮済みデータ値 (R8G8B8A8 サーフェス値)、単一の 8 ビット整数、または 4 つの 32 ビット浮動小数点値を含めることができます。

利用可能なバッファーには、頂点バッファー、インデックス バッファー、定数バッファーの 3 つの種類があります。

#### <a name="vertex-buffer"></a>頂点バッファー

ジオメトリの定義に使われる頂点データが格納されます。 頂点データには、位置座標、色データ、テクスチャ座標データ、法線データなどが含まれます。 

#### <a name="index-buffer"></a>インデックス バッファー

頂点バッファーへの整数オフセットが格納されます。このバッファーは、より効率的なプリミティブのレンダリングに使われます。 インデックス バッファーは 16 ビットまたは 32 ビットの連続するインデックスを格納します。各インデックスは頂点バッファーの頂点を識別するのに使用されます。

#### <a name="constant-buffer-or-shader-constant-buffer"></a>定数バッファーまたはシェーダー定数バッファー

シェーダー データをパイプラインに効率的に提供できます。 定数バッファーは、各プリミティブについて実行され、レンダリング パイプラインのストリーム出力ステージの結果を格納するシェーダーの入力として使用できます。 定数バッファーは、概念的には要素が 1 つの頂点バッファーに似ています。

#### <a name="design-and-implementation-of-buffers"></a>バッファーの設計と実装

バッファーはデータ型に基づいて設計できます。たとえば、ゲームのサンプルでは、静的データ用に 1 つのバッファー、フレームで一定のデータ用に別のバッファー、プリミティブに固有のデータ用にまた別のバッファーを作成します。

すべてのバッファーの種類は __ID3D11Buffer__ インターフェイスによってカプセル化され、__ID3D11Device::CreateBuffer__ を呼び出すことによってバッファー リソースを作成できます。 ただし、バッファーにアクセスするには、その前にバッファーがパイプラインにバインドされている必要があります。 バッファーは、読み取りのために同時に複数のパイプライン ステージにバインドできます。 バッファーは、書き込みのために単一のパイプライン ステージにバインドすることもできます。ただし、同じバッファーを読み取りと書き込みのために同時にバインドすることはできません。

次のようなステージにバッファーをバインドします。
    * 入力アセンブラー ステージ。そのためには、__ID3D11DeviceContext__ の __ID3D11DeviceContext::IASetVertexBuffers__ メソッドや __ID3D11DeviceContext::IASetIndexBuffer__ メソッドを呼び出します。
    * ストリーム出力ステージ。そのためには、__ID3D11DeviceContext::SOSetTargets__ を呼び出します。
    * シェーダー ステージ。そのためには、__ID3D11DeviceContext::VSSetConstantBuffers__ などのシェーダー メソッドを呼び出します。

詳しくは、「[Direct3D 11 のバッファーについて](https://msdn.microsoft.com/library/windows/desktop/ff476898.aspx)」をご覧ください。

### <a name="dxgi"></a>DXGI

Microsoft DirectX グラフィックス インフラストラクチャ (DXGI) は、direct3d10 で必要とされる低レベルのタスクの一部をカプセル化 WindowsVista で導入された新しいサブシステム 10.1、11、11.1 します。 マルチスレッド アプリケーションで DXGI を使用する場合、デッドロックが発生しないように特に注意する必要があります。 詳細については、[DirectX グラフィックス インフラストラクチャ (DXGI): ベスト プラクティスのマルチスレッドに関する説明](https://msdn.microsoft.com/library/windows/desktop/ee417025.aspx#multithreading_and_dxgi)を参照してください。

### <a name="feature-level"></a>機能レベル

機能レベルは、最新または既存のコンピューターで多様なビデオ カードを処理するために、Direct3D 11 で導入された概念です。 機能レベルは、明確に定義されたグラフィックス処理装置 (GPU) 機能のセットです。 

各ビデオ カードは、インストールされている GPU に応じて、特定のレベルの DirectX の機能を実装します。 以前のバージョンの Microsoft Direct3D では、ビデオ カードが実装しているバージョンを検出し、それに応じてアプリケーションをプログラミングすることができました。 

機能レベルを使用すると、デバイスを作成するときに、必要な機能レベルのデバイスを作成してみることができます。 デバイスの作成に成功した場合は、その機能レベルが存在します。失敗した場合は、ハードウェアはその機能レベルをサポートしていません。 低い機能レベルでデバイスを再作成してみることも、アプリケーションの終了を選択することもできます。 たとえば、12\_0 機能レベルでは、Direct3D 11.3 や Direct3D 12、およびシェーダー モデル 5.1 が必要です。 詳細については、[Direct3D の各機能レベルの概要に関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476876.aspx#Overview)を参照してください。

機能レベルを使用して、Direct3D9 や Microsoft Direct3D10、Direct3D11 では、アプリケーションを開発し、9、10 または 11 のハードウェア (一部例外あり) で実行できます。 詳細については、[Direct3D の機能レベルに関するページ](https://msdn.microsoft.com/library/windows/desktop/ff476876.aspx)を参照してください。

### <a name="stereo-rendering"></a>ステレオ レンダリング

ステレオ レンダリングは奥行き感を強化するために使用されます。 左目の視点から画像と右目の視点からの画像の 2 つの画像を使用して、ディスプレイの画面にシーンを表示します。 

数学的には、ステレオ射影行列を適用することによってこれを実現します。ステレオ射影行列は、通常のモノラル射影行列を水平方向にわずかに右および左にオフセットしたものです。

このゲーム サンプルでは、ステレオ レンダリングを実現するために、次の 2 つのレンダリング パスを実行しました。
* 右側のレンダー ターゲットにバインドし、右の射影を適用したのち、プリミティブ オブジェクトを描画します。
* 左側のレンダー ターゲットにバインドし、左の射影を適用したのち、プリミティブ オブジェクトを描画します。

### <a name="camera-and-coordinate-space"></a>カメラと座標空間

ゲームには、独自の座標系でワールドを更新するためのコードがあります (ワールド空間またはシーン空間と呼ばれることもあります)。 カメラを含むすべてのオブジェクトはこの空間に配置されます。 詳細については、「[座標系](../graphics-concepts/coordinate-systems.md)」を参照してください。

頂点シェーダーは、次のアルゴリズムを使って (V はベクター、M は行列を表す) モデル座標からデバイス座標への変換を行います。

V(device) = V(model) x M(model-to-world) x M(world-to-view) x M(view-to-device)。

この場合 
* M(model-to-world) はモデル座標からワールド座標への変換行列であり、[ワールド変換行列](#world-transform-matrix)とも呼ばれます。 これは、プリミティブによって提供されます。
* M(world-to-view) はワールド座標からビュー座標への変換行列であり、[ビュー変換行列](#view-transform-matrix)とも呼ばれます。
    * これは、カメラのビュー行列によって提供されます。 これは、カメラの位置とルック ベクター (カメラからシーンを直接ポイントする "ルック アット" ベクターとシーンに対して垂直かつ上向きの "ルック アップ" ベクター) によって定義されます。
    * サンプル ゲームでは、__m\_viewMatrix__ はビュー変換行列であり、__Camera::SetViewParams__ を使用して計算されます。 
* M(view-to-device) はビュー座標からデバイス座標への変換行列であり、[射影変換行列](#projection-transform-matrix)とも呼ばれます。
    * これは、カメラの射影によって提供されます。 その空間のどれくらいの量が実際に最終的なシーンに表示されるかについての情報を提供します。 視野 (FoV)、縦横比、クリッピング面によって、射影変換行列が定義されます。
    * サンプル ゲームでは、__m\_projectionMatrix__ は、__Camera::SetProjParams__ を使用して計算された、射影座標への変換を定義します (ステレオ射影の場合は、それぞれの目のビューに 1 つずつ、2 つの射影行列を使用します)。 

VertexShader.hlsl のシェーダー コードがこれらのベクターや行列と共に定数バッファーから読み込まれ、各頂点に対してこの変換を実行します。

### <a name="coordinate-transformation"></a>座標変換

Direct3D では、3 つの変換を使用して 3D モデル座標をピクセル座標 (スクリーン空間) に変更します。 これらの変換は、ワールド変換、ビュー変換、射影変換です。 詳細については、「[変換の概要](../graphics-concepts/transform-overview.md)」を参照してください。

#### <a name="world-transform-matrix"></a>ワールド変換行列

ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。ワールド空間では、頂点はシーン内のすべてのオブジェクトに共通の原点を基準として相対的に定義されます。 基本的に、ワールド変換はモデルをワールド空間に配置します。そのため、このように呼ばれます。 詳細については、「[ワールド変換](../graphics-concepts/world-transform.md)」を参照してください。

####  <a name="view-transform-matrix"></a>ビュー変換行列

ビュー変換は、ビューアーをワールド空間に配置し、頂点をカメラ空間に変換します。 カメラ空間では、カメラつまりビューアーは原点に位置し、Z 軸の正方向を向いています。 詳細については、「[ビュー変換](../graphics-concepts/view-transform.md)」を参照してください。

####  <a name="projection-transform-matrix"></a>射影変換行列

射影変換では、視錐台を立方体に変換します。 視錐台とは、ビューポートのカメラに対して相対的に配置された、シーン内の 3D ボリュームです。 ビューポートとは、3D シーンが投影される 2D の四角形です。 詳細については、「[ビューポートとクリッピング](../graphics-concepts/viewports-and-clipping.md)」を参照してください。

視錐台の近くの端は遠くの端よりも小さいので、このトランスフォームにはカメラの近くのオブジェクトを拡大するという効果があり、これによってシーンに遠近感が生まれます。 したがって、プレイヤーに近いオブジェクトは大きく表示され、遠くにあるオブジェクトは小さく表示されます。

数学的には、射影変換は、通常、スケーリングおよび遠近法の両方の行列です。 カメラのレンズと同様に機能します。 詳細については、「[射影変換](../graphics-concepts/projection-transform.md)」を参照してください。

### <a name="sampler-state"></a>サンプラーの状態

サンプラーの状態は、テクスチャのアドレス指定モード、フィルター、詳細レベルを使用して、テクスチャ データをサンプリングする方法を決定します。 サンプリングは、テクスチャ ピクセル、つまりテクセルがテクスチャから読み取られるたびに実行されます。

テクスチャには、テクセル、つまりテクスチャ ピクセルの配列が含まれています。 各テクセルの位置は (u, v) で表されます。u が幅、v が高さで、テクスチャの幅と高さに基づいて、0 ～ 1 にマッピングされます。 結果として得られるテクスチャ座標は、テクスチャをサンプリングするときに、テクセルのアドレス指定に使用されます。

テクスチャ座標が 0 未満または 1 を超える場合、テクスチャ アドレス モードは、テクスチャ座標がテクセル位置を指定する方法を定義します。 たとえば、__TextureAddressMode.Clamp__ を使用する場合、0 ～ 1 の範囲外の座標は、サンプリングの前に、最大値 1 および最小値 0 にクランプされます。

テクスチャがポリゴンに対して大きすぎる場合や小さすぎる場合は、テクスチャは空間に合わせてフィルタリングされます。 拡大フィルターはテクスチャを拡大し、縮小フィルターは小さな領域に収まるようにテクスチャを縮小します。 テクスチャの拡大では、サンプル テクセルが 1 つまたは複数のアドレスに繰り返され、ぼやけた画像が生成されます。 テクスチャの縮小では、1 つ以上のテクセルの値が 1 つの値に結合する必要があるためより複雑です。 これによって、テクスチャ データに応じてエイリアシングやぎざぎざのエッジが発生する場合があります。 縮小の最も一般的なアプローチでは、ミップマップを使用します。 ミップマップは、複数レベルのテクスチャです。 各レベルのサイズは、上のレベルよりも 2 の累乗だけ小さくなり、最終的には 1 x 1 のテクスチャになります。 縮小を使用すると、ゲームはレンダリング時に必要なサイズに最も近いミップマップ レベルを選択します。 

### <a name="basicloader"></a>BasicLoader

__BasicLoader__ は、ディスク上のファイルからのシェーダー、テクスチャ、メッシュの読み込みをサポートする、単純なローダー クラスです。 同期メソッドと非同期メソッドの両方を提供します。 このゲーム サンプルでは、BasicLoader.h/.cpp ファイルは __Commons__ フォルダーにあります。

詳細については、[BasicLoader](complete-code-for-basicloader.md) を参照してください。