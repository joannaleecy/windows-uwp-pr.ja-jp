---
author: mijacobs
description: 半透明のテクスチャを作成するブラシの種類。
title: アクリル素材
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
ms.localizationpriority: medium
ms.openlocfilehash: 8589a450b53a5ea028f8af2cee2aef7dc0816b52
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2894101"
---
# <a name="acrylic-material"></a>アクリル素材

![ヒーロー イメージ](images/header-acrylic.svg)

Acrylic は、[ブラシ](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush)半透明テクスチャを作成するはします。 アクリルをアプリ サーフェスに適用すると、奥行きを加えたり、視覚的な階層を確立したりすることができます。  <!-- By allowing user-selected wallpaper or colors to shine through, acrylic keeps users in touch with the OS personalization they've chosen. -->

> **重要な API**: [AcrylicBrush クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush)、[Background プロパティ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control.Background)

:::row:::
    :::column:::
        簡易テーマ acrylic ![Acrylic 簡易テーマ](images/Acrylic_LightTheme_Base.png)
    :::column-end:::
    :::column:::
        ダーク テーマの acrylic![ダーク テーマの Acrylic](images/Acrylic_DarkTheme_Base.png)
    :::column-end:::
:::row-end:::

## <a name="acrylic-and-the-fluent-design-system"></a>アクリルと Fluent Design System

 Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。 アクリルは、アプリに物理的なテクスチャ (マテリアル) と深度を追加する Fluent Design System コンポーネントです。 詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。

 ## <a name="video-summary"></a>ビデオの概要

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev002/player]

## <a name="examples"></a>例

:::row:::
    ::: 列:::![一部の画像](images/XAML-controls-gallery-app-icon.png)
    :::column-end:::
    ::: 列 =「2」::: **XAML コントロール] ギャラリー**<br>
        をクリックして、XAML コントロール ギャラリー アプリがインストールされている場合は、<a href="xamlcontrolsgallery:/item/Acrylic">次のとおり</a>にアプリを開き、acrylic の使用例を参照してください。

        <a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a><br>
        <a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">Get the source code (GitHub)</a>
    :::column-end:::
:::row-end:::

## <a name="when-to-use-acrylic"></a>アクリルを使用する状況

アプリ内ナビゲーションの要素やコマンド実行要素などのサポート UI は、アクリル サーフェス上に配置することをお勧めします。 アクリル素材は、ダイアログやポップアップなどの一時的な UI の要素を使用する場合にも役立ちます。これは、この素材によって、一時的な UI をトリガーしたコンテンツとの視覚的な関係を維持することができるためです。 アクリルは、背景素材として使用し、視覚的に分離されたウィンドウ内に表示するように設計されています。そのため、アクリルは詳細な前景要素には適用しないでください。

アプリの主要なコンテンツの背後にあるサーフェスでは、単色で不透明な背景を使用してください。

滑らかな表示を実現するには、アクリルを、アプリの 1 つまたは複数の端にまで (ウィンドウのタイトル バーも含む) 拡張することを検討してください。 ブレンドの種類が異なる複数のアクリルを相互に隣接するように重ねて、ストライプ効果を作成することは回避してください。 アクリルは、デザインで視覚的な調和をとるためのツールですが、正しく使用しないと、視覚的なノイズになる場合があります。

次の使用パターンを検討して、アクリルをアプリに組み込むに最適な方法を決定してください。

### <a name="vertical-acrylic-pane"></a>垂直方向のアクリル ウィンドウ

垂直方向のナビゲーションを行うアプリでは、アクリルを、ナビゲーション要素を含んでいるセカンダリ ウィンドウに適用することをお勧めします。

![1 つの垂直方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_vertical.png)

[NavigationView](../controls-and-patterns/navigationview.md) は、ナビゲーションをアプリに追加し、そのビジュアル デザインにアクリルを取り込むための新しいコモン コントロール です。 NavigationView のウィンドウでは、ウィンドウが主要なコンテンツと並んで開かれるとき、背景アクリルが表示されます。また、ウィンドウがオーバーレイとして開くと、自動的にアプリ内アクリルに切り替わります。

