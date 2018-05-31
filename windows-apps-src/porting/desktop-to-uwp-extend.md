---
author: normesta
Description: Extend your desktop application with Windows UIs and components
Search.Product: eADQiWindows 10XVcnh
title: Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張
ms.author: normesta
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ef20366092a5f284c39f4e43d4412c69b60f12fa
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1691331"
---
# <a name="extend-your-desktop-application-with-modern-uwp-components"></a><span data-ttu-id="2a6fb-103">最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張</span><span class="sxs-lookup"><span data-stu-id="2a6fb-103">Extend your desktop application with modern UWP components</span></span>

<span data-ttu-id="2a6fb-104">一部の Windows 10 エクスペリエンス (タッチ対応 UI ページなど) は、最新のアプリ コンテナー内で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-104">Some Windows 10 experiences (For example: a touch-enabled UI page) must run inside of a modern app container .</span></span> <span data-ttu-id="2a6fb-105">こうしたエクスペリエンスを追加するには、UWP プロジェクトと Windows ランタイム コンポーネントを使ってデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-105">If you want to add these experiences, extend your desktop application with UWP projects and Windows Runtime Components.</span></span>

<span data-ttu-id="2a6fb-106">多くの場合、デスクトップ アプリケーションから UWP API を直接呼び出すことができます。そのため、このガイドを確認する前に、「[Windows 10 のための拡張](desktop-to-uwp-enhance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-106">In many cases you can call UWP APIs directly from your desktop application, so before you review this guide, see [Enhance for Windows 10](desktop-to-uwp-enhance.md).</span></span>

>[!NOTE]
><span data-ttu-id="2a6fb-107">このガイドは、デスクトップ ブリッジを使用してデスクトップ アプリケーションの Windows アプリ パッケージを作成済みであることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-107">This guide assumes that you've created a Windows app package for your desktop application by using the Desktop Bridge.</span></span> <span data-ttu-id="2a6fb-108">この作業をまだ行っていない場合は、「[デスクトップ ブリッジ](desktop-to-uwp-root.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-108">If you haven't yet done this, see [Desktop Bridge](desktop-to-uwp-root.md).</span></span>

<span data-ttu-id="2a6fb-109">準備ができたら始めましょう。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-109">If you're ready, let's start.</span></span>

## <a name="first-setup-your-solution"></a><span data-ttu-id="2a6fb-110">まず、ソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="2a6fb-110">First, setup your Solution</span></span>

<span data-ttu-id="2a6fb-111">UWP プロジェクトとランタイム コンポーネントを 1 つ以上ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-111">Add one or more UWP projects and runtime components to your solution.</span></span>

<span data-ttu-id="2a6fb-112">**Windows アプリケーション パッケージ プロジェクト**とデスクトップ アプリケーションへの参照が含まれるソリューションから始めます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-112">Start with a solution that contains a **Windows Application Packaging Project** with a reference to your desktop application.</span></span>

<span data-ttu-id="2a6fb-113">次の画像は、ソリューションの例を示しています。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-113">This image shows an example solution.</span></span>

![開始プロジェクトを拡張する](images/desktop-to-uwp/extend-start-project.png)

<span data-ttu-id="2a6fb-115">ソリューションにパッケージ プロジェクトが含まれていない場合、[Visual Studio を使ったアプリのパッケージ化に関するページ](desktop-to-uwp-packaging-dot-net.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-115">If your solution doesn't contain a packaging project, see [Package your app by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

### <a name="add-a-uwp-project"></a><span data-ttu-id="2a6fb-116">UWP プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-116">Add a UWP project</span></span>

<span data-ttu-id="2a6fb-117">ソリューションに **[空白のアプリ (ユニバーサル Windows)]** を追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-117">Add a **Blank App (Universal Windows)** to your solution.</span></span>

<span data-ttu-id="2a6fb-118">ここでは、最新の XAML UI をビルドするか、UWP プロセス内でのみ実行される API を使います。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-118">This is where you'll build a modern XAML UI or use APIs that run only within a UWP process.</span></span>

![UWP プロジェクト](images/desktop-to-uwp/add-uwp-project-to-solution.png)

<span data-ttu-id="2a6fb-120">パッケージ プロジェクトで、**[アプリケーション]** ノードを右クリックして **[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-120">In your packaging project, right-click the **Applications** node, and then click **Add Reference**.</span></span>

![UWP プロジェクトを参照する](images/desktop-to-uwp/add-uwp-project-reference.png)

<span data-ttu-id="2a6fb-122">次に、UWP プロジェクトに参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-122">Then, add a reference the UWP project.</span></span>

![UWP プロジェクトを参照する](images/desktop-to-uwp/choose-uwp-project.png)

<span data-ttu-id="2a6fb-124">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-124">Your solution will look something like this:</span></span>

![UWP プロジェクトのあるソリューション](images/desktop-to-uwp/uwp-project-reference.png)

### <a name="optional-add-a-windows-runtime-component"></a><span data-ttu-id="2a6fb-126">(省略可能) Windows ランタイム コンポーネントを追加する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-126">(Optional) Add a Windows Runtime Component</span></span>

<span data-ttu-id="2a6fb-127">いくつかのシナリオでは、Windows ランタイム コンポーネントにコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-127">To accomplish some scenarios, you'll have to add code to a Windows Runtime Component.</span></span>

![ランタイム コンポーネントのアプリ サービス](images/desktop-to-uwp/add-runtime-component.png)

<span data-ttu-id="2a6fb-129">次に、UWP プロジェクトからランタイム コンポーネントに参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-129">Then, from your UWP project, add a reference to the runtime component.</span></span> <span data-ttu-id="2a6fb-130">ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-130">Your solution will look something like this:</span></span>

![ランタイム コンポーネント参照](images/desktop-to-uwp/runtime-component-reference.png)

<span data-ttu-id="2a6fb-132">UWP プロジェクトとランタイム コンポーネントで行うことができる操作をいくつか見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-132">Let's take a look at a few things you can do with your UWP projects and runtime components.</span></span>

## <a name="show-a-modern-xaml-ui"></a><span data-ttu-id="2a6fb-133">最新の XAML UI を表示する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-133">Show a modern XAML UI</span></span>

<span data-ttu-id="2a6fb-134">アプリケーション フローの一環として、最新の XAML ベースのユーザー インターフェイスをデスクトップ アプリケーションに組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-134">As part of your application flow, you can incorporate modern XAML-based user interfaces into your desktop application.</span></span> <span data-ttu-id="2a6fb-135">これらのユーザー インターフェイスは、さまざまな画面サイズと解像度に適応し、タッチや手描きなどの最新の対話モデルをサポートする性質を備えています。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-135">These user interfaces are naturally adaptive to different screen sizes and resolutions and support modern interactive models such as touch and ink.</span></span>

<span data-ttu-id="2a6fb-136">たとえば、少量の XAML マークアップを使用して、地図関連の強力な視覚化機能をユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-136">For example, with a small amount of XAML markup, you can give users with powerful map-related visualization features.</span></span>

<span data-ttu-id="2a6fb-137">次の画像に、マップ コントロールを含む XAML ベースの最新の UI を表示している VB6 アプリケーションを示しています。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-137">This image shows a VB6 application that opens a XAML-based modern UI that contains a map control.</span></span>

![アダプティブ デザイン](images/desktop-to-uwp/extend-xaml-ui.png)

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="2a6fb-139">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-139">Have a closer look at this app</span></span>

<span data-ttu-id="2a6fb-140">:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/vb6-app-with-xaml-sample/9n191ncxf2f6)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-140">:heavy_check_mark: [Get the app](https://www.microsoft.com/en-us/store/p/vb6-app-with-xaml-sample/9n191ncxf2f6)</span></span>

<span data-ttu-id="2a6fb-141">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/VB6withXaml)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-141">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/VB6withXaml)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="2a6fb-142">設計パターン</span><span class="sxs-lookup"><span data-stu-id="2a6fb-142">The design pattern</span></span>

<span data-ttu-id="2a6fb-143">XAML ベースの UI を表示するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-143">To show a XAML-based UI, do these things:</span></span>

<span data-ttu-id="2a6fb-144">:1: [そのプロジェクトにプロトコル拡張機能を追加する](#protocol)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-144">:one: [Add a protocol extension to that project](#protocol)</span></span>

<span data-ttu-id="2a6fb-145">:2: [デスクトップ アプリから UWP アプリを起動する](#start)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-145">:two: [Start the UWP app from your desktop app](#start)</span></span>

<span data-ttu-id="2a6fb-146">:3: [UWP プロジェクトで目的のページを表示する](#parse)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-146">:three: [In the UWP project, show the page that you want](#parse)</span></span>

<a id="protocol" />

### <a name="add-a-protocol-extension"></a><span data-ttu-id="2a6fb-147">プロトコル拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-147">Add a protocol extension</span></span>

<span data-ttu-id="2a6fb-148">**ソリューション エクスプ ローラー**で、UWP プロジェクトの **package.appxmanifest** ファイルを開き、この拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-148">In **Solution Explorer**, open the **package.appxmanifest** file of the UWP project in your solution, and add this extension.</span></span>

```xml
<Extensions>
      <uap:Extension
          Category="windows.protocol"
          Executable="MapUI.exe"
          EntryPoint=" MapUI.App">
        <uap:Protocol Name="desktopbridgemapsample" />
      </uap:Extension>
    </Extensions>     
```

<span data-ttu-id="2a6fb-149">プロトコルに名前を付けて、UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-149">Give the protocol a name, provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span>

<span data-ttu-id="2a6fb-150">デザイナーで **package.appxmanifest** 開き、**[宣言]** タブを選んで、そこで拡張機能を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-150">You can also open the **package.appxmanifest** in the designer, choose the **Declarations** tab, and then add the extension there.</span></span>

![[宣言] タブ](images/desktop-to-uwp/protocol-properties.png)



> [!NOTE]
> <span data-ttu-id="2a6fb-152">マップ コントロールはインターネットからデータをダウンロードします。そのため、マップ コントロールを使用する場合は、"インターネット クライアント" 機能もマニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-152">Map controls download data from the internet so if you use one, you'll have to add the "internet client" capability to your manifest as well.</span></span>

<a id="start" />

### <a name="start-the-uwp-app"></a><span data-ttu-id="2a6fb-153">UWP アプリを起動する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-153">Start the UWP app</span></span>

<span data-ttu-id="2a6fb-154">まず、デスクトップ アプリケーションから、プロトコル名と UWP アプリに渡すパラメーターが含まれた [URI](https://msdn.microsoft.com/library/system.uri.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-154">First, from your desktop application, create a [Uri](https://msdn.microsoft.com/library/system.uri.aspx) that includes the protocol name and any parameters you want to pass into the UWP app.</span></span> <span data-ttu-id="2a6fb-155">次に、[LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-155">Then, call the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) method.</span></span>

<span data-ttu-id="2a6fb-156">C# の基本的な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-156">Here's a basic example in C#.</span></span>

```csharp

private async void showMap(double lat, double lon)
{
    string str = "desktopbridgemapsample://";

    Uri uri = new Uri(str + "location?lat=" +
        lat.ToString() + "&?lon=" + lon.ToString());

    var success = await Windows.System.Launcher.LaunchUriAsync(uri);

    if (success)
    {
        // URI launched
    }
    else
    {
        // URI launch failed
    }
}
```
このサンプルでは、もう少し間接的な作業を行います。 ``LaunchMap`` という名前の VB6 で呼び出せる相互運用関数に呼び出しをラップしました。 <span data-ttu-id="2a6fb-159">この関数は C++ を使用して記述されています。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-159">That function is written by using C++.</span></span>

<span data-ttu-id="2a6fb-160">VB ブロックを次に示します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-160">Here's the VB block:</span></span>

```VB
Private Declare Function LaunchMap Lib "UWPWrappers.dll" _
  (ByVal lat As Double, ByVal lon As Double) As Boolean
 
Private Sub EiffelTower_Click()
    LaunchMap 48.858222, 2.2945
End Sub
```

<span data-ttu-id="2a6fb-161">C++ 関数を次に示します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-161">Here's the C++ function:</span></span>

```C++

DllExport bool __stdcall LaunchMap(double lat, double lon)
{
  try
  {
    String ^str = ref new String(L"desktopbridgemapsample://");
    Uri ^uri = ref new Uri(
      str + L"location?lat=" + lat.ToString() + L"&?lon=" + lon.ToString());
 
    // now launch the UWP component
    Launcher::LaunchUriAsync(uri);
  }
  catch (Exception^ ex) { return false; }
  return true;
}

```

<a id="parse" />

### <a name="parse-parameters-and-show-a-page"></a><span data-ttu-id="2a6fb-162">パラメーターを解析してページを表示する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-162">Parse parameters and show a page</span></span>

<span data-ttu-id="2a6fb-163">UWP プロジェクトの **App** クラスで、**OnActivated** イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-163">In the **App** class of your UWP project, override the **OnActivated** event handler.</span></span> <span data-ttu-id="2a6fb-164">アプリがプロトコルによってアクティブ化されている場合は、パラメーターを解析して目的のページを開きます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-164">If the app is activated by your protocol, parse the parameters and then open the page that you want.</span></span>

```C++
void App::OnActivated(Windows::ApplicationModel::Activation::IActivatedEventArgs^ e)
{
  if (e->Kind == ActivationKind::Protocol)
  {
    ProtocolActivatedEventArgs^ protocolArgs = (ProtocolActivatedEventArgs^)e;
    Uri ^uri = protocolArgs->Uri;
    if (uri->SchemeName == "desktopbridgemapsample")
    {
      Frame ^rootFrame = ref new Frame();
      Window::Current->Content = rootFrame;
      rootFrame->Navigate(TypeName(MainPage::typeid), uri->Query);
      Window::Current->Activate();
    }
  }
}
```

### <a name="similar-samples"></a><span data-ttu-id="2a6fb-165">類似のサンプル</span><span class="sxs-lookup"><span data-stu-id="2a6fb-165">Similar Samples</span></span>

[<span data-ttu-id="2a6fb-166">Northwind サンプル: UWA UI および Win32 レガシ コードのエンド ツー エンドの例</span><span class="sxs-lookup"><span data-stu-id="2a6fb-166">Northwind sample: End-to-end example for UWA UI & Win32 legacy code</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/NorthwindSample)

[<span data-ttu-id="2a6fb-167">Northwind サンプル: SQL Server に接続する UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="2a6fb-167">Northwind sample: UWP app connecting to SQL Server</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SQLServer)

## <a name="provide-services-to-other-apps"></a><span data-ttu-id="2a6fb-168">サービスを他のアプリに提供する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-168">Provide services to other apps</span></span>

<span data-ttu-id="2a6fb-169">他のアプリで利用できるサービスを追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-169">You add a service that other apps can consume.</span></span> <span data-ttu-id="2a6fb-170">たとえば、アプリの背後でデータベースが実行されている場合に、そのデータベースへの制御されたアクセスを他のアプリに提供するサービスを追加できます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-170">For example, you can add a service that gives other apps controlled access to the database behind your app.</span></span> <span data-ttu-id="2a6fb-171">バックグラウンド タスクを実装することで、デスクトップ アプリが実行されていない場合でも他のアプリからサービスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-171">By implementing a background task, apps can reach the service even if your desktop app is not running.</span></span>

<span data-ttu-id="2a6fb-172">これを実行するサンプルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-172">Here's a sample that does this.</span></span>

![アダプティブ デザイン](images/desktop-to-uwp/winforms-app-service.png)

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="2a6fb-174">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-174">Have a closer look at this app</span></span>

<span data-ttu-id="2a6fb-175">:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/winforms-appservice/9p7d9b6nk5tn)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-175">:heavy_check_mark: [Get the app](https://www.microsoft.com/en-us/store/p/winforms-appservice/9p7d9b6nk5tn)</span></span>

<span data-ttu-id="2a6fb-176">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinformsAppService)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-176">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinformsAppService)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="2a6fb-177">設計パターン</span><span class="sxs-lookup"><span data-stu-id="2a6fb-177">The design pattern</span></span>

<span data-ttu-id="2a6fb-178">サービスの提供を示すには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-178">To show provide a service, do these things:</span></span>

<span data-ttu-id="2a6fb-179">:1: [アプリ サービスを実装する](#appservice)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-179">:one: [Implement the app service](#appservice)</span></span>

<span data-ttu-id="2a6fb-180">:2: [アプリ サービスの拡張機能を追加する](#extension)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-180">:two: [Add an app service extension](#extension)</span></span>

<span data-ttu-id="2a6fb-181">:3: [アプリ サービスをテストする](#test)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-181">:three: [Test the app service](#test)</span></span>

<a id="appservice" />

### <a name="implement-the-app-service"></a><span data-ttu-id="2a6fb-182">アプリ サービスを実装する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-182">Implement the app service</span></span>

<span data-ttu-id="2a6fb-183">以下では、他のアプリからの要求を検証して処理します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-183">Here's where you'll validate and handle requests from other apps.</span></span> <span data-ttu-id="2a6fb-184">ソリューションで Windows ランタイム コンポーネントにこのコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-184">Add this code to a Windows Runtime Component in your solution.</span></span>

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

### <a name="add-an-app-service-extension-to-the-uwp-project"></a><span data-ttu-id="2a6fb-185">UWP プロジェクトにアプリ サービスの拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-185">Add an app service extension to the UWP project</span></span>

<span data-ttu-id="2a6fb-186">UWP プロジェクトの **package.appxmanifest** ファイルを開き、アプリ サービスの拡張機能を ``<Application>`` 要素に追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-186">Open the **package.appxmanifest** file of the UWP project, and add an app service extension to the ``<Application>`` element.</span></span>

```xml
<Extensions>
      <uap:Extension
          Category="windows.appService"
          EntryPoint="AppServiceComponent.AppServiceTask">
        <uap:AppService Name="com.microsoft.samples.winforms" />
      </uap:Extension>
    </Extensions>    
```
<span data-ttu-id="2a6fb-187">そのアプリ サービスに名前を付けて、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-187">Give the app service a name and provide the name of the entry point class.</span></span> <span data-ttu-id="2a6fb-188">これは、サービスを実装したクラスです。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-188">This is the class in which you implemented the service.</span></span>

<a id="test" />

### <a name="test-the-app-service"></a><span data-ttu-id="2a6fb-189">アプリ サービスをテストする</span><span class="sxs-lookup"><span data-stu-id="2a6fb-189">Test the app service</span></span>

<span data-ttu-id="2a6fb-190">別のアプリからサービスを呼び出すことにより、サービスをテストします。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-190">Test your service by calling it from another app.</span></span> <span data-ttu-id="2a6fb-191">このコードは、Windows フォーム アプリや別の UWP アプリなどのデスクトップ アプリケーションにすることができます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-191">This code can be a desktop application such as a Windows forms app or another UWP app.</span></span>

> [!NOTE]
> <span data-ttu-id="2a6fb-192">このコードは、``AppServiceConnection`` クラスの ``PackageFamilyName`` プロパティを適切に設定した場合のみ動作します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-192">This code only works if you properly set the ``PackageFamilyName`` property of the ``AppServiceConnection`` class.</span></span> <span data-ttu-id="2a6fb-193">その名前を取得するには、UWP プロジェクトで ``Windows.ApplicationModel.Package.Current.Id.FamilyName`` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-193">You can get that name by calling ``Windows.ApplicationModel.Package.Current.Id.FamilyName`` in the context of the UWP project.</span></span> <span data-ttu-id="2a6fb-194">「[App Service の作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-194">See [Create and consume an app service](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service).</span></span>

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

<span data-ttu-id="2a6fb-195">アプリ サービスについて詳しくは、「[アプリ サービスの作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-195">Learn more about app services here: [Create and consume an app service](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service).</span></span>

### <a name="similar-samples"></a><span data-ttu-id="2a6fb-196">類似のサンプル</span><span class="sxs-lookup"><span data-stu-id="2a6fb-196">Similar Samples</span></span>

[<span data-ttu-id="2a6fb-197">アプリ サービス ブリッジのサンプル</span><span class="sxs-lookup"><span data-stu-id="2a6fb-197">App service bridge sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/AppServiceBridgeSample)

[<span data-ttu-id="2a6fb-198">C++ Win32 アプリを使ったアプリ サービス ブリッジのサンプル</span><span class="sxs-lookup"><span data-stu-id="2a6fb-198">App service bridge sample with C++ win32 app</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/AppServiceBridgeSample_C%2B%2B)

[<span data-ttu-id="2a6fb-199">プッシュ通知を受け取る MFC アプリケーション</span><span class="sxs-lookup"><span data-stu-id="2a6fb-199">MFC application that receives push notifications</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/MFCwithPush)


## <a name="making-your-desktop-application-a-share-target"></a><span data-ttu-id="2a6fb-200">デスクトップ アプリケーションを共有ターゲットにする</span><span class="sxs-lookup"><span data-stu-id="2a6fb-200">Making your desktop application a share target</span></span>

<span data-ttu-id="2a6fb-201">デスクトップ アプリケーションを共有ターゲットにすることで、共有をサポートしている他のアプリのデータ (画像など) をユーザーが簡単に共有できるようになります。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-201">You can make your desktop application a share target so that users can easily share data such as pictures from other apps that support sharing.</span></span>

<span data-ttu-id="2a6fb-202">たとえば、ユーザーは、Microsoft Edge やフォト アプリから画像を共有するためにアプリを選択できます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-202">For example, users could choose your app to share pictures from Microsoft Edge, the Photos app.</span></span> <span data-ttu-id="2a6fb-203">そのような機能を備えた WPF サンプル アプリは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-203">Here's a WPF sample app that has that capability.</span></span>

![共有ターゲット](images/desktop-to-uwp/share-target.png)

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="2a6fb-205">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-205">Have a closer look at this app</span></span>

<span data-ttu-id="2a6fb-206">:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/wpf-app-as-sharetarget/9pjcjljlck37)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-206">:heavy_check_mark: [Get the app](https://www.microsoft.com/en-us/store/p/wpf-app-as-sharetarget/9pjcjljlck37)</span></span>

<span data-ttu-id="2a6fb-207">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WPFasShareTarget)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-207">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WPFasShareTarget)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="2a6fb-208">設計パターン</span><span class="sxs-lookup"><span data-stu-id="2a6fb-208">The design pattern</span></span>

<span data-ttu-id="2a6fb-209">アプリケーションを共有ターゲットにするには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-209">To make your application a share target, do these things:</span></span>

<span data-ttu-id="2a6fb-210">:1: [共有ターゲットの拡張機能を追加する](#share-extension)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-210">:one: [Add a share target extension](#share-extension)</span></span>

<span data-ttu-id="2a6fb-211">:2: [OnNavigatedTo イベント ハンドラーをオーバーライドする](#override)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-211">:two: [Override the OnNavigatedTo event handler](#override)</span></span>

<a id="share-extension" />

### <a name="add-a-share-target-extension"></a><span data-ttu-id="2a6fb-212">共有ターゲットの拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-212">Add a share target extension</span></span>

<span data-ttu-id="2a6fb-213">**ソリューション エクスプ ローラー**で、UWP プロジェクトの **package.appxmanifest** ファイルを開き、拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-213">In **Solution Explorer**, open the **package.appxmanifest** file of the UWP project in your solution and add the extension.</span></span>

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

<span data-ttu-id="2a6fb-214">UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-214">Provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span> <span data-ttu-id="2a6fb-215">アプリとの間で共有できるようにするファイルの種類を指定することも必要です。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-215">You'll also have to specify what types of files can be shared with your app.</span></span>

<a id="override" />

### <a name="override-the-onnavigatedto-event-handler"></a><span data-ttu-id="2a6fb-216">OnNavigatedTo イベント ハンドラーをオーバーライドする</span><span class="sxs-lookup"><span data-stu-id="2a6fb-216">Override the OnNavigatedTo event handler</span></span>

<span data-ttu-id="2a6fb-217">UWP プロジェクトの **App** クラスで、**OnNavigatedTo** イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-217">Override the **OnNavigatedTo** event handler in the **App** class of your UWP project.</span></span>

<span data-ttu-id="2a6fb-218">このイベント ハンドラーは、ユーザーがファイルを共有するためにアプリを選択するときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-218">This event handler is called when users choose your app to share their files.</span></span>

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

## <a name="create-a-background-task"></a><span data-ttu-id="2a6fb-219">バックグラウンド タスクを作成する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-219">Create a background task</span></span>

<span data-ttu-id="2a6fb-220">バックグラウンド タスクを追加して、アプリが一時停止されているときでもコードを実行できます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-220">You add a background task to run code even when the app is suspended.</span></span> <span data-ttu-id="2a6fb-221">バックグラウンド タスクは、ユーザーの操作を必要としない小さなタスクに最適です。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-221">Background tasks are great for small tasks that don't require the user interaction.</span></span> <span data-ttu-id="2a6fb-222">たとえば、タスクはメールのダウンロード、受信チャット メッセージに関するトースト通知の表示、システムの状態の変化に対する対応を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-222">For example, your task can download mail, show a toast notification about an incoming chat message, or react to a change in a system condition.</span></span>

<span data-ttu-id="2a6fb-223">バックグラウンド タスクを登録する WPF サンプル アプリを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-223">Here's a WPF sample app that registers a background task.</span></span>

![バックグラウンド タスク](images/desktop-to-uwp/sample-background-task.png)

<span data-ttu-id="2a6fb-225">タスクは http 要求を行い、要求が応答を返すのにかかる時間を測定します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-225">The task makes an http request and measures the time that it takes for the request to return a response.</span></span> <span data-ttu-id="2a6fb-226">タスクはさらに興味深いものと考えられますが、このサンプルはバックグラウンド タスクの基本的なしくみを学習するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-226">Your tasks will likely be much more interesting, but this sample is great for learning the basic mechanics of a background task.</span></span>

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="2a6fb-227">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="2a6fb-227">Have a closer look at this app</span></span>

<span data-ttu-id="2a6fb-228">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-228">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="2a6fb-229">設計パターン</span><span class="sxs-lookup"><span data-stu-id="2a6fb-229">The design pattern</span></span>

<span data-ttu-id="2a6fb-230">バックグラウンド サービスを作成するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-230">To create a background service, do these things:</span></span>

<span data-ttu-id="2a6fb-231">:1: [バックグラウンド タスクの実装](#implement-task)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-231">:one: [Implement the background task](#implement-task)</span></span>

<span data-ttu-id="2a6fb-232">:2: [バックグラウンド タスクの構成](#configure-background-task)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-232">:two: [Configure the background task](#configure-background-task)</span></span>

<span data-ttu-id="2a6fb-233">:3: [バックグラウンド タスクの登録](#register-background-task)</span><span class="sxs-lookup"><span data-stu-id="2a6fb-233">:three: [Register the background task](#register-background-task)</span></span>

<a id="implement-task" />

### <a name="implement-the-background-task"></a><span data-ttu-id="2a6fb-234">バックグラウンド タスクの実装</span><span class="sxs-lookup"><span data-stu-id="2a6fb-234">Implement the background task</span></span>

<span data-ttu-id="2a6fb-235">Windows ランタイム コンポーネント プロジェクトにコードを追加することで、バックグラウンド タスクを実装します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-235">Implement the background task by adding code to a Windows Runtime component project.</span></span>

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

### <a name="configure-the-background-task"></a><span data-ttu-id="2a6fb-236">バックグラウンド タスクの構成</span><span class="sxs-lookup"><span data-stu-id="2a6fb-236">Configure the background task</span></span>

<span data-ttu-id="2a6fb-237">マニフェスト デザイナーで、ソリューションの UWP プロジェクトの **package.appxmanifest** ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-237">In the manifest designer, open the **package.appxmanifest** file of the UWP project in your solution.</span></span>

<span data-ttu-id="2a6fb-238">**[宣言]** タブで、**[バックグラウンド タスク]** 宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-238">In the **Declarations** tab, add a **Background Tasks** declaration.</span></span>

![バックグラウンド タスクのオプション](images/desktop-to-uwp/background-task-option.png)

<span data-ttu-id="2a6fb-240">次に、必要なプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-240">Then, choose the desired properties.</span></span> <span data-ttu-id="2a6fb-241">サンプルでは、**Timer** プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-241">Our sample uses the **Timer** property.</span></span>

![Timer プロパティ](images/desktop-to-uwp/timer-property.png)

<span data-ttu-id="2a6fb-243">バックグラウンド タスクを実装する Windows ランタイム コンポーネントでクラスの完全修飾名を指定します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-243">Provide the fully qualified name of the class in your Windows Runtime Component that implements the background task.</span></span>

![Timer プロパティ](images/desktop-to-uwp/background-task-entry-point.png)

<a id="register-background-task" />

### <a name="register-the-background-task"></a><span data-ttu-id="2a6fb-245">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="2a6fb-245">Register the background task</span></span>

<span data-ttu-id="2a6fb-246">バックグラウンド タスクを登録するデスクトップ アプリケーション プロジェクトにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-246">Add code to your desktop application project that registers the background task.</span></span>

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
## <a name="support-and-feedback"></a><span data-ttu-id="2a6fb-247">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="2a6fb-247">Support and feedback</span></span>

**<span data-ttu-id="2a6fb-248">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="2a6fb-248">Find answers to your questions</span></span>**

<span data-ttu-id="2a6fb-249">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="2a6fb-249">Have questions?</span></span> <span data-ttu-id="2a6fb-250">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-250">Ask us on Stack Overflow.</span></span> <span data-ttu-id="2a6fb-251">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-251">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="2a6fb-252">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-252">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="2a6fb-253">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="2a6fb-253">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="2a6fb-254">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a6fb-254">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
