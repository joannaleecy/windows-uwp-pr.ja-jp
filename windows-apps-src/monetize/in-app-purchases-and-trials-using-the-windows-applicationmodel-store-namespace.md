---
author: mcleanbyron
ms.assetid: 32572890-26E3-4FBB-985B-47D61FF7F387
description: "Windows 10 バージョン 1607 より前のリリースを対象とする UWP アプリでのアプリ内購入と試用版を有効にする方法を説明します。"
title: "Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "UWP, アプリ内購入, IAP, アドオン, 試用版, Windows.ApplicationModel.Store"
ms.openlocfilehash: 06ee6eba5e4dc2f13b1ca8f8555b0e29770d1ec8
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="in-app-purchases-and-trials-using-the-windowsapplicationmodelstore-namespace"></a><span data-ttu-id="23a28-104">Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版</span><span class="sxs-lookup"><span data-stu-id="23a28-104">In-app purchases and trials using the Windows.ApplicationModel.Store namespace</span></span>

<span data-ttu-id="23a28-105">[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーを使って、ユニバーサル Windows プラットフォーム (UWP) アプリにアプリ内購入機能や試用版機能を追加し、アプリの収益化に役立てることができます。</span><span class="sxs-lookup"><span data-stu-id="23a28-105">You can use members in the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace to add in-app purchases and trial functionality to your Universal Windows Platform (UWP) app to help monetize your app.</span></span> <span data-ttu-id="23a28-106">このような API では、アプリのライセンス情報にもアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="23a28-106">These APIs also provide access to the license info for your app.</span></span>

<span data-ttu-id="23a28-107">このセクションの記事では、いくつかの一般的なシナリオにおいて **Windows.ApplicationModel.Store** 名前空間のメンバーを使用するための詳しいガイダンスとコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="23a28-107">The articles in this section provide in-depth guidance and code examples for using the members in the **Windows.ApplicationModel.Store** namespace for several common scenarios.</span></span> <span data-ttu-id="23a28-108">UWP アプリのアプリ内での購入に関する基本概念の概要については、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-108">For an overview of basic concepts related to in-app purchases in UWP apps, see [In-app purchases and trials](in-app-purchases-and-trials.md).</span></span>

<span data-ttu-id="23a28-109">**Windows.ApplicationModel.Store** 名前空間を使用した試用版とアプリ内購入の実装方法を示す完全なサンプルについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-109">For a complete sample that demonstrates how to implement trials and in-app purchases using the **Windows.ApplicationModel.Store** namespace, see the [Store sample](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store).</span></span>

> [!NOTE]
> <span data-ttu-id="23a28-110">アプリが Windows 10 バージョン 1607 以降をターゲットとする場合は、**Windows.ApplicationModel.Store** 名前空間ではなく、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間のメンバーを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23a28-110">If your app targets Windows 10, version 1607, or later, we recommend that you use members of the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace instead of the **Windows.ApplicationModel.Store** namespace.</span></span> <span data-ttu-id="23a28-111">**Windows.Services.Store** 名前空間は、ストアで管理されるコンシューマブルなアドオンなど、最新の種類のアドオンをサポートしており、Windows デベロッパー センターとストアで今後サポートされる製品および機能の種類と互換性を持つように設計されています。</span><span class="sxs-lookup"><span data-stu-id="23a28-111">The **Windows.Services.Store** namespace supports the latest add-on types, such as Store-managed consumable add-ons, and is designed to be compatible with future types of products and features supported by Windows Dev Center and the Store.</span></span> <span data-ttu-id="23a28-112">**Windows.Services.Store** 名前空間は、パフォーマンスの向上も考えた作りになっています。</span><span class="sxs-lookup"><span data-stu-id="23a28-112">The **Windows.Services.Store** namespace is also designed to have better performance.</span></span> <span data-ttu-id="23a28-113">詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-113">For more information, see [In-app purchases and trials](in-app-purchases-and-trials.md).</span></span>

> [!NOTE]
> <span data-ttu-id="23a28-114">**Windows.ApplicationModel.Store** 名前空間は、[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用する Windows デスクトップ アプリケーションではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="23a28-114">The **Windows.ApplicationModel.Store** namespace is not supported in Windows desktop applications that use the [Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop).</span></span> <span data-ttu-id="23a28-115">このようなアプリケーションでは、**Windows.Services.Store** 名前空間を使用して、アプリ内購入と試用版を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-115">These applications must use the **Windows.Services.Store** namespace to implement in-app purchases and trials.</span></span>

## <a name="get-started-with-the-currentapp-and-currentappsimulator-classes"></a><span data-ttu-id="23a28-116">CurrentApp クラスと CurrentAppSimulator クラスの概要</span><span class="sxs-lookup"><span data-stu-id="23a28-116">Get started with the CurrentApp and CurrentAppSimulator classes</span></span>

<span data-ttu-id="23a28-117">**Windows.ApplicationModel.Store** 名前空間へのメイン エントリ ポイントは、[CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) クラスです。</span><span class="sxs-lookup"><span data-stu-id="23a28-117">The main entry point to the **Windows.ApplicationModel.Store** namespace is the [CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) class.</span></span> <span data-ttu-id="23a28-118">このクラスには、現在のアプリとその利用可能なアドオンに関する情報の取得、現在のアプリまたはそのアドオンに関するライセンス情報の取得、現在のユーザー向けのアプリまたはアドオンの購入、およびその他のタスクを行う際に使用できる静的プロパティおよびメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="23a28-118">This class provides static properties and methods you can use to get info for the current app and its available add-ons, get license info for the current app or its add-ons, purchase an app or add-on for the current user, and perform other tasks.</span></span>

<span data-ttu-id="23a28-119">[CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) クラスは Windows ストアからデータを取得するため、アプリ内でこのクラスを使うには、開発者が開発者アカウントを持ち、アプリがストアで公開されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-119">The [CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) class obtains its data from the Windows Store, so you must have a developer account and the app must be published in the Store before you can successfully use this class in your app.</span></span> <span data-ttu-id="23a28-120">アプリをまだストアに提出していない場合は、このクラスのシミュレートされたバージョンである [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) を使ってコードをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="23a28-120">Before you submit your app to the Store, you can test your code with a simulated version of this class called [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx).</span></span> <span data-ttu-id="23a28-121">アプリのテストを完了した後は、Windows ストアに提出する前に **CurrentAppSimulator** のインスタンスを **CurrentApp** に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-121">After you test your app, and before you submit it to the Windows Store, you must replace the instances of **CurrentAppSimulator** with **CurrentApp**.</span></span> <span data-ttu-id="23a28-122">アプリで **CurrentAppSimulator** が使用されている場合は、認定が不合格になります。</span><span class="sxs-lookup"><span data-stu-id="23a28-122">Your app will fail certification if it uses **CurrentAppSimulator**.</span></span>

<span data-ttu-id="23a28-123">**CurrentAppSimulator** を使う場合、アプリのライセンスとアプリ内製品の初期状態は、開発コンピューター上にある WindowsStoreProxy.xml という名前のローカル ファイルに記述されています。</span><span class="sxs-lookup"><span data-stu-id="23a28-123">When the **CurrentAppSimulator** is used, the initial state of your app's licensing and in-app products is described in a local file on your development computer named WindowsStoreProxy.xml.</span></span> <span data-ttu-id="23a28-124">このファイルについて詳しくは、「[CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用](#proxy)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-124">For more information about this file, see [Using the WindowsStoreProxy.xml file with CurrentAppSimulator](#proxy).</span></span>

<span data-ttu-id="23a28-125">**CurrentApp** と **CurrentAppSimulator** を使って実行できる一般的なタスクについて詳しくは、次の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-125">For more information about common tasks you can perform using **CurrentApp** and **CurrentAppSimulator**, see the following articles.</span></span>

| <span data-ttu-id="23a28-126">トピック</span><span class="sxs-lookup"><span data-stu-id="23a28-126">Topic</span></span>       | <span data-ttu-id="23a28-127">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-127">Description</span></span>                 |
|----------------------------|-----------------------------|
| [<span data-ttu-id="23a28-128">試用版での機能の除外または制限</span><span class="sxs-lookup"><span data-stu-id="23a28-128">Exclude or limit features in a trial version</span></span>](exclude-or-limit-features-in-a-trial-version-of-your-app.md) | <span data-ttu-id="23a28-129">ユーザーがアプリを無料で使うことができる試用期間を設け、その期間中は一部の機能を除外または制限することで、アプリを通常版にアップグレードするようユーザーに促すことができます。</span><span class="sxs-lookup"><span data-stu-id="23a28-129">If you enable customers to use your app for free during a trial period, you can entice your customers to upgrade to the full version of your app by excluding or limiting some features during the trial period.</span></span> |
| [<span data-ttu-id="23a28-130">アプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="23a28-130">Enable in-app product purchases</span></span>](enable-in-app-product-purchases.md)      |  <span data-ttu-id="23a28-131">アプリが無料であるかどうかにかかわらず、コンテンツ、その他のアプリ、アプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-131">Whether your app is free or not, you can sell content, other apps, or new app functionality (such as unlocking the next level of a game) from right within the app.</span></span> <span data-ttu-id="23a28-132">ここでは、アプリ内で製品を販売できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="23a28-132">Here we show you how to enable these products in your app.</span></span>  |
| [<span data-ttu-id="23a28-133">コンシューマブルなアプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="23a28-133">Enable consumable in-app product purchases</span></span>](enable-consumable-in-app-product-purchases.md)      | <span data-ttu-id="23a28-134">ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-134">Offer consumable in-app products—items that can be purchased, used, and purchased again—through the Store commerce platform to provide your customers with a purchase experience that is both robust and reliable.</span></span> <span data-ttu-id="23a28-135">これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="23a28-135">This is especially useful for things like in-game currency (gold, coins, etc.) that can be purchased and then used to purchase specific power-ups.</span></span> |
| [<span data-ttu-id="23a28-136">アプリ内製品の大規模なカタログの管理</span><span class="sxs-lookup"><span data-stu-id="23a28-136">Manage a large catalog of in-app products</span></span>](manage-a-large-catalog-of-in-app-products.md)      |   <span data-ttu-id="23a28-137">アプリ内製品のカタログが大きくなる場合、カタログを管理するためにこのトピックで説明するプロセスを採用できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-137">If your app offers a large in-app product catalog, you can optionally follow the process described in this topic to help manage your catalog.</span></span>    |
| [<span data-ttu-id="23a28-138">受領通知を使った製品購入の確認</span><span class="sxs-lookup"><span data-stu-id="23a28-138">Use receipts to verify product purchases</span></span>](use-receipts-to-verify-product-purchases.md)      |   <span data-ttu-id="23a28-139">製品購入が成功した各 Windows ストアのトランザクションでは、必要に応じてトランザクションの通知を返し、掲載製品と料金についての情報をユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-139">Each Windows Store transaction that results in a successful product purchase can optionally return a transaction receipt that provides information about the listed product and monetary cost to the customer.</span></span> <span data-ttu-id="23a28-140">この情報は、ユーザーがアプリを購入したことや、Windows ストアからアプリ内製品の購入が行われたことをアプリで確認する必要がある場合などに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="23a28-140">Having access to this information supports scenarios where your app needs to verify that a user purchased your app, or has made in-app product purchases from the Windows Store.</span></span> |

<span id="proxy" />
## <a name="using-the-windowsstoreproxyxml-file-with-currentappsimulator"></a><span data-ttu-id="23a28-141">CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用</span><span class="sxs-lookup"><span data-stu-id="23a28-141">Using the WindowsStoreProxy.xml file with CurrentAppSimulator</span></span>

<span data-ttu-id="23a28-142">**CurrentAppSimulator** を使う場合、アプリのライセンスとアプリ内製品の初期状態は、開発コンピューター上にある WindowsStoreProxy.xml という名前のローカル ファイルに記述されています。</span><span class="sxs-lookup"><span data-stu-id="23a28-142">When the **CurrentAppSimulator** is used, the initial state of your app's licensing and in-app products is described in a local file on your development computer named WindowsStoreProxy.xml.</span></span> <span data-ttu-id="23a28-143">**CurrentAppSimulator** メソッドは、ライセンスの購入やアプリ内での購入処理などに応じてアプリの状態を変更しますが、更新されるのはメモリ内の **CurrentAppSimulator** オブジェクトの状態のみです。</span><span class="sxs-lookup"><span data-stu-id="23a28-143">**CurrentAppSimulator** methods that alter the app's state, for example by buying a license or handling an in-app purchase, only update the state of the **CurrentAppSimulator** object in memory.</span></span> <span data-ttu-id="23a28-144">WindowsStoreProxy.xml の内容は変更されません。</span><span class="sxs-lookup"><span data-stu-id="23a28-144">The contents of WindowsStoreProxy.xml are not changed.</span></span> <span data-ttu-id="23a28-145">アプリを再起動すると、ライセンスの状態は、WindowsStoreProxy.xml に記述されている内容に戻ります。</span><span class="sxs-lookup"><span data-stu-id="23a28-145">When the app starts again, the license state reverts to what is described in WindowsStoreProxy.xml.</span></span>

<span data-ttu-id="23a28-146">WindowsStoreProxy.xml ファイルは、既定で %UserProfile%\AppData\Local\Packages\\&lt;Local\Packages&gt;\LocalState\Microsoft\Windows Store\ApiData に作成されます。</span><span class="sxs-lookup"><span data-stu-id="23a28-146">A WindowsStoreProxy.xml file is created by default at the following location: %UserProfile%\AppData\Local\Packages\\&lt;app package folder&gt;\LocalState\Microsoft\Windows Store\ApiData.</span></span> <span data-ttu-id="23a28-147">このファイルを編集して、シミュレートするシナリオを **CurrentAppSimulator** プロパティで定義できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-147">You can edit this file to define the scenario that you want to simulate in the **CurrentAppSimulator** properties.</span></span>

<span data-ttu-id="23a28-148">このファイルの値を変更することは可能ですが、直接変更するのではなく、独自の WindowsStoreProxy.xml ファイルを (Visual Studio プロジェクトのデータ フォルダーに) 作成し、**CurrentAppSimulator** で使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23a28-148">Although you can modify the values in this file, we recommend that you create your own WindowsStoreProxy.xml file (in a data folder of your Visual Studio project) for **CurrentAppSimulator** to use instead.</span></span> <span data-ttu-id="23a28-149">トランザクションをシミュレートするには、[ReloadSimulatorAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.reloadsimulatorasync.aspx) を呼び出して、作成したファイルを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="23a28-149">When simulating the transaction, call [ReloadSimulatorAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.reloadsimulatorasync.aspx) to load your file.</span></span> <span data-ttu-id="23a28-150">**ReloadSimulatorAsync** を呼び出して独自の WindowsStoreProxy.xml ファイルを読み込まない場合、**CurrentAppSimulator** は既定の WindowsStoreProxy.xml ファイルを作成して読み込みます (上書きはしません)。</span><span class="sxs-lookup"><span data-stu-id="23a28-150">If you do not call **ReloadSimulatorAsync** to load your own WindowsStoreProxy.xml file, **CurrentAppSimulator** will create/load (but not overwrite) the default WindowsStoreProxy.xml file.</span></span>

> [!NOTE]
> <span data-ttu-id="23a28-151">**CurrentAppSimulator** は、**ReloadSimulatorAsync** が完了するまで完全には初期化されません。</span><span class="sxs-lookup"><span data-stu-id="23a28-151">Be aware that **CurrentAppSimulator** is not fully initialized until **ReloadSimulatorAsync** completes.</span></span> <span data-ttu-id="23a28-152">**ReloadSimulatorAsync** は非同期メソッドであるため、1 つのスレッドで **CurrentAppSimulator** が照会されているときに、別のスレッドでそれが初期化されているといった競合状態が起こらないように注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-152">And, since **ReloadSimulatorAsync** is an asynchronous method, care should be taken to avoid the race condition of querying **CurrentAppSimulator** on one thread while it is being initialized on another.</span></span> <span data-ttu-id="23a28-153">これにはフラグを使って初期化の完了を示すのも 1 つの方法です。</span><span class="sxs-lookup"><span data-stu-id="23a28-153">One technique is to use a flag to indicate that initialization is complete.</span></span> <span data-ttu-id="23a28-154">Windows ストアからインストールされるアプリは、**CurrentAppSimulator** ではなく **CurrentApp** を使う必要があります。これにより、**ReloadSimulatorAsync** を呼び出すことがなくなり、そのような競合状態が発生しなくなります。</span><span class="sxs-lookup"><span data-stu-id="23a28-154">An app that is installed from the Windows Store must use **CurrentApp** instead of **CurrentAppSimulator**, and in that case **ReloadSimulatorAsync** is not called and therefore the race condition just mentioned does not apply.</span></span> <span data-ttu-id="23a28-155">このため、コードは同期と非同期の両方で動作するように設計する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-155">For this reason, design your code so that it will work in both cases, both asychronously and synchronously.</span></span>


<span id="proxy-examples" />
### <a name="examples"></a><span data-ttu-id="23a28-156">例</span><span class="sxs-lookup"><span data-stu-id="23a28-156">Examples</span></span>

<span data-ttu-id="23a28-157">以下の例では、試用モードのアプリを記述する WindowsStoreProxy.xml ファイル (UTF-16 エンコード) を示します。このアプリは、2015 年 1 月 19 日午前 5 時 (UTC) に試用モードの有効期限が切れます。</span><span class="sxs-lookup"><span data-stu-id="23a28-157">This example is a WindowsStoreProxy.xml file (UTF-16 encoded) that describes an app with a trial mode that expires at 05:00 (UTC) on Jan. 19, 2015.</span></span>

> [!div class="tabbedCodeSnippets"]
```xml
<?xml version="1.0" encoding="UTF-16"?>
<CurrentApp>
  <ListingInformation>
    <App>
      <AppId>2B14D306-D8F8-4066-A45B-0FB3464C67F2</AppId>
      <LinkUri>http://apps.windows.microsoft.com/app/2B14D306-D8F8-4066-A45B-0FB3464C67F2</LinkUri>
      <CurrentMarket>en-US</CurrentMarket>
      <AgeRating>3</AgeRating>
      <MarketData xml:lang="en-us">
        <Name>App with a trial license</Name>
        <Description>Sample app for demonstrating trial license management</Description>
        <Price>4.99</Price>
        <CurrencySymbol>$</CurrencySymbol>
      </MarketData>
    </App>
  </ListingInformation>
  <LicenseInformation>
    <App>
      <IsActive>true</IsActive>
      <IsTrial>true</IsTrial>
      <ExpirationDate>2015-01-19T05:00:00.00Z</ExpirationDate>
    </App>
  </LicenseInformation>
  <Simulation SimulationMode="Automatic">
    <DefaultResponse MethodName="LoadListingInformationAsync_GetResult" HResult="E_FAIL"/>
  </Simulation>
</CurrentApp>
```

<span data-ttu-id="23a28-158">次の例では、購入済みのアプリを記述する WindowsStoreProxy.xml ファイル (UTF-16 エンコード) を示します。このアプリには、2015 年 1 月 19 日午前 5 時 (UTC) に有効期限が切れる機能と、コンシューマブルなアプリ内での購入があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-158">The next example is a WindowsStoreProxy.xml file (UTF-16 encoded) that describes an app that has been purchased, has a feature that expires at 05:00 (UTC) on Jan. 19, 2015, and has a consumable in-app purchase.</span></span>

> [!div class="tabbedCodeSnippets"]
```xml
<?xml version="1.0" encoding="utf-16" ?>
<CurrentApp>
  <ListingInformation>
    <App>
      <AppId>988b90e4-5d4d-4dea-99d0-e423e414ffbc</AppId>
      <LinkUri>http://apps.windows.microsoft.com/app/988b90e4-5d4d-4dea-99d0-e423e414ffbc</LinkUri>
      <CurrentMarket>en-us</CurrentMarket>
      <AgeRating>3</AgeRating>
      <MarketData xml:lang="en-us">
        <Name>App with several in-app products</Name>
        <Description>Sample app for demonstrating an expiring in-app product and a consumable in-app product</Description>
        <Price>5.99</Price>
        <CurrencySymbol>$</CurrencySymbol>
      </MarketData>
    </App>
    <Product ProductId="feature1" LicenseDuration="10" ProductType="Durable">
      <MarketData xml:lang="en-us">
        <Name>Expiring Item</Name>
        <Price>1.99</Price>
        <CurrencySymbol>$</CurrencySymbol>
      </MarketData>
    </Product>
    <Product ProductId="consumable1" LicenseDuration="0" ProductType="Consumable">
      <MarketData xml:lang="en-us">
        <Name>Consumable Item</Name>
        <Price>2.99</Price>
        <CurrencySymbol>$</CurrencySymbol>
      </MarketData>
    </Product>
  </ListingInformation>
  <LicenseInformation>
    <App>
      <IsActive>true</IsActive>
      <IsTrial>false</IsTrial>
    </App>
    <Product ProductId="feature1">
      <IsActive>true</IsActive>
      <ExpirationDate>2015-01-19T00:00:00.00Z</ExpirationDate>
    </Product>
  </LicenseInformation>
  <ConsumableInformation>
    <Product ProductId="consumable1" TransactionId="00000001-0000-0000-0000-000000000000" Status="Active"/>
  </ConsumableInformation>
</CurrentApp>
```


<span id="proxy-schema" />
### <a name="schema"></a><span data-ttu-id="23a28-159">スキーマ</span><span class="sxs-lookup"><span data-stu-id="23a28-159">Schema</span></span>

<span data-ttu-id="23a28-160">このセクションでは、WindowsStoreProxy.xml ファイルの構造を定義する XSD ファイルを示します。</span><span class="sxs-lookup"><span data-stu-id="23a28-160">This section lists the XSD file that defines the structure of the WindowsStoreProxy.xml file.</span></span> <span data-ttu-id="23a28-161">WindowsStoreProxy.xml ファイルで作業するときに、このスキーマを Visual Studio の XML エディターに適用するには、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="23a28-161">To apply this schema to the XML editor in Visual Studio when working with your WindowsStoreProxy.xml file, do the following:</span></span>

1. <span data-ttu-id="23a28-162">Visual Studio で WindowsStoreProxy.xml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="23a28-162">Open the WindowsStoreProxy.xml file in Visual Studio.</span></span>
2. <span data-ttu-id="23a28-163">**[XML]** メニューの **[スキーマの作成]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="23a28-163">On the **XML** menu, click **Create Schema**.</span></span> <span data-ttu-id="23a28-164">XML ファイルの内容に基づいて、WindowsStoreProxy.xsd 一時ファイルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="23a28-164">This will create a temporary WindowsStoreProxy.xsd file based on the contents of the XML file.</span></span>
3. <span data-ttu-id="23a28-165">その .xsd ファイルの内容を下記のスキーマと置き換えます。</span><span class="sxs-lookup"><span data-stu-id="23a28-165">Replace the contents of that .xsd file with the schema below.</span></span>
4. <span data-ttu-id="23a28-166">複数のアプリ プロジェクトに適用できる場所に、作成したファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="23a28-166">Save the file to a location where you can apply it to multiple app projects.</span></span>
5. <span data-ttu-id="23a28-167">Visual Studio で、この WindowsStoreProxy.xml ファイルに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="23a28-167">Switch to your WindowsStoreProxy.xml file in Visual Studio.</span></span>
6. <span data-ttu-id="23a28-168">**[XML]** メニューで **[スキーマ]** をクリックし、一覧から WindowsStoreProxy.xsd ファイルの行を探します。</span><span class="sxs-lookup"><span data-stu-id="23a28-168">On the **XML** menu, click **Schemas**, then locate the row in the list for the WindowsStoreProxy.xsd file.</span></span> <span data-ttu-id="23a28-169">ファイルの場所が適切でない場合 (たとえば、一時ファイルがまだ表示されている場合) は、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="23a28-169">If the location for the file is not the one you want (for example, if the temporary file is still shown), click **Add**.</span></span> <span data-ttu-id="23a28-170">適切なファイルに移動し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="23a28-170">Navigate to the right file, then click **OK**.</span></span> <span data-ttu-id="23a28-171">一覧にそのファイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="23a28-171">You should now see that file in the list.</span></span> <span data-ttu-id="23a28-172">そのスキーマの**[使用] ** 列にチェックマークが入っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="23a28-172">Make sure a checkmark appears in the **Use** column for that schema.</span></span>

<span data-ttu-id="23a28-173">この操作を完了すると、WindowsStoreProxy.xml に加えた変更内容がスキーマに適用されます。</span><span class="sxs-lookup"><span data-stu-id="23a28-173">Once you've done this, edits you make to WindowsStoreProxy.xml will be subject to the schema.</span></span> <span data-ttu-id="23a28-174">詳しくは、「[方法: 使用する XML スキーマを選択する](http://go.microsoft.com/fwlink/p/?LinkId=403014)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-174">For more information, see [How to: Select the XML Schemas to Use](http://go.microsoft.com/fwlink/p/?LinkId=403014).</span></span>

> [!div class="tabbedCodeSnippets"]
```xml
<?xml version="1.0" encoding="utf-8"?>
<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:import namespace="http://www.w3.org/XML/1998/namespace"/>
  <xs:element name="CurrentApp" type="CurrentAppDefinition"></xs:element>
  <xs:complexType name="CurrentAppDefinition">
    <xs:sequence>
      <xs:element name="ListingInformation" type="ListingDefinition" minOccurs="1" maxOccurs="1"/>
      <xs:element name="LicenseInformation" type="LicenseDefinition" minOccurs="1" maxOccurs="1"/>
      <xs:element name="ConsumableInformation" type="ConsumableDefinition" minOccurs="0" maxOccurs="1"/>
      <xs:element name="Simulation" type="SimulationDefinition" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
  </xs:complexType>
  <xs:simpleType name="ResponseCodes">
    <xs:restriction base="xs:string">
      <xs:enumeration value="S_OK">
        <xs:annotation>
          <xs:documentation>0x00000000</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="E_INVALIDARG">
        <xs:annotation>
          <xs:documentation>0x80070057</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="E_CANCELLED">
        <xs:annotation>
          <xs:documentation>0x800704C7</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="E_FAIL">
        <xs:annotation>
          <xs:documentation>0x80004005</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="E_OUTOFMEMORY">
        <xs:annotation>
          <xs:documentation>0x8007000E</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="ERROR_ALREADY_EXISTS">
        <xs:annotation>
          <xs:documentation>0x800700B7</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
    </xs:restriction>
  </xs:simpleType>
  <xs:simpleType name="ConsumableStatus">
    <xs:restriction base="xs:string">
      <xs:enumeration value="Active"/>
      <xs:enumeration value="PurchaseReverted"/>
      <xs:enumeration value="PurchasePending"/>
      <xs:enumeration value="ServerError"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:simpleType name="StoreMethodName">
    <xs:restriction base="xs:string">
      <xs:enumeration value="RequestAppPurchaseAsync_GetResult" id="RPPA"/>
      <xs:enumeration value="RequestProductPurchaseAsync_GetResult" id="RFPA"/>
      <xs:enumeration value="LoadListingInformationAsync_GetResult" id="LLIA"/>
      <xs:enumeration value="ReportConsumableFulfillmentAsync_GetResult" id="RPFA"/>
      <xs:enumeration value="LoadListingInformationByKeywordsAsync_GetResult" id="LLIKA"/>
      <xs:enumeration value="LoadListingInformationByProductIdAsync_GetResult" id="LLIPA"/>
      <xs:enumeration value="GetUnfulfilledConsumablesAsync_GetResult" id="GUC"/>
      <xs:enumeration value="GetAppReceiptAsync_GetResult" id="GARA"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:simpleType name="SimulationMode">
    <xs:restriction base="xs:string">
      <xs:enumeration value="Interactive"/>
      <xs:enumeration value="Automatic"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:complexType name="ListingDefinition">
    <xs:sequence>
      <xs:element name="App" type="AppListingDefinition"/>
      <xs:element name="Product" type="ProductListingDefinition" minOccurs="0" maxOccurs="unbounded"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="ConsumableDefinition">
    <xs:sequence>
      <xs:element name="Product" type="ConsumableProductDefinition" minOccurs="0" maxOccurs="unbounded"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="AppListingDefinition">
    <xs:sequence>
      <xs:element name="AppId" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="LinkUri" type="xs:anyURI" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrentMarket" type="xs:language" minOccurs="1" maxOccurs="1"/>
      <xs:element name="AgeRating" type="xs:unsignedInt" minOccurs="1" maxOccurs="1"/>
      <xs:element name="MarketData" type="MarketSpecificAppData" minOccurs="1" maxOccurs="unbounded"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="MarketSpecificAppData">
    <xs:sequence>
      <xs:element name="Name" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="Description" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="Price" type="xs:float" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrencySymbol" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrencyCode" type="xs:string" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
    <xs:attribute ref="xml:lang" use="required"/>
  </xs:complexType>
  <xs:complexType name="MarketSpecificProductData">
    <xs:sequence>
      <xs:element name="Name" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="Price" type="xs:float" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrencySymbol" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrencyCode" type="xs:string" minOccurs="0" maxOccurs="1"/>
      <xs:element name="Description" type="xs:string" minOccurs="0" maxOccurs="1"/>
      <xs:element name="Tag" type="xs:string" minOccurs="0" maxOccurs="1"/>
      <xs:element name="Keywords" type="KeywordDefinition" minOccurs="0" maxOccurs="1"/>
      <xs:element name="ImageUri" type="xs:anyURI" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
    <xs:attribute ref="xml:lang" use="required"/>
  </xs:complexType>
  <xs:complexType name="ProductListingDefinition">
    <xs:sequence>
      <xs:element name="MarketData" type="MarketSpecificProductData" minOccurs="1" maxOccurs="unbounded"/>
    </xs:sequence>
    <xs:attribute name="ProductId" use="required">
      <xs:simpleType>
        <xs:restriction base="xs:string">
          <xs:maxLength value="100"/>
          <xs:pattern value="[^,]*"/>
        </xs:restriction>
      </xs:simpleType>
    </xs:attribute>
    <xs:attribute name="LicenseDuration" type="xs:integer" use="optional"/>
    <xs:attribute name="ProductType" type="xs:string" use="optional"/>
  </xs:complexType>
  <xs:simpleType name="guid">
    <xs:restriction base="xs:string">
      <xs:pattern value="[\da-fA-F]{8}-[\da-fA-F]{4}-[\da-fA-F]{4}-[\da-fA-F]{4}-[\da-fA-F]{12}"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:complexType name="ConsumableProductDefinition">
    <xs:attribute name="ProductId" use="required">
      <xs:simpleType>
        <xs:restriction base="xs:string">
          <xs:maxLength value="100"/>
          <xs:pattern value="[^,]*"/>
        </xs:restriction>
      </xs:simpleType>
    </xs:attribute>
    <xs:attribute name="TransactionId" type="guid" use="required"/>
    <xs:attribute name="Status" type="ConsumableStatus" use="required"/>
    <xs:attribute name="OfferId" type="xs:string" use="optional"/>
  </xs:complexType>
  <xs:complexType name="LicenseDefinition">
    <xs:sequence>
      <xs:element name="App" type="AppLicenseDefinition"/>
      <xs:element name="Product" type="ProductLicenseDefinition" minOccurs="0" maxOccurs="unbounded"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="AppLicenseDefinition">
    <xs:sequence>
      <xs:element name="IsActive" type="xs:boolean" minOccurs="1" maxOccurs="1"/>
      <xs:element name="IsTrial" type="xs:boolean" minOccurs="1" maxOccurs="1"/>
      <xs:element name="ExpirationDate" type="xs:dateTime" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="ProductLicenseDefinition">
    <xs:sequence>
      <xs:element name="IsActive" type="xs:boolean" minOccurs="1" maxOccurs="1"/>
      <xs:element name="ExpirationDate" type="xs:dateTime" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
    <xs:attribute name="ProductId" type="xs:string" use="required"/>
    <xs:attribute name="OfferId" type="xs:string" use="optional"/>
  </xs:complexType>
  <xs:complexType name="SimulationDefinition" >
    <xs:sequence>
      <xs:element name="DefaultResponse" type="DefaultResponseDefinition" minOccurs="0" maxOccurs="unbounded"/>
    </xs:sequence>
    <xs:attribute name="SimulationMode" type="SimulationMode" use="optional"/>
  </xs:complexType>
  <xs:complexType name="DefaultResponseDefinition">
    <xs:attribute name="MethodName" type="StoreMethodName" use="required"/>
    <xs:attribute name="HResult" type="ResponseCodes" use="required"/>
  </xs:complexType>
  <xs:complexType name="KeywordDefinition">
    <xs:sequence>
      <xs:element name="Keyword" type="xs:string" minOccurs="0" maxOccurs="10"/>
    </xs:sequence>
  </xs:complexType>
</xs:schema>
```


<span id="proxy-descriptions" />
### <a name="element-and-attribute-descriptions"></a><span data-ttu-id="23a28-175">要素と属性の説明</span><span class="sxs-lookup"><span data-stu-id="23a28-175">Element and attribute descriptions</span></span>

<span data-ttu-id="23a28-176">このセクションでは、WindowsStoreProxy.xml ファイル内の要素と属性について説明します。</span><span class="sxs-lookup"><span data-stu-id="23a28-176">This section describes the elements and attributes in the WindowsStoreProxy.xml file.</span></span>

<span data-ttu-id="23a28-177">このファイルのルート要素は、現在のアプリを表す **CurrentApp**要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-177">The root element of this file is the **CurrentApp** element, which represents the current app.</span></span> <span data-ttu-id="23a28-178">この要素には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-178">This element contains the following child elements.</span></span>

|  <span data-ttu-id="23a28-179">要素</span><span class="sxs-lookup"><span data-stu-id="23a28-179">Element</span></span>  |  <span data-ttu-id="23a28-180">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-180">Required</span></span>  |  <span data-ttu-id="23a28-181">数量</span><span class="sxs-lookup"><span data-stu-id="23a28-181">Quantity</span></span>  |  <span data-ttu-id="23a28-182">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-182">Description</span></span>   |
|-------------|------------|--------|--------|
|  [<span data-ttu-id="23a28-183">ListingInformation</span><span class="sxs-lookup"><span data-stu-id="23a28-183">ListingInformation</span></span>](#listinginformation)  |    <span data-ttu-id="23a28-184">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-184">Yes</span></span>        |  <span data-ttu-id="23a28-185">1</span><span class="sxs-lookup"><span data-stu-id="23a28-185">1</span></span>  |  <span data-ttu-id="23a28-186">アプリの登録情報のデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-186">Contains data from the app's listing.</span></span>            |
|  [<span data-ttu-id="23a28-187">LicenseInformation</span><span class="sxs-lookup"><span data-stu-id="23a28-187">LicenseInformation</span></span>](#licenseinformation)  |     <span data-ttu-id="23a28-188">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-188">Yes</span></span>       |   <span data-ttu-id="23a28-189">1</span><span class="sxs-lookup"><span data-stu-id="23a28-189">1</span></span>    |   <span data-ttu-id="23a28-190">このアプリで利用可能なライセンスと永続的なアドオンが記述されています。</span><span class="sxs-lookup"><span data-stu-id="23a28-190">Describes the licenses available for this app and its durable add-ons.</span></span>     |
|  [<span data-ttu-id="23a28-191">ConsumableInformation</span><span class="sxs-lookup"><span data-stu-id="23a28-191">ConsumableInformation</span></span>](#consumableinformation)  |      <span data-ttu-id="23a28-192">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-192">No</span></span>      |   <span data-ttu-id="23a28-193">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-193">0 or 1</span></span>   |   <span data-ttu-id="23a28-194">このアプリで利用可能なコンシューマブルなアドオンが記述されています。</span><span class="sxs-lookup"><span data-stu-id="23a28-194">Describes the consumable add-ons that are available for this app.</span></span>      |
|  [<span data-ttu-id="23a28-195">Simulation</span><span class="sxs-lookup"><span data-stu-id="23a28-195">Simulation</span></span>](#simulation)  |     <span data-ttu-id="23a28-196">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-196">No</span></span>       |      <span data-ttu-id="23a28-197">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-197">0 or 1</span></span>      |   <span data-ttu-id="23a28-198">テストで、さまざまな [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) メソッドを呼び出したときに行われる動作が記述されています。</span><span class="sxs-lookup"><span data-stu-id="23a28-198">Describes how calls to various [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) methods will work in the app during testing.</span></span>    |

<span id="listinginformation" />
#### <a name="listinginformation-element"></a><span data-ttu-id="23a28-199">ListingInformation 要素</span><span class="sxs-lookup"><span data-stu-id="23a28-199">ListingInformation element</span></span>

<span data-ttu-id="23a28-200">この要素には、アプリの登録情報のデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-200">This element contains data from the app's listing.</span></span> <span data-ttu-id="23a28-201">**ListingInformation** は、**CurrentApp** 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-201">**ListingInformation** is a required child of the **CurrentApp** element.</span></span>

<span data-ttu-id="23a28-202">**ListingInformation** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-202">**ListingInformation** contains the following child elements.</span></span>

|  <span data-ttu-id="23a28-203">要素</span><span class="sxs-lookup"><span data-stu-id="23a28-203">Element</span></span>  |  <span data-ttu-id="23a28-204">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-204">Required</span></span>  |  <span data-ttu-id="23a28-205">数量</span><span class="sxs-lookup"><span data-stu-id="23a28-205">Quantity</span></span>  |  <span data-ttu-id="23a28-206">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-206">Description</span></span>   |
|-------------|------------|--------|--------|
|  [<span data-ttu-id="23a28-207">App</span><span class="sxs-lookup"><span data-stu-id="23a28-207">App</span></span>](#app-child-of-listinginformation)  |    <span data-ttu-id="23a28-208">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-208">Yes</span></span>   |  <span data-ttu-id="23a28-209">1</span><span class="sxs-lookup"><span data-stu-id="23a28-209">1</span></span>   |    <span data-ttu-id="23a28-210">アプリに関するデータを提供します。</span><span class="sxs-lookup"><span data-stu-id="23a28-210">Provides data about the app.</span></span>         |
|  [<span data-ttu-id="23a28-211">Product</span><span class="sxs-lookup"><span data-stu-id="23a28-211">Product</span></span>](#product-child-of-listinginformation)  |    <span data-ttu-id="23a28-212">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-212">No</span></span>  |  <span data-ttu-id="23a28-213">0 以上</span><span class="sxs-lookup"><span data-stu-id="23a28-213">0 or more</span></span>   |      <span data-ttu-id="23a28-214">アプリのアドオンを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-214">Describes an add-on for the app.</span></span>     |     |

<span id="app-child-of-listinginformation"/>
#### <a name="app-element-child-of-listinginformation"></a><span data-ttu-id="23a28-215">App 要素 (ListingInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="23a28-215">App element (child of ListingInformation)</span></span>

<span data-ttu-id="23a28-216">この要素は、アプリのライセンスを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-216">This element describes the app's license.</span></span> <span data-ttu-id="23a28-217">**App** は、[ListingInformation](#listinginformation) 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-217">**App** is a required child of the [ListingInformation](#listinginformation) element.</span></span>

<span data-ttu-id="23a28-218">**App** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-218">**App** contains the following child elements.</span></span>

|  <span data-ttu-id="23a28-219">要素</span><span class="sxs-lookup"><span data-stu-id="23a28-219">Element</span></span>  |  <span data-ttu-id="23a28-220">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-220">Required</span></span>  |  <span data-ttu-id="23a28-221">数量</span><span class="sxs-lookup"><span data-stu-id="23a28-221">Quantity</span></span>  | <span data-ttu-id="23a28-222">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-222">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="23a28-223">AppId</span><span class="sxs-lookup"><span data-stu-id="23a28-223">AppId</span></span>**  |    <span data-ttu-id="23a28-224">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-224">Yes</span></span>   |  <span data-ttu-id="23a28-225">1</span><span class="sxs-lookup"><span data-stu-id="23a28-225">1</span></span>   |   <span data-ttu-id="23a28-226">ストアでアプリを識別する GUID です。</span><span class="sxs-lookup"><span data-stu-id="23a28-226">The GUID that identifies the app in the Store.</span></span> <span data-ttu-id="23a28-227">テストでは任意の GUID を使用できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-227">This can be any GUID for testing.</span></span>        |
|  **<span data-ttu-id="23a28-228">LinkUri</span><span class="sxs-lookup"><span data-stu-id="23a28-228">LinkUri</span></span>**  |    <span data-ttu-id="23a28-229">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-229">Yes</span></span>  |  <span data-ttu-id="23a28-230">1</span><span class="sxs-lookup"><span data-stu-id="23a28-230">1</span></span>   |    <span data-ttu-id="23a28-231">ストアの登録情報ページの URI です。</span><span class="sxs-lookup"><span data-stu-id="23a28-231">The URI of the listing page in the store.</span></span> <span data-ttu-id="23a28-232">テストでは任意の有効な URI を使用できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-232">This can be any valid URI for testing.</span></span>         |
|  **<span data-ttu-id="23a28-233">CurrentMarket</span><span class="sxs-lookup"><span data-stu-id="23a28-233">CurrentMarket</span></span>**  |    <span data-ttu-id="23a28-234">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-234">Yes</span></span>  |  <span data-ttu-id="23a28-235">1</span><span class="sxs-lookup"><span data-stu-id="23a28-235">1</span></span>   |    <span data-ttu-id="23a28-236">顧客の国/地域です。</span><span class="sxs-lookup"><span data-stu-id="23a28-236">The customer's country/region.</span></span>         |
|  **<span data-ttu-id="23a28-237">AgeRating</span><span class="sxs-lookup"><span data-stu-id="23a28-237">AgeRating</span></span>**  |    <span data-ttu-id="23a28-238">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-238">Yes</span></span>  |  <span data-ttu-id="23a28-239">1</span><span class="sxs-lookup"><span data-stu-id="23a28-239">1</span></span>   |     <span data-ttu-id="23a28-240">アプリの年齢区分の下限を表す整数です。</span><span class="sxs-lookup"><span data-stu-id="23a28-240">An integer that represents the minimum age rating of the app.</span></span> <span data-ttu-id="23a28-241">アプリの提出時にデベロッパー センター ダッシュ ボードで指定する値と同じ数値です。</span><span class="sxs-lookup"><span data-stu-id="23a28-241">This is the same value you would specify in the Dev Center dashboard when you submit the app.</span></span> <span data-ttu-id="23a28-242">ストアで使われる値は、3、7、12、および 16 です。</span><span class="sxs-lookup"><span data-stu-id="23a28-242">The values used by the Store are: 3, 7, 12, and 16.</span></span> <span data-ttu-id="23a28-243">これらの年齢区分について詳しくは、「[年齢区分](../publish/age-ratings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-243">For more info on these ratings, see [Age ratings](../publish/age-ratings.md).</span></span>        |
|  [<span data-ttu-id="23a28-244">MarketData</span><span class="sxs-lookup"><span data-stu-id="23a28-244">MarketData</span></span>](#marketdata-child-of-app)  |    <span data-ttu-id="23a28-245">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-245">Yes</span></span>  |  <span data-ttu-id="23a28-246">1 以上</span><span class="sxs-lookup"><span data-stu-id="23a28-246">1 or more</span></span>      |    <span data-ttu-id="23a28-247">アプリに関する特定の国/地域向けの情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-247">Contains info about the app for a given country/region.</span></span> <span data-ttu-id="23a28-248">アプリが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-248">For each country/region in which the app is listed, you must include a **MarketData** element.</span></span>       |    |

<span id="marketdata-child-of-app"/>
#### <a name="marketdata-element-child-of-app"></a><span data-ttu-id="23a28-249">MarketData 要素 (App の子要素)</span><span class="sxs-lookup"><span data-stu-id="23a28-249">MarketData element (child of App)</span></span>

<span data-ttu-id="23a28-250">この要素は、アプリに関する特定の国/地域向けの情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="23a28-250">This element provides info about the app for a given country/region.</span></span> <span data-ttu-id="23a28-251">アプリが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-251">For each country/region in which the app is listed, you must include a **MarketData** element.</span></span> <span data-ttu-id="23a28-252">**MarketData** は、[App](#app-child-of-listinginformation) 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-252">**MarketData** is a required child of the [App](#app-child-of-listinginformation) element.</span></span>

<span data-ttu-id="23a28-253">**MarketData** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-253">**MarketData** contains the following child elements.</span></span>

|  <span data-ttu-id="23a28-254">要素</span><span class="sxs-lookup"><span data-stu-id="23a28-254">Element</span></span>  |  <span data-ttu-id="23a28-255">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-255">Required</span></span>  |  <span data-ttu-id="23a28-256">数量</span><span class="sxs-lookup"><span data-stu-id="23a28-256">Quantity</span></span>  | <span data-ttu-id="23a28-257">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-257">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="23a28-258">Name</span><span class="sxs-lookup"><span data-stu-id="23a28-258">Name</span></span>**  |    <span data-ttu-id="23a28-259">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-259">Yes</span></span>   |  <span data-ttu-id="23a28-260">1</span><span class="sxs-lookup"><span data-stu-id="23a28-260">1</span></span>   |   <span data-ttu-id="23a28-261">この国/地域でのアプリの名前です。</span><span class="sxs-lookup"><span data-stu-id="23a28-261">The name of the app in this country/region.</span></span>        |
|  **<span data-ttu-id="23a28-262">Description</span><span class="sxs-lookup"><span data-stu-id="23a28-262">Description</span></span>**  |    <span data-ttu-id="23a28-263">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-263">Yes</span></span>  |  <span data-ttu-id="23a28-264">1</span><span class="sxs-lookup"><span data-stu-id="23a28-264">1</span></span>   |      <span data-ttu-id="23a28-265">この国/地域向けのアプリの説明です。</span><span class="sxs-lookup"><span data-stu-id="23a28-265">The description of the app for this country/region.</span></span>       |
|  **<span data-ttu-id="23a28-266">Price</span><span class="sxs-lookup"><span data-stu-id="23a28-266">Price</span></span>**  |    <span data-ttu-id="23a28-267">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-267">Yes</span></span>  |  <span data-ttu-id="23a28-268">1</span><span class="sxs-lookup"><span data-stu-id="23a28-268">1</span></span>   |     <span data-ttu-id="23a28-269">この国/地域でのアプリの価格です。</span><span class="sxs-lookup"><span data-stu-id="23a28-269">The price of the app in this country/region.</span></span>        |
|  **<span data-ttu-id="23a28-270">CurrencySymbol</span><span class="sxs-lookup"><span data-stu-id="23a28-270">CurrencySymbol</span></span>**  |    <span data-ttu-id="23a28-271">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-271">Yes</span></span>  |  <span data-ttu-id="23a28-272">1</span><span class="sxs-lookup"><span data-stu-id="23a28-272">1</span></span>   |     <span data-ttu-id="23a28-273">この国/地域で使われている通貨記号です。</span><span class="sxs-lookup"><span data-stu-id="23a28-273">The currency symbol used in this country/region.</span></span>        |
|  **<span data-ttu-id="23a28-274">CurrencyCode</span><span class="sxs-lookup"><span data-stu-id="23a28-274">CurrencyCode</span></span>**  |    <span data-ttu-id="23a28-275">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-275">No</span></span>  |  <span data-ttu-id="23a28-276">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-276">0 or 1</span></span>      |      <span data-ttu-id="23a28-277">この国/地域で使われている通貨コードです。</span><span class="sxs-lookup"><span data-stu-id="23a28-277">The currency code used in this country/region.</span></span>         |  |

<span data-ttu-id="23a28-278">**MarketData** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-278">**MarketData** has the following attributes.</span></span>

|  <span data-ttu-id="23a28-279">属性</span><span class="sxs-lookup"><span data-stu-id="23a28-279">Attribute</span></span>  |  <span data-ttu-id="23a28-280">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-280">Required</span></span>  |  <span data-ttu-id="23a28-281">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-281">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="23a28-282">xml:lang</span><span class="sxs-lookup"><span data-stu-id="23a28-282">xml:lang</span></span>**  |    <span data-ttu-id="23a28-283">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-283">Yes</span></span>        |     <span data-ttu-id="23a28-284">市場データ情報を適用する国/地域を指定します。</span><span class="sxs-lookup"><span data-stu-id="23a28-284">Specifies the country/region for which the market data info applies.</span></span>          |  |

<span id="product-child-of-listinginformation"/>
#### <a name="product-element-child-of-listinginformation"></a><span data-ttu-id="23a28-285">Product 要素 (ListingInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="23a28-285">Product element (child of ListingInformation)</span></span>

<span data-ttu-id="23a28-286">この要素は、アプリのアドオンを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-286">This element describes an add-on for the app.</span></span> <span data-ttu-id="23a28-287">**Product** は、[ListingInformation](#listinginformation) 要素のオプションの子要素であり、1 つ以上の [MarketData](#marketdata-child-of-product) 要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-287">**Product** is an optional child of the [ListingInformation](#listinginformation) element, and it contains one or more [MarketData](#marketdata-child-of-product) elements.</span></span>

<span data-ttu-id="23a28-288">**Product** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-288">**Product** has the following attributes.</span></span>

|  <span data-ttu-id="23a28-289">属性</span><span class="sxs-lookup"><span data-stu-id="23a28-289">Attribute</span></span>  |  <span data-ttu-id="23a28-290">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-290">Required</span></span>  |  <span data-ttu-id="23a28-291">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-291">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="23a28-292">ProductId</span><span class="sxs-lookup"><span data-stu-id="23a28-292">ProductId</span></span>**  |    <span data-ttu-id="23a28-293">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-293">Yes</span></span>        |    <span data-ttu-id="23a28-294">アプリがこのアドオンを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-294">Contains the string used by the app to identify the add-on.</span></span>           |
|  **<span data-ttu-id="23a28-295">LicenseDuration</span><span class="sxs-lookup"><span data-stu-id="23a28-295">LicenseDuration</span></span>**  |    <span data-ttu-id="23a28-296">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-296">No</span></span>        |    <span data-ttu-id="23a28-297">アイテム購入後、ライセンスが有効な日数を示します。</span><span class="sxs-lookup"><span data-stu-id="23a28-297">Indicates the number of days for which the license will be valid after the item has been purchased.</span></span> <span data-ttu-id="23a28-298">製品の購入によって作成される新しいライセンスの有効期限は、購入日にライセンス期間を加算した日付です。</span><span class="sxs-lookup"><span data-stu-id="23a28-298">The expiration date of the new license created by a product purchase is the purchase date plus the license duration.</span></span> <span data-ttu-id="23a28-299">この属性は、**ProductType** 属性が **Durable** の場合のみ使用され、コンシューマブルなアドオンの場合には無視されます。</span><span class="sxs-lookup"><span data-stu-id="23a28-299">This attribute is used only if the **ProductType** attribute is **Durable**; this attribute is ignored for consumable add-ons.</span></span>           |
|  **<span data-ttu-id="23a28-300">ProductType</span><span class="sxs-lookup"><span data-stu-id="23a28-300">ProductType</span></span>**  |    <span data-ttu-id="23a28-301">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-301">No</span></span>        |    <span data-ttu-id="23a28-302">アプリ内製品が永続的かどうかを識別する値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-302">Contains a value to identify the persistence of the in-app product.</span></span> <span data-ttu-id="23a28-303">サポートされている値は、**Durable** (既定) と **Consumable** です。</span><span class="sxs-lookup"><span data-stu-id="23a28-303">The supported values are **Durable** (the default) and **Consumable**.</span></span> <span data-ttu-id="23a28-304">永続的なアドオンについて詳しくは、[LicenseInformation](#licenseinformation) の下の [Product](#product-child-of-licenseinformation)要素をご覧ください。コンシューマブルなアドオンについて詳しくは、[ConsumableInformation](#consumableinformation) の [Product](#product-child-of-consumableinformation) 要素をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-304">For durable types, additional information is described by a [Product](#product-child-of-licenseinformation) element under [LicenseInformation](#licenseinformation); for consumable types, additional information is described by a [Product](#product-child-of-consumableinformation) element under [ConsumableInformation](#consumableinformation).</span></span>           |  |

<span id="marketdata-child-of-product"/>
#### <a name="marketdata-element-child-of-product"></a><span data-ttu-id="23a28-305">MarketData 要素 (Product の子要素)</span><span class="sxs-lookup"><span data-stu-id="23a28-305">MarketData element (child of Product)</span></span>

<span data-ttu-id="23a28-306">この要素は、アドオンに関する特定の国/地域向けの情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="23a28-306">This element provides info about the add-on for a given country/region.</span></span> <span data-ttu-id="23a28-307">アドオンが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-307">For each country/region in which the add-on is listed, you must include a **MarketData** element.</span></span> <span data-ttu-id="23a28-308">**MarketData** は、[Product](#product-child-of-listinginformation) 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-308">**MarketData** is a required child of the [Product](#product-child-of-listinginformation) element.</span></span>

<span data-ttu-id="23a28-309">**MarketData** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-309">**MarketData** contains the following child elements.</span></span>

|  <span data-ttu-id="23a28-310">要素</span><span class="sxs-lookup"><span data-stu-id="23a28-310">Element</span></span>  |  <span data-ttu-id="23a28-311">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-311">Required</span></span>  |  <span data-ttu-id="23a28-312">数量</span><span class="sxs-lookup"><span data-stu-id="23a28-312">Quantity</span></span>  | <span data-ttu-id="23a28-313">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-313">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="23a28-314">Name</span><span class="sxs-lookup"><span data-stu-id="23a28-314">Name</span></span>**  |    <span data-ttu-id="23a28-315">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-315">Yes</span></span>   |  <span data-ttu-id="23a28-316">1</span><span class="sxs-lookup"><span data-stu-id="23a28-316">1</span></span>   |   <span data-ttu-id="23a28-317">この国/地域でのアドオンの名前です。</span><span class="sxs-lookup"><span data-stu-id="23a28-317">The name of the add-on in this country/region.</span></span>        |
|  **<span data-ttu-id="23a28-318">Price</span><span class="sxs-lookup"><span data-stu-id="23a28-318">Price</span></span>**  |    <span data-ttu-id="23a28-319">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-319">Yes</span></span>  |  <span data-ttu-id="23a28-320">1</span><span class="sxs-lookup"><span data-stu-id="23a28-320">1</span></span>   |     <span data-ttu-id="23a28-321">この国/地域でのアドオンの価格です。</span><span class="sxs-lookup"><span data-stu-id="23a28-321">The price of the add-on in this country/region.</span></span>        |
|  **<span data-ttu-id="23a28-322">CurrencySymbol</span><span class="sxs-lookup"><span data-stu-id="23a28-322">CurrencySymbol</span></span>**  |    <span data-ttu-id="23a28-323">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-323">Yes</span></span>  |  <span data-ttu-id="23a28-324">1</span><span class="sxs-lookup"><span data-stu-id="23a28-324">1</span></span>   |     <span data-ttu-id="23a28-325">この国/地域で使われている通貨記号です。</span><span class="sxs-lookup"><span data-stu-id="23a28-325">The currency symbol used in this country/region.</span></span>        |
|  **<span data-ttu-id="23a28-326">CurrencyCode</span><span class="sxs-lookup"><span data-stu-id="23a28-326">CurrencyCode</span></span>**  |    <span data-ttu-id="23a28-327">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-327">No</span></span>  |  <span data-ttu-id="23a28-328">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-328">0 or 1</span></span>      |      <span data-ttu-id="23a28-329">この国/地域で使われている通貨コードです。</span><span class="sxs-lookup"><span data-stu-id="23a28-329">The currency code used in this country/region.</span></span>         |  
|  **<span data-ttu-id="23a28-330">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-330">Description</span></span>**  |    <span data-ttu-id="23a28-331">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-331">No</span></span>  |   <span data-ttu-id="23a28-332">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-332">0 or 1</span></span>   |      <span data-ttu-id="23a28-333">この国/地域向けのアドオンの説明です。</span><span class="sxs-lookup"><span data-stu-id="23a28-333">The description of the add-on for this country/region.</span></span>       |
|  **<span data-ttu-id="23a28-334">Tag</span><span class="sxs-lookup"><span data-stu-id="23a28-334">Tag</span></span>**  |    <span data-ttu-id="23a28-335">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-335">No</span></span>  |   <span data-ttu-id="23a28-336">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-336">0 or 1</span></span>   |      <span data-ttu-id="23a28-337">アドオンの[カスタム開発者データ](../publish/enter-add-on-properties.md#custom-developer-data) (タグとも呼ばれます) です。</span><span class="sxs-lookup"><span data-stu-id="23a28-337">The [custom developer data](../publish/enter-add-on-properties.md#custom-developer-data) (also called tag) for the add-on.</span></span>       |
|  **<span data-ttu-id="23a28-338">Keywords</span><span class="sxs-lookup"><span data-stu-id="23a28-338">Keywords</span></span>**  |    <span data-ttu-id="23a28-339">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-339">No</span></span>  |   <span data-ttu-id="23a28-340">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-340">0 or 1</span></span>   |      <span data-ttu-id="23a28-341">アドオンの[キーワード](../publish/enter-add-on-properties.md#keywords)が含まれた最大 10 個の **Keyword** 要素を含みます。</span><span class="sxs-lookup"><span data-stu-id="23a28-341">Contains up to 10 **Keyword** elements that contain the [keywords](../publish/enter-add-on-properties.md#keywords) for the add-on.</span></span>       |
|  **<span data-ttu-id="23a28-342">ImageUri</span><span class="sxs-lookup"><span data-stu-id="23a28-342">ImageUri</span></span>**  |    <span data-ttu-id="23a28-343">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-343">No</span></span>  |   <span data-ttu-id="23a28-344">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-344">0 or 1</span></span>   |      <span data-ttu-id="23a28-345">アドオンの登録情報に表示する[画像の URI](../publish/create-add-on-store-listings.md#icon) です。</span><span class="sxs-lookup"><span data-stu-id="23a28-345">The [URI for the image](../publish/create-add-on-store-listings.md#icon) in the add-on's listing.</span></span>           |  |

<span data-ttu-id="23a28-346">**MarketData** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-346">**MarketData** has the following attributes.</span></span>

|  <span data-ttu-id="23a28-347">属性</span><span class="sxs-lookup"><span data-stu-id="23a28-347">Attribute</span></span>  |  <span data-ttu-id="23a28-348">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-348">Required</span></span>  |  <span data-ttu-id="23a28-349">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-349">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="23a28-350">xml:lang</span><span class="sxs-lookup"><span data-stu-id="23a28-350">xml:lang</span></span>**  |    <span data-ttu-id="23a28-351">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-351">Yes</span></span>        |     <span data-ttu-id="23a28-352">市場データ情報を適用する国/地域を指定します。</span><span class="sxs-lookup"><span data-stu-id="23a28-352">Specifies the country/region for which the market data info applies.</span></span>          |  |

<span id="licenseinformation"/>
#### <a name="licenseinformation-element"></a><span data-ttu-id="23a28-353">LicenseInformation 要素</span><span class="sxs-lookup"><span data-stu-id="23a28-353">LicenseInformation element</span></span>

<span data-ttu-id="23a28-354">この要素は、このアプリで利用可能なライセンスと永続的なアプリ内製品を記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-354">This element describes the licenses available for this app and its durable in-app products.</span></span> <span data-ttu-id="23a28-355">**LicenseInformation** は、**CurrentApp** 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-355">**LicenseInformation** is a required child of the **CurrentApp** element.</span></span>

<span data-ttu-id="23a28-356">**LicenseInformation** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-356">**LicenseInformation** contains the following child elements.</span></span>

|  <span data-ttu-id="23a28-357">要素</span><span class="sxs-lookup"><span data-stu-id="23a28-357">Element</span></span>  |  <span data-ttu-id="23a28-358">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-358">Required</span></span>  |  <span data-ttu-id="23a28-359">数量</span><span class="sxs-lookup"><span data-stu-id="23a28-359">Quantity</span></span>  | <span data-ttu-id="23a28-360">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-360">Description</span></span>   |
|-------------|------------|--------|--------|
|  [<span data-ttu-id="23a28-361">App</span><span class="sxs-lookup"><span data-stu-id="23a28-361">App</span></span>](#app-child-of-licenseinformation)  |    <span data-ttu-id="23a28-362">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-362">Yes</span></span>   |  <span data-ttu-id="23a28-363">1</span><span class="sxs-lookup"><span data-stu-id="23a28-363">1</span></span>   |    <span data-ttu-id="23a28-364">アプリのライセンスを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-364">Describes the app's license.</span></span>         |
|  [<span data-ttu-id="23a28-365">Product</span><span class="sxs-lookup"><span data-stu-id="23a28-365">Product</span></span>](#product-child-of-licenseinformation)  |    <span data-ttu-id="23a28-366">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-366">No</span></span>  |  <span data-ttu-id="23a28-367">0 以上</span><span class="sxs-lookup"><span data-stu-id="23a28-367">0 or more</span></span>   |      <span data-ttu-id="23a28-368">アプリ内の永続的なアドオンのライセンスの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-368">Describes the license status of a durable add-on in the app.</span></span>         |   |

<span data-ttu-id="23a28-369">次の表では、**App** 要素と **Product** 要素の下で値を組み合わせて、いくつかの一般的な条件をシミュレートする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="23a28-369">The following table shows how to simulate some common conditions by combining values under the **App** and **Product** elements.</span></span>

|  <span data-ttu-id="23a28-370">シミュレートする条件</span><span class="sxs-lookup"><span data-stu-id="23a28-370">Condition to simulate</span></span>  |  <span data-ttu-id="23a28-371">IsActive</span><span class="sxs-lookup"><span data-stu-id="23a28-371">IsActive</span></span>  |  <span data-ttu-id="23a28-372">IsTrial</span><span class="sxs-lookup"><span data-stu-id="23a28-372">IsTrial</span></span>  | <span data-ttu-id="23a28-373">ExpirationDate</span><span class="sxs-lookup"><span data-stu-id="23a28-373">ExpirationDate</span></span>   |
|-------------|------------|--------|--------|
|  <span data-ttu-id="23a28-374">完全なライセンスを保有</span><span class="sxs-lookup"><span data-stu-id="23a28-374">Fully licensed</span></span>  |    <span data-ttu-id="23a28-375">true</span><span class="sxs-lookup"><span data-stu-id="23a28-375">true</span></span>   |  <span data-ttu-id="23a28-376">false</span><span class="sxs-lookup"><span data-stu-id="23a28-376">false</span></span>  |    <span data-ttu-id="23a28-377">指定しません。</span><span class="sxs-lookup"><span data-stu-id="23a28-377">Absent.</span></span> <span data-ttu-id="23a28-378">実際には有効期限が存在し、将来の日付を指定する場合でも、その要素は XML ファイルから省略することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23a28-378">It actually may be present and specify a future date, but you're advised to omit the element from the XML file.</span></span> <span data-ttu-id="23a28-379">有効期限が存在し、過去の日付が指定されている場合、**IsActive** は無視され、false として扱われます。</span><span class="sxs-lookup"><span data-stu-id="23a28-379">If it is present and specifies a date in the past, then **IsActive** will be ignored and taken to be false.</span></span>          |
|  <span data-ttu-id="23a28-380">試用期間中</span><span class="sxs-lookup"><span data-stu-id="23a28-380">In trial period</span></span>  |    <span data-ttu-id="23a28-381">true</span><span class="sxs-lookup"><span data-stu-id="23a28-381">true</span></span>  |  <span data-ttu-id="23a28-382">true</span><span class="sxs-lookup"><span data-stu-id="23a28-382">true</span></span>   |      <span data-ttu-id="23a28-383">&lt;将来の日付と時刻&gt; **IsTrial** が true であるため、この要素を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-383">&lt;a datetime in the future&gt; This element must be present because **IsTrial** is true.</span></span> <span data-ttu-id="23a28-384">残りの試用期間に対応する有効期限は、現在の協定世界時 (UTC) を表示する Web サイトにアクセスして確認できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-384">You can visit a website showing the current Coordinated Universal Time (UTC) to know how far in the future to set this to get the remaining trial period you want.</span></span>         |
|  <span data-ttu-id="23a28-385">有効期限が切れた試用版</span><span class="sxs-lookup"><span data-stu-id="23a28-385">Expired trial</span></span>  |    <span data-ttu-id="23a28-386">false</span><span class="sxs-lookup"><span data-stu-id="23a28-386">false</span></span>  |  <span data-ttu-id="23a28-387">true</span><span class="sxs-lookup"><span data-stu-id="23a28-387">true</span></span>   |      <span data-ttu-id="23a28-388">&lt;過去の日付と時刻&gt; **IsTrial** が true であるため、この要素を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-388">&lt;a datetime in the past&gt; This element must be present because **IsTrial** is true.</span></span> <span data-ttu-id="23a28-389">UTC で表した "過去の" 有効期限は、現在の協定世界時 (UTC) を表示する Web サイトにアクセスして確認できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-389">You can visit a website showing the current Coordinated Universal Time (UTC) to know when "the past" is in UTC.</span></span>         |
|  <span data-ttu-id="23a28-390">ライセンスが無効</span><span class="sxs-lookup"><span data-stu-id="23a28-390">Invalid</span></span>  |    <span data-ttu-id="23a28-391">false</span><span class="sxs-lookup"><span data-stu-id="23a28-391">false</span></span>  | <span data-ttu-id="23a28-392">false</span><span class="sxs-lookup"><span data-stu-id="23a28-392">false</span></span>       |     <span data-ttu-id="23a28-393">&lt;任意の値または省略&gt;</span><span class="sxs-lookup"><span data-stu-id="23a28-393">&lt;any value or omitted&gt;</span></span>          |  |

<span id="app-child-of-licenseinformation"/>
#### <a name="app-element-child-of-licenseinformation"></a><span data-ttu-id="23a28-394">App 要素 (LicenseInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="23a28-394">App element (child of LicenseInformation)</span></span>

<span data-ttu-id="23a28-395">この要素は、アプリのライセンスを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-395">This element describes the app's license.</span></span> <span data-ttu-id="23a28-396">**App** は、[LicenseInformation](#licenseinformation) 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-396">**App** is a required child of the [LicenseInformation](#licenseinformation) element.</span></span>

<span data-ttu-id="23a28-397">**App** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-397">**App** contains the following child elements.</span></span>

|  <span data-ttu-id="23a28-398">要素</span><span class="sxs-lookup"><span data-stu-id="23a28-398">Element</span></span>  |  <span data-ttu-id="23a28-399">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-399">Required</span></span>  |  <span data-ttu-id="23a28-400">数量</span><span class="sxs-lookup"><span data-stu-id="23a28-400">Quantity</span></span>  | <span data-ttu-id="23a28-401">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-401">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="23a28-402">IsActive</span><span class="sxs-lookup"><span data-stu-id="23a28-402">IsActive</span></span>**  |    <span data-ttu-id="23a28-403">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-403">Yes</span></span>   |  <span data-ttu-id="23a28-404">1</span><span class="sxs-lookup"><span data-stu-id="23a28-404">1</span></span>   |    <span data-ttu-id="23a28-405">このアプリの現在のライセンスの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-405">Describes the current license state of this app.</span></span> <span data-ttu-id="23a28-406">値 **true** はライセンスが有効であることを示し、**false** はライセンスが無効であることを示します。</span><span class="sxs-lookup"><span data-stu-id="23a28-406">The value **true** indicates the license is valid; **false** indicates an invalid license.</span></span> <span data-ttu-id="23a28-407">この値はアプリが使用モードであるかどうかに関係なく、通常、**true** です。</span><span class="sxs-lookup"><span data-stu-id="23a28-407">Normally this value is **true**, whether the app has a trial mode or not.</span></span>  <span data-ttu-id="23a28-408">ライセンスが無効な場合にアプリがどのように動作するかをテストするには、この値を **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="23a28-408">Set this value to **false** to test how your app behaves when it has an invalid license.</span></span>           |
|  **<span data-ttu-id="23a28-409">IsTrial</span><span class="sxs-lookup"><span data-stu-id="23a28-409">IsTrial</span></span>**  |    <span data-ttu-id="23a28-410">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-410">Yes</span></span>  |  <span data-ttu-id="23a28-411">1</span><span class="sxs-lookup"><span data-stu-id="23a28-411">1</span></span>   |      <span data-ttu-id="23a28-412">このアプリが現在、試用期間中かどうかの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-412">Describes the current trial state of this app.</span></span> <span data-ttu-id="23a28-413">値 **true** はアプリが試用期間中であることを示します。**false** は、アプリが購入済みであるか、試用期限が切れたために、アプリが試用期間中でないことを示します。</span><span class="sxs-lookup"><span data-stu-id="23a28-413">The value **true** indicates the app is being used during the trial period; **false** indicates the app is not in a trial, either because the app has been purchased or the trial period has expired.</span></span>         |
|  **<span data-ttu-id="23a28-414">ExpirationDate</span><span class="sxs-lookup"><span data-stu-id="23a28-414">ExpirationDate</span></span>**  |    <span data-ttu-id="23a28-415">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-415">No</span></span>  |  <span data-ttu-id="23a28-416">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-416">0 or 1</span></span>       |     <span data-ttu-id="23a28-417">このアプリの試用期間が期限切れとなる日付 (協定世界時 (UTC)) です。</span><span class="sxs-lookup"><span data-stu-id="23a28-417">The date the trial period for this app expires, in Coordinated Universal Time (UTC).</span></span> <span data-ttu-id="23a28-418">日付は、yyyy-mm-ddThh:mm:ss.ssZ の形式で表す必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-418">The date must be expressed as: yyyy-mm-ddThh:mm:ss.ssZ.</span></span> <span data-ttu-id="23a28-419">たとえば、2015 年 1 月 19 日午前 5 時は、2015-01-19T05:00:00.00Z と表します。</span><span class="sxs-lookup"><span data-stu-id="23a28-419">For example, 05:00 on January 19, 2015 would be specified as 2015-01-19T05:00:00.00Z.</span></span> <span data-ttu-id="23a28-420">この要素は、**IsTrial** が **true** の場合に必須です。</span><span class="sxs-lookup"><span data-stu-id="23a28-420">This element is required when **IsTrial** is **true**.</span></span> <span data-ttu-id="23a28-421">そうでない場合は、必須ではありません。</span><span class="sxs-lookup"><span data-stu-id="23a28-421">Otherwise, it is not required.</span></span>          |  |

<span id="product-child-of-licenseinformation"/>
#### <a name="product-element-child-of-licenseinformation"></a><span data-ttu-id="23a28-422">Product 要素 (LicenseInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="23a28-422">Product element (child of LicenseInformation)</span></span>

<span data-ttu-id="23a28-423">この要素は、アプリ内の永続的なアドオンのライセンスの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-423">This element describes the license status of a durable add-on in the app.</span></span> <span data-ttu-id="23a28-424">**Product** は、[LicenseInformation](#licenseinformation) 要素のオプションの子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-424">**Product** is an optional child of the [LicenseInformation](#licenseinformation) element.</span></span>

<span data-ttu-id="23a28-425">**Product** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-425">**Product** contains the following child elements.</span></span>

|  <span data-ttu-id="23a28-426">要素</span><span class="sxs-lookup"><span data-stu-id="23a28-426">Element</span></span>  |  <span data-ttu-id="23a28-427">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-427">Required</span></span>  |  <span data-ttu-id="23a28-428">数量</span><span class="sxs-lookup"><span data-stu-id="23a28-428">Quantity</span></span>  | <span data-ttu-id="23a28-429">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-429">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="23a28-430">IsActive</span><span class="sxs-lookup"><span data-stu-id="23a28-430">IsActive</span></span>**  |    <span data-ttu-id="23a28-431">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-431">Yes</span></span>   |  <span data-ttu-id="23a28-432">1</span><span class="sxs-lookup"><span data-stu-id="23a28-432">1</span></span>     |    <span data-ttu-id="23a28-433">このアドオンの現在のライセンスの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-433">Describes the current license state of this add-on.</span></span> <span data-ttu-id="23a28-434">値 **true** はアドオンを追加できることを示し、**false** はアドオンを使用できないか、購入していないことを示します。</span><span class="sxs-lookup"><span data-stu-id="23a28-434">The value **true** indicates the add-on can be used; **false** indicates the add-on cannot be used or has not been purchased</span></span>           |
|  **<span data-ttu-id="23a28-435">ExpirationDate</span><span class="sxs-lookup"><span data-stu-id="23a28-435">ExpirationDate</span></span>**  |    <span data-ttu-id="23a28-436">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-436">No</span></span>   |  <span data-ttu-id="23a28-437">0 または 1</span><span class="sxs-lookup"><span data-stu-id="23a28-437">0 or 1</span></span>     |     <span data-ttu-id="23a28-438">協定世界時 (UTC) で表したアドオンの有効期限日です。</span><span class="sxs-lookup"><span data-stu-id="23a28-438">The date the add-on expires, in Coordinated Universal Time (UTC).</span></span> <span data-ttu-id="23a28-439">日付は、yyyy-mm-ddThh:mm:ss.ssZ の形式で表す必要があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-439">The date must be expressed as: yyyy-mm-ddThh:mm:ss.ssZ.</span></span> <span data-ttu-id="23a28-440">たとえば、2015 年 1 月 19 日午前 5 時は、2015-01-19T05:00:00.00Z と表します。</span><span class="sxs-lookup"><span data-stu-id="23a28-440">For example, 05:00 on January 19, 2015 would be specified as 2015-01-19T05:00:00.00Z.</span></span> <span data-ttu-id="23a28-441">この要素が存在する場合、アドオンには有効期限日があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-441">If this element is present, the add-on has an expiration date.</span></span> <span data-ttu-id="23a28-442">存在しない場合、アドオンに有効期限はありません。</span><span class="sxs-lookup"><span data-stu-id="23a28-442">If it's not present, the add-on does not expire.</span></span>  |  

<span data-ttu-id="23a28-443">**Product** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-443">**Product** has the following attributes.</span></span>

|  <span data-ttu-id="23a28-444">属性</span><span class="sxs-lookup"><span data-stu-id="23a28-444">Attribute</span></span>  |  <span data-ttu-id="23a28-445">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-445">Required</span></span>  |  <span data-ttu-id="23a28-446">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-446">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="23a28-447">ProductId</span><span class="sxs-lookup"><span data-stu-id="23a28-447">ProductId</span></span>**  |    <span data-ttu-id="23a28-448">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-448">Yes</span></span>        |   <span data-ttu-id="23a28-449">アプリがこのアドオンを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-449">Contains the string used by the app to identify the add-on.</span></span>            |
|  **<span data-ttu-id="23a28-450">OfferId</span><span class="sxs-lookup"><span data-stu-id="23a28-450">OfferId</span></span>**  |     <span data-ttu-id="23a28-451">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-451">No</span></span>       |   <span data-ttu-id="23a28-452">アプリが、このアドオンが属するカテゴリを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-452">Contains the string used by the app to identify the category in which the add-on belongs.</span></span> <span data-ttu-id="23a28-453">これを使うことで、「[アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)」で説明されている大規模なアイテムのカタログに対応できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-453">This provides support for large item catalogs, as described in [Manage a large catalog of in-app products](manage-a-large-catalog-of-in-app-products.md).</span></span>           |

<span id="simulation"/>
#### <a name="simulation-element"></a><span data-ttu-id="23a28-454">Simulation 要素</span><span class="sxs-lookup"><span data-stu-id="23a28-454">Simulation element</span></span>

<span data-ttu-id="23a28-455">この要素は、テストにおいて、さまざまな [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) メソッドへの呼び出しがどのように動作するかを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-455">This element describes how calls to various [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) methods will work in the app during testing.</span></span> <span data-ttu-id="23a28-456">**Simulation** は **CurrentApp** 要素のオプションの子要素であり、0 個以上の [DefaultResponse](#defaultresponse) 要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-456">**Simulation** is an optional child of the **CurrentApp** element, and it contains zero or more [DefaultResponse](#defaultresponse) elements.</span></span>

<span data-ttu-id="23a28-457">**Simulation** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-457">**Simulation** has the following attributes.</span></span>

|  <span data-ttu-id="23a28-458">属性</span><span class="sxs-lookup"><span data-stu-id="23a28-458">Attribute</span></span>  |  <span data-ttu-id="23a28-459">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-459">Required</span></span>  |  <span data-ttu-id="23a28-460">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-460">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="23a28-461">SimulationMode</span><span class="sxs-lookup"><span data-stu-id="23a28-461">SimulationMode</span></span>**  |    <span data-ttu-id="23a28-462">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-462">No</span></span>        |      <span data-ttu-id="23a28-463">値は **Interactive** か **Automatic** のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="23a28-463">Values can be **Interactive** or **Automatic**.</span></span> <span data-ttu-id="23a28-464">この属性を **Automatic** に設定すると、指定した HRESULT エラー コードがメソッドによって自動的に返されます。</span><span class="sxs-lookup"><span data-stu-id="23a28-464">When this attribute is set to **Automatic**, the methods will automatically return the specified HRESULT error codes.</span></span> <span data-ttu-id="23a28-465">これは自動化されたテスト ケースを実行する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-465">This can be used when running automated test cases.</span></span>       |

<span id="defaultresponse"/>
#### <a name="defaultresponse-element"></a><span data-ttu-id="23a28-466">DefaultResponse 要素</span><span class="sxs-lookup"><span data-stu-id="23a28-466">DefaultResponse element</span></span>

<span data-ttu-id="23a28-467">この要素は、**CurrentAppSimulator** メソッドによって返される既定のエラー コードを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-467">This element describes the default error code returned by a **CurrentAppSimulator** method.</span></span> <span data-ttu-id="23a28-468">**DefaultResponse** は、[Simulation](#simulation) 要素のオプションの子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-468">**DefaultResponse** is an optional child of the [Simulation](#simulation) element.</span></span>

<span data-ttu-id="23a28-469">**DefaultResponse** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-469">**DefaultResponse** has the following attributes.</span></span>

|  <span data-ttu-id="23a28-470">属性</span><span class="sxs-lookup"><span data-stu-id="23a28-470">Attribute</span></span>  |  <span data-ttu-id="23a28-471">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-471">Required</span></span>  |  <span data-ttu-id="23a28-472">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-472">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="23a28-473">MethodName</span><span class="sxs-lookup"><span data-stu-id="23a28-473">MethodName</span></span>**  |    <span data-ttu-id="23a28-474">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-474">Yes</span></span>        |   <span data-ttu-id="23a28-475">この属性は、[スキーマ](#schema) の **StoreMethodName** 型で表示される列挙値のいずれかに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="23a28-475">Assign this attribute to one of the enum values shown for the **StoreMethodName** type in the [schema](#schema).</span></span> <span data-ttu-id="23a28-476">これらの各列挙値は、テストのときにアプリでエラー コードの戻り値をシミュレートする **CurrentAppSimulator** メソッドを表します。</span><span class="sxs-lookup"><span data-stu-id="23a28-476">Each of these enum values represents a **CurrentAppSimulator** method for which you want to simulate an error code return value in your app during testing.</span></span> <span data-ttu-id="23a28-477">たとえば、値 **RequestAppPurchaseAsync_GetResult** は、[RequestAppPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.requestapppurchaseasync.aspx) メソッドのエラー コードの戻り値をシミュレートすることを示します。</span><span class="sxs-lookup"><span data-stu-id="23a28-477">For example, the value **RequestAppPurchaseAsync_GetResult** indicates you want to simulate the error code return value of the [RequestAppPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.requestapppurchaseasync.aspx) method.</span></span>            |
|  **<span data-ttu-id="23a28-478">HResult</span><span class="sxs-lookup"><span data-stu-id="23a28-478">HResult</span></span>**  |     <span data-ttu-id="23a28-479">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-479">Yes</span></span>       |   <span data-ttu-id="23a28-480">この属性は、[スキーマ](#schema) の **ResponseCodes** 型で表示される列挙値のいずれかに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="23a28-480">Assign this attribute to one of the enum values shown for the **ResponseCodes** type in the [schema](#schema).</span></span> <span data-ttu-id="23a28-481">これらの各列挙値は、この **DefaultResponse** 要素の **MethodName** 属性に割り当てるメソッドに対して返すエラーコードを表します。</span><span class="sxs-lookup"><span data-stu-id="23a28-481">Each of these enum values represents the error code you want to return for the method that is assigned to the **MethodName** attribute for this **DefaultResponse** element.</span></span>           |

<span id="consumableinformation"/>
#### <a name="consumableinformation-element"></a><span data-ttu-id="23a28-482">ConsumableInformation 要素</span><span class="sxs-lookup"><span data-stu-id="23a28-482">ConsumableInformation element</span></span>

<span data-ttu-id="23a28-483">この要素は、このアプリで利用可能なコンシューマブルなアドオンを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-483">This element describes the consumable add-ons available for this app.</span></span> <span data-ttu-id="23a28-484">**ConsumableInformation** は、**CurrentApp** 要素のオプションの子要素であり、0 個以上の [Product](#product-child-of-consumableinformation) 要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23a28-484">**ConsumableInformation** is an optional child of the **CurrentApp** element, and it can contain zero or more [Product](#product-child-of-consumableinformation) elements.</span></span>

<span id="product-child-of-consumableinformation"/>
#### <a name="product-element-child-of-consumableinformation"></a><span data-ttu-id="23a28-485">Product 要素 (ConsumableInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="23a28-485">Product element (child of ConsumableInformation)</span></span>

<span data-ttu-id="23a28-486">この要素は、コンシューマブルなアドオンを記述します。</span><span class="sxs-lookup"><span data-stu-id="23a28-486">This element describes a consumable add-on.</span></span> <span data-ttu-id="23a28-487">**Product** は、[ConsumableInformation](#consumableinformation) 要素のオプションの子要素です。</span><span class="sxs-lookup"><span data-stu-id="23a28-487">**Product** is an optional child of the [ConsumableInformation](#consumableinformation) element.</span></span>

<span data-ttu-id="23a28-488">**Product** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="23a28-488">**Product** has the following attributes.</span></span>

|  <span data-ttu-id="23a28-489">属性</span><span class="sxs-lookup"><span data-stu-id="23a28-489">Attribute</span></span>  |  <span data-ttu-id="23a28-490">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="23a28-490">Required</span></span>  |  <span data-ttu-id="23a28-491">説明</span><span class="sxs-lookup"><span data-stu-id="23a28-491">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="23a28-492">ProductId</span><span class="sxs-lookup"><span data-stu-id="23a28-492">ProductId</span></span>**  |    <span data-ttu-id="23a28-493">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-493">Yes</span></span>        |   <span data-ttu-id="23a28-494">アプリがこのコンシューマブルなアドオンを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-494">Contains the string used by the app to identify the consumable add-on.</span></span>            |
|  **<span data-ttu-id="23a28-495">TransactionId</span><span class="sxs-lookup"><span data-stu-id="23a28-495">TransactionId</span></span>**  |     <span data-ttu-id="23a28-496">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-496">Yes</span></span>       |   <span data-ttu-id="23a28-497">アプリが、フルフィルメントのプロセス全体を通じ、コンシューマブルの購入トランザクションを追跡するために使用する GUID (文字列) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-497">Contains a GUID (as a string) used by the app to track the purchase transaction of a consumable through the process of fulfillment.</span></span> <span data-ttu-id="23a28-498">詳しくは、「[コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23a28-498">See [Enable consumable in-app product purchases](enable-consumable-in-app-product-purchases.md).</span></span>            |
|  **<span data-ttu-id="23a28-499">Status</span><span class="sxs-lookup"><span data-stu-id="23a28-499">Status</span></span>**  |      <span data-ttu-id="23a28-500">必須</span><span class="sxs-lookup"><span data-stu-id="23a28-500">Yes</span></span>      |  <span data-ttu-id="23a28-501">アプリが、コンシューマブルのフルフィルメントの状態を示すために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-501">Contains the string used by the app to indicate the fulfillment status of a consumable.</span></span> <span data-ttu-id="23a28-502">値は、**Active**、**PurchaseReverted**、**PurchasePending**、または **ServerError** です。</span><span class="sxs-lookup"><span data-stu-id="23a28-502">Values can be **Active**, **PurchaseReverted**, **PurchasePending**, or **ServerError**.</span></span>             |
|  **<span data-ttu-id="23a28-503">OfferId</span><span class="sxs-lookup"><span data-stu-id="23a28-503">OfferId</span></span>**  |     <span data-ttu-id="23a28-504">必須ではない</span><span class="sxs-lookup"><span data-stu-id="23a28-504">No</span></span>       |    <span data-ttu-id="23a28-505">アプリが、このコンシューマブルが属するカテゴリを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23a28-505">Contains the string used by the app to identify the category in which the consumable belongs.</span></span> <span data-ttu-id="23a28-506">これを使うことで、「[アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)」で説明されている大規模なアイテムのカタログに対応できます。</span><span class="sxs-lookup"><span data-stu-id="23a28-506">This provides support for large item catalogs, as described in [Manage a large catalog of in-app products](manage-a-large-catalog-of-in-app-products.md).</span></span>           |
