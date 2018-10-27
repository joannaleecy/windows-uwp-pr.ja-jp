---
author: mtoepke
title: 頂点バッファーと頂点データの移植
description: この手順では、シェーダーが指定された順番で頂点を走査できるようにするインデックス バッファーとメッシュを格納する頂点バッファーを定義します。
ms.assetid: 9a8138a5-0797-8532-6c00-58b907197a25
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 移植, 頂点バッファー, データ, Direct3D
ms.localizationpriority: medium
ms.openlocfilehash: b32747a4e11d258f71d4e55e41b7f54bb5e99246
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5691229"
---
# <a name="port-the-vertex-buffers-and-data"></a><span data-ttu-id="aca6d-104">頂点バッファーと頂点データの移植</span><span class="sxs-lookup"><span data-stu-id="aca6d-104">Port the vertex buffers and data</span></span>




**<span data-ttu-id="aca6d-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="aca6d-105">Important APIs</span></span>**

-   [**<span data-ttu-id="aca6d-106">ID3DDevice::CreateBuffer</span><span class="sxs-lookup"><span data-stu-id="aca6d-106">ID3DDevice::CreateBuffer</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476501)
-   [**<span data-ttu-id="aca6d-107">ID3DDeviceContext::IASetVertexBuffers</span><span class="sxs-lookup"><span data-stu-id="aca6d-107">ID3DDeviceContext::IASetVertexBuffers</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476456)
-   [**<span data-ttu-id="aca6d-108">ID3D11DeviceContext::IASetIndexBuffer</span><span class="sxs-lookup"><span data-stu-id="aca6d-108">ID3D11DeviceContext::IASetIndexBuffer</span></span>**](https://msdn.microsoft.com/library/windows/desktop/bb173588)

<span data-ttu-id="aca6d-109">この手順では、シェーダーが指定された順番で頂点を走査できるようにするインデックス バッファーとメッシュを格納する頂点バッファーを定義します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-109">In this step, you'll define the vertex buffers that will contain your meshes and the index buffers that allow the shaders to traverse the vertices in a specified order.</span></span>

<span data-ttu-id="aca6d-110">ここでは、使う立方体のメッシュのハードコードされたモデルを見ていきます。</span><span class="sxs-lookup"><span data-stu-id="aca6d-110">At this point, let's examine the hardcoded model for the cube mesh we are using.</span></span> <span data-ttu-id="aca6d-111">両方の表現では、頂点が (ストリップなどのより効率的な三角形レイアウトではなく) 三角形リストとしてまとめられています。</span><span class="sxs-lookup"><span data-stu-id="aca6d-111">Both representations have the vertices organized as a triangle list (as opposed to a strip or other more efficient triangle layout).</span></span> <span data-ttu-id="aca6d-112">また、両方の表現のすべての頂点には、インデックスと色値が関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="aca6d-112">All vertices in both representations also have associated indices and color values.</span></span> <span data-ttu-id="aca6d-113">このトピックのほとんどの Direct3D コードでは、Direct3D プロジェクトで定義された変数とオブジェクトを参照します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-113">Much of the Direct3D code in this topic refers to variables and objects defined in the Direct3D project.</span></span>

<span data-ttu-id="aca6d-114">OpenGL ES 2.0 で処理する場合の立方体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-114">Here's the cube for processing by OpenGL ES 2.0.</span></span> <span data-ttu-id="aca6d-115">サンプルの実装では、頂点ごとに 7 つの浮動小数点値があります (3 つの位置座標の後に 4 つの RGBA カラー値が続きます)。</span><span class="sxs-lookup"><span data-stu-id="aca6d-115">In the sample implementation, each vertex is 7 float values: 3 position coordinates followed by 4 RGBA color values.</span></span>

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

<span data-ttu-id="aca6d-116">Direct3D 11 で処理する場合の同じ立方体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-116">And here's the same cube for processing by Direct3D 11.</span></span>

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

<span data-ttu-id="aca6d-117">このコードを確認すると、OpenGL ES 2.0 コードの立方体が右手座標系で表されているのに対し、Direct3D 固有のコードの立方体が左手座標系で表されていることがわかります。</span><span class="sxs-lookup"><span data-stu-id="aca6d-117">Reviewing this code, you notice that the cube in the OpenGL ES 2.0 code is represented in a right-hand coordinate system, whereas the cube in the Direct3D-specific code is represented in a left-hand coordinate system.</span></span> <span data-ttu-id="aca6d-118">自分のメッシュ データをインポートする際は、モデルの z 軸の座標を反転させ、座標系の変更に従って三角形を走査するように各メッシュのインデックスを適切に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="aca6d-118">When importing your own mesh data, you must reverse the z-axis coordinates for your model and change the indices for each mesh accordingly to traverse the triangles according to the change in the coordinate system.</span></span>

<span data-ttu-id="aca6d-119">立方体のメッシュを OpenGL ES 2.0 の右手座標系から Direct3D の左手座標系に正常に移植できたことを前提に、両方のモデルで処理する立方体データを読み込む方法を見ていきます。</span><span class="sxs-lookup"><span data-stu-id="aca6d-119">Assuming that we have successfully moved the cube mesh from the right-handed OpenGL ES 2.0 coordinate system to the left-handed Direct3D one, let's see how to load the cube data for processing in both models.</span></span>

## <a name="instructions"></a><span data-ttu-id="aca6d-120">手順</span><span class="sxs-lookup"><span data-stu-id="aca6d-120">Instructions</span></span>

### <a name="step-1-create-an-input-layout"></a><span data-ttu-id="aca6d-121">手順 1: 入力レイアウトの作成</span><span class="sxs-lookup"><span data-stu-id="aca6d-121">Step 1: Create an input layout</span></span>

<span data-ttu-id="aca6d-122">OpenGL ES 2.0 では、頂点データを attribute として渡し、シェーダー オブジェクトがそれを受け取って、読み取ります。</span><span class="sxs-lookup"><span data-stu-id="aca6d-122">In OpenGL ES 2.0, your vertex data is supplied as attributes that will be supplied to and read by the shader objects.</span></span> <span data-ttu-id="aca6d-123">通常、シェーダーの GLSL で使われる attribute 名を含む文字列をシェーダー プログラム オブジェクトに渡し、シェーダーに渡すことができるメモリの場所を取得します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-123">You typically provide a string that contains the attribute name used in the shader's GLSL to the shader program object, and get a memory location back that you can supply to the shader.</span></span> <span data-ttu-id="aca6d-124">この例では、次のように定義され、フォーマットされたカスタムの Vertex 構造体の一覧を頂点バッファー オブジェクトに含めます。</span><span class="sxs-lookup"><span data-stu-id="aca6d-124">In this example, a vertex buffer object contains a list of custom Vertex structures, defined and formatted as follows:</span></span>

<span data-ttu-id="aca6d-125">OpenGL ES 2.0: 頂点ごとの情報を含む attribute の構成</span><span class="sxs-lookup"><span data-stu-id="aca6d-125">OpenGL ES 2.0: Configure the attributes that contain the per-vertex information.</span></span>

``` syntax
typedef struct 
{
  GLfloat pos[3];        
  GLfloat rgba[4];
} Vertex;
```

<span data-ttu-id="aca6d-126">OpenGL ES 2.0 では、入力レイアウトは暗黙的です。汎用の GL\_ELEMENT\_ARRAY\_BUFFER を受け取り、頂点シェーダーがデータをアップロード後に解釈できるようにストライドとオフセットを渡します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-126">In OpenGL ES 2.0, input layouts are implicit; you take a general purpose GL\_ELEMENT\_ARRAY\_BUFFER and supply the stride and offset such that the vertex shader can interpret the data after uploading it.</span></span> <span data-ttu-id="aca6d-127">レンダリングする前に、**glVertexAttribPointer** を使って、どの attribute が頂点データの各ブロックのどの部分にマップされるかをシェーダーに通知します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-127">You inform the shader before rendering which attributes map to which portions of each block of vertex data with **glVertexAttribPointer**.</span></span>

<span data-ttu-id="aca6d-128">Direct3D では、ジオメトリを描画する前ではなく、バッファーを作成するときに、頂点バッファー内の頂点データの構造体を記述した入力レイアウトを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="aca6d-128">In Direct3D, you must provide an input layout to describe the structure of the vertex data in the vertex buffer when you create the buffer, instead of before you draw the geometry.</span></span> <span data-ttu-id="aca6d-129">そのためには、メモリ内の個々の頂点データのレイアウトに対応する入力レイアウトを使います。</span><span class="sxs-lookup"><span data-stu-id="aca6d-129">To do this, you use an input layout which corresponds to layout of the data for our individual vertices in memory.</span></span> <span data-ttu-id="aca6d-130">これを正確に指定することが非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="aca6d-130">It is very important to specify this accurately!</span></span>

<span data-ttu-id="aca6d-131">次に、入力の記述を [**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) 構造体の配列として作成します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-131">Here, you create an input description as an array of [**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) structures.</span></span>

<span data-ttu-id="aca6d-132">Direct3D: 入力レイアウトの記述の定義</span><span class="sxs-lookup"><span data-stu-id="aca6d-132">Direct3D: Define an input layout description.</span></span>

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

<span data-ttu-id="aca6d-133">この入力の記述では、頂点を 2 つの 3 座標ベクトルのペアとして定義します。1 つの 3D ベクトルにはモデル座標内の頂点の位置を格納し、もう 1 つの 3D ベクトルには頂点に関連付けられている RGB 色値を格納します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-133">This input description defines a vertex as a pair of 2 3-coordinate vectors: one 3D vector to store the position of the vertex in model coordinates, and another 3D vector to store the RGB color value associated with the vertex.</span></span> <span data-ttu-id="aca6d-134">この場合は、3x32 ビットの浮動小数点形式を使います。コードではその要素を `XMFLOAT3(X.Xf, X.Xf, X.Xf)` として表します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-134">In this case, you use 3x32 bit floating point format, elements of which we represent in code as `XMFLOAT3(X.Xf, X.Xf, X.Xf)`.</span></span> <span data-ttu-id="aca6d-135">シェーダーで使われるデータを処理する場合は、必ず [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/ee415574) ライブラリの型を使って、そのデータのパッキングとアラインメントが適切に行われるようにする必要があります </span><span class="sxs-lookup"><span data-stu-id="aca6d-135">You should use types from the [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/ee415574) library whenever you are handling data that will be used by a shader, as it ensure the proper packing and alignment of that data.</span></span> <span data-ttu-id="aca6d-136">(たとえば、ベクトル データには [**XMFLOAT3**](https://msdn.microsoft.com/library/windows/desktop/ee419475) または [**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) を使い、マトリックスには [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) を使います)。</span><span class="sxs-lookup"><span data-stu-id="aca6d-136">(For example, use [**XMFLOAT3**](https://msdn.microsoft.com/library/windows/desktop/ee419475) or [**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) for vector data, and [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) for matrices.)</span></span>

<span data-ttu-id="aca6d-137">使うことができるすべての形式の種類の一覧については、「[**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="aca6d-137">For a list of all the possible format types, refer to [**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059).</span></span>

<span data-ttu-id="aca6d-138">頂点ごとの入力レイアウトを定義して、レイアウト オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-138">With the per-vertex input layout defined, you create the layout object.</span></span> <span data-ttu-id="aca6d-139">次のコードでは、それを ([**ID3D11InputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476575) 型のオブジェクトを指す) **ComPtr** 型の変数 **m\_inputLayout** に書き込みます。</span><span class="sxs-lookup"><span data-stu-id="aca6d-139">In the following code, you write it to **m\_inputLayout**, a variable of type **ComPtr** (which points to an object of type [**ID3D11InputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476575)).</span></span> <span data-ttu-id="aca6d-140">**fileData** には、前の手順の「[シェーダー オブジェクトの移植](port-the-shader-config.md)」のコンパイル済み頂点シェーダー オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="aca6d-140">**fileData** contains the compiled vertex shader object from the previous step, [Port the shaders](port-the-shader-config.md).</span></span>

<span data-ttu-id="aca6d-141">Direct3D: 頂点バッファーで使われる入力レイアウトの作成</span><span class="sxs-lookup"><span data-stu-id="aca6d-141">Direct3D: Create the input layout used by the vertex buffer.</span></span>

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

<span data-ttu-id="aca6d-142">ここまでで、入力レイアウトを定義しました。</span><span class="sxs-lookup"><span data-stu-id="aca6d-142">We've defined the input layout.</span></span> <span data-ttu-id="aca6d-143">次は、このレイアウトを使うバッファーを作成し、それを立方体のメッシュ データと一緒に読み込みます。</span><span class="sxs-lookup"><span data-stu-id="aca6d-143">Now, let's create a buffer that uses this layout and load it with the cube mesh data.</span></span>

### <a name="step-2-create-and-load-the-vertex-buffers"></a><span data-ttu-id="aca6d-144">手順 2: 頂点バッファーの作成と読み込み</span><span class="sxs-lookup"><span data-stu-id="aca6d-144">Step 2: Create and load the vertex buffer(s)</span></span>

<span data-ttu-id="aca6d-145">OpenGL ES 2.0 では、2 つのバッファー (位置データ用と色データ用) を作成します </span><span class="sxs-lookup"><span data-stu-id="aca6d-145">In OpenGL ES 2.0, you create a pair of buffers, one for the position data and one for the color data.</span></span> <span data-ttu-id="aca6d-146">(また、両方を含む構造体と 1 つのバッファーを作成することもできます)。各バッファーをバインドし、位置データと色データをバッファーに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="aca6d-146">(You could also create a struct that contains both and a single buffer.) You bind each buffer and write position and color data into them.</span></span> <span data-ttu-id="aca6d-147">その後、レンダリング関数の実行時に、もう一度バッファーをバインドし、シェーダーが正しく解釈できるようにバッファー内のデータの形式をシェーダーに通知します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-147">Later, during your render function, bind the buffers again and provide the shader with the format of the data in the buffer so it can correctly interpret it.</span></span>

<span data-ttu-id="aca6d-148">OpenGL ES 2.0: 頂点バッファーのバインド</span><span class="sxs-lookup"><span data-stu-id="aca6d-148">OpenGL ES 2.0: Bind the vertex buffers</span></span>

``` syntax
// upload the data for the vertex position buffer
glGenBuffers(1, &renderer->vertexBuffer);    
glBindBuffer(GL_ARRAY_BUFFER, renderer->vertexBuffer);
glBufferData(GL_ARRAY_BUFFER, sizeof(VERTEX) * CUBE_VERTICES, renderer->vertices, GL_STATIC_DRAW);   
```

<span data-ttu-id="aca6d-149">Direct3D では、シェーダーがアクセスできるバッファーは [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) 構造体として表されます。</span><span class="sxs-lookup"><span data-stu-id="aca6d-149">In Direct3D, shader-accessible buffers are represented as [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) structures.</span></span> <span data-ttu-id="aca6d-150">このバッファーの場所をシェーダー オブジェクトにバインドするには、[**ID3DDevice::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) を使って、各バッファーの CD3D11\_BUFFER\_DESC 構造体を作成し、[**ID3DDeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456) などのバッファーの種類に固有の設定メソッドを呼び出して、Direct3D デバイス コンテキストのバッファーを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="aca6d-150">To bind the location of this buffer to shader object, you need to create a CD3D11\_BUFFER\_DESC structure for each buffer with [**ID3DDevice::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501), and then set the buffer of the Direct3D device context by calling a set method specific to the buffer type, such as [**ID3DDeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456).</span></span>

<span data-ttu-id="aca6d-151">バッファーを設定するときに、ストライド (個々の頂点のデータ要素のサイズ) とバッファーの先頭からのオフセット (実際に頂点データの配列が始まる位置) を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="aca6d-151">When you set the buffer, you must set the stride (the size of the data element for an individual vertex) as well the offset (where the vertex data array actually starts) from the beginning of the buffer.</span></span>

<span data-ttu-id="aca6d-152">[**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) 構造体の **pSysMem** フィールドに **vertexIndices** 配列へのポインターを割り当てることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="aca6d-152">Notice that we assign the pointer to the **vertexIndices** array to the **pSysMem** field of the [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) structure.</span></span> <span data-ttu-id="aca6d-153">これを正しく行わないと、メッシュの形が正しく表示されないか、空になります。</span><span class="sxs-lookup"><span data-stu-id="aca6d-153">If this isn't correct, your mesh will be corrupt or empty!</span></span>

<span data-ttu-id="aca6d-154">Direct3D: 頂点バッファーの作成と設定</span><span class="sxs-lookup"><span data-stu-id="aca6d-154">Direct3D: Create and set the vertex buffer</span></span>

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

### <a name="step-3-create-and-load-the-index-buffer"></a><span data-ttu-id="aca6d-155">手順 3: インデックス バッファーの作成と読み込み</span><span class="sxs-lookup"><span data-stu-id="aca6d-155">Step 3: Create and load the index buffer</span></span>

<span data-ttu-id="aca6d-156">インデックス バッファーは、頂点シェーダーが個々の頂点を検索できるようにする効率的な方法です。</span><span class="sxs-lookup"><span data-stu-id="aca6d-156">Index buffers are an efficient way to allow the vertex shader to look up individual vertices.</span></span> <span data-ttu-id="aca6d-157">これは必須ではありませんが、このサンプルのレンダラーでは使います。</span><span class="sxs-lookup"><span data-stu-id="aca6d-157">Although they are not required, we use them in this sample renderer.</span></span> <span data-ttu-id="aca6d-158">OpenGL ES 2.0 の頂点バッファーと同じように、インデックス バッファーを汎用のバッファーとして作成してバインドし、前に作成した頂点インデックスをインデックス バッファーにコピーします。</span><span class="sxs-lookup"><span data-stu-id="aca6d-158">As with vertex buffers in OpenGL ES 2.0, an index buffer is created and bound as a general purpose buffer and the vertex indices you created earlier are copied into it.</span></span>

<span data-ttu-id="aca6d-159">描画する準備ができたら、もう一度頂点バッファーとインデックス バッファーの両方をバインドし、**glDrawElements** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-159">When you're ready to draw, you bind both the vertex and the index buffer again, and call **glDrawElements**.</span></span>

<span data-ttu-id="aca6d-160">OpenGL ES 2.0: 描画呼び出しへのインデックスの順序の送信</span><span class="sxs-lookup"><span data-stu-id="aca6d-160">OpenGL ES 2.0: Send the index order to the draw call.</span></span>

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

<span data-ttu-id="aca6d-161">Direct3D の場合、プロセスは非常に似ていますが、多少説明が必要です。</span><span class="sxs-lookup"><span data-stu-id="aca6d-161">With Direct3D, it's a bit very similar process, albeit a bit more didactic.</span></span> <span data-ttu-id="aca6d-162">Direct3D を構成したときに作成した [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) にインデックス バッファーを Direct3D サブリソースとして渡します。</span><span class="sxs-lookup"><span data-stu-id="aca6d-162">Supply the index buffer as a Direct3D subresource to the [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) you created when you configured Direct3D.</span></span> <span data-ttu-id="aca6d-163">これを行うには、次のように、インデックスの配列の構成済みのサブリソースを指定して [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/bb173588) を呼び出します </span><span class="sxs-lookup"><span data-stu-id="aca6d-163">You do this by calling [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/bb173588) with the configured subresource for the index array, as follows.</span></span> <span data-ttu-id="aca6d-164">(ここでも、[**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) 構造体の **pSysMem** フィールドに **cubeIndices** 配列へのポインターを割り当てることに注意してください)。</span><span class="sxs-lookup"><span data-stu-id="aca6d-164">(Again, notice that you assign the pointer to the **cubeIndices** array to the **pSysMem** field of the [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) structure.)</span></span>

<span data-ttu-id="aca6d-165">Direct3D: インデックス バッファーの作成</span><span class="sxs-lookup"><span data-stu-id="aca6d-165">Direct3D: Create the index buffer.</span></span>

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

<span data-ttu-id="aca6d-166">その後、次のように、[**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) (インデックスなしの頂点の場合は [**ID3D11DeviceContext::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407)) を呼び出して、三角形を描画します </span><span class="sxs-lookup"><span data-stu-id="aca6d-166">Later, you will draw the triangles with a call to [**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) (or [**ID3D11DeviceContext::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407) for unindexed vertices), as follows.</span></span> <span data-ttu-id="aca6d-167">(詳しくは、一足先に「[画面への描画](draw-to-the-screen.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="aca6d-167">(For more details, jump ahead to [Draw to the screen](draw-to-the-screen.md).)</span></span>

<span data-ttu-id="aca6d-168">Direct3D: インデックス付きの頂点の描画</span><span class="sxs-lookup"><span data-stu-id="aca6d-168">Direct3D: Draw the indexed vertices.</span></span>

``` syntax
m_d3dContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
m_d3dContext->IASetInputLayout(m_inputLayout.Get());

// ...

m_d3dContext->DrawIndexed(
  m_indexCount,
  0,
  0);
```

## <a name="previous-step"></a><span data-ttu-id="aca6d-169">前の手順</span><span class="sxs-lookup"><span data-stu-id="aca6d-169">Previous step</span></span>


[<span data-ttu-id="aca6d-170">シェーダー オブジェクトの移植</span><span class="sxs-lookup"><span data-stu-id="aca6d-170">Port the shader objects</span></span>](port-the-shader-config.md)

## <a name="next-step"></a><span data-ttu-id="aca6d-171">次の手順</span><span class="sxs-lookup"><span data-stu-id="aca6d-171">Next step</span></span>

[<span data-ttu-id="aca6d-172">GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="aca6d-172">Port the GLSL</span></span>](port-the-glsl.md)

## <a name="remarks"></a><span data-ttu-id="aca6d-173">注釈</span><span class="sxs-lookup"><span data-stu-id="aca6d-173">Remarks</span></span>

<span data-ttu-id="aca6d-174">Direct3D を構築する場合は、[**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) のメソッドを呼び出すコードを切り離して、デバイス リソースを再作成する必要があるたびに呼び出されるメソッドに配置します </span><span class="sxs-lookup"><span data-stu-id="aca6d-174">When structuring your Direct3D, separate the code that calls methods on [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) into a method that is called whenever the device resources need to be recreated.</span></span> <span data-ttu-id="aca6d-175">(Direct3D プロジェクト テンプレートでは、このコードはレンダラー オブジェクトの **CreateDeviceResource** メソッドに配置されています)。</span><span class="sxs-lookup"><span data-stu-id="aca6d-175">(In the Direct3D project template, this code is in the renderer object's **CreateDeviceResource** methods.</span></span> <span data-ttu-id="aca6d-176">また、デバイス コンテキスト ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)) を更新するコードは **Render** メソッドに配置されています。そこで実際にシェーダー ステージを作成し、データをバインドするためです。</span><span class="sxs-lookup"><span data-stu-id="aca6d-176">The code that updates the device context ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)), on the other hand, is placed in the **Render** method, since this is where you actually construct the shader stages and bind the data.</span></span>

## <a name="related-topics"></a><span data-ttu-id="aca6d-177">関連トピック</span><span class="sxs-lookup"><span data-stu-id="aca6d-177">Related topics</span></span>


* [<span data-ttu-id="aca6d-178">簡単な OpenGL ES 2.0 レンダラーを Direct3D 11 に移植する方法</span><span class="sxs-lookup"><span data-stu-id="aca6d-178">How to: port a simple OpenGL ES 2.0 renderer to Direct3D 11</span></span>](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)
* [<span data-ttu-id="aca6d-179">シェーダー オブジェクトの移植</span><span class="sxs-lookup"><span data-stu-id="aca6d-179">Port the shader objects</span></span>](port-the-shader-config.md)
* [<span data-ttu-id="aca6d-180">頂点バッファーと頂点データの移植</span><span class="sxs-lookup"><span data-stu-id="aca6d-180">Port the vertex buffers and data</span></span>](port-the-vertex-buffers-and-data-config.md)
* [<span data-ttu-id="aca6d-181">GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="aca6d-181">Port the GLSL</span></span>](port-the-glsl.md)

 

 




