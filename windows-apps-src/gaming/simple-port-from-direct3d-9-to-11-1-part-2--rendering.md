---
author: mtoepke
title: レンダリング フレームワークの変換
description: ジオメトリ バッファーを移植する方法、HLSL シェーダー プログラムをコンパイルして読み込む方法、Direct3D 11 のレンダリング チェーンを実装する方法など、Direct3D 9 の簡単なレンダリング フレームワークを Direct3D 11 に変換する方法について説明します。
ms.assetid: f6ca1147-9bb8-719a-9a2c-b7ee3e34bd18
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, レンダリング フレームワーク, 変換, Direct3D 9, Direct3D 11
ms.localizationpriority: medium
ms.openlocfilehash: 044a0dc7bf264a82b849623a53d00268d7b30fd9
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5569633"
---
# <a name="convert-the-rendering-framework"></a><span data-ttu-id="09b9f-104">レンダリング フレームワークの変換</span><span class="sxs-lookup"><span data-stu-id="09b9f-104">Convert the rendering framework</span></span>



**<span data-ttu-id="09b9f-105">要約</span><span class="sxs-lookup"><span data-stu-id="09b9f-105">Summary</span></span>**

-   [<span data-ttu-id="09b9f-106">パート 1: Direct3D 11 の初期化</span><span class="sxs-lookup"><span data-stu-id="09b9f-106">Part 1: Initialize Direct3D 11</span></span>](simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md)
-   <span data-ttu-id="09b9f-107">パート 2: レンダリング フレームワークの変換</span><span class="sxs-lookup"><span data-stu-id="09b9f-107">Part 2: Convert the rendering framework</span></span>
-   [<span data-ttu-id="09b9f-108">パート 3: ゲーム ループの移植</span><span class="sxs-lookup"><span data-stu-id="09b9f-108">Part 3: Port the game loop</span></span>](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md)


<span data-ttu-id="09b9f-109">ジオメトリ バッファーを移植する方法、HLSL シェーダー プログラムをコンパイルして読み込む方法、Direct3D 11 のレンダリング チェーンを実装する方法など、Direct3D 9 の簡単なレンダリング フレームワークを Direct3D 11 に変換する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-109">Shows how to convert a simple rendering framework from Direct3D 9 to Direct3D 11, including how to port geometry buffers, how to compile and load HLSL shader programs, and how to implement the rendering chain in Direct3D 11.</span></span> <span data-ttu-id="09b9f-110">「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="09b9f-110">Part 2 of the [Port a simple Direct3D 9 app to DirectX 11 and Universal Windows Platform (UWP)](walkthrough--simple-port-from-direct3d-9-to-11-1.md) walkthrough.</span></span>

## <a name="convert-effects-to-hlsl-shaders"></a><span data-ttu-id="09b9f-111">HLSL シェーダーへのエフェクトの変換</span><span class="sxs-lookup"><span data-stu-id="09b9f-111">Convert effects to HLSL shaders</span></span>


<span data-ttu-id="09b9f-112">次の例は、従来のエフェクト API 向けに記述された、ハードウェアの頂点変換とパススルー色データの簡単な D3DX の手法です。</span><span class="sxs-lookup"><span data-stu-id="09b9f-112">The following example is a simple D3DX technique, written for the legacy Effects API, for hardware vertex transformation and pass-through color data.</span></span>

<span data-ttu-id="09b9f-113">Direct3D 9 シェーダー コード</span><span class="sxs-lookup"><span data-stu-id="09b9f-113">Direct3D 9 shader code</span></span>

```cpp
// Global variables
matrix g_mWorld;        // world matrix for object
matrix g_View;          // view matrix
matrix g_Projection;    // projection matrix

// Shader pipeline structures
struct VS_OUTPUT
{
    float4 Position   : POSITION;   // vertex position
    float4 Color      : COLOR0;     // vertex diffuse color
};

struct PS_OUTPUT
{
    float4 RGBColor : COLOR0;  // Pixel color    
};

// Vertex shader
VS_OUTPUT RenderSceneVS(float3 vPos : POSITION, 
                        float3 vColor : COLOR0)
{
    VS_OUTPUT Output;
    
    float4 pos = float4(vPos, 1.0f);

    // Transform the position from object space to homogeneous projection space
    pos = mul(pos, g_mWorld);
    pos = mul(pos, g_View);
    pos = mul(pos, g_Projection);

    Output.Position = pos;
    
    // Just pass through the color data
    Output.Color = float4(vColor, 1.0f);
    
    return Output;
}

// Pixel shader
PS_OUTPUT RenderScenePS(VS_OUTPUT In) 
{ 
    PS_OUTPUT Output;

    Output.RGBColor = In.Color;

    return Output;
}

// Technique
technique RenderSceneSimple
{
    pass P0
    {          
        VertexShader = compile vs_2_0 RenderSceneVS();
        PixelShader  = compile ps_2_0 RenderScenePS(); 
    }
}
```

