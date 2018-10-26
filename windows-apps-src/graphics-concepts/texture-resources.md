---
title: テクスチャ リソース
description: テクスチャは、レンダリングに使われるリソースの一種です。
ms.assetid: 016F6CDA-D361-4E6B-BA99-49E915A19364
keywords:
- テクスチャ リソース
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 72f58521e01d46437ba44453b94d12a82bb3e639
ms.sourcegitcommit: b7e3d222e229cdbf04e837fcb94fb7d84a93de09
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5599178"
---
# <a name="texture-resources"></a><span data-ttu-id="93ed2-104">テクスチャ リソース</span><span class="sxs-lookup"><span data-stu-id="93ed2-104">Texture resources</span></span>


<span data-ttu-id="93ed2-105">テクスチャは、レンダリングに使われるリソースの一種です。</span><span class="sxs-lookup"><span data-stu-id="93ed2-105">Textures are a type of resource used for rendering.</span></span>

## <a name="span-idrenderingwithtextureresourcesspanspan-idrenderingwithtextureresourcesspanspan-idrenderingwithtextureresourcesspanrendering-with-texture-resources"></a><span data-ttu-id="93ed2-106"><span id="Rendering_with_Texture_Resources"></span><span id="rendering_with_texture_resources"></span><span id="RENDERING_WITH_TEXTURE_RESOURCES"></span>テクスチャ リソースを使ったレンダリング</span><span class="sxs-lookup"><span data-stu-id="93ed2-106"><span id="Rendering_with_Texture_Resources"></span><span id="rendering_with_texture_resources"></span><span id="RENDERING_WITH_TEXTURE_RESOURCES"></span>Rendering with texture resources</span></span>


<span data-ttu-id="93ed2-107">Direct3D は、テクスチャ ステージの概念による複数のテクスチャ ブレンドをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="93ed2-107">Direct3D supports multiple texture blending through the concept of texture stages.</span></span> <span data-ttu-id="93ed2-108">各テクスチャ ステージには、テクスチャとそのテクスチャに対して実行できる操作が含まれています。</span><span class="sxs-lookup"><span data-stu-id="93ed2-108">Each texture stage contains a texture and operations that can be performed on the texture.</span></span> <span data-ttu-id="93ed2-109">テクスチャ ステージ内のテクスチャが現在のテクスチャのセットを構成します。</span><span class="sxs-lookup"><span data-stu-id="93ed2-109">The textures in the texture stages form the set of current textures.</span></span> <span data-ttu-id="93ed2-110">「[テクスチャ ブレンド](texture-blending.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93ed2-110">See [Texture blending](texture-blending.md).</span></span> <span data-ttu-id="93ed2-111">各テクスチャの状態は、そのテクスチャ ステージにカプセル化されます。</span><span class="sxs-lookup"><span data-stu-id="93ed2-111">The state of each texture is encapsulated in its texture stage.</span></span>

<span data-ttu-id="93ed2-112">また、アプリケーションは、テクスチャの視点とテクスチャ フィルタリングの状態を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="93ed2-112">Your application can also set the texture perspective and texture filtering states.</span></span> <span data-ttu-id="93ed2-113">「[テクスチャ フィルタリング](texture-filtering.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93ed2-113">See [Texture filtering](texture-filtering.md).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="93ed2-114"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="93ed2-114"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="93ed2-115">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="93ed2-115">Textures</span></span>](textures.md)

 

 




