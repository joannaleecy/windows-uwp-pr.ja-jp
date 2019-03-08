---
Description: アドオンを提出するとき、[プロパティ] ページのオプションは、ユーザーに提供される場合のアドオン動作を決めるのに役立ちます。
title: アドオン プロパティの入力
ms.assetid: 26D2139F-66FD-479E-940B-7491238ADCAE
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, アドオン, プロパティ, サブスクリプション期間, 製品の有効期間, コンテンツの種類, iap, アプリ内購入, アプリ内製品
ms.localizationpriority: medium
ms.openlocfilehash: 17025282aec18da01f14431996a3942ffdd90312
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57629677"
---
# <a name="enter-add-on-properties"></a><span data-ttu-id="e47c2-104">アドオン プロパティの入力</span><span class="sxs-lookup"><span data-stu-id="e47c2-104">Enter add-on properties</span></span>

<span data-ttu-id="e47c2-105">アドオンを提出するとき、**[プロパティ]** ページのオプションは、ユーザーに提供される場合のアドオン動作を決めるのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-105">When submitting an add-on, the options on the **Properties** page help determine the behavior of your add-on when offered to customers.</span></span>

## <a name="product-type"></a><span data-ttu-id="e47c2-106">製品の種類</span><span class="sxs-lookup"><span data-stu-id="e47c2-106">Product type</span></span>

<span data-ttu-id="e47c2-107">最初に[アドオンを作成する](set-your-add-on-product-id.md)ときに、製品の種類を選びます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-107">Your product type is selected when you first [create the add-on](set-your-add-on-product-id.md).</span></span> <span data-ttu-id="e47c2-108">ここには、選んだ製品の種類が表示されますが、変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="e47c2-108">The product type you selected is displayed here, but you can't change it.</span></span>

> [!TIP]
> <span data-ttu-id="e47c2-109">アドオンを公開しておらず、別の製品の種類を選ぶ必要がある場合は、申請を削除して、もう一度選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-109">If you haven't published the add-on, you can delete the submission and start again if you want to choose a different product type.</span></span>

<span data-ttu-id="e47c2-110">このページに表示されるフィールドは、アドオンの製品の種類に応じて変化します。</span><span class="sxs-lookup"><span data-stu-id="e47c2-110">The fields you see on this page will vary, depending on the product type of your add-on.</span></span>


## <a name="product-lifetime"></a><span data-ttu-id="e47c2-111">製品の有効期限</span><span class="sxs-lookup"><span data-stu-id="e47c2-111">Product lifetime</span></span>

<span data-ttu-id="e47c2-112">製品の種類として **[永続的]** を選んだ場合、**[製品の有効期限]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-112">If you selected **Durable** for your product type, **Product lifetime** is shown here.</span></span> <span data-ttu-id="e47c2-113">永続的なアドオンの **[製品の有効期限]** の既定値は、**[無期限]** です。つまり、アドオンの期限は切れません。</span><span class="sxs-lookup"><span data-stu-id="e47c2-113">The default **Product lifetime** for a durable add-on is **Forever**, which means the add-on never expires.</span></span> <span data-ttu-id="e47c2-114">変更することができる場合は、**製品の有効期間**アドオンは、(1 ~ 365 日のオプション) で設定された期間の後に有効期限が切れるようにします。</span><span class="sxs-lookup"><span data-stu-id="e47c2-114">If you prefer, you can change the **Product lifetime** so that the add-on expires after a set duration (with options from 1-365 days).</span></span>


## <a name="quantity"></a><span data-ttu-id="e47c2-115">数量</span><span class="sxs-lookup"><span data-stu-id="e47c2-115">Quantity</span></span>

<span data-ttu-id="e47c2-116">製品の種類に **[ストアで管理されるコンシューマブル]** を選択した場合、**[数量]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-116">If you selected **Store-managed consumable** for your product type, **Quantity** is shown here.</span></span> <span data-ttu-id="e47c2-117">1 ~ 1000000 の範囲の数値を入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e47c2-117">You'll need to enter a number between 1 and 1000000.</span></span> <span data-ttu-id="e47c2-118">顧客が対象アドオンを入手するときにこの数量が付与されます。顧客によるアドオンの消費がアプリによって報告されるたびに、ストアが残量を追跡します。</span><span class="sxs-lookup"><span data-stu-id="e47c2-118">This quantity will be granted to the customer when they acquire your add-on, and the Store will track the balance as the app reports the customer’s consumption of the add-on.</span></span>


