---
author: mijacobs
description: 
title: "アクリル素材"
template: detail.hbs
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: rybick
dev-contact: jevansa
doc-status: Published
ms.openlocfilehash: 01c8d1bd961a5246a052d1dc7a746257687104e4
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="acrylic-material"></a>アクリル素材
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

> [!IMPORTANT]
> この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

アクリルは [Brush](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush) の一種であり、半透明のテクスチャを作成します。 アクリルをアプリ サーフェスに適用すると、奥行きを加えたり、視覚的な階層を確立したりすることができます。  <!-- By allowing user-selected wallpaper or colors to shine through, Acrylic keeps users in touch with the OS personalization they've chosen. -->

> **重要な API**: [AcrylicBrush クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush)、[Background プロパティ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Background)


![淡色テーマのアクリル](images/Acrylic_DarkTheme_Base.png)

![濃色テーマのアクリル](images/Acrylic_LightTheme_Base.png)

## <a name="acrylic-and-the-fluent-design-system"></a>アクリルと Fluent Design System

 Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。 アクリルは、アプリに物理的なテクスチャ (マテリアル) と深度を追加する Fluent Design System コンポーネントです。 

## <a name="when-to-use-acrylic"></a>アクリルを使用する状況

アプリ内ナビゲーションの要素やコマンド実行要素などのサポート UI は、アクリル サーフェス上に配置することをお勧めします。 アクリル素材は、ダイアログやポップアップなどの一時的な UI の要素を使用する場合にも役立ちます。これは、この素材によって、一時的な UI をトリガーしたコンテンツとの視覚的な関係を維持することができるためです。 アクリルは、背景素材として使用し、視覚的に分離されたウィンドウ内に表示するように設計されています。そのため、アクリルは詳細な前景要素には適用しないでください。

アプリの主要なコンテンツの背後にあるサーフェスでは、単色で不透明な背景を使用してください。

滑らかな表示を実現するには、アクリルを、アプリの 1 つまたは複数の端にまで (ウィンドウのタイトル バーも含む) 拡張することを検討してください。 ブレンドの種類が異なる複数のアクリルを相互に隣接するように重ねて、ストライプ効果を作成することは回避してください。 アクリルは、デザインで視覚的な調和をとるためのツールですが、正しく使用しないと、視覚的なノイズになる場合があります。

次の使用パターンを検討して、アクリルをアプリに組み込むに最適な方法を決定してください。

### <a name="vertical-acrylic-pane"></a>垂直方向のアクリル ウィンドウ

垂直方向のナビゲーションを行うアプリでは、アクリルを、ナビゲーション要素を含んでいるセカンダリ ウィンドウに適用することをお勧めします。

![1 つの垂直方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_vertical.png)

[NavigationView](../controls-and-patterns/navigationview.md) は、ナビゲーションをアプリに追加し、そのビジュアル デザインにアクリルを取り込むための新しいコモン コントロール です。 NavigationView のウィンドウでは、ウィンドウが主要なコンテンツと並んで開かれるとき、背景アクリルが表示されます。また、ウィンドウがオーバーレイとして開くと、自動的にアプリ内アクリルに切り替わります。

