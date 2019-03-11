---
title: 頂点バッファーとインデックス バッファー
description: 頂点バッファーは、頂点データを格納するメモリ バッファーです。頂点バッファー内の頂点は、変換、照明の適用、クリッピングを実行するために処理されます。
ms.assetid: 8A39CD23-85FB-4424-9AC3-37919704CD68
keywords:
- 頂点バッファーとインデックス バッファー
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: d2ea6ce4060957ade5dd1007389be51176440f04
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593577"
---
# <a name="vertex-and-index-buffers"></a><span data-ttu-id="1d783-104">頂点バッファーとインデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="1d783-104">Vertex and index buffers</span></span>


<span data-ttu-id="1d783-105">"*頂点バッファー*" は、頂点データを格納するメモリ バッファーです。頂点バッファー内の頂点は、変換、照明の適用、クリッピングを実行するために処理されます。</span><span class="sxs-lookup"><span data-stu-id="1d783-105">*Vertex buffers* are memory buffers that contain vertex data; vertices in a vertex buffer are processed to perform transformation, lighting, and clipping.</span></span> <span data-ttu-id="1d783-106">*インデックス バッファー*は、インデックス データを含むメモリ バッファーであり、プリミティブのレンダリングに使用される、頂点バッファーへの整数オフセットです。</span><span class="sxs-lookup"><span data-stu-id="1d783-106">*Index buffers* are memory buffers that contain index data, which are integer offsets into vertex buffers, used to render primitives.</span></span>

<span data-ttu-id="1d783-107">頂点バッファーには、レンダリング可能な任意の種類の頂点を含めることができます。変換済みでも未変換でも、照明が適用済みでも未適用でもかまいません。</span><span class="sxs-lookup"><span data-stu-id="1d783-107">Vertex buffers can contain any vertex type - transformed or untransformed, lit or unlit - that can be rendered.</span></span> <span data-ttu-id="1d783-108">頂点バッファー内の頂点を処理して、変換、照明の適用、クリッピング フラグの生成などの操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="1d783-108">You can process the vertices in a vertex buffer to perform operations such as transformation, lighting, or generating clipping flags.</span></span> <span data-ttu-id="1d783-109">変換は常に実行されます。</span><span class="sxs-lookup"><span data-stu-id="1d783-109">Transformation is always performed.</span></span>

<span data-ttu-id="1d783-110">頂点バッファーは柔軟なため、変換されたジオメトリを再利用するための最適なステージング ポイントとなります。</span><span class="sxs-lookup"><span data-stu-id="1d783-110">The flexibility of vertex buffers make them ideal staging points for reusing transformed geometry.</span></span> <span data-ttu-id="1d783-111">1 つの頂点バッファーを作成し、その中の頂点に対して変換、照明、クリッピングを適用したら、そのモデルを必要に応じて何度でも、再変換なしでシーンにレンダリングできます。途中でレンダリング状態が変更されたとしても、再変換を行う必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1d783-111">You could create a single vertex buffer, transform, light, and clip the vertices in it, and render the model in the scene as many times as needed without re-transforming it, even with interleaved render state changes.</span></span> <span data-ttu-id="1d783-112">これは、複数のテクスチャを使うモデルをレンダリングする場合に便利です。ジオメトリを 1 回だけ変換すれば、必要なテクスチャの変更を加えながら、変換したジオメトリの一部を必要に応じてレンダリングすることができます。</span><span class="sxs-lookup"><span data-stu-id="1d783-112">This is useful when rendering models that use multiple textures: the geometry is transformed only once, and then portions of it can be rendered as needed, interleaved with the required texture changes.</span></span> <span data-ttu-id="1d783-113">頂点の処理後に行われたレンダリング状態の変更は、次に頂点が処理されるときに反映されます。</span><span class="sxs-lookup"><span data-stu-id="1d783-113">Render state changes made after vertices are processed take effect the next time the vertices are processed.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="1d783-114"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="1d783-114"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="1d783-115">トピック</span><span class="sxs-lookup"><span data-stu-id="1d783-115">Topic</span></span></th>
<th align="left"><span data-ttu-id="1d783-116">説明</span><span class="sxs-lookup"><span data-stu-id="1d783-116">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="1d783-117"><a href="introduction-to-buffers.md">バッファーの概要</a></span><span class="sxs-lookup"><span data-stu-id="1d783-117"><a href="introduction-to-buffers.md">Introduction to buffers</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="1d783-118">バッファー リソースは完全に型指定されたデータのコレクションであり、要素にグループ化されます。</span><span class="sxs-lookup"><span data-stu-id="1d783-118">A buffer resource is a collection of fully typed data, grouped into elements.</span></span> <span data-ttu-id="1d783-119">バッファーには、<em>頂点バッファー</em> 内のテクスチャ座標、<em>インデックス バッファー</em>内のインデックス、<em>定数バッファー</em>内のシェーダー定数データ、位置ベクトル、法線ベクトル、デバイスの状態などのデータが格納されます。</span><span class="sxs-lookup"><span data-stu-id="1d783-119">Buffers store data, such as texture coordinates in a <em>vertex buffer</em>, indexes in an <em>index buffer</em>, shader constants data in a <em>constant buffer</em>, position vectors, normal vectors, or device state.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="1d783-120"><a href="index-buffers.md">インデックス バッファー</a></span><span class="sxs-lookup"><span data-stu-id="1d783-120"><a href="index-buffers.md">Index buffers</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="1d783-121"><em>インデックス バッファー</em>は、インデックス データを含むメモリ バッファーであり、プリミティブのレンダリングに使用される、頂点バッファーへの整数オフセットです。</span><span class="sxs-lookup"><span data-stu-id="1d783-121"><em>Index buffers</em> are memory buffers that contain index data, which are integer offsets into vertex buffers, used to render primitives.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1d783-122"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1d783-122"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1d783-123">Direct3D グラフィックス学習ガイド</span><span class="sxs-lookup"><span data-stu-id="1d783-123">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




