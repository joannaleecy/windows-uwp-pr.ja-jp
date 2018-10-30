---
author: Jwmsft
Description: Use a RichTextBlock with RichTextBlockOverflow elements to create advanced text layouts.
title: RichTextBlock
ms.assetid: E4BE4B1B-418E-4075-88F1-22C09DDF8E45
label: Rich text block
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 16ebc375a72984af8bbc40823121d2d94689fcf2
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5756557"
---
# <a name="rich-text-block"></a><span data-ttu-id="6e564-103">リッチ テキスト ブロック</span><span class="sxs-lookup"><span data-stu-id="6e564-103">Rich text block</span></span>

 

<span data-ttu-id="6e564-104">リッチ テキスト ブロックは、段落、インライン UI 要素、複雑なテキスト レイアウトなどのサポートが必要な場合に使用できる、高度なテキスト レイアウト用のいくつかの機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="6e564-104">Rich text blocks provide several features for advanced text layout that you can use when you need support for paragraphs, inline UI elements, or complex text layouts.</span></span>

> <span data-ttu-id="6e564-105">**重要な API**: [RichTextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)、[RichTextBlockOverflow クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx)、[Paragraph クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx)、[Typography クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx)</span><span class="sxs-lookup"><span data-stu-id="6e564-105">**Important APIs**: [RichTextBlock class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx), [RichTextBlockOverflow class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx), [Paragraph class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx), [Typography class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="6e564-106">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="6e564-106">Is this the right control?</span></span>

<span data-ttu-id="6e564-107">複数の段落、段組などの複雑なテキスト レイアウト、インライン UI 要素 (画像など) をサポートする必要がある場合は、**RichTextBlock** を使います。</span><span class="sxs-lookup"><span data-stu-id="6e564-107">Use a **RichTextBlock** when you need support for multiple paragraphs, multi-column or other complex text layouts, or inline UI elements like images.</span></span>

<span data-ttu-id="6e564-108">**TextBlock** を使用して、アプリ内の読み取り専用テキストの大半を表示します。</span><span class="sxs-lookup"><span data-stu-id="6e564-108">Use a **TextBlock** to display most read-only text in your app.</span></span> <span data-ttu-id="6e564-109">これを使用すると、単一行または複数行のテキスト、インライン ハイパーリンク、書式 (太字、斜体、下線付きなど) が設定されたテキストを表示できます。</span><span class="sxs-lookup"><span data-stu-id="6e564-109">You can use it to display single-line or multi-line text, inline hyperlinks, and text with formatting like bold, italic, or underlined.</span></span> <span data-ttu-id="6e564-110">TextBlock は、よりシンプルなコンテンツ モデルを提供します。そのため、一般に使い方がより簡単で、テキスト レンダリングのパフォーマンスも RichTextBlock より優れています。</span><span class="sxs-lookup"><span data-stu-id="6e564-110">TextBlock provides a simpler content model, so it’s typically easier to use, and it can provide better text rendering performance than RichTextBlock.</span></span> <span data-ttu-id="6e564-111">ほとんどのアプリで UI テキストに適しています。</span><span class="sxs-lookup"><span data-stu-id="6e564-111">It's preferred for most app UI text.</span></span> <span data-ttu-id="6e564-112">テキスト内に改行を配置することはできますが、TextBlock は単一の段落を表示するために設計されており、テキストのインデントはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="6e564-112">Although you can put line breaks in the text, TextBlock is designed to display a single paragraph and doesn’t support text indentation.</span></span>

<span data-ttu-id="6e564-113">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6e564-113">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="6e564-114">例</span><span class="sxs-lookup"><span data-stu-id="6e564-114">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="6e564-115">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="6e564-115">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="6e564-116"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/RichTextBlock">アプリを開き、RichTextBlock の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="6e564-116">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/RichTextBlock">open the app and see the RichTextBlock in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="6e564-117">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="6e564-117">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="6e564-118">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="6e564-118">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-rich-text-block"></a><span data-ttu-id="6e564-119">リッチ テキスト ブロックを作成する</span><span class="sxs-lookup"><span data-stu-id="6e564-119">Create a rich text block</span></span>

<span data-ttu-id="6e564-120">RichTextBlock のコンテンツ プロパティは [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) プロパティです。このプロパティでは、[Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素によって段落に基づくテキストがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="6e564-120">The content property of RichTextBlock is the [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) property, which supports paragraph based text via the [Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) element.</span></span> <span data-ttu-id="6e564-121">アプリ内でコントロールのテキスト コンテンツに簡単にアクセスすることができる **Text** プロパティは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="6e564-121">It doesn't have a **Text** property that you can use to easily access the control's text content in your app.</span></span> <span data-ttu-id="6e564-122">しかし、RichTextBlock には、TextBlock にはない独自の機能がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="6e564-122">However, RichTextBlock provides several unique features that TextBlock doesn’t provide.</span></span> 

<span data-ttu-id="6e564-123">RichTextBlock では次の機能がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="6e564-123">RichTextBlock supports:</span></span>
- <span data-ttu-id="6e564-124">複数の段落。</span><span class="sxs-lookup"><span data-stu-id="6e564-124">Multiple paragraphs.</span></span> <span data-ttu-id="6e564-125">段落のインデントを設定するには [TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="6e564-125">Set the indentation for paragraphs by setting the [TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) property.</span></span>
- <span data-ttu-id="6e564-126">インライン UI 要素。</span><span class="sxs-lookup"><span data-stu-id="6e564-126">Inline UI elements.</span></span> <span data-ttu-id="6e564-127">画像などの UI 要素をテキスト内にインラインで表示するには [InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) を使います。</span><span class="sxs-lookup"><span data-stu-id="6e564-127">Use an [InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) to display UI elements, such as images, inline with your text.</span></span>
- <span data-ttu-id="6e564-128">オーバーフロー コンテナー。</span><span class="sxs-lookup"><span data-stu-id="6e564-128">Overflow containers.</span></span> <span data-ttu-id="6e564-129">段組テキスト レイアウトを作成するには [RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="6e564-129">Use [RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) elements to create multi-column text layouts.</span></span>

### <a name="paragraphs"></a><span data-ttu-id="6e564-130">段落</span><span class="sxs-lookup"><span data-stu-id="6e564-130">Paragraphs</span></span>

<span data-ttu-id="6e564-131">RichTextBlock コントロール内に表示するテキストのブロックを定義するには [Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="6e564-131">You use [Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) elements to define the blocks of text to display within a RichTextBlock control.</span></span> <span data-ttu-id="6e564-132">すべての RichTextBlock に少なくとも 1 つの Paragraph を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="6e564-132">Every RichTextBlock should include at least one Paragraph.</span></span> 

<span data-ttu-id="6e564-133">RichTextBlock のすべての段落のインデントを設定するには、[RichTextBlock.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="6e564-133">You can set the indent amount for all paragraphs in a RichTextBlock by setting the [RichTextBlock.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) property.</span></span> <span data-ttu-id="6e564-134">RichTextBlock 内の特定の段落でこの設定を上書きするには、[Paragraph.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.textindent.aspx) プロパティを別の値に設定します。</span><span class="sxs-lookup"><span data-stu-id="6e564-134">You can override this setting for specific paragraphs in a RichTextBlock by setting the [Paragraph.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.textindent.aspx) property to a different value.</span></span>

```xaml
<RichTextBlock TextIndent="12">
  <Paragraph TextIndent="24">First paragraph.</Paragraph>
  <Paragraph>Second paragraph.</Paragraph>
  <Paragraph>Third paragraph. <Bold>With an inline.</Bold></Paragraph>
</RichTextBlock>
```

### <a name="inline-ui-elements"></a><span data-ttu-id="6e564-135">インライン UI 要素</span><span class="sxs-lookup"><span data-stu-id="6e564-135">Inline UI elements</span></span>

<span data-ttu-id="6e564-136">[InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) クラスを使うと、任意の UIElement をテキスト内にインラインで埋め込むことができます。</span><span class="sxs-lookup"><span data-stu-id="6e564-136">The [InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) class lets you embed any UIElement inline with your text.</span></span> <span data-ttu-id="6e564-137">Image をテキスト内にインラインで配置するシナリオが一般的ですが、Button、CheckBox などの対話型の要素を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="6e564-137">A common scenario is to place an Image inline with your text, but you can also use interactive elements, like a Button or CheckBox.</span></span>

<span data-ttu-id="6e564-138">同じ位置に複数の要素をインラインで埋め込むには、パネルを 1 つの InlineUIContainer の子として使って、そのパネルに複数の要素を配置することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="6e564-138">If you want to embed more than one element inline in the same position, consider using a panel as the single InlineUIContainer child, and then place the multiple elements within that panel.</span></span>

<span data-ttu-id="6e564-139">次の例は、InlineUIContainer を使って RichTextBlock に画像を挿入する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6e564-139">This example shows how to use an InlineUIContainer to insert an image into a RichTextBlock.</span></span> 

```xaml
<RichTextBlock>
    <Paragraph>
        <Italic>This is an inline image.</Italic>
        <InlineUIContainer>
            <Image Source="Assets/Square44x44Logo.png" Height="30" Width="30"/>
        </InlineUIContainer>
        Mauris auctor tincidunt auctor.
    </Paragraph>
</RichTextBlock>
```

## <a name="overflow-containers"></a><span data-ttu-id="6e564-140">オーバーフロー コンテナー</span><span class="sxs-lookup"><span data-stu-id="6e564-140">Overflow containers</span></span>

<span data-ttu-id="6e564-141">[RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) 要素を持つ RichTextBlock を使って、段組などの高度なページ レイアウトを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="6e564-141">You can use a RichTextBlock with [RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) elements to create multi-column or other advanced page layouts.</span></span> <span data-ttu-id="6e564-142">RichTextBlockOverflow 要素のコンテンツは、常に RichTextBlock 要素から取得されます。</span><span class="sxs-lookup"><span data-stu-id="6e564-142">The content for a RichTextBlockOverflow element always comes from a RichTextBlock element.</span></span> <span data-ttu-id="6e564-143">RichTextBlockOverflow 要素をリンクするには、その要素を RichTextBlock または別の RichTextBlockOverflow の OverflowContentTarget として設定します。</span><span class="sxs-lookup"><span data-stu-id="6e564-143">You link RichTextBlockOverflow elements by setting them as the OverflowContentTarget of a RichTextBlock or another RichTextBlockOverflow.</span></span>

<span data-ttu-id="6e564-144">2 段組みのレイアウトを作成する簡単な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6e564-144">Here's a simple example that creates a two column layout.</span></span> <span data-ttu-id="6e564-145">より複雑な例については、「例」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6e564-145">See the Examples section for a more complex example.</span></span>

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <RichTextBlock Grid.Column="0" 
                   OverflowContentTarget="{Binding ElementName=overflowContainer}" >
        <Paragraph>
            Proin ac metus at quam luctus ultricies.
        </Paragraph>
    </RichTextBlock>
    <RichTextBlockOverflow x:Name="overflowContainer" Grid.Column="1"/>
</Grid>
```

## <a name="formatting-text"></a><span data-ttu-id="6e564-146">テキストの書式設定</span><span class="sxs-lookup"><span data-stu-id="6e564-146">Formatting text</span></span>

<span data-ttu-id="6e564-147">RichTextBlock に格納されるのはプレーン テキストですが、各種の書式設定オプションを適用して、アプリでテキストをレンダリングする方法をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="6e564-147">Although the RichTextBlock stores plain text, you can apply various formatting options to customize how the text is rendered in your app.</span></span> <span data-ttu-id="6e564-148">FontFamily、FontSize、FontStyle、Foreground、CharacterSpacing などの標準的なコントロール プロパティを設定して、テキストの外観を変更できます。</span><span class="sxs-lookup"><span data-stu-id="6e564-148">You can set standard control properties like FontFamily, FontSize, FontStyle, Foreground, and CharacterSpacing to change the look of the text.</span></span> <span data-ttu-id="6e564-149">インライン テキスト要素と Typography 添付プロパティを使ってテキストを書式設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="6e564-149">You can also use inline text elements and Typography attached properties to format your text.</span></span> <span data-ttu-id="6e564-150">これらのオプションが影響を与えるのは、RichTextBlock がローカルでテキストを表示する方法だけです。したがって、テキストをコピーしてリッチ テキスト コントロールなどに貼り付けても、書式設定は適用されません。</span><span class="sxs-lookup"><span data-stu-id="6e564-150">These options affect only how the RichTextBlock displays the text locally, so if you copy and paste the text into a rich text control, for example, no formatting is applied.</span></span>

### <a name="inline-elements"></a><span data-ttu-id="6e564-151">インライン要素</span><span class="sxs-lookup"><span data-stu-id="6e564-151">Inline elements</span></span>

<span data-ttu-id="6e564-152">[Windows.UI.Xaml.Documents](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) 名前空間には、テキストの書式設定に使うことができるさまざまなインライン テキスト要素が用意されています (Bold、Italic、Run、Span、LineBreak など)。</span><span class="sxs-lookup"><span data-stu-id="6e564-152">The [Windows.UI.Xaml.Documents](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) namespace provides a variety of inline text elements that you can use to format your text, such as Bold, Italic, Run, Span, and LineBreak.</span></span> <span data-ttu-id="6e564-153">テキストのセクションに書式設定を適用する典型的な方法では、テキストを Run 要素または Span 要素に配置して、その要素のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="6e564-153">A typical way to apply formatting to sections of text is to place the text in a Run or Span element, and then set properties on that element.</span></span>

<span data-ttu-id="6e564-154">次の例では、Paragraph の最初の語句が太字、青色、16 ポイントのテキストで表示されます。</span><span class="sxs-lookup"><span data-stu-id="6e564-154">Here's a Paragraph with the first phrase shown in bold, blue, 16pt text.</span></span>

```xaml
<Paragraph>
    <Bold><Span Foreground="DarkSlateBlue" FontSize="16">Lorem ipsum dolor sit amet</Span></Bold>
    , consectetur adipiscing elit.
</Paragraph>
```

### <a name="typography"></a><span data-ttu-id="6e564-155">文字体裁</span><span class="sxs-lookup"><span data-stu-id="6e564-155">Typography</span></span>

<span data-ttu-id="6e564-156">[Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) クラスの添付プロパティは、Microsoft OpenType の一連の Typography プロパティへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="6e564-156">The attached properties of the [Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) class provide access to a set of Microsoft OpenType typography properties.</span></span> <span data-ttu-id="6e564-157">これらの添付プロパティは、RichTextBlock で設定することも、次の例のように個々のインライン テキスト要素で設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="6e564-157">You can set these attached properties either on the RichTextBlock, or on individual inline text elements, as shown here.</span></span>

```xaml
<RichTextBlock Typography.StylisticSet4="True">
    <Paragraph>
        <Span Typography.Capitals="SmallCaps">Lorem ipsum dolor sit amet</Span>
        , consectetur adipiscing elit.
    </Paragraph>
</RichTextBlock>
```

## <a name="recommendations"></a><span data-ttu-id="6e564-158">推奨事項</span><span class="sxs-lookup"><span data-stu-id="6e564-158">Recommendations</span></span>

<span data-ttu-id="6e564-159">文字体裁およびフォントのガイドラインに関するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6e564-159">See Typography and Guidelines for fonts.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="6e564-160">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="6e564-160">Get the sample code</span></span>

- <span data-ttu-id="6e564-161">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="6e564-161">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="6e564-162">関連記事</span><span class="sxs-lookup"><span data-stu-id="6e564-162">Related articles</span></span>

[<span data-ttu-id="6e564-163">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="6e564-163">Text controls</span></span>](text-controls.md)

**<span data-ttu-id="6e564-164">デザイナー向け</span><span class="sxs-lookup"><span data-stu-id="6e564-164">For designers</span></span>**
- [<span data-ttu-id="6e564-165">スペル チェックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="6e564-165">Guidelines for spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="6e564-166">検索の追加</span><span class="sxs-lookup"><span data-stu-id="6e564-166">Adding search</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [<span data-ttu-id="6e564-167">テキスト入力のガイドライン</span><span class="sxs-lookup"><span data-stu-id="6e564-167">Guidelines for text input</span></span>](text-controls.md)

**<span data-ttu-id="6e564-168">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="6e564-168">For developers (XAML)</span></span>**
- [<span data-ttu-id="6e564-169">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="6e564-169">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="6e564-170">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="6e564-170">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)


**<span data-ttu-id="6e564-171">開発者向け (その他)</span><span class="sxs-lookup"><span data-stu-id="6e564-171">For developers (other)</span></span>**
- [<span data-ttu-id="6e564-172">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="6e564-172">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
