---
title: プレイヤーの統計
author: aablackm
description: 統計 2017年の概要
ms.author: aablackm
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム、uwp、windows 10, xbox one、プレイヤーの統計、ランキング, 統計 2017
ms.localizationpriority: medium
ms.openlocfilehash: 24e953dcca8f57b689cdee879551b188aa01f42f
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4500550"
---
# <a name="stats-2017"></a><span data-ttu-id="9647b-104">統計 2017</span><span class="sxs-lookup"><span data-stu-id="9647b-104">Stats 2017</span></span>

<span data-ttu-id="9647b-105">統計 2017年で、進行状況やゲームでの削減を示す個々 のプレイヤーの統計を構成する開発者ができます。</span><span class="sxs-lookup"><span data-stu-id="9647b-105">Stats 2017 allows developers to configure stats for individual players signifying progress and prowess in game.</span></span> <span data-ttu-id="9647b-106">これらの統計は、フレンドより大きなタイトルのコミュニティといくつかの機能とを提供するには、タイトルの課題を示すことで競争力のあるプレイヤーを許可するソーシャル ツールです。</span><span class="sxs-lookup"><span data-stu-id="9647b-106">These stats are a social tool that will allow players to be more competitive with their friends and the larger title's community, as well as showcasing some of the capabilities and challenges your title has to offer.</span></span> <span data-ttu-id="9647b-107">最も長いドリフトとハングに最適なタイミングと同様に注目の統計のレーシング ゲームがある場合、プレイヤーが期待できるレーシング ゲームの種類を伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="9647b-107">If you have a racing game with featured statistics like longest drift and best hang time, you can communicate the type of racing game your players can expect.</span></span> <span data-ttu-id="9647b-108">方法がフレンドとコミュニティ全体に対してプレイヤー スタックにより、それらを購入して、タイトルをプレイする複数のインセンティブを表示します。</span><span class="sxs-lookup"><span data-stu-id="9647b-108">Seeing how players stack against their friends and the community at large will give them more incentive to buy and play your title.</span></span> <span data-ttu-id="9647b-109">プレイヤーは、注目の統計をタイトルのゲーム ハブに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9647b-109">Players will see featured statistics on the title's GameHub.</span></span> <span data-ttu-id="9647b-110">注目の統計は、ユーザーは、[ホーム] ビューに追加される可能性をピン留めされたコンテンツのブロックで定期的にもあります。</span><span class="sxs-lookup"><span data-stu-id="9647b-110">Featured Stats may also periodically appear in pinned content blocks that users may add to their Home view.</span></span>

<span data-ttu-id="9647b-111">統計 2017年は、タイトルからのキーの値のペアとしてプレイヤーの統計値を受け入れると、後で表示できるように、その統計値を格納するでは動作します。</span><span class="sxs-lookup"><span data-stu-id="9647b-111">Stats 2017 operates by accepting stat values as key value pairs from your title for a player and storing that stat value so that it can be displayed at a later time.</span></span> <span data-ttu-id="9647b-112">統計 2017年と比較して、後で、ランキングの順位の高いし、できるように、個々 のプレイヤーの統計を保存することによって Xbox Live のランキングのシナリオをサポートするものです。</span><span class="sxs-lookup"><span data-stu-id="9647b-112">Stats 2017 is meant to support Xbox Live leaderboard scenarios by saving stats about individual players so they can be compared and ranked on a leaderboard later.</span></span> <span data-ttu-id="9647b-113">統計 2017年では、すべての統計の正しい値を決定するロジックを処理するタイトルは、ほとんど検証なしに送信された値を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="9647b-113">Stats 2017 accepts values sent to it with little to no validation so it is up to your title to handle all of the logic which determines the correct value for a stat.</span></span>

## <a name="configured-stats-and-featured-leaderboards"></a><span data-ttu-id="9647b-114">構成済みの統計と注目ランキング</span><span class="sxs-lookup"><span data-stu-id="9647b-114">Configured stats and featured leaderboards</span></span>

