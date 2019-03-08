---
title: チュートリアル -- Direct3D 11 のシャドウ ボリュームの深度バッファー
description: このチュートリアルでは、すべての Direct3D 機能レベルのデバイスで Direct3D 11 を使い、深度マップを利用してシャドウ ボリュームをレンダリングする方法について説明します。
ms.assetid: d15e6501-1a1d-d99c-d1d8-ad79b849db90
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, シャドウ ボリューム, 深度バッファー, DirectX 11
ms.localizationpriority: medium
ms.openlocfilehash: 2feecb3080efefb2f9625fd8b66c5b722ad02a45
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622277"
---
# <a name="walkthrough-implement-shadow-volumes-using-depth-buffers-in-direct3d-11"></a><span data-ttu-id="fb3f8-104">チュートリアル:Direct3d11 の深度バッファーを使用してボリュームをシャドウの実装します。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-104">Walkthrough: Implement shadow volumes using depth buffers in Direct3D 11</span></span>



<span data-ttu-id="fb3f8-105">このチュートリアルでは、すべての Direct3D 機能レベルのデバイスで Direct3D 11 を使い、深度マップを利用してシャドウ ボリュームをレンダリングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-105">This walkthrough demonstrates how to render shadow volumes using depth maps, using Direct3D 11 on devices of all Direct3D feature levels.</span></span>
## 
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="fb3f8-106">トピック</span><span class="sxs-lookup"><span data-stu-id="fb3f8-106">Topic</span></span></th>
<th align="left"><span data-ttu-id="fb3f8-107">説明</span><span class="sxs-lookup"><span data-stu-id="fb3f8-107">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="fb3f8-108"><a href="create-depth-buffer-resource--view--and-sampler-state.md">深度バッファー デバイス リソースを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="fb3f8-108"><a href="create-depth-buffer-resource--view--and-sampler-state.md">Create depth buffer device resources</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="fb3f8-109">シャドウ ボリュームの深度のテストをサポートするために必要な Direct3D デバイス リソースを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-109">Learn how to create the Direct3D device resources necessary to support depth testing for shadow volumes.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="fb3f8-110"><a href="render-the-shadow-map-to-the-depth-buffer.md">深度バッファーにシャドウ マップを表示します。</a></span><span class="sxs-lookup"><span data-stu-id="fb3f8-110"><a href="render-the-shadow-map-to-the-depth-buffer.md">Render the shadow map to the depth buffer</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="fb3f8-111">ライトの視点からレンダリングして、シャドウ ボリュームを表す 2 次元の深度マップを作成します。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-111">Render from the point of view of the light to create a two-dimensional depth map representing the shadow volume.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="fb3f8-112"><a href="render-the-scene-with-depth-testing.md">深度テストとシーンをレンダリングします。</a></span><span class="sxs-lookup"><span data-stu-id="fb3f8-112"><a href="render-the-scene-with-depth-testing.md">Render the scene with depth testing</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="fb3f8-113">シャドウ効果を作成するには、頂点 (またはジオメトリ) シェーダーとピクセル シェーダーに深度のテストを追加します。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-113">Create a shadow effect by adding depth testing to your vertex (or geometry) shader and your pixel shader.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="fb3f8-114"><a href="target-a-range-of-hardware.md">さまざまなハードウェアでシャドウ マップをサポートします。</a></span><span class="sxs-lookup"><span data-stu-id="fb3f8-114"><a href="target-a-range-of-hardware.md">Support shadow maps on a range of hardware</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="fb3f8-115">より高速なデバイスでは高品質なシャドウを、性能が低いデバイスではよりすばやいシャドウをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-115">Render higher-fidelity shadows on faster devices and faster shadows on less powerful devices.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="shadow-mapping-application-to-direct3d-9-desktop-porting"></a><span data-ttu-id="fb3f8-116">Direct3D 9 デスクトップに対するシャドウ マップの適用の移植</span><span class="sxs-lookup"><span data-stu-id="fb3f8-116">Shadow mapping application to Direct3D 9 desktop porting</span></span>


