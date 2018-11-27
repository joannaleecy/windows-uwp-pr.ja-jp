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
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7700347"
---
# <a name="radio-buttons"></a>ラジオ ボタン

> **重要な API**: [RadioButton クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.RadioButton)、[Checked イベント](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.Checked)、[IsChecked プロパティ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.IsChecked)

ラジオ ボタンを使用すると、ユーザーはセットから 1 つのオプションを選択できます。 各オプションは、1 つのラジオ ボタンによって表されます。ユーザーは、ラジオ ボタン グループの中から、1 つのラジオ ボタンだけを選ぶことができます。

(ラジオ ボタンという名称は、ラジオのチャンネル プリセットのボタンから付けられました。)

![ラジオ ボタン](images/controls/radio-button.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ユーザーに 2 つ以上の相互排他的なオプションを提示するには、ラジオ ボタンを使います。

![ラジオ ボタンのグループ](images/radiobutton_basic.png)

ユーザーが選択するすべてのオプションを表示する必要がある場合は、ラジオ ボタンを使用します。 ラジオ ボタンはすべてのオプションを均等に強調するため、必要以上に注目される可能性があります。 ユーザーの特別な注目を引く必要がない場合は、他のコントロールを使うことを検討してください。 たとえば、ほとんどの状況でほとんどのユーザーに既定のオプションが適切な場合は、代わりに[ドロップダウン リスト](lists.md)を使います。

![ドロップダウン リスト](images/combo_box_collapsed.png)

2 つだけの相互排他的なオプションの場合は、1 つの[チェック ボックス](checkbox.md)または[トグル スイッチ](toggles.md)にまとめます。 たとえば、"I agree" と "I don't agree" という 2 つのラジオ ボタンではなく、"I agree" のチェック ボックスを使います。

![二者択一を表す 2 つの方法](images/radiobutton_vs_checkbox.png)

ユーザーが複数のオプションを選択できる場合は、[チェックボックス](checkbox.md) を使います。

![チェック ボックスでの複数のオプションの選択](images/checkbox2.png)

オプションが固定間隔の数値 (10, 20, 30) である場合は、[スライダー](slider.md) コントロールを使用します。

![スライダー コントロール](images/controls/slider.png)

オプションが 8 個より多い場合は、[ドロップダウン リスト](lists.md)、または[リスト ボックス](lists.md) を使います。

![コンボ ボックス](images/combo_box_scroll.png)

オプションがアプリの現在のコンテキストに基づいて表示される場合や、その他の方法で動的に変化する場合は、単一選択の [リスト ボックス](lists.md) を使います。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/RadioButton">アプリを開き、RadioButton の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

Microsoft Edge ブラウザーでのラジオ ボタンの設定です。

![Microsoft Edge ブラウザーでのラジオ ボタンの設定](images/control-examples/radio-buttons-edge.png)

## <a name="create-a-radio-button"></a>ラジオ ボタンの作成

ラジオ ボタンは、グループで動作します。 ラジオ ボタン コントロールをグループ化する 2 つの方法があります。
- 同じ親コンテナー内に追加します。
- 各ラジオ ボタンの [GroupName](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.RadioButton.GroupName) プロパティを同じ値に設定します。

この例では、スタック パネルを同じにすることでラジオ ボタンの最初のグループが暗黙的にグループ化されます。 2 つ目のグループは、2 つのスタック パネルの間で分割されているので、GroupName で明示的にグループ化されます。

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

ラジオ ボタンのグループは、次のようになります。

![ラジオ ボタンの 2 つのグループ](images/radio-button-groups.png)

ラジオ ボタンには*選択*または*クリア*の 2 つの状態があります。 ラジオ ボタンを選択すると、[IsChecked](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.ToggleButton.IsChecked) プロパティは **true** になります。 ラジオ ボタンがクリアされると、**IsChecked** プロパティは **false** になります。 同じグループ内の別のラジオ ボタンをクリックするとラジオ ボタンをクリアにできますが、ボタンをもう一度クリックしてもクリアにすることはできません。 ただし、プログラムで IsChecked プロパティを **false** に設定してラジオ ボタンをクリアにすることができます。 **IsChecked** プロパティの**値**を取得することで、**IsChecked** プロパティとブール値を実際に比較することができます。

## <a name="recommendations"></a>推奨事項

-   一連のラジオ ボタンの用途と現在の状態が明確に表示されていることを確認します。
-   ラジオ ボタンのテキスト コンテンツは、1 行に収まるように作成します。
-   テキスト コンテンツが動的な場合、ボタンのサイズがどのように変わり、周囲の視覚効果にどのような影響が生じるかを検討してください。
-   ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。
-   2 つのラジオ ボタン グループを並べて配置しないようにします。 2 つのラジオ ボタン グループが並んでいると、どのボタンがどのグループに属しているかがわかりにくくなります。

## <a name="additional-usage-guidance"></a>その他の使い方のガイダンス

この図は、適切な位置と間隔で配置したラジオ ボタンを示しています。

![一連のラジオ ボタン](images/radiobutton-layout.png)

![ラジオ ボタンの間隔ガイドライン](images/radiobutton-redlines.png)

## <a name="related-topics"></a>関連トピック

**設計者向け**
- [ボタン](buttons.md)
- [トグル スイッチ](toggles.md)
- [チェック ボックス](checkbox.md)
- [リストとコンボ ボックス](lists.md)
- [スライダー](slider.md)

**開発者向け (XAML)**
- [RadioButton クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.radiobutton)