## <a name="subscription-period"></a><span data-ttu-id="e47c2-119">サブスクリプション期間</span><span class="sxs-lookup"><span data-stu-id="e47c2-119">Subscription period</span></span>

<span data-ttu-id="e47c2-120">製品の種類として **[サブスクリプション]** を選んだ場合、**[サブスクリプション期間]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-120">If you selected **Subscription** for your product type, **Subscription period** is shown here.</span></span> <span data-ttu-id="e47c2-121">サブスクリプション料を課金する頻度を指定するオプションを選びす。</span><span class="sxs-lookup"><span data-stu-id="e47c2-121">Choose an option to specify how frequently a customer will be charged for the subscription.</span></span> <span data-ttu-id="e47c2-122">既定のオプションは**毎月**、選択することもできますが、 **3 か月間**、 **6 か月間**、**年間**、または**24か月間**.</span><span class="sxs-lookup"><span data-stu-id="e47c2-122">The default option is **Monthly**, but you can also select **3 months**, **6 months**, **Annually**, or **24 months**.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e47c2-123">アドオンが公開されると、**[サブスクリプション期間]** の指定は変更できません。</span><span class="sxs-lookup"><span data-stu-id="e47c2-123">After your add-on is published, you can't change your **Subscription period** selection.</span></span>


## <a name="free-trial"></a><span data-ttu-id="e47c2-124">無料試用版</span><span class="sxs-lookup"><span data-stu-id="e47c2-124">Free trial</span></span>

<span data-ttu-id="e47c2-125">製品の種類として **[サブスクリプション]** を選んだ場合、**[無料試用版]** もここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-125">If you selected **Subscription** for your product type, **Free trial** is also shown here.</span></span> <span data-ttu-id="e47c2-126">既定のオプションは **[無料の試用版なし]** です。</span><span class="sxs-lookup"><span data-stu-id="e47c2-126">The default option is **No free trial.**</span></span> <span data-ttu-id="e47c2-127">必要に応じて、一定の期間アドオンを無料でユーザーが使えるようにすることもできます (**[1 週間]** または **[1 か月]**)。</span><span class="sxs-lookup"><span data-stu-id="e47c2-127">If you prefer, you can let customers use the add-on for free for a set period of time (either **1 week** or **1 month**).</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="e47c2-128">アドオンが公開されると、**[無料試用版]** の指定は変更できません。</span><span class="sxs-lookup"><span data-stu-id="e47c2-128">After your add-on is published, you can't change your **Free trial** selection.</span></span>


## <a name="content-type"></a><span data-ttu-id="e47c2-129">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="e47c2-129">Content type</span></span>

<span data-ttu-id="e47c2-130">アドオンの製品の種類に関係なく、提供するコンテンツの種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e47c2-130">Regardless of your add-on's product type, you'll need to indicate the type of content you're offering.</span></span> <span data-ttu-id="e47c2-131">ほとんどのアドオンでは、コンテンツの種類は **[ソフトウェアのダウンロード]** になります。</span><span class="sxs-lookup"><span data-stu-id="e47c2-131">For most add-ons, the content type should be **Electronic software download**.</span></span> <span data-ttu-id="e47c2-132">一覧の別のオプションがアドオンの説明としてより適している場合 (たとえば、音楽のダウンロードや電子書籍を提供している場合) は、代わりにそのオプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-132">If another option from the list describes your add-on better (for example, if you are offering a music download or an e-book), select that option instead.</span></span>

<span data-ttu-id="e47c2-133">アドオンのコンテンツの種類として利用可能なオプションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="e47c2-133">These are the possible options for an add-on's content type:</span></span>

