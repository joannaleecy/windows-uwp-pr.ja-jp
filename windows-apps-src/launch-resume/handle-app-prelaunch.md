---
author: TylerMSFT
title: アプリの事前起動の処理
description: OnLaunched メソッドをオーバーライドし、CoreApplication.EnablePrelaunch(true) を呼び出すことで、アプリの事前起動を処理する方法について説明します。
ms.assetid: A4838AC2-22D7-46BA-9EB2-F3C248E22F52
ms.author: twhitney
ms.date: 07/05/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a13ec942080d7fe517a10b837bea9ae8fae27750
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5641038"
---
# <a name="handle-app-prelaunch"></a><span data-ttu-id="21560-104">アプリの事前起動の処理</span><span class="sxs-lookup"><span data-stu-id="21560-104">Handle app prelaunch</span></span>

<span data-ttu-id="21560-105">[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドをオーバーライドすることで、アプリの事前起動を処理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="21560-105">Learn how to handle app prelaunch by overriding the [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) method.</span></span>

## <a name="introduction"></a><span data-ttu-id="21560-106">はじめに</span><span class="sxs-lookup"><span data-stu-id="21560-106">Introduction</span></span>

<span data-ttu-id="21560-107">利用可能なシステム リソースができるように、事前にバック グラウンドでのユーザーの最も頻繁に使うアプリを起動することによりデスクトップ デバイス ファミリのデバイス上の UWP アプリの起動時のパフォーマンスが向上しています。</span><span class="sxs-lookup"><span data-stu-id="21560-107">When available system resources allow, the startup performance of UWP apps on desktop device family devices is improved by proactively launching the user’s most frequently used apps in the background.</span></span> <span data-ttu-id="21560-108">事前起動されたアプリは起動直後に中断状態になります。</span><span class="sxs-lookup"><span data-stu-id="21560-108">A prelaunched app is put into the suspended state shortly after it is launched.</span></span> <span data-ttu-id="21560-109">その後、ユーザーがアプリを呼び出すと、アプリは中断状態から実行状態に移って再開されます。これは、アプリのコールド スタートよりも高速です。</span><span class="sxs-lookup"><span data-stu-id="21560-109">Then, when the user invokes the app, the app is resumed by bringing it from the suspended state to the running state--which is faster than launching the app cold.</span></span> <span data-ttu-id="21560-110">ユーザーのエクスペリエンスとしては、アプリが非常に短時間で起動するように感じられます。</span><span class="sxs-lookup"><span data-stu-id="21560-110">The user's experience is that the app simply launched very quickly.</span></span>

<span data-ttu-id="21560-111">Windows 10 より前では、アプリは自動的には事前起動を利用しませんでした。</span><span class="sxs-lookup"><span data-stu-id="21560-111">Prior to Windows 10, apps did not automatically take advantage of prelaunch.</span></span> <span data-ttu-id="21560-112">Windows 10 バージョン 1511 では、すべてのユニバーサル Windows プラットフォーム (UWP) アプリが事前起動の候補をでした。</span><span class="sxs-lookup"><span data-stu-id="21560-112">In Windows10, version 1511, all Universal Windows Platform (UWP) apps were candidates for being prelaunched.</span></span> <span data-ttu-id="21560-113">Windows 10 バージョン 1607 では、[CoreApplication.EnablePrelaunch(true)](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx) を呼び出すことで、事前起動の動作にオプトインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="21560-113">In Windows 10, version 1607, you must opt-in to prelaunch behavior by calling [CoreApplication.EnablePrelaunch(true)](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx).</span></span> <span data-ttu-id="21560-114">この呼び出しを配置する最適な場所は、`OnLaunched()` 内の `if (e.PrelaunchActivated == false)` チェックが実行される位置の近くです。</span><span class="sxs-lookup"><span data-stu-id="21560-114">A good place to put this call is within `OnLaunched()` near the location that the `if (e.PrelaunchActivated == false)` check is made.</span></span>

<span data-ttu-id="21560-115">アプリが事前起動されるかどうかは、システム リソースに応じて決まります。</span><span class="sxs-lookup"><span data-stu-id="21560-115">Whether an app is prelaunched depends on system resources.</span></span> <span data-ttu-id="21560-116">システムのリソースに負荷が掛かっている場合、アプリは事前起動されません。</span><span class="sxs-lookup"><span data-stu-id="21560-116">If the system is experiencing resource pressure, apps are not prelaunched.</span></span>

<span data-ttu-id="21560-117">アプリの種類によっては、事前起動を利用するために、起動の動作の変更が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="21560-117">Some types of apps may need to change their startup behavior to work well with prelaunch.</span></span> <span data-ttu-id="21560-118">たとえば、起動時に音楽を再生するアプリ、ユーザーがオンラインであることを想定してアプリの起動時に凝ったビジュアルを表示するゲーム、起動時にユーザーのオンライン状態を変更するメッセージング アプリは、アプリが事前起動したことを識別し、以下の説明のとおり起動の動作を変更できます。</span><span class="sxs-lookup"><span data-stu-id="21560-118">For example, an app that plays music when its starts up, a game which assumes the user is present and displays elaborate visuals when the app starts up, a messaging app that changes the user's online visibility during startup, can identify when the app was prelaunched and can change their startup behavior as described in the sections below.</span></span>

<span data-ttu-id="21560-119">XAML プロジェクト (C#、VB、C++) と WinJS の既定のテンプレートは、Visual Studio 2015 Update 3 で事前起動に対応します。</span><span class="sxs-lookup"><span data-stu-id="21560-119">The default templates for XAML Projects (C#, VB, C++) and WinJS accommodate prelaunch in Visual Studio 2015 Update 3.</span></span>

## <a name="prelaunch-and-the-app-lifecycle"></a><span data-ttu-id="21560-120">事前起動とアプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="21560-120">Prelaunch and the app lifecycle</span></span>

<span data-ttu-id="21560-121">アプリは、事前起動された後すぐに中断状態になります。</span><span class="sxs-lookup"><span data-stu-id="21560-121">After an app is prelaunched, it will enter the suspended state.</span></span> <span data-ttu-id="21560-122">(「[アプリの中断の処理](suspend-an-app.md)」をご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="21560-122">(see [Handle app suspend](suspend-an-app.md)).</span></span>

## <a name="detect-and-handle-prelaunch"></a><span data-ttu-id="21560-123">事前起動の検出と処理</span><span class="sxs-lookup"><span data-stu-id="21560-123">Detect and handle prelaunch</span></span>

<span data-ttu-id="21560-124">アプリはアクティブ化中に [**LaunchActivatedEventArgs.PrelaunchActivated**](https://msdn.microsoft.com/library/windows/apps/dn263740) フラグを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="21560-124">Apps receive the [**LaunchActivatedEventArgs.PrelaunchActivated**](https://msdn.microsoft.com/library/windows/apps/dn263740) flag during activation.</span></span> <span data-ttu-id="21560-125">このフラグを使用する必要がありますのみを実行しているユーザーが明示的に、アプリを起動したとき[**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335)変更が次に示すようにコードを実行します。</span><span class="sxs-lookup"><span data-stu-id="21560-125">Use this flag to run code that should only run when the user explicitly launches the app, as shown in the following modification to [**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335).</span></span>

```csharp
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    // CoreApplication.EnablePrelaunch was introduced in Windows 10 version 1607
    bool canEnablePrelaunch = Windows.Foundation.Metadata.ApiInformation.IsMethodPresent("Windows.ApplicationModel.Core.CoreApplication", "EnablePrelaunch");

    // NOTE: Only enable this code if you are targeting a version of Windows 10 prior to version 1607
    // and you want to opt-out of prelaunch.
    // In Windows 10 version 1511, all UWP apps were candidates for prelaunch.
    // Starting in Windows 10 version 1607, the app must opt-in to be prelaunched.
    //if ( !canEnablePrelaunch && e.PrelaunchActivated == true)
    //{
    //    return;
    //}

    Frame rootFrame = Window.Current.Content as Frame;

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == null)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
    }

    if (e.PrelaunchActivated == false)
    {
        // On Windows 10 version 1607 or later, this code signals that this app wants to participate in prelaunch
        if (canEnablePrelaunch)
        {
            TryEnablePrelaunch();
        }

        // TODO: This is not a prelaunch activation. Perform operations which
        // assume that the user explicitly launched the app such as updating
        // the online presence of the user on a social network, updating a
        // what's new feed, etc.

        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(MainPage), e.Arguments);
        }
        // Ensure the current window is active
        Window.Current.Activate();
    }
}

/// <summary>
/// Encapsulates the call to CoreApplication.EnablePrelaunch() so that the JIT
/// won't encounter that call (and prevent the app from running when it doesn't
/// find it), unless this method gets called. This method should only
/// be called when the caller determines that we are running on a system that
/// supports CoreApplication.EnablePrelaunch().
/// </summary>
private void TryEnablePrelaunch()
{
    Windows.ApplicationModel.Core.CoreApplication.EnablePrelaunch(true);
}
```

<span data-ttu-id="21560-126">注:、`TryEnablePrelaunch()`関数で、上記のします。</span><span class="sxs-lookup"><span data-stu-id="21560-126">Note the `TryEnablePrelaunch()` function, above.</span></span> <span data-ttu-id="21560-127">理由の呼び出しを`CoreApplication.EnablePrelaunch()`に関しては、この関数には、メソッドが呼び出されたとき (だけでコンパイル) JIT がしようとするとメソッド全体をコンパイルするためです。</span><span class="sxs-lookup"><span data-stu-id="21560-127">The reason the call to `CoreApplication.EnablePrelaunch()` is factored out into this function is because when a method is called, the JIT (just in time compilation) will attempt to compile the entire method.</span></span> <span data-ttu-id="21560-128">アプリがサポートされていない Windows 10 のバージョンで実行されているかどうかは`CoreApplication.EnablePrelaunch()`、JIT は失敗します。</span><span class="sxs-lookup"><span data-stu-id="21560-128">If your app is running on a version of Windows 10 that doesn't support `CoreApplication.EnablePrelaunch()`, then the JIT will fail.</span></span> <span data-ttu-id="21560-129">アプリをプラットフォームをサポートしているときにのみ呼び出されるメソッドの呼び出しを考慮することによって`CoreApplication.EnablePrelaunch()`、問題を回避します。</span><span class="sxs-lookup"><span data-stu-id="21560-129">By factoring the call into a method that is only called when the app determines that the platform supports `CoreApplication.EnablePrelaunch()`, we avoid that problem.</span></span>

<span data-ttu-id="21560-130">あるかどうか、アプリがオプトアウトする事前起動の場合、Windows 10 バージョン 1511 で実行されている必要がありますコメントを解除できます上記の例でコードがあります。</span><span class="sxs-lookup"><span data-stu-id="21560-130">There is also code in the example above that you can uncomment if your app needs to opt-out of prelaunch when running on Windows 10, version 1511.</span></span> <span data-ttu-id="21560-131">バージョン 1511 では、すべての UWP アプリが自動的にことを選んで場合に、事前起動されるできない可能性があるアプリに適したします。</span><span class="sxs-lookup"><span data-stu-id="21560-131">In version 1511, all UWP apps were automatically opted into prelaunch, which may not be appropriate for your app.</span></span>

## <a name="use-the-visibilitychanged-event"></a><span data-ttu-id="21560-132">VisibilityChanged イベントの使用</span><span class="sxs-lookup"><span data-stu-id="21560-132">Use the VisibilityChanged event</span></span>

<span data-ttu-id="21560-133">事前起動によってアクティブ化されたアプリはユーザーに対して表示されません。</span><span class="sxs-lookup"><span data-stu-id="21560-133">Apps activated by prelaunch are not visible to the user.</span></span> <span data-ttu-id="21560-134">ユーザーがそれらのアプリに切り替えると表示されます。</span><span class="sxs-lookup"><span data-stu-id="21560-134">They become visible when the user switches to them.</span></span> <span data-ttu-id="21560-135">アプリのメイン ウィンドウが表示されるまで、特定の操作を遅らせることが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="21560-135">You may want to delay certain operations until your app's main window becomes visible.</span></span> <span data-ttu-id="21560-136">たとえば、アプリによってフィードからの新着アイテムの一覧が表示される場合は、[**VisibilityChanged**](https://msdn.microsoft.com/library/windows/apps/hh702458) イベントの発生時に一覧を更新できます。アプリの事前起動時に生成された一覧は使いません。ユーザーがアプリをアクティブ化するまでに、その一覧が古くなっている可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="21560-136">For example, if your app displays a list of what's new items from a feed, you could update the list during the [**VisibilityChanged**](https://msdn.microsoft.com/library/windows/apps/hh702458) event rather than use the list that was built when the app was prelaunched because it may become stale by the time the user activates the app.</span></span> <span data-ttu-id="21560-137">次のコードは、**MainPage** の **VisibilityChanged** イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="21560-137">The following code handles the **VisibilityChanged** event for **MainPage**:</span></span>

```csharp
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        Window.Current.VisibilityChanged += WindowVisibilityChangedEventHandler;
    }

    void WindowVisibilityChangedEventHandler(System.Object sender, Windows.UI.Core.VisibilityChangedEventArgs e)
    {
        // Perform operations that should take place when the application becomes visible rather than
        // when it is prelaunched, such as building a what's new feed
    }
}
```

## <a name="directx-games-guidance"></a><span data-ttu-id="21560-138">DirectX ゲームのガイダンス</span><span class="sxs-lookup"><span data-stu-id="21560-138">DirectX games guidance</span></span>

<span data-ttu-id="21560-139">DirectX ゲームは、一般に、事前起動を有効にしないでください。多くの DirectX ゲームは、事前起動を検出できるより前に初期化を実行するためです。</span><span class="sxs-lookup"><span data-stu-id="21560-139">DirectX games should generally not enable prelaunch because many DirectX games do their initialization before prelaunch can be detected.</span></span> <span data-ttu-id="21560-140">Windows 1607 (Anniversary エディション) 以降では、ゲームは既定で事前起動されません。</span><span class="sxs-lookup"><span data-stu-id="21560-140">Starting with Windows 1607, Anniversary edition, your game will not be prelaunched by default.</span></span>  <span data-ttu-id="21560-141">ゲームで事前起動を利用する必要がある場合は、[CoreApplication.EnablePrelaunch(true)](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="21560-141">If you do want your game to take advantage of prelaunch, call [CoreApplication.EnablePrelaunch(true)](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx).</span></span>

<span data-ttu-id="21560-142">以前のバージョンの Windows 10 をターゲットとするゲームでは、事前起動の条件を処理してアプリケーションを終了することができます。</span><span class="sxs-lookup"><span data-stu-id="21560-142">If your game targets an earlier version of Windows 10, you can handle the prelaunch condition to exit the application:</span></span>

```cppwinrt
void ViewProvider::OnActivated(CoreApplicationView const& /* appView */, Windows::ApplicationModel::Activation::IActivatedEventArgs const& args)
{
    if (args.Kind() == Windows::ApplicationModel::Activation::ActivationKind::Launch)
    {
        auto launchArgs{ args.as<Windows::ApplicationModel::Activation::LaunchActivatedEventArgs>()};
        if (launchArgs.PrelaunchActivated())
        {
            // Opt-out of Prelaunch.
            CoreApplication::Exit();
        }
    }
}

void ViewProvider::Initialize(CoreApplicationView const & appView)
{
    appView.Activated({ this, &App::OnActivated });
}
```

```cpp
void ViewProvider::OnActivated(CoreApplicationView^ appView,IActivatedEventArgs^ args)
{
    if (args->Kind == ActivationKind::Launch)
    {
        auto launchArgs = static_cast<LaunchActivatedEventArgs^>(args);
        if (launchArgs->PrelaunchActivated)
        {
            // Opt-out of Prelaunch
            CoreApplication::Exit();
            return;
        }
    }
}
```

## <a name="winjs-app-guidance"></a><span data-ttu-id="21560-143">WinJS アプリのガイダンス</span><span class="sxs-lookup"><span data-stu-id="21560-143">WinJS app guidance</span></span>

<span data-ttu-id="21560-144">以前のバージョンの Windows 10 をターゲットとする WinJS アプリでは、[onactivated](https://msdn.microsoft.com/library/windows/apps/br212679.aspx) ハンドラー内で事前起動の条件を処理することができます。</span><span class="sxs-lookup"><span data-stu-id="21560-144">If your WinJS app targets an earlier version of Windows 10, you can handle the prelaunch condition in your [onactivated](https://msdn.microsoft.com/library/windows/apps/br212679.aspx) handler:</span></span>

```javascript
    app.onactivated = function (args) {
        if (!args.detail.prelaunchActivated) {
            // TODO: This is not a prelaunch activation. Perform operations which
            // assume that the user explicitly launched the app such as updating
            // the online presence of the user on a social network, updating a
            // what's new feed, etc.
        }
    }
```

## <a name="general-guidance"></a><span data-ttu-id="21560-145">一般的なガイダンス</span><span class="sxs-lookup"><span data-stu-id="21560-145">General Guidance</span></span>

-   <span data-ttu-id="21560-146">長時間かかる操作を、アプリが事前起動時に実行しないようにしてください。アプリはすぐに中断状態に移れない場合に終了するためです。</span><span class="sxs-lookup"><span data-stu-id="21560-146">Apps should not perform long running operations during prelaunch because the app will terminate if it can't be suspended quickly.</span></span>
-   <span data-ttu-id="21560-147">アプリが事前起動された場合、アプリは [**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) からオーディオの再生を開始しません。アプリは表示されず、オーディオ再生が行われる理由がはっきりしないためです。</span><span class="sxs-lookup"><span data-stu-id="21560-147">Apps should not initiate audio playback from [**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) when the app is prelaunched because the app won't be visible and it won't be apparent why there is audio playing.</span></span>
-   <span data-ttu-id="21560-148">アプリがユーザーに表示されていることを前提とした操作やユーザーによって明示的に起動されたことを前提とした操作を、アプリが事前起動時に実行しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="21560-148">Apps should not perform any operations during launch which assume that the app is visible to the user, or assume that the app was explicitly launched by the user.</span></span> <span data-ttu-id="21560-149">アプリはユーザーによる明示的な操作なしにバックグラウンドで起動できるようになったため、開発者はプライバシー、ユーザー エクスペリエンス、パフォーマンスへの影響を配慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21560-149">Because an app can now be launched in the background without explicit user action, developers should consider the privacy, user experience and performance implications.</span></span>
    -   <span data-ttu-id="21560-150">プライバシーの配慮の一例は、ソーシャル アプリがユーザーの状態をオンラインに変更する場合です。</span><span class="sxs-lookup"><span data-stu-id="21560-150">An example privacy consideration is when a social app should change the user state to online.</span></span> <span data-ttu-id="21560-151">アプリの事前起動時に状態を変更せずに、ユーザーがそのアプリに切り替えるまで待機する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21560-151">It should wait until the user switches to the app instead of changing the status when the app is prelaunched.</span></span>
    -   <span data-ttu-id="21560-152">ユーザー エクスペリエンスの配慮の一例は、ゲームなどのアプリが起動時に導入シーケンスを表示する場合です。ユーザーがアプリに切り替えるまでそのシーケンスを遅らせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="21560-152">An example user experience consideration is that if you have an app, such as a game, that displays an introductory sequence when it is launched, you might delay the introductory sequence until the user switches to the app.</span></span>
    -   <span data-ttu-id="21560-153">パフォーマンスの配慮の一例は、アプリの事前起動時に最新の気象情報を読み込む場合です。ユーザーがアプリに切り替えるまでその読み込みを遅らせて、アプリが表示されたら最新の情報を読み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="21560-153">An example performance implication is that you might wait until the user switches to the app to retrieve the current weather information instead of loading it when the app is prelaunched and then need to load it again when the app becomes visible to ensure that the information is current.</span></span>
-   <span data-ttu-id="21560-154">アプリが起動時にライブ タイルをクリアする場合、表示の変更イベントが発生するまでこの操作の実行を遅らせてください。</span><span class="sxs-lookup"><span data-stu-id="21560-154">If your app clears its Live Tile when launched, defer doing this until the visibility changed event.</span></span>
-   <span data-ttu-id="21560-155">アプリの利用統計情報をタイルの通常のアクティブ化と事前起動時のアクティブ化で区別して、問題が発生する場合のシナリオを容易に絞り込めるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="21560-155">Telemetry for your app should distinguish between normal tile activations and prelaunch activations to make it easier to narrow down the scenario if problems occur.</span></span>
-   <span data-ttu-id="21560-156">Microsoft Visual の Studio2015 Update 1 と windows 10、バージョン 1511 では、ある場合をシミュレートできます事前起動の Visual Studio2015 でアプリの**デバッグ**を選択して&gt;**その他のデバッグ ターゲット** &gt; **Windows ユニバーサル アプリのデバッグ事前起動**します。</span><span class="sxs-lookup"><span data-stu-id="21560-156">If you have Microsoft Visual Studio2015 Update 1, and Windows10, Version 1511, you can simulate prelaunch for App your app in Visual Studio2015 by choosing **Debug** &gt; **Other Debug Targets** &gt; **Debug Windows Universal App PreLaunch**.</span></span>

## <a name="related-topics"></a><span data-ttu-id="21560-157">関連トピック</span><span class="sxs-lookup"><span data-stu-id="21560-157">Related topics</span></span>

* [<span data-ttu-id="21560-158">アプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="21560-158">App lifecycle</span></span>](app-lifecycle.md)
* [<span data-ttu-id="21560-159">CoreApplication.EnablePrelaunch</span><span class="sxs-lookup"><span data-stu-id="21560-159">CoreApplication.EnablePrelaunch</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx)
