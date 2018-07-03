---
author: serenaz
Description: The Universal Windows Platform (UWP) provides a consistent back navigation system for traversing the user's navigation history within an app and, depending on the device, from app to app.
title: ナビゲーション履歴と前に戻る移動 (Windows アプリ)
ms.assetid: e9876b4c-242d-402d-a8ef-3487398ed9b3
isNew: true
label: History and backwards navigation
template: detail.hbs
op-migration-status: ready
ms.author: sezhen
ms.date: 11/22/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 824f0e83408893bf95d856067282b1fea1313876
ms.sourcegitcommit: 588171ea8cb629d2dd6aa2080e742dc8ce8584e5
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/17/2018
ms.locfileid: "1895409"
---
#  <a name="navigation-history-and-backwards-navigation-for-uwp-apps"></a>UWP アプリのナビゲーション履歴と前に戻る移動

> **重要な API**: [BackRequested イベント](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager.BackRequested)、[SystemNavigationManager クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Core.SystemNavigationManager)、[OnNavigatedTo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto#Windows_UI_Xaml_Controls_Page_OnNavigatedTo_Windows_UI_Xaml_Navigation_NavigationEventArgs_)

ユニバーサル Windows プラットフォーム (UWP) では、アプリのユーザーのナビゲーションの履歴内の移動や、デバイスによってはアプリ間の移動について、一貫性のある "戻る" ナビゲーション システムを提供します。

アプリに前に戻る移動を実装するには、アプリの UI の左上隅に[戻るボタン](#Back-button)を配置します。 アプリで [NavigationView](../controls-and-patterns/navigationview.md) コントロールを使用する場合は、[NavigationView の組み込みの戻るボタン](../controls-and-patterns/navigationview.md#backwards-navigation)を使用できます。 

ユーザーは、戻るボタンによって、アプリのナビゲーション履歴における前の場所に戻ることを想定しています。 ナビゲーション履歴に追加するナビゲーション操作の種類、および戻るボタンが押されたときの応答方法は、自由に決めることができます。

## <a name="back-button"></a>[戻る] ボタン

戻るボタンを作成するには、`NavigationBackButtonNormalStyle` スタイルの [Button](../controls-and-patterns/buttons.md) コントロールを使用し、アプリの UI の左上隅にボタンを配置します。

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
<Page x:Class="AppName.MainPage">
...
<Button x:Name="BackButton" Click="Back_Click" Style="{StaticResource NavigationBackButtonNormalStyle}"/>
...
<Page/>
```

分離コード:

```csharp
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

ここでは、`App.xaml` 分離コード ファイルで、[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.BackRequested) イベントのグローバル リスナーを登録しています。 "戻る" ナビゲーションから特定のページを除外する場合や、ページを表示する前にページ レベルのコードを実行する場合は、各ページでこのイベントについて登録できます。

App.xaml 分離コード:

```csharp
Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
Frame rootFrame = Window.Current.Content;
rootFrame.PointerPressed += On_PointerPressed;

private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
{
    e.Handled = On_BackRequested();
}

private void On_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    bool isXButton1Pressed = e.GetCurrentPoint(sender as UIElement).Properties.PointerUpdateKind == PointerUpdateKind.XButton1Pressed;

    if (isXButton1Pressed)
    {
        e.Handled = On_BackRequested();
    }
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

![タイトル バーの戻るボタン](images/nav-back-pc.png)

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
<p>ユーザーは、同じピア グループでページ間を移動します。 両方のページを対象とした直接的なナビゲーションを実現するナビゲーション要素 (上部ナビゲーション ウィンドウや、ドッキングされた左側のナビゲーション ウィンドウなど) は画面に表示されません。</p></td>
<td style="vertical-align:top;"><strong>○</strong>
<p>次の図では、ユーザーは同じピア グループ内の 2 つのページ間を移動します。 ページでは、上部のナビゲーション バーやドッキングされた左側のナビゲーション ウィンドウは使われていません。そのため、このナビゲーションはナビゲーション履歴に追加されます。</p>
<p><img src="images/back-nav/nav-pagetopage-samepeer-noosnavelement.png" alt="Navigation within a peer group" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong>ページ間、同じピア グループ、画面上に表示されるナビゲーション要素を使う</strong>
<p>ユーザーは、同じピア グループ内のページ間を移動します。 両方のページは同じナビゲーション要素に表示されます。 たとえば、両方のページで同じ上部のウィンドウの要素を使っていたり、両方のページがドッキングされた左側のナビゲーション ウィンドウに表示されるとします。</p></td>
<td style="vertical-align:top;"><strong>場合によって異なります。</strong>
<p>はい、ナビゲーション履歴に追加しますが、2 つの注目すべき例外があります。 アプリのユーザーがピア グループ内でページ間を頻繁に切り替えることが予想される場合、またはピア グループのページ内でナビゲーションの状態/履歴を保持する場合は、ナビゲーション履歴に追加しないでください。 この場合、ユーザーが戻るボタンを押すと、現在のピア グループに移動する前に表示していた最後のページに戻ります。 </p>
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