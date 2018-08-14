---
author: mtoepke
title: DirectX ゲームの基本的な 3D グラフィックス
description: DirectX プログラミングを使って、3D グラフィックスの基本的な概念を実装する方法について説明します。
ms.assetid: 2989c91f-7b45-7377-4e83-9daa0325e92e
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, DirectX, グラフィックス
ms.openlocfilehash: 2ac11ce220bc1c62c81df12fbf9c2a41fda1d940
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243126"
---
# <a name="basic-3d-graphics-for-directx-games"></a><span data-ttu-id="4b1b1-104">DirectX ゲームの基本的な 3D グラフィックス</span><span class="sxs-lookup"><span data-stu-id="4b1b1-104">Basic 3D graphics for DirectX games</span></span>


<span data-ttu-id="4b1b1-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="4b1b1-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="4b1b1-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="4b1b1-107">DirectX プログラミングを使って、3D グラフィックスの基本的な概念を実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-107">We show how to use DirectX programming to implement the fundamental concepts of 3D graphics.</span></span>

<span data-ttu-id="4b1b1-108">**目標:** 3D グラフィックス アプリのプログラミング方法を身に付ける。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-108">**Objective:** Learn to program a 3D graphics app.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="4b1b1-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="4b1b1-109">Prerequisites</span></span>


<span data-ttu-id="4b1b1-110">C++ に習熟していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-110">We assume that you are familiar with C++.</span></span> <span data-ttu-id="4b1b1-111">また、グラフィックス プログラミングの概念に対する基礎的な知識も必要となります。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-111">You also need basic experience with graphics programming concepts.</span></span>

<span data-ttu-id="4b1b1-112">**完了までの合計時間:** 30 分。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-112">**Total time to complete:** 30 minutes.</span></span>

## <a name="where-to-go-from-here"></a><span data-ttu-id="4b1b1-113">次の段階</span><span class="sxs-lookup"><span data-stu-id="4b1b1-113">Where to go from here</span></span>


<span data-ttu-id="4b1b1-114">ここでは、DirectX と C++\\Cx を使って 3D グラフィックスを開発する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-114">Here, we talk about how to develop 3D graphics with DirectX and C++\\Cx.</span></span> <span data-ttu-id="4b1b1-115">この 5 つのパートから成るチュートリアルでは、[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) API と、その他の DirectX サンプルの多くでも使われる概念やコードを紹介しています。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-115">This five-part tutorial introduces you to the [Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) API and the concepts and code that are also used in many of the other DirectX samples.</span></span> <span data-ttu-id="4b1b1-116">各パートでは、UWP の C++ アプリ向けに DirectX を構成することから始まって、プリミティブのテクスチャリングや効果の追加まで、段階的に構築していきます。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-116">These parts build upon each other, from configuring DirectX for your UWP C++ app to texturing primitives and adding effects.</span></span>

> <span data-ttu-id="4b1b1-117">**注**  このチュートリアルでは、右手による座標系と列のベクターを使います。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-117">**Note**  This tutorial uses a right-handed coordinate system with column vectors.</span></span> <span data-ttu-id="4b1b1-118">多くの DirectX サンプルと DirectX アプリでは、左手による座標系と行のベクターを使います。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-118">Many DirectX samples and apps use a left-handed coordinate system with row vectors.</span></span> <span data-ttu-id="4b1b1-119">より完全なグラフィックス数式ソリューションと、左手による座標系と行のベクターをサポートするグラフィックス数式ソリューションが必要な場合は、[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-119">For a more complete graphics math solution and one that supports a left-handed coordinate system with row vectors, consider using [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833).</span></span> <span data-ttu-id="4b1b1-120">詳しくは、「[Direct3D との DirectXMath の使用](https://msdn.microsoft.com/library/windows/desktop/ff729728#Use_DXMath_with_D3D)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-120">For more info, see [Using DirectXMath with Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff729728#Use_DXMath_with_D3D).</span></span>

 

<span data-ttu-id="4b1b1-121">次の方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-121">We show you how to:</span></span>

-   <span data-ttu-id="4b1b1-122">Windows ランタイムを使っての [Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) インターフェイスの初期化</span><span class="sxs-lookup"><span data-stu-id="4b1b1-122">Initialize [Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) interfaces by using the Windows Runtime</span></span>
-   <span data-ttu-id="4b1b1-123">頂点ごとのシェーダー操作の適用</span><span class="sxs-lookup"><span data-stu-id="4b1b1-123">Apply per-vertex shader operations</span></span>
-   <span data-ttu-id="4b1b1-124">ジオメトリの設定</span><span class="sxs-lookup"><span data-stu-id="4b1b1-124">Set up the geometry</span></span>
-   <span data-ttu-id="4b1b1-125">シーンのラスタライズ (3D シーンを 2D プロジェクションにフラット化)</span><span class="sxs-lookup"><span data-stu-id="4b1b1-125">Rasterize the scene (flattening the 3D scene to a 2D projection)</span></span>
-   <span data-ttu-id="4b1b1-126">隠面のカリング</span><span class="sxs-lookup"><span data-stu-id="4b1b1-126">Cull the hidden surfaces</span></span>

> **<span data-ttu-id="4b1b1-127">注</span><span class="sxs-lookup"><span data-stu-id="4b1b1-127">Note</span></span>**  
<span data-ttu-id="4b1b1-128">この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-128">This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="4b1b1-129">Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-129">If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).</span></span>

 

<span data-ttu-id="4b1b1-130">次に、Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像をディスプレイに表示します。</span><span class="sxs-lookup"><span data-stu-id="4b1b1-130">Next, we create a Direct3D device, swap chain, and render-target view, and present the rendered image to the display.</span></span>

[<span data-ttu-id="4b1b1-131">クイック スタート: DirectX リソースの設定と画像の表示</span><span class="sxs-lookup"><span data-stu-id="4b1b1-131">Quickstart: setting up DirectX resources and displaying an image</span></span>](setting-up-directx-resources.md)

## <a name="related-topics"></a><span data-ttu-id="4b1b1-132">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4b1b1-132">Related topics</span></span>


* [<span data-ttu-id="4b1b1-133">Direct3D 11 グラフィックス</span><span class="sxs-lookup"><span data-stu-id="4b1b1-133">Direct3D 11 Graphics</span></span>](https://msdn.microsoft.com/library/windows/desktop/ff476080)
* [<span data-ttu-id="4b1b1-134">DXGI</span><span class="sxs-lookup"><span data-stu-id="4b1b1-134">DXGI</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh404534)
* [<span data-ttu-id="4b1b1-135">HLSL</span><span class="sxs-lookup"><span data-stu-id="4b1b1-135">HLSL</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb509561)

 

 




