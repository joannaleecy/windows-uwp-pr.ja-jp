---
Description: Whether your app is free or not, you can sell content, other apps, or new app functionality (such as unlocking the next level of a game) from right within the app. Here we show you how to enable these products in your app.
title: アプリ内製品購入の有効化
ms.assetid: D158E9EB-1907-4173-9889-66507957BD6B
keywords: UWP, アドオン, アプリ内購入, IAP, Windows.ApplicationModel.Store
ms.date: 08/25/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a203ef79fc6ebb45107cd9ac9d79cadf330f7a5d
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8784890"
---
# <a name="enable-in-app-product-purchases"></a><span data-ttu-id="428ec-103">アプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="428ec-103">Enable in-app product purchases</span></span>

<span data-ttu-id="428ec-104">アプリが無料であるかどうかにかかわらず、コンテンツ、その他のアプリ、アプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。</span><span class="sxs-lookup"><span data-stu-id="428ec-104">Whether your app is free or not, you can sell content, other apps, or new app functionality (such as unlocking the next level of a game) from right within the app.</span></span> <span data-ttu-id="428ec-105">ここでは、アプリ内で製品を販売できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="428ec-105">Here we show you how to enable these products in your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="428ec-106">この記事では、[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーを使って、アプリ内製品の購入を有効化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="428ec-106">This article demonstrates how to use members of the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace to enable in-app product purchases.</span></span> <span data-ttu-id="428ec-107">この名前空間は更新されなくなり、新機能も追加されないため、代わりに [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="428ec-107">This namespace is no longer being updated with new features, and we recommend that you use the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace instead.</span></span> <span data-ttu-id="428ec-108">**Windows.Services.Store**名前空間では、ストアで管理されるコンシューマブルなアドオンやサブスクリプションなどの最新のアドオンの種類をサポートし、今後の製品とパートナー センターとストアでサポートされる機能の種類に対応するのには設計されています。</span><span class="sxs-lookup"><span data-stu-id="428ec-108">The **Windows.Services.Store** namespace supports the latest add-on types, such as Store-managed consumable add-ons and subscriptions, and is designed to be compatible with future types of products and features supported by Partner Center and the Store.</span></span> <span data-ttu-id="428ec-109">**Windows.Services.Store** 名前空間は、Windows 10 バージョン 1607 で導入され、Visual Studio で、**Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするプロジェクトでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="428ec-109">The **Windows.Services.Store** namespace was introduced in Windows 10, version 1607, and it can only be used in projects that target **Windows 10 Anniversary Edition (10.0; Build 14393)** or a later release in Visual Studio.</span></span> <span data-ttu-id="428ec-110">**Windows.Services.Store**名前空間を使用してアプリ内製品購入の有効化についての詳細については、[この記事](enable-in-app-purchases-of-apps-and-add-ons.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="428ec-110">For more information about enabling in-app product purchases using the **Windows.Services.Store** namespace, see [this article](enable-in-app-purchases-of-apps-and-add-ons.md).</span></span>

> [!NOTE]
> <span data-ttu-id="428ec-111">アプリ内製品は、アプリの試用版では提供できません。</span><span class="sxs-lookup"><span data-stu-id="428ec-111">In-app products cannot be offered from a trial version of an app.</span></span> <span data-ttu-id="428ec-112">アプリの試用版を使用中のユーザーがアプリ内製品を購入できるのは、通常版のアプリを購入する場合のみです。</span><span class="sxs-lookup"><span data-stu-id="428ec-112">Customers using a trial version of your app can only buy an in-app product if they purchase a full version of your app.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="428ec-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="428ec-113">Prerequisites</span></span>

-   <span data-ttu-id="428ec-114">ユーザーが購入できる機能を追加する Windows アプリ。</span><span class="sxs-lookup"><span data-stu-id="428ec-114">A Windows app in which to add features for customers to buy.</span></span>
-   <span data-ttu-id="428ec-115">新しいアプリ内製品のコード記述やテストを初めて行うときは、[CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) オブジェクトではなく、[CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) オブジェクトを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="428ec-115">When you code and test new in-app products for the first time, you must use the [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) object instead of the [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) object.</span></span> <span data-ttu-id="428ec-116">そうすることで、実稼働サーバーを呼び出すのではなく、ライセンス サーバーへのシミュレートされた呼び出しを使って、ライセンス ロジックを検証できます。</span><span class="sxs-lookup"><span data-stu-id="428ec-116">This way you can verify your license logic using simulated calls to the license server instead of calling the live server.</span></span> <span data-ttu-id="428ec-117">そのためには、%userprofile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData で WindowsStoreProxy.xml という名前のファイルをカスタマイズする必要があります。</span><span class="sxs-lookup"><span data-stu-id="428ec-117">To do this, you need to customize the file named WindowsStoreProxy.xml in %userprofile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData.</span></span> <span data-ttu-id="428ec-118">このファイルは、アプリを初めて実行するときに Microsoft Visual Studio シミュレーターによって作られます。カスタマイズされたファイルを実行時に読み込むこともできます。</span><span class="sxs-lookup"><span data-stu-id="428ec-118">The Microsoft Visual Studio simulator creates this file when you run your app for the first time—or you can also load a custom one at runtime.</span></span> <span data-ttu-id="428ec-119">詳しくは、「[CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#proxy)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="428ec-119">For more info, see [Using the WindowsStoreProxy.xml file with CurrentAppSimulator](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#proxy).</span></span>
-   <span data-ttu-id="428ec-120">このトピックでは、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)で提供されているコード例も参照します。</span><span class="sxs-lookup"><span data-stu-id="428ec-120">This topic also references code examples provided in the [Store sample](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store).</span></span> <span data-ttu-id="428ec-121">このサンプルを利用すると、ユニバーサル Windows プラットフォーム (UWP) アプリに提供されるさまざまな収益化オプションを体験できます。</span><span class="sxs-lookup"><span data-stu-id="428ec-121">This sample is a great way to get hands-on experience with the different monetization options provided for Universal Windows Platform (UWP) apps.</span></span>

## <a name="step-1-initialize-the-license-info-for-your-app"></a><span data-ttu-id="428ec-122">手順 1: アプリのライセンス情報を初期化する</span><span class="sxs-lookup"><span data-stu-id="428ec-122">Step 1: Initialize the license info for your app</span></span>

<span data-ttu-id="428ec-123">アプリを初期化するときに、[CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) または [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) を初期化することで、アプリの [LicenseInformation](https://msdn.microsoft.com/library/windows/apps/br225157) オブジェクトを取得し、アプリ内製品の購入を有効にします。</span><span class="sxs-lookup"><span data-stu-id="428ec-123">When your app is initializing, get the [LicenseInformation](https://msdn.microsoft.com/library/windows/apps/br225157) object for your app by initializing the [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) or [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) to enable purchases of an in-app product.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnableInAppPurchases](./code/InAppPurchasesAndLicenses/cs/EnableInAppPurchases.cs#InitializeLicenseTest)]

## <a name="step-2-add-the-in-app-offers-to-your-app"></a><span data-ttu-id="428ec-124">手順 2: アプリにアプリ内製品の販売を追加する</span><span class="sxs-lookup"><span data-stu-id="428ec-124">Step 2: Add the in-app offers to your app</span></span>

<span data-ttu-id="428ec-125">アプリ内製品によって提供する機能ごとに、販売を作り、アプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="428ec-125">For each feature that you want to make available through an in-app product, create an offer and add it to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="428ec-126">ストアにアプリを提出する前に、ユーザーに提供するすべてのアプリ内製品をアプリに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="428ec-126">You must add all the in-app products that you want to present to your customers to your app before you submit it to the Store.</span></span> <span data-ttu-id="428ec-127">新しいアプリ内製品を後から追加する場合は、アプリを更新し、新しいバージョンを再提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="428ec-127">If you want to add new in-app products later, you must update your app and re-submit a new version.</span></span>

1.  **<span data-ttu-id="428ec-128">アプリ内販売トークンを作成する</span><span class="sxs-lookup"><span data-stu-id="428ec-128">Create an in-app offer token</span></span>**

    <span data-ttu-id="428ec-129">アプリの各アプリ内製品は、トークンで識別します。</span><span class="sxs-lookup"><span data-stu-id="428ec-129">You identify each in-app product in your app by a token.</span></span> <span data-ttu-id="428ec-130">このトークンは開発者が定義する文字列であり、アプリ内とストア内で、特定のアプリ内製品を識別するために使われます。</span><span class="sxs-lookup"><span data-stu-id="428ec-130">This token is a string that you define and use in your app and in the Store to identify a specific in-app product.</span></span> <span data-ttu-id="428ec-131">アプリに固有のわかりやすい名前を付けて、その機能をコードの記述中に簡単に識別できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="428ec-131">Give it a unique (to your app) and meaningful name so that you can quickly identify the correct feature it represents while you are coding.</span></span> <span data-ttu-id="428ec-132">たとえば、次のような名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="428ec-132">Here are some examples of names:</span></span>

    * <span data-ttu-id="428ec-133">"SpaceMissionLevel4"</span><span class="sxs-lookup"><span data-stu-id="428ec-133">"SpaceMissionLevel4"</span></span>
    * <span data-ttu-id="428ec-134">"ContosoCloudSave"</span><span class="sxs-lookup"><span data-stu-id="428ec-134">"ContosoCloudSave"</span></span>
    * <span data-ttu-id="428ec-135">"RainbowThemePack"</span><span class="sxs-lookup"><span data-stu-id="428ec-135">"RainbowThemePack"</span></span>

  > [!NOTE]
  > <span data-ttu-id="428ec-136">コードで使用するアプリ内販売トークンはときに指定する[製品 ID](../publish/set-your-add-on-product-id.md#product-id)値と一致する必要があります[パートナー センターでのアプリの対応するアドオンを定義](../publish/add-on-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="428ec-136">The in-app offer token that you use in your code must match the [product ID](../publish/set-your-add-on-product-id.md#product-id) value you specify when you [define the corresponding add-on for your app in Partner Center](../publish/add-on-submissions.md).</span></span>

2.  **<span data-ttu-id="428ec-137">条件ブロック内に機能のコードを記述する</span><span class="sxs-lookup"><span data-stu-id="428ec-137">Code the feature in a conditional block</span></span>**

    <span data-ttu-id="428ec-138">アプリ内製品の対象となる各機能のコードは、その機能を使うためのライセンスをユーザーが持っているかどうかをテストする条件ブロック内に記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="428ec-138">You must put the code for each feature that is associated with an in-app product in a conditional block that tests to see if the customer has a license to use that feature.</span></span>

    <span data-ttu-id="428ec-139">次の例は、ライセンス固有の条件ブロック内に **featureName** という名前の製品機能のコードを記述する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="428ec-139">Here's an example that shows how you can code a product feature named **featureName** in a license-specific conditional block.</span></span> <span data-ttu-id="428ec-140">**featureName** という文字列は、アプリ内でこの製品を一意に識別するトークンであり、ストアでも識別用に使われます。</span><span class="sxs-lookup"><span data-stu-id="428ec-140">The string, **featureName**,is the token that uniquely identifies this product within the app and is also used to identify it in the Store.</span></span>

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[EnableInAppPurchases](./code/InAppPurchasesAndLicenses/cs/EnableInAppPurchases.cs#CodeFeature)]

3.  **<span data-ttu-id="428ec-141">この機能の購入 UI を追加する</span><span class="sxs-lookup"><span data-stu-id="428ec-141">Add the purchase UI for this feature</span></span>**

    <span data-ttu-id="428ec-142">アプリには、アプリ内製品で提供される製品または機能をユーザーが購入するための方法も用意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="428ec-142">Your app must also provide a way for your customers to purchase the product or feature offered by the in-app product.</span></span> <span data-ttu-id="428ec-143">ユーザーは、完全なアプリを購入したときのように、ストアを通じてそれらの製品または機能を購入することはできません。</span><span class="sxs-lookup"><span data-stu-id="428ec-143">They can't purchase them through the Store in the same way they purchased the full app.</span></span>

    <span data-ttu-id="428ec-144">次の例は、ユーザーが既にアプリ内製品を所有しているかどうかをテストし、所有していない場合は購入できるように購入用ダイアログを表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="428ec-144">Here's how to test to see if your customer already owns an in-app product and, if they don't, displays the purchase dialog so they can buy it.</span></span> <span data-ttu-id="428ec-145">"show the purchase dialog" というコメントを、購入用ダイアログの独自のコードに置き換えてください (わかりやすい [このアプリを購入] </span><span class="sxs-lookup"><span data-stu-id="428ec-145">Replace the comment "show the purchase dialog" with your custom code for the purchase dialog (such as a page with a friendly "Buy this app!"</span></span> <span data-ttu-id="428ec-146">ボタンのあるページなど)。</span><span class="sxs-lookup"><span data-stu-id="428ec-146">button).</span></span>

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[EnableInAppPurchases](./code/InAppPurchasesAndLicenses/cs/EnableInAppPurchases.cs#BuyFeature)]

## <a name="step-3-change-the-test-code-to-the-final-calls"></a><span data-ttu-id="428ec-147">手順 3: テスト コードを最終的な呼び出しに変更する</span><span class="sxs-lookup"><span data-stu-id="428ec-147">Step 3: Change the test code to the final calls</span></span>

<span data-ttu-id="428ec-148">この手順は簡単です。アプリのコード内の [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) への参照をすべて [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) への参照に変えます。</span><span class="sxs-lookup"><span data-stu-id="428ec-148">This is an easy step: change every reference to [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) to [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) in your app's code.</span></span> <span data-ttu-id="428ec-149">WindowsStoreProxy.xml ファイルは不要になるので、アプリのパスから削除します (ただし、次の手順でアプリ内販売を構成するときの参照用に保存しておくことをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="428ec-149">You don't need to provide the WindowsStoreProxy.xml file any longer, so remove it from your app's path (although you may want to save it for reference when you configure the in-app offer in the next step).</span></span>

## <a name="step-4-configure-the-in-app-product-offer-in-the-store"></a><span data-ttu-id="428ec-150">手順 4: ストアでアプリ内製品を構成する</span><span class="sxs-lookup"><span data-stu-id="428ec-150">Step 4: Configure the in-app product offer in the Store</span></span>

<span data-ttu-id="428ec-151">パートナー センターで、アプリと[アドオンを作成](../publish/add-on-submissions.md)するアプリ内製品と一致に移動します。</span><span class="sxs-lookup"><span data-stu-id="428ec-151">In Partner Center, navigate to your app and [create an add-on](../publish/add-on-submissions.md) that matches your in-app product offer.</span></span> <span data-ttu-id="428ec-152">アドオンの製品 ID、種類、価格などのプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="428ec-152">Define the product ID, type, price, and other properties for your add-on.</span></span> <span data-ttu-id="428ec-153">テストのときに WindowsStoreProxy.xml で設定した構成と同じ構成になっていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="428ec-153">Make sure that you configure it identically to the configuration you set in WindowsStoreProxy.xml when testing.</span></span>

  > [!NOTE]
  > <span data-ttu-id="428ec-154">コードで使用するアプリ内販売トークンは、パートナー センターで対応するアドオンに対して指定した[製品 ID](../publish/set-your-add-on-product-id.md#product-id)の値と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="428ec-154">The in-app offer token that you use in your code must match the [product ID](../publish/set-your-add-on-product-id.md#product-id) value you specify for the corresponding add-on in Partner Center.</span></span>

## <a name="remarks"></a><span data-ttu-id="428ec-155">注釈</span><span class="sxs-lookup"><span data-stu-id="428ec-155">Remarks</span></span>

<span data-ttu-id="428ec-156">コンシューマブルなアプリ内購入オプション (購入して使い切った後、必要に応じて再購入できる項目) を顧客に提供することに関心がある場合は、「[コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="428ec-156">If you're interested in providing your customers with consumable in-app product options (items that can be purchased, used up, and then purchased again if desired), move on to the [Enable consumable in-app product purchases](enable-consumable-in-app-product-purchases.md) topic.</span></span>

<span data-ttu-id="428ec-157">ユーザーがアプリ内購入を行ったことを確認するために通知を使う必要がある場合は、「[受領通知を使った製品購入の確認](use-receipts-to-verify-product-purchases.md)」を確認してください。</span><span class="sxs-lookup"><span data-stu-id="428ec-157">If you need to use receipts to verify that user made an in-app purchase, be sure to review [Use receipts to verify product purchases](use-receipts-to-verify-product-purchases.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="428ec-158">関連トピック</span><span class="sxs-lookup"><span data-stu-id="428ec-158">Related topics</span></span>


* [<span data-ttu-id="428ec-159">コンシューマブルなアプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="428ec-159">Enable consumable in-app product purchases</span></span>](enable-consumable-in-app-product-purchases.md)
* [<span data-ttu-id="428ec-160">アプリ内製品の大規模なカタログの管理</span><span class="sxs-lookup"><span data-stu-id="428ec-160">Manage a large catalog of in-app products</span></span>](manage-a-large-catalog-of-in-app-products.md)
* [<span data-ttu-id="428ec-161">受領通知を使った製品購入の確認</span><span class="sxs-lookup"><span data-stu-id="428ec-161">Use receipts to verify product purchases</span></span>](use-receipts-to-verify-product-purchases.md)
* [<span data-ttu-id="428ec-162">ストア サンプル (試用版とアプリ内購入のデモンストレーション)</span><span class="sxs-lookup"><span data-stu-id="428ec-162">Store sample (demonstrates trials and in-app purchases)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)
