---
author: JnHs
Description: "特定のユーザー セグメントをターゲットに設定し、ユーザーに合わせたコンテンツを提供すると、エンゲージメント、ユーザー維持率、収益性を高めることができます。"
title: "対象のプランによるエンゲージメントとコンバージョンの最大化"
ms.author: wdg-dev-content
ms.date: 07/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 対象のプラン, プラン, 販売, 通知"
ms.openlocfilehash: b30add7a1aa55ffd852bff57fcebb7a5f40e114b
ms.sourcegitcommit: eaacc472317eef343b764d17e57ef24389dd1cc3
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/17/2017
---
# <a name="use-targeted-offers-to-maximize-engagement-and-conversions"></a><span data-ttu-id="2b981-104">対象のプランによるエンゲージメントとコンバージョンの最大化</span><span class="sxs-lookup"><span data-stu-id="2b981-104">Use targeted offers to maximize engagement and conversions</span></span>

<span data-ttu-id="2b981-105">特定のユーザー セグメントをターゲットに設定し、ユーザーに合わせた魅力的なコンテンツを提供すると、エンゲージメント、ユーザー維持率、収益性を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="2b981-105">Target specific segments of your customers with attractive, personalized content to increase engagement, retention, and monetization.</span></span> <span data-ttu-id="2b981-106">場合によっては、対象のプランが Microsoft 提供のプロモーションに関連付けられることもあります。この場合、成功したコンバージョンごとに開発者にボーナスが支払われ、収益を増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="2b981-106">In some cases, targeted offers may be associated with a Microsoft-sponsored promotion that pays a bonus to developers for each successful conversion, allowing you to earn even more.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2b981-107">対象のプランは、アドオンを持つ UWP アプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="2b981-107">Targeted offers can only be used with UWP apps that include add-ons.</span></span>

## <a name="targeted-offer-overview"></a><span data-ttu-id="2b981-108">対象のプランの概要</span><span class="sxs-lookup"><span data-stu-id="2b981-108">Targeted offer overview</span></span>

<span data-ttu-id="2b981-109">対象のプランを使うには、次の 3 ステップを実行します。</span><span class="sxs-lookup"><span data-stu-id="2b981-109">At a high level, you need to do three things to use targeted offers:</span></span>