-   <span data-ttu-id="e47c2-134">ソフトウェアのダウンロード</span><span class="sxs-lookup"><span data-stu-id="e47c2-134">Electronic software download</span></span>
-   <span data-ttu-id="e47c2-135">電子書籍</span><span class="sxs-lookup"><span data-stu-id="e47c2-135">Electronic books</span></span>
-   <span data-ttu-id="e47c2-136">電子雑誌 1 冊</span><span class="sxs-lookup"><span data-stu-id="e47c2-136">Electronic magazine single issue</span></span>
-   <span data-ttu-id="e47c2-137">電子新聞 1 部</span><span class="sxs-lookup"><span data-stu-id="e47c2-137">Electronic newspaper single issue</span></span>
-   <span data-ttu-id="e47c2-138">ミュージックのダウンロード</span><span class="sxs-lookup"><span data-stu-id="e47c2-138">Music download</span></span>
-   <span data-ttu-id="e47c2-139">ミュージックのストリーミング</span><span class="sxs-lookup"><span data-stu-id="e47c2-139">Music streaming</span></span>
-   <span data-ttu-id="e47c2-140">オンライン データ ストレージ/サービス</span><span class="sxs-lookup"><span data-stu-id="e47c2-140">Online data storage/services</span></span>
-   <span data-ttu-id="e47c2-141">SaaS</span><span class="sxs-lookup"><span data-stu-id="e47c2-141">Software as a service</span></span>
-   <span data-ttu-id="e47c2-142">ビデオのダウンロード</span><span class="sxs-lookup"><span data-stu-id="e47c2-142">Video download</span></span>
-   <span data-ttu-id="e47c2-143">ビデオのストリーミング</span><span class="sxs-lookup"><span data-stu-id="e47c2-143">Video streaming</span></span>


## <a name="additional-properties"></a><span data-ttu-id="e47c2-144">追加のプロパティ</span><span class="sxs-lookup"><span data-stu-id="e47c2-144">Additional properties</span></span>

<span data-ttu-id="e47c2-145">これらのフィールドは、どのアドオンの種類でも省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e47c2-145">These fields are optional for all types of add-ons.</span></span>

<span id="keywords" />

### <a name="keywords"></a><span data-ttu-id="e47c2-146">キーワード</span><span class="sxs-lookup"><span data-stu-id="e47c2-146">Keywords</span></span>

<span data-ttu-id="e47c2-147">提出するアドオンごとに、それぞれ 30 文字以内のキーワードを最大 10 個指定するオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="e47c2-147">You have the option to provide up to ten keywords of up to 30 characters each for each add-on you submit.</span></span> <span data-ttu-id="e47c2-148">そうすると、アプリはキーワードと一致するアドオンを照会できます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-148">Your app can then query for add-ons that match these words.</span></span> <span data-ttu-id="e47c2-149">この機能を利用すると、アプリのコードで製品 ID を直接指定しなくても、アドオンを読み込むことができる画面をアプリで構築できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e47c2-149">This feature lets you build screens in your app that can load add-ons without you having to directly specify the product ID in your app's code.</span></span> <span data-ttu-id="e47c2-150">その場合、アプリでコードを変更したり、アプリをもう一度提出したりしなくても、いつでもアドオンのキーワードを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-150">You can then change the add-on's keywords anytime, without having to make code changes in your app or submit the app again.</span></span>

