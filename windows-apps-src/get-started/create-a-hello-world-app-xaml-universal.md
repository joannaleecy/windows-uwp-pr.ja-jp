---
author: GrantMeStrength
ms.assetid: 03A74239-D4B6-4E41-B2FA-6C04F225B844
title: "\"Hello, world\" アプリを作成する方法 (XAML)"
description: Windows 10 のユニバーサル Windows プラットフォーム (UWP) を対象にした単純な Hello, world アプリを Extensible Application Markup Language (XAML) を使って C# で作成します。
ms.author: jken
ms.date: 03/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 初めてのアプリ, hello world
ms.localizationpriority: medium
ms.openlocfilehash: 950b2f3fac44c8350a51fd5c1b7071f05c92d746
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3383444"
---
# <a name="create-a-hello-world-app-xaml"></a><span data-ttu-id="5465d-104">"Hello, world" アプリを作成する (XAML)</span><span class="sxs-lookup"><span data-stu-id="5465d-104">Create a "Hello, world" app (XAML)</span></span>

<span data-ttu-id="5465d-105">このチュートリアルでは、Windows 10 のユニバーサル Windows プラットフォーム (UWP) 向けの単純な "Hello, world" アプリを XAML と C# で作る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5465d-105">This tutorial teaches you how to use XAML and C# to create a simple "Hello, world" app for the Universal Windows Platform (UWP) on Windows 10.</span></span> <span data-ttu-id="5465d-106">Microsoft Visual Studio プロジェクトを 1 つ開発すれば、あらゆる Windows 10 デバイスで動作するアプリを構築できます。</span><span class="sxs-lookup"><span data-stu-id="5465d-106">With a single project in Microsoft Visual Studio, you can build an app that runs on any Windows 10 device.</span></span>

<span data-ttu-id="5465d-107">ここでは、次の方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5465d-107">Here you'll learn how to:</span></span>

-   <span data-ttu-id="5465d-108">**Windows 10** と **UWP** を対象とする新しい **Visual Studio 2017** プロジェクトを作る。</span><span class="sxs-lookup"><span data-stu-id="5465d-108">Create a new **Visual Studio 2017** project that targets **Windows 10** and the **UWP**.</span></span>
-   <span data-ttu-id="5465d-109">スタート ページの UI を変更するように XAML を記述する。</span><span class="sxs-lookup"><span data-stu-id="5465d-109">Write XAML to change the UI on your start page.</span></span>
-   <span data-ttu-id="5465d-110">Visual Studio のローカル デスクトップでプロジェクトを実行する。</span><span class="sxs-lookup"><span data-stu-id="5465d-110">Run the project on the local desktop in Visual Studio.</span></span>
-   <span data-ttu-id="5465d-111">SpeechSynthesizer を使って、ボタンが押されたときにアプリがコンテンツを読み上げるようにする。</span><span class="sxs-lookup"><span data-stu-id="5465d-111">Use a SpeechSynthesizer to make the app talk when you press a button.</span></span>


## <a name="before-you-start"></a><span data-ttu-id="5465d-112">はじめに...</span><span class="sxs-lookup"><span data-stu-id="5465d-112">Before you start...</span></span>

