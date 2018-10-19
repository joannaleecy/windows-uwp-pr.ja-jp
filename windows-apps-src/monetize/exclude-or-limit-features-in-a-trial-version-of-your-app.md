---
author: Xansky
Description: If you enable customers to use your app for free during a trial period, you can entice your customers to upgrade to the full version of your app by excluding or limiting some features during the trial period.
title: 試用版での機能の除外または制限
ms.assetid: 1B62318F-9EF5-432A-8593-F3E095CA7056
keywords: Windows 10, UWP, 試用, アプリ内購入, IAP, Windows.ApplicationModel.Store
ms.author: mhopkins
ms.date: 08/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 18d9fb3ba5b0fbd1e964450a75d8e0e417265e7f
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4951539"
---
# <a name="exclude-or-limit-features-in-a-trial-version"></a><span data-ttu-id="6157c-103">試用版での機能の除外または制限</span><span class="sxs-lookup"><span data-stu-id="6157c-103">Exclude or limit features in a trial version</span></span>

<span data-ttu-id="6157c-104">ユーザーがアプリを無料で使うことができる試用期間を設け、その期間中は一部の機能を除外または制限することで、アプリを通常版にアップグレードするようユーザーに促すことができます。</span><span class="sxs-lookup"><span data-stu-id="6157c-104">If you enable customers to use your app for free during a trial period, you can entice your customers to upgrade to the full version of your app by excluding or limiting some features during the trial period.</span></span> <span data-ttu-id="6157c-105">どのような機能を制限するかをコーディング開始前に決め、完全なライセンスが購入されたときにだけその機能が正しく動作するようにアプリを設定します。</span><span class="sxs-lookup"><span data-stu-id="6157c-105">Determine which features should be limited before you begin coding, then make sure that your app only allows them to work when a full license has been purchased.</span></span> <span data-ttu-id="6157c-106">また、ユーザーがアプリを購入する前の試用期間中にだけバナーや透かしなどを表示する機能を有効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="6157c-106">You can also enable features, such as banners or watermarks, that are shown only during the trial, before a customer buys your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6157c-107">この記事では、[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーを使って、試用版機能を実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6157c-107">This article demonstrates how to use members of the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace to implement trial functionality.</span></span> <span data-ttu-id="6157c-108">この名前空間は更新されなくなり、新機能も追加されないため、代わりに [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6157c-108">This namespace is no longer being updated with new features, and we recommend that you use the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace instead.</span></span> <span data-ttu-id="6157c-109">**Windows.Services.Store** 名前空間は、Microsoft Store で管理されるコンシューマブルなアドオンやサブスクリプションなど、最新の種類のアドオンをサポートしており、Windows デベロッパー センターと Microsoft Store で今後サポートされる製品および機能の種類と互換性を持つように設計されています。</span><span class="sxs-lookup"><span data-stu-id="6157c-109">The **Windows.Services.Store** namespace supports the latest add-on types, such as Store-managed consumable add-ons and subscriptions, and is designed to be compatible with future types of products and features supported by Windows Dev Center and the Store.</span></span> <span data-ttu-id="6157c-110">**Windows.Services.Store** 名前空間は、Windows 10 バージョン 1607 で導入され、Visual Studio で、**Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするプロジェクトでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="6157c-110">The **Windows.Services.Store** namespace was introduced in Windows 10, version 1607, and it can only be used in projects that target **Windows 10 Anniversary Edition (10.0; Build 14393)** or a later release in Visual Studio.</span></span> <span data-ttu-id="6157c-111">**Windows.Services.Store** 名前空間を使用した試用版機能の実装について詳しくは、[この記事](implement-a-trial-version-of-your-app.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6157c-111">For more information about implementing trial functionality using the **Windows.Services.Store** namespace, see [this article](implement-a-trial-version-of-your-app.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="6157c-112">前提条件</span><span class="sxs-lookup"><span data-stu-id="6157c-112">Prerequisites</span></span>

<span data-ttu-id="6157c-113">ユーザーが購入できる機能を追加する Windows アプリ。</span><span class="sxs-lookup"><span data-stu-id="6157c-113">A Windows app in which to add features for customers to buy.</span></span>

## <a name="step-1-pick-the-features-you-want-to-enable-or-disable-during-the-trial-period"></a><span data-ttu-id="6157c-114">手順 1: 試用期間中に有効または無効にする機能を選ぶ</span><span class="sxs-lookup"><span data-stu-id="6157c-114">Step 1: Pick the features you want to enable or disable during the trial period</span></span>

<span data-ttu-id="6157c-115">アプリの現時点でのライセンスの状態は、[LicenseInformation](https://msdn.microsoft.com/library/windows/apps/br225157) クラスのプロパティとして保存されています。</span><span class="sxs-lookup"><span data-stu-id="6157c-115">The current license state of your app is stored as properties of the [LicenseInformation](https://msdn.microsoft.com/library/windows/apps/br225157) class.</span></span> <span data-ttu-id="6157c-116">通常は、次の手順で説明するように、ライセンスの状態に依存する関数を条件ブロック内に記述します。</span><span class="sxs-lookup"><span data-stu-id="6157c-116">Typically, you put the functions that depend on the license state in a conditional block, as we describe in the next step.</span></span> <span data-ttu-id="6157c-117">このような機能について検討するときには、ライセンスがどの状態であっても動作するように実装できることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="6157c-117">When considering these features, make sure you can implement them in a way that will work in all license states.</span></span>

<span data-ttu-id="6157c-118">また、アプリの実行中にライセンスが変更された場合の処理方法を決めておきます。</span><span class="sxs-lookup"><span data-stu-id="6157c-118">Also, decide how you want to handle changes to the app's license while the app is running.</span></span> <span data-ttu-id="6157c-119">試用版のアプリでもすべての機能を使うことができるようにしながら、購入版では表示されない広告バナーを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="6157c-119">Your trial app can be full-featured, but have in-app ad banners where the paid-for version doesn't.</span></span> <span data-ttu-id="6157c-120">また、試用版アプリでは一部の機能を無効にしたり、ユーザーに購入を勧めるメッセージを表示したりすることもできます。</span><span class="sxs-lookup"><span data-stu-id="6157c-120">Or, your trial app can disable certain features, or display regular messages asking the user to buy it.</span></span>

<span data-ttu-id="6157c-121">アプリの性質を考慮して、それに適した試用や有効期限の戦略を立ててください。</span><span class="sxs-lookup"><span data-stu-id="6157c-121">Think about the type of app you're making and what a good trial or expiration strategy is for it.</span></span> <span data-ttu-id="6157c-122">ゲームの試用版の場合は、ユーザーが遊べるゲーム コンテンツの量を制限するのが良い戦略でしょう。</span><span class="sxs-lookup"><span data-stu-id="6157c-122">For a trial version of a game, a good strategy is to limit the amount of game content that a user can play.</span></span> <span data-ttu-id="6157c-123">ユーティリティの試用版の場合は、有効期限日の設定や、ユーザーが使いたがるような機能の制限を検討するとよいでしょう。</span><span class="sxs-lookup"><span data-stu-id="6157c-123">For a trial version of a utility, you might consider setting an expiration date, or limiting the features that a potential buyer can use.</span></span>

<span data-ttu-id="6157c-124">ゲーム以外の多くのアプリでは、ユーザーにアプリ全体を理解してもらうために、有効期限日を設定するのが適しています。</span><span class="sxs-lookup"><span data-stu-id="6157c-124">For most non-gaming apps, setting an expiration date works well, because users can develop a good understanding of the complete app.</span></span> <span data-ttu-id="6157c-125">ここでは、有効期限に関するいくつかの一般的なシナリオと、その処理方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6157c-125">Here are a few common expiration scenarios and your options for handling them.</span></span>

-   **<span data-ttu-id="6157c-126">アプリの実行中に試用ライセンスが期限切れになった</span><span class="sxs-lookup"><span data-stu-id="6157c-126">Trial license expires while the app is running</span></span>**

    <span data-ttu-id="6157c-127">アプリの実行中に試用ライセンスが期限切れになった場合は、次の対処方法があります。</span><span class="sxs-lookup"><span data-stu-id="6157c-127">If the trial expires while your app is running, your app can:</span></span>

    -   <span data-ttu-id="6157c-128">何もしない。</span><span class="sxs-lookup"><span data-stu-id="6157c-128">Do nothing.</span></span>
    -   <span data-ttu-id="6157c-129">ユーザーにメッセージを表示する。</span><span class="sxs-lookup"><span data-stu-id="6157c-129">Display a message to your customer.</span></span>
    -   <span data-ttu-id="6157c-130">閉じる。</span><span class="sxs-lookup"><span data-stu-id="6157c-130">Close.</span></span>
    -   <span data-ttu-id="6157c-131">ユーザーにアプリの購入を促す。</span><span class="sxs-lookup"><span data-stu-id="6157c-131">Prompt your customer to buy the app.</span></span>

    <span data-ttu-id="6157c-132">お勧めするのは、アプリの購入を促すメッセージを表示することです。ユーザーがアプリを購入したら、すべての機能を有効にして、そのまま使うことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="6157c-132">The best practice is to display a message with a prompt for buying the app, and if the customer buys it, continue with all features enabled.</span></span> <span data-ttu-id="6157c-133">購入しなかった場合は、アプリを閉じるか、アプリの購入が必要なことを一定の間隔で通知します。</span><span class="sxs-lookup"><span data-stu-id="6157c-133">If the user decides not to buy the app, close it or remind them to buy the app at regular intervals.</span></span>

-   **<span data-ttu-id="6157c-134">アプリの起動前に試用ライセンスが期限切れになった</span><span class="sxs-lookup"><span data-stu-id="6157c-134">Trial license expires before the app is launched</span></span>**

    <span data-ttu-id="6157c-135">ユーザーがアプリを起動する前に試用ライセンスが期限切れになった場合、アプリは起動しません。</span><span class="sxs-lookup"><span data-stu-id="6157c-135">If the trial expires before the user launches the app, your app won't launch.</span></span> <span data-ttu-id="6157c-136">ユーザーには、ストアからそのアプリを購入できることを伝えるダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="6157c-136">Instead, users see a dialog box that gives them the option to purchase your app from the Store.</span></span>

-   **<span data-ttu-id="6157c-137">アプリの実行中にユーザーがアプリを購入した</span><span class="sxs-lookup"><span data-stu-id="6157c-137">Customer buys the app while it is running</span></span>**

    <span data-ttu-id="6157c-138">アプリの実行中にユーザーがアプリを購入した場合は、次の対処方法があります。</span><span class="sxs-lookup"><span data-stu-id="6157c-138">If the customer buys your app while it is running, here are some actions your app can take.</span></span>

    -   <span data-ttu-id="6157c-139">何もせず、アプリが再起動されるまでは試用モードを続ける。</span><span class="sxs-lookup"><span data-stu-id="6157c-139">Do nothing and let them continue in trial mode until they restart the app.</span></span>
    -   <span data-ttu-id="6157c-140">購入に対するお礼をする、またはメッセージを表示する。</span><span class="sxs-lookup"><span data-stu-id="6157c-140">Thank them for buying or display a message.</span></span>
    -   <span data-ttu-id="6157c-141">完全なライセンスがある場合に使うことができる機能を、通知なしで有効にする (または、試用版であることを示す表示を消す)。</span><span class="sxs-lookup"><span data-stu-id="6157c-141">Silently enable the features that are available with a full-license (or disable the trial-only notices).</span></span>

<span data-ttu-id="6157c-142">ライセンスの変更を検出して、アプリで対応する場合は、次の手順で説明するように、そのためのイベント ハンドラーを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157c-142">If you want to detect the license change and take some action in your app, you must add an event handler for this as described in the next step.</span></span>

## <a name="step-2-initialize-the-license-info"></a><span data-ttu-id="6157c-143">手順 2: ライセンス情報を初期化する</span><span class="sxs-lookup"><span data-stu-id="6157c-143">Step 2: Initialize the license info</span></span>

<span data-ttu-id="6157c-144">アプリを初期化するときに、この例に示すように、アプリの [LicenseInformation](https://msdn.microsoft.com/library/windows/apps/br225157) オブジェクトを取得してください。</span><span class="sxs-lookup"><span data-stu-id="6157c-144">When your app is initializing, get the [LicenseInformation](https://msdn.microsoft.com/library/windows/apps/br225157) object for your app as shown in this example.</span></span> <span data-ttu-id="6157c-145">**licenseInformation** は、**LicenseInformation** 型のグローバル変数またはフィールドと仮定します。</span><span class="sxs-lookup"><span data-stu-id="6157c-145">We assume that **licenseInformation** is a global variable or field of type **LicenseInformation**.</span></span>

<span data-ttu-id="6157c-146">ここでは、[CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) ではなく [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) を使って、シミュレートされたライセンス情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="6157c-146">For now, you will get simulated license information by using [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) instead of [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765).</span></span> <span data-ttu-id="6157c-147">アプリのリリース バージョンを **Microsoft Store** に提出する前に、コード内のすべての **CurrentAppSimulator** の参照を **CurrentApp** に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157c-147">Before you submit the release version of your app to the **Store**, you must replace all **CurrentAppSimulator** references in your code with **CurrentApp**.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[TrialVersion](./code/InAppPurchasesAndLicenses/cs/TrialVersion.cs#InitializeLicenseTest)]

<span data-ttu-id="6157c-148">次に、アプリの実行中にライセンスが変更されたときに通知を受け取るイベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="6157c-148">Next, add an event handler to receive notifications when the license changes while the app is running.</span></span> <span data-ttu-id="6157c-149">アプリのライセンスが変更されるのは、たとえば、試用期間が終了したときや、ユーザーがストアを通じてアプリを購入したときです。</span><span class="sxs-lookup"><span data-stu-id="6157c-149">The app's license could change if the trial period expires or the customer buys the app through a Store, for example.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[TrialVersion](./code/InAppPurchasesAndLicenses/cs/TrialVersion.cs#InitializeLicenseTestWithEvent)]

## <a name="step-3-code-the-features-in-conditional-blocks"></a><span data-ttu-id="6157c-150">手順 3: 条件ブロック内に機能のコードを記述する</span><span class="sxs-lookup"><span data-stu-id="6157c-150">Step 3: Code the features in conditional blocks</span></span>

<span data-ttu-id="6157c-151">ライセンスの変更のイベントが発生したときに、アプリはライセンス API を呼び出して試用の状態が変わったかどうかを判定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157c-151">When the license change event is raised, your app must call the License API to determine if the trial status has changed.</span></span> <span data-ttu-id="6157c-152">この手順のコードは、このイベントのハンドラーを構造化する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6157c-152">The code in this step shows how to structure your handler for this event.</span></span> <span data-ttu-id="6157c-153">この時点で、ユーザーがアプリを購入したら、ライセンスの状態が変わったことをユーザーに知らせることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6157c-153">At this point, if a user bought the app, it is a good practice to provide feedback to the user that the licensing status has changed.</span></span> <span data-ttu-id="6157c-154">コーディングの方法上、必要であれば、ユーザーにアプリを再起動してもらわなければならないこともあります。</span><span class="sxs-lookup"><span data-stu-id="6157c-154">You might need to ask the user to restart the app if that's how you've coded it.</span></span> <span data-ttu-id="6157c-155">ただし、この移行は可能な限りスムーズで違和感のないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157c-155">But make this transition as seamless and painless as possible.</span></span>

<span data-ttu-id="6157c-156">この例は、アプリの機能を必要に応じて有効にしたり、無効にしたりできるように、アプリのライセンス状態を判断する方法を示したものです。</span><span class="sxs-lookup"><span data-stu-id="6157c-156">This example shows how to evaluate an app's license status so that you can enable or disable a feature of your app accordingly.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[TrialVersion](./code/InAppPurchasesAndLicenses/cs/TrialVersion.cs#ReloadLicense)]

## <a name="step-4-get-an-apps-trial-expiration-date"></a><span data-ttu-id="6157c-157">手順 4: アプリの試用有効期限日を取得する</span><span class="sxs-lookup"><span data-stu-id="6157c-157">Step 4: Get an app's trial expiration date</span></span>

<span data-ttu-id="6157c-158">アプリの試用有効期限日を取得するコードを含めます。</span><span class="sxs-lookup"><span data-stu-id="6157c-158">Include code to determine the app's trial expiration date.</span></span>

<span data-ttu-id="6157c-159">この例のコードは、アプリの試用有効期限日を取得する関数を定義しています。</span><span class="sxs-lookup"><span data-stu-id="6157c-159">The code in this example defines a function to get the expiration date of the app's trial license.</span></span> <span data-ttu-id="6157c-160">ライセンスがまだ有効であれば、試用期限が切れるまでの日数で有効期限を表示します。</span><span class="sxs-lookup"><span data-stu-id="6157c-160">If the license is still valid, display the expiration date with the number of days left until the trial expires.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[TrialVersion](./code/InAppPurchasesAndLicenses/cs/TrialVersion.cs#DisplayTrialVersionExpirationTime)]

## <a name="step-5-test-the-features-using-simulated-calls-to-the-license-api"></a><span data-ttu-id="6157c-161">手順 5: ライセンス API 呼び出しをシミュレートして機能をテストする</span><span class="sxs-lookup"><span data-stu-id="6157c-161">Step 5: Test the features using simulated calls to the License API</span></span>

<span data-ttu-id="6157c-162">シミュレートされたデータを使用してアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="6157c-162">Now, test your app using simulated data.</span></span> <span data-ttu-id="6157c-163">**CurrentAppSimulator** は、%UserProfile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData にある WindowsStoreProxy.xml という XML ファイルから、テスト専用のライセンス情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="6157c-163">**CurrentAppSimulator** gets test-specific licensing info from an XML file called WindowsStoreProxy.xml, located in %UserProfile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData.</span></span> <span data-ttu-id="6157c-164">WindowsStoreProxy.xml を編集して、アプリや機能のシミュレートされた有効期限日を変更できます。</span><span class="sxs-lookup"><span data-stu-id="6157c-164">You can edit WindowsStoreProxy.xml to change the simulated expiration dates for your app and for its features.</span></span> <span data-ttu-id="6157c-165">すべてが意図したとおりに動作するように、想定されるすべての有効期限とライセンスの構成をテストします。</span><span class="sxs-lookup"><span data-stu-id="6157c-165">Test all your possible expiration and licensing configurations to make sure everything works as intended.</span></span> <span data-ttu-id="6157c-166">詳しくは、「[CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#proxy)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6157c-166">For more info, see [Using the WindowsStoreProxy.xml file with CurrentAppSimulator](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#proxy).</span></span>

<span data-ttu-id="6157c-167">このパスとファイルがない場合は、インストール時か実行時にそれらを作る必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157c-167">If this path and file don't exist, you must create them, either during installation or at run-time.</span></span> <span data-ttu-id="6157c-168">WindowsStoreProxy.xml が所定の場所にない状態で [CurrentAppSimulator.LicenseInformation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.licenseinformation) プロパティにアクセスしようとすると、エラーになります。</span><span class="sxs-lookup"><span data-stu-id="6157c-168">If you try to access the [CurrentAppSimulator.LicenseInformation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.licenseinformation) property without WindowsStoreProxy.xml present in that specific location, you will get an error.</span></span>

## <a name="step-6-replace-the-simulated-license-api-methods-with-the-actual-api"></a><span data-ttu-id="6157c-169">手順 6: シミュレートされたライセンス API メソッドを実際の API に置き換える</span><span class="sxs-lookup"><span data-stu-id="6157c-169">Step 6: Replace the simulated License API methods with the actual API</span></span>

<span data-ttu-id="6157c-170">シミュレートされたライセンス サーバーでアプリをテストした後、認定用にストアにアプリを提出する前に、**CurrentAppSimulator** を **CurrentApp** に置き換えます (次のコード例を参照)。</span><span class="sxs-lookup"><span data-stu-id="6157c-170">After you test your app with the simulated license server, and before you submit your app to a Store for certification, replace **CurrentAppSimulator** with **CurrentApp**, as shown in the next code sample.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6157c-171">アプリを Microsoft Store に提出するときには、アプリで **CurrentApp** オブジェクトを使っている必要があり、そうでない場合は認定が不合格になります。</span><span class="sxs-lookup"><span data-stu-id="6157c-171">Your app must use the **CurrentApp** object when you submit your app to a Store or it will fail certification.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[TrialVersion](./code/InAppPurchasesAndLicenses/cs/TrialVersion.cs#InitializeLicenseRetailWithEvent)]

## <a name="step-7-describe-how-the-free-trial-works-to-your-customers"></a><span data-ttu-id="6157c-172">手順 7: 無料の試用版についてユーザーに説明する</span><span class="sxs-lookup"><span data-stu-id="6157c-172">Step 7: Describe how the free trial works to your customers</span></span>

<span data-ttu-id="6157c-173">アプリの動作でユーザーが驚くことがないように、無料試用版のアプリが試用期間中にどのように機能し、期間が過ぎるとどのようになるかを必ず説明してください。</span><span class="sxs-lookup"><span data-stu-id="6157c-173">Be sure to explain how your app will behave during and after the free trial period so your customers won't be surprised by your app's behavior.</span></span>

<span data-ttu-id="6157c-174">アプリの説明について詳しくは、「[アプリの説明の作成](https://msdn.microsoft.com/library/windows/apps/mt148529)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6157c-174">For more info about describing your app, see [Create app descriptions](https://msdn.microsoft.com/library/windows/apps/mt148529).</span></span>

## <a name="related-topics"></a><span data-ttu-id="6157c-175">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6157c-175">Related topics</span></span>

* [<span data-ttu-id="6157c-176">ストア サンプル (試用版とアプリ内購入のデモンストレーション)</span><span class="sxs-lookup"><span data-stu-id="6157c-176">Store sample (demonstrates trials and in-app purchases)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)
* [<span data-ttu-id="6157c-177">アプリの価格と使用可能状況の設定</span><span class="sxs-lookup"><span data-stu-id="6157c-177">Set app pricing and availability</span></span>](https://msdn.microsoft.com/library/windows/apps/mt148548)
* [<span data-ttu-id="6157c-178">CurrentApp</span><span class="sxs-lookup"><span data-stu-id="6157c-178">CurrentApp</span></span>](https://msdn.microsoft.com/library/windows/apps/hh779765)
* [<span data-ttu-id="6157c-179">CurrentAppSimulator</span><span class="sxs-lookup"><span data-stu-id="6157c-179">CurrentAppSimulator</span></span>](https://msdn.microsoft.com/library/windows/apps/hh779766)
 

 
