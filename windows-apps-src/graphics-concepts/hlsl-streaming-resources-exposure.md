---
title: HLSL ストリーミング リソースの露出
description: シェーダー モデル 5 のストリーミング リソースをサポートするには、Microsoft 上位レベル シェーダー言語 (HLSL) の特定の構文が必要です。
ms.assetid: 00A40D82-0565-43DC-82AB-0675B7E772E3
keywords:
- HLSL ストリーミング リソースの露出
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a8523f4895c541ffb3b92ee00d5b62c57343ae00
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6203927"
---
# <a name="hlsl-streaming-resources-exposure"></a><span data-ttu-id="dd74a-104">HLSL ストリーミング リソースの露出</span><span class="sxs-lookup"><span data-stu-id="dd74a-104">HLSL streaming resources exposure</span></span>


<span data-ttu-id="dd74a-105">[シェーダー モデル 5](https://msdn.microsoft.com/library/windows/desktop/ff471356) のストリーミング リソースをサポートするには、Microsoft 上位レベル シェーダー言語 (HLSL) の特定の構文が必要です。</span><span class="sxs-lookup"><span data-stu-id="dd74a-105">A specific Microsoft High Level Shader Language (HLSL) syntax is required to support streaming resources in [Shader Model 5](https://msdn.microsoft.com/library/windows/desktop/ff471356).</span></span>

<span data-ttu-id="dd74a-106">シェーダー モデル 5 の HLSL 構文は、ストリーミング リソースのサポートを備えたデバイスでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="dd74a-106">The HLSL syntax for Shader Model 5 is allowed only on devices with streaming resources support.</span></span> <span data-ttu-id="dd74a-107">次の表のストリーミング リソース用の関連する各 HLSL メソッドでは、1 つ (フィードバック) または 2 つ (クランプとフィードバックをこの順序で) の追加の省略可能なパラメーターを指定できます。</span><span class="sxs-lookup"><span data-stu-id="dd74a-107">Each relevant HLSL method for streaming resources in the following table accepts either one (feedback) or two (clamp and feedback in this order) additional optional parameters.</span></span> <span data-ttu-id="dd74a-108">**Sample** メソッドの例を示します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-108">For example, a **Sample** method is:</span></span>

**<span data-ttu-id="dd74a-109">Sample(sampler, location \[, offset \[, clamp \[, feedback\] \] \])</span><span class="sxs-lookup"><span data-stu-id="dd74a-109">Sample(sampler, location \[, offset \[, clamp \[, feedback\] \] \])</span></span>**

<span data-ttu-id="dd74a-110">**Sample** メソッドの例は、[**Texture2D.Sample(S,float,int,float,uint)**](https://msdn.microsoft.com/library/windows/desktop/dn393787) のようになります。</span><span class="sxs-lookup"><span data-stu-id="dd74a-110">An example of a **Sample** method is [**Texture2D.Sample(S,float,int,float,uint)**](https://msdn.microsoft.com/library/windows/desktop/dn393787).</span></span>

<span data-ttu-id="dd74a-111">offset、clamp、feedback の各パラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="dd74a-111">The offset, clamp and feedback parameters are optional.</span></span> <span data-ttu-id="dd74a-112">必要なパラメーターまで、すべての省略可能なパラメーターを指定する必要があります。これは、C++ の既定の関数の引数に関する規則と一貫しています。</span><span class="sxs-lookup"><span data-stu-id="dd74a-112">You must specify all optional parameters up to the one you need, which is consistent with the C++ rules for default function arguments.</span></span> <span data-ttu-id="dd74a-113">たとえば、フィードバックの状態が必要な場合、**Sample** に対して、論理的には必要ではない場合でも、offset および clamp の両方のパラメーターを明示的に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dd74a-113">For example, if the feedback status is needed, both offset and clamp parameters need to be explicitly supplied to **Sample**, even though they may not be logically needed.</span></span>

<span data-ttu-id="dd74a-114">clamp パラメーターは、浮動小数点のスカラー値です。</span><span class="sxs-lookup"><span data-stu-id="dd74a-114">The clamp parameter is a scalar float value.</span></span> <span data-ttu-id="dd74a-115">リテラル値の clamp = 0.0f は、クランプ操作が実行されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-115">The literal value of clamp=0.0f indicates that the clamp operation isn't performed.</span></span>

<span data-ttu-id="dd74a-116">feedback パラメーターは **uint** 変数で、メモリ アクセス照会の組み込み関数 [**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) に対して指定できます。</span><span class="sxs-lookup"><span data-stu-id="dd74a-116">The feedback parameter is a **uint** variable that you can supply to the memory-access querying intrinsic [**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) function.</span></span> <span data-ttu-id="dd74a-117">feedback パラメーターの値を変更または解釈しないでください。コンパイラでは、値を変更したかどうかを検出するための高度な分析と診断の機能は提供されません。</span><span class="sxs-lookup"><span data-stu-id="dd74a-117">You must not modify or interpret the value of the feedback parameter; but, the compiler doesn't provide any advanced analysis and diagnostics to detect whether you modified the value.</span></span>

<span data-ttu-id="dd74a-118">[**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) の構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="dd74a-118">Here is the syntax of [**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083):</span></span>

**<span data-ttu-id="dd74a-119">bool CheckAccessFullyMapped(in uint FeedbackVar);</span><span class="sxs-lookup"><span data-stu-id="dd74a-119">bool CheckAccessFullyMapped(in uint FeedbackVar);</span></span>**

<span data-ttu-id="dd74a-120">[**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) は、*FeedbackVar* の値を解釈し、アクセスされているすべてのデータがリソースにマップされていた場合は true を返します。それ以外の場合、**CheckAccessFullyMapped** は false を返します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-120">[**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) interprets the value of *FeedbackVar* and returns true if all data being accessed was mapped in the resource; otherwise, **CheckAccessFullyMapped** returns false.</span></span>

<span data-ttu-id="dd74a-121">clamp と feedback のいずれかのパラメーターが存在する場合、コンパイラは、基本的な命令のバリアントを出力します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-121">If either the clamp or feedback parameter is present, the compiler emits a variant of the basic instruction.</span></span> <span data-ttu-id="dd74a-122">たとえば、ストリーミング リソースのサンプルは、`sample_cl_s` 命令を生成します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-122">For example, sample of a streaming resource generates the `sample_cl_s` instruction.</span></span>

<span data-ttu-id="dd74a-123">clamp も feedback も指定しない場合、現在の動作と変わらないようにするために、コンパイラは基本的な命令を出力します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-123">If neither clamp nor feedback is specified, the compiler emits the basic instruction, so that there is no change from the current behavior.</span></span>

<span data-ttu-id="dd74a-124">クランプ値が 0.0f である場合、クランプは実行されません。したがって、ドライバーのコンパイラは対象ハードウェアに合わせて命令をさらに調整することができます。</span><span class="sxs-lookup"><span data-stu-id="dd74a-124">The clamp value of 0.0f indicates that no clamp is performed; thus, the driver compiler can further tailor the instruction to the target hardware.</span></span> <span data-ttu-id="dd74a-125">フィードバックが命令で NULL レジスタである場合、フィードバックは使用されていません。したがって、ドライバーのコンパイラはターゲット アーキテクチャに合わせて命令をさらに調整することができます。</span><span class="sxs-lookup"><span data-stu-id="dd74a-125">If feedback is a NULL register in an instruction, the feedback is unused; thus, the driver compiler can further tailor the instruction to the target architecture.</span></span>

<span data-ttu-id="dd74a-126">HLSL コンパイラは、クランプが 0.0f であり、フィードバックが使用されていないことを推測する場合、対応する基本的な命令 (たとえば、`sample_cl_s` ではなく `sample` ) を生成します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-126">If the HLSL compiler infers that clamp is 0.0f and feedback is unused, the compiler emits the corresponding basic instruction (for example, `sample` rather than `sample_cl_s`).</span></span>

<span data-ttu-id="dd74a-127">ストリーミング リソースへのアクセスが、複数のバイト コード命令で構成される場合 (構造化されたリソースなど)、コンパイラは OR 演算によって個別のフィードバック値を集計し、最終的なフィードバック値を生成します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-127">If a streaming resource access consists of several constituent byte code instructions, for example, for structured resources, the compiler aggregates individual feedback values via the OR operation to produce the final feedback value.</span></span> <span data-ttu-id="dd74a-128">そのため、このような複雑なアクセスでも、1 つのフィードバック値が示されます。</span><span class="sxs-lookup"><span data-stu-id="dd74a-128">Therefore, you see a single feedback value for such a complex access.</span></span>

<span data-ttu-id="dd74a-129">フィードバックやクランプをサポートするために変更される HLSL メソッドをまとめた表を次に示します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-129">This is the summary table of HLSL methods that are changed to support feedback and/or clamp.</span></span> <span data-ttu-id="dd74a-130">これらは、あらゆるサイズのタイル リソースや非ストリーミング リソースで動作します。</span><span class="sxs-lookup"><span data-stu-id="dd74a-130">These all work on tiled and non-streaming resources of all dimensions.</span></span> <span data-ttu-id="dd74a-131">非ストリーミング リソースは、常に、完全にマップされているように表示されます。</span><span class="sxs-lookup"><span data-stu-id="dd74a-131">Non-streaming resources always appear to be fully mapped.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><a href="https://msdn.microsoft.com/library/windows/desktop/ff471359"><span data-ttu-id="dd74a-132">HLSL オブジェクト</span><span class="sxs-lookup"><span data-stu-id="dd74a-132">HLSL objects</span></span></a> </th>
<th align="left"><span data-ttu-id="dd74a-133">フィードバック オプションを持つ組み込みメソッド (\*) - クランプ オプションも持つ</span><span class="sxs-lookup"><span data-stu-id="dd74a-133">Intrinsic methods with feedback option (\*) - also has clamp option</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="dd74a-134">[RW]Texture2D</span><span class="sxs-lookup"><span data-stu-id="dd74a-134">[RW]Texture2D</span></span></p>
<p><span data-ttu-id="dd74a-135">[RW]Texture2DArray</span><span class="sxs-lookup"><span data-stu-id="dd74a-135">[RW]Texture2DArray</span></span></p>
<p><span data-ttu-id="dd74a-136">TextureCUBE</span><span class="sxs-lookup"><span data-stu-id="dd74a-136">TextureCUBE</span></span></p>
<p><span data-ttu-id="dd74a-137">TextureCUBEArray</span><span class="sxs-lookup"><span data-stu-id="dd74a-137">TextureCUBEArray</span></span></p></td>
<td align="left"><p><span data-ttu-id="dd74a-138">Gather</span><span class="sxs-lookup"><span data-stu-id="dd74a-138">Gather</span></span></p>
<p><span data-ttu-id="dd74a-139">GatherRed</span><span class="sxs-lookup"><span data-stu-id="dd74a-139">GatherRed</span></span></p>
<p><span data-ttu-id="dd74a-140">GatherGreen</span><span class="sxs-lookup"><span data-stu-id="dd74a-140">GatherGreen</span></span></p>
<p><span data-ttu-id="dd74a-141">GatherBlue</span><span class="sxs-lookup"><span data-stu-id="dd74a-141">GatherBlue</span></span></p>
<p><span data-ttu-id="dd74a-142">GatherAlpha</span><span class="sxs-lookup"><span data-stu-id="dd74a-142">GatherAlpha</span></span></p>
<p><span data-ttu-id="dd74a-143">GatherCmp</span><span class="sxs-lookup"><span data-stu-id="dd74a-143">GatherCmp</span></span></p>
<p><span data-ttu-id="dd74a-144">GatherCmpRed</span><span class="sxs-lookup"><span data-stu-id="dd74a-144">GatherCmpRed</span></span></p>
<p><span data-ttu-id="dd74a-145">GatherCmpGreen</span><span class="sxs-lookup"><span data-stu-id="dd74a-145">GatherCmpGreen</span></span></p>
<p><span data-ttu-id="dd74a-146">GatherCmpBlue</span><span class="sxs-lookup"><span data-stu-id="dd74a-146">GatherCmpBlue</span></span></p>
<p><span data-ttu-id="dd74a-147">GatherCmpAlpha</span><span class="sxs-lookup"><span data-stu-id="dd74a-147">GatherCmpAlpha</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="dd74a-148">[RW]Texture1D</span><span class="sxs-lookup"><span data-stu-id="dd74a-148">[RW]Texture1D</span></span></p>
<p><span data-ttu-id="dd74a-149">[RW]Texture1DArray</span><span class="sxs-lookup"><span data-stu-id="dd74a-149">[RW]Texture1DArray</span></span></p>
<p><span data-ttu-id="dd74a-150">[RW]Texture2D</span><span class="sxs-lookup"><span data-stu-id="dd74a-150">[RW]Texture2D</span></span></p>
<p><span data-ttu-id="dd74a-151">[RW]Texture2DArray</span><span class="sxs-lookup"><span data-stu-id="dd74a-151">[RW]Texture2DArray</span></span></p>
<p><span data-ttu-id="dd74a-152">[RW]Texture3D</span><span class="sxs-lookup"><span data-stu-id="dd74a-152">[RW]Texture3D</span></span></p>
<p><span data-ttu-id="dd74a-153">TextureCUBE</span><span class="sxs-lookup"><span data-stu-id="dd74a-153">TextureCUBE</span></span></p>
<p><span data-ttu-id="dd74a-154">TextureCUBEArray</span><span class="sxs-lookup"><span data-stu-id="dd74a-154">TextureCUBEArray</span></span></p></td>
<td align="left"><p><span data-ttu-id="dd74a-155">Sample\*</span><span class="sxs-lookup"><span data-stu-id="dd74a-155">Sample\*</span></span></p>
<p><span data-ttu-id="dd74a-156">SampleBias\*</span><span class="sxs-lookup"><span data-stu-id="dd74a-156">SampleBias\*</span></span></p>
<p><span data-ttu-id="dd74a-157">SampleCmp\*</span><span class="sxs-lookup"><span data-stu-id="dd74a-157">SampleCmp\*</span></span></p>
<p><span data-ttu-id="dd74a-158">SampleCmpLevelZero</span><span class="sxs-lookup"><span data-stu-id="dd74a-158">SampleCmpLevelZero</span></span></p>
<p><span data-ttu-id="dd74a-159">SampleGrad\*</span><span class="sxs-lookup"><span data-stu-id="dd74a-159">SampleGrad\*</span></span></p>
<p><span data-ttu-id="dd74a-160">SampleLevel</span><span class="sxs-lookup"><span data-stu-id="dd74a-160">SampleLevel</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="dd74a-161">[RW]Texture1D</span><span class="sxs-lookup"><span data-stu-id="dd74a-161">[RW]Texture1D</span></span></p>
<p><span data-ttu-id="dd74a-162">[RW]Texture1DArray</span><span class="sxs-lookup"><span data-stu-id="dd74a-162">[RW]Texture1DArray</span></span></p>
<p><span data-ttu-id="dd74a-163">[RW]Texture2D</span><span class="sxs-lookup"><span data-stu-id="dd74a-163">[RW]Texture2D</span></span></p>
<p><span data-ttu-id="dd74a-164">Texture2DMS</span><span class="sxs-lookup"><span data-stu-id="dd74a-164">Texture2DMS</span></span></p>
<p><span data-ttu-id="dd74a-165">[RW]Texture2DArray</span><span class="sxs-lookup"><span data-stu-id="dd74a-165">[RW]Texture2DArray</span></span></p>
<p><span data-ttu-id="dd74a-166">Texture2DArrayMS</span><span class="sxs-lookup"><span data-stu-id="dd74a-166">Texture2DArrayMS</span></span></p>
<p><span data-ttu-id="dd74a-167">[RW]Texture3D</span><span class="sxs-lookup"><span data-stu-id="dd74a-167">[RW]Texture3D</span></span></p>
<p><span data-ttu-id="dd74a-168">[RW]Buffer</span><span class="sxs-lookup"><span data-stu-id="dd74a-168">[RW]Buffer</span></span></p>
<p><span data-ttu-id="dd74a-169">[RW]ByteAddressBuffer</span><span class="sxs-lookup"><span data-stu-id="dd74a-169">[RW]ByteAddressBuffer</span></span></p>
<p><span data-ttu-id="dd74a-170">[RW]StructuredBuffer</span><span class="sxs-lookup"><span data-stu-id="dd74a-170">[RW]StructuredBuffer</span></span></p></td>
<td align="left"><span data-ttu-id="dd74a-171">Load</span><span class="sxs-lookup"><span data-stu-id="dd74a-171">Load</span></span></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="dd74a-172"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="dd74a-172"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="dd74a-173">ストリーミング リソースへのパイプライン アクセス</span><span class="sxs-lookup"><span data-stu-id="dd74a-173">Pipeline access to streaming resources</span></span>](pipeline-access-to-streaming-resources.md)

 

 




