---
title: 基本的なメッシュの作成と表示
description: 3-D のユニバーサル Windows プラットフォーム (UWP) ゲームでは、通常は多角形を使ってゲーム内のオブジェクトやサーフェスを表現します。
ms.assetid: bfe0ed5b-63d8-935b-a25b-378b36982b7d
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、メッシュ、DirectX
ms.localizationpriority: medium
ms.openlocfilehash: d3b6717c0b2d9d85e9c81e78fcaa1df1abbea23b
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7693612"
---
# <a name="create-and-display-a-basic-mesh"></a>基本的なメッシュの作成と表示



3-D のユニバーサル Windows プラットフォーム (UWP) ゲームでは、通常は多角形を使ってゲーム内のオブジェクトやサーフェスを表現します。 そのような多角形によるオブジェクトやサーフェスの構造を構成する頂点のリストをメッシュと呼びます。 ここでは、立方体オブジェクトの基本的なメッシュを作り、シェーダー パイプラインに渡してレンダリングと表示を行います。

> **重要な**含まれているコードの例は、ここで (directx::xmfloat3:xmfloat4x4 など) の型と DirectXMath.h で宣言されているインライン メソッドに使用します。 このコードを切り取って貼り付ける場合は、プロジェクトに \#include &lt;DirectXMath.h&gt; を含めてください。

 

## <a name="what-you-need-to-know"></a>理解しておく必要があること


### <a name="technologies"></a>テクノロジ

-   [Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh769064)

### <a name="prerequisites"></a>前提条件

-   線形代数と 3-D 座標系の基本的な知識
-   Visual Studio 2015 またはそれ以降の Direct3D テンプレート

## <a name="instructions"></a>手順

次の手順では、基本的なメッシュ立方体を作成する方法を説明します。 


これらの概念の説明を聞くことを希望する場合には、このビデオをご覧ください。
</br>
</br>
<iframe src="https://channel9.msdn.com/Series/Introduction-to-C-and-DirectX-Game-Development/03/player#time=7m39s:paused" width="600" height="338" allowFullScreen frameBorder="0"></iframe>


### <a name="step-1-construct-the-mesh-for-the-model"></a>手順 1: モデルのメッシュを構成する

ほとんどのゲームでは、ゲーム オブジェクトのメッシュは特定の頂点データが含まれるファイルからロードされます。 頂点の順序はアプリに依存していますが、通常は帯状または扇状にシリアル化されます。 頂点データは、ソフトウェア ソースからのものを使うことも、手動で作ることもできます。 頂点シェーダーが効果的に処理できる方法でデータを解釈するかどうかはゲーム次第です。

この例では、立方体用にシンプルなメッシュを使います。 立方体は、パイプラインのこの段階ではあらゆるオブジェクト メッシュと同様に、専用の座標系を使って表されます。 頂点シェーダーはその座標を使い、指定された変換マトリックスを適用して、同一座標系での最終的な 2-D ビュー プロジェクションを返します。

立方体のメッシュを定義します。 (またはファイルからロードします。 決めるのはあなたです)

```cpp
SimpleCubeVertex cubeVertices[] =
{
    { DirectX::XMFLOAT3(-0.5f, 0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f) }, // +Y (top face)
    { DirectX::XMFLOAT3( 0.5f, 0.5f, -0.5f), DirectX::XMFLOAT3(1.0f, 1.0f, 0.0f) },
    { DirectX::XMFLOAT3( 0.5f, 0.5f,  0.5f), DirectX::XMFLOAT3(1.0f, 1.0f, 1.0f) },
    { DirectX::XMFLOAT3(-0.5f, 0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 1.0f) },

    { DirectX::XMFLOAT3(-0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f) }, // -Y (bottom face)
    { DirectX::XMFLOAT3( 0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(1.0f, 0.0f, 1.0f) },
    { DirectX::XMFLOAT3( 0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(1.0f, 0.0f, 0.0f) },
    { DirectX::XMFLOAT3(-0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 0.0f) },
};
```

立方体の座標系では立方体の中心が原点になり、Y 軸が上下を貫き、左手による座標系を使います。 座標値は、-1 ～ 1 の 32 ビット浮動小数点値で表されます。

かっこ対ごとに 2 つ目の DirectX::XMFLOAT3 値グループは、頂点と関連付けられた色 (RGB 値) を指定します。 たとえば、(-0.5, 0.5, -0.5) にある 1 番目の頂点は、完全に緑色 (G 値が 1.0、R 値と B 値は 0 に設定) です。

