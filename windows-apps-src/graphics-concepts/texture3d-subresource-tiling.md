---
title: Texture3D サブリソースのタイル表示
description: 次の表に、Texture3D サブリソースがどのようにタイル表示されるかを示します。
ms.assetid: 210D03E4-CF12-47E0-BA2F-C8D059B17D3E
keywords:
- Texture3D サブリソースのタイル表示
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 17970d509fa2bf6b80431e1c07b5d135c7dcb112
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7578883"
---
# <a name="texture3d-subresource-tiling"></a>Texture3D サブリソースのタイル表示


次の表に、[**Texture3D**](https://msdn.microsoft.com/library/windows/desktop/ff471562) サブリソースがどのようにタイル表示されるかを示します。 この表の値は、テール ミップ パッキングをカウントしていません。

次の表では、[**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) のタイル表示を受け取り、x/y 次元をそれぞれ 4 で割り、16 レイヤーの深度を追加します。 最初の平面 (最初の 16 レイヤーの深度を定義するタイルの 2D 平面) のすべてのタイルが、後続の平面の前に表示されます。

**注:** ストリーミング リソースでの[**Texture3D**](https://msdn.microsoft.com/library/windows/desktop/ff471562)のサポートがない、ストリーミング リソースの最初の実装で公開されているが、今後のリリースでのサポートに備えて必要なタイル形状はここに記載されています。

 

| ビット/ピクセル (1 サンプル/ピクセル) | タイルの寸法 (ピクセル、W x H x D) |
|-----------------------------|---------------------------------|
| 8                           | 64 x 32 x 32                        |
| 16                          | 32 x 32 x 32                        |
| 32                          | 32 x 32 x 16                        |
| 64                          | 32 x 16 x 16                        |
| 128                         | 16 x 16 x 16                        |
| BC1、4                       | 128 x 64 x 16                       |
| BC2、3、5、6、7                 | 64 x 64 x 16                        |

 

ストリーミング リソースでサポートされない形式のビット数は、96 bpp 形式、ビデオ形式、DXGI\_FORMAT\_R1\_UNORM、DXGI\_FORMAT\_R8G8\_B8G8\_UNORM、および DXGI\_FORMAT\_R8R8\_G8B8\_UNORM です。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースの領域をタイル表示する方法](how-a-streaming-resource-s-area-is-tiled.md)

 

 




