---
author: eliotcowley
Description: "テレビで見栄えよく表示され適切に機能するアプリを設計します。"
title: "Xbox およびテレビ向け設計"
ms.assetid: 780209cb-3e8a-4cf7-8f80-8b8f449580bf
label: Designing for Xbox and TV
template: detail.hbs
isNew: true
translationtype: Human Translation
ms.sourcegitcommit: 2e7515efa04f6335929e23d31da7d76cb64b9cc9
ms.openlocfilehash: 54da89e33b81fc8c5439786f8a5133360dbd186c

---

> \[この記事では、まだ利用できない機能について説明します。 この機能は、商用リリースの前に大幅に変更される場合があります。 ここに記載された情報について、マイクロソフトは明示または黙示を問わずいかなる保証をするものでもありません。\]

# Xbox およびテレビ向け設計

Xbox One とテレビ画面で見栄えよく表示され、適切に機能するようにユニバーサル Windows プラットフォーム (UWP) アプリの設計を行います。

## 概要

ユニバーサル Windows プラットフォームでは、複数の Windows 10 デバイスで魅力的なエクスペリエンスを実現できます。 UWP フレームワークで提供される機能のほとんどは、追加の作業を行わなくても、これらのデバイス間で同じユーザー インターフェイス (UI) をアプリに使用できます。 ただし、Xbox One とテレビ画面で快適に機能するようにアプリを調整し最適化するには、特別な注意事項があります。

ソファーに座りながらゲームパッドやリモコンを使って部屋の反対側にあるテレビを操作することを、**10 フィート エクスペリエンス**といいます。 通常は画面から約 10 フィート (約 3 m) の距離に座るため、このように呼ばれています。 この場合、たとえば PC の操作 (*2 フィート* エクスペリエンスと呼ばれます) には見られない、特有の課題があります。 Xbox One や、コントローラーを使って入力しテレビ画面に出力するその他のデバイス向けアプリを開発している場合、この点を常に意識しておく必要があります。

アプリを 10 フィート エクスペリエンス向けに適切に動作させるためにこの記事のすべての手順が必要なわけではありませんが、手順を理解し、アプリにとって何が適切かを判断することで、アプリ特有のニーズに合わせてカスタマイズされた、優れた 10 フィート エクスペリエンスを提供できます。 10 フィート環境でアプリを使う場合、次のデザイン原則を検討してください。

### シンプル

10 フィート環境向けのデザインには特有の課題があります。 解像度と視聴距離の点から、ユーザーはあまり多くの情報を処理できない可能性があります。 単純なデザインになるように、ごくシンプルなコンポーネントだけに絞り込むようにしてください。 テレビに表示される情報の量は、デスクトップではなく、携帯電話と同程度にする必要があります。

![Xbox One ホーム画面](images/designing-for-tv/xbox-home-screen.png)

### 一貫性

10 フィート環境の UWP アプリは、直感的で簡単に使えるようにします。 何がポイントなのかを明快、明確にしてください。 コンテンツの配置を工夫し、コンテンツ間の移動に一貫性を持たせてユーザーが予測できるようにします。 ユーザーが目的の操作を最短で実行できるように配慮しましょう。

![Xbox One 映画アプリ](images/designing-for-tv/xbox-movies-app.png)

_**スクリーンショットに示す映画はすべて、Microsoft 映画 & テレビでご利用いただけます。**_  

### 魅力的

最もイマーシブで臨場感のあるエクスペリエンスは、大画面で引き出されます。 画面いっぱいに広がる風景、洗練された動作、鮮やかな色使い、生き生きとした文字が、アプリをワンランク上に引き上げます。 大胆で美しいデザインにしましょう。

![Xbox One アバター アプリ](images/designing-for-tv/xbox-avatar-app.png)

### 10 フィート エクスペリエンス向けの最適化

ここまで、10 フィート エクスペリエンス向けに優れた UWP アプリを設計する原則を説明しました。次に、アプリを最適化して優れたユーザー エクスペリエンスを提供する具体的な方法について、概要を示します。

