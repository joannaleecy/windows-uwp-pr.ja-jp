---
Description: テレビで見栄えよく表示され適切に機能するアプリを設計します。
title: Xbox およびテレビ向け設計
ms.assetid: 780209cb-3e8a-4cf7-8f80-8b8f449580bf
label: Designing for Xbox and TV
template: detail.hbs
isNew: true
keywords: Xbox, テレビ, 10 フィート エクスペリエンス, ゲームパッド, リモコン, 入力, 操作
ms.date: 11/13/2018
ms.topic: article
pm-contact: chigy
design-contact: jeffarn
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 431b8912e43647bc2678aaab7efc9ec68b866d10
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616657"
---
# <a name="designing-for-xbox-and-tv"></a>Xbox およびテレビ向け設計

Xbox One とテレビ画面で見栄えよく表示され、適切に機能するようにユニバーサル Windows プラットフォーム (UWP) アプリの設計を行います。

参照してください[ゲームパッドとリモート制御の相互作用](../input/gamepad-and-remote-interactions.md)相互作用についての UWP アプリケーションのエクスペリエンス、 *10-foot*が発生します。

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

### <a name="simple"></a>Simple

10 フィート環境向けのデザインには特有の課題があります。 解像度と視聴距離の点から、ユーザーはあまり多くの情報を処理できない可能性があります。
単純なデザインになるように、ごくシンプルなコンポーネントだけに絞り込むようにしてください。 テレビに表示される情報の量は、デスクトップではなく、携帯電話と同程度にする必要があります。

![Xbox One ホーム画面](images/designing-for-tv/xbox-home-screen.png)

### <a name="coherent"></a>一貫性

10 フィート環境の UWP アプリは、直感的で簡単に使えるようにします。 何がポイントなのかを明快、明確にしてください。
コンテンツの配置を工夫し、コンテンツ間の移動に一貫性を持たせてユーザーが予測できるようにします。 ユーザーが目的の操作を最短で実行できるように配慮しましょう。

![Xbox One 映画アプリ](images/designing-for-tv/xbox-movies-app.png)

_**すべての映画のスクリーン ショットに示すように Microsoft の映画とテレビで利用できます。**_  

### <a name="captivating"></a>魅力的

最もイマーシブで臨場感のあるエクスペリエンスは、大画面で引き出されます。 画面いっぱいに広がる風景、洗練された動作、鮮やかな色使い、生き生きとした文字が、アプリをワンランク上に引き上げます。 大胆で美しいデザインにしましょう。

![Xbox One アバター アプリ](images/designing-for-tv/xbox-avatar-app.png)

### <a name="optimizations-for-the-10-foot-experience"></a>10 フィート エクスペリエンス向けの最適化

ここまで、10 フィート エクスペリエンス向けに優れた UWP アプリを設計する原則を説明しました。次に、アプリを最適化して優れたユーザー エクスペリエンスを提供する具体的な方法について、概要を示します。

