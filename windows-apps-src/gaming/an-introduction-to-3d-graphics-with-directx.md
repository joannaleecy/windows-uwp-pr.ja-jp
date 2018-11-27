---
title: DirectX ゲームの基本的な 3D グラフィックス
description: DirectX プログラミングを使って、3D グラフィックスの基本的な概念を実装する方法について説明します。
ms.assetid: 2989c91f-7b45-7377-4e83-9daa0325e92e
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, グラフィックス
ms.localizationpriority: medium
ms.openlocfilehash: 5dbdf6072f57d12d424f0787cfa2e8993a1624af
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7707655"
---
# <a name="basic-3d-graphics-for-directx-games"></a><span data-ttu-id="ff03e-104">DirectX ゲームの基本的な 3D グラフィックス</span><span class="sxs-lookup"><span data-stu-id="ff03e-104">Basic 3D graphics for DirectX games</span></span>



<span data-ttu-id="ff03e-105">DirectX プログラミングを使って、3D グラフィックスの基本的な概念を実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ff03e-105">We show how to use DirectX programming to implement the fundamental concepts of 3D graphics.</span></span>

<span data-ttu-id="ff03e-106">**目標:** 3D グラフィックス アプリのプログラミング方法を身に付ける。</span><span class="sxs-lookup"><span data-stu-id="ff03e-106">**Objective:** Learn to program a 3D graphics app.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="ff03e-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="ff03e-107">Prerequisites</span></span>


<span data-ttu-id="ff03e-108">C++ に習熟していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="ff03e-108">We assume that you are familiar with C++.</span></span> <span data-ttu-id="ff03e-109">また、グラフィックス プログラミングの概念に対する基礎的な知識も必要となります。</span><span class="sxs-lookup"><span data-stu-id="ff03e-109">You also need basic experience with graphics programming concepts.</span></span>

<span data-ttu-id="ff03e-110">**完了までの合計時間:** 30 分。</span><span class="sxs-lookup"><span data-stu-id="ff03e-110">**Total time to complete:** 30 minutes.</span></span>

## <a name="where-to-go-from-here"></a><span data-ttu-id="ff03e-111">次の段階</span><span class="sxs-lookup"><span data-stu-id="ff03e-111">Where to go from here</span></span>


<span data-ttu-id="ff03e-112">ここでは、DirectX と C++\\Cx を使って 3D グラフィックスを開発する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ff03e-112">Here, we talk about how to develop 3D graphics with DirectX and C++\\Cx.</span></span> <span data-ttu-id="ff03e-113">この 5 つのパートから成るチュートリアルでは、[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) API と、その他の DirectX サンプルの多くでも使われる概念やコードを紹介しています。</span><span class="sxs-lookup"><span data-stu-id="ff03e-113">This five-part tutorial introduces you to the [Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) API and the concepts and code that are also used in many of the other DirectX samples.</span></span> <span data-ttu-id="ff03e-114">各パートでは、UWP の C++ アプリ向けに DirectX を構成することから始まって、プリミティブのテクスチャリングや効果の追加まで、段階的に構築していきます。</span><span class="sxs-lookup"><span data-stu-id="ff03e-114">These parts build upon each other, from configuring DirectX for your UWP C++ app to texturing primitives and adding effects.</span></span>

> <span data-ttu-id="ff03e-115">**注:** このチュートリアルでは、右手による座標系と列のベクター使用します。</span><span class="sxs-lookup"><span data-stu-id="ff03e-115">**Note**This tutorial uses a right-handed coordinate system with column vectors.</span></span> <span data-ttu-id="ff03e-116">多くの DirectX サンプルと DirectX アプリでは、左手による座標系と行のベクターを使います。</span><span class="sxs-lookup"><span data-stu-id="ff03e-116">Many DirectX samples and apps use a left-handed coordinate system with row vectors.</span></span> <span data-ttu-id="ff03e-117">より完全なグラフィックス数式ソリューションと、左手による座標系と行のベクターをサポートするグラフィックス数式ソリューションが必要な場合は、[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="ff03e-117">For a more complete graphics math solution and one that supports a left-handed coordinate system with row vectors, consider using [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833).</span></span> <span data-ttu-id="ff03e-118">詳しくは、「[Direct3D との DirectXMath の使用](https://msdn.microsoft.com/library/windows/desktop/ff729728#Use_DXMath_with_D3D)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ff03e-118">For more info, see [Using DirectXMath with Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff729728#Use_DXMath_with_D3D).</span></span>

 

<span data-ttu-id="ff03e-119">次の方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ff03e-119">We show you how to:</span></span>

-   <span data-ttu-id="ff03e-120">Windows ランタイムを使っての [Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) インターフェイスの初期化</span><span class="sxs-lookup"><span data-stu-id="ff03e-120">Initialize [Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) interfaces by using the Windows Runtime</span></span>
-   <span data-ttu-id="ff03e-121">頂点ごとのシェーダー操作の適用</span><span class="sxs-lookup"><span data-stu-id="ff03e-121">Apply per-vertex shader operations</span></span>
-   <span data-ttu-id="ff03e-122">ジオメトリの設定</span><span class="sxs-lookup"><span data-stu-id="ff03e-122">Set up the geometry</span></span>
-   <span data-ttu-id="ff03e-123">シーンのラスタライズ (3D シーンを 2D プロジェクションにフラット化)</span><span class="sxs-lookup"><span data-stu-id="ff03e-123">Rasterize the scene (flattening the 3D scene to a 2D projection)</span></span>
-   <span data-ttu-id="ff03e-124">隠面のカリング</span><span class="sxs-lookup"><span data-stu-id="ff03e-124">Cull the hidden surfaces</span></span>

> **<span data-ttu-id="ff03e-125">注</span><span class="sxs-lookup"><span data-stu-id="ff03e-125">Note</span></span>**  

 

<span data-ttu-id="ff03e-126">次に、Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像をディスプレイに表示します。</span><span class="sxs-lookup"><span data-stu-id="ff03e-126">Next, we create a Direct3D device, swap chain, and render-target view, and present the rendered image to the display.</span></span>

[<span data-ttu-id="ff03e-127">クイック スタート: DirectX リソースの設定と画像の表示</span><span class="sxs-lookup"><span data-stu-id="ff03e-127">Quickstart: setting up DirectX resources and displaying an image</span></span>](setting-up-directx-resources.md)

## <a name="related-topics"></a><span data-ttu-id="ff03e-128">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ff03e-128">Related topics</span></span>


* [<span data-ttu-id="ff03e-129">Direct3D 11 グラフィックス</span><span class="sxs-lookup"><span data-stu-id="ff03e-129">Direct3D 11 Graphics</span></span>](https://msdn.microsoft.com/library/windows/desktop/ff476080)
* [<span data-ttu-id="ff03e-130">DXGI</span><span class="sxs-lookup"><span data-stu-id="ff03e-130">DXGI</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh404534)
* [<span data-ttu-id="ff03e-131">HLSL</span><span class="sxs-lookup"><span data-stu-id="ff03e-131">HLSL</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb509561)

 

 




