---
author: QuinnRadich
Description: A button gives the user a way to trigger an immediate action.
title: ボタン
label: Buttons
template: detail.hbs
ms.author: quradic
ms.date: 10/2/2018
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: f04d1a3c-7dcd-4bc8-9586-3396923b312e
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 922dccc61954e2022cbe76f2ca5d5b1f9e548733
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919464"
---
# <a name="buttons"></a>ボタン

ボタンは、特定の操作を直ちに実行する方法をユーザーに与えます。 ナビゲーション、繰り返されるアクションは、メニューを表示するなど、特定のタスクに特化していくつかのボタンです。

![ボタンの例](images/controls/button.png)

XAML フレームワークには、いくつかの特殊なボタン コントロールと同様に標準のボタン コントロールが用意されています。

コントロール | 説明
------- | -----------
[ボタン](/uwp/api/windows.ui.xaml.controls.button) | 即時の操作を開始します。 Click イベントまたはコマンド バインディングを使用できます。
[RepeatButton](/uwp/api/windows.ui.xaml.controls.primitives.repeatbutton) | 押されている間に継続的には、Click イベントを発生させるボタンです。
[HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton) | A ボタンをナビゲーションに使用される、ハイパーリンクのようにスタイルが適用されます。 詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。
[DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton) | 開くには、接続されているフライアウト シェブロン ボタンです。
[SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton) | 2 つの辺を持つボタンです。 一側の操作を開始して、反対側にメニューが開きます。
[ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton) | 2 つの辺を持つトグル ボタンです。 一方をオン/オフを切り替えます、反対側にメニューが開きます。

| **Windows の UI ライブラリを取得します。** |
| - |
| DropDownButton、SplitButton、および ToggleSplitButton は、NuGet パッケージの新しいコントロールと UWP のアプリケーションの UI 機能を含む、Windows UI ライブラリの一部として含まれています。 インストール方法など、詳細な情報については、 [Windows の UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)を参照してください。 |

| **プラットフォーム Api** | **Windows UI ライブラリの Api** |
| - | - |
| して[[イベント] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)[コマンドのプロパティ](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.command) | [DropDownButton クラス](/uwp/api/microsoft.ui.xaml.controls.dropdownbutton)、 [SplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.splitbutton)、 [ToggleSplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.togglesplitbutton) |

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

**ボタン**を使用すると、ユーザーがフォームを送信するなどの操作が直ちに開始できるようにします。

別のページに移動するのには、アクション ボタンを使用しません。[HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton)を使用してください。 詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。
> 例外: ウィザードでのページの移動には、[戻る] と [次へ] というラベルのボタンを使います。 他の種類の下位または上位のレベルでは、ナビゲーションを使用して、 [[戻る] ボタン](../basics/navigation-history-and-backwards-navigation.md)。

ユーザーは、繰り返しアクションをトリガーするときの**RepeatButton**を使用します。 たとえば、カウンターの値を増減する、RepeatButton を使用します。

ボタンに複数のオプションを含むフライアウトがあるときの**DropDownButton**を使用します。 既定のシェブロン ボタンにフライアウトが含まれていることを視覚を提供します。

の**SplitButton**は、ユーザーが直接操作を開始するかを選択していないその他のオプションから個別にする場合に使用します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Button">アプリを開き、Button の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

この例では、一情報へのアクセスを求めるダイアログ ボックスで、2 つのボタン ([Allow] (許可) と [Block] (禁止)) を使っています。

![ダイアログで使われるボタンの例](images/dialogs/dialog_RS2_two_button.png)

## <a name="create-a-button"></a>ボタンの作成

クリックに応答するボタンの例を次に示します。

XAML でボタンを作成します。

```xaml
<Button Content="Subscribe" Click="SubscribeButton_Click"/>
```

または、コードでボタンを作成します。

```csharp
Button subscribeButton = new Button();
subscribeButton.Content = "Subscribe";
subscribeButton.Click += SubscribeButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(subscribeButton);
```

Click イベントを処理します。

