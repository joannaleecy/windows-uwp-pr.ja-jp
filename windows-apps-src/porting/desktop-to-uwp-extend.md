---
author: normesta
Description: "Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張"
Search.Product: eADQiWindows 10XVcnh
title: "Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張"
ms.author: normesta
ms.date: 07/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: fce6076f07957b50e83cf80e8d12350630b99456
ms.sourcegitcommit: ba0d20f6fad75ce98c25ceead78aab6661250571
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/24/2017
---
# <a name="extend-your-desktop-application-with-modern-uwp-components"></a><span data-ttu-id="3dd55-104">最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張</span><span class="sxs-lookup"><span data-stu-id="3dd55-104">Extend your desktop application with modern UWP components</span></span>

<span data-ttu-id="3dd55-105">一部の Windows 10 エクスペリエンス (タッチ対応 UI ページなど) は、最新のアプリ コンテナー内で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3dd55-105">Some Windows 10 experiences (For example: a touch-enabled UI page) must run inside of a modern app container .</span></span> <span data-ttu-id="3dd55-106">こうしたエクスペリエンスを追加するには、UWP コンポーネントを使ってデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-106">If you want to add these experiences, extend your desktop application with UWP component.</span></span>

<span data-ttu-id="3dd55-107">多くの場合、デスクトップ アプリケーションから UWP API を直接呼び出すことができます。そのため、このガイドを確認する前に、「[Windows 10 のための拡張](desktop-to-uwp-enhance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3dd55-107">In many cases you can call UWP APIs directly from your desktop application, so before you review this guide, see [Enhance for Windows 10](desktop-to-uwp-enhance.md).</span></span>

>[!NOTE]
><span data-ttu-id="3dd55-108">このガイドは、デスクトップ ブリッジを使用してデスクトップ アプリケーションの Windows アプリ パッケージを作成済みであることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="3dd55-108">This guide assumes that you've created a Windows app package for your desktop application by using the Desktop Bridge.</span></span> <span data-ttu-id="3dd55-109">この作業をまだ行っていない場合は、「[デスクトップ ブリッジ](desktop-to-uwp-root.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3dd55-109">If you haven't yet done this, see [Desktop Bridge](desktop-to-uwp-root.md).</span></span>

<span data-ttu-id="3dd55-110">準備ができたら始めましょう。</span><span class="sxs-lookup"><span data-stu-id="3dd55-110">If you're ready, let's start.</span></span>

## <a name="show-a-modern-xaml-ui"></a><span data-ttu-id="3dd55-111">最新の XAML UI を表示する</span><span class="sxs-lookup"><span data-stu-id="3dd55-111">Show a modern XAML UI</span></span>

<span data-ttu-id="3dd55-112">アプリケーション フローの一環として、最新の XAML ベースのユーザー インターフェイスをデスクトップ アプリケーションに組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="3dd55-112">As part of your application flow, you can incorporate modern XAML-based user interfaces into your desktop application.</span></span> <span data-ttu-id="3dd55-113">これらのユーザー インターフェイスは、さまざまな画面サイズと解像度に適応し、タッチや手描きなどの最新の対話モデルをサポートする性質を備えています。</span><span class="sxs-lookup"><span data-stu-id="3dd55-113">These user interfaces are naturally adaptive to different screen sizes and resolutions and support modern interactive models such as touch and ink.</span></span>

<span data-ttu-id="3dd55-114">たとえば、少量の XAML マークアップを使用して、地図関連の強力な視覚化機能をユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="3dd55-114">For example, with a small amount of XAML markup, you can give users with powerful map-related visualization features.</span></span>

<span data-ttu-id="3dd55-115">次の画像に、マップ コントロールを含む XAML ベースの最新の UI を表示している VB6 アプリケーションを示しています。</span><span class="sxs-lookup"><span data-stu-id="3dd55-115">This image shows a VB6 application that opens a XAML-based modern UI that contains a map control.</span></span>

![アダプティブ デザイン](images\desktop-to-uwp\extend-xaml-ui.png)

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="3dd55-117">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="3dd55-117">Have a closer look at this app</span></span>

<span data-ttu-id="3dd55-118">:heavy_check_mark: [ビデオを見る](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Add-a-XAML-UI-and-Toast-Notification-to-a-VB6-Application-OsJHC7WhD_8006218965)</span><span class="sxs-lookup"><span data-stu-id="3dd55-118">:heavy_check_mark: [Watch a video](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Add-a-XAML-UI-and-Toast-Notification-to-a-VB6-Application-OsJHC7WhD_8006218965)</span></span>

<span data-ttu-id="3dd55-119">:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/vb6-app-with-xaml-sample/9n191ncxf2f6)</span><span class="sxs-lookup"><span data-stu-id="3dd55-119">:heavy_check_mark: [Get the app](https://www.microsoft.com/en-us/store/p/vb6-app-with-xaml-sample/9n191ncxf2f6)</span></span>

<span data-ttu-id="3dd55-120">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/VB6withXaml)</span><span class="sxs-lookup"><span data-stu-id="3dd55-120">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/VB6withXaml)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="3dd55-121">設計パターン</span><span class="sxs-lookup"><span data-stu-id="3dd55-121">The design pattern</span></span>

