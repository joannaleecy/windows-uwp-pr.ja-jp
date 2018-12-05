---
Description: You can customize a control's visual structure and visual behavior by creating a control template in the XAML framework.
MS-HAID: dev\_ctrl\_layout\_txt.control\_templates
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: コントロール テンプレート
ms.assetid: 6E642626-A1D6-482F-9F7E-DBBA7A071DAD
label: Control templates
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9ad66d8797234d01673518256d6f5376ce93245f
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8709784"
---
# <a name="control-templates"></a>コントロール テンプレート

XAML フレームワークで、コントロール テンプレートを作ることによって、コントロールの視覚的構造や視覚的動作をカスタマイズすることができます。 コントロールには、[**Background**](https://msdn.microsoft.com/library/windows/apps/br209395)、[**Foreground**](https://msdn.microsoft.com/library/windows/apps/br209414)、[**FontFamily**](https://msdn.microsoft.com/library/windows/apps/br209404) などの多くのプロパティがあり、このプロパティを設定することで、コントロールの外観に関するさまざまな要素を指定できます。 ただし、これらのプロパティの設定によって変更できる内容は限られています。 [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) クラスを使ってテンプレートを作成することにより、さらに細かいカスタマイズを指定できます。 ここでは、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) コントロールの外観をカスタマイズする **ControlTemplate** の作成方法について説明します。

> **重要な API**: [**ControlTemplate クラス**](https://msdn.microsoft.com/library/windows/apps/br209391)、[**Control.Template プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.template.aspx)

## <a name="custom-control-template-example"></a>カスタム コントロール テンプレートの例

既定では、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) コントロールの内容 (**CheckBox** の横に表示される文字列またはオブジェクト) は、選択ボックスの右側に配置され、チェック マークはユーザーがその **CheckBox** を選択したことを示します。 これらの特性は、**CheckBox** の視覚的構造や視覚的動作を表します。

次の図は、既定の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) を使った [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) での `Unchecked`、`Checked`、`Indeterminate` の各状態を示しています。

![既定の CheckBox テンプレート](images/templates-checkbox-states-default.png)

[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) に対して [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) を作成することで、これらの特性を変更できます。 たとえば、チェック ボックスの内容を選択ボックスの下に配置し、ユーザーがチェック ボックスをオンにしたことを **X** で示す場合を考えます。 **CheckBox** の **ControlTemplate** に、これらの特性を指定します。

コントロールにカスタム テンプレートを使うには、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) をコントロールの [**Template**](https://msdn.microsoft.com/library/windows/apps/br209465) プロパティに割り当てます。 ここでは、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) に `CheckBoxTemplate1` という名前の **ControlTemplate** を使います。 **ControlTemplate** の Extensible Application Markup Language (XAML) は、次のセクションで示します。

```XAML
<CheckBox Content="CheckBox" Template="{StaticResource CheckBoxTemplate1}" IsThreeState="True" Margin="20"/>
```

このテンプレートを適用した後で [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) の `Unchecked`、`Checked`、`Indeterminate` の各状態がどのようになるかを次に示します。

![カスタム CheckBox テンプレート](images/templates-checkbox-states.png)

## <a name="specify-the-visual-structure-of-a-control"></a>コントロールの視覚的構造の指定

[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) を作るときには、いくつかの [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) オブジェクトを組み合わせて 1 つのコントロールを作ります。 **ControlTemplate** には、ルート要素として **FrameworkElement** が 1 つだけ含まれている必要があります。 通常、ルート要素には、他の **FrameworkElement** オブジェクトが含まれています。 オブジェクトの組み合わせによって、コントロールの視覚的構造が作られます

次の XAML は、コントロールの内容を選択ボックスの下に配置するよう指定する、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) 用の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) を作成します。 ルート要素は [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) です。 この例では、ユーザーが **CheckBox** をオンにしたことを示す **X** を作成する [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) と、不確定状態を示す [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) を指定しています。 これらの **Path** と **Ellipse** では [**Opacity**](/uwp/api/Windows.UI.Xaml.UIElement.Opacity) が 0 に設定されているため、既定ではどちらも表示されません。

