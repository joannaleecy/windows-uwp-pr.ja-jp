---
author: Xansky
ms.assetid: 9F0A59A1-FAD7-4AD5-B78B-C1280F215D23
description: アプリの現在のユーザーが利用できるターゲット オファーを取得するには、Microsoft Store ターゲット オファー API を使います。
title: ストア サービスを使ってターゲット オファーを管理する
ms.author: mhopkins
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store ターゲット オファー API, ターゲット オファー
ms.localizationpriority: medium
ms.openlocfilehash: dbfefefdb7f7b96dbe99b35656b610b393ab3afa
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6444807"
---
# <a name="manage-targeted-offers-using-store-services"></a><span data-ttu-id="d40a4-104">ストア サービスを使ってターゲット オファーを管理する</span><span class="sxs-lookup"><span data-stu-id="d40a4-104">Manage targeted offers using Store services</span></span>

<span data-ttu-id="d40a4-105">*対象のプラン*を作成する場合、**利用率の引き上げ > 対象のプラン**パートナー センターで、使用して、 *Microsoft Store ターゲット オファー API* 、アプリのコードに役立つ情報を取得するエクスペリエンスを実装するアプリ内のアプリのページ、ターゲット オファーします。</span><span class="sxs-lookup"><span data-stu-id="d40a4-105">If you create a *targeted offer* in the **Engage > Targeted offers** page for your app in Partner Center, use the *Microsoft Store targeted offers API* in your app's code to retrieve info that helps you implement the in-app experience for the targeted offer.</span></span> <span data-ttu-id="d40a4-106">ターゲット オファーについてとダッシュボードで作成する方法について詳しくは、「[ターゲット オファーによるエンゲージメントとコンバージョンの最大化](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d40a4-106">For more information about targeted offers and how to create them in the dashboard, see [Use targeted offers to maximize engagement and conversions](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md).</span></span>

<span data-ttu-id="d40a4-107">ターゲット オファー API はシンプルな REST API で、これを使用すると、ユーザーがターゲット オファーの顧客セグメントに属しているかどうかに基づいて、現在のユーザーに適用されるターゲット オファーを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d40a4-107">The targeted offers API is a simple REST API that you can use to get the targeted offers that are available for the current user, based on whether or not the user is part of the customer segment for the targeted offer.</span></span> <span data-ttu-id="d40a4-108">アプリのコードでこの API を使うには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="d40a4-108">To use this API in your app's code, follow these steps:</span></span>

