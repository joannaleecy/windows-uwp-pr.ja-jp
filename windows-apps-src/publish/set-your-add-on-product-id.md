---
author: jnHs
Description: "Windows デベロッパー センター ダッシュボードで新しいアドオンを作成する際は、製品の種類を指定して、製品 ID を割り当てる必要があります。"
title: "アドオンの製品の種類と製品 ID を設定する"
ms.assetid: 59497B0F-82F0-4CEE-B628-040EF9ED8D3D
ms.author: wdg-dev-content
ms.date: 06/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 136077edcf4704f3ea71416719e7c37db43dafda
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="set-your-add-on-product-type-and-product-id"></a><span data-ttu-id="5a5b5-104">アドオンの製品の種類と製品 ID を設定する</span><span class="sxs-lookup"><span data-stu-id="5a5b5-104">Set your add-on product type and product ID</span></span>

<span data-ttu-id="5a5b5-105">アドオンは、ダッシュボードで作成済みのアプリと関連付けている必要があります (アプリが未申請であっても同様)。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-105">An add-on must be associated with an app that you've created in the dashboard already (even if you haven't submitted it yet).</span></span> <span data-ttu-id="5a5b5-106">アプリの **[概要]** ページまたは **[アドオン]** ページに **[新しいアドオンを作成する]** ボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-106">You can find the button to **Create a new add-on** on your app's **Overview** page or on its **Add-ons** page.</span></span>

<span data-ttu-id="5a5b5-107">**[新しいアドオンを作成する]** を選ぶと、製品の種類を指定し、アドオンに製品 ID を割り当てるように求められます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-107">After you select **Create a new add-on**, you'll be prompted to specify a product type and assign a product ID for your add-on.</span></span>

## <a name="product-type"></a><span data-ttu-id="5a5b5-108">製品の種類</span><span class="sxs-lookup"><span data-stu-id="5a5b5-108">Product type</span></span>

<span data-ttu-id="5a5b5-109">まず、提供するアドオンの種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-109">First, you'll need to indicate which type of add-on you are offering.</span></span> <span data-ttu-id="5a5b5-110">この選択内容は、ユーザーがアドオンをどのように使うことができるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-110">This selection refers to how the customer can use your add-on.</span></span>

> [!NOTE]
> <span data-ttu-id="5a5b5-111">このページを保存してアドオンを作成した後は、製品の種類を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-111">You won't be able to change the product type after you save this page to create the add-on.</span></span> <span data-ttu-id="5a5b5-112">間違った製品の種類を選択した場合は、いつでも進行中のアドオンの申請を削除して、新しいアドオンを作成し直すことができます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-112">If you choose the wrong product type, you can always delete your in-progress add-on submission and start over by creating a new add-on.</span></span>

<span id="durable" />
### <a name="durable"></a><span data-ttu-id="5a5b5-113">永続的</span><span class="sxs-lookup"><span data-stu-id="5a5b5-113">Durable</span></span>

<span data-ttu-id="5a5b5-114">通常 1 回しか購入しないタイプのアドオンの場合は、製品の種類に **[永続的]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-114">Select **Durable** as your product type if your add-on is typically purchased only once.</span></span> <span data-ttu-id="5a5b5-115">このタイプのアドオンは多くの場合、アプリの追加機能のロックを解除するために使います。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-115">These add-ons are often used to unlock additional functionality in an app.</span></span>

<span data-ttu-id="5a5b5-116">永続的なアドオンの **[製品の有効期限]** の既定値は、**[無期限]** です。つまり、アドオンの期限は切れません。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-116">The default **Product lifetime** for a durable add-on is **Forever**, which means the add-on never expires.</span></span> <span data-ttu-id="5a5b5-117">**[製品の有効期限]** は、アドオンの申請プロセスの[プロパティ](enter-add-on-properties.md)の手順で、別の期限に変更できます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-117">You have the option to set the **Product lifetime** to a different duration in the [Properties](enter-add-on-properties.md) step of the add-on submission process.</span></span> <span data-ttu-id="5a5b5-118">変更すると、アドオンは指定した期限 (1 ～ 365 日) を過ぎると使用できなくなります。その場合は、アドオンの期限切れ後に再びアドオンを購入可能にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-118">If you do so, the add-on will expire after the duration you specify (with options from 1-365 days), in which case a customer could purchase it again after it expires.</span></span>

<span id="consumable" />
### <a name="consumable"></a><span data-ttu-id="5a5b5-119">コンシューマブル</span><span class="sxs-lookup"><span data-stu-id="5a5b5-119">Consumable</span></span>

