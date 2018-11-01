---
title: 浮動小数点の規則
description: Direct3D では、いくつかの浮動小数点表現がサポートされています。 すべての浮動小数点演算は、IEEE 754 32 ビット単精度浮動小数点ルールのサブセットの定義のもとで動作します。
ms.assetid: 3B0C95E2-1025-4F70-BF14-EBFF2BB53AFF
keywords:
- 浮動小数点の規則
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: bcfdb8f6258547ff210d80136a6113e04092aad2
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5887488"
---
# <a name="span-iddirect3dconceptsfloating-pointrulesspanfloating-point-rules"></a><span data-ttu-id="3d8cb-105"><span id="direct3dconcepts.floating-point_rules"></span>浮動小数点の規則</span><span class="sxs-lookup"><span data-stu-id="3d8cb-105"><span id="direct3dconcepts.floating-point_rules"></span>Floating-point rules</span></span>


<span data-ttu-id="3d8cb-106">Direct3D では、いくつかの浮動小数点表現がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-106">Direct3D supports several floating-point representations.</span></span> <span data-ttu-id="3d8cb-107">すべての浮動小数点演算は、IEEE 754 32 ビット単精度浮動小数点ルールのサブセットの定義のもとで動作します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-107">All floating-point computations operate under a defined subset of the IEEE 754 32-bit single precision floating-point rules.</span></span>

## <a name="span-idalpha32bitspanspan-idalpha32bitspan32-bit-floating-point-rules"></a><span data-ttu-id="3d8cb-108"><span id="alpha_32_bit"></span><span id="ALPHA_32_BIT"></span>32 ビット浮動小数点の規則</span><span class="sxs-lookup"><span data-stu-id="3d8cb-108"><span id="alpha_32_bit"></span><span id="ALPHA_32_BIT"></span>32-bit floating-point rules</span></span>


<span data-ttu-id="3d8cb-109">規則には、IEEE-754 に準拠する規則、および IEEE-754 と異なる規則の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-109">There are two sets of rules: those that conform to IEEE-754, and those that deviate from the standard.</span></span>

### <a name="span-idalpha754rulesspanspan-idalpha754rulesspanspan-idalpha754rulesspanhonored-ieee-754-rules"></a><span data-ttu-id="3d8cb-110"><span id="alpha_754_Rules"></span><span id="alpha_754_rules"></span><span id="ALPHA_754_RULES"></span>IEEE-754 に準拠する規則</span><span class="sxs-lookup"><span data-stu-id="3d8cb-110"><span id="alpha_754_Rules"></span><span id="alpha_754_rules"></span><span id="ALPHA_754_RULES"></span>Honored IEEE-754 rules</span></span>

<span data-ttu-id="3d8cb-111">これらの規則のいくつかは、IEEE-754 が複数の選択肢を提供している中の 1 つの選択肢の場合があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-111">Some of these rules are a single option where IEEE-754 offers choices.</span></span>

-   <span data-ttu-id="3d8cb-112">0 での除算は +/- INF になります。ただし、0/0 の結果は NaN になります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-112">Divide by 0 produces +/- INF, except 0/0 which results in NaN.</span></span>
-   <span data-ttu-id="3d8cb-113">(+/-) 0 の対数 (log) は -INF になります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-113">log of (+/-) 0 produces -INF.</span></span>  

    <span data-ttu-id="3d8cb-114">負の値 (-0 以外) の対数 (log) は NaN になります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-114">log of a negative value (other than -0) produces NaN.</span></span>
-   <span data-ttu-id="3d8cb-115">負の値の逆数平方根 (rsq) または平方根 (sqrt) は、NaN になります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-115">Reciprocal square root (rsq) or square root (sqrt) of a negative number produces NaN.</span></span>  

    <span data-ttu-id="3d8cb-116">-0 は例外です。sqrt(-0) は -0 になり、rsq(-0) は -INF になります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-116">The exception is -0; sqrt(-0) produces -0, and rsq(-0) produces -INF.</span></span>