```csharp
private async void SubscribeButton_Click(object sender, RoutedEventArgs e)
{
    // Call app specific code to subscribe to the service. For example:
    ContentDialog subscribeDialog = new ContentDialog
    {
        Title = "Subscribe to App Service?",
        Content = "Listen, watch, and play in high definition for only $9.99/month. Free to try, cancel anytime.",
        CloseButtonText = "Not Now",
        PrimaryButtonText = "Subscribe",
        SecondaryButtonText = "Try it"
    };

    ContentDialogResult result = await subscribeDialog.ShowAsync();
}
```

### <a name="button-interaction"></a>ボタンの対話式操作

ポインターがボタンの上にあるときに、指やスタイラスでそのボタンをタップするか、マウスの左ボタンを押すと、ボタンでは [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントが発生します。 ボタンにキーボード フォーカスがある場合は、Enter キーまたは Space キーを押しても、Click イベントが発生します。

通常、ボタンでは低レベルな [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントを処理できません。これに代わる Click 動作があるためです。 詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx)」をご覧ください。

ボタンで Click イベントが発生する方法を変えるには、[ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) プロパティを変更します。 ClickMode の既定値は **Release** ですが、ボタンの ClickMode を **Hover** または **Press** に設定することもできます。 ClickMode が **Hover** の場合、キーボード操作やタッチ操作によって Click イベントを発生させることはできません。


### <a name="button-content"></a>ボタンのコンテンツ

ボタンは [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx) です。 その XAML コンテンツ プロパティは [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) であり、`<Button>A button's content</Button>` のような XAML 構文を使用できます。 任意のオブジェクトをボタンのコンテンツとして設定できます。 コンテンツが [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) の場合、ボタンにレンダリングされます。 コンテンツが別のタイプのオブジェクトの場合、その文字列表現がボタンに表示されます。

ボタンのコンテンツは、通常はテキストです。 テキスト コンテンツの付いたボタンの設計に関する推奨事項を次に示します。
-   ボタンによって行われる操作を明確に説明する、簡潔で具体的でわかりやすいテキストを使います。 通常、ボタンのテキスト コンテンツは、1 語の動詞です。
-   ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。
-   短いテキストでは、120px の最小ボタン幅を使用し、幅が狭いコマンド ボタンは使わないようにします。
- 長いテキストでは、テキストを最大文字数 26 文字に制限し、さまざまなコマンド ボタンは使わないようにします。
-   ボタンのテキスト コンテンツが動的な場合 ([ローカライズされる](../globalizing/globalizing-portal.md) 場合など) は、ボタンのサイズがどのように変化し、その周囲のコントロールに何が起こるかを考えます。

<table>
<tr>
<td> <b>必要な修正:</b><br> オーバーフロー テキストの付いたボタン。 </td>
<td> <img src="images/button-wraptext.png"/> </td>
</tr>
<tr>
<td> <b>オプション 1:</b><br> テキストの長さが 26 文字より大きい場合は、ボタンの幅やスタック ボタンを増やし、テキストを折り返します。 </td>
<td> <img src="images/button-wraptext1.png"> </td>
</tr>
<tr>
<td> <b>オプション 2:</b><br> ボタンの高さを増やし、テキストを折り返します。 </td>
<td> <img src="images/button-wraptext2.png"> </td>
</tr>
</table>

ボタンの外観を構成する視覚効果をカスタマイズすることもできます。 たとえば、テキストをアイコンに置き換えたり、アイコンとテキストを使用したりできます。

ここでは、画像とテキストを含む **StackPanel** がボタンのコンテンツとして設定されます。

```xaml
<Button Click="Button_Click"
        Background="LightGray"
        Height="100" Width="80">
    <StackPanel>
        <Image Source="Assets/Photo.png" Height="62"/>
        <TextBlock Text="Photos" Foreground="Black"
                   HorizontalAlignment="Center"/>
    </StackPanel>
</Button>
```

ボタンは次のように表示されます。

![画像とテキスト コンテンツがあるボタン](images/button-orange.png)

## <a name="create-a-repeat-button"></a>繰り返しボタンの作成

[RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) は、ボタンが押されてから離されるまで、繰り返し [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントを発生させるボタンです。 ボタンが押されてからクリック操作の繰り返しを始めるまでの RepeatButton の待ち時間を指定するには、[Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) プロパティを設定します。 クリック操作の繰り返し間隔を指定するには、[Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) プロパティを設定します。 これらのプロパティの時間はどちらもミリ秒単位で指定します。

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

## <a name="create-a-drop-down-button"></a>ドロップ ダウン ボタンを作成します。

> DropDownButton Windows 10、1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) のバージョンを必要とするまたはそれ以降、または[Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)です。

[DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton)には、他のオプションが含まれている添付のフライアウトを使用している視覚的なインジケーターとして、山形の記号を表示するボタンです。 フライアウトは、標準のボタンと同じ動作があります。外観だけとは異なります。

ドロップ ダウン ボタンは、Click イベントを継承しますが、通常これを使用しません。 代わりに、フライアウトのプロパティを使用して、フライアウトを接続し、フライアウトのメニュー オプションを使用してアクションを起動します。 フライアウトは、ボタンがクリックされたときに自動的に開きます。

> [!TIP]
> フライアウト方法の詳細については、[メニューおよびコンテキスト メニュー](menus.md)を参照してください。

### <a name="example---drop-down-button"></a>ドロップ ダウン ボタンの使用例

次の使用例は、RichEditBox 内の段落の配置のためのコマンドを含むフライアウトを使用して、ドロップ ダウン ボタンを作成する方法を示しています。 (他の情報やコードを参照してください[リッチ エディット ボックス](rich-edit-box.md))。

![ドロップ ダウン ボタンの配置コマンドを使用して](images/drop-down-button-align.png)

```xaml
<DropDownButton ToolTipService.ToolTip="Alignment">
    <TextBlock FontFamily="Segoe MDL2 Assets" FontSize="16" Text="&#xE8E4;"/>
    <DropDownButton.Flyout>
        <MenuFlyout Placement="BottomEdgeAlignedLeft">
            <MenuFlyoutItem Text="Left" Icon="AlignLeft" Tag="left"
                            Click="AlignmentMenuFlyoutItem_Click"/>
            <MenuFlyoutItem Text="Center" Icon="AlignCenter" Tag="center"
                            Click="AlignmentMenuFlyoutItem_Click"/>
            <MenuFlyoutItem Text="Right" Icon="AlignRight" Tag="right"
                            Click="AlignmentMenuFlyoutItem_Click"/>
        </MenuFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

```csharp
private void AlignmentMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
{
    var option = ((MenuFlyoutItem)sender).Tag.ToString();

    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        // Apply the alignment to the selected paragraphs.
        var paragraphFormatting = selectedText.ParagraphFormat;
        if (option == "left")
        {
            paragraphFormatting.Alignment = Windows.UI.Text.ParagraphAlignment.Left;
        }
        else if (option == "center")
        {
            paragraphFormatting.Alignment = Windows.UI.Text.ParagraphAlignment.Center;
        }
        else if (option == "right")
        {
            paragraphFormatting.Alignment = Windows.UI.Text.ParagraphAlignment.Right;
        }
    }
}
```

## <a name="create-a-split-button"></a>分割ボタンを作成します。

> SplitButton Windows 10、1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) のバージョンを必要とするまたはそれ以降、または[Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)です。

の[SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton)は、個別に呼び出すことができる 2 つの部分です。 1 つの部品では、標準のボタンのように動作し、直接操作を呼び出します。 他のパーツは、ユーザーが選択できる追加のオプションを含むポップアップを起動します。

> [!NOTE]
> タッチで呼び出されると、分割ボタンのドロップダウン ボタンとして動作します。ボタンの両方の半分は、フライアウトを呼び出します。 入力の他のメソッドでは、ユーザーは個別にボタンのいずれかの半分を呼び出すことができます。

分割ボタンの通常の動作は次のとおりです。

- ユーザーは、ボタンの部分をクリックすると、ドロップダウン ・ リストで現在選択されているオプションを起動するのには、Click イベントを処理します。
- ドロップダウンが開いているときは、オプションを両方の変更に、ドロップダウン リスト内のアイテムのハンドルの呼び出しが選択され、し、呼び出すこと。 フライアウトの項目を呼び出すために、ボタンのタッチを使用する場合、イベントは発生しません] をクリックします。

> [!TIP]
> ドロップでアイテムを配置し、その呼び出しを処理する方法はたくさんあります。 リスト ビューまたは GridView を使用する方法の 1 つが SelectionChanged イベントを処理します。 その場合、 [SingleSelectionFollowsFocus](/uwp/api/windows.ui.xaml.controls.listviewbase.singleselectionfollowsfocus)を**false**に設定します。 ユーザーが各変更の項目を呼び出すことがなく、キーボードを使用してオプション間を移動できます。

### <a name="example---split-button"></a>分割ボタンの使用例

次の使用例は、RichEditBox で選択したテキストの前景色を変更するために使用される分割ボタンを作成する方法を示します。 (他の情報やコードを参照してください[リッチ エディット ボックス](rich-edit-box.md))。

![前景の色を選択するための分割ボタン](images/split-button-rtb.png)

```xaml
<SplitButton ToolTipService.ToolTip="Foreground color"
             Click="BrushButtonClick">
    <Border x:Name="SelectedColorBorder" Width="20" Height="20"/>
    <SplitButton.Flyout>
        <Flyout x:Name="BrushFlyout" Placement="BottomEdgeAlignedLeft">
            <!-- Set SingleSelectionFollowsFocus="False"
                 so that keyboard navigation works correctly. -->
            <GridView ItemsSource="{x:Bind ColorOptions}" 
                      SelectionChanged="BrushSelectionChanged"
                      SingleSelectionFollowsFocus="False"
                      SelectedIndex="0" Padding="0">
                <GridView.ItemTemplate>
                    <DataTemplate>
                        <Rectangle Fill="{Binding}" Width="20" Height="20"/>
                    </DataTemplate>
                </GridView.ItemTemplate>
                <GridView.ItemContainerStyle>
                    <Style TargetType="GridViewItem">
                        <Setter Property="Margin" Value="2"/>
                        <Setter Property="MinWidth" Value="0"/>
                        <Setter Property="MinHeight" Value="0"/>
                    </Style>
                </GridView.ItemContainerStyle>
            </GridView>
        </Flyout>
    </SplitButton.Flyout>
