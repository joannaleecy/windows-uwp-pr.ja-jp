---
author: jnHs
Description: "フィードバックを確認していることを顧客に伝えるために、アプリのレビューに直接返信できます。"
title: "顧客のレビューに返信する"
ms.assetid: 96AA2108-E793-4DD0-8CDA-0D115423C68D
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: c43304d9902727fb8f5c4d0854efb09a0f0f5196
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="respond-to-customer-reviews"></a><span data-ttu-id="2559f-104">顧客のレビューに返信する</span><span class="sxs-lookup"><span data-stu-id="2559f-104">Respond to customer reviews</span></span>


<span data-ttu-id="2559f-105">フィードバックを確認していることを顧客に伝えるために、アプリのレビューに直接返信できます。</span><span class="sxs-lookup"><span data-stu-id="2559f-105">You can respond directly to reviews of your app to let customers know you’re listening to their feedback.</span></span> <span data-ttu-id="2559f-106">レビューへの返信機能を使えば、追加した機能や、顧客のコメントに基づいて修正したバグについて顧客に伝えたり、アプリを改善する方法についてさらに細かいフィードバックを得たりできます。</span><span class="sxs-lookup"><span data-stu-id="2559f-106">With a review response, you can tell customers about the features you’ve added or bugs you’ve fixed based on their comments, or get more specific feedback on how to improve your app.</span></span> <span data-ttu-id="2559f-107">すべての Windows 10 の顧客から見えるように、返信をストアに表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="2559f-107">You can also opt to have your response displayed in the Store for all Windows 10 customers to see.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2559f-108">レビューへの返信を受け取らない設定にしている顧客が書いたレビューには直接返信できません。</span><span class="sxs-lookup"><span data-stu-id="2559f-108">You won't be able to directly respond to reviews written by customers who have chosen not to receive review responses.</span></span> <span data-ttu-id="2559f-109">また、米国外の顧客が Windows Phone 8 デバイスを使って作成したレビューに対して返信することもできません。</span><span class="sxs-lookup"><span data-stu-id="2559f-109">Responses also can’t be left for any reviews that were created by customers outside of the U.S. with Windows Phone 8 devices.</span></span>

<span data-ttu-id="2559f-110">アプリのレビューを表示し、返信するには、Windows デベロッパー センター ダッシュボードで目的のアプリを探します。</span><span class="sxs-lookup"><span data-stu-id="2559f-110">To view your app's reviews and provide responses, find the app in your Windows Dev Center dashboard.</span></span> <span data-ttu-id="2559f-111">左側のナビゲーション メニューで、**[分析]** を展開し、**[レビュー]** をクリックして [[レビュー] レポート](reviews-report.md)を表示します。</span><span class="sxs-lookup"><span data-stu-id="2559f-111">In the left navigation menu, expand **Analytics** and then click **Reviews** to display the [Reviews report](reviews-report.md).</span></span> <span data-ttu-id="2559f-112">**[レビューに返信する]** を選び、返答を記入します。</span><span class="sxs-lookup"><span data-stu-id="2559f-112">Select **Respond to review** to provide your respons.</span></span>

> [!TIP]
> <span data-ttu-id="2559f-113">レビューにはダッシュボードを使って返信するほか、[プログラム](../monetize/submit-responses-to-app-reviews.md)を使って返信することも、[デベロッパー センター アプリ](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws)を使って返信することもできます。</span><span class="sxs-lookup"><span data-stu-id="2559f-113">In addition to using the dashboard to respond to reviews, you can alternatively respond to reviews [programmatically](../monetize/submit-responses-to-app-reviews.md), or by using the [Dev Center app](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws).</span></span> 

<span data-ttu-id="2559f-114">レビューへの返信を送信すると、顧客には Microsoft からその返信を見ることを促すメールが届きます。</span><span class="sxs-lookup"><span data-stu-id="2559f-114">When you send a review response, the customer will receive an email from Microsoft that lets them see your response.</span></span> <span data-ttu-id="2559f-115">このメールには、顧客が直接連絡するときに使うアプリのサポート メール アドレスも記載されます。</span><span class="sxs-lookup"><span data-stu-id="2559f-115">This email will also include your app’s support email address, which the customer can then use to contact you directly.</span></span> <span data-ttu-id="2559f-116">提出プロセスの過程でアプリのサポート メール アドレスを追加していない場合、返信する前にサポート メール アドレスを含めることを求められます。</span><span class="sxs-lookup"><span data-stu-id="2559f-116">If you didn’t add a support email address for your app during the submission process, you'll be asked to include one before you can respond.</span></span>