<span data-ttu-id="fb3f8-117">Windows 8 adde 9 の機能レベルを比較機能を d 深さ\_1 から 9\_3。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-117">Windows 8 adde d depth comparison functionality to feature level 9\_1 and 9\_3.</span></span> <span data-ttu-id="fb3f8-118">シャドウ ボリュームを含むレンダリング コードを DirectX 11 に移行できるようになりました。Direct3D 11 レンダラーは機能レベル 9 のデバイスと下位互換性を持ちます。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-118">Now you can migrate rendering code with shadow volumes to DirectX 11, and the Direct3D 11 renderer will be downlevel compatible with feature level 9 devices.</span></span> <span data-ttu-id="fb3f8-119">このチュートリアルでは、Direct3D 11 のアプリやゲームで深度のテストを使って従来のシャドウ ボリュームを実装する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-119">This walkthrough shows how any Direct3D 11 app or game can implement traditional shadow volumes using depth testing.</span></span> <span data-ttu-id="fb3f8-120">コードは次のプロセスに対応しています。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-120">The code covers the following process:</span></span>

1.  <span data-ttu-id="fb3f8-121">シャドウ マッピング用の Direct3D デバイス リソースを作成する。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-121">Creating Direct3D device resources for shadow mapping.</span></span>
2.  <span data-ttu-id="fb3f8-122">レンダリング パスを追加して深度マップを作成する。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-122">Adding a rendering pass to create the depth map.</span></span>
3.  <span data-ttu-id="fb3f8-123">深度のテストをメイン レンダリング パスに渡す。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-123">Adding depth testing to the main rendering pass.</span></span>
4.  <span data-ttu-id="fb3f8-124">必要なシェーダー コードを実行する。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-124">Implementing the necessary shader code.</span></span>
5.  <span data-ttu-id="fb3f8-125">下位レベル ハードウェアでのレンダリングを高速化するためのオプション。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-125">Options for fast rendering on downlevel hardware.</span></span>

<span data-ttu-id="fb3f8-126">このチュートリアルを完了すると、9 の機能レベルと互換性がある direct3d11 の基本的な互換性のあるシャドウ ボリュームの手法を実装する方法を理解しておく必要がありますあります\_1 以上です。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-126">Upon completing this walkthrough, you should be familiar with how to implement a basic compatible shadow volume technique in Direct3D 11 that's compatible with feature level 9\_1 and above.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="fb3f8-127">前提条件</span><span class="sxs-lookup"><span data-stu-id="fb3f8-127">Prerequisites</span></span>


<span data-ttu-id="fb3f8-128">[ユニバーサル Windows プラットフォーム (UWP) DirectX ゲームの開発環境を準備する](prepare-your-dev-environment-for-windows-store-directx-game-development.md)必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-128">You should [Prepare your dev environment for Universal Windows Platform (UWP) DirectX game development](prepare-your-dev-environment-for-windows-store-directx-game-development.md).</span></span> <span data-ttu-id="fb3f8-129">テンプレートは、まだ必要はありませんが、このチュートリアルのコード サンプルをビルドする、Microsoft Visual Studio 2015 が必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-129">You don't need a template yet, but you'll need Microsoft Visual Studio 2015 to build the code sample for this walkthrough.</span></span>

## <a name="related-topics"></a><span data-ttu-id="fb3f8-130">関連トピック</span><span class="sxs-lookup"><span data-stu-id="fb3f8-130">Related topics</span></span>


<span data-ttu-id="fb3f8-131">**Direct3D**</span><span class="sxs-lookup"><span data-stu-id="fb3f8-131">**Direct3D**</span></span>

* [<span data-ttu-id="fb3f8-132">Direct3D 9 での HLSL シェーダーの記述</span><span class="sxs-lookup"><span data-stu-id="fb3f8-132">Writing HLSL Shaders in Direct3D 9</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb944006)
* [<span data-ttu-id="fb3f8-133">UWP の DirectX 11 の新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="fb3f8-133">Create a new DirectX 11 project for UWP</span></span>](user-interface.md)

<span data-ttu-id="fb3f8-134">**シャドウの技術情報のマッピング**</span><span class="sxs-lookup"><span data-stu-id="fb3f8-134">**Shadow mapping technical articles**</span></span>

* [<span data-ttu-id="fb3f8-135">影の深さのマップを向上させるために一般的な手法</span><span class="sxs-lookup"><span data-stu-id="fb3f8-135">Common Techniques to Improve Shadow Depth Maps</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee416324)
* [<span data-ttu-id="fb3f8-136">カスケード シャドウ マップ</span><span class="sxs-lookup"><span data-stu-id="fb3f8-136">Cascaded Shadow Maps</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee416307)

 

 




