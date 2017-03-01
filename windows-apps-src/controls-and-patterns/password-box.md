---
author: Jwmsft
Description: "パスワード ボックスは、プライバシーの目的で入力文字が非表示になるテキスト入力ボックスです。"
title: "パスワード ボックスのガイドライン"
ms.assetid: 332B04D6-4FFE-42A4-8B3D-ABE8266C7C18
dev.assetid: 4BFDECC6-9BC5-4FF5-8C63-BB36F6DDF2EF
label: Password box
template: detail.hbs
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 1f4af88235615226954f5a8ca7fd038568d08012
ms.lasthandoff: 02/07/2017

---
# <a name="password-box"></a>パスワード ボックス

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

パスワード ボックスは、プライバシーの目的で入力文字が非表示になるテキスト入力ボックスです。 パスワード ボックスは、入力されたテキストの代わりに代替文字が表示される点を除けば、テキスト ボックスに似ています。 この代替文字は、構成できます。

既定では、ユーザーは表示ボタンを押すことによってパスワード ボックスでパスワードを表示できます。 表示ボタンを無効にしたり、別の方法でパスワードを表示できるようにしたりすることもできます (チェック ボックスなど)。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**PasswordBox クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</li>
<li>[**Password プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.password.aspx)</li>
<li>[**PasswordChar プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchar.aspx)</li>
<li>[**PasswordRevealMode プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordrevealmode.aspx)</li>
<li>[**PasswordChanged イベント**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchanged.aspx)</li>
</ul>
</div>

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

**PasswordBox** コントロールを使用して、社会保障番号などその他の機密データも収集できます。

適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。

## <a name="examples"></a>例

パスワード ボックスには、次のようにいくつかの状態があります。

待機状態のパスワード ボックスでは、目的がユーザーにわかるように、ヒントのテキストを表示できます。

![ヒントのテキストが表示された、待機状態のパスワード ボックス](images/passwordbox-rest-hinttext.png)

ユーザーがパスワード ボックスに入力すると、既定の動作では、入力中のテキストを隠す記号が表示されます。

![テキスト入力中でフォーカス状態のパスワード ボックス](images/passwordbox-focus-typing.png)

右側にある "表示" ボタンを押すと、入力中のパスワード テキストを一時的に表示できます。

![テキストが一時的に表示されたパスワード ボックス](images/passwordbox-text-reveal.png)

## <a name="create-a-password-box"></a>パスワード ボックスの作成

PasswordBox の内容を取得または設定するには [Password](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.password.aspx) プロパティを使います。 [PasswordChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchanged.aspx) イベントのハンドラーでこの操作を実行すると、ユーザーがパスワードを入力している間に検証を実行できます。 ボタンの [Click](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) などの別のイベントを使って、ユーザーが入力を終えてから検証を実行することもできます。

パスワード ボックス コントロールの XAML を次に示します。PasswordBox の既定の外観を確認してください。 ユーザーがパスワードを入力すると、リテラル値の "Password" であるかどうかが調べられます。 一致する場合、メッセージがユーザーに表示されます。

```xaml
<StackPanel>  
  <PasswordBox x:Name="passwordBox" Width="200" MaxLength="16"
             PasswordChanged="passwordBox_PasswordChanged"/>

  <TextBlock x:Name="statusText" Margin="10" HorizontalAlignment="Center" />
</StackPanel>   
```

```csharp
private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
{
    if (passwordBox.Password == "Password")
    {
        statusText.Text = "'Password' is not allowed as a password.";
    }
    else
    {
        statusText.Text = string.Empty;
    }
}
```
このコードを実行し、ユーザーが「Password」と入力した場合に表示される結果を次に示します。

![検証メッセージを表示するパスワード ボックス](images/passwordbox-revealed-validation.png)

### <a name="password-character"></a>パスワード文字

パスワードを隠すために使う文字を変更するには、[PasswordChar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchar.aspx) プロパティを設定します。 ここでは、既定の記号をアスタリスクに置き換えています。

```xaml
<PasswordBox x:Name="passwordBox" Width="200" PasswordChar="*"/>
```

結果は次のようになります。

![カスタムの文字が使われているパスワード ボックス](images/passwordbox-custom-char.png)

### <a name="headers-and-placeholder-text"></a>ヘッダーとプレースホルダー テキスト

[Header](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.header.aspx) プロパティと [PlaceholderText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.placeholdertext.aspx) プロパティを使って PasswordBox のコンテキストを提示することができます。 パスワードを変更するためのフォームなど、複数のボックスがある場合に特に便利です。

```xaml
<PasswordBox x:Name="passwordBox" Width="200" Header="Password" PlaceholderText="Enter your password"/>
```

![ヒントのテキストが表示された、待機状態のパスワード ボックス](images/passwordbox-rest-hinttext.png)

### <a name="maximum-length"></a>最大長

ユーザーが入力できる文字の最大数を指定するには、[MaxLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.maxlength.aspx) プロパティを設定します。 長さの最小値を指定するプロパティはありませんが、アプリのコードでパスワードの長さをチェックしたりその他の検証を実行したりできます。

## <a name="password-reveal-mode"></a>パスワード表示モード

PasswordBox には、ユーザーが押すとパスワード テキストを表示できるボタンが組み込まれています。 ユーザーがこのボタンを操作した結果を次に示します。 ユーザーがボタンを離すと、パスワードは自動的に非表示になります。

