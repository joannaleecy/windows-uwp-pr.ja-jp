---
author: joannaleecy
title: DirectX ゲームの最適化と高度なトピック
description: DirectX ゲーム プログラミングの最適化と高度なトピックについて説明します。
ms.assetid: b5f29fb2-3bcf-43b2-9a68-f8819473bf62
ms.author: joanlee
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, 最適化, マルチサンプリング, スワップ チェーン
ms.localizationpriority: medium
ms.openlocfilehash: e1a9b16dcf8c40c2b1db4af172d97009563e677a
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5836734"
---
# <a name="optimization-and-advanced-topics-for-directx-games"></a><span data-ttu-id="d0c5c-104">DirectX ゲームの最適化と高度なトピック</span><span class="sxs-lookup"><span data-stu-id="d0c5c-104">Optimization and advanced topics for DirectX games</span></span>

<span data-ttu-id="d0c5c-105">このセクションでは、DirectX ゲームのパフォーマンスの最適化と他の高度なトピックについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-105">This section provides information about optimizing your DirectX game performance and other advanced topics.</span></span>

<span data-ttu-id="d0c5c-106">「ゲームの非同期プログラミング」トピックでは、非同期プログラミングを使用して一部のコンポーネントを並列化し、マルチスレッドを使用して強力な GPU は最大限に活用する際のさまざまな考慮事項について取り上げます。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-106">Asynchronous programming for games topic discusses the various points to consider when you want to use asynchronous programming to parallelize some of the components and use multithreading to maximise the use of a powerful GPU.</span></span>

<span data-ttu-id="d0c5c-107">「Direct3D 11 でのデバイス削除シナリオの処理」トピックでは、チュートリアルを使用して、Direct3D 11 で開発したゲームがグラフィックス アダプターのリセット、取り外し、変更の状況をどのように検出し対応するかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-107">Handle device removed scenarios in Direct3D 11 topic uses a walkthrough to explain how games developed using Direct3D 11 can detect and respond to situations where the graphics adapter is reset, removed, or changed.</span></span>

<span data-ttu-id="d0c5c-108">「UWP アプリでのマルチサンプリング」トピックでは、マルチサンプル アンチエイリアシングの使用方法の概要について説明します。マルチサンプル アンチエイリアシングとは、Direct3D を使って構築された UWP ゲームでエッジを滑らかに描画するために使用されるグラフィックス技法です。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-108">Multisampling in UWP apps topic provides an overview of how to use multi-sample antialiasing, a graphics technique to reduce the appearance of aliased edges in UWP games built with Direct3D.</span></span>

<span data-ttu-id="d0c5c-109">「入力とレンダリング ループの最適化」トピックでは、入力待ち時間の管理とレンダリング ループの最適化で必要となる適切な入力イベント処理オプションを選ぶ方法のガイダンスを示します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-109">Optimize input and rendering loop topic provides guidance on how to choose the right input event processing option to manage input latency and optimize the rendering loop.</span></span>

<span data-ttu-id="d0c5c-110">「DXGI 1.3 スワップ チェーンによる遅延の減少」トピックでは、スワップ チェーンが新しいフレームのレンダリング開始の適切な時間を通知するまで待機することによって実質的なフレーム待機時間を短縮する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-110">Reduce latency with DXGI 1.3 swap chains topic explains how to reduce effective frame latency by waiting for the swap chain to signal the appropriate time to begin rendering a new frame.</span></span>

<span data-ttu-id="d0c5c-111">「スワップ チェーンのスケーリングとオーバーレイ」トピックでは、レンダリングにかかる時間を改善する方法について説明します。そのためには、スケーリングされたスワップ チェーンを使用し、ディスプレイのネイティブの機能よりも低い解像度でリアルタイムのゲーム コンテンツをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-111">Swap chain scaling and overlays topic explains how to improve rendering times by using scaled swap chains to render real-time game content at a lower resolution than the display is natively capable of.</span></span> <span data-ttu-id="d0c5c-112">また、ハードウェア オーバーレイ機能を使ってデバイスのオーバーレイ スワップ チェーンを作成する方法についても説明します。この方法を使用して、スワップ チェーンのスケーリングが原因で発生する、縮小された UI の問題を改善することができます。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-112">It also explains how to create overlay swap chains for devices with the hardware overlay capability; this technique can be used to alleviate the issue of a scaled down UI resulting from the use of swap chain scaling.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="d0c5c-113">トピック</span><span class="sxs-lookup"><span data-stu-id="d0c5c-113">Topic</span></span></th>
<th align="left"><span data-ttu-id="d0c5c-114">説明</span><span class="sxs-lookup"><span data-stu-id="d0c5c-114">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="asynchronous-programming-directx-and-cpp.md"><span data-ttu-id="d0c5c-115">ゲームの非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="d0c5c-115">Asynchronous programming for games</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d0c5c-116">DirectX での非同期プログラミングとスレッド化について説明します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-116">Understand asynchronous programming and threading with DirectX.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="handling-device-lost-scenarios.md"><span data-ttu-id="d0c5c-117">Direct3D 11 でのデバイス削除シナリオの処理</span><span class="sxs-lookup"><span data-stu-id="d0c5c-117">Handle device removed scenarios in Direct3D 11</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d0c5c-118">グラフィックス アダプターの取り外しや再初期化が行われたときに Direct3D と DXGI デバイス インターフェイス チェーンを再作成します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-118">Recreate the Direct3D and DXGI device interface chain when the graphics adapter is removed or reinitialized.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="multisampling--multi-sample-anti-aliasing--in-windows-store-apps.md"><span data-ttu-id="d0c5c-119">UWP アプリでのマルチサンプリング</span><span class="sxs-lookup"><span data-stu-id="d0c5c-119">Multisampling in UWP apps</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d0c5c-120">Direct3D を使って構築された UWP ゲームでマルチサンプリングを使用します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-120">Use multisampling in UWP games built using Direct3D.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="optimize-performance-for-windows-store-direct3d-11-apps-with-coredispatcher.md"><span data-ttu-id="d0c5c-121">入力とレンダリング ループの最適化</span><span class="sxs-lookup"><span data-stu-id="d0c5c-121">Optimize input and rendering loop</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d0c5c-122">入力待ち時間を短縮し、レンダリング ループを最適化します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-122">Reduce input latency and optimize the rendering loop.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="reduce-latency-with-dxgi-1-3-swap-chains.md"><span data-ttu-id="d0c5c-123">DXGI 1.3 スワップ チェーンによる遅延の減少</span><span class="sxs-lookup"><span data-stu-id="d0c5c-123">Reduce latency with DXGI 1.3 swap chains</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d0c5c-124">DXGI 1.3を使って、実質的なフレーム待機時間を短縮します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-124">Use DXGI 1.3 to reduce the effective frame latency.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="multisampling--scaling--and-overlay-swap-chains.md"><span data-ttu-id="d0c5c-125">スワップ チェーンのスケーリングとオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="d0c5c-125">Swap chain scaling and overlays</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d0c5c-126">モバイル デバイスでのレンダリングを高速化するためにスケーリングされたスワップ チェーンを作成し、オーバーレイ スワップ チェーンを使用して画質を改善します。</span><span class="sxs-lookup"><span data-stu-id="d0c5c-126">Create scaled swap chains for faster rendering on mobile devices, and use overlay swap chains to increase the visual quality.</span></span></p></td>
</tr>
</tbody>
</table>