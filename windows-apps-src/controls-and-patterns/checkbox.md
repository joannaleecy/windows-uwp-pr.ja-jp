---
Description: アクション項目の選択や選択解除を行うときに使います。 単一のリスト項目や複数のリスト項目に対して使うことができます。
title: チェック ボックス
ms.assetid: 6231A806-287D-43EE-BD8D-39D2FF761914
label: チェック ボックス
template: detail.hbs
---
# チェック ボックス

チェック ボックスは、アクション項目の選択や選択解除を行うときに使います。また、チェック ボックスは単一のリスト項目や複数のリスト項目に対して使うことができます。 コントロールには 3 つの選択状態 (選択されていない、選択されている、不確定) があります。 不確定状態は、選択されていない状態と選択されている状態の両方がサブ選択肢のコレクションに含まれている場合に示されます。

![4 つの状態を示すチェック ボックスの例](images/checkboxstates.png)

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>
-   [**CheckBox クラス**](https://msdn.microsoft.com/library/windows/apps/br209316) 

## 例

この例では、チェック ボックスを使ってショッピング リストを作成します。

![標準的なチェック ボックス コントロールを示すスクリーンショット](images/CheckBox_Standard.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

"このアカウントを記憶する" ログイン シナリオや、サービス契約の条項など、 はい/いいえの二者択一の選択肢に対しては、1 つのチェック ボックスを使います。

![個人的な選択のための 1 つのチェック ボックス](images/checkbox1.png)

複数選択シナリオの場合 (ユーザーが相互排他的でない選択肢のグループから 1 つ以上の項目を選ぶ場合) は、複数のチェック ボックスを使います。

二者択一の場合、チェック ボックスとトグル スイッチとの主な違いは、チェック ボックスが状態を管理し、トグル スイッチが動作を管理する点です。 チェック ボックスによる操作はコミットを遅らせることができますが (たとえばフォームの送信の一部として)、トグル スイッチによる操作は直ちにコミットしなければなりません。 また、複数の選択ができるのは、チェック ボックスだけです。

ユーザーがオプションの任意の組み合わせを選べる場合は、チェック ボックスのグループを作成します。

![チェック ボックスでの複数のオプションの選択](images/checkbox2.png)

ラジオ ボタンのグループが 1 つの選択を表すラジオ ボタンとは異なり、グループ内の各チェック ボックスが個別の独立した選択を表します。 1 つ以上のオプションがあっても、選択できるのが 1 つだけの場合は、代わりにラジオ ボタンを使います。

オプションが複数のオブジェクトに適用される場合は、チェック ボックスを使って、オプションの適用対象がすべてのオブジェクトか、一部のオブジェクトか、いずれにも適用されないかを示すことができます。 オプションの適用対象がすべてのオブジェクトではなく、一部のオブジェクトである場合は、混在する選択を表すために、チェック ボックスの不確定の状態を使います。 混在する選択のチェック ボックスの 1 つの例は、すべてでなく一部のサブ項目をユーザーが選択した場合に不確定の状態になる [すべて選択] チェック ボックスです。

![混在する選択を示すために使用されるチェック ボックス](images/checkbox3.png)

詳しくは、[**Indeterminate イベント (XAML) に関するページ**](https://msdn.microsoft.com/library/windows/apps/br209797) をご覧ください。

## チェック ボックスの作成

チェック ボックスを作成するには、CheckBox オブジェクトを使います。 
-   CheckBox には、任意のコンテンツ コントロールの子を使用できます。 通常、チェック ボックスは、StackPanel や Grid などのパネルの子として追加します。 
-   チェック ボックスにラベルを割り当てるには、Content プロパティを使います。 ラベルはチェック ボックスの横に表示されます。 
-   チェック ボックスの状態が変化したときにアクションを実行するには、Click イベントのハンドラーを追加します。 代わりに Checked イベント ハンドラーを使うこともできますが、Checked イベントが発生するのはチェック ボックスがオフからオンの状態に変化したときだけです。一方、Click イベントはオンの状態が変化するたびに発生するため、Click イベントの方がやや便利です。 

同じイベント ハンドラーを複数のチェック ボックスで共有できます。 
この例では、ピザのトッピングを選ぶための 4 つのチェック ボックスを作成します。 4 つのチェック ボックスで同じ Click イベント ハンドラーを共有します。 



```XAML
<StackPanel>
    <CheckBox Content="Pepperoni" x:Name="pepperoniCheckbox" 
        Checked="pizzaToppingCheckBox_Checked">
    </CheckBox>
    <CheckBox Content="Beef" x:Name="beefCheckbox" 
        Checked="pizzaToppingCheckBox_Checked">
    </CheckBox>
    <CheckBox Content="Mushrooms" x:Name="mushroomsCheckbox"
        Checked="pizzaToppingCheckBox_Checked">
    </CheckBox>
    <CheckBox Content="Onions" x:Name="onionsCheckbox"
        Checked="pizzaToppingCheckBox_Checked" >
    </CheckBox>

    <!-- Display the selected toppings. -->
    <TextBlock>Toppings selected:</TextBlock>
    <TextBlock x:Name="toppingsList"></TextBlock>
</StackPanel>
```

この例では、Click イベントのイベント ハンドラーを示します。 チェック ボックスがクリックされるたびにチェック ボックスを調べ、どれがオンになっているかを確認します。

```C#
private void pizzaToppingCheckBox_Clicked(
    object sender, RoutedEventArgs e)
{
    CheckBox selectedCheckbox = sender as CheckBox;

    string selectedToppingsText = "";
    CheckBox[] checkboxes = 
        new CheckBox[] { pepperoniCheckbox, beefCheckbox, 
                         mushroomsCheckbox, onionsCheckbox };
    foreach(CheckBox c in checkboxes)
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



## <a name="dos-and-donts"></a>推奨と非推奨 

-   チェック ボックスの用途と現在の状態が明確であることを確認します。
-   チェック ボックスのテキスト コンテンツは 2 行以内にします。
-   チェック マークをオンにすると true、チェック マークをオフにすると false に設定されるようにチェック ボックスのラベルを記述します。
-   ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。
-   提示する選択が複数ある場合は、レイアウト パネルが組み込まれた [スクロール ビューアー](scroll-controls.md) コントロールを使うことを検討してください。
-   すべてではなく一部のサブ選択のためにオプションが設定されていることを示すには、不確定の状態を使います。
-   不確定の状態を使う場合は、下位のチェック ボックスを使って、どのオプションが選択され、どのオプションが選択されていないかがわかるようにします。 ユーザーにサブ選択肢がわかりやすいように UI を設計します。
-   テキスト コンテンツが動的な場合、コントロールのサイズがどのように変わり、周囲の視覚効果にどのような影響が生じるかを検討してください。
-   相互排他的な複数のオプションから選ぶ場合は、[オプション ボタン](radio-button.md) を使うことを検討してください。
-   2 つのチェック ボックスのグループを並べて配置しないようにします。 グループを分けるには、グループ ラベルを使います。
-   オン/オフの制御やコマンドの実行にはチェック ボックスを使わず、代わりにトグル スイッチを使います。
-   ダイアログ ボックスなどの他のコントロールを表示するためにチェック ボックスを使わないでください。
-   不確定の状態を、第 3 の状態を示すために使わないでください。 不確定の状態は、すべてではなく一部のサブ選択のためにオプションが設定されていることを示すために使います。 そのため、ユーザーが不確定の状態を直接設定できないようにします。 良くない例を示すために、次のチェック ボックスでは不確定の状態を使って "中辛" を示しています。

    ![不確定状態のチェック ボックス](images/checkbox4_spicy.png)

    このような場合は、[Not spicy]、[Spicy]、[Extra spicy] という 3 つのオプションがあるラジオ ボタン グループを使います。

    ![[Not spicy]、[Spicy]、[Extra spicy] という 3 つのオプションがあるラジオ ボタン グループ](images/spicyoptions.png)


## 関連記事

-   [**CheckBox クラス**](https://msdn.microsoft.com/library/windows/apps/br209316) 




<!--HONumber=Mar16_HO1-->


