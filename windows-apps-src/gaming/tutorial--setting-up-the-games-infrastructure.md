---
author: joannaleecy
title: ゲーム プロジェクトのセットアップ
description: ゲームを作るための最初の手順は、必要なコード インフラストラクチャ作業の量を最小限に抑えるように Microsoft Visual Studio でプロジェクトを設定することです。
ms.assetid: 9fde90b3-bf79-bcb3-03b6-d38ab85803f2
ms.author: joanlee
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, セットアップ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 9100e80e0b4ac436ae872698e94fe29e5c8cab46
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7560832"
---
# <a name="set-up-the-game-project"></a><span data-ttu-id="0f0e6-104">ゲーム プロジェクトのセットアップ</span><span class="sxs-lookup"><span data-stu-id="0f0e6-104">Set up the game project</span></span>

<span data-ttu-id="0f0e6-105">このトピックでは、Visual Studio でテンプレートを使用してシンプルな UWP DirectX ゲームを設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-105">This topic goes through how to setup a simple UWP DirectX game using the templates in Visual Studio.</span></span> <span data-ttu-id="0f0e6-106">ゲームを作るための最初の手順は、必要なコード インフラストラクチャ作業の量を最小限に抑えるように Microsoft Visual Studio でプロジェクトを設定することです。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-106">The first step in assembling your game is to set up a project in Microsoft Visual Studio in such a way that you minimize the amount of code infrastructure work you need to do.</span></span> <span data-ttu-id="0f0e6-107">適切なテンプレートを使い、ゲーム開発用にプロジェクトを構成することで、設定にかかる時間を大幅に節約できることを説明します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-107">Learn to save set up time when you use the right template and configure the project specifically for game development.</span></span>

## <a name="objectives"></a><span data-ttu-id="0f0e6-108">目標</span><span class="sxs-lookup"><span data-stu-id="0f0e6-108">Objectives</span></span>

* <span data-ttu-id="0f0e6-109">Visual Studio でテンプレートを使用して Direct3D ゲーム プロジェクトを設定する</span><span class="sxs-lookup"><span data-stu-id="0f0e6-109">Set up a Direct3D game project in Visual Studio using a template</span></span>
* <span data-ttu-id="0f0e6-110">**App** ソース ファイル調べることによって、ゲームのメイン エントリ ポイントを理解する</span><span class="sxs-lookup"><span data-stu-id="0f0e6-110">Understand the game's main entry point by examining the **App** source files</span></span>
* <span data-ttu-id="0f0e6-111">プロジェクトの **package.appxmanifest** ファイルを確認する</span><span class="sxs-lookup"><span data-stu-id="0f0e6-111">Review the project's **package.appxmanifest** file</span></span>
* <span data-ttu-id="0f0e6-112">プロジェクトに含まれているゲーム開発ツールやサポートを調べる</span><span class="sxs-lookup"><span data-stu-id="0f0e6-112">Find out what game dev tools and support are included with the project</span></span>

## <a name="how-to-set-up-the-game-project"></a><span data-ttu-id="0f0e6-113">ゲーム プロジェクトを設定する方法</span><span class="sxs-lookup"><span data-stu-id="0f0e6-113">How to set up the game project</span></span>

<span data-ttu-id="0f0e6-114">初めてユニバーサル Windows プラットフォーム (UWP) 向けの開発を行う場合は、Visual Studio でテンプレートを使用して、基本的なコード構造を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-114">If you're new to Universal Windows Platform (UWP) development, we recommend the use of templates in Visual Studio to set up the basic code structure.</span></span>

