---
Description: ユーザーが入力するときに、検索候補を表示するテキスト入力ボックスです。
title: コンボ ボックス (ドロップダウン リスト)
label: Combo box
template: detail.hbs
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: ''
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 21a6c698fa0e07587e2c25ae827dc6654a8ced9d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618627"
---
# <a name="combo-box"></a><span data-ttu-id="ec452-104">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="ec452-104">Combo box</span></span>

<span data-ttu-id="ec452-105">ユーザーが選択できる項目の一覧を提供するのにには、コンボ ボックス (ドロップダウン リストとも呼ばれます) を使用します。</span><span class="sxs-lookup"><span data-stu-id="ec452-105">Use a combo box (also known as a drop-down list) to present a list of items that a user can select from.</span></span> <span data-ttu-id="ec452-106">コンボ ボックスでは、コンパクトな状態で開始し、選択可能な項目の一覧を表示する展開します。</span><span class="sxs-lookup"><span data-stu-id="ec452-106">A combo box starts in a compact state and expands to show a list of selectable items.</span></span>

<span data-ttu-id="ec452-107">コンボ ボックスが閉じられたときに表示され、現在の選択か選択した項目がない場合は空です。</span><span class="sxs-lookup"><span data-stu-id="ec452-107">When the combo box is closed, it either displays the current selection or is empty if there is no selected item.</span></span> <span data-ttu-id="ec452-108">ユーザーがコンボ ボックスを展開すると、選択可能な項目の一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="ec452-108">When the user expands the combo box, it displays the list of selectable items.</span></span>

