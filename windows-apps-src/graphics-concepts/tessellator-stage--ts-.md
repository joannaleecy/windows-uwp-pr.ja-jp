---
title: テッセレータ (TS) ステージ
description: テッセレータ (TS) ステージは、ジオメトリ パッチを表すドメインのサンプリング パターンを作成し、サンプルを接続する一連の小さいオブジェクト (三角形、点、または線) を生成します。
ms.assetid: 2F006F3D-5A04-4B3F-8BC7-55567EFCFA6C
keywords:
- テッセレータ (TS) ステージ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1d57c60e8cba9be75e936c55800bac93f8df3e30
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6043943"
---
# <a name="tessellator-ts-stage"></a><span data-ttu-id="af162-104">テッセレータ (TS) ステージ</span><span class="sxs-lookup"><span data-stu-id="af162-104">Tessellator (TS) stage</span></span>


<span data-ttu-id="af162-105">テッセレータ (TS) ステージは、ジオメトリ パッチを表すドメインのサンプリング パターンを作成し、サンプルを接続する一連の小さいオブジェクト (三角形、点、または線) を生成します。</span><span class="sxs-lookup"><span data-stu-id="af162-105">The Tessellator (TS) stage creates a sampling pattern of the domain that represents the geometry patch and generates a set of smaller objects (triangles, points, or lines) that connect these samples.</span></span>

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span data-ttu-id="af162-106"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途</span><span class="sxs-lookup"><span data-stu-id="af162-106"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>Purpose and uses</span></span>


<span data-ttu-id="af162-107">次の図は、Direct3D のグラフィックス パイプラインのステージを示しています。</span><span class="sxs-lookup"><span data-stu-id="af162-107">The following diagram highlights the stages of the Direct3D graphics pipeline.</span></span>

![ハル シェーダー、テッセレータ、およびドメイン シェーダー ステージを示す Direct3D 11 のパイプラインの図](images/d3d11-pipeline-stages-tessellation.png)

<span data-ttu-id="af162-109">次の図は、テッセレーション ステージのプログレッションを示しています。</span><span class="sxs-lookup"><span data-stu-id="af162-109">The following diagram shows the progression through the tessellation stages.</span></span>

![テッセレーションのプログレッションの図](images/tess-prog.png)

<span data-ttu-id="af162-111">プログレッションは、詳細度の低いサブ サーフェスから開始します。</span><span class="sxs-lookup"><span data-stu-id="af162-111">The progression starts with the low-detail subdivision surface.</span></span> <span data-ttu-id="af162-112">次に、これらのサンプルを接続する、対応するジオメトリ パッチ、ドメイン サンプル、および三角形を使用して入力パッチがハイライトされます。</span><span class="sxs-lookup"><span data-stu-id="af162-112">The progression next highlights the input patch with the corresponding geometry patch, domain samples, and triangles that connect these samples.</span></span> <span data-ttu-id="af162-113">最後に、これらのサンプルに対応する頂点がハイライトされます。</span><span class="sxs-lookup"><span data-stu-id="af162-113">The progression finally highlights the vertices that correspond to these samples.</span></span>

<span data-ttu-id="af162-114">Direct3D ランタイムは、テッセレーションを実装する 3 ステージをサポートします。テッセレーションは、GPU 上で詳細度の低いサブディビジョン サーフェスを詳細度の高いプリミティブに変換します。</span><span class="sxs-lookup"><span data-stu-id="af162-114">The Direct3D runtime supports three stages that implement tessellation, which converts low-detail subdivision surfaces into higher-detail primitives on the GPU.</span></span> <span data-ttu-id="af162-115">テッセレーションは、高次サーフェスをレンダリングに適した構造体にタイル化 (または分割) します。</span><span class="sxs-lookup"><span data-stu-id="af162-115">Tessellation tiles (or breaks up) high-order surfaces into suitable structures for rendering.</span></span>

<span data-ttu-id="af162-116">テッセレーションの各ステージは連携して、Direct3D グラフィックス パイプライン内で、詳細なレンダリングを行うため高次のサーフェスを多数の三角形に変換しまず (これによりモデルはシンプルで効率的な状態に保たれます)。</span><span class="sxs-lookup"><span data-stu-id="af162-116">The tessellation stages work together to convert higher-order surfaces (which keep the model simple and efficient) to many triangles for detailed rendering within the Direct3D graphics pipeline.</span></span>

