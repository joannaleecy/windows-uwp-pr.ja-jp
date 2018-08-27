---
author: mijacobs
description: 表示は発光効果の 1 つで、アプリの対話型要素に奥行きを与え、焦点を当てるために役立ちます。
title: 強調表示を表示します。
template: detail.hbs
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: conrwi
dev-contact: jevansa
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 67bd984f4216be9eded51b6175829828e9c332f1
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2867651"
---
# <a name="reveal-highlight"></a>強調表示を表示します。

![ヒーロー イメージ](images/header-reveal-highlight.svg)

強調表示は、それらの近くにポインターを置いたときに、コマンド バーなどの対話型の要素を強調表示する光の効果を表示します。 

> **重要な API**: [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)、[RevealBackgroundBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush)、[RevealBorderBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush)、[RevealBrushHelper クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper)、[VisualState クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)

## <a name="how-it-works"></a>動作の仕組み
対話型の要素を強調表示通話対応をして要素のコンテナー、ポインターがこの図に示すように、近くに表示されます。

![表示のビジュアル効果](images/Nav_Reveal_Animation.gif)

オブジェクトの周囲にある非表示の境界線を明示すると、表示の動作によって、ユーザーが操作する領域の認識が容易になり、実行できる操作もわかりやすくなります。 これは、リスト コントロールやボタンのグループ化では特に重要です。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Reveal">アプリを開き、表示効果の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="video-summary"></a>概要 (ビデオ)

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev013/player]

## <a name="how-to-use-it"></a>使用方法

