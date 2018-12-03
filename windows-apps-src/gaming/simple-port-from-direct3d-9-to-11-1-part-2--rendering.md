---
title: レンダリング フレームワークの変換
description: ジオメトリ バッファーを移植する方法、HLSL シェーダー プログラムをコンパイルして読み込む方法、Direct3D 11 のレンダリング チェーンを実装する方法など、Direct3D 9 の簡単なレンダリング フレームワークを Direct3D 11 に変換する方法について説明します。
ms.assetid: f6ca1147-9bb8-719a-9a2c-b7ee3e34bd18
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, レンダリング フレームワーク, 変換, Direct3D 9, Direct3D 11
ms.localizationpriority: medium
ms.openlocfilehash: aba723a5ee2443664d6d640adc124b991ff0da7e
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8472106"
---
# <a name="convert-the-rendering-framework"></a>レンダリング フレームワークの変換



**要約**

-   [パート 1: Direct3D 11 の初期化](simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md)
-   パート 2: レンダリング フレームワークの変換
-   [パート 3: ゲーム ループの移植](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md)


ジオメトリ バッファーを移植する方法、HLSL シェーダー プログラムをコンパイルして読み込む方法、Direct3D 11 のレンダリング チェーンを実装する方法など、Direct3D 9 の簡単なレンダリング フレームワークを Direct3D 11 に変換する方法について説明します。 「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」のパート 2 です。

## <a name="convert-effects-to-hlsl-shaders"></a>HLSL シェーダーへのエフェクトの変換


次の例は、従来のエフェクト API 向けに記述された、ハードウェアの頂点変換とパススルー色データの簡単な D3DX の手法です。

Direct3D 9 シェーダー コード

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

