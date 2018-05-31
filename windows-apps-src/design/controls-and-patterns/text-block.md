---
author: Jwmsft
ms.assetid: DA562509-D893-425A-AAE6-B2AE9E9F8A19
Description: Text block is the primary control for displaying read-only text in apps.
title: テキスト ブロック
label: Text block
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
ms.localizationpriority: medium
ms.openlocfilehash: 387f160d409bc032c30ac8059fc85b9954a800f0
ms.sourcegitcommit: 4b522af988273946414a04fbbd1d7fde40f8ba5e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/08/2018
ms.locfileid: "1494119"
---
# <a name="text-block"></a><span data-ttu-id="0c7db-103">テキスト ブロック</span><span class="sxs-lookup"><span data-stu-id="0c7db-103">Text block</span></span>

 

 <span data-ttu-id="0c7db-104">テキスト ブロックは、アプリで読み取り専用テキストを表示するためのプライマリ コントロールです。</span><span class="sxs-lookup"><span data-stu-id="0c7db-104">Text block is the primary control for displaying read-only text in apps.</span></span> <span data-ttu-id="0c7db-105">これを使用すると、単一行または複数行のテキスト、インライン ハイパーリンク、書式 (太字、斜体、下線付きなど) が設定されたテキストを表示できます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-105">You can use it to display single-line or multi-line text, inline hyperlinks, and text with formatting like bold, italic, or underlined.</span></span>
 
 > <span data-ttu-id="0c7db-106">**重要な API**: [TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、[Text プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx)、[Inlines プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.inlines.aspx)</span><span class="sxs-lookup"><span data-stu-id="0c7db-106">**Important APIs**: [TextBlock class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx), [Text property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx), [Inlines property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.inlines.aspx)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="0c7db-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="0c7db-107">Is this the right control?</span></span>

<span data-ttu-id="0c7db-108">テキスト ブロックは、一般的に、リッチ テキスト ブロックより使い方が簡単で、テキスト レンダリングのパフォーマンスが優れているため、ほとんどのアプリで UI テキストに適しています。</span><span class="sxs-lookup"><span data-stu-id="0c7db-108">A text block is typically easier to use and provides better text rendering performance than a rich text block, so it's preferred for most app UI text.</span></span> <span data-ttu-id="0c7db-109">[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) プロパティの値を取得することによって、アプリ内でテキスト ブロックのテキストに容易にアクセスして使用することができます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-109">You can easily access and use text from a text block in your app by getting the value of the [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) property.</span></span> <span data-ttu-id="0c7db-110">テキストのレンダリング方法をカスタマイズするための書式設定オプションも、同じものが数多く用意されています。</span><span class="sxs-lookup"><span data-stu-id="0c7db-110">It also provides many of the same formatting options for customizing how your text is rendered.</span></span>

<span data-ttu-id="0c7db-111">テキスト内に改行を配置することはできますが、テキスト ブロックは単一の段落を表示するために設計されており、テキストのインデントはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0c7db-111">Although you can put line breaks in the text, text block is designed to display a single paragraph and doesn’t support text indentation.</span></span> <span data-ttu-id="0c7db-112">複数の段落、段組テキスト、インライン UI 要素 (画像など) をサポートする必要がある場合は、**RichTextBlock** を使います。</span><span class="sxs-lookup"><span data-stu-id="0c7db-112">Use a **RichTextBlock** when you need support for multiple paragraphs, multi-column text or other complex text layouts, or inline UI elements like images.</span></span>

<span data-ttu-id="0c7db-113">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0c7db-113">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="0c7db-114">例</span><span class="sxs-lookup"><span data-stu-id="0c7db-114">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="0c7db-115">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="0c7db-115">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="0c7db-116"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/TextBlock">アプリを開き、TextBlock の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="0c7db-116">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/TextBlock">open the app and see the TextBlock in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="0c7db-117">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="0c7db-117">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="0c7db-118">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="0c7db-118">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-text-block"></a><span data-ttu-id="0c7db-119">テキスト ブロックの作成</span><span class="sxs-lookup"><span data-stu-id="0c7db-119">Create a text block</span></span>

<span data-ttu-id="0c7db-120">ここでは、単純な TextBlock コントロールを定義し、その Text プロパティを文字列に設定する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0c7db-120">Here's how to define a simple TextBlock control and set its Text property to a string.</span></span>

```xaml
<TextBlock Text="Hello, world!" />
```

```csharp
TextBlock textBlock1 = new TextBlock();
textBlock1.Text = "Hello, world!";
```

    <TextBlock Text="Hello, world!" />

    TextBlock textBlock1 = new TextBlock();
    textBlock1.Text = "Hello, world!";

### <a name="content-model"></a><span data-ttu-id="0c7db-121">コンテンツ モデル</span><span class="sxs-lookup"><span data-stu-id="0c7db-121">Content model</span></span>

<span data-ttu-id="0c7db-122">コンテンツを TextBlock に追加するために使用できるプロパティとして、[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) と [Inlines](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.inlines.aspx) の 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="0c7db-122">There are two properties you can use to add content to a TextBlock: [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) and [Inlines](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.inlines.aspx).</span></span>

<span data-ttu-id="0c7db-123">テキストを表示する最も一般的な方法は、前の例で示したように Text プロパティを文字列値に設定することです。</span><span class="sxs-lookup"><span data-stu-id="0c7db-123">The most common way to display text is to set the Text property to a string value, as shown in the previous example.</span></span>

<span data-ttu-id="0c7db-124">また、次のように、TextBox.Inlines プロパティにインライン フロー コンテンツ要素を配置することで、コンテンツを追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-124">You can also add content by placing inline flow content elements in the TextBox.Inlines property, like this.</span></span>
```xaml
<TextBlock>Text can be <Bold>bold</Bold>, <Underline>underlined</Underline>, 
    <Italic>italic</Italic>, or a <Bold><Italic>combination</Italic></Bold>.</TextBlock>
```

<span data-ttu-id="0c7db-125">Inline クラスから派生した要素 (Bold、Italic、Run、Span、LineBreak など) を使用すると、テキスト内の部分によって別々の書式を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-125">Elements derived from the Inline class, such as Bold, Italic, Run, Span, and LineBreak, enable different formatting for different parts of the text.</span></span> <span data-ttu-id="0c7db-126">詳しくは、「[テキストの書式設定]()」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0c7db-126">For more info, see the [Formatting text]() section.</span></span> <span data-ttu-id="0c7db-127">インラインの Hyperlink 要素を使うと、テキストにハイパーリンクを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-127">The inline Hyperlink element lets you add a hyperlink to your text.</span></span> <span data-ttu-id="0c7db-128">ただし、Inlines を使用すると、テキストの高速パス レンダリングが無効になります。これについては、次のセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="0c7db-128">However, using Inlines also disables fast path text rendering, which is discussed in the next section.</span></span>


## <a name="performance-considerations"></a><span data-ttu-id="0c7db-129">パフォーマンスに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="0c7db-129">Performance considerations</span></span>

<span data-ttu-id="0c7db-130">可能であれば、XAML ではより効率的なコード パスを使ってテキストをレイアウトします。</span><span class="sxs-lookup"><span data-stu-id="0c7db-130">Whenever possible, XAML uses a more efficient code path to layout text.</span></span> <span data-ttu-id="0c7db-131">この高速パスを使うと、全体的なメモリ使用量が減少し、テキストのサイズ測定と配置を実行するための CPU 時間が大幅に減少します。</span><span class="sxs-lookup"><span data-stu-id="0c7db-131">This fast path both decreases overall memory use and greatly reduces the CPU time to do text measuring and arranging.</span></span> <span data-ttu-id="0c7db-132">この高速パスは TextBlock にのみ適用されるため、可能な場合 RichTextBlock よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-132">This fast path applies only to TextBlock, so it should be preferred when possible over RichTextBlock.</span></span>

<span data-ttu-id="0c7db-133">特定の条件では、TextBlock のテキストのレンダリングはより高機能な CPU 負荷の高いコード パスにフォールバックされます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-133">Certain conditions require TextBlock to fall back to a more feature-rich and CPU intensive code path for text rendering.</span></span> <span data-ttu-id="0c7db-134">常に高速パスでテキスト レンダリングを処理するために、次に示すプロパティを設定するときは、以下のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="0c7db-134">To keep text rendering on the fast path, be sure to follow these guidelines when setting the properties listed here.</span></span>
- <span data-ttu-id="0c7db-135">[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx): 最も重要な条件は、XAML またはコード (前の例に示されている) で Text プロパティを明示的に設定することによってテキストを設定した場合にのみ高速パスが使用されるということです。</span><span class="sxs-lookup"><span data-stu-id="0c7db-135">[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx): The most important condition is that the fast path is used only when you set text by explicitly setting the Text property, either in XAML or in code (as shown in the previous examples).</span></span> <span data-ttu-id="0c7db-136">TextBlock の Inlines コレクション (`<TextBlock>Inline text</TextBlock>` など) によってテキストを設定すると、複数の形式の潜在的な複雑さのために、高速パスが無効になります。</span><span class="sxs-lookup"><span data-stu-id="0c7db-136">Setting the text via TextBlock’s Inlines collection (such as `<TextBlock>Inline text</TextBlock>`) will disable the fast path, due to the potential complexity of multiple formats.</span></span>
- <span data-ttu-id="0c7db-137">[CharacterSpacing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.characterspacing.aspx): 既定値の 0 のみが高速パスです。</span><span class="sxs-lookup"><span data-stu-id="0c7db-137">[CharacterSpacing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.characterspacing.aspx): Only the default value of 0 is fast path.</span></span>
- <span data-ttu-id="0c7db-138">[TextTrimming](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.texttrimming.aspx): **None**、**CharacterEllipsis**、および **WordEllipsis** 値のみが高速パスです。</span><span class="sxs-lookup"><span data-stu-id="0c7db-138">[TextTrimming](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.texttrimming.aspx): Only the **None**, **CharacterEllipsis**, and **WordEllipsis** values are fast path.</span></span> <span data-ttu-id="0c7db-139">**Clip** 値は高速パスを無効にします。</span><span class="sxs-lookup"><span data-stu-id="0c7db-139">The **Clip** value disables the fast path.</span></span>

> <span data-ttu-id="0c7db-140">**注**&nbsp;&nbsp;Windows 10 Version 1607 より前のバージョンでは、他のプロパティも高速パスに影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-140">**Note**&nbsp;&nbsp;Prior to Windows 10, version 1607, additional properties also affect the fast path.</span></span> <span data-ttu-id="0c7db-141">以前のバージョンの Windows でアプリが実行される場合は、以下の条件によってもテキストは低速パスでレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-141">If your app is run on an earlier version of Windows, these conditions will also cause your text to render on the slow path.</span></span> <span data-ttu-id="0c7db-142">バージョンについて詳しくは、バージョン アダプティブ コードを参照してください。</span><span class="sxs-lookup"><span data-stu-id="0c7db-142">For more info about versions, see Version adaptive code.</span></span>
- <span data-ttu-id="0c7db-143">[Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx): さまざまな Typography プロパティの既定値のみが高速パスです。</span><span class="sxs-lookup"><span data-stu-id="0c7db-143">[Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx): Only the default values for the various Typography properties are fast path.</span></span>
- <span data-ttu-id="0c7db-144">[LineStackingStrategy](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.linestackingstrategy.aspx): [LineHeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.lineheight.aspx) が 0 ではない場合、**BaselineToBaseline** および **MaxHeight** の値は高速パスを無効にします。</span><span class="sxs-lookup"><span data-stu-id="0c7db-144">[LineStackingStrategy](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.linestackingstrategy.aspx): If [LineHeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.lineheight.aspx) is not 0, the **BaselineToBaseline** and **MaxHeight** values disable the fast path.</span></span>
- <span data-ttu-id="0c7db-145">[IsTextSelectionEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.istextselectionenabled.aspx): **false** のみが高速パスです。</span><span class="sxs-lookup"><span data-stu-id="0c7db-145">[IsTextSelectionEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.istextselectionenabled.aspx): Only **false** is fast path.</span></span> <span data-ttu-id="0c7db-146">このプロパティを **true** に設定すると、高速パスが無効になります。</span><span class="sxs-lookup"><span data-stu-id="0c7db-146">Setting this property to **true** disables the fast path.</span></span>

<span data-ttu-id="0c7db-147">デバッグ中に [DebugSettings.IsTextPerformanceVisualizationEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.debugsettings.istextperformancevisualizationenabled.aspx) プロパティを **true** に設定すると、テキストのレンダリングに高速パスが使用されているかどうかを特定できます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-147">You can set the [DebugSettings.IsTextPerformanceVisualizationEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.debugsettings.istextperformancevisualizationenabled.aspx) property to **true** during debugging to determine whether text is using fast path rendering.</span></span> <span data-ttu-id="0c7db-148">このプロパティを true に設定すると、高速パスにあるテキストは明るい緑色で表示されます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-148">When this property is set to true, the text that is on the fast path displays in a bright green color.</span></span>

><span data-ttu-id="0c7db-149">**ヒント**&nbsp;&nbsp;この機能については、ビルド 2015 以降のこのセッション ([XAML パフォーマンス: XAML を使って構築されたユニバーサル Windows アプリのエクスペリエンスを最大化する手法](https://channel9.msdn.com/Events/Build/2015/3-698)) で説明します。</span><span class="sxs-lookup"><span data-stu-id="0c7db-149">**Tip**&nbsp;&nbsp;This feature is explained in depth in this session from Build 2015- [XAML Performance: Techniques for Maximizing Universal Windows App Experiences Built with XAML](https://channel9.msdn.com/Events/Build/2015/3-698).</span></span>



<span data-ttu-id="0c7db-150">通常、次のように、App.xaml の分離コード ページの [OnLaunched](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.application.onlaunched.aspx) メソッドのオーバーライドでデバッグの設定を行います。</span><span class="sxs-lookup"><span data-stu-id="0c7db-150">You typically set debug settings in the [OnLaunched](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.application.onlaunched.aspx) method override in the code-behind page for App.xaml, like this.</span></span>
```csharp
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
#if DEBUG
    if (System.Diagnostics.Debugger.IsAttached)
    {
        this.DebugSettings.IsTextPerformanceVisualizationEnabled = true;
    }
#endif

// ...

}
```

<span data-ttu-id="0c7db-151">この例では、最初の TextBlock は高速パスを使用してレンダリングされますが、2 番目の TextBlock は高速パスでレンダリングされません。</span><span class="sxs-lookup"><span data-stu-id="0c7db-151">In this example, the first TextBlock is rendered using the fast path, while the second is not.</span></span>
```xaml
<StackPanel>
    <TextBlock Text="This text is on the fast path."/>
    <TextBlock>This text is NOT on the fast path.</TextBlock>
<StackPanel/>
```

<span data-ttu-id="0c7db-152">IsTextPerformanceVisualizationEnabled を true に設定してデバッグ モードでこの XAML を実行すると、次のような結果になります。</span><span class="sxs-lookup"><span data-stu-id="0c7db-152">When you run this XAML in debug mode with IsTextPerformanceVisualizationEnabled set to true, the result looks like this.</span></span>

![デバッグ モードでレンダリングされたテキスト](images/text-block-rendering-performance.png)

><span data-ttu-id="0c7db-154">**注意**&nbsp;&nbsp;高速パスにないテキストの色は変更されません。</span><span class="sxs-lookup"><span data-stu-id="0c7db-154">**Caution**&nbsp;&nbsp;The color of text that is not on the fast path is not changed.</span></span> <span data-ttu-id="0c7db-155">アプリ内に、明るい緑色として指定された色のテキストがある場合、レンダリング パスが低速であれば、引き続き明るい緑色として表示されます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-155">If you have text in your app with its color specified as bright green, it is still displayed in bright green when it's on the slower rendering path.</span></span> <span data-ttu-id="0c7db-156">テキストが高速パスにあるアプリで緑色に設定されたテキストと、デバッグ設定による緑色を混同しないように注意してください。</span><span class="sxs-lookup"><span data-stu-id="0c7db-156">Be careful to not confuse text that is set to green in the app with text that is on the fast path and green because of the debug settings.</span></span>

## <a name="formatting-text"></a><span data-ttu-id="0c7db-157">テキストの書式設定</span><span class="sxs-lookup"><span data-stu-id="0c7db-157">Formatting text</span></span>

<span data-ttu-id="0c7db-158">Text プロパティに格納されるのはプレーンテキストですが、各種の書式設定オプションを TextBlock コントロールに適用して、アプリでテキストをレンダリングする方法をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-158">Although the Text property stores plain text, you can apply various formatting options to the TextBlock control to customize how the text is rendered in your app.</span></span> <span data-ttu-id="0c7db-159">FontFamily、FontSize、FontStyle、Foreground、CharacterSpacing などの標準的なコントロール プロパティを設定して、テキストの外観を変更できます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-159">You can set standard control properties like FontFamily, FontSize, FontStyle, Foreground, and CharacterSpacing to change the look of the text.</span></span> <span data-ttu-id="0c7db-160">インライン テキスト要素と Typography 添付プロパティを使ってテキストを書式設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-160">You can also use inline text elements and Typography attached properties to format your text.</span></span> <span data-ttu-id="0c7db-161">これらのオプションが影響を与えるのは、TextBlock がローカルでテキストを表示する方法だけです。したがって、テキストをコピーしてリッチ テキスト コントロールなどに貼り付けても、書式設定は適用されません。</span><span class="sxs-lookup"><span data-stu-id="0c7db-161">These options affect only how the TextBlock displays the text locally, so if you copy and paste the text into a rich text control, for example, no formatting is applied.</span></span>

><span data-ttu-id="0c7db-162">**注**&nbsp;&nbsp;前のセクションで説明したように、インライン テキスト要素と既定以外の文字体裁値は、高速パスでレンダリングされません。</span><span class="sxs-lookup"><span data-stu-id="0c7db-162">**Note**&nbsp;&nbsp;Remember, as noted in the previous section, inline text elements and non-default typography values are not rendered on the fast path.</span></span>


### <a name="inline-elements"></a><span data-ttu-id="0c7db-163">インライン要素</span><span class="sxs-lookup"><span data-stu-id="0c7db-163">Inline elements</span></span>

<span data-ttu-id="0c7db-164">[Windows.UI.Xaml.Documents](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) 名前空間には、テキストの書式設定に使うことができるさまざまなインライン テキスト要素が用意されています (Bold、Italic、Run、Span、LineBreak など)。</span><span class="sxs-lookup"><span data-stu-id="0c7db-164">The [Windows.UI.Xaml.Documents](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) namespace provides a variety of inline text elements that you can use to format your text, such as Bold, Italic, Run, Span, and LineBreak.</span></span>

<span data-ttu-id="0c7db-165">それぞれ書式設定の異なる複数の文字列を TextBlock に表示できます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-165">You can display a series of strings in a TextBlock, where each string has different formatting.</span></span> <span data-ttu-id="0c7db-166">そのためには、Run 要素を使って各文字列をそれぞれの書式設定で表示し、各 Run 要素を LineBreak 要素で区切ります。</span><span class="sxs-lookup"><span data-stu-id="0c7db-166">You can do this by using a Run element to display each string with its formatting and by separating each Run element with a LineBreak element.</span></span>

<span data-ttu-id="0c7db-167">次の例は、LineBreak で区切られた Run オブジェクトを使って、書式設定の異なる複数のテキスト文字列を TextBlock に定義する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0c7db-167">Here's how to define several differently formatted text strings in a TextBlock by using Run objects separated with a LineBreak.</span></span>
```xaml
<TextBlock FontFamily="Segoe UI" Width="400" Text="Sample text formatting runs">
    <LineBreak/>
    <Run Foreground="Gray" FontFamily="Segoe UI Light" FontSize="24">
        Segoe UI Light 24
    </Run>
    <LineBreak/>
    <Run Foreground="Teal" FontFamily="Georgia" FontSize="18" FontStyle="Italic">
        Georgia Italic 18
    </Run>
    <LineBreak/>
    <Run Foreground="Black" FontFamily="Arial" FontSize="14" FontWeight="Bold">
        Arial Bold 14
    </Run>
</TextBlock>
```

<span data-ttu-id="0c7db-168">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0c7db-168">Here's the result.</span></span>

![Run 要素で書式設定されたテキスト](images/text-block-run-examples.png)

### <a name="typography"></a><span data-ttu-id="0c7db-170">文字体裁</span><span class="sxs-lookup"><span data-stu-id="0c7db-170">Typography</span></span>

<span data-ttu-id="0c7db-171">[Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) クラスの添付プロパティは、Microsoft OpenType の一連の Typography プロパティへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="0c7db-171">The attached properties of the [Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) class provide access to a set of Microsoft OpenType typography properties.</span></span> <span data-ttu-id="0c7db-172">これらの添付プロパティは、TextBlock で設定することも、個々のインライン テキスト要素で設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-172">You can set these attached properties either on the TextBlock, or on individual inline text elements.</span></span> <span data-ttu-id="0c7db-173">次の例では、両方を示します。</span><span class="sxs-lookup"><span data-stu-id="0c7db-173">These examples show both.</span></span>
```xaml
<TextBlock Text="Hello, world!"
           Typography.Capitals="SmallCaps"
           Typography.StylisticSet4="True"/>
```

```csharp
TextBlock textBlock1 = new TextBlock();
textBlock1.Text = "Hello, world!";
Windows.UI.Xaml.Documents.Typography.SetCapitals(textBlock1, FontCapitals.SmallCaps);
Windows.UI.Xaml.Documents.Typography.SetStylisticSet4(textBlock1, true);
```

```xaml
<TextBlock>12 x <Run Typography.Fraction="Slashed">1/3</Run> = 4.</TextBlock>
```

## <a name="get-the-sample-code"></a><span data-ttu-id="0c7db-174">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="0c7db-174">Get the sample code</span></span>

- <span data-ttu-id="0c7db-175">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="0c7db-175">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="0c7db-176">関連記事</span><span class="sxs-lookup"><span data-stu-id="0c7db-176">Related articles</span></span>

- [<span data-ttu-id="0c7db-177">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="0c7db-177">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="0c7db-178">スペル チェックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="0c7db-178">Guidelines for spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="0c7db-179">検索の追加</span><span class="sxs-lookup"><span data-stu-id="0c7db-179">Adding search</span></span>](search.md)
- [<span data-ttu-id="0c7db-180">テキスト入力のガイドライン</span><span class="sxs-lookup"><span data-stu-id="0c7db-180">Guidelines for text input</span></span>](text-controls.md)
- [<span data-ttu-id="0c7db-181">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="0c7db-181">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="0c7db-182">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="0c7db-182">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="0c7db-183">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="0c7db-183">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
