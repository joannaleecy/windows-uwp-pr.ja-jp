---
author: Jwmsft
Description: "ハイパーリンクはユーザーを、アプリの別の部分、別のアプリ、または別のブラウザー アプリを使って呼び出した URI (Uniform Resource Identifier) に誘導します。"
title: "ハイパーリンク"
ms.assetid: 74302FF0-65FC-4820-B59A-718A765EF7F0
label: Hyperlinks
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: stpete
doc-status: Published
ms.openlocfilehash: 5079d1782188b6d2e49fc14741a23a5651995c67
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="hyperlinks"></a><span data-ttu-id="787fd-104">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="787fd-104">Hyperlinks</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="787fd-105">ハイパーリンクはユーザーを、アプリの別の部分、別のアプリ、または別のブラウザー アプリを使って呼び出した URI (Uniform Resource Identifier) に誘導します。</span><span class="sxs-lookup"><span data-stu-id="787fd-105">Hyperlinks navigate the user to another part of the app, to another app, or launch a specific uniform resource identifier (URI) using a separate browser app.</span></span> <span data-ttu-id="787fd-106">XAML アプリにハイパーリンクを追加するには 2 つの方法、**ハイパーリンク** テキスト要素と **HyperlinkButton** コントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="787fd-106">There are two ways that you can add a hyperlink to a XAML app: the **Hyperlink** text element and **HyperlinkButton** control.</span></span>

> <span data-ttu-id="787fd-107">**重要な API**: [ハイパーリンク テキスト要素](https://msdn.microsoft.com/library/windows/apps/dn279356)、[HyperlinkButton コントロール](https://msdn.microsoft.com/library/windows/apps/br242739)</span><span class="sxs-lookup"><span data-stu-id="787fd-107">**Important APIs**: [Hyperlink text element](https://msdn.microsoft.com/library/windows/apps/dn279356), [HyperlinkButton control](https://msdn.microsoft.com/library/windows/apps/br242739)</span></span>

![ハイパーリンク ボタン](images/controls/hyperlink-button.png)


## <a name="is-this-the-right-control"></a><span data-ttu-id="787fd-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="787fd-109">Is this the right control?</span></span>

<span data-ttu-id="787fd-110">ユーザーがテキストを選び、そのテキストに関する詳しい情報が表示される場所に移動するとき、この操作に応答するテキストが必要となる場合に、ハイパーリンクを使います。</span><span class="sxs-lookup"><span data-stu-id="787fd-110">Use a hyperlink when you need text that responds when selected and navigates the user to more information about the text that was selected.</span></span>

<span data-ttu-id="787fd-111">必要に応じて適切な種類のハイパーリンクを選んでください。</span><span class="sxs-lookup"><span data-stu-id="787fd-111">Choose the right type of hyperlink based on your needs:</span></span>

-   <span data-ttu-id="787fd-112">テキスト コントロール内でインライン **ハイパーリンク** テキスト要素を使用します。</span><span class="sxs-lookup"><span data-stu-id="787fd-112">Use an inline **Hyperlink** text element inside of a text control.</span></span> <span data-ttu-id="787fd-113">ハイパーリンク要素は他のテキスト要素とともに表示され、すべて InlineCollection で使うことができます。</span><span class="sxs-lookup"><span data-stu-id="787fd-113">A Hyperlink element flows with other text elements and you can use it in any InlineCollection.</span></span> <span data-ttu-id="787fd-114">自動テキスト折り返しを必要とするが、大きいサイズのヒット ターゲットを必要としない場合は、テキスト ハイパーリンクを使います。</span><span class="sxs-lookup"><span data-stu-id="787fd-114">Use a text hyperlink if you want automatic text wrapping and don't necessarily need a large hit target.</span></span> <span data-ttu-id="787fd-115">ハイパーリンク テキストのサイズは小さく、ターゲットとして使うのが難しくなることがあります (特にタッチ操作の場合)。</span><span class="sxs-lookup"><span data-stu-id="787fd-115">Hyperlink text can be small and difficult to target, especially for touch.</span></span>
-   <span data-ttu-id="787fd-116">スタンドアロンのハイパーリンクには **HyperlinkButton** を使用します。</span><span class="sxs-lookup"><span data-stu-id="787fd-116">Use a **HyperlinkButton** for stand-alone hyperlinks.</span></span> <span data-ttu-id="787fd-117">HyperlinkButton は、ボタンを使用する任意の場所で使用できる特殊なボタン コントロールです。</span><span class="sxs-lookup"><span data-stu-id="787fd-117">A HyperlinkButton is a specialized Button control that you can use anywhere that you would use a Button.</span></span>
-   <span data-ttu-id="787fd-118">クリック可能なイメージを作成するには[イメージ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.image.aspx) と一緒にそのコンテンツとして **HyperlinkButton** を使用します。</span><span class="sxs-lookup"><span data-stu-id="787fd-118">Use a **HyperlinkButton** with an [Image](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.image.aspx) as its content to make a clickable image.</span></span>

## <a name="create-a-hyperlink-text-element"></a><span data-ttu-id="787fd-119">ハイパーリンク テキスト要素を作成する</span><span class="sxs-lookup"><span data-stu-id="787fd-119">Create a Hyperlink text element</span></span>

<span data-ttu-id="787fd-120">この例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) 内のハイパーリンク テキスト要素の使用方法を示します。</span><span class="sxs-lookup"><span data-stu-id="787fd-120">This example shows how to use a Hyperlink text element inside of a [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx).</span></span>

