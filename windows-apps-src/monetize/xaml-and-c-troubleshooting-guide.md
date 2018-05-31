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
ms.openlocfilehash: a971aa26ceab462fedc37ebb7cdba584c55efe93
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1655634"
---
# <a name="xaml-and-c-troubleshooting-guide"></a><span data-ttu-id="3f196-104">XAML と C# のトラブルシューティング ガイド</span><span class="sxs-lookup"><span data-stu-id="3f196-104">XAML and C# troubleshooting guide</span></span>

<span data-ttu-id="3f196-105">このトピックでは、XAML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策について説明します。</span><span class="sxs-lookup"><span data-stu-id="3f196-105">This topic contains solutions to common development issues with the Microsoft advertising libraries in XAML apps.</span></span>

* [<span data-ttu-id="3f196-106">XAML</span><span class="sxs-lookup"><span data-stu-id="3f196-106">XAML</span></span>](#xaml)
  * [<span data-ttu-id="3f196-107">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="3f196-107">AdControl not appearing</span></span>](#xaml-notappearing)
  * [<span data-ttu-id="3f196-108">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="3f196-108">Black box blinks and disappears</span></span>](#xaml-blackboxblinksdisappears)
  * [<span data-ttu-id="3f196-109">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="3f196-109">Ads not refreshing</span></span>](#xaml-adsnotrefreshing)

* [<span data-ttu-id="3f196-110">C#</span><span class="sxs-lookup"><span data-stu-id="3f196-110">C#</span></span>](#csharp)
  * [<span data-ttu-id="3f196-111">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="3f196-111">AdControl not appearing</span></span>](#csharp-adcontrolnotappearing)
  * [<span data-ttu-id="3f196-112">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="3f196-112">Black box blinks and disappears</span></span>](#csharp-blackboxblinksdisappears)
  * [<span data-ttu-id="3f196-113">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="3f196-113">Ads not refreshing</span></span>](#csharp-adsnotrefreshing)

<span id="xaml"/>

## <a name="xaml"></a><span data-ttu-id="3f196-114">XAML</span><span class="sxs-lookup"><span data-stu-id="3f196-114">XAML</span></span>

<span id="xaml-notappearing"/>

### <a name="adcontrol-not-appearing"></a><span data-ttu-id="3f196-115">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="3f196-115">AdControl not appearing</span></span>

1.  <span data-ttu-id="3f196-116">Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-116">Ensure that the **Internet (Client)** capability is selected in Package.appxmanifest.</span></span>

2.  <span data-ttu-id="3f196-117">アプリケーション ID と広告ユニット ID を確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-117">Check the application ID and ad unit ID.</span></span> <span data-ttu-id="3f196-118">これらの ID は、Windows デベロッパー センターで取得したアプリケーション ID と広告ユニット ID に一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-118">These IDs must match the application ID and ad unit ID that you obtained in Windows Dev Center.</span></span> <span data-ttu-id="3f196-119">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f196-119">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}" ApplicationId="{ApplicationID}"
                  Width="728" Height="90" />
    ```

3.  <span data-ttu-id="3f196-120">**Height** プロパティと **Width** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-120">Check the **Height** and **Width** properties.</span></span> <span data-ttu-id="3f196-121">これらのプロパティは、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-121">These must be set to one of the [Supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90" />
    ```

4.  <span data-ttu-id="3f196-122">要素の配置を確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-122">Check the element position.</span></span> <span data-ttu-id="3f196-123">[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) は表示可能領域の内部にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-123">The [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) must be inside the viewable area.</span></span>

5.  <span data-ttu-id="3f196-124">**Visibility** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-124">Check the **Visibility** property.</span></span> <span data-ttu-id="3f196-125">省略可能な **Visibility** プロパティは collapsed または hidden に設定しないでください。</span><span class="sxs-lookup"><span data-stu-id="3f196-125">The optional **Visibility** property must not be set to collapsed or hidden.</span></span> <span data-ttu-id="3f196-126">(次のように) インラインで設定できるほか、外部スタイル シートで設定できます。</span><span class="sxs-lookup"><span data-stu-id="3f196-126">This property can be set inline (as shown below) or in an external style sheet.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Visibility="Visible"
                  Width="728" Height="90" />
    ```

6.  <span data-ttu-id="3f196-127">**IsEnabled** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-127">Check the **IsEnabled** property.</span></span> <span data-ttu-id="3f196-128">省略可能な `IsEnabled` プロパティを `True` に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-128">The optional `IsEnabled` property must be set to `True`.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  IsEnabled="True"
                  Width="728" Height="90" />
    ```

7.  <span data-ttu-id="3f196-129">**AdControl** の親を確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-129">Check the parent of the **AdControl**.</span></span> <span data-ttu-id="3f196-130">**AdControl** 要素がある親要素の中にある場合、この親はアクティブで表示されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-130">If the **AdControl** element resides in a parent element, the parent must be active and visible.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <StackPanel>
        <UI:AdControl AdUnitId="{AdUnitID}"
                      ApplicationId="{ApplicationID}"
                      Width="728" Height="90" />
    </StackPanel>
    ```

8.  <span data-ttu-id="3f196-131">**AdControl** がビューポートから隠れていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-131">Ensure the **AdControl** is not hidden from the viewport.</span></span> <span data-ttu-id="3f196-132">**AdControl** は、広告が正常に表示されるように、見える必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-132">The **AdControl** must be visible for ads to display properly.</span></span>

9.  <span data-ttu-id="3f196-133">**ApplicationId** と **AdUnitId** の実際の値は、エミュレーターでのテストに使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="3f196-133">Live values for **ApplicationId** and **AdUnitId** should not be tested in the emulator.</span></span> <span data-ttu-id="3f196-134">**AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってください。</span><span class="sxs-lookup"><span data-stu-id="3f196-134">To ensure the **AdControl** is functioning as expected, use the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for both **ApplicationId** and **AdUnitId**.</span></span>

<span id="xaml-blackboxblinksdisappears"/>

### <a name="black-box-blinks-and-disappears"></a><span data-ttu-id="3f196-135">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="3f196-135">Black box blinks and disappears</span></span>

1.  <span data-ttu-id="3f196-136">前の「[AdControl が表示されない](#xaml-notappearing)」セクションの手順をすべてもう一度確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-136">Double-check all steps in the previous [AdControl not appearing](#xaml-notappearing) section.</span></span>

2.  <span data-ttu-id="3f196-137">**ErrorOccurred** イベントを処理します。エラーが発生したかどうかと、発生したエラーの種類を特定するイベント ハンドラーに渡されるメッセージを使います。</span><span class="sxs-lookup"><span data-stu-id="3f196-137">Handle the **ErrorOccurred** event, and use the message that is passed to the event handler to determine whether an error occurred and what type of error was thrown.</span></span> <span data-ttu-id="3f196-138">詳しくは、「[XAML/C# ウォークスルーでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f196-138">See [Error handling in XAML/C# walkthrough](error-handling-in-xamlc-walkthrough.md) for more information.</span></span>

    <span data-ttu-id="3f196-139">次の例は、**ErrorOccurred**イベント ハンドラーを示しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-139">This example demonstrates an **ErrorOccurred** event handler.</span></span> <span data-ttu-id="3f196-140">最初のスニペットは、XAML UI マークアップです。</span><span class="sxs-lookup"><span data-stu-id="3f196-140">The first snippet is the XAML UI markup.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  ErrorOccurred="adControl_ErrorOccurred" />
    <TextBlock x:Name="TextBlock1" TextWrapping="Wrap" Width="500" Height="250" />
    ```

    <span data-ttu-id="3f196-141">次の例は、対応する C# コードを示しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-141">This example demonstrates the corresponding C# code.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    private void adControl_ErrorOccurred(object sender,               
        Microsoft.Advertising.WinRT.UI.AdErrorEventArgs e)
    {
        TextBlock1.Text = e.ErrorMessage;
    }
    ```

    <span data-ttu-id="3f196-142">ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。</span><span class="sxs-lookup"><span data-stu-id="3f196-142">The most common error that causes a black box is “No ad available.”</span></span> <span data-ttu-id="3f196-143">このエラーは、要求から復帰する利用可能な広告がないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="3f196-143">This error means there is no ad available to return from the request.</span></span>

3.  <span data-ttu-id="3f196-144">[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-144">The [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) is behaving normally.</span></span>

    <span data-ttu-id="3f196-145">既定では、**AdControl** は広告を表示できない場合に折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="3f196-145">By default, the **AdControl** will collapse when it cannot display an ad.</span></span> <span data-ttu-id="3f196-146">他の要素が同じ親の子である場合、これらの他の要素は折りたたんだ **AdControl** の隙間を埋めるように移動し、次の要求がなされたときに展開することがあります。</span><span class="sxs-lookup"><span data-stu-id="3f196-146">If other elements are children of the same parent they may move to fill the gap of the collapsed **AdControl** and expand when the next request is made.</span></span>

<span id="xaml-adsnotrefreshing"/>

### <a name="ads-not-refreshing"></a><span data-ttu-id="3f196-147">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="3f196-147">Ads not refreshing</span></span>

1.  <span data-ttu-id="3f196-148">[IsAutoRefreshEnabled](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-148">Check the [IsAutoRefreshEnabled](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) property.</span></span> <span data-ttu-id="3f196-149">既定では、この省略可能なプロパティは **True** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="3f196-149">By default, this optional property is set to **True**.</span></span> <span data-ttu-id="3f196-150">**False** に設定すると、他の広告を取得するために [Refresh](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) メソッドを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-150">When set to **False**, the [Refresh](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) method must be used to retrieve another ad.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  IsAutoRefreshEnabled="True" />
    ```

2.  <span data-ttu-id="3f196-151">**Refresh** メソッドの呼び出しを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-151">Check calls to the **Refresh** method.</span></span> <span data-ttu-id="3f196-152">自動更新の場合、他の広告を取得するために **Refresh** を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="3f196-152">When using automatic refresh, **Refresh** cannot be used to retrieve another ad.</span></span> <span data-ttu-id="3f196-153">手動更新の場合、デバイスの現在のデータ接続に応じて、少なくとも 30 秒から 60 秒経ってから **Refresh** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3f196-153">When using manual refresh, **Refresh** should be called only after a minimum of 30 to 60 seconds depending on the device’s current data connection.</span></span>

    <span data-ttu-id="3f196-154">次のコード スニペットは、**Refresh** メソッドを使う方法の例を示しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-154">The following code snippets show an example of how to use the **Refresh** method.</span></span> <span data-ttu-id="3f196-155">最初のスニペットは、XAML UI マークアップです。</span><span class="sxs-lookup"><span data-stu-id="3f196-155">The first snippet is the XAML UI markup.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl x:Name="adControl1"
                  AdUnitId="{AdUnit_ID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  IsAutoRefreshEnabled="False" />
    ```

    <span data-ttu-id="3f196-156">次のコード スニペットは、C# コード ビハインドの UI マークアップの例を示しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-156">This code snippet shows an example of the C# code behind the UI markup.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    public RefreshAds()
    {
        var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(60) };
        timer.Tick += (s, e) => adControl1.Refresh();
        timer.Start();
    }
    ```

3.  <span data-ttu-id="3f196-157">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-157">The **AdControl** is behaving normally.</span></span> <span data-ttu-id="3f196-158">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="3f196-158">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

<span id="csharp"/>

## <a name="c"></a><span data-ttu-id="3f196-159">C\#</span><span class="sxs-lookup"><span data-stu-id="3f196-159">C\#</span></span> #

<span id="csharp-adcontrolnotappearing"/>

### <a name="adcontrol-not-appearing"></a><span data-ttu-id="3f196-160">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="3f196-160">AdControl not appearing</span></span>

1.  <span data-ttu-id="3f196-161">Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-161">Ensure that the **Internet (Client)** capability is selected in Package.appxmanifest.</span></span>

2.  <span data-ttu-id="3f196-162">**AdControl** がインスタンス化されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-162">Ensure the **AdControl** is instantiated.</span></span> <span data-ttu-id="3f196-163">**AdControl** がインスタンス化されない場合、利用できません。</span><span class="sxs-lookup"><span data-stu-id="3f196-163">If the **AdControl** is not instantiated it will not be available.</span></span>

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[AdControl](./code/AdvertisingSamples/AdControlSamples/cs/MiscellaneousSnippets.cs#Snippet1)]

3.  <span data-ttu-id="3f196-164">アプリケーション ID と広告ユニット ID を確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-164">Check the application ID and ad unit ID.</span></span> <span data-ttu-id="3f196-165">これらの ID は、Windows デベロッパー センターで取得したアプリケーション ID と広告ユニット ID に一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-165">These IDs must match the application ID and ad unit ID that you obtained in Windows Dev Center.</span></span> <span data-ttu-id="3f196-166">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f196-166">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    ```

4.  <span data-ttu-id="3f196-167">**Height** と **Width** パラメーターを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-167">Check the **Height** and **Width** parameters.</span></span> <span data-ttu-id="3f196-168">これらのプロパティは、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-168">These must be set to one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;adControl.Width = 728;
    ```

5.  <span data-ttu-id="3f196-169">**AdControl** が親要素に追加されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-169">Ensure the **AdControl** is added to a parent element.</span></span> <span data-ttu-id="3f196-170">表示するには、**AdControl** を親コントロールの子として追加する必要があります (たとえば、**StackPanel** または **Grid**)。</span><span class="sxs-lookup"><span data-stu-id="3f196-170">To display, the **AdControl** must be added as a child to a parent control (for example, a **StackPanel** or **Grid**).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    ContentPanel.Children.Add(adControl);
    ```

6.  <span data-ttu-id="3f196-171">**Margin** パラメーターを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-171">Check the **Margin** parameter.</span></span> <span data-ttu-id="3f196-172">**AdControl** は表示可能領域の内部にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-172">The **AdControl** must be inside the viewable area.</span></span>

7.  <span data-ttu-id="3f196-173">**Visibility** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-173">Check the **Visibility** property.</span></span> <span data-ttu-id="3f196-174">省略可能な **Visibility** プロパティを **Visible** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-174">The optional **Visibility** property must be set to **Visible**.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    adControl.Visibility = System.Windows.Visibility.Visible;
    ```

8.  <span data-ttu-id="3f196-175">**IsEnabled** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-175">Check the **IsEnabled** property.</span></span> <span data-ttu-id="3f196-176">省略可能な **IsEnabled** プロパティを **True** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-176">The optional **IsEnabled** property must be set to **True**.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` cs
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    adControl.IsEnabled = True;
    ```

9.  <span data-ttu-id="3f196-177">**AdControl** の親を確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-177">Check the parent of the **AdControl**.</span></span> <span data-ttu-id="3f196-178">親はアクティブな状態で表示されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-178">The parent must be active and visible.</span></span>

10. <span data-ttu-id="3f196-179">**ApplicationId** と **AdUnitId** の実際の値は、エミュレーターでのテストに使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="3f196-179">Live values for **ApplicationId** and **AdUnitId** should not be tested in the emulator.</span></span> <span data-ttu-id="3f196-180">**AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってください。</span><span class="sxs-lookup"><span data-stu-id="3f196-180">To ensure the **AdControl** is functioning as expected, use the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for both **ApplicationId** and **AdUnitId**.</span></span>

<span id="csharp-blackboxblinksdisappears"/>

### <a name="black-box-blinks-and-disappears"></a><span data-ttu-id="3f196-181">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="3f196-181">Black box blinks and disappears</span></span>

1.  <span data-ttu-id="3f196-182">上記の「[AdControl が表示されない](#csharp-adcontrolnotappearing)」セクションの手順をすべてもう一度確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-182">Double-check all steps in the [AdControl not appearing](#csharp-adcontrolnotappearing) section above.</span></span>

2.  <span data-ttu-id="3f196-183">**ErrorOccurred** イベントを処理します。エラーが発生したかどうかと、発生したエラーの種類を特定するイベント ハンドラーに渡されるメッセージを使います。</span><span class="sxs-lookup"><span data-stu-id="3f196-183">Handle the **ErrorOccurred** event, and use the message that is passed to the event handler to determine whether an error occurred and what type of error was thrown.</span></span> <span data-ttu-id="3f196-184">詳しくは、「[XAML/C# ウォークスルーでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f196-184">See [Error handling in XAML/C# walkthrough](error-handling-in-xamlc-walkthrough.md) for more information.</span></span>

    <span data-ttu-id="3f196-185">次の例は、エラー呼び出しの実装に必要な基本的なコードを示しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-185">The following examples show the basic code needed to implement an error call.</span></span> <span data-ttu-id="3f196-186">この XAML コードは、エラー メッセージの表示に使う **TextBlock** を定義します。</span><span class="sxs-lookup"><span data-stu-id="3f196-186">This XAML code defines a **TextBlock** that is used to display the error message.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <TextBlock x:Name="TextBlock1" TextWrapping="Wrap" Width="500" Height="250" />
    ```

    <span data-ttu-id="3f196-187">この C# コードは、エラー メッセージを取得し、**TextBlock** に表示します。</span><span class="sxs-lookup"><span data-stu-id="3f196-187">This C# code retrieves the error message and displays it in the **TextBlock**.</span></span>

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[AdControl](./code/AdvertisingSamples/AdControlSamples/cs/MiscellaneousSnippets.cs#Snippet2)]

    <span data-ttu-id="3f196-188">ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。</span><span class="sxs-lookup"><span data-stu-id="3f196-188">The most common error that causes a black box is “No ad available.”</span></span> <span data-ttu-id="3f196-189">このエラーは、要求から復帰する利用可能な広告がないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="3f196-189">This error means there is no ad available to return from the request.</span></span>

3.  <span data-ttu-id="3f196-190">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-190">**AdControl** is behaving normally.</span></span> <span data-ttu-id="3f196-191">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="3f196-191">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

<span id="csharp-adsnotrefreshing"/>

### <a name="ads-not-refreshing"></a><span data-ttu-id="3f196-192">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="3f196-192">Ads not refreshing</span></span>

1.  <span data-ttu-id="3f196-193">**AdControl** の [IsAutoRefreshEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) プロパティが false に設定されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-193">Check whether the [IsAutoRefreshEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) property of your **AdControl** is set to false.</span></span> <span data-ttu-id="3f196-194">既定では、この省略可能なプロパティは **true** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="3f196-194">By default, this optional property is set to **true**.</span></span> <span data-ttu-id="3f196-195">**false** に設定すると、他の広告を取得するために **Refresh** メソッドを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f196-195">When set to **false**, the **Refresh** method must be used to retrieve another ad.</span></span>

2.  <span data-ttu-id="3f196-196">[Refresh](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) メソッドの呼び出しを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f196-196">Check calls to the [Refresh](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) method.</span></span> <span data-ttu-id="3f196-197">自動更新 (**IsAutoRefreshEnabled** が **true**) の場合、他の広告を取得するために **Refresh** を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="3f196-197">When using automatic refresh (**IsAutoRefreshEnabled** is **true**), **Refresh** cannot be used to retrieve another ad.</span></span> <span data-ttu-id="3f196-198">手動更新 (**IsAutoRefreshEnabled** が **false**) の場合、デバイスの現在のデータ接続に応じて、少なくとも 30 秒から 60 秒経ってから **Refresh** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3f196-198">When using manual refresh (**IsAutoRefreshEnabled** is **false**), **Refresh** should be called only after a minimum of 30 to 60 seconds depending on the device’s current data connection.</span></span>

    <span data-ttu-id="3f196-199">次の例は、**Refresh** メソッドを呼び出す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-199">The following example demonstrates how to call the **Refresh** method.</span></span>

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[AdControl](./code/AdvertisingSamples/AdControlSamples/cs/MiscellaneousSnippets.cs#Snippet3)]

3.  <span data-ttu-id="3f196-200">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="3f196-200">The **AdControl** is behaving normally.</span></span> <span data-ttu-id="3f196-201">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="3f196-201">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

 

 