<span data-ttu-id="e47c2-151">このフィールドを照会するには、[Windows.Services.Store 名前空間](https://docs.microsoft.com/uwp/api/Windows.Services.Store)の [StoreProduct.Keywords](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.Keywords) プロパティを使用します </span><span class="sxs-lookup"><span data-stu-id="e47c2-151">To query this field, use the [StoreProduct.Keywords](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.Keywords) property in the [Windows.Services.Store namespace](https://docs.microsoft.com/uwp/api/Windows.Services.Store).</span></span> <span data-ttu-id="e47c2-152">(または、[Windows.ApplicationModel.Store 名前空間](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store)を使用している場合は、[ProductListing.Keywords](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.Keywords) プロパティを使用します)。</span><span class="sxs-lookup"><span data-stu-id="e47c2-152">(Or, if you're using the [Windows.ApplicationModel.Store namespace](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store), use the [ProductListing.Keywords](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.Keywords) property.)</span></span>

> [!NOTE]
> <span data-ttu-id="e47c2-153">Windows 8 および Windows 8.1 を対象とするパッケージで使用するためのキーワードが利用できません。</span><span class="sxs-lookup"><span data-stu-id="e47c2-153">Keywords are not available for use in packages targeting Windows 8 and Windows 8.1.</span></span>

<span id="custom-developer-data" />

### <a name="custom-developer-data"></a><span data-ttu-id="e47c2-154">カスタムの開発者データ</span><span class="sxs-lookup"><span data-stu-id="e47c2-154">Custom developer data</span></span>

<span data-ttu-id="e47c2-155">**[カスタムの開発者データ]** フィールド (以前は**タグ**と呼ばれていました) に最大 3,000 文字を入力して、アプリ内製品について追加のコンテキストを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-155">You can enter up to 3000 characters into the **Custom developer data** field (formerly called **Tag**) to provide extra context for your in-app product.</span></span> <span data-ttu-id="e47c2-156">通常、これは XML 文字列の形式ですが、このフィールドには任意の内容を入力できます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-156">Most often, this is in the form of an XML string, but you can enter anything you'd like in this field.</span></span> <span data-ttu-id="e47c2-157">これで、アプリはこのフィールドを照会して内容を読み取ることができます (ただし、アプリからデータを編集したり、変更を書き戻したりすることはできません)。</span><span class="sxs-lookup"><span data-stu-id="e47c2-157">Your app can then query this field to read its content (although the app can't edit the data and pass the changes back.)</span></span>

<span data-ttu-id="e47c2-158">たとえば、ゲームのアドオンとして、ユーザーが上のレベルにアクセスできるようになる金貨入りの袋を販売するとします。</span><span class="sxs-lookup"><span data-stu-id="e47c2-158">For example, let’s say you have a game, and you’re selling an add-on which allows the customer to access additional levels.</span></span> <span data-ttu-id="e47c2-159">**[カスタムの開発者データ]** フィールドを使うと、このアドオンをユーザーが所有している場合、どのレベルを利用できるかをアプリから照会できます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-159">Using the **Custom developer data** field, the app can query to see which levels are available when a customer owns this add-on.</span></span> <span data-ttu-id="e47c2-160">値 (ここでは、設定されているレベル) は、アプリのコードを変更したり、アプリをもう一度提出したりしなくても、アドオンの **[カスタムの開発者データ]** フィールドで情報を更新し、アドオンの更新された申請を公開することでいつでも調整できます。</span><span class="sxs-lookup"><span data-stu-id="e47c2-160">You could adjust the value at any time (in this case, the levels which are included), without having to make code changes in your app or submit the app again, by updating the info in the add-on's **Custom developer data** field and then publishing an updated submission for the add-on.</span></span>

<span data-ttu-id="e47c2-161">このフィールドを照会するには、[Windows.Services.Store 名前空間](https://docs.microsoft.com/uwp/api/Windows.Services.Store)の [StoreSku.CustomDeveloperData](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.customdeveloperdata#Windows_Services_Store_StoreSku_CustomDeveloperData) プロパティを使用します </span><span class="sxs-lookup"><span data-stu-id="e47c2-161">To query this field, use the [StoreSku.CustomDeveloperData](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.customdeveloperdata#Windows_Services_Store_StoreSku_CustomDeveloperData) property in the [Windows.Services.Store namespace](https://docs.microsoft.com/uwp/api/Windows.Services.Store).</span></span> <span data-ttu-id="e47c2-162">(または、[Windows.ApplicationModel.Store 名前空間](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store)を使用している場合は、[ProductListing.Tag](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.tag#Windows_ApplicationModel_Store_ProductListing_Tag) プロパティを使用します)。</span><span class="sxs-lookup"><span data-stu-id="e47c2-162">(Or, if you're using the [Windows.ApplicationModel.Store namespace](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store), use the [ProductListing.Tag](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.tag#Windows_ApplicationModel_Store_ProductListing_Tag) property.)</span></span>

> [!NOTE]
> <span data-ttu-id="e47c2-163">**カスタム開発者データ**フィールドは Windows 8 および Windows 8.1 を対象とするパッケージで使用するために使用できません。</span><span class="sxs-lookup"><span data-stu-id="e47c2-163">The **Custom developer data** field is not available for use in packages targeting Windows 8 and Windows 8.1.</span></span>

 

 

 
