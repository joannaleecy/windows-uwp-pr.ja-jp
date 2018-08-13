---
title: データ型の変換
description: 次のセクションでは、Direct3D がデータ型の間の変換を処理する方法について説明します。
ms.assetid: B50AB8DE-CAED-465B-B18C-81F3A984B8AC
keywords:
- データ型の変換
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1c7f68984274cbdb3adec0a88a0c99f7a7342380
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1045115"
---
# <a name="data-type-conversion"></a>データ型の変換


次のセクションでは、Direct3D がデータ型の間の変換を処理する方法について説明します。

## <a name="span-iddatatypeterminologyspanspan-iddatatypeterminologyspanspan-iddatatypeterminologyspandata-type-terminology"></a><span id="Data_Type_Terminology"></span><span id="data_type_terminology"></span><span id="DATA_TYPE_TERMINOLOGY"></span>データ型に関する用語


次に示す用語は、さまざまな形式の変換の特性を説明するために後で使用されます。

| 用語  | 説明                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
|-------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SNORM | 符号付き正規化整数。n ビットの 2 の補数をとり、最大値は 1.0f で (たとえば、5 ビット値 01111 は 1.0f にマップされます)、最小値は -1.0f です (たとえば、5 ビット値 10000 は -1.0f にマップされます)。 さらに、2 番目に小さい数値も -1.0f にマップされます (たとえば、5 ビット値 10001 は -1.0f にマップされます)。 したがって、-1.0f には 2 つの整数表現があります。 0.0f の整数表現は 1 つで、1.0f の整数表現も 1 つです。 その結果、-1.0f ～ 0.0f の範囲の均等間隔の浮動小数点値に対する整数表現のセットと、同様に 0.0f ～ 1.0f の範囲の数値表現の補集合が存在することになります。 |
| UNORM | 符号なし正規化整数。n ビットの数値では、すべての桁が 0 の場合は 0.0f、すべての桁が 1 の場合は 1.0f を表します。 0.0f ～ 1.0f の均等な間隔の一連の浮動小数点値が表されます。 たとえば、2 ビットの UNORM は、0.0f、1/3、2/3、および 1.0f を表します。                                                                                                                                                                                                                                                                                                                                                                                                                                |
| SINT  | 符号付き整数。 2 の補数の整数です。 たとえば、3 ビットの SINT は整数値の -4、-3、-2、-1、0、1、2、3 を表します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| UINT  | 符号なし整数。 たとえば、3 ビットの UINT は整数値の 0、1、2、3、4、5、6、7 を表します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| FLOAT | Direct3D で定義された任意の表現の浮動小数点値。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| SRGB  | n ビットの数値ですべての桁が 0 の場合は 0.0f、すべての桁が 1 の場合は 1.0f を表す点で UNORM と同様です。 ただし、UNORM とは異なり、SRGB では、すべての桁が 0 である値からすべての桁が 1 である値までの符号なし整数エンコードのシーケンスは、0.0f ～ 1.0f の数値の浮動小数点で表した値に対して非線形数列を表します。 大まかにいえば、この非線形の数列である SRGB をカラーのシーケンスとして表示すると、平均的な視聴者には、平均的な表示条件下および平均的なディスプレイ上で、輝度レベルの直線的な変化に見えます。 詳細については、IEC (国際電気標準会議) の SRGB カラー規格である IEC 61996-2-1 を参照してください。                |

 

前述の各用語は、通常、"形式名修飾子" として使用されます。これらは、メモリ内のデータのレイアウト方法と、メモリからまたはシェーダーなどのパイプライン ユニットからのトランスポート パス (潜在的にフィルター処理を含む) で実行される変換の両方を表します。

## <a name="span-idfloatingpointconversionspanspan-idfloatingpointconversionspanspan-idfloatingpointconversionspanfloating-point-conversion"></a><span id="Floating_Point_Conversion"></span><span id="floating_point_conversion"></span><span id="FLOATING_POINT_CONVERSION"></span>浮動小数点の変換


浮動小数点以外の表現との変換を含め、さまざまな表現間で浮動小数点の変換が発生する場合、必ず以下の規則を適用します。

### <a name="span-idconververtingfromahigherrangerepresentationtoalowerrangerepresentationspanspan-idconververtingfromahigherrangerepresentationtoalowerrangerepresentationspanspan-idconververtingfromahigherrangerepresentationtoalowerrangerepresentationspanconververting-from-a-higher-range-representation-to-a-lower-range-representation"></a><span id="Conververting_from_a_higher_range_representation_to_a_lower_range_representation"></span><span id="conververting_from_a_higher_range_representation_to_a_lower_range_representation"></span><span id="CONVERVERTING_FROM_A_HIGHER_RANGE_REPRESENTATION_TO_A_LOWER_RANGE_REPRESENTATION"></span>範囲が広い表現から範囲が狭い表現への変換

