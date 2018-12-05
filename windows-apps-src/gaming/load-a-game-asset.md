---
title: DirectX ゲームでのリソースの読み込み
description: ほとんどのゲームは、ある時点で、ローカル ストレージまたは他のデータ ストリームからリソースとアセット (シェーダー、テクスチャ、定義済みメッシュ、その他のグラフィックス データなど) を読み込みます。
ms.assetid: e45186fa-57a3-dc70-2b59-408bff0c0b41
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、DirectX、リソースの読み込み
ms.localizationpriority: medium
ms.openlocfilehash: ca16dd6115bbbe84529928ca58ee0d3074498728
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8696460"
---
# <a name="load-resources-in-your-directx-game"></a>DirectX ゲームでのリソースの読み込み



ほとんどのゲームは、ある時点で、ローカル ストレージまたは他のデータ ストリームからリソースとアセット (シェーダー、テクスチャ、定義済みメッシュ、その他のグラフィックス データなど) を読み込みます。 ここでは、このようなファイルを読み込んで DirectX C/C++ ユニバーサル Windows プラットフォーム (UWP) ゲームで使う際に考慮すべきことについて、その概要を説明します。

たとえば、ゲームの多角形オブジェクトのメッシュは、別のツールで作成されて特定の形式にエクスポートされている場合があります。 テクスチャなどについても同じことが言えます。フラットな非圧縮ビットマップは、ほとんどのツールで普通に作成でき、ほとんどのグラフィックス API で理解されますが、ゲームで使うにはきわめて効率が悪い可能性があります。 ここでは、Direct3D で使うために 3 種類のグラフィック リソース (メッシュ (モデル)、テクスチャ (ビットマップ) と、コンパイル済みシェーダーの各オブジェクト) を読み込む基本的なステップについて説明します。

## <a name="what-you-need-to-know"></a>理解しておく必要があること


### <a name="technologies"></a>テクノロジ

-   並列パターン ライブラリ (ppltasks.h)

### <a name="prerequisites"></a>前提条件

-   基本的な Windows ランタイムを理解している。
-   非同期タスクを理解している。
-   3-D グラフィックス プログラミングの基本概念を理解している。

また、このサンプルには、リソースの読み込みと管理のためのコード ファイルが 3 つ含まれています。 このトピックでは、これらのファイルに定義されているコード オブジェクトが表示されます。

-   BasicLoader.h/.cpp
-   BasicReaderWriter.h/.cpp
-   DDSTextureLoader.h/.cpp

これらのサンプルのコード一式については、次のリンク先をご覧ください。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">トピック</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="complete-code-for-basicloader.md">BasicLoader のコード一式</a></p></td>
<td align="left"><p>グラフィックス メッシュ オブジェクトを変換してメモリに読み込むクラスとメソッドのコード一式です。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="complete-code-for-basicreaderwriter.md">BasicReaderWriter のコード一式</a></p></td>
<td align="left"><p>バイナリ データ ファイル全般の読み書きを行うクラスとメソッドのコード一式です。 <a href="complete-code-for-basicloader.md">BasicLoader</a> クラスで使われます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="complete-code-for-ddstextureloader.md">DDSTextureLoader のコード一式</a></p></td>
<td align="left"><p>メモリから DDS テクスチャを読み込むクラスとメソッドのコード一式です。</p></td>
</tr>
</tbody>
</table>

 

## <a name="instructions"></a>手順

### <a name="asynchronous-loading"></a>非同期読み込み

非同期読み込みは、並列パターン ライブラリ (PPL) の **task** テンプレートを使って処理します。 **task** にはメソッド呼び出しが含まれています。その後に、非同期呼び出しの完了後にその結果を処理するラムダが続きます。通常の形式は次のとおりです: 

`task<generic return type>(async code to execute).then((parameters for lambda){ lambda code contents });`.

タスクは、**.then()** 構文を使って連結できます。したがって、ある操作の完了後、その操作の結果に依存する別の非同期操作を実行できます。 このように、プレイヤーにはほぼ見えない方法で、個別のスレッドで複雑なアセットの読み込み、変換、管理を行うことができます。

詳しくは、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

それでは、非同期ファイル読み込みメソッド **ReadDataAsync** の宣言と作成の基本構造を見てみましょう。

