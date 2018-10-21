---
title: Xbox Live API の新規事項 - August 2017
author: KevinAsgari
description: Xbox Live API の新規事項 - August 2017
ms.assetid: ''
ms.author: kevinasg
ms.date: 08/16/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 新規事項, august 2017
ms.localizationpriority: medium
ms.openlocfilehash: f9c92d679e85e2ba6154bba607e8ed2112752652
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5158989"
---
# <a name="whats-new-for-the-xbox-live-apis---august-2017"></a><span data-ttu-id="48cf7-104">Xbox Live API の新規事項 - August 2017</span><span class="sxs-lookup"><span data-stu-id="48cf7-104">What's new for the Xbox Live APIs - August 2017</span></span>

<span data-ttu-id="48cf7-105">July 2017 リリースで追加された内容については、「[新規事項 - July 2017](1707-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="48cf7-105">Please see the [What's New - July 2017](1707-whats-new.md) article for what was added in the July 2017 release.</span></span>

<span data-ttu-id="48cf7-106">[Xbox Live API GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="48cf7-106">You can also check the [Xbox Live API GitHub commit history](https://github.com/Microsoft/xbox-live-api/commits/master) to see all of the recent code changes to the Xbox Live APIs.</span></span>

## <a name="xbox-live-features"></a><span data-ttu-id="48cf7-107">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="48cf7-107">Xbox Live features</span></span>

### <a name="in-game-clubs"></a><span data-ttu-id="48cf7-108">ゲーム内クラブ</span><span class="sxs-lookup"><span data-stu-id="48cf7-108">In-Game clubs</span></span>

<span data-ttu-id="48cf7-109">開発者は、"ゲーム内クラブ" を作成できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="48cf7-109">Developers can now create "in-game clubs".</span></span> <span data-ttu-id="48cf7-110">ゲーム内クラブは、開発者が完全にカスタマイズ可能であり、ゲームの内部と外部の両方で使うことができる点で標準の Xbox クラブとは異なります、</span><span class="sxs-lookup"><span data-stu-id="48cf7-110">In-game clubs differ from standard Xbox clubs in that they are fully customizable by a developer and can be used both inside and outside of the game.</span></span> <span data-ttu-id="48cf7-111">ゲーム開発者は、これらを使って、チーム、仲間、スクワッドなど、独自の要件を満たすあらゆる種類の永続グループ シナリオをゲーム内にすばやく構築することができます。</span><span class="sxs-lookup"><span data-stu-id="48cf7-111">As a game developer, you can use them to quickly build any type of persistent group scenarios inside your games such as teams, clans, squads, guilds, etc. that match your unique requirements.</span></span>

<span data-ttu-id="48cf7-112">Xbox Live メンバーは、Xbox コンソール、PC、または iOS/Android デバイスで自由にチャット、フィード、LFG、Mixer などのクラブ機能を使って、どの Xbox エクスペリエンスにおいてもゲームの外部でゲーム内クラブにアクセスして相互につながり、ゲームとの接続を維持できます。</span><span class="sxs-lookup"><span data-stu-id="48cf7-112">Xbox live members can access in-game clubs outside of your game across any Xbox experience to stay connected to each other and to your game by using club features like chat, feed, LFG, and Mixer freely on Xbox console, PC, or iOS/Android devices.</span></span>

<span data-ttu-id="48cf7-113">API を使うと、ゲーム内から直接ゲーム内クラブを作成および管理できます。</span><span class="sxs-lookup"><span data-stu-id="48cf7-113">APIs are available to create & manage in-game clubs directly from within your game.</span></span> <span data-ttu-id="48cf7-114">これらの API は、xbox::services::clubs 名前空間に存在します。</span><span class="sxs-lookup"><span data-stu-id="48cf7-114">These APIs exist in the xbox::services::clubs namespace.</span></span>