<span data-ttu-id="3dd55-122">XAML ベースの UI を表示するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-122">To show a XAML-based UI, do these things:</span></span>

<span data-ttu-id="3dd55-123">:1: [UWP プロジェクトをソリューションに追加する](#project)</span><span class="sxs-lookup"><span data-stu-id="3dd55-123">:one: [Add a UWP project to your solution](#project)</span></span>

<span data-ttu-id="3dd55-124">:2: [そのプロジェクトにプロトコル拡張機能を追加する](#protocol)</span><span class="sxs-lookup"><span data-stu-id="3dd55-124">:two: [Add a protocol extension to that project](#protocol)</span></span>

<span data-ttu-id="3dd55-125">:3: [デスクトップ アプリから UWP アプリを起動する](#start)</span><span class="sxs-lookup"><span data-stu-id="3dd55-125">:three: [Start the UWP app from your desktop app](#start)</span></span>

<span data-ttu-id="3dd55-126">:4: [UWP プロジェクトで目的のページを表示する](#parse)</span><span class="sxs-lookup"><span data-stu-id="3dd55-126">:four: [In the UWP project, show the page that you want](#parse)</span></span>

<span id="project" />
### <a name="add-a-uwp-project"></a><span data-ttu-id="3dd55-127">UWP プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="3dd55-127">Add a UWP project</span></span>

<span data-ttu-id="3dd55-128">ソリューションに **[空白のアプリ (ユニバーサル Windows)]** プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-128">Add a **Blank App (Universal Windows)** project to your solution.</span></span>

<span id="protocol" />
### <a name="add-a-protocol-extension"></a><span data-ttu-id="3dd55-129">プロトコル拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="3dd55-129">Add a protocol extension</span></span>

<span data-ttu-id="3dd55-130">**ソリューション エクスプ ローラー**で、プロジェクトの **package.appxmanifest** ファイルを開き、目的の拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-130">In **Solution Explorer**, open the **package.appxmanifest** file of the project and add the extension.</span></span>

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

<span data-ttu-id="3dd55-131">プロトコルに名前を付けて、UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-131">Give the protocol a name, provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span>

<span data-ttu-id="3dd55-132">デザイナーで **package.appxmanifest** 開き、**[宣言]** タブを選んで、そこで拡張機能を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="3dd55-132">You can also open the **package.appxmanifest** in the designer, choose the **Declarations** tab, and then add the extension there.</span></span>

![[宣言] タブ](images\desktop-to-uwp\protocol-properties.png)



> [!NOTE]
> <span data-ttu-id="3dd55-134">マップ コントロールはインターネットからデータをダウンロードします。そのため、マップ コントロールを使用する場合は、"インターネット クライアント" 機能もマニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3dd55-134">Map controls download data from the internet so if you use one, you'll have to add the "internet client" capability to your manifest as well.</span></span>

<span id="start" />
### <a name="start-the-uwp-app"></a><span data-ttu-id="3dd55-135">UWP アプリを起動する</span><span class="sxs-lookup"><span data-stu-id="3dd55-135">Start the UWP app</span></span>

<span data-ttu-id="3dd55-136">まず、プロトコル名と UWP アプリに渡すパラメーターが含まれた [URI](https://msdn.microsoft.com/library/system.uri.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-136">First, create a [Uri](https://msdn.microsoft.com/library/system.uri.aspx) that includes the protocol name and any parameters you want to pass into the UWP app.</span></span> <span data-ttu-id="3dd55-137">次に、[LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-137">Then, call the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_) method.</span></span>

<span data-ttu-id="3dd55-138">C# の基本的な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-138">Here's a basic example in C#.</span></span>

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
このサンプルでは、もう少し間接的な作業を行います。 ``LaunchMap`` という名前の VB6 で呼び出せる相互運用関数に呼び出しをラップしました。 <span data-ttu-id="3dd55-141">この関数は C++ を使用して記述されています。</span><span class="sxs-lookup"><span data-stu-id="3dd55-141">That function is written by using C++.</span></span>

<span data-ttu-id="3dd55-142">VB ブロックを次に示します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-142">Here's the VB block:</span></span>

```VB
Private Declare Function LaunchMap Lib "UWPWrappers.dll" _
  (ByVal lat As Double, ByVal lon As Double) As Boolean
 
Private Sub EiffelTower_Click()
    LaunchMap 48.858222, 2.2945
End Sub
```

<span data-ttu-id="3dd55-143">C++ 関数を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-143">Here's the C++ function:</span></span>

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

<span id="parse" />
### <a name="parse-parameters-and-show-a-page"></a><span data-ttu-id="3dd55-144">パラメーターを解析してページを表示する</span><span class="sxs-lookup"><span data-stu-id="3dd55-144">Parse parameters and show a page</span></span>

<span data-ttu-id="3dd55-145">UWP プロジェクトの **App** クラスで、**OnActivated** イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="3dd55-145">In the **App** class of your UWP project, override the **OnActivated** event handler.</span></span> <span data-ttu-id="3dd55-146">アプリがプロトコルによってアクティブ化されている場合は、パラメーターを解析して目的のページを開きます。</span><span class="sxs-lookup"><span data-stu-id="3dd55-146">If the app is activated by your protocol, parse the parameters and then open the page that you want.</span></span>

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

### <a name="similar-samples"></a><span data-ttu-id="3dd55-147">類似のサンプル</span><span class="sxs-lookup"><span data-stu-id="3dd55-147">Similar Samples</span></span>

[<span data-ttu-id="3dd55-148">Northwind サンプル: UWA UI および Win32 レガシ コードのエンド ツー エンドの例</span><span class="sxs-lookup"><span data-stu-id="3dd55-148">Northwind sample: End-to-end example for UWA UI & Win32 legacy code</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/NorthwindSample)

[<span data-ttu-id="3dd55-149">Northwind サンプル: SQL Server に接続する UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="3dd55-149">Northwind sample: UWP app connecting to SQL Server</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SQLServer)

## <a name="provide-services-to-other-apps"></a><span data-ttu-id="3dd55-150">サービスを他のアプリに提供する</span><span class="sxs-lookup"><span data-stu-id="3dd55-150">Provide services to other apps</span></span>

<span data-ttu-id="3dd55-151">他のアプリで利用できるサービスを追加します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-151">You add a service that other apps can consume.</span></span> <span data-ttu-id="3dd55-152">たとえば、アプリの背後でデータベースが実行されている場合に、そのデータベースへの制御されたアクセスを他のアプリに提供するサービスを追加できます。</span><span class="sxs-lookup"><span data-stu-id="3dd55-152">For example, you can add a service that gives other apps controlled access to the database behind your app.</span></span> <span data-ttu-id="3dd55-153">バックグラウンド タスクを実装することで、デスクトップ アプリが実行されていない場合でも他のアプリからサービスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="3dd55-153">By implementing a background task, apps can reach the service even if your desktop app is not running.</span></span>

<span data-ttu-id="3dd55-154">これを実行するサンプルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-154">Here's a sample that does this.</span></span>

![アダプティブ デザイン](images\desktop-to-uwp\winforms-app-service.png)

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="3dd55-156">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="3dd55-156">Have a closer look at this app</span></span>

<span data-ttu-id="3dd55-157">:heavy_check_mark: [ビデオを見る](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Expose-an-AppService-from-a-Windows-Forms-Data-Application-GiqNS7WhD_706218965)</span><span class="sxs-lookup"><span data-stu-id="3dd55-157">:heavy_check_mark: [Watch a video](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Expose-an-AppService-from-a-Windows-Forms-Data-Application-GiqNS7WhD_706218965)</span></span>

<span data-ttu-id="3dd55-158">:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/winforms-appservice/9p7d9b6nk5tn)</span><span class="sxs-lookup"><span data-stu-id="3dd55-158">:heavy_check_mark: [Get the app](https://www.microsoft.com/en-us/store/p/winforms-appservice/9p7d9b6nk5tn)</span></span>

<span data-ttu-id="3dd55-159">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinformsAppService)</span><span class="sxs-lookup"><span data-stu-id="3dd55-159">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinformsAppService)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="3dd55-160">設計パターン</span><span class="sxs-lookup"><span data-stu-id="3dd55-160">The design pattern</span></span>

<span data-ttu-id="3dd55-161">サービスの提供を示すには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-161">To show provide a service, do these things:</span></span>

<span data-ttu-id="3dd55-162">:1: [Windows ランタイム コンポーネントを追加する](#component)</span><span class="sxs-lookup"><span data-stu-id="3dd55-162">:one: [Add a Windows Runtime Component](#component)</span></span>

<span data-ttu-id="3dd55-163">:2: [アプリ サービスの拡張機能を追加する](#extension)</span><span class="sxs-lookup"><span data-stu-id="3dd55-163">:two: [Add an app service extension](#extension)</span></span>

<span data-ttu-id="3dd55-164">:3: [アプリ サービスを実装する](#appservice)</span><span class="sxs-lookup"><span data-stu-id="3dd55-164">:three: [Implement the app service](#appservice)</span></span>

<span data-ttu-id="3dd55-165">:4: [アプリ サービスをテストする](#test)</span><span class="sxs-lookup"><span data-stu-id="3dd55-165">:four: [Test the app service](#test)</span></span>

<span id="component" />

### <a name="add-a-windows-runtime-component"></a><span data-ttu-id="3dd55-166">Windows ランタイム コンポーネントを追加する</span><span class="sxs-lookup"><span data-stu-id="3dd55-166">Add a Windows Runtime component</span></span>

<span data-ttu-id="3dd55-167">ソリューションに **[Windows ランタイム コンポーネント (ユニバーサル Windows)]** プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-167">Add a **Windows Runtime Component (Universal Windows)** project to your solution.</span></span>

<span data-ttu-id="3dd55-168">次に、UWP パッケージ プロジェクトからそのランタイム コンポーネント プロジェクトを参照します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-168">Then, reference the project of that runtime component from your UWP packaging project.</span></span>

<span id="extension" />
### <a name="add-an-app-service-extension"></a><span data-ttu-id="3dd55-169">アプリ サービスの拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="3dd55-169">Add an app service extension</span></span>

<span data-ttu-id="3dd55-170">**ソリューション エクスプ ローラー**で、パッケージ プロジェクトの **package.appxmanifest** ファイルを開き、アプリ サービスの拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-170">In **Solution Explorer**, open the **package.appxmanifest** file of your packaging project and add an app service extension.</span></span>

```xml
<Extensions>
      <uap:Extension
          Category="windows.appService"
          EntryPoint="MyAppService.AppServiceTask">
        <uap:AppService Name="com.microsoft.samples.winforms" />
      </uap:Extension>
    </Extensions>    
```

<span data-ttu-id="3dd55-171">そのアプリ サービスに名前を付けて、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-171">Give the app service a name and provide the name of the entry point class.</span></span> <span data-ttu-id="3dd55-172">このクラスは、アプリ サービスを実装するために使用します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-172">This is the class that you'll use to implement your app service.</span></span>

<span id="appservice" />
### <a name="implement-the-app-service"></a><span data-ttu-id="3dd55-173">アプリ サービスを実装する</span><span class="sxs-lookup"><span data-stu-id="3dd55-173">Implement the app service</span></span>

<span data-ttu-id="3dd55-174">以下では、他のアプリからの要求を検証して処理します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-174">Here's where you'll validate and handle requests from other apps.</span></span>

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

<span id="test" />
### <a name="test-the-app-service"></a><span data-ttu-id="3dd55-175">アプリ サービスをテストする</span><span class="sxs-lookup"><span data-stu-id="3dd55-175">Test the app service</span></span>

<span data-ttu-id="3dd55-176">別のアプリからサービスを呼び出すことにより、サービスをテストします。</span><span class="sxs-lookup"><span data-stu-id="3dd55-176">Test your service by calling it from another app.</span></span>

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
        string result = "";
 
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

<span data-ttu-id="3dd55-177">アプリ サービスについて詳しくは、「[アプリ サービスの作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3dd55-177">Learn more about app services here: [Create and consume an app service](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service).</span></span>

### <a name="similar-samples"></a><span data-ttu-id="3dd55-178">類似のサンプル</span><span class="sxs-lookup"><span data-stu-id="3dd55-178">Similar Samples</span></span>

[<span data-ttu-id="3dd55-179">アプリ サービス ブリッジのサンプル</span><span class="sxs-lookup"><span data-stu-id="3dd55-179">App service bridge sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/AppServiceBridgeSample)

[<span data-ttu-id="3dd55-180">C++ Win32 アプリを使ったアプリ サービス ブリッジのサンプル</span><span class="sxs-lookup"><span data-stu-id="3dd55-180">App service bridge sample with C++ win32 app</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/AppServiceBridgeSample_C%2B%2B)

[<span data-ttu-id="3dd55-181">プッシュ通知を受け取る MFC アプリケーション</span><span class="sxs-lookup"><span data-stu-id="3dd55-181">MFC application that receives push notifications</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/MFCwithPush)


## <a name="making-your-desktop-application-a-share-target"></a><span data-ttu-id="3dd55-182">デスクトップ アプリケーションを共有ターゲットにする</span><span class="sxs-lookup"><span data-stu-id="3dd55-182">Making your desktop application a share target</span></span>

<span data-ttu-id="3dd55-183">デスクトップ アプリケーションを共有ターゲットにすることで、共有をサポートしている他のアプリのデータ (画像など) をユーザーが簡単に共有できるようになります。</span><span class="sxs-lookup"><span data-stu-id="3dd55-183">You can make your desktop application a share target so that users can easily share data such as pictures from other apps that support sharing.</span></span>

<span data-ttu-id="3dd55-184">たとえば、ユーザーは、Microsoft Edge やフォト アプリから画像を共有するためにアプリを選択できます。</span><span class="sxs-lookup"><span data-stu-id="3dd55-184">For example, users could choose your app to share pictures from Microsoft Edge, the Photos app.</span></span> <span data-ttu-id="3dd55-185">そのような機能を備えた WPF サンプル アプリは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="3dd55-185">Here's a WPF sample app that has that capability.</span></span>

![共有ターゲット](images\desktop-to-uwp\share-target.png)

### <a name="have-a-closer-look-at-this-app"></a><span data-ttu-id="3dd55-187">このアプリを詳しく確認する</span><span class="sxs-lookup"><span data-stu-id="3dd55-187">Have a closer look at this app</span></span>

<span data-ttu-id="3dd55-188">:heavy_check_mark: [ビデオを見る](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Make-a-WPF-Application-a-Share-Target-xd6Fu6WhD_8406218965)</span><span class="sxs-lookup"><span data-stu-id="3dd55-188">:heavy_check_mark: [Watch a video](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Make-a-WPF-Application-a-Share-Target-xd6Fu6WhD_8406218965)</span></span>

<span data-ttu-id="3dd55-189">:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/wpf-app-as-sharetarget/9pjcjljlck37)</span><span class="sxs-lookup"><span data-stu-id="3dd55-189">:heavy_check_mark: [Get the app](https://www.microsoft.com/en-us/store/p/wpf-app-as-sharetarget/9pjcjljlck37)</span></span>

<span data-ttu-id="3dd55-190">:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WPFasShareTarget)</span><span class="sxs-lookup"><span data-stu-id="3dd55-190">:heavy_check_mark: [Browse the code](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WPFasShareTarget)</span></span>

### <a name="the-design-pattern"></a><span data-ttu-id="3dd55-191">設計パターン</span><span class="sxs-lookup"><span data-stu-id="3dd55-191">The design pattern</span></span>

<span data-ttu-id="3dd55-192">アプリケーションを共有ターゲットにするには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-192">To make your application a share target, do these things:</span></span>

<span data-ttu-id="3dd55-193">:1: [UWP プロジェクトをソリューションに追加する](#project2)</span><span class="sxs-lookup"><span data-stu-id="3dd55-193">:one: [Add a UWP project to your solution](#project2)</span></span>

<span data-ttu-id="3dd55-194">:2: [共有ターゲットの拡張機能を追加する](#share-extension)</span><span class="sxs-lookup"><span data-stu-id="3dd55-194">:two: [Add a share target extension](#share-extension)</span></span>

<span data-ttu-id="3dd55-195">:3: [OnNavigatedTo イベント ハンドラーをオーバーライドする](#override)</span><span class="sxs-lookup"><span data-stu-id="3dd55-195">:three: [Override the OnNavigatedTo event handler](#override)</span></span>

<span id="project2" />
### <a name="add-a-uwp-project-to-your-solution"></a><span data-ttu-id="3dd55-196">UWP プロジェクトをソリューションに追加する</span><span class="sxs-lookup"><span data-stu-id="3dd55-196">Add a UWP project to your solution</span></span>

<span data-ttu-id="3dd55-197">ソリューションに **[空白のアプリ (ユニバーサル Windows)]** プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-197">Add a **Blank App (Universal Windows)** project to your solution.</span></span>

<span id="share-extension" />
### <a name="add-a-share-target-extension"></a><span data-ttu-id="3dd55-198">共有ターゲットの拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="3dd55-198">Add a share target extension</span></span>

<span data-ttu-id="3dd55-199">**ソリューション エクスプ ローラー**で、プロジェクトの **package.appxmanifest** ファイルを開き、目的の拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-199">In **Solution Explorer**, open the **package.appxmanifest** file of the project and add the extension.</span></span>

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

<span data-ttu-id="3dd55-200">UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="3dd55-200">Provide the name of the executable produced by the UWP project, and the name of the entry point class.</span></span> <span data-ttu-id="3dd55-201">アプリとの間で共有できるようにするファイルの種類を指定することも必要です。</span><span class="sxs-lookup"><span data-stu-id="3dd55-201">You'll also have to specify what types of files can be shared with your app.</span></span>

<span id="override" />
### <a name="override-the-onnavigatedto-event-handler"></a><span data-ttu-id="3dd55-202">OnNavigatedTo イベント ハンドラーをオーバーライドする</span><span class="sxs-lookup"><span data-stu-id="3dd55-202">Override the OnNavigatedTo event handler</span></span>

<span data-ttu-id="3dd55-203">UWP プロジェクトの **App** クラスで、**OnNavigatedTo** イベント ハンドラーをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="3dd55-203">Override the **OnNavigatedTo** event handler in the **App** class of your UWP project.</span></span>

<span data-ttu-id="3dd55-204">このイベント ハンドラーは、ユーザーがファイルを共有するためにアプリを選択するときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="3dd55-204">This event handler is called when users choose your app to share their files.</span></span>

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

## <a name="support-and-feedback"></a><span data-ttu-id="3dd55-205">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="3dd55-205">Support and feedback</span></span>

**<span data-ttu-id="3dd55-206">特定の質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="3dd55-206">Find answers to specific questions</span></span>**

<span data-ttu-id="3dd55-207">マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="3dd55-207">Our team monitors these [StackOverflow tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

**<span data-ttu-id="3dd55-208">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="3dd55-208">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="3dd55-209">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3dd55-209">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial)</span></span>

**<span data-ttu-id="3dd55-210">この記事に関するフィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="3dd55-210">Give feedback about this article</span></span>**

<span data-ttu-id="3dd55-211">下のコメント セクションをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="3dd55-211">Use the comments section below.</span></span>
