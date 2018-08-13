---
title: ラスタライザー (RS) ステージ
description: ラスタライザーは、表示されないプリミティブをトリミングし、ピクセル シェーダー (PS) ステージ用にプリミティブを準備して、ピクセル シェーダーを呼び出す方法を決定します。
ms.assetid: 7E80724B-5696-4A99-91AF-49744B5CD3A9
keywords:
- ラスタライザー (RS) ステージ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: b707356b2d90ad4839fdc7f6e52370b74ea4857a
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1044051"
---
# <a name="rasterizer-rs-stage"></a><span data-ttu-id="d079b-104">ラスタライザー (RS) ステージ</span><span class="sxs-lookup"><span data-stu-id="d079b-104">Rasterizer (RS) stage</span></span>


<span data-ttu-id="d079b-105">ラスタライザーは、表示されないプリミティブをトリミングし、[ピクセル シェーダー (PS) ステージ](pixel-shader-stage--ps-.md)用にプリミティブを準備して、ピクセル シェーダーを呼び出す方法を決定します。</span><span class="sxs-lookup"><span data-stu-id="d079b-105">The rasterizer clips primitives that aren't in view, prepares primitives for the [Pixel Shader (PS) stage](pixel-shader-stage--ps-.md), and determines how to invoke pixel shaders.</span></span> <span data-ttu-id="d079b-106">ラスター化ステージは、リアルタイム 3D グラフィックスを表示するために、(図形やプリミティブで構成された) ベクター情報を (ピクセルで構成された) ラスター画像に変換します。</span><span class="sxs-lookup"><span data-stu-id="d079b-106">The rasterization stage converts vector information (composed of shapes or primitives) into a raster image (composed of pixels) for the purpose of displaying real-time 3D graphics.</span></span>

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span data-ttu-id="d079b-107"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途</span><span class="sxs-lookup"><span data-stu-id="d079b-107"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>Purpose and uses</span></span>


<span data-ttu-id="d079b-108">ラスター化時には、各プリミティブがピクセルに変換され、各プリミティブでは頂点単位の値が補間されます。</span><span class="sxs-lookup"><span data-stu-id="d079b-108">During rasterization, each primitive is converted into pixels, while interpolating per-vertex values across each primitive.</span></span> <span data-ttu-id="d079b-109">ラスター化では、視錘台に対する頂点のクリッピング、パースペクティブを求めるための z での除算、2D ビューポートへのプリミティブのマッピング、およびピクセル シェーダーの呼び出し方法の決定などが行われます。</span><span class="sxs-lookup"><span data-stu-id="d079b-109">Rasterization includes clipping vertices to the view frustum, performing a divide by z to provide perspective, mapping primitives to a 2D viewport, and determining how to invoke the pixel shader.</span></span> <span data-ttu-id="d079b-110">ピクセル シェーダーの使用は省略できますが、ラスタライザー ステージでは常に、クリッピング、点を同次空間に変換するための透視除算、およびビューポートへの頂点のマッピングが実行されます。</span><span class="sxs-lookup"><span data-stu-id="d079b-110">While using a pixel shader is optional, the rasterizer stage always performs clipping, a perspective divide to transform the points into homogeneous space, and maps the vertices to the viewport.</span></span>

<span data-ttu-id="d079b-111">ラスター化を無効にするには、ピクセル シェーダーが存在しないことをパイプラインに通知します ([ピクセル シェーダー ステージ (PS)](pixel-shader-stage--ps-.md) を **NULL** に設定して、深度およびステンシル テストを無効にします)。</span><span class="sxs-lookup"><span data-stu-id="d079b-111">You may disable rasterization by telling the pipeline there is no pixel shader (set the [Pixel Shader (PS) stage](pixel-shader-stage--ps-.md) to **NULL** and disable depth and stencil testing).</span></span> <span data-ttu-id="d079b-112">無効になっている間、ラスター化関連のパイプライン カウンターは更新されません。</span><span class="sxs-lookup"><span data-stu-id="d079b-112">While disabled, rasterization-related pipeline counters will not update.</span></span>

<span data-ttu-id="d079b-113">階層型 Z バッファー最適化を実装しているハードウェアでは、深度およびステンシル テストを有効にしたままピクセル シェーダー (PS) ステージを **NULL** に設定することで、Z バッファーを事前に読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d079b-113">On hardware that implements hierarchical Z-buffer optimizations, you may enable preloading the z-buffer by setting the Pixel Shader (PS) stage to **NULL** while enabling depth and stencil testing.</span></span>

<span data-ttu-id="d079b-114">「[ラスター化ルール](rasterization-rules.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d079b-114">See [Rasterization rules](rasterization-rules.md).</span></span>

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="d079b-115"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="d079b-115"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


<span data-ttu-id="d079b-116">ラスタライザー ステージに渡される頂点 (x、y、z、w) は同次クリップ空間と見なされます。</span><span class="sxs-lookup"><span data-stu-id="d079b-116">Vertices (x,y,z,w), coming into the Rasterizer stage are assumed to be in homogeneous clip-space.</span></span> <span data-ttu-id="d079b-117">この座標空間では、X 軸は右向き、Y 軸は上向き、Z 軸はカメラから遠ざかる方向を向きます。</span><span class="sxs-lookup"><span data-stu-id="d079b-117">In this coordinate space the X axis points right, Y points up and Z points away from camera.</span></span>

<span data-ttu-id="d079b-118">固定関数のラスタライザー (RS) ステージは、ストリーム出力 (SO) ステージや、[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)などの前のパイプライン ステージから入力を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="d079b-118">The fixed-function Rasterizer (RS) stage is fed by the Stream Output (SO) stage and/or by the previous pipeline stage, such as the [Geometry Shader (GS) stage](geometry-shader-stage--gs-.md).</span></span> <span data-ttu-id="d079b-119">GS が使用されていない場合、RS は[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)から入力を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="d079b-119">If GS isn't used, RS is fed by the [Domain Shader (DS) stage](domain-shader-stage--ds-.md).</span></span> <span data-ttu-id="d079b-120">DS も使用されていない場合、RS は[頂点シェーダー (VS) ステージ](vertex-shader-stage--vs-.md)から入力を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="d079b-120">If DS also isn't used, RS is fed by the [Vertex Shader (VS) stage](vertex-shader-stage--vs-.md).</span></span>

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="d079b-121"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="d079b-121"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


<span data-ttu-id="d079b-122">ピクセル シェーダー (PS) ステージの使用は省略できます。代わりに、ラスタライザー ステージから[出力結合 (OM) ステージ](output-merger-stage--om-.md)に直接出力することができます。</span><span class="sxs-lookup"><span data-stu-id="d079b-122">Using the Pixel Shader (PS) stage is optional; the rasterizer stage can output directly to the [Output Merger (OM) stage](output-merger-stage--om-.md) instead.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="d079b-123"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="d079b-123"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="d079b-124">ラスター化ルール</span><span class="sxs-lookup"><span data-stu-id="d079b-124">Rasterization rules</span></span>](rasterization-rules.md)

[<span data-ttu-id="d079b-125">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="d079b-125">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




