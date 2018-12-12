---
title: ドメイン シェーダー (DS) ステージ
description: ドメイン シェーダー (DS) ステージでは、パッチ内の細分化されたポイントの頂点の位置を計算します。つまり、各ドメイン サンプルに対応する頂点の位置を計算します。
ms.assetid: 673CC04A-A74F-495F-AFB7-49157538749C
keywords:
- ドメイン シェーダー (DS) ステージ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: bbde90d848d3bc8fb18a5ecf370c85121adc02f6
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8934667"
---
# <a name="domain-shader-ds-stage"></a><span data-ttu-id="333d8-104">ドメイン シェーダー (DS) ステージ</span><span class="sxs-lookup"><span data-stu-id="333d8-104">Domain Shader (DS) stage</span></span>


<span data-ttu-id="333d8-105">ドメイン シェーダー (DS) ステージでは、パッチ内の細分化されたポイントの頂点の位置を計算します。つまり、各ドメイン サンプルに対応する頂点の位置を計算します。</span><span class="sxs-lookup"><span data-stu-id="333d8-105">The Domain Shader (DS) stage calculates the vertex position of a subdivided point in the output patch; it calculates the vertex position that corresponds to each domain sample.</span></span> <span data-ttu-id="333d8-106">ドメイン シェーダーは、テッセレータ ステージの出力ポイントごとに 1 回実行され、ハル シェーダーの出力パッチや出力パッチ定数、およびテッセレータ ステージの出力 UV 座標への読み取り専用アクセスが可能です。</span><span class="sxs-lookup"><span data-stu-id="333d8-106">A domain shader is run once per tessellator stage output point and has read-only access to the hull shader output patch and output patch constants, and the tessellator stage output UV coordinates.</span></span>

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span data-ttu-id="333d8-107"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途</span><span class="sxs-lookup"><span data-stu-id="333d8-107"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>Purpose and uses</span></span>


<span data-ttu-id="333d8-108">ドメイン シェーダー (DS) ステージは、[ハル シェーダー (HS) ステージ](hull-shader-stage--hs-.md)と[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)からの入力に基づいて、出力パッチ内の細分化されたポイントの頂点の位置を出力します。</span><span class="sxs-lookup"><span data-stu-id="333d8-108">The Domain Shader (DS) stage outputs the vertex position of a subdivided point in the output patch, based on input from the [Hull Shader (HS) stage](hull-shader-stage--hs-.md) and the [Tessellator (TS) stage](tessellator-stage--ts-.md).</span></span>

![ドメイン シェーダー ステージの図](images/d3d11-domain-shader.png)

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="333d8-110"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="333d8-110"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


-   <span data-ttu-id="333d8-111">ドメイン シェーダーは、[ハル シェーダー (HS) ステージ](hull-shader-stage--hs-.md)からの出力の制御点を利用します。</span><span class="sxs-lookup"><span data-stu-id="333d8-111">A domain shader consumes output control points from the [Hull Shader (HS) stage](hull-shader-stage--hs-.md).</span></span> <span data-ttu-id="333d8-112">ハル シェーダーの出力には次の項目が含まれます。</span><span class="sxs-lookup"><span data-stu-id="333d8-112">The hull shader outputs include:</span></span>
    -   <span data-ttu-id="333d8-113">制御点。</span><span class="sxs-lookup"><span data-stu-id="333d8-113">Control points.</span></span>
    -   <span data-ttu-id="333d8-114">パッチ定数データ。</span><span class="sxs-lookup"><span data-stu-id="333d8-114">Patch constant data.</span></span>
    -   <span data-ttu-id="333d8-115">テセレーション係数。</span><span class="sxs-lookup"><span data-stu-id="333d8-115">Tessellation factors.</span></span> <span data-ttu-id="333d8-116">テセレーション係数には、未処理の値 (整数テセレーションによる丸めの前など) と共に、固定機能テッセレータで使われる値を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="333d8-116">The tessellation factors can include the values used by the fixed-function tessellator as well as the raw values (before rounding by integer tessellation, for example), which facilitates geomorphing, for example.</span></span>
-   <span data-ttu-id="333d8-117">ドメイン シェーダーは、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)からの出力座標ごとに 1 回呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="333d8-117">A domain shader is invoked once per output coordinate from the [Tessellator (TS) stage](tessellator-stage--ts-.md).</span></span>

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="333d8-118"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="333d8-118"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


-   <span data-ttu-id="333d8-119">ドメイン シェーダー (DS) ステージでは、出力パッチ内の細分化されたポイントの頂点の位置を出力します。</span><span class="sxs-lookup"><span data-stu-id="333d8-119">The Domain Shader (DS) stage outputs the vertex position of a subdivided point in the output patch.</span></span>

<span data-ttu-id="333d8-120">ドメイン シェーダーが完了すると、テセレーションは終了し、パイプライン データは、[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)や[ピクセル シェーダー (PS) ステージ](pixel-shader-stage--ps-.md)など、次のパイプライン ステージで処理が続行されます。</span><span class="sxs-lookup"><span data-stu-id="333d8-120">After the domain shader completes, tessellation is finished and pipeline data continues to the next pipeline stage, such as the [Geometry Shader (GS) stage](geometry-shader-stage--gs-.md) and the [Pixel Shader (PS) stage](pixel-shader-stage--ps-.md).</span></span> <span data-ttu-id="333d8-121">隣接性を持つプリミティブ (三角形ごとに 6 個の頂点など) を想定するジオメトリ シェーダーは、テセレーションがアクティブな場合には有効ではありません (これは未定義の動作となり、デバッグ レイヤーで問題が検出されます)。</span><span class="sxs-lookup"><span data-stu-id="333d8-121">A geometry shader that expects primitives with adjacency (for example, 6 vertices per triangle) is not valid when tessellation is active (this results in undefined behavior, which the debug layer will complain about).</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="333d8-122"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="333d8-122"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


```
void main( out    MyDSOutput result, 
           float2 myInputUV : SV_DomainPoint, 
           MyDSInput DSInputs,
           OutputPatch<MyOutPoint, 12> ControlPts, 
           MyTessFactors tessFactors)
{
     ...

     result.Position = EvaluateSurfaceUV(ControlPoints, myInputUV);
}
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="333d8-123"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="333d8-123"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="333d8-124">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="333d8-124">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




