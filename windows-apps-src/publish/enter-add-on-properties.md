---
author: jnHs
Description: "アドオンを提出するとき、[プロパティ] ページのオプションは、ユーザーに提供される場合のアドオン動作を決めるのに役立ちます。"
title: "アドオン プロパティの入力"
ms.assetid: 26D2139F-66FD-479E-940B-7491238ADCAE
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 253e008d3622094dcfe765531d71e5f37b7777b0
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="enter-add-on-properties"></a><span data-ttu-id="61600-104">アドオン プロパティの入力</span><span class="sxs-lookup"><span data-stu-id="61600-104">Enter add-on properties</span></span>


<span data-ttu-id="61600-105">アドオンを提出するとき、**[プロパティ]** ページのオプションは、ユーザーに提供される場合のアドオン動作を決めるのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="61600-105">When submitting an add-on, the options on the **Properties** page help determine the behavior of your add-on when offered to customers.</span></span>

## <a name="product-type"></a><span data-ttu-id="61600-106">製品の種類</span><span class="sxs-lookup"><span data-stu-id="61600-106">Product type</span></span>

<span data-ttu-id="61600-107">最初に[アドオンを作成する](set-your-add-on-product-id.md)ときに、製品の種類を選びます。</span><span class="sxs-lookup"><span data-stu-id="61600-107">Your product type is selected when you first [create the add-on](set-your-add-on-product-id.md).</span></span> <span data-ttu-id="61600-108">ここには、選んだ製品の種類が表示されますが、変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="61600-108">The product type you selected is displayed here, but you can't change it.</span></span>

> [!TIP]
> <span data-ttu-id="61600-109">アドオンを公開しておらず、別の製品の種類を選ぶ必要がある場合は、申請を削除して、もう一度選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="61600-109">If you haven't published the add-on, you can delete the submission and start again if you want to choose a different product type.</span></span>

<span data-ttu-id="61600-110">このページに表示されるフィールドは、アドオンの製品の種類に応じて変化します。</span><span class="sxs-lookup"><span data-stu-id="61600-110">The fields you see on this page will vary, depending on the product type of your add-on.</span></span>

## <a name="product-lifetime"></a><span data-ttu-id="61600-111">製品の有効期限</span><span class="sxs-lookup"><span data-stu-id="61600-111">Product lifetime</span></span>


<span data-ttu-id="61600-112">製品の種類として **[永続的]** を選んだ場合、**[製品の有効期限]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="61600-112">If you selected **Durable** for your product type, **Product lifetime** is shown here.</span></span> <span data-ttu-id="61600-113">永続的なアドオンの **[製品の有効期限]** の既定値は、**[無期限]** です。つまり、アドオンの期限は切れません。</span><span class="sxs-lookup"><span data-stu-id="61600-113">The default **Product lifetime** for a durable add-on is **Forever**, which means the add-on never expires.</span></span> <span data-ttu-id="61600-114">必要に応じて、設定した期間の後でアドオンの期限が切れるように **[製品の有効期限]** を設定できます (1 から 365 日間のオプションがあります)。</span><span class="sxs-lookup"><span data-stu-id="61600-114">If you prefer, you can set the **Product lifetime** so that the add-on expires after a set duration (with options from 1-365 days).</span></span>

## <a name="quantity"></a><span data-ttu-id="61600-115">数量</span><span class="sxs-lookup"><span data-stu-id="61600-115">Quantity</span></span>


<span data-ttu-id="61600-116">製品の種類に **[ストアで管理されるコンシューマブル]** を選択した場合、**[数量]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="61600-116">If you selected **Store-managed consumable** for your product type, **Quantity** is shown here.</span></span> <span data-ttu-id="61600-117">1 ~ 1000000 の範囲の数値を入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="61600-117">You'll need to enter a number between 1 and 1000000.</span></span> <span data-ttu-id="61600-118">顧客が対象アドオンを入手するときにこの数量が付与されます。顧客によるアドオンの消費がアプリによって報告されるたびに、ストアが残量を追跡します。</span><span class="sxs-lookup"><span data-stu-id="61600-118">This quantity will be granted to the customer when they acquire your add-on, and the Store will track the balance as the app reports the customer’s consumption of the add-on.</span></span>


## <a name="subscription-period"></a><span data-ttu-id="61600-119">サブスクリプション期間</span><span class="sxs-lookup"><span data-stu-id="61600-119">Subscription period</span></span>

