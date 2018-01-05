---
author: mijacobs
description: "言語の視覚的な表現として、文字体裁の主な役割は明確であることです。 スタイルによってその目的が邪魔されてはなりません。 ただし、文字体裁にはレイアウト コンポーネントとしての重要な役割もあり、そのデザインの密度と複雑さに強い影響を与え、そのデザインのユーザー エクスペリエンスにも影響します。"
title: "文字体裁"
ms.assetid: ca35f78a-e4da-423d-9f5b-75896e0b8f82
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: bec416694e347a1432892f9dc591afdfe8548e61
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
---
# <a name="typography"></a><span data-ttu-id="cd903-106">文字体裁</span><span class="sxs-lookup"><span data-stu-id="cd903-106">Typography</span></span>

<span data-ttu-id="cd903-107">言語の視覚的な表現として、文字体裁の主な役割は明確であることです。</span><span class="sxs-lookup"><span data-stu-id="cd903-107">As the visual representation of language, typography’s main task is to be clear.</span></span> <span data-ttu-id="cd903-108">スタイルによってその目的が邪魔されてはなりません。</span><span class="sxs-lookup"><span data-stu-id="cd903-108">Its style should never get in the way of that goal.</span></span> <span data-ttu-id="cd903-109">ただし、文字体裁にはレイアウト コンポーネントとしての重要な役割もあり、そのデザインの密度と複雑さに強い影響を与え、そのデザインのユーザー エクスペリエンスにも影響します。</span><span class="sxs-lookup"><span data-stu-id="cd903-109">But typography also has an important role as a layout component—with a powerful effect on the density and complexity of the design—and on the user’s experience of that design.</span></span>

## <a name="typeface"></a><span data-ttu-id="cd903-110">書体</span><span class="sxs-lookup"><span data-stu-id="cd903-110">Typeface</span></span>

<span data-ttu-id="cd903-111">すべての Microsoft デジタル デザインで使う書体として Segoe UI が選択されました。</span><span class="sxs-lookup"><span data-stu-id="cd903-111">We’ve selected Segoe UI for use on all Microsoft digital designs.</span></span> <span data-ttu-id="cd903-112">Segoe UI には多くの文字が用意されており、さまざまなサイズとピクセル密度で最適な読みやすさが維持されるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="cd903-112">Segoe UI provides a wide range of characters and is designed to maintain optimal legibility across sizes and pixel densities.</span></span> <span data-ttu-id="cd903-113">システムのコンテンツを補完する、きれいで明るくオープンな美しさを備えています。</span><span class="sxs-lookup"><span data-stu-id="cd903-113">It offers a clean, light, and open aesthetic that complements the content of the system.</span></span>

![Segoe UI フォントのサンプル テキスト](images/segoe-sample.png)

## <a name="weights"></a><span data-ttu-id="cd903-115">太さ</span><span class="sxs-lookup"><span data-stu-id="cd903-115">Weights</span></span>

<span data-ttu-id="cd903-116">Microsoft では、シンプルさと効率性を考慮に入れて文字体裁に取り組んでいます。</span><span class="sxs-lookup"><span data-stu-id="cd903-116">We approach typography with an eye to simplicity and efficiency.</span></span> <span data-ttu-id="cd903-117">1 つの書体、最小限の太さとサイズ、明確な階層構造を使うことを選択しました。</span><span class="sxs-lookup"><span data-stu-id="cd903-117">We choose to use one typeface, a minimum of weights and sizes, and a clear hierarchy.</span></span> <span data-ttu-id="cd903-118">配置と位置合わせは、各言語の既定のスタイルに従います。</span><span class="sxs-lookup"><span data-stu-id="cd903-118">Positioning and alignment follow the default style for the given language.</span></span> <span data-ttu-id="cd903-119">英語では、文字が左から右、上から下へと進みます。</span><span class="sxs-lookup"><span data-stu-id="cd903-119">In English the sequence runs left to right, top to bottom.</span></span> <span data-ttu-id="cd903-120">テキストと画像の関係は、明確で直接的です。</span><span class="sxs-lookup"><span data-stu-id="cd903-120">Relationships between text and images are clear and straightforward.</span></span>

![サポートされるフォントの太さを示します。](images/weights.png)

