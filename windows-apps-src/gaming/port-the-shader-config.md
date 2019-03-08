---
title: シェーダー オブジェクトの移植
description: OpenGL ES 2.0 から簡単なレンダラーを移植する場合、最初の手順では、Direct3D 11 の対応する頂点シェーダー オブジェクトとフラグメント シェーダー オブジェクトを設定し、コンパイル後にメイン プログラムがシェーダー オブジェクトと通信できるようにします。
ms.assetid: 0383b774-bc1b-910e-8eb6-cc969b3dcc08
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 移植, シェーダー, Direct3D, OpenGL
ms.localizationpriority: medium
ms.openlocfilehash: f061d31ca779cb4c6cbe76f163e190996a6985cb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618747"
---
# <a name="port-the-shader-objects"></a>シェーダー オブジェクトの移植




**重要な API**

-   [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379)
-   [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)

OpenGL ES 2.0 から簡単なレンダラーを移植する場合、最初の手順では、Direct3D 11 の対応する頂点シェーダー オブジェクトとフラグメント シェーダー オブジェクトを設定し、コンパイル後にメイン プログラムがシェーダー オブジェクトと通信できるようにします。

> **注**  新しい Direct3D プロジェクトを作成しましたか? 作成していない場合は、「[テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)」の指示に従ってください。 このチュートリアルでは、画面に描画するために DXGI リソースと Direct3D リソースを作成していることを前提としています。これらのリソースは、テンプレートで提供されます。

 

OpenGL ES 2.0 と同じように、Direct3D のコンパイル済みシェーダーは描画コンテキストに関連付ける必要があります。 ただし、Direct3D にはもともとシェーダー プログラム オブジェクトという概念がありません。そのため、代わりに、シェーダーを [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) に直接割り当てる必要があります。 この手順では、OpenGL ES 2.0 のシェーダー オブジェクトを作成してバインドするプロセスに従い、Direct3D で対応する API の動作を実現します。

<a name="instructions"></a>手順
------------

### <a name="step-1-compile-the-shaders"></a>手順 1:シェーダーをコンパイルします。

この簡単な OpenGL ES 2.0 のサンプルでは、シェーダーをテキスト ファイルとして保存し、実行時コンパイルのために文字列データとして読み込みます。

OpenGL ES 2.0:シェーダーをコンパイルします。

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

> **注**  シェーダーの読み込みおよびコンパイルを使用して非同期的に次の例では、**自動**キーワードとラムダ構文です。 ReadDataAsync() はテンプレートに実装されているメソッドで、CSO ファイルをバイト データの配列 (fileData) として読み取ります。

 

Direct3D 11。シェーダーをコンパイルします。

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

### <a name="step-2-create-and-load-the-vertex-and-fragment-pixel-shaders"></a>手順 2:フラグメントの (ピクセル) シェーダーを作成し、頂点の読み込み

OpenGL ES 2.0 にはシェーダー "プログラム" という概念があります。この概念は、CPU で実行されるメイン プログラムと GPU で実行されるシェーダーの間のインターフェイスとして機能します。 シェーダーはコンパイルされ (またはコンパイル済みのソースから読み込まれ)、プログラムに関連付けられることで、GPU で実行できるようになります。

OpenGL ES 2.0:網掛けプログラムへの頂点とフラグメントのシェーダーの読み込み

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

Direct3D 11。グラフィックス デバイスの描画コンテキストのシェーダーを設定します。

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

### <a name="step-3-define-the-data-to-supply-to-the-shaders"></a>手順 3:シェーダーに提供するデータを定義します。

OpenGL ES 2.0 の例では、シェーダー パイプラインに対して宣言する次の **uniform** が 1 つあります。

-   **u\_mvpMatrix**: モデルを最終的なモデル-ビュー-射影変換行列を表す浮動小数点数の 4 x 4 配列は、キューブの調整し、スキャンの変換の投影が 2D 座標に変換します。

さらに、頂点データ用の次の **attribute** 値が 2 つあります。

-   **\_位置**: 頂点のモデルの座標を表す 4 float ベクトル。
-   **\_色**:頂点に関連付けられている RGBA 色の値を 4 float ベクトル。

Opengl ES 2.0:GLSL 定義制服と属性

``` syntax
uniform mat4 u_mvpMatrix;
attribute vec4 a_position;
attribute vec4 a_color;
```

この場合は、対応するメイン プログラムの変数をレンダラー オブジェクトのフィールドとして定義します  (でヘッダーを参照してください[方法: direct3d11 を単純な OpenGL ES 2.0 レンダラーをポート](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md))。処理が完了したら、メインのプログラムが通常の方法で描画呼び出しの直前、シェーダー パイプラインのこれらの値を提供するためのメモリ内の場所を指定する必要があります。

OpenGL ES 2.0:一様と属性データの場所をマークします。

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

このプロセスを Direct3D に移行する場合は、uniform を Direct3D の定数バッファー (cbuffer) に変換し、**register** HLSL セマンティクスを使って、検索のために cbuffer をレジスタに割り当てます。 2 つの頂点 attribute はシェーダー パイプライン ステージの入力要素として処理され、シェーダーに通知する [HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574) (POSITION と COLOR0) が割り当てられます。 ピクセル シェーダーは、SV\_位置を SV\_ GPU によって生成されたシステムの値であることを示すプレフィックス。 (この場合、これはスキャンの変換中に生成されたピクセル位置) です。VertexShaderInput と PixelShaderInput 定数前者を頂点バッファーの定義に使用するためのバッファーとしてを宣言されていない (を参照してください[頂点バッファーとデータをポート](port-the-vertex-buffers-and-data-config.md))、後者の場合、データがの結果として生成されると、頂点シェーダーをここでは、パイプラインの前のステージ。

Direct3D:定数バッファーと頂点データの HLSL の定義

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

Direct3D 11。定数と頂点バッファー レイアウトを宣言します。

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

使用して、DirectXMath XM\*シェーダー パイプラインに送信されるときに適切なパッキングと内容の配置を提供するために、定数の型が、要素をバッファーします。 Windows プラットフォームの標準の浮動小数点型と配列を使う場合は、手動でパッキングとアラインメントを実行する必要があります。

定数バッファーをバインドするとしてレイアウトの説明を作成、 [ **CD3D11\_バッファー\_DESC** ](https://msdn.microsoft.com/library/windows/desktop/jj151620)構造体に渡すと[ **ID3DDevice:。CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501)します。 次に、レンダリング メソッドで、定数バッファーを [**ID3D11DeviceContext::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476486) に渡してから、描画します。

Direct3D 11。定数バッファーをバインドします。

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


[方法: direct3d11 を単純な OpenGL ES 2.0 レンダラーのポート](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)

[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)

[GLSL の移植](port-the-glsl.md)

[画面への描画](draw-to-the-screen.md)

 

 




