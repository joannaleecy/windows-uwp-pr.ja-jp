---
title: ハル シェーダー (HS) ステージ
description: ハル シェーダー (HS) ステージは、モデルの 1 つのサーフェスを効率的に多数の三角形に分割する、テセレーション ステージの 1 つです。
ms.assetid: C62F6F15-CAD7-4C72-9735-00762E346C4C
keywords:
- ハル シェーダー (HS) ステージ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9137f7ef46da1b861976dbac680327febf315dac
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7987601"
---
# <a name="hull-shader-hs-stage"></a><span data-ttu-id="650e9-104">ハル シェーダー (HS) ステージ</span><span class="sxs-lookup"><span data-stu-id="650e9-104">Hull Shader (HS) stage</span></span>


<span data-ttu-id="650e9-105">ハル シェーダー (HS) ステージは、モデルの 1 つのサーフェスを効率的に多数の三角形に分割する、テセレーション ステージの 1 つです。</span><span class="sxs-lookup"><span data-stu-id="650e9-105">The Hull Shader (HS) stage is one of the tessellation stages, which efficiently break up a single surface of a model into many triangles.</span></span> <span data-ttu-id="650e9-106">ハル シェーダー (HS) ステージは、各入力パッチ (クワッド、トライアングル、またはライン) に対応するジオメトリ パッチ (およびパッチ定数) を生成します。</span><span class="sxs-lookup"><span data-stu-id="650e9-106">The Hull Shader (HS) stage produces a geometry patch (and patch constants) that correspond to each input patch (quad, triangle, or line).</span></span> <span data-ttu-id="650e9-107">ハル シェーダーは、パッチごとに 1 回呼び出され、低次サーフェスを定義する入力制御点を、パッチを構成する制御点に変換します。</span><span class="sxs-lookup"><span data-stu-id="650e9-107">A hull shader is invoked once per patch, and it transforms input control points that define a low-order surface into control points that make up a patch.</span></span> <span data-ttu-id="650e9-108">また、ハル シェーダーは、いくつかのパッチごとの計算を行い、データを[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)と[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)に提供します。</span><span class="sxs-lookup"><span data-stu-id="650e9-108">It also does some per-patch calculations to provide data for the [Tessellator (TS) stage](tessellator-stage--ts-.md) and the [Domain Shader (DS) stage](domain-shader-stage--ds-.md).</span></span>

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span data-ttu-id="650e9-109"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途</span><span class="sxs-lookup"><span data-stu-id="650e9-109"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>Purpose and uses</span></span>


![ハル シェーダー ステージの図](images/d3d11-hull-shader.png)

<span data-ttu-id="650e9-111">テッセレーションの 3 つのステージは連携して、グラフィックス パイプライン内で、詳細なレンダリングを行うため高次のサーフェスを多数の三角形に変換しまず (これによりモデルはシンプルで効率的な状態に保たれます)。</span><span class="sxs-lookup"><span data-stu-id="650e9-111">The three tessellation stages work together to convert higher-order surfaces (which keep the model simple and efficient) to many triangles for detailed rendering within the graphics pipeline.</span></span> <span data-ttu-id="650e9-112">テセレーション ステージには、ハル シェーダー (HS) ステージ、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)、および[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="650e9-112">The tessellation stages include the Hull Shader (HS) stage, [Tessellator (TS) stage](tessellator-stage--ts-.md), and [Domain Shader (DS) stage](domain-shader-stage--ds-.md).</span></span>

<span data-ttu-id="650e9-113">ハル シェーダー (HS) ステージは、プログラム可能なシェーダー ステージです。</span><span class="sxs-lookup"><span data-stu-id="650e9-113">The Hull Shader (HS) stage is a programmable shader stage.</span></span> <span data-ttu-id="650e9-114">ハル シェーダーは、HLSL 関数を使って実装されます。</span><span class="sxs-lookup"><span data-stu-id="650e9-114">A hull shader is implemented with an HLSL function.</span></span>

<span data-ttu-id="650e9-115">ハル シェーダーは、制御点フェーズとパッチ定数フェーズの 2 つのフェーズで動作します。これらはハードウェアによって並行して実行されます。</span><span class="sxs-lookup"><span data-stu-id="650e9-115">A hull shader operates in two phases: a control-point phase and a patch-constant phase, which are run in parallel by the hardware.</span></span> <span data-ttu-id="650e9-116">HLSL コンパイラは、ハル シェーダーの並列処理を抽出し、ハードウェアを駆動するバイトコードにエンコードします。</span><span class="sxs-lookup"><span data-stu-id="650e9-116">The HLSL compiler extracts the parallelism in a hull shader and encodes it into bytecode that drives the hardware.</span></span>

-   <span data-ttu-id="650e9-117">制御点フェーズは制御点ごとに 1 回実行され、パッチの制御点を読み取り、1 つの出力制御点 (**ControlPointID** で識別される) を生成します。</span><span class="sxs-lookup"><span data-stu-id="650e9-117">The control-point phase operates once for each control-point, reading the control points for a patch, and generating one output control point (identified by a **ControlPointID**).</span></span>
-   <span data-ttu-id="650e9-118">パッチ定数フェーズは、パッチごとに 1 回実行され、エッジ テセレーション係数とその他のパッチごとの定数を生成します。</span><span class="sxs-lookup"><span data-stu-id="650e9-118">The patch-constant phase operates once per patch to generate edge tessellation factors and other per-patch constants.</span></span> <span data-ttu-id="650e9-119">内部的には、複数のパッチ定数フェーズが同時に実行される場合があります。</span><span class="sxs-lookup"><span data-stu-id="650e9-119">Internally, many patch-constant phases may run at the same time.</span></span> <span data-ttu-id="650e9-120">パッチ定数フェーズでは、すべての入力制御点と出力制御点に対して読み取り専用アクセスの権限があります。</span><span class="sxs-lookup"><span data-stu-id="650e9-120">The patch-constant phase has read-only access to all input and output control points.</span></span>

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="650e9-121"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="650e9-121"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


<span data-ttu-id="650e9-122">1 ～ 32 個の入力制御点。これらがまとまって低次サーフェスを定義します。</span><span class="sxs-lookup"><span data-stu-id="650e9-122">Between 1 and 32 input control points, which together define a low-order surface.</span></span>

-   <span data-ttu-id="650e9-123">ハル シェーダーは、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)で必要な状態を宣言します。</span><span class="sxs-lookup"><span data-stu-id="650e9-123">The hull shader declares the state required by the [Tessellator (TS) stage](tessellator-stage--ts-.md).</span></span> <span data-ttu-id="650e9-124">これには、テセレーションで使用する制御点の数、パッチ面の種類、分割の種類などの情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="650e9-124">This includes information such as the number of control points, the type of patch face and the type of partitioning to use when tessellating.</span></span> <span data-ttu-id="650e9-125">この情報は、通常、シェーダー コードの最初に宣言として表示されます。</span><span class="sxs-lookup"><span data-stu-id="650e9-125">This information appears as declarations typically at the front of the shader code.</span></span>
-   <span data-ttu-id="650e9-126">テセレーション係数は、各パッチを分割する程度を決定します。</span><span class="sxs-lookup"><span data-stu-id="650e9-126">Tessellation factors determine how much to subdivide each patch.</span></span>

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="650e9-127"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="650e9-127"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


