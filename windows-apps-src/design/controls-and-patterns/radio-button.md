---
Description: Radio buttons let users select one option from two or more choices.
title: ラジオ ボタンのガイドライン
ms.assetid: 41E3F928-AA55-42A2-9281-EC3907C4F898
label: Radio buttons
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: f614b6f167f91f276557aaff383921742d63c684
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7840596"
---
# <a name="radio-buttons"></a><span data-ttu-id="a0216-103">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="a0216-103">Radio buttons</span></span>

> <span data-ttu-id="a0216-104">**重要な API**: [RadioButton クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.RadioButton)、[Checked イベント](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.Checked)、[IsChecked プロパティ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.IsChecked)</span><span class="sxs-lookup"><span data-stu-id="a0216-104">**Important APIs**: [RadioButton class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.RadioButton), [Checked event](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.Checked), [IsChecked property](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.IsChecked)</span></span>

<span data-ttu-id="a0216-105">ラジオ ボタンを使用すると、ユーザーはセットから 1 つのオプションを選択できます。</span><span class="sxs-lookup"><span data-stu-id="a0216-105">Radio buttons allow users to select one option from a set.</span></span> <span data-ttu-id="a0216-106">各オプションは、1 つのラジオ ボタンによって表されます。ユーザーは、ラジオ ボタン グループの中から、1 つのラジオ ボタンだけを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="a0216-106">Each option is represented by one radio button, and users can only select one radio button in a radio button group.</span></span>

