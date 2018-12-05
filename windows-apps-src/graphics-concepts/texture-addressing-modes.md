---
title: テクスチャのアドレス指定モード
description: Direct3D アプリケーションは、任意のプリミティブの頂点テクスチャ座標を割り当てることができます。
ms.assetid: 925E8F2E-43EC-404E-8870-03E39155F697
keywords:
- テクスチャのアドレス指定モード
- ラップ テクスチャ アドレス モード
- ミラー テクスチャ アドレス モード
- クランプ テクスチャ アドレス モード
- 境界線の色テクスチャ アドレス モード
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 5e263876f414e5683ffc8a5645a12e5031b3d6fb
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8707376"
---
# <a name="texture-addressing-modes"></a>テクスチャのアドレス指定モード


Direct3D アプリケーションは、任意のプリミティブの頂点テクスチャ座標を割り当てることができます。 通常、頂点に割り当てるテクスチャ座標 (u, v) は 0.0 ～ 1.0 (両端含む) の範囲です。 ただし、その範囲外のテクスチャ座標を割り当てることで、テクスチャリングの特殊効果を作成できます。 .

テクスチャのアドレス指定モードを設定すると、\[0.0, 1.0\] の範囲外にあるテクスチャ座標で Direct3D が実行することを制御できます。 たとえば、テクスチャがプリミティブ全体でタイル化されるようにアプリケーションにテクスチャのアドレス指定モードを設定させることができます。

Direct3D では、アプリケーションでテクスチャの折り返しを実行できます。 「[テクスチャの折り返し](texture-wrapping.md)」をご覧ください。

テクスチャの折り返しを有効にすると、\[0.0, 1.0\] の範囲外のテクスチャ座標は無効になり、その場合は延滞テクスチャ座標などのラスター化の動作は未定義になります。 テクスチャの折り返しを有効にすると、テクスチャのアドレス指定モードは使用されません。 テクスチャの折り返しが有効なときは、アプリケーションで 0.0 未満または 1.0 を上回るテクスチャ座標を指定しないように気をつけてください。

## <a name="span-idsummaryofthetextureaddressingmodesspanspan-idsummaryofthetextureaddressingmodesspanspan-idsummaryofthetextureaddressingmodesspansummary-of-the-texture-addressing-modes"></a><span id="Summary_of_the_texture_addressing_modes"></span><span id="summary_of_the_texture_addressing_modes"></span><span id="SUMMARY_OF_THE_TEXTURE_ADDRESSING_MODES"></span>テクスチャのアドレス指定モードの概要


| テクスチャのアドレス指定モード | 説明                                                                                                                           |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------------------|
| Wrap (ラップ)                    | すべての整数接合点でテクスチャを繰り返します。                                                                                        |
| Mirror (ミラー)                  | すべての整数境界でテクスチャをミラーリングします。                                                                                        |
| Clamp (クランプ)                   | テクスチャ座標を \[0.0, 1.0\] の範囲にクランプします。テクスチャを一度適用してから、エッジ ピクセルの色を付けます。 |
| Border Color (境界線の色)            | *境界線の色*として知られる任意のカラーを、0.0 ～ 1.0 の範囲外のテクスチャ座標に対して使用します。                         |

 

## <a name="span-idwraptextureaddressmodespanspan-idwraptextureaddressmodespanspan-idwraptextureaddressmodespanwrap-texture-address-mode"></a><span id="Wrap_texture_address_mode"></span><span id="wrap_texture_address_mode"></span><span id="WRAP_TEXTURE_ADDRESS_MODE"></span>ラップ テクスチャ アドレス モード


ラップ テクスチャ アドレス モードでは、Direct3D はすべての整数接合点でテクスチャを繰り返します。

たとえば、アプリケーションで正方形のプリミティブを作成し、(0.0,0.0)、(0.0,3.0)、(3.0,3.0)、および (3.0,0.0) のテクスチャ座標を指定するとします。 テクスチャのアドレス指定モードを "Wrap" に設定すると、次の図に示すように、テクスチャは u 方向と v 方向の両方で 3 回適用されます。

![u 方向と v 方向にラップされた顔のテクスチャの図](images/wrap.png)

このモードを、次の**ミラー テクスチャ アドレス モード**と区別してください。

