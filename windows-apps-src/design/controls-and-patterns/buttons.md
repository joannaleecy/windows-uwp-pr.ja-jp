---
author: serenaz
Description: A button gives the user a way to trigger an immediate action.
title: ボタン
label: Buttons
template: detail.hbs
ms.author: sezhen
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: f04d1a3c-7dcd-4bc8-9586-3396923b312e
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: f0bf7731a8480fb4f6d81368227ad6259780381b
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2891071"
---
# <a name="buttons"></a>ボタン

> [!IMPORTANT]
> この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。 プレビュー機能[最新の Windows 10 の内部のプレビュー ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)必要があります。

ボタンは、特定の操作を直ちに実行する方法をユーザーに与えます。 いくつかのボタンは、ナビゲーション、繰り返しのアクション] メニューを表示するなど、特定のタスクの特殊なされます。

![ボタンの例](images/controls/button.png)

XAML フレームワークには、いくつかの特殊なボタン コントロールと同様に、標準のボタン コントロールが用意されています。

コントロール | 説明
------- | -----------
[ボタン](/uwp/api/windows.ui.xaml.controls.button) | すぐにアクションを開始します。 イベントやコマンドのバインドで使用できます。
[RepeatButton](/uwp/api/windows.ui.xaml.controls.primitives.repeatbutton) | 押したときに、継続的をクリックしてイベントを発生させる] ボタン。
[HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton) | A ボタン ナビゲーションで使用し、ハイパーリンクのようなスタイルが適用されます。 詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。
[DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton) | (プレビュー版)ボタン、プロセス、接続されているサブメニューを開きます。
[SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton) | (プレビュー版)2 つの辺] ボタン。 1 つの辺が、アクションを開始し、[その他の面に、メニューが表示します。
[ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton) | (プレビュー版)2 つの辺の表示/非表示] ボタン。 1 つの辺をオン/オフを切り替えます、その他の面に、メニューが開きます。

| **Windows の UI ライブラリを取得します。** |
| - |
| DropDownButton、分割ボタンと ToggleSplitButton NuGet パッケージに新しいコントロールや UWP アプリの UI の機能が含まれている、Windows UI ライブラリの一部として含まれています。 インストール方法など、さらに詳しい情報は、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)を参照してください。 |

| **Platform Api** | **Windows UI ライブラリ Api** |
| - | - |
| して[[イベント] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)[コマンドのプロパティ](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.command) | [DropDownButton クラス](/uwp/api/microsoft.ui.xaml.controls.dropdownbutton)、 [SplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.splitbutton) [ToggleSplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.togglesplitbutton) |

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ユーザー フォームを送信するなど、すぐにアクションを開始するように**ボタン**を使用します。

別のページに移動するには、アクション ボタンを使用しません。代わりに、 [HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton)を使用します。 詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。
> 例外: ウィザードでのページの移動には、[戻る] と [次へ] というラベルのボタンを使います。 他の種類の下位またはナビゲーションを上位レベルの場合は、使用して[[戻る] ボタン](../basics/navigation-history-and-backwards-navigation.md)。

ユーザーは、操作を繰り返し発生する場合はの**RepeatButton**を使用します。 たとえば、反対の値を増減する、RepeatButton を使用します。

ボタンにその他のオプションを含むフライアウトときの**DropDownButton**を使用します。 既定のプロセスでは、視覚ボタンにフライアウトが含まれていることを提供します。

ユーザーは、すぐにアクションを開始またはいないその他のオプションからを個別に選択できるようにする場合はの**SplitButton**を使用します。

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

> **プレビュー**: DropDownButton[最新の Windows 10 の内部のプレビュー ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)必要です。

の[DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton)は、その他のオプションを含む添付のフライアウトがある視覚的なインジケーターとして、プロセスが表示されているボタンです。 フライアウト; と標準のボタンと同じ動作があります。表示のみとは異なります。

ドロップ ダウン ボタンをクリックしてイベントを継承するが、通常はこれを使用しません。 代わりに、フライアウト プロパティを使用するフライアウトを添付し、フライアウトでメニュー オプションを使用してアクションを起動します。 フライアウトは、ボタンをクリックしたときに自動的に開きます。

> [!TIP]
> フライアウトの詳細については、[メニューおよびコンテキスト メニュー](menus.md)を参照してください。

### <a name="example---drop-down-button"></a>ドロップ ダウン ボタンの使用例

