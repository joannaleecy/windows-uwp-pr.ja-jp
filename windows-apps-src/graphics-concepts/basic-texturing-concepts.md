---
title: テクスチャリングの基本概念
description: コンピューターで作成された初期の 3D 画像は、当時は高度な技術でしたが、ツルツルのプラスチックのような外観になりがちでした。
ms.assetid: 3CA3905D-E837-48EB-A81F-319AA1C6537E
keywords:
- テクスチャリングの基本概念
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c48b7b007c1af1eaf6013d5f6e99468713d50745
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5881675"
---
# <a name="basic-texturing-concepts"></a><span data-ttu-id="1e10d-104">テクスチャリングの基本概念</span><span class="sxs-lookup"><span data-stu-id="1e10d-104">Basic texturing concepts</span></span>


<span data-ttu-id="1e10d-105">コンピューターで作成された初期の 3D 画像は、当時は高度な技術でしたが、ツルツルのプラスチックのような外観になりがちでした。</span><span class="sxs-lookup"><span data-stu-id="1e10d-105">Early computer-generated 3D images, although generally advanced for their time, tended to have a shiny plastic look.</span></span> <span data-ttu-id="1e10d-106">それらには、3D オブジェクトにリアルで複雑な外観を与える傷や割れ、指紋、汚れなどがありませんでした。</span><span class="sxs-lookup"><span data-stu-id="1e10d-106">They lacked the types of markings-such as scuffs, cracks, fingerprints, and smudges-that give 3D objects realistic visual complexity.</span></span> <span data-ttu-id="1e10d-107">テクスチャは、コンピューターで作成された 3D 画像のリアルさを向上させるための一般的な手法になってきました。</span><span class="sxs-lookup"><span data-stu-id="1e10d-107">Textures have become popular for enhancing the realism of computer-generated 3D images.</span></span>

<span data-ttu-id="1e10d-108">テクスチャという単語は一般的には、オブジェクトのなめらかさや粗さを表します。</span><span class="sxs-lookup"><span data-stu-id="1e10d-108">In its everyday use, the word texture refers to an object's smoothness or roughness.</span></span> <span data-ttu-id="1e10d-109">ただし、コンピューター グラフィックスでは、オブジェクトにテクスチャの外観を与えるピクセル カラーのビットマップを指します。</span><span class="sxs-lookup"><span data-stu-id="1e10d-109">In computer graphics, however, a texture is a bitmap of pixel colors that give an object the appearance of texture.</span></span>

<span data-ttu-id="1e10d-110">Direct3D のテクスチャはビットマップであるため、どんなビットマップも Direct3D プリミティブに適用できます。</span><span class="sxs-lookup"><span data-stu-id="1e10d-110">Because Direct3D textures are bitmaps, any bitmap can be applied to a Direct3D primitive.</span></span> <span data-ttu-id="1e10d-111">たとえば、アプリケーションは、木目のパターンを持つように表示するオブジェクトを作成して処理できます。</span><span class="sxs-lookup"><span data-stu-id="1e10d-111">For instance, applications can create and manipulate objects that appear to have a wood grain pattern in them.</span></span> <span data-ttu-id="1e10d-112">丘を形成する一連の 3D プリミティブには草、土、岩を適用できます。</span><span class="sxs-lookup"><span data-stu-id="1e10d-112">Grass, dirt, and rocks can be applied to a set of 3D primitives that form a hill.</span></span> <span data-ttu-id="1e10d-113">これによって、丘の中腹をよりリアルに見せることができます。</span><span class="sxs-lookup"><span data-stu-id="1e10d-113">The result is a realistic-looking hillside.</span></span> <span data-ttu-id="1e10d-114">また、テクスチャを使用して道路沿いの標識、がけの岩石層、大理石模様の床などのエフェクトを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="1e10d-114">You can also use texturing to create effects such as signs along a roadside, rock strata in a cliff, or the appearance of marble on a floor.</span></span>

<span data-ttu-id="1e10d-115">さらに、Direct3D は透明度ありなしのテクスチャ ブレンディングやライト マッピングなど、さらに高度なテクスチャ テクニックをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1e10d-115">In addition, Direct3D supports more advanced texturing techniques such as texture blending-with or without transparency-and light mapping.</span></span> <span data-ttu-id="1e10d-116">詳しくは、「[テクスチャ ブレンディング](texture-blending.md)」および「[テクスチャによるライト マッピング](light-mapping-with-textures.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1e10d-116">See [Texture blending](texture-blending.md) and [Light mapping with textures](light-mapping-with-textures.md).</span></span>

<span data-ttu-id="1e10d-117">アプリケーションがハードウェア アブストラクション レイヤー (HAL) デバイスやソフトウェア デバイスを作成する場合、8、16、24、32、64、または 128 ビットのテクスチャを使用できます。</span><span class="sxs-lookup"><span data-stu-id="1e10d-117">If your application creates a hardware abstraction layer (HAL) device or a software device, it can use 8, 16, 24, 32, 64, or 128-bit textures.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1e10d-118"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1e10d-118"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1e10d-119">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="1e10d-119">Textures</span></span>](textures.md)

 

 




