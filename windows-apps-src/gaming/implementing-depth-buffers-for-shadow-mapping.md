---
author: mtoepke
title: チュートリアル -- Direct3D 11 のシャドウ ボリュームの深度バッファー
description: このチュートリアルでは、すべての Direct3D 機能レベルのデバイスで Direct3D 11 を使い、深度マップを利用してシャドウ ボリュームをレンダリングする方法について説明します。
ms.assetid: d15e6501-1a1d-d99c-d1d8-ad79b849db90
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, シャドウ ボリューム, 深度バッファー, DirectX 11
ms.localizationpriority: medium
ms.openlocfilehash: 269f8423795d7c2515ce555cf8e65f14a8c63431
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6471773"
---
# <a name="walkthrough-implement-shadow-volumes-using-depth-buffers-in-direct3d-11"></a><span data-ttu-id="e4342-104">チュートリアル: Direct3D 11 の深度バッファーを使ったシャドウ ボリュームの実装</span><span class="sxs-lookup"><span data-stu-id="e4342-104">Walkthrough: Implement shadow volumes using depth buffers in Direct3D 11</span></span>



<span data-ttu-id="e4342-105">このチュートリアルでは、すべての Direct3D 機能レベルのデバイスで Direct3D 11 を使い、深度マップを利用してシャドウ ボリュームをレンダリングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e4342-105">This walkthrough demonstrates how to render shadow volumes using depth maps, using Direct3D 11 on devices of all Direct3D feature levels.</span></span>
## 
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e4342-106">トピック</span><span class="sxs-lookup"><span data-stu-id="e4342-106">Topic</span></span></th>
<th align="left"><span data-ttu-id="e4342-107">説明</span><span class="sxs-lookup"><span data-stu-id="e4342-107">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="create-depth-buffer-resource--view--and-sampler-state.md"><span data-ttu-id="e4342-108">深度バッファーのデバイス リソースの作成</span><span class="sxs-lookup"><span data-stu-id="e4342-108">Create depth buffer device resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="e4342-109">シャドウ ボリュームの深度のテストをサポートするために必要な Direct3D デバイス リソースを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e4342-109">Learn how to create the Direct3D device resources necessary to support depth testing for shadow volumes.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="render-the-shadow-map-to-the-depth-buffer.md"><span data-ttu-id="e4342-110">深度バッファーへのシャドウ マップのレンダリング</span><span class="sxs-lookup"><span data-stu-id="e4342-110">Render the shadow map to the depth buffer</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="e4342-111">ライトの視点からレンダリングして、シャドウ ボリュームを表す 2 次元の深度マップを作成します。</span><span class="sxs-lookup"><span data-stu-id="e4342-111">Render from the point of view of the light to create a two-dimensional depth map representing the shadow volume.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="render-the-scene-with-depth-testing.md"><span data-ttu-id="e4342-112">深度のテストを使ったシーンのレンダリング</span><span class="sxs-lookup"><span data-stu-id="e4342-112">Render the scene with depth testing</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="e4342-113">シャドウ効果を作成するには、頂点 (またはジオメトリ) シェーダーとピクセル シェーダーに深度のテストを追加します。</span><span class="sxs-lookup"><span data-stu-id="e4342-113">Create a shadow effect by adding depth testing to your vertex (or geometry) shader and your pixel shader.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="target-a-range-of-hardware.md"><span data-ttu-id="e4342-114">ハードウェアの範囲でのシャドウ マップのサポート</span><span class="sxs-lookup"><span data-stu-id="e4342-114">Support shadow maps on a range of hardware</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="e4342-115">より高速なデバイスでは高品質なシャドウを、性能が低いデバイスではよりすばやいシャドウをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="e4342-115">Render higher-fidelity shadows on faster devices and faster shadows on less powerful devices.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="shadow-mapping-application-to-direct3d-9-desktop-porting"></a><span data-ttu-id="e4342-116">Direct3D 9 デスクトップに対するシャドウ マップの適用の移植</span><span class="sxs-lookup"><span data-stu-id="e4342-116">Shadow mapping application to Direct3D 9 desktop porting</span></span>