-   別の浮動小数点形式への変換時には、ゼロへの丸めを使用します。 変換先が整数または固定小数点形式の場合、最も近い偶数への丸めを使用します。ただし、FLOAT から SNORM、FLOAT から UNORM、FLOAT から SRGB の各変換で使用する最も近い値への丸めなどのように、別の丸め動作を使用した変換が明示されている場合は除きます。 その他の例外としてシェーダー命令の ftoi と ftou があります。この場合は、ゼロへの丸めを使用します。 最後に、テクスチャーのサンプラーとラスタライザーで使用する浮動小数点から固定小数点への変換では、無限に理想的な精度に対する指定の許容誤差があります。この許容誤差は、ULP (Unit-Last-Place) で表します。
-   変換元の値のうち、変換先のダイナミック レンジより大きいものは (たとえば、 大きな 32 ビットの浮動小数点値を 16 ビットの浮動小数点型 RenderTarget に書き込む場合)、表現可能な最大の値 (適切な符号付き) に変換されます。ただし、前述のゼロへの丸めにより、符号付きの無限大にはなりません。
-   範囲が広い形式にある NaN を範囲の狭い形式に変換する場合、範囲が狭い変換先の形式に該当の NaN 表現があればその表現に変換されます。 範囲が狭い変換先の形式に NaN 表現がない場合、結果は 0 になります。
-   範囲が広い形式にある INF を範囲が狭い形式に変換する場合、範囲が狭い変換先の形式に該当の INF があればその INF に変換されます。 範囲が狭い変換先の形式に INF 表現がない場合、表現可能な最大の値に変換されます。 変換先の形式で利用可能な場合、符号は保持されます。
-   範囲が広い形式にある非正規化数を範囲が狭い形式に変換する場合、その変換先の形式に非正規化表現があり、その表現への変換が可能であれば、該当の非正規化表現に変換されます。それ以外の場合、結果は 0 になります。 変換先の形式で利用可能な場合、符号ビットは保持されます。

### <a name="span-idconvertingfromalowerrangerepresentationtoahigherrangerepresentationspanspan-idconvertingfromalowerrangerepresentationtoahigherrangerepresentationspanspan-idconvertingfromalowerrangerepresentationtoahigherrangerepresentationspanconverting-from-a-lower-range-representation-to-a-higher-range-representation"></a><span id="Converting_from_a_lower_range_representation_to_a_higher_range_representation"></span><span id="converting_from_a_lower_range_representation_to_a_higher_range_representation"></span><span id="CONVERTING_FROM_A_LOWER_RANGE_REPRESENTATION_TO_A_HIGHER_RANGE_REPRESENTATION"></span>範囲が狭い表現から範囲が広い表現への変換

-   範囲が狭い形式にある NaN を範囲の広い形式に変換する場合、範囲が広い変換先の形式で利用可能であれば該当する NaN 表現に変換されます。 範囲が広い形式に NaN 表現がない場合は、0 に変換されます。
-   範囲が狭い形式にある INF を範囲の広い形式に変換する場合、範囲が広い変換先の形式で利用可能であれば該当する INF 表現に変換されます。 範囲が広い形式に INF 表現がない場合、表現可能な最大の値 (その形式の MAX\_FLOAT) に変換されます。 変換先の形式で利用可能な場合、符号は保持されます。
-   範囲が狭い形式にある非正規化数を範囲が広い形式に変換する場合、変換先の形式の正規化表現に変換可能であれば、その表現に変換されます。変換が不可能な場合、範囲が広い形式に該当の非正規化表現があれば、その表現に変換されます。 範囲が広い形式に非正規化表現がなければ、0 に変換されます。 変換先の形式で利用可能な場合、符号は保持されます。 32 ビット浮動小数点型の数値は、非正規化表現のない形式として扱います (32 ビット浮動小数点型の演算における非正規化数を、符号が保持された 0 にフラッシュする必要があるからです)。

## <a name="span-idintegerconversionspanspan-idintegerconversionspanspan-idintegerconversionspaninteger-conversion"></a><span id="Integer_Conversion"></span><span id="integer_conversion"></span><span id="INTEGER_CONVERSION"></span>整数の変換


次の表で、前述のさまざまな表現から別の表現への変換について説明します。 ここでは、Direct3D で実際に発生する変換のみを示します。