-   [<span data-ttu-id="5465d-113">ユニバーサル Windows アプリとは?</span><span class="sxs-lookup"><span data-stu-id="5465d-113">What's a Universal Windows app?</span></span>](universal-application-platform-guide.md)
-   <span data-ttu-id="5465d-114">[Visual Studio 2017 (および Windows 10) をダウンロードします](https://developer.microsoft.com/windows/downloads)。</span><span class="sxs-lookup"><span data-stu-id="5465d-114">[Download Visual Studio 2017 (and Windows 10)](https://developer.microsoft.com/windows/downloads).</span></span> <span data-ttu-id="5465d-115">サポートが必要な場合は、[セットアップする](get-set-up.md)方法をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5465d-115">If you need a hand, learn how to [get set up](get-set-up.md).</span></span>
-   <span data-ttu-id="5465d-116">また、Visual Studio の既定のウィンドウ レイアウトを使用することを前提としています。</span><span class="sxs-lookup"><span data-stu-id="5465d-116">We also assume you're using the default window layout in Visual Studio.</span></span> <span data-ttu-id="5465d-117">既定のレイアウトを変更した場合は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** を使って、レイアウトをリセットできます。</span><span class="sxs-lookup"><span data-stu-id="5465d-117">If you change the default layout, you can reset it in the **Window** menu by using the **Reset Window Layout** command.</span></span>

> [!NOTE]
> <span data-ttu-id="5465d-118">このチュートリアルでは、Visual Studio Community 2017 を使います。</span><span class="sxs-lookup"><span data-stu-id="5465d-118">This tutorial is using Visual Studio Community 2017.</span></span> <span data-ttu-id="5465d-119">異なるバージョンの Visual Studio を使っている場合には、見た目が多少異なることがあります。</span><span class="sxs-lookup"><span data-stu-id="5465d-119">If you are using a different version of Visual Studio, it may look a little different for you.</span></span>

## <a name="video-summary"></a><span data-ttu-id="5465d-120">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="5465d-120">Video summary</span></span>

<iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Writing-Your-First-Windows-10-App/player" width="640" height="360" allowFullScreen frameBorder="0"></iframe>



## <a name="step-1-create-a-new-project-in-visual-studio"></a><span data-ttu-id="5465d-121">手順 1. Visual Studio で新しいプロジェクトを作る</span><span class="sxs-lookup"><span data-stu-id="5465d-121">Step 1: Create a new project in Visual Studio.</span></span>

1.  <span data-ttu-id="5465d-122">Visual Studio 2017 を起動します。</span><span class="sxs-lookup"><span data-stu-id="5465d-122">Launch Visual Studio 2017.</span></span>

2.  <span data-ttu-id="5465d-123">**[ファイル**] メニューから選択**新規 > プロジェクト**を*新しいプロジェクト*] ダイアログを開きます。</span><span class="sxs-lookup"><span data-stu-id="5465d-123">From the **File** menu, select **New > Project** to open the *New Project* dialog.</span></span>

3.  <span data-ttu-id="5465d-124">左側のテンプレートの一覧から選択**インストール済み > Visual C#] > Windows ユニバーサル**UWP プロジェクト テンプレートの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="5465d-124">From the list of templates on the left, choose **Installed > Visual C# > Windows Universal** to see the list of UWP project templates.</span></span>

    <span data-ttu-id="5465d-125">ユニバーサル テンプレートが表示されない場合は、UWP アプリを作成するためのコンポーネントがない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5465d-125">(If you don't see any Universal templates, you might be missing the components for creating UWP apps.</span></span> <span data-ttu-id="5465d-126">インストール プロセスを繰り返して UWP サポートを追加することもできます (*[新しいプロジェクト]* ダイアログで **[Visual Studio インストーラーを開く]** をクリック)。</span><span class="sxs-lookup"><span data-stu-id="5465d-126">You can repeat the installation process and add UWP support by clicking **Open Visual Studio installer** on the *New Project* dialog.</span></span> <span data-ttu-id="5465d-127">参照[準備](get-set-up.md))。</span><span class="sxs-lookup"><span data-stu-id="5465d-127">See [Get set up](get-set-up.md).)</span></span>

    ![インストール プロセスを繰り返す方法](images/win10-cs-install.png)

4.  <span data-ttu-id="5465d-129">**[空白のアプリ (ユニバーサル Windows)]** テンプレートを選択し、**[名前]** に「HelloWorld」と入力します。</span><span class="sxs-lookup"><span data-stu-id="5465d-129">Choose the **Blank App (Universal Windows)** template, and enter "HelloWorld" as the **Name**.</span></span> <span data-ttu-id="5465d-130">**[OK]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="5465d-130">Select **OK**.</span></span>

    ![[新しいプロジェクト] ウィンドウ](images/win10-cs-01.png)

> [!NOTE]
> <span data-ttu-id="5465d-132">Visual Studio を初めて使う場合は、[設定] ダイアログ ボックスが表示され、**開発者モード**を有効にするよう求められることがあります。</span><span class="sxs-lookup"><span data-stu-id="5465d-132">If this is the first time you have used Visual Studio, you might see a Settings dialog asking you to enable **Developer mode**.</span></span> <span data-ttu-id="5465d-133">開発者モードは、アプリをストアからだけではなく、直接実行するためのアクセス許可など、特定の機能を有効にする特別な設定です。</span><span class="sxs-lookup"><span data-stu-id="5465d-133">Developer mode is a special setting that enables certain features, such as permission to run apps directly, rather than only from the Store.</span></span> <span data-ttu-id="5465d-134">詳しくは、「[デバイスを開発用に有効にする](enable-your-device-for-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5465d-134">For more information, please read [Enable your device for development](enable-your-device-for-development.md).</span></span> <span data-ttu-id="5465d-135">先に進むには、**[開発者モード]** を選択し、**[はい]** をクリックしてダイアログ ボックスを閉じます。</span><span class="sxs-lookup"><span data-stu-id="5465d-135">To continue with this guide, select **Developer mode**, click **Yes**, and close the dialog.</span></span>

 ![開発者モードのアクティブ化ダイアログ](images/win10-cs-00.png)

5.  <span data-ttu-id="5465d-137">ターゲット バージョンと最小バージョンのダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5465d-137">The target version/minimum version dialog appears.</span></span> <span data-ttu-id="5465d-138">このチュートリアルでは既定の設定で問題ないため、**[OK]** を選択してプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="5465d-138">The default settings are fine for this tutorial, so select **OK** to create the project.</span></span>

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-02.png)

6.  <span data-ttu-id="5465d-140">新しいプロジェクトが開き、そのプロジェクトのファイルが右側の**ソリューション エクスプローラー**のウィンドウに表示されます。</span><span class="sxs-lookup"><span data-stu-id="5465d-140">When your new project opens, its files are displayed in the **Solution Explorer** pane on the right.</span></span> <span data-ttu-id="5465d-141">場合によっては、ファイルを表示するために **[ソリューション エクスプローラー]** タブを選択する必要があります (**[プロパティ]** タブではありません)。</span><span class="sxs-lookup"><span data-stu-id="5465d-141">You may need to choose the **Solution Explorer** tab instead of the **Properties** tab to see your files.</span></span>

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-03.png)

