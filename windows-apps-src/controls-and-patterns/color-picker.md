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
# <a name="color-picker"></a><span data-ttu-id="4e5e3-104">カラー ピッカー</span><span class="sxs-lookup"><span data-stu-id="4e5e3-104">Color picker</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4e5e3-105">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-105">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="4e5e3-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="4e5e3-107">カラー ピッカーは、色を参照し、選ぶために使用します。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-107">A color picker is used to browse through and select colors.</span></span> <span data-ttu-id="4e5e3-108">既定では、ユーザーはカラー ピッカーを使って、カラー スペクトルで色を参照するか、Red-Green-Blue (RGB)、Hue-Saturation-Value (HSV)、または 16 進数のテキスト ボックスのいずれかで色を指定できます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-108">By default, it lets a user navigate through colors on a color spectrum, or specify a color in either Red-Green-Blue (RGB), Hue-Saturation-Value (HSV), or Hexadecimal textboxes.</span></span>

> <span data-ttu-id="4e5e3-109">**重要な API**: [ColorPicker クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker)、[Color プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_color)、[ColorChanged イベント](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorchanged)</span><span class="sxs-lookup"><span data-stu-id="4e5e3-109">**Important APIs**: [ColorPicker class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker), [Color property](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_color), [ColorChanged event](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorchanged)</span></span>

![既定のカラー ピッカー](images/color-picker-default.png)


## <a name="is-this-the-right-control"></a><span data-ttu-id="4e5e3-111">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="4e5e3-111">Is this the right control?</span></span>

<span data-ttu-id="4e5e3-112">アプリでユーザーが色を選べるようにするには、カラー ピッカーを使います。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-112">Use the color picker to let a user select colors in your app.</span></span> <span data-ttu-id="4e5e3-113">たとえば、フォントの色、背景、またはアプリのテーマの色など、色の設定を変更するために、カラー ピッカーを使います。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-113">For example, use it to change color settings, such as font colors, background, or app theme colors.</span></span>

