---
title: 頂点バッファーと頂点データの移植
description: この手順では、シェーダーが指定された順番で頂点を走査できるようにするインデックス バッファーとメッシュを格納する頂点バッファーを定義します。
ms.assetid: 9a8138a5-0797-8532-6c00-58b907197a25
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 移植, 頂点バッファー, データ, Direct3D
ms.localizationpriority: medium
ms.openlocfilehash: 4c961a8852fb1e03e4e86209f62bda821b980f8c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592817"
---
# <a name="port-the-vertex-buffers-and-data"></a>頂点バッファーと頂点データの移植




**重要な API**

-   [**ID3DDevice::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501)
-   [**ID3DDeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456)
-   [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/bb173588)

この手順では、シェーダーが指定された順番で頂点を走査できるようにするインデックス バッファーとメッシュを格納する頂点バッファーを定義します。

ここでは、使う立方体のメッシュのハードコードされたモデルを見ていきます。 両方の表現では、頂点が (ストリップなどのより効率的な三角形レイアウトではなく) 三角形リストとしてまとめられています。 また、両方の表現のすべての頂点には、インデックスと色値が関連付けられています。 このトピックのほとんどの Direct3D コードでは、Direct3D プロジェクトで定義された変数とオブジェクトを参照します。

OpenGL ES 2.0 で処理する場合の立方体を次に示します。 サンプル実装では、各頂点は、7 float 値です。4 つの RGBA 色値の後に 3 つの位置座標。

```cpp
#define CUBE_INDICES 36
#define CUBE_VERTICES 8

GLfloat cubeVertsAndColors[] = 
{
  -0.5f, -0.5f,  0.5f, 0.0f, 0.0f, 1.0f, 1.0f,
  -0.5f, -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, 1.0f,
  -0.5f,  0.5f,  0.5f, 0.0f, 1.0f, 1.0f, 1.0f,
  -0.5f,  0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 1.0f,
  0.5f, -0.5f,  0.5f, 1.0f, 0.0f, 1.0f, 1.0f,
  0.5f, -0.5f, -0.5f, 1.0f, 0.0f, 0.0f, 1.0f,  
  0.5f,  0.5f,  0.5f, 1.0f, 1.0f, 1.0f, 1.0f,
  0.5f,  0.5f, -0.5f, 1.0f, 1.0f, 0.0f, 1.0f
};

GLuint cubeIndices[] = 
{
  0, 1, 2, // -x
  1, 3, 2,

  4, 6, 5, // +x
  6, 7, 5,

  0, 5, 1, // -y
  5, 6, 1,

  2, 6, 3, // +y
  6, 7, 3,

  0, 4, 2, // +z
  4, 6, 2,

  1, 7, 3, // -z
  5, 7, 1
};
```

Direct3D 11 で処理する場合の同じ立方体を次に示します。

```cpp
VertexPositionColor cubeVerticesAndColors[] = 
// struct format is position, color
{
  {XMFLOAT3(-0.5f, -0.5f, -0.5f), XMFLOAT3(0.0f, 0.0f, 0.0f)},
  {XMFLOAT3(-0.5f, -0.5f,  0.5f), XMFLOAT3(0.0f, 0.0f, 1.0f)},
  {XMFLOAT3(-0.5f,  0.5f, -0.5f), XMFLOAT3(0.0f, 1.0f, 0.0f)},
  {XMFLOAT3(-0.5f,  0.5f,  0.5f), XMFLOAT3(0.0f, 1.0f, 1.0f)},
  {XMFLOAT3( 0.5f, -0.5f, -0.5f), XMFLOAT3(1.0f, 0.0f, 0.0f)},
  {XMFLOAT3( 0.5f, -0.5f,  0.5f), XMFLOAT3(1.0f, 0.0f, 1.0f)},
  {XMFLOAT3( 0.5f,  0.5f, -0.5f), XMFLOAT3(1.0f, 1.0f, 0.0f)},
  {XMFLOAT3( 0.5f,  0.5f,  0.5f), XMFLOAT3(1.0f, 1.0f, 1.0f)},
};
        
unsigned short cubeIndices[] = 
{
  0, 2, 1, // -x
  1, 2, 3,

  4, 5, 6, // +x
  5, 7, 6,

  0, 1, 5, // -y
  0, 5, 4,

  2, 6, 7, // +y
  2, 7, 3,

  0, 4, 6, // -z
  0, 6, 2,

  1, 3, 7, // +z
  1, 7, 5
};
```

このコードを確認すると、OpenGL ES 2.0 コードの立方体が右手座標系で表されているのに対し、Direct3D 固有のコードの立方体が左手座標系で表されていることがわかります。 自分のメッシュ データをインポートする際は、モデルの z 軸の座標を反転させ、座標系の変更に従って三角形を走査するように各メッシュのインデックスを適切に変更する必要があります。

立方体のメッシュを OpenGL ES 2.0 の右手座標系から Direct3D の左手座標系に正常に移植できたことを前提に、両方のモデルで処理する立方体データを読み込む方法を見ていきます。

