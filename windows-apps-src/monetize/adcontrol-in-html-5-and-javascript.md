---
author: mcleanbyron
ms.assetid: adb2fa45-e18f-4254-bd8b-a749a386e3b4
description: "Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の JavaScript/HTML アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。"
title: "HTML 5 および JavaScript の AdControl"
ms.author: mcleans
ms.date: 06/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, Advertising, AdControl, 広告コントロール, JavaScript, HTML"
ms.openlocfilehash: 44417516d773ea4faf103f6d4cdaf0bc8f290921
ms.sourcegitcommit: 8c4d50ef819ed1a2f8cac4eebefb5ccdaf3fa898
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/27/2017
---
# <a name="adcontrol-in-html-5-and-javascript"></a><span data-ttu-id="a94d9-104">HTML 5 および JavaScript の AdControl</span><span class="sxs-lookup"><span data-stu-id="a94d9-104">AdControl in HTML 5 and JavaScript</span></span>

<span data-ttu-id="a94d9-105">このチュートリアルでは、Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の JavaScript/HTML アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスを使ってバナー広告を表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-105">This walkthrough shows how to use the [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) class to display banner ads in a JavaScript/HTML app for Windows 10 (UWP), Windows 8.1, or Windows Phone 8.1.</span></span>

<span data-ttu-id="a94d9-106">JavaScript/HTML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a94d9-106">For a complete sample project that demonstrates how to add banner ads to a JavaScript/HTML app, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="a94d9-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="a94d9-107">Prerequisites</span></span>


* <span data-ttu-id="a94d9-108">UWP アプリの場合: Visual Studio 2015 以降のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="a94d9-108">For UWP apps: install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release.</span></span>
* <span data-ttu-id="a94d9-109">Windows 8.1 アプリまたは Windows Phone 8.1 アプリ: Visual Studio 2015 または Visual Studio 2013 と共に [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="a94d9-109">For Windows 8.1 or Windows Phone 8.1 apps: install the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk) with Visual Studio 2015 or Visual Studio 2013.</span></span>

> [!NOTE]
> <span data-ttu-id="a94d9-110">UWP アプリにバナー広告を追加し、Windows 10 SDK バージョン 10.0.14393 (Anniversary Update) または Windows SDK のそれ以降のバージョンをインストールしている場合、WinJS ライブラリもインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a94d9-110">If you are adding banner ads to a UWP app and you have installed the Windows 10 SDK version 10.0.14393 (Anniversary Update) or a later version of the Windows SDK, you must also install the WinJS library.</span></span> <span data-ttu-id="a94d9-111">このライブラリは以前のバージョンの Windows SDK for Windows 10 に含まれていましたが、Windows 10 SDK バージョン 10.0.14393 (Anniversary Update) 以降ではこのライブラリを別個にインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a94d9-111">This library used to be included in previous versions of the Windows SDK for Windows 10, but starting with the Windows 10 SDK version 10.0.14393 (Anniversary Update) this library must be installed separately.</span></span> <span data-ttu-id="a94d9-112">WinJS をインストールする場合は、「[Get WinJS (WinJS を入手する)](http://try.buildwinjs.com/download/GetWinJS/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a94d9-112">To install WinJS, see [Get WinJS](http://try.buildwinjs.com/download/GetWinJS/).</span></span>

## <a name="code-development"></a><span data-ttu-id="a94d9-113">コード開発</span><span class="sxs-lookup"><span data-stu-id="a94d9-113">Code development</span></span>

1. <span data-ttu-id="a94d9-114">Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="a94d9-114">In Visual Studio, open your project or create a new project.</span></span>

2. <span data-ttu-id="a94d9-115">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-115">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="a94d9-116">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="a94d9-116">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps.</span></span> <span data-ttu-id="a94d9-117">詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a94d9-117">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

3.  <span data-ttu-id="a94d9-118">**ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-118">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>

4.  <span data-ttu-id="a94d9-119">**[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-119">In **Reference Manager**, select one of the following references depending on your project type:</span></span>

    -   <span data-ttu-id="a94d9-120">ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for JavaScript]** (Version 10.0) の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="a94d9-120">For a Universal Windows Platform (UWP) project: Expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for JavaScript** (Version 10.0).</span></span>

    -   <span data-ttu-id="a94d9-121">Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows 8.1 Native (JS)]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="a94d9-121">For a Windows 8.1 project: Expand **Windows 8.1**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for Windows 8.1 Native (JS)**.</span></span>

    -   <span data-ttu-id="a94d9-122">Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="a94d9-122">For a Windows Phone 8.1 project: Expand **Windows Phone 8.1**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)**.</span></span>

    ![javascriptaddreference](images/13-f7f6d6a6-161e-4f17-995d-1236d0b5d9f2.png)