<span data-ttu-id="a0216-107">(ラジオ ボタンという名称は、ラジオのチャンネル プリセットのボタンから付けられました。)</span><span class="sxs-lookup"><span data-stu-id="a0216-107">(If you're curious about the name, radio buttons are named after the channel preset buttons on a radio.)</span></span>

![ラジオ ボタン](images/controls/radio-button.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="a0216-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="a0216-109">Is this the right control?</span></span>

<span data-ttu-id="a0216-110">ユーザーに 2 つ以上の相互排他的なオプションを提示するには、ラジオ ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="a0216-110">Use radio buttons to present users with two or more mutually exclusive options.</span></span>

![ラジオ ボタンのグループ](images/radiobutton_basic.png)

<span data-ttu-id="a0216-112">ユーザーが選択するすべてのオプションを表示する必要がある場合は、ラジオ ボタンを使用します。</span><span class="sxs-lookup"><span data-stu-id="a0216-112">Use radio buttons when users need to see all options to make a selection.</span></span> <span data-ttu-id="a0216-113">ラジオ ボタンはすべてのオプションを均等に強調するため、必要以上に注目される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a0216-113">Since radio buttons emphasize all options equally, they may draw more attention to the options than necessary.</span></span> <span data-ttu-id="a0216-114">ユーザーの特別な注目を引く必要がない場合は、他のコントロールを使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="a0216-114">Unless the options deserve extra attention from the user, consider using other controls.</span></span> <span data-ttu-id="a0216-115">たとえば、ほとんどの状況でほとんどのユーザーに既定のオプションが適切な場合は、代わりに[ドロップダウン リスト](lists.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="a0216-115">For example, if the default option is recommended for most users in most situations, use a [drop-down list](lists.md) instead.</span></span>

![ドロップダウン リスト](images/combo_box_collapsed.png)

<span data-ttu-id="a0216-117">2 つだけの相互排他的なオプションの場合は、1 つの[チェック ボックス](checkbox.md)または[トグル スイッチ](toggles.md)にまとめます。</span><span class="sxs-lookup"><span data-stu-id="a0216-117">If there are only two mutually exclusive options, combine them into a single [checkbox](checkbox.md) or [toggle switch](toggles.md).</span></span> <span data-ttu-id="a0216-118">たとえば、"I agree" と "I don't agree" という 2 つのラジオ ボタンではなく、"I agree" のチェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="a0216-118">For example, use a checkbox for "I agree" instead of two radio buttons for "I agree" and "I don't agree."</span></span>

![二者択一を表す 2 つの方法](images/radiobutton_vs_checkbox.png)

<span data-ttu-id="a0216-120">ユーザーが複数のオプションを選択できる場合は、[チェックボックス](checkbox.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="a0216-120">When the user can select multiple options, use a [checkbox](checkbox.md).</span></span>

![チェック ボックスでの複数のオプションの選択](images/checkbox2.png)

<span data-ttu-id="a0216-122">オプションが固定間隔の数値 (10, 20, 30) である場合は、[スライダー](slider.md) コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="a0216-122">When options are numbers that have fixed steps (10, 20, 30), use a [slider](slider.md) control.</span></span>

![スライダー コントロール](images/controls/slider.png)

<span data-ttu-id="a0216-124">オプションが 8 個より多い場合は、[ドロップダウン リスト](lists.md)、または[リスト ボックス](lists.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="a0216-124">If there are more than 8 options, use a [drop-down list](lists.md) or [list box](lists.md).</span></span>

![コンボ ボックス](images/combo_box_scroll.png)

<span data-ttu-id="a0216-126">オプションがアプリの現在のコンテキストに基づいて表示される場合や、その他の方法で動的に変化する場合は、単一選択の [リスト ボックス](lists.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="a0216-126">If the available options are based on the app’s current context, or can otherwise vary dynamically, use a single-select [list box](lists.md).</span></span>

## <a name="examples"></a><span data-ttu-id="a0216-127">例</span><span class="sxs-lookup"><span data-stu-id="a0216-127">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="a0216-128">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="a0216-128">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="a0216-129"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/RadioButton">アプリを開き、RadioButton の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="a0216-129">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/RadioButton">open the app and see the RadioButton in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="a0216-130">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="a0216-130">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="a0216-131">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="a0216-131">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="a0216-132">Microsoft Edge ブラウザーでのラジオ ボタンの設定です。</span><span class="sxs-lookup"><span data-stu-id="a0216-132">Radio buttons in the Microsoft Edge browser settings.</span></span>

![Microsoft Edge ブラウザーでのラジオ ボタンの設定](images/control-examples/radio-buttons-edge.png)

## <a name="create-a-radio-button"></a><span data-ttu-id="a0216-134">ラジオ ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="a0216-134">Create a radio button</span></span>

<span data-ttu-id="a0216-135">ラジオ ボタンは、グループで動作します。</span><span class="sxs-lookup"><span data-stu-id="a0216-135">Radio buttons work in groups.</span></span> <span data-ttu-id="a0216-136">ラジオ ボタン コントロールをグループ化する 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="a0216-136">There are 2 ways you can group radio button controls:</span></span>
- <span data-ttu-id="a0216-137">同じ親コンテナー内に追加します。</span><span class="sxs-lookup"><span data-stu-id="a0216-137">Put them inside the same parent container.</span></span>
- <span data-ttu-id="a0216-138">各ラジオ ボタンの [GroupName](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.RadioButton.GroupName) プロパティを同じ値に設定します。</span><span class="sxs-lookup"><span data-stu-id="a0216-138">Set the [GroupName](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.RadioButton.GroupName) property on each radio button to the same value.</span></span>

<span data-ttu-id="a0216-139">この例では、スタック パネルを同じにすることでラジオ ボタンの最初のグループが暗黙的にグループ化されます。</span><span class="sxs-lookup"><span data-stu-id="a0216-139">In this example, the first group of radio buttons is implicitly grouped by being in the same stack panel.</span></span> <span data-ttu-id="a0216-140">2 つ目のグループは、2 つのスタック パネルの間で分割されているので、GroupName で明示的にグループ化されます。</span><span class="sxs-lookup"><span data-stu-id="a0216-140">The second group is divided between 2 stack panels, so they're explicitly grouped by GroupName.</span></span>

```xaml
<StackPanel>
    <StackPanel>
        <TextBlock Text="Background" Style="{ThemeResource BaseTextBlockStyle}"/>
        <StackPanel Orientation="Horizontal">
            <RadioButton Content="Green" Tag="Green" Checked="BGRadioButton_Checked"/>
            <RadioButton Content="Yellow" Tag="Yellow" Checked="BGRadioButton_Checked"/>
            <RadioButton Content="Blue" Tag="Blue" Checked="BGRadioButton_Checked"/>
            <RadioButton Content="White" Tag="White" Checked="BGRadioButton_Checked" IsChecked="True"/>
        </StackPanel>
    </StackPanel>
    <StackPanel>
        <TextBlock Text="BorderBrush" Style="{ThemeResource BaseTextBlockStyle}"/>
        <StackPanel Orientation="Horizontal">
            <StackPanel>
                <RadioButton Content="Green" GroupName="BorderBrush" Tag="Green" Checked="BorderRadioButton_Checked"/>
                <RadioButton Content="Yellow" GroupName="BorderBrush" Tag="Yellow" Checked="BorderRadioButton_Checked" IsChecked="True"/>
            </StackPanel>
            <StackPanel>
                <RadioButton Content="Blue" GroupName="BorderBrush" Tag="Blue" Checked="BorderRadioButton_Checked"/>
                <RadioButton Content="White" GroupName="BorderBrush" Tag="White"  Checked="BorderRadioButton_Checked"/>
            </StackPanel>
        </StackPanel>
    </StackPanel>
    <Border x:Name="BorderExample1" BorderThickness="10" BorderBrush="#FFFFD700" Background="#FFFFFFFF" Height="50" Margin="0,10,0,10"/>
</StackPanel>
```

```csharp
private void BGRadioButton_Checked(object sender, RoutedEventArgs e)
{
    RadioButton rb = sender as RadioButton;

    if (rb != null && BorderExample1 != null)
    {
        string colorName = rb.Tag.ToString();
        switch (colorName)
        {
            case "Yellow":
                BorderExample1.Background = new SolidColorBrush(Colors.Yellow);
                break;
            case "Green":
                BorderExample1.Background = new SolidColorBrush(Colors.Green);
                break;
            case "Blue":
                BorderExample1.Background = new SolidColorBrush(Colors.Blue);
                break;
            case "White":
                BorderExample1.Background = new SolidColorBrush(Colors.White);
                break;
        }
    }
}

private void BorderRadioButton_Checked(object sender, RoutedEventArgs e)
{
    RadioButton rb = sender as RadioButton;

    if (rb != null && BorderExample1 != null)
    {
        string colorName = rb.Tag.ToString();
        switch (colorName)
        {
            case "Yellow":
                BorderExample1.BorderBrush = new SolidColorBrush(Colors.Gold);
                break;
            case "Green":
                BorderExample1.BorderBrush = new SolidColorBrush(Colors.DarkGreen);
                break;
            case "Blue":
                BorderExample1.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
                break;
            case "White":
                BorderExample1.BorderBrush = new SolidColorBrush(Colors.White);
                break;
        }
    }
}
```

<span data-ttu-id="a0216-141">ラジオ ボタンのグループは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="a0216-141">The radio button groups look like this.</span></span>

![ラジオ ボタンの 2 つのグループ](images/radio-button-groups.png)

<span data-ttu-id="a0216-143">ラジオ ボタンには*選択*または*クリア*の 2 つの状態があります。</span><span class="sxs-lookup"><span data-stu-id="a0216-143">A radio button has two states: *selected* or *cleared*.</span></span> <span data-ttu-id="a0216-144">ラジオ ボタンを選択すると、[IsChecked](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.IsChecked) プロパティは **true** になります。</span><span class="sxs-lookup"><span data-stu-id="a0216-144">When a radio button is selected, its [IsChecked](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.IsChecked) property is **true**.</span></span> <span data-ttu-id="a0216-145">ラジオ ボタンがクリアされると、**IsChecked** プロパティは **false** になります。</span><span class="sxs-lookup"><span data-stu-id="a0216-145">When a radio button is cleared, its **IsChecked** property is **false**.</span></span> <span data-ttu-id="a0216-146">同じグループ内の別のラジオ ボタンをクリックするとラジオ ボタンをクリアにできますが、ボタンをもう一度クリックしてもクリアにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="a0216-146">A radio button can be cleared by clicking another radio button in the same group, but it cannot be cleared by clicking it again.</span></span> <span data-ttu-id="a0216-147">ただし、プログラムで IsChecked プロパティを **false** に設定してラジオ ボタンをクリアにすることができます。</span><span class="sxs-lookup"><span data-stu-id="a0216-147">However, you can clear a radio button programmatically by setting its IsChecked property to **false**.</span></span> <span data-ttu-id="a0216-148">**IsChecked** プロパティの**値**を取得することで、**IsChecked** プロパティとブール値を実際に比較することができます。</span><span class="sxs-lookup"><span data-stu-id="a0216-148">You can actually compare the **IsChecked** property with a bool by getting the **Value** of the **IsChecked** property</span></span>

## <a name="recommendations"></a><span data-ttu-id="a0216-149">推奨事項</span><span class="sxs-lookup"><span data-stu-id="a0216-149">Recommendations</span></span>

-   <span data-ttu-id="a0216-150">一連のラジオ ボタンの用途と現在の状態が明確に表示されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a0216-150">Make sure the purpose and current state of a set of radio buttons is clear.</span></span>
-   <span data-ttu-id="a0216-151">ラジオ ボタンのテキスト コンテンツは、1 行に収まるように作成します。</span><span class="sxs-lookup"><span data-stu-id="a0216-151">Limit the radio button’s text content to a single line.</span></span>
-   <span data-ttu-id="a0216-152">テキスト コンテンツが動的な場合、ボタンのサイズがどのように変わり、周囲の視覚効果にどのような影響が生じるかを検討してください。</span><span class="sxs-lookup"><span data-stu-id="a0216-152">If the text content is dynamic, consider how the button will resize and what will happen to visuals around it.</span></span>
-   <span data-ttu-id="a0216-153">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="a0216-153">Use the default font unless your brand guidelines tell you to use another.</span></span>
-   <span data-ttu-id="a0216-154">2 つのラジオ ボタン グループを並べて配置しないようにします。</span><span class="sxs-lookup"><span data-stu-id="a0216-154">Don't put two radio button groups side by side.</span></span> <span data-ttu-id="a0216-155">2 つのラジオ ボタン グループが並んでいると、どのボタンがどのグループに属しているかがわかりにくくなります。</span><span class="sxs-lookup"><span data-stu-id="a0216-155">When two radio button groups are right next to each other, it's difficult to determine which buttons belong to which group.</span></span>

## <a name="additional-usage-guidance"></a><span data-ttu-id="a0216-156">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="a0216-156">Additional usage guidance</span></span>

<span data-ttu-id="a0216-157">この図は、適切な位置と間隔で配置したラジオ ボタンを示しています。</span><span class="sxs-lookup"><span data-stu-id="a0216-157">This illustration shows the proper way to position and space radio buttons.</span></span>

![一連のラジオ ボタン](images/radiobutton-layout.png)

![ラジオ ボタンの間隔ガイドライン](images/radiobutton-redlines.png)

## <a name="related-topics"></a><span data-ttu-id="a0216-160">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a0216-160">Related topics</span></span>

**<span data-ttu-id="a0216-161">設計者向け</span><span class="sxs-lookup"><span data-stu-id="a0216-161">For designers</span></span>**
- [<span data-ttu-id="a0216-162">ボタン</span><span class="sxs-lookup"><span data-stu-id="a0216-162">Buttons</span></span>](buttons.md)
- [<span data-ttu-id="a0216-163">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="a0216-163">Toggle switches</span></span>](toggles.md)
- [<span data-ttu-id="a0216-164">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="a0216-164">Checkboxes</span></span>](checkbox.md)
- [<span data-ttu-id="a0216-165">リストとコンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="a0216-165">Lists and combo boxes</span></span>](lists.md)
- [<span data-ttu-id="a0216-166">スライダー</span><span class="sxs-lookup"><span data-stu-id="a0216-166">Sliders</span></span>](slider.md)

**<span data-ttu-id="a0216-167">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="a0216-167">For developers (XAML)</span></span>**
- [<span data-ttu-id="a0216-168">RadioButton クラス</span><span class="sxs-lookup"><span data-stu-id="a0216-168">RadioButton class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.radiobutton)
