---
title: ゲーム プロジェクトのセットアップ
description: ゲームを作るための最初の手順は、必要なコード インフラストラクチャ作業の量を最小限に抑えるように Microsoft Visual Studio でプロジェクトを設定することです。
ms.assetid: 9fde90b3-bf79-bcb3-03b6-d38ab85803f2
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, セットアップ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 789b235220e5d22b85f7b3038d5d468729439501
ms.sourcegitcommit: 7a3d28472901edbe4ecdde7e1a01a505ee5bc028
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/29/2019
ms.locfileid: "58658768"
---
# <a name="set-up-the-game-project"></a><span data-ttu-id="4a3b7-104">ゲーム プロジェクトのセットアップ</span><span class="sxs-lookup"><span data-stu-id="4a3b7-104">Set up the game project</span></span>

<span data-ttu-id="4a3b7-105">このトピックでは、Visual Studio でテンプレートを使用してシンプルな UWP DirectX ゲームを設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-105">This topic goes through how to setup a simple UWP DirectX game using the templates in Visual Studio.</span></span> <span data-ttu-id="4a3b7-106">ゲームを作るための最初の手順は、必要なコード インフラストラクチャ作業の量を最小限に抑えるように Microsoft Visual Studio でプロジェクトを設定することです。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-106">The first step in assembling your game is to set up a project in Microsoft Visual Studio in such a way that you minimize the amount of code infrastructure work you need to do.</span></span> <span data-ttu-id="4a3b7-107">適切なテンプレートを使い、ゲーム開発用にプロジェクトを構成することで、設定にかかる時間を大幅に節約できることを説明します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-107">Learn to save set up time when you use the right template and configure the project specifically for game development.</span></span>

## <a name="objectives"></a><span data-ttu-id="4a3b7-108">目標</span><span class="sxs-lookup"><span data-stu-id="4a3b7-108">Objectives</span></span>

* <span data-ttu-id="4a3b7-109">Visual Studio でテンプレートを使用して Direct3D ゲーム プロジェクトを設定する</span><span class="sxs-lookup"><span data-stu-id="4a3b7-109">Set up a Direct3D game project in Visual Studio using a template</span></span>
* <span data-ttu-id="4a3b7-110">**App** ソース ファイル調べることによって、ゲームのメイン エントリ ポイントを理解する</span><span class="sxs-lookup"><span data-stu-id="4a3b7-110">Understand the game's main entry point by examining the **App** source files</span></span>
* <span data-ttu-id="4a3b7-111">プロジェクトの **package.appxmanifest** ファイルを確認する</span><span class="sxs-lookup"><span data-stu-id="4a3b7-111">Review the project's **package.appxmanifest** file</span></span>
* <span data-ttu-id="4a3b7-112">プロジェクトに含まれているゲーム開発ツールやサポートを調べる</span><span class="sxs-lookup"><span data-stu-id="4a3b7-112">Find out what game dev tools and support are included with the project</span></span>

## <a name="how-to-set-up-the-game-project"></a><span data-ttu-id="4a3b7-113">ゲーム プロジェクトを設定する方法</span><span class="sxs-lookup"><span data-stu-id="4a3b7-113">How to set up the game project</span></span>

<span data-ttu-id="4a3b7-114">初めてユニバーサル Windows プラットフォーム (UWP) 向けの開発を行う場合は、Visual Studio でテンプレートを使用して、基本的なコード構造を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-114">If you're new to Universal Windows Platform (UWP) development, we recommend the use of templates in Visual Studio to set up the basic code structure.</span></span>