<span data-ttu-id="5a5b5-120">購入して使用 (消費) した後に、再び購入できるアドオンの場合は、**コンシューマブル**な製品の種類のいずれかを選びます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-120">If the add-on can be purchased, used (consumed), and then purchased again, you'll want to select one of the **consumable** product types.</span></span> <span data-ttu-id="5a5b5-121">コンシューマブル アドオンは多くの場合、一定金額を購入してユーザーが使い切ることができるゲーム内通貨 (ゴールド、コインなど) などに使います。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-121">Consumable add-ons are often used for things like in-game currency (gold, coins, etc.) which can be purchased in set amounts and then used up by the customer.</span></span> <span data-ttu-id="5a5b5-122">コンシューマブルなアドオンをアプリで使用する方法について詳しくは、「[コンシューマブルなアドオン購入の有効化](../monetize/enable-consumable-add-on-purchases.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-122">For more info on including consumable add-ons in your app, see [Enable consumable add-on purchases](../monetize/enable-consumable-add-on-purchases.md).</span></span>

<span data-ttu-id="5a5b5-123">コンシューマブルなアドオンには、次の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-123">There are two types of consumable add-ons:</span></span>
- <span data-ttu-id="5a5b5-124">**開発者により管理されるコンシューマブル**: 残高とフルフィルメントは、アプリ内で管理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-124">**Developer-managed consumable**: Balance and fulfillment must be managed within your app.</span></span> <span data-ttu-id="5a5b5-125">すべての OS バージョンでサポートされます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-125">Supported on all OS versions.</span></span>
- <span data-ttu-id="5a5b5-126">**ストアで管理されるコンシューマブル:** 残高は、Windows 10 バージョン 1607 以降を実行している顧客の全デバイスを対象に、Microsoft によって追跡されます。これ以前の OS バージョンではサポートされません。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-126">**Store-managed consumable:** Balance will be tracked by Microsoft across all of the customer’s devices running Windows 10, version 1607 or later; not supported on any earlier OS versions.</span></span> <span data-ttu-id="5a5b5-127">このオプションを使うには、Windows 10 SDK バージョン 14393 以降を使用して親製品をコンパイルする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-127">To use this option, the parent product must be compiled using Windows 10 SDK version 14393 or later.</span></span> <span data-ttu-id="5a5b5-128">また、親製品が公開されるまで、ストアで管理されるコンシューマブル アドオンをストアに申請することはできません (ただし、ダッシュ ボードで申請を作成して作業を開始することは可能です)。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-128">Also note that you can't submit a Store-managed consumable add-on to the Store until the parent product has been published (though you can create the submission in your dashboard and begin working on it at any time).</span></span> <span data-ttu-id="5a5b5-129">申請の**プロパティ**のステップで、ストアで管理されるコンシューマブル アドオンの数量を入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-129">You'll need to enter the quantity for your Store-managed consumable add-on in the **Properties** step of your submission.</span></span>

<span id="subscription" />
### <a name="subscription"></a><span data-ttu-id="5a5b5-130">サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="5a5b5-130">Subscription</span></span>

<span data-ttu-id="5a5b5-131">アドオンの顧客に繰り返し課金する場合は、**[サブスクリプション]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-131">If your want to charge customers on a recurring basis for your add-on, choose **Subscription**.</span></span>

> [!NOTE]
> <span data-ttu-id="5a5b5-132">現在、サブスクリプション アドオンを作成できるのは、早期導入プログラムに参加している開発者アカウントに限られます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-132">Currently, the ability to create subscription add-ons is only available to a set of developer accounts who are participating in an early adoption program.</span></span> <span data-ttu-id="5a5b5-133">いずれは、すべての開発者アカウントでサブスクリプション アドオンをご利用いただけます。現時点でこの正式リリース前のドキュメントを公開しているのは、この機能がどのようなものかを開発者の皆様に簡単に紹介することが目的です。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-133">We will make subscription add-ons available to all developer accounts in the future, and we are making this preliminary documentation available now to give developers a preview of this feature.</span></span> <span data-ttu-id="5a5b5-134">詳しくは、「[アプリのサブスクリプション アドオンの有効化](../monetize/enable-subscription-add-ons-for-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-134">For more info, see [Enable subscription add-ons for your app](../monetize/enable-subscription-add-ons-for-your-app.md).</span></span>

<span data-ttu-id="5a5b5-135">サブスクリプション アドオンは一度購入すると、その後アドオンを使い続けるための料金が定期的にユーザーに課金されます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-135">After a subscription add-on is initially acquired by a customer, they will continue to be charged at recurring intervals in order to keep using the add-on.</span></span> <span data-ttu-id="5a5b5-136">ユーザーはいつでもサブスクリプションをキャンセルして、それ以降の課金を取り消すことができます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-136">The customer can cancel the subscription at any time to avoid further charges.</span></span> <span data-ttu-id="5a5b5-137">サブスクリプション期間と、無料試用版を提供するかどうかを申請の**プロパティ**のステップで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-137">You'll need to specify the subscription period, and whether or not to offer a free trial, in the **Properties** step of your submission.</span></span>

<span data-ttu-id="5a5b5-138">サブスクリプション アドオンは、Windows 10 バージョン 1607 以降を実行しているユーザーのみが対象です。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-138">Subscription add-ons are only supported for customers running Windows 10, version 1607 or later.</span></span> <span data-ttu-id="5a5b5-139">親アプリは Windows 10 SDK バージョン 14393 以降を使ってコンパイルし、**Windows.ApplicationModel.Store** 名前空間ではなく、**Windows.Services.Store** 名前空間のアプリ内購入 API を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-139">The parent app must be compiled using Windows 10 SDK version 14393 or later and it must use the in-app purchase API in the **Windows.Services.Store** namespace instead of the **Windows.ApplicationModel.Store** namespace.</span></span> <span data-ttu-id="5a5b5-140">これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-140">For more information about the differences between these namespaces, see [In-app purchases and trials](../monetize/in-app-purchases-and-trials.md).</span></span>

<span data-ttu-id="5a5b5-141">親製品を公開しないと、サブスクリプション アドオンをストアで公開することはできません (ただし、ダッシュ ボードで申請を作成して作業を開始することは可能です)。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-141">You must submit the parent product before you can publish subscriptions add-on to the Store (though you can create the submission in your dashboard and begin working on it at any time).</span></span>

## <a name="product-id"></a><span data-ttu-id="5a5b5-142">製品 ID</span><span class="sxs-lookup"><span data-stu-id="5a5b5-142">Product ID</span></span>

<span data-ttu-id="5a5b5-143">どの製品の種類を選んでも、アドオンに割り当てる一意の製品 ID を入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-143">Regardless of the product type you choose, you will need to enter a unique product ID for your add-on.</span></span> <span data-ttu-id="5a5b5-144">この名前はダッシュボードでアドオンを識別するために使われます。また、この ID は、[コード内でアドオンを参照](../monetize/in-app-purchases-and-trials.md#how-to-use-product-ids-for-add-ons-in-your-code)するためにも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-144">This name will be used to identify your add-on in the dashboard, and you can use this identifier to [refer to the add-on in your code](../monetize/in-app-purchases-and-trials.md#how-to-use-product-ids-for-add-ons-in-your-code).</span></span>

<span data-ttu-id="5a5b5-145">次に示しているのは、製品 ID を選ぶときの留意点です。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-145">Here are a few things to keep in mind when choosing a product ID:</span></span>

-   <span data-ttu-id="5a5b5-146">この製品 ID はお客様には表示されません </span><span class="sxs-lookup"><span data-stu-id="5a5b5-146">Customers won't see this product ID.</span></span> <span data-ttu-id="5a5b5-147">(後で、お客様に表示される[タイトルと説明](create-add-on-descriptions.md)を入力できます)。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-147">(Later, you can enter a [title and description](create-add-on-descriptions.md) to be displayed to customers.)</span></span>
-   <span data-ttu-id="5a5b5-148">このアドオンの製品 ID はアプリの公開後に変更することも削除することもできません。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-148">You can’t change or delete an add-on's product ID after it's been published.</span></span>
-   <span data-ttu-id="5a5b5-149">この製品 ID の長さは 100 文字以内にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-149">A product ID can't be more than 100 characters in length.</span></span>
-   <span data-ttu-id="5a5b5-150">この製品 ID に **&lt; &gt; \* % & : \\ ? + ,** のいずれの文字も含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-150">A product ID cannot include any of the following characters: **&lt; &gt; \* % & : \\ ? + ,**</span></span>
-   <span data-ttu-id="5a5b5-151">すべての OS バージョンに対応したアドオンを提供するには、英数字、ピリオド、アンダースコアのみを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-151">To offer your add-on in all OS versions, you must only use alphanumeric characters, periods, and/or underscores.</span></span> <span data-ttu-id="5a5b5-152">その他の種類の文字を使った場合、Windows Phone 8.1 以前を実行しているお客様はそのアドオンを購入できなくなります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-152">If you use any other types of characters, the add-on will not be available for purchase to customers running Windows Phone 8.1 or earlier.</span></span>
-   <span data-ttu-id="5a5b5-153">この製品 ID は Windows ストアでは一意である必要はありませんが、開発者アカウントには一意である必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a5b5-153">A product ID doesn't have to be unique within the Windows Store, but it must be unique to your developer account.</span></span>
 
