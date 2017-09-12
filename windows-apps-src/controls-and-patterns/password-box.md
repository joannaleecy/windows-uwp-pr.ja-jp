---
author: Jwmsft
Description: "パスワード ボックスは、プライバシーの目的で入力文字が非表示になるテキスト入力ボックスです。"
title: "パスワード ボックスのガイドライン"
ms.assetid: 332B04D6-4FFE-42A4-8B3D-ABE8266C7C18
dev.assetid: 4BFDECC6-9BC5-4FF5-8C63-BB36F6DDF2EF
label: Password box
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.openlocfilehash: 742d72d1d62cdb1bc2cd0397589d167cd6d3cfe2
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="password-box"></a><span data-ttu-id="f1ccd-104">パスワード ボックス</span><span class="sxs-lookup"><span data-stu-id="f1ccd-104">Password box</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="f1ccd-105">パスワード ボックスは、プライバシーの目的で入力文字が非表示になるテキスト入力ボックスです。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-105">A password box is a text input box that conceals the characters typed into it for the purpose of privacy.</span></span> <span data-ttu-id="f1ccd-106">パスワード ボックスは、入力されたテキストの代わりに代替文字が表示される点を除けば、テキスト ボックスに似ています。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-106">A password box looks like a text box, except that it renders placeholder characters in place of the text that has been entered.</span></span> <span data-ttu-id="f1ccd-107">この代替文字は、構成できます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-107">You can configure the placeholder character.</span></span>

> <span data-ttu-id="f1ccd-108">**重要な API**: [PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)、[Password プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.password.aspx)、[PasswordChar プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchar.aspx)、[PasswordRevealMode プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordrevealmode.aspx)、[PasswordChanged イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchanged.aspx)</span><span class="sxs-lookup"><span data-stu-id="f1ccd-108">**Important APIs**: [PasswordBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx), [Password property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.password.aspx), [PasswordChar property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchar.aspx), [PasswordRevealMode property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordrevealmode.aspx), [PasswordChanged event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchanged.aspx)</span></span>

<span data-ttu-id="f1ccd-109">既定では、ユーザーは表示ボタンを押すことによってパスワード ボックスでパスワードを表示できます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-109">By default, the password box provides a way for the user to view their password by holding down a reveal button.</span></span> <span data-ttu-id="f1ccd-110">表示ボタンを無効にしたり、別の方法でパスワードを表示できるようにしたりすることもできます (チェック ボックスなど)。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-110">You can disable the reveal button, or provide an alternate mechanism to reveal the password, such as a check box.</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="f1ccd-111">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="f1ccd-111">Is this the right control?</span></span>

<span data-ttu-id="f1ccd-112">**PasswordBox** コントロールを使用して、パスワードや、社会保障番号などの機密データを収集できます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-112">Use a **PasswordBox** control to collect a password or other private data, such as a Social Security number.</span></span>

<span data-ttu-id="f1ccd-113">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-113">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="f1ccd-114">例</span><span class="sxs-lookup"><span data-stu-id="f1ccd-114">Examples</span></span>

<span data-ttu-id="f1ccd-115">パスワード ボックスには、次のようにいくつかの状態があります。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-115">The password box has several states, including these notable ones.</span></span>

<span data-ttu-id="f1ccd-116">待機状態のパスワード ボックスでは、目的がユーザーにわかるように、ヒントのテキストを表示できます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-116">A password box at rest can show hint text so that the user knows its purpose:</span></span>

![ヒントのテキストが表示された、待機状態のパスワード ボックス](images/passwordbox-rest-hinttext.png)

<span data-ttu-id="f1ccd-118">ユーザーがパスワード ボックスに入力すると、既定の動作では、入力中のテキストを隠す記号が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-118">When the user types in a password box, the default behavior is to show bullets that hide the text being entered:</span></span>

![テキスト入力中でフォーカス状態のパスワード ボックス](images/passwordbox-focus-typing.png)

