---
author: TylerMSFT
title: アプリのアクティブ化の処理
description: OnLaunched メソッドをオーバーライドすることで、アプリのアクティブ化を処理する方法について説明します。
ms.assetid: DA9A6A43-F09D-4512-A2AB-9B6132431007
ms.author: twhitney
ms.date: 07/02/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
- vb
ms.openlocfilehash: 4d69680df1684da756219c180bbe6d47263801b9
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6980629"
---
# <a name="handle-app-activation"></a>アプリのアクティブ化の処理

[**Application.OnLaunched**](/uwp/api/windows.ui.xaml.application.onlaunched)メソッドをオーバーライドすることによってアプリのアクティブ化を処理する方法について説明します。

## <a name="override-the-launch-handler"></a>起動ハンドラーを上書きする

何らかの理由で、アプリがアクティブ化されるとき、システムは[**CoreApplicationView.Activated**](/uwp/api/windows.applicationmodel.core.coreapplicationview.activated)イベントを送信します。 アクティブ化の種類の一覧については、[**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693) 列挙型をご覧ください。

[**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) クラスで定義されているメソッドを上書きして、さまざまなアクティブ化の種類に対応することができます。 一部のアクティブ化の種類には、上書きできる専用のメソッドがあります。 それ以外のアクティブ化の種類では、[**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) メソッドを上書きします。

アプリのクラスを定義します。

```xml
<Application
    x:Class="AppName.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
```

