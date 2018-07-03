---
author: mijacobs
description: コンテンツをユーザーに理解しやすくするための、アプリにおける文字体裁の使用方法について説明します。
title: UWP アプリの文字体裁
ms.author: mijacobs
ms.date: 04/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 505167775b61908be7f47068dbf3221c293f6112
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1843372"
---
# <a name="typography"></a><span data-ttu-id="5bce6-104">文字体裁</span><span class="sxs-lookup"><span data-stu-id="5bce6-104">Typography</span></span>

![ヒーロー イメージ](images/header-typography.svg)

<span data-ttu-id="5bce6-106">言語の視覚的表現である文字体裁において、何よりも重要な役割は情報を伝達することです。</span><span class="sxs-lookup"><span data-stu-id="5bce6-106">As the visual representation of language, typography’s main task is to communicate information.</span></span> <span data-ttu-id="5bce6-107">スタイルは、その目的を阻害するものであってはなりません。</span><span class="sxs-lookup"><span data-stu-id="5bce6-107">Its style should never get in the way of that goal.</span></span> <span data-ttu-id="5bce6-108">この記事では、ユーザーが簡単かつ効率的にコンテンツを理解できるように、UWP アプリで文字体裁のスタイルを決定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5bce6-108">In this article, we'll discuss how to style typography in your UWP app to help users understand content easily and efficiently.</span></span>

## <a name="font"></a><span data-ttu-id="5bce6-109">フォント</span><span class="sxs-lookup"><span data-stu-id="5bce6-109">Font</span></span>

<span data-ttu-id="5bce6-110">アプリ全体で同じフォントを使用してください。UWP アプリの既定のフォントである **Segoe UI** に統一することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5bce6-110">You should use one font throughout your app's UI, and we recommend sticking with the default font for UWP apps, **Segoe UI**.</span></span> <span data-ttu-id="5bce6-111">このフォントは、常に最適な読みやすさが維持されるサイズとピクセル密度を備え、システムのコンテンツを清潔で軽快、かつオープンに美しく表示します。</span><span class="sxs-lookup"><span data-stu-id="5bce6-111">It's designed to maintain optimal legibility across sizes and pixel densities and offers a clean, light, and open aesthetic that complements the content of the system.</span></span>

![Segoe UI フォントのサンプル テキスト](images/type/segoe-sample.svg)