## <a name="line-spacing"></a><span data-ttu-id="cd903-123">行間</span><span class="sxs-lookup"><span data-stu-id="cd903-123">Line spacing</span></span>

![行間 125% の例](images/line-spacing.png)

<span data-ttu-id="cd903-125">行間はフォント サイズの 125% で計算し、必要に応じて 4 の倍数の近似値に丸めてください。</span><span class="sxs-lookup"><span data-stu-id="cd903-125">Line spacing should be calculated at 125% of the font size, rounding to the closest multiple of four when necessary.</span></span> <span data-ttu-id="cd903-126">たとえば 15 ピクセルの Segoe UI の場合、15 ピクセルの 125% は 18.75 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="cd903-126">For example with 15px Segoe UI, 125% of 15px is 18.75px.</span></span> <span data-ttu-id="cd903-127">4 ピクセル グリッドが維持されるように、行の高さを 20 ピクセルに切り上げて設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cd903-127">We recommend rounding up and setting line height to 20px to stay on the 4px grid.</span></span> <span data-ttu-id="cd903-128">これにより、読みやすくなり、発音区分符のスペースが十分確保されます。</span><span class="sxs-lookup"><span data-stu-id="cd903-128">This ensures a good reading experience and adequate space for diacritical marks.</span></span> <span data-ttu-id="cd903-129">具体的な例については、以下の「書体見本」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cd903-129">See the Type ramp section below for specific examples.</span></span>

<span data-ttu-id="cd903-130">小さい書体の上に大きい書体を重ねる場合、大きい書体の最後のベースラインから小さい書体の最初のベースラインまでの距離が、大きい書体の行の高さと等しくなるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="cd903-130">When stacking larger type on top of smaller type, the distance from the last baseline of the larger type to the first baseline of the smaller type should be equal to the larger type’s line height.</span></span>

![小さい書体に対する大きい書体の重なり方を示す図](images/line-height-stacking.png)

