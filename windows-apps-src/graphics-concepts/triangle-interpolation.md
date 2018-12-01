---
title: 三角形の補間
description: レンダリング中、パイプラインは各三角形の間の頂点データを補間します。
ms.assetid: 1A76DD78-CED7-42BE-BA81-B9050CD3AF9B
keywords:
- 三角形の補間
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e8017cd75ed3dfd4129d6c15d668648792cc8d0a
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8349150"
---
# <a name="triangle-interpolation"></a><span data-ttu-id="f8f87-104">三角形の補間</span><span class="sxs-lookup"><span data-stu-id="f8f87-104">Triangle interpolation</span></span>


<span data-ttu-id="f8f87-105">レンダリング中、パイプラインは各三角形で頂点データを補間します。</span><span class="sxs-lookup"><span data-stu-id="f8f87-105">During rendering, the pipeline interpolates vertex data across each triangle.</span></span> <span data-ttu-id="f8f87-106">頂点データにはさまざまなデータがあり、拡散色、反射色、拡散色アルファ (三角形の不透明度)、反射色アルファ、フォグ係数などを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="f8f87-106">Vertex data can be a broad variety of data and can include (but is not limited to): diffuse color, specular color, diffuse alpha (triangle opacity), specular alpha, and a fog factor.</span></span> <span data-ttu-id="f8f87-107">プログラム可能な頂点パイプラインの場合、フォグ係数はフォグ レジスタから取得されます。</span><span class="sxs-lookup"><span data-stu-id="f8f87-107">For the programmable vertex pipeline, the fog factor is taken from the fog register.</span></span> <span data-ttu-id="f8f87-108">固定機能頂点パイプラインの場合、フォグ係数は反射色アルファから取得されます。</span><span class="sxs-lookup"><span data-stu-id="f8f87-108">For the fixed-function vertex pipeline, the fog factor is taken from specular alpha.</span></span>

<span data-ttu-id="f8f87-109">一部の頂点データでは、次のように、現在のシェーディング モードに応じて補間の動作が異なります。</span><span class="sxs-lookup"><span data-stu-id="f8f87-109">For some vertex data, the interpolation is dependent on the current shading mode, as follows:</span></span>

| <span data-ttu-id="f8f87-110">シェーディング モード</span><span class="sxs-lookup"><span data-stu-id="f8f87-110">Shading mode</span></span> | <span data-ttu-id="f8f87-111">説明</span><span class="sxs-lookup"><span data-stu-id="f8f87-111">Description</span></span>                                                                                                                                                                 |
|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="f8f87-112">フラット</span><span class="sxs-lookup"><span data-stu-id="f8f87-112">Flat</span></span>         | <span data-ttu-id="f8f87-113">フラット シェーディング モードでは、フォグ係数だけが補間されます。</span><span class="sxs-lookup"><span data-stu-id="f8f87-113">Only the fog factor is interpolated in flat shade mode.</span></span> <span data-ttu-id="f8f87-114">その他のすべて補間値については、三角形の最初の頂点の色が面全体に適用されます。</span><span class="sxs-lookup"><span data-stu-id="f8f87-114">For all other interpolated values, the color of the first vertex in the triangle is applied across the entire face.</span></span> |
| <span data-ttu-id="f8f87-115">グーロー</span><span class="sxs-lookup"><span data-stu-id="f8f87-115">Gouraud</span></span>      | <span data-ttu-id="f8f87-116">3 つの頂点すべての間で線形補間が実行されます。</span><span class="sxs-lookup"><span data-stu-id="f8f87-116">Linear interpolation is performed between all three vertices.</span></span>                                                                                                               |

 

<span data-ttu-id="f8f87-117">拡散色と反射色は、カラー モデルに応じて異なる方法で処理されます。</span><span class="sxs-lookup"><span data-stu-id="f8f87-117">The diffuse color and specular color are treated differently, depending on the color model.</span></span> <span data-ttu-id="f8f87-118">RGB カラー モデルでは、システムは赤、緑、青の色成分を補間に使用します。</span><span class="sxs-lookup"><span data-stu-id="f8f87-118">In the RGB color model, the system uses the red, green, and blue color components in the interpolation.</span></span>

<span data-ttu-id="f8f87-119">色のアルファ成分は別個の補間値として扱われます。これは、デバイス ドライバーによって透明度の実装方法が異なり、テクスチャ ブレンディングが使われる場合と、点描が使われる場合の 2 とおりがあるためです。</span><span class="sxs-lookup"><span data-stu-id="f8f87-119">The alpha component of a color is treated as a separate interpolated value because device drivers can implement transparency in two different ways: by using texture blending or by using stippling.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="f8f87-120"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="f8f87-120"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="f8f87-121">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="f8f87-121">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




