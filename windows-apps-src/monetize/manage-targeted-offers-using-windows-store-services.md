---
author: mcleanbyron
ms.assetid: 9F0A59A1-FAD7-4AD5-B78B-C1280F215D23
description: "アプリで使用可能なターゲット オファーを要求するには、Windows ストア ターゲット オファー API を使います。"
title: "ストア サービスを使ってターゲット オファーを管理する"
ms.author: mcleans
ms.date: 05/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windows ストア ターゲット オファー API, ターゲット オファー"
ms.openlocfilehash: 684c37d4439f415ad607b7f3e6a166966cc9f835
ms.sourcegitcommit: eaacc472317eef343b764d17e57ef24389dd1cc3
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/17/2017
---
# <a name="manage-targeted-offers-using-store-services"></a><span data-ttu-id="e37e3-104">ストア サービスを使ってターゲット オファーを管理する</span><span class="sxs-lookup"><span data-stu-id="e37e3-104">Manage targeted offers using Store services</span></span>

<span data-ttu-id="e37e3-105">Windows デベロッパー センター ダッシュボードの **[関心を引く] > [ターゲット オファー]** ページで*ターゲット オファー*を作成した場合、アプリのコードで *Windows ストア ターゲット オファー API* を使ってターゲット オファーのアプリ内エクスペリエンスを実装します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-105">If you create a *targeted offer* in the **Engage > Targeted offers** page for your app in the Windows Dev Center dashboard, use the *Windows Store targeted offers API* in your app's code to implement the in-app experience for the targeted offer.</span></span> <span data-ttu-id="e37e3-106">ターゲット オファーについてとダッシュボードで作成する方法について詳しくは、「[ターゲット オファーによるエンゲージメントとコンバージョンの最大化](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-106">For more information about targeted offers and how to create them in the dashboard, see [Use targeted offers to maximize engagement and conversions](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md).</span></span>

<span data-ttu-id="e37e3-107">ターゲット オファー API は、以下のタスクの実行に使用できる REST API です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-107">The targeted offers API is a REST API that you can use to perform these tasks:</span></span>

* <span data-ttu-id="e37e3-108">ユーザーがターゲット オファーの顧客セグメントの一部であるかどうか基づいて、現在のユーザーが利用可能なターゲット オファーを取得する。</span><span class="sxs-lookup"><span data-stu-id="e37e3-108">Get the targeted offers that are available for the current user, based on whether or not the user is part of the customer segment for the targeted offer.</span></span>
* <span data-ttu-id="e37e3-109">ユーザーがターゲット オファーを購入した場合、ターゲット オファーに関連付けられているボーナスを受け取ることができるようにストアに要求を提出できます。</span><span class="sxs-lookup"><span data-stu-id="e37e3-109">If the user purchases the targeted offer, you can submit a claim to the Store so you can receive the bonus that is associated with the targeted offer.</span></span> <span data-ttu-id="e37e3-110">これは、コンバージョンが成功するたびにボーナスが開発者に支払われる Microsoft 提供のプロモーションにターゲット オファーが関連付けられている場合のみ必要です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-110">This is only necessary if the targeted offer is associated with a Microsoft-sponsored promotion that pays a bonus to developers for each successful conversion.</span></span>

<span data-ttu-id="e37e3-111">アプリのコードでこの API を使うには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="e37e3-111">To use this API in your app's code, follow these steps:</span></span>