>[!Note]
><span data-ttu-id="4a3b7-115">この記事は、ゲーム サンプルに基づく一連のチュートリアルの一部です。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-115">This article is part of a tutorial series based on a game sample.</span></span> <span data-ttu-id="4a3b7-116">最新のコードは、[Direct3D ゲーム サンプルに関するページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)で入手できます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-116">You can get the latest code at [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="4a3b7-117">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-117">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="4a3b7-118">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-118">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

### <a name="use-directx-template-to-create-a-project"></a><span data-ttu-id="4a3b7-119">DirectX テンプレートを使用してプロジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="4a3b7-119">Use DirectX template to create a project</span></span>

<span data-ttu-id="4a3b7-120">Visual Studio テンプレートは、優先する言語および技術に基づいて、特定の種類のアプリ向けの設定とコード ファイルを集めたものです。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-120">A Visual Studio template is a collection of settings and code files that target a specific type of app based on the preferred language and technology.</span></span> <span data-ttu-id="4a3b7-121">Microsoft Visual Studio 2017 では、多数のゲームおよびグラフィックスのアプリ開発が大幅に軽減できるテンプレートがあります。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-121">In Microsoft Visual Studio 2017, you'll find a number of templates that can dramatically ease game and graphics app development.</span></span> <span data-ttu-id="4a3b7-122">テンプレートを使わない場合、基本的なグラフィックス レンダリングや表示フレームワークの大部分を自分で開発しなければならず、これは新人のゲーム開発者にとっては骨の折れる仕事となります。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-122">If you don't use a template, you must develop much of the basic graphics rendering and display framework yourself, which can be a bit of a chore to a new game developer.</span></span>

<span data-ttu-id="4a3b7-123">このチュートリアルで使用するテンプレートは、**DirectX 11 アプリ (ユニバーサル Windows)** です。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-123">The template used for this tutorial is titled **DirectX 11 App (Universal Windows)**.</span></span> 

<span data-ttu-id="4a3b7-124">Visual Studio で DirectX 11 ゲーム プロジェクトを作成する手順を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-124">Steps to create a DirectX 11 game project in Visual Studio:</span></span>
1.  <span data-ttu-id="4a3b7-125">選択**ファイル.**&gt; **新しい**&gt; **プロジェクト.**</span><span class="sxs-lookup"><span data-stu-id="4a3b7-125">Select **File...** &gt; **New**  &gt; **Project...**</span></span>
2.  <span data-ttu-id="4a3b7-126">左側のウィンドウで次のように選択します**インストール済み** &gt; **テンプレート** &gt; **Visual c** &gt; **Windows ユニバーサル。**</span><span class="sxs-lookup"><span data-stu-id="4a3b7-126">In the left pane, select **Installed** &gt; **Templates** &gt; **Visual C++** &gt; **Windows Universal**</span></span>
3.  <span data-ttu-id="4a3b7-127">中央のウィンドウで、**[DirectX 11 アプリ (ユニバーサル Windows)]** テンプレートを選びます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-127">In the center pane, select **DirectX 11 App (Universal Windows)**</span></span>
4.  <span data-ttu-id="4a3b7-128">ゲーム プロジェクトに名前を付けて、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-128">Give your game project a name, and click **OK**.</span></span>

![新しいゲーム プロジェクトを作成するための DirectX 11 テンプレートを選択する方法を示すスクリーン ショット](images/simple-dx-game-setup-new-project.png)

<span data-ttu-id="4a3b7-130">このテンプレートは、DirectX と C++ を使った UWP アプリの基本的なフレームワークを提供します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-130">This template provides you with the basic framework for a UWP app using DirectX with C++.</span></span> <span data-ttu-id="4a3b7-131">F5 キーを押して、アプリをビルドし、実行します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-131">Click F5 to build and run it.</span></span> <span data-ttu-id="4a3b7-132">パウダー ブルーの画面を確認します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-132">Check out that powder blue screen.</span></span> <span data-ttu-id="4a3b7-133">このテンプレートは、DirectX と C++ を使った UWP アプリの基本的な機能が含まれているコード ファイルを複数作成します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-133">The template creates multiple code files containing the basic functionality for a UWP app using DirectX with C++.</span></span>

## <a name="review-the-apps-main-entry-point-by-understanding-iframeworkview"></a><span data-ttu-id="4a3b7-134">IFrameworkView を理解することによりアプリのメイン エントリ ポイントを確認する</span><span class="sxs-lookup"><span data-stu-id="4a3b7-134">Review the app's main entry point by understanding IFrameworkView</span></span>

<span data-ttu-id="4a3b7-135">**App** クラスは **IFrameworkView** クラスを継承します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-135">The **App** class inherits from the **IFrameworkView** class.</span></span>

### <a name="inspect-apph"></a><span data-ttu-id="4a3b7-136">**App.h** を調べる</span><span class="sxs-lookup"><span data-stu-id="4a3b7-136">Inspect **App.h**.</span></span>

<span data-ttu-id="4a3b7-137">短時間で 5 つの方法を見てみましょう**App.h** &mdash; [**初期化**](https://msdn.microsoft.com/library/windows/apps/hh700495)、 [ **SetWindow** ](https://msdn.microsoft.com/library/windows/apps/hh700509)、 [**ロード**](https://msdn.microsoft.com/library/windows/apps/hh700501)、 [**実行**](https://msdn.microsoft.com/library/windows/apps/hh700505)、および[**初期化**](https://msdn.microsoft.com/library/windows/apps/hh700523)を実装する場合、 [ **IFrameworkView** ](https://msdn.microsoft.com/library/windows/apps/hh700469)ビュー プロバイダーを定義するインターフェイス。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-137">Let's quickly look at the 5 methods in **App.h** &mdash; [**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495), [**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509), [**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501), [**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505), and [**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523) when implementing the [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700469) interface that defines a view provider.</span></span> <span data-ttu-id="4a3b7-138">これらのメソッドはゲームの起動時に作成されるアプリ シングルトンによって実行され、適切なイベント ハンドラーに接続されて、アプリのすべてのリソースが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-138">These methods are run by the app singleton that is created when your game is launched, and load all your app's resources as well as connect the appropriate event handlers.</span></span>

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

### <a name="inspect-appcpp"></a><span data-ttu-id="4a3b7-139">**App.cpp** を調べる</span><span class="sxs-lookup"><span data-stu-id="4a3b7-139">Inspect **App.cpp**</span></span>

<span data-ttu-id="4a3b7-140">**App.cpp** ソース ファイル内の **main** メソッドを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-140">Here's the **main** method in the **App.cpp** source file:</span></span>

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

<span data-ttu-id="4a3b7-141">このメソッドは、ビューのプロバイダー ファクトリから Direct3D ビュー プロバイダーのインスタンスを作成します (**Direct3DApplicationSource**で定義された`App.h`) を呼び出すことによってアプリ シングルトンに渡す[ **CoreApplication::Run**](/uwp/api/windows.applicationmodel.core.coreapplication.run)します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-141">This method creates an instance of the Direct3D view provider from the view provider factory (**Direct3DApplicationSource**, defined in `App.h`), and passes it to the app singleton by calling [**CoreApplication::Run**](/uwp/api/windows.applicationmodel.core.coreapplication.run).</span></span> <span data-ttu-id="4a3b7-142">フレームワークのビューのメソッド (これは、**アプリ**この例ではクラス) の順序で呼び出されます**初期化**-**SetWindow** -**ロード**-**OnActivated**-**実行**-**初期化**します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-142">The methods of your framework view (which is the **App** class in this example) are called in the order **Initialize**-**SetWindow**-**Load**-**OnActivated**-**Run**-**Uninitialize**.</span></span> <span data-ttu-id="4a3b7-143">呼び出す**CoreApplication::Run**がその lifycycle 開始されます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-143">Calling **CoreApplication::Run** kicks off that lifycycle.</span></span> <span data-ttu-id="4a3b7-144">実装の本体で、ゲームのメイン ループが存在する、 [ **IFrameworkView::Run**メソッド](/uwp/api/windows.applicationmodel.core.iframeworkview.run)、し、この例では、 **App::Run**します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-144">The main loop of your game resides in the body of the implementation of the [**IFrameworkView::Run** method](/uwp/api/windows.applicationmodel.core.iframeworkview.run), and in this case, it's the **App::Run**.</span></span>

<span data-ttu-id="4a3b7-145">**App.cpp** 内でスクロールして **App::Run** メソッドを見つけます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-145">Scroll to find the **App::Run** method in **App.cpp**.</span></span> <span data-ttu-id="4a3b7-146">コードは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-146">Here's the code.</span></span>

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

<span data-ttu-id="4a3b7-147">このメソッドの特長。ゲームは、ウィンドウが閉じていない場合、すべてのイベントをディスパッチ、タイマーを更新、をレンダリングおよびグラフィックス パイプラインの結果を提供します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-147">What this method does: If the window for your game isn't closed, it dispatches all events, updates the timer, then renders and presents the results of your graphics pipeline.</span></span> <span data-ttu-id="4a3b7-148">については、これでさらに詳しく話します[UWP アプリのフレームワークを定義](tutorial--building-the-games-uwp-app-framework.md)、[レンダリング framework i:レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)、および[レンダリング framework II:ゲームのレンダリング](tutorial-game-rendering.md)します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-148">We'll talk about this in greater detail in [Define the UWP app framework](tutorial--building-the-games-uwp-app-framework.md), [Rendering framework I: Intro to rendering](tutorial--assembling-the-rendering-pipeline.md), and  [Rendering framework II: Game rendering](tutorial-game-rendering.md).</span></span> <span data-ttu-id="4a3b7-149">これで、UWP DirectX ゲームのコードの基本構造については理解できました。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-149">At this point, you should have a sense of the basic code structure of a UWP DirectX game.</span></span>

## <a name="review-and-update-the-packageappxmanifest-file"></a><span data-ttu-id="4a3b7-150">package.appxmanifest ファイルを確認して更新する</span><span class="sxs-lookup"><span data-stu-id="4a3b7-150">Review and update the package.appxmanifest file</span></span>


<span data-ttu-id="4a3b7-151">テンプレートに含まれるのはコード ファイルだけではありません。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-151">The code files aren't all there is to the template.</span></span> <span data-ttu-id="4a3b7-152">**Package.appxmanifest** ファイルには、ゲームのパッケージ化と起動や Microsoft Store への提出に使うプロジェクトのメタデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-152">The **Package.appxmanifest** file contains metadata about your project that are used for packaging and launching your game and for submission to the Microsoft Store.</span></span> <span data-ttu-id="4a3b7-153">プレイヤーのシステムがゲームの実行に必要なリソースへのアクセスを提供するための、重要な情報も含まれます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-153">It also contains important info the player's system uses to provide access to the system resources the game needs to run.</span></span>

<span data-ttu-id="4a3b7-154">**ソリューション エクスプローラー**で **Package.appxmanifest** ファイルをダブルクリックして、**マニフェスト デザイナー**を起動します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-154">Launch the **manifest designer** by double-clicking the **Package.appxmanifest** file in **Solution Explorer**.</span></span>

![package.appxmanifest エディターのスクリーンショット。](images/simple-dx-game-setup-app-manifest.png)

<span data-ttu-id="4a3b7-156">**package.appxmanifest** ファイルとパッケージ化について詳しくは、[マニフェスト デザイナー](https://msdn.microsoft.com/library/windows/apps/br230259.aspx)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-156">For more info about the **package.appxmanifest** file and packaging, see [Manifest Designer](https://msdn.microsoft.com/library/windows/apps/br230259.aspx).</span></span> <span data-ttu-id="4a3b7-157">それでは、**[機能]** タブとそのオプションを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-157">For now, take a look at the **Capabilities** tab and look at the options provided.</span></span>

![Direct3D アプリの既定の機能のスクリーンショット。](images/simple-dx-game-setup-capabilities.png)

<span data-ttu-id="4a3b7-159">グローバルなハイ スコア ボードのための**インターネット**へのアクセスなど、ゲームで使う機能を選択しないと、該当するリソースや機能にアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-159">If you don't select the capabilities that your game uses, such as access to the **Internet** for global high score board, you won't be able to access the corresponding resources or features.</span></span> <span data-ttu-id="4a3b7-160">新しいゲームを作る場合、ゲームの実行に必要な機能を忘れずに選択してください。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-160">When you create a new game, make sure that you select the capabilities that your game needs to run!</span></span>

<span data-ttu-id="4a3b7-161">次に、**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートの残りのファイルを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-161">Now, let's look at the rest of the files that come with the **DirectX 11 App (Universal Windows)** template.</span></span>

## <a name="review-the-included-libraries-and-headers"></a><span data-ttu-id="4a3b7-162">含まれているライブラリとヘッダーを確認する</span><span class="sxs-lookup"><span data-stu-id="4a3b7-162">Review the included libraries and headers</span></span>

<span data-ttu-id="4a3b7-163">まだ確認していないファイルがいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-163">There are a few files we haven't looked at yet.</span></span> <span data-ttu-id="4a3b7-164">それは、Direct3D ゲーム開発シナリオに共通するその他のツールとサポートを提供するファイルです。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-164">These files provide additional tools and support common to Direct3D game development scenarios.</span></span> <span data-ttu-id="4a3b7-165">基本的な DirectX ゲーム プロジェクトに付属しているすべてのファイルの一覧については、「[DirectX ゲーム プロジェクト テンプレート](user-interface.md#template-structure)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-165">For the full list of files that comes with the basic DirectX game project, see [DirectX game project templates](user-interface.md#template-structure).</span></span>

| <span data-ttu-id="4a3b7-166">テンプレート ソース ファイル</span><span class="sxs-lookup"><span data-stu-id="4a3b7-166">Template Source File</span></span>         | <span data-ttu-id="4a3b7-167">ファイル フォルダー</span><span class="sxs-lookup"><span data-stu-id="4a3b7-167">File folder</span></span>            | <span data-ttu-id="4a3b7-168">説明</span><span class="sxs-lookup"><span data-stu-id="4a3b7-168">Description</span></span> |
|------------------------------|------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="4a3b7-169">DeviceResources.h/.cpp</span><span class="sxs-lookup"><span data-stu-id="4a3b7-169">DeviceResources.h/.cpp</span></span>       | <span data-ttu-id="4a3b7-170">共通</span><span class="sxs-lookup"><span data-stu-id="4a3b7-170">Common</span></span>                 | <span data-ttu-id="4a3b7-171">すべての DirectX [デバイス リソース](tutorial--assembling-the-rendering-pipeline.md#resource)を制御するクラス オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-171">Defines a class object that controls all DirectX [device resources](tutorial--assembling-the-rendering-pipeline.md#resource).</span></span> <span data-ttu-id="4a3b7-172">デバイスが消失または作成されたときに通知される DeviceResources を所有しているアプリケーションのインターフェイスも含まれています。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-172">It also includes an interface for your application that owns DeviceResources to be notified  when the device is lost or created.</span></span>                                                |
| <span data-ttu-id="4a3b7-173">DirectXHelper.h</span><span class="sxs-lookup"><span data-stu-id="4a3b7-173">DirectXHelper.h</span></span>              | <span data-ttu-id="4a3b7-174">共通</span><span class="sxs-lookup"><span data-stu-id="4a3b7-174">Common</span></span>                 | <span data-ttu-id="4a3b7-175">**DX::ThrowIfFailed**、**ReadDataAsync**、\*\*ConvertDipsToPixels などのメソッドを実装します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-175">Implements methods including **DX::ThrowIfFailed**, **ReadDataAsync**, and \*\*ConvertDipsToPixels.</span></span> <span data-ttu-id="4a3b7-176">**DX::ThrowIfFailed** は、DirectX Win32 API によって返されたエラー HRESULT 値を Windows ランタイム例外に変換します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-176">**DX::ThrowIfFailed** converts the error HRESULT values returned by DirectX Win32 APIs into Windows Runtime exceptions.</span></span> <span data-ttu-id="4a3b7-177">このメソッドを使って、DirectX エラーをデバッグするためのブレーク ポイントを配置します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-177">Use this method to put a break point for debugging DirectX errors.</span></span> <span data-ttu-id="4a3b7-178">詳しくは、[ThrowIfFailed](https://github.com/Microsoft/DirectXTK/wiki/ThrowIfFailed) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-178">For more information, see [ThrowIfFailed](https://github.com/Microsoft/DirectXTK/wiki/ThrowIfFailed).</span></span> <span data-ttu-id="4a3b7-179">**ReadDataAsync** は、バイナリ ファイルから非同期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-179">**ReadDataAsync** reads from a binary file asynchronously.</span></span> <span data-ttu-id="4a3b7-180">**ConvertDipsToPixels** は、デバイスに依存しないピクセル (DIP) 単位の長さを物理ピクセル単位の長さに変換します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-180">**ConvertDipsToPixels** converts a length in device-independent pixels (DIPs) to a length in physical pixels.</span></span> |
| <span data-ttu-id="4a3b7-181">StepTimer.h</span><span class="sxs-lookup"><span data-stu-id="4a3b7-181">StepTimer.h</span></span>                  | <span data-ttu-id="4a3b7-182">共通</span><span class="sxs-lookup"><span data-stu-id="4a3b7-182">Common</span></span>                 | <span data-ttu-id="4a3b7-183">ゲーム アプリまたは対話型レンダリング アプリで役に立つ、高分解能タイマーを定義します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-183">Defines a high-resolution timer useful for gaming or interactive rendering apps.</span></span>   |
| <span data-ttu-id="4a3b7-184">Sample3DSceneRenderer.h/.cpp</span><span class="sxs-lookup"><span data-stu-id="4a3b7-184">Sample3DSceneRenderer.h/.cpp</span></span> | <span data-ttu-id="4a3b7-185">Content</span><span class="sxs-lookup"><span data-stu-id="4a3b7-185">Content</span></span>                | <span data-ttu-id="4a3b7-186">基本的なレンダリング パイプラインのインスタンスを作成するクラス オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-186">Defines a class object to instantiate a basic rendering pipeline.</span></span> <span data-ttu-id="4a3b7-187">DirectX を使った UWP に Direct3D スワップ チェーンとグラフィックス アダプターを接続する基本的なレンダラー実装を作成します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-187">It creates a basic renderer implementation that connects a Direct3D swap chain and graphics adapter to your UWP using DirectX.</span></span>   |
| <span data-ttu-id="4a3b7-188">SampleFPSTextRenderer.h/.cpp</span><span class="sxs-lookup"><span data-stu-id="4a3b7-188">SampleFPSTextRenderer.h/.cpp</span></span> | <span data-ttu-id="4a3b7-189">Content</span><span class="sxs-lookup"><span data-stu-id="4a3b7-189">Content</span></span>                | <span data-ttu-id="4a3b7-190">Direct2D と DirectWrite を使って画面の右下隅に現在の FPS (1 秒あたりのフレーム数) 値をレンダリングするクラス オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-190">Defines a class object to render the current frames per second (FPS) value in the bottom right corner of the screen using Direct2D and DirectWrite.</span></span>  |
| <span data-ttu-id="4a3b7-191">SamplePixelShader.hlsl</span><span class="sxs-lookup"><span data-stu-id="4a3b7-191">SamplePixelShader.hlsl</span></span>       | <span data-ttu-id="4a3b7-192">Content</span><span class="sxs-lookup"><span data-stu-id="4a3b7-192">Content</span></span>                | <span data-ttu-id="4a3b7-193">非常に基本的なピクセル シェーダー用の上位レベル シェーダー言語 (HLSL) コードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-193">Contains the high-level shader language (HLSL) code for a very basic pixel shader.</span></span>                                            |
| <span data-ttu-id="4a3b7-194">SampleVertexShader.hlsl</span><span class="sxs-lookup"><span data-stu-id="4a3b7-194">SampleVertexShader.hlsl</span></span>      | <span data-ttu-id="4a3b7-195">Content</span><span class="sxs-lookup"><span data-stu-id="4a3b7-195">Content</span></span>                | <span data-ttu-id="4a3b7-196">非常に基本的な頂点シェーダー用の上位レベル シェーダー言語 (HLSL) コードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-196">Contains the high-level shader language (HLSL) code for a very basic vertex shader.</span></span>                                           |
| <span data-ttu-id="4a3b7-197">ShaderStructures.h</span><span class="sxs-lookup"><span data-stu-id="4a3b7-197">ShaderStructures.h</span></span>           | <span data-ttu-id="4a3b7-198">Content</span><span class="sxs-lookup"><span data-stu-id="4a3b7-198">Content</span></span>                | <span data-ttu-id="4a3b7-199">MVP 行列と頂点単位のデータを頂点シェーダーに送信するために使用できるシェーダー構造体が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-199">Contains shader structures that can be used to send MVP matrices and per-vertex data to the vertex shader.</span></span>  |
| <span data-ttu-id="4a3b7-200">pch.h/.cpp</span><span class="sxs-lookup"><span data-stu-id="4a3b7-200">pch.h/.cpp</span></span>                   | <span data-ttu-id="4a3b7-201">メイン</span><span class="sxs-lookup"><span data-stu-id="4a3b7-201">Main</span></span>                   | <span data-ttu-id="4a3b7-202">DirectX 11 API など、Direct3D アプリで使われる API 用のすべての Windows システム インクルードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-202">Contains all the Windows system includes for the APIs used by a Direct3D app, including the DirectX 11 APIs.</span></span>| 

### <a name="next-steps"></a><span data-ttu-id="4a3b7-203">次のステップ</span><span class="sxs-lookup"><span data-stu-id="4a3b7-203">Next steps</span></span>

<span data-ttu-id="4a3b7-204">これで、**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートを使用して UWP DirectX ゲーム プロジェクトを作成する方法と、このプロジェクトで提供されるいくつかのコンポーネントとファイルについての説明が終わりました。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-204">At this point, you've learnt how to create a UWP DirectX game project using the **DirectX 11 App (Universal Windows)** template and have been introduced to a few components and files provided by this project.</span></span>

<span data-ttu-id="4a3b7-205">次のセクションは、「[ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義](tutorial--building-the-games-uwp-app-framework.md)」です。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-205">The next section is [Defining the game's UWP framework](tutorial--building-the-games-uwp-app-framework.md).</span></span> <span data-ttu-id="4a3b7-206">テンプレートで提供される概念やコンポーネントの多くを、このゲームでどのように使用し、拡張しているかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4a3b7-206">We'll examine how this game uses and extends many of the concepts and components that the template provides.</span></span>

 

 




