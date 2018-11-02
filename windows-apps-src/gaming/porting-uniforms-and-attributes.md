---
author: mtoepke
title: OpenGL ES 2.0 のバッファー、uniform、頂点属性 を Direct3D に移植する
description: OpenGL ES 2.0 から Direct3D 11 に移植するプロセスでは、アプリとシェーダー プログラムの間でデータを受け渡すための構文と API の動作を変更する必要があります。
ms.assetid: 9b215874-6549-80c5-cc70-c97b571c74fe
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, OpenGL, Direct3D, バッファー, uniform, 頂点属性
ms.localizationpriority: medium
ms.openlocfilehash: bc0192eb4b89ef91bc895a96e46cd39524f24c44
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5929812"
---
# <a name="compare-opengl-es-20-buffers-uniforms-and-vertex-attributes-to-direct3d"></a>OpenGL ES 2.0 のバッファー、uniform、頂点 attribute と Direct3D の比較




**重要な API**

-   [**ID3D11Device1::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/hh404575)
-   [**ID3D11Device1::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512)
-   [**ID3D11DeviceContext1::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454)

OpenGL ES 2.0 から Direct3D 11 に移植するプロセスでは、アプリとシェーダー プログラムの間でデータを受け渡すための構文と API の動作を変更する必要があります。

OpenGL ES 2.0 では、4 つの方法で (定数データは uniform として、頂点データは attribute として、テクスチャなどのその他のリソース データはバッファー オブジェクトとして) シェーダー プログラムとの間でデータを受け渡します。 Direct3D 11 では、これらはだいたい定数バッファー、頂点バッファー、サブリソースにマップされます。 表面上は似ていますが、使う際の処理はまったく異なります。

基本的なマッピングを次に示します。