<span data-ttu-id="61600-120">製品の種類として **[サブスクリプション]** を選んだ場合、**[サブスクリプション期間]** がここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="61600-120">If you selected **Subscription** for your product type, **Subscription period** is shown here.</span></span> <span data-ttu-id="61600-121">表示されるオプション (**[毎月]**、**[3 か月]**、**[6 か月]**、**[毎年]**、**[24 か月]**) の 1 つを選び、サブスクリプション料を課金する頻度を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="61600-121">You'll need to choose one of the available options (**Monthly**, **3 months**, **6 months**, **Annually**, or **24 months**) to indicate how frequently a customer will be charged for the subscription.</span></span> <span data-ttu-id="61600-122">アドオンが公開されると、**[サブスクリプション期間]** の指定は変更できません。</span><span class="sxs-lookup"><span data-stu-id="61600-122">Note that after your add-on is published, you can't change your **Subscription period** selection.</span></span>

> [!NOTE]
> <span data-ttu-id="61600-123">現在、サブスクリプション アドオンを作成できるのは、早期導入プログラムに参加している開発者アカウントに限られます。</span><span class="sxs-lookup"><span data-stu-id="61600-123">Currently, the ability to create subscription add-ons is only available to a set of developer accounts who are participating in an early adoption program.</span></span> <span data-ttu-id="61600-124">いずれは、すべての開発者アカウントでサブスクリプション アドオンをご利用いただけます。現時点でこの正式リリース前のドキュメントを公開しているのは、この機能がどのようなものかを開発者の皆様に簡単に紹介することが目的です。</span><span class="sxs-lookup"><span data-stu-id="61600-124">We will make subscription add-ons available to all developer accounts in the future, and we are making this preliminary documentation available now to give developers a preview of this feature.</span></span> <span data-ttu-id="61600-125">詳しくは、「[アプリのサブスクリプション アドオンの有効化](../monetize/enable-subscription-add-ons-for-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="61600-125">For more info, see [Enable subscription add-ons for your app](../monetize/enable-subscription-add-ons-for-your-app.md).</span></span>


## <a name="free-trial"></a><span data-ttu-id="61600-126">無料試用版</span><span class="sxs-lookup"><span data-stu-id="61600-126">Free trial</span></span>

<span data-ttu-id="61600-127">サブスクリプション型のアドオンの場合、**[無料のお試し版]** もここに表示されます。</span><span class="sxs-lookup"><span data-stu-id="61600-127">For subscription add-ons, **Free trial** is also shown here.</span></span> <span data-ttu-id="61600-128">一定の期間 (**[1 週間]** または **[1 か月]**) アドオンを無料でユーザーが使えるようにするか、**[無料評価版はありません]** を選ぶ必要があります。</span><span class="sxs-lookup"><span data-stu-id="61600-128">You must select whether to let customers use the add-on for free for a set period of time (either **1 week** or **1 month**), or whether to offer **No free trial**.</span></span> <span data-ttu-id="61600-129">アドオンが公開されると、**[無料のお試し版]** の指定は変更できません。</span><span class="sxs-lookup"><span data-stu-id="61600-129">Note that after your add-on is published, you can't change your **Free trial** selection.</span></span>


## <a name="content-type"></a><span data-ttu-id="61600-130">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="61600-130">Content type</span></span>

<span data-ttu-id="61600-131">アドオンの製品の種類に関係なく、提供するコンテンツの種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="61600-131">Regardless of your add-on's product type, you'll need to indicate the type of content you're offering.</span></span> <span data-ttu-id="61600-132">ほとんどのアドオンでは、コンテンツの種類は **[ソフトウェアのダウンロード]** になります。</span><span class="sxs-lookup"><span data-stu-id="61600-132">For most add-ons, the content type should be **Electronic software download**.</span></span> <span data-ttu-id="61600-133">一覧の別のオプションがアドオンの説明としてより適している場合 (たとえば、音楽のダウンロードや電子書籍を提供している場合) は、代わりにそのオプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="61600-133">If another option from the list describes your add-on better (for example, if you are offering a music download or an e-book), select that option instead.</span></span>

<span data-ttu-id="61600-134">アドオンのコンテンツの種類として利用可能なオプションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="61600-134">These are the possible options for an add-on's content type:</span></span>

-   <span data-ttu-id="61600-135">ソフトウェアのダウンロード</span><span class="sxs-lookup"><span data-stu-id="61600-135">Electronic software download</span></span>
-   <span data-ttu-id="61600-136">電子書籍</span><span class="sxs-lookup"><span data-stu-id="61600-136">Electronic books</span></span>
-   <span data-ttu-id="61600-137">電子雑誌 1 冊</span><span class="sxs-lookup"><span data-stu-id="61600-137">Electronic magazine single issue</span></span>
-   <span data-ttu-id="61600-138">電子新聞 1 部</span><span class="sxs-lookup"><span data-stu-id="61600-138">Electronic newspaper single issue</span></span>
-   <span data-ttu-id="61600-139">ミュージックのダウンロード</span><span class="sxs-lookup"><span data-stu-id="61600-139">Music download</span></span>
-   <span data-ttu-id="61600-140">ミュージックのストリーミング</span><span class="sxs-lookup"><span data-stu-id="61600-140">Music streaming</span></span>
-   <span data-ttu-id="61600-141">オンライン データ ストレージ/サービス</span><span class="sxs-lookup"><span data-stu-id="61600-141">Online data storage/services</span></span>
-   <span data-ttu-id="61600-142">SaaS</span><span class="sxs-lookup"><span data-stu-id="61600-142">Software as a service</span></span>
-   <span data-ttu-id="61600-143">ビデオのダウンロード</span><span class="sxs-lookup"><span data-stu-id="61600-143">Video download</span></span>
-   <span data-ttu-id="61600-144">ビデオのストリーミング</span><span class="sxs-lookup"><span data-stu-id="61600-144">Video streaming</span></span>


## <a name="additional-properties"></a><span data-ttu-id="61600-145">追加のプロパティ</span><span class="sxs-lookup"><span data-stu-id="61600-145">Additional properties</span></span>

<span data-ttu-id="61600-146">これらのフィールドは、どのアドオンの種類でも省略可能です。</span><span class="sxs-lookup"><span data-stu-id="61600-146">These fields are optional for all types of add-ons.</span></span>

<span id="keywords" />
### <a name="keywords"></a><span data-ttu-id="61600-147">キーワード</span><span class="sxs-lookup"><span data-stu-id="61600-147">Keywords</span></span>

<span data-ttu-id="61600-148">提出するアドオンごとに、それぞれ 30 文字以内のキーワードを最大 10 個指定するオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="61600-148">You have the option to provide up to ten keywords of up to 30 characters each for each add-on you submit.</span></span> <span data-ttu-id="61600-149">そうすると、アプリはキーワードと一致するアドオンを照会できます。</span><span class="sxs-lookup"><span data-stu-id="61600-149">Your app can then query for add-ons that match these words.</span></span> <span data-ttu-id="61600-150">この機能を利用すると、アプリのコードで製品 ID を直接指定しなくても、アドオンを読み込むことができる画面をアプリで構築できるようになります。</span><span class="sxs-lookup"><span data-stu-id="61600-150">This feature lets you build screens in your app that can load add-ons without you having to directly specify the product ID in your app's code.</span></span> <span data-ttu-id="61600-151">その場合、アプリでコードを変更したり、アプリをもう一度提出したりしなくても、いつでもアドオンのキーワードを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="61600-151">You can then change the add-on's keywords anytime, without having to make code changes in your app or submit the app again.</span></span>

<span data-ttu-id="61600-152">このフィールドを照会するには、[Windows.Services.Store 名前空間](https://msdn.microsoft.com/en-us/library/windows/apps/windows.services.store.aspx)の [StoreProduct.Keywords](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct#Windows_Services_Store_StoreProduct_Keywords) プロパティを使用します </span><span class="sxs-lookup"><span data-stu-id="61600-152">To query this field, use the [StoreProduct.Keywords](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct#Windows_Services_Store_StoreProduct_Keywords) property in the [Windows.Services.Store namespace](https://msdn.microsoft.com/en-us/library/windows/apps/windows.services.store.aspx).</span></span> <span data-ttu-id="61600-153">(または、[Windows.ApplicationModel.Store 名前空間](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.store.aspx)を使用している場合は、[ProductListing.Keywords](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting#Windows_ApplicationModel_Store_ProductListing_Keywords) プロパティを使用します)。</span><span class="sxs-lookup"><span data-stu-id="61600-153">(Or, if you're using the [Windows.ApplicationModel.Store namespace](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.store.aspx), use the [ProductListing.Keywords](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting#Windows_ApplicationModel_Store_ProductListing_Keywords) property.)</span></span>

> [!NOTE]
> <span data-ttu-id="61600-154">キーワードは、Windows 8 と Windows 8.1 を対象とするパッケージでは使うことができません。</span><span class="sxs-lookup"><span data-stu-id="61600-154">Keywords are not available for use in packages targeting Windows 8 and Windows 8.1.</span></span>

<span id="custom-developer-data" />
### <a name="custom-developer-data"></a><span data-ttu-id="61600-155">カスタムの開発者データ</span><span class="sxs-lookup"><span data-stu-id="61600-155">Custom developer data</span></span>

<span data-ttu-id="61600-156">**[カスタムの開発者データ]** フィールド (以前は**タグ**と呼ばれていました) に最大 3,000 文字を入力して、アプリ内製品について追加のコンテキストを指定できます。</span><span class="sxs-lookup"><span data-stu-id="61600-156">You can enter up to 3000 characters into the **Custom developer data** field (formerly called **Tag**) to provide extra context for your in-app product.</span></span> <span data-ttu-id="61600-157">通常、これは XML 文字列の形式ですが、このフィールドには任意の内容を入力できます。</span><span class="sxs-lookup"><span data-stu-id="61600-157">Most often, this is in the form of an XML string, but you can enter anything you'd like in this field.</span></span> <span data-ttu-id="61600-158">これで、アプリはこのフィールドを照会して内容を読み取ることができます (ただし、アプリからデータを編集したり、変更を書き戻したりすることはできません)。</span><span class="sxs-lookup"><span data-stu-id="61600-158">Your app can then query this field to read its content (although the app can't edit the data and pass the changes back.)</span></span>

<span data-ttu-id="61600-159">たとえば、ゲームのアドオンとして、ユーザーが上のレベルにアクセスできるようになる金貨入りの袋を販売するとします。</span><span class="sxs-lookup"><span data-stu-id="61600-159">For example, let’s say you have a game, and you’re selling an add-on which allows the customer to access additional levels.</span></span> <span data-ttu-id="61600-160">**[カスタムの開発者データ]** フィールドを使うと、このアドオンをユーザーが所有している場合、どのレベルを利用できるかをアプリから照会できます。</span><span class="sxs-lookup"><span data-stu-id="61600-160">Using the **Custom developer data** field, the app can query to see which levels are available when a customer owns this add-on.</span></span> <span data-ttu-id="61600-161">値 (ここでは、設定されているレベル) は、アプリのコードを変更したり、アプリをもう一度提出したりしなくても、アドオンの **[カスタムの開発者データ]** フィールドで情報を更新し、アドオンの更新された申請を公開することでいつでも調整できます。</span><span class="sxs-lookup"><span data-stu-id="61600-161">You could adjust the value at any time (in this case, the levels which are included), without having to make code changes in your app or submit the app again, by updating the info in the add-on's **Custom developer data** field and then publishing an updated submission for the add-on.</span></span>

<span data-ttu-id="61600-162">このフィールドを照会するには、[Windows.Services.Store 名前空間](https://msdn.microsoft.com/en-us/library/windows/apps/windows.services.store.aspx)の [StoreSku.CustomDeveloperData](https://msdn.microsoft.com/en-us/library/windows/apps/windows.services.store.storesku.customdeveloperdata.aspx) プロパティを使用します </span><span class="sxs-lookup"><span data-stu-id="61600-162">To query this field, use the [StoreSku.CustomDeveloperData](https://msdn.microsoft.com/en-us/library/windows/apps/windows.services.store.storesku.customdeveloperdata.aspx) property in the [Windows.Services.Store namespace](https://msdn.microsoft.com/en-us/library/windows/apps/windows.services.store.aspx).</span></span> <span data-ttu-id="61600-163">(または、[Windows.ApplicationModel.Store 名前空間](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.store.aspx)を使用している場合は、[ProductListing.Tag](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.store.productlisting.tag.aspx) プロパティを使用します)。</span><span class="sxs-lookup"><span data-stu-id="61600-163">(Or, if you're using the [Windows.ApplicationModel.Store namespace](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.store.aspx), use the [ProductListing.Tag](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.store.productlisting.tag.aspx) property.)</span></span>

> [!NOTE]
> <span data-ttu-id="61600-164">**[カスタムの開発者データ]** フィールドは、Windows 8 と Windows 8.1 を対象とするパッケージでは使うことができません。</span><span class="sxs-lookup"><span data-stu-id="61600-164">The **Custom developer data** field is not available for use in packages targeting Windows 8 and Windows 8.1.</span></span>

 

 

 