<span data-ttu-id="9647b-115">[Windows デベロッパー センター ダッシュ ボード](https://developer.microsoft.com/en-us/dashboard/windows/overview)の統計を構成します。</span><span class="sxs-lookup"><span data-stu-id="9647b-115">Stats are configured on the [Windows Development Center dashboard](https://developer.microsoft.com/en-us/dashboard/windows/overview).</span></span> <span data-ttu-id="9647b-116">統計を構成するためには、タイトルの構成をすでに必要があります。</span><span class="sxs-lookup"><span data-stu-id="9647b-116">In order to configure stats you must already have a title configured.</span></span> <span data-ttu-id="9647b-117">タイトルの構成を用意していない場合の読み取りを行うにはこれを方法については[作成し、新しい作成者のタイトルをテスト](../get-started-with-creators/create-and-test-a-new-creators-title.md)します。</span><span class="sxs-lookup"><span data-stu-id="9647b-117">If you do not have a title configured you can learn how to do so by reading [Create and test a new Creator's title](../get-started-with-creators/create-and-test-a-new-creators-title.md).</span></span>  <span data-ttu-id="9647b-118">Windows デベロッパー センターで構成する統計は、になっている場合は、タイトルのゲーム ハブに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9647b-118">The Stats you configure on Windows Dev Center will appear in your title's GameHub as pictured:</span></span>

<span data-ttu-id="9647b-119">以下の画像で黄色では、*機能の統計*が強調表示されます。</span><span class="sxs-lookup"><span data-stu-id="9647b-119">The *Feature Stats* are highlighted in yellow in the image below.</span></span>
![正式なクラブ ページ ソーシャル ランキング](../images/omega/gamehub_featuredstats.png)


<span data-ttu-id="9647b-121">Xbox One では、ユーザーは関連する情報、駆動型のコミュニティ コンテンツ、および開発者の投稿をすばやく検索がホーム画面に直接暗証番号 (pin) のゲームにできます。</span><span class="sxs-lookup"><span data-stu-id="9647b-121">On Xbox One, users are able to pin games directly to their Home screen to quickly find relevant information, community driven content, and developer posts.</span></span> <span data-ttu-id="9647b-122">統計を構成することがあります、ピン留めされたホーム コンテンツの一部としても表示されます。</span><span class="sxs-lookup"><span data-stu-id="9647b-122">The stats you configure may also appear as a part of pinned Home content.</span></span> <span data-ttu-id="9647b-123">統計を再生、方法、ランキングを促すこと、若干より高いランク フレンドと共に、プレイヤーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9647b-123">Stats will show the player along with a slightly higher ranked friend, encouraging them to play their way up the leaderboard.</span></span> <span data-ttu-id="9647b-124">ピン留めされたコンテンツのランキングが次の図で強調表示されます。</span><span class="sxs-lookup"><span data-stu-id="9647b-124">Leaderboards in pinned content would appear as highlighted in the following image.</span></span>

![Halo 5 つのピン留めされたランキング](../images/stats/Halo_5_Pinned_Leaderboard.png)

<span data-ttu-id="9647b-126">注目の統計は、ゲームの進行中も、タイトルをプレイしている他のフレンドと構成済みの統計に基づく比較します。</span><span class="sxs-lookup"><span data-stu-id="9647b-126">Featured Stats compare in game progress based on configured statistics with other friends who also play the title.</span></span> <span data-ttu-id="9647b-127">これにより、フレンドのハイ スコアの競合が発生または単に共有エクスペリエンスを結合するとき、タイトルのプレイ時間をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9647b-127">This encourages more play time for your title when friends compete for high scores or simply bond over a shared experience.</span></span> <span data-ttu-id="9647b-128">注目の統計のランキングは、月次請求のランキングの月の最初の日にリセットされます。</span><span class="sxs-lookup"><span data-stu-id="9647b-128">Featured Stat leaderboards are monthly leaderboards which are reset on the first day of the month.</span></span>

<span data-ttu-id="9647b-129">開発者は、制限すると、自分のタイトルの注目の統計を 20 個を超えることはありませんが、開発者はタイトル内での注目の統計を含めるための要件はありません。</span><span class="sxs-lookup"><span data-stu-id="9647b-129">Developers are limited to having no more than 20 featured stats for their title, but there is no requirement for developers to include Featured Stats in their title.</span></span>

## <a name="further-reading"></a><span data-ttu-id="9647b-130">参考資料</span><span class="sxs-lookup"><span data-stu-id="9647b-130">Further Reading</span></span>
<span data-ttu-id="9647b-131">学習する[統計](player-stats-updating.md)2017 の更新の統計値を更新する方法を学習する[構成注目の統計とランキング 2017年](../configure-xbl/dev-center/featured-stats-and-leaderboards.md)で統計を構成するには</span><span class="sxs-lookup"><span data-stu-id="9647b-131">Learn to configure stats with [Configuring Featured Stats and Leaderboards 2017](../configure-xbl/dev-center/featured-stats-and-leaderboards.md) Learn how to update stat values with [Updating Stats 2017](player-stats-updating.md)</span></span>