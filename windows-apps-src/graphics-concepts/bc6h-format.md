---
title: BC6H 形式
description: BC6H 形式は、ソース データのハイ ダイナミック レンジ (HDR) 色空間をサポートするように設計されたテクスチャ圧縮形式です。
ms.assetid: 6781D967-9262-4EE7-B354-7A6D0EA0498E
keywords:
- BC6H 形式
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: be88f06cd5893f2f67697a54754826440bdf7d18
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7304453"
---
# <a name="bc6h-format"></a>BC6H 形式


BC6H 形式は、ソース データのハイ ダイナミック レンジ (HDR) 色空間をサポートするように設計されたテクスチャ圧縮形式です。

## <a name="span-idabout-bc6h-dxgi-format-bc6hspanspan-idabout-bc6h-dxgi-format-bc6hspanspan-idabout-bc6h-dxgi-format-bc6hspanabout-bc6hdxgiformatbc6h"></a><span id="About-BC6H-DXGI-FORMAT-BC6H"></span><span id="about-bc6h-dxgi-format-bc6h"></span><span id="ABOUT-BC6H-DXGI-FORMAT-BC6H"></span>BC6H/DXGI\_FORMAT\_BC6H について


BC6H 形式は、3 つの HDR カラー チャネルを使用した画像に、高品質の圧縮を提供します。各カラー チャネルに (16:16:16) の 16 ビット値を使用します。 アルファ チャネルはサポートされません。

BC6H は、次の DXGI \ _FORMAT 列挙値によって指定されます。

-   **DXGI\_FORMAT\_BC6H\_TYPELESS**。
-   **DXGI\_FORMAT\_BC6H\_UF16**。 この BC6H 形式は、16 ビット浮動小数点カラー チャネル値の符号ビットを使用しません。
-   **DXGI\_FORMAT\_BC6H\_SF16**。 この BC6H 形式は、16 ビット浮動小数点カラー チャネル値の符号ビットを使用します。

**注:**  16 ビット浮動小数点形式のカラー チャネルは、多くの場合と呼ばれます「半」浮動小数点形式です。 この形式には、次のビット レイアウトがあります。
|                       |                                                 |
|-----------------------|-------------------------------------------------|
| UF16 (符号なし浮動小数点) | 5 指数ビット + 11 仮数ビット              |
| SF16 (符号付き浮動小数点)   | 1 符号ビット + 5 指数ビット + 10 仮数ビット |

 

 

