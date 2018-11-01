---
title: アルファ チャネルを含むテクスチャ
description: 複雑な透明度を表現するテクスチャ マップには 2 つのエンコード方法があります。
ms.assetid: 768A774A-4F21-4DDE-B863-14211DA92926
keywords:
- アルファ チャネルを含むテクスチャ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: eef41642d371f3a8be451c2687eee007608c3b2e
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5880075"
---
# <a name="textures-with-alpha-channels"></a>アルファ チャネルを含むテクスチャ


複雑な透明度を表現するテクスチャ マップには 2 つのエンコード方法があります。 いずれの場合も、既に説明した 64 ビットのブロックの前に、透明度を記述したブロックを配置します。 透明度は、1 ピクセルあたり 4 ビットの 4 x 4 ビットマップ (明示的エンコード)、またはこれよりも少ないビット数およびカラー エンコードで使用されるものに類似した線形補間で表現されます。

透明度ブロックと色ブロックは、次の表に示すように配置されます。

| ワード アドレス | 64 ビットのブロック                      |
|--------------|-----------------------------------|
| 3:0          | 透明度ブロック                |
| 7:4          | 既に説明した 64 ビットのブロック |

 

## <a name="span-idexplicit-texture-encodingspanspan-idexplicit-texture-encodingspanspan-idexplicit-texture-encodingspanexplicit-texture-encoding"></a><span id="Explicit-Texture-Encoding"></span><span id="explicit-texture-encoding"></span><span id="EXPLICIT-TEXTURE-ENCODING"></span>明示的なテクスチャ エンコード


明示的なテクスチャ エンコード (BC2 形式) の場合、透明度を記述するテクセルのアルファ成分は、テクセルあたり 4 ビットの 4 x 4 のビットマップでエンコードされます。 これらの 4 ビットは、ディザリングなどのさまざまな手法によるか、アルファ データの 4 つの最上位ビットを使用して取得できます。 ただし、これらは生成されると、どのような補間もされずに、そのままの状態で使用されます。

次の図に、64 ビットの透明度ブロックを示します。

![64 ビットの透明度ブロックの図](images/colors4.png)

**注:**  Direct3D の圧縮方法で、4 つの最上位ビットを使用します。

 

次の表に、16 ビット ワードごとにメモリ内のアルファ情報のレイアウト方法を示します。

ワード 0 のレイアウト:

| ビット          | アルファ      |
|---------------|------------|
| 3:0 (LSB\*)   | \[0\]\[0\] |
| 7:4           | \[0\]\[1\] |
| 11:8          | \[0\]\[2\] |
| 15:12 (MSB\*) | \[0\]\[3\] |

 

\*最下位ビット、最上位ビット (MSB)

ワード 1 のレイアウト:

| ビット        | アルファ      |
|-------------|------------|
| 3:0 (LSB)   | \[1\]\[0\] |
| 7:4         | \[1\]\[1\] |
| 11:8        | \[1\]\[2\] |
| 15:12 (MSB) | \[1\]\[3\] |

 

ワード 2 のレイアウト:

| ビット        | アルファ      |
|-------------|------------|
| 3:0 (LSB)   | \[2\]\[0\] |
| 7:4         | \[2\]\[1\] |
| 11:8        | \[2\]\[2\] |
| 15:12 (MSB) | \[2\]\[3\] |

 

ワード 3 のレイアウト:

| ビット        | アルファ      |
|-------------|------------|
| 3:0 (LSB)   | \[3\]\[0\] |
| 7:4         | \[3\]\[1\] |
| 11:8        | \[3\]\[2\] |
| 15:12 (MSB) | \[3\]\[3\] |

 

BC1 でテクセルが透明かどうかを判断するために使われる色比較は、この形式では使われません。 色比較を行わない場合、色データは常に 4 カラー モードであるものとして処理されると仮定されます。

