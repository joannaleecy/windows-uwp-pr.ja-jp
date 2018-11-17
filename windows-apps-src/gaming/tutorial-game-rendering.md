---
author: joannaleecy
title: セットアップ
description: グラフィックスを表示するレンダリング パイプラインをアセンブルする方法について説明します。 ゲームのレンダリング、データのセットアップと準備。
ms.assetid: 7720ac98-9662-4cf3-89c5-7ff81896364a
ms.author: joanlee
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, レンダリング
ms.localizationpriority: medium
ms.openlocfilehash: 134c9005a796f52fb61ba628c0a85c8dbd875442
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7172878"
---
# <a name="rendering-framework-ii-game-rendering"></a><span data-ttu-id="703b6-105">レンダリング フレームワーク II: ゲームのレンダリング</span><span class="sxs-lookup"><span data-stu-id="703b6-105">Rendering framework II: Game rendering</span></span>

<span data-ttu-id="703b6-106">「[レンダリング フレームワーク I](tutorial--assembling-the-rendering-pipeline.md)」では、シーン情報を取得し、ディスプレイの画面に表示する方法を説明しました。</span><span class="sxs-lookup"><span data-stu-id="703b6-106">In [Rendering framework I](tutorial--assembling-the-rendering-pipeline.md), we've covered how we take the scene info and present it to the display screen.</span></span> <span data-ttu-id="703b6-107">ここでは、一歩戻って、レンダリングのためのデータを準備する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="703b6-107">Now, we'll take a step back and learn how to prepare the data for rendering.</span></span>

>[!Note]
><span data-ttu-id="703b6-108">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="703b6-108">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="703b6-109">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="703b6-109">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="703b6-110">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="703b6-110">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="objective"></a><span data-ttu-id="703b6-111">目標</span><span class="sxs-lookup"><span data-stu-id="703b6-111">Objective</span></span>

<span data-ttu-id="703b6-112">目標について簡単に要約します。</span><span class="sxs-lookup"><span data-stu-id="703b6-112">Quick recap on the objective.</span></span> <span data-ttu-id="703b6-113">基本的なレンダリング フレームワークを設定して、UWP DirectX ゲームのグラフィックス出力を表示する方法を理解することです。</span><span class="sxs-lookup"><span data-stu-id="703b6-113">It is to understand how to set up a basic rendering framework to display the graphics output for a UWP DirectX game.</span></span> <span data-ttu-id="703b6-114">これらはおおまかに 3 つの手順にグループ分けすることができます。</span><span class="sxs-lookup"><span data-stu-id="703b6-114">We can loosely group them into these three steps.</span></span>

 1. <span data-ttu-id="703b6-115">グラフィックス インターフェイスへの接続を確立する</span><span class="sxs-lookup"><span data-stu-id="703b6-115">Establish a connection to our graphics interface</span></span>
 2. <span data-ttu-id="703b6-116">準備: グラフィックスを描画するために必要なリソースを作成する</span><span class="sxs-lookup"><span data-stu-id="703b6-116">Preparation: Create the resources we need to draw the graphics</span></span>
 3. <span data-ttu-id="703b6-117">グラフィックの表示: フレームをレンダリングする</span><span class="sxs-lookup"><span data-stu-id="703b6-117">Display the graphics: Render the frame</span></span>

<span data-ttu-id="703b6-118">「[レンダリング フレームワーク I: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)」では、手順 1 と 3 を含む、グラフィックスをレンダリングする方法について説明しました。</span><span class="sxs-lookup"><span data-stu-id="703b6-118">[Rendering framework I: Intro to rendering](tutorial--assembling-the-rendering-pipeline.md) explained how graphics are rendered, covering Steps 1 and 3.</span></span> 

<span data-ttu-id="703b6-119">この記事では、このフレームワークの他の部分を設定し、レンダリングの前に必要なデータを準備する方法 (プロセスの手順 2 に相当) について説明します。</span><span class="sxs-lookup"><span data-stu-id="703b6-119">This article explains how to set up other pieces of this framework and prepare the required data before rendering can happen, which is Step 2 of the process.</span></span>

## <a name="design-the-renderer"></a><span data-ttu-id="703b6-120">レンダラーの設計</span><span class="sxs-lookup"><span data-stu-id="703b6-120">Design the renderer</span></span>

<span data-ttu-id="703b6-121">レンダラーは、ゲームの視覚効果を生成するために使用する、すべての D3D11 オブジェクトと D2D オブジェクトの作成と保守を担当します。</span><span class="sxs-lookup"><span data-stu-id="703b6-121">The renderer is responsible for creating and maintaining all the D3D11 and D2D objects used to generate the game visuals.</span></span> <span data-ttu-id="703b6-122">__GameRenderer__ クラスは、このサンプル ゲームのレンダラーであり、し、ゲームのレンダリングのニーズに合わせて設計されています。</span><span class="sxs-lookup"><span data-stu-id="703b6-122">The __GameRenderer__ class is the renderer for this sample game and is designed to meet the game's rendering needs.</span></span>

