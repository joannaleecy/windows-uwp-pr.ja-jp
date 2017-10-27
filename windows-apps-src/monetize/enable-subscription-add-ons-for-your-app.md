---
author: mcleanbyron
description: "Windows.Services.Store 名前空間を使ってサブスクリプション アドオンを実装する方法について説明します。"
title: "アプリのサブスクリプション アドオンの有効化"
keywords: "Windows 10, UWP, サブスクリプション, アドオン, アプリ内購入, IAP, Windows.Services.Store"
ms.author: mcleans
ms.date: 08/01/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 16e2e8d160ad2236220dc6f19f578bbaa82c9dc0
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="enable-subscription-add-ons-for-your-app"></a><span data-ttu-id="dd7fb-104">アプリのサブスクリプション アドオンの有効化</span><span class="sxs-lookup"><span data-stu-id="dd7fb-104">Enable subscription add-ons for your app</span></span>

> [!IMPORTANT]
> <span data-ttu-id="dd7fb-105">現在、サブスクリプション アドオンを作成できるのは、早期導入プログラムに参加している開発者アカウントに限られます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-105">Currently, the ability to create subscription add-ons is only available to a set of developer accounts who are participating in an early adoption program.</span></span> <span data-ttu-id="dd7fb-106">いずれは、すべての開発者アカウントでサブスクリプション アドオンをご利用いただけます。現時点でこの正式リリース前のドキュメントを公開しているのは、この機能がどのようなものかを開発者の皆様に簡単に紹介することが目的です。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-106">We will make subscription add-ons available to all developer accounts in the future, and we are making this preliminary documentation available now to give developers a preview of this feature.</span></span>

<span data-ttu-id="dd7fb-107">UWP アプリが Windows 10 バージョン 1607 以降を対象としている場合、ユーザーに*サブスクリプション* アドオンのアプリ内購入を提供できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-107">If your UWP app targets Windows 10, version 1607, or later, you can offer in-app purchases of *subscription* add-ons to your customers.</span></span> <span data-ttu-id="dd7fb-108">サブスクリプションを使用すると、自動の定期的な課金期間を設定してアプリ内でデジタル製品 (アプリの機能やデジタル コンテンツなど) を販売できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-108">You can use subscriptions to sell digital products in your app (such as app features or digital content) with automated recurring billing periods.</span></span>

## <a name="feature-highlights"></a><span data-ttu-id="dd7fb-109">機能の概要</span><span class="sxs-lookup"><span data-stu-id="dd7fb-109">Feature highlights</span></span>

<span data-ttu-id="dd7fb-110">UWP アプリのサブスクリプション アドオンでは、次の機能をサポートします。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-110">Subscription add-ons for UWP apps support the following features:</span></span>

