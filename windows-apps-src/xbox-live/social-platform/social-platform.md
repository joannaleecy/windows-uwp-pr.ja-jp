---
title: Xbox Live ソーシャル プラットフォーム - ゲームおよびゲーマー向け
author: aablackm
description: Xbox Live ソーシャル プラットフォーム サービスについて説明するリンクを示します。
ms.assetid: 27b85218-60f3-4eb0-9f7e-fe90e027db5c
ms.author: aablackm
ms.date: 09/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2bc8856d4ea03adc39edaa2066f0dd3224f293c1
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4312849"
---
# <a name="xbox-live-social-platform---for-games-and-gamers"></a><span data-ttu-id="203ff-104">Xbox Live ソーシャル プラットフォーム - ゲームおよびゲーマー向け</span><span class="sxs-lookup"><span data-stu-id="203ff-104">Xbox Live social platform - For games and gamers</span></span>

<span data-ttu-id="203ff-105">ゲーマーがタイトルを選んで熱心にプレイし続けるには、他のユーザーと一緒にプレイして競争することが重要です。</span><span class="sxs-lookup"><span data-stu-id="203ff-105">For gamers to adopt your title and stay engaged, it is crucial for them to play and compete with others.</span></span> <span data-ttu-id="203ff-106">Xbox Live には、5,000 万人を超えるアクティブなゲーマーを抱え、今なお増加し続けている優れたゲーム ソーシャル ネットワークがあります。</span><span class="sxs-lookup"><span data-stu-id="203ff-106">Xbox Live offers the best gaming social network with over 50 million active gamers and growing.</span></span> <span data-ttu-id="203ff-107">ゲーマーを集めて、これから作るゲームのような斬新で刺激的なゲームに注目してもらうための一連のツールを作成しました。</span><span class="sxs-lookup"><span data-stu-id="203ff-107">We have created a set of tools to bring gamers together and get their eyes on new and exciting games like the one you’re sure to create.</span></span> <span data-ttu-id="203ff-108">Xbox Live ソーシャル プラットフォームはタイトルに簡単に統合でき、シングル プレイヤーのカジュアル ゲーム、コンパニオン アプリ、大規模なマルチプレイヤー ゲームのどれを構築しているかにかかわらず、非常に高い投資効果が得られます。</span><span class="sxs-lookup"><span data-stu-id="203ff-108">Integrating the Xbox Live social platform in your title is easy and the return on investment is huge whether you are building a single player casual game, a companion app, or a massive multiplayer game.</span></span>