<span data-ttu-id="5465d-143">**[空白のアプリ (ユニバーサル Windows)]** は最小限のテンプレートですが、多くのファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="5465d-143">Although the **Blank App (Universal Window)** is a minimal template, it still contains a lot of files.</span></span> <span data-ttu-id="5465d-144">これらのファイルは、C# を使うすべての UWP アプリに必要です。</span><span class="sxs-lookup"><span data-stu-id="5465d-144">These files are essential to all UWP apps using C#.</span></span> <span data-ttu-id="5465d-145">Visual Studio で作るすべてのプロジェクトには、これらのファイルが必ず含まれます。</span><span class="sxs-lookup"><span data-stu-id="5465d-145">Every project that you create in Visual Studio contains them.</span></span>


### <a name="whats-in-the-files"></a><span data-ttu-id="5465d-146">ファイルの内容</span><span class="sxs-lookup"><span data-stu-id="5465d-146">What's in the files?</span></span>

<span data-ttu-id="5465d-147">プロジェクトのファイルを表示して編集するには、**ソリューション エクスプローラー**でファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="5465d-147">To view and edit a file in your project, double-click the file in the **Solution Explorer**.</span></span> <span data-ttu-id="5465d-148">フォルダーと同様、XAML ファイルを展開して、関連するコード ファイルを表示します。</span><span class="sxs-lookup"><span data-stu-id="5465d-148">Expand a XAML file just like a folder to see its associated code file.</span></span> <span data-ttu-id="5465d-149">XAML ファイルは、デザイン サーフェスと XAML エディターの両方を表示する分割ビューで開きます。</span><span class="sxs-lookup"><span data-stu-id="5465d-149">XAML files open in a split view that shows both the design surface and the XAML editor.</span></span>
> [!NOTE]
> <span data-ttu-id="5465d-150">XAML とは</span><span class="sxs-lookup"><span data-stu-id="5465d-150">What is XAML?</span></span> <span data-ttu-id="5465d-151">Extensible Application Markup Language (XAML) は、アプリのユーザー インターフェイスを定義するための言語です。</span><span class="sxs-lookup"><span data-stu-id="5465d-151">Extensible Application Markup Language (XAML) is the language used to define your app's user interface.</span></span> <span data-ttu-id="5465d-152">XAML は、手動で入力することも、Visual Studio のデザイン ツールを使って作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="5465d-152">It can be entered manually, or created using the Visual Studio design tools.</span></span> <span data-ttu-id="5465d-153">.xaml ファイルには、ロジックが格納される .xaml.cs 分離コード ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="5465d-153">A .xaml file has a .xaml.cs code-behind file which contains the logic.</span></span> <span data-ttu-id="5465d-154">XAML と分離コードがまとまって、完全なクラスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="5465d-154">Together, the XAML and code-behind make a complete class.</span></span> <span data-ttu-id="5465d-155">詳しくは、「[XAML の概要](https://msdn.microsoft.com/library/windows/apps/Mt185595)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5465d-155">For more information, see [XAML overview](https://msdn.microsoft.com/library/windows/apps/Mt185595).</span></span>

*<span data-ttu-id="5465d-156">App.xaml と App.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="5465d-156">App.xaml and App.xaml.cs</span></span>*

