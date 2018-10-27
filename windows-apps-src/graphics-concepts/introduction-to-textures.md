---
title: テクスチャの概要
description: テクスチャ リソースはテクセルを保存するデータ構造で、読み書きできるテクスチャの最小単位です。 テクスチャがシェーダーにより読み取られる際、テクスチャ サンプラーでフィルターを適用することができます。
ms.assetid: 6F3C76A8-F762-4296-AE02-BFBD6476A5A8
keywords:
- テクスチャの概要
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: f88cccc3f32449d09c01450bf159b3fca6a3d59f
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5689644"
---
# <a name="introduction-to-textures"></a><span data-ttu-id="8364b-105">テクスチャの概要</span><span class="sxs-lookup"><span data-stu-id="8364b-105">Introduction to textures</span></span>


<span data-ttu-id="8364b-106">テクスチャ リソースはテクセルを保存するデータ構造で、読み書きできるテクスチャの最小単位です。</span><span class="sxs-lookup"><span data-stu-id="8364b-106">A texture resource is a data structure to store texels, which are the smallest unit of a texture that can be read or written to.</span></span> <span data-ttu-id="8364b-107">テクスチャがシェーダーにより読み取られる際、テクスチャ サンプラーでフィルターを適用することができます。</span><span class="sxs-lookup"><span data-stu-id="8364b-107">When the texture is read by a shader, it can be filtered by texture samplers.</span></span>

<span data-ttu-id="8364b-108">テクスチャ リソースは、テクセルを格納するように設計された、データの構造化されたコレクションです。</span><span class="sxs-lookup"><span data-stu-id="8364b-108">A texture resource is a structured collection of data designed to store texels.</span></span> <span data-ttu-id="8364b-109">テクセルは、パイプラインで読み取ったり、書き込んだりすることができるテクスチャの最小単位を表します。</span><span class="sxs-lookup"><span data-stu-id="8364b-109">A texel represents the smallest unit of a texture that can be read or written to by the pipeline.</span></span> <span data-ttu-id="8364b-110">バッファーと異なり、テクスチャは、シェーダー ユニットに読み取られる際にテクスチャ サンプラーでフィルターを適用することができます。</span><span class="sxs-lookup"><span data-stu-id="8364b-110">Unlike buffers, textures can be filtered by texture samplers as they are read by shader units.</span></span> <span data-ttu-id="8364b-111">テクスチャへのフィルター処理の適用方法はテクスチャの種類に影響されます。</span><span class="sxs-lookup"><span data-stu-id="8364b-111">The type of texture impacts how the texture is filtered.</span></span> <span data-ttu-id="8364b-112">各テクセルは 1 ～ 4 つの成分を含み、DXGI\_FORMAT 列挙値により定義された DXGI 形式のいずれかで配置されます。</span><span class="sxs-lookup"><span data-stu-id="8364b-112">Each texel contains 1 to 4 components, arranged in one of the DXGI formats defined by the DXGI\_FORMAT enumeration.</span></span>

<span data-ttu-id="8364b-113">テクスチャは構造化されたリソースとして、既知のサイズで作成されます。</span><span class="sxs-lookup"><span data-stu-id="8364b-113">Textures are created as a structured resource with a known size.</span></span> <span data-ttu-id="8364b-114">ただし、各テクスチャはリソースの作成時に型指定される場合もありますが、テクスチャをパイプラインにバインドするときにビューを使用して型を完全に指定するという条件で、リソース作成時に型指定されない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="8364b-114">However, each texture may be typed or typeless when the resource is created as long as the type is fully specified using a view when the texture is bound to the pipeline.</span></span>

## <a name="span-idtexturetypesspanspan-idtexturetypesspanspan-idtexturetypesspantexture-types"></a><span data-ttu-id="8364b-115"><span id="Texture_Types"></span><span id="texture_types"></span><span id="TEXTURE_TYPES"></span>テクスチャの種類</span><span class="sxs-lookup"><span data-stu-id="8364b-115"><span id="Texture_Types"></span><span id="texture_types"></span><span id="TEXTURE_TYPES"></span>Texture Types</span></span>


