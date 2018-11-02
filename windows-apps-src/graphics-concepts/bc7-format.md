---
title: BC7 形式
description: BC7 形式は、RGB および RGBA データの高品質圧縮に使用される、テクスチャ圧縮形式です。
ms.assetid: 788B6E8C-9A1F-45F9-BE49-742285E8D8A6
keywords:
- BC7 形式
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 70380dd0bd07cfe0c81e8339f8606029663b47d4
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5991476"
---
# <a name="bc7-format"></a>BC7 形式


BC7 形式は、RGB および RGBA データの高品質圧縮に使用される、テクスチャ圧縮形式です。

BC7 形式のブロック モードについて詳しくは、[BC7 形式モード リファレンス](https://msdn.microsoft.com/library/windows/desktop/hh308954)をご覧ください。

## <a name="span-idabout-bc7-dxgi-format-bc7spanspan-idabout-bc7-dxgi-format-bc7spanspan-idabout-bc7-dxgi-format-bc7spanabout-bc7dxgiformatbc7"></a><span id="About-BC7-DXGI-FORMAT-BC7"></span><span id="about-bc7-dxgi-format-bc7"></span><span id="ABOUT-BC7-DXGI-FORMAT-BC7"></span>BC7/DXGI\_FORMAT\_BC7 について


BC7 は、次の DXGI \ _FORMAT 列挙値によって指定されます。

-   **DXGI\_FORMAT\_BC7\_TYPELESS**
-   **DXGI\_FORMAT\_BC7\_UNORM**
-   **DXGI\_FORMAT\_BC7\_UNORM\_SRGB**

BC7 形式は、[Texture2D](https://msdn.microsoft.com/library/windows/desktop/bb205277) (配列を含む)、Texture3D、または TextureCube (配列を含む) のテクスチャ リソースに使用できます。 同様に、この形式は、これらのリソースに関連付けられた任意のミップマップ サーフェスに適用されます。

BC7 は、16バイト (128 ビット) の固定ブロックサイズと 4 × 4 テクセルの固定タイル サイズを使用します。 以前の BC 形式と同様に、サポートされるタイル サイズ (4 x 4) よりも大きなテクスチャ画像は、複数のブロックを使用して圧縮されます。 このアドレス指定 ID は、3 次元画像とミップマップ、キューブマップ、テクスチャ配列にも適用されます。 すべての画像タイルは同じ形式でなければなりません。

BC7 は、3 チャネル (RGB) と 4 チャネル (RGBA) の不動点データ画像を圧縮します。 一般的に、ソース データはカラー成分 (チャネル) ごとに 8 ビットですが、この形式はカラー成分ごとに上位ビットでソース データをエンコードすることができます。 すべての画像タイルは同じ形式でなければなりません。

BC7 デコーダーは、テクスチャ フィルタリングが適用される前に圧縮解除を実行します。

BC7 の圧縮解除ハードウェアはビットアキュレートである必要があります。つまり、ハードウェアはこのドキュメントで説明されているデコーダーによって返される結果と同一の結果を返す必要があります。

## <a name="span-idbc7-implementationspanspan-idbc7-implementationspanspan-idbc7-implementationspanbc7-implementation"></a><span id="BC7-Implementation"></span><span id="bc7-implementation"></span><span id="BC7-IMPLEMENTATION"></span>BC7 の実装


BC7 の実装では、16 バイト (128ビット) ブロックの最下位ビットに指定されたモードで、8 つのモードのうちの 1 つを指定できます。 モードは 0 または 0 の値の後に 1 が続く複数ビットによりエンコードされます。

BC7 ブロックには、複数のエンドポイントのペアを含むことができます。 エンドポイントのペアに対応するインデックスのセットは、「サブセット」と呼ばれることがあります。 また、いくつかのブロック モードでは、エンドポイントの表現は、「RBGP」とも呼ばれる形式でエンコードされます。「P」ビットはエンドポイントのカラー成分の共有最下位ビットを表します。 たとえば、形式のエンドポイント表現が「RGB 5.5.5.1」である場合、エンドポイントは RGB 6.6.6 の値として解釈されます。P ビットの状態は各コンポーネントの最下位ビットを定義します。 同様に、アルファ チャネルを持つソース データでは、形式の表現が「RGBAP 5.5.5.5.1」である場合、エンドポイントは RGBA 6.6.6.6 と解釈されます。 ブロック モードに応じて、サブセットの両方のエンドポイント (サブセットごとに 2 P ビット) の共有最下位ビット、またはサブセットのエンドポイント間で共有される(サブセットごとに 1 P ビット) 最下位ビットを指定できます。

アルファ成分を明示的にエンコードしない BC7 ブロックの場合、BC7 ブロックはモード ビット、パーティション ビット、圧縮エンドポイント、圧縮インデックス、および P ビット (オプション) で構成されます。 これらのブロックでは、エンドポイントは RGB のみの表現を持ち、アルファ成分はソース データ内のすべてのテクセルについて 1.0 としてデコードされます。

色成分とアルファ成分を組み合わせた BC7 ブロックの場合、ブロックはモードビット、圧縮エンドポイント、圧縮インデックス、およびパーティション ビットと P ビット (オプション) で構成されます。 これらのブロックでは、エンドポイントの色は RGBA 形式で表現され、アルファ成分の値は色成分の値により補間されます。

個別の色成分とアルファ成分を持つ BC7 ブロックの場合、ブロックはモード ビット、回転ビット、圧縮エンドポイント、圧縮インデックス、およびインデックス セレクタ ビット (オプション) で構成されます。 これらのブロックには、有効な RGB ベクトル \[R, G, B\] およびスカラー アルファ チャネル \[A\] が別々にエンコードされています。

次の表に、各ブロック タイプのコンポーネントを示します。

| BC7 ブロックに含まれるもの     | モード ビット | 回転ビット | インデックス セレクター ビット | パーティション ビット | 圧縮エンドポイント | P ビット    | 圧縮インデックス |
|---------------------------|-----------|---------------|--------------------|----------------|----------------------|----------|--------------------|
| 色成分のみ     | 必須  | なし           | なし                | 必須       | 必須             | オプション | 必須           |
| 色とアルファの組み合わせ    | 必須  | なし           | なし                | オプション       | 必須             | オプション | 必須           |
| 色とアルファが別々 | 必須  | 必須      | オプション           | なし            | 必須             | なし      | 必須           |

 

BC7 は、2 つのエンドポイント間の近似線上に色のパレットを定義します。 モード値によって、ブロックごとのエンドポイント ペアの補間の数が決まります。 BC7 はテクセルごとに 1 つのパレット インデックスを格納します。

エンコーダーは、エンドポイントのペアに対応するインデックスの各サブセットについて、そのサブセットの圧縮インデックス データの 1 ビットの状態を固定します。 これは次のように行われます。まずエンドポイントの順序を選択して、指定された「修正」インデックスのためのインデックスがその最上位ビットを 0 に設定するようにします。するとそれは破棄されて、サブセットごとに 1 ビットが保存されます。 単一のサブセットのみを持つブロック モードの場合、修正インデックスは常にインデックス 0 です。

## <a name="span-iddecoding-the-bc7-formatspanspan-iddecoding-the-bc7-formatspanspan-iddecoding-the-bc7-formatspandecoding-the-bc7-format"></a><span id="Decoding-the-BC7-Format"></span><span id="decoding-the-bc7-format"></span><span id="DECODING-THE-BC7-FORMAT"></span>BC7 形式のデコード


次の擬似コードは、16 バイトの BC7 ブロックを指定して(x, y) のピクセルを圧縮解除する手順の概要を示しています。

``` syntax
decompress_bc7(x, y, block)
{
    mode = extract_mode(block);
    
    //decode partition data from explicit partition bits
    subset_index = 0;
    num_subsets = 1;
    
    if (mode.type == 0 OR == 1 OR == 2 OR == 3 OR == 7)
    {
        num_subsets = get_num_subsets(mode.type);
        partition_set_id = extract_partition_set_id(mode, block);
        subset_index = get_partition_index(num_subsets, partition_set_id, x, y);
    }
    
    //extract raw, compressed endpoint bits
    UINT8 endpoint_array[num_subsets][4] = extract_endpoints(mode, block);
    
    //decode endpoint color and alpha for each subset
    fully_decode_endpoints(endpoint_array, mode, block);
    
    //endpoints are now complete.
    UINT8 endpoint_start[4] = endpoint_array[2 * subset_index];
    UINT8 endpoint_end[4]   = endpoint_array[2 * subset_index + 1];
        
    //Determine the palette index for this pixel
    alpha_index     = get_alpha_index(block, mode, x, y);
    alpha_bitcount  = get_alpha_bitcount(block, mode);
    color_index     = get_color_index(block, mode, x, y);
    color_bitcount  = get_color_bitcount(block, mode);

    //determine output
    UINT8 output[4];
    output.rgb = interpolate(endpoint_start.rgb, endpoint_end.rgb, color_index, color_bitcount);
    output.a   = interpolate(endpoint_start.a,   endpoint_end.a,   alpha_index, alpha_bitcount);
    
    if (mode.type == 4 OR == 5)
    {
        //Decode the 2 color rotation bits as follows:
        // 00 – Block format is Scalar(A) Vector(RGB) - no swapping
        // 01 – Block format is Scalar(R) Vector(AGB) - swap A and R
        // 10 – Block format is Scalar(G) Vector(RAB) - swap A and G
        // 11 - Block format is Scalar(B) Vector(RGA) - swap A and B
        rotation = extract_rot_bits(mode, block);
        output = swap_channels(output, rotation);
    }
    
}
```

次の擬似コードは、16 バイトの BC7 ブロックを指定して、各サブセットのエンドポイントの色とアルファ成分を完全にデコードする手順の概要を示しています。

``` syntax
fully_decode_endpoints(endpoint_array, mode, block)
{
    //first handle modes that have P-bits
    if (mode.type == 0 OR == 1 OR == 3 OR == 6 OR == 7)
    {
        for each endpoint i
        {
            //component-wise left-shift
            endpoint_array[i].rgba = endpoint_array[i].rgba << 1;
        }
        
        //if P-bit is shared
        if (mode.type == 1) 
        {
            pbit_zero = extract_pbit_zero(mode, block);
            pbit_one = extract_pbit_one(mode, block);
            
            //rgb component-wise insert pbits
            endpoint_array[0].rgb |= pbit_zero;
            endpoint_array[1].rgb |= pbit_zero;
            endpoint_array[2].rgb |= pbit_one;
            endpoint_array[3].rgb |= pbit_one;  
        }
        else //unique P-bit per endpoint
        {  
            pbit_array = extract_pbit_array(mode, block);
            for each endpoint i
            {
                endpoint_array[i].rgba |= pbit_array[i];
            }
        }
    }

    for each endpoint i
    {
        // Color_component_precision & alpha_component_precision includes pbit
        // left shift endpoint components so that their MSB lies in bit 7
        endpoint_array[i].rgb = endpoint_array[i].rgb << (8 - color_component_precision(mode));
        endpoint_array[i].a = endpoint_array[i].a << (8 - alpha_component_precision(mode));

        // Replicate each component's MSB into the LSBs revealed by the left-shift operation above
        endpoint_array[i].rgb = endpoint_array[i].rgb | (endpoint_array[i].rgb >> color_component_precision(mode));
        endpoint_array[i].a = endpoint_array[i].a | (endpoint_array[i].a >> alpha_component_precision(mode));
    }
        
    //If this mode does not explicitly define the alpha component
    //set alpha equal to 1.0
    if (mode.type == 0 OR == 1 OR == 2 OR == 3)
    {
        for each endpoint i
        {
            endpoint_array[i].a = 255; //i.e. alpha = 1.0f
        }
    }
}
```

各サブセットの補間された各成分を生成するには、次のアルゴリズムを使用します。生成する成分を "c" とします。 "e0" をサブセットのエンドポイント 0 の成分とします。"e1" をそのサブセットのエンドポイント 1 の成分とします。

``` syntax
UINT16 aWeight2[] = {0, 21, 43, 64};
UINT16 aWeight3[] = {0, 9, 18, 27, 37, 46, 55, 64};
UINT16 aWeight4[] = {0, 4, 9, 13, 17, 21, 26, 30, 34, 38, 43, 47, 51, 55, 60, 64};

UINT8 interpolate(UINT8 e0, UINT8 e1, UINT8 index, UINT8 indexprecision)
{
    if(indexprecision == 2)
        return (UINT8) (((64 - aWeights2[index])*UINT16(e0) + aWeights2[index]*UINT16(e1) + 32) >> 6);
    else if(indexprecision == 3)
        return (UINT8) (((64 - aWeights3[index])*UINT16(e0) + aWeights3[index]*UINT16(e1) + 32) >> 6);
    else // indexprecision == 4
        return (UINT8) (((64 - aWeights4[index])*UINT16(e0) + aWeights4[index]*UINT16(e1) + 32) >> 6);
}
```

次の擬似コードは、色の成分とアルファ成分のインデックスとビット数を抽出する方法を示しています。 別の色とアルファを持つブロックには、ベクトル チャネル用とスカラー チャネル用の 2 つのインデックス データ セットもあります。 モード 4 では、これらのインデックスは異なる幅 (2 または 3 ビット) を持ち、ベクトルまたはスカラー データが 3 ビット インデックスを使用するかどうかを指定する 1 ビット セレクタがあります。 (アルファ ビット数の抽出は、カラー ビット数の抽出と似ていますが、**idxMode** ビットに基づく逆の動作です)。

``` syntax
bitcount get_color_bitcount(block, mode)
{
    if (mode.type == 0 OR == 1)
        return 3;
    
    if (mode.type == 2 OR == 3 OR == 5 OR == 7)
        return 2;
    
    if (mode.type == 6)
        return 4;
        
    //The only remaining case is Mode 4 with 1-bit index selector
    idxMode = extract_idxMode(block);
    if (idxMode == 0)
        return 2;
    else
        return 3;
}
```

## <a name="span-idbc7-format-mode-referencespanspan-idbc7-format-mode-referencespanspan-idbc7-format-mode-referencespanbc7-format-mode-reference"></a><span id="BC7-format-mode-reference"></span><span id="bc7-format-mode-reference"></span><span id="BC7-FORMAT-MODE-REFERENCE"></span>BC7 形式モードのリファレンス


このセクションには、BC7 テクスチャ圧縮形式のブロックの 8 つのブロック モードとビット割り当てのリストが含まれています。

ブロック内の各サブセットの色は、2 つの明示的なエンドポイントの色とその間の補間された色のセットで表されます。 ブロックのインデックスの精度に応じて、各サブセットは 4、8 または 16 の色を持つことができます。

### <a name="span-idmode-0spanspan-idmode-0spanspan-idmode-0spanmode-0"></a><span id="Mode-0"></span><span id="mode-0"></span><span id="MODE-0"></span>モード 0

BC7 モード 0 には以下の特徴があります。

-   カラー成分のみ (アルファなし)
-   ブロックごとに 3 つのサブセット
-   エンドポイントごとに固有の P ビットを持つ、RGBP 4.4.4.1 エンドポイント
-   3 ビット インデックス
-   16 パーティション

![モード 0 のビット レイアウト](images/bc7-mode0.png)

### <a name="span-idmode-1spanspan-idmode-1spanspan-idmode-1spanmode-1"></a><span id="Mode-1"></span><span id="mode-1"></span><span id="MODE-1"></span>モード 1

BC7 モード 1 には以下の特徴があります。

-   カラー成分のみ (アルファなし)
-   ブロックごとに 2 つのサブセット
-   エンドポイントごとに 1 つの共有 P ビットを持つ、RGBP 6.6.6.1 エンドポイント)
-   3 ビット インデックス
-   64 パーティション

![モード 1 のビット レイアウト](images/bc7-mode1.png)

### <a name="span-idmode-2spanspan-idmode-2spanspan-idmode-2spanmode-2"></a><span id="Mode-2"></span><span id="mode-2"></span><span id="MODE-2"></span>モード 2

BC7 モード 2 には以下の特徴があります。

-   カラー成分のみ (アルファなし)
-   ブロックごとに 3 つのサブセット
-   RGB 5.5.5 エンドポイント
-   2 ビット インデックス
-   64 パーティション

![モード 2 のビット レイアウト](images/bc7-mode2.png)

### <a name="span-idmode-3spanspan-idmode-3spanspan-idmode-3spanmode-3"></a><span id="Mode-3"></span><span id="mode-3"></span><span id="MODE-3"></span>モード 3

BC7 モード 3 には以下の特徴があります。

-   カラー成分のみ (アルファなし)
-   ブロックごとに 2 つのサブセット
-   サブセットごとに固有の P ビットを持つ、RGBP 7.7.7.1 エンドポイント)
-   2 ビット インデックス
-   64 パーティション

