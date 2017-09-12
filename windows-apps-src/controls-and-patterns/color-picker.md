---
author: Jwmsft
Description: "カラー ピッカーは、ユーザーが色を参照して選ぶためのしくみです。"
title: "カラー ピッカー"
label: Color Picker
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: llongley
doc-status: Published
ms.openlocfilehash: 546f904239c61c36422070e946d3cd1c6496c9aa
ms.sourcegitcommit: 45490bd85e6f8d247a041841d547ecac2ff48250
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/23/2017
---
# <a name="color-picker"></a>カラー ピッカー

> [!IMPORTANT]
> この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

カラー ピッカーは、色を参照し、選ぶために使用します。 既定では、ユーザーはカラー ピッカーを使って、カラー スペクトルで色を参照するか、Red-Green-Blue (RGB)、Hue-Saturation-Value (HSV)、または 16 進数のテキスト ボックスのいずれかで色を指定できます。

> **重要な API**: [ColorPicker クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker)、[Color プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_color)、[ColorChanged イベント](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorchanged)

![既定のカラー ピッカー](images/color-picker-default.png)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

アプリでユーザーが色を選べるようにするには、カラー ピッカーを使います。 たとえば、フォントの色、背景、またはアプリのテーマの色など、色の設定を変更するために、カラー ピッカーを使います。

