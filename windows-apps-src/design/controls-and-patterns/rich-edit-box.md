---
Description: 書式付きテキスト、ハイパーリンク、イメージなどを含んだリッチ テキスト ドキュメントの入力と編集には、RichEditBox コントロールを使うことができます。 このコントロールの IsReadOnly プロパティを true に設定すると、RichEditBox を読み取り専用にできます。
title: RichEditBox
ms.assetid: 4AFC0DFA-3B89-434D-9F86-4309CCFF7839
label: Rich edit box
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: fea636f78f4430d5bf8917c1ed720faeac7c4017
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651737"
---
# <a name="rich-edit-box"></a><span data-ttu-id="71f0c-105">リッチ エディット ボックス</span><span class="sxs-lookup"><span data-stu-id="71f0c-105">Rich edit box</span></span>

 

<span data-ttu-id="71f0c-106">書式付きテキスト、ハイパーリンク、イメージなどを含んだリッチ テキスト ドキュメントの入力と編集には、RichEditBox コントロールを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="71f0c-106">You can use a RichEditBox control to enter and edit rich text documents that contain formatted text, hyperlinks, and images.</span></span> <span data-ttu-id="71f0c-107">このコントロールの IsReadOnly プロパティを **true** に設定すると、RichEditBox を読み取り専用にできます。</span><span class="sxs-lookup"><span data-stu-id="71f0c-107">You can make a RichEditBox read-only by setting its IsReadOnly property to **true**.</span></span>

> <span data-ttu-id="71f0c-108">**重要な Api**:[RichEditBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)、[ドキュメント プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.document.aspx)、 [IsReadOnly プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isreadonly.aspx)、 [IsSpellCheckEnabled プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isspellcheckenabled.aspx)</span><span class="sxs-lookup"><span data-stu-id="71f0c-108">**Important APIs**: [RichEditBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx), [Document property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.document.aspx), [IsReadOnly property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isreadonly.aspx), [IsSpellCheckEnabled property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isspellcheckenabled.aspx)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="71f0c-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="71f0c-109">Is this the right control?</span></span>

<span data-ttu-id="71f0c-110">**RichEditBox** を使用して、テキスト ファイルを表示および編集します。</span><span class="sxs-lookup"><span data-stu-id="71f0c-110">Use a **RichEditBox** to display and edit text files.</span></span> <span data-ttu-id="71f0c-111">その他の標準的なテキスト入力ボックスを使用するように、RichEditBox を使用してアプリにユーザー入力を行わないでください。</span><span class="sxs-lookup"><span data-stu-id="71f0c-111">You don't use a RichEditBox to get user input into you app the way you use other standard text input boxes.</span></span> <span data-ttu-id="71f0c-112">代わりに、アプリとは別のテキスト ファイルを操作するために使用します。</span><span class="sxs-lookup"><span data-stu-id="71f0c-112">Rather, you use it to work with text files that are separate from your app.</span></span> <span data-ttu-id="71f0c-113">通常は、RichEditBox に入力されたテキストを .rtf ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="71f0c-113">You typically save text entered into a RichEditBox to a .rtf file.</span></span>
-   <span data-ttu-id="71f0c-114">複数行テキスト ボックスの主な目的がドキュメントの作成 (ブログのエントリ、メール メッセージのコンテンツなど) であり、ドキュメントでリッチ テキストが必要な場合は、リッチ テキスト ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="71f0c-114">If the primary purpose of the multi-line text box is for creating documents (such as blog entries or the contents of an email message), and those documents require rich text, use a rich text box.</span></span>
-   <span data-ttu-id="71f0c-115">ユーザーがテキストを書式設定できるようにする場合は、リッチ テキスト ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="71f0c-115">If you want users to be able to format their text, use a rich text box.</span></span>
-   <span data-ttu-id="71f0c-116">内部的に使うだけで、ユーザーに再表示しないテキストを取得する場合は、プレーンテキスト入力コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="71f0c-116">When capturing text that will only be consumed and not redisplayed to users, use a plain text input control.</span></span>
-   <span data-ttu-id="71f0c-117">他のすべてのシナリオでは、プレーンテキスト入力コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="71f0c-117">For all other scenarios, use a plain text input control.</span></span>