[TemplateBinding](../../xaml-platform/templatebinding-markup-extension.md) は、コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクする特殊なバインディングです。 XAML では、TemplateBinding は ControlTemplate 定義内でのみ使用できます。 詳しくは、「[TemplateBinding マークアップ拡張](../../xaml-platform/templatebinding-markup-extension.md)」をご覧ください。

> [!NOTE]
> Windows 10、バージョン 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) 以降では[**X:bind**](https://msdn.microsoft.com/library/windows/apps/Mt204783)マークアップ拡張機能を使うことができますの場所では、 [TemplateBinding](../../xaml-platform/templatebinding-markup-extension.md)を使用します。 詳しくは、「[TemplateBinding マークアップ拡張](../../xaml-platform/templatebinding-markup-extension.md)」をご覧ください。

```XAML
<ControlTemplate x:Key="CheckBoxTemplate1" TargetType="CheckBox">
    <Border BorderBrush="{TemplateBinding BorderBrush}"
            BorderThickness="{TemplateBinding BorderThickness}"
            Background="{TemplateBinding Background}">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="25"/>
            </Grid.RowDefinitions>
            <Rectangle x:Name="NormalRectangle" Fill="Transparent" Height="20" Width="20"
                       Stroke="{ThemeResource SystemControlForegroundBaseMediumHighBrush}"
                       StrokeThickness="{ThemeResource CheckBoxBorderThemeThickness}"
                       UseLayoutRounding="False"/>
            <!-- Create an X to indicate that the CheckBox is selected. -->
            <Path x:Name="CheckGlyph"
                  Data="M103,240 L111,240 119,248 127,240 135,240 123,252 135,264 127,264 119,257 111,264 103,264 114,252 z"
                  Fill="{ThemeResource CheckBoxForegroundThemeBrush}"
                  FlowDirection="LeftToRight"
                  Height="14" Width="16" Opacity="0" Stretch="Fill"/>
            <Ellipse x:Name="IndeterminateGlyph"
                     Fill="{ThemeResource CheckBoxForegroundThemeBrush}"
                     Height="8" Width="8" Opacity="0" UseLayoutRounding="False" />
            <ContentPresenter x:Name="ContentPresenter"
                              ContentTemplate="{TemplateBinding ContentTemplate}"
                              Content="{TemplateBinding Content}"
                              Margin="{TemplateBinding Padding}" Grid.Row="1"
                              HorizontalAlignment="Center"
                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
        </Grid>
    </Border>
</ControlTemplate>
```

## <a name="specify-the-visual-behavior-of-a-control"></a>コントロールの視覚的動作の指定

視覚的動作は、コントロールが特定の状態にあるときの外観を指定します。 [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) コントロールには、`Checked`、`Unchecked`、`Indeterminate` という 3 つのチェック状態があります。 [**IsChecked**](https://msdn.microsoft.com/library/windows/apps/br209798) プロパティの値によって **CheckBox** の状態が決まり、その状態によって、ボックスに何が表示されるかが決まります。

次の表に、考えられる [**IsChecked**](https://msdn.microsoft.com/library/windows/apps/br209798) の値と、対応する [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) の状態および **CheckBox** の外観を示します。

|                     |                    |                         |
|---------------------|--------------------|-------------------------|
| **IsChecked** の値 | **CheckBox** の状態 | **CheckBox** の外観 |
| **true**            | `Checked`          | "X" を表示。        |
| **false**           | `Unchecked`        | 空白。                  |
| **null**            | `Indeterminate`    | 円を表示。      |


[**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) オブジェクトを使って、コントロールが特定の状態にあるときの外観を指定します。 **VisualState** には、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 内の要素の外観を変更する [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) または [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br243053) が含まれています。 コントロールが [**VisualState.Name**](https://msdn.microsoft.com/library/windows/apps/br209031) プロパティで指定された状態になると、**Setter** または [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) 内のプロパティの変更が適用されます。 コントロールがこの状態でなくなると、変更は削除されます。 **VisualState** オブジェクトは [**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/br209014) オブジェクトに追加します。 **ControlTemplate** のルート [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) に設定する [**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) 添付プロパティに、**VisualStateGroup** オブジェクトを追加します。

次の XAML は、`Checked`、`Unchecked`、`Indeterminate` の各状態に対する [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) オブジェクトを示しています。 この例では、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) のルート要素である [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) に対して [**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) 添付プロパティを設定します。 `Checked` **VisualState** は、(前の例で示した) `CheckGlyph` という名前の [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) の [**Opacity**](/uwp/api/Windows.UI.Xaml.UIElement.Opacity) が 1 であることを指定します。 `Indeterminate` **VisualState** は、`IndeterminateGlyph` という名前の [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) の **Opacity** が 1 であることを指定します。 `Unchecked` **VisualState** には [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) または [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) がないため、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) は既定の外観に戻ります。

```XAML
<ControlTemplate x:Key="CheckBoxTemplate1" TargetType="CheckBox">
    <Border BorderBrush="{TemplateBinding BorderBrush}"
            BorderThickness="{TemplateBinding BorderThickness}"
            Background="{TemplateBinding Background}">

        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="CheckStates">
                <VisualState x:Name="Checked">
                    <VisualState.Setters>
                        <Setter Target="CheckGlyph.Opacity" Value="1"/>
                    </VisualState.Setters>
                    <!-- This Storyboard is equivalent to the Setter. -->
                    <!--<Storyboard>
                        <DoubleAnimation Duration="0" To="1"
                         Storyboard.TargetName="CheckGlyph" Storyboard.TargetProperty="Opacity"/>
                    </Storyboard>-->
                </VisualState>
                <VisualState x:Name="Unchecked"/>
                <VisualState x:Name="Indeterminate">
                    <VisualState.Setters>
                        <Setter Target="IndeterminateGlyph.Opacity" Value="1"/>
                    </VisualState.Setters>
                    <!-- This Storyboard is equivalent to the Setter. -->
                    <!--<Storyboard>
                        <DoubleAnimation Duration="0" To="1"
                         Storyboard.TargetName="IndeterminateGlyph" Storyboard.TargetProperty="Opacity"/>
                    </Storyboard>-->
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="25"/>
            </Grid.RowDefinitions>
            <Rectangle x:Name="NormalRectangle" Fill="Transparent" Height="20" Width="20"
                       Stroke="{ThemeResource SystemControlForegroundBaseMediumHighBrush}"
                       StrokeThickness="{ThemeResource CheckBoxBorderThemeThickness}"
                       UseLayoutRounding="False"/>
            <!-- Create an X to indicate that the CheckBox is selected. -->
            <Path x:Name="CheckGlyph"
                  Data="M103,240 L111,240 119,248 127,240 135,240 123,252 135,264 127,264 119,257 111,264 103,264 114,252 z"
                  Fill="{ThemeResource CheckBoxForegroundThemeBrush}"
                  FlowDirection="LeftToRight"
                  Height="14" Width="16" Opacity="0" Stretch="Fill"/>
            <Ellipse x:Name="IndeterminateGlyph"
                     Fill="{ThemeResource CheckBoxForegroundThemeBrush}"
                     Height="8" Width="8" Opacity="0" UseLayoutRounding="False" />
            <ContentPresenter x:Name="ContentPresenter"
                              ContentTemplate="{TemplateBinding ContentTemplate}"
                              Content="{TemplateBinding Content}"
                              Margin="{TemplateBinding Padding}" Grid.Row="1"
                              HorizontalAlignment="Center"
                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
        </Grid>
    </Border>
</ControlTemplate>
```

[**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) オブジェクトの機能をよりよく理解するために、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) が `Unchecked` 状態から `Checked` 状態に変化した後、`Indeterminate` 状態に変化してから、`Unchecked` 状態に戻るとき、どのようになるかを考えてみます。 状態の遷移を次に示します。

|                                      |                                                                                                                                                                                                                                                                                                                                                |                                                   |
|--------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------|
| 状態の遷移                     | 動作                                                                                                                                                                                                                                                                                                                                   | 遷移完了時の CheckBox の外観 |
| `Unchecked` から `Checked`。       | `Checked` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) の [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) 値が適用され、`CheckGlyph` の [**Opacity**](/uwp/api/Windows.UI.Xaml.UIElement.Opacity) が 1 となる。                                                                                                                                                         | X が表示される。                                |
| `Checked` から `Indeterminate`。   | `Indeterminate` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) の [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) 値が適用され、`IndeterminateGlyph` の [**Opacity**](/uwp/api/Windows.UI.Xaml.UIElement.Opacity) が 1 となる。 `Checked` **VisualState** の **Setter** 値が削除され、`CheckGlyph` の [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br228078) が 0 となる。 | 円が表示される。                            |
| `Indeterminate` から `Unchecked`。 | `Indeterminate` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) の [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) 値が削除され、`IndeterminateGlyph` の [**Opacity**](/uwp/api/Windows.UI.Xaml.UIElement.Opacity) が 0 となる。                                                                                                                                           | 何も表示されない。                             |

 
コントロールの表示状態の作成方法、特に、[**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) クラスとアニメーション タイプの使い方について詳しくは、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/jj819808)」をご覧ください。