この例では、段落の配置を RichEditBox のためのコマンドを含むフライアウトを使って、ドロップ ダウン ボタンを作成する方法を示します。 (情報とコードの詳細を参照してください[リッチ エディット ボックス](rich-edit-box.md))。

![ドロップ ダウン配置コマンド ボタン](images/drop-down-button-align.png)

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

> **プレビュー**: SplitButton[最新の Windows 10 の内部のプレビュー ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)必要です。

[SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton)を個別に呼び出すことができる 2 つの部分があります。 1 つの部分では、標準のボタンに似ています、すぐにアクションを起動します。 他の部分では、ユーザーが選択できるその他のオプションを含むフライアウトを起動します。

> [!NOTE]
> タッチで呼び出されると、[分割] ボタンのドロップダウン ボタンとして動作します。ボタンの両方の部分では、フライアウトを起動します。 入力には、他の方法でユーザーは個別にボタンのいずれかの半分を呼び出すことができます。

分割ボタンの一般的な動作は次のとおりです。

- ユーザーは、ボタンのパーツをクリックすると、イベントを処理] をクリックして] ボックスで現在選択されている] オプションを起動します。
- 開いているドロップダウンとハンドルの呼び出しのオプションを両方の変更にドロップダウン リスト内のアイテムが選択されている起動し、します。 に、フライアウト アイテムを起動することが重要] ボタンのタッチを使用してイベントが発生しない] をクリックします。

> [!TIP]
> のドロップ内のアイテムを設定することや、呼び出しを処理するには、さまざまな方法があります。 リスト ビューまたは GridView を使用する方法の 1 つが SelectionChanged イベントを処理するには この場合[SingleSelectionFollowsFocus](/uwp/api/windows.ui.xaml.controls.listviewbase.singleselectionfollowsfocus)を**false**に設定します。 これにより、ユーザーがそれぞれの変更のアイテムが起動せず、キーボードを使うと、オプションを移動します。

### <a name="example---split-button"></a>例の分割] ボタン

この例を RichEditBox で選択したテキストの背景色を変更するための分割] ボタンを作成する方法を示します。 (情報とコードの詳細を参照してください[リッチ エディット ボックス](rich-edit-box.md))。

![背景色を選ぶための分割] ボタン](images/split-button-rtb.png)

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

## <a name="create-a-toggle-split-button"></a>表示/非表示の分割] ボタンを作成します。

> **プレビュー**: ToggleSplitButton[最新の Windows 10 の内部のプレビュー ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)必要です。

[ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton)を個別に呼び出すことができる 2 つの部分があります。 1 つの部分に似てトグル ボタンをオンまたはオフにすることができます。 他の部分では、ユーザーが選択できるその他のオプションを含むフライアウトを起動します。

表示/非表示の分割] ボタンは通常、機能を無効にする機能は、ユーザーが選択される複数のオプションを有効またはに使用されます。 たとえば、ドキュメントの編集者] で、される可能性がありますドロップダウンを使用して、リストのスタイルを選択する] リストを有効にします。

> [!NOTE]
> タッチで呼び出されると、[分割] ボタンのドロップ ダウン ボタンとして動作します。 入力には、他の方法でユーザーは個別にボタンのいずれかの半分を呼び出すことができます。 タッチ] ボタンの両方の部分フライアウトを起動します。 このため、] をオンまたはオフに切り替え] フライアウト コンテンツのオプションを追加する必要があります。

### <a name="differences-with-togglebutton"></a>トグル ボタンとの相違点

[トグル ボタン](/uwp/api/windows.ui.xaml.controls.primitives.togglebutton)] とは異なり ToggleSplitButton に中間状態はありません。 その結果、これらの違いを点に注意する必要があります。

- **IsThreeState**プロパティまたは**中間状態**のイベントを ToggleSplitButton はありません。
- [ToggleSplitButton.IsChecked](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischecked)プロパティは、だけ**ブール値**、**ブール値が null 許容**されません。
- ToggleSplitButton が[IsCheckedChanged](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischeckedchanged)イベントのみ別の**オン**と**オフ**のイベントはありません。

### <a name="example---toggle-split-button"></a>例: 表示/非表示の分割] ボタン

方法の分割] ボタン、トグルを使用してリストのオンとオフを書式設定を有効にして、RichEditBox で、リストのスタイルを変更する次の例を示しています。 (情報とコードの詳細を参照してください[リッチ エディット ボックス](rich-edit-box.md))。

![リストのスタイルを選ぶためのトグル分割] ボタン](images/toggle-split-button-open.png)

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
