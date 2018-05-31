---
author: mcleanbyron
ms.assetid: adb2fa45-e18f-4254-bd8b-a749a386e3b4
description: Windows 10 (UWP) 用の JavaScript/HTML アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。
title: HTML 5 および JavaScript の AdControl
ms.author: mcleans
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, Advertising, AdControl, 広告コントロール, JavaScript, HTML
ms.localizationpriority: medium
ms.openlocfilehash: 84c6b924072c9a55bf0610883252b511f612dff1
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1690138"
---
# <a name="adcontrol-in-html-5-and-javascript"></a><span data-ttu-id="ff643-104">HTML 5 および JavaScript の AdControl</span><span class="sxs-lookup"><span data-stu-id="ff643-104">AdControl in HTML 5 and JavaScript</span></span>

<span data-ttu-id="ff643-105">このチュートリアルでは、Windows 10 (HTML) 用のユニバーサル Windows プラットフォーム (UWP) JavaScript/HTML アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスを使ってバナー広告を表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ff643-105">This walkthrough shows how to use the [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) class to display banner ads in a Universal Windows Platform (UWP) JavaScript/HTML app for Windows 10.</span></span>

<span data-ttu-id="ff643-106">JavaScript/HTML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ff643-106">For a complete sample project that demonstrates how to add banner ads to a JavaScript/HTML app, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="ff643-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="ff643-107">Prerequisites</span></span>

* <span data-ttu-id="ff643-108">Visual Studio 2015 以降の Visual Studio のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="ff643-108">Install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release of Visual Studio.</span></span> <span data-ttu-id="ff643-109">インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ff643-109">For installation instructions, see [this article](install-the-microsoft-advertising-libraries.md).</span></span>

