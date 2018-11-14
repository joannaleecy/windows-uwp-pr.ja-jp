---
author: mtoepke
title: シェーダー オブジェクトの移植
description: OpenGL ES 2.0 から簡単なレンダラーを移植する場合、最初の手順では、Direct3D 11 の対応する頂点シェーダー オブジェクトとフラグメント シェーダー オブジェクトを設定し、コンパイル後にメイン プログラムがシェーダー オブジェクトと通信できるようにします。
ms.assetid: 0383b774-bc1b-910e-8eb6-cc969b3dcc08
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 移植, シェーダー, Direct3D, OpenGL
ms.localizationpriority: medium
ms.openlocfilehash: bbf7e05a93ccce4188d62f9800a5f225be713cc6
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6201852"
---
# <a name="port-the-shader-objects"></a>シェーダー オブジェクトの移植




**重要な API**

-   [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379)
-   [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)

OpenGL ES 2.0 から簡単なレンダラーを移植する場合、最初の手順では、Direct3D 11 の対応する頂点シェーダー オブジェクトとフラグメント シェーダー オブジェクトを設定し、コンパイル後にメイン プログラムがシェーダー オブジェクトと通信できるようにします。

> **注:** 新しい Direct3D プロジェクトを作成するかどうか。 作成していない場合は、「[テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)」の指示に従ってください。 このチュートリアルでは、画面に描画するために DXGI リソースと Direct3D リソースを作成していることを前提としています。これらのリソースは、テンプレートで提供されます。

 

OpenGL ES 2.0 と同じように、Direct3D のコンパイル済みシェーダーは描画コンテキストに関連付ける必要があります。 ただし、Direct3D にはもともとシェーダー プログラム オブジェクトという概念がありません。そのため、代わりに、シェーダーを [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) に直接割り当てる必要があります。 この手順では、OpenGL ES 2.0 のシェーダー オブジェクトを作成してバインドするプロセスに従い、Direct3D で対応する API の動作を実現します。

<a name="instructions"></a>手順
------------

### <a name="step-1-compile-the-shaders"></a>手順 1: シェーダーのコンパイル

この簡単な OpenGL ES 2.0 のサンプルでは、シェーダーをテキスト ファイルとして保存し、実行時コンパイルのために文字列データとして読み込みます。

OpenGL ES 2.0: シェーダーのコンパイル

``` syntax
GLuint __cdecl CompileShader (GLenum shaderType, const char *shaderSrcStr)
// shaderType can be GL_VERTEX_SHADER or GL_FRAGMENT_SHADER. Returns 0 if compilation fails.
{
  GLuint shaderHandle;
  GLint compiledShaderHandle;
   
  // Create an empty shader object.
  shaderHandle = glCreateShader(shaderType);

  if (shaderHandle == 0)
  return 0;

  // Load the GLSL shader source as a string value. You could obtain it from
  // from reading a text file or hardcoded.
  glShaderSource(shaderHandle, 1, &shaderSrcStr, NULL);
   
  // Compile the shader.
  glCompileShader(shaderHandle);

  // Check the compile status
  glGetShaderiv(shaderHandle, GL_COMPILE_STATUS, &compiledShaderHandle);

  if (!compiledShaderHandle) // error in compilation occurred
  {
    // Handle any errors here.
              
    glDeleteShader(shaderHandle);
    return 0;
  }

  return shaderHandle;

}
```

Direct3D では、シェーダーは実行時にコンパイルされず、常に、プログラムの他の部分をコンパイルしたときに、CSO ファイルにコンパイルされます。 Microsoft Visual Studio でアプリをコンパイルすると、HLSL ファイルは、アプリで読み込む必要がある CSO (.cso) ファイルにコンパイルされます。 アプリをパッケージ化するときは、これらの CSO ファイルを必ず含めてください。

> **注:** 次の例は、シェーダーの読み込みと**auto**キーワードとラムダ構文を使用して非同期でコンパイルを実行します。 ReadDataAsync() はテンプレートに実装されているメソッドで、CSO ファイルをバイト データの配列 (fileData) として読み取ります。

 

Direct3D 11: シェーダーのコンパイル

``` syntax
auto loadVSTask = DX::ReadDataAsync(m_projectDir + "SimpleVertexShader.cso");
auto loadPSTask = DX::ReadDataAsync(m_projectDir + "SimplePixelShader.cso");

auto createVSTask = loadVSTask.then([this](Platform::Array<byte>^ fileData) {

m_d3dDevice->CreateVertexShader(
  fileData->Data,
  fileData->Length,
  nullptr,
  &m_vertexShader);

auto createPSTask = loadPSTask.then([this](Platform::Array<byte>^ fileData) {
  m_d3dDevice->CreatePixelShader(
    fileData->Data,
    fileData->Length,
    nullptr,
    &m_pixelShader;
};
```