<span data-ttu-id="f1ccd-120">右側にある "表示" ボタンを押すと、入力中のパスワード テキストを一時的に表示できます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-120">Pressing the "reveal" button on the right gives a peek at the password text being entered:</span></span>

![テキストが一時的に表示されたパスワード ボックス](images/passwordbox-text-reveal.png)

## <a name="create-a-password-box"></a><span data-ttu-id="f1ccd-122">パスワード ボックスの作成</span><span class="sxs-lookup"><span data-stu-id="f1ccd-122">Create a password box</span></span>

<span data-ttu-id="f1ccd-123">PasswordBox の内容を取得または設定するには [Password](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.password.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-123">Use the [Password](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.password.aspx) property to get or set the contents of the PasswordBox.</span></span> <span data-ttu-id="f1ccd-124">[PasswordChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchanged.aspx) イベントのハンドラーでこの操作を実行すると、ユーザーがパスワードを入力している間に検証を実行できます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-124">You can do this in the handler for the [PasswordChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchanged.aspx) event to perform validation while the user enters the password.</span></span> <span data-ttu-id="f1ccd-125">ボタンの [Click](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) などの別のイベントを使って、ユーザーが入力を終えてから検証を実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-125">Or, you can use another event, like a button [Click](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx), to perform validation after the user completes the text entry.</span></span>

<span data-ttu-id="f1ccd-126">パスワード ボックス コントロールの XAML を次に示します。PasswordBox の既定の外観を確認してください。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-126">Here's the XAML for a password box control that demonstrates the default look of the PasswordBox.</span></span> <span data-ttu-id="f1ccd-127">ユーザーがパスワードを入力すると、リテラル値の "Password" であるかどうかが調べられます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-127">When the user enters a password, you check to see if it's the literal value, "Password".</span></span> <span data-ttu-id="f1ccd-128">一致する場合、メッセージがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-128">If it is, you display a message to the user.</span></span>

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
<span data-ttu-id="f1ccd-129">このコードを実行し、ユーザーが「Password」と入力した場合に表示される結果を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-129">Here's the result when this code runs and the user enters "Password".</span></span>

![検証メッセージを表示するパスワード ボックス](images/passwordbox-revealed-validation.png)

### <a name="password-character"></a><span data-ttu-id="f1ccd-131">パスワード文字</span><span class="sxs-lookup"><span data-stu-id="f1ccd-131">Password character</span></span>

<span data-ttu-id="f1ccd-132">パスワードを隠すために使う文字を変更するには、[PasswordChar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchar.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-132">You can change the character used to mask the password by setting the [PasswordChar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchar.aspx) property.</span></span> <span data-ttu-id="f1ccd-133">ここでは、既定の記号をアスタリスクに置き換えています。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-133">Here, the default bullet is replaced with an asterisk.</span></span>

```xaml
<PasswordBox x:Name="passwordBox" Width="200" PasswordChar="*"/>
```

<span data-ttu-id="f1ccd-134">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-134">The result looks like this.</span></span>

![カスタムの文字が使われているパスワード ボックス](images/passwordbox-custom-char.png)

### <a name="headers-and-placeholder-text"></a><span data-ttu-id="f1ccd-136">ヘッダーとプレースホルダー テキスト</span><span class="sxs-lookup"><span data-stu-id="f1ccd-136">Headers and placeholder text</span></span>

<span data-ttu-id="f1ccd-137">[Header](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.header.aspx) プロパティと [PlaceholderText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.placeholdertext.aspx) プロパティを使って PasswordBox のコンテキストを提示することができます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-137">You can use the [Header](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.header.aspx) and [PlaceholderText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.placeholdertext.aspx) properties to provide context for the PasswordBox.</span></span> <span data-ttu-id="f1ccd-138">パスワードを変更するためのフォームなど、複数のボックスがある場合に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-138">This is especially useful when you have multiple boxes, such as on a form to change a password.</span></span>

```xaml
<PasswordBox x:Name="passwordBox" Width="200" Header="Password" PlaceholderText="Enter your password"/>
```

![ヒントのテキストが表示された、待機状態のパスワード ボックス](images/passwordbox-rest-hinttext.png)

### <a name="maximum-length"></a><span data-ttu-id="f1ccd-140">最大長</span><span class="sxs-lookup"><span data-stu-id="f1ccd-140">Maximum length</span></span>

<span data-ttu-id="f1ccd-141">ユーザーが入力できる文字の最大数を指定するには、[MaxLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.maxlength.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-141">Specify the maximum number of characters that the user can enter by setting the [MaxLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.maxlength.aspx) property.</span></span> <span data-ttu-id="f1ccd-142">長さの最小値を指定するプロパティはありませんが、アプリのコードでパスワードの長さをチェックしたりその他の検証を実行したりできます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-142">There is no property to specify a minimum length, but you can check the password length, and perform any other validation, in your app code.</span></span>

## <a name="password-reveal-mode"></a><span data-ttu-id="f1ccd-143">パスワード表示モード</span><span class="sxs-lookup"><span data-stu-id="f1ccd-143">Password reveal mode</span></span>

<span data-ttu-id="f1ccd-144">PasswordBox には、ユーザーが押すとパスワード テキストを表示できるボタンが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-144">The PasswordBox has a built-in button that the user can press to display the password text.</span></span> <span data-ttu-id="f1ccd-145">ユーザーがこのボタンを操作した結果を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-145">Here's the result of the user's action.</span></span> <span data-ttu-id="f1ccd-146">ユーザーがボタンを離すと、パスワードは自動的に非表示になります。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-146">When the user releases it, the password is automatically hidden again.</span></span>

![テキストが一時的に表示されたパスワード ボックス](images/passwordbox-text-reveal.png)

### <a name="peek-mode"></a><span data-ttu-id="f1ccd-148">プレビュー モード</span><span class="sxs-lookup"><span data-stu-id="f1ccd-148">Peek mode</span></span>

<span data-ttu-id="f1ccd-149">既定で表示されるパスワード表示ボタン ("プレビュー" ボタン) では、</span><span class="sxs-lookup"><span data-stu-id="f1ccd-149">By default, the password reveal button (or "peek" button) is shown.</span></span> <span data-ttu-id="f1ccd-150">ユーザーがパスワードを表示するにはボタンを押し続けなければならないため、高レベルのセキュリティが維持されます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-150">The user must continuously press the button to view the password, so that a high level of security is maintained.</span></span>

<span data-ttu-id="f1ccd-151">[PasswordRevealMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordrevealmode.aspx) プロパティの値は、ユーザーにパスワード表示ボタンが表示されるかどうかを決定する唯一の要因ではありません。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-151">The value of the [PasswordRevealMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordrevealmode.aspx) property is not the only factor that determines whether a password reveal button is visible to the user.</span></span> <span data-ttu-id="f1ccd-152">その他の要因には、コントロールの表示幅が最小幅を上回っているか、PasswordBox にフォーカスがあるか、テキスト入力フィールドに文字が含まれているか、などがあります。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-152">Other factors include whether the control is displayed above a minimum width, whether the PasswordBox has focus, and whether the text entry field contains at least one character.</span></span> <span data-ttu-id="f1ccd-153">パスワード表示ボタンが表示されるのは、PasswordBox が初めてフォーカスを受け取り、文字が入力されたときだけです。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-153">The password reveal button is shown only when the PasswordBox receives focus for the first time and a character is entered.</span></span> <span data-ttu-id="f1ccd-154">いったん PasswordBox からフォーカスが移動すると、その後にフォーカスが戻っても、パスワードをクリアして入力し直さない限り、パスワード表示ボタンは表示されません。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-154">If the PasswordBox loses focus and then regains focus, the reveal button is not shown again unless the password is cleared and character entry starts over.</span></span>

> <span data-ttu-id="f1ccd-155">**注意:**&nbsp;&nbsp;Windows 10 より前のバージョンでは、パスワード表示ボタンは既定で表示されませんでした。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-155">**Caution**&nbsp;&nbsp;Prior to Windows 10, the password reveal button was not shown by default.</span></span> <span data-ttu-id="f1ccd-156">アプリのセキュリティにより、パスワードを必ず非表示にする必要がある場合は、PasswordRevealMode を Hidden に設定してください。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-156">If the security of your app requires that the password is always obscured, be sure to set PasswordRevealMode to Hidden.</span></span>

### <a name="hidden-and-visible-modes"></a><span data-ttu-id="f1ccd-157">非表示モードと表示モード</span><span class="sxs-lookup"><span data-stu-id="f1ccd-157">Hidden and Visible modes</span></span>

<span data-ttu-id="f1ccd-158">[PasswordRevealMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordrevealmode.aspx) には、そのほかに **Hidden** と **Visible** という列挙値があります。これらの列挙値を使うと、パスワード表示ボタンを非表示にして、パスワードを非表示にするかどうかをプログラムで管理できます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-158">The other [PasswordRevealMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordrevealmode.aspx) enumeration values, **Hidden** and **Visible**, hide the password reveal button and let you programmatically manage whether the password is obscured.</span></span>

<span data-ttu-id="f1ccd-159">パスワードを常に非表示にするには、PasswordRevealMode を Hidden に設定します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-159">To always obscure the password, set PasswordRevealMode to Hidden.</span></span> <span data-ttu-id="f1ccd-160">パスワードを常に非表示にする必要がある場合以外は、カスタム UI を用意して、ユーザーが PasswordRevealMode の Hidden と Visible を切り替えられるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-160">Unless you need the password to be always obscured, you can provide a custom UI to let the user toggle the PasswordRevealMode between Hidden and Visible.</span></span>

<span data-ttu-id="f1ccd-161">以前のバージョンの Windows Phone では、PasswordBox のパスワードの表示/非表示の切り替えにチェック ボックスが使われていました。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-161">In previous versions of Windows Phone, PasswordBox used a check box to toggle whether the password was obscured.</span></span> <span data-ttu-id="f1ccd-162">次の例に示すように、これと同様の UI をアプリで作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-162">You can create a similar UI for your app, as shown in the following example.</span></span> <span data-ttu-id="f1ccd-163">[ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx) などのその他のコントロールを使ってユーザーがモードを切り替えられるようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-163">You can also use other controls, like [ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx), to let the user switch modes.</span></span>

<span data-ttu-id="f1ccd-164">次の例は、[CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx) を使ってユーザーが PasswordBox の表示モードを切り替えられるようにする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-164">This example shows how to use a [CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx) to let a user switch the reveal mode of a PasswordBox.</span></span>

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

<span data-ttu-id="f1ccd-165">この PasswordBox は次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-165">This PasswordBox looks like this.</span></span>

![カスタムの表示ボタンが使われているパスワード ボックス](images/passwordbox-custom-reveal.png)

## <a name="choose-the-right-keyboard-for-your-text-control"></a><span data-ttu-id="f1ccd-167">テキスト コントロールに適切なキーボードの選択</span><span class="sxs-lookup"><span data-stu-id="f1ccd-167">Choose the right keyboard for your text control</span></span>

<span data-ttu-id="f1ccd-168">ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力値の種類を設定できます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-168">To help users to enter data using the touch keyboard, or Soft Input Panel (SIP), you can set the input scope of the text control to match the kind of data the user is expected to enter.</span></span> <span data-ttu-id="f1ccd-169">PasswordBox でサポートされている入力値の種類は **Password** と **NumericPin** だけです。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-169">PasswordBox supports only the **Password** and **NumericPin** input scope values.</span></span> <span data-ttu-id="f1ccd-170">それ以外の値はすべて無視されます。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-170">Any other value is ignored.</span></span>

<span data-ttu-id="f1ccd-171">入力値の種類の使い方について詳しくは、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-171">For more info about how to use input scopes, see [Use input scope to change the touch keyboard](https://msdn.microsoft.com/library/windows/apps/mt280229).</span></span>

## <a name="recommendations"></a><span data-ttu-id="f1ccd-172">推奨事項</span><span class="sxs-lookup"><span data-stu-id="f1ccd-172">Recommendations</span></span>

-   <span data-ttu-id="f1ccd-173">パスワード ボックスの目的がわかりにくい場合は、ラベルまたはプレース ホルダー テキストを使用します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-173">Use a label or placeholder text if the purpose of the password box isn't clear.</span></span> <span data-ttu-id="f1ccd-174">ラベルは、テキスト入力ボックスに値が存在するかどうかに関係なく表示します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-174">A label is visible whether or not the text input box has a value.</span></span> <span data-ttu-id="f1ccd-175">プレースホルダー テキストはテキスト入力ボックスの内側に表示され、値を入力すると非表示になります。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-175">Placeholder text is displayed inside the text input box and disappears once a value has been entered.</span></span>
-   <span data-ttu-id="f1ccd-176">パスワード ボックスは、入力できる値の範囲に適した幅になるようにします。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-176">Give the password box an appropriate width for the range of values that can be entered.</span></span> <span data-ttu-id="f1ccd-177">単語の長さは言語によって異なるため、アプリを世界対応にする場合は、ローカライズを考慮に入れて幅を調整します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-177">Word length varies between languages, so take localization into account if you want your app to be world-ready.</span></span>
-   <span data-ttu-id="f1ccd-178">パスワード入力ボックスのすぐ横に、他のコントロールを配置しないようにします。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-178">Don't put another control right next to a password input box.</span></span> <span data-ttu-id="f1ccd-179">パスワード ボックスには、入力したパスワードをユーザーが確認するための、パスワード表示ボタンがあります。他のコントロールをすぐ横に配置すると、ユーザーが他のコントロールを操作しようとしたときに、誤ってパスワードが表示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-179">The password box has a password reveal button for users to verify the passwords they have typed, and having another control right next to it might make users accidentally reveal their passwords when they try to interact with the other control.</span></span> <span data-ttu-id="f1ccd-180">これを防ぐには、パスワード入力ボックスと他のコントロールの間には少し間隔をおくか、他のコントロールを次の行に配置します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-180">To prevent this from happening, put some spacing between the password in put box and the other control, or put the other control on the next line.</span></span>
-   <span data-ttu-id="f1ccd-181">アカウントの作成時は、新しいパスワードの入力用および新しいパスワードの確認用として、2 つのパスワード ボックスを提示することを検討します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-181">Consider presenting two password boxes for account creation: one for the new password, and a second to confirm the new password.</span></span>
-   <span data-ttu-id="f1ccd-182">ログイン時は 1 つのパスワード ボックスのみを表示します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-182">Only show a single password box for logins.</span></span>
-   <span data-ttu-id="f1ccd-183">PIN の入力にパスワード ボックスを使う場合は、確認ボタンを使う代わりに、最後の数値が入力されたらすぐに応答を返すことを検討します。</span><span class="sxs-lookup"><span data-stu-id="f1ccd-183">When a password box is used to enter a PIN, consider providing an instant response as soon as the last number is entered instead of using a confirmation button.</span></span>



## <a name="related-articles"></a><span data-ttu-id="f1ccd-184">関連記事</span><span class="sxs-lookup"><span data-stu-id="f1ccd-184">Related articles</span></span>

[<span data-ttu-id="f1ccd-185">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="f1ccd-185">Text controls</span></span>](text-controls.md)

- [<span data-ttu-id="f1ccd-186">スペル チェックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="f1ccd-186">Guidelines for spell checking</span></span>](spell-checking-and-prediction.md)
- [<span data-ttu-id="f1ccd-187">検索の追加</span><span class="sxs-lookup"><span data-stu-id="f1ccd-187">Adding search</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [<span data-ttu-id="f1ccd-188">テキスト入力のガイドライン</span><span class="sxs-lookup"><span data-stu-id="f1ccd-188">Guidelines for text input</span></span>](text-controls.md)
- [<span data-ttu-id="f1ccd-189">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="f1ccd-189">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="f1ccd-190">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="f1ccd-190">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="f1ccd-191">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="f1ccd-191">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