1.  <span data-ttu-id="d40a4-109">アプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得します](#obtain-a-microsoft-account-token)。</span><span class="sxs-lookup"><span data-stu-id="d40a4-109">[Get a Microsoft Account token](#obtain-a-microsoft-account-token) for the current signed-in user of your app.</span></span>
2.  <span data-ttu-id="d40a4-110">[現在のユーザーのターゲット オファーを取得します](#get-targeted-offers)。</span><span class="sxs-lookup"><span data-stu-id="d40a4-110">[Get the targeted offers for the current user](#get-targeted-offers).</span></span>
3.  <span data-ttu-id="d40a4-111">ターゲット オファーの 1 つに関連付けられているアドオンのアプリ内購入エクスペリエンスを実装します。</span><span class="sxs-lookup"><span data-stu-id="d40a4-111">Implement the in-app purchase experience for the add-on that is associated with one of the targeted offers.</span></span> <span data-ttu-id="d40a4-112">アプリ内購入の実装について詳しくは、[こちらの記事](enable-in-app-purchases-of-apps-and-add-ons.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d40a4-112">For more information about implementing in-app purchases, see [this article](enable-in-app-purchases-of-apps-and-add-ons.md).</span></span>

<span data-ttu-id="d40a4-113">上記のすべての手順を示す完全なコード例については、この記事の最後にある[コード例](#code-example)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d40a4-113">For a complete code example that demonstrates all of these steps, see the [code example](#code-example) at the end of this article.</span></span> <span data-ttu-id="d40a4-114">以降のセクションでは、各手順についてさらに詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="d40a4-114">The following sections provide more details about each step.</span></span>

<span id="obtain-a-microsoft-account-token" />

## <a name="get-a-microsoft-account-token-for-the-current-user"></a><span data-ttu-id="d40a4-115">現在のユーザーの Microsoft アカウント トークンを取得する</span><span class="sxs-lookup"><span data-stu-id="d40a4-115">Get a Microsoft Account token for the current user</span></span>

<span data-ttu-id="d40a4-116">アプリのコードで、現在サインインしているユーザーの Microsoft アカウント (MSA) トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="d40a4-116">In your app's code, get a Microsoft Account (MSA) token for the current signed-in user.</span></span> <span data-ttu-id="d40a4-117">このトークンを Microsoft Store ターゲット オファー API の ```Authorization``` 要求ヘッダーに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d40a4-117">You must pass this token in the ```Authorization``` request header for the Microsoft Store targeted offers API.</span></span> <span data-ttu-id="d40a4-118">このトークンは、現在のユーザーが利用できるターゲット オファーを取得するために Store によって使用されます。</span><span class="sxs-lookup"><span data-stu-id="d40a4-118">This token is used by the Store to retrieve the targeted offers that are available for the current user.</span></span>

<span data-ttu-id="d40a4-119">MSA トークンを取得するには、[WebAuthenticationCoreManager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webauthenticationcoremanager) クラスを使い、スコープ ```devcenter_implicit.basic,wl.basic``` を設定してトークンを要求します。</span><span class="sxs-lookup"><span data-stu-id="d40a4-119">To get the MSA token, use the [WebAuthenticationCoreManager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webauthenticationcoremanager) class to request a token using the scope ```devcenter_implicit.basic,wl.basic```.</span></span> <span data-ttu-id="d40a4-120">次の例は、この処理を実行する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d40a4-120">The following example demonstrates how to do this.</span></span> <span data-ttu-id="d40a4-121">この例は[完全な例](#code-example)からの抜粋で、完全な例に示されている **using** ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="d40a4-121">This example is an excerpt from the [complete example](#code-example), and it requires **using** statements that are provided in the complete example.</span></span>

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetMSAToken)]

<span data-ttu-id="d40a4-122">MSA トークンの取得について詳しくは、「[Web アカウント マネージャー](../security/web-account-manager.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d40a4-122">For more information about getting MSA tokens, see [Web account manager](../security/web-account-manager.md).</span></span>

<span id="get-targeted-offers" />

## <a name="get-the-targeted-offers-for-the-current-user"></a><span data-ttu-id="d40a4-123">現在のユーザーのターゲット オファーを取得する</span><span class="sxs-lookup"><span data-stu-id="d40a4-123">Get the targeted offers for the current user</span></span>

<span data-ttu-id="d40a4-124">現在のユーザーの MSA トークンがある場合、```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI の GET メソッドを呼び出して、現在のユーザーの利用可能なターゲット オファーを取得します。</span><span class="sxs-lookup"><span data-stu-id="d40a4-124">After you have an MSA token for the current user, call the GET method of the ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI to get the available targeted offers for the current user.</span></span> <span data-ttu-id="d40a4-125">この REST メソッドについて詳しくは、「[ターゲット オファーを取得する](get-targeted-offers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d40a4-125">For more information about this REST method, see [Get targeted offers](get-targeted-offers.md).</span></span>

<span data-ttu-id="d40a4-126">このメソッドは、現在のユーザーが利用可能なターゲット オファーに関連付けられているアドオンの製品 ID を返します。</span><span class="sxs-lookup"><span data-stu-id="d40a4-126">This method returns the product IDs of the add-ons that that are associated with the targeted offers that are available for the current user.</span></span> <span data-ttu-id="d40a4-127">この情報を使って、1 つ以上のターゲット オファーをアプリ内購入としてユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="d40a4-127">With this information, you can offer one or more of the targeted offers as an in-app purchase to the user.</span></span>

<span data-ttu-id="d40a4-128">次の例は、現在のユーザーのターゲット オファーを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d40a4-128">The following example demonstrates how to get the targeted offers for the current user.</span></span> <span data-ttu-id="d40a4-129">この例は、[完全な例](#code-example)からの抜粋です。</span><span class="sxs-lookup"><span data-stu-id="d40a4-129">This example is an excerpt from the [complete example](#code-example).</span></span> <span data-ttu-id="d40a4-130">Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリと、完全な例に示されている追加クラスおよび **using** ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="d40a4-130">It requires the [Json.NET](http://www.newtonsoft.com/json) library from Newtonsoft and additional classes and **using** statements that are provided in the complete example.</span></span>

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetTargetedOffers)]

<span id="code-example" />

## <a name="complete-code-example"></a><span data-ttu-id="d40a4-131">完全なコード例</span><span class="sxs-lookup"><span data-stu-id="d40a4-131">Complete code example</span></span>

<span data-ttu-id="d40a4-132">次のコード例は、次のタスクを示しています。</span><span class="sxs-lookup"><span data-stu-id="d40a4-132">The following code example demonstrates the following tasks:</span></span>

* <span data-ttu-id="d40a4-133">現在のユーザーの MSA トークンを取得する。</span><span class="sxs-lookup"><span data-stu-id="d40a4-133">Get an MSA token for the current user.</span></span>
* <span data-ttu-id="d40a4-134">「[ターゲット オファーを取得する](get-targeted-offers.md)」の方法を使って、現在のユーザーのすべてのターゲット オファーを取得する。</span><span class="sxs-lookup"><span data-stu-id="d40a4-134">Get all of the targeted offers for the current user by using the [Get targeted offers](get-targeted-offers.md) method.</span></span>
* <span data-ttu-id="d40a4-135">ターゲット オファーに関連付けられているアドオンを購入する。</span><span class="sxs-lookup"><span data-stu-id="d40a4-135">Purchase the add-on that is associated with a targeted offer.</span></span>

<span data-ttu-id="d40a4-136">この例では、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリが必要です。</span><span class="sxs-lookup"><span data-stu-id="d40a4-136">This example requires the [Json.NET](http://www.newtonsoft.com/json) library from Newtonsoft.</span></span> <span data-ttu-id="d40a4-137">この例では、このライブラリを使って JSON 形式のデータをシリアル化および逆シリアル化します。</span><span class="sxs-lookup"><span data-stu-id="d40a4-137">The example uses this library to serialize and deserialize JSON-formatted data.</span></span>

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetTargetedOffersSample)]

## <a name="related-topics"></a><span data-ttu-id="d40a4-138">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d40a4-138">Related topics</span></span>

* [<span data-ttu-id="d40a4-139">ターゲット オファーによるエンゲージメントとコンバージョンの最大化</span><span class="sxs-lookup"><span data-stu-id="d40a4-139">Use targeted offers to maximize engagement and conversions</span></span>](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)
* [<span data-ttu-id="d40a4-140">ターゲット オファーを取得する</span><span class="sxs-lookup"><span data-stu-id="d40a4-140">Get targeted offers</span></span>](get-targeted-offers.md)