## <a name="span-idthree-bit-linear-alpha-interpolationspanspan-idthree-bit-linear-alpha-interpolationspanspan-idthree-bit-linear-alpha-interpolationspanthree-bit-linear-alpha-interpolation"></a><span id="Three-Bit-Linear-Alpha-Interpolation"></span><span id="three-bit-linear-alpha-interpolation"></span><span id="THREE-BIT-LINEAR-ALPHA-INTERPOLATION"></span>3 ビット線形アルファ補間


BC3 形式での透明度のエンコーディングは、色に使用される線形エンコーディングと同様の概念に基づいています。 2 つの 8 ビット アルファ値、およびピクセルあたり 3 ビットの 4 x 4 ビットマップが、ブロックの最初の 8 バイトに格納されます。 代表的なアルファ値を使用して、中間アルファ値が補間されます。 追加の情報は、2 つのアルファ値を格納する方法で利用できます。 alpha\_0 が alpha\_1 より大きい場合は、6 つの中間アルファ値が補間によって作成されます。 それ以外の場合、4 つの中間アルファ値が指定したアルファの極値の間で補間されます。 その他 2 つの暗黙のアルファ値は、0 (完全に透明) と 255 (完全に不透明) です。

次のコード例に、このアルゴリズムを示します。

```
// 8-alpha or 6-alpha block?    
if (alpha_0 > alpha_1) {    
    // 8-alpha block:  derive the other six alphas.    
    // Bit code 000 = alpha_0, 001 = alpha_1, others are interpolated.
    alpha_2 = (6 * alpha_0 + 1 * alpha_1 + 3) / 7;    // bit code 010
    alpha_3 = (5 * alpha_0 + 2 * alpha_1 + 3) / 7;    // bit code 011
    alpha_4 = (4 * alpha_0 + 3 * alpha_1 + 3) / 7;    // bit code 100
    alpha_5 = (3 * alpha_0 + 4 * alpha_1 + 3) / 7;    // bit code 101
    alpha_6 = (2 * alpha_0 + 5 * alpha_1 + 3) / 7;    // bit code 110
    alpha_7 = (1 * alpha_0 + 6 * alpha_1 + 3) / 7;    // bit code 111  
}    
else {  
    // 6-alpha block.    
    // Bit code 000 = alpha_0, 001 = alpha_1, others are interpolated.
    alpha_2 = (4 * alpha_0 + 1 * alpha_1 + 2) / 5;    // Bit code 010
    alpha_3 = (3 * alpha_0 + 2 * alpha_1 + 2) / 5;    // Bit code 011
    alpha_4 = (2 * alpha_0 + 3 * alpha_1 + 2) / 5;    // Bit code 100
    alpha_5 = (1 * alpha_0 + 4 * alpha_1 + 2) / 5;    // Bit code 101
    alpha_6 = 0;                                      // Bit code 110
    alpha_7 = 255;                                    // Bit code 111
}
```

アルファ ブロックのメモリ レイアウトは次のとおりです。

| バイト | アルファ                                                          |
|------|----------------------------------------------------------------|
| 0    | Alpha\_0                                                       |
| 1    | Alpha\_1                                                       |
| 2    | \[0\]\[2\] (2 つの MSB)、\[0\]\[1\]、\[0\]\[0\]                    |
| 3    | \[1\]\[1\] (1 つの MSB)、\[1\]\[0\]、\[0\]\[3\]、\[0\]\[2\] (1 つの LSB) |
| 4    | \[1\]\[3\]、\[1\]\[2\]、\[1\]\[1\] (2 つの LSB)                    |
| 5    | \[2\]\[2\] (2 つの MSB)、\[2\]\[1\]、\[2\]\[0\]                    |
| 6    | \[3\]\[1\] (1 つの MSB)、\[3\]\[0\]、\[2\]\[3\]、\[2\]\[2\] (1 つの LSB) |
| 7    | \[3\]\[3\]、\[3\]\[2\]、\[3\]\[1\] (2 つの LSB)                    |

 

BC1 でテクセルが透明かどうかを判断するために使われる色比較は、これらの形式では使われません。 色比較を行わない場合、色データは常に 4 カラー モードであるものとして処理されると仮定されます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[圧縮テクスチャ リソース](compressed-texture-resources.md)

 

 