```cpp
#include <ppltasks.h>

// ...
concurrency::task<Platform::Array<byte>^> ReadDataAsync(
        _In_ Platform::String^ filename);

// ...

using concurrency;

task<Platform::Array<byte>^> BasicReaderWriter::ReadDataAsync(
    _In_ Platform::String^ filename
    )
{
    return task<StorageFile^>(m_location->GetFileAsync(filename)).then([=](StorageFile^ file)
    {
        return FileIO::ReadBufferAsync(file);
    }).then([=](IBuffer^ buffer)
    {
        auto fileData = ref new Platform::Array<byte>(buffer->Length);
        DataReader::FromBuffer(buffer)->ReadBytes(fileData);
        return fileData;
    });
}
```

このコードでは、上で定義された **ReadDataAsync** メソッドを呼び出すと、ファイル システムのバッファーを読み取るタスクが作成されます。 このタスクが完了すると、連結されたタスクがバッファーを受け取り、静的な [**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) 型を使ってバッファーから配列にバイトをストリームします。

```cpp
m_basicReaderWriter = ref new BasicReaderWriter();

// ...
return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ bytecode)
    {
      // Perform some operation with the data when the async load completes.          
    });
```

**ReadDataAsync** の呼び出しはこのとおりです。 これが完了すると、提供されたファイルから読み取ったバイトの配列が渡されます。 **ReadDataAsync** 自体はタスクとして定義されているため、バイト配列が返されたときにラムダを使って特定の操作 (対応可能な DirectX 関数にバイト データを渡すなど) を実行することができます。

非常にシンプルなゲームの場合は、ユーザーがゲームを開始したときに、このようなメソッドを使ってリソースを読み込みます。 これを実行できるのは、[**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) 実装の呼び出しシーケンスにおけるあるポイントからメインのゲーム ループを開始する前です。 ゲームを速く開始できるように、またプレイヤーが初期段階の対話式操作を行う前に読み込みが完了するまで待機することがないように、もう一度、非同期的にリソース読み込みメソッドを呼び出します。

しかし、すべての非同期読み込みが完了するまではゲーム本体を開始したくありません。 そこで、読み込みが完了したら通知するメソッド (特定のフィールドなど) を作成し、読み込みメソッドでラムダを使って、完了時に通知を設定します。 この読み込まれたリソースを使うコンポーネントを開始する前に、変数を確認します。

次に示すのは、BasicLoader.cpp に定義された非同期メソッドを使って、ゲーム起動時にシェーダー、メッシュ、テクスチャを読み込む例です。 すべての読み込みメソッドが完了したときに、ゲーム オブジェクト **m\_loadingComplete** に特定のフィールドが設定されている点に注目してください。

```cpp
void ResourceLoading::CreateDeviceResources()
{
    // DirectXBase is a common sample class that implements a basic view provider. 
    
    DirectXBase::CreateDeviceResources(); 

    // ...

    // This flag will keep track of whether or not all application
    // resources have been loaded.  Until all resources are loaded,
    // only the sample overlay will be drawn on the screen.
    m_loadingComplete = false;

    // Create a BasicLoader, and use it to asynchronously load all
    // application resources.  When an output value becomes non-null,
    // this indicates that the asynchronous operation has completed.
    BasicLoader^ loader = ref new BasicLoader(m_d3dDevice.Get());

    auto loadVertexShaderTask = loader->LoadShaderAsync(
        "SimpleVertexShader.cso",
        nullptr,
        0,
        &m_vertexShader,
        &m_inputLayout
        );

    auto loadPixelShaderTask = loader->LoadShaderAsync(
        "SimplePixelShader.cso",
        &m_pixelShader
        );

    auto loadTextureTask = loader->LoadTextureAsync(
        "reftexture.dds",
        nullptr,
        &m_textureSRV
        );

    auto loadMeshTask = loader->LoadMeshAsync(
        "refmesh.vbo",
        &m_vertexBuffer,
        &m_indexBuffer,
        nullptr,
        &m_indexCount
        );

    // The && operator can be used to create a single task that represents
    // a group of multiple tasks. The new task's completed handler will only
    // be called once all associated tasks have completed. In this case, the
    // new task represents a task to load various assets from the package.
    (loadVertexShaderTask && loadPixelShaderTask && loadTextureTask && loadMeshTask).then([=]()
    {
        m_loadingComplete = true;
    });

    // Create constant buffers and other graphics device-specific resources here.
}
```

すべてのタスクが完了したときにのみ、読み込み完了フラグを設定するラムダがトリガーされるように、&& 演算子を使ってタスクが統合されている点に注意してください。 複数のフラグが存在する場合は、競合状態になる可能性があります。 たとえば、ラムダが 2 つのフラグを順次同じ値に設定するとします。2 つ目のフラグが設定される前に別のスレッドがフラグを確認した場合、別のスレッドは 1 つ目のフラグの設定しか認識しません。

