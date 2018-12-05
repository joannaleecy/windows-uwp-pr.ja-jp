---
title: 浮動小数点の規則
description: Direct3D では、いくつかの浮動小数点表現がサポートされています。 すべての浮動小数点演算は、IEEE 754 32 ビット単精度浮動小数点ルールのサブセットの定義のもとで動作します。
ms.assetid: 3B0C95E2-1025-4F70-BF14-EBFF2BB53AFF
keywords:
- 浮動小数点の規則
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 4de5ba146c8241598527dd268d604fcc9bb97d6d
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8710562"
---
# <a name="span-iddirect3dconceptsfloating-pointrulesspanfloating-point-rules"></a><span id="direct3dconcepts.floating-point_rules"></span>浮動小数点の規則


Direct3D では、いくつかの浮動小数点表現がサポートされています。 すべての浮動小数点演算は、IEEE 754 32 ビット単精度浮動小数点ルールのサブセットの定義のもとで動作します。

## <a name="span-idalpha32bitspanspan-idalpha32bitspan32-bit-floating-point-rules"></a><span id="alpha_32_bit"></span><span id="ALPHA_32_BIT"></span>32 ビット浮動小数点の規則


規則には、IEEE-754 に準拠する規則、および IEEE-754 と異なる規則の 2 種類があります。

### <a name="span-idalpha754rulesspanspan-idalpha754rulesspanspan-idalpha754rulesspanhonored-ieee-754-rules"></a><span id="alpha_754_Rules"></span><span id="alpha_754_rules"></span><span id="ALPHA_754_RULES"></span>IEEE-754 に準拠する規則

これらの規則のいくつかは、IEEE-754 が複数の選択肢を提供している中の 1 つの選択肢の場合があります。

-   0 での除算は +/- INF になります。ただし、0/0 の結果は NaN になります。
-   (+/-) 0 の対数 (log) は -INF になります。  

    負の値 (-0 以外) の対数 (log) は NaN になります。
-   負の値の逆数平方根 (rsq) または平方根 (sqrt) は、NaN になります。  

    -0 は例外です。sqrt(-0) は -0 になり、rsq(-0) は -INF になります。
-   INF - INF = NaN
-   (+/-)INF / (+/-)INF = NaN
-   (+/-)INF \* 0 = NaN
-   NaN (任意の演算子) 任意の値 = NaN
-   比較演算の EQ、GT、GE、LT、および LE は、一方または両方のオペランドが NaN であるとき、**FALSE** を返します。
-   比較演算では 0 の符号は無視されます (したがって +0 は -0 と等しくなります)。
-   比較演算の NE は、一方または両方のオペランドが NaN であるとき、**TRUE** を返します。
-   NaN ではない任意の値を +/- INF と比較すると、正しい結果が返されます。

### <a name="span-idalpha754deviationsspanspan-idalpha754deviationsspanspan-idalpha754deviationsspandeviations-or-additional-requirements-from-ieee-754-rules"></a><span id="alpha_754_Deviations"></span><span id="alpha_754_deviations"></span><span id="ALPHA_754_DEVIATIONS"></span>IEEE-754 の規則と異なる規則または追加の要件

-   IEEE-754 では、浮動小数点演算において、無限大精度の結果に最も近い、表現可能な値を求めることが要求されており、これは最も近い偶数への丸めと呼ばれます。

    Direct3D 11 以上では、IEEE-754 と同じ要件が定義されており、32 ビット浮動小数点演算では、無限大精度の結果から 0.5 ULP (unit-last-place) 以内の結果が返されます。 たとえば、ハードウェアでは、最も近い偶数への丸めを実行せず、結果を 32 ビットで切り捨てることができます。これは、切り捨てた場合にも、誤差が 0.5 ULP 以内となるためです。 この規則は、追加、減算、乗算にのみ適用されます。

    以前のバージョンの Direct3D では、IEEE-754 よりも緩やかな要件が定められており、32 ビット浮動小数点演算では、無限大精度の結果から 1 ULP (unit-last-place) 以内の結果が返されます。 たとえば、ハードウェアでは、最も近い偶数への丸めを実行せず、結果を 32 ビットで切り捨てることができます。これは、切り捨てた場合にも、誤差が 1 ULP 以内となるためです。

