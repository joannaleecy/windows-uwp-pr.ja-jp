---
title: "パートナーとして Xbox Live を使用する際の概要"
author: KevinAsgari
description: "対象パートナーや ID@Xbox メンバーが Xbox Live の開発を始める際に役立つリンクを紹介します。"
ms.assetid: 69ab75d1-c0e7-4bad-bf8f-5df5cfce13d5
ms.author: kevinasg
ms.date: 06-07-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, パートナー, ID@Xbox"
ms.openlocfilehash: c26e5afb3ba99a010e3663e6eefae09082fa989a
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="getting-started-with-xbox-live-as-a-managed-partner-or-an-idxbox-developer"></a><span data-ttu-id="49109-104">パートナーまたは ID@Xbox 開発者として Xbox Live の利用を開始する</span><span class="sxs-lookup"><span data-stu-id="49109-104">Getting started with Xbox Live as a managed partner or an ID@Xbox developer</span></span>

<span data-ttu-id="49109-105">このセクションでは、パートナーまたは ID@Xbox 開発者として Xbox Live の利用を開始する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="49109-105">This section covers getting started with Xbox Live as a managed partner or as an ID@Xbox developer.</span></span> <span data-ttu-id="49109-106">パートナーや ID 開発者は、実績やマルチプレイヤーなど、Xbox Live の機能をすべて利用できます。</span><span class="sxs-lookup"><span data-stu-id="49109-106">Partners and ID developers can access the full range of Xbox Live features, including achievements, multiplayer, and more.</span></span>

<span data-ttu-id="49109-107">対象パートナーおよび ID@Xbox 開発者は、ユニバーサル Windows プラットフォーム (UWP) や Xbox 開発キット (XDK) プラットフォームに対応した Xbox Live タイトルを開発できます。</span><span class="sxs-lookup"><span data-stu-id="49109-107">Managed partners and ID@Xbox developers can develop Xbox Live titles for both the Universal Windows Platform (UWP) or the Xbox Developer Kit (XDK) platform.</span></span>

<span data-ttu-id="49109-108">ここで紹介するコンテンツ以外にも、承認されているデベロッパー センター アカウントを持っているパートナーが利用できるその他のドキュメントが用意されています。</span><span class="sxs-lookup"><span data-stu-id="49109-108">In addition to the content available here, there is also additional documentation that is available to partners with an authorized Dev Center account.</span></span> <span data-ttu-id="49109-109">そのようなコンテンツには、[Xbox Live パートナー コンテンツ](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/partner-content)でアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="49109-109">You can access that content here: [Xbox Live partner content](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/partner-content).</span></span>

## <a name="why-should-you-use-xbox-live"></a><span data-ttu-id="49109-110">Xbox Live を使用する理由</span><span class="sxs-lookup"><span data-stu-id="49109-110">Why should you use Xbox Live?</span></span>

<span data-ttu-id="49109-111">Xbox Live には、ゲームの販売を促進し、ゲーマーの関心を引き付けておくために設計された一連の機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="49109-111">Xbox Live offers an array of features designed to help promote your game and keep gamers engaged:</span></span>

- <span data-ttu-id="49109-112">Xbox Live ソーシャル プラットフォームを使用すると、ゲーマーはフレンドと接続してゲームについて会話することができます。</span><span class="sxs-lookup"><span data-stu-id="49109-112">Xbox Live social platform lets gamers connect with friends and talk about your game.</span></span>
- <span data-ttu-id="49109-113">Xbox Live の実績を利用すると、ゲーマーが実績のロックを解除したときに、Xbox Live のソーシャル グラフにゲームの無料プロモーションが提供され、ゲームの人気を高める際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="49109-113">Xbox Live achievements helps your game get popular by giving your game free promotion to the Xbox Live social graph when gamers unlock achievements.</span></span>
- <span data-ttu-id="49109-114">Xbox Live のランキングを利用すると、ゲーマーがフレンドに勝ってランクを上げることが可能になり、ゲームに対するユーザーの関心を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="49109-114">Xbox Live leaderboards helps drive engagement of your game by letting gamers compete to beat their friends and move up the ranks.</span></span>
- <span data-ttu-id="49109-115">Xbox Live のマルチプレイヤーを利用すると、ゲーマーがフレンドと一緒にプレイしたり、他のプレイヤーとのマッチメイキングによってゲーム内で戦ったり協力したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="49109-115">Xbox Live multiplayer lets gamers play with their friends or a get matched with other players to compete or cooperate in your game.</span></span>
- <span data-ttu-id="49109-116">Xbox Live の接続ストレージでは、デバイス間でゲームのセーブ データを無料でローミングでき、ゲーマーは Xbox One と Windows PC の間で簡単にゲームの進行を継続することができます。</span><span class="sxs-lookup"><span data-stu-id="49109-116">Xbox Live connected storage offers free save game roaming between devices so gamers can easily continue game progress between Xbox One and Windows PC.</span></span>

## <a name="in-this-section"></a><span data-ttu-id="49109-117">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="49109-117">In this section</span></span>

[<span data-ttu-id="49109-118">開発者プログラムの概要</span><span class="sxs-lookup"><span data-stu-id="49109-118">Developer Program Overview</span></span>](../developer-program-overview.md)

[<span data-ttu-id="49109-119">対象パートナーおよび ID@Xbox 向けに Xbox Live を統合するためのステップ バイ ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="49109-119">Step by step guide to integrate Xbox Live for managed partners and ID@Xbox</span></span>](partners-step-by-step-guide.md)

[<span data-ttu-id="49109-120">新しいタイトルを作成する</span><span class="sxs-lookup"><span data-stu-id="49109-120">Create a new title</span></span>](create-a-new-title.md)

[<span data-ttu-id="49109-121">Visual Studio と UWP の使用に関する概要</span><span class="sxs-lookup"><span data-stu-id="49109-121">Get started with Visual Studio and UWP</span></span>](get-started-with-visual-studio-and-uwp.md)

[<span data-ttu-id="49109-122">対象パートナーや ID@Xbox メンバーとして Xbox Live サポートを Unity UWP タイトルに 追加する</span><span class="sxs-lookup"><span data-stu-id="49109-122">Add Xbox Live to a Unity UWP title as a managed partner or ID@Xbox member</span></span>](partner-add-xbox-live-to-unity-uwp.md)

[<span data-ttu-id="49109-123">Xbox Live と Xbox 開発キット (XDK) の使用に関する概要</span><span class="sxs-lookup"><span data-stu-id="49109-123">Get started with Xbox Live and the Xbox Developer Kit (XDK)</span></span>](xdk-developers.md)

[<span data-ttu-id="49109-124">クロスプレイ ゲームの概要</span><span class="sxs-lookup"><span data-stu-id="49109-124">Get started with cross-play games</span></span>](get-started-with-cross-play-games.md)

[<span data-ttu-id="49109-125">高度な Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="49109-125">Advanced Xbox Live sandboxes</span></span>](../advanced-xbox-live-sandboxes.md)
