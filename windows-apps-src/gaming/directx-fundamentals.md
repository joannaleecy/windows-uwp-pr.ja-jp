---
title: DirectX プログラミングの基本
description: DirectX プログラミングの基本について説明します。
ms.assetid: 05a1bc59-f32e-44a0-8902-94cf1e099b1b
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, 読み込み, ラスタライズ, メッシュ, ビットマップ, 2D, 3D
ms.localizationpriority: medium
ms.openlocfilehash: afd08d62182bd0980f43ce1c4578c1181f8a6d2f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613747"
---
# <a name="fundamentals-of-directx-programming"></a><span data-ttu-id="525d9-104">DirectX プログラミングの基本</span><span class="sxs-lookup"><span data-stu-id="525d9-104">Fundamentals of DirectX programming</span></span>

<span data-ttu-id="525d9-105">このセクションでは、DirectX プログラミングの基本的な情報について説明します。</span><span class="sxs-lookup"><span data-stu-id="525d9-105">This section provides information about the basic blocks of DirectX programming.</span></span>

<span data-ttu-id="525d9-106">「DirectX ゲームの 2D グラフィックス」トピックでは、2D ビットマップ グラフィックスおよびエフェクトの用途、およびこれらを Direct2D と Direct3D の両方のライブラリにある要素を組み合わせて利用しているゲームで使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="525d9-106">2D graphics for DirectX games topic explains the use of 2D bitmap graphics and effects, and how to use them in your game using a combination of elements from both Direct2D and Direct3D libraries.</span></span>

<span data-ttu-id="525d9-107">「Direct3D グラフィックスの学習ガイド」トピックでは、Direct3D で使われている概念の概要について説明します。</span><span class="sxs-lookup"><span data-stu-id="525d9-107">Direct3D graphics learning guide topic provides an overview of the concepts that Direct3D uses.</span></span>

<span data-ttu-id="525d9-108">「DirectX ゲームの基本的な 3D グラフィックス」トピックでは、3D グラフィックスの基本的な概念について説明します。5 つのパートから成るチュートリアルを利用して、Direct3D の概念や API を紹介します。</span><span class="sxs-lookup"><span data-stu-id="525d9-108">Basic 3D graphics for DirectX games topic explains the fundamental concepts of 3D graphics using a five-part tutorial that introduces the Direct3D concept and API.</span></span> <span data-ttu-id="525d9-109">このチュートリアルでは、Windows ランタイムを使用した Direct3D インターフェイスの初期化、頂点ごとのシェーダー操作の適用、ジオメトリの設定、シーンのラスタライズ、および隠面のカリングの各方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="525d9-109">This tutorial shows you how to initialize Direct3D interfaces using Windows Runtime, apply per-vertex shader operations, set up the geometry, rasterize the scene, and cull hidden surfaces.</span></span>

<span data-ttu-id="525d9-110">「DirectX ゲームでのリソースの読み込み」トピックでは、UWP ゲームで使用するために、メッシュ (モデル)、テクスチャ (ビットマップ)、コンパイル済みシェーダーの各オブジェクトをローカル ストレージや他のデータ ストリームから読み込むための基本的な手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="525d9-110">Load resources in your DirectX game topic guides you through the basic steps for loading meshes (models), textures (bitmaps), and compiled shader objects from local storage or other data streams for use in your UWP game.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="525d9-111">トピック</span><span class="sxs-lookup"><span data-stu-id="525d9-111">Topic</span></span></th>
<th align="left"><span data-ttu-id="525d9-112">説明</span><span class="sxs-lookup"><span data-stu-id="525d9-112">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="525d9-113"><a href="working-with-2d-graphics-in-your-directx-game.md">DirectX ゲームの 2D グラフィック</a></span><span class="sxs-lookup"><span data-stu-id="525d9-113"><a href="working-with-2d-graphics-in-your-directx-game.md">2D graphics for DirectX games</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="525d9-114">DirectX を使用して 2D グラフィックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="525d9-114">Create 2D graphics using DirectX.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="525d9-115"><a href="https://msdn.microsoft.com/windows/uwp/graphics-concepts/index">Direct3D グラフィックス学習ガイド</a></span><span class="sxs-lookup"><span data-stu-id="525d9-115"><a href="https://msdn.microsoft.com/windows/uwp/graphics-concepts/index">Direct3D graphics learning guide</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="525d9-116">Direct3D でのグラフィックスの概念について説明します。</span><span class="sxs-lookup"><span data-stu-id="525d9-116">Understand Direct3D graphics concepts.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="525d9-117"><a href="an-introduction-to-3d-graphics-with-directx.md">DirectX ゲーム用の基本的な 3D グラフィック</a></span><span class="sxs-lookup"><span data-stu-id="525d9-117"><a href="an-introduction-to-3d-graphics-with-directx.md">Basic 3D graphics for DirectX games</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="525d9-118">DirectX の基本的な 3D グラフィックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="525d9-118">Create basic 3D DirectX graphics.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="525d9-119"><a href="load-a-game-asset.md">DirectX ゲームでリソースを読み込む</a></span><span class="sxs-lookup"><span data-stu-id="525d9-119"><a href="load-a-game-asset.md">Load resources in your DirectX game</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="525d9-120">DirectX ゲームでメッシュを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="525d9-120">Load meshes in your DirectX game.</span></span></p></td>
</tr>
</tbody>
</table>