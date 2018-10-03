---
title: デベロッパー センターでのリッチ プレゼンスの構成
author: aablackm
description: Windows デベロッパー センターでリッチ プレゼンス文字列を構成する方法について説明します。
ms.author: aablackm
ms.date: 02/27/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, リッチ プレゼンス文字列, Windows デベロッパー センター
ms.openlocfilehash: 125d14fe0bf261caf9177a8ef5fa4cdb72b7952b
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4262716"
---
# <a name="configure-rich-presence-on-windows-dev-center"></a><span data-ttu-id="0f581-104">Windows デベロッパー センターでのリッチ プレゼンスの構成</span><span class="sxs-lookup"><span data-stu-id="0f581-104">Configure Rich Presence on Windows Dev Center</span></span>

<span data-ttu-id="0f581-105">リッチ プレゼンス文字列には、ユーザーのゲーム内のアクティビティが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f581-105">Rich Presence strings display a user's in-game activity.</span></span> <span data-ttu-id="0f581-106">**[フレンドとクラブ]** リストにあるプレイヤーのゲーマータグの下に、Xbox Live ユーザー プロフィールと共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f581-106">They are displayed under a player's Gamertag in the **Friends & clubs** list as well as in their Xbox Live user profile.</span></span> <span data-ttu-id="0f581-107">構成済みのリッチ プレゼンス文字列が、プレイしているゲームの名前に付加されます。</span><span class="sxs-lookup"><span data-stu-id="0f581-107">Configured Rich Presence strings are appended to the name of the game being played.</span></span> <span data-ttu-id="0f581-108">BubblePop というゲームを作成し、リッチ プレゼンス文字列 "友だちと一緒にバブルをはじこう" を構成した場合、構成された文字列により状態 "BubblePop - 友だちと一緒にバブルをはじこう" が生成されます。</span><span class="sxs-lookup"><span data-stu-id="0f581-108">If you create a game called BubblePop and configure the Rich Presence string "Popping bubbles with friends", your configured string would produce "BubblePop - Popping bubbles with friends" as a status.</span></span> <span data-ttu-id="0f581-109">リッチ プレゼンス文字列が実際にどのように表示されるかを以下で確認できます。</span><span class="sxs-lookup"><span data-stu-id="0f581-109">Below you can see how a Rich Presence string will appear in context.</span></span>

<span data-ttu-id="0f581-110">次のスクリーンショットでは、Xbox Live ユーザー **Last Roar** と **Lucha Uno** が、リッチ プレゼンス文字列を使っているゲームをプレイしています。</span><span class="sxs-lookup"><span data-stu-id="0f581-110">In the following screenshot Xbox Live users **Last Roar** and **Lucha Uno** are playing games using Rich Presence strings.</span></span>

![フレンド リストの例](../../images/rich_presence/RichPresence_FriendsList_Screen.jpg)

<span data-ttu-id="0f581-112">次のスクリーンショットでは、**Lucha Uno** のリッチ プレゼンス文字列全体がプロフィールに表示されています。</span><span class="sxs-lookup"><span data-stu-id="0f581-112">In the following screenshot you can see **Lucha Uno's** full Rich Presence string in his profile.</span></span>

![プロフィールの例](../../images/rich_presence/RichPresence_Config_ProfileScreen.jpg)

> [!IMPORTANT]
> <span data-ttu-id="0f581-114">リッチ プレゼンス文字列は、Xbox Live クリエーターズ プログラムのタイトルには使用できないため、それらのタイトルには構成できません。</span><span class="sxs-lookup"><span data-stu-id="0f581-114">Rich Presence strings are not available to Xbox Live Creators Program titles and therefore are not configurable for those titles.</span></span> <span data-ttu-id="0f581-115">この記事の内容は、ID@Xbox と対象パートナーのタイトル向けです。</span><span class="sxs-lookup"><span data-stu-id="0f581-115">The content in this article is for ID@Xbox and Managed Partner titles.</span></span>

## <a name="requirements"></a><span data-ttu-id="0f581-116">要件</span><span class="sxs-lookup"><span data-stu-id="0f581-116">Requirements</span></span>

<span data-ttu-id="0f581-117">リッチ プレゼンス文字列を構成する前に、次の条件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f581-117">Before configuring Rich Presence strings you and your title must meet the following criteria:</span></span>

