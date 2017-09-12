---
author: jnHs
Description: "Windows デベロッパー センター ダッシュボードで各アプリに関連する詳細を管理および表示し、通知、A/B テスト、マップなどのサービスを構成します。"
title: "アプリの管理とサービス"
ms.assetid: 99DA2BC1-9B5D-4746-8BC0-EC723D516EEF
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 2ff75a5e85a37f4f47b6b32f3e8338524752bb2f
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="app-management-and-services"></a><span data-ttu-id="f1fe8-104">アプリの管理とサービス</span><span class="sxs-lookup"><span data-stu-id="f1fe8-104">App management and services</span></span>

<span data-ttu-id="f1fe8-105">Windows デベロッパー センター ダッシュボードで各アプリに関連する詳細を管理および表示し、通知、A/B テスト、マップなどのサービスを構成できます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-105">You can manage and view details related to each of your apps in the Windows Dev Center dashboard, and configure services such as notifications, A/B testing, and maps.</span></span>

<span data-ttu-id="f1fe8-106">ダッシュボードでアプリを操作するとき、左側のナビゲーション メニューに **[サービス]** と **[アプリ管理]** のセクションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-106">When working with an app in your dashboard, you'll see sections in the left navigation menu for **Services** and **App management**.</span></span> <span data-ttu-id="f1fe8-107">これらのセクションを展開すると、次の機能にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-107">You can expand these sections to access the functionality described below.</span></span>

## <a name="services"></a><span data-ttu-id="f1fe8-108">サービス</span><span class="sxs-lookup"><span data-stu-id="f1fe8-108">Services</span></span>

<span data-ttu-id="f1fe8-109">**[サービス]** セクションでは、アプリのいくつかの異なるサービスを管理できます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-109">The **Services** section lets you manage several different services for your apps.</span></span>

## <a name="push-notifications"></a><span data-ttu-id="f1fe8-110">プッシュ通知</span><span class="sxs-lookup"><span data-stu-id="f1fe8-110">Push notifications</span></span>

<span data-ttu-id="f1fe8-111">**[プッシュ通知]** セクションでは、通知を作成してアプリのユーザーに送信できます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-111">The **Push notifications** section lets you create and send notifications to your app's customers.</span></span> <span data-ttu-id="f1fe8-112">すべてのアプリのユーザーにプッシュ通知を送信することも、[顧客セグメント](create-customer-segments.md)で定義した基準を満たす、Windows 10 ユーザーのサブセットを対象にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-112">You can send them to all of your app's customers, or you can target a subset of your Windows 10 customers who meet the criteria you’ve defined in a [customer segment](create-customer-segments.md).</span></span> <span data-ttu-id="f1fe8-113">詳しくは、「[アプリのユーザーに通知を送信する](send-push-notifications-to-your-apps-customers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-113">For more info, see [Send notifications to your app's customers](send-push-notifications-to-your-apps-customers.md).</span></span>

<span data-ttu-id="f1fe8-114">アプリのパッケージの種類とその具体的な要件に応じて、左側のナビゲーション メニューの **[WNS/MPNS]** をクリックし、プッシュ通知の次のいずれかのオプションを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-114">Depending on your app's package type and its specific requirements, you can also use one of the following options for push notifications by clicking **WNS/MPNS** in the left navigation menu:</span></span> 

