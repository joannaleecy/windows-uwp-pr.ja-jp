---
author: eliotcowley
Description: Design your app so that it looks good and functions well on your television.
title: Xbox およびテレビ向け設計
ms.assetid: 780209cb-3e8a-4cf7-8f80-8b8f449580bf
label: Designing for Xbox and TV
template: detail.hbs
isNew: true
keywords: Xbox, テレビ, 10 フィート エクスペリエンス, ゲームパッド, リモコン, 入力, 操作
ms.author: elcowle
ms.date: 12/5/2017
ms.topic: article
pm-contact: chigy
design-contact: jeffarn
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 098bc97de27d58fdc1d582e0db264ef04f0d3e61
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6182395"
---
# <a name="designing-for-xbox-and-tv"></a>Xbox およびテレビ向け設計

Xbox One とテレビ画面で見栄えよく表示され、適切に機能するようにユニバーサル Windows プラットフォーム (UWP) アプリの設計を行います。

## <a name="overview"></a>概要

ユニバーサル Windows プラットフォームでは、複数の Windows 10 デバイスで魅力的なエクスペリエンスを実現できます。
UWP フレームワークで提供される機能のほとんどは、追加の作業を行わなくても、これらのデバイス間で同じユーザー インターフェイス (UI) をアプリに使用できます。
ただし、Xbox One とテレビ画面で快適に機能するようにアプリを調整し最適化するには、特別な注意事項があります。

ソファーに座りながらゲームパッドやリモコンを使って部屋の反対側にあるテレビを操作することを、**10 フィート エクスペリエンス**といいます。
通常は画面から約 10 フィート (約 3 m) の距離に座るため、このように呼ばれています。
この場合、たとえば PC の操作 (*2 フィート* エクスペリエンスと呼ばれます) には見られない、特有の課題があります。
Xbox One や、コントローラーを使って入力しテレビ画面に出力するその他のデバイス向けアプリを開発している場合、この点を常に意識しておく必要があります。

アプリを 10 フィート エクスペリエンス向けに適切に動作させるためにこの記事のすべての手順が必要なわけではありませんが、手順を理解し、アプリにとって何が適切かを判断することで、アプリ特有のニーズに合わせてカスタマイズされた、優れた 10 フィート エクスペリエンスを提供できます。
10 フィート環境でアプリを使う場合、次のデザイン原則を検討してください。

### <a name="simple"></a>シンプル

10 フィート環境向けのデザインには特有の課題があります。 解像度と視聴距離の点から、ユーザーはあまり多くの情報を処理できない可能性があります。
単純なデザインになるように、ごくシンプルなコンポーネントだけに絞り込むようにしてください。 テレビに表示される情報の量は、デスクトップではなく、携帯電話と同程度にする必要があります。

![Xbox One ホーム画面](images/designing-for-tv/xbox-home-screen.png)

### <a name="coherent"></a>一貫性

10 フィート環境の UWP アプリは、直感的で簡単に使えるようにします。 何がポイントなのかを明快、明確にしてください。
コンテンツの配置を工夫し、コンテンツ間の移動に一貫性を持たせてユーザーが予測できるようにします。 ユーザーが目的の操作を最短で実行できるように配慮しましょう。

![Xbox One 映画アプリ](images/designing-for-tv/xbox-movies-app.png)

_**スクリーンショットに示す映画はすべて、Microsoft 映画 & テレビでご利用いただけます。**_  

### <a name="captivating"></a>魅力的

最もイマーシブで臨場感のあるエクスペリエンスは、大画面で引き出されます。 画面いっぱいに広がる風景、洗練された動作、鮮やかな色使い、生き生きとした文字が、アプリをワンランク上に引き上げます。 大胆で美しいデザインにしましょう。

![Xbox One アバター アプリ](images/designing-for-tv/xbox-avatar-app.png)

### <a name="optimizations-for-the-10-foot-experience"></a>10 フィート エクスペリエンス向けの最適化

ここまで、10 フィート エクスペリエンス向けに優れた UWP アプリを設計する原則を説明しました。次に、アプリを最適化して優れたユーザー エクスペリエンスを提供する具体的な方法について、概要を示します。