1. **<span data-ttu-id="2b981-110">ダッシュボードでプランを作成する。</span><span class="sxs-lookup"><span data-stu-id="2b981-110">Create the offer in your dashboard.</span></span>** <span data-ttu-id="2b981-111">**[Engage] (関心を引く) の [対象のプラン]** ページに移動して、プランを作成します。</span><span class="sxs-lookup"><span data-stu-id="2b981-111">Navigate to the **Engage > Targeted offers** page to create offers.</span></span> <span data-ttu-id="2b981-112">このプロセスについては、以降で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="2b981-112">More info about this process is described below.</span></span>
2. **<span data-ttu-id="2b981-113">アプリ内販売エクスペリエンスを実装する。</span><span class="sxs-lookup"><span data-stu-id="2b981-113">Implement the in-app offer experience.</span></span>** <span data-ttu-id="2b981-114">特定のユーザー向けの利用可能なプランを取得したり、プロモーションに関連付けられているプランを要求したりするには、アプリのコードで "Windows ストア対象のプラン API"** を使います。</span><span class="sxs-lookup"><span data-stu-id="2b981-114">Use the *Windows Store targeted offers API* in your app's code to retrieve the available offers for a given user, and to claim the offer (if associated with a promotion).</span></span> <span data-ttu-id="2b981-115">対象のプラン用のアプリ内エクスペリエンスを作成する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="2b981-115">You'll also need to create the in-app experience for the targeted offer.</span></span> <span data-ttu-id="2b981-116">詳しくは、「[ストア サービスを使ってターゲット オファーを管理する](../monetize/manage-targeted-offers-using-windows-store-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2b981-116">For more info, see [Manage targeted offers using Store services](../monetize/manage-targeted-offers-using-windows-store-services.md).</span></span>
3. **<span data-ttu-id="2b981-117">アプリをストアに提出する。</span><span class="sxs-lookup"><span data-stu-id="2b981-117">Submit your app to the Store.</span></span>** <span data-ttu-id="2b981-118">プランをユーザーに提供するには、アプリ内販売エクスペリエンスを実装して、アプリを発行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b981-118">Your app must be published with the in-app offer experience in place in order for the offer(s) be made available to customers.</span></span>

<span data-ttu-id="2b981-119">これらの手順を完了すると、プランに関連付けられているセグメントのメンバーシップに基づいて、アプリを使っているユーザーに、そのユーザーがその時点で利用できるプランが表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="2b981-119">After you complete these steps, customers using your app will see the offers that are available to them at that time, based in their membership in the segment(s) associated with your offers.</span></span> <span data-ttu-id="2b981-120">ただし、Microsoft では利用可能なすべてのプランがユーザーに表示されるように最善を尽くしていますが、ときにはプランの表示状態に問題が生じる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="2b981-120">Please note that while we’ll make every effort to show all available offers to your customers, there may occasionally be issues that impact offer availability.</span></span>


## <a name="to-create-and-send-a-targeted-offer"></a><span data-ttu-id="2b981-121">対象のプランを作成して送信するには</span><span class="sxs-lookup"><span data-stu-id="2b981-121">To create and send a targeted offer</span></span>

<span data-ttu-id="2b981-122">ダッシュボードで対象のプランを作成するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="2b981-122">Follow these steps to create a targeted offer in the dashboard.</span></span> 

1.  <span data-ttu-id="2b981-123">Windows デベロッパー センター ダッシュボードで、左側のナビゲーション メニューの **[Engage] (関心を引く)** を展開して、**[対象のプラン]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="2b981-123">In the Windows Dev Center dashboard, expand **Engage** in the left navigation menu, then select **Targeted offers**.</span></span>
2.  <span data-ttu-id="2b981-124">**[対象のプラン]** ページで、利用可能なプランを確認します。</span><span class="sxs-lookup"><span data-stu-id="2b981-124">On the **Targeted offers** page, review the available offers.</span></span> <span data-ttu-id="2b981-125">実装するプランについて、**[新しいプランの作成]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="2b981-125">Select **Create new offer** for any offer you wish to implement.</span></span> 

    > [!NOTE]
    > <span data-ttu-id="2b981-126">表示されるプランは、アカウントの条件や時間の経過と共に変わる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2b981-126">The available offers you will see may vary over time and based on account criteria.</span></span> <span data-ttu-id="2b981-127">最初は、定義済みのセグメントの条件を使うプランが 1 つ以上表示されます。</span><span class="sxs-lookup"><span data-stu-id="2b981-127">Initially, you will see one or more offers using predefined segment criteria.</span></span> <span data-ttu-id="2b981-128">[開発者定義のユーザー セグメント](create-customer-segments.md)に基づいた対象のプランも、間もなく作成できるようになる予定です。</span><span class="sxs-lookup"><span data-stu-id="2b981-128">Soon, we'll allow you to create targeted offers based on [customer segments that you define](create-customer-segments.md).</span></span>

3.  <span data-ttu-id="2b981-129">利用可能なプランの下に新しい行が表示されます。この行で、プランを利用可能にする製品 (アプリ) を選びます。</span><span class="sxs-lookup"><span data-stu-id="2b981-129">In the new row that appears below the available offers, choose the product (app) in which the offer will be available.</span></span> <span data-ttu-id="2b981-130">次に、プランに関連付けるアドオンを選びます。</span><span class="sxs-lookup"><span data-stu-id="2b981-130">Then, select the add-on that you want to associate with the offer.</span></span> 
4.  <span data-ttu-id="2b981-131">他のプランを作成する場合は、手順 2 ～ 3 を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="2b981-131">Repeat steps 2 and 3 if you'd like to create additional offers.</span></span> <span data-ttu-id="2b981-132">種類は同じでも、プランごとに別のアドオンを選ぶと、同じアプリに同じ種類のプランを複数実装できます。</span><span class="sxs-lookup"><span data-stu-id="2b981-132">You can implement the same offer type more than once for the same app, as long as you select different add-ons for each offer.</span></span> <span data-ttu-id="2b981-133">また、同じアドオンを複数のプランの種類に関連付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="2b981-133">Additionally, you can associate the same add-on with more than one offer type.</span></span>
5.  <span data-ttu-id="2b981-134">プランの作成が完了したら、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2b981-134">When you are finished creating offers, click **Save**.</span></span>

<span data-ttu-id="2b981-135">プランの実装後は、**[対象のプラン]** ページでプランごとのコンバージョン数の合計を確認できます。</span><span class="sxs-lookup"><span data-stu-id="2b981-135">After you've implemented your offers, you can return to the **Targeted offers** page in your dashboard to view the total conversions for each offer.</span></span> 

<span data-ttu-id="2b981-136">プランを使わないことにした場合 (または使い続ける必要がなくなった場合) は、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2b981-136">If you decide not to use an offer (or if you no longer want to keep using it, click **Delete.**</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2b981-137">特定のユーザー向けの利用可能なプランを取得するコードを発行していることと、アプリ内エクスペリエンスを作成することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="2b981-137">Be sure you have published the code to retrieve the available offers for a given user, and to create the in-app experience.</span></span> <span data-ttu-id="2b981-138">詳しくは、「[ストア サービスを使ってターゲット オファーを管理する](../monetize/manage-targeted-offers-using-windows-store-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2b981-138">For more info, see [Manage targeted offers using Store services](../monetize/manage-targeted-offers-using-windows-store-services.md).</span></span>
> 
> <span data-ttu-id="2b981-139">対象のプランのコンテンツを検討するときは、あらゆるアプリ コンテンツと同様に、プラン内のコンテンツもストアの[コンテンツ ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#content_policies)に準拠する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="2b981-139">When considering the content of your targeted offers, keep in mind that, as with all app content, the content in your offers must comply with the Store [Content Policies](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#content_policies).</span></span>
> 
> <span data-ttu-id="2b981-140">また、アプリを使っているユーザーが、セグメント メンバーシップの決定時に自分の Microsoft アカウントでサインインしていて、後からそのデバイスを他のユーザーに譲渡した場合、元のユーザーを対象としたプランが他のユーザーに表示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2b981-140">Also be aware that if a customer who uses your app (and is signed in with their Microsoft account at the time the segment membership is determined) gives their device to someone else to use, the other person may see offers that were targeted at the original customer.</span></span> 