```xml
<StackPanel Width="200">
    <TextBlock Text="Privacy" Style="{StaticResource SubheaderTextBlockStyle}"/>
    <TextBlock TextWrapping="WrapWholeWords">
        <Span xml:space="preserve"><Run>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Read the </Run><Hyperlink NavigateUri="http://www.contoso.com">Contoso Privacy Statement</Hyperlink><Run> in your browser.</Run> Donec pharetra, enim sit amet mattis tincidunt, felis nisi semper lectus, vel porta diam nisi in augue.</Span>
    </TextBlock>
</StackPanel>

```
<span data-ttu-id="787fd-121">ハイパーリンクは、インラインで周囲のテキストと表示されます。</span><span class="sxs-lookup"><span data-stu-id="787fd-121">The hyperlink appears inline and flows with the surrounding text:</span></span>

![テキスト要素としてのハイパーリンクの例](images/controls_hyperlink-element.png) 

> <span data-ttu-id="787fd-123">**ヒント**&nbsp;&nbsp;テキスト コントロールでハイパーリンクを XAML のその他のテキスト要素と一緒に使用する場合、[スパン](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.aspx) コンテナーにコンテンツを配置してスパンに `xml:space="preserve"` 属性を適用すると、ハイパーリンクとその他の要素間に空白を保持します。</span><span class="sxs-lookup"><span data-stu-id="787fd-123">**Tip**&nbsp;&nbsp;When you use a Hyperlink in a text control with other text elements in XAML, place the content in a [Span](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.aspx) container and apply the `xml:space="preserve"` attribute to the Span to keep the white space between the Hyperlink and other elements.</span></span>

## <a name="create-a-hyperlinkbutton"></a><span data-ttu-id="787fd-124">HyperlinkButton を作成する</span><span class="sxs-lookup"><span data-stu-id="787fd-124">Create a HyperlinkButton</span></span>

<span data-ttu-id="787fd-125">テキストおよび画像の両方で HyperlinkButton を使用する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="787fd-125">Here's how to use a HyperlinkButton, both with text and with an image.</span></span>