> [!NOTE]
> <span data-ttu-id="ff643-110">Windows 10 SDK バージョン 10.0.14393 (Anniversary Update) または Windows SDK のそれ以降のバージョンをインストールしている場合、WinJS ライブラリもインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ff643-110">If you have installed the Windows 10 SDK version 10.0.14393 (Anniversary Update) or a later version of the Windows SDK, you must also install the WinJS library.</span></span> <span data-ttu-id="ff643-111">このライブラリは以前のバージョンの Windows SDK for Windows 10 に含まれていましたが、Windows 10 SDK バージョン 10.0.14393 (Anniversary Update) 以降ではこのライブラリを別個にインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ff643-111">This library used to be included in previous versions of the Windows SDK for Windows 10, but starting with the Windows 10 SDK version 10.0.14393 (Anniversary Update) this library must be installed separately.</span></span> <span data-ttu-id="ff643-112">WinJS をインストールする場合は、「[Get WinJS (WinJS を入手する)](http://try.buildwinjs.com/download/GetWinJS/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ff643-112">To install WinJS, see [Get WinJS](http://try.buildwinjs.com/download/GetWinJS/).</span></span>

## <a name="integrate-a-banner-ad-into-your-app"></a><span data-ttu-id="ff643-113">バナー広告をアプリに統合する</span><span class="sxs-lookup"><span data-stu-id="ff643-113">Integrate a banner ad into your app</span></span>

1. <span data-ttu-id="ff643-114">Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="ff643-114">In Visual Studio, open your project or create a new project.</span></span>

    > [!NOTE]
    > <span data-ttu-id="ff643-115">既存のプロジェクトを使用している場合、プロジェクトの Package.appxmanifest ファイルを開き、**インターネット (クライアント)** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ff643-115">If you're using an existing project, open the Package.appxmanifest file in your project and ensure that the **Internet (Client)** capability is selected.</span></span> <span data-ttu-id="ff643-116">アプリでは、テスト広告やライブ広告を受信するためにこの機能が必要になります。</span><span class="sxs-lookup"><span data-stu-id="ff643-116">Your app needs this capability to receive test ads and live ads.</span></span>

2. <span data-ttu-id="ff643-117">プロジェクトのターゲットが **[任意の CPU]** になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="ff643-117">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="ff643-118">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="ff643-118">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps.</span></span> <span data-ttu-id="ff643-119">詳しくは、「[プロジェクトのターゲットを "任意の CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ff643-119">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

3. <span data-ttu-id="ff643-120">プロジェクトで Microsoft Advertising SDK への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="ff643-120">Add a reference to the Microsoft Advertising SDK in your project:</span></span>

    1. <span data-ttu-id="ff643-121">**[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ff643-121">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>
    2.  <span data-ttu-id="ff643-122">**[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for JavaScript]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="ff643-122">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for JavaScript** (Version 10.0).</span></span>
    3.  <span data-ttu-id="ff643-123">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ff643-123">In **Reference Manager**, click OK.</span></span>

6.  <span data-ttu-id="ff643-124">index.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。</span><span class="sxs-lookup"><span data-stu-id="ff643-124">Open the index.html file (or other html file as appropriate for your project).</span></span>

7.  <span data-ttu-id="ff643-125">**&lt;head&gt;** セクションで、プロジェクトの default.css と main.js の JavaScript 参照の後に ad.js への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="ff643-125">In the **&lt;head&gt;** section, after the project’s JavaScript references of default.css and main.js, add the reference to ad.js.</span></span>

    ``` HTML
    <!-- Advertising required references -->
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    ```

    > [!NOTE]
    > <span data-ttu-id="ff643-126">この行は、**&lt;head&gt;** セクションの main.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="ff643-126">This line must be placed in the **&lt;head&gt;** section after the include of main.js; otherwise, you will encounter an error when you build your project.</span></span>

8.  <span data-ttu-id="ff643-127">default.html ファイル (またはプロジェクトに対応するその他の html ファイル) の **&lt;body&gt;** セクションを変更して、**AdControl** の **div** を追加します。</span><span class="sxs-lookup"><span data-stu-id="ff643-127">Modify the **&lt;body&gt;** section in the default.html file (or other html file as appropriate for your project) to include the **div** for the **AdControl**.</span></span> <span data-ttu-id="ff643-128">**AdControl** の **applicationId** プロパティと **adUnitId** プロパティに、[広告ユニットのテスト値](set-up-ad-units-in-your-app.md#test-ad-units)を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="ff643-128">Assign the **applicationId** and **adUnitId** properties of the **AdControl** to the [test ad unit values](set-up-ad-units-in-your-app.md#test-ad-units).</span></span> <span data-ttu-id="ff643-129">また、コントロールの**高さ**と**幅**を、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。</span><span class="sxs-lookup"><span data-stu-id="ff643-129">Also adjust the **height** and **width** so the control is one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!NOTE]
    > <span data-ttu-id="ff643-130">各 **AdControl** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="ff643-130">Every **AdControl** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="ff643-131">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="ff643-131">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="ff643-132">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="ff643-132">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="ff643-133">ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="ff643-133">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

    ``` HTML
    <div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
        data-win-control="MicrosoftNSJS.Advertising.AdControl"
        data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test'}">
    </div>
    ```

9.  <span data-ttu-id="ff643-134">アプリをコンパイルして実行し、広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ff643-134">Compile and run the app to see it with an ad.</span></span>

<span data-ttu-id="ff643-135">次の例は、シンプルなアプリの index.html 全体を示しています。</span><span class="sxs-lookup"><span data-stu-id="ff643-135">The following example shows the complete index.html for a simple app.</span></span>

``` HTML
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>AdControlExampleApp</title>
    <!-- WinJS references -->
    <link href="lib/winjs-4.0.1/css/ui-light.css" rel="stylesheet" />
    <script src="lib/winjs-4.0.1/js/base.js"></script>
    <script src="lib/winjs-4.0.1/js/ui.js"></script>
    <!-- AdControlExampleApp references -->
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/main.js"></script>
    <!-- Required reference for AdControl -->
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
</head>
<body>
    <div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test'}">
    </div>
    <p>Content goes here</p>
</body>
</html>
```

### <a name="create-an-adcontrol-programmatically-in-javascript"></a><span data-ttu-id="ff643-136">JavaScript でのプログラムによる AdControl の作成</span><span class="sxs-lookup"><span data-stu-id="ff643-136">Create an AdControl programmatically in Javascript</span></span>

<span data-ttu-id="ff643-137">前の手順では、HTML マークアップで **AdControl** を宣言する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ff643-137">The previous steps show how to declare an **AdControl** in your HTML markup.</span></span> <span data-ttu-id="ff643-138">代わりに、JavaScript を使ってプログラムで **AdControl** を作成できます。</span><span class="sxs-lookup"><span data-stu-id="ff643-138">Alternatively, you can programmatically create an **AdControl** using JavaScript.</span></span> <span data-ttu-id="ff643-139">次の例では、HTML に **div** が存在し、その ID が **myAd** に設定されていると想定しています。</span><span class="sxs-lookup"><span data-stu-id="ff643-139">This example assumes that you are using an existing **div** in your HTML with the ID **myAd**.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-javascript[AdControl](./code/AdvertisingSamples/AdControlSamples/js/main.js#DeclareAdControl)]

<span data-ttu-id="ff643-140">この例では、**myAdError**、**myAdRefreshed**、**myAdEngagedChanged** という名前のイベント ハンドラー メソッドが既に宣言されていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="ff643-140">This example assumes that you have already declared event handler methods named **myAdError**, **myAdRefreshed**, and **myAdEngagedChanged**.</span></span>

<span data-ttu-id="ff643-141">このコードで広告が表示されない場合は、**AdControl** を含む **div** に **position:relative** の属性を挿入してみてください。</span><span class="sxs-lookup"><span data-stu-id="ff643-141">If you use this code and do not see ads, you can try inserting an attribute of **position:relative** in the **div** that contains the **AdControl**.</span></span> <span data-ttu-id="ff643-142">これにより、**IFrame** の既定の設定が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="ff643-142">This will override the default setting of the **IFrame**.</span></span> <span data-ttu-id="ff643-143">この属性の値が原因でなければ、広告が正しく表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="ff643-143">Ads will be displayed correctly, unless they are not being shown due to the value of this attribute.</span></span> <span data-ttu-id="ff643-144">新しい広告ユニットが利用可能になるまでに最大で 30 分かかる場合があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ff643-144">Note that new ad units may not be available for up to 30 minutes.</span></span>

> [!NOTE]
> <span data-ttu-id="ff643-145">この例の *applicationId* の値と *adUnitId* の値は、[テスト モードの値](set-up-ad-units-in-your-app.md#test-ad-units)です。</span><span class="sxs-lookup"><span data-stu-id="ff643-145">The *applicationId* and *adUnitId* values shown in this example are [test mode values](set-up-ad-units-in-your-app.md#test-ad-units).</span></span> <span data-ttu-id="ff643-146">申請のためにアプリを提出する前に、Windows デベロッパー センターから[実際の値にこれらの値を置き換える](set-up-ad-units-in-your-app.md#live-ad-units)必要があります。</span><span class="sxs-lookup"><span data-stu-id="ff643-146">You must [replace these values with live values](set-up-ad-units-in-your-app.md#live-ad-units) from Windows Dev Center before submitting your app for submission.</span></span>

<span id="release" />

## <a name="release-your-app-with-live-ads"></a><span data-ttu-id="ff643-147">ライブ広告を表示するアプリをリリースする</span><span class="sxs-lookup"><span data-stu-id="ff643-147">Release your app with live ads</span></span>

1. <span data-ttu-id="ff643-148">アプリでのバナー広告の使用方法が[バナー広告のガイドライン](ui-and-user-experience-guidelines.md#guidelines-for-banner-ads)に従っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ff643-148">Make sure your use of banner ads in your app follows our [guidelines for banner ads](ui-and-user-experience-guidelines.md#guidelines-for-banner-ads).</span></span>

1.  <span data-ttu-id="ff643-149">デベロッパー センター ダッシュボードで、[[アプリ内広告]](../publish/in-app-ads.md) ページに移動し、[広告ユニットを作成](set-up-ad-units-in-your-app.md#live-ad-units)します。</span><span class="sxs-lookup"><span data-stu-id="ff643-149">In the Dev Center dashboard, go to the [In-app ads](../publish/in-app-ads.md) page and [create an ad unit](set-up-ad-units-in-your-app.md#live-ad-units).</span></span> <span data-ttu-id="ff643-150">広告ユニットの種類として、**[バナー]** を指定します。</span><span class="sxs-lookup"><span data-stu-id="ff643-150">For the ad unit type, specify **Banner**.</span></span> <span data-ttu-id="ff643-151">広告ユニット ID とアプリケーション ID の両方を書き留めておきます。</span><span class="sxs-lookup"><span data-stu-id="ff643-151">Make note of both the ad unit ID and the application ID.</span></span>
    > [!NOTE]
    > <span data-ttu-id="ff643-152">テスト広告ユニットとライブ UWP 広告ユニットでは、アプリケーション ID の値の形式が異なります。</span><span class="sxs-lookup"><span data-stu-id="ff643-152">The application ID values for test ad units and live UWP ad units have different formats.</span></span> <span data-ttu-id="ff643-153">テスト アプリケーション ID の値は GUID です。</span><span class="sxs-lookup"><span data-stu-id="ff643-153">Test application ID values are GUIDs.</span></span> <span data-ttu-id="ff643-154">ダッシュボードでライブ UWP 広告ユニットを作成する場合、広告ユニットのアプリケーション ID の値は常にアプリの Store ID に一致します (Store ID 値は、たとえば 9NBLGGH4R315 のようになります)。</span><span class="sxs-lookup"><span data-stu-id="ff643-154">When you create a live UWP ad unit in the dashboard, the application ID value for the ad unit always matches the Store ID for your app (an example Store ID value looks like 9NBLGGH4R315).</span></span>

2. <span data-ttu-id="ff643-155">必要に応じて、[[アプリ内広告]](../publish/in-app-ads.md) ページの [[仲介設定]](../publish/in-app-ads.md#mediation) セクションで設定を構成することで、**AdControl** の広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="ff643-155">You can optionally enable ad mediation for the **AdControl** by configuring the settings in the [Mediation settings](../publish/in-app-ads.md#mediation) section on the [In-app ads](../publish/in-app-ads.md) page.</span></span> <span data-ttu-id="ff643-156">広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、Taboola や Smaato などの他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ff643-156">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks, including ads from other paid ad networks such as Taboola and Smaato and ads for Microsoft app promotion campaigns.</span></span>

3.  <span data-ttu-id="ff643-157">コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="ff643-157">In your code, replace the test ad unit values (**applicationId** and **adUnitId**) with the live values you generated in Dev Center.</span></span>

4.  <span data-ttu-id="ff643-158">デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="ff643-158">[Submit your app](../publish/app-submissions.md) to the Store using the Dev Center dashboard.</span></span>

5.  <span data-ttu-id="ff643-159">デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。</span><span class="sxs-lookup"><span data-stu-id="ff643-159">Review your [advertising performance reports](../publish/advertising-performance-report.md) in the Dev Center dashboard.</span></span>             

<span id="manage" />

## <a name="manage-ad-units-for-multiple-ad-controls-in-your-app"></a><span data-ttu-id="ff643-160">アプリで複数の広告コントロールの広告ユニットを管理する</span><span class="sxs-lookup"><span data-stu-id="ff643-160">Manage ad units for multiple ad controls in your app</span></span>

<span data-ttu-id="ff643-161">1 つのアプリで複数の **AdControl** オブジェクトを使うことができます (たとえば、アプリの各ページに異なる **AdControl** オブジェクトをホストできます)。</span><span class="sxs-lookup"><span data-stu-id="ff643-161">You can use multiple **AdControl** objects in a single app (for example, each page in your app might host a different **AdControl** object).</span></span> <span data-ttu-id="ff643-162">このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ff643-162">In this scenario, we recommend that you assign a different ad unit to each control.</span></span> <span data-ttu-id="ff643-163">各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="ff643-163">Using different ad units for each control enables you to separately [configure the mediation settings](../publish/in-app-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="ff643-164">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="ff643-164">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="ff643-165">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="ff643-165">You can use each ad unit in only one app.</span></span> <span data-ttu-id="ff643-166">複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="ff643-166">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="ff643-167">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ff643-167">Related topics</span></span>

* [<span data-ttu-id="ff643-168">バナー広告のガイドライン</span><span class="sxs-lookup"><span data-stu-id="ff643-168">Guidelines for banner ads</span></span>](ui-and-user-experience-guidelines.md#guidelines-for-banner-ads)
* [<span data-ttu-id="ff643-169">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="ff643-169">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
* [<span data-ttu-id="ff643-170">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="ff643-170">Set up ad units for your app</span></span>](set-up-ad-units-in-your-app.md)
* [<span data-ttu-id="ff643-171">JavaScript ウォークスルーでのエラー処理</span><span class="sxs-lookup"><span data-stu-id="ff643-171">Error handling in JavaScript walkthrough</span></span>](error-handling-in-javascript-walkthrough.md)
