---
author: joannaleecy
title: ゲームの UWP アプリ フレームワークの定義
description: DirectX によるユニバーサル Windows プラットフォーム (UWP) ゲームのコーディングでは、まず、ゲーム オブジェクトと Windows との対話を可能にするフレームワークを構築します。
ms.assetid: 7beac1eb-ba3d-e15c-44a1-da2f5a79bb3b
ms.author: joanlee
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 3444c71b4e4c610be0b7d92ac6d761340c5dd5c2
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5814364"
---
#  <a name="define-the-uwp-app-framework"></a><span data-ttu-id="013ad-104">UWP アプリ フレームワークの定義</span><span class="sxs-lookup"><span data-stu-id="013ad-104">Define the UWP app framework</span></span>

<span data-ttu-id="013ad-105">中断/再開イベント、ウィンドウのフォーカスの変更、スナップなどの Windows ランタイム プロパティを含め、ゲーム オブジェクトが Windows とやり取りできるようにするためのフレームワークを構築します。</span><span class="sxs-lookup"><span data-stu-id="013ad-105">Build a framework to let your game object interact with Windows, including Windows Runtime properties like suspend-resume event handling, changes in window focus, and snapping.</span></span>

<span data-ttu-id="013ad-106">このフレームワークを設定するために、まず、アプリ シングルトン (実行中のアプリのインスタンスを定義する Windows ランタイム オブジェクト) が必要なグラフィック リソースにアクセスできるようにするビュー プロバイダーを取得します。</span><span class="sxs-lookup"><span data-stu-id="013ad-106">To set this framework up, first obtain a view provider so that the app singleton, which is the Windows Runtime object that defines an instance of your running app, can access the graphic resources it needs.</span></span> <span data-ttu-id="013ad-107">Windows ランタイムを通じて、ゲームはグラフィックス インターフェイスに直接接続して、必要なリソースとその処理方法を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="013ad-107">Through Windows Runtime, your game also has a direct connection with the graphics interface, allowing you to specify the resources needed and how to handle them.</span></span>

<span data-ttu-id="013ad-108">ビュー プロバイダー オブジェクトは、__IFrameworkView__ インターフェイスを実装します。これには、このゲーム サンプルを作成するために構成する必要がある一連のメソッドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="013ad-108">The view provider object implements the __IFrameworkView__ interface, which consists of a series of methods that needs to be configured to create this game sample.</span></span>