これまでは、リソース ファイルを非同期的に読み込む方法について確認してきました。 同期ファイルの読み込みはもっと簡単です。この読み込みの例については、「[BasicReaderWriter のコード一式](complete-code-for-basicreaderwriter.md)」と「[BasicLoader のコード一式](complete-code-for-basicloader.md)」をご覧ください。

言うまでもなく、リソースやアセットの種類が異なれば、ほとんどの場合、グラフィックス パイプラインで使う前に追加の処理または変換が必要になります。 次に、3 種類のリソース (メッシュ、テクスチャ、シェーダー) について見てみましょう。

### <a name="loading-meshes"></a>メッシュの読み込み

メッシュは頂点データです。ゲーム内のコードによって手続き的に生成されるか、他のアプリ (3DStudio MAX や Alias WaveFront など) またはツールからファイルにエクスポートされます。 これらのメッシュは、立方体や球体のようなシンプルなプリミティブから自動車、家、人物に及ぶ、ゲーム内のモデルを表します。 形式によっては、色やアニメーションのデータが含まれることも少なくありません。 ここでは、頂点データのみが含まれるメッシュについて説明します。

メッシュを正しく読み込むには、メッシュのファイルのデータ形式を把握しておく必要があります。 上記のシンプルな **BasicReaderWriter** 型は、データをバイト ストリームとして読み取るだけです。バイト データがメッシュを表していると認識することはできません。言うまでもなく、他のアプリケーションによってエクスポートされた特定のメッシュ形式も認識されません。 メッシュ データをメモリに読み込む際に変換を実行する必要があります。

(常に、できるだけ内部表現に近い形式でアセット データをパッケージ化するようにする必要があります。 こうすることでリソースの使用率が下がり、時間が短縮されます。)

メッシュのファイルからバイト データを取得してみましょう。 この例では、ファイルの形式がサンプル固有の形式 (名前の最後が .vbo) であるとします (繰り返しますが、この形式は OpenGL の VBO 形式とは異なります)。頂点自体はそれぞれ **BasicVertex** 型 (obj2vbo コンバーター ツールのコードで定義されている構造体) にマップされます。 .vbo ファイルの頂点データのレイアウトは次のようになります。

-   データ ストリームの最初の 32 ビット (4 バイト) には、uint32 値として表されたメッシュの頂点の数 (numVertices) が含まれています。
-   データ ストリームの次の 32 ビット (4 バイト) には、uint32 値として表されたメッシュのインデックスの数 (numIndices) が含まれています。
-   それ以降の (numVertices \* sizeof(**BasicVertex**)) ビットには頂点データが含まれています。
-   データの最後の (numIndices \* 16) ビットには、一連の uint16 値として表されたインデックス データが含まれています。

要するに、読み込んだメッシュ データのビット レベルのレイアウトを把握するということです。 また、エンディアンが一致するようにします。 Windows8 プラットフォームはすべてリトル エンディアンです。

この例では、**LoadMeshAsync** メソッドから CreateMesh メソッドを呼び出して、ビット レベルの解釈を行っています。

```cpp
task<void> BasicLoader::LoadMeshAsync(
    _In_ Platform::String^ filename,
    _Out_ ID3D11Buffer** vertexBuffer,
    _Out_ ID3D11Buffer** indexBuffer,
    _Out_opt_ uint32* vertexCount,
    _Out_opt_ uint32* indexCount
    )
{
    return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ meshData)
    {
        CreateMesh(
            meshData->Data,
            vertexBuffer,
            indexBuffer,
            vertexCount,
            indexCount,
            filename
            );
    });
}
```

**CreateMesh** は、ファイルから読み込まれたバイト データを解釈します。そして、頂点リストとインデックス リストをそれぞれ [**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) に渡し、D3D11\_BIND\_VERTEX\_BUFFER または D3D11\_BIND\_INDEX\_BUFFER を指定することによって、メッシュの頂点バッファーとインデックス バッファーを作成します。 **BasicLoader** で使われるコードは次のとおりです。