-   <span data-ttu-id="5465d-157">App.xaml は、アプリ全体で使われるリソースを宣言するファイルです。</span><span class="sxs-lookup"><span data-stu-id="5465d-157">App.xaml is where you declare resources that are used across the app.</span></span>
-   <span data-ttu-id="5465d-158">App.xaml.cs は、App.xaml の分離コード ファイルです。</span><span class="sxs-lookup"><span data-stu-id="5465d-158">App.xaml.cs is the code-behind file for App.xaml.</span></span> <span data-ttu-id="5465d-159">すべての分離コード ページと同じように、`InitializeComponent` メソッドを呼び出すコンストラクターが含まれています。</span><span class="sxs-lookup"><span data-stu-id="5465d-159">Like all code-behind pages, it contains a constructor that calls the `InitializeComponent` method.</span></span> <span data-ttu-id="5465d-160">`InitializeComponent` メソッドは自分で記述する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5465d-160">You don't write the `InitializeComponent` method.</span></span> <span data-ttu-id="5465d-161">Visual Studio によって生成されるこのメソッドの主な目的は、XAML ファイルに宣言された要素を初期化することです。</span><span class="sxs-lookup"><span data-stu-id="5465d-161">It's generated by Visual Studio, and its main purpose is to initialize the elements declared in the XAML file.</span></span>
-   <span data-ttu-id="5465d-162">App.xaml.cs は、アプリのエントリ ポイントです。</span><span class="sxs-lookup"><span data-stu-id="5465d-162">App.xaml.cs is the entry point for your app.</span></span>
-   <span data-ttu-id="5465d-163">App.xaml.cs には、アプリのアクティブ化と中断を処理するためのメソッドも含まれています。</span><span class="sxs-lookup"><span data-stu-id="5465d-163">App.xaml.cs also contains methods to handle activation and suspension of the app.</span></span>

*<span data-ttu-id="5465d-164">MainPage.xaml</span><span class="sxs-lookup"><span data-stu-id="5465d-164">MainPage.xaml</span></span>*

-   <span data-ttu-id="5465d-165">MainPage.xaml は、アプリの UI を定義する場所です。</span><span class="sxs-lookup"><span data-stu-id="5465d-165">MainPage.xaml is where you define the UI for your app.</span></span> <span data-ttu-id="5465d-166">要素の追加は、XAML マークアップを使って直接行うことも、Visual Studio のデザイン ツールを使って行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="5465d-166">You can add elements directly using XAML markup, or you can use the design tools provided by Visual Studio.</span></span>
-   <span data-ttu-id="5465d-167">MainPage.xaml.cs は、MainPage.xaml のコード ビハインド ページです。</span><span class="sxs-lookup"><span data-stu-id="5465d-167">MainPage.xaml.cs is the code-behind page for MainPage.xaml.</span></span> <span data-ttu-id="5465d-168">ここには、アプリのロジックとイベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="5465d-168">It's where you add your app logic and event handlers.</span></span>
-   <span data-ttu-id="5465d-169">これら 2 つのファイルで、[**Page**](https://msdn.microsoft.com/library/windows/apps/BR227503) から継承される `MainPage` という新しいクラスを `HelloWorld` 名前空間に定義します。</span><span class="sxs-lookup"><span data-stu-id="5465d-169">Together these two files define a new class called `MainPage`, which inherits from [**Page**](https://msdn.microsoft.com/library/windows/apps/BR227503), in the `HelloWorld` namespace.</span></span>

*<span data-ttu-id="5465d-170">Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="5465d-170">Package.appxmanifest</span></span>*
-   <span data-ttu-id="5465d-171">名前、説明、タイル、開始ページなど、アプリを説明するマニフェスト ファイルです。</span><span class="sxs-lookup"><span data-stu-id="5465d-171">A manifest file that describes your app: its name, description, tile, start page, etc.</span></span>
-   <span data-ttu-id="5465d-172">アプリに含まれるファイルの一覧が含まれています。</span><span class="sxs-lookup"><span data-stu-id="5465d-172">Includes a list of the files that your app contains.</span></span>

*<span data-ttu-id="5465d-173">一連のロゴ イメージ</span><span class="sxs-lookup"><span data-stu-id="5465d-173">A set of logo images</span></span>*
-   <span data-ttu-id="5465d-174">Assets/Square150x150Logo.scale-200.png は、スタート メニュー内のアプリを表します。</span><span class="sxs-lookup"><span data-stu-id="5465d-174">Assets/Square150x150Logo.scale-200.png represents your app in the start menu.</span></span>
-   <span data-ttu-id="5465d-175">Assets/StoreLogo.png は、Microsoft Store 内のアプリを表します。</span><span class="sxs-lookup"><span data-stu-id="5465d-175">Assets/StoreLogo.png represents your app in the Microsoft Store.</span></span>
-   <span data-ttu-id="5465d-176">Assets/SplashScreen.scale-200.png は、アプリが起動したときに表示するスプラッシュ画面です。</span><span class="sxs-lookup"><span data-stu-id="5465d-176">Assets/SplashScreen.scale-200.png is the splash screen that appears when your app starts.</span></span>

## <a name="step-2-adding-a-button"></a><span data-ttu-id="5465d-177">手順 2. ボタンを追加する</span><span class="sxs-lookup"><span data-stu-id="5465d-177">Step 2: Adding a button</span></span>

### <a name="using-the-designer-view"></a><span data-ttu-id="5465d-178">デザイナー ビューの使用</span><span class="sxs-lookup"><span data-stu-id="5465d-178">Using the designer view</span></span>

<span data-ttu-id="5465d-179">ページにボタンを追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="5465d-179">Let's add a button to our page.</span></span> <span data-ttu-id="5465d-180">このチュートリアルでは、前に示した複数のファイルの一部 (App.xaml、MainPage.xaml、および MainPage.xaml.cs) のみを操作します。</span><span class="sxs-lookup"><span data-stu-id="5465d-180">In this tutorial, you work with just a few of the files listed previously: App.xaml, MainPage.xaml, and MainPage.xaml.cs.</span></span>

1.  <span data-ttu-id="5465d-181">**MainPage.xaml** をダブルクリックしてデザイン ビューで開きます。</span><span class="sxs-lookup"><span data-stu-id="5465d-181">Double-click on **MainPage.xaml** to open it in the Design view.</span></span>

    <span data-ttu-id="5465d-182">画面の上部にグラフィック ビュー、その下部に XAML コード ビューがあります。</span><span class="sxs-lookup"><span data-stu-id="5465d-182">You'll notice there is a graphical view on the top part of the screen, and the XAML code view underneath.</span></span> <span data-ttu-id="5465d-183">どちらのビューでも変更を加えることができますが、ここではグラフィック ビューを使います。</span><span class="sxs-lookup"><span data-stu-id="5465d-183">You can make changes to either, but for now we'll use the graphical view.</span></span>

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-04.png)

