---
author: mcleanbyron
ms.assetid: 4e7c2388-b94e-4828-a104-14fa33f6eb2d
description: "Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の XAML アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。"
title: "XAML および .NET の AdControl"
ms.author: mcleans
ms.date: 06/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, AdControl, 広告コントロール, XAML, .NET, チュートリアル"
ms.openlocfilehash: be273ca4c17edb4affa5e0abb4b3317b03893280
ms.sourcegitcommit: 8c4d50ef819ed1a2f8cac4eebefb5ccdaf3fa898
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/27/2017
---
# <a name="adcontrol-in-xaml-and-net"></a><span data-ttu-id="761a3-104">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="761a3-104">AdControl in XAML and .NET</span></span>


<span data-ttu-id="761a3-105">このチュートリアルでは、Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の XAML アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスを使ってバナー広告を表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="761a3-105">This walkthrough shows how to use the [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) class to display banner ads in a XAML app for Windows 10 (UWP), Windows 8.1, or Windows Phone 8.1.</span></span>

<span data-ttu-id="761a3-106">C# と C++ を使って XAML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="761a3-106">For a complete sample project that demonstrates how to add banner ads to a XAML app using C# and C++, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="761a3-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="761a3-107">Prerequisites</span></span>

* <span data-ttu-id="761a3-108">UWP アプリの場合: Visual Studio 2015 以降のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="761a3-108">For UWP apps: install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release.</span></span>
* <span data-ttu-id="761a3-109">Windows 8.1 アプリまたは Windows Phone 8.1 アプリ: Visual Studio 2015 または Visual Studio 2013 と共に [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="761a3-109">For Windows 8.1 or Windows Phone 8.1 apps: install the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk) with Visual Studio 2015 or Visual Studio 2013.</span></span>

## <a name="code-development"></a><span data-ttu-id="761a3-110">コード開発</span><span class="sxs-lookup"><span data-stu-id="761a3-110">Code development</span></span>

1. <span data-ttu-id="761a3-111">Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="761a3-111">In Visual Studio, open your project or create a new project.</span></span>

2. <span data-ttu-id="761a3-112">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="761a3-112">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="761a3-113">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="761a3-113">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps.</span></span> <span data-ttu-id="761a3-114">詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="761a3-114">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

1.  <span data-ttu-id="761a3-115">**ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="761a3-115">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>

2.  <span data-ttu-id="761a3-116">**[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。</span><span class="sxs-lookup"><span data-stu-id="761a3-116">In **Reference Manager**, select one of the following references depending on your project type:</span></span>

    -   <span data-ttu-id="761a3-117">ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for XAML]** (Version 10.0) の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="761a3-117">For a Universal Windows Platform (UWP) project: Expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (Version 10.0).</span></span>

    -   <span data-ttu-id="761a3-118">Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows 8.1 XAML]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="761a3-118">For a Windows 8.1 project: Expand **Windows 8.1**, click **Extensions**, and then select the check box next to **Ad Mediator SDK for Windows 8.1 XAML**.</span></span> <span data-ttu-id="761a3-119">この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="761a3-119">This option will add both the Microsoft advertising and ad mediator libraries to your project, but you can ignore the ad mediator libraries.</span></span>

    -   <span data-ttu-id="761a3-120">Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="761a3-120">For a Windows Phone 8.1 project: Expand **Windows Phone 8.1**, click **Extensions**, and then select the check box next to **Ad Mediator SDK for Windows Phone 8.1 XAML**.</span></span> <span data-ttu-id="761a3-121">この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="761a3-121">This option will add both the Microsoft advertising and ad mediator libraries to your project, but you can ignore the ad mediator libraries.</span></span>

    ![addreferences](images/13-a84c026e-b283-44f2-8816-f950a1ef89aa.png)

3.  <span data-ttu-id="761a3-123">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="761a3-123">In **Reference Manager**, click OK.</span></span>

