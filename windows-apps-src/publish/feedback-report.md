---
author: jnHs
Description: The Feedback report in the Windows Dev Center dashboard lets you see the problems, suggestions, and upvotes that your Windows 10 customers have submitted through Feedback Hub.
title: フィードバック レポート
ms.assetid: 9EA8B456-CA57-40CE-A55B-7BFDC55CA8A8
ms.author: wdg-dev-content
ms.date: 11/3/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: bceb1d2cc6682698d0ad06ed4b1865f3d6510442
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2906479"
---
# <a name="feedback-report"></a><span data-ttu-id="d837d-103">フィードバック レポート</span><span class="sxs-lookup"><span data-stu-id="d837d-103">Feedback report</span></span>

<span data-ttu-id="d837d-104">Windows デベロッパー センターのダッシュボードの**フィードバック レポート**により、Windows 10 のユーザーがフィードバック Hub から送信した問題、提案、賛成票を参照できます。</span><span class="sxs-lookup"><span data-stu-id="d837d-104">The **Feedback report** in the Windows Dev Center dashboard lets you see the problems, suggestions, and upvotes that your Windows 10 customers have submitted through Feedback Hub.</span></span> <span data-ttu-id="d837d-105">このデータは、ダッシュボードで表示することも、データをエクスポートしてオフラインで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d837d-105">You can view this data in your dashboard, or export the data to view offline.</span></span>

> [!NOTE]
> <span data-ttu-id="d837d-106">またフィードバックを確認していることを顧客に伝えるため、このレポートから直接[フィードバックに返信](respond-to-customer-feedback.md)できます。</span><span class="sxs-lookup"><span data-stu-id="d837d-106">You can also [respond to feedback](respond-to-customer-feedback.md) directly from this report to let your customers know you're listening.</span></span>

<span data-ttu-id="d837d-107">アプリについてのフィードバックをユーザーに送信してもらうように促すのは、ユーザーにとって重要な問題や機能について知ることができる、よい方法です。</span><span class="sxs-lookup"><span data-stu-id="d837d-107">Encouraging your customers to give you feedback about your app is a great way to learn about the problems and features that are most important to them.</span></span> <span data-ttu-id="d837d-108">ユーザーは、アプリの作成者に直接フィードバックを送ることができるとわかると、否定的なレビューをフィードバックとしてストアに残す可能性が低くなることが考えられます。</span><span class="sxs-lookup"><span data-stu-id="d837d-108">When your customers know they can send you feedback directly, they may be less likely to leave that feedback as a negative review in the Store.</span></span>