2.  <span data-ttu-id="5465d-185">左側の縦方向に配置された **[ツールボックス]** タブをクリックして UI コントロールの一覧を開きます </span><span class="sxs-lookup"><span data-stu-id="5465d-185">Click on the vertical **Toolbox** tab on the left to open the list of UI controls.</span></span> <span data-ttu-id="5465d-186">(タイトル バーのピン アイコンをクリックすると、このウィンドウを表示したままにすることができます)。</span><span class="sxs-lookup"><span data-stu-id="5465d-186">(You can click the pin icon in its title bar to keep it visible.)</span></span>

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-05.png)

3.  <span data-ttu-id="5465d-188">**[コモン XAML コントロール]** を展開し、**Button** をドラッグしてデザイン キャンバスの中央に配置します。</span><span class="sxs-lookup"><span data-stu-id="5465d-188">Expand **Common XAML Controls**, and drag the **Button** out to the middle of the design canvas.</span></span>

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-06.png)

    <span data-ttu-id="5465d-190">XAML コード ウィンドウを見ると、そこにも Button が追加されたことがわかります。</span><span class="sxs-lookup"><span data-stu-id="5465d-190">If you look at the XAML code window, you'll see that the Button has been added there too:</span></span>

 ```XAML
<Button x:name="button" Content="Button" HorizontalAlignment="Left" Margin = "152,293,0,0" VerticalAlignment="Top"/>
 ```

4.  <span data-ttu-id="5465d-191">ボタンのテキストを変更します。</span><span class="sxs-lookup"><span data-stu-id="5465d-191">Change the button's text.</span></span>

    <span data-ttu-id="5465d-192">XAML コード ビュー内をクリックし、Content の値を "Button" から "Hello, world!" に変更します。</span><span class="sxs-lookup"><span data-stu-id="5465d-192">Click in the XAML code view, and change the Content from "Button" to "Hello, world!".</span></span>

```XAML
<Button x:name="button" Content="Hello, world!" HorizontalAlignment="Left" Margin = "152,293,0,0" VerticalAlignment="Top"/>
```

<span data-ttu-id="5465d-193">デザイン キャンバスに表示されたボタンが更新され、新しいテキストが表示されることがわかります。</span><span class="sxs-lookup"><span data-stu-id="5465d-193">Notice how the button displayed in the design canvas updates to display the new text.</span></span>

![ソリューション エクスプローラーのウィンドウ](images/win10-cs-07.png)

## <a name="step-3-start-the-app"></a><span data-ttu-id="5465d-195">手順 3. アプリを起動する</span><span class="sxs-lookup"><span data-stu-id="5465d-195">Step 3: Start the app</span></span>