BC6H 形式は、[Texture2D](https://msdn.microsoft.com/library/windows/desktop/bb205277) (配列を含む)、Texture3D、または TextureCube (配列を含む) のテクスチャ リソースに使用できます。 同様に、この形式は、これらのリソースに関連付けられた任意のミップマップ サーフェスに適用されます。

BC6H は、16バイト (128 ビット) の固定ブロックサイズと 4 × 4 テクセルの固定タイル サイズを使用します。 以前の BC 形式と同様に、サポートされるタイル サイズ (4 x 4) よりも大きなテクスチャ画像は、複数のブロックを使用して圧縮されます。 このアドレス指定 ID は、3 次元画像とミップマップ、キューブマップ、テクスチャ配列にも適用されます。 すべての画像タイルは同じ形式でなければなりません。

BC6H 形式の注意事項:

-   BC6H は浮動小数点非正規化数をサポートしていますが、INF (無限大) と NaN (非数) をサポートしていません。 ただし、BC6H の符号付きモード (DXGI \ _FORMAT \ _BC6H \ _SF16) は例外で、-INF (負の無限大) をサポートします。 この -INF のサポートは、形式そのものの結果に過ぎず、この形式のエンコーダーでは特にサポートされていません。 一般に、エンコーダーが INF (正または負) または NaN 入力データを検出する場合には、圧縮前にそのデータを最大許容非 INF 表現値に変換したり、NaN を 0 にマッピングする必要があります。
-   BC6H はアルファ チャネルをサポートしません。
-   BC6H デコーダーは、テクスチャ フィルタリングを実行する前に、圧縮解除を実行します。
-   BC6H の圧縮解除はビットアキュレートである必要があります。ハードウェアは、このドキュメントで説明されているデコーダーと同じ結果を返す必要があります。

## <a name="span-idbc6h-implementationspanspan-idbc6h-implementationspanspan-idbc6h-implementationspanbc6h-implementation"></a><span id="BC6H-implementation"></span><span id="bc6h-implementation"></span><span id="BC6H-IMPLEMENTATION"></span>BC6H の実装


BC6H ブロックは、モードビット、圧縮エンドポイント、圧縮インデックス、パーティション インデックス (オプション) で構成されています。 この形式は、14 の異なるモードを指定します。

エンドポイント カラーは RGB トリプレットとして保存されます。 BC6H は、いくつかの定義されたカラー エンドポイントを横切る近似線上に色のパレットを定義します。 また、モードによっては、タイルを 2 つの領域に分割したり、1 つの領域として扱うこともできます。2 つの領域を持つタイルには、各領域にカラー エンドポイントが別々に設定されます。 BC6H はテクセルごとに 1 つのパレット インデックスを格納します。

2 つの領域の場合、可能なパーティションは 32 です。

## <a name="span-iddecoding-the-bc6h-formatspanspan-iddecoding-the-bc6h-formatspanspan-iddecoding-the-bc6h-formatspandecoding-the-bc6h-format"></a><span id="Decoding-the-BC6H-format"></span><span id="decoding-the-bc6h-format"></span><span id="DECODING-THE-BC6H-FORMAT"></span>BC6H 形式のデコード


次の擬似コードは、16 バイトの BC6H ブロックを指定して(x, y) のピクセルを圧縮解除する手順の概要を示しています。

``` syntax
decompress_bc6h(x, y, block)
{
    mode = extract_mode(block);
    endpoints;
    index;
    
    if(mode.type == ONE)
    {
        endpoints = extract_compressed_endpoints(mode, block);
        index = extract_index_ONE(x, y, block);
    }
    else //mode.type == TWO
    {
        partition = extract_partition(block);
        region = get_region(partition, x, y);
        endpoints = extract_compressed_endpoints(mode, region, block);
        index = extract_index_TWO(x, y, partition, block);
    }
    
    unquantize(endpoints);
    color = interpolate(index, endpoints);
    finish_unquantize(color);
}
```

次の表に、BC6H ブロックで使用可能な 14 の形式のビット数と値を示します。

| モード | パーティション インデックス | パーティション | カラー エンドポイント                  | モード ビット      |
|------|-------------------|-----------|----------------------------------|----------------|
| 1    | 46 ビット           | 5 ビット    | 75 ビット (10.555, 10.555, 10.555) | 2 ビット (00)    |
| 2    | 46 ビット           | 5 ビット    | 75 ビット (7666, 7666, 7666)       | 2 ビット (01)    |
| 3    | 46 ビット           | 5 ビット    | 72 ビット (11.555, 11.444, 11.444) | 5 ビット (00010) |
| 4    | 46 ビット           | 5 ビット    | 72 ビット (11.444, 11.555, 11.444) | 5 ビット (00110) |
| 5    | 46 ビット           | 5 ビット    | 72 ビット (11.444, 11.444, 11.555) | 5 ビット (01010) |
| 6    | 46 ビット           | 5 ビット    | 72 ビット (9555, 9555, 9555)       | 5 ビット (01110) |
| 7    | 46 ビット           | 5 ビット    | 72 ビット (8666, 8555, 8555)       | 5 ビット (10010) |
| 8    | 46 ビット           | 5 ビット    | 72 ビット (8555, 8666, 8555)       | 5 ビット (10110) |
| 9    | 46 ビット           | 5 ビット    | 72 ビット (8555, 8555, 8666)       | 5 ビット (11010) |
| 10   | 46 ビット           | 5 ビット    | 72 ビット (6666, 6666, 6666)       | 5 ビット (11110) |
| 11   | 63 ビット           | 0 ビット    | 60 ビット (10.10, 10.10, 10.10)    | 5 ビット (00011) |
| 12   | 63 ビット           | 0 ビット    | 60 ビット (11.9, 11.9, 11.9)       | 5 ビット (00111) |
| 13   | 63 ビット           | 0 ビット    | 60 ビット (12.8, 12.8, 12.8)       | 5 ビット (01011) |
| 14   | 63 ビット           | 0 ビット    | 60 ビット (16.4, 16.4, 16.4)       | 5 ビット (01111) |

 

この表の各形式は、モード ビットによって一意に識別できます。 最初の 10 個のモードは 2 領域のタイルに使用され、モード ビット フィールドは 2 または 5 ビット長とすることができます。 これらのブロックには、圧縮されたカラー エンドポイント (72 または 75 ビット)、パーティション (5ビット)、およびパーティション インデックス (46ビット) のフィールドもあります。

圧縮されたカラー エンドポイントの場合、上記の表の値は、保存された RGB エンドポイントの精度と、各カラー値に使用されるビット数を示します。 たとえば、モード 3 では、カラー エンドポイントの精度レベル 11 と、赤、青、緑の色の変換されたエンドポイントのデルタ値を保存するために使用するビット数 (それぞれ 5、4、4) を指定します。 モード 10 はデルタ圧縮を使用せず、4 つのカラー エンドポイントをすべて明示的に保存します。

最後の 4 つのブロック モードは 1 領域タイルに使用され、モード フィールドは 5 ビットです。 これらのブロックには、エンドポイント (60 ビット) と圧縮インデックス (63 ビット) のフィールドがあります。 モード 11 ではモード 10 と同様にデルタ圧縮を使用せず、その代わりに両方のカラー エンドポイントを明示的に保存します。

モード 10011、10111、11011、および11111 (示されていません) は予約されています。 これらをエンコーダーで使用しないでください。 これらのモードの1 つを指定してハードウェアにブロックが渡された場合、その結果の圧縮解除されたブロックは、アルファ チャネルを除くすべてのチャネルにゼロを含む必要があります。

BC6H では、アルファ チャネルはモードに関係なく常に 1.0 を返す必要があります。

### <a name="span-idbc6h-partition-setspanspan-idbc6h-partition-setspanspan-idbc6h-partition-setspanbc6h-partition-set"></a><span id="BC6H-partition-set"></span><span id="bc6h-partition-set"></span><span id="BC6H-PARTITION-SET"></span>BC6H パーティション セット

2 領域のタイルでは 32 のパーティション セットが使用可能で、それらは下の表で定義されています。 各 4 x 4 ブロックは単一の形状を表しています。

![BC6H パーティション セットの表](images/bc6h-partition-sets.png)

このパーティション・セットの表では、太字の下線付きの項目は、サブセット 1 の修正インデックスの位置です (1 つ少ないビットで指定されます)。 パーティションは常にインデックス 0 がサブセット 0 になるように配置されるため、サブセット 0 の修正インデックスは常にインデックス 0 です。 パーティションの順序は、左上から右下、つまり左から右へ、上から下へとなります。

## <a name="span-idbc6h-compressed-endpoint-formatspanspan-idbc6h-compressed-endpoint-formatspanspan-idbc6h-compressed-endpoint-formatspanbc6h-compressed-endpoint-format"></a><span id="BC6H-compressed-endpoint-format"></span><span id="bc6h-compressed-endpoint-format"></span><span id="BC6H-COMPRESSED-ENDPOINT-FORMAT"></span>BC6H 圧縮エンドポイント形式


![BC6H 圧縮エンドポイント形式のビット フィールド](images/bc6h-headers-med.png)

この表は、圧縮エンドポイントのビット フィールドを、エンドポイント形式の関数として示しています。各列がエンコードを示し、各行がビット フィールドを示しています。 この方法では、2 領域タイルで 82 ビット、1 領域タイルで 65 ビットを使用します。 たとえば、上記で、1 領域 \[16 4\] のエンコーディング (特に右端の列) の最初の 5 ビットは m\[4:0\] となります。次の 10 ビットは rw\[9:0\] であり、同様に最後の 6 ビット は bw\[10:15\] です。

上記の表のフィールド名は、次のように定義されています。

| フィールド | 変数          |
|-------|-------------------|
| m     | mode              |
| d     | shape index       |
| rw    | endpt\[0\].A\[0\] |
| rx    | endpt\[0\].B\[0\] |
| ry    | endpt\[1\].A\[0\] |
| rz    | endpt\[1\].B\[0\] |
| gw    | endpt\[0\].A\[1\] |
| gx    | endpt\[0\].B\[1\] |
| gy    | endpt\[1\].A\[1\] |
| gz    | endpt\[1\].B\[1\] |
| bw    | endpt\[0\].A\[2\] |
| bx    | endpt\[0\].B\[2\] |
| by    | endpt\[1\].A\[2\] |
| bz    | endpt\[1\].B\[2\] |

 

Endpt\[i\] (i は 0 または 1) は、それぞれ 0 番目または 1 番目のエンドポイントを示します。
## <a name="span-idsign-extension-for-endpoint-valuesspanspan-idsign-extension-for-endpoint-valuesspanspan-idsign-extension-for-endpoint-valuesspansign-extension-for-endpoint-values"></a><span id="Sign-extension-for-endpoint-values"></span><span id="sign-extension-for-endpoint-values"></span><span id="SIGN-EXTENSION-FOR-ENDPOINT-VALUES"></span>エンドポイント値の符号拡張


2 領域タイルでは、符号拡張が可能な 4 つのエンドポイント値があります。 Endpt\[0\].A は、形式が符号付き形式の場合にのみ符号付きとなります。他のエンドポイントは、エンドポイントが変換された場合、または形式が符号付き形式である場合にのみ、符号付きとなります。 以下のコードは、2 領域のエンドポイント値の符号を拡張するアルゴリズムを示しています。

``` syntax
static void sign_extend_two_region(Pattern &p, IntEndpts endpts[NREGIONS_TWO])
{
    for (int i=0; i<NCHANNELS; ++i)
    {
      if (BC6H::FORMAT == SIGNED_F16)
        endpts[0].A[i] = SIGN_EXTEND(endpts[0].A[i], p.chan[i].prec);
      if (p.transformed || BC6H::FORMAT == SIGNED_F16)
      {
        endpts[0].B[i] = SIGN_EXTEND(endpts[0].B[i], p.chan[i].delta[0]);
        endpts[1].A[i] = SIGN_EXTEND(endpts[1].A[i], p.chan[i].delta[1]);
        endpts[1].B[i] = SIGN_EXTEND(endpts[1].B[i], p.chan[i].delta[2]);
      }
    }
}
```

1 領域のタイルでは、動作は同じですが、endpt\[1\] のみが削除されます。

``` syntax
static void sign_extend_one_region(Pattern &p, IntEndpts endpts[NREGIONS_ONE])
{
    for (int i=0; i<NCHANNELS; ++i)
    {
    if (BC6H::FORMAT == SIGNED_F16)
        endpts[0].A[i] = SIGN_EXTEND(endpts[0].A[i], p.chan[i].prec);
    if (p.transformed || BC6H::FORMAT == SIGNED_F16) 
        endpts[0].B[i] = SIGN_EXTEND(endpts[0].B[i], p.chan[i].delta[0]);
    }
}
```

## <a name="span-idtransform-inversion-for-endpoint-valuesspanspan-idtransform-inversion-for-endpoint-valuesspanspan-idtransform-inversion-for-endpoint-valuesspantransform-inversion-for-endpoint-values"></a><span id="Transform-inversion-for-endpoint-values"></span><span id="transform-inversion-for-endpoint-values"></span><span id="TRANSFORM-INVERSION-FOR-ENDPOINT-VALUES"></span>エンドポイント値の変換の反転


2 領域タイルでは、変換は差分エンコーディングの逆数を適用し、endpt\[0\].A の基本値を他の 3 つのエントリに加算し、合計 9 回の加算演算を行います。 下の画像では、基本値は「A0」として表され、最も高い浮動小数点精度を持ちます。 「A1」「B0」「B1」は全てアンカー値から算出されたデルタであり、これらのデルタ値は、より低い精度で表されます。 (A0 は endpt\[0\].A に、B0 は endpt\[0\].Bに、A1 は endpt\[1\].A に、B1 は endpt\[1\].B に対応します。)

![変換の反転のエンドポイント値の計算](images/bc6h-transform-inverse.png)

1 領域のタイルでは、デルタ オフセットは 1 つだけであるため、3 つの加算演算のみとなります。

圧縮解除プログラムは、反転の結果が endpt\[0\].a の精度をオーバーフローしないようにする必要があります。 オーバーフローの場合には、反転から生じる値は、同じビット数内でラップする必要があります。 A0 の精度が「p」ビットの場合、変換アルゴリズムは次のようになります。

`B0 = (B0 + A0) & ((1 << p) - 1)`

符号付き形式の場合、デルタ計算の結果も符号拡張される必要があります。 符号拡張演算が両方の符号を拡張することを考慮する場合には、0 が正、1 が負であり、0 の符号拡張がこのクランプの処理を行います。 同様に、このクランプ後に、値 1 (負) のみ符号拡張する必要があります。

## <a name="span-idunquantization-of-color-endpointsspanspan-idunquantization-of-color-endpointsspanspan-idunquantization-of-color-endpointsspanunquantization-of-color-endpoints"></a><span id="Unquantization-of-color-endpoints"></span><span id="unquantization-of-color-endpoints"></span><span id="UNQUANTIZATION-OF-COLOR-ENDPOINTS"></span>カラー エンドポイントの非量子化


圧縮されていないエンドポイントでは、次のステップはカラー エンドポイントの最初の非量子化を実行することです。 これには次の 3 つのステップがあります。

-   カラー パレットの非量子化
-   パレットの補間
-   非量子化の最終化

非量子化プロセスを 2 つの部分 (補間前のカラー パレットの非量子化と、補間後の最終の非量子化) に分離することにより、パレット補間前の完全非量子化プロセスと比較して必要な乗算演算の数が減少します。

下のコードは、元の 16 ビット カラー値の見積もりを取得し、提供されたウェイト値を使用して 6 つの追加のカラー値をパレットに追加するプロセスを示しています。 同じ操作が各チャネルで実行されます。

``` syntax
int aWeight3[] = {0, 9, 18, 27, 37, 46, 55, 64};
int aWeight4[] = {0, 4, 9, 13, 17, 21, 26, 30, 34, 38, 43, 47, 51, 55, 60, 64};

// c1, c2: endpoints of a component
void generate_palette_unquantized(UINT8 uNumIndices, int c1, int c2, int prec, UINT16 palette[NINDICES])
{
    int* aWeights;
    if(uNumIndices == 8)
        aWeights = aWeight3;
    else  // uNumIndices == 16
        aWeights = aWeight4;

    int a = unquantize(c1, prec); 
    int b = unquantize(c2, prec);

    // interpolate
    for(int i = 0; i < uNumIndices; ++i)
        palette[i] = finish_unquantize((a * (64 - aWeights[i]) + b * aWeights[i] + 32) >> 6);
}
```

次のコード サンプルでは、補間のプロセスを示しています。次のようなことがわかります。

-   **非量子化**関数 (下記) のカラー値の有効な範囲は -32768 〜 65535 であるため、インターポレーターは 17 ビット符号付き算術演算を使って実装されています。
-   補間後、値は **finish\_unquantize** 関数 (このセクションの 3 番目のサンプルで説明しています) に渡され、最終的なスケーリングが適用されます。
-   すべてのハードウェアの圧縮解除プログラムは、これらの関数でビットアキュレートの結果を返す必要があります。

``` syntax
int unquantize(int comp, int uBitsPerComp)
{
    int unq, s = 0;
    switch(BC6H::FORMAT)
    {
    case UNSIGNED_F16:
        if(uBitsPerComp >= 15)
            unq = comp;
        else if(comp == 0)
            unq = 0;
        else if(comp == ((1 << uBitsPerComp) - 1))
            unq = 0xFFFF;
        else
            unq = ((comp << 16) + 0x8000) >> uBitsPerComp;
        break;

    case SIGNED_F16:
        if(uBitsPerComp >= 16)
            unq = comp;
        else
        {
            if(comp < 0)
            {
                s = 1;
                comp = -comp;
            }

            if(comp == 0)
                unq = 0;
            else if(comp >= ((1 << (uBitsPerComp - 1)) - 1))
                unq = 0x7FFF;
            else
                unq = ((comp << 15) + 0x4000) >> (uBitsPerComp-1);

            if(s)
                unq = -unq;
        }
        break;
    }
    return unq;
}
```

**finish\_unquantize** はパレット補間後に呼び出されます。 **Unquantize** 関数は、符号付きの場合は 31/32、符号なしの場合は 31/64 で、スケーリングを延期します。 この動作は、パレット補間の完了後の最終値を有効な半範囲 (-0x7BFF〜0x7BFF) にして、必要な乗算の数を減らすために必要です。 **finish\_unquantize**は最終的なスケーリングを適用して、**unsigned short** 値を返し、それが **half** に再解釈されます。

``` syntax
unsigned short finish_unquantize(int comp)
{
    if(BC6H::FORMAT == UNSIGNED_F16)
    {
        comp = (comp * 31) >> 6;                                         // scale the magnitude by 31/64
        return (unsigned short) comp;
    }
    else // (BC6H::FORMAT == SIGNED_F16)
    {
        comp = (comp < 0) ? -(((-comp) * 31) >> 5) : (comp * 31) >> 5;   // scale the magnitude by 31/32
        int s = 0;
        if(comp < 0)
        {
            s = 0x8000;
            comp = -comp;
        }
        return (unsigned short) (s | comp);
    }
}
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャのブロック圧縮](texture-block-compression.md)

 

 




