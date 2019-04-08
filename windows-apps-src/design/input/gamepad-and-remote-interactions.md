---
Description: Xbox ゲームパッド、リモート コントロールからの入力にアプリを最適化します。
title: ゲームパッドとリモコンの操作
ms.assetid: 784a08dc-2736-4bd3-bea0-08da16b1bd47
label: Gamepad and remote interactions
template: detail.hbs
isNew: true
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1292051362b9751d41b530f6b47f226d36228252
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592807"
---
# <a name="gamepad-and-remote-control-interactions"></a>ゲームパッドとリモコンの操作

![キーボードとゲームパッドのイメージ](images/keyboard/keyboard-gamepad.jpg)

***多くの相互作用のエクスペリエンスは、ゲーム パッド、リモート制御、およびキーボードの間で共有されます。***

アプリが利用でき、入力の型と同じように、両方の従来入力の種類の Pc、ラップトップ、およびタブレット (マウス、キーボード、タッチ、およびなど) からアクセスできることを確認するユニバーサル Windows プラットフォーム (UWP) アプリケーションの相互作用のエクスペリエンスを構築します。テレビ、Xbox の一般的な*10-foot*ゲームパッド、リモート制御などが発生します。

参照してください[Xbox やテレビの設計](../devices/designing-for-tv.md)で UWP アプリケーションで一般的な設計のガイダンスについて、 *10-foot*が発生します。

## <a name="overview"></a>概要

このトピックでは、について説明しますとする必要があり、について検討する、対話デザイン (またはしないか、プラットフォームの後に次の場合)、ガイダンス、推奨事項、およびに関係なく使用する快適に利用される UWP アプリケーションを構築するための推奨事項を提供デバイス、入力の型またはユーザー機能および設定します。

最後の行で直感的なとで簡単に使用、アプリケーションをする必要があります、 *2 フィート*として、環境が、 *10-foot*環境 (その逆)。 ユーザーの任意のデバイスのサポートは、実行に必要なものに集中明確かつ異質、ナビゲーションは一貫性があり、予測可能なために、コンテンツを配置および最短パスをユーザーに付与の UI を可能します。

> [!NOTE]
> このトピックで示すコード スニペットはほとんどが XAMLで/c# ですが、基本原則と概念はすべての UWP アプリに共通です。 Xbox 向けの HTML/JavaScript UWP アプリを開発している場合は、GitHub の [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) ライブラリを参照することをお勧めします。


## <a name="optimize-for-both-2-foot-and-10-foot-experiences"></a>2 フィートと 10 フィート エクスペリエンスの最適化します。

