---
author: JnHs
Description: Target specific segments of your customers with personalized content to increase engagement, retention, and monetization.
title: 対象のプランによるエンゲージメントとコンバージョンの最大化
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, UWP, 対象のプラン, プラン, 販売, 通知
ms.localizationpriority: medium
ms.openlocfilehash: 0f6e1f8119522cd0441157131362d860feff3410
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7102362"
---
# <a name="use-targeted-offers-to-maximize-engagement-and-conversions"></a><span data-ttu-id="2e3d6-103">対象のプランによるエンゲージメントとコンバージョンの最大化</span><span class="sxs-lookup"><span data-stu-id="2e3d6-103">Use targeted offers to maximize engagement and conversions</span></span>

<span data-ttu-id="2e3d6-104">特定のユーザー セグメントをターゲットに設定し、ユーザーに合わせた魅力的なコンテンツを提供すると、エンゲージメント、ユーザー維持率、収益性を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-104">Target specific segments of your customers with attractive, personalized content to increase engagement, retention, and monetization.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2e3d6-105">対象のプランは、アドオンを持つ UWP アプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-105">Targeted offers can only be used with UWP apps that include add-ons.</span></span>

## <a name="targeted-offer-overview"></a><span data-ttu-id="2e3d6-106">対象のプランの概要</span><span class="sxs-lookup"><span data-stu-id="2e3d6-106">Targeted offer overview</span></span>

<span data-ttu-id="2e3d6-107">対象のプランを使うには、次の 3 ステップを実行します。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-107">At a high level, you need to do three things to use targeted offers:</span></span>

