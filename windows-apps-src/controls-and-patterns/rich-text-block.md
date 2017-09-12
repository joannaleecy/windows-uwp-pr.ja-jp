---
author: Jwmsft
Description: "RichTextBlockOverflow 要素を持つ RichTextBlock を使って、高度なテキスト レイアウトを作成します。"
title: RichTextBlock
ms.assetid: E4BE4B1B-418E-4075-88F1-22C09DDF8E45
label: Rich text block
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
ms.openlocfilehash: af9a6883ac20d59c319c663c1f489247e2bb6f2e
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="rich-text-block"></a><span data-ttu-id="5a768-104">リッチ テキスト ブロック</span><span class="sxs-lookup"><span data-stu-id="5a768-104">Rich text block</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="5a768-105">リッチ テキスト ブロックは、段落、インライン UI 要素、複雑なテキスト レイアウトなどのサポートが必要な場合に使用できる、高度なテキスト レイアウト用のいくつかの機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="5a768-105">Rich text blocks provide several features for advanced text layout that you can use when you need support for paragraphs, inline UI elements, or complex text layouts.</span></span>

> <span data-ttu-id="5a768-106">**重要な API**: [RichTextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)、[RichTextBlockOverflow クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx)、[Paragraph クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx)、[Typography クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx)</span><span class="sxs-lookup"><span data-stu-id="5a768-106">**Important APIs**: [RichTextBlock class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx), [RichTextBlockOverflow class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx), [Paragraph class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx), [Typography class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="5a768-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="5a768-107">Is this the right control?</span></span>

<span data-ttu-id="5a768-108">複数の段落、段組などの複雑なテキスト レイアウト、インライン UI 要素 (画像など) をサポートする必要がある場合は、**RichTextBlock** を使います。</span><span class="sxs-lookup"><span data-stu-id="5a768-108">Use a **RichTextBlock** when you need support for multiple paragraphs, multi-column or other complex text layouts, or inline UI elements like images.</span></span>

<span data-ttu-id="5a768-109">**TextBlock** を使用して、アプリ内の読み取り専用テキストの大半を表示します。</span><span class="sxs-lookup"><span data-stu-id="5a768-109">Use a **TextBlock** to display most read-only text in your app.</span></span> <span data-ttu-id="5a768-110">これを使用すると、単一行または複数行のテキスト、インライン ハイパーリンク、書式 (太字、斜体、下線付きなど) が設定されたテキストを表示できます。</span><span class="sxs-lookup"><span data-stu-id="5a768-110">You can use it to display single-line or multi-line text, inline hyperlinks, and text with formatting like bold, italic, or underlined.</span></span> <span data-ttu-id="5a768-111">TextBlock は、よりシンプルなコンテンツ モデルを提供します。そのため、一般に使い方がより簡単で、テキスト レンダリングのパフォーマンスも RichTextBlock より優れています。</span><span class="sxs-lookup"><span data-stu-id="5a768-111">TextBlock provides a simpler content model, so it’s typically easier to use, and it can provide better text rendering performance than RichTextBlock.</span></span> <span data-ttu-id="5a768-112">ほとんどのアプリで UI テキストに適しています。</span><span class="sxs-lookup"><span data-stu-id="5a768-112">It's preferred for most app UI text.</span></span> <span data-ttu-id="5a768-113">テキスト内に改行を配置することはできますが、TextBlock は単一の段落を表示するために設計されており、テキストのインデントはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="5a768-113">Although you can put line breaks in the text, TextBlock is designed to display a single paragraph and doesn’t support text indentation.</span></span>

<span data-ttu-id="5a768-114">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a768-114">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="create-a-rich-text-block"></a><span data-ttu-id="5a768-115">リッチ テキスト ブロックを作成する</span><span class="sxs-lookup"><span data-stu-id="5a768-115">Create a rich text block</span></span>

<span data-ttu-id="5a768-116">RichTextBlock のコンテンツ プロパティは [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) プロパティです。このプロパティでは、[Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素によって段落に基づくテキストがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="5a768-116">The content property of RichTextBlock is the [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) property, which supports paragraph based text via the [Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) element.</span></span> <span data-ttu-id="5a768-117">アプリ内でコントロールのテキスト コンテンツに簡単にアクセスすることができる **Text** プロパティは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="5a768-117">It doesn't have a **Text** property that you can use to easily access the control's text content in your app.</span></span> <span data-ttu-id="5a768-118">しかし、RichTextBlock には、TextBlock にはない独自の機能がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="5a768-118">However, RichTextBlock provides several unique features that TextBlock doesn’t provide.</span></span> 

<span data-ttu-id="5a768-119">RichTextBlock では次の機能がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="5a768-119">RichTextBlock supports:</span></span>
- <span data-ttu-id="5a768-120">複数の段落。</span><span class="sxs-lookup"><span data-stu-id="5a768-120">Multiple paragraphs.</span></span> <span data-ttu-id="5a768-121">段落のインデントを設定するには [TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="5a768-121">Set the indentation for paragraphs by setting the [TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) property.</span></span>
- <span data-ttu-id="5a768-122">インライン UI 要素。</span><span class="sxs-lookup"><span data-stu-id="5a768-122">Inline UI elements.</span></span> <span data-ttu-id="5a768-123">画像などの UI 要素をテキスト内にインラインで表示するには [InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) を使います。</span><span class="sxs-lookup"><span data-stu-id="5a768-123">Use an [InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) to display UI elements, such as images, inline with your text.</span></span>
- <span data-ttu-id="5a768-124">オーバーフロー コンテナー。</span><span class="sxs-lookup"><span data-stu-id="5a768-124">Overflow containers.</span></span> <span data-ttu-id="5a768-125">段組テキスト レイアウトを作成するには [RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="5a768-125">Use [RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) elements to create multi-column text layouts.</span></span>

### <a name="paragraphs"></a><span data-ttu-id="5a768-126">段落</span><span class="sxs-lookup"><span data-stu-id="5a768-126">Paragraphs</span></span>

<span data-ttu-id="5a768-127">RichTextBlock コントロール内に表示するテキストのブロックを定義するには [Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="5a768-127">You use [Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) elements to define the blocks of text to display within a RichTextBlock control.</span></span> <span data-ttu-id="5a768-128">すべての RichTextBlock に少なくとも 1 つの Paragraph を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a768-128">Every RichTextBlock should include at least one Paragraph.</span></span> 

<span data-ttu-id="5a768-129">RichTextBlock のすべての段落のインデントを設定するには、[RichTextBlock.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="5a768-129">You can set the indent amount for all paragraphs in a RichTextBlock by setting the [RichTextBlock.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) property.</span></span> <span data-ttu-id="5a768-130">RichTextBlock 内の特定の段落でこの設定を上書きするには、[Paragraph.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.textindent.aspx) プロパティを別の値に設定します。</span><span class="sxs-lookup"><span data-stu-id="5a768-130">You can override this setting for specific paragraphs in a RichTextBlock by setting the [Paragraph.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.textindent.aspx) property to a different value.</span></span>

```xaml
<RichTextBlock TextIndent="12">
  <Paragraph TextIndent="24">First paragraph.</Paragraph>
  <Paragraph>Second paragraph.</Paragraph>
  <Paragraph>Third paragraph. <Bold>With an inline.</Bold></Paragraph>
</RichTextBlock>
```

### <a name="inline-ui-elements"></a><span data-ttu-id="5a768-131">インライン UI 要素</span><span class="sxs-lookup"><span data-stu-id="5a768-131">Inline UI elements</span></span>

<span data-ttu-id="5a768-132">[InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) クラスを使うと、任意の UIElement をテキスト内にインラインで埋め込むことができます。</span><span class="sxs-lookup"><span data-stu-id="5a768-132">The [InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) class lets you embed any UIElement inline with your text.</span></span> <span data-ttu-id="5a768-133">Image をテキスト内にインラインで配置するシナリオが一般的ですが、Button、CheckBox などの対話型の要素を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="5a768-133">A common scenario is to place an Image inline with your text, but you can also use interactive elements, like a Button or CheckBox.</span></span>

<span data-ttu-id="5a768-134">同じ位置に複数の要素をインラインで埋め込むには、パネルを 1 つの InlineUIContainer の子として使って、そのパネルに複数の要素を配置することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="5a768-134">If you want to embed more than one element inline in the same position, consider using a panel as the single InlineUIContainer child, and then place the multiple elements within that panel.</span></span>

<span data-ttu-id="5a768-135">次の例は、InlineUIContainer を使って RichTextBlock に画像を挿入する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="5a768-135">This example shows how to use an InlineUIContainer to insert an image into a RichTextBlock.</span></span> 

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

## <a name="overflow-containers"></a><span data-ttu-id="5a768-136">オーバーフロー コンテナー</span><span class="sxs-lookup"><span data-stu-id="5a768-136">Overflow containers</span></span>

<span data-ttu-id="5a768-137">[RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) 要素を持つ RichTextBlock を使って、段組などの高度なページ レイアウトを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="5a768-137">You can use a RichTextBlock with [RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) elements to create multi-column or other advanced page layouts.</span></span> <span data-ttu-id="5a768-138">RichTextBlockOverflow 要素のコンテンツは、常に RichTextBlock 要素から取得されます。</span><span class="sxs-lookup"><span data-stu-id="5a768-138">The content for a RichTextBlockOverflow element always comes from a RichTextBlock element.</span></span> <span data-ttu-id="5a768-139">RichTextBlockOverflow 要素をリンクするには、その要素を RichTextBlock または別の RichTextBlockOverflow の OverflowContentTarget として設定します。</span><span class="sxs-lookup"><span data-stu-id="5a768-139">You link RichTextBlockOverflow elements by setting them as the OverflowContentTarget of a RichTextBlock or another RichTextBlockOverflow.</span></span>

<span data-ttu-id="5a768-140">2 段組みのレイアウトを作成する簡単な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="5a768-140">Here's a simple example that creates a two column layout.</span></span> <span data-ttu-id="5a768-141">より複雑な例については、「例」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a768-141">See the Examples section for a more complex example.</span></span>

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

## <a name="formatting-text"></a><span data-ttu-id="5a768-142">テキストの書式設定</span><span class="sxs-lookup"><span data-stu-id="5a768-142">Formatting text</span></span>

<span data-ttu-id="5a768-143">RichTextBlock に格納されるのはプレーン テキストですが、各種の書式設定オプションを適用して、アプリでテキストをレンダリングする方法をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="5a768-143">Although the RichTextBlock stores plain text, you can apply various formatting options to customize how the text is rendered in your app.</span></span> <span data-ttu-id="5a768-144">FontFamily、FontSize、FontStyle、Foreground、CharacterSpacing などの標準的なコントロール プロパティを設定して、テキストの外観を変更できます。</span><span class="sxs-lookup"><span data-stu-id="5a768-144">You can set standard control properties like FontFamily, FontSize, FontStyle, Foreground, and CharacterSpacing to change the look of the text.</span></span> <span data-ttu-id="5a768-145">インライン テキスト要素と Typography 添付プロパティを使ってテキストを書式設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="5a768-145">You can also use inline text elements and Typography attached properties to format your text.</span></span> <span data-ttu-id="5a768-146">これらのオプションが影響を与えるのは、RichTextBlock がローカルでテキストを表示する方法だけです。したがって、テキストをコピーしてリッチ テキスト コントロールなどに貼り付けても、書式設定は適用されません。</span><span class="sxs-lookup"><span data-stu-id="5a768-146">These options affect only how the RichTextBlock displays the text locally, so if you copy and paste the text into a rich text control, for example, no formatting is applied.</span></span>

### <a name="inline-elements"></a><span data-ttu-id="5a768-147">インライン要素</span><span class="sxs-lookup"><span data-stu-id="5a768-147">Inline elements</span></span>

<span data-ttu-id="5a768-148">[Windows.UI.Xaml.Documents](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) 名前空間には、テキストの書式設定に使うことができるさまざまなインライン テキスト要素が用意されています (Bold、Italic、Run、Span、LineBreak など)。</span><span class="sxs-lookup"><span data-stu-id="5a768-148">The [Windows.UI.Xaml.Documents](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) namespace provides a variety of inline text elements that you can use to format your text, such as Bold, Italic, Run, Span, and LineBreak.</span></span> <span data-ttu-id="5a768-149">テキストのセクションに書式設定を適用する典型的な方法では、テキストを Run 要素または Span 要素に配置して、その要素のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="5a768-149">A typical way to apply formatting to sections of text is to place the text in a Run or Span element, and then set properties on that element.</span></span>

<span data-ttu-id="5a768-150">次の例では、Paragraph の最初の語句が太字、青色、16 ポイントのテキストで表示されます。</span><span class="sxs-lookup"><span data-stu-id="5a768-150">Here's a Paragraph with the first phrase shown in bold, blue, 16pt text.</span></span>

```xaml
<Paragraph>
    <Bold><Span Foreground="DarkSlateBlue" FontSize="16">Lorem ipsum dolor sit amet</Span></Bold>
    , consectetur adipiscing elit.
</Paragraph>
```

### <a name="typography"></a><span data-ttu-id="5a768-151">文字体裁</span><span class="sxs-lookup"><span data-stu-id="5a768-151">Typography</span></span>

<span data-ttu-id="5a768-152">[Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) クラスの添付プロパティは、Microsoft OpenType の一連の Typography プロパティへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="5a768-152">The attached properties of the [Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) class provide access to a set of Microsoft OpenType typography properties.</span></span> <span data-ttu-id="5a768-153">これらの添付プロパティは、RichTextBlock で設定することも、次の例のように個々のインライン テキスト要素で設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="5a768-153">You can set these attached properties either on the RichTextBlock, or on individual inline text elements, as shown here.</span></span>

```xaml
<RichTextBlock Typography.StylisticSet4="True">
    <Paragraph>
        <Span Typography.Capitals="SmallCaps">Lorem ipsum dolor sit amet</Span>
        , consectetur adipiscing elit.
    </Paragraph>
</RichTextBlock>
```

## <a name="recommendations"></a><span data-ttu-id="5a768-154">推奨事項</span><span class="sxs-lookup"><span data-stu-id="5a768-154">Recommendations</span></span>

<span data-ttu-id="5a768-155">文字体裁およびフォントのガイドラインに関するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a768-155">See Typography and Guidelines for fonts.</span></span>



## <a name="related-articles"></a><span data-ttu-id="5a768-156">関連記事</span><span class="sxs-lookup"><span data-stu-id="5a768-156">Related articles</span></span>

[<span data-ttu-id="5a768-157">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="5a768-157">Text controls</span></span>](text-controls.md)

**<span data-ttu-id="5a768-158">デザイナー向け</span><span class="sxs-lookup"><span data-stu-id="5a768-158">For designers</span></span>**
- [<span data-ttu-id="5a768-159">スペル チェックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="5a768-159">Guidelines for spell checking</span></span>](spell-checking-and-prediction.md)
- [<span data-ttu-id="5a768-160">検索の追加</span><span class="sxs-lookup"><span data-stu-id="5a768-160">Adding search</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [<span data-ttu-id="5a768-161">テキスト入力のガイドライン</span><span class="sxs-lookup"><span data-stu-id="5a768-161">Guidelines for text input</span></span>](text-controls.md)

**<span data-ttu-id="5a768-162">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="5a768-162">For developers (XAML)</span></span>**
- [<span data-ttu-id="5a768-163">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="5a768-163">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="5a768-164">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="5a768-164">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)


**<span data-ttu-id="5a768-165">開発者向け (その他)</span><span class="sxs-lookup"><span data-stu-id="5a768-165">For developers (other)</span></span>**
- [<span data-ttu-id="5a768-166">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="5a768-166">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
