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
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0e817dcc92741ca2e738784f387cfe49399a108c
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5880135"
---
# <a name="texture-addressing-modes"></a><span data-ttu-id="1032f-108">テクスチャのアドレス指定モード</span><span class="sxs-lookup"><span data-stu-id="1032f-108">Texture addressing modes</span></span>


<span data-ttu-id="1032f-109">Direct3D アプリケーションは、任意のプリミティブの頂点テクスチャ座標を割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="1032f-109">Your Direct3D application can assign texture coordinates to any vertex of any primitive.</span></span> <span data-ttu-id="1032f-110">通常、頂点に割り当てるテクスチャ座標 (u, v) は 0.0 ～ 1.0 (両端含む) の範囲です。</span><span class="sxs-lookup"><span data-stu-id="1032f-110">Typically, the u- and v-texture coordinates that you assign to a vertex are in the range of 0.0 to 1.0 inclusive.</span></span> <span data-ttu-id="1032f-111">ただし、その範囲外のテクスチャ座標を割り当てることで、テクスチャリングの特殊効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="1032f-111">However, by assigning texture coordinates outside that range, you can create certain special texturing effects.</span></span> <span data-ttu-id="1032f-112">.</span><span class="sxs-lookup"><span data-stu-id="1032f-112">.</span></span>

<span data-ttu-id="1032f-113">テクスチャのアドレス指定モードを設定すると、\[0.0, 1.0\] の範囲外にあるテクスチャ座標で Direct3D が実行することを制御できます。</span><span class="sxs-lookup"><span data-stu-id="1032f-113">You control what Direct3D does with texture coordinates that are outside the \[0.0, 1.0\] range by setting the texture addressing mode.</span></span> <span data-ttu-id="1032f-114">たとえば、テクスチャがプリミティブ全体でタイル化されるようにアプリケーションにテクスチャのアドレス指定モードを設定させることができます。</span><span class="sxs-lookup"><span data-stu-id="1032f-114">For instance, you can have your application set the texture addressing mode so that a texture is tiled across a primitive.</span></span>