ペンを使って絵を描くなどのタスクを実行するアプリの場合は、カラー ピッカーと併せて[インク コントロール](http://windowsstyleguide/controls-and-patterns/inking-controls/)も使うことを検討してください。

## <a name="create-a-color-picker"></a>カラー ピッカーを作成する

次の例は、XAML で既定のカラー ピッカーを作成する方法を示しています。

```xaml
<ColorPicker x:Name="myColorPicker"/>
```

既定では、カラー ピッカーは、カラー スペクトルの横にある長方形のバーに、選択された色のプレビューを示します。 アプリ内で選択された色にアクセスし、その色を使うには、[ColorChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorchanged) イベントか [Color](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_color) プロパティを使います。 詳しいコードについては、これ以降の例を参照してください。

### <a name="bind-to-the-chosen-color"></a>選択された色にバインドする

選択した色がすぐに反映される必要がある場合は、コードで、データ バインディングを使って Color プロパティにバインドするか、ColorChanged イベントを処理して選択した色にアクセスします。

次の例では、Rectangle の Fill として使われている SolidColorBrush の Color プロパティを直接カラー ピッカーで選択された色にバインドしています。 カラー ピッカーを変更すると、バインド先のプロパティも直ちに変更されます。

```xaml
<ColorPicker x:Name="myColorPicker"
             ColorSpectrumShape=”Ring”
             IsColorPreviewVisible="False"
             IsColorChannelTextInputVisible="False"
             IsHexInputVisible="False"/>

<Rectangle Height="50" Width="50">
    <Rectangle.Fill>
        <SolidColorBrush Color="{x:Bind myColorPicker.Color, Mode=OneWay}"/>
    </Rectangle.Fill>
</Rectangle>
```

この例では、よく "簡単" な色選択操作に利用される、円とスライダーだけのシンプルなカラー ピッカーを使っています。 変更が適用されるオブジェクトに、リアルタイムで色の変更が反映される場合は、色のプレビュー バーを表示する必要はありません。 詳しくは「*カラー ピッカーをカスタマイズする*」のセクションをご覧ください。

### <a name="save-the-chosen-color"></a>選択された色を保存する

色の変更を直ちに適用したくない場合もあります。 たとえば、ポップアップでカラー ピッカーをホストする場合は、ユーザーが選択内容を確認して、ポップアップを閉じてから、選択された色を適用することをお勧めします。 選択された色の値を保存しておき、後で使うこともできます。

次の例では、確認用とキャンセル用のボタンがあるポップアップ (Flyout) でカラー ピッカーをホストしています。 ユーザーが選択した色でよいことを確認すると、選択された色がアプリで後で使用できるように保存されます。

```xaml
<Page.Resources>
    <Flyout x:Key="myColorPickerFlyout">
        <RelativePanel>
            <ColorPicker x:Name="myColorPicker"
                         IsColorChannelTextInputVisible="False"
                         IsHexInputVisible="False"/>

            <Grid RelativePanel.Below="myColorPicker"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <Button Content="OK" Click="confirmColor_Click"
                        Margin="0,12,2,0" HorizontalAlignment="Stretch"/>
                <Button Content="Cancel" Click="cancelColor_Click"
                        Margin="2,12,0,0" HorizontalAlignment="Stretch"
                        Grid.Column="1"/>
            </Grid>
        </RelativePanel>
    </Flyout>
</Page.Resources>

<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Button x:Name="colorPickerButton"
            Content="Pick a color"
            Flyout="{StaticResource myColorPickerFlyout}"/>
</Grid>
```

```csharp
private Color mycolor;

private void confirmColor_Click(object sender, RoutedEventArgs e)
{
    // Assign the selected color to a variable to use outside the popup.
    myColor = myColorPicker.Color;

    // Close the Flyout.
    colorPickerButton.Flyout.Hide();
}

private void cancelColor_Click(object sender, RoutedEventArgs e)
{
    // Close the Flyout.
    colorPickerButton.Flyout.Hide();
}
```

### <a name="configure-the-color-picker"></a>カラー ピッカーを構成する

全部のフィールドなくてもユーザーは色を選ぶことができるので、カラー ピッカーは柔軟に扱うことができます。 カラー ピッカーには、ニーズに合わせて構成できるさまざまなオプションがあります。

たとえば、メモ帳アプリで蛍光ペンの色を選ぶなど、正確なコントロールが必要ない場合は、シンプルな UI を採用できます。 テキスト入力フィールドを非表示にし、カラー スペクトルを円形に変更します。

グラフィック デザインアプリなど、正確なコントロールが必要な場合は、色の要素ごとにスライダーとテキスト入力フィールドの両方を提供できます。

#### <a name="show-the-circle-spectrum"></a>円形のスペクトルを表示する

次の例は、[ColorSpectrumShape](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorspectrumshape) プロパティを使って、カラー ピッカーで既定の正方形ではなく円形のスペクトルを使うように構成する方法を示しています。

```xaml
<ColorPicker x:Name="myColorPicker"
             ColorSpectrumShape="Ring"/>
```

![円形のスペクトルを表示するカラー ピッカー](images/color-picker-ring.png)

スペクトルを正方形と円形のどちらにするかを選ぶ必要がある場合、正確性が主な判断材料の 1 つになります。 表示される色域の範囲が広いため、正方形を使って特定の色を選択すると、より正確に色をコントロールできます。 "簡単" に色を選択できることを優先する場合は、円形のスペクトルをお勧めします。

#### <a name="show-the-alpha-channel"></a>アルファ チャネルを表示する

次の例では、カラー ピッカーで不透明度のスライダーとテキスト ボックスを提供します。

```xaml
<ColorPicker x:Name="myColorPicker"
             IsAlphaEnabled="True"/>
```

![IsAlphaEnabled を true に設定したカラー ピッカー](images/color-picker-alpha.png)

#### <a name="show-a-simple-picker"></a>シンプルなピッカーを表示する

次の例では、"簡単" な操作向けのシンプルな UI でカラー ピッカーを構成する方法を示しています。 円形のスペクトルを表示し、既定のテキスト入力ボックスは非表示にしています。 変更が適用されるオブジェクトに、リアルタイムで色の変更が反映される場合は、色のプレビュー バーを表示する必要はありません。 そうでない場合は、色のプレビューは表示したままにします。

```xaml
<ColorPicker x:Name="myColorPicker"
             ColorSpectrumShape="Ring"
             IsColorPreviewVisible="False"
             IsColorChannelTextInputVisible="False"
             IsHexInputVisible="False"/>
```

![シンプルなカラー ピッカー](images/color-picker-casual.png)

#### <a name="show-or-hide-additional-features"></a>追加の機能を表示または非表示にする

ColorPicker コントロールの構成に使うことができるすべてのオプションを次の表に示します。

機能 | プロパティ
--------|-----------
カラー スペクトル | IsColorSpectrumVisible、ColorSpectrumShape、ColorSpectrumComponents
色のプレビュー | IsColorPreviewVisible
色の値| IsColorSliderVisible、IsColorChannelTextInputVisible
不透明度の値 | IsAlphaEnabled、IsAlphaSliderVisible、IsAlphaTextInputVisible
16 進値 | IsHexInputVisible

> [!NOTE]
> 不透明度のテキスト ボックスとスライダーを表示する場合は、IsAlphaEnabled を **true** に設定する必要があります。 この設定にすると、IsAlphaTextInputVisible プロパティと IsAlphaSliderVisible プロパティを使って、入力コントロールの表示を変更できるようになります。 詳しくは、API ドキュメントをご覧ください。

## <a name="dos-and-donts"></a>推奨と非推奨

- アプリにはどのような色選択操作が適しているかを考えます。 シナリオによっては、細かい設定をして色を選ぶ必要がなく、シンプルなピッカーが便利な場合があります。
- 最も正確に色を選べるようにするには、256 x 256 ピクセル以上に正方形を使うか、ユーザーが選択した色を調整できるようにテキスト入力フィールドを含めます。
- ポップアップで使う場合は、スペクトルをタップするか、スライダーを調節しただけでは、色の選択が確定されないようにします。 選択を確定するには、次のように対応します。
  - 選択内容の適用や取り消しを行う確定ボタンとキャンセル ボタンを提供します。 戻るボタンを押すか、ポップアップ外の領域をタップすると、ポップアップを閉じます。ユーザーの選択内容は保存されません。
  - または、ポップアップ外の領域をタップするか、戻るボタンを押すと、ポップアップを閉じ、ユーザーの選択内容を適用します。

## <a name="related-articles"></a>関連記事

- [UWP アプリのペン操作とスタイラス操作](../input-and-devices/pen-and-stylus-interactions.md)
- [インク操作](inking-controls.md)

<!--
<div class=”microsoft-internal-note”>
<p>
<p>
Note: For more info, see the [color picker redlines](http://uni/DesignDepot.FrontEnd/#/ProductNav/3666/15/dv/?t=Windows%7CControls&f=RS2) on UNI.
</div>
-->