<span data-ttu-id="af162-117">テッセレーションは GPU を使用して、クワッド パッチ、トライアングル パッチまたは等値線から作成されたサーフェスから、より詳細なサーフェスを計算します。</span><span class="sxs-lookup"><span data-stu-id="af162-117">Tessellation uses the GPU to calculate a more detailed surface from a surface constructed from quad patches, triangle patches or isolines.</span></span> <span data-ttu-id="af162-118">高次サーフェスを概算するには、テッセレーション係数を使用して各パッチを三角形、点、線に分割します。</span><span class="sxs-lookup"><span data-stu-id="af162-118">To approximate the high-ordered surface, each patch is subdivided into triangles, points, or lines using tessellation factors.</span></span> <span data-ttu-id="af162-119">Direct3D グラフィックス パイプラインは、3 つのパイプライン ステージを使用してテッセレーションを実装します。</span><span class="sxs-lookup"><span data-stu-id="af162-119">The Direct3D graphics pipeline implements tessellation using three pipeline stages:</span></span>

-   <span data-ttu-id="af162-120">[ハル シェーダー (HS) ステージ](hull-shader-stage--hs-.md) - 各入力パッチ (クワッド、トライアングル、またはライン) に対応するジオメトリ パッチ (およびパッチ定数) を生成するプログラム可能なシェーダー ステージです。</span><span class="sxs-lookup"><span data-stu-id="af162-120">[Hull Shader (HS) stage](hull-shader-stage--hs-.md) - A programmable shader stage that produces a geometry patch (and patch constants) that correspond to each input patch (quad, triangle, or line).</span></span>
-   <span data-ttu-id="af162-121">テッセレータ (TS) ステージ - ジオメトリ パッチを表すドメインのサンプリング パターンを作成し、サンプルを接続する一連の小さいオブジェクト (三角形、点、または線) を生成する固定機能パイプライン ステージです。</span><span class="sxs-lookup"><span data-stu-id="af162-121">Tessellator (TS) stage - A fixed-function pipeline stage that creates a sampling pattern of the domain that represents the geometry patch and generates a set of smaller objects (triangles, points, or lines) that connect these samples.</span></span>
-   <span data-ttu-id="af162-122">[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md) - 各ドメイン サンプルに対応する頂点の位置を計算するプログラム可能なシェーダー ステージです。</span><span class="sxs-lookup"><span data-stu-id="af162-122">[Domain Shader (DS) stage](domain-shader-stage--ds-.md) - A programmable shader stage that calculates the vertex position that corresponds to each domain sample.</span></span>

<span data-ttu-id="af162-123">ハードウェアにテッセレーションを実装すると、グラフィック パイプラインは、詳細度の低い (ポリゴン数の少ない) モデルを評価して、より高い詳細度でレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="af162-123">By implementing tessellation in hardware, a graphics pipeline can evaluate lower detail (lower polygon count) models and render in higher detail.</span></span> <span data-ttu-id="af162-124">ソフトウェア テッセレーションも可能ですが、ハードウェアにより実装されたテッセレーションでは、モデル サイズに表示の詳細を追加したり、リフレッシュ レートを無効化しなくても、非常に精細な表示 (ディスプレースメント マッピングのサポートを含む) を実現できます。</span><span class="sxs-lookup"><span data-stu-id="af162-124">While software tessellation can be done, tessellation implemented by hardware can generate an incredible amount of visual detail (including support for displacement mapping) without adding the visual detail to the model sizes and paralyzing refresh rates.</span></span>

<span data-ttu-id="af162-125">テセレーションの利点:</span><span class="sxs-lookup"><span data-stu-id="af162-125">Benefits of tessellation:</span></span>

