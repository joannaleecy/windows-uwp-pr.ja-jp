---
author: normesta
Description: Extend your desktop application with Windows UIs and components
Search.Product: eADQiWindows 10XVcnh
title: Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張
ms.author: normesta
ms.date: 06/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: bed06d5f9f43acd5aa4ec5ff7b2b7139ad0dd26f
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4414842"
---
# <a name="extend-your-desktop-application-with-modern-uwp-components"></a><span data-ttu-id="e50f5-103">最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張</span><span class="sxs-lookup"><span data-stu-id="e50f5-103">Extend your desktop application with modern UWP components</span></span>

<span data-ttu-id="e50f5-104">一部の Windows 10 エクスペリエンス (タッチ対応 UI ページなど) は、最新のアプリ コンテナー内で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e50f5-104">Some Windows 10 experiences (For example: a touch-enabled UI page) must run inside of a modern app container .</span></span> <span data-ttu-id="e50f5-105">こうしたエクスペリエンスを追加するには、UWP プロジェクトと Windows ランタイム コンポーネントを使ってデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-105">If you want to add these experiences, extend your desktop application with UWP projects and Windows Runtime Components.</span></span>

<span data-ttu-id="e50f5-106">多くの場合、デスクトップ アプリケーションから UWP API を直接呼び出すことができます。そのため、このガイドを確認する前に、「[Windows 10 のための拡張](desktop-to-uwp-enhance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-106">In many cases you can call UWP APIs directly from your desktop application, so before you review this guide, see [Enhance for Windows 10](desktop-to-uwp-enhance.md).</span></span>

>[!NOTE]
><span data-ttu-id="e50f5-107">このガイドでは、デスクトップ アプリケーションの Windows アプリ パッケージを作成したことを前提としています。</span><span class="sxs-lookup"><span data-stu-id="e50f5-107">This guide assumes that you've created a Windows app package for your desktop application.</span></span> <span data-ttu-id="e50f5-108">いないまだ行っていない場合、[デスクトップ アプリケーションのパッケージ](desktop-to-uwp-root.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-108">If you haven't yet done this, see [Package desktop applications](desktop-to-uwp-root.md).</span></span>

<span data-ttu-id="e50f5-109">準備ができたら始めましょう。</span><span class="sxs-lookup"><span data-stu-id="e50f5-109">If you're ready, let's start.</span></span>

<a id="setup" />

## <a name="first-setup-your-solution"></a><span data-ttu-id="e50f5-110">まず、ソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="e50f5-110">First, setup your Solution</span></span>

<span data-ttu-id="e50f5-111">UWP プロジェクトとランタイム コンポーネントを 1 つ以上ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-111">Add one or more UWP projects and runtime components to your solution.</span></span>

<span data-ttu-id="e50f5-112">**Windows アプリケーション パッケージ プロジェクト**とデスクトップ アプリケーションへの参照が含まれるソリューションから始めます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-112">Start with a solution that contains a **Windows Application Packaging Project** with a reference to your desktop application.</span></span>

<span data-ttu-id="e50f5-113">次の画像は、ソリューションの例を示しています。</span><span class="sxs-lookup"><span data-stu-id="e50f5-113">This image shows an example solution.</span></span>

![開始プロジェクトを拡張する](images/desktop-to-uwp/extend-start-project.png)

<span data-ttu-id="e50f5-115">ソリューションにパッケージ プロジェクトがない場合は、 [Visual Studio を使ってデスクトップ アプリケーションのパッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-115">If your solution doesn't contain a packaging project, see [Package your desktop application by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

### <a name="add-a-uwp-project"></a><span data-ttu-id="e50f5-116">UWP プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="e50f5-116">Add a UWP project</span></span>

<span data-ttu-id="e50f5-117">ソリューションに **[空白のアプリ (ユニバーサル Windows)]** を追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-117">Add a **Blank App (Universal Windows)** to your solution.</span></span>

<span data-ttu-id="e50f5-118">ここでは、最新の XAML UI をビルドするか、UWP プロセス内でのみ実行される API を使います。</span><span class="sxs-lookup"><span data-stu-id="e50f5-118">This is where you'll build a modern XAML UI or use APIs that run only within a UWP process.</span></span>

![UWP プロジェクト](images/desktop-to-uwp/add-uwp-project-to-solution.png)

<span data-ttu-id="e50f5-120">パッケージ プロジェクトで、**[アプリケーション]** ノードを右クリックして **[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e50f5-120">In your packaging project, right-click the **Applications** node, and then click **Add Reference**.</span></span>

![UWP プロジェクトを参照する](images/desktop-to-uwp/add-uwp-project-reference.png)

<span data-ttu-id="e50f5-122">次に、UWP プロジェクトに参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-122">Then, add a reference the UWP project.</span></span>

![UWP プロジェクトを参照する](images/desktop-to-uwp/choose-uwp-project.png)

<span data-ttu-id="e50f5-124">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e50f5-124">Your solution will look something like this:</span></span>

![UWP プロジェクトのあるソリューション](images/desktop-to-uwp/uwp-project-reference.png)

### <a name="optional-add-a-windows-runtime-component"></a><span data-ttu-id="e50f5-126">(省略可能) Windows ランタイム コンポーネントを追加する</span><span class="sxs-lookup"><span data-stu-id="e50f5-126">(Optional) Add a Windows Runtime Component</span></span>

<span data-ttu-id="e50f5-127">いくつかのシナリオでは、Windows ランタイム コンポーネントにコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e50f5-127">To accomplish some scenarios, you'll have to add code to a Windows Runtime Component.</span></span>

![ランタイム コンポーネントのアプリ サービス](images/desktop-to-uwp/add-runtime-component.png)

<span data-ttu-id="e50f5-129">次に、UWP プロジェクトからランタイム コンポーネントに参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-129">Then, from your UWP project, add a reference to the runtime component.</span></span> <span data-ttu-id="e50f5-130">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e50f5-130">Your solution will look something like this:</span></span>

![ランタイム コンポーネント参照](images/desktop-to-uwp/runtime-component-reference.png)

<span data-ttu-id="e50f5-132">UWP プロジェクトとランタイム コンポーネントで行うことができる操作をいくつか見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="e50f5-132">Let's take a look at a few things you can do with your UWP projects and runtime components.</span></span>

## <a name="show-a-modern-xaml-ui"></a><span data-ttu-id="e50f5-133">最新の XAML UI を表示する</span><span class="sxs-lookup"><span data-stu-id="e50f5-133">Show a modern XAML UI</span></span>

<span data-ttu-id="e50f5-134">アプリケーション フローの一環として、最新の XAML ベースのユーザー インターフェイスをデスクトップ アプリケーションに組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-134">As part of your application flow, you can incorporate modern XAML-based user interfaces into your desktop application.</span></span> <span data-ttu-id="e50f5-135">これらのユーザー インターフェイスは、さまざまな画面サイズと解像度に適応し、タッチや手描きなどの最新の対話モデルをサポートする性質を備えています。</span><span class="sxs-lookup"><span data-stu-id="e50f5-135">These user interfaces are naturally adaptive to different screen sizes and resolutions and support modern interactive models such as touch and ink.</span></span>

<span data-ttu-id="e50f5-136">たとえば、少量の XAML マークアップを使用して、地図関連の強力な視覚化機能をユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-136">For example, with a small amount of XAML markup, you can give users with powerful map-related visualization features.</span></span>

<span data-ttu-id="e50f5-137">次の画像に、マップ コントロールを含む XAML ベースの最新の UI を表示している Windows フォーム アプリケーションを示しています。</span><span class="sxs-lookup"><span data-stu-id="e50f5-137">This image shows a Windows Forms application that opens a XAML-based modern UI that contains a map control.</span></span>

![アダプティブ デザイン](images/desktop-to-uwp/extend-xaml-ui.png)

>[!NOTE]
><span data-ttu-id="e50f5-139">この例では、UWP プロジェクトをソリューションに追加することで、XAML UI を示しています。</span><span class="sxs-lookup"><span data-stu-id="e50f5-139">This example shows a XAML UI by adding a UWP project to the solution.</span></span> <span data-ttu-id="e50f5-140">デスクトップ アプリケーションでの XAML Ui を表示する安定したサポートされているアプローチです。</span><span class="sxs-lookup"><span data-stu-id="e50f5-140">That is the stable supported approach to showing XAML UIs in a desktop application.</span></span> <span data-ttu-id="e50f5-141">このアプローチを代わりに、XAML 島を使用して、デスクトップ アプリケーションに直接 UWP XAML コントロールを追加することです。</span><span class="sxs-lookup"><span data-stu-id="e50f5-141">The alternative to this approach is to add UWP XAML controls directly to your desktop application by using a XAML Island.</span></span> <span data-ttu-id="e50f5-142">XAML 諸島現在利用可能な開発者プレビューとしてします。</span><span class="sxs-lookup"><span data-stu-id="e50f5-142">XAML Islands are currently available as a developer preview.</span></span> <span data-ttu-id="e50f5-143">それらプロトタイプ コードで今すぐ試すをお勧めしますがない使用することに運用コードでこの時点でお勧めしますしないでください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-143">Although we encourage you to try them out in your own prototype code now, we do not recommend that you use them in production code at this time.</span></span> <span data-ttu-id="e50f5-144">これらの Api とコントロールは引き続き成熟し、今後の Windows のリリースを安定させます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-144">These APIs and controls will continue to mature and stabilize in future Windows releases.</span></span> <span data-ttu-id="e50f5-145">XAML 諸島について詳しくは、[デスクトップ アプリケーションで UWP コントロール](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-145">To learn more about XAML Islands, see [UWP controls in desktop applications](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="e50f5-146">設計パターン</span><span class="sxs-lookup"><span data-stu-id="e50f5-146">The design pattern</span></span>

<span data-ttu-id="e50f5-147">XAML ベースの UI を表示するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-147">To show a XAML-based UI, do these things:</span></span>

<span data-ttu-id="e50f5-148">1: [ソリューションをセットアップする](#solution-setup)</span><span class="sxs-lookup"><span data-stu-id="e50f5-148">:one: [Setup your Solution](#solution-setup)</span></span>

<span data-ttu-id="e50f5-149">2: [XAML UI を作成する](#xaml-UI)</span><span class="sxs-lookup"><span data-stu-id="e50f5-149">:two: [Create a XAML UI](#xaml-UI)</span></span>

<span data-ttu-id="e50f5-150">3: [プロトコル拡張機能を UWP プロジェクトに追加する](#protocol)</span><span class="sxs-lookup"><span data-stu-id="e50f5-150">:three: [Add a protocol extension to the UWP project](#protocol)</span></span>

<span data-ttu-id="e50f5-151">4: [デスクトップ アプリから UWP アプリを起動する](#start)</span><span class="sxs-lookup"><span data-stu-id="e50f5-151">:four: [Start the UWP app from your desktop app](#start)</span></span>

<span data-ttu-id="e50f5-152">5: [UWP プロジェクトで目的のページを表示する](#parse)</span><span class="sxs-lookup"><span data-stu-id="e50f5-152">:five: [In the UWP project, show the page that you want](#parse)</span></span>

<a id="solution-setup" />

### <a name="setup-your-solution"></a><span data-ttu-id="e50f5-153">ソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="e50f5-153">Setup your Solution</span></span>

<span data-ttu-id="e50f5-154">ソリューションのセットアップ方法に関する一般的なガイダンスについては、このガイドの冒頭の「[まず、ソリューションをセットアップする](#setup)」セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-154">For general guidance on how to set your solution up, see the [First, setup your Solution](#setup) section at the beginning of this guide.</span></span>

<span data-ttu-id="e50f5-155">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e50f5-155">Your solution would look something like this:</span></span>

![XAML UI ソリューション](images/desktop-to-uwp/xaml-ui-solution.png)

<span data-ttu-id="e50f5-157">この例では、Windows フォーム プロジェクトは **Landmarks** という名前で、XAML UI を含む UWP プロジェクトは **MapUI** という名前です。</span><span class="sxs-lookup"><span data-stu-id="e50f5-157">In this example, the Windows Forms project is named **Landmarks** and the UWP project that contains the XAML UI is named **MapUI**.</span></span>

<a id="xaml-UI" />

### <a name="create-a-xaml-ui"></a><span data-ttu-id="e50f5-158">XAML UI の作成</span><span class="sxs-lookup"><span data-stu-id="e50f5-158">Create a XAML UI</span></span>

<span data-ttu-id="e50f5-159">XAML UI を UWP プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-159">Add a XAML UI to your UWP project.</span></span> <span data-ttu-id="e50f5-160">基本的なマップの XAML を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-160">Here's the XAML for a basic map.</span></span>

```xml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" Margin="12,20,12,14">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    <maps:MapControl x:Name="myMap" Grid.Column="0" Width="500" Height="500"
                     ZoomLevel="{Binding ElementName=zoomSlider,Path=Value, Mode=TwoWay}"
                     Heading="{Binding ElementName=headingSlider,Path=Value, Mode=TwoWay}"
                     DesiredPitch="{Binding ElementName=desiredPitchSlider,Path=Value, Mode=TwoWay}"    
                     HorizontalAlignment="Left"               
                     MapServiceToken="<Your Key Goes Here" />
    <Grid Grid.Column="1" Margin="12">
        <StackPanel>
            <Slider Minimum="1" Maximum="20" Header="ZoomLevel" Name="zoomSlider" Value="17.5"/>
            <Slider Minimum="0" Maximum="360" Header="Heading" Name="headingSlider" Value="0"/>
            <Slider Minimum="0" Maximum="64" Header=" DesiredPitch" Name="desiredPitchSlider" Value="32"/>
        </StackPanel>
    </Grid>
</Grid>
```

### <a name="add-a-protocol-extension"></a><span data-ttu-id="e50f5-161">プロトコル拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="e50f5-161">Add a protocol extension</span></span>

<span data-ttu-id="e50f5-162">**ソリューション エクスプ ローラー**で、ソリューションにパッケージ プロジェクトの**package.appxmanifest**ファイルを開くし、この拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-162">In **Solution Explorer**, open the **package.appxmanifest** file of the Packaging project in your solution, and add this extension.</span></span>

```xml
<Extensions>
  <uap:Extension Category="windows.protocol" Executable="MapUI.exe" EntryPoint="MapUI.App">
    <uap:Protocol Name="xamluidemo" />
  </uap:Extension>
</Extensions>    
```

<span data-ttu-id="e50f5-163">プロトコルに名前を付けて、UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-163">Give the protocol a name, provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span>

<span data-ttu-id="e50f5-164">デザイナーで **package.appxmanifest** 開き、**[宣言]** タブを選んで、そこで拡張機能を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-164">You can also open the **package.appxmanifest** in the designer, choose the **Declarations** tab, and then add the extension there.</span></span>

![[宣言] タブ](images/desktop-to-uwp/protocol-properties.png)

> [!NOTE]
> <span data-ttu-id="e50f5-166">マップ コントロールはインターネットからデータをダウンロードします。そのため、マップ コントロールを使用する場合は、"インターネット クライアント" 機能もマニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e50f5-166">Map controls download data from the internet so if you use one, you'll have to add the "internet client" capability to your manifest as well.</span></span>

<a id="start" />

### <a name="start-the-uwp-app"></a><span data-ttu-id="e50f5-167">UWP アプリを起動する</span><span class="sxs-lookup"><span data-stu-id="e50f5-167">Start the UWP app</span></span>

<span data-ttu-id="e50f5-168">まず、デスクトップ アプリケーションから、プロトコル名と UWP アプリに渡すパラメーターが含まれた [URI](https://msdn.microsoft.com/library/system.uri.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-168">First, from your desktop application, create a [Uri](https://msdn.microsoft.com/library/system.uri.aspx) that includes the protocol name and any parameters you want to pass into the UWP app.</span></span> <span data-ttu-id="e50f5-169">次に、[LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-169">Then, call the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) method.</span></span>

```csharp

private void Statue_Of_Liberty_Click(object sender, EventArgs e)
{
    ShowMap(40.689247, -74.044502);
}

private async void ShowMap(double lat, double lon)
{
    string str = "xamluidemo://";

    Uri uri = new Uri(str + "location?lat=" +
        lat.ToString() + "&?lon=" + lon.ToString());

    var success = await Windows.System.Launcher.LaunchUriAsync(uri);

}
```

<a id="parse" />

### <a name="parse-parameters-and-show-a-page"></a><span data-ttu-id="e50f5-170">パラメーターを解析してページを表示する</span><span class="sxs-lookup"><span data-stu-id="e50f5-170">Parse parameters and show a page</span></span>

<span data-ttu-id="e50f5-171">UWP プロジェクトの **App** クラスで、**OnActivated** イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="e50f5-171">In the **App** class of your UWP project, override the **OnActivated** event handler.</span></span> <span data-ttu-id="e50f5-172">アプリがプロトコルによってアクティブ化されている場合は、パラメーターを解析して目的のページを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-172">If the app is activated by your protocol, parse the parameters and then open the page that you want.</span></span>

```csharp
protected override void OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs e)
{
    if (e.Kind == ActivationKind.Protocol)
    {
        ProtocolActivatedEventArgs protocolArgs = (ProtocolActivatedEventArgs)e;
        Uri uri = protocolArgs.Uri;
        if (uri.Scheme == "xamluidemo")
        {
            Frame rootFrame = new Frame();
            Window.Current.Content = rootFrame;
            rootFrame.Navigate(typeof(MainPage), uri.Query);
            Window.Current.Activate();
        }
    }
}
```

<span data-ttu-id="e50f5-173">``OnNavigatedTo`` メソッドを上書きして、ページに渡されるパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-173">Override the ``OnNavigatedTo`` method to use the parameters passed into the page.</span></span> <span data-ttu-id="e50f5-174">この場合、このページに渡された緯度と経度を使用してマップに場所を表示します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-174">In this case, we'll use the latitude and longitude that were passed into this page to show a location in a map.</span></span>

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
 {
     if (e.Parameter != null)
     {
         WwwFormUrlDecoder decoder = new WwwFormUrlDecoder(e.Parameter.ToString());

         double lat = Convert.ToDouble(decoder[0].Value);
         double lon = Convert.ToDouble(decoder[1].Value);

         BasicGeoposition pos = new BasicGeoposition();

         pos.Latitude = lat;
         pos.Longitude = lon;

         myMap.Center = new Geopoint(pos);

         myMap.Style = MapStyle.Aerial3D;

     }

     base.OnNavigatedTo(e);
 }
```

### <a name="similar-samples"></a><span data-ttu-id="e50f5-175">類似のサンプル</span><span class="sxs-lookup"><span data-stu-id="e50f5-175">Similar Samples</span></span>

[<span data-ttu-id="e50f5-176">VB6 アプリケーションへの UWP XAML ユーザー エクスペリエンスの追加</span><span class="sxs-lookup"><span data-stu-id="e50f5-176">Adding a UWP XAML user experience to VB6 Application</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/VB6withXaml)

[<span data-ttu-id="e50f5-177">Northwind サンプル: UWA UI および Win32 レガシ コードのエンド ツー エンドの例</span><span class="sxs-lookup"><span data-stu-id="e50f5-177">Northwind sample: End-to-end example for UWA UI & Win32 legacy code</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/NorthwindSample)

[<span data-ttu-id="e50f5-178">Northwind サンプル: SQL Server に接続する UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="e50f5-178">Northwind sample: UWP app connecting to SQL Server</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SQLServer)

## <a name="provide-services-to-other-apps"></a><span data-ttu-id="e50f5-179">サービスを他のアプリに提供する</span><span class="sxs-lookup"><span data-stu-id="e50f5-179">Provide services to other apps</span></span>

<span data-ttu-id="e50f5-180">他のアプリで利用できるサービスを追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-180">You add a service that other apps can consume.</span></span> <span data-ttu-id="e50f5-181">たとえば、アプリの背後でデータベースが実行されている場合に、そのデータベースへの制御されたアクセスを他のアプリに提供するサービスを追加できます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-181">For example, you can add a service that gives other apps controlled access to the database behind your app.</span></span> <span data-ttu-id="e50f5-182">バック グラウンド タスクを実装すると、アプリ サービスに到達可能、デスクトップ アプリケーションが実行されていない場合でもします。</span><span class="sxs-lookup"><span data-stu-id="e50f5-182">By implementing a background task, apps can reach the service even if your desktop application is not running.</span></span>

<span data-ttu-id="e50f5-183">これを実行するサンプルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-183">Here's a sample that does this.</span></span>

![アダプティブ デザイン](images/desktop-to-uwp/winforms-app-service.png)

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="e50f5-185">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="e50f5-185">Have a closer look at this app</span></span>

<span data-ttu-id="e50f5-186">:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/winforms-appservice/9p7d9b6nk5tn)</span><span class="sxs-lookup"><span data-stu-id="e50f5-186">:heavy_check_mark: [Get the app](https://www.microsoft.com/en-us/store/p/winforms-appservice/9p7d9b6nk5tn)</span></span>

<span data-ttu-id="e50f5-187">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinformsAppService)</span><span class="sxs-lookup"><span data-stu-id="e50f5-187">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinformsAppService)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="e50f5-188">設計パターン</span><span class="sxs-lookup"><span data-stu-id="e50f5-188">The design pattern</span></span>

<span data-ttu-id="e50f5-189">サービスの提供を示すには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-189">To show provide a service, do these things:</span></span>

<span data-ttu-id="e50f5-190">:1: [アプリ サービスを実装する](#appservice)</span><span class="sxs-lookup"><span data-stu-id="e50f5-190">:one: [Implement the app service](#appservice)</span></span>

<span data-ttu-id="e50f5-191">:2: [アプリ サービスの拡張機能を追加する](#extension)</span><span class="sxs-lookup"><span data-stu-id="e50f5-191">:two: [Add an app service extension](#extension)</span></span>

<span data-ttu-id="e50f5-192">:3: [アプリ サービスをテストする](#test)</span><span class="sxs-lookup"><span data-stu-id="e50f5-192">:three: [Test the app service](#test)</span></span>

<a id="appservice" />

### <a name="implement-the-app-service"></a><span data-ttu-id="e50f5-193">アプリ サービスを実装する</span><span class="sxs-lookup"><span data-stu-id="e50f5-193">Implement the app service</span></span>

<span data-ttu-id="e50f5-194">以下では、他のアプリからの要求を検証して処理します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-194">Here's where you'll validate and handle requests from other apps.</span></span> <span data-ttu-id="e50f5-195">ソリューションで Windows ランタイム コンポーネントにこのコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-195">Add this code to a Windows Runtime Component in your solution.</span></span>

```csharp
public sealed class AppServiceTask : IBackgroundTask
{
    private BackgroundTaskDeferral backgroundTaskDeferral;
 
    public void Run(IBackgroundTaskInstance taskInstance)
    {
        this.backgroundTaskDeferral = taskInstance.GetDeferral();
        taskInstance.Canceled += OnTaskCanceled;
        var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
        details.AppServiceConnection.RequestReceived += OnRequestReceived;
    }
 
    private async void OnRequestReceived(AppServiceConnection sender,
                                         AppServiceRequestReceivedEventArgs args)
    {
        var messageDeferral = args.GetDeferral();
        ValueSet message = args.Request.Message;
        string id = message["ID"] as string;
        ValueSet returnData = DataBase.GetData(id);
        await args.Request.SendResponseAsync(returnData);
        messageDeferral.Complete();
    }
 
 
    private void OnTaskCanceled(IBackgroundTaskInstance sender,
                                BackgroundTaskCancellationReason reason)
    {
        if (this.backgroundTaskDeferral != null)
        {
            this.backgroundTaskDeferral.Complete();
        }
    }
}
```

<a id="extension" />

### <a name="add-an-app-service-extension-to-the-packaging-project"></a><span data-ttu-id="e50f5-196">アプリ サービスの拡張機能をパッケージ プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-196">Add an app service extension to the Packaging project</span></span>

<span data-ttu-id="e50f5-197">パッケージ プロジェクトの**package.appxmanifest**ファイルを開くし、アプリ サービスの拡張機能を追加、``<Application>``要素です。</span><span class="sxs-lookup"><span data-stu-id="e50f5-197">Open the **package.appxmanifest** file of the Packaging project, and add an app service extension to the ``<Application>`` element.</span></span>

```xml
<Extensions>
      <uap:Extension
          Category="windows.appService"
          EntryPoint="AppServiceComponent.AppServiceTask">
        <uap:AppService Name="com.microsoft.samples.winforms" />
      </uap:Extension>
    </Extensions>    
```
<span data-ttu-id="e50f5-198">そのアプリ サービスに名前を付けて、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-198">Give the app service a name and provide the name of the entry point class.</span></span> <span data-ttu-id="e50f5-199">これは、サービスを実装したクラスです。</span><span class="sxs-lookup"><span data-stu-id="e50f5-199">This is the class in which you implemented the service.</span></span>

<a id="test" />

### <a name="test-the-app-service"></a><span data-ttu-id="e50f5-200">アプリ サービスをテストする</span><span class="sxs-lookup"><span data-stu-id="e50f5-200">Test the app service</span></span>

<span data-ttu-id="e50f5-201">別のアプリからサービスを呼び出すことにより、サービスをテストします。</span><span class="sxs-lookup"><span data-stu-id="e50f5-201">Test your service by calling it from another app.</span></span> <span data-ttu-id="e50f5-202">このコードは、Windows フォーム アプリケーションまたは別の UWP アプリなどのデスクトップ アプリケーションにすることができます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-202">This code can be a desktop application such as a Windows forms application or another UWP app.</span></span>

> [!NOTE]
> <span data-ttu-id="e50f5-203">このコードは、``AppServiceConnection`` クラスの ``PackageFamilyName`` プロパティを適切に設定した場合のみ動作します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-203">This code only works if you properly set the ``PackageFamilyName`` property of the ``AppServiceConnection`` class.</span></span> <span data-ttu-id="e50f5-204">その名前を取得するには、UWP プロジェクトで ``Windows.ApplicationModel.Package.Current.Id.FamilyName`` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-204">You can get that name by calling ``Windows.ApplicationModel.Package.Current.Id.FamilyName`` in the context of the UWP project.</span></span> <span data-ttu-id="e50f5-205">「[App Service の作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-205">See [Create and consume an app service](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service).</span></span>

```csharp
private async void button_Click(object sender, RoutedEventArgs e)
{
    AppServiceConnection dataService = new AppServiceConnection();
    dataService.AppServiceName = "com.microsoft.samples.winforms";
    dataService.PackageFamilyName = "Microsoft.SDKSamples.WinformWithAppService";
 
    var status = await dataService.OpenAsync();
    if (status == AppServiceConnectionStatus.Success)
    {
        string id = int.Parse(textBox.Text);
        var message = new ValueSet();
        message.Add("ID", id);
        AppServiceResponse response = await dataService.SendMessageAsync(message);
 
        if (response.Status == AppServiceResponseStatus.Success)
        {
            if (response.Message["Status"] as string == "OK")
            {
                DisplayResult(response.Message["Result"]);
            }
        }
    }
}
```

<span data-ttu-id="e50f5-206">アプリ サービスについて詳しくは、「[アプリ サービスの作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-206">Learn more about app services here: [Create and consume an app service](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service).</span></span>

### <a name="similar-samples"></a><span data-ttu-id="e50f5-207">類似のサンプル</span><span class="sxs-lookup"><span data-stu-id="e50f5-207">Similar Samples</span></span>

[<span data-ttu-id="e50f5-208">アプリ サービス ブリッジのサンプル</span><span class="sxs-lookup"><span data-stu-id="e50f5-208">App service bridge sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/AppServiceBridgeSample)

[<span data-ttu-id="e50f5-209">C++ Win32 アプリを使ったアプリ サービス ブリッジのサンプル</span><span class="sxs-lookup"><span data-stu-id="e50f5-209">App service bridge sample with C++ win32 app</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/AppServiceBridgeSample_C%2B%2B)

[<span data-ttu-id="e50f5-210">プッシュ通知を受け取る MFC アプリケーション</span><span class="sxs-lookup"><span data-stu-id="e50f5-210">MFC application that receives push notifications</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/MFCwithPush)


## <a name="making-your-desktop-application-a-share-target"></a><span data-ttu-id="e50f5-211">デスクトップ アプリケーションを共有ターゲットにする</span><span class="sxs-lookup"><span data-stu-id="e50f5-211">Making your desktop application a share target</span></span>

<span data-ttu-id="e50f5-212">デスクトップ アプリケーションを共有ターゲットにすることで、共有をサポートしている他のアプリのデータ (画像など) をユーザーが簡単に共有できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e50f5-212">You can make your desktop application a share target so that users can easily share data such as pictures from other apps that support sharing.</span></span>

<span data-ttu-id="e50f5-213">たとえば、ユーザーは、Microsoft Edge、フォト アプリから画像を共有するアプリケーションを選択できます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-213">For example, users could choose your application to share pictures from Microsoft Edge, the Photos app.</span></span> <span data-ttu-id="e50f5-214">その機能を備えている WPF サンプル アプリケーションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-214">Here's a WPF sample application that has that capability.</span></span>

![共有ターゲット](images/desktop-to-uwp/share-target.png)

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="e50f5-216">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="e50f5-216">Have a closer look at this app</span></span>

<span data-ttu-id="e50f5-217">:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/wpf-app-as-sharetarget/9pjcjljlck37)</span><span class="sxs-lookup"><span data-stu-id="e50f5-217">:heavy_check_mark: [Get the app](https://www.microsoft.com/en-us/store/p/wpf-app-as-sharetarget/9pjcjljlck37)</span></span>

<span data-ttu-id="e50f5-218">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WPFasShareTarget)</span><span class="sxs-lookup"><span data-stu-id="e50f5-218">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WPFasShareTarget)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="e50f5-219">設計パターン</span><span class="sxs-lookup"><span data-stu-id="e50f5-219">The design pattern</span></span>

<span data-ttu-id="e50f5-220">アプリケーションを共有ターゲットにするには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-220">To make your application a share target, do these things:</span></span>

<span data-ttu-id="e50f5-221">:1: [共有ターゲットの拡張機能を追加する](#share-extension)</span><span class="sxs-lookup"><span data-stu-id="e50f5-221">:one: [Add a share target extension](#share-extension)</span></span>

<span data-ttu-id="e50f5-222">:2: [OnNavigatedTo イベント ハンドラーをオーバーライドする](#override)</span><span class="sxs-lookup"><span data-stu-id="e50f5-222">:two: [Override the OnNavigatedTo event handler](#override)</span></span>

<a id="share-extension" />

### <a name="add-a-share-target-extension"></a><span data-ttu-id="e50f5-223">共有ターゲットの拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="e50f5-223">Add a share target extension</span></span>

<span data-ttu-id="e50f5-224">**ソリューション エクスプ ローラー**で、ソリューションにパッケージ プロジェクトの**package.appxmanifest**ファイルを開くし、拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-224">In **Solution Explorer**, open the **package.appxmanifest** file of the Packaging project in your solution and add the extension.</span></span>

```xml
<Extensions>
      <uap:Extension
          Category="windows.shareTarget"
          Executable="ShareTarget.exe"
          EntryPoint="ShareTarget.App">
        <uap:ShareTarget>
          <uap:SupportedFileTypes>
            <uap:SupportsAnyFileType />
          </uap:SupportedFileTypes>
          <uap:DataFormat>Bitmap</uap:DataFormat>
        </uap:ShareTarget>
      </uap:Extension>
</Extensions>  
```

<span data-ttu-id="e50f5-225">UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-225">Provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span> <span data-ttu-id="e50f5-226">アプリとの間で共有できるようにするファイルの種類を指定することも必要です。</span><span class="sxs-lookup"><span data-stu-id="e50f5-226">You'll also have to specify what types of files can be shared with your app.</span></span>

<a id="override" />

### <a name="override-the-onnavigatedto-event-handler"></a><span data-ttu-id="e50f5-227">OnNavigatedTo イベント ハンドラーをオーバーライドする</span><span class="sxs-lookup"><span data-stu-id="e50f5-227">Override the OnNavigatedTo event handler</span></span>

<span data-ttu-id="e50f5-228">UWP プロジェクトの **App** クラスで、**OnNavigatedTo** イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="e50f5-228">Override the **OnNavigatedTo** event handler in the **App** class of your UWP project.</span></span>

<span data-ttu-id="e50f5-229">このイベント ハンドラーは、ユーザーがファイルを共有するためにアプリを選択するときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-229">This event handler is called when users choose your app to share their files.</span></span>

```csharp
protected override async void OnNavigatedTo(NavigationEventArgs e)
{
  this.shareOperation = (ShareOperation)e.Parameter;
  if (this.shareOperation.Data.Contains(StandardDataFormats.StorageItems))
  {
      this.sharedStorageItems =
        await this.shareOperation.Data.GetStorageItemsAsync();
       
      foreach (StorageFile item in this.sharedStorageItems)
      {
          ProcessSharedFile(item);
      }
  }
}
```

## <a name="create-a-background-task"></a><span data-ttu-id="e50f5-230">バックグラウンド タスクを作成する</span><span class="sxs-lookup"><span data-stu-id="e50f5-230">Create a background task</span></span>

<span data-ttu-id="e50f5-231">バックグラウンド タスクを追加して、アプリが一時停止されているときでもコードを実行できます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-231">You add a background task to run code even when the app is suspended.</span></span> <span data-ttu-id="e50f5-232">バックグラウンド タスクは、ユーザーの操作を必要としない小さなタスクに最適です。</span><span class="sxs-lookup"><span data-stu-id="e50f5-232">Background tasks are great for small tasks that don't require the user interaction.</span></span> <span data-ttu-id="e50f5-233">たとえば、タスクはメールのダウンロード、受信チャット メッセージに関するトースト通知の表示、システムの状態の変化に対する対応を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-233">For example, your task can download mail, show a toast notification about an incoming chat message, or react to a change in a system condition.</span></span>

<span data-ttu-id="e50f5-234">バック グラウンド タスクを登録する WPF サンプル アプリケーションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-234">Here's a WPF sample application that registers a background task.</span></span>

![バックグラウンド タスク](images/desktop-to-uwp/sample-background-task.png)

<span data-ttu-id="e50f5-236">タスクは http 要求を行い、要求が応答を返すのにかかる時間を測定します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-236">The task makes an http request and measures the time that it takes for the request to return a response.</span></span> <span data-ttu-id="e50f5-237">タスクはさらに興味深いものと考えられますが、このサンプルはバックグラウンド タスクの基本的なしくみを学習するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="e50f5-237">Your tasks will likely be much more interesting, but this sample is great for learning the basic mechanics of a background task.</span></span>

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="e50f5-238">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="e50f5-238">Have a closer look at this app</span></span>

<span data-ttu-id="e50f5-239">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask)</span><span class="sxs-lookup"><span data-stu-id="e50f5-239">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="e50f5-240">設計パターン</span><span class="sxs-lookup"><span data-stu-id="e50f5-240">The design pattern</span></span>

<span data-ttu-id="e50f5-241">バックグラウンド サービスを作成するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-241">To create a background service, do these things:</span></span>

<span data-ttu-id="e50f5-242">:1: [バックグラウンド タスクの実装](#implement-task)</span><span class="sxs-lookup"><span data-stu-id="e50f5-242">:one: [Implement the background task](#implement-task)</span></span>

<span data-ttu-id="e50f5-243">:2: [バックグラウンド タスクの構成](#configure-background-task)</span><span class="sxs-lookup"><span data-stu-id="e50f5-243">:two: [Configure the background task](#configure-background-task)</span></span>

<span data-ttu-id="e50f5-244">:3: [バックグラウンド タスクの登録](#register-background-task)</span><span class="sxs-lookup"><span data-stu-id="e50f5-244">:three: [Register the background task](#register-background-task)</span></span>

<a id="implement-task" />

### <a name="implement-the-background-task"></a><span data-ttu-id="e50f5-245">バックグラウンド タスクの実装</span><span class="sxs-lookup"><span data-stu-id="e50f5-245">Implement the background task</span></span>

<span data-ttu-id="e50f5-246">Windows ランタイム コンポーネント プロジェクトにコードを追加することで、バックグラウンド タスクを実装します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-246">Implement the background task by adding code to a Windows Runtime component project.</span></span>

```csharp
public sealed class SiteVerifier : IBackgroundTask
{
    public async void Run(IBackgroundTaskInstance taskInstance)
    {

        taskInstance.Canceled += TaskInstance_Canceled;
        BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
        var msg = await MeasureRequestTime();
        ShowToast(msg);
        deferral.Complete();
    }

    private async Task<string> MeasureRequestTime()
    {
        string msg;
        try
        {
            var url = ApplicationData.Current.LocalSettings.Values["UrlToVerify"] as string;
            var http = new HttpClient();
            Stopwatch clock = Stopwatch.StartNew();
            var response = await http.GetAsync(new Uri(url));
            response.EnsureSuccessStatusCode();
            var elapsed = clock.ElapsedMilliseconds;
            clock.Stop();
            msg = $"{url} took {elapsed.ToString()} ms";
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        return msg;
    }
```

<a id="configure-background-task" />

### <a name="configure-the-background-task"></a><span data-ttu-id="e50f5-247">バックグラウンド タスクの構成</span><span class="sxs-lookup"><span data-stu-id="e50f5-247">Configure the background task</span></span>

<span data-ttu-id="e50f5-248">マニフェスト デザイナーで、ソリューションにパッケージ プロジェクトの**package.appxmanifest**ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-248">In the manifest designer, open the **package.appxmanifest** file of the Packaging project in your solution.</span></span>

<span data-ttu-id="e50f5-249">**[宣言]** タブで、**[バックグラウンド タスク]** 宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-249">In the **Declarations** tab, add a **Background Tasks** declaration.</span></span>

![バックグラウンド タスクのオプション](images/desktop-to-uwp/background-task-option.png)

<span data-ttu-id="e50f5-251">次に、必要なプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-251">Then, choose the desired properties.</span></span> <span data-ttu-id="e50f5-252">サンプルでは、**Timer** プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="e50f5-252">Our sample uses the **Timer** property.</span></span>

![Timer プロパティ](images/desktop-to-uwp/timer-property.png)

<span data-ttu-id="e50f5-254">バックグラウンド タスクを実装する Windows ランタイム コンポーネントでクラスの完全修飾名を指定します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-254">Provide the fully qualified name of the class in your Windows Runtime Component that implements the background task.</span></span>

![Timer プロパティ](images/desktop-to-uwp/background-task-entry-point.png)

<a id="register-background-task" />

### <a name="register-the-background-task"></a><span data-ttu-id="e50f5-256">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="e50f5-256">Register the background task</span></span>

<span data-ttu-id="e50f5-257">バックグラウンド タスクを登録するデスクトップ アプリケーション プロジェクトにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="e50f5-257">Add code to your desktop application project that registers the background task.</span></span>

```csharp
public void RegisterBackgroundTask(String triggerName)
{
    var current = BackgroundTaskRegistration.AllTasks
        .Where(b => b.Value.Name == triggerName).FirstOrDefault().Value;

    if (current is null)
    {
        BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
        builder.Name = triggerName;
        builder.SetTrigger(new MaintenanceTrigger(15, false));
        builder.TaskEntryPoint = "HttpPing.SiteVerifier";
        builder.Register();
        System.Diagnostics.Debug.WriteLine("BGTask registered:" + triggerName);
    }
    else
    {
        System.Diagnostics.Debug.WriteLine("Task already:" + triggerName);
    }
}
```
## <a name="support-and-feedback"></a><span data-ttu-id="e50f5-258">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="e50f5-258">Support and feedback</span></span>

**<span data-ttu-id="e50f5-259">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="e50f5-259">Find answers to your questions</span></span>**

<span data-ttu-id="e50f5-260">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="e50f5-260">Have questions?</span></span> <span data-ttu-id="e50f5-261">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-261">Ask us on Stack Overflow.</span></span> <span data-ttu-id="e50f5-262">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="e50f5-262">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="e50f5-263">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="e50f5-263">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="e50f5-264">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="e50f5-264">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="e50f5-265">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50f5-265">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
