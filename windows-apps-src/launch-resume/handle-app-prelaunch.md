---
author: TylerMSFT
title: "アプリの事前起動の処理"
description: "OnLaunched メソッドをオーバーライドし、CoreApplication.EnablePrelaunch(true) を呼び出すことで、アプリの事前起動を処理する方法について説明します。"
ms.assetid: A4838AC2-22D7-46BA-9EB2-F3C248E22F52
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 6107fe07fc8e98db7d197354246784a31a9c902c
ms.lasthandoff: 02/07/2017

---

# <a name="handle-app-prelaunch"></a>アプリの事前起動の処理

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドをオーバーライドすることで、アプリの事前起動を処理する方法について説明します。

## <a name="introduction"></a>はじめに

システム リソースが許す限り、ユーザーの最も頻繁に使うアプリを事前にバックグラウンドで起動することで、デスクトップ デバイス ファミリのデバイスにおける Windows ストア アプリの起動時のパフォーマンスが向上します。 事前起動されたアプリは起動直後に中断状態になります。 その後、ユーザーがアプリを呼び出すと、アプリは中断状態から実行状態に移って再開されます。これは、アプリのコールド スタートよりも高速です。 ユーザーのエクスペリエンスとしては、アプリが非常に短時間で起動するように感じられます。

Windows 10 より前では、アプリは自動的には事前起動を利用しませんでした。 Windows 10 バージョン 1511 では、すべてのユニバーサル Windows プラットフォーム (UWP) アプリが、事前起動の候補でした。 Windows 10 バージョン 1607 では、[CoreApplication.EnablePrelaunch(true)](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx) を呼び出すことで、事前起動の動作にオプトインする必要があります。 この呼び出しを配置する最適な場所は、`OnLaunched()` 内の `if (e.PrelaunchActivated == false)` チェックが実行される位置の近くです。

アプリが事前起動されるかどうかは、システム リソースに応じて決まります。 システムのリソースに負荷が掛かっている場合、アプリは事前起動されません。

アプリの種類によっては、事前起動を利用するために、起動の動作の変更が必要になる場合があります。 たとえば、起動時に音楽を再生するアプリ、ユーザーがオンラインであることを想定してアプリの起動時に凝ったビジュアルを表示するゲーム、起動時にユーザーのオンライン状態を変更するメッセージング アプリは、アプリが事前起動したことを識別し、以下の説明のとおり起動の動作を変更できます。

XAML プロジェクト (C#、VB、C++) と WinJS の既定のテンプレートは、Visual Studio 2015 Update 3 で事前起動に対応します。

## <a name="prelaunch-and-the-app-lifecycle"></a>事前起動とアプリのライフサイクル

アプリは、事前起動された後すぐに中断状態になります。 (「[アプリの中断の処理](suspend-an-app.md)」をご覧ください。)

## <a name="detect-and-handle-prelaunch"></a>事前起動の検出と処理

アプリはアクティブ化中に [**LaunchActivatedEventArgs.PrelaunchActivated**](https://msdn.microsoft.com/library/windows/apps/dn263740) フラグを受け取ります。 このフラグを使うと、ユーザーが明示的にアプリを起動した場合にのみ実行されるコードを実行することができます。[**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) からの次の抜粋に示されているとおりです。

```cs
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;

    // Do not repeat app initialization when the Window already has content - rather just ensure that the window is active
    if (rootFrame == null)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }

        if (!e.PrelaunchActivated)
        {
            // TODO: This is not a prelaunch activation. Perform operations which
            // assume that the user explicitly launched the app such as updating
            // the online presence of the user on a social network, updating a
            // what's new feed, etc.
        }

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
    }

    if (rootFrame.Content == null)
    {
        // When the navigation stack isn't restored navigate to the first page,
        // configuring the new page by passing required information as a navigation parameter
        rootFrame.Navigate(typeof(MainPage), e.Arguments);
    }
    // Ensure the current window is active
    Window.Current.Activate();
}
```

**ヒント**  Windows 10 のバージョン 1607 より前のバージョンをターゲットとしている場合に、事前起動からオプトアウトするには、[**LaunchActivatedEventArgs.PrelaunchActivated**](https://msdn.microsoft.com/library/windows/apps/dn263740) フラグを確認します。 設定されていれば、フレームの作成やウィンドウのアクティブ化を行うための操作を実行する前に、OnLaunched() から復帰します。

## <a name="use-the-visibilitychanged-event"></a>VisibilityChanged イベントの使用

事前起動によってアクティブ化されたアプリはユーザーに対して表示されません。 ユーザーがそれらのアプリに切り替えると表示されます。 アプリのメイン ウィンドウが表示されるまで、特定の操作を遅らせることが必要になる場合があります。 たとえば、アプリによってフィードからの新着アイテムの一覧が表示される場合は、[**VisibilityChanged**](https://msdn.microsoft.com/library/windows/apps/hh702458) イベントの発生時に一覧を更新できます。アプリの事前起動時に生成された一覧は使いません。ユーザーがアプリをアクティブ化するまでに、その一覧が古くなっている可能性があるためです。 次のコードは、**MainPage** の **VisibilityChanged** イベントを処理します。

```cs
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

```cs
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

```js
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
-   Microsoft Visual Studio 2015 Update 1 および Windows 10 バージョン 1511 がインストールされている場合、**[デバッグ]** &gt; **[その他のデバッグ ターゲット]** &gt; **[Windows ユニバーサルアプリ事前起動のデバッグ]** の順に選ぶことで、Visual Studio 2015 でアプリの事前起動をシミュレートできます。

## <a name="related-topics"></a>関連トピック

* [アプリのライフサイクル](app-lifecycle.md)
* [CoreApplication.EnablePrelaunch](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.core.coreapplication.enableprelaunch.aspx)