-   <span data-ttu-id="af162-126">大量のメモリーおよび帯域幅を節約します。これにより、アプリケーションがより詳細なサーフェスを低解像度モデルからレンダリングできるようになります。</span><span class="sxs-lookup"><span data-stu-id="af162-126">Tessellation saves lots of memory and bandwidth, which allows an application to render higher detailed surfaces from low-resolution models.</span></span> <span data-ttu-id="af162-127">Direct3D グラフィックス パイプラインに実装されているテッセレーション手法では、非常に詳細なサーフェスを実現できるディスプレースメント マッピングもサポートしています。</span><span class="sxs-lookup"><span data-stu-id="af162-127">The tessellation technique implemented in the Direct3D graphics pipeline also supports displacement mapping, which can produce stunning amounts of surface detail.</span></span>
-   <span data-ttu-id="af162-128">随時計算可能な連続的または表示依存の詳細レベルなどのスケーラブルなレンダリング手法をサポートします。</span><span class="sxs-lookup"><span data-stu-id="af162-128">Tessellation supports scalable-rendering techniques, such as continuous or view dependent levels-of-detail which can be calculated on the fly.</span></span>
-   <span data-ttu-id="af162-129">負荷の大きい計算の頻度を下げる (詳細度の低いモデルで計算を実行する) ことで、パフォーマンスを向上します。</span><span class="sxs-lookup"><span data-stu-id="af162-129">Tessellation improves performance by performing expensive computations at lower frequency (doing calculations on a lower-detail model).</span></span> <span data-ttu-id="af162-130">これには、リアルなアニメーションを実現するためのブレンド形状またはモーフ ターゲットを使用したブレンディング計算、または衝突検出用や軟体力学用の物理計算があります。</span><span class="sxs-lookup"><span data-stu-id="af162-130">This could include blending calculations using blend shapes or morph targets for realistic animation or physics calculations for collision detection or soft body dynamics.</span></span>

<span data-ttu-id="af162-131">Direct3D グラフィックス パイプラインは、ハードウェアでテッセレーションを実装し、CPU から GPU に処理をオフロードします。</span><span class="sxs-lookup"><span data-stu-id="af162-131">The Direct3D graphics pipeline implements tessellation in hardware, which off-loads the work from the CPU to the GPU.</span></span> <span data-ttu-id="af162-132">アプリケーションが多数のモーフ ターゲットや洗練されたスキニング/変形モデルを実装している場合、パフォーマンスの大幅な向上を実現できます。</span><span class="sxs-lookup"><span data-stu-id="af162-132">This can lead to very large performance improvements if an application implements large numbers of morph targets and/or more sophisticated skinning/deformation models.</span></span>