<span data-ttu-id="71f0c-118">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71f0c-118">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="71f0c-119">例</span><span class="sxs-lookup"><span data-stu-id="71f0c-119">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="71f0c-120">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="71f0c-120">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="71f0c-121"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/RichEditBox">アプリを開き、RichEditBox の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="71f0c-121">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/RichEditBox">open the app and see the RichEditBox in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="71f0c-122"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></span><span class="sxs-lookup"><span data-stu-id="71f0c-122"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="71f0c-123"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="71f0c-123"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="71f0c-124">このリッチ エディット ボックスで、リッチ テキスト ドキュメントを開きます。</span><span class="sxs-lookup"><span data-stu-id="71f0c-124">This rich edit box has a rich text document open in it.</span></span> <span data-ttu-id="71f0c-125">書式設定とファイルのボタンは、リッチ エディット ボックスの一部ではありませんが、最小限のスタイル設定ボタンを用意し、その動作を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="71f0c-125">The formatting and file buttons aren't part of the rich edit box, but you should provide at least a minimal set of styling buttons and implement their actions.</span></span>

![開いたドキュメントが用意されたリッチ テキスト ボックス](images/rich-edit-box.png)

## <a name="create-a-rich-edit-box"></a><span data-ttu-id="71f0c-127">リッチ エディット ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="71f0c-127">Create a rich edit box</span></span>