![モード 3 のビット レイアウト](images/bc7-mode3.png)

### <a name="span-idmode-4spanspan-idmode-4spanspan-idmode-4spanmode-4"></a><span id="Mode-4"></span><span id="mode-4"></span><span id="MODE-4"></span>モード 4

BC7 モード 4 には以下の特徴があります。

-   別のアルファ成分を持つカラー成分
-   ブロックごとに 1 つのサブセット
-   RGB 5.5.5 カラー エンドポイント
-   6 ビットのアルファ エンドポイント
-   16 個の 2 ビット インデックス
-   16 個の 3 ビット インデックス
-   2 ビット成分回転
-   1 ビットのインデックス セレクター (2 ビットまたは 3 ビットのインデックスの使用を指定する)

![モード 4 のビット レイアウト](images/bc7-mode4.png)

### <a name="span-idmode-5spanspan-idmode-5spanspan-idmode-5spanmode-5"></a><span id="Mode-5"></span><span id="mode-5"></span><span id="MODE-5"></span>モード 5

BC7 モード 5 には以下の特徴があります。

-   別のアルファ成分を持つカラー成分
-   ブロックごとに 1 つのサブセット
-   RGB 7.7.7 カラー エンドポイント
-   6 ビットのアルファ エンドポイント
-   16 個の 2 ビット カラー インデックス
-   16 個の 2 ビット アルファ インデックス
-   2 ビット成分回転