## <a name="span-idmirrortextureaddressmodespanspan-idmirrortextureaddressmodespanspan-idmirrortextureaddressmodespanmirror-texture-address-mode"></a><span id="Mirror_texture_address_mode"></span><span id="mirror_texture_address_mode"></span><span id="MIRROR_TEXTURE_ADDRESS_MODE"></span>ミラー テクスチャ アドレス モード


ミラー テクスチャ アドレス モードでは、Direct3D はすべての整数境界でテクスチャをミラーリングします。

たとえば、アプリケーションで正方形のプリミティブを作成し、(0.0,0.0)、(0.0,3.0)、(3.0,3.0)、および (3.0,0.0) のテクスチャ座標を指定するとします。 テクスチャのアドレス指定モードを "Mirror" に設定すると、テクスチャは u 方向と v 方向の両方で 3 回適用されます。 次の図に示すように、これが適用される行と列はすべて、先行する行または列のミラー イメージです。

![3 x 3 グリッドのミラー イメージの図](images/mirror.png)

このモードを、前の**ラップ テクスチャ アドレス モード**と区別してください。

## <a name="span-idclamptextureaddressmodespanspan-idclamptextureaddressmodespanspan-idclamptextureaddressmodespanclamp-texture-address-mode"></a><span id="Clamp_texture_address_mode"></span><span id="clamp_texture_address_mode"></span><span id="CLAMP_TEXTURE_ADDRESS_MODE"></span>クランプ テクスチャ アドレス モード


クランプ テクスチャ アドレス モードでは、Direct3D はテクスチャ座標を \[0.0, 1.0\] の範囲にクランプします。テクスチャを一度適用してから、エッジ ピクセルの色を付けます。

たとえば、アプリケーションで正方形のプリミティブを作成し、(0.0,0.0)、(0.0,3.0)、(3.0,3.0)、および (3.0,0.0) のテクスチャ座標をプリミティブの頂点に割り当てるとします。 テクスチャ アドレス指定モードを "Clamp" に設定すると、テクスチャは一度適用されます。 列の最上部と行の最後にあるピクセル カラーが、それぞれプリミティブの上と右に拡張されます。

次の図に、クランプされたテクスチャを示します。

![テクスチャとクランプされたテクスチャの図](images/clamp.png)

## <a name="span-idbordercolortextureaddressmodespanspan-idbordercolortextureaddressmodespanspan-idbordercolortextureaddressmodespanborder-color-texture-address-mode"></a><span id="Border_Color_texture_address_mode"></span><span id="border_color_texture_address_mode"></span><span id="BORDER_COLOR_TEXTURE_ADDRESS_MODE"></span>境界線の色テクスチャ アドレス モード


境界線の色テクスチャ アドレス モードでは、Direct3D は*境界線の色*として知られる任意のカラーを、0.0 ～ 1.0 の範囲外のテクスチャ座標に対して使用します。

これを以下の図に示します。アプリケーションは赤い境界線を使用してプリミティブに適用されるテクスチャを指定しています。

![テクスチャと赤い境界線のテクスチャの図](images/border.png)

## <a name="span-iddevicelimitationsspanspan-iddevicelimitationsspanspan-iddevicelimitationsspandevice-limitations"></a><span id="Device_Limitations"></span><span id="device_limitations"></span><span id="DEVICE_LIMITATIONS"></span>デバイスの制限


一般に、0.0 ～ 1.0 の範囲外のテクスチャ座標も許可されますが、その範囲からテクスチャ座標がどの程度はずれることが可能かは、ほとんどがハードウェアの制限によって変わってきます。 デバイスの機能が取得されると、レンダリング デバイスは、デバイスに許可されているテクスチャ座標の全範囲の制限を伝えます。

たとえば、この値が 128 の場合、入力テクスチャ座標は -128.0 ～ +128.0 の範囲を保つ必要があります。 この範囲外のテクスチャ座標を持つ頂点を渡すことは無効です。 同じ制限は、自動的なテクスチャ座標生成とテクスチャ座標変換の結果として生成されるテクスチャ座標にも適用されます。

テクスチャの繰り返しの制限は、テクスチャ座標によってインデックスされるテクスチャのサイズによって異なります。 たとえば、テクスチャの寸法が 32 で、デバイスに許可されるテクスチャ座標の範囲が 512 とすると、実際の有効なテクスチャ座標範囲は 512/32 = 16 となり、このデバイスのテクスチャ座標は -16.0 ～ +16.0 の範囲内にある必要があります。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャ](textures.md)

 

 




