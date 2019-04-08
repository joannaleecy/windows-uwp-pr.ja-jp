---
description: 半透明テクスチャを作成するブラシの種類。
title: アクリル素材
template: detail.hbs
ms.date: 08/09/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: yulikl
design-contact: rybick
dev-contact: jevansa
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 0600e66c672a28683befdb7b0090f5455a28c948
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57624197"
---
# <a name="acrylic-material"></a>アクリル素材

![ヒーロー イメージ](images/header-acrylic.svg)

アクリルは一種の[ブラシ](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush)半透明テクスチャを作成します。 アクリルをアプリ サーフェスに適用すると、奥行きを加えたり、視覚的な階層を確立したりすることができます。  <!-- By allowing user-selected wallpaper or colors to shine through, acrylic keeps users in touch with the OS personalization they've chosen. -->

> **重要な API**:[AcrylicBrush クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush)、[プロパティをバック グラウンド](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control.Background)

:::row:::
    :::column:::
        Acrylic in light theme
        ![Acrylic in light theme](images/Acrylic_LightTheme_Base.png)
    :::column-end:::
    :::column:::
        Acrylic in dark theme
        ![Acrylic in dark theme](images/Acrylic_DarkTheme_Base.png)
    :::column-end:::
:::row-end:::

## <a name="acrylic-and-the-fluent-design-system"></a>アクリルと Fluent Design System

 Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。 アクリルは、アプリに物理的なテクスチャ (マテリアル) と深度を追加する Fluent Design System コンポーネントです。 詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。

 ## <a name="video-summary"></a>ビデオの概要

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev002/player]

## <a name="examples"></a>例

:::row:::
    :::column span:::
        ![Some image](images/XAML-controls-gallery-app-icon.png)
    :::column-end:::
    :::column span="2":::
        **XAML Controls Gallery**<br>
        If you have the XAML Controls Gallery app installed, click <a href="xamlcontrolsgallery:/item/Acrylic">here</a> to open the app and see acrylic in action.

        <a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a><br>
        <a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a>
    :::column-end:::
:::row-end:::

## <a name="acrylic-blend-types"></a>アクリル ブレンドの種類
アクリルの最も注目すべき特徴は、その透明度です。 アクリル ブレンドの種類は 2 つあり、素材を通して何が表示されるかを変更することができます。
 - **背景アクリル**では、デスクトップの壁紙と現在アクティブになっているアプリの背後にある他のウィンドウが表示されます。これにより、アプリケーション ウィンドウの間に奥行きが出て、ユーザーが個人的に優先する画面を明示しておくことができます。
 - **アプリ内アクリル**では、アプリ フレーム内に奥行きの感覚がもたらされ、フォーカスと階層の両方が提供されます。

 ![背景アクリル](images/BackgroundAcrylic_DarkTheme.png)

 ![アプリ内アクリル](images/AppAcrylic_DarkTheme.png)

 レイヤーの複数のアクリル サーフェスで注意が必要です: バック グラウンド アクリルの複数のレイヤーが注意をそらす光学フィルターを作成できます。

## <a name="when-to-use-acrylic"></a>アクリルを使用する状況

* 重複するコンテンツがスクロールまたは操作したときに画面上など、UI をサポートするためには、アプリ内のアクリルを使用します。
* コンテキスト メニュー、フライアウト、光 dimsissable UI などの一時的な UI 要素の背景のアクリルを使用します。<br />一時的なシナリオでアクリルを使用すると、一時的な UI をトリガーするコンテンツで視覚的な関係を維持できます。

ナビゲーション画面をアプリ内のアクリルを使用している場合は、アプリでフローを向上させるためにアクリル ペインの下にコンテンツを拡張することを検討します。 NavigationView を使用してはこの処理を自動実行します。 ただし、ストライピング効果の作成を回避するため、アクリル - エッジでの複数の部分を配置しないでくださいこのことができます、2 つのぼかしサーフェスの間で不要な継ぎ目を作成します。 アクリルは、設計を visual 調和を実現するツールですが、適切に使用されることが余計。

アプリにアクリルを組み込むことが最善の方法を次の使用パターンを検討してください。

### <a name="horizontal-navigation-or-commanding"></a>水平方向のナビゲーション ウィンドウまたはコマンド実行

