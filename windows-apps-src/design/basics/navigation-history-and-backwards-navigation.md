---
author: QuinnRadich
Description: Learn how to implement backwards navigation for traversing the user's navigation history within an UWP app.
title: ナビゲーション履歴と前に戻る移動 (Windows アプリ)
ms.assetid: e9876b4c-242d-402d-a8ef-3487398ed9b3
isNew: true
label: History and backwards navigation
template: detail.hbs
op-migration-status: ready
ms.author: quradic
ms.date: 06/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 714a1af932dfb8d5b0aab5c84437f92d5c2bd90e
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3851212"
---
# <a name="navigation-history-and-backwards-navigation-for-uwp-apps"></a><span data-ttu-id="edd49-103">UWP アプリのナビゲーション履歴と前に戻る移動</span><span class="sxs-lookup"><span data-stu-id="edd49-103">Navigation history and backwards navigation for UWP apps</span></span>

> <span data-ttu-id="edd49-104">**重要な API**: [BackRequested イベント](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager.BackRequested)、[SystemNavigationManager クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager)、[OnNavigatedTo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_)</span><span class="sxs-lookup"><span data-stu-id="edd49-104">**Important APIs**: [BackRequested event](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager.BackRequested), [SystemNavigationManager class](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager), [OnNavigatedTo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_)</span></span>

<span data-ttu-id="edd49-105">ユニバーサル Windows プラットフォーム (UWP) では、アプリのユーザーのナビゲーションの履歴内の移動や、デバイスによってはアプリ間の移動について、一貫性のある "戻る" ナビゲーション システムを提供します。</span><span class="sxs-lookup"><span data-stu-id="edd49-105">The Universal Windows Platform (UWP) provides a consistent back navigation system for traversing the user's navigation history within an app and, depending on the device, from app to app.</span></span>