> <span data-ttu-id="ec452-109">**重要な Api**:[コンボ ボックス クラス](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [IsEditable プロパティ](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)、 [Text プロパティ](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [TextSubmitted イベント](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)</span><span class="sxs-lookup"><span data-stu-id="ec452-109">**Important APIs**: [ComboBox class](/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [IsEditable property](/uwp/api/windows.ui.xaml.controls.combobox.iseditable), [Text property](/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [TextSubmitted event](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)</span></span>

<span data-ttu-id="ec452-110">ヘッダーと圧縮の状態でコンボ ボックス。</span><span class="sxs-lookup"><span data-stu-id="ec452-110">A combo box in its compact state with a header.</span></span>

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="ec452-112">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="ec452-112">Is this the right control?</span></span>

- <span data-ttu-id="ec452-113">1 行のテキストで十分に表すことができる項目のセットから、ユーザーが単一の値を選ぶことができるようにするには、ドロップダウン リストを使います。</span><span class="sxs-lookup"><span data-stu-id="ec452-113">Use a drop-down list to let users select a single value from a set of items that can be adequately represented with single lines of text.</span></span>
- <span data-ttu-id="ec452-114">複数のテキスト行や画像が含まれる項目を表示するには、コンボ ボックスではなくリスト ビューまたはグリッド ビューを使います。</span><span class="sxs-lookup"><span data-stu-id="ec452-114">Use a list or grid view instead of a combo box to display items that contain multiple lines of text or images.</span></span>
- <span data-ttu-id="ec452-115">項目が 5 個より少ない場合は、[ラジオ ボタン](radio-button.md) (1 つの項目だけを選ぶことができる場合)、または[チェック ボックス](checkbox.md) (複数の項目を選ぶことができる場合) の使用を検討します。</span><span class="sxs-lookup"><span data-stu-id="ec452-115">When there are fewer than five items, consider using [radio buttons](radio-button.md) (if only one item can be selected) or [check boxes](checkbox.md) (if multiple items can be selected).</span></span>
- <span data-ttu-id="ec452-116">選択項目がアプリのフローにおいて二次的な重要性しか持たない場合は、コンボ ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="ec452-116">Use a combo box when the selection items are of secondary importance in the flow of your app.</span></span> <span data-ttu-id="ec452-117">多くの状況でほとんどのユーザーに対して既定のオプションが推奨されている場合、リスト ビューを使ってすべての項目を表示すると、既定以外のオプションに必要以上の注意を引いてしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ec452-117">If the default option is recommended for most users in most situations, showing all the items by using a list view might draw more attention to the options than necessary.</span></span> <span data-ttu-id="ec452-118">コンボ ボックスを使うことで、領域を節約し、無駄な情報を最小限にすることができます。</span><span class="sxs-lookup"><span data-stu-id="ec452-118">You can save space and minimize distraction by using a combo box.</span></span>

## <a name="examples"></a><span data-ttu-id="ec452-119">例</span><span class="sxs-lookup"><span data-stu-id="ec452-119">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="ec452-120">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="ec452-120">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="ec452-121">ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/ComboBox">アプリを開き、コンボ ボックスの動作を参照してください。</a>します。</span><span class="sxs-lookup"><span data-stu-id="ec452-121">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/ComboBox">open the app and see the ComboBox in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="ec452-122"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></span><span class="sxs-lookup"><span data-stu-id="ec452-122"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="ec452-123"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="ec452-123"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="ec452-124">コンパクトな状態のコンボ ボックスには、ヘッダーを表示できます。</span><span class="sxs-lookup"><span data-stu-id="ec452-124">A combo box in its compact state can show a header.</span></span>

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

<span data-ttu-id="ec452-126">コンボ ボックスは、長い文字列の幅をサポートするために拡張できますが、読みづらくなるような長すぎる文字列は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="ec452-126">Although combo boxes expand to support longer string lengths, avoid excessively long strings that are difficult to read.</span></span>

![長い文字列のドロップダウン リストの例](images/combo_box_listitemstate.png)

<span data-ttu-id="ec452-128">コンボ ボックス内のコレクションが一定の長さに達すると、対応できるようにスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ec452-128">If the collection in a combo box is long enough, a scroll bar will appear to accommodate it.</span></span> <span data-ttu-id="ec452-129">リスト内の項目は論理的にグループ化します。</span><span class="sxs-lookup"><span data-stu-id="ec452-129">Group items logically in the list.</span></span>

![ドロップダウン リストに表示されたスクロール バーの例](images/combo_box_scroll.png)

## <a name="create-a-combo-box"></a><span data-ttu-id="ec452-131">コンボ ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="ec452-131">Create a combo box</span></span>

<span data-ttu-id="ec452-132">直接オブジェクトを追加することで、コンボ ボックスに入力する、[項目](/uwp/api/windows.ui.xaml.controls.itemscontrol.items)コレクションまたはバインドすることによって、 [ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティをデータ ソース。</span><span class="sxs-lookup"><span data-stu-id="ec452-132">You populate the combo box by adding objects directly to the [Items](/uwp/api/windows.ui.xaml.controls.itemscontrol.items) collection or by binding the [ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property to a data source.</span></span> <span data-ttu-id="ec452-133">コンボ ボックスに追加された項目にラップされます[や ComboBoxItem](/uwp/api/windows.ui.xaml.controls.comboboxitem)コンテナー。</span><span class="sxs-lookup"><span data-stu-id="ec452-133">Items added to the ComboBox are wrapped in [ComboBoxItem](/uwp/api/windows.ui.xaml.controls.comboboxitem) containers.</span></span>

<span data-ttu-id="ec452-134">XAML で追加された項目を含む単純なコンボ ボックスを次に示します。</span><span class="sxs-lookup"><span data-stu-id="ec452-134">Here's a simple combo box with items added in XAML.</span></span>

```xaml
<ComboBox Header="Colors" PlaceholderText="Pick a color" Width="200">
    <x:String>Blue</x:String>
    <x:String>Green</x:String>
    <x:String>Red</x:String>
    <x:String>Yellow</x:String>
</ComboBox>
```

<span data-ttu-id="ec452-135">次の例では、コンボ ボックスの FontFamily オブジェクトのコレクションへのバインディングを示します。</span><span class="sxs-lookup"><span data-stu-id="ec452-135">The following example demonstrates binding a combo box to a collection of FontFamily objects.</span></span>

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

### <a name="item-selection"></a><span data-ttu-id="ec452-136">項目の選択</span><span class="sxs-lookup"><span data-stu-id="ec452-136">Item selection</span></span>

<span data-ttu-id="ec452-137">ListView、GridView などコンボ ボックスはから派生[セレクター](/uwp/api/windows.ui.xaml.controls.primitives.selector)、標準と同様に、ユーザーの選択を取得できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ec452-137">Like ListView and GridView, ComboBox is derived from [Selector](/uwp/api/windows.ui.xaml.controls.primitives.selector), so you can get the user’s selection in the same standard way.</span></span>

<span data-ttu-id="ec452-138">取得またはを使用して、コンボ ボックスの選択された項目を設定することができます、 [SelectedItem](/uwp/api/windows.ui.xaml.controls.primitives.selector.selecteditem)プロパティ、および get または set を使用して、選択した項目のインデックス、 [SelectedIndex](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedindex)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="ec452-138">You can get or set the combo box's selected item by using the [SelectedItem](/uwp/api/windows.ui.xaml.controls.primitives.selector.selecteditem) property, and get or set the index of the selected item by using the [SelectedIndex](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedindex) property.</span></span>

<span data-ttu-id="ec452-139">使用することを選択したデータ項目の特定のプロパティの値を取得する、 [SelectedValue](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvalue)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="ec452-139">To get the value of a particular property on the selected data item, you can use the [SelectedValue](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvalue) property.</span></span> <span data-ttu-id="ec452-140">この場合、設定、 [SelectedValuePath](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvaluepath)から値を取得する選択項目にプロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="ec452-140">In this case, set the [SelectedValuePath](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvaluepath) to specify which property on the selected item to get the value from.</span></span>

> [!TIP]
> <span data-ttu-id="ec452-141">既定の選択を示すためには、SelectedItem または SelectedIndex を設定すると、コンボ ボックス項目のコレクションを設定する前に、プロパティが設定されている場合、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="ec452-141">If you set SelectedItem or SelectedIndex to indicate the default selection, an exception occurs if the property is set before the combo box Items collection is populated.</span></span> <span data-ttu-id="ec452-142">XAML でアイテムを定義する場合を除き、コンボ ボックスの Loaded イベントを処理し、Loaded イベント ハンドラーで SelectedItem または SelectedIndex を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ec452-142">Unless you define your Items in XAML, it's best to handle the combo box Loaded event, and set SelectedItem or SelectedIndex in the Loaded event handler.</span></span>

<span data-ttu-id="ec452-143">XAML では、これらのプロパティにバインドしたり、処理、 [SelectionChanged](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)選択の変更に応答するイベントです。</span><span class="sxs-lookup"><span data-stu-id="ec452-143">You can bind to these properties in XAML, or handle the [SelectionChanged](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged) event to respond to selection changes.</span></span>

<span data-ttu-id="ec452-144">イベント ハンドラーのコードを取得できますから選択されたアイテム、 [SelectionChangedEventArgs.AddedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.addeditems)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="ec452-144">In the event handler code, you can get the selected item from the [SelectionChangedEventArgs.AddedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.addeditems) property.</span></span> <span data-ttu-id="ec452-145">取得できます、以前に選択した項目 (ある場合)、 [SelectionChangedEventArgs.RemovedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.removeditems)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="ec452-145">You can get the previously selected item (if any) from the [SelectionChangedEventArgs.RemovedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.removeditems) property.</span></span> <span data-ttu-id="ec452-146">AddedItems と RemovedItems のそれぞれのコレクションには、コンボ ボックスが複数選択をサポートしていないために、1 項目のみが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ec452-146">The AddedItems and RemovedItems collections each contain only 1 item because combo box does not support multiple selection.</span></span>

<span data-ttu-id="ec452-147">この例では、選択した項目にバインドする方法と、SelectionChanged イベントを処理する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="ec452-147">This example shows how to handle the SelectionChanged event, and also how to bind to the selected item.</span></span>

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

#### <a name="selectionchanged-and-keyboard-navigation"></a><span data-ttu-id="ec452-148">SelectionChanged とキーボードのナビゲーション</span><span class="sxs-lookup"><span data-stu-id="ec452-148">SelectionChanged and keyboard navigation</span></span>

<span data-ttu-id="ec452-149">既定では、SelectionChanged イベントは、コンボ ボックスが閉じ、ユーザーがクリックして、タップ、または enter を押すと、項目を自分の選択をコミットする一覧と発生します。</span><span class="sxs-lookup"><span data-stu-id="ec452-149">By default, the SelectionChanged event occurs when a user clicks, taps, or presses Enter on an item in the list to commit their selection, and the combo box closes.</span></span> <span data-ttu-id="ec452-150">ユーザーがキーボードの矢印キーを開いているコンボ ボックスの一覧を移動すると、選択は変更されません。</span><span class="sxs-lookup"><span data-stu-id="ec452-150">Selection doesn't change when the user navigates the open combo box list with the keyboard arrow keys.</span></span>

<span data-ttu-id="ec452-151">ユーザーは一覧を開きます (フォントの選択ボックスの一覧) のように、矢印キーで移動する際に、その「ライブ更新」をボックス コンボをするためには、次のように設定します。 [SelectionChangedTrigger](/uwp/api/windows.ui.xaml.controls.combobox.selectionchangedtrigger)に[常に](/uwp/api/windows.ui.xaml.controls.comboboxselectionchangedtrigger)します。</span><span class="sxs-lookup"><span data-stu-id="ec452-151">To make a combo box that "live updates" while the user is navigating the open list with the arrow keys (like a Font selection drop-down), set [SelectionChangedTrigger](/uwp/api/windows.ui.xaml.controls.combobox.selectionchangedtrigger) to [Always](/uwp/api/windows.ui.xaml.controls.comboboxselectionchangedtrigger).</span></span> <span data-ttu-id="ec452-152">これにより、オープン リスト内の別の項目にフォーカスが変更されたときに発生する SelectionChanged イベントです。</span><span class="sxs-lookup"><span data-stu-id="ec452-152">This causes the SelectionChanged event to occur when focus changes to another item in the open list.</span></span>

#### <a name="selected-item-behavior-change"></a><span data-ttu-id="ec452-153">選択した項目の動作の変更</span><span class="sxs-lookup"><span data-stu-id="ec452-153">Selected item behavior change</span></span>

<span data-ttu-id="ec452-154">Windows 10、バージョンは 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) や、編集可能なコンボ ボックスをサポートするために選択した項目の動作が更新された後で、します。</span><span class="sxs-lookup"><span data-stu-id="ec452-154">In Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, the behavior of selected items is updated to support editable combo boxes.</span></span>

<span data-ttu-id="ec452-155">SDK 17763、SelectedItem プロパティの値の前に (とそのため、SelectedValue および SelectedIndex) コンボ ボックスの項目のコレクションに存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ec452-155">Prior to SDK 17763, the value of the SelectedItem property (and therefore, SelectedValue and SelectedIndex) was required to be in the combo box's Items collection.</span></span> <span data-ttu-id="ec452-156">前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`結果します。</span><span class="sxs-lookup"><span data-stu-id="ec452-156">Using the previous example, setting `colorComboBox.SelectedItem = "Pink"` results in:</span></span>

- <span data-ttu-id="ec452-157">SelectedItem = null</span><span class="sxs-lookup"><span data-stu-id="ec452-157">SelectedItem = null</span></span>
- <span data-ttu-id="ec452-158">SelectedValue = null</span><span class="sxs-lookup"><span data-stu-id="ec452-158">SelectedValue = null</span></span>
- <span data-ttu-id="ec452-159">SelectedIndex =-1</span><span class="sxs-lookup"><span data-stu-id="ec452-159">SelectedIndex = -1</span></span>

<span data-ttu-id="ec452-160">Sdk 17763 以降、SelectedItem プロパティの値 (とそのため、SelectedValue および SelectedIndex) コンボ ボックスの項目のコレクションに存在する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ec452-160">In SDK 17763 and later, the value of the SelectedItem property (and therefore, SelectedValue and SelectedIndex) is not required to be in the combo box's Items collection.</span></span> <span data-ttu-id="ec452-161">前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`結果します。</span><span class="sxs-lookup"><span data-stu-id="ec452-161">Using the previous example, setting `colorComboBox.SelectedItem = "Pink"` results in:</span></span>

- <span data-ttu-id="ec452-162">SelectedItem = pink」と入力</span><span class="sxs-lookup"><span data-stu-id="ec452-162">SelectedItem = Pink</span></span>
- <span data-ttu-id="ec452-163">SelectedValue = pink」と入力</span><span class="sxs-lookup"><span data-stu-id="ec452-163">SelectedValue = Pink</span></span>
- <span data-ttu-id="ec452-164">SelectedIndex =-1</span><span class="sxs-lookup"><span data-stu-id="ec452-164">SelectedIndex = -1</span></span>

### <a name="text-search"></a><span data-ttu-id="ec452-165">テキスト検索</span><span class="sxs-lookup"><span data-stu-id="ec452-165">Text Search</span></span>

<span data-ttu-id="ec452-166">コンボ ボックスでは、コレクション内を自動的に検索できます。</span><span class="sxs-lookup"><span data-stu-id="ec452-166">Combo boxes automatically support search within their collections.</span></span> <span data-ttu-id="ec452-167">開かれた状態または閉じた状態のコンボ ボックスにフォーカスがあるときに、物理的なキーボードで文字を入力すると、ユーザーが入力した文字列に一致する候補がビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="ec452-167">As users type characters on a physical keyboard while focused on an open or closed combo box, candidates matching the user's string are brought into view.</span></span> <span data-ttu-id="ec452-168">この機能は、長いリストを操作するときに特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ec452-168">This functionality is especially helpful when navigating a long list.</span></span> <span data-ttu-id="ec452-169">たとえば、状態の一覧を含むドロップダウンを扱うときにユーザーのユーザーは、迅速な選択に"Washington"の表示を"w"キーを押すできます。</span><span class="sxs-lookup"><span data-stu-id="ec452-169">For example, when interacting with a drop-down containing a list of states, users can press the "w" key to bring "Washington" into view for quick selection.</span></span> <span data-ttu-id="ec452-170">フルテキスト検索は区別されません。</span><span class="sxs-lookup"><span data-stu-id="ec452-170">The text search is not case-sensitive.</span></span>

<span data-ttu-id="ec452-171">設定することができます、 [IsTextSearchEnabled](/uwp/api/windows.ui.xaml.controls.combobox.istextsearchenabled)プロパティを**false**この機能を無効にします。</span><span class="sxs-lookup"><span data-stu-id="ec452-171">You can set the [IsTextSearchEnabled](/uwp/api/windows.ui.xaml.controls.combobox.istextsearchenabled) property to **false** to disable this functionality.</span></span>

## <a name="make-a-combo-box-editable"></a><span data-ttu-id="ec452-172">コンボ ボックスを編集可能します。</span><span class="sxs-lookup"><span data-stu-id="ec452-172">Make a combo box editable</span></span>

> [!IMPORTANT]
> <span data-ttu-id="ec452-173">この機能は、Windows 10、バージョンは 1809 を必要があります ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="ec452-173">This feature requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later.</span></span>

<span data-ttu-id="ec452-174">既定では、コンボ ボックスには、ユーザーができるように事前に定義されているオプションの一覧から選択します。</span><span class="sxs-lookup"><span data-stu-id="ec452-174">By default, a combo box lets the user select from a pre-defined list of options.</span></span> <span data-ttu-id="ec452-175">ただし、これには、一覧には、有効な値のサブセットのみが含まれています、ユーザーが示されていないその他の値を入力できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="ec452-175">However, there are cases where the list contains only a subset of valid values, and the user should be able to enter other values that aren't listed.</span></span> <span data-ttu-id="ec452-176">これをサポートするには、行うことができます、コンボ ボックス編集できます。</span><span class="sxs-lookup"><span data-stu-id="ec452-176">To support this, you can make the combo box editable.</span></span>

<span data-ttu-id="ec452-177">コンボ ボックスを編集するためには、設定、 [IsEditable](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)プロパティを**true**します。</span><span class="sxs-lookup"><span data-stu-id="ec452-177">To make a combo box editable, set the [IsEditable](/uwp/api/windows.ui.xaml.controls.combobox.iseditable) property to **true**.</span></span> <span data-ttu-id="ec452-178">次に、処理、 [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)ユーザーが入力した値を使用するイベントです。</span><span class="sxs-lookup"><span data-stu-id="ec452-178">Then, handle the [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox) event to work with the value entered by the user.</span></span>

<span data-ttu-id="ec452-179">既定では、ユーザーがカスタム テキストをコミット時に、SelectedItem 値が更新されます。</span><span class="sxs-lookup"><span data-stu-id="ec452-179">By default, the SelectedItem value is updated when the user commits custom text.</span></span> <span data-ttu-id="ec452-180">設定してこの動作をオーバーライドできます**処理済み**に**true** TextSubmitted イベントの引数にします。</span><span class="sxs-lookup"><span data-stu-id="ec452-180">You can override this behavior by setting **Handled** to **true** in the TextSubmitted event args.</span></span> <span data-ttu-id="ec452-181">イベントが処理済みとしてマークされている、コンボ ボックスは、イベント後にこれ以上の操作を実行しないと、編集の状態のままとなります。</span><span class="sxs-lookup"><span data-stu-id="ec452-181">When the event is marked as handled, the combo box will take no further action after the event and will stay in the editing state.</span></span> <span data-ttu-id="ec452-182">SelectedItem は更新されません。</span><span class="sxs-lookup"><span data-stu-id="ec452-182">SelectedItem will not be updated.</span></span>

<span data-ttu-id="ec452-183">この例では、単純な編集可能なコンボ ボックスを使用します。</span><span class="sxs-lookup"><span data-stu-id="ec452-183">This example shows a simple editable combo box.</span></span> <span data-ttu-id="ec452-184">一覧には、単純な文字列が含まれていて、入力時に、ユーザーが入力した任意の値を使用します。</span><span class="sxs-lookup"><span data-stu-id="ec452-184">The list contains simple strings, and any value entered by the user is used as entered.</span></span>

<span data-ttu-id="ec452-185">「最近使った名前を」の選択には、カスタム文字列を入力します。 ユーザーことができます。</span><span class="sxs-lookup"><span data-stu-id="ec452-185">A "recently used names" chooser lets the user enter custom strings.</span></span> <span data-ttu-id="ec452-186">'RecentlyUsedNames' 一覧には、ユーザーが選択できる、いくつかの値が含まれていますが、ユーザーは、新しいカスタム値を追加もできます。</span><span class="sxs-lookup"><span data-stu-id="ec452-186">The 'RecentlyUsedNames' list contains some values that the user can choose from, but the user can also add a new, custom value.</span></span> <span data-ttu-id="ec452-187">'CurrentName' プロパティは、現在入力した名前を表します。</span><span class="sxs-lookup"><span data-stu-id="ec452-187">The 'CurrentName' property represents the currently entered name.</span></span>

```xaml
<ComboBox IsEditable="true"
          ItemsSource="{x:Bind RecentlyUsedNames}"
          SelectedItem="{x:Bind CurrentName, Mode=TwoWay}"/>
```

### <a name="text-submitted"></a><span data-ttu-id="ec452-188">送信されるテキスト</span><span class="sxs-lookup"><span data-stu-id="ec452-188">Text submitted</span></span>

<span data-ttu-id="ec452-189">処理することができます、 [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)ユーザーが入力した値を使用するイベントです。</span><span class="sxs-lookup"><span data-stu-id="ec452-189">You can handle the [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox) event to work with the value entered by the user.</span></span> <span data-ttu-id="ec452-190">イベント ハンドラーは通常を検証する、ユーザーが入力した値が有効であるには、アプリで、値を使用します。</span><span class="sxs-lookup"><span data-stu-id="ec452-190">In the event handler, you will typically validate that the value entered by the user is valid, then use the value in your app.</span></span> <span data-ttu-id="ec452-191">状況によっては、将来使用するためのオプションのコンボ ボックスの一覧を値を追加することも可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ec452-191">Depending on the situation, you might also add the value to the combo box’s list of options for future use.</span></span>

<span data-ttu-id="ec452-192">TextSubmitted イベントは、これらの条件が満たされたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="ec452-192">The TextSubmitted event occurs when these conditions are met:</span></span>

- <span data-ttu-id="ec452-193">IsEditable プロパティは**は true。**</span><span class="sxs-lookup"><span data-stu-id="ec452-193">The IsEditable property is **true**</span></span>
- <span data-ttu-id="ec452-194">ユーザーがコンボ ボックスの一覧で既存のエントリに一致しないテキストを入力します。</span><span class="sxs-lookup"><span data-stu-id="ec452-194">The user enters text that does not match an existing entry in the combo box list</span></span>
- <span data-ttu-id="ec452-195">ユーザーは、Enter キーを押すか、コンボ ボックスからフォーカスを移動します。</span><span class="sxs-lookup"><span data-stu-id="ec452-195">The user presses Enter, or moves focus from the combo box.</span></span>

<span data-ttu-id="ec452-196">ユーザーがテキストを入力し、一覧を上下に移動する場合、TextSubmitted イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="ec452-196">The TextSubmitted event does not occur if the user enters text and then navigates up or down through the list.</span></span>

### <a name="sample---validate-input-and-use-locally"></a><span data-ttu-id="ec452-197">サンプル - 入力を検証し、ローカルで使用</span><span class="sxs-lookup"><span data-stu-id="ec452-197">Sample - Validate input and use locally</span></span>

<span data-ttu-id="ec452-198">この例では、フォント サイズの選択には、フォント サイズのランプに対応する値のセットが含まれていますが、ユーザーは、一覧にないフォント サイズを入力します。</span><span class="sxs-lookup"><span data-stu-id="ec452-198">In this example, a font size chooser contains a set of values corresponding to the font size ramp, but the user may enter font sizes that are not in the list.</span></span>

<span data-ttu-id="ec452-199">ユーザーが、フォント サイズ、更新プログラムのリストは、値ではない値を追加するときは、フォント サイズの一覧には追加されません。</span><span class="sxs-lookup"><span data-stu-id="ec452-199">When the user adds a value that's not in the list, the font size updates, but the value is not added to the list of font sizes.</span></span>

<span data-ttu-id="ec452-200">新しく入力した値が無効ですが、最後の Text プロパティを元に戻す、SelectedValue を使用する場合は、有効な値を知られています。</span><span class="sxs-lookup"><span data-stu-id="ec452-200">If the newly entered value is not valid, you use the SelectedValue to revert the Text property to the last known good value.</span></span>

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

### <a name="sample---validate-input-and-add-to-list"></a><span data-ttu-id="ec452-201">サンプル - 入力を検証し、一覧に追加</span><span class="sxs-lookup"><span data-stu-id="ec452-201">Sample - Validate input and add to list</span></span>

<span data-ttu-id="ec452-202">ここでは、「好きな色選択」には、最も一般的なの好きな色 (赤、青、緑、オレンジ色) が含まれていますが、ユーザーは、一覧に含まれていない好きな色を入力します。</span><span class="sxs-lookup"><span data-stu-id="ec452-202">Here, a "favorite color chooser" contains the most common favorite colors (Red, Blue, Green, Orange), but the user may enter a favorite color that's not in the list.</span></span> <span data-ttu-id="ec452-203">ユーザーは、(ピンク) などの有効な色を追加するときに新しく入力色がリストに追加し、「好きな色」アクティブとして設定。</span><span class="sxs-lookup"><span data-stu-id="ec452-203">When the user adds a valid color (like Pink), the newly entered color is added to the list and set as the active "favorite color".</span></span>

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

## <a name="dos-and-donts"></a><span data-ttu-id="ec452-204">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="ec452-204">Do's and don'ts</span></span>

- <span data-ttu-id="ec452-205">コンボ ボックス項目のテキストのコンテンツは、単一行に制限します。</span><span class="sxs-lookup"><span data-stu-id="ec452-205">Limit the text content of combo box items to a single line.</span></span>
- <span data-ttu-id="ec452-206">コンボ ボックス内の項目は、最も論理的な順序に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="ec452-206">Sort items in a combo box in the most logical order.</span></span> <span data-ttu-id="ec452-207">関連するオプションをグループ化し、最も一般的なオプションを先頭に配置します。</span><span class="sxs-lookup"><span data-stu-id="ec452-207">Group together related options and place the most common options at the top.</span></span> <span data-ttu-id="ec452-208">名前はアルファベット順、数値は数値順、日付は時系列順に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="ec452-208">Sort names in alphabetical order, numbers in numerical order, and dates in chronological order.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="ec452-209">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="ec452-209">Get the sample code</span></span>

- <span data-ttu-id="ec452-210">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="ec452-210">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="ec452-211">AutoSuggestBox サンプル</span><span class="sxs-lookup"><span data-stu-id="ec452-211">AutoSuggestBox sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlAutoSuggestBox)

## <a name="related-articles"></a><span data-ttu-id="ec452-212">関連記事</span><span class="sxs-lookup"><span data-stu-id="ec452-212">Related articles</span></span>

- [<span data-ttu-id="ec452-213">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="ec452-213">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="ec452-214">スペル チェック</span><span class="sxs-lookup"><span data-stu-id="ec452-214">Spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="ec452-215">検索</span><span class="sxs-lookup"><span data-stu-id="ec452-215">Search</span></span>](search.md)
- [<span data-ttu-id="ec452-216">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="ec452-216">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="ec452-217">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="ec452-217">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="ec452-218">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="ec452-218">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length.aspx)
