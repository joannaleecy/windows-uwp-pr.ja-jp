---
author: Xansky
ms.assetid: 4e7c2388-b94e-4828-a104-14fa33f6eb2d
description: Windows 10 (UWP) 用の XAML アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。
title: XAML および .NET の AdControl
ms.author: mhopkins
ms.date: 03/22/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, AdControl, 広告コントロール, XAML, .NET, チュートリアル
ms.localizationpriority: medium
ms.openlocfilehash: b2346fceaae3996de8aa54640c206b5fcd8c4a87
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7572774"
---
# <a name="adcontrol-in-xaml-and-net"></a><span data-ttu-id="2224e-104">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="2224e-104">AdControl in XAML and .NET</span></span>


<span data-ttu-id="2224e-105">このチュートリアルでは、C# を使用して実装された Windows 10 用のユニバーサル Windows プラットフォーム (UWP) XAML アプリで、[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) クラスを使ってバナー広告を表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2224e-105">This walkthrough shows how to use the [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) class to display banner ads in a Universal Windows Platform (UWP) XAML app for Windows 10 that is implemented using C#.</span></span>

> [!NOTE]
> <span data-ttu-id="2224e-106">Microsoft Advertising SDK は、C++ で実装された XAML アプリもサポートしています。</span><span class="sxs-lookup"><span data-stu-id="2224e-106">The Microsoft Advertising SDK also supports XAML apps that are implemented using C++.</span></span> <span data-ttu-id="2224e-107">完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2224e-107">For a complete sample project, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="2224e-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="2224e-108">Prerequisites</span></span>

* <span data-ttu-id="2224e-109">Visual Studio 2015 以降の Visual Studio のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="2224e-109">Install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release of Visual Studio.</span></span> <span data-ttu-id="2224e-110">インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2224e-110">For installation instructions, see [this article](install-the-microsoft-advertising-libraries.md).</span></span>

## <a name="integrate-a-banner-ad-into-your-app"></a><span data-ttu-id="2224e-111">バナー広告をアプリに統合する</span><span class="sxs-lookup"><span data-stu-id="2224e-111">Integrate a banner ad into your app</span></span>

1. <span data-ttu-id="2224e-112">Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="2224e-112">In Visual Studio, open your project or create a new project.</span></span>

    > [!NOTE]
    > <span data-ttu-id="2224e-113">既存のプロジェクトを使用している場合、プロジェクトの Package.appxmanifest ファイルを開き、**インターネット (クライアント)** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="2224e-113">If you're using an existing project, open the Package.appxmanifest file in your project and ensure that the **Internet (Client)** capability is selected.</span></span> <span data-ttu-id="2224e-114">アプリでは、テスト広告やライブ広告を受信するためにこの機能が必要になります。</span><span class="sxs-lookup"><span data-stu-id="2224e-114">Your app needs this capability to receive test ads and live ads.</span></span>