-   <span data-ttu-id="f1fe8-115">**Windows プッシュ通知サービス** を使うと、独自のクラウド サービスからトースト更新、タイル更新、バッジ更新、直接更新を送ることができます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-115">**Windows Push Notification Services (WNS)** lets you send toast, tile, badge, and raw updates from your own cloud service.</span></span> <span data-ttu-id="f1fe8-116">詳しくは、「[Windows プッシュ通知サービスの概要](https://msdn.microsoft.com/library/windows/apps/mt187203)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-116">For more info, see [Windows Push Notification Services (WNS) overview](https://msdn.microsoft.com/library/windows/apps/mt187203).</span></span>

-   <span data-ttu-id="f1fe8-117">**Microsoft Azure Mobile Apps** を使うと、プッシュ通知の送信や、アプリ ユーザーの認証や管理、クラウドでのアプリ データの保存をすることができます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-117">**Microsoft Azure Mobile Apps** lets you send push notifications, authenticate and manage app users, and store app data in the cloud.</span></span> <span data-ttu-id="f1fe8-118">詳しくは、[モバイル アプリに関するドキュメント](http://go.microsoft.com/fwlink/p/?LinkId=221116)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-118">For more info, see the [Mobile Apps documentation](http://go.microsoft.com/fwlink/p/?LinkId=221116).</span></span>

-   <span data-ttu-id="f1fe8-119">**Microsoft プッシュ通知サービス (MPNS)** は、Windows Phone の .xap パッケージと一緒に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-119">**Microsoft Push Notifications Service (MPNS)** can be used with your .xap packages for Windows Phone.</span></span> <span data-ttu-id="f1fe8-120">ここで構成を行わなくても、認証されていない通知を限られた数送信することができますが、制限が減らないように認証済みの通知を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-120">You can send a limited number of unauthenticated notifications without doing any configuration here, although we recommend using authenticated notifications to avoid throttling limits.</span></span> <span data-ttu-id="f1fe8-121">MPNS を使っている場合、**[プッシュ通知]** のフィールドに証明書をアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-121">If you're using MPNS, you'll need to upload a certificate to the field provided on the **Push notifications** page.</span></span> <span data-ttu-id="f1fe8-122">詳しくは、「[Windows Phone 8 のプッシュ通知を送信するように認証済み Web サービスを設定する](http://go.microsoft.com/fwlink/p/?LinkId=528736)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-122">For more info, see [Setting up an authenticated web service to send push notifications for Windows Phone 8](http://go.microsoft.com/fwlink/p/?LinkId=528736).</span></span>

## <a name="experimentation"></a><span data-ttu-id="f1fe8-123">Experimentation</span><span class="sxs-lookup"><span data-stu-id="f1fe8-123">Experimentation</span></span>

<span data-ttu-id="f1fe8-124">**[Experimentation]** ページを使うと、ユニバーサル Windows プラットフォーム (UWP) アプリの試験的機能を作成し、A/B テストを実行できます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-124">Use the **Experimentation** page to create and run experiments for your Universal Windows Platform (UWP) apps with A/B testing.</span></span> <span data-ttu-id="f1fe8-125">アプリの機能の変更をすべてのユーザー向けに有効にする前に、一部のユーザーに対して変更 (またはバリエーション) の有効性を A/B テストで測定します。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-125">In an A/B test, you measure the effectiveness of feature changes (or variations) in your app on some customers before you enable the changes for everyone.</span></span>

<span data-ttu-id="f1fe8-126">詳しくは、「[A/B テストを使用してアプリの試験的機能を実行する](../monetize/run-app-experiments-with-a-b-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-126">For more info, see [Run app experiments with A/B testing](../monetize/run-app-experiments-with-a-b-testing.md).</span></span>

## <a name="maps"></a><span data-ttu-id="f1fe8-127">マップ</span><span class="sxs-lookup"><span data-stu-id="f1fe8-127">Maps</span></span>

<span data-ttu-id="f1fe8-128">Windows Phone 8.1 以前を対象としたアプリでマップ サービスを使うには、アプリのコードに含めるマップ サービス アプリケーション ID とトークンが必要です。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-128">To use map services in apps for Windows Phone 8.1 and earlier, you need a map service application ID and a token to include in your app's code.</span></span> <span data-ttu-id="f1fe8-129">**[マップ]** ページの **[サービス]** セクションでこのトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-129">You can get this token on the **Maps** page in the **Services** section.</span></span>

> [!NOTE]
> <span data-ttu-id="f1fe8-130">Windows 10 または Windows 8.x を対象としたアプリでマップ サービスを使うには、[Bing 地図デベロッパー センター](http://go.microsoft.com/fwlink/p/?LinkId=614880)にアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-130">To use map services in apps targeting Windows 10 or Windows 8.x, visit the [Bing Maps Dev Center](http://go.microsoft.com/fwlink/p/?LinkId=614880).</span></span> <span data-ttu-id="f1fe8-131">詳しくは、「[マップ認証キーの要求](https://msdn.microsoft.com/library/windows/apps/mt219694)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-131">See [Request a maps authentication key](https://msdn.microsoft.com/library/windows/apps/mt219694) for more info.</span></span>

<span data-ttu-id="f1fe8-132">詳しくは、「[マップ サービスの使用](use-map-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-132">For more info, see [Use map services](use-map-services.md).</span></span>

## <a name="product-collections-and-purchases"></a><span data-ttu-id="f1fe8-133">製品のコレクションと購入</span><span class="sxs-lookup"><span data-stu-id="f1fe8-133">Product collections and purchases</span></span>

<span data-ttu-id="f1fe8-134">Windows ストア コレクション API と Windows ストア購入 API を使用してアプリとアドオンの所有者情報にアクセスするには、関連する Azure AD クライアント ID をここに入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-134">To use the Windows Store collection API and the Windows Store purchase API to access ownership information for apps and add-ons, you need to enter the associated Azure AD client IDs here.</span></span> <span data-ttu-id="f1fe8-135">これらの変更が有効になるまで最大で 16 時間かかることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-135">Note that it may take up to 16 hours for these changes to take effect.</span></span>

<span data-ttu-id="f1fe8-136">詳しくは、「[サービスから製品の権利を管理する](../monetize/view-and-grant-products-from-a-service.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-136">For more info, see [Manage product entitlements from a service](../monetize/view-and-grant-products-from-a-service.md).</span></span>

## <a name="app-management"></a><span data-ttu-id="f1fe8-137">アプリ管理</span><span class="sxs-lookup"><span data-stu-id="f1fe8-137">App management</span></span>

<span data-ttu-id="f1fe8-138">**[アプリ管理]** セクションでは、ID とパッケージの詳細を確認したり、アプリの名前を管理したりできます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-138">The **App management** section lets you view identity and package details and manage names for your app.</span></span>

## <a name="app-identity"></a><span data-ttu-id="f1fe8-139">アプリ ID</span><span class="sxs-lookup"><span data-stu-id="f1fe8-139">App identity</span></span>

<span data-ttu-id="f1fe8-140">このページには、アプリの登録情報へのリンクの URL など、ストア内のアプリの一意の ID に関連する詳細情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-140">This page shows you details related to your app's unique identity within the Store, including the URL(s) to link to your app's listing.</span></span>

<span data-ttu-id="f1fe8-141">詳しくは、「[アプリ ID の詳細の表示](view-app-identity-details.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-141">For more info, see [View app identity details](view-app-identity-details.md).</span></span>

## <a name="manage-app-names"></a><span data-ttu-id="f1fe8-142">アプリ名の管理</span><span class="sxs-lookup"><span data-stu-id="f1fe8-142">Manage app names</span></span>

<span data-ttu-id="f1fe8-143">ここでは、アプリのために予約したすべての名前を確認できます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-143">This is where you can view all of the names that you've reserved for your app.</span></span> <span data-ttu-id="f1fe8-144">追加の名前の予約や、使わなくなったの名前の削除は、ここで行うことができます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-144">You can reserve additional names here, or delete names you're no longer using.</span></span>

<span data-ttu-id="f1fe8-145">詳しくは、「[アプリ名の管理](manage-app-names.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-145">For more info, see [Manage app names](manage-app-names.md).</span></span>

## <a name="current-packages"></a><span data-ttu-id="f1fe8-146">現在のパッケージ</span><span class="sxs-lookup"><span data-stu-id="f1fe8-146">Current packages</span></span>

<span data-ttu-id="f1fe8-147">このページでは、公開されたすべてのパッケージに関連する詳しい情報を確認することができます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-147">This page lets you view details related to all of your published packages.</span></span>

> [!NOTE]
> <span data-ttu-id="f1fe8-148">ここには、アプリが公開されるまで、情報は表示されません。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-148">You won't see any info here until your app has been published.</span></span>

<span data-ttu-id="f1fe8-149">各パッケージの名前、バージョン、およびアーキテクチャが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-149">The name, version, and architecture of each package is shown.</span></span> <span data-ttu-id="f1fe8-150">**[詳細]** をクリックすると、サポートされる言語、アプリの機能、ファイル サイズなどの詳しい情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-150">Click **Details** to show additional info such as supported language, app capabilities, and file sizes.</span></span> <span data-ttu-id="f1fe8-151">パッケージごとに表示される情報は、対象となるオペレーティング システムとその他の要因によって異なることがあります。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-151">The info you see for each package may vary depending on its targeted operating system and other factors.</span></span> 

<span data-ttu-id="f1fe8-152">OEM アクセス許可を持つ開発者は、**[現在のパッケージ]** ページから [プレインストール パッケージを生成](generate-preinstall-packages-for-oems.md) することもできます。</span><span class="sxs-lookup"><span data-stu-id="f1fe8-152">Developers with OEM permissions can also [generate preinstall packages](generate-preinstall-packages-for-oems.md) from the **Current packages** page.</span></span>

 

 