<span data-ttu-id="d837d-109">[Microsoft Store Services SDK](http://aka.ms/store-em-sdk) のフィードバック API を使って、ユーザーが直接[アプリからフィードバック Hub を起動](../monetize/launch-feedback-hub-from-your-app.md)するようにできます。</span><span class="sxs-lookup"><span data-stu-id="d837d-109">You can use the Feedback API in the [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) to let customers [directly launch Feedback Hub from your app](../monetize/launch-feedback-hub-from-your-app.md).</span></span> <span data-ttu-id="d837d-110">フィードバック Hub をサポートする Windows 10 デバイスにアプリをダウンロードしたユーザーはだれでも、フィードバック Hub アプリを使ってフィードバックを残すことができます。</span><span class="sxs-lookup"><span data-stu-id="d837d-110">Keep in mind that any customer who has downloaded your app on a Windows 10 device that supports Feedback Hub has the ability to leave feedback for it by using the Feedback Hub app.</span></span> <span data-ttu-id="d837d-111">このため、特に促していないからのフィードバックのアプリ内で場合でも、このレポートでユーザーのフィードバックを表示する場合があります。</span><span class="sxs-lookup"><span data-stu-id="d837d-111">Because of this, you may see customer feedback in this report even if you have not specifically asked for feedback from within your app.</span></span>

<span data-ttu-id="d837d-112">また、[パッケージ フライト](package-flights.md)を使っている場合にもフィードバックは有効です。各ユーザーがデバイスにインストールした特定のパッケージが [フィードバック] レポートに表示されるためです。</span><span class="sxs-lookup"><span data-stu-id="d837d-112">Feedback can also be helpful when using [package flighting](package-flights.md), since the Feedback report shows you the specific package that each customer had installed on their device when they left the feedback.</span></span>

> [!TIP]
> <span data-ttu-id="d837d-113">過去 30 日以内に、レビュー、評価、およびすべてのアプリの間でユーザーのフィードバックの概要を確認、左側のナビゲーション メニューでの**利用率の引き上げ**を展開し、選択**レビューとフィードバック**。</span><span class="sxs-lookup"><span data-stu-id="d837d-113">For a quick look at the reviews, ratings, and user feedback across all of your apps in the last 30 days, expand **Engage** in the left navigation menu and select **Reviews and feedback.**</span></span> 


## <a name="apply-filters"></a><span data-ttu-id="d837d-114">フィルターの適用</span><span class="sxs-lookup"><span data-stu-id="d837d-114">Apply filters</span></span>

<span data-ttu-id="d837d-115">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="d837d-115">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="d837d-116">既定では **[有効期間]** が選択されていますが、30 日間、3 か月間、6 か月間、12 か月間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d837d-116">The default selection is **Lifetime**, but you can choose to show data for 30 days, 3 months, 6 months, or 12 months.</span></span>

<span data-ttu-id="d837d-117">また、**[フィルター]** を展開して、このページのすべてのデータを次のオプションを使ってフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="d837d-117">You can also expand **Filters** to filter all of the data on this page by the following options.</span></span>

- <span data-ttu-id="d837d-118">**[フィードバックの種類]**: 既定の設定は **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="d837d-118">**Feedback type**: The default setting is **All**.</span></span> <span data-ttu-id="d837d-119">**[問題]** または **[提案]** を選択して、表示するフィードバックの種類を選択できます。</span><span class="sxs-lookup"><span data-stu-id="d837d-119">You can select **Problem** or **Suggestion** to show only that type of feedback.</span></span>
- <span data-ttu-id="d837d-120">**[デバイスの種類]**: 既定の設定は **[すべてのデバイス]** です。</span><span class="sxs-lookup"><span data-stu-id="d837d-120">**Device type**: The default setting is **All devices**.</span></span> <span data-ttu-id="d837d-121">このページにその種類のデバイスを使っているユーザーによるフィードバックのみを表示する場合は、特定のデバイスの種類を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="d837d-121">You can choose a specific device type if you want this page to only show feedback left by customers using that type of device.</span></span>
- <span data-ttu-id="d837d-122">**[パッケージ バージョン]**: 既定の設定は **[すべてのパッケージ]** です。</span><span class="sxs-lookup"><span data-stu-id="d837d-122">**Package version**: The default setting is **All packages**.</span></span> <span data-ttu-id="d837d-123">パッケージの 1 つを選択して、ユーザーがフィードバックを行ったときに使っていた特定のパッケージのみのフィードバックを表示できます。</span><span class="sxs-lookup"><span data-stu-id="d837d-123">You can select one of your packages to show only feedback left from customers who were using that particular package when they left feedback.</span></span>
- <span data-ttu-id="d837d-124">**[市場]**: 既定の設定は **[すべての市場]** です。</span><span class="sxs-lookup"><span data-stu-id="d837d-124">**Market**: The default setting is **All markets**.</span></span> <span data-ttu-id="d837d-125">特定の市場でのユーザーからフィードバックのみを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="d837d-125">You can choose a specific to show only feedback from customers in that market.</span></span>
- <span data-ttu-id="d837d-126">**[グループ]**: 既定の設定は **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="d837d-126">**Group**: The default setting is **All**.</span></span> <span data-ttu-id="d837d-127">[Windows Insider](http://insider.windows.com) から送信されたフィードバックのみを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d837d-127">You can choose to view only feedback submitted by [Windows Insiders](http://insider.windows.com).</span></span>

> [!TIP]
> <span data-ttu-id="d837d-128">このページにフィードバックが表示されない場合は、フィルターですべてのフィードバックを除外していないかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="d837d-128">If you don't see any feedback on the page, check to make sure your filters haven't excluded all of your feedback.</span></span> <span data-ttu-id="d837d-129">たとえば、アプリがサポートされていない**デバイスの種類**でフィルター処理する場合、フィードバックは表示されません。</span><span class="sxs-lookup"><span data-stu-id="d837d-129">For example, if you filter by a **Device type** that your app doesn't support, you won't see any feedback.</span></span>


## <a name="viewing-feedback-details"></a><span data-ttu-id="d837d-130">フィードバックの詳細の表示</span><span class="sxs-lookup"><span data-stu-id="d837d-130">Viewing feedback details</span></span>

<span data-ttu-id="d837d-131">このレポートには、ユーザーからの個々のフィードバックが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d837d-131">In this report, you’ll see the individual feedback left by your customers.</span></span> <span data-ttu-id="d837d-132">各項目のフィードバックのテキストの左には、フィードバック Hub で他のユーザーがそのフィードバックに投じた賛成票の回数が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d837d-132">To the left of the feedback text for each item, you’ll see the number of times the feedback was upvoted by other customers in the Feedback Hub.</span></span> <span data-ttu-id="d837d-133">3 つの方法で、フィードバックを並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="d837d-133">You can sort the feedback in three ways:</span></span>

- <span data-ttu-id="d837d-134">**賛成票** (既定): 他のユーザーから最も多くの賛成票を受けたフィードバックを先頭に、賛成票を受けたフィードバックを表示します。</span><span class="sxs-lookup"><span data-stu-id="d837d-134">**Upvoted** (default): Shows feedback that has been upvoted by other customers, starting with the feedback which received the most upvotes.</span></span>
- <span data-ttu-id="d837d-135">**人気上昇中**: 最も直近に受けたフィードバックを先頭に、最近 7 日間に他のユーザーから賛成票を受けたフィードバックを表示します。</span><span class="sxs-lookup"><span data-stu-id="d837d-135">**Trending**: Shows feedback that has been upvoted by other customers in the last seven days, starting with the feedback which has been getting the most recent activity.</span></span>
- <span data-ttu-id="d837d-136">**最近のフィードバック**: 最も直近のフィードバックを先頭に、すべてのフィードバックを表示します。</span><span class="sxs-lookup"><span data-stu-id="d837d-136">**Most recent**: Shows all feedback, starting with the feedback most recently left.</span></span>

<span data-ttu-id="d837d-137">各コメントの横には、フィードバックを受けた日付と、フィードバックの種類が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d837d-137">Next to each comment you’ll see the date on which the feedback was left, and the type of feedback.</span></span> <span data-ttu-id="d837d-138">ユーザーの市場、フィードバックを送信したユーザーが Windows Insider のメンバーである場合、フィードバック、デバイス、 **Windows Insider**の種類を中断したときに使っていたデバイスにインストールされている特定のパッケージを確認することもあります。プログラムです。</span><span class="sxs-lookup"><span data-stu-id="d837d-138">You’ll also see the customer’s market, the specific package that was installed on the device they were using when they left the feedback, the type of that device, and **Windows Insider** if the customer submitting the feedback is a member of the Windows Insider program.</span></span>

<span data-ttu-id="d837d-139">ここには、[フィードバックに返信](respond-to-customer-feedback.md)するためのオプションも表示されます。</span><span class="sxs-lookup"><span data-stu-id="d837d-139">You'll also see an option here to [respond to the feedback](respond-to-customer-feedback.md).</span></span>


## <a name="translating-feedback"></a><span data-ttu-id="d837d-140">フィードバックの翻訳</span><span class="sxs-lookup"><span data-stu-id="d837d-140">Translating feedback</span></span>

<span data-ttu-id="d837d-141">既定では、優先する言語で記述されていないフィードバックは翻訳されます。</span><span class="sxs-lookup"><span data-stu-id="d837d-141">By default, feedback that was not written in your preferred language is translated for you.</span></span> <span data-ttu-id="d837d-142">必要に応じて、右上の、ページ フィルターの近くにある **[フィードバックを翻訳する]** チェック ボックスをオフにして、フィードバックの翻訳を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="d837d-142">If you prefer, feedback translation can be disabled by unchecking the **Translate feedback** checkbox at the upper right, near the page filters.</span></span>

<span data-ttu-id="d837d-143">フィードバックは自動翻訳システムによって翻訳されるため、翻訳の結果が正確でない場合があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d837d-143">Please note that feedback is translated by an automatic translation system, and the resulting translation may not always be accurate.</span></span> <span data-ttu-id="d837d-144">元のテキストと翻訳を比較する場合や、元のテキストを他の方法で翻訳する場合は、元のテキストが提供されます。</span><span class="sxs-lookup"><span data-stu-id="d837d-144">The original text is provided if you wish to compare it to the translation, or translate it through some other means.</span></span>


## <a name="launching-feedback-hub-directly-from-your-app"></a><span data-ttu-id="d837d-145">アプリから直フィードバック Hub を起動する</span><span class="sxs-lookup"><span data-stu-id="d837d-145">Launching Feedback Hub directly from your app</span></span>

<span data-ttu-id="d837d-146">前に説明したように、フィードバック Hub への直接のリンクをアプリ内に組み込んで、ユーザーにフィードバックの提供を促すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d837d-146">As noted above, we recommend incorporating a link to Feedback Hub directly in your app to encourage customers to provide feedback.</span></span> <span data-ttu-id="d837d-147">詳しくは、「[アプリからのフィードバック Hub の起動](../monetize/launch-feedback-hub-from-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d837d-147">For more info, see [Launch Feedback Hub from your app](../monetize/launch-feedback-hub-from-your-app.md).</span></span>
