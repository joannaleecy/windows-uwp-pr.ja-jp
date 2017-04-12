---
author: TylerMSFT
title: "アプリのアクティブ化の処理"
description: "OnLaunched メソッドをオーバーライドすることで、アプリのアクティブ化を処理する方法について説明します。"
ms.assetid: DA9A6A43-F09D-4512-A2AB-9B6132431007
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: f29396111ef11b23783e4bda79d621a1ae7a4d69
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="handle-app-activation"></a>アプリのアクティブ化の処理


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドをオーバーライドすることで、アプリのアクティブ化を処理する方法について説明します。

## <a name="override-the-launch-handler"></a>起動ハンドラーを上書きする

アプリがアクティブ化されると、その理由にかかわらず、システムから [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントが送信されます。 アクティブ化の種類の一覧については、[**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693) 列挙型をご覧ください。

[**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) クラスで定義されているメソッドを上書きして、さまざまなアクティブ化の種類に対応することができます。 一部のアクティブ化の種類には、上書きできる専用のメソッドがあります。 それ以外のアクティブ化の種類では、[**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) メソッドを上書きします。

アプリのクラスを定義します。

```xml
<Application xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             x:Class="AppName.App" >
```

[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドを上書きします。 このメソッドは、ユーザーがアプリを起動するたびに呼び出されます。 [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) パラメーターには、アプリの以前の状態とアクティブ化引数が含まれています。

**注**  Windows Phone ストア アプリでは、このメソッドは、ユーザーがスタート画面のタイルやアプリの一覧からアプリを起動するたびに呼び出されます (アプリが現在メモリ内で一時停止されている場合も含む)。 Windows では、スタート画面のタイルまたはアプリの一覧から中断中のアプリを起動するときに、このメソッドが呼び出されることはありません。

> [!div class="tabbedCodeSnippets"]
> ```cs
> using System;
> using Windows.ApplicationModel.Activation;
> using Windows.UI.Xaml;
>
> namespace AppName
> {
>    public partial class App
>    {
>       async protected override void OnLaunched(LaunchActivatedEventArgs args)
>       {
>          EnsurePageCreatedAndActivate();
>       }
>
>       // Creates the MainPage if it isn't already created.  Also activates
>       // the window so it takes foreground and input focus.
>       private MainPage EnsurePageCreatedAndActivate()
>       {
>          if (Window.Current.Content == null)
>          {
>              Window.Current.Content = new MainPage();
>          }
>
>          Window.Current.Activate();
>          return Window.Current.Content as MainPage;
>       }
>    }
> }
> ```
> ```vb
> Class App
>    Protected Overrides Sub OnLaunched(args As LaunchActivatedEventArgs)
>       Window.Current.Content = New MainPage()
>       Window.Current.Activate()
>    End Sub
> End Class
> ```
> ```cpp
> using namespace Windows::ApplicationModel::Activation;
> using namespace Windows::Foundation;
> using namespace Windows::UI::Xaml;
> using namespace AppName;
> void App::OnLaunched(LaunchActivatedEventArgs^ args)
> {
>    EnsurePageCreatedAndActivate();
> }
>
> // Creates the MainPage if it isn't already created.  Also activates
> // the window so it takes foreground and input focus.
> void App::EnsurePageCreatedAndActivate()
> {
>     if (_mainPage == nullptr)
>     {
>         // Save the MainPage for use if we get activated later
>         _mainPage = ref new MainPage();
>     }
>     Window::Current->Content = _mainPage;
>     Window::Current->Activate();
> }
> ```

## <a name="restore-application-data-if-app-was-suspended-then-terminated"></a>アプリが一時停止後に終了された場合は、アプリケーション データを復元する


ユーザーが終了したアプリに切り替えると、システムは [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを送信します。このとき、[**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) は **Launch** に設定され、[**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) は **Terminated** または **ClosedByUser** に設定されます。 アプリでは、保存されているアプリ データを読み込み、表示されているコンテンツを更新する必要があります。

> [!div class="tabbedCodeSnippets"]
> ```cs
> async protected override void OnLaunched(LaunchActivatedEventArgs args)
> {
>    if (args.PreviousExecutionState == ApplicationExecutionState.Terminated ||
>        args.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
>    {
>       // TODO: Populate the UI with the previously saved application data
>    }
>    else
>    {
>       // TODO: Populate the UI with defaults
>    }
>
>    EnsurePageCreatedAndActivate();
> }
> ```
> ```vb
> Protected Overrides Sub OnLaunched(args As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
>    Dim restoreState As Boolean = False
>
>    Select Case args.PreviousExecutionState
>       Case ApplicationExecutionState.Terminated
>          ' TODO: Populate the UI with the previously saved application data
>          restoreState = True
>       Case ApplicationExecutionState.ClosedByUser
>          ' TODO: Populate the UI with the previously saved application data
>          restoreState = True
>       Case Else
>          ' TODO: Populate the UI with defaults
>    End Select
>
>    Window.Current.Content = New MainPage(restoreState)
>    Window.Current.Activate()
> End Sub
> ```
> ```cpp
> void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ args)
> {
>    if (args->PreviousExecutionState == ApplicationExecutionState::Terminated ||
>        args->PreviousExecutionState == ApplicationExecutionState::ClosedByUser)
>    {
>       // TODO: Populate the UI with the previously saved application data
>    }
>    else
>    {
>       // TODO: Populate the UI with defaults
>    }
>
>    EnsurePageCreatedAndActivate();
> }
> ```

[**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) の値が **NotRunning** である場合は、アプリがアプリケーション データの保存に失敗しているため、初めて起動するときのように最初からアプリをやり直す必要があります。

## <a name="remarks"></a>解説

> **注**  Windows Phone ストア アプリでは、アプリが現在一時停止中で、ユーザーがプライマリ タイルまたはアプリの一覧からアプリを再起動した場合でも、[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントの後に、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) イベントが常に発生します。 現在のウィンドウにコンテンツ セットが既にある場合、アプリは初期化をスキップすることがあります。 [**LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736) プロパティをチェックすると、アプリがプライマリ タイルとセカンダリ タイルのどちらから起動されたかを調べ、その情報に基づいて新しいアプリ エクスペリエンスを表示するか、アプリ エクスペリエンスを再開するかを判断できます。

## <a name="related-topics"></a>関連トピック

* [アプリの中断の処理](suspend-an-app.md)
* [アプリの再開の処理](resume-an-app.md)
* [アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [アプリのライフサイクル](app-lifecycle.md)

**リファレンス**

* [**Windows.ApplicationModel.Activation**](https://msdn.microsoft.com/library/windows/apps/br224766)
* [**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324)

 

 