```xml
<StackPanel>
    <TextBlock Text="About" Style="{StaticResource TitleTextBlockStyle}"/>
    <HyperlinkButton NavigateUri="http://www.contoso.com">
        <Image Source="Assets/ContosoLogo.png"/>
    </HyperlinkButton>
    <TextBlock Text="Version: 1.0.0001" Style="{StaticResource CaptionTextBlockStyle}"/>
    <HyperlinkButton Content="Contoso.com" NavigateUri="http://www.contoso.com"/>
    <HyperlinkButton Content="Acknowledgments" NavigateUri="http://www.contoso.com"/>
    <HyperlinkButton Content="Help" NavigateUri="http://www.contoso.com"/>
</StackPanel>

```
<span data-ttu-id="787fd-126">テキスト コンテンツの付いたハイパーリンク ボタンは、マークアップ テキストとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="787fd-126">The hyperlink buttons with text content appear as marked-up text.</span></span> <span data-ttu-id="787fd-127">Contoso ロゴ画像もクリック可能なハイパーリンクです。</span><span class="sxs-lookup"><span data-stu-id="787fd-127">The Contoso logo image is also a clickable hyperlink:</span></span>

![ボタン コントロールとしてのハイパーリンクの例](images/controls_hyperlink-button-image.png)

## <a name="handle-navigation"></a><span data-ttu-id="787fd-129">ナビゲーションの処理</span><span class="sxs-lookup"><span data-stu-id="787fd-129">Handle navigation</span></span>

<span data-ttu-id="787fd-130">どちらの種類のハイパーリンクでも同様にナビゲーションを処理します。**NavigateUri** プロパティを設定するか、または**クリック** イベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="787fd-130">For both kinds of hyperlinks, you handle navigation the same way; you can set the **NavigateUri** property, or handle the **Click** event.</span></span>

**<span data-ttu-id="787fd-131">URI に移動</span><span class="sxs-lookup"><span data-stu-id="787fd-131">Navigate to a URI</span></span>**

<span data-ttu-id="787fd-132">ハイパーリンクを使用して URI に移動するには、NavigateUri プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="787fd-132">To use the hyperlink to navigate to a URI, set the NavigateUri property.</span></span> <span data-ttu-id="787fd-133">ユーザーがハイパーリンクをクリックしてまたはタップすると、指定された URI が既定のブラウザーで開きます。</span><span class="sxs-lookup"><span data-stu-id="787fd-133">When a user clicks or taps the hyperlink, the specified URI opens in the default browser.</span></span> <span data-ttu-id="787fd-134">既定のブラウザーは、アプリと別のプロセスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="787fd-134">The default browser runs in a separate process from your app.</span></span>

> [!NOTE]
> <span data-ttu-id="787fd-135">Http: または https: スキームを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="787fd-135">You don't have to use http: or https: schemes.</span></span> <span data-ttu-id="787fd-136">ブラウザーに読み込むのに適したリソース コンテンツがこれらの場所にある場合は、ms-appx:、ms-appdata: または ms リソース: などのスキームを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="787fd-136">You can use schemes such as ms-appx:, ms-appdata:, or ms-resources:, if there's resource content at these locations that's appropriate to load in a browser.</span></span> <span data-ttu-id="787fd-137">ただし、file: スキームは明確に禁止されます。</span><span class="sxs-lookup"><span data-stu-id="787fd-137">However, the file: scheme is specifically blocked.</span></span> <span data-ttu-id="787fd-138">詳しくは、「[URI スキーム](https://msdn.microsoft.com/library/windows/apps/jj655406.aspx)」 をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="787fd-138">For more info, see [URI schemes](https://msdn.microsoft.com/library/windows/apps/jj655406.aspx).</span></span>

> <span data-ttu-id="787fd-139">ユーザーがハイパーリンクをクリックすると、URI の種類とスキームのシステムのハンドラーに NavigateUri プロパティの値が渡されます。</span><span class="sxs-lookup"><span data-stu-id="787fd-139">When a user clicks the hyperlink, the value of the NavigateUri property is passed to a system handler for URI types and schemes.</span></span> <span data-ttu-id="787fd-140">システムは、NavigateUri の指定された URI のスキームに対して登録されているアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="787fd-140">The system then launches the app that is registered for the scheme of the URI provided for NavigateUri.</span></span>