<span data-ttu-id="cd903-132">XAML では、これは 2 つの [TextBlocks](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を重ね、適切な余白を設定することで実現できます。</span><span class="sxs-lookup"><span data-stu-id="cd903-132">In XAML, this is accomplished by stacking two [TextBlocks](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) and setting the appropriate margin.</span></span>

```xaml
<StackPanel Width="200">
    <!-- Setting a bottom margin of 3px on the header
         puts the baseline of the body text exactly 24px
         below the baseline of the header. 24px is the
         recommended line height for a 20px font size,
         which is what’s set in SubtitleTextBlockStyle.
         The bottom margin will be different for
         different font size pairings. -->
    <TextBlock
        Style="{StaticResource SubtitleTextBlockStyle}"
        Margin="0,0,0,3"
        Text="Header text" />
    <TextBlock
        Style="{StaticResource BodyTextBlockStyle}"
        TextWrapping="Wrap"
        Text="This line of text should be positioned where the above header would have wrapped." />
</StackPanel>
```


<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<h2><span data-ttu-id="cd903-133">カーニングとトラッキング</span><span class="sxs-lookup"><span data-stu-id="cd903-133">Kerning and tracking</span></span></h2>

<span data-ttu-id="cd903-134">Segoe は、ソフトでわかりやすい外観をした人間的な書体であり、手書き文字に基づく自然でオープンな形をしています。</span><span class="sxs-lookup"><span data-stu-id="cd903-134">Segoe is a humanist typeface, with a soft, friendly appearance, it has organic, open forms based on handwritten text.</span></span> <span data-ttu-id="cd903-135">できるだけ読みやすくし、人間的な一貫性を保つため、カーニングとトラッキングの設定を特定の値にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cd903-135">To ensure optimum legibility and maintain its humanist integrity, the kerning and tracking settings must have specific values.</span></span>

<span data-ttu-id="cd903-136">カーニングを "メトリック" に設定し、トラッキングを "0" に設定してください。</span><span class="sxs-lookup"><span data-stu-id="cd903-136">Kerning should be set to “metrics” and tracking should be set to “0”.</span></span>
  </div>
  <div class="side-by-side-content-right">
<h2><span data-ttu-id="cd903-137">単語や文字の間隔</span><span class="sxs-lookup"><span data-stu-id="cd903-137">Word and letter spacing</span></span></h2>

<span data-ttu-id="cd903-138">カーニングやトラッキングと同様、できるだけ読みやすくし、人間的な一貫性を保つため、単語の間隔と文字間隔でも特定の設定を使います。</span><span class="sxs-lookup"><span data-stu-id="cd903-138">Similar to kerning and tracking, word spacing and letter spacing use specific settings to ensure optimum legibility and humanist integrity.</span></span>

<span data-ttu-id="cd903-139">既定では、単語の間隔は常に 100% であり、文字間隔は "0" に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cd903-139">Word spacing by default is always 100% and letter spacing should be set to “0”.</span></span>
  </div>
</div>
</div>
<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
![カーニングとトラッキングの差](images/kerning-tracking.png)  
  </div>
  <div class="side-by-side-content-right">
![単語の間隔と文字の間隔の差](images/word-letter.png) 
  </div>
</div>
</div>


>[!NOTE]
><span data-ttu-id="cd903-142">XAML テキスト コントロールでは、[Typogrphy.Kerning](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.typography.kerning.aspx) を使ってカーニングを制御し、[FontStretch](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_FontStretch) を使ってトラッキングを制御します。</span><span class="sxs-lookup"><span data-stu-id="cd903-142">In a XAML text control use [Typogrphy.Kerning](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.typography.kerning.aspx) to control kerning and [FontStretch](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_FontStretch) to control tracking.</span></span> <span data-ttu-id="cd903-143">既定では、Typography.Kerning は "true" に設定され、FontStretch は推奨値である" Normal" に設定されます。</span><span class="sxs-lookup"><span data-stu-id="cd903-143">By default Typography.Kerning is set to “true” and FontStretch is set to “Normal”, which are the recommended values.</span></span>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<h2><span data-ttu-id="cd903-144">配置</span><span class="sxs-lookup"><span data-stu-id="cd903-144">Alignment</span></span></h2>

<span data-ttu-id="cd903-145">通常は、視覚要素と書体の列を左揃えにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cd903-145">Generally, we recommend that visual elements and columns of type be left-aligned.</span></span> <span data-ttu-id="cd903-146">ほとんどの場合、このような左揃えおよび右不揃いのアプローチによって、コンテンツが一貫したアンカー設定となり、均一なレイアウトになります。</span><span class="sxs-lookup"><span data-stu-id="cd903-146">In most instances, this flush-left and ragged-right approach provides consistent anchoring of the content and a uniform layout.</span></span> 
  </div>
  <div class="side-by-side-content-right">
<h2><span data-ttu-id="cd903-147">行の末尾</span><span class="sxs-lookup"><span data-stu-id="cd903-147">Line endings</span></span></h2>

<span data-ttu-id="cd903-148">文字体裁が左揃えおよび右不揃いで配置されていない場合、行の末尾が均等になるようにし、ハイフンを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="cd903-148">When typography is not positioned as flush left and ragged right, try to ensure even line endings and avoid hyphenation.</span></span>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
![左揃えテキストを示します。](images/alignment.png)  
  </div>
  <div class="side-by-side-content-right">
![均等な行の末尾を示します。](images/line-endings.png) 
  </div>
</div>
</div>


## <a name="paragraphs"></a><span data-ttu-id="cd903-151">段落</span><span class="sxs-lookup"><span data-stu-id="cd903-151">Paragraphs</span></span>

<span data-ttu-id="cd903-152">列の端を揃えるため、インデントなしの行をスキップすることで段落を示してください。</span><span class="sxs-lookup"><span data-stu-id="cd903-152">To provide aligned column edges, paragraphs should be indicated by skipping a line without indentation.</span></span>

![段落間のスペースの行全体を示します。](images/paragraphs.png)

## <a name="character-count"></a><span data-ttu-id="cd903-154">文字カウント</span><span class="sxs-lookup"><span data-stu-id="cd903-154">Character count</span></span>

<span data-ttu-id="cd903-155">行が短すぎると、目を左から右へと頻繁に動かさなければならなくなり、読者のリズムが崩れます。</span><span class="sxs-lookup"><span data-stu-id="cd903-155">If a line is too short, the eye will have to travel left and right too often, breaking the reader’s rhythm.</span></span> <span data-ttu-id="cd903-156">可能であれば、1 行あたり 50 ~ 60 文字にすると最も読みやすくなります。</span><span class="sxs-lookup"><span data-stu-id="cd903-156">If possible, 50–60 letters per line is best for ease of reading.</span></span>

<span data-ttu-id="cd903-157">Segoe UI には多くの文字が用意されており、サイズが小さくても大きくても、またはピクセル密度が低くても高くても最適な読みやすさが維持されるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="cd903-157">Segoe provides a wide range of characters and is designed to maintain optimal legibility in both small and large sizes as well as low and high pixel densities.</span></span> <span data-ttu-id="cd903-158">テキスト列の行の文字数を最適にすると、アプリケーションでの読みやすさが確保されます。</span><span class="sxs-lookup"><span data-stu-id="cd903-158">Using the optimal number of letters in a text column line ensures good legibility in an application.</span></span>

<span data-ttu-id="cd903-159">行が長すぎると目に負担がかかり、ユーザーが混乱する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cd903-159">Lines that are too long will strain the eye and may disorient the user.</span></span> <span data-ttu-id="cd903-160">行が短すぎると読者が目を頻繁に動かさなければならず、疲れる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cd903-160">Lines that are too short force the reader’s eye to travel too much and can cause fatigue.</span></span>

![行の長さが異なる 3 つの段落を示します。](images/character-count.png)

## <a name="hanging-text-alignment"></a><span data-ttu-id="cd903-162">ぶら下げテキストの配置</span><span class="sxs-lookup"><span data-stu-id="cd903-162">Hanging text alignment</span></span>

<span data-ttu-id="cd903-163">横方向に配置されたテキスト付きアイコンは、アイコンのサイズとテキストの量に応じてさまざまな方法で処理することができます。</span><span class="sxs-lookup"><span data-stu-id="cd903-163">The horizontal alignment of icons with text can be handled in a number of ways depending on the size of the icon and the amount of text.</span></span> <span data-ttu-id="cd903-164">1 行であっても複数行であってもテキストがアイコンの高さに収まる場合、テキストを上下に中央揃えにしてください。</span><span class="sxs-lookup"><span data-stu-id="cd903-164">When the text, either single or multiple lines, fits within the height of the icon, the text should be vertically centered.</span></span>

<span data-ttu-id="cd903-165">テキストの高さがアイコンの高さより高い場合、テキストの先頭行を縦方向に揃え、残りのテキストが自然に下に流れるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="cd903-165">Once the height of the text extends beyond the height of the icon, the first line of text should align vertically and the additional text should flow on naturally below.</span></span> <span data-ttu-id="cd903-166">大文字、アセンダー、ディセンダーの高さが通常よりも大きい文字を使うときは、同じ配置ガイダンスが守られるように注意してください。</span><span class="sxs-lookup"><span data-stu-id="cd903-166">When using characters with larger cap, ascender and descender heights, care should be taken to observe the same alignment guidance.</span></span>

![アイコンとテキストの組み合わせの例](images/hanging-text-alignment.png)

>[!NOTE]
><span data-ttu-id="cd903-168">XAML の [TextBlock.TextLineBounds](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.textlinebounds.aspx) プロパティを使うと、大文字の高さやベースライン フォント メトリックにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="cd903-168">XAML’s [TextBlock.TextLineBounds](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.textlinebounds.aspx) property provides access to the cap height and baseline font metrics.</span></span> <span data-ttu-id="cd903-169">このプロパティは、書体を視覚的に上下中央に配置したり、上揃えに配置する場合に利用できます。</span><span class="sxs-lookup"><span data-stu-id="cd903-169">It can be used to visually vertically center or top-align type.</span></span>

## <a name="clipping-and-ellipses"></a><span data-ttu-id="cd903-170">クリッピングと省略記号</span><span class="sxs-lookup"><span data-stu-id="cd903-170">Clipping and ellipses</span></span>

<span data-ttu-id="cd903-171">既定でクリップ - 赤線により指定されている場合除き、テキストが折り返されることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="cd903-171">Clip by default—assume that text will wrap unless the redline specifies otherwise.</span></span> <span data-ttu-id="cd903-172">折り返しのないテキストを使う場合、省略記号ではなくクリッピングをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cd903-172">When using non-wrapping text, we recommend clipping rather than using ellipses.</span></span> <span data-ttu-id="cd903-173">クリッピングは、コンテナーの端、デバイスの端、スクロール バーの端などで行われます。</span><span class="sxs-lookup"><span data-stu-id="cd903-173">Clipping can occur at the edge of the container, at the edge of the device, at the edge of a scrollbar, etc.</span></span>

<span data-ttu-id="cd903-174">例外: 明確に定義されていないコンテナーの場合 (はっきりした背景色がないなど)、折り返しのないテキストに赤線を付けて省略記号 "..." を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="cd903-174">Exceptions—for containers which are not well-defined (e.g. no differentiating background color), then non-wrapping text can be redlined to use the ellipse ”…”.</span></span>

![いくつかのテキスト クリッピングがあるデバイス フレームを示します。](images/clipping.png)

## <a name="type-ramp"></a><span data-ttu-id="cd903-176">書体見本</span><span class="sxs-lookup"><span data-stu-id="cd903-176">Type ramp</span></span>
<span data-ttu-id="cd903-177">書体見本 (type ramp) は、ヘッドラインからの本文までの重要なデザインの関係を確立し、異なるレベル間の明快でわかりやすい階層を保証します。</span><span class="sxs-lookup"><span data-stu-id="cd903-177">The type ramp establishes a crucial design relationship from headlines to body text and ensures a clear and understandable hierarchy between the different levels.</span></span> <span data-ttu-id="cd903-178">この階層により、ユーザーが書面によるコミュニケーションを通じて簡単にナビゲートできる構造が作成されます。</span><span class="sxs-lookup"><span data-stu-id="cd903-178">This hierarchy builds a structure which enables users to easily navigate through written communication.</span></span>

<div class="uwpd-image-with-caption">
    <img src="images/type-ramp.png" alt="Shows the type ramp" />
    <div><span data-ttu-id="cd903-179">すべてのサイズは有効ピクセル単位です。</span><span class="sxs-lookup"><span data-stu-id="cd903-179">All sizes are in effective pixels.</span></span> <span data-ttu-id="cd903-180">詳しくは、「[UWP アプリ設計の概要](../basics/design-and-ui-intro.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cd903-180">For more details, see [Intro to UWP app design](../basics/design-and-ui-intro.md).</span></span></div>
</div>

>[!NOTE]
><span data-ttu-id="cd903-181">書体見本のほとんどのレベルは、XAML の[静的リソース](https://msdn.microsoft.com/en-us/library/windows/apps/Mt187274.aspx#the_xaml_type_ramp)として利用できます。これらのリソースは、`*TextBlockStyle` 名前付け規則に従っています (例: `HeaderTextBlockStyle`)。</span><span class="sxs-lookup"><span data-stu-id="cd903-181">Most levels of the ramp are available as XAML [static resources](https://msdn.microsoft.com/en-us/library/windows/apps/Mt187274.aspx#the_xaml_type_ramp) that follow the `*TextBlockStyle` naming convention (ex: `HeaderTextBlockStyle`).</span></span>


<!--
<div class="microsoft-internal-note">
SubtitleAlt, BaseAlt, and CaptionAlt are not currently included. You can create the styles in your own app following the code snippets in the above link. Also note that XAML does not currently match the line height exactly.
</div>
-->


## <a name="primary-and-secondary-text"></a><span data-ttu-id="cd903-182">プライマリ テキストとセカンダリ テキスト</span><span class="sxs-lookup"><span data-stu-id="cd903-182">Primary and secondary text</span></span>

<span data-ttu-id="cd903-183">書体見本を超えて追加の階層を作成するには、セカンダリ テキストの不透明度を 60% に設定します。</span><span class="sxs-lookup"><span data-stu-id="cd903-183">To create additional hierarchy beyond the type ramp, set secondary text to 60% opacity.</span></span> <span data-ttu-id="cd903-184">[テーマ カラー パレット](color.md#themes) で、BaseMedium を使います。</span><span class="sxs-lookup"><span data-stu-id="cd903-184">In the [theming color palette](color.md#themes), you would use BaseMedium.</span></span> <span data-ttu-id="cd903-185">プライマリ テキストは、常に不透明度を 100% にするか、BaseHigh にしてください。</span><span class="sxs-lookup"><span data-stu-id="cd903-185">Primary text should always be at 100% opacity, or BaseHigh.</span></span>

<!-- Need new images
![Two phone apps using SubtitleAlt](images/type-ramp-example-2.png)
Recommended use of SubtitleAlt. Also note the primary and secondary text usage in list items.

![Two phone apps using CaptionAlt](images/type-ramp-example-1.png)
Recommended use of CaptionAlt.
-->

## <a name="all-caps-titles"></a><span data-ttu-id="cd903-186">すべて大文字のタイトル</span><span class="sxs-lookup"><span data-stu-id="cd903-186">All caps titles</span></span>

<span data-ttu-id="cd903-187">特定のページ タイトルでは、階層に新たな次元を加えるため、すべて大文字にしてください。</span><span class="sxs-lookup"><span data-stu-id="cd903-187">Certain page titles should be in ALL CAPS to add yet another dimension of hierarchy.</span></span> <span data-ttu-id="cd903-188">これらのタイトルでは、BaseAlt を使い、文字間隔を em の 1,000 分の 75 にしてください。</span><span class="sxs-lookup"><span data-stu-id="cd903-188">These titles should use BaseAlt with the character spacing set to 75 thousandths of an em.</span></span> <span data-ttu-id="cd903-189">この処理は、アプリのナビゲーションに使っても役立つことがあります。</span><span class="sxs-lookup"><span data-stu-id="cd903-189">This treatment may also be used to help with app navigation.</span></span>

<span data-ttu-id="cd903-190">ただし、言語によっては固有名詞を大文字にすると意味が変わるため、名前やユーザー入力に基づくページ タイトルはすべて大文字に変換*しない*でください。</span><span class="sxs-lookup"><span data-stu-id="cd903-190">However, proper names change their meaning when capitalized in certain languages, so any page titles based on names or user input should *not* be converted to all caps.</span></span>


<!-- Need new images
![Shows several apps where they should and should not use all caps](images/all-caps.png)
Green shows where all caps should be used. Red shows where it should not.
-->

## <a name="dos-and-donts"></a><span data-ttu-id="cd903-191">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="cd903-191">Do’s and don’ts</span></span>
* <span data-ttu-id="cd903-192">ほとんどのテキストには Body を使う</span><span class="sxs-lookup"><span data-stu-id="cd903-192">Use Body for most text</span></span>
* <span data-ttu-id="cd903-193">スペースに制約がある場合はタイトルに Base を使う</span><span class="sxs-lookup"><span data-stu-id="cd903-193">Use Base for titles when space is constrained</span></span>
* <span data-ttu-id="cd903-194">SubtitleAlt を組み込んで、最上位のコンテンツを強調することでコントラストと階層を作る</span><span class="sxs-lookup"><span data-stu-id="cd903-194">Incorporate SubtitleAlt to create contrast and hierarchy by emphasizing top level content</span></span>
* <span data-ttu-id="cd903-195">長い文字列やプライマリ操作には Caption を使わない</span><span class="sxs-lookup"><span data-stu-id="cd903-195">Don’t use Caption for long strings or any primary action</span></span>
* <span data-ttu-id="cd903-196">テキストを折り返す必要がある場合は Header や Subheader を使わない</span><span class="sxs-lookup"><span data-stu-id="cd903-196">Don’t use Header or Subheader if text needs to wrap</span></span>
* <span data-ttu-id="cd903-197">同じページで Subtitle と SubtitleAlt を組み合わせない</span><span class="sxs-lookup"><span data-stu-id="cd903-197">Don’t combine Subtitle and SubtitleAlt on the same page</span></span>


## <a name="related-articles"></a><span data-ttu-id="cd903-198">関連記事</span><span class="sxs-lookup"><span data-stu-id="cd903-198">Related articles</span></span>

* [<span data-ttu-id="cd903-199">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="cd903-199">Text controls</span></span>](../controls-and-patterns/text-controls.md)
* [<span data-ttu-id="cd903-200">フォント</span><span class="sxs-lookup"><span data-stu-id="cd903-200">Fonts</span></span>](../style/fonts.md)
* [<span data-ttu-id="cd903-201">Segoe MDL2 アイコン</span><span class="sxs-lookup"><span data-stu-id="cd903-201">Segoe MDL2 icons</span></span>](segoe-ui-symbol-font.md)