5.  <span data-ttu-id="a94d9-124">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a94d9-124">In **Reference Manager**, click OK.</span></span>

6.  <span data-ttu-id="a94d9-125">index.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-125">Open the index.html file (or other html file as appropriate for your project).</span></span>

7.  <span data-ttu-id="a94d9-126">**&lt;head&gt;** セクションで、プロジェクトの default.css と main.js の JavaScript 参照の後に ad.js への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-126">In the **&lt;head&gt;** section, after the project’s JavaScript references of default.css and main.js, add the reference to ad.js.</span></span>

    <span data-ttu-id="a94d9-127">UWP プロジェクトでは、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-127">In a UWP project, add the following code.</span></span>

    ``` HTML
    <!-- Advertising required references -->
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    ```

    <span data-ttu-id="a94d9-128">Windows 8.1 または Windows Phone 8.1 のプロジェクトでは、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-128">In a Windows 8.1 or Windows Phone 8.1 project, add the following code.</span></span>

    ``` HTML
    <!-- Advertising required references -->
    <script src="/MSAdvertisingJS/ads/ad.js"></script>
    ```

    > [!NOTE]
    > <span data-ttu-id="a94d9-129">この行は、**&lt;head&gt;** セクションの main.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-129">This line must be placed in the **&lt;head&gt;** section after the include of main.js; otherwise, you will encounter an error when you build your project.</span></span> <span data-ttu-id="a94d9-130">プロジェクトのターゲットが Windows 8.1 または Windows Phone 8.1 である場合、プロジェクトの既定の HTML ファイルの名前は index.html ではなく default.html になります。また、プロジェクトの既定の JavaScript ファイルの名前は main.js ではなく default.js になります。</span><span class="sxs-lookup"><span data-stu-id="a94d9-130">If your project targets Windows 8.1 or Windows Phone 8.1, the default HTML file in your project is named default.html instead of index.html, and the default JavaScript file in your project is named default.js instead of main.js.</span></span>

8.  <span data-ttu-id="a94d9-131">default.html ファイル (またはプロジェクトに対応するその他の html ファイル) の **&lt;body&gt;** セクションを変更して、**AdControl** の div を追加します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-131">Modify the **&lt;body&gt;** section in the default.html file (or other html file as appropriate for your project) to include the div for the **AdControl**.</span></span> <span data-ttu-id="a94d9-132">**AdControl** の **applicationId** プロパティと **adUnitId** プロパティに、「[Test mode values (テスト モードの値)](test-mode-values.md)」に示されているテスト値を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-132">Assign the **applicationId** and **adUnitId** properties in the **AdControl** to the test values provided in [Test mode values](test-mode-values.md).</span></span> <span data-ttu-id="a94d9-133">また、コントロールの高さと幅を、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-133">Also adjust the height and width of the control so it is one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!NOTE]
    > <span data-ttu-id="a94d9-134">各 **AdControl** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-134">Every **AdControl** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="a94d9-135">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-135">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="a94d9-136">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-136">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="a94d9-137">ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="a94d9-137">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

    ``` HTML
    <div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
        data-win-control="MicrosoftNSJS.Advertising.AdControl"
        data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test'}">
    </div>
    ```

9.  <span data-ttu-id="a94d9-138">アプリをコンパイルして実行し、広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-138">Compile and run the app to see it with an ad.</span></span>

<span data-ttu-id="a94d9-139">次の例は、シンプルな UWP アプリの index.html 全体を示しています。</span><span class="sxs-lookup"><span data-stu-id="a94d9-139">The following example shows the complete index.html for a simple UWP app.</span></span>

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