NavigationView を利用できるように、アプリは、アクリルを追加する場合は、比較的半透明のアクリルを使用して、60% 濃淡の不透明度をお勧めします。
 - ウィンドウが他のアプリ コンテンツ上でオーバーレイとして開くときは、[60% のアプリ内アクリル](#acrylic-theme-resources)にする必要があります

![アプリで水平方向のコマンドを使用してマップ アプリ](images/Maps_In_App_Acrylic_1.png)

さらに、上部にある、コンテンツの拡張またはアクリル、下のスクロールを持つは、アプリ、さらに魅力的なシームレスなエクスペリエンスです。

### <a name="vertical-panes"></a>垂直方向のウィンドウ

垂直方向のウィンドウまたはヘルプ、アプリのコンテンツのセクションで、サーフェスでは、不透明な背景を使用して、アクリルではなくをお勧めします。 NavigationView の内などの場合は、垂直方向のウィンドウ コンテンツの上に開くには、 **Compact**または**最小限**モードをお勧め、ユーザーがあるこのウィンドウを開いているときに、ページのコンテキストを維持するためにアプリ内のアクリルを使用します。

### <a name="transient-surfaces"></a>一時的なサーフェイス

アプリのメニュー フライアウト、非モーダル ポップアップでは、ペイン の light 無視またはバック グラウンドのアクリルを使用することをお勧めします。

![情報のポップアップを使用してメール アプリのパターン](images/Mail_TransientContextMenu.png)

コントロールの多くは、既定でアクリルを使用します。 [MenuFlyouts](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/menus)、 [AutoSuggestBox](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/auto-suggest-box)、 [ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox) light dimiss ポップアップのようなコントロールはすべて一時的なアクリル場合に、使用に呼び出されます。

> [!Note]
> GPU の負荷がデバイスの電力消費量を増やすことができますし、バッテリの寿命を短縮するにはアクリル サーフェスをレンダリングします。 Acrylic 効果は、選択した場合デバイスがバッテリー セーバー モードに入るし、ユーザーには、すべてのアプリのアクリル効果が無効にすることができます自動的に無効にします。

## <a name="usability-and-adaptability"></a>使いやすさと適応性
アクリルの外観は、さまざまなデバイスやコンテキストに合うように自動的に対応します。

ハイ コントラスト モードでは、ユーザーが選んだ見慣れた背景色が、アクリルの代わりに引き続き表示されます。 さらに、バック グラウンド アクリルとアプリ内のアクリルの両方は、純色として表示されます。
 - ユーザーが設定での透過性をオフにする場合 > 個人用設定 > 色
 - バッテリー セーバー モードがアクティブにするタイミング
 - アプリがローエンド ハードウェアで実行されている場合

さらに、バック グラウンド アクリルのみは置換の透明度とテクスチャを純色。
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
        <td> <b>推奨される使用法:</b>これらは、さまざまな使用法で問題なく動作する汎用のアクリル リソースです。 アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセルよりも小さい場合は、<a href="../accessibility/accessible-text-requirements.md">コントラスト比の要件を満たすように</a>、80% のアクリル リソースをテキストの背景に配置してください。 </td>
    </tr>
    <tr>
        <td> SystemControlAcrylicWindowMediumHighBrush、SystemControlAcrylicElementMediumHighBrush <br/> SystemControlBaseHighAcrylicWindowMediumHighBrush、SystemControlBaseHighAcrylicElementMediumHighBrush </td>
        <td align="center"> 70% </td>
        <td> ChromeMedium <br/><br/> BaseHigh </td>
    </tr>
    <tr>
        <td> <b>推奨される使用法:</b>アプリでは、18 px 以上のテキスト サイズを AltMedium 色のセカンダリ テキストを使用している場合は、これら複数の半透明 70% のテキストの背後にあるアクリル リソースを配置できます。 これらのリソースは、アプリの最上部にある水平方向のナビゲーション領域やコマンド実行領域で使用することをお勧めします。  </td>
    </tr>
    <tr>
        <td> SystemControlChromeHighAcrylicWindowMediumBrush、SystemControlChromeHighAcrylicElementMediumBrush <br/> SystemControlChromeMediumAcrylicWindowMediumBrush、SystemControlChromeMediumAcrylicElementMediumBrush <br/> SystemControlChromeMediumLowAcrylicWindowMediumBrush、SystemControlChromeMediumLowAcrylicElementMediumBrush <br/> SystemControlBaseHighAcrylicWindowMediumBrush、SystemControlBaseHighAcrylicElementMediumBrush <br/> SystemControlBaseMediumLowAcrylicWindowMediumBrush、SystemControlBaseMediumLowAcrylicElementMediumBrush <br/> SystemControlAltMediumLowAcrylicWindowMediumBrush、SystemControlAltMediumLowAcrylicElementMediumBrush  </td>
        <td align="center"> 60% </td>
        <td> ChromeHigh <br/><br/> ChromeMedium <br/><br/> ChromeMediumLow <br/><br/> BaseHigh <br/><br/> BaseLow <br/><br/> AltMediumLow </td>
    </tr>
    <tr>
        <td> <b>推奨される使用法:</b>AltHigh 色の主要なテキストのみアクリルの上に配置するときに、アプリは、これらの 60% リソースを利用できます。 アプリの<a href="../controls-and-patterns/navigationview.md">垂直方向のナビゲーション ウィンドウ</a> (ハンバーガー メニュー) を描画するときは、60% のアクリルを使用することをお勧めします。 </td>
    </tr>
</table>

中間色のアクリルに加え、ユーザーが指定したアクセント カラーを使用してアクリルに濃淡を付けるリソースも追加しました。 色が付いたアクリルは慎重に使用してください。 提供されている dark1 と dark2 のバリアントを使用する場合、濃色テーマのテキストの色と調和するように、白または明るい色のテキストをこれらのリソース上に配置してください。
<table>
    <tr>
        <th align="center">リソース キー</th>
        <th align="center">濃淡の不透明度</th>
        <th align="center"><a href="color.md">代替の濃淡の色</a> </th>
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
 - **TintOpacity**: 濃淡レイヤーの不透明度です。 お勧め 80% の不透明度を出発点として他の translucencies で魅力的なさまざまな色に見える場合があります。
 - **TintLuminosityOpacity**: がバック グラウンドからアクリル画面によって許可される彩度の量を制御します。
 - **BackgroundSource**: 背景アクリルまたはアプリ内アクリルのどちらを使用するかを指定するフラグです。
 - **FallbackColor**: 純色をバッテリー セーバーのアクリルを置換します。 背景アクリルでは、フォールバックの色は、アプリが作業中のデスクトップ ウィンドウにない場合、またはアプリが電話や Xbox 上で実行されている場合にもアクリルと置き換わります。

![淡色テーマのアクリルの見本](images/CustomAcrylic_Swatches_LightTheme.png)

![濃色テーマのアクリルの見本](images/CustomAcrylic_Swatches_DarkTheme.png)

![濃淡の不透明度と比較して光度 opactity](images/LuminosityVersusTint.png)

アクリル ブラシを追加するには、濃色テーマ、淡色テーマ、ハイ コントラスト テーマの 3 つのリソースを定義します。 ハイ コントラストでは、濃色/淡色の AcrylicBrush と同じ x:Key で SolidColorBrush を使用することをお勧めします。

> [!Note] 
> TintLuminosityOpacity 値を指定しない場合、システムは TintColor と TintOpacity に基づき、その値を自動的に調整します。

```xaml
<ResourceDictionary.ThemeDictionaries>
    <ResourceDictionary x:Key="Default">
        <AcrylicBrush x:Key="MyAcrylicBrush"
            BackgroundSource="HostBackdrop"
            TintColor="#FFFF0000"
            TintOpacity="0.8"
            TintLuminosityOpacity="0.5"
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
            TintLuminosityOpacity="0.5"
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
* アプリの大きな背景サーフェイス デスクトップ arylic を入れないでください - 一時的なサーフェイスの主に使用されているアクリルのメンタル モデルが破損します。
* アプリ内アクリルと背景アクリルは、継ぎ目部分での視覚的なテンションを回避するために、隣接するようには配置しないでください。
* 複数のアクリル ウィンドウを、同じ濃淡や不透明度で隣接するように配置しないでください。このようにすると、望ましくない継ぎ目が表示されます。
* アクリル サーフェスの上には、アクセント カラーのテキストを配置しないでください。

## <a name="how-we-designed-acrylic"></a>アクリルをどのように設計したか

アクリルの主要なコンポーネントを微調整して、ユニークな外観とプロパティを作成しました。 透明度、ぼかしフラット サーフェスをビジュアルの深さとディメンションを追加するノイズと始めました。 除外ブレンド モード レイヤーを追加して、アクリルの背景に配置される UI のコントラストと見やすさを確保しました。 最後に、ユーザーの個性を反映できるように、色の濃淡を追加しました。 次のレイヤーを組み合わせることで、新しくて使いやすい素材が生みだされます。

![Acrylic レシピ](images/AcrylicRecipe_Diagram.jpg)
<br/>アクリルのレシピ: 背景、ぼかし、除外ブレンド、色/濃淡のオーバーレイ、ノイズ


## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

[**強調表示を表示します。**](reveal.md)