>[!Note]
><span data-ttu-id="0f0e6-115">この記事は、ゲーム サンプルに基づく一連のチュートリアルの一部です。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-115">This article is part of a tutorial series based on a game sample.</span></span> <span data-ttu-id="0f0e6-116">最新のコードは、[Direct3D ゲーム サンプルに関するページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)で入手できます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-116">You can get the latest code at [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="0f0e6-117">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-117">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="0f0e6-118">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-118">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

### <a name="use-directx-template-to-create-a-project"></a><span data-ttu-id="0f0e6-119">DirectX テンプレートを使用してプロジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="0f0e6-119">Use DirectX template to create a project</span></span>

<span data-ttu-id="0f0e6-120">Visual Studio テンプレートは、優先する言語および技術に基づいて、特定の種類のアプリ向けの設定とコード ファイルを集めたものです。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-120">A Visual Studio template is a collection of settings and code files that target a specific type of app based on the preferred language and technology.</span></span> <span data-ttu-id="0f0e6-121">Microsoft Visual の Studio2017 では多くのゲームやグラフィックス アプリの開発が容易になることが大幅にテンプレートがわかります。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-121">In Microsoft Visual Studio2017, you'll find a number of templates that can dramatically ease game and graphics app development.</span></span> <span data-ttu-id="0f0e6-122">テンプレートを使わない場合、基本的なグラフィックス レンダリングや表示フレームワークの大部分を自分で開発しなければならず、これは新人のゲーム開発者にとっては骨の折れる仕事となります。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-122">If you don't use a template, you must develop much of the basic graphics rendering and display framework yourself, which can be a bit of a chore to a new game developer.</span></span>

<span data-ttu-id="0f0e6-123">このチュートリアルで使用するテンプレートは、**DirectX 11 アプリ (ユニバーサル Windows)** です。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-123">The template used for this tutorial is titled **DirectX 11 App (Universal Windows)**.</span></span> 

<span data-ttu-id="0f0e6-124">Visual Studio で DirectX 11 ゲーム プロジェクトを作成する手順を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-124">Steps to create a DirectX 11 game project in Visual Studio:</span></span>
1.  <span data-ttu-id="0f0e6-125">**[ファイル]** &gt; **[新規作成]**  &gt; **[プロジェクト]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-125">Select **File...** &gt; **New**  &gt; **Project...**</span></span>
2.  <span data-ttu-id="0f0e6-126">左側のウィンドウで、**[インストール済み]** &gt; **[テンプレート]** &gt; **[Visual C++]** &gt; **[Windows ユニバーサル]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-126">In the left pane, select **Installed** &gt; **Templates** &gt; **Visual C++** &gt; **Windows Universal**</span></span>
3.  <span data-ttu-id="0f0e6-127">中央のウィンドウで、**[DirectX 11 アプリ (ユニバーサル Windows)]** テンプレートを選びます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-127">In the center pane, select **DirectX 11 App (Universal Windows)**</span></span>
4.  <span data-ttu-id="0f0e6-128">ゲーム プロジェクトに名前を付けて、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-128">Give your game project a name, and click **OK**.</span></span>

![新しいゲーム プロジェクトを作成するための DirectX 11 テンプレートを選択する方法を示すスクリーン ショット](images/simple-dx-game-setup-new-project.png)

<span data-ttu-id="0f0e6-130">このテンプレートは、DirectX と C++ を使った UWP アプリの基本的なフレームワークを提供します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-130">This template provides you with the basic framework for a UWP app using DirectX with C++.</span></span> <span data-ttu-id="0f0e6-131">F5 キーを押して、アプリをビルドし、実行します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-131">Click F5 to build and run it.</span></span> <span data-ttu-id="0f0e6-132">パウダー ブルーの画面を確認します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-132">Check out that powder blue screen.</span></span> <span data-ttu-id="0f0e6-133">このテンプレートは、DirectX と C++ を使った UWP アプリの基本的な機能が含まれているコード ファイルを複数作成します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-133">The template creates multiple code files containing the basic functionality for a UWP app using DirectX with C++.</span></span>

## <a name="review-the-apps-main-entry-point-by-understanding-iframeworkview"></a><span data-ttu-id="0f0e6-134">IFrameworkView を理解することによりアプリのメイン エントリ ポイントを確認する</span><span class="sxs-lookup"><span data-stu-id="0f0e6-134">Review the app's main entry point by understanding IFrameworkView</span></span>

<span data-ttu-id="0f0e6-135">**App** クラスは **IFrameworkView** クラスを継承します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-135">The **App** class inherits from the **IFrameworkView** class.</span></span>

### <a name="inspect-apph"></a><span data-ttu-id="0f0e6-136">**App.h** を調べる</span><span class="sxs-lookup"><span data-stu-id="0f0e6-136">Inspect **App.h**.</span></span>

<span data-ttu-id="0f0e6-137">ビュー プロバイダーを定義する [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700469) インターフェイスを実装する際に使用される、**App.h** の 5 つのメソッド、[**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495)、[**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509)、[**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501)、[**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505)、[**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523) について簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-137">Let's quickly look at the 5 methods in **App.h** &mdash; [**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495), [**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509), [**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501), [**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505), and [**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523) when implementing the [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700469) interface that defines a view provider.</span></span> <span data-ttu-id="0f0e6-138">これらのメソッドはゲームの起動時に作成されるアプリ シングルトンによって実行され、適切なイベント ハンドラーに接続されて、アプリのすべてのリソースが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-138">These methods are run by the app singleton that is created when your game is launched, and load all your app's resources as well as connect the appropriate event handlers.</span></span>

```cpp
    // Main entry point for our app. Connects the app with the Windows shell and handle application lifecycle events.
    ref class App sealed : public Windows::ApplicationModel::Core::IFrameworkView
    {
    public:
        App();

        // IFrameworkView Methods.
        virtual void Initialize(Windows::ApplicationModel::Core::CoreApplicationView^ applicationView);
        virtual void SetWindow(Windows::UI::Core::CoreWindow^ window);
        virtual void Load(Platform::String^ entryPoint);
        virtual void Run();
        virtual void Uninitialize();

    protected:
        ...
    };
```

### <a name="inspect-appcpp"></a><span data-ttu-id="0f0e6-139">**App.cpp** を調べる</span><span class="sxs-lookup"><span data-stu-id="0f0e6-139">Inspect **App.cpp**</span></span>

<span data-ttu-id="0f0e6-140">**App.cpp** ソース ファイル内の **main** メソッドを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-140">Here's the **main** method in the **App.cpp** source file:</span></span>

```cpp
//The main function is only used to initialize our IFrameworkView class.
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto direct3DApplicationSource = ref new Direct3DApplicationSource();
    CoreApplication::Run(direct3DApplicationSource);
    return 0;
}
```

<span data-ttu-id="0f0e6-141">このメソッドでは、ビュー プロバイダー ファクトリから Direct3D ビュー プロバイダーのインスタンスが作成され (**App.h** で定義された **Direct3DApplicationSource**)、[**CoreApplication::Run**](https://msdn.microsoft.com/library/windows/apps/hh700469) を呼び出すことによってアプリ シングルトンに渡されます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-141">In this method, it creates an instance of the Direct3D view provider from the view provider factory (**Direct3DApplicationSource**, defined in **App.h**), and passes it to the app singleton by calling ([**CoreApplication::Run**](https://msdn.microsoft.com/library/windows/apps/hh700469)).</span></span> <span data-ttu-id="0f0e6-142">つまり、ゲームの出発点は、[**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドの実装の本文にあります (この場合は **App::Run**)。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-142">This means that the starting point for your game lives in the body of the implementation of the [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) method, and in this case, it's the **App::Run**.</span></span> 

<span data-ttu-id="0f0e6-143">**App.cpp** 内でスクロールして **App::Run** メソッドを見つけます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-143">Scroll to find the **App::Run** method in **App.cpp**.</span></span> <span data-ttu-id="0f0e6-144">コードは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-144">Here's the code:</span></span>

```cpp
//This method is called after the window becomes active.
void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_windowVisible)
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            m_main->Update();

            if (m_main->Render())
            {
                m_deviceResources->Present();
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
}
```

<span data-ttu-id="0f0e6-145">このメソッドでは、ゲームのウィンドウを閉じなければ、すべてのイベントがディスパッチされ、タイマーが更新され、グラフィックス パイプラインの結果がレンダリングされて表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-145">What this method does: If the window for your game isn't closed, it dispatches all events, updates the timer, then renders and presents the results of your graphics pipeline.</span></span> <span data-ttu-id="0f0e6-146">これについては、「[UWP アプリ フレームワークの定義](tutorial--building-the-games-uwp-app-framework.md)」、「[レンダリング フレームワーク I: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)」、「[レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-146">We'll talk about this in greater detail in [Define the UWP app framework](tutorial--building-the-games-uwp-app-framework.md), [Rendering framework I: Intro to rendering](tutorial--assembling-the-rendering-pipeline.md), and  [Rendering framework II: Game rendering](tutorial-game-rendering.md).</span></span> <span data-ttu-id="0f0e6-147">これで、UWP DirectX ゲームのコードの基本構造については理解できました。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-147">At this point, you should have a sense of the basic code structure of a UWP DirectX game.</span></span>

## <a name="review-and-update-the-packageappxmanifest-file"></a><span data-ttu-id="0f0e6-148">package.appxmanifest ファイルを確認して更新する</span><span class="sxs-lookup"><span data-stu-id="0f0e6-148">Review and update the package.appxmanifest file</span></span>


<span data-ttu-id="0f0e6-149">テンプレートに含まれるのはコード ファイルだけではありません。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-149">The code files aren't all there is to the template.</span></span> <span data-ttu-id="0f0e6-150">**Package.appxmanifest** ファイルには、ゲームのパッケージ化と起動や Microsoft Store への提出に使うプロジェクトのメタデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-150">The **Package.appxmanifest** file contains metadata about your project that are used for packaging and launching your game and for submission to the Microsoft Store.</span></span> <span data-ttu-id="0f0e6-151">プレイヤーのシステムがゲームの実行に必要なリソースへのアクセスを提供するための、重要な情報も含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-151">It also contains important info the player's system uses to provide access to the system resources the game needs to run.</span></span>

<span data-ttu-id="0f0e6-152">**ソリューション エクスプローラー**で **Package.appxmanifest** ファイルをダブルクリックして、**マニフェスト デザイナー**を起動します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-152">Launch the **manifest designer** by double-clicking the **Package.appxmanifest** file in **Solution Explorer**.</span></span>

![package.appxmanifest エディターのスクリーンショット。](images/simple-dx-game-setup-app-manifest.png)

<span data-ttu-id="0f0e6-154">**package.appxmanifest** ファイルとパッケージ化について詳しくは、[マニフェスト デザイナー](https://msdn.microsoft.com/library/windows/apps/br230259.aspx)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-154">For more info about the **package.appxmanifest** file and packaging, see [Manifest Designer](https://msdn.microsoft.com/library/windows/apps/br230259.aspx).</span></span> <span data-ttu-id="0f0e6-155">それでは、**[機能]** タブとそのオプションを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-155">For now, take a look at the **Capabilities** tab and look at the options provided.</span></span>

![Direct3D アプリの既定の機能のスクリーンショット。](images/simple-dx-game-setup-capabilities.png)

<span data-ttu-id="0f0e6-157">グローバルなハイ スコア ボードのための**インターネット**へのアクセスなど、ゲームで使う機能を選択しないと、該当するリソースや機能にアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-157">If you don't select the capabilities that your game uses, such as access to the **Internet** for global high score board, you won't be able to access the corresponding resources or features.</span></span> <span data-ttu-id="0f0e6-158">新しいゲームを作る場合、ゲームの実行に必要な機能を忘れずに選択してください。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-158">When you create a new game, make sure that you select the capabilities that your game needs to run!</span></span>

<span data-ttu-id="0f0e6-159">次に、**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートの残りのファイルを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-159">Now, let's look at the rest of the files that come with the **DirectX 11 App (Universal Windows)** template.</span></span>

## <a name="review-the-included-libraries-and-headers"></a><span data-ttu-id="0f0e6-160">含まれているライブラリとヘッダーを確認する</span><span class="sxs-lookup"><span data-stu-id="0f0e6-160">Review the included libraries and headers</span></span>

<span data-ttu-id="0f0e6-161">まだ確認していないファイルがいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-161">There are a few files we haven't looked at yet.</span></span> <span data-ttu-id="0f0e6-162">それは、Direct3D ゲーム開発シナリオに共通するその他のツールとサポートを提供するファイルです。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-162">These files provide additional tools and support common to Direct3D game development scenarios.</span></span> <span data-ttu-id="0f0e6-163">基本的な DirectX ゲーム プロジェクトに付属しているすべてのファイルの一覧については、「[DirectX ゲーム プロジェクト テンプレート](user-interface.md#template-structure)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-163">For the full list of files that comes with the basic DirectX game project, see [DirectX game project templates](user-interface.md#template-structure).</span></span>

| <span data-ttu-id="0f0e6-164">テンプレート ソース ファイル</span><span class="sxs-lookup"><span data-stu-id="0f0e6-164">Template Source File</span></span>         | <span data-ttu-id="0f0e6-165">ファイル フォルダー</span><span class="sxs-lookup"><span data-stu-id="0f0e6-165">File folder</span></span>            | <span data-ttu-id="0f0e6-166">説明</span><span class="sxs-lookup"><span data-stu-id="0f0e6-166">Description</span></span> |
|------------------------------|------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="0f0e6-167">DeviceResources.h/.cpp</span><span class="sxs-lookup"><span data-stu-id="0f0e6-167">DeviceResources.h/.cpp</span></span>       | <span data-ttu-id="0f0e6-168">Common</span><span class="sxs-lookup"><span data-stu-id="0f0e6-168">Common</span></span>                 | <span data-ttu-id="0f0e6-169">すべての DirectX [デバイス リソース](tutorial--assembling-the-rendering-pipeline.md#resource)を制御するクラス オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-169">Defines a class object that controls all DirectX [device resources](tutorial--assembling-the-rendering-pipeline.md#resource).</span></span> <span data-ttu-id="0f0e6-170">デバイスが消失または作成されたときに通知される DeviceResources を所有しているアプリケーションのインターフェイスも含まれています。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-170">It also includes an interface for your application that owns DeviceResources to be notified  when the device is lost or created.</span></span>                                                |
| <span data-ttu-id="0f0e6-171">DirectXHelper.h</span><span class="sxs-lookup"><span data-stu-id="0f0e6-171">DirectXHelper.h</span></span>              | <span data-ttu-id="0f0e6-172">Common</span><span class="sxs-lookup"><span data-stu-id="0f0e6-172">Common</span></span>                 | <span data-ttu-id="0f0e6-173">**DX::ThrowIfFailed**、**ReadDataAsync**、\*\*ConvertDipsToPixels などのメソッドを実装します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-173">Implements methods including **DX::ThrowIfFailed**, **ReadDataAsync**, and \*\*ConvertDipsToPixels.</span></span> <span data-ttu-id="0f0e6-174">**DX::ThrowIfFailed** は、DirectX Win32 API によって返されたエラー HRESULT 値を Windows ランタイム例外に変換します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-174">**DX::ThrowIfFailed** converts the error HRESULT values returned by DirectX Win32 APIs into Windows Runtime exceptions.</span></span> <span data-ttu-id="0f0e6-175">このメソッドを使って、DirectX エラーをデバッグするためのブレーク ポイントを配置します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-175">Use this method to put a break point for debugging DirectX errors.</span></span> <span data-ttu-id="0f0e6-176">詳しくは、[ThrowIfFailed](https://github.com/Microsoft/DirectXTK/wiki/ThrowIfFailed) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-176">For more information, see [ThrowIfFailed](https://github.com/Microsoft/DirectXTK/wiki/ThrowIfFailed).</span></span> <span data-ttu-id="0f0e6-177">**ReadDataAsync** は、バイナリ ファイルから非同期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-177">**ReadDataAsync** reads from a binary file asynchronously.</span></span> <span data-ttu-id="0f0e6-178">**ConvertDipsToPixels** は、デバイスに依存しないピクセル (DIP) 単位の長さを物理ピクセル単位の長さに変換します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-178">**ConvertDipsToPixels** converts a length in device-independent pixels (DIPs) to a length in physical pixels.</span></span> |
| <span data-ttu-id="0f0e6-179">StepTimer.h</span><span class="sxs-lookup"><span data-stu-id="0f0e6-179">StepTimer.h</span></span>                  | <span data-ttu-id="0f0e6-180">Common</span><span class="sxs-lookup"><span data-stu-id="0f0e6-180">Common</span></span>                 | <span data-ttu-id="0f0e6-181">ゲーム アプリまたは対話型レンダリング アプリで役に立つ、高分解能タイマーを定義します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-181">Defines a high-resolution timer useful for gaming or interactive rendering apps.</span></span>   |
| <span data-ttu-id="0f0e6-182">Sample3DSceneRenderer.h/.cpp</span><span class="sxs-lookup"><span data-stu-id="0f0e6-182">Sample3DSceneRenderer.h/.cpp</span></span> | <span data-ttu-id="0f0e6-183">Content</span><span class="sxs-lookup"><span data-stu-id="0f0e6-183">Content</span></span>                | <span data-ttu-id="0f0e6-184">基本的なレンダリング パイプラインのインスタンスを作成するクラス オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-184">Defines a class object to instantiate a basic rendering pipeline.</span></span> <span data-ttu-id="0f0e6-185">DirectX を使った UWP に Direct3D スワップ チェーンとグラフィックス アダプターを接続する基本的なレンダラー実装を作成します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-185">It creates a basic renderer implementation that connects a Direct3D swap chain and graphics adapter to your UWP using DirectX.</span></span>   |
| <span data-ttu-id="0f0e6-186">SampleFPSTextRenderer.h/.cpp</span><span class="sxs-lookup"><span data-stu-id="0f0e6-186">SampleFPSTextRenderer.h/.cpp</span></span> | <span data-ttu-id="0f0e6-187">Content</span><span class="sxs-lookup"><span data-stu-id="0f0e6-187">Content</span></span>                | <span data-ttu-id="0f0e6-188">Direct2D と DirectWrite を使って画面の右下隅に現在の FPS (1 秒あたりのフレーム数) 値をレンダリングするクラス オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-188">Defines a class object to render the current frames per second (FPS) value in the bottom right corner of the screen using Direct2D and DirectWrite.</span></span>  |
| <span data-ttu-id="0f0e6-189">SamplePixelShader.hlsl</span><span class="sxs-lookup"><span data-stu-id="0f0e6-189">SamplePixelShader.hlsl</span></span>       | <span data-ttu-id="0f0e6-190">Content</span><span class="sxs-lookup"><span data-stu-id="0f0e6-190">Content</span></span>                | <span data-ttu-id="0f0e6-191">非常に基本的なピクセル シェーダー用の上位レベル シェーダー言語 (HLSL) コードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-191">Contains the high-level shader language (HLSL) code for a very basic pixel shader.</span></span>                                            |
| <span data-ttu-id="0f0e6-192">SampleVertexShader.hlsl</span><span class="sxs-lookup"><span data-stu-id="0f0e6-192">SampleVertexShader.hlsl</span></span>      | <span data-ttu-id="0f0e6-193">Content</span><span class="sxs-lookup"><span data-stu-id="0f0e6-193">Content</span></span>                | <span data-ttu-id="0f0e6-194">非常に基本的な頂点シェーダー用の上位レベル シェーダー言語 (HLSL) コードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-194">Contains the high-level shader language (HLSL) code for a very basic vertex shader.</span></span>                                           |
| <span data-ttu-id="0f0e6-195">ShaderStructures.h</span><span class="sxs-lookup"><span data-stu-id="0f0e6-195">ShaderStructures.h</span></span>           | <span data-ttu-id="0f0e6-196">Content</span><span class="sxs-lookup"><span data-stu-id="0f0e6-196">Content</span></span>                | <span data-ttu-id="0f0e6-197">MVP 行列と頂点単位のデータを頂点シェーダーに送信するために使用できるシェーダー構造体が含まれています。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-197">Contains shader structures that can be used to send MVP matrices and per-vertex data to the vertex shader.</span></span>  |
| <span data-ttu-id="0f0e6-198">pch.h/.cpp</span><span class="sxs-lookup"><span data-stu-id="0f0e6-198">pch.h/.cpp</span></span>                   | <span data-ttu-id="0f0e6-199">Main</span><span class="sxs-lookup"><span data-stu-id="0f0e6-199">Main</span></span>                   | <span data-ttu-id="0f0e6-200">DirectX 11 API など、Direct3D アプリで使われる API 用のすべての Windows システム インクルードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-200">Contains all the Windows system includes for the APIs used by a Direct3D app, including the DirectX 11 APIs.</span></span>| 

### <a name="next-steps"></a><span data-ttu-id="0f0e6-201">次の手順</span><span class="sxs-lookup"><span data-stu-id="0f0e6-201">Next steps</span></span>

<span data-ttu-id="0f0e6-202">これで、**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートを使用して UWP DirectX ゲーム プロジェクトを作成する方法と、このプロジェクトで提供されるいくつかのコンポーネントとファイルについての説明が終わりました。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-202">At this point, you've learnt how to create a UWP DirectX game project using the **DirectX 11 App (Universal Windows)** template and have been introduced to a few components and files provided by this project.</span></span>

<span data-ttu-id="0f0e6-203">次のセクションは、「[ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義](tutorial--building-the-games-uwp-app-framework.md)」です。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-203">The next section is [Defining the game's UWP framework](tutorial--building-the-games-uwp-app-framework.md).</span></span> <span data-ttu-id="0f0e6-204">テンプレートで提供される概念やコンポーネントの多くを、このゲームでどのように使用し、拡張しているかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="0f0e6-204">We'll examine how this game uses and extends many of the concepts and components that the template provides.</span></span>

 

 




