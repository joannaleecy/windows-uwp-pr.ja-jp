---
title: コンテキスト検索
author: KevinAsgari
description: コンテキスト検索を使用し、関連するメタデータを使って配信やゲーム クリップに自動的にタグ付けする方法を説明します。
ms.assetid: 0c2afbfa-f32a-4ddd-9e9e-c8ac7eedae18
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, コンテキスト検索, 配信, ゲーム クリップ
ms.localizationpriority: medium
ms.openlocfilehash: 17d24b31087db9c73f6b286a140c6dcf3a7e1eb4
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7554687"
---
# <a name="contextual-search"></a><span data-ttu-id="d1110-104">コンテキスト検索</span><span class="sxs-lookup"><span data-stu-id="d1110-104">Contextual Search</span></span>

## <a name="introducing-contextual-search"></a><span data-ttu-id="d1110-105">コンテキスト検索の概要</span><span class="sxs-lookup"><span data-stu-id="d1110-105">Introducing Contextual Search</span></span>
<span data-ttu-id="d1110-106">コンテキスト検索は、ゲーム メディア コンテンツの次世代シナリオを実現する新しい Xbox Live サービスです。</span><span class="sxs-lookup"><span data-stu-id="d1110-106">Contextual Search is a new Xbox Live Service that enables truly next gen scenarios for gaming media content.</span></span>  <span data-ttu-id="d1110-107">コンテキスト検索を利用すると、Xbox Live では、指定されたリアルタイム統計を使用して、自動的にゲームからの配信やゲーム クリップにタグ付けします。</span><span class="sxs-lookup"><span data-stu-id="d1110-107">With Contextual Search,  Xbox Live automatically tags broadcasts and game clips from your game with real time stats of your choosing.</span></span> <span data-ttu-id="d1110-108">たとえば、ユーザーのレベル、ユーザーが持っている武器、またはユーザーの現在のキル/デス (K/D) 比率でゲーム クリップにタグ付けすることを選択できます。</span><span class="sxs-lookup"><span data-stu-id="d1110-108">For example, you could choose to tag a game clip with the level the user is on, the weapon they are carrying, or perhaps their current K/D ratio.</span></span>  <span data-ttu-id="d1110-109">また、Xbox Live ではこのデータに基づく検索インターフェイスが公開されており、ユーザーまたはタイトルは最も興味深いコンテンツを探して表示することができます。</span><span class="sxs-lookup"><span data-stu-id="d1110-109">Xbox Live also  exposes a search interface off this data, enabling users or titles to discover and surface the perfect content.</span></span>  <span data-ttu-id="d1110-110">たとえば、ユーザーはコンテキスト検索を利用して、Halo 2 のゲーム クリップで作成者が Slayer on Lockout または Blood Gulch をプレイしているものをすべて検索し、プレイヤーのランクで並べ替えた結果を表示して、最も興味深いコンテンツを確実に先頭に表示させることができます。</span><span class="sxs-lookup"><span data-stu-id="d1110-110">For example, leveraging Contextual Search, a user could find all the Halo 2 game clips where the creator is playing Slayer on Lockout or Blood Gulch and have the results sorted by the players rank, ensuring the best content bubbles to the top.</span></span>  

<span data-ttu-id="d1110-111">コンテキスト検索は、ゲームのデータと Xbox Live の機能を利用して、多くの強力なシナリオを実現します。</span><span class="sxs-lookup"><span data-stu-id="d1110-111">Contextual Search flexes your game's data and the power of Xbox Live to unlock a number of powerful scenarios.</span></span>  <span data-ttu-id="d1110-112">次のようなシナリオが考えられます。</span><span class="sxs-lookup"><span data-stu-id="d1110-112">This includes:</span></span>

* <span data-ttu-id="d1110-113">ゲームのコンテキスト ヘルプ</span><span class="sxs-lookup"><span data-stu-id="d1110-113">Contextual game help</span></span>
* <span data-ttu-id="d1110-114">最も人気のあるコンテンツ作成者の紹介</span><span class="sxs-lookup"><span data-stu-id="d1110-114">Showcasing top content creators</span></span>
* <span data-ttu-id="d1110-115">新しい DLC の内容の確認</span><span class="sxs-lookup"><span data-stu-id="d1110-115">Surface new DLC in action</span></span>
* <span data-ttu-id="d1110-116">作成者のコメントをコンテキストに応じて配信</span><span class="sxs-lookup"><span data-stu-id="d1110-116">Contextually deliver creator commentary</span></span>

<span data-ttu-id="d1110-117">単に XDP またはパートナー センターで構成すると、タイトルのコンテキスト検索は自動的に点灯しませんブロードキャスト アプリケーションをすぐに、Xbox のシェルと Cortana で後日。</span><span class="sxs-lookup"><span data-stu-id="d1110-117">Simply by configuring in XDP or Partner Center, Contextual Search for your title will automatically light up in broadcasting applications immediately, and the Xbox Shell and Cortana at a later date.</span></span>  <span data-ttu-id="d1110-118">さらに、ゲーム内で検索 API を直接利用すれば、ゲームから離れることなく、今までにないエクスペリエンスをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="d1110-118">Additionally, titles can leverage the search APIs directly in game, enabling differentiated experiences for users without leaving the game.</span></span>  <span data-ttu-id="d1110-119">統合のレベルに関係なく、タイトルの価値や知名度を大きく高めることができます。</span><span class="sxs-lookup"><span data-stu-id="d1110-119">Regardless of the level of integration, you'll generate a tremendous amount of value and exposure for your title.</span></span>
