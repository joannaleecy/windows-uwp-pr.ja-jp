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
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5947563"
---
# <a name="handle-app-activation"></a><span data-ttu-id="86033-104">アプリのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="86033-104">Handle app activation</span></span>

<span data-ttu-id="86033-105">[**Application.OnLaunched**](/uwp/api/windows.ui.xaml.application.onlaunched)メソッドをオーバーライドして、アプリのアクティブ化を処理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="86033-105">Learn how to handle app activation by overriding the [**Application.OnLaunched**](/uwp/api/windows.ui.xaml.application.onlaunched) method.</span></span>

## <a name="override-the-launch-handler"></a><span data-ttu-id="86033-106">起動ハンドラーを上書きする</span><span class="sxs-lookup"><span data-stu-id="86033-106">Override the launch handler</span></span>

<span data-ttu-id="86033-107">何らかの理由で、アプリがアクティブ化されるとき、システムは[**CoreApplicationView.Activated**](/uwp/api/windows.applicationmodel.core.coreapplicationview.activated)イベントを送信します。</span><span class="sxs-lookup"><span data-stu-id="86033-107">When an app is activated, for any reason, the system sends the [**CoreApplicationView.Activated**](/uwp/api/windows.applicationmodel.core.coreapplicationview.activated) event.</span></span> <span data-ttu-id="86033-108">アクティブ化の種類の一覧については、[**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693) 列挙型をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="86033-108">For a list of activation types, see the [**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693) enumeration.</span></span>

<span data-ttu-id="86033-109">[**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) クラスで定義されているメソッドを上書きして、さまざまなアクティブ化の種類に対応することができます。</span><span class="sxs-lookup"><span data-stu-id="86033-109">The [**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) class defines methods you can override to handle the various activation types.</span></span> <span data-ttu-id="86033-110">一部のアクティブ化の種類には、上書きできる専用のメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="86033-110">Several of the activation types have a specific method that you can override.</span></span> <span data-ttu-id="86033-111">それ以外のアクティブ化の種類では、[**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) メソッドを上書きします。</span><span class="sxs-lookup"><span data-stu-id="86033-111">For the other activation types, override the [**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) method.</span></span>

<span data-ttu-id="86033-112">アプリのクラスを定義します。</span><span class="sxs-lookup"><span data-stu-id="86033-112">Define the class for your application.</span></span>

```xml
<Application
    x:Class="AppName.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
```

<span data-ttu-id="86033-113">[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドを上書きします。</span><span class="sxs-lookup"><span data-stu-id="86033-113">Override the [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) method.</span></span> <span data-ttu-id="86033-114">このメソッドは、ユーザーがアプリを起動するたびに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="86033-114">This method is called whenever the user launches the app.</span></span> <span data-ttu-id="86033-115">[**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) パラメーターには、アプリの以前の状態とアクティブ化引数が含まれています。</span><span class="sxs-lookup"><span data-stu-id="86033-115">The [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) parameter contains the previous state of your app and the activation arguments.</span></span>

> [!NOTE]
> <span data-ttu-id="86033-116">Windows では、スタート画面のタイルまたはアプリの一覧から中断中のアプリを起動します。 このメソッドを呼び出すしません。</span><span class="sxs-lookup"><span data-stu-id="86033-116">On Windows, launching a suspended app from Start tile or app list doesn't call this method.</span></span>

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

## <a name="restore-application-data-if-app-was-suspended-then-terminated"></a><span data-ttu-id="86033-117">アプリが一時停止後に終了された場合は、アプリケーション データを復元する</span><span class="sxs-lookup"><span data-stu-id="86033-117">Restore application data if app was suspended then terminated</span></span>

<span data-ttu-id="86033-118">ユーザーが終了したアプリに切り替えると、システムは [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを送信します。このとき、[**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) は **Launch** に設定され、[**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) は **Terminated** または **ClosedByUser** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="86033-118">When the user switches to your terminated app, the system sends the [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) event, with [**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) set to **Launch** and [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) set to **Terminated** or **ClosedByUser**.</span></span> <span data-ttu-id="86033-119">アプリでは、保存されているアプリ データを読み込み、表示されているコンテンツを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="86033-119">The app should load its saved application data and refresh its displayed content.</span></span>

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

<span data-ttu-id="86033-120">[**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) の値が **NotRunning** である場合は、アプリがアプリケーション データの保存に失敗しているため、初めて起動するときのように最初からアプリをやり直す必要があります。</span><span class="sxs-lookup"><span data-stu-id="86033-120">If the value of [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) is **NotRunning**, the app failed to save its application data successfully and the app should start over as if it were being initially launched.</span></span>

## <a name="remarks"></a><span data-ttu-id="86033-121">解説</span><span class="sxs-lookup"><span data-stu-id="86033-121">Remarks</span></span>

> [!NOTE]
> <span data-ttu-id="86033-122">現在のウィンドウにコンテンツ セットが既にある場合、アプリは初期化をスキップすることがあります。</span><span class="sxs-lookup"><span data-stu-id="86033-122">Apps can skip initialization if there is already content set on the current window.</span></span> <span data-ttu-id="86033-123">プライマリまたはセカンダリ タイルから、アプリが起動されたかどうかを判断し、新しいを表示またはアプリのエクスペリエンスを再開する必要があるかどうか、その情報に基づいて決定[**LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736)プロパティを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="86033-123">You can check the [**LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736) property to determine whether the app was launched from a primary or a secondary tile and, based on that information, decide whether you should present a fresh or resume app experience.</span></span>

## <a name="important-apis"></a><span data-ttu-id="86033-124">重要な API</span><span class="sxs-lookup"><span data-stu-id="86033-124">Important APIs</span></span>
* [<span data-ttu-id="86033-125">Windows.ApplicationModel.Activation</span><span class="sxs-lookup"><span data-stu-id="86033-125">Windows.ApplicationModel.Activation</span></span>](https://msdn.microsoft.com/library/windows/apps/br224766)
* [<span data-ttu-id="86033-126">Windows.UI.Xaml.Application</span><span class="sxs-lookup"><span data-stu-id="86033-126">Windows.UI.Xaml.Application</span></span>](https://msdn.microsoft.com/library/windows/apps/br242324)

## <a name="related-topics"></a><span data-ttu-id="86033-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="86033-127">Related topics</span></span>
* [<span data-ttu-id="86033-128">アプリの中断の処理</span><span class="sxs-lookup"><span data-stu-id="86033-128">Handle app suspend</span></span>](suspend-an-app.md)
* [<span data-ttu-id="86033-129">アプリの再開の処理</span><span class="sxs-lookup"><span data-stu-id="86033-129">Handle app resume</span></span>](resume-an-app.md)
* [<span data-ttu-id="86033-130">アプリの中断と再開のガイドライン</span><span class="sxs-lookup"><span data-stu-id="86033-130">Guidelines for app suspend and resume</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [<span data-ttu-id="86033-131">アプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="86033-131">App lifecycle</span></span>](app-lifecycle.md)
