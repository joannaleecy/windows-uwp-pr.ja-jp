---
author: mtoepke
title: "ゲーム プログラミング"
description: "ユニバーサル Windows プラットフォーム (UWP) は、ゲームを作り、配布し、収益を得るための新たな機会を提供します。 新しいゲームの開始または既存のゲームの移植について説明します。"
ms.assetid: 4073b835-c900-4ff2-9fc5-da52f9432a1f
ms.author: mtoepke
ms.date: 06/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, DirectX"
ms.openlocfilehash: 2f98c038c745615d16227334d7e87426394d5c79
ms.sourcegitcommit: a61e9fc06f74dc54c36abf7acb85eeb606e475b8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/15/2017
---
# <a name="game-programming"></a><span data-ttu-id="808ec-105">ゲーム プログラミング</span><span class="sxs-lookup"><span data-stu-id="808ec-105">Game programming</span></span>

<span data-ttu-id="808ec-106">ユニバーサル Windows プラットフォーム (UWP) は、ゲームを作り、配布し、収益を得るための新たな機会を提供します。</span><span class="sxs-lookup"><span data-stu-id="808ec-106">Universal Windows Platform (UWP) offers new opportunities to create, distribute, and monetize games.</span></span> <span data-ttu-id="808ec-107">Windows 10 のゲームの作成について学習します。</span><span class="sxs-lookup"><span data-stu-id="808ec-107">Learn about creating a game for Windows 10.</span></span>

| <span data-ttu-id="808ec-108">トピック</span><span class="sxs-lookup"><span data-stu-id="808ec-108">Topic</span></span> | <span data-ttu-id="808ec-109">説明</span><span class="sxs-lookup"><span data-stu-id="808ec-109">Description</span></span> |
|---------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [<span data-ttu-id="808ec-110">Windows 10 ゲーム開発ガイド</span><span class="sxs-lookup"><span data-stu-id="808ec-110">Windows 10 game development guide</span></span>](e2e.md) | <span data-ttu-id="808ec-111">UWP ゲーム開発のためのリソースや情報を網羅したガイドです。</span><span class="sxs-lookup"><span data-stu-id="808ec-111">An end-to-end guide with resources and information for developing UWP games.</span></span> |
| [<span data-ttu-id="808ec-112">計画</span><span class="sxs-lookup"><span data-stu-id="808ec-112">Planning</span></span>](planning.md) | <span data-ttu-id="808ec-113">このトピックには、ゲームの計画段階に関する記事の一覧が記載されています。</span><span class="sxs-lookup"><span data-stu-id="808ec-113">This topic contains a list of articles for the game planning stage.</span></span> |
| [<span data-ttu-id="808ec-114">UWP プログラミング</span><span class="sxs-lookup"><span data-stu-id="808ec-114">UWP programming</span></span>](uwp-programming.md) | <span data-ttu-id="808ec-115">Windows ランタイム API を使用して UWP ゲームを開発する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="808ec-115">Learn how to use Windows Runtime APIs to develop UWP games.</span></span> |
| [<span data-ttu-id="808ec-116">ゲーム開発ビデオ</span><span class="sxs-lookup"><span data-stu-id="808ec-116">Game development videos</span></span>](game-development-videos.md) | <span data-ttu-id="808ec-117">主要なカンファレンスやイベントで収録された、一連のゲーム開発関連のビデオです。</span><span class="sxs-lookup"><span data-stu-id="808ec-117">A collection of game dev videos from major conferences and events.</span></span> |

<span data-ttu-id="808ec-118">DirectX を使用した UWP ゲームの開発について学ぶには、[DirectX プログラミング](directx-programming.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="808ec-118">To learn about developing UWP games using DirectX, go to [DirectX programming](directx-programming.md).</span></span>

> **<span data-ttu-id="808ec-119">注意</span><span class="sxs-lookup"><span data-stu-id="808ec-119">Note</span></span>**  
<span data-ttu-id="808ec-120">この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。</span><span class="sxs-lookup"><span data-stu-id="808ec-120">This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="808ec-121">Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="808ec-121">If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).</span></span>

 

<span data-ttu-id="808ec-122">ゲーム開発の概要とチュートリアルを最大限に活用するには、次のテーマについて理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="808ec-122">To make the best use of the game development overviews and tutorials, you should be familiar with the following subjects:</span></span>

-   <span data-ttu-id="808ec-123">Microsoft C++ コンポーネント拡張 (C++/CX)</span><span class="sxs-lookup"><span data-stu-id="808ec-123">Microsoft C++ with Component Extensions (C++/CX).</span></span> <span data-ttu-id="808ec-124">これは自動参照カウントが組み込まれた Microsoft C++ の更新であり、DirectX 11.1 以降のバージョンを使って UWP ゲームを開発するための言語です。</span><span class="sxs-lookup"><span data-stu-id="808ec-124">This is an update to Microsoft C++ that incorporates automatic reference counting, and is the language for developing UWP games with DirectX 11.1 or later versions</span></span>
-   <span data-ttu-id="808ec-125">基本的なグラフィックス プログラミング用語</span><span class="sxs-lookup"><span data-stu-id="808ec-125">Basic graphics programming terminology</span></span>
-   <span data-ttu-id="808ec-126">Windows プログラミングの基本的な概念</span><span class="sxs-lookup"><span data-stu-id="808ec-126">Basic Windows programming concepts</span></span>
-   <span data-ttu-id="808ec-127">Direct3D 9 または 11 API に関する基本的な知識</span><span class="sxs-lookup"><span data-stu-id="808ec-127">Basic familiarity with the Direct3D 9 or 11 APIs</span></span>

 

 