<span data-ttu-id="5465d-196">ここまでの操作で、非常に単純なアプリが作成されました。</span><span class="sxs-lookup"><span data-stu-id="5465d-196">At this point, you've created a very simple app.</span></span> <span data-ttu-id="5465d-197">ここで、アプリをビルド、デプロイ、起動してどうなるかを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="5465d-197">This is a good time to build, deploy, and launch your app and see what it looks like.</span></span> <span data-ttu-id="5465d-198">アプリは、ローカル コンピューター、シミュレーターかエミュレーター、またはリモート デバイスでデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="5465d-198">You can debug your app on the local machine, in a simulator or emulator, or on a remote device.</span></span> <span data-ttu-id="5465d-199">Visual Studio の [ターゲット デバイス] メニューを示します。</span><span class="sxs-lookup"><span data-stu-id="5465d-199">Here's the target device menu in Visual Studio.</span></span>

![アプリをデバッグするデバイス ターゲットのドロップダウン リスト](images/uap-debug.png)

### <a name="start-the-app-on-a-desktop-device"></a><span data-ttu-id="5465d-201">デスクトップ デバイスでアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="5465d-201">Start the app on a Desktop device</span></span>

<span data-ttu-id="5465d-202">既定では、アプリはローカル コンピューターで実行されます。</span><span class="sxs-lookup"><span data-stu-id="5465d-202">By default, the app runs on the local machine.</span></span> <span data-ttu-id="5465d-203">[ターゲット デバイス] メニューには、デスクトップ デバイス ファミリのデバイスでアプリをデバッグするためのいくつかのオプションが用意されています。</span><span class="sxs-lookup"><span data-stu-id="5465d-203">The target device menu provides several options for debugging your app on devices from the desktop device family.</span></span>

-   **<span data-ttu-id="5465d-204">シミュレーター</span><span class="sxs-lookup"><span data-stu-id="5465d-204">Simulator</span></span>**
-   **<span data-ttu-id="5465d-205">ローカル コンピューター</span><span class="sxs-lookup"><span data-stu-id="5465d-205">Local Machine</span></span>**
-   **<span data-ttu-id="5465d-206">リモート コンピューター</span><span class="sxs-lookup"><span data-stu-id="5465d-206">Remote Machine</span></span>**

**<span data-ttu-id="5465d-207">ローカル コンピューターでデバッグを開始するには</span><span class="sxs-lookup"><span data-stu-id="5465d-207">To start debugging on the local machine</span></span>**