アプリでは NavigationView を利用できず、独自にアクリルを追加することを検討している場合は、比較的透明なアクリル (濃淡の透明度が 60%) を使用することをお勧めします。
 - ウィンドウが他のアプリ コンテンツ上でオーバーレイとして開くときは、[60% のアプリ内アクリル](#acrylic-theme-resources)にする必要があります
 - ウィンドウがメイン アプリ コンテンツと並んで開かれるときは、[60% の背景アクリル](#acrylic-theme-resources)にする必要があります

### <a name="multiple-acrylic-panes"></a>複数のアクリル ウィンドウ

3 つの異なる垂直方向のウィンドウを持つアプリでは、アクリルを主要なコンテンツ以外のコンテンツに追加することをお勧めします。
 - 主要なコンテンツの最も近くに表示される第 2 ウィンドウでは、[80% の背景アクリル](#acrylic-theme-resources)を使用します
 - 主要なコンテンツから離れて表示される第 3 ウィンドウでは、[60% の背景アクリル](#acrylic-theme-resources)を使用します

![2 つの垂直方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_double-vertical.png)

### <a name="horizontal-acrylic-pane"></a>水平方向のアクリル ウィンドウ

水平方向のナビゲーションやコマンド実行を行ったり、アプリの上部で水平方向に他の重要な要素が表示されるアプリでは、この視覚要素に [70% のアクリル](#acrylic-theme-resources)を適用することをお勧めします。

![水平方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_horizontal.png)

連続性があるズーム可能なコンテンツに重点を置くキャンバス アプリでは、上部のバーでアプリ内アクリルを使用し、ユーザーがこのコンテンツにアクセスできるようにしてください。 キャンバス アプリには、マップや各種の描画を含んでいるものがあります。

単一の連続したキャンバスのないアプリでは、背景アクリルを使用して、ユーザーがデスクトップ環境全体にアクセスできるようにすることをお勧めします。

### <a name="acrylic-in-utility-apps"></a>ユーティリティ アプリでのアクリル

ウィジェットや軽量アプリでは、アプリ ウィンドウの内部いっぱいにアクリルを描画して、ユーティリティ アプリとしての用途を強化することができます。 このカテゴリのアプリは、ユーザーによる使用時間が短く、ユーザーのデスクトップ画面全体を占有することもないのが一般的です。 たとえば、電卓やアクション センターが該当します。

![アクリルを背景全体として使用した電卓ユーティリティ アプリ](images/acrylic_app-pattern_full.png)

> [!Note]
> アクリル サーフェスのレンダリングでは GPU を集中的に使用するため、デバイスの電力消費が増加し、バッテリー残量が少なくなる可能性があります。 デバイスがバッテリー節約モードになると、アクリルの効果は自動的に無効になります。また、ユーザーは、必要に応じてすべてのアプリでアクリルの効果を無効にすることができます。


## <a name="acrylic-blend-types"></a>アクリル ブレンドの種類
アクリルの最も注目すべき特徴は、その透明度です。 アクリル ブレンドの種類は 2 つあり、素材を通して何が表示されるかを変更することができます。
 - **背景アクリル**では、デスクトップの壁紙と現在アクティブになっているアプリの背後にある他のウィンドウが表示されます。これにより、アプリケーション ウィンドウの間に奥行きが出て、ユーザーが個人的に優先する画面を明示しておくことができます。
 - **アプリ内アクリル**では、アプリ フレーム内に奥行きの感覚がもたらされ、フォーカスと階層の両方が提供されます。

 ![背景アクリル](images/BackgroundAcrylic_DarkTheme.png)

 ![アプリ内アクリル](images/AppAcrylic_DarkTheme.png)

 複数のアクリル サーフェスを重ねる場合には注意が必要です。 背景アクリルは、その名前が示すように、Z オーダーではユーザーの最も近くには表示しないでください。 背景アクリルの複数のレイヤーは、予期しない目の錯覚を引き起こす傾向があるので、使用しないでください。 アクリルを重ねる場合は、アプリ内アクリルを重ねてください。また、アクリルの濃淡が薄くなるように値を設定して、アクリルのレイヤーが視覚的に閲覧者の近くに表示されるようにすることを検討してください。


## <a name="usability-and-adaptability"></a>使いやすさと適応性
アクリルの外観は、さまざまなデバイスやコンテキストに合うように自動的に対応します。

ハイ コントラスト モードでは、ユーザーが選んだ見慣れた背景色が、アクリルの代わりに引き続き表示されます。 また次の場合には、背景アクリルとアプリ内アクリルはどちらも、単色として表示されます。
 - ユーザーが個人用設定で透明度をオフにした場合
 - バッテリー節約機能モードがアクティブ化されている場合
 - アプリがローエンド ハードウェアで実行されている場合

また次の場合には、背景アクリルのみ、その透明度とテクスチャを単色で置き換えることができます。
 - アプリ ウィンドウがデスクトップで非アクティブ化されている場合
 - UWP アプリが、電話、Xbox、HoloLens、またはタブレット モードで実行されている場合

### <a name="legibility-considerations"></a>見やすくするための考慮事項
アプリがユーザーに表示するすべてのテキストでは、[コントラスト比を適切な値にする](../accessibility/accessible-text-requirements.md)ことが重要です。 ハイカラーの黒や白のテキスト、またはミディアムカラーの灰色のテキストがアクリル上で適切なコントラスト比になるように、アクリルのレシピは最適化されています。 プラットフォームによって提供されるテーマ リソースは、既定で、濃淡の色のコントラストが 80% の不透明度に設定されます。 ハイカラーの本文テキストをアクリル上に配置する場合、濃淡の不透明度を下げて、見やすさを維持することができます。 ダーク モードでは濃淡の不透明度を 70% にすることができ、ライト モードのアクリルではコントラスト比を 50% の不透明度に合わせることができます。

アクリル サーフェスの上にアクセント カラーのテキストを配置することはお勧めしません。これは、これらの組み合わせが、15 ピクセルのフォント サイズでのコントラスト比の最小要件を満たさない可能性があるためです。 [ハイパーリンク](../controls-and-patterns/hyperlinks.md)はアクリル要素上には配置しないようにしてください。 また、アクリルの濃淡の色や透明度のレベルを、テーマ リソースによって提供されるプラットフォームの既定値以外にカスタマイズする場合は、見やすさへの影響を考慮してください。

## <a name="acrylic-theme-resources"></a>アクリルのテーマ リソース
新しい XAML AcrylicBrush テーマ リソースや定義済みの AcrylicBrush テーマ リソースを使用して、アクリルをアプリのサーフェスに簡単に適用できます。 まず、アプリ内アクリルまたは背景アクリルのどちらを使用するかを決める必要があります。 この記事で推奨事項として既に説明した一般的なアプリのパターンを確認してください。

背景アクリルやアプリ内アクリルの両方を対象としたブラシのテーマ リソースのコレクションが作成されています。これらのリソースでは、アプリのテーマが重視され、必要に応じて、単色にフォール バックします。 *Acrylic\*WindowBrush* という名前のリソースは背景アクリルを表し、*Acrylic\*ElementBrush* はアプリ内アクリルを表します。

<table>
    <tr>
        <th align="center">リソース キー</th>
        <th align="center">濃淡の不透明度</th>
        <th align="center">[フォールバックの色](color.md)</th>
    </tr>
    <tr>
        <td> SystemControlAcrylicWindowBrush<br/>SystemControlAcrylicElementBrush </td>
        <td align="center"> 80% </td>
        <td> ChromeMedium </td>
    </tr>
    </tr>
        <td> **推奨する使用方法:** これらは、汎用的なアクリルのリソースであり、さまざまな使用方法で適切に機能します。 アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセルよりも小さい場合は、[コントラスト比の要件を満たすように](../accessibility/accessible-text-requirements.md)、80% のアクリル リソースをテキストの背景に配置してください。 </td>
    </tr>
    <tr>
        <td> SystemControlAcrylicMediumHighWindowBrush<br/>SystemControlAcrylicMediumHighElementBrush </td>
        <td align="center"> 70% </td>
        <td> ChromeMedium </td>
    </tr>
    <tr>
        <td> **推奨する使用方法:** アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセル以上になる場合は、これらのより透過的な 70% のアクリル リソースをテキストの背景に配置できます。 これらのリソースは、アプリの最上部にある水平方向のナビゲーション領域やコマンド実行領域で使用することをお勧めします。  </td>
    </tr>
    <tr>
        <td> SystemControlAcrylicMediumWindowBrush<br/>SystemControlAcrylicMediumElementBrush </td>
        <td align="center"> 60% </td>
        <td> ChromeMediumLow </td>
    </tr>
    <tr>
        <td> **推奨する使用方法:** プライマリ テキストの色が AltHigh で、このテキストのみをアクリルの上に配置する場合は、これらの 60% のリソースを利用できます。 アプリの[垂直方向のナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md) (ハンバーガー メニュー) を描画するときは、60% のアクリルを使用することをお勧めします。 </td>
    </tr>
</table>

中間色のアクリルに加え、ユーザーが指定したアクセント カラーを使用してアクリルに濃淡を付けるリソースも追加しました。 色が付いたアクリルは慎重に使用してください。 提供されている dark1 と dark2 のバリアントを使用する場合、濃色テーマのテキストの色と調和するように、白または明るい色のテキストをこれらのリソース上に配置してください。
<table>
    <tr>
        <th align="center">リソース キー</th>
        <th align="center">濃淡の不透明度</th>
        <th align="center">[濃淡とフォールバックの色](color.md)</th>
    </tr>
    <tr>
        <td> SystemControlAcrylicAccentMediumHighWindowBrush<br/>SystemControlAcrylicAccentMediumHighElementBrush </td>
        <td align="center"> 70% </td>
        <td> SystemAccentColor </td>
    </tr>
    <tr>
        <td> SystemControlAcrylicAccentDark1WindowBrush<br/>SystemControlAcrylicAccentDark1ElementBrush </td>
        <td align="center"> 80% </td>
        <td> SystemAccentColorDark1 </td>
    </tr>
    <tr>
        <td> SystemControlAcrylicAccentDark2MediumHighWindowBrush<br/>SystemControlAcrylicAccentDark2MediumHighElementBrush </td>
        <td align="center"> 70% </td>
        <td> SystemAccentColorDark2 </td>
    </tr>
</table>


特定のサーフェスを塗りつぶすには、上記のテーマ リソースのいずれかを、他のブラシ リソースを適用する要素の背景に適用します。

```xaml
<Grid Background="{ThemeResource SystemControlAcrylicElementBrush}">
```

## <a name="custom-acrylic-brush"></a>カスタム アクリル ブラシ
色の濃淡をアプリのアクリルに加えて、ブランドを表示したり、ページ上にある他の要素と視覚的にバランスをとったりすることができます。 グレースケール以外の色を表示するには、次のプロパティを使って、独自のアクリル ブラシを定義する必要があります。
 - **TintColor**: 色/濃淡のオーバーレイ レイヤーです。 RGB の色の値とアルファ チャネルの不透明度の両方を指定することを検討してください。
 - **TintOpacity**: 濃淡レイヤーの不透明度です。 開始点として 80% の不透明度をお勧めします。ただし、透明度が異なると、別の色を使用したほうがより魅力的に表示される可能性もあります。
 - **BackgroundSource**: 背景アクリルまたはアプリ内アクリルのどちらを使用するかを指定するフラグです。
 - **FallbackColor**: バッテリ低下モードでアクリルと置き換わる単色です。 背景アクリルでは、フォールバックの色は、アプリが作業中のデスクトップ ウィンドウにない場合、またはアプリが電話や Xbox 上で実行されている場合にもアクリルと置き換わります。


![淡色テーマのアクリルの見本](images/CustomAcrylic_Swatches_LightTheme.png)

![濃色テーマのアクリルの見本](images/CustomAcrylic_Swatches_DarkTheme.png)

アクリル ブラシを追加するには、濃色テーマ、淡色テーマ、ハイ コントラスト テーマの 3 つのリソースを定義します。 ハイ コントラストでは、濃色/淡色の AcrylicBrush と同じ x:Key で SolidColorBrush を使用することをお勧めします。

```xaml
<ResourceDictionary.ThemeDictionaries>
    <ResourceDictionary x:Key="Default">
        <AcrylicBrush x:Key="MyAcrylicBrush"
            BackgroundSource="HostBackdrop"
            TintColor="#FFFF0000"
            TintOpacity="0.8"
            FallbackColor="#FF7F0000"/>
    </ResourceDictionary>

    <ResourceDictionary x:Key="HighContrast">
        <SolidColorBrush x:Key="MyAcrylicBrush"
            Color="{ThemeResource SystemColorWindowColor}"/>
    </ResourceDictionary>

    <ResourceDictionary x:Key="Light">
        <AcrylicBrush x:Key="MyAcrylicBrush"
            BackgroundSource="HostBackdrop"
            TintColor="#FFFF0000"
            TintOpacity="0.8"
            FallbackColor="#FFFF7F7F"/>
    </ResourceDictionary>
</ResourceDictionary.ThemeDictionaries>
```

次のサンプルは、コードで AcrylicBrush を宣言する方法を示しています。 アプリが複数の OS ターゲットをサポートする場合は、この API がユーザーのコンピューターで利用できることを確認してください。

```csharp
if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
{
    Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
    myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
    myBrush.TintColor = Color.FromArgb(255, 202, 24, 37);
    myBrush.FallbackColor = Color.FromArgb(255, 202, 24, 37);
    myBrush.TintOpacity = 0.6;

    grid.Fill = myBrush;
}
else
{
    SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

    grid.Fill = myBrush;
}
```

## <a name="extending-acrylic-into-your-title-bar"></a>アクリルをタイトル バーに拡張する

アプリのウィンドウ内でシームレスで滑らかな表示を実現するには、アクリルをアプリのタイトル バー領域に配置することをお勧めします。 そのためには、次のコードを App.xaml.cs に追加します。

```csharp
CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
titleBar.ButtonBackgroundColor = Colors.Transparent;
titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
```

また、通常はタイトル バーに自動的に表示されるアプリのタイトルを、`CaptionTextBlockStyle` を使用した TextBlock で描画する必要もあります。

## <a name="dos-and-donts"></a>推奨と非推奨
* アクリルは、ナビゲーション ウィンドウなど、アプリのプライマリ サーフェス以外のサーフェスで背景素材として使用してください。
* シームレスなエクスペリエンスを実現するには、アプリの周囲とわずかにブレンドするようにして、アクリルをアプリの 1 つ以上の端にまで拡張してください。
* アプリ内アクリルと背景アクリルは、継ぎ目部分での視覚的なテンションを回避するために、隣接するようには配置しないでください。
* 複数のアクリル ウィンドウを、同じ濃淡や不透明度で隣接するように配置しないでください。このようにすると、望ましくない継ぎ目が表示されます。
* アクリル サーフェスの上には、アクセント カラーのテキストを配置しないでください。

## <a name="how-we-designed-acrylic"></a>アクリルをどのように設計したか

アクリルの主要なコンポーネントを微調整して、ユニークな外観とプロパティを作成しました。 設計の開始時には透明度、ぼかし、ノイズを使い、平坦なサーフェスに視覚的な奥行きとディメンションを追加しました。 除外ブレンド モード レイヤーを追加して、アクリルの背景に配置される UI のコントラストと見やすさを確保しました。 最後に、ユーザーの個性を反映できるように、色の濃淡を追加しました。 次のレイヤーを組み合わせることで、新しくて使いやすい素材が生みだされます。

![アクリルのレシピ](images/AcrylicRecipe_Diagram.png)
<br/>アクリルのレシピ: 背景、ぼかし、除外ブレンド、色/濃淡のオーバーレイ、ノイズ

<!--
<div class="microsoft-internal-note">
When designing your app, please utilize these [design resources](http://uni/DesignDepot.FrontEnd/#/Search?t=Resources%7CNeon%7CToolkit&f=Acrylic%20Material) to show acrylic in comps. The linked templates are the most accurate way to represent acrylic material in Photoshop and Illustrator. The ordering, as noted in the recipe diagram above, should start from the top: <br/>
 - Noise asset (tiled) at 4% opacity <br/>
 - Base color/tint/alpha layer <br/>
 - Exclusion blend (white @ 10% opacity) <br/>
 - Gaussian blur (30px radius) <br/>
</div>
-->


## <a name="related-articles"></a>関連記事
[**表示**](reveal.md)