* <span data-ttu-id="dd7fb-111">サブスクリプション期間を 1 か月、3 か月、6 か月、1 年、または 2 年から選択できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-111">You can choose from subscription periods of 1 month, 3 months, 6 months, 1 year, or 2 years.</span></span> <span data-ttu-id="dd7fb-112">一部のアプリでは、テスト目的専用の 6 時間のサブスクリプションを使用できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-112">Some apps can also use a 6-hour subscription period for testing purposes only.</span></span>
* <span data-ttu-id="dd7fb-113">サブスクリプションに 1 週間または 1 か月の無料試用期間を追加できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-113">You can add free trial periods of 1 week or 1 month to your subscription.</span></span>
* <span data-ttu-id="dd7fb-114">Windows SDK では、アプリで利用可能なサブスクリプション アドオンに関する情報を入手したり、サブスクリプション アドオンを購入できるようにしたりするためにアプリで利用できる [API を提供](#code-examples)しています。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-114">The Windows SDK [provides APIs](#code-examples) you can use in your app to get info about available subscription add-ons for the app and enable the purchase of a subscription add-on.</span></span> <span data-ttu-id="dd7fb-115">また、サービスから呼び出して[ユーザーのサブスクリプションを管理](#manage-subscriptions)できる REST API も提供しています。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-115">We also provide REST APIs you can call from your services to [manage subscriptions for a user](#manage-subscriptions).</span></span>
* <span data-ttu-id="dd7fb-116">サブスクリプションの取得数、アクティブなサブスクリプション会員数、および特定の期間中に取り消されたサブスクリプション数を表示する分析レポートを確認できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-116">You can view analytic reports that provide the number of subscription acquisitions, active subscribers, and canceled subscriptions in a given time period.</span></span>
* <span data-ttu-id="dd7fb-117">ユーザーは自分の Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページでサブスクリプションを管理できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-117">Customers can manage their subscription on the [http://account.microsoft.com/services](http://account.microsoft.com/services) page for their Microsoft account.</span></span> <span data-ttu-id="dd7fb-118">ユーザーはこのページを使用して、取得したサブスクリプションすべての表示、サブスクリプションの取り消し、およびサブスクリプションに関連付けられた支払方法の変更ができます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-118">Customers can use this page to view all of the subscriptions they have acquired, cancel a subscription, and change the form of payment that is associated with their subscription.</span></span>

> [!NOTE]
> <span data-ttu-id="dd7fb-119">アプリでサブスクリプション アドオンの購入ができるようにするには、アプリは Windows 10 バージョン 1607 以降を対象とし、**Windows.ApplicationModel.Store** 名前空間ではなく、**Windows.Services.Store** 名前空間の API を使用して、アプリ内購入エクスペリエンスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-119">To enable the purchase of subscription add-ons in your app, your app must target Windows 10, version 1607, or a later version, and it must use the APIs in the **Windows.Services.Store** namespace to implement the in-app purchase experience instead of the **Windows.ApplicationModel.Store** namespace.</span></span> <span data-ttu-id="dd7fb-120">これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-120">For more information about the differences between these namespaces, see [In-app purchases and trials](in-app-purchases-and-trials.md).</span></span>

## <a name="steps-to-enable-a-subscription-add-on-for-your-app"></a><span data-ttu-id="dd7fb-121">アプリのサブスクリプション アドオンを有効化する手順</span><span class="sxs-lookup"><span data-stu-id="dd7fb-121">Steps to enable a subscription add-on for your app</span></span>

<span data-ttu-id="dd7fb-122">アプリでサブスクリプション アドオンを購入できるようにするには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-122">To enable the purchase of subscription add-ons in your app, follow these steps.</span></span>

1. <span data-ttu-id="dd7fb-123">デベロッパー センター ダッシュボードでサブスクリプションの[アドオンの申請を作成](../publish/add-on-submissions.md)し、申請を公開します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-123">[Create an add-on submission](../publish/add-on-submissions.md) for your subscription in the Dev Center dashboard and publish the submission.</span></span> <span data-ttu-id="dd7fb-124">アドオンの申請プロセスに従い、次のプロパティをよく確認します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-124">As you follow the add-on submission process, pay close attention to the following properties:</span></span>

  * <span data-ttu-id="dd7fb-125">[製品の種類](../publish/set-your-add-on-product-id.md#product-type): **[サブスクリプション]**を選択していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-125">[Product type](../publish/set-your-add-on-product-id.md#product-type): Make sure you select **Subscription**.</span></span>

  * <span data-ttu-id="dd7fb-126">[サブスクリプション期間](../publish/enter-add-on-properties.md#subscription-period): サブスクリプションの定期的な課金期間を選択します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-126">[Subscription period](../publish/enter-add-on-properties.md#subscription-period): Choose the recurring billing period for your subscription.</span></span> <span data-ttu-id="dd7fb-127">アドオンの公開後にサブスクリプション期間を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-127">You cannot change the subscription period after you publish your add-on.</span></span>

    <span data-ttu-id="dd7fb-128">各サブスクリプション アドオンがサポートするのは、単一のサブスクリプション期間と試用期間だけです。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-128">Each subscription add-on supports a single subscription period and trial period.</span></span> <span data-ttu-id="dd7fb-129">アプリで提供するサブスクリプションの種類ごとに異なるサブスクリプション アドオンを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-129">You must create a different subscription add-on for each type of subscription you want to offer in your app.</span></span> <span data-ttu-id="dd7fb-130">たとえば、試用期間のない月間サブスクリプション、1 か月の試用期間のある月間サブスクリプション、試用期間のない年間サブスクリプション、1 か月の試用期間のある年間サブスクリプションを提供する場合、サブスクリプション アドオンを 4 つ作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-130">For example, if you wanted to offer a monthly subscription with no trial, a monthly subscription with a one-month trial, an annual subscription with no trial, and an annual subscription with a one-month trial, you would need to create four subscription add-ons.</span></span>
        > [!NOTE]
        > If you are in the process of implementing the in-app purchase experience for your subscription, we recommend that you create a test add-on with the **For testing only – 6 hours** subscription period to help you test the experience. You can choose this test period only if you select one of the **Hidden in the Store** [visibility options](../publish/set-add-on-pricing-and-availability.md#visibility) for your test add-on.

  * <span data-ttu-id="dd7fb-131">[試用期間](../publish/enter-add-on-properties.md#free-trial): ユーザーがサブスクリプション コンテンツを購入する前に試すことのできる期間を 1 週間にするか、1 か月にするかを選択することを検討します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-131">[Trial period](../publish/enter-add-on-properties.md#free-trial): Consider choosing a 1 week or 1 month trial period for your subscription to enable users to try your subscription content before they buy it.</span></span> <span data-ttu-id="dd7fb-132">サブスクリプション アドオンの公開後に試用期間を変更または削除することはできません。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-132">You cannot change or remove the trial period after you publish your subscription add-on.</span></span>

    <span data-ttu-id="dd7fb-133">サブスクリプションの無料試用版を取得するには、ユーザーは有効な支払方法の設定も含めて標準のアプリ内購入プロセスに従って、サブスクリプションを購入する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-133">To acquire a free trial of your subscription, a user must purchase your subscription through the standard in-app purchase process, including a valid form of payment.</span></span> <span data-ttu-id="dd7fb-134">試用期間中に料金を請求されることはありません。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-134">They are not charged any money during the trial period.</span></span> <span data-ttu-id="dd7fb-135">試用期間の終わりに、サブスクリプションは自動的に完全なサブスクリプションに変わり、有料サブスクリプションの最初の期間の料金がユーザーの支払方法に請求されます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-135">At the end of the trial period, the subscription automatically converts to the full subscription and the user's payment instrument will be charged for the first period of the paid subscription.</span></span> <span data-ttu-id="dd7fb-136">ユーザーが試用期間中にサブスクリプションを取り消した場合、試用期間が終わるまでサブスクリプションは有効のままです。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-136">If the user chooses to cancel their subscription during the trial period, the subscription remains active until the end of the trial period.</span></span>
        > [!NOTE]
        > Some trial durations are not available for all subscription periods.

  * <span data-ttu-id="dd7fb-137">[可視性](../publish/set-add-on-pricing-and-availability.md#visibility): サブスクリプションのアプリ内購入エクスペリエンスのテストだけに使用するテスト用アドオンを作成している場合は、**[ストアに表示しない]** オプションのいずれかを選択することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-137">[Visibility](../publish/set-add-on-pricing-and-availability.md#visibility): If you creating a test add-on that you will only use to test the in-app purchase experience for your subscription, we recommend that you select one of the **Hidden in the Store** options.</span></span> <span data-ttu-id="dd7fb-138">それ以外の場合は、シナリオに最適な可視化オプションを選択します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-138">Otherwise, you can select the best visibility option for your scenario.</span></span>

  * <span data-ttu-id="dd7fb-139">[価格](../publish/set-add-on-pricing-and-availability.md?#pricing): このセクションでサブスクリプションの価格を選択します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-139">[Pricing](../publish/set-add-on-pricing-and-availability.md?#pricing): Choose the price of your subscription in this section.</span></span> <span data-ttu-id="dd7fb-140">アドオンの公開後にサブスクリプションの価格を上げることはできません (ただし、後で価格を下げることはできます)。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-140">You cannot raise the price of the subscription after you publish the add-on (however, you can lower the price later).</span></span>
      > [!IMPORTANT]
      > <span data-ttu-id="dd7fb-141">アドオンの作成時、既定では、価格は最初 **[無料]** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-141">By default, when you create any add-on the price is initially set to **Free**.</span></span> <span data-ttu-id="dd7fb-142">サブスクリプション アドオンの申請の完了後にアドオンの価格を上げることはできないため、ここで必ずサブスクリプションの価格を選択してください。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-142">Because you cannot raise the price of a subscription add-on after you complete the add-on submission, be sure to choose the price of your subscription here.</span></span>

2. <span data-ttu-id="dd7fb-143">アプリで、[**Windows.Services.Store**](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の API を使用して、現在のユーザーが既にサブスクリプション アドオンを取得していて、そのユーザーにアドオンをアプリ内購入として販売するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-143">In your app, use APIs in the [**Windows.Services.Store**](https://docs.microsoft.com/uwp/api/windows.services.store) namespace to confirm whether the current user has already acquired your subscription add-on and then offer it for sale to the user as an in-app purchase.</span></span> <span data-ttu-id="dd7fb-144">詳細については、この記事の[コード サンプル](#code-examples)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-144">See the [code examples](#code-examples) in this article for more details.</span></span>

3. <span data-ttu-id="dd7fb-145">アプリで、サブスクリプションのアプリ内購入の実装をテストします。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-145">Test the in-app purchase implementation of your subscription in your app.</span></span> <span data-ttu-id="dd7fb-146">ストアからアプリを開発用デバイスに 1 回ダウンロードして、そのライセンスをテストに使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-146">You'll need to download your app once from the Store to your development device to use its license for testing.</span></span> <span data-ttu-id="dd7fb-147">詳細については、アプリ内購入の[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-147">For more information, see our [testing guidance](in-app-purchases-and-trials.md#testing) for in-app purchases.</span></span>  
    > [!NOTE]
    > <span data-ttu-id="dd7fb-148">アプリで、**テスト専用 (6 時間)** のサブスクリプション期間を利用できる場合、この期間を設定したテスト用アドオンを作成して、エクスペリエンスのテストに役立てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-148">If your app has access to the **For testing only – 6 hours** subscription period, we recommend that you create a test add-on with this period to help you test the experience.</span></span> <span data-ttu-id="dd7fb-149">このテスト期間は、テスト用アドオンに **[ストアに表示しない]** [可視性オプション](../publish/set-add-on-pricing-and-availability.md#visibility)のいずれかを選択した場合にのみ選択できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-149">You can choose this test period only if you select one of the **Hidden in the Store** [visibility options](../publish/set-add-on-pricing-and-availability.md#visibility) for your test add-on.</span></span>

4. <span data-ttu-id="dd7fb-150">テストしたコードを含む更新したアプリ パッケージを含めたアプリの申請を作成して公開します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-150">Create and publish an app submission that includes your updated app package, including your tested code.</span></span> <span data-ttu-id="dd7fb-151">詳しくは、「[アプリの申請](../publish/app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-151">For more information, see [App submissions](../publish/app-submissions.md).</span></span>

<span id="code-examples"/>
## <a name="code-examples"></a><span data-ttu-id="dd7fb-152">コード例</span><span class="sxs-lookup"><span data-stu-id="dd7fb-152">Code examples</span></span>

<span data-ttu-id="dd7fb-153">このセクションのコード例では、[**Windows.Services.Store**](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の API を使用して現在のアプリのサブスクリプション アドオンに関する情報を取得する方法および現在のユーザーの代わりにサブスクリプション アドオンの購入を要求する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-153">The code examples in this section demonstrate how to use the APIs in the [**Windows.Services.Store**](https://docs.microsoft.com/uwp/api/windows.services.store) namespace to get info about subscription add-ons for the current app and request the purchase a subscription add-on on behalf of the current user.</span></span>

<span data-ttu-id="dd7fb-154">これらの例には、次の前提条件があります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-154">These examples have the following prerequisites:</span></span>
* <span data-ttu-id="dd7fb-155">Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-155">A Visual Studio project for a Universal Windows Platform (UWP) app that targets Windows 10, version 1607, or later.</span></span>
* <span data-ttu-id="dd7fb-156">Windows デベロッパー センター ダッシュボードで[アプリの申請を作成](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)し、このアプリがストアで公開されている。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-156">You have [created an app submission](https://msdn.microsoft.com/windows/uwp/publish/app-submissions) in the Windows Dev Center dashboard and this app is published in the Store.</span></span> <span data-ttu-id="dd7fb-157">必要に応じで、テスト中にストアでアプリを検索できないようにアプリを構成することも可能です。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-157">You can optionally configure the app so it is not discoverable in the Store while you test it.</span></span> <span data-ttu-id="dd7fb-158">詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-158">For more information, see the [testing guidance](in-app-purchases-and-trials.md#testing).</span></span>
* <span data-ttu-id="dd7fb-159">デベロッパー センター ダッシュボードで[アプリのサブスクリプション アドオンを作成](../publish/add-on-submissions.md)した。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-159">You have [created a subscription add-on for the app](../publish/add-on-submissions.md) in the Dev Center dashboard.</span></span>

<span data-ttu-id="dd7fb-160">これらの例のコードは、次の点を前提としています。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-160">The code in these examples assumes:</span></span>
* <span data-ttu-id="dd7fb-161">コードは、```workingProgressRing``` という名前の [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [**Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-161">The code runs in the context of a [**Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) that contains a [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) named ```workingProgressRing``` and a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) named ```textBlock```.</span></span> <span data-ttu-id="dd7fb-162">これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-162">These objects are used to indicate that an asynchronous operation is occurring and to display output messages, respectively.</span></span>
* <span data-ttu-id="dd7fb-163">コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-163">The code file has a **using** statement for the **Windows.Services.Store** namespace.</span></span>
* <span data-ttu-id="dd7fb-164">アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-164">The app is a single-user app that runs only in the context of the user that launched the app.</span></span> <span data-ttu-id="dd7fb-165">詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-165">For more information, see [In-app purchases and trials](in-app-purchases-and-trials.md#api_intro).</span></span>

> [!NOTE]
> <span data-ttu-id="dd7fb-166">[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用するデスクトップ アプリケーションがある場合、これらの例には示されていないコードを追加して [**StoreContext**](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-166">If you have a desktop application that uses the [Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop), you may need to add additional code not shown in these examples to configure the [**StoreContext**](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) object.</span></span> <span data-ttu-id="dd7fb-167">詳しくは、「[デスクトップ ブリッジを使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-167">For more information, see [Using the StoreContext class in a desktop application that uses the Desktop Bridge](in-app-purchases-and-trials.md#desktop).</span></span>

### <a name="get-info-about-subscription-add-ons-for-the-current-app"></a><span data-ttu-id="dd7fb-168">現在のアプリのサブスクリプション アドオンの情報の取得</span><span class="sxs-lookup"><span data-stu-id="dd7fb-168">Get info about subscription add-ons for the current app</span></span>

<span data-ttu-id="dd7fb-169">このコード例では、アプリで利用可能なサブスクリプション アドオンの情報を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-169">This code example demonstrates how to get info for the subscription add-ons that are available in your app.</span></span> <span data-ttu-id="dd7fb-170">この情報を取得するには、まず [**GetAssociatedStoreProductsAsync**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext#Windows_Services_Store_StoreContext_GetAssociatedStoreProductsAsync_) メソッドを使用して、アプリで利用可能なアドオンそれぞれを表す [**StoreProduct**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct) オブジェクトのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-170">To get this info, first use the [**GetAssociatedStoreProductsAsync**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext#Windows_Services_Store_StoreContext_GetAssociatedStoreProductsAsync_) method to get the collection of [**StoreProduct**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct) objects that represent each of the available add-ons for the app.</span></span> <span data-ttu-id="dd7fb-171">次に、各製品の [**StoreSku**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku) を取得し、[**IsSubscription**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku#Windows_Services_Store_StoreSku_IsSubscription_) プロパティと [**SubscriptionInfo**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku#Windows_Services_Store_StoreSku_SubscriptionInfo_) プロパティを使用してサブスクリプション情報にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-171">Then, get the [**StoreSku**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku) for each product and use the [**IsSubscription**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku#Windows_Services_Store_StoreSku_IsSubscription_) and [**SubscriptionInfo**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku#Windows_Services_Store_StoreSku_SubscriptionInfo_) properties to access the subscription info.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="dd7fb-172">サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="dd7fb-172">Subscriptions</span></span>](./code/InAppPurchasesAndLicenses_RS1/cs/GetSubscriptionAddOnsPage.xaml.cs#GetSubscriptions)]

### <a name="purchase-a-subscription-add-on"></a><span data-ttu-id="dd7fb-173">サブスクリプション アドオンの購入</span><span class="sxs-lookup"><span data-stu-id="dd7fb-173">Purchase a subscription add-on</span></span>

<span data-ttu-id="dd7fb-174">この例では、[**StoreProduct**](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct) クラスの [**RequestPurchaseAsync**](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct#Windows_Services_Store_StoreProduct_RequestPurchaseAsync_) メソッドを使用して、サブスクリプション アドオンを購入する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-174">This example demonstrates how to use the [**RequestPurchaseAsync**](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct#Windows_Services_Store_StoreProduct_RequestPurchaseAsync_) method of the [**StoreProduct**](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct) class to purchase a subscription add-on.</span></span> <span data-ttu-id="dd7fb-175">この例では、購入するサブスクリプション アドオンの[ストア ID](in-app-purchases-and-trials.md#store-ids) を既に知っていることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-175">This example assumes that you already know the [Store ID](in-app-purchases-and-trials.md#store-ids) of the subscription add-on you want to purchase.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="dd7fb-176">サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="dd7fb-176">Subscriptions</span></span>](./code/InAppPurchasesAndLicenses_RS1/cs/PurchaseSubscriptionAddOnPage.xaml.cs#PurchaseSubscription)]

<span id="manage-subscriptions" />
## <a name="manage-subscriptions-from-your-services"></a><span data-ttu-id="dd7fb-177">サービスからのサブスクリプションの管理</span><span class="sxs-lookup"><span data-stu-id="dd7fb-177">Manage subscriptions from your services</span></span>

<span data-ttu-id="dd7fb-178">更新したアプリがストアで公開され、ユーザーがサブスクリプション アドオンを購入できるようになったら、ユーザーのサブスクリプションの管理が必要になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-178">After your updated app is in the Store and customers can buy your subscription add-on, you may have scenarios where you need to manage the subscription for a customer.</span></span> <span data-ttu-id="dd7fb-179">サービスから呼び出して次のサブスクリプション管理タスクを実行できる REST API が用意されています。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-179">We provide REST APIs you can call from your services to perform the following subscription management tasks:</span></span>

* <span data-ttu-id="dd7fb-180">[ユーザーが使う権利を持っているサブスクリプションを取得する](get-subscriptions-for-a-user.md)。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-180">[Get the subscriptions that a user has an entitlement to use](get-subscriptions-for-a-user.md).</span></span> <span data-ttu-id="dd7fb-181">サブスクリプションがクロスプラットフォーム サービスの一部である場合は、この API を呼び出して、指定のユーザーにサブスクリプションの権利があるかどうかや、UWP アプリのコンテキストにおけるサブスクリプションの状態を判断することができます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-181">If your subscription is part of a cross-platform service, you can call this API to determine whether the specified user has an entitlement for your subscription and the status of their subscription in the context of your UWP app.</span></span> <span data-ttu-id="dd7fb-182">その後、この情報を使用して、サービスでサポートしている他のプラットフォームにおけるサブスクリプションの状態を更新できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-182">You can then use this information to update the status of the subscription on other platforms that your service supports.</span></span>

* <span data-ttu-id="dd7fb-183">[特定のユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-183">[Change the billing state of a subscription for a given user](change-the-billing-state-of-a-subscription-for-a-user.md).</span></span> <span data-ttu-id="dd7fb-184">この API を使用して、サブスクリプションの取り消し、延長、または自動更新の無効化を行えます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-184">Use this API to cancel, extend, or disable automatic renewal for a subscription.</span></span>

<span id="cancellations" />
## <a name="cancellations"></a><span data-ttu-id="dd7fb-185">取り消し</span><span class="sxs-lookup"><span data-stu-id="dd7fb-185">Cancellations</span></span>

<span data-ttu-id="dd7fb-186">ユーザーは自分の Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページを使用して、取得したサブスクリプションすべての表示、サブスクリプションの取り消し、およびサブスクリプションに関連付けられた支払方法の変更ができます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-186">Customers can use the [http://account.microsoft.com/services](http://account.microsoft.com/services) page for their Microsoft account to view all of the subscriptions they have acquired, cancel a subscription, and change the form of payment that is associated with their subscription.</span></span> <span data-ttu-id="dd7fb-187">ユーザーがこのページを使用してサブスクリプションを取り消した場合、現在の請求サイクルの期間中はサブスクリプションを引き続き利用できます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-187">When a customer cancels a subscription using this page, they continue to have access to the subscription for the duration of the current billing cycle.</span></span> <span data-ttu-id="dd7fb-188">現在の請求サイクルのどのようなタイミングにおいても、払い戻しは行われません。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-188">They do not get a refund for any part of the current billing cycle.</span></span> <span data-ttu-id="dd7fb-189">現在の請求サイクルの最後に、サブスクリプションが無効になります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-189">At the end of the current billing cycle, their subscription is deactivated.</span></span>

<span data-ttu-id="dd7fb-190">REST API を使用して、ユーザーの代わりにサブスクリプションを取り消して、[特定のユーザーのサブスクリプションに関する請求の状態を変更](change-the-billing-state-of-a-subscription-for-a-user.md)することもできます。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-190">You can also cancel a subscription on behalf of a user by using our REST API to [change the billing state of a subscription for a given user](change-the-billing-state-of-a-subscription-for-a-user.md).</span></span>

## <a name="unsupported-scenarios"></a><span data-ttu-id="dd7fb-191">サポートされていないシナリオ</span><span class="sxs-lookup"><span data-stu-id="dd7fb-191">Unsupported scenarios</span></span>

<span data-ttu-id="dd7fb-192">次のシナリオは、サブスクリプション アドオンで現在サポートされていません。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-192">The following scenarios are not currently supported for subscription add-ons.</span></span>

* <span data-ttu-id="dd7fb-193">現時点では、ストアを通じたユーザーへのサブスクリプションの直接販売はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-193">Selling subscriptions to customers directly via the Store is not supported at this time.</span></span> <span data-ttu-id="dd7fb-194">サブスクリプションはデジタル製品のアプリ内購入でのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-194">Subscriptions are available for in-app purchases of digital products only.</span></span>
* <span data-ttu-id="dd7fb-195">ユーザーが自分の Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページを使用してサブスクリプション期間を切り替えることはできません。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-195">Customers cannot switch subscription periods using the [http://account.microsoft.com/services](http://account.microsoft.com/services) page for their Microsoft account.</span></span> <span data-ttu-id="dd7fb-196">異なるサブスクリプション期間に切り替えるには、ユーザーは現在のサブスクリプションを取り消して、アプリで別のサブスクリプション期間のサブスクリプションを購入する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-196">To switch to a different subscription period, customers much cancel their current subscription and then purchase a subscription with a different subscription period from your app.</span></span>
* <span data-ttu-id="dd7fb-197">サブスクリプション アドオンでは現在、サブスクリプション レベルの切り替えはサポートされていません (たとえば、ユーザーをベーシック サブスクリプションから機能の多いプレミアム サブスクリプションに切り替えるなど)。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-197">Tier switching is currently not supported for subscription add-ons (for example, switching a customer from a basic subscription to a premium subscription with more features).</span></span>
* <span data-ttu-id="dd7fb-198">サブスクリプション アドオンでは現在、[セール](../publish/put-apps-and-add-ons-on-sale.md)と[プロモーション コード](../publish/generate-promotional-codes.md)はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="dd7fb-198">[Sales](../publish/put-apps-and-add-ons-on-sale.md) and [promotional codes](../publish/generate-promotional-codes.md) are currently not supported for subscription add-ons.</span></span>


## <a name="related-topics"></a><span data-ttu-id="dd7fb-199">関連トピック</span><span class="sxs-lookup"><span data-stu-id="dd7fb-199">Related topics</span></span>

* [<span data-ttu-id="dd7fb-200">アプリ内購入と試用版</span><span class="sxs-lookup"><span data-stu-id="dd7fb-200">In-app purchases and trials</span></span>](in-app-purchases-and-trials.md)
* [<span data-ttu-id="dd7fb-201">アプリとアドオンの製品情報の取得</span><span class="sxs-lookup"><span data-stu-id="dd7fb-201">Get product info for apps and add-ons</span></span>](get-product-info-for-apps-and-add-ons.md)