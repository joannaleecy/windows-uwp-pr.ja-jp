---
title: Texture3D サブリソースのタイル表示
description: 次の表に、Texture3D サブリソースがどのようにタイル表示されるかを示します。
ms.assetid: 210D03E4-CF12-47E0-BA2F-C8D059B17D3E
keywords:
- Texture3D サブリソースのタイル表示
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c9c232bc60bbbb3cccc16618d82ec23452c58ee8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645957"
---
# <a name="texture3d-subresource-tiling"></a>Texture3D サブリソースのタイル表示


次の表に、[**Texture3D**](https://msdn.microsoft.com/library/windows/desktop/ff471562) サブリソースがどのようにタイル表示されるかを示します。 この表の値は、テール ミップ パッキングをカウントしていません。

次の表では、[**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) のタイル表示を受け取り、x/y 次元をそれぞれ 4 で割り、16 レイヤーの深度を追加します。 最初の平面 (最初の 16 レイヤーの深度を定義するタイルの 2D 平面) のすべてのタイルが、後続の平面の前に表示されます。

**注** ストリーミング リソースでの   [**Texture3D**](https://msdn.microsoft.com/library/windows/desktop/ff471562) のサポートは、ストリーミング リソースの最初の実装では公開されませんが、今後のリリースでのサポートに備えて必要なタイル形状をここに示します。

 

| ビット/ピクセル (1 サンプル/ピクセル) | タイルの寸法 (ピクセル、W x H x D) |
|-----------------------------|---------------------------------|
| 8                           | 64 x 32 x 32                        |
| 16                          | 32 x 32 x 32                        |
| 32                          | 32 x 32 x 16                        |
| 64                          | 32 x 16 x 16                        |
| 128                         | 16 x 16 x 16                        |
| BC1、4                       | 128 x 64 x 16                       |
| BC2、3、5、6、7                 | 64 x 64 x 16                        |

 

ストリームのリソースではサポートされていません形式のビット数は 96 の bpp 形式、ビデオ形式は、DXGI\_形式\_R1\_UNORM、DXGI\_形式\_R8G8\_B8G8\_UNORM、DXGI\_形式\_R8R8\_G8B8\_UNORM します。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミングのリソースの領域は並べて表示する方法](how-a-streaming-resource-s-area-is-tiled.md)

 

 