2. <span data-ttu-id="2224e-115">プロジェクトのターゲットが **[任意の CPU]** になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="2224e-115">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="2224e-116">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="2224e-116">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps.</span></span> <span data-ttu-id="2224e-117">詳しくは、「[プロジェクトのターゲットを "任意の CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2224e-117">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

3. <span data-ttu-id="2224e-118">プロジェクトで Microsoft Advertising SDK への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="2224e-118">Add a reference to the Microsoft Advertising SDK in your project:</span></span>

    1. <span data-ttu-id="2224e-119">**[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="2224e-119">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>
    2.  <span data-ttu-id="2224e-120">**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="2224e-120">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (Version 10.0).</span></span>
    3.  <span data-ttu-id="2224e-121">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2224e-121">In **Reference Manager**, click OK.</span></span>

4.  <span data-ttu-id="2224e-122">広告を埋め込むページの XAML を変更して、**Microsoft.Advertising.WinRT.UI** 名前空間を追加します。</span><span class="sxs-lookup"><span data-stu-id="2224e-122">Modify the XAML for the page where you are embedding advertising to include the **Microsoft.Advertising.WinRT.UI** namespace.</span></span> <span data-ttu-id="2224e-123">たとえば、Visual Studio によって生成される既定のサンプル アプリ (この例では MyAdFundedWindows10AppXAML という名前) では、**MainPage.XAML** という XAML ページに追加します。</span><span class="sxs-lookup"><span data-stu-id="2224e-123">For example, in the default sample app generated by Visual Studio (named, in this app, MyAdFundedWindows10AppXAML), the XAML page is **MainPage.XAML**.</span></span>

    <span data-ttu-id="2224e-124">Visual Studio によって生成される MainPage.xaml ファイルの **Page** セクションには、次のようなコードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2224e-124">The **Page** section of the MainPage.xaml file generated by Visual Studio has the following code.</span></span>

    ``` xml
    <Page
      x:Class="MyAdFundedWindows10AppXAML.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:MyAdFundedWindows10AppXAML"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      mc:Ignorable="d">
      <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      </Grid>
    </Page>
    ```

    <span data-ttu-id="2224e-125">**Microsoft.Advertising.WinRT.UI** 名前空間の参照を追加すると、MainPage.xaml ファイルの **Page** セクションのコードが次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2224e-125">Add the namespace reference **Microsoft.Advertising.WinRT.UI** so the **Page** section of the MainPage.xaml file has the following code.</span></span>

    ``` xml
    <Page
      x:Class="MyAdFundedWindows10AppXAML.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:MyAdFundedWindows10AppXAML"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:UI="using:Microsoft.Advertising.WinRT.UI"
      mc:Ignorable="d">
      <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      </Grid>
    </Page>
    ```

5. <span data-ttu-id="2224e-126">**Grid** タグに、**AdControl** のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="2224e-126">In the **Grid** tag, add the code for the **AdControl**.</span></span> <span data-ttu-id="2224e-127">[AdUnitId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.adunitid) プロパティと [ApplicationId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.applicationid) プロパティに、[広告ユニットのテスト値](set-up-ad-units-in-your-app.md#test-ad-units)を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="2224e-127">Assign the  [AdUnitId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.adunitid) and [ApplicationId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.applicationid) properties to the [test ad unit values](set-up-ad-units-in-your-app.md#test-ad-units).</span></span> <span data-ttu-id="2224e-128">また、コントロールの**高さ**と**幅**を、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。</span><span class="sxs-lookup"><span data-stu-id="2224e-128">Also adjust the **Height** and **Width** of the control so it is one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!NOTE]
    > <span data-ttu-id="2224e-129">各 **AdControl** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="2224e-129">Every **AdControl** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="2224e-130">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="2224e-130">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="2224e-131">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="2224e-131">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="2224e-132">ストアにアプリを公開する前に行う必要があります[置き換えるこれらのテスト値を実際の値](#release)パートナー センターからです。</span><span class="sxs-lookup"><span data-stu-id="2224e-132">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Partner Center.</span></span>

    <span data-ttu-id="2224e-133">完成した **Grid** タグのコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2224e-133">The complete **Grid** tag looks like this code.</span></span>

    ``` xml
    <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
        <UI:AdControl ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
            AdUnitId="test"
            HorizontalAlignment="Left"
            Height="250"
            VerticalAlignment="Top"
            Width="300"/>
    </Grid>
    ```

    <span data-ttu-id="2224e-134">MainPage.xaml ファイルの完全なコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2224e-134">The complete code for the MainPage.xaml file should look like this.</span></span>

    ``` xml
    <Page
      x:Class="MyAdFundedWindows10AppXAML.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:MyAdFundedWindows10AppXAML"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:UI="using:Microsoft.Advertising.WinRT.UI"
      mc:Ignorable="d">
      <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
            <UI:AdControl ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
                  AdUnitId="test"
                  HorizontalAlignment="Left"
                  Height="250"
                  VerticalAlignment="Top"
                  Width="300"/>
      </Grid>
    </Page>
    ```

6.  <span data-ttu-id="2224e-135">アプリをコンパイルして実行し、広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="2224e-135">Compile and run the app to see it with an ad.</span></span>

<span id="release" />

## <a name="release-your-app-with-live-ads"></a><span data-ttu-id="2224e-136">ライブ広告を表示するアプリをリリースする</span><span class="sxs-lookup"><span data-stu-id="2224e-136">Release your app with live ads</span></span>

1. <span data-ttu-id="2224e-137">アプリでのバナー広告の使用方法が[バナー広告のガイドライン](ui-and-user-experience-guidelines.md#guidelines-for-banner-ads)に従っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="2224e-137">Make sure your use of banner ads in your app follows our [guidelines for banner ads](ui-and-user-experience-guidelines.md#guidelines-for-banner-ads).</span></span>

2.  <span data-ttu-id="2224e-138">パートナー センターで、[アプリ内広告](../publish/in-app-ads.md)ページと[広告ユニットを作成](set-up-ad-units-in-your-app.md#live-ad-units)に移動します。</span><span class="sxs-lookup"><span data-stu-id="2224e-138">In Partner Center, go to the [In-app ads](../publish/in-app-ads.md) page and [create an ad unit](set-up-ad-units-in-your-app.md#live-ad-units).</span></span> <span data-ttu-id="2224e-139">広告ユニットの種類として、**[バナー]** を指定します。</span><span class="sxs-lookup"><span data-stu-id="2224e-139">For the ad unit type, specify **Banner**.</span></span> <span data-ttu-id="2224e-140">広告ユニット ID とアプリケーション ID の両方を書き留めておきます。</span><span class="sxs-lookup"><span data-stu-id="2224e-140">Make note of both the ad unit ID and the application ID.</span></span>
    > [!NOTE]
    > <span data-ttu-id="2224e-141">テスト広告ユニットとライブ UWP 広告ユニットでは、アプリケーション ID の値の形式が異なります。</span><span class="sxs-lookup"><span data-stu-id="2224e-141">The application ID values for test ad units and live UWP ad units have different formats.</span></span> <span data-ttu-id="2224e-142">テスト アプリケーション ID の値は GUID です。</span><span class="sxs-lookup"><span data-stu-id="2224e-142">Test application ID values are GUIDs.</span></span> <span data-ttu-id="2224e-143">パートナー センターでライブ UWP 広告ユニットを作成するとき、広告ユニットのアプリケーション ID の値は (ストア ID の値は、たとえばは 9NBLGGH4R315 のようになります)、アプリのストア ID を常に一致します。</span><span class="sxs-lookup"><span data-stu-id="2224e-143">When you create a live UWP ad unit in Partner Center, the application ID value for the ad unit always matches the Store ID for your app (an example Store ID value looks like 9NBLGGH4R315).</span></span>

3. <span data-ttu-id="2224e-144">必要に応じて、[[アプリ内広告]](../publish/in-app-ads.md) ページの [[仲介設定]](../publish/in-app-ads.md#mediation) セクションで設定を構成することで、**AdControl** の広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="2224e-144">You can optionally enable ad mediation for the **AdControl** by configuring the settings in the [Mediation settings](../publish/in-app-ads.md#mediation) section on the [In-app ads](../publish/in-app-ads.md) page.</span></span> <span data-ttu-id="2224e-145">広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、Taboola や Smaato などの他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="2224e-145">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks, including ads from other paid ad networks such as Taboola and Smaato and ads for Microsoft app promotion campaigns.</span></span>

4.  <span data-ttu-id="2224e-146">コードで、テスト用の広告ユニット値 (**ApplicationId**と**AdUnitId**) をパートナー センターで生成した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="2224e-146">In your code, replace the test ad unit values (**ApplicationId** and **AdUnitId**) with the live values you generated in Partner Center.</span></span>

5.  <span data-ttu-id="2224e-147">パートナー センターを使用してストアに[アプリを提出](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="2224e-147">[Submit your app](../publish/app-submissions.md) to the Store using Partner Center.</span></span>

6.  <span data-ttu-id="2224e-148">パートナー センターで、[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。</span><span class="sxs-lookup"><span data-stu-id="2224e-148">Review your [advertising performance reports](../publish/advertising-performance-report.md) in Partner Center.</span></span>

<span id="manage" />

## <a name="manage-ad-units-for-multiple-ad-controls-in-your-app"></a><span data-ttu-id="2224e-149">アプリで複数の広告コントロールの広告ユニットを管理する</span><span class="sxs-lookup"><span data-stu-id="2224e-149">Manage ad units for multiple ad controls in your app</span></span>

<span data-ttu-id="2224e-150">1 つのアプリで複数の **AdControl** オブジェクトを使うことができます (たとえば、アプリの各ページに異なる **AdControl** オブジェクトをホストできます)。</span><span class="sxs-lookup"><span data-stu-id="2224e-150">You can use multiple **AdControl** objects in a single app (for example, each page in your app might host a different **AdControl** object).</span></span> <span data-ttu-id="2224e-151">このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2224e-151">In this scenario, we recommend that you assign a different ad unit to each control.</span></span> <span data-ttu-id="2224e-152">各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="2224e-152">Using different ad units for each control enables you to separately [configure the mediation settings](../publish/in-app-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="2224e-153">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="2224e-153">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2224e-154">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="2224e-154">You can use each ad unit in only one app.</span></span> <span data-ttu-id="2224e-155">複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="2224e-155">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="2224e-156">関連トピック</span><span class="sxs-lookup"><span data-stu-id="2224e-156">Related topics</span></span>

* [<span data-ttu-id="2224e-157">バナー広告のガイドライン</span><span class="sxs-lookup"><span data-stu-id="2224e-157">Guidelines for banner ads</span></span>](ui-and-user-experience-guidelines.md#guidelines-for-banner-ads)
* <span data-ttu-id="2224e-158">[XAML/C# ウォークスルーでのエラー処理](error-handling-in-xamlc-walkthrough.md)</span><span class="sxs-lookup"><span data-stu-id="2224e-158">[Error handling in XAML/C# walkthrough](error-handling-in-xamlc-walkthrough.md).</span></span>
* [<span data-ttu-id="2224e-159">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="2224e-159">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
* [<span data-ttu-id="2224e-160">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="2224e-160">Set up ad units for your app</span></span>](set-up-ad-units-in-your-app.md)
