---
title: WPF でのビジュアル層の使用
description: 既存の WPF コンテンツと組み合わせて、ビジュアル レイヤー API を使用して、高度なアニメーションや効果を作成するための手法について説明します。
ms.date: 03/18/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: a280b36b0ff3a34bfbd52417aec0856156aa420d
ms.sourcegitcommit: e63fbd7a63a7e8c03c52f4219f34513f4b2bb411
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/18/2019
ms.locfileid: "58174126"
---
# <a name="using-the-visual-layer-with-wpf"></a><span data-ttu-id="8654d-104">WPF でのビジュアル層の使用</span><span class="sxs-lookup"><span data-stu-id="8654d-104">Using the Visual Layer with WPF</span></span>

<span data-ttu-id="8654d-105">Windows ランタイムの合成 Api を使用することができます (とも呼ばれる、[ビジュアル層](visual-layer.md)) で、Windows Presentation Foundation (WPF) アプリ用 Windows 10 のユーザーに光を最新のエクスペリエンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-105">You can use Windows Runtime Composition APIs (also called the [Visual layer](visual-layer.md)) in your Windows Presentation Foundation (WPF) apps to create modern experiences that light up for Windows 10 users.</span></span>

<span data-ttu-id="8654d-106">このチュートリアルの完成したコードは GitHub で入手できます。[WPF HelloComposition サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/HelloComposition)します。</span><span class="sxs-lookup"><span data-stu-id="8654d-106">The complete code for this tutorial is available on GitHub: [WPF HelloComposition sample](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/HelloComposition).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="8654d-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="8654d-107">Prerequisites</span></span>

<span data-ttu-id="8654d-108">API をホストしている UWP XAML では、これらの前提条件があります。</span><span class="sxs-lookup"><span data-stu-id="8654d-108">The UWP XAML hosting API has these prerequisites.</span></span>

- <span data-ttu-id="8654d-109">WPF および UWP を使用してアプリ開発の知識があると仮定します。</span><span class="sxs-lookup"><span data-stu-id="8654d-109">We assume that you have some familiarity with app development using WPF and UWP.</span></span> <span data-ttu-id="8654d-110">For more info, see:</span><span class="sxs-lookup"><span data-stu-id="8654d-110">For more info, see:</span></span>
  - [<span data-ttu-id="8654d-111">概要 (WPF)</span><span class="sxs-lookup"><span data-stu-id="8654d-111">Getting Started (WPF)</span></span>](/dotnet/framework/wpf/getting-started/)
  - [<span data-ttu-id="8654d-112">Windows 10 アプリを概要します。</span><span class="sxs-lookup"><span data-stu-id="8654d-112">Get started with Windows 10 apps</span></span>](/windows/uwp/get-started/)
  - [<span data-ttu-id="8654d-113">Windows 10 のデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="8654d-113">Enhance your desktop application for Windows 10</span></span>](/windows/uwp/porting/desktop-to-uwp-enhance)
- <span data-ttu-id="8654d-114">.NET framework 4.7.2 以降</span><span class="sxs-lookup"><span data-stu-id="8654d-114">.NET Framework 4.7.2 or later</span></span>
- <span data-ttu-id="8654d-115">Windows 10 バージョン 1803 以降</span><span class="sxs-lookup"><span data-stu-id="8654d-115">Windows 10 version 1803 or later</span></span>
- <span data-ttu-id="8654d-116">Windows 10 SDK 17134 またはそれ以降</span><span class="sxs-lookup"><span data-stu-id="8654d-116">Windows 10 SDK 17134 or later</span></span>

## <a name="how-to-use-composition-apis-in-wpf"></a><span data-ttu-id="8654d-117">WPF で合成 Api を使用する方法</span><span class="sxs-lookup"><span data-stu-id="8654d-117">How to use Composition APIs in WPF</span></span>

<span data-ttu-id="8654d-118">このチュートリアルでは、単純な WPF アプリの UI を作成し、アニメーションの合成要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-118">In this tutorial, you create a simple WPF app UI and add animated Composition elements to it.</span></span> <span data-ttu-id="8654d-119">WPF と合成の両方のコンポーネントを単純に保持されますが、相互運用機能のコードは、コンポーネントの複雑さに関係なく同じです。</span><span class="sxs-lookup"><span data-stu-id="8654d-119">Both the WPF and Composition components are kept simple, but the interop code shown is the same regardless of the complexity of the components.</span></span> <span data-ttu-id="8654d-120">次のような完成したアプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8654d-120">The finished app looks like this.</span></span>

![実行中のアプリの UI](images/interop/wpf-comp-interop-app-ui.png)

## <a name="create-a-wpf-project"></a><span data-ttu-id="8654d-122">WPF プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-122">Create a WPF project</span></span>

<span data-ttu-id="8654d-123">最初の手順では、UI のアプリケーションの定義と、XAML ページを含む WPF アプリ プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-123">The first step is to create the WPF app project, which includes an application definition and the XAML page for the UI.</span></span>

<span data-ttu-id="8654d-124">ビジュアルで新しい WPF アプリケーション プロジェクトを作成するC#という_HelloComposition_:</span><span class="sxs-lookup"><span data-stu-id="8654d-124">To create a new WPF Application project in Visual C# named _HelloComposition_:</span></span>

1. <span data-ttu-id="8654d-125">Visual Studio を開き、選択**ファイル** > **新規** > **プロジェクト**します。</span><span class="sxs-lookup"><span data-stu-id="8654d-125">Open Visual Studio and select **File** > **New** > **Project**.</span></span>

    <span data-ttu-id="8654d-126">**新しいプロジェクト**ダイアログ ボックスが開きます。</span><span class="sxs-lookup"><span data-stu-id="8654d-126">The **New Project** dialog opens.</span></span>
1. <span data-ttu-id="8654d-127">下、**インストール済み**カテゴリで、展開、 **Visual C#** ノードをクリックして**Windows デスクトップ**します。</span><span class="sxs-lookup"><span data-stu-id="8654d-127">Under the **Installed** category, expand the **Visual C#** node, and then select **Windows Desktop**.</span></span>
1. <span data-ttu-id="8654d-128">選択、 **WPF アプリ (.NET Framework)** テンプレート。</span><span class="sxs-lookup"><span data-stu-id="8654d-128">Select the **WPF App (.NET Framework)** template.</span></span>
1. <span data-ttu-id="8654d-129">名前を入力します_HelloComposition_、フレームワークを選択します **.NET Framework 4.7.2**、 をクリックし、 **OK**。</span><span class="sxs-lookup"><span data-stu-id="8654d-129">Enter the name _HelloComposition_, select Framework **.NET Framework 4.7.2**, then click **OK**.</span></span>

    <span data-ttu-id="8654d-130">Visual Studio では、プロジェクトを作成し、MainWindow.xaml をという名前の既定アプリケーション ウィンドウのデザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="8654d-130">Visual Studio creates the project and opens the designer for the default application window named MainWindow.xaml.</span></span>

## <a name="configure-the-project-to-use-windows-runtime-apis"></a><span data-ttu-id="8654d-131">Windows ランタイム Api を使用してプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-131">Configure the project to use Windows Runtime APIs</span></span>

<span data-ttu-id="8654d-132">Windows ランタイム (WinRT)、WPF アプリで Api を使用するには、Windows ランタイムにアクセスする Visual Studio プロジェクトを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8654d-132">To use Windows Runtime (WinRT) APIs in your WPF app, you need to configure your Visual Studio project to access the Windows Runtime.</span></span> <span data-ttu-id="8654d-133">さらに、ベクターを使用するために必要な参照を追加する必要があるために、合成 Api でベクターは広範囲に使用されます。</span><span class="sxs-lookup"><span data-stu-id="8654d-133">In addition, vectors are used extensively by the Composition APIs, so you need to add the references required to use vectors.</span></span>

<span data-ttu-id="8654d-134">NuGet パッケージのこれらのニーズの両方のアドレスを利用できます。</span><span class="sxs-lookup"><span data-stu-id="8654d-134">NuGet packages are available to address both of these needs.</span></span> <span data-ttu-id="8654d-135">これらのパッケージをプロジェクトに必要な参照を追加するの最新バージョンをインストールします。</span><span class="sxs-lookup"><span data-stu-id="8654d-135">Install the latest versions of these packages to add the necessary references to your project.</span></span>  

