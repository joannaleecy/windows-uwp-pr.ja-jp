---
title: Xbox Live Account Tool
author: KevinAsgari
description: Xbox Live Account Tool を使って Xbox Live 対応タイトルをテストするためのテスト アカウントをすばやく作成する方法について説明します。
ms.assetid: ec5959f9-1c60-4aa4-94a6-5d8bdcf77a96
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, テスト, テスト アカウント
ms.localizationpriority: medium
ms.openlocfilehash: e76f12ab9ebaffff6b106c13c033d5a7210346d0
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5563308"
---
# <a name="xbox-live-account-tool"></a><span data-ttu-id="ca5ea-104">Xbox Live Account Tool</span><span class="sxs-lookup"><span data-stu-id="ca5ea-104">Xbox Live Account Tool</span></span>

## <a name="what-is-xbox-live-account-tool"></a><span data-ttu-id="ca5ea-105">Xbox Live Account Tool とは</span><span class="sxs-lookup"><span data-stu-id="ca5ea-105">What is Xbox Live Account Tool?</span></span>
<span data-ttu-id="ca5ea-106">Xbox Live Account Tool は、タイトル デベロッパーが既存のデベロッパー アカウントをゲーム シナリオのテスト用にセットアップするときに使用できるように作られています。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-106">The Xbox Live Account Tool is a tool designed to help title developers set up existing dev accounts for testing game scenarios.</span></span> <span data-ttu-id="ca5ea-107">たとえば、Xbox Live Account Tool を使用すると、デベロッパー アカウントのゲーマータグを変更したり、アカウントのフレンド リストに 1000 人のフォロワーをすばやく追加したりできます。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-107">For example, you can use Xbox Live Account Tool to change a dev account's gamertag, or quickly add 1000 followers to an account's friends list.</span></span>

## <a name="what-can-i-do-with-xbox-live-account-tool"></a><span data-ttu-id="ca5ea-108">Xbox Live Account Tool の機能</span><span class="sxs-lookup"><span data-stu-id="ca5ea-108">What can I do with Xbox Live Account Tool?</span></span>
<span data-ttu-id="ca5ea-109">以下が可能です。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-109">You can:</span></span>
  1. <span data-ttu-id="ca5ea-110">ユーザーのプロフィール設定、XUID、アクティブな権限を表示する</span><span class="sxs-lookup"><span data-stu-id="ca5ea-110">View a user's profile settings, XUID, and active privileges</span></span>
  2. <span data-ttu-id="ca5ea-111">フォロワーのリストをテキスト ファイルまたは、Xbox 開発者向けプラットフォーム csv からユーザーのソーシャル グラフに追加します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-111">Add a list of followers to a user's social graph, either from a text file or an Xbox Developer Platform csv</span></span>
  3. <span data-ttu-id="ca5ea-112">ユーザーのフレンド リストを管理する: フォローしているユーザーのお気に入り登録、お気に入り解除、ブロック、ブロック解除、およびそのユーザーにフォローされているかどうかの確認</span><span class="sxs-lookup"><span data-stu-id="ca5ea-112">Manage a user's friends list: favorite, unfavorite, block, and unblock users you follow, and see if they follow you back</span></span>
  4. <span data-ttu-id="ca5ea-113">開発ユーザーの評判を変更する (および、未処理の評判統計値をすぐに表示する)</span><span class="sxs-lookup"><span data-stu-id="ca5ea-113">Change your dev user's reputation (and see the raw reputation stat values immediately)</span></span>
  5. <span data-ttu-id="ca5ea-114">ユーザーのゲーマータグを変更する</span><span class="sxs-lookup"><span data-stu-id="ca5ea-114">Change a user's gamertag</span></span>

## <a name="where-can-i-find-xbox-live-account-tool"></a><span data-ttu-id="ca5ea-115">Xbox Live Account Tool の入手方法</span><span class="sxs-lookup"><span data-stu-id="ca5ea-115">Where can I find Xbox Live Account Tool?</span></span>
<span data-ttu-id="ca5ea-116">Xbox Live ツール パッケージの一部として Xbox Live Account Tool が見つかりません[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools)します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-116">The Xbox Live Account Tool can be found as part of the Xbox Live Tools package from [https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools).</span></span>

## <a name="how-do-i-log-in"></a><span data-ttu-id="ca5ea-117">ログイン方法</span><span class="sxs-lookup"><span data-stu-id="ca5ea-117">How do I log in?</span></span>
<span data-ttu-id="ca5ea-118">管理対象のユーザーの資格情報が必要であり、正しいサンドボックスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-118">You'll need the credentials of the user you want to manage and specify the correct sandbox.</span></span> <span data-ttu-id="ca5ea-119">デベロッパー アカウントにサンドボックスへのアクセス権があることを確認してください。アクセス権がないとログインできません。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-119">Make sure that the dev account has access to the sandbox, otherwise the login might fail.</span></span> <span data-ttu-id="ca5ea-120">このツールは、サンドボックスを使用するデベロッパー アカウントを想定して設計されています。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-120">The tool was designed with dev accounts using a sandbox in mind.</span></span>