<span data-ttu-id="e4342-117">Windows8 で機能レベル 9 \_1 と 9 \_3 に深度の比較機能します。</span><span class="sxs-lookup"><span data-stu-id="e4342-117">Windows8 adde d depth comparison functionality to feature level 9\_1 and 9\_3.</span></span> <span data-ttu-id="e4342-118">シャドウ ボリュームを含むレンダリング コードを DirectX 11 に移行できるようになりました。Direct3D 11 レンダラーは機能レベル 9 のデバイスと下位互換性を持ちます。</span><span class="sxs-lookup"><span data-stu-id="e4342-118">Now you can migrate rendering code with shadow volumes to DirectX 11, and the Direct3D 11 renderer will be downlevel compatible with feature level 9 devices.</span></span> <span data-ttu-id="e4342-119">このチュートリアルでは、Direct3D 11 のアプリやゲームで深度のテストを使って従来のシャドウ ボリュームを実装する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="e4342-119">This walkthrough shows how any Direct3D 11 app or game can implement traditional shadow volumes using depth testing.</span></span> <span data-ttu-id="e4342-120">コードは次のプロセスに対応しています。</span><span class="sxs-lookup"><span data-stu-id="e4342-120">The code covers the following process:</span></span>

1.  <span data-ttu-id="e4342-121">シャドウ マッピング用の Direct3D デバイス リソースを作成する。</span><span class="sxs-lookup"><span data-stu-id="e4342-121">Creating Direct3D device resources for shadow mapping.</span></span>
2.  <span data-ttu-id="e4342-122">レンダリング パスを追加して深度マップを作成する。</span><span class="sxs-lookup"><span data-stu-id="e4342-122">Adding a rendering pass to create the depth map.</span></span>
3.  <span data-ttu-id="e4342-123">深度のテストをメイン レンダリング パスに渡す。</span><span class="sxs-lookup"><span data-stu-id="e4342-123">Adding depth testing to the main rendering pass.</span></span>
4.  <span data-ttu-id="e4342-124">必要なシェーダー コードを実行する。</span><span class="sxs-lookup"><span data-stu-id="e4342-124">Implementing the necessary shader code.</span></span>
5.  <span data-ttu-id="e4342-125">下位レベル ハードウェアでのレンダリングを高速化するためのオプション。</span><span class="sxs-lookup"><span data-stu-id="e4342-125">Options for fast rendering on downlevel hardware.</span></span>

<span data-ttu-id="e4342-126">このチュートリアルを終了すると、機能レベル 9\_1 以上と互換性のある Direct3D 11 で互換性のある基本的なシャドウ ボリュームの手法を実装する方法を理解できます。</span><span class="sxs-lookup"><span data-stu-id="e4342-126">Upon completing this walkthrough, you should be familiar with how to implement a basic compatible shadow volume technique in Direct3D 11 that's compatible with feature level 9\_1 and above.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="e4342-127">前提条件</span><span class="sxs-lookup"><span data-stu-id="e4342-127">Prerequisites</span></span>


<span data-ttu-id="e4342-128">[ユニバーサル Windows プラットフォーム (UWP) DirectX ゲームの開発環境を準備する](prepare-your-dev-environment-for-windows-store-directx-game-development.md)必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4342-128">You should [Prepare your dev environment for Universal Windows Platform (UWP) DirectX game development](prepare-your-dev-environment-for-windows-store-directx-game-development.md).</span></span> <span data-ttu-id="e4342-129">テンプレートはまだ必要ありませんが、このチュートリアルのコード サンプルをビルドする Microsoft Visual Studio2015 必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4342-129">You don't need a template yet, but you'll need Microsoft Visual Studio2015 to build the code sample for this walkthrough.</span></span>

## <a name="related-topics"></a><span data-ttu-id="e4342-130">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e4342-130">Related topics</span></span>


**<span data-ttu-id="e4342-131">Direct3D</span><span class="sxs-lookup"><span data-stu-id="e4342-131">Direct3D</span></span>**

* [<span data-ttu-id="e4342-132">Direct3D 9 での HLSL シェーダーの記述</span><span class="sxs-lookup"><span data-stu-id="e4342-132">Writing HLSL Shaders in Direct3D 9</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb944006)
* [<span data-ttu-id="e4342-133">テンプレートからの DirectX ゲーム プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="e4342-133">Create a new DirectX 11 project for UWP</span></span>](user-interface.md)

**<span data-ttu-id="e4342-134">シャドウ マッピングに関する技術記事</span><span class="sxs-lookup"><span data-stu-id="e4342-134">Shadow mapping technical articles</span></span>**

* [<span data-ttu-id="e4342-135">シャドウ深度マップを向上させるための一般的な方法</span><span class="sxs-lookup"><span data-stu-id="e4342-135">Common Techniques to Improve Shadow Depth Maps</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee416324)
* [<span data-ttu-id="e4342-136">カスケードされたシャドウ マップ</span><span class="sxs-lookup"><span data-stu-id="e4342-136">Cascaded Shadow Maps</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee416307)

 

 




