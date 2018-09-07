---
author: jnHs
Description: Add-ons are published through the Windows Dev Center dashboard.
title: アドオンの申請
ms.assetid: E175AF9E-A1D4-45DF-B353-5E24E573AE67
ms.author: wdg-dev-content
ms.date: 05/09/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, iap, アプリ内購入, アプリ内製品, iap の申請
ms.localizationpriority: medium
ms.openlocfilehash: 37d05722578ed945fbf75040f96360bb569c6d06
ms.sourcegitcommit: 00d27738325d6db5b5e481911ae7fac0711b05eb
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/07/2018
ms.locfileid: "3662275"
---
# <a name="add-on-submissions"></a><span data-ttu-id="c481b-103">アドオンの申請</span><span class="sxs-lookup"><span data-stu-id="c481b-103">Add-on submissions</span></span>

<span data-ttu-id="c481b-104">アドオン (アプリ内製品とも呼ばれる) は、お客様が購入可能なアプリの補助アイテムです。</span><span class="sxs-lookup"><span data-stu-id="c481b-104">Add-ons (also sometimes referred to as in-app products) are supplementary items for your app that can be purchased by customers.</span></span> <span data-ttu-id="c481b-105">アドオンは、楽しいと考えられる新しいゲーム レベル、またはその他の新機能に対するユーザーのエンゲージメントとできます。</span><span class="sxs-lookup"><span data-stu-id="c481b-105">An add-on can be a fun new feature, a new game level, or anything else you think will keep users engaged.</span></span> <span data-ttu-id="c481b-106">アドオンは収益を得るためだけでなく、お客様との意見交換や顧客エンゲージメントの獲得を促すためにも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c481b-106">Not only are add-ons a great way to make money, but they help to drive customer interaction and engagement.</span></span>

<span data-ttu-id="c481b-107">アドオンは Windows デベロッパー センター ダッシュボードを使って公開します。</span><span class="sxs-lookup"><span data-stu-id="c481b-107">Add-ons are published through the Windows Dev Center dashboard.</span></span> <span data-ttu-id="c481b-108">また、アプリのコードで [アドオンを有効にする](../monetize/in-app-purchases-and-trials.md)ことも必要です。</span><span class="sxs-lookup"><span data-stu-id="c481b-108">You'll also need to [enable the add-ons](../monetize/in-app-purchases-and-trials.md) in your app's code.</span></span>

<span data-ttu-id="c481b-109">アドオンの申請プロセスでは、最初に、[その製品の種類と製品 ID を定義](set-your-add-on-product-id.md)して、ダッシュボードでアドオンを作成します。</span><span class="sxs-lookup"><span data-stu-id="c481b-109">The first step in the add-on submission process is to create the add-on in the dashboard by [defining its product type and product ID](set-your-add-on-product-id.md).</span></span> <span data-ttu-id="c481b-110">その後、Microsoft Store 経由でアドオンを購入できるように、申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="c481b-110">After that, you'll create a submission so that your add-on can be purchased via the Microsoft Store.</span></span> <span data-ttu-id="c481b-111">[アプリの申請](app-submissions.md)と同時にまたは別々にアドオンを申請できます。</span><span class="sxs-lookup"><span data-stu-id="c481b-111">You can submit an add-on at the same time you [submit your app](app-submissions.md), or you can work on it independently.</span></span> <span data-ttu-id="c481b-112">アプリがストアに公開された後は、アプリを再び申請することなく、アドオンを[更新](#updating-an-add-on-after-publication)できます。</span><span class="sxs-lookup"><span data-stu-id="c481b-112">And you can make [updates](#updating-an-add-on-after-publication) to add-ons after the app is in the Store without having to resubmit the app again.</span></span>

> [!NOTE]
> <span data-ttu-id="c481b-113">ドキュメントのこのセクションでは、デベロッパー センター ダッシュボードでアドオンを申請する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c481b-113">This section of the documentation describes how to submit add-ons in the Dev Center dashboard.</span></span> <span data-ttu-id="c481b-114">ここで説明する方法以外に、[Microsoft Store 申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) を使用してアドオン申請を自動化することもできます。</span><span class="sxs-lookup"><span data-stu-id="c481b-114">Alternatively, you can use the [Microsoft Store submission API](../monetize/create-and-manage-submissions-using-windows-store-services.md) to automate add-on submissions.</span></span>