## <a name="use-tools-to-work-with-themes-easily"></a>ツールを使ってテーマを簡単に操作

コントロールにテーマをすばやく適用する方法の 1 つは、Microsoft Visual Studio の **[ドキュメント アウトライン]** でコントロールを右クリックし、**[テーマの編集]** または **[スタイルの編集]** (右クリックしたコントロールによって異なる) をクリックすることです。 その後、**[リソースの適用]** をクリックして既にあるテーマを適用するか、または **[空アイテムの作成]** をクリックして新しいテーマを定義できます。

## <a name="controls-and-accessibility"></a>コントロールとアクセシビリティ

コントロールのテンプレートを新しく作成するときは、コントロールの動作と外見を変更する以外にも、アクセシビリティ フレームワークに対する表現方法も変更することができます。 ユニバーサル Windows プラットフォーム (UWP) は、アクセシビリティのための Microsoft UI オートメーション フレームワークをサポートしています。 既定のコントロールとそのテンプレートはいずれも、UI オートメーションの共通のコントロール型と、その目的や機能に合ったパターンをサポートしています。 支援技術などの UI オートメーション クライアントが、これらのコントロール型とパターンを解釈することにより、アクセシビリティ対応アプリの UI という、より大きな枠組みを構成する要素としてコントロールを利用することができます。