<span data-ttu-id="09b9f-114">Direct3D 11 では、引き続き HLSL シェーダーを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-114">In Direct3D 11, we can still use our HLSL shaders.</span></span> <span data-ttu-id="09b9f-115">各シェーダーは、それぞれの HLSL ファイルに配置して、Visual Studio で別々のファイルにコンパイルされるようにします。その後で、個々の Direct3D リソースとして読み込みます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-115">We put each shader in its own HLSL file so that Visual Studio compiles them into separate files and later, we'll load them as separate Direct3D resources.</span></span> <span data-ttu-id="09b9f-116">これらのシェーダーは DirectX 9.1 GPU 向けに記述されているため、ターゲット レベルを[シェーダー モデル 4 レベル 9\_1 (/4\_0\_level\_9\_1)](https://msdn.microsoft.com/library/windows/desktop/ff476876) に設定します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-116">We set the target level to [Shader Model 4 Level 9\_1 (/4\_0\_level\_9\_1)](https://msdn.microsoft.com/library/windows/desktop/ff476876) because these shaders are written for DirectX 9.1 GPUs.</span></span>

<span data-ttu-id="09b9f-117">入力レイアウトを定義する際に、入力レイアウトが表す、頂点ごとのデータを格納するために使うデータ構造体がシステム メモリと GPU メモリで同じことを確認しました。</span><span class="sxs-lookup"><span data-stu-id="09b9f-117">When we defined the input layout, we made sure it represented the same data structure we use to store per-vertex data in system memory and in GPU memory.</span></span> <span data-ttu-id="09b9f-118">同じように、頂点シェーダーの出力がピクセル シェーダーへの入力として使われる構造体と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="09b9f-118">Similarly, the output of a vertex shader should match the structure used as input to the pixel shader.</span></span> <span data-ttu-id="09b9f-119">規則は C++ の関数間でデータを受け渡す場合と異なり、構造体の末尾の使わない変数は省略できます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-119">The rules are not the same as passing data from one function to another in C++; you can omit unused variables at the end of the structure.</span></span> <span data-ttu-id="09b9f-120">ただし、順序を並べ替えることはできず、データ構造体の真ん中のコンテンツをスキップすることもできません。</span><span class="sxs-lookup"><span data-stu-id="09b9f-120">But the order can't be rearranged and you can't skip content in the middle of the data structure.</span></span>

> <span data-ttu-id="09b9f-121">**注:** をピクセル シェーダーに頂点シェーダーをバインドの direct3d9 の規則は、direct3d11 の規則よりも緩やかでした。</span><span class="sxs-lookup"><span data-stu-id="09b9f-121">**Note** The rules in Direct3D 9 for binding vertex shaders to pixel shaders were more relaxed than the rules in Direct3D 11.</span></span> <span data-ttu-id="09b9f-122">Direct3D 9 の配置は、柔軟ですが、効率的ではありませんでした。</span><span class="sxs-lookup"><span data-stu-id="09b9f-122">The Direct3D 9 arrangement was flexible, but inefficient.</span></span>

 

<span data-ttu-id="09b9f-123">HLSL ファイルでは、シェーダー セマンティクスの以前の構文 (たとえば、SV\_TARGET の代わりに COLOR) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-123">It's possible that your HLSL files uses older syntax for shader semantics - for example, COLOR instead of SV\_TARGET.</span></span> <span data-ttu-id="09b9f-124">その場合は、HLSL 互換モード (/Gec コンパイラ オプション) を有効にするか、シェーダー [セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)を現行の構文に更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="09b9f-124">If so you'll need to enable HLSL compatibility mode (/Gec compiler option) or update the shader [semantics](https://msdn.microsoft.com/library/windows/desktop/bb509647) to the current syntax.</span></span> <span data-ttu-id="09b9f-125">この例の頂点シェーダーは現行の構文で更新されています。</span><span class="sxs-lookup"><span data-stu-id="09b9f-125">The vertex shader in this example has been updated with current syntax.</span></span>