4.  <span data-ttu-id="761a3-124">広告を埋め込むページの XAML を変更して、**Microsoft.Advertising.WinRT.UI** 名前空間を追加します。</span><span class="sxs-lookup"><span data-stu-id="761a3-124">Modify the XAML for the page where you are embedding advertising to include the **Microsoft.Advertising.WinRT.UI** namespace.</span></span> <span data-ttu-id="761a3-125">たとえば、Visual Studio によって生成される既定のサンプル アプリ (この例では MyAdFundedWindows10AppXAML という名前) では、**MainPage.XAML** という XAML ページに追加します。</span><span class="sxs-lookup"><span data-stu-id="761a3-125">For example, in the default sample app generated by Visual Studio (named, in this app, MyAdFundedWindows10AppXAML), the XAML page is **MainPage.XAML**.</span></span>

    <span data-ttu-id="761a3-126">Visual Studio によって生成される MainPage.xaml ファイルの **Page** セクションには、次のようなコードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="761a3-126">The **Page** section of the MainPage.xaml file generated by Visual Studio has the following code.</span></span>

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

    <span data-ttu-id="761a3-127">**Microsoft.Advertising.WinRT.UI** 名前空間の参照を追加すると、MainPage.xaml ファイルの **Page** セクションのコードが次のようになります。</span><span class="sxs-lookup"><span data-stu-id="761a3-127">Add the namespace reference **Microsoft.Advertising.WinRT.UI** so the **Page** section of the MainPage.xaml file has the following code.</span></span>

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

5. <span data-ttu-id="761a3-128">**Grid** タグに、**AdControl** のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="761a3-128">In the **Grid** tag, add the code for the **AdControl**.</span></span> <span data-ttu-id="761a3-129">**Page** の [AdUnitId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.adunitid.aspx) プロパティと [ApplicationId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.applicationid.aspx) プロパティに、「[Test mode values (テスト モードの値)](test-mode-values.md)」に示されているテスト値を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="761a3-129">Assign the  [AdUnitId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.adunitid.aspx) and [ApplicationId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.applicationid.aspx) properties in the **Page** to the test values provided in [Test mode values](test-mode-values.md).</span></span> <span data-ttu-id="761a3-130">また、コントロールの高さと幅を、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。</span><span class="sxs-lookup"><span data-stu-id="761a3-130">Also adjust the height and width of the control so it is one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!NOTE]
    > <span data-ttu-id="761a3-131">各 **AdControl** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="761a3-131">Every **AdControl** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="761a3-132">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="761a3-132">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="761a3-133">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="761a3-133">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="761a3-134">ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="761a3-134">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

    <span data-ttu-id="761a3-135">完成した **Grid** タグのコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="761a3-135">The complete **Grid** tag looks like this code.</span></span>

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

    <span data-ttu-id="761a3-136">MainPage.xaml ファイルの完全なコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="761a3-136">The complete code for the MainPage.xaml file should look like this.</span></span>

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

6.  <span data-ttu-id="761a3-137">アプリをコンパイルして実行し、広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="761a3-137">Compile and run the app to see it with an ad.</span></span>

<span id="release" />
## <a name="release-your-app-with-live-ads-using-windows-dev-center"></a><span data-ttu-id="761a3-138">Windows デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする</span><span class="sxs-lookup"><span data-stu-id="761a3-138">Release your app with live ads using Windows Dev Center</span></span>

1.  <span data-ttu-id="761a3-139">デベロッパー センターのダッシュボードで、アプリの [[広告で収入を増やす]](../publish/monetize-with-ads.md) ページに移動し、[広告ユニットを作成](../monetize/set-up-ad-units-in-your-app.md)します。</span><span class="sxs-lookup"><span data-stu-id="761a3-139">In the Dev Center dashboard, go to the [Monetize with ads](../publish/monetize-with-ads.md) page for your app and [create an ad unit](../monetize/set-up-ad-units-in-your-app.md).</span></span> <span data-ttu-id="761a3-140">広告ユニットの種類として、**[バナー]** を指定します。</span><span class="sxs-lookup"><span data-stu-id="761a3-140">For the ad unit type, specify **Banner**.</span></span> <span data-ttu-id="761a3-141">広告ユニット ID とアプリケーション ID の両方をメモしておきます。</span><span class="sxs-lookup"><span data-stu-id="761a3-141">Make note of both the ad unit ID and the application ID.</span></span>

