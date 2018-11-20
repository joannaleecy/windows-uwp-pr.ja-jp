---
author: Jwmsft
Description: A text entry box that provides suggestions as the user types.
title: コンボ ボックス (ドロップダウン リスト)
label: Combo box
template: detail.hbs
ms.author: jimwalk
ms.date: 10/02/2018
ms.topic: article
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: ''
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 0c34dda3039a9b6a66428266e37f81b41695fbc0
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7287203"
---
# <a name="combo-box"></a><span data-ttu-id="33fba-103">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="33fba-103">Combo box</span></span>

<span data-ttu-id="33fba-104">ユーザーが選択できる項目の一覧を表示するのにには、コンボ ボックス (ドロップダウン リストとも呼ばれます) を使用します。</span><span class="sxs-lookup"><span data-stu-id="33fba-104">Use a combo box (also known as a drop-down list) to present a list of items that a user can select from.</span></span> <span data-ttu-id="33fba-105">コンボ ボックスでは、コンパクトな状態で開始し、展開を選択できる項目の一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="33fba-105">A combo box starts in a compact state and expands to show a list of selectable items.</span></span>

<span data-ttu-id="33fba-106">コンボ ボックスを閉じると、現在の選択範囲を表示するか選択された項目がない場合は空です。</span><span class="sxs-lookup"><span data-stu-id="33fba-106">When the combo box is closed, it either displays the current selection or is empty if there is no selected item.</span></span> <span data-ttu-id="33fba-107">ユーザーがコンボ ボックスを展開するときに、選択可能な項目の一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="33fba-107">When the user expands the combo box, it displays the list of selectable items.</span></span>