-   <span data-ttu-id="3d8cb-117">INF - INF = NaN</span><span class="sxs-lookup"><span data-stu-id="3d8cb-117">INF - INF = NaN</span></span>
-   <span data-ttu-id="3d8cb-118">(+/-)INF / (+/-)INF = NaN</span><span class="sxs-lookup"><span data-stu-id="3d8cb-118">(+/-)INF / (+/-)INF = NaN</span></span>
-   <span data-ttu-id="3d8cb-119">(+/-)INF \* 0 = NaN</span><span class="sxs-lookup"><span data-stu-id="3d8cb-119">(+/-)INF \* 0 = NaN</span></span>
-   <span data-ttu-id="3d8cb-120">NaN (任意の演算子) 任意の値 = NaN</span><span class="sxs-lookup"><span data-stu-id="3d8cb-120">NaN (any OP) any-value = NaN</span></span>
-   <span data-ttu-id="3d8cb-121">比較演算の EQ、GT、GE、LT、および LE は、一方または両方のオペランドが NaN であるとき、**FALSE** を返します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-121">The comparisons EQ, GT, GE, LT, and LE, when either or both operands is NaN returns **FALSE**.</span></span>
-   <span data-ttu-id="3d8cb-122">比較演算では 0 の符号は無視されます (したがって +0 は -0 と等しくなります)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-122">Comparisons ignore the sign of 0 (so +0 equals -0).</span></span>
-   <span data-ttu-id="3d8cb-123">比較演算の NE は、一方または両方のオペランドが NaN であるとき、**TRUE** を返します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-123">The comparison NE, when either or both operands is NaN returns **TRUE**.</span></span>
-   <span data-ttu-id="3d8cb-124">NaN ではない任意の値を +/- INF と比較すると、正しい結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-124">Comparisons of any non-NaN value against +/- INF return the correct result.</span></span>

### <a name="span-idalpha754deviationsspanspan-idalpha754deviationsspanspan-idalpha754deviationsspandeviations-or-additional-requirements-from-ieee-754-rules"></a><span data-ttu-id="3d8cb-125"><span id="alpha_754_Deviations"></span><span id="alpha_754_deviations"></span><span id="ALPHA_754_DEVIATIONS"></span>IEEE-754 の規則と異なる規則または追加の要件</span><span class="sxs-lookup"><span data-stu-id="3d8cb-125"><span id="alpha_754_Deviations"></span><span id="alpha_754_deviations"></span><span id="ALPHA_754_DEVIATIONS"></span>Deviations or additional requirements from IEEE-754 rules</span></span>

-   <span data-ttu-id="3d8cb-126">IEEE-754 では、浮動小数点演算において、無限大精度の結果に最も近い、表現可能な値を求めることが要求されており、これは最も近い偶数への丸めと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-126">IEEE-754 requires floating-point operations to produce a result that is the nearest representable value to an infinitely-precise result, known as round-to-nearest-even.</span></span>

    <span data-ttu-id="3d8cb-127">Direct3D 11 以上では、IEEE-754 と同じ要件が定義されており、32 ビット浮動小数点演算では、無限大精度の結果から 0.5 ULP (unit-last-place) 以内の結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-127">Direct3D 11 and up define the same requirement as IEEE-754: 32-bit floating-point operations produce a result that is within 0.5 unit-last-place (ULP) of the infinitely-precise result.</span></span> <span data-ttu-id="3d8cb-128">たとえば、ハードウェアでは、最も近い偶数への丸めを実行せず、結果を 32 ビットで切り捨てることができます。これは、切り捨てた場合にも、誤差が 0.5 ULP 以内となるためです。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-128">This means that, for example, hardware is allowed to truncate results to 32-bit rather than perform round-to-nearest-even, as that would result in error of at most 0.5 ULP.</span></span> <span data-ttu-id="3d8cb-129">この規則は、追加、減算、乗算にのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-129">This rule applies only to addition, subtraction, and multiplication.</span></span>

    <span data-ttu-id="3d8cb-130">以前のバージョンの Direct3D では、IEEE-754 よりも緩やかな要件が定められており、32 ビット浮動小数点演算では、無限大精度の結果から 1 ULP (unit-last-place) 以内の結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-130">Earlier versions of Direct3D define a looser requirement than IEEE-754: 32-bit floating-point operations produce a result that is within one unit-last-place (1 ULP) of the infinitely-precise result.</span></span> <span data-ttu-id="3d8cb-131">たとえば、ハードウェアでは、最も近い偶数への丸めを実行せず、結果を 32 ビットで切り捨てることができます。これは、切り捨てた場合にも、誤差が 1 ULP 以内となるためです。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-131">This means that, for example, hardware is allowed to truncate results to 32-bit rather than perform round-to-nearest-even, as that would result in error of at most one ULP.</span></span>