### <a name="step-2-create-and-load-the-vertex-and-fragment-pixel-shaders"></a>手順 2: 頂点シェーダーとフラグメント (ピクセル) シェーダーの作成と読み込み

OpenGL ES 2.0 にはシェーダー "プログラム" という概念があります。この概念は、CPU で実行されるメイン プログラムと GPU で実行されるシェーダーの間のインターフェイスとして機能します。 シェーダーはコンパイルされ (またはコンパイル済みのソースから読み込まれ)、プログラムに関連付けられることで、GPU で実行できるようになります。

OpenGL ES 2.0: シェーダー プログラムへの頂点シェーダーとフラグメント シェーダーの読み込み

``` syntax
GLuint __cdecl LoadShaderProgram (const char *vertShaderSrcStr, const char *fragShaderSrcStr)
{
  GLuint programObject, vertexShaderHandle, fragmentShaderHandle;
  GLint linkStatusCode;

  // Load the vertex shader and compile it to an internal executable format.
  vertexShaderHandle = CompileShader(GL_VERTEX_SHADER, vertShaderSrcStr);
  if (vertexShaderHandle == 0)
  {
    glDeleteShader(vertexShaderHandle);
    return 0;
  }

   // Load the fragment/pixel shader and compile it to an internal executable format.
  fragmentShaderHandle = CompileShader(GL_FRAGMENT_SHADER, fragShaderSrcStr);
  if (fragmentShaderHandle == 0)
  {
    glDeleteShader(fragmentShaderHandle);
    return 0;
  }

  // Create the program object proper.
  programObject = glCreateProgram();
   
  if (programObject == 0)    return 0;

  // Attach the compiled shaders
  glAttachShader(programObject, vertexShaderHandle);
  glAttachShader(programObject, fragmentShaderHandle);

  // Compile the shaders into binary executables in memory and link them to the program object..
  glLinkProgram(programObject);

  // Check the project object link status and determine if the program is available.
  glGetProgramiv(programObject, GL_LINK_STATUS, &linkStatusCode);

  if (!linkStatusCode) // if link status <> 0
  {
    // Linking failed; delete the program object and return a failure code (0).

    glDeleteProgram (programObject);
    return 0;
  }

  // Deallocate the unused shader resources. The actual executables are part of the program object.
  glDeleteShader(vertexShaderHandle);
  glDeleteShader(fragmentShaderHandle);

  return programObject;
}

// ...

glUseProgram(renderer->programObject);
```

Direct3D には、シェーダー プログラム オブジェクトという概念がありません。 そのため、シェーダーは、[**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) インターフェイスでいずれかのシェーダー作成メソッド ([**ID3D11Device::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) や [**ID3D11Device::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) など) が呼び出されたときに作成されます。 現在の描画コンテキストのシェーダーを設定するには、シェーダー設定メソッド (頂点シェーダーの [**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) やフラグメント シェーダーの [**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) など) を使って、シェーダーを対応する [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) に渡します。

Direct3D 11: グラフィックス デバイスの描画コンテキストのシェーダーの設定

``` syntax
m_d3dContext->VSSetShader(
  m_vertexShader.Get(),
  nullptr,
  0);

m_d3dContext->PSSetShader(
  m_pixelShader.Get(),
  nullptr,
  0);
```

### <a name="step-3-define-the-data-to-supply-to-the-shaders"></a>手順 3: シェーダーに渡すデータの定義

OpenGL ES 2.0 の例では、シェーダー パイプラインに対して宣言する次の **uniform** が 1 つあります。

-   **u\_mvpMatrix**: 立方体のモデル座標を受け取り、それをスキャン変換のために 2D プロジェクション座標に変換する最終的なモデル ビュー プロジェクション変換マトリックスを表す浮動小数点値の 4x4 配列。

さらに、頂点データ用の次の **attribute** 値が 2 つあります。

-   **a\_position**: 頂点のモデル座標の 4 つの浮動小数点値で構成されたベクトル。
-   **a\_color**: 頂点に関連付けられている RGBA カラー値の 4 つの浮動小数点値で構成されたベクトル。

OpenGL ES 2.0: GLSL での uniform と attribute の定義

``` syntax
uniform mat4 u_mvpMatrix;
attribute vec4 a_position;
attribute vec4 a_color;
```

この場合は、対応するメイン プログラムの変数をレンダラー オブジェクトのフィールドとして定義します  (「[簡単な OpenGL ES 2.0 レンダラーを Direct3D 11 に移植する方法](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)」の見出しをご覧ください)。定義したら、メイン プログラムでシェーダー パイプラインにこれらの値を渡すメモリ内の場所を指定する必要があります。これは、通常、描画呼び出しの直前に行います。

OpenGL ES 2.0: uniform データと attribute データの場所のマーキング

