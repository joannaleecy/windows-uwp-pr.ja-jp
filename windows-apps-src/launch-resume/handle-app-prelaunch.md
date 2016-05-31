---
author: mcleblanc
title: アプリの事前起動の処理
description: OnLaunched メソッドをオーバーライドすることで、アプリの事前起動を処理する方法について説明します。
ms.assetid: A4838AC2-22D7-46BA-9EB2-F3C248E22F52
---

# アプリの事前起動の処理


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335)

[
            **OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドをオーバーライドすることで、アプリの事前起動を処理する方法について説明します。

## はじめに


システム リソースが許す限り、ユーザーの最も頻繁に使うアプリを事前にバックグラウンドで起動することで、Windows ストア アプリの起動時のパフォーマンスが向上します。 事前起動されたアプリは起動直後に中断状態になります。 ユーザーがアプリを呼び出すと、アプリは中断状態から実行状態に移って再開されます。これは、アプリのコールド スタートよりも高速です。

Windows 10 より前では、アプリは自動的には事前起動を利用しませんでした。 Windows 10 以降、すべてのユニバーサル Windows プラットフォーム (UWP) アプリは自動的に事前起動を利用します。

ほとんどのアプリでは、事前起動を利用するための変更は不要です。 ただしアプリの種類によっては、事前起動を利用するために、起動動作の変更が必要になる場合があります。 たとえば、起動時にユーザーのオンライン状態を変更するメッセージング アプリや、ユーザーがオンラインであることを想定してアプリの起動時に凝ったビジュアルを表示するゲームです。

## 事前起動とアプリのライフ サイクル


アプリは事前起動されると、すぐに中断状態になります ([アプリの中断の処理](suspend-an-app.md)」をご覧ください。)

## 事前起動の検出と処理


アプリはアクティブ化中に [**LaunchActivatedEventArgs.PrelaunchActivated**](https://msdn.microsoft.com/library/windows/apps/dn263740) フラグを受け取ります。 このフラグを使って、ユーザーによって明示的にアプリが起動されたときにのみ行う操作を実行するかどうかを調べます (次の [**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) からの抜粋をご覧ください。

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

**ヒント**  事前起動を除外する場合は、[**LaunchActivatedEventArgs.PrelaunchActivated**](https://msdn.microsoft.com/library/windows/apps/dn263740) フラグを確認します。 設定されていれば、フレームの作成やウィンドウのアクティブ化を行うための操作を実行する前に、OnLaunched() から復帰します。

 

## VisibilityChanged イベントの使用


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

## ガイダンス


-   長時間かかる操作を、アプリが事前起動時に実行しないようにしてください。アプリはすぐに中断状態に移れない場合に終了するためです。
-   アプリが事前起動された場合、アプリは [**Application.OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) からオーディオの再生を開始しません。アプリは表示されず、オーディオ再生が行われる理由がはっきりしないためです。
-   アプリがユーザーに表示されていることを前提とした操作やユーザーによって明示的に起動されたことを前提とした操作を、アプリが事前起動時に実行しないようにしてください。 アプリはユーザーによる明示的な操作なしにバックグラウンドで起動できるようになったため、開発者はプライバシー、ユーザー エクスペリエンス、パフォーマンスへの影響を配慮する必要があります。
    -   プライバシーの配慮の一例は、ソーシャル アプリがユーザーの状態をオンラインに変更する場合です。 アプリの事前起動時に状態を変更せずに、ユーザーがそのアプリに切り替えるまで待機する必要があります。
    -   ユーザー エクスペリエンスの配慮の一例は、ゲームなどのアプリが起動時に導入シーケンスを表示する場合です。ユーザーがアプリに切り替えるまでそのシーケンスを遅らせる必要があります。
    -   パフォーマンスの配慮の一例は、アプリの事前起動時に最新の気象情報を読み込む場合です。ユーザーがアプリに切り替えるまでその読み込みを遅らせて、アプリが表示されたら最新の情報を読み込む必要があります。
-   アプリが事前起動時にライブ タイルをクリアする場合、表示の変更イベントが発生するまでこの操作を遅らせてください。
-   アプリの利用統計情報をタイルの通常のアクティブ化と起動前のアクティブ化で区別して、問題が発生するシナリオを特定できるようにしてください。
-   Microsoft Visual Studio 2015 Update 1 および Windows 10 Version 1511 がインストールされている場合、**[デバッグ]** &gt; **[その他のデバッグ ターゲット]** &gt; **[Debug Windows Universal App PreLaunch]** の順に選ぶことで、Microsoft Visual Studio 2015 でアプリの事前起動をシミュレートできます。

## 関連トピック

* [アプリのライフサイクル](app-lifecycle.md)

 

 





<!--HONumber=May16_HO2-->