| 機能        | 説明           |
| -------------------------------------------------------------- |--------------------------------|
| [ゲームパッドとリモコン](#gamepad-and-remote-control)      | アプリがゲームパッドやリモコンで正しく動作するか確認することは、10 フィート エクスペリエンス向けの最適化で最も重要な手順です。 操作がある程度制限されたデバイスでユーザーの対話式操作エクスペリエンスを最適化できる、ゲームパッドやリモコン固有の改善点がいくつかあります。 |
| [XY フォーカス ナビゲーションと対話式操作](#xy-focus-navigation-and-interaction) | UWP では、ユーザーは **XY フォーカス ナビゲーション**を使ってアプリの UI 内を移動できます。 ただし、ユーザーの移動は上下左右に制限されます。 このセクションでは、この点に対応するための推奨事項とその他の考慮事項について説明します。 |
| [マウス モード](#mouse-mode)|地図や描画サーフェイスなど一部のユーザー インターフェイスでは、XY フォーカス ナビゲーションの使用は不可能または非実用的です。 UWP ではこれらのインターフェイス用に**マウス モード**が用意されており、デスクトップ コンピューターでマウスを操作するように、ゲームパッド/リモコンを使って自由に移動できます。|
| [フォーカス表示](#focus-visual)  | フォーカス表示とは、現在フォーカスがある UI 要素を囲む境界線のことです。 この機能を使ってユーザーの現在位置をわかりやすく示すことで、ユーザーが自分の位置を見失わずに UI を移動しやすくなります。 フォーカスがよく見えないとユーザーが UI 内で自分の位置を見失ってしまい、優れたエクスペリエンスを得られない可能性があります。  |
| [フォーカス エンゲージメント](#focus-engagement) | UI 要素にフォーカス エンゲージメントを設定すると、ユーザーは、対話式操作するために [**A/選択**] ボタンを押す必要があります。 こうすることで、アプリの UI を移動するときのユーザー エクスペリエンスをより良くすることができます。
| [UI 要素のサイズ](#ui-element-sizing)  | ユニバーサル Windows プラットフォームは、[スケーリングと有効ピクセル](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)を使い、視聴距離に合わせて UI をスケーリングします。 サイズについて理解し UI 全体に適用すれば、アプリを 10 フィート環境用に最適化するのに役立ちます。  |
|  [テレビのセーフ エリア](#tv-safe-area) | UWP は既定で、テレビのセーフ エリア以外の領域 (画面の端に近い部分) に UI を表示することを自動的に避けます。 ただし、この場合、アスペクト比が変わり、UI がレターボックス化されてしまいます。 テレビでイマーシブなアプリにするには、サポートしているテレビで、画面の端まで広がるようにアプリを変更します。 |
| [カラー](#colors)  |  UWP は配色テーマをサポートしています。システム テーマを引き継ぐアプリは、Xbox One では既定で**濃色**になります。 アプリに特定の配色テーマがある場合、テレビではうまく表示されないために一部の色を避ける必要があることに注意してください。 |
| [サウンド](../style/sound.md)    | サウンドは、ユーザーを没頭させたりユーザーにフィードバックを提供したりする上で役立ち、10 フィート エクスペリエンスで重要な役割を果たします。 UWP には、アプリが Xbox One で実行されているときは一般的なコントロールのサウンドを自動的に有効にする機能があります。 UWP に組み込まれているサウンド サポートの詳細とその活用方法について説明します。    |
| [UI コントロールのガイドライン](#guidelines-for-ui-controls)  |  いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。 10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。 |
| [Xbox のカスタム表示状態トリガー](#custom-visual-state-trigger-for-xbox) | UWP アプリを 10 フィート エクスペリエンス用にカスタマイズする場合、カスタム*表示状態トリガー*を使用して、アプリが Xbox コンソールで起動されたことを検出したときにアプリのレイアウトが変わるようにすることをお勧めします。

> [!NOTE]
> このトピックで示すコード スニペットはほとんどが XAMLで/c# ですが、基本原則と概念はすべての UWP アプリに共通です。 Xbox 向けの HTML/JavaScript UWP アプリを開発している場合は、GitHub の [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) ライブラリを参照することをお勧めします。

## <a name="gamepad-and-remote-control"></a>ゲームパッドとリモコン

PC でキーボードやマウス、電話とタブレットでタッチを使うように、10 フィート エクスペリエンスではゲームパッドとリモコンがメイン入力デバイスになります。
このセクションでは、ハードウェア ボタンとはどのようなもので何に使うかについて説明します。
「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」と「[マウス モード](#mouse-mode)」では、これらの入力デバイスを使うときにアプリを最適化する方法について学びます。

設定なしの場合のゲームパッドとリモコンの動作の品質は、アプリでキーボードがどの程度サポートされているかによって異なります。 アプリがゲームパッドとリモコンでうまく動作することを確認する良い方法は、アプリが PC でキーボードを使ってうまく動作するか確認してから、ゲームパッドとリモコンでテストして UI で不十分な箇所を見つけることです。

### <a name="hardware-buttons"></a>ハードウェア ボタン

このドキュメントでは、次の図に示すボタン名を使っています。

![ゲームパッドとリモコンのボタンの図](images/designing-for-tv/hardware-buttons-gamepad-remote.png)

図からわかるように、ゲームパッドでサポートされているボタンのいくつかはリモコンでサポートされておらず、逆に、リモコンでサポートされているボタンのいくつかはゲームパッドでサポートされていません。 1 つの入力デバイスのみでサポートされているボタンを使って UI の移動を速くすることもできますが、そのようなボタンを重要な操作に使うように設計してしまうと、ユーザーが一部の UI を操作できなくなる可能性があることに注意してください。

次の表に、UWP アプリでサポートされているすべてのハードウェア ボタンと、各ボタンがサポートされている入力デバイスを示します。

| ボタン                    | ゲームパッド   | リモコン    |
|---------------------------|-----------|-------------------|
| A/[選択] ボタン           | ○       | ○               |
| B/[戻る] ボタン             | ○       | ○               |
| 方向パッド   | ○       | ○               |
| メニュー ボタン               | ○       | ○               |
| ビュー ボタン               | ○       | ○               |
| X ボタン、Y ボタン           | ○       | ×                |
| 左スティック                | ○       | ×                |
| 右スティック               | ○       | ×                |
| 左トリガー、右トリガー   | ○       | ×                |
| L ボタン、R ボタン    | ○       | ×                |
| OneGuide ボタン           | ×        | ○               |
| [音量] ボタン             | ×        | ○               |
| チャネル ボタン            | ×        | ○               |
| メディア コントロール ボタン     | ×        | ○               |
| [ミュート] ボタン               | ×        | ○               |

### <a name="built-in-button-support"></a>組み込みボタンのサポート

UWP は、既存のキーボード入力動作をゲームパッドとリモコンの入力に自動的にマップします。 次の表に、これらの組み込みのマッピングを示します。

| キーボード              | ゲームパッド/リモコン                        |
|-----------------------|---------------------------------------|
| 方向キー            | 方向パッド (ゲームパッドの左スティックも同じ)    |
| Space              | A/[選択] ボタン                       |
| Enter                 | A/[選択] ボタン                       |
| Esc キー                | B/[戻る] ボタン*                        |

\* B ボタンの [KeyDown](https://msdn.microsoft.com/library/windows/apps/br208941.aspx) イベントまたは [KeyUp](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.keyup.aspx) イベントのどちらもアプリで処理されない場合、[SystemNavigationManager.BackRequested](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.systemnavigationmanager.backrequested.aspx) イベントが発生し、アプリで "戻る" ナビゲーションが発生します。 ただし、次のコード スニペットのように、これを自分で実装する必要があります。

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
| ページ アップ/ダウン  | PageUp/PageDown キー | 左/右トリガー | [CalendarView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.calendarview.aspx)、[ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)、[ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx)、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、`ScrollViewer`、[Selector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.aspx)、[LoopingSelector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.loopingselector.aspx)、[ComboBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx)、[FlipView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx) | 垂直スクロールをサポートするビュー
| ページの左/右 | なし | L/R ボタン | [Pivot](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.aspx)、[ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)、[ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx)、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、`ScrollViewer`、[Selector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.aspx)、[LoopingSelector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.loopingselector.aspx)、[FlipView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx) | 水平スクロールをサポートするビュー
| ズーム イン/アウト        | Ctrl + 正符号 (+)/負符号 (-) | 左/右トリガー | なし | `ScrollViewer`、拡大と縮小をサポートするビュー |
| ナビゲーション ウィンドウを開く/閉じる | なし | 表示 | なし | ナビゲーション ウィンドウ |
| [検索](#search-experience) | なし | Y ボタン | なし | アプリのメインの検索機能へのショートカット |
| [コンテキスト メニューを開く](#commandbar-and-contextflyout) | 右クリック | メニュー ボタン | [ContextFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout) | コンテキスト メニュー |

## <a name="xy-focus-navigation-and-interaction"></a>XY フォーカス ナビゲーションと対話式操作

アプリがキーボードの適切なフォーカス ナビゲーションをサポートしている場合、ゲームパッドとリモコンでも適切にサポートされます。
方向キーを使ったナビゲーションは**方向パッド** (とゲームパッドの**左スティック**) にマップされ、UI 要素の対話式操作は **Enter/[選択]** キーにマップされます (「[ゲームパッドとリモコン](#gamepad-and-remote-control)」を参照してください)。

多くのイベントやプロパティがキーボードとゲームパッドの両方で使用されます。キーボードとゲームパッドはいずれも `KeyDown` イベントと `KeyUp` イベントを発生させ、`IsTabStop="True"` プロパティと `Visibility="Visible"` プロパティを持つコントロール間のみを移動します。 キーボードの設計ガイダンスについては、「[キーボード操作](../input/keyboard-interactions.md)」をご覧ください。

キーボードのサポートが適切に実装されている場合、アプリはかなり適切に機能します。ただし、すべてのシナリオをサポートするためには追加の作業が必要になります。 最適なユーザー エクスペリエンスを提供するために、アプリ固有のニーズについて考えてください。

> [!IMPORTANT]
> マウス モードは、Xbox One で実行されている UWP アプリでは既定で有効です。 マウス モードを無効にし、XY フォーカス ナビゲーションを有効にするには、`Application.RequiresPointerMode=WhenRequested` を設定します。

### <a name="debugging-focus-issues"></a>フォーカスの問題のデバッグ

[FocusManager.GetFocusedElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.focusmanager.getfocusedelement.aspx) メソッドによって、現在、どの要素にフォーカスがあるかがわかります。 これは、フォーカス表示の場所が明確ではない場合に便利です。 この情報は、Visual Studio の出力ウィンドウに次のように記録できます。

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

* [IsTabStop](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.istabstop.aspx) プロパティまたは [Visibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.visibility.aspx) プロパティが正しく設定されていません。
* フォーカスを取得するコントロールが、実際には想定以上の大きさです。XY ナビゲーションでは、関心のあるものをレンダリングするコントロールの部分だけでなく、コントロールの合計サイズ ([ActualWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.actualwidth.aspx) と [ActualHeight](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.actualheight.aspx)) が考慮されます。
* フォーカス対応コントロールが別のコントロールの上に配置されています。XY ナビゲーションでは、重なり合ったコントロールはサポートされません。

これらの問題を解決しても XY ナビゲーションが引き続き機能しない場合は、「[既定のナビゲーションのオーバーライド](#overriding-the-default-navigation)」で説明されている方法を使って、フォーカスを取得する要素を手動で指定できます。

XY ナビゲーションは意図したとおりに動作するが、フォーカス表示が表示されない場合は、次のいずれかの問題が原因である可能性があります。

* コントロールを再テンプレート化しましたが、フォーカス表示を含めていませんでした。 `UseSystemFocusVisuals="True"` を設定するか、フォーカス表示を手動で追加します。
* `Focus(FocusState.Pointer)` を呼び出してフォーカスを移動しました。 [FocusState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.focusstate.aspx) パラメーターによって、フォーカス表示の処理を制御できます。 一般的には、これを `FocusState.Programmatic` に設定してください。これにより、フォーカスが以前に表示されていた場合は表示され、以前に非表示であった場合は非表示になります。

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

ユーザーが最も一般的なタスクを最小クリック回数で実行できるようにしてください。 次の例では、(最初にフォーカスがある) **再生**ボタンとよく使われる要素の間に [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) が配置されているため、優先順位の高いタスクの間に不要な要素が入り込んでいます。

![ナビゲーションのベスト プラクティスは最小限のクリックのパスを提供すること](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks.png)

次の例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) は**再生**ボタンの上に配置されています。
優先順位の高いタスクの間に不要な要素が配置されないように UI を並べ替えるだけで、アプリの操作性が大幅に向上します。

![優先順位の高いタスクの間から再生ボタンの上に移動した TextBlock](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks-2.png)

### <a name="commandbar-and-contextflyout"></a>CommandBar と ContextFlyout

「[問題: 長いスクロールをするリストやグリッドの後にある UI 要素](#problem-ui-elements-located-after-long-scrolling-list-grid)」で説明するように、[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) を使う場合はリストのスクロールの問題に配慮してください。 次の図は、`CommandBar` がリストやグリッドの下にある UI レイアウトです。 ユーザーはリストやグリッド全体をスクロールしなければ `CommandBar` に到達できません。

![リストやグリッドの下にある CommandBar](images/designing-for-tv/2d-navigation-best-practices-commandbar-and-contextflyout.png)

リストやグリッドの*上*に `CommandBar` を配置した場合はどうなるでしょうか。 リストやグリッドを下へスクロールしたユーザーは `CommandBar` に戻るために上へスクロールして戻る必要がありますが、前の構成よりもナビゲーションはわずかに少なくなります。 ただし、これは、アプリの最初のフォーカスが `CommandBar` の横または上に配置されている場合です。最初のフォーカスがリストやグリッドの下にある場合、この方法はうまく機能しません。 これらの `CommandBar` 項目があまりアクセスする必要のないグローバルな操作の項目の場合 (**同期** ボタンなど)、リストやグリッドの上に置いても問題ありません。

`CommandBar` の項目を縦方向に重ねることはできませんが、UI レイアウトで適切な場合はスクロール方向と異なる向き (たとえば、縦方向にスクロールするリストの左右や、横方向にスクロールするリストの上下) に項目を配置することも検討できます。

ユーザーが項目に簡単にアクセスできる必要がある `CommandBar` をアプリで使う場合、それらの項目を [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) 内に配置して `CommandBar` から削除することを検討できます。 `ContextFlyout` は、[UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.aspx) のプロパティであり、その要素に関連づけられた[コンテキスト メニュー](../controls-and-patterns/dialogs-and-flyouts/index.md)です。 PC では、`ContextFlyout` を持つ要素を右クリックすると、そのコンテキスト メニューがポップアップ表示されます。 Xbox One では、このような要素にフォーカスがあるときに**メニュー** ボタンを押すと、コンテキスト メニューがポップアップ表示されます。

### <a name="ui-layout-challenges"></a>UI レイアウトの問題

XY フォーカス ナビゲーションの特性により、一部の UI レイアウトは設定が難しく、状況ごとに評価が必要です。 "正解" は 1 つではなく、どの解決策を選ぶかはアプリのニーズ次第ですが、優れたテレビ エクスペリエンスを提供するために利用できる方法がいくつかあります。

このことをさらに理解するために、架空のアプリでこれらの問題のいくつかとそれを克服する手法を見てみましょう。

> [!NOTE]
> この架空のアプリは、UI の問題とその解決策を示すことを目的としており、実際のアプリの最適なユーザー エクスペリエンスを示すものではありません。

次の架空の不動産アプリは、販売中の家の一覧、地図、不動産の説明などの情報を表示するものです。 このアプリでは、次の方法で克服できる 3 つの課題が生じます。

- [UI の並べ替え](#ui-rearrange)
- [フォーカス エンゲージメント](#engagement)
- [マウス モード](#mouse-mode)

![架空の不動産アプリ](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app.png)

#### 問題: 長いスクロールをするリストやグリッドの後にある UI 要素 <a name="problem-ui-elements-located-after-long-scrolling-list-grid"></a>

次の図に示すプロパティの [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) は、非常に長いスクロールをするリストです。 この `ListView` で[エンゲージメント](#focus-engagement)が要求され*ない*場合、ユーザーがリストに移動するとフォーカスはリストの最初の項目に設定されます。 ユーザーが **[前へ]** または **[次へ]** ボタンにアクセスするには、リスト内のすべての項目を移動する必要があります。 このような、リスト全体を移動する必要がある設計は、ユーザーがそのエクスペリエンスを許容できるほどリストが短くなければ煩わしくなるため、その他のオプションを検討することをお勧めします。

![不動産アプリ: 50 個の項目があるリストは、下のボタンに移動するまでに 51 回のクリックが必要](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app-list.png)

#### <a name="solutions"></a>解決策

**UI の並べ替え <a name="ui-rearrange"></a>**

最初のフォーカスがページの下部に設定されない限り、通常、長いスクロールをするリストの上に配置した UI 要素の方が、下に配置した場合よりも簡単にアクセスできます。
この新しいレイアウトが他のデバイスでも有効な場合、Xbox One のためだけに UI に特別な変更を行うのでなく、すべてのデバイス ファミリ用にレイアウトを変更する方が、低コストのアプローチになる可能性があります。
また、スクロール方向と異なる向き (縦方向にスクロールするリストでは横方向、横方向にスクロールするリストでは縦方向) に UI 要素を配置すると、アクセシビリティがさらに向上します。

![不動産アプリ: 長いスクロールをするリストの上にボタンを配置](images/designing-for-tv/2d-focus-navigation-and-interaction-ui-rearrange.png)

**フォーカス エンゲージメント <a name="engagement"></a>**

エンゲージメントが*要求される*場合、`ListView` 全体が 1 つのフォーカスの対象になります。 ユーザーはリストの内容をバイパスして、フォーカス可能な次の要素にアクセスできます。 エンゲージメントをサポートしているコントロールとその使用方法について詳しくは、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。

![不動産アプリ: エンゲージメントの要求を設定して 1 クリックのみで [前へ]/[次へ] ボタンにアクセス](images/designing-for-tv/2d-focus-navigation-and-interaction-engagement.png)

#### <a name="problem-scrollviewer-without-any-focusable-elements"></a>問題: フォーカス可能な要素がない ScrollViewer

XY フォーカス ナビゲーションは、フォーカス可能な UI 要素に 1 回で移動できることを前提としているため、フォーカス可能な要素を 1 つも含まない [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) (この例ではテキストのみの要素) は、ユーザーが `ScrollViewer` のすべてのコンテンツを表示することができない状況を招く可能性があります。
この問題の解決策とその他の関連するシナリオについては、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。

![不動産アプリ: テキストのみが含まれる ScrollViewer](images/designing-for-tv/2d-focus-navigation-and-interaction-scrollviewer.png)

#### <a name="problem-free-scrolling-ui"></a>問題: 自由スクロール UI

描画面や次の例にある地図など、アプリに自由スクロール UI が必要な場合、XY フォーカス ナビゲーションのみでは機能しません。
このような場合は、[マウス モード](#mouse-mode)をオンにして、ユーザーが UI 要素内を自由に移動できるようにします。

![マウス モードを使う地図の UI 要素](images/designing-for-tv/map-mouse-mode.png)

## <a name="mouse-mode"></a>マウス モード

「[XY フォーカス ナビゲーションと対話式操作](#xy-focus-navigation-and-interaction)」で説明するとおり、Xbox One でフォーカスを移動するには、XY ナビゲーション システムを使います。ユーザーは、フォーカスを上下左右に動かしてコントロール間を移動できます。
ただし、[WebView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx) や [MapControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.maps.mapcontrol.aspx) などの一部のコントロールでは、ユーザーがコントロールの境界内でポインターを自由に動かせる、マウスのような対話式操作が必要です。
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
> `WhenFocused` の値は [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) オブジェクトでのみサポートされています。 コントロールにこの値を設定しようとすると、例外がスローされます。

### <a name="disabling-mouse-mode-for-full-screen-content"></a>全画面コンテンツのマウス モードの無効化

通常、全画面表示でビデオやその他の種類のコンテンツを表示する場合、ユーザーの注意をそらす可能性があるため、カーソルを非表示にします。 このシナリオは、アプリの他の部分ではマウス モードを使用するが、全画面コンテンツを表示するときはマウス モードを無効にする必要がある場合に発生します。 これを実現するには、全画面コンテンツを独自の `Page` に配置し、次の手順に従います。

1. `App` オブジェクトで、`RequiresPointerMode="WhenRequested"` を設定します。
2. 全画面表示の `Page` を*除く*すべての `Page` オブジェクトで、`RequiresPointer="WhenFocused"` を設定します。
3. 全画面表示の `Page` で、`RequiresPointer="Never"` を設定します。

これにより、全画面コンテンツを表示するときに、カーソルは表示されません。

## <a name="focus-visual"></a>フォーカス表示

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

表示状態を使って独自のフォーカス表示を描画することにより、システムが提供するフォーカス表示を除外することもできます。 詳しくは、「[VisualState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.visualstate.Aspx)」をご覧ください。

### <a name="light-dismiss-overlay"></a>簡易非表示オーバーレイ

ユーザーが現在ゲーム コントローラーまたはリモコンで操作している UI 要素にユーザーの注意を引きつけるために、アプリが Xbox One で実行されている場合は、UWP ではポップアップ UI 以外の領域をカバーする「スモーク」レイヤーが自動的に追加されます。 このための追加作業は必要ありませんが、UI を設計する際に留意してください。 いずれかの `FlyoutBase` で `LightDismissOverlayMode` プロパティを設定して、スモーク レイヤーを有効または無効にすることができます。既定の設定は `Auto` で、Xbox では有効になり、その他の場所では無効になります。 詳しくは、「[モーダルと簡易非表示](../controls-and-patterns/menus.md)」をご覧ください。

## <a name="focus-engagement"></a>フォーカス エンゲージメント

フォーカス エンゲージメントは、ゲームパッドやリモコンでアプリを操作しやすくするためのものです。

> [!NOTE]
> フォーカス エンゲージメントを設定しても、キーボードなどの他の入力デバイスには影響しません。

[FrameworkElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.aspx) オブジェクトのプロパティ `IsFocusEngagementEnabled` を `True` に設定すると、コントロールがフォーカス エンゲージメントを要求するよう設定されます。 この場合、コントロールを "獲得" して操作するには、ユーザーが **A/[選択]** ボタンをクリックする必要があります。 終了したら、**B/[戻る]** ボタンをクリックしてコントロールのエンゲージメントを解除すると、コントロールから移動できるようになります。

> [!NOTE]
> `IsFocusEngagementEnabled` は新しい API で、まだ文書化されていません。

### <a name="focus-trapping"></a>フォーカスのトラップ

フォーカスのトラップとは、ユーザーがアプリの UI を移動しようとしているときにコントロール内に "捕まる" ことで、そのコントロールの外に移動することが困難または不可能になることです。

次の例では、フォーカスのトラップが発生する UI を示します。

![水平方向のスライダーの左右のボタン](images/designing-for-tv/focus-engagement-focus-trapping.png)

ユーザーが左のボタンから右のボタンに移動する場合、方向パッド/左スティックの右を 2 回クリックするだけでよいと考えることは論理的です。
しかし、[Slider](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx) がエンゲージメントを必要としない場合、ユーザーが最初に右に押したときにフォーカスは `Slider` に移動し、もう一度右に押したときに `Slider` のハンドルが右に移動します。 ユーザーはハンドルを右に動かし続けるだけで、ボタンに移ることはできません。

この問題を回避する方法はいくつかあります。 その 1 つは、「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」の不動産アプリで **[前へ]** ボタンと **[次へ]** ボタンの位置を `ListView` の上に変更する例のように、別のレイアウトを設計することです。 次の図のように、水平方向ではなく垂直方向にコントロールを重ねて配置すると、問題が解決します。

![水平方向のスライダーの上下のボタン](images/designing-for-tv/focus-engagement-focus-trapping-2.png)

これでユーザーは期待どおり、方向パッド/左スティックを上下に押して各コントロールに移動でき、`Slider` にフォーカスがあるときは左右に押して `Slider` ハンドルを動かすことができます。

この問題を解決するためのもう 1 つの方法は、`Slider` でエンゲージメントを要求することです。 `IsFocusEngagementEnabled="True"` を設定すると、次の動作が発生します。

![ユーザーが右側のボタンに移動できるように、スライダーでフォーカス エンゲージメントを要求する](images/designing-for-tv/focus-engagement-slider.png)

`Slider` でフォーカス エンゲージメントを要求すると、ユーザーは方向パッド/左スティックを右に 2 回押すだけで右側のボタンに移動できます。 この解決策は、UI の調整なしで予期する動作を実現できるので便利です。

### <a name="items-controls"></a>項目コントロール

[Slider](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx) コントロール以外にもエンゲージメントを要求できるコントロールがあります。

- [ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)
- [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)
- [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)
- [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview)

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

これらのコントロールと少し異なる点は、[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) です。ScrollViewer には、考慮すべき独自の Quirk があります。 フォーカス可能なコンテンツを含む `ScrollViewer` がある場合、`ScrollViewer` に移動すると既定でフォーカス可能なコンテンツ間を移動できます。 `ListView` の場合と同様に、`ScrollViewer` 以外の場所に移動するには、各項目をスクロールする必要があります。

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
| Slider                | オン                        |

他のすべての UWP コントロールは、`IsFocusEngagementEnabled="True"` のとき、動作の変更または視覚的な変更はありません。

## <a name="ui-element-sizing"></a>UI 要素のサイズ

10 フィート環境でアプリを使うユーザーは、画面から数フィート離れた場所に座ってリモコンやゲームパッドを使っています。そのため、UI のデザインに関して考慮する必要がある注意事項がいくつかあります。
ユーザーが簡単に要素間を移動したり要素を選んだりできるように、UI があまり雑然とせず、適切なコンテンツの密度になるようにします。 簡潔さが重要です。

### <a name="scale-factor-and-adaptive-layout"></a>拡大縮小率とアダプティブ レイアウト

**拡大縮小率**は、アプリが実行されているデバイスにおける適切なサイズで UI 要素が表示されることを保証します。
デスクトップでは、この設定は **[設定] > [システム] > [表示]** からスライダーで値を指定します。
この設定が電話でサポートされている場合、電話にも同じ設定があります。

![テキスト、アプリ、その他の項目のサイズを変更する](images/designing-for-tv/ui-scaling.png)

Xbox One ではこのようなシステム設定はありません。ただし、UWP の UI 要素をテレビ用に適切なサイズにするために、拡大縮小率は既定で **200%** (XAML アプリの場合) および **150%** (HTML アプリの場合) に設定されます。
他のデバイスで UI 要素のサイズが適切に設定されていれば、テレビでも適切なサイズになります。
Xbox One ではアプリは 1080 p (1920 x 1080 ピクセル) で表示されます。 そのため、PC などの他のデバイスからアプリを移植する場合は、[アダプティブ手法](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を利用して 960 x 540 ピクセル、100% のスケーリング (または HTML アプリの場合、1280 x 720 ピクセル、100% のスケーリング) で UI が適切に表示されるようにしてください。

Xbox 用の設計では、1 つの解像度 (1920 x 1080) だけを考慮すればよいため、PC の設計とは少し異なります。
ユーザーがそれ以上の解像度のテレビを使っていても関係ありません。UWP アプリは常に 1080 p に拡大縮小されます。

また、テレビの解像度に関係なく、アプリが Xbox One で実行されている場合は適切なアセット サイズが 200% (または HTML アプリの場合は 150%) のセットから取得されます。

### <a name="content-density"></a>コンテンツの密度

アプリを設計する際には、ユーザーは離れた位置から UI を見るということに注意してください。また、リモコンやゲーム コントローラーを使ってアプリを操作するために、マウスやタッチ入力を使うよりも移動に時間がかかることに注意してください。

#### <a name="sizes-of-ui-controls"></a>UI コントロールのサイズ

対話型の UI 要素は、最小の高さである 32 epx (有効ピクセル) でサイズを調整する必要があります。 これは一般的な UWP コントロールの既定の設定で、拡大縮小率が 200% のときに UI 要素が遠くから確実に見えるようにし、コンテンツの密度を抑えるためのものです。

![拡大縮小率 100% と 200% の UWP ボタン](images/designing-for-tv/button-100-200.png)

#### <a name="number-of-clicks"></a>クリックの回数

UI を簡略化するために、ユーザーがテレビ画面の端から端まで移動するときに、**クリックは 6 回**以内になるようにします。 ここでも**簡潔さ**の原則が重要です。 詳しくは、「[最小回数のクリック数](#path-of-least-clicks)」をご覧ください。

![6 つのアイコン分の幅](images/designing-for-tv/six-clicks.png)

### <a name="text-sizes"></a>テキスト サイズ

UI を離れた位置から見えるようにするために、次の経験則に従ってください。

* メイン テキストと読解コンテンツ: 最小 15 epx
* 不可欠ではないテキストと補助コンテンツ: 最小 12 epx

UI でさらに大きなテキストを使う場合は、画面領域をあまり狭めないサイズを選び、他のコンテンツのためのスペースを圧迫しないようにします。

### <a name="opting-out-of-scale-factor"></a>拡大縮小率の無効化

アプリでは拡大縮小率のサポートを利用することをお勧めします。この機能は、各デバイスの種類に合わせて拡大縮小することで、すべてのデバイスでアプリを適切に実行するためのものです。
しかし、この動作を無効にして、すべての UI を 100% の拡大縮小率で設計することもできます。 100% 以外の拡大縮小率には変更できないことに注意してください。

XAML アプリでは、次のコード スニペットを使って倍率を無効にすることができます。

```csharp
bool result =
    Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```

`result` 無効化に成功したかどうかが通知されます。

HTML/JavaScript のサンプル コードなどの詳細情報については、「[スケーリングを無効にする方法](../../xbox-apps/disable-scaling.md)」をご覧ください。

UI 要素の適切なサイズを計算するときに、このトピックで説明した*有効*ピクセルの値を倍にして (または HTML アプリの場合は 1.5 倍にして) *実際*のピクセル値にすることを忘れないでください。

## <a name="tv-safe-area"></a>テレビのセーフ エリア

歴史的な経緯や技術的な理由により、すべてのテレビで画面の端までコンテンツが表示されるわけではありません。 既定では、UWP はテレビのセーフ エリア以外に UI コンテンツを表示せず、ページの背景のみを描画します。

次の図に、テレビのセーフ エリア以外の領域を青色で示します。

![テレビのセーフ エリア以外の領域](images/designing-for-tv/tv-unsafe-area.png)

次のコード スニペットに示すように、背景は静的な色、テーマの色、または画像に設定できます。

### <a name="theme-color"></a>テーマの色

```xml
<Page x:Class="Sample.MainPage"
      Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"/>
```

### <a name="image"></a>画像

```xml
<Page x:Class="Sample.MainPage"
      Background="\Assets\Background.png"/>
```

追加の作業を行わない場合、アプリは次のように表示されます。

![テレビのセーフ エリア](images/designing-for-tv/tv-safe-area.png)

この場合、アプリのアスペクト比が変わり、ナビゲーション ウィンドウやグリッドなど UI の一部が切れて表示されるため、最適とはいえません。 ただし、UI の一部を画面の端まで拡張し、アプリに映画のような効果を持たせることで最適化することができます。

### <a name="drawing-ui-to-the-edge"></a>端までの UI の描画

ユーザーに没入感を提供するために、特定の UI 要素を使って画面の端まで拡張することをお勧めします。 [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx)、[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)、[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) などを使えます。

一方、対話型の要素とテキストは画面の端に表示されることを常に避け、一部のテレビで表示が切れないようにすることも重要です。 画面の端 5% 以内には重要でない視覚効果のみを描画することをお勧めします。 「[UI 要素のサイズ](#ui-element-sizing)」で説明したように、Xbox One コンソールの既定の拡大縮小率 200% に従っている UWP アプリは、960 x 540 epx の領域を使います。そのため、アプリの UI では重要な UI を以下の領域に置かないようにします。

- 上部と下部から 27 epx
- 左側と右側から 48 epx

以下のセクションでは、UI を画面の端まで広げる方法について説明します。

#### <a name="core-window-bounds"></a>コア ウィンドウの境界

10 フィート エクスペリエンスのみを対象とする UWP アプリでは、コア ウィンドウの境界を使う方が簡単です。

`App.xaml.cs` の `OnLaunched` メソッドで、次のコードを追加します。

```csharp
Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode
    (Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
```

このコード行で、アプリ ウィンドウは画面の端まで拡張されます。そのため、前に説明したテレビのセーフ エリアへ、すべての対話型 UI と重要な UI を移動する必要があります。 コンテキスト メニューや開かれた状態の [ComboBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) などの一時的な UI は、テレビのセーフ エリア内に自動的に残ります。

![コア ウィンドウの境界](images/designing-for-tv/core-window-bounds.png)

#### <a name="pane-backgrounds"></a>ウィンドウの背景

通常、ナビゲーション ウィンドウは画面の端近くに描画されるため、不自然なギャップが入らないように背景をテレビのセーフ エリア以外まで広げる必要があります。 ナビゲーション ウィンドウの背景の色をアプリの背景の色に変更するだけで、これを行うことができます。

既に説明したように、コア ウィンドウの境界を使用すると、画面の端まで UI を描画することができますが、さらに [SplitView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.splitview.aspx) のコンテンツで正の余白を使用してコンテンツがテレビ セーフ エリア内に収まるようにする必要があります。

![画面の端まで拡張されたナビゲーション ウィンドウ](images/designing-for-tv/tv-safe-areas-2.png)

ここでは、ナビゲーション ウィンドウの背景は画面の端まで拡張され、ナビゲーション項目はテレビのセーフ エリア内に収まっています。
`SplitView` のコンテンツ (この場合は項目のグリッド) は、途切れずに続いているように見せるために、画面の下部まで拡張されています。一方、グリッドの上部はテレビのセーフ エリア内に収まったままです  (この方法ついて詳しくは、「[リストとグリッドのスクロールの端](#scrolling-ends-of-lists-and-grids)」で説明します)。

次のコード スニペットでは、この効果を実現します。

```xml
<SplitView x:Name="RootSplitView"
           Margin="48,0,48,0">
    <SplitView.Pane>
        <ListView x:Name="NavMenuList"
                  ContainerContentChanging="NavMenuItemContainerContentChanging"
                  ItemContainerStyle="{StaticResource NavMenuItemContainerStyle}"
                  ItemTemplate="{StaticResource NavMenuItemTemplate}"
                  ItemInvoked="NavMenuList_ItemInvoked"
                  ItemsSource="{Binding NavMenuListItems}"/>
    </SplitView.Pane>
    <Frame x:Name="frame"
           Navigating="OnNavigatingToPage"
           Navigated="OnNavigatedToPage"/>
</SplitView>
```

[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) も、アプリの 1 つまたは複数の端の近くに置かれることが多いウィンドウの例ですが、そのためにテレビではその背景を画面の端まで拡張する必要があります。 これには通常、**[その他]** ボタンも含まれます。[その他] ボタンは右側に表示する "..." で表し、テレビのセーフ エリア内に収める必要があります。 目的の操作と視覚効果を実現するためのいくつかの異なる方法を次に示します。

**オプション 1**: `CommandBar` の背景色を透明またはページの背景と同じ色に変更します。

```xml
<CommandBar x:Name="topbar"
            Background="{ThemeResource SystemControlBackgroundAltHighBrush}">
            ...
</CommandBar>
```

これで、`CommandBar` がページの残りの部分と同じ背景の上にあるように見え、背景が画面の端まで切れ目なく続きます。

**オプション 2**: `CommandBar` の背景と同じ色で塗りつぶした背景の四角形を追加し、その四角形を `CommandBar` の下、ページの残りの部分に配置します。

```xml
<Rectangle VerticalAlignment="Top"
            HorizontalAlignment="Stretch"      
            Fill="{ThemeResource SystemControlBackgroundChromeMediumBrush}"/>
<CommandBar x:Name="topbar"
            VerticalAlignment="Top"
            HorizontalContentAlignment="Stretch">
            ...
</CommandBar>
```

> [!NOTE]
> この方法を使う場合、アイコンの下に `AppBarButton` のラベルを表示できるように、開いた状態の `CommandBar` の高さが **[その他]** ボタンによって必要に応じて変更されることに注意してください。 サイズ変更を避けるために、アイコンの*右側*へラベルを移動することをお勧めします。 詳しくは、「[CommandBar のラベル](#commandbar-labels)」をご覧ください。

これらのアプローチはいずれも、このセクションに示されている他の種類のコントロールにも適用されます。

#### <a name="scrolling-ends-of-lists-and-grids"></a>リストとグリッドのスクロールの端

リストとグリッドに一度に画面に表示できるよりも多くの項目を含めることはよくあります。 この場合、リストまたはグリッドを画面の端まで拡張することをお勧めします。 リストとグリッドを横方向にスクロールする場合は右端まで、垂直方向にスクロールする場合は一番下まで拡張するようにします。

![テレビのセーフ エリアでのグリッドの切り捨て](images/designing-for-tv/tv-safe-area-grid-cutoff.png)

リストまたはグリッドは次のように拡張されますが、フォーカス表示とその関連項目をテレビのセーフ エリア内に収めることが重要です。

![グリッドのフォーカスのスクロールをテレビのセーフ エリア内に収める](images/designing-for-tv/scrolling-grid-focus.png)

UWP にはフォーカス表示を [VisibleBounds](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.applicationview.visiblebounds.aspx) 内に保持する機能がありますが、リストやグリッドの項目をセーフ エリアの表示領域内までスクロールできるように余白を追加する必要があります。 具体的には、次のコード スニペットのように、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) または [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) の [ItemsPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemspresenter.aspx) に正の余白を追加します。

```xml
<Style x:Key="TitleSafeListViewStyle"
       TargetType="ListView">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="ListView">
                <Border BorderBrush="{TemplateBinding BorderBrush}"
                        Background="{TemplateBinding Background}"
                        BorderThickness="{TemplateBinding BorderThickness}">
                    <ScrollViewer x:Name="ScrollViewer"
                                  TabNavigation="{TemplateBinding TabNavigation}"
                                  HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}"
                                  HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}"
                                  IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}"
                                  VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}"
                                  VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}"
                                  IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}"
                                  IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}"
                                  IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}"
                                  ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}"
                                  IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}"
                                  BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}"
                                  AutomationProperties.AccessibilityView="Raw">
                        <ItemsPresenter Header="{TemplateBinding Header}"
                                        HeaderTemplate="{TemplateBinding HeaderTemplate}"
                                        HeaderTransitions="{TemplateBinding HeaderTransitions}"
                                        Footer="{TemplateBinding Footer}"
                                        FooterTemplate="{TemplateBinding FooterTemplate}"
                                        FooterTransitions="{TemplateBinding FooterTransitions}"
                                        Padding="{TemplateBinding Padding}"
                                        Margin="0,27,0,27"/>
                    </ScrollViewer>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

前のコード スニペットをページまたはアプリのリソースに含め、次のようにアクセスします。

```xml
<Page>
    <Grid>
        <ListView Style="{StaticResource TitleSafeListViewStyle}"
                  ... />
```

> [!NOTE]
> このコード スニペットは `ListView` 専用です。`GridView` のスタイルの場合、[ControlTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.controltemplate.aspx) と [Style](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.aspx) の両方の [TargetType](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.controltemplate.targettype.aspx) 属性を `GridView` に設定します。

## <a name="colors"></a>色

既定では、アプリが適切に表示されるように、ユニバーサル Windows プラットフォームはアプリの色をテレビ セーフの範囲 (詳しくは「[テレビ セーフ カラー](#tv-safe-colors)」を参照) に対応させています。 また、テレビでの視覚エクスペリエンスを向上させるために、アプリで使う色のセットを改善できます。

### <a name="application-theme"></a>アプリケーション テーマ

アプリに合わせて適切な**アプリケーション テーマ** (濃色または淡色) を選ぶか、テーマを無効にすることができます。 テーマの一般的な推奨事項については、「[配色テーマ](../style/color.md)」をご覧ください。

UWP では、アプリが実行されているデバイスから提供されるシステム設定に基づいて、アプリでテーマを動的に設定することもできます。
UWP では、ユーザーが指定したテーマ設定が常に適用されますが、各デバイスは、適切な既定のテーマも提供します。
Xbox One はその性質上、*生産性*エクスペリエンスよりも*メディア* エクスペリエンスを期待されているため、既定で濃色のシステム テーマに設定されます。
アプリのテーマがシステム設定を基にしている場合、Xbox One では既定で濃色に設定されるはずです。

### <a name="accent-color"></a>アクセント カラー

UWP には、ユーザーがシステム設定から選んだ**アクセント カラー**を公開する便利な方法が用意されています。

PC でアクセント カラーを選べるように、ユーザーは Xbox One でユーザーの色を選ぶことができます。
アプリでブラシやカラー リソースからこれらのアクセント カラーを呼び出していれば、ユーザーがシステム設定で選んだ色が使われます。 Xbox One ではアクセント カラーはシステムごとではなくユーザーごとであることに注意してください。

また、Xbox One と PC、電話、その他のデバイスでは、ユーザーの色のセットが異なることに注意してください。

アプリで **SystemControlForegroundAccentBrush** などのブラシ リソースやカラー リソース (**SystemAccentColor**) を使うか、代わりに [UIColorType.Accent*](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.uicolortype.aspx) API からアクセント カラーを直接呼び出していれば、これらの色は Xbox One で利用可能なアクセント カラーに置き換えられます。 ハイ コントラストのブラシの色も、PC や電話と同じ方法でシステムから取得されます。

アクセント カラー全般について詳しくは、「[アクセント カラー](../style/color.md#accent-color)」をご覧ください。

### <a name="color-variance-among-tvs"></a>テレビごとのカラーの変化

テレビ向けに設計するときには、レンダリングされるテレビごとに色の表示が大きく異なることに注意してください。 モニター上とまったく同じ色に見えるとは限りません。 アプリで UI の各部を区別するために色のわずかな違いを利用している場合、色が混ざり合ってユーザーが混乱する可能性があります。 どのテレビであっても、ユーザーがはっきり区別できる違いがある色を使うようにしてください。

### <a name="tv-safe-colors"></a>テレビ セーフ カラー

色の RGB 値は、赤、緑、青の輝度を表します。 テレビでは、極端な輝度をあまりうまく処理できません。不自然な縞模様になったり、一部のテレビでは色あせて表示されたりする可能性があります。 また、高輝度色はブルーミング (隣接するピクセルが同じ色を描画する現象) を起こす可能性があります。 どのような色をテレビ セーフ カラーと見なすかについてはいくつかの考え方がありますが、一般に、RGB 値 16 ～ 235 (16 進数では 10 ～ EB) の色はテレビで使っても安全です。

![テレビ セーフ カラーの範囲](images/designing-for-tv/tv-safe-colors-2.png)

従来、Xbox 上のアプリは、この "テレビ セーフ" カラーの範囲内に収まるように色を調整する必要がありました。ただし、Fall Creators Update 以降、Xbox One はすべての範囲のコンテンツをテレビ セーフ範囲に自動的に対応させています。 つまり、ほとんどのアプリ開発者がテレビ セーフ カラーについて心配する必要がなくなりました。

> [!IMPORTANT]
> 既にテレビ セーフ カラーの範囲内にあるビデオ コンテンツは、[メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) を使用して再生する場合、このカラー スケール効果は適用されません。

DirectX 11 または DirectX 12 を使ってアプリを開発し、UI またはビデオをレンダリングするために独自のスワップ チェーンを作成している場合、[IDXGISwapChain3::SetColorSpace1](https://msdn.microsoft.com/library/windows/desktop/dn903676) を呼び出して使用する色空間を指定できるため、色の操作が必要かどうかをシステムに通知します。

## <a name="guidelines-for-ui-controls"></a>UI コントロールのガイドライン

いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。 10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。

### <a name="pivot-control"></a>ピボット コントロール

[ピボット](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.aspx)は、別のヘッダーやタブを選択することにより、アプリ内でビューのすばやいナビゲーションを提供します。 このコントロールでは、フォーカスがあるヘッダーに下線が引かれ、ゲームパッド/リモコンを使用している場合に、現在選択されているヘッダーがわかりやすくなります。

![ピボットの下線](images/designing-for-tv/pivot-underline.png)

[Pivot.IsHeaderItemsCarouselEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.isheaderitemscarouselenabled.aspx) プロパティを `true` に設定すると、選択したピボット ヘッダーが常に最初の位置に移動する代わりに、ピボットが常に同じ位置に固定されます。 ヘッダーの折り返しを煩わしいと感じるユーザーもいるため、これでテレビなどの大画面表示でエクスペリエンスが向上します。 すべてのピボット ヘッダーが同時に画面に収まらない場合、ユーザーは表示されるスクロール バーを使って他のヘッダーを表示できますが、最良のエクスペリエンスを提供するためには、すべてのピボット ヘッダーが画面に収まることを確認する必要があります。 詳しくは、「[タブとピボット](../controls-and-patterns/tabs-pivot.md)」をご覧ください。

### <a name="navigation-pane-a-namenavigation-pane"></a>ナビゲーション ウィンドウ <a name="navigation-pane">

ナビゲーション ウィンドウ (*ハンバーガー メニュー*とも呼ばれる) は、UWP アプリでよく使われるナビゲーション コントロールです。 通常、リスト スタイルのメニューから選択できる複数のオプションを表示するウィンドウであり、ユーザーに異なるページを表示します。 一般的に、このウィンドウは領域を節約するために折りたたまれた状態で表示され、ユーザーがボタンをクリックすることで開くことができます。

ナビゲーション ウィンドウは、マウスやタッチを使う場合に非常にアクセシビリティが高く、ゲームパッド/リモコンを使う場合はウィンドウを開くボタンに移動する必要があるためアクセシビリティは低くなります。 そのため、ユーザーがページの左端まで移動してナビゲーション ウィンドウを開くことができるだけでなく、**表示**ボタンでナビゲーション ウィンドウを開く操作を可能にすることをお勧めします。 この設計パターンを実装する方法を示すコード サンプルは、「[プログラムによるフォーカス ナビゲーション](../input/focus-navigation-programmatic.md#split-view-code-sample)」にあります。 これにより、ユーザーは非常に簡単にウィンドウの内容にアクセスすることができます。 さまざまな画面サイズでのナビゲーション ウィンドウの動作と、ゲームパッド/リモコンでのナビゲーションのベスト プラクティスについては、「[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)」をご覧ください。

### <a name="commandbar-labels"></a>CommandBar のラベル

[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) のアイコンの高さを最小化し、一貫性が保たれるようにするために、アイコンの右側にラベルを配置することをお勧めします。 [CommandBar.DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) プロパティを `CommandBarDefaultLabelPosition.Right` に設定することによって、これを実現できます。

![アイコンの右側にラベルが配置された CommandBar](images/designing-for-tv/commandbar.png)

また、このプロパティを設定するとラベルが常に表示されるようになり、ユーザーのクリック数を最小限に抑えることができるため、10 フィート エクスペリエンスに適しています。 また、これは他の種類のデバイスでも従うべき優れたモデルです。

### <a name="tooltip"></a>ヒント

[Tooltip](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltip.aspx) コントロールは、ユーザーが要素の上にマウスを置くか、要素をタップして長押ししたときに UI の詳しい情報を提供する方法として導入されました。 ゲームパッドとリモコンの場合、`Tooltip` は、要素にフォーカスが設定されて少し時間が経つと表示され、しばらく画面に表示された後で消えます。 使う `Tooltip` が多すぎると、ユーザーがこの動作を煩わしいと感じる可能性があります。 テレビを設計するときには `Tooltip` を使わないようにしてください。

### <a name="button-styles"></a>ボタンのスタイル

標準的な UWP ボタンもテレビで適切に機能しますが、ボタンのいくつかの視覚スタイルは、より UI に注意を引きます。そのため、すべてのプラットフォーム、特に 10 フィート エクスペリエンスでは、どこにフォーカスがあるかを明確に通知できるというメリットがあるため、検討することをお勧めします。 そのようなスタイルについて詳しくは、「[ボタン](../controls-and-patterns/buttons.md)」をご覧ください。

### <a name="nested-ui-elements"></a>入れ子になった UI 要素

入れ子になった UI は、コンテナー UI 要素内部に囲まれた、操作できる入れ子になったアイテムを公開します。入れ子になったアイテムとコンテナー アイテムはどちらも互いに、個別のフォーカスを取得することが可能です。

入れ子になった UI がうまく機能する入力の種類もありますが、XY ナビゲーションに依存するゲームパッドやリモコンでは、うまく機能するとは限りません。 このトピックのガイダンスに従い、UI が 10 フィート環境に最適化され、ユーザーが対話可能なすべての要素に容易にアクセスできるようにしてください。 よく使用される解決策の 1 つは、`ContextFlyout` に入れ子になった UI 要素を配置することです ([CommandBarとContextFlyout](#commandbar-and-contextflyout) をご覧ください)。

入れ子になった UI について詳しくは、「[リスト項目の入れ子になった UI](../controls-and-patterns/nested-ui.md)」をご覧ください。

### <a name="mediatransportcontrols"></a>MediaTransportControls

[MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediatransportcontrols.aspx) 要素によって、ユーザーが再生、一時停止、クローズド キャプションの有効化などの操作を実行できる既定の再生エクスペリエンスが提供され、ユーザーはメディアを操作することができます。 このコントロールは、[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement.aspx) のプロパティであり、*1 行*と *2 行*の 2 つのレイアウト オプションをサポートしています。 1 行のレイアウトでは、スライダーと再生ボタンはすべて 1 つの行に配置され、スライダーの左側に再生/一時停止ボタンが配置されます。 2 行のレイアウトでは、スライダーは独自の行に配置され、再生ボタンは下側の別の行に配置されます。 10 フィート エクスペリエンス向けに設計する場合は、ゲームパッドでのナビゲーションが向上するため、2 行のレイアウトを使用してください。 2 行のレイアウトを有効にするには、`MediaPlayerElement` の [TransportControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.transportcontrols.aspx) プロパティの `MediaTransportControls` 要素で `IsCompact="False"` を設定します。

```xml
<MediaPlayerElement x:Name="mediaPlayerElement1"  
                    Source="Assets/video.mp4"
                    AreTransportControlsEnabled="True">
    <MediaPlayerElement.TransportControls>
        <MediaTransportControls IsCompact="False"/>
    </MediaPlayerElement.TransportControls>
</MediaPlayerElement>
```  

アプリにメディアを追加する方法について詳しくは、「[メディア再生](../controls-and-patterns/media-playback.md)」をご覧ください。

> ![注] `MediaPlayerElement` は Windows 10 バージョン 1607 以降でのみ使用できます。 Windows 10 の以前のバージョン用にアプリを開発する場合は、代わりに [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) を使用する必要があります。 上記の推奨事項は `MediaElement` にも適用され、`TransportControls` プロパティも同じ方法でアクセスされます。

### <a name="search-experience"></a>検索エクスペリエンス

コンテンツの検索は 10 フィート エクスペリエンスで最もよく実行される機能の 1 つです。 アプリが検索エクスペリエンスを提供する場合、ユーザーがゲームパッドの **Y** ボタンをアクセラレータとして使用して、検索へのクイックアクセスができるようにすると便利です。

このアクセラレータは既に多くのユーザーに使用されていますが、必要に応じて UI に視覚的な **Y** グリフを追加して、ユーザーがこのボタンを使用して検索機能にアクセスできることを示すことも可能です。 このヒントを追加する場合は、Xbox のシェルやその他のアプリとの一貫性を維持するため、必ず **Segoe Xbox シンボル MDL2** フォント (XAML アプリの場合は `&#xE3CC;`、HTML アプリの場合は `\E426`) のシンボルを使用します。

> [!NOTE]
> **Segoe Xbox MDL2 シンボル** フォントは Xbox にのみ対応するフォントであるため、PC ではシンボルが正しく表示されません。 ただし、テレビに Xbox を展開した後はテレビで表示できます。

**Y** ボタンはゲームパッドのみで利用できるため、検索にアクセスするための他の方法 (UI のボタンなど) を提供するようにします。 そうしない場合、一部のユーザーが検索機能にアクセスすることができない可能性があります。

10 フィート エクスペリエンスではディスプレイのスペースが限られるため、通常、ユーザーは全画面表示の検索エクスペリエンスを使うほうが便利です。 全画面表示でも部分的な表示でも、「インプレース」検索により、ユーザーが検索エクスペリエンスを開いたときにスクリーン キーボードが表示され、ユーザーが検索用語を入力できるようにすることをお勧めします。

## <a name="custom-visual-state-trigger-for-xbox"></a>Xbox のカスタム表示状態トリガー

UWP アプリを 10 フィート エクスペリエンス用にカスタマイズする場合、アプリが Xbox コンソールで起動されたことを検出したときにアプリのレイアウトが変わるようにすることをお勧めします。 これを行う方法の 1 つが、カスタム*表示状態トリガー*を使用することです。 表示状態トリガーは、**Blend for Visual Studio** で編集する場合に最も有用です。 次のコード スニペットは、Xbox の表示状態トリガーを作成する方法を示しています。

```xml
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
        <VisualState>
            <VisualState.StateTriggers>
                <triggers:DeviceFamilyTrigger DeviceFamily="Windows.Xbox"/>
            </VisualState.StateTriggers>
            <VisualState.Setters>
                <Setter Target="RootSplitView.OpenPaneLength"
                        Value="368"/>
                <Setter Target="RootSplitView.CompactPaneLength"
                        Value="96"/>
                <Setter Target="NavMenuList.Margin"
                        Value="0,75,0,27"/>
                <Setter Target="Frame.Margin"
                        Value="0,27,48,27"/>
                <Setter Target="NavMenuList.ItemContainerStyle"
                        Value="{StaticResource NavMenuItemContainerXboxStyle}"/>
            </VisualState.Setters>
        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

このようなトリガーを作成するには、アプリに次のクラスを追加します。 これは、前の XAML コードで参照されているクラスです。

```csharp
class DeviceFamilyTrigger : StateTriggerBase
{
    private string _currentDeviceFamily, _queriedDeviceFamily;

    public string DeviceFamily
    {
        get
        {
            return _queriedDeviceFamily;
        }

        set
        {
            _queriedDeviceFamily = value;
            _currentDeviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;
            SetActive(_queriedDeviceFamily == _currentDeviceFamily);
        }
    }
}
```

カスタム トリガーを追加した場合、アプリは、Xbox One コンソールで実行されていることを検出すると XAML コードで指定されたレイアウトを自動的に変更します。

アプリが Xbox で実行されていることを確認した後、適切な調整を行うためのもう 1 つの方法は、コードを使うことです。 次の単純な変数を使って、Xbox でアプリが実行されているかどうかを確認できます。

```csharp
bool IsTenFoot = (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily ==
                    "Windows.Xbox");
```

次に、このチェックに続くコード ブロックで、UI に適切な調整を行うことができます。 この例については、「[UWP 色のサンプル](#uwp-color-sample)」をご覧ください。

## <a name="summary"></a>まとめ

10 フィート エクスペリエンスの設計には、他のプラットフォーム向けの設計とは対応を変える必要がある、特別な考慮事項があります。 UWP アプリを Xbox One に単純に移植し、うまく動かすことができたとしも、必ずしも 10 フィート エクスペリエンス向けに最適化されるわけではありません。ユーザーのフラストレーションを招くことさえあります。 この記事のガイドラインに従うと、テレビに組み込まれているかのようなすばらしいアプリにすることができます。

## <a name="related-articles"></a>関連記事

- [ユニバーサル Windows プラットフォーム (UWP) アプリ用デバイスの基本情報](index.md)
- [ゲームパッドとリモコンの操作](../input/gamepad-and-remote-interactions.md)
- [UWP アプリのサウンド](../style/sound.md)
