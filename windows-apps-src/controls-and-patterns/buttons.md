---
author: Jwmsft
Description: "ボタンは、特定の操作を直ちに実行する方法をユーザーに与えます。"
label: Buttons
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: bb670533769d8bae9cdea0f18e9cbb5717eb3877

---
# <a name="buttons"></a>ボタン
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

ボタンは、特定の操作を直ちに実行する方法をユーザーに与えます。

![ボタンの例](images/controls/button.png)

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**Button クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)</li>
<li>[**RepeatButton クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx)</li>
<li>[**Click イベント**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx)</li>
<li> </li>
<li> </li>
<li> </li>
</ul>
</div>

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ボタンを使うと、ユーザーは直ちに操作を開始できます (フォームの送信など)。

他のページに移動する操作では、ボタンは使わず、リンクを使います。 詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。
    
> 例外: ウィザードでのページの移動には、[戻る] と [次へ] というラベルのボタンを使います。 他の種類の前に戻る移動や上位レベルへの移動では、[戻る] ボタンを使います。

## <a name="example"></a>例

この例では、Microsoft Edge ブラウザーのダイアログで、Close all (すべて閉じる) と Cancel (キャンセル) という 2 つのボタンを使用しています。 

![ダイアログで使われるボタンの例](images/control-examples/buttons-edge.png)

## <a name="create-a-button"></a>ボタンの作成

クリックに応答するボタンの例を次に示します。 

XAML でボタンを作成します。

```xaml
<Button Content="Submit" Click="SubmitButton_Click"/>
```

または、コードでボタンを作成します。

```csharp
Button submitButton = new Button();
submitButton.Content = "Submit";
submitButton.Click += SubmitButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(submitButton);
```

Click イベントを処理します。

```csharp
private async void SubmitButton_Click(object sender, RoutedEventArgs e)
{
    // Call app specific code to submit form. For example:
    // form.Submit();
    Windows.UI.Popups.MessageDialog messageDialog = 
        new Windows.UI.Popups.MessageDialog("Thank you for your submission.");
    await messageDialog.ShowAsync();
}
```

### <a name="button-interaction"></a>ボタンの対話式操作

