---
author: mijacobs
description: "表示は照明効果の 1 つで、アプリの対話型要素に奥行きを与え、焦点を当てるために役立ちます。"
title: "表示ハイライト"
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
ms.localizationpriority: high
ms.openlocfilehash: 8ba0d9939d7ab1d9826ed2848e476499f09c628f
ms.sourcegitcommit: 4b522af988273946414a04fbbd1d7fde40f8ba5e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/08/2018
---
# <a name="reveal-highlight"></a>表示ハイライト

表示は照明効果の 1 つで、アプリの対話型要素に奥行きを与え、焦点を当てるために役立ちます。

> **重要な API**: [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)、[RevealBackgroundBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush)、[RevealBorderBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush)、[RevealBrushHelper クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper)、[VisualState class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)

表示動作は、ポインターが近くにある場合にクリック可能なコンテンツのコンテナーを表示することによりこれを行います。

![表示のビジュアル効果](images/Nav_Reveal_Animation.gif)

オブジェクトの周囲にある非表示の境界線を明示すると、表示の動作によって、ユーザーが操作する領域の認識が容易になり、実行できる操作もわかりやすくなります。 これは、リスト コントロールやボタンのグループ化では特に重要です。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Reveal">アプリを開き、表示の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="video-summary"></a>ビデオの概要

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev013/player]

## <a name="reveal-and-the-fluent-design-system"></a>表示と Fluent Design System

 Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。 表示は、アプリにライトを追加する Fluent Design System コンポーネントです。 詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。

## <a name="how-to-use-it"></a>用途

表示は、一部のコントロールでは自動的に動作します。 他のコントロールでは、コントロールに特別なスタイルを割り当てることにより表示を有効にできます。

## <a name="controls-that-automatically-use-reveal"></a>表示を自動的に使用するコントロール

- [**ListView**](../controls-and-patterns/lists.md)
- [**GridView**](../controls-and-patterns/lists.md)
- [**TreeView**](../controls-and-patterns/tree-view.md)
- [**NavigationView**](../controls-and-patterns/navigationview.md)
- [**AutosuggestBox**](../controls-and-patterns/auto-suggest-box.md)
- [**MediaTransportControl**](../controls-and-patterns/media-playback.md)
- [**CommandBar**](../controls-and-patterns/app-bars.md)
- [**ComboBox**](../controls-and-patterns/lists.md)

これらの図は、いくつかの異なるコントロールでの表示効果を示しています。

![表示の例](images/RevealExamples_Collage.png)

## <a name="enabling-reveal-on-other-common-controls"></a>他の一般的なコントロールで表示を有効にする

表示の適用が必要なシナリオの場合 (シナリオで使用されるコントロールはメイン コンテンツである場合、またはそれらのコントロールがリストやコレクションに対応するために使用される場合)、オプトインのリソース スタイルが用意されているので、これらのスタイルを使用することで、そのような状況で表示を有効にすることができます。

以下に示すコントロールは、既定では表示の機能を備えていません。これらのコントロールは小さなコントロールであり、通常は、アプリケーションの重要なコンテンツをサポートするヘルパー コントロールですが、アプリによってはその状況は異なります。これらのコントロールをアプリの多くの部分で使用する場合は、その表示をサポートするスタイルがいくつか用意されているのでご利用ください。

| コントロール名   | リソース名 |
|----------|:-------------:|
| Button |  ButtonRevealStyle |
| ToggleButton | ToggleButtonRevealStyle |
| RepeatButton | RepeatButtonRevealStyle |
| AppBarButton | AppBarButtonRevealStyle |
| SemanticZoom | SemanticZoomRevealStyle |

これらのスタイルを適用するには、Style プロパティを次のように更新するだけです。

```XAML
<Button Content="Button Content" Style="{StaticResource ButtonRevealStyle}"/>
```

## <a name="enabling-reveal-on-custom-controls"></a>カスタム コントロールで表示を有効にする

システム コントロールが表示を取得するかどうかを判断する際に考える必要がある一般的なルールは、すべてアプリで実行する包括的な機能またはアクションに関連している対話型要素のグループを作成する必要があるということです。

たとえば、NavigationView の項目はページ ナビゲーションに関連しています。 CommandBar のボタンは、メニューのアクションまたはページ機能のアクションに関連しています。 その下にある MediaTransportControl のボタンは、すべて再生するメディアに関連しています。

表示を取得するコントロールが互いに関連している必要はありません。高密度の領域に存在し、大きい目的に適合しているだけでかまいません。

カスタム コントロールや再テンプレート化されたコントロールで表示を有効にするには、そのコントロールのテンプレートの表示状態 (VisualState) でコントロールのスタイルを調べ、ルート グリッドで表示を指定します。

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

表示が十分に機能するため、表示状態ではブラシと setter の両方が必要である点に留意することは重要です。 コントロールのブラシをいずれかの表示ブラシ リソースに設定するだけでは、そのコントロールの表示が有効になりません。 反対に、表示ブラシとなる値がないターゲットまたは設定だけでも表示は有効になりません。

UI のカスタマイズに使うことができる一連のシステム表示ブラシが作成されました。 たとえば、**ButtonRevealBackground** ブラシを使ってカスタム ボタンの背景を作成したり、カスタム一覧に **ListViewItemRevealBackground** ブラシを使ったりすることができます 

(XAMl でのリソースのしくみについて詳しくは、[Xaml リソース ディクショナリに関する記事](../controls-and-patterns/resourcedictionary-and-xaml-resource-references.md)をご覧ください)。

### <a name="reveal-on-listview-controls-with-nested-buttons"></a>入れ子になったボタンのある ListView コントロールでの表示

[ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) があり、その [ListViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listviewitem) 要素内でボタンや呼び出し可能なコンテンツが入れ子になっている場合、入れ子になった項目の表示を有効にする必要があります。

ボタン、またはListViewItem 内のボタンのようなコントロールの場合、コントロールの [Style](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_Style) プロパティを **ButtonRevealStyle** 静的リソースに設定するだけです。 

![入れ子になった表示](images/NestedListContent.png)

この例では、ListViewItem 内のいくつかのボタンで表示を有効にします。 

```XAML
<ListViewItem>
    <StackPanel Orientation="Horizontal">
        <TextBlock Margin="5">Test Text: lorem ipsum.</TextBlock>
        <StackPanel Orientation="Horizontal">
            <Button Content="&#xE71B;" FontFamily="Segoe MDL2 Assets" Width="45" Height="45" Margin="5" Style="{StaticResource ButtonRevealStyle}"/>
            <Button Content="&#xE728;" FontFamily="Segoe MDL2 Assets" Width="45" Height="45" Margin="5" Style="{StaticResource ButtonRevealStyle}"/>
            <Button Content="&#xE74D;" FontFamily="Segoe MDL2 Assets" Width="45" Height="45" Margin="5" Style="{StaticResource ButtonRevealStyle}"/>
         </StackPanel>
    </StackPanel>
</ListViewItem>
```

### <a name="listviewitempresenter-with-reveal"></a>表示のある ListViewItemPresenter

一覧は、XAML では少し特別です。表示のケースでは、ListViewItemPresenter 内で表示専用の Visual State Manager を定義する必要があります。

```XAML
<ListViewItemPresenter>
<!-- ContentTransitions, SelectedForeground, etc. properties -->
RevealBackground="{ThemeResource ListViewItemRevealBackground}"
RevealBorderThickness="{ThemeResource ListViewItemRevealBorderThemeThickness}"
RevealBorderBrush="{ThemeResource ListViewItemRevealBorderBrush}">
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="CommonStates">
        <VisualState x:Name="Normal" />
        <VisualState x:Name="Selected" />
        <VisualState x:Name="PointerOver">
            <VisualState.Setters>
                <Setter Target="Root.(RevealBrush.State)" Value="PointerOver" />
            </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="PointerOverSelected">
                <VisualState.Setters>
                    <Setter Target="Root.(RevealBrush.State)" Value="PointerOver" />
                </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="PointerOverPressed">
                <VisualState.Setters>
                    <Setter Target="Root.(RevealBrush.State)" Value="Pressed" />
                </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="Pressed">
                <VisualState.Setters>
                    <Setter Target="Root.(RevealBrush.State)" Value="Pressed" />
                </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="PressedSelected">
                <VisualState.Setters>
                    <Setter Target="Root.(RevealBrush.State)" Value="Pressed" />
                </VisualState.Setters>
            </VisualState>
            </VisualStateGroup>
                <VisualStateGroup x:Name="EnabledGroup">
                    <VisualState x:Name="Enabled" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                             <Setter Target="Root.RevealBorderThickness" Value="0"/>
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</ListViewItemPresenter>
```

これは、表示固有の表示状態 setter を持つ ListViewItemPresenter 内のプロパティ コレクションの末尾に追加することを意味します。

### <a name="full-template-example"></a>テンプレート全体の例

表示ボタンの外観を示すテンプレート全体を次に示します。

```XAML
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

## <a name="dos-and-donts"></a>推奨と非推奨
- ユーザーが操作を実行できる要素 (ボタン、選択肢) では表示を使う
- 既定で視覚的な区切り記号がない対話型要素のグループ (一覧、コマンド バー) では表示を使う
- 対話型要素が高密度な領域では表示を使う
- 静的コンテンツ (背景、テキスト) では表示を使わない
- 1 回限りの個別の状況では表示を使わない
- 非常に多くの項目 (500 epx 超) では表示を使わない
- セキュリティ上の決定を行う場合には表示を使わない (ユーザーに提供する必要があるメッセージから注意がそれる可能性があるため)

## <a name="how-we-designed-reveal"></a>表示をどのように設計したか

表示には 2 つの主要な視覚コンポーネントがあります。それらは、**ホバーによる表示**動作と**境界線による表示**動作です。

![表示レイヤー](images/RevealLayers.png)

ホバーによる表示は、ポインターやフォーカス入力によってポイントされるコンテンツに直接関連付けられており、ポイントされる項目やフォーカスが置かれる項目の周囲に滑らかなハロー型を適用し、その項目が操作可能であることを示します。

境界線による表示は、フォーカスが置かれる項目やその近くにある項目に適用されます。 これにより、オブジェクトの近くにある項目に対して、現在フォーカスが置かれている項目と類似した操作を実行できること示されます。

表示のレシピには以下のものがあります。

- 境界線による表示は、すべてのコンテンツの最上位にありますが、指定されたエッジの上に配置されます
- テキストとコンテンツは、境界線による表示の直下に表示されます
- ホバーによる表示は、コンテンツとテキストの下にあります
- バック プレート (ホバーによる表示をオンにして有効にします)
- 背景 (コントロールの背景です)

<!--
<div class=”microsoft-internal-note”>
To create your own Reveal lighting effect for static comps or prototype purposes, see the full [uni design guidance](http://uni/DesignDepot.FrontEnd/#/ProductNav/3020/1/dv/?t=Resources%7CToolkit%7CReveal&f=Neon) for this effect in illustrator.
</div>
-->  

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)
- [アクリル](acrylic.md)
- [コンポジションの効果](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [UWP の Fluent Design](../fluent-design-system/index.md)
- [システムの科学: Fluent Design と奥行き](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [システムの科学: Fluent Design と明るさ](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