最終的に 8 つの頂点があり、それぞれに特定の色が割り当てられています。 頂点/色の各ペアは、この例で使う頂点のフル データになっています。 頂点バッファーを指定する場合は、この具体的なレイアウトを念頭に置いておく必要があります。 この入力レイアウトを頂点シェーダーに渡して、頂点データが頂点シェーダーで理解されるようにします。

### <a name="step-2-set-up-the-input-layout"></a>手順 2: 入力レイアウトを設定する

現在、頂点はメモリ内に取り込まれています。 ただし、グラフィックス デバイスには専用のメモリがあり、このメモリにアクセスするには Direct3D を使います。 頂点データをグラフィックス デバイスに取り込んで処理するには、言ってみればその方法を明らかにしておく必要があります。グラフィックス デバイスがゲームから頂点データを受け取ったときに解釈できるように、頂点データをどのように配置するのかを宣言しておく必要があるのです。 それには、[**ID3D11InputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476575) を使います。

頂点バッファー用に入力レイアウトを宣言し、設定します。

```cpp
const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
{
    { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0,  0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
    { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};

ComPtr<ID3D11InputLayout> inputLayout;
m_d3dDevice->CreateInputLayout(
                basicVertexLayoutDesc,
                ARRAYSIZE(basicVertexLayoutDesc),
                vertexShaderBytecode->Data,
                vertexShaderBytecode->Length,
                &inputLayout)
);
```

このコードでは、頂点のレイアウト、具体的には頂点リスト内の各要素に含まれるデータを指定します。 ここでは、**basicVertexLayoutDesc** で 2 つのデータ コンポーネントを指定します。

-   **POSITION**: これは、シェーダーに渡される位置データの HLSL セマンティックです。 このコードでは DirectX::XMFLOAT3、正確には 3D 座標 (x, y, z) に対応する 3 つの 32 ビット浮動小数点値を持つ構造です。 統一された "w" 座標を提供する場合は (この例では DXGI\_FORMAT\_R32G32B32A32\_FLOAT を指定する場合は)、float4 を使うこともできます。 DirectX::XMFLOAT3 と float4 のどちらを使うのかは、ゲームの特定の必要性によって異なります。 メッシュの頂点データが、使う形式に正しく対応していることを確認してください。

    各座標値は、オブジェクトの座標空間内で -1 ～ 1 の浮動小数点値で表されます。 頂点シェーダーが完了すると、変換された頂点は統一された (視点が修正された) ビュー プロジェクション空間内にあります。

    「でも、列挙値は、XYZ ではなく RGB を示しています。」 ご指摘のとおりです。 さすがです! 色データと座標データの両方で、通常は 3 つか 4 つの成分値を使います。それならば両方で同じ形式を使わないのはなぜなのでしょうか。 HLSL セマンティックは形式の名前ではなく、シェーダーがデータを扱う方法を表します。

-   **COLOR**: これは、色データの HLSL セマンティックです。 **POSITION** と同様に、3 つの 32 ビット浮動小数点値 (DirectX::XMFLOAT3) で構成されます。 それぞれの値は、0 ～ 1 の浮動小数点値で表される色成分の赤 (r)、青 (b)、または緑 (g) を含みます。

    通常、**COLOR** の値は、シェーダー パイプラインの最後に 4 成分の RGBA 値として返されます。 この例では、すべてのピクセルについて、シェーダー パイプラインで "A" アルファ値を 1.0 (最大不透明度) に設定します。

形式の全一覧については、[**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059) をご覧ください。 HLSL セマンティックの全一覧については、「[セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)」をご覧ください。

[**ID3D11Device::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512) を呼び出し、Direct3D デバイスで入力レイアウトを作ります。 次に、データを実際に保持できるバッファーを作る必要があります。

### <a name="step-3-populate-the-vertex-buffers"></a>手順 3: 頂点バッファーを設定する

頂点バッファーには、メッシュの各三角形の頂点のリストが含まれます。 各頂点は、このリストで一意である必要があります。 この例では、立方体に 8 個の頂点があります。 頂点シェーダーはグラフィックス デバイス上で実行され、頂点バッファーからデータを読み取ります。データは、前の手順で指定した入力レイアウトに基づいて解釈されます。

