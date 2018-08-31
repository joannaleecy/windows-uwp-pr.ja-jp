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
ms.sourcegitcommit: 1e5590dd10d606a910da6deb67b6a98f33235959
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/31/2018
ms.locfileid: "3237204"
---
# <a name="navigation-history-and-backwards-navigation-for-uwp-apps"></a>UWP アプリのナビゲーション履歴と前に戻る移動

> **重要な API**: [BackRequested イベント](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager.BackRequested)、[SystemNavigationManager クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager)、[OnNavigatedTo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_)

ユニバーサル Windows プラットフォーム (UWP) では、アプリのユーザーのナビゲーションの履歴内の移動や、デバイスによってはアプリ間の移動について、一貫性のある "戻る" ナビゲーション システムを提供します。

アプリに前に戻る移動を実装するには、アプリの UI の左上隅に[戻るボタン](#Back-button)を配置します。 アプリで [NavigationView](../controls-and-patterns/navigationview.md) コントロールを使用する場合は、[NavigationView の組み込みの戻るボタン](../controls-and-patterns/navigationview.md#backwards-navigation)を使用できます。

ユーザーは、戻るボタンによって、アプリのナビゲーション履歴における前の場所に戻ることを想定しています。 ナビゲーション履歴に追加するナビゲーション操作の種類、および戻るボタンが押されたときの応答方法は、自由に決めることができます。

## <a name="back-button"></a>[戻る] ボタン

"戻る"ボタンを作成する[ボタン](../controls-and-patterns/buttons.md)コントロールを使用して、`NavigationBackButtonNormalStyle`スタイルを指定し、アプリの UI の左上隅にボタンが配置 (詳細については、次の XAML コード例を参照してください)。

![アプリの UI の左上隅にある [戻る] ボタン](images/back-nav/BackEnabled.png)

```xaml
<Button Style="{StaticResource NavigationBackButtonNormalStyle}"/>
```

アプリに上部 [CommandBar](../controls-and-patterns/app-bars.md) がある場合、高さ 44px の Button コントロールは 48px の AppBarButtons とはぴったり合いません。 不整合を避けるために、Button コントロールの最上部を 48px の境界内部に合わせてください。

![上部のコマンド バーの [戻る] ボタン](images/back-nav/CommandBar.png)

```xaml
<Button VerticalAlignment="Top" HorizontalAlignment="Left" 
Style="{StaticResource NavigationBackButtonNormalStyle}"/>
```

アプリ内で動き回る UI 要素を最小化するために、バックスタックに何もないときに、無効になった戻るボタンを表示します (以下のコード例を参照)。

![[戻る] ボタンの状態](images/back-nav/BackDisabled.png)

## <a name="code-example"></a>コード例

次のコード例は、戻るボタンで前に戻る移動の動作を実装する方法を示しています。 このコードでは、Button の [**Click**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.Click) イベントに応答し、新しいページに移動したときに呼び出される [**OnNavigatedTo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_) でボタンの表示を無効/有効にします。 このコード例では、[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested) イベントのリスナーを登録することで、ハードウェアおよびソフトウェア システムの戻るキーからの入力も処理しています。

```xaml
<!-- MainPage.xaml -->
<Page x:Class="AppName.MainPage">
...
<Button x:Name="BackButton" Click="Back_Click" Style="{StaticResource NavigationBackButtonNormalStyle}"/>
...
<Page/>
```

分離コード:

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

上記を処理します前に戻る単一ページのナビゲーション。 "戻る"ナビゲーションから特定のページを除外するか、ページを表示する前に、ページ レベルのコードを実行する場合は、各ページでのナビゲーションを処理できます。

前に戻るナビゲーションをアプリ全体を処理するで[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested)イベントのグローバル リスナーを登録するが、`App.xaml`コード ビハインド ファイル。

App.xaml 分離コード:

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

## <a name="optimizing-for-different-device-and-form-factors"></a>さまざまなデバイスとフォーム ファクター向けに最適化

この前に戻る移動の設計ガイダンスはすべてのデバイスに適用可能ですが、最適化によってさまざまなデバイスとフォーム ファクターに適したものになります。 これは、さまざまなシェルでサポートされているハードウェアの戻るボタンによっても変わります。

- **電話/タブレット**: ハードウェアまたはソフトウェアの戻るボタンは、携帯電話やタブレットに常に存在しますが、わかりやすくするために　アプリ内の戻るボタンを描画することをお勧めします。
- **デスクトップ/ハブ**: アプリの UI の左上隅にアプリ内の戻るボタンを描画します。
- **Xbox/テレビ**: 不要な UI 要素が追加されるため、戻るボタンは描画しません。 代わりに、ゲームパッドの B ボタンで前に戻ります。

アプリが複数のデバイスで実行される場合は、[Xbox 用の視覚的なカスタム トリガーを作成](../devices/designing-for-tv.md#custom-visual-state-trigger-for-xbox)してボタンの表示/非表示を切り替えます。 NavigationView コントロールでは、Xbox でアプリが実行されている場合に、戻るボタンの表示/非表示が自動的に切り替わります。 

"戻る" ナビゲーションの場合に、次の入力をサポートすることをお勧めします。 (これらの入力の一部はシステム BackRequested でサポートされていないため、別のイベントで処理する必要があります)。

| 入力 | イベント |
| --- | --- |
| Windows の BackSpace キー | BackRequested |
| ハードウェアの戻るボタン | BackRequested |
| シェル タブレット モードの戻るボタン | BackRequested |
| VirtualKey.XButton1 | PointerPressed |
| VirtualKey.GoBack | KeyboardAccelerator.BackInvoked |
| Alt + 左方向キー | KeyboardAccelerator.BackInvoked |

上のコード例は、これらすべての入力を処理する方法を示してます。

## <a name="system-back-behavior-for-backward-compatibilities"></a>下位互換性のためのシステムの戻る動作

以前、UWP アプリは前に戻る移動のために [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility) を使用しました。 この API は下位互換性のためにサポートが継続されますが、タイトル バーの戻るボタンの使用はもうお勧めできません。 代わりに、アプリで独自のアプリ内の戻るボタンを描画してください。

アプリで [AppViewBackButtonVisibility](https://docs.microsoft.com/uwp/api/windows.ui.core.appviewbackbuttonvisibility) の使用を続ける場合は、通常どおり、戻るボタンはタイトル バーの内部にレンダリングされます。

- アプリが**タブがない**場合は、タイトル バーの内部、戻るボタンがレンダリングされます。 "戻る"ボタンの視覚エクスペリエンスとユーザーの操作では、以前のビルドから変更されません。

    ![タイトル バーの戻るボタン](images/nav-back-pc.png)

- アプリが**タブ**のかどうか、戻るボタンは、新しいシステムの戻る内部にレンダリング バー。

    ![戻るボタンのバーに描画されるシステム](images/back-nav/tabs.png)

### <a name="system-back-bar"></a>システムの戻るバー

> [!NOTE]
> "システムの戻るバー"は、公式の名前ではなく説明のみです。

システムの戻るバーは、タブ バンドとアプリのコンテンツ領域の間に挿入されているバンドします。 バンドは、アプリの幅に沿って表示され、左端に戻るボタンが配置されます。 バンドは、戻るボタンの適切なタッチ ターゲットのサイズを確認する 32 ピクセルの高さがあります。

システムの戻るバーは、戻るボタンの可視性に基づいて動的に表示されます。 [戻る] ボタンが表示される場合、システムの戻るバーが挿入され、アプリのコンテンツのタブ バンド 32 ピクセル下に移動します。 [戻る] ボタンを非表示するとき、システムの戻るバーは動的に削除され、アプリのコンテンツ シフトをタブ バンドを満たすために 32 ピクセルです。 上または下に、アプリの UI shift キーを持つを避けるため、[アプリ内の戻るボタン](#back-button)を描画をお勧めします。

[タイトル バーのカスタマイズ](../shell/title-bar.md)は、アプリのタブとシステムの戻るの両方に引き継がバー。 アプリで[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar)、バック グラウンドとフォア グラウンドの色のプロパティを指定するかどうかは、色がタブとシステムの戻るに適用されますバー。

## <a name="guidelines-for-custom-back-navigation-behavior"></a>カスタムの "戻る" ナビゲーションの動作のガイドライン

独自のバック スタック ナビゲーションを提供する場合、エクスペリエンスが他のアプリと一貫している必要があります。 ナビゲーション操作では、次のパターンに従うことをお勧めします。

<div class="mx-responsive-img">
<table>
<thead>
<tr class="header">
<th align="left">ナビゲーション操作</th>
<th align="left">ナビゲーション履歴への追加</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><strong>ページ間、異なるピア グループ</strong></td>
<td style="vertical-align:top;"><strong>○</strong>
<p>この図では、ユーザーはピア グループを横断して、アプリのレベル 1 からレベル 2 に移動します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</p>
<p><img src="images/back-nav/nav-pagetopage-diffpeers-imageonly1.png" alt="Navigation across peer groups" /></p>
<p>次の図では、ユーザーは同じレベルにある 2 つのピア グループの間を移動し、この場合もピア グループを横断します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</p>
<p><img src="images/back-nav/nav-pagetopage-diffpeers-imageonly2.png" alt="Navigation across peer groups" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><strong>ページ間、同じピア グループ、ナビゲーション要素は画面上に表示されない</strong>
<p>ユーザーは、同じピア グループでページ間を移動します。 画面に表示されるありませんが ( [NavigationView](../controls-and-patterns/navigationview.md)) などの両方のページに直接的なナビゲーションを提供するナビゲーション要素です。</p></td>
<td style="vertical-align:top;"><strong>はい</strong>
<p>次の図で、ユーザーが、同じピア グループ内の 2 つのページ間を移動し、このナビゲーションはナビゲーション履歴に追加する必要があります。</p>
<p><img src="images/back-nav/nav-pagetopage-samepeer-noosnavelement.png" alt="Navigation within a peer group" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong>ページ間、同じピア グループ、画面上に表示されるナビゲーション要素を使う</strong>
<p>ユーザーは、同じピア グループ内のページ間を移動します。 [NavigationView](../controls-and-patterns/navigationview.md)など、同じナビゲーション要素は、両方のページが表示されます。</p></td>
<td style="vertical-align:top;"><strong>場合によって異なります。</strong>
<p>はい、2 つの例外、ナビゲーション履歴に追加します。 多くの場合、ピア グループ内のページ間を切り替える、アプリのユーザーが予想される場合、またはナビゲーション階層を保持する場合は、次を追加しないでくださいナビゲーション履歴にします。 この場合、ユーザーが戻るボタンを押すと、現在のピア グループに移動する前に表示していた最後のページに戻ります。 </p>
<p><img src="images/back-nav/nav-pagetopage-samepeer-yesosnavelement.png" alt="Navigation across peer groups when a navigation element is present" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><strong>一時的な UI の表示</strong>
<p>アプリは、ダイアログ、スプラッシュ画面、スクリーン キーボードなどのポップアップ ウィンドウや子ウィンドウを表示します。または、アプリが複数選択モードなどの特別なモードに移行します。</p></td>
<td style="vertical-align:top;"><strong>×</strong>
<p>ユーザーが戻るボタンを押すと、一時的な UI が閉じられ (スクリーン キーボードが非表示になる、ダイアログがキャンセルされるなど)、一時的な UI を生成したページに戻ります。</p>
<p><img src="images/back-nav/back-transui.png" alt="Showing a transient UI" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong>項目の列挙</strong>
<p>アプリが、マスター/詳細リストで選んだ項目の詳細など、画面上の項目のコンテンツを表示します。</p></td>
<td style="vertical-align:top;"><strong>×</strong>
<p>項目の列挙は、ピア グループ内の移動に似ています。 ユーザーが戻るボタンを押すと、項目の列挙が表示されている現在のページの前のページに移動されます。</p>
<p><img src="images/back-nav/nav-enumerate.png" alt="Iterm enumeration" /></p></td>
</tr>
</tbody>
</table>
</div>

### <a name="resuming"></a>再開

ユーザーが別のアプリに切り替えた後で、元のアプリに戻った場合は、ナビゲーション履歴にある最後のページに戻すことをお勧めします。

## <a name="related-articles"></a>関連記事

- [ナビゲーションの基本](navigation-basics.md)