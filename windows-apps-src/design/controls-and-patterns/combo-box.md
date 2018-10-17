---
author: Jwmsft
Description: A text entry box that provides suggestions as the user types.
title: コンボ ボックス (ドロップダウン リスト)
label: Combo box
template: detail.hbs
ms.author: jimwalk
ms.date: 10/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: ''
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 518ce49ddb631e3e914a6c7662b4e74de247c29c
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4743322"
---
# <a name="combo-box"></a>コンボ ボックス

ユーザーが選択できる項目の一覧を表示するのにには、コンボ ボックス (ドロップダウン リストとも呼ばれます) を使用します。 コンボ ボックスでは、コンパクトな状態で開始し、展開を選択できる項目の一覧を表示します。

コンボ ボックスを閉じると、現在の選択範囲を表示するか選択された項目がない場合は空です。 ユーザーがコンボ ボックスを展開するときは、選択可能な項目の一覧を表示します。

> **重要な Api**: [ComboBox クラス](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [IsEditable プロパティ](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)、 [Text プロパティ](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、 [TextSubmitted イベント](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)

コンボ ボックス、ヘッダーを含むコンパクトな状態にします。

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
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールした場合は、アプリを<a href="xamlcontrolsgallery:/item/ComboBox">開き、コンボ ボックスの動作を参照してください</a>ここをクリックします。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
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

[Items](/uwp/api/windows.ui.xaml.controls.itemscontrol.items)コレクションに直接オブジェクトを追加するか[ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティをデータ ソースにバインドすることによって、コンボ ボックスを作成します。 [ComboBoxItem](/uwp/api/windows.ui.xaml.controls.comboboxitem)コンテナーでは、コンボ ボックスに追加された項目が改行されています。

XAML で追加された項目の単純なコンボ ボックスを次に示します。

```xaml
<ComboBox Header="Colors" PlaceholderText="Pick a color" Width="200">
    <x:String>Blue<x:String>
    <x:String>Green<x:String>
    <x:String>Red<x:String>
    <x:String>Yellow<x:String>
</ComboBox>
```

次の例では、コンボ ボックスを FontFamily オブジェクトのコレクションにバインドを示します。

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

ListView や GridView のように ComboBox は[セレクター](/uwp/api/windows.ui.xaml.controls.primitives.selector)から派生したため、同じ標準的な方法でユーザーの選択内容を取得することができます。

取得して、 [SelectedItem](/uwp/api/windows.ui.xaml.controls.primitives.selector.selecteditem)プロパティを使用して、項目の選択、コンボ ボックスを設定し、または取得するか、または[SelectedIndex](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedindex)プロパティを使用して、選択した項目のインデックスを設定できます。

選択したデータ項目の特定のプロパティの値を取得するには、 [「selectedvalue」](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvalue)プロパティを使用することができます。 この例から値を取得するのには、選択した項目をどのプロパティを指定する[SelectedValuePath](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectedvaluepath)を設定します。

> [!TIP]
> 既定の選択を示すためには、SelectedItem または SelectedIndex を設定すると、コンボ ボックス項目のコレクションが指定されている前に、プロパティが設定されている場合、例外が発生します。 XAML で項目を定義する場合を除き、コンボ ボックスの Loaded イベントを処理し、SelectedItem または SelectedIndex Loaded イベント ハンドラーで設定することをお勧めします。

XAML では、これらのプロパティにバインドしたり、選択内容の変更に応答する[SelectionChanged](/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)イベントを処理することができます。

イベント ハンドラーのコード[SelectionChangedEventArgs.AddedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.addeditems)プロパティから、選択した項目を取得できます。 (ある場合)、以前に選択した項目は、 [SelectionChangedEventArgs.RemovedItems](/uwp/api/windows.ui.xaml.controls.selectionchangedeventargs.removeditems)プロパティから取得できます。 AddedItems と RemovedItems の各のコレクションには、コンボ ボックスでは、複数選択をサポートしていないために、1 つだけの項目が含まれます。

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

#### <a name="selectionchanged-and-keyboard-navigation"></a>SelectionChanged とキーボード ナビゲーション

既定では、コンボ ボックスを閉じると、ユーザーがクリックした、タップ、または項目で Enter の選択が確定する一覧に SelectionChanged イベントが発生します。 選択範囲は、ユーザーがキーボードの方向キーで開くコンボ ボックスの一覧を移動するときに変更されません。

更新コンボ ボックス作成その"ライブ"(フォント選択ドロップダウン) のような方向キーで、ユーザーが一覧を開きますを移動するときに、 [SelectionChangedTrigger](/uwp/api/windows.ui.xaml.controls.combobox.selectionchangedtrigger)を[Always](/uwp/api/windows.ui.xaml.controls.comboboxselectionchangedtrigger)に設定します。 これにより、開いている一覧の別の項目にフォーカスが変更されたときに発生する SelectionChanged イベントが発生します。

#### <a name="selected-item-behavior-change"></a>選択した項目の動作の変更

RS5 で (Windows SDK バージョン 10.0.NNNNN.0 (Windows 10、バージョン YYMM) 選択した項目の動作が編集可能なコンボ ボックスをサポートするために更新されます。

RS5、SelectedItem プロパティの値の前に (およびそのため、「selectedvalue」と SelectedIndex)、コンボ ボックス項目のコレクション内にする必要がありました。 前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`の結果します。

- SelectedItem = null
- 「Selectedvalue」= null
- SelectedIndex は-1

RS5 以降では、SelectedItem プロパティの値 (つまり、「selectedvalue」と SelectedIndex)、コンボ ボックス項目のコレクション内にする必要はありません。 前の例では、設定を使用して`colorComboBox.SelectedItem = "Pink"`の結果します。

- SelectedItem ピンク =
- 「Selectedvalue」ピンク =
- SelectedIndex は-1

### <a name="text-search"></a>テキスト検索

コンボ ボックスでは、コレクション内を自動的に検索できます。 開かれた状態または閉じた状態のコンボ ボックスにフォーカスがあるときに、物理的なキーボードで文字を入力すると、ユーザーが入力した文字列に一致する候補がビューに表示されます。 この機能は、長いリストを操作するときに特に役立ちます。 たとえば、州のリストが含まれているドロップダウンを操作するときに、ユーザーは"washington"ビューにすばやく選ぶ"w"キーを押してことができます。 テキスト検索小文字は区別されません。

**False**をこの機能を無効にするには、 [IsTextSearchEnabled](/uwp/api/windows.ui.xaml.controls.combobox.istextsearchenabled)プロパティを設定できます。

## <a name="make-a-combo-box-editable"></a>コンボ ボックスを編集します。

> [!IMPORTANT]
> この機能[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)が必要です。

コンボ ボックスで、ユーザーは既定では、オプションの事前に定義された一覧から選択します。 ただし、これには、有効な値のサブセットのみが一覧に含まれて、ユーザーに記載されていないその他の値を入力できる必要がありますである場合があります。 これをサポートするには、ことができますコンボ ボックス編集可能です。

コンボ ボックスを編集するには、 [IsEditable](/uwp/api/windows.ui.xaml.controls.combobox.iseditable)プロパティを**true**に設定します。 次に、ユーザーが入力した値を操作する[TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)イベントを処理します。

既定では、ユーザーがカスタム テキストをコミットすると、SelectedItem 値が更新されます。 この動作を上書きするには、 **Handled**を**true** TextSubmitted イベント引数で設定します。 イベントが処理済みとしてマークし、コンボ ボックスは何も実行さらに、イベントの後に編集の状態に維持されます。 SelectedItem が更新されなくなります。

この例では、単純な編集可能なコンボ ボックスを使用します。 一覧には、単純な文字列が含まれてされ、ユーザーが入力した任意の値が、入力に使用されます。

「最近使った名前を」の選択には、カスタムの文字列を入力します。 ユーザーことができます。 'RecentlyUsedNames' リストには、ユーザーが選択できる、いくつかの値が含まれていますが、ユーザーにも、カスタムの新しい値を追加できます。 'CurrentName' プロパティは、現在の入力の名前を表します。

```xaml
<ComboBox IsEditable="true"
          ItemsSource="{x:Bind RecentlyUsedNames}"
          SelectedItem="{x:Bind CurrentName, Mode=TwoWay}"/>
```

### <a name="text-submitted"></a>提出されたテキスト

ユーザーが入力した値を操作する[TextSubmitted](/uwp/api/Windows.UI.Xaml.Controls.ComboBox)イベントを処理することができます。 イベント ハンドラーでは通常を検証するユーザーが入力した値が有効である、アプリで、値を使用します。 状況によって後で使用するためのオプションのコンボ ボックスの一覧に値を追加することも可能性があります。

TextSubmitted イベントは、これらの条件が満たされた場合に発生します。

- IsEditable プロパティが**true**
- ユーザーがコンボ ボックスの一覧の既存のエントリに一致しないテキストを入力します。
- ユーザーは、Enter キーを押したまたはコンボ ボックスからフォーカスが移動します。

TextSubmitted イベントは、ユーザーがテキストを入力し、一覧を上下に移動する場合に発生しません。

### <a name="sample---validate-input-and-use-locally"></a>サンプル - 入力を検証し、ローカルで使用

この examle では、フォント サイズの選択には、フォント サイズの見本に対応する値のセットが含まれていますが、ユーザーは、一覧にないフォント サイズを入力します。

フォント サイズの一覧には、ユーザーがリスト、フォント サイズの更新プログラムは、値に含まれていない値を追加する場合は追加されません。

新たに入力された値が無効な Text プロパティを最後に戻すには、「selectedvalue」を使用する場合は、適切な値に知られています。

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

### <a name="sample---validate-input-and-add-to-list"></a>サンプル - 入力を検証し、一覧に追加します。

ここでは、「好きな色選択」には、最も一般的な好みの色 (赤、青、緑、Orange) が含まれていますが、ユーザーは、一覧に含まれていない好きな色を入力します。 ユーザーは、(ピンク) のように有効な色を追加するとき、新たに入力された色が一覧に追加し、「好きな色」アクティブとして設定します。

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

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。
- [AutoSuggestBox サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlAutoSuggestBox)

## <a name="related-articles"></a>関連記事

- [テキスト コントロール](text-controls.md)
- [スペル チェック](text-controls.md)
- [検索](search.md)
- [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/br209683)
- [Windows.UI.Xaml.Controls PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/br227519)
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length.aspx)
