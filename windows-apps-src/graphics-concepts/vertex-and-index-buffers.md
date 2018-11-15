---
title: 頂点バッファーとインデックス バッファー
description: 頂点バッファーは、頂点データを格納するメモリ バッファーです。頂点バッファー内の頂点は、変換、照明の適用、クリッピングを実行するために処理されます。
ms.assetid: 8A39CD23-85FB-4424-9AC3-37919704CD68
keywords:
- 頂点バッファーとインデックス バッファー
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 2327036eb53ac34c406aef53163be642468fbddc
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6669449"
---
# <a name="vertex-and-index-buffers"></a><span data-ttu-id="f943f-104">頂点バッファーとインデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="f943f-104">Vertex and index buffers</span></span>


<span data-ttu-id="f943f-105">"頂点バッファー"\*\* は、頂点データを格納するメモリ バッファーです。頂点バッファー内の頂点は、変換、照明の適用、クリッピングを実行するために処理されます。</span><span class="sxs-lookup"><span data-stu-id="f943f-105">*Vertex buffers* are memory buffers that contain vertex data; vertices in a vertex buffer are processed to perform transformation, lighting, and clipping.</span></span> <span data-ttu-id="f943f-106">"インデックス バッファー"\*\* は、インデックス データを格納するメモリ バッファーです。インデックス データは頂点バッファーへの整数オフセットで、プリミティブのレンダリングに使われます。</span><span class="sxs-lookup"><span data-stu-id="f943f-106">*Index buffers* are memory buffers that contain index data, which are integer offsets into vertex buffers, used to render primitives.</span></span>

<span data-ttu-id="f943f-107">頂点バッファーには、レンダリング可能な任意の種類の頂点を含めることができます。変換済みでも未変換でも、照明が適用済みでも未適用でもかまいません。</span><span class="sxs-lookup"><span data-stu-id="f943f-107">Vertex buffers can contain any vertex type - transformed or untransformed, lit or unlit - that can be rendered.</span></span> <span data-ttu-id="f943f-108">頂点バッファー内の頂点を処理して、変換、照明の適用、クリッピング フラグの生成などの操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="f943f-108">You can process the vertices in a vertex buffer to perform operations such as transformation, lighting, or generating clipping flags.</span></span> <span data-ttu-id="f943f-109">変換は常に実行されます。</span><span class="sxs-lookup"><span data-stu-id="f943f-109">Transformation is always performed.</span></span>

<span data-ttu-id="f943f-110">頂点バッファーは柔軟なため、変換されたジオメトリを再利用するための最適なステージング ポイントとなります。</span><span class="sxs-lookup"><span data-stu-id="f943f-110">The flexibility of vertex buffers make them ideal staging points for reusing transformed geometry.</span></span> <span data-ttu-id="f943f-111">1 つの頂点バッファーを作成し、その中の頂点に対して変換、照明、クリッピングを適用したら、そのモデルを必要に応じて何度でも、再変換なしでシーンにレンダリングできます。途中でレンダリング状態が変更されたとしても、再変換を行う必要はありません。</span><span class="sxs-lookup"><span data-stu-id="f943f-111">You could create a single vertex buffer, transform, light, and clip the vertices in it, and render the model in the scene as many times as needed without re-transforming it, even with interleaved render state changes.</span></span> <span data-ttu-id="f943f-112">これは、複数のテクスチャを使うモデルをレンダリングする場合に便利です。ジオメトリを 1 回だけ変換すれば、必要なテクスチャの変更を加えながら、変換したジオメトリの一部を必要に応じてレンダリングすることができます。</span><span class="sxs-lookup"><span data-stu-id="f943f-112">This is useful when rendering models that use multiple textures: the geometry is transformed only once, and then portions of it can be rendered as needed, interleaved with the required texture changes.</span></span> <span data-ttu-id="f943f-113">頂点の処理後に行われたレンダリング状態の変更は、次に頂点が処理されるときに反映されます。</span><span class="sxs-lookup"><span data-stu-id="f943f-113">Render state changes made after vertices are processed take effect the next time the vertices are processed.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="f943f-114"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="f943f-114"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="f943f-115">トピック</span><span class="sxs-lookup"><span data-stu-id="f943f-115">Topic</span></span></th>
<th align="left"><span data-ttu-id="f943f-116">説明</span><span class="sxs-lookup"><span data-stu-id="f943f-116">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="introduction-to-buffers.md"><span data-ttu-id="f943f-117">バッファーの概要</span><span class="sxs-lookup"><span data-stu-id="f943f-117">Introduction to buffers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f943f-118">バッファー リソースは完全に型指定されたデータのコレクションであり、複数の要素にグループ化されます。</span><span class="sxs-lookup"><span data-stu-id="f943f-118">A buffer resource is a collection of fully typed data, grouped into elements.</span></span> <span data-ttu-id="f943f-119">バッファーには、"頂点バッファー"<em></em> 内のテクスチャ座標、"インデックス バッファー"<em></em> 内のインデックス、"定数バッファー"<em></em> 内のシェーダー定数データ、位置ベクトル、法線ベクトル、デバイスの状態などのデータが格納されます。</span><span class="sxs-lookup"><span data-stu-id="f943f-119">Buffers store data, such as texture coordinates in a <em>vertex buffer</em>, indexes in an <em>index buffer</em>, shader constants data in a <em>constant buffer</em>, position vectors, normal vectors, or device state.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="index-buffers.md"><span data-ttu-id="f943f-120">インデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="f943f-120">Index buffers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f943f-121"><em>インデックス バッファー</em>は、インデックス データを格納するメモリ バッファーです。インデックス データは頂点バッファーへの整数オフセットで、プリミティブのレンダリングに使われます。</span><span class="sxs-lookup"><span data-stu-id="f943f-121"><em>Index buffers</em> are memory buffers that contain index data, which are integer offsets into vertex buffers, used to render primitives.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="f943f-122"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="f943f-122"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="f943f-123">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="f943f-123">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