## <a name="can-i-use-a-retail-account-or-does-it-have-to-be-a-sandboxed-account"></a><span data-ttu-id="ca5ea-121">リテール アカウントを使用できますか? サンドボックス アカウントを使用する必要がありますか?</span><span class="sxs-lookup"><span data-stu-id="ca5ea-121">Can I use a retail account, or does it have to be a sandboxed account?</span></span>
<span data-ttu-id="ca5ea-122">Xbox Live Account Tool を使用してリテール アカウントを管理できますが、すべての機能がサポートされるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-122">You can certainly use Xbox Live Account Tool to manage a retail account, but not all features are supported.</span></span> <span data-ttu-id="ca5ea-123">たとえば、リテール ユーザーの評判を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-123">For example, you cannot change a retail user's reputation.</span></span>

## <a name="how-do-i-change-a-dev-users-gamertag"></a><span data-ttu-id="ca5ea-124">開発ユーザーのゲーマータグを変更する方法</span><span class="sxs-lookup"><span data-stu-id="ca5ea-124">How do I change a dev user's gamertag?</span></span>
<span data-ttu-id="ca5ea-125">[Gamertag] タブに移動してゲーマータグを入力します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-125">Navigate to the "Gamertag" tab and enter a gamertag.</span></span> <span data-ttu-id="ca5ea-126">ゲーマータグに使用できるのは英数字と空白文字のみで、長さは 15 文字以下でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-126">Gamertags must only contain numbers, letters, and spaces and can be only 15 characters long.</span></span> <span data-ttu-id="ca5ea-127">デベロッパー アカウント ゲーマータグは、2 で始まっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-127">Dev account gamertags must start with a 2.</span></span> <span data-ttu-id="ca5ea-128">現在は 1 つの変更のみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-128">Only one change is currently supported.</span></span>

## <a name="how-do-i-see-my-block-list"></a><span data-ttu-id="ca5ea-129">ブロック リストを表示する方法</span><span class="sxs-lookup"><span data-stu-id="ca5ea-129">How do I see my block list?</span></span>
<span data-ttu-id="ca5ea-130">[People] タブに移動し、[Blocked] 列見出しを選択して、現在ブロックされているユーザーで並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-130">Navigate to the "People" tab and select the "Blocked" column header to sort by users who are currently blocked.</span></span>

## <a name="how-do-i-follow-a-large-group-of-users"></a><span data-ttu-id="ca5ea-131">大きいユーザー グループをフォローする方法</span><span class="sxs-lookup"><span data-stu-id="ca5ea-131">How do I follow a large group of users?</span></span>
<span data-ttu-id="ca5ea-132">フォローする必要のある XUID のリストがある場合、それをテキスト ファイルにコピーします。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-132">If you have a list of XUIDs you want to follow, copy them into a text file.</span></span> <span data-ttu-id="ca5ea-133">[Follow] タブに移動し、[Import list] を選択して、ファイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-133">Navigate to the "Follow" tab, select "Import list", and choose your file.</span></span> <span data-ttu-id="ca5ea-134">XUID がリスト ビューに設定されます。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-134">The XUIDs should populate in the list view.</span></span> <span data-ttu-id="ca5ea-135">[commit changes] をクリックしてユーザーをフォローします。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-135">Click "commit changes" to follow the users.</span></span>

## <a name="how-do-i-block-someone"></a><span data-ttu-id="ca5ea-136">ユーザーをブロックする方法</span><span class="sxs-lookup"><span data-stu-id="ca5ea-136">How do I block someone?</span></span>
<span data-ttu-id="ca5ea-137">[People] タブに移動し、ブロックするユーザー (1 人または複数) を選択します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-137">Navigate to the "People" tab and select the user or users you want to block.</span></span> <span data-ttu-id="ca5ea-138">[block] ボタンをクリックすると、まとめてブロックされます。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-138">Press the "block" button and they'll get blocked in batches.</span></span> <span data-ttu-id="ca5ea-139">エラーが発生する場合は、後でやり直してください。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-139">If you notice an error, simply retry later.</span></span>