<span data-ttu-id="71f0c-128">既定では、RichEditBox はスペル チェックをサポートします。</span><span class="sxs-lookup"><span data-stu-id="71f0c-128">By default, the RichEditBox supports spell checking.</span></span> <span data-ttu-id="71f0c-129">スペル チェックを無効にするには、[IsSpellCheckEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isspellcheckenabled.aspx) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="71f0c-129">To disable the spell checker, set the [IsSpellCheckEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isspellcheckenabled.aspx) property to **false**.</span></span> <span data-ttu-id="71f0c-130">詳しくは、「[スペル チェックのガイドライン](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71f0c-130">For more info, see the [Guidelines for spell checking](text-controls.md) article.</span></span>

<span data-ttu-id="71f0c-131">RichEditBox のコンテンツを取得するには、このコントロールの [Document](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.document.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="71f0c-131">You use the [Document](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.document.aspx) property of the RichEditBox to get its content.</span></span> <span data-ttu-id="71f0c-132">RichTextBlock コントロールと異なり、RichEditBox のコンテンツは [Windows.UI.Text.ITextDocument](https://msdn.microsoft.com/library/windows/apps/xaml/bb774052.aspx) オブジェクトです。このコンテンツは、[Windows.UI.Xaml.Documents.Block](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.block.aspx) オブジェクトをそのコンテンツとして使います。</span><span class="sxs-lookup"><span data-stu-id="71f0c-132">The content of a RichEditBox is a [Windows.UI.Text.ITextDocument](https://msdn.microsoft.com/library/windows/apps/xaml/bb774052.aspx) object, unlike the RichTextBlock control, which uses [Windows.UI.Xaml.Documents.Block](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.block.aspx) objects as its content.</span></span> <span data-ttu-id="71f0c-133">ITextDocument インターフェイスは、ドキュメントの読み込みとストリームへの保存、テキスト範囲の取得、アクティブな選択内容の取得、変更の取り消しとやり直し、既定の書式設定属性の設定などに利用できます。</span><span class="sxs-lookup"><span data-stu-id="71f0c-133">The ITextDocument interface provides a way to load and save the document to a stream, retrieve text ranges, get the active selection, undo and redo changes, set default formatting attributes, and so on.</span></span>

<span data-ttu-id="71f0c-134">この例では、RichEditBox でリッチ テキスト形式 (.rtf) ファイルの編集、読み込み、保存を行う方法を示します。</span><span class="sxs-lookup"><span data-stu-id="71f0c-134">This example shows how to edit, load, and save a Rich Text Format (.rtf) file in a RichEditBox.</span></span>

```xaml
<RelativePanel Margin="20" HorizontalAlignment="Stretch">
    <RelativePanel.Resources>
        <Style TargetType="AppBarButton">
            <Setter Property="IsCompact" Value="True"/>
        </Style>
    </RelativePanel.Resources>
    <AppBarButton x:Name="openFileButton" Icon="OpenFile"
                  Click="OpenButton_Click" ToolTipService.ToolTip="Open file"/>
    <AppBarButton Icon="Save" Click="SaveButton_Click"
                  ToolTipService.ToolTip="Save file"
                  RelativePanel.RightOf="openFileButton" Margin="8,0,0,0"/>

    <AppBarButton Icon="Bold" Click="BoldButton_Click" ToolTipService.ToolTip="Bold"
                  RelativePanel.LeftOf="italicButton" Margin="0,0,8,0"/>
    <AppBarButton x:Name="italicButton" Icon="Italic" Click="ItalicButton_Click"
                  ToolTipService.ToolTip="Italic" RelativePanel.LeftOf="underlineButton" Margin="0,0,8,0"/>
    <AppBarButton x:Name="underlineButton" Icon="Underline" Click="UnderlineButton_Click"
                  ToolTipService.ToolTip="Underline" RelativePanel.AlignRightWithPanel="True"/>

    <RichEditBox x:Name="editor" Height="200" RelativePanel.Below="openFileButton"
                 RelativePanel.AlignLeftWithPanel="True" RelativePanel.AlignRightWithPanel="True"/>
</RelativePanel>
```


```csharp
private async void OpenButton_Click(object sender, RoutedEventArgs e)
{
    // Open a text file.
    Windows.Storage.Pickers.FileOpenPicker open =
        new Windows.Storage.Pickers.FileOpenPicker();
    open.SuggestedStartLocation =
        Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
    open.FileTypeFilter.Add(".rtf");

    Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

    if (file != null)
    {
        try
        {
            Windows.Storage.Streams.IRandomAccessStream randAccStream =
        await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

            // Load the file into the Document property of the RichEditBox.
            editor.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
        }
        catch (Exception)
        {
            ContentDialog errorDialog = new ContentDialog()
            {
                Title = "File open error",
                Content = "Sorry, I couldn't open the file.",
                PrimaryButtonText = "Ok"
            };

            await errorDialog.ShowAsync();
        }
    }
}

private async void SaveButton_Click(object sender, RoutedEventArgs e)
{
    Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
    savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

    // Dropdown of file types the user can save the file as
    savePicker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });

    // Default file name if the user does not type one in or select a file to replace
    savePicker.SuggestedFileName = "New Document";

    Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
    if (file != null)
    {
        // Prevent updates to the remote version of the file until we
        // finish making changes and call CompleteUpdatesAsync.
        Windows.Storage.CachedFileManager.DeferUpdates(file);
        // write to file
        Windows.Storage.Streams.IRandomAccessStream randAccStream =
            await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

        editor.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);

        // Let Windows know that we're finished changing the file so the
        // other app can update the remote version of the file.
        Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
        if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
        {
            Windows.UI.Popups.MessageDialog errorBox =
                new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
            await errorBox.ShowAsync();
        }
    }
}

private void BoldButton_Click(object sender, RoutedEventArgs e)
{
    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
        charFormatting.Bold = Windows.UI.Text.FormatEffect.Toggle;
        selectedText.CharacterFormat = charFormatting;
    }
}

private void ItalicButton_Click(object sender, RoutedEventArgs e)
{
    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
        charFormatting.Italic = Windows.UI.Text.FormatEffect.Toggle;
        selectedText.CharacterFormat = charFormatting;
    }
}

private void UnderlineButton_Click(object sender, RoutedEventArgs e)
{
    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
        if (charFormatting.Underline == Windows.UI.Text.UnderlineType.None)
        {
            charFormatting.Underline = Windows.UI.Text.UnderlineType.Single;
        }
        else {
            charFormatting.Underline = Windows.UI.Text.UnderlineType.None;
        }
        selectedText.CharacterFormat = charFormatting;
    }
}
```

## <a name="choose-the-right-keyboard-for-your-text-control"></a><span data-ttu-id="71f0c-135">テキスト コントロールに適切なキーボードの選択</span><span class="sxs-lookup"><span data-stu-id="71f0c-135">Choose the right keyboard for your text control</span></span>

<span data-ttu-id="71f0c-136">ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力値の種類を設定できます。</span><span class="sxs-lookup"><span data-stu-id="71f0c-136">To help users to enter data using the touch keyboard, or Soft Input Panel (SIP), you can set the input scope of the text control to match the kind of data the user is expected to enter.</span></span> <span data-ttu-id="71f0c-137">通常、既定のキーボード レイアウトは、リッチ テキスト ドキュメントを扱う場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="71f0c-137">The default keyboard layout is usually appropriate for working with rich text documents.</span></span>

<span data-ttu-id="71f0c-138">入力値の種類の使い方について詳しくは、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71f0c-138">For more info about how to use input scopes, see [Use input scope to change the touch keyboard](https://msdn.microsoft.com/library/windows/apps/mt280229).</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="71f0c-139">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="71f0c-139">Do's and don'ts</span></span>

- <span data-ttu-id="71f0c-140">リッチ テキスト ボックスを作る場合は、スタイル設定ボタンを用意し、その動作を実装します。</span><span class="sxs-lookup"><span data-stu-id="71f0c-140">When you create a rich text box, provide styling buttons and implement their actions.</span></span>
- <span data-ttu-id="71f0c-141">アプリのスタイルに合ったフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="71f0c-141">Use a font that's consistent with the style of your app.</span></span>
- <span data-ttu-id="71f0c-142">テキスト コントロールの高さは、典型的な入力が十分に入るように設定します。</span><span class="sxs-lookup"><span data-stu-id="71f0c-142">Make the height of the text control tall enough to accommodate typical entries.</span></span>
- <span data-ttu-id="71f0c-143">ユーザーの入力中にテキスト入力コントロールの高さが増加するようにはしません。</span><span class="sxs-lookup"><span data-stu-id="71f0c-143">Don't let your text input controls grow in height while users type.</span></span>
- <span data-ttu-id="71f0c-144">ユーザーが 1 行しか必要としていない場合は、複数行テキスト ボックスを使いません。</span><span class="sxs-lookup"><span data-stu-id="71f0c-144">Don't use a multi-line text box when users only need a single line.</span></span>
- <span data-ttu-id="71f0c-145">プレーンテキスト コントロールで十分な場合に、リッチ テキスト コントロールを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="71f0c-145">Don't use a rich text control if a plain text control is adequate.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="71f0c-146">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="71f0c-146">Get the sample code</span></span>

- <span data-ttu-id="71f0c-147">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="71f0c-147">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="71f0c-148">関連記事</span><span class="sxs-lookup"><span data-stu-id="71f0c-148">Related articles</span></span>

- [<span data-ttu-id="71f0c-149">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="71f0c-149">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="71f0c-150">スペル チェックするためのガイドライン</span><span class="sxs-lookup"><span data-stu-id="71f0c-150">Guidelines for spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="71f0c-151">検索の追加</span><span class="sxs-lookup"><span data-stu-id="71f0c-151">Adding search</span></span>](search.md)
- [<span data-ttu-id="71f0c-152">テキスト入力するためのガイドライン</span><span class="sxs-lookup"><span data-stu-id="71f0c-152">Guidelines for text input</span></span>](text-controls.md)
- [<span data-ttu-id="71f0c-153">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="71f0c-153">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="71f0c-154">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="71f0c-154">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