-   浮動小数点の例外、ステータス ビットまたはトラップはサポートされていません。
-   非正規化数は、任意の浮動小数点算術演算の入力および出力において、符号付きの 0 にフラッシュされます。 データを操作しない I/O 処理やデータ移動処理には例外が発生します。
-   Viewport MinDepth/MaxDepth、BorderColor 値などの浮動小数点値を含んだステートは、非正規化数の値として提供され、ハードウェアでの使用前にフラッシュされる場合と、フラッシュされない場合があります。
-   min または max 演算により、非正規化数が比較のためにフラッシュされますが、その結果は、フラッシュされた非正規化数となる場合とならない場合があります。
-   演算への NaN の入力は常に NaN が出力されます。 ただし、同じ値を維持するために NaN の厳密なビット パターンは必要ありません (その演算が、データを一切変更しない、未変更のデータの移動命令ではない場合)。
-   一方のオペランドのみが NaN である min または max 演算では、もう一方のオペランドが結果として返されます (前述の比較規則とは異なります)。 これは IEEE 754R 規則です。

    浮動小数点の min および max 演算についての IEEE-754R 仕様では、min または max への入力のいずれかが quiet QNaN 値である場合、演算の結果はもう一方のパラメーターになります。 次に例を示します。

    ```ManagedCPlusPlus
    min(x,QNaN) == min(QNaN,x) == x (same for max)
    ```

    IEEE-754R 仕様のリビジョンでは、1つの入力が QNaN 値ではなく、"signaling" SNaN 値である場合、min と max で異なる動作を採用します。

    ```ManagedCPlusPlus
    min(x,SNaN) == min(SNaN,x) == QNaN (same for max)
     
    ```

    一般的に、Direct3D は、演算の標準 IEEE-754 および IEEE-754R に従っています。 ただし、ここでは、規則と異なる部分があります。

    Direct3D 10 以降の算術規則では、quiet NaN 値と signaling NaN 値 (QNaN と SNaN) を区別しません。 すべての NaN 値は同じように処理されます。 min と max の場合、任意の NaN 値についての Direct3D の動作は、IEEE 754R の定義による QNaN の処理方法と似ています  (詳しく説明すると、両方の入力が NaN の場合、任意の NaN 値が返されます)。