表示効果は、一部のコントロールでは自動的に動作します。 この記事の[他のコントロール表示を有効にして](#enabling-reveal-on-other-controls)、[カスタム コントロールの表示を有効にする](#enabling-reveal-on-custom-controls)セクションで説明するよう他のコントロールには、コントロールに特別なスタイルを割り当てることによって表示を有効にできます。

## <a name="controls-that-automatically-use-reveal"></a>表示効果が自動的に使用されるコントロール

- [**ListView**](../controls-and-patterns/lists.md)
- [**GridView**](../controls-and-patterns/lists.md)
- [**TreeView**](../controls-and-patterns/tree-view.md)
- [**NavigationView**](../controls-and-patterns/navigationview.md)
- [**MediaTransportControl**](../controls-and-patterns/media-playback.md)
- [**CommandBar**](../controls-and-patterns/app-bars.md)

強調表示を表示するいくつかのさまざまなコントロールに次の図。

![表示効果の例](images/RevealExamples_Collage.png)


## <a name="enabling-reveal-on-other-controls"></a>他のコントロールで表示効果を有効にする

表示の適用が必要なシナリオの場合 (シナリオで使用されるコントロールはメイン コンテンツである場合、またはそれらのコントロールがリストやコレクションに対応するために使用される場合)、オプトインのリソース スタイルが用意されているので、これらのスタイルを使用することで、そのような状況で表示を有効にすることができます。

以下に示すコントロールは、既定では表示の機能を備えていません。これらのコントロールは小さなコントロールであり、通常は、アプリケーションの重要なコンテンツをサポートするヘルパー コントロールですが、アプリによってはその状況は異なります。これらのコントロールをアプリの多くの部分で使用する場合は、その表示をサポートするスタイルがいくつか用意されているのでご利用ください。

| コントロール名   | リソース名 |
|----------|:-------------:|
| Button |  ButtonRevealStyle |
| ToggleButton | ToggleButtonRevealStyle |
| RepeatButton | RepeatButtonRevealStyle |
| AppBarButton | AppBarButtonRevealStyle |
| AppBarToggleButton | AppBarToggleButtonRevealStyle |
| GridViewItem (表示効果がコンテンツより手前) | GridViewItemRevealBackgroundShowsAboveContentStyle |

これらのスタイルを適用するには、コントロールの [Style](/uwp/api/Windows.UI.Xaml.Style) プロパティを次のように設定します。

```xaml
<Button Content="Button Content" Style="{StaticResource ButtonRevealStyle}"/>
```

### <a name="reveal-in-themes"></a>テーマ内の表示効果

表示効果は、コントロール、アプリ、またはユーザー設定で指定されているテーマによって少し異なります。 黒テーマの表示効果では境界線とホバー ライトが白ですが、白テーマでは境界線が明るい灰色になります。

![黒テーマと白テーマでの表示効果](images/Dark_vs_LightReveal.png)

白テーマのときに白の境界線を有効にするには、コントロールに指定されたテーマを黒に設定します。

```xaml
<Grid RequestedTheme="Dark">
    <Button Content="Button" Click="Button_Click" Style="{ThemeResource ButtonRevealStyle}"/>
</Grid>
```

または、RevealBorderBrush の TargetTheme を黒に変更します。 注意:  TargetTheme が黒に設定されている場合、表示効果は白になりますが、TargetTheme が白に設定されている場合、表示効果の境界線は灰色になります。

```xaml
 <RevealBorderBrush x:Key="MyLightBorderBrush" TargetTheme="Dark" Color="{ThemeResource SystemAccentColor}" FallbackColor="{ThemeResource SystemAccentColor}" />
```

## <a name="enabling-reveal-on-custom-controls"></a>カスタム コントロールで表示効果を有効にする

表示効果は、カスタム コントロールにも追加できます。 その前に、表示効果の動作についてもう少し詳しく知っておくと便利です。 表示効果は、2 つの独立した効果 (**表示効果の境界線**と**表示効果のホバー**) で構成されています。

- **表示効果の境界線**では、ポインターが近付くと、対話型要素の境界線が表示されます。 この効果では、現在フォーカスが置かれているオブジェクトと類似したアクションを、近くにある他のオブジェクトでも実行できることが示されます。
- **表示効果のホバー**では、ホバーされた (フォーカスが置かれた) 項目の周囲に淡く発光する図形が描画され、クリック時には押下操作のアニメーションが再生されます。 

![表示効果のレイヤー](images/RevealLayers.png)

<!-- The Reveal recipe breakdown is:

- Border reveal will be on top of all content but on the designated edges
- Text and content will be displayed directly under Border Reveal
- Hover reveal will be beneath content and text
- The backplate (that turns on and enables Hover Reveal)
- The background (background of control) -->


これらの効果は、次の 2 つのブラシによって定義されます。 
* **RevealBorderBrush**で定義枠線の表示
* Hover の表示が**RevealBackgroundBrush**で定義されています。

```xaml
<RevealBorderBrush x:Key="MyRevealBorderBrush" TargetTheme="Light" Color="{ThemeResource SystemAccentColor}" FallbackColor="{ThemeResource SystemAccentColor}"/>
<RevealBackgroundBrush x:Key="MyRevealBackgroundBrush" TargetTheme="Light" Color="{StaticResource SystemAccentColor}" FallbackColor="{StaticResource SystemAccentColor}" />
```
ほとんどの場合、特定のコントロールについては、表示効果が自動的に有効になってこれらの使用が処理されます。 その他のコントロールでは、スタイルを適用するかテンプレートを直接変更することで、有効にする必要があります。

### <a name="when-to-add-reveal"></a>表示効果の用途
カスタム コントロールにも表示効果を追加できますが、その前に、コントロールの種類と動作を考慮してください。 
* カスタム コントロールが単独の対話型要素であり、メニュー内のメニュー項目のように、類似する複数のコントロールが同じ場所にない場合は、そのカスタム コントロールには表示効果が不要である可能性があります。  
* 関連する対話型コンテンツまたは要素のグループがある場合は、アプリのその領域に表示効果が必要である可能性があります。これは一般的に、[コマンド実行](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/collection-commanding)サーフェスと呼ばれます。

たとえば、単独のボタンに表示効果は適していませんが、コマンド バー上の一連のボタンには表示効果が適しています。

<!-- For example, NavigationView's items are related to page navigation. CommandBar's buttons relate to menu actions or page feature actions. MediaTransportControl's buttons beneath all relate to the media being played. -->

### <a name="using-the-control-template-to-add-reveal"></a>コントロール テンプレートを使用して表示効果を追加する 
カスタム コントロールまたは再テンプレート化されたコントロールで表示効果を有効にするには、コントロールのコントロール テンプレートを変更します。 ほとんどのコントロール テンプレートでは、ルートにグリッドがあります。そのルート グリッドで表示効果を使用できるように [VisualState](/uwp/api/windows.ui.xaml.visualstate) を更新します。

```xaml
<VisualState x:Name="PointerOver">
    <VisualState.Setters>
        <Setter Target="RootGrid.(RevealBrush.State)" Value="PointerOver" />
        <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPointerOver}" />
        <Setter Target="ContentPresenter.BorderBrush" Value="Transparent"/>
        <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPointerOver}" />
    </VisualState.Setters>
</VisualState>
```

表示効果が正しく機能するためには、VisualState 内にブラシと setter の両方が必要である点に注意してください。 コントロールのブラシをいずれかの表示ブラシ リソースに設定するだけでは、そのコントロールに対して表示効果は有効になりません。 逆に、ターゲットまたは設定があっても表示ブラシを指定する値がなければ、表示効果は有効になりません。

コントロール テンプレートの変更について詳しくは、[XAML コントロール テンプレート](../controls-and-patterns/control-templates.md)に関する記事をご覧ください。

テンプレートのカスタマイズに使うことができる一連のシステム表示ブラシが作成されました。 たとえば、**ButtonRevealBackground** ブラシを使ってカスタム ボタンの背景を作成したり、カスタム一覧に **ListViewItemRevealBackground** ブラシを使ったりすることができます  (XAML でのリソースのしくみについて詳しくは、[Xaml リソース ディクショナリに関する記事](../controls-and-patterns/resourcedictionary-and-xaml-resource-references.md)をご覧ください)。

### <a name="full-template-example"></a>テンプレート全体の例

表示ボタンの外観を示すテンプレート全体を次に示します。

```xaml
<Style TargetType="Button" x:Key="ButtonStyle1">
    <Setter Property="Background" Value="{ThemeResource ButtonRevealBackground}" />
    <Setter Property="Foreground" Value="{ThemeResource ButtonForeground}" />
    <Setter Property="BorderBrush" Value="{ThemeResource ButtonRevealBorderBrush}" />
    <Setter Property="BorderThickness" Value="2" />
    <Setter Property="Padding" Value="8,4,8,4" />
    <Setter Property="HorizontalAlignment" Value="Left" />
    <Setter Property="VerticalAlignment" Value="Center" />
    <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}" />
    <Setter Property="FontWeight" Value="Normal" />
    <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}" />
    <Setter Property="UseSystemFocusVisuals" Value="True" />
    <Setter Property="FocusVisualMargin" Value="-3" />
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="Button">
                <Grid x:Name="RootGrid" Background="{TemplateBinding Background}">

                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal">

                                <Storyboard>
                                    <PointerUpThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="PointerOver">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.(RevealBrush.State)" Value="PointerOver" />
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPointerOver}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="Transparent"/>
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPointerOver}" />
                                </VisualState.Setters>

                                <Storyboard>
                                    <PointerUpThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="Pressed">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.(RevealBrush.State)" Value="Pressed" />
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPressed}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBackgroundPressed}" />
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPressed}" />
                                </VisualState.Setters>

                                <Storyboard>
                                    <PointerDownThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="Disabled">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundDisabled}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBorderBrushDisabled}" />
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundDisabled}" />
                                </VisualState.Setters>
                            </VisualState>
                        </VisualStateGroup>

              </VisualStateManager.VisualStateGroups>
                    <ContentPresenter x:Name="ContentPresenter"
                    BorderBrush="{TemplateBinding BorderBrush}"
                    BorderThickness="{TemplateBinding BorderThickness}"
                    Content="{TemplateBinding Content}"
                    ContentTransitions="{TemplateBinding ContentTransitions}"
                    ContentTemplate="{TemplateBinding ContentTemplate}"
                    Padding="{TemplateBinding Padding}"
                    HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}"
                    VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}"
                    AutomationProperties.AccessibilityView="Raw" />
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

### <a name="fine-tuning-the-reveal-effect-on-a-custom-control"></a>カスタム コントロールに対する表示効果を微調整する 

カスタムまたは再テンプレートのコントロールまたはユーザー設定のコマンド実行等高線グラフで表示を有効にすると以下のヒント、効果を最適化できます。
 
* 隣接する項目の高さまたは幅が一致しない場合 (特に、リスト内): 境界線のアプローチ動作を削除し、ホバー時のみ境界線を表示しておきます。
* 無効状態への移行と解除が頻繁に発生するコマンド実行項目の場合: 境界線アプローチのブラシを要素のバックプレートとバックプレートの境界線に配置して、状態を強調します。
* 隣接するコマンド実行要素の間隔が狭すぎて接触する場合: 2 つの要素間に 1 px の余白を追加します。 

## <a name="dos-and-donts"></a>推奨と非推奨
### <a name="do"></a>操作を行います。
- ユーザーが多数の操作を実行できる要素 (CommandBar、ナビゲーション メニュー) で表示効果を使う
- 既定で視覚的な区切りがない対話型要素のグループ (一覧、リボン) 内で表示効果を使う
- 対話型要素が密集している領域では表示を使う (コマンド実行シナリオ)
- 表示効果を適用する項目と項目の間に 1 px の余白を配置する

### <a name="dont"></a>非推奨
- 静的コンテンツ (背景、テキスト) では表示効果を使わない
- ポップアップやドロップダウンでは表示効果を使わない
- 1 回限りの個別の状況では表示効果を使わない
- 非常に多くの項目 (500 epx 超) では表示効果を使わない
- セキュリティ上の決定を行う場面では表示効果を使わない (ユーザーに提供する必要があるメッセージから注意がそれる可能性があるため)


## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。

## <a name="reveal-and-the-fluent-design-system"></a>表示効果と Fluent Design System

 Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。 表示は、アプリに発光効果を加える Fluent Design System コンポーネントです。 詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。

## <a name="related-articles"></a>関連記事

- [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)
- [アクリル](acrylic.md)
- [コンポジションの効果](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [UWP の Fluent Design](../fluent-design-system/index.md)
- [システムの科学: Fluent Design と奥行き](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [システムの科学: Fluent Design と明るさ](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