-   <span data-ttu-id="3d8cb-132">浮動小数点の例外、ステータス ビットまたはトラップはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-132">There is no support for floating-point exceptions, status bits or traps.</span></span>
-   <span data-ttu-id="3d8cb-133">非正規化数は、任意の浮動小数点算術演算の入力および出力において、符号付きの 0 にフラッシュされます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-133">Denorms are flushed to sign-preserved zero on input and output of any floating-point mathematical operation.</span></span> <span data-ttu-id="3d8cb-134">データを操作しない I/O 処理やデータ移動処理には例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-134">Exceptions are made for any I/O or data movement operation that doesn't manipulate the data.</span></span>
-   <span data-ttu-id="3d8cb-135">Viewport MinDepth/MaxDepth、BorderColor 値などの浮動小数点値を含んだステートは、非正規化数の値として提供され、ハードウェアでの使用前にフラッシュされる場合と、フラッシュされない場合があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-135">States that contain floating-point values, such as Viewport MinDepth/MaxDepth or BorderColor values, may be provided as denorm values and may or may not be flushed before the hardware uses them.</span></span>
-   <span data-ttu-id="3d8cb-136">min または max 演算により、非正規化数が比較のためにフラッシュされますが、その結果は、フラッシュされた非正規化数となる場合とならない場合があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-136">Min or max operations flush denorms for comparison, but the result may or may not be denorm flushed.</span></span>
-   <span data-ttu-id="3d8cb-137">演算への NaN の入力は常に NaN が出力されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-137">NaN input to an operation always produces NaN on output.</span></span> <span data-ttu-id="3d8cb-138">ただし、同じ値を維持するために NaN の厳密なビット パターンは必要ありません (その演算が、データを一切変更しない、未変更のデータの移動命令ではない場合)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-138">But the exact bit pattern of the NaN is not required to stay the same (unless the operation is a raw move instruction - which doesn't alter data.)</span></span>
-   <span data-ttu-id="3d8cb-139">一方のオペランドのみが NaN である min または max 演算では、もう一方のオペランドが結果として返されます (前述の比較規則とは異なります)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-139">Min or max operations for which only one operand is NaN return the other operand as the result (contrary to comparison rules we looked at earlier).</span></span> <span data-ttu-id="3d8cb-140">これは IEEE 754R 規則です。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-140">This is an IEEE 754R rule.</span></span>

    <span data-ttu-id="3d8cb-141">浮動小数点の min および max 演算についての IEEE-754R 仕様では、min または max への入力のいずれかが quiet QNaN 値である場合、演算の結果はもう一方のパラメーターになります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-141">The IEEE-754R specification for floating point min and max operations states that if one of the inputs to min or max is a quiet QNaN value, the result of the operation is the other parameter.</span></span> <span data-ttu-id="3d8cb-142">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-142">For example:</span></span>

    ```ManagedCPlusPlus
    min(x,QNaN) == min(QNaN,x) == x (same for max)
    ```

    <span data-ttu-id="3d8cb-143">IEEE-754R 仕様のリビジョンでは、1つの入力が QNaN 値ではなく、"signaling" SNaN 値である場合、min と max で異なる動作を採用します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-143">A revision of the IEEE-754R specification adopted a different behavior for min and max when one input is a "signaling" SNaN value versus a QNaN value:</span></span>

    ```ManagedCPlusPlus
    min(x,SNaN) == min(SNaN,x) == QNaN (same for max)
     
    ```

    <span data-ttu-id="3d8cb-144">一般的に、Direct3D は、演算の標準 IEEE-754 および IEEE-754R に従っています。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-144">Generally, Direct3D follows the standards for arithmetic: IEEE-754 and IEEE-754R.</span></span> <span data-ttu-id="3d8cb-145">ただし、ここでは、規則と異なる部分があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-145">But in this case, we have a deviation.</span></span>

    <span data-ttu-id="3d8cb-146">Direct3D 10 以降の算術規則では、quiet NaN 値と signaling NaN 値 (QNaN と SNaN) を区別しません。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-146">The arithmetic rules in Direct3D 10 and later don't make any distinctions between quiet and signaling NaN values (QNaN versus SNaN).</span></span> <span data-ttu-id="3d8cb-147">すべての NaN 値は同じように処理されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-147">All NaN values are handled the same way.</span></span> <span data-ttu-id="3d8cb-148">min と max の場合、任意の NaN 値についての Direct3D の動作は、IEEE 754R の定義による QNaN の処理方法と似ています </span><span class="sxs-lookup"><span data-stu-id="3d8cb-148">In the case of min and max, the Direct3D behavior for any NaN value is like how QNaN is handled in the IEEE-754R definition.</span></span> <span data-ttu-id="3d8cb-149">(詳しく説明すると、両方の入力が NaN の場合、任意の NaN 値が返されます)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-149">(For completeness - if both inputs are NaN, any NaN value is returned.)</span></span>

-   <span data-ttu-id="3d8cb-150">別の IEEE 754R 規則として、min(-0,+0) == min(+0,-0) == -0、max(-0,+0) == max(+0,-0) == +0 があり、前述の符号付きの 0 に対する比較規則と対照的に、符号が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-150">Another IEEE 754R rule is that min(-0,+0) == min(+0,-0) == -0, and max(-0,+0) == max(+0,-0) == +0, which honors the sign, in contrast to the comparison rules for signed zero (as we saw earlier).</span></span> <span data-ttu-id="3d8cb-151">Direct3D では、この場合、IEEE 754R の動作を推奨していますが強制的なものではありません。符号を無視する比較を使用して、0 どうしを比較した結果がパラメーターの順序に依存してもかまいません。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-151">Direct3D recommends the IEEE 754R behavior here, but doesn't enforce it; it is permissible for the result of comparing zeros to be dependent on the order of parameters, using a comparison that ignores the signs.</span></span>
-   <span data-ttu-id="3d8cb-152">x\*1.0f は常に x となります (フラッシュされた非正規化数を除く)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-152">x\*1.0f always results in x (except denorm flushed).</span></span>
-   <span data-ttu-id="3d8cb-153">x/1.0f は常に x となります (フラッシュされた非正規化数を除く)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-153">x/1.0f always results in x (except denorm flushed).</span></span>
-   <span data-ttu-id="3d8cb-154">x +/- 0.0f は常に x となります (フラッシュされた非正規化数を除く)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-154">x +/- 0.0f always results in x (except denorm flushed).</span></span> <span data-ttu-id="3d8cb-155">ただし、-0 + 0 = +0 となります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-155">But -0 + 0 = +0.</span></span>
-   <span data-ttu-id="3d8cb-156">組み合わせ演算 (mad、dp3 など) では、非組み合わせ演算で展開した場合の最悪順序の評価よりも、正確性が劣ることはありません。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-156">Fused operations (such as mad, dp3) produce results that are no less accurate than the worst possible serial ordering of evaluation of the unfused expansion of the operation.</span></span> <span data-ttu-id="3d8cb-157">許容誤差に関する最悪順序の定義は、特定の組み合わせ演算についての固定の定義ではなく、入力の特定の値によって変わります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-157">The definition of the worst possible ordering, for the purpose of tolerance, is not a fixed definition for a given fused operation; it depends on the particular values of the inputs.</span></span> <span data-ttu-id="3d8cb-158">非組み合わせ演算の展開における個々のステップは、それぞれ 1 ULP の許容誤差が認められます (また、Direct3D が、1 ULP よりも緩い許容誤差で呼び出す命令には、より緩い許容誤差が認められます)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-158">The individual steps in the unfused expansion are each allowed 1 ULP tolerance (or for any instructions Direct3D calls out with a more lax tolerance than 1 ULP, the more lax tolerance is allowed).</span></span>
-   <span data-ttu-id="3d8cb-159">組み合わせ演算は、非組み合わせ演算と同じ NaN の規則に従います。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-159">Fused operations adhere to the same NaN rules as non-fused operations.</span></span>
-   <span data-ttu-id="3d8cb-160">sqrt と rcp には、1 ULP の許容誤差があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-160">sqrt and rcp have 1 ULP tolerance.</span></span> <span data-ttu-id="3d8cb-161">シェーダーの逆数および逆数平方根命令 [**rcp**](https://msdn.microsoft.com/library/windows/desktop/hh447205) と [**rsq**](https://msdn.microsoft.com/library/windows/desktop/hh447221) には、それぞれ独自の緩やかな精度要件があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-161">The shader reciprocal and reciprocal square-root instructions, [**rcp**](https://msdn.microsoft.com/library/windows/desktop/hh447205) and [**rsq**](https://msdn.microsoft.com/library/windows/desktop/hh447221), have their own separate relaxed precision requirement.</span></span>
-   <span data-ttu-id="3d8cb-162">乗算および除算はそれぞれ、32 ビット浮動小数点の精度レベル (乗算の場合は 0.5 ULP の精度、逆数の場合は 1.0 ULP の精度) で実行されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-162">Multiply and divide each operate at the 32-bit floating-point precision level (accuracy to 0.5 ULP for multiply, 1.0 ULP for reciprocal).</span></span> <span data-ttu-id="3d8cb-163">x/y が直接実装されている場合、結果は 2 段階の方法以上の精度になる必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-163">If x/y is implemented directly, results must be of greater or equal accuracy than a two-step method.</span></span>

## <a name="span-iddoubleprec64bitspanspan-iddoubleprec64bitspan64-bit-double-precision-floating-point-rules"></a><span data-ttu-id="3d8cb-164"><span id="double_prec_64_bit"></span><span id="DOUBLE_PREC_64_BIT"></span>64 ビット (倍精度) 浮動小数点の規則</span><span class="sxs-lookup"><span data-stu-id="3d8cb-164"><span id="double_prec_64_bit"></span><span id="DOUBLE_PREC_64_BIT"></span>64-bit (double precision) floating point rules</span></span>


<span data-ttu-id="3d8cb-165">ハードウェアやディスプレイ ドライバーは、必要に応じて、倍精度浮動小数点数をサポートします。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-165">Hardware and display drivers optionally support double-precision floating-point.</span></span> <span data-ttu-id="3d8cb-166">サポートを指定する場合、[**D3D11\_FEATURE\_DOUBLES**](https://msdn.microsoft.com/library/windows/desktop/ff476124#d3d11-feature-doubles) を指定して [**ID3D11Device::CheckFeatureSupport**](https://msdn.microsoft.com/library/windows/desktop/ff476497)を呼び出すと、ドライバーが [**D3D11\_FEATURE\_DATA\_DOUBLES**](https://msdn.microsoft.com/library/windows/desktop/ff476127) の **DoublePrecisionFloatShaderOps** を TRUE に設定します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-166">To indicate support, when you call [**ID3D11Device::CheckFeatureSupport**](https://msdn.microsoft.com/library/windows/desktop/ff476497) with [**D3D11\_FEATURE\_DOUBLES**](https://msdn.microsoft.com/library/windows/desktop/ff476124#d3d11-feature-doubles), the driver sets **DoublePrecisionFloatShaderOps** of [**D3D11\_FEATURE\_DATA\_DOUBLES**](https://msdn.microsoft.com/library/windows/desktop/ff476127) to TRUE.</span></span> <span data-ttu-id="3d8cb-167">この場合、ドライバーとハードウェアでは、すべての倍精度浮動小数点命令しをサポートしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-167">The driver and hardware must then support all double-precision floating-point instructions.</span></span>

<span data-ttu-id="3d8cb-168">倍精度命令は IEEE 754R の動作の要件に従っています。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-168">Double-precision instructions follow IEEE 754R behavior requirements.</span></span>

<span data-ttu-id="3d8cb-169">倍精度のデータ (0 へのフラッシュ動作がない) では、非正規化値の生成がサポートされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-169">Support for generation of denormalized values is required for double-precision data (no flush-to-zero behavior).</span></span> <span data-ttu-id="3d8cb-170">同様に、命令は非正規化データを符号付き 0 として読み取らずに、非正規化値を考慮します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-170">Likewise, instructions don't read denormalized data as a signed zero, they honor the denorm value.</span></span>

## <a name="span-idalpha16bitspanspan-idalpha16bitspan16-bit-floating-point-rules"></a><span data-ttu-id="3d8cb-171"><span id="alpha_16_bit"></span><span id="ALPHA_16_BIT"></span>16 ビット浮動小数点の規則</span><span class="sxs-lookup"><span data-stu-id="3d8cb-171"><span id="alpha_16_bit"></span><span id="ALPHA_16_BIT"></span>16-bit floating-point rules</span></span>


<span data-ttu-id="3d8cb-172">Direct3D では、浮動小数点値の 16 ビット表現もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-172">Direct3D also supports 16-bit representations of floating-point numbers.</span></span>

<span data-ttu-id="3d8cb-173">形式:</span><span class="sxs-lookup"><span data-stu-id="3d8cb-173">Format:</span></span>

-   <span data-ttu-id="3d8cb-174">MSB のビット位置に 1 つの符号ビット (s)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-174">1 sign bit (s)in the MSB bit position</span></span>
-   <span data-ttu-id="3d8cb-175">5 ビットのバイアス付き指数部 (e)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-175">5 bits of biased exponent (e)</span></span>
-   <span data-ttu-id="3d8cb-176">追加の隠しビットを持つ 10 ビットの小数部 (f)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-176">10 bits of fraction (f), with an additional hidden bit</span></span>

<span data-ttu-id="3d8cb-177">float16 の値 (v) は次の規則に従います。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-177">A float16 value (v) follows these rules:</span></span>

-   <span data-ttu-id="3d8cb-178">e == 31 かつ f != 0 の場合、v は s にかかわらず NaN</span><span class="sxs-lookup"><span data-stu-id="3d8cb-178">if e == 31 and f != 0, then v is NaN regardless of s</span></span>
-   <span data-ttu-id="3d8cb-179">e == 31 かつ f == 0 の場合、v = (-1)s\*無限大 (符号付き無限大)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-179">if e == 31 and f == 0, then v = (-1)s\*infinity (signed infinity)</span></span>
-   <span data-ttu-id="3d8cb-180">e が 0 と 31 の間である場合、v = (-1)s\*2(e-15)\*(1.f)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-180">if e is between 0 and 31, then v = (-1)s\*2(e-15)\*(1.f)</span></span>
-   <span data-ttu-id="3d8cb-181">e ==0 かつ f != 0 である場合、v = (-1)s\*2(e-14)\*(0.f) (非正規化数)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-181">if e == 0 and f != 0, then v = (-1)s\*2(e-14)\*(0.f) (denormalized numbers)</span></span>
-   <span data-ttu-id="3d8cb-182">e == 0 かつ f == 0 の場合、v = (-1)s\*0 (符号付きゼロ)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-182">if e == 0 and f == 0, then v = (-1)s\*0 (signed zero)</span></span>

<span data-ttu-id="3d8cb-183">32 ビット浮動小数点規則は、16 ビット浮動小数点値にも適用され、ビット レイアウトは前の記述に従って調整されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-183">32-bit floating-point rules also hold for 16-bit floating-point numbers, adjusted for the bit layout described earlier.</span></span> <span data-ttu-id="3d8cb-184">ただし、次のような例外があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-184">Exceptions to this include:</span></span>

-   <span data-ttu-id="3d8cb-185">精度: 16 ビット浮動小数点値に対する非組み合わせ演算では、無限大精度の結果に最も近い表現可能な値が結果として返されます (16 ビット値に適用された IEEE-754 に従う最も近い偶数への丸め)。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-185">Precision: Unfused operations on 16-bit floating-point numbers produce a result that is the nearest representable value to an infinitely-precise result (round to nearest even, per IEEE-754, applied to 16-bit values).</span></span> <span data-ttu-id="3d8cb-186">32 ビット浮動小数点規則は 1 ULP の許容誤差に従い、16 ビット浮動小数点規則は、非組み合わせ演算に対しては 0.5 ULP、組み合わせ演算に対しては 0.6 ULP に従います。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-186">32-bit floating-point rules adhere to 1 ULP tolerance, 16-bit floating-point rules adhere to 0.5 ULP for unfused operations, and 0.6 ULP for fused operations.</span></span>
-   <span data-ttu-id="3d8cb-187">16 ビット浮動小数点値は非正規化数を維持します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-187">16-bit floating-point numbers preserve denorms.</span></span>

## <a name="span-idalpha11bitspanspan-idalpha11bitspan11-bit-and-10-bit-floating-point-rules"></a><span data-ttu-id="3d8cb-188"><span id="alpha_11_bit"></span><span id="ALPHA_11_BIT"></span>11 ビットおよび 10 ビット浮動小数点の規則</span><span class="sxs-lookup"><span data-stu-id="3d8cb-188"><span id="alpha_11_bit"></span><span id="ALPHA_11_BIT"></span>11-bit and 10-bit floating-point rules</span></span>


<span data-ttu-id="3d8cb-189">Direct3D では、11 ビットおよび 10 ビット浮動小数点のフォーマットもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-189">Direct3D also supports 11-bit and 10-bit floating-point formats.</span></span>

<span data-ttu-id="3d8cb-190">形式:</span><span class="sxs-lookup"><span data-stu-id="3d8cb-190">Format:</span></span>

-   <span data-ttu-id="3d8cb-191">符号ビットなし</span><span class="sxs-lookup"><span data-stu-id="3d8cb-191">No sign bit</span></span>
-   <span data-ttu-id="3d8cb-192">5 ビットのバイアス付き指数部 (e)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-192">5 bits of biased exponent (e)</span></span>
-   <span data-ttu-id="3d8cb-193">11 ビット フォーマットの 6 ビットの小数部 (f)、10 ビット フォーマットの 5 ビットの小数部 (f)、および追加の隠しビット (両方の場合)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-193">6 bits of fraction (f) for an 11-bit format, 5 bits of fraction (f) for a 10-bit format, with an additional hidden bit in either case.</span></span>

<span data-ttu-id="3d8cb-194">float11/float10 の値 (v) は次の規則に従います。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-194">A float11/float10 value (v) follows the following rules:</span></span>

-   <span data-ttu-id="3d8cb-195">e == 31 かつ f != 0 の場合、v は NaN</span><span class="sxs-lookup"><span data-stu-id="3d8cb-195">if e == 31 and f != 0, then v is NaN</span></span>
-   <span data-ttu-id="3d8cb-196">e == 31 かつ f == 0 の場合、v = +無限大</span><span class="sxs-lookup"><span data-stu-id="3d8cb-196">if e == 31 and f == 0, then v = +infinity</span></span>
-   <span data-ttu-id="3d8cb-197">e が 0 と 31 の間である場合、v = 2(e-15)\*(1.f)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-197">if e is between 0 and 31, then v = 2(e-15)\*(1.f)</span></span>
-   <span data-ttu-id="3d8cb-198">e ==0 かつ f != 0 である場合、v = \*2(e-14)\*(0.f) (非正規化数)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-198">if e == 0 and f != 0, then v = \*2(e-14)\*(0.f) (denormalized numbers)</span></span>
-   <span data-ttu-id="3d8cb-199">e == 0 かつ f == 0 の場合、v = 0 (ゼロ)</span><span class="sxs-lookup"><span data-stu-id="3d8cb-199">if e == 0 and f == 0, then v = 0 (zero)</span></span>

<span data-ttu-id="3d8cb-200">32 ビット浮動小数点規則は、11 ビットおよび10 ビット浮動小数点値にも適用され、ビット レイアウトは前の記述に従って調整されます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-200">32-bit floating-point rules also hold for 11-bit and 10-bit floating-point numbers, adjusted for the bit layout described earlier.</span></span> <span data-ttu-id="3d8cb-201">次のような例外があります。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-201">Exceptions include:</span></span>

-   <span data-ttu-id="3d8cb-202">精度: 32 ビット浮動小数点規則は 0.5 ULP に従います。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-202">Precision: 32-bit floating-point rules adhere to 0.5 ULP.</span></span>
-   <span data-ttu-id="3d8cb-203">10/11 ビット浮動小数点値は非正規化数を維持します。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-203">10/11-bit floating-point numbers preserve denorms.</span></span>
-   <span data-ttu-id="3d8cb-204">0 未満の値となるすべての演算は、0 にクランプされます。</span><span class="sxs-lookup"><span data-stu-id="3d8cb-204">Any operation that would result in a number less than zero is clamped to zero.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="3d8cb-205"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="3d8cb-205"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="3d8cb-206">付録</span><span class="sxs-lookup"><span data-stu-id="3d8cb-206">Appendices</span></span>](appendix.md)

[<span data-ttu-id="3d8cb-207">リソース</span><span class="sxs-lookup"><span data-stu-id="3d8cb-207">Resources</span></span>](https://msdn.microsoft.com/library/windows/desktop/ff476894)

[<span data-ttu-id="3d8cb-208">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="3d8cb-208">Textures</span></span>](https://msdn.microsoft.com/library/windows/desktop/ff476902)

 

 




