---
author: Jwmsft
Description: Consider how often we read text in our daily lives - in email, a book, a road sign, the prices on a menu, tire pressure markings, or posters on a street pole.
title: テキスト コントロール
ms.assetid: 43DC68BF-FA86-43D2-8807-70A359453048
label: Text controls
template: detail.hbs
ms.author: jimwalk
ms.date: 10/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: ad7326acf728aef66f10c72ee04461fd90e5f775
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4424876"
---
# <a name="text-controls"></a><span data-ttu-id="e2092-103">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="e2092-103">Text controls</span></span>

<span data-ttu-id="e2092-104">テキスト コントロールは、テキスト入力ボックス、パスワード ボックス、自動提案ボックス、テキスト ブロックで構成されています。</span><span class="sxs-lookup"><span data-stu-id="e2092-104">Text controls consist of text input boxes, password boxes, auto-suggest boxes, and text blocks.</span></span> <span data-ttu-id="e2092-105">XAML フレームワークには、テキストのレンダリング、入力、編集用のいくつかのコントロールと、テキストの書式設定用のプロパティのセットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e2092-105">The XAML framework provides several controls for rendering, entering, and editing text, and a set of properties for formatting the text.</span></span>

- <span data-ttu-id="e2092-106">読み取り専用テキストを表示するためのコントロールは、[TextBlock](text-block.md) および [RichTextBlock](rich-text-block.md) です。</span><span class="sxs-lookup"><span data-stu-id="e2092-106">The controls for displaying read-only text are [TextBlock](text-block.md) and [RichTextBlock](rich-text-block.md).</span></span>
- <span data-ttu-id="e2092-107">テキスト入力と編集用のコントロールは: [TextBox](text-box.md)、 [RichEditBox](rich-edit-box.md)、 [AutoSuggestBox](auto-suggest-box.md)、および[PasswordBox](password-box.md)します。</span><span class="sxs-lookup"><span data-stu-id="e2092-107">The controls for text entry and editing are: [TextBox](text-box.md), [RichEditBox](rich-edit-box.md), [AutoSuggestBox](auto-suggest-box.md), and [PasswordBox](password-box.md).</span></span>