<span data-ttu-id="2559f-117">既定では、返信は返信先の顧客が見るだけです。</span><span class="sxs-lookup"><span data-stu-id="2559f-117">By default, your response will only be seen by the customer to whom you are responding.</span></span> <span data-ttu-id="2559f-118">その他の顧客にも返信を表示する場合は、**[この返信を公開する]** チェック ボックスをオンにして、アプリのストア登録情報の顧客によるレビューのすぐ下に返信を表示できます。</span><span class="sxs-lookup"><span data-stu-id="2559f-118">If you want to let other customers view your response, check the **Make this response public** box to allow us to display your response in your app’s Store listing, directly below the customer’s review.</span></span> <span data-ttu-id="2559f-119">公開の返信は、Windows 10 デバイスでストアを表示している顧客にのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="2559f-119">Public responses will be visible to any customer viewing the Store on a Windows 10 devices.</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="2559f-120">公開の返信は後で変更できないため (顧客が元のレビューを改訂しない限り)、返信を公開にする前に慎重に検討してください。</span><span class="sxs-lookup"><span data-stu-id="2559f-120">You won’t be able to change a public response later (unless the customer revises their original review), so review your response carefully before you choose to make it public.</span></span> <span data-ttu-id="2559f-121">顧客が元のレビューを改訂すると、返信は削除されます。</span><span class="sxs-lookup"><span data-stu-id="2559f-121">If a customer revises the original review, your response will be removed.</span></span> <span data-ttu-id="2559f-122">必要な場合は、**[返信を更新する]** を選び、改訂されたレビューに対する新しい返信を提出できます。</span><span class="sxs-lookup"><span data-stu-id="2559f-122">You can then submit a new response to the revised review by selecting **Update your response** if you wish.</span></span>


## <a name="guidelines-for-responses"></a><span data-ttu-id="2559f-123">返信のガイドライン</span><span class="sxs-lookup"><span data-stu-id="2559f-123">Guidelines for responses</span></span>

<span data-ttu-id="2559f-124">顧客のレビューに返信する場合、次のガイドラインに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="2559f-124">When responding to a customer's review, you must follow these guidelines.</span></span> <span data-ttu-id="2559f-125">返信を公開にするかどうかにかかわらず、これらのガイドラインはすべての返信に適用されます。</span><span class="sxs-lookup"><span data-stu-id="2559f-125">These apply to all responses, whether you choose to make them public or not.</span></span>

