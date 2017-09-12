---
author: mcleanbyron
Description: "ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。"
title: "コンシューマブルなアプリ内製品購入の有効化"
ms.assetid: F79EE369-ACFC-4156-AF6A-72D1C7D3BDA4
keywords: "UWP, コンシューマブル, アドオン, アプリ内購入, IAP, Windows.ApplicationModel.Store"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 9190000a2c5a35a0b7125429a19e4743b388d503
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="enable-consumable-in-app-product-purchases"></a><span data-ttu-id="c7574-104">コンシューマブルなアプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="c7574-104">Enable consumable in-app product purchases</span></span>


> [!NOTE]
> <span data-ttu-id="c7574-105">この記事では、[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーの使用方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c7574-105">This article demonstrates how to use members of the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace.</span></span> <span data-ttu-id="c7574-106">アプリが Windows 10 Version 1607 以降を対象としている場合、**Windows.ApplicationModel.Store** 名前空間ではなく、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間のメンバーを使ってアドオンを管理することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c7574-106">If your app targets Windows 10, version 1607, or later, we recommend that you use members of the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace to manage add-ons instead of the **Windows.ApplicationModel.Store** namespace.</span></span> <span data-ttu-id="c7574-107">詳しくは、[この記事](enable-consumable-add-on-purchases.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7574-107">For more information, see [this article](enable-consumable-add-on-purchases.md).</span></span>

<span data-ttu-id="c7574-108">ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。</span><span class="sxs-lookup"><span data-stu-id="c7574-108">Offer consumable in-app products—items that can be purchased, used, and purchased again—through the Store commerce platform to provide your customers with a purchase experience that is both robust and reliable.</span></span> <span data-ttu-id="c7574-109">これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="c7574-109">This is especially useful for things like in-game currency (gold, coins, etc.) that can be purchased and then used to purchase specific power-ups.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="c7574-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="c7574-110">Prerequisites</span></span>

-   <span data-ttu-id="c7574-111">このトピックでは、コンシューマブルなアプリ内製品の購入とフルフィルメントの完了報告について説明します。</span><span class="sxs-lookup"><span data-stu-id="c7574-111">This topic covers the purchase and fulfillment reporting of consumable in-app products.</span></span> <span data-ttu-id="c7574-112">アプリ内製品に詳しくない場合は、「[アプリ内製品購入の有効化](enable-in-app-product-purchases.md)」を読んで、ライセンス情報と、ストアでアプリ内製品を適切に一覧表示する方法を確かめてください。</span><span class="sxs-lookup"><span data-stu-id="c7574-112">If you are unfamiliar with in-app products, please review [Enable in-app product purchases](enable-in-app-product-purchases.md) to learn about license information, and how to properly list in-app products in the Store.</span></span>
-   <span data-ttu-id="c7574-113">新しいアプリ内製品のコード記述やテストを初めて行うときは、[CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) オブジェクトではなく、[CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) オブジェクトを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7574-113">When you code and test new in-app products for the first time, you must use the [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) object instead of the [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) object.</span></span> <span data-ttu-id="c7574-114">そうすることで、実稼働サーバーを呼び出すのではなく、ライセンス サーバーへのシミュレートされた呼び出しを使って、ライセンス ロジックを検証できます。</span><span class="sxs-lookup"><span data-stu-id="c7574-114">This way you can verify your license logic using simulated calls to the license server instead of calling the live server.</span></span> <span data-ttu-id="c7574-115">そのためには、%userprofile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData で WindowsStoreProxy.xml という名前のファイルをカスタマイズする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7574-115">To do this, you need to customize the file named WindowsStoreProxy.xml in %userprofile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData.</span></span> <span data-ttu-id="c7574-116">このファイルは、アプリを初めて実行するときに Microsoft Visual Studio シミュレーターによって作られます。カスタマイズされたファイルを実行時に読み込むこともできます。</span><span class="sxs-lookup"><span data-stu-id="c7574-116">The Microsoft Visual Studio simulator creates this file when you run your app for the first time—or you can also load a custom one at runtime.</span></span> <span data-ttu-id="c7574-117">詳しくは、「[CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#proxy)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7574-117">For more info, see [Using the WindowsStoreProxy.xml file with CurrentAppSimulator](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#proxy).</span></span>
-   <span data-ttu-id="c7574-118">このトピックでは、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)で提供されているコード例も参照します。</span><span class="sxs-lookup"><span data-stu-id="c7574-118">This topic also references code examples provided in the [Store sample](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store).</span></span> <span data-ttu-id="c7574-119">このサンプルを利用すると、ユニバーサル Windows プラットフォーム (UWP) アプリに提供されるさまざまな収益化オプションを体験できます。</span><span class="sxs-lookup"><span data-stu-id="c7574-119">This sample is a great way to get hands-on experience with the different monetization options provided for Universal Windows Platform (UWP) apps.</span></span>

## <a name="step-1-making-the-purchase-request"></a><span data-ttu-id="c7574-120">手順 1: 購入要求の作成</span><span class="sxs-lookup"><span data-stu-id="c7574-120">Step 1: Making the purchase request</span></span>

<span data-ttu-id="c7574-121">最初の購買要求は、ストアを通じて行われた他の購入と同様に、[RequestProductPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/dn263381) を使って行います。</span><span class="sxs-lookup"><span data-stu-id="c7574-121">The initial purchase request is made with [RequestProductPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/dn263381) like any other purchase made through the Store.</span></span> <span data-ttu-id="c7574-122">コンシューマブルなアプリ内製品に関する違いとして、購入が成功した後、その購入に対するフルフィルメントが正常に完了したことをアプリがストアに通知するまで、顧客は同じ製品をもう一度購入することができません。</span><span class="sxs-lookup"><span data-stu-id="c7574-122">The difference for consumable in-app products is that after a successful purchase, a customer cannot purchase the same product again until the app has notified the Store that the previous purchase was successfully fulfilled.</span></span> <span data-ttu-id="c7574-123">アプリは、購入されたコンシューマブルのフルフィルメントを処理し、ストアにフルフィルメントの完了を通知する責任を負います。</span><span class="sxs-lookup"><span data-stu-id="c7574-123">It's your app's responsibility to fulfill purchased consumables and notify the Store of the fulfillment.</span></span>

<span data-ttu-id="c7574-124">次の例は、コンシューマブルなアプリ内製品の購入要求を示しています。</span><span class="sxs-lookup"><span data-stu-id="c7574-124">The following example shows a consumable in-app product purchase request.</span></span> <span data-ttu-id="c7574-125">コードのコメントに、購入要求が成功した場合と同じ製品の購入のフルフィルメントが完了していないことが原因で購入要求が成功しなかった場合の 2 つの異なるシナリオについて、アプリがコンシューマブルなアプリ内製品のローカル フルフィルメントをいつ完了する必要があるかが示されています。</span><span class="sxs-lookup"><span data-stu-id="c7574-125">You'll notice code comments indicating when your app should conduct its local fulfillment of the consumable in-app product for two different scenarios—when the request is successful, and when the request is not successful because of an unfulfilled purchase of that same product.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="c7574-126">EnableConsumablePurchases</span><span class="sxs-lookup"><span data-stu-id="c7574-126">EnableConsumablePurchases</span></span>](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#MakePurchaseRequest)]

## <a name="step-2-tracking-local-fulfillment-of-the-consumable"></a><span data-ttu-id="c7574-127">手順 2: コンシューマブルのローカル フルフィルメントの実行</span><span class="sxs-lookup"><span data-stu-id="c7574-127">Step 2: Tracking local fulfillment of the consumable</span></span>

<span data-ttu-id="c7574-128">コンシューマブルなアプリ内製品へのアクセスを顧客に許可するとき、フルフィルメントの対象になっている製品 (*productId*) と、フルフィルメントが関連付けられているトランザクション (*transactionId*) を追跡することが重要です。</span><span class="sxs-lookup"><span data-stu-id="c7574-128">When granting your customer access to the consumable in-app product, it's important to keep track of which product is fulfilled (*productId*), and which transaction that fulfillment is associated with (*transactionId*).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c7574-129">アプリは、ストアにフルフィルメントの完了を正確に報告する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7574-129">Your app is responsible for the accurately reporting fulfillment to the Store.</span></span> <span data-ttu-id="c7574-130">この手順は、顧客が体験する公正で信頼できる購入エクスペリエンスを維持するために必要です。</span><span class="sxs-lookup"><span data-stu-id="c7574-130">This step is essential to maintaining a fair and reliable purchase experience for your customers.</span></span>

<span data-ttu-id="c7574-131">次の例では、前の手順の [RequestProductPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/dn263381) 呼び出しの PurchaseResults [](https://msdn.microsoft.com/library/windows/apps/dn263392)プロパティを使って、フルフィルメントの対象となる、購入された製品を識別しています。</span><span class="sxs-lookup"><span data-stu-id="c7574-131">The following example demonstrates use of the [PurchaseResults](https://msdn.microsoft.com/library/windows/apps/dn263392) properties from the [RequestProductPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/dn263381) call in the previous step to identify the purchased product for fulfillment.</span></span> <span data-ttu-id="c7574-132">ローカル フルフィルメントが成功したことを確かめるために、コレクションを使って後で参照できる場所に製品情報が保存されます。</span><span class="sxs-lookup"><span data-stu-id="c7574-132">A collection is used to store the product information in a location that can later be referenced to confirm that local fulfillment was successful.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="c7574-133">EnableConsumablePurchases</span><span class="sxs-lookup"><span data-stu-id="c7574-133">EnableConsumablePurchases</span></span>](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#GrantFeatureLocally)]

<span data-ttu-id="c7574-134">次の例では、前の例の配列を使って、後でストアにフルフィルメントを報告するときに使われる製品 ID とトランザクション ID のペアにアクセスする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c7574-134">This next example shows how to use the array from the previous example to access product ID/transaction ID pairs that are later used when reporting fulfillment to the Store.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c7574-135">フルフィルメントの追跡と確認のために使っている方法を問わず、アプリは、顧客が受け取っていないアイテムに対して課金されることのないように適正評価を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7574-135">Whatever methodology your app uses to track and confirm fulfillment, your app must demonstrate due diligence to ensure that your customers are not charged for items they haven't received.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="c7574-136">EnableConsumablePurchases</span><span class="sxs-lookup"><span data-stu-id="c7574-136">EnableConsumablePurchases</span></span>](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#IsLocallyFulfilled)]

## <a name="step-3-reporting-product-fulfillment-to-the-store"></a><span data-ttu-id="c7574-137">手順 3: ストアへの製品フルフィルメントの報告</span><span class="sxs-lookup"><span data-stu-id="c7574-137">Step 3: Reporting product fulfillment to the Store</span></span>

<span data-ttu-id="c7574-138">ローカル フルフィルメントが完了した後、アプリは、*productId* と製品購入が含まれるトランザクションを含む [ReportConsumableFulfillmentAsync](https://msdn.microsoft.com/library/windows/apps/dn263380) 呼び出しを行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7574-138">After local fulfillment is completed, your app must make a [ReportConsumableFulfillmentAsync](https://msdn.microsoft.com/library/windows/apps/dn263380) call that includes the *productId* and the transaction the product purchase is included in.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c7574-139">フルフィルメントが完了したコンシューマブルなアプリ内製品をストアに報告しなかった場合、ユーザーは、前回の購入のフルフィルメントが報告されるまで、その製品をもう一度購入することができなくなります。</span><span class="sxs-lookup"><span data-stu-id="c7574-139">Failure to report fulfilled consumable in-app products to the Store will result in the user being unable to purchase that product again until fulfillment for the previous purchase is reported.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="c7574-140">EnableConsumablePurchases</span><span class="sxs-lookup"><span data-stu-id="c7574-140">EnableConsumablePurchases</span></span>](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#ReportFulfillment)]

## <a name="step-4-identifying-unfulfilled-purchases"></a><span data-ttu-id="c7574-141">手順 4: フルフィルメントが未完了の購入の識別</span><span class="sxs-lookup"><span data-stu-id="c7574-141">Step 4: Identifying unfulfilled purchases</span></span>

<span data-ttu-id="c7574-142">アプリでは、[GetUnfulfilledConsumablesAsync](https://msdn.microsoft.com/library/windows/apps/dn263379) メソッドを使って、コンシューマブルなアプリ内製品に対するフルフィルメントの未完了をいつでも確認することができます。</span><span class="sxs-lookup"><span data-stu-id="c7574-142">Your app can use the [GetUnfulfilledConsumablesAsync](https://msdn.microsoft.com/library/windows/apps/dn263379) method to check for unfulfilled consumable in-app products at any time.</span></span> <span data-ttu-id="c7574-143">このメソッドは、ネットワーク接続の中断やアプリの終了など、予期しないアプリのイベントが原因でフルフィルメントが完了していないコンシューマブルを調べるために、定期的に呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7574-143">This method should be called on a regular basis to check for unfulfilled consumables that exist due to unanticipated app events like an interruption in network connectivity or app termination.</span></span>

<span data-ttu-id="c7574-144">次の例に、[GetUnfulfilledConsumablesAsync](https://msdn.microsoft.com/library/windows/apps/dn263379) を使ってフルフィルメントが未完了のコンシューマブルを列挙する方法と、アプリでこの一覧を反復処理してローカル フルフィルメントを完了する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c7574-144">The following example demonstrates how [GetUnfulfilledConsumablesAsync](https://msdn.microsoft.com/library/windows/apps/dn263379) can be used to enumerate unfulfilled consumables, and how your app can iterate through this list to complete local fulfillment.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="c7574-145">EnableConsumablePurchases</span><span class="sxs-lookup"><span data-stu-id="c7574-145">EnableConsumablePurchases</span></span>](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#GetUnfulfilledConsumables)]

## <a name="related-topics"></a><span data-ttu-id="c7574-146">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c7574-146">Related topics</span></span>

* [<span data-ttu-id="c7574-147">アプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="c7574-147">Enable in-app product purchases</span></span>](enable-in-app-product-purchases.md)
* [<span data-ttu-id="c7574-148">ストア サンプル (試用版とアプリ内購入のデモンストレーション)</span><span class="sxs-lookup"><span data-stu-id="c7574-148">Store sample (demonstrates trials and in-app purchases)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)
* [<span data-ttu-id="c7574-149">Windows.ApplicationModel.Store</span><span class="sxs-lookup"><span data-stu-id="c7574-149">Windows.ApplicationModel.Store</span></span>](https://msdn.microsoft.com/library/windows/apps/br225197)
 

 