整数の場合、特に指定のない限り、整数表現への変換および整数表現から浮動小数点表現への変換はすべて正確に行われます。

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">変換元のデータ型</th>
<th align="left">変換先のデータ型</th>
<th align="left">変換の規則</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">SNORM</td>
<td align="left">FLOAT</td>
<td align="left"><p>符号付きの -1.0f ～ 1.0f の範囲を表す n ビットの整数値から浮動小数点型への変換は次のとおりです。</p>
<ul>
<li>負数側の最小値が -1.0f にマップされます。 たとえば、5 ビット値 10000 は -1.0f にマップされます。</li>
<li>その他の値はすべて浮動小数点型 (これを c とします) に変換され、結果は c * (1.0f / (2⁽ⁿ⁻¹⁾-1)) となります。 たとえば、5 ビット値 10001 は -15.0f に変換された後、15.0f で除算され、-1.0f となります。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">FLOAT</td>
<td align="left">SNORM</td>
<td align="left"><p>浮動小数点値から符号付きの -1.0f ～ 1.0f の範囲を表す n ビットの整数値への変換は次のとおりです。</p>
<ul>
<li>変換元の値を c とします。</li>
<li>c が NaN の場合、結果は 0 です。</li>
<li>c &gt; 1.0f の場合 (INF を含む)、1.0f にクランプされます。</li>
<li>c &lt; -1.0f の場合 (-INF を含む)、-1.0f にクランプされます。</li>
<li>次のように浮動小数点のスケールから整数のスケールに変換します。c = c * (2ⁿ⁻¹-1)。</li>
<li>次のように整数に変換します。
<ul>
<li>c &gt;= 0 ならば c = c + 0.5f とし、それ以外の場合は c = c - 0.5f とします。</li>
<li>小数部を除外し、残りの浮動小数点値 (整数値) を整数に直接変換します。</li>
</ul></li>
</ul>
<p>この変換では、整数側で D3D<em>xx</em>_FLOAT32_TO_INTEGER_TOLERANCE_IN_Unit-Last-Place ULP の誤差が許容されます。 つまり、浮動小数点スケールから整数スケールへの変換後、変換先の表現可能な形式の値に対して D3D<em>xx</em>_FLOAT32_TO_INTEGER_TOLERANCE_IN_ULP ULP 以内にある値はすべてその変換先の値にマップできます。 また、データ可換性の要件により、変換は範囲全体にわたって非減少であること、およびすべての出力値が達成可能であることが保証されます。 ここで示した定数で、<em>xx</em> は Direct3D のバージョン (10、11、12 など) に置き換える必要があります。</p></td>
</tr>
<tr class="odd">
<td align="left">UNORM</td>
<td align="left">FLOAT</td>
<td align="left"><p>変換元の n ビット値は浮動小数点型 (0.0f、1.0f、2.0f など) に変換された後、(2ⁿ-1) で除算されます。</p></td>
</tr>
<tr class="even">
<td align="left">FLOAT</td>
<td align="left">UNORM</td>
<td align="left"><p>変換元の値を c とします。</p>
<ul>
<li>c が NaN の場合、結果は 0 です。</li>
<li>c &gt; 1.0f の場合 (INF を含む)、1.0f にクランプされます。</li>
<li>c &lt; 0.0f の場合 (-INF を含む)、0.0f にクランプされます。</li>
<li>次のように浮動小数点のスケールから整数のスケールに変換します。c = c * (2ⁿ-1)。</li>
<li>整数値に変換します。
<ul>
<li>c = c + 0.5f。</li>
<li>小数部を除外し、残りの浮動小数点値 (整数値) を整数に直接変換します。</li>
</ul></li>
</ul>
<p>この変換では、整数側で D3D<em>xx</em>_FLOAT32_TO_INTEGER_TOLERANCE_IN_ULP ULP の誤差が許容されます。 つまり、浮動小数点スケールから整数スケールへの変換後、変換先の表現可能な形式の値に対して D3D<em>xx</em>_FLOAT32_TO_INTEGER_TOLERANCE_IN_ULP ULP 以内にある値はすべてその変換先の値にマップできます。 また、データ可換性の要件により、変換は範囲全体にわたって非減少であること、およびすべての出力値が達成可能であることが保証されます。</p></td>
</tr>
<tr class="odd">
<td align="left">SRGB</td>
<td align="left">FLOAT</td>
<td align="left"><p>SRGB から FLOAT への最適な変換は次のとおりです。</p>
<ul>
<li>変換元の n ビット値を浮動小数点型 (0.0f、1.0f、2.0f など) に変換します。これを c とします。</li>
<li>c = c * (1.0f / (2ⁿ-1))</li>
<li>c &lt; = D3D<em>xx</em>_SRGB_TO_FLOAT_THRESHOLD の場合、結果は c / D3D<em>xx</em>_SRGB_TO_FLOAT_DENOMINATOR_1 です。それ以外の場合、結果は ((c + D3D<em>xx</em>_SRGB_TO_FLOAT_OFFSET)/D3D<em>xx</em>_SRGB_TO_FLOAT_DENOMINATOR_2)D3D<em>xx</em>_SRGB_TO_FLOAT_EXPONENT です。</li>
</ul>
<p>この変換では、SRGB 側で D3D<em>xx</em>_SRGB_TO_FLOAT_TOLERANCE_IN_ULP ULP の誤差が許容されます。</p></td>
</tr>
<tr class="even">
<td align="left">FLOAT</td>
<td align="left">SRGB</td>
<td align="left"><p>FLOAT から SRGB への最適な変換は次のとおりです。</p>
<p>変換先の SRGB カラー成分を n ビットと仮定します。</p>
<ul>
<li>変換元の値を c とします。</li>
<li>c が NaN の場合、結果は 0 です。</li>
<li>c &gt; 1.0f の場合 (INF を含む)、1.0f にクランプされます。</li>
<li>c &lt; 0.0f の場合 (-INF を含む)、0.0f にクランプされます。</li>
<li>c &lt;= D3D<em>xx</em>_FLOAT_TO_SRGB_THRESHOLD の場合、c = D3D<em>xx</em>_FLOAT_TO_SRGB_SCALE_1 * c です。それ以外の場合、c = D3D<em>xx</em>_FLOAT_TO_SRGB_SCALE_2 * c(D3D<em>xx</em>_FLOAT_TO_SRGB_EXPONENT_NUMERATOR/D3D<em>xx</em>_FLOAT_TO_SRGB_EXPONENT_DENOMINATOR) - D3D<em>xx</em>_FLOAT_TO_SRGB_OFFSET です。</li>
<li>次のように浮動小数点のスケールから整数のスケールに変換します。c = c * (2ⁿ-1)。</li>
<li>整数値に変換します。
<ul>
<li>c = c + 0.5f。</li>
<li>小数部を除外し、残りの浮動小数点値 (整数値) を整数に直接変換します。</li>
</ul></li>
</ul>
<p>この変換では、整数側で D3D<em>xx</em>_FLOAT32_TO_INTEGER_TOLERANCE_IN_ULP ULP の誤差が許容されます。 つまり、浮動小数点スケールから整数スケールへの変換後、変換先の表現可能な形式の値に対して D3D<em>xx</em>_FLOAT32_TO_INTEGER_TOLERANCE_IN_ULP ULP 以内にある値はすべてその変換先の値にマップできます。 また、データ可換性の要件により、変換は範囲全体にわたって非減少であること、およびすべての出力値が達成可能であることが保証されます。</p></td>
</tr>
<tr class="odd">
<td align="left">SINT</td>
<td align="left">よりビット数が多い SINT</td>
<td align="left"><p>SINT からそれよりもビット数が多い SINT に変換する場合、変換元の数値の最上位ビット (MSB) が変換先の形式の追加ビットに &quot;符号拡張&quot; されます。</p></td>
</tr>
<tr class="even">
<td align="left">UINT</td>
<td align="left">よりビット数が多い SINT</td>
<td align="left"><p>UINT からそれよりもビット数が多い SINT に変換する場合、その数値が変換先の形式の最下位ビット (LSB) 側にコピーされ、余った MSB 側ビットが 0 で埋められます。</p></td>
</tr>
<tr class="odd">
<td align="left">SINT</td>
<td align="left">よりビット数が多い UINT</td>
<td align="left"><p>SINT からそれよりもビット数が多い UINTに変換する場合、負の値は 0 にクランプされます。 それ以外の数値は変換先の形式の LSB 側にコピーされ、余った MSB 側が 0 で埋められます。</p></td>
</tr>
<tr class="even">
<td align="left">UINT</td>
<td align="left">よりビット数が多い UINT</td>
<td align="left"><p>UINT からそれよりもビット数が多い UINT に変換する場合、その数値が変換先の形式の LSB 側にコピーされ、余った MSB 側が 0 で埋められます。</p></td>
</tr>
<tr class="odd">
<td align="left">SINT または UINT</td>
<td align="left">ビット数が同じか少ない SINT または UINT</td>
<td align="left"><p>SINT または UINT からビット数が同じか少ない SINT または UINT に変換 (符号の有無の変更を伴うことも可) する場合、変換元の値が変換先の形式の範囲に単純にクランプされます。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idfixedpointintegerconversionspanspan-idfixedpointintegerconversionspanspan-idfixedpointintegerconversionspanfixed-point-integer-conversion"></a><span id="Fixed_Point_Integer_Conversion"></span><span id="fixed_point_integer_conversion"></span><span id="FIXED_POINT_INTEGER_CONVERSION"></span>固定小数点整数の変換