```cpp
void BasicLoader::CreateMesh(
    _In_ byte* meshData,
    _Out_ ID3D11Buffer** vertexBuffer,
    _Out_ ID3D11Buffer** indexBuffer,
    _Out_opt_ uint32* vertexCount,
    _Out_opt_ uint32* indexCount,
    _In_opt_ Platform::String^ debugName
    )
{
    // The first 4 bytes of the BasicMesh format define the number of vertices in the mesh.
    uint32 numVertices = *reinterpret_cast<uint32*>(meshData);

    // The following 4 bytes define the number of indices in the mesh.
    uint32 numIndices = *reinterpret_cast<uint32*>(meshData + sizeof(uint32));

    // The next segment of the BasicMesh format contains the vertices of the mesh.
    BasicVertex* vertices = reinterpret_cast<BasicVertex*>(meshData + sizeof(uint32) * 2);

    // The last segment of the BasicMesh format contains the indices of the mesh.
    uint16* indices = reinterpret_cast<uint16*>(meshData + sizeof(uint32) * 2 + sizeof(BasicVertex) * numVertices);

    // Create the vertex and index buffers with the mesh data.

    D3D11_SUBRESOURCE_DATA vertexBufferData = {0};
    vertexBufferData.pSysMem = vertices;
    vertexBufferData.SysMemPitch = 0;
    vertexBufferData.SysMemSlicePitch = 0;
    CD3D11_BUFFER_DESC vertexBufferDesc(numVertices * sizeof(BasicVertex), D3D11_BIND_VERTEX_BUFFER);

    m_d3dDevice->CreateBuffer(
            &vertexBufferDesc,
            &vertexBufferData,
            vertexBuffer
            );
    
    D3D11_SUBRESOURCE_DATA indexBufferData = {0};
    indexBufferData.pSysMem = indices;
    indexBufferData.SysMemPitch = 0;
    indexBufferData.SysMemSlicePitch = 0;
    CD3D11_BUFFER_DESC indexBufferDesc(numIndices * sizeof(uint16), D3D11_BIND_INDEX_BUFFER);
    
    m_d3dDevice->CreateBuffer(
            &indexBufferDesc,
            &indexBufferData,
            indexBuffer
            );
  
    if (vertexCount != nullptr)
    {
        *vertexCount = numVertices;
    }
    if (indexCount != nullptr)
    {
        *indexCount = numIndices;
    }
}
```

通常は、ゲームで使うメッシュごとに、頂点バッファーとインデックス バッファーのペアを作成します。 メッシュをいつ、どこに読み込むかは任意です。 メッシュが多数存在する場合は、ゲームの特定のポイント (定義済みの特定の読み込み状態のときなど) でディスクから一部のメッシュを読み込むことをお勧めします。 地形データのような大きなメッシュの場合は、キャッシュから頂点をストリームすることもできますが、手順はより複雑になります (このトピックでは扱いません)。

