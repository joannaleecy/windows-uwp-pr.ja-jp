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
# <a name="handle-app-prelaunch"></a>アプリの事前起動の処理

[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドをオーバーライドすることで、アプリの事前起動を処理する方法について説明します。

## <a name="introduction"></a>はじめに

利用可能なシステム リソースができるように、事前にバック グラウンドでのユーザーの最も頻繁に使うアプリを起動することによりデスクトップ デバイス ファミリのデバイス上の UWP アプリの起動時のパフォーマンスが向上しています。 事前起動されたアプリは起動直後に中断状態になります。 その後、ユーザーがアプリを呼び出すと、アプリは中断状態から実行状態に移って再開されます。これは、アプリのコールド スタートよりも高速です。 ユーザーのエクスペリエンスとしては、アプリが非常に短時間で起動するように感じられます。

Windows 10 より前では、アプリは自動的には事前起動を利用しませんでした。 Windows 10 バージョン 1511 では、すべてのユニバーサル Windows プラットフォーム (UWP) アプリが事前起動の候補をでした。 Windows 10 バージョン 1607 では、[CoreApplication.EnablePrelaunch(true)](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx) を呼び出すことで、事前起動の動作にオプトインする必要があります。 この呼び出しを配置する最適な場所は、`OnLaunched()` 内の `if (e.PrelaunchActivated == false)` チェックが実行される位置の近くです。

アプリが事前起動されるかどうかは、システム リソースに応じて決まります。 システムのリソースに負荷が掛かっている場合、アプリは事前起動されません。

アプリの種類によっては、事前起動を利用するために、起動の動作の変更が必要になる場合があります。 たとえば、起動時に音楽を再生するアプリ、ユーザーがオンラインであることを想定してアプリの起動時に凝ったビジュアルを表示するゲーム、起動時にユーザーのオンライン状態を変更するメッセージング アプリは、アプリが事前起動したことを識別し、以下の説明のとおり起動の動作を変更できます。

XAML プロジェクト (C#、VB、C++) と WinJS の既定のテンプレートは、Visual Studio 2015 Update 3 で事前起動に対応します。

## <a name="prelaunch-and-the-app-lifecycle"></a>事前起動とアプリのライフサイクル

アプリは、事前起動された後すぐに中断状態になります。 (「[アプリの中断の処理](suspend-an-app.md)」をご覧ください。)

## <a name="detect-and-handle-prelaunch"></a>事前起動の検出と処理

アプリはアクティブ化中に [**LaunchActivatedEventArgs.PrelaunchActivated**](https://msdn.microsoft.com/library/windows/apps/dn263740) フラグを受け取ります。 このフラグを使用する必要がありますのみを実行しているユーザーが明示的に、アプリを起動したとき[**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335)変更が次に示すようにコードを実行します。

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

注:、`TryEnablePrelaunch()`関数で、上記のします。 理由の呼び出しを`CoreApplication.EnablePrelaunch()`に関しては、この関数には、メソッドが呼び出されたとき (だけでコンパイル) JIT がしようとするとメソッド全体をコンパイルするためです。 アプリがサポートされていない Windows 10 のバージョンで実行されているかどうかは`CoreApplication.EnablePrelaunch()`、JIT は失敗します。 アプリをプラットフォームをサポートしているときにのみ呼び出されるメソッドの呼び出しを考慮することによって`CoreApplication.EnablePrelaunch()`、問題を回避します。

あるかどうか、アプリがオプトアウトする事前起動の場合、Windows 10 バージョン 1511 で実行されている必要がありますコメントを解除できます上記の例でコードがあります。 バージョン 1511 では、すべての UWP アプリが自動的にことを選んで場合に、事前起動されるできない可能性があるアプリに適したします。

## <a name="use-the-visibilitychanged-event"></a>VisibilityChanged イベントの使用

事前起動によってアクティブ化されたアプリはユーザーに対して表示されません。 ユーザーがそれらのアプリに切り替えると表示されます。 アプリのメイン ウィンドウが表示されるまで、特定の操作を遅らせることが必要になる場合があります。 たとえば、アプリによってフィードからの新着アイテムの一覧が表示される場合は、[**VisibilityChanged**](https://msdn.microsoft.com/library/windows/apps/hh702458) イベントの発生時に一覧を更新できます。アプリの事前起動時に生成された一覧は使いません。ユーザーがアプリをアクティブ化するまでに、その一覧が古くなっている可能性があるためです。 次のコードは、**MainPage** の **VisibilityChanged** イベントを処理します。

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

## <a name="directx-games-guidance"></a>DirectX ゲームのガイダンス

DirectX ゲームは、一般に、事前起動を有効にしないでください。多くの DirectX ゲームは、事前起動を検出できるより前に初期化を実行するためです。 Windows 1607 (Anniversary エディション) 以降では、ゲームは既定で事前起動されません。  ゲームで事前起動を利用する必要がある場合は、[CoreApplication.EnablePrelaunch(true)](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx) を呼び出します。

以前のバージョンの Windows 10 をターゲットとするゲームでは、事前起動の条件を処理してアプリケーションを終了することができます。

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

## <a name="winjs-app-guidance"></a>WinJS アプリのガイダンス

以前のバージョンの Windows 10 をターゲットとする WinJS アプリでは、[onactivated](https://msdn.microsoft.com/library/windows/apps/br212679.aspx) ハンドラー内で事前起動の条件を処理することができます。

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

## <a name="general-guidance"></a>一般的なガイダンス

-   長時間かかる操作を、アプリが事前起動時に実行しないようにしてください。アプリはすぐに中断状態に移れない場合に終了するためです。
-   アプリが事前起動された場合、アプリは [**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) からオーディオの再生を開始しません。アプリは表示されず、オーディオ再生が行われる理由がはっきりしないためです。
-   アプリがユーザーに表示されていることを前提とした操作やユーザーによって明示的に起動されたことを前提とした操作を、アプリが事前起動時に実行しないようにしてください。 アプリはユーザーによる明示的な操作なしにバックグラウンドで起動できるようになったため、開発者はプライバシー、ユーザー エクスペリエンス、パフォーマンスへの影響を配慮する必要があります。
    -   プライバシーの配慮の一例は、ソーシャル アプリがユーザーの状態をオンラインに変更する場合です。 アプリの事前起動時に状態を変更せずに、ユーザーがそのアプリに切り替えるまで待機する必要があります。
    -   ユーザー エクスペリエンスの配慮の一例は、ゲームなどのアプリが起動時に導入シーケンスを表示する場合です。ユーザーがアプリに切り替えるまでそのシーケンスを遅らせる必要があります。
    -   パフォーマンスの配慮の一例は、アプリの事前起動時に最新の気象情報を読み込む場合です。ユーザーがアプリに切り替えるまでその読み込みを遅らせて、アプリが表示されたら最新の情報を読み込む必要があります。
-   アプリが起動時にライブ タイルをクリアする場合、表示の変更イベントが発生するまでこの操作の実行を遅らせてください。
-   アプリの利用統計情報をタイルの通常のアクティブ化と事前起動時のアクティブ化で区別して、問題が発生する場合のシナリオを容易に絞り込めるようにしてください。
-   Microsoft Visual の Studio2015 Update 1 と windows 10、バージョン 1511 では、ある場合をシミュレートできます事前起動の Visual Studio2015 でアプリの**デバッグ**を選択して&gt;**その他のデバッグ ターゲット** &gt; **Windows ユニバーサル アプリのデバッグ事前起動**します。

## <a name="related-topics"></a>関連トピック

* [アプリのライフサイクル](app-lifecycle.md)
* [CoreApplication.EnablePrelaunch](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx)
