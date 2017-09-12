---
author: mcleanbyron
ms.assetid: c0450f7b-5c81-4d8c-92ef-2b1190d18af7
description: "Windows Phone 8.1 用または Windows Phone 8.0 用の Silverlight アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。"
title: "Windows Phone Silverlight の AdControl"
ms.author: mcleans
ms.date: 07/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、広告、宣伝、AdControl、Silverlight、Windows Phone"
ms.openlocfilehash: f1582639757abfb6de156bf88ce8af71ba3eaacd
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="adcontrol-in-windows-phone-silverlight"></a><span data-ttu-id="94f42-104">Windows Phone Silverlight の AdControl</span><span class="sxs-lookup"><span data-stu-id="94f42-104">AdControl in Windows Phone Silverlight</span></span>

<span data-ttu-id="94f42-105">このチュートリアルでは、Windows Phone 8.1 用または Windows Phone 8.0 用の Silverlight アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/hh524191.aspx) クラスを使ってバナー広告を表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="94f42-105">This walkthrough shows how to use the [AdControl](https://msdn.microsoft.com/library/windows/apps/hh524191.aspx) class to display banner ads in a Silverlight app for Windows Phone 8.1 or Windows Phone 8.0.</span></span>

<span id="silverlight_support"/>
## <a name="advertising-support-for-windows-phone-8x-silverlight-projects"></a><span data-ttu-id="94f42-106">Windows Phone 8.x Silverlight プロジェクト用の広告のサポート</span><span class="sxs-lookup"><span data-stu-id="94f42-106">Advertising support for Windows Phone 8.x Silverlight projects</span></span>

<span data-ttu-id="94f42-107">Windows Phone 8.x Silverlight プロジェクトでのいくつかの開発者シナリオは、サポートされません。</span><span class="sxs-lookup"><span data-stu-id="94f42-107">Some developer scenarios are no longer supported in Windows Phone 8.x Silverlight projects.</span></span> <span data-ttu-id="94f42-108">詳しくは、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="94f42-108">For more information, see the following table.</span></span>

|  <span data-ttu-id="94f42-109">プラットフォームのバージョン</span><span class="sxs-lookup"><span data-stu-id="94f42-109">Platform version</span></span>  |  <span data-ttu-id="94f42-110">既存のプロジェクト</span><span class="sxs-lookup"><span data-stu-id="94f42-110">Existing projects</span></span>    |   <span data-ttu-id="94f42-111">新しいプロジェクト</span><span class="sxs-lookup"><span data-stu-id="94f42-111">New projects</span></span>  |
|-----------------|----------------|--------------|
| <span data-ttu-id="94f42-112">Windows Phone 8.0 Silverlight</span><span class="sxs-lookup"><span data-stu-id="94f42-112">Windows Phone 8.0 Silverlight</span></span>     |  <span data-ttu-id="94f42-113">Microsoft ユニバーサル広告クライアント SDK または Microsoft Advertising SDK の以前のリリースの **AdControl** または **AdMediatorControl** を使用している既存の Windows Phone 8.0 Silverlight プロジェクトがあり、アプリが既に Windows ストアで公開されている場合、プロジェクトの変更とリビルドを行い、デバイスで変更のデバッグまたはテストを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="94f42-113">If you have an existing Windows Phone 8.0 Silverlight project that already uses an **AdControl** or **AdMediatorControl** from an earlier release of the Universal Ad Client SDK or Microsoft Advertising SDK and this app is already published in the Windows Store, you can modify and rebuild the project, and you can debug or test your changes on a device.</span></span> <span data-ttu-id="94f42-114">エミュレーターでのプロジェクトのデバッグまたはテストはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="94f42-114">Debugging or testing the project in the emulator is not supported.</span></span>  |  <span data-ttu-id="94f42-115">サポートされません。</span><span class="sxs-lookup"><span data-stu-id="94f42-115">Not supported.</span></span>  |
| <span data-ttu-id="94f42-116">Windows Phone 8.1 Silverlight</span><span class="sxs-lookup"><span data-stu-id="94f42-116">Windows Phone 8.1 Silverlight</span></span>    |  <span data-ttu-id="94f42-117">以前の SDK の **AdControl** または **AdMediatorControl** を使用している既存の Windows Phone 8.1 Silverlight プロジェクトがある場合、プロジェクトの変更とリビルドを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="94f42-117">If you have an existing Windows Phone 8.1 Silverlight project that uses an **AdControl** or **AdMediatorControl** from an earlier SDK, you can modify and rebuild the project.</span></span> <span data-ttu-id="94f42-118">ただし、アプリをテストまたはデバッグするには、エミュレーターでアプリを実行し、アプリケーション ID と広告ユニット ID に[テスト モードの値](test-mode-values.md)を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="94f42-118">However, to debug or test the app, you must run the app in the emulator and use [test mode values](test-mode-values.md) for the application ID and ad unit ID.</span></span> <span data-ttu-id="94f42-119">デバイス上でのアプリのデバッグやテストはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="94f42-119">Debugging or testing the app on a device is not supported.</span></span>  |   <span data-ttu-id="94f42-120">新しい Windows Phone 8.1 Silverlight プロジェクトに **AdControl** または **AdMediatorControl** を追加することができます。</span><span class="sxs-lookup"><span data-stu-id="94f42-120">You can add an **AdControl** or **AdMediatorControl** to a new Windows Phone 8.1 Silverlight project.</span></span> <span data-ttu-id="94f42-121">ただし、アプリをテストまたはデバッグするには、エミュレーターでアプリを実行し、アプリケーション ID と広告ユニット ID に[テスト モードの値](test-mode-values.md)を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="94f42-121">However, to debug or test the app, you must run the app in the emulator and use [test mode values](test-mode-values.md) for the application ID and ad unit ID.</span></span> <span data-ttu-id="94f42-122">デバイス上でのアプリのデバッグやテストはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="94f42-122">Debugging or testing the app on a device is not supported.</span></span> |

## <a name="add-the-advertising-assemblies-to-your-project"></a><span data-ttu-id="94f42-123">Advertising アセンブリをプロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="94f42-123">Add the advertising assemblies to your project</span></span>

<span data-ttu-id="94f42-124">まず、Windows Phone Silverlight 用の Microsoft Advertising アセンブリを含む NuGet パッケージをプロジェクトにダウンロードしてインストールします。</span><span class="sxs-lookup"><span data-stu-id="94f42-124">To get started, download and install the NuGet package that contains the Microsoft advertising assemblies for Windows Phone Silverlight to your project.</span></span>

1.  <span data-ttu-id="94f42-125">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="94f42-125">Open your project in Visual Studio.</span></span>

2.  <span data-ttu-id="94f42-126">**[ツール]** をクリックし、**[NuGet パッケージ マネージャー]** をポイントして **[パッケージ マネージャー コンソール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="94f42-126">Click **Tools**, point to **NuGet Package Manager**, and click **Package Manager Console**.</span></span>

3.  <span data-ttu-id="94f42-127">**パッケージ マネージャー コンソール** ウィンドウで、以下のいずれかのコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="94f42-127">In the **Package Manager Console** window, enter one of these commands.</span></span>

  * <span data-ttu-id="94f42-128">プロジェクトが Windows Phone 8.0 をターゲットとする場合は、以下のコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="94f42-128">If your project targets Windows Phone 8.0, enter this command.</span></span>

      ```syntax
      Install-Package Microsoft.Advertising.WindowsPhone.SL80 -Version 6.2.40501.1
      ```

  * <span data-ttu-id="94f42-129">プロジェクトが Windows Phone 8.1 をターゲットとする場合は、以下のコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="94f42-129">If your project targets Windows Phone 8.1, enter this command.</span></span>

      ```syntax
      Install-Package Microsoft.Advertising.WindowsPhone.SL81 -Version 8.1.50112
      ```

    <span data-ttu-id="94f42-130">コマンドを入力すると、必要なすべての Silverlight 用 Microsoft Advertising アセンブリが NuGet パッケージとしてローカルのプロジェクトにダウンロードされ、それらのアセンブリへの参照が自動的にプロジェクトに追加されます。</span><span class="sxs-lookup"><span data-stu-id="94f42-130">After entering the command, all the necessary Microsoft advertising assemblies for Silverlight are downloaded to your local project via NuGet packages, and references to these assemblies are automatically added to your project.</span></span>

## <a name="code-your-app"></a><span data-ttu-id="94f42-131">アプリのコードを記述する</span><span class="sxs-lookup"><span data-stu-id="94f42-131">Code your app</span></span>


1.  <span data-ttu-id="94f42-132">WMAppManifest.xml ファイルの **Capabilities** ノードに次の機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="94f42-132">Add the following capabilities to the in the **Capabilities** node in your WMAppManifest.xml file.</span></span>

  ``` syntax
  <Capability Name="ID_CAP_IDENTITY_USER"/>
  <Capability Name="ID_CAP_MEDIALIB_PHOTO"/>
  <Capability Name="ID_CAP_PHONEDIALER"/>
  ```

  <span data-ttu-id="94f42-133">この例では、**Capabilities** ノードが次のようになります。</span><span class="sxs-lookup"><span data-stu-id="94f42-133">For this example, your **Capabilities** node looks like:</span></span>

  ``` syntax
  <Capabilities>
      <Capability Name="ID_CAP_NETWORKING"/>
      <Capability Name="ID_CAP_MEDIALIB_AUDIO"/>
      <Capability Name="ID_CAP_MEDIALIB_PLAYBACK"/>
      <Capability Name="ID_CAP_SENSORS"/>
      <Capability Name="ID_CAP_WEBBROWSERCOMPONENT"/>
      <Capability Name="ID_CAP_IDENTITY_USER"/>
      <Capability Name="ID_CAP_MEDIALIB_PHOTO"/>
      <Capability Name="ID_CAP_PHONEDIALER"/>
  </Capabilities>
  ```

2.  <span data-ttu-id="94f42-134">(省略可能) プロジェクトを保存します。</span><span class="sxs-lookup"><span data-stu-id="94f42-134">(Optional) Save your project.</span></span> <span data-ttu-id="94f42-135">**[すべてを保存]** アイコンをクリックするか、**[ファイル]** メニューの **[すべてを保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="94f42-135">Click on the **Save All** icon or under the **File** menu click **Save All**.</span></span>

3.  <span data-ttu-id="94f42-136">プロジェクトの Package.appxmanifest ファイルに **[インターネット (クライアントとサーバー)]** 機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="94f42-136">Add the **Internet (Client & Server)** capability to the Package.appxmanifest file in your project.</span></span> <span data-ttu-id="94f42-137">**ソリューション エクスプローラー**で、**[Package.appxmanifest]** をダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="94f42-137">In **Solution Explorer**, double click **Package.appxmanifest**.</span></span>

    ![wp81silverlightmarkup\-solutionexplorer\-packageappxmanifest](images/13-b98c2a1a-69c3-4018-be0a-6ce010e703e7.jpg)

    <span data-ttu-id="94f42-139">**エディター**で、**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="94f42-139">In the **Editor**, click the **Capabilities** tab.</span></span> <span data-ttu-id="94f42-140">**[インターネット (クライアントとサーバー)]** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="94f42-140">Check the **Internet (Client & Server)** box.</span></span>

4.  <span data-ttu-id="94f42-141">(省略可能) プロジェクトを保存します。</span><span class="sxs-lookup"><span data-stu-id="94f42-141">(Optional) Save your project.</span></span> <span data-ttu-id="94f42-142">**[すべてを保存]** アイコンをクリックするか、**[ファイル]** メニューの **[すべてを保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="94f42-142">Click on the **Save All** icon or under the **File** menu click **Save All**.</span></span>

5.  <span data-ttu-id="94f42-143">MainPage.xaml ファイルの Silverlight マークアップを変更して、**Microsoft.Advertising.Mobile.UI** 名前空間を追加します。</span><span class="sxs-lookup"><span data-stu-id="94f42-143">Modify the Silverlight markup in the MainPage.xaml file to include the **Microsoft.Advertising.Mobile.UI** namespace.</span></span>

  ``` xml
  xmlns:UI="clr-namespace:Microsoft.Advertising.Mobile.UI;assembly=Microsoft.Advertising.Mobile.UI"
  ```

  <span data-ttu-id="94f42-144">ページのヘッダーのコードが次のようになります。</span><span class="sxs-lookup"><span data-stu-id="94f42-144">The header of your page will have the following code:</span></span>

  ``` xml
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
  xmlns:UI="clr-namespace:Microsoft.Advertising.Mobile.UI;assembly=Microsoft.Advertising.Mobile.UI"
  x:Class="PhoneApp1.MainPage"
  ```

6.  <span data-ttu-id="94f42-145">**Grid** タグに、以下に示す **AdControl** のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="94f42-145">In the **Grid** tag, add the following code for the **AdControl**.</span></span> <span data-ttu-id="94f42-146">**ApplicationId** プロパティと **AdUnitId** プロパティに、「[Test mode values (テスト モードの値)](test-mode-values.md)」に示されているテスト値を割り当てて、**Height** プロパティと **Width** プロパティを、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。</span><span class="sxs-lookup"><span data-stu-id="94f42-146">Assign the **ApplicationId** and **AdUnitId** properties to the test values provided in [Test mode values](test-mode-values.md), and adjust the **Height** and **Width** properties to one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

  > <span data-ttu-id="94f42-147">              **注**&nbsp;&nbsp;**ApplicationId** と **AdUnitId** のテスト値は、アプリを申請のために提出する前に実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="94f42-147">**Note**&nbsp;&nbsp;You will replace the test **ApplicationId** and **AdUnitId** values with live values before submitting your app for submission.</span></span>

  ``` xml
  <Grid x:Name="ContentPanel" Grid.Row="1">
      <UI:AdControl
          ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
          AdUnitId="10865270"
          HorizontalAlignment="Left"
          Height="80"
          VerticalAlignment="Top"
          Width="480"/>
  </Grid>
  ```

7.  <span data-ttu-id="94f42-148">プロジェクトをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="94f42-148">Build and run your project.</span></span> <span data-ttu-id="94f42-149">アプリに次のような広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="94f42-149">Confirm that your app displays an ad, similar to the following:</span></span>

  ![wp81silverlight\-emulatorwithad](images/13-8db1492f-ae1d-439b-9b78-bed8e22fe996.jpg)

## <a name="release-your-app-with-live-ads-using-dev-center"></a><span data-ttu-id="94f42-151">デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする</span><span class="sxs-lookup"><span data-stu-id="94f42-151">Release your app with live ads using Dev Center</span></span>

1.  <span data-ttu-id="94f42-152">デベロッパー センターのダッシュボードで、アプリの **[収益化]** &gt; **[広告で収入を増やす]** ページに移動し、[スタンドアロン広告ユニットを作成](../publish/monetize-with-ads.md)します。</span><span class="sxs-lookup"><span data-stu-id="94f42-152">In the Dev Center dashboard, go to the **Monetization** &gt; **Monetize with ads** page for your app, and [create a standalone ad unit](../publish/monetize-with-ads.md).</span></span> <span data-ttu-id="94f42-153">広告ユニットの種類として、**[バナー]** を指定します。</span><span class="sxs-lookup"><span data-stu-id="94f42-153">For the ad unit type, specify **Banner**.</span></span> <span data-ttu-id="94f42-154">広告ユニット ID とアプリケーション ID の両方をメモしておきます。</span><span class="sxs-lookup"><span data-stu-id="94f42-154">Make note of both the ad unit ID and the application ID.</span></span>

2.  <span data-ttu-id="94f42-155">コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="94f42-155">In your code, replace the test ad unit values (**applicationId** and **adUnitId**) with the live values you generated in Dev Center.</span></span>

3.  <span data-ttu-id="94f42-156">デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="94f42-156">[Submit your app](../publish/app-submissions.md) to the Store using the Dev Center dashboard.</span></span>

4.  <span data-ttu-id="94f42-157">デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。</span><span class="sxs-lookup"><span data-stu-id="94f42-157">Review your [advertising performance reports](../publish/advertising-performance-report.md) in the Dev Center dashboard.</span></span>


 