<span data-ttu-id="787fd-141">ハイパーリンクで、コンテンツを既定の Web ブラウザーで読み込む必要がない場合 (ブラウザーを表示しない場合) は、NavigateUri の値を設定しないでください。</span><span class="sxs-lookup"><span data-stu-id="787fd-141">If you don't want the hyperlink to load content in a default Web browser (and don't want a browser to appear), then don't set a value for NavigateUri.</span></span> <span data-ttu-id="787fd-142">代わりに、Click イベントを処理し、目的に合ったコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="787fd-142">Instead, handle the Click event, and write code that does what you want.</span></span>


**<span data-ttu-id="787fd-143">Click イベントの処理</span><span class="sxs-lookup"><span data-stu-id="787fd-143">Handle the Click event</span></span>**

<span data-ttu-id="787fd-144">アプリ内のナビゲーションなど、ブラウザーの URI の起動以外の操作に Click イベントを使用します。</span><span class="sxs-lookup"><span data-stu-id="787fd-144">Use the Click event for actions other than launching a URI in a browser, such as navigation within the app.</span></span> <span data-ttu-id="787fd-145">たとえば、ブラウザーを開くのではなく、新しいアプリのページを読み込む場合は、クリック イベント ハンドラー内で [Frame.Navigate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.frame.navigate.aspx) メソッドを呼び出して新しいアプリのページに移動します。</span><span class="sxs-lookup"><span data-stu-id="787fd-145">For example, if you want to load a new app page rather than opening a browser, call a [Frame.Navigate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.frame.navigate.aspx) method within your Click event handler to navigate to the new app page.</span></span> <span data-ttu-id="787fd-146">同様にアプリ内にある [WebView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx) コントロール内で外部の絶対 URI を読み込む場合は、[WebView.Navigate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.navigate.aspx) を Click ハンドラーのロジックの一部として呼び出します。</span><span class="sxs-lookup"><span data-stu-id="787fd-146">If you want an external, absolute URI to load within a [WebView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx) control that also exists in your app, call [WebView.Navigate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.navigate.aspx) as part of your Click handler logic.</span></span>

<span data-ttu-id="787fd-147">通常は、これらはハイパーリンク要素を使用する別の 2 つの方法に相当するので、Click イベントの処理は行わず、NavigateUri 値も指定しません。</span><span class="sxs-lookup"><span data-stu-id="787fd-147">You don't typically handle the Click event as well as specifying a NavigateUri value, as these represent two different ways of using the hyperlink element.</span></span> <span data-ttu-id="787fd-148">既定のブラウザーで URI を開き、NavigateUri の値を指定した場合は、クリック イベントは処理しません。</span><span class="sxs-lookup"><span data-stu-id="787fd-148">If your intent is to open the URI in the default browser, and you have specified a value for NavigateUri, don't handle the Click event.</span></span> <span data-ttu-id="787fd-149">逆に、クリック イベントを処理する場合は、NavigateUri を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="787fd-149">Conversely, if you handle the Click event, don't specify a NavigateUri.</span></span>

<span data-ttu-id="787fd-150">既定のブラウザーが NavigateUri に指定されている任意の有効なターゲットを読み込むことを防ぐために Click イベント ハンドラー内でできることはありません。ハイパーリンクがアクティブ化されると操作は自動的に (非同期的に) 行われ、Click イベント ハンドラー内で取り消すことはできません。</span><span class="sxs-lookup"><span data-stu-id="787fd-150">There's nothing you can do within the Click event handler to prevent the default browser from loading any valid target specified for NavigateUri; that action takes place automatically (asynchronously) when the hyperlink is activated and can't be canceled from within the Click event handler.</span></span> 

