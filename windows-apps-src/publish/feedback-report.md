---
Description: パートナー センターでフィードバック レポートでは、問題、提案、およびお客様の Windows 10 フィードバック Hub を介して送信 upvotes を確認できます。
title: フィードバック レポート
ms.assetid: 9EA8B456-CA57-40CE-A55B-7BFDC55CA8A8
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: a827b316d40f9a9cc9c0a5bee0252d47d6af6036
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63791090"
---
# <a name="feedback-report"></a><span data-ttu-id="b1a4a-104">フィードバック レポート</span><span class="sxs-lookup"><span data-stu-id="b1a4a-104">Feedback report</span></span>

<span data-ttu-id="b1a4a-105">**フィードバック レポート**でパートナー センターでの問題、提案、およびお客様の Windows 10 フィードバック Hub を介して送信 upvotes を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-105">The **Feedback report** in Partner Center lets you see the problems, suggestions, and upvotes that your Windows 10 customers have submitted through Feedback Hub.</span></span> <span data-ttu-id="b1a4a-106">パートナー センターでこのデータを表示したり、オフラインで表示するデータをエクスポートすることができます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-106">You can view this data in Partner Center, or export the data to view offline.</span></span>

> [!NOTE]
> <span data-ttu-id="b1a4a-107">またフィードバックを確認していることを顧客に伝えるため、このレポートから直接[フィードバックに返信](respond-to-customer-feedback.md)できます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-107">You can also [respond to feedback](respond-to-customer-feedback.md) directly from this report to let your customers know you're listening.</span></span>

<span data-ttu-id="b1a4a-108">アプリについてのフィードバックをユーザーに送信してもらうように促すのは、ユーザーにとって重要な問題や機能について知ることができる、よい方法です。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-108">Encouraging your customers to give you feedback about your app is a great way to learn about the problems and features that are most important to them.</span></span> <span data-ttu-id="b1a4a-109">ユーザーは、アプリの作成者に直接フィードバックを送ることができるとわかると、否定的なレビューをフィードバックとしてストアに残す可能性が低くなることが考えられます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-109">When your customers know they can send you feedback directly, they may be less likely to leave that feedback as a negative review in the Store.</span></span>

<span data-ttu-id="b1a4a-110">[Microsoft Store Services SDK](https://aka.ms/store-em-sdk) のフィードバック API を使って、ユーザーが直接[アプリからフィードバック Hub を起動](../monetize/launch-feedback-hub-from-your-app.md)するようにできます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-110">You can use the Feedback API in the [Microsoft Store Services SDK](https://aka.ms/store-em-sdk) to let customers [directly launch Feedback Hub from your app](../monetize/launch-feedback-hub-from-your-app.md).</span></span> <span data-ttu-id="b1a4a-111">フィードバック Hub をサポートする Windows 10 デバイスにアプリをダウンロードしたユーザーはだれでも、フィードバック Hub アプリを使ってフィードバックを残すことができます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-111">Keep in mind that any customer who has downloaded your app on a Windows 10 device that supports Feedback Hub has the ability to leave feedback for it by using the Feedback Hub app.</span></span> <span data-ttu-id="b1a4a-112">このためがないご質問からのフィードバックに基づいて、アプリ内で場合でも、このレポートにお客様からのフィードバックを表示する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-112">Because of this, you may see customer feedback in this report even if you have not specifically asked for feedback from within your app.</span></span>

<span data-ttu-id="b1a4a-113">フィードバックは場合にも役立ちますを使用して[パッケージ フライティング](package-flights.md)、ので、**フィードバック**フィードバックを出るときに、各顧客がデバイスにインストールした特定のパッケージを表示します。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-113">Feedback can also be helpful when using [package flighting](package-flights.md), since the **Feedback** report shows you the specific package that each customer had installed on their device when they left the feedback.</span></span>

> [!TIP]
> <span data-ttu-id="b1a4a-114">過去 30 日間に、レビュー、評価、およびすべてのアプリ間でユーザーからのフィードバックの概要、展開**エンゲージ**を選択し、左側のナビゲーション メニューで**レビューとフィードバック。**</span><span class="sxs-lookup"><span data-stu-id="b1a4a-114">For a quick look at the reviews, ratings, and user feedback across all of your apps in the last 30 days, expand **Engage** in the left navigation menu and select **Reviews and feedback.**</span></span> 


## <a name="apply-filters"></a><span data-ttu-id="b1a4a-115">フィルターの適用</span><span class="sxs-lookup"><span data-stu-id="b1a4a-115">Apply filters</span></span>

<span data-ttu-id="b1a4a-116">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-116">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="b1a4a-117">既定では **[有効期間]** が選択されていますが、30 日間、3 か月間、6 か月間、12 か月間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-117">The default selection is **Lifetime**, but you can choose to show data for 30 days, 3 months, 6 months, or 12 months.</span></span>

<span data-ttu-id="b1a4a-118">また、**[フィルター]** を展開して、このページのすべてのデータを次のオプションを使ってフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-118">You can also expand **Filters** to filter all of the data on this page by the following options.</span></span>

- <span data-ttu-id="b1a4a-119">**フィードバックの種類**:既定の設定は**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-119">**Feedback type**: The default setting is **All**.</span></span> <span data-ttu-id="b1a4a-120">**[問題]** または **[提案]** を選択して、表示するフィードバックの種類を選択できます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-120">You can select **Problem** or **Suggestion** to show only that type of feedback.</span></span>
- <span data-ttu-id="b1a4a-121">**デバイスの種類**:既定の設定は**すべてのデバイス**します。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-121">**Device type**: The default setting is **All devices**.</span></span> <span data-ttu-id="b1a4a-122">このページにその種類のデバイスを使っているユーザーによるフィードバックのみを表示する場合は、特定のデバイスの種類を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-122">You can choose a specific device type if you want this page to only show feedback left by customers using that type of device.</span></span>
- <span data-ttu-id="b1a4a-123">**パッケージ バージョン**:既定の設定は**すべてのパッケージ**します。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-123">**Package version**: The default setting is **All packages**.</span></span> <span data-ttu-id="b1a4a-124">パッケージの 1 つを選択して、ユーザーがフィードバックを行ったときに使っていた特定のパッケージのみのフィードバックを表示できます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-124">You can select one of your packages to show only feedback left from customers who were using that particular package when they left feedback.</span></span>
- <span data-ttu-id="b1a4a-125">**市場**:既定の設定は**すべての市場**します。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-125">**Market**: The default setting is **All markets**.</span></span> <span data-ttu-id="b1a4a-126">特定の市場でのユーザーからフィードバックのみを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-126">You can choose a specific to show only feedback from customers in that market.</span></span>
- <span data-ttu-id="b1a4a-127">**グループ**:既定の設定は**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-127">**Group**: The default setting is **All**.</span></span> <span data-ttu-id="b1a4a-128">[Windows Insider](https://insider.windows.com) から送信されたフィードバックのみを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-128">You can choose to view only feedback submitted by [Windows Insiders](https://insider.windows.com).</span></span>

> [!TIP]
> <span data-ttu-id="b1a4a-129">このページにフィードバックが表示されない場合は、フィルターですべてのフィードバックを除外していないかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-129">If you don't see any feedback on the page, check to make sure your filters haven't excluded all of your feedback.</span></span> <span data-ttu-id="b1a4a-130">たとえば、アプリがサポートされていない**デバイスの種類**でフィルター処理する場合、フィードバックは表示されません。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-130">For example, if you filter by a **Device type** that your app doesn't support, you won't see any feedback.</span></span>


## <a name="viewing-feedback-details"></a><span data-ttu-id="b1a4a-131">フィードバックの詳細の表示</span><span class="sxs-lookup"><span data-stu-id="b1a4a-131">Viewing feedback details</span></span>

<span data-ttu-id="b1a4a-132">このレポートには、ユーザーからの個々のフィードバックが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-132">In this report, you’ll see the individual feedback left by your customers.</span></span> <span data-ttu-id="b1a4a-133">各項目のフィードバックのテキストの左には、フィードバック Hub で他のユーザーがそのフィードバックに投じた賛成票の回数が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-133">To the left of the feedback text for each item, you’ll see the number of times the feedback was upvoted by other customers in the Feedback Hub.</span></span> <span data-ttu-id="b1a4a-134">3 つの方法で、フィードバックを並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-134">You can sort the feedback in three ways:</span></span>

- <span data-ttu-id="b1a4a-135">**Upvoted** (既定値)。以降では、ほとんどの upvotes を受信するフィードバックは、他のお客様による upvoted されたフィードバックを示しています。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-135">**Upvoted** (default): Shows feedback that has been upvoted by other customers, starting with the feedback which received the most upvotes.</span></span>
- <span data-ttu-id="b1a4a-136">**トレンド分析**:フィードバックされている他のお客様による upvoted 過去 7 日間、フィードバックを最も最近のアクティビティが取得されて以降を示しています。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-136">**Trending**: Shows feedback that has been upvoted by other customers in the last seven days, starting with the feedback which has been getting the most recent activity.</span></span>
- <span data-ttu-id="b1a4a-137">**最新**:以降、フィードバックを最も最近では、すべてのフィードバックを示しています。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-137">**Most recent**: Shows all feedback, starting with the feedback most recently left.</span></span>

<span data-ttu-id="b1a4a-138">各コメントの横には、フィードバックを受けた日付と、フィードバックの種類が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-138">Next to each comment you’ll see the date on which the feedback was left, and the type of feedback.</span></span> <span data-ttu-id="b1a4a-139">顧客の市場も表示されます、デバイスの種類のフィードバックを出るときに使用、デバイスにインストールされた特定のパッケージと**Windows Insider**フィードバックを送信する顧客のメンバーである場合Windows Insider プログラム。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-139">You’ll also see the customer’s market, the specific package that was installed on the device they were using when they left the feedback, the type of that device, and **Windows Insider** if the customer submitting the feedback is a member of the Windows Insider program.</span></span>

<span data-ttu-id="b1a4a-140">ここには、[フィードバックに返信](respond-to-customer-feedback.md)するためのオプションも表示されます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-140">You'll also see an option here to [respond to the feedback](respond-to-customer-feedback.md).</span></span>


## <a name="translating-feedback"></a><span data-ttu-id="b1a4a-141">フィードバックの翻訳</span><span class="sxs-lookup"><span data-stu-id="b1a4a-141">Translating feedback</span></span>

<span data-ttu-id="b1a4a-142">既定では、好みの言語で記述されたいないフィードバックが変換されます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-142">By default, feedback that was not written in your preferred language is translated for you.</span></span> <span data-ttu-id="b1a4a-143">必要に応じて、右上の、ページ フィルターの近くにある **[フィードバックを翻訳する]** チェック ボックスをオフにして、フィードバックの翻訳を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-143">If you prefer, feedback translation can be disabled by unchecking the **Translate feedback** checkbox at the upper right, near the page filters.</span></span>

<span data-ttu-id="b1a4a-144">フィードバックは自動翻訳システムによって翻訳されるため、翻訳の結果が正確でない場合があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-144">Please note that feedback is translated by an automatic translation system, and the resulting translation may not always be accurate.</span></span> <span data-ttu-id="b1a4a-145">元のテキストと翻訳を比較する場合や、元のテキストを他の方法で翻訳する場合は、元のテキストが提供されます。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-145">The original text is provided if you wish to compare it to the translation, or translate it through some other means.</span></span>


## <a name="launching-feedback-hub-directly-from-your-app"></a><span data-ttu-id="b1a4a-146">アプリから直フィードバック Hub を起動する</span><span class="sxs-lookup"><span data-stu-id="b1a4a-146">Launching Feedback Hub directly from your app</span></span>

<span data-ttu-id="b1a4a-147">前に説明したように、フィードバック Hub への直接のリンクをアプリ内に組み込んで、ユーザーにフィードバックの提供を促すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-147">As noted above, we recommend incorporating a link to Feedback Hub directly in your app to encourage customers to provide feedback.</span></span> <span data-ttu-id="b1a4a-148">詳しくは、「[アプリからのフィードバック Hub の起動](../monetize/launch-feedback-hub-from-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b1a4a-148">For more info, see [Launch Feedback Hub from your app](../monetize/launch-feedback-hub-from-your-app.md).</span></span>