<span data-ttu-id="edd49-106">アプリに前に戻る移動を実装するには、アプリの UI の左上隅に[戻るボタン](#Back-button)を配置します。</span><span class="sxs-lookup"><span data-stu-id="edd49-106">To implement backwards navigation in your app, place a [back button](#Back-button) at the top left corner of your app's UI.</span></span> <span data-ttu-id="edd49-107">アプリで [NavigationView](../controls-and-patterns/navigationview.md) コントロールを使用する場合は、[NavigationView の組み込みの戻るボタン](../controls-and-patterns/navigationview.md#backwards-navigation)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="edd49-107">If your app uses the [NavigationView](../controls-and-patterns/navigationview.md) control, then you can use [NavigationView's built-in back button](../controls-and-patterns/navigationview.md#backwards-navigation).</span></span>

<span data-ttu-id="edd49-108">ユーザーは、戻るボタンによって、アプリのナビゲーション履歴における前の場所に戻ることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="edd49-108">The user expects the back button to navigate to the previous location in the app's navigation history.</span></span> <span data-ttu-id="edd49-109">ナビゲーション履歴に追加するナビゲーション操作の種類、および戻るボタンが押されたときの応答方法は、自由に決めることができます。</span><span class="sxs-lookup"><span data-stu-id="edd49-109">Note that it's up to you to decide which navigation actions to add to the navigation history and how to respond to the back button press.</span></span>

## <a name="back-button"></a><span data-ttu-id="edd49-110">[戻る] ボタン</span><span class="sxs-lookup"><span data-stu-id="edd49-110">Back button</span></span>

<span data-ttu-id="edd49-111">"戻る"ボタンを作成する[ボタン](../controls-and-patterns/buttons.md)コントロールを使用して、`NavigationBackButtonNormalStyle`スタイルを指定し、アプリの UI の左上隅にボタンが配置 (詳細については、次の XAML コード例を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="edd49-111">To create a back button, use the [Button](../controls-and-patterns/buttons.md) control with the `NavigationBackButtonNormalStyle` style, and place the button at the top left hand corner of your app's UI (for details, see the XAML code examples below).</span></span>

![アプリの UI の左上隅にある [戻る] ボタン](images/back-nav/BackEnabled.png)

```xaml
<Button Style="{StaticResource NavigationBackButtonNormalStyle}"/>
```

<span data-ttu-id="edd49-113">アプリに上部 [CommandBar](../controls-and-patterns/app-bars.md) がある場合、高さ 44px の Button コントロールは 48px の AppBarButtons とはぴったり合いません。</span><span class="sxs-lookup"><span data-stu-id="edd49-113">If your app has a top [CommandBar](../controls-and-patterns/app-bars.md), the Button control that is 44px in height will not align with 48px AppBarButtons very nicely.</span></span> <span data-ttu-id="edd49-114">不整合を避けるために、Button コントロールの最上部を 48px の境界内部に合わせてください。</span><span class="sxs-lookup"><span data-stu-id="edd49-114">However, to avoid inconsistency, align the top of the Button control inside the 48px bounds.</span></span>

![上部のコマンド バーの [戻る] ボタン](images/back-nav/CommandBar.png)

```xaml
<Button VerticalAlignment="Top" HorizontalAlignment="Left" 
Style="{StaticResource NavigationBackButtonNormalStyle}"/>
```

<span data-ttu-id="edd49-116">アプリ内で動き回る UI 要素を最小化するために、バックスタックに何もないときに、無効になった戻るボタンを表示します (以下のコード例を参照)。</span><span class="sxs-lookup"><span data-stu-id="edd49-116">In order to minimize UI elements moving around in your app, show a disabled back button when there is nothing in the backstack (see code example below).</span></span>

![[戻る] ボタンの状態](images/back-nav/BackDisabled.png)

## <a name="code-example"></a><span data-ttu-id="edd49-118">コード例</span><span class="sxs-lookup"><span data-stu-id="edd49-118">Code example</span></span>

<span data-ttu-id="edd49-119">次のコード例は、戻るボタンで前に戻る移動の動作を実装する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="edd49-119">The following code example demonstrates how to implement backwards navigation behavior with a back button.</span></span> <span data-ttu-id="edd49-120">このコードでは、Button の [**Click**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.Click) イベントに応答し、新しいページに移動したときに呼び出される [**OnNavigatedTo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_) でボタンの表示を無効/有効にします。</span><span class="sxs-lookup"><span data-stu-id="edd49-120">The code responds to the Button [**Click**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.Click) event and disables/enables the button visibility in [**OnNavigatedTo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_), which is called when navigating to a new page.</span></span> <span data-ttu-id="edd49-121">このコード例では、[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested) イベントのリスナーを登録することで、ハードウェアおよびソフトウェア システムの戻るキーからの入力も処理しています。</span><span class="sxs-lookup"><span data-stu-id="edd49-121">The code example also handles inputs from hardware and software system back keys by registering a listener for the [**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested) event.</span></span>

```xaml
<!-- MainPage.xaml -->
<Page x:Class="AppName.MainPage">
...
<Button x:Name="BackButton" Click="Back_Click" Style="{StaticResource NavigationBackButtonNormalStyle}"/>
...
<Page/>
```

<span data-ttu-id="edd49-122">分離コード:</span><span class="sxs-lookup"><span data-stu-id="edd49-122">Code-behind:</span></span>

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

<span data-ttu-id="edd49-123">上記を処理します前に戻る単一ページのナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="edd49-123">Above, we handle backwards navigation for a single page.</span></span> <span data-ttu-id="edd49-124">"戻る"ナビゲーションから特定のページを除外するか、ページを表示する前に、ページ レベルのコードを実行する場合は、各ページでのナビゲーションを処理できます。</span><span class="sxs-lookup"><span data-stu-id="edd49-124">You can handle navigation in each page if you want to exclude specific pages from back navigation, or you want to execute page-level code before displaying the page.</span></span>

<span data-ttu-id="edd49-125">前に戻るナビゲーションをアプリ全体を処理するで[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested)イベントのグローバル リスナーを登録するが、`App.xaml`コード ビハインド ファイル。</span><span class="sxs-lookup"><span data-stu-id="edd49-125">To handle backwards navigation for an entire app, you'll register a global listener for the [**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested) event in the `App.xaml` code-behind file.</span></span>

<span data-ttu-id="edd49-126">App.xaml 分離コード:</span><span class="sxs-lookup"><span data-stu-id="edd49-126">App.xaml code-behind:</span></span>

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

## <a name="optimizing-for-different-device-and-form-factors"></a><span data-ttu-id="edd49-127">さまざまなデバイスとフォーム ファクター向けに最適化</span><span class="sxs-lookup"><span data-stu-id="edd49-127">Optimizing for different device and form factors</span></span>

<span data-ttu-id="edd49-128">この前に戻る移動の設計ガイダンスはすべてのデバイスに適用可能ですが、最適化によってさまざまなデバイスとフォーム ファクターに適したものになります。</span><span class="sxs-lookup"><span data-stu-id="edd49-128">This backwards navigation design guidance is applicable to all devices, but different device and form factors may benefit from optimization.</span></span> <span data-ttu-id="edd49-129">これは、さまざまなシェルでサポートされているハードウェアの戻るボタンによっても変わります。</span><span class="sxs-lookup"><span data-stu-id="edd49-129">This also depends on the hardware back button supported by different shells.</span></span>

- <span data-ttu-id="edd49-130">**電話/タブレット**: ハードウェアまたはソフトウェアの戻るボタンは、携帯電話やタブレットに常に存在しますが、わかりやすくするために　アプリ内の戻るボタンを描画することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="edd49-130">**Phone/Tablet**: A hardware or software back button is always present on mobile and tablet, but we recommend drawing an in-app back button for clarity.</span></span>
- <span data-ttu-id="edd49-131">**デスクトップ/ハブ**: アプリの UI の左上隅にアプリ内の戻るボタンを描画します。</span><span class="sxs-lookup"><span data-stu-id="edd49-131">**Desktop/Hub**: Draw the in-app back button on the top left corner of your app's UI.</span></span>
- <span data-ttu-id="edd49-132">**Xbox/テレビ**: 不要な UI 要素が追加されるため、戻るボタンは描画しません。</span><span class="sxs-lookup"><span data-stu-id="edd49-132">**Xbox/TV**: Do not draw a back button, for it will add unnecessary UI clutter.</span></span> <span data-ttu-id="edd49-133">代わりに、ゲームパッドの B ボタンで前に戻ります。</span><span class="sxs-lookup"><span data-stu-id="edd49-133">Instead, rely on the Gamepad B button to navigate backwards.</span></span>

<span data-ttu-id="edd49-134">アプリが複数のデバイスで実行される場合は、[Xbox 用の視覚的なカスタム トリガーを作成](../devices/designing-for-tv.md#custom-visual-state-trigger-for-xbox)してボタンの表示/非表示を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="edd49-134">If your app will run on multiple devices, [create a custom visual trigger for Xbox](../devices/designing-for-tv.md#custom-visual-state-trigger-for-xbox) to toggle the visibility of button.</span></span> <span data-ttu-id="edd49-135">NavigationView コントロールでは、Xbox でアプリが実行されている場合に、戻るボタンの表示/非表示が自動的に切り替わります。</span><span class="sxs-lookup"><span data-stu-id="edd49-135">The NavigationView control will automatically toggle the back button's visibility if your app is running on Xbox.</span></span> 

<span data-ttu-id="edd49-136">"戻る" ナビゲーションの場合に、次の入力をサポートすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="edd49-136">We recommend supporting the following inputs for back navigation.</span></span> <span data-ttu-id="edd49-137">(これらの入力の一部はシステム BackRequested でサポートされていないため、別のイベントで処理する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="edd49-137">(Note that some of these inputs are not supported by the system BackRequested and must be handled by separate events.)</span></span>

| <span data-ttu-id="edd49-138">入力</span><span class="sxs-lookup"><span data-stu-id="edd49-138">Input</span></span> | <span data-ttu-id="edd49-139">イベント</span><span class="sxs-lookup"><span data-stu-id="edd49-139">Event</span></span> |
| --- | --- |
| <span data-ttu-id="edd49-140">Windows の BackSpace キー</span><span class="sxs-lookup"><span data-stu-id="edd49-140">Windows-Backspace key</span></span> | <span data-ttu-id="edd49-141">BackRequested</span><span class="sxs-lookup"><span data-stu-id="edd49-141">BackRequested</span></span> |
| <span data-ttu-id="edd49-142">ハードウェアの戻るボタン</span><span class="sxs-lookup"><span data-stu-id="edd49-142">Hardware back button</span></span> | <span data-ttu-id="edd49-143">BackRequested</span><span class="sxs-lookup"><span data-stu-id="edd49-143">BackRequested</span></span> |
| <span data-ttu-id="edd49-144">シェル タブレット モードの戻るボタン</span><span class="sxs-lookup"><span data-stu-id="edd49-144">Shell tablet mode back button</span></span> | <span data-ttu-id="edd49-145">BackRequested</span><span class="sxs-lookup"><span data-stu-id="edd49-145">BackRequested</span></span> |
| <span data-ttu-id="edd49-146">VirtualKey.XButton1</span><span class="sxs-lookup"><span data-stu-id="edd49-146">VirtualKey.XButton1</span></span> | <span data-ttu-id="edd49-147">PointerPressed</span><span class="sxs-lookup"><span data-stu-id="edd49-147">PointerPressed</span></span> |
| <span data-ttu-id="edd49-148">VirtualKey.GoBack</span><span class="sxs-lookup"><span data-stu-id="edd49-148">VirtualKey.GoBack</span></span> | <span data-ttu-id="edd49-149">KeyboardAccelerator.BackInvoked</span><span class="sxs-lookup"><span data-stu-id="edd49-149">KeyboardAccelerator.BackInvoked</span></span> |
| <span data-ttu-id="edd49-150">Alt + 左方向キー</span><span class="sxs-lookup"><span data-stu-id="edd49-150">Alt+LeftArrow key</span></span> | <span data-ttu-id="edd49-151">KeyboardAccelerator.BackInvoked</span><span class="sxs-lookup"><span data-stu-id="edd49-151">KeyboardAccelerator.BackInvoked</span></span> |

<span data-ttu-id="edd49-152">上のコード例は、これらすべての入力を処理する方法を示してます。</span><span class="sxs-lookup"><span data-stu-id="edd49-152">The code examples provided above demonstrate how to handle all of these inputs.</span></span>

## <a name="system-back-behavior-for-backward-compatibilities"></a><span data-ttu-id="edd49-153">下位互換性のためのシステムの戻る動作</span><span class="sxs-lookup"><span data-stu-id="edd49-153">System back behavior for backward compatibilities</span></span>

<span data-ttu-id="edd49-154">以前、UWP アプリは前に戻る移動のために [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility) を使用しました。</span><span class="sxs-lookup"><span data-stu-id="edd49-154">Previously, UWP apps used [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility) for backwards navigation.</span></span> <span data-ttu-id="edd49-155">この API は下位互換性のためにサポートが継続されますが、タイトル バーの戻るボタンの使用はもうお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="edd49-155">The API will continue to be supported for backward compatibility, but we no longer recommend relying on the title bar back button.</span></span> <span data-ttu-id="edd49-156">代わりに、アプリで独自のアプリ内の戻るボタンを描画してください。</span><span class="sxs-lookup"><span data-stu-id="edd49-156">Instead, your app should draw its own in-app back button.</span></span>

<span data-ttu-id="edd49-157">アプリで [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility) の使用を続ける場合は、通常どおり、戻るボタンはタイトル バーの内部にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="edd49-157">If your app continues to use [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility), then the back button will be rendered inside the title bar as usual.</span></span>

- <span data-ttu-id="edd49-158">アプリが**タブがない**場合は、タイトル バーの内部、戻るボタンがレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="edd49-158">If your app is **not tabbed**, then the back button is rendered inside the title bar.</span></span> <span data-ttu-id="edd49-159">"戻る"ボタンの視覚エクスペリエンスとユーザーの操作では、以前のビルドから変更されません。</span><span class="sxs-lookup"><span data-stu-id="edd49-159">The visual experience and user interactions for the back button are unchanged from previous builds.</span></span>

    ![タイトル バーの戻るボタン](images/nav-back-pc.png)

- <span data-ttu-id="edd49-161">アプリが**タブ**のかどうか、戻るボタンは、新しいシステムの戻る内部にレンダリング バー。</span><span class="sxs-lookup"><span data-stu-id="edd49-161">If an app is **tabbed**, then the back button is rendered inside a new system back bar.</span></span>

    ![戻るボタンのバーに描画されるシステム](images/back-nav/tabs.png)

### <a name="system-back-bar"></a><span data-ttu-id="edd49-163">システムの戻るバー</span><span class="sxs-lookup"><span data-stu-id="edd49-163">System back bar</span></span>

> [!NOTE]
> <span data-ttu-id="edd49-164">"システムの戻るバー"は、公式の名前ではなく説明のみです。</span><span class="sxs-lookup"><span data-stu-id="edd49-164">"System back bar" is only a description, not an official name.</span></span>

<span data-ttu-id="edd49-165">システムの戻るバーは、タブ バンドとアプリのコンテンツ領域の間に挿入されているバンドします。</span><span class="sxs-lookup"><span data-stu-id="edd49-165">The system back bar is a �band� that is inserted between the tab band and the app�s content area.</span></span> <span data-ttu-id="edd49-166">バンドは、アプリの幅に沿って表示され、左端に戻るボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="edd49-166">The band goes across the width of the app, with the back button on the left edge.</span></span> <span data-ttu-id="edd49-167">バンドは、戻るボタンの適切なタッチ ターゲットのサイズを確認する 32 ピクセルの高さがあります。</span><span class="sxs-lookup"><span data-stu-id="edd49-167">The band has a vertical height of 32 pixels to ensure adequate touch target size for the back button.</span></span>

<span data-ttu-id="edd49-168">システムの戻るバーは、戻るボタンの可視性に基づいて動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="edd49-168">The system back bar is displayed dynamically, based on back button visibility.</span></span> <span data-ttu-id="edd49-169">[戻る] ボタンが表示される場合、システムの戻るバーが挿入され、アプリのコンテンツのタブ バンド 32 ピクセル下に移動します。</span><span class="sxs-lookup"><span data-stu-id="edd49-169">When the back button is visible, the system back bar is inserted, shifting app content down by 32 pixels below the tab band.</span></span> <span data-ttu-id="edd49-170">[戻る] ボタンを非表示するとき、システムの戻るバーは動的に削除され、アプリのコンテンツ シフトをタブ バンドを満たすために 32 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="edd49-170">When the back button is hidden, the system back bar is dynamically removed, shifting app content up by 32 pixels to meet the tab band.</span></span> <span data-ttu-id="edd49-171">上または下に、アプリの UI shift キーを持つを避けるため、[アプリ内の戻るボタン](#back-button)を描画をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="edd49-171">To avoid having your app's UI shift up or down, we recommend drawing an [in-app back button](#back-button).</span></span>

<span data-ttu-id="edd49-172">[タイトル バーのカスタマイズ](../shell/title-bar.md)は、アプリのタブとシステムの戻るの両方に引き継がバー。</span><span class="sxs-lookup"><span data-stu-id="edd49-172">[Title bar customizations](../shell/title-bar.md) will carry over to both the app tab and the system back bar.</span></span> <span data-ttu-id="edd49-173">アプリで[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar)、バック グラウンドとフォア グラウンドの色のプロパティを指定するかどうかは、色がタブとシステムの戻るに適用されますバー。</span><span class="sxs-lookup"><span data-stu-id="edd49-173">If your app specifies background and foreground color properties with [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar), then the colors will be applied to the tab and system back bar.</span></span>

## <a name="guidelines-for-custom-back-navigation-behavior"></a><span data-ttu-id="edd49-174">カスタムの "戻る" ナビゲーションの動作のガイドライン</span><span class="sxs-lookup"><span data-stu-id="edd49-174">Guidelines for custom back navigation behavior</span></span>

<span data-ttu-id="edd49-175">独自のバック スタック ナビゲーションを提供する場合、エクスペリエンスが他のアプリと一貫している必要があります。</span><span class="sxs-lookup"><span data-stu-id="edd49-175">If you choose to provide your own back stack navigation, the experience should be consistent with other apps.</span></span> <span data-ttu-id="edd49-176">ナビゲーション操作では、次のパターンに従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="edd49-176">We recommend that you follow the following patterns for navigation actions:</span></span>

<div class="mx-responsive-img">
<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="edd49-177">ナビゲーション操作</span><span class="sxs-lookup"><span data-stu-id="edd49-177">Navigation action</span></span></th>
<th align="left"><span data-ttu-id="edd49-178">ナビゲーション履歴への追加</span><span class="sxs-lookup"><span data-stu-id="edd49-178">Add to navigation history?</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-179">ページ間、異なるピア グループ</span><span class="sxs-lookup"><span data-stu-id="edd49-179">Page to page, different peer groups</span></span></strong></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-180">○</span><span class="sxs-lookup"><span data-stu-id="edd49-180">Yes</span></span></strong>
<p><span data-ttu-id="edd49-181">この図では、ユーザーはピア グループを横断して、アプリのレベル 1 からレベル 2 に移動します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</span><span class="sxs-lookup"><span data-stu-id="edd49-181">In this illustration, the user navigates from level 1 of the app to level 2, crossing peer groups, so the navigation is added to the navigation history.</span></span></p>
<p><img src="images/back-nav/nav-pagetopage-diffpeers-imageonly1.png" alt="Navigation across peer groups" /></p>
<p><span data-ttu-id="edd49-182">次の図では、ユーザーは同じレベルにある 2 つのピア グループの間を移動し、この場合もピア グループを横断します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</span><span class="sxs-lookup"><span data-stu-id="edd49-182">In the next illustration, the user navigates between two peer groups at the same level, again crossing peer groups, so the navigation is added to the navigation history.</span></span></p>
<p><img src="images/back-nav/nav-pagetopage-diffpeers-imageonly2.png" alt="Navigation across peer groups" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-183">ページ間、同じピア グループ、ナビゲーション要素は画面上に表示されない</span><span class="sxs-lookup"><span data-stu-id="edd49-183">Page to page, same peer group, no on-screen navigation element</span></span></strong>
<p><span data-ttu-id="edd49-184">ユーザーは、同じピア グループでページ間を移動します。</span><span class="sxs-lookup"><span data-stu-id="edd49-184">The user navigates from one page to another with the same peer group.</span></span> <span data-ttu-id="edd49-185">画面に表示されるありませんが ( [NavigationView](../controls-and-patterns/navigationview.md)) などの両方のページに直接的なナビゲーションを提供するナビゲーション要素です。</span><span class="sxs-lookup"><span data-stu-id="edd49-185">There is no on-screen navigation element (such as [NavigationView](../controls-and-patterns/navigationview.md)) that provides direct navigation to both pages.</span></span></p></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-186">はい</span><span class="sxs-lookup"><span data-stu-id="edd49-186">Yes</span></span></strong>
<p><span data-ttu-id="edd49-187">次の図で、ユーザーが、同じピア グループ内の 2 つのページ間を移動し、このナビゲーションはナビゲーション履歴に追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="edd49-187">In the following illustration, the user navigates between two pages in the same peer group, and the navigation should be added to the navigation history.</span></span></p>
<p><img src="images/back-nav/nav-pagetopage-samepeer-noosnavelement.png" alt="Navigation within a peer group" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-188">ページ間、同じピア グループ、画面上に表示されるナビゲーション要素を使う</span><span class="sxs-lookup"><span data-stu-id="edd49-188">Page to page, same peer group, with an on-screen navigation element</span></span></strong>
<p><span data-ttu-id="edd49-189">ユーザーは、同じピア グループ内のページ間を移動します。</span><span class="sxs-lookup"><span data-stu-id="edd49-189">The user navigates from one page to another in the same peer group.</span></span> <span data-ttu-id="edd49-190">[NavigationView](../controls-and-patterns/navigationview.md)など、同じナビゲーション要素は、両方のページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="edd49-190">Both pages are shown in the same navigation element, such as [NavigationView](../controls-and-patterns/navigationview.md).</span></span></p></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-191">場合によって異なります。</span><span class="sxs-lookup"><span data-stu-id="edd49-191">It depends</span></span></strong>
<p><span data-ttu-id="edd49-192">はい、2 つの例外、ナビゲーション履歴に追加します。</span><span class="sxs-lookup"><span data-stu-id="edd49-192">Yes, add to the navigation history, with two notable exceptions.</span></span> <span data-ttu-id="edd49-193">多くの場合、ピア グループ内のページ間を切り替える、アプリのユーザーが予想される場合、またはナビゲーション階層を保持する場合は、次を追加しないでくださいナビゲーション履歴にします。</span><span class="sxs-lookup"><span data-stu-id="edd49-193">If you expect users of your app to switch between pages in the peer group frequently, or if you wish to preserve the navigational hierarchy, then do not add to the navigation history.</span></span> <span data-ttu-id="edd49-194">この場合、ユーザーが戻るボタンを押すと、現在のピア グループに移動する前に表示していた最後のページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="edd49-194">In this case, when the user presses back, go back to the last page before the user navigated to the current peer group.</span></span> </p>
<p><img src="images/back-nav/nav-pagetopage-samepeer-yesosnavelement.png" alt="Navigation across peer groups when a navigation element is present" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-195">一時的な UI の表示</span><span class="sxs-lookup"><span data-stu-id="edd49-195">Show a transient UI</span></span></strong>
<p><span data-ttu-id="edd49-196">アプリは、ダイアログ、スプラッシュ画面、スクリーン キーボードなどのポップアップ ウィンドウや子ウィンドウを表示します。または、アプリが複数選択モードなどの特別なモードに移行します。</span><span class="sxs-lookup"><span data-stu-id="edd49-196">The app displays a pop-up or child window, such as a dialog, splash screen, or on-screen keyboard, or the app enters a special mode, such as multiple selection mode.</span></span></p></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-197">×</span><span class="sxs-lookup"><span data-stu-id="edd49-197">No</span></span></strong>
<p><span data-ttu-id="edd49-198">ユーザーが戻るボタンを押すと、一時的な UI が閉じられ (スクリーン キーボードが非表示になる、ダイアログがキャンセルされるなど)、一時的な UI を生成したページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="edd49-198">When the user presses the back button, dismiss the transient UI (hide the on-screen keyboard, cancel the dialog, etc) and return to the page that spawned the transient UI.</span></span></p>
<p><img src="images/back-nav/back-transui.png" alt="Showing a transient UI" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-199">項目の列挙</span><span class="sxs-lookup"><span data-stu-id="edd49-199">Enumerate items</span></span></strong>
<p><span data-ttu-id="edd49-200">アプリが、マスター/詳細リストで選んだ項目の詳細など、画面上の項目のコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="edd49-200">The app displays content for an on-screen item, such as the details for the selected item in master/details list.</span></span></p></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="edd49-201">×</span><span class="sxs-lookup"><span data-stu-id="edd49-201">No</span></span></strong>
<p><span data-ttu-id="edd49-202">項目の列挙は、ピア グループ内の移動に似ています。</span><span class="sxs-lookup"><span data-stu-id="edd49-202">Enumerating items is similar to navigating within a peer group.</span></span> <span data-ttu-id="edd49-203">ユーザーが戻るボタンを押すと、項目の列挙が表示されている現在のページの前のページに移動されます。</span><span class="sxs-lookup"><span data-stu-id="edd49-203">When the user presses back, navigate to the page that preceded the current page that has the item enumeration.</span></span></p>
<p><img src="images/back-nav/nav-enumerate.png" alt="Iterm enumeration" /></p></td>
</tr>
</tbody>
</table>
</div>

### <a name="resuming"></a><span data-ttu-id="edd49-204">再開</span><span class="sxs-lookup"><span data-stu-id="edd49-204">Resuming</span></span>

<span data-ttu-id="edd49-205">ユーザーが別のアプリに切り替えた後で、元のアプリに戻った場合は、ナビゲーション履歴にある最後のページに戻すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="edd49-205">When the user switches to another app and returns to your app, we recommend returning to the last page in the navigation history.</span></span>

## <a name="related-articles"></a><span data-ttu-id="edd49-206">関連記事</span><span class="sxs-lookup"><span data-stu-id="edd49-206">Related articles</span></span>

- [<span data-ttu-id="edd49-207">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="edd49-207">Navigation basics</span></span>](navigation-basics.md)