<span data-ttu-id="09b9f-126">ハードウェア変換の頂点シェーダーを次に示します。今回は、個別のファイルに定義しています。</span><span class="sxs-lookup"><span data-stu-id="09b9f-126">Here's our hardware transformation vertex shader, this time defined in its own file.</span></span>

> <span data-ttu-id="09b9f-127">**注:**、sv \_position システム値セマンティクスを出力する頂点シェーダーが必要です。</span><span class="sxs-lookup"><span data-stu-id="09b9f-127">**Note**Vertex shaders are required to output the SV\_POSITION system value semantic.</span></span> <span data-ttu-id="09b9f-128">このセマンティクスは頂点の位置データを座標値に解決します。x は -1 ～ 1 の値に、y は -1 ～ 1 の値になり、z は元の同次座標 w の値で割られ (z/w)、w は 1 を元の w の値で割った値 (1/w) になります。</span><span class="sxs-lookup"><span data-stu-id="09b9f-128">This semantic resolves the vertex position data to coordinate values where x is between -1 and 1, y is between -1 and 1, z is divided by the original homogeneous coordinate w value (z/w), and w is 1 divided by the original w value (1/w).</span></span>

 

<span data-ttu-id="09b9f-129">HLSL 頂点シェーダー (機能レベル 9.1)</span><span class="sxs-lookup"><span data-stu-id="09b9f-129">HLSL vertex shader (feature level 9.1)</span></span>

```cpp
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
    matrix mWorld;       // world matrix for object
    matrix View;        // view matrix
    matrix Projection;  // projection matrix
};

struct VS_INPUT
{
    float3 vPos   : POSITION;
    float3 vColor : COLOR0;
};

struct VS_OUTPUT
{
    float4 Position : SV_POSITION; // Vertex shaders must output SV_POSITION
    float4 Color    : COLOR0;
};

VS_OUTPUT main(VS_INPUT input) // main is the default function name
{
    VS_OUTPUT Output;

    float4 pos = float4(input.vPos, 1.0f);

    // Transform the position from object space to homogeneous projection space
    pos = mul(pos, mWorld);
    pos = mul(pos, View);
    pos = mul(pos, Projection);
    Output.Position = pos;

    // Just pass through the color data
    Output.Color = float4(input.vColor, 1.0f);

    return Output;
}
```

<span data-ttu-id="09b9f-130">パススルー ピクセル シェーダーに必要なコードはこれだけです。</span><span class="sxs-lookup"><span data-stu-id="09b9f-130">This is all we need for our pass-through pixel shader.</span></span> <span data-ttu-id="09b9f-131">パススルーと呼んでいますが、実際には、各ピクセルの透視補正補間された色データを取得します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-131">Even though we call it a pass-through, it's actually getting perspective-correct interpolated color data for each pixel.</span></span> <span data-ttu-id="09b9f-132">API で要求されているとおり、ピクセル シェーダーによって色値の出力に SV\_TARGET システム値セマンティクスが適用されます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-132">Note that the SV\_TARGET system value semantic is applied to the color value output by our pixel shader as required by the API.</span></span>

> <span data-ttu-id="09b9f-133">**注:** シェーダー レベル 9 \_x ピクセル シェーダーは、sv \_position システム値セマンティクスから読み取ることができません。</span><span class="sxs-lookup"><span data-stu-id="09b9f-133">**Note**Shader level 9\_x pixel shaders cannot read from the SV\_POSITION system value semantic.</span></span> <span data-ttu-id="09b9f-134">モデル 4.0 (以上) のピクセル シェーダーでは、SV\_POSITION を使って、画面上のピクセル位置を取得できます。x は 0 からレンダー ターゲットの幅までの値に、y は 0 からレンダー ターゲットの高さまでの値になります (各オフセットは 0.5 単位)。</span><span class="sxs-lookup"><span data-stu-id="09b9f-134">Model 4.0 (and higher) pixel shaders can use SV\_POSITION to retrieve the pixel location on the screen, where x is between 0 and the render target width and y is between 0 and the render target height (each offset by 0.5).</span></span>

 

