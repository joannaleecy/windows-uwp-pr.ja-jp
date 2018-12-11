---
title: モノクロ ライト マップ
description: モノクロ ライト マップを使うと、古い 3D アクセラレータ ボードが宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていない場合に、古いアダプターでもマルチパス テクスチャ ブレンドを実行できます。
ms.assetid: 60F8F8F6-9DB7-452B-8DC0-407FFAA4BFE1
keywords:
- モノクロ ライト マップ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: b81838393d7b2692e6fd04b7ce535f58dc773780
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8893148"
---
# <a name="monochrome-light-maps"></a><span data-ttu-id="baf8f-104">モノクロ ライト マップ</span><span class="sxs-lookup"><span data-stu-id="baf8f-104">Monochrome light maps</span></span>


<span data-ttu-id="baf8f-105">モノクロ ライト マップを使うと、古い 3D アクセラレータ ボードが宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていない場合に、古いアダプターでもマルチパス テクスチャ ブレンドを実行できます。</span><span class="sxs-lookup"><span data-stu-id="baf8f-105">Monochrome light mapping enables older adapters to perform multipass texture blending, when an older 3D accelerator board doesn't support texture blending using the alpha value of the destination pixel.</span></span>

<span data-ttu-id="baf8f-106">一部の古い 3D アクセラレータ ボードは、宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="baf8f-106">Some older 3D accelerator boards do not support texture blending using the alpha value of the destination pixel.</span></span> <span data-ttu-id="baf8f-107">これらのアダプターは多くの場合、複数テクスチャ ブレンドもサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="baf8f-107">These adapters also generally do not support multiple texture blending.</span></span> <span data-ttu-id="baf8f-108">アプリケーションがこのようなアダプターで実行されている場合、マルチパス テクスチャ ブレンドを使ってモノクロ ライト マッピングを実行できます。</span><span class="sxs-lookup"><span data-stu-id="baf8f-108">If your application is running on an adapter such as this, it can use multipass texture blending to perform monochrome light mapping.</span></span>

<span data-ttu-id="baf8f-109">モノクロ ライト マッピングを実行するため、アプリケーションはライト マップ テクスチャのアルファ データに照明情報を格納します。</span><span class="sxs-lookup"><span data-stu-id="baf8f-109">To perform monochrome light mapping, an application stores the lighting information in the alpha data of its light map textures.</span></span> <span data-ttu-id="baf8f-110">アプリケーションは、Direct3D のテクスチャ フィルタリング機能を使って、プリミティブのイメージ内の各ピクセルからライト マップ内の対応するテクセルへのマッピングを実行します。</span><span class="sxs-lookup"><span data-stu-id="baf8f-110">The application uses the texture filtering capabilities of Direct3D to perform a mapping from each pixel in the primitive's image to a corresponding texel in the light map.</span></span> <span data-ttu-id="baf8f-111">また、ソース ブレンド要素を対応するテクセルのアルファ値に設定します。</span><span class="sxs-lookup"><span data-stu-id="baf8f-111">It sets the source blending factor to the alpha value of the corresponding texel.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="baf8f-112"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="baf8f-112"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="baf8f-113">テクスチャでのライト マッピング</span><span class="sxs-lookup"><span data-stu-id="baf8f-113">Light mapping with textures</span></span>](light-mapping-with-textures.md)

 

 