## <a name="checklist-for-submitting-an-add-on"></a><span data-ttu-id="c481b-115">アドオンの申請用チェック リスト</span><span class="sxs-lookup"><span data-stu-id="c481b-115">Checklist for submitting an add-on</span></span>

<span data-ttu-id="c481b-116">アドオンの申請を作成するときに提供する情報の一覧を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c481b-116">Here's a list of the info that you provide when creating your add-on submission.</span></span> <span data-ttu-id="c481b-117">提供が必須である情報については、次の一覧に示してあります。</span><span class="sxs-lookup"><span data-stu-id="c481b-117">The items that you are required to provide are noted below.</span></span> <span data-ttu-id="c481b-118">また、省略可能な情報もあります。既に提供されている既定値は必要に応じて変更できます。</span><span class="sxs-lookup"><span data-stu-id="c481b-118">Some of these are optional, or have default values already provided that you can change as desired.</span></span>


### <a name="create-a-new-add-on-page"></a><span data-ttu-id="c481b-119">新しいアドオン ページを作成する</span><span class="sxs-lookup"><span data-stu-id="c481b-119">Create a new add-on page</span></span>

| <span data-ttu-id="c481b-120">フィールド名</span><span class="sxs-lookup"><span data-stu-id="c481b-120">Field name</span></span>                    | <span data-ttu-id="c481b-121">コメント</span><span class="sxs-lookup"><span data-stu-id="c481b-121">Notes</span></span>                            |
|-------------------------------|----------------------------------|
| [**<span data-ttu-id="c481b-122">製品の種類</span><span class="sxs-lookup"><span data-stu-id="c481b-122">Product type</span></span>**](set-your-add-on-product-id.md#product-type)      | <span data-ttu-id="c481b-123">必須</span><span class="sxs-lookup"><span data-stu-id="c481b-123">Required</span></span> |  
| [**<span data-ttu-id="c481b-124">製品 ID</span><span class="sxs-lookup"><span data-stu-id="c481b-124">Product ID</span></span>**](set-your-add-on-product-id.md#product-id)          | <span data-ttu-id="c481b-125">必須</span><span class="sxs-lookup"><span data-stu-id="c481b-125">Required</span></span> |        


### <a name="properties-page"></a><span data-ttu-id="c481b-126">[プロパティ] ページ</span><span class="sxs-lookup"><span data-stu-id="c481b-126">Properties page</span></span>

| <span data-ttu-id="c481b-127">フィールド名</span><span class="sxs-lookup"><span data-stu-id="c481b-127">Field name</span></span>                    | <span data-ttu-id="c481b-128">コメント</span><span class="sxs-lookup"><span data-stu-id="c481b-128">Notes</span></span>                              |   
|-------------------------------|------------------------------------|
| [**<span data-ttu-id="c481b-129">製品の有効期限</span><span class="sxs-lookup"><span data-stu-id="c481b-129">Product lifetime</span></span>**](enter-add-on-properties.md#product-lifetime)  | <span data-ttu-id="c481b-130">製品の種類が **[永続的]** である場合は必須です。</span><span class="sxs-lookup"><span data-stu-id="c481b-130">Required if the product type is **Durable**.</span></span> <span data-ttu-id="c481b-131">他の種類の製品には適用されません。</span><span class="sxs-lookup"><span data-stu-id="c481b-131">Not applicable to other product types.</span></span> |
| [**<span data-ttu-id="c481b-132">数量</span><span class="sxs-lookup"><span data-stu-id="c481b-132">Quantity</span></span>**](enter-add-on-properties.md#quantity)  | <span data-ttu-id="c481b-133">製品の種類が **[ストアで管理されるコンシューマブル]** の場合は必須です。</span><span class="sxs-lookup"><span data-stu-id="c481b-133">Required if the product type is **Store-managed consumable**.</span></span> <span data-ttu-id="c481b-134">他の種類の製品には適用されません。</span><span class="sxs-lookup"><span data-stu-id="c481b-134">Not applicable to other product types.</span></span> |
| [**<span data-ttu-id="c481b-135">サブスクリプション期間</span><span class="sxs-lookup"><span data-stu-id="c481b-135">Subscription period</span></span>**](enter-add-on-properties.md#subscription-period)          | <span data-ttu-id="c481b-136">製品の種類が **[サブスクリプション]** である場合は必須です。</span><span class="sxs-lookup"><span data-stu-id="c481b-136">Required if the product type is **Subscription**.</span></span> <span data-ttu-id="c481b-137">他の種類の製品には適用されません。</span><span class="sxs-lookup"><span data-stu-id="c481b-137">Not applicable to other product types.</span></span>       |  
| [**<span data-ttu-id="c481b-138">無料試用版</span><span class="sxs-lookup"><span data-stu-id="c481b-138">Free trial</span></span>**](enter-add-on-properties.md#free-trial)          | <span data-ttu-id="c481b-139">製品の種類が **[サブスクリプション]** である場合は必須です。</span><span class="sxs-lookup"><span data-stu-id="c481b-139">Required if the product type is **Subscription**.</span></span> <span data-ttu-id="c481b-140">他の種類の製品には適用されません。</span><span class="sxs-lookup"><span data-stu-id="c481b-140">Not applicable to other product types.</span></span>       |
| [**<span data-ttu-id="c481b-141">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="c481b-141">Content type</span></span>**](enter-add-on-properties.md#content-type)          | <span data-ttu-id="c481b-142">必須</span><span class="sxs-lookup"><span data-stu-id="c481b-142">Required</span></span>    |               
| [**<span data-ttu-id="c481b-143">キーワード</span><span class="sxs-lookup"><span data-stu-id="c481b-143">Keywords</span></span>**](enter-add-on-properties.md#keywords)                  | <span data-ttu-id="c481b-144">省略可能 (最大で 10 個まで。それぞれ 30 文字以内)。</span><span class="sxs-lookup"><span data-stu-id="c481b-144">Optional (up to 10 keywords, 30 character limit each)</span></span> |
| [**<span data-ttu-id="c481b-145">カスタムの開発者データ</span><span class="sxs-lookup"><span data-stu-id="c481b-145">Custom developer data</span></span>**](enter-add-on-properties.md#custom-developer-data)   | <span data-ttu-id="c481b-146">省略可能 (3,000 文字以内)。</span><span class="sxs-lookup"><span data-stu-id="c481b-146">Optional (3000 character limit)</span></span>            |


### <a name="pricing-and-availability-page"></a><span data-ttu-id="c481b-147">[価格と使用可能状況] ページ</span><span class="sxs-lookup"><span data-stu-id="c481b-147">Pricing and availability page</span></span>

| <span data-ttu-id="c481b-148">フィールド名</span><span class="sxs-lookup"><span data-stu-id="c481b-148">Field name</span></span>                    | <span data-ttu-id="c481b-149">メモ</span><span class="sxs-lookup"><span data-stu-id="c481b-149">Notes</span></span>                                       |
|-------------------------------|---------------------------------------------|
| [**<span data-ttu-id="c481b-150">市場</span><span class="sxs-lookup"><span data-stu-id="c481b-150">Markets</span></span>**](set-add-on-pricing-and-availability.md#markets)  | <span data-ttu-id="c481b-151">既定値: 対象となるすべての市場</span><span class="sxs-lookup"><span data-stu-id="c481b-151">Default: All possible markets</span></span> |
| [**<span data-ttu-id="c481b-152">表示</span><span class="sxs-lookup"><span data-stu-id="c481b-152">Visibility</span></span>**](set-add-on-pricing-and-availability.md#visibility)   | <span data-ttu-id="c481b-153">既定値: 購入可能。</span><span class="sxs-lookup"><span data-stu-id="c481b-153">Default: Available for purchase.</span></span> <span data-ttu-id="c481b-154">アプリのリストに表示されます</span><span class="sxs-lookup"><span data-stu-id="c481b-154">May be displayed in your app's listing</span></span> |
| [**<span data-ttu-id="c481b-155">スケジュール</span><span class="sxs-lookup"><span data-stu-id="c481b-155">Schedule</span></span>**](set-add-on-pricing-and-availability.md#schedule)    | <span data-ttu-id="c481b-156">既定値: 最短でリリース</span><span class="sxs-lookup"><span data-stu-id="c481b-156">Default: Release as soon as possible</span></span>
| [**<span data-ttu-id="c481b-157">価格設定</span><span class="sxs-lookup"><span data-stu-id="c481b-157">Pricing</span></span>**](set-add-on-pricing-and-availability.md#pricing)                | <span data-ttu-id="c481b-158">必須</span><span class="sxs-lookup"><span data-stu-id="c481b-158">Required</span></span>                                    |
| [**<span data-ttu-id="c481b-159">セール価格</span><span class="sxs-lookup"><span data-stu-id="c481b-159">Sale pricing</span></span>**](put-apps-and-add-ons-on-sale.md)               | <span data-ttu-id="c481b-160">省略可能</span><span class="sxs-lookup"><span data-stu-id="c481b-160">Optional</span></span>                    |


### <a name="store-listings"></a><span data-ttu-id="c481b-161">ストア登録情報</span><span class="sxs-lookup"><span data-stu-id="c481b-161">Store listings</span></span>

<span data-ttu-id="c481b-162">1 つのストア登録情報が必要です。</span><span class="sxs-lookup"><span data-stu-id="c481b-162">One Store listing required.</span></span> <span data-ttu-id="c481b-163">アプリがサポートする各[言語](create-add-on-store-listings.md#store-listing-languages)でストア登録情報を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c481b-163">We recommend providing Store listings for every [language](create-add-on-store-listings.md#store-listing-languages) your app supports.</span></span>

| <span data-ttu-id="c481b-164">フィールド名</span><span class="sxs-lookup"><span data-stu-id="c481b-164">Field name</span></span>                    | <span data-ttu-id="c481b-165">コメント</span><span class="sxs-lookup"><span data-stu-id="c481b-165">Notes</span></span>                                       |
|-------------------------------|---------------------------------------------|
| [**<span data-ttu-id="c481b-166">タイトル</span><span class="sxs-lookup"><span data-stu-id="c481b-166">Title</span></span>**](create-add-on-store-listings.md#title)                    | <span data-ttu-id="c481b-167">必須 (100 文字以内)</span><span class="sxs-lookup"><span data-stu-id="c481b-167">Required (100 character limit)</span></span>           |
| [**<span data-ttu-id="c481b-168">説明</span><span class="sxs-lookup"><span data-stu-id="c481b-168">Description</span></span>**](create-add-on-store-listings.md#description)       | <span data-ttu-id="c481b-169">省略可能 (200 文字以内)</span><span class="sxs-lookup"><span data-stu-id="c481b-169">Optional (200 character limit)</span></span>            |
| [**<span data-ttu-id="c481b-170">アイコン</span><span class="sxs-lookup"><span data-stu-id="c481b-170">Icon</span></span>**](create-add-on-store-listings.md#icon)                    | <span data-ttu-id="c481b-171">省略可能 (.png、300 x 300 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="c481b-171">Optional (.png, 300x300 pixels)</span></span>            |


<span data-ttu-id="c481b-172">これらの情報の入力が完了したら、**[ストアに提出]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c481b-172">When you've finished entering this info, click **Submit to the Store**.</span></span> <span data-ttu-id="c481b-173">ほとんどの場合、認定プロセスは約 1 時間かかります。</span><span class="sxs-lookup"><span data-stu-id="c481b-173">In most cases, the certification process takes about an hour.</span></span> <span data-ttu-id="c481b-174">その後、アドオンはストアに公開され、お客様が購入できるようになります。</span><span class="sxs-lookup"><span data-stu-id="c481b-174">After that, your add-on will be published to the Store and ready for customers to purchase.</span></span>

> [!NOTE]
> <span data-ttu-id="c481b-175">アドオンは、アプリのコードでも実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c481b-175">The add-on must also be implemented in your app's code.</span></span> <span data-ttu-id="c481b-176">詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c481b-176">For more info, see [In-app purchases and trials](../monetize/in-app-purchases-and-trials.md).</span></span>


## <a name="updating-an-add-on-after-publication"></a><span data-ttu-id="c481b-177">公開後のアドオンの更新</span><span class="sxs-lookup"><span data-stu-id="c481b-177">Updating an add-on after publication</span></span>

<span data-ttu-id="c481b-178">公開したアドオンはいつでも変更できます。</span><span class="sxs-lookup"><span data-stu-id="c481b-178">You can make changes to a published add-on at any time.</span></span> <span data-ttu-id="c481b-179">アドオンの変更が送られ、アプリに独立して公開されるためを一般に、価格や説明の更新などのアドオンを変更するためにアプリ全体を更新する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c481b-179">Add-on changes are submitted and published independently of your app, so you generally don't need to update the entire app in order to make changes to an add-on such as updating its price or description.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c481b-180">Windows 8.x のユーザーがこのアプリを利用できる場合、アドオンの更新がこれらのユーザーにも表示されるようにするために、新しいアプリの申請を作成して公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c481b-180">If your app is available to customers on Windows 8.x, you will need to create and publish a new app submission in order to make the add-on updates visible to those customers.</span></span> <span data-ttu-id="c481b-181">同様に、アプリを公開した後で、Windows 8.x を対象とする新しいアドオンをアプリに追加する場合は、アドオンを参照するようにアプリのコードを更新して、アプリを再申請する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c481b-181">Similarly, if you add new add-ons to an app targeting Windows 8.x after the app has been published, you'll need to update your app's code to reference those add-ons, then resubmit the app.</span></span> <span data-ttu-id="c481b-182">それ以外の場合、新しいアドオンは、Windows 8.x のユーザーには表示されません。</span><span class="sxs-lookup"><span data-stu-id="c481b-182">Otherwise, the new add-ons won't be visible to customers on Windows 8.x.</span></span>

<span data-ttu-id="c481b-183">更新を申請するには、ダッシュボードでアドオンのページに移動し、**[更新]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c481b-183">To submit updates, go to the add-on's page in your dashboard and click **Update**.</span></span> <span data-ttu-id="c481b-184">これにより、開始点として、以前の申請から情報を使用して、アドオンの新しい申請が作成されます。</span><span class="sxs-lookup"><span data-stu-id="c481b-184">This will create a new submission for the add-on, using the info from your previous submission as a starting point.</span></span> <span data-ttu-id="c481b-185">変更をし、**ストアに提出**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c481b-185">Make the changes you'd like, and then click **Submit to the Store**.</span></span>

<span data-ttu-id="c481b-186">既に提供されているアドオンを削除する場合は、新しい申請を作成して、[[分布と認知度]](set-add-on-pricing-and-availability.md) オプションを **[ストアに表示しない]** に変更し、**[購入の停止]** オプションを選択します。</span><span class="sxs-lookup"><span data-stu-id="c481b-186">If you'd like to remove an add-on you've previously offered, you can do this by creating a new submission and changing the [Distribution and visibility](set-add-on-pricing-and-availability.md) option to **Hidden in the Store** with the **Stop acquisition** option.</span></span> <span data-ttu-id="c481b-187">アドオンへの参照も削除するには、必要に応じて、アプリのコードを更新してください (特にアプリが以前に Windows 8.1 をサポートしていた場合、この表示の設定はそれらのユーザーには適用されません)。</span><span class="sxs-lookup"><span data-stu-id="c481b-187">Be sure to update your app's code as needed to also remove references to the add-on (especially if your app supports Windows 8.1 earlier; this visibility setting won't apply to those customers).</span></span>