[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドを上書きします。 このメソッドは、ユーザーがアプリを起動するたびに呼び出されます。 [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) パラメーターには、アプリの以前の状態とアクティブ化引数が含まれています。

> [!NOTE]
> Windows では、スタート画面のタイルまたはアプリの一覧から中断中のアプリを起動します。 このメソッドを呼び出すしません。

```csharp
using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace AppName
{
   public partial class App
   {
      async protected override void OnLaunched(LaunchActivatedEventArgs args)
      {
         EnsurePageCreatedAndActivate();
      }

      // Creates the MainPage if it isn't already created.  Also activates
      // the window so it takes foreground and input focus.
      private MainPage EnsurePageCreatedAndActivate()
      {
         if (Window.Current.Content == null)
         {
             Window.Current.Content = new MainPage();
         }

         Window.Current.Activate();
         return Window.Current.Content as MainPage;
      }
   }
}
```

```vb
Class App
   Protected Overrides Sub OnLaunched(args As LaunchActivatedEventArgs)
      Window.Current.Content = New MainPage()
      Window.Current.Activate()
   End Sub
End Class
```

```cppwinrt
...
#include "MainPage.h"
#include "winrt/Windows.ApplicationModel.Activation.h"
#include "winrt/Windows.UI.Xaml.h"
#include "winrt/Windows.UI.Xaml.Controls.h"
...
using namespace winrt;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;

struct App : AppT<App>
{
    App();

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    void OnLaunched(LaunchActivatedEventArgs const& e)
    {
        Frame rootFrame{ nullptr };
        auto content = Window::Current().Content();
        if (content)
        {
            rootFrame = content.try_as<Frame>();
        }

        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (rootFrame == nullptr)
        {
            // Create a Frame to act as the navigation context and associate it with
            // a SuspensionManager key
            rootFrame = Frame();

            rootFrame.NavigationFailed({ this, &App::OnNavigationFailed });

            if (e.PreviousExecutionState() == ApplicationExecutionState::Terminated)
            {
                // Restore the saved session state only when appropriate, scheduling the
                // final launch steps after the restore is complete
            }

            if (e.PrelaunchActivated() == false)
            {
                if (rootFrame.Content() == nullptr)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(xaml_typename<BlankApp1::MainPage>(), box_value(e.Arguments()));
                }
                // Place the frame in the current Window
                Window::Current().Content(rootFrame);
                // Ensure the current window is active
                Window::Current().Activate();
            }
        }
        else
        {
            if (e.PrelaunchActivated() == false)
            {
                if (rootFrame.Content() == nullptr)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(xaml_typename<BlankApp1::MainPage>(), box_value(e.Arguments()));
                }
                // Ensure the current window is active
                Window::Current().Activate();
            }
        }
    }
};
```

```cpp
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;
using namespace AppName;
void App::OnLaunched(LaunchActivatedEventArgs^ args)
{
   EnsurePageCreatedAndActivate();
}

// Creates the MainPage if it isn't already created.  Also activates
// the window so it takes foreground and input focus.
void App::EnsurePageCreatedAndActivate()
{
    if (_mainPage == nullptr)
    {
        // Save the MainPage for use if we get activated later
        _mainPage = ref new MainPage();
    }
    Window::Current->Content = _mainPage;
    Window::Current->Activate();
}
```

## <a name="restore-application-data-if-app-was-suspended-then-terminated"></a>アプリが一時停止後に終了された場合は、アプリケーション データを復元する

ユーザーが終了したアプリに切り替えると、システムは [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを送信します。このとき、[**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) は **Launch** に設定され、[**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) は **Terminated** または **ClosedByUser** に設定されます。 アプリでは、保存されているアプリ データを読み込み、表示されているコンテンツを更新する必要があります。

```csharp
async protected override void OnLaunched(LaunchActivatedEventArgs args)
{
   if (args.PreviousExecutionState == ApplicationExecutionState.Terminated ||
       args.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
   {
      // TODO: Populate the UI with the previously saved application data
   }
   else
   {
      // TODO: Populate the UI with defaults
   }

   EnsurePageCreatedAndActivate();
}
```

```vb
Protected Overrides Sub OnLaunched(args As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
   Dim restoreState As Boolean = False

   Select Case args.PreviousExecutionState
      Case ApplicationExecutionState.Terminated
         ' TODO: Populate the UI with the previously saved application data
         restoreState = True
      Case ApplicationExecutionState.ClosedByUser
         ' TODO: Populate the UI with the previously saved application data
         restoreState = True
      Case Else
         ' TODO: Populate the UI with defaults
   End Select

   Window.Current.Content = New MainPage(restoreState)
   Window.Current.Activate()
End Sub
```

```cppwinrt
void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs const& e)
{
    if (e.PreviousExecutionState() == ApplicationExecutionState::Terminated ||
        e.PreviousExecutionState() == ApplicationExecutionState::ClosedByUser)
    {
        // Populate the UI with the previously saved application data.
    }
    else
    {
        // Populate the UI with defaults.
    }
    ...
}
```

```cpp
void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ args)
{
   if (args->PreviousExecutionState == ApplicationExecutionState::Terminated ||
       args->PreviousExecutionState == ApplicationExecutionState::ClosedByUser)
   {
      // TODO: Populate the UI with the previously saved application data
   }
   else
   {
      // TODO: Populate the UI with defaults
   }

   EnsurePageCreatedAndActivate();
}
```

[**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) の値が **NotRunning** である場合は、アプリがアプリケーション データの保存に失敗しているため、初めて起動するときのように最初からアプリをやり直す必要があります。

## <a name="remarks"></a>解説

> [!NOTE]
> 現在のウィンドウにコンテンツ セットが既にある場合、アプリは初期化をスキップすることがあります。 プライマリまたはセカンダリ タイルから、アプリが起動されたかどうかを特定し、その情報に基づいて新しいを表示またはアプリのエクスペリエンスを再開する必要があるかどうかを決定する[**LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736)プロパティを確認することができます。

## <a name="important-apis"></a>重要な API
* [Windows.ApplicationModel.Activation](https://msdn.microsoft.com/library/windows/apps/br224766)
* [Windows.UI.Xaml.Application](https://msdn.microsoft.com/library/windows/apps/br242324)

## <a name="related-topics"></a>関連トピック
* [アプリの中断の処理](suspend-an-app.md)
* [アプリの再開の処理](resume-an-app.md)
* [アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [アプリのライフサイクル](app-lifecycle.md)