基本的なコントロールのロジックを分離すると共に、UI オートメーションのアーキテクチャに求められるいくつかの要件を満たすために、コントロール クラスのアクセシビリティ機能は、別個のクラス (オートメーション ピア) に置かれています。 オートメーション ピアは、折に触れてコントロール テンプレートと対話します。テンプレート内の特定の名前付きパーツの存在を頼りにその機能 (支援技術によってボタン アクションを呼び出すなど) を実現しているためです。

まったく新しいカスタム コントロールを作成するときは、同時に、新しいオートメーション ピアの作成が必要になることもあります。 詳しくは、「[カスタム オートメーション ピア](../accessibility/custom-automation-peers.md)」をご覧ください。

## <a name="learn-more-about-a-controls-default-template"></a>コントロールの既定のテンプレートの詳細

XAML コントロールのスタイルとテンプレートについて説明するトピックでは、既に説明した **テーマの編集**や**スタイルの編集**の手法を使った場合に見られる、同じ XAML の開始部分を抜粋しています。 各トピックでは、表示状態の名前、使用しているテーマ リソースを示しているほか、テンプレートを含むスタイルの完全な XAML を示しています。 これらのトピックが便利なガイダンスになるのは、テンプレートを変更し始めてから元のテンプレートがどのように見えていたかを確認したり、必要な名前付きの表示状態がすべて新しいテンプレートにあることを確認したりする場合です。

## <a name="theme-resources-in-control-templates"></a>コントロール テンプレートのテーマ リソース

XAML の例を見ると、一部の属性について [{ThemeResource} マークアップ拡張機能](../../xaml-platform/themeresource-markup-extension.md) を使うリソース参照があることがわかるでしょう。 この手法では、現在アクティブであるテーマに応じて値が変わるリソースを 1 つのコントロール テンプレートで使用できます。 この点はブラシと色に特に重要です。システム全体に暗い、明るい、またはハイコントラストのいずれのテーマを適用するかをユーザーが選択できるようにすることが、テーマの主な目的であるためです。 XAML リソース システムを使うアプリはそのテーマに適切な一連のリソースを使用できます。そのため、アプリの UI のテーマの選択にはユーザーのシステム全体のテーマの選択が反映されます。

 # のサンプル コードを入手します。

* [XAML コントロール ギャラリーのサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)
* [カスタム テキスト編集コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/CustomEditControl)
