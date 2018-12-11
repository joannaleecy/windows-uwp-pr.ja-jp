---
Description: Extend your desktop application with Windows UIs and components
Search.Product: eADQiWindows 10XVcnh
title: Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張
ms.date: 06/08/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 76e4b60e1cd25a205d6a304f12a0b04f5db693b5
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8883136"
---
# <a name="extend-your-desktop-application-with-modern-uwp-components"></a><span data-ttu-id="96f59-103">最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張</span><span class="sxs-lookup"><span data-stu-id="96f59-103">Extend your desktop application with modern UWP components</span></span>

<span data-ttu-id="96f59-104">一部の Windows 10 エクスペリエンス (タッチ対応 UI ページなど) は、最新のアプリ コンテナー内で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96f59-104">Some Windows 10 experiences (For example: a touch-enabled UI page) must run inside of a modern app container .</span></span> <span data-ttu-id="96f59-105">こうしたエクスペリエンスを追加するには、UWP プロジェクトと Windows ランタイム コンポーネントを使ってデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="96f59-105">If you want to add these experiences, extend your desktop application with UWP projects and Windows Runtime Components.</span></span>

<span data-ttu-id="96f59-106">多くの場合、デスクトップ アプリケーションから直接 Windows ランタイム Api を呼び出して、ため、このガイドを確認する前に[強化 for Windows 10](desktop-to-uwp-enhance.md)を表示できます。</span><span class="sxs-lookup"><span data-stu-id="96f59-106">In many cases you can call Windows Runtime APIs directly from your desktop application, so before you review this guide, see [Enhance for Windows 10](desktop-to-uwp-enhance.md).</span></span>

>[!NOTE]
><span data-ttu-id="96f59-107">このガイドでは、デスクトップ アプリケーションの Windows アプリ パッケージを作成したことを前提としています。</span><span class="sxs-lookup"><span data-stu-id="96f59-107">This guide assumes that you've created a Windows app package for your desktop application.</span></span> <span data-ttu-id="96f59-108">まだ行っていない場合、は、[デスクトップ アプリケーションのパッケージ](desktop-to-uwp-root.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="96f59-108">If you haven't yet done this, see [Package desktop applications](desktop-to-uwp-root.md).</span></span>

<span data-ttu-id="96f59-109">準備ができたら始めましょう。</span><span class="sxs-lookup"><span data-stu-id="96f59-109">If you're ready, let's start.</span></span>

<a id="setup" />

## <a name="first-setup-your-solution"></a><span data-ttu-id="96f59-110">まず、ソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="96f59-110">First, setup your Solution</span></span>

<span data-ttu-id="96f59-111">UWP プロジェクトとランタイム コンポーネントを 1 つ以上ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-111">Add one or more UWP projects and runtime components to your solution.</span></span>

<span data-ttu-id="96f59-112">**Windows アプリケーション パッケージ プロジェクト**とデスクトップ アプリケーションへの参照が含まれるソリューションから始めます。</span><span class="sxs-lookup"><span data-stu-id="96f59-112">Start with a solution that contains a **Windows Application Packaging Project** with a reference to your desktop application.</span></span>

<span data-ttu-id="96f59-113">次の画像は、ソリューションの例を示しています。</span><span class="sxs-lookup"><span data-stu-id="96f59-113">This image shows an example solution.</span></span>

![開始プロジェクトを拡張する](images/desktop-to-uwp/extend-start-project.png)

