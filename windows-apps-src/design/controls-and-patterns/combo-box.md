---
author: Jwmsft
Description: A text entry box that provides suggestions as the user types.
title: コンボ ボックス (ドロップダウン リスト)
label: Combo box
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: ''
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 4f7592f584227d9b3a93a0ef4cea3ce53cd203ea
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4132213"
---
# <a name="combo-box"></a><span data-ttu-id="e7071-103">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="e7071-103">Combo box</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e7071-104">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e7071-104">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="e7071-105">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="e7071-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="e7071-106">ユーザーが選択できる項目の一覧を表示するのにには、コンボ ボックス (ドロップダウン リストとも呼ばれます) を使用します。</span><span class="sxs-lookup"><span data-stu-id="e7071-106">Use a combo box (also known as a drop-down list) to present a list of items that a user can select from.</span></span> <span data-ttu-id="e7071-107">コンボ ボックスでは、コンパクトな状態で開始し、展開を選択できる項目の一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="e7071-107">A combo box starts in a compact state and expands to show a list of selectable items.</span></span>

<span data-ttu-id="e7071-108">コンボ ボックスを閉じると、現在の選択項目が表示されますか選択された項目がない場合は空です。</span><span class="sxs-lookup"><span data-stu-id="e7071-108">When the combo box is closed, it either displays the current selection or is empty if there is no selected item.</span></span> <span data-ttu-id="e7071-109">ユーザーがコンボ ボックスを展開するときは、選択可能な項目の一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="e7071-109">When the user expands the combo box, it displays the list of selectable items.</span></span>

