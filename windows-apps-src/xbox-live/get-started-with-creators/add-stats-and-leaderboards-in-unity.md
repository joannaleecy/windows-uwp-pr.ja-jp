---
title: "Unity プロジェクトにプレイヤーの統計とランキングを追加する"
author: KevinAsgari
description: "Xbox Live Unity プラグインを使用してプレイヤーの統計とランキングを Unity プロジェクトに追加する方法について説明します。"
ms.assetid: 756b3c31-a459-4ad2-97af-119adcd522b5
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, クリエーター"
ms.openlocfilehash: f27b909f3176e1e896dde39b117bb49e8ecf6fdc
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="add-player-stats-and-leaderboards-to-your-unity-project"></a><span data-ttu-id="6351d-104">Unity プロジェクトにプレイヤーの統計とランキングを追加する</span><span class="sxs-lookup"><span data-stu-id="6351d-104">Add player stats and leaderboards to your Unity project</span></span>

> <span data-ttu-id="6351d-105">**注:** 現在、実績とマルチプレイヤーがサポートされていないため、Xbox Live Unity プラグインは [Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。</span><span class="sxs-lookup"><span data-stu-id="6351d-105">**Note:** The Xbox Live Unity plugin is only recommended for [Xbox Live Creators Program](../developer-program-overview.md) members, since currently there is no support for achievements or multiplayer.</span></span>

<span data-ttu-id="6351d-106">[Xbox Live サインイン](sign-in-to-xbox-live-in-unity.md)を Unity プロジェクトに追加したら、次の手順として、プレイヤーの統計とその統計に基づくランキングを追加します。</span><span class="sxs-lookup"><span data-stu-id="6351d-106">Once you have added [Xbox Live sign in](sign-in-to-xbox-live-in-unity.md) to your Unity project, the next step is to add player stats and leaderboards based on those player stats.</span></span>

<span data-ttu-id="6351d-107">Xbox Live Unity プラグインを使用すると、プレイヤーの統計とランキングを Unity プロジェクトに簡単に追加できます。</span><span class="sxs-lookup"><span data-stu-id="6351d-107">With the Xbox Live Unity plugin, you can easily add player stats and leaderboards in your Unity project.</span></span> <span data-ttu-id="6351d-108">サインイン手順と同様、付属のプレハブを使用したり、付属のスクリプトを独自のカスタム オブジェクトにアタッチしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="6351d-108">Similar to the sign in steps, you can use the included prefabs, or you can attach the included scripts to your own custom objects.</span></span>

> <span data-ttu-id="6351d-109">**注:** このトピックでは、Xbox Live プラグインが Unity プロジェクトで既にセットアップされていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="6351d-109">**Note:** This topic assumes that you have already set up the Xbox Live plugin in your Unity project.</span></span> <span data-ttu-id="6351d-110">その方法について詳しくは、「[Unity で Xbox Live を構成する](configure-xbox-live-in-unity.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6351d-110">For information about how to do that, see [Configure Xbox Live in Unity](configure-xbox-live-in-unity.md).</span></span>

## <a name="player-stats"></a><span data-ttu-id="6351d-111">プレイヤーの統計</span><span class="sxs-lookup"><span data-stu-id="6351d-111">Player stats</span></span>

<span data-ttu-id="6351d-112">プレイヤーの統計とは、プレイヤーに関して追跡される統計情報であり、プレイヤーの関心を引くために使用されます。</span><span class="sxs-lookup"><span data-stu-id="6351d-112">A player stat is any interesting statistic that you want to track for your players.</span></span> <span data-ttu-id="6351d-113">Xbox Live で追跡する統計は、プレイヤーに関連する統計であることが必要です。またこの統計は、所定の方法で表示されます。</span><span class="sxs-lookup"><span data-stu-id="6351d-113">The stats that you track with Xbox Live should be stats that are relevant to the player, and are displayed in some manner.</span></span> <span data-ttu-id="6351d-114">こうしたプレイヤーの統計は、一般的にランキングの作成に使用されます。プレイヤーはこのランキングを確認することで、ゲームをプレイしたときのランクが他のプレイヤーと比べてどの順位にあるかを判断することができます。</span><span class="sxs-lookup"><span data-stu-id="6351d-114">These player stats are most commonly used to build leaderboards, which players can view to determine how their performance ranks against other players.</span></span> <span data-ttu-id="6351d-115">プレイヤーの統計には「注目のプレイヤーの統計」とマークされるものがあります。このようにマークされたプレイヤーの統計は、ゲームのゲーム ハブに表示されます。</span><span class="sxs-lookup"><span data-stu-id="6351d-115">Some player stats can be marked as "featured player stats", which means that the player stat will be displayed in the GameHub page for the game.</span></span>

<span data-ttu-id="6351d-116">個々の統計は複雑なオブジェクトにせずに、単一の値を表すようなオブジェクトにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6351d-116">Individual stats cannot be complex objects, but must represent a single value.</span></span> <span data-ttu-id="6351d-117">Xbox Live Unity プラグインには、整数型、倍精度浮動小数点数型、および文字列型の各統計に対応したプレハブが用意されています。</span><span class="sxs-lookup"><span data-stu-id="6351d-117">The Xbox Live Unity plugin contains prefabs for integer, double, and string stats.</span></span> <span data-ttu-id="6351d-118">また、他のデータ型に拡張可能な基本統計オブジェクト用のスクリプトも用意されています。</span><span class="sxs-lookup"><span data-stu-id="6351d-118">In addition, a script is provided for a base stat object that can be extended to other data types.</span></span>

<span data-ttu-id="6351d-119">プレイヤーの統計について詳しくは、「[プレイヤーの統計](../leaderboards-and-stats-2017/player-stats.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6351d-119">For more information about player stats, see [Player stats](../leaderboards-and-stats-2017/player-stats.md).</span></span>

> <span data-ttu-id="6351d-120">**注:** Xbox Live サービスでプレイヤーの統計やランキングを使用する場合、データにアクセスするためには、ユーザーが正常にサインインしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6351d-120">**Note:** In order to use player stats or leaderboards with the Xbox Live service, you must have a successfully signed in user before you can access any data.</span></span>

## <a name="using-the-player-stat-prefabs"></a><span data-ttu-id="6351d-121">プレイヤーの統計プレハブを使用する</span><span class="sxs-lookup"><span data-stu-id="6351d-121">Using the player stat prefabs</span></span>

<span data-ttu-id="6351d-122">Xbox Live Unity プラグインには、プレイヤーの統計に関連して使用できるプレハブがいくつか用意されています。</span><span class="sxs-lookup"><span data-stu-id="6351d-122">There are several prefabs provided in the Xbox Live Unity plugin that you can use relating to player stats:</span></span>

* <span data-ttu-id="6351d-123">IntegerStat - ラウンドでの撃墜の合計数など、整数値として表すことができる統計です。</span><span class="sxs-lookup"><span data-stu-id="6351d-123">IntegerStat - A stat that can be expressed as an integer value, such as total number of kills in a round.</span></span>
* <span data-ttu-id="6351d-124">DoubleStat - 撃墜/死亡の割合など、浮動小数点値として表すことができる統計です。</span><span class="sxs-lookup"><span data-stu-id="6351d-124">DoubleStat - A stat that can be expressed as a floating point value, such as a kill/death ratio.</span></span>
* <span data-ttu-id="6351d-125">StringStat - "ゴールド"、"シルバー"、"ブロンズ" といったラウンドで付与されるランクなど、文字列値 (通常は列挙型) として表すことができる統計です。</span><span class="sxs-lookup"><span data-stu-id="6351d-125">StringStat - A stat that can be expressed as a string value, typically an enumeration, such as a rank awarded for a round, such as "Gold", "Silver", or "Bronze".</span></span>
* <span data-ttu-id="6351d-126">StatPanel - 現在の統計の値を表示する際に使用できるサンプル UI です。</span><span class="sxs-lookup"><span data-stu-id="6351d-126">StatPanel - Sample UI that you can use to display the current value of a stat.</span></span>

<span data-ttu-id="6351d-127">プレイヤーの統計を追加するには、統計のデータ型に一致するプレハブをシーンにドラッグするだけです。</span><span class="sxs-lookup"><span data-stu-id="6351d-127">To add a player stat, simply drag the prefab that matches the data type of the stat onto the scene.</span></span> <span data-ttu-id="6351d-128">統計の Unity インスペクターでは、3 つの値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="6351d-128">In the Unity inspector for the stat, you can specify three values:</span></span>

* <span data-ttu-id="6351d-129">統計の名前。</span><span class="sxs-lookup"><span data-stu-id="6351d-129">The name of the stat.</span></span>
* <span data-ttu-id="6351d-130">統計の表示名 (この名前は StatPanel プレハブ UI に表示されます)。</span><span class="sxs-lookup"><span data-stu-id="6351d-130">The display name of the stat (this name is displayed in the StatPanel prefab UI).</span></span>
* <span data-ttu-id="6351d-131">シーンが開始したときの統計の初期値。</span><span class="sxs-lookup"><span data-stu-id="6351d-131">The initial value of the stat when the scene starts.</span></span>

<span data-ttu-id="6351d-132">**StatPanel** プレハブを使用すると、統計の値を表示できます。</span><span class="sxs-lookup"><span data-stu-id="6351d-132">You can use the **StatPanel** prefab to display the value of a stat.</span></span> <span data-ttu-id="6351d-133">**StatPanel** プレハブをシーンにドラッグしてから、**StatPanel** オブジェクトの Unity インスペクターを使用することで、表示する統計を指定します。</span><span class="sxs-lookup"><span data-stu-id="6351d-133">Simply drag a **StatPanel** prefab onto the scene, and specify which stat to display by using the Unity inspector for the **StatPanel** object.</span></span>

### <a name="manipulating-the-player-stat-values"></a><span data-ttu-id="6351d-134">プレイヤーの統計値を操作する</span><span class="sxs-lookup"><span data-stu-id="6351d-134">Manipulating the player stat values</span></span>

<span data-ttu-id="6351d-135">プレイヤーの統計オブジェクトには、統計の値を調整するために呼び出すことができる多くの関数があります。</span><span class="sxs-lookup"><span data-stu-id="6351d-135">The player stat objects have a number of functions that you can call to adjust the value of the stat.</span></span> <span data-ttu-id="6351d-136">これらの関数は、他のルーチンから呼び出したり、UI 要素にバインドしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="6351d-136">These functions can be called from other routines, or bound to UI elements.</span></span> <span data-ttu-id="6351d-137">**DoubleStat**、**IntegerStat**、**StringStat** の各スクリプトを調べると、統計の値を変更する関数の例を確認できます。</span><span class="sxs-lookup"><span data-stu-id="6351d-137">You can look at the **DoubleStat**, **IntegerStat**, and **StringStat** scripts to see examples of functions to change the value of the stat.</span></span> <span data-ttu-id="6351d-138">スクリプトを変更したり、新しいスクリプトを作成したりして、より複雑な関数とロジックを使用して統計を表示できます。</span><span class="sxs-lookup"><span data-stu-id="6351d-138">You can modify or create new scripts to represents stats with more complex functions and logic.</span></span> <span data-ttu-id="6351d-139">新しい統計クラスは、**StatBase** スクリプトで定義された**StatBase** クラスを拡張します。</span><span class="sxs-lookup"><span data-stu-id="6351d-139">New stat classes should extend the **StatBase** class, defined in the **StatBase** script.</span></span>

<span data-ttu-id="6351d-140">たとえば、簡単なテストとして、UI ボタンをシーンに追加します。次に、Unity インスペクターにあるボタンの **OnClick** メソッドで **IntegerStat** オブジェクトを追加し、**Increment()** 関数を呼び出して、ボタンをクリックするたびに統計の値が大きくなるようにします。</span><span class="sxs-lookup"><span data-stu-id="6351d-140">For example, as a simple test, you can add a UI button to your scene, and in the **OnClick** method of the button, in the Unity inspector, add an **IntegerStat** object, and call the **Increment()** function to increase the value of the stat by one every time you click the button.</span></span>

<span data-ttu-id="6351d-141">統計が **StatPanel** オブジェクトにもバインドされている場合、ボタンをクリックするたびに統計の値が更新されるのを確認できます。</span><span class="sxs-lookup"><span data-stu-id="6351d-141">If you have the stat also bound to a **StatPanel** object, you can see the stat value update every time you click the button.</span></span>

## <a name="leaderboards"></a><span data-ttu-id="6351d-142">ランキング</span><span class="sxs-lookup"><span data-stu-id="6351d-142">Leaderboards</span></span>

<span data-ttu-id="6351d-143">ランキングは、統計の "優れた" 値を獲得したプレイヤーを順番に並べた番号付きの一覧です。</span><span class="sxs-lookup"><span data-stu-id="6351d-143">A leaderboard represents an ordered, numbered list of the players who have achieved the "best" value of a stat.</span></span> <span data-ttu-id="6351d-144">たとえば、ランキングにはレースのラップ タイムで最も速いタイムを獲得したプレイヤーが一覧表示されるため、プレイヤーは自分のベスト レース タイムと他のプレイヤーのベスト レース タイムを比較できます。</span><span class="sxs-lookup"><span data-stu-id="6351d-144">For example, a leaderboard might list the people who have achieved the fastest time on a race lap, so that players can compare their best race time against the best race times achieved by other players.</span></span>

<span data-ttu-id="6351d-145">ランキングは、ゲームによって Xbox Live サービスに送信されたプレイヤーの統計に基づいて作成されます。</span><span class="sxs-lookup"><span data-stu-id="6351d-145">Leaderboards are based off of player stats that are sent to the Xbox Live service by the game.</span></span> <span data-ttu-id="6351d-146">したがって、ランキング データは読み取り専用であり、直接変更できません。</span><span class="sxs-lookup"><span data-stu-id="6351d-146">Therefore, leaderboard data is read only, as you cannot modify them directly.</span></span>

<span data-ttu-id="6351d-147">Xbox Live Unity プラグインには、ランキングをゲームに実装する方法を理解する際に役立つサンプルのランキング プレハブが用意されています。</span><span class="sxs-lookup"><span data-stu-id="6351d-147">The Xbox Live Unity plugin provides a sample Leaderboard prefab that you can use to understand how to implement leaderboards in your game.</span></span>

<span data-ttu-id="6351d-148">ランキングについて詳しくは、「[ランキング](../leaderboards-and-stats-2017/leaderboards.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6351d-148">For more information about leaderboards, see [Leaderboards](../leaderboards-and-stats-2017/leaderboards.md).</span></span>

## <a name="using-the-leaderboard-prefabs"></a><span data-ttu-id="6351d-149">ランキング プレハブを使用する</span><span class="sxs-lookup"><span data-stu-id="6351d-149">Using the leaderboard prefabs</span></span>

<span data-ttu-id="6351d-150">Xbox Live Unity プラグインには、ランキング用の 2 つのプレハブが用意されています。</span><span class="sxs-lookup"><span data-stu-id="6351d-150">The Xbox Live Unity plugin contains two prefabs for leaderboards:</span></span>

* <span data-ttu-id="6351d-151">LeaderBoard - ランキングを表示するオブジェクトであり、ランキングの値を表示するためのシンプルな UI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6351d-151">LeaderBoard - an object that represents a leaderboard, and contains simple UI to display the values from the leaderboard.</span></span>
* <span data-ttu-id="6351d-152">LeaderboardEntry - ランキングの単一の行を表示するオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="6351d-152">LeaderboardEntry - an object that represents a single row of a leaderboard.</span></span>

<span data-ttu-id="6351d-153">**ランキング** プレハブはシーンにドラッグできます。</span><span class="sxs-lookup"><span data-stu-id="6351d-153">You can drag a **Leaderboard** prefab onto the scene.</span></span> <span data-ttu-id="6351d-154">Unity インスペクターでは、次の属性を設定できます。</span><span class="sxs-lookup"><span data-stu-id="6351d-154">In the Unity inspector, you can set the following attributes:</span></span>

* <span data-ttu-id="6351d-155">ランキング名 - サービス構成でグローバル ランキングを定義した場合、この名前は構成済みのランキングの名前と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6351d-155">Leaderboard Name - If you have defined a global leaderboard in your service configuration, this name should match the name of the configured leaderboard.</span></span> <span data-ttu-id="6351d-156">それ以外の場合、この名前はプレイヤーの統計の値に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6351d-156">Otherwise, this name should match the value of a player stat.</span></span>
* <span data-ttu-id="6351d-157">表示名 - プレハブの UI に表示される名前。</span><span class="sxs-lookup"><span data-stu-id="6351d-157">Display Name - the name displayed in the UI for the prefab</span></span>
* <span data-ttu-id="6351d-158">エントリ数 - 1 ページあたりに表示するデータの行数。</span><span class="sxs-lookup"><span data-stu-id="6351d-158">Entry Count - the number of rows of data to display per page.</span></span>

<span data-ttu-id="6351d-159">Unity エディターでは、インスペクターの設定に関係なく、常に同じモック データが**ランキング** プレハブに表示されます。</span><span class="sxs-lookup"><span data-stu-id="6351d-159">In the Unity editor, the **Leaderboard** prefab will always display the same mock data regardless of the inspector settings.</span></span> <span data-ttu-id="6351d-160">実際のデータ値を表示するには、プロジェクトをビルドして Visual Studio にエクスポートし、承認されたユーザーとしてログインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6351d-160">You must build and export your project to Visual Studio and sign in with an authorized user in order to see real data values.</span></span> <span data-ttu-id="6351d-161">詳しくは、「[Unity で Xbox Live を構成する](configure-xbox-live-in-unity.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6351d-161">For more information, see [Configure Xbox Live in Unity](configure-xbox-live-in-unity.md).</span></span>

## <a name="see-also"></a><span data-ttu-id="6351d-162">関連項目</span><span class="sxs-lookup"><span data-stu-id="6351d-162">See also</span></span>

* [<span data-ttu-id="6351d-163">Unity で Xbox Live にサインインする</span><span class="sxs-lookup"><span data-stu-id="6351d-163">Sign into Xbox Live in Unity</span></span>](sign-in-to-xbox-live-in-unity.md)
* [<span data-ttu-id="6351d-164">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="6351d-164">Configure Xbox Live in Unity</span></span>](configure-xbox-live-in-unity.md)
