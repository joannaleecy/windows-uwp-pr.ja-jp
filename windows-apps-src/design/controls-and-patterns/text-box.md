---
ms.assetid: CC1BF51D-3DAC-4198-ADCB-1770B901C2FC
Description: The TextBox control lets a user enter text into an app.
title: テキスト ボックス
label: Text box
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a40449b66d2187aacb60501240a0c38de2dc3abc
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8808687"
---
# <a name="text-box"></a>テキスト ボックス

 

TextBox コントロールによって、ユーザーはアプリにテキストを入力できます。 通常、1 行のテキストを取得するために使用されますが、複数行のテキストを取得するように構成できます。 テキストは、シンプルで同様のプレーンテキスト形式で画面に表示されます。

TextBox には、テキスト入力を簡略化するための多くの機能があります。 テキストのコピーと貼り付けをサポートする、使い慣れた組み込みのコンテキスト メニューが付属しています。 [すべてクリア] ボタンによって、ユーザーは入力されているすべてのテキストを簡単に削除できます。 スペル チェック機能も組み込まれており、既定で有効になっています。

> **重要な API**: [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)、[Text プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ユーザーが書式設定されていないテキストを入力、編集できるようにするには、**TextBox** コントロールを使います。 TextBox 内のテキストの取得と設定には、[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) プロパティを使います。

TextBox を読み取り専用にすることはできますが、これは一時的な条件付きの状態である必要があります。 テキストを編集可能にしない場合は、代わりに [TextBlock](text-block.md) を使用することを検討してください。

[PasswordBox](password-box.md) コントロールを使用して、パスワードや、社会保障番号などの機密データを収集できます。 パスワード ボックスは、入力されたテキストの代わりに記号が表示される点を除けば、テキスト入力ボックスに似ています。

ユーザーが検索語句を入力できるようにしたり、入力時に選べる候補リストを表示したりするには、[AutoSuggestBox](auto-suggest-box.md) コントロールを使います。

[RichEditBox](rich-edit-box.md) を使用して、リッチ テキスト ファイルを表示および編集します。

適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/TextBox">アプリを開き、TextBox の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

![テキスト ボックス](images/text-box.png)

## <a name="create-a-text-box"></a>テキスト ボックスの作成

ヘッダーとプレースホルダーのテキストを含むシンプルなテキスト ボックスの XAML を次に示します。

```xaml
<TextBox Width="500" Header="Notes" PlaceholderText="Type your notes here"/>
```

```csharp
TextBox textBox = new TextBox();
textBox.Width = 500;
textBox.Header = "Notes";
textBox.PlaceholderText = "Type your notes here";
// Add the TextBox to the visual tree.
rootGrid.Children.Add(textBox);
```

この XAML で表示されるテキスト ボックスは次のとおりです。

![シンプルなテキスト ボックス](images/text-box-ex1.png)

### <a name="use-a-text-box-for-data-input-in-a-form"></a>フォームでのデータ入力用のテキスト ボックスの使用

テキスト ボックスを使用してフォームでデータ入力を受け付け、[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) プロパティを使用してテキスト ボックスから完全なテキスト文字列を取得するのが一般的です。 通常、Text プロパティにアクセスするには、送信ボタンのクリックなどのイベントを使用しますが、テキストが変化したときに処理を実行する必要がある場合は、[TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textchanged.aspx) イベントや [TextChanging](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textchanging.aspx) イベントを処理することができます。

[](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.header.aspx)Header[](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.placeholdertext.aspx) (ラベル) と PlaceholderText (透かし) をテキスト コントロールに追加すると、ユーザーに用途を示すことができます。 ヘッダーの外観をカスタマイズするには、Header ではなく [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.headertemplate.aspx) プロパティを設定します。 *設計については、「ラベルのガイドライン」を参照してください。*

[MaxLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.maxlength.aspx) プロパティを設定することによって、ユーザーが入力する文字数を制限できます。 ただし、MaxLength では、貼り付けられたテキストの長さは制限されません。 アプリでこれが重要である場合は、[Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) イベントを使って、貼り付けられたテキストを変更します。

テキスト ボックスには、テキストがボックスに入力されたときに表示されるすべてクリア ボタン ("X") が含まれています。 ユーザーが [X] をクリックすると、テキスト ボックス内のテキストがクリアされます。 次のようになります。

![すべてクリア ボタンが表示されたテキスト ボックス](images/text-box-clear-all.png)

すべてクリア ボタンは、テキストが含まれフォーカスがある、編集可能な単一行テキスト ボックスにのみ表示されます。

すべてクリア ボタンは、次のいずれかの場合には表示されません。
- **IsReadOnly** が **true** である
- **AcceptsReturn** が **true** である
- **TextWrap** の値が **NoWrap** 以外である

### <a name="make-a-text-box-read-only"></a>テキスト ボックスを読み取り専用にする

[IsReadOnly](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.isreadonly.aspx) プロパティを **true** に設定すると、テキスト ボックスを読み取り専用にすることができます。 通常、アプリでの条件に基づいて、アプリ コードでこのプロパティを切り替えます。 テキストを常に読み取り専用にする必要がある場合は、代わりに TextBlock の使用を検討してください。

IsReadOnly プロパティを true に設定すると、TextBox を読み取り専用にすることができます。 たとえば、ユーザーがコメントを入力するための TextBox が特定の条件下でのみ有効になるとします。 条件が満たされるまでは、TextBox を読み取り専用にすることができます。 テキストの表示のみが必要である場合は、代わりに TextBlock や RichTextBlock の使用を検討してください。

読み取り専用テキスト ボックスの見た目は読み取り/書き込み可能なテキスト ボックスと同じであるため、ユーザーを混乱させる可能性があります。
ユーザーはテキストを選択してコピーできます。
IsEnabled


### <a name="enable-multi-line-input"></a>複数行入力の有効化

テキスト ボックスで複数行にテキストを表示するかどうかを制御するために使用できるプロパティが 2 つあります。 通常、両方のプロパティを設定して複数行テキスト ボックスを作成します。
- テキスト ボックスで改行文字の入力を受け付けて表示するには、[AcceptsReturn](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.acceptsreturn.aspx) プロパティを **true** に設定します。
- テキストの折り返しを有効にするには、[TextWrapping](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textwrapping.aspx) プロパティを **Wrap** に設定します。 これにより、テキストはテキスト ボックスの端に達すると、行の区切り文字とは無関係に折り返されます。

> **注**&nbsp;&nbsp;TextBox および RichEditBox は、TextWrapping プロパティの **WrapWholeWords** 値をサポートしていません。 TextBox.TextWrapping または RichEditBox.TextWrapping の値として WrapWholeWords を使用しようとすると、無効な引数の例外がスローされます。

複数行のテキスト ボックスは、その [Height](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) プロパティや [MaxHeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxheight.aspx) プロパティ、または親コンテナーによって制約されていない場合、テキストを入力すると垂直方向に拡大し続けます。 複数行テキスト ボックスが、表示領域を越えて拡大しないことをテストし、表示領域を越える場合は拡大を制約する必要があります。 複数行テキスト ボックスの適切な高さを常に指定し、ユーザーが入力するときにテキスト ボックスの高さの拡大を許可しないことをお勧めします。

スクロール ホイールまたはタッチを使ったスクロールは、必要に応じて自動的に有効になります。 ただし、垂直方向のスクロール バーは、既定では表示されません。 垂直方向のスクロール バーを表示するには、次に示すように、[ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibility.aspx) を **Auto** に設定します。

```xaml
<TextBox AcceptsReturn="True" TextWrapping="Wrap"
         MaxHeight="172" Width="300" Header="Description"
         ScrollViewer.VerticalScrollBarVisibility="Auto"/>
```

```csharp
TextBox textBox = new TextBox();
textBox.AcceptsReturn = true;
textBox.TextWrapping = TextWrapping.Wrap;
textBox.MaxHeight = 172;
textBox.Width = 300;
textBox.Header = "Description";
ScrollViewer.SetVerticalScrollBarVisibility(textBox, ScrollBarVisibility.Auto);
```

テキストを追加した後、テキスト ボックスがどのようになるかを次に示します。

![複数行テキスト ボックス](images/text-box-multi-line.png)

### <a name="format-the-text-display"></a>テキストの表示形式の設定

テキスト ボックス内のテキストを整列するには、[TextAlignment]() プロパティを使います。 ページのレイアウト内のテキスト ボックスを整列するには、[HorizontalAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) プロパティと [VerticalAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) プロパティを使います。

テキスト ボックスが書式設定されていないテキストのみをサポートするときに、ブランド化と一致するようにテキスト ボックスにテキストを表示する方法をカスタマイズできます。 標準的な [Control](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.aspx) プロパティ ([FontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontfamily.aspx)、[FontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontsize.aspx)、[FontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontstyle.aspx)、[Background](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.background.aspx)、[Foreground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.foreground.aspx)、[CharacterSpacing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.characterspacing.aspx) など) を設定して、テキストの外観を変更できます。 これらのプロパティが影響を与えるのは、テキスト ボックスがローカルでテキストを表示する方法だけです。したがって、テキストをコピーしてリッチ テキスト コントロールなどに貼り付けても、書式設定は適用されません。

この例では、テキストの外観をカスタマイズするためにいくつかのプロパティが設定された読み取り専用のテキスト ボックスを示します。

```xaml
<TextBox Text="Sample Text" IsReadOnly="True"
         FontFamily="Verdana" FontSize="24"
         FontWeight="Bold" FontStyle="Italic"
         CharacterSpacing="200" Width="300"
         Foreground="Blue" Background="Beige"/>
```

```csharp
TextBox textBox = new TextBox();
textBox.Text = "Sample Text";
textBox.IsReadOnly = true;
textBox.FontFamily = new FontFamily("Verdana");
textBox.FontSize = 24;
textBox.FontWeight = Windows.UI.Text.FontWeights.Bold;
textBox.FontStyle = Windows.UI.Text.FontStyle.Italic;
textBox.CharacterSpacing = 200;
textBox.Width = 300;
textBox.Background = new SolidColorBrush(Windows.UI.Colors.Beige);
textBox.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);
// Add the TextBox to the visual tree.
rootGrid.Children.Add(textBox);
```

このテキスト ボックスは次のように表示されます。

![書式設定されたテキスト ボックス](images/text-box-formatted.png)

### <a name="modify-the-context-menu"></a>ショートカット メニューの変更

既定では、テキスト ボックスのショートカット メニューに表示されるコマンドは、テキスト ボックスの状態によって異なります。 たとえば、次のコマンドは、テキスト ボックスが編集可能なときに表示できます。

コマンド | 表示される状況
------- | -------------
コピー | テキストが選択されている。
切り取り | テキストが選択されている。
貼り付け | クリップボードにテキストが含まれている。
すべて選択 | TextBox にテキストが含まれている。
元に戻す | テキストが変更されている。

ショートカット メニューに表示されるコマンドを変更するには、[ContextMenuOpening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.contextmenuopening.aspx) イベントを処理します。 この処理の例については、[ContextMenu のサンプル](http://go.microsoft.com/fwlink/p/?linkid=234891)のシナリオ 2 をご覧ください。 デザインについて詳しくは、「ショートカット メニューのガイドライン」をご覧ください。

### <a name="select-copy-and-paste"></a>選択、コピー、貼り付け

[SelectedText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectedtext.aspx) プロパティを使って、テキスト ボックス内のテキストを取得または設定できます。 [SelectionStart](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionstart.aspx) プロパティと [SelectionLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionlength.aspx) プロパティ、[Select](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.select.aspx) メソッドと [SelectAll](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectall.aspx) メソッドを使って、テキストの選択を操作します。 ユーザーがテキストの選択または選択解除を行ったときに操作を実行するには、[SelectionChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionchanged.aspx) イベントを処理します。 選択したテキストを強調表示するために使用する色を変更するには、[SelectionHighlightColor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionhighlightcolor.aspx) プロパティを設定します。

TextBox は、既定では、コピーと貼り付けをサポートしています。 アプリの編集可能なテキスト コントロールで、[Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) イベントのカスタム処理を行うことができます。 たとえば、複数行のアドレスから単一行の検索ボックスに貼り付けるときに、改行を削除できます。 または、貼り付けられたテキストの長さをチェックし、データベースに保存できる最大の長さを超えている場合はユーザーに警告することができます。 詳しい説明と例については、[Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) イベントに関するトピックをご覧ください。

これらのプロパティとメソッドを使う例を次に示します。 1 つ目のテキスト ボックス内のテキストを選ぶと、選んだテキストが 2 つ目のテキスト ボックスに表示されます。2 つ目のテキスト ボックスは読み取り専用です。 [SelectionLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionlength.aspx) プロパティと [SelectionStart](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionstart.aspx) プロパティの値は、2 つのテキスト ブロックに表示されます。 この処理を実行するには、[SelectionChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionchanged.aspx) イベントを使います。

```xaml
<StackPanel>
   <TextBox x:Name="textBox1" Height="75" Width="300" Margin="10"
         Text="The text that is selected in this TextBox will show up in the read only TextBox below."
         TextWrapping="Wrap" AcceptsReturn="True"
         SelectionChanged="TextBox1_SelectionChanged" />
   <TextBox x:Name="textBox2" Height="75" Width="300" Margin="5"
         TextWrapping="Wrap" AcceptsReturn="True" IsReadOnly="True"/>
   <TextBlock x:Name="label1" HorizontalAlignment="Center"/>
   <TextBlock x:Name="label2" HorizontalAlignment="Center"/>
</StackPanel>
```

```csharp
private void TextBox1_SelectionChanged(object sender, RoutedEventArgs e)
{
    textBox2.Text = textBox1.SelectedText;
    label1.Text = "Selection length is " + textBox1.SelectionLength.ToString();
    label2.Text = "Selection starts at " + textBox1.SelectionStart.ToString();
}
```

このコードを実行すると、次のように表示されます。

![テキスト ボックスで選択されたテキスト](images/text-box-selection.png)

## <a name="choose-the-right-keyboard-for-your-text-control"></a>テキスト コントロールに適切なキーボードの選択

ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力スコープを設定できます。

タッチ キーボードは、アプリがタッチ スクリーン付きのデバイスで実行されているときにテキスト入力に使うことができます。 タッチ キーボードは、TextBox または RichEditBox などの編集可能な入力フィールドをユーザーがタップしたときに呼び出されます。 ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの入力スコープを設定することで、ユーザーがより速く簡単にアプリにデータを入力できるようになります。 入力値の種類は、システムに対してコントロールが予期しているテキスト入力の種類のヒントとなるため、システムはその入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。

たとえば、テキスト ボックスが 4 桁の PIN の入力専用の場合は、[InputScope](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.inputscope.aspx) プロパティを **Number** に設定します。 これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。

> **重要**&nbsp;&nbsp;入力値の種類の設定によって、入力の検証が実行されるわけではありません。また、ユーザーが、ハードウェア キーボードやその他の入力デバイスから入力できなくなることもありません。 必要に応じて、コードで入力を検証する必要があります。

タッチ キーボードに影響するその他のプロパティとして、[IsSpellCheckEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.isspellcheckenabled.aspx)、[IsTextPredictionEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.istextpredictionenabled.aspx)、[PreventKeyboardDisplayOnProgrammaticFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.preventkeyboarddisplayonprogrammaticfocus.aspx) があります  (IsSpellCheckEnabled は、ハードウェア キーボードを使用する場合にも TextBox に影響します)。

詳細な情報と例については、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」とプロパティのドキュメントをご覧ください。

## <a name="recommendations"></a>推奨事項

-   テキスト ボックスの目的がわかりにくい場合は、ラベルまたはプレースホルダー テキストを使用します。 ラベルは、テキスト入力ボックスに値が存在するかどうかに関係なく表示します。 プレースホルダー テキストはテキスト入力ボックスの内側に表示され、値を入力すると非表示になります。
-   テキスト ボックスは、入力できる値の範囲に適した幅になるようにします。 単語の長さは言語によって異なるため、アプリを世界対応にする場合は、ローカライズを考慮に入れて幅を調整します。
-   テキスト入力ボックスは、通常、単一行 (`TextWrap = "NoWrap"`) です。 ユーザーが長い文字列を入力または編集する必要がある場合は、テキスト入力ボックスを複数行 (`TextWrap = "Wrap"`) に設定します。
-   通常、テキスト入力ボックスは編集可能なテキストに対して使います。 ただし、読み取り、選択、コピーはできるが編集はできないように、テキスト入力ボックスを読み取り専用に設定することもできます。
-   画面をすっきりと見せる必要がある場合は、制御するチェック ボックスがオンの場合のみ、一連のテキスト入力ボックスを表示することをお勧めします。 また、有効な状態のテキスト入力ボックスをチェック ボックスなどのコントロールにバインドすることもできます。
-   既に値が入力されているテキスト入力ボックスをユーザーがタップしたときの動作を検討します。 既定の動作では、単語の間に挿入ポイントが配置され、何も選択されません。この動作は値の置き換えよりも編集に適しています。 対象のテキスト入力ボックスが、編集よりも主に置き換えに使われる場合は、フォーカスを受け取ったときにフィールドのすべてのテキストを選択し、入力によって選択内容が置き換えられるように設定できます。

**単一行入力ボックス**

-   少量のテキスト情報を多数取得する場合は、いくつかの単一行テキスト ボックスを使います。 それらのテキスト ボックスに関連性がある場合は、グループ化します。

-   単一行テキスト ボックスの幅は、予測される最長の入力値より少し広くします。 そのようにするとコントロールの幅が広くなり過ぎる場合は、2 つのコントロールに分割します。 たとえば、1 つの住所の入力を "Address line 1" と "Address line 2" に分割できます。
-   入力できる最大文字数を設定します。 バッキング データ ソースが長い入力文字列を許可しない場合は、入力を制限し、制限に達したら検証ポップアップを使ってユーザーに知らせます。
-   ユーザーから少量のテキストを収集するには、単一行テキスト入力コントロールを使います。

    次の例は、セキュリティの質問への回答を取得する単一行テキスト ボックスを示しています。 回答には短い文字列が想定されるので、単一行テキスト ボックスが適しています。

    ![基本データ入力](images/guidelines_and_checklist_for_singleline_text_input_type_text.png)

-   特定の書式のデータを入力するには、短い固定サイズの単一行テキスト入力コントロールのセットを使います。

    ![書式付きのデータ入力](images/textinput_example_productkey.png)

-   文字列を入力または編集するには、単一行の、制約のないテキスト入力コントロールと、ユーザーが有効な値を選択できるように補助するコマンド ボタンを組み合わせて使います。

    ![補助付きのデータ入力](images/textinput_example_assisted.png)


**複数行テキスト入力コントロール**

-   リッチ テキスト ボックスを作る場合は、スタイル設定ボタンを用意し、その動作を実装します。
-   アプリのスタイルに合ったフォントを使います。
-   テキスト コントロールの高さは、典型的な入力が十分に入るように設定します。
-   最大文字数または単語数を設定して長いテキストを取得する場合、プレーンテキスト ボックスを使い、ライブ実行のカウンターを用意して、制限までの残りの文字数または単語数をユーザーに示します。 カウンターは自分で作成する必要があります。テキスト ボックスの下に配置し、ユーザーが文字や単語を入力するたびに動的に更新します。

    ![長いテキスト](images/guidelines_and_checklist_for_multiline_text_input_text_limits.png)

-   ユーザーの入力中にテキスト入力コントロールの高さが増加するようにはしません。
-   ユーザーが 1 行しか必要としていない場合は、複数行テキスト ボックスを使いません。
-   プレーンテキスト コントロールで十分な場合に、リッチ テキスト コントロールを使わないでください。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [テキスト コントロール](text-controls.md)
- [スペル チェックのガイドライン](text-controls.md)
- [検索の追加](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [テキスト入力のガイドライン](text-controls.md)
- [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/br209683)
- [PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/br227519)
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
