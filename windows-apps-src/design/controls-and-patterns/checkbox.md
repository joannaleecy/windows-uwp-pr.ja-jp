---
author: QuinnRadich
Description: Used to select or deselect action items. Can be used for a single list item or for multiple list items.
title: チェック ボックス
ms.assetid: 6231A806-287D-43EE-BD8D-39D2FF761914
label: Check boxes
template: detail.hbs
ms.author: quradic
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a3e6180c23208f02c3f7fb2294eabe2ee080f504
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4053322"
---
# <a name="check-boxes"></a>チェック ボックス

 

チェック ボックスは、アクション項目の選択や選択解除を行うときに使います。 また、チェック ボックスはユーザーが選択する単一の項目や複数の項目の一覧に対して使うことができます。 コントロールには 3 つの選択状態 (選択されていない、選択されている、不確定) があります。 不確定状態は、選択されていない状態と選択されている状態の両方がサブ選択肢のコレクションに含まれている場合に使います。

> **重要な API**: [CheckBox クラス](https://msdn.microsoft.com/library/windows/apps/br209316)、[Checked イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.checked.aspx)、[IsChecked プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx)

![チェック ボックスの状態の例](images/templates-checkbox-states-default.png)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

**1 つのチェック ボックス**を使うのは、"このアカウントを記憶する" ログイン シナリオや、 サービス契約の条項など、はい/いいえの二者択一の選択肢の場合です。

![個人的な選択のための 1 つのチェック ボックス](images/checkbox1.png)

二者択一の場合、**チェック ボックス**と[トグル スイッチ](toggles.md)との主な違いは、チェック ボックスが状態を管理し、トグル スイッチが動作を管理する点です。 チェック ボックスによる操作はコミットを遅らせることができますが (たとえばフォームの送信の一部として)、トグル スイッチによる操作は直ちにコミットしなければなりません。 また、複数の選択ができるのは、チェック ボックスだけです。

**複数のチェック ボックス**を使うのは、複数選択シナリオの場合 (ユーザーが相互排他的でない選択肢のグループから 1 つ以上の項目を選ぶ場合) です。

ユーザーがオプションの任意の組み合わせを選べる場合は、チェック ボックスのグループを作成します。

![チェック ボックスでの複数のオプションの選択](images/checkbox2.png)

オプションをグループ化できる場合は、不確定状態のチェック ボックスを使ってグループ全体を表すことができます。 グループ内のすべてでなく一部のサブ項目をユーザーが選択する場合は、チェック ボックスの不確定の状態を使います。

![混在する選択を示すために使用されるチェック ボックス](images/checkbox3.png)

**チェック ボックス** コントロールと**ラジオ ボタン** コントロールの両方を使うと、ユーザーはオプションの一覧から選択できます。 チェック ボックスを使うと、ユーザーはオプションの組み合わせを選択できます。 これに対し、ラジオ ボタンを使うと、ユーザーは相互排他的なオプションの中から 1 つのオプションを選択できます。 1 つ以上のオプションがあっても、選択できるのが 1 つだけの場合は、代わりにラジオ ボタンを使います。

## <a name="examples"></a>例

<table>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/CheckBox">アプリを開き、CheckBox の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-checkbox"></a>チェック ボックスを作成する

チェック ボックスにラベルを割り当てるには、[Content](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content.aspx) プロパティを設定します。 ラベルはチェック ボックスの横に表示されます。

次の XAML は、フォームの送信前にサービス条件に同意するために使う単一のチェック ボックスを作成します。 

```xaml
<CheckBox x:Name="termsOfServiceCheckBox" 
          Content="I agree to the terms of service."/>
```

同じチェック ボックスをコードで作成すると、次のようになります。

```csharp
CheckBox checkBox1 = new CheckBox();
checkBox1.Content = "I agree to the terms of service.";
```

### <a name="bind-to-ischecked"></a>IsChecked にバインドする

チェック ボックスがオンになっているかオフになっているかを判断するには、[IsChecked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx) プロパティを使います。 IsChecked プロパティの値を他のバイナリ値にバインドできます。 ただし、IsChecked は [null 許容](https://msdn.microsoft.com/library/windows/apps/b3h38hb0.aspx)のブール値であるため、値コンバーターを使ってブール値にバインドする必要があります。

次の例では、サービス条件に同意するためのチェック ボックスの **IsChecked** プロパティが送信ボタンの [IsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isenabled.aspx) プロパティにバインドされます。 送信ボタンは、サービス条件に同意した場合にのみ有効です。

> 注&nbsp;&nbsp;ここには関連するコードのみ掲載しています。 データ バインディングと値コンバーターについて詳しくは、「[データ バインディングの概要](../../data-binding/data-binding-quickstart.md)」をご覧ください。

```xaml
...
<Page.Resources>
    <local:NullableBooleanToBooleanConverter x:Key="NullableBooleanToBooleanConverter"/>
</Page.Resources>

...

<StackPanel Grid.Column="2" Margin="40">
    <CheckBox x:Name="termsOfServiceCheckBox" Content="I agree to the terms of service."/>
    <Button Content="Submit" 
            IsEnabled="{x:Bind termsOfServiceCheckBox.IsChecked, 
                        Converter={StaticResource NullableBooleanToBooleanConverter}, Mode=OneWay}"/>
</StackPanel>
```

```csharp
public class NullableBooleanToBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool?)
        {
            return (bool)value;
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is bool)
            return (bool)value;
        return false;
    }
}
```

### <a name="handle-click-and-checked-events"></a>Click イベントと Checked イベントを処理する

チェック ボックスの状態が変化したときにアクションを実行するには、[Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベント、または [Checked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.checked.aspx) イベントと [Unchecked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.unchecked.aspx) イベントを処理できます。 

**Click** イベントはオンの状態が変化するたびに発生します。 Click イベントを処理する場合は、**IsChecked** プロパティを使ってチェック ボックスの状態を確認します。

**Checked** イベントと **Unchecked** イベントは別々に発生します。 これらのイベントを処理する場合は、チェック ボックスの状態の変化に応じて両方のイベントを処理する必要があります。

次の例では、Click イベントの処理、および Checked イベントと Unchecked イベントの処理を示します。

同じイベント ハンドラーを複数のチェック ボックスで共有できます。 この例では、ピザのトッピングを選ぶための 4 つのチェック ボックスを作成します。 4 つのチェック ボックスで同じ **Click** イベント ハンドラーを共有して、選んだトッピングの一覧を更新します。

```XAML
<StackPanel Margin="40">
    <TextBlock Text="Pizza Toppings"/>
    <CheckBox Content="Pepperoni" x:Name="pepperoniCheckbox"
              Click="toppingsCheckbox_Click"/>
    <CheckBox Content="Beef" x:Name="beefCheckbox" 
              Click="toppingsCheckbox_Click"/>
    <CheckBox Content="Mushrooms" x:Name="mushroomsCheckbox"
              Click="toppingsCheckbox_Click"/>
    <CheckBox Content="Onions" x:Name="onionsCheckbox"
              Click="toppingsCheckbox_Click"/>

    <!-- Display the selected toppings. -->
    <TextBlock Text="Toppings selected:"/>
    <TextBlock x:Name="toppingsList"/>
</StackPanel>
```

Click イベントのイベント ハンドラーを次に示します。 チェック ボックスがクリックされるたびにチェック ボックスを調べ、どれがオンになっているかを確認し、選んだトッピングの一覧を更新します。

```csharp
private void toppingsCheckbox_Click(object sender, RoutedEventArgs e)
{
    string selectedToppingsText = string.Empty;
    CheckBox[] checkboxes = new CheckBox[] { pepperoniCheckbox, beefCheckbox,
                                             mushroomsCheckbox, onionsCheckbox };
    foreach (CheckBox c in checkboxes)
    {
        if (c.IsChecked == true)
        {
            if (selectedToppingsText.Length > 1)
            {
                selectedToppingsText += ", ";
            }
            selectedToppingsText += c.Content;
        }
    }
    toppingsList.Text = selectedToppingsText;
}
```

### <a name="use-the-indeterminate-state"></a>不確定の状態を使用する

CheckBox コントロールは [ToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.aspx) を継承します。また、このコントロールには 3 つの状態を指定できます。 

状態 | プロパティ | 値
------|----------|------
オン | IsChecked | **true** 
オフ | IsChecked | **false** 
不確定 | IsChecked | **null** 

不確定の状態を報告するチェック ボックスの場合、[IsThreeState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.isthreestate.aspx) プロパティを **true** に設定する必要があります。 

オプションをグループ化できる場合は、不確定状態のチェック ボックスを使ってグループ全体を表すことができます。 グループ内のすべてでなく一部のサブ項目をユーザーが選択する場合は、チェック ボックスの不確定の状態を使います。

次の例では、[すべて選択] チェック ボックスの IsThreeState プロパティを **true** に設定します。 [すべて選択] チェック ボックスは、すべての子要素がオンになっている場合はオンになり、すべての子要素がオフになっている場合はオフになり、それ以外の場合は不確定の状態になります。

```xaml
<StackPanel>
    <CheckBox x:Name="OptionsAllCheckBox" Content="Select all" IsThreeState="True" 
              Checked="SelectAll_Checked" Unchecked="SelectAll_Unchecked" 
              Indeterminate="SelectAll_Indeterminate"/>
    <CheckBox x:Name="Option1CheckBox" Content="Option 1" Margin="24,0,0,0" 
              Checked="Option_Checked" Unchecked="Option_Unchecked" />
    <CheckBox x:Name="Option2CheckBox" Content="Option 2" Margin="24,0,0,0" 
              Checked="Option_Checked" Unchecked="Option_Unchecked" IsChecked="True"/>
    <CheckBox x:Name="Option3CheckBox" Content="Option 3" Margin="24,0,0,0"
              Checked="Option_Checked" Unchecked="Option_Unchecked" />
</StackPanel>
```

```csharp
private void Option_Checked(object sender, RoutedEventArgs e)
{
    SetCheckedState();
}

private void Option_Unchecked(object sender, RoutedEventArgs e)
{
    SetCheckedState();
}

private void SelectAll_Checked(object sender, RoutedEventArgs e)
{
    Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = true;
}

private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
{
    Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = false;
}

private void SelectAll_Indeterminate(object sender, RoutedEventArgs e)
{
    // If the SelectAll box is checked (all options are selected), 
    // clicking the box will change it to its indeterminate state.
    // Instead, we want to uncheck all the boxes,
    // so we do this programatically. The indeterminate state should
    // only be set programatically, not by the user.

    if (Option1CheckBox.IsChecked == true &&
        Option2CheckBox.IsChecked == true &&
        Option3CheckBox.IsChecked == true)
    {
        // This will cause SelectAll_Unchecked to be executed, so
        // we don't need to uncheck the other boxes here.
        OptionsAllCheckBox.IsChecked = false;
    }
}

private void SetCheckedState()
{
    // Controls are null the first time this is called, so we just 
    // need to perform a null check on any one of the controls.
    if (Option1CheckBox != null)
    {
        if (Option1CheckBox.IsChecked == true &&
            Option2CheckBox.IsChecked == true &&
            Option3CheckBox.IsChecked == true)
        {
            OptionsAllCheckBox.IsChecked = true;
        }
        else if (Option1CheckBox.IsChecked == false &&
            Option2CheckBox.IsChecked == false &&
            Option3CheckBox.IsChecked == false)
        {
            OptionsAllCheckBox.IsChecked = false;
        }
        else
        {
            // Set third state (indeterminate) by setting IsChecked to null.
            OptionsAllCheckBox.IsChecked = null;
        }
    }
}
```

## <a name="dos-and-donts"></a>推奨と非推奨

-   チェック ボックスの用途と現在の状態が明確であることを確認します。
-   チェック ボックスのテキスト コンテンツは 2 行以内にします。
-   チェック マークをオンにすると true、チェック マークをオフにすると false に設定されるようにチェック ボックスのラベルを記述します。
-   ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。
-   テキスト コンテンツが動的な場合、コントロールのサイズがどのように変わり、周囲の視覚効果にどのような影響が生じるかを検討してください。
-   相互排他的な複数のオプションから選ぶ場合は、[オプション ボタン](radio-button.md) を使うことを検討してください。
-   2 つのチェック ボックスのグループを並べて配置しないようにします。 グループを分けるには、グループ ラベルを使います。
-   オン/オフの制御やコマンドの実行にはチェック ボックスを使わず、代わりにトグル スイッチを使います。
-   ダイアログ ボックスなどの他のコントロールを表示するためにチェック ボックスを使わないでください。
-   すべてではなく一部のサブ選択のためにオプションが設定されていることを示すには、不確定の状態を使います。
-   不確定の状態を使う場合は、下位のチェック ボックスを使って、どのオプションが選択され、どのオプションが選択されていないかがわかるようにします。 ユーザーにサブ選択肢がわかりやすいように UI を設計します。
-   不確定の状態を、第 3 の状態を示すために使わないでください。 不確定の状態は、すべてではなく一部のサブ選択のためにオプションが設定されていることを示すために使います。 そのため、ユーザーが不確定の状態を直接設定できないようにします。 良くない例を示すために、次のチェック ボックスでは不確定の状態を使って "中辛" を示しています。

    ![不確定状態のチェック ボックス](images/checkbox4_spicy.png)

    このような場合は、[Not spicy]、[Spicy]、[Extra spicy] という 3 つのオプションがあるラジオ ボタン グループを使います。

    ![[Not spicy]、[Spicy]、[Extra spicy] という 3 つのオプションがあるラジオ ボタン グループ](images/spicyoptions.png)

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [CheckBox クラス](https://msdn.microsoft.com/library/windows/apps/br209316) 
- [ラジオ ボタン](radio-button.md)
- [トグル スイッチ](toggles.md)