| 機能        | 説明           |
| -------------------------------------------------------------- |--------------------------------|
| [UI 要素のサイズ変更](#ui-element-sizing)  | ユニバーサル Windows プラットフォームは、[スケーリングと有効ピクセル](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)を使い、視聴距離に合わせて UI をスケーリングします。 サイズについて理解し UI 全体に適用すれば、アプリを 10 フィート環境用に最適化するのに役立ちます。  |
|  [テレビの安全な領域](#tv-safe-area) | UWP は既定で、テレビのセーフ エリア以外の領域 (画面の端に近い部分) に UI を表示することを自動的に避けます。 ただし、この場合、アスペクト比が変わり、UI がレターボックス化されてしまいます。 テレビでイマーシブなアプリにするには、サポートしているテレビで、画面の端まで広がるようにアプリを変更します。 |
| [色](#colors)  |  UWP は配色テーマをサポートしています。システム テーマを引き継ぐアプリは、Xbox One では既定で**濃色**になります。 アプリに特定の配色テーマがある場合、テレビではうまく表示されないために一部の色を避ける必要があることに注意してください。 |
| [サウンド](../style/sound.md)    | サウンドは、ユーザーを没頭させたりユーザーにフィードバックを提供したりする上で役立ち、10 フィート エクスペリエンスで重要な役割を果たします。 UWP には、アプリが Xbox One で実行されているときは一般的なコントロールのサウンドを自動的に有効にする機能があります。 UWP に組み込まれているサウンド サポートの詳細とその活用方法について説明します。    |
| [UI コントロールのガイドライン](#guidelines-for-ui-controls)  |  いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。 10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。 |
| [Xbox 用のカスタムの表示状態トリガー](#custom-visual-state-trigger-for-xbox) | UWP アプリを 10 フィート エクスペリエンス用にカスタマイズする場合、カスタム*表示状態トリガー*を使用して、アプリが Xbox コンソールで起動されたことを検出したときにアプリのレイアウトが変わるようにすることをお勧めします。 |

数がある、前のデザインとレイアウトに関する考慮事項に加えて[ゲームパッド、リモート_コントロールの相互作用](../input/gamepad-and-remote-interactions.md)最適化は、アプリを構築するときに検討してください。

| 機能        | 説明           |
| -------------------------------------------------------------- |--------------------------------|
| [お客様 xy のところフォーカスのナビゲーションと相互作用](../input/gamepad-and-remote-interactions.md#xy-focus-navigation-and-interaction) | **お客様 xy のところフォーカスのナビゲーション**ユーザーがアプリの UI を移動できるようにします。 ただし、ユーザーの移動は上下左右に制限されます。 このセクションでは、この点に対応するための推奨事項とその他の考慮事項について説明します。 |
| [マウス モード](../input/gamepad-and-remote-interactions.md#mouse-mode)|お客様 xy のところフォーカスのナビゲーションは、実用的でも、可能性もいくつかの種類のマップまたは描画とペイント アプリなどのアプリケーションがありません。 このような場合は、**マウス モード**ゲームパッドまたはリモート コントロール、ユーザーが自由に移動できますが、PC 上のマウスと同様です。|
| [フォーカス ビジュアル](../input/gamepad-and-remote-interactions.md#focus-visual)  | フォーカスのビジュアルでは、現在フォーカスがある UI 要素を強調表示する罫線です。 これにより、ユーザーの間の移動またはとの対話は、UI をすばやく識別できます。  |
| [フォーカス engagement](../input/gamepad-and-remote-interactions.md#focus-engagement) | フォーカス engagement には、キーを押すユーザーが必要があります、**する/選択**ゲームパッドまたは UI 要素にフォーカスがある場合は、対話するために、リモート コントロールのボタン。 |
| [ハードウェア ボタン](../input/gamepad-and-remote-interactions.md#hardware-buttons) | ゲームパッド、リモート_コントロールは、非常にさまざまなボタンと構成を提供します。 |

> [!NOTE]
> このトピックで示すコード スニペットはほとんどが XAMLで/c# ですが、基本原則と概念はすべての UWP アプリに共通です。 Xbox 向けの HTML/JavaScript UWP アプリを開発している場合は、GitHub の [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) ライブラリを参照することをお勧めします。

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

UI を簡略化するために、ユーザーがテレビ画面の端から端まで移動するときに、**クリックは 6 回**以内になるようにします。 ここでも**簡潔さ**の原則が重要です。 

![6 つのアイコン分の幅](images/designing-for-tv/six-clicks.png)

### <a name="text-sizes"></a>テキスト サイズ

UI を離れた位置から見えるようにするために、次の経験則に従ってください。

* メイン テキストとコンテンツの読み取り:15 epx の最小値
* 重大ではない文字列および補助コンテンツ:12 epx の最小値

UI でさらに大きなテキストを使う場合は、画面領域をあまり狭めないサイズを選び、他のコンテンツのためのスペースを圧迫しないようにします。

### <a name="opting-out-of-scale-factor"></a>拡大縮小率の無効化

アプリでは拡大縮小率のサポートを利用することをお勧めします。この機能は、各デバイスの種類に合わせて拡大縮小することで、すべてのデバイスでアプリを適切に実行するためのものです。
しかし、この動作を無効にして、すべての UI を 100% の拡大縮小率で設計することもできます。 100% 以外の拡大縮小率には変更できないことに注意してください。

XAML アプリでは、次のコード スニペットを使って倍率を無効にすることができます。

```csharp
bool result =
    Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```

無効化に成功したかどうかは `result` で通知されます。

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

### <a name="image"></a>Image

```xml
<Page x:Class="Sample.MainPage"
      Background="\Assets\Background.png"/>
```

追加の作業を行わない場合、アプリは次のように表示されます。

![テレビのセーフ エリア](images/designing-for-tv/tv-safe-area.png)

この場合、アプリのアスペクト比が変わり、ナビゲーション ウィンドウやグリッドなど UI の一部が切れて表示されるため、最適とはいえません。 ただし、UI の一部を画面の端まで拡張し、アプリに映画のような効果を持たせることで最適化することができます。

### <a name="drawing-ui-to-the-edge"></a>端までの UI の描画

ユーザーに没入感を提供するために、特定の UI 要素を使って画面の端まで拡張することをお勧めします。 [ScrollViewer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer)、[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)、[CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar) などを使えます。

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

このコード行で、アプリ ウィンドウは画面の端まで拡張されます。そのため、前に説明したテレビのセーフ エリアへ、すべての対話型 UI と重要な UI を移動する必要があります。 コンテキスト メニューや開かれた状態の [ComboBoxes](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox) などの一時的な UI は、テレビのセーフ エリア内に自動的に残ります。

![コア ウィンドウの境界](images/designing-for-tv/core-window-bounds.png)

#### <a name="pane-backgrounds"></a>ウィンドウの背景

通常、ナビゲーション ウィンドウは画面の端近くに描画されるため、不自然なギャップが入らないように背景をテレビのセーフ エリア以外まで広げる必要があります。 ナビゲーション ウィンドウの背景の色をアプリの背景の色に変更するだけで、これを行うことができます。

既に説明したように、コア ウィンドウの境界を使用すると、画面の端まで UI を描画することができますが、さらに [SplitView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SplitView) のコンテンツで正の余白を使用してコンテンツがテレビ セーフ エリア内に収まるようにする必要があります。

![画面の端まで拡張されたナビゲーション ウィンドウ](images/designing-for-tv/tv-safe-areas-2.png)

ここでは、ナビゲーション ウィンドウの背景は画面の端まで拡張され、ナビゲーション項目はテレビのセーフ エリア内に収まっています。
`SplitView` のコンテンツ (この場合は項目のグリッド) は、途切れずに続いているように見せるために、画面の下部まで拡張されています。一方、グリッドの上部はテレビのセーフ エリア内に収まったままです。 (この方法ついて詳しくは、「[リストとグリッドのスクロールの端](#scrolling-ends-of-lists-and-grids)」で説明します)。

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

[CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar) も、アプリの 1 つまたは複数の端の近くに置かれることが多いウィンドウの例ですが、そのためにテレビではその背景を画面の端まで拡張する必要があります。 これには通常、**[その他]** ボタンも含まれます。[その他] ボタンは右側に表示する "..." で表し、テレビのセーフ エリア内に収める必要があります。 目的の操作と視覚効果を実現するためのいくつかの異なる方法を次に示します。

**オプション 1**:変更、`CommandBar`背景色を透明またはページの背景と同じ色。

```xml
<CommandBar x:Name="topbar"
            Background="{ThemeResource SystemControlBackgroundAltHighBrush}">
            ...
</CommandBar>
```

これで、`CommandBar` がページの残りの部分と同じ背景の上にあるように見え、背景が画面の端まで切れ目なく続きます。

**オプション 2**:バック グラウンドの四角形の塗りつぶしが同じ色を追加として、 `CommandBar` 、バック グラウンドしてそれを下にある、`CommandBar`およびページの残りの部分間。

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

UWP にはフォーカス表示を [VisibleBounds](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview.visiblebounds) 内に保持する機能がありますが、リストやグリッドの項目をセーフ エリアの表示領域内までスクロールできるように余白を追加する必要があります。 具体的には、次のコード スニペットのように、[ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) または [GridView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.GridView) の [ItemsPresenter](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ItemsPresenter) に正の余白を追加します。

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
> このコード スニペットは `ListView` 専用です。`GridView` のスタイルの場合、[ControlTemplate](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ControlTemplate) と [Style](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Style) の両方の [TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype) 属性を `GridView` に設定します。

アプリケーションの対象バージョン 1803 または後で、使用できる場合にビューに取り込まれます項目の方法よりきめ細かく制御、 [UIElement.BringIntoViewRequested イベント](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.bringintoviewrequested)します。 配置することができます、 [ItemsPanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemspanel)の**ListView**/**GridView** 、内部の前にそれをキャッチする**ScrollViewer**次のコード スニペットのように実行します。

```xaml
<GridView x:Name="gridView">
    <GridView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid Orientation="Horizontal"
                           BringIntoViewRequested="ItemsWrapGrid_BringIntoViewRequested"/>
        </ItemsPanelTemplate>
    </GridView.ItemsPanel>
</GridView>
```

```cs
// The BringIntoViewRequested event is raised by the framework when items receive keyboard (or Narrator) focus or 
// someone triggers it with a call to UIElement.StartBringIntoView.
private void ItemsWrapGrid_BringIntoViewRequested(UIElement sender, BringIntoViewRequestedEventArgs args)
{
    if (args.VerticalAlignmentRatio != 0.5)  // Guard against our own request
    {
        args.Handled = true;
        // Swallow this request and restart it with a request to center the item.  We could instead have chosen
        // to adjust the TargetRect’s Y and Height values to add a specific amount of padding as it bubbles up, 
        // but if we just want to center it then this is easier.

        // (Optional) Account for sticky headers if they exist
        var headerOffset = 0.0;
        var itemsWrapGrid = sender as ItemsWrapGrid;
        if (gridView.IsGrouping && itemsWrapGrid.AreStickyGroupHeadersEnabled)
        {
            var header = gridView.GroupHeaderContainerFromItemContainer(args.TargetElement as GridViewItem);
            if (header != null)
            {
                headerOffset = ((FrameworkElement)header).ActualHeight;
            }
        }

        // Issue a new request
        args.TargetElement.StartBringIntoView(new BringIntoViewOptions()
        {
            AnimationDesired = true,
            VerticalAlignmentRatio = 0.5, // a normalized alignment position (0 for the top, 1 for the bottom)
            VerticalOffset = headerOffset, // applied after meeting the alignment ratio request
        });
    }
}
```

## <a name="colors"></a>Colors (画面の色)

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

アプリで **SystemControlForegroundAccentBrush** などのブラシ リソースやカラー リソース (**SystemAccentColor**) を使うか、代わりに [UIColorType.Accent*](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UIColorType) API からアクセント カラーを直接呼び出していれば、これらの色は Xbox One で利用可能なアクセント カラーに置き換えられます。 ハイ コントラストのブラシの色も、PC や電話と同じ方法でシステムから取得されます。

アクセント カラー全般について詳しくは、「[アクセント カラー](../style/color.md#accent-color)」をご覧ください。

### <a name="color-variance-among-tvs"></a>テレビごとのカラーの変化

テレビ向けに設計するときには、レンダリングされるテレビごとに色の表示が大きく異なることに注意してください。 モニター上とまったく同じ色に見えるとは限りません。 アプリで UI の各部を区別するために色のわずかな違いを利用している場合、色が混ざり合ってユーザーが混乱する可能性があります。 どのテレビであっても、ユーザーがはっきり区別できる違いがある色を使うようにしてください。

### <a name="tv-safe-colors"></a>テレビ セーフ カラー

色の RGB 値は、赤、緑、青の輝度を表します。 テレビでは、極端な輝度をあまりうまく処理できません。不自然な縞模様になったり、一部のテレビでは色あせて表示されたりする可能性があります。 また、高輝度色はブルーミング (隣接するピクセルが同じ色を描画する現象) を起こす可能性があります。 どのような色をテレビ セーフ カラーと見なすかについてはいくつかの考え方がありますが、一般に、RGB 値 16 ～ 235 (16 進数では 10 ～ EB) の色はテレビで使っても安全です。

![テレビ セーフ カラーの範囲](images/designing-for-tv/tv-safe-colors-2.png)

従来、Xbox 上のアプリは、この "テレビ セーフ" カラーの範囲内に収まるように色を調整する必要がありました。ただし、Fall Creators Update 以降、Xbox One はすべての範囲のコンテンツをテレビ セーフ範囲に自動的に対応させています。 つまり、ほとんどのアプリ開発者がテレビ セーフ カラーについて心配する必要がなくなりました。

> [!IMPORTANT]
> 既にテレビ セーフ カラーの範囲内にあるビデオ コンテンツは、[メディア ファンデーション](https://docs.microsoft.com/windows/desktop/medfound/microsoft-media-foundation-sdk) を使用して再生する場合、このカラー スケール効果は適用されません。

DirectX 11 または DirectX 12 を使ってアプリを開発し、UI またはビデオをレンダリングするために独自のスワップ チェーンを作成している場合、[IDXGISwapChain3::SetColorSpace1](https://docs.microsoft.com/windows/desktop/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-setcolorspace1) を呼び出して使用する色空間を指定できるため、色の操作が必要かどうかをシステムに通知します。

## <a name="guidelines-for-ui-controls"></a>UI コントロールのガイドライン

いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。 10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。

### <a name="pivot-control"></a>ピボット コントロール

[ピボット](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)は、別のヘッダーやタブを選択することにより、アプリ内でビューのすばやいナビゲーションを提供します。 このコントロールでは、フォーカスがあるヘッダーに下線が引かれ、ゲームパッド/リモコンを使用している場合に、現在選択されているヘッダーがわかりやすくなります。

![ピボットの下線](images/designing-for-tv/pivot-underline.png)

[Pivot.IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pivot.isheaderitemscarouselenabledproperty) プロパティを `true` に設定すると、選択したピボット ヘッダーが常に最初の位置に移動する代わりに、ピボットが常に同じ位置に固定されます。 ヘッダーの折り返しを煩わしいと感じるユーザーもいるため、これでテレビなどの大画面表示でエクスペリエンスが向上します。 すべてのピボット ヘッダーが同時に画面に収まらない場合、ユーザーは表示されるスクロール バーを使って他のヘッダーを表示できますが、最良のエクスペリエンスを提供するためには、すべてのピボット ヘッダーが画面に収まることを確認する必要があります。 詳しくは、「[タブとピボット](/windows/uwp/design/controls-and-patterns/pivot)」をご覧ください。

### <a name="navigation-pane-a-namenavigation-pane-"></a>ナビゲーション ウィンドウ <a name="navigation-pane" />

ナビゲーション ウィンドウ (*ハンバーガー メニュー*とも呼ばれる) は、UWP アプリでよく使われるナビゲーション コントロールです。 通常、リスト スタイルのメニューから選択できる複数のオプションを表示するウィンドウであり、ユーザーに異なるページを表示します。 一般的に、このウィンドウは領域を節約するために折りたたまれた状態で表示され、ユーザーがボタンをクリックすることで開くことができます。

ナビゲーション ウィンドウは、マウスやタッチを使う場合に非常にアクセシビリティが高く、ゲームパッド/リモコンを使う場合はウィンドウを開くボタンに移動する必要があるためアクセシビリティは低くなります。 そのため、ユーザーがページの左端まで移動してナビゲーション ウィンドウを開くことができるだけでなく、**表示**ボタンでナビゲーション ウィンドウを開く操作を可能にすることをお勧めします。 この設計パターンを実装する方法を示すコード サンプルは、「[プログラムによるフォーカス ナビゲーション](../input/focus-navigation-programmatic.md#split-view-code-sample)」にあります。 これにより、ユーザーは非常に簡単にウィンドウの内容にアクセスすることができます。 さまざまな画面サイズでのナビゲーション ウィンドウの動作と、ゲームパッド/リモコンでのナビゲーションのベスト プラクティスについては、「[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)」をご覧ください。

### <a name="commandbar-labels"></a>CommandBar のラベル

[CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar) のアイコンの高さを最小化し、一貫性が保たれるようにするために、アイコンの右側にラベルを配置することをお勧めします。 [CommandBar.DefaultLabelPosition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar.defaultlabelpositionproperty) プロパティを `CommandBarDefaultLabelPosition.Right` に設定することによって、これを実現できます。

![アイコンの右側にラベルが配置された CommandBar](images/designing-for-tv/commandbar.png)

また、このプロパティを設定するとラベルが常に表示されるようになり、ユーザーのクリック数を最小限に抑えることができるため、10 フィート エクスペリエンスに適しています。 また、これは他の種類のデバイスでも従うべき優れたモデルです。

### <a name="tooltip"></a>ヒント

[Tooltip](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ToolTip) コントロールは、ユーザーが要素の上にマウスを置くか、要素をタップして長押ししたときに UI の詳しい情報を提供する方法として導入されました。 ゲームパッドとリモコンの場合、`Tooltip` は、要素にフォーカスが設定されて少し時間が経つと表示され、しばらく画面に表示された後で消えます。 使う `Tooltip` が多すぎると、ユーザーがこの動作を煩わしいと感じる可能性があります。 テレビを設計するときには `Tooltip` を使わないようにしてください。

### <a name="button-styles"></a>ボタンのスタイル

標準的な UWP ボタンもテレビで適切に機能しますが、ボタンのいくつかの視覚スタイルは、より UI に注意を引きます。そのため、すべてのプラットフォーム、特に 10 フィート エクスペリエンスでは、どこにフォーカスがあるかを明確に通知できるというメリットがあるため、検討することをお勧めします。 そのようなスタイルについて詳しくは、「[ボタン](../controls-and-patterns/buttons.md)」をご覧ください。

### <a name="nested-ui-elements"></a>入れ子になった UI 要素

入れ子になった UI は、コンテナー UI 要素内部に囲まれた、操作できる入れ子になったアイテムを公開します。入れ子になったアイテムとコンテナー アイテムはどちらも互いに、個別のフォーカスを取得することが可能です。

入れ子になった UI がうまく機能する入力の種類もありますが、XY ナビゲーションに依存するゲームパッドやリモコンでは、うまく機能するとは限りません。 このトピックのガイダンスに従い、UI が 10 フィート環境に最適化され、ユーザーが対話可能なすべての要素に容易にアクセスできるようにしてください。 1 つの一般的な解決策は、入れ子になった UI 要素を配置する、`ContextFlyout`します。

入れ子になった UI について詳しくは、「[リスト項目の入れ子になった UI](../controls-and-patterns/nested-ui.md)」をご覧ください。

### <a name="mediatransportcontrols"></a>MediaTransportControls

[MediaTransportControls](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaTransportControls) 要素によって、ユーザーが再生、一時停止、クローズド キャプションの有効化などの操作を実行できる既定の再生エクスペリエンスが提供され、ユーザーはメディアを操作することができます。 このコントロールは、[MediaPlayerElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaPlayerElement) のプロパティであり、*1 行*と *2 行*の 2 つのレイアウト オプションをサポートしています。 1 行のレイアウトでは、スライダーと再生ボタンはすべて 1 つの行に配置され、スライダーの左側に再生/一時停止ボタンが配置されます。 2 行のレイアウトでは、スライダーは独自の行に配置され、再生ボタンは下側の別の行に配置されます。 10 フィート エクスペリエンス向けに設計する場合は、ゲームパッドでのナビゲーションが向上するため、2 行のレイアウトを使用してください。 2 行のレイアウトを有効にするには、`MediaPlayerElement` の [TransportControls](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement.transportcontrols) プロパティの `MediaTransportControls` 要素で `IsCompact="False"` を設定します。

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

> ![注] `MediaPlayerElement` は Windows 10 バージョン 1607 以降でのみ使用できます。 Windows 10 の以前のバージョン用にアプリを開発する場合は、代わりに [MediaElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaElement) を使用する必要があります。 上記の推奨事項は `MediaElement` にも適用され、`TransportControls` プロパティも同じ方法でアクセスされます。

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

次に、このチェックに続くコード ブロックで、UI に適切な調整を行うことができます。 

## <a name="summary"></a>概要

10 フィート エクスペリエンスの設計には、他のプラットフォーム向けの設計とは対応を変える必要がある、特別な考慮事項があります。 UWP アプリを Xbox One に単純に移植し、うまく動かすことができたとしも、必ずしも 10 フィート エクスペリエンス向けに最適化されるわけではありません。ユーザーのフラストレーションを招くことさえあります。 この記事のガイドラインに従うと、テレビに組み込まれているかのようなすばらしいアプリにすることができます。

## <a name="related-articles"></a>関連記事

- [ユニバーサル Windows プラットフォーム (UWP) アプリ向けのデバイス入門](index.md)
- [ゲームパッドとリモート制御の相互作用](../input/gamepad-and-remote-interactions.md)
- [UWP アプリでサウンド](../style/sound.md)