| OpenGL ES 2.0             | Direct3D 11                                                                                                                                                                         |
|---------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| uniform                   | 定数バッファー (**cbuffer**) フィールド。                                                                                                                                                |
| attribute                 | 入力レイアウトで指定し、特定の HLSL セマンティクスでマークされた頂点バッファー要素フィールド。                                                                                |
| バッファー オブジェクト             | バッファー (「[**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220)」、「[**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092)」、汎用バッファーの定義に関するページをご覧ください)。 |
| フレーム バッファー オブジェクト (FBO) | レンダー ターゲット (「[**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635)」と「[**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582)」をご覧ください)。                                       |
| バック バッファー               | スワップ チェーンと "バック バッファー" サーフェス (「[**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631)」と「[**IDXGISurface1**](https://msdn.microsoft.com/library/windows/desktop/ff471343)」をご覧ください)。                       |

 

## <a name="port-buffers"></a>バッファーの移植


OpenGL ES 2.0 では、どの種類のバッファーでも、作成してバインドするプロセスは、通常、次のパターンに従います。

-   glGenBuffers を呼び出して、1 つ以上のバッファーを生成し、それらへのハンドルを返す。
-   glBindBuffer を呼び出して、GL\_ELEMENT\_ARRAY\_BUFFER などのバッファーのレイアウトを定義する。
-   glBufferData を呼び出して、特定のレイアウトの特定のデータ (頂点の構造体、インデックス データ、色データなど) をバッファーに設定する。

最も一般的なバッファーは頂点バッファーで、少なくとも何らかの座標系内の頂点の位置を含みます。 一般的な用途では、頂点は、位置座標、頂点の位置に向かう法線ベクトル、頂点の位置に向かう接線ベクトル、テクスチャ検索 (uv) 座標を含む構造体によって表されます。 バッファーには何らかの順序 (三角形リスト、三角形ストリップ、三角形ファンなど) でのそうした頂点の連続する一覧が含まれ、それらがまとまってシーンに表示されるポリゴンを表します  (Direct3D 11 でも、OpenGL ES 2.0 でも、描画呼び出しごとに複数の頂点バッファーを作成するのは効率的ではありません)。

OpenGL ES 2.0 で作成した頂点バッファーとインデックス バッファーの例を次に示します。

OpenGL ES 2.0: 頂点バッファーとインデックス バッファーの作成と設定

``` syntax
glGenBuffers(1, &renderer->vertexBuffer);
glBindBuffer(GL_ARRAY_BUFFER, renderer->vertexBuffer);
glBufferData(GL_ARRAY_BUFFER, sizeof(Vertex) * CUBE_VERTICES, renderer->vertices, GL_STATIC_DRAW);

glGenBuffers(1, &renderer->indexBuffer);
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->indexBuffer);
glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(int) * CUBE_INDICES, renderer->vertexIndices, GL_STATIC_DRAW);
```

他のバッファーには、ピクセル バッファーとマップ (テクスチャなど) があります。 シェーダー パイプラインでは、テクスチャ バッファー (pixmap) にレンダリングすることや、バッファー オブジェクトをレンダリングすることができます。また、後のシェーダー パスでこれらのバッファーを使うこともできます。 最も単純なケースでは、呼び出しフローは次のようになります。

-   glGenFramebuffers を呼び出して、フレーム バッファー オブジェクトを生成する。
-   glBindFramebuffer を呼び出して、書き込み用にフレーム バッファー オブジェクトをバインドする。
-   glFramebufferTexture2D を呼び出して、指定されたテクスチャ マップに描画する。

Direct3D 11 では、バッファー データ要素は "サブリソース" と見なされます。そうした要素には、個々の頂点データ要素や MIP マップ テクスチャなどがあります。

-   バッファー データ要素の構成を [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) 構造体に設定する。
-   バッファーの個々の要素のサイズとバッファーの種類を [**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) 構造体に設定する。
-   これら 2 つの構造体を指定して [**ID3D11Device1::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/hh404575) を呼び出す。

Direct3D 11: 頂点バッファーとインデックス バッファーの作成と設定

``` syntax
D3D11_SUBRESOURCE_DATA vertexBufferData = {0};
vertexBufferData.pSysMem = cubeVertices;
vertexBufferData.SysMemPitch = 0;
vertexBufferData.SysMemSlicePitch = 0;
CD3D11_BUFFER_DESC vertexBufferDesc(sizeof(cubeVertices), D3D11_BIND_VERTEX_BUFFER);

m_d3dDevice->CreateBuffer(
  &vertexBufferDesc,
  &vertexBufferData,
  &m_vertexBuffer);

m_indexCount = ARRAYSIZE(cubeIndices);

D3D11_SUBRESOURCE_DATA indexBufferData = {0};
indexBufferData.pSysMem = cubeIndices;
indexBufferData.SysMemPitch = 0;
indexBufferData.SysMemSlicePitch = 0;
CD3D11_BUFFER_DESC indexBufferDesc(sizeof(cubeIndices), D3D11_BIND_INDEX_BUFFER);

m_d3dDevice->CreateBuffer(
  &indexBufferDesc,
  &indexBufferData,
  &m_indexBuffer);
    
```

フレーム バッファーなど、書き込み可能なピクセル バッファーやマップは、[**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) オブジェクトとして作成できます。 これらはリソースとして [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) または [**ID3D11ShaderResourceView**](https://msdn.microsoft.com/library/windows/desktop/ff476628) にバインドできます。また、一度描画すると、ID3D11RenderTargetView は関連付けられているスワップ チェーンを使って表示でき、ID3D11ShaderResourceView はシェーダーに渡すことができます。

Direct3D 11: フレーム バッファー オブジェクトの作成

``` syntax
ComPtr<ID3D11RenderTargetView> m_d3dRenderTargetViewWin;
// ...
ComPtr<ID3D11Texture2D> frameBuffer;

m_swapChainCoreWindow->GetBuffer(0, IID_PPV_ARGS(&frameBuffer));
m_d3dDevice->CreateRenderTargetView(
  frameBuffer.Get(),
  nullptr,
  &m_d3dRenderTargetViewWin);
```

## <a name="change-uniforms-and-uniform-buffer-objects-to-direct3d-constant-buffers"></a>Direct3D の定数バッファーへの uniform と uniform バッファー オブジェクトの変更


OpenGL ES 2.0 では、uniform は個々のシェーダー プログラムに定数データを渡すためのメカニズムです。 このデータをシェーダーが変更することはできません。

uniform を設定する際は、通常、GPU 内のアップロード場所とアプリ メモリ内のデータへのポインターを指定した glUniform\* メソッドの 1 つを渡します。 glUniform\* メソッドを実行すると、uniform データは GPU メモリに配置され、その uniform を宣言したシェーダーからアクセスできるようになります。 シェーダーがシェーダー内の uniform の宣言に基づいて (互換性のある型を使って) 解釈できる方法でデータをパックする必要があります。

OpenGL ES 2.0: uniform の作成と uniform へのデータのアップロード

``` syntax
renderer->mvpLoc = glGetUniformLocation(renderer->programObject, "u_mvpMatrix");

// ...

glUniformMatrix4fv(renderer->mvpLoc, 1, GL_FALSE, (GLfloat*) &renderer->mvpMatrix.m[0][0]);
```

シェーダーの GLSL では、対応する uniform の宣言は次のようになります。

Open GL ES 2.0: GLSL での uniform の宣言

``` syntax
uniform mat4 u_mvpMatrix;
```

Direct3D では、uniform データを "定数バッファー" として指定します。定数バッファーには、uniform と同じように、個々のシェーダーに渡す定数データを含めます。 uniform バッファーと同じように、シェーダーが解釈できる方法でメモリ内の定数バッファー データをパックすることが重要です。 プラットフォームの型 (**float\*** や **float\[4\]** など) ではなく、DirectXMath 型 ([**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) など) を使って、データ要素のアラインメントが適切に行われるようにします。

定数バッファーには、GPU でそのデータを参照するために使う GPU レジスタを関連付ける必要があります。 データは、バッファーのレイアウトで指定されているレジスタの場所にパックされます。

Direct3D 11: 定数バッファーの作成と定数バッファーへのデータのアップロード

``` syntax
struct ModelViewProjectionConstantBuffer
{
     DirectX::XMFLOAT4X4 mvp;
};

// ...

ModelViewProjectionConstantBuffer   m_constantBufferData;

// ...

XMStoreFloat4x4(&m_constantBufferData.mvp, mvpMatrix);

CD3D11_BUFFER_DESC constantBufferDesc(sizeof(ModelViewProjectionConstantBuffer), D3D11_BIND_CONSTANT_BUFFER);
m_d3dDevice->CreateBuffer(
  &constantBufferDesc,
  nullptr,
  &m_constantBuffer);
```

シェーダーの HLSL では、対応する定数バッファーの宣言は次のようになります。

Direct3D 11: HLSL での定数バッファーの宣言

``` syntax
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
  matrix mvp;
};
```

定数バッファーごとにレジスタを宣言する必要があります。 Direct3D 機能レベルによって、利用できるレジスタの最大数が異なります。そのため、ターゲットとする最も低い機能レベルの最大数を超えないようにしてください。

## <a name="port-vertex-attributes-to-a-direct3d-input-layouts-and-hlsl-semantics"></a>Direct3D の入力レイアウトと HLSL セマンティクスへの頂点 attribute の移植


頂点データはシェーダー パイプラインで変更できるため、OpenGL ES 2.0 では、頂点データを "uniform" ではなく "attribute" として指定する必要があります  (これは最近のバージョンの OpenGL と GLSL で変更されました)。頂点の位置、法線、接線、色値などの頂点固有のデータは、attribute 値としてシェーダーに渡します。 これらの attribute 値は、頂点データの各要素の特定のオフセットに対応しています。たとえば、1 つ目の attribute は個々の頂点の位置コンポーネントを指し、2 つ目は法線を指します。

メイン メモリから GPU に頂点バッファー データを移動する基本的なプロセスを次のようになります。

-   glBindBuffer を使って、頂点データをアップロードする。
-   glGetAttribLocation を使って、GPU 上の attribute の場所を取得する。 頂点データ要素の attribute ごとに glGetAttribLocation を呼び出します。
-   glVertexAttribPointer を呼び出して、個々の頂点データ要素内の正しい attribute のサイズとオフセットを設定する。 attribute ごとにこれを実行します。
-   glEnableVertexAttribArray を使って、頂点データのレイアウト情報を有効にする。

OpenGL ES 2.0: シェーダーの attribute への頂点バッファー データのアップロード

``` syntax
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->vertexBuffer);
loc = glGetAttribLocation(renderer->programObject, "a_position");

glVertexAttribPointer(loc, 3, GL_FLOAT, GL_FALSE, 
  sizeof(Vertex), 0);
loc = glGetAttribLocation(renderer->programObject, "a_color");
glEnableVertexAttribArray(loc);

glVertexAttribPointer(loc, 4, GL_FLOAT, GL_FALSE, 
  sizeof(Vertex), (GLvoid*) (sizeof(float) * 3));
glEnableVertexAttribArray(loc);
```

次に、頂点シェーダーで、glGetAttribLocation の呼び出しで定義したのと同じ名前の attribute を宣言します。

OpenGL ES 2.0: GLSL での attribute の宣言

``` syntax
attribute vec4 a_position;
attribute vec4 a_color;                     
```

ある意味では、同じプロセスが Direct3D にも当てはまります。 attribute ではなく、頂点データを入力バッファーに配置します。入力バッファーには、頂点バッファーと、対応するインデックス バッファーが含まれます。 ただし、Direct3D には "attribute" の宣言がないため、頂点バッファー内のデータ要素の個々のコンポーネントと、それらのコンポーネントを頂点シェーダーが解釈する場所と方法を示す HLSL セマンティクスを宣言する入力レイアウトを指定する必要があります。 HLSL セマンティクスでは、シェーダー エンジンに目的を通知する特定の文字列を使って、各コンポーネントの用途を定義する必要があります。 たとえば、頂点の位置データは POSITION とマークし、法線データは NORMAL とマークし、頂点の色データは COLOR とマークします  (また、他のシェーダー ステージでも特定のセマンティクスが必要です。それらのセマンティクスは、シェーダー ステージに応じて解釈が異なります)。HLSL セマンティクスについて詳しくは、「[OpenGL ES 2.0 と Direct3D のシェーダー パイプラインの比較](change-your-shader-loading-code.md)」と「[HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574)」をご覧ください。

頂点バッファーとインデックス バッファーを設定し、入力レイアウトを設定するプロセスはまとめて Direct3D グラフィックス パイプラインの "入力アセンブリ" (IA) ステージと呼ばれます。

Direct3D 11: 入力アセンブリ ステージの構成

``` syntax
// Set up the IA stage corresponding to the current draw operation.
UINT stride = sizeof(VertexPositionColor);
UINT offset = 0;
m_d3dContext->IASetVertexBuffers(
        0,
        1,
        m_vertexBuffer.GetAddressOf(),
        &stride,
        &offset);

m_d3dContext->IASetIndexBuffer(
        m_indexBuffer.Get(),
        DXGI_FORMAT_R16_UINT,
        0);

m_d3dContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
m_d3dContext->IASetInputLayout(m_inputLayout.Get());
```

入力レイアウトを宣言し、頂点シェーダーに関連付けるには、頂点データ要素の形式と、各コンポーネントに使うセマンティクスを宣言します。 作成した D3D11\_INPUT\_ELEMENT\_DESC に記述されている頂点要素データのレイアウトは、対応する構造体のレイアウトと対応している必要があります。 ここでは、次の 2 つのコンポーネントを含む頂点データのレイアウトを作成します。

-   メイン メモリ内で XMFLOAT3 として表される頂点の位置座標。これは、(x, y, z) 座標の 3 つの 32 ビット浮動小数点値のアラインメントされた配列です。
-   XMFLOAT4 として表される頂点の色値。これは、色 (RGBA) の 4 つの 32 ビット浮動小数点値のアラインメントされた配列です。

それぞれのセマンティクスと形式の種類を割り当てます。 次に、記述を [**ID3D11Device1::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512) に渡します。 入力レイアウトは、レンダリング メソッドの実行時に入力アセンブリを設定するために、[**ID3D11DeviceContext1::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) を呼び出すときに使います。

Direct3D 11: 特定のセマンティクスを使った入力レイアウトの記述

``` syntax
ComPtr<ID3D11InputLayout> m_inputLayout;

// ...

const D3D11_INPUT_ELEMENT_DESC vertexDesc[] = 
{
  { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,  D3D11_INPUT_PER_VERTEX_DATA, 0 },
  { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};

m_d3dDevice->CreateInputLayout(
  vertexDesc,
  ARRAYSIZE(vertexDesc),
  fileData->Data,
  fileData->Length,
  &m_inputLayout);

// ...
// When we start the drawing process...

m_d3dContext->IASetInputLayout(m_inputLayout.Get());
```

最後に、入力を宣言して、シェーダーが入力データを理解できるようにします。 レイアウト内で割り当てたセマンティクスを使って、GPU メモリ内の正しい場所を選択します。

Direct3D 11: HLSL セマンティクスを使ったシェーダーの入力データの宣言

``` syntax
struct VertexShaderInput
{
  float3 pos : POSITION;
  float3 color : COLOR;
};
```

 

 




