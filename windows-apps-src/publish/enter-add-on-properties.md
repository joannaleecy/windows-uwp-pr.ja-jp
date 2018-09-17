---
author: jnHs
Description: When submitting an add-on, the options on the Properties page help determine the behavior of your add-on when offered to customers.
title: アドオン プロパティの入力
ms.assetid: 26D2139F-66FD-479E-940B-7491238ADCAE
ms.author: wdg-dev-content
ms.date: 01/12/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アドオン, プロパティ, サブスクリプション期間, 製品の有効期間, コンテンツの種類, iap, アプリ内購入, アプリ内製品
ms.localizationpriority: medium
ms.openlocfilehash: 73a494ea1899f3a764a668ae61c1235808eff1a7
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3989349"
---
# <a name="enter-add-on-properties"></a><span data-ttu-id="9d26a-103">アドオン プロパティの入力</span><span class="sxs-lookup"><span data-stu-id="9d26a-103">Enter add-on properties</span></span>


<span data-ttu-id="9d26a-104">アドオンを提出するとき、**[プロパティ]** ページのオプションは、ユーザーに提供される場合のアドオン動作を決めるのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-104">When submitting an add-on, the options on the **Properties** page help determine the behavior of your add-on when offered to customers.</span></span>

## <a name="product-type"></a><span data-ttu-id="9d26a-105">製品の種類</span><span class="sxs-lookup"><span data-stu-id="9d26a-105">Product type</span></span>

<span data-ttu-id="9d26a-106">最初に[アドオンを作成する](set-your-add-on-product-id.md)ときに、製品の種類を選びます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-106">Your product type is selected when you first [create the add-on](set-your-add-on-product-id.md).</span></span> <span data-ttu-id="9d26a-107">ここには、選んだ製品の種類が表示されますが、変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="9d26a-107">The product type you selected is displayed here, but you can't change it.</span></span>

> [!TIP]
> <span data-ttu-id="9d26a-108">アドオンを公開しておらず、別の製品の種類を選ぶ必要がある場合は、申請を削除して、もう一度選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-108">If you haven't published the add-on, you can delete the submission and start again if you want to choose a different product type.</span></span>

<span data-ttu-id="9d26a-109">このページに表示されるフィールドは、アドオンの製品の種類に応じて変化します。</span><span class="sxs-lookup"><span data-stu-id="9d26a-109">The fields you see on this page will vary, depending on the product type of your add-on.</span></span>


## <a name="product-lifetime"></a><span data-ttu-id="9d26a-110">製品の有効期限</span><span class="sxs-lookup"><span data-stu-id="9d26a-110">Product lifetime</span></span>

<span data-ttu-id="9d26a-111">製品の種類として **[永続的]** を選んだ場合、**[製品の有効期限]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-111">If you selected **Durable** for your product type, **Product lifetime** is shown here.</span></span> <span data-ttu-id="9d26a-112">永続的なアドオンの **[製品の有効期限]** の既定値は、**[無期限]** です。つまり、アドオンの期限は切れません。</span><span class="sxs-lookup"><span data-stu-id="9d26a-112">The default **Product lifetime** for a durable add-on is **Forever**, which means the add-on never expires.</span></span> <span data-ttu-id="9d26a-113">必要に応じて、設定した期間の後でアドオンの期限が切れるように **[製品の有効期限]** を設定できます (1 から 365 日間のオプションがあります)。</span><span class="sxs-lookup"><span data-stu-id="9d26a-113">If you prefer, you can set the **Product lifetime** so that the add-on expires after a set duration (with options from 1-365 days).</span></span>


## <a name="quantity"></a><span data-ttu-id="9d26a-114">数量</span><span class="sxs-lookup"><span data-stu-id="9d26a-114">Quantity</span></span>

<span data-ttu-id="9d26a-115">製品の種類に **[ストアで管理されるコンシューマブル]** を選択した場合、**[数量]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-115">If you selected **Store-managed consumable** for your product type, **Quantity** is shown here.</span></span> <span data-ttu-id="9d26a-116">1 ~ 1000000 の範囲の数値を入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d26a-116">You'll need to enter a number between 1 and 1000000.</span></span> <span data-ttu-id="9d26a-117">顧客が対象アドオンを入手するときにこの数量が付与されます。顧客によるアドオンの消費がアプリによって報告されるたびに、ストアが残量を追跡します。</span><span class="sxs-lookup"><span data-stu-id="9d26a-117">This quantity will be granted to the customer when they acquire your add-on, and the Store will track the balance as the app reports the customer’s consumption of the add-on.</span></span>