![テキストが一時的に表示されたパスワード ボックス](images/passwordbox-text-reveal.png)

### <a name="peek-mode"></a>プレビュー モード

既定で表示されるパスワード表示ボタン ("プレビュー" ボタン) では、 ユーザーがパスワードを表示するにはボタンを押し続けなければならないため、高レベルのセキュリティが維持されます。

[PasswordRevealMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordrevealmode.aspx) プロパティの値は、ユーザーにパスワード表示ボタンが表示されるかどうかを決定する唯一の要因ではありません。 その他の要因には、コントロールの表示幅が最小幅を上回っているか、PasswordBox にフォーカスがあるか、テキスト入力フィールドに文字が含まれているか、などがあります。 パスワード表示ボタンが表示されるのは、PasswordBox が初めてフォーカスを受け取り、文字が入力されたときだけです。 いったん PasswordBox からフォーカスが移動すると、その後にフォーカスが戻っても、パスワードをクリアして入力し直さない限り、パスワード表示ボタンは表示されません。

> **注意:**&nbsp;&nbsp;Windows 10 より前のバージョンでは、パスワード表示ボタンは既定で表示されませんでした。 アプリのセキュリティにより、パスワードを必ず非表示にする必要がある場合は、PasswordRevealMode を Hidden に設定してください。

### <a name="hidden-and-visible-modes"></a>非表示モードと表示モード

[PasswordRevealMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordrevealmode.aspx) には、そのほかに **Hidden** と **Visible** という列挙値があります。これらの列挙値を使うと、パスワード表示ボタンを非表示にして、パスワードを非表示にするかどうかをプログラムで管理できます。

パスワードを常に非表示にするには、PasswordRevealMode を Hidden に設定します。 パスワードを常に非表示にする必要がある場合以外は、カスタム UI を用意して、ユーザーが PasswordRevealMode の Hidden と Visible を切り替えられるようにすることができます。

以前のバージョンの Windows Phone では、PasswordBox のパスワードの表示/非表示の切り替えにチェック ボックスが使われていました。 次の例に示すように、これと同様の UI をアプリで作成することもできます。 [ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx) などのその他のコントロールを使ってユーザーがモードを切り替えられるようにすることもできます。

次の例は、[CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx) を使ってユーザーが PasswordBox の表示モードを切り替えられるようにする方法を示しています。

```xaml
<StackPanel Width="200">
    <PasswordBox Name="passwordBox1"
                 PasswordRevealMode="Hidden"/>
    <CheckBox Name="revealModeCheckBox" Content="Show password"
              IsChecked="False"
              Checked="CheckBox_Changed" Unchecked="CheckBox_Changed"/>
</StackPanel>
```

```csharp
private void CheckBox_Changed(object sender, RoutedEventArgs e)
{
    if (revealModeCheckBox.IsChecked == true)
    {
        passwordBox1.PasswordRevealMode = PasswordRevealMode.Visible;
    }
    else
    {
        passwordBox1.PasswordRevealMode = PasswordRevealMode.Hidden;
    }
}
```

この PasswordBox は次のように表示されます。

![カスタムの表示ボタンが使われているパスワード ボックス](images/passwordbox-custom-reveal.png)

## <a name="choose-the-right-keyboard-for-your-text-control"></a>テキスト コントロールに適切なキーボードの選択

ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力値の種類を設定できます。 PasswordBox でサポートされている入力値の種類は **Password** と **NumericPin** だけです。 それ以外の値はすべて無視されます。

入力値の種類の使い方について詳しくは、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」をご覧ください。

## <a name="recommendations"></a>推奨事項

-   パスワード ボックスの目的がわかりにくい場合は、ラベルまたはプレース ホルダー テキストを使用します。 ラベルは、テキスト入力ボックスに値が存在するかどうかに関係なく表示します。 プレースホルダー テキストはテキスト入力ボックスの内側に表示され、値を入力すると非表示になります。
-   パスワード ボックスは、入力できる値の範囲に適した幅になるようにします。 単語の長さは言語によって異なるため、アプリを世界対応にする場合は、ローカライズを考慮に入れて幅を調整します。
-   パスワード入力ボックスのすぐ横に、他のコントロールを配置しないようにします。 パスワード ボックスには、入力したパスワードをユーザーが確認するための、パスワード表示ボタンがあります。他のコントロールをすぐ横に配置すると、ユーザーが他のコントロールを操作しようとしたときに、誤ってパスワードが表示される可能性があります。 これを防ぐには、パスワード入力ボックスと他のコントロールの間には少し間隔をおくか、他のコントロールを次の行に配置します。
-   アカウントの作成時は、新しいパスワードの入力用および新しいパスワードの確認用として、2 つのパスワード ボックスを提示することを検討します。
-   ログイン時は 1 つのパスワード ボックスのみを表示します。
-   PIN の入力にパスワード ボックスを使う場合は、確認ボタンを使う代わりに、最後の数値が入力されたらすぐに応答を返すことを検討します。



## <a name="related-articles"></a>関連記事

[テキスト コントロール](text-controls.md)

- [スペル チェックのガイドライン](spell-checking-and-prediction.md)
- [検索の追加](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [テキスト入力のガイドライン](text-controls.md)
- [**TextBox クラス**](https://msdn.microsoft.com/library/windows/apps/br209683)
- [**Windows.UI.Xaml.Controls PasswordBox クラス**](https://msdn.microsoft.com/library/windows/apps/br227519)
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)