<span data-ttu-id="5bce6-113">アプリで英語以外の言語を表示する場合、または異なるフォントを選択する場合は、「[言語](#Languages)」と「[フォント](#Fonts)」のセクションで、弊社が UWP アプリ向けに推奨するフォントを確認してください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-113">To display non-English languages or to select a different font for your app, please see [Languages](#Languages) and [Fonts](#Fonts) for our recommended fonts for UWP apps.</span></span>

<span data-ttu-id="5bce6-114">:::row::: :::column::: ![推奨](images/do.svg) UI のフォントを統一してください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-114">:::row::: :::column::: ![do](images/do.svg) Pick one font for your UI.</span></span>
<span data-ttu-id="5bce6-115">:::column-end::: :::column::: ![非推奨](images/dont.svg) 複数のフォントを混在させないでください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-115">:::column-end::: :::column::: ![don't](images/dont.svg) Don't mix multiple fonts.</span></span>
<span data-ttu-id="5bce6-116">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="5bce6-116">:::column-end::: :::row-end:::</span></span>

## <a name="size-and-scaling"></a><span data-ttu-id="5bce6-117">サイズとスケーリング</span><span class="sxs-lookup"><span data-stu-id="5bce6-117">Size and scaling</span></span>

<span data-ttu-id="5bce6-118">UWP アプリのフォント サイズは、すべてのデバイスで自動的に拡大縮小します。</span><span class="sxs-lookup"><span data-stu-id="5bce6-118">Font sizes in UWP apps automatically scale on all devices.</span></span> <span data-ttu-id="5bce6-119">スケーリング アルゴリズムによって、10 フィート離れた Surface Hub 上の 24 ピクセル フォントが、目の前にある 5 インチ サイズの電話の画面に表示された 24 ピクセル フォントと同じ読みやすさで表示されます。</span><span class="sxs-lookup"><span data-stu-id="5bce6-119">The scaling algorithm ensures that a 24 px font on Surface Hub 10 feet away is just as legible as a 24 px font on 5" phone that's a few inches away.</span></span>

![さまざまなデバイスの視聴距離](images/type/scaling-chart.svg)

<span data-ttu-id="5bce6-121">スケーリング システムのしくみを踏まえ、実際の物理ピクセルではなく、有効ピクセルに基づいてデザインしてください。異なる画面サイズや解像度に応じてフォント サイズを変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5bce6-121">Because of how the scaling system works, you're designing in effective pixels, not actual physical pixels, and you shouldn't have to alter font sizes for different screens sizes or resolutions.</span></span>

<span data-ttu-id="5bce6-122">:::row::: :::column::: ![推奨](images/do.svg) UWP の[書体見本](#type-ramp)に従います。</span><span class="sxs-lookup"><span data-stu-id="5bce6-122">:::row::: :::column::: ![do](images/do.svg) Follow the UWP [type ramp](#type-ramp) sizing.</span></span>
<span data-ttu-id="5bce6-123">:::column-end::: :::column::: ![非推奨](images/dont.svg) 12 ピクセルよりも小さいフォント サイズを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-123">:::column-end::: :::column::: ![don't](images/dont.svg) Use a font size smaller than 12 px.</span></span>
<span data-ttu-id="5bce6-124">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="5bce6-124">:::column-end::: :::row-end:::</span></span>

## <a name="hierarchy"></a><span data-ttu-id="5bce6-125">階層</span><span class="sxs-lookup"><span data-stu-id="5bce6-125">Hierarchy</span></span>

<span data-ttu-id="5bce6-126">:::row::: :::column::: ユーザーはページを斜め読みするとき、視覚的な階層を手掛かりにしています。見出しは内容を要約し、本文は詳細を説明するものと想定されます。</span><span class="sxs-lookup"><span data-stu-id="5bce6-126">:::row::: :::column::: Users rely on visual hierarchy when scanning a page: headers summarize content, and body text provides more detail.</span></span> <span data-ttu-id="5bce6-127">アプリでわかりやすい視覚的階層を作成するためには、UWP 書体見本に従ってください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-127">To create a clear visual hierarchy in your app, follow the UWP type ramp.</span></span>
<span data-ttu-id="5bce6-128">:::column-end::: :::column::: ![テキスト ブロックのスタイル](images/type/type-hierarchy.svg) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="5bce6-128">:::column-end::: :::column::: ![text block styles](images/type/type-hierarchy.svg) :::column-end::: :::row-end:::</span></span>

### <a name="type-ramp"></a><span data-ttu-id="5bce6-129">書体見本</span><span class="sxs-lookup"><span data-stu-id="5bce6-129">Type ramp</span></span>

<span data-ttu-id="5bce6-130">UWP 書体見本は、ユーザーがコンテンツを読みやすいように、ページ上の各書体スタイル間の重要な関係を定めたものです。</span><span class="sxs-lookup"><span data-stu-id="5bce6-130">The UWP type ramp establishes crucial relationships between the type styles on a page, helping users read content easily.</span></span> <span data-ttu-id="5bce6-131">すべてのサイズは有効ピクセル単位で示され、UWP アプリが動作するデバイスを問わず、常に最適に表示されるように調整されています。</span><span class="sxs-lookup"><span data-stu-id="5bce6-131">All sizes are in effective pixels and are optimized for UWP apps running on all devices.</span></span>

![書体見本](images/type/type-ramp.svg)

### <a name="using-the-type-ramp"></a><span data-ttu-id="5bce6-133">書体見本の使用</span><span class="sxs-lookup"><span data-stu-id="5bce6-133">Using the type ramp</span></span>

<span data-ttu-id="5bce6-134">:::row::: :::column::: 各レベルの書体見本は、XAML の[静的リソース](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp)としてアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="5bce6-134">:::row::: :::column::: You can access levels of the type ramp as XAML [static resources](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp).</span></span> <span data-ttu-id="5bce6-135">これらのスタイルは、`*TextBlockStyle` 名前付け規則に従っています。</span><span class="sxs-lookup"><span data-stu-id="5bce6-135">The styles follow the `*TextBlockStyle` naming convention.</span></span>
<span data-ttu-id="5bce6-136">:::column-end::: :::column::: ![テキスト ブロックのスタイル](images/type/text-block-type-ramp.svg) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="5bce6-136">:::column-end::: :::column::: ![text block styles](images/type/text-block-type-ramp.svg) :::column-end::: :::row-end:::</span></span>

```XAML
<TextBlock Text="Header" Style="{StaticResource HeaderTextBlockStyle}"/>
<TextBlock Text="SubHeader" Style="{StaticResource SubheaderTextBlockStyle}"/>
<TextBlock Text="Title" Style="{StaticResource TitleTextBlockStyle}"/>
<TextBlock Text="SubTitle" Style="{StaticResource SubtitleTextBlockStyle}"/>
<TextBlock Text="Base" Style="{StaticResource BaseTextBlockStyle}"/>
<TextBlock Text="Body" Style="{StaticResource BodyTextBlockStyle}"/>
<TextBlock Text="Caption" Style="{StaticResource CaptionTextBlockStyle}"/>
```

<span data-ttu-id="5bce6-137">:::row::: :::column::: ![推奨](images/do.svg) ほとんどのテキストは、"Body" スタイルを使用して表示してください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-137">:::row::: :::column::: ![do](images/do.svg) Use "Body" for most text.</span></span>

        Use "Base" for titles when space is constrained.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Use "Caption" for primary action or any long strings.

        Use "Header" or "Subheader" if text needs to wrap.
    :::column-end:::
<span data-ttu-id="5bce6-138">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="5bce6-138">:::row-end:::</span></span>

## <a name="alignment"></a><span data-ttu-id="5bce6-139">配置</span><span class="sxs-lookup"><span data-stu-id="5bce6-139">Alignment</span></span>

<span data-ttu-id="5bce6-140">既定の [TextAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.textalignment) (行揃え) は Left (左揃え) です。ほとんどの場合、左揃え、右不揃いの形式でコンテンツを一貫してアンカー設定することで、均一なレイアウトが実現します。</span><span class="sxs-lookup"><span data-stu-id="5bce6-140">The default [TextAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.textalignment) is Left, and in most instances, flush-left and ragged right provides consistent anchoring of the content and a uniform layout.</span></span> <span data-ttu-id="5bce6-141">RTL 言語については、[グローバリゼーションをサポートするためのレイアウトとフォントの調整に関するページ](../globalizing/adjust-layout-and-fonts--and-support-rtl.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-141">For RTL languages, see [Adjusting layout and fonts to support globalization](../globalizing/adjust-layout-and-fonts--and-support-rtl.md).</span></span>

![左揃えテキストを示します。](images/type/alignment.svg)

```xaml
<TextBlock TextAlignment="Left">
```

## <a name="character-count"></a><span data-ttu-id="5bce6-143">文字カウント</span><span class="sxs-lookup"><span data-stu-id="5bce6-143">Character count</span></span>

<span data-ttu-id="5bce6-144">:::row::: :::column::: ![推奨](images/do.svg) 読みやすさを確保するため、1 行当たり 50 ～ 60 文字の文字カウントを維持します。</span><span class="sxs-lookup"><span data-stu-id="5bce6-144">:::row::: :::column::: ![do](images/do.svg) Keep to 50–60 letters per line for ease of reading.</span></span>
<span data-ttu-id="5bce6-145">:::column-end::: :::column::: ![非推奨](images/dont.svg) 1 行当たりの文字カウントが 20 文字を下回るか 60 文字を超えると読みにくくなります。</span><span class="sxs-lookup"><span data-stu-id="5bce6-145">:::column-end::: :::column::: ![don't](images/dont.svg) Less than 20 characters or more than 60 characters per line is difficult to read.</span></span>
<span data-ttu-id="5bce6-146">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="5bce6-146">:::column-end::: :::row-end:::</span></span>

## <a name="clipping-and-ellipses"></a><span data-ttu-id="5bce6-147">クリッピングと省略記号</span><span class="sxs-lookup"><span data-stu-id="5bce6-147">Clipping and ellipses</span></span>

<span data-ttu-id="5bce6-148">テキストの量が利用可能なスペースを超えている場合は、テキストをクリッピングすることが推奨されます。クリッピングは、ほとんどの [UWP テキスト コントロール](../controls-and-patterns/text-controls.md) で既定の処理です。</span><span class="sxs-lookup"><span data-stu-id="5bce6-148">When the amount of text extends beyond the space available, we recommend clipping text, which is the default behavior of most [UWP text controls](../controls-and-patterns/text-controls.md).</span></span>

![いくつかのテキストがクリッピングされているデバイス フレームを示します。](images/type/clipping.svg)

```xaml
<TextBlock TextWrapping="WrapWholeWords" TextTrimming="Clip"/>
```

<span data-ttu-id="5bce6-150">:::row::: :::column::: ![推奨](images/do.svg) テキストをクリップし、複数行を使用できる場合は、行を折り返します。</span><span class="sxs-lookup"><span data-stu-id="5bce6-150">:::row::: :::column::: ![do](images/do.svg) Clip text, and wrap if multiple lines are enabled.</span></span>
<span data-ttu-id="5bce6-151">:::column-end::: :::column::: ![非推奨](images/dont.svg) すっきりと表示するため、省略記号は使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-151">:::column-end::: :::column::: ![don't](images/dont.svg) Use ellipses to avoid visual clutter.</span></span>
<span data-ttu-id="5bce6-152">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="5bce6-152">:::column-end::: :::row-end:::</span></span>

<span data-ttu-id="5bce6-153">**注**: 表示領域が不明確な場合 (領域が異なる背景色によって明確に表示されていない場合など)、または詳細テキストへのリンクがある場合は、省略記号を使用します。</span><span class="sxs-lookup"><span data-stu-id="5bce6-153">**Note**: If containers are not well-defined (e.g. no differentiating background color), or when there is a link to see more text, then use ellipses.</span></span>

## <a name="languages"></a><span data-ttu-id="5bce6-154">言語</span><span class="sxs-lookup"><span data-stu-id="5bce6-154">Languages</span></span> 

<span data-ttu-id="5bce6-155">Segoe UI は、英語、ヨーロッパの各言語、ギリシャ語、ヘブライ語、アルメニア語、ジョージア語、アラビア語に対応した弊社のフォントです。</span><span class="sxs-lookup"><span data-stu-id="5bce6-155">Segoe UI is our font for English, European languages, Greek, Hebrew, Armenian, Georgian, and Arabic.</span></span> <span data-ttu-id="5bce6-156">他の言語については、以下の推奨事項を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-156">For other languages, see the following recommendations.</span></span>

### <a name="globalizinglocalizing-fonts"></a><span data-ttu-id="5bce6-157">フォントのグローバリゼーション/ローカライズ</span><span class="sxs-lookup"><span data-stu-id="5bce6-157">Globalizing/localizing fonts</span></span>

<span data-ttu-id="5bce6-158">特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[LanguageFont フォント マッピング API](https://docs.microsoft.com/uwp/api/Windows.Globalization.Fonts.LanguageFont) を使ってください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-158">Use the [LanguageFont font-mapping APIs](https://docs.microsoft.com/uwp/api/Windows.Globalization.Fonts.LanguageFont) for programmatic access to the recommended font family, size, weight, and style for a particular language.</span></span> <span data-ttu-id="5bce6-159">LanguageFont オブジェクトを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="5bce6-159">The LanguageFont object provides access to the correct font info for various categories of content including UI headers, notifications, body text, and user-editable document body fonts.</span></span> <span data-ttu-id="5bce6-160">詳しくは、[グローバリゼーションをサポートするためのレイアウトとフォントの調整に関するページ](../globalizing/adjust-layout-and-fonts--and-support-rtl.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-160">For more info, see [Adjusting layout and fonts to support globalization](../globalizing/adjust-layout-and-fonts--and-support-rtl.md).</span></span>

### <a name="fonts-for-non-latin-languages"></a><span data-ttu-id="5bce6-161">ラテン語以外の言語用のフォント</span><span class="sxs-lookup"><span data-stu-id="5bce6-161">Fonts for non-Latin languages</span></span>

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5bce6-162">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="5bce6-162">Font-family</span></span></th>
<th align="left"><span data-ttu-id="5bce6-163">スタイル</span><span class="sxs-lookup"><span data-stu-id="5bce6-163">Styles</span></span></th>
<th align="left"><span data-ttu-id="5bce6-164">コメント</span><span class="sxs-lookup"><span data-stu-id="5bce6-164">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="font-family: Embrima;"><span data-ttu-id="5bce6-165">Ebrima</span><span class="sxs-lookup"><span data-stu-id="5bce6-165">Ebrima</span></span></td>
<td align="left"><span data-ttu-id="5bce6-166">標準、太字</span><span class="sxs-lookup"><span data-stu-id="5bce6-166">Regular, Bold</span></span></td>
<td align="left"><span data-ttu-id="5bce6-167">アフリカのスクリプト (エチオピア文字、ンコ文字、オスマニア文字、ティフィナグ文字、ヴァイ文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-167">User-interface font for African scripts (Ethiopic, N'Ko, Osmanya, Tifinagh, Vai).</span></span></td>
</tr>
<tr class="even">
<td style="font-family: Gadugi;"><span data-ttu-id="5bce6-168">Gadugi</span><span class="sxs-lookup"><span data-stu-id="5bce6-168">Gadugi</span></span></td>
<td align="left"><span data-ttu-id="5bce6-169">標準、太字</span><span class="sxs-lookup"><span data-stu-id="5bce6-169">Regular, Bold</span></span></td>
<td align="left"><span data-ttu-id="5bce6-170">北アメリカ スクリプト (カナダ音節文字、チェロキー文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-170">User-interface font for North American scripts (Canadian Syllabics, Cherokee).</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Leelawadee UI;"><span data-ttu-id="5bce6-171">Leelawadee UI</span><span class="sxs-lookup"><span data-stu-id="5bce6-171">Leelawadee UI</span></span></td>
<td align="left"><span data-ttu-id="5bce6-172">通常、Semilight、太字</span><span class="sxs-lookup"><span data-stu-id="5bce6-172">Regular, Semilight, Bold</span></span></td>
<td align="left"><span data-ttu-id="5bce6-173">東南アジアのスクリプト (ブギス文字、ラオス文字、クメール文字、タイ文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-173">User-interface font for Southeast Asian scripts (Buginese, Lao, Khmer, Thai).</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Malgun Gothic;"><span data-ttu-id="5bce6-174">Malgun Gothic</span><span class="sxs-lookup"><span data-stu-id="5bce6-174">Malgun Gothic</span></span></td>
<td align="left"><span data-ttu-id="5bce6-175">標準</span><span class="sxs-lookup"><span data-stu-id="5bce6-175">Regular</span></span></td>
<td align="left"><span data-ttu-id="5bce6-176">韓国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-176">User-interface font for Korean.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft JhengHei UI;"><span data-ttu-id="5bce6-177">Microsoft JhengHei UI</span><span class="sxs-lookup"><span data-stu-id="5bce6-177">Microsoft JhengHei UI</span></span></td>
<td align="left"><span data-ttu-id="5bce6-178">標準、太字、細字</span><span class="sxs-lookup"><span data-stu-id="5bce6-178">Regular, Bold, Light</span></span></td>
<td align="left"><span data-ttu-id="5bce6-179">繁体字中国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-179">User-interface font for Traditional Chinese.</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Microsoft YaHei UI;"><span data-ttu-id="5bce6-180">Microsoft YaHei UI</span><span class="sxs-lookup"><span data-stu-id="5bce6-180">Microsoft YaHei UI</span></span></td>
<td align="left"><span data-ttu-id="5bce6-181">標準、太字、細字</span><span class="sxs-lookup"><span data-stu-id="5bce6-181">Regular, Bold, Light</span></span></td>
<td align="left"><span data-ttu-id="5bce6-182">簡体字中国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-182">User-interface font for Simplified Chinese.</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Myanmar Text;"><span data-ttu-id="5bce6-183">Myanmar Text</span><span class="sxs-lookup"><span data-stu-id="5bce6-183">Myanmar Text</span></span></td>
<td align="left"><span data-ttu-id="5bce6-184">標準</span><span class="sxs-lookup"><span data-stu-id="5bce6-184">Regular</span></span></td>
<td align="left"><span data-ttu-id="5bce6-185">ミャンマー文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-185">Fallback font for Myanmar script.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Nirmala UI;"><span data-ttu-id="5bce6-186">Nirmala UI</span><span class="sxs-lookup"><span data-stu-id="5bce6-186">Nirmala UI</span></span></td>
<td align="left"><span data-ttu-id="5bce6-187">標準、中細、太字</span><span class="sxs-lookup"><span data-stu-id="5bce6-187">Regular, Semilight, Bold</span></span></td>
<td align="left"><span data-ttu-id="5bce6-188">南アジア言語のスクリプト (バングラ文字、デーバナーガリー文字、グジャラート文字、グルムキー文字、カンナダ文字、マラヤーラム文字、オディア文字、オル チキ文字、シンハラ文字、ソラング ソンペング文字、タミール文字、テルグ文字) 用のユーザー インターフェイス フォント</span><span class="sxs-lookup"><span data-stu-id="5bce6-188">User-interface font for South Asian scripts (Bangla, Devanagari, Gujarati, Gurmukhi, Kannada, Malayalam, Odia, Ol Chiki, Sinhala, Sora Sompeng, Tamil, Telugu)</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: SimSun;"><span data-ttu-id="5bce6-189">SimSun</span><span class="sxs-lookup"><span data-stu-id="5bce6-189">SimSun</span></span></td>
<td align="left"><span data-ttu-id="5bce6-190">標準</span><span class="sxs-lookup"><span data-stu-id="5bce6-190">Regular</span></span></td>
<td align="left"><span data-ttu-id="5bce6-191">中国語繁体字の UI フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-191">A legacy Chinese UI font.</span></span> </td>
</tr>
<tr class="even">
<td align="left" style="font-family: Yu Gothic UI;"><span data-ttu-id="5bce6-192">Yu Gothic UI</span><span class="sxs-lookup"><span data-stu-id="5bce6-192">Yu Gothic UI</span></span></td>
<td align="left"><span data-ttu-id="5bce6-193">細字、中細、標準、中太、太字</span><span class="sxs-lookup"><span data-stu-id="5bce6-193">Light, Semilight, Regular, Semibold, Bold</span></span></td>
<td align="left"><span data-ttu-id="5bce6-194">日本語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-194">User-interface font for Japanese.</span></span></td>
</tr>
</tbody>
</table>

## <a name="fonts"></a><span data-ttu-id="5bce6-195">フォント</span><span class="sxs-lookup"><span data-stu-id="5bce6-195">Fonts</span></span>

### <a name="sans-serif-fonts"></a><span data-ttu-id="5bce6-196">サンセリフ フォント</span><span class="sxs-lookup"><span data-stu-id="5bce6-196">Sans-serif fonts</span></span>

<span data-ttu-id="5bce6-197">サンセリフ フォントは、ヘッダーと UI 要素に適しています。</span><span class="sxs-lookup"><span data-stu-id="5bce6-197">Sans-serif fonts are a great choice for headings and UI elements.</span></span> 

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5bce6-198">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="5bce6-198">Font-family</span></span></th>
<th align="left"><span data-ttu-id="5bce6-199">スタイル</span><span class="sxs-lookup"><span data-stu-id="5bce6-199">Styles</span></span></th>
<th align="left"><span data-ttu-id="5bce6-200">コメント</span><span class="sxs-lookup"><span data-stu-id="5bce6-200">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left" style="font-family: Arial;"><span data-ttu-id="5bce6-201">Arial</span><span class="sxs-lookup"><span data-stu-id="5bce6-201">Arial</span></span></td>
<td align="left"><span data-ttu-id="5bce6-202">標準、斜体、太字、太字斜体、黒</span><span class="sxs-lookup"><span data-stu-id="5bce6-202">Regular, Italic, Bold, Bold Italic, Black</span></span></td>
<td align="left"><span data-ttu-id="5bce6-203">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。極太の太さがサポートされているのはヨーロッパのスクリプトだけです。</span><span class="sxs-lookup"><span data-stu-id="5bce6-203">Supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic, Armenian, and Hebrew) Black weight supports European scripts only.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Calibri;"><span data-ttu-id="5bce6-204">Calibri</span><span class="sxs-lookup"><span data-stu-id="5bce6-204">Calibri</span></span></td>
<td align="left"><span data-ttu-id="5bce6-205">標準、斜体、太字、太字斜体、細字、細字斜体</span><span class="sxs-lookup"><span data-stu-id="5bce6-205">Regular, Italic, Bold, Bold Italic, Light, Light Italic</span></span></td>
<td align="left"><span data-ttu-id="5bce6-206">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア語、ヘブライ語) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5bce6-206">Supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic and Hebrew).</span></span> <span data-ttu-id="5bce6-207">アラビア語は縦書きでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="5bce6-207">Arabic available in the uprights only.</span></span></td>
</tr>
<td style="font-family: Consolas;"><span data-ttu-id="5bce6-208">Consolas</span><span class="sxs-lookup"><span data-stu-id="5bce6-208">Consolas</span></span></td>
<td><span data-ttu-id="5bce6-209">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="5bce6-209">Regular, Italic, Bold, Bold Italic</span></span></td>
<td><span data-ttu-id="5bce6-210">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートする等幅フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-210">Fixed width font that supports European scripts (Latin, Greek and Cyrillic).</span></span></td>
</tr>

<tr>
<td style="font-family: Segoe UI;"><span data-ttu-id="5bce6-211">Segoe UI</span><span class="sxs-lookup"><span data-stu-id="5bce6-211">Segoe UI</span></span></td>
<td><span data-ttu-id="5bce6-212">標準、斜体、細字斜体、極太斜体、太字、太字斜体、細字、中細、中太、極太</span><span class="sxs-lookup"><span data-stu-id="5bce6-212">Regular, Italic, Light Italic, Black Italic, Bold, Bold Italic, Light, Semilight, Semibold, Black</span></span></td>
<td><span data-ttu-id="5bce6-213">ヨーロッパおよび中東のスクリプト (アラビア文字、アルメニア文字、キリル文字、ジョージア文字、ギリシャ文字、ヘブライ文字、ラテン文字) およびリス文字のスクリプト用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-213">User-interface font for European and Middle East scripts (Arabic, Armenian, Cyrillic, Georgian, Greek, Hebrew, Latin), and also Lisu script.</span></span></td>
</tr>

<tr class="even">
<td style="font-family: Selawik;"><span data-ttu-id="5bce6-214">Selawik</span><span class="sxs-lookup"><span data-stu-id="5bce6-214">Selawik</span></span></td>
<td align="left"><span data-ttu-id="5bce6-215">標準、中細、細字、太字、中太</span><span class="sxs-lookup"><span data-stu-id="5bce6-215">Regular, Semilight, Light, Bold, Semibold</span></span></td>
<td align="left"><span data-ttu-id="5bce6-216">他のプラットフォーム上で動作する Segoe UI をバンドルしないアプリ向けの、Segoe UI と測定上の互換性があるオープン ソース フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-216">An open-source font that's metrically compatible with Segoe UI, intended for apps on other platforms that don’t want to bundle Segoe UI.</span></span> <a href="https://github.com/Microsoft/Selawik"><span data-ttu-id="5bce6-217">Selawik は、GitHub で入手できます。</span><span class="sxs-lookup"><span data-stu-id="5bce6-217">Get Selawik on GitHub.</span></span></a></td>
</tr>

</tbody>
</table>

### <a name="serif-fonts"></a><span data-ttu-id="5bce6-218">セリフ フォント</span><span class="sxs-lookup"><span data-stu-id="5bce6-218">Serif fonts</span></span>

<span data-ttu-id="5bce6-219">セリフ フォントは、大量のテキストを表示するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="5bce6-219">Serif fonts are good for presenting large amounts of text.</span></span> 

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5bce6-220">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="5bce6-220">Font-family</span></span></th>
<th align="left"><span data-ttu-id="5bce6-221">スタイル</span><span class="sxs-lookup"><span data-stu-id="5bce6-221">Styles</span></span></th>
<th align="left"><span data-ttu-id="5bce6-222">コメント</span><span class="sxs-lookup"><span data-stu-id="5bce6-222">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="font-family: Cambria;"><span data-ttu-id="5bce6-223">Cambria</span><span class="sxs-lookup"><span data-stu-id="5bce6-223">Cambria</span></span></td>
<td align="left"><span data-ttu-id="5bce6-224">標準</span><span class="sxs-lookup"><span data-stu-id="5bce6-224">Regular</span></span></td>
<td align="left"><span data-ttu-id="5bce6-225">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートするセリフ フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-225">Serif font that supports European scripts (Latin, Greek, Cyrillic).</span></span></td>
</tr>
<tr class="even">
<td style="font-family: Courier New;"><span data-ttu-id="5bce6-226">Courier New</span><span class="sxs-lookup"><span data-stu-id="5bce6-226">Courier New</span></span></td>
<td align="left"><span data-ttu-id="5bce6-227">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="5bce6-227">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="5bce6-228">セリフ等幅フォントは、ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5bce6-228">Serif fixed width font supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic, Armenian, and Hebrew).</span></span></td>
</tr>
<tr class="odd">
<td style="font-family: Georgia;"><span data-ttu-id="5bce6-229">Georgia</span><span class="sxs-lookup"><span data-stu-id="5bce6-229">Georgia</span></span></td>
<td align="left"><span data-ttu-id="5bce6-230">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="5bce6-230">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="5bce6-231">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5bce6-231">Supports European scripts (Latin, Greek and Cyrillic).</span></span></td>
</tr>

<tr class="even">
<td style="font-family: Times New Roman;"><span data-ttu-id="5bce6-232">Times New Roman</span><span class="sxs-lookup"><span data-stu-id="5bce6-232">Times New Roman</span></span></td>
<td align="left"><span data-ttu-id="5bce6-233">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="5bce6-233">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="5bce6-234">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしている従来のフォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-234">Legacy font that supports European scripts (Latin, Greek, Cyrillic, Arabic, Armenian, Hebrew).</span></span></td>
</tr>

</tbody>
</table>

### <a name="symbols-and-icons"></a><span data-ttu-id="5bce6-235">シンボルとアイコン</span><span class="sxs-lookup"><span data-stu-id="5bce6-235">Symbols and icons</span></span>

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5bce6-236">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="5bce6-236">Font-family</span></span></th>
<th align="left"><span data-ttu-id="5bce6-237">スタイル</span><span class="sxs-lookup"><span data-stu-id="5bce6-237">Styles</span></span></th>
<th align="left"><span data-ttu-id="5bce6-238">コメント</span><span class="sxs-lookup"><span data-stu-id="5bce6-238">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="5bce6-239">Segoe MDL2 アセット</span><span class="sxs-lookup"><span data-stu-id="5bce6-239">Segoe MDL2 Assets</span></span></td>
<td align="left"><span data-ttu-id="5bce6-240">標準</span><span class="sxs-lookup"><span data-stu-id="5bce6-240">Regular</span></span></td>
<td align="left"><span data-ttu-id="5bce6-241">アプリ アイコン用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="5bce6-241">User-interface font for app icons.</span></span> <span data-ttu-id="5bce6-242">詳しくは、<a href="segoe-ui-symbol-font.md">Segoe MDL2 アセットの記事</a>をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5bce6-242">For more info, see the <a href="segoe-ui-symbol-font.md">Segoe MDL2 assets article</a>.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="5bce6-243">Segoe UI Emoji</span><span class="sxs-lookup"><span data-stu-id="5bce6-243">Segoe UI Emoji</span></span></td>
<td align="left"><span data-ttu-id="5bce6-244">標準</span><span class="sxs-lookup"><span data-stu-id="5bce6-244">Regular</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="5bce6-245">Segoe UI Symbol</span><span class="sxs-lookup"><span data-stu-id="5bce6-245">Segoe UI Symbol</span></span></td>
<td align="left"><span data-ttu-id="5bce6-246">標準</span><span class="sxs-lookup"><span data-stu-id="5bce6-246">Regular</span></span></td>
<td align="left"><span data-ttu-id="5bce6-247">記号用のフォールバック フォント</span><span class="sxs-lookup"><span data-stu-id="5bce6-247">Fallback font for symbols</span></span></td>
</tr>
</tbody>
</table>

## <a name="related-articles"></a><span data-ttu-id="5bce6-248">関連記事</span><span class="sxs-lookup"><span data-stu-id="5bce6-248">Related articles</span></span>

* [<span data-ttu-id="5bce6-249">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="5bce6-249">Text controls</span></span>](../controls-and-patterns/text-controls.md)
* [<span data-ttu-id="5bce6-250">XAML テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="5bce6-250">XAML theme resources</span></span>](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp)
* [<span data-ttu-id="5bce6-251">XAML スタイル</span><span class="sxs-lookup"><span data-stu-id="5bce6-251">XAML styles</span></span>](../controls-and-patterns/xaml-styles.md)
* [<span data-ttu-id="5bce6-252">Microsoft の文字体裁</span><span class="sxs-lookup"><span data-stu-id="5bce6-252">Microsoft Typography</span></span>](https://docs.microsoft.com/typography/)