## <a name="subscription-period"></a><span data-ttu-id="9d26a-118">サブスクリプション期間</span><span class="sxs-lookup"><span data-stu-id="9d26a-118">Subscription period</span></span>

<span data-ttu-id="9d26a-119">製品の種類として **[サブスクリプション]** を選んだ場合、**[サブスクリプション期間]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-119">If you selected **Subscription** for your product type, **Subscription period** is shown here.</span></span> <span data-ttu-id="9d26a-120">サブスクリプション料を課金する頻度を指定するオプションを選びす。</span><span class="sxs-lookup"><span data-stu-id="9d26a-120">Choose an option to specify how frequently a customer will be charged for the subscription.</span></span> <span data-ttu-id="9d26a-121">既定のオプションは**毎月**が、 **3 か月**、 **6 か月**、**年**、または**24 か月間**を選択することもできます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-121">The default option is **Monthly**, but you can also select **3 months**, **6 months**, **Annually**, or **24 months**.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="9d26a-122">アドオンが公開されると、**[サブスクリプション期間]** の指定は変更できません。</span><span class="sxs-lookup"><span data-stu-id="9d26a-122">After your add-on is published, you can't change your **Subscription period** selection.</span></span>


## <a name="free-trial"></a><span data-ttu-id="9d26a-123">無料試用版</span><span class="sxs-lookup"><span data-stu-id="9d26a-123">Free trial</span></span>

<span data-ttu-id="9d26a-124">製品の種類として **[サブスクリプション]** を選んだ場合、**[無料試用版]** もここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-124">If you selected **Subscription** for your product type, **Free trial** is also shown here.</span></span> <span data-ttu-id="9d26a-125">既定のオプションは **[無料の試用版なし]** です。</span><span class="sxs-lookup"><span data-stu-id="9d26a-125">The default option is **No free trial.**</span></span> <span data-ttu-id="9d26a-126">必要に応じて、一定の期間アドオンを無料でユーザーが使えるようにすることもできます (**[1 週間]** または **[1 か月]**)。</span><span class="sxs-lookup"><span data-stu-id="9d26a-126">If you prefer, you can let customers use the add-on for free for a set period of time (either **1 week** or **1 month**).</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="9d26a-127">アドオンが公開されると、**[無料試用版]** の指定は変更できません。</span><span class="sxs-lookup"><span data-stu-id="9d26a-127">After your add-on is published, you can't change your **Free trial** selection.</span></span>


## <a name="content-type"></a><span data-ttu-id="9d26a-128">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="9d26a-128">Content type</span></span>

<span data-ttu-id="9d26a-129">アドオンの製品の種類に関係なく、提供するコンテンツの種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d26a-129">Regardless of your add-on's product type, you'll need to indicate the type of content you're offering.</span></span> <span data-ttu-id="9d26a-130">ほとんどのアドオンでは、コンテンツの種類は **[ソフトウェアのダウンロード]** になります。</span><span class="sxs-lookup"><span data-stu-id="9d26a-130">For most add-ons, the content type should be **Electronic software download**.</span></span> <span data-ttu-id="9d26a-131">一覧の別のオプションがアドオンの説明としてより適している場合 (たとえば、音楽のダウンロードや電子書籍を提供している場合) は、代わりにそのオプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-131">If another option from the list describes your add-on better (for example, if you are offering a music download or an e-book), select that option instead.</span></span>

<span data-ttu-id="9d26a-132">アドオンのコンテンツの種類として利用可能なオプションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="9d26a-132">These are the possible options for an add-on's content type:</span></span>

