---
author: Jwmsft
Description: "ラジオ ボタンでは、ユーザーは 2 つ以上の選択肢から 1 つのオプションを選ぶことができます。"
title: "ラジオ ボタンのガイドライン"
ms.assetid: 41E3F928-AA55-42A2-9281-EC3907C4F898
label: Radio buttons
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.openlocfilehash: 370c5266277ff442f26c9aeb951d869ec70b31c5
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="radio-buttons"></a><span data-ttu-id="439b0-104">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="439b0-104">Radio buttons</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="439b0-105">ラジオ ボタンでは、ユーザーは 2 つ以上の選択肢から 1 つのオプションを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="439b0-105">Radio buttons let users select one option from two or more choices.</span></span> <span data-ttu-id="439b0-106">各オプションは、1 つのラジオ ボタンによって表されます。ユーザーは、ラジオ ボタン グループの中から、1 つのラジオ ボタンだけを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="439b0-106">Each option is represented by one radio button; a user can select only one radio button in a radio button group.</span></span>

> <span data-ttu-id="439b0-107">**重要な API**: [RadioButton クラス](https://msdn.microsoft.com/library/windows/apps/br227544)、[Checked イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.checked.aspx)、[IsChecked プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx)</span><span class="sxs-lookup"><span data-stu-id="439b0-107">**Important APIs**: [RadioButton class](https://msdn.microsoft.com/library/windows/apps/br227544), [Checked event](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.checked.aspx), [IsChecked property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx)</span></span>

<span data-ttu-id="439b0-108">ラジオ ボタンという名称は、ラジオのチャンネル プリセットのボタンから付けられました。</span><span class="sxs-lookup"><span data-stu-id="439b0-108">(If you're curious about the name, radio buttons are named for the channel preset buttons on a radio.)</span></span>

![ラジオ ボタン](images/controls/radio-button.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="439b0-110">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="439b0-110">Is this the right control?</span></span>

<span data-ttu-id="439b0-111">ユーザーに 2 つ以上の相互排他的なオプションを提示するには、次のようにラジオ ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-111">Use radio buttons to present users with two or more mutually exclusive options, as here.</span></span>

![ラジオ ボタンのグループ](images/radiobutton_basic.png)

<span data-ttu-id="439b0-113">ラジオ ボタンはわかりやすく、アプリで重要なオプションを目立つように表示します。</span><span class="sxs-lookup"><span data-stu-id="439b0-113">Radio buttons add clarity and weight to very important options in your app.</span></span> <span data-ttu-id="439b0-114">ラジオ ボタンは、広い画面領域を使うに値する重要なオプションを表示する場合であって、選択肢が明確なためにわかりやすいオプション表示が必要な場合に使用してます。</span><span class="sxs-lookup"><span data-stu-id="439b0-114">Use radio buttons when the options being presented are important enough to command more screen space and where the clarity of the choice demands very explicit options.</span></span>

<span data-ttu-id="439b0-115">ラジオ ボタンはすべてのオプションを均等に強調するため、必要以上に注目される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="439b0-115">Radio buttons emphasize all options equally, and that may draw more attention to the options than necessary.</span></span> <span data-ttu-id="439b0-116">ユーザーの特別な注目を引く必要がない場合は、他のコントロールを使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="439b0-116">Consider using other controls, unless the options deserve extra attention from the user.</span></span> <span data-ttu-id="439b0-117">たとえば、ほとんどの状況でほとんどのユーザーに既定のオプションが適切な場合は、代わりに[ドロップダウン リスト](lists.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-117">For example, if the default option is recommended for most users in most situations, use a [drop-down list](lists.md) instead.</span></span>

<span data-ttu-id="439b0-118">2 つだけの相互排他的なオプションの場合は、1 つの[チェック ボックス](checkbox.md)または[トグル スイッチ](toggles.md)にまとめます。</span><span class="sxs-lookup"><span data-stu-id="439b0-118">If there are only two mutually exclusive options, combine them into a single [checkbox](checkbox.md) or [toggle switch](toggles.md).</span></span> <span data-ttu-id="439b0-119">たとえば、"I agree" と "I don't agree" という 2 つのラジオ ボタンではなく、"I agree" のチェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-119">For example, use a checkbox for "I agree" instead of two radio buttons for "I agree" and "I don't agree."</span></span>

![二者択一を表す 2 つの方法](images/radiobutton_vs_checkbox.png)

<span data-ttu-id="439b0-121">ユーザーが複数のオプションを選択できる場合は、代わりに[チェック ボックス](checkbox.md)または[リスト ボックス](lists.md) コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-121">When the user can select multiple options, use a [checkbox](checkbox.md) or [list box](lists.md) control instead.</span></span>

![チェック ボックスでの複数のオプションの選択](images/checkbox2.png)

<span data-ttu-id="439b0-123">オプションが 10、20、30 のように固定間隔の数値である場合は、ラジオ ボタンを使いません。</span><span class="sxs-lookup"><span data-stu-id="439b0-123">Don't use radio buttons when the options are numbers that have fixed steps, like 10, 20, 30.</span></span> <span data-ttu-id="439b0-124">代わりに、[スライダー](slider.md) コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-124">Use a [slider](slider.md) control instead.</span></span>

<span data-ttu-id="439b0-125">オプションが 8 個より多い場合は、[ドロップダウン リスト](lists.md)、単一選択の[リスト ボックス](lists.md)、または[リスト ボックス](lists.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-125">If there are more than 8 options, use a [drop-down list](lists.md), a single-select [list box](lists.md), or a [list box](lists.md) instead.</span></span>

<span data-ttu-id="439b0-126">オプションがアプリの現在のコンテキストに基づいて表示される場合や、その他の方法で動的に変化する場合は、単一選択の [リスト ボックス](lists.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-126">If the available options are based on the app’s current context, or can otherwise vary dynamically, use a single-select [list box](lists.md) instead.</span></span>

## <a name="example"></a><span data-ttu-id="439b0-127">例</span><span class="sxs-lookup"><span data-stu-id="439b0-127">Example</span></span>
<span data-ttu-id="439b0-128">Microsoft Edge ブラウザーでのラジオ ボタンの設定です。</span><span class="sxs-lookup"><span data-stu-id="439b0-128">Radio buttons in the Microsoft Edge browser settings.</span></span>

![Microsoft Edge ブラウザーでのラジオ ボタンの設定](images/control-examples/radio-buttons-edge.png)

## <a name="create-a-radio-button"></a><span data-ttu-id="439b0-130">ラジオ ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="439b0-130">Create a radio button</span></span>

<span data-ttu-id="439b0-131">ラジオ ボタンは、グループで動作します。</span><span class="sxs-lookup"><span data-stu-id="439b0-131">Radio buttons work in groups.</span></span> <span data-ttu-id="439b0-132">ラジオ ボタン コントロールをグループ化する 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="439b0-132">There are 2 ways you can group radio button controls:</span></span>
- <span data-ttu-id="439b0-133">同じ親コンテナー内に追加します。</span><span class="sxs-lookup"><span data-stu-id="439b0-133">Put them inside the same parent container.</span></span>
- <span data-ttu-id="439b0-134">各ラジオ ボタンの [GroupName](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.radiobutton.groupname.aspx) プロパティを同じ値に設定します。</span><span class="sxs-lookup"><span data-stu-id="439b0-134">Set the [GroupName](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.radiobutton.groupname.aspx) property on each radio button to the same value.</span></span>

> <span data-ttu-id="439b0-135">**注**&nbsp;&nbsp;キーボード経由でアクセスした場合、ラジオ ボタンのグループは、1 つのコントロールのように動作します。</span><span class="sxs-lookup"><span data-stu-id="439b0-135">**Note**&nbsp;&nbsp;A group of radio buttons behaves like a single control when accessed via the keyboard.</span></span> <span data-ttu-id="439b0-136">Tab キーを使うと選んだオプションにのみアクセスできますが、方向キーを使ってグループを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="439b0-136">Only the selected choice is accessible using the Tab key but users can cycle through the group using arrow keys.</span></span>

<span data-ttu-id="439b0-137">この例では、スタック パネルを同じにすることでラジオ ボタンの最初のグループが暗黙的にグループ化されます。</span><span class="sxs-lookup"><span data-stu-id="439b0-137">In this example, the first group of radio buttons is implicitly grouped by being in the same stack panel.</span></span> <span data-ttu-id="439b0-138">2 つ目のグループは、2 つのスタック パネルの間で分割されているので、GroupName で明示的にグループ化されます。</span><span class="sxs-lookup"><span data-stu-id="439b0-138">The second group is divided between 2 stack panels, so they're explicitly grouped by GroupName.</span></span>

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

<span data-ttu-id="439b0-139">ラジオ ボタンのグループは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="439b0-139">The radio button groups look like this.</span></span>

![ラジオ ボタンの 2 つのグループ](images/radio-button-groups.png)

<span data-ttu-id="439b0-141">ラジオ ボタンには*選択*または*クリア*の 2 つの状態があります。</span><span class="sxs-lookup"><span data-stu-id="439b0-141">A radio button has two states: *selected* or *cleared*.</span></span> <span data-ttu-id="439b0-142">ラジオ ボタンを選択すると、[IsChecked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx) プロパティは **true** になります。</span><span class="sxs-lookup"><span data-stu-id="439b0-142">When a radio button is selected, its [IsChecked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx) property is **true**.</span></span> <span data-ttu-id="439b0-143">ラジオ ボタンがクリアされると、**IsChecked** プロパティは **false** になります。</span><span class="sxs-lookup"><span data-stu-id="439b0-143">When a radio button is cleared, its **IsChecked** property is **false**.</span></span> <span data-ttu-id="439b0-144">同じグループ内の別のラジオ ボタンをクリックするとラジオ ボタンをクリアにできますが、ボタンをもう一度クリックしてもクリアにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="439b0-144">A radio button can be cleared by clicking another radio button in the same group, but it cannot be cleared by clicking it again.</span></span> <span data-ttu-id="439b0-145">ただし、プログラムで IsChecked プロパティを **false** に設定してラジオ ボタンをクリアにすることができます。</span><span class="sxs-lookup"><span data-stu-id="439b0-145">However, you can clear a radio button programmatically by setting its IsChecked property to **false**.</span></span>

## <a name="recommendations"></a><span data-ttu-id="439b0-146">推奨事項</span><span class="sxs-lookup"><span data-stu-id="439b0-146">Recommendations</span></span>

-   <span data-ttu-id="439b0-147">一連のラジオ ボタンの用途と現在の状態が明確に表示されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="439b0-147">Make sure that the purpose and current state of a set of radio buttons is clear.</span></span>
-   <span data-ttu-id="439b0-148">ユーザーがラジオ ボタンをタップしたときには、必ず視覚的なフィードバックを返します。</span><span class="sxs-lookup"><span data-stu-id="439b0-148">Always give visual feedback when the user taps a radio button.</span></span>
-   <span data-ttu-id="439b0-149">ユーザーのラジオ ボタンの操作に合わせて、視覚的なフィードバックを返します。</span><span class="sxs-lookup"><span data-stu-id="439b0-149">Give visual feedback as the user interacts with radio buttons.</span></span> <span data-ttu-id="439b0-150">ラジオ ボタンの状態には、たとえば、標準、押された状態、オンの状態、オフの状態があります。</span><span class="sxs-lookup"><span data-stu-id="439b0-150">Normal, pressed, checked, and disabled are examples of radio button states.</span></span> <span data-ttu-id="439b0-151">ユーザーは、ラジオ ボタンをタップして関連のオプションをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="439b0-151">A user taps a radio button to activate the related option.</span></span> <span data-ttu-id="439b0-152">アクティブなオプションをもう一度タップしても非アクティブにはなりませんが、別のオプションをタップすると、そのオプションにアクティブ化の状態が移ります。</span><span class="sxs-lookup"><span data-stu-id="439b0-152">Tapping an activated option doesn’t deactivate it, but tapping another option transfers activation to that option.</span></span>
-   <span data-ttu-id="439b0-153">タッチに対するフィードバック用とオンの状態用に視覚効果やアニメーションを予約します。オフの状態のラジオ ボタン コントロールは、使われていない、または非アクティブなコントロールとして表示します (無効なコントロールとして表示しないでください)。</span><span class="sxs-lookup"><span data-stu-id="439b0-153">Reserve visual effects and animations for touch feedback, and for the checked state; in the unchecked state, radio button controls should appear unused or inactive (but not disabled).</span></span>
-   <span data-ttu-id="439b0-154">ラジオ ボタンのテキスト コンテンツは、1 行に収まるように作成します。</span><span class="sxs-lookup"><span data-stu-id="439b0-154">Limit the radio button’s text content to a single line.</span></span> <span data-ttu-id="439b0-155">ラジオ ボタンの視覚効果をカスタマイズして、メインのテキスト行の下に小さいフォント サイズでオプションの説明を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="439b0-155">You can customize the radio button’s visuals to display a description of the option in smaller font size below the main line of text.</span></span>
-   <span data-ttu-id="439b0-156">テキスト コンテンツが動的な場合、ボタンのサイズがどのように変わり、周囲の視覚効果にどのような影響が生じるかを検討してください。</span><span class="sxs-lookup"><span data-stu-id="439b0-156">If the text content is dynamic, consider how the button will resize and what will happen to visuals around it.</span></span>
-   <span data-ttu-id="439b0-157">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-157">Use the default font unless your brand guidelines tell you to use another.</span></span>
-   <span data-ttu-id="439b0-158">ラベルをタップするとラジオ ボタンが選択されるように、ラベル要素でラジオ ボタンを囲みます。</span><span class="sxs-lookup"><span data-stu-id="439b0-158">Enclose the radio button in a label element so that tapping the label selects the radio button.</span></span>
-   <span data-ttu-id="439b0-159">ラベル テキストは、ラジオ ボタン コントロールの前や上ではなく、後に配置します。</span><span class="sxs-lookup"><span data-stu-id="439b0-159">Place the label text after the radio button control, not before or above it.</span></span>
-   <span data-ttu-id="439b0-160">ラジオ ボタンをカスタマイズすることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="439b0-160">Consider customizing your radio buttons.</span></span> <span data-ttu-id="439b0-161">既定のラジオ ボタンは、2 つの同心円 (内側の円は塗りつぶされ、オンの場合に表示。外側の円はストロークのみ) とテキスト コンテンツで構成されています。</span><span class="sxs-lookup"><span data-stu-id="439b0-161">By default, a radio button consists of two concentric circles—the inner one filled (and shown when the radio button is checked), the outer one stroked—and some text content.</span></span> <span data-ttu-id="439b0-162">しかし、工夫しだいで使いやすさが向上します。</span><span class="sxs-lookup"><span data-stu-id="439b0-162">But we encourage you to be creative.</span></span> <span data-ttu-id="439b0-163">アプリのコンテンツを直接操作できれば、ユーザーが理解しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="439b0-163">Users are comfortable interacting directly with the content of an app.</span></span> <span data-ttu-id="439b0-164">たとえば、グラフィックやさりげないテキストのトグル ボタンを使って、提供する実際のコンテンツを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="439b0-164">So you may choose to show the actual content on offer, whether that’s presented with graphics or as subtle textual toggle buttons.</span></span>
-   <span data-ttu-id="439b0-165">ラジオ ボタン グループには、8 個以上のオプションを含めないでください。</span><span class="sxs-lookup"><span data-stu-id="439b0-165">Don't put more than 8 options in a radio button group.</span></span> <span data-ttu-id="439b0-166">それより多くのオプションを提示する必要がある場合は、代わりに [ドロップダウン リスト](lists.md)、[リスト ボックス](lists.md)、[リスト ビュー](lists.md) などを使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-166">When you need to present more options, use a [drop-down list](lists.md), [list box](lists.md), or a [list view](lists.md) instead.</span></span>
-   <span data-ttu-id="439b0-167">2 つのラジオ ボタン グループを並べて配置しないようにします。</span><span class="sxs-lookup"><span data-stu-id="439b0-167">Don't put two radio button groups next to each other.</span></span> <span data-ttu-id="439b0-168">
2 つのラジオ ボタン グループが並んでいると、どのボタンがどのグループに属しているかがわかりにくくなります。</span><span class="sxs-lookup"><span data-stu-id="439b0-168">When two radio button groups are right next to each other, it's difficult to determine which buttons belong to which group.</span></span> <span data-ttu-id="439b0-169">グループを分けるには、グループ ラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="439b0-169">Use group labels to separate them.</span></span>

## <a name="additional-usage-guidance"></a><span data-ttu-id="439b0-170">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="439b0-170">Additional usage guidance</span></span>

<span data-ttu-id="439b0-171">この図は、適切な位置と間隔で配置したラジオ ボタンを示しています。</span><span class="sxs-lookup"><span data-stu-id="439b0-171">This illustration shows the proper way to position and space radio buttons.</span></span>

![一連のラジオ ボタン](images/radiobutton_layout1.png)
## <a name="related-topics"></a><span data-ttu-id="439b0-173">関連トピック</span><span class="sxs-lookup"><span data-stu-id="439b0-173">Related topics</span></span>

**<span data-ttu-id="439b0-174">デザイナー向け</span><span class="sxs-lookup"><span data-stu-id="439b0-174">For designers</span></span>**
- [<span data-ttu-id="439b0-175">ボタンのガイドライン</span><span class="sxs-lookup"><span data-stu-id="439b0-175">Guidelines for buttons</span></span>](buttons.md)
- [<span data-ttu-id="439b0-176">トグル スイッチのガイドライン</span><span class="sxs-lookup"><span data-stu-id="439b0-176">Guidelines for toggle switches</span></span>](toggles.md)
- [<span data-ttu-id="439b0-177">チェック ボックスのガイドライン</span><span class="sxs-lookup"><span data-stu-id="439b0-177">Guidelines for checkboxes</span></span>](checkbox.md)
- [<span data-ttu-id="439b0-178">ドロップダウン リストのガイドライン</span><span class="sxs-lookup"><span data-stu-id="439b0-178">Guidelines for drop-down lists</span></span>](lists.md)
- [<span data-ttu-id="439b0-179">リスト ビュー コントロールとグリッド ビュー コントロールのガイドライン</span><span class="sxs-lookup"><span data-stu-id="439b0-179">Guidelines for list view and grid view controls</span></span>](lists.md)
- [<span data-ttu-id="439b0-180">スライダーのガイドライン</span><span class="sxs-lookup"><span data-stu-id="439b0-180">Guidelines for sliders</span></span>](slider.md)
- [<span data-ttu-id="439b0-181">選択コントロールのガイドライン</span><span class="sxs-lookup"><span data-stu-id="439b0-181">Guidelines for the select control</span></span>](lists.md)


**<span data-ttu-id="439b0-182">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="439b0-182">For developers (XAML)</span></span>**
- [<span data-ttu-id="439b0-183">Windows.UI.Xaml.Controls RadioButton クラス</span><span class="sxs-lookup"><span data-stu-id="439b0-183">Windows.UI.Xaml.Controls RadioButton class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227544)