</SplitButton>
```

```csharp
public sealed partial class MainPage : Page
{
    // Color options that are bound to the grid in the split button flyout.
    private List<SolidColorBrush> ColorOptions = new List<SolidColorBrush>();
    private SolidColorBrush CurrentColorBrush = null;

    public MainPage()
    {
        this.InitializeComponent();

        // Add color brushes to the collection.
        ColorOptions.Add(new SolidColorBrush(Colors.Black));
        ColorOptions.Add(new SolidColorBrush(Colors.Red));
        ColorOptions.Add(new SolidColorBrush(Colors.Orange));
        ColorOptions.Add(new SolidColorBrush(Colors.Yellow));
        ColorOptions.Add(new SolidColorBrush(Colors.Green));
        ColorOptions.Add(new SolidColorBrush(Colors.Blue));
        ColorOptions.Add(new SolidColorBrush(Colors.Indigo));
        ColorOptions.Add(new SolidColorBrush(Colors.Violet));
        ColorOptions.Add(new SolidColorBrush(Colors.White));
    }

    private void BrushButtonClick(object sender, object e)
    {
        // When the button part of the split button is clicked,
        // apply the selected color.
        ChangeColor();
    }

    private void BrushSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // When the flyout part of the split button is opened and the user selects
        // an option, set their choice as the current color, apply it, then close the flyout.
        CurrentColorBrush = (SolidColorBrush)e.AddedItems[0];
        SelectedColorBorder.Background = CurrentColorBrush;
        ChangeColor();
        BrushFlyout.Hide();
    }

    private void ChangeColor()
    {
        // Apply the color to the selected text in a RichEditBox.
        Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
        if (selectedText != null)
        {
            Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
            charFormatting.ForegroundColor = CurrentColorBrush.Color;
            selectedText.CharacterFormat = charFormatting;
        }
    }
}
```

## <a name="create-a-toggle-split-button"></a>分割のトグル ボタンを作成します。

> Windows 10、1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) のバージョンが必要です ToggleSplitButton またはそれ以降、または[Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。

の[ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton)は、個別に呼び出すことができる 2 つの部分です。 1 つの部品は、オンまたはオフにできるトグル ボタンのように動作します。 他のパーツは、ユーザーが選択できる追加のオプションを含むポップアップを起動します。

分割のトグル ボタンは有効にするまたは機能を無効にする機能で、ユーザーが選択できる複数のオプションがある場合に通常使用されます。 など、ドキュメントのエディターで、される可能性があります無効を切り替えるリスト、リストのスタイルを選択するドロップダウンを使用します。

> [!NOTE]
> タッチで呼び出されると、[分割] ボタンは、ドロップ ダウン ボタンとして動作します。 入力の他のメソッドでは、ユーザーは個別にボタンのいずれかの半分を呼び出すことができます。 タッチ、ボタンの両方の半分、フライアウトを起動します。 したがって、ボタンをオンまたはオフに切り替えるには、ポップアップのコンテンツのオプションを含める必要があります。

### <a name="differences-with-togglebutton"></a>トグル ボタンとの相違点

[トグル ボタン](/uwp/api/windows.ui.xaml.controls.primitives.togglebutton)とは異なり、ToggleSplitButton は、中間状態がありません。 その結果、これらの違いを点に注意する必要があります。

- ToggleSplitButton には、 **IsThreeState**プロパティまたは**中間状態**のイベントはありません。
- [ToggleSplitButton.IsChecked](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischecked)プロパティは、同じ**ブール値**、 **null 許容のブール値**ではありません。
- ToggleSplitButton には、 [IsCheckedChanged](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischeckedchanged)イベントのみです。別の**オン**と**オフにした場合**のイベントはありません。

### <a name="example---toggle-split-button"></a>例 - 表示/非表示の分割ボタン

スプリット ボタンの切り替えの設定をオンまたはオフを切り替えたり、リストを有効にされる可能性があり、RichEditBox で、リストのスタイルを変更する次の使用例を示しています。 (他の情報やコードを参照してください[リッチ エディット ボックス](rich-edit-box.md))。

![トグル ボタン] ボックスの一覧のスタイルを選択するための分割](images/toggle-split-button-open.png)

```xaml
<ToggleSplitButton x:Name="ListButton"
                   ToolTipService.ToolTip="List style"
                   Click="ListButton_Click"
                   IsCheckedChanged="ListStyleButton_IsCheckedChanged">
    <TextBlock FontFamily="Segoe MDL2 Assets" FontSize="16" Text="&#xE8FD;"/>
    <ToggleSplitButton.Flyout>
        <Flyout Placement="BottomEdgeAlignedLeft">
            <ListView x:Name="ListStylesListView"
                      SelectionChanged="ListStylesListView_SelectionChanged" 
                      SingleSelectionFollowsFocus="False">
                <StackPanel Tag="bullet" Orientation="Horizontal">
                    <FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xE7C8;"/>
                    <TextBlock Text="Bullet" Margin="8,0"/>
                </StackPanel>
                <StackPanel Tag="alpha" Orientation="Horizontal">
                    <TextBlock Text="A" FontSize="24" Margin="2,0"/>
                    <TextBlock Text="Alpha" Margin="8"/>
                </StackPanel>
                <StackPanel Tag="numeric" Orientation="Horizontal">
                    <FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xF146;"/>
                    <TextBlock Text="Numeric" Margin="8,0"/>
                </StackPanel>
                <TextBlock Tag="none" Text="None" Margin="28,0"/>
            </ListView>
        </Flyout>
    </ToggleSplitButton.Flyout>