<span data-ttu-id="09b9f-135">ほとんどのピクセル シェーダーはパススルーよりはるかに複雑です。上位の Direct3D 機能レベルでは、シェーダー プログラムごとにより多くの計算を実行できます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-135">Most pixel shaders are much more complex than a pass through; note that higher Direct3D feature levels allow a much greater number of calculations per shader program.</span></span>

<span data-ttu-id="09b9f-136">HLSL ピクセル シェーダー (機能レベル 9.1)</span><span class="sxs-lookup"><span data-stu-id="09b9f-136">HLSL pixel shader (feature level 9.1)</span></span>

```cpp
struct PS_INPUT
{
    float4 Position : SV_POSITION;  // interpolated vertex position (system value)
    float4 Color    : COLOR0;       // interpolated diffuse color
};

struct PS_OUTPUT
{
    float4 RGBColor : SV_TARGET;  // pixel color (your PS computes this system value)
};

PS_OUTPUT main(PS_INPUT In)
{
    PS_OUTPUT Output;

    Output.RGBColor = In.Color;

    return Output;
}
```

## <a name="compile-and-load-shaders"></a><span data-ttu-id="09b9f-137">シェーダーのコンパイルと読み込み</span><span class="sxs-lookup"><span data-stu-id="09b9f-137">Compile and load shaders</span></span>


