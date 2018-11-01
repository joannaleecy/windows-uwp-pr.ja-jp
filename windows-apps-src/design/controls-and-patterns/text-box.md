---
author: Jwmsft
ms.assetid: CC1BF51D-3DAC-4198-ADCB-1770B901C2FC
Description: The TextBox control lets a user enter text into an app.
title: テキスト ボックス
label: Text box
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 43af446513ebb857858c21f0b2859af6febd82d0
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5876700"
---
# <a name="text-box"></a><span data-ttu-id="97245-103">テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="97245-103">Text box</span></span>

 

<span data-ttu-id="97245-104">TextBox コントロールによって、ユーザーはアプリにテキストを入力できます。</span><span class="sxs-lookup"><span data-stu-id="97245-104">The TextBox control lets a user type text into an app.</span></span> <span data-ttu-id="97245-105">通常、1 行のテキストを取得するために使用されますが、複数行のテキストを取得するように構成できます。</span><span class="sxs-lookup"><span data-stu-id="97245-105">It's typically used to capture a single line of text, but can be configured to capture multiple lines of text.</span></span> <span data-ttu-id="97245-106">テキストは、シンプルで同様のプレーンテキスト形式で画面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="97245-106">The text displays on the screen in a simple, uniform, plaintext format.</span></span>

<span data-ttu-id="97245-107">TextBox には、テキスト入力を簡略化するための多くの機能があります。</span><span class="sxs-lookup"><span data-stu-id="97245-107">TextBox has a number of features that can simplify text entry.</span></span> <span data-ttu-id="97245-108">テキストのコピーと貼り付けをサポートする、使い慣れた組み込みのコンテキスト メニューが付属しています。</span><span class="sxs-lookup"><span data-stu-id="97245-108">It comes with a familiar, built-in context menu with support for copying and pasting text.</span></span> <span data-ttu-id="97245-109">[すべてクリア] ボタンによって、ユーザーは入力されているすべてのテキストを簡単に削除できます。</span><span class="sxs-lookup"><span data-stu-id="97245-109">The "clear all" button lets a user quickly delete all text that has been entered.</span></span> <span data-ttu-id="97245-110">スペル チェック機能も組み込まれており、既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="97245-110">It also has spell checking capabilities built in and enabled by default.</span></span>