-   <span data-ttu-id="9d26a-133">ソフトウェアのダウンロード</span><span class="sxs-lookup"><span data-stu-id="9d26a-133">Electronic software download</span></span>
-   <span data-ttu-id="9d26a-134">電子書籍</span><span class="sxs-lookup"><span data-stu-id="9d26a-134">Electronic books</span></span>
-   <span data-ttu-id="9d26a-135">電子雑誌 1 冊</span><span class="sxs-lookup"><span data-stu-id="9d26a-135">Electronic magazine single issue</span></span>
-   <span data-ttu-id="9d26a-136">電子新聞 1 部</span><span class="sxs-lookup"><span data-stu-id="9d26a-136">Electronic newspaper single issue</span></span>
-   <span data-ttu-id="9d26a-137">ミュージックのダウンロード</span><span class="sxs-lookup"><span data-stu-id="9d26a-137">Music download</span></span>
-   <span data-ttu-id="9d26a-138">ミュージックのストリーミング</span><span class="sxs-lookup"><span data-stu-id="9d26a-138">Music streaming</span></span>
-   <span data-ttu-id="9d26a-139">オンライン データ ストレージ/サービス</span><span class="sxs-lookup"><span data-stu-id="9d26a-139">Online data storage/services</span></span>
-   <span data-ttu-id="9d26a-140">SaaS</span><span class="sxs-lookup"><span data-stu-id="9d26a-140">Software as a service</span></span>
-   <span data-ttu-id="9d26a-141">ビデオのダウンロード</span><span class="sxs-lookup"><span data-stu-id="9d26a-141">Video download</span></span>
-   <span data-ttu-id="9d26a-142">ビデオのストリーミング</span><span class="sxs-lookup"><span data-stu-id="9d26a-142">Video streaming</span></span>


## <a name="additional-properties"></a><span data-ttu-id="9d26a-143">追加のプロパティ</span><span class="sxs-lookup"><span data-stu-id="9d26a-143">Additional properties</span></span>

<span data-ttu-id="9d26a-144">これらのフィールドは、どのアドオンの種類でも省略可能です。</span><span class="sxs-lookup"><span data-stu-id="9d26a-144">These fields are optional for all types of add-ons.</span></span>

<span id="keywords" />

### <a name="keywords"></a><span data-ttu-id="9d26a-145">キーワード</span><span class="sxs-lookup"><span data-stu-id="9d26a-145">Keywords</span></span>

<span data-ttu-id="9d26a-146">提出するアドオンごとに、それぞれ 30 文字以内のキーワードを最大 10 個指定するオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="9d26a-146">You have the option to provide up to ten keywords of up to 30 characters each for each add-on you submit.</span></span> <span data-ttu-id="9d26a-147">そうすると、アプリはキーワードと一致するアドオンを照会できます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-147">Your app can then query for add-ons that match these words.</span></span> <span data-ttu-id="9d26a-148">この機能を利用すると、アプリのコードで製品 ID を直接指定しなくても、アドオンを読み込むことができる画面をアプリで構築できるようになります。</span><span class="sxs-lookup"><span data-stu-id="9d26a-148">This feature lets you build screens in your app that can load add-ons without you having to directly specify the product ID in your app's code.</span></span> <span data-ttu-id="9d26a-149">その場合、アプリでコードを変更したり、アプリをもう一度提出したりしなくても、いつでもアドオンのキーワードを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-149">You can then change the add-on's keywords anytime, without having to make code changes in your app or submit the app again.</span></span>

