---
ms.assetid: 98BD79B3-F420-43C5-98D3-52EBDDB479A0
description: この記事では、BitmapEncoder で使用できるエンコーディング オプションを示します。
title: BitmapEncoder オプションのリファレンス
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 07f5c6ef180cb4abe90a705e73be8d99ecbd2ca7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603187"
---
# <a name="bitmapencoder-options-reference"></a>BitmapEncoder オプションのリファレンス


この記事では、[**BitmapEncoder**](https://msdn.microsoft.com/library/windows/apps/br226206) で使用できるエンコーディング オプションを示します。 エンコーディング オプションは、対応する名前の文字列と特定のデータ型 ([**Windows.Foundation.PropertyType**](https://msdn.microsoft.com/library/windows/apps/br225871)) の値によって定義されます。 画像の操作について詳しくは、「[ビットマップ画像の作成、編集、保存](imaging.md)」をご覧ください。

| 名前                    | PropertyType | 使用上の注意                                                                                        | 有効な形式 |
|-------------------------|--------------|----------------------------------------------------------------------------------------------------|---------------|
| ImageQuality            | single       | 有効な値は 0 ～ 1.0 です。 値が大きいほど、画質が高くなります。                                 | JPEG、JPEG-XR |
| CompressionQuality      | single       | 有効な値は 0 ～ 1.0 です。 値が大きいほど、効率の高い (時間のかかる) 圧縮方式であることを示します。 | TIFF          |
| Lossless                | boolean      | true に設定すると、ImageQuality オプションが無視されます。                                        | JPEG-XR       |
| InterlaceOption         | boolean      | 画像をインターレースするかどうかを示します。                                                                    | PNG           |
| FilterOption            | uint8        | [  **PngFilterMode**](https://msdn.microsoft.com/library/windows/apps/br226389) 列挙値を使います。                                | PNG           |
| TiffCompressionMethod   | uint8        | [  **TiffCompressionMode**](https://msdn.microsoft.com/library/windows/apps/br226399) 列挙値を使います。                    | TIFF          |
| Luminance               | uint32Array  | 輝度の量子化定数を格納する 64 要素の配列です。                               | JPEG          |
| Chrominance             | uint32Array  | クロミナンスの量子化定数を格納する 64 要素の配列です。                             | JPEG          |
| JpegYCrCbSubsampling    | uint8        | [  **JpegSubsamplingMode**](https://msdn.microsoft.com/library/windows/apps/br226386) 列挙値を使います。                    | JPEG          |
| SuppressApp0            | boolean      | App0 メタデータ ブロックの作成を抑制するかどうかを示します。                                        | JPEG          |
| EnableV5Header32bppBGRA | boolean      | アルファをサポートするバージョン 5 BMP にエンコードするかどうかを示します。                                         | BMP           |

 

## <a name="related-topics"></a>関連トピック

* [ビットマップ画像の作成、編集、保存](imaging.md)
* [サポートされるコーデック](supported-codecs.md)

 