> <span data-ttu-id="e2092-108">**重要な Api**: [TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、 [RichTextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)、 [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)、 [RichEditBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)、 [AutoSuggestBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)、 [PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="e2092-108">**Important APIs**: [TextBlock class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx), [RichTextBlock class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx), [TextBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx), [RichEditBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx), [AutoSuggestBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx), [PasswordBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="e2092-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="e2092-109">Is this the right control?</span></span>

<span data-ttu-id="e2092-110">使うテキスト コントロールは、シナリオによって異なります。</span><span class="sxs-lookup"><span data-stu-id="e2092-110">The text control you use depends on your scenario.</span></span> <span data-ttu-id="e2092-111">以下の情報を参考にして、アプリに適切なテキスト コントロールを選んでください。</span><span class="sxs-lookup"><span data-stu-id="e2092-111">Use this info to pick the right text control to use in your app.</span></span>

### <a name="render-read-only-text"></a><span data-ttu-id="e2092-112">読み取り専用テキストのレンダリング</span><span class="sxs-lookup"><span data-stu-id="e2092-112">Render read-only text</span></span>

<span data-ttu-id="e2092-113">**TextBlock** を使用して、アプリ内の読み取り専用テキストの大半を表示します。</span><span class="sxs-lookup"><span data-stu-id="e2092-113">Use a **TextBlock** to display most read-only text in your app.</span></span> <span data-ttu-id="e2092-114">これを使用すると、単一行または複数行のテキスト、インライン ハイパーリンク、書式 (太字、斜体、下線付きなど) が設定されたテキストを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-114">You can use it to display single-line or multi-line text, inline hyperlinks, and text with formatting like bold, italic, or underlined.</span></span>

<span data-ttu-id="e2092-115">TextBlock は、一般的に、RichTextBlock より使い方が簡単で、テキスト レンダリングのパフォーマンスが優れているため、ほとんどのアプリで UI テキストに適しています。</span><span class="sxs-lookup"><span data-stu-id="e2092-115">TextBlock is typically easier to use and provides better text rendering performance than RichTextBlock, so it's preferred for most app UI text.</span></span> <span data-ttu-id="e2092-116">[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) プロパティの値を取得することによって、アプリ内で TextBlock のテキストに容易にアクセスして使用することができます。</span><span class="sxs-lookup"><span data-stu-id="e2092-116">You can easily access and use text from a TextBlock in your app by getting the value of the [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) property.</span></span>

<span data-ttu-id="e2092-117">テキストのレンダリング方法をカスタマイズするための書式設定オプションも、同じものが数多く用意されています。</span><span class="sxs-lookup"><span data-stu-id="e2092-117">It also provides many of the same formatting options for customizing how your text is rendered.</span></span> <span data-ttu-id="e2092-118">テキスト内に改行を配置することはできますが、TextBlock は単一の段落を表示するために設計されており、テキストのインデントはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e2092-118">Although you can put line breaks in the text, TextBlock is designed to display a single paragraph and doesn’t support text indentation.</span></span>

<span data-ttu-id="e2092-119">複数の段落、段組テキスト、インライン UI 要素 (画像など) をサポートする必要がある場合は、**RichTextBlock** を使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-119">Use a **RichTextBlock** when you need support for multiple paragraphs, multi-column text or other complex text layouts, or inline UI elements like images.</span></span> <span data-ttu-id="e2092-120">RichTextBlock には、高度なテキスト レイアウトのための機能がいくつか用意されています。</span><span class="sxs-lookup"><span data-stu-id="e2092-120">RichTextBlock provides several features for advanced text layout.</span></span>

<span data-ttu-id="e2092-121">RichTextBlock のコンテンツ プロパティは [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) プロパティです。このプロパティでは、[Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素によって段落に基づくテキストがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="e2092-121">The content property of RichTextBlock is the [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) property, which supports paragraph based text via the [Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) element.</span></span> <span data-ttu-id="e2092-122">アプリ内でコントロールのテキスト コンテンツに簡単にアクセスすることができる **Text** プロパティは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="e2092-122">It doesn't have a **Text** property that you can use to easily access the control's text content in your app.</span></span>  

### <a name="text-input"></a><span data-ttu-id="e2092-123">テキスト入力</span><span class="sxs-lookup"><span data-stu-id="e2092-123">Text input</span></span>

<span data-ttu-id="e2092-124">ユーザーが書式設定されていないテキストを入力、編集できるようにするには、**TextBox** コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-124">Use a **TextBox** control to let a user enter and edit unformatted text, such as in a form.</span></span> <span data-ttu-id="e2092-125">TextBox 内のテキストの取得と設定には、[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-125">You can use the [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) property to get and set the text in a TextBox.</span></span>

<span data-ttu-id="e2092-126">TextBox を読み取り専用にすることはできますが、これは一時的な条件付きの状態である必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2092-126">You can make a TextBox read-only, but this should be a temporary, conditional state.</span></span> <span data-ttu-id="e2092-127">テキストを編集可能にしない場合は、代わりに TextBlock を使用することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="e2092-127">If the text is never editable, consider using a TextBlock instead.</span></span>

<span data-ttu-id="e2092-128">**PasswordBox** コントロールを使用して、パスワードや、社会保障番号などの機密データを収集できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-128">Use a **PasswordBox** control to collect a password or other private data, such as a Social Security number.</span></span> <span data-ttu-id="e2092-129">パスワード ボックスは、プライバシー保護用に入力文字が非表示になるテキスト入力ボックスです。</span><span class="sxs-lookup"><span data-stu-id="e2092-129">A password box is a text input box that conceals the characters typed in it for the sake of privacy.</span></span> <span data-ttu-id="e2092-130">パスワード ボックスは、入力されたテキストの代わりに記号が表示される点を除けば、テキスト入力ボックスに似ています。</span><span class="sxs-lookup"><span data-stu-id="e2092-130">A password box looks like a text input box, except that it renders bullets in place of the text that has been entered.</span></span> <span data-ttu-id="e2092-131">この記号は、カスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="e2092-131">The bullet character can be customized.</span></span>

<span data-ttu-id="e2092-132">**AutoSuggestBox** コントロールを使って、ユーザーが入力時に選べる候補リストを表示します。</span><span class="sxs-lookup"><span data-stu-id="e2092-132">Use an **AutoSuggestBox** control to show the user a list of suggestions to choose from as they type.</span></span> <span data-ttu-id="e2092-133">自動提案ボックスは、基本的な検索候補の一覧をトリガーするテキスト入力ボックスです。</span><span class="sxs-lookup"><span data-stu-id="e2092-133">An auto-suggest box is a text entry box that triggers a list of basic search suggestions.</span></span> <span data-ttu-id="e2092-134">候補となる用語は、一般的な検索用語とユーザーが入力した履歴の組み合わせから取得できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-134">Suggested terms can draw from a combination of popular search terms and historical user-entered terms.</span></span>

<span data-ttu-id="e2092-135">また、検索ボックスを実装する場合も、AutoSuggestBox コントロールを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2092-135">You should also use an AutoSuggestBox control to implement a search box.</span></span>

<span data-ttu-id="e2092-136">**RichEditBox** を使用して、テキスト ファイルを表示および編集します。</span><span class="sxs-lookup"><span data-stu-id="e2092-136">Use a **RichEditBox** to display and edit text files.</span></span> <span data-ttu-id="e2092-137">その他の標準的なテキスト入力ボックスを使用するように、RichEditBox を使用してアプリにユーザー入力を行わないでください。</span><span class="sxs-lookup"><span data-stu-id="e2092-137">You don't use a RichEditBox to get user input into your app the way you use other standard text input boxes.</span></span> <span data-ttu-id="e2092-138">代わりに、アプリとは別のテキスト ファイルを操作するために使用します。</span><span class="sxs-lookup"><span data-stu-id="e2092-138">Rather, you use it to work with text files that are separate from your app.</span></span> <span data-ttu-id="e2092-139">通常、RichEditBox に入力されたテキストを .rtf ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="e2092-139">You typically save text entered into a RichEditBox to a .rtf file.</span></span>

**<span data-ttu-id="e2092-140">テキスト入力は最適な選択肢か</span><span class="sxs-lookup"><span data-stu-id="e2092-140">Is text input the best option?</span></span>**

<span data-ttu-id="e2092-141">アプリでユーザー入力を取得するには、さまざまな方法があります。</span><span class="sxs-lookup"><span data-stu-id="e2092-141">There are many ways you can get user input in your app.</span></span> <span data-ttu-id="e2092-142">標準テキスト ボックスのいずれかまたは別のコントロールのどちらがユーザー入力を取得するのに最適であるかを決定する際には、次の点を考慮します。</span><span class="sxs-lookup"><span data-stu-id="e2092-142">These questions will help answer whether one of the standard text input boxes or another control is the best fit for getting user input.</span></span>

-   **<span data-ttu-id="e2092-143">有効なすべての値を効率的に列挙することが現実的か。</span><span class="sxs-lookup"><span data-stu-id="e2092-143">Is it practical to efficiently enumerate all valid values?</span></span>** <span data-ttu-id="e2092-144">そうである場合は、いずれかの選択コントロールを使うことを検討します。考えられる選択コントロールは、[チェック ボックス](checkbox.md)、[ドロップダウン リスト](lists.md)、リスト ボックス、[ラジオ ボタン](radio-button.md)、[スライダー](slider.md)、[トグル スイッチ](toggles.md)、[日付の選択コントロール](date-and-time.md)、または時刻の選択コントロールです。</span><span class="sxs-lookup"><span data-stu-id="e2092-144">If so, consider using one of the selection controls, such as a [check box](checkbox.md), [drop-down list](lists.md), list box, [radio button](radio-button.md), [slider](slider.md), [toggle switch](toggles.md), [date picker](date-and-time.md), or time picker.</span></span>
-   **<span data-ttu-id="e2092-145">有効な値は比較的少数か。</span><span class="sxs-lookup"><span data-stu-id="e2092-145">Is there a fairly small set of valid values?</span></span>** <span data-ttu-id="e2092-146">少数の場合は、[ドロップダウン リスト](lists.md)またはリスト ボックス (値の文字数が多い場合) をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2092-146">If so, consider a [drop-down list](lists.md) or a list box, especially if the values are more than a few characters long.</span></span>
-   **<span data-ttu-id="e2092-147">有効なデータに、何も制約がないか。</span><span class="sxs-lookup"><span data-stu-id="e2092-147">Is the valid data completely unconstrained?</span></span> <span data-ttu-id="e2092-148">または、形式の制約 (長さや文字の種類による制約) だけがあるか。</span><span class="sxs-lookup"><span data-stu-id="e2092-148">Or is the valid data only constrained by format (constrained length or character types)?</span></span>** <span data-ttu-id="e2092-149">これに該当する場合は、テキスト入力コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-149">If so, use a text input control.</span></span> <span data-ttu-id="e2092-150">入力できる文字数を制限したり、アプリ コードで形式を検証したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="e2092-150">You can limit the number of characters that can be entered, and you can validate the format in your app code.</span></span>
-   **<span data-ttu-id="e2092-151">値は専用のコモン コントロールがあるデータ型か。</span><span class="sxs-lookup"><span data-stu-id="e2092-151">Does the value represent a data type that has a specialized common control?</span></span>** <span data-ttu-id="e2092-152">そうである場合は、テキスト入力コントロールではなく、適切なコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-152">If so, use the appropriate control instead of a text input control.</span></span> <span data-ttu-id="e2092-153">たとえば、データ入力を受け付けるには、テキスト入力コントロールの代わりに [DatePicker](https://msdn.microsoft.com/library/windows/apps/br211681) を使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-153">For example, use a [DatePicker](https://msdn.microsoft.com/library/windows/apps/br211681) instead of a text input control to accept a date entry.</span></span>
-   <span data-ttu-id="e2092-154">数値データのみに制限されている場合:</span><span class="sxs-lookup"><span data-stu-id="e2092-154">If the data is strictly numeric:</span></span>
    -   **<span data-ttu-id="e2092-155">入力される値は、近似値や同じページの別の数量に対する相対値か。</span><span class="sxs-lookup"><span data-stu-id="e2092-155">Is the value being entered approximate and/or relative to another quantity on the same page?</span></span>** <span data-ttu-id="e2092-156">そうである場合は、[スライダー](slider.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-156">If so, use a [slider](slider.md).</span></span>
    -   **<span data-ttu-id="e2092-157">設定の変更による影響をすぐに確認できることがユーザーにとって便利か。</span><span class="sxs-lookup"><span data-stu-id="e2092-157">Would the user benefit from instant feedback on the effect of setting changes?</span></span>** <span data-ttu-id="e2092-158">そうである場合は、 [スライダー](slider.md)を使い、必要であれば付随するコントロールも使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-158">If so, use a [slider](slider.md), possibly with an accompanying control.</span></span>
    -   **<span data-ttu-id="e2092-159">入力した結果の確認後 (たとえば、音量や明るさを設定した後など)、入力された値を調整する可能性が高いか。</span><span class="sxs-lookup"><span data-stu-id="e2092-159">Is the value entered likely to be adjusted after the result is observed, such as with volume or screen brightness?</span></span>** <span data-ttu-id="e2092-160">そうである場合は、[スライダー](slider.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-160">If so, use a [slider](slider.md).</span></span>

## <a name="examples"></a><span data-ttu-id="e2092-161">例</span><span class="sxs-lookup"><span data-stu-id="e2092-161">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="e2092-162">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="e2092-162">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="e2092-163"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/category/Text">アプリを開き、テキスト コントロールの動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="e2092-163">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/category/Text">open the app and see the text controls in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="e2092-164">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="e2092-164">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="e2092-165">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="e2092-165">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="e2092-166">テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="e2092-166">Text box</span></span>

![テキスト ボックス](images/text-box.png)

<span data-ttu-id="e2092-168">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="e2092-168">Auto suggest box</span></span>

![展開された自動提案コントロールの例](images/controls_autosuggest_expanded01.png)

<span data-ttu-id="e2092-170">パスワード ボックス</span><span class="sxs-lookup"><span data-stu-id="e2092-170">Password box</span></span>

![テキスト入力中でフォーカス状態のパスワード ボックス](images/passwordbox-focus-typing.png)

## <a name="create-a-text-control"></a><span data-ttu-id="e2092-172">テキスト コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="e2092-172">Create a text control</span></span>

<span data-ttu-id="e2092-173">各テキスト コントロールの詳細と例については、次の記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e2092-173">See these articles for info and examples specific to each text control.</span></span>

-   [<span data-ttu-id="e2092-174">AutoSuggestBox</span><span class="sxs-lookup"><span data-stu-id="e2092-174">AutoSuggestBox</span></span>](auto-suggest-box.md)
-   [<span data-ttu-id="e2092-175">PasswordBox</span><span class="sxs-lookup"><span data-stu-id="e2092-175">PasswordBox</span></span>](password-box.md)
-   [<span data-ttu-id="e2092-176">RichEditBox</span><span class="sxs-lookup"><span data-stu-id="e2092-176">RichEditBox</span></span>](rich-edit-box.md)
-   [<span data-ttu-id="e2092-177">RichTextBlock</span><span class="sxs-lookup"><span data-stu-id="e2092-177">RichTextBlock</span></span>](rich-text-block.md)
-   [<span data-ttu-id="e2092-178">TextBlock</span><span class="sxs-lookup"><span data-stu-id="e2092-178">TextBlock</span></span>](text-block.md)
-   [<span data-ttu-id="e2092-179">TextBox</span><span class="sxs-lookup"><span data-stu-id="e2092-179">TextBox</span></span>](text-box.md)

## <a name="font-and-style-guidelines"></a><span data-ttu-id="e2092-180">フォントとスタイルのガイドライン</span><span class="sxs-lookup"><span data-stu-id="e2092-180">Font and style guidelines</span></span>
<span data-ttu-id="e2092-181">フォントのガイドラインについては、次の記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e2092-181">See these articles for font guidelines:</span></span>

- [<span data-ttu-id="e2092-182">文字体裁のガイドライン</span><span class="sxs-lookup"><span data-stu-id="e2092-182">Typography guidelines</span></span>](../style/typography.md)
- [<span data-ttu-id="e2092-183">Segoe MDL2 アイコンの一覧とガイドライン</span><span class="sxs-lookup"><span data-stu-id="e2092-183">Segoe MDL2 icon list and guidelines</span></span>](../style/segoe-ui-symbol-font.md)

## <a name="pen-input"></a><span data-ttu-id="e2092-184">ペン入力</span><span class="sxs-lookup"><span data-stu-id="e2092-184">Pen input</span></span>

<span data-ttu-id="e2092-185">**適用対象:** TextBox、RichEditBox、AutoSuggestBox</span><span class="sxs-lookup"><span data-stu-id="e2092-185">**Applies to:** TextBox, RichEditBox, AutoSuggestBox</span></span>

<span data-ttu-id="e2092-186">Windows 10 バージョン 1803 以降では、XAML テキスト入力ボックスは、[Windows Ink](../input/pen-and-stylus-interactions.md) を使用したペン入力の埋め込みをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e2092-186">Starting with Windows 10, version 1803, XAML text input boxes feature embedded support for pen input using [Windows Ink](../input/pen-and-stylus-interactions.md).</span></span> <span data-ttu-id="e2092-187">ユーザーが Windows ペンを使用してテキスト入力ボックスでタップすると、テキスト ボックスは変換され、ユーザーは別の入力パネルを開かなくても、ペンを使用して直接書き込むことができます。</span><span class="sxs-lookup"><span data-stu-id="e2092-187">When a user taps into a text input box using a Windows pen, the text box transforms to let the user write directly into it with a pen, rather than opening a separate input panel.</span></span>

![ペンでタップするとテキスト ボックスが展開する](images/pen-input-expand.gif)

<span data-ttu-id="e2092-189">詳しくは、[テキスト入力では、手書きのビュー](text-handwriting-view.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e2092-189">For more info, see [Text input with the handwriting view](text-handwriting-view.md).</span></span>

## <a name="choose-the-right-keyboard-for-your-text-control"></a><span data-ttu-id="e2092-190">テキスト コントロールに適切なキーボードの選択</span><span class="sxs-lookup"><span data-stu-id="e2092-190">Choose the right keyboard for your text control</span></span>

<span data-ttu-id="e2092-191">**適用対象:** TextBox、PasswordBox、RichEditBox</span><span class="sxs-lookup"><span data-stu-id="e2092-191">**Applies to:** TextBox, PasswordBox RichEditBox</span></span>

<span data-ttu-id="e2092-192">ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力スコープを設定できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-192">To help users to enter data using the touch keyboard, or Soft Input Panel (SIP), you can set the input scope of the text control to match the kind of data the user is expected to enter.</span></span>

><span data-ttu-id="e2092-193">ヒント この情報は、SIP にのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="e2092-193">Tip This info applies only to the SIP.</span></span> <span data-ttu-id="e2092-194">ハードウェア キーボードにも、Windows の簡単操作オプションで使用できるスクリーン キーボードにも適用されません。</span><span class="sxs-lookup"><span data-stu-id="e2092-194">It does not apply to hardware keyboards or the On-Screen Keyboard available in the Windows Ease of Access options.</span></span>

<span data-ttu-id="e2092-195">タッチ キーボードは、アプリがタッチ スクリーン付きのデバイスで実行されているときにテキスト入力に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e2092-195">The touch keyboard can be used for text entry when your app runs on a device with a touch screen.</span></span> <span data-ttu-id="e2092-196">タッチ キーボードは、TextBox または RichEditBox などの編集可能な入力フィールドをユーザーがタップしたときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="e2092-196">The touch keyboard is invoked when the user taps on an editable input field, such as a TextBox or RichEditBox.</span></span> <span data-ttu-id="e2092-197">ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの入力スコープを設定することで、ユーザーがより速く簡単にアプリにデータを入力できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e2092-197">You can make it much faster and easier for users to enter data in your app by setting the input scope of the text control to match the kind of data you expect the user to enter.</span></span> <span data-ttu-id="e2092-198">入力値の種類は、システムに対してコントロールが予期しているテキスト入力の種類のヒントとなるため、システムはその入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-198">The input scope provides a hint to the system about the type of text input expected by the control so the system can provide a specialized touch keyboard layout for the input type.</span></span>

<span data-ttu-id="e2092-199">たとえば、テキスト ボックスが 4 桁の PIN の入力専用の場合は、[InputScope](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.inputscope.aspx) プロパティを **Number** に設定します。</span><span class="sxs-lookup"><span data-stu-id="e2092-199">For example, if a text box is used only to enter a 4-digit PIN, set the [InputScope](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.inputscope.aspx) property to **Number**.</span></span> <span data-ttu-id="e2092-200">これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-200">This tells the system to show the number keypad layout, which makes it easier for the user to enter the PIN.</span></span>

><span data-ttu-id="e2092-201">重要</span><span class="sxs-lookup"><span data-stu-id="e2092-201">Important</span></span>  
><span data-ttu-id="e2092-202">入力スコープの設定によって、入力の検証が実行されるわけではありません。また、ユーザーが、ハードウェア キーボードやその他の入力デバイスから入力できなくなることもありません。</span><span class="sxs-lookup"><span data-stu-id="e2092-202">The input scope does not cause any input validation to be performed, and does not prevent the user from providing any input through a hardware keyboard or other input device.</span></span> <span data-ttu-id="e2092-203">必要に応じて、コードで入力を検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2092-203">You are still responsible for validating the input in your code as needed.</span></span>

<span data-ttu-id="e2092-204">詳しくは、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2092-204">For more info, see [Use input scope to change the touch keyboard](https://msdn.microsoft.com/library/windows/apps/mt280229).</span></span>

## <a name="color-fonts"></a><span data-ttu-id="e2092-205">カラー フォント</span><span class="sxs-lookup"><span data-stu-id="e2092-205">Color fonts</span></span>

<span data-ttu-id="e2092-206">**適用対象:** TextBlock、RichTextBlock、TextBox、RichEditBox</span><span class="sxs-lookup"><span data-stu-id="e2092-206">**Applies to:** TextBlock, RichTextBlock, TextBox, RichEditBox</span></span>

<span data-ttu-id="e2092-207">Windows には、フォントに各グリフの複数の色付きレイヤーを含めるための機能があります。</span><span class="sxs-lookup"><span data-stu-id="e2092-207">Windows has the ability for fonts to include multiple colored layers for each glyph.</span></span> <span data-ttu-id="e2092-208">たとえば、Segoe UI Emoji フォントは、顔文字とその他の絵文字のカラー バージョンを定義します。</span><span class="sxs-lookup"><span data-stu-id="e2092-208">For example, the Segoe UI Emoji font defines color versions of the Emoticon and other Emoji characters.</span></span>

<span data-ttu-id="e2092-209">標準テキスト コントロールとリッチ テキスト コントロールは、カラー フォントの表示をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e2092-209">The standard and rich text controls support display color fonts.</span></span> <span data-ttu-id="e2092-210">既定では、**IsColorFontEnabled** プロパティは **true** であり、これらの追加のレイヤーを使用するフォントはカラーでレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="e2092-210">By default, the **IsColorFontEnabled** property is **true** and fonts with these additional layers are rendered in color.</span></span> <span data-ttu-id="e2092-211">システムに既定のカラー フォントは Segoe UI Emoji フォントで、コントロールはこのフォントにフォールバックしてグリフをカラーで表示します。</span><span class="sxs-lookup"><span data-stu-id="e2092-211">The default color font on the system is Segoe UI Emoji and the controls will fall back to this font to display the glyphs in color.</span></span>

```xaml
<TextBlock FontSize="30">Hello ☺⛄☂♨⛅</TextBlock>
```

<span data-ttu-id="e2092-212">レンダリングされたテキストは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e2092-212">The rendered text looks like this:</span></span>

![カラー フォントを使用したテキスト ブロック](images/text-block-color-fonts.png)

<span data-ttu-id="e2092-214">詳しくは、[IsColorFontEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.iscolorfontenabled.aspx) プロパティに関するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2092-214">For more info, see the [IsColorFontEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.iscolorfontenabled.aspx) property.</span></span>

## <a name="guidelines-for-line-and-paragraph-separators"></a><span data-ttu-id="e2092-215">行と段落の区切り記号のガイドライン</span><span class="sxs-lookup"><span data-stu-id="e2092-215">Guidelines for line and paragraph separators</span></span>

<span data-ttu-id="e2092-216">**適用対象:** TextBlock、RichTextBlock、複数行 TextBox、RichEditBox</span><span class="sxs-lookup"><span data-stu-id="e2092-216">**Applies to:** TextBlock, RichTextBlock, multi-line TextBox, RichEditBox</span></span>

<span data-ttu-id="e2092-217">行の区切り文字 (0x2028) と段落の区切り文字 (0x2029) を使用すると、プレーンテキストを分割できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-217">Use the line separator character (0x2028) and the paragraph separator character (0x2029) to divide plain text.</span></span> <span data-ttu-id="e2092-218">各行区切り文字の後に新しい行が開始されます。</span><span class="sxs-lookup"><span data-stu-id="e2092-218">A new line is begun after each line separator.</span></span> <span data-ttu-id="e2092-219">各段落区切り文字の後に新しい段落が開始されます。</span><span class="sxs-lookup"><span data-stu-id="e2092-219">A new paragraph is begun after each paragraph separator.</span></span>

<span data-ttu-id="e2092-220">ファイルの最初の行や段落をこれらの文字で始める必要はなく、最後の行や段落をこれらの文字で終わる必要はありません。これらの文字を使用した場合、その位置に空の行または段落があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="e2092-220">It isn't necessary to start the first line or paragraph in a file with these characters or to end the last line or paragraph with them; doing so indicates that there is an empty line or paragraph in that location.</span></span>

<span data-ttu-id="e2092-221">アプリでは、行の区切り記号を使って無条件の行の終わりを示すことができます。</span><span class="sxs-lookup"><span data-stu-id="e2092-221">Your app can use the line separator to indicate an unconditional end of line.</span></span> <span data-ttu-id="e2092-222">ただし、行の区切り記号は、独立した復帰文字や改行文字またはこれらの文字の組み合わせに対応していません。</span><span class="sxs-lookup"><span data-stu-id="e2092-222">However, line separators do not correspond to the separate carriage return and linefeed characters, or to a combination of these characters.</span></span> <span data-ttu-id="e2092-223">行の区切り記号は、復帰文字や改行文字とは別に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2092-223">Line separators must be processed separately from carriage return and linefeed characters.</span></span>

<span data-ttu-id="e2092-224">アプリでは、テキストの段落の間の段落の区切り記号を挿入できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-224">Your app can insert a paragraph separator between paragraphs of text.</span></span> <span data-ttu-id="e2092-225">この区切り記号を使用すると、さまざまなオペレーティング システムで異なる行の幅で書式設定できるプレーンテキスト ファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="e2092-225">Use of this separator allows creation of plain text files that can be formatted with different line widths on different operating systems.</span></span> <span data-ttu-id="e2092-226">ターゲット システムでは、行の区切り記号を無視し、段落の区切り記号でのみ段落を分割することができます。</span><span class="sxs-lookup"><span data-stu-id="e2092-226">The target system can ignore any line separators and break paragraphs only at the paragraph separators.</span></span>

## <a name="guidelines-for-spell-checking"></a><span data-ttu-id="e2092-227">スペル チェックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="e2092-227">Guidelines for spell checking</span></span>

<span data-ttu-id="e2092-228">**適用対象:** TextBox、RichEditBox</span><span class="sxs-lookup"><span data-stu-id="e2092-228">**Applies to:** TextBox, RichEditBox</span></span>

<span data-ttu-id="e2092-229">テキストの入力と編集を行っているときに、スペル チェックは単語を赤い波線で強調表示してユーザーに単語のスペルの間違いを知らせ、それを修正する方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="e2092-229">During text entry and editing, spell checking informs the user that a word is misspelled by highlighting it with a red squiggle and provides a way for the user to correct the misspelling.</span></span>

<span data-ttu-id="e2092-230">組み込みスペル チェックの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e2092-230">Here's an example of the built-in spell checker:</span></span>

![組み込みスペル チェック](images/spellchecking.png)

<span data-ttu-id="e2092-232">テキスト入力コントロールでのスペル チェックは、次の 2 つの目的で使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-232">Use spell checking with text input controls for these two purposes:</span></span>

-   **<span data-ttu-id="e2092-233">スペル ミスを自動修正する</span><span class="sxs-lookup"><span data-stu-id="e2092-233">To auto-correct misspellings</span></span>**

    <span data-ttu-id="e2092-234">スペル チェック エンジンは、単語にスペルの間違いがあり、修正が確実であれば自動的に修正します。</span><span class="sxs-lookup"><span data-stu-id="e2092-234">The spell checking engine automatically corrects misspelled words when it's confident about the correction.</span></span> <span data-ttu-id="e2092-235">たとえば、エンジンは自動的に "teh" を "the" に変更します。</span><span class="sxs-lookup"><span data-stu-id="e2092-235">For example, the engine automatically changes "teh" to "the."</span></span>

-   **<span data-ttu-id="e2092-236">代わりのスペルを示す</span><span class="sxs-lookup"><span data-stu-id="e2092-236">To show alternate spellings</span></span>**

    <span data-ttu-id="e2092-237">修正が確実でないとスペル チェック エンジンが判断した場合、スペル ミスのある単語には赤い下線が引かれ、ユーザーがその単語をタップするか右クリックすると、ショートカット メニューに修正候補が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e2092-237">When the spell checking engine is not confident about the corrections, it adds a red line under the misspelled word and displays the alternates in a context menu when you tap or right-click the word.</span></span>

-   <span data-ttu-id="e2092-238">スペル チェックは、テキスト入力コントロールに単語や文を入力するときにユーザーを補助するために使います。</span><span class="sxs-lookup"><span data-stu-id="e2092-238">Use spell checking to help users as they enter words or sentences into text input controls.</span></span> <span data-ttu-id="e2092-239">スペル チェックは、タッチ、マウス、キーボード入力で機能します。</span><span class="sxs-lookup"><span data-stu-id="e2092-239">Spell checking works with touch, mouse, and keyboard inputs.</span></span>
-   <span data-ttu-id="e2092-240">単語が辞書になさそうな場合や、ユーザーがスペル チェックを重視しない場合は、スペル チェックを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="e2092-240">Don't use spell checking when a word is not likely to be in the dictionary or if users wouldn't value spell checking.</span></span> <span data-ttu-id="e2092-241">たとえば、電話番号または名前をキャプチャするためのテキスト ボックスでは、スペル チェックを有効にしません。</span><span class="sxs-lookup"><span data-stu-id="e2092-241">For example, don't turn it on if the text box is intended to capture a telephone number or name.</span></span>
-   <span data-ttu-id="e2092-242">現在のスペル チェック エンジンがアプリの言語をサポートしていないという理由だけで、スペル チェックを無効にしないでください。</span><span class="sxs-lookup"><span data-stu-id="e2092-242">Don't disable spell checking just because the current spell checking engine doesn't support your app language.</span></span> <span data-ttu-id="e2092-243">スペル チェックでその言語がサポートされていない場合は、何も行われないので、有効にしたままで何も問題がありません。</span><span class="sxs-lookup"><span data-stu-id="e2092-243">When the spell checker doesn't support a language, it doesn't do anything, so there's no harm in leaving the option on.</span></span> <span data-ttu-id="e2092-244">また、一部のユーザーは Input Method Editor (IME) を使ってアプリに他の言語を入力する場合があり、その言語がサポートされている可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="e2092-244">Also, some users might use an Input Method Editor (IME) to enter another language into your app, and that language might be supported.</span></span> <span data-ttu-id="e2092-245">たとえば、日本語のアプリを構築している場合には、現在はスペル チェック エンジンが日本語を認識していなくても、スペル チェックを無効にしないでください。</span><span class="sxs-lookup"><span data-stu-id="e2092-245">For example, when building a Japanese language app, even though the spell checking engine might not currently recognize that language, don't turn spell checking off.</span></span> <span data-ttu-id="e2092-246">ユーザーが英語 IME に切り替え、アプリに英語を入力する場合があります。スペル チェックが有効になっていれば、英語のスペル チェックが行われます。</span><span class="sxs-lookup"><span data-stu-id="e2092-246">The user may switch to an English IME and type English into the app; if spell checking is enabled, the English will get spell checked.</span></span>

<span data-ttu-id="e2092-247">TextBox コントロールおよび RichEditBox コントロールでは、スペル チェックが既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="e2092-247">For TextBox and RichEditBox controls, spell checking is turned on by default.</span></span> <span data-ttu-id="e2092-248">**IsSpellCheckEnabled** プロパティを **false** に設定することによって無効にできます。</span><span class="sxs-lookup"><span data-stu-id="e2092-248">You can turn it off by setting the **IsSpellCheckEnabled** property to **false**.</span></span>

## <a name="related-articles"></a><span data-ttu-id="e2092-249">関連記事</span><span class="sxs-lookup"><span data-stu-id="e2092-249">Related articles</span></span>

**<span data-ttu-id="e2092-250">設計者向け</span><span class="sxs-lookup"><span data-stu-id="e2092-250">For designers</span></span>**
- [<span data-ttu-id="e2092-251">文字体裁のガイドライン</span><span class="sxs-lookup"><span data-stu-id="e2092-251">Typography guidelines</span></span>](../style/typography.md)
- [<span data-ttu-id="e2092-252">Segoe MDL2 アイコンの一覧とガイドライン</span><span class="sxs-lookup"><span data-stu-id="e2092-252">Segoe MDL2 icon list and guidelines</span></span>](../style/segoe-ui-symbol-font.md)
- [<span data-ttu-id="e2092-253">検索の追加</span><span class="sxs-lookup"><span data-stu-id="e2092-253">Adding search</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465231)

**<span data-ttu-id="e2092-254">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="e2092-254">For developers (XAML)</span></span>**
- [<span data-ttu-id="e2092-255">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="e2092-255">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="e2092-256">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="e2092-256">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="e2092-257">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="e2092-257">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length.aspx)