## <a name="concepts-in-this-article"></a><span data-ttu-id="203ff-109">この記事に含まれている概念</span><span class="sxs-lookup"><span data-stu-id="203ff-109">Concepts in this article</span></span>
- [<span data-ttu-id="203ff-110">プロフィール</span><span class="sxs-lookup"><span data-stu-id="203ff-110">Profile</span></span>](#profile)
- [<span data-ttu-id="203ff-111">ゲーマースコアと実績</span><span class="sxs-lookup"><span data-stu-id="203ff-111">Gamerscore and Achievements</span></span>](#gamerscore-and-achievements)
- [<span data-ttu-id="203ff-112">People システム - Xbox Live のソーシャル ネットワーク</span><span class="sxs-lookup"><span data-stu-id="203ff-112">The people system - Your Social Network On Xbox Live</span></span>](#the-people-system---your-social-network-on-xbox-live)
- [<span data-ttu-id="203ff-113">クラブ</span><span class="sxs-lookup"><span data-stu-id="203ff-113">Clubs</span></span>](#clubs)
- [<span data-ttu-id="203ff-114">クリップとスクリーンショット</span><span class="sxs-lookup"><span data-stu-id="203ff-114">Clips and screen shots</span></span>](#clips-and-screenshots)
- [<span data-ttu-id="203ff-115">アクティビティ フィード</span><span class="sxs-lookup"><span data-stu-id="203ff-115">The activity feed</span></span>](#the-activity-feed)
- [<span data-ttu-id="203ff-116">人気上昇中</span><span class="sxs-lookup"><span data-stu-id="203ff-116">Trending</span></span>](#trending)
- [<span data-ttu-id="203ff-117">リッチ プレゼンス</span><span class="sxs-lookup"><span data-stu-id="203ff-117">Rich Presence</span></span>](#rich-presence)
- [<span data-ttu-id="203ff-118">ゲーム ハブ</span><span class="sxs-lookup"><span data-stu-id="203ff-118">Game Hubs</span></span>](#game-hubs)
- [<span data-ttu-id="203ff-119">Xbox Live ソーシャル API の使用</span><span class="sxs-lookup"><span data-stu-id="203ff-119">Use the Xbox Live Social APIs</span></span>](#use-the-xbox-live-social-apis)

## <a name="bringing-gamers-together"></a><span data-ttu-id="203ff-120">ゲーマーを集める</span><span class="sxs-lookup"><span data-stu-id="203ff-120">Bringing gamers together</span></span>
<span data-ttu-id="203ff-121">Xbox Live は、ゲーマーのアクティブなコミュニティの構築を目指しています。</span><span class="sxs-lookup"><span data-stu-id="203ff-121">Xbox Live is committed to building an active community of gamers.</span></span> <span data-ttu-id="203ff-122">ゲーマーが経験を共有する他のゲーマーを見つけ、ゲームをソーシャル アクティビティとするのに役立つ一連のツールが用意されているのはそのためです。</span><span class="sxs-lookup"><span data-stu-id="203ff-122">That's why we provide a set of tools to help gamers find others to share experiences with and make gaming a social activity.</span></span> <span data-ttu-id="203ff-123">したがって、ゲームをプレイするときにフレンドをサポートできなくても共有することはできます。</span><span class="sxs-lookup"><span data-stu-id="203ff-123">So when they play your game they can't help but share it with their friends.</span></span> 

### <a name="profile"></a><span data-ttu-id="203ff-124">プロフィール</span><span class="sxs-lookup"><span data-stu-id="203ff-124">Profile</span></span>
<span data-ttu-id="203ff-125">Xbox Live でそれぞれのゲーマーにプロフィールがあります。</span><span class="sxs-lookup"><span data-stu-id="203ff-125">Each gamer on Xbox Live has a profile.</span></span> <span data-ttu-id="203ff-126">プロフィールには次の情報が記録されます。</span><span class="sxs-lookup"><span data-stu-id="203ff-126">The profile contains the following information:</span></span>

-   <span data-ttu-id="203ff-127">**ゲーマータグ**: ゲーマーの一意のニックネームです。</span><span class="sxs-lookup"><span data-stu-id="203ff-127">**Gamertag**: The unique nickname of the gamer.</span></span> <span data-ttu-id="203ff-128">Xbox Live 上のすべてのユーザーにゲーマータグがあります。</span><span class="sxs-lookup"><span data-stu-id="203ff-128">Every user on Xbox Live has a gamertag.</span></span>

-   <span data-ttu-id="203ff-129">**氏名**: ゲーマーの名、姓です。</span><span class="sxs-lookup"><span data-stu-id="203ff-129">**Real Name**: The first and last name of the gamer.</span></span> <span data-ttu-id="203ff-130">ユーザーがプライバシー設定を通じてリアルタイムを共有しない場合、これは空です。</span><span class="sxs-lookup"><span data-stu-id="203ff-130">This is empty if the user doesn’t want to share their real name via their privacy settings.</span></span>

-   <span data-ttu-id="203ff-131">**ゲーマーアイコン**: ゲーマーが自分を表すものとして選択した画像またはアイコンです。</span><span class="sxs-lookup"><span data-stu-id="203ff-131">**Gamerpic**: The picture or icon that the gamer has chosen to represent them.</span></span>

-   <span data-ttu-id="203ff-132">**プレゼンス**: ゲーマーの現在の状態です (オンライン、オフライン、ゲームのプレイ中など)。</span><span class="sxs-lookup"><span data-stu-id="203ff-132">**Presence**: The current state of the gamer (online, offline, playing a game, etc.)</span></span>

-   <span data-ttu-id="203ff-133">**ゲーマースコア**: ユーザーがプレイしてきたすべての Xbox Live ゲーム間で積み上げてきた実績スコアを総合して 1 つの値にしたものです。</span><span class="sxs-lookup"><span data-stu-id="203ff-133">**Gamerscore**: The single value that represents the total achievement score the user has accumulated across all of the Xbox Live games they have played.</span></span>

### <a name="gamerscore-and-achievements"></a><span data-ttu-id="203ff-134">ゲーマースコアと実績</span><span class="sxs-lookup"><span data-stu-id="203ff-134">Gamerscore and Achievements</span></span>
<span data-ttu-id="203ff-135">ゲームでの[実績](../achievements-2017/achievements.md)をロック解除した後に各ゲーマーが、ゲーマースコアを獲得できます。</span><span class="sxs-lookup"><span data-stu-id="203ff-135">Each gamer can earn Gamerscore by unlocking [achievements](../achievements-2017/achievements.md) in your game.</span></span>
<span data-ttu-id="203ff-136">実績はとても人気のある機能で、これを利用するとゲーマーが自分の力を自慢したり、ゲームプレイの目標を広げることができるため、ゲーマーをタイトルに引き付け続けることができます。</span><span class="sxs-lookup"><span data-stu-id="203ff-136">Achievements is a very popular feature that keeps your gamers engaged with your title by letting them both boast of their prowess and extend gameplay goals.</span></span> <span data-ttu-id="203ff-137">プレイヤーは、実績をプロフィールのフレンドと比較することができます。</span><span class="sxs-lookup"><span data-stu-id="203ff-137">Players can compare their Achievements with their friends in their profile.</span></span>

> [!NOTE]
> <span data-ttu-id="203ff-138">ゲーマースコアと実績は、Xbox Live クリエーターズ プログラムで作成されたゲームには使用できません。</span><span class="sxs-lookup"><span data-stu-id="203ff-138">Gamerscore and Achievements are not available to games created under the Xbox Live Creators Program.</span></span>

### <a name="the-people-system---your-social-network-on-xbox-live"></a><span data-ttu-id="203ff-139">People システム - Xbox Live のソーシャル ネットワーク</span><span class="sxs-lookup"><span data-stu-id="203ff-139">The people system - Your social network on Xbox Live</span></span>
<span data-ttu-id="203ff-140">各 Xbox Live メンバーは、ユーザーの個人的な フレンド リストを維持できます。このリストには、実際の友人、Xbox Live で知り合った他のゲーム、有名ゲーマーや Major Nelson などの VIP を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="203ff-140">Each Xbox Live member can maintain a personal friends list of people which could contain real world friends, gamers met on Xbox Live, and well known gamers and VIPs such as Major Nelson.</span></span> 

<span data-ttu-id="203ff-141">ユーザーの関係は、一方向の "*フォロワー*" 関係です。つまり、フォローするだけでフレンド リストに追加できます。</span><span class="sxs-lookup"><span data-stu-id="203ff-141">The relationships between people are one way *follower* relationships, which means you can add someone to your friends list just by following them.</span></span> <span data-ttu-id="203ff-142">これは、フォローしようとしている人がシステムでフレンドとなる前に関係を確認する必要がある他のシステムとは対照的です。</span><span class="sxs-lookup"><span data-stu-id="203ff-142">This is in contrast to other systems where the person you are trying to follow has to confirm the relationship before you can become friends in the system.</span></span> <span data-ttu-id="203ff-143">フレンド リストにはフレンドを最大 1000 人追加でき、フォロワーに制限はありません。</span><span class="sxs-lookup"><span data-stu-id="203ff-143">You can add up to 1000 friends in your friends list and have unlimited followers:</span></span>

-   <span data-ttu-id="203ff-144">*フレンド*は、フォローすることで自分のフレンド リストに追加した人物です。</span><span class="sxs-lookup"><span data-stu-id="203ff-144">A *friend* is a person you have added to your friends list by following them.</span></span>

-   <span data-ttu-id="203ff-145">*フォロワー*は、フォローすることで自分をフレンド リストに追加した人物です。</span><span class="sxs-lookup"><span data-stu-id="203ff-145">A *follower* is someone who has added you to their friends list by following you.</span></span>

<span data-ttu-id="203ff-146">フレンド リストでお気に入りのゲーマーを見つけやすくするため、各ゲーマーは最大 100 人のフレンドをお気に入りとしてマークできます。</span><span class="sxs-lookup"><span data-stu-id="203ff-146">To make it easy to find their favorite gamers in their friends list, each gamer can mark up to 100 friends as a favorite.</span></span>

<span data-ttu-id="203ff-147">ゲーマーがゲームをプレイしているとき、Xbox Live ソーシャル グラフには、そのゲームをプレイしたことのあるゲーマーのフレンドのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="203ff-147">When a gamer plays your game, the Xbox Live social graph will show only the gamer’s friends who have also played your game.</span></span>

[<span data-ttu-id="203ff-148">People システムの詳細</span><span class="sxs-lookup"><span data-stu-id="203ff-148">Learn more about the people system</span></span>](people-system/xbox-live-people-system.md) 

### <a name="clubs"></a><span data-ttu-id="203ff-149">クラブ</span><span class="sxs-lookup"><span data-stu-id="203ff-149">Clubs</span></span>
<span data-ttu-id="203ff-150">ゲーマーは、共通の興味に基づいて任意の規模のソーシャル グループを作成できます。</span><span class="sxs-lookup"><span data-stu-id="203ff-150">Gamers can build social groups of any size based on shared interests.</span></span> <span data-ttu-id="203ff-151">これらのグループは、クラブと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="203ff-151">These groups are called Clubs.</span></span>
<span data-ttu-id="203ff-152">クラブの範囲は、フレンズの小規模なグループから、交流して一緒にプレイするのが好きな何十万人ものゲームからなる大規模なコミュニティまでさまざまです。</span><span class="sxs-lookup"><span data-stu-id="203ff-152">Clubs range from a small group of friends to a large community of hundreds of thousands of gamers who love to socialize and play together.</span></span>
<span data-ttu-id="203ff-153">クラブは、特定のゲームだけでなく、広範な興味のカテゴリもカバーできます。</span><span class="sxs-lookup"><span data-stu-id="203ff-153">Clubs may also cover broad categories of interest and not just your game in particular.</span></span> <span data-ttu-id="203ff-154">著名なクラブには以下のものがあります。</span><span class="sxs-lookup"><span data-stu-id="203ff-154">Some notable club names include:</span></span>

- <span data-ttu-id="203ff-155">Awesome Screenshot Club</span><span class="sxs-lookup"><span data-stu-id="203ff-155">Awesome Screenshot Club</span></span>
- <span data-ttu-id="203ff-156">Vintage Retro Games</span><span class="sxs-lookup"><span data-stu-id="203ff-156">Vintage Retro Games</span></span>
- <span data-ttu-id="203ff-157">Memes Are Everything</span><span class="sxs-lookup"><span data-stu-id="203ff-157">Memes Are Everything</span></span>
- <span data-ttu-id="203ff-158">Club UFC</span><span class="sxs-lookup"><span data-stu-id="203ff-158">Club UFC</span></span>

<span data-ttu-id="203ff-159">これは、Xbox Live のゲーマーが作った数多くのクラブの一部にすぎません。</span><span class="sxs-lookup"><span data-stu-id="203ff-159">That's just a few of the multitude of Clubs Xbox Live gamers have created.</span></span>

<span data-ttu-id="203ff-160">クラブでは、ゲームのファンがゲームのクリップとスクリーンショットを他の人と共有したり、互いに質問したり、一緒にチャットしたり、"グループを検索" (LFG) を通じてゲームをプレイする他のプレイヤーを探したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="203ff-160">In a club, fans of your game may share clips and screenshots of your game with others, ask each other questions, chat together, and find other players to play your game via Looking For Group (LFG).</span></span> <span data-ttu-id="203ff-161">ゲーマーがクラブに参加すると、エンゲージメントが 40% 拡大し、フレンドも増えます。</span><span class="sxs-lookup"><span data-stu-id="203ff-161">Gamers who join Clubs increase their engagement by 40% and make more friends.</span></span>

> [!NOTE]
> <span data-ttu-id="203ff-162">クラブの管理は、プレイヤーに任されています。必然的にファンベース内に現れることになり、開発者側で作業やインプットは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="203ff-162">Clubs are exclusively managed by the players and will naturally appear within your fanbase, requiring no work or input on the developers part.</span></span> <span data-ttu-id="203ff-163">しかし、もちろんクリエイターが発言してもかまいません。</span><span class="sxs-lookup"><span data-stu-id="203ff-163">But, a word from the > creator couldn't hurt.</span></span> 

## <a name="getting-eyes-on-games"></a><span data-ttu-id="203ff-164">ゲームに注目を集める</span><span class="sxs-lookup"><span data-stu-id="203ff-164">Getting eyes on games</span></span>
<span data-ttu-id="203ff-165">Xbox ソーシャル システムの重要な部分は、アクティビティの共有です。</span><span class="sxs-lookup"><span data-stu-id="203ff-165">An important part of the Xbox social system is activity sharing.</span></span> <span data-ttu-id="203ff-166">これにより、これまでのアクティビティを Xbox Live のフレンドすべてに知らせることができ、ゲームに参加する各プレイヤーへの露出が大きくなるという特別な利点もゲームにもたらされます。</span><span class="sxs-lookup"><span data-stu-id="203ff-166">This lets all your friends on Xbox Live know what you've been up to, with the special added benefit of giving your game more exposure for every player getting in the game.</span></span> <span data-ttu-id="203ff-167">次の機能は、Xbox ユーザーがゲームを発見し、新しいファンとなった後もゲームをプレイし続けてもらうために用意されています。</span><span class="sxs-lookup"><span data-stu-id="203ff-167">The following features are meant to help Xbox users discover your game and keep them engaged after they’ve become yet another loyal fan.</span></span> <span data-ttu-id="203ff-168">さらにすばらしいことに、ゲームをプレイするたびに新しいフレンドを連れてきてゲームに加わってもらう効果があります。</span><span class="sxs-lookup"><span data-stu-id="203ff-168">Even better than that, every time they play your game they’ll be enticing all their friends to join your legion.</span></span> 

### <a name="clips-and-screenshots"></a><span data-ttu-id="203ff-169">クリップとスクリーンショット</span><span class="sxs-lookup"><span data-stu-id="203ff-169">Clips and screenshots</span></span>
<span data-ttu-id="203ff-170">ゲーマーがゲーム コンテンツを共有する最も簡単な方法はクリップとスクリーンショットです。</span><span class="sxs-lookup"><span data-stu-id="203ff-170">The easiest way for gamers to share your games content is through clips and screenshots.</span></span> <span data-ttu-id="203ff-171">プレイヤーは、ゲームプレイのビデオとスクリーンショットを録画または撮影し、Xbox Live のフレンドと共有できます。</span><span class="sxs-lookup"><span data-stu-id="203ff-171">Players will be able to record gameplay videos and screenshots to share with their friends on Xbox Live.</span></span> <span data-ttu-id="203ff-172">そのようなすばらしい瞬間は、プレイヤーのアクティビティ フィードで自動的に再生されます。</span><span class="sxs-lookup"><span data-stu-id="203ff-172">These moments of glory will automatically be showcased in the player's activity feed.</span></span>

### <a name="the-activity-feed"></a><span data-ttu-id="203ff-173">アクティビティ フィード</span><span class="sxs-lookup"><span data-stu-id="203ff-173">The activity feed</span></span>
<span data-ttu-id="203ff-174">ゲーマーがタイトルをプレイすると、その実績がロック解除され、クリップ、スクリーンショット、その他のアクティビティが他のフレンドと共有されるアクティビティ フィードの一部となるため、ゲームについて知りたいことを確認できるようになります。</span><span class="sxs-lookup"><span data-stu-id="203ff-174">When gamers play your title, their Achievement unlocks, clips, screenshots and other activities will become a part of an activity feed that is shared with their friends so they can all see the wonders your game has to offer.</span></span>

### <a name="trending"></a><span data-ttu-id="203ff-175">人気上昇中</span><span class="sxs-lookup"><span data-stu-id="203ff-175">Trending</span></span>
<span data-ttu-id="203ff-176">Xbox Live で発行された最も人気のあるコンテンツは、Xbox Live のトレンド セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="203ff-176">The most popular content published across Xbox Live is visible in the Trending section of Xbox Live.</span></span> <span data-ttu-id="203ff-177">ゲーマーが興味深い質問をゲーム ハブに投稿したり、ゲームのすばらしいクリップを共有したりした場合、コンテンツが Xbox Live でトレンドとなることを期待できます。</span><span class="sxs-lookup"><span data-stu-id="203ff-177">If a gamer posts an interesting question on your Game Hub or shares a great clip of your game, you can expect your content to trend on Xbox Live.</span></span> <span data-ttu-id="203ff-178">これはタイトルの認知度を高めるための別の優れた方法です。</span><span class="sxs-lookup"><span data-stu-id="203ff-178">This is another great way to raise awareness for your title.</span></span>

### <a name="rich-presence"></a><span data-ttu-id="203ff-179">リッチ プレゼンス</span><span class="sxs-lookup"><span data-stu-id="203ff-179">Rich Presence</span></span>
<span data-ttu-id="203ff-180">プレゼンス (プレイヤーのオンライン ステータス) は、プレイヤーがオンラインかどうかを確認するためだけのものではありません。</span><span class="sxs-lookup"><span data-stu-id="203ff-180">Presence, the online status of the player, isn't just for checking whether the player is online or not.</span></span> <span data-ttu-id="203ff-181">プレイヤーが現在使っているアプリやゲームもわかります。</span><span class="sxs-lookup"><span data-stu-id="203ff-181">It also shows what app or game the player is currently engaged with.</span></span> <span data-ttu-id="203ff-182">さらに、リッチ プレゼンス文字列では、プレイヤーがゲーム内でしていること、メニューを見ているかどうか、ゲームを待機しているかどうか、プレイの途中かどうかを宣伝することができます。</span><span class="sxs-lookup"><span data-stu-id="203ff-182">Furthermore,  Rich Presence strings allow you to advertise what someone is doing within your game, whether they are puttering around the menus, queuing up for a game, or right in the middle of play.</span></span> 

[<span data-ttu-id="203ff-183">リッチ プレゼンスの詳細</span><span class="sxs-lookup"><span data-stu-id="203ff-183">Learn more about Rich Presence</span></span>](rich-presence-strings/rich-presence-strings-overview.md)

> [!NOTE]
> <span data-ttu-id="203ff-184">リッチ プレゼンスは、Xbox Live クリエーターズ プログラムで作成されたゲームには使用できません。</span><span class="sxs-lookup"><span data-stu-id="203ff-184">Rich Presence is not available for games created under the Xbox Live Creators Program.</span></span>

### <a name="game-hubs"></a><span data-ttu-id="203ff-185">ゲーム ハブ</span><span class="sxs-lookup"><span data-stu-id="203ff-185">Game Hubs</span></span>
<span data-ttu-id="203ff-186">Xbox Live との統合によって、ゲームは、ゲーム ハブと呼ばれるハブ ページを自動的に持つことになります。</span><span class="sxs-lookup"><span data-stu-id="203ff-186">By integrating with Xbox Live, your game automatically gets a hub page known as the Game Hub.</span></span> <span data-ttu-id="203ff-187">ゲーム ハブは、Xbox Live にあるゲームの公式な目的地であり、プレイヤーはゲームに関連するアクティビティ、実績、グループ、クラブ、トーナメントなどを参照することができます。</span><span class="sxs-lookup"><span data-stu-id="203ff-187">Game Hub is the official destination for your game on Xbox Live, and lets players find game-related activity, Achievements, groups, Clubs, tournaments, and more.</span></span>

<span data-ttu-id="203ff-188">必要に応じて、アクティビティ フィードを通じてユーザーと対話するゲーム ハブのコミュニティ マネージャーをセットアップすることができます。</span><span class="sxs-lookup"><span data-stu-id="203ff-188">You can optionally setup a community manager for your Game Hub to interact with your users via the activity feed.</span></span> <span data-ttu-id="203ff-189">ゲームをプレイするゲーマーは全員ゲーム ハブ アクティビティ フィードに自動的にサブスクライブされるため、ゲーマーにリーチする強力な手段となります。</span><span class="sxs-lookup"><span data-stu-id="203ff-189">Any gamer who plays your game is automatically subscribed to your Game Hub activity feed, giving you a powerful mechanism to reach gamers.</span></span> <span data-ttu-id="203ff-190">ゲーム ハブ アクティビティ フィードの投稿は、人気のある外部のソーシャル メディア プラットフォームにおける同様の投稿よりエンゲージメントが平均で 10 倍高くなります。</span><span class="sxs-lookup"><span data-stu-id="203ff-190">On average, a post on the Game Hub activity feed will get 10x more engagement than a similar post on an external popular social media platform.</span></span>

##  <a name="use-the-xbox-live-social-apis"></a><span data-ttu-id="203ff-191">Xbox Live ソーシャル API の使用</span><span class="sxs-lookup"><span data-stu-id="203ff-191">Use the Xbox Live Social APIs</span></span>
<span data-ttu-id="203ff-192">Xbox Live ソーシャル API を通じてゲーマーやそのフレンドをタイトルに引き付け続けるには、`SocialManager` クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="203ff-192">In order to keep gamers, and their friends engaged with your title through the Xbox Live Social APIs you will use the `SocialManager` class.</span></span>  <span data-ttu-id="203ff-193">使い方については、「[Social Manager の概要](intro-to-social-manager.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ff-193">Start learning how to use it in [Introduction to Social Manager](intro-to-social-manager.md)</span></span>