<span data-ttu-id="703b6-123">ゲームのレンダラーを設計する際に役立ついくつかの概念を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="703b6-123">These are some concepts you can use to help design the renderer for your game:</span></span>
* <span data-ttu-id="703b6-124">Direct3D 11 API は [COM](https://msdn.microsoft.com/library/windows/desktop/ms694363.aspx) API として定義されるため、これらの API で定義されたオブジェクトへの [ComPtr](https://docs.microsoft.com/cpp/windows/comptr-class) 参照を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="703b6-124">Because Direct3D 11 APIs are defined as [COM](https://msdn.microsoft.com/library/windows/desktop/ms694363.aspx) APIs, you must provide [ComPtr](https://docs.microsoft.com/cpp/windows/comptr-class) references to the objects defined by these APIs.</span></span> <span data-ttu-id="703b6-125">これらのオブジェクトは、アプリ終了時に最後の参照がスコープ外になったときに自動的に解放されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-125">These objects are automatically freed when their last reference goes out of scope when the app terminates.</span></span> <span data-ttu-id="703b6-126">詳細については、「[ComPtr](https://github.com/Microsoft/DirectXTK/wiki/ComPtr)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="703b6-126">For more information, see [ComPtr](https://github.com/Microsoft/DirectXTK/wiki/ComPtr).</span></span> <span data-ttu-id="703b6-127">このようなオブジェクトの例として、定数バッファー、シェーダー オブジェクト ([頂点シェーダー](tutorial--assembling-the-rendering-pipeline.md#vertex-shaders-and-pixel-shaders)、[ピクセル シェーダー](tutorial--assembling-the-rendering-pipeline.md#vertex-shaders-and-pixel-shaders))、シェーダー リソース オブジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="703b6-127">Example of these objects: constant buffers, shader objects - [vertex shader](tutorial--assembling-the-rendering-pipeline.md#vertex-shaders-and-pixel-shaders), [pixel shader](tutorial--assembling-the-rendering-pipeline.md#vertex-shaders-and-pixel-shaders), and shader resource objects.</span></span>
* <span data-ttu-id="703b6-128">定数バッファーは、レンダリングに必要なさまざまなデータを保持するために、このクラスで定義されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-128">Constant buffers are defined in this class to hold various data needed for rendering.</span></span>
    * <span data-ttu-id="703b6-129">GPU に送信するデータの 1 フレームあたりの量を減らすために、更新頻度の異なる複数の定数バッファーを使用します。</span><span class="sxs-lookup"><span data-stu-id="703b6-129">Use multiple constant buffers with different frequencies to reduce the amount of data that must be sent to the GPU per frame.</span></span> <span data-ttu-id="703b6-130">このサンプルでは、更新する必要のある頻度に基づいて定数を異なるバッファーに分けています。</span><span class="sxs-lookup"><span data-stu-id="703b6-130">This sample separates constants into different buffers based on the frequency that they must be updated.</span></span> <span data-ttu-id="703b6-131">Direct3D プログラミングでは、このような処理をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="703b6-131">This is a best practice for Direct3D programming.</span></span> 
    * <span data-ttu-id="703b6-132">このゲームのサンプルでは、4 つの定数バッファーを定義します。</span><span class="sxs-lookup"><span data-stu-id="703b6-132">In this game sample, 4 constant buffers are defined.</span></span>
        1. <span data-ttu-id="703b6-133">__m\_constantBufferNeverChanges__ には照明パラメーターが含まれます。</span><span class="sxs-lookup"><span data-stu-id="703b6-133">__m\_constantBufferNeverChanges__ contains the lighting parameters.</span></span> <span data-ttu-id="703b6-134">これは、__FinalizeCreateGameDeviceResources__ メソッドで一度設定されると、再び変更されることはありません。</span><span class="sxs-lookup"><span data-stu-id="703b6-134">It's set one time in the __FinalizeCreateGameDeviceResources__ method and never changes again.</span></span>
        2. <span data-ttu-id="703b6-135">__m\_constantBufferChangeOnResize__ にはプロジェクション マトリックスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="703b6-135">__m\_constantBufferChangeOnResize__ contains the projection matrix.</span></span> <span data-ttu-id="703b6-136">プロジェクション マトリックスは、ウィンドウのサイズと縦横比に依存します。</span><span class="sxs-lookup"><span data-stu-id="703b6-136">The projection matrix is dependent on the size and aspect ratio of the window.</span></span> <span data-ttu-id="703b6-137">これは、[__CreateWindowSizeDependentResources__](#createwindowsizedependentresources-method) で設定され、[__FinalizeCreateGameDeviceResources__](#finalizecreategamedeviceresources-method) メソッドでリソースが読み込まれた後で更新されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-137">It's set in [__CreateWindowSizeDependentResources__](#createwindowsizedependentresources-method) and then updated after resources are loaded in the [__FinalizeCreateGameDeviceResources__](#finalizecreategamedeviceresources-method) method.</span></span> <span data-ttu-id="703b6-138">3D でレンダリングする場合は、フレームごとに 2 回変更されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-138">If rendering in 3D, it is also changed twice per frame.</span></span>
        3. <span data-ttu-id="703b6-139">__m\_constantBufferChangesEveryFrame__ にはビュー マトリックスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="703b6-139">__m\_constantBufferChangesEveryFrame__ contains the view matrix.</span></span> <span data-ttu-id="703b6-140">このマトリックスは、カメラ位置とルック方向 (標準はプロジェクション方向) に依存し、__Render__ メソッドで 1 フレームあたり 1 回変更されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-140">This matrix is dependent on the camera position and look direction (the normal to the projection) and changes one time per frame in the __Render__ method.</span></span> <span data-ttu-id="703b6-141">これについては、「__レンダリング フレームワーク I: レンダリングの概要__」の「[__GameRenderer::Render__ メソッド](tutorial--assembling-the-rendering-pipeline.md#gamerendererrender-method)」で既に説明しました。</span><span class="sxs-lookup"><span data-stu-id="703b6-141">This was discussed earlier in __Rendering framework I: Intro to rendering__, under the [__GameRenderer::Render__ method](tutorial--assembling-the-rendering-pipeline.md#gamerendererrender-method).</span></span>
        4. <span data-ttu-id="703b6-142">__m\_constantBufferChangesEveryPrim__ には各プリミティブのモデル マトリックスとマテリアル プロパティが含まれます。</span><span class="sxs-lookup"><span data-stu-id="703b6-142">__m\_constantBufferChangesEveryPrim__ contains the model matrix and material properties of each primitive.</span></span> <span data-ttu-id="703b6-143">モデル マトリックスは、頂点をローカル座標からワールド座標に変換します。</span><span class="sxs-lookup"><span data-stu-id="703b6-143">The model matrix transforms vertices from local coordinates into world coordinates.</span></span> <span data-ttu-id="703b6-144">これらの定数は各プリミティブに固有で、描画呼び出しのたびに更新されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-144">These constants are specific to each primitive and are updated for every draw call.</span></span> <span data-ttu-id="703b6-145">これについては、「__レンダリング フレームワーク I: レンダリングの概要__」の「[プリミティブのレンダリング](tutorial--assembling-the-rendering-pipeline.md#primitive-rendering)」で既に説明しました。</span><span class="sxs-lookup"><span data-stu-id="703b6-145">This was discussed earlier in __Rendering framework I: Intro to rendering__, under the [Primitive rendering](tutorial--assembling-the-rendering-pipeline.md#primitive-rendering).</span></span>
* <span data-ttu-id="703b6-146">プリミティブのテクスチャを保持するシェーダー リソース オブジェクトも、このクラスで定義されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-146">Shader resource objects that hold textures for the primitives are also defined in this class.</span></span>
    * <span data-ttu-id="703b6-147">一部のテクスチャは事前に定義されています ([DDS](https://msdn.microsoft.com/library/windows/desktop/bb943991.aspx) は、圧縮および非圧縮テクスチャを格納するために使用されるファイル形式です。</span><span class="sxs-lookup"><span data-stu-id="703b6-147">Some textures are pre-defined ([DDS](https://msdn.microsoft.com/library/windows/desktop/bb943991.aspx) is a file format that can be used to store compressed and uncompressed textures.</span></span> <span data-ttu-id="703b6-148">DDS テクスチャは、ワールドの壁や床、弾薬の球体に使用されます)。</span><span class="sxs-lookup"><span data-stu-id="703b6-148">DDS textures are used for the walls and floor of the world as well as the ammo spheres.)</span></span>
    * <span data-ttu-id="703b6-149">このゲームのサンプルで、シェーダー リソース オブジェクトは、__m\_sphereTexture__、__m\_cylinderTexture__、__m\_ceilingTexture__、__m\_floorTexture__、__m\_wallsTexture__ です。</span><span class="sxs-lookup"><span data-stu-id="703b6-149">In this game sample, shader resource objects are: __m\_sphereTexture__, __m\_cylinderTexture__, __m\_ceilingTexture__, __m\_floorTexture__, __m\_wallsTexture__.</span></span>
* <span data-ttu-id="703b6-150">シェーダー オブジェクトは、プリミティブやテクスチャを計算するために、このクラスで定義されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-150">Shader objects are defined in this class to compute our primitives and textures.</span></span> 
    * <span data-ttu-id="703b6-151">このゲームのサンプルで、シェーダー オブジェクトは、__m\_vertexShader__、__m\_vertexShaderFlat__、__m\_pixelShader__、__m\_pixelShaderFlat__ です。</span><span class="sxs-lookup"><span data-stu-id="703b6-151">In this game sample, the shader objects are __m\_vertexShader__, __m\_vertexShaderFlat__, and __m\_pixelShader__, __m\_pixelShaderFlat__.</span></span>
    * <span data-ttu-id="703b6-152">頂点シェーダーはプリミティブと基本的な照明を処理し、ピクセル シェーダー (フラグメント シェーダーとも呼ばれます) はテクスチャとピクセルごとの効果を処理します。</span><span class="sxs-lookup"><span data-stu-id="703b6-152">The vertex shader processes the primitives and the basic lighting, and the pixel shader (sometimes called a fragment shader) processes the textures and any per-pixel effects.</span></span>
    * <span data-ttu-id="703b6-153">これらのシェーダーには、異なるプリミティブをレンダリングするための 2 つのバージョン (標準とフラット) があります。</span><span class="sxs-lookup"><span data-stu-id="703b6-153">There are two versions of these shaders (regular and flat) for rendering different primitives.</span></span> <span data-ttu-id="703b6-154">異なるバージョンを用意しているでは、フラット バージョンは、標準と比べるときわめて単純であり、鏡面ハイライトやピクセル単位の照明効果が一切実行されないためです。</span><span class="sxs-lookup"><span data-stu-id="703b6-154">The reason we have different versions is that the flat versions are much simpler and don't do specular highlights or any per pixel lighting effects.</span></span> <span data-ttu-id="703b6-155">壁に使われ、低電力デバイスでレンダリングを高速化します。</span><span class="sxs-lookup"><span data-stu-id="703b6-155">These are used for the walls and make rendering faster on lower powered devices.</span></span>

## <a name="gamerendererh"></a><span data-ttu-id="703b6-156">GameRenderer.h</span><span class="sxs-lookup"><span data-stu-id="703b6-156">GameRenderer.h</span></span>

<span data-ttu-id="703b6-157">ここでは、ゲーム サンプルのレンダラー クラス オブジェクトのコードについて説明し、DirectX 11 アプリ テンプレートで提供されている __Sample3DSceneRenderer.h__ と比較してみます。</span><span class="sxs-lookup"><span data-stu-id="703b6-157">Now let's look at the code in the game sample's renderer class object and compare it with the __Sample3DSceneRenderer.h__ provided in the DirectX 11 App template.</span></span>

```cpp
// Class object handling the rendering of the game
ref class GameRenderer
{
internal:
    GameRenderer(const std::shared_ptr<DX::DeviceResources>& deviceResources);
    
    // Compared with Sample3DSceneRenderer.h in the DirectX 11 App template sample. 
    
    // These methods are present.
    void CreateDeviceDependentResources();
    void CreateWindowSizeDependentResources();
    void ReleaseDeviceDependentResources();
    void Render();

    // Added: Async related methods to prepare 3D game objects for rendering
    concurrency::task<void> CreateGameDeviceResourcesAsync(_In_ Simple3DGame^ game);
    void FinalizeCreateGameDeviceResources();
    concurrency::task<void> LoadLevelResourcesAsync();
    void FinalizeLoadLevelResources();
    // --- end of async related methods section

    // Added: Methods for rendering overlay
    Simple3DGameDX::IGameUIControl^ GameUIControl()  { return m_gameInfoOverlay; };

    DirectX::XMFLOAT2 GameInfoOverlayUpperLeft()
    {
        return DirectX::XMFLOAT2(m_gameInfoOverlayRect.left, m_gameInfoOverlayRect.top);
    };
    DirectX::XMFLOAT2 GameInfoOverlayLowerRight()
    {
        return DirectX::XMFLOAT2(m_gameInfoOverlayRect.right, m_gameInfoOverlayRect.bottom);
    };
    bool GameInfoOverlayVisible() { return m_gameInfoOverlay->Visible(); }
    // --- end of rendering overlay section

    //...
    protected private:
    // Cached pointer to device resources.
    std::shared_ptr<DX::DeviceResources>                m_deviceResources;

    // ...

    // Shader resource objects
    Microsoft::WRL::ComPtr<ID3D11ShaderResourceView>    m_sphereTexture;
    Microsoft::WRL::ComPtr<ID3D11ShaderResourceView>    m_cylinderTexture;
    Microsoft::WRL::ComPtr<ID3D11ShaderResourceView>    m_ceilingTexture;
    Microsoft::WRL::ComPtr<ID3D11ShaderResourceView>    m_floorTexture;
    Microsoft::WRL::ComPtr<ID3D11ShaderResourceView>    m_wallsTexture;

    // Constant Buffers
    Microsoft::WRL::ComPtr<ID3D11Buffer>                m_constantBufferNeverChanges;
    Microsoft::WRL::ComPtr<ID3D11Buffer>                m_constantBufferChangeOnResize;
    Microsoft::WRL::ComPtr<ID3D11Buffer>                m_constantBufferChangesEveryFrame;
    Microsoft::WRL::ComPtr<ID3D11Buffer>                m_constantBufferChangesEveryPrim;

    // Texture sampler
    Microsoft::WRL::ComPtr<ID3D11SamplerState>          m_samplerLinear;

    // Shader objects: Vertex shaders and pixel shaders
    Microsoft::WRL::ComPtr<ID3D11VertexShader>          m_vertexShader;
    Microsoft::WRL::ComPtr<ID3D11VertexShader>          m_vertexShaderFlat;
    Microsoft::WRL::ComPtr<ID3D11PixelShader>           m_pixelShader;
    Microsoft::WRL::ComPtr<ID3D11PixelShader>           m_pixelShaderFlat;
    Microsoft::WRL::ComPtr<ID3D11InputLayout>           m_vertexLayout;
};
```

## <a name="constructor"></a><span data-ttu-id="703b6-158">コンストラクター</span><span class="sxs-lookup"><span data-stu-id="703b6-158">Constructor</span></span>

<span data-ttu-id="703b6-159">ここでは、ゲーム サンプルの __GameRenderer__ コンストラクターについて説明し、DirectX 11 アプリ テンプレートで提供されている __Sample3DSceneRenderer__ コンストラクターと比較してみます。</span><span class="sxs-lookup"><span data-stu-id="703b6-159">Next, let's examine the game sample's __GameRenderer__ constructor and compare it with the __Sample3DSceneRenderer__ constructor provided in the DirectX 11 App template.</span></span>

```cpp
// Constructor method of the main rendering class object
GameRenderer::GameRenderer(const std::shared_ptr<DX::DeviceResources>& deviceResources) : //...
{
    // Compared with Sample3DSceneRenderer::Sample3DSceneRenderer in the DirectX 11 App template sample. 
    
    // Added: Create a new GameHud object to rendered text on the top left corner of the screen
    m_gameHud = ref new GameHud(
        deviceResources,
        "Windows platform samples",
        "DirectX first-person game sample"
        );
    //--- end of new GameHud object section
        
    // Added: Game info rendered as an overlay on the top right corner of the screen (eg. Hits, Shots, Time)    
    m_gameInfoOverlay = ref new GameInfoOverlay(deviceResources);
    //--- end of game info rendered as overlay section

    // These methods are present.
    CreateDeviceDependentResources();
    CreateWindowSizeDependentResources();
}
```

## <a name="create-and-load-directx-graphic-resources"></a><span data-ttu-id="703b6-160">DirectX グラフィックス リソースの作成と読み込み</span><span class="sxs-lookup"><span data-stu-id="703b6-160">Create and load DirectX graphic resources</span></span>

<span data-ttu-id="703b6-161">ゲーム サンプル (および Visual Studio の __DirectX 11 アプリ (ユニバーサル Windows)__ テンプレート) では、ゲームのリソースの作成と読み込みは、__GameRenderer__ コンス トラクターから呼び出される次の 2 つのメソッドを使用して実装されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-161">In the game sample (and in Visual Studio's __DirectX 11 App (Universal Windows)__ template), creating and loading game resources is implemented using these two methods that are called from __GameRenderer__ constructor:</span></span>

* [__<span data-ttu-id="703b6-162">CreateDeviceDependentResources</span><span class="sxs-lookup"><span data-stu-id="703b6-162">CreateDeviceDependentResources</span></span>__](#createdevicedependentresources-method)
* [__<span data-ttu-id="703b6-163">CreateWindowSizeDependentResources</span><span class="sxs-lookup"><span data-stu-id="703b6-163">CreateWindowSizeDependentResources</span></span>__](#createwindowsizedependentresources-method)

## <a name="createdevicedependentresources-method"></a><span data-ttu-id="703b6-164">CreateDeviceDependentResources メソッド</span><span class="sxs-lookup"><span data-stu-id="703b6-164">CreateDeviceDependentResources method</span></span>

<span data-ttu-id="703b6-165">DirectX 11 アプリ テンプレートでは、このメソッドを使用して、頂点シェーダーとピクセル シェーダーの非道敵的な読み込み、シェーダーと定数バッファーの作成、位置と色の情報を含む頂点を持つメッシュの作成が行われます。</span><span class="sxs-lookup"><span data-stu-id="703b6-165">In the DirectX 11 App template, this method is used to load vertex and pixel shader asynchronously, create the shader and constant buffer, create a mesh with vertices that contain position and color info.</span></span> 

<span data-ttu-id="703b6-166">サンプル ゲームでは、シーン オブジェクトのこれらの操作は、[__CreateGameDeviceResourcesAsync__](#creategamedeviceresourcesasync-method) メソッドと [__FinalizeCreateGameDeviceResources__](#finalizecreategamedeviceresources-method) メソッドに分割されています。</span><span class="sxs-lookup"><span data-stu-id="703b6-166">In the sample game, these operations of the scene objects are instead split among the [__CreateGameDeviceResourcesAsync__](#creategamedeviceresourcesasync-method) and [__FinalizeCreateGameDeviceResources__](#finalizecreategamedeviceresources-method) methods.</span></span> 

<span data-ttu-id="703b6-167">このゲームのサンプルでは、このメソッドに何が含まれているでしょうか。</span><span class="sxs-lookup"><span data-stu-id="703b6-167">For this game sample, what goes into this method?</span></span>

* <span data-ttu-id="703b6-168">リソースを非同期的に読み込んでいるため、レンダリングに進む前にリソースが読み込まれているかどうかを示す、インスタンス化された変数 (__m\_gameResourcesLoaded__ = false と__m\_levelResourcesLoaded__ = false)。</span><span class="sxs-lookup"><span data-stu-id="703b6-168">Instantiated variables (__m\_gameResourcesLoaded__ = false and __m\_levelResourcesLoaded__ = false) that indicate whether resources have been loaded before moving forward to render, since we're loading them asynchronously.</span></span> 
* <span data-ttu-id="703b6-169">HUD とオーバーレイのレンダリングは別のクラスのオブジェクトで行われるため、ここでは __GameHud::CreateDeviceDependentResources__ メソッドと __GameInfoOverlay::CreateDeviceDependentResources__ メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="703b6-169">Since HUD and overlay rendering are in separate class objects, call __GameHud::CreateDeviceDependentResources__ and __GameInfoOverlay::CreateDeviceDependentResources__ methods here.</span></span>

<span data-ttu-id="703b6-170">__GameRenderer::CreateDeviceDependentResources__ のコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="703b6-170">Here's the code for __GameRenderer::CreateDeviceDependentResources__.</span></span>

```cpp
// This method is called in GameRenderer constructor when it's created in GameMain constructor.
void GameRenderer::CreateDeviceDependentResources()
{
    // instantiate variables that indicate if resources were loaded.
    m_gameResourcesLoaded = false;
    m_levelResourcesLoaded = false;

    // game HUD and overlay are design as separate class objects.
    m_gameHud->CreateDeviceDependentResources();
    m_gameInfoOverlay->CreateDeviceDependentResources();
}
```
<span data-ttu-id="703b6-171">次の表に、リソースを作成して読み込むために使用するメソッドを示します。</span><span class="sxs-lookup"><span data-stu-id="703b6-171">The table below lists the methods that are used to create and load resources.</span></span> <span data-ttu-id="703b6-172">リソースを非同期的に読み込むことができるように、サンプル ゲームには、__CreateGameDeviceResourcesAsync__ と __FinalizeCreateGameDeviceResources__ が追加されています。</span><span class="sxs-lookup"><span data-stu-id="703b6-172">__CreateGameDeviceResourcesAsync__ and __FinalizeCreateGameDeviceResources__ are added in the sample game so that resources are loaded asynchronously.</span></span>

|<span data-ttu-id="703b6-173">元の DirectX 11 アプリ テンプレート</span><span class="sxs-lookup"><span data-stu-id="703b6-173">Original DirectX 11 App template</span></span>           |<span data-ttu-id="703b6-174">サンプル ゲーム</span><span class="sxs-lookup"><span data-stu-id="703b6-174">Sample game</span></span>                                                                |
|-------------------------------------------|---------------------------------------------------------------------------|
|<span data-ttu-id="703b6-175">CreateDeviceDependentResources</span><span class="sxs-lookup"><span data-stu-id="703b6-175">CreateDeviceDependentResources</span></span>             |<span data-ttu-id="703b6-176">CreateDeviceDependentResources</span><span class="sxs-lookup"><span data-stu-id="703b6-176">CreateDeviceDependentResources</span></span>                                             |
|                                           | <span data-ttu-id="703b6-177">- CreateGameDeviceResourcesAsync (追加)</span><span class="sxs-lookup"><span data-stu-id="703b6-177">- CreateGameDeviceResourcesAsync (Added)</span></span>                                  |
|                                           | <span data-ttu-id="703b6-178">- FinalizeCreateGameDeviceResources (追加)</span><span class="sxs-lookup"><span data-stu-id="703b6-178">- FinalizeCreateGameDeviceResources (Added)</span></span>                               |
|<span data-ttu-id="703b6-179">CreateWindowSizeDependentResources</span><span class="sxs-lookup"><span data-stu-id="703b6-179">CreateWindowSizeDependentResources</span></span>         |<span data-ttu-id="703b6-180">CreateWindowSizeDependentResources</span><span class="sxs-lookup"><span data-stu-id="703b6-180">CreateWindowSizeDependentResources</span></span>                                         |

<span data-ttu-id="703b6-181">リソースの作成と読み込みに使用される他のメソッドについて解説する前に、まずレンダラーを作成し、ゲーム ループに適していることを確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="703b6-181">Before diving into the other methods that are used to create and load resources, let's first create the renderer and see how it fits into the game loop.</span></span>

## <a name="create-the-renderer"></a><span data-ttu-id="703b6-182">レンダラーの作成</span><span class="sxs-lookup"><span data-stu-id="703b6-182">Create the renderer</span></span>

<span data-ttu-id="703b6-183">__GameRenderer__ は __GameMain__ のコンストラクターで作成されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-183">The __GameRenderer__ is created in the __GameMain__'s constructor.</span></span> <span data-ttu-id="703b6-184">また、リソースの作成と読み込みのために追加された、他の 2 つメソッド [__CreateGameDeviceResourcesAsync__](#creategamedeviceresourcesasync-method) と [__FinalizeCreateGameDeviceResources__](#finalizecreategamedeviceresources-method) も呼び出します。</span><span class="sxs-lookup"><span data-stu-id="703b6-184">It also calls the two other methods, [__CreateGameDeviceResourcesAsync__](#creategamedeviceresourcesasync-method) and [__FinalizeCreateGameDeviceResources__](#finalizecreategamedeviceresources-method) that are added to help create and load resources.</span></span>

```cpp

GameMain::GameMain(const std::shared_ptr<DX::DeviceResources>& deviceResources) : // ...
{
    m_deviceResources->RegisterDeviceNotify(this);

    // These methods are used in the DirectX 11 App template to create the class objects used for rendering. 
    // But are replaced in this game sample with GameRenderer as shown below.
    // m_sceneRenderer = std::unique_ptr<Sample3DSceneRenderer>(new Sample3DSceneRenderer(m_deviceResources));
    // m_fpsTextRenderer = std::unique_ptr<SampleFpsTextRenderer>(new SampleFpsTextRenderer(m_deviceResources));
    
    // Creation of GameRenderer
    m_renderer = ref new GameRenderer(m_deviceResources);
    
    //...

     create_task([this]()
    {
        // Asynchronously initialize the game class and load the renderer device resources.
        // By doing all this asynchronously, the game gets to its main loop more quickly
        // and in parallel all the necessary resources are loaded on other threads.
        m_game->Initialize(m_controller, m_renderer);

        return m_renderer->CreateGameDeviceResourcesAsync(m_game);

    }).then([this]()
    {
        // The finalize code needs to run in the same thread context
        // as the m_renderer object was created because the D3D device context
        // can ONLY be accessed on a single thread.
        m_renderer->FinalizeCreateGameDeviceResources();

        InitializeGameState();
    
    //...
}
```

## <a name="creategamedeviceresourcesasync-method"></a><span data-ttu-id="703b6-185">CreateGameDeviceResourcesAsync メソッド</span><span class="sxs-lookup"><span data-stu-id="703b6-185">CreateGameDeviceResourcesAsync method</span></span>

<span data-ttu-id="703b6-186">ゲームのリソースを非同期的に読み込んでいるため、__create\_task__ ループで __GameMain__コンストラクター メソッドから __CreateGameDeviceResourcesAsync__ を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="703b6-186">__CreateGameDeviceResourcesAsync__ is called from the __GameMain__ constructor method in the __create\_task__ loop since we're loading game resources asynchronously.</span></span>
        
<span data-ttu-id="703b6-187">__CreateDeviceResourcesAsync__ は、ゲームのリソースを読み込むための一連の非同期タスクとして別個に実行されるメソッドです。</span><span class="sxs-lookup"><span data-stu-id="703b6-187">__CreateDeviceResourcesAsync__ is a method that runs as a separate set of async tasks to load the game resources.</span></span> <span data-ttu-id="703b6-188">個別のスレッドで実行されると想定されるので、Direct3D 11 デバイス メソッド (__ID3D11Device__ で定義されているメソッド) にのみアクセスでき、デバイス コンテキスト メソッド (__ID3D11DeviceContext__ で定義されているメソッド) にはアクセスできないため、レンダリングは実行されません。</span><span class="sxs-lookup"><span data-stu-id="703b6-188">Because it's expected to run on a separate thread, it only has access to the Direct3D 11 device methods (those defined on __ID3D11Device__) and not the device context methods (the methods defined on __ID3D11DeviceContext__), so it does not perform any rendering.</span></span>

<span data-ttu-id="703b6-189">__FinalizeCreateGameDeviceResources__ メソッドはメイン スレッドで実行され、Direct3D 11 デバイス コンテキスト メソッドにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="703b6-189">__FinalizeCreateGameDeviceResources__ method runs on the main thread and does have access to the Direct3D 11 device context methods.</span></span>

<span data-ttu-id="703b6-190">原則は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="703b6-190">In principle:</span></span>
* <span data-ttu-id="703b6-191">__CreateGameDeviceResourcesAsync__ では __ID3D11Device__ のメソッドのみを使用します。これは、フリー スレッド化されている (任意のスレッドで実行できることを意味する) ためです。</span><span class="sxs-lookup"><span data-stu-id="703b6-191">Use only __ID3D11Device__ methods in __CreateGameDeviceResourcesAsync__ because they are free-threaded, which means that they are able to run on any thread.</span></span> <span data-ttu-id="703b6-192">また、__GameRenderer__ が作成されたスレッドと同じスレッドでは実行されないことも想定されています。</span><span class="sxs-lookup"><span data-stu-id="703b6-192">It is also expected that they do not run on the same thread as the one __GameRenderer__ was created on.</span></span> 
* <span data-ttu-id="703b6-193">1 つのスレッドで実行する必要があり、かつ __GameRenderer__ と同じスレッドで実行する必要があるため、ここでは __ID3D11DeviceContext__ のスレッドを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="703b6-193">Do not use methods in __ID3D11DeviceContext__ here because they need to run on a single thread and on the same thread as __GameRenderer__.</span></span>
* <span data-ttu-id="703b6-194">定数バッファーを作成するには、このメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="703b6-194">Use this method to create constant buffers.</span></span>
* <span data-ttu-id="703b6-195">テクスチャ (.dds ファイルなど) やシェーダー情報 (.cso ファイルなど) を、[シェーダー](tutorial--assembling-the-rendering-pipeline.md#shaders)に読み込むには、このメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="703b6-195">Use this method to load textures (like the .dds files) and shader info (like the .cso files) into the [shaders](tutorial--assembling-the-rendering-pipeline.md#shaders).</span></span>

<span data-ttu-id="703b6-196">このメソッドを使用して、次の処理を行います。</span><span class="sxs-lookup"><span data-stu-id="703b6-196">This method is used to:</span></span>
* <span data-ttu-id="703b6-197">4 つの[定数バッファー](tutorial--assembling-the-rendering-pipeline.md#buffer) (__m\_constantBufferNeverChanges__、__m\_constantBufferChangeOnResize__、__m\_constantBufferChangesEveryFrame__、__m\_constantBufferChangesEveryPrim__) を作成します。</span><span class="sxs-lookup"><span data-stu-id="703b6-197">Create the 4 [constant buffers](tutorial--assembling-the-rendering-pipeline.md#buffer): __m\_constantBufferNeverChanges__, __m\_constantBufferChangeOnResize__, __m\_constantBufferChangesEveryFrame__, __m\_constantBufferChangesEveryPrim__</span></span>
* <span data-ttu-id="703b6-198">テクスチャーのサンプリング情報をカプセル化する[サンプラー ステート](tutorial--assembling-the-rendering-pipeline.md#sampler-state) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="703b6-198">Create a [sampler-state](tutorial--assembling-the-rendering-pipeline.md#sampler-state) object that encapsulates sampling information for a texture</span></span>
* <span data-ttu-id="703b6-199">メソッドで作成されたすべての非同期タスクを含むタスク グループを作成します。</span><span class="sxs-lookup"><span data-stu-id="703b6-199">Create a task group that contains all async tasks created by the method.</span></span> <span data-ttu-id="703b6-200">メソッドは、これらすべての非同期タスクが完了するまで待機してから __FinalizeCreateGameDeviceResources__ を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="703b6-200">It waits for the completion of all these async tasks, and then calls __FinalizeCreateGameDeviceResources__.</span></span>
* <span data-ttu-id="703b6-201">[Basic Loader](tutorial--assembling-the-rendering-pipeline.md#basicloader) を使用してローダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="703b6-201">Create a loader using [Basic Loader](tutorial--assembling-the-rendering-pipeline.md#basicloader).</span></span> <span data-ttu-id="703b6-202">前の手順で作成したタスク グループに、ローダーの非同期読み込み操作をタスクとして追加します。</span><span class="sxs-lookup"><span data-stu-id="703b6-202">Add the loader's async loading operations as tasks into the task group created earlier.</span></span>
* <span data-ttu-id="703b6-203">__BasicLoader::LoadShaderAsync__ や __BasicLoader::LoadTextureAsync__ などのメソッドは、以下を読み込むために使用されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-203">Methods like __BasicLoader::LoadShaderAsync__ and  __BasicLoader::LoadTextureAsync__ are used to load:</span></span>
    * <span data-ttu-id="703b6-204">コンパイル済みのシェーダー オブジェクト (VertextShader.cso、VertexShaderFlat.cso、PixelShader.cso、PixelShaderFlat.cso)。</span><span class="sxs-lookup"><span data-stu-id="703b6-204">compiled shader objects (VertextShader.cso, VertexShaderFlat.cso, PixelShader.cso, and PixelShaderFlat.cso).</span></span> <span data-ttu-id="703b6-205">詳細については、「[さまざまなシェーダー ファイル形式](tutorial--assembling-the-rendering-pipeline.md#various-shader-file-formats)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="703b6-205">For more info, go to [Various shader file formats](tutorial--assembling-the-rendering-pipeline.md#various-shader-file-formats).</span></span>
    * <span data-ttu-id="703b6-206">ゲーム固有のテクスチャ (Assets\\seafloor.dds metal_texture.dds、cellceiling.dds、cellfloor.dds、cellwall.dds)。</span><span class="sxs-lookup"><span data-stu-id="703b6-206">game specific textures (Assets\\seafloor.dds, metal_texture.dds, cellceiling.dds, cellfloor.dds, cellwall.dds).</span></span>

```cpp
task<void> GameRenderer::CreateGameDeviceResourcesAsync(_In_ Simple3DGame^ game)
{
    // Create the device dependent game resources.
    // Only the d3dDevice is used in this method.  It is expected
    // to not run on the same thread as the GameRenderer was created.
    // Create methods on the d3dDevice are free-threaded and are safe while any methods
    // in the d3dContext should only be used on a single thread and handled
    // in the FinalizeCreateGameDeviceResources method.
    m_game = game;

    auto d3dDevice = m_deviceResources->GetD3DDevice();

    // Define D3D11_BUFFER_DESC.
    // For API ref, go to: https://msdn.microsoft.com/library/windows/desktop/ff476092.aspx
    D3D11_BUFFER_DESC bd;
    ZeroMemory(&bd, sizeof(bd));
    
    bd.Usage = D3D11_USAGE_DEFAULT;
    // ...
    
    // Create the constant buffers: m_constantBufferNeverChanges, m_constantBufferChangeOnResize,
    // m_constantBufferChangesEveryFrame, m_constantBufferChangesEveryPrim
    // CreateBuffer is used to create one of these buffers: vertex buffer, index buffer, or 
    // shader-constant buffer. For CreateBuffer API ref info, go to: https://msdn.microsoft.com/library/windows/desktop/ff476501.aspx
    
    DX::ThrowIfFailed(
        d3dDevice->CreateBuffer(&bd, nullptr, &m_constantBufferNeverChanges) 
        );
    // ...
    
    // Define D3D11_SAMPLER_DESC. For API ref, go to: https://msdn.microsoft.com/library/windows/desktop/ff476207.aspx
    D3D11_SAMPLER_DESC sampDesc;

    // ZeroMemory fills a block of memory with zeros. 
    // For API ref, go to: https://msdn.microsoft.com/en-us/library/windows/desktop/aa366920(v=vs.85).aspx
    ZeroMemory(&sampDesc, sizeof(sampDesc));

    sampDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
    sampDesc.AddressU = D3D11_TEXTURE_ADDRESS_WRAP;
    sampDesc.AddressV = D3D11_TEXTURE_ADDRESS_WRAP;
    // ...
    
    // Create a sampler-state object that encapsulates sampling information for a texture.
    // The sampler-state interface holds a description for sampler state that you can bind to any 
    // shader stage of the pipeline for reference by texture sample operations.
    DX::ThrowIfFailed(
        d3dDevice->CreateSamplerState(&sampDesc, &m_samplerLinear)
        );

    // Start the async tasks to load the shaders and textures (resources).
    
    // Load compiled shader objects (VertextShader.cso, VertexShaderFlat.cso, PixelShader.cso, and PixelShaderFlat.cso).
    // The BasicLoader class is used to convert and load common graphics resources, such as meshes, textures, 
    // and various shader objects into the constant buffers. 
    // For more info, go to: https://docs.microsoft.com/windows/uwp/gaming/complete-code-for-basicloader
    BasicLoader^ loader = ref new BasicLoader(d3dDevice);

    std::vector<task<void>> tasks;

    uint32 numElements = ARRAYSIZE(PNTVertexLayout);

    // Load shaders asynchronously with the shader and pixel data using the BasicLoader::LoadShaderAsync method
    // Push these method calls into a list of tasks
    tasks.push_back(loader->LoadShaderAsync("VertexShader.cso", PNTVertexLayout, numElements, &m_vertexShader, &m_vertexLayout));
    tasks.push_back(loader->LoadShaderAsync("VertexShaderFlat.cso", nullptr, numElements, &m_vertexShaderFlat, nullptr));
    tasks.push_back(loader->LoadShaderAsync("PixelShader.cso", &m_pixelShader));
    tasks.push_back(loader->LoadShaderAsync("PixelShaderFlat.cso", &m_pixelShaderFlat));

    // Make sure the previous versions are set to NULL before any of the textures are loaded.
    m_sphereTexture = nullptr;
    // ...

    // Load Game specific textures (Assets\\seafloor.dds, metal_texture.dds, cellceiling.dds, cellfloor.dds, cellwall.dds).
    // Push these method calls also into a list of tasks
    tasks.push_back(loader->LoadTextureAsync("Assets\\seafloor.dds", nullptr, &m_sphereTexture));
    // ...
    
    tasks.push_back(create_task([]()
    {
        // Simulate loading additional resources by introducing a delay.
        wait(GameConstants::InitialLoadingDelay);
    }));

    // Returns when all the async tasks for loading the shader and texture assets have completed.
    return when_all(tasks.begin(), tasks.end());
}
```

## <a name="finalizecreategamedeviceresources-method"></a><span data-ttu-id="703b6-207">FinalizeCreateGameDeviceResources メソッド</span><span class="sxs-lookup"><span data-stu-id="703b6-207">FinalizeCreateGameDeviceResources method</span></span>

<span data-ttu-id="703b6-208">__FinalizeCreateGameDeviceResources__メソッドは、__CreateGameDeviceResourcesAsync__メソッド内のすべてのリソース読み込みタスクが完了した後で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-208">__FinalizeCreateGameDeviceResources__ method is called after all the load resources tasks that are in the __CreateGameDeviceResourcesAsync__ method completes.</span></span> 

* <span data-ttu-id="703b6-209">ライトの位置と色を使用して constantBufferNeverChanges を初期化します。</span><span class="sxs-lookup"><span data-stu-id="703b6-209">Initialize constantBufferNeverChanges with the light positions and color.</span></span> <span data-ttu-id="703b6-210">デバイス コンテキスト メソッド __ID3D11DeviceContext::UpdateSubresource__ の呼び出しによって、最初のデータを定数バッファーに読み込みます。</span><span class="sxs-lookup"><span data-stu-id="703b6-210">Loads the initial data into the constant buffers with a device context method call to __ID3D11DeviceContext::UpdateSubresource__.</span></span>
* <span data-ttu-id="703b6-211">非同期的に読み込まれるリソースの読み込みが完了したら、適切なゲーム オブジェクトに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="703b6-211">Since asynchronously loaded resources have completed loading, it's time to associate them with the appropriate game objects.</span></span>
* <span data-ttu-id="703b6-212">ゲーム オブジェクトごとに、読み込まれたテクスチャを使用して、メッシュとマテリアルを作成します。</span><span class="sxs-lookup"><span data-stu-id="703b6-212">For each game object, create the mesh and the material using the textures that have been loaded.</span></span> <span data-ttu-id="703b6-213">次に、メッシュとマテリアルをゲーム オブジェクトに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="703b6-213">Then associate the mesh and material to the game object.</span></span>
* <span data-ttu-id="703b6-214">ターゲットのゲーム オブジェクトの場合、同心円の色付きのリングとその上の数値で構成されるテクスチャは、テクスチャー ファイルからは読み込まれません。</span><span class="sxs-lookup"><span data-stu-id="703b6-214">For the targets game object, the texture which is composed of concentric colored rings, with a numeric value on the top, is not loaded from a texture file.</span></span> <span data-ttu-id="703b6-215">代わりに、__TargetTexture.cpp__ 内のコードを使用して手続き的に生成されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-215">Instead, it's procedurally generated using the code in __TargetTexture.cpp__.</span></span> <span data-ttu-id="703b6-216">__TargetTexture__ クラスは、初期化時にオフスクリーン リソースにテクスチャを描画するために必要なリソースを作成します。</span><span class="sxs-lookup"><span data-stu-id="703b6-216">The __TargetTexture__ class creates the necessary resources to draw the texture into an off screen resource at initialization time.</span></span> <span data-ttu-id="703b6-217">生成されたテクスチャは、適切なターゲット ゲーム オブジェクトに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="703b6-217">The resulting texture is then associated with the appropriate target game objects.</span></span>

<span data-ttu-id="703b6-218">__FinalizeCreateGameDeviceResources__ と [__CreateWindowSizeDependentResources__](#createwindowsizedependentresource-method) は、以下について、コードの同様の部分を共有します。</span><span class="sxs-lookup"><span data-stu-id="703b6-218">__FinalizeCreateGameDeviceResources__ and [__CreateWindowSizeDependentResources__](#createwindowsizedependentresource-method) share similar portions of code for these:</span></span>
* <span data-ttu-id="703b6-219">__SetProjParams__ を使用して、カメラのプロジェクション マトリックスが適切になるように設定します。</span><span class="sxs-lookup"><span data-stu-id="703b6-219">Use __SetProjParams__ to ensure that the camera has the right projection matrix.</span></span> <span data-ttu-id="703b6-220">詳しくは、「[カメラと座標空間](tutorial--assembling-the-rendering-pipeline.md#camera-and-coordinate-space)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="703b6-220">For more info, go to [Camera and coordinate space](tutorial--assembling-the-rendering-pipeline.md#camera-and-coordinate-space).</span></span>
* <span data-ttu-id="703b6-221">カメラのプロジェクション マトリックスに 3D 回転マトリックスを乗算することにより、画面の向きを処理します。</span><span class="sxs-lookup"><span data-stu-id="703b6-221">Handle screen rotation by post multiplying the 3D rotation matrix to the camera's projection matrix.</span></span> <span data-ttu-id="703b6-222">結果として得られるプロジェクション マトリックスを使って、__ConstantBufferChangeOnResize__ 定数バッファーを更新します。</span><span class="sxs-lookup"><span data-stu-id="703b6-222">Then update the __ConstantBufferChangeOnResize__ constant buffer with the resulting projection matrix.</span></span>
* <span data-ttu-id="703b6-223">__ブール型__の __m\_gameResourcesLoaded__ グローバル変数を設定し、リソースがバッファーに読み込まれ、次の手順の準備ができたことを示します。</span><span class="sxs-lookup"><span data-stu-id="703b6-223">Set the __m\_gameResourcesLoaded__ __Boolean__ global variable to indicate that the resources are now loaded in the buffers, ready for the next step.</span></span> <span data-ttu-id="703b6-224">最初に __GameRenderer__ のコンストラクター メソッドで、__GameRenderer::CreateDeviceDependentResources__ メソッドを使用して、この変数を __FALSE__ として初期化したことを思い出してください。</span><span class="sxs-lookup"><span data-stu-id="703b6-224">Recall that we first initialized this variable as __FALSE__ in the __GameRenderer__'s constructor method, through the __GameRenderer::CreateDeviceDependentResources__ method.</span></span> 
* <span data-ttu-id="703b6-225">この __m\_gameResourcesLoaded__ が __TRUE__ である場合、シーン オブジェクトのレンダリングを実行できます。</span><span class="sxs-lookup"><span data-stu-id="703b6-225">When this __m\_gameResourcesLoaded__ is __TRUE__, rendering of the scene objects can take place.</span></span> <span data-ttu-id="703b6-226">これについては、「__レンダリング フレームワーク I: レンダリングの概要__」の「[__GameRenderer::Render メソッド__](tutorial--assembling-the-rendering-pipeline.md#gamerendererrender-method)」で説明しました。</span><span class="sxs-lookup"><span data-stu-id="703b6-226">This was covered in the __Rendering framework I: Intro to rendering__ article, under [__GameRenderer::Render method__](tutorial--assembling-the-rendering-pipeline.md#gamerendererrender-method).</span></span>

```cpp
// When creating this sample game using the DirectX 11 App template, this method needs to be created.
// This new method is called from GameMain constructor in the .then loop.
// Make sure the 2D rendering is occurring on the same thread as the main rendering.
// Note: Helper class .h and .cpp files used in this method are located in the SharedContent/cpp/GameContent folder
void GameRenderer::FinalizeCreateGameDeviceResources()
{
    // All asynchronously loaded resources have completed loading.
    // Now associate all the resources with the appropriate game objects.
    // This method is expected to run in the same thread as the GameRenderer
    // was created. All work will happen behind the "Loading ..." screen after the
    // main loop has been entered.

    // Initialize constantBufferNeverChanges with the light positions and color.
    // These are handled here to ensure that the d3dContext is only
    // used in one thread.

    auto d3dDevice = m_deviceResources->GetD3DDevice();
    ConstantBufferNeverChanges constantBufferNeverChanges;
    constantBufferNeverChanges.lightPosition[0] = XMFLOAT4( 3.5f, 2.5f,  5.5f, 1.0f);
    // ...
    constantBufferNeverChanges.lightColor = XMFLOAT4(0.25f, 0.25f, 0.25f, 1.0f);

    // CPU copies data from memory (constantBufferNeverChanges) to a subresource 
    // created in non-mappable memory (m_constantBufferNeverChanges) which was created in the earlier 
    // CreateGameDeviceResourcesAsync method. For UpdateSubresource API ref info, 
    // go to: https://msdn.microsoft.com/library/windows/desktop/ff476486.aspx
    // To learn more about what a subresource is, go to:
    // https://msdn.microsoft.com/library/windows/desktop/ff476901.aspx

    m_deviceResources->GetD3DDeviceContext()->UpdateSubresource(
        m_constantBufferNeverChanges.Get(),
        0,
        nullptr,
        &constantBufferNeverChanges,
        0,
        0
        );

    // For the objects that function as targets, they have two unique generated textures.
    // One version is used to show that they have never been hit and the other is 
    // used to show that they have been hit.
    // TargetTexture is a helper class to procedurally generate textures for game
    // targets. The class creates the necessary resources to draw the texture into 
    // an off screen resource at initialization time.

    TargetTexture^ textureGenerator = ref new TargetTexture(
        d3dDevice,
        m_deviceResources->GetD2DFactory(),
        m_deviceResources->GetDWriteFactory(),
        m_deviceResources->GetD2DDeviceContext()
        );

    // CylinderMesh is a class derived from MeshObject and creates a ID3D11Buffer of
    // vertices and indices to represent a canonical cylinder (capped at
    // both ends) that is positioned at the origin with a radius of 1.0,
    // a height of 1.0 and with its axis in the +Z direction.
    // In the game sample, there are various types of mesh types:
    // CylinderMesh (vertical rods), SphereMesh (balls that the player shoots), 
    // FaceMesh (target objects), and WorldMesh (Floors and ceilings that define the enclosed area)

    MeshObject^ cylinderMesh = ref new CylinderMesh(d3dDevice, 26);
    // ...

    // The Material class maintains the properties that represent how an object will
    // look when it is rendered.  This includes the color of the object, the
    // texture used to render the object, and the vertex and pixel shader that
    // should be used for rendering.

    Material^ cylinderMaterial = ref new Material(
        XMFLOAT4(0.8f, 0.8f, 0.8f, .5f),
        XMFLOAT4(0.8f, 0.8f, 0.8f, .5f),
        XMFLOAT4(1.0f, 1.0f, 1.0f, 1.0f),
        15.0f,
        m_cylinderTexture.Get(),
        m_vertexShader.Get(),
        m_pixelShader.Get()
        );

    // ...
    auto objects = m_game->RenderObjects();

    // Attach the textures to the appropriate game objects.
    // We'll loop through all the objects that need to be rendered.
    for (auto object = objects.begin(); object != objects.end(); object++)
    {

        if ((*object)->TargetId() == GameConstants::WorldFloorId)
        {
            // Assign a normal material for the floor object.
            // This normal material uses the floor texture (cellfloor.dds) that was loaded asynchronously from
            // the Assets folder using BasicLoader::LoadTextureAsync method in the earlier 
            // CreateGameDeviceResourcesAsync loop

            (*object)->NormalMaterial(
                ref new Material(
                    XMFLOAT4(0.5f, 0.5f, 0.5f, 1.0f),
                    XMFLOAT4(0.8f, 0.8f, 0.8f, 1.0f),
                    XMFLOAT4(0.3f, 0.3f, 0.3f, 1.0f),
                    150.0f,
                    m_floorTexture.Get(),
                    m_vertexShaderFlat.Get(),
                    m_pixelShaderFlat.Get()
                    )
                );
            // Creates a mesh object called WorldFloorMesh and assign it to the floor object.
            (*object)->Mesh(ref new WorldFloorMesh(d3dDevice));
        }
        // ...
        else if (Cylinder^ cylinder = dynamic_cast<Cylinder^>(*object))
        {
            cylinder->Mesh(cylinderMesh);
            cylinder->NormalMaterial(cylinderMaterial);
        }
        else if (Face^ target = dynamic_cast<Face^>(*object))
        {
            const int bufferLength = 16;
            char16 str[bufferLength];
            int len = swprintf_s(str, bufferLength, L"%d", target->TargetId());
            Platform::String^ string = ref new Platform::String(str, len);

            ComPtr<ID3D11ShaderResourceView> texture;
            textureGenerator->CreateTextureResourceView(string, &texture);
            target->NormalMaterial(
                ref new Material(
                    XMFLOAT4(0.8f, 0.8f, 0.8f, 0.5f),
                    XMFLOAT4(0.8f, 0.8f, 0.8f, 0.5f),
                    XMFLOAT4(0.3f, 0.3f, 0.3f, 1.0f),
                    5.0f,
                    texture.Get(),
                    m_vertexShader.Get(),
                    m_pixelShader.Get()
                    )
                );

            textureGenerator->CreateHitTextureResourceView(string, &texture);
            target->HitMaterial(
                ref new Material(
                    XMFLOAT4(0.8f, 0.8f, 0.8f, 0.5f),
                    XMFLOAT4(0.8f, 0.8f, 0.8f, 0.5f),
                    XMFLOAT4(0.3f, 0.3f, 0.3f, 1.0f),
                    5.0f,
                    texture.Get(),
                    m_vertexShader.Get(),
                    m_pixelShader.Get()
                    )
                );

            target->Mesh(targetMesh);
        }
        // ...
    }


    // The SetProjParams method calculates the projection matrix based on input params and
    // ensures that the camera has been initialized with the right projection
    // matrix.  
    // The camera is not created at the time the first window resize event occurs.

    auto renderTargetSize = m_deviceResources->GetRenderTargetSize();
    m_game->GameCamera()->SetProjParams(
        XM_PI / 2,
        renderTargetSize.Width / renderTargetSize.Height,
        0.01f,
        100.0f
        );

    // Make sure that the correct projection matrix is set in the ConstantBufferChangeOnResize buffer.

    // Get the 3D rotation transform matrix. We are handling screen rotations directly to eliminate an unaligned 
    // fullscreen copy. So it is necessary to post multiply the 3D rotation matrix to the camera's projection matrix
    // to get the projection matrix that we need.

    auto orientation = m_deviceResources->GetOrientationTransform3D();

    ConstantBufferChangeOnResize changesOnResize;

    // The matrices are transposed due to the shader code expecting the matrices in the opposite
    // row/column order from the DirectX math library.

    // XMStoreFloat4x4 takes a matrix and writes the components out to sixteen single-precision floating-point values at the given address. 
    // The most significant component of the first row vector is written to the first four bytes of the address, 
    // followed by the second most significant component of the first row, and so on. The second row is then written out in a 
    // like manner to memory beginning at byte 16, followed by the third row to memory beginning at byte 32, and finally 
    // the fourth row to memory beginning at byte 48. For more API ref info, go to: 
    // https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.storing.xmstorefloat4x4.aspx

    XMStoreFloat4x4(
        &changesOnResize.projection,
        XMMatrixMultiply(
            XMMatrixTranspose(m_game->GameCamera()->Projection()),
            XMMatrixTranspose(XMLoadFloat4x4(&orientation))
            )
        );

    // UpdateSubresource method instructs CPU to copy data from memory (changesOnResize) to a subresource 
    // created in non-mappable memory (m_constantBufferChangeOnResize ) which was created in the earlier 
    // CreateGameDeviceResourcesAsync method.

    m_deviceResources->GetD3DDeviceContext()->UpdateSubresource(
        m_constantBufferChangeOnResize.Get(),
        0,
        nullptr,
        &changesOnResize,
        0,
        0
        );

    // Finally we set the m_gameResourcesLoaded as TRUE, so we can start rendering.
    m_gameResourcesLoaded = true;
}
```

## <a name="createwindowsizedependentresource-method"></a><span data-ttu-id="703b6-227">CreateWindowSizeDependentResource メソッド</span><span class="sxs-lookup"><span data-stu-id="703b6-227">CreateWindowSizeDependentResource method</span></span>

<span data-ttu-id="703b6-228">CreateWindowSizeDependentResources メソッドは、ウィンドウのサイズ、向き、ステレオに対応したレンダリング、解像度を変更するたびに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-228">CreateWindowSizeDependentResources methods are called every time the window size, orientation, stereo-enabled rendering, or resolution changes.</span></span> <span data-ttu-id="703b6-229">サンプル ゲームでは、 __ConstantBufferChangeOnResize__でプロジェクション マトリックスを更新します。</span><span class="sxs-lookup"><span data-stu-id="703b6-229">In the sample game, it updates the projection matrix in __ConstantBufferChangeOnResize__.</span></span>

<span data-ttu-id="703b6-230">ウィンドウ サイズのリソースは、次の方法で更新されます。</span><span class="sxs-lookup"><span data-stu-id="703b6-230">Window size resources are updated in this manner:</span></span> 
* <span data-ttu-id="703b6-231">アプリ フレームワークが、ウィンドウの状態の変更を表すいくつかの考えられるイベントのいずれかを取得します。</span><span class="sxs-lookup"><span data-stu-id="703b6-231">The App framework gets one of several possible events indicating a change in the window state.</span></span> 
* <span data-ttu-id="703b6-232">メイン ゲーム ループにイベントが通知され、メイン クラス (__GameMain__) インスタンスで __CreateWindowSizeDependentResources__ を呼び出します。これは、次に、ゲーム レンダラー (__GameRenderer__) クラスでの __CreateWindowSizeDependentResources__ の実装を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="703b6-232">Your main game loop is then informed about the event and calls __CreateWindowSizeDependentResources__ on the main class (__GameMain__) instance, which then calls the __CreateWindowSizeDependentResources__ implementation in the game renderer (__GameRenderer__) class.</span></span>
* <span data-ttu-id="703b6-233">このメソッドの主な役割は、ウィンドウのプロパティが変化したために視覚効果が混乱したり、誤ったものにならないようにすることです。</span><span class="sxs-lookup"><span data-stu-id="703b6-233">The primary job of this method is to make sure the visuals don't become confused or invalid because of a change in window properties.</span></span>

<span data-ttu-id="703b6-234">このゲーム サンプルでは、多くのメソッド呼び出しが [__FinalizeCreateGameDeviceResources__](#finalizecreategamedeviceresources-method) メソッドと同じです。</span><span class="sxs-lookup"><span data-stu-id="703b6-234">For this game sample, a number of method calls are the same as the [__FinalizeCreateGameDeviceResources__](#finalizecreategamedeviceresources-method) method.</span></span> <span data-ttu-id="703b6-235">コード チュートリアルについては、前のセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="703b6-235">For code walkthrough, go to the previous section.</span></span>

<span data-ttu-id="703b6-236">ゲームの HUD とオーバーレイ ウィンドウ サイズのレンダリングの調整については、「[ユーザー インターフェイスの追加](#tutorial--adding-a-user-interface)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="703b6-236">The game HUD and overlay window size rendering adjustments is covered under [Add a user interface](#tutorial--adding-a-user-interface).</span></span>

```cpp
// Initializes view parameters when the window size changes.
void GameRenderer::CreateWindowSizeDependentResources()
{

    // Game HUD and overlay window size rendering adjustments are done here
    // but they'll be covered in the UI section instead.

    m_gameHud->CreateWindowSizeDependentResources();

    // ...

    auto d3dContext = m_deviceResources->GetD3DDeviceContext();
    // In Sample3DSceneRenderer::CreateWindowSizeDependentResources, we had:
    // Size outputSize = m_deviceResources->GetOutputSize();

    auto renderTargetSize = m_deviceResources->GetRenderTargetSize();

    // ...

    m_gameInfoOverlay->CreateWindowSizeDependentResources(m_gameInfoOverlaySize);

    if (m_game != nullptr)
    {
        // Similar operations as the last section of FinalizeCreateGameDeviceResources method
        m_game->GameCamera()->SetProjParams(
            XM_PI / 2, renderTargetSize.Width / renderTargetSize.Height,
            0.01f,
            100.0f
            );

        XMFLOAT4X4 orientation = m_deviceResources->GetOrientationTransform3D();

        ConstantBufferChangeOnResize changesOnResize;
        XMStoreFloat4x4(
            &changesOnResize.projection,
            XMMatrixMultiply(
                XMMatrixTranspose(m_game->GameCamera()->Projection()),
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
}
```

## <a name="next-steps"></a><span data-ttu-id="703b6-237">次のステップ</span><span class="sxs-lookup"><span data-stu-id="703b6-237">Next steps</span></span>

<span data-ttu-id="703b6-238">これは、ゲームのグラフィックス レンダリング フレームワークを実装する基本的なプロセスです。</span><span class="sxs-lookup"><span data-stu-id="703b6-238">This is the basic process for implementing the graphics rendering framework of a game.</span></span> <span data-ttu-id="703b6-239">ゲームの規模が大きくなるほど、オブジェクトの種類とアニメーションの動作の階層を処理するために必要な抽象化も増加します。</span><span class="sxs-lookup"><span data-stu-id="703b6-239">The larger your game, the more abstractions you would have to put in place to handle hierarchies of object types and animation behaviors.</span></span> <span data-ttu-id="703b6-240">メッシュやテクスチャなどのアセットを読み込んで管理するために、より複雑なメソッドの実装が必要になります。</span><span class="sxs-lookup"><span data-stu-id="703b6-240">You need to implement more complex methods for loading and managing assets such as meshes and textures.</span></span> <span data-ttu-id="703b6-241">次に、[ユーザー インターフェイスを追加する](tutorial--adding-a-user-interface.md)方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="703b6-241">Next, let's learn how to [add a user interface](tutorial--adding-a-user-interface.md).</span></span>