> <span data-ttu-id="33fba-108">**重要な Api**: [ComboBox クラス](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [IsEditable プロパティ](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)、 [Text プロパティ](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [TextSubmitted イベント](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)</span><span class="sxs-lookup"><span data-stu-id="33fba-108">**Important APIs**: [ComboBox class](/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [IsEditable property](/uwp/api/windows.ui.xaml.controls.combobox.iseditable), [Text property](/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [TextSubmitted event](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)</span></span>

<span data-ttu-id="33fba-109">コンボ ボックス、ヘッダーを含むコンパクトな状態にします。</span><span class="sxs-lookup"><span data-stu-id="33fba-109">A combo box in its compact state with a header.</span></span>

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="33fba-111">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="33fba-111">Is this the right control?</span></span>

- <span data-ttu-id="33fba-112">1 行のテキストで十分に表すことができる項目のセットから、ユーザーが単一の値を選ぶことができるようにするには、ドロップダウン リストを使います。</span><span class="sxs-lookup"><span data-stu-id="33fba-112">Use a drop-down list to let users select a single value from a set of items that can be adequately represented with single lines of text.</span></span>
- <span data-ttu-id="33fba-113">複数のテキスト行や画像が含まれる項目を表示するには、コンボ ボックスではなくリスト ビューまたはグリッド ビューを使います。</span><span class="sxs-lookup"><span data-stu-id="33fba-113">Use a list or grid view instead of a combo box to display items that contain multiple lines of text or images.</span></span>
- <span data-ttu-id="33fba-114">項目が 5 個より少ない場合は、[ラジオ ボタン](radio-button.md) (1 つの項目だけを選ぶことができる場合)、または[チェック ボックス](checkbox.md) (複数の項目を選ぶことができる場合) の使用を検討します。</span><span class="sxs-lookup"><span data-stu-id="33fba-114">When there are fewer than five items, consider using [radio buttons](radio-button.md) (if only one item can be selected) or [check boxes](checkbox.md) (if multiple items can be selected).</span></span>
- <span data-ttu-id="33fba-115">選択項目がアプリのフローにおいて二次的な重要性しか持たない場合は、コンボ ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="33fba-115">Use a combo box when the selection items are of secondary importance in the flow of your app.</span></span> <span data-ttu-id="33fba-116">多くの状況でほとんどのユーザーに対して既定のオプションが推奨されている場合、リスト ビューを使ってすべての項目を表示すると、既定以外のオプションに必要以上の注意を引いてしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33fba-116">If the default option is recommended for most users in most situations, showing all the items by using a list view might draw more attention to the options than necessary.</span></span> <span data-ttu-id="33fba-117">コンボ ボックスを使うことで、領域を節約し、無駄な情報を最小限にすることができます。</span><span class="sxs-lookup"><span data-stu-id="33fba-117">You can save space and minimize distraction by using a combo box.</span></span>

## <a name="examples"></a><span data-ttu-id="33fba-118">例</span><span class="sxs-lookup"><span data-stu-id="33fba-118">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="33fba-119">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="33fba-119">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="33fba-120"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールした場合ここをクリックして<a href="xamlcontrolsgallery:/item/ComboBox">アプリを開き、ComboBox の動作をご覧ください</a>。</span><span class="sxs-lookup"><span data-stu-id="33fba-120">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/ComboBox">open the app and see the ComboBox in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="33fba-121">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="33fba-121">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="33fba-122">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="33fba-122">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="33fba-123">コンパクトな状態のコンボ ボックスには、ヘッダーを表示できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-123">A combo box in its compact state can show a header.</span></span>

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

<span data-ttu-id="33fba-125">コンボ ボックスは、長い文字列の幅をサポートするために拡張できますが、読みづらくなるような長すぎる文字列は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="33fba-125">Although combo boxes expand to support longer string lengths, avoid excessively long strings that are difficult to read.</span></span>

![長い文字列のドロップダウン リストの例](images/combo_box_listitemstate.png)

<span data-ttu-id="33fba-127">コンボ ボックス内のコレクションが一定の長さに達すると、対応できるようにスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="33fba-127">If the collection in a combo box is long enough, a scroll bar will appear to accommodate it.</span></span> <span data-ttu-id="33fba-128">リスト内の項目は論理的にグループ化します。</span><span class="sxs-lookup"><span data-stu-id="33fba-128">Group items logically in the list.</span></span>

![ドロップダウン リストに表示されたスクロール バーの例](images/combo_box_scroll.png)

## <a name="create-a-combo-box"></a><span data-ttu-id="33fba-130">コンボ ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="33fba-130">Create a combo box</span></span>

<span data-ttu-id="33fba-131">[Items](/uwp/api/windows.ui.xaml.controls.itemscontrol.items)コレクションに直接オブジェクトを追加するか[ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティをデータ ソースにバインドすることによって、コンボ ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="33fba-131">You populate the combo box by adding objects directly to the [Items](/uwp/api/windows.ui.xaml.controls.itemscontrol.items) collection or by binding the [ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property to a data source.</span></span> <span data-ttu-id="33fba-132">[ComboBoxItem](/uwp/api/windows.ui.xaml.controls.comboboxitem)コンテナーでは、コンボ ボックスに追加された項目が改行されています。</span><span class="sxs-lookup"><span data-stu-id="33fba-132">Items added to the ComboBox are wrapped in [ComboBoxItem](/uwp/api/windows.ui.xaml.controls.comboboxitem) containers.</span></span>

<span data-ttu-id="33fba-133">XAML で追加された項目の単純なコンボ ボックスを次に示します。</span><span class="sxs-lookup"><span data-stu-id="33fba-133">Here's a simple combo box with items added in XAML.</span></span>

```xaml
<ComboBox Header="Colors" PlaceholderText="Pick a color" Width="200">
    <x:String>Blue<x:String>
    <x:String>Green<x:String>
    <x:String>Red<x:String>
    <x:String>Yellow<x:String>
</ComboBox>
```

<span data-ttu-id="33fba-134">次の例では、コンボ ボックスを FontFamily オブジェクトのコレクションにバインドを示しています。</span><span class="sxs-lookup"><span data-stu-id="33fba-134">The following example demonstrates binding a combo box to a collection of FontFamily objects.</span></span>

```xaml
<ComboBox x:Name="FontsCombo" Header="Fonts" Height="44" Width="296"
          ItemsSource="{x:Bind fonts}" DisplayMemberPath="Source"/>
```

```csharp
ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();

public MainPage()
{
    this.InitializeComponent();
    fonts.Add(new FontFamily("Arial"));
    fonts.Add(new FontFamily("Courier New"));
    fonts.Add(new FontFamily("Times New Roman"));
}
```

### <a name="item-selection"></a><span data-ttu-id="33fba-135">項目の選択</span><span class="sxs-lookup"><span data-stu-id="33fba-135">Item selection</span></span>

<span data-ttu-id="33fba-136">ListView や GridView のように ComboBox は[セレクター](/uwp/api/windows.ui.xaml.controls.primitives.selector)から派生したため、同じ標準的な方法でユーザーの選択内容を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="33fba-136">Like ListView and GridView, ComboBox is derived from [Selector](/uwp/api/windows.ui.xaml.controls.primitives.selector), so you can get the user’s selection in the same standard way.</span></span>

<span data-ttu-id="33fba-137">取得して、 [SelectedItem](/uwp/api/windows.ui.xaml.controls.primitives.selector.selecteditem)プロパティを使用して、項目の選択、コンボ ボックスを設定し、または取得するか、または[SelectedIndex](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedindex)プロパティを使用して、選択した項目のインデックスを設定できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-137">You can get or set the combo box's selected item by using the [SelectedItem](/uwp/api/windows.ui.xaml.controls.primitives.selector.selecteditem) property, and get or set the index of the selected item by using the [SelectedIndex](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedindex) property.</span></span>

<span data-ttu-id="33fba-138">選択したデータ項目の特定のプロパティの値を取得するには、 [「selectedvalue」](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvalue)プロパティを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="33fba-138">To get the value of a particular property on the selected data item, you can use the [SelectedValue](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvalue) property.</span></span> <span data-ttu-id="33fba-139">この場合から値を取得する、選択した項目でどのプロパティを指定する[SelectedValuePath](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvaluepath)を設定します。</span><span class="sxs-lookup"><span data-stu-id="33fba-139">In this case, set the [SelectedValuePath](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvaluepath) to specify which property on the selected item to get the value from.</span></span>

> [!TIP]
> <span data-ttu-id="33fba-140">SelectedItem SelectedIndex を指定したりする既定の選択を設定すると、コンボ ボックス項目のコレクションを作成する前に、プロパティが設定されている場合、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="33fba-140">If you set SelectedItem or SelectedIndex to indicate the default selection, an exception occurs if the property is set before the combo box Items collection is populated.</span></span> <span data-ttu-id="33fba-141">XAML で項目を定義する場合を除き、コンボ ボックスの Loaded イベントを処理し、SelectedItem または SelectedIndex Loaded イベント ハンドラーで設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="33fba-141">Unless you define your Items in XAML, it's best to handle the combo box Loaded event, and set SelectedItem or SelectedIndex in the Loaded event handler.</span></span>

<span data-ttu-id="33fba-142">XAML では、これらのプロパティにバインドしたり、選択内容の変更に応答する[SelectionChanged](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)イベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="33fba-142">You can bind to these properties in XAML, or handle the [SelectionChanged](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged) event to respond to selection changes.</span></span>

<span data-ttu-id="33fba-143">イベント ハンドラーのコードは[SelectionChangedEventArgs.AddedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.addeditems)プロパティから、選択した項目を取得できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-143">In the event handler code, you can get the selected item from the [SelectionChangedEventArgs.AddedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.addeditems) property.</span></span> <span data-ttu-id="33fba-144">(ある場合)、以前に選択した項目は、 [SelectionChangedEventArgs.RemovedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.removeditems)プロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-144">You can get the previously selected item (if any) from the [SelectionChangedEventArgs.RemovedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.removeditems) property.</span></span> <span data-ttu-id="33fba-145">AddedItems と RemovedItems の各のコレクションには、コンボ ボックスでは、複数選択をサポートしていないために、1 つだけの項目が含まれます。</span><span class="sxs-lookup"><span data-stu-id="33fba-145">The AddedItems and RemovedItems collections each contain only 1 item because combo box does not support multiple selection.</span></span>

<span data-ttu-id="33fba-146">この例では、選択した項目にバインドする方法と、SelectionChanged イベントを処理する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="33fba-146">This example shows how to handle the SelectionChanged event, and also how to bind to the selected item.</span></span>

```xaml
<StackPanel>
    <ComboBox x:Name="colorComboBox" Width="200"
              Header="Colors" PlaceholderText="Pick a color"
              SelectionChanged="ColorComboBox_SelectionChanged">
        <x:String>Blue</x:String>
        <x:String>Green</x:String>
        <x:String>Red</x:String>
        <x:String>Yellow</x:String>
    </ComboBox>

    <Rectangle x:Name="colorRectangle" Height="30" Width="100"
               Margin="0,8,0,0" HorizontalAlignment="Left"/>

    <TextBlock Text="{x:Bind colorComboBox.SelectedIndex, Mode=OneWay}"/>
    <TextBlock Text="{x:Bind colorComboBox.SelectedItem, Mode=OneWay}"/>
</StackPanel>
```

```csharp
private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    // Add "using Windows.UI;" for Color and Colors.
    string colorName = e.AddedItems[0].ToString();
    Color color;
    switch (colorName)
    {
        case "Yellow":
            color = Colors.Yellow;
            break;
        case "Green":
            color = Colors.Green;
            break;
        case "Blue":
            color = Colors.Blue;
            break;
        case "Red":
            color = Colors.Red;
            break;
    }
    colorRectangle.Fill = new SolidColorBrush(color);
}
```

#### <a name="selectionchanged-and-keyboard-navigation"></a><span data-ttu-id="33fba-147">SelectionChanged とキーボード ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="33fba-147">SelectionChanged and keyboard navigation</span></span>

<span data-ttu-id="33fba-148">既定では、コンボ ボックスを閉じると、ユーザーがクリックした、タップ、または項目 Enter の選択が確定する一覧に SelectionChanged イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="33fba-148">By default, the SelectionChanged event occurs when a user clicks, taps, or presses Enter on an item in the list to commit their selection, and the combo box closes.</span></span> <span data-ttu-id="33fba-149">選択範囲は、ユーザーはキーボードの方向キーで開くコンボ ボックスの一覧を移動するときに変更されません。</span><span class="sxs-lookup"><span data-stu-id="33fba-149">Selection doesn't change when the user navigates the open combo box list with the keyboard arrow keys.</span></span>

<span data-ttu-id="33fba-150">更新コンボ ボックス作成その"ライブ"(フォント選択ドロップダウン) のような方向キーで、ユーザーが一覧を開きますを移動するときに、 [SelectionChangedTrigger](/uwp/api/windows.ui.xaml.controls.combobox.selectionchangedtrigger)を[Always](/uwp/api/windows.ui.xaml.controls.comboboxselectionchangedtrigger)に設定します。</span><span class="sxs-lookup"><span data-stu-id="33fba-150">To make a combo box that "live updates" while the user is navigating the open list with the arrow keys (like a Font selection drop-down), set [SelectionChangedTrigger](/uwp/api/windows.ui.xaml.controls.combobox.selectionchangedtrigger) to [Always](/uwp/api/windows.ui.xaml.controls.comboboxselectionchangedtrigger).</span></span> <span data-ttu-id="33fba-151">これにより、開いている一覧の別の項目にフォーカスが変更されたときに発生する SelectionChanged イベントです。</span><span class="sxs-lookup"><span data-stu-id="33fba-151">This causes the SelectionChanged event to occur when focus changes to another item in the open list.</span></span>

#### <a name="selected-item-behavior-change"></a><span data-ttu-id="33fba-152">選択した項目の動作の変更</span><span class="sxs-lookup"><span data-stu-id="33fba-152">Selected item behavior change</span></span>

<span data-ttu-id="33fba-153">Windows 10、バージョン 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) で選択した項目の動作が編集可能なコンボ ボックスをサポートするために更新された後で、またはします。</span><span class="sxs-lookup"><span data-stu-id="33fba-153">In Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, the behavior of selected items is updated to support editable combo boxes.</span></span>

<span data-ttu-id="33fba-154">SDK 17763、SelectedItem プロパティの値の前に (およびそのため、「selectedvalue」と SelectedIndex)、コンボ ボックス項目のコレクション内にする必要がありました。</span><span class="sxs-lookup"><span data-stu-id="33fba-154">Prior to SDK 17763, the value of the SelectedItem property (and therefore, SelectedValue and SelectedIndex) was required to be in the combo box's Items collection.</span></span> <span data-ttu-id="33fba-155">前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`結果します。</span><span class="sxs-lookup"><span data-stu-id="33fba-155">Using the previous example, setting `colorComboBox.SelectedItem = "Pink"` results in:</span></span>

- <span data-ttu-id="33fba-156">SelectedItem = null</span><span class="sxs-lookup"><span data-stu-id="33fba-156">SelectedItem = null</span></span>
- <span data-ttu-id="33fba-157">「Selectedvalue」= null</span><span class="sxs-lookup"><span data-stu-id="33fba-157">SelectedValue = null</span></span>
- <span data-ttu-id="33fba-158">SelectedIndex は-1</span><span class="sxs-lookup"><span data-stu-id="33fba-158">SelectedIndex = -1</span></span>

<span data-ttu-id="33fba-159">Sdk 17763 以降、SelectedItem プロパティの値 (つまり、「selectedvalue」と SelectedIndex) コンボ ボックスの項目のコレクション内にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="33fba-159">In SDK 17763 and later, the value of the SelectedItem property (and therefore, SelectedValue and SelectedIndex) is not required to be in the combo box's Items collection.</span></span> <span data-ttu-id="33fba-160">前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`結果します。</span><span class="sxs-lookup"><span data-stu-id="33fba-160">Using the previous example, setting `colorComboBox.SelectedItem = "Pink"` results in:</span></span>

- <span data-ttu-id="33fba-161">SelectedItem ピンク =</span><span class="sxs-lookup"><span data-stu-id="33fba-161">SelectedItem = Pink</span></span>
- <span data-ttu-id="33fba-162">「Selectedvalue」ピンク =</span><span class="sxs-lookup"><span data-stu-id="33fba-162">SelectedValue = Pink</span></span>
- <span data-ttu-id="33fba-163">SelectedIndex は-1</span><span class="sxs-lookup"><span data-stu-id="33fba-163">SelectedIndex = -1</span></span>

### <a name="text-search"></a><span data-ttu-id="33fba-164">テキスト検索</span><span class="sxs-lookup"><span data-stu-id="33fba-164">Text Search</span></span>

<span data-ttu-id="33fba-165">コンボ ボックスでは、コレクション内を自動的に検索できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-165">Combo boxes automatically support search within their collections.</span></span> <span data-ttu-id="33fba-166">開かれた状態または閉じた状態のコンボ ボックスにフォーカスがあるときに、物理的なキーボードで文字を入力すると、ユーザーが入力した文字列に一致する候補がビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="33fba-166">As users type characters on a physical keyboard while focused on an open or closed combo box, candidates matching the user's string are brought into view.</span></span> <span data-ttu-id="33fba-167">この機能は、長いリストを操作するときに特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="33fba-167">This functionality is especially helpful when navigating a long list.</span></span> <span data-ttu-id="33fba-168">たとえば、州のリストが含まれているドロップダウンを操作するときに、ユーザーは"washington"ビューにすばやく選ぶを"w"キーを押すことができます。</span><span class="sxs-lookup"><span data-stu-id="33fba-168">For example, when interacting with a drop-down containing a list of states, users can press the "w" key to bring "Washington" into view for quick selection.</span></span> <span data-ttu-id="33fba-169">テキスト検索小文字は区別されません。</span><span class="sxs-lookup"><span data-stu-id="33fba-169">The text search is not case-sensitive.</span></span>

<span data-ttu-id="33fba-170">**False**をこの機能を無効にするには、 [IsTextSearchEnabled](/uwp/api/windows.ui.xaml.controls.combobox.istextsearchenabled)プロパティを設定できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-170">You can set the [IsTextSearchEnabled](/uwp/api/windows.ui.xaml.controls.combobox.istextsearchenabled) property to **false** to disable this functionality.</span></span>

## <a name="make-a-combo-box-editable"></a><span data-ttu-id="33fba-171">コンボ ボックスを編集します。</span><span class="sxs-lookup"><span data-stu-id="33fba-171">Make a combo box editable</span></span>

> [!IMPORTANT]
> <span data-ttu-id="33fba-172">この機能では Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="33fba-172">This feature requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later.</span></span>

<span data-ttu-id="33fba-173">コンボ ボックスで、ユーザーは既定では、オプションの事前に定義された一覧から選択します。</span><span class="sxs-lookup"><span data-stu-id="33fba-173">By default, a combo box lets the user select from a pre-defined list of options.</span></span> <span data-ttu-id="33fba-174">ただし、これには、有効な値のサブセットのみが一覧に含まれて、ユーザーに記載されていないその他の値を入力できる必要がありますである場合があります。</span><span class="sxs-lookup"><span data-stu-id="33fba-174">However, there are cases where the list contains only a subset of valid values, and the user should be able to enter other values that aren't listed.</span></span> <span data-ttu-id="33fba-175">これをサポートするには、ことができますコンボ ボックス編集可能です。</span><span class="sxs-lookup"><span data-stu-id="33fba-175">To support this, you can make the combo box editable.</span></span>

<span data-ttu-id="33fba-176">コンボ ボックスを編集するためには、 [IsEditable](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)プロパティを**true**に設定します。</span><span class="sxs-lookup"><span data-stu-id="33fba-176">To make a combo box editable, set the [IsEditable](/uwp/api/windows.ui.xaml.controls.combobox.iseditable) property to **true**.</span></span> <span data-ttu-id="33fba-177">次に、ユーザーが入力した値と連携する[TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="33fba-177">Then, handle the [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox) event to work with the value entered by the user.</span></span>

<span data-ttu-id="33fba-178">既定では、ユーザーがカスタム テキストをコミットすると、SelectedItem 値が更新されます。</span><span class="sxs-lookup"><span data-stu-id="33fba-178">By default, the SelectedItem value is updated when the user commits custom text.</span></span> <span data-ttu-id="33fba-179">この動作を上書きするには、 **Handled**を**true** TextSubmitted イベント引数で設定します。</span><span class="sxs-lookup"><span data-stu-id="33fba-179">You can override this behavior by setting **Handled** to **true** in the TextSubmitted event args.</span></span> <span data-ttu-id="33fba-180">イベントが処理済みとしてマークし、コンボ ボックスは何も実行さらに、イベントの後に編集の状態に維持されます。</span><span class="sxs-lookup"><span data-stu-id="33fba-180">When the event is marked as handled, the combo box will take no further action after the event and will stay in the editing state.</span></span> <span data-ttu-id="33fba-181">SelectedItem が更新されなくなります。</span><span class="sxs-lookup"><span data-stu-id="33fba-181">SelectedItem will not be updated.</span></span>

<span data-ttu-id="33fba-182">この例では、単純な編集可能なコンボ ボックスを使用します。</span><span class="sxs-lookup"><span data-stu-id="33fba-182">This example shows a simple editable combo box.</span></span> <span data-ttu-id="33fba-183">一覧には、単純な文字列が含まれてされ、ユーザーが入力した任意の値が、入力に使用されます。</span><span class="sxs-lookup"><span data-stu-id="33fba-183">The list contains simple strings, and any value entered by the user is used as entered.</span></span>

<span data-ttu-id="33fba-184">「最近使った名前を」の選択では、ユーザーがカスタム文字列を入力できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-184">A "recently used names" chooser lets the user enter custom strings.</span></span> <span data-ttu-id="33fba-185">'RecentlyUsedNames' 一覧には、ユーザーが選択できる、いくつかの値が含まれていますが、ユーザーにも、カスタムの新しい値を追加できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-185">The 'RecentlyUsedNames' list contains some values that the user can choose from, but the user can also add a new, custom value.</span></span> <span data-ttu-id="33fba-186">'CurrentName' プロパティは、現在の入力の名前を表します。</span><span class="sxs-lookup"><span data-stu-id="33fba-186">The 'CurrentName' property represents the currently entered name.</span></span>

```xaml
<ComboBox IsEditable="true"
          ItemsSource="{x:Bind RecentlyUsedNames}"
          SelectedItem="{x:Bind CurrentName, Mode=TwoWay}"/>
```

### <a name="text-submitted"></a><span data-ttu-id="33fba-187">提出されたテキスト</span><span class="sxs-lookup"><span data-stu-id="33fba-187">Text submitted</span></span>

<span data-ttu-id="33fba-188">ユーザーが入力した値と連携する[TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)イベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="33fba-188">You can handle the [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox) event to work with the value entered by the user.</span></span> <span data-ttu-id="33fba-189">イベント ハンドラーでは通常を検証するユーザーが入力した値が有効である、アプリで、値を使用します。</span><span class="sxs-lookup"><span data-stu-id="33fba-189">In the event handler, you will typically validate that the value entered by the user is valid, then use the value in your app.</span></span> <span data-ttu-id="33fba-190">状況によって後で使用するためのオプションのコンボ ボックスの一覧に値を追加することも可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33fba-190">Depending on the situation, you might also add the value to the combo box’s list of options for future use.</span></span>

<span data-ttu-id="33fba-191">TextSubmitted イベントは、これらの条件が満たされた場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="33fba-191">The TextSubmitted event occurs when these conditions are met:</span></span>

- <span data-ttu-id="33fba-192">IsEditable プロパティが**true**</span><span class="sxs-lookup"><span data-stu-id="33fba-192">The IsEditable property is **true**</span></span>
- <span data-ttu-id="33fba-193">ユーザーがコンボ ボックスの一覧の既存のエントリに一致しないテキストを入力します。</span><span class="sxs-lookup"><span data-stu-id="33fba-193">The user enters text that does not match an existing entry in the combo box list</span></span>
- <span data-ttu-id="33fba-194">ユーザーは、Enter を押すか、コンボ ボックスからフォーカスが移動します。</span><span class="sxs-lookup"><span data-stu-id="33fba-194">The user presses Enter, or moves focus from the combo box.</span></span>

<span data-ttu-id="33fba-195">TextSubmitted イベントは、ユーザーがテキストを入力し、一覧を上下に移動する場合に発生しません。</span><span class="sxs-lookup"><span data-stu-id="33fba-195">The TextSubmitted event does not occur if the user enters text and then navigates up or down through the list.</span></span>

### <a name="sample---validate-input-and-use-locally"></a><span data-ttu-id="33fba-196">サンプル - 入力を検証し、ローカルで使う</span><span class="sxs-lookup"><span data-stu-id="33fba-196">Sample - Validate input and use locally</span></span>

<span data-ttu-id="33fba-197">この例では、フォント サイズの選択には、フォント サイズの見本に対応する値のセットが含まれていますが、ユーザーは、一覧にないフォント サイズを入力します。</span><span class="sxs-lookup"><span data-stu-id="33fba-197">In this example, a font size chooser contains a set of values corresponding to the font size ramp, but the user may enter font sizes that are not in the list.</span></span>

<span data-ttu-id="33fba-198">フォント サイズの一覧には、ユーザーがリスト、フォント サイズ、更新プログラムは、値に含まれていない値を追加する場合は追加されません。</span><span class="sxs-lookup"><span data-stu-id="33fba-198">When the user adds a value that's not in the list, the font size updates, but the value is not added to the list of font sizes.</span></span>

<span data-ttu-id="33fba-199">新たに入力された値が正しくない Text プロパティを最後に戻すには、「selectedvalue」を使用する場合は、適切な値に知られています。</span><span class="sxs-lookup"><span data-stu-id="33fba-199">If the newly entered value is not valid, you use the SelectedValue to revert the Text property to the last known good value.</span></span>

```xaml
<ComboBox x:Name="fontSizeComboBox"
          IsEditable="true"
          ItemsSource="{x:Bind ListOfFontSizes}"
          TextSubmitted="FontSizeComboBox_TextSubmitted"/>
```

```csharp
private void FontSizeComboBox_TextSubmitted(ComboBox sender, ComboBoxTextSubmittedEventArgs e)
{
    if (byte.TryParse(e.Text, out double newValue))
    {
        // Update the app’s font size.
        _fontSize = newValue;
    }
    else
    {
        // If the item is invalid, reject it and revert the text.
        // Mark the event as handled so the framework doesn’t update the selected item.
        sender.Text = sender.SelectedValue.ToString();
        e.Handled = true;
    }
}
```

### <a name="sample---validate-input-and-add-to-list"></a><span data-ttu-id="33fba-200">サンプル - 入力を検証し、一覧に追加します。</span><span class="sxs-lookup"><span data-stu-id="33fba-200">Sample - Validate input and add to list</span></span>

<span data-ttu-id="33fba-201">ここでは、「好きな色の選択」には、最も一般的な好みの色 (赤、青、緑、Orange) が含まれていますが、ユーザーは、一覧に含まれていない好きな色を入力します。</span><span class="sxs-lookup"><span data-stu-id="33fba-201">Here, a "favorite color chooser" contains the most common favorite colors (Red, Blue, Green, Orange), but the user may enter a favorite color that's not in the list.</span></span> <span data-ttu-id="33fba-202">ユーザーは、有効な色 (ピンク) などを追加するとき、新たに入力された色がリストに追加し、「好きな色」アクティブとして設定します。</span><span class="sxs-lookup"><span data-stu-id="33fba-202">When the user adds a valid color (like Pink), the newly entered color is added to the list and set as the active "favorite color".</span></span>

```xaml
<ComboBox x:Name="favoriteColorComboBox"
          IsEditable="true"
          ItemsSource="{x:Bind ListOfColors}"
          TextSubmitted="FavoriteColorComboBox_TextSubmitted"/>
```

```csharp
private void FavoriteColorComboBox_TextSubmitted(ComboBox sender, ComboBoxTextSubmittedEventArgs e)
{
    if (IsValid(e.Text))
    {
        FavoriteColor newColor = new FavoriteColor()
        {
            ColorName = e.Text,
            Color = ColorFromStringConverter(e.Text)
        }
        ListOfColors.Add(newColor);
    }
    else
    {
        // If the item is invalid, reject it but do not revert the text.
        // Mark the event as handled so the framework doesn’t update the selected item.
        e.Handled = true;
    }
}

bool IsValid(string Text)
{
    // Validate that the string is: not empty; a color.
}
```

## <a name="dos-and-donts"></a><span data-ttu-id="33fba-203">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="33fba-203">Do's and don'ts</span></span>

- <span data-ttu-id="33fba-204">コンボ ボックス項目のテキストのコンテンツは、単一行に制限します。</span><span class="sxs-lookup"><span data-stu-id="33fba-204">Limit the text content of combo box items to a single line.</span></span>
- <span data-ttu-id="33fba-205">コンボ ボックス内の項目は、最も論理的な順序に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="33fba-205">Sort items in a combo box in the most logical order.</span></span> <span data-ttu-id="33fba-206">関連するオプションをグループ化し、最も一般的なオプションを先頭に配置します。</span><span class="sxs-lookup"><span data-stu-id="33fba-206">Group together related options and place the most common options at the top.</span></span> <span data-ttu-id="33fba-207">名前はアルファベット順、数値は数値順、日付は時系列順に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="33fba-207">Sort names in alphabetical order, numbers in numerical order, and dates in chronological order.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="33fba-208">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="33fba-208">Get the sample code</span></span>

- <span data-ttu-id="33fba-209">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="33fba-209">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="33fba-210">AutoSuggestBox サンプル</span><span class="sxs-lookup"><span data-stu-id="33fba-210">AutoSuggestBox sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlAutoSuggestBox)

## <a name="related-articles"></a><span data-ttu-id="33fba-211">関連記事</span><span class="sxs-lookup"><span data-stu-id="33fba-211">Related articles</span></span>

- [<span data-ttu-id="33fba-212">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="33fba-212">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="33fba-213">スペル チェック</span><span class="sxs-lookup"><span data-stu-id="33fba-213">Spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="33fba-214">検索</span><span class="sxs-lookup"><span data-stu-id="33fba-214">Search</span></span>](search.md)
- [<span data-ttu-id="33fba-215">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="33fba-215">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="33fba-216">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="33fba-216">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="33fba-217">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="33fba-217">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length.aspx)