Direct3D 11 では、引き続き HLSL シェーダーを使うことができます。 各シェーダーは、それぞれの HLSL ファイルに配置して、Visual Studio で別々のファイルにコンパイルされるようにします。その後で、個々の Direct3D リソースとして読み込みます。 これらのシェーダーは DirectX 9.1 GPU 向けに記述されているため、ターゲット レベルを[シェーダー モデル 4 レベル 9\_1 (/4\_0\_level\_9\_1)](https://msdn.microsoft.com/library/windows/desktop/ff476876) に設定します。

入力レイアウトを定義する際に、入力レイアウトが表す、頂点ごとのデータを格納するために使うデータ構造体がシステム メモリと GPU メモリで同じことを確認しました。 同じように、頂点シェーダーの出力がピクセル シェーダーへの入力として使われる構造体と一致する必要があります。 規則は C++ の関数間でデータを受け渡す場合と異なり、構造体の末尾の使わない変数は省略できます。 ただし、順序を並べ替えることはできず、データ構造体の真ん中のコンテンツをスキップすることもできません。

> **注:** をピクセル シェーダーに頂点シェーダーをバインドの direct3d9 の規則は、direct3d11 の規則よりも緩やかでした。 Direct3D 9 の配置は、柔軟ですが、効率的ではありませんでした。

 

HLSL ファイルでは、シェーダー セマンティクスの以前の構文 (たとえば、SV\_TARGET の代わりに COLOR) を使うことができます。 その場合は、HLSL 互換モード (/Gec コンパイラ オプション) を有効にするか、シェーダー [セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)を現行の構文に更新する必要があります。 この例の頂点シェーダーは現行の構文で更新されています。

ハードウェア変換の頂点シェーダーを次に示します。今回は、個別のファイルに定義しています。

> **注:**、sv \_position システム値セマンティクスを出力する頂点シェーダーが必要です。 このセマンティクスは頂点の位置データを座標値に解決します。x は -1 ～ 1 の値に、y は -1 ～ 1 の値になり、z は元の同次座標 w の値で割られ (z/w)、w は 1 を元の w の値で割った値 (1/w) になります。

 

HLSL 頂点シェーダー (機能レベル 9.1)

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

パススルー ピクセル シェーダーに必要なコードはこれだけです。 パススルーと呼んでいますが、実際には、各ピクセルの透視補正補間された色データを取得します。 API で要求されているとおり、ピクセル シェーダーによって色値の出力に SV\_TARGET システム値セマンティクスが適用されます。

> **注:** シェーダー レベル 9 \_x ピクセル シェーダーは、sv \_position システム値セマンティクスから読み取ることができません。 モデル 4.0 (以上) のピクセル シェーダーでは、SV\_POSITION を使って、画面上のピクセル位置を取得できます。x は 0 からレンダー ターゲットの幅までの値に、y は 0 からレンダー ターゲットの高さまでの値になります (各オフセットは 0.5 単位)。

 

ほとんどのピクセル シェーダーはパススルーよりはるかに複雑です。上位の Direct3D 機能レベルでは、シェーダー プログラムごとにより多くの計算を実行できます。

HLSL ピクセル シェーダー (機能レベル 9.1)

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

## <a name="compile-and-load-shaders"></a>シェーダーのコンパイルと読み込み


Direct3D 9 ゲームでは、プログラム可能なパイプラインを実装する便利な方法として Effects ライブラリをよく使いました。 エフェクトは [**D3DXCreateEffectFromFile function**](https://msdn.microsoft.com/library/windows/desktop/bb172768) メソッドを使って実行時にコンパイルできます。

Direct3D 9 でのエフェクトの読み込み

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

Direct3D 11 では、バイナリ リソースとしてシェーダー プログラムを使います。 シェーダーは、プロジェクトのビルド時にコンパイルされた後、リソースとして扱われます。 そのため、この例では、シェーダーのバイトコードをシステム メモリに読み込み、Direct3D デバイス インターフェイスを使って各シェーダーの Direct3D リソースを作成し、各フレームを設定するときに Direct3D シェーダー リソースを参照します。

Direct3D 11 でのシェーダー リソースの読み込み

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

コンパイル済みのアプリ パッケージにシェーダーのバイトコードを含めるには、単純に Visual Studio プロジェクトに HLSL ファイルを追加します。 Visual Studio では、[エフェクト コンパイラ ツール](https://msdn.microsoft.com/library/windows/desktop/bb232919) (FXC) を使って、HLSL ファイルをコンパイル済みシェーダー オブジェクト (.CSO ファイル) にコンパイルし、それらをアプリ パッケージに含めます。

> **注:**  HLSL コンパイラの適切なターゲット機能レベルを設定してください: Visual Studio で HLSL ソース ファイルを右クリックし、プロパティを選択し、[**シェーダー モデル**の設定を変更**HLSL コンパイラ] -&gt;一般的な**します。 アプリで Direct3D シェーダー リソースを作成するときに、Direct3D ではこのプロパティとハードウェアの機能を照合します。

 

![HLSL シェーダーのプロパティ](images/hlslshaderpropertiesmenu.png)![HLSL シェーダーの種類](images/hlslshadertypeproperties.png)

ここは、Direct3D 9 の頂点ストリームの宣言に対応する入力レイアウトを作成するのに適した場所です。 頂点ごとのデータ構造体は、頂点シェーダーで使う構造体と一致する必要があります。Direct3D 11 では、入力レイアウトをより細かく制御できます。そのため、浮動小数点ベクトルの配列サイズとビット長を定義し、頂点シェーダーのセマンティクスを指定できます。 [**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) 構造体を作成し、それを使って、頂点ごとのデータがどのような構造になっているかを Direct3D に通知します。 API では入力レイアウトを頂点シェーダー リソースに照らして検証するため、頂点シェーダーを読み込んで、入力レイアウトを定義するまで待ちます。 入力レイアウトに互換性がない場合は、Direct3D から例外がスローされます。

頂点ごとのデータは互換性のある型でシステム メモリに格納する必要があります。 DirectXMath データ型は便利です。たとえば、DXGI\_FORMAT\_R32G32B32\_FLOAT は [**XMFLOAT3**](https://msdn.microsoft.com/library/windows/desktop/ee419475) に対応しています。

> **注:** 定数バッファーは、一度に 4 つの浮動小数点数にアラインメントする固定入力レイアウトを使用します。 定数バッファー データには [**XMFLOAT4**
            ](https://msdn.microsoft.com/library/windows/desktop/ee419608) (とその派生) をお勧めします。

 

Direct3D 11 での入力レイアウトの設定

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

## <a name="create-geometry-resources"></a>ジオメトリ リソースの作成


Direct3D 9 では、ジオメトリ リソースを格納するために、Direct3D デバイスにバッファーを作成し、メモリをロックして、CPU メモリから GPU メモリにデータをコピーしました。

Direct3D 9

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

DirectX 11 では、もっと簡単なプロセスに従います。 データは、API によって自動的にシステム メモリから GPU にコピーされます。 COM のスマート ポインターを使うと、プログラミングをさらに簡単にできます。

DirectX 11

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

## <a name="implement-the-rendering-chain"></a>レンダリング チェーンの実装


Direct3D 9 ゲームでは、エフェクト ベースのレンダリング チェーンをよく使いました。 この種のレンダリング チェーンでは、エフェクト オブジェクトを設定し、それを必要なリソースと一緒に提供して、各パスをレンダリングできるようにします。

Direct3D 9 のレンダリング チェーン

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

DirectX 11 のレンダリング チェーンでは、引き続き同じタスクを実行しますが、レンダリング パスを実装する必要がある点が異なります。 仕様を FX ファイルに配置し、レンダリング手法を C++ コードに対してほぼ不透明にする代わりに、C++ ですべてレンダリングを設定します。

レンダリング チェーンは次のようになります。 頂点シェーダーを読み込んだ後に作成した入力レイアウトを提供し、各シェーダー オブジェクトを渡して、使うシェーダーごとに定数バッファーを指定する必要があります。 この例には複数のレンダリング パスは含まれていませんが、含まれている場合は、各パスに同じようなレンダリング チェーンを実装し、必要に応じて設定を変更します。

Direct3D 11 のレンダリング チェーン

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

スワップ チェーンはグラフィックス インフラストラクチャの一部です。そのため、DXGI スワップ チェーンを使って、完成したフレームを表示します。 DXGI では、次の vsync まで呼び出しがブロックされます。その後、制御が返されると、このゲーム ループでは次の反復に進むことができます。

DirectX 11 を使った画面へのフレームの表示

```cpp
m_swapChain->Present(1, 0);
```

作成したレンダリング チェーンは、[**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドに実装したゲーム ループから呼び出されます。 これについては、「[パート 3: ゲーム ループの移植](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md)」をご覧ください。

 

 




