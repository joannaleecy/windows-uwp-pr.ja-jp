---
Description: 旧バージョンと、UWP アプリ内で、ユーザーのナビゲーション履歴を通過するためのナビゲーションを実装する方法について説明します。
title: ナビゲーション履歴と前に戻る移動 (Windows アプリ)
template: detail.hbs
op-migration-status: ready
ms.date: 06/21/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: c74d4ebd08dfeddfb4a0149cffcd7bb845ceff11
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595047"
---
# <a name="navigation-history-and-backwards-navigation-for-uwp-apps"></a><span data-ttu-id="cf457-104">UWP アプリのナビゲーション履歴と前に戻る移動</span><span class="sxs-lookup"><span data-stu-id="cf457-104">Navigation history and backwards navigation for UWP apps</span></span>

> <span data-ttu-id="cf457-105">**重要な API**:[BackRequested イベント](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager.BackRequested)、 [SystemNavigationManager クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager)、 [OnNavigatedTo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_)</span><span class="sxs-lookup"><span data-stu-id="cf457-105">**Important APIs**: [BackRequested event](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager.BackRequested), [SystemNavigationManager class](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager), [OnNavigatedTo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_)</span></span>

<span data-ttu-id="cf457-106">ユニバーサル Windows プラットフォーム (UWP) では、アプリのユーザーのナビゲーションの履歴内の移動や、デバイスによってはアプリ間の移動について、一貫性のある "戻る" ナビゲーション システムを提供します。</span><span class="sxs-lookup"><span data-stu-id="cf457-106">The Universal Windows Platform (UWP) provides a consistent back navigation system for traversing the user's navigation history within an app and, depending on the device, from app to app.</span></span>