<span data-ttu-id="650e9-128">1 ～ 32 個の出力制御点。これらがまとまってパッチを構成します。</span><span class="sxs-lookup"><span data-stu-id="650e9-128">Between 1 and 32 output control points, which together make up a patch.</span></span>

-   <span data-ttu-id="650e9-129">シェーダーの出力は、テセレーション係数の数に関係なく、1 ～ 32 個の制御点です。</span><span class="sxs-lookup"><span data-stu-id="650e9-129">The shader output is between 1 and 32 control points, regardless of the number of tessellation factors.</span></span> <span data-ttu-id="650e9-130">ハル シェーダーから出力された制御点は、ドメイン シェーダー ステージで使用できます。</span><span class="sxs-lookup"><span data-stu-id="650e9-130">The control-points output from a hull shader can be consumed by the domain-shader stage.</span></span> <span data-ttu-id="650e9-131">パッチ定数データは、ドメイン シェーダーで使用できます。</span><span class="sxs-lookup"><span data-stu-id="650e9-131">Patch constant data can be consumed by a domain shader.</span></span> <span data-ttu-id="650e9-132">テセレーション係数は、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)と[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)で使用できます。</span><span class="sxs-lookup"><span data-stu-id="650e9-132">Tessellation factors can be consumed by the [Tessellator (TS) stage](tessellator-stage--ts-.md) and the [Domain Shader (DS) stage](domain-shader-stage--ds-.md).</span></span>
-   <span data-ttu-id="650e9-133">ハル シェーダーがいずれかのエッジ テセレーション係数を ≤ 0または NaN に設定する場合、パッチをカリングする (省略する) ことができます。</span><span class="sxs-lookup"><span data-stu-id="650e9-133">If the hull shader sets any edge tessellation factor to ≤ 0 or NaN, the patch will be culled (omitted).</span></span> <span data-ttu-id="650e9-134">その結果、テッセレータ ステージは実行される場合と実行されない場合があり、ドメイン シェーダーは実行されず、そのパッチの表示出力は生成されません。</span><span class="sxs-lookup"><span data-stu-id="650e9-134">As a result, the tessellator stage may or may not run, the domain shader will not run, and no visible output will be produced for that patch.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="650e9-135"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="650e9-135"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


```
[patchsize(12)]
[patchconstantfunc(MyPatchConstantFunc)]
MyOutPoint main(uint Id : SV_ControlPointID,
     InputPatch<MyInPoint, 12> InPts)
{
     MyOutPoint result;
     
     ...
     
     result = TransformControlPoint( InPts[Id] );

     return result;
}
```

<span data-ttu-id="650e9-136">「[方法: ハル シェーダーの作成](https://msdn.microsoft.com/library/windows/desktop/ff476338)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="650e9-136">See [How To: Create a Hull Shader](https://msdn.microsoft.com/library/windows/desktop/ff476338).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="650e9-137"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="650e9-137"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="650e9-138">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="650e9-138">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