## <a name="how-do-i-change-my-dev-accounts-repuation"></a><span data-ttu-id="ca5ea-140">開発アカウントの評判を変更する方法</span><span class="sxs-lookup"><span data-stu-id="ca5ea-140">How do I change my dev account's repuation?</span></span>
<span data-ttu-id="ca5ea-141">[Reputation] タブに移動します。適切な既定値を選択し、[Commit changes] ボタンをクリックして要求を送信します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-141">Navigate to the "Reputation" tab. Select the defaults you'd like, and press the "Commit changes" button to submit the request.</span></span> <span data-ttu-id="ca5ea-142">要求が成功した場合、評判の統計値が変更されます。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-142">You'll see the reputation stat values change if the request is successful.</span></span>

## <a name="what-do-the-values-in-the-reputation-tab-mean"></a><span data-ttu-id="ca5ea-143">[Reputation] タブの値の意味</span><span class="sxs-lookup"><span data-stu-id="ca5ea-143">What do the values in the Reputation tab mean?</span></span>
<span data-ttu-id="ca5ea-144">総合的な評判は、フェアプレイ (マルチプレイヤーでの行動)、ユーザー作成コンテンツ (ビデオ クリップなど)、コミュニケーション (メッセージと音声) という 3 つの下位評判から計算されます。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-144">Overall reputation is computed from three sub-reputations: Fairplay (multiplayer conduct), user-generated content (video clips and the like), and communications (messages and voice).</span></span> <span data-ttu-id="ca5ea-145">各カテゴリー未処理の値は 0 ～ 75 の範囲の値で、値が高いほどユーザーの評判が良いことを意味します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-145">The raw values for each category can range from 0 to 75, where higher means the user's reputation is better.</span></span> <span data-ttu-id="ca5ea-146">OverallStatIsBad は、ユーザーの評判が "敬遠対象" かどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-146">The OverallStatIsBad tells you if the user has "Avoid Me" reputation.</span></span>

## <a name="whats-the-black-area-at-the-bottom"></a><span data-ttu-id="ca5ea-147">下部の黒い領域は何のためにあるのですか?</span><span class="sxs-lookup"><span data-stu-id="ca5ea-147">What's the black area at the bottom?</span></span>
<span data-ttu-id="ca5ea-148">情報提供のために、UI にデバッグ出力を表示すると役に立つと考えました。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-148">To keep you informed, we thought that it would be useful if debug output printed in the UI.</span></span> <span data-ttu-id="ca5ea-149">この領域には、ツールの動作状態および発生したエラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-149">That area will tell you what the tool is up to and print any errors it runs into.</span></span>

## <a name="wheres-my-gamerpic"></a><span data-ttu-id="ca5ea-150">ゲーマーアイコンはどこにありますか?</span><span class="sxs-lookup"><span data-stu-id="ca5ea-150">Where's my gamerpic?</span></span>
<span data-ttu-id="ca5ea-151">アカウント作成時に一部の開発アカウントのゲーマーアイコンが自動的に生成されないというバグが確認されています。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-151">We're aware of a bug that some dev accounts do not get a gamerpic auto-generated at account creation time.</span></span>

## <a name="why-are-things-happening-so-slowly"></a><span data-ttu-id="ca5ea-152">処理速度が非常に遅いのはなぜですか?</span><span class="sxs-lookup"><span data-stu-id="ca5ea-152">Why are things happening so slowly?</span></span>
<span data-ttu-id="ca5ea-153">バッチ操作 (フォロワーの追加など) の場合、ツールは自動的にバッチを実行して要求のサイズが大きくなるのを防ぎます。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-153">For the batch operations (like adding followers), the tool automatically performs batches to prevent huge request sizes.</span></span>

## <a name="how-do-i-run-xbox-live-account-tool"></a><span data-ttu-id="ca5ea-154">Xbox Live Account Tool の実行方法</span><span class="sxs-lookup"><span data-stu-id="ca5ea-154">How do I run Xbox Live Account Tool?</span></span>
<span data-ttu-id="ca5ea-155">Xbox Live SDK をフォルダーに展開し、Tools\XboxLiveAccountTool.exe ファイルをダブルクリックして実行します。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-155">Extract Xbox Live SDK to a folder, and double-click the Tools\XboxLiveAccountTool.exe file to run it.</span></span>

## <a name="i-have-a-feature-request-how-do-i-get-my-feature-incorporated"></a><span data-ttu-id="ca5ea-156">搭載してほしい機能があります。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-156">I have a feature request!</span></span> <span data-ttu-id="ca5ea-157">どうすれば機能を組み込んでもらえますか?</span><span class="sxs-lookup"><span data-stu-id="ca5ea-157">How do I get my feature incorporated?</span></span>
<span data-ttu-id="ca5ea-158">マイクロソフトの担当者に機能をお伝えいただければ、検討いたします。</span><span class="sxs-lookup"><span data-stu-id="ca5ea-158">Talk to your Microsoft representative with any feature requests and we'll see what we can do.</span></span>