<span data-ttu-id="013ad-109">アプリ シングルトンが呼び出す次の 5 つのメソッドを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="013ad-109">You'll need to implement these five methods that the app singleton calls:</span></span>
* [__<span data-ttu-id="013ad-110">Initialize</span><span class="sxs-lookup"><span data-stu-id="013ad-110">Initialize</span></span>__](#initialize-the-view-provider)
* [__<span data-ttu-id="013ad-111">SetWindow</span><span class="sxs-lookup"><span data-stu-id="013ad-111">SetWindow</span></span>__](#configure-the-window-and-display-behavior)
* [__<span data-ttu-id="013ad-112">Load</span><span class="sxs-lookup"><span data-stu-id="013ad-112">Load</span></span>__](#load-method-of-the-view-provider)
* [__<span data-ttu-id="013ad-113">Run</span><span class="sxs-lookup"><span data-stu-id="013ad-113">Run</span></span>__](#run-method-of-the-view-provider)
* [__<span data-ttu-id="013ad-114">Uninitialize</span><span class="sxs-lookup"><span data-stu-id="013ad-114">Uninitialize</span></span>__](#uninitialize-method-of-the-view-provider)

<span data-ttu-id="013ad-115">__Initialize__ メソッドは、アプリケーションの起動時に呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-115">The __Initialize__ method is called on application launch.</span></span> <span data-ttu-id="013ad-116">__SetWindow__ メソッドは __Initialize__ の後に呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-116">__SetWindow__ method is called after __Initialize__.</span></span> <span data-ttu-id="013ad-117">次に、__Load__ メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-117">And then the __Load__ method is called.</span></span> <span data-ttu-id="013ad-118">__Run__ メソッドはゲームの実行中に呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-118">The __Run__ method is when the game is running.</span></span> <span data-ttu-id="013ad-119">ゲームが終了すると、__Uninitialize__ メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-119">When the game ends, the __Uninitialize__ method is called.</span></span> <span data-ttu-id="013ad-120">詳しくは、[__IFrameworkView__ の API リファレンス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.iframeworkview)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-120">For more info, see [__IFrameworkView__ API reference](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.iframeworkview).</span></span> 

>[!Note]
><span data-ttu-id="013ad-121">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-121">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="013ad-122">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="013ad-122">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="013ad-123">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="013ad-123">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="objective"></a><span data-ttu-id="013ad-124">目標</span><span class="sxs-lookup"><span data-stu-id="013ad-124">Objective</span></span>

<span data-ttu-id="013ad-125">ユニバーサル Windows プラットフォーム (UWP) DirectX ゲーム用のフレームワークをセットアップし、ゲーム全体のフローを定義するステート マシンを実装します。</span><span class="sxs-lookup"><span data-stu-id="013ad-125">Set up the framework for a Universal Windows Platform (UWP) DirectX game and implement the state machine that defines the overall game flow.</span></span>

## <a name="define-the-view-provider-factory-and-view-provider-object"></a><span data-ttu-id="013ad-126">ビュー プロバイダー ファクトリとビュー プロバイダー オブジェクトを定義する</span><span class="sxs-lookup"><span data-stu-id="013ad-126">Define the view provider factory and view provider object</span></span>

<span data-ttu-id="013ad-127">__App.cpp__ 内の __main__ ループを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="013ad-127">Let's examine the __main__ loop in __App.cpp__.</span></span> 

<span data-ttu-id="013ad-128">この手順では、ビューのファクトリを作成 (__IFrameworkViewSource__ を実装) し、次に、ビューを定義するビュー プロバイダー オブジェクトのインスタンスを作成 (__IFrameworkView__ を実装) します。</span><span class="sxs-lookup"><span data-stu-id="013ad-128">In this step, we create a factory for the view (implements __IFrameworkViewSource__), which in turn creates instances of the view provider object (implements __IFrameworkView__) that defines the view.</span></span>

### <a name="main-method"></a><span data-ttu-id="013ad-129">Main メソッド</span><span class="sxs-lookup"><span data-stu-id="013ad-129">Main method</span></span>

<span data-ttu-id="013ad-130">GitHub サンプル コードを読み込んでいる場合は、新しい __DirectXApplicationSource__ を作成します </span><span class="sxs-lookup"><span data-stu-id="013ad-130">Create a new __DirectXApplicationSource__ if you have the GitHub sample code loaded.</span></span> <span data-ttu-id="013ad-131">(元の DirectX テンプレートを使用している場合は __Direct3DApplicationSource__ を使用します)。これは、__IFrameworkViewSource__ を実装するビュー プロバイダー ファクトリです。</span><span class="sxs-lookup"><span data-stu-id="013ad-131">(Use __Direct3DApplicationSource__ if you're using the original DirectX template) This is the view provider factory that implements __IFrameworkViewSource__.</span></span> <span data-ttu-id="013ad-132">ビュー プロバイダー ファクトリの __IFrameworkViewSource__ インターフェイスには、__CreateView__ という単一のメソッドが定義されています。</span><span class="sxs-lookup"><span data-stu-id="013ad-132">The view provider factory's __IFrameworkViewSource__ interface has a single method, __CreateView__, defined.</span></span>

<span data-ttu-id="013ad-133">__CoreApplication::Run__ では、__Direct3DApplicationSource__ または __DirectXApplicationSource__ が渡されたときに、アプリ シングルトンによって __CreateView__ メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-133">In __CoreApplication::Run__, the __CreateView__ method is called by the app singleton when __Direct3DApplicationSource__ or __DirectXApplicationSource__ is passed.</span></span>

<span data-ttu-id="013ad-134">__CreateView__ は、__IFrameworkView__ を実装するアプリ オブジェクトの新しいインスタンスへの参照を返します。これは、このサンプルでは __App__ クラス オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="013ad-134">__CreateView__ returns a reference to a new instance of your app object that implements __IFrameworkView__, which is the __App__ class object in this sample.</span></span> <span data-ttu-id="013ad-135">__App__ クラス オブジェクトがビュー プロバイダー オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="013ad-135">The __App__ class object is the view provider object.</span></span>

```cpp
// The main function is only used to initialize our IFrameworkView class.
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto directXApplicationSource = ref new DirectXApplicationSource();
    CoreApplication::Run(directXApplicationSource);
    return 0;
}

//--------------------------------------------------------------------------------------

IFrameworkView^ DirectXApplicationSource::CreateView()
{
    return ref new App();
}
```

## <a name="initialize-the-view-provider"></a><span data-ttu-id="013ad-136">ビュー プロバイダーを初期化する</span><span class="sxs-lookup"><span data-stu-id="013ad-136">Initialize the view provider</span></span>

<span data-ttu-id="013ad-137">ビュー プロバイダー オブジェクトが作成されたら、アプリケーションの起動時に、アプリ シングルトンが [**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="013ad-137">After the view provider object is created, the app singleton calls the [**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) method on application launch.</span></span> <span data-ttu-id="013ad-138">このため、メイン ウィンドウのアクティブ化の処理や、ゲームが突然の中断 (とその後に行われる場合がある再開) イベントを処理できることの確認など、UWP ゲームの最も基本的な動作をこのメソッドで処理することが非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="013ad-138">Therefore, it is crucial that this method handles the most fundamental behaviors of a UWP game, such as handling the activation of the main window and making sure that the game can handle a sudden suspend (and a possible later resume) event.</span></span>

<span data-ttu-id="013ad-139">この時点で、ゲーム アプリは一時停止 (または再開) メッセージを処理できます。</span><span class="sxs-lookup"><span data-stu-id="013ad-139">At this point, the game app can handle a suspend (or resume) message.</span></span> <span data-ttu-id="013ad-140">ただし、まだ操作するウィンドウはなく、ゲームは初期化されていません。</span><span class="sxs-lookup"><span data-stu-id="013ad-140">But there's still no window to work with and the game is uninitialized.</span></span> <span data-ttu-id="013ad-141">必要なことが、あといくつか残っています。</span><span class="sxs-lookup"><span data-stu-id="013ad-141">There's a few more things that need to happen!</span></span>

### <a name="appinitialize-method"></a><span data-ttu-id="013ad-142">App::Initialize メソッド</span><span class="sxs-lookup"><span data-stu-id="013ad-142">App::Initialize method</span></span>

<span data-ttu-id="013ad-143">このメソッドでは、ゲームのアクティブ化、一時停止、再開のためのさまざまなイベント ハンドラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="013ad-143">In this method, create various event handlers for activating, suspending, and resuming the game.</span></span>

<span data-ttu-id="013ad-144">デバイス リソースへのアクセスを取得します。</span><span class="sxs-lookup"><span data-stu-id="013ad-144">Get access to the device resources.</span></span> <span data-ttu-id="013ad-145">メモリ リソースが最初に作成されたときに、__make_shared__ 関数を使用して __shared_ptr__ を作成します。</span><span class="sxs-lookup"><span data-stu-id="013ad-145">The __make_shared__ function is used to create a __shared_ptr__ when the memory resource is created for the first time.</span></span> <span data-ttu-id="013ad-146">__make_shared__ を使用する利点は例外安全性です。</span><span class="sxs-lookup"><span data-stu-id="013ad-146">An advantage of using __make_shared__ is that it's exception-safe.</span></span> <span data-ttu-id="013ad-147">また、同じ呼び出しを使用して、制御ブロックとリソースにメモリを割り当てて、構築にかかるオーバーヘッドを削減します。</span><span class="sxs-lookup"><span data-stu-id="013ad-147">It also uses the same call to allocate the memory for the control block and the resource and therefore reduces the construction overhead.</span></span>

```cpp
void App::Initialize(
    CoreApplicationView^ applicationView
    )
{
    // Register event handlers for app lifecycle. This example includes Activated, so that we
    // can make the CoreWindow active and start rendering on the window.
    applicationView->Activated +=
        ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &App::OnActivated);

    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

    CoreApplication::Resuming +=
        ref new EventHandler<Platform::Object^>(this, &App::OnResuming);

    // At this point we have access to the device. 
    // We can create the device-dependent resources.
    m_deviceResources = std::make_shared<DX::DeviceResources>();
}
```

## <a name="configure-the-window-and-display-behaviors"></a><span data-ttu-id="013ad-148">ウィンドウと表示動作を構成する</span><span class="sxs-lookup"><span data-stu-id="013ad-148">Configure the window and display behaviors</span></span>

<span data-ttu-id="013ad-149">ここでは、[__SetWindow__](https://msdn.microsoft.com/library/windows/apps/hh700509) の実装を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="013ad-149">Now, let's look at the implementation of [__SetWindow__](https://msdn.microsoft.com/library/windows/apps/hh700509).</span></span> <span data-ttu-id="013ad-150">__SetWindow__ メソッドでは、ウィンドウと表示動作を構成します。</span><span class="sxs-lookup"><span data-stu-id="013ad-150">In the __SetWindow__ method, you configure the window and display behaviors.</span></span>

### <a name="appsetwindow-method"></a><span data-ttu-id="013ad-151">App::SetWindow メソッド</span><span class="sxs-lookup"><span data-stu-id="013ad-151">App::SetWindow method</span></span>

<span data-ttu-id="013ad-152">アプリ シングルトンは、ゲームのメイン ウィンドウを表す [__CoreWindow__](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトを提供し、そのリソースとイベントをゲームで使用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="013ad-152">The app singleton provides a [__CoreWindow__](https://msdn.microsoft.com/library/windows/apps/br208225) object that represents the game's main window, and makes its resources and events available to the game.</span></span> <span data-ttu-id="013ad-153">操作するウィンドウができたら、ゲームの基本的な UI コンポーネントとイベントを追加できます。</span><span class="sxs-lookup"><span data-stu-id="013ad-153">Now that there's a window to work with, the game can now start adding in the basic UI components and events.</span></span>

<span data-ttu-id="013ad-154">次に、マウスとタッチ コントロールの両方で使用できる __CoreCursor__ メソッドを使用してポインターを作成します。</span><span class="sxs-lookup"><span data-stu-id="013ad-154">Then, create a pointer using __CoreCursor__ method which can be used by both mouse and touch controls.</span></span>

<span data-ttu-id="013ad-155">最後に、(ディスプレイ デバイスが変更された場合に) ウィンドウのサイズ変更、終了、DPI 変更を行うための基本的なイベントを作成します。</span><span class="sxs-lookup"><span data-stu-id="013ad-155">Lastly, create basic events for window resizing, closing, and DPI changes (if the display device changes).</span></span> <span data-ttu-id="013ad-156">これらのイベントの詳細については、「[イベント処理](tutorial-game-flow-management.md#events-handling)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-156">For more info about the events, go to [Event Handling](tutorial-game-flow-management.md#events-handling).</span></span>

```cpp
void App::SetWindow(
    CoreWindow^ window
    )
{
    // Codes added to modify the original DirectX template project
    window->PointerCursor = ref new CoreCursor(CoreCursorType::Arrow, 0);

    PointerVisualizationSettings^ visualizationSettings = PointerVisualizationSettings::GetForCurrentView();
    visualizationSettings->IsContactFeedbackEnabled = false;
    visualizationSettings->IsBarrelButtonFeedbackEnabled = false;
    // --end of codes added
    
    m_deviceResources->SetWindow(window);

    window->Activated +=
        ref new TypedEventHandler<CoreWindow^, WindowActivatedEventArgs^>(this, &App::OnWindowActivationChanged);

    window->SizeChanged +=
        ref new TypedEventHandler<CoreWindow^, WindowSizeChangedEventArgs^>(this, &App::OnWindowSizeChanged);

    window->VisibilityChanged +=
        ref new TypedEventHandler<CoreWindow^, VisibilityChangedEventArgs^>(this, &App::OnVisibilityChanged);
        
    window->Closed +=
        ref new TypedEventHandler<CoreWindow^, CoreWindowEventArgs^>(this, &App::OnWindowClosed);

    DisplayInformation^ currentDisplayInformation = DisplayInformation::GetForCurrentView();

    currentDisplayInformation->DpiChanged +=
        ref new TypedEventHandler<DisplayInformation^, Platform::Object^>(this, &App::OnDpiChanged);

    currentDisplayInformation->OrientationChanged +=
        ref new TypedEventHandler<DisplayInformation^, Object^>(this, &App::OnOrientationChanged);
    
    // Codes added to modify the original DirectX template project
    currentDisplayInformation->StereoEnabledChanged +=
        ref new TypedEventHandler<DisplayInformation^, Platform::Object^>(this, &App::OnStereoEnabledChanged);
    // --end of codes added
    
    DisplayInformation::DisplayContentsInvalidated +=
        ref new TypedEventHandler<DisplayInformation^, Platform::Object^>(this, &App::OnDisplayContentsInvalidated);
}
```

## <a name="load-method-of-the-view-provider"></a><span data-ttu-id="013ad-157">ビュー プロバイダーの Load メソッド</span><span class="sxs-lookup"><span data-stu-id="013ad-157">Load method of the view provider</span></span>

<span data-ttu-id="013ad-158">メイン ウィンドウが設定された後、アプリ シングルトンは [__Load__](https://msdn.microsoft.com/library/windows/apps/hh700501) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="013ad-158">After the main window is set, the app singleton calls [__Load__](https://msdn.microsoft.com/library/windows/apps/hh700501).</span></span> <span data-ttu-id="013ad-159">このメソッドで一連の非同期タスクを使って、ゲーム オブジェクトを作成し、グラフィックス リソースを読み込み、ゲームのステート マシンを初期化します。</span><span class="sxs-lookup"><span data-stu-id="013ad-159">A set of asynchronous tasks is used in this method to create the game objects, load graphics resources, and initialize the game’s state machine.</span></span> <span data-ttu-id="013ad-160">ゲームのデータまたはアセットを事前に取得するには、**SetWindow** や **Initialize** よりも、このメソッドが適しています。</span><span class="sxs-lookup"><span data-stu-id="013ad-160">If you want to pre-fetch game data or assets, this is a better place for it than in **SetWindow** or **Initialize**.</span></span> 

<span data-ttu-id="013ad-161">Windows では、非同期タスク パターンを使用して、ゲームが入力の処理を開始するまでにかけることができる時間に制限が設けられているため、ゲームが入力の処理を開始できるように、__Load__ メソッドは迅速に完了するように設計する必要があります。</span><span class="sxs-lookup"><span data-stu-id="013ad-161">Because Windows imposes restrictions on the time your game can take before it must start processing input, by using the async task pattern, you need to design for the __Load__ method to complete quickly so it can start processing input.</span></span> <span data-ttu-id="013ad-162">読み込みに時間がかかる場合やリソースが多い場合は、進行状況バーを用意して定期的に更新するようにします。</span><span class="sxs-lookup"><span data-stu-id="013ad-162">If loading takes awhile or if there are lots of resources, provide your users with a regularly updated progress bar.</span></span> <span data-ttu-id="013ad-163">開始時の状態やグローバルな値の設定など、ゲームを開始する前に必要な準備を行う場合にも、このメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="013ad-163">This method is also used to do any necessary preparations before the game begins, like setting any starting states or global values.</span></span>

<span data-ttu-id="013ad-164">非同期プログラミングとタスクの並列処理の概念に慣れていない場合は、「[C++ での非同期プログラミング](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-164">If you are new to asynchronous programming and task parallelism concepts, go to [Asynchronous programming in C++](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps).</span></span>

### <a name="appload-method"></a><span data-ttu-id="013ad-165">App::Load メソッド</span><span class="sxs-lookup"><span data-stu-id="013ad-165">App::Load method</span></span>

<span data-ttu-id="013ad-166">読み込みタスクが含まれる __GameMain__ クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="013ad-166">Create the __GameMain__ class that contains the loading tasks.</span></span>

```cpp
void App::Load(
    Platform::String^ entryPoint
    )
{
        if (!m_main)
    {
        m_main = std::unique_ptr<GameMain>(new GameMain(m_deviceResources));
    }
}
````

### <a name="gamemain-constructor"></a><span data-ttu-id="013ad-167">GameMain コンストラクター</span><span class="sxs-lookup"><span data-stu-id="013ad-167">GameMain constructor</span></span>

* <span data-ttu-id="013ad-168">ゲーム レンダラーを作成して初期化します。</span><span class="sxs-lookup"><span data-stu-id="013ad-168">Create and initialize the game renderer.</span></span> <span data-ttu-id="013ad-169">詳細については、「[レンダリング フレームワーク I: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-169">For more information, see [Rendering framework I: Intro to rendering](tutorial--assembling-the-rendering-pipeline.md).</span></span>
* <span data-ttu-id="013ad-170">Simple3Dgame オブジェクトを作成して初期化します。</span><span class="sxs-lookup"><span data-stu-id="013ad-170">Create the initialize the Simple3Dgame object.</span></span> <span data-ttu-id="013ad-171">詳細については、「[メイン ゲーム オブジェクトの定義](tutorial--defining-the-main-game-loop.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-171">For more information, see [Define the main game object](tutorial--defining-the-main-game-loop.md).</span></span>    
* <span data-ttu-id="013ad-172">ゲームの UI コントロール オブジェクトを作成し、リソース ファイルの読み込み時に進行状況バーを表示するゲーム情報オーバーレイを表示します。</span><span class="sxs-lookup"><span data-stu-id="013ad-172">Create the game UI control object and display game info overlay to show a progress bar as the resource files load.</span></span> <span data-ttu-id="013ad-173">詳細については、「[ユーザー インターフェイスの追加](tutorial--adding-a-user-interface.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-173">For more information, see [Adding a user interface](tutorial--adding-a-user-interface.md).</span></span>
* <span data-ttu-id="013ad-174">コントローラー (タッチ、マウス、または Xbox ワイヤレス コントローラー) からの入力を読み取ることができるようにコントローラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="013ad-174">Create the controller so it can read input from the controller (touch, mouse, or XBox wireless controller).</span></span> <span data-ttu-id="013ad-175">詳細については、「[コントロールの追加](tutorial--adding-controls.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-175">For more information, see [Adding controls](tutorial--adding-controls.md).</span></span>
* <span data-ttu-id="013ad-176">コントローラーを初期化したら、移動とカメラのそれぞれのタッチ コントロール用に、画面の左下と右下の 2 つの四角形の領域を定義しています。</span><span class="sxs-lookup"><span data-stu-id="013ad-176">After the controller is initialized, we defined two rectangular areas in the lower-left and lower-right corners of the screen for the move and camera touch controls, respectively.</span></span> <span data-ttu-id="013ad-177">**SetMoveRect** を呼び出して定義される左下の四角形は、カメラを前後左右に動かすための仮想のコントロール パッドとして使われ、</span><span class="sxs-lookup"><span data-stu-id="013ad-177">The player uses the lower-left rectangle, defined by the call to **SetMoveRect**, as a virtual control pad for moving the camera forward and backward, and side to side.</span></span> <span data-ttu-id="013ad-178">**SetFireRect** メソッドで定義される右下の四角形は、弾を撃つための仮想のボタンとして使われます。</span><span class="sxs-lookup"><span data-stu-id="013ad-178">The lower-right rectangle, defined by the **SetFireRect** method, is used as a virtual button to fire the ammo.</span></span>
* <span data-ttu-id="013ad-179">__create_task__ と __create_task::then__ を使用して、リソースの読み込みを 2 つの独立したステージに分割します。</span><span class="sxs-lookup"><span data-stu-id="013ad-179">Use __create_task__ and __create_task::then__ to break resource loading into two separate stages.</span></span> <span data-ttu-id="013ad-180">Direct3D 11 デバイス コンテキストへのアクセスは、そのデバイス コンテキストが作成されたスレッドに制限されている一方で、オブジェクト作成のための Direct3D 11 デバイスへのアクセスにはスレッドの制限がないため、**CreateGameDeviceResourcesAsync** タスクは、元のスレッドで実行される完了タスク (*FinalizeCreateGameDeviceResources*) とは別のスレッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-180">Because access to the Direct3D 11 device context is restricted to the thread the device context was created on while access to the Direct3D 11 device for object creation is free-threaded, this means that the **CreateGameDeviceResourcesAsync** task can run on a separate thread from the completion task (*FinalizeCreateGameDeviceResources*), which runs on the original thread.</span></span> <span data-ttu-id="013ad-181">**LoadLevelAsync** と **FinalizeLoadLevel** を使うレベル リソースの読み込みにも同様のパターンを使います。</span><span class="sxs-lookup"><span data-stu-id="013ad-181">We use a similar pattern for loading level resources with **LoadLevelAsync** and **FinalizeLoadLevel**.</span></span>

```cpp
GameMain::GameMain(const std::shared_ptr<DX::DeviceResources>& deviceResources) :
    m_deviceResources(deviceResources),
    m_windowClosed(false),
    m_haveFocus(false),
    m_gameInfoOverlayCommand(GameInfoOverlayCommand::None),
    m_visible(true),
    m_loadingCount(0),
    m_updateState(UpdateEngineState::WaitingForResources)
{
    m_deviceResources->RegisterDeviceNotify(this);

    m_renderer = ref new GameRenderer(m_deviceResources);
    m_game = ref new Simple3DGame();

    m_uiControl = m_renderer->GameUIControl();

    m_controller = ref new MoveLookController(CoreWindow::GetForCurrentThread());

    auto bounds = m_deviceResources->GetLogicalSize();

    m_controller->SetMoveRect(
        XMFLOAT2(0.0f, bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(GameConstants::TouchRectangleSize, bounds.Height)
        );
    m_controller->SetFireRect(
        XMFLOAT2(bounds.Width - GameConstants::TouchRectangleSize, bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(bounds.Width, bounds.Height)
        );

    SetGameInfoOverlay(GameInfoOverlayState::Loading);
    m_uiControl->SetAction(GameInfoOverlayCommand::None);
    m_uiControl->ShowGameInfoOverlay();

    create_task([this]()
    {
        // Asynchronously initialize the game class and load the renderer device resources.
        // By doing all this asynchronously, the game gets to its main loop more quickly
        // and in parallel all the necessary resources are loaded on other threads.
        m_game->Initialize(m_controller, m_renderer);

        return m_renderer->CreateGameDeviceResourcesAsync(m_game);

    }).then([this]()
    {
        // The finalize code needs to run in the same thread context
        // as the m_renderer object was created because the D3D device context
        // can ONLY be accessed on a single thread.
        m_renderer->FinalizeCreateGameDeviceResources();

        InitializeGameState();

        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // In the middle of a game so spin up the async task to load the level.
            return m_game->LoadLevelAsync().then([this]()
            {
                // The m_game object may need to deal with D3D device context work so
                // again the finalize code needs to run in the same thread
                // context as the m_renderer object was created because the D3D
                // device context can ONLY be accessed on a single thread.
                m_game->FinalizeLoadLevel();
                m_game->SetCurrentLevelToSavedState();
                m_updateState = UpdateEngineState::ResourcesLoaded;

            }, task_continuation_context::use_current());
        }
        else
        {
            // The game is not in the middle of a level so there aren't any level
            // resources to load.  Creating a no-op task so that in both cases
            // the same continuation logic is used.
            return create_task([]()
            {
            });
        }
    }, task_continuation_context::use_current()).then([this]()
    {
        // Since Game loading is an async task, the app visual state
        // may be too small or not have focus.  Put the state machine
        // into the correct state to reflect these cases.

        if (m_deviceResources->GetLogicalSize().Width < GameConstants::MinPlayableWidth)
        {
            m_updateStateNext = m_updateState;
            m_updateState = UpdateEngineState::TooSmall;
            m_controller->Active(false);
            m_uiControl->HideGameInfoOverlay();
            m_uiControl->ShowTooSmall();
            m_renderNeeded = true;
        }
        else if (!m_haveFocus)
        {
            m_updateStateNext = m_updateState;
            m_updateState = UpdateEngineState::Deactivated;
            m_controller->Active(false);
            m_uiControl->SetAction(GameInfoOverlayCommand::None);
            m_renderNeeded = true;
        }
    }, task_continuation_context::use_current());
}
```

## <a name="run-method-of-the-view-provider"></a><span data-ttu-id="013ad-182">ビュー プロバイダーの Run メソッド</span><span class="sxs-lookup"><span data-stu-id="013ad-182">Run method of the view provider</span></span>

<span data-ttu-id="013ad-183">前述の 3 つメソッド __Initialize__、__SetWindow__、__Load__ によって、ステージを設定しました。</span><span class="sxs-lookup"><span data-stu-id="013ad-183">The earlier three methods: __Initialize__, __SetWindow__, and __Load__ have set the stage.</span></span> <span data-ttu-id="013ad-184">次に、ゲームは **Run** メソッドに進んで、楽しいゲームを開始できます。</span><span class="sxs-lookup"><span data-stu-id="013ad-184">Now the game can progress to the **Run** method, starting the fun!</span></span> <span data-ttu-id="013ad-185">ゲームの状態間の移行に使われるイベントのディスパッチと処理が行われます。</span><span class="sxs-lookup"><span data-stu-id="013ad-185">The events that it uses to transition between game states are dispatched and processed.</span></span> <span data-ttu-id="013ad-186">ゲーム ループの循環に応じてグラフィックスが更新されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-186">Graphics are updated as the game loop cycles.</span></span>

### <a name="apprun"></a><span data-ttu-id="013ad-187">App::Run</span><span class="sxs-lookup"><span data-stu-id="013ad-187">App::Run</span></span>

<span data-ttu-id="013ad-188">プレイヤーがゲーム ウィンドウを閉じると終了する __while__ ループを開始します。</span><span class="sxs-lookup"><span data-stu-id="013ad-188">Start a __while__ loop that terminates when the player closes the game window.</span></span>

<span data-ttu-id="013ad-189">サンプル コードは、ゲーム エンジンのステート マシンの次の 2 つのいずれかの状態に移行します。</span><span class="sxs-lookup"><span data-stu-id="013ad-189">The sample code transitions to one of two states in the game engine state machine:</span></span>
    * <span data-ttu-id="013ad-190">__Deactivated__: ゲーム ウィンドウが非アクティブ化される (フォーカスを失う) か、スナップされます。</span><span class="sxs-lookup"><span data-stu-id="013ad-190">__Deactivated__: The game window gets deactivated (loses focus) or snapped.</span></span> <span data-ttu-id="013ad-191">この場合、ゲームではイベントの処理を中断し、ウィンドウがフォーカスまたはスナップを解除されるまで待機します。</span><span class="sxs-lookup"><span data-stu-id="013ad-191">When this happens, the game suspends event processing and waits for the window to focus or unsnap.</span></span>
    * <span data-ttu-id="013ad-192">__TooSmall__: ゲームが自身の状態を更新し、表示するグラフィックスをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="013ad-192">__TooSmall__: The game updates its own state and renders the graphics for display.</span></span>

<span data-ttu-id="013ad-193">ゲームにフォーカスがある場合、メッセージ キューに到達する各イベントを処理する必要があるため、[**CoreWindowDispatch.ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を **ProcessAllIfPresent** オプションで呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="013ad-193">When your game has focus, you must handle every event in the message queue as it arrives, and so you must call [**CoreWindowDispatch.ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) with the **ProcessAllIfPresent** option.</span></span> <span data-ttu-id="013ad-194">他のオプションでは、メッセージ イベントの処理に遅延が発生することがあり、この場合、ゲームが応答しなくなったように見えるか、タッチ動作の反応が遅くて "敏感" でないように見える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="013ad-194">Other options can cause delays in processing message events, which can make your game feel unresponsive, or result in touch behaviors that feel sluggish and not "sticky".</span></span>

<span data-ttu-id="013ad-195">ゲームが表示されていないときや中断またはスナップ状態のときにリソースを循環させてどこにも到達しないメッセージをディスパッチすることは回避する必要があるため、</span><span class="sxs-lookup"><span data-stu-id="013ad-195">When the game is not visible, suspended or snapped, you don't want it to consume any resources cycling to dispatch messages that will never arrive.</span></span> <span data-ttu-id="013ad-196">ゲームでは **ProcessOneAndAllPending** を使う必要があります。この結果、イベントが取得されるまではブロックが行われ、その後、そのイベントと、そのイベントの処理中にプロセス キューに到達した他のイベントが処理されます。</span><span class="sxs-lookup"><span data-stu-id="013ad-196">In this case, your game must use **ProcessOneAndAllPending**, which blocks until it gets an event, and then processes that event and any others that arrive in the process queue during the processing of the first.</span></span> <span data-ttu-id="013ad-197">その後、キューの処理が終了すると、[**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) に即座に戻ります。</span><span class="sxs-lookup"><span data-stu-id="013ad-197">[**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) then immediately returns after the queue has been processed.</span></span>

```cpp
void App::Run()
{
    m_main->Run();
}

void GameMain::Run()
{
    while (!m_windowClosed)
    {
        if (m_visible)
        {
            switch (m_updateState)
            {
            case UpdateEngineState::Deactivated:
            case UpdateEngineState::TooSmall:
                if (m_updateStateNext == UpdateEngineState::WaitingForResources)
                {
                    WaitingForResourceLoading();
                    m_renderNeeded = true;
                }
                else if (m_updateStateNext == UpdateEngineState::ResourcesLoaded)
                {
                    // In the device lost case, we transition to the final waiting state
                    // and make sure the display is updated.
                    switch (m_pressResult)
                    {
                    case PressResultState::LoadGame:
                        SetGameInfoOverlay(GameInfoOverlayState::GameStats);
                        break;

                    case PressResultState::PlayLevel:
                        SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
                        break;

                    case PressResultState::ContinueLevel:
                        SetGameInfoOverlay(GameInfoOverlayState::Pause);
                        break;
                    }
                    m_updateStateNext = UpdateEngineState::WaitingForPress;
                    m_uiControl->ShowGameInfoOverlay();
                    m_renderNeeded = true;
                }

                if (!m_renderNeeded)
                {
                    // The App is not currently the active window and not in a transient state so just wait for events.
                    CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
                    break;
                }
                // otherwise fall through and do normal processing to get the rendering handled.
            default:
                CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
                Update();
                m_renderer->Render();
                m_deviceResources->Present();
                m_renderNeeded = false;
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
    m_game->OnSuspending();  // exiting due to window close.  Make sure to save state.
}
```

## <a name="uninitialize-method-of-the-view-provider"></a><span data-ttu-id="013ad-198">ビュー プロバイダーの Uninitialize メソッド</span><span class="sxs-lookup"><span data-stu-id="013ad-198">Uninitialize method of the view provider</span></span>

<span data-ttu-id="013ad-199">ユーザー最終的にゲーム セッションを終了したら、クリーンアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="013ad-199">When the user eventually ends the game session, we need to clean up.</span></span> <span data-ttu-id="013ad-200">**Uninitialize** はまさにそのような用途に使います。</span><span class="sxs-lookup"><span data-stu-id="013ad-200">This is where **Uninitialize** comes in.</span></span>

<span data-ttu-id="013ad-201">Windows 10 では、アプリ ウィンドウを閉じても強制アプリのプロセスが代わりに、アプリ シングルトンの状態をメモリに書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="013ad-201">In Windows10, closing the app window doesn't kill the app's process, but instead it writes the state of the app singleton to memory.</span></span> <span data-ttu-id="013ad-202">システムでこのメモリの再利用が必要になった際に、リソースの特別なクリーンアップなどの特別な処理が必要な場合は、そのクリーンアップ用のコードをこのメソッドに入れてください。</span><span class="sxs-lookup"><span data-stu-id="013ad-202">If anything special must happen when the system must reclaim this memory, including any special cleanup of resources, then put the code for that cleanup in this method.</span></span>

### <a name="app-uninitialize"></a><span data-ttu-id="013ad-203">App:: Uninitialize</span><span class="sxs-lookup"><span data-stu-id="013ad-203">App:: Uninitialize</span></span>

```cpp
void App::Uninitialize()
{
}
```

## <a name="tips"></a><span data-ttu-id="013ad-204">ヒント</span><span class="sxs-lookup"><span data-stu-id="013ad-204">Tips</span></span>

<span data-ttu-id="013ad-205">ゲームを開発するときは、これらのメソッドの近くにスタートアップ コードを設計してください。</span><span class="sxs-lookup"><span data-stu-id="013ad-205">When developing your own game, design your startup code around these methods.</span></span> <span data-ttu-id="013ad-206">各メソッドの基本的な推奨事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="013ad-206">Here's a simple list of basic suggestions for each method:</span></span>

-   <span data-ttu-id="013ad-207">メイン クラスの割り当てと基本的なイベント ハンドラーの接続には **Initialize** を使います。</span><span class="sxs-lookup"><span data-stu-id="013ad-207">Use **Initialize** to allocate your main classes and connect up the basic event handlers.</span></span>
-   <span data-ttu-id="013ad-208">メイン ウィンドウの作成とウィンドウ固有のイベントの接続には **SetWindow** を使います。</span><span class="sxs-lookup"><span data-stu-id="013ad-208">Use **SetWindow** to create your main window and connect any window-specific events.</span></span>
-   <span data-ttu-id="013ad-209">その他のセットアップの処理と非同期のオブジェクト作成やリソース読み込みには **Load** を使います。</span><span class="sxs-lookup"><span data-stu-id="013ad-209">Use **Load** to handle any remaining setup, and to initiate the async creation of objects and loading of resources.</span></span> <span data-ttu-id="013ad-210">一時ファイルまたは一時データを作成する必要がある場合は (手続き的に生成されるアセットなど)、その処理もこのメソッドで行います。</span><span class="sxs-lookup"><span data-stu-id="013ad-210">If you need to create any temporary files or data, such as procedurally generated assets, do it here too.</span></span>


## <a name="next-steps"></a><span data-ttu-id="013ad-211">次の手順</span><span class="sxs-lookup"><span data-stu-id="013ad-211">Next steps</span></span>

<span data-ttu-id="013ad-212">ここでは、DirectX を使った UWP ゲームの基本的な構造について説明します。</span><span class="sxs-lookup"><span data-stu-id="013ad-212">This covers the basic structure of a UWP game with DirectX.</span></span> <span data-ttu-id="013ad-213">このチュートリアルの他の部分で参照するので、ここで説明した 5 つのメソッドを覚えておいてください。</span><span class="sxs-lookup"><span data-stu-id="013ad-213">Keep these five methods in mind as we'll reference them in other parts of this walkthrough.</span></span> <span data-ttu-id="013ad-214">次に、「[ゲームのフロー管理](tutorial-game-flow-management.md)」で、ゲームを続行するために、ゲームの状態とイベント処理を管理する方法について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="013ad-214">Next, we'll take an in-depth look at how to manage game states and event handling to keep the game going under [Game flow management](tutorial-game-flow-management.md).</span></span>



