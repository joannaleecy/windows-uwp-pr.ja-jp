---
title: テクスチャのブロック圧縮
description: Direct3D 11 では、テクスチャのブロック圧縮 (BC) サポートが拡張され、BC6H および BC7 アルゴリズムが組み込まれています。
ms.assetid: 63506C46-BF14-464B-B20C-8B8F359E7AFE
keywords:
- テクスチャのブロック圧縮
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: dec33768eff90b9bd35a3ea60f3158fce663345e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640187"
---
# <a name="texture-block-compression"></a>テクスチャのブロック圧縮


Direct3D 11 では、テクスチャのブロック圧縮 (BC) サポートが拡張され、BC6H および BC7 アルゴリズムが組み込まれています。 BC6H はハイ ダイナミック レンジのカラー ソース データをサポートし、BC7 は標準 RGB ソース データのアーティファクトを低減して標準よりも優れた品質の圧縮を提供します。

BC1 ～ BC5 形式のサポートなど、Direct3D 11 より前のブロック圧縮アルゴリズムのサポートに関する具体的な情報については、「[ブロック圧縮 (Direct3D 10)](https://msdn.microsoft.com/library/windows/desktop/bb694531)」をご覧ください。

**ファイル形式に関する注意事項。  **BC6H および BC7 テクスチャの圧縮形式は、圧縮されたテクスチャ データを格納する DDS ファイル形式を使用します。 詳しくは、「[DDS 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/bb943991)」をご覧ください。

## <a name="span-idblockcompressionformatssupportedindirect3d11spanspan-idblockcompressionformatssupportedindirect3d11spanspan-idblockcompressionformatssupportedindirect3d11spanblock-compression-formats-supported-in-direct3d-11"></a><span id="Block_Compression_Formats_Supported_in_Direct3D_11"></span><span id="block_compression_formats_supported_in_direct3d_11"></span><span id="BLOCK_COMPRESSION_FORMATS_SUPPORTED_IN_DIRECT3D_11"></span>Direct3D でサポートされている圧縮形式のブロック 11


| ソース データ                                  | 最低限必要なデータ圧縮解像度                              | 推奨形式 | サポートされる最小機能レベル |
|----------------------------------------------|---------------------------------------------------------------------------|--------------------|---------------------------------|
| 3 チャネル カラーおよびアルファ チャネル       | 3 カラー チャネル (5 ビット:6 ビット:5 ビット)、および 0 または 1 ビットのアルファ  | BC1                | Direct3D 9.1                    |
| 3 チャネル カラーおよびアルファ チャネル       | 3 カラー チャネル (5 ビット:6 ビット:5 ビット)、および 4 ビットのアルファ         | BC2                | Direct3D 9.1                    |
| 3 チャネル カラーおよびアルファ チャネル       | 3 カラー チャネル (5 ビット:6 ビット:5 ビット)、および 8 ビットのアルファ          | BC3                | Direct3D 9.1                    |
| 1 チャネル カラー                            | 1 カラー チャネル (8 ビット)                                                | BC4                | Direct3D 10                     |
| 2 チャネル カラー                            | 2 カラー チャンネル (8 ビット:8 ビット)                                        | BC5                | Direct3D 10                     |
| 3 チャネル ハイ ダイナミック レンジ (HDR) カラー | 3 つの色 (16 ビット: 16 ビット: 16 ビット) のチャネルを「半分」浮動小数点\* | BC6H               | Direct3D 11                     |
| 3 チャネル カラー、アルファ チャネルはオプション  | 3 カラー チャネル (チャネルあたり 4 ～ 7 ビット)、および 0 ～ 8 ビットのアルファ  | BC7                | Direct3D 11                     |

 

\*浮動小数点数「半分」は、省略可能な符号ビットで構成される 16 ビット値、5 ビット指数、および 10 または 11 ビット仮数部のバイアスします。
## <a name="span-idbc1bc2andb3formatsspanspan-idbc1bc2andb3formatsspanspan-idbc1bc2andb3formatsspanbc1-bc2-and-b3-formats"></a><span id="BC1__BC2__and_B3_Formats"></span><span id="bc1__bc2__and_b3_formats"></span><span id="BC1__BC2__AND_B3_FORMATS"></span>BC1、BC2、および B3 形式


BC1、BC2、および BC3 形式は Direct3D 9 DXTn テクスチャ圧縮形式と等価で、対応する Direct3D 10 BC1、BC2、および BC3 形式と同じです。 すべての機能レベルでのこれら 3 つの形式のサポートが必要です (D3D\_機能\_レベル\_9\_1、D3D\_機能\_レベル\_9\_2、D3D\_機能\_レベル\_9\_3、D3D\_機能\_レベル\_10\_0、D3D\_機能\_レベル\_10\_1、および D3D\_機能\_レベル\_11\_0)。

| ブロック圧縮形式 | DXGI 形式                                                                           | 相当する Direct3D 9 の形式                               | 4 x 4 のピクセル ブロックあたりのバイト数 |
|--------------------------|---------------------------------------------------------------------------------------|------------------------------------------------------------|---------------------------|
| BC1                      | DXGI\_形式\_BC1\_UNORM、DXGI\_形式\_BC1\_UNORM\_SRGB、DXGI\_形式\_BC1\_TYPELESS | D3DFMT\_DXT1、FourCC"DXT1"を =                                | 8                         |
| BC2                      | DXGI\_形式\_BC2\_UNORM、DXGI\_形式\_BC2\_UNORM\_SRGB、DXGI\_形式\_BC2\_TYPELESS | D3DFMT\_DXT2\*、FourCC = D3DFMT"DXT2"\_DXT3、FourCC"DXT3"を = | 16                        |
| BC3                      | DXGI\_形式\_BC3\_UNORM、DXGI\_形式\_BC3\_UNORM\_SRGB、DXGI\_形式\_BC3\_TYPELESS | D3DFMT\_DXT4\*、FourCC = D3DFMT"DXT4"\_DXT5、FourCC"DXT5"を = | 16                        |

 

\*これらの圧縮方式 (DXT2 および DXT4) には、Direct3D 9 前乗算されたアルファ形式と標準のアルファ形式の違いは行いません。 これらの区別は、レンダリング時にプログラム可能なシェーダーで処理する必要があります。

## <a name="span-idbc4andbc5formatsspanspan-idbc4andbc5formatsspanspan-idbc4andbc5formatsspanbc4-and-bc5-formats"></a><span id="BC4_and_BC5_Formats"></span><span id="bc4_and_bc5_formats"></span><span id="BC4_AND_BC5_FORMATS"></span>に対する BC4、BC5 形式


| ブロック圧縮形式 | DXGI 形式                                                                     | 相当する Direct3D 9 の形式 | 4 x 4 のピクセル ブロックあたりのバイト数 |
|--------------------------|---------------------------------------------------------------------------------|------------------------------|---------------------------|
| BC4                      | DXGI\_形式\_に対する BC4\_UNORM、DXGI\_形式\_に対する BC4\_SNORM、DXGI\_形式\_に対する BC4\_TYPELESS | FourCC="ATI1"                | 8                         |
| BC5                      | DXGI\_形式\_BC5\_UNORM、DXGI\_形式\_BC5\_SNORM、DXGI\_形式\_BC5\_TYPELESS | FourCC="ATI2"                | 16                        |

 

## <a name="span-idbc6hformatspanspan-idbc6hformatspanspan-idbc6hformatspanbc6h-format"></a><span id="BC6H_Format"></span><span id="bc6h_format"></span><span id="BC6H_FORMAT"></span>BC6H 形式


この形式については詳しくは、「[BC6H 形式](https://msdn.microsoft.com/library/windows/desktop/hh308952)」をご覧ください。

| ブロック圧縮形式 | DXGI 形式                                                                      | 相当する Direct3D 9 の形式 | 4 x 4 のピクセル ブロックあたりのバイト数 |
|--------------------------|----------------------------------------------------------------------------------|------------------------------|---------------------------|
| BC6H                     | DXGI\_形式\_BC6H\_UF16、DXGI\_形式\_BC6H\_SF16、DXGI\_形式\_BC6H\_TYPELESS | なし                          | 16                        |

 

BC6H 形式では、4 x 4 のピクセル ブロックごとに異なるエンコード モードを選択できます。 全部で 14 種類のエンコード モードを利用でき、それぞれのモードには、表示されるテクスチャの画質に少しずつ異なるトレードオフがあります。 モードの選択によって、ソース コンテンツに合わせて品質レベルを選択または適合させたハードウェアで高速デコードできますが、検索領域の複雑さも大幅に増加します。

## <a name="span-idbc7formatspanspan-idbc7formatspanspan-idbc7formatspanbc7-format"></a><span id="BC7_Format"></span><span id="bc7_format"></span><span id="BC7_FORMAT"></span>BC7 形式


この形式については詳しくは、「[BC7 形式](https://msdn.microsoft.com/library/windows/desktop/hh308953)」をご覧ください。

| ブロック圧縮形式 | DXGI 形式                                                                           | 相当する Direct3D 9 の形式 | 4 x 4 のピクセル ブロックあたりのバイト数 |
|--------------------------|---------------------------------------------------------------------------------------|------------------------------|---------------------------|
| BC7                      | DXGI\_形式\_BC7\_UNORM、DXGI\_形式\_BC7\_UNORM\_SRGB、DXGI\_形式\_BC7\_TYPELESS | なし                          | 16                        |

 

BC7 形式では、4 x 4 のピクセル ブロックごとに異なるエンコード モードを選択できます。 全部で 8 種類のエンコード モードを利用でき、それぞれのモードには、表示されるテクスチャの画質に少しずつ異なるトレードオフがあります。 モードの選択によって、ソース コンテンツに合わせて品質レベルを選択または適合させたハードウェアで高速デコードできますが、検索領域の複雑さも大幅に増加します。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[付録](appendix.md)

[テクスチャ](https://msdn.microsoft.com/library/windows/desktop/ff476902)

 

 




