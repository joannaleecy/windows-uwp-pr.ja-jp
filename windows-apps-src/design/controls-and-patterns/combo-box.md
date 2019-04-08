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
# <a name="combo-box"></a>コンボ ボックス

ユーザーが選択できる項目の一覧を提供するのにには、コンボ ボックス (ドロップダウン リストとも呼ばれます) を使用します。 コンボ ボックスでは、コンパクトな状態で開始し、選択可能な項目の一覧を表示する展開します。

コンボ ボックスが閉じられたときに表示され、現在の選択か選択した項目がない場合は空です。 ユーザーがコンボ ボックスを展開すると、選択可能な項目の一覧が表示されます。

> **重要な API**:[コンボ ボックス クラス](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [IsEditable プロパティ](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)、 [Text プロパティ](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [TextSubmitted イベント](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)

ヘッダーと圧縮の状態でコンボ ボックス。

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

- 1 行のテキストで十分に表すことができる項目のセットから、ユーザーが単一の値を選ぶことができるようにするには、ドロップダウン リストを使います。
- 複数のテキスト行や画像が含まれる項目を表示するには、コンボ ボックスではなくリスト ビューまたはグリッド ビューを使います。
- 項目が 5 個より少ない場合は、[ラジオ ボタン](radio-button.md) (1 つの項目だけを選ぶことができる場合)、または[チェック ボックス](checkbox.md) (複数の項目を選ぶことができる場合) の使用を検討します。
- 選択項目がアプリのフローにおいて二次的な重要性しか持たない場合は、コンボ ボックスを使います。 多くの状況でほとんどのユーザーに対して既定のオプションが推奨されている場合、リスト ビューを使ってすべての項目を表示すると、既定以外のオプションに必要以上の注意を引いてしまう可能性があります。 コンボ ボックスを使うことで、領域を節約し、無駄な情報を最小限にすることができます。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p>ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/ComboBox">アプリを開き、コンボ ボックスの動作を参照してください。</a>します。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

コンパクトな状態のコンボ ボックスには、ヘッダーを表示できます。

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

コンボ ボックスは、長い文字列の幅をサポートするために拡張できますが、読みづらくなるような長すぎる文字列は使わないでください。

![長い文字列のドロップダウン リストの例](images/combo_box_listitemstate.png)

コンボ ボックス内のコレクションが一定の長さに達すると、対応できるようにスクロール バーが表示されます。 リスト内の項目は論理的にグループ化します。

![ドロップダウン リストに表示されたスクロール バーの例](images/combo_box_scroll.png)

## <a name="create-a-combo-box"></a>コンボ ボックスを作成します。

直接オブジェクトを追加することで、コンボ ボックスに入力する、[項目](/uwp/api/windows.ui.xaml.controls.itemscontrol.items)コレクションまたはバインドすることによって、 [ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティをデータ ソース。 コンボ ボックスに追加された項目にラップされます[や ComboBoxItem](/uwp/api/windows.ui.xaml.controls.comboboxitem)コンテナー。

XAML で追加された項目を含む単純なコンボ ボックスを次に示します。

```xaml
<ComboBox Header="Colors" PlaceholderText="Pick a color" Width="200">
    <x:String>Blue</x:String>
    <x:String>Green</x:String>
    <x:String>Red</x:String>
    <x:String>Yellow</x:String>
</ComboBox>
```

次の例では、コンボ ボックスの FontFamily オブジェクトのコレクションへのバインディングを示します。

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

### <a name="item-selection"></a>項目の選択

ListView、GridView などコンボ ボックスはから派生[セレクター](/uwp/api/windows.ui.xaml.controls.primitives.selector)、標準と同様に、ユーザーの選択を取得できるようにします。

取得またはを使用して、コンボ ボックスの選択された項目を設定することができます、 [SelectedItem](/uwp/api/windows.ui.xaml.controls.primitives.selector.selecteditem)プロパティ、および get または set を使用して、選択した項目のインデックス、 [SelectedIndex](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedindex)プロパティ。

使用することを選択したデータ項目の特定のプロパティの値を取得する、 [SelectedValue](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvalue)プロパティ。 この場合、設定、 [SelectedValuePath](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvaluepath)から値を取得する選択項目にプロパティを指定します。

> [!TIP]
> 既定の選択を示すためには、SelectedItem または SelectedIndex を設定すると、コンボ ボックス項目のコレクションを設定する前に、プロパティが設定されている場合、例外が発生します。 XAML でアイテムを定義する場合を除き、コンボ ボックスの Loaded イベントを処理し、Loaded イベント ハンドラーで SelectedItem または SelectedIndex を設定することをお勧めします。

XAML では、これらのプロパティにバインドしたり、処理、 [SelectionChanged](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)選択の変更に応答するイベントです。

イベント ハンドラーのコードを取得できますから選択されたアイテム、 [SelectionChangedEventArgs.AddedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.addeditems)プロパティ。 取得できます、以前に選択した項目 (ある場合)、 [SelectionChangedEventArgs.RemovedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.removeditems)プロパティ。 AddedItems と RemovedItems のそれぞれのコレクションには、コンボ ボックスが複数選択をサポートしていないために、1 項目のみが含まれます。

この例では、選択した項目にバインドする方法と、SelectionChanged イベントを処理する方法を示します。

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

#### <a name="selectionchanged-and-keyboard-navigation"></a>SelectionChanged とキーボードのナビゲーション

既定では、SelectionChanged イベントは、コンボ ボックスが閉じ、ユーザーがクリックして、タップ、または enter を押すと、項目を自分の選択をコミットする一覧と発生します。 ユーザーがキーボードの矢印キーを開いているコンボ ボックスの一覧を移動すると、選択は変更されません。

ユーザーは一覧を開きます (フォントの選択ボックスの一覧) のように、矢印キーで移動する際に、その「ライブ更新」をボックス コンボをするためには、次のように設定します。 [SelectionChangedTrigger](/uwp/api/windows.ui.xaml.controls.combobox.selectionchangedtrigger)に[常に](/uwp/api/windows.ui.xaml.controls.comboboxselectionchangedtrigger)します。 これにより、オープン リスト内の別の項目にフォーカスが変更されたときに発生する SelectionChanged イベントです。

#### <a name="selected-item-behavior-change"></a>選択した項目の動作の変更

Windows 10、バージョンは 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) や、編集可能なコンボ ボックスをサポートするために選択した項目の動作が更新された後で、します。

SDK 17763、SelectedItem プロパティの値の前に (とそのため、SelectedValue および SelectedIndex) コンボ ボックスの項目のコレクションに存在する必要があります。 前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`結果します。

- SelectedItem = null
- SelectedValue = null
- SelectedIndex =-1

Sdk 17763 以降、SelectedItem プロパティの値 (とそのため、SelectedValue および SelectedIndex) コンボ ボックスの項目のコレクションに存在する必要はありません。 前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`結果します。

- SelectedItem = pink」と入力
- SelectedValue = pink」と入力
- SelectedIndex =-1

### <a name="text-search"></a>テキスト検索

コンボ ボックスでは、コレクション内を自動的に検索できます。 開かれた状態または閉じた状態のコンボ ボックスにフォーカスがあるときに、物理的なキーボードで文字を入力すると、ユーザーが入力した文字列に一致する候補がビューに表示されます。 この機能は、長いリストを操作するときに特に役立ちます。 たとえば、状態の一覧を含むドロップダウンを扱うときにユーザーのユーザーは、迅速な選択に"Washington"の表示を"w"キーを押すできます。 フルテキスト検索は区別されません。

設定することができます、 [IsTextSearchEnabled](/uwp/api/windows.ui.xaml.controls.combobox.istextsearchenabled)プロパティを**false**この機能を無効にします。

## <a name="make-a-combo-box-editable"></a>コンボ ボックスを編集可能します。

> [!IMPORTANT]
> この機能は、Windows 10、バージョンは 1809 を必要があります ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。

既定では、コンボ ボックスには、ユーザーができるように事前に定義されているオプションの一覧から選択します。 ただし、これには、一覧には、有効な値のサブセットのみが含まれています、ユーザーが示されていないその他の値を入力できる場合があります。 これをサポートするには、行うことができます、コンボ ボックス編集できます。

コンボ ボックスを編集するためには、設定、 [IsEditable](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)プロパティを**true**します。 次に、処理、 [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)ユーザーが入力した値を使用するイベントです。

既定では、ユーザーがカスタム テキストをコミット時に、SelectedItem 値が更新されます。 設定してこの動作をオーバーライドできます**処理済み**に**true** TextSubmitted イベントの引数にします。 イベントが処理済みとしてマークされている、コンボ ボックスは、イベント後にこれ以上の操作を実行しないと、編集の状態のままとなります。 SelectedItem は更新されません。

この例では、単純な編集可能なコンボ ボックスを使用します。 一覧には、単純な文字列が含まれていて、入力時に、ユーザーが入力した任意の値を使用します。

「最近使った名前を」の選択には、カスタム文字列を入力します。 ユーザーことができます。 'RecentlyUsedNames' 一覧には、ユーザーが選択できる、いくつかの値が含まれていますが、ユーザーは、新しいカスタム値を追加もできます。 'CurrentName' プロパティは、現在入力した名前を表します。

```xaml
<ComboBox IsEditable="true"
          ItemsSource="{x:Bind RecentlyUsedNames}"
          SelectedItem="{x:Bind CurrentName, Mode=TwoWay}"/>
```

### <a name="text-submitted"></a>送信されるテキスト

処理することができます、 [TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)ユーザーが入力した値を使用するイベントです。 イベント ハンドラーは通常を検証する、ユーザーが入力した値が有効であるには、アプリで、値を使用します。 状況によっては、将来使用するためのオプションのコンボ ボックスの一覧を値を追加することも可能性があります。

TextSubmitted イベントは、これらの条件が満たされたときに発生します。

- IsEditable プロパティは**は true。**
- ユーザーがコンボ ボックスの一覧で既存のエントリに一致しないテキストを入力します。
- ユーザーは、Enter キーを押すか、コンボ ボックスからフォーカスを移動します。

ユーザーがテキストを入力し、一覧を上下に移動する場合、TextSubmitted イベントは発生しません。

### <a name="sample---validate-input-and-use-locally"></a>サンプル - 入力を検証し、ローカルで使用

この例では、フォント サイズの選択には、フォント サイズのランプに対応する値のセットが含まれていますが、ユーザーは、一覧にないフォント サイズを入力します。

ユーザーが、フォント サイズ、更新プログラムのリストは、値ではない値を追加するときは、フォント サイズの一覧には追加されません。

新しく入力した値が無効ですが、最後の Text プロパティを元に戻す、SelectedValue を使用する場合は、有効な値を知られています。

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

### <a name="sample---validate-input-and-add-to-list"></a>サンプル - 入力を検証し、一覧に追加

ここでは、「好きな色選択」には、最も一般的なの好きな色 (赤、青、緑、オレンジ色) が含まれていますが、ユーザーは、一覧に含まれていない好きな色を入力します。 ユーザーは、(ピンク) などの有効な色を追加するときに新しく入力色がリストに追加し、「好きな色」アクティブとして設定。

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

## <a name="dos-and-donts"></a>推奨と非推奨

- コンボ ボックス項目のテキストのコンテンツは、単一行に制限します。
- コンボ ボックス内の項目は、最も論理的な順序に並べ替えます。 関連するオプションをグループ化し、最も一般的なオプションを先頭に配置します。 名前はアルファベット順、数値は数値順、日付は時系列順に並べ替えます。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。
- [AutoSuggestBox サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlAutoSuggestBox)

## <a name="related-articles"></a>関連記事

- [テキスト コントロール](text-controls.md)
- [スペル チェック](text-controls.md)
- [検索](search.md)
- [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/br209683)
- [Windows.UI.Xaml.Controls PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/br227519)
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length.aspx)