<span data-ttu-id="96f59-115">ソリューションにパッケージ プロジェクトがない場合は、 [Visual Studio を使ってデスクトップ アプリケーションのパッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="96f59-115">If your solution doesn't contain a packaging project, see [Package your desktop application by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

### <a name="configure-the-desktop-application"></a><span data-ttu-id="96f59-116">デスクトップ アプリケーションを構成します。</span><span class="sxs-lookup"><span data-stu-id="96f59-116">Configure the desktop application</span></span>

<span data-ttu-id="96f59-117">デスクトップ アプリケーションを Windows ランタイム Api を呼び出す必要があるファイルへの参照があることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="96f59-117">Make sure that your desktop application has references to the files that you need to call Windows Runtime APIs.</span></span>

<span data-ttu-id="96f59-118">これを行うには、 [Windows 10 のデスクトップ アプリケーションの効果を高める](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project)トピックの[最初に、プロジェクトのセットアップ](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project)」セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="96f59-118">To do this, see the [First, setup your project](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project) section of the topic [Enhance your desktop application for Windows 10](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project).</span></span>

### <a name="add-a-uwp-project"></a><span data-ttu-id="96f59-119">UWP プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="96f59-119">Add a UWP project</span></span>

<span data-ttu-id="96f59-120">ソリューションに **[空白のアプリ (ユニバーサル Windows)]** を追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-120">Add a **Blank App (Universal Windows)** to your solution.</span></span>

<span data-ttu-id="96f59-121">ここでは、最新の XAML UI をビルドするか、UWP プロセス内でのみ実行される API を使います。</span><span class="sxs-lookup"><span data-stu-id="96f59-121">This is where you'll build a modern XAML UI or use APIs that run only within a UWP process.</span></span>

![UWP プロジェクト](images/desktop-to-uwp/add-uwp-project-to-solution.png)

<span data-ttu-id="96f59-123">パッケージ プロジェクトで、**[アプリケーション]** ノードを右クリックして **[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="96f59-123">In your packaging project, right-click the **Applications** node, and then click **Add Reference**.</span></span>

![UWP プロジェクトを参照する](images/desktop-to-uwp/add-uwp-project-reference.png)

<span data-ttu-id="96f59-125">次に、UWP プロジェクトに参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-125">Then, add a reference the UWP project.</span></span>

![UWP プロジェクトを参照する](images/desktop-to-uwp/choose-uwp-project.png)

<span data-ttu-id="96f59-127">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="96f59-127">Your solution will look something like this:</span></span>

![UWP プロジェクトのあるソリューション](images/desktop-to-uwp/uwp-project-reference.png)

### <a name="optional-add-a-windows-runtime-component"></a><span data-ttu-id="96f59-129">(省略可能) Windows ランタイム コンポーネントを追加する</span><span class="sxs-lookup"><span data-stu-id="96f59-129">(Optional) Add a Windows Runtime Component</span></span>

<span data-ttu-id="96f59-130">いくつかのシナリオでは、Windows ランタイム コンポーネントにコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96f59-130">To accomplish some scenarios, you'll have to add code to a Windows Runtime Component.</span></span>

![ランタイム コンポーネントのアプリ サービス](images/desktop-to-uwp/add-runtime-component.png)

<span data-ttu-id="96f59-132">次に、UWP プロジェクトからランタイム コンポーネントに参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-132">Then, from your UWP project, add a reference to the runtime component.</span></span> <span data-ttu-id="96f59-133">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="96f59-133">Your solution will look something like this:</span></span>

![ランタイム コンポーネント参照](images/desktop-to-uwp/runtime-component-reference.png)

### <a name="build-your-solution"></a><span data-ttu-id="96f59-135">ソリューションをビルドします。</span><span class="sxs-lookup"><span data-stu-id="96f59-135">Build your solution</span></span>

<span data-ttu-id="96f59-136">エラーが表示されないことを確認するソリューションをビルドします。</span><span class="sxs-lookup"><span data-stu-id="96f59-136">Build your solution to ensure that no errors appear.</span></span> <span data-ttu-id="96f59-137">エラーが発生した場合は、 **Configuration Manager**を開き、プロジェクトが同じプラットフォームを対象とすることを確認します。</span><span class="sxs-lookup"><span data-stu-id="96f59-137">If you receive errors, open **Configuration Manager** and ensure that your projects target the same platform.</span></span>

![構成マネージャー](images/desktop-to-uwp/config-manager.png)

<span data-ttu-id="96f59-139">UWP プロジェクトとランタイム コンポーネントで行うことができる操作をいくつか見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="96f59-139">Let's take a look at a few things you can do with your UWP projects and runtime components.</span></span>

## <a name="show-a-modern-xaml-ui"></a><span data-ttu-id="96f59-140">最新の XAML UI を表示する</span><span class="sxs-lookup"><span data-stu-id="96f59-140">Show a modern XAML UI</span></span>

<span data-ttu-id="96f59-141">アプリケーション フローの一環として、最新の XAML ベースのユーザー インターフェイスをデスクトップ アプリケーションに組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="96f59-141">As part of your application flow, you can incorporate modern XAML-based user interfaces into your desktop application.</span></span> <span data-ttu-id="96f59-142">これらのユーザー インターフェイスは、さまざまな画面サイズと解像度に適応し、タッチや手描きなどの最新の対話モデルをサポートする性質を備えています。</span><span class="sxs-lookup"><span data-stu-id="96f59-142">These user interfaces are naturally adaptive to different screen sizes and resolutions and support modern interactive models such as touch and ink.</span></span>

<span data-ttu-id="96f59-143">たとえば、少量の XAML マークアップを使用して、地図関連の強力な視覚化機能をユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="96f59-143">For example, with a small amount of XAML markup, you can give users with powerful map-related visualization features.</span></span>

<span data-ttu-id="96f59-144">次の画像に、マップ コントロールを含む XAML ベースの最新の UI を表示している Windows フォーム アプリケーションを示しています。</span><span class="sxs-lookup"><span data-stu-id="96f59-144">This image shows a Windows Forms application that opens a XAML-based modern UI that contains a map control.</span></span>

![アダプティブ デザイン](images/desktop-to-uwp/extend-xaml-ui.png)

>[!NOTE]
><span data-ttu-id="96f59-146">この例では、UWP プロジェクトをソリューションに追加することで、XAML UI を示しています。</span><span class="sxs-lookup"><span data-stu-id="96f59-146">This example shows a XAML UI by adding a UWP project to the solution.</span></span> <span data-ttu-id="96f59-147">デスクトップ アプリケーションでの XAML Ui の表示を安定したサポートされているアプローチです。</span><span class="sxs-lookup"><span data-stu-id="96f59-147">That is the stable supported approach to showing XAML UIs in a desktop application.</span></span> <span data-ttu-id="96f59-148">代わりに、この方法では、XAML 島を使用して、デスクトップ アプリケーションに直接 UWP XAML コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-148">The alternative to this approach is to add UWP XAML controls directly to your desktop application by using a XAML Island.</span></span> <span data-ttu-id="96f59-149">XAML 諸島現在利用可能な開発者プレビューとしてします。</span><span class="sxs-lookup"><span data-stu-id="96f59-149">XAML Islands are currently available as a developer preview.</span></span> <span data-ttu-id="96f59-150">それらプロトタイプ コードで今すぐ試すをお勧めしますがない使用することに運用コードでこの時点でお勧めしますしないでください。</span><span class="sxs-lookup"><span data-stu-id="96f59-150">Although we encourage you to try them out in your own prototype code now, we do not recommend that you use them in production code at this time.</span></span> <span data-ttu-id="96f59-151">これらの Api とコントロールは引き続き成熟して、今後の Windows リリースに安定します。</span><span class="sxs-lookup"><span data-stu-id="96f59-151">These APIs and controls will continue to mature and stabilize in future Windows releases.</span></span> <span data-ttu-id="96f59-152">XAML 諸島について詳しくは、[デスクトップ アプリケーションで UWP コントロール](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="96f59-152">To learn more about XAML Islands, see [UWP controls in desktop applications](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="96f59-153">設計パターン</span><span class="sxs-lookup"><span data-stu-id="96f59-153">The design pattern</span></span>

<span data-ttu-id="96f59-154">XAML ベースの UI を表示するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="96f59-154">To show a XAML-based UI, do these things:</span></span>

<span data-ttu-id="96f59-155">1: [ソリューションをセットアップする](#solution-setup)</span><span class="sxs-lookup"><span data-stu-id="96f59-155">:one: [Setup your Solution](#solution-setup)</span></span>

<span data-ttu-id="96f59-156">2: [XAML UI を作成する](#xaml-UI)</span><span class="sxs-lookup"><span data-stu-id="96f59-156">:two: [Create a XAML UI](#xaml-UI)</span></span>

<span data-ttu-id="96f59-157">3: [プロトコル拡張機能を UWP プロジェクトに追加する](#protocol)</span><span class="sxs-lookup"><span data-stu-id="96f59-157">:three: [Add a protocol extension to the UWP project](#protocol)</span></span>

<span data-ttu-id="96f59-158">4: [デスクトップ アプリから UWP アプリを起動する](#start)</span><span class="sxs-lookup"><span data-stu-id="96f59-158">:four: [Start the UWP app from your desktop app](#start)</span></span>

<span data-ttu-id="96f59-159">5: [UWP プロジェクトで目的のページを表示する](#parse)</span><span class="sxs-lookup"><span data-stu-id="96f59-159">:five: [In the UWP project, show the page that you want](#parse)</span></span>

<a id="solution-setup" />

### <a name="setup-your-solution"></a><span data-ttu-id="96f59-160">ソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="96f59-160">Setup your Solution</span></span>

<span data-ttu-id="96f59-161">ソリューションのセットアップ方法に関する一般的なガイダンスについては、このガイドの冒頭の「[まず、ソリューションをセットアップする](#setup)」セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="96f59-161">For general guidance on how to set your solution up, see the [First, setup your Solution](#setup) section at the beginning of this guide.</span></span>

<span data-ttu-id="96f59-162">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="96f59-162">Your solution would look something like this:</span></span>

![XAML UI ソリューション](images/desktop-to-uwp/xaml-ui-solution.png)

<span data-ttu-id="96f59-164">この例では、Windows フォーム プロジェクトは **Landmarks** という名前で、XAML UI を含む UWP プロジェクトは **MapUI** という名前です。</span><span class="sxs-lookup"><span data-stu-id="96f59-164">In this example, the Windows Forms project is named **Landmarks** and the UWP project that contains the XAML UI is named **MapUI**.</span></span>

<a id="xaml-UI" />

### <a name="create-a-xaml-ui"></a><span data-ttu-id="96f59-165">XAML UI の作成</span><span class="sxs-lookup"><span data-stu-id="96f59-165">Create a XAML UI</span></span>

<span data-ttu-id="96f59-166">XAML UI を UWP プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-166">Add a XAML UI to your UWP project.</span></span> <span data-ttu-id="96f59-167">基本的なマップの XAML を次に示します。</span><span class="sxs-lookup"><span data-stu-id="96f59-167">Here's the XAML for a basic map.</span></span>

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

### <a name="add-a-protocol-extension"></a><span data-ttu-id="96f59-168">プロトコル拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="96f59-168">Add a protocol extension</span></span>

<span data-ttu-id="96f59-169">**ソリューション エクスプ ローラー**で、ソリューションにパッケージ プロジェクトの**package.appxmanifest**ファイルを開くし、この拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-169">In **Solution Explorer**, open the **package.appxmanifest** file of the Packaging project in your solution, and add this extension.</span></span>

```xml
<Extensions>
  <uap:Extension Category="windows.protocol" Executable="MapUI.exe" EntryPoint="MapUI.App">
    <uap:Protocol Name="xamluidemo" />
  </uap:Extension>
</Extensions>
```

<span data-ttu-id="96f59-170">プロトコルに名前を付けて、UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="96f59-170">Give the protocol a name, provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span>

<span data-ttu-id="96f59-171">デザイナーで **package.appxmanifest** 開き、**[宣言]** タブを選んで、そこで拡張機能を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="96f59-171">You can also open the **package.appxmanifest** in the designer, choose the **Declarations** tab, and then add the extension there.</span></span>

![[宣言] タブ](images/desktop-to-uwp/protocol-properties.png)

> [!NOTE]
> <span data-ttu-id="96f59-173">マップ コントロールはインターネットからデータをダウンロードします。そのため、マップ コントロールを使用する場合は、"インターネット クライアント" 機能もマニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96f59-173">Map controls download data from the internet so if you use one, you'll have to add the "internet client" capability to your manifest as well.</span></span>

<a id="start" />

### <a name="start-the-uwp-app"></a><span data-ttu-id="96f59-174">UWP アプリを起動する</span><span class="sxs-lookup"><span data-stu-id="96f59-174">Start the UWP app</span></span>

<span data-ttu-id="96f59-175">まず、デスクトップ アプリケーションから、プロトコル名と UWP アプリに渡すパラメーターが含まれた [URI](https://msdn.microsoft.com/library/system.uri.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="96f59-175">First, from your desktop application, create a [Uri](https://msdn.microsoft.com/library/system.uri.aspx) that includes the protocol name and any parameters you want to pass into the UWP app.</span></span> <span data-ttu-id="96f59-176">次に、[LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="96f59-176">Then, call the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) method.</span></span>

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

### <a name="parse-parameters-and-show-a-page"></a><span data-ttu-id="96f59-177">パラメーターを解析してページを表示する</span><span class="sxs-lookup"><span data-stu-id="96f59-177">Parse parameters and show a page</span></span>

<span data-ttu-id="96f59-178">UWP プロジェクトの **App** クラスで、**OnActivated** イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="96f59-178">In the **App** class of your UWP project, override the **OnActivated** event handler.</span></span> <span data-ttu-id="96f59-179">アプリがプロトコルによってアクティブ化されている場合は、パラメーターを解析して目的のページを開きます。</span><span class="sxs-lookup"><span data-stu-id="96f59-179">If the app is activated by your protocol, parse the parameters and then open the page that you want.</span></span>

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

<span data-ttu-id="96f59-180">コードでは、XAML ページの背後にある、オーバーライド、``OnNavigatedTo``ページに渡されるパラメーターを使用する方法。</span><span class="sxs-lookup"><span data-stu-id="96f59-180">In the code behind your XAML page, override the ``OnNavigatedTo`` method to use the parameters passed into the page.</span></span> <span data-ttu-id="96f59-181">この場合、このページに渡された緯度と経度を使用してマップに場所を表示します。</span><span class="sxs-lookup"><span data-stu-id="96f59-181">In this case, we'll use the latitude and longitude that were passed into this page to show a location in a map.</span></span>

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

## <a name="making-your-desktop-application-a-share-target"></a><span data-ttu-id="96f59-182">デスクトップ アプリケーションを共有ターゲットにする</span><span class="sxs-lookup"><span data-stu-id="96f59-182">Making your desktop application a share target</span></span>

<span data-ttu-id="96f59-183">デスクトップ アプリケーションを共有ターゲットにすることで、共有をサポートしている他のアプリのデータ (画像など) をユーザーが簡単に共有できるようになります。</span><span class="sxs-lookup"><span data-stu-id="96f59-183">You can make your desktop application a share target so that users can easily share data such as pictures from other apps that support sharing.</span></span>

<span data-ttu-id="96f59-184">たとえば、ユーザーは、Microsoft Edge、フォト アプリから画像を共有するアプリケーションを選択できます。</span><span class="sxs-lookup"><span data-stu-id="96f59-184">For example, users could choose your application to share pictures from Microsoft Edge, the Photos app.</span></span> <span data-ttu-id="96f59-185">その機能を備えている WPF サンプル アプリケーションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="96f59-185">Here's a WPF sample application that has that capability.</span></span>

![共有ターゲット](images/desktop-to-uwp/share-target.png)<span data-ttu-id="96f59-187">.</span><span class="sxs-lookup"><span data-stu-id="96f59-187">.</span></span>

<span data-ttu-id="96f59-188">完全なサンプルを参照してください[ここで](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/ShareTarget)。</span><span class="sxs-lookup"><span data-stu-id="96f59-188">See the complete sample [here](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/ShareTarget)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="96f59-189">設計パターン</span><span class="sxs-lookup"><span data-stu-id="96f59-189">The design pattern</span></span>

<span data-ttu-id="96f59-190">アプリケーションを共有ターゲットにするには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="96f59-190">To make your application a share target, do these things:</span></span>

<span data-ttu-id="96f59-191">:1: [共有ターゲットの拡張機能を追加する](#share-extension)</span><span class="sxs-lookup"><span data-stu-id="96f59-191">:one: [Add a share target extension](#share-extension)</span></span>

<span data-ttu-id="96f59-192">: 2: [OnShareTargetActivated イベントのハンドラーをオーバーライド](#override)</span><span class="sxs-lookup"><span data-stu-id="96f59-192">:two: [Override the OnShareTargetActivated event handler](#override)</span></span>

<span data-ttu-id="96f59-193">: 3:[デスクトップ拡張機能を UWP プロジェクトに追加](#desktop-extensions)</span><span class="sxs-lookup"><span data-stu-id="96f59-193">:three: [Add desktop extensions to the UWP project](#desktop-extensions)</span></span>

<span data-ttu-id="96f59-194">: 4:[完全な信頼プロセスの拡張機能の追加](#full-trust)</span><span class="sxs-lookup"><span data-stu-id="96f59-194">:four: [Add the full trust process extension](#full-trust)</span></span>

<span data-ttu-id="96f59-195">: 5:[変更、共有ファイルを取得するデスクトップ アプリケーション](#modify-desktop)</span><span class="sxs-lookup"><span data-stu-id="96f59-195">:five: [Modify the desktop application to get the shared file](#modify-desktop)</span></span>

<a id="share-extension" />

<span data-ttu-id="96f59-196">次の手順</span><span class="sxs-lookup"><span data-stu-id="96f59-196">The following steps</span></span>  

### <a name="add-a-share-target-extension"></a><span data-ttu-id="96f59-197">共有ターゲットの拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="96f59-197">Add a share target extension</span></span>

<span data-ttu-id="96f59-198">**ソリューション エクスプ ローラー**で、ソリューションで、パッケージ プロジェクトの**package.appxmanifest**ファイルを開くし、共有ターゲットの拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-198">In **Solution Explorer**, open the **package.appxmanifest** file of the Packaging project in your solution and add the share target extension.</span></span>

```xml
<Extensions>
      <uap:Extension
          Category="windows.shareTarget"
          Executable="ShareTarget.exe"
          EntryPoint="App">
        <uap:ShareTarget>
          <uap:SupportedFileTypes>
            <uap:SupportsAnyFileType />
          </uap:SupportedFileTypes>
          <uap:DataFormat>Bitmap</uap:DataFormat>
        </uap:ShareTarget>
      </uap:Extension>
</Extensions>  
```

<span data-ttu-id="96f59-199">UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="96f59-199">Provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span> <span data-ttu-id="96f59-200">このマークアップは、UWP アプリの実行可能ファイルの名前が前提としています。`ShareTarget.exe`します。</span><span class="sxs-lookup"><span data-stu-id="96f59-200">This markup assumes that the name of the executable for your UWP app is `ShareTarget.exe`.</span></span>

<span data-ttu-id="96f59-201">アプリとの間で共有できるようにするファイルの種類を指定することも必要です。</span><span class="sxs-lookup"><span data-stu-id="96f59-201">You'll also have to specify what types of files can be shared with your app.</span></span> <span data-ttu-id="96f59-202">この例でを行う[WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)デスクトップ アプリケーションを共有ターゲット ビットマップ画像を指定するための`Bitmap`のサポートされているファイルの種類。</span><span class="sxs-lookup"><span data-stu-id="96f59-202">In this example, we are making the [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo) desktop application a share target for bitmap images so we specify `Bitmap` for the supported file type.</span></span>

<a id="override" />

### <a name="override-the-onsharetargetactivated-event-handler"></a><span data-ttu-id="96f59-203">OnShareTargetActivated イベントのハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="96f59-203">Override the OnShareTargetActivated event handler</span></span>

<span data-ttu-id="96f59-204">UWP プロジェクトの**アプリ**のクラスで**OnShareTargetActivated**イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="96f59-204">Override the **OnShareTargetActivated** event handler in the **App** class of your UWP project.</span></span>

<span data-ttu-id="96f59-205">このイベント ハンドラーは、ユーザーがファイルを共有するためにアプリを選択するときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="96f59-205">This event handler is called when users choose your app to share their files.</span></span>

```csharp

protected override void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    shareWithDesktopApplication(args.ShareOperation);
}

private async void shareWithDesktopApplication(ShareOperation shareOperation)
{
    if (shareOperation.Data.Contains(StandardDataFormats.StorageItems))
    {
        var items = await shareOperation.Data.GetStorageItemsAsync();
        StorageFile file = items[0] as StorageFile;
        IRandomAccessStreamWithContentType stream = await file.OpenReadAsync();

        await file.CopyAsync(ApplicationData.Current.LocalFolder);
            shareOperation.ReportCompleted();

        await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
    }
}
```

<span data-ttu-id="96f59-206">このコードでは、アプリのローカル ストレージ フォルダーに、ユーザーが共有されているイメージを保存します。</span><span class="sxs-lookup"><span data-stu-id="96f59-206">In this code, we save the image that is being shared by the user into a apps local storage folder.</span></span> <span data-ttu-id="96f59-207">その後、その同じフォルダーからのイメージをプルするデスクトップ アプリケーションを変更します。</span><span class="sxs-lookup"><span data-stu-id="96f59-207">Later, we'll modify the desktop application to pull images from that same folder.</span></span> <span data-ttu-id="96f59-208">UWP アプリとして、同じパッケージに含まれているために、デスクトップ アプリケーションを実行できます。</span><span class="sxs-lookup"><span data-stu-id="96f59-208">The desktop application can do that because it is included in the same package as the UWP app.</span></span>

<a id="desktop-extensions" />

### <a name="add-desktop-extensions-to-the-uwp-project"></a><span data-ttu-id="96f59-209">デスクトップ拡張機能を UWP プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-209">Add desktop extensions to the UWP project</span></span>

<span data-ttu-id="96f59-210">**Windows Desktop Extensions for UWP**拡張機能を UWP アプリ プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-210">Add the **Windows Desktop Extensions for the UWP** extension to the UWP app project.</span></span>

![デスクトップ拡張機能](images/desktop-to-uwp/desktop-extensions.png)

<a id="full-trust" />

### <a name="add-the-full-trust-process-extension"></a><span data-ttu-id="96f59-212">完全な信頼プロセスの拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-212">Add the full trust process extension</span></span>

<span data-ttu-id="96f59-213">**ソリューション エクスプ ローラー**で、ソリューションにパッケージ プロジェクトの**package.appxmanifest**ファイルを開くし、以前このファイルを追加する共有ターゲットの拡張機能の横にある完全な信頼プロセス拡張機能を追加し、します。</span><span class="sxs-lookup"><span data-stu-id="96f59-213">In **Solution Explorer**, open the **package.appxmanifest** file of the Packaging project in your solution, and then add the full trust process extension next to the share target extension that you add this file earlier.</span></span>

```xml
<Extensions>
  ...
      <desktop:Extension Category="windows.fullTrustProcess" Executable="PhotoStoreDemo\PhotoStoreDemo.exe" />
  ...
</Extensions>  
```

<span data-ttu-id="96f59-214">この拡張機能は、ファイル共有を希望するデスクトップ アプリケーションを起動する UWP アプリを有効になります。</span><span class="sxs-lookup"><span data-stu-id="96f59-214">This extension will enable the UWP app to start the desktop application to which you would like the share a file.</span></span> <span data-ttu-id="96f59-215">例では、 [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)デスクトップ アプリケーションの実行可能ファイルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="96f59-215">In example, we refer to the executable of the [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo) desktop application.</span></span>

<a id="modify-desktop" />

### <a name="modify-the-desktop-application-to-get-the-shared-file"></a><span data-ttu-id="96f59-216">共有ファイルを取得するデスクトップ アプリケーションを変更します。</span><span class="sxs-lookup"><span data-stu-id="96f59-216">Modify the desktop application to get the shared file</span></span>

<span data-ttu-id="96f59-217">共有ファイルを処理を検索するデスクトップ アプリケーションを変更します。</span><span class="sxs-lookup"><span data-stu-id="96f59-217">Modify your desktop application to find and process the shared file.</span></span> <span data-ttu-id="96f59-218">この例では、UWP アプリには、ローカル アプリ データ フォルダーに共有ファイルが格納されます。</span><span class="sxs-lookup"><span data-stu-id="96f59-218">In this example, the UWP app stored the shared file in the local app data folder.</span></span> <span data-ttu-id="96f59-219">そのため、そのフォルダーからプル写真に[WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)デスクトップ アプリケーションを変更しますします。</span><span class="sxs-lookup"><span data-stu-id="96f59-219">Therefore, we would modify the [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo) desktop application to pull photos from that folder.</span></span>

```csharp
Photos.Path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
```

<span data-ttu-id="96f59-220">ユーザーが開くにはデスクトップ アプリケーションのインスタンスが既に存在するのも[FileSystemWatcher](https://docs.microsoft.com/dotnet/api/system.io.filesystemwatcher?view=netframework-4.7.2)イベントを処理し、ファイルの場所にパスを渡すします可能性があります。</span><span class="sxs-lookup"><span data-stu-id="96f59-220">For instances of the desktop application that are already open by the user, we might also handle the [FileSystemWatcher](https://docs.microsoft.com/dotnet/api/system.io.filesystemwatcher?view=netframework-4.7.2) event and pass in the path to the file location.</span></span> <span data-ttu-id="96f59-221">これにより、開いているデスクトップ アプリケーションのインスタンスに、共有の写真が表示されます。</span><span class="sxs-lookup"><span data-stu-id="96f59-221">That way any open instances of the desktop application will show the shared photo.</span></span>

```csharp
...

   FileSystemWatcher watcher = new FileSystemWatcher(Photos.Path);

...

private void Watcher_Created(object sender, FileSystemEventArgs e)
{
    // new file got created, adding it to the list
    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
    {
        if (File.Exists(e.FullPath))
        {
            ImageFile item = new ImageFile(e.FullPath);
            Photos.Insert(0, item);
            PhotoListBox.SelectedIndex = 0;
            CurrentPhoto.Source = (BitmapSource)item.Image;
        }
    }));
}

```

## <a name="create-a-background-task"></a><span data-ttu-id="96f59-222">バックグラウンド タスクを作成する</span><span class="sxs-lookup"><span data-stu-id="96f59-222">Create a background task</span></span>

<span data-ttu-id="96f59-223">バックグラウンド タスクを追加して、アプリが一時停止されているときでもコードを実行できます。</span><span class="sxs-lookup"><span data-stu-id="96f59-223">You add a background task to run code even when the app is suspended.</span></span> <span data-ttu-id="96f59-224">バックグラウンド タスクは、ユーザーの操作を必要としない小さなタスクに最適です。</span><span class="sxs-lookup"><span data-stu-id="96f59-224">Background tasks are great for small tasks that don't require the user interaction.</span></span> <span data-ttu-id="96f59-225">たとえば、タスクはメールのダウンロード、受信チャット メッセージに関するトースト通知の表示、システムの状態の変化に対する対応を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="96f59-225">For example, your task can download mail, show a toast notification about an incoming chat message, or react to a change in a system condition.</span></span>

<span data-ttu-id="96f59-226">バック グラウンド タスクを登録する WPF サンプル アプリケーションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="96f59-226">Here's a WPF sample application that registers a background task.</span></span>

![バックグラウンド タスク](images/desktop-to-uwp/sample-background-task.png)

<span data-ttu-id="96f59-228">タスクは http 要求を行い、要求が応答を返すのにかかる時間を測定します。</span><span class="sxs-lookup"><span data-stu-id="96f59-228">The task makes an http request and measures the time that it takes for the request to return a response.</span></span> <span data-ttu-id="96f59-229">タスクはさらに興味深いものと考えられますが、このサンプルはバックグラウンド タスクの基本的なしくみを学習するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="96f59-229">Your tasks will likely be much more interesting, but this sample is great for learning the basic mechanics of a background task.</span></span>

<span data-ttu-id="96f59-230">完全なサンプルを参照してください。[次に](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask)します。</span><span class="sxs-lookup"><span data-stu-id="96f59-230">See the complete sample [here](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask).</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="96f59-231">設計パターン</span><span class="sxs-lookup"><span data-stu-id="96f59-231">The design pattern</span></span>

<span data-ttu-id="96f59-232">バックグラウンド サービスを作成するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="96f59-232">To create a background service, do these things:</span></span>

<span data-ttu-id="96f59-233">:1: [バックグラウンド タスクの実装](#implement-task)</span><span class="sxs-lookup"><span data-stu-id="96f59-233">:one: [Implement the background task](#implement-task)</span></span>

<span data-ttu-id="96f59-234">:2: [バックグラウンド タスクの構成](#configure-background-task)</span><span class="sxs-lookup"><span data-stu-id="96f59-234">:two: [Configure the background task](#configure-background-task)</span></span>

<span data-ttu-id="96f59-235">:3: [バックグラウンド タスクの登録](#register-background-task)</span><span class="sxs-lookup"><span data-stu-id="96f59-235">:three: [Register the background task](#register-background-task)</span></span>

<a id="implement-task" />

### <a name="implement-the-background-task"></a><span data-ttu-id="96f59-236">バックグラウンド タスクの実装</span><span class="sxs-lookup"><span data-stu-id="96f59-236">Implement the background task</span></span>

<span data-ttu-id="96f59-237">Windows ランタイム コンポーネント プロジェクトにコードを追加することで、バックグラウンド タスクを実装します。</span><span class="sxs-lookup"><span data-stu-id="96f59-237">Implement the background task by adding code to a Windows Runtime component project.</span></span>

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

### <a name="configure-the-background-task"></a><span data-ttu-id="96f59-238">バックグラウンド タスクの構成</span><span class="sxs-lookup"><span data-stu-id="96f59-238">Configure the background task</span></span>

<span data-ttu-id="96f59-239">マニフェスト デザイナーで、ソリューションにパッケージ プロジェクトの**package.appxmanifest**ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="96f59-239">In the manifest designer, open the **package.appxmanifest** file of the Packaging project in your solution.</span></span>

<span data-ttu-id="96f59-240">**[宣言]** タブで、**[バックグラウンド タスク]** 宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-240">In the **Declarations** tab, add a **Background Tasks** declaration.</span></span>

![バックグラウンド タスクのオプション](images/desktop-to-uwp/background-task-option.png)

<span data-ttu-id="96f59-242">次に、必要なプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="96f59-242">Then, choose the desired properties.</span></span> <span data-ttu-id="96f59-243">サンプルでは、**Timer** プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="96f59-243">Our sample uses the **Timer** property.</span></span>

![Timer プロパティ](images/desktop-to-uwp/timer-property.png)

<span data-ttu-id="96f59-245">バックグラウンド タスクを実装する Windows ランタイム コンポーネントでクラスの完全修飾名を指定します。</span><span class="sxs-lookup"><span data-stu-id="96f59-245">Provide the fully qualified name of the class in your Windows Runtime Component that implements the background task.</span></span>

![Timer プロパティ](images/desktop-to-uwp/background-task-entry-point.png)

<a id="register-background-task" />

### <a name="register-the-background-task"></a><span data-ttu-id="96f59-247">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="96f59-247">Register the background task</span></span>

<span data-ttu-id="96f59-248">バックグラウンド タスクを登録するデスクトップ アプリケーション プロジェクトにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="96f59-248">Add code to your desktop application project that registers the background task.</span></span>

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

## <a name="support-and-feedback"></a><span data-ttu-id="96f59-249">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="96f59-249">Support and feedback</span></span>

**<span data-ttu-id="96f59-250">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="96f59-250">Find answers to your questions</span></span>**

<span data-ttu-id="96f59-251">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="96f59-251">Have questions?</span></span> <span data-ttu-id="96f59-252">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="96f59-252">Ask us on Stack Overflow.</span></span> <span data-ttu-id="96f59-253">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="96f59-253">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="96f59-254">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="96f59-254">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="96f59-255">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="96f59-255">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="96f59-256">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96f59-256">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