1. **<span data-ttu-id="2e3d6-108">[パートナー センター](https://partner.microsoft.com/dashboard)で、プランを作成します。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-108">Create the offer in [Partner Center](https://partner.microsoft.com/dashboard).</span></span>** <span data-ttu-id="2e3d6-109">**[Engage] (関心を引く) の [対象のプラン]** ページに移動して、プランを作成します。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-109">Navigate to the **Engage > Targeted offers** page to create offers.</span></span> <span data-ttu-id="2e3d6-110">このプロセスについては、以降で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-110">More info about this process is described below.</span></span>
2. **<span data-ttu-id="2e3d6-111">アプリ内販売エクスペリエンスを実装する。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-111">Implement the in-app offer experience.</span></span>** <span data-ttu-id="2e3d6-112">*Microsoft Store ターゲット オファー API*コードで使うアプリの特定のユーザー向けの利用可能なプランを取得します。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-112">Use the *Microsoft Store targeted offers API* in your app's code to retrieve the available offers for a given user.</span></span> <span data-ttu-id="2e3d6-113">対象のプラン用のアプリ内エクスペリエンスを作成する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-113">You'll also need to create the in-app experience for the targeted offer.</span></span> <span data-ttu-id="2e3d6-114">詳しくは、「[ストア サービスを使ってターゲット オファーを管理する](../monetize/manage-targeted-offers-using-windows-store-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-114">For more info, see [Manage targeted offers using Store services](../monetize/manage-targeted-offers-using-windows-store-services.md).</span></span>
3. **<span data-ttu-id="2e3d6-115">アプリをストアに提出する。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-115">Submit your app to the Store.</span></span>** <span data-ttu-id="2e3d6-116">プランをユーザーに提供するには、アプリ内販売エクスペリエンスを実装して、アプリを発行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-116">Your app must be published with the in-app offer experience in place in order for the offer(s) be made available to customers.</span></span>

<span data-ttu-id="2e3d6-117">これらの手順を完了すると、プランに関連付けられているセグメントのメンバーシップに基づいて、アプリを使っているユーザーに、そのユーザーがその時点で利用できるプランが表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-117">After you complete these steps, customers using your app will see the offers that are available to them at that time, based in their membership in the segment(s) associated with your offers.</span></span> <span data-ttu-id="2e3d6-118">ただし、Microsoft では利用可能なすべてのプランがユーザーに表示されるように最善を尽くしていますが、ときにはプランの表示状態に問題が生じる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-118">Please note that while we’ll make every effort to show all available offers to your customers, there may occasionally be issues that impact offer availability.</span></span>


## <a name="to-create-and-send-a-targeted-offer"></a><span data-ttu-id="2e3d6-119">対象のプランを作成して送信するには</span><span class="sxs-lookup"><span data-stu-id="2e3d6-119">To create and send a targeted offer</span></span>

1.  <span data-ttu-id="2e3d6-120">[パートナー センター](https://partner.microsoft.com/dashboard)では、左側のナビゲーション メニューで、**利用率の引き上げ**を展開し、**対象のプラン**を選択します。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-120">In [Partner Center](https://partner.microsoft.com/dashboard), expand **Engage** in the left navigation menu, then select **Targeted offers**.</span></span>
2.  <span data-ttu-id="2e3d6-121">**[対象のプラン]** ページで、利用可能なプランを確認します。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-121">On the **Targeted offers** page, review the available offers.</span></span> <span data-ttu-id="2e3d6-122">実装するプランについて、**[新しいプランの作成]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-122">Select **Create new offer** for any offer you wish to implement.</span></span>

    > [!NOTE]
    > <span data-ttu-id="2e3d6-123">表示されるプランは、アカウントの条件や時間の経過と共に変わる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-123">The available offers you will see may vary over time and based on account criteria.</span></span>

3.  <span data-ttu-id="2e3d6-124">利用可能なプランの下に新しい行が表示されます。この行で、プランを利用可能にする製品 (アプリ) を選びます。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-124">In the new row that appears below the available offers, choose the product (app) in which the offer will be available.</span></span> <span data-ttu-id="2e3d6-125">次に、プランに関連付けるアドオンを選びます。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-125">Then, select the add-on that you want to associate with the offer.</span></span>
4.  <span data-ttu-id="2e3d6-126">他のプランを作成する場合は、手順 2 ～ 3 を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-126">Repeat steps 2 and 3 if you'd like to create additional offers.</span></span> <span data-ttu-id="2e3d6-127">種類は同じでも、プランごとに別のアドオンを選ぶと、同じアプリに同じ種類のプランを複数実装できます。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-127">You can implement the same offer type more than once for the same app, as long as you select different add-ons for each offer.</span></span> <span data-ttu-id="2e3d6-128">また、同じアドオンを複数のプランの種類に関連付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-128">Additionally, you can associate the same add-on with more than one offer type.</span></span>
5.  <span data-ttu-id="2e3d6-129">プランの作成が完了したら、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-129">When you are finished creating offers, click **Save**.</span></span>

<span data-ttu-id="2e3d6-130">プランの実装後は、プランごとのコンバージョン数の合計を表示するパートナー センターで、**対象のプラン**のページに返すことができます。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-130">After you've implemented your offers, you can return to the **Targeted offers** page in Partner Center to view the total conversions for each offer.</span></span>

<span data-ttu-id="2e3d6-131">プランを使わないことにした場合 (または使い続ける必要がなくなった場合) は、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-131">If you decide not to use an offer (or if you no longer want to keep using it, click **Delete.**</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2e3d6-132">特定のユーザー向けの利用可能なプランを取得するコードを発行していることと、アプリ内エクスペリエンスを作成することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-132">Be sure you have published the code to retrieve the available offers for a given user, and to create the in-app experience.</span></span> <span data-ttu-id="2e3d6-133">詳しくは、「[ストア サービスを使ってターゲット オファーを管理する](../monetize/manage-targeted-offers-using-windows-store-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-133">For more info, see [Manage targeted offers using Store services](../monetize/manage-targeted-offers-using-windows-store-services.md).</span></span>
>
> <span data-ttu-id="2e3d6-134">対象のプランのコンテンツを検討するときは、あらゆるアプリ コンテンツと同様に、プラン内のコンテンツもストアの[コンテンツ ポリシー](https://docs.microsoft.com/en-us/legal/windows/agreements/store-policies)に準拠する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-134">When considering the content of your targeted offers, keep in mind that, as with all app content, the content in your offers must comply with the Store [Content Policies](https://docs.microsoft.com/en-us/legal/windows/agreements/store-policies).</span></span>
>
> <span data-ttu-id="2e3d6-135">また、アプリを使っているユーザーが、セグメント メンバーシップの決定時に自分の Microsoft アカウントでサインインしていて、後からそのデバイスを他のユーザーに譲渡した場合、元のユーザーを対象としたプランが他のユーザーに表示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2e3d6-135">Also be aware that if a customer who uses your app (and is signed in with their Microsoft account at the time the segment membership is determined) gives their device to someone else to use, the other person may see offers that were targeted at the original customer.</span></span>