- <span data-ttu-id="0f581-118">Windows 開発アカウントを持っている。</span><span class="sxs-lookup"><span data-stu-id="0f581-118">You must have a Windows development account.</span></span>
- <span data-ttu-id="0f581-119">開発アカウントが ID@Xboxプログラムに登録されているか、対象パートナーの開発者アカウントとして登録されている。</span><span class="sxs-lookup"><span data-stu-id="0f581-119">Your development account must be registered in the ID@Xbox program or as a managed partner developer account.</span></span>
- <span data-ttu-id="0f581-120">タイトルがデベロッパー センターに登録されていて、Xbox Live が有効になっている。</span><span class="sxs-lookup"><span data-stu-id="0f581-120">Your title must be registered in Dev Center and be Xbox Live enabled.</span></span>

<span data-ttu-id="0f581-121">リッチ プレゼンス文字列を使う前に、デベロッパー センター ダッシュボードで構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f581-121">Before you can use Rich Presence strings you must configure them on your Dev Center dashboard.</span></span>

## <a name="rich-presence-configuration-page"></a><span data-ttu-id="0f581-122">リッチ プレゼンスの構成ページ</span><span class="sxs-lookup"><span data-stu-id="0f581-122">Rich Presence Configuration Page</span></span>

<span data-ttu-id="0f581-123">リッチ プレゼンス文字列は、[developer.microsoft.com](https://developer.microsoft.com/windows) からアクセスできるデベロッパー センター ダッシュボードでタイトルの Xbox Live サービスの一部として構成されます。</span><span class="sxs-lookup"><span data-stu-id="0f581-123">Rich Presence strings are configured as a part of the Xbox Live Service for your title on the Dev Center dashboard accessible from [developer.microsoft.com](https://developer.microsoft.com/windows).</span></span>

<span data-ttu-id="0f581-124">次の手順に従って、リッチ プレゼンスの構成ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="0f581-124">Navigate to the Rich Presence configuration page with the following instructions:</span></span>

1. <span data-ttu-id="0f581-125">developer.microsoft.com で[デベロッパー センター ダッシュボード](https://developer.microsoft.com/windows)に移動します。</span><span class="sxs-lookup"><span data-stu-id="0f581-125">Go to your [Dev Center dashboard](https://developer.microsoft.com/windows) on developer.microsoft.com.</span></span>
2. <span data-ttu-id="0f581-126">サインインが要求された場合は、登録されている Windows 開発者アカウントでサインインします。</span><span class="sxs-lookup"><span data-stu-id="0f581-126">Sign in with your registered Windows developer account if sign-in is requested.</span></span>
3. <span data-ttu-id="0f581-127">**[概要]** ページで Xbox Live 対応のタイトルまたはアプリを選択します。</span><span class="sxs-lookup"><span data-stu-id="0f581-127">Choose your Xbox Live enabled title or App from the **Overview** page.</span></span> <span data-ttu-id="0f581-128">リッチ プレゼンス文字列の構成が有効にならないため、クリエイター プログラムのタイトルは選択しないでください。</span><span class="sxs-lookup"><span data-stu-id="0f581-128">Do not select a Creators Program title as it will not be enabled for Rich Presence string configuration.</span></span>
4. <span data-ttu-id="0f581-129">**[サービス]** ドロップダウン リストをクリックして [Xbox Live] を選択します。</span><span class="sxs-lookup"><span data-stu-id="0f581-129">Click on the **Services** drop down and select Xbox Live.</span></span>
5. <span data-ttu-id="0f581-130">**[Rich Presence]** (リッチ プレゼンス) リンクまで下にスクロールしてクリックします。</span><span class="sxs-lookup"><span data-stu-id="0f581-130">Scroll down to the **Rich Presence** link, and click it.</span></span>

<span data-ttu-id="0f581-131">[Rich Presence] (リッチ プレゼンス) ページに、サービスの簡単な説明、新しいリッチ プレゼンス文字列を作成するボタン、以前に構成した文字列の検索可能な一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f581-131">The Rich Presence page displays a brief description of the service, a button to create a new Rich Presence string and a searchable list of your previously configured strings.</span></span> <span data-ttu-id="0f581-132">このページでは、新しい文字列を構成するだけでなく、構成した文字列を編集および確認できます。</span><span class="sxs-lookup"><span data-stu-id="0f581-132">From this page you can configure new strings as well as edit and review your configured strings.</span></span>

![リッチ プレゼンス文字列の構成ページの例](../../images/rich_presence/RichPresence_ConfigPage_New.JPG)

> [!NOTE]
> <span data-ttu-id="0f581-134">"Playing Net Runner - 月面基地でのマルチプレイヤー デスマッチ (10 キル)" などの文字列</span><span class="sxs-lookup"><span data-stu-id="0f581-134">Strings like "Playing Net Runner - Multiplayer deathmatch on Moon Base with 10 kills.”</span></span> <span data-ttu-id="0f581-135">は、データ プラットフォーム 2017 更新プログラムの時点では開発者は使用できません。</span><span class="sxs-lookup"><span data-stu-id="0f581-135">will not be available to developers as of the Data Platform 2017 update.</span></span> <span data-ttu-id="0f581-136">データ プラットフォーム 2013 の*変数*は、データ プラットフォーム 2017 では使用できません。</span><span class="sxs-lookup"><span data-stu-id="0f581-136">Data Platform 2013 *Variables* are unavailable in Data Platform 2017.</span></span> <span data-ttu-id="0f581-137">この場合の変数は、キル数の "10" です。</span><span class="sxs-lookup"><span data-stu-id="0f581-137">The variable in this case is the number of kills "10".</span></span> <span data-ttu-id="0f581-138">データ プラットフォーム 2017 更新プログラムより後における同等の文字列は、"Playing Net Runner - 月面基地におけるマルチプレイヤー デスマッチ" です。</span><span class="sxs-lookup"><span data-stu-id="0f581-138">The equivalent string after the Data Platform 2017 update would be "Playing Net Runner - Multiplayer deathmatch on Moon Base."</span></span> <span data-ttu-id="0f581-139">“Playing Net Runner - メニュー内” も有効なリッチ プレゼンス文字列です。</span><span class="sxs-lookup"><span data-stu-id="0f581-139">“Playing Net Runner - In the menus” is still a valid Rich Presence string.</span></span>

## <a name="create-a-new-rich-presence-string"></a><span data-ttu-id="0f581-140">新しいリッチ プレゼンス文字列の作成</span><span class="sxs-lookup"><span data-stu-id="0f581-140">Create a new Rich Presence string</span></span>

<span data-ttu-id="0f581-141">リッチ プレゼンス文字列を作成するには、**[New Rich Presence string]** (新しいリッチ プレゼンス文字列) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="0f581-141">To create a Rich Presence string, click the button labeled **New Rich Presence string**.</span></span> <span data-ttu-id="0f581-142">UI に **[Presence Details]** (プレゼンスの詳細) が表示され、新しいリッチ プレゼンス文字列の **[Unique Rich Presence ID]** (一意のリッチ プレゼンス ID) と **[Display string]** (表示文字列) を入力できます。</span><span class="sxs-lookup"><span data-stu-id="0f581-142">You will be presented with UI to fill in the **Presence Details** which include the **Unique Rich Presence ID** as well as the **Display string** for your new Rich Presence string.</span></span>

![新しいリッチ プレゼンス文字列 UI](../../images/rich_presence/RichPresence_Config_NewString.JPG)

<span data-ttu-id="0f581-144">**[Unique Rich Presence ID]** 一意のリッチ プレゼンス ID - 一意のリッチ プレゼンス ID は、リッチ プレゼンス文字列を識別するための文字列です。</span><span class="sxs-lookup"><span data-stu-id="0f581-144">**Unique Rich Presence ID** - The Unique Rich Presence ID is a string used to identify your Rich Presence string.</span></span> <span data-ttu-id="0f581-145">この文字列は、ゲームのプレイヤーの状態を設定するために使用され、表示する特定の文字列に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="0f581-145">This string will be used to set the status of players for your game and is associated with the particular string you would like to display.</span></span> <span data-ttu-id="0f581-146">ID の上限は 50 文字です。</span><span class="sxs-lookup"><span data-stu-id="0f581-146">Your ID can be a maximum of 50 characters.</span></span>

<span data-ttu-id="0f581-147">**[Display string]** (表示文字列) - 表示文字列は、ゲームをプレイしているゲーマーの状態に加えて表示する文字列です。</span><span class="sxs-lookup"><span data-stu-id="0f581-147">**Display string** - The Display string is the string that you will want to display appended to the status of some gamer playing your game.</span></span> <span data-ttu-id="0f581-148">ここには、ゲームへの興味を誘うために表示するリッチ プレゼンス文字列を入力します。</span><span class="sxs-lookup"><span data-stu-id="0f581-148">This is where you will fill in the Rich Presence string you want displayed to generate interest in your game.</span></span> <span data-ttu-id="0f581-149">表示内容は最大 100 文字ですが、先頭の 40 文字のみが表示されるインスタンスがあります。</span><span class="sxs-lookup"><span data-stu-id="0f581-149">Your display can be a maximum of 100 characters but there will be instances where only the first 40 characters will be shown.</span></span>

<span data-ttu-id="0f581-150">新しいリッチ プレゼンス文字列を作成するには、両方のフィールドに入力して **[保存]** ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="0f581-150">In order to create your new Rich Presence string, fill in both fields and press the **Save** button.</span></span>
<span data-ttu-id="0f581-151">[保存] をクリックすると、リッチ プレゼンスの構成ページに戻り、新しいリッチ プレゼンス文字列が構成した文字列の一覧に追加されているのがわかります。</span><span class="sxs-lookup"><span data-stu-id="0f581-151">Once you click save you will be taken back to the Rich Presence Configuration Page where you will see your new Rich Presence string added to the list of configured strings.</span></span>

## <a name="review-edit-and-delete-strings"></a><span data-ttu-id="0f581-152">文字列の確認、編集、削除</span><span class="sxs-lookup"><span data-stu-id="0f581-152">Review, edit, and delete strings</span></span>

<span data-ttu-id="0f581-153">ここでは、リッチ プレゼンスの構成ページで構成したいくつかの文字列を表示できます。</span><span class="sxs-lookup"><span data-stu-id="0f581-153">Here you can see a Rich Presence configuration page with a few configured strings.</span></span>
![構成されたリッチ プレゼンス文字列の例](../../images/rich_presence/RichPresence_ConfigPage_Configured.JPG)

<span data-ttu-id="0f581-155">以前に作成した文字列を確認するには、リッチ プレゼンスの構成ページの一覧を参照します。</span><span class="sxs-lookup"><span data-stu-id="0f581-155">To review previously created strings, simply browse the list on the Rich Presence configuration page.</span></span> <span data-ttu-id="0f581-156">ここでは、一意のリッチ プレゼンス ID と表示文字列の両方を一緒に確認できます。</span><span class="sxs-lookup"><span data-stu-id="0f581-156">There you can see both the Unique Rich Presence ID, and Display string together.</span></span> <span data-ttu-id="0f581-157">タイトルのコードで一意のリッチ プレゼンス ID を使って、リッチ プレゼンス文字列を指定する必要がある場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0f581-157">This will be useful when you need to use the Unique Rich Presence Id in your title's code to specify a Rich Presence string.</span></span>

<span data-ttu-id="0f581-158">リッチ プレゼンス文字列を編集するには、編集する文字列の **[Unique Rich Presence ID]** (一意のリッチ プレゼンス ID) リンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="0f581-158">To edit a Rich Presence string simply click on the **Unique Rich Presence ID** link for the string you want to edit.</span></span> <span data-ttu-id="0f581-159">新しいリッチ プレゼンス文字列を作成するときと同じ UI が表示され、編集のために現在の文字列設定が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f581-159">You will be taken to the same UI used to create a new Rich Presence string with the current string settings filled in for editing.</span></span> <span data-ttu-id="0f581-160">編集したら **[保存]** ボタンをクリックし、構成されている文字列を変更内容で更新します。</span><span class="sxs-lookup"><span data-stu-id="0f581-160">After making edits click the **Save** button to update the configured string with your changes.</span></span>

<span data-ttu-id="0f581-161">構成済みのリッチ プレゼンス文字列を削除するには、リッチ プレゼンスの構成ページで削除するリッチ プレゼンス文字列と同じ行にある **[削除]** リンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="0f581-161">To delete a configured Rich Presence string click the **delete** link on the Rich Presence Configuration page in the same row as the Rich Presence string you would like to delete.</span></span> <span data-ttu-id="0f581-162">削除の確認画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f581-162">You will be asked to confirm the deletion.</span></span>

## <a name="further-reading"></a><span data-ttu-id="0f581-163">参考資料</span><span class="sxs-lookup"><span data-stu-id="0f581-163">Further Reading</span></span>

<span data-ttu-id="0f581-164">リッチ プレゼンス機能の詳しい概念情報と実装方法について詳しくは、[リッチ プレゼンスのドキュメント](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/social-platform/rich-presence-strings/rich-presence-strings-overview)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f581-164">To get more in-depth conceptual information about Rich Presence string features and how to implement them, read the [Rich Presence documentation](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/social-platform/rich-presence-strings/rich-presence-strings-overview).</span></span>