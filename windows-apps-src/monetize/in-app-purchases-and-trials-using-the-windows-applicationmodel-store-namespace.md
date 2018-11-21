---
author: Xansky
ms.assetid: 32572890-26E3-4FBB-985B-47D61FF7F387
description: Windows 10 バージョン 1607 より前のリリースを対象とする UWP アプリでのアプリ内購入と試用版を有効にする方法を説明します。
title: Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版
ms.author: mhopkins
ms.date: 08/25/2017
ms.topic: article
keywords: UWP, アプリ内購入, IAP, アドオン, 試用版, Windows.ApplicationModel.Store
ms.localizationpriority: medium
ms.openlocfilehash: 28fe27cc4464598414fec11d6812e2e9ea377aff
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7425936"
---
# <a name="in-app-purchases-and-trials-using-the-windowsapplicationmodelstore-namespace"></a><span data-ttu-id="3d868-104">Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版</span><span class="sxs-lookup"><span data-stu-id="3d868-104">In-app purchases and trials using the Windows.ApplicationModel.Store namespace</span></span>

<span data-ttu-id="3d868-105">[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーを使って、ユニバーサル Windows プラットフォーム (UWP) アプリにアプリ内購入機能や試用版機能を追加し、アプリの収益化に役立てることができます。</span><span class="sxs-lookup"><span data-stu-id="3d868-105">You can use members in the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace to add in-app purchases and trial functionality to your Universal Windows Platform (UWP) app to help monetize your app.</span></span> <span data-ttu-id="3d868-106">このような API では、アプリのライセンス情報にもアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="3d868-106">These APIs also provide access to the license info for your app.</span></span>

<span data-ttu-id="3d868-107">このセクションの記事では、いくつかの一般的なシナリオにおいて **Windows.ApplicationModel.Store** 名前空間のメンバーを使用するための詳しいガイダンスとコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="3d868-107">The articles in this section provide in-depth guidance and code examples for using the members in the **Windows.ApplicationModel.Store** namespace for several common scenarios.</span></span> <span data-ttu-id="3d868-108">UWP アプリのアプリ内での購入に関する基本概念の概要については、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-108">For an overview of basic concepts related to in-app purchases in UWP apps, see [In-app purchases and trials](in-app-purchases-and-trials.md).</span></span> <span data-ttu-id="3d868-109">**Windows.ApplicationModel.Store** 名前空間を使用した試用版とアプリ内購入の実装方法を示す完全なサンプルについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-109">For a complete sample that demonstrates how to implement trials and in-app purchases using the **Windows.ApplicationModel.Store** namespace, see the [Store sample](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3d868-110">**Windows.ApplicationModel.Store** 名前空間は今後更新されず、新機能も追加されません。</span><span class="sxs-lookup"><span data-stu-id="3d868-110">The **Windows.ApplicationModel.Store** namespace is no longer being updated with new features.</span></span> <span data-ttu-id="3d868-111">Visual Studio でプロジェクトのターゲットを **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースに設定している (つまり、Windows 10 Version 1607 以降をターゲットとしている) 場合は、代わりに [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3d868-111">If your project targets **Windows 10 Anniversary Edition (10.0; Build 14393)** or a later release in Visual Studio (that is, you are targeting Windows 10, version 1607, or later), we recommend that you use the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace instead.</span></span> <span data-ttu-id="3d868-112">詳しくは、「[アプリ内購入と試用版](https://msdn.microsoft.com/windows/uwp/monetize/in-app-purchases-and-trials)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-112">For more information, see [In-app purchases and trials](https://msdn.microsoft.com/windows/uwp/monetize/in-app-purchases-and-trials).</span></span> <span data-ttu-id="3d868-113">**Windows.ApplicationModel.Store**名前空間は、[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用する Windows デスクトップ アプリケーションで、またはアプリやパートナー センターで開発サンド ボックスを使用するゲームでサポートされていません (たとえば、このような場合にゲームのいずれかのXbox Live と統合)。</span><span class="sxs-lookup"><span data-stu-id="3d868-113">The **Windows.ApplicationModel.Store** namespace is not supported in Windows desktop applications that use the [Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) or in apps or games that use a development sandbox in Partner Center (for example, this is the case for any game that integrates with Xbox Live).</span></span> <span data-ttu-id="3d868-114">このような製品では、**Windows.Services.Store** 名前空間を使ってアプリ内購入と試用版を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-114">These products must use the **Windows.Services.Store** namespace to implement in-app purchases and trials.</span></span>

## <a name="get-started-with-the-currentapp-and-currentappsimulator-classes"></a><span data-ttu-id="3d868-115">CurrentApp クラスと CurrentAppSimulator クラスの概要</span><span class="sxs-lookup"><span data-stu-id="3d868-115">Get started with the CurrentApp and CurrentAppSimulator classes</span></span>

<span data-ttu-id="3d868-116">**Windows.ApplicationModel.Store** 名前空間へのメイン エントリ ポイントは、[CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) クラスです。</span><span class="sxs-lookup"><span data-stu-id="3d868-116">The main entry point to the **Windows.ApplicationModel.Store** namespace is the [CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) class.</span></span> <span data-ttu-id="3d868-117">このクラスには、現在のアプリとその利用可能なアドオンに関する情報の取得、現在のアプリまたはそのアドオンに関するライセンス情報の取得、現在のユーザー向けのアプリまたはアドオンの購入、およびその他のタスクを行う際に使用できる静的プロパティおよびメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="3d868-117">This class provides static properties and methods you can use to get info for the current app and its available add-ons, get license info for the current app or its add-ons, purchase an app or add-on for the current user, and perform other tasks.</span></span>

<span data-ttu-id="3d868-118">[CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) クラスは Microsoft Store からデータを取得するため、アプリ内でこのクラスを使うには、開発者が開発者アカウントを持っていて、アプリが Microsoft Store で公開されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-118">The [CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) class obtains its data from the Microsoft Store, so you must have a developer account and the app must be published in the Store before you can successfully use this class in your app.</span></span> <span data-ttu-id="3d868-119">アプリをまだ Microsoft Store に提出していない場合は、このクラスのシミュレートされたバージョンである [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) を使ってコードをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="3d868-119">Before you submit your app to the Store, you can test your code with a simulated version of this class called [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx).</span></span> <span data-ttu-id="3d868-120">アプリのテストが完了したら、Microsoft Store に提出する前に **CurrentAppSimulator** のインスタンスを **CurrentApp** に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-120">After you test your app, and before you submit it to the Microsoft Store, you must replace the instances of **CurrentAppSimulator** with **CurrentApp**.</span></span> <span data-ttu-id="3d868-121">アプリで **CurrentAppSimulator** が使用されている場合は、認定が不合格になります。</span><span class="sxs-lookup"><span data-stu-id="3d868-121">Your app will fail certification if it uses **CurrentAppSimulator**.</span></span>

<span data-ttu-id="3d868-122">**CurrentAppSimulator** を使う場合、アプリのライセンスとアプリ内製品の初期状態は、開発コンピューター上にある WindowsStoreProxy.xml という名前のローカル ファイルに記述されています。</span><span class="sxs-lookup"><span data-stu-id="3d868-122">When the **CurrentAppSimulator** is used, the initial state of your app's licensing and in-app products is described in a local file on your development computer named WindowsStoreProxy.xml.</span></span> <span data-ttu-id="3d868-123">このファイルについて詳しくは、「[CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用](#proxy)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-123">For more information about this file, see [Using the WindowsStoreProxy.xml file with CurrentAppSimulator](#proxy).</span></span>

<span data-ttu-id="3d868-124">**CurrentApp** と **CurrentAppSimulator** を使って実行できる一般的なタスクについて詳しくは、次の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-124">For more information about common tasks you can perform using **CurrentApp** and **CurrentAppSimulator**, see the following articles.</span></span>

| <span data-ttu-id="3d868-125">トピック</span><span class="sxs-lookup"><span data-stu-id="3d868-125">Topic</span></span>       | <span data-ttu-id="3d868-126">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-126">Description</span></span>                 |
|----------------------------|-----------------------------|
| [<span data-ttu-id="3d868-127">試用版での機能の除外または制限</span><span class="sxs-lookup"><span data-stu-id="3d868-127">Exclude or limit features in a trial version</span></span>](exclude-or-limit-features-in-a-trial-version-of-your-app.md) | <span data-ttu-id="3d868-128">ユーザーがアプリを無料で使うことができる試用期間を設け、その期間中は一部の機能を除外または制限することで、アプリを通常版にアップグレードするようユーザーに促すことができます。</span><span class="sxs-lookup"><span data-stu-id="3d868-128">If you enable customers to use your app for free during a trial period, you can entice your customers to upgrade to the full version of your app by excluding or limiting some features during the trial period.</span></span> |
| [<span data-ttu-id="3d868-129">アプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="3d868-129">Enable in-app product purchases</span></span>](enable-in-app-product-purchases.md)      |  <span data-ttu-id="3d868-130">アプリが無料であるかどうかにかかわらず、コンテンツ、その他のアプリ、アプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-130">Whether your app is free or not, you can sell content, other apps, or new app functionality (such as unlocking the next level of a game) from right within the app.</span></span> <span data-ttu-id="3d868-131">ここでは、アプリ内で製品を販売できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3d868-131">Here we show you how to enable these products in your app.</span></span>  |
| [<span data-ttu-id="3d868-132">コンシューマブルなアプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="3d868-132">Enable consumable in-app product purchases</span></span>](enable-consumable-in-app-product-purchases.md)      | <span data-ttu-id="3d868-133">ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-133">Offer consumable in-app products—items that can be purchased, used, and purchased again—through the Store commerce platform to provide your customers with a purchase experience that is both robust and reliable.</span></span> <span data-ttu-id="3d868-134">これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="3d868-134">This is especially useful for things like in-game currency (gold, coins, etc.) that can be purchased and then used to purchase specific power-ups.</span></span> |
| [<span data-ttu-id="3d868-135">アプリ内製品の大規模なカタログの管理</span><span class="sxs-lookup"><span data-stu-id="3d868-135">Manage a large catalog of in-app products</span></span>](manage-a-large-catalog-of-in-app-products.md)      |   <span data-ttu-id="3d868-136">アプリ内製品のカタログが大きくなる場合、カタログを管理するためにこのトピックで説明するプロセスを採用できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-136">If your app offers a large in-app product catalog, you can optionally follow the process described in this topic to help manage your catalog.</span></span>    |
| [<span data-ttu-id="3d868-137">受領通知を使った製品購入の確認</span><span class="sxs-lookup"><span data-stu-id="3d868-137">Use receipts to verify product purchases</span></span>](use-receipts-to-verify-product-purchases.md)      |   <span data-ttu-id="3d868-138">製品購入が成功した各 Microsoft Store トランザクションでは、必要に応じてトランザクションの通知を返し、掲載製品と料金についての情報をユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-138">Each Microsoft Store transaction that results in a successful product purchase can optionally return a transaction receipt that provides information about the listed product and monetary cost to the customer.</span></span> <span data-ttu-id="3d868-139">この情報は、ユーザーがアプリを購入したことや、Microsoft Store からアプリ内製品の購入が行われたことをアプリで確認する必要がある場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3d868-139">Having access to this information supports scenarios where your app needs to verify that a user purchased your app, or has made in-app product purchases from the Microsoft Store.</span></span> |

<span id="proxy" />

## <a name="using-the-windowsstoreproxyxml-file-with-currentappsimulator"></a><span data-ttu-id="3d868-140">CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用</span><span class="sxs-lookup"><span data-stu-id="3d868-140">Using the WindowsStoreProxy.xml file with CurrentAppSimulator</span></span>

<span data-ttu-id="3d868-141">**CurrentAppSimulator** を使う場合、アプリのライセンスとアプリ内製品の初期状態は、開発コンピューター上にある WindowsStoreProxy.xml という名前のローカル ファイルに記述されています。</span><span class="sxs-lookup"><span data-stu-id="3d868-141">When the **CurrentAppSimulator** is used, the initial state of your app's licensing and in-app products is described in a local file on your development computer named WindowsStoreProxy.xml.</span></span> <span data-ttu-id="3d868-142">**CurrentAppSimulator** メソッドは、ライセンスの購入やアプリ内での購入処理などに応じてアプリの状態を変更しますが、更新されるのはメモリ内の **CurrentAppSimulator** オブジェクトの状態のみです。</span><span class="sxs-lookup"><span data-stu-id="3d868-142">**CurrentAppSimulator** methods that alter the app's state, for example by buying a license or handling an in-app purchase, only update the state of the **CurrentAppSimulator** object in memory.</span></span> <span data-ttu-id="3d868-143">WindowsStoreProxy.xml の内容は変更されません。</span><span class="sxs-lookup"><span data-stu-id="3d868-143">The contents of WindowsStoreProxy.xml are not changed.</span></span> <span data-ttu-id="3d868-144">アプリを再起動すると、ライセンスの状態は、WindowsStoreProxy.xml に記述されている内容に戻ります。</span><span class="sxs-lookup"><span data-stu-id="3d868-144">When the app starts again, the license state reverts to what is described in WindowsStoreProxy.xml.</span></span>

<span data-ttu-id="3d868-145">WindowsStoreProxy.xml ファイルは、既定で %UserProfile%\AppData\Local\Packages\\&lt;Local\Packages&gt;\LocalState\Microsoft\Windows Store\ApiData に作成されます。</span><span class="sxs-lookup"><span data-stu-id="3d868-145">A WindowsStoreProxy.xml file is created by default at the following location: %UserProfile%\AppData\Local\Packages\\&lt;app package folder&gt;\LocalState\Microsoft\Windows Store\ApiData.</span></span> <span data-ttu-id="3d868-146">このファイルを編集して、シミュレートするシナリオを **CurrentAppSimulator** プロパティで定義できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-146">You can edit this file to define the scenario that you want to simulate in the **CurrentAppSimulator** properties.</span></span>

<span data-ttu-id="3d868-147">このファイルの値を変更することは可能ですが、直接変更するのではなく、独自の WindowsStoreProxy.xml ファイルを (Visual Studio プロジェクトのデータ フォルダーに) 作成し、**CurrentAppSimulator** で使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3d868-147">Although you can modify the values in this file, we recommend that you create your own WindowsStoreProxy.xml file (in a data folder of your Visual Studio project) for **CurrentAppSimulator** to use instead.</span></span> <span data-ttu-id="3d868-148">トランザクションをシミュレートするには、[ReloadSimulatorAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.reloadsimulatorasync) を呼び出して、作成したファイルを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="3d868-148">When simulating the transaction, call [ReloadSimulatorAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.reloadsimulatorasync) to load your file.</span></span> <span data-ttu-id="3d868-149">**ReloadSimulatorAsync** を呼び出して独自の WindowsStoreProxy.xml ファイルを読み込まない場合、**CurrentAppSimulator** は既定の WindowsStoreProxy.xml ファイルを作成して読み込みます (上書きはしません)。</span><span class="sxs-lookup"><span data-stu-id="3d868-149">If you do not call **ReloadSimulatorAsync** to load your own WindowsStoreProxy.xml file, **CurrentAppSimulator** will create/load (but not overwrite) the default WindowsStoreProxy.xml file.</span></span>

> [!NOTE]
> <span data-ttu-id="3d868-150">**CurrentAppSimulator** は、**ReloadSimulatorAsync** が完了するまで完全には初期化されません。</span><span class="sxs-lookup"><span data-stu-id="3d868-150">Be aware that **CurrentAppSimulator** is not fully initialized until **ReloadSimulatorAsync** completes.</span></span> <span data-ttu-id="3d868-151">**ReloadSimulatorAsync** は非同期メソッドであるため、1 つのスレッドで **CurrentAppSimulator** が照会されているときに、別のスレッドでそれが初期化されているといった競合状態が起こらないように注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-151">And, since **ReloadSimulatorAsync** is an asynchronous method, care should be taken to avoid the race condition of querying **CurrentAppSimulator** on one thread while it is being initialized on another.</span></span> <span data-ttu-id="3d868-152">これにはフラグを使って初期化の完了を示すのも 1 つの方法です。</span><span class="sxs-lookup"><span data-stu-id="3d868-152">One technique is to use a flag to indicate that initialization is complete.</span></span> <span data-ttu-id="3d868-153">Microsoft Store からインストールされるアプリでは、**CurrentAppSimulator** ではなく **CurrentApp** を使う必要があります。これにより、**ReloadSimulatorAsync** が呼び出されなくなり、そのような競合状態は発生しなくなります。</span><span class="sxs-lookup"><span data-stu-id="3d868-153">An app that is installed from the Microsoft Store must use **CurrentApp** instead of **CurrentAppSimulator**, and in that case **ReloadSimulatorAsync** is not called and therefore the race condition just mentioned does not apply.</span></span> <span data-ttu-id="3d868-154">このため、コードは同期と非同期の両方で動作するように設計する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-154">For this reason, design your code so that it will work in both cases, both asychronously and synchronously.</span></span>


<span id="proxy-examples" />

### <a name="examples"></a><span data-ttu-id="3d868-155">例</span><span class="sxs-lookup"><span data-stu-id="3d868-155">Examples</span></span>

<span data-ttu-id="3d868-156">以下の例では、試用モードのアプリを記述する WindowsStoreProxy.xml ファイル (UTF-16 エンコード) を示します。このアプリは、2015 年 1 月 19 日午前 5 時 (UTC) に試用モードの有効期限が切れます。</span><span class="sxs-lookup"><span data-stu-id="3d868-156">This example is a WindowsStoreProxy.xml file (UTF-16 encoded) that describes an app with a trial mode that expires at 05:00 (UTC) on Jan. 19, 2015.</span></span>

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

<span data-ttu-id="3d868-157">次の例では、購入済みのアプリを記述する WindowsStoreProxy.xml ファイル (UTF-16 エンコード) を示します。このアプリには、2015 年 1 月 19 日午前 5 時 (UTC) に有効期限が切れる機能と、コンシューマブルなアプリ内での購入があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-157">The next example is a WindowsStoreProxy.xml file (UTF-16 encoded) that describes an app that has been purchased, has a feature that expires at 05:00 (UTC) on Jan. 19, 2015, and has a consumable in-app purchase.</span></span>

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

### <a name="schema"></a><span data-ttu-id="3d868-158">スキーマ</span><span class="sxs-lookup"><span data-stu-id="3d868-158">Schema</span></span>

<span data-ttu-id="3d868-159">このセクションでは、WindowsStoreProxy.xml ファイルの構造を定義する XSD ファイルを示します。</span><span class="sxs-lookup"><span data-stu-id="3d868-159">This section lists the XSD file that defines the structure of the WindowsStoreProxy.xml file.</span></span> <span data-ttu-id="3d868-160">WindowsStoreProxy.xml ファイルで作業するときに、このスキーマを Visual Studio の XML エディターに適用するには、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="3d868-160">To apply this schema to the XML editor in Visual Studio when working with your WindowsStoreProxy.xml file, do the following:</span></span>

1. <span data-ttu-id="3d868-161">Visual Studio で WindowsStoreProxy.xml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="3d868-161">Open the WindowsStoreProxy.xml file in Visual Studio.</span></span>
2. <span data-ttu-id="3d868-162">**[XML]** メニューの **[スキーマの作成]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3d868-162">On the **XML** menu, click **Create Schema**.</span></span> <span data-ttu-id="3d868-163">XML ファイルの内容に基づいて、WindowsStoreProxy.xsd 一時ファイルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="3d868-163">This will create a temporary WindowsStoreProxy.xsd file based on the contents of the XML file.</span></span>
3. <span data-ttu-id="3d868-164">その .xsd ファイルの内容を下記のスキーマと置き換えます。</span><span class="sxs-lookup"><span data-stu-id="3d868-164">Replace the contents of that .xsd file with the schema below.</span></span>
4. <span data-ttu-id="3d868-165">複数のアプリ プロジェクトに適用できる場所に、作成したファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="3d868-165">Save the file to a location where you can apply it to multiple app projects.</span></span>
5. <span data-ttu-id="3d868-166">Visual Studio で、この WindowsStoreProxy.xml ファイルに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="3d868-166">Switch to your WindowsStoreProxy.xml file in Visual Studio.</span></span>
6. <span data-ttu-id="3d868-167">**[XML]** メニューで **[スキーマ]** をクリックし、一覧から WindowsStoreProxy.xsd ファイルの行を探します。</span><span class="sxs-lookup"><span data-stu-id="3d868-167">On the **XML** menu, click **Schemas**, then locate the row in the list for the WindowsStoreProxy.xsd file.</span></span> <span data-ttu-id="3d868-168">ファイルの場所が適切でない場合 (たとえば、一時ファイルがまだ表示されている場合) は、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3d868-168">If the location for the file is not the one you want (for example, if the temporary file is still shown), click **Add**.</span></span> <span data-ttu-id="3d868-169">適切なファイルに移動し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3d868-169">Navigate to the right file, then click **OK**.</span></span> <span data-ttu-id="3d868-170">一覧にそのファイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3d868-170">You should now see that file in the list.</span></span> <span data-ttu-id="3d868-171">そのスキーマの \*\*[使用] \*\* 列にチェックマークが入っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3d868-171">Make sure a checkmark appears in the **Use** column for that schema.</span></span>

<span data-ttu-id="3d868-172">この操作を完了すると、WindowsStoreProxy.xml に加えた変更内容がスキーマに適用されます。</span><span class="sxs-lookup"><span data-stu-id="3d868-172">Once you've done this, edits you make to WindowsStoreProxy.xml will be subject to the schema.</span></span> <span data-ttu-id="3d868-173">詳しくは、「[方法: 使用する XML スキーマを選択する](http://go.microsoft.com/fwlink/p/?LinkId=403014)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-173">For more information, see [How to: Select the XML Schemas to Use](http://go.microsoft.com/fwlink/p/?LinkId=403014).</span></span>

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

### <a name="element-and-attribute-descriptions"></a><span data-ttu-id="3d868-174">要素と属性の説明</span><span class="sxs-lookup"><span data-stu-id="3d868-174">Element and attribute descriptions</span></span>

<span data-ttu-id="3d868-175">このセクションでは、WindowsStoreProxy.xml ファイル内の要素と属性について説明します。</span><span class="sxs-lookup"><span data-stu-id="3d868-175">This section describes the elements and attributes in the WindowsStoreProxy.xml file.</span></span>

<span data-ttu-id="3d868-176">このファイルのルート要素は、現在のアプリを表す **CurrentApp**要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-176">The root element of this file is the **CurrentApp** element, which represents the current app.</span></span> <span data-ttu-id="3d868-177">この要素には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-177">This element contains the following child elements.</span></span>

|  <span data-ttu-id="3d868-178">要素</span><span class="sxs-lookup"><span data-stu-id="3d868-178">Element</span></span>  |  <span data-ttu-id="3d868-179">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-179">Required</span></span>  |  <span data-ttu-id="3d868-180">数量</span><span class="sxs-lookup"><span data-stu-id="3d868-180">Quantity</span></span>  |  <span data-ttu-id="3d868-181">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-181">Description</span></span>   |
|-------------|------------|--------|--------|
|  [<span data-ttu-id="3d868-182">ListingInformation</span><span class="sxs-lookup"><span data-stu-id="3d868-182">ListingInformation</span></span>](#listinginformation)  |    <span data-ttu-id="3d868-183">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-183">Yes</span></span>        |  <span data-ttu-id="3d868-184">1</span><span class="sxs-lookup"><span data-stu-id="3d868-184">1</span></span>  |  <span data-ttu-id="3d868-185">アプリの登録情報のデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-185">Contains data from the app's listing.</span></span>            |
|  [<span data-ttu-id="3d868-186">LicenseInformation</span><span class="sxs-lookup"><span data-stu-id="3d868-186">LicenseInformation</span></span>](#licenseinformation)  |     <span data-ttu-id="3d868-187">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-187">Yes</span></span>       |   <span data-ttu-id="3d868-188">1</span><span class="sxs-lookup"><span data-stu-id="3d868-188">1</span></span>    |   <span data-ttu-id="3d868-189">このアプリで利用可能なライセンスと永続的なアドオンが記述されています。</span><span class="sxs-lookup"><span data-stu-id="3d868-189">Describes the licenses available for this app and its durable add-ons.</span></span>     |
|  [<span data-ttu-id="3d868-190">ConsumableInformation</span><span class="sxs-lookup"><span data-stu-id="3d868-190">ConsumableInformation</span></span>](#consumableinformation)  |      <span data-ttu-id="3d868-191">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-191">No</span></span>      |   <span data-ttu-id="3d868-192">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-192">0 or 1</span></span>   |   <span data-ttu-id="3d868-193">このアプリで利用可能なコンシューマブルなアドオンが記述されています。</span><span class="sxs-lookup"><span data-stu-id="3d868-193">Describes the consumable add-ons that are available for this app.</span></span>      |
|  [<span data-ttu-id="3d868-194">Simulation</span><span class="sxs-lookup"><span data-stu-id="3d868-194">Simulation</span></span>](#simulation)  |     <span data-ttu-id="3d868-195">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-195">No</span></span>       |      <span data-ttu-id="3d868-196">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-196">0 or 1</span></span>      |   <span data-ttu-id="3d868-197">テストで、さまざまな [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) メソッドを呼び出したときに行われる動作が記述されています。</span><span class="sxs-lookup"><span data-stu-id="3d868-197">Describes how calls to various [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) methods will work in the app during testing.</span></span>    |

<span id="listinginformation" />

#### <a name="listinginformation-element"></a><span data-ttu-id="3d868-198">ListingInformation 要素</span><span class="sxs-lookup"><span data-stu-id="3d868-198">ListingInformation element</span></span>

<span data-ttu-id="3d868-199">この要素には、アプリの登録情報のデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-199">This element contains data from the app's listing.</span></span> <span data-ttu-id="3d868-200">**ListingInformation** は、**CurrentApp** 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-200">**ListingInformation** is a required child of the **CurrentApp** element.</span></span>

<span data-ttu-id="3d868-201">**ListingInformation** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-201">**ListingInformation** contains the following child elements.</span></span>

|  <span data-ttu-id="3d868-202">要素</span><span class="sxs-lookup"><span data-stu-id="3d868-202">Element</span></span>  |  <span data-ttu-id="3d868-203">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-203">Required</span></span>  |  <span data-ttu-id="3d868-204">数量</span><span class="sxs-lookup"><span data-stu-id="3d868-204">Quantity</span></span>  |  <span data-ttu-id="3d868-205">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-205">Description</span></span>   |
|-------------|------------|--------|--------|
|  [<span data-ttu-id="3d868-206">App</span><span class="sxs-lookup"><span data-stu-id="3d868-206">App</span></span>](#app-child-of-listinginformation)  |    <span data-ttu-id="3d868-207">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-207">Yes</span></span>   |  <span data-ttu-id="3d868-208">1</span><span class="sxs-lookup"><span data-stu-id="3d868-208">1</span></span>   |    <span data-ttu-id="3d868-209">アプリに関するデータを提供します。</span><span class="sxs-lookup"><span data-stu-id="3d868-209">Provides data about the app.</span></span>         |
|  [<span data-ttu-id="3d868-210">Product</span><span class="sxs-lookup"><span data-stu-id="3d868-210">Product</span></span>](#product-child-of-listinginformation)  |    <span data-ttu-id="3d868-211">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-211">No</span></span>  |  <span data-ttu-id="3d868-212">0 以上</span><span class="sxs-lookup"><span data-stu-id="3d868-212">0 or more</span></span>   |      <span data-ttu-id="3d868-213">アプリのアドオンを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-213">Describes an add-on for the app.</span></span>     |     |

<span id="app-child-of-listinginformation"/>

#### <a name="app-element-child-of-listinginformation"></a><span data-ttu-id="3d868-214">App 要素 (ListingInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="3d868-214">App element (child of ListingInformation)</span></span>

<span data-ttu-id="3d868-215">この要素は、アプリのライセンスを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-215">This element describes the app's license.</span></span> <span data-ttu-id="3d868-216">**App** は、[ListingInformation](#listinginformation) 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-216">**App** is a required child of the [ListingInformation](#listinginformation) element.</span></span>

<span data-ttu-id="3d868-217">**App** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-217">**App** contains the following child elements.</span></span>

|  <span data-ttu-id="3d868-218">要素</span><span class="sxs-lookup"><span data-stu-id="3d868-218">Element</span></span>  |  <span data-ttu-id="3d868-219">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-219">Required</span></span>  |  <span data-ttu-id="3d868-220">数量</span><span class="sxs-lookup"><span data-stu-id="3d868-220">Quantity</span></span>  | <span data-ttu-id="3d868-221">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-221">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="3d868-222">AppId</span><span class="sxs-lookup"><span data-stu-id="3d868-222">AppId</span></span>**  |    <span data-ttu-id="3d868-223">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-223">Yes</span></span>   |  <span data-ttu-id="3d868-224">1</span><span class="sxs-lookup"><span data-stu-id="3d868-224">1</span></span>   |   <span data-ttu-id="3d868-225">ストアでアプリを識別する GUID です。</span><span class="sxs-lookup"><span data-stu-id="3d868-225">The GUID that identifies the app in the Store.</span></span> <span data-ttu-id="3d868-226">テストでは任意の GUID を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-226">This can be any GUID for testing.</span></span>        |
|  **<span data-ttu-id="3d868-227">LinkUri</span><span class="sxs-lookup"><span data-stu-id="3d868-227">LinkUri</span></span>**  |    <span data-ttu-id="3d868-228">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-228">Yes</span></span>  |  <span data-ttu-id="3d868-229">1</span><span class="sxs-lookup"><span data-stu-id="3d868-229">1</span></span>   |    <span data-ttu-id="3d868-230">ストアの登録情報ページの URI です。</span><span class="sxs-lookup"><span data-stu-id="3d868-230">The URI of the listing page in the store.</span></span> <span data-ttu-id="3d868-231">テストでは任意の有効な URI を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-231">This can be any valid URI for testing.</span></span>         |
|  **<span data-ttu-id="3d868-232">CurrentMarket</span><span class="sxs-lookup"><span data-stu-id="3d868-232">CurrentMarket</span></span>**  |    <span data-ttu-id="3d868-233">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-233">Yes</span></span>  |  <span data-ttu-id="3d868-234">1</span><span class="sxs-lookup"><span data-stu-id="3d868-234">1</span></span>   |    <span data-ttu-id="3d868-235">顧客の国/地域です。</span><span class="sxs-lookup"><span data-stu-id="3d868-235">The customer's country/region.</span></span>         |
|  **<span data-ttu-id="3d868-236">AgeRating</span><span class="sxs-lookup"><span data-stu-id="3d868-236">AgeRating</span></span>**  |    <span data-ttu-id="3d868-237">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-237">Yes</span></span>  |  <span data-ttu-id="3d868-238">1</span><span class="sxs-lookup"><span data-stu-id="3d868-238">1</span></span>   |     <span data-ttu-id="3d868-239">アプリの年齢区分の下限を表す整数です。</span><span class="sxs-lookup"><span data-stu-id="3d868-239">An integer that represents the minimum age rating of the app.</span></span> <span data-ttu-id="3d868-240">これは、アプリの提出時にパートナー センターで指定するのと同じ値です。</span><span class="sxs-lookup"><span data-stu-id="3d868-240">This is the same value you would specify in Partner Center when you submit the app.</span></span> <span data-ttu-id="3d868-241">ストアで使われる値は、3、7、12、および 16 です。</span><span class="sxs-lookup"><span data-stu-id="3d868-241">The values used by the Store are: 3, 7, 12, and 16.</span></span> <span data-ttu-id="3d868-242">これらの年齢区分について詳しくは、「[年齢区分](../publish/age-ratings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-242">For more info on these ratings, see [Age ratings](../publish/age-ratings.md).</span></span>        |
|  [<span data-ttu-id="3d868-243">MarketData</span><span class="sxs-lookup"><span data-stu-id="3d868-243">MarketData</span></span>](#marketdata-child-of-app)  |    <span data-ttu-id="3d868-244">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-244">Yes</span></span>  |  <span data-ttu-id="3d868-245">1 以上</span><span class="sxs-lookup"><span data-stu-id="3d868-245">1 or more</span></span>      |    <span data-ttu-id="3d868-246">アプリに関する特定の国/地域向けの情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-246">Contains info about the app for a given country/region.</span></span> <span data-ttu-id="3d868-247">アプリが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-247">For each country/region in which the app is listed, you must include a **MarketData** element.</span></span>       |    |

<span id="marketdata-child-of-app"/>

#### <a name="marketdata-element-child-of-app"></a><span data-ttu-id="3d868-248">MarketData 要素 (App の子要素)</span><span class="sxs-lookup"><span data-stu-id="3d868-248">MarketData element (child of App)</span></span>

<span data-ttu-id="3d868-249">この要素は、アプリに関する特定の国/地域向けの情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="3d868-249">This element provides info about the app for a given country/region.</span></span> <span data-ttu-id="3d868-250">アプリが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-250">For each country/region in which the app is listed, you must include a **MarketData** element.</span></span> <span data-ttu-id="3d868-251">**MarketData** は、[App](#app-child-of-listinginformation) 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-251">**MarketData** is a required child of the [App](#app-child-of-listinginformation) element.</span></span>

<span data-ttu-id="3d868-252">**MarketData** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-252">**MarketData** contains the following child elements.</span></span>

|  <span data-ttu-id="3d868-253">要素</span><span class="sxs-lookup"><span data-stu-id="3d868-253">Element</span></span>  |  <span data-ttu-id="3d868-254">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-254">Required</span></span>  |  <span data-ttu-id="3d868-255">数量</span><span class="sxs-lookup"><span data-stu-id="3d868-255">Quantity</span></span>  | <span data-ttu-id="3d868-256">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-256">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="3d868-257">Name</span><span class="sxs-lookup"><span data-stu-id="3d868-257">Name</span></span>**  |    <span data-ttu-id="3d868-258">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-258">Yes</span></span>   |  <span data-ttu-id="3d868-259">1</span><span class="sxs-lookup"><span data-stu-id="3d868-259">1</span></span>   |   <span data-ttu-id="3d868-260">この国/地域でのアプリの名前です。</span><span class="sxs-lookup"><span data-stu-id="3d868-260">The name of the app in this country/region.</span></span>        |
|  **<span data-ttu-id="3d868-261">Description</span><span class="sxs-lookup"><span data-stu-id="3d868-261">Description</span></span>**  |    <span data-ttu-id="3d868-262">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-262">Yes</span></span>  |  <span data-ttu-id="3d868-263">1</span><span class="sxs-lookup"><span data-stu-id="3d868-263">1</span></span>   |      <span data-ttu-id="3d868-264">この国/地域向けのアプリの説明です。</span><span class="sxs-lookup"><span data-stu-id="3d868-264">The description of the app for this country/region.</span></span>       |
|  **<span data-ttu-id="3d868-265">Price</span><span class="sxs-lookup"><span data-stu-id="3d868-265">Price</span></span>**  |    <span data-ttu-id="3d868-266">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-266">Yes</span></span>  |  <span data-ttu-id="3d868-267">1</span><span class="sxs-lookup"><span data-stu-id="3d868-267">1</span></span>   |     <span data-ttu-id="3d868-268">この国/地域でのアプリの価格です。</span><span class="sxs-lookup"><span data-stu-id="3d868-268">The price of the app in this country/region.</span></span>        |
|  **<span data-ttu-id="3d868-269">CurrencySymbol</span><span class="sxs-lookup"><span data-stu-id="3d868-269">CurrencySymbol</span></span>**  |    <span data-ttu-id="3d868-270">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-270">Yes</span></span>  |  <span data-ttu-id="3d868-271">1</span><span class="sxs-lookup"><span data-stu-id="3d868-271">1</span></span>   |     <span data-ttu-id="3d868-272">この国/地域で使われている通貨記号です。</span><span class="sxs-lookup"><span data-stu-id="3d868-272">The currency symbol used in this country/region.</span></span>        |
|  **<span data-ttu-id="3d868-273">CurrencyCode</span><span class="sxs-lookup"><span data-stu-id="3d868-273">CurrencyCode</span></span>**  |    <span data-ttu-id="3d868-274">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-274">No</span></span>  |  <span data-ttu-id="3d868-275">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-275">0 or 1</span></span>      |      <span data-ttu-id="3d868-276">この国/地域で使われている通貨コードです。</span><span class="sxs-lookup"><span data-stu-id="3d868-276">The currency code used in this country/region.</span></span>         |  |

<span data-ttu-id="3d868-277">**MarketData** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-277">**MarketData** has the following attributes.</span></span>

|  <span data-ttu-id="3d868-278">属性</span><span class="sxs-lookup"><span data-stu-id="3d868-278">Attribute</span></span>  |  <span data-ttu-id="3d868-279">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-279">Required</span></span>  |  <span data-ttu-id="3d868-280">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-280">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="3d868-281">xml:lang</span><span class="sxs-lookup"><span data-stu-id="3d868-281">xml:lang</span></span>**  |    <span data-ttu-id="3d868-282">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-282">Yes</span></span>        |     <span data-ttu-id="3d868-283">市場データ情報を適用する国/地域を指定します。</span><span class="sxs-lookup"><span data-stu-id="3d868-283">Specifies the country/region for which the market data info applies.</span></span>          |  |

<span id="product-child-of-listinginformation"/>

#### <a name="product-element-child-of-listinginformation"></a><span data-ttu-id="3d868-284">Product 要素 (ListingInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="3d868-284">Product element (child of ListingInformation)</span></span>

<span data-ttu-id="3d868-285">この要素は、アプリのアドオンを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-285">This element describes an add-on for the app.</span></span> <span data-ttu-id="3d868-286">**Product** は、[ListingInformation](#listinginformation) 要素のオプションの子要素であり、1 つ以上の [MarketData](#marketdata-child-of-product) 要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-286">**Product** is an optional child of the [ListingInformation](#listinginformation) element, and it contains one or more [MarketData](#marketdata-child-of-product) elements.</span></span>

<span data-ttu-id="3d868-287">**Product** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-287">**Product** has the following attributes.</span></span>

|  <span data-ttu-id="3d868-288">属性</span><span class="sxs-lookup"><span data-stu-id="3d868-288">Attribute</span></span>  |  <span data-ttu-id="3d868-289">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-289">Required</span></span>  |  <span data-ttu-id="3d868-290">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-290">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="3d868-291">ProductId</span><span class="sxs-lookup"><span data-stu-id="3d868-291">ProductId</span></span>**  |    <span data-ttu-id="3d868-292">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-292">Yes</span></span>        |    <span data-ttu-id="3d868-293">アプリがこのアドオンを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-293">Contains the string used by the app to identify the add-on.</span></span>           |
|  **<span data-ttu-id="3d868-294">LicenseDuration</span><span class="sxs-lookup"><span data-stu-id="3d868-294">LicenseDuration</span></span>**  |    <span data-ttu-id="3d868-295">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-295">No</span></span>        |    <span data-ttu-id="3d868-296">アイテム購入後、ライセンスが有効な日数を示します。</span><span class="sxs-lookup"><span data-stu-id="3d868-296">Indicates the number of days for which the license will be valid after the item has been purchased.</span></span> <span data-ttu-id="3d868-297">製品の購入によって作成される新しいライセンスの有効期限は、購入日にライセンス期間を加算した日付です。</span><span class="sxs-lookup"><span data-stu-id="3d868-297">The expiration date of the new license created by a product purchase is the purchase date plus the license duration.</span></span> <span data-ttu-id="3d868-298">この属性は、**ProductType** 属性が **Durable** の場合のみ使用され、コンシューマブルなアドオンの場合には無視されます。</span><span class="sxs-lookup"><span data-stu-id="3d868-298">This attribute is used only if the **ProductType** attribute is **Durable**; this attribute is ignored for consumable add-ons.</span></span>           |
|  **<span data-ttu-id="3d868-299">ProductType</span><span class="sxs-lookup"><span data-stu-id="3d868-299">ProductType</span></span>**  |    <span data-ttu-id="3d868-300">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-300">No</span></span>        |    <span data-ttu-id="3d868-301">アプリ内製品が永続的かどうかを識別する値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-301">Contains a value to identify the persistence of the in-app product.</span></span> <span data-ttu-id="3d868-302">サポートされている値は、**Durable** (既定) と **Consumable** です。</span><span class="sxs-lookup"><span data-stu-id="3d868-302">The supported values are **Durable** (the default) and **Consumable**.</span></span> <span data-ttu-id="3d868-303">永続的なアドオンについて詳しくは、[LicenseInformation](#licenseinformation) の下の [Product](#product-child-of-licenseinformation)要素をご覧ください。コンシューマブルなアドオンについて詳しくは、[ConsumableInformation](#consumableinformation) の [Product](#product-child-of-consumableinformation) 要素をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-303">For durable types, additional information is described by a [Product](#product-child-of-licenseinformation) element under [LicenseInformation](#licenseinformation); for consumable types, additional information is described by a [Product](#product-child-of-consumableinformation) element under [ConsumableInformation](#consumableinformation).</span></span>           |  |

<span id="marketdata-child-of-product"/>

#### <a name="marketdata-element-child-of-product"></a><span data-ttu-id="3d868-304">MarketData 要素 (Product の子要素)</span><span class="sxs-lookup"><span data-stu-id="3d868-304">MarketData element (child of Product)</span></span>

<span data-ttu-id="3d868-305">この要素は、アドオンに関する特定の国/地域向けの情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="3d868-305">This element provides info about the add-on for a given country/region.</span></span> <span data-ttu-id="3d868-306">アドオンが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-306">For each country/region in which the add-on is listed, you must include a **MarketData** element.</span></span> <span data-ttu-id="3d868-307">**MarketData** は、[Product](#product-child-of-listinginformation) 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-307">**MarketData** is a required child of the [Product](#product-child-of-listinginformation) element.</span></span>

<span data-ttu-id="3d868-308">**MarketData** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-308">**MarketData** contains the following child elements.</span></span>

|  <span data-ttu-id="3d868-309">要素</span><span class="sxs-lookup"><span data-stu-id="3d868-309">Element</span></span>  |  <span data-ttu-id="3d868-310">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-310">Required</span></span>  |  <span data-ttu-id="3d868-311">数量</span><span class="sxs-lookup"><span data-stu-id="3d868-311">Quantity</span></span>  | <span data-ttu-id="3d868-312">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-312">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="3d868-313">Name</span><span class="sxs-lookup"><span data-stu-id="3d868-313">Name</span></span>**  |    <span data-ttu-id="3d868-314">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-314">Yes</span></span>   |  <span data-ttu-id="3d868-315">1</span><span class="sxs-lookup"><span data-stu-id="3d868-315">1</span></span>   |   <span data-ttu-id="3d868-316">この国/地域でのアドオンの名前です。</span><span class="sxs-lookup"><span data-stu-id="3d868-316">The name of the add-on in this country/region.</span></span>        |
|  **<span data-ttu-id="3d868-317">Price</span><span class="sxs-lookup"><span data-stu-id="3d868-317">Price</span></span>**  |    <span data-ttu-id="3d868-318">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-318">Yes</span></span>  |  <span data-ttu-id="3d868-319">1</span><span class="sxs-lookup"><span data-stu-id="3d868-319">1</span></span>   |     <span data-ttu-id="3d868-320">この国/地域でのアドオンの価格です。</span><span class="sxs-lookup"><span data-stu-id="3d868-320">The price of the add-on in this country/region.</span></span>        |
|  **<span data-ttu-id="3d868-321">CurrencySymbol</span><span class="sxs-lookup"><span data-stu-id="3d868-321">CurrencySymbol</span></span>**  |    <span data-ttu-id="3d868-322">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-322">Yes</span></span>  |  <span data-ttu-id="3d868-323">1</span><span class="sxs-lookup"><span data-stu-id="3d868-323">1</span></span>   |     <span data-ttu-id="3d868-324">この国/地域で使われている通貨記号です。</span><span class="sxs-lookup"><span data-stu-id="3d868-324">The currency symbol used in this country/region.</span></span>        |
|  **<span data-ttu-id="3d868-325">CurrencyCode</span><span class="sxs-lookup"><span data-stu-id="3d868-325">CurrencyCode</span></span>**  |    <span data-ttu-id="3d868-326">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-326">No</span></span>  |  <span data-ttu-id="3d868-327">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-327">0 or 1</span></span>      |      <span data-ttu-id="3d868-328">この国/地域で使われている通貨コードです。</span><span class="sxs-lookup"><span data-stu-id="3d868-328">The currency code used in this country/region.</span></span>         |  
|  **<span data-ttu-id="3d868-329">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-329">Description</span></span>**  |    <span data-ttu-id="3d868-330">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-330">No</span></span>  |   <span data-ttu-id="3d868-331">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-331">0 or 1</span></span>   |      <span data-ttu-id="3d868-332">この国/地域向けのアドオンの説明です。</span><span class="sxs-lookup"><span data-stu-id="3d868-332">The description of the add-on for this country/region.</span></span>       |
|  **<span data-ttu-id="3d868-333">Tag</span><span class="sxs-lookup"><span data-stu-id="3d868-333">Tag</span></span>**  |    <span data-ttu-id="3d868-334">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-334">No</span></span>  |   <span data-ttu-id="3d868-335">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-335">0 or 1</span></span>   |      <span data-ttu-id="3d868-336">アドオンの[カスタム開発者データ](../publish/enter-add-on-properties.md#custom-developer-data) (タグとも呼ばれます) です。</span><span class="sxs-lookup"><span data-stu-id="3d868-336">The [custom developer data](../publish/enter-add-on-properties.md#custom-developer-data) (also called tag) for the add-on.</span></span>       |
|  **<span data-ttu-id="3d868-337">Keywords</span><span class="sxs-lookup"><span data-stu-id="3d868-337">Keywords</span></span>**  |    <span data-ttu-id="3d868-338">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-338">No</span></span>  |   <span data-ttu-id="3d868-339">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-339">0 or 1</span></span>   |      <span data-ttu-id="3d868-340">アドオンの[キーワード](../publish/enter-add-on-properties.md#keywords)が含まれた最大 10 個の **Keyword** 要素を含みます。</span><span class="sxs-lookup"><span data-stu-id="3d868-340">Contains up to 10 **Keyword** elements that contain the [keywords](../publish/enter-add-on-properties.md#keywords) for the add-on.</span></span>       |
|  **<span data-ttu-id="3d868-341">ImageUri</span><span class="sxs-lookup"><span data-stu-id="3d868-341">ImageUri</span></span>**  |    <span data-ttu-id="3d868-342">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-342">No</span></span>  |   <span data-ttu-id="3d868-343">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-343">0 or 1</span></span>   |      <span data-ttu-id="3d868-344">アドオンの登録情報に表示する[画像の URI](../publish/create-add-on-store-listings.md#icon) です。</span><span class="sxs-lookup"><span data-stu-id="3d868-344">The [URI for the image](../publish/create-add-on-store-listings.md#icon) in the add-on's listing.</span></span>           |  |

<span data-ttu-id="3d868-345">**MarketData** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-345">**MarketData** has the following attributes.</span></span>

|  <span data-ttu-id="3d868-346">属性</span><span class="sxs-lookup"><span data-stu-id="3d868-346">Attribute</span></span>  |  <span data-ttu-id="3d868-347">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-347">Required</span></span>  |  <span data-ttu-id="3d868-348">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-348">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="3d868-349">xml:lang</span><span class="sxs-lookup"><span data-stu-id="3d868-349">xml:lang</span></span>**  |    <span data-ttu-id="3d868-350">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-350">Yes</span></span>        |     <span data-ttu-id="3d868-351">市場データ情報を適用する国/地域を指定します。</span><span class="sxs-lookup"><span data-stu-id="3d868-351">Specifies the country/region for which the market data info applies.</span></span>          |  |

<span id="licenseinformation"/>

#### <a name="licenseinformation-element"></a><span data-ttu-id="3d868-352">LicenseInformation 要素</span><span class="sxs-lookup"><span data-stu-id="3d868-352">LicenseInformation element</span></span>

<span data-ttu-id="3d868-353">この要素は、このアプリで利用可能なライセンスと永続的なアプリ内製品を記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-353">This element describes the licenses available for this app and its durable in-app products.</span></span> <span data-ttu-id="3d868-354">**LicenseInformation** は、**CurrentApp** 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-354">**LicenseInformation** is a required child of the **CurrentApp** element.</span></span>

<span data-ttu-id="3d868-355">**LicenseInformation** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-355">**LicenseInformation** contains the following child elements.</span></span>

|  <span data-ttu-id="3d868-356">要素</span><span class="sxs-lookup"><span data-stu-id="3d868-356">Element</span></span>  |  <span data-ttu-id="3d868-357">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-357">Required</span></span>  |  <span data-ttu-id="3d868-358">数量</span><span class="sxs-lookup"><span data-stu-id="3d868-358">Quantity</span></span>  | <span data-ttu-id="3d868-359">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-359">Description</span></span>   |
|-------------|------------|--------|--------|
|  [<span data-ttu-id="3d868-360">App</span><span class="sxs-lookup"><span data-stu-id="3d868-360">App</span></span>](#app-child-of-licenseinformation)  |    <span data-ttu-id="3d868-361">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-361">Yes</span></span>   |  <span data-ttu-id="3d868-362">1</span><span class="sxs-lookup"><span data-stu-id="3d868-362">1</span></span>   |    <span data-ttu-id="3d868-363">アプリのライセンスを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-363">Describes the app's license.</span></span>         |
|  [<span data-ttu-id="3d868-364">Product</span><span class="sxs-lookup"><span data-stu-id="3d868-364">Product</span></span>](#product-child-of-licenseinformation)  |    <span data-ttu-id="3d868-365">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-365">No</span></span>  |  <span data-ttu-id="3d868-366">0 以上</span><span class="sxs-lookup"><span data-stu-id="3d868-366">0 or more</span></span>   |      <span data-ttu-id="3d868-367">アプリ内の永続的なアドオンのライセンスの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-367">Describes the license status of a durable add-on in the app.</span></span>         |   |

<span data-ttu-id="3d868-368">次の表では、**App** 要素と **Product** 要素の下で値を組み合わせて、いくつかの一般的な条件をシミュレートする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3d868-368">The following table shows how to simulate some common conditions by combining values under the **App** and **Product** elements.</span></span>

|  <span data-ttu-id="3d868-369">シミュレートする条件</span><span class="sxs-lookup"><span data-stu-id="3d868-369">Condition to simulate</span></span>  |  <span data-ttu-id="3d868-370">IsActive</span><span class="sxs-lookup"><span data-stu-id="3d868-370">IsActive</span></span>  |  <span data-ttu-id="3d868-371">IsTrial</span><span class="sxs-lookup"><span data-stu-id="3d868-371">IsTrial</span></span>  | <span data-ttu-id="3d868-372">ExpirationDate</span><span class="sxs-lookup"><span data-stu-id="3d868-372">ExpirationDate</span></span>   |
|-------------|------------|--------|--------|
|  <span data-ttu-id="3d868-373">完全なライセンスを保有</span><span class="sxs-lookup"><span data-stu-id="3d868-373">Fully licensed</span></span>  |    <span data-ttu-id="3d868-374">true</span><span class="sxs-lookup"><span data-stu-id="3d868-374">true</span></span>   |  <span data-ttu-id="3d868-375">false</span><span class="sxs-lookup"><span data-stu-id="3d868-375">false</span></span>  |    <span data-ttu-id="3d868-376">指定しません。</span><span class="sxs-lookup"><span data-stu-id="3d868-376">Absent.</span></span> <span data-ttu-id="3d868-377">実際には有効期限が存在し、将来の日付を指定する場合でも、その要素は XML ファイルから省略することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3d868-377">It actually may be present and specify a future date, but you're advised to omit the element from the XML file.</span></span> <span data-ttu-id="3d868-378">有効期限が存在し、過去の日付が指定されている場合、**IsActive** は無視され、false として扱われます。</span><span class="sxs-lookup"><span data-stu-id="3d868-378">If it is present and specifies a date in the past, then **IsActive** will be ignored and taken to be false.</span></span>          |
|  <span data-ttu-id="3d868-379">試用期間中</span><span class="sxs-lookup"><span data-stu-id="3d868-379">In trial period</span></span>  |    <span data-ttu-id="3d868-380">true</span><span class="sxs-lookup"><span data-stu-id="3d868-380">true</span></span>  |  <span data-ttu-id="3d868-381">true</span><span class="sxs-lookup"><span data-stu-id="3d868-381">true</span></span>   |      <span data-ttu-id="3d868-382">&lt;将来の日付と時刻&gt; **IsTrial** が true であるため、この要素を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-382">&lt;a datetime in the future&gt; This element must be present because **IsTrial** is true.</span></span> <span data-ttu-id="3d868-383">残りの試用期間に対応する有効期限は、現在の協定世界時 (UTC) を表示する Web サイトにアクセスして確認できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-383">You can visit a website showing the current Coordinated Universal Time (UTC) to know how far in the future to set this to get the remaining trial period you want.</span></span>         |
|  <span data-ttu-id="3d868-384">有効期限が切れた試用版</span><span class="sxs-lookup"><span data-stu-id="3d868-384">Expired trial</span></span>  |    <span data-ttu-id="3d868-385">false</span><span class="sxs-lookup"><span data-stu-id="3d868-385">false</span></span>  |  <span data-ttu-id="3d868-386">true</span><span class="sxs-lookup"><span data-stu-id="3d868-386">true</span></span>   |      <span data-ttu-id="3d868-387">&lt;過去の日付と時刻&gt; **IsTrial** が true であるため、この要素を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-387">&lt;a datetime in the past&gt; This element must be present because **IsTrial** is true.</span></span> <span data-ttu-id="3d868-388">UTC で表した "過去の" 有効期限は、現在の協定世界時 (UTC) を表示する Web サイトにアクセスして確認できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-388">You can visit a website showing the current Coordinated Universal Time (UTC) to know when "the past" is in UTC.</span></span>         |
|  <span data-ttu-id="3d868-389">ライセンスが無効</span><span class="sxs-lookup"><span data-stu-id="3d868-389">Invalid</span></span>  |    <span data-ttu-id="3d868-390">false</span><span class="sxs-lookup"><span data-stu-id="3d868-390">false</span></span>  | <span data-ttu-id="3d868-391">false</span><span class="sxs-lookup"><span data-stu-id="3d868-391">false</span></span>       |     <span data-ttu-id="3d868-392">&lt;任意の値または省略&gt;</span><span class="sxs-lookup"><span data-stu-id="3d868-392">&lt;any value or omitted&gt;</span></span>          |  |

<span id="app-child-of-licenseinformation"/>

#### <a name="app-element-child-of-licenseinformation"></a><span data-ttu-id="3d868-393">App 要素 (LicenseInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="3d868-393">App element (child of LicenseInformation)</span></span>

<span data-ttu-id="3d868-394">この要素は、アプリのライセンスを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-394">This element describes the app's license.</span></span> <span data-ttu-id="3d868-395">**App** は、[LicenseInformation](#licenseinformation) 要素の必須の子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-395">**App** is a required child of the [LicenseInformation](#licenseinformation) element.</span></span>

<span data-ttu-id="3d868-396">**App** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-396">**App** contains the following child elements.</span></span>

|  <span data-ttu-id="3d868-397">要素</span><span class="sxs-lookup"><span data-stu-id="3d868-397">Element</span></span>  |  <span data-ttu-id="3d868-398">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-398">Required</span></span>  |  <span data-ttu-id="3d868-399">数量</span><span class="sxs-lookup"><span data-stu-id="3d868-399">Quantity</span></span>  | <span data-ttu-id="3d868-400">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-400">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="3d868-401">IsActive</span><span class="sxs-lookup"><span data-stu-id="3d868-401">IsActive</span></span>**  |    <span data-ttu-id="3d868-402">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-402">Yes</span></span>   |  <span data-ttu-id="3d868-403">1</span><span class="sxs-lookup"><span data-stu-id="3d868-403">1</span></span>   |    <span data-ttu-id="3d868-404">このアプリの現在のライセンスの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-404">Describes the current license state of this app.</span></span> <span data-ttu-id="3d868-405">値 **true** はライセンスが有効であることを示し、**false** はライセンスが無効であることを示します。</span><span class="sxs-lookup"><span data-stu-id="3d868-405">The value **true** indicates the license is valid; **false** indicates an invalid license.</span></span> <span data-ttu-id="3d868-406">この値はアプリが使用モードであるかどうかに関係なく、通常、**true** です。</span><span class="sxs-lookup"><span data-stu-id="3d868-406">Normally this value is **true**, whether the app has a trial mode or not.</span></span>  <span data-ttu-id="3d868-407">ライセンスが無効な場合にアプリがどのように動作するかをテストするには、この値を **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="3d868-407">Set this value to **false** to test how your app behaves when it has an invalid license.</span></span>           |
|  **<span data-ttu-id="3d868-408">IsTrial</span><span class="sxs-lookup"><span data-stu-id="3d868-408">IsTrial</span></span>**  |    <span data-ttu-id="3d868-409">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-409">Yes</span></span>  |  <span data-ttu-id="3d868-410">1</span><span class="sxs-lookup"><span data-stu-id="3d868-410">1</span></span>   |      <span data-ttu-id="3d868-411">このアプリが現在、試用期間中かどうかの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-411">Describes the current trial state of this app.</span></span> <span data-ttu-id="3d868-412">値 **true** はアプリが試用期間中であることを示します。**false** は、アプリが購入済みであるか、試用期限が切れたために、アプリが試用期間中でないことを示します。</span><span class="sxs-lookup"><span data-stu-id="3d868-412">The value **true** indicates the app is being used during the trial period; **false** indicates the app is not in a trial, either because the app has been purchased or the trial period has expired.</span></span>         |
|  **<span data-ttu-id="3d868-413">ExpirationDate</span><span class="sxs-lookup"><span data-stu-id="3d868-413">ExpirationDate</span></span>**  |    <span data-ttu-id="3d868-414">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-414">No</span></span>  |  <span data-ttu-id="3d868-415">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-415">0 or 1</span></span>       |     <span data-ttu-id="3d868-416">このアプリの試用期間が期限切れとなる日付 (協定世界時 (UTC)) です。</span><span class="sxs-lookup"><span data-stu-id="3d868-416">The date the trial period for this app expires, in Coordinated Universal Time (UTC).</span></span> <span data-ttu-id="3d868-417">日付は、yyyy-mm-ddThh:mm:ss.ssZ の形式で表す必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-417">The date must be expressed as: yyyy-mm-ddThh:mm:ss.ssZ.</span></span> <span data-ttu-id="3d868-418">たとえば、2015 年 1 月 19 日午前 5 時は、2015-01-19T05:00:00.00Z と表します。</span><span class="sxs-lookup"><span data-stu-id="3d868-418">For example, 05:00 on January 19, 2015 would be specified as 2015-01-19T05:00:00.00Z.</span></span> <span data-ttu-id="3d868-419">この要素は、**IsTrial** が **true** の場合に必須です。</span><span class="sxs-lookup"><span data-stu-id="3d868-419">This element is required when **IsTrial** is **true**.</span></span> <span data-ttu-id="3d868-420">そうでない場合は、必須ではありません。</span><span class="sxs-lookup"><span data-stu-id="3d868-420">Otherwise, it is not required.</span></span>          |  |

<span id="product-child-of-licenseinformation"/>

#### <a name="product-element-child-of-licenseinformation"></a><span data-ttu-id="3d868-421">Product 要素 (LicenseInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="3d868-421">Product element (child of LicenseInformation)</span></span>

<span data-ttu-id="3d868-422">この要素は、アプリ内の永続的なアドオンのライセンスの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-422">This element describes the license status of a durable add-on in the app.</span></span> <span data-ttu-id="3d868-423">**Product** は、[LicenseInformation](#licenseinformation) 要素のオプションの子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-423">**Product** is an optional child of the [LicenseInformation](#licenseinformation) element.</span></span>

<span data-ttu-id="3d868-424">**Product** には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-424">**Product** contains the following child elements.</span></span>

|  <span data-ttu-id="3d868-425">要素</span><span class="sxs-lookup"><span data-stu-id="3d868-425">Element</span></span>  |  <span data-ttu-id="3d868-426">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-426">Required</span></span>  |  <span data-ttu-id="3d868-427">数量</span><span class="sxs-lookup"><span data-stu-id="3d868-427">Quantity</span></span>  | <span data-ttu-id="3d868-428">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-428">Description</span></span>   |
|-------------|------------|--------|--------|
|  **<span data-ttu-id="3d868-429">IsActive</span><span class="sxs-lookup"><span data-stu-id="3d868-429">IsActive</span></span>**  |    <span data-ttu-id="3d868-430">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-430">Yes</span></span>   |  <span data-ttu-id="3d868-431">1</span><span class="sxs-lookup"><span data-stu-id="3d868-431">1</span></span>     |    <span data-ttu-id="3d868-432">このアドオンの現在のライセンスの状態を記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-432">Describes the current license state of this add-on.</span></span> <span data-ttu-id="3d868-433">値 **true** はアドオンを追加できることを示し、**false** はアドオンを使用できないか、購入していないことを示します。</span><span class="sxs-lookup"><span data-stu-id="3d868-433">The value **true** indicates the add-on can be used; **false** indicates the add-on cannot be used or has not been purchased</span></span>           |
|  **<span data-ttu-id="3d868-434">ExpirationDate</span><span class="sxs-lookup"><span data-stu-id="3d868-434">ExpirationDate</span></span>**  |    <span data-ttu-id="3d868-435">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-435">No</span></span>   |  <span data-ttu-id="3d868-436">0 または 1</span><span class="sxs-lookup"><span data-stu-id="3d868-436">0 or 1</span></span>     |     <span data-ttu-id="3d868-437">協定世界時 (UTC) で表したアドオンの有効期限日です。</span><span class="sxs-lookup"><span data-stu-id="3d868-437">The date the add-on expires, in Coordinated Universal Time (UTC).</span></span> <span data-ttu-id="3d868-438">日付は、yyyy-mm-ddThh:mm:ss.ssZ の形式で表す必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-438">The date must be expressed as: yyyy-mm-ddThh:mm:ss.ssZ.</span></span> <span data-ttu-id="3d868-439">たとえば、2015 年 1 月 19 日午前 5 時は、2015-01-19T05:00:00.00Z と表します。</span><span class="sxs-lookup"><span data-stu-id="3d868-439">For example, 05:00 on January 19, 2015 would be specified as 2015-01-19T05:00:00.00Z.</span></span> <span data-ttu-id="3d868-440">この要素が存在する場合、アドオンには有効期限日があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-440">If this element is present, the add-on has an expiration date.</span></span> <span data-ttu-id="3d868-441">存在しない場合、アドオンに有効期限はありません。</span><span class="sxs-lookup"><span data-stu-id="3d868-441">If it's not present, the add-on does not expire.</span></span>  |  

<span data-ttu-id="3d868-442">**Product** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-442">**Product** has the following attributes.</span></span>

|  <span data-ttu-id="3d868-443">属性</span><span class="sxs-lookup"><span data-stu-id="3d868-443">Attribute</span></span>  |  <span data-ttu-id="3d868-444">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-444">Required</span></span>  |  <span data-ttu-id="3d868-445">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-445">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="3d868-446">ProductId</span><span class="sxs-lookup"><span data-stu-id="3d868-446">ProductId</span></span>**  |    <span data-ttu-id="3d868-447">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-447">Yes</span></span>        |   <span data-ttu-id="3d868-448">アプリがこのアドオンを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-448">Contains the string used by the app to identify the add-on.</span></span>            |
|  **<span data-ttu-id="3d868-449">OfferId</span><span class="sxs-lookup"><span data-stu-id="3d868-449">OfferId</span></span>**  |     <span data-ttu-id="3d868-450">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-450">No</span></span>       |   <span data-ttu-id="3d868-451">アプリが、このアドオンが属するカテゴリを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-451">Contains the string used by the app to identify the category in which the add-on belongs.</span></span> <span data-ttu-id="3d868-452">これを使うことで、「[アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)」で説明されている大規模なアイテムのカタログに対応できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-452">This provides support for large item catalogs, as described in [Manage a large catalog of in-app products](manage-a-large-catalog-of-in-app-products.md).</span></span>           |

<span id="simulation"/>

#### <a name="simulation-element"></a><span data-ttu-id="3d868-453">Simulation 要素</span><span class="sxs-lookup"><span data-stu-id="3d868-453">Simulation element</span></span>

<span data-ttu-id="3d868-454">この要素は、テストにおいて、さまざまな [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) メソッドへの呼び出しがどのように動作するかを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-454">This element describes how calls to various [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) methods will work in the app during testing.</span></span> <span data-ttu-id="3d868-455">**Simulation** は **CurrentApp** 要素のオプションの子要素であり、0 個以上の [DefaultResponse](#defaultresponse) 要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-455">**Simulation** is an optional child of the **CurrentApp** element, and it contains zero or more [DefaultResponse](#defaultresponse) elements.</span></span>

<span data-ttu-id="3d868-456">**Simulation** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-456">**Simulation** has the following attributes.</span></span>

|  <span data-ttu-id="3d868-457">属性</span><span class="sxs-lookup"><span data-stu-id="3d868-457">Attribute</span></span>  |  <span data-ttu-id="3d868-458">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-458">Required</span></span>  |  <span data-ttu-id="3d868-459">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-459">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="3d868-460">SimulationMode</span><span class="sxs-lookup"><span data-stu-id="3d868-460">SimulationMode</span></span>**  |    <span data-ttu-id="3d868-461">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-461">No</span></span>        |      <span data-ttu-id="3d868-462">値は **Interactive** か **Automatic** のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="3d868-462">Values can be **Interactive** or **Automatic**.</span></span> <span data-ttu-id="3d868-463">この属性を **Automatic** に設定すると、指定した HRESULT エラー コードがメソッドによって自動的に返されます。</span><span class="sxs-lookup"><span data-stu-id="3d868-463">When this attribute is set to **Automatic**, the methods will automatically return the specified HRESULT error codes.</span></span> <span data-ttu-id="3d868-464">これは自動化されたテスト ケースを実行する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-464">This can be used when running automated test cases.</span></span>       |

<span id="defaultresponse"/>

#### <a name="defaultresponse-element"></a><span data-ttu-id="3d868-465">DefaultResponse 要素</span><span class="sxs-lookup"><span data-stu-id="3d868-465">DefaultResponse element</span></span>

<span data-ttu-id="3d868-466">この要素は、**CurrentAppSimulator** メソッドによって返される既定のエラー コードを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-466">This element describes the default error code returned by a **CurrentAppSimulator** method.</span></span> <span data-ttu-id="3d868-467">**DefaultResponse** は、[Simulation](#simulation) 要素のオプションの子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-467">**DefaultResponse** is an optional child of the [Simulation](#simulation) element.</span></span>

<span data-ttu-id="3d868-468">**DefaultResponse** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-468">**DefaultResponse** has the following attributes.</span></span>

|  <span data-ttu-id="3d868-469">属性</span><span class="sxs-lookup"><span data-stu-id="3d868-469">Attribute</span></span>  |  <span data-ttu-id="3d868-470">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-470">Required</span></span>  |  <span data-ttu-id="3d868-471">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-471">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="3d868-472">MethodName</span><span class="sxs-lookup"><span data-stu-id="3d868-472">MethodName</span></span>**  |    <span data-ttu-id="3d868-473">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-473">Yes</span></span>        |   <span data-ttu-id="3d868-474">この属性は、[スキーマ](#schema) の **StoreMethodName** 型で表示される列挙値のいずれかに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="3d868-474">Assign this attribute to one of the enum values shown for the **StoreMethodName** type in the [schema](#schema).</span></span> <span data-ttu-id="3d868-475">これらの各列挙値は、テストのときにアプリでエラー コードの戻り値をシミュレートする **CurrentAppSimulator** メソッドを表します。</span><span class="sxs-lookup"><span data-stu-id="3d868-475">Each of these enum values represents a **CurrentAppSimulator** method for which you want to simulate an error code return value in your app during testing.</span></span> <span data-ttu-id="3d868-476">たとえば、値 **RequestAppPurchaseAsync_GetResult** は、[RequestAppPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.requestapppurchaseasync) メソッドのエラー コードの戻り値をシミュレートすることを示します。</span><span class="sxs-lookup"><span data-stu-id="3d868-476">For example, the value **RequestAppPurchaseAsync_GetResult** indicates you want to simulate the error code return value of the [RequestAppPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.requestapppurchaseasync) method.</span></span>            |
|  **<span data-ttu-id="3d868-477">HResult</span><span class="sxs-lookup"><span data-stu-id="3d868-477">HResult</span></span>**  |     <span data-ttu-id="3d868-478">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-478">Yes</span></span>       |   <span data-ttu-id="3d868-479">この属性は、[スキーマ](#schema) の **ResponseCodes** 型で表示される列挙値のいずれかに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="3d868-479">Assign this attribute to one of the enum values shown for the **ResponseCodes** type in the [schema](#schema).</span></span> <span data-ttu-id="3d868-480">これらの各列挙値は、この **DefaultResponse** 要素の **MethodName** 属性に割り当てるメソッドに対して返すエラーコードを表します。</span><span class="sxs-lookup"><span data-stu-id="3d868-480">Each of these enum values represents the error code you want to return for the method that is assigned to the **MethodName** attribute for this **DefaultResponse** element.</span></span>           |

<span id="consumableinformation"/>

#### <a name="consumableinformation-element"></a><span data-ttu-id="3d868-481">ConsumableInformation 要素</span><span class="sxs-lookup"><span data-stu-id="3d868-481">ConsumableInformation element</span></span>

<span data-ttu-id="3d868-482">この要素は、このアプリで利用可能なコンシューマブルなアドオンを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-482">This element describes the consumable add-ons available for this app.</span></span> <span data-ttu-id="3d868-483">**ConsumableInformation** は、**CurrentApp** 要素のオプションの子要素であり、0 個以上の [Product](#product-child-of-consumableinformation) 要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3d868-483">**ConsumableInformation** is an optional child of the **CurrentApp** element, and it can contain zero or more [Product](#product-child-of-consumableinformation) elements.</span></span>

<span id="product-child-of-consumableinformation"/>

#### <a name="product-element-child-of-consumableinformation"></a><span data-ttu-id="3d868-484">Product 要素 (ConsumableInformation の子要素)</span><span class="sxs-lookup"><span data-stu-id="3d868-484">Product element (child of ConsumableInformation)</span></span>

<span data-ttu-id="3d868-485">この要素は、コンシューマブルなアドオンを記述します。</span><span class="sxs-lookup"><span data-stu-id="3d868-485">This element describes a consumable add-on.</span></span> <span data-ttu-id="3d868-486">**Product** は、[ConsumableInformation](#consumableinformation) 要素のオプションの子要素です。</span><span class="sxs-lookup"><span data-stu-id="3d868-486">**Product** is an optional child of the [ConsumableInformation](#consumableinformation) element.</span></span>

<span data-ttu-id="3d868-487">**Product** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="3d868-487">**Product** has the following attributes.</span></span>

|  <span data-ttu-id="3d868-488">属性</span><span class="sxs-lookup"><span data-stu-id="3d868-488">Attribute</span></span>  |  <span data-ttu-id="3d868-489">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3d868-489">Required</span></span>  |  <span data-ttu-id="3d868-490">説明</span><span class="sxs-lookup"><span data-stu-id="3d868-490">Description</span></span>   |
|-------------|------------|----------------|
|  **<span data-ttu-id="3d868-491">ProductId</span><span class="sxs-lookup"><span data-stu-id="3d868-491">ProductId</span></span>**  |    <span data-ttu-id="3d868-492">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-492">Yes</span></span>        |   <span data-ttu-id="3d868-493">アプリがこのコンシューマブルなアドオンを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-493">Contains the string used by the app to identify the consumable add-on.</span></span>            |
|  **<span data-ttu-id="3d868-494">TransactionId</span><span class="sxs-lookup"><span data-stu-id="3d868-494">TransactionId</span></span>**  |     <span data-ttu-id="3d868-495">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-495">Yes</span></span>       |   <span data-ttu-id="3d868-496">アプリが、フルフィルメントのプロセス全体を通じ、コンシューマブルの購入トランザクションを追跡するために使用する GUID (文字列) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-496">Contains a GUID (as a string) used by the app to track the purchase transaction of a consumable through the process of fulfillment.</span></span> <span data-ttu-id="3d868-497">詳しくは、「[コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d868-497">See [Enable consumable in-app product purchases](enable-consumable-in-app-product-purchases.md).</span></span>            |
|  **<span data-ttu-id="3d868-498">Status</span><span class="sxs-lookup"><span data-stu-id="3d868-498">Status</span></span>**  |      <span data-ttu-id="3d868-499">必須</span><span class="sxs-lookup"><span data-stu-id="3d868-499">Yes</span></span>      |  <span data-ttu-id="3d868-500">アプリが、コンシューマブルのフルフィルメントの状態を示すために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-500">Contains the string used by the app to indicate the fulfillment status of a consumable.</span></span> <span data-ttu-id="3d868-501">値は、**Active**、**PurchaseReverted**、**PurchasePending**、または **ServerError** です。</span><span class="sxs-lookup"><span data-stu-id="3d868-501">Values can be **Active**, **PurchaseReverted**, **PurchasePending**, or **ServerError**.</span></span>             |
|  **<span data-ttu-id="3d868-502">OfferId</span><span class="sxs-lookup"><span data-stu-id="3d868-502">OfferId</span></span>**  |     <span data-ttu-id="3d868-503">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3d868-503">No</span></span>       |    <span data-ttu-id="3d868-504">アプリが、このコンシューマブルが属するカテゴリを特定するために使う文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3d868-504">Contains the string used by the app to identify the category in which the consumable belongs.</span></span> <span data-ttu-id="3d868-505">これを使うことで、「[アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)」で説明されている大規模なアイテムのカタログに対応できます。</span><span class="sxs-lookup"><span data-stu-id="3d868-505">This provides support for large item catalogs, as described in [Manage a large catalog of in-app products](manage-a-large-catalog-of-in-app-products.md).</span></span>           |