## <a name="hyperlink-underlines"></a><span data-ttu-id="787fd-151">ハイパーリンクの下線</span><span class="sxs-lookup"><span data-stu-id="787fd-151">Hyperlink underlines</span></span>
<span data-ttu-id="787fd-152">既定では、ハイパーリンクに下線が引かれます。</span><span class="sxs-lookup"><span data-stu-id="787fd-152">By default, hyperlinks are underlined.</span></span> <span data-ttu-id="787fd-153">この下線は、アクセシビリティ要件を満たすために役立つので重要です。</span><span class="sxs-lookup"><span data-stu-id="787fd-153">This underline is important because it helps meet accessibility requirements.</span></span> <span data-ttu-id="787fd-154">色覚に障碍があるユーザーは、ハイパーリンクとその他のテキストを区別するために下線を使用します。</span><span class="sxs-lookup"><span data-stu-id="787fd-154">Color-blind users use the underline to distinguish between hyperlinks and other text.</span></span> <span data-ttu-id="787fd-155">下線を無効にした場合は、ハイパーリンクを他のテキストと区別するために、FontWeight または FontStyle など、他の書式設定の違いを追加することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="787fd-155">If you disable underlines, you should consider adding some other type of formatting difference to distinguish hyperlinks from other text, such as FontWeight or FontStyle.</span></span>

**<span data-ttu-id="787fd-156">ハイパーリンク テキスト要素</span><span class="sxs-lookup"><span data-stu-id="787fd-156">Hyperlink text elements</span></span>**

<span data-ttu-id="787fd-157">[UnderlineStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.hyperlink.underlinestyle.aspx) プロパティを設定すると下線の表示を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="787fd-157">You can set the [UnderlineStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.hyperlink.underlinestyle.aspx) property to disable the underline.</span></span> <span data-ttu-id="787fd-158">これを行う場合は、リンクを表すテキストを区別するために [FontWeight](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.fontweight.aspx) または [FontStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.fontstyle.aspx) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="787fd-158">If you do, consider using [FontWeight](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.fontweight.aspx) or [FontStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.fontstyle.aspx) to differentiate your link text.</span></span>

**<span data-ttu-id="787fd-159">HyperlinkButton</span><span class="sxs-lookup"><span data-stu-id="787fd-159">HyperlinkButton</span></span>** 

<span data-ttu-id="787fd-160">既定では、HyperlinkButton は、[Content](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content.aspx) プロパティの値として文字列を設定すると、下線付きテキストとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="787fd-160">By default, the HyperlinkButton appears as underlined text when you set a string as the value for the [Content](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content.aspx) property.</span></span>

