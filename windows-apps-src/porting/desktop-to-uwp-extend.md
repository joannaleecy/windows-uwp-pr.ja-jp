---
Description: Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張
Search.Product: eADQiWindows 10XVcnh
title: Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張
ms.date: 06/08/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 2d1fac6d735d4f6915dea1af531dffa666607fe3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641707"
---
# <a name="extend-your-desktop-application-with-modern-uwp-components"></a><span data-ttu-id="d19da-104">最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張</span><span class="sxs-lookup"><span data-stu-id="d19da-104">Extend your desktop application with modern UWP components</span></span>

<span data-ttu-id="d19da-105">一部の Windows 10 エクスペリエンス (タッチ対応 UI ページなど) は、最新のアプリ コンテナー内で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d19da-105">Some Windows 10 experiences (For example: a touch-enabled UI page) must run inside of a modern app container .</span></span> <span data-ttu-id="d19da-106">こうしたエクスペリエンスを追加するには、UWP プロジェクトと Windows ランタイム コンポーネントを使ってデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="d19da-106">If you want to add these experiences, extend your desktop application with UWP projects and Windows Runtime Components.</span></span>

<span data-ttu-id="d19da-107">多くの場合、デスクトップ アプリケーションから直接 Windows ランタイム Api を呼び出し、そのため、このガイドを確認する前に表示[Windows 10 の強化](desktop-to-uwp-enhance.md)します。</span><span class="sxs-lookup"><span data-stu-id="d19da-107">In many cases you can call Windows Runtime APIs directly from your desktop application, so before you review this guide, see [Enhance for Windows 10](desktop-to-uwp-enhance.md).</span></span>

>[!NOTE]
><span data-ttu-id="d19da-108">このガイドでは、お客様のデスクトップ アプリケーションの Windows アプリ パッケージを作成したことを前提としています。</span><span class="sxs-lookup"><span data-stu-id="d19da-108">This guide assumes that you've created a Windows app package for your desktop application.</span></span> <span data-ttu-id="d19da-109">これはまだ完了していない場合を参照してください。[デスクトップ アプリケーションをパッケージ化](desktop-to-uwp-root.md)します。</span><span class="sxs-lookup"><span data-stu-id="d19da-109">If you haven't yet done this, see [Package desktop applications](desktop-to-uwp-root.md).</span></span>

<span data-ttu-id="d19da-110">準備ができたら始めましょう。</span><span class="sxs-lookup"><span data-stu-id="d19da-110">If you're ready, let's start.</span></span>

<a id="setup" />

## <a name="first-setup-your-solution"></a><span data-ttu-id="d19da-111">まず、ソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="d19da-111">First, setup your Solution</span></span>

<span data-ttu-id="d19da-112">UWP プロジェクトとランタイム コンポーネントを 1 つ以上ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-112">Add one or more UWP projects and runtime components to your solution.</span></span>

<span data-ttu-id="d19da-113">**Windows アプリケーション パッケージ プロジェクト**とデスクトップ アプリケーションへの参照が含まれるソリューションから始めます。</span><span class="sxs-lookup"><span data-stu-id="d19da-113">Start with a solution that contains a **Windows Application Packaging Project** with a reference to your desktop application.</span></span>

<span data-ttu-id="d19da-114">次の画像は、ソリューションの例を示しています。</span><span class="sxs-lookup"><span data-stu-id="d19da-114">This image shows an example solution.</span></span>

![開始プロジェクトを拡張する](images/desktop-to-uwp/extend-start-project.png)

<span data-ttu-id="d19da-116">場合は、ソリューションには、パッケージのプロジェクトが含まれていないを参照してください。 [Visual Studio を使用して、デスクトップ アプリケーションをパッケージ化](desktop-to-uwp-packaging-dot-net.md)します。</span><span class="sxs-lookup"><span data-stu-id="d19da-116">If your solution doesn't contain a packaging project, see [Package your desktop application by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

### <a name="configure-the-desktop-application"></a><span data-ttu-id="d19da-117">デスクトップ アプリケーションを構成します。</span><span class="sxs-lookup"><span data-stu-id="d19da-117">Configure the desktop application</span></span>

<span data-ttu-id="d19da-118">デスクトップ アプリケーションの Windows ランタイム Api を呼び出すために必要なファイルへの参照を確認します。</span><span class="sxs-lookup"><span data-stu-id="d19da-118">Make sure that your desktop application has references to the files that you need to call Windows Runtime APIs.</span></span>