繰り返しになりますが、頂点データの形式を把握する必要があります。 モデルの作成に使われるツールで頂点データを表す方法は数多くあります。 また、三角形リストや三角形ストリップなど、Direct3D に対して頂点データの入力レイアウトを示す方法もさまざまです。 頂点データについて詳しくは、「[Direct3D 11 のバッファーについて](https://msdn.microsoft.com/library/windows/desktop/ff476898)」と「[プリミティブ](https://msdn.microsoft.com/library/windows/desktop/bb147291)」をご覧ください。

次に、テクスチャの読み込みについて見てみましょう。

### <a name="loading-textures"></a>テクスチャの読み込み

ゲームで最も一般的なアセット、そしてディスク上とメモリ内のファイルの大部分を構成するアセットはテクスチャです。 メッシュと同様、テクスチャにもさまざまな形式があるため、テクスチャの読み込み時に Direct3D で使うことができる形式に変換します。 また、テクスチャにはさまざまなタイプがあり、種々の効果を作成するのに使われます。 テクスチャの MIP レベルを使えば、距離オブジェクトの外観とパフォーマンスを向上させることができます。ダート マップとライト マップは、基本テクスチャの上に効果や詳細を重ねるのに使われます。標準マップは、ピクセルあたりの照明の計算で使われます。 最新のゲームでは、標準シーンにそれぞれ異なる何千ものテクスチャが存在する可能性があるため、そのすべてをコードで効果的に管理する必要があります。

また、メッシュと同様、メモリ使用を効率化するのに使われる特殊な形式も数多く存在します。 テクスチャは、GPU (およびシステム) のメモリの大部分をすぐに消費するため、ほとんどの場合何らかの方法で圧縮されています。 ゲームのテクスチャで圧縮を使う必要はありません。認識できる形式のデータを Direct3D シェーダーに提供する限り、必要な圧縮アルゴリズムと圧縮解除アルゴリズムを使うことができます ([**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) ビットマップと同様)。

Direct3D は、DXT テクスチャ圧縮アルゴリズムをサポートしています。ただし、プレイヤーのグラフィックス ハードウェアではサポートされない DXT 形式が存在する可能性もあります。 DDS ファイルには DXT テクスチャ (および他のテクスチャ圧縮形式) が含まれています。DDS ファイルの名前は .dds で終わります。

DDS ファイルは、次の情報が含まれるバイナリ ファイルです。

-   4 文字コード値 "DDS " (0x20534444) が含まれる DWORD (マジック ナンバー)。

-   ファイル内のデータの説明。

    データは、[**DDS\_HEADER**](https://msdn.microsoft.com/library/windows/desktop/bb943982) を使ってヘッダーの説明と一緒に説明されます。ピクセル形式は、[**DDS\_PIXELFORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb943984) を使って定義されます。 **DDS\_HEADER** 構造体と **DDS\_PIXELFORMAT** 構造体は、推奨されなくなった DirectDraw 7 の DDSURFACEDESC2 構造体、DDSCAPS2 構造体、および DDPIXELFORMAT 構造体の代わりに使います。 **DDS\_HEADER** は、DDSURFACEDESC2 と DDSCAPS2 の機能をバイナリで実現します。 **DDS\_PIXELFORMAT** は、DDPIXELFORMAT の機能をバイナリで実現します。

    ```cpp
    DWORD               dwMagic;
    DDS_HEADER          header;
    ```

    [**DDS\_PIXELFORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb943984) の **dwFlags** の値を DDPF\_FOURCC に設定し、**dwFourCC** を "DX10" に設定していると、[**DDS\_HEADER\_DXT10**](https://msdn.microsoft.com/library/windows/desktop/bb943983) 構造体が追加で生成され、浮動小数点形式や sRGB 形式などの RGB ピクセル形式では表現できない DXGI 形式やテクスチャ配列がこの構造体に格納されます。この **DDS\_HEADER\_DXT10** 構造体が存在する場合、データ記述の全体は次のようになります。

    ```cpp
    DWORD               dwMagic;
    DDS_HEADER          header;
    DDS_HEADER_DXT10    header10;
    ```

-   メイン サーフェス データを含むバイトの配列へのポインター。
    ```cpp
    BYTE bdata[]
    ```

-   残りのサーフェス (ミップマップ レベル、キューブ マップの面、ボリューム テクスチャの深度など) を含むバイトの配列へのポインター。 [テクスチャ](https://msdn.microsoft.com/library/windows/desktop/bb205578)、[キューブ マップ](https://msdn.microsoft.com/library/windows/desktop/bb205577)、または[ボリューム テクスチャ](https://msdn.microsoft.com/library/windows/desktop/bb205579)の DDS ファイル レイアウトについて詳しくは、ここに挙げたリンク先をご覧ください。

    ```cpp
    BYTE bdata2[]
    ```

DDS 形式へのエクスポートは、多くのツールで実行可能です。 テクスチャを DDS 形式にエクスポートできるツールがない場合は、作成することを検討してください。 DDS 形式について、また DDS 形式をコードで使う方法について詳しくは、「[DDS 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/bb943991)」をご覧ください。 この例では DDS を使います。

他の種類のリソースと同様に、バイトのストリームとしてファイルからデータを読み取ります。 読み込みタスクが完了すると、ラムダ呼び出しがコード (**CreateTexture** メソッド) を実行し、バイトのストリームを処理して Direct3D で使用できる形式にします。

```cpp
task<void> BasicLoader::LoadTextureAsync(
    _In_ Platform::String^ filename,
    _Out_opt_ ID3D11Texture2D** texture,
    _Out_opt_ ID3D11ShaderResourceView** textureView
    )
{
    return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ textureData)
    {
        CreateTexture(
            GetExtension(filename) == "dds",
            textureData->Data,
            textureData->Length,
            texture,
            textureView,
            filename
            );
    });
}
```

上記のスニペットでは、ファイル名に拡張子の "dds" が含まれているかどうかラムダでチェックしています。 この拡張子が含まれていれば、DDS テクスチャであると判断できます。 含まれていない場合は、Windows Imaging Component (WIC) API を使って形式を検出し、データをビットマップとしてデコードします。 いずれにしても、結果は [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) ビットマップ (またはエラー) になります。

```cpp
void BasicLoader::CreateTexture(
    _In_ bool decodeAsDDS,
    _In_reads_bytes_(dataSize) byte* data,
    _In_ uint32 dataSize,
    _Out_opt_ ID3D11Texture2D** texture,
    _Out_opt_ ID3D11ShaderResourceView** textureView,
    _In_opt_ Platform::String^ debugName
    )
{
    ComPtr<ID3D11ShaderResourceView> shaderResourceView;
    ComPtr<ID3D11Texture2D> texture2D;

    if (decodeAsDDS)
    {
        ComPtr<ID3D11Resource> resource;

        if (textureView == nullptr)
        {
            CreateDDSTextureFromMemory(
                m_d3dDevice.Get(),
                data,
                dataSize,
                &resource,
                nullptr
                );
        }
        else
        {
            CreateDDSTextureFromMemory(
                m_d3dDevice.Get(),
                data,
                dataSize,
                &resource,
                &shaderResourceView
                );
        }

        resource.As(&texture2D);
    }
    else
    {
        if (m_wicFactory.Get() == nullptr)
        {
            // A WIC factory object is required in order to load texture
            // assets stored in non-DDS formats.  If BasicLoader was not
            // initialized with one, create one as needed.
            CoCreateInstance(
                    CLSID_WICImagingFactory,
                    nullptr,
                    CLSCTX_INPROC_SERVER,
                    IID_PPV_ARGS(&m_wicFactory));
        }

        ComPtr<IWICStream> stream;
        m_wicFactory->CreateStream(&stream);

        stream->InitializeFromMemory(
                data,
                dataSize);

        ComPtr<IWICBitmapDecoder> bitmapDecoder;
        m_wicFactory->CreateDecoderFromStream(
                stream.Get(),
                nullptr,
                WICDecodeMetadataCacheOnDemand,
                &bitmapDecoder);

        ComPtr<IWICBitmapFrameDecode> bitmapFrame;
        bitmapDecoder->GetFrame(0, &bitmapFrame);

        ComPtr<IWICFormatConverter> formatConverter;
        m_wicFactory->CreateFormatConverter(&formatConverter);

        formatConverter->Initialize(
                bitmapFrame.Get(),
                GUID_WICPixelFormat32bppPBGRA,
                WICBitmapDitherTypeNone,
                nullptr,
                0.0,
                WICBitmapPaletteTypeCustom);

        uint32 width;
        uint32 height;
        bitmapFrame->GetSize(&width, &height);

        std::unique_ptr<byte[]> bitmapPixels(new byte[width * height * 4]);
        formatConverter->CopyPixels(
                nullptr,
                width * 4,
                width * height * 4,
                bitmapPixels.get());

        D3D11_SUBRESOURCE_DATA initialData;
        ZeroMemory(&initialData, sizeof(initialData));
        initialData.pSysMem = bitmapPixels.get();
        initialData.SysMemPitch = width * 4;
        initialData.SysMemSlicePitch = 0;

        CD3D11_TEXTURE2D_DESC textureDesc(
            DXGI_FORMAT_B8G8R8A8_UNORM,
            width,
            height,
            1,
            1
            );

        m_d3dDevice->CreateTexture2D(
                &textureDesc,
                &initialData,
                &texture2D);

        if (textureView != nullptr)
        {
            CD3D11_SHADER_RESOURCE_VIEW_DESC shaderResourceViewDesc(
                texture2D.Get(),
                D3D11_SRV_DIMENSION_TEXTURE2D
                );

            m_d3dDevice->CreateShaderResourceView(
                    texture2D.Get(),
                    &shaderResourceViewDesc,
                    &shaderResourceView);
        }
    }


    if (texture != nullptr)
    {
        *texture = texture2D.Detach();
    }
    if (textureView != nullptr)
    {
        *textureView = shaderResourceView.Detach();
    }
}
```

このコードが完了すると、イメージ ファイルから読み込まれた [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) がメモリ内に格納されます。 メッシュと同様に、ゲームにも特定のシーンにもおそらく多数のテクスチャが含まれています。 ゲームまたはレベルの開始時にすべてのテクスチャを読み込むのではなく、シーンごとまたはレベルごとに何度もアクセスされるテクスチャについては、そのためのキャッシュを作成することを検討します。

(上記のサンプルで呼び出された **CreateDDSTextureFromMemory** メソッドの全コードについては、「[DDSTextureLoader のコード一式](complete-code-for-ddstextureloader.md)」をご覧ください。)

また、個々のテクスチャまたはテクスチャの "スキン" は、特定のメッシュ多角形やサーフェスにマップされている場合があります。 このマッピング データは通常、アーティストやデザイナーがモデルとテクスチャを作成するのに使ったツールでエクスポートされます。 フラグメント シェーディングの実行時には、この情報を使って適切なテクスチャを対応サーフェスにマップします。したがって、エクスポートされたデータを読み込む際には、この情報も必ずキャプチャするようにします。

### <a name="loading-shaders"></a>シェーダーの読み込み

シェーダーは、メモリに読み込まれてグラフィックス パイプラインの特定の段階で呼び出されるコンパイル済み上位レベル シェーダー言語 (HLSL) ファイルです。 最も一般的で重要なシェーダーは、頂点シェーダーとピクセル シェーダーです。頂点シェーダーではメッシュの個々の頂点が処理され、ピクセル シェーダーではシーンのビューポートのピクセルが処理されます。 HLSL コードは、ジオメトリの変換、照明効果とテクスチャの適用、レンダリングされたシーンの後処理を行う場合に実行します。

Direct3D ゲームには、それぞれが別々の CSO (コンパイル済みシェーダー オブジェクト、.cso) ファイルにコンパイルされた、さまざまなシェーダーが存在している可能性があります。 通常、動的に読み込む必要があるシェーダーはそれほど多くありません。ほとんどの場合、ゲームの開始時またはレベルごとに、シェーダーを簡単に読み込むことができます (雨の効果のシェーダーなど)。

**BasicLoader** クラスのコードは、頂点、ジオメトリ、ピクセル、ハルなどのさまざまなシェーダーに多数のオーバーロードを提供します。 次のコードでは、例としてピクセル シェーダーを取り上げています (すべてのコードについては、「[BasicLoader のコード一式](complete-code-for-basicloader.md)」をご覧ください)。

```cpp
concurrency::task<void> LoadShaderAsync(
    _In_ Platform::String^ filename,
    _Out_ ID3D11PixelShader** shader
    );

// ...

task<void> BasicLoader::LoadShaderAsync(
    _In_ Platform::String^ filename,
    _Out_ ID3D11PixelShader** shader
    )
{
    return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ bytecode)
    {
        
       m_d3dDevice->CreatePixelShader(
                bytecode->Data,
                bytecode->Length,
                nullptr,
                shader);
    });
}

```

この例では、**BasicReaderWriter** インスタンス (**m\_basicReaderWriter**) を使って、指定されたコンパイル済みシェーダー オブジェクト (.cso) ファイルをバイト ストリームとして読み取っています。 このタスクが完了すると、ラムダは、ファイルから読み込まれたバイト データを使って [**ID3D11Device::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) を呼び出します。 また、コールバックによって、読み込みの成功を示すフラグを設定する必要があります。コードでは、シェーダーの実行前にこのフラグを確認する必要があります。

頂点シェーダーはもう少し複雑になります。 頂点シェーダーの場合は、頂点データを定義する別個の入力レイアウトも読み込みます。 次のコードを使うことで、頂点シェーダーと一緒にカスタムの頂点入力レイアウトを非同期的に読み込むことができます。 メッシュから読み込まれた頂点情報は、この入力レイアウトによって適切に表せるようになります。

頂点シェーダーを読み込む前に入力レイアウトを作成しましょう。

```cpp
void BasicLoader::CreateInputLayout(
    _In_reads_bytes_(bytecodeSize) byte* bytecode,
    _In_ uint32 bytecodeSize,
    _In_reads_opt_(layoutDescNumElements) D3D11_INPUT_ELEMENT_DESC* layoutDesc,
    _In_ uint32 layoutDescNumElements,
    _Out_ ID3D11InputLayout** layout
    )
{
    if (layoutDesc == nullptr)
    {
        // If no input layout is specified, use the BasicVertex layout.
        const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
        {
            { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,  D3D11_INPUT_PER_VERTEX_DATA, 0 },
            { "NORMAL",   0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
            { "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT,    0, 24, D3D11_INPUT_PER_VERTEX_DATA, 0 },
        };

        m_d3dDevice->CreateInputLayout(
                basicVertexLayoutDesc,
                ARRAYSIZE(basicVertexLayoutDesc),
                bytecode,
                bytecodeSize,
                layout);
    }
    else
    {
        m_d3dDevice->CreateInputLayout(
                layoutDesc,
                layoutDescNumElements,
                bytecode,
                bytecodeSize,
                layout);
    }
}
```

このレイアウトでは、各頂点に、頂点シェーダーで処理される次のデータが含まれます。

-   モデルの座標空間における 3D の座標位置 (x, y, z)。3 つの 32 ビット浮動小数点値で表されます。
-   頂点の標準ベクター。これも 3 つの 32 ビット浮動小数点値で表されます。
-   変換された 2D テクスチャの座標値 (u, v)。2 つの 32 ビット浮動小数点値で表されます。

頂点ごとのこれらの入力要素は [HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)と呼ばれます。これらの入力要素は、コンパイル済みシェーダー オブジェクトとのデータの受け渡しに使われる定義済みレジスタのセットです。 読み込んだメッシュの頂点ごとに 1 回、パイプラインが頂点シェーダーを実行します。 このセマンティクスは、実行時の頂点シェーダーへの入力 (および頂点シェーダーからの出力) を定義し、シェーダーの HLSL コードでの頂点ごとの計算にこのデータを提供します。

次に、頂点シェーダー オブジェクトを読み込みます。

```cpp
concurrency::task<void> LoadShaderAsync(
        _In_ Platform::String^ filename,
        _In_reads_opt_(layoutDescNumElements) D3D11_INPUT_ELEMENT_DESC layoutDesc[],
        _In_ uint32 layoutDescNumElements,
        _Out_ ID3D11VertexShader** shader,
        _Out_opt_ ID3D11InputLayout** layout
        );

// ...

task<void> BasicLoader::LoadShaderAsync(
    _In_ Platform::String^ filename,
    _In_reads_opt_(layoutDescNumElements) D3D11_INPUT_ELEMENT_DESC layoutDesc[],
    _In_ uint32 layoutDescNumElements,
    _Out_ ID3D11VertexShader** shader,
    _Out_opt_ ID3D11InputLayout** layout
    )
{
    // This method assumes that the lifetime of input arguments may be shorter
    // than the duration of this task.  In order to ensure accurate results, a
    // copy of all arguments passed by pointer must be made.  The method then
    // ensures that the lifetime of the copied data exceeds that of the task.

    // Create copies of the layoutDesc array as well as the SemanticName strings,
    // both of which are pointers to data whose lifetimes may be shorter than that
    // of this method's task.
    shared_ptr<vector<D3D11_INPUT_ELEMENT_DESC>> layoutDescCopy;
    shared_ptr<vector<string>> layoutDescSemanticNamesCopy;
    if (layoutDesc != nullptr)
    {
        layoutDescCopy.reset(
            new vector<D3D11_INPUT_ELEMENT_DESC>(
                layoutDesc,
                layoutDesc + layoutDescNumElements
                )
            );

        layoutDescSemanticNamesCopy.reset(
            new vector<string>(layoutDescNumElements)
            );

        for (uint32 i = 0; i < layoutDescNumElements; i++)
        {
            layoutDescSemanticNamesCopy->at(i).assign(layoutDesc[i].SemanticName);
        }
    }

    return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ bytecode)
    {
       m_d3dDevice->CreateVertexShader(
                bytecode->Data,
                bytecode->Length,
                nullptr,
                shader);

        if (layout != nullptr)
        {
            if (layoutDesc != nullptr)
            {
                // Reassign the SemanticName elements of the layoutDesc array copy to point
                // to the corresponding copied strings. Performing the assignment inside the
                // lambda body ensures that the lambda will take a reference to the shared_ptr
                // that holds the data.  This will guarantee that the data is still valid when
                // CreateInputLayout is called.
                for (uint32 i = 0; i < layoutDescNumElements; i++)
                {
                    layoutDescCopy->at(i).SemanticName = layoutDescSemanticNamesCopy->at(i).c_str();
                }
            }

            CreateInputLayout(
                bytecode->Data,
                bytecode->Length,
                layoutDesc == nullptr ? nullptr : layoutDescCopy->data(),
                layoutDescNumElements,
                layout);   
        }
    });
}

```

このコードでは、頂点シェーダーの CSO ファイルのバイト データを読み取ってから、[**ID3D11Device::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) を呼び出して頂点シェーダーを作成しています。 その後で、同じラムダでシェーダーの入力レイアウトを作成しています。

ハル シェーダーやジオメトリ シェーダーなどの他の種類のシェーダーでは、特別な構成が必要になる場合もあります。 さまざまなシェーダー読み込みメソッドのコード一式については、「[BasicLoader のコード一式](complete-code-for-basicloader.md)」と [Direct3D リソース読み込みのサンプル]( http://go.microsoft.com/fwlink/p/?LinkID=265132)をご覧ください。

## <a name="remarks"></a>注釈

これで、メッシュ、テクスチャ、コンパイル済みシェーダーなどの一般的なゲームのリソースとアセットを非同期的に読み込むメソッドを理解し、作成と変更をできるようになりました。

## <a name="related-topics"></a>関連トピック

* [Direct3D リソース読み込みのサンプルに関するページ]( http://go.microsoft.com/fwlink/p/?LinkID=265132)
* [BasicLoader のコード一式](complete-code-for-basicloader.md)
* [BasicReaderWriter のコード一式](complete-code-for-basicreaderwriter.md)
* [DDSTextureLoader のコード一式](complete-code-for-ddstextureloader.md)

 

 