-   別の IEEE 754R 規則として、min(-0,+0) == min(+0,-0) == -0、max(-0,+0) == max(+0,-0) == +0 があり、前述の符号付きの 0 に対する比較規則と対照的に、符号が考慮されます。 Direct3D では、この場合、IEEE 754R の動作を推奨していますが強制的なものではありません。符号を無視する比較を使用して、0 どうしを比較した結果がパラメーターの順序に依存してもかまいません。
-   x\*1.0f は常に x となります (フラッシュされた非正規化数を除く)。
-   x/1.0f は常に x となります (フラッシュされた非正規化数を除く)。
-   x +/- 0.0f は常に x となります (フラッシュされた非正規化数を除く)。 ただし、-0 + 0 = +0 となります。
-   組み合わせ演算 (mad、dp3 など) では、非組み合わせ演算で展開した場合の最悪順序の評価よりも、正確性が劣ることはありません。 許容誤差に関する最悪順序の定義は、特定の組み合わせ演算についての固定の定義ではなく、入力の特定の値によって変わります。 非組み合わせ演算の展開における個々のステップは、それぞれ 1 ULP の許容誤差が認められます (また、Direct3D が、1 ULP よりも緩い許容誤差で呼び出す命令には、より緩い許容誤差が認められます)。
-   組み合わせ演算は、非組み合わせ演算と同じ NaN の規則に従います。
-   sqrt と rcp には、1 ULP の許容誤差があります。 シェーダーの逆数および逆数平方根命令 [**rcp**](https://msdn.microsoft.com/library/windows/desktop/hh447205) と [**rsq**](https://msdn.microsoft.com/library/windows/desktop/hh447221) には、それぞれ独自の緩やかな精度要件があります。
-   乗算および除算はそれぞれ、32 ビット浮動小数点の精度レベル (乗算の場合は 0.5 ULP の精度、逆数の場合は 1.0 ULP の精度) で実行されます。 x/y が直接実装されている場合、結果は 2 段階の方法以上の精度になる必要があります。

## <a name="span-iddoubleprec64bitspanspan-iddoubleprec64bitspan64-bit-double-precision-floating-point-rules"></a><span id="double_prec_64_bit"></span><span id="DOUBLE_PREC_64_BIT"></span>64 ビット (倍精度) 浮動小数点の規則


ハードウェアやディスプレイ ドライバーは、必要に応じて、倍精度浮動小数点数をサポートします。 サポートを指定する場合、[**D3D11\_FEATURE\_DOUBLES**](https://msdn.microsoft.com/library/windows/desktop/ff476124#d3d11-feature-doubles) を指定して [**ID3D11Device::CheckFeatureSupport**](https://msdn.microsoft.com/library/windows/desktop/ff476497)を呼び出すと、ドライバーが [**D3D11\_FEATURE\_DATA\_DOUBLES**](https://msdn.microsoft.com/library/windows/desktop/ff476127) の **DoublePrecisionFloatShaderOps** を TRUE に設定します。 この場合、ドライバーとハードウェアでは、すべての倍精度浮動小数点命令しをサポートしている必要があります。

倍精度命令は IEEE 754R の動作の要件に従っています。

倍精度のデータ (0 へのフラッシュ動作がない) では、非正規化値の生成がサポートされている必要があります。 同様に、命令は非正規化データを符号付き 0 として読み取らずに、非正規化値を考慮します。

## <a name="span-idalpha16bitspanspan-idalpha16bitspan16-bit-floating-point-rules"></a><span id="alpha_16_bit"></span><span id="ALPHA_16_BIT"></span>16 ビット浮動小数点の規則


Direct3D では、浮動小数点値の 16 ビット表現もサポートされています。

形式:

-   MSB のビット位置に 1 つの符号ビット (s)
-   5 ビットのバイアス付き指数部 (e)
-   追加の隠しビットを持つ 10 ビットの小数部 (f)

float16 の値 (v) は次の規則に従います。

-   e == 31 かつ f != 0 の場合、v は s にかかわらず NaN
-   e == 31 かつ f == 0 の場合、v = (-1)s\*無限大 (符号付き無限大)
-   e が 0 と 31 の間である場合、v = (-1)s\*2(e-15)\*(1.f)
-   e ==0 かつ f != 0 である場合、v = (-1)s\*2(e-14)\*(0.f) (非正規化数)
-   e == 0 かつ f == 0 の場合、v = (-1)s\*0 (符号付きゼロ)

32 ビット浮動小数点規則は、16 ビット浮動小数点値にも適用され、ビット レイアウトは前の記述に従って調整されます。 ただし、次のような例外があります。

-   精度: 16 ビット浮動小数点値に対する非組み合わせ演算では、無限大精度の結果に最も近い表現可能な値が結果として返されます (16 ビット値に適用された IEEE-754 に従う最も近い偶数への丸め)。 32 ビット浮動小数点規則は 1 ULP の許容誤差に従い、16 ビット浮動小数点規則は、非組み合わせ演算に対しては 0.5 ULP、組み合わせ演算に対しては 0.6 ULP に従います。
-   16 ビット浮動小数点値は非正規化数を維持します。

## <a name="span-idalpha11bitspanspan-idalpha11bitspan11-bit-and-10-bit-floating-point-rules"></a><span id="alpha_11_bit"></span><span id="ALPHA_11_BIT"></span>11 ビットおよび 10 ビット浮動小数点の規則


Direct3D では、11 ビットおよび 10 ビット浮動小数点のフォーマットもサポートされています。

形式:

-   符号ビットなし
-   5 ビットのバイアス付き指数部 (e)
-   11 ビット フォーマットの 6 ビットの小数部 (f)、10 ビット フォーマットの 5 ビットの小数部 (f)、および追加の隠しビット (両方の場合)

float11/float10 の値 (v) は次の規則に従います。

-   e == 31 かつ f != 0 の場合、v は NaN
-   e == 31 かつ f == 0 の場合、v = +無限大
-   e が 0 と 31 の間である場合、v = 2(e-15)\*(1.f)
-   e ==0 かつ f != 0 である場合、v = \*2(e-14)\*(0.f) (非正規化数)
-   e == 0 かつ f == 0 の場合、v = 0 (ゼロ)

32 ビット浮動小数点規則は、11 ビットおよび10 ビット浮動小数点値にも適用され、ビット レイアウトは前の記述に従って調整されます。 次のような例外があります。

-   精度: 32 ビット浮動小数点規則は 0.5 ULP に従います。
-   10/11 ビット浮動小数点値は非正規化数を維持します。
-   0 未満の値となるすべての演算は、0 にクランプされます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[付録](appendix.md)

[リソース](https://msdn.microsoft.com/library/windows/desktop/ff476894)

[テクスチャ](https://msdn.microsoft.com/library/windows/desktop/ff476902)

 

 