1.  <span data-ttu-id="e37e3-112">アプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得します](#obtain-a-microsoft-account-token)。</span><span class="sxs-lookup"><span data-stu-id="e37e3-112">[Get a Microsoft Account token](#obtain-a-microsoft-account-token) for the current signed-in user of your app.</span></span>
2.  <span data-ttu-id="e37e3-113">[現在のユーザーのターゲット オファーを取得します](#get-targeted-offers)。</span><span class="sxs-lookup"><span data-stu-id="e37e3-113">[Get the targeted offers for the current user](#get-targeted-offers).</span></span>
3.  <span data-ttu-id="e37e3-114">[ターゲット オファーに関連付けられているアドオンを購入します](#purchase-add-on)。</span><span class="sxs-lookup"><span data-stu-id="e37e3-114">[Purchase the add-on that is associated with a targeted offer](#purchase-add-on).</span></span>
3.  <span data-ttu-id="e37e3-115">[ターゲット オファーを要求します](#claim-targeted-offer) (コンバージョンが成功するたびにボーナスが開発者に支払われる Microsoft 提供プロモーションにターゲット オファーが関連付けられている場合)。</span><span class="sxs-lookup"><span data-stu-id="e37e3-115">[Claim the targeted offer](#claim-targeted-offer) (if the targeted offer is associated with a Microsoft-sponsored promotion that pays a bonus to developers for each successful conversion).</span></span>

> [!NOTE]
> <span data-ttu-id="e37e3-116">現在のところ、すべての開発者アカウントで Microsoft 提供プロモーションにターゲット オファーを関連付け、オファーの要求を提出できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="e37e3-116">The ability to associate a targeted offer with a Microsoft-sponsored promotion and then submit a claim for the offer is currently not available to all developer accounts.</span></span>

<span data-ttu-id="e37e3-117">上記のすべての手順を示す完全なコード例については、この記事の最後にある[コード例](#code-example)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-117">For a complete code example that demonstrates all of these steps, see the [code example](#code-example) at the end of this article.</span></span> <span data-ttu-id="e37e3-118">以降のセクションでは、各手順についてさらに詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-118">The following sections provide more details about each step.</span></span>

<span id="obtain-a-microsoft-account-token" />
## <a name="get-a-microsoft-account-token-for-the-current-user"></a><span data-ttu-id="e37e3-119">現在のユーザーの Microsoft アカウント トークンを取得する</span><span class="sxs-lookup"><span data-stu-id="e37e3-119">Get a Microsoft Account token for the current user</span></span>

<span data-ttu-id="e37e3-120">アプリのコードで、現在サインインしているユーザーの Microsoft アカウント (MSA) トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-120">In your app's code, get a Microsoft Account (MSA) token for the current signed-in user.</span></span> <span data-ttu-id="e37e3-121">Windows ストア ターゲット オファー API では、各メソッドの ```Authorization``` 要求ヘッダーでこのトークンを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e37e3-121">You must pass this token in the ```Authorization``` request header for each of the methods in the Windows Store targeted offers API.</span></span> <span data-ttu-id="e37e3-122">このトークンは、現在のユーザーが利用できるターゲット オファーを取得するためにストアにより使用されます。</span><span class="sxs-lookup"><span data-stu-id="e37e3-122">This token is used by the Store to retrieve the targeted offers that are available for the current user.</span></span>

<span data-ttu-id="e37e3-123">MSA トークンを取得するには、[WebAuthenticationCoreManager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webauthenticationcoremanager) クラスを使い、スコープ ```devcenter_implicit.basic,wl.basic``` を設定してトークンを要求します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-123">To get the MSA token, use the [WebAuthenticationCoreManager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webauthenticationcoremanager) class to request a token using the scope ```devcenter_implicit.basic,wl.basic```.</span></span> <span data-ttu-id="e37e3-124">次の例は、この処理を実行する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e37e3-124">The following example demonstrates how to do this.</span></span> <span data-ttu-id="e37e3-125">この例は、[完全な例](#code-example)からの抜粋です。また、完全な例で提供されている **using** ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-125">This example is an excerpt from the [complete example](#code-example), and it requires **using** statements that are provided in the complete example.</span></span>

[!code-cs[<span data-ttu-id="e37e3-126">TargetedOffers</span><span class="sxs-lookup"><span data-stu-id="e37e3-126">TargetedOffers</span></span>](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetMSAToken)]

<span data-ttu-id="e37e3-127">MSA トークンの取得について詳しくは、「[Web アカウント マネージャー](../security/web-account-manager.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-127">For more information about getting MSA tokens, see [Web account manager](../security/web-account-manager.md).</span></span>

<span id="get-targeted-offers" />
## <a name="get-the-targeted-offers-for-the-current-user"></a><span data-ttu-id="e37e3-128">現在のユーザーのターゲット オファーを取得する</span><span class="sxs-lookup"><span data-stu-id="e37e3-128">Get the targeted offers for the current user</span></span>

<span data-ttu-id="e37e3-129">現在のユーザーの MSA トークンがある場合、```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI の GET メソッドを呼び出して、現在のユーザーの利用可能なターゲット オファーを取得します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-129">After you have an MSA token for the current user, call the GET method of the ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI to get the available targeted offers for the current user.</span></span> <span data-ttu-id="e37e3-130">この REST メソッドについて詳しくは、「[ターゲット オファーを取得する](get-targeted-offers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-130">For more information about this REST method, see [Get targeted offers](get-targeted-offers.md).</span></span>

<span data-ttu-id="e37e3-131">このメソッドは、現在のユーザーが利用可能なターゲット オファーに関連付けられているアドオンの製品 ID を返します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-131">This method returns the product IDs of the add-ons that that are associated with the targeted offers that are available for the current user.</span></span> <span data-ttu-id="e37e3-132">この情報を使って、1 つ以上のターゲット オファーをアプリ内での購入としてユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="e37e3-132">With this information, you can offer one or more of the targeted offers as an in-app purchase to the user.</span></span> <span data-ttu-id="e37e3-133">このメソッドは、ストアへの[要求の提出](#claim-targeted-offer)に使うことができる追跡 ID も返すため、ターゲット オファーに関連付けられているボーナスを受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="e37e3-133">This method also returns a tracking ID that you can use to [submit a claim](#claim-targeted-offer) to the Store so you can receive any bonus that is associated with one of the targeted offers.</span></span>

<span data-ttu-id="e37e3-134">次の例は、現在のユーザーのターゲット オファーを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e37e3-134">The following example demonstrates how to get the targeted offers for the current user.</span></span> <span data-ttu-id="e37e3-135">この例は、[完全な例](#code-example)からの抜粋です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-135">This example is an excerpt from the [complete example](#code-example).</span></span> <span data-ttu-id="e37e3-136">また、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリ、および完全な例で提供されている追加クラスと **using** ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-136">It requires the [Json.NET](http://www.newtonsoft.com/json) library from Newtonsoft and additional classes and **using** statements that are provided in the complete example.</span></span>

[!code-cs[<span data-ttu-id="e37e3-137">TargetedOffers</span><span class="sxs-lookup"><span data-stu-id="e37e3-137">TargetedOffers</span></span>](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetTargetedOffers)]

<span id="purchase-add-on" />
## <a name="purchase-the-add-on-that-is-associated-with-a-targeted-offer"></a><span data-ttu-id="e37e3-138">ターゲット オファーに関連付けられているアドオンを購入する</span><span class="sxs-lookup"><span data-stu-id="e37e3-138">Purchase the add-on that is associated with a targeted offer</span></span>

<span data-ttu-id="e37e3-139">次に、購入用のターゲット オファーのいずれかをユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-139">Next, offer one of the targeted offers for purchase to the user.</span></span> <span data-ttu-id="e37e3-140">ユーザーがターゲット オファーの購入に同意した場合、次のいずれかの方法を使って、ターゲット オファーに関連付けられているアドオンをプログラムにより購入します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-140">If the user agrees to purchase the targeted offer, use one of the following methods to programmatically purchase the add-on that is associated with the targeted offer.</span></span> <span data-ttu-id="e37e3-141">前の手順で取得した製品 ID 値を使って、購入するアドオンを特定します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-141">Use the product ID values that you retrieved in the previous step to identify the add-on you want to purchase.</span></span>

* <span data-ttu-id="e37e3-142">アプリが Windows 10 バージョン 1607 以降をターゲットとする場合は、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間で **RequestPurchaseAsync** メソッドのいずれかを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e37e3-142">If your app targets Windows 10, version 1607, or later, we recommend that you use one of the **RequestPurchaseAsync** methods in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) namespace.</span></span> <span data-ttu-id="e37e3-143">これらのメソッドの使い方について詳しくは、「[アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-143">For more information about using these methods, see [Enable in-app purchases of apps and add-ons](enable-in-app-purchases-of-apps-and-add-ons.md).</span></span>

* <span data-ttu-id="e37e3-144">アプリが Windows 10 より前のバージョンをターゲットとしている場合、[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間で [RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp#Windows_ApplicationModel_Store_CurrentApp_RequestProductPurchaseAsync_System_String_) メソッドを使ってアドオンを購入します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-144">If your app targets an earlier version of Windows 10, use the [RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp#Windows_ApplicationModel_Store_CurrentApp_RequestProductPurchaseAsync_System_String_) method in the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace to purchase the add-on.</span></span> <span data-ttu-id="e37e3-145">このメソッドの使い方について詳しくは、「[アプリ内製品購入の有効化](enable-in-app-product-purchases.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-145">For more information about using this method, see [Enable in-app product purchases](enable-in-app-product-purchases.md).</span></span>

<span data-ttu-id="e37e3-146">各オプションを示すコード例については、この記事の最後にある[コード例](#code-example)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-146">For code examples that demonstrate each option, see the [code example](#code-example) at the end of this article.</span></span>

> [!NOTE]
> <span data-ttu-id="e37e3-147">UWP アプリでのアプリ内購入を実装するため、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) (Windows 10 バージョン 1607 で導入) と [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) (すべてのバージョンの Windows 10 で利用可能) の 2 つの異なる名前空間が用意されています。</span><span class="sxs-lookup"><span data-stu-id="e37e3-147">There are two different namespaces for implementing in-app purchases in a UWP app: [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) (introduced in Windows 10, version 1607) and [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) (available in all versions of Windows 10).</span></span> <span data-ttu-id="e37e3-148">これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-148">For more information about the differences between these namespaces, see [In-app purchases and trials](in-app-purchases-and-trials.md).</span></span>

<span id="claim-targeted-offer" />
## <a name="submit-a-claim-for-a-targeted-offer"></a><span data-ttu-id="e37e3-149">ターゲット オファーの要求を提出する</span><span class="sxs-lookup"><span data-stu-id="e37e3-149">Submit a claim for a targeted offer</span></span>

<span data-ttu-id="e37e3-150">コンバージョンが成功するたびにボーナスが開発者に支払われる Microsoft 提供プロモーションに関連付けられているターゲット オファーをユーザーが購入した場合、ボーナスを受け取ることができるようにストアに要求を提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e37e3-150">If the user purchases a targeted offer that is associated with a Microsoft-sponsored promotion that pays a bonus to developers for each successful conversion, you must submit a claim to the Store so you can receive your bonus.</span></span> <span data-ttu-id="e37e3-151">要求を提出するときに、購入の確認を表す値を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e37e3-151">When you submit your claim, you must provide a value that represents the purchase confirmation.</span></span> <span data-ttu-id="e37e3-152">この購入の確認を取得する方法は、アドオンを購入する際に、アプリで **Windows.ApplicationModel.Store** 名前空間と **Windows.Services.Store** 名前空間のどちらの API を使うかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="e37e3-152">The way you obtain this purchase confirmation depends on whether your app uses APIs in the **Windows.ApplicationModel.Store** namespace or **Windows.Services.Store** namespace to purchase the add-on.</span></span>

> [!NOTE]
> <span data-ttu-id="e37e3-153">現在のところ、すべての開発者アカウントで Microsoft 提供プロモーションにターゲット オファーを関連付け、オファーの要求を提出できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="e37e3-153">The ability to associate a targeted offer with a Microsoft-sponsored promotion and then submit a claim for the offer is currently not available to all developer accounts.</span></span>

### <a name="apps-that-use-the-windowsapplicationmodelstore-namespace"></a><span data-ttu-id="e37e3-154">Windows.ApplicationModel.Store 名前空間を使うアプリ</span><span class="sxs-lookup"><span data-stu-id="e37e3-154">Apps that use the Windows.ApplicationModel.Store namespace</span></span>

1. <span data-ttu-id="e37e3-155">**Windows.ApplicationModel.Store** 名前空間で [RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp#Windows_ApplicationModel_Store_CurrentApp_RequestProductPurchaseAsync_System_String_) メソッドを使ってアドオンを購入した後は、必ず[購入領収書](use-receipts-to-verify-product-purchases.md)を受け取ってください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-155">After you purchase the add-on by using the [RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp#Windows_ApplicationModel_Store_CurrentApp_RequestProductPurchaseAsync_System_String_) method in the **Windows.ApplicationModel.Store** namespace, make sure that you retrieve a [purchase receipt](use-receipts-to-verify-product-purchases.md).</span></span> <span data-ttu-id="e37e3-156">この領収書は、**RequestProductPurchaseAsync** メソッドにより返される [PurchaseResults.ReceiptXml](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.purchaseresults#Windows_ApplicationModel_Store_PurchaseResults_ReceiptXml_) オブジェクトで利用可能です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-156">This receipt is available in the [PurchaseResults.ReceiptXml](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.purchaseresults#Windows_ApplicationModel_Store_PurchaseResults_ReceiptXml_) object that is returned by the **RequestProductPurchaseAsync** method.</span></span> <span data-ttu-id="e37e3-157">この領収書は、次の手順で使う購入の確認を表します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-157">This receipt represents the purchase confirmation that you will use in the following step.</span></span>

2. <span data-ttu-id="e37e3-158">POST メッセージを ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI に送信し、ターゲット オファーのコンバージョン要求を提出します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-158">Send a POST message to the ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI to submit a claim for the conversion of the targeted offer.</span></span> <span data-ttu-id="e37e3-159">この REST メソッドについて詳しくは、「[ターゲット オファーを要求する](claim-a-targeted-offer.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-159">For more information about this REST method, see [Claim a targeted offer](claim-a-targeted-offer.md).</span></span> <span data-ttu-id="e37e3-160">要求の本文で、次のデータを渡します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-160">In the request body, pass the following data:</span></span>

  * <span data-ttu-id="e37e3-161">*storeOffer* フィールド: 「[ターゲット オファーを取得する](get-targeted-offers.md)」の方法の応答本文で受け取った JSON オブジェクトのいずれかを渡します (このオブジェクトには *offers* フィールドと *trackingId* フィールドを含める必要があります)。</span><span class="sxs-lookup"><span data-stu-id="e37e3-161">*storeOffer* field: Pass one of the JSON objects you received in the response body of the [Get targeted offers](get-targeted-offers.md) method (this object should include *offers* and *trackingId* fields).</span></span>

  * <span data-ttu-id="e37e3-162">*receipt* フィールド: 前の手順で取得した領収書の文字列を渡します (これは **RequestProductPurchaseAsync** メソッドにより返される **PurchaseResults.ReceiptXml** オブジェクトで利用可能です)。</span><span class="sxs-lookup"><span data-stu-id="e37e3-162">*receipt* field: Pass the receipt string that you retrieved in the previous step (this is available in the **PurchaseResults.ReceiptXml** object that is returned by the **RequestProductPurchaseAsync** method).</span></span>

<span data-ttu-id="e37e3-163">次の例は、**Windows.ApplicationModel.Store** 名前空間の API を使ってターゲット オファーを購入し要求する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e37e3-163">The following example demonstrates how to purchase and claim a targeted offer by using the APIs in the **Windows.ApplicationModel.Store** namespace.</span></span> <span data-ttu-id="e37e3-164">この例は、[完全な例](#code-example)からの抜粋です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-164">This example is an excerpt from the [complete example](#code-example).</span></span> <span data-ttu-id="e37e3-165">また、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリ、および完全な例で提供されている追加クラスと **using** ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-165">It requires the [Json.NET](http://www.newtonsoft.com/json) library from Newtonsoft and additional classes and **using** statements that are provided in the complete example.</span></span>

[!code-cs[<span data-ttu-id="e37e3-166">TargetedOffers</span><span class="sxs-lookup"><span data-stu-id="e37e3-166">TargetedOffers</span></span>](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#ClaimOfferOnAnyVersionWindows10)]

### <a name="apps-that-use-the-windowsservicesstore-namespace"></a><span data-ttu-id="e37e3-167">Windows.Services.Store 名前空間を使うアプリ</span><span class="sxs-lookup"><span data-stu-id="e37e3-167">Apps that use the Windows.Services.Store namespace</span></span>

1. <span data-ttu-id="e37e3-168">[Windows.Services.Store](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間で **RequestPurchaseAsync** メソッドのいずれかを使ってアドオンを購入したら、次の手順に従って購入の*注文 ID* を取得します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-168">After you purchase the add-on by using one of the **RequestPurchaseAsync** methods in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) namespace, get the *order ID* for the purchase by following these steps.</span></span> <span data-ttu-id="e37e3-169">この値は、購入の確認を表します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-169">This value represents the purchase confirmation.</span></span>

  1. <span data-ttu-id="e37e3-170">[GetUserCollectionAsync](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext#Windows_Services_Store_StoreContext_GetUserCollectionAsync_Windows_Foundation_Collections_IIterable_System_String__) メソッドを呼び出して、ユーザーが取得したアドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-170">Call the [GetUserCollectionAsync](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext#Windows_Services_Store_StoreContext_GetUserCollectionAsync_Windows_Foundation_Collections_IIterable_System_String__) method to get the collection of [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) objects that represent the add-ons that the user has acquired.</span></span>

  2. <span data-ttu-id="e37e3-171">このコレクションで、ターゲット オファー用に購入されたアドオンを表す **StoreProduct** オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-171">In this collection, get the **StoreProduct** object that represents the add-on that was purchased for the targeted offer.</span></span>

  3. <span data-ttu-id="e37e3-172">この **StoreProduct** オブジェクトの [ExtendedJsonData](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct#Windows_Services_Store_StoreProduct_ExtendedJsonData_) プロパティの値を取得します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-172">Get the value of the [ExtendedJsonData](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct#Windows_Services_Store_StoreProduct_ExtendedJsonData_) property of this **StoreProduct** object.</span></span> <span data-ttu-id="e37e3-173">このプロパティは、アドオンのストアに関連する完全なデータを含む JSON 形式の文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-173">This property returns a JSON-formatted string that contains the complete Store-related data for the add-on.</span></span>

  4. <span data-ttu-id="e37e3-174">この JSON 文字列を解析し、文字列に含まれている *orderId* フィールドの値を取得します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-174">Parse this JSON string and retrieve the value of the *orderId* field in the string.</span></span>

2. <span data-ttu-id="e37e3-175">POST メッセージを ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI に送信し、ターゲット オファーのコンバージョン要求を提出します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-175">Send a POST message to the ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI to submit a claim for the conversion of the targeted offer.</span></span> <span data-ttu-id="e37e3-176">この REST メソッドについて詳しくは、「[ターゲット オファーを要求する](claim-a-targeted-offer.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-176">For more information about this REST method, see [Claim a targeted offer](claim-a-targeted-offer.md).</span></span> <span data-ttu-id="e37e3-177">要求の本文で、次のオブジェクトを渡します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-177">In the request body, pass the following objects:</span></span>

  * <span data-ttu-id="e37e3-178">*storeOffer* フィールド: 「[ターゲット オファーを取得する](get-targeted-offers.md)」の方法の応答本文で受け取った JSON オブジェクトのいずれかを渡します (このオブジェクトには *offers* フィールドと *trackingId* フィールドを含める必要があります)。</span><span class="sxs-lookup"><span data-stu-id="e37e3-178">*storeOffer* field: Pass one of the JSON objects you received in the response body of the [Get targeted offers](get-targeted-offers.md) method (this object should include *offers* and *trackingId* fields).</span></span>

  * <span data-ttu-id="e37e3-179">*receipt* フィールド: 前の手順で取得した *orderId* 値を渡します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-179">*receipt* field: Pass the *orderId* value you retrieved in the previous step.</span></span>

<span data-ttu-id="e37e3-180">次の例は、**Windows.Services.Store** 名前空間の API を使ってターゲット オファーを購入し要求する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e37e3-180">The following example demonstrates how to purchase and claim a targeted offer by using the APIs in the **Windows.Services.Store** namespace.</span></span> <span data-ttu-id="e37e3-181">この例は、[完全な例](#code-example)からの抜粋です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-181">This example is an excerpt from the [complete example](#code-example).</span></span> <span data-ttu-id="e37e3-182">また、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリ、および完全な例で提供されている追加クラスと **using** ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-182">It requires the [Json.NET](http://www.newtonsoft.com/json) library from Newtonsoft and additional classes and **using** statements that are provided in the complete example.</span></span>

[!code-cs[<span data-ttu-id="e37e3-183">TargetedOffers</span><span class="sxs-lookup"><span data-stu-id="e37e3-183">TargetedOffers</span></span>](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#ClaimOfferOnWindows1607AndLater)]

<span id="code-example" />
## <a name="complete-code-example"></a><span data-ttu-id="e37e3-184">完全なコード例</span><span class="sxs-lookup"><span data-stu-id="e37e3-184">Complete code example</span></span>

<span data-ttu-id="e37e3-185">次のコード例は、次のタスクを示しています。</span><span class="sxs-lookup"><span data-stu-id="e37e3-185">The following code example demonstrates the following tasks:</span></span>

* <span data-ttu-id="e37e3-186">現在のユーザーの MSA トークンを取得する。</span><span class="sxs-lookup"><span data-stu-id="e37e3-186">Get an MSA token for the current user.</span></span>
* <span data-ttu-id="e37e3-187">「[ターゲット オファーを取得する](get-targeted-offers.md)」の方法を使って、現在のユーザーのすべてのターゲット オファーを取得する。</span><span class="sxs-lookup"><span data-stu-id="e37e3-187">Get all of the targeted offers for the current user by using the [Get targeted offers](get-targeted-offers.md) method.</span></span>
* <span data-ttu-id="e37e3-188">ターゲット オファーに関連付けられているアドオンを購入する。</span><span class="sxs-lookup"><span data-stu-id="e37e3-188">Purchase the add-on that is associated with a targeted offer.</span></span>
* <span data-ttu-id="e37e3-189">「[ターゲット オファーを要求する](claim-a-targeted-offer.md)」の方法を使うことで、ターゲット オファーを要求する。</span><span class="sxs-lookup"><span data-stu-id="e37e3-189">Claim the targeted offer by using the [Claim a targeted offer](claim-a-targeted-offer.md) method.</span></span>

<span data-ttu-id="e37e3-190">この例では、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリが必要です。</span><span class="sxs-lookup"><span data-stu-id="e37e3-190">This example requires the [Json.NET](http://www.newtonsoft.com/json) library from Newtonsoft.</span></span> <span data-ttu-id="e37e3-191">この例では、このライブラリを使って JSON 形式のデータをシリアル化および逆シリアル化します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-191">The example uses this library to serialize and deserialize JSON-formatted data.</span></span>

> [!NOTE]
> <span data-ttu-id="e37e3-192">UWP アプリでのアプリ内購入を実装するため、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) (Windows 10 バージョン 1607 で導入) と [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) (すべてのバージョンの Windows 10 で利用可能) の 2 つの異なる名前空間が用意されています。</span><span class="sxs-lookup"><span data-stu-id="e37e3-192">There are two different namespaces for implementing in-app purchases in a UWP app: [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) (introduced in Windows 10, version 1607) and [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) (available in all versions of Windows 10).</span></span> <span data-ttu-id="e37e3-193">この例では、[バージョン アダプティブ コード](../debug-test-perf/version-adaptive-code.md)を使うことで、同じアプリでそれら両方の名前空間を使って、アドオンを購入しターゲット オファーの要求を提出します。</span><span class="sxs-lookup"><span data-stu-id="e37e3-193">This example uses [version adaptive code](../debug-test-perf/version-adaptive-code.md) to use both of these namespaces in the same app to purchase an add-on and submit a claim for the targeted offer.</span></span> <span data-ttu-id="e37e3-194">このコードを使うには、プロジェクトのターゲット OS のバージョンが、**Windows 10 Anniversary Edition (10.0、ビルド 14394)** 以降である必要があります。ただし、以前のバージョンの Windows 10 でアプリを実行する場合は、最小 OS バージョンを以前のバージョンにすることができます。</span><span class="sxs-lookup"><span data-stu-id="e37e3-194">To use this code, the target OS version of your project must be **Windows 10 Anniversary Edition (10.0; Build 14394)** or later, although the minimum OS version can be an earlier version if you want to your app to run on earlier versions of Windows 10.</span></span> <span data-ttu-id="e37e3-195">これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e37e3-195">For more information about the differences between these namespaces, see [In-app purchases and trials](in-app-purchases-and-trials.md).</span></span>

[!code-cs[<span data-ttu-id="e37e3-196">TargetedOffers</span><span class="sxs-lookup"><span data-stu-id="e37e3-196">TargetedOffers</span></span>](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetTargetedOffersSample)]

## <a name="related-topics"></a><span data-ttu-id="e37e3-197">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e37e3-197">Related topics</span></span>

* [<span data-ttu-id="e37e3-198">ターゲット オファーによるエンゲージメントとコンバージョンの最大化</span><span class="sxs-lookup"><span data-stu-id="e37e3-198">Use targeted offers to maximize engagement and conversions</span></span>](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)
* [<span data-ttu-id="e37e3-199">ターゲット オファーを取得する</span><span class="sxs-lookup"><span data-stu-id="e37e3-199">Get targeted offers</span></span>](get-targeted-offers.md)
* [<span data-ttu-id="e37e3-200">ターゲット オファーを要求する</span><span class="sxs-lookup"><span data-stu-id="e37e3-200">Claim a targeted offer</span></span>](claim-a-targeted-offer.md)