-   <span data-ttu-id="2559f-126">返信は 1,000 文字以内である必要があります。</span><span class="sxs-lookup"><span data-stu-id="2559f-126">Responses can't be longer than 1000 characters.</span></span>
-   <span data-ttu-id="2559f-127">デジタル アプリ アイテムなど、アプリの評価を変更してもらうための補償は一切認められていません。</span><span class="sxs-lookup"><span data-stu-id="2559f-127">You may not offer any type of compensation, including digital app items, to users for changing the app rating.</span></span> <span data-ttu-id="2559f-128">[アプリケーション開発者契約](https://msdn.microsoft.com/library/windows/apps/hh694058)では、評価の操作は許可されていないので注意してください。</span><span class="sxs-lookup"><span data-stu-id="2559f-128">Remember, attempts to manipulate ratings are not permitted under the [App Developer Agreement](https://msdn.microsoft.com/library/windows/apps/hh694058).</span></span>
-   <span data-ttu-id="2559f-129">返信にマーケティング的な内容や広告を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="2559f-129">Don’t include any marketing content or ads in your response.</span></span> <span data-ttu-id="2559f-130">レビュアーは既に顧客です。</span><span class="sxs-lookup"><span data-stu-id="2559f-130">Remember, your reviewer is already your customer.</span></span>
-   <span data-ttu-id="2559f-131">返信で他のアプリやサービスを宣伝しないでください。</span><span class="sxs-lookup"><span data-stu-id="2559f-131">Don’t promote other apps or services in your response.</span></span>
-   <span data-ttu-id="2559f-132">返信は、特定のアプリおよびレビューに直接関係したものにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2559f-132">Your response must be directly related to the specific app and review.</span></span> <span data-ttu-id="2559f-133">同じ質問に対する定型の返信ではない限り、多数のユーザーに同じ返信を送ることはできません。</span><span class="sxs-lookup"><span data-stu-id="2559f-133">Duplicating the same response to a large number of users isn’t allowed if the canned response doesn’t address the same question.</span></span>
-   <span data-ttu-id="2559f-134">品位を欠いたコメントや、攻撃的、個人的、あるいは悪意のあるコメントを、返信に記載しないでください。</span><span class="sxs-lookup"><span data-stu-id="2559f-134">Don’t include any profane, aggressive, personal, or malicious comments in your response.</span></span> <span data-ttu-id="2559f-135">常に礼儀正しさを保つようにしてください。また、満足した顧客はアプリの最も重要な推薦人となるということを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="2559f-135">Always be polite and keep in mind that happy customers will likely be your app’s biggest promoters.</span></span>

> [!NOTE]
> <span data-ttu-id="2559f-136">顧客は、レビューに対する開発者からの不適切な返信を Microsoft に報告できます。</span><span class="sxs-lookup"><span data-stu-id="2559f-136">Customers can report an inappropriate review response from a developer to Microsoft.</span></span> <span data-ttu-id="2559f-137">また、レビューに対する返信を受信しないことを選ぶこともできます。</span><span class="sxs-lookup"><span data-stu-id="2559f-137">They can also opt out of receiving review responses.</span></span> 
>
> <span data-ttu-id="2559f-138">Microsoft は、開発者の返信が不適切であるという報告が異常に多い場合や、開発者の返信が原因でレビューへの返信を拒否しているユーザーの数が異常に多い場合など、どのような理由であっても、開発者が返信をする許可を取り消す権利を留保します。</span><span class="sxs-lookup"><span data-stu-id="2559f-138">Microsoft retains the right to revoke a developer’s permission to send responses for any reason, including if your responses prompt an unusually high number of inappropriate response reports, or if they prompt an unusually high number of customers to opt out of receiving review responses.</span></span>

<span data-ttu-id="2559f-139">ユーザーとの関係は開発者の責任です。</span><span class="sxs-lookup"><span data-stu-id="2559f-139">Your relationship with your customers is your own.</span></span> <span data-ttu-id="2559f-140">開発者とユーザー間の係争に Microsoft は関与しません。</span><span class="sxs-lookup"><span data-stu-id="2559f-140">Microsoft doesn’t get involved in disputes between developers and customers.</span></span> <span data-ttu-id="2559f-141">ただし、アプリのレビューに侮辱的な言葉や冒とく的な言葉、暴言などが含まれている場合は、[サポート チケット](http://go.microsoft.com/fwlink/p/?LinkID=401178)を送信してください。</span><span class="sxs-lookup"><span data-stu-id="2559f-141">However, if a review of your app contains offensive, profane or abusive language, please submit a [support ticket](http://go.microsoft.com/fwlink/p/?LinkID=401178).</span></span>


## <a name="use-customer-reviews-to-improve-your-app"></a><span data-ttu-id="2559f-142">ユーザーのレビューを参考にアプリを改善する</span><span class="sxs-lookup"><span data-stu-id="2559f-142">Use customer reviews to improve your app</span></span>

<span data-ttu-id="2559f-143">ユーザーの声を聞いて返信するのは第一歩にすぎません。</span><span class="sxs-lookup"><span data-stu-id="2559f-143">Listening and responding to your customers is only the beginning.</span></span> <span data-ttu-id="2559f-144">彼らのフィードバックに対応することも重要です。</span><span class="sxs-lookup"><span data-stu-id="2559f-144">Acting on their feedback is also critical.</span></span> <span data-ttu-id="2559f-145">大幅な改善を行う場合は、アプリを更新するための[新しい申請を作成](app-submissions.md)して、ストアで自信を持ってお知らせしてください。</span><span class="sxs-lookup"><span data-stu-id="2559f-145">If you make significant improvements, showcase them in the Store with confidence by [creating a new submission](app-submissions.md) to update your app.</span></span>