ポインターがボタンの上にあるときに、指やスタイラスでそのボタンをタップするか、マウスの左ボタンを押すと、ボタンでは [**Click**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントが発生します。 ボタンにキーボード フォーカスがある場合は、Enter キーまたは Space キーを押しても、Click イベントが発生します。

通常、ボタンでは低レベルな [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントを処理できません。これに代わる Click 動作があるためです。 詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/en-us/library/windows/apps/mt185584.aspx)」をご覧ください。

ボタンで Click イベントが発生する方法を変えるには、[**ClickMode**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.clickmode.aspx) プロパティを変更します。 ClickMode の既定値は **Release** です。 ClickMode が **Hover** の場合、キーボード操作やタッチ操作によって Click イベントを発生させることはできません。 


### <a name="button-content"></a>ボタンのコンテンツ

ボタンは [**ContentControl**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx) です。 その XAML コンテンツ プロパティは [**Content**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) で、`<Button>A button's content</Button>` のような XMAL 構文を使用できます。 任意のオブジェクトをボタンのコンテンツとして設定できます。 コンテンツが [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) の場合、ボタンにレンダリングされます。 コンテンツが別のタイプのオブジェクトの場合、その文字列表現がボタンに表示されます。

ここでは、バナナの画像とテキストを含む **StackPanel** がボタンのコンテンツとして設定されます。

```xaml
<Button Click="Button_Click" 
        Background="#FF0D6AA3" 
        Height="100" Width="80">
    <StackPanel>
        <Image Source="Assets/Slices.png" Height="62"/>
        <TextBlock Text="Orange"  Foreground="White"
                   HorizontalAlignment="Center"/>
    </StackPanel>
</Button>
```

ボタンは次のように表示されます。

![画像とテキスト コンテンツがあるボタン](images/button-orange.png)

## <a name="create-a-repeat-button"></a>繰り返しボタンの作成

[**RepeatButton**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) は、ボタンが押されてから離されるまで、繰り返し [**Click**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントを発生させるボタンです。 ボタンが押されてからクリック操作の繰り返しを始めるまでの RepeatButton の待ち時間を指定するには、[**Delay**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) プロパティを設定します。 クリック操作の繰り返し間隔を指定するには、[**Interval**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) プロパティを設定します。 これらのプロパティの時間はどちらもミリ秒単位で指定します。

次の例は 2 つの RepeatButton コントロールを示しています。それぞれの Click イベントを使って、テキスト ブロックに表示される値を増減します。

```xaml
<StackPanel>
    <RepeatButton Width="100" Delay="500" Interval="100" Click="Increase_Click">Increase</RepeatButton>
    <RepeatButton Width="100" Delay="500" Interval="100" Click="Decrease_Click">Decrease</RepeatButton>
    <TextBlock x:Name="clickTextBlock" Text="Number of Clicks:" />
</StackPanel>
```

```csharp
private static int _clicks = 0;
private void Increase_Click(object sender, RoutedEventArgs e)
{
    _clicks += 1;
    clickTextBlock.Text = "Number of Clicks: " + _clicks;
}

private void Decrease_Click(object sender, RoutedEventArgs e)
{
    if(_clicks > 0)
    {
        _clicks -= 1;
        clickTextBlock.Text = "Number of Clicks: " + _clicks;
    }
}
```

## <a name="recommendations"></a>推奨事項

-   ボタンの用途と状態をユーザーがはっきりと理解できるようにします。
-   ボタンによって行われる操作を明確に説明する、簡潔で具体的でわかりやすいテキストを使います。 通常、ボタンのテキスト コンテンツは、1 語の動詞です。
-   同じ意思決定に対して複数のボタンが存在する場合 (確認のダイアログなど)、コミット ボタンは次の順番で提示します。 
    -   [OK]/[実行する]/[はい]
    -   [実行しない]/[いいえ]
    -   [キャンセル]

    (この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。)

-   ボタンのテキスト コンテンツが動的な場合 (ローカライズされる場合など) は、ボタンのサイズがどのように変化し、その周囲のコントロールに何が起こるかを考えます。
-   テキスト コンテンツの付いたコマンド ボタンの場合は、最小のボタン幅を使います。
-   テキスト コンテンツの付いた幅が狭い横長または縦長のコマンド ボタンは使わないようにします。
-   ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。
-   ある操作をアプリの複数のページで実行できるようにするには、各ページでボタンを使うのではなく、[下部のアプリ バー](app-bars.md) を使うことを検討します。
-   ユーザーに対して表示するボタンは、1 つまたは 2 つにします (例: [承諾] と [キャンセル])。 3 つ以上の操作をユーザーに示す必要がある場合は、ユーザーが操作を選択できる [チェック ボックス](checkbox.md) または [オプション ボタン](radio-button.md) を、それらの操作を開始するための 1 つのコマンド ボタンと共に使うことを検討します。
-   最も一般的な操作や推奨される操作を示す既定のコマンド ボタンを使います。
-   ボタンをカスタマイズすることを検討します。 ボタンの形は既定では四角形ですが、ボタンの外観を構成する視覚効果をカスタマイズできます。 ボタンのコンテンツは、通常はテキスト (例: [承諾] や [キャンセル]) ですが、アイコンに置き換えるか、アイコンとテキストを使うことができます。
-   ユーザーがボタンを操作したとき、ボタンの状態と外観を変更して、ユーザーにフィードバックを返します。 ボタンの状態には、Normal、Pressed、Disabled などがあります。
-   ユーザーがボタンをタップまたはクリックしたときに、ボタンのアクションを開始します。 通常、アクションは、ユーザーがボタンを離したときに開始されますが、指がボタンを押したときにボタンのアクションを開始するように設定することもできます。
-   コマンド ボタンは、状態の設定には使わないでください。
-   アプリの実行中、ボタンのテキストは変更しないでください。たとえば、"次へ" というボタンのテキストは "続行" というテキストには変更しないでください。
-   送信、リセット、標準ボタンの既定のスタイルを取り替えないでください。
-   ボタン内に多すぎるコンテンツを配置しないでください。 ボタン内のコンテンツは、簡潔でわかりやすくします (画像と少しのテキストのみにします)。

## <a name="back-buttons"></a>戻るボタン
戻るボタンは、バック スタックまたはユーザーのナビゲーション履歴を使って "戻る" ナビゲーションを実現する、システムの UI 要素です。 独自の"戻る"ボタンを作成する必要はありませんが、前に戻る移動で適切なエクスペリエンスを提供するために作業が必要になることがあります。 詳しくは、「[履歴と前に戻る移動](../layout/navigation-history-and-backwards-navigation.md)」をご覧ください。

## <a name="get-the-sample-code"></a>サンプル コードを入手する
*   [XAML UI の基本のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)<br/>
    インタラクティブな形で XAML コントロールのすべてを参照できます。


## <a name="related-articles"></a>関連記事

- [ラジオ ボタン](radio-button.md)
- [トグル スイッチ](toggles.md)
- [チェック ボックス](checkbox.md)
- [**Button クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)





<!--HONumber=Dec16_HO2-->