少なくとも、お勧めします 2 フィートと 10-foot の両方のシナリオで正常に動作することを確認して、アプリケーションをテストすることと、すべての機能が検出および Xbox にアクセスできる[ゲームパッドとリモート制御](#gamepad-and-remote-control)します。

すべての入力デバイス (各ここでは、該当するセクションにリンク) を使用して 2 フィートと 10 フィート エクスペリエンスで使用するためにアプリを最適化する他のいくつかの方法を示します。

> [!NOTE]
> Xbox ゲームパッドとリモコンは、多くの UWP のキーボード動作とエクスペリエンスをサポートして、ために、これらの推奨事項は、両方の入力の種類に適しています。 参照してください[の相互作用をキーボード](keyboard-interactions.md)キーボード情報の詳細。

| 機能        | 説明           |
| -------------------------------------------------------------- |--------------------------------|
| [お客様 xy のところフォーカスのナビゲーションと相互作用](#xy-focus-navigation-and-interaction) | **お客様 xy のところフォーカスのナビゲーション**ユーザーがアプリの UI を移動できるようにします。 ただし、ユーザーの移動は上下左右に制限されます。 このセクションでは、この点に対応するための推奨事項とその他の考慮事項について説明します。 |
| [マウス モード](#mouse-mode)|お客様 xy のところフォーカスのナビゲーションは、実用的でも、可能性もいくつかの種類のマップまたは描画とペイント アプリなどのアプリケーションがありません。 このような場合は、**マウス モード**ゲームパッドまたはリモート コントロール、ユーザーが自由に移動できますが、PC 上のマウスと同様です。|
| [フォーカス ビジュアル](#focus-visual)  | フォーカスのビジュアルでは、現在フォーカスがある UI 要素を強調表示する罫線です。 これにより、ユーザーの間の移動またはとの対話は、UI をすばやく識別できます。  |
| [フォーカス engagement](#focus-engagement) | フォーカス engagement には、キーを押すユーザーが必要があります、**する/選択**ゲームパッドまたは UI 要素にフォーカスがある場合は、対話するために、リモート コントロールのボタン。 |
| [ハードウェア ボタン](#hardware-buttons) | ゲームパッド、リモート_コントロールは、非常にさまざまなボタンと構成を提供します。 |

## <a name="gamepad-and-remote-control"></a>ゲームパッドとリモート制御

PC でキーボードやマウス、電話とタブレットでタッチを使うように、10 フィート エクスペリエンスではゲームパッドとリモコンがメイン入力デバイスになります。
このセクションでは、ハードウェア ボタンとはどのようなもので何に使うかについて説明します。
「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」と「[マウス モード](#mouse-mode)」では、これらの入力デバイスを使うときにアプリを最適化する方法について学びます。

設定なしの場合のゲームパッドとリモコンの動作の品質は、アプリでキーボードがどの程度サポートされているかによって異なります。 アプリがゲームパッドとリモコンでうまく動作することを確認する良い方法は、アプリが PC でキーボードを使ってうまく動作するか確認してから、ゲームパッドとリモコンでテストして UI で不十分な箇所を見つけることです。

### <a name="hardware-buttons"></a>ハードウェア ボタン

このドキュメントでは、次の図に示すボタン名を使っています。

![ゲームパッドとリモコンのボタンの図](images/designing-for-tv/hardware-buttons-gamepad-remote.png)

図からわかるように、ゲームパッドでサポートされているボタンのいくつかはリモコンでサポートされておらず、逆に、リモコンでサポートされているボタンのいくつかはゲームパッドでサポートされていません。 1 つの入力デバイスのみでサポートされているボタンを使って UI の移動を速くすることもできますが、そのようなボタンを重要な操作に使うように設計してしまうと、ユーザーが一部の UI を操作できなくなる可能性があることに注意してください。

次の表に、UWP アプリでサポートされているすべてのハードウェア ボタンと、各ボタンがサポートされている入力デバイスを示します。

| Button                    | ゲームパッド   | リモコン    |
|---------------------------|-----------|-------------------|
| A/[選択] ボタン           | 〇       | 〇               |
| B/[戻る] ボタン             | 〇       | 〇               |
| 方向パッド   | 〇       | 〇               |
| メニュー ボタン               | 〇       | 〇               |
| 表示ボタン               | 〇       | 〇               |
| X ボタン、Y ボタン           | 〇       | X                |
| 左スティック                | 〇       | X                |
| 右スティック               | 〇       | いいえ                |
| 左トリガー、右トリガー   | 〇       | いいえ                |
| L ボタン、R ボタン    | 〇       | X                |
| OneGuide ボタン           | X        | 〇               |
| [音量] ボタン             | X        | 〇               |
| チャネル ボタン            | X        | 〇               |
| メディア コントロール ボタン     | X        | 〇               |
| [ミュート] ボタン               | X        | 〇               |

### <a name="built-in-button-support"></a>組み込みボタンのサポート

UWP は、既存のキーボード入力動作をゲームパッドとリモコンの入力に自動的にマップします。 次の表に、これらの組み込みのマッピングを示します。

| キーボード              | ゲームパッド/リモコン                        |
|-----------------------|---------------------------------------|
| 方向キー            | 方向パッド (ゲームパッドの左スティックも同じ)    |
| Space キー              | A/[選択] ボタン                       |
| 以下に                 | A/[選択] ボタン                       |
| Esc キー                | B/[戻る] ボタン*                        |

\*どちらの場合、 [KeyDown](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.keydown)も[KeyUp](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.keyup) B ボタンのイベントは、アプリによって処理されます、 [SystemNavigationManager.BackRequested](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.backrequested)をする、イベントは発生します。背面に、アプリ内のナビゲーションが発生します。 ただし、次のコード スニペットのように、これを自分で実装する必要があります。

```csharp
// This code goes in the MainPage class

public MainPage()
{
    this.InitializeComponent();

    // Handling Page Back navigation behaviors
    SystemNavigationManager.GetForCurrentView().BackRequested +=
        SystemNavigationManager_BackRequested;
}

private void SystemNavigationManager_BackRequested(
    object sender,
    BackRequestedEventArgs e)
{
    if (!e.Handled)
    {
        e.Handled = this.BackRequested();
    }
}

public Frame AppFrame { get { return this.Frame; } }

private bool BackRequested()
{
    // Get a hold of the current frame so that we can inspect the app back stack
    if (this.AppFrame == null)
        return false;

    // Check to see if this is the top-most page on the app back stack
    if (this.AppFrame.CanGoBack)
    {
        // If not, set the event to handled and go back to the previous page in the
        // app.
        this.AppFrame.GoBack();
        return true;
    }
    return false;
}
```

> [!NOTE]
> B ボタンを使用して戻る場合は、UI に [戻る] ボタンを表示しないでください。 [ナビゲーション ビュー](../controls-and-patterns/navigationview.md) を使用している場合、[戻る] ボタンは自動的に非表示になります。 前に戻る移動の詳細については、「[UWP アプリのナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。

Xbox One の UWP アプリでは、**メニュー** ボタンを押してコンテキスト メニューを開く操作もサポートされています。 詳しくは、「[CommandBar と ContextFlyout](#commandbar-and-contextflyout)」をご覧ください。

### <a name="accelerator-support"></a>アクセラレータのサポート

アクセラレータ ボタンは、UI でナビゲーションを高速化するために使うことができます。 ただし、これらのボタンは特定の入力デバイスにしかない可能性があるため、すべてのユーザーが機能を使用できるとは限らないことに注意してください。 事実、現在 Xbox One で UWP アプリのアクセラレータ機能をサポートしている入力デバイスは、ゲームパッドだけです。

次の表に、UWP に組み込まれているアクセラレータのサポートと自分で実装することができるアクセラレータのサポートを示します。 一貫性のあるわかりやすいユーザー エクスペリエンスを提供するために、これらの動作をカスタム UI で利用してください。

| 操作   | キーボード/マウス   | ゲームパッド      | 組み込み済み:  | 推奨: |
|---------------|------------|--------------|----------------|------------------|
| ページ アップ/ダウン  | ページ アップ/ダウン | 左/右トリガー | [CalendarView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CalendarView)、[ListBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListBox)、[ListViewBase](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListViewBase)、[ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView)、`ScrollViewer`、[Selector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.Selector)、[LoopingSelector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.LoopingSelector)、[ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、[FlipView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView) | 垂直スクロールをサポートするビュー
| ページの左/右 | なし | L/R ボタン | [Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)、[ListBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListBox)、[ListViewBase](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListViewBase)、[ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView)、`ScrollViewer`、[Selector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.Selector)、[LoopingSelector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.LoopingSelector)、[FlipView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView) | 水平スクロールをサポートするビュー
| ズーム イン/アウト        | Ctrl + 正符号 (+)/マイナス記号 (-) | 左/右トリガー | なし | `ScrollViewer`、拡大縮小をサポートするビュー |
| ナビゲーション ウィンドウを開く/閉じる | なし | ビュー | なし | ナビゲーション ウィンドウ |
| [検索](#search-experience) | なし | Y ボタン | なし | アプリのメインの検索機能へのショートカット |
| [コンテキスト メニューを開く](#commandbar-and-contextflyout) | 右クリック | メニュー ボタン | [ContextFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout) | コンテキスト メニュー |

## <a name="xy-focus-navigation-and-interaction"></a>XY フォーカス ナビゲーションと操作

アプリがキーボードの適切なフォーカス ナビゲーションをサポートしている場合、ゲームパッドとリモコンでも適切にサポートされます。
方向キーを使ったナビゲーションは**方向パッド** (とゲームパッドの**左スティック**) にマップされ、UI 要素の対話式操作は **Enter/[選択]** キーにマップされます (「[ゲームパッドとリモコン](#gamepad-and-remote-control)」を参照してください)。

多くのイベントやプロパティがキーボードとゲームパッドの両方で使用されます。キーボードとゲームパッドはいずれも `KeyDown` イベントと `KeyUp` イベントを発生させ、`IsTabStop="True"` プロパティと `Visibility="Visible"` プロパティを持つコントロール間のみを移動します。 キーボードの設計ガイダンスについては、「[キーボード操作](../input/keyboard-interactions.md)」をご覧ください。

キーボードのサポートが適切に実装されている場合、アプリはかなり適切に機能します。ただし、すべてのシナリオをサポートするためには追加の作業が必要になります。 最適なユーザー エクスペリエンスを提供するために、アプリ固有のニーズについて考えてください。

> [!IMPORTANT]
> マウス モードは、Xbox One で実行されている UWP アプリでは既定で有効です。 マウス モードを無効にし、XY フォーカス ナビゲーションを有効にするには、`Application.RequiresPointerMode=WhenRequested` を設定します。

### <a name="debugging-focus-issues"></a>フォーカスの問題のデバッグ

[FocusManager.GetFocusedElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager.getfocusedelement) メソッドによって、現在、どの要素にフォーカスがあるかがわかります。 これは、フォーカス表示の場所が明確ではない場合に便利です。 この情報は、Visual Studio の出力ウィンドウに次のように記録できます。

```csharp
page.GotFocus += (object sender, RoutedEventArgs e) =>
{
    FrameworkElement focus = FocusManager.GetFocusedElement() as FrameworkElement;
    if (focus != null)
    {
        Debug.WriteLine("got focus: " + focus.Name + " (" +
            focus.GetType().ToString() + ")");
    }
};
```

XY ナビゲーションが期待どおりに動作しない場合の一般的な理由には、次の 3 つがあります。

* [IsTabStop](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istabstop) プロパティまたは [Visibility](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.visibility) プロパティが正しく設定されていません。
* フォーカスを取得するコントロールが、実際には想定以上の大きさです。XY ナビゲーションでは、関心のあるものをレンダリングするコントロールの部分だけでなく、コントロールの合計サイズ ([ActualWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.actualwidth) と [ActualHeight](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.actualheight)) が考慮されます。
* フォーカス対応コントロールが別のコントロールの上に配置されています。XY ナビゲーションでは、重なり合ったコントロールはサポートされません。

これらの問題を解決しても XY ナビゲーションが引き続き機能しない場合は、「[既定のナビゲーションのオーバーライド](#overriding-the-default-navigation)」で説明されている方法を使って、フォーカスを取得する要素を手動で指定できます。

XY ナビゲーションは意図したとおりに動作するが、フォーカス表示が表示されない場合は、次のいずれかの問題が原因である可能性があります。

* コントロールを再テンプレート化しましたが、フォーカス表示を含めていませんでした。 `UseSystemFocusVisuals="True"` を設定するか、フォーカス表示を手動で追加します。
* `Focus(FocusState.Pointer)` を呼び出してフォーカスを移動しました。 [FocusState](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.FocusState) パラメーターによって、フォーカス表示の処理を制御できます。 一般的には、これを `FocusState.Programmatic` に設定してください。これにより、フォーカスが以前に表示されていた場合は表示され、以前に非表示であった場合は非表示になります。

このセクションの残りの部分では、XY ナビゲーションを使用する場合の一般的な設計上の課題と、その解決方法のいくつかについて詳しく説明します。

### <a name="inaccessible-ui"></a>アクセスできない UI

XY フォーカス ナビゲーションはユーザーの動作を上下左右への移動に制限しているため、UI の一部にアクセスできなくなる可能性があります。
次の図は、XY フォーカス ナビゲーションでサポートされていない UI レイアウトの例を示します。
垂直および水平方向ナビゲーションが優先され、中央の要素はフォーカスを獲得できるほど優先順位が高くないため、ゲームパッド/リモコンを使って中央の要素にアクセスできないことに注意してください。

![4 隅の要素と、アクセスできない中央の要素](images/designing-for-tv/2d-navigation-best-practices-ui-layout-to-avoid.png)

何らかの理由で UI の配置を変更できない場合は、次のセクションで説明する手法のいずれかを使って、フォーカスの既定の動作をオーバーライドします。

### <a name="overriding-the-default-navigation"></a>既定のナビゲーションのオーバーライド 

ユニバーサル Windows プラットフォームは、方向パッド/左スティックによるナビゲーションがユーザーにとって意味のあるものであることを確認しようとしますが、アプリの目的に沿って最適化された動作を保証することはできません。
ナビゲーションがアプリ用に最適化されていることを確認する最善の方法は、ゲームパッドを使ってナビゲーションをテストし、アプリのシナリオにとって適切な方法でユーザーがすべての UI 要素にアクセスできることを確認することです。 アプリのシナリオで、提供されている XY フォーカス ナビゲーションでは実現できない動作が必要となる場合は、次のセクションの推奨事項に従ったり、動作をオーバーライドして適切な項目にフォーカスを設定したりことを検討してください。

次のコード スニペットは、XY フォーカス ナビゲーションの動作をオーバーライドする方法を示しています。

```xml
<StackPanel>
    <Button x:Name="MyBtnLeft"
            Content="Search" />
    <Button x:Name="MyBtnRight"
            Content="Delete"/>
    <Button x:Name="MyBtnTop"
            Content="Update" />
    <Button x:Name="MyBtnDown"
            Content="Undo" />
    <Button Content="Home"  
            XYFocusLeft="{x:Bind MyBtnLeft}"
            XYFocusRight="{x:Bind MyBtnRight}"
            XYFocusDown="{x:Bind MyBtnDown}"
            XYFocusUp="{x:Bind MyBtnTop}" />
</StackPanel>
```

この場合、フォーカスが `Home` ボタンにある状態でユーザーが左に移動すると、フォーカスは `MyBtnLeft` ボタンに移ります。ユーザーが右に移動すると、フォーカスは `MyBtnRight` ボタンに移ります (以下、同様です)。

フォーカスが特定の方向でコントロールから移動することを防ぐには、`XYFocus*` プロパティを使ってそのコントロールで方向を指定します。

```xml
<Button Name="HomeButton"  
        Content="Home"  
        XYFocusLeft ="{x:Bind HomeButton}" />
```

これらの `XYFocus` プロパティを使用して、コントロールの親は、次のフォーカスの候補がビジュアル ツリー外である場合、子のナビゲーションを強制することができます。ただし、フォーカスを持つ子が同じ `XYFocus` プロパティを使用している場合を除きます。

```xml
<StackPanel Orientation="Horizontal" Margin="300,300">
    <UserControl XYFocusRight="{x:Bind ButtonThree}">
        <StackPanel>
            <Button Content="One"/>
            <Button Content="Two"/>
        </StackPanel>
    </UserControl>
    <StackPanel>
        <Button x:Name="ButtonThree" Content="Three"/>
        <Button Content="Four"/>
    </StackPanel>
</StackPanel>
```

上記のサンプルでは、フォーカスが `Button` Two にあり、ユーザーが右に移動した場合、最適なフォーカスの候補は `Button` Four ですが、フォーカスは `Button` Three に移動します。これは、親の `UserControl` で、ビジュアル ツリー外である場合はその場所に移動するように強制されているためです。

### <a name="path-of-least-clicks"></a>最小回数のクリック数

ユーザーが最も一般的なタスクを最小クリック回数で実行できるようにしてください。 次の例では、(最初にフォーカスがある) **再生**ボタンとよく使われる要素の間に [TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) が配置されているため、優先順位の高いタスクの間に不要な要素が入り込んでいます。

![ナビゲーションのベスト プラクティスは最小限のクリックのパスを提供すること](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks.png)

次の例では、[TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) は**再生**ボタンの上に配置されています。
優先順位の高いタスクの間に不要な要素が配置されないように UI を並べ替えるだけで、アプリの操作性が大幅に向上します。

![優先順位の高いタスクの間から再生ボタンの上に移動した TextBlock](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks-2.png)

### <a name="commandbar-and-contextflyout"></a>CommandBar と ContextFlyout

使用する場合、 [CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar)で説明したように、一覧をスクロールの問題に留意[問題。UI 要素が時間の長いスクロール リスト/グリッドの後にある](#problem-ui-elements-located-after-long-scrolling-list-grid)します。 次の図は、`CommandBar` がリストやグリッドの下にある UI レイアウトです。 ユーザーはリストやグリッド全体をスクロールしなければ `CommandBar` に到達できません。

![リストやグリッドの下にある CommandBar](images/designing-for-tv/2d-navigation-best-practices-commandbar-and-contextflyout.png)

配置する場合、 `CommandBar` *上*リスト/グリッドでしょうか。 リストやグリッドを下へスクロールしたユーザーは `CommandBar` に戻るために上へスクロールして戻る必要がありますが、前の構成よりもナビゲーションはわずかに少なくなります。 ただし、これは、アプリの最初のフォーカスが `CommandBar` の横または上に配置されている場合です。最初のフォーカスがリストやグリッドの下にある場合、この方法はうまく機能しません。 これらの `CommandBar` 項目があまりアクセスする必要のないグローバルな操作の項目の場合 (**同期** ボタンなど)、リストやグリッドの上に置いても問題ありません。

`CommandBar` の項目を縦方向に重ねることはできませんが、UI レイアウトで適切な場合はスクロール方向と異なる向き (たとえば、縦方向にスクロールするリストの左右や、横方向にスクロールするリストの上下) に項目を配置することも検討できます。

ユーザーが項目に簡単にアクセスできる必要がある `CommandBar` をアプリで使う場合、それらの項目を [ContextFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout) 内に配置して `CommandBar` から削除することを検討できます。 `ContextFlyout` プロパティである[UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement)であり、[コンテキスト メニュー](../controls-and-patterns/dialogs-and-flyouts/index.md)その要素に関連付けられています。 PC では、`ContextFlyout` を持つ要素を右クリックすると、そのコンテキスト メニューがポップアップ表示されます。 Xbox One では、このような要素にフォーカスがあるときに**メニュー** ボタンを押すと、コンテキスト メニューがポップアップ表示されます。

### <a name="ui-layout-challenges"></a>UI レイアウトの問題

XY フォーカス ナビゲーションの特性により、一部の UI レイアウトは設定が難しく、状況ごとに評価が必要です。 "正解" は 1 つではなく、どの解決策を選ぶかはアプリのニーズ次第ですが、優れたテレビ エクスペリエンスを提供するために利用できる方法がいくつかあります。

このことをさらに理解するために、架空のアプリでこれらの問題のいくつかとそれを克服する手法を見てみましょう。

> [!NOTE]
> この架空のアプリは、UI の問題とその解決策を示すことを目的としており、実際のアプリの最適なユーザー エクスペリエンスを示すものではありません。

次の架空の不動産アプリは、販売中の家の一覧、地図、不動産の説明などの情報を表示するものです。 このアプリでは、次の方法で克服できる 3 つの課題が生じます。

- [UI の再配置](#ui-rearrange)
- [フォーカス engagement](#engagement)
- [マウス モード](#mouse-mode)

![架空の不動産アプリ](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app.png)

#### 問題: 時間スクロール リスト/グリッドの後にある UI 要素 <a name="problem-ui-elements-located-after-long-scrolling-list-grid"></a>

次の図に示すプロパティの [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) は、非常に長いスクロールをするリストです。 この `ListView` で[エンゲージメント](#focus-engagement)が要求され*ない*場合、ユーザーがリストに移動するとフォーカスはリストの最初の項目に設定されます。 ユーザーが **[前へ]** または **[次へ]** ボタンにアクセスするには、リスト内のすべての項目を移動する必要があります。 このような、リスト全体を移動する必要がある設計は、ユーザーがそのエクスペリエンスを許容できるほどリストが短くなければ煩わしくなるため、その他のオプションを検討することをお勧めします。

![不動産アプリ: 50 個の項目があるリストは、下のボタンに移動するまでに 51 回のクリックが必要](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app-list.png)

#### <a name="solutions"></a>解決策

**UI の再配置 <a name="ui-rearrange"></a>**

最初のフォーカスがページの下部に設定されない限り、通常、長いスクロールをするリストの上に配置した UI 要素の方が、下に配置した場合よりも簡単にアクセスできます。
この新しいレイアウトが他のデバイスでも有効な場合、Xbox One のためだけに UI に特別な変更を行うのでなく、すべてのデバイス ファミリ用にレイアウトを変更する方が、低コストのアプローチになる可能性があります。
また、スクロール方向と異なる向き (縦方向にスクロールするリストでは横方向、横方向にスクロールするリストでは縦方向) に UI 要素を配置すると、アクセシビリティがさらに向上します。

![不動産アプリ: 長いスクロールをするリストの上にボタンを配置](images/designing-for-tv/2d-focus-navigation-and-interaction-ui-rearrange.png)

**フォーカス engagement <a name="engagement"></a>**

エンゲージメントが*要求される*場合、`ListView` 全体が 1 つのフォーカスの対象になります。 ユーザーはリストの内容をバイパスして、フォーカス可能な次の要素にアクセスできます。 エンゲージメントをサポートしているコントロールとその使用方法について詳しくは、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。

![不動産アプリ: エンゲージメントの要求を設定して 1 クリックのみで [前へ]/[次へ] ボタンにアクセス](images/designing-for-tv/2d-focus-navigation-and-interaction-engagement.png)

#### <a name="problem-scrollviewer-without-any-focusable-elements"></a>問題: フォーカスを設定できる任意の要素を使用せずに ScrollViewer

XY フォーカス ナビゲーションは、フォーカス可能な UI 要素に 1 回で移動できることを前提としているため、フォーカス可能な要素を 1 つも含まない [ScrollViewer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer) (この例ではテキストのみの要素) は、ユーザーが `ScrollViewer` のすべてのコンテンツを表示することができない状況を招く可能性があります。
この問題の解決策とその他の関連するシナリオについては、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。

![不動産アプリ:テキストのみのある ScrollViewer](images/designing-for-tv/2d-focus-navigation-and-interaction-scrollviewer.png)

#### <a name="problem-free-scrolling-ui"></a>問題: 無料のスクロール UI

描画面や次の例にある地図など、アプリに自由スクロール UI が必要な場合、XY フォーカス ナビゲーションのみでは機能しません。
このような場合は、[マウス モード](#mouse-mode)をオンにして、ユーザーが UI 要素内を自由に移動できるようにします。

![マウス モードを使う地図の UI 要素](images/designing-for-tv/map-mouse-mode.png)

## <a name="mouse-mode"></a>[マウス モード]

「[XY フォーカス ナビゲーションと対話式操作](#xy-focus-navigation-and-interaction)」で説明するとおり、Xbox One でフォーカスを移動するには、XY ナビゲーション システムを使います。ユーザーは、フォーカスを上下左右に動かしてコントロール間を移動できます。
ただし、[WebView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.WebView) や [MapControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Maps.MapControl) などの一部のコントロールでは、ユーザーがコントロールの境界内でポインターを自由に動かせる、マウスのような対話式操作が必要です。
また、ユーザーがページ全体でポインターを動かせるようにして、PC でマウスを使うときと同じようなエクスペリエンスをゲームパッド/リモコンで体験できるようにする必要があるアプリもあります。

このような場合、ページ全体に対して、または、ページ内のいずれかのコントロールに対して、ポインター (マウス モード) を要求する必要があります。
たとえば、アプリのページで `WebView` コントロールを使い、そのコントロール内ではマウス モード、それ以外はすべて XY フォーカス ナビゲーションを使うことができます。
ポインターを要求する場合、**コントロールまたはページが有効になったとき**、または**ページにフォーカスがあるとき**のどちらでポインターを要求するかを指定できます。

> [!NOTE]
> コントロールにフォーカスがある場合にポインターを要求することはサポートされていません。

Xbox One で実行されている XAML アプリとホスト型 Web アプリのいずれの場合も、マウス モードがアプリ全体で既定で有効になっています。 これを無効にして、XY ナビゲーション用にアプリを最適化することを強くお勧めします。 これを行うには、`Application.RequiresPointerMode` プロパティを `WhenRequested` に設定して、コントロールやページから呼び出された場合にのみマウス モードを有効にします。

XAML アプリでこれを行うには、`App` クラスで次のコードを使います。

```csharp
public App()
{
    this.InitializeComponent();
    this.RequiresPointerMode =
        Windows.UI.Xaml.ApplicationRequiresPointerMode.WhenRequested;
    this.Suspending += OnSuspending;
}
```

HTML/JavaScript のサンプル コードなどの詳細情報については、「[マウス モードを無効にする方法](../../xbox-apps/how-to-disable-mouse-mode.md)」をご覧ください。

次の図は、マウス モードでのゲームパッド/リモコンのボタンのマッピングを示しています。

![マウス モードでのゲームパッド/リモコンのボタンのマッピング](images/designing-for-tv/10ft_infographics_mouse-mode.png)

> [!NOTE]
> マウス モードは Xbox One のゲームパッド/リモコンのみでサポートされています。 その他のデバイス ファミリや入力タイプでは自動的に無視されます。

コントロールまたはページでマウス モードをアクティブ化するには、そのコントロールまたはページで [RequiresPointer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.requirespointer) プロパティを使います。 このプロパティには `Never` (既定値)、`WhenEngaged`、`WhenFocused` の 3 つの値があります。

### <a name="activating-mouse-mode-on-a-control"></a>コントロールでのマウス モードのアクティブ化

`RequiresPointer="WhenEngaged"` の状態でユーザーがコントロールを使うと、ユーザーが解除するまでコントロールでマウス モードがアクティブ化されます。 次のコード スニペットは、使用時にマウス モードをアクティブ化する単純な `MapControl` を示します。

```xml
<Page>
    <Grid>
        <MapControl IsEngagementRequired="true"
                    RequiresPointer="WhenEngaged"/>
    </Grid>
</Page>
```

> [!NOTE]
> コントロールを使うときにマウス モードをアクティブ化する場合、`IsEngagementRequired="true"` も指定する必要があります。そうしないと、マウス モードがアクティブ化されません。

コントロールがマウス モードになると、そのコントロールの入れ子になったコントロールもマウス モードになります。 その子の要求モードは無視されます。親をマウス モードにして子はマウス モードにしないということはできません。

また、コントロールの要求モードはフォーカスがあるときにのみ調べられます。そのため、フォーカスがある間はモードは動的に変更されません。

### <a name="activating-mouse-mode-on-a-page"></a>ページでのマウス モードのアクティブ化

ページに `RequiresPointer="WhenFocused"` プロパティを設定している場合、フォーカスがあるとページ全体に対してマウス モードがアクティブ化されます。 次のコード スニペットは、ページでこのプロパティを設定する方法を示しています。

```xml
<Page RequiresPointer="WhenFocused">
    ...
</Page>
```

> [!NOTE]
> `WhenFocused` の値は [Page](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page) オブジェクトでのみサポートされています。 コントロールにこの値を設定しようとすると、例外がスローされます。

### <a name="disabling-mouse-mode-for-full-screen-content"></a>全画面コンテンツのマウス モードの無効化

通常、全画面表示でビデオやその他の種類のコンテンツを表示する場合、ユーザーの注意をそらす可能性があるため、カーソルを非表示にします。 このシナリオは、アプリの他の部分ではマウス モードを使用するが、全画面コンテンツを表示するときはマウス モードを無効にする必要がある場合に発生します。 これを実現するには、全画面コンテンツを独自の `Page` に配置し、次の手順に従います。

1. `App` オブジェクトで、`RequiresPointerMode="WhenRequested"` を設定します。
2. 全画面表示の `Page` を*除く*すべての `Page` オブジェクトで、`RequiresPointer="WhenFocused"` を設定します。
3. 全画面表示の `Page` で、`RequiresPointer="Never"` を設定します。

これにより、全画面コンテンツを表示するときに、カーソルは表示されません。

## <a name="focus-visual"></a>フォーカスの視覚効果

フォーカス表示とは、現在フォーカスがある UI 要素を囲む境界線のことです。 この機能を使ってユーザーの現在位置をわかりやすく示すことで、ユーザーが自分の位置を見失わずに UI を移動しやすくなります。

フォーカス表示は、表示が更新され、多数のカスタマイズ オプションが追加されているため、開発者は 1 つのフォーカス表示を用意すれば、PC と Xbox One、さらにはキーボードやゲームパッド/リモコンをサポートするその他の Windows 10 デバイスで正しく動作することを期待できます。

ただし、異なるプラットフォームで同じフォーカス表示を使うことはできますが、10 フィート エクスペリエンスではフォーカス表示の利用状況がやや異なります。 この場合、ユーザーはテレビ画面全体に十分注意を払っていないと想定し、ユーザーが表示を探す際にフラストレーションを感じないように、現在フォーカスのある要素を常に明確に表示することが重要です。

また、フォーカス表示は、ゲームパッドやリモコンを使うときは既定で表示されますが、キーボードを使うときは既定で表示*されない*ことに注意してください。 したがって、実装していなくても Xbox One でアプリを実行すると表示されます。

### <a name="initial-focus-visual-placement"></a>フォーカス表示の初期設定

アプリを起動したりページに移動したりするときは、ユーザーがアクションを実行する最初の要素として意味のある UI 要素にフォーカスを設定します。 たとえば、フォト アプリではギャラリー内の最初の項目にフォーカスを設定し、音楽アプリで曲の詳細ビューに移動する場合は音楽を再生しやすいように再生ボタンにフォーカスを設定できます。

初期フォーカスは、アプリの左上 (右から左へ移動する場合は右上) の領域に設定するようにしてください。 通常、アプリのコンテンツ フローはそこから開始されるため、ほとんどのユーザーは最初にその隅を意識する傾向があります。

### <a name="making-focus-clearly-visible"></a>フォーカスの明確な表示

ユーザーがフォーカスを探さなくても前回の終了位置を選べるように、1 つのフォーカス表示が常に画面に表示されているようにします。 同様に、フォーカス可能な項目を常に画面上に表示する必要があります。たとえば、フォーカス可能な要素がない、テキストのみのポップアップを使わないでください。

このルールの例外は、ビデオの視聴や画像の表示などの全画面表示エクスペリエンスです。この場合、フォーカス表示を行うことは適切ではありません。

### <a name="reveal-focus"></a>表示フォーカス

表示フォーカスは、ユーザーがゲームパッドやキーボードのフォーカスをフォーカス可能な要素 (ボタンなど) に移動したときに、その要素の境界線をアニメーション化する発光効果です。 フォーカス対象要素の境界線周囲でグローをアニメーション化すると、表示フォーカスにより、フォーカスの位置とフォーカスの方向を把握しやすくなります。

既定では、表示フォーカスは無効になっています。 10 フィート エクスペリエンスの場合、アプリ コンストラクターで [Application.FocusVisualKind プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.FocusVisualKind) を設定して表示フォーカスにオプトインする必要があります。

```csharp
    if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox")
    {
        this.FocusVisualKind = FocusVisualKind.Reveal;
    }
```

詳しくは、[表示フォーカス](/windows/uwp/design/style/reveal-focus) のガイダンスをご覧ください。

### <a name="customizing-the-focus-visual"></a>フォーカスの表示のカスタマイズ

フォーカス表示をカスタマイズする場合は、各コントロールのフォーカス表示に関連するプロパティを変更します。 アプリのパーソナル設定に活用できるこのようなプロパティはいくつかあります。

表示状態を使って独自のフォーカス表示を描画することにより、システムが提供するフォーカス表示を除外することもできます。 詳しくは、「[VisualState](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.VisualState)」をご覧ください。

### <a name="light-dismiss-overlay"></a>簡易非表示オーバーレイ

ユーザーが現在ゲーム コントローラーまたはリモコンで操作している UI 要素にユーザーの注意を引きつけるために、アプリが Xbox One で実行されている場合は、UWP ではポップアップ UI 以外の領域をカバーする「スモーク」レイヤーが自動的に追加されます。 このための追加作業は必要ありませんが、UI を設計する際に留意してください。 いずれかの `FlyoutBase` で `LightDismissOverlayMode` プロパティを設定して、スモーク レイヤーを有効または無効にすることができます。既定の設定は `Auto` で、Xbox では有効になり、その他の場所では無効になります。 詳しくは、「[モーダルと簡易非表示](../controls-and-patterns/menus.md)」をご覧ください。

## <a name="focus-engagement"></a>フォーカス エンゲージメント

フォーカス エンゲージメントは、ゲームパッドやリモコンでアプリを操作しやすくするためのものです。

> [!NOTE]
> フォーカス エンゲージメントを設定しても、キーボードなどの他の入力デバイスには影響しません。

[FrameworkElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.FrameworkElement) オブジェクトのプロパティ `IsFocusEngagementEnabled` を `True` に設定すると、コントロールがフォーカス エンゲージメントを要求するよう設定されます。 この場合、コントロールを "獲得" して操作するには、ユーザーが **A/[選択]** ボタンをクリックする必要があります。 終了したら、**B/[戻る]** ボタンをクリックしてコントロールのエンゲージメントを解除すると、コントロールから移動できるようになります。

> [!NOTE]
> `IsFocusEngagementEnabled` は新しい API で、まだ文書化されていません。

### <a name="focus-trapping"></a>フォーカスのトラップ

フォーカスのトラップとは、ユーザーがアプリの UI を移動しようとしているときにコントロール内に "捕まる" ことで、そのコントロールの外に移動することが困難または不可能になることです。

次の例では、フォーカスのトラップが発生する UI を示します。

![水平方向のスライダーの左右のボタン](images/designing-for-tv/focus-engagement-focus-trapping.png)

ユーザーが左のボタンから右のボタンに移動する場合、方向パッド/左スティックの右を 2 回クリックするだけでよいと考えることは論理的です。
しかし、[Slider](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Slider) がエンゲージメントを必要としない場合、ユーザーが最初に右に押したときにフォーカスは `Slider` に移動し、もう一度右に押したときに `Slider` のハンドルが右に移動します。 ユーザーはハンドルを右に動かし続けるだけで、ボタンに移ることはできません。

この問題を回避する方法はいくつかあります。 その 1 つは、「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」の不動産アプリで **[前へ]** ボタンと **[次へ]** ボタンの位置を `ListView` の上に変更する例のように、別のレイアウトを設計することです。 次の図のように、水平方向ではなく垂直方向にコントロールを重ねて配置すると、問題が解決します。

![水平方向のスライダーの上下のボタン](images/designing-for-tv/focus-engagement-focus-trapping-2.png)

これでユーザーは期待どおり、方向パッド/左スティックを上下に押して各コントロールに移動でき、`Slider` にフォーカスがあるときは左右に押して `Slider` ハンドルを動かすことができます。

この問題を解決するためのもう 1 つの方法は、`Slider` でエンゲージメントを要求することです。 `IsFocusEngagementEnabled="True"` を設定すると、次の動作が発生します。

![ユーザーが右側のボタンに移動できるように、スライダーでフォーカス エンゲージメントを要求する](images/designing-for-tv/focus-engagement-slider.png)

`Slider` でフォーカス エンゲージメントを要求すると、ユーザーは方向パッド/左スティックを右に 2 回押すだけで右側のボタンに移動できます。 この解決策は、UI の調整なしで予期する動作を実現できるので便利です。

### <a name="items-controls"></a>項目コントロール

[Slider](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Slider) コントロール以外にもエンゲージメントを要求できるコントロールがあります。

- [リスト ボックス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListBox)
- [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView)
- [GridView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.GridView)
- [FlipView]https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView)

`Slider` コントロールと異なり、これらのコントロールはフォーカスを捕捉しませんが、大量のデータを含めると操作性の問題が生じる可能性があります。 次の例は、大量のデータが含まれる `ListView` です。

![大量のデータと上下のボタンが含まれる ListView](images/designing-for-tv/focus-engagement-list-and-grid-controls.png)

`Slider` の例と同様に、ゲームパッド/リモコンで上のボタンから下のボタンに移動してみましょう。
上ボタンにフォーカスがある状態で方向パッド/スティックを押すと、`ListView` の最初の項目 ("Item 1") にフォーカスが設定されます。
ユーザーがもう一度押すと、下にあるボタンではなく、一覧の次の項目がフォーカスを獲得します。
ボタンに移動するには、ユーザーは `ListView` のすべての項目を移動していく必要があります。
`ListView` に大量のデータが含まれている場合は、この操作に手間がかかり、最適なユーザー エクスペリエンスになりません。

この問題を解決するには、`ListView` でプロパティ `IsFocusEngagementEnabled="True"` を設定し、エンゲージメントを要求します。
この結果、ユーザーは下に押すだけで `ListView` まで迅速にスキップできます。 ただし、一覧にエンゲージメントを設定しないと、一覧をスクロールしたり、一覧から項目を選んだりすることはできません。エンゲージメントを設定するには、フォーカスがある状態で **A/[選択]** ボタンを押します。エンゲージメントを解除するには、**B/[戻る]** ボタンを押します。

![エンゲージメントが要求される ListView](images/designing-for-tv/focus-engagement-list-and-grid-controls-2.png)

#### <a name="scrollviewer"></a>ScrollViewer

これらのコントロールと少し異なる点は、[ScrollViewer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer) です。ScrollViewer には、考慮すべき独自の Quirk があります。 フォーカス可能なコンテンツを含む `ScrollViewer` がある場合、`ScrollViewer` に移動すると既定でフォーカス可能なコンテンツ間を移動できます。 `ListView` の場合と同様に、`ScrollViewer` 以外の場所に移動するには、各項目をスクロールする必要があります。

`ScrollViewer` にフォーカス可能なコンテンツが*ない*場合 (テキストのみが含まれる場合など)、ユーザーが **A/[選択]** ボタンを使って `ScrollViewer` にエンゲージメントを設定できるように、`IsFocusEngagementEnabled="True"` を設定できます。 エンゲージメントの設定後、**方向パッド/左スティック**を使ってテキストをスクロールできます。作業が終わったら、**B/[戻る]** ボタンを押してエンゲージメントを解除できます。

別の方法としては、ユーザーがコントロールにエンゲージメントを設定しなくてすむように `ScrollViewer` で `IsTabStop="True"` を設定します。`ScrollViewer` 内にフォーカス可能な要素がない場合にも、**D パッド/左スティック**を使って、単にフォーカスしてからスクロールできます。

### <a name="focus-engagement-defaults"></a>フォーカス エンゲージメントの既定値

一部のコントロールでは、フォーカスのトラップがよく発生するため、既定の設定でフォーカス エンゲージメントを要求する方が良い場合があります。また、コントロールによっては既定でフォーカス エンゲージメントが無効になっていますが、有効にする方が良い場合があります。 次の表は、これらのコントロールと、既定のフォーカス エンゲージメントの動作を示します。

| コントロール               | フォーカス エンゲージメントの既定値  |
|-----------------------|---------------------------|
| CalendarDatePicker    | オン                        |
| FlipView              | オフ                       |
| GridView              | オフ                       |
| ListBox               | オフ                       |
| ListView              | オフ                       |
| ScrollViewer          | オフ                       |
| SemanticZoom          | オフ                       |
| スライダー                | オン                        |

他のすべての UWP コントロールは、`IsFocusEngagementEnabled="True"` のとき、動作の変更または視覚的な変更はありません。

## <a name="summary"></a>概要

特定のデバイスやエクスペリエンス、用に最適化された UWP アプリケーションを構築することができます。 が、ユニバーサル Windows プラットフォームでは 2 フィートと 10-foot の両方のエクスペリエンスでは入力に関係なく、デバイス間で正常に使用できるアプリを構築することもできます。デバイスまたはユーザーの権限です。 この記事では、推奨事項を使用して、アプリが、テレビと PC の両方で可能な限り適切ことを確認できます。

## <a name="related-articles"></a>関連記事

- [Xbox およびテレビ向け設計](../devices/designing-for-tv.md)
- [ユニバーサル Windows プラットフォーム (UWP) アプリ向けのデバイス入門](index.md)