> <span data-ttu-id="97245-111">**重要な API**: [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)、[Text プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx)</span><span class="sxs-lookup"><span data-stu-id="97245-111">**Important APIs**: [TextBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx), [Text property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="97245-112">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="97245-112">Is this the right control?</span></span>

<span data-ttu-id="97245-113">ユーザーが書式設定されていないテキストを入力、編集できるようにするには、**TextBox** コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-113">Use a **TextBox** control to let a user enter and edit unformatted text, such as in a form.</span></span> <span data-ttu-id="97245-114">TextBox 内のテキストの取得と設定には、[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-114">You can use the [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) property to get and set the text in a TextBox.</span></span>

<span data-ttu-id="97245-115">TextBox を読み取り専用にすることはできますが、これは一時的な条件付きの状態である必要があります。</span><span class="sxs-lookup"><span data-stu-id="97245-115">You can make a TextBox read-only, but this should be a temporary, conditional state.</span></span> <span data-ttu-id="97245-116">テキストを編集可能にしない場合は、代わりに [TextBlock](text-block.md) を使用することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="97245-116">If the text is never editable, consider using a [TextBlock](text-block.md) instead.</span></span>

<span data-ttu-id="97245-117">[PasswordBox](password-box.md) コントロールを使用して、パスワードや、社会保障番号などの機密データを収集できます。</span><span class="sxs-lookup"><span data-stu-id="97245-117">Use a [PasswordBox](password-box.md) control to collect a password or other private data, such as a Social Security number.</span></span> <span data-ttu-id="97245-118">パスワード ボックスは、入力されたテキストの代わりに記号が表示される点を除けば、テキスト入力ボックスに似ています。</span><span class="sxs-lookup"><span data-stu-id="97245-118">A password box looks like a text input box, except that it renders bullets in place of the text that has been entered.</span></span>

<span data-ttu-id="97245-119">ユーザーが検索語句を入力できるようにしたり、入力時に選べる候補リストを表示したりするには、[AutoSuggestBox](auto-suggest-box.md) コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-119">Use an [AutoSuggestBox](auto-suggest-box.md) control to let the user enter search terms or to show the user a list of suggestions to choose from as they type.</span></span>

<span data-ttu-id="97245-120">[RichEditBox](rich-edit-box.md) を使用して、リッチ テキスト ファイルを表示および編集します。</span><span class="sxs-lookup"><span data-stu-id="97245-120">Use a [RichEditBox](rich-edit-box.md) to display and edit rich text files.</span></span>

<span data-ttu-id="97245-121">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97245-121">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="97245-122">例</span><span class="sxs-lookup"><span data-stu-id="97245-122">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="97245-123">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="97245-123">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="97245-124"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/TextBox">アプリを開き、TextBox の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="97245-124">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/TextBox">open the app and see the TextBox in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="97245-125">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="97245-125">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="97245-126">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="97245-126">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

![テキスト ボックス](images/text-box.png)

## <a name="create-a-text-box"></a><span data-ttu-id="97245-128">テキスト ボックスの作成</span><span class="sxs-lookup"><span data-stu-id="97245-128">Create a text box</span></span>

<span data-ttu-id="97245-129">ヘッダーとプレースホルダーのテキストを含むシンプルなテキスト ボックスの XAML を次に示します。</span><span class="sxs-lookup"><span data-stu-id="97245-129">Here's the XAML for a simple text box with a header and placeholder text.</span></span>

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

<span data-ttu-id="97245-130">この XAML で表示されるテキスト ボックスは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="97245-130">Here's the text box that results from this XAML.</span></span>

![シンプルなテキスト ボックス](images/text-box-ex1.png)

### <a name="use-a-text-box-for-data-input-in-a-form"></a><span data-ttu-id="97245-132">フォームでのデータ入力用のテキスト ボックスの使用</span><span class="sxs-lookup"><span data-stu-id="97245-132">Use a text box for data input in a form</span></span>

<span data-ttu-id="97245-133">テキスト ボックスを使用してフォームでデータ入力を受け付け、[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) プロパティを使用してテキスト ボックスから完全なテキスト文字列を取得するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="97245-133">It’s common to use a text box to accept data input on a form, and use the [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) property to get the complete text string from the text box.</span></span> <span data-ttu-id="97245-134">通常、Text プロパティにアクセスするには、送信ボタンのクリックなどのイベントを使用しますが、テキストが変化したときに処理を実行する必要がある場合は、[TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textchanged.aspx) イベントや [TextChanging](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textchanging.aspx) イベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="97245-134">You typically use an event like a submit button click to access the Text property, but you can handle the [TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textchanged.aspx) or [TextChanging](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textchanging.aspx) event if you need to do something when the text changes.</span></span>

<span data-ttu-id="97245-135">[](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.header.aspx)Header[](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.placeholdertext.aspx) (ラベル) と PlaceholderText (透かし) をテキスト コントロールに追加すると、ユーザーに用途を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="97245-135">You can add a [Header](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.header.aspx) (or label) and [PlaceholderText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.placeholdertext.aspx) (or watermark) to the text box to give the user an indication of what the text box is for.</span></span> <span data-ttu-id="97245-136">ヘッダーの外観をカスタマイズするには、Header ではなく [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.headertemplate.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-136">To customize the look of the header, you can set the [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.headertemplate.aspx) property instead of Header.</span></span> <span data-ttu-id="97245-137">*設計については、「ラベルのガイドライン」を参照してください。*</span><span class="sxs-lookup"><span data-stu-id="97245-137">*For design info, see Guidelines for labels*.</span></span>

<span data-ttu-id="97245-138">[MaxLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.maxlength.aspx) プロパティを設定することによって、ユーザーが入力する文字数を制限できます。</span><span class="sxs-lookup"><span data-stu-id="97245-138">You can restrict the number of characters the user can type by setting the [MaxLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.maxlength.aspx) property.</span></span> <span data-ttu-id="97245-139">ただし、MaxLength では、貼り付けられたテキストの長さは制限されません。</span><span class="sxs-lookup"><span data-stu-id="97245-139">However, MaxLength does not restrict the length of pasted text.</span></span> <span data-ttu-id="97245-140">アプリでこれが重要である場合は、[Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) イベントを使って、貼り付けられたテキストを変更します。</span><span class="sxs-lookup"><span data-stu-id="97245-140">Use the [Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) event to modify pasted text if this is important for your app.</span></span>

<span data-ttu-id="97245-141">テキスト ボックスには、テキストがボックスに入力されたときに表示されるすべてクリア ボタン ("X") が含まれています。</span><span class="sxs-lookup"><span data-stu-id="97245-141">The text box includes a clear all button ("X") that appears when text is entered in the box.</span></span> <span data-ttu-id="97245-142">ユーザーが [X] をクリックすると、テキスト ボックス内のテキストがクリアされます。</span><span class="sxs-lookup"><span data-stu-id="97245-142">When a user clicks the "X", the text in the text box is cleared.</span></span> <span data-ttu-id="97245-143">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="97245-143">It looks like this.</span></span>

![すべてクリア ボタンが表示されたテキスト ボックス](images/text-box-clear-all.png)

<span data-ttu-id="97245-145">すべてクリア ボタンは、テキストが含まれフォーカスがある、編集可能な単一行テキスト ボックスにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="97245-145">The clear all button is shown only for editable, single-line text boxes that contain text and have focus.</span></span>

<span data-ttu-id="97245-146">すべてクリア ボタンは、次のいずれかの場合には表示されません。</span><span class="sxs-lookup"><span data-stu-id="97245-146">The clear all button is not shown in any of these cases:</span></span>
- <span data-ttu-id="97245-147">**IsReadOnly** が **true** である</span><span class="sxs-lookup"><span data-stu-id="97245-147">**IsReadOnly** is **true**</span></span>
- <span data-ttu-id="97245-148">**AcceptsReturn** が **true** である</span><span class="sxs-lookup"><span data-stu-id="97245-148">**AcceptsReturn** is **true**</span></span>
- <span data-ttu-id="97245-149">**TextWrap** の値が **NoWrap** 以外である</span><span class="sxs-lookup"><span data-stu-id="97245-149">**TextWrap** has a value other than **NoWrap**</span></span>

### <a name="make-a-text-box-read-only"></a><span data-ttu-id="97245-150">テキスト ボックスを読み取り専用にする</span><span class="sxs-lookup"><span data-stu-id="97245-150">Make a text box read-only</span></span>

<span data-ttu-id="97245-151">[IsReadOnly](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.isreadonly.aspx) プロパティを **true** に設定すると、テキスト ボックスを読み取り専用にすることができます。</span><span class="sxs-lookup"><span data-stu-id="97245-151">You can make a text box read-only by setting the [IsReadOnly](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.isreadonly.aspx) property to **true**.</span></span> <span data-ttu-id="97245-152">通常、アプリでの条件に基づいて、アプリ コードでこのプロパティを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="97245-152">You typically toggle this property in your app code based on conditions in your app.</span></span> <span data-ttu-id="97245-153">テキストを常に読み取り専用にする必要がある場合は、代わりに TextBlock の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="97245-153">If need text that is always read-only, consider using a TextBlock instead.</span></span>

<span data-ttu-id="97245-154">IsReadOnly プロパティを true に設定すると、TextBox を読み取り専用にすることができます。</span><span class="sxs-lookup"><span data-stu-id="97245-154">You can make a TextBox read-only by setting the IsReadOnly property to true.</span></span> <span data-ttu-id="97245-155">たとえば、ユーザーがコメントを入力するための TextBox が特定の条件下でのみ有効になるとします。</span><span class="sxs-lookup"><span data-stu-id="97245-155">For example, you might have a TextBox for a user to enter comments that is enabled only under certain conditions.</span></span> <span data-ttu-id="97245-156">条件が満たされるまでは、TextBox を読み取り専用にすることができます。</span><span class="sxs-lookup"><span data-stu-id="97245-156">You can make the TextBox read-only until the conditions are met.</span></span> <span data-ttu-id="97245-157">テキストの表示のみが必要である場合は、代わりに TextBlock や RichTextBlock の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="97245-157">If you need only to display text, consider using a TextBlock or RichTextBlock instead.</span></span>

<span data-ttu-id="97245-158">読み取り専用テキスト ボックスの見た目は読み取り/書き込み可能なテキスト ボックスと同じであるため、ユーザーを混乱させる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="97245-158">A read-only text box looks the same as a read/write text box, so it might be confusing to a user.</span></span>
<span data-ttu-id="97245-159">ユーザーはテキストを選択してコピーできます。</span><span class="sxs-lookup"><span data-stu-id="97245-159">A user can select and copy text.</span></span>
<span data-ttu-id="97245-160">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="97245-160">IsEnabled</span></span>


### <a name="enable-multi-line-input"></a><span data-ttu-id="97245-161">複数行入力の有効化</span><span class="sxs-lookup"><span data-stu-id="97245-161">Enable multi-line input</span></span>

<span data-ttu-id="97245-162">テキスト ボックスで複数行にテキストを表示するかどうかを制御するために使用できるプロパティが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="97245-162">There are two properties that you can use to control whether the text box displays text on more than one line.</span></span> <span data-ttu-id="97245-163">通常、両方のプロパティを設定して複数行テキスト ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="97245-163">You typically set both properties to make a multi-line text box.</span></span>
- <span data-ttu-id="97245-164">テキスト ボックスで改行文字の入力を受け付けて表示するには、[AcceptsReturn](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.acceptsreturn.aspx) プロパティを **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-164">To let the text box allow and display the newline or return characters, set the [AcceptsReturn](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.acceptsreturn.aspx) property to **true**.</span></span>
- <span data-ttu-id="97245-165">テキストの折り返しを有効にするには、[TextWrapping](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textwrapping.aspx) プロパティを **Wrap** に設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-165">To enable text wrapping, set the [TextWrapping](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.textwrapping.aspx) property to **Wrap**.</span></span> <span data-ttu-id="97245-166">これにより、テキストはテキスト ボックスの端に達すると、行の区切り文字とは無関係に折り返されます。</span><span class="sxs-lookup"><span data-stu-id="97245-166">This causes the text to wrap when it reaches the edge of the text box, independent of line separator characters.</span></span>

> <span data-ttu-id="97245-167">**注**&nbsp;&nbsp;TextBox および RichEditBox は、TextWrapping プロパティの **WrapWholeWords** 値をサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="97245-167">**Note**&nbsp;&nbsp;TextBox and RichEditBox don't support the **WrapWholeWords** value for their TextWrapping properties.</span></span> <span data-ttu-id="97245-168">TextBox.TextWrapping または RichEditBox.TextWrapping の値として WrapWholeWords を使用しようとすると、無効な引数の例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="97245-168">If you try to use WrapWholeWords as a value for TextBox.TextWrapping or RichEditBox.TextWrapping an invalid argument exception is thrown.</span></span>

<span data-ttu-id="97245-169">複数行のテキスト ボックスは、その [Height](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) プロパティや [MaxHeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxheight.aspx) プロパティ、または親コンテナーによって制約されていない場合、テキストを入力すると垂直方向に拡大し続けます。</span><span class="sxs-lookup"><span data-stu-id="97245-169">A multi-line text box will continue to grow vertically as text is entered unless it’s constrained by its [Height](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) or [MaxHeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxheight.aspx) property, or by a parent container.</span></span> <span data-ttu-id="97245-170">複数行テキスト ボックスが、表示領域を越えて拡大しないことをテストし、表示領域を越える場合は拡大を制約する必要があります。</span><span class="sxs-lookup"><span data-stu-id="97245-170">You should test that a multi-line text box doesn’t grow beyond its visible area, and constrain its growth if it does.</span></span> <span data-ttu-id="97245-171">複数行テキスト ボックスの適切な高さを常に指定し、ユーザーが入力するときにテキスト ボックスの高さの拡大を許可しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="97245-171">We recommend that you always specify an appropriate height for a multi-line text box, and not let it grow in height as the user types.</span></span>

<span data-ttu-id="97245-172">スクロール ホイールまたはタッチを使ったスクロールは、必要に応じて自動的に有効になります。</span><span class="sxs-lookup"><span data-stu-id="97245-172">Scrolling using a scroll-wheel or touch is automatically enabled when needed.</span></span> <span data-ttu-id="97245-173">ただし、垂直方向のスクロール バーは、既定では表示されません。</span><span class="sxs-lookup"><span data-stu-id="97245-173">However, the vertical scrollbars are not visible by default.</span></span> <span data-ttu-id="97245-174">垂直方向のスクロール バーを表示するには、次に示すように、[ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibility.aspx) を **Auto** に設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-174">You can show the vertical scrollbars by setting the [ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibility.aspx) to **Auto** on the embedded ScrollViewer, as shown here.</span></span>

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

<span data-ttu-id="97245-175">テキストを追加した後、テキスト ボックスがどのようになるかを次に示します。</span><span class="sxs-lookup"><span data-stu-id="97245-175">Here's what the text box looks like after text is added.</span></span>

![複数行テキスト ボックス](images/text-box-multi-line.png)

### <a name="format-the-text-display"></a><span data-ttu-id="97245-177">テキストの表示形式の設定</span><span class="sxs-lookup"><span data-stu-id="97245-177">Format the text display</span></span>

<span data-ttu-id="97245-178">テキスト ボックス内のテキストを整列するには、[TextAlignment]() プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-178">Use the [TextAlignment]() property to align text within a text box.</span></span> <span data-ttu-id="97245-179">ページのレイアウト内のテキスト ボックスを整列するには、[HorizontalAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) プロパティと [VerticalAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-179">To align the text box within the layout of the page, use the [HorizontalAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) and [VerticalAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) properties.</span></span>

<span data-ttu-id="97245-180">テキスト ボックスが書式設定されていないテキストのみをサポートするときに、ブランド化と一致するようにテキスト ボックスにテキストを表示する方法をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="97245-180">While the text box supports only unformatted text, you can customize how the text is displayed in the text box to match your branding.</span></span> <span data-ttu-id="97245-181">標準的な [Control](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.aspx) プロパティ ([FontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontfamily.aspx)、[FontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontsize.aspx)、[FontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontstyle.aspx)、[Background](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.background.aspx)、[Foreground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.foreground.aspx)、[CharacterSpacing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.characterspacing.aspx) など) を設定して、テキストの外観を変更できます。</span><span class="sxs-lookup"><span data-stu-id="97245-181">You can set standard [Control](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.aspx) properties like [FontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontfamily.aspx), [FontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontsize.aspx), [FontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.fontstyle.aspx), [Background](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.background.aspx), [Foreground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.foreground.aspx), and [CharacterSpacing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.characterspacing.aspx) to change the look of the text.</span></span> <span data-ttu-id="97245-182">これらのプロパティが影響を与えるのは、テキスト ボックスがローカルでテキストを表示する方法だけです。したがって、テキストをコピーしてリッチ テキスト コントロールなどに貼り付けても、書式設定は適用されません。</span><span class="sxs-lookup"><span data-stu-id="97245-182">These properties affect only how the text box displays the text locally, so if you were to copy and paste the text into a rich text control, for example, no formatting would be applied.</span></span>

<span data-ttu-id="97245-183">この例では、テキストの外観をカスタマイズするためにいくつかのプロパティが設定された読み取り専用のテキスト ボックスを示します。</span><span class="sxs-lookup"><span data-stu-id="97245-183">This example shows a read-only text box with several properties set to customize the appearance of the text.</span></span>

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

<span data-ttu-id="97245-184">このテキスト ボックスは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="97245-184">The resulting text box looks like this.</span></span>

![書式設定されたテキスト ボックス](images/text-box-formatted.png)

### <a name="modify-the-context-menu"></a><span data-ttu-id="97245-186">ショートカット メニューの変更</span><span class="sxs-lookup"><span data-stu-id="97245-186">Modify the context menu</span></span>

<span data-ttu-id="97245-187">既定では、テキスト ボックスのショートカット メニューに表示されるコマンドは、テキスト ボックスの状態によって異なります。</span><span class="sxs-lookup"><span data-stu-id="97245-187">By default, the commands shown in the text box context menu depend on the state of the text box.</span></span> <span data-ttu-id="97245-188">たとえば、次のコマンドは、テキスト ボックスが編集可能なときに表示できます。</span><span class="sxs-lookup"><span data-stu-id="97245-188">For example, the following commands can be shown when the text box is editable.</span></span>

<span data-ttu-id="97245-189">コマンド</span><span class="sxs-lookup"><span data-stu-id="97245-189">Command</span></span> | <span data-ttu-id="97245-190">表示される状況</span><span class="sxs-lookup"><span data-stu-id="97245-190">Shown when...</span></span>
------- | -------------
<span data-ttu-id="97245-191">コピー</span><span class="sxs-lookup"><span data-stu-id="97245-191">Copy</span></span> | <span data-ttu-id="97245-192">テキストが選択されている。</span><span class="sxs-lookup"><span data-stu-id="97245-192">text is selected.</span></span>
<span data-ttu-id="97245-193">切り取り</span><span class="sxs-lookup"><span data-stu-id="97245-193">Cut</span></span> | <span data-ttu-id="97245-194">テキストが選択されている。</span><span class="sxs-lookup"><span data-stu-id="97245-194">text is selected.</span></span>
<span data-ttu-id="97245-195">貼り付け</span><span class="sxs-lookup"><span data-stu-id="97245-195">Paste</span></span> | <span data-ttu-id="97245-196">クリップボードにテキストが含まれている。</span><span class="sxs-lookup"><span data-stu-id="97245-196">the clipboard contains text.</span></span>
<span data-ttu-id="97245-197">すべて選択</span><span class="sxs-lookup"><span data-stu-id="97245-197">Select all</span></span> | <span data-ttu-id="97245-198">TextBox にテキストが含まれている。</span><span class="sxs-lookup"><span data-stu-id="97245-198">the TextBox contains text.</span></span>
<span data-ttu-id="97245-199">元に戻す</span><span class="sxs-lookup"><span data-stu-id="97245-199">Undo</span></span> | <span data-ttu-id="97245-200">テキストが変更されている。</span><span class="sxs-lookup"><span data-stu-id="97245-200">text has been changed.</span></span>

<span data-ttu-id="97245-201">ショートカット メニューに表示されるコマンドを変更するには、[ContextMenuOpening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.contextmenuopening.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="97245-201">To modify the commands shown in the context menu, handle the [ContextMenuOpening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.contextmenuopening.aspx) event.</span></span> <span data-ttu-id="97245-202">この処理の例については、[ContextMenu のサンプル](http://go.microsoft.com/fwlink/p/?linkid=234891)のシナリオ 2 をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97245-202">For an example of this, see Scenario 2 of the [ContextMenu sample](http://go.microsoft.com/fwlink/p/?linkid=234891).</span></span> <span data-ttu-id="97245-203">デザインについて詳しくは、「ショートカット メニューのガイドライン」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97245-203">For design info, see Guidelines for context menus.</span></span>

### <a name="select-copy-and-paste"></a><span data-ttu-id="97245-204">選択、コピー、貼り付け</span><span class="sxs-lookup"><span data-stu-id="97245-204">Select, copy, and paste</span></span>

<span data-ttu-id="97245-205">[SelectedText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectedtext.aspx) プロパティを使って、テキスト ボックス内のテキストを取得または設定できます。</span><span class="sxs-lookup"><span data-stu-id="97245-205">You can get or set the selected text in a text box using the [SelectedText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectedtext.aspx) property.</span></span> <span data-ttu-id="97245-206">[SelectionStart](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionstart.aspx) プロパティと [SelectionLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionlength.aspx) プロパティ、[Select](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.select.aspx) メソッドと [SelectAll](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectall.aspx) メソッドを使って、テキストの選択を操作します。</span><span class="sxs-lookup"><span data-stu-id="97245-206">Use the [SelectionStart](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionstart.aspx) and [SelectionLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionlength.aspx) properties, and the [Select](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.select.aspx) and [SelectAll](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectall.aspx) methods, to manipulate the text selection.</span></span> <span data-ttu-id="97245-207">ユーザーがテキストの選択または選択解除を行ったときに操作を実行するには、[SelectionChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionchanged.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="97245-207">Handle the [SelectionChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionchanged.aspx) event to do something when the user selects or de-selects text.</span></span> <span data-ttu-id="97245-208">選択したテキストを強調表示するために使用する色を変更するには、[SelectionHighlightColor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionhighlightcolor.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-208">You can change the color used to highlight the selected text by setting the [SelectionHighlightColor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionhighlightcolor.aspx) property.</span></span>

<span data-ttu-id="97245-209">TextBox は、既定では、コピーと貼り付けをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="97245-209">TextBox supports copy and paste by default.</span></span> <span data-ttu-id="97245-210">アプリの編集可能なテキスト コントロールで、[Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) イベントのカスタム処理を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="97245-210">You can provide custom handling of the [Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) event on editable text controls in your app.</span></span> <span data-ttu-id="97245-211">たとえば、複数行のアドレスから単一行の検索ボックスに貼り付けるときに、改行を削除できます。</span><span class="sxs-lookup"><span data-stu-id="97245-211">For example, you might remove the line breaks from a multi-line address when pasting it into a single-line search box.</span></span> <span data-ttu-id="97245-212">または、貼り付けられたテキストの長さをチェックし、データベースに保存できる最大の長さを超えている場合はユーザーに警告することができます。</span><span class="sxs-lookup"><span data-stu-id="97245-212">Or, you might check the length of the pasted text and warn the user if it exceeds the maximum length that can be saved to a database.</span></span> <span data-ttu-id="97245-213">詳しい説明と例については、[Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) イベントに関するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97245-213">For more info and examples, see the [Paste](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.paste.aspx) event.</span></span>

<span data-ttu-id="97245-214">これらのプロパティとメソッドを使う例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="97245-214">Here, we have an example of these properties and methods in use.</span></span> <span data-ttu-id="97245-215">1 つ目のテキスト ボックス内のテキストを選ぶと、選んだテキストが 2 つ目のテキスト ボックスに表示されます。2 つ目のテキスト ボックスは読み取り専用です。</span><span class="sxs-lookup"><span data-stu-id="97245-215">When you select text in the first text box, the selected text is displayed in the second text box, which is read-only.</span></span> <span data-ttu-id="97245-216">[SelectionLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionlength.aspx) プロパティと [SelectionStart](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionstart.aspx) プロパティの値は、2 つのテキスト ブロックに表示されます。</span><span class="sxs-lookup"><span data-stu-id="97245-216">The values of the [SelectionLength](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionlength.aspx) and [SelectionStart](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionstart.aspx) properties are shown in two text blocks.</span></span> <span data-ttu-id="97245-217">この処理を実行するには、[SelectionChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionchanged.aspx) イベントを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-217">This is done using the [SelectionChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.selectionchanged.aspx) event.</span></span>

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

<span data-ttu-id="97245-218">このコードを実行すると、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="97245-218">Here's the result of this code.</span></span>

![テキスト ボックスで選択されたテキスト](images/text-box-selection.png)

## <a name="choose-the-right-keyboard-for-your-text-control"></a><span data-ttu-id="97245-220">テキスト コントロールに適切なキーボードの選択</span><span class="sxs-lookup"><span data-stu-id="97245-220">Choose the right keyboard for your text control</span></span>

<span data-ttu-id="97245-221">ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力スコープを設定できます。</span><span class="sxs-lookup"><span data-stu-id="97245-221">To help users to enter data using the touch keyboard, or Soft Input Panel (SIP), you can set the input scope of the text control to match the kind of data the user is expected to enter.</span></span>

<span data-ttu-id="97245-222">タッチ キーボードは、アプリがタッチ スクリーン付きのデバイスで実行されているときにテキスト入力に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="97245-222">The touch keyboard can be used for text entry when your app runs on a device with a touch screen.</span></span> <span data-ttu-id="97245-223">タッチ キーボードは、TextBox または RichEditBox などの編集可能な入力フィールドをユーザーがタップしたときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="97245-223">The touch keyboard is invoked when the user taps on an editable input field, such as a TextBox or RichEditBox.</span></span> <span data-ttu-id="97245-224">ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの入力スコープを設定することで、ユーザーがより速く簡単にアプリにデータを入力できるようになります。</span><span class="sxs-lookup"><span data-stu-id="97245-224">You can make it much faster and easier for users to enter data in your app by setting the input scope of the text control to match the kind of data you expect the user to enter.</span></span> <span data-ttu-id="97245-225">入力値の種類は、システムに対してコントロールが予期しているテキスト入力の種類のヒントとなるため、システムはその入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。</span><span class="sxs-lookup"><span data-stu-id="97245-225">The input scope provides a hint to the system about the type of text input expected by the control so the system can provide a specialized touch keyboard layout for the input type.</span></span>

<span data-ttu-id="97245-226">たとえば、テキスト ボックスが 4 桁の PIN の入力専用の場合は、[InputScope](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.inputscope.aspx) プロパティを **Number** に設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-226">For example, if a text box is used only to enter a 4-digit PIN, set the [InputScope](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.inputscope.aspx) property to **Number**.</span></span> <span data-ttu-id="97245-227">これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。</span><span class="sxs-lookup"><span data-stu-id="97245-227">This tells the system to show the number keypad layout, which makes it easier for the user to enter the PIN.</span></span>

> <span data-ttu-id="97245-228">**重要**&nbsp;&nbsp;入力値の種類の設定によって、入力の検証が実行されるわけではありません。また、ユーザーが、ハードウェア キーボードやその他の入力デバイスから入力できなくなることもありません。</span><span class="sxs-lookup"><span data-stu-id="97245-228">**Important**&nbsp;&nbsp;The input scope does not cause any input validation to be performed, and does not prevent the user from providing any input through a hardware keyboard or other input device.</span></span> <span data-ttu-id="97245-229">必要に応じて、コードで入力を検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="97245-229">You are still responsible for validating the input in your code as needed.</span></span>

<span data-ttu-id="97245-230">タッチ キーボードに影響するその他のプロパティとして、[IsSpellCheckEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.isspellcheckenabled.aspx)、[IsTextPredictionEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.istextpredictionenabled.aspx)、[PreventKeyboardDisplayOnProgrammaticFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.preventkeyboarddisplayonprogrammaticfocus.aspx) があります </span><span class="sxs-lookup"><span data-stu-id="97245-230">Other properties that affect the touch keyboard are [IsSpellCheckEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.isspellcheckenabled.aspx), [IsTextPredictionEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.istextpredictionenabled.aspx), and [PreventKeyboardDisplayOnProgrammaticFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.preventkeyboarddisplayonprogrammaticfocus.aspx).</span></span> <span data-ttu-id="97245-231">(IsSpellCheckEnabled は、ハードウェア キーボードを使用する場合にも TextBox に影響します)。</span><span class="sxs-lookup"><span data-stu-id="97245-231">(IsSpellCheckEnabled also affects the TextBox when a hardware keyboard is used.)</span></span>

<span data-ttu-id="97245-232">詳細な情報と例については、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」とプロパティのドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97245-232">For more info and examples, see [Use input scope to change the touch keyboard](https://msdn.microsoft.com/library/windows/apps/mt280229) and the property documentation.</span></span>

## <a name="recommendations"></a><span data-ttu-id="97245-233">推奨事項</span><span class="sxs-lookup"><span data-stu-id="97245-233">Recommendations</span></span>

-   <span data-ttu-id="97245-234">テキスト ボックスの目的がわかりにくい場合は、ラベルまたはプレースホルダー テキストを使用します。</span><span class="sxs-lookup"><span data-stu-id="97245-234">Use a label or placeholder text if the purpose of the text box isn't clear.</span></span> <span data-ttu-id="97245-235">ラベルは、テキスト入力ボックスに値が存在するかどうかに関係なく表示します。</span><span class="sxs-lookup"><span data-stu-id="97245-235">A label is visible whether or not the text input box has a value.</span></span> <span data-ttu-id="97245-236">プレースホルダー テキストはテキスト入力ボックスの内側に表示され、値を入力すると非表示になります。</span><span class="sxs-lookup"><span data-stu-id="97245-236">Placeholder text is displayed inside the text input box and disappears once a value has been entered.</span></span>
-   <span data-ttu-id="97245-237">テキスト ボックスは、入力できる値の範囲に適した幅になるようにします。</span><span class="sxs-lookup"><span data-stu-id="97245-237">Give the text box an appropriate width for the range of values that can be entered.</span></span> <span data-ttu-id="97245-238">単語の長さは言語によって異なるため、アプリを世界対応にする場合は、ローカライズを考慮に入れて幅を調整します。</span><span class="sxs-lookup"><span data-stu-id="97245-238">Word length varies between languages, so take localization into account if you want your app to be world-ready.</span></span>
-   <span data-ttu-id="97245-239">テキスト入力ボックスは、通常、単一行 (`TextWrap = "NoWrap"`) です。</span><span class="sxs-lookup"><span data-stu-id="97245-239">A text input box is typically single-line (`TextWrap = "NoWrap"`).</span></span> <span data-ttu-id="97245-240">ユーザーが長い文字列を入力または編集する必要がある場合は、テキスト入力ボックスを複数行 (`TextWrap = "Wrap"`) に設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-240">When users need to enter or edit a long string, set the text input box to multi-line (`TextWrap = "Wrap"`).</span></span>
-   <span data-ttu-id="97245-241">通常、テキスト入力ボックスは編集可能なテキストに対して使います。</span><span class="sxs-lookup"><span data-stu-id="97245-241">Generally, a text input box is used for editable text.</span></span> <span data-ttu-id="97245-242">ただし、読み取り、選択、コピーはできるが編集はできないように、テキスト入力ボックスを読み取り専用に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="97245-242">But you can make a text input box read-only so that its content can be read, selected, and copied, but not edited.</span></span>
-   <span data-ttu-id="97245-243">画面をすっきりと見せる必要がある場合は、制御するチェック ボックスがオンの場合のみ、一連のテキスト入力ボックスを表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="97245-243">If you need to reduce clutter in a view, consider making a set of text input boxes appear only when a controlling checkbox is checked.</span></span> <span data-ttu-id="97245-244">また、有効な状態のテキスト入力ボックスをチェック ボックスなどのコントロールにバインドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="97245-244">You can also bind the enabled state of a text input box to a control such as a checkbox.</span></span>
-   <span data-ttu-id="97245-245">既に値が入力されているテキスト入力ボックスをユーザーがタップしたときの動作を検討します。</span><span class="sxs-lookup"><span data-stu-id="97245-245">Consider how you want a text input box to behave when it contains a value and the user taps it.</span></span> <span data-ttu-id="97245-246">既定の動作では、単語の間に挿入ポイントが配置され、何も選択されません。この動作は値の置き換えよりも編集に適しています。</span><span class="sxs-lookup"><span data-stu-id="97245-246">The default behavior is appropriate for editing the value rather than replacing it; the insertion point is placed between words and nothing is selected.</span></span> <span data-ttu-id="97245-247">対象のテキスト入力ボックスが、編集よりも主に置き換えに使われる場合は、フォーカスを受け取ったときにフィールドのすべてのテキストを選択し、入力によって選択内容が置き換えられるように設定できます。</span><span class="sxs-lookup"><span data-stu-id="97245-247">If replacing is the most common use case for a given text input box, you can select all the text in the field whenever the control receives focus, and typing replaces the selection.</span></span>

**<span data-ttu-id="97245-248">単一行入力ボックス</span><span class="sxs-lookup"><span data-stu-id="97245-248">Single-line input boxes</span></span>**

-   <span data-ttu-id="97245-249">少量のテキスト情報を多数取得する場合は、いくつかの単一行テキスト ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-249">Use several single-line text boxes to capture many small pieces of text information.</span></span> <span data-ttu-id="97245-250">それらのテキスト ボックスに関連性がある場合は、グループ化します。</span><span class="sxs-lookup"><span data-stu-id="97245-250">If the text boxes are related in nature, group those together.</span></span>

-   <span data-ttu-id="97245-251">単一行テキスト ボックスの幅は、予測される最長の入力値より少し広くします。</span><span class="sxs-lookup"><span data-stu-id="97245-251">Make the size of single-line text boxes slightly wider than the longest anticipated input.</span></span> <span data-ttu-id="97245-252">そのようにするとコントロールの幅が広くなり過ぎる場合は、2 つのコントロールに分割します。</span><span class="sxs-lookup"><span data-stu-id="97245-252">If doing so makes the control too wide, separate it into two controls.</span></span> <span data-ttu-id="97245-253">たとえば、1 つの住所の入力を "Address line 1" と "Address line 2" に分割できます。</span><span class="sxs-lookup"><span data-stu-id="97245-253">For example, you could split a single address input into "Address line 1" and "Address line 2".</span></span>
-   <span data-ttu-id="97245-254">入力できる最大文字数を設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-254">Set a maximum length for characters that can be entered.</span></span> <span data-ttu-id="97245-255">バッキング データ ソースが長い入力文字列を許可しない場合は、入力を制限し、制限に達したら検証ポップアップを使ってユーザーに知らせます。</span><span class="sxs-lookup"><span data-stu-id="97245-255">If the backing data source doesn't allow a long input string, limit the input and use a validation popup to let users know when they reach the limit.</span></span>
-   <span data-ttu-id="97245-256">ユーザーから少量のテキストを収集するには、単一行テキスト入力コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-256">Use single-line text input controls to gather small pieces of text from users.</span></span>

    <span data-ttu-id="97245-257">次の例は、セキュリティの質問への回答を取得する単一行テキスト ボックスを示しています。</span><span class="sxs-lookup"><span data-stu-id="97245-257">The following example shows a single-line text box to capture an answer to a security question.</span></span> <span data-ttu-id="97245-258">回答には短い文字列が想定されるので、単一行テキスト ボックスが適しています。</span><span class="sxs-lookup"><span data-stu-id="97245-258">The answer is expected to be short, and so a single-line text box is appropriate here.</span></span>

    ![基本データ入力](images/guidelines_and_checklist_for_singleline_text_input_type_text.png)

-   <span data-ttu-id="97245-260">特定の書式のデータを入力するには、短い固定サイズの単一行テキスト入力コントロールのセットを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-260">Use a set of short, fixed-sized, single-line text input controls to enter data with a specific format.</span></span>

    ![書式付きのデータ入力](images/textinput_example_productkey.png)

-   <span data-ttu-id="97245-262">文字列を入力または編集するには、単一行の、制約のないテキスト入力コントロールと、ユーザーが有効な値を選択できるように補助するコマンド ボタンを組み合わせて使います。</span><span class="sxs-lookup"><span data-stu-id="97245-262">Use a single-line, unconstrained text input control to enter or edit strings, combined with a command button that helps users select valid values.</span></span>

    ![補助付きのデータ入力](images/textinput_example_assisted.png)


**<span data-ttu-id="97245-264">複数行テキスト入力コントロール</span><span class="sxs-lookup"><span data-stu-id="97245-264">Multi-line text input controls</span></span>**

-   <span data-ttu-id="97245-265">リッチ テキスト ボックスを作る場合は、スタイル設定ボタンを用意し、その動作を実装します。</span><span class="sxs-lookup"><span data-stu-id="97245-265">When you create a rich text box, provide styling buttons and implement their actions.</span></span>
-   <span data-ttu-id="97245-266">アプリのスタイルに合ったフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="97245-266">Use a font that's consistent with the style of your app.</span></span>
-   <span data-ttu-id="97245-267">テキスト コントロールの高さは、典型的な入力が十分に入るように設定します。</span><span class="sxs-lookup"><span data-stu-id="97245-267">Make the height of the text control tall enough to accommodate typical entries.</span></span>
-   <span data-ttu-id="97245-268">最大文字数または単語数を設定して長いテキストを取得する場合、プレーンテキスト ボックスを使い、ライブ実行のカウンターを用意して、制限までの残りの文字数または単語数をユーザーに示します。</span><span class="sxs-lookup"><span data-stu-id="97245-268">When capturing long spans of text with a maximum character or word count, use a plain text box and provide a live-running counter to show the user how many characters or words they have left before they reach the limit.</span></span> <span data-ttu-id="97245-269">カウンターは自分で作成する必要があります。テキスト ボックスの下に配置し、ユーザーが文字や単語を入力するたびに動的に更新します。</span><span class="sxs-lookup"><span data-stu-id="97245-269">You'll need to create the counter yourself; place it below the text box and dynamically update it as the user enters each character or word.</span></span>

    ![長いテキスト](images/guidelines_and_checklist_for_multiline_text_input_text_limits.png)

-   <span data-ttu-id="97245-271">ユーザーの入力中にテキスト入力コントロールの高さが増加するようにはしません。</span><span class="sxs-lookup"><span data-stu-id="97245-271">Don't let your text input controls grow in height while users type.</span></span>
-   <span data-ttu-id="97245-272">ユーザーが 1 行しか必要としていない場合は、複数行テキスト ボックスを使いません。</span><span class="sxs-lookup"><span data-stu-id="97245-272">Don't use a multi-line text box when users only need a single line.</span></span>
-   <span data-ttu-id="97245-273">プレーンテキスト コントロールで十分な場合に、リッチ テキスト コントロールを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="97245-273">Don't use a rich text control if a plain text control is adequate.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="97245-274">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="97245-274">Get the sample code</span></span>

- <span data-ttu-id="97245-275">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="97245-275">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="97245-276">関連記事</span><span class="sxs-lookup"><span data-stu-id="97245-276">Related articles</span></span>

- [<span data-ttu-id="97245-277">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="97245-277">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="97245-278">スペル チェックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="97245-278">Guidelines for spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="97245-279">検索の追加</span><span class="sxs-lookup"><span data-stu-id="97245-279">Adding search</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [<span data-ttu-id="97245-280">テキスト入力のガイドライン</span><span class="sxs-lookup"><span data-stu-id="97245-280">Guidelines for text input</span></span>](text-controls.md)
- [<span data-ttu-id="97245-281">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="97245-281">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="97245-282">PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="97245-282">PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="97245-283">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="97245-283">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