<span data-ttu-id="cf457-107">アプリに前に戻る移動を実装するには、アプリの UI の左上隅に[戻るボタン](#Back-button)を配置します。</span><span class="sxs-lookup"><span data-stu-id="cf457-107">To implement backwards navigation in your app, place a [back button](#Back-button) at the top left corner of your app's UI.</span></span> <span data-ttu-id="cf457-108">アプリで [NavigationView](../controls-and-patterns/navigationview.md) コントロールを使用する場合は、[NavigationView の組み込みの戻るボタン](../controls-and-patterns/navigationview.md#backwards-navigation)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="cf457-108">If your app uses the [NavigationView](../controls-and-patterns/navigationview.md) control, then you can use [NavigationView's built-in back button](../controls-and-patterns/navigationview.md#backwards-navigation).</span></span>

<span data-ttu-id="cf457-109">ユーザーは、戻るボタンによって、アプリのナビゲーション履歴における前の場所に戻ることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="cf457-109">The user expects the back button to navigate to the previous location in the app's navigation history.</span></span> <span data-ttu-id="cf457-110">ナビゲーション履歴に追加するナビゲーション操作の種類、および戻るボタンが押されたときの応答方法は、自由に決めることができます。</span><span class="sxs-lookup"><span data-stu-id="cf457-110">Note that it's up to you to decide which navigation actions to add to the navigation history and how to respond to the back button press.</span></span>

## <a name="back-button"></a><span data-ttu-id="cf457-111">[戻る] ボタン</span><span class="sxs-lookup"><span data-stu-id="cf457-111">Back button</span></span>

<span data-ttu-id="cf457-112">[戻る] ボタンを作成するには、使用、[ボタン](../controls-and-patterns/buttons.md)コントロールを`NavigationBackButtonNormalStyle`スタイル、およびアプリの UI の左上隅にあるボタンを配置する (詳細については、次の XAML コードの例を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="cf457-112">To create a back button, use the [Button](../controls-and-patterns/buttons.md) control with the `NavigationBackButtonNormalStyle` style, and place the button at the top left hand corner of your app's UI (for details, see the XAML code examples below).</span></span>

![アプリの UI の左上隅にある [戻る] ボタン](images/back-nav/BackEnabled.png)

```xaml
<Button Style="{StaticResource NavigationBackButtonNormalStyle}"/>
```

<span data-ttu-id="cf457-114">アプリに上部 [CommandBar](../controls-and-patterns/app-bars.md) がある場合、高さ 44px の Button コントロールは 48px の AppBarButtons とはぴったり合いません。</span><span class="sxs-lookup"><span data-stu-id="cf457-114">If your app has a top [CommandBar](../controls-and-patterns/app-bars.md), the Button control that is 44px in height will not align with 48px AppBarButtons very nicely.</span></span> <span data-ttu-id="cf457-115">不整合を避けるために、Button コントロールの最上部を 48px の境界内部に合わせてください。</span><span class="sxs-lookup"><span data-stu-id="cf457-115">However, to avoid inconsistency, align the top of the Button control inside the 48px bounds.</span></span>

![上部のコマンド バーの [戻る] ボタン](images/back-nav/CommandBar.png)

```xaml
<Button VerticalAlignment="Top" HorizontalAlignment="Left" 
Style="{StaticResource NavigationBackButtonNormalStyle}"/>
```

<span data-ttu-id="cf457-117">アプリ内で動き回る UI 要素を最小化するために、バックスタックに何もないときに、無効になった戻るボタンを表示します (以下のコード例を参照)。</span><span class="sxs-lookup"><span data-stu-id="cf457-117">In order to minimize UI elements moving around in your app, show a disabled back button when there is nothing in the backstack (see code example below).</span></span> <span data-ttu-id="cf457-118">ただし、アプリは、バック スタックを持つことがない場合は、[戻る] ボタンを表示する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="cf457-118">However, if you expect your app will never have a backstack, you don’t need to display the back button at all.</span></span>

![[戻る] ボタンの状態](images/back-nav/BackDisabled.png)

## <a name="code-example"></a><span data-ttu-id="cf457-120">コードの例</span><span class="sxs-lookup"><span data-stu-id="cf457-120">Code example</span></span>

<span data-ttu-id="cf457-121">次のコード例は、戻るボタンで前に戻る移動の動作を実装する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="cf457-121">The following code example demonstrates how to implement backwards navigation behavior with a back button.</span></span> <span data-ttu-id="cf457-122">このコードでは、Button の [**Click**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.Click) イベントに応答し、新しいページに移動したときに呼び出される [**OnNavigatedTo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_) でボタンの表示を無効/有効にします。</span><span class="sxs-lookup"><span data-stu-id="cf457-122">The code responds to the Button [**Click**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.Click) event and disables/enables the button visibility in [**OnNavigatedTo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_), which is called when navigating to a new page.</span></span> <span data-ttu-id="cf457-123">このコード例では、[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested) イベントのリスナーを登録することで、ハードウェアおよびソフトウェア システムの戻るキーからの入力も処理しています。</span><span class="sxs-lookup"><span data-stu-id="cf457-123">The code example also handles inputs from hardware and software system back keys by registering a listener for the [**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested) event.</span></span>

```xaml
<!-- MainPage.xaml -->
<Page x:Class="AppName.MainPage">
...
<Button x:Name="BackButton" Click="Back_Click" Style="{StaticResource NavigationBackButtonNormalStyle}"/>
...
<Page/>
```

<span data-ttu-id="cf457-124">分離コード:</span><span class="sxs-lookup"><span data-stu-id="cf457-124">Code-behind:</span></span>

```csharp
// MainPage.xaml.cs
public MainPage()
{
    KeyboardAccelerator GoBack = new KeyboardAccelerator();
    GoBack.Key = VirtualKey.GoBack;
    GoBack.Invoked += BackInvoked;
    KeyboardAccelerator AltLeft = new KeyboardAccelerator();
    AltLeft.Key = VirtualKey.Left;
    AltLeft.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(GoBack);
    this.KeyboardAccelerators.Add(AltLeft);
    // ALT routes here
    AltLeft.Modifiers = VirtualKeyModifiers.Menu;
}

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    BackButton.IsEnabled = this.Frame.CanGoBack;
}

private void Back_Click(object sender, RoutedEventArgs e)
{
    On_BackRequested();
}

// Handles system-level BackRequested events and page-level back button Click events
private bool On_BackRequested()
{
    if (this.Frame.CanGoBack)
    {
        this.Frame.GoBack();
        return true;
    }
    return false;
}

private void BackInvoked (KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
{
    On_BackRequested();
    args.Handled = true;
}
```

```cppwinrt
// MainPage.cpp
#include "pch.h"
#include "MainPage.h"

#include "winrt/Windows.System.h"
#include "winrt/Windows.UI.Xaml.Controls.h"
#include "winrt/Windows.UI.Xaml.Input.h"
#include "winrt/Windows.UI.Xaml.Navigation.h"

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;

namespace winrt::PageNavTest::implementation
{
    MainPage::MainPage()
    {
        InitializeComponent();

        Windows::UI::Xaml::Input::KeyboardAccelerator goBack;
        goBack.Key(Windows::System::VirtualKey::GoBack);
        goBack.Invoked({ this, &MainPage::BackInvoked });
        Windows::UI::Xaml::Input::KeyboardAccelerator altLeft;
        altLeft.Key(Windows::System::VirtualKey::Left);
        altLeft.Invoked({ this, &MainPage::BackInvoked });
        KeyboardAccelerators().Append(goBack);
        KeyboardAccelerators().Append(altLeft);
        // ALT routes here.
        altLeft.Modifiers(Windows::System::VirtualKeyModifiers::Menu);
    }

    void MainPage::OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs const& e)
    {
        BackButton().IsEnabled(Frame().CanGoBack());
    }

    void MainPage::Back_Click(IInspectable const&, RoutedEventArgs const&)
    {
        On_BackRequested();
    }

    // Handles system-level BackRequested events and page-level back button Click events.
    bool MainPage::On_BackRequested()
    {
        if (Frame().CanGoBack())
        {
            Frame().GoBack();
            return true;
        }
        return false;
    }

    void MainPage::BackInvoked(Windows::UI::Xaml::Input::KeyboardAccelerator const& sender,
        Windows::UI::Xaml::Input::KeyboardAcceleratorInvokedEventArgs const& args)
    {
        args.Handled(On_BackRequested());
    }
}
```

<span data-ttu-id="cf457-125">上記の単一ページ ナビゲーションを処理内を後方に向かってします。</span><span class="sxs-lookup"><span data-stu-id="cf457-125">Above, we handle backwards navigation for a single page.</span></span> <span data-ttu-id="cf457-126">戻るナビゲーションで、特定のページを除外するか、ページを表示する前にページ レベルのコードを実行する場合は、各ページのナビゲーションを処理できます。</span><span class="sxs-lookup"><span data-stu-id="cf457-126">You can handle navigation in each page if you want to exclude specific pages from back navigation, or you want to execute page-level code before displaying the page.</span></span>

<span data-ttu-id="cf457-127">旧バージョンとアプリ全体のナビゲーションを処理するためのグローバルのリスナーを登録します、 [ **BackRequested** ](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested)内のイベント、`App.xaml`分離コード ファイル。</span><span class="sxs-lookup"><span data-stu-id="cf457-127">To handle backwards navigation for an entire app, you'll register a global listener for the [**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested) event in the `App.xaml` code-behind file.</span></span>

<span data-ttu-id="cf457-128">App.xaml 分離コード:</span><span class="sxs-lookup"><span data-stu-id="cf457-128">App.xaml code-behind:</span></span>

```csharp
// App.xaml.cs
Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
Frame rootFrame = Window.Current.Content;
rootFrame.PointerPressed += On_PointerPressed;

private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
{
    e.Handled = On_BackRequested();
}

private void On_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    bool isXButton1Pressed =
        e.GetCurrentPoint(sender as UIElement).Properties.PointerUpdateKind == PointerUpdateKind.XButton1Pressed;

    if (isXButton1Pressed)
    {
        e.Handled = On_BackRequested();
    }
}

private bool On_BackRequested()
{
    Frame rootFrame = Window.Current.Content as Frame;
    if (rootFrame.CanGoBack)
    {
        rootFrame.GoBack();
        return true;
    }
    return false;
}
```

```cppwinrt
// App.cpp
#include <winrt/Windows.UI.Core.h>
#include "winrt/Windows.UI.Input.h"
#include "winrt/Windows.UI.Xaml.Input.h"

#include "App.h"
#include "MainPage.h"

using namespace winrt;
...

    Windows::UI::Core::SystemNavigationManager::GetForCurrentView().BackRequested({ this, &App::App_BackRequested });
    Frame rootFrame{ nullptr };
    auto content = Window::Current().Content();
    if (content)
    {
        rootFrame = content.try_as<Frame>();
    }
    rootFrame.PointerPressed({ this, &App::On_PointerPressed });
...

void App::App_BackRequested(IInspectable const& /* sender */, Windows::UI::Core::BackRequestedEventArgs const& e)
{
    e.Handled(On_BackRequested());
}

void App::On_PointerPressed(IInspectable const& sender, Windows::UI::Xaml::Input::PointerRoutedEventArgs const& e)
{
    bool isXButton1Pressed =
        e.GetCurrentPoint(sender.as<UIElement>()).Properties().PointerUpdateKind() == Windows::UI::Input::PointerUpdateKind::XButton1Pressed;

    if (isXButton1Pressed)
    {
        e.Handled(On_BackRequested());
    }
}

// Handles system-level BackRequested events.
bool App::On_BackRequested()
{
    if (Frame().CanGoBack())
    {
        Frame().GoBack();
        return true;
    }
    return false;
}
```

## <a name="optimizing-for-different-device-and-form-factors"></a><span data-ttu-id="cf457-129">さまざまなデバイスとフォーム ファクター向けに最適化</span><span class="sxs-lookup"><span data-stu-id="cf457-129">Optimizing for different device and form factors</span></span>

<span data-ttu-id="cf457-130">この前に戻る移動の設計ガイダンスはすべてのデバイスに適用可能ですが、最適化によってさまざまなデバイスとフォーム ファクターに適したものになります。</span><span class="sxs-lookup"><span data-stu-id="cf457-130">This backwards navigation design guidance is applicable to all devices, but different device and form factors may benefit from optimization.</span></span> <span data-ttu-id="cf457-131">これは、さまざまなシェルでサポートされているハードウェアの戻るボタンによっても変わります。</span><span class="sxs-lookup"><span data-stu-id="cf457-131">This also depends on the hardware back button supported by different shells.</span></span>

- <span data-ttu-id="cf457-132">**電話やタブレット**:ハードウェアまたはソフトウェアの戻るボタンは、常にモバイルに存在して、タブレット、ですがは、わかりやすくするために、アプリの戻るボタンを描画することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cf457-132">**Phone/Tablet**: A hardware or software back button is always present on mobile and tablet, but we recommend drawing an in-app back button for clarity.</span></span>
- <span data-ttu-id="cf457-133">**デスクトップ/ハブ**:アプリの UI の左上隅で、アプリで [戻る] ボタンを描画します。</span><span class="sxs-lookup"><span data-stu-id="cf457-133">**Desktop/Hub**: Draw the in-app back button on the top left corner of your app's UI.</span></span>
- <span data-ttu-id="cf457-134">**Xbox/テレビ**:UI の不要なものは、追加は、[戻る] ボタンを描画しません。</span><span class="sxs-lookup"><span data-stu-id="cf457-134">**Xbox/TV**: Do not draw a back button, for it will add unnecessary UI clutter.</span></span> <span data-ttu-id="cf457-135">代わりに、ゲームパッドの B ボタンで前に戻ります。</span><span class="sxs-lookup"><span data-stu-id="cf457-135">Instead, rely on the Gamepad B button to navigate backwards.</span></span>

<span data-ttu-id="cf457-136">アプリが複数のデバイスで実行される場合は、[Xbox 用の視覚的なカスタム トリガーを作成](../devices/designing-for-tv.md#custom-visual-state-trigger-for-xbox)してボタンの表示/非表示を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="cf457-136">If your app will run on multiple devices, [create a custom visual trigger for Xbox](../devices/designing-for-tv.md#custom-visual-state-trigger-for-xbox) to toggle the visibility of button.</span></span> <span data-ttu-id="cf457-137">NavigationView コントロールでは、Xbox でアプリが実行されている場合に、戻るボタンの表示/非表示が自動的に切り替わります。</span><span class="sxs-lookup"><span data-stu-id="cf457-137">The NavigationView control will automatically toggle the back button's visibility if your app is running on Xbox.</span></span> 

<span data-ttu-id="cf457-138">"戻る" ナビゲーションの場合に、次の入力をサポートすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cf457-138">We recommend supporting the following inputs for back navigation.</span></span> <span data-ttu-id="cf457-139">(これらの入力の一部はシステム BackRequested でサポートされていないため、別のイベントで処理する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="cf457-139">(Note that some of these inputs are not supported by the system BackRequested and must be handled by separate events.)</span></span>

| <span data-ttu-id="cf457-140">入力</span><span class="sxs-lookup"><span data-stu-id="cf457-140">Input</span></span> | <span data-ttu-id="cf457-141">event</span><span class="sxs-lookup"><span data-stu-id="cf457-141">Event</span></span> |
| --- | --- |
| <span data-ttu-id="cf457-142">Windows の BackSpace キー</span><span class="sxs-lookup"><span data-stu-id="cf457-142">Windows-Backspace key</span></span> | <span data-ttu-id="cf457-143">BackRequested</span><span class="sxs-lookup"><span data-stu-id="cf457-143">BackRequested</span></span> |
| <span data-ttu-id="cf457-144">ハードウェアの戻るボタン</span><span class="sxs-lookup"><span data-stu-id="cf457-144">Hardware back button</span></span> | <span data-ttu-id="cf457-145">BackRequested</span><span class="sxs-lookup"><span data-stu-id="cf457-145">BackRequested</span></span> |
| <span data-ttu-id="cf457-146">シェル タブレット モードの戻るボタン</span><span class="sxs-lookup"><span data-stu-id="cf457-146">Shell tablet mode back button</span></span> | <span data-ttu-id="cf457-147">BackRequested</span><span class="sxs-lookup"><span data-stu-id="cf457-147">BackRequested</span></span> |
| <span data-ttu-id="cf457-148">VirtualKey.XButton1</span><span class="sxs-lookup"><span data-stu-id="cf457-148">VirtualKey.XButton1</span></span> | <span data-ttu-id="cf457-149">PointerPressed</span><span class="sxs-lookup"><span data-stu-id="cf457-149">PointerPressed</span></span> |
| <span data-ttu-id="cf457-150">VirtualKey.GoBack</span><span class="sxs-lookup"><span data-stu-id="cf457-150">VirtualKey.GoBack</span></span> | <span data-ttu-id="cf457-151">KeyboardAccelerator.BackInvoked</span><span class="sxs-lookup"><span data-stu-id="cf457-151">KeyboardAccelerator.BackInvoked</span></span> |
| <span data-ttu-id="cf457-152">Alt + 左方向キー</span><span class="sxs-lookup"><span data-stu-id="cf457-152">Alt+LeftArrow key</span></span> | <span data-ttu-id="cf457-153">KeyboardAccelerator.BackInvoked</span><span class="sxs-lookup"><span data-stu-id="cf457-153">KeyboardAccelerator.BackInvoked</span></span> |

<span data-ttu-id="cf457-154">上のコード例は、これらすべての入力を処理する方法を示してます。</span><span class="sxs-lookup"><span data-stu-id="cf457-154">The code examples provided above demonstrate how to handle all of these inputs.</span></span>

## <a name="system-back-behavior-for-backward-compatibilities"></a><span data-ttu-id="cf457-155">下位互換性のためのシステムの戻る動作</span><span class="sxs-lookup"><span data-stu-id="cf457-155">System back behavior for backward compatibilities</span></span>

<span data-ttu-id="cf457-156">以前、UWP アプリは前に戻る移動のために [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility) を使用しました。</span><span class="sxs-lookup"><span data-stu-id="cf457-156">Previously, UWP apps used [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility) for backwards navigation.</span></span> <span data-ttu-id="cf457-157">旧バージョンとの互換性を確保するためにサポートする API は引き続きが不要になったで証明書利用者をお勧めします[AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility)します。</span><span class="sxs-lookup"><span data-stu-id="cf457-157">The API will continue to be supported to ensure backward compatibility, but we no longer recommend relying on [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility).</span></span> <span data-ttu-id="cf457-158">代わりに、アプリで独自のアプリ内の戻るボタンを描画してください。</span><span class="sxs-lookup"><span data-stu-id="cf457-158">Instead, your app should draw its own in-app back button.</span></span>

<span data-ttu-id="cf457-159">使用して、アプリが解決しない場合は[AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility)、システム UI は、タイトル バー内でシステムの [戻る] ボタンをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="cf457-159">If your app continues using [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility), then the system UI will render the system back button inside the title bar.</span></span> <span data-ttu-id="cf457-160">([戻る] ボタンの外観とユーザーの相互作用は、前のビルドから変更されていません)。</span><span class="sxs-lookup"><span data-stu-id="cf457-160">(The appearance and user interactions for the back button are unchanged from previous builds.)</span></span>

![タイトル バーの [戻る] ボタン](images/nav-back-pc.png)

### <a name="system-back-bar"></a><span data-ttu-id="cf457-162">システム バックアップ バー</span><span class="sxs-lookup"><span data-stu-id="cf457-162">System back bar</span></span>

> [!NOTE]
> <span data-ttu-id="cf457-163">"システム バック バー"は公式名ではなく、説明のみです。</span><span class="sxs-lookup"><span data-stu-id="cf457-163">"System back bar" is only a description, not an official name.</span></span>

<span data-ttu-id="cf457-164">システム バックアップ バーが「バンド」タブ バンドとアプリのコンテンツ領域の間に挿入します。</span><span class="sxs-lookup"><span data-stu-id="cf457-164">The system back bar is a “band” that is inserted between the tab band and the app’s content area.</span></span> <span data-ttu-id="cf457-165">バンドは、アプリの幅に沿って表示され、左端に戻るボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="cf457-165">The band goes across the width of the app, with the back button on the left edge.</span></span> <span data-ttu-id="cf457-166">バンドが、[戻る] ボタンのための適切なタッチの目標サイズを 32 ピクセルの縦の高さ。</span><span class="sxs-lookup"><span data-stu-id="cf457-166">The band has a vertical height of 32 pixels to ensure adequate touch target size for the back button.</span></span>

<span data-ttu-id="cf457-167">システムの戻るバーは、戻るボタンの可視性に基づいて動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="cf457-167">The system back bar is displayed dynamically, based on back button visibility.</span></span> <span data-ttu-id="cf457-168">[戻る] ボタンが表示されている場合、システムのバック バーを挿入すると、32 ピクセル タブ バンドの下でアプリのコンテンツを移行します。</span><span class="sxs-lookup"><span data-stu-id="cf457-168">When the back button is visible, the system back bar is inserted, shifting app content down by 32 pixels below the tab band.</span></span> <span data-ttu-id="cf457-169">[戻る] ボタンが非表示、システムのバック バーが動的に削除され、アプリのコンテンツをタブのバンドを満たすために 32 ピクセルずつ増えます。</span><span class="sxs-lookup"><span data-stu-id="cf457-169">When the back button is hidden, the system back bar is dynamically removed, shifting app content up by 32 pixels to meet the tab band.</span></span> <span data-ttu-id="cf457-170">描画をお勧め、アプリの UI の shift キーを持つアップまたはスケール ダウンを回避する、[アプリで [戻る] ボタン](#back-button)します。</span><span class="sxs-lookup"><span data-stu-id="cf457-170">To avoid having your app's UI shift up or down, we recommend drawing an [in-app back button](#back-button).</span></span>

<span data-ttu-id="cf457-171">[タイトルのカスタマイズ バー](../shell/title-bar.md)アプリ タブとシステムの両方に引き継がれるバー。</span><span class="sxs-lookup"><span data-stu-id="cf457-171">[Title bar customizations](../shell/title-bar.md) will carry over to both the app tab and the system back bar.</span></span> <span data-ttu-id="cf457-172">アプリの前景色および背景色のプロパティを指定する場合[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar)タブとシステムの背面に適用される色、バー。</span><span class="sxs-lookup"><span data-stu-id="cf457-172">If your app specifies background and foreground color properties with [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar), then the colors will be applied to the tab and system back bar.</span></span>

## <a name="guidelines-for-custom-back-navigation-behavior"></a><span data-ttu-id="cf457-173">カスタムの "戻る" ナビゲーションの動作のガイドライン</span><span class="sxs-lookup"><span data-stu-id="cf457-173">Guidelines for custom back navigation behavior</span></span>

<span data-ttu-id="cf457-174">独自のバック スタック ナビゲーションを提供する場合、エクスペリエンスが他のアプリと一貫している必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf457-174">If you choose to provide your own back stack navigation, the experience should be consistent with other apps.</span></span> <span data-ttu-id="cf457-175">ナビゲーション操作では、次のパターンに従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cf457-175">We recommend that you follow the following patterns for navigation actions:</span></span>

<div class="mx-responsive-img">
<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="cf457-176">ナビゲーション操作</span><span class="sxs-lookup"><span data-stu-id="cf457-176">Navigation action</span></span></th>
<th align="left"><span data-ttu-id="cf457-177">ナビゲーション履歴への追加</span><span class="sxs-lookup"><span data-stu-id="cf457-177">Add to navigation history?</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><span data-ttu-id="cf457-178"><strong>ページのさまざまなピア グループ ページ</strong></span><span class="sxs-lookup"><span data-stu-id="cf457-178"><strong>Page to page, different peer groups</strong></span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="cf457-179"><strong>うん</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-179"><strong>Yes</strong>
</span></span><p><span data-ttu-id="cf457-180">この図では、ユーザーはピア グループを横断して、アプリのレベル 1 からレベル 2 に移動します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</span><span class="sxs-lookup"><span data-stu-id="cf457-180">In this illustration, the user navigates from level 1 of the app to level 2, crossing peer groups, so the navigation is added to the navigation history.</span></span></p>
<p><img src="images/back-nav/nav-pagetopage-diffpeers-imageonly1.png" alt="Navigation across peer groups" /></p>
<p><span data-ttu-id="cf457-181">次の図では、ユーザーは同じレベルにある 2 つのピア グループの間を移動し、この場合もピア グループを横断します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</span><span class="sxs-lookup"><span data-stu-id="cf457-181">In the next illustration, the user navigates between two peer groups at the same level, again crossing peer groups, so the navigation is added to the navigation history.</span></span></p>
<p><img src="images/back-nav/nav-pagetopage-diffpeers-imageonly2.png" alt="Navigation across peer groups" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><span data-ttu-id="cf457-182"><strong>ページのページに同じピア グループ、いいえ画面上のナビゲーション要素</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-182"><strong>Page to page, same peer group, no on-screen navigation element</strong>
</span></span><p><span data-ttu-id="cf457-183">ユーザーは、同じピア グループでページ間を移動します。</span><span class="sxs-lookup"><span data-stu-id="cf457-183">The user navigates from one page to another with the same peer group.</span></span> <span data-ttu-id="cf457-184">いいえ画面がナビゲーション要素 (など<a href="https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/navigationview">NavigationView</a>) 両方のページへの直接のナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="cf457-184">There is no on-screen navigation element (such as <a href="https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/navigationview">NavigationView</a>) that provides direct navigation to both pages.</span></span></p></td>
<td style="vertical-align:top;"><span data-ttu-id="cf457-185"><strong>うん</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-185"><strong>Yes</strong>
</span></span><p><span data-ttu-id="cf457-186">次の図に、ユーザーが同じピア グループに 2 つのページ間で移動して、ナビゲーションは、ナビゲーション履歴に追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf457-186">In the following illustration, the user navigates between two pages in the same peer group, and the navigation should be added to the navigation history.</span></span></p>
<p><img src="images/back-nav/nav-pagetopage-samepeer-noosnavelement.png" alt="Navigation within a peer group" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><span data-ttu-id="cf457-187"><strong>同じピア グループのページにページ、画面上のナビゲーション要素</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-187"><strong>Page to page, same peer group, with an on-screen navigation element</strong>
</span></span><p><span data-ttu-id="cf457-188">ユーザーは、同じピア グループ内のページ間を移動します。</span><span class="sxs-lookup"><span data-stu-id="cf457-188">The user navigates from one page to another in the same peer group.</span></span> <span data-ttu-id="cf457-189">両方のページに表示されます、同じナビゲーション要素など<a href="https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/navigationview">NavigationView</a>します。</span><span class="sxs-lookup"><span data-stu-id="cf457-189">Both pages are shown in the same navigation element, such as <a href="https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/navigationview">NavigationView</a>.</span></span></p></td>
<td style="vertical-align:top;"><span data-ttu-id="cf457-190"><strong>事によりけりです</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-190"><strong>It depends</strong>
</span></span><p><span data-ttu-id="cf457-191">はい、2 つの注目すべき例外で、ナビゲーション履歴に追加します。</span><span class="sxs-lookup"><span data-stu-id="cf457-191">Yes, add to the navigation history, with two notable exceptions.</span></span> <span data-ttu-id="cf457-192">多くの場合、ピア グループのページ間を切り替えるアプリのユーザーが予想される場合、またはナビゲーション階層を保持する場合は、追加しないでくださいをナビゲーション履歴にします。</span><span class="sxs-lookup"><span data-stu-id="cf457-192">If you expect users of your app to switch between pages in the peer group frequently, or if you wish to preserve the navigational hierarchy, then do not add to the navigation history.</span></span> <span data-ttu-id="cf457-193">この場合、ユーザーが戻るボタンを押すと、現在のピア グループに移動する前に表示していた最後のページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="cf457-193">In this case, when the user presses back, go back to the last page before the user navigated to the current peer group.</span></span> </p>
<p><img src="images/back-nav/nav-pagetopage-samepeer-yesosnavelement.png" alt="Navigation across peer groups when a navigation element is present" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><span data-ttu-id="cf457-194"><strong>一時的な UI を表示します。</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-194"><strong>Show a transient UI</strong>
</span></span><p><span data-ttu-id="cf457-195">アプリは、ダイアログ、スプラッシュ画面、スクリーン キーボードなどのポップアップ ウィンドウや子ウィンドウを表示します。または、アプリが複数選択モードなどの特別なモードに移行します。</span><span class="sxs-lookup"><span data-stu-id="cf457-195">The app displays a pop-up or child window, such as a dialog, splash screen, or on-screen keyboard, or the app enters a special mode, such as multiple selection mode.</span></span></p></td>
<td style="vertical-align:top;"><span data-ttu-id="cf457-196"><strong>違います</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-196"><strong>No</strong>
</span></span><p><span data-ttu-id="cf457-197">ユーザーが戻るボタンを押すと、一時的な UI が閉じられ (スクリーン キーボードが非表示になる、ダイアログがキャンセルされるなど)、一時的な UI を生成したページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="cf457-197">When the user presses the back button, dismiss the transient UI (hide the on-screen keyboard, cancel the dialog, etc) and return to the page that spawned the transient UI.</span></span></p>
<p><img src="images/back-nav/back-transui.png" alt="Showing a transient UI" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><span data-ttu-id="cf457-198"><strong>項目を列挙します。</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-198"><strong>Enumerate items</strong>
</span></span><p><span data-ttu-id="cf457-199">アプリが、マスター/詳細リストで選んだ項目の詳細など、画面上の項目のコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="cf457-199">The app displays content for an on-screen item, such as the details for the selected item in master/details list.</span></span></p></td>
<td style="vertical-align:top;"><span data-ttu-id="cf457-200"><strong>違います</strong>
</span><span class="sxs-lookup"><span data-stu-id="cf457-200"><strong>No</strong>
</span></span><p><span data-ttu-id="cf457-201">項目の列挙は、ピア グループ内の移動に似ています。</span><span class="sxs-lookup"><span data-stu-id="cf457-201">Enumerating items is similar to navigating within a peer group.</span></span> <span data-ttu-id="cf457-202">ユーザーが戻るボタンを押すと、項目の列挙が表示されている現在のページの前のページに移動されます。</span><span class="sxs-lookup"><span data-stu-id="cf457-202">When the user presses back, navigate to the page that preceded the current page that has the item enumeration.</span></span></p>
<p><img src="images/back-nav/nav-enumerate.png" alt="Iterm enumeration" /></p></td>
</tr>
</tbody>
</table>
</div>

### <a name="resuming"></a><span data-ttu-id="cf457-203">Resuming</span><span class="sxs-lookup"><span data-stu-id="cf457-203">Resuming</span></span>

<span data-ttu-id="cf457-204">ユーザーが別のアプリに切り替えた後で、元のアプリに戻った場合は、ナビゲーション履歴にある最後のページに戻すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cf457-204">When the user switches to another app and returns to your app, we recommend returning to the last page in the navigation history.</span></span>

## <a name="related-articles"></a><span data-ttu-id="cf457-205">関連記事</span><span class="sxs-lookup"><span data-stu-id="cf457-205">Related articles</span></span>

- [<span data-ttu-id="cf457-206">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="cf457-206">Navigation basics</span></span>](navigation-basics.md)