<span data-ttu-id="d19da-119">これを行うには、次を参照してください。、[プロジェクトを最初に、セットアップ](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project)」の「 [Windows 10 のデスクトップ アプリケーションの拡張](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project)します。</span><span class="sxs-lookup"><span data-stu-id="d19da-119">To do this, see the [First, setup your project](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project) section of the topic [Enhance your desktop application for Windows 10](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project).</span></span>

### <a name="add-a-uwp-project"></a><span data-ttu-id="d19da-120">UWP プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="d19da-120">Add a UWP project</span></span>

<span data-ttu-id="d19da-121">ソリューションに **[空白のアプリ (ユニバーサル Windows)]** を追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-121">Add a **Blank App (Universal Windows)** to your solution.</span></span>

<span data-ttu-id="d19da-122">ここでは、最新の XAML UI をビルドするか、UWP プロセス内でのみ実行される API を使います。</span><span class="sxs-lookup"><span data-stu-id="d19da-122">This is where you'll build a modern XAML UI or use APIs that run only within a UWP process.</span></span>

![UWP プロジェクト](images/desktop-to-uwp/add-uwp-project-to-solution.png)

<span data-ttu-id="d19da-124">パッケージ プロジェクトで、**[アプリケーション]** ノードを右クリックして **[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d19da-124">In your packaging project, right-click the **Applications** node, and then click **Add Reference**.</span></span>

![UWP プロジェクトを参照する](images/desktop-to-uwp/add-uwp-project-reference.png)

<span data-ttu-id="d19da-126">次に、UWP プロジェクトに参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-126">Then, add a reference the UWP project.</span></span>

![UWP プロジェクトを参照する](images/desktop-to-uwp/choose-uwp-project.png)

<span data-ttu-id="d19da-128">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d19da-128">Your solution will look something like this:</span></span>

![UWP プロジェクトのあるソリューション](images/desktop-to-uwp/uwp-project-reference.png)

### <a name="optional-add-a-windows-runtime-component"></a><span data-ttu-id="d19da-130">(省略可能) Windows ランタイム コンポーネントを追加する</span><span class="sxs-lookup"><span data-stu-id="d19da-130">(Optional) Add a Windows Runtime Component</span></span>

<span data-ttu-id="d19da-131">いくつかのシナリオでは、Windows ランタイム コンポーネントにコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d19da-131">To accomplish some scenarios, you'll have to add code to a Windows Runtime Component.</span></span>

![ランタイム コンポーネントのアプリ サービス](images/desktop-to-uwp/add-runtime-component.png)

<span data-ttu-id="d19da-133">次に、UWP プロジェクトからランタイム コンポーネントに参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-133">Then, from your UWP project, add a reference to the runtime component.</span></span> <span data-ttu-id="d19da-134">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d19da-134">Your solution will look something like this:</span></span>

![ランタイム コンポーネント参照](images/desktop-to-uwp/runtime-component-reference.png)

### <a name="build-your-solution"></a><span data-ttu-id="d19da-136">ソリューションを構築します。</span><span class="sxs-lookup"><span data-stu-id="d19da-136">Build your solution</span></span>

<span data-ttu-id="d19da-137">エラーが表示されないことを確認するソリューションをビルドします。</span><span class="sxs-lookup"><span data-stu-id="d19da-137">Build your solution to ensure that no errors appear.</span></span> <span data-ttu-id="d19da-138">エラーが発生した場合は開きます**Configuration Manager**プロジェクトのターゲット プラットフォームが同じことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="d19da-138">If you receive errors, open **Configuration Manager** and ensure that your projects target the same platform.</span></span>

![構成マネージャー](images/desktop-to-uwp/config-manager.png)

<span data-ttu-id="d19da-140">UWP プロジェクトとランタイム コンポーネントで行うことができる操作をいくつか見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="d19da-140">Let's take a look at a few things you can do with your UWP projects and runtime components.</span></span>

## <a name="show-a-modern-xaml-ui"></a><span data-ttu-id="d19da-141">最新の XAML UI を表示する</span><span class="sxs-lookup"><span data-stu-id="d19da-141">Show a modern XAML UI</span></span>

<span data-ttu-id="d19da-142">アプリケーション フローの一環として、最新の XAML ベースのユーザー インターフェイスをデスクトップ アプリケーションに組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d19da-142">As part of your application flow, you can incorporate modern XAML-based user interfaces into your desktop application.</span></span> <span data-ttu-id="d19da-143">これらのユーザー インターフェイスは、さまざまな画面サイズと解像度に適応し、タッチや手描きなどの最新の対話モデルをサポートする性質を備えています。</span><span class="sxs-lookup"><span data-stu-id="d19da-143">These user interfaces are naturally adaptive to different screen sizes and resolutions and support modern interactive models such as touch and ink.</span></span>

<span data-ttu-id="d19da-144">たとえば、少量の XAML マークアップを使用して、地図関連の強力な視覚化機能をユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="d19da-144">For example, with a small amount of XAML markup, you can give users with powerful map-related visualization features.</span></span>

<span data-ttu-id="d19da-145">次の画像に、マップ コントロールを含む XAML ベースの最新の UI を表示している Windows フォーム アプリケーションを示しています。</span><span class="sxs-lookup"><span data-stu-id="d19da-145">This image shows a Windows Forms application that opens a XAML-based modern UI that contains a map control.</span></span>

![アダプティブ デザイン](images/desktop-to-uwp/extend-xaml-ui.png)

>[!NOTE]
><span data-ttu-id="d19da-147">この例では、UWP プロジェクトをソリューションに追加することで、XAML UI を示します。</span><span class="sxs-lookup"><span data-stu-id="d19da-147">This example shows a XAML UI by adding a UWP project to the solution.</span></span> <span data-ttu-id="d19da-148">デスクトップ アプリケーションで XAML の Ui を表示する場合は、安定したサポートされているアプローチです。</span><span class="sxs-lookup"><span data-stu-id="d19da-148">That is the stable supported approach to showing XAML UIs in a desktop application.</span></span> <span data-ttu-id="d19da-149">代わりに、この方法では、XAML の島を使用して、デスクトップ アプリケーションに直接 UWP XAML コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-149">The alternative to this approach is to add UWP XAML controls directly to your desktop application by using a XAML Island.</span></span> <span data-ttu-id="d19da-150">XAML アイランドは、現在開発者プレビューとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="d19da-150">XAML Islands are currently available as a developer preview.</span></span> <span data-ttu-id="d19da-151">実際に試してみて、プロトタイプのコードで今すぐするを勧めしますが、使用することに実稼働コードでこの時点でをしないでください。</span><span class="sxs-lookup"><span data-stu-id="d19da-151">Although we encourage you to try them out in your own prototype code now, we do not recommend that you use them in production code at this time.</span></span> <span data-ttu-id="d19da-152">これらの Api とコントロールが成熟し、将来のリリースの Windows を安定化を続けます。</span><span class="sxs-lookup"><span data-stu-id="d19da-152">These APIs and controls will continue to mature and stabilize in future Windows releases.</span></span> <span data-ttu-id="d19da-153">XAML 諸島の詳細については、次を参照してください[デスクトップ アプリケーションでの UWP コントロール。](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)</span><span class="sxs-lookup"><span data-stu-id="d19da-153">To learn more about XAML Islands, see [UWP controls in desktop applications](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="d19da-154">設計パターン</span><span class="sxs-lookup"><span data-stu-id="d19da-154">The design pattern</span></span>

<span data-ttu-id="d19da-155">XAML ベースの UI を表示するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="d19da-155">To show a XAML-based UI, do these things:</span></span>

<span data-ttu-id="d19da-156">: 1 つ。[ソリューションをセットアップします。](#solution-setup)</span><span class="sxs-lookup"><span data-stu-id="d19da-156">:one: [Setup your Solution](#solution-setup)</span></span>

<span data-ttu-id="d19da-157">: 2。[XAML UI を作成します。](#xaml-UI)</span><span class="sxs-lookup"><span data-stu-id="d19da-157">:two: [Create a XAML UI](#xaml-UI)</span></span>

<span data-ttu-id="d19da-158">: 3。[プロトコルの拡張機能を UWP プロジェクトに追加します。](#add-a-protocol-extension)</span><span class="sxs-lookup"><span data-stu-id="d19da-158">:three: [Add a protocol extension to the UWP project](#add-a-protocol-extension)</span></span>

<span data-ttu-id="d19da-159">: 4。[UWP アプリ、デスクトップ アプリを起動します。](#start)</span><span class="sxs-lookup"><span data-stu-id="d19da-159">:four: [Start the UWP app from your desktop app](#start)</span></span>

<span data-ttu-id="d19da-160">: 5。[UWP プロジェクトでのページを表示します。](#parse)</span><span class="sxs-lookup"><span data-stu-id="d19da-160">:five: [In the UWP project, show the page that you want](#parse)</span></span>

<a id="solution-setup" />

### <a name="setup-your-solution"></a><span data-ttu-id="d19da-161">ソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="d19da-161">Setup your Solution</span></span>

<span data-ttu-id="d19da-162">ソリューションのセットアップ方法に関する一般的なガイダンスについては、このガイドの冒頭の「[まず、ソリューションをセットアップする](#setup)」セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="d19da-162">For general guidance on how to set your solution up, see the [First, setup your Solution](#setup) section at the beginning of this guide.</span></span>

<span data-ttu-id="d19da-163">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d19da-163">Your solution would look something like this:</span></span>

![XAML UI ソリューション](images/desktop-to-uwp/xaml-ui-solution.png)

<span data-ttu-id="d19da-165">この例では、Windows フォーム プロジェクトは **Landmarks** という名前で、XAML UI を含む UWP プロジェクトは **MapUI** という名前です。</span><span class="sxs-lookup"><span data-stu-id="d19da-165">In this example, the Windows Forms project is named **Landmarks** and the UWP project that contains the XAML UI is named **MapUI**.</span></span>

<a id="xaml-UI" />

### <a name="create-a-xaml-ui"></a><span data-ttu-id="d19da-166">XAML UI の作成</span><span class="sxs-lookup"><span data-stu-id="d19da-166">Create a XAML UI</span></span>

<span data-ttu-id="d19da-167">XAML UI を UWP プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-167">Add a XAML UI to your UWP project.</span></span> <span data-ttu-id="d19da-168">基本的なマップの XAML を次に示します。</span><span class="sxs-lookup"><span data-stu-id="d19da-168">Here's the XAML for a basic map.</span></span>

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

### <a name="add-a-protocol-extension"></a><span data-ttu-id="d19da-169">プロトコル拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="d19da-169">Add a protocol extension</span></span>

<span data-ttu-id="d19da-170">**ソリューション エクスプ ローラー**、オープン、 **package.appxmanifest**パッケージ プロジェクト、ソリューション内のファイルし、この拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-170">In **Solution Explorer**, open the **package.appxmanifest** file of the Packaging project in your solution, and add this extension.</span></span>

```xml
<Extensions>
  <uap:Extension Category="windows.protocol" Executable="MapUI.exe" EntryPoint="MapUI.App">
    <uap:Protocol Name="xamluidemo" />
  </uap:Extension>
</Extensions>
```

<span data-ttu-id="d19da-171">プロトコルに名前を付けて、UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="d19da-171">Give the protocol a name, provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span>

<span data-ttu-id="d19da-172">デザイナーで **package.appxmanifest** 開き、**[宣言]** タブを選んで、そこで拡張機能を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="d19da-172">You can also open the **package.appxmanifest** in the designer, choose the **Declarations** tab, and then add the extension there.</span></span>

![[宣言] タブ](images/desktop-to-uwp/protocol-properties.png)

> [!NOTE]
> <span data-ttu-id="d19da-174">マップ コントロールはインターネットからデータをダウンロードします。そのため、マップ コントロールを使用する場合は、"インターネット クライアント" 機能もマニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d19da-174">Map controls download data from the internet so if you use one, you'll have to add the "internet client" capability to your manifest as well.</span></span>

<a id="start" />

### <a name="start-the-uwp-app"></a><span data-ttu-id="d19da-175">UWP アプリを起動する</span><span class="sxs-lookup"><span data-stu-id="d19da-175">Start the UWP app</span></span>

<span data-ttu-id="d19da-176">まず、デスクトップ アプリケーションから、プロトコル名と UWP アプリに渡すパラメーターが含まれた [URI](https://msdn.microsoft.com/library/system.uri.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="d19da-176">First, from your desktop application, create a [Uri](https://msdn.microsoft.com/library/system.uri.aspx) that includes the protocol name and any parameters you want to pass into the UWP app.</span></span> <span data-ttu-id="d19da-177">次に、[LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d19da-177">Then, call the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) method.</span></span>

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

### <a name="parse-parameters-and-show-a-page"></a><span data-ttu-id="d19da-178">パラメーターを解析してページを表示する</span><span class="sxs-lookup"><span data-stu-id="d19da-178">Parse parameters and show a page</span></span>

<span data-ttu-id="d19da-179">UWP プロジェクトの **App** クラスで、**OnActivated** イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="d19da-179">In the **App** class of your UWP project, override the **OnActivated** event handler.</span></span> <span data-ttu-id="d19da-180">アプリがプロトコルによってアクティブ化されている場合は、パラメーターを解析して目的のページを開きます。</span><span class="sxs-lookup"><span data-stu-id="d19da-180">If the app is activated by your protocol, parse the parameters and then open the page that you want.</span></span>

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

<span data-ttu-id="d19da-181">XAML ページの背後にあるコードでは、オーバーライド、``OnNavigatedTo``パラメーターを使用するメソッドがページに渡されます。</span><span class="sxs-lookup"><span data-stu-id="d19da-181">In the code behind your XAML page, override the ``OnNavigatedTo`` method to use the parameters passed into the page.</span></span> <span data-ttu-id="d19da-182">この場合、このページに渡された緯度と経度を使用してマップに場所を表示します。</span><span class="sxs-lookup"><span data-stu-id="d19da-182">In this case, we'll use the latitude and longitude that were passed into this page to show a location in a map.</span></span>

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

## <a name="making-your-desktop-application-a-share-target"></a><span data-ttu-id="d19da-183">デスクトップ アプリケーションを共有ターゲットにする</span><span class="sxs-lookup"><span data-stu-id="d19da-183">Making your desktop application a share target</span></span>

<span data-ttu-id="d19da-184">デスクトップ アプリケーションを共有ターゲットにすることで、共有をサポートしている他のアプリのデータ (画像など) をユーザーが簡単に共有できるようになります。</span><span class="sxs-lookup"><span data-stu-id="d19da-184">You can make your desktop application a share target so that users can easily share data such as pictures from other apps that support sharing.</span></span>

<span data-ttu-id="d19da-185">たとえば、ユーザーは、Microsoft Edge、写真アプリからの画像を共有するアプリケーションを選択できます。</span><span class="sxs-lookup"><span data-stu-id="d19da-185">For example, users could choose your application to share pictures from Microsoft Edge, the Photos app.</span></span> <span data-ttu-id="d19da-186">ここで、その機能を持つ WPF サンプル アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="d19da-186">Here's a WPF sample application that has that capability.</span></span>

![共有ターゲット](images/desktop-to-uwp/share-target.png)<span data-ttu-id="d19da-188">.</span><span class="sxs-lookup"><span data-stu-id="d19da-188">.</span></span>

<span data-ttu-id="d19da-189">完全なサンプルを参照してください[ここ。](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/ShareTarget)</span><span class="sxs-lookup"><span data-stu-id="d19da-189">See the complete sample [here](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/ShareTarget)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="d19da-190">設計パターン</span><span class="sxs-lookup"><span data-stu-id="d19da-190">The design pattern</span></span>

<span data-ttu-id="d19da-191">アプリケーションを共有ターゲットにするには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="d19da-191">To make your application a share target, do these things:</span></span>

<span data-ttu-id="d19da-192">: 1 つ。[共有ターゲットの拡張機能を追加します。](#share-extension)</span><span class="sxs-lookup"><span data-stu-id="d19da-192">:one: [Add a share target extension](#share-extension)</span></span>

<span data-ttu-id="d19da-193">: 2。[OnShareTargetActivated イベント ハンドラーをオーバーライドします。](#override)</span><span class="sxs-lookup"><span data-stu-id="d19da-193">:two: [Override the OnShareTargetActivated event handler](#override)</span></span>

<span data-ttu-id="d19da-194">: 3。[拡張機能のデスクトップ、UWP プロジェクトを追加します。](#desktop-extensions)</span><span class="sxs-lookup"><span data-stu-id="d19da-194">:three: [Add desktop extensions to the UWP project](#desktop-extensions)</span></span>

<span data-ttu-id="d19da-195">: 4。[完全信頼プロセスの拡張機能を追加します。](#full-trust)</span><span class="sxs-lookup"><span data-stu-id="d19da-195">:four: [Add the full trust process extension](#full-trust)</span></span>

<span data-ttu-id="d19da-196">: 5。[共有のファイルを取得するデスクトップ アプリケーションを変更します。](#modify-desktop)</span><span class="sxs-lookup"><span data-stu-id="d19da-196">:five: [Modify the desktop application to get the shared file](#modify-desktop)</span></span>

<a id="share-extension" />

<span data-ttu-id="d19da-197">次の手順</span><span class="sxs-lookup"><span data-stu-id="d19da-197">The following steps</span></span>  

### <a name="add-a-share-target-extension"></a><span data-ttu-id="d19da-198">共有ターゲットの拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="d19da-198">Add a share target extension</span></span>

<span data-ttu-id="d19da-199">**ソリューション エクスプ ローラー**、オープン、 **package.appxmanifest**パッケージのファイルがソリューションにプロジェクトし、共有ターゲットの拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-199">In **Solution Explorer**, open the **package.appxmanifest** file of the Packaging project in your solution and add the share target extension.</span></span>

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

<span data-ttu-id="d19da-200">UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="d19da-200">Provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span> <span data-ttu-id="d19da-201">このマークアップは、UWP アプリの実行可能ファイルの名前がある前提としています。`ShareTarget.exe`します。</span><span class="sxs-lookup"><span data-stu-id="d19da-201">This markup assumes that the name of the executable for your UWP app is `ShareTarget.exe`.</span></span>

<span data-ttu-id="d19da-202">アプリとの間で共有できるようにするファイルの種類を指定することも必要です。</span><span class="sxs-lookup"><span data-stu-id="d19da-202">You'll also have to specify what types of files can be shared with your app.</span></span> <span data-ttu-id="d19da-203">この例で行っています、 [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)ビットマップの共有ターゲット イメージのでデスクトップ アプリケーション`Bitmap`サポートされているファイルの種類。</span><span class="sxs-lookup"><span data-stu-id="d19da-203">In this example, we are making the [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo) desktop application a share target for bitmap images so we specify `Bitmap` for the supported file type.</span></span>

<a id="override" />

### <a name="override-the-onsharetargetactivated-event-handler"></a><span data-ttu-id="d19da-204">OnShareTargetActivated イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="d19da-204">Override the OnShareTargetActivated event handler</span></span>

<span data-ttu-id="d19da-205">上書き、 **OnShareTargetActivated**内のイベント ハンドラー、**アプリ**UWP プロジェクトのクラス。</span><span class="sxs-lookup"><span data-stu-id="d19da-205">Override the **OnShareTargetActivated** event handler in the **App** class of your UWP project.</span></span>

<span data-ttu-id="d19da-206">このイベント ハンドラーは、ユーザーがファイルを共有するためにアプリを選択するときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="d19da-206">This event handler is called when users choose your app to share their files.</span></span>

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

<span data-ttu-id="d19da-207">このコードでは、アプリのローカル ストレージ フォルダーに、ユーザーが共有されているイメージを保存します。</span><span class="sxs-lookup"><span data-stu-id="d19da-207">In this code, we save the image that is being shared by the user into a apps local storage folder.</span></span> <span data-ttu-id="d19da-208">後でその同じフォルダーからイメージをプルするデスクトップ アプリケーションを変更します。</span><span class="sxs-lookup"><span data-stu-id="d19da-208">Later, we'll modify the desktop application to pull images from that same folder.</span></span> <span data-ttu-id="d19da-209">UWP アプリと同じパッケージに含まれているために、デスクトップ アプリケーションはことで実現できます。</span><span class="sxs-lookup"><span data-stu-id="d19da-209">The desktop application can do that because it is included in the same package as the UWP app.</span></span>

<a id="desktop-extensions" />

### <a name="add-desktop-extensions-to-the-uwp-project"></a><span data-ttu-id="d19da-210">拡張機能のデスクトップ、UWP プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-210">Add desktop extensions to the UWP project</span></span>

<span data-ttu-id="d19da-211">追加、 **UWP 用 Windows デスクトップの拡張機能**UWP アプリ プロジェクトを拡張します。</span><span class="sxs-lookup"><span data-stu-id="d19da-211">Add the **Windows Desktop Extensions for the UWP** extension to the UWP app project.</span></span>

![デスクトップ拡張機能](images/desktop-to-uwp/desktop-extensions.png)

<a id="full-trust" />

### <a name="add-the-full-trust-process-extension"></a><span data-ttu-id="d19da-213">完全信頼プロセスの拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-213">Add the full trust process extension</span></span>

<span data-ttu-id="d19da-214">**ソリューション エクスプ ローラー**、オープン、 **package.appxmanifest**パッケージ プロジェクト、ソリューション内のファイルし、これを追加すること、共有ターゲットの拡張機能の横にある完全信頼プロセスの拡張機能を追加ファイルの前。</span><span class="sxs-lookup"><span data-stu-id="d19da-214">In **Solution Explorer**, open the **package.appxmanifest** file of the Packaging project in your solution, and then add the full trust process extension next to the share target extension that you add this file earlier.</span></span>

```xml
<Extensions>
  ...
      <desktop:Extension Category="windows.fullTrustProcess" Executable="PhotoStoreDemo\PhotoStoreDemo.exe" />
  ...
</Extensions>  
```

<span data-ttu-id="d19da-215">この拡張機能は、ファイル共有が希望されるデスクトップ アプリケーションを起動する UWP アプリを有効になります。</span><span class="sxs-lookup"><span data-stu-id="d19da-215">This extension will enable the UWP app to start the desktop application to which you would like the share a file.</span></span> <span data-ttu-id="d19da-216">実行可能ファイルの例では、言及、 [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)デスクトップ アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="d19da-216">In example, we refer to the executable of the [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo) desktop application.</span></span>

<a id="modify-desktop" />

### <a name="modify-the-desktop-application-to-get-the-shared-file"></a><span data-ttu-id="d19da-217">共有のファイルを取得するデスクトップ アプリケーションを変更します。</span><span class="sxs-lookup"><span data-stu-id="d19da-217">Modify the desktop application to get the shared file</span></span>

<span data-ttu-id="d19da-218">見つけて共有ファイルを処理するデスクトップ アプリケーションを変更します。</span><span class="sxs-lookup"><span data-stu-id="d19da-218">Modify your desktop application to find and process the shared file.</span></span> <span data-ttu-id="d19da-219">この例では、UWP アプリは、データのローカルのアプリ フォルダーに共有ファイルを格納します。</span><span class="sxs-lookup"><span data-stu-id="d19da-219">In this example, the UWP app stored the shared file in the local app data folder.</span></span> <span data-ttu-id="d19da-220">そのため、変更します、 [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)プル写真をそのフォルダーからのデスクトップ アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="d19da-220">Therefore, we would modify the [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo) desktop application to pull photos from that folder.</span></span>

```csharp
Photos.Path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
```

<span data-ttu-id="d19da-221">処理がありますも、ユーザーが既にあるデスクトップ アプリケーションのインスタンスを開いて、 [FileSystemWatcher](https://docs.microsoft.com/dotnet/api/system.io.filesystemwatcher?view=netframework-4.7.2)イベントとファイルの場所にパスを渡します。</span><span class="sxs-lookup"><span data-stu-id="d19da-221">For instances of the desktop application that are already open by the user, we might also handle the [FileSystemWatcher](https://docs.microsoft.com/dotnet/api/system.io.filesystemwatcher?view=netframework-4.7.2) event and pass in the path to the file location.</span></span> <span data-ttu-id="d19da-222">これにより、デスクトップ アプリケーションの開いているすべてのインスタンスは共有フォトに表示されます。</span><span class="sxs-lookup"><span data-stu-id="d19da-222">That way any open instances of the desktop application will show the shared photo.</span></span>

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

## <a name="create-a-background-task"></a><span data-ttu-id="d19da-223">バックグラウンド タスクを作成する</span><span class="sxs-lookup"><span data-stu-id="d19da-223">Create a background task</span></span>

<span data-ttu-id="d19da-224">バックグラウンド タスクを追加して、アプリが一時停止されているときでもコードを実行できます。</span><span class="sxs-lookup"><span data-stu-id="d19da-224">You add a background task to run code even when the app is suspended.</span></span> <span data-ttu-id="d19da-225">バックグラウンド タスクは、ユーザーの操作を必要としない小さなタスクに最適です。</span><span class="sxs-lookup"><span data-stu-id="d19da-225">Background tasks are great for small tasks that don't require the user interaction.</span></span> <span data-ttu-id="d19da-226">たとえば、タスクはメールのダウンロード、受信チャット メッセージに関するトースト通知の表示、システムの状態の変化に対する対応を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="d19da-226">For example, your task can download mail, show a toast notification about an incoming chat message, or react to a change in a system condition.</span></span>

<span data-ttu-id="d19da-227">バック グラウンド タスクを登録する WPF サンプル アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="d19da-227">Here's a WPF sample application that registers a background task.</span></span>

![バックグラウンド タスク](images/desktop-to-uwp/sample-background-task.png)

<span data-ttu-id="d19da-229">タスクは http 要求を行い、要求が応答を返すのにかかる時間を測定します。</span><span class="sxs-lookup"><span data-stu-id="d19da-229">The task makes an http request and measures the time that it takes for the request to return a response.</span></span> <span data-ttu-id="d19da-230">タスクはさらに興味深いものと考えられますが、このサンプルはバックグラウンド タスクの基本的なしくみを学習するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="d19da-230">Your tasks will likely be much more interesting, but this sample is great for learning the basic mechanics of a background task.</span></span>

<span data-ttu-id="d19da-231">完全なサンプルを参照してください。[ここ](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask)します。</span><span class="sxs-lookup"><span data-stu-id="d19da-231">See the complete sample [here](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask).</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="d19da-232">設計パターン</span><span class="sxs-lookup"><span data-stu-id="d19da-232">The design pattern</span></span>

<span data-ttu-id="d19da-233">バックグラウンド サービスを作成するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="d19da-233">To create a background service, do these things:</span></span>

<span data-ttu-id="d19da-234">: 1 つ。[バック グラウンド タスクを実装します。](#implement-task)</span><span class="sxs-lookup"><span data-stu-id="d19da-234">:one: [Implement the background task](#implement-task)</span></span>

<span data-ttu-id="d19da-235">: 2。[バック グラウンド タスクを構成します。](#configure-background-task)</span><span class="sxs-lookup"><span data-stu-id="d19da-235">:two: [Configure the background task](#configure-background-task)</span></span>

<span data-ttu-id="d19da-236">: 3。[バック グラウンド タスクを登録します。](#register-background-task)</span><span class="sxs-lookup"><span data-stu-id="d19da-236">:three: [Register the background task](#register-background-task)</span></span>

<a id="implement-task" />

### <a name="implement-the-background-task"></a><span data-ttu-id="d19da-237">バックグラウンド タスクの実装</span><span class="sxs-lookup"><span data-stu-id="d19da-237">Implement the background task</span></span>

<span data-ttu-id="d19da-238">Windows ランタイム コンポーネント プロジェクトにコードを追加することで、バックグラウンド タスクを実装します。</span><span class="sxs-lookup"><span data-stu-id="d19da-238">Implement the background task by adding code to a Windows Runtime component project.</span></span>

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

### <a name="configure-the-background-task"></a><span data-ttu-id="d19da-239">バックグラウンド タスクの構成</span><span class="sxs-lookup"><span data-stu-id="d19da-239">Configure the background task</span></span>

<span data-ttu-id="d19da-240">マニフェスト デザイナーで開く、 **package.appxmanifest**ソリューションのパッケージ化プロジェクトのファイル。</span><span class="sxs-lookup"><span data-stu-id="d19da-240">In the manifest designer, open the **package.appxmanifest** file of the Packaging project in your solution.</span></span>

<span data-ttu-id="d19da-241">**[宣言]** タブで、**[バックグラウンド タスク]** 宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-241">In the **Declarations** tab, add a **Background Tasks** declaration.</span></span>

![バックグラウンド タスクのオプション](images/desktop-to-uwp/background-task-option.png)

<span data-ttu-id="d19da-243">次に、必要なプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="d19da-243">Then, choose the desired properties.</span></span> <span data-ttu-id="d19da-244">サンプルでは、**Timer** プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="d19da-244">Our sample uses the **Timer** property.</span></span>

![Timer プロパティ](images/desktop-to-uwp/timer-property.png)

<span data-ttu-id="d19da-246">バックグラウンド タスクを実装する Windows ランタイム コンポーネントでクラスの完全修飾名を指定します。</span><span class="sxs-lookup"><span data-stu-id="d19da-246">Provide the fully qualified name of the class in your Windows Runtime Component that implements the background task.</span></span>

![Timer プロパティ](images/desktop-to-uwp/background-task-entry-point.png)

<a id="register-background-task" />

### <a name="register-the-background-task"></a><span data-ttu-id="d19da-248">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="d19da-248">Register the background task</span></span>

<span data-ttu-id="d19da-249">バックグラウンド タスクを登録するデスクトップ アプリケーション プロジェクトにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="d19da-249">Add code to your desktop application project that registers the background task.</span></span>

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

## <a name="support-and-feedback"></a><span data-ttu-id="d19da-250">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="d19da-250">Support and feedback</span></span>

<span data-ttu-id="d19da-251">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="d19da-251">**Find answers to your questions**</span></span>

<span data-ttu-id="d19da-252">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="d19da-252">Have questions?</span></span> <span data-ttu-id="d19da-253">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="d19da-253">Ask us on Stack Overflow.</span></span> <span data-ttu-id="d19da-254">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="d19da-254">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="d19da-255">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="d19da-255">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="d19da-256">**ご意見や機能を提案します。**</span><span class="sxs-lookup"><span data-stu-id="d19da-256">**Give feedback or make feature suggestions**</span></span>

<span data-ttu-id="d19da-257">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d19da-257">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