| 機能        | 説明           |
| -------------------------------------------------------------- |--------------------------------|
| [ゲームパッドとリモコン](#gamepad-and-remote-control)      | アプリがゲームパッドやリモコンで正しく動作するか確認することは、10 フィート エクスペリエンス向けの最適化で最も重要な手順です。 操作がある程度制限されたデバイスでユーザーの対話式操作エクスペリエンスを最適化できる、ゲームパッドやリモコン固有の改善点がいくつかあります。 |
| [XY フォーカス ナビゲーションと対話式操作](#xy-focus-navigation-and-interaction) | UWP では、ユーザーは **XY フォーカス ナビゲーション**を使ってアプリの UI 内を移動できます。 ただし、ユーザーの移動は上下左右に制限されます。 このセクションでは、この点に対応するための推奨事項とその他の考慮事項について説明します。 |
| [マウス モード](#mouse-mode)|地図や描画サーフェイスなど一部のユーザー インターフェイスでは、XY フォーカス ナビゲーションの使用は不可能または非実用的です。 UWP ではこれらのインターフェイス用に**マウス モード**が用意されており、デスクトップ コンピューターでマウスを操作するように、ゲームパッド/リモコンを使って自由に移動できます。|
| [フォーカス表示](#focus-visual)  | フォーカス表示とは、現在フォーカスがある UI 要素を囲む境界線のことです。 この機能を使ってユーザーの現在位置をわかりやすく示すことで、ユーザーが自分の位置を見失わずに UI を移動しやすくなります。 フォーカスがよく見えないとユーザーが UI 内で自分の位置を見失ってしまい、優れたエクスペリエンスを得られない可能性があります。  |
| [フォーカス エンゲージメント](#focus-engagement) | UI 要素にフォーカス エンゲージメントを設定すると、ユーザーは、対話式操作するために [**A/選択**] ボタンを押す必要があります。 こうすることで、アプリの UI を移動するときのユーザー エクスペリエンスをより良くすることができます。
| [UI 要素のサイズ](#ui-element-sizing)  | ユニバーサル Windows プラットフォームは、[スケーリングと有効ピクセル](..\layout\design-and-ui-intro.md#effective-pixels-and-scaling)を使い、視聴距離に合わせて UI をスケーリングします。 サイズについて理解し UI 全体に適用すれば、アプリを 10 フィート環境用に最適化するのに役立ちます。  |
|  [テレビのセーフ エリア](#tv-safe-area) | UWP は既定で、テレビのセーフ エリア以外の領域 (画面の端に近い部分) に UI を表示することを自動的に避けます。 ただし、この場合、アスペクト比が変わり、UI がレターボックス化されてしまいます。 テレビでイマーシブなアプリにするには、サポートしているテレビで、画面の端まで広がるようにアプリを変更します。 |
| [カラー](#colors)  |  UWP は配色テーマをサポートしています。システム テーマを引き継ぐアプリは、Xbox One では既定で**濃色**になります。 アプリに特定の配色テーマがある場合、テレビではうまく表示されないために一部の色を避ける必要があることに注意してください。 |
| [サウンド](../style/sound.md)    | サウンドは、ユーザーを没頭させたりユーザーにフィードバックを提供したりする上で役立ち、10 フィート エクスペリエンスで重要な役割を果たします。 UWP には、アプリが Xbox One で実行されているときは一般的なコントロールのサウンドを自動的に有効にする機能があります。 UWP に組み込まれているサウンド サポートの詳細とその活用方法について説明します。    |
| [UI コントロールのガイドライン](#guidelines-for-ui-controls)  |  いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。 10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。 |
| [Xbox のカスタム表示状態トリガー](#custom-visual-state-trigger-for-xbox) | UWP アプリを 10 フィート エクスペリエンス用にカスタマイズする場合、カスタム*表示状態トリガー*を使用して、アプリが Xbox コンソールで起動されたことを検出したときにアプリのレイアウトが変わるようにすることをお勧めします。

## ゲームパッドとリモコン

PC でキーボードやマウス、電話とタブレットでタッチを使うように、10 フィート エクスペリエンスではゲームパッドとリモコンがメイン入力デバイスになります。 このセクションでは、ハードウェア ボタンとはどのようなもので何に使うかについて説明します。 「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」と「[マウス モード](#mouse-mode)」では、これらの入力デバイスを使うときにアプリを最適化する方法について学びます。

設定なしの場合のゲームパッドとリモコンの動作の品質は、アプリでキーボードがどの程度サポートされているかによって異なります。 アプリがゲームパッドとリモコンでうまく動作することを確認する良い方法は、アプリが PC でキーボードを使ってうまく動作するか確認してから、ゲームパッドとリモコンでテストして UI で不十分な箇所を見つけることです。

### ハードウェア ボタン

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
| [表示] ボタン               | ○       | ○               |
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

### 組み込みボタンのサポート

UWP は、既存のキーボード入力動作をゲームパッドとリモコンの入力に自動的にマップします。 次の表に、これらの組み込みのマッピングを示します。

| キーボード              | ゲームパッド/リモコン                        |
|-----------------------|---------------------------------------|
| 方向キー            | 方向パッド (ゲームパッドの左スティックも同じ)    |
| Space              | A/[選択] ボタン                       |
| Enter                 | A/[選択] ボタン                       |
| Esc キー                | B/[戻る] ボタン*                        |

\* B ボタンの [KeyDown](https://msdn.microsoft.com/library/windows/apps/br208941) イベントまたは [KeyUp](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.keyup.aspx) イベントのどちらもアプリで処理されない場合、[SystemNavigationManager.BackRequested](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.systemnavigationmanager.backrequested.aspx) イベントが発生し、アプリで "戻る" ナビゲーションが発生します。 ただし、次のコード スニペットのように、これを自分で実装する必要があります。

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

Xbox One の UWP アプリでは、**メニュー** ボタンを押してコンテキスト メニューを開く操作もサポートされています。 詳しくは、「[CommandBar と ContextFlyout](#commandbar-and-contextflyout)」をご覧ください。

### アクセラレータのサポート

アクセラレータ ボタンは、UI でナビゲーションを高速化するために使うことができます。 ただし、これらのボタンは特定の入力デバイスにしかない可能性があるため、すべてのユーザーが機能を使用できるとは限らないことに注意してください。 事実、現在 Xbox One で UWP アプリのアクセラレータ機能をサポートしている入力デバイスは、ゲームパッドだけです。

次の表に、UWP に組み込まれているアクセラレータのサポートと自分で実装することができるアクセラレータのサポートを示します。 一貫性のあるわかりやすいユーザー エクスペリエンスを提供するために、これらの動作をカスタム UI で利用してください。

| 操作   | キーボード   | ゲームパッド      | 組み込み済み:  | 推奨: |
|---------------|------------|--------------|----------------|------------------|
| ページ アップ/ダウン  | PageUp/PageDown キー | 左/右トリガー | 
              [CalendarView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.calendarview.aspx)、[ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)、[ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx)、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、`ScrollViewer`、[Selector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.aspx)、[LoopingSelector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.loopingselector.aspx)、[ComboBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx)、[FlipView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx) | 垂直スクロールをサポートするビュー
| ページの左/右 | なし | L/R ボタン | 
              [Pivot](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.aspx)、[ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)、[ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx)、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、`ScrollViewer`、[Selector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.aspx)、[LoopingSelector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.loopingselector.aspx)、[FlipView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx) | 水平スクロールをサポートするビュー
| ズーム イン/アウト        | Ctrl + 正符号 (+)/負符号 (-) | 左/右トリガー | なし | `ScrollViewer`、拡大と縮小をサポートするビュー |
| ナビゲーション ウィンドウを開く/閉じる | なし | 表示 | なし | ナビゲーション ウィンドウ

## XY フォーカス ナビゲーションと対話式操作

アプリがキーボードの適切なフォーカス ナビゲーションをサポートしている場合、ゲームパッドとリモコンでも適切にサポートされます。 方向キーを使ったナビゲーションは**方向パッド** (とゲームパッドの**左スティック**) にマップされ、UI 要素の対話式操作は **Enter/[選択]** キーにマップされます (「[ゲームパッドとリモコン](#gamepad-and-remote-control)」を参照してください)。 

多くのイベントやプロパティがキーボードとゲームパッドの両方で使用されます。キーボードとゲームパッドはいずれも `KeyDown` イベントと `KeyUp` イベントを発生させ、`IsTabStop="True"` プロパティと `Visibility="Visible"` プロパティを持つコントロール間のみを移動します。 キーボードの設計ガイダンスについては、「[キーボード操作](keyboard-interactions.md)」をご覧ください。

キーボードのサポートが適切に実装されている場合、アプリはかなり適切に機能します。ただし、すべてのシナリオをサポートするためには追加の作業が必要になります。 最適なユーザー エクスペリエンスを提供するために、アプリ固有のニーズについて考えてください。

> [!IMPORTANT]
> マウス モードは、Xbox One で実行されている UWP アプリでは既定で有効です。 マウス モードを無効にし、XY フォーカス ナビゲーションを有効にするには、`Application.RequiresPointerMode=WhenRequested` を設定します。

### フォーカスの問題のデバッグ

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

### アクセスできない UI

XY フォーカス ナビゲーションはユーザーの動作を上下左右への移動に制限しているため、UI の一部にアクセスできなくなる可能性があります。 次の図は、XY フォーカス ナビゲーションでサポートされていない UI レイアウトの例を示します。 垂直および水平方向ナビゲーションが優先され、中央の要素はフォーカスを獲得できるほど優先順位が高くないため、ゲームパッド/リモコンを使って中央の要素にアクセスできないことに注意してください。

![4 隅の要素と、アクセスできない中央の要素](images/designing-for-tv/2d-navigation-best-practices-ui-layout-to-avoid.png)

何らかの理由で UI の配置を変更できない場合は、次のセクションで説明する手法のいずれかを使って、フォーカスの既定の動作をオーバーライドします。

### 既定のナビゲーションのオーバーライド

ユニバーサル Windows プラットフォームは、方向パッド/左スティックによるナビゲーションがユーザーにとって意味のあるものであることを確認しようとしますが、アプリの目的に沿って最適化された動作を保証することはできません。 ナビゲーションがアプリ用に最適化されていることを確認する最善の方法は、ゲームパッドを使ってナビゲーションをテストし、アプリのシナリオにとって適切な方法でユーザーがすべての UI 要素にアクセスできることを確認することです。 アプリのシナリオで、提供されている XY フォーカス ナビゲーションでは実現できない動作が必要となる場合は、次のセクションの推奨事項に従ったり、動作をオーバーライドして適切な項目にフォーカスを設定したりことを検討してください。

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

### 最小回数のクリック数

ユーザーが最も一般的なタスクを最小クリック回数で実行できるようにしてください。 次の例では、(最初にフォーカスがある) **再生**ボタンとよく使われる要素の間に [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) が配置されているため、優先順位の高いタスクの間に不要な要素が入り込んでいます。

![ナビゲーションのベスト プラクティスは最小限のクリックのパスを提供すること](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks.png)

次の例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) は**再生**ボタンの上に配置されています。 優先順位の高いタスクの間に不要な要素が配置されないように UI を並べ替えるだけで、アプリの操作性が大幅に向上します。

![優先順位の高いタスクの間から再生ボタンの上に移動した TextBlock](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks-2.png)

### CommandBar と ContextFlyout

「[問題: 長いスクロールをするリストやグリッドの後にある UI 要素](#problem-ui-elements-located-after-long-scrolling-list-grid)」で説明するように、[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) を使う場合はリストのスクロールの問題に配慮してください。 次の図は、`CommandBar` がリストやグリッドの下にある UI レイアウトです。 ユーザーはリストやグリッド全体をスクロールしなければ `CommandBar` に到達できません。

![リストやグリッドの下にある CommandBar](images/designing-for-tv/2d-navigation-best-practices-commandbar-and-contextflyout.png)

リストやグリッドの*上*に `CommandBar` を配置した場合はどうなるでしょうか。 リストやグリッドを下へスクロールしたユーザーは `CommandBar` に戻るために上へスクロールして戻る必要がありますが、前の構成よりもナビゲーションはわずかに少なくなります。 ただし、これは、アプリの最初のフォーカスが `CommandBar` の横または上に配置されている場合です。最初のフォーカスがリストやグリッドの下にある場合、この方法はうまく機能しません。 これらの `CommandBar` 項目があまりアクセスする必要のないグローバルな操作の項目の場合 (**同期** ボタンなど)、リストやグリッドの上に置いても問題ありません。

`CommandBar` の項目を縦方向に重ねることはできませんが、UI レイアウトで適切な場合はスクロール方向と異なる向き (たとえば、縦方向にスクロールするリストの左右や、横方向にスクロールするリストの上下) に項目を配置することも検討できます。

ユーザーが項目に簡単にアクセスできる必要がある `CommandBar` をアプリで使う場合、それらの項目を [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) 内に配置して `CommandBar` から削除することを検討できます。 `ContextFlyout` は、[UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.aspx) のプロパティであり、その要素に関連づけられた[コンテキスト メニュー](../controls-and-patterns/dialogs-popups-menus.md#context-menus-and-flyouts)です。 PC では、`ContextFlyout` を持つ要素を右クリックすると、そのコンテキスト メニューがポップアップ表示されます。 Xbox One では、このような要素にフォーカスがあるときに**メニュー** ボタンを押すと、コンテキスト メニューがポップアップ表示されます。

<!--The following XAML code demonstrates a simple `ContextFlyout`:

```xml
<Button HorizontalAlignment="Center"
        Content="Context Flyout">
    <Button.ContextFlyout>
        <MenuFlyout>
            <MenuFlyoutItem Text="Item 1"/>
        </MenuFlyout>
    </Button.ContextFlyout>
</Button>
```

In the above example, when you press the **Menu** button while the [Button](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx) has focus, the context menu appears with the menu item labeled **Item 1**.

`ContextFlyout` takes any element of type [FlyoutBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.aspx); however, most of the time you will likely use [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.aspx) or [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyout.aspx).

Alternatively, you can listen for the [ContextRequested](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextrequested.aspx) event, which occurs when the user has completed a context input gesture (pressing the **Menu** button). In this case you can, in the code-behind, create the context menu, attach it to the **UIElement**, and show the flyout when the event is raised.

The following C# code demonstrates a simple example of this:

```csharp
MenuFlyout myFlyout = new MenuFlyout();
MenuFlyoutItem item1 = new MenuFlyoutItem();
item1.Text = "Item 1";
myFlyout.Items.Add(item1);
MyButton.ContextFlyout = myFlyout;

private void MyButton_ContextRequested(UIElement sender, ContextRequestedEventArgs args)
{
    Point point = new Point(0, 0);
    if (args.TryGetPosition(sender, out point)
    {
        myFlyout.ShowAt(sender, point);
    }
    else
    {
        myFlyout.ShowAt(sender as FrameworkElement);
    }
}
```
> **Note** Don't use both of these options, as `ContextFlyout` already handles the `ContextRequested` event.-->

### UI レイアウトの問題

XY フォーカス ナビゲーションの特性により、一部の UI レイアウトは設定が難しく、状況ごとに評価が必要です。 "正解" は 1 つではなく、どの解決策を選ぶかはアプリのニーズ次第ですが、優れたテレビ エクスペリエンスを提供するために利用できる方法がいくつかあります。

このことをさらに理解するために、架空のアプリでこれらの問題のいくつかとそれを克服する手法を見てみましょう。

> [!NOTE]
> この架空のアプリは、UI の問題とその解決策を示すことを目的としており、実際のアプリの最適なユーザー エクスペリエンスを示すものではありません。

次の架空の不動産アプリは、販売中の家の一覧、地図、不動産の説明などの情報を表示するものです。 このアプリでは、次の方法で克服できる 3 つの課題が生じます。

- [UI の並べ替え](#ui-rearrange)
- [フォーカス エンゲージメント](#engagement)
- [マウス モード](#mouse-mode)

![架空の不動産アプリ](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app.png)

#### 問題: 長いスクロールをするリストやグリッドの後にある UI 要素  <a name="problem-ui-elements-located-after-long-scrolling-list-grid"></a>

次の図に示すプロパティの [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) は、非常に長いスクロールをするリストです。 この `ListView` で[エンゲージメント](#focus-engagement)が要求され*ない*場合、ユーザーがリストに移動するとフォーカスはリストの最初の項目に設定されます。 ユーザーが **[前へ]** または **[次へ]** ボタンにアクセスするには、リスト内のすべての項目を移動する必要があります。 このような、リスト全体を移動する必要がある設計は、ユーザーがそのエクスペリエンスを許容できるほどリストが短くなければ煩わしくなるため、その他のオプションを検討することをお勧めします。

![不動産アプリ: 50 個の項目があるリストは、下のボタンに移動するまでに 51 回のクリックが必要](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app-list.png)

#### 解決策

**UI の並べ替え  <a name="ui-rearrange"></a>**

最初のフォーカスがページの下部に設定されない限り、通常、長いスクロールをするリストの上に配置した UI 要素の方が、下に配置した場合よりも簡単にアクセスできます。 この新しいレイアウトが他のデバイスでも有効な場合、Xbox One のためだけに UI に特別な変更を行うのでなく、すべてのデバイス ファミリ用にレイアウトを変更する方が、低コストのアプローチになる可能性があります。 また、スクロール方向と異なる向き (縦方向にスクロールするリストでは横方向、横方向にスクロールするリストでは縦方向) に UI 要素を配置すると、アクセシビリティがさらに向上します。

![不動産アプリ: 長いスクロールをするリストの上にボタンを配置](images/designing-for-tv/2d-focus-navigation-and-interaction-ui-rearrange.png)

**フォーカス エンゲージメント  <a name="engagement"></a>**

エンゲージメントが*要求される*場合、`ListView` 全体が 1 つのフォーカスの対象になります。 ユーザーはリストの内容をバイパスして、フォーカス可能な次の要素にアクセスできます。 エンゲージメントをサポートしているコントロールとその使用方法について詳しくは、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。

![不動産アプリ: エンゲージメントの要求を設定して 1 クリックのみで [前へ]/[次へ] ボタンにアクセス](images/designing-for-tv/2d-focus-navigation-and-interaction-engagement.png)

#### 問題: フォーカス可能な要素がない ScrollViewer

XY フォーカス ナビゲーションは、フォーカス可能な UI 要素に 1 回で移動できることを前提としているため、フォーカス可能な要素を 1 つも含まない [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) (この例ではテキストのみの要素) は、ユーザーが `ScrollViewer` のすべてのコンテンツを表示することができない状況を招く可能性があります。 この問題の解決策とその他の関連するシナリオについては、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。

![不動産アプリ: テキストのみが含まれる ScrollViewer](images/designing-for-tv/2d-focus-navigation-and-interaction-scrollviewer.png)

#### 問題: 自由スクロール UI

描画面や次の例にある地図など、アプリに自由スクロール UI が必要な場合、XY フォーカス ナビゲーションのみでは機能しません。 このような場合は、[マウス モード](#mouse-mode)をオンにして、ユーザーが UI 要素内を自由に移動できるようにします。

![マウス モードを使う地図の UI 要素](images/designing-for-tv/map-mouse-mode.png)

## マウス モード

「[XY フォーカス ナビゲーションと対話式操作](#xy-focus-navigation-and-interaction)」で説明するとおり、Xbox One でフォーカスを移動するには、XY ナビゲーション システムを使います。ユーザーは、フォーカスを上下左右に動かしてコントロール間を移動できます。 ただし、[WebView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx) や [MapControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.maps.mapcontrol.aspx) などの一部のコントロールでは、ユーザーがコントロールの境界内でポインターを自由に動かせる、マウスのような対話式操作が必要です。 また、ユーザーがページ全体でポインターを動かせるようにして、PC でマウスを使うときと同じようなエクスペリエンスをゲームパッド/リモコンで体験できるようにする必要があるアプリもあります。

このような場合、ページ全体に対して、または、ページ内のいずれかのコントロールに対して、ポインター (マウス モード) を要求する必要があります。 たとえば、アプリのページで `WebView` コントロールを使い、そのコントロール内ではマウス モード、それ以外はすべて XY フォーカス ナビゲーションを使うことができます。 ポインターを要求する場合、**コントロールまたはページが有効になったとき**、または**ページにフォーカスがあるとき**のどちらでポインターを要求するかを指定できます。

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

HTML と Javascript のアプリでは、次のコードを使います。

```javascript
navigator.gamepadInputEmulation = "keyboard";
```

次の図は、マウス モードでのゲームパッド/リモコンのボタンのマッピングを示しています。

![マウス モードでのゲームパッド/リモコンのボタンのマッピング](images/designing-for-tv/mouse-mode.png)

> [!NOTE]
> マウス モードは Xbox One のゲームパッド/リモコンのみでサポートされています。 その他のデバイス ファミリや入力タイプでは自動的に無視されます。

コントロールまたはページでマウス モードをアクティブ化するには、そのコントロールまたはページで `RequiresPointer` プロパティを使います。 `RequiresPointer` には `Never` (既定値)、`WhenEngaged`、`WhenFocused` の 3 つの値があります。

> [!NOTE]
> `RequiresPointer` は新しい API で、まだ文書化されていません。 

<!--TODO: Link to doc-->

### コントロールでのマウス モードのアクティブ化

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

### ページでのマウス モードのアクティブ化

ページに `RequiresPointer="WhenFocused"` プロパティを設定している場合、フォーカスがあるとページ全体に対してマウス モードがアクティブ化されます。 次のコード スニペットは、ページでこのプロパティを設定する方法を示しています。

```xml
<Page RequiresPointer="WhenFocused">
    ...
</Page> 
```

> [!NOTE]
> `WhenFocused` の値は [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) オブジェクトでのみサポートされています。 コントロールにこの値を設定しようとすると、例外がスローされます。

### 全画面コンテンツのマウス モードの無効化

通常、全画面表示でビデオやその他の種類のコンテンツを表示する場合、ユーザーの注意をそらす可能性があるため、カーソルを非表示にします。 このシナリオは、アプリの他の部分ではマウス モードを使用するが、全画面コンテンツを表示するときはマウス モードを無効にする必要がある場合に発生します。 これを実現するには、全画面コンテンツを独自の `Page` に配置し、次の手順に従います。

1. `App` オブジェクトで、`RequiresPointerMode="WhenRequested"` を設定します。
2. 全画面表示の `Page` を*除く*すべての `Page` オブジェクトで、`RequiresPointer="WhenFocused"` を設定します。
3. 全画面表示の `Page` で、`RequiresPointer="Never"` を設定します。

これにより、全画面コンテンツを表示するときに、カーソルは表示されません。

## フォーカス表示

フォーカス表示とは、現在フォーカスがある UI 要素を囲む境界線のことです。 この機能を使ってユーザーの現在位置をわかりやすく示すことで、ユーザーが自分の位置を見失わずに UI を移動しやすくなります。

フォーカス表示は、表示が更新され、多数のカスタマイズ オプションが追加されているため、開発者は 1 つのフォーカス表示を用意すれば、PC と Xbox One、さらにはキーボードやゲームパッド/リモコンをサポートするその他の Windows 10 デバイスで正しく動作することを期待できます。

ただし、異なるプラットフォームで同じフォーカス表示を使うことはできますが、10 フィート エクスペリエンスではフォーカス表示の利用状況がやや異なります。 この場合、ユーザーはテレビ画面全体に十分注意を払っていないと想定し、ユーザーが表示を探す際にフラストレーションを感じないように、現在フォーカスのある要素を常に明確に表示することが重要です。

また、フォーカス表示は、ゲームパッドやリモコンを使うときは既定で表示されますが、キーボードを使うときは既定で表示*されない*ことに注意してください。 したがって、実装していなくても Xbox One でアプリを実行すると表示されます。

### フォーカス表示の初期設定

アプリを起動したりページに移動したりするときは、ユーザーがアクションを実行する最初の要素として意味のある UI 要素にフォーカスを設定します。 たとえば、フォト アプリではギャラリー内の最初の項目にフォーカスを設定し、音楽アプリで曲の詳細ビューに移動する場合は音楽を再生しやすいように再生ボタンにフォーカスを設定できます。

初期フォーカスは、アプリの左上 (右から左へ移動する場合は右上) の領域に設定するようにしてください。 通常、アプリのコンテンツ フローはそこから開始されるため、ほとんどのユーザーは最初にその隅を意識する傾向があります。

### フォーカスの明確な表示

ユーザーがフォーカスを探さなくても前回の終了位置を選べるように、1 つのフォーカス表示が常に画面に表示されているようにします。 同様に、フォーカス可能な項目を常に画面上に表示する必要があります。たとえば、フォーカス可能な要素がない、テキストのみのポップアップを使わないでください。

このルールの例外は、ビデオの視聴や画像の表示などの全画面表示エクスペリエンスです。この場合、フォーカス表示を行うことは適切ではありません。

### フォーカスの表示のカスタマイズ

フォーカス表示をカスタマイズする場合は、各コントロールのフォーカス表示に関連するプロパティを変更します。 アプリのパーソナル設定に活用できるこのようなプロパティはいくつかあります。

表示状態を使って独自のフォーカス表示を描画することにより、システムが提供するフォーカス表示を除外することもできます。 詳しくは、「[VisualState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.visualstate.Aspx)」をご覧ください。

### 簡易非表示オーバーレイ

ユーザーが現在ゲーム コントローラーまたはリモコンで操作している UI 要素にユーザーの注意を引きつけるために、アプリが Xbox One で実行されている場合は、UWP ではポップアップ UI 以外の領域をカバーする「スモーク」レイヤーが自動的に追加されます。 このための追加作業は必要ありませんが、UI を設計する際に留意してください。 いずれかの `FlyoutBase` で `LightDismissOverlayMode` プロパティを設定して、スモーク レイヤーを有効または無効にすることができます。既定の設定は `Auto` で、Xbox では有効になり、その他の場所では無効になります。 詳しくは、「[モーダルと簡易非表示](../controls-and-patterns/dialogs-popups-menus.md#modal-vs-light-dismiss)」をご覧ください。

## フォーカス エンゲージメント

フォーカス エンゲージメントは、ゲームパッドやリモコンでアプリを操作しやすくするためのものです。 

> [!NOTE]
> フォーカス エンゲージメントを設定しても、キーボードなどの他の入力デバイスには影響しません。

[FrameworkElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.aspx) オブジェクトのプロパティ `IsFocusEngagementEnabled` を `True` に設定すると、コントロールがフォーカス エンゲージメントを要求するよう設定されます。 この場合、コントロールを "獲得" して操作するには、ユーザーが **A/[選択]** ボタンをクリックする必要があります。 終了したら、**B/[戻る]** ボタンをクリックしてコントロールのエンゲージメントを解除すると、コントロールから移動できるようになります。

> [!NOTE]
> `IsFocusEngagementEnabled` は新しい API で、まだ文書化されていません。

### フォーカスのトラップ

フォーカスのトラップとは、ユーザーがアプリの UI を移動しようとしているときにコントロール内に "捕まる" ことで、そのコントロールの外に移動することが困難または不可能になることです。

次の例では、フォーカスのトラップが発生する UI を示します。

![水平方向のスライダーの左右のボタン](images/designing-for-tv/focus-engagement-focus-trapping.png)

ユーザーが左のボタンから右のボタンに移動する場合、方向パッド/左スティックの右を 2 回クリックするだけでよいと考えることは論理的です。 しかし、[Slider](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx) がエンゲージメントを必要としない場合、ユーザーが最初に右に押したときにフォーカスは `Slider` に移動し、もう一度右に押したときに `Slider` のハンドルが右に移動します。 ユーザーはハンドルを右に動かし続けるだけで、ボタンに移ることはできません。

この問題を回避する方法はいくつかあります。 その 1 つは、「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」の不動産アプリで **[前へ]** ボタンと **[次へ]** ボタンの位置を `ListView` の上に変更する例のように、別のレイアウトを設計することです。 次の図のように、水平方向ではなく垂直方向にコントロールを重ねて配置すると、問題が解決します。

![水平方向のスライダーの上下のボタン](images/designing-for-tv/focus-engagement-focus-trapping-2.png)

これでユーザーは期待どおり、方向パッド/左スティックを上下に押して各コントロールに移動でき、`Slider` にフォーカスがあるときは左右に押して `Slider` ハンドルを動かすことができます。

この問題を解決するためのもう 1 つの方法は、`Slider` でエンゲージメントを要求することです。 `IsFocusEngagementEnabled="True"` を設定すると、次の動作が発生します。

![ユーザーが右側のボタンに移動できるように、スライダーでフォーカス エンゲージメントを要求する](images/designing-for-tv/focus-engagement-slider.png)

`Slider` でフォーカス エンゲージメントを要求すると、ユーザーは方向パッド/左スティックを右に 2 回押すだけで右側のボタンに移動できます。 この解決策は、UI の調整なしで予期する動作を実現できるので便利です。

### 項目コントロール

[Slider](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx) コントロール以外にもエンゲージメントを要求できるコントロールがあります。

- [ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)
- [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)
- [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)
- [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview)

`Slider` コントロールと異なり、これらのコントロールはフォーカスを捕捉しませんが、大量のデータを含めると操作性の問題が生じる可能性があります。 次の例は、大量のデータが含まれる `ListView` です。

![大量のデータと上下のボタンが含まれる ListView](images/designing-for-tv/focus-engagement-list-and-grid-controls.png)

`Slider` の例と同様に、ゲームパッド/リモコンで上のボタンから下のボタンに移動してみましょう。 上ボタンにフォーカスがある状態で方向パッド/スティックを押すと、`ListView` の最初の項目 ("Item 1") にフォーカスが設定されます。 ユーザーがもう一度押すと、下にあるボタンではなく、一覧の次の項目がフォーカスを獲得します。 ボタンに移動するには、ユーザーは `ListView` のすべての項目を移動していく必要があります。 `ListView` に大量のデータが含まれている場合は、この操作に手間がかかり、最適なユーザー エクスペリエンスになりません。

この問題を解決するには、`ListView` でプロパティ `IsFocusEngagementEnabled="True"` を設定し、エンゲージメントを要求します。 この結果、ユーザーは下に押すだけで `ListView` まで迅速にスキップできます。 ただし、一覧にエンゲージメントを設定しないと、一覧をスクロールしたり、一覧から項目を選んだりすることはできません。エンゲージメントを設定するには、フォーカスがある状態で **A/[選択]** ボタンを押します。エンゲージメントを解除するには、**B/[戻る]** ボタンを押します。

![エンゲージメントが要求される ListView](images/designing-for-tv/focus-engagement-list-and-grid-controls-2.png)

#### ScrollViewer

これらのコントロールと少し異なる点は、[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) です。ScrollViewer には、考慮すべき独自の Quirk があります。 フォーカス可能なコンテンツを含む `ScrollViewer` がある場合、`ScrollViewer` に移動すると既定でフォーカス可能なコンテンツ間を移動できます。 `ListView` の場合と同様に、`ScrollViewer` 以外の場所に移動するには、各項目をスクロールする必要があります。 

`ScrollViewer` にフォーカス可能なコンテンツが*ない*場合 (テキストのみが含まれる場合など)、ユーザーが **A/[選択]** ボタンを使って `ScrollViewer` にエンゲージメントを設定できるように、`IsFocusEngagementEnabled="True"` を設定できます。 エンゲージメントの設定後、**方向パッド/左スティック**を使ってテキストをスクロールできます。作業が終わったら、**B/[戻る]** ボタンを押してエンゲージメントを解除できます。

別の方法としては、ユーザーがコントロールにエンゲージメントを設定しなくてすむように `ScrollViewer` で `IsTabStop="True"` を設定します。`ScrollViewer` 内にフォーカス可能な要素がない場合にも、**D パッド/左スティック**を使って、単にフォーカスしてからスクロールできます。

### フォーカス エンゲージメントの既定値

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

## UI 要素のサイズ

10 フィート環境でアプリを使うユーザーは、画面から数フィート離れた場所に座ってリモコンやゲームパッドを使っています。そのため、UI のデザインに関して考慮する必要がある注意事項がいくつかあります。 ユーザーが簡単に要素間を移動したり要素を選んだりできるように、UI があまり雑然とせず、適切なコンテンツの密度になるようにします。 簡潔さが重要です。

### 拡大縮小率とアダプティブ レイアウト


              **拡大縮小率**は、アプリが実行されているデバイスにおける適切なサイズで UI 要素が表示されることを保証します。 デスクトップでは、この設定は **[設定] > [システム] > [表示]** からスライダーで値を指定します。 この設定が電話でサポートされている場合、電話にも同じ設定があります。

![テキスト、アプリ、その他の項目のサイズを変更する](images/designing-for-tv/ui-scaling.png) 

Xbox One ではこのようなシステム設定はありません。ただし、UWP の UI 要素をテレビ用に適切なサイズにするために、拡大縮小率は既定で **200%** に設定されます。 他のデバイスで UI 要素のサイズが適切に設定されていれば、テレビでも適切なサイズになります。 Xbox One ではアプリは 1080 p (1920 x 1080 ピクセル) で表示されます。 そのため、PC などの他のデバイスからアプリを持ってくるときには、[アダプティブ手法](https://msdn.microsoft.com/windows/uwp/layout/screen-sizes-and-breakpoints-for-responsive-design)を利用して 960 x 540 ピクセルの 100% のスケーリングで UI が適切に表示されるようにしてください。

Xbox 用の設計では、1 つの解像度 (1920 x 1080) だけを考慮すればよいため、PC の設計とは少し異なります。 ユーザーがそれ以上の解像度のテレビを使っていても関係ありません。UWP アプリは常に 1080 p に拡大縮小されます。

また、テレビの解像度に関係なく、アプリが Xbox One で実行されている場合は適切なアセット サイズが 200% のセットから取得されます。

### コンテンツの密度

アプリを設計する際には、ユーザーは離れた位置から UI を見るということに注意してください。また、リモコンやゲーム コントローラーを使ってアプリを操作するために、マウスやタッチ入力を使うよりも移動に時間がかかることに注意してください。

#### UI コントロールのサイズ

対話型の UI 要素は、最小の高さである 32 epx (有効ピクセル) でサイズを調整する必要があります。 これは一般的な UWP コントロールの既定の設定で、拡大縮小率が 200% のときに UI 要素が遠くから確実に見えるようにし、コンテンツの密度を抑えるためのものです。 

![拡大縮小率 100% と 200% の UWP ボタン](images/designing-for-tv/button-100-200.png)

#### クリックの回数

UI を簡略化するために、ユーザーがテレビ画面の端から端まで移動するときに、**クリックは 6 回**以内になるようにします。 ここでも**簡潔さ**の原則が重要です。 詳しくは、「[最小回数のクリック数](#path-of-least-clicks)」をご覧ください。

![6 つのアイコン分の幅](images/designing-for-tv/six-clicks.png)

### テキスト サイズ

UI を離れた位置から見えるようにするために、次の経験則に従ってください。

* メイン テキストと読解コンテンツ: 最小 15 epx
* 不可欠ではないテキストと補助コンテンツ: 最小 12 epx

UI でさらに大きなテキストを使う場合は、画面領域をあまり狭めないサイズを選び、他のコンテンツのためのスペースを圧迫しないようにします。

### 拡大縮小率の無効化

アプリでは拡大縮小率のサポートを利用することをお勧めします。この機能は、各デバイスの種類に合わせて拡大縮小することで、すべてのデバイスでアプリを適切に実行するためのものです。 しかし、この動作を無効にして、すべての UI を 100% の拡大縮小率で設計することもできます。 100% 以外の拡大縮小率には変更できないことに注意してください。

次のコード スニペットを使って拡大縮小率を無効にすることができます。

```csharp
bool result = Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```

`result` 無効化に成功したかどうかが通知されます。

UI 要素の適切なサイズを計算するときに、このトピックで説明した*有効*ピクセルの値を倍にして*実際*のピクセル値にすることを忘れないでください。

## テレビのセーフ エリア

歴史的な経緯や技術的な理由により、すべてのテレビで画面の端までコンテンツが表示されるわけではありません。 既定では、UWP はテレビのセーフ エリア以外に UI コンテンツを表示せず、ページの背景のみを描画します。

次の図に、テレビのセーフ エリア以外の領域を青色で示します。

![テレビのセーフ エリア以外の領域](images/designing-for-tv/tv-unsafe-area.png)

次のコード スニペットに示すように、背景は静的な色、テーマの色、または画像に設定できます。

### テーマの色

```xml
<Page x:Class="Sample.MainPage"
      Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"/>
```

### 画像

```xml
<Page x:Class="Sample.MainPage"
      Background="\Assets\Background.png"/>
```

追加の作業を行わない場合、アプリは次のように表示されます。

![テレビのセーフ エリア](images/designing-for-tv/tv-safe-area.png)

この場合、アプリのアスペクト比が変わり、ナビゲーション ウィンドウやグリッドなど UI の一部が切れて表示されるため、最適とはいえません。 ただし、UI の一部を画面の端まで拡張し、アプリに映画のような効果を持たせることで最適化することができます。

### 端までの UI の描画

ユーザーに没入感を提供するために、特定の UI 要素を使って画面の端まで拡張することをお勧めします。 [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx)、[ナビゲーション ウィンドウ](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/nav-pane)、[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) などを使えます。

一方、対話型の要素とテキストは画面の端に表示されることを常に避け、一部のテレビで表示が切れないようにすることも重要です。 画面の端 5% 以内には重要でない視覚効果のみを描画することをお勧めします。 「[UI 要素のサイズ](#ui-element-sizing)」で説明したように、Xbox One コンソールの既定の拡大縮小率 200% に従っている UWP アプリは、960 x 540 epx の領域を使います。そのため、アプリの UI では重要な UI を以下の領域に置かないようにします。

- 上部と下部から 27 epx
- 左側と右側から 48 epx

以下のセクションでは、UI を画面の端まで広げる方法について説明します。

#### コア ウィンドウの境界

10 フィート エクスペリエンスのみを対象とする UWP アプリでは、コア ウィンドウの境界を使う方が簡単です。

`App.xaml.cs` の `OnLaunched` メソッドで、次のコードを追加します。

```csharp
Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode
    (Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
```

このコード行で、アプリ ウィンドウは画面の端まで拡張されます。そのため、前に説明したテレビのセーフ エリアへ、すべての対話型 UI と重要な UI を移動する必要があります。 コンテキスト メニューや開かれた状態の [ComboBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) などの一時的な UI は、テレビのセーフ エリア内に自動的に残ります。

![コア ウィンドウの境界](images/designing-for-tv/core-window-bounds.png)

#### ウィンドウの背景 

通常、ナビゲーション ウィンドウは画面の端近くに描画されるため、不自然なギャップが入らないように背景をテレビのセーフ エリア以外まで広げる必要があります。 ナビゲーション ウィンドウの背景の色をアプリの背景の色に変更するだけで、これを行うことができます。

既に説明したように、コア ウィンドウの境界を使用すると、画面の端まで UI を描画することができますが、さらに [SplitView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.splitview.aspx) のコンテンツで正の余白を使用してコンテンツがテレビ セーフ エリア内に収まるようにする必要があります。

![画面の端まで拡張されたナビゲーション ウィンドウ](images/designing-for-tv/tv-safe-areas-2.png)

ここでは、ナビゲーション ウィンドウの背景は画面の端まで拡張され、ナビゲーション項目はテレビのセーフ エリア内に収まっています。 `SplitView` のコンテンツ (この場合は項目のグリッド) は、途切れずに続いているように見せるために、画面の下部まで拡張されています。一方、グリッドの上部はテレビのセーフ エリア内に収まったままです  (この方法ついて詳しくは、「[リストとグリッドのスクロールの端](#scrolling-ends-of-lists-and-grids)」で説明します)。

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

#### リストとグリッドのスクロールの端

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

## カラー

既定では、ユニバーサル Windows プラットフォームはアプリの色を変更しません。 ただし、テレビでのビジュアル エクスペリエンスを向上させるために、アプリで使う色のセットを改善できます。

### アプリケーション テーマ

アプリに合わせて適切な**アプリケーション テーマ** (濃色または淡色) を選ぶか、テーマを無効にすることができます。 テーマの一般的な推奨事項については、「[配色テーマ](../style/color.md#color-themes)」をご覧ください。

UWP では、アプリが実行されているデバイスから提供されるシステム設定に基づいて、アプリでテーマを動的に設定することもできます。 UWP では、ユーザーが指定したテーマ設定が常に適用されますが、各デバイスは、適切な既定のテーマも提供します。 Xbox One はその性質上、*生産性*エクスペリエンスよりも*メディア* エクスペリエンスを期待されているため、既定で濃色のシステム テーマに設定されます。 アプリのテーマがシステム設定を基にしている場合、Xbox One では既定で濃色に設定されるはずです。

### アクセント カラー

UWP には、ユーザーがシステム設定から選んだ**アクセント カラー**を公開する便利な方法が用意されています。

PC でアクセント カラーを選べるように、ユーザーは Xbox One でユーザーの色を選ぶことができます。 アプリでブラシやカラー リソースからこれらのアクセント カラーを呼び出していれば、ユーザーがシステム設定で選んだ色が使われます。 Xbox One ではアクセント カラーはシステムごとではなくユーザーごとであることに注意してください。

また、Xbox One と PC、電話、その他のデバイスでは、ユーザーの色のセットが異なることに注意してください。 この理由の 1 つとして、これらの色は、Xbox One で最適な 10 フィート エクスペリエンスを提供できるように、この記事で説明するのと同じ方法で厳選されているということがあります。

アプリで **SystemControlForegroundAccentBrush** などのブラシ リソースやカラー リソース (**SystemAccentColor**) を使うか、代わりに [UIColorType.Accent*](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.uicolortype.aspx) API からアクセント カラーを直接呼び出していれば、これらの色はテレビ用に適切なアクセント カラーに置き換えられます。 ハイ コントラストのブラシの色も、PC、電話と同じ方法で (ただし、テレビに適切な色が) システムから取得されます。

アクセント カラー全般について詳しくは、「[アクセント カラー](../style/color.md#accent-color)」をご覧ください。

### テレビごとのカラーの変化

テレビ向けに設計するときには、レンダリングされるテレビごとに色の表示が大きく異なることに注意してください。 モニター上とまったく同じ色に見えるとは限りません。 アプリで UI の各部を区別するために色のわずかな違いを利用している場合、色が混ざり合ってユーザーが混乱する可能性があります。 どのテレビであっても、ユーザーがはっきり区別できる違いがある色を使うようにしてください。

### テレビ セーフ カラー

色の RGB 値は、赤、緑、青の輝度を表します。 テレビでは、極端な輝度をあまりうまく処理できません。そのため、10 フィート エクスペリエンス向けに設計する際に、そのような色は使わないでください。 不自然な縞模様になったり、一部のテレビでは色あせて表示されたりする可能性があります。 また、高輝度色はブルーミング (隣接するピクセルが同じ色を描画する現象) を起こす可能性があります。 

どのような色をテレビ セーフ カラーと見なすかについてはいくつかの考え方がありますが、一般に、RGB 値 16 ～ 235 (16 進数では 10 ～ EB) の色はテレビで使っても安全です。

![テレビ セーフ カラーの範囲](images/designing-for-tv/tv-safe-colors.png)

### テレビ セーフ カラー以外の修正

テレビ セーフ カラー以外の色を個々に調整して、RGB 値がテレビ セーフな範囲内に収まるように修正することを、一般に**カラー クランプ**と呼びます。 この方法は、色数の多いカラー パレットを使わないアプリに適している場合があります。 ただし、この方法だけで色を修正すると、色がうまく調和せず、最適な 10 フィート エクスペリエンスを提供できない可能性があります。

カラー パレットをテレビ向けに最適化するには、カラー クランプなどの方法で色がテレビ セーフであることを確認した後で、**スケーリング**という方法を使うことをお勧めします。

この方法では、すべての色の RGB 値を特定の係数でスケーリングしてテレビ セーフの範囲に収めます。 色が被ることを防ぎ、優れた 10 フィート エクスペリエンスを提供するために、アプリのすべての色をスケーリングすることは効果的な方法です。

![クランプとスケーリング](images/designing-for-tv/clamping-vs-scaling.png)

### アセット

色に変更を加える場合は、それに応じてアセットも必ず更新します。 アプリで、アセット カラーと同じように見えると思われる色を XAML で使う場合、XAML コードだけを更新すると、アセットの色が違って見えます。

### UWP の色のサンプル


              [UWP の配色テーマ](../style/color.md#color-themes)は、アプリの背景 (濃色テーマ用の**黒**または淡色テーマ用の**白**のいずれかになります) をベースに設計されています。 黒と白のどちらもテレビ セーフではないため、これらの色は*クランプ*を使って修正する必要がありました。 また、修正後に、必要なコントラストを保持するために*スケーリング*を使ってその他のすべての色を調整する必要がありました。

<!--[v-lcap to eliot]why is the above paragraph in the past tense?-->
<!--[elcowle] Because this is something that Microsoft had to do to the UWP color themes to accommodate TV-safe colors for Xbox. These themes are then provided in the below code sample.-->

次のサンプル コードは、テレビ向けに最適化された配色テーマを提供します。

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="ApplicationPageBackgroundThemeBrush" 
                                 Color="#FF101010"/>
                <Color x:Key="SystemAltHighColor">#FF101010</Color>
                <Color x:Key="SystemAltLowColor">#33101010</Color>
                <Color x:Key="SystemAltMediumColor">#99101010</Color>
                <Color x:Key="SystemAltMediumHighColor">#CC101010</Color>
                <Color x:Key="SystemAltMediumLowColor">#66101010</Color>
                <Color x:Key="SystemBaseHighColor">#FFEBEBEB</Color>
                <Color x:Key="SystemBaseLowColor">#33EBEBEB</Color>
                <Color x:Key="SystemBaseMediumColor">#99EBEBEB</Color>
                <Color x:Key="SystemBaseMediumHighColor">#CCEBEBEB</Color>
                <Color x:Key="SystemBaseMediumLowColor">#66EBEBEB</Color>
                <Color x:Key="SystemChromeAltLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeBlackHighColor">#FF101010</Color>
                <Color x:Key="SystemChromeBlackLowColor">#33101010</Color>
                <Color x:Key="SystemChromeBlackMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeBlackMediumColor">#CC101010</Color>
                <Color x:Key="SystemChromeDisabledHighColor">#FF333333</Color>
                <Color x:Key="SystemChromeDisabledLowColor">#FF858585</Color>
                <Color x:Key="SystemChromeHighColor">#FF767676</Color>
                <Color x:Key="SystemChromeLowColor">#FF1F1F1F</Color>
                <Color x:Key="SystemChromeMediumColor">#FF262626</Color>
                <Color x:Key="SystemChromeMediumLowColor">#FF2B2B2B</Color>
                <Color x:Key="SystemChromeWhiteColor">#FFEBEBEB</Color>
                <Color x:Key="SystemListLowColor">#19EBEBEB</Color>
                <Color x:Key="SystemListMediumColor">#33EBEBEB</Color>
            </ResourceDictionary>
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="ApplicationPageBackgroundThemeBrush" 
                                 Color="#FFEBEBEB" /> 
                <Color x:Key="SystemAltHighColor">#FFEBEBEB</Color>
                <Color x:Key="SystemAltLowColor">#33EBEBEB</Color>
                <Color x:Key="SystemAltMediumColor">#99EBEBEB</Color>
                <Color x:Key="SystemAltMediumHighColor">#CCEBEBEB</Color>
                <Color x:Key="SystemAltMediumLowColor">#66EBEBEB</Color>
                <Color x:Key="SystemBaseHighColor">#FF101010</Color>
                <Color x:Key="SystemBaseLowColor">#33101010</Color>
                <Color x:Key="SystemBaseMediumColor">#99101010</Color>
                <Color x:Key="SystemBaseMediumHighColor">#CC101010</Color>
                <Color x:Key="SystemBaseMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeAltLowColor">#FF1F1F1F</Color>
                <Color x:Key="SystemChromeBlackHighColor">#FF101010</Color>
                <Color x:Key="SystemChromeBlackLowColor">#33101010</Color>
                <Color x:Key="SystemChromeBlackMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeBlackMediumColor">#CC101010</Color>
                <Color x:Key="SystemChromeDisabledHighColor">#FFCCCCCC</Color>
                <Color x:Key="SystemChromeDisabledLowColor">#FF7A7A7A</Color>
                <Color x:Key="SystemChromeHighColor">#FFB2B2B2</Color>
                <Color x:Key="SystemChromeLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeMediumColor">#FFCCCCCC</Color>
                <Color x:Key="SystemChromeMediumLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeWhiteColor">#FFEBEBEB</Color>
                <Color x:Key="SystemListLowColor">#19101010</Color>
                <Color x:Key="SystemListMediumColor">#33101010</Color>
            </ResourceDictionary> 
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

> [!NOTE]
> 淡色テーマ **SystemChromeMediumLowColor** と **SystemChromeMediumLowColor** は、クランプの結果ではなく、意図的に同じ色になっています。 

> [!NOTE]
> 16 進数の色は **ARGB** (アルファ、赤、緑、青) で指定します。

クランプなしですべての範囲を表示できるモニターでは、テレビ セーフ カラーを使わないことをお勧めします。色があせて見えます。 代わりに、Xbox でアプリを実行し他のプラットフォームで実行*しない*場合は、リソース ディクショナリ (前のサンプル) を読み込みます。 `App.xaml.cs` の `OnLaunched` メソッドに、次のチェックを追加します。

```csharp
if (IsTenFoot)
{ 
    this.Resources.MergedDictionaries.Add(new ResourceDictionary 
    { 
        Source = new Uri("ms-appx:///TenFootStylesheet.xaml") 
    }); 
}
```

> [!NOTE] 
> `IsTenFoot` 変数は、「[Xbox 用のカスタム表示状態のトリガー](#custom-visual-state-trigger-for-xbox)」で定義されています。

これにより、どのデバイスでアプリを実行していても正しい色が表示され、美的に優れた、より良いエクスペリエンスをユーザーに提供できます。

## UI コントロールのガイドライン

いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。 10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。

### ピボット コントロール

[ピボット](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.aspx)は、別のヘッダーやタブを選択することにより、アプリ内でビューのすばやいナビゲーションを提供します。 このコントロールでは、フォーカスがあるヘッダーに下線が引かれ、ゲームパッド/リモコンを使用している場合に、現在選択されているヘッダーがわかりやすくなります。 

![ピボットの下線](images/designing-for-tv/pivot-underline.png)

<!--By default, when you navigate to a `Pivot`, one of the [PivotItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivotitem.aspx)s will get focus. However, you can show focus around all the headers by setting `Pivot.HeaderFocusVisualPlacement="ItemHeaders"`.

![Pivot focus around headers](images/designing-for-tv/pivot-headers-focus.png)-->

電話やタブレットではヘッダーが画面の端で折り返されますが、[Pivot.HeaderOverflowMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.headeroverflowmode.aspx) プロパティを `PivotHeaderOverflowMode.NoWrap` に設定することで、ヘッダーが画面の端で折り返されないように設定できます。 ヘッダーの折り返しを煩わしいと感じるユーザーもいるため、これでテレビなどの大画面表示でエクスペリエンスが向上します。 詳しくは、「[タブとピボット](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/tabs-pivot)」をご覧ください。

<!--If you find it necessary to wrap headers, you can set it so that it doesn't show the selected header in the left-most position, like it does by default. When you set `Pivot.IsHeaderItemsCarouselEnabled="False"`, the selected header will move left by the minimal amount required to become fully visible. This is the recommended approach for 10-foot design.

![Pivot headers carousel disabled](images/designing-for-tv/pivot-headers-carousel.png)-->

### ナビゲーション ウィンドウ

ナビゲーション ウィンドウ (*ハンバーガー メニュー*とも呼ばれる) は、UWP アプリでよく使われるナビゲーション コントロールです。 通常、リスト スタイルのメニューから選択できる複数のオプションを表示するウィンドウであり、ユーザーに異なるページを表示します。 一般的に、このウィンドウは領域を節約するために折りたたまれた状態で表示され、ユーザーがボタンをクリックすることで開くことができます。 

ナビゲーション ウィンドウは、マウスやタッチを使う場合に非常にアクセシビリティが高く、ゲームパッド/リモコンを使う場合はウィンドウを開くボタンに移動する必要があるためアクセシビリティは低くなります。 そのため、ユーザーがページの左端まで移動してナビゲーション ウィンドウを開くことができるだけでなく、**表示**ボタンでナビゲーション ウィンドウを開く操作を可能にすることをお勧めします。 これにより、ユーザーは非常に簡単にウィンドウの内容にアクセスすることができます。 さまざまな画面サイズでのナビゲーション ウィンドウの動作と、ゲームパッド/リモコンでのナビゲーションのベスト プラクティスについては、「[ナビゲーション ウィンドウ](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/nav-pane)」をご覧ください。

### CommandBar のラベル

[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) のアイコンの高さを最小化し、一貫性が保たれるようにするために、アイコンの右側にラベルを配置することをお勧めします。 [CommandBar.DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) プロパティを `CommandBarDefaultLabelPosition.Right` に設定することによって、これを実現できます。

![アイコンの右側にラベルが配置された CommandBar](images/designing-for-tv/commandbar.png)

また、このプロパティを設定するとラベルが常に表示されるようになり、ユーザーのクリック数を最小限に抑えることができるため、10 フィート エクスペリエンスに適しています。 また、これは他の種類のデバイスでも従うべき優れたモデルです。

<!--When there isn't enough space in the window to fit all of the `AppBarButton`s, buttons move into an overflow menu, which is accessed by selecting the "..." button. This happens dynamically as the screen resizes. This generally shouldn't be a problem for TV because the screen size is so large, but if you find that you have overflow buttons, you can specify which appear first using the `AppBarButton.DynamicOverflowOrder` property.

![CommandBar with overflow commands](images/designing-for-tv/commandbar-overflow.png)-->

### Tooltip

[Tooltip](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltip.aspx) コントロールは、ユーザーが要素の上にマウスを置くか、要素をタップして長押ししたときに UI の詳しい情報を提供する方法として導入されました。 ゲームパッドとリモコンの場合、`Tooltip` は、要素にフォーカスが設定されて少し時間が経つと表示され、しばらく画面に表示された後で消えます。 使う `Tooltip` が多すぎると、ユーザーがこの動作を煩わしいと感じる可能性があります。 テレビを設計するときには `Tooltip` を使わないようにしてください。

### ボタンのスタイル

標準的な UWP ボタンもテレビで適切に機能しますが、ボタンのいくつかの視覚スタイルは、より UI に注意を引きます。そのため、すべてのプラットフォーム、特に 10 フィート エクスペリエンスでは、どこにフォーカスがあるかを明確に通知できるというメリットがあるため、検討することをお勧めします。 そのようなスタイルについて詳しくは、「[ボタン](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/buttons)」をご覧ください。

### 入れ子になった UI 要素

UI 要素が他の UI 要素の入れ子になっている場合、既定の動作では、ユーザーは入れ子になった UI 要素にアクセスできません。

主なシナリオの 1 つは、入れ子になった UI 要素にユーザーがマウスを置いたときに UI が表示され、それ以外の場合は表示されない場合です。

![マウスに置くと表示される UI 要素](images/designing-for-tv/2d-navigation-best-practices-ui-elements-display-on-mouse-hover.png)

ゲームパッド/リモコン入力でこのシナリオを処理するお勧めの方法は、それらの UI 要素を `ContextFlyout` に配置することです (「[CommandBar と ContextFlyout](#commandbar-and-contextflyout)」をご覧ください)。

### MediaTransportControls

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

## Xbox のカスタム表示状態トリガー

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
bool IsTenFoot = (Windows.System.Profile.AnaylticsInfo.VersionInfo.DeviceFamily == 
                    "Windows.Xbox");
```

次に、このチェックに続くコード ブロックで、UI に適切な調整を行うことができます。 この例については、「[UWP 色のサンプル](#uwp-color-sample)」をご覧ください。

## まとめ

10 フィート エクスペリエンスの設計には、他のプラットフォーム向けの設計とは対応を変える必要がある、特別な考慮事項があります。 UWP アプリを Xbox One に単純に移植し、うまく動かすことができたとしも、必ずしも 10 フィート エクスペリエンス向けに最適化されるわけではありません。ユーザーのフラストレーションを招くことさえあります。 この記事のガイドラインに従うと、テレビに組み込まれているかのようなすばらしいアプリにすることができます。

## 関連記事

- [ユニバーサル Windows プラットフォーム (UWP) アプリ用デバイスの基本情報](device-primer.md)
- [ゲームパッドとリモコンの操作](gamepad-and-remote-interactions.md)
- [UWP アプリのサウンド](../style/sound.md)



<!--HONumber=Jul16_HO3-->