## <a name="instructions"></a>手順

### <a name="step-1-create-an-input-layout"></a>手順 1:入力レイアウトを作成します。

OpenGL ES 2.0 では、頂点データを attribute として渡し、シェーダー オブジェクトがそれを受け取って、読み取ります。 通常、シェーダーの GLSL で使われる attribute 名を含む文字列をシェーダー プログラム オブジェクトに渡し、シェーダーに渡すことができるメモリの場所を取得します。 この例では、次のように定義され、フォーマットされたカスタムの Vertex 構造体の一覧を頂点バッファー オブジェクトに含めます。

OpenGL ES 2.0:頂点ごとの情報を含む属性を構成します。

``` syntax
typedef struct 
{
  GLfloat pos[3];        
  GLfloat rgba[4];
} Vertex;
```

OpenGL ES 2.0 では、入力レイアウトは暗黙の型です。汎用 GL 行う\_要素\_配列\_バッファー ストライドを指定して、オフセット、頂点シェーダーにアップロードした後、データを解釈できるようにします。 レンダリングする前に、**glVertexAttribPointer** を使って、どの attribute が頂点データの各ブロックのどの部分にマップされるかをシェーダーに通知します。

Direct3D では、ジオメトリを描画する前ではなく、バッファーを作成するときに、頂点バッファー内の頂点データの構造体を記述した入力レイアウトを渡す必要があります。 そのためには、メモリ内の個々の頂点データのレイアウトに対応する入力レイアウトを使います。 これを正確に指定することが非常に重要です。