<span data-ttu-id="4e5e3-114">ペンを使って絵を描くなどのタスクを実行するアプリの場合は、カラー ピッカーと併せて[インク コントロール](http://windowsstyleguide/controls-and-patterns/inking-controls/)も使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-114">If your app is for drawing or similar tasks using pen, consider using [Inking controls](http://windowsstyleguide/controls-and-patterns/inking-controls/) along with the color picker.</span></span>

## <a name="create-a-color-picker"></a><span data-ttu-id="4e5e3-115">カラー ピッカーを作成する</span><span class="sxs-lookup"><span data-stu-id="4e5e3-115">Create a color picker</span></span>

<span data-ttu-id="4e5e3-116">次の例は、XAML で既定のカラー ピッカーを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-116">This example shows how to create a default color picker in XAML.</span></span>

```xaml
<ColorPicker x:Name="myColorPicker"/>
```

<span data-ttu-id="4e5e3-117">既定では、カラー ピッカーは、カラー スペクトルの横にある長方形のバーに、選択された色のプレビューを示します。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-117">By default, the color picker shows a preview of the chosen color on the rectangular bar beside the color spectrum.</span></span> <span data-ttu-id="4e5e3-118">アプリ内で選択された色にアクセスし、その色を使うには、[ColorChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorchanged) イベントか [Color](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_color) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-118">You can use either the [ColorChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorchanged) event or the [Color](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_color) property to access the selected color and use it in your app.</span></span> <span data-ttu-id="4e5e3-119">詳しいコードについては、これ以降の例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-119">See the following examples for detailed code.</span></span>

### <a name="bind-to-the-chosen-color"></a><span data-ttu-id="4e5e3-120">選択された色にバインドする</span><span class="sxs-lookup"><span data-stu-id="4e5e3-120">Bind to the chosen color</span></span>

<span data-ttu-id="4e5e3-121">選択した色がすぐに反映される必要がある場合は、コードで、データ バインディングを使って Color プロパティにバインドするか、ColorChanged イベントを処理して選択した色にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-121">When the color selection should take effect immediately, you can either use databinding to bind to the Color property, or handle the ColorChanged event to access the selected color in your code.</span></span>

<span data-ttu-id="4e5e3-122">次の例では、Rectangle の Fill として使われている SolidColorBrush の Color プロパティを直接カラー ピッカーで選択された色にバインドしています。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-122">In this example, you bind the Color property of a SolidColorBrush that’s used as the Fill for a Rectangle directly to the color picker’s selected color.</span></span> <span data-ttu-id="4e5e3-123">カラー ピッカーを変更すると、バインド先のプロパティも直ちに変更されます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-123">Any change to the color picker results in a live change to the bound property.</span></span>

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

<span data-ttu-id="4e5e3-124">この例では、よく "簡単" な色選択操作に利用される、円とスライダーだけのシンプルなカラー ピッカーを使っています。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-124">This example uses a simplified color picker with just the circle and the slider, which is a common "casual" color picking experience.</span></span> <span data-ttu-id="4e5e3-125">変更が適用されるオブジェクトに、リアルタイムで色の変更が反映される場合は、色のプレビュー バーを表示する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-125">When the color change can be seen and happens in real-time on the affected object, you don't need to show the color preview bar.</span></span> <span data-ttu-id="4e5e3-126">詳しくは「*カラー ピッカーをカスタマイズする*」のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-126">See the *Customize the color picker* section for more info.</span></span>

### <a name="save-the-chosen-color"></a><span data-ttu-id="4e5e3-127">選択された色を保存する</span><span class="sxs-lookup"><span data-stu-id="4e5e3-127">Save the chosen color</span></span>

<span data-ttu-id="4e5e3-128">色の変更を直ちに適用したくない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-128">In some cases, you don't want to apply the color change immediately.</span></span> <span data-ttu-id="4e5e3-129">たとえば、ポップアップでカラー ピッカーをホストする場合は、ユーザーが選択内容を確認して、ポップアップを閉じてから、選択された色を適用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-129">For example, when you host a color picker in a flyout, we recomend that you apply the selected color only after the user confirms the selection or closes the flyout.</span></span> <span data-ttu-id="4e5e3-130">選択された色の値を保存しておき、後で使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-130">You can also save the selected color value to use later.</span></span>

<span data-ttu-id="4e5e3-131">次の例では、確認用とキャンセル用のボタンがあるポップアップ (Flyout) でカラー ピッカーをホストしています。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-131">In this example, you host a color picker in a Flyout with Confirm and Cancel buttons.</span></span> <span data-ttu-id="4e5e3-132">ユーザーが選択した色でよいことを確認すると、選択された色がアプリで後で使用できるように保存されます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-132">When the user confirms their color choice, you save the selected color to use later in your app.</span></span>

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

### <a name="configure-the-color-picker"></a><span data-ttu-id="4e5e3-133">カラー ピッカーを構成する</span><span class="sxs-lookup"><span data-stu-id="4e5e3-133">Configure the color picker</span></span>

<span data-ttu-id="4e5e3-134">全部のフィールドなくてもユーザーは色を選ぶことができるので、カラー ピッカーは柔軟に扱うことができます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-134">Not all fields are necessary to let a user pick a color, so the color picker is flexible.</span></span> <span data-ttu-id="4e5e3-135">カラー ピッカーには、ニーズに合わせて構成できるさまざまなオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-135">It provides a variety of options that let you configure the control to fit your needs.</span></span>

<span data-ttu-id="4e5e3-136">たとえば、メモ帳アプリで蛍光ペンの色を選ぶなど、正確なコントロールが必要ない場合は、シンプルな UI を採用できます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-136">For example, when the user doesn't need precise control, like picking a highlighter color in a note taking app, you can use a simplified UI.</span></span> <span data-ttu-id="4e5e3-137">テキスト入力フィールドを非表示にし、カラー スペクトルを円形に変更します。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-137">You can hide the text entry fields and change the color spectrum to a circle.</span></span>

<span data-ttu-id="4e5e3-138">グラフィック デザインアプリなど、正確なコントロールが必要な場合は、色の要素ごとにスライダーとテキスト入力フィールドの両方を提供できます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-138">When the user does need precise control, like in a graphic design app, you can show both sliders and text entry fields for each aspect of the color.</span></span>

#### <a name="show-the-circle-spectrum"></a><span data-ttu-id="4e5e3-139">円形のスペクトルを表示する</span><span class="sxs-lookup"><span data-stu-id="4e5e3-139">Show the circle spectrum</span></span>

<span data-ttu-id="4e5e3-140">次の例は、[ColorSpectrumShape](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorspectrumshape) プロパティを使って、カラー ピッカーで既定の正方形ではなく円形のスペクトルを使うように構成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-140">This example shows how to use the [ColorSpectrumShape](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker_colorspectrumshape) property to configure the color picker to use a circular spectrum instead of the default square.</span></span>

```xaml
<ColorPicker x:Name="myColorPicker"
             ColorSpectrumShape="Ring"/>
```

![円形のスペクトルを表示するカラー ピッカー](images/color-picker-ring.png)

<span data-ttu-id="4e5e3-142">スペクトルを正方形と円形のどちらにするかを選ぶ必要がある場合、正確性が主な判断材料の 1 つになります。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-142">When you must choose between the square and circle color spectrum, a primary consideration is accuracy.</span></span> <span data-ttu-id="4e5e3-143">表示される色域の範囲が広いため、正方形を使って特定の色を選択すると、より正確に色をコントロールできます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-143">A user has more control when they select a specific color using a square because more of the color gamut is shown.</span></span> <span data-ttu-id="4e5e3-144">"簡単" に色を選択できることを優先する場合は、円形のスペクトルをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-144">You should consider the circle spectrum as more of the "casual" color choosing experience.</span></span>

#### <a name="show-the-alpha-channel"></a><span data-ttu-id="4e5e3-145">アルファ チャネルを表示する</span><span class="sxs-lookup"><span data-stu-id="4e5e3-145">Show the alpha channel</span></span>

<span data-ttu-id="4e5e3-146">次の例では、カラー ピッカーで不透明度のスライダーとテキスト ボックスを提供します。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-146">In this example, you enable an opacity slider and textbox on the color picker.</span></span>

```xaml
<ColorPicker x:Name="myColorPicker"
             IsAlphaEnabled="True"/>
```

![IsAlphaEnabled を true に設定したカラー ピッカー](images/color-picker-alpha.png)

#### <a name="show-a-simple-picker"></a><span data-ttu-id="4e5e3-148">シンプルなピッカーを表示する</span><span class="sxs-lookup"><span data-stu-id="4e5e3-148">Show a simple picker</span></span>

<span data-ttu-id="4e5e3-149">次の例では、"簡単" な操作向けのシンプルな UI でカラー ピッカーを構成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-149">This example shows how to configure the color picker with a simple UI for "casual" use.</span></span> <span data-ttu-id="4e5e3-150">円形のスペクトルを表示し、既定のテキスト入力ボックスは非表示にしています。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-150">You show the circular spectrum and hide the default text input boxes.</span></span> <span data-ttu-id="4e5e3-151">変更が適用されるオブジェクトに、リアルタイムで色の変更が反映される場合は、色のプレビュー バーを表示する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-151">When the color change can be seen and happens in real-time on the affected object, you don't need to show the color preview bar.</span></span> <span data-ttu-id="4e5e3-152">そうでない場合は、色のプレビューは表示したままにします。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-152">Otherwise, you should leave the color preview visible.</span></span>

```xaml
<ColorPicker x:Name="myColorPicker"
             ColorSpectrumShape="Ring"
             IsColorPreviewVisible="False"
             IsColorChannelTextInputVisible="False"
             IsHexInputVisible="False"/>
```

![シンプルなカラー ピッカー](images/color-picker-casual.png)

#### <a name="show-or-hide-additional-features"></a><span data-ttu-id="4e5e3-154">追加の機能を表示または非表示にする</span><span class="sxs-lookup"><span data-stu-id="4e5e3-154">Show or hide additional features</span></span>

<span data-ttu-id="4e5e3-155">ColorPicker コントロールの構成に使うことができるすべてのオプションを次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-155">This table shows all the options you can use to configure the ColorPicker control.</span></span>

<span data-ttu-id="4e5e3-156">機能</span><span class="sxs-lookup"><span data-stu-id="4e5e3-156">Feature</span></span> | <span data-ttu-id="4e5e3-157">プロパティ</span><span class="sxs-lookup"><span data-stu-id="4e5e3-157">Properties</span></span>
--------|-----------
<span data-ttu-id="4e5e3-158">カラー スペクトル</span><span class="sxs-lookup"><span data-stu-id="4e5e3-158">Color spectrum</span></span> | <span data-ttu-id="4e5e3-159">IsColorSpectrumVisible、ColorSpectrumShape、ColorSpectrumComponents</span><span class="sxs-lookup"><span data-stu-id="4e5e3-159">IsColorSpectrumVisible, ColorSpectrumShape, ColorSpectrumComponents</span></span>
<span data-ttu-id="4e5e3-160">色のプレビュー</span><span class="sxs-lookup"><span data-stu-id="4e5e3-160">Color preview</span></span> | <span data-ttu-id="4e5e3-161">IsColorPreviewVisible</span><span class="sxs-lookup"><span data-stu-id="4e5e3-161">IsColorPreviewVisible</span></span>
<span data-ttu-id="4e5e3-162">色の値</span><span class="sxs-lookup"><span data-stu-id="4e5e3-162">Color values</span></span>| <span data-ttu-id="4e5e3-163">IsColorSliderVisible、IsColorChannelTextInputVisible</span><span class="sxs-lookup"><span data-stu-id="4e5e3-163">IsColorSliderVisible, IsColorChannelTextInputVisible</span></span>
<span data-ttu-id="4e5e3-164">不透明度の値</span><span class="sxs-lookup"><span data-stu-id="4e5e3-164">Opacity values</span></span> | <span data-ttu-id="4e5e3-165">IsAlphaEnabled、IsAlphaSliderVisible、IsAlphaTextInputVisible</span><span class="sxs-lookup"><span data-stu-id="4e5e3-165">IsAlphaEnabled, IsAlphaSliderVisible, IsAlphaTextInputVisible</span></span>
<span data-ttu-id="4e5e3-166">16 進値</span><span class="sxs-lookup"><span data-stu-id="4e5e3-166">Hex values</span></span> | <span data-ttu-id="4e5e3-167">IsHexInputVisible</span><span class="sxs-lookup"><span data-stu-id="4e5e3-167">IsHexInputVisible</span></span>

> [!NOTE]
> <span data-ttu-id="4e5e3-168">不透明度のテキスト ボックスとスライダーを表示する場合は、IsAlphaEnabled を **true** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-168">IsAlphaEnabled must be **true** in order to show the opacity textbox and slider.</span></span> <span data-ttu-id="4e5e3-169">この設定にすると、IsAlphaTextInputVisible プロパティと IsAlphaSliderVisible プロパティを使って、入力コントロールの表示を変更できるようになります。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-169">The visibility of the input controls can then be modified using IsAlphaTextInputVisible and IsAlphaSliderVisible properties.</span></span> <span data-ttu-id="4e5e3-170">詳しくは、API ドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-170">See the API documentation for details.</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="4e5e3-171">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="4e5e3-171">Do's and Don'ts</span></span>

- <span data-ttu-id="4e5e3-172">アプリにはどのような色選択操作が適しているかを考えます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-172">Do think about what kind of color picking experience is appropriate for your app.</span></span> <span data-ttu-id="4e5e3-173">シナリオによっては、細かい設定をして色を選ぶ必要がなく、シンプルなピッカーが便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-173">Some scenarios may not require granular color picking and would benefit from a simplified picker</span></span>
- <span data-ttu-id="4e5e3-174">最も正確に色を選べるようにするには、256 x 256 ピクセル以上に正方形を使うか、ユーザーが選択した色を調整できるようにテキスト入力フィールドを含めます。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-174">For the most accurate color picking experience, use the square spectrum and ensure it is at least 256x256px, or include the text input fields to let users refine their selected color.</span></span>
- <span data-ttu-id="4e5e3-175">ポップアップで使う場合は、スペクトルをタップするか、スライダーを調節しただけでは、色の選択が確定されないようにします。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-175">When used in a flyout, tapping in the spectrum or adjusting the slider alone should not commit the color selection.</span></span> <span data-ttu-id="4e5e3-176">選択を確定するには、次のように対応します。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-176">To commit the selection:</span></span>
  - <span data-ttu-id="4e5e3-177">選択内容の適用や取り消しを行う確定ボタンとキャンセル ボタンを提供します。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-177">Provide commit and cancel buttons to apply or cancel the selection.</span></span> <span data-ttu-id="4e5e3-178">戻るボタンを押すか、ポップアップ外の領域をタップすると、ポップアップを閉じます。ユーザーの選択内容は保存されません。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-178">Hitting the back button or tapping outside of the flyout will dismiss it, and not save the user’s selection.</span></span>
  - <span data-ttu-id="4e5e3-179">または、ポップアップ外の領域をタップするか、戻るボタンを押すと、ポップアップを閉じ、ユーザーの選択内容を適用します。</span><span class="sxs-lookup"><span data-stu-id="4e5e3-179">Or, commit the selection upon dismissing the flyout, by either tapping outside of the flyout or hitting the back button.</span></span>

## <a name="related-articles"></a><span data-ttu-id="4e5e3-180">関連記事</span><span class="sxs-lookup"><span data-stu-id="4e5e3-180">Related articles</span></span>

- [<span data-ttu-id="4e5e3-181">UWP アプリのペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="4e5e3-181">Pen and stylus interactions in UWP apps</span></span>](../input-and-devices/pen-and-stylus-interactions.md)
- [<span data-ttu-id="4e5e3-182">インク操作</span><span class="sxs-lookup"><span data-stu-id="4e5e3-182">Inking</span></span>](inking-controls.md)

<!--
<div class=”microsoft-internal-note”>
<p>
<p>
Note: For more info, see the [color picker redlines](http://uni/DesignDepot.FrontEnd/#/ProductNav/3666/15/dv/?t=Windows%7CControls&f=RS2) on UNI.
</div>
-->