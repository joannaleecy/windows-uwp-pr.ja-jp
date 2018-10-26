---
title: マルチパス テクスチャ ブレンド
description: Direct3D アプリケーションは、複数のレンダリング パスを通る間にさまざまなテクスチャをプリミティブに適用することで、多くの特殊効果を実現できます。
ms.assetid: FB4D6E3F-4EF5-4D20-BF7E-1008E790E30C
keywords:
- マルチパス テクスチャ ブレンド
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c55f371e97daba5f81945812f8179eb708bbadd6
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5567184"
---
# <a name="multipass-texture-blending"></a><span data-ttu-id="5ef4a-104">マルチパス テクスチャ ブレンド</span><span class="sxs-lookup"><span data-stu-id="5ef4a-104">Multipass texture blending</span></span>


<span data-ttu-id="5ef4a-105">Direct3D アプリケーションでは、複数のレンダリング パスでさまざまなテクスチャを 1 つのプリミティブに適用することで、多彩な特殊効果を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-105">Direct3D applications can achieve numerous special effects by applying various textures to a primitive over the course of multiple rendering passes.</span></span> <span data-ttu-id="5ef4a-106">これを表す一般的な用語が*マルチパス テクスチャ ブレンド*です。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-106">The common term for this is *multipass texture blending*.</span></span> <span data-ttu-id="5ef4a-107">通常、マルチパス テクスチャ ブレンドは、さまざまなテクスチャから複数のカラーを適用して、複雑なライティング モデルやシェーディング モデルの効果をエミュレートするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-107">A typical use for multipass texture blending is to emulate the effects of complex lighting and shading models by applying multiple colors from several different textures.</span></span> <span data-ttu-id="5ef4a-108">このような適用は*ライト マッピング*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-108">One such application is called *light mapping*.</span></span> <span data-ttu-id="5ef4a-109">「[テクスチャでのライト マッピング](light-mapping-with-textures.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-109">See [Light mapping with textures](light-mapping-with-textures.md).</span></span>

<span data-ttu-id="5ef4a-110">**注:** デバイスによっては複数の 1 つのパスでプリミティブにテクスチャを適用できます。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-110">**Note** Some devices are capable of applying multiple textures to primitives in a single pass.</span></span> <span data-ttu-id="5ef4a-111">「[テクスチャ ブレンド](texture-blending.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-111">See [Texture blending](texture-blending.md).</span></span>

 

<span data-ttu-id="5ef4a-112">ユーザーのハードウェアで複数テクスチャ ブレンドがサポートされていない場合、アプリケーションはマルチパス テクスチャ ブレンドを使って同じ視覚効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-112">If the user's hardware does not support multiple texture blending, your application can use multipass texture blending to achieve the same visual effects.</span></span> <span data-ttu-id="5ef4a-113">ただし、アプリケーションは複数テクスチャ ブレンドを使ったときに生じる可能性があるフレーム レートに対応できません。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-113">However, the application cannot sustain the frame rates that are possible when using multiple texture blending.</span></span>

<span data-ttu-id="5ef4a-114">C/C++ アプリケーションでマルチパス テクスチャ ブレンドを実行するには</span><span class="sxs-lookup"><span data-stu-id="5ef4a-114">To perform multipass texture blending in a C/C++ application:</span></span>

1.  <span data-ttu-id="5ef4a-115">テクスチャ ステージ 0 でテクスチャを設定します。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-115">Set a texture in texture stage 0.</span></span>
2.  <span data-ttu-id="5ef4a-116">必要な色およびアルファ ブレンドの引数と操作を選択します。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-116">Select the desired color and alpha blending arguments and operations.</span></span> <span data-ttu-id="5ef4a-117">既定の設定は、マルチパス テクスチャ ブレンドに最適です。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-117">The default settings are well-suited for multipass texture blending.</span></span>
3.  <span data-ttu-id="5ef4a-118">シーン内の適切なオブジェクトをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-118">Render the appropriate objects in the scene.</span></span>
4.  <span data-ttu-id="5ef4a-119">テクスチャ ステージ 0 で次のテクスチャを設定します。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-119">Set the next texture in texture stage 0.</span></span>
5.  <span data-ttu-id="5ef4a-120">レンダー状態を設定し、必要に応じてソース ブレンドとターゲット ブレンドを調整します。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-120">Set the render states to adjust the source and destination blending factors as needed.</span></span> <span data-ttu-id="5ef4a-121">システムが、これらのパラメーターに従って、レンダー ターゲット サーフェスで新しいテクスチャと既存のピクセルをブレンドします。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-121">The system blends the new textures with the existing pixels in the render-target surface according to these parameters.</span></span>
6.  <span data-ttu-id="5ef4a-122">必要な数のテクスチャに対して手順 3、4、5 を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="5ef4a-122">Repeat Steps 3, 4, and 5 with as many textures as needed.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="5ef4a-123"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="5ef4a-123"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="5ef4a-124">テクスチャ ブレンド</span><span class="sxs-lookup"><span data-stu-id="5ef4a-124">Texture blending</span></span>](texture-blending.md)

 

 