ここでは、入力の説明の配列を作成する[ **D3D11\_入力\_要素\_DESC** ](https://msdn.microsoft.com/library/windows/desktop/ff476180)構造体。

Direct3D:入力レイアウトの説明を定義します。

``` syntax
struct VertexPositionColor
{
  DirectX::XMFLOAT3 pos;
  DirectX::XMFLOAT3 color;
};

// ...

const D3D11_INPUT_ELEMENT_DESC vertexDesc[] = 
{
  { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,  D3D11_INPUT_PER_VERTEX_DATA, 0 },
  { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};

```

この入力の記述では、頂点を 2 つの 3 座標ベクトルのペアとして定義します。1 つの 3D ベクトルにはモデル座標内の頂点の位置を格納し、もう 1 つの 3D ベクトルには頂点に関連付けられている RGB 色値を格納します。 この場合は、3x32 ビットの浮動小数点形式を使います。コードではその要素を `XMFLOAT3(X.Xf, X.Xf, X.Xf)` として表します。 シェーダーで使われるデータを処理する場合は、必ず [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/ee415574) ライブラリの型を使って、そのデータのパッキングとアラインメントが適切に行われるようにする必要があります  (たとえば、ベクトル データには [**XMFLOAT3**](https://msdn.microsoft.com/library/windows/desktop/ee419475) または [**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) を使い、マトリックスには [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) を使います)。

すべての有効な形式の種類の一覧を参照してください[ **DXGI\_形式**](https://msdn.microsoft.com/library/windows/desktop/bb173059)します。

頂点ごとの入力レイアウトを定義して、レイアウト オブジェクトを作成します。 次のコードで記述する**m\_inputLayout**、型の変数**ComPtr** (型のオブジェクトを指す[ **ID3D11InputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476575)). **fileData** には、前の手順の「[シェーダー オブジェクトの移植](port-the-shader-config.md)」のコンパイル済み頂点シェーダー オブジェクトが含まれています。

Direct3D:頂点バッファーで使用される入力レイアウトを作成します。

``` syntax
Microsoft::WRL::ComPtr<ID3D11InputLayout>      m_inputLayout;

// ...

m_d3dDevice->CreateInputLayout(
  vertexDesc,
  ARRAYSIZE(vertexDesc),
  fileData->Data,
  fileShaderData->Length,
  &m_inputLayout
);
```

ここまでで、入力レイアウトを定義しました。 次は、このレイアウトを使うバッファーを作成し、それを立方体のメッシュ データと一緒に読み込みます。

### <a name="step-2-create-and-load-the-vertex-buffers"></a>手順 2:作成し、頂点バッファーを読み込む

OpenGL ES 2.0 では、2 つのバッファー (位置データ用と色データ用) を作成します  (両方を含む構造体を作成することも、1 つのバッファー)。各バッファーをバインドし、それらに位置と色のデータを書き込みます。 その後、レンダリング関数の実行時に、もう一度バッファーをバインドし、シェーダーが正しく解釈できるようにバッファー内のデータの形式をシェーダーに通知します。

OpenGL ES 2.0:頂点バッファーをバインドします。

``` syntax
// upload the data for the vertex position buffer
glGenBuffers(1, &renderer->vertexBuffer);    
glBindBuffer(GL_ARRAY_BUFFER, renderer->vertexBuffer);
glBufferData(GL_ARRAY_BUFFER, sizeof(VERTEX) * CUBE_VERTICES, renderer->vertices, GL_STATIC_DRAW);   
```

として、Direct3D のシェーダーにアクセス可能なバッファーが表される[ **D3D11\_SUBRESOURCE\_データ**](https://msdn.microsoft.com/library/windows/desktop/ff476220)構造体。 シェーダー オブジェクトには、このバッファーの場所をバインドするには、CD3D11 を作成する必要があります\_バッファー\_DESC 構造で各バッファーの[ **ID3DDevice::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501)、し、設定set メソッドをなどでバッファーの種類に固有に呼び出すことによって、Direct3D デバイス コンテキストのバッファー [ **ID3DDeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456)します。

バッファーを設定するときに、ストライド (個々の頂点のデータ要素のサイズ) とバッファーの先頭からのオフセット (実際に頂点データの配列が始まる位置) を設定する必要があります。

ポインターを割り当てることに注意してください、 **vertexIndices**配列を**pSysMem**のフィールド、 [ **D3D11\_SUBRESOURCE\_データ**](https://msdn.microsoft.com/library/windows/desktop/ff476220)構造体。 これを正しく行わないと、メッシュの形が正しく表示されないか、空になります。

Direct3D:作成し、頂点バッファーを設定します

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
        
// ...

UINT stride = sizeof(VertexPositionColor);
UINT offset = 0;
m_d3dContext->IASetVertexBuffers(
  0,
  1,
  m_vertexBuffer.GetAddressOf(),
  &stride,
  &offset);
```

### <a name="step-3-create-and-load-the-index-buffer"></a>手順 3:作成し、インデックス バッファーを読み込む

インデックス バッファーは、頂点シェーダーが個々の頂点を検索できるようにする効率的な方法です。 これは必須ではありませんが、このサンプルのレンダラーでは使います。 OpenGL ES 2.0 の頂点バッファーと同じように、インデックス バッファーを汎用のバッファーとして作成してバインドし、前に作成した頂点インデックスをインデックス バッファーにコピーします。

描画する準備ができたら、もう一度頂点バッファーとインデックス バッファーの両方をバインドし、**glDrawElements** を呼び出します。

OpenGL ES 2.0:描画呼び出しに、インデックスの順序を送信します。

``` syntax
GLuint indexBuffer;

// ...

glGenBuffers(1, &renderer->indexBuffer);    
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->indexBuffer);   
glBufferData(GL_ELEMENT_ARRAY_BUFFER, 
  sizeof(GLuint) * CUBE_INDICES, 
  renderer->vertexIndices, 
  GL_STATIC_DRAW);

// ...
// Drawing function

// Bind the index buffer
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->indexBuffer);
glDrawElements (GL_TRIANGLES, renderer->numIndices, GL_UNSIGNED_INT, 0);
```

Direct3D の場合、プロセスは非常に似ていますが、多少説明が必要です。 Direct3D を構成したときに作成した [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) にインデックス バッファーを Direct3D サブリソースとして渡します。 これを行うには、次のように、インデックスの配列の構成済みのサブリソースを指定して [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/bb173588) を呼び出します  (ここでもへのポインターを割り当てることに注意してください、 **cubeIndices**配列を**pSysMem**のフィールド、 [ **D3D11\_SUBRESOURCE\_データ**](https://msdn.microsoft.com/library/windows/desktop/ff476220)構造です)。

Direct3D:インデックス バッファーを作成します。

``` syntax
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

// ...

m_d3dContext->IASetIndexBuffer(
  m_indexBuffer.Get(),
  DXGI_FORMAT_R16_UINT,
  0);
```

その後、次のように、[**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) (インデックスなしの頂点の場合は [**ID3D11DeviceContext::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407)) を呼び出して、三角形を描画します  (詳しくは、一足先に「[画面への描画](draw-to-the-screen.md)」をご覧ください)。

Direct3D:インデックス付きの頂点を描画します。

``` syntax
m_d3dContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
m_d3dContext->IASetInputLayout(m_inputLayout.Get());

// ...

m_d3dContext->DrawIndexed(
  m_indexCount,
  0,
  0);
```

## <a name="previous-step"></a>前のステップ


[シェーダー オブジェクトの移植](port-the-shader-config.md)

## <a name="next-step"></a>次の手順

[GLSL の移植](port-the-glsl.md)

## <a name="remarks"></a>注釈

Direct3D を構築する場合は、[**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) のメソッドを呼び出すコードを切り離して、デバイス リソースを再作成する必要があるたびに呼び出されるメソッドに配置します  (Direct3D プロジェクト テンプレートでは、このコードはレンダラー オブジェクトの **CreateDeviceResource** メソッドに配置されています)。 また、デバイス コンテキスト ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)) を更新するコードは **Render** メソッドに配置されています。そこで実際にシェーダー ステージを作成し、データをバインドするためです。

## <a name="related-topics"></a>関連トピック


* [方法: direct3d11 を単純な OpenGL ES 2.0 レンダラーのポート](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)
* [シェーダー オブジェクトの移植](port-the-shader-config.md)
* [頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)
* [GLSL の移植](port-the-glsl.md)

 

 