2. <span data-ttu-id="761a3-142">アプリが Windows 10 用 UWP アプリである場合、[[広告で収入を増やす]](../publish/monetize-with-ads.md) ページの [[広告仲介]](../publish/monetize-with-ads.md#mediation) セクションで設定を構成することにより、必要に応じて **AdControl** の広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="761a3-142">If your app is a UWP app for Windows 10, you can optionally enable ad mediation for the **AdControl** by configuring the settings in the [Ad mediation](../publish/monetize-with-ads.md#mediation) section on the [Monetize with ads](../publish/monetize-with-ads.md) page.</span></span> <span data-ttu-id="761a3-143">広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、Taboola や Smaato などの他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="761a3-143">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks, including ads from other paid ad networks such as Taboola and Smaato and ads for Microsoft app promotion campaigns.</span></span>

3.  <span data-ttu-id="761a3-144">コードで、広告ユニットのテスト値 (**ApplicationId** と **AdUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="761a3-144">In your code, replace the test ad unit values (**ApplicationId** and **AdUnitId**) with the live values you generated in Dev Center.</span></span>

4.  <span data-ttu-id="761a3-145">デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="761a3-145">[Submit your app](../publish/app-submissions.md) to the Store using the Dev Center dashboard.</span></span>

5.  <span data-ttu-id="761a3-146">デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。</span><span class="sxs-lookup"><span data-stu-id="761a3-146">Review your [advertising performance reports](../publish/advertising-performance-report.md) in the Dev Center dashboard.</span></span>

<span id="manage" />
## <a name="manage-ad-units-for-multiple-ad-controls-in-your-app"></a><span data-ttu-id="761a3-147">アプリで複数の広告コントロールの広告ユニットを管理する</span><span class="sxs-lookup"><span data-stu-id="761a3-147">Manage ad units for multiple ad controls in your app</span></span>

<span data-ttu-id="761a3-148">1 つのアプリで複数の **AdControl** オブジェクトを使うことができます (たとえば、アプリの各ページに異なる **AdControl** オブジェクトをホストできます)。</span><span class="sxs-lookup"><span data-stu-id="761a3-148">You can use multiple **AdControl** objects in a single app (for example, each page in your app might host a different **AdControl** object).</span></span> <span data-ttu-id="761a3-149">このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="761a3-149">In this scenario, we recommend that you assign a different ad unit to each control.</span></span> <span data-ttu-id="761a3-150">各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/monetize-with-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="761a3-150">Using different ad units for each control enables you to separately [configure the mediation settings](../publish/monetize-with-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="761a3-151">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="761a3-151">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="761a3-152">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="761a3-152">You can use each ad unit in only one app.</span></span> <span data-ttu-id="761a3-153">複数のアプリで広告ユニットを使用すると、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="761a3-153">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

## <a name="notes"></a><span data-ttu-id="761a3-154">注:</span><span class="sxs-lookup"><span data-stu-id="761a3-154">Notes</span></span>

* <span data-ttu-id="761a3-155">C#: **AdControl** イベントにイベント ハンドラーを割り当てる例については、「[XAML プロパティの例](xaml-properties-example.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="761a3-155">C#: See [XAML properties example](xaml-properties-example.md) for an example of how to assign event handlers to **AdControl** events.</span></span> <span data-ttu-id="761a3-156">C# で書かれたイベント ハンドラーのサンプル コードについては、「[C# の AdControl イベント](adcontrol-events-in-c.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="761a3-156">Then see [AdControl events in C#](adcontrol-events-in-c.md) for sample code that shows event handlers written in C#.</span></span>

* <span data-ttu-id="761a3-157">C++: Microsoft Advertising ライブラリの現在のリリースは C++ をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="761a3-157">C++: The current release of the Microsoft advertising libraries support C++.</span></span> <span data-ttu-id="761a3-158">**AdControl** クラスは、ネイティブ C++ で実装されており、.NET CLR を読み込みません。</span><span class="sxs-lookup"><span data-stu-id="761a3-158">The **AdControl** class is implemented in native C++, and does not load the .NET CLR.</span></span> <span data-ttu-id="761a3-159">C++ で **AdControl** を使用する方法を示すコード例については、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="761a3-159">For code examples that demonstrate how to use **AdControl** in C++, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

* <span data-ttu-id="761a3-160">Visual Basic: **AdControl** イベントにイベント ハンドラーを割り当てる例については、「[XAML プロパティの例](xaml-properties-example.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="761a3-160">Visual Basic: See [XAML properties example](xaml-properties-example.md) for an example of how to assign event handlers to **AdControl** events.</span></span>

* <span data-ttu-id="761a3-161">エラー処理: エラー処理の方法については、「[AdControl エラーの処理](adcontrol-error-handling.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="761a3-161">Error Handling: To learn about how to handle errors, see [AdControl error handling](adcontrol-error-handling.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="761a3-162">関連トピック</span><span class="sxs-lookup"><span data-stu-id="761a3-162">Related topics</span></span>

* [<span data-ttu-id="761a3-163">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="761a3-163">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
* [<span data-ttu-id="761a3-164">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="761a3-164">Set up ad units for your app</span></span>](../monetize/set-up-ad-units-in-your-app.md)