NavigationView を利用できるようには、アプリで、[自分で acrylic を追加する場合は、比較的半透明 acrylic を使って 60% の濃淡の透明度をお勧めします。
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
> デバイスの電力消費を増やすとバッテリを短くする GPU 型は、acrylic 内に表示します。 Acrylic 効果は、選択した場合デバイス バッテリ セーバー モードに入るし、ユーザーには、すべてのアプリの acrylic 効果が無効にすることができます自動的に無効にします。


## <a name="acrylic-blend-types"></a>アクリル ブレンドの種類
Acrylic の最も大きな特徴は、その透明度を設定します。 アクリル ブレンドの種類は 2 つあり、素材を通して何が表示されるかを変更することができます。
 - **背景アクリル**では、デスクトップの壁紙と現在アクティブになっているアプリの背後にある他のウィンドウが表示されます。これにより、アプリケーション ウィンドウの間に奥行きが出て、ユーザーが個人的に優先する画面を明示しておくことができます。
 - **アプリ内アクリル**では、アプリ フレーム内に奥行きの感覚がもたらされ、フォーカスと階層の両方が提供されます。

 ![背景アクリル](images/BackgroundAcrylic_DarkTheme.png)

 ![アプリ内アクリル](images/AppAcrylic_DarkTheme.png)

 複数のアクリル サーフェスを重ねる場合には注意が必要です。 背景アクリルは、その名前が示すように、Z オーダーではユーザーの最も近くには表示しないでください。 背景アクリルの複数のレイヤーは、予期しない目の錯覚を引き起こす傾向があるので、使用しないでください。 アクリルを重ねる場合は、アプリ内アクリルを重ねてください。また、アクリルの濃淡が薄くなるように値を設定して、アクリルのレイヤーが視覚的に閲覧者の近くに表示されるようにすることを検討してください。


## <a name="usability-and-adaptability"></a>使いやすさと適応性
アクリルの外観は、さまざまなデバイスやコンテキストに合うように自動的に対応します。

ハイ コントラスト モードでは、ユーザーが選んだ見慣れた背景色が、アクリルの代わりに引き続き表示されます。 さらに、背景 acrylic と acrylic のアプリでは、純色として表示されます。
 - ユーザーが透明度設定をオフにすると > [個人用設定 > 色
 - バッテリ セーバー モードが有効な場合
 - アプリがローエンド ハードウェアで実行されている場合

さらに、バック グラウンド acrylic のみが、透明度およびテクスチャを置き換えます単色を。
 - アプリ ウィンドウがデスクトップで非アクティブ化されている場合
 - UWP アプリが、電話、Xbox、HoloLens、またはタブレット モードで実行されている場合

### <a name="legibility-considerations"></a>見やすくするための考慮事項
アプリがユーザーに表示するすべてのテキストでは、[コントラスト比を適切な値にする](../accessibility/accessible-text-requirements.md)ことが重要です。 ハイカラーの黒や白のテキスト、またはミディアムカラーの灰色のテキストがアクリル上で適切なコントラスト比になるように、アクリルのレシピは最適化されています。 プラットフォームによって提供されるテーマ リソースは、既定で、濃淡の色のコントラストが 80% の不透明度に設定されます。 ハイカラーの本文テキストをアクリル上に配置する場合、濃淡の不透明度を下げて、見やすさを維持することができます。 ダーク モードでは濃淡の不透明度を 70% にすることができ、ライト モードのアクリルではコントラスト比を 50% の不透明度に合わせることができます。

アクリル サーフェスの上にアクセント カラーのテキストを配置することはお勧めしません。これは、これらの組み合わせが、15 ピクセルのフォント サイズでのコントラスト比の最小要件を満たさない可能性があるためです。 [ハイパーリンク](../controls-and-patterns/hyperlinks.md)はアクリル要素上には配置しないようにしてください。 また、アクリルの濃淡の色や透明度のレベルを、テーマ リソースによって提供されるプラットフォームの既定値以外にカスタマイズする場合は、見やすさへの影響を考慮してください。

## <a name="acrylic-theme-resources"></a>アクリルのテーマ リソース
新しい XAML AcrylicBrush テーマ リソースや定義済みの AcrylicBrush テーマ リソースを使用して、アクリルをアプリのサーフェスに簡単に適用できます。 まず、アプリ内アクリルまたは背景アクリルのどちらを使用するかを決める必要があります。 この記事で推奨事項として既に説明した一般的なアプリのパターンを確認してください。

背景アクリルやアプリ内アクリルの両方を対象としたブラシのテーマ リソースのコレクションが作成されています。これらのリソースでは、アプリのテーマが重視され、必要に応じて、単色にフォール バックします。 *AcrylicWindow* という名前のリソースは背景アクリルを表し、*AcrylicElement* はアプリ内アクリルを表します。

<table>
    <tr>
        <th align="center">リソース キー</th>
        <th align="center">濃淡の不透明度</th>
        <th align="center"><a href="color.md">フォールバックの色</a> </th>
    </tr>
    <tr>
        <td> SystemControlAcrylicWindowBrush、SystemControlAcrylicElementBrush <br/> SystemControlChromeLowAcrylicWindowBrush、SystemControlChromeLowAcrylicElementBrush <br/> SystemControlBaseHighAcrylicWindowBrush、SystemControlBaseHighAcrylicElementBrush <br/> SystemControlBaseLowAcrylicWindowBrush、SystemControlBaseLowAcrylicElementBrush <br/> SystemControlAltHighAcrylicWindowBrush、SystemControlAltHighAcrylicElementBrush <br/> SystemControlAltLowAcrylicWindowBrush、SystemControlAltLowAcrylicElementBrush </td>
        <td align="center"> 80% </td>
        <td> ChromeMedium <br/> ChromeLow <br/><br/> BaseHigh <br/><br/> BaseLow <br/><br/> AltHigh <br/><br/> AltLow </td>
    </tr>
    </tr>
        <td> <b>推奨する使用方法:</b> これらは、汎用的なアクリルのリソースであり、さまざまな使用方法で適切に機能します。 アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセルよりも小さい場合は、<a href="../accessibility/accessible-text-requirements.md">コントラスト比の要件を満たすように</a>、80% のアクリル リソースをテキストの背景に配置してください。 </td>
    </tr>
    <tr>
        <td> SystemControlAcrylicWindowMediumHighBrush、SystemControlAcrylicElementMediumHighBrush <br/> SystemControlBaseHighAcrylicWindowMediumHighBrush、SystemControlBaseHighAcrylicElementMediumHighBrush </td>
        <td align="center"> 70% </td>
        <td> ChromeMedium <br/><br/> BaseHigh </td>
    </tr>
    <tr>
        <td> <b>使用をお勧めします</b>。アプリでは、18px 以上のテキスト サイズと AltMedium 色の第 2 のテキストを使用している場合は、テキストの背後にあるその他の半透明 70 %acrylic リソースを配置できます。 これらのリソースは、アプリの最上部にある水平方向のナビゲーション領域やコマンド実行領域で使用することをお勧めします。  </td>
    </tr>
    <tr>
        <td> SystemControlChromeHighAcrylicWindowMediumBrush、SystemControlChromeHighAcrylicElementMediumBrush <br/> SystemControlChromeMediumAcrylicWindowMediumBrush、SystemControlChromeMediumAcrylicElementMediumBrush <br/> SystemControlChromeMediumLowAcrylicWindowMediumBrush、SystemControlChromeMediumLowAcrylicElementMediumBrush <br/> SystemControlBaseHighAcrylicWindowMediumBrush、SystemControlBaseHighAcrylicElementMediumBrush <br/> SystemControlBaseMediumLowAcrylicWindowMediumBrush、SystemControlBaseMediumLowAcrylicElementMediumBrush <br/> SystemControlAltMediumLowAcrylicWindowMediumBrush、SystemControlAltMediumLowAcrylicElementMediumBrush  </td>
        <td align="center"> 60% </td>
        <td> ChromeHigh <br/><br/> ChromeMedium <br/><br/> ChromeMediumLow <br/><br/> BaseHigh <br/><br/> BaseLow <br/><br/> AltMediumLow </td>
    </tr>
    <tr>
        <td> <b>推奨する使用方法:</b> プライマリ テキストの色が AltHigh で、このテキストのみをアクリルの上に配置する場合は、これらの 60% のリソースを利用できます。 アプリの<a href="../controls-and-patterns/navigationview.md">垂直方向のナビゲーション ウィンドウ</a> (ハンバーガー メニュー) を描画するときは、60% のアクリルを使用することをお勧めします。 </td>
    </tr>
</table>

中間色のアクリルに加え、ユーザーが指定したアクセント カラーを使用してアクリルに濃淡を付けるリソースも追加しました。 色が付いたアクリルは慎重に使用してください。 提供されている dark1 と dark2 のバリアントを使用する場合、濃色テーマのテキストの色と調和するように、白または明るい色のテキストをこれらのリソース上に配置してください。
<table>
    <tr>
        <th align="center">リソース キー</th>
        <th align="center">濃淡の不透明度</th>
        <th align="center"><a href="color.md">濃淡とフォールバックの色</a> </th>
    </tr>
    <tr>
        <td> SystemControlAccentAcrylicWindowAccentMediumHighBrush、SystemControlAccentAcrylicElementAccentMediumHighBrush  </td>
        <td align="center"> 70% </td>
        <td> SystemAccentColor </td>
    </tr>
    <tr>
        <td> SystemControlAccentDark1AcrylicWindowAccentDark1Brush、SystemControlAccentDark1AcrylicElementAccentDark1Brush  </td>
        <td align="center"> 80% </td>
        <td> SystemAccentColorDark1 </td>
    </tr>
    <tr>
        <td> SystemControlAccentDark2AcrylicWindowAccentDark2MediumHighBrush、SystemControlAccentDark2AcrylicElementAccentDark2MediumHighBrush  </td>
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
 - **TintOpacity**: 濃淡レイヤーの不透明度です。 さまざまな色が他の translucencies で説得力を確認することがありますが、開始点として 80% 不透明お勧めします。
 - **BackgroundSource**: 背景アクリルまたはアプリ内アクリルのどちらを使用するかを指定するフラグです。
 - **FallbackColor**: 単色バッテリ セーバー acrylic を置換します。 背景アクリルでは、フォールバックの色は、アプリが作業中のデスクトップ ウィンドウにない場合、またはアプリが電話や Xbox 上で実行されている場合にもアクリルと置き換わります。


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

## <a name="extend-acrylic-into-the-title-bar"></a>アクリルをタイトル バーに拡張する

アプリのウィンドウを滑らかな外観にするには、タイトル バー領域にアクリルを使います。 この例では、[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar) オブジェクトの [ButtonBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar.ButtonBackgroundColor) および [ButtonInactiveBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar.ButtonInactiveBackgroundColor) プロパティを [Colors.Transparent](https://docs.microsoft.com/uwp/api/Windows.UI.Colors.Transparent) に設定することで、アクリルをタイトル バーに拡張します。 

```csharp
/// Extend acrylic into the title bar. 
private void ExtendAcrylicIntoTitleBar()
{
    CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
    ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
    titleBar.ButtonBackgroundColor = Colors.Transparent;
    titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
}
```

このコードは、ここに示すようにアプリの [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) メソッド (_App.xaml.cs_) 内の [Window.Activate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.Activate) の呼び出しの後か、アプリの最初のページに配置できます。 


```csharp
// Call your extend acrylic code in the OnLaunched event, after 
// calling Window.Current.Activate.
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == null)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
    }

    if (e.PrelaunchActivated == false)
    {
        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(MainPage), e.Arguments);
        }
        // Ensure the current window is active
        Window.Current.Activate();

        // Extend acrylic
        ExtendAcrylicIntoTitleBar();
    }
}
```

また、通常はタイトル バーに自動的に表示されるアプリのタイトルを、`CaptionTextBlockStyle` を使用した TextBlock で描画する必要もあります。 詳しくは、「[タイトル バーのカスタマイズ](../shell/title-bar.md)」をご覧ください。

## <a name="dos-and-donts"></a>推奨と非推奨
* アクリルは、ナビゲーション ウィンドウなど、アプリのプライマリ サーフェス以外のサーフェスで背景素材として使用してください。
* シームレスなエクスペリエンスを実現するには、アプリの周囲とわずかにブレンドするようにして、アクリルをアプリの 1 つ以上の端にまで拡張してください。
* アプリ内アクリルと背景アクリルは、継ぎ目部分での視覚的なテンションを回避するために、隣接するようには配置しないでください。
* 複数のアクリル ウィンドウを、同じ濃淡や不透明度で隣接するように配置しないでください。このようにすると、望ましくない継ぎ目が表示されます。
* アクリル サーフェスの上には、アクセント カラーのテキストを配置しないでください。

## <a name="how-we-designed-acrylic"></a>アクリルをどのように設計したか

アクリルの主要なコンポーネントを微調整して、ユニークな外観とプロパティを作成しました。 透明度、ぼかしノイズ フラット内に視覚的な奥行きとディメンションを追加すると作業を開始します。 除外ブレンド モード レイヤーを追加して、アクリルの背景に配置される UI のコントラストと見やすさを確保しました。 最後に、ユーザーの個性を反映できるように、色の濃淡を追加しました。 次のレイヤーを組み合わせることで、新しくて使いやすい素材が生みだされます。

![アクリルのレシピ](images/AcrylicRecipe_Diagram.jpg)
<br/>アクリルのレシピ: 背景、ぼかし、除外ブレンド、色/濃淡のオーバーレイ、ノイズ


## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

[**表示ハイライト**](reveal.md)