<span data-ttu-id="1032f-115">Direct3D では、アプリケーションでテクスチャの折り返しを実行できます。</span><span class="sxs-lookup"><span data-stu-id="1032f-115">Direct3D enables applications to perform texture wrapping.</span></span> <span data-ttu-id="1032f-116">「[テクスチャの折り返し](texture-wrapping.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1032f-116">See [Texture wrapping](texture-wrapping.md).</span></span>

<span data-ttu-id="1032f-117">テクスチャの折り返しを有効にすると、\[0.0, 1.0\] の範囲外のテクスチャ座標は無効になり、その場合は延滞テクスチャ座標などのラスター化の動作は未定義になります。</span><span class="sxs-lookup"><span data-stu-id="1032f-117">Enabling texture wrapping effectively makes texture coordinates outside the \[0.0, 1.0\] range invalid, and the behavior for rasterizing such delinquent texture coordinates is undefined in this case.</span></span> <span data-ttu-id="1032f-118">テクスチャの折り返しを有効にすると、テクスチャのアドレス指定モードは使用されません。</span><span class="sxs-lookup"><span data-stu-id="1032f-118">When texture wrapping is enabled, texture addressing modes are not used.</span></span> <span data-ttu-id="1032f-119">テクスチャの折り返しが有効なときは、アプリケーションで 0.0 未満または 1.0 を上回るテクスチャ座標を指定しないように気をつけてください。</span><span class="sxs-lookup"><span data-stu-id="1032f-119">Take care that your application does not specify texture coordinates lower than 0.0 or higher than 1.0 when texture wrapping is enabled.</span></span>

## <a name="span-idsummaryofthetextureaddressingmodesspanspan-idsummaryofthetextureaddressingmodesspanspan-idsummaryofthetextureaddressingmodesspansummary-of-the-texture-addressing-modes"></a><span data-ttu-id="1032f-120"><span id="Summary_of_the_texture_addressing_modes"></span><span id="summary_of_the_texture_addressing_modes"></span><span id="SUMMARY_OF_THE_TEXTURE_ADDRESSING_MODES"></span>テクスチャのアドレス指定モードの概要</span><span class="sxs-lookup"><span data-stu-id="1032f-120"><span id="Summary_of_the_texture_addressing_modes"></span><span id="summary_of_the_texture_addressing_modes"></span><span id="SUMMARY_OF_THE_TEXTURE_ADDRESSING_MODES"></span>Summary of the texture addressing modes</span></span>


| <span data-ttu-id="1032f-121">テクスチャのアドレス指定モード</span><span class="sxs-lookup"><span data-stu-id="1032f-121">Texture addressing mode</span></span> | <span data-ttu-id="1032f-122">説明</span><span class="sxs-lookup"><span data-stu-id="1032f-122">Description</span></span>                                                                                                                           |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="1032f-123">Wrap (ラップ)</span><span class="sxs-lookup"><span data-stu-id="1032f-123">Wrap</span></span>                    | <span data-ttu-id="1032f-124">すべての整数接合点でテクスチャを繰り返します。</span><span class="sxs-lookup"><span data-stu-id="1032f-124">Repeats the texture on every integer junction.</span></span>                                                                                        |
| <span data-ttu-id="1032f-125">Mirror (ミラー)</span><span class="sxs-lookup"><span data-stu-id="1032f-125">Mirror</span></span>                  | <span data-ttu-id="1032f-126">すべての整数境界でテクスチャをミラーリングします。</span><span class="sxs-lookup"><span data-stu-id="1032f-126">Mirrors the texture at every integer boundary.</span></span>                                                                                        |
| <span data-ttu-id="1032f-127">Clamp (クランプ)</span><span class="sxs-lookup"><span data-stu-id="1032f-127">Clamp</span></span>                   | <span data-ttu-id="1032f-128">テクスチャ座標を \[0.0, 1.0\] の範囲にクランプします。テクスチャを一度適用してから、エッジ ピクセルの色を付けます。</span><span class="sxs-lookup"><span data-stu-id="1032f-128">Clamps your texture coordinates to the \[0.0, 1.0\] range; Clamp mode applies the texture once, then smears the color of edge pixels.</span></span> |
| <span data-ttu-id="1032f-129">Border Color (境界線の色)</span><span class="sxs-lookup"><span data-stu-id="1032f-129">Border Color</span></span>            | <span data-ttu-id="1032f-130">*境界線の色*として知られる任意のカラーを、0.0 ～ 1.0 の範囲外のテクスチャ座標に対して使用します。</span><span class="sxs-lookup"><span data-stu-id="1032f-130">Uses an arbitrary *border color* for any texture coordinates outside the range of 0.0 through 1.0, inclusive.</span></span>                         |

 

## <a name="span-idwraptextureaddressmodespanspan-idwraptextureaddressmodespanspan-idwraptextureaddressmodespanwrap-texture-address-mode"></a><span data-ttu-id="1032f-131"><span id="Wrap_texture_address_mode"></span><span id="wrap_texture_address_mode"></span><span id="WRAP_TEXTURE_ADDRESS_MODE"></span>ラップ テクスチャ アドレス モード</span><span class="sxs-lookup"><span data-stu-id="1032f-131"><span id="Wrap_texture_address_mode"></span><span id="wrap_texture_address_mode"></span><span id="WRAP_TEXTURE_ADDRESS_MODE"></span>Wrap texture address mode</span></span>


<span data-ttu-id="1032f-132">ラップ テクスチャ アドレス モードでは、Direct3D はすべての整数接合点でテクスチャを繰り返します。</span><span class="sxs-lookup"><span data-stu-id="1032f-132">The Wrap texture address mode makes Direct3D repeat the texture on every integer junction.</span></span>

<span data-ttu-id="1032f-133">たとえば、アプリケーションで正方形のプリミティブを作成し、(0.0,0.0)、(0.0,3.0)、(3.0,3.0)、および (3.0,0.0) のテクスチャ座標を指定するとします。</span><span class="sxs-lookup"><span data-stu-id="1032f-133">Suppose, for example, your application creates a square primitive and specifies texture coordinates of (0.0,0.0), (0.0,3.0), (3.0,3.0), and (3.0,0.0).</span></span> <span data-ttu-id="1032f-134">テクスチャのアドレス指定モードを "Wrap" に設定すると、次の図に示すように、テクスチャは u 方向と v 方向の両方で 3 回適用されます。</span><span class="sxs-lookup"><span data-stu-id="1032f-134">Setting the texture addressing mode to "Wrap" results in the texture being applied three times in both the u-and v-directions, as shown in the following illustration.</span></span>

![u 方向と v 方向にラップされた顔のテクスチャの図](images/wrap.png)

<span data-ttu-id="1032f-136">このモードを、次の**ミラー テクスチャ アドレス モード**と区別してください。</span><span class="sxs-lookup"><span data-stu-id="1032f-136">Contrast this with the following **Mirror texture address mode**.</span></span>

## <a name="span-idmirrortextureaddressmodespanspan-idmirrortextureaddressmodespanspan-idmirrortextureaddressmodespanmirror-texture-address-mode"></a><span data-ttu-id="1032f-137"><span id="Mirror_texture_address_mode"></span><span id="mirror_texture_address_mode"></span><span id="MIRROR_TEXTURE_ADDRESS_MODE"></span>ミラー テクスチャ アドレス モード</span><span class="sxs-lookup"><span data-stu-id="1032f-137"><span id="Mirror_texture_address_mode"></span><span id="mirror_texture_address_mode"></span><span id="MIRROR_TEXTURE_ADDRESS_MODE"></span>Mirror texture address mode</span></span>


<span data-ttu-id="1032f-138">ミラー テクスチャ アドレス モードでは、Direct3D はすべての整数境界でテクスチャをミラーリングします。</span><span class="sxs-lookup"><span data-stu-id="1032f-138">The Mirror texture address mode causes Direct3D to mirror the texture at every integer boundary.</span></span>

<span data-ttu-id="1032f-139">たとえば、アプリケーションで正方形のプリミティブを作成し、(0.0,0.0)、(0.0,3.0)、(3.0,3.0)、および (3.0,0.0) のテクスチャ座標を指定するとします。</span><span class="sxs-lookup"><span data-stu-id="1032f-139">Suppose, for example, your application creates a square primitive and specifies texture coordinates of (0.0,0.0), (0.0,3.0), (3.0,3.0), and (3.0,0.0).</span></span> <span data-ttu-id="1032f-140">テクスチャのアドレス指定モードを "Mirror" に設定すると、テクスチャは u 方向と v 方向の両方で 3 回適用されます。</span><span class="sxs-lookup"><span data-stu-id="1032f-140">Setting the texture addressing mode to "Mirror" results in the texture being applied three times in both the u- and v-directions.</span></span> <span data-ttu-id="1032f-141">次の図に示すように、これが適用される行と列はすべて、先行する行または列のミラー イメージです。</span><span class="sxs-lookup"><span data-stu-id="1032f-141">Every other row and column that it is applied to is a mirror image of the preceding row or column, as shown in the following illustration.</span></span>

![3 x 3 グリッドのミラー イメージの図](images/mirror.png)

<span data-ttu-id="1032f-143">このモードを、前の**ラップ テクスチャ アドレス モード**と区別してください。</span><span class="sxs-lookup"><span data-stu-id="1032f-143">Contrast this with the previous **Wrap texture address mode**.</span></span>

## <a name="span-idclamptextureaddressmodespanspan-idclamptextureaddressmodespanspan-idclamptextureaddressmodespanclamp-texture-address-mode"></a><span data-ttu-id="1032f-144"><span id="Clamp_texture_address_mode"></span><span id="clamp_texture_address_mode"></span><span id="CLAMP_TEXTURE_ADDRESS_MODE"></span>クランプ テクスチャ アドレス モード</span><span class="sxs-lookup"><span data-stu-id="1032f-144"><span id="Clamp_texture_address_mode"></span><span id="clamp_texture_address_mode"></span><span id="CLAMP_TEXTURE_ADDRESS_MODE"></span>Clamp texture address mode</span></span>


<span data-ttu-id="1032f-145">クランプ テクスチャ アドレス モードでは、Direct3D はテクスチャ座標を \[0.0, 1.0\] の範囲にクランプします。テクスチャを一度適用してから、エッジ ピクセルの色を付けます。</span><span class="sxs-lookup"><span data-stu-id="1032f-145">The Clamp texture address mode causes Direct3D to clamp your texture coordinates to the \[0.0, 1.0\] range; Clamp mode applies the texture once, then smears the color of edge pixels.</span></span>

<span data-ttu-id="1032f-146">たとえば、アプリケーションで正方形のプリミティブを作成し、(0.0,0.0)、(0.0,3.0)、(3.0,3.0)、および (3.0,0.0) のテクスチャ座標をプリミティブの頂点に割り当てるとします。</span><span class="sxs-lookup"><span data-stu-id="1032f-146">Suppose that your application creates a square primitive and assigns texture coordinates of (0.0,0.0), (0.0,3.0), (3.0,3.0), and (3.0,0.0) to the primitive's vertices.</span></span> <span data-ttu-id="1032f-147">テクスチャ アドレス指定モードを "Clamp" に設定すると、テクスチャは一度適用されます。</span><span class="sxs-lookup"><span data-stu-id="1032f-147">Setting the texture addressing mode to "Clamp" results in the texture being applied once.</span></span> <span data-ttu-id="1032f-148">列の最上部と行の最後にあるピクセル カラーが、それぞれプリミティブの上と右に拡張されます。</span><span class="sxs-lookup"><span data-stu-id="1032f-148">The pixel colors at the top of the columns and the end of the rows are extended to the top and right of the primitive respectively.</span></span>

<span data-ttu-id="1032f-149">次の図に、クランプされたテクスチャを示します。</span><span class="sxs-lookup"><span data-stu-id="1032f-149">The following illustration shows a clamped texture.</span></span>

![テクスチャとクランプされたテクスチャの図](images/clamp.png)

## <a name="span-idbordercolortextureaddressmodespanspan-idbordercolortextureaddressmodespanspan-idbordercolortextureaddressmodespanborder-color-texture-address-mode"></a><span data-ttu-id="1032f-151"><span id="Border_Color_texture_address_mode"></span><span id="border_color_texture_address_mode"></span><span id="BORDER_COLOR_TEXTURE_ADDRESS_MODE"></span>境界線の色テクスチャ アドレス モード</span><span class="sxs-lookup"><span data-stu-id="1032f-151"><span id="Border_Color_texture_address_mode"></span><span id="border_color_texture_address_mode"></span><span id="BORDER_COLOR_TEXTURE_ADDRESS_MODE"></span>Border Color texture address mode</span></span>


<span data-ttu-id="1032f-152">境界線の色テクスチャ アドレス モードでは、Direct3D は*境界線の色*として知られる任意のカラーを、0.0 ～ 1.0 の範囲外のテクスチャ座標に対して使用します。</span><span class="sxs-lookup"><span data-stu-id="1032f-152">The Border Color texture address mode causes Direct3D to use an arbitrary color, known as the *border color*, for any texture coordinates outside the range of 0.0 through 1.0, inclusive.</span></span>

<span data-ttu-id="1032f-153">これを以下の図に示します。アプリケーションは赤い境界線を使用してプリミティブに適用されるテクスチャを指定しています。</span><span class="sxs-lookup"><span data-stu-id="1032f-153">In the following illustration, the application specifies that the texture be applied to the primitive using a red border.</span></span>

![テクスチャと赤い境界線のテクスチャの図](images/border.png)

## <a name="span-iddevicelimitationsspanspan-iddevicelimitationsspanspan-iddevicelimitationsspandevice-limitations"></a><span data-ttu-id="1032f-155"><span id="Device_Limitations"></span><span id="device_limitations"></span><span id="DEVICE_LIMITATIONS"></span>デバイスの制限</span><span class="sxs-lookup"><span data-stu-id="1032f-155"><span id="Device_Limitations"></span><span id="device_limitations"></span><span id="DEVICE_LIMITATIONS"></span>Device limitations</span></span>


<span data-ttu-id="1032f-156">一般に、0.0 ～ 1.0 の範囲外のテクスチャ座標も許可されますが、その範囲からテクスチャ座標がどの程度はずれることが可能かは、ほとんどがハードウェアの制限によって変わってきます。</span><span class="sxs-lookup"><span data-stu-id="1032f-156">Although the system generally allows texture coordinates outside the range of 0.0 and 1.0, inclusive, hardware limitations often affect how far outside that range texture coordinates can be.</span></span> <span data-ttu-id="1032f-157">デバイスの機能が取得されると、レンダリング デバイスは、デバイスに許可されているテクスチャ座標の全範囲の制限を伝えます。</span><span class="sxs-lookup"><span data-stu-id="1032f-157">A rendering device communicates the limit for the full range of texture coordinates allowed by the device, when you retrieve the device's capabilities.</span></span>

<span data-ttu-id="1032f-158">たとえば、この値が 128 の場合、入力テクスチャ座標は -128.0 ～ +128.0 の範囲を保つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="1032f-158">For instance, if this value is 128, then the input texture coordinates must be kept in the range -128.0 to +128.0.</span></span> <span data-ttu-id="1032f-159">この範囲外のテクスチャ座標を持つ頂点を渡すことは無効です。</span><span class="sxs-lookup"><span data-stu-id="1032f-159">Passing vertices with texture coordinates outside this range is invalid.</span></span> <span data-ttu-id="1032f-160">同じ制限は、自動的なテクスチャ座標生成とテクスチャ座標変換の結果として生成されるテクスチャ座標にも適用されます。</span><span class="sxs-lookup"><span data-stu-id="1032f-160">The same restriction applies to the texture coordinates generated as a result of automatic texture coordinate generation and texture coordinate transformations.</span></span>

<span data-ttu-id="1032f-161">テクスチャの繰り返しの制限は、テクスチャ座標によってインデックスされるテクスチャのサイズによって異なります。</span><span class="sxs-lookup"><span data-stu-id="1032f-161">Texture repeating limitations can depend on the size of the texture indexed by the texture coordinates.</span></span> <span data-ttu-id="1032f-162">たとえば、テクスチャの寸法が 32 で、デバイスに許可されるテクスチャ座標の範囲が 512 とすると、実際の有効なテクスチャ座標範囲は 512/32 = 16 となり、このデバイスのテクスチャ座標は -16.0 ～ +16.0 の範囲内にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="1032f-162">In that case, supposing the texture dimension is 32, and the range of texture coordinates allowed by the device is 512, the actual valid texture coordinate range would therefore be 512/32 = 16, so the texture coordinates for this device must be within the range of -16.0 to +16.0.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1032f-163"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1032f-163"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1032f-164">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="1032f-164">Textures</span></span>](textures.md)

 

 




