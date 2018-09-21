---
author: mcleanbyron
ms.assetid: 141900dd-f1d3-4432-ac8b-b98eaa0b0da2
description: XAML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策について説明します。
title: XAML と C# のトラブルシューティング ガイド
ms.author: mcleans
ms.date: 08/23/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, 宣伝, AdControl, トラブルシューティング, XAML, C#
ms.localizationpriority: medium
ms.openlocfilehash: d20f816bc6e4010daf01ebad87c0138df0f1243d
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4119754"
---
# <a name="xaml-and-c-troubleshooting-guide"></a><span data-ttu-id="13152-104">XAML と C# のトラブルシューティング ガイド</span><span class="sxs-lookup"><span data-stu-id="13152-104">XAML and C# troubleshooting guide</span></span>

<span data-ttu-id="13152-105">このトピックでは、XAML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策について説明します。</span><span class="sxs-lookup"><span data-stu-id="13152-105">This topic contains solutions to common development issues with the Microsoft advertising libraries in XAML apps.</span></span>

* [<span data-ttu-id="13152-106">XAML</span><span class="sxs-lookup"><span data-stu-id="13152-106">XAML</span></span>](#xaml)
  * [<span data-ttu-id="13152-107">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="13152-107">AdControl not appearing</span></span>](#xaml-notappearing)
  * [<span data-ttu-id="13152-108">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="13152-108">Black box blinks and disappears</span></span>](#xaml-blackboxblinksdisappears)
  * [<span data-ttu-id="13152-109">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="13152-109">Ads not refreshing</span></span>](#xaml-adsnotrefreshing)

* [<span data-ttu-id="13152-110">C#</span><span class="sxs-lookup"><span data-stu-id="13152-110">C#</span></span>](#csharp)
  * [<span data-ttu-id="13152-111">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="13152-111">AdControl not appearing</span></span>](#csharp-adcontrolnotappearing)
  * [<span data-ttu-id="13152-112">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="13152-112">Black box blinks and disappears</span></span>](#csharp-blackboxblinksdisappears)
  * [<span data-ttu-id="13152-113">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="13152-113">Ads not refreshing</span></span>](#csharp-adsnotrefreshing)

<span id="xaml"/>

## <a name="xaml"></a><span data-ttu-id="13152-114">XAML</span><span class="sxs-lookup"><span data-stu-id="13152-114">XAML</span></span>

<span id="xaml-notappearing"/>

### <a name="adcontrol-not-appearing"></a><span data-ttu-id="13152-115">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="13152-115">AdControl not appearing</span></span>

1.  <span data-ttu-id="13152-116">Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-116">Ensure that the **Internet (Client)** capability is selected in Package.appxmanifest.</span></span>

2.  <span data-ttu-id="13152-117">アプリケーション ID と広告ユニット ID を確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-117">Check the application ID and ad unit ID.</span></span> <span data-ttu-id="13152-118">これらの ID は、Windows デベロッパー センターで取得したアプリケーション ID と広告ユニット ID に一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-118">These IDs must match the application ID and ad unit ID that you obtained in Windows Dev Center.</span></span> <span data-ttu-id="13152-119">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="13152-119">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}" ApplicationId="{ApplicationID}"
                  Width="728" Height="90" />
    ```

3.  <span data-ttu-id="13152-120">**Height** プロパティと **Width** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-120">Check the **Height** and **Width** properties.</span></span> <span data-ttu-id="13152-121">これらのプロパティは、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-121">These must be set to one of the [Supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90" />
    ```

4.  <span data-ttu-id="13152-122">要素の配置を確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-122">Check the element position.</span></span> <span data-ttu-id="13152-123">[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) は表示可能領域の内部にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-123">The [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) must be inside the viewable area.</span></span>

5.  <span data-ttu-id="13152-124">**Visibility** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-124">Check the **Visibility** property.</span></span> <span data-ttu-id="13152-125">省略可能な **Visibility** プロパティは collapsed または hidden に設定しないでください。</span><span class="sxs-lookup"><span data-stu-id="13152-125">The optional **Visibility** property must not be set to collapsed or hidden.</span></span> <span data-ttu-id="13152-126">(次のように) インラインで設定できるほか、外部スタイル シートで設定できます。</span><span class="sxs-lookup"><span data-stu-id="13152-126">This property can be set inline (as shown below) or in an external style sheet.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Visibility="Visible"
                  Width="728" Height="90" />
    ```

6.  <span data-ttu-id="13152-127">**AdControl** の親を確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-127">Check the parent of the **AdControl**.</span></span> <span data-ttu-id="13152-128">**AdControl** 要素がある親要素の中にある場合、この親はアクティブで表示されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-128">If the **AdControl** element resides in a parent element, the parent must be active and visible.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <StackPanel>
        <UI:AdControl AdUnitId="{AdUnitID}"
                      ApplicationId="{ApplicationID}"
                      Width="728" Height="90" />
    </StackPanel>
    ```

7.  <span data-ttu-id="13152-129">**AdControl** がビューポートから隠れていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-129">Ensure the **AdControl** is not hidden from the viewport.</span></span> <span data-ttu-id="13152-130">**AdControl** は、広告が正常に表示されるように、見える必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-130">The **AdControl** must be visible for ads to display properly.</span></span>

8.  <span data-ttu-id="13152-131">**ApplicationId** と **AdUnitId** の実際の値は、エミュレーターでのテストに使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="13152-131">Live values for **ApplicationId** and **AdUnitId** should not be tested in the emulator.</span></span> <span data-ttu-id="13152-132">**AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってください。</span><span class="sxs-lookup"><span data-stu-id="13152-132">To ensure the **AdControl** is functioning as expected, use the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for both **ApplicationId** and **AdUnitId**.</span></span>

<span id="xaml-blackboxblinksdisappears"/>

### <a name="black-box-blinks-and-disappears"></a><span data-ttu-id="13152-133">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="13152-133">Black box blinks and disappears</span></span>

1.  <span data-ttu-id="13152-134">前の「[AdControl が表示されない](#xaml-notappearing)」セクションの手順をすべてもう一度確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-134">Double-check all steps in the previous [AdControl not appearing](#xaml-notappearing) section.</span></span>

2.  <span data-ttu-id="13152-135">**ErrorOccurred** イベントを処理します。エラーが発生したかどうかと、発生したエラーの種類を特定するイベント ハンドラーに渡されるメッセージを使います。</span><span class="sxs-lookup"><span data-stu-id="13152-135">Handle the **ErrorOccurred** event, and use the message that is passed to the event handler to determine whether an error occurred and what type of error was thrown.</span></span> <span data-ttu-id="13152-136">詳しくは、「[XAML/C# ウォークスルーでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="13152-136">See [Error handling in XAML/C# walkthrough](error-handling-in-xamlc-walkthrough.md) for more information.</span></span>

    <span data-ttu-id="13152-137">次の例は、**ErrorOccurred**イベント ハンドラーを示しています。</span><span class="sxs-lookup"><span data-stu-id="13152-137">This example demonstrates an **ErrorOccurred** event handler.</span></span> <span data-ttu-id="13152-138">最初のスニペットは、XAML UI マークアップです。</span><span class="sxs-lookup"><span data-stu-id="13152-138">The first snippet is the XAML UI markup.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  ErrorOccurred="adControl_ErrorOccurred" />
    <TextBlock x:Name="TextBlock1" TextWrapping="Wrap" Width="500" Height="250" />
    ```

    <span data-ttu-id="13152-139">次の例は、対応する C# コードを示しています。</span><span class="sxs-lookup"><span data-stu-id="13152-139">This example demonstrates the corresponding C# code.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    private void adControl_ErrorOccurred(object sender,               
        Microsoft.Advertising.WinRT.UI.AdErrorEventArgs e)
    {
        TextBlock1.Text = e.ErrorMessage;
    }
    ```

    <span data-ttu-id="13152-140">ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。</span><span class="sxs-lookup"><span data-stu-id="13152-140">The most common error that causes a black box is “No ad available.”</span></span> <span data-ttu-id="13152-141">このエラーは、要求から復帰する利用可能な広告がないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="13152-141">This error means there is no ad available to return from the request.</span></span>

3.  <span data-ttu-id="13152-142">[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="13152-142">The [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) is behaving normally.</span></span>

    <span data-ttu-id="13152-143">既定では、**AdControl** は広告を表示できない場合に折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="13152-143">By default, the **AdControl** will collapse when it cannot display an ad.</span></span> <span data-ttu-id="13152-144">他の要素が同じ親の子である場合、これらの他の要素は折りたたんだ **AdControl** の隙間を埋めるように移動し、次の要求がなされたときに展開することがあります。</span><span class="sxs-lookup"><span data-stu-id="13152-144">If other elements are children of the same parent they may move to fill the gap of the collapsed **AdControl** and expand when the next request is made.</span></span>

<span id="xaml-adsnotrefreshing"/>

### <a name="ads-not-refreshing"></a><span data-ttu-id="13152-145">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="13152-145">Ads not refreshing</span></span>

1.  <span data-ttu-id="13152-146">[IsAutoRefreshEnabled](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled) プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-146">Check the [IsAutoRefreshEnabled](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled) property.</span></span> <span data-ttu-id="13152-147">既定では、この省略可能なプロパティは **True** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="13152-147">By default, this optional property is set to **True**.</span></span> <span data-ttu-id="13152-148">**False** に設定すると、他の広告を取得するために [Refresh](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.refresh) メソッドを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-148">When set to **False**, the [Refresh](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.refresh) method must be used to retrieve another ad.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  IsAutoRefreshEnabled="True" />
    ```

2.  <span data-ttu-id="13152-149">**Refresh** メソッドの呼び出しを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-149">Check calls to the **Refresh** method.</span></span> <span data-ttu-id="13152-150">自動更新の場合、他の広告を取得するために **Refresh** を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="13152-150">When using automatic refresh, **Refresh** cannot be used to retrieve another ad.</span></span> <span data-ttu-id="13152-151">手動更新の場合、デバイスの現在のデータ接続に応じて、少なくとも 30 秒から 60 秒経ってから **Refresh** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="13152-151">When using manual refresh, **Refresh** should be called only after a minimum of 30 to 60 seconds depending on the device’s current data connection.</span></span>

    <span data-ttu-id="13152-152">次のコード スニペットは、**Refresh** メソッドを使う方法の例を示しています。</span><span class="sxs-lookup"><span data-stu-id="13152-152">The following code snippets show an example of how to use the **Refresh** method.</span></span> <span data-ttu-id="13152-153">最初のスニペットは、XAML UI マークアップです。</span><span class="sxs-lookup"><span data-stu-id="13152-153">The first snippet is the XAML UI markup.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl x:Name="adControl1"
                  AdUnitId="{AdUnit_ID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  IsAutoRefreshEnabled="False" />
    ```

    <span data-ttu-id="13152-154">次のコード スニペットは、C# コード ビハインドの UI マークアップの例を示しています。</span><span class="sxs-lookup"><span data-stu-id="13152-154">This code snippet shows an example of the C# code behind the UI markup.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    public RefreshAds()
    {
        var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(60) };
        timer.Tick += (s, e) => adControl1.Refresh();
        timer.Start();
    }
    ```

3.  <span data-ttu-id="13152-155">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="13152-155">The **AdControl** is behaving normally.</span></span> <span data-ttu-id="13152-156">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="13152-156">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

<span id="csharp"/>

## <a name="c"></a><span data-ttu-id="13152-157">C\#</span><span class="sxs-lookup"><span data-stu-id="13152-157">C\#</span></span> #

<span id="csharp-adcontrolnotappearing"/>

### <a name="adcontrol-not-appearing"></a><span data-ttu-id="13152-158">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="13152-158">AdControl not appearing</span></span>

1.  <span data-ttu-id="13152-159">Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-159">Ensure that the **Internet (Client)** capability is selected in Package.appxmanifest.</span></span>

2.  <span data-ttu-id="13152-160">**AdControl** がインスタンス化されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-160">Ensure the **AdControl** is instantiated.</span></span> <span data-ttu-id="13152-161">**AdControl** がインスタンス化されない場合、利用できません。</span><span class="sxs-lookup"><span data-stu-id="13152-161">If the **AdControl** is not instantiated it will not be available.</span></span>

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[AdControl](./code/AdvertisingSamples/AdControlSamples/cs/MiscellaneousSnippets.cs#Snippet1)]

3.  <span data-ttu-id="13152-162">アプリケーション ID と広告ユニット ID を確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-162">Check the application ID and ad unit ID.</span></span> <span data-ttu-id="13152-163">これらの ID は、Windows デベロッパー センターで取得したアプリケーション ID と広告ユニット ID に一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-163">These IDs must match the application ID and ad unit ID that you obtained in Windows Dev Center.</span></span> <span data-ttu-id="13152-164">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="13152-164">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    ```

4.  <span data-ttu-id="13152-165">**Height** と **Width** パラメーターを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-165">Check the **Height** and **Width** parameters.</span></span> <span data-ttu-id="13152-166">これらのプロパティは、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-166">These must be set to one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;adControl.Width = 728;
    ```

5.  <span data-ttu-id="13152-167">**AdControl** が親要素に追加されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-167">Ensure the **AdControl** is added to a parent element.</span></span> <span data-ttu-id="13152-168">表示するには、**AdControl** を親コントロールの子として追加する必要があります (たとえば、**StackPanel** または **Grid**)。</span><span class="sxs-lookup"><span data-stu-id="13152-168">To display, the **AdControl** must be added as a child to a parent control (for example, a **StackPanel** or **Grid**).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    ContentPanel.Children.Add(adControl);
    ```

6.  <span data-ttu-id="13152-169">**Margin** パラメーターを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-169">Check the **Margin** parameter.</span></span> <span data-ttu-id="13152-170">**AdControl** は表示可能領域の内部にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-170">The **AdControl** must be inside the viewable area.</span></span>

7.  <span data-ttu-id="13152-171">**Visibility** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-171">Check the **Visibility** property.</span></span> <span data-ttu-id="13152-172">省略可能な **Visibility** プロパティを **Visible** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-172">The optional **Visibility** property must be set to **Visible**.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    adControl.Visibility = System.Windows.Visibility.Visible;
    ```

8.  <span data-ttu-id="13152-173">**AdControl** の親を確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-173">Check the parent of the **AdControl**.</span></span> <span data-ttu-id="13152-174">親はアクティブな状態で表示されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-174">The parent must be active and visible.</span></span>

9. <span data-ttu-id="13152-175">**ApplicationId** と **AdUnitId** の実際の値は、エミュレーターでのテストに使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="13152-175">Live values for **ApplicationId** and **AdUnitId** should not be tested in the emulator.</span></span> <span data-ttu-id="13152-176">**AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってください。</span><span class="sxs-lookup"><span data-stu-id="13152-176">To ensure the **AdControl** is functioning as expected, use the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for both **ApplicationId** and **AdUnitId**.</span></span>

<span id="csharp-blackboxblinksdisappears"/>

### <a name="black-box-blinks-and-disappears"></a><span data-ttu-id="13152-177">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="13152-177">Black box blinks and disappears</span></span>

1.  <span data-ttu-id="13152-178">上記の「[AdControl が表示されない](#csharp-adcontrolnotappearing)」セクションの手順をすべてもう一度確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-178">Double-check all steps in the [AdControl not appearing](#csharp-adcontrolnotappearing) section above.</span></span>

2.  <span data-ttu-id="13152-179">**ErrorOccurred** イベントを処理します。エラーが発生したかどうかと、発生したエラーの種類を特定するイベント ハンドラーに渡されるメッセージを使います。</span><span class="sxs-lookup"><span data-stu-id="13152-179">Handle the **ErrorOccurred** event, and use the message that is passed to the event handler to determine whether an error occurred and what type of error was thrown.</span></span> <span data-ttu-id="13152-180">詳しくは、「[XAML/C# ウォークスルーでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="13152-180">See [Error handling in XAML/C# walkthrough](error-handling-in-xamlc-walkthrough.md) for more information.</span></span>

    <span data-ttu-id="13152-181">次の例は、エラー呼び出しの実装に必要な基本的なコードを示しています。</span><span class="sxs-lookup"><span data-stu-id="13152-181">The following examples show the basic code needed to implement an error call.</span></span> <span data-ttu-id="13152-182">この XAML コードは、エラー メッセージの表示に使う **TextBlock** を定義します。</span><span class="sxs-lookup"><span data-stu-id="13152-182">This XAML code defines a **TextBlock** that is used to display the error message.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <TextBlock x:Name="TextBlock1" TextWrapping="Wrap" Width="500" Height="250" />
    ```

    <span data-ttu-id="13152-183">この C# コードは、エラー メッセージを取得し、**TextBlock** に表示します。</span><span class="sxs-lookup"><span data-stu-id="13152-183">This C# code retrieves the error message and displays it in the **TextBlock**.</span></span>

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[AdControl](./code/AdvertisingSamples/AdControlSamples/cs/MiscellaneousSnippets.cs#Snippet2)]

    <span data-ttu-id="13152-184">ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。</span><span class="sxs-lookup"><span data-stu-id="13152-184">The most common error that causes a black box is “No ad available.”</span></span> <span data-ttu-id="13152-185">このエラーは、要求から復帰する利用可能な広告がないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="13152-185">This error means there is no ad available to return from the request.</span></span>

3.  <span data-ttu-id="13152-186">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="13152-186">**AdControl** is behaving normally.</span></span> <span data-ttu-id="13152-187">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="13152-187">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

<span id="csharp-adsnotrefreshing"/>

### <a name="ads-not-refreshing"></a><span data-ttu-id="13152-188">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="13152-188">Ads not refreshing</span></span>

1.  <span data-ttu-id="13152-189">**AdControl** の [IsAutoRefreshEnabled](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) プロパティが false に設定されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-189">Check whether the [IsAutoRefreshEnabled](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) property of your **AdControl** is set to false.</span></span> <span data-ttu-id="13152-190">既定では、この省略可能なプロパティは **true** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="13152-190">By default, this optional property is set to **true**.</span></span> <span data-ttu-id="13152-191">**false** に設定すると、他の広告を取得するために **Refresh** メソッドを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="13152-191">When set to **false**, the **Refresh** method must be used to retrieve another ad.</span></span>

2.  <span data-ttu-id="13152-192">[Refresh](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) メソッドの呼び出しを確認します。</span><span class="sxs-lookup"><span data-stu-id="13152-192">Check calls to the [Refresh](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) method.</span></span> <span data-ttu-id="13152-193">自動更新 (**IsAutoRefreshEnabled** が **true**) の場合、他の広告を取得するために **Refresh** を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="13152-193">When using automatic refresh (**IsAutoRefreshEnabled** is **true**), **Refresh** cannot be used to retrieve another ad.</span></span> <span data-ttu-id="13152-194">手動更新 (**IsAutoRefreshEnabled** が **false**) の場合、デバイスの現在のデータ接続に応じて、少なくとも 30 秒から 60 秒経ってから **Refresh** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="13152-194">When using manual refresh (**IsAutoRefreshEnabled** is **false**), **Refresh** should be called only after a minimum of 30 to 60 seconds depending on the device’s current data connection.</span></span>

    <span data-ttu-id="13152-195">次の例は、**Refresh** メソッドを呼び出す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="13152-195">The following example demonstrates how to call the **Refresh** method.</span></span>

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[AdControl](./code/AdvertisingSamples/AdControlSamples/cs/MiscellaneousSnippets.cs#Snippet3)]

3.  <span data-ttu-id="13152-196">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="13152-196">The **AdControl** is behaving normally.</span></span> <span data-ttu-id="13152-197">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="13152-197">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

 

 