``` syntax

// Inform the shader of the attribute locations
loc = glGetAttribLocation(renderer->programObject, "a_position");
glVertexAttribPointer(loc, 3, GL_FLOAT, GL_FALSE, 
    sizeof(Vertex), 0);
glEnableVertexAttribArray(loc);

loc = glGetAttribLocation(renderer->programObject, "a_color");
glVertexAttribPointer(loc, 4, GL_FLOAT, GL_FALSE, 
    sizeof(Vertex), (GLvoid*) (sizeof(float) * 3));
glEnableVertexAttribArray(loc);


// Inform the shader program of the uniform location
renderer->mvpLoc = glGetUniformLocation(renderer->programObject, "u_mvpMatrix");
```

Direct3D には、同じ意味での "attribute" と "uniform" の概念がありません (または、少なくともこの構文を共有しません)。 その代わり、Direct3D サブリソースとして表される定数バッファーがあります。これは、メイン プログラムとシェーダー プログラムの間で共有されるリソースです。 頂点の位置や色など、これらのサブリソースの一部は HLSL セマンティクスと呼ばれます。 OpenGL ES 2.0 の概念に関連する定数バッファーと HLSL セマンティクスについて詳しくは、「[OpenGL ES 2.0 のバッファー、uniform、頂点 attribute と Direct3D の比較](porting-uniforms-and-attributes.md)」を参照してください。

このプロセスを Direct3D に移行する場合は、uniform を Direct3D の定数バッファー (cbuffer) に変換し、**register** HLSL セマンティクスを使って、検索のために cbuffer をレジスタに割り当てます。 2 つの頂点 attribute はシェーダー パイプライン ステージの入力要素として処理され、シェーダーに通知する [HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574) (POSITION と COLOR0) が割り当てられます。 ピクセル シェーダーは、GPU によって生成されたシステム値であることを示す SV\_ プレフィックスが付いている SV\_POSITION を受け取ります  (この場合は、スキャン変換時に生成されたピクセルの位置です)。VertexShaderInput と PixelShaderInput は定数バッファーとして宣言しません。これは、VertexShaderInput は頂点バッファーを定義するために使い (「[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)」をご覧ください)、PixelShaderInput のデータはパイプラインの前のステージ (この場合は頂点シェーダー) の結果として生成されるためです。

Direct3D: HLSL での定数バッファーと頂点データの定義

``` syntax
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
  matrix mvp;
};

// Per-vertex data used as input to the vertex shader.
struct VertexShaderInput
{
  float4 pos : POSITION;
  float4 color : COLOR0;
};

// Per-vertex color data passed through the pixel shader.
struct PixelShaderInput
{
  float4 pos : SV_POSITION;
  float3 color : COLOR0;
};
```

定数バッファーへの移植と HLSL セマンティクスの利用について詳しくは、「[OpenGL ES 2.0 のバッファー、uniform、頂点 attribute と Direct3D の比較](porting-uniforms-and-attributes.md)」をご覧ください。

定数バッファーまたは頂点バッファーを使ってシェーダー パイプラインに渡されるデータのレイアウトの構造体を次に示します。

Direct3D 11: 定数バッファーと頂点バッファーのレイアウトの宣言

``` syntax
// Constant buffer used to send MVP matrices to the vertex shader.
struct ModelViewProjectionConstantBuffer
{
  DirectX::XMFLOAT4X4 modelViewProjection;
};

// Used to send per-vertex data to the vertex shader.
struct VertexPositionColor
{
  DirectX::XMFLOAT4 pos;
  DirectX::XMFLOAT4 color;
};
```

定数バッファー要素には DirectXMath XM\* 型を使っています。これにより、シェーダー パイプラインに送信する際に、コンテンツのパッキングとアラインメントが適切に行われます。 Windows プラットフォームの標準の浮動小数点型と配列を使う場合は、手動でパッキングとアラインメントを実行する必要があります。

定数バッファーをバインドするために、レイアウトの記述を [**CD3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/jj151620) 構造体として作成し、[**ID3DDevice::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) に渡します。 次に、レンダリング メソッドで、定数バッファーを [**ID3D11DeviceContext::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476486) に渡してから、描画します。

Direct3D 11: 定数バッファーのバインド

``` syntax
CD3D11_BUFFER_DESC constantBufferDesc(sizeof(ModelViewProjectionConstantBuffer), D3D11_BIND_CONSTANT_BUFFER);

m_d3dDevice->CreateBuffer(
  &constantBufferDesc,
  nullptr,
  &m_constantBuffer);

// ...

// Only update shader resources that have changed since the last frame.
m_d3dContext->UpdateSubresource(
  m_constantBuffer.Get(),
  0,
  NULL,
  &m_constantBufferData,
  0,
  0);
```

同じように頂点バッファーを作成して更新します。これについては、次の手順の「[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)」で説明します。

<a name="next-step"></a>次の手順
---------

[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)
## <a name="related-topics"></a>関連トピック


[簡単な OpenGL ES 2.0 レンダラーを Direct3D 11 に移植する方法](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)

[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)

[GLSL の移植](port-the-glsl.md)

[画面への描画](draw-to-the-screen.md)

 

 




