---
author: Xansky
description: ストア製品向けに Windows.Services.Store 名前空間の拡張 JSON データ スキーマについて説明します。
title: Store 製品のデータ スキーマ
ms.author: mhopkins
ms.date: 09/26/2017
ms.topic: article
keywords: Windows 10, UWP, ExtendedJsonData, Store 製品, スキーマ
ms.localizationpriority: medium
ms.openlocfilehash: 980fde1a222b5fb7ba2d4524469a9b6673cbabd3
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7173383"
---
# <a name="data-schemas-for-store-products"></a><span data-ttu-id="680f3-104">Store 製品のデータ スキーマ</span><span class="sxs-lookup"><span data-stu-id="680f3-104">Data schemas for Store products</span></span>

<span data-ttu-id="680f3-105">アプリやアドオンなどの製品をストアに提出すると、製品とそのライセンスの包括的なデータ セットがストアで管理されます。</span><span class="sxs-lookup"><span data-stu-id="680f3-105">When you submit a product such as an app or add-on to the Store, the Store maintains a comprehensive set of data for the product and its licenses.</span></span> <span data-ttu-id="680f3-106">アプリのコードで [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間のプロパティを使用することで、こうしたデータの一部にプログラムによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="680f3-106">In your app's code, you can programmatically access some of this data by using properties in the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace.</span></span> <span data-ttu-id="680f3-107">たとえば、[StoreProduct.Description](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.Description) プロパティと [StoreProduct.Price](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.Price) プロパティを使用すると、現在のアプリや、現在のアプリのアドオンに関する説明と価格を取得できます。</span><span class="sxs-lookup"><span data-stu-id="680f3-107">For example, you can retrieve the description and price of the current app or an add-on for the current app by using the [StoreProduct.Description](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.Description) and [StoreProduct.Price](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.Price) properties.</span></span>

<span data-ttu-id="680f3-108">ただし、ストア内の製品に関する多くのデータは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の定義済みプロパティを使用することでは公開されません。</span><span class="sxs-lookup"><span data-stu-id="680f3-108">However, much of the data for products in the Store is not exposed by predefined properties in the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace.</span></span> <span data-ttu-id="680f3-109">コードで製品の完全なデータにアクセスするには、代わりに、次の全般的なプロパティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="680f3-109">To access the complete data for a product in your code, you can use the following general properties instead:</span></span>

* [<span data-ttu-id="680f3-110">StoreProduct.ExtendedJsonData</span><span class="sxs-lookup"><span data-stu-id="680f3-110">StoreProduct.ExtendedJsonData</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.ExtendedJsonData)
* [<span data-ttu-id="680f3-111">StoreSku.ExtendedJsonData</span><span class="sxs-lookup"><span data-stu-id="680f3-111">StoreSku.ExtendedJsonData</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.ExtendedJsonData)
* [<span data-ttu-id="680f3-112">StoreAvailability.ExtendedJsonData</span><span class="sxs-lookup"><span data-stu-id="680f3-112">StoreAvailability.ExtendedJsonData</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storeavailability.ExtendedJsonData)
*   [<span data-ttu-id="680f3-113">StoreCollectionData.ExtendedJsonData</span><span class="sxs-lookup"><span data-stu-id="680f3-113">StoreCollectionData.ExtendedJsonData</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storecollectiondata.ExtendedJsonData)
*   [<span data-ttu-id="680f3-114">StoreAppLicense.ExtendedJsonData</span><span class="sxs-lookup"><span data-stu-id="680f3-114">StoreAppLicense.ExtendedJsonData</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense.ExtendedJsonData)
* [<span data-ttu-id="680f3-115">StoreLicense.ExtendedJsonData</span><span class="sxs-lookup"><span data-stu-id="680f3-115">StoreLicense.ExtendedJsonData</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storelicense.ExtendedJsonData)
*   [<span data-ttu-id="680f3-116">StorePurchaseProperties.ExtendedJsonData</span><span class="sxs-lookup"><span data-stu-id="680f3-116">StorePurchaseProperties.ExtendedJsonData</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storepurchaseproperties.ExtendedJsonData)

<span data-ttu-id="680f3-117">これらのプロパティは、対応するオブジェクトの完全なデータを JSON 形式の文字列として返します。</span><span class="sxs-lookup"><span data-stu-id="680f3-117">These properties return the complete data for the corresponding object as a JSON-formatted string.</span></span> <span data-ttu-id="680f3-118">この記事では、これらのプロパティによって返されるデータの完全なスキーマを提供します。</span><span class="sxs-lookup"><span data-stu-id="680f3-118">This article provides the complete schema for the data returned by these properties.</span></span>

> [!NOTE]
> <span data-ttu-id="680f3-119">ストア内の製品は、[製品](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct)オブジェクト、[SKU](https://docs.microsoft.com/uwp/api/windows.services.store.storesku) オブジェクト、および[可用性](https://docs.microsoft.com/uwp/api/windows.services.store.storeavailability)オブジェクトの階層で整理されます。</span><span class="sxs-lookup"><span data-stu-id="680f3-119">Products in the Store are organized in a hierarchy of [product](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct), [SKU](https://docs.microsoft.com/uwp/api/windows.services.store.storesku), and [availability](https://docs.microsoft.com/uwp/api/windows.services.store.storeavailability) objects.</span></span> <span data-ttu-id="680f3-120">詳細については、「[製品、SKU、および可用性](in-app-purchases-and-trials.md#products-skus)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="680f3-120">For more information, see [Products, SKUs, and availabilities](in-app-purchases-and-trials.md#products-skus).</span></span>

## <a name="schema-for-storeproduct-storesku-storeavailability-and-storecollectiondata"></a><span data-ttu-id="680f3-121">StoreProduct、StoreSku、StoreAvailability、および StoreCollectionData のスキーマ</span><span class="sxs-lookup"><span data-stu-id="680f3-121">Schema for StoreProduct, StoreSku, StoreAvailability, and StoreCollectionData</span></span>

<span data-ttu-id="680f3-122">次のスキーマは、[StoreProduct.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.ExtendedJsonData) によって返される JSON 形式の文字列を示しています。</span><span class="sxs-lookup"><span data-stu-id="680f3-122">The following schema describes the JSON-formatted string returned by [StoreProduct.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.ExtendedJsonData).</span></span> <span data-ttu-id="680f3-123">[StoreSku.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.ExtendedJsonData) プロパティ、[StoreAvailability.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeavailability.ExtendedJsonData) プロパティ、および [StoreCollectionData.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storecollectiondata.ExtendedJsonData) プロパティは、```DisplaySkuAvailabilities\Sku```、```DisplaySkuAvailabilities\Availabilities```、および ```DisplaySkuAvailabilities\Sku\CollectionData``` のパスの下でそれぞれ定義されているスキーマの部分だけを返します。</span><span class="sxs-lookup"><span data-stu-id="680f3-123">The [StoreSku.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.ExtendedJsonData), [StoreAvailability.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeavailability.ExtendedJsonData), and [StoreCollectionData.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storecollectiondata.ExtendedJsonData) properties return only the portions of the schema that are defined under the ```DisplaySkuAvailabilities\Sku```, ```DisplaySkuAvailabilities\Availabilities```, and ```DisplaySkuAvailabilities\Sku\CollectionData``` paths, respectively.</span></span>

<span data-ttu-id="680f3-124">[StoreProduct.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.ExtendedJsonData) によって返される JSON 形式の文字列の例については、[このセクション](#product-example)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="680f3-124">For an example of a JSON-formatted string returned by [StoreProduct.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.ExtendedJsonData), see [this section](#product-example).</span></span>

[!code[ExtendedJsonDataSchema](./code/InAppPurchasesAndLicenses_RS1/json/StoreProduct.ExtendedJsonData.json#L1-L729)]

<span id="product-example" />

### <a name="example"></a><span data-ttu-id="680f3-125">例</span><span class="sxs-lookup"><span data-stu-id="680f3-125">Example</span></span>

<span data-ttu-id="680f3-126">次の例は、アプリの [StoreProduct.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.ExtendedJsonData) プロパティによって返される JSON 形式の文字列を示しています。</span><span class="sxs-lookup"><span data-stu-id="680f3-126">The following example demonstrates a JSON-formatted string returned by the [StoreProduct.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.ExtendedJsonData) property for app.</span></span>

[!code[ExtendedJsonDataSchema](./code/InAppPurchasesAndLicenses_RS1/json/StoreProduct.ExtendedJsonDataExample.json#L1-L268)]

## <a name="schema-for-storeapplicense-and-storelicense"></a><span data-ttu-id="680f3-127">StoreAppLicense と StoreLicense のスキーマ</span><span class="sxs-lookup"><span data-stu-id="680f3-127">Schema for StoreAppLicense and StoreLicense</span></span>

<span data-ttu-id="680f3-128">次のスキーマは、[StoreAppLicense.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense.ExtendedJsonData) によって返される JSON 形式の文字列を示しています。</span><span class="sxs-lookup"><span data-stu-id="680f3-128">The following schema describes the JSON-formatted string returned by [StoreAppLicense.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense.ExtendedJsonData).</span></span> <span data-ttu-id="680f3-129">[StoreLicense.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storelicense.ExtendedJsonData) プロパティは、```productAddOns``` パスの下で定義されているスキーマの部分だけを返します。</span><span class="sxs-lookup"><span data-stu-id="680f3-129">The [StoreLicense.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storelicense.ExtendedJsonData) property returns only the portions of the schema that are defined under the ```productAddOns``` path.</span></span>

<span data-ttu-id="680f3-130">[StoreAppLicense.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense.ExtendedJsonData) によって返される JSON 形式の文字列の例については、[このセクション](#license-example)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="680f3-130">For an example of a JSON-formatted string returned by [StoreAppLicense.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense.ExtendedJsonData), see [this section](#license-example).</span></span>

[!code[ExtendedJsonDataSchema](./code/InAppPurchasesAndLicenses_RS1/json/StoreAppLicense.ExtendedJsonData.json#L1-L80)]

<span id="license-example" />

### <a name="example"></a><span data-ttu-id="680f3-131">例</span><span class="sxs-lookup"><span data-stu-id="680f3-131">Example</span></span>

<span data-ttu-id="680f3-132">次の例は、アプリの [StoreAppLicense.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense.ExtendedJsonData) プロパティによって返される JSON 形式の文字列を示しています。</span><span class="sxs-lookup"><span data-stu-id="680f3-132">The following example demonstrates a JSON-formatted string returned by the [StoreAppLicense.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense.ExtendedJsonData) property for app.</span></span>

[!code[ExtendedJsonDataSchema](./code/InAppPurchasesAndLicenses_RS1/json/StoreAppLicense.ExtendedJsonDataExample.json#L1-L28)]

## <a name="schema-for-storepurchaseproperties"></a><span data-ttu-id="680f3-133">StorePurchaseProperties のスキーマ</span><span class="sxs-lookup"><span data-stu-id="680f3-133">Schema for StorePurchaseProperties</span></span>

<span data-ttu-id="680f3-134">次のスキーマは、[StorePurchaseProperties.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storepurchaseproperties.ExtendedJsonData) によって返される JSON 形式の文字列を示しています。</span><span class="sxs-lookup"><span data-stu-id="680f3-134">The following schema describes the JSON-formatted string returned by [StorePurchaseProperties.ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storepurchaseproperties.ExtendedJsonData).</span></span>

[!code[ExtendedJsonDataSchema](./code/InAppPurchasesAndLicenses_RS1/json/StorePurchaseProperties.ExtendedJsonData.json#L1-L12)]

## <a name="related-topics"></a><span data-ttu-id="680f3-135">関連トピック</span><span class="sxs-lookup"><span data-stu-id="680f3-135">Related topics</span></span>

* [<span data-ttu-id="680f3-136">アプリ内購入と試用版</span><span class="sxs-lookup"><span data-stu-id="680f3-136">In-app purchases and trials</span></span>](in-app-purchases-and-trials.md)
* [<span data-ttu-id="680f3-137">アプリとアドオンの製品情報の取得</span><span class="sxs-lookup"><span data-stu-id="680f3-137">Get product info for apps and add-ons</span></span>](get-product-info-for-apps-and-add-ons.md)
* [<span data-ttu-id="680f3-138">アプリとアドオンのライセンス情報の取得</span><span class="sxs-lookup"><span data-stu-id="680f3-138">Get license info for apps and add-ons</span></span>](get-license-info-for-apps-and-add-ons.md)
* [<span data-ttu-id="680f3-139">アプリとアドオンのアプリ内購入の有効化</span><span class="sxs-lookup"><span data-stu-id="680f3-139">Enable in-app purchases of apps and add-ons</span></span>](enable-in-app-purchases-of-apps-and-add-ons.md)
* [<span data-ttu-id="680f3-140">コンシューマブルなアドオン購入の有効化</span><span class="sxs-lookup"><span data-stu-id="680f3-140">Enable consumable add-on purchases</span></span>](enable-consumable-add-on-purchases.md)
* [<span data-ttu-id="680f3-141">アプリの試用版の実装</span><span class="sxs-lookup"><span data-stu-id="680f3-141">Implement a trial version of your app</span></span>](implement-a-trial-version-of-your-app.md)