固定小数点整数とは単に、暗黙の小数点が固定位置にある一定のビット長の整数です。

よく使用される "整数" データ型は、数値の末尾に小数点を置いた、固定小数点整数の特殊なケースです。

固定小数点数は i.f という形式で表現します。i は整数部ビット数、f は小数部ビット数を表します。 たとえば、16.8 は 16 ビットの整数の後ろに 8 ビットの小数が続くことを示します。 整数部は、少なくともここでの定義では、2 の補数として格納されます (符号なし整数についても同様です)。 小数部は符号なしの形式で格納されます。 小数部は、負数側の最小値から、互いに最も近い 2 つの整数値の間で必ず正の小数となります。

固定小数点数に対する加算演算および減算演算は、単純に通常の整数演算で実行します。暗黙の小数点の位置は考慮されません。 16.8 の固定小数点数に対する 1 の加算は、この数値の最下位端から 8 桁は小数部であるため、256 を加算することを意味します。 乗算などのその他の演算も、固定小数点への影響を考慮したうえで、単純に整数演算によって実行できます。 たとえば、2 つの 16.8 の整数を整数乗算すると、結果は 32.16 になります。

Direct3D では、次の 2 つの状況で固定小数点整数表現を使用します。

-   ラスタライザーでのクリップ後の頂点位置は固定小数点にスナップされ、RenderTarget 領域全体で精度分布が均一になります。 面のカリングをはじめ、多くのラスタライザー処理は固定小数点のスナップ位置で発生しますが、属性のインターポレーター セットアップなどの処理では、固定小数点のスナップ位置から浮動小数点に逆変換した位置を使用します。
-   フィルターのタップ位置/重みの選択では、サンプリング処理のテクスチャー座標が (テクスチャー サイズに合わせてスケーリングされた後) 固定小数点にスナップされ、テクスチャー領域全体で精度分布が均一になります。 重み値は、実際のフィルタリング演算を実行する前に浮動小数点に逆変換します。

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">変換元のデータ型</th>
<th align="left">変換先のデータ型</th>
<th align="left">変換の規則</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">FLOAT</td>
<td align="left">固定小数点整数</td>
<td align="left"><p>浮動小数点型の数値 n を固定小数点整数 i.f に変換する一般的な手順は次のとおりです。ここで、i は整数部ビット数 (符号付き)、f は小数部ビット数です。</p>
<ul>
<li>FixedMin = -2⁽ⁱ⁻¹⁾ を計算します。</li>
<li>FixedMax = 2⁽ⁱ⁻¹⁾ - 2<sup>(-f)</sup> を計算します。</li>
<li>n が NaN の場合、結果は 0 です。n が +Inf の場合の結果は FixedMax*2<sup>f</sup> で、n が -Inf の場合の結果は FixedMin*2<sup>f</sup> です。</li>
<li>n &gt;= FixedMax の場合の結果は Fixedmax*2<sup>f</sup> で、n &lt;= FixedMin の場合の結果は FixedMin*2<sup>f</sup> です。</li>
<li>それ以外の場合は、n*2<sup>f</sup> を計算して整数に変換します。</li>
</ul>
<p>実装では、上の最後の手順で得られた整数と無限大精度値 n*2<sup>f</sup> との比較で、D3D<em>xx</em>_FLOAT32_TO_INTEGER_TOLERANCE_IN_ULP ULP の誤差が許容されます。</p></td>
</tr>
<tr class="even">
<td align="left">固定小数点整数</td>
<td align="left">FLOAT</td>
<td align="left"><p>浮動小数点型に変換する固定小数点表現があり、その合計ビット数は 24 ビット以下で、うち小数部は 23 ビット以下であるとします。 特定の固定小数点数 fxp を i.f の形式とします (i ビットの整数、f ビットの小数)。 浮動小数点型への変換は次に示す疑似コードのようになります。</p>
<p>結果を浮動 = (フロート) (fxp &gt; &gt; f) +//整数を抽出します。</p>
((フロート) (fxp &amp; (2<sup>f</sup> - 1))/(<sup>f</sup>2))。分数を抽出します。</td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[付録](appendix.md)

 

 