- <span data-ttu-id="8654d-136">[Microsoft.Windows.SDK.Contracts](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts) (PackageReference に既定のパッケージ管理形式のセットが必要)。</span><span class="sxs-lookup"><span data-stu-id="8654d-136">[Microsoft.Windows.SDK.Contracts](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts) (Requires default package management format set to PackageReference.)</span></span>
- [<span data-ttu-id="8654d-137">System.Numerics.Vectors</span><span class="sxs-lookup"><span data-stu-id="8654d-137">System.Numerics.Vectors</span></span>](https://www.nuget.org/packages/System.Numerics.Vectors/)

> [!NOTE]
> <span data-ttu-id="8654d-138">NuGet パッケージを使用して、プロジェクトを構成することをお勧め、中には、必要な参照を手動で追加することができます。</span><span class="sxs-lookup"><span data-stu-id="8654d-138">While we recommend using the NuGet packages to configure your project, you can add the required references manually.</span></span> <span data-ttu-id="8654d-139">詳細については、次を参照してください。 [Windows 10 のデスクトップ アプリケーションの拡張](/windows/uwp/porting/desktop-to-uwp-enhance)します。</span><span class="sxs-lookup"><span data-stu-id="8654d-139">For more info, see [Enhance your desktop application for Windows 10](/windows/uwp/porting/desktop-to-uwp-enhance).</span></span> <span data-ttu-id="8654d-140">次の表への参照を追加する必要のあるファイルを示します。</span><span class="sxs-lookup"><span data-stu-id="8654d-140">The following table shows the files that you need to add references to.</span></span>

|<span data-ttu-id="8654d-141">ファイル</span><span class="sxs-lookup"><span data-stu-id="8654d-141">File</span></span>|<span data-ttu-id="8654d-142">Location</span><span class="sxs-lookup"><span data-stu-id="8654d-142">Location</span></span>|
|--|--|
|<span data-ttu-id="8654d-143">System.Runtime.WindowsRuntime</span><span class="sxs-lookup"><span data-stu-id="8654d-143">System.Runtime.WindowsRuntime</span></span>|<span data-ttu-id="8654d-144">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span><span class="sxs-lookup"><span data-stu-id="8654d-144">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span></span>|
|<span data-ttu-id="8654d-145">Windows.Foundation.UniversalApiContract.winmd</span><span class="sxs-lookup"><span data-stu-id="8654d-145">Windows.Foundation.UniversalApiContract.winmd</span></span>|<span data-ttu-id="8654d-146">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span><span class="sxs-lookup"><span data-stu-id="8654d-146">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span></span>|
|<span data-ttu-id="8654d-147">Windows.Foundation.FoundationContract.winmd</span><span class="sxs-lookup"><span data-stu-id="8654d-147">Windows.Foundation.FoundationContract.winmd</span></span>|<span data-ttu-id="8654d-148">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span><span class="sxs-lookup"><span data-stu-id="8654d-148">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span></span>|
|<span data-ttu-id="8654d-149">System.Numerics.Vectors.dll</span><span class="sxs-lookup"><span data-stu-id="8654d-149">System.Numerics.Vectors.dll</span></span>|<span data-ttu-id="8654d-150">C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics.Vectors\v4.0_4.0.0.0__b03f5f7f11d50a3a</span><span class="sxs-lookup"><span data-stu-id="8654d-150">C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics.Vectors\v4.0_4.0.0.0__b03f5f7f11d50a3a</span></span>|
|<span data-ttu-id="8654d-151">System.Numerics.dll</span><span class="sxs-lookup"><span data-stu-id="8654d-151">System.Numerics.dll</span></span>|<span data-ttu-id="8654d-152">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2</span><span class="sxs-lookup"><span data-stu-id="8654d-152">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2</span></span>|

## <a name="configure-the-project-to-be-per-monitor-dpi-aware"></a><span data-ttu-id="8654d-153">あるモニターごとの DPI 対応のプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-153">Configure the project to be per-monitor DPI aware</span></span>

<span data-ttu-id="8654d-154">表示されます。 画面の DPI 設定と一致するアプリに追加するビジュアル層のコンテンツは自動的に対応できません。</span><span class="sxs-lookup"><span data-stu-id="8654d-154">The visual layer content you add to your app does not automatically scale to match the DPI settings of the screen it's shown on.</span></span> <span data-ttu-id="8654d-155">アプリの場合、モニターごとの DPI 対応を有効にすること、ビジュアル層のコンテンツの作成に使用するコード、現在の DPI スケールするときは考慮、アプリが実行されるかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8654d-155">You need to enable per-monitor DPI awareness for your app, and then make sure that the code you use to create your visual layer content takes into account the current DPI scale when the app runs.</span></span> <span data-ttu-id="8654d-156">ここでは、DPI 対応にするプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-156">Here, we configure the project to be DPI aware.</span></span> <span data-ttu-id="8654d-157">以降のセクションでは、DPI 情報を使用して、ビジュアル層のコンテンツを拡大縮小する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="8654d-157">In later sections, we show how to use the DPI information to scale the visual layer content.</span></span>

<span data-ttu-id="8654d-158">WPF アプリは、システム DPI の既定では、認識がモニターごとの DPI 対応で app.manifest ファイルに対して自身を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8654d-158">WPF apps are System DPI aware by default, but need to declare themselves to be per-monitor DPI aware in an app.manifest file.</span></span> <span data-ttu-id="8654d-159">アプリ マニフェスト ファイルでモニターごとの DPI 認識を Windows レベル: オンにする</span><span class="sxs-lookup"><span data-stu-id="8654d-159">To turn on Windows-level per-monitor DPI awareness in the app manifest file:</span></span>

1. <span data-ttu-id="8654d-160">**ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="8654d-160">In **Solution Explorer**, right click the _HelloComposition_ project.</span></span>
1. <span data-ttu-id="8654d-161">コンテキスト メニューで選択**追加** > **新しい項目.**.</span><span class="sxs-lookup"><span data-stu-id="8654d-161">In the context menu, select **Add** > **New Item...**.</span></span>
1. <span data-ttu-id="8654d-162">**新しい項目の追加**ダイアログ ボックスで、' アプリケーション マニフェスト ファイル ' を選択し、クリックして**追加**します。</span><span class="sxs-lookup"><span data-stu-id="8654d-162">In the **Add New Item** dialog, select 'Application Manifest File', then click **Add**.</span></span> <span data-ttu-id="8654d-163">(既定の名前をおくことができます。)</span><span class="sxs-lookup"><span data-stu-id="8654d-163">(You can leave the default name.)</span></span>
1. <span data-ttu-id="8654d-164">アプリケーション マニフェスト ファイルでこの xml とコメントを解除を見つけること。</span><span class="sxs-lookup"><span data-stu-id="8654d-164">In the app.manifest file, find this xml and un-comment it:</span></span>

    ```xaml
    <application xmlns="urn:schemas-microsoft-com:asm.v3">
        <windowsSettings>
          <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
        </windowsSettings>
      </application>
    ```

1. <span data-ttu-id="8654d-165">開始後にこの設定を追加`<windowsSettings>`タグ。</span><span class="sxs-lookup"><span data-stu-id="8654d-165">Add this setting after the opening `<windowsSettings>` tag:</span></span>

    ```xaml
          <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitor</dpiAwareness>
    ```

1. <span data-ttu-id="8654d-166">設定する必要があります、 **DoNotScaleForDpiChanges** App.config ファイルで設定します。</span><span class="sxs-lookup"><span data-stu-id="8654d-166">You also need to set the **DoNotScaleForDpiChanges** setting in the App.config file.</span></span>

    <span data-ttu-id="8654d-167">App.Config を開き、内には、この xml を追加、`<configuration>`要素。</span><span class="sxs-lookup"><span data-stu-id="8654d-167">Open App.Config and add this xml inside the `<configuration>` element:</span></span>

    ```xml
    <runtime>
      <AppContextSwitchOverrides value="Switch.System.Windows.DoNotScaleForDpiChanges=false"/>
    </runtime>
    ```

> [!NOTE]
> <span data-ttu-id="8654d-168">**AppContextSwitchOverrides** 1 回のみ設定できます。</span><span class="sxs-lookup"><span data-stu-id="8654d-168">**AppContextSwitchOverrides** can only be set once.</span></span> <span data-ttu-id="8654d-169">既にアプリケーションに 1 つのセットがある場合は、セミコロン必要があります。 属性値内でこのスイッチを区切ります。</span><span class="sxs-lookup"><span data-stu-id="8654d-169">If your application already has one set, you must semicolon delimit this switch inside the value attribute.</span></span>

<span data-ttu-id="8654d-170">(詳細については、次を参照してください、[あたりモニター DPI 開発者ガイドとサンプル](https://github.com/Microsoft/WPF-Samples/tree/master/PerMonitorDPI)github。)。</span><span class="sxs-lookup"><span data-stu-id="8654d-170">(For more info, see the [Per Monitor DPI Developer Guide and samples](https://github.com/Microsoft/WPF-Samples/tree/master/PerMonitorDPI) on GitHub.)</span></span>

## <a name="create-an-hwndhost-derived-class-to-host-composition-elements"></a><span data-ttu-id="8654d-171">コンポジションのホスト要素に HwndHost が派生クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-171">Create an HwndHost derived class to host composition elements</span></span>

<span data-ttu-id="8654d-172">ビジュアル層で作成するコンテンツのホストにから派生するクラスを作成する必要があります。 [HwndHost](/dotnet/api/system.windows.interop.hwndhost)します。</span><span class="sxs-lookup"><span data-stu-id="8654d-172">To host content you create with the visual layer, you need to create a class that derives from [HwndHost](/dotnet/api/system.windows.interop.hwndhost).</span></span> <span data-ttu-id="8654d-173">これは、合成 Api をホストするための構成の大部分を実行します。</span><span class="sxs-lookup"><span data-stu-id="8654d-173">This is where you do most of the configuration for hosting Composition APIs.</span></span> <span data-ttu-id="8654d-174">このクラスを使用して[プラットフォーム呼び出しサービス (PInvoke)](/cpp/dotnet/calling-native-functions-from-managed-code)と[COM 相互運用機能](/dotnet/api/system.runtime.interopservices.comimportattribute)WPF アプリに合成 Api を表示します。</span><span class="sxs-lookup"><span data-stu-id="8654d-174">In this class, you use [Platform Invocation Services (PInvoke)](/cpp/dotnet/calling-native-functions-from-managed-code) and [COM Interop](/dotnet/api/system.runtime.interopservices.comimportattribute) to bring Composition APIs into your WPF app.</span></span> <span data-ttu-id="8654d-175">PInvoke と COM 相互運用機能の詳細については、次を参照してください。[アンマネージ コードとの相互運用](/dotnet/framework/interop/index)します。</span><span class="sxs-lookup"><span data-stu-id="8654d-175">For more info about PInvoke and COM Interop, see [Interoperating with unmanaged code](/dotnet/framework/interop/index).</span></span>

> [!TIP]
> <span data-ttu-id="8654d-176">必要がある場合は、すべてのコードは、チュートリアルを使用すると適切な場所にいるかどうかを確認するチュートリアルの最後に完全なコードを確認します。</span><span class="sxs-lookup"><span data-stu-id="8654d-176">If you need to, check the complete code at the end of the tutorial to make sure all the code is in the right places as you work through the tutorial.</span></span>

1. <span data-ttu-id="8654d-177">派生するプロジェクトに新しいクラス ファイルを追加[HwndHost](/dotnet/api/system.windows.interop.hwndhost)します。</span><span class="sxs-lookup"><span data-stu-id="8654d-177">Add a new class file to your project that derives from [HwndHost](/dotnet/api/system.windows.interop.hwndhost).</span></span>
    - <span data-ttu-id="8654d-178">**ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="8654d-178">In **Solution Explorer**, right click the _HelloComposition_ project.</span></span>
    - <span data-ttu-id="8654d-179">コンテキスト メニューで選択**追加** > **クラス.**.</span><span class="sxs-lookup"><span data-stu-id="8654d-179">In the context menu, select **Add** > **Class...**.</span></span>
    - <span data-ttu-id="8654d-180">**新しい項目の追加**ダイアログ ボックスで、クラス名_CompositionHost.cs_、 をクリックし、**追加**します。</span><span class="sxs-lookup"><span data-stu-id="8654d-180">In the **Add New Item** dialog, name the class _CompositionHost.cs_, then click **Add**.</span></span>
1. <span data-ttu-id="8654d-181">派生するクラス定義を編集、CompositionHost.cs で**HwndHost**します。</span><span class="sxs-lookup"><span data-stu-id="8654d-181">In CompositionHost.cs, edit the class definition to derive from **HwndHost**.</span></span>

    ```csharp
    // Add
    // using System.Windows.Interop;

    namespace HelloComposition
    {
        class CompositionHost : HwndHost
        {
        }
    }
    ```

1. <span data-ttu-id="8654d-182">クラスに次のコードとコンストラクターを追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-182">Add the following code and constructor to the class.</span></span>

    ```csharp
    // Add
    // using Windows.UI.Composition;

    IntPtr hwndHost;
    int hostHeight, hostWidth;
    object dispatcherQueue;
    ICompositionTarget compositionTarget;

    public Compositor Compositor { get; private set; }

    public Visual Child
    {
        set
        {
            if (Compositor == null)
            {
                InitComposition(hwndHost);
            }
            compositionTarget.Root = value;
        }
    }

    internal const int
      WS_CHILD = 0x40000000,
      WS_VISIBLE = 0x10000000,
      LBS_NOTIFY = 0x00000001,
      HOST_ID = 0x00000002,
      LISTBOX_ID = 0x00000001,
      WS_VSCROLL = 0x00200000,
      WS_BORDER = 0x00800000;

    public CompositionHost(double height, double width)
    {
        hostHeight = (int)height;
        hostWidth = (int)width;
    }
    ```

1. <span data-ttu-id="8654d-183">上書き、 **BuildWindowCore**と**次**メソッド。</span><span class="sxs-lookup"><span data-stu-id="8654d-183">Override the **BuildWindowCore** and **DestroyWindowCore** methods.</span></span>
    > [!NOTE]
    > <span data-ttu-id="8654d-184">BuildWindowCore でを呼び出す、 _InitializeCoreDispatcher_と_InitComposition_メソッド。</span><span class="sxs-lookup"><span data-stu-id="8654d-184">In BuildWindowCore, you call the _InitializeCoreDispatcher_ and _InitComposition_ methods.</span></span> <span data-ttu-id="8654d-185">次の手順では、これらのメソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-185">You create these methods in the next steps.</span></span>

    ```csharp
    // Add
    // using System.Runtime.InteropServices;

    protected override HandleRef BuildWindowCore(HandleRef hwndParent)
    {
        // Create Window
        hwndHost = IntPtr.Zero;
        hwndHost = CreateWindowEx(0, "static", "",
                                  WS_CHILD | WS_VISIBLE,
                                  0, 0,
                                  hostWidth, hostHeight,
                                  hwndParent.Handle,
                                  (IntPtr)HOST_ID,
                                  IntPtr.Zero,
                                  0);

        // Create Dispatcher Queue
        dispatcherQueue = InitializeCoreDispatcher();

        // Build Composition tree of content
        InitComposition(hwndHost);

        return new HandleRef(this, hwndHost);
    }

    protected override void DestroyWindowCore(HandleRef hwnd)
    {
        if (compositionTarget.Root != null)
        {
            compositionTarget.Root.Dispose();
        }
        DestroyWindow(hwnd.Handle);
    }
    ```

    - <span data-ttu-id="8654d-186">[CreateWindowEx](/windows/desktop/api/winuser/nf-winuser-createwindowexa)と[DestroyWindow](/windows/desktop/api/winuser/nf-winuser-destroywindow) PInvoke 宣言が必要です。</span><span class="sxs-lookup"><span data-stu-id="8654d-186">[CreateWindowEx](/windows/desktop/api/winuser/nf-winuser-createwindowexa) and [DestroyWindow](/windows/desktop/api/winuser/nf-winuser-destroywindow) require a PInvoke declaration.</span></span> <span data-ttu-id="8654d-187">この宣言をクラスのコードの最後に配置します。</span><span class="sxs-lookup"><span data-stu-id="8654d-187">Place this declaration at the end of the code for the class.</span></span>

    ```csharp
    #region PInvoke declarations

    [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
    internal static extern IntPtr CreateWindowEx(int dwExStyle,
                                                  string lpszClassName,
                                                  string lpszWindowName,
                                                  int style,
                                                  int x, int y,
                                                  int width, int height,
                                                  IntPtr hwndParent,
                                                  IntPtr hMenu,
                                                  IntPtr hInst,
                                                  [MarshalAs(UnmanagedType.AsAny)] object pvParam);

    [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
    internal static extern bool DestroyWindow(IntPtr hwnd);

    #endregion PInvoke declarations
    ```

1. <span data-ttu-id="8654d-188">スレッドの初期化、 [CoreDispatcher](/uwp/api/windows.ui.core.coredispatcher)します。</span><span class="sxs-lookup"><span data-stu-id="8654d-188">Initialize a thread with a [CoreDispatcher](/uwp/api/windows.ui.core.coredispatcher).</span></span> <span data-ttu-id="8654d-189">Core ディスパッチャーは、ウィンドウ メッセージを処理して、イベントをディスパッチ WinRT Api を担当します。</span><span class="sxs-lookup"><span data-stu-id="8654d-189">The core dispatcher is responsible for processing window messages and dispatching events for WinRT APIs.</span></span> <span data-ttu-id="8654d-190">新しいインスタンス**CoreDispatcher** CoreDispatcher を含むスレッドで作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8654d-190">New instances of **CoreDispatcher** must be created on a thread that has a CoreDispatcher.</span></span>
    - <span data-ttu-id="8654d-191">という名前のメソッドを作成する_InitializeCoreDispatcher_ディスパッチャー キューを設定するコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-191">Create a method named _InitializeCoreDispatcher_ and add code to set up the dispatcher queue.</span></span>

    ```csharp
    private object InitializeCoreDispatcher()
    {
        DispatcherQueueOptions options = new DispatcherQueueOptions();
        options.apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA;
        options.threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT;
        options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));

        object queue = null;
        CreateDispatcherQueueController(options, out queue);
        return queue;
    }
    ```

    - <span data-ttu-id="8654d-192">ディスパッチャー キューには、PInvoke 宣言も必要です。</span><span class="sxs-lookup"><span data-stu-id="8654d-192">The dispatcher queue also requires a PInvoke declaration.</span></span> <span data-ttu-id="8654d-193">この宣言内の配置、 _PInvoke 宣言_前の手順で作成されるリージョン。</span><span class="sxs-lookup"><span data-stu-id="8654d-193">Place this declaration inside the _PInvoke declarations_ region you created in the previous step.</span></span>

    ```csharp
    //typedef enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
    //{
    //    DQTAT_COM_NONE,
    //    DQTAT_COM_ASTA,
    //    DQTAT_COM_STA
    //};
    internal enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
    {
        DQTAT_COM_NONE = 0,
        DQTAT_COM_ASTA = 1,
        DQTAT_COM_STA = 2
    };

    //typedef enum DISPATCHERQUEUE_THREAD_TYPE
    //{
    //    DQTYPE_THREAD_DEDICATED,
    //    DQTYPE_THREAD_CURRENT
    //};
    internal enum DISPATCHERQUEUE_THREAD_TYPE
    {
        DQTYPE_THREAD_DEDICATED = 1,
        DQTYPE_THREAD_CURRENT = 2,
    };

    //struct DispatcherQueueOptions
    //{
    //    DWORD dwSize;
    //    DISPATCHERQUEUE_THREAD_TYPE threadType;
    //    DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct DispatcherQueueOptions
    {
        public int dwSize;

        [MarshalAs(UnmanagedType.I4)]
        public DISPATCHERQUEUE_THREAD_TYPE threadType;

        [MarshalAs(UnmanagedType.I4)]
        public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
    };

    //HRESULT CreateDispatcherQueueController(
    //  DispatcherQueueOptions options,
    //  ABI::Windows::System::IDispatcherQueueController** dispatcherQueueController
    //);
    [DllImport("coremessaging.dll", EntryPoint = "CreateDispatcherQueueController", CharSet = CharSet.Unicode)]
    internal static extern IntPtr CreateDispatcherQueueController(DispatcherQueueOptions options,
                                            [MarshalAs(UnmanagedType.IUnknown)]
                                            out object dispatcherQueueController);
    ```

    <span data-ttu-id="8654d-194">今すぐディスパッチャー キューの準備ができているし、初期化し、合成コンテンツの作成を開始できます。</span><span class="sxs-lookup"><span data-stu-id="8654d-194">You now have the dispatcher queue ready and can begin to initialize and create Composition content.</span></span>

1. <span data-ttu-id="8654d-195">初期化、[コンポジター](/uwp/api/windows.ui.composition.compositor)します。</span><span class="sxs-lookup"><span data-stu-id="8654d-195">Initialize the [Compositor](/uwp/api/windows.ui.composition.compositor).</span></span> <span data-ttu-id="8654d-196">コンポジターがさまざまな型を作成するファクトリを[Windows.UI.Composition](/uwp/api/windows.ui.composition)ビジュアル、効果のシステム、およびアニメーション システムにまたがる名前空間。</span><span class="sxs-lookup"><span data-stu-id="8654d-196">The Compositor is a factory that creates a variety of types in the [Windows.UI.Composition](/uwp/api/windows.ui.composition) namespace spanning visuals, the effects system, and the animation system.</span></span> <span data-ttu-id="8654d-197">コンポジター クラスには、ファクトリから作成されたオブジェクトの有効期間も管理します。</span><span class="sxs-lookup"><span data-stu-id="8654d-197">The Compositor class also manages the lifetime of objects created from the factory.</span></span>

    ```csharp
    private void InitComposition(IntPtr hwndHost)
    {
        ICompositorDesktopInterop interop;

        compositor = new Compositor();
        object iunknown = compositor as object;
        interop = (ICompositorDesktopInterop)iunknown;
        IntPtr raw;
        interop.CreateDesktopWindowTarget(hwndHost, true, out raw);

        object rawObject = Marshal.GetObjectForIUnknown(raw);
        ICompositionTarget target = (ICompositionTarget)rawObject;

        if (raw == null) { throw new Exception("QI Failed"); }
    }
    ```

    - <span data-ttu-id="8654d-198">**ICompositorDesktopInterop**と**ICompositionTarget** COM インポートが必要です。</span><span class="sxs-lookup"><span data-stu-id="8654d-198">**ICompositorDesktopInterop** and **ICompositionTarget** require COM imports.</span></span> <span data-ttu-id="8654d-199">このコードの後、 _CompositionHost_クラスが内部名前空間の宣言。</span><span class="sxs-lookup"><span data-stu-id="8654d-199">Place this code after the _CompositionHost_ class, but inside the namespace declaration.</span></span>

    ```csharp
    #region COM Interop

    /*
    #undef INTERFACE
    #define INTERFACE ICompositorDesktopInterop
        DECLARE_INTERFACE_IID_(ICompositorDesktopInterop, IUnknown, "29E691FA-4567-4DCA-B319-D0F207EB6807")
        {
            IFACEMETHOD(CreateDesktopWindowTarget)(
                _In_ HWND hwndTarget,
                _In_ BOOL isTopmost,
                _COM_Outptr_ IDesktopWindowTarget * *result
                ) PURE;
        };
    */
    [ComImport]
    [Guid("29E691FA-4567-4DCA-B319-D0F207EB6807")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICompositorDesktopInterop
    {
        void CreateDesktopWindowTarget(IntPtr hwndTarget, bool isTopmost, out IntPtr test);
    }

    //[contract(Windows.Foundation.UniversalApiContract, 2.0)]
    //[exclusiveto(Windows.UI.Composition.CompositionTarget)]
    //[uuid(A1BEA8BA - D726 - 4663 - 8129 - 6B5E7927FFA6)]
    //interface ICompositionTarget : IInspectable
    //{
    //    [propget] HRESULT Root([out] [retval] Windows.UI.Composition.Visual** value);
    //    [propput] HRESULT Root([in] Windows.UI.Composition.Visual* value);
    //}

    [ComImport]
    [Guid("A1BEA8BA-D726-4663-8129-6B5E7927FFA6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface ICompositionTarget
    {
        Windows.UI.Composition.Visual Root
        {
            get;
            set;
        }
    }

    #endregion COM Interop
    ```

## <a name="create-a-usercontrol-to-add-your-content-to-the-wpf-visual-tree"></a><span data-ttu-id="8654d-200">WPF のビジュアル ツリーにコンテンツを追加するユーザー コントロールを作成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-200">Create a UserControl to add your content to the WPF visual tree</span></span>

<span data-ttu-id="8654d-201">HwndHost を WPF のビジュアル ツリーに追加するコンテンツは、コンポジションのホストに必要なインフラストラクチャをセットアップする最後の手順。</span><span class="sxs-lookup"><span data-stu-id="8654d-201">The last step to set up the infrastructure required to host Composition content is to add the HwndHost to the WPF visual tree.</span></span>

### <a name="create-a-usercontrol"></a><span data-ttu-id="8654d-202">UserControl を作成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-202">Create a UserControl</span></span>

<span data-ttu-id="8654d-203">UserControl は、コンポジションのコンテンツを管理するコードをパッケージ化し、XAML にコンテンツを簡単に追加する便利な方法です。</span><span class="sxs-lookup"><span data-stu-id="8654d-203">A UserControl is a convenient way to package your code that creates and manages Composition content, and easily add the content to your XAML.</span></span>

1. <span data-ttu-id="8654d-204">新しいユーザー コントロール ファイルをプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-204">Add a new user control file to your project.</span></span>
    - <span data-ttu-id="8654d-205">**ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="8654d-205">In **Solution Explorer**, right click the _HelloComposition_ project.</span></span>
    - <span data-ttu-id="8654d-206">コンテキスト メニューで選択**追加** > **ユーザー制御しています.**.</span><span class="sxs-lookup"><span data-stu-id="8654d-206">In the context menu, select **Add** > **User Control...**.</span></span>
    - <span data-ttu-id="8654d-207">**新しい項目の追加**ダイアログ ボックスで、ユーザー コントロールに名前を_CompositionHostControl.xaml_、 をクリックし、**追加**します。</span><span class="sxs-lookup"><span data-stu-id="8654d-207">In the **Add New Item** dialog, name the user control _CompositionHostControl.xaml_, then click **Add**.</span></span>

    <span data-ttu-id="8654d-208">CompositionHostControl.xaml と CompositionHostControl.xaml.cs の両方のファイルが作成され、プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-208">Both the CompositionHostControl.xaml and CompositionHostControl.xaml.cs files are created and added to your project.</span></span>
1. <span data-ttu-id="8654d-209">CompositionHostControl.xaml、置き換えます、`<Grid> </Grid>`このタグ**境界線**HwndHost がである XAML コンテナーである要素。</span><span class="sxs-lookup"><span data-stu-id="8654d-209">In CompositionHostControl.xaml, replace the `<Grid> </Grid>` tags with this **Border** element, which is the XAML container that your HwndHost will go in.</span></span>

    ```xaml
    <Border Name="CompositionHostElement"/>
    ```

<span data-ttu-id="8654d-210">ユーザー コントロールのコードで、前の手順で作成した CompositionHost クラスのインスタンスを作成し、子要素として追加_CompositionHostElement_、XAML ページで作成した境界線。</span><span class="sxs-lookup"><span data-stu-id="8654d-210">In the code for the user control, you create an instance of the CompositionHost class you created in the previous step and add it as a child element of _CompositionHostElement_, the Border you created in the XAML page.</span></span>

1. <span data-ttu-id="8654d-211">CompositionHostControl.xaml.cs では、構成コードで使用するオブジェクトのプライベート変数を追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-211">In CompositionHostControl.xaml.cs, add private variables for the objects you'll use in your Composition code.</span></span> <span data-ttu-id="8654d-212">クラス定義の後にこれらを追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-212">Add these after the class definition.</span></span>

    ```csharp
    CompositionHost compositionHost;
    Compositor compositor;
    Windows.UI.Composition.ContainerVisual containerVisual;
    DpiScale currentDpi;
    ```

1. <span data-ttu-id="8654d-213">ユーザー コントロールのハンドラーを追加**Loaded**イベント。</span><span class="sxs-lookup"><span data-stu-id="8654d-213">Add a handler for the user control's **Loaded** event.</span></span> <span data-ttu-id="8654d-214">これは、CompositionHost インスタンスを設定します。</span><span class="sxs-lookup"><span data-stu-id="8654d-214">This is where you set up your CompositionHost instance.</span></span>

    - <span data-ttu-id="8654d-215">コンストラクターのフック イベント ハンドラーを次に示すよう (`Loaded += CompositionHostControl_Loaded;`)。</span><span class="sxs-lookup"><span data-stu-id="8654d-215">In the constructor, hook up the event handler as shown here (`Loaded += CompositionHostControl_Loaded;`).</span></span>

    ```csharp
    public CompositionHostControl()
    {
        InitializeComponent();
        Loaded += CompositionHostControl_Loaded;
    }
    ```

    - <span data-ttu-id="8654d-216">名前のイベント ハンドラー メソッドを追加*CompositionHostControl_Loaded*します。</span><span class="sxs-lookup"><span data-stu-id="8654d-216">Add the event handler method with the name *CompositionHostControl_Loaded*.</span></span>
    ```csharp
    private void CompositionHostControl_Loaded(object sender, RoutedEventArgs e)
    {
        // If the user changes the DPI scale setting for the screen the app is on,
        // the CompositionHostControl is reloaded. Don't redo this set up if it's
        // already been done.
        if (compositionHost is null)
        {
            currentDpi = VisualTreeHelper.GetDpi(this);

            compositionHost =
                new CompositionHost(ControlHostElement.ActualHeight, ControlHostElement.ActualWidth);
            ControlHostElement.Child = compositionHost;
            compositor = compositionHost.Compositor;
            containerVisual = compositor.CreateContainerVisual();
            compositionHost.Child = containerVisual;
        }
    }
    ```

    <span data-ttu-id="8654d-217">このメソッドでは、構成コードで使用するオブジェクトを設定します。</span><span class="sxs-lookup"><span data-stu-id="8654d-217">In this method, you set up the objects you'll use in your Composition code.</span></span> <span data-ttu-id="8654d-218">何が起こっているかの概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8654d-218">Here's a quick look at what's happening.</span></span>

    - <span data-ttu-id="8654d-219">最初に、セットアップに一度だけ実行をチェックして CompositionHost のインスタンスが既に存在するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8654d-219">First, make sure the set up is only done once by checking whether an instance of CompositionHost already exists.</span></span>

    ```csharp
    // If the user changes the DPI scale setting for the screen the app is on,
    // the CompositionHostControl is reloaded. Don't redo this set up if it's
    // already been done.
    if (compositionHost is null)
    {

    }
    ```

    - <span data-ttu-id="8654d-220">現在の DPI を取得します。</span><span class="sxs-lookup"><span data-stu-id="8654d-220">Get the current DPI.</span></span> <span data-ttu-id="8654d-221">これは、合成要素を適切にスケールに使用されます。</span><span class="sxs-lookup"><span data-stu-id="8654d-221">This is used to properly scale your Composition elements.</span></span>

    ```csharp
    currentDpi = VisualTreeHelper.GetDpi(this);
    ```

    - <span data-ttu-id="8654d-222">CompositionHost のインスタンスを作成し、境界線の子として代入_CompositionHostElement_します。</span><span class="sxs-lookup"><span data-stu-id="8654d-222">Create an instance of CompositionHost and assign it as the Child of the Border, _CompositionHostElement_.</span></span>

    ```csharp
    compositionHost =
        new CompositionHost(ControlHostElement.ActualHeight, ControlHostElement.ActualWidth);
    ControlHostElement.Child = compositionHost;
    ```

    - <span data-ttu-id="8654d-223">CompositionHost からコンポジターを取得します。</span><span class="sxs-lookup"><span data-stu-id="8654d-223">Get the Compositor from the CompositionHost.</span></span>

    ```csharp
    compositor = compositionHost.Compositor;
    ```

    - <span data-ttu-id="8654d-224">ビジュアル コンテナーを作成するのにには、コンポジターを使用します。</span><span class="sxs-lookup"><span data-stu-id="8654d-224">Use the Compositor to create a container visual.</span></span> <span data-ttu-id="8654d-225">これは、合成要素を追加する合成コンテナーです。</span><span class="sxs-lookup"><span data-stu-id="8654d-225">This is the Composition container that you add your Composition elements to.</span></span>

    ```csharp
    containerVisual = compositor.CreateContainerVisual();
    compositionHost.Child = containerVisual;
    ```

### <a name="add-composition-elements"></a><span data-ttu-id="8654d-226">合成要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-226">Add composition elements</span></span>

<span data-ttu-id="8654d-227">インフラストラクチャを導入するに表示する合成コンテンツを生成できます。</span><span class="sxs-lookup"><span data-stu-id="8654d-227">With the infrastructure in place, you can now generate the Composition content you want to show.</span></span>

<span data-ttu-id="8654d-228">この例で作成して単純な四角形をアニメーション化するコードを追加する[SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)します。</span><span class="sxs-lookup"><span data-stu-id="8654d-228">For this example, you add code that creates and animates a simple square [SpriteVisual](/uwp/api/windows.ui.composition.spritevisual).</span></span>

1. <span data-ttu-id="8654d-229">合成要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-229">Add a composition element.</span></span> <span data-ttu-id="8654d-230">CompositionHostControl.xaml.cs では、CompositionHostControl クラスにこれらのメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-230">In CompositionHostControl.xaml.cs, add these methods to the CompositionHostControl class.</span></span>

    ```csharp
    // Add
    // using System.Numerics;

    public void AddElement(float size, float offsetX, float offsetY)
    {
        var visual = compositor.CreateSpriteVisual();
        visual.Size = new Vector2(size, size);
        visual.Scale = new Vector3((float)currentDpi.DpiScaleX, (float)currentDpi.DpiScaleY, 1);
        visual.Brush = compositor.CreateColorBrush(GetRandomColor());
        visual.Offset = new Vector3(offsetX * (float)currentDpi.DpiScaleX, offsetY * (float)currentDpi.DpiScaleY, 0);

        containerVisual.Children.InsertAtTop(visual);

        AnimateSquare(visual, 3);
    }

    private void AnimateSquare(SpriteVisual visual, int delay)
    {
        float offsetX = (float)(visual.Offset.X); // Already adjusted for DPI.

        // Adjust values for DPI scale, then find the Y offset that aligns the bottom of the square
        // with the bottom of the host container. This is the value to animate to.
        var hostHeightAdj = CompositionHostElement.ActualHeight * currentDpi.DpiScaleY;
        var squareSizeAdj = visual.Size.Y * currentDpi.DpiScaleY;
        float bottom = (float)(hostHeightAdj - squareSizeAdj);

        // Create the animation only if it's needed.
        if (visual.Offset.Y != bottom)
        {
            Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
            animation.InsertKeyFrame(1f, new Vector3(offsetX, bottom, 0f));
            animation.Duration = TimeSpan.FromSeconds(2);
            animation.DelayTime = TimeSpan.FromSeconds(delay);
            visual.StartAnimation("Offset", animation);
        }
    }

    private Windows.UI.Color GetRandomColor()
    {
        Random random = new Random();
        byte r = (byte)random.Next(0, 255);
        byte g = (byte)random.Next(0, 255);
        byte b = (byte)random.Next(0, 255);
        return Windows.UI.Color.FromArgb(255, r, g, b);
    }
    ```

### <a name="handle-dpi-changes"></a><span data-ttu-id="8654d-231">DPI 変更を処理します。</span><span class="sxs-lookup"><span data-stu-id="8654d-231">Handle DPI changes</span></span>

<span data-ttu-id="8654d-232">コードを追加して要素をアニメーション化する現在の DPI スケールするときは考慮要素が作成されますが、アプリの実行中に、DPI の変更を考慮する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="8654d-232">The code to add and animate an element takes into account the current DPI scale when elements are created, but you also need to account for DPI changes while the app is running.</span></span> <span data-ttu-id="8654d-233">処理することができます、 [HwndHost.DpiChanged](/dotnet/api/system.windows.interop.hwndhost.dpichanged)新しい DPI に基づいてイベントの変更を通知し、計算の結果を調整します。</span><span class="sxs-lookup"><span data-stu-id="8654d-233">You can handle the [HwndHost.DpiChanged](/dotnet/api/system.windows.interop.hwndhost.dpichanged) event to be notified of changes and adjust your calculations based on the new DPI.</span></span>

1. <span data-ttu-id="8654d-234">CompositionHostControl_Loaded メソッドで最後の行の後、DpiChanged イベントのハンドラーをフックするこれを追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-234">In the CompositionHostControl_Loaded method, after the last line, add this to hook up the DpiChanged event handler.</span></span>

    ```csharp
    compositionHost.DpiChanged += CompositionHost_DpiChanged;
    ```

1. <span data-ttu-id="8654d-235">名前のイベント ハンドラー メソッドを追加_CompositionHostDpiChanged_します。</span><span class="sxs-lookup"><span data-stu-id="8654d-235">Add the event handler method with the name _CompositionHostDpiChanged_.</span></span> <span data-ttu-id="8654d-236">このコードでは、スケールと、各要素のオフセットを調整し、完了しないすべてのアニメーションを再計算されます。</span><span class="sxs-lookup"><span data-stu-id="8654d-236">This code adjusts the scale and offset of each element, and recalculates any animations that aren't complete.</span></span>

    ```csharp
    private void CompositionHost_DpiChanged(object sender, DpiChangedEventArgs e)
    {
        currentDpi = e.NewDpi;
        Vector3 newScale = new Vector3((float)e.NewDpi.DpiScaleX, (float)e.NewDpi.DpiScaleY, 1);

        foreach (SpriteVisual child in containerVisual.Children)
        {
            child.Scale = newScale;
            var newOffsetX = child.Offset.X * ((float)e.NewDpi.DpiScaleX / (float)e.OldDpi.DpiScaleX);
            var newOffsetY = child.Offset.Y * ((float)e.NewDpi.DpiScaleY / (float)e.OldDpi.DpiScaleY);
            child.Offset = new Vector3(newOffsetX, newOffsetY, 1);

            // Adjust animations for DPI change.
            AnimateSquare(child, 0);
        }
    }
    ```

## <a name="add-the-user-control-to-your-xaml-page"></a><span data-ttu-id="8654d-237">XAML ページに、ユーザー コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-237">Add the user control to your XAML page</span></span>

<span data-ttu-id="8654d-238">次に、XAML UI にユーザー コントロールを追加できます。</span><span class="sxs-lookup"><span data-stu-id="8654d-238">Now, you can add the user control to your XAML UI.</span></span>

1. <span data-ttu-id="8654d-239">MainWindow.xaml では、600 と 840 に幅にウィンドウの高さを設定します。</span><span class="sxs-lookup"><span data-stu-id="8654d-239">In MainWindow.xaml, set the Window Height to 600 and the Width to 840.</span></span>
1. <span data-ttu-id="8654d-240">UI の XAML を追加します。</span><span class="sxs-lookup"><span data-stu-id="8654d-240">Add the XAML for the UI.</span></span> <span data-ttu-id="8654d-241">MainWindow.xaml で、ルートの間には、この XAML を追加`<Grid> </Grid>`タグ。</span><span class="sxs-lookup"><span data-stu-id="8654d-241">In MainWindow.xaml, add this XAML between the root `<Grid> </Grid>` tags.</span></span>

    ```xaml
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="210"/>
        <ColumnDefinition Width="600"/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition Height="46"/>
        <RowDefinition/>
    </Grid.RowDefinitions>
    <Button Content="Add composition element" Click="Button_Click"
            Grid.Row="1" Margin="12,0"
            VerticalAlignment="Top" Height="40"/>
    <TextBlock Text="Composition content" FontSize="20"
               Grid.Column="1" Margin="0,12,0,4"
               HorizontalAlignment="Center"/>
    <local:CompositionHostControl x:Name="CompositionHostControl1"
                                  Grid.Row="1" Grid.Column="1"
                                  VerticalAlignment="Top"
                                  Width="600" Height="500"
                                  BorderBrush="LightGray"
                                  BorderThickness="3"/>
    ```

1. <span data-ttu-id="8654d-242">新しい要素を作成するボタンのクリックを処理します。</span><span class="sxs-lookup"><span data-stu-id="8654d-242">Handle the button click to create new elements.</span></span> <span data-ttu-id="8654d-243">(クリック イベントは既にフック、XAML でします。)</span><span class="sxs-lookup"><span data-stu-id="8654d-243">(The Click event is already hooked up in the XAML.)</span></span>

    <span data-ttu-id="8654d-244">MainWindow.xaml.cs でこれを追加*Button_Click*イベント ハンドラー メソッド。</span><span class="sxs-lookup"><span data-stu-id="8654d-244">In MainWindow.xaml.cs, add this *Button_Click* event handler method.</span></span> <span data-ttu-id="8654d-245">このコードは呼び出して_CompositionHost.AddElement_ランダムに生成されたサイズおよびオフセットを新しい要素を作成します。</span><span class="sxs-lookup"><span data-stu-id="8654d-245">This code calls _CompositionHost.AddElement_ to create a new element with a randomly generated size and offset.</span></span>

    ```csharp
    // Add
    // using System;

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Random random = new Random();
        float size = random.Next(50, 150);
        float offsetX = random.Next(0, (int)(CompositionHostControl1.ActualWidth - size));
        float offsetY = random.Next(0, (int)(CompositionHostControl1.ActualHeight/2 - size));
        CompositionHostControl1.AddElement(size, offsetX, offsetY);
    }
    ```

<span data-ttu-id="8654d-246">ビルドして、WPF アプリを実行することができますようになりました。</span><span class="sxs-lookup"><span data-stu-id="8654d-246">You can now build and run your WPF app.</span></span> <span data-ttu-id="8654d-247">必要がある場合は、すべてのコードは、適切な場所にいるかどうかを確認するチュートリアルの最後に完全なコードを確認します。</span><span class="sxs-lookup"><span data-stu-id="8654d-247">If you need to, check the complete code at the end of the tutorial to make sure all the code is in the right places.</span></span>

<span data-ttu-id="8654d-248">アプリを実行する ボタンをクリックすると、UI に追加するアニメーションの正方形が表示されます。</span><span class="sxs-lookup"><span data-stu-id="8654d-248">When you run the app and click the button, you should see animated squares added to the UI.</span></span>

## <a name="next-steps"></a><span data-ttu-id="8654d-249">次のステップ</span><span class="sxs-lookup"><span data-stu-id="8654d-249">Next steps</span></span>

<span data-ttu-id="8654d-250">同じインフラストラクチャ上に構築するより詳細な例については、 [WPF Visual レイヤーの統合サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/VisualLayerIntegration)GitHub でします。</span><span class="sxs-lookup"><span data-stu-id="8654d-250">For a more complete example that builds on the same infrastructure, see the [WPF Visual layer integration sample](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/VisualLayerIntegration) on GitHub.</span></span>

## <a name="additional-resources"></a><span data-ttu-id="8654d-251">その他の資料</span><span class="sxs-lookup"><span data-stu-id="8654d-251">Additional resources</span></span>

- <span data-ttu-id="8654d-252">[概要 (WPF)](/dotnet/framework/wpf/getting-started/) (.NET)</span><span class="sxs-lookup"><span data-stu-id="8654d-252">[Getting Started (WPF)](/dotnet/framework/wpf/getting-started/) (.NET)</span></span>
- <span data-ttu-id="8654d-253">[アンマネージ コードと相互運用](/dotnet/framework/interop/)(.NET)</span><span class="sxs-lookup"><span data-stu-id="8654d-253">[Interoperating with unmanaged code](/dotnet/framework/interop/) (.NET)</span></span>
- <span data-ttu-id="8654d-254">[Windows 10 アプリの概要](/windows/uwp/get-started/)(UWP)</span><span class="sxs-lookup"><span data-stu-id="8654d-254">[Get started with Windows 10 apps](/windows/uwp/get-started/) (UWP)</span></span>
- <span data-ttu-id="8654d-255">[Windows 10 のデスクトップ アプリケーションの拡張](/windows/uwp/porting/desktop-to-uwp-enhance)(UWP)</span><span class="sxs-lookup"><span data-stu-id="8654d-255">[Enhance your desktop application for Windows 10](/windows/uwp/porting/desktop-to-uwp-enhance) (UWP)</span></span>
- <span data-ttu-id="8654d-256">[名前空間の Windows.UI.Composition](/uwp/api/windows.ui.composition) (UWP)</span><span class="sxs-lookup"><span data-stu-id="8654d-256">[Windows.UI.Composition namespace](/uwp/api/windows.ui.composition) (UWP)</span></span>

## <a name="complete-code"></a><span data-ttu-id="8654d-257">コードを完成させる</span><span class="sxs-lookup"><span data-stu-id="8654d-257">Complete code</span></span>

<span data-ttu-id="8654d-258">このチュートリアルの完全なコードを示します。</span><span class="sxs-lookup"><span data-stu-id="8654d-258">Here's the complete code for this tutorial.</span></span>

### <a name="mainwindowxaml"></a><span data-ttu-id="8654d-259">MainWindow.xaml</span><span class="sxs-lookup"><span data-stu-id="8654d-259">MainWindow.xaml</span></span>

```xaml
<Window x:Class="HelloComposition.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:HelloComposition"
        mc:Ignorable="d"
        Title="MainWindow" Height="600" Width="840">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="210"/>
            <ColumnDefinition Width="600"/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="46"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Button Content="Add composition element" Click="Button_Click"
                Grid.Row="1" Margin="12,0"
                VerticalAlignment="Top" Height="40"/>
        <TextBlock Text="Composition content" FontSize="20"
                   Grid.Column="1" Margin="0,12,0,4"
                   HorizontalAlignment="Center"/>
        <local:CompositionHostControl x:Name="CompositionHostControl1"
                                      Grid.Row="1" Grid.Column="1"
                                      VerticalAlignment="Top"
                                      Width="600" Height="500"
                                      BorderBrush="LightGray" BorderThickness="3"/>
    </Grid>
</Window>
```

### <a name="mainwindowxamlcs"></a><span data-ttu-id="8654d-260">MainWindow.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="8654d-260">MainWindow.xaml.cs</span></span>

```csharp
using System;
using System.Windows;

namespace HelloComposition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            float size = random.Next(50, 150);
            float offsetX = random.Next(0, (int)(CompositionHostControl1.ActualWidth - size));
            float offsetY = random.Next(0, (int)(CompositionHostControl1.ActualHeight/2 - size));
            CompositionHostControl1.AddElement(size, offsetX, offsetY);
        }
    }
}
```

### <a name="compositionhostcontrolxaml"></a><span data-ttu-id="8654d-261">CompositionHostControl.xaml</span><span class="sxs-lookup"><span data-stu-id="8654d-261">CompositionHostControl.xaml</span></span>

```xaml
<UserControl x:Class="HelloComposition.CompositionHostControl"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:local="clr-namespace:HelloComposition"
             mc:Ignorable="d"
             d:DesignHeight="450" d:DesignWidth="800">
    <Border Name="CompositionHostElement"/>
</UserControl>
```

### <a name="compositionhostcontrolxamlcs"></a><span data-ttu-id="8654d-262">CompositionHostControl.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="8654d-262">CompositionHostControl.xaml.cs</span></span>

```csharp
using System;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Windows.UI.Composition;

namespace HelloComposition
{
    /// <summary>
    /// Interaction logic for CompositionHostControl.xaml
    /// </summary>
    public partial class CompositionHostControl : UserControl
    {
        CompositionHost compositionHost;
        Compositor compositor;
        Windows.UI.Composition.ContainerVisual containerVisual;
        DpiScale currentDpi;

        public CompositionHostControl()
        {
            InitializeComponent();
            Loaded += CompositionHostControl_Loaded;
        }

        private void CompositionHostControl_Loaded(object sender, RoutedEventArgs e)
        {
            // If the user changes the DPI scale setting for the screen the app is on,
            // the CompositionHostControl is reloaded. Don't redo this set up if it's
            // already been done.
            if (compositionHost is null)
            {
                currentDpi = VisualTreeHelper.GetDpi(this);

                compositionHost = new CompositionHost(CompositionHostElement.ActualHeight, CompositionHostElement.ActualWidth);
                CompositionHostElement.Child = compositionHost;
                compositor = compositionHost.Compositor;
                containerVisual = compositor.CreateContainerVisual();
                compositionHost.Child = containerVisual;
            }
        }

        protected override void OnDpiChanged(DpiScale oldDpi, DpiScale newDpi)
        {
            base.OnDpiChanged(oldDpi, newDpi);
            currentDpi = newDpi;
            Vector3 newScale = new Vector3((float)newDpi.DpiScaleX, (float)newDpi.DpiScaleY, 1);

            foreach (SpriteVisual child in containerVisual.Children)
            {
                child.Scale = newScale;
                var newOffsetX = child.Offset.X * ((float)newDpi.DpiScaleX / (float)oldDpi.DpiScaleX);
                var newOffsetY = child.Offset.Y * ((float)newDpi.DpiScaleY / (float)oldDpi.DpiScaleY);
                child.Offset = new Vector3(newOffsetX, newOffsetY, 1);

                // Adjust animations for DPI change.
                AnimateSquare(child, 0);
            }
        }

        public void AddElement(float size, float offsetX, float offsetY)
        {
            var visual = compositor.CreateSpriteVisual();
            visual.Size = new Vector2(size, size);
            visual.Scale = new Vector3((float)currentDpi.DpiScaleX, (float)currentDpi.DpiScaleY, 1);
            visual.Brush = compositor.CreateColorBrush(GetRandomColor());
            visual.Offset = new Vector3(offsetX * (float)currentDpi.DpiScaleX, offsetY * (float)currentDpi.DpiScaleY, 0);

            containerVisual.Children.InsertAtTop(visual);

            AnimateSquare(visual, 3);
        }

        private void AnimateSquare(SpriteVisual visual, int delay)
        {
            float offsetX = (float)(visual.Offset.X); // Already adjusted for DPI.

            // Adjust values for DPI scale, then find the Y offset that aligns the bottom of the square
            // with the bottom of the host container. This is the value to animate to.
            var hostHeightAdj = CompositionHostElement.ActualHeight * currentDpi.DpiScaleY;
            var squareSizeAdj = visual.Size.Y * currentDpi.DpiScaleY;
            float bottom = (float)(hostHeightAdj - squareSizeAdj);

            // Create the animation only if it's needed.
            if (visual.Offset.Y != bottom)
            {
                Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
                animation.InsertKeyFrame(1f, new Vector3(offsetX, bottom, 0f));
                animation.Duration = TimeSpan.FromSeconds(2);
                animation.DelayTime = TimeSpan.FromSeconds(delay);
                visual.StartAnimation("Offset", animation);
            }
        }

        private Windows.UI.Color GetRandomColor()
        {
            Random random = new Random();
            byte r = (byte)random.Next(0, 255);
            byte g = (byte)random.Next(0, 255);
            byte b = (byte)random.Next(0, 255);
            return Windows.UI.Color.FromArgb(255, r, g, b);
        }
    }
}

```

### <a name="compositionhostcs"></a><span data-ttu-id="8654d-263">CompositionHost.cs</span><span class="sxs-lookup"><span data-stu-id="8654d-263">CompositionHost.cs</span></span>

```csharp
using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Windows.UI.Composition;

namespace HelloComposition
{
    class CompositionHost : HwndHost
    {
        IntPtr hwndHost;
        int hostHeight, hostWidth;
        object dispatcherQueue;
        ICompositionTarget compositionTarget;

        public Compositor Compositor { get; private set; }

        public Visual Child
        {
            set
            {
                if (Compositor == null)
                {
                    InitComposition(hwndHost);
                }
                compositionTarget.Root = value;
            }
        }

        internal const int
          WS_CHILD = 0x40000000,
          WS_VISIBLE = 0x10000000,
          LBS_NOTIFY = 0x00000001,
          HOST_ID = 0x00000002,
          LISTBOX_ID = 0x00000001,
          WS_VSCROLL = 0x00200000,
          WS_BORDER = 0x00800000;

        public CompositionHost(double height, double width)
        {
            hostHeight = (int)height;
            hostWidth = (int)width;
        }

        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            // Create Window
            hwndHost = IntPtr.Zero;
            hwndHost = CreateWindowEx(0, "static", "",
                                      WS_CHILD | WS_VISIBLE,
                                      0, 0,
                                      hostWidth, hostHeight,
                                      hwndParent.Handle,
                                      (IntPtr)HOST_ID,
                                      IntPtr.Zero,
                                      0);

            // Create Dispatcher Queue
            dispatcherQueue = InitializeCoreDispatcher();

            // Build Composition Tree of content
            InitComposition(hwndHost);

            return new HandleRef(this, hwndHost);
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            if (compositionTarget.Root != null)
            {
                compositionTarget.Root.Dispose();
            }
            DestroyWindow(hwnd.Handle);
        }

        private object InitializeCoreDispatcher()
        {
            DispatcherQueueOptions options = new DispatcherQueueOptions();
            options.apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA;
            options.threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT;
            options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));

            object queue = null;
            CreateDispatcherQueueController(options, out queue);
            return queue;
        }

        private void InitComposition(IntPtr hwndHost)
        {
            ICompositorDesktopInterop interop;

            Compositor = new Compositor();
            object iunknown = Compositor as object;
            interop = (ICompositorDesktopInterop)iunknown;
            IntPtr raw;
            interop.CreateDesktopWindowTarget(hwndHost, true, out raw);

            object rawObject = Marshal.GetObjectForIUnknown(raw);
            compositionTarget = (ICompositionTarget)rawObject;

            if (raw == null) { throw new Exception("QI Failed"); }
        }

        #region PInvoke declarations

        //typedef enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
        //{
        //    DQTAT_COM_NONE,
        //    DQTAT_COM_ASTA,
        //    DQTAT_COM_STA
        //};
        internal enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
        {
            DQTAT_COM_NONE = 0,
            DQTAT_COM_ASTA = 1,
            DQTAT_COM_STA = 2
        };

        //typedef enum DISPATCHERQUEUE_THREAD_TYPE
        //{
        //    DQTYPE_THREAD_DEDICATED,
        //    DQTYPE_THREAD_CURRENT
        //};
        internal enum DISPATCHERQUEUE_THREAD_TYPE
        {
            DQTYPE_THREAD_DEDICATED = 1,
            DQTYPE_THREAD_CURRENT = 2,
        };

        //struct DispatcherQueueOptions
        //{
        //    DWORD dwSize;
        //    DISPATCHERQUEUE_THREAD_TYPE threadType;
        //    DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
        //};
        [StructLayout(LayoutKind.Sequential)]
        internal struct DispatcherQueueOptions
        {
            public int dwSize;

            [MarshalAs(UnmanagedType.I4)]
            public DISPATCHERQUEUE_THREAD_TYPE threadType;

            [MarshalAs(UnmanagedType.I4)]
            public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
        };

        //HRESULT CreateDispatcherQueueController(
        //  DispatcherQueueOptions options,
        //  ABI::Windows::System::IDispatcherQueueController** dispatcherQueueController
        //);
        [DllImport("coremessaging.dll", EntryPoint = "CreateDispatcherQueueController", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateDispatcherQueueController(DispatcherQueueOptions options,
                                                [MarshalAs(UnmanagedType.IUnknown)]
                                               out object dispatcherQueueController);


        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowEx(int dwExStyle,
                                                      string lpszClassName,
                                                      string lpszWindowName,
                                                      int style,
                                                      int x, int y,
                                                      int width, int height,
                                                      IntPtr hwndParent,
                                                      IntPtr hMenu,
                                                      IntPtr hInst,
                                                      [MarshalAs(UnmanagedType.AsAny)] object pvParam);

        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
        internal static extern bool DestroyWindow(IntPtr hwnd);


        #endregion PInvoke declarations

    }
    #region COM Interop

    /*
    #undef INTERFACE
    #define INTERFACE ICompositorDesktopInterop
        DECLARE_INTERFACE_IID_(ICompositorDesktopInterop, IUnknown, "29E691FA-4567-4DCA-B319-D0F207EB6807")
        {
            IFACEMETHOD(CreateDesktopWindowTarget)(
                _In_ HWND hwndTarget,
                _In_ BOOL isTopmost,
                _COM_Outptr_ IDesktopWindowTarget * *result
                ) PURE;
        };
    */
    [ComImport]
    [Guid("29E691FA-4567-4DCA-B319-D0F207EB6807")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICompositorDesktopInterop
    {
        void CreateDesktopWindowTarget(IntPtr hwndTarget, bool isTopmost, out IntPtr test);
    }

    //[contract(Windows.Foundation.UniversalApiContract, 2.0)]
    //[exclusiveto(Windows.UI.Composition.CompositionTarget)]
    //[uuid(A1BEA8BA - D726 - 4663 - 8129 - 6B5E7927FFA6)]
    //interface ICompositionTarget : IInspectable
    //{
    //    [propget] HRESULT Root([out] [retval] Windows.UI.Composition.Visual** value);
    //    [propput] HRESULT Root([in] Windows.UI.Composition.Visual* value);
    //}

    [ComImport]
    [Guid("A1BEA8BA-D726-4663-8129-6B5E7927FFA6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface ICompositionTarget
    {
        Windows.UI.Composition.Visual Root
        {
            get;
            set;
        }
    }

    #endregion COM Interop
}
```