<span data-ttu-id="9d26a-150">このフィールドを照会するには、[Windows.Services.Store 名前空間](https://docs.microsoft.com/uwp/api/Windows.Services.Store)の [StoreProduct.Keywords](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.Keywords) プロパティを使用します </span><span class="sxs-lookup"><span data-stu-id="9d26a-150">To query this field, use the [StoreProduct.Keywords](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.Keywords) property in the [Windows.Services.Store namespace](https://docs.microsoft.com/uwp/api/Windows.Services.Store).</span></span> <span data-ttu-id="9d26a-151">(または、[Windows.ApplicationModel.Store 名前空間](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store)を使用している場合は、[ProductListing.Keywords](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.Keywords) プロパティを使用します)。</span><span class="sxs-lookup"><span data-stu-id="9d26a-151">(Or, if you're using the [Windows.ApplicationModel.Store namespace](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store), use the [ProductListing.Keywords](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.Keywords) property.)</span></span>

> [!NOTE]
> <span data-ttu-id="9d26a-152">キーワードは、Windows 8 と Windows 8.1 を対象とするパッケージでは使うことができません。</span><span class="sxs-lookup"><span data-stu-id="9d26a-152">Keywords are not available for use in packages targeting Windows 8 and Windows 8.1.</span></span>

<span id="custom-developer-data" />

### <a name="custom-developer-data"></a><span data-ttu-id="9d26a-153">カスタムの開発者データ</span><span class="sxs-lookup"><span data-stu-id="9d26a-153">Custom developer data</span></span>

<span data-ttu-id="9d26a-154">**[カスタムの開発者データ]** フィールド (以前は**タグ**と呼ばれていました) に最大 3,000 文字を入力して、アプリ内製品について追加のコンテキストを指定できます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-154">You can enter up to 3000 characters into the **Custom developer data** field (formerly called **Tag**) to provide extra context for your in-app product.</span></span> <span data-ttu-id="9d26a-155">通常、これは XML 文字列の形式ですが、このフィールドには任意の内容を入力できます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-155">Most often, this is in the form of an XML string, but you can enter anything you'd like in this field.</span></span> <span data-ttu-id="9d26a-156">これで、アプリはこのフィールドを照会して内容を読み取ることができます (ただし、アプリからデータを編集したり、変更を書き戻したりすることはできません)。</span><span class="sxs-lookup"><span data-stu-id="9d26a-156">Your app can then query this field to read its content (although the app can't edit the data and pass the changes back.)</span></span>

<span data-ttu-id="9d26a-157">たとえば、ゲームのアドオンとして、ユーザーが上のレベルにアクセスできるようになる金貨入りの袋を販売するとします。</span><span class="sxs-lookup"><span data-stu-id="9d26a-157">For example, let’s say you have a game, and you’re selling an add-on which allows the customer to access additional levels.</span></span> <span data-ttu-id="9d26a-158">**[カスタムの開発者データ]** フィールドを使うと、このアドオンをユーザーが所有している場合、どのレベルを利用できるかをアプリから照会できます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-158">Using the **Custom developer data** field, the app can query to see which levels are available when a customer owns this add-on.</span></span> <span data-ttu-id="9d26a-159">値 (ここでは、設定されているレベル) は、アプリのコードを変更したり、アプリをもう一度提出したりしなくても、アドオンの **[カスタムの開発者データ]** フィールドで情報を更新し、アドオンの更新された申請を公開することでいつでも調整できます。</span><span class="sxs-lookup"><span data-stu-id="9d26a-159">You could adjust the value at any time (in this case, the levels which are included), without having to make code changes in your app or submit the app again, by updating the info in the add-on's **Custom developer data** field and then publishing an updated submission for the add-on.</span></span>

<span data-ttu-id="9d26a-160">このフィールドを照会するには、[Windows.Services.Store 名前空間](https://docs.microsoft.com/uwp/api/Windows.Services.Store)の [StoreSku.CustomDeveloperData](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.customdeveloperdata#Windows_Services_Store_StoreSku_CustomDeveloperData) プロパティを使用します </span><span class="sxs-lookup"><span data-stu-id="9d26a-160">To query this field, use the [StoreSku.CustomDeveloperData](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.customdeveloperdata#Windows_Services_Store_StoreSku_CustomDeveloperData) property in the [Windows.Services.Store namespace](https://docs.microsoft.com/uwp/api/Windows.Services.Store).</span></span> <span data-ttu-id="9d26a-161">(または、[Windows.ApplicationModel.Store 名前空間](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store)を使用している場合は、[ProductListing.Tag](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.tag#Windows_ApplicationModel_Store_ProductListing_Tag) プロパティを使用します)。</span><span class="sxs-lookup"><span data-stu-id="9d26a-161">(Or, if you're using the [Windows.ApplicationModel.Store namespace](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store), use the [ProductListing.Tag](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.tag#Windows_ApplicationModel_Store_ProductListing_Tag) property.)</span></span>

> [!NOTE]
> <span data-ttu-id="9d26a-162">**[カスタムの開発者データ]** フィールドは、Windows 8 と Windows 8.1 を対象とするパッケージでは使うことができません。</span><span class="sxs-lookup"><span data-stu-id="9d26a-162">The **Custom developer data** field is not available for use in packages targeting Windows 8 and Windows 8.1.</span></span>

 

 

 