![モード 5 のビット レイアウト](images/bc7-mode5.png)

### <a name="span-idmode-6spanspan-idmode-6spanspan-idmode-6spanmode-6"></a><span id="Mode-6"></span><span id="mode-6"></span><span id="MODE-6"></span>モード 6

BC7 モード 6 には以下の特徴があります。

-   色成分とアルファ成分の結合
-   ブロックごとに 1 つのサブセット
-   RGBAP 7.7.7.7.1 カラー (およびアルファ) エンドポイント (エンドポイントごとに固有の P ビット)
-   16 個の 4 ビット インデックス

![モード 6 のビット レイアウト](images/bc7-mode6.png)

### <a name="span-idmode-7spanspan-idmode-7spanspan-idmode-7spanmode-7"></a><span id="Mode-7"></span><span id="mode-7"></span><span id="MODE-7"></span>モード 7

BC7 モード 7 には以下の特徴があります。

-   色成分とアルファ成分の結合
-   ブロックごとに 2 つのサブセット
-   RGBAP 5.5.5.5.1 カラー (およびアルファ) エンドポイント (エンドポイントごとに固有の P ビット)
-   2 ビット インデックス
-   64 パーティション

![モード 7 のビット レイアウト](images/bc7-mode7.png)

### <a name="span-idremarksspanspan-idremarksspanspan-idremarksspanremarks"></a><span id="Remarks"></span><span id="remarks"></span><span id="REMARKS"></span>注釈