<span id="release" />
## <a name="release-your-app-with-live-ads-using-windows-dev-center"></a><span data-ttu-id="a94d9-140">Windows デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする</span><span class="sxs-lookup"><span data-stu-id="a94d9-140">Release your app with live ads using Windows Dev Center</span></span>

1.  <span data-ttu-id="a94d9-141">デベロッパー センターのダッシュボードで、アプリの [[広告で収入を増やす]](../publish/monetize-with-ads.md) ページに移動し、[広告ユニットを作成](../monetize/set-up-ad-units-in-your-app.md)します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-141">In the Dev Center dashboard, go to the [Monetize with ads](../publish/monetize-with-ads.md) page for your app and [create an ad unit](../monetize/set-up-ad-units-in-your-app.md).</span></span> <span data-ttu-id="a94d9-142">広告ユニットの種類として、**[バナー]** を指定します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-142">For the ad unit type, specify **Banner**.</span></span> <span data-ttu-id="a94d9-143">広告ユニット ID とアプリケーション ID の両方をメモしておきます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-143">Make note of both the ad unit ID and the application ID.</span></span>

2. <span data-ttu-id="a94d9-144">アプリが Windows 10 用 UWP アプリである場合、[[広告で収入を増やす]](../publish/monetize-with-ads.md) ページの[広告仲介](../publish/monetize-with-ads.md#mediation)セクションで設定を構成することにより、必要に応じて **AdControl** の広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-144">If your app is a UWP app for Windows 10, you can optionally enable ad mediation for the **AdControl** by configuring the settings in the [Ad mediation](../publish/monetize-with-ads.md#mediation) section on the [Monetize with ads](../publish/monetize-with-ads.md) page.</span></span> <span data-ttu-id="a94d9-145">広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、Taboola や Smaato などの他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-145">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks, including ads from other paid ad networks such as Taboola and Smaato and ads for Microsoft app promotion campaigns.</span></span>

3.  <span data-ttu-id="a94d9-146">コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-146">In your code, replace the test ad unit values (**applicationId** and **adUnitId**) with the live values you generated in Dev Center.</span></span>

4.  <span data-ttu-id="a94d9-147">デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-147">[Submit your app](../publish/app-submissions.md) to the Store using the Dev Center dashboard.</span></span>

5.  <span data-ttu-id="a94d9-148">デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。</span><span class="sxs-lookup"><span data-stu-id="a94d9-148">Review your [advertising performance reports](../publish/advertising-performance-report.md) in the Dev Center dashboard.</span></span>             

<span id="manage" />
## <a name="manage-ad-units-for-multiple-ad-controls-in-your-app"></a><span data-ttu-id="a94d9-149">アプリで複数の広告コントロールの広告ユニットを管理する</span><span class="sxs-lookup"><span data-stu-id="a94d9-149">Manage ad units for multiple ad controls in your app</span></span>

<span data-ttu-id="a94d9-150">1 つのアプリで複数の **AdControl** オブジェクトを使うことができます (たとえば、アプリの各ページに異なる **AdControl** オブジェクトをホストできます)。</span><span class="sxs-lookup"><span data-stu-id="a94d9-150">You can use multiple **AdControl** objects in a single app (for example, each page in your app might host a different **AdControl** object).</span></span> <span data-ttu-id="a94d9-151">このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a94d9-151">In this scenario, we recommend that you assign a different ad unit to each control.</span></span> <span data-ttu-id="a94d9-152">各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/monetize-with-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="a94d9-152">Using different ad units for each control enables you to separately [configure the mediation settings](../publish/monetize-with-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="a94d9-153">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-153">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a94d9-154">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="a94d9-154">You can use each ad unit in only one app.</span></span> <span data-ttu-id="a94d9-155">複数のアプリで広告ユニットを使用すると、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="a94d9-155">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="a94d9-156">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a94d9-156">Related topics</span></span>

* [<span data-ttu-id="a94d9-157">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="a94d9-157">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
* [<span data-ttu-id="a94d9-158">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="a94d9-158">Set up ad units for your app</span></span>](../monetize/set-up-ad-units-in-your-app.md)