> <span data-ttu-id="e7071-110">**重要な Api**: [ComboBox クラス](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [IsEditable プロパティ](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)、 [Text プロパティ](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)を、 [TextSubmitted イベント](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)</span><span class="sxs-lookup"><span data-stu-id="e7071-110">**Important APIs**: [ComboBox class](/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [IsEditable property](/uwp/api/windows.ui.xaml.controls.combobox.iseditable), [Text property](/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [TextSubmitted event](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)</span></span>

<span data-ttu-id="e7071-111">コンボ ボックス、ヘッダーを含むコンパクトな状態にします。</span><span class="sxs-lookup"><span data-stu-id="e7071-111">A combo box in its compact state with a header.</span></span>

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="e7071-113">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="e7071-113">Is this the right control?</span></span>

- <span data-ttu-id="e7071-114">1 行のテキストで十分に表すことができる項目のセットから、ユーザーが単一の値を選ぶことができるようにするには、ドロップダウン リストを使います。</span><span class="sxs-lookup"><span data-stu-id="e7071-114">Use a drop-down list to let users select a single value from a set of items that can be adequately represented with single lines of text.</span></span>
- <span data-ttu-id="e7071-115">複数のテキスト行や画像が含まれる項目を表示するには、コンボ ボックスではなくリスト ビューまたはグリッド ビューを使います。</span><span class="sxs-lookup"><span data-stu-id="e7071-115">Use a list or grid view instead of a combo box to display items that contain multiple lines of text or images.</span></span>
- <span data-ttu-id="e7071-116">項目が 5 個より少ない場合は、[ラジオ ボタン](radio-button.md) (1 つの項目だけを選ぶことができる場合)、または[チェック ボックス](checkbox.md) (複数の項目を選ぶことができる場合) の使用を検討します。</span><span class="sxs-lookup"><span data-stu-id="e7071-116">When there are fewer than five items, consider using [radio buttons](radio-button.md) (if only one item can be selected) or [check boxes](checkbox.md) (if multiple items can be selected).</span></span>
- <span data-ttu-id="e7071-117">選択項目がアプリのフローにおいて二次的な重要性しか持たない場合は、コンボ ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="e7071-117">Use a combo box when the selection items are of secondary importance in the flow of your app.</span></span> <span data-ttu-id="e7071-118">多くの状況でほとんどのユーザーに対して既定のオプションが推奨されている場合、リスト ビューを使ってすべての項目を表示すると、既定以外のオプションに必要以上の注意を引いてしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e7071-118">If the default option is recommended for most users in most situations, showing all the items by using a list view might draw more attention to the options than necessary.</span></span> <span data-ttu-id="e7071-119">コンボ ボックスを使うことで、領域を節約し、無駄な情報を最小限にすることができます。</span><span class="sxs-lookup"><span data-stu-id="e7071-119">You can save space and minimize distraction by using a combo box.</span></span>

## <a name="examples"></a><span data-ttu-id="e7071-120">例</span><span class="sxs-lookup"><span data-stu-id="e7071-120">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="e7071-121">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="e7071-121">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="e7071-122"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールした場合は、アプリを<a href="xamlcontrolsgallery:/item/ComboBox">開き、コンボ ボックスの動作を参照してください</a>ここをクリックします。</span><span class="sxs-lookup"><span data-stu-id="e7071-122">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/ComboBox">open the app and see the ComboBox in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="e7071-123">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="e7071-123">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="e7071-124">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="e7071-124">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="e7071-125">コンパクトな状態のコンボ ボックスには、ヘッダーを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-125">A combo box in its compact state can show a header.</span></span>

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

<span data-ttu-id="e7071-127">コンボ ボックスは、長い文字列の幅をサポートするために拡張できますが、読みづらくなるような長すぎる文字列は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="e7071-127">Although combo boxes expand to support longer string lengths, avoid excessively long strings that are difficult to read.</span></span>

![長い文字列のドロップダウン リストの例](images/combo_box_listitemstate.png)

<span data-ttu-id="e7071-129">コンボ ボックス内のコレクションが一定の長さに達すると、対応できるようにスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e7071-129">If the collection in a combo box is long enough, a scroll bar will appear to accommodate it.</span></span> <span data-ttu-id="e7071-130">リスト内の項目は論理的にグループ化します。</span><span class="sxs-lookup"><span data-stu-id="e7071-130">Group items logically in the list.</span></span>

![ドロップダウン リストに表示されたスクロール バーの例](images/combo_box_scroll.png)

## <a name="create-a-combo-box"></a><span data-ttu-id="e7071-132">コンボ ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="e7071-132">Create a combo box</span></span>

<span data-ttu-id="e7071-133">[Items](/uwp/api/windows.ui.xaml.controls.itemscontrol.items)コレクションに直接オブジェクトを追加するか[ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティをデータ ソースにバインドすることによって、コンボ ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="e7071-133">You populate the combo box by adding objects directly to the [Items](/uwp/api/windows.ui.xaml.controls.itemscontrol.items) collection or by binding the [ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property to a data source.</span></span> <span data-ttu-id="e7071-134">[ComboBoxItem](/uwp/api/windows.ui.xaml.controls.comboboxitem)コンテナーでは、コンボ ボックスに追加された項目が改行されています。</span><span class="sxs-lookup"><span data-stu-id="e7071-134">Items added to the ComboBox are wrapped in [ComboBoxItem](/uwp/api/windows.ui.xaml.controls.comboboxitem) containers.</span></span>

<span data-ttu-id="e7071-135">XAML で追加された項目の単純なコンボ ボックスを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e7071-135">Here's a simple combo box with items added in XAML.</span></span>

```xaml
<ComboBox Header="Colors" PlaceholderText="Pick a color" Width="200">
    <x:String>Blue<x:String>
    <x:String>Green<x:String>
    <x:String>Red<x:String>
    <x:String>Yellow<x:String>
</ComboBox>
```

<span data-ttu-id="e7071-136">次の例では、コンボ ボックスを FontFamily オブジェクトのコレクションにバインドを示します。</span><span class="sxs-lookup"><span data-stu-id="e7071-136">The following example demonstrates binding a combo box to a collection of FontFamily objects.</span></span>

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

### <a name="item-selection"></a><span data-ttu-id="e7071-137">項目の選択</span><span class="sxs-lookup"><span data-stu-id="e7071-137">Item selection</span></span>

<span data-ttu-id="e7071-138">ListView や GridView のようにコンボ ボックスは[セレクター](/uwp/api/windows.ui.xaml.controls.primitives.selector)から派生したため、同じ標準的な方法でユーザーの選択内容を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="e7071-138">Like ListView and GridView, ComboBox is derived from [Selector](/uwp/api/windows.ui.xaml.controls.primitives.selector), so you can get the user’s selection in the same standard way.</span></span>

<span data-ttu-id="e7071-139">取得して、コンボ ボックスの[SelectedItem](/uwp/api/windows.ui.xaml.controls.primitives.selector.selecteditem)プロパティを使用して、項目の選択を設定し、または取得するか、または[SelectedIndex](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedindex)プロパティを使用して、選択した項目のインデックスを設定できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-139">You can get or set the combo box's selected item by using the [SelectedItem](/uwp/api/windows.ui.xaml.controls.primitives.selector.selecteditem) property, and get or set the index of the selected item by using the [SelectedIndex](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedindex) property.</span></span>

<span data-ttu-id="e7071-140">選択したデータ項目の特定のプロパティの値を取得するには、 [「selectedvalue」](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvalue)プロパティを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="e7071-140">To get the value of a particular property on the selected data item, you can use the [SelectedValue](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvalue) property.</span></span> <span data-ttu-id="e7071-141">この場合から値を取得するのには、選択した項目をどのプロパティを指定する[SelectedValuePath](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvaluepath)を設定します。</span><span class="sxs-lookup"><span data-stu-id="e7071-141">In this case, set the [SelectedValuePath](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvaluepath) to specify which property on the selected item to get the value from.</span></span>

> [!TIP]
> <span data-ttu-id="e7071-142">SelectedItem SelectedIndex を指定したりする既定の選択を設定すると、コンボ ボックス項目のコレクションを作成する前に、プロパティが設定されている場合、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="e7071-142">If you set SelectedItem or SelectedIndex to indicate the default selection, an exception occurs if the property is set before the combo box Items collection is populated.</span></span> <span data-ttu-id="e7071-143">XAML で項目を定義する場合を除き、コンボ ボックスの Loaded イベントを処理し、SelectedItem または SelectedIndex Loaded イベント ハンドラーで設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e7071-143">Unless you define your Items in XAML, it's best to handle the combo box Loaded event, and set SelectedItem or SelectedIndex in the Loaded event handler.</span></span>

<span data-ttu-id="e7071-144">XAML では、これらのプロパティにバインドしたり、選択内容の変更に応答する[SelectionChanged](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)イベントを処理できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-144">You can bind to these properties in XAML, or handle the [SelectionChanged](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged) event to respond to selection changes.</span></span>

<span data-ttu-id="e7071-145">イベント ハンドラーのコードは[SelectionChangedEventArgs.AddedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.addeditems)プロパティから選択した項目を取得できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-145">In the event handler code, you can get the selected item from the [SelectionChangedEventArgs.AddedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.addeditems) property.</span></span> <span data-ttu-id="e7071-146">選択した項目 (ある場合) は、 [SelectionChangedEventArgs.RemovedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.removeditems)プロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-146">You can get the previously selected item (if any) from the [SelectionChangedEventArgs.RemovedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.removeditems) property.</span></span> <span data-ttu-id="e7071-147">コンボ ボックスでは、複数選択をサポートしていないため、AddedItems コレクションと RemovedItems コレクション各が項目 1 つだけには含まれています。</span><span class="sxs-lookup"><span data-stu-id="e7071-147">The AddedItems and RemovedItems collections each contain only 1 item because combo box does not support multiple selection.</span></span>

<span data-ttu-id="e7071-148">この例では、選択した項目にバインドする方法と、SelectionChanged イベントを処理する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e7071-148">This example shows how to handle the SelectionChanged event, and also how to bind to the selected item.</span></span>

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

#### <a name="selectionchanged-and-keyboard-navigation"></a><span data-ttu-id="e7071-149">SelectionChanged とキーボード ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="e7071-149">SelectionChanged and keyboard navigation</span></span>

<span data-ttu-id="e7071-150">既定では、コンボ ボックスを閉じると、ユーザーがクリックした、タップ、または項目の選択が確定するリストで enter ときに SelectionChanged イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="e7071-150">By default, the SelectionChanged event occurs when a user clicks, taps, or presses Enter on an item in the list to commit their selection, and the combo box closes.</span></span> <span data-ttu-id="e7071-151">ユーザーはキーボードの方向キーで開くコンボ ボックスの一覧を移動するとき、選択範囲は変更されません。</span><span class="sxs-lookup"><span data-stu-id="e7071-151">Selection doesn't change when the user navigates the open combo box list with the keyboard arrow keys.</span></span>

<span data-ttu-id="e7071-152">コンボ ボックス作成その「ライブ更新」(フォント選択ドロップダウン) のような方向キーで、ユーザーが一覧を開きますを移動するときに、 [SelectionChangedTrigger](/uwp/api/windows.ui.xaml.controls.combobox.selectionchangedtrigger)を[Always](/uwp/api/windows.ui.xaml.controls.comboboxselectionchangedtrigger)に設定します。</span><span class="sxs-lookup"><span data-stu-id="e7071-152">To make a combo box that "live updates" while the user is navigating the open list with the arrow keys (like a Font selection drop-down), set [SelectionChangedTrigger](/uwp/api/windows.ui.xaml.controls.combobox.selectionchangedtrigger) to [Always](/uwp/api/windows.ui.xaml.controls.comboboxselectionchangedtrigger).</span></span> <span data-ttu-id="e7071-153">これにより、開いている一覧の別の項目にフォーカスが変更されたときに発生する SelectionChanged イベントします。</span><span class="sxs-lookup"><span data-stu-id="e7071-153">This causes the SelectionChanged event to occur when focus changes to another item in the open list.</span></span>

#### <a name="selected-item-behavior-change"></a><span data-ttu-id="e7071-154">選択した項目の動作の変更</span><span class="sxs-lookup"><span data-stu-id="e7071-154">Selected item behavior change</span></span>

<span data-ttu-id="e7071-155">RS5 で (Windows SDK バージョン 10.0.NNNNN.0 (Windows 10、バージョン YYMM) 選択した項目の動作が編集可能なコンボ ボックスをサポートするために更新されます。</span><span class="sxs-lookup"><span data-stu-id="e7071-155">In RS5 (Windows SDK version 10.0.NNNNN.0 (Windows 10, version YYMM), the behavior of selected items is updated to support editable combo boxes.</span></span>

<span data-ttu-id="e7071-156">RS5、SelectedItem プロパティの値より前 (つまり、「selectedvalue」と SelectedIndex) コンボ ボックスの項目のコレクション内にする必要がありました。</span><span class="sxs-lookup"><span data-stu-id="e7071-156">Prior to RS5, the value of the SelectedItem property (and therefore, SelectedValue and SelectedIndex) was required to be in the combo box's Items collection.</span></span> <span data-ttu-id="e7071-157">前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`結果します。</span><span class="sxs-lookup"><span data-stu-id="e7071-157">Using the previous example, setting `colorComboBox.SelectedItem = "Pink"` results in:</span></span>

- <span data-ttu-id="e7071-158">SelectedItem = null</span><span class="sxs-lookup"><span data-stu-id="e7071-158">SelectedItem = null</span></span>
- <span data-ttu-id="e7071-159">「Selectedvalue」= null</span><span class="sxs-lookup"><span data-stu-id="e7071-159">SelectedValue = null</span></span>
- <span data-ttu-id="e7071-160">SelectedIndex は-1</span><span class="sxs-lookup"><span data-stu-id="e7071-160">SelectedIndex = -1</span></span>

<span data-ttu-id="e7071-161">RS5 以降では、SelectedItem プロパティの値 (そのため、および「selectedvalue」と SelectedIndex) コンボ ボックスの項目のコレクション内にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e7071-161">In RS5 and later, the value of the SelectedItem property (and therefore, SelectedValue and SelectedIndex) is not required to be in the combo box's Items collection.</span></span> <span data-ttu-id="e7071-162">前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`結果します。</span><span class="sxs-lookup"><span data-stu-id="e7071-162">Using the previous example, setting `colorComboBox.SelectedItem = "Pink"` results in:</span></span>

- <span data-ttu-id="e7071-163">SelectedItem ピンク =</span><span class="sxs-lookup"><span data-stu-id="e7071-163">SelectedItem = Pink</span></span>
- <span data-ttu-id="e7071-164">「Selectedvalue」= ピンク</span><span class="sxs-lookup"><span data-stu-id="e7071-164">SelectedValue = Pink</span></span>
- <span data-ttu-id="e7071-165">SelectedIndex は-1</span><span class="sxs-lookup"><span data-stu-id="e7071-165">SelectedIndex = -1</span></span>

### <a name="text-search"></a><span data-ttu-id="e7071-166">テキスト検索</span><span class="sxs-lookup"><span data-stu-id="e7071-166">Text Search</span></span>

<span data-ttu-id="e7071-167">コンボ ボックスでは、コレクション内を自動的に検索できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-167">Combo boxes automatically support search within their collections.</span></span> <span data-ttu-id="e7071-168">開かれた状態または閉じた状態のコンボ ボックスにフォーカスがあるときに、物理的なキーボードで文字を入力すると、ユーザーが入力した文字列に一致する候補がビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="e7071-168">As users type characters on a physical keyboard while focused on an open or closed combo box, candidates matching the user's string are brought into view.</span></span> <span data-ttu-id="e7071-169">この機能は、長いリストを操作するときに特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e7071-169">This functionality is especially helpful when navigating a long list.</span></span> <span data-ttu-id="e7071-170">たとえば、州のリストが含まれているドロップダウンを操作するときに、ユーザーは"washington"ビューにすばやく選ぶ"w"キーを押してことができます。</span><span class="sxs-lookup"><span data-stu-id="e7071-170">For example, when interacting with a drop-down containing a list of states, users can press the "w" key to bring "Washington" into view for quick selection.</span></span> <span data-ttu-id="e7071-171">テキスト検索小文字は区別されません。</span><span class="sxs-lookup"><span data-stu-id="e7071-171">The text search is not case-sensitive.</span></span>

<span data-ttu-id="e7071-172">**False**をこの機能を無効にするには、 [IsTextSearchEnabled](/uwp/api/windows.ui.xaml.controls.combobox.istextsearchenabled)プロパティを設定できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-172">You can set the [IsTextSearchEnabled](/uwp/api/windows.ui.xaml.controls.combobox.istextsearchenabled) property to **false** to disable this functionality.</span></span>

## <a name="make-a-combo-box-editable"></a><span data-ttu-id="e7071-173">コンボ ボックスを編集します。</span><span class="sxs-lookup"><span data-stu-id="e7071-173">Make a combo box editable</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e7071-174">この機能[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)が必要です。</span><span class="sxs-lookup"><span data-stu-id="e7071-174">This feature requires the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/).</span></span>

<span data-ttu-id="e7071-175">コンボ ボックスで、ユーザーは既定では、オプションの事前に定義された一覧から選択します。</span><span class="sxs-lookup"><span data-stu-id="e7071-175">By default, a combo box lets the user select from a pre-defined list of options.</span></span> <span data-ttu-id="e7071-176">ただし、これには、有効な値のサブセットのみが一覧に含まれて、ユーザーに記載されていないその他の値を入力できる必要がありますである場合があります。</span><span class="sxs-lookup"><span data-stu-id="e7071-176">However, there are cases where the list contains only a subset of valid values, and the user should be able to enter other values that aren't listed.</span></span> <span data-ttu-id="e7071-177">これをサポートするには、ことができますコンボ ボックス編集可能です。</span><span class="sxs-lookup"><span data-stu-id="e7071-177">To support this, you can make the combo box editable.</span></span>

<span data-ttu-id="e7071-178">コンボ ボックスを編集するためには、 [IsEditable](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)プロパティを**true**に設定します。</span><span class="sxs-lookup"><span data-stu-id="e7071-178">To make a combo box editable, set the [IsEditable](/uwp/api/windows.ui.xaml.controls.combobox.iseditable) property to **true**.</span></span> <span data-ttu-id="e7071-179">次に、ユーザーが入力した値と連携する[TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="e7071-179">Then, handle the [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox) event to work with the value entered by the user.</span></span>

<span data-ttu-id="e7071-180">既定では、ユーザーのカスタム テキストをコミットすると、SelectedItem 値が更新されます。</span><span class="sxs-lookup"><span data-stu-id="e7071-180">By default, the SelectedItem value is updated when the user commits custom text.</span></span> <span data-ttu-id="e7071-181">この動作を上書きするには、 **Handled**を**true**に TextSubmitted イベント引数に設定します。</span><span class="sxs-lookup"><span data-stu-id="e7071-181">You can override this behavior by setting **Handled** to **true** in the TextSubmitted event args.</span></span> <span data-ttu-id="e7071-182">イベントが処理済みとしてマークし、コンボ ボックスは何も実行さらに、イベントの後に編集の状態に維持されます。</span><span class="sxs-lookup"><span data-stu-id="e7071-182">When the event is marked as handled, the combo box will take no further action after the event and will stay in the editing state.</span></span> <span data-ttu-id="e7071-183">SelectedItem が更新されなくなります。</span><span class="sxs-lookup"><span data-stu-id="e7071-183">SelectedItem will not be updated.</span></span>

<span data-ttu-id="e7071-184">この例では、単純な編集可能なコンボ ボックスを使用します。</span><span class="sxs-lookup"><span data-stu-id="e7071-184">This example shows a simple editable combo box.</span></span> <span data-ttu-id="e7071-185">一覧には、単純な文字列が含まれてされ、ユーザーが入力した任意の値が、入力に使用されます。</span><span class="sxs-lookup"><span data-stu-id="e7071-185">The list contains simple strings, and any value entered by the user is used as entered.</span></span>

<span data-ttu-id="e7071-186">「最近使った名前を」セレクターではユーザーがカスタム文字列を入力できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-186">A "recently used names" chooser lets the user enter custom strings.</span></span> <span data-ttu-id="e7071-187">'RecentlyUsedNames' 一覧にはから、ユーザーが選択できるいくつかの値が含まれていますが、ユーザーにも、カスタムの新しい値を追加できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-187">The 'RecentlyUsedNames' list contains some values that the user can choose from, but the user can also add a new, custom value.</span></span> <span data-ttu-id="e7071-188">'CurrentName' プロパティは、入力した現在の名前を表します。</span><span class="sxs-lookup"><span data-stu-id="e7071-188">The 'CurrentName' property represents the currently entered name.</span></span>

```xaml
<ComboBox IsEditable="true"
          ItemsSource="{x:Bind RecentlyUsedNames}"
          SelectedItem="{x:Bind CurrentName, Mode=TwoWay}"/>
```

### <a name="text-submitted"></a><span data-ttu-id="e7071-189">提出されたテキスト</span><span class="sxs-lookup"><span data-stu-id="e7071-189">Text submitted</span></span>

<span data-ttu-id="e7071-190">ユーザーが入力した値と連携する[TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)イベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="e7071-190">You can handle the [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox) event to work with the value entered by the user.</span></span> <span data-ttu-id="e7071-191">イベント ハンドラーでは通常を検証するユーザーが入力した値が有効である、アプリで値を使用します。</span><span class="sxs-lookup"><span data-stu-id="e7071-191">In the event handler, you will typically validate that the value entered by the user is valid, then use the value in your app.</span></span> <span data-ttu-id="e7071-192">状況によって将来使用するためのオプションのコンボ ボックスの一覧に値を追加することも可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e7071-192">Depending on the situation, you might also add the value to the combo box’s list of options for future use.</span></span>

<span data-ttu-id="e7071-193">TextSubmitted イベントは、これらの条件が満たされた場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="e7071-193">The TextSubmitted event occurs when these conditions are met:</span></span>

- <span data-ttu-id="e7071-194">IsEditable プロパティが**true**</span><span class="sxs-lookup"><span data-stu-id="e7071-194">The IsEditable property is **true**</span></span>
- <span data-ttu-id="e7071-195">ユーザーがコンボ ボックスの一覧の既存のエントリに一致しないテキストを入力します。</span><span class="sxs-lookup"><span data-stu-id="e7071-195">The user enters text that does not match an existing entry in the combo box list</span></span>
- <span data-ttu-id="e7071-196">ユーザーは、Enter を押すか、コンボ ボックスからフォーカスが移動します。</span><span class="sxs-lookup"><span data-stu-id="e7071-196">The user presses Enter, or moves focus from the combo box.</span></span>

<span data-ttu-id="e7071-197">ユーザーがテキストを入力し、一覧を上下に移動する場合、TextSubmitted イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="e7071-197">The TextSubmitted event does not occur if the user enters text and then navigates up or down through the list.</span></span>

### <a name="sample---validate-input-and-use-locally"></a><span data-ttu-id="e7071-198">サンプル - 入力を検証し、ローカルで使う</span><span class="sxs-lookup"><span data-stu-id="e7071-198">Sample - Validate input and use locally</span></span>

<span data-ttu-id="e7071-199">この examle では、フォント サイズの選択には、フォント サイズの見本に対応する値のセットが含まれていますが、ユーザーは、一覧にないフォント サイズを入力します。</span><span class="sxs-lookup"><span data-stu-id="e7071-199">In this examle, a font size chooser contains a set of values corresponding to the font size ramp, but the user may enter font sizes that are not in the list.</span></span>

<span data-ttu-id="e7071-200">フォント サイズの一覧には、ユーザーがリスト、フォント サイズ、更新プログラムは、値に含まれていない値を追加する場合は追加されません。</span><span class="sxs-lookup"><span data-stu-id="e7071-200">When the user adds a value that's not in the list, the font size updates, but the value is not added to the list of font sizes.</span></span>

<span data-ttu-id="e7071-201">新たに入力された値が無効な Text プロパティを最後に戻すには、「selectedvalue」を使用する場合は、適切な値に知られています。</span><span class="sxs-lookup"><span data-stu-id="e7071-201">If the newly entered value is not valid, you use the SelectedValue to revert the Text property to the last known good value.</span></span>

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

### <a name="sample---validate-input-and-add-to-list"></a><span data-ttu-id="e7071-202">サンプル - 入力を検証し、一覧に追加します。</span><span class="sxs-lookup"><span data-stu-id="e7071-202">Sample - Validate input and add to list</span></span>

<span data-ttu-id="e7071-203">ここでは、「好きな色の選択」には、最も一般的な好みの色 (赤、青、緑、オレンジ色) が含まれていますが、ユーザーは、一覧に含まれていない好きな色を入力します。</span><span class="sxs-lookup"><span data-stu-id="e7071-203">Here, a "favorite color chooser" contains the most common favorite colors (Red, Blue, Green, Orange), but the user may enter a favorite color that's not in the list.</span></span> <span data-ttu-id="e7071-204">ユーザーは、(ピンク) のように有効な色を追加するとき、新たに入力された色がリストに追加し、「好きな色」アクティブとして設定します。</span><span class="sxs-lookup"><span data-stu-id="e7071-204">When the user adds a valid color (like Pink), the newly entered color is added to the list and set as the active "favorite color".</span></span>

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

## <a name="dos-and-donts"></a><span data-ttu-id="e7071-205">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="e7071-205">Do's and don'ts</span></span>

- <span data-ttu-id="e7071-206">コンボ ボックス項目のテキストのコンテンツは、単一行に制限します。</span><span class="sxs-lookup"><span data-stu-id="e7071-206">Limit the text content of combo box items to a single line.</span></span>
- <span data-ttu-id="e7071-207">コンボ ボックス内の項目は、最も論理的な順序に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="e7071-207">Sort items in a combo box in the most logical order.</span></span> <span data-ttu-id="e7071-208">関連するオプションをグループ化し、最も一般的なオプションを先頭に配置します。</span><span class="sxs-lookup"><span data-stu-id="e7071-208">Group together related options and place the most common options at the top.</span></span> <span data-ttu-id="e7071-209">名前はアルファベット順、数値は数値順、日付は時系列順に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="e7071-209">Sort names in alphabetical order, numbers in numerical order, and dates in chronological order.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="e7071-210">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="e7071-210">Get the sample code</span></span>

- <span data-ttu-id="e7071-211">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="e7071-211">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="e7071-212">AutoSuggestBox サンプル</span><span class="sxs-lookup"><span data-stu-id="e7071-212">AutoSuggestBox sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlAutoSuggestBox)

## <a name="related-articles"></a><span data-ttu-id="e7071-213">関連記事</span><span class="sxs-lookup"><span data-stu-id="e7071-213">Related articles</span></span>

- [<span data-ttu-id="e7071-214">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="e7071-214">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="e7071-215">スペル チェック</span><span class="sxs-lookup"><span data-stu-id="e7071-215">Spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="e7071-216">検索</span><span class="sxs-lookup"><span data-stu-id="e7071-216">Search</span></span>](search.md)
- [<span data-ttu-id="e7071-217">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="e7071-217">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="e7071-218">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="e7071-218">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="e7071-219">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="e7071-219">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length.aspx)