次の例では、バッファーの説明とサブリソースを指定します。バッファーは、頂点データの物理マッピングと、グラフィックス デバイスのメモリで扱う方法を Direct3D に知らせます。 何でも格納できる汎用 [**ID3D11Buffer**](https://msdn.microsoft.com/library/windows/desktop/ff476351) を使うため、これは必要です。 [**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) 構造体と [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) 構造体は、バッファー内の各頂点要素のサイズや頂点リストの最大サイズなど、Direct3D がバッファーの物理メモリ レイアウトを理解できるようにするために提供されます。 ここではバッファー メモリへのアクセスや走査方法も制御できますが、その説明はこのチュートリアルの範囲を少々超えています。

バッファーを構成したら、[**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) を呼び出して、実際にバッファーを作ります。 明らかなことですが、複数のオブジェクトがある場合は、固有のモデルごとにバッファーを作ります。

頂点バッファーを宣言して作ります。

```cpp
D3D11_BUFFER_DESC vertexBufferDesc = {0};
vertexBufferDesc.ByteWidth = sizeof(SimpleCubeVertex) * ARRAYSIZE(cubeVertices);
vertexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
vertexBufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
vertexBufferDesc.CPUAccessFlags = 0;
vertexBufferDesc.MiscFlags = 0;
vertexBufferDesc.StructureByteStride = 0;

D3D11_SUBRESOURCE_DATA vertexBufferData;
vertexBufferData.pSysMem = cubeVertices;
vertexBufferData.SysMemPitch = 0;
vertexBufferData.SysMemSlicePitch = 0;

ComPtr<ID3D11Buffer> vertexBuffer;
m_d3dDevice->CreateBuffer(
                &vertexBufferDesc,
                &vertexBufferData,
                &vertexBuffer);
```

頂点がロードされます。 しかし、これらの頂点を処理する順序はどうなるのでしょうか。 順序はインデックスのリストを頂点に割り当てるときに処理されます。インデックスの順序が頂点シェーダーが頂点を処理する順序になります。

### <a name="step-4-populate-the-index-buffers"></a>手順 4: インデックス バッファーを設定する

これから各頂点のインデックスのリストを用意します。 インデックスは頂点バッファーで頂点の位置に対応し、0 から始まります。 この様子を視覚化するために、メッシュの各頂点に ID のような固有の番号が割り当てられていると考えます。 この ID は、頂点バッファーで頂点の位置を表す整数です。

![8 個の頂点がある立方体](images/cube-mesh-1.png)

この立方体の例では、8 個の頂点があります。4 個の頂点で側面を形成し、4 個セットが 6 組あります。 この 4 個セットを三角形に分割すると、8 個の頂点を使った三角形が合計で 12 個できます。 三角形 1 個あたり 3 個の頂点があるので、インデックス バッファーには 36 個のエントリがあります。 この例に示したインデックスのパターンは三角形リストと呼ばれ、三角形リストはプリミティブ トポロジを設定するときに Direct3D に対して **D3D11\_PRIMITIVE\_TOPOLOGY\_TRIANGLELIST** として指定します。

これはインデックスをリストする方法としてはおそらく最も非効率的でしょう。三角形が点や辺を共有すると、多くの冗長部分があります。 たとえば、三角形がひし形状に辺を共有している場合は、次のように 4 個の頂点で 6 個のインデックスをリストします。

![ひし形を構成するときのインデックスの順序](images/rhombus-surface-1.png)

-   三角形 1: \[0, 1, 2\]
-   三角形 2: \[0, 2, 3\]

帯や扇のトポロジでは、走査時に多くの冗長な辺 (この図ではインデックス 0 からインデックス 2 への辺) を取り除くようにして頂点の順序を決めます。大きなメッシュになると、これで頂点シェーダーの実行回数が劇的に少なくなり、パフォーマンスが大きく向上します。 ただし、ここではシンプルなまま、三角形リストに沿っておきます。

頂点バッファーのインデックスをシンプルな三角形リスト トポロジとして宣言します。

```cpp
unsigned short cubeIndices[] =
{   0, 1, 2,
    0, 2, 3,

    4, 5, 6,
    4, 6, 7,

    3, 2, 5,
    3, 5, 4,

    2, 1, 6,
    2, 6, 5,

    1, 7, 6,
    1, 0, 7,

    0, 3, 4,
    0, 4, 7 };
```

頂点がわずか 8 個しかないのにバッファーに 36 個のインデックス要素があるというのは、非常に冗長です。 冗長さを若干取り除いて、帯状や扇状など別の頂点リスト タイプを使う場合は、[**ID3D11DeviceContext::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) メソッドに特定の [**D3D11\_PRIMITIVE\_TOPOLOGY**](https://msdn.microsoft.com/library/windows/desktop/ff476189) 値を渡すときにそのタイプを指定する必要があります。

さまざまなインデックス リストの手法について詳しくは、「[プリミティブ トポロジ](https://msdn.microsoft.com/library/windows/desktop/bb205124)」をご覧ください。

### <a name="step-5-create-a-constant-buffer-for-your-transformation-matrices"></a>手順 5: 変換マトリックス用の定数バッファーを作る

頂点の処理を開始する前に、実行時に各頂点に適用 (乗算) する変換マトリックスを指定する必要があります。 ほとんどの 3-D ゲームには、3 種類の変換マトリックスがあります。

-   オブジェクト (モデル) 座標系から全体のワールド座標系に変換する 4x4 マトリックス。
-   ワールド座標系からカメラ (ビュー) 座標系に変換する 4x4 マトリックス。
-   カメラ座標系から 2-D ビュー プロジェクション座標系に変換する 4x4 マトリックス。

これらのマトリックスは、*定数バッファー*でシェーダーに渡されます。 定数バッファーは、シェーダー パイプラインの次のパスを実行する間、定数を保持するメモリ領域のことで、HLSL コードからシェーダーを使って直接アクセスできます。 各定数バッファーは 2 回定義します。ゲームの C++ コードで 1 回、そして C ライクな HLSL 構文のシェーダー コードで (少なくとも) 1 回です。 この 2 回の宣言は、タイプとデータの配置に関して直接対応している必要があります。 C++ で宣言されたデータを解釈するためにシェーダーで HLSL 宣言を使うと、発見が困難なエラーが紛れ込みやすくなり、タイプが一致しなかったりデータの配置が揃わなかったりします。

定数バッファーは、HLSL で変更されません。 ゲームで特定のデータを更新するときに、定数バッファーを変更できます。 ゲーム開発者は、定数バッファーを 4 種類作ることがよくあります。フレームごとの更新用、モデルやオブジェクトごとの更新用、ゲーム状態のリフレッシュごとの更新用、そしてゲームの存続中は変更することのないデータ用です。

この例では、変更することがない定数バッファーのみを用意します。3 つのマトリックスの DirectX::XMFLOAT4X4 データです。

> **注:** ここに示すコード例は、列優先マトリックスを使用します。 HLSL で **row\_major** キーワードを使うと、代わりに行優先マトリックスを使うことができ、ソース マトリックス データも行優先になります。 DirectXMath は行優先マトリックスを使います。**row\_major** キーワードで定義される HLSL マトリックスを使うと、DirectXMath を直接使うことができます。

 

各頂点を変換するために使う 3 つのマトリックスの定数バッファーを宣言して作ります。

```cpp
struct ConstantBuffer
{
    DirectX::XMFLOAT4X4 model;
    DirectX::XMFLOAT4X4 view;
    DirectX::XMFLOAT4X4 projection;
};
ComPtr<ID3D11Buffer> m_constantBuffer;
ConstantBuffer m_constantBufferData;

// ...

// Create a constant buffer for passing model, view, and projection matrices
// to the vertex shader.  This allows us to rotate the cube and apply
// a perspective projection to it.

D3D11_BUFFER_DESC constantBufferDesc = {0};
constantBufferDesc.ByteWidth = sizeof(m_constantBufferData);
constantBufferDesc.Usage = D3D11_USAGE_DEFAULT;
constantBufferDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
constantBufferDesc.CPUAccessFlags = 0;
constantBufferDesc.MiscFlags = 0;
constantBufferDesc.StructureByteStride = 0;
m_d3dDevice->CreateBuffer(
                &constantBufferDesc,
                nullptr,
                &m_constantBuffer
             );

m_constantBufferData.model = DirectX::XMFLOAT4X4( // Identity matrix, since you are not animating the object
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f);

);
// Specify the view (camera) transform corresponding to a camera position of
// X = 0, Y = 1, Z = 2.  

m_constantBufferData.view = DirectX::XMFLOAT4X4(
            -1.00000000f, 0.00000000f,  0.00000000f,  0.00000000f,
             0.00000000f, 0.89442718f,  0.44721359f,  0.00000000f,
             0.00000000f, 0.44721359f, -0.89442718f, -2.23606800f,
             0.00000000f, 0.00000000f,  0.00000000f,  1.00000000f);
```

> **注:** 通常ためにを宣言する射影行列デバイス固有のリソースをセットアップするときに乗算の結果は、現在の 2 D ビューポート サイズ パラメーターに一致する必要があります (多くの場合、ピクセルの高さと幅に対応していますが、表示する)。 これらのパラメーターを変更する場合は、それに合わせて x 座標と y 座標の値をスケーリングする必要があります。

 

```cpp
// Finally, update the constant buffer perspective projection parameters
// to account for the size of the application window.  In this sample,
// the parameters are fixed to a 70-degree field of view, with a depth
// range of 0.01 to 100.  

float xScale = 1.42814801f;
float yScale = 1.42814801f;
if (backBufferDesc.Width > backBufferDesc.Height)
{
    xScale = yScale *
                static_cast<float>(backBufferDesc.Height) /
                static_cast<float>(backBufferDesc.Width);
}
else
{
    yScale = xScale *
                static_cast<float>(backBufferDesc.Width) /
                static_cast<float>(backBufferDesc.Height);
}
m_constantBufferData.projection = DirectX::XMFLOAT4X4(
            xScale, 0.0f,    0.0f,  0.0f,
            0.0f,   yScale,  0.0f,  0.0f,
            0.0f,   0.0f,   -1.0f, -0.01f,
            0.0f,   0.0f,   -1.0f,  0.0f
            );
```

ここで、[ID3D11DeviceContext](https://msdn.microsoft.com/library/windows/desktop/ff476149)で頂点バッファーとインデックス バッファー、そして使っているトポロジを設定します。

```cpp
// Set the vertex and index buffers, and specify the way they define geometry.
UINT stride = sizeof(SimpleCubeVertex);
UINT offset = 0;
m_d3dDeviceContext->IASetVertexBuffers(
                0,
                1,
                vertexBuffer.GetAddressOf(),
                &stride,
                &offset);

m_d3dDeviceContext->IASetIndexBuffer(
                indexBuffer.Get(),
                DXGI_FORMAT_R16_UINT,
                0);

 m_d3dDeviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
```

よくできました。 入力の組み立ては完了です。 レンダリングの準備はすべて整いました。 それでは頂点シェーダーを使ってみましょう。

### <a name="step-6-process-the-mesh-with-the-vertex-shader"></a>手順 6: 頂点シェーダーでメッシュを処理する

メッシュを定義する頂点を格納する頂点バッファーと、頂点の処理順序を定義するインデックス バッファーができたので、これから頂点シェーダーに頂点を送信します。 頂点シェーダーのコードは、コンパイルされた上位レベル シェーダー言語として表されます。頂点バッファー内の頂点ごとに 1 回実行されるため、頂点ごとに変換を実行できます。 最終的な結果は、通常は 2-D プロジェクションになります。

(頂点シェーダーをロードしてありますか? まだの場合は、「[DirectX ゲームでリソースをロードする方法](load-a-game-asset.md)」をご覧ください。)

まず頂点シェーダーを作り ...

``` syntax
// Set the vertex and pixel shader stage state.
m_d3dDeviceContext->VSSetShader(
                vertexShader.Get(),
                nullptr,
                0);
```

... 次に定数バッファーを設定します。

``` syntax
m_d3dDeviceContext->VSSetConstantBuffers(
                0,
                1,
                m_constantBuffer.GetAddressOf());
```

この頂点シェーダーのコードは、オブジェクト座標からワールド座標への変換、その後で 2-D ビュー プロジェクション座標系への変換を処理します。 見た目をよくするために、シンプルな頂点ごとの照明を適用することもできます。 これは、頂点シェーダーの HLSL ファイル (この例では SimplerVertexShader.hlsl) に記載されています。

``` syntax
cbuffer simpleConstantBuffer : register( b0 )
{
    matrix model;
    matrix view;
    matrix projection;
};

struct VertexShaderInput
{
    DirectX::XMFLOAT3 pos : POSITION;
    DirectX::XMFLOAT3 color : COLOR;
};

struct PixelShaderInput
{
    float4 pos : SV_POSITION;
    float4 color : COLOR;
};

PixelShaderInput SimpleVertexShader(VertexShaderInput input)
{
    PixelShaderInput vertexShaderOutput;
    float4 pos = float4(input.pos, 1.0f);

    // Transform the vertex position into projection space.
    pos = mul(pos, model);
    pos = mul(pos, view);
    pos = mul(pos, projection);
    vertexShaderOutput.pos = pos;

    // Pass the vertex color through to the pixel shader.
    vertexShaderOutput.color = float4(input.color, 1.0f);

    return vertexShaderOutput;
}
```

先頭には **cbuffer** があります。 これは、前に C++ コードで宣言した定数バッファーと同じものを HLSL で表現したものです。 **VertexShaderInputstruct** は、 なぜか、作った入力レイアウトや頂点データの宣言とそっくりです。 大切なのは、C++ コードでの定数バッファーと頂点データの宣言が、HLSL コードでの宣言と一致していること、そして符号、タイプ、データの配置が含まれていることです。

**PixelShaderInput** は、頂点シェーダーのメインの関数から返されるデータのレイアウトを指定します。 頂点の処理が完了すると、2-D プロジェクション空間における頂点の位置と、頂点ごとの照明に使われる色を返します。 グラフィックス カードは、シェーダーによるデータ出力を使って "フラグメント" (可能性のあるピクセル) を計算します。フラグメントは、パイプラインの次の段階でピクセル シェーダーが実行されたときに色が付きます。

### <a name="step-7-passing-the-mesh-through-the-pixel-shader"></a>手順 7: ピクセル シェーダーでメッシュを渡す

通常、グラフィックス パイプラインのこの段階では、オブジェクトのプロジェクションされたサーフェスの見えている部分でピクセル単位の操作を実行します  (テクスチャが好まれます)。ただし、これはサンプルなので、この段階では素通りするだけにします。

まず、ピクセル シェーダーのインスタンスを作りましょう。 ピクセル シェーダーは、シーンの 2-D プロジェクションの各ピクセルに対して実行され、そのピクセルに色を割り当てます。 この場合は、頂点シェーダーで返されたピクセルの色を素通りさせます。

ピクセル シェーダーを設定します。

``` syntax
m_d3dDeviceContext->PSSetShader( pixelShader.Get(), nullptr, 0 );
```

HLSL でパススルー ピクセル シェーダーを定義します。

``` syntax
struct PixelShaderInput
{
    float4 pos : SV_POSITION;
};

float4 SimplePixelShader(PixelShaderInput input) : SV_TARGET
{
    // Draw the entire triangle yellow.
    return float4(1.0f, 1.0f, 0.0f, 1.0f);
}
```

このコードを頂点シェーダーの HLSL とは別の HLSL ファイルに配置します (たとえば SimplePixelShader.hlsl)。 このコードは、ビューポート (描画先画面の一部分のメモリ内表現) で見えているピクセルごとに 1 回実行されます。この場合のビューポートは、画面全体にマッピングされます。 これで、グラフィックス パイプラインはすべて定義されました。

### <a name="step-8-rasterizing-and-displaying-the-mesh"></a>手順 8: メッシュのラスタライズと表示

パイプラインを実行しましょう。 手順は簡単です。[**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/bb173565) を呼び出します。

立方体を描画します。

```cpp
// Draw the cube.
m_d3dDeviceContext->DrawIndexed( ARRAYSIZE(cubeIndices), 0, 0 );
            
```

グラフィックス カード内で、各頂点がインデックス バッファーでの指定順に処理されます。 コードが実行されると、頂点シェーダーと 2-D フラグメントが定義されます。次に、ピクセル シェーダーが呼び出されて、三角形に色が付きます。

次に、立方体を画面に配置します。

フレーム バッファーをディスプレイに表示します。

```cpp
// Present the rendered image to the window.  Because the maximum frame latency is set to 1,
// the render loop is generally  throttled to the screen refresh rate, typically around
// 60 Hz, by sleeping the app on Present until the screen is refreshed.

m_swapChain->Present(1, 0);
```

これで、終わりです。 モデルがたくさんあるシーンでは、複数の頂点バッファーとインデックス バッファーを使ってください。モデルのタイプごとにシェーダーがある場合もあります。 各モデルには専用の座標系があり、定数バッファーで定義したマトリックスを使って、座標系を共有されるワールド座標系に変換する必要があることに注意してください。

## <a name="remarks"></a>注釈

このトピックでは、シンプルなジオメトリを自分で作り、表示する方法について取り上げました。 より複雑なジオメトリをファイルからロードしてサンプル専用の頂点バッファー オブジェクト (.vbo) 形式に変換する方法について詳しくは、「[DirectX ゲームでリソースをロードする方法](load-a-game-asset.md)」をご覧ください。  

 

## <a name="related-topics"></a>関連トピック


* [DirectX ゲームでリソースをロードする方法](load-a-game-asset.md)

 

 