1.  <span data-ttu-id="5465d-208">**[標準]** ツール バーの [ターゲット デバイス] メニュー (![[デバッグの開始] メニュー](images/startdebug-full.png)) で、**[ローカル コンピューター]** が選択されていることを確認します </span><span class="sxs-lookup"><span data-stu-id="5465d-208">In the target device menu (![Start debugging menu](images/startdebug-full.png)) on the **Standard** toolbar, make sure that **Local Machine** is selected.</span></span> <span data-ttu-id="5465d-209">(既定で選択されています)。</span><span class="sxs-lookup"><span data-stu-id="5465d-209">(It's the default selection.)</span></span>
2.  <span data-ttu-id="5465d-210">ツール バーの **[デバッグの開始]** ボタン (![[デバッグの開始] ボタン](images/startdebug-sm.png)) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5465d-210">Click the **Start Debugging** button (![Start debugging button](images/startdebug-sm.png)) on the toolbar.</span></span>

   <span data-ttu-id="5465d-211">または</span><span class="sxs-lookup"><span data-stu-id="5465d-211">–or–</span></span>

   <span data-ttu-id="5465d-212">**[デバッグ]** メニューの **[デバッグの開始]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5465d-212">From the **Debug** menu, click **Start Debugging**.</span></span>

   <span data-ttu-id="5465d-213">または</span><span class="sxs-lookup"><span data-stu-id="5465d-213">–or–</span></span>

   <span data-ttu-id="5465d-214">F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="5465d-214">Press F5.</span></span>

<span data-ttu-id="5465d-215">アプリがウィンドウで開かれ、最初に既定のスプラッシュ画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="5465d-215">The app opens in a window, and a default splash screen appears first.</span></span> <span data-ttu-id="5465d-216">スプラッシュ画面は、画像 (SplashScreen.png) と背景色によって定義されます (背景色はアプリのマニフェスト ファイルに指定します)。</span><span class="sxs-lookup"><span data-stu-id="5465d-216">The splash screen is defined by an image (SplashScreen.png) and a background color (specified in your app's manifest file).</span></span>

<span data-ttu-id="5465d-217">スプラッシュ画面が消えた後、アプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5465d-217">The splash screen disappears, and then your app appears.</span></span> <span data-ttu-id="5465d-218">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="5465d-218">It looks like this.</span></span>

![アプリの初期画面](images/win10-cs-08.png)

<span data-ttu-id="5465d-220">Windows キーを押して **[スタート]** メニューを開き、すべてのアプリを表示します。</span><span class="sxs-lookup"><span data-stu-id="5465d-220">Press the Windows key to open the **Start** menu, then show all apps.</span></span> <span data-ttu-id="5465d-221">ローカルに配置したアプリのタイルが **[スタート]** メニューに追加されています。</span><span class="sxs-lookup"><span data-stu-id="5465d-221">Notice that deploying the app locally adds its tile to the **Start** menu.</span></span> <span data-ttu-id="5465d-222">後でもう一度 (デバッグ モード以外で) アプリを実行するときは、**[スタート]** メニューでこのタイルをタップまたはクリックします。</span><span class="sxs-lookup"><span data-stu-id="5465d-222">To run the app again later (not in debugging mode), tap or click its tile in the **Start** menu.</span></span>

<span data-ttu-id="5465d-223">お疲れさまでした。これで、初めての UWP アプリの作成は完了です。</span><span class="sxs-lookup"><span data-stu-id="5465d-223">It doesn't do much—yet—but congratulations, you've built your first UWP app!</span></span>

**<span data-ttu-id="5465d-224">デバッグを停止するには</span><span class="sxs-lookup"><span data-stu-id="5465d-224">To stop debugging</span></span>**

   <span data-ttu-id="5465d-225">ツール バーの **[デバッグの停止]** ボタン (![[デバッグの停止] ボタン](images/stopdebug.png)) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5465d-225">Click the **Stop Debugging** button (![Stop debugging button](images/stopdebug.png)) in the toolbar.</span></span>

   <span data-ttu-id="5465d-226">または</span><span class="sxs-lookup"><span data-stu-id="5465d-226">–or–</span></span>

   <span data-ttu-id="5465d-227">**[デバッグ]** メニューの **[デバッグの停止]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5465d-227">From the **Debug** menu, click **Stop debugging**.</span></span>

   <span data-ttu-id="5465d-228">- または -</span><span class="sxs-lookup"><span data-stu-id="5465d-228">–or–</span></span>

   <span data-ttu-id="5465d-229">アプリ ウィンドウを閉じます。</span><span class="sxs-lookup"><span data-stu-id="5465d-229">Close the app window.</span></span>

## <a name="step-4-event-handlers"></a><span data-ttu-id="5465d-230">手順 4. イベント ハンドラー</span><span class="sxs-lookup"><span data-stu-id="5465d-230">Step 4: Event handlers</span></span>

<span data-ttu-id="5465d-231">"イベント ハンドラー" は複雑なもののように聞こえますが、イベント (ユーザーによるボタンのクリックなど) が発生したときに呼び出されるコードの別名にすぎません。</span><span class="sxs-lookup"><span data-stu-id="5465d-231">An "event handler" sounds complicated, but it's just another name for the code that is called when an event happens (such as the user clicking on your button).</span></span>

1.  <span data-ttu-id="5465d-232">アプリの実行を停止します (まだ停止していない場合)。</span><span class="sxs-lookup"><span data-stu-id="5465d-232">Stop the app from running, if you haven't already.</span></span>

2.  <span data-ttu-id="5465d-233">デザイン キャンバス上のボタン コントロールをダブルクリックします。Visual Studio によってボタンのイベント ハンドラーが作成されます。</span><span class="sxs-lookup"><span data-stu-id="5465d-233">Double-click on the button control on the design canvas to make Visual Studio create an event handler for your button.</span></span>

  <span data-ttu-id="5465d-234">もちろん、すべてのコードを手動で作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="5465d-234">You can of course, create all the code manually too.</span></span> <span data-ttu-id="5465d-235">または、ボタンをクリックして選択し、右下の **[プロパティ]** ウィンドウを確認します。</span><span class="sxs-lookup"><span data-stu-id="5465d-235">Or you can click on the button to select it, and look in the **Properties** pane on the lower right.</span></span> <span data-ttu-id="5465d-236">**[イベント]** (小さな稲妻) に切り替えると、イベント ハンドラーの名前を追加することができます。</span><span class="sxs-lookup"><span data-stu-id="5465d-236">If you switch to **Events** (the little lightning bolt) you can add the name of your event handler.</span></span>

3.  <span data-ttu-id="5465d-237">*MainPage.xaml.cs* (分離コード ページ) でイベント ハンドラーを編集します。</span><span class="sxs-lookup"><span data-stu-id="5465d-237">Edit the event handler code in *MainPage.xaml.cs*, the code-behind page.</span></span> <span data-ttu-id="5465d-238">ここから面白くなります。</span><span class="sxs-lookup"><span data-stu-id="5465d-238">This is where things get interesting.</span></span> <span data-ttu-id="5465d-239">既定のイベント ハンドラーは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="5465d-239">The default event handler looks like this:</span></span>

```C#
private void Button_Click(object sender, RoutedEventArgs e)
{

}
```

  <span data-ttu-id="5465d-240">これを変更して次のようにします。</span><span class="sxs-lookup"><span data-stu-id="5465d-240">Let's change it, so it looks like this:</span></span>

```C#
private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Hello, World!");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
```

<span data-ttu-id="5465d-241">**async** キーワードも含めるようにしてください。そうしないと、アプリを実行しようとしたときにエラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5465d-241">Make sure you include the **async** keyword as well, or you'll get an error when you try to run the app.</span></span>

### <a name="what-did-we-just-do"></a><span data-ttu-id="5465d-242">ここで実行したこと</span><span class="sxs-lookup"><span data-stu-id="5465d-242">What did we just do?</span></span>

<span data-ttu-id="5465d-243">このコードでは、いくつか Windows API を使用して音声合成オブジェクトを作成し、読み上げるテキストを指定します </span><span class="sxs-lookup"><span data-stu-id="5465d-243">This code uses some Windows APIs to create a speech synthesis object, and then gives it some text to say.</span></span> <span data-ttu-id="5465d-244">(SpeechSynthesis の使い方について詳しくは、[SpeechSynthesis 名前空間](https://msdn.microsoft.com/library/windows/apps/windows.media.speechsynthesis.aspx)のドキュメントをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="5465d-244">(For more information on using SpeechSynthesis, see the [SpeechSynthesis namespace](https://msdn.microsoft.com/library/windows/apps/windows.media.speechsynthesis.aspx) docs.)</span></span>

<span data-ttu-id="5465d-245">アプリを実行し、ボタンをクリックすると、コンピューター (または電話) が "Hello, World!" を文字どおりにしゃべります。</span><span class="sxs-lookup"><span data-stu-id="5465d-245">When you run the app and click on the button, your computer (or phone) will literally say "Hello, World!".</span></span>


## <a name="summary"></a><span data-ttu-id="5465d-246">まとめ</span><span class="sxs-lookup"><span data-stu-id="5465d-246">Summary</span></span>

<span data-ttu-id="5465d-247">これで、Windows 10 と UWP 用の初めてのアプリを作成しました。</span><span class="sxs-lookup"><span data-stu-id="5465d-247">Congratulations, you've created your first app for Windows 10 and the UWP!</span></span>

<span data-ttu-id="5465d-248">アプリで使うコントロールを XAML によってレイアウトする方法については、[グリッドに関するチュートリアル](../design/layout/grid-tutorial.md)で学習するか、直接[次のステップ](learn-more.md)に進んでください。</span><span class="sxs-lookup"><span data-stu-id="5465d-248">To learn how to use XAML for laying out the controls your app will use, try the [grid tutorial](../design/layout/grid-tutorial.md), or jump straight to [next steps](learn-more.md)?</span></span>

## <a name="see-also"></a><span data-ttu-id="5465d-249">関連項目</span><span class="sxs-lookup"><span data-stu-id="5465d-249">See Also</span></span>

* [<span data-ttu-id="5465d-250">初めてのアプリ</span><span class="sxs-lookup"><span data-stu-id="5465d-250">Your first app</span></span>](your-first-app.md)
* <span data-ttu-id="5465d-251">[UWP アプリを公開する](https://developer.microsoft.com/store/publish-apps)</span><span class="sxs-lookup"><span data-stu-id="5465d-251">[Publishing your UWP app](https://developer.microsoft.com/store/publish-apps).</span></span>
* [<span data-ttu-id="5465d-252">UWP アプリの開発に関するハウツー記事</span><span class="sxs-lookup"><span data-stu-id="5465d-252">How-to articles on developing UWP apps</span></span>](https://developer.microsoft.com/windows/apps/develop)
* [<span data-ttu-id="5465d-253">UWP 開発者向けコード サンプル</span><span class="sxs-lookup"><span data-stu-id="5465d-253">Code Samples for UWP developers</span></span>](https://developer.microsoft.com/windows/samples)
* [<span data-ttu-id="5465d-254">ユニバーサル Windows アプリとは?</span><span class="sxs-lookup"><span data-stu-id="5465d-254">What's a Universal Windows app?</span></span>](universal-application-platform-guide.md)
* [<span data-ttu-id="5465d-255">Windows アカウントのサインアップ</span><span class="sxs-lookup"><span data-stu-id="5465d-255">Sign up for Windows account</span></span>](sign-up.md)