<span data-ttu-id="09b9f-138">Direct3D 9 ゲームでは、プログラム可能なパイプラインを実装する便利な方法として Effects ライブラリをよく使いました。</span><span class="sxs-lookup"><span data-stu-id="09b9f-138">Direct3D 9 games often used the Effects library as a convenient way to implement programmable pipelines.</span></span> <span data-ttu-id="09b9f-139">エフェクトは [**D3DXCreateEffectFromFile function**](https://msdn.microsoft.com/library/windows/desktop/bb172768) メソッドを使って実行時にコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-139">Effects could be compiled at run-time using the [**D3DXCreateEffectFromFile function**](https://msdn.microsoft.com/library/windows/desktop/bb172768) method.</span></span>

<span data-ttu-id="09b9f-140">Direct3D 9 でのエフェクトの読み込み</span><span class="sxs-lookup"><span data-stu-id="09b9f-140">Loading an effect in Direct3D 9</span></span>

```cpp
// Turn off preshader optimization to keep calculations on the GPU
DWORD dwShaderFlags = D3DXSHADER_NO_PRESHADER;

// Only enable debug info when compiling for a debug target
#if defined (DEBUG) || defined (_DEBUG)
dwShaderFlags |= D3DXSHADER_DEBUG;
#endif

D3DXCreateEffectFromFile(
    m_pd3dDevice,
    L"CubeShaders.fx",
    NULL,
    NULL,
    dwShaderFlags,
    NULL,
    &m_pEffect,
    NULL
    );
```

<span data-ttu-id="09b9f-141">Direct3D 11 では、バイナリ リソースとしてシェーダー プログラムを使います。</span><span class="sxs-lookup"><span data-stu-id="09b9f-141">Direct3D 11 works with shader programs as binary resources.</span></span> <span data-ttu-id="09b9f-142">シェーダーは、プロジェクトのビルド時にコンパイルされた後、リソースとして扱われます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-142">Shaders are compiled when the project is built and then treated as resources.</span></span> <span data-ttu-id="09b9f-143">そのため、この例では、シェーダーのバイトコードをシステム メモリに読み込み、Direct3D デバイス インターフェイスを使って各シェーダーの Direct3D リソースを作成し、各フレームを設定するときに Direct3D シェーダー リソースを参照します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-143">So our example will load the shader bytecode into system memory, use the Direct3D device interface to create a Direct3D resource for each shader, and point to the Direct3D shader resources when we set up each frame.</span></span>

<span data-ttu-id="09b9f-144">Direct3D 11 でのシェーダー リソースの読み込み</span><span class="sxs-lookup"><span data-stu-id="09b9f-144">Loading a shader resource in Direct3D 11</span></span>

```cpp
// BasicReaderWriter is a tested file loader used in SDK samples.
BasicReaderWriter^ readerWriter = ref new BasicReaderWriter();


// Load vertex shader:
Platform::Array<byte>^ vertexShaderData =
    readerWriter->ReadData("CubeVertexShader.cso");

// This call allocates a device resource, validates the vertex shader 
// with the device feature level, and stores the vertex shader bits in 
// graphics memory.
m_d3dDevice->CreateVertexShader(
    vertexShaderData->Data,
    vertexShaderData->Length,
    nullptr,
    &m_vertexShader
    );
```

<span data-ttu-id="09b9f-145">コンパイル済みのアプリ パッケージにシェーダーのバイトコードを含めるには、単純に Visual Studio プロジェクトに HLSL ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-145">To include the shader bytecode in your compiled app package, just add the HLSL file to the Visual Studio project.</span></span> <span data-ttu-id="09b9f-146">Visual Studio では、[エフェクト コンパイラ ツール](https://msdn.microsoft.com/library/windows/desktop/bb232919) (FXC) を使って、HLSL ファイルをコンパイル済みシェーダー オブジェクト (.CSO ファイル) にコンパイルし、それらをアプリ パッケージに含めます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-146">Visual Studio will use the [Effect-Compiler Tool](https://msdn.microsoft.com/library/windows/desktop/bb232919) (FXC) to compile HLSL files into compiled shader objects (.CSO files) and include them in the app package.</span></span>

> <span data-ttu-id="09b9f-147">**注:**  HLSL コンパイラの適切なターゲット機能レベルを設定してください: Visual Studio で HLSL ソース ファイルを右クリックし、プロパティを選択し、[**シェーダー モデル**の設定を変更**HLSL コンパイラ] -&gt;一般的な**します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-147">**Note** Be sure to set the correct target feature level for the HLSL compiler: right-click the HLSL source file in Visual Studio, select Properties, and change the **Shader Model** setting under **HLSL Compiler -&gt; General**.</span></span> <span data-ttu-id="09b9f-148">アプリで Direct3D シェーダー リソースを作成するときに、Direct3D ではこのプロパティとハードウェアの機能を照合します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-148">Direct3D checks this property against the hardware capabilities when your app creates the Direct3D shader resource.</span></span>

 

![HLSL シェーダーのプロパティ](images/hlslshaderpropertiesmenu.png)![HLSL シェーダーの種類](images/hlslshadertypeproperties.png)

<span data-ttu-id="09b9f-151">ここは、Direct3D 9 の頂点ストリームの宣言に対応する入力レイアウトを作成するのに適した場所です。</span><span class="sxs-lookup"><span data-stu-id="09b9f-151">This is a good place to create the input layout, which corresponds to the vertex stream declaration in Direct3D 9.</span></span> <span data-ttu-id="09b9f-152">頂点ごとのデータ構造体は、頂点シェーダーで使う構造体と一致する必要があります。Direct3D 11 では、入力レイアウトをより細かく制御できます。そのため、浮動小数点ベクトルの配列サイズとビット長を定義し、頂点シェーダーのセマンティクスを指定できます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-152">The per-vertex data structure needs to match what the vertex shader uses; in Direct3D 11 we have more control over the input layout; we can define the array size and bit length of floating-point vectors and specify semantics for the vertex shader.</span></span> <span data-ttu-id="09b9f-153">[**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) 構造体を作成し、それを使って、頂点ごとのデータがどのような構造になっているかを Direct3D に通知します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-153">We create a [**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) structure and use it to inform Direct3D what the per-vertex data will look like.</span></span> <span data-ttu-id="09b9f-154">API では入力レイアウトを頂点シェーダー リソースに照らして検証するため、頂点シェーダーを読み込んで、入力レイアウトを定義するまで待ちます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-154">We waited until after we loaded the vertex shader to define the input layout because the API validates the input layout against the vertex shader resource.</span></span> <span data-ttu-id="09b9f-155">入力レイアウトに互換性がない場合は、Direct3D から例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-155">If the input layout isn't compatible then Direct3D throws an exception.</span></span>

<span data-ttu-id="09b9f-156">頂点ごとのデータは互換性のある型でシステム メモリに格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="09b9f-156">Per-vertex data has to be stored in compatible types in system memory.</span></span> <span data-ttu-id="09b9f-157">DirectXMath データ型は便利です。たとえば、DXGI\_FORMAT\_R32G32B32\_FLOAT は [**XMFLOAT3**](https://msdn.microsoft.com/library/windows/desktop/ee419475) に対応しています。</span><span class="sxs-lookup"><span data-stu-id="09b9f-157">DirectXMath data types can help; for example, DXGI\_FORMAT\_R32G32B32\_FLOAT corresponds to [**XMFLOAT3**](https://msdn.microsoft.com/library/windows/desktop/ee419475).</span></span>

> <span data-ttu-id="09b9f-158">**注:** 定数バッファーは、一度に 4 つの浮動小数点数にアラインメントする固定入力レイアウトを使用します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-158">**Note** Constant buffers use a fixed input layout that aligns to four floating-point numbers at a time.</span></span> <span data-ttu-id="09b9f-159">定数バッファー データには [**XMFLOAT4**
            ](https://msdn.microsoft.com/library/windows/desktop/ee419608) (とその派生) をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="09b9f-159">[**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) (and its derivatives) are recommended for constant buffer data.</span></span>

 

<span data-ttu-id="09b9f-160">Direct3D 11 での入力レイアウトの設定</span><span class="sxs-lookup"><span data-stu-id="09b9f-160">Setting the input layout in Direct3D 11</span></span>

```cpp
// Create input layout:
const D3D11_INPUT_ELEMENT_DESC vertexDesc[] = 
{
    { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT,
        0, 0,  D3D11_INPUT_PER_VERTEX_DATA, 0 },

    { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 
        0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};
```

## <a name="create-geometry-resources"></a><span data-ttu-id="09b9f-161">ジオメトリ リソースの作成</span><span class="sxs-lookup"><span data-stu-id="09b9f-161">Create geometry resources</span></span>


<span data-ttu-id="09b9f-162">Direct3D 9 では、ジオメトリ リソースを格納するために、Direct3D デバイスにバッファーを作成し、メモリをロックして、CPU メモリから GPU メモリにデータをコピーしました。</span><span class="sxs-lookup"><span data-stu-id="09b9f-162">In Direct3D 9 we stored geometry resources by creating buffers on the Direct3D device, locking the memory, and copying data from CPU memory to GPU memory.</span></span>

<span data-ttu-id="09b9f-163">Direct3D 9</span><span class="sxs-lookup"><span data-stu-id="09b9f-163">Direct3D 9</span></span>

```cpp
// Create vertex buffer:
VOID* pVertices;

// In Direct3D 9 we create the buffer, lock it, and copy the data from 
// system memory to graphics memory.
m_pd3dDevice->CreateVertexBuffer(
    sizeof(CubeVertices),
    0,
    D3DFVF_XYZ | D3DFVF_DIFFUSE,
    D3DPOOL_MANAGED,
    &pVertexBuffer,
    NULL);

pVertexBuffer->Lock(
    0,
    sizeof(CubeVertices),
    &pVertices,
    0);

memcpy(pVertices, CubeVertices, sizeof(CubeVertices));
pVertexBuffer->Unlock();
```

<span data-ttu-id="09b9f-164">DirectX 11 では、もっと簡単なプロセスに従います。</span><span class="sxs-lookup"><span data-stu-id="09b9f-164">DirectX 11 follows a simpler process.</span></span> <span data-ttu-id="09b9f-165">データは、API によって自動的にシステム メモリから GPU にコピーされます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-165">The API automatically copies the data from system memory to the GPU.</span></span> <span data-ttu-id="09b9f-166">COM のスマート ポインターを使うと、プログラミングをさらに簡単にできます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-166">We can use COM smart pointers to help make programming easier.</span></span>

<span data-ttu-id="09b9f-167">DirectX 11</span><span class="sxs-lookup"><span data-stu-id="09b9f-167">DirectX 11</span></span>

```cpp
D3D11_SUBRESOURCE_DATA vertexBufferData = {0};
vertexBufferData.pSysMem = CubeVertices;
vertexBufferData.SysMemPitch = 0;
vertexBufferData.SysMemSlicePitch = 0;
CD3D11_BUFFER_DESC vertexBufferDesc(
    sizeof(CubeVertices),
    D3D11_BIND_VERTEX_BUFFER);
  
// This call allocates a device resource for the vertex buffer and copies
// in the data.
m_d3dDevice->CreateBuffer(
    &vertexBufferDesc,
    &vertexBufferData,
    &m_vertexBuffer
    );
```

## <a name="implement-the-rendering-chain"></a><span data-ttu-id="09b9f-168">レンダリング チェーンの実装</span><span class="sxs-lookup"><span data-stu-id="09b9f-168">Implement the rendering chain</span></span>


<span data-ttu-id="09b9f-169">Direct3D 9 ゲームでは、エフェクト ベースのレンダリング チェーンをよく使いました。</span><span class="sxs-lookup"><span data-stu-id="09b9f-169">Direct3D 9 games often used an effect-based rendering chain.</span></span> <span data-ttu-id="09b9f-170">この種のレンダリング チェーンでは、エフェクト オブジェクトを設定し、それを必要なリソースと一緒に提供して、各パスをレンダリングできるようにします。</span><span class="sxs-lookup"><span data-stu-id="09b9f-170">This type of rendering chain sets up the effect object, provides it with the resources it needs, and lets it render each pass.</span></span>

<span data-ttu-id="09b9f-171">Direct3D 9 のレンダリング チェーン</span><span class="sxs-lookup"><span data-stu-id="09b9f-171">Direct3D 9 rendering chain</span></span>

```cpp
// Clear the render target and the z-buffer.
m_pd3dDevice->Clear(
    0, NULL,
    D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER,
    D3DCOLOR_ARGB(0, 45, 50, 170),
    1.0f, 0
    );

// Set the effect technique
m_pEffect->SetTechnique("RenderSceneSimple");

// Rotate the cube 1 degree per frame.
D3DXMATRIX world;
D3DXMatrixRotationY(&world, D3DXToRadian(m_frameCount++));


// Set the matrices up using traditional functions.
m_pEffect->SetMatrix("g_mWorld", &world);
m_pEffect->SetMatrix("g_View", &m_view);
m_pEffect->SetMatrix("g_Projection", &m_projection);

// Render the scene using the Effects library.
if(SUCCEEDED(m_pd3dDevice->BeginScene()))
{
    // Begin rendering effect passes.
    UINT passes = 0;
    m_pEffect->Begin(&passes, 0);
    
    for (UINT i = 0; i < passes; i++)
    {
        m_pEffect->BeginPass(i);
        
        // Send vertex data to the pipeline.
        m_pd3dDevice->SetFVF(D3DFVF_XYZ | D3DFVF_DIFFUSE);
        m_pd3dDevice->SetStreamSource(
            0, pVertexBuffer,
            0, sizeof(VertexPositionColor)
            );
        m_pd3dDevice->SetIndices(pIndexBuffer);
        
        // Draw the cube.
        m_pd3dDevice->DrawIndexedPrimitive(
            D3DPT_TRIANGLELIST,
            0, 0, 8, 0, 12
            );
        m_pEffect->EndPass();
    }
    m_pEffect->End();
    
    // End drawing.
    m_pd3dDevice->EndScene();
}

// Present frame:
// Show the frame on the primary surface.
m_pd3dDevice->Present(NULL, NULL, NULL, NULL);
```

<span data-ttu-id="09b9f-172">DirectX 11 のレンダリング チェーンでは、引き続き同じタスクを実行しますが、レンダリング パスを実装する必要がある点が異なります。</span><span class="sxs-lookup"><span data-stu-id="09b9f-172">The DirectX 11 rendering chain will still do the same tasks, but the rendering passes need to be implemented differently.</span></span> <span data-ttu-id="09b9f-173">仕様を FX ファイルに配置し、レンダリング手法を C++ コードに対してほぼ不透明にする代わりに、C++ ですべてレンダリングを設定します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-173">Instead of putting the specifics in FX files and letting the rendering techniques be more-or-less opaque to our C++ code, we'll set up all our rendering in C++.</span></span>

<span data-ttu-id="09b9f-174">レンダリング チェーンは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="09b9f-174">Here's how our rendering chain will look.</span></span> <span data-ttu-id="09b9f-175">頂点シェーダーを読み込んだ後に作成した入力レイアウトを提供し、各シェーダー オブジェクトを渡して、使うシェーダーごとに定数バッファーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="09b9f-175">We need to supply the input layout we created after loading the vertex shader, supply each of the shader objects, and specify the constant buffers for each shader to use.</span></span> <span data-ttu-id="09b9f-176">この例には複数のレンダリング パスは含まれていませんが、含まれている場合は、各パスに同じようなレンダリング チェーンを実装し、必要に応じて設定を変更します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-176">This example doesn't include multiple rendering passes, but if it did we'd do a similar rendering chain for each pass, changing the setup as needed.</span></span>

<span data-ttu-id="09b9f-177">Direct3D 11 のレンダリング チェーン</span><span class="sxs-lookup"><span data-stu-id="09b9f-177">Direct3D 11 rendering chain</span></span>

```cpp
// Clear the back buffer.
const float midnightBlue[] = { 0.098f, 0.098f, 0.439f, 1.000f };
m_d3dContext->ClearRenderTargetView(
    m_renderTargetView.Get(),
    midnightBlue
    );

// Set the render target. This starts the drawing operation.
m_d3dContext->OMSetRenderTargets(
    1,  // number of render target views for this drawing operation.
    m_renderTargetView.GetAddressOf(),
    nullptr
    );


// Rotate the cube 1 degree per frame.
XMStoreFloat4x4(
    &m_constantBufferData.model, 
    XMMatrixTranspose(XMMatrixRotationY(m_frameCount++ * XM_PI / 180.f))
    );

// Copy the updated constant buffer from system memory to video memory.
m_d3dContext->UpdateSubresource(
    m_constantBuffer.Get(),
    0,      // update the 0th subresource
    NULL,   // use the whole destination
    &m_constantBufferData,
    0,      // default pitch
    0       // default pitch
    );


// Send vertex data to the Input Assembler stage.
UINT stride = sizeof(VertexPositionColor);
UINT offset = 0;

m_d3dContext->IASetVertexBuffers(
    0,  // start with the first vertex buffer
    1,  // one vertex buffer
    m_vertexBuffer.GetAddressOf(),
    &stride,
    &offset
    );

m_d3dContext->IASetIndexBuffer(
    m_indexBuffer.Get(),
    DXGI_FORMAT_R16_UINT,
    0   // no offset
    );

m_d3dContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
m_d3dContext->IASetInputLayout(m_inputLayout.Get());


// Set the vertex shader.
m_d3dContext->VSSetShader(
    m_vertexShader.Get(),
    nullptr,
    0
    );

// Set the vertex shader constant buffer data.
m_d3dContext->VSSetConstantBuffers(
    0,  // register 0
    1,  // one constant buffer
    m_constantBuffer.GetAddressOf()
    );


// Set the pixel shader.
m_d3dContext->PSSetShader(
    m_pixelShader.Get(),
    nullptr,
    0
    );


// Draw the cube.
m_d3dContext->DrawIndexed(
    m_indexCount,
    0,  // start with index 0
    0   // start with vertex 0
    );
```

<span data-ttu-id="09b9f-178">スワップ チェーンはグラフィックス インフラストラクチャの一部です。そのため、DXGI スワップ チェーンを使って、完成したフレームを表示します。</span><span class="sxs-lookup"><span data-stu-id="09b9f-178">The swap chain is part of graphics infrastructure, so we use our DXGI swap chain to present the completed frame.</span></span> <span data-ttu-id="09b9f-179">DXGI では、次の vsync まで呼び出しがブロックされます。その後、制御が返されると、このゲーム ループでは次の反復に進むことができます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-179">DXGI blocks the call until the next vsync; then it returns, and our game loop can continue to the next iteration.</span></span>

<span data-ttu-id="09b9f-180">DirectX 11 を使った画面へのフレームの表示</span><span class="sxs-lookup"><span data-stu-id="09b9f-180">Presenting a frame to the screen using DirectX 11</span></span>

```cpp
m_swapChain->Present(1, 0);
```

<span data-ttu-id="09b9f-181">作成したレンダリング チェーンは、[**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドに実装したゲーム ループから呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="09b9f-181">The rendering chain we just created will be called from a game loop implemented in the [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) method.</span></span> <span data-ttu-id="09b9f-182">これについては、「[パート 3: ゲーム ループの移植](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="09b9f-182">This is shown in [Part 3: Viewport and game loop](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md).</span></span>

 

 