</ToggleSplitButton>
```

```csharp
private void ListStyleButton_IsCheckedChanged(ToggleSplitButton sender, ToggleSplitButtonIsCheckedChangedEventArgs args)
{
    // Use the toggle button to turn the selected list style on or off.
    if (((ToggleSplitButton)sender).IsChecked == true)
    {
        // On. Apply the list style selected in the drop down to the selected text.
        var listStyle = ((FrameworkElement)(ListStylesListView.SelectedItem)).Tag.ToString();
        ApplyListStyle(listStyle);
    }
    else
    {
        // Off. Make the selected text not a list,
        // but don't change the list style selected in the drop down.
        ApplyListStyle("none");
    }
}

private void ListStylesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    var listStyle = ((FrameworkElement)(e.AddedItems[0])).Tag.ToString();

    if (ListButton.IsChecked == true)
    {
        // Toggle button is on. Turn it off...
        if (listStyle == "none")
        {
            ListButton.IsChecked = false;
        }
        else
        {
            // or apply the new selection.
            ApplyListStyle(listStyle);
        }
    }
    else
    {
        // Toggle button is off. Turn it on, which will apply the selection
        // in the IsCheckedChanged event handler.
        ListButton.IsChecked = true;
    }
}

private void ApplyListStyle(string listStyle)
{
    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        // Apply the list style to the selected text.
        var paragraphFormatting = selectedText.ParagraphFormat;
        if (listStyle == "none")
        {  
            paragraphFormatting.ListType = Windows.UI.Text.MarkerType.None;
        }
        else if (listStyle == "bullet")
        {
            paragraphFormatting.ListType = Windows.UI.Text.MarkerType.Bullet;
        }
        else if (listStyle == "numeric")
        {
            paragraphFormatting.ListType = Windows.UI.Text.MarkerType.Arabic;
        }
        else if (listStyle == "alpha")
        {
            paragraphFormatting.ListType = Windows.UI.Text.MarkerType.UppercaseEnglishLetter;
        }
        selectedText.ParagraphFormat = paragraphFormatting;
    }
}
```

## <a name="recommendations"></a>推奨事項

- ボタンの用途と状態をユーザーがはっきりと理解できるようにします。
- 同じ意思決定に対して複数のボタンが存在する場合 (確認のダイアログなど)、コミット ボタンは次の順番で提示します。この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。
    - [OK]/[実行する]/[はい]
    - [実行しない]/[いいえ]
    - [キャンセル]
- ユーザーに対して表示するボタンは、1 つまたは 2 つにします (例: [承諾] と [キャンセル])。 3 つ以上の操作をユーザーに示す必要がある場合は、ユーザーが操作を選択できる [チェック ボックス](checkbox.md) または [オプション ボタン](radio-button.md) を、それらの操作を開始するための 1 つのコマンド ボタンと共に使うことを検討します。
- ある操作をアプリの複数のページで実行できるようにするには、各ページでボタンを使うのではなく、[下部のアプリ バー](app-bars.md) を使うことを検討します。

### <a name="recommended-single-button-layout"></a>単一のボタンの推奨レイアウト

ボタンを 1 つしか必要としないレイアウトでは、コンテナーのコンテキストに応じて、左揃えまたは右揃えにします。

- ボタンが 1 つだけのダイアログでは、ボタンを**右揃え**にします。 ダイアログにボタンが 1 つしかない場合は、ボタンによって安全で非破壊的な操作が実行されるようにします。 [ContentDialog](dialogs.md) を使い、単一のボタンを指定する場合は、自動的に右揃えになります。

![ダイアログ内のボタン](images/pushbutton_doc_dialog.png)

- ボタンがコンテナー UI 内 (トースト通知、ポップアップ、またはリスト ビュー項目内など) に表示される場合は、コンテナー内でボタンを**左揃え**にします。

![コンテナー内のボタン](images/pushbutton_doc_container.png)

- ページに含まれるボタンが 1 つだけの場合は (設定ページの下部にある [適用] ボタンなど)、ボタンを**左揃え**にします。 これで、ページのその他のコンテンツとボタンを揃えて配置できます。

![ページのボタン](images/pushbutton_doc_page.png)

## <a name="back-buttons"></a>戻るボタン

戻るボタンは、バック スタックまたはユーザーのナビゲーション履歴を使って "戻る" ナビゲーションを実現する、システムの UI 要素です。 独自の"戻る"ボタンを作成する必要はありませんが、前に戻る移動で適切なエクスペリエンスを提供するために作業が必要になることがあります。 詳しくは、「[履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [Button クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)
- [ラジオ ボタン](radio-button.md)
- [チェック ボックス](checkbox.md)
- [トグル スイッチ](toggles.md)