モード 8 (最下位バイトは 0x00 に設定されます) は予約されています。 エンコーダーで使用しないでください。 このモードをハードウェアに渡すと、すべてゼロに初期化されたブロックが返されます。

BC7 では、次のいずれかの方法でアルファ成分をエンコードできます。

-   明示的なアルファ成分エンコーディングのないブロック タイプ。 これらのブロックでは、カラー エンドポイントには RGB のみのエンコードがあり、アルファ成分はすべてのテクセルに対して 1.0 にデコードされます。
-   色成分とアルファ成分を組み合わせたブロック タイプ。 これらのブロックでは、エンドポイントのカラー値は RGBA 形式で指定され、アルファ成分の値は、カラー値と共に補間されます。
-   色成分とアルファ成分が分離されたブロック タイプ。 これらのブロックでは、色とアルファの値が別々に指定され、それぞれ独自のインデックス セットを持ちます。 その結果、有効なベクトルとスカラー チャネルが別々にエンコードされます。一般にベクトルはカラー チャネル \[R, G, B\] を指定し、スカラーはアルファ チャネル \[A\] を指定します。 この方法をサポートするために、別の 2 ビット フィールドがエンコードに提供されます。これにより、スカラー値として別のチャネル エンコードの指定が可能になります。 その結果、ブロックは、このアルファ エンコードの次の 4 つの異なる表現のうちの 1 つを持つことができます (2 ビット フィールドによって示されます)。
    -   RGB|A: アルファ チャネル分離
    -   AGB|R: "赤" 色チャネル分離
    -   RAB|G: "緑" 色チャネル分離
    -   RGA|B: "青" 色チャネル分離

    デコーダーは、デコード後にチャネルの順序を RGBA に戻すため、内部ブロックの形式は開発者には見えません。 別の色成分とアルファ成分を持つ黒は、2 つのセットのインデックス データも持っています。1 つはベクター化されたチャネル セット用で、もう 1 つはスカラー チャネル用です。 (モード 4 の場合、これらのインデックスの幅はそれぞれ \[2 ビットまたは 3 ビット\] と異なります。 モード 4 には、ベクトルまたはスカラー チャネルが 3 ビット インデックスを使用するかどうかを指定する、1 ビットのセレクターも含まれています。)

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャのブロック圧縮](texture-block-compression.md)

 

 