<span data-ttu-id="af162-133">テッセレーションは、[ハル シェーダー](hull-shader-stage--hs-.md)をパイプラインにバインドすることで初期化される固定機能ステージです。</span><span class="sxs-lookup"><span data-stu-id="af162-133">The tessellator is a fixed-function stage initialized by binding a [hull shader](hull-shader-stage--hs-.md) to the pipeline.</span></span> <span data-ttu-id="af162-134">(「[How To: Initialize the Tessellator Stage](https://msdn.microsoft.com/library/windows/desktop/ff476341)」(方法: テッセレーション ステージの初期化) を参照)。</span><span class="sxs-lookup"><span data-stu-id="af162-134">(see [How To: Initialize the Tessellator Stage](https://msdn.microsoft.com/library/windows/desktop/ff476341)).</span></span> <span data-ttu-id="af162-135">テッセレータ ステージの目的は、ドメイン (クワッド、トライアングル、またはライン) を多数のより小さいオブジェクト (三角形、点または線) に分割することです。</span><span class="sxs-lookup"><span data-stu-id="af162-135">The purpose of the tessellator stage is to subdivide a domain (quad, tri, or line) into many smaller objects (triangles, points or lines).</span></span> <span data-ttu-id="af162-136">テッセレータは、正規のドメインを標準化された (0 ～ 1 の) 座標系でタイル化します。</span><span class="sxs-lookup"><span data-stu-id="af162-136">The tessellator tiles a canonical domain in a normalized (zero-to-one) coordinate system.</span></span> <span data-ttu-id="af162-137">たとえば、クワッド ドメインは、単位正方形にテッセレーションされます。 </span><span class="sxs-lookup"><span data-stu-id="af162-137">For example, a quad domain is tessellated to a unit square.</span></span>

### <a name="span-idphasesinthetessellatortsstagespanspan-idphasesinthetessellatortsstagespanspan-idphasesinthetessellatortsstagespanphases-in-the-tessellator-ts-stage"></a><span data-ttu-id="af162-138"><span id="Phases_in_the_Tessellator__TS__stage"></span><span id="phases_in_the_tessellator__ts__stage"></span><span id="PHASES_IN_THE_TESSELLATOR__TS__STAGE"></span>テッセレータ (TS) ステージのフェーズ</span><span class="sxs-lookup"><span data-stu-id="af162-138"><span id="Phases_in_the_Tessellator__TS__stage"></span><span id="phases_in_the_tessellator__ts__stage"></span><span id="PHASES_IN_THE_TESSELLATOR__TS__STAGE"></span>Phases in the Tessellator (TS) stage</span></span>

<span data-ttu-id="af162-139">テッセレータ (TS) ステージは次の 2 つのフェーズで動作します。</span><span class="sxs-lookup"><span data-stu-id="af162-139">The Tessellator (TS) stage operates in two phases:</span></span>

-   <span data-ttu-id="af162-140">最初のフェーズでは、32 ビット浮動小数点演算を使用して、テッセレーション係数を処理して丸めの問題を解決した後、非常に小さい係数を処理することで係数の削減および結合を行います。</span><span class="sxs-lookup"><span data-stu-id="af162-140">The first phase processes the tessellation factors, fixing rounding problems, handling very small factors, reducing and combining factors, using 32-bit floating-point arithmetic.</span></span>
-   <span data-ttu-id="af162-141">2 番目のフェーズでは、選択したパーティションの種類に基づいてポイント リストまたはトポロジ リストを生成します。</span><span class="sxs-lookup"><span data-stu-id="af162-141">The second phase generates point or topology lists based on the type of partitioning selected.</span></span> <span data-ttu-id="af162-142">これはテッセレータ ステージの中核タスクで、固定小数点演算の 16 ビットの小数を使用します。</span><span class="sxs-lookup"><span data-stu-id="af162-142">This is the core task of the tessellator stage and uses 16-bit fractions with fixed-point arithmetic.</span></span> <span data-ttu-id="af162-143">固定小数点演算により、許容範囲内の精度を維持しつつハードウェアを加速化できます。</span><span class="sxs-lookup"><span data-stu-id="af162-143">Fixed-point arithmetic allows hardware acceleration while maintaining acceptable precision.</span></span> <span data-ttu-id="af162-144">たとえば、64 メートル幅のパッチの場合、この精度を 2mm の解像度の点にできます。</span><span class="sxs-lookup"><span data-stu-id="af162-144">For example, given a 64 meter wide patch, this precision can place points at a 2 mm resolution.</span></span>

    | <span data-ttu-id="af162-145">パーティションの種類</span><span class="sxs-lookup"><span data-stu-id="af162-145">Type of Partitioning</span></span> | <span data-ttu-id="af162-146">範囲</span><span class="sxs-lookup"><span data-stu-id="af162-146">Range</span></span>                       |
    |----------------------|-----------------------------|
    | <span data-ttu-id="af162-147">Fractional\_odd</span><span class="sxs-lookup"><span data-stu-id="af162-147">Fractional\_odd</span></span>      | <span data-ttu-id="af162-148">\[1...63\]</span><span class="sxs-lookup"><span data-stu-id="af162-148">\[1...63\]</span></span>                  |
    | <span data-ttu-id="af162-149">Fractional\_even</span><span class="sxs-lookup"><span data-stu-id="af162-149">Fractional\_even</span></span>     | <span data-ttu-id="af162-150">TessFactor 範囲: \[2..64\]</span><span class="sxs-lookup"><span data-stu-id="af162-150">TessFactor range: \[2..64\]</span></span> |
    | <span data-ttu-id="af162-151">Integer</span><span class="sxs-lookup"><span data-stu-id="af162-151">Integer</span></span>              | <span data-ttu-id="af162-152">TessFactor 範囲: \[1..64\]</span><span class="sxs-lookup"><span data-stu-id="af162-152">TessFactor range: \[1..64\]</span></span> |
    | <span data-ttu-id="af162-153">Pow2</span><span class="sxs-lookup"><span data-stu-id="af162-153">Pow2</span></span>                 | <span data-ttu-id="af162-154">TessFactor 範囲: \[1..64\]</span><span class="sxs-lookup"><span data-stu-id="af162-154">TessFactor range: \[1..64\]</span></span> |

     

<span data-ttu-id="af162-155">テッセレーションは、[ハル シェーダー](hull-shader-stage--hs-.md)と[ドメイン シェーダー](domain-shader-stage--ds-.md)の 2 つのプログラム可能なシェーダー ステージにより実装されます。</span><span class="sxs-lookup"><span data-stu-id="af162-155">Tessellation is implemented with two programmable shader stages: a [hull shader](hull-shader-stage--hs-.md) and a [domain shader](domain-shader-stage--ds-.md).</span></span> <span data-ttu-id="af162-156">これらのシェーダー ステージは、シェーダー モデル 5 で定義された HLSL コードでプログラムされます。</span><span class="sxs-lookup"><span data-stu-id="af162-156">These shader stages are programmed with HLSL code that is defined in shader model 5.</span></span> <span data-ttu-id="af162-157">シェーダー ターゲットは hs\_5\_0 と ds\_5\_0 です。</span><span class="sxs-lookup"><span data-stu-id="af162-157">The shader targets are: hs\_5\_0 and ds\_5\_0.</span></span> <span data-ttu-id="af162-158">タイトルによってシェーダーが作成され、その後、シェーダーがパイプラインにバインドされるときにランタイムに渡されるコンパイル済みのシェーダーから、ハードウェア用のコードが抽出されます。</span><span class="sxs-lookup"><span data-stu-id="af162-158">The title creates the shader, then code for the hardware is extracted from compiled shaders passed into the runtime when shaders are bound to the pipeline.</span></span>

### <a name="span-idenablingdisablingtessellationspanspan-idenablingdisablingtessellationspanspan-idenablingdisablingtessellationspanenablingdisabling-tessellation"></a><span data-ttu-id="af162-159"><span id="Enabling_disabling_tessellation"></span><span id="enabling_disabling_tessellation"></span><span id="ENABLING_DISABLING_TESSELLATION"></span>テッセレーションの有効化/無効化</span><span class="sxs-lookup"><span data-stu-id="af162-159"><span id="Enabling_disabling_tessellation"></span><span id="enabling_disabling_tessellation"></span><span id="ENABLING_DISABLING_TESSELLATION"></span>Enabling/disabling tessellation</span></span>

<span data-ttu-id="af162-160">テッセレーションは、ハル シェーダーを作成し、これをハル シェーダー ステージにバインドすることによって有効にします (これにより、テッセレータ ステージが自動的にセットアップされます)。</span><span class="sxs-lookup"><span data-stu-id="af162-160">Enable tessellation by creating a hull shader and binding it to the hull-shader stage (this automatically sets up the tessellator stage).</span></span> <span data-ttu-id="af162-161">テッセレーションされたパッチから最終的な頂点位置を生成するには、[ドメイン シェーダー](domain-shader-stage--ds-.md)を作成し、これをドメイン シェーダー ステージにバインドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="af162-161">To generate the final vertex positions from the tessellated patches, you will also need to create a [domain shader](domain-shader-stage--ds-.md) and bind it to the domain-shader stage.</span></span> <span data-ttu-id="af162-162">テッセレーションが有効になると、入力アセンブラー (IA) ステージに入力するデータは、パッチ データである必要があります。</span><span class="sxs-lookup"><span data-stu-id="af162-162">Once tessellation is enabled, the data input to the Input Assembler (IA) stage must be patch data.</span></span> <span data-ttu-id="af162-163">つまり、入力アセンブラー トポロジは、パッチ定数トポロジである必要があります。</span><span class="sxs-lookup"><span data-stu-id="af162-163">The input assembler topology must be a patch constant topology.</span></span>

<span data-ttu-id="af162-164">テッセレーションを無効にするには、ハル シェーダーおよびドメイン シェーダーを **NULL** に設定します。</span><span class="sxs-lookup"><span data-stu-id="af162-164">To disable tessellation, set the hull shader and the domain shader to **NULL**.</span></span> <span data-ttu-id="af162-165">[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)と [ストリーム出力 (SO) ステージ](stream-output-stage--so-.md)のいずれも、ハル シェーダーの出力コントロール ポイントまたはパッチ データを読み取れません。</span><span class="sxs-lookup"><span data-stu-id="af162-165">Neither the [Geometry Shader (GS) stage](geometry-shader-stage--gs-.md) nor the [Stream Output (SO) stage](stream-output-stage--so-.md) can read hull-shader output-control points or patch data.</span></span>

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="af162-166"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="af162-166"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


<span data-ttu-id="af162-167">テッセレータは、ハル シェーダー ステージから渡されるテッセレーション係数 (ドメインをどの程度詳細にテッセレーションするかを指定する) およびパーティションの種類 (パッチのスライスに使用するアルゴリズムを指定する) を使用して、パッチごとに 1 回動作します。</span><span class="sxs-lookup"><span data-stu-id="af162-167">The tessellator operates once per patch using the tessellation factors (which specify how finely the domain will be tessellated) and the type of partitioning (which specifies the algorithm used to slice up a patch) that are passed in from the hull-shader stage.</span></span>

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="af162-168"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="af162-168"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


<span data-ttu-id="af162-169">テッセレータは、uv (およびオプションとして w) 座標およびサーフェス トポロジをドメイン シェーダー ステージに出力します。</span><span class="sxs-lookup"><span data-stu-id="af162-169">The tessellator outputs uv (and optionally w) coordinates and the surface topology to the domain-shader stage.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="af162-170"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="af162-170"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="af162-171">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="af162-171">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