<span data-ttu-id="787fd-161">次の場合、テキストは下線付きで表示されません。</span><span class="sxs-lookup"><span data-stu-id="787fd-161">The text does not appear underlined in the following cases:</span></span>
- <span data-ttu-id="787fd-162">コンテンツのプロパティの値として [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を設定し、TextBlock の [Text](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.text.aspx) プロパティを設定した場合。</span><span class="sxs-lookup"><span data-stu-id="787fd-162">You set a [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) as the value for the Content property, and set the [Text](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.text.aspx) property on the TextBlock.</span></span>
- <span data-ttu-id="787fd-163">HyperlinkButton を再テンプレートして [ContentPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentpresenter.aspx) テンプレート パーツの名前を変更した場合。</span><span class="sxs-lookup"><span data-stu-id="787fd-163">You re-template the HyperlinkButton and change the name of the [ContentPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentpresenter.aspx) template part.</span></span>

<span data-ttu-id="787fd-164">下線の無いテキストとして表示されるボタンが必要な場合は、標準のボタン コントロールを使い、そのスタイルのプロパティに組み込みの `TextBlockButtonStyle` システム リソースを適用することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="787fd-164">If you need a button that appears as non-underlined text, consider using a standard Button control and applying the built-in `TextBlockButtonStyle` system resource to its Style property.</span></span>

## <a name="notes-for-hyperlink-text-element"></a><span data-ttu-id="787fd-165">ハイパーリンク テキスト要素の注意点</span><span class="sxs-lookup"><span data-stu-id="787fd-165">Notes for Hyperlink text element</span></span>

<span data-ttu-id="787fd-166">このセクションは、ハイパーリンク テキスト要素にのみ該当します。HyperlinkButton コントロールには該当しません。</span><span class="sxs-lookup"><span data-stu-id="787fd-166">This section applies only to the Hyperlink text element, not to the HyperlinkButton control.</span></span>

**<span data-ttu-id="787fd-167">入力イベント</span><span class="sxs-lookup"><span data-stu-id="787fd-167">Input events</span></span>**

<span data-ttu-id="787fd-168">ハイパーリンクは [UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.aspx) ではないため、Tapped、PointerPressed などの UI 要素の入力イベントのセットはありません。</span><span class="sxs-lookup"><span data-stu-id="787fd-168">Because a Hyperlink is not a [UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.aspx), it does not have the set of UI element input events such as Tapped, PointerPressed, and so on.</span></span> <span data-ttu-id="787fd-169">代わりに、ハイパーリンクには、独自の Click イベントに加えて、NavigateUri として指定されている任意の URI を読み込むシステムの暗黙的な動作があります。</span><span class="sxs-lookup"><span data-stu-id="787fd-169">Instead, a Hyperlink has its own Click event, plus the implicit behavior of the system loading any URI specified as the NavigateUri.</span></span> <span data-ttu-id="787fd-170">システムは、ハイパーリンクのアクションを呼び出し、応答で Click イベントを発生させる必要があるすべての入力動作を処理します。</span><span class="sxs-lookup"><span data-stu-id="787fd-170">The system handles all input actions that should invoke the Hyperlink actions and raises the Click event in response.</span></span>

**<span data-ttu-id="787fd-171">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="787fd-171">Content</span></span>**

<span data-ttu-id="787fd-172">ハイパーリンクには、その [Inlines](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.inlines.aspx) コレクション内にあるコンテンツの制限があります。</span><span class="sxs-lookup"><span data-stu-id="787fd-172">Hyperlink has restrictions on the content that can exist in its [Inlines](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.inlines.aspx) collection.</span></span> <span data-ttu-id="787fd-173">具体的には、ハイパーリンクは、[実行](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.run.aspx)および別のハイパーリンクではないその他の[スパン]() タイプのみ許可します。</span><span class="sxs-lookup"><span data-stu-id="787fd-173">Specifically, a Hyperlink only permits [Run](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.run.aspx) and other [Span]() types that aren't another Hyperlink.</span></span> <span data-ttu-id="787fd-174">[InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.inlineuicontainer.aspx) は、ハイパーリンクの Inlines コレクション内にはありません。</span><span class="sxs-lookup"><span data-stu-id="787fd-174">[InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.inlineuicontainer.aspx) can't be in the Inlines collection of a Hyperlink.</span></span> <span data-ttu-id="787fd-175">制限されたコンテンツを追加しようとすると、無効な引数の例外、または XAML 解析例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="787fd-175">Attempting to add restricted content throws an invalid argument exception or XAML parse exception.</span></span>

**<span data-ttu-id="787fd-176">ハイパーリンクとテーマまたはスタイルの動作</span><span class="sxs-lookup"><span data-stu-id="787fd-176">Hyperlink and theme/style behavior</span></span>**

<span data-ttu-id="787fd-177">ハイパーリンクは [コントロール](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.aspx) から継承しないため、[Style](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.style.aspx) プロパティまたは [Template](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.template.aspx) がありません。</span><span class="sxs-lookup"><span data-stu-id="787fd-177">Hyperlink doesn't inherit from [Control](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.aspx), so it doesn't have a [Style](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.style.aspx) property or a [Template](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.template.aspx).</span></span> <span data-ttu-id="787fd-178">Foreground または FontFamily など、[TextElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.aspx) から継承されたプロパティを編集してハイパーリンクの外観を変更できますが、一般的なスタイルまたはテンプレートを使用して変更を適用することはできません。</span><span class="sxs-lookup"><span data-stu-id="787fd-178">You can edit the properties that are inherited from [TextElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.aspx), such as Foreground or FontFamily, to change the appearance of a Hyperlink, but you can't use a common style or template to apply changes.</span></span> <span data-ttu-id="787fd-179">テンプレートを使う代わりに、一貫性を保つためにハイパーリンクのプロパティの値の一般的なリソースの使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="787fd-179">Instead of using a template, consider using common resources for values of Hyperlink properties to provide consistency.</span></span> <span data-ttu-id="787fd-180">一部のプロパティのハイパーリンクは、システムによって提供される {themeresource} マークアップ拡張機能の値から既定の設定を使用します。</span><span class="sxs-lookup"><span data-stu-id="787fd-180">Some properties of Hyperlink use defaults from a {ThemeResource} markup extension value provided by the system.</span></span> <span data-ttu-id="787fd-181">これにより、ハイパーリンクの外観は、実行時にシステム テーマが変更されると、適切な方法で切り替わります。</span><span class="sxs-lookup"><span data-stu-id="787fd-181">This enables the Hyperlink appearance to switch in appropriate ways when the user changes the system theme at run-time.</span></span>

<span data-ttu-id="787fd-182">ハイパーリンクの既定の色は、システムのアクセント カラーです。</span><span class="sxs-lookup"><span data-stu-id="787fd-182">The default color of the hyperlink is the accent color of the system.</span></span> <span data-ttu-id="787fd-183">[Foreground](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.foreground.aspx) プロパティを設定するとこれを上書きできます。</span><span class="sxs-lookup"><span data-stu-id="787fd-183">You can set the [Foreground](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.foreground.aspx) property to override this.</span></span>

## <a name="recommendations"></a><span data-ttu-id="787fd-184">推奨事項</span><span class="sxs-lookup"><span data-stu-id="787fd-184">Recommendations</span></span>

-   <span data-ttu-id="787fd-185">ハイパーリンクを使う場合は、移動のみを目的としてください。他の操作のためにハイパーリンクは使わないでください。</span><span class="sxs-lookup"><span data-stu-id="787fd-185">Only use hyperlinks for navigation; don't use them for other actions.</span></span>
-   <span data-ttu-id="787fd-186">テキスト ベースのハイパーリンクには、書体見本の本文スタイルを使います。</span><span class="sxs-lookup"><span data-stu-id="787fd-186">Use the Body style from the type ramp for text-based hyperlinks.</span></span> <span data-ttu-id="787fd-187">[フォントと Windows 10 の書体見本](fonts.md)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="787fd-187">Read about [fonts and the Windows 10 type ramp](fonts.md).</span></span>
-   <span data-ttu-id="787fd-188">個々のハイパーリンクの間には十分な間隔を空けます。これにより、それぞれのハイパーリンクを区別することができ、ハイパーリンクを間違えずに選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="787fd-188">Keep discrete hyperlinks far enough apart so that the user can differentiate between them and has an easy time selecting each one.</span></span>
-   <span data-ttu-id="787fd-189">ユーザーの移動先を示すヒントをハイパーリンクに追加します。</span><span class="sxs-lookup"><span data-stu-id="787fd-189">Add tooltips to hyperlinks that indicate to where the user will be directed.</span></span> <span data-ttu-id="787fd-190">ユーザーが外部サイトに移動する場合は、ヒント内にトップレベルのドメイン名を入れ、補助的なフォント色を使ってそのテキストのスタイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="787fd-190">If the user will be directed to an external site, include the top-level domain name inside the tooltip, and style the text with a secondary font color.</span></span>

## <a name="related-articles"></a><span data-ttu-id="787fd-191">関連記事</span><span class="sxs-lookup"><span data-stu-id="787fd-191">Related articles</span></span>

- [<span data-ttu-id="787fd-192">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="787fd-192">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="787fd-193">ヒントのガイドライン</span><span class="sxs-lookup"><span data-stu-id="787fd-193">Guidelines for tooltips</span></span>](tooltips.md)

**<span data-ttu-id="787fd-194">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="787fd-194">For developers (XAML)</span></span>**
- [<span data-ttu-id="787fd-195">Windows.UI.Xaml.Documents.Hyperlink クラス</span><span class="sxs-lookup"><span data-stu-id="787fd-195">Windows.UI.Xaml.Documents.Hyperlink class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279356)
- [<span data-ttu-id="787fd-196">Windows.UI.Xaml.Controls.HyperlinkButton クラス</span><span class="sxs-lookup"><span data-stu-id="787fd-196">Windows.UI.Xaml.Controls.HyperlinkButton class</span></span>](https://msdn.microsoft.com/library/windows/apps/br242739)
