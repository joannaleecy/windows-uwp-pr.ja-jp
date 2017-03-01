---
author: laurenhughes
ms.assetid: 98BD79B3-F420-43C5-98D3-52EBDDB479A0
description: "この記事では、BitmapEncoder で使用できるエンコーディング オプションを示します。"
title: "BitmapEncoder オプションのリファレンス"
ms.author: lahugh
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: c29c05e7397e87851ebb0fa5fa29df3b9b58907b
ms.lasthandoff: 02/07/2017

---

# <a name="bitmapencoder-options-reference"></a>BitmapEncoder オプションのリファレンス

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]

この記事では、[**BitmapEncoder**](https://msdn.microsoft.com/library/windows/apps/br226206) で使用できるエンコーディング オプションを示します。 エンコーディング オプションは、対応する名前の文字列と特定のデータ型 ([**Windows.Foundation.PropertyType**](https://msdn.microsoft.com/library/windows/apps/br225871)) の値によって定義されます。 画像の操作について詳しくは、「[ビットマップ画像の作成、編集、保存](imaging.md)」をご覧ください。

| 名前                    | PropertyType | 使用上の注意                                                                                        | 有効な形式 |
|-------------------------|--------------|----------------------------------------------------------------------------------------------------|---------------|
| ImageQuality            | single       | 有効な値は 0 ～ 1.0 です。 値が大きいほど、画質が高くなります。                                 | JPEG、JPEG-XR |
| CompressionQuality      | single       | 有効な値は 0 ～ 1.0 です。 値が大きいほど、効率の高い (時間のかかる) 圧縮方式であることを示します。 | TIFF          |
| Lossless                | boolean      | true に設定すると、ImageQuality オプションが無視されます。                                        | JPEG-XR       |
| InterlaceOption         | boolean      | 画像をインターレースするかどうかを示します。                                                                    | PNG           |
| FilterOption            | uint8        | [**PngFilterMode**](https://msdn.microsoft.com/library/windows/apps/br226389) 列挙値を使います。                                | PNG           |
| TiffCompressionMethod   | uint8        | [**TiffCompressionMode**](https://msdn.microsoft.com/library/windows/apps/br226399) 列挙値を使います。                    | TIFF          |
| Luminance               | uint32Array  | 輝度の量子化定数を格納する 64 要素の配列です。                               | JPEG          |
| Chrominance             | uint32Array  | クロミナンスの量子化定数を格納する 64 要素の配列です。                             | JPEG          |
| JpegYCrCbSubsampling    | uint8        | [**JpegSubsamplingMode**](https://msdn.microsoft.com/library/windows/apps/br226386) 列挙値を使います。                    | JPEG          |
| SuppressApp0            | boolean      | App0 メタデータ ブロックの作成を抑制するかどうかを示します。                                        | JPEG          |
| EnableV5Header32bppBGRA | boolean      | アルファをサポートするバージョン 5 BMP にエンコードするかどうかを示します。                                         | BMP           |

 

## <a name="related-topics"></a>関連トピック

* [ビットマップ画像の作成、編集、保存](imaging.md)
* [サポートされているコーデック](supported-codecs.md)

 