<span data-ttu-id="8364b-116">Direct3D は、複数の浮動小数点表現をサポートします。</span><span class="sxs-lookup"><span data-stu-id="8364b-116">Direct3D supports several floating-point representations.</span></span> <span data-ttu-id="8364b-117">すべての浮動小数点計算は、IEEE 754 32 ビット単精度浮動小数点ルールの定義済みサブセット下で実行されます。</span><span class="sxs-lookup"><span data-stu-id="8364b-117">All floating-point computations operate under a defined subset of the IEEE 754 32-bit single precision floating-point rules.</span></span>

<span data-ttu-id="8364b-118">テクスチャの種類には 1D、2D、および 3D があり、それぞれミップマップ付きまたはミップマップなしで作成できます。</span><span class="sxs-lookup"><span data-stu-id="8364b-118">There are several types of textures: 1D, 2D, 3D, each of which can be created with or without mipmaps.</span></span> <span data-ttu-id="8364b-119">Direct3D では、テクスチャ配列とマルチサンプリングされたテクスチャもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="8364b-119">Direct3D also supports texture arrays and multisampled textures.</span></span>

-   [<span data-ttu-id="8364b-120">1D テクスチャ</span><span class="sxs-lookup"><span data-stu-id="8364b-120">1D Textures</span></span>](#texture1d-resource)
-   [<span data-ttu-id="8364b-121">1D テクスチャ配列</span><span class="sxs-lookup"><span data-stu-id="8364b-121">1D Texture Arrays</span></span>](#texture1d-array-resource)
-   [<span data-ttu-id="8364b-122">2D テクスチャと 2D テクスチャ配列</span><span class="sxs-lookup"><span data-stu-id="8364b-122">2D Textures and 2D Texture Arrays</span></span>](#texture2d-resource)
-   [<span data-ttu-id="8364b-123">3D テクスチャ</span><span class="sxs-lookup"><span data-stu-id="8364b-123">3D Textures</span></span>](#texture3d-resource)

### <a name="span-idtexture1dresourcespanspan-idtexture1dresourcespanspan-idtexture1dresourcespanspan-idtexture1d-resourcespan1d-textures"></a><span data-ttu-id="8364b-124"><span id="Texture1D_Resource"></span><span id="texture1d_resource"></span><span id="TEXTURE1D_RESOURCE"></span><span id="texture1d-resource"></span>1D テクスチャ</span><span class="sxs-lookup"><span data-stu-id="8364b-124"><span id="Texture1D_Resource"></span><span id="texture1d_resource"></span><span id="TEXTURE1D_RESOURCE"></span><span id="texture1d-resource"></span>1D Textures</span></span>

<span data-ttu-id="8364b-125">最も単純な形式の 1D テクスチャには、1 つのテクスチャ座標で処理できるテクスチャ データが格納されます。これをテクセルの配列として視覚化すると次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="8364b-125">A 1D texture in its simplest form contains texture data that can be addressed with a single texture coordinate; it can be visualized as an array of texels, as shown in the following illustration.</span></span>

<span data-ttu-id="8364b-126">次の図に 1D テクスチャを示します。</span><span class="sxs-lookup"><span data-stu-id="8364b-126">The following illustration shows a 1D texture:</span></span>

![1D テクスチャ](images/d3d10-1d-texture.png)

<span data-ttu-id="8364b-128">各テクセルには、格納されているデータ形式に応じた色成分がいくつか含まれます。</span><span class="sxs-lookup"><span data-stu-id="8364b-128">Each texel contains a number of color components depending on the format of the data stored.</span></span> <span data-ttu-id="8364b-129">より複雑なものになると、次の図に示すように、ミップマップ レベルを持つ 1D テクスチャを作成できます。</span><span class="sxs-lookup"><span data-stu-id="8364b-129">Adding more complexity, you can create a 1D texture with mipmap levels, as shown in the following illustration.</span></span>

![ミップマップ レベルを持つ 1D テクスチャ](images/d3d10-resource-texture1d.png)

<span data-ttu-id="8364b-131">ミップマップ レベルは、上のレベルよりも 2 の累乗だけ小さいテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="8364b-131">A mipmap level is a texture that is a power-of-two smaller than the level above it.</span></span> <span data-ttu-id="8364b-132">最上位レベルが最も詳細で (大きく)、レベルが下がるほど小さくなります。</span><span class="sxs-lookup"><span data-stu-id="8364b-132">The topmost level contains the most detail, each subsequent level is smaller.</span></span> <span data-ttu-id="8364b-133">1D ミップマップの最小レベルはテクセルを 1 つだけ含みます。</span><span class="sxs-lookup"><span data-stu-id="8364b-133">For a 1D mipmap, the smallest level contains one texel.</span></span> <span data-ttu-id="8364b-134">さらに、MIP レベルは常に 1:1 まで下がります。</span><span class="sxs-lookup"><span data-stu-id="8364b-134">Furthermore, MIP levels always reduce down to 1:1.</span></span>

<span data-ttu-id="8364b-135">ミップマップが奇数サイズのテクスチャに生成された場合、1 つ下のレベルは必ず偶数サイズになります (最下位レベルが 1 に達した場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="8364b-135">When mipmaps are generated for an odd sized texture, the next lower level is always even size (except when the lowest level reaches 1).</span></span> <span data-ttu-id="8364b-136">たとえば、この図は次の最下位レベルが 2x1 テクスチャである 5x1 テクスチャを示しており、次の (および最後の) ミップ レベルは 1x1 サイズのテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="8364b-136">For example, the diagram illustrates a 5x1 texture whose next lowest level is a 2x1 texture, whose next (and last) mip level is a 1x1 sized texture.</span></span> <span data-ttu-id="8364b-137">レベルの識別には詳細レベル (LOD) と呼ばれるインデックスを使用します。LOD は、カメラにそれほど近くないジオメトリをレンダリングする場合に、小さいテクスチャにアクセスするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="8364b-137">The levels are identified by an index called a LOD (level-of-detail) which is used to access the smaller texture when rendering geometry that is not as close to the camera.</span></span>

### <a name="span-idtexture1darrayresourcespanspan-idtexture1darrayresourcespanspan-idtexture1darrayresourcespanspan-idtexture1d-array-resourcespan1d-texture-arrays"></a><span data-ttu-id="8364b-138"><span id="Texture1D_Array_Resource"></span><span id="texture1d_array_resource"></span><span id="TEXTURE1D_ARRAY_RESOURCE"></span><span id="texture1d-array-resource"></span>1D テクスチャ配列</span><span class="sxs-lookup"><span data-stu-id="8364b-138"><span id="Texture1D_Array_Resource"></span><span id="texture1d_array_resource"></span><span id="TEXTURE1D_ARRAY_RESOURCE"></span><span id="texture1d-array-resource"></span>1D Texture Arrays</span></span>

<span data-ttu-id="8364b-139">Direct3D は、テクスチャの配列もサポートします。</span><span class="sxs-lookup"><span data-stu-id="8364b-139">Direct3D also supports arrays of textures.</span></span> <span data-ttu-id="8364b-140">1D テクスチャの配列は概念的に次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="8364b-140">An array of 1D textures looks conceptually like the following illustration.</span></span>

![1D テクスチャの配列](images/d3d10-resource-texture1darray.png)

<span data-ttu-id="8364b-142">このテクスチャ配列には 3 つのテクスチャが含まれています。</span><span class="sxs-lookup"><span data-stu-id="8364b-142">This texture array contains three textures.</span></span> <span data-ttu-id="8364b-143">3 つのテクスチャはそれぞれテクスチャ幅が 5 になっています (5 は最初のレイヤーの要素数)。</span><span class="sxs-lookup"><span data-stu-id="8364b-143">Each of the three textures has a texture width of 5 (which is the number of elements in the first layer).</span></span> <span data-ttu-id="8364b-144">また、各テクスチャには 3 レイヤーのミップマップも格納されています。</span><span class="sxs-lookup"><span data-stu-id="8364b-144">Each texture also contains a 3 layer mipmap.</span></span>

<span data-ttu-id="8364b-145">Direct3D のすべてのテクスチャ配列は、テクスチャの同次配列です。つまり、1 つのテクスチャ配列内にあるテクスチャはすべて、データ形式とサイズが (テクスチャ幅とミップマップ レベル数も含めて) 同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="8364b-145">All texture arrays in Direct3D are a homogeneous array of textures; this means that every texture in a texture array must have the same data format and size (including texture width and number of mipmap levels).</span></span> <span data-ttu-id="8364b-146">各配列に含まれるすべてのテクスチャのサイズが一致してさえいれば、さまざまなサイズのテクスチャ配列を作成できます。</span><span class="sxs-lookup"><span data-stu-id="8364b-146">You may create texture arrays of different sizes, as long as all the textures in each array match in size.</span></span>

### <a name="span-idtexture2dresourcespanspan-idtexture2dresourcespanspan-idtexture2dresourcespanspan-idtexture2d-resourcespan2d-textures-and-2d-texture-arrays"></a><span data-ttu-id="8364b-147"><span id="Texture2D_Resource"></span><span id="texture2d_resource"></span><span id="TEXTURE2D_RESOURCE"></span><span id="texture2d-resource"></span>2D テクスチャと 2D テクスチャ配列</span><span class="sxs-lookup"><span data-stu-id="8364b-147"><span id="Texture2D_Resource"></span><span id="texture2d_resource"></span><span id="TEXTURE2D_RESOURCE"></span><span id="texture2d-resource"></span>2D Textures and 2D Texture Arrays</span></span>

<span data-ttu-id="8364b-148">Texture2D リソースにはテクセルの 2D グリッドが 1 つ含まれています。</span><span class="sxs-lookup"><span data-stu-id="8364b-148">A Texture2D resource contains a 2D grid of texels.</span></span> <span data-ttu-id="8364b-149">各テクセルは u ベクトルと v ベクトルで指定できます。</span><span class="sxs-lookup"><span data-stu-id="8364b-149">Each texel is addressable by a u, v vector.</span></span> <span data-ttu-id="8364b-150">これはテクスチャ リソースであるため、ミップマップ レベルとサブリソースが格納される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="8364b-150">Since it is a texture resource, it may contain mipmap levels, and subresources.</span></span> <span data-ttu-id="8364b-151">すべてのデータが設定された 2D テクスチャ リソースは次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="8364b-151">A fully populated 2D texture resource looks like the following illustration.</span></span>

![2D テクスチャ リソース](images/d3d10-resource-texture2d.png)

<span data-ttu-id="8364b-153">このテクスチャ リソースには 1 つの 3x5 テクスチャと 3 つのミップマップ レベルが格納されています。</span><span class="sxs-lookup"><span data-stu-id="8364b-153">This texture resource contains a single 3x5 texture with three mipmap levels.</span></span>

<span data-ttu-id="8364b-154">2D テクスチャ リソースは 2D テクスチャの同次配列であるため、各テクスチャのデータ形式とサイズは (ミップマップ レベルを含めて) 同じです。</span><span class="sxs-lookup"><span data-stu-id="8364b-154">A 2D texture array resource is a homogeneous array of 2D textures; that is, each texture has the same data format and dimensions (including mipmap levels).</span></span> <span data-ttu-id="8364b-155">次の図に示すように、このリソースはテクスチャに 2D データが含まれていることを除けば 1D テクスチャ配列とレイアウトが似ています。</span><span class="sxs-lookup"><span data-stu-id="8364b-155">It has a similar layout as the 1D texture array except that the textures now contain 2D data, as shown in the following illustration.</span></span>

![2D テクスチャの配列](images/d3d10-resource-texture2darray.png)

<span data-ttu-id="8364b-157">このテクスチャ配列には 3 つのテクスチャが含まれています。各テクスチャは 3x5 で、2 つのミップマップ レベルを持ちます。</span><span class="sxs-lookup"><span data-stu-id="8364b-157">This texture array contains three textures; each texture is 3x5 with two mipmap levels.</span></span>

### <a name="span-idtexture2darrayresourceasatexturecubespanspan-idtexture2darrayresourceasatexturecubespanspan-idtexture2darrayresourceasatexturecubespanusing-a-2d-texture-array-as-a-texture-cube"></a><span data-ttu-id="8364b-158"><span id="Texture2DArray_Resource_as_a_Texture_Cube"></span><span id="texture2darray_resource_as_a_texture_cube"></span><span id="TEXTURE2DARRAY_RESOURCE_AS_A_TEXTURE_CUBE"></span>テクスチャ キューブとしての 2D テクスチャ配列の使用</span><span class="sxs-lookup"><span data-stu-id="8364b-158"><span id="Texture2DArray_Resource_as_a_Texture_Cube"></span><span id="texture2darray_resource_as_a_texture_cube"></span><span id="TEXTURE2DARRAY_RESOURCE_AS_A_TEXTURE_CUBE"></span>Using a 2D Texture Array as a Texture Cube</span></span>

<span data-ttu-id="8364b-159">テクスチャ キューブは、6 つのテクスチャ (キューブの各面に 1 つずつ) が含まれた 2D テクスチャ配列です。</span><span class="sxs-lookup"><span data-stu-id="8364b-159">A texture cube is a 2D texture array that contains 6 textures, one for each face of the cube.</span></span> <span data-ttu-id="8364b-160">すべてのデータが設定されたテクスチャ キューブは次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="8364b-160">A fully populated texture cube looks like the following illustration.</span></span>

![テクスチャ キューブを表す 2D テクスチャ配列](images/d3d10-resource-texturecube.png)

<span data-ttu-id="8364b-162">6 つのテクスチャが含まれた 2D テクスチャ配列は、キューブ テクスチャ ビューを使ってパイプラインにバインドした後に、キューブ マップ組み込み関数を使ってシェーダー内から読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="8364b-162">A 2D texture array that contains 6 textures may be read from within shaders with the cube map intrinsic functions, after they are bound to the pipeline with a cube-texture view.</span></span> <span data-ttu-id="8364b-163">テクスチャ キューブは、テクスチャ キューブの中心を起点とする 3D ベクトルによってシェーダーで処理されます。</span><span class="sxs-lookup"><span data-stu-id="8364b-163">Texture cubes are addressed from the shader with a 3D vector pointing out from the center of the texture cube.</span></span>

### <a name="span-idtexture3dresourcespanspan-idtexture3dresourcespanspan-idtexture3dresourcespanspan-idtexture3d-resourcespan3d-textures"></a><span data-ttu-id="8364b-164"><span id="Texture3D_Resource"></span><span id="texture3d_resource"></span><span id="TEXTURE3D_RESOURCE"></span><span id="texture3d-resource"></span>3D テクスチャ</span><span class="sxs-lookup"><span data-stu-id="8364b-164"><span id="Texture3D_Resource"></span><span id="texture3d_resource"></span><span id="TEXTURE3D_RESOURCE"></span><span id="texture3d-resource"></span>3D Textures</span></span>

<span data-ttu-id="8364b-165">3D テクスチャ リソース (ボリューム テクスチャとも呼ばれます) にはテクセルの 3D ボリュームが格納されます。</span><span class="sxs-lookup"><span data-stu-id="8364b-165">A 3D texture resource (also known as a volume texture) contains a 3D volume of texels.</span></span> <span data-ttu-id="8364b-166">これはテクスチャ リソースであるため、ミップマップ レベルが含まれる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="8364b-166">Because it is a texture resource, it may contain mipmap levels.</span></span> <span data-ttu-id="8364b-167">すべてのデータが設定された 3D テクスチャは次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="8364b-167">A fully populated 3D texture looks like the following illustration.</span></span>

![3D テクスチャ リソース](images/d3d10-resource-texture3d.png)

<span data-ttu-id="8364b-169">3D テクスチャ ミップマップ スライスを (レンダー ターゲット ビューを使って) レンダー ターゲット出力としてバインドした場合、3D テクスチャは n 個のスライスの 2D テクスチャ配列と同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="8364b-169">When a 3D texture mipmap slice is bound as a render target output (with a render-target view), the 3D texture behaves identically to a 2D texture array with n slices.</span></span> <span data-ttu-id="8364b-170">特定のレンダー スライスはジオメトリ シェーダー ステージで選択します。</span><span class="sxs-lookup"><span data-stu-id="8364b-170">The particular render slice is chosen from the geometry-shader stage.</span></span>

<span data-ttu-id="8364b-171">3D テクスチャ配列という概念は存在しません。そのため、3D テクスチャのサブリソースは単一のミップマップ レベルになります。</span><span class="sxs-lookup"><span data-stu-id="8364b-171">There is no concept of a 3D texture array; therefore a 3D texture subresource is a single mipmap level.</span></span>

<span data-ttu-id="8364b-172">Direct3D の座標系は、ピクセルとテクセルで定義されます。</span><span class="sxs-lookup"><span data-stu-id="8364b-172">Coordinate systems for Direct3D are defined for pixels and texels.</span></span>

## <a name="span-idpixelspanspan-idpixelspanspan-idpixelspanpixel-coordinate-system"></a><span data-ttu-id="8364b-173"><span id="Pixel"></span><span id="pixel"></span><span id="PIXEL"></span>ピクセル座標系</span><span class="sxs-lookup"><span data-stu-id="8364b-173"><span id="Pixel"></span><span id="pixel"></span><span id="PIXEL"></span>Pixel Coordinate System</span></span>


<span data-ttu-id="8364b-174">Direct3D のピクセル座標系は、次の図に示すように、左上隅にあるレンダー ターゲットの原点を定義します。</span><span class="sxs-lookup"><span data-stu-id="8364b-174">The pixel coordinate system in Direct3D defines the origin of a render target at the upper-left corner, as shown in the following diagram.</span></span> <span data-ttu-id="8364b-175">ピクセルの中心は、整数位置から (0.5f,0.5f) オフセットされます。</span><span class="sxs-lookup"><span data-stu-id="8364b-175">Pixel centers are offset by (0.5f,0.5f) from integer locations.</span></span>

![Direct3D 10 におけるピクセル座標系の図](images/d3d10-coordspix10.png)

## <a name="span-idtexelspanspan-idtexelspanspan-idtexelspantexel-coordinate-system"></a><span data-ttu-id="8364b-177"><span id="Texel"></span><span id="texel"></span><span id="TEXEL"></span>テクセル座標系</span><span class="sxs-lookup"><span data-stu-id="8364b-177"><span id="Texel"></span><span id="texel"></span><span id="TEXEL"></span>Texel Coordinate System</span></span>


<span data-ttu-id="8364b-178">テクセル座標系では、次の図に示すように、テクスチャの左上隅に原点があります。</span><span class="sxs-lookup"><span data-stu-id="8364b-178">The texel coordinate system has its origin at the top-left corner of the texture, as shown in the following diagram.</span></span> <span data-ttu-id="8364b-179">これにより、ピクセル座標権がテクセル座標系に揃えられるため、画面に沿ったテクスチャのレンダリングが簡単になります。</span><span class="sxs-lookup"><span data-stu-id="8364b-179">This makes rendering screen-aligned textures trivial, as the pixel coordinate system is aligned with the texel coordinate system.</span></span>

![テクセル座標系の図](images/d3d10-coordstex10.png)

<span data-ttu-id="8364b-181">テクスチャ座標は、正規化またはスケーリングされた番号で表現されます。各テクスチャ座標は、次のように特定のテクセルにマップされます。</span><span class="sxs-lookup"><span data-stu-id="8364b-181">Texture coordinates are represented with either a normalized or a scaled number; each texture coordinate is mapped to a specific texel as follows:</span></span>

<span data-ttu-id="8364b-182">正規化された座標の場合:</span><span class="sxs-lookup"><span data-stu-id="8364b-182">For a normalized coordinate:</span></span>

-   <span data-ttu-id="8364b-183">点サンプリング: テクセル \# = フロア(U \* 幅)</span><span class="sxs-lookup"><span data-stu-id="8364b-183">Point sampling: Texel \# = floor(U \* Width)</span></span>
-   <span data-ttu-id="8364b-184">線サンプリング: 左テクセル \# = フロア(U \* 幅), 右テクセル \# = 左テクセル \# + 1</span><span class="sxs-lookup"><span data-stu-id="8364b-184">Linear sampling: Left Texel \# = floor(U \* Width), Right Texel \# = Left Texel \# + 1</span></span>

<span data-ttu-id="8364b-185">スケーリングされた座標の場合:</span><span class="sxs-lookup"><span data-stu-id="8364b-185">For a scaled coordinate:</span></span>

-   <span data-ttu-id="8364b-186">点サンプリング: テクセル \# = フロア(U)</span><span class="sxs-lookup"><span data-stu-id="8364b-186">Point sampling: Texel \# = floor(U)</span></span>
-   <span data-ttu-id="8364b-187">線サンプリング: 左テクセル \# = フロア(U - 0.5), 右テクセル \# = 左テクセル \# + 1</span><span class="sxs-lookup"><span data-stu-id="8364b-187">Linear sampling: Left Texel \# = floor(U - 0.5), Right Texel \# = Left Texel \# + 1</span></span>

<span data-ttu-id="8364b-188">ここで、幅はテクスチャの幅です (ピクセル単位)。</span><span class="sxs-lookup"><span data-stu-id="8364b-188">Where the width, is the width of the texture (in texels).</span></span>

<span data-ttu-id="8364b-189">テクスチャ アドレスのラップは、テクセル位置が計算された後に行われます。</span><span class="sxs-lookup"><span data-stu-id="8364b-189">Texture address wrapping occurs after the texel location is computed.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="8364b-190"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="8364b-190"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="8364b-191">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="8364b-191">Textures</span></span>](textures.md)
