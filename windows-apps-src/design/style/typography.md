---
description: コンテンツをユーザーに理解しやすくするための、アプリにおける文字体裁の使用方法について説明します。
title: UWP アプリの文字体裁
ms.date: 04/06/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 0943273dab239669be75b30070222d698246aa41
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610027"
---
# <a name="typography"></a><span data-ttu-id="1c930-104">文字体裁</span><span class="sxs-lookup"><span data-stu-id="1c930-104">Typography</span></span>

![ヒーロー イメージ](images/header-typography.svg)

<span data-ttu-id="1c930-106">言語の視覚的表現である文字体裁において、何よりも重要な役割は情報を伝達することです。</span><span class="sxs-lookup"><span data-stu-id="1c930-106">As the visual representation of language, typography’s main task is to communicate information.</span></span> <span data-ttu-id="1c930-107">スタイルによってその目的が邪魔されてはなりません。</span><span class="sxs-lookup"><span data-stu-id="1c930-107">Its style should never get in the way of that goal.</span></span> <span data-ttu-id="1c930-108">この記事では、ユーザーが簡単かつ効率的にコンテンツを理解できるように、UWP アプリで文字体裁のスタイルを決定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1c930-108">In this article, we'll discuss how to style typography in your UWP app to help users understand content easily and efficiently.</span></span>

## <a name="font"></a><span data-ttu-id="1c930-109">Font</span><span class="sxs-lookup"><span data-stu-id="1c930-109">Font</span></span>

<span data-ttu-id="1c930-110">アプリ全体で同じフォントを使用してください。UWP アプリの既定のフォントである **Segoe UI** に統一することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1c930-110">You should use one font throughout your app's UI, and we recommend sticking with the default font for UWP apps, **Segoe UI**.</span></span> <span data-ttu-id="1c930-111">このフォントは、常に最適な読みやすさが維持されるサイズとピクセル密度を備え、システムのコンテンツを清潔で軽快、かつオープンに美しく表示します。</span><span class="sxs-lookup"><span data-stu-id="1c930-111">It's designed to maintain optimal legibility across sizes and pixel densities and offers a clean, light, and open aesthetic that complements the content of the system.</span></span>

![Segoe UI フォントのサンプル テキスト](images/type/segoe-sample.svg)

<span data-ttu-id="1c930-113">アプリで英語以外の言語を表示する場合、または異なるフォントを選択する場合は、「[言語](#Languages)」と「[フォント](#Fonts)」のセクションで、弊社が UWP アプリ向けに推奨するフォントを確認してください。</span><span class="sxs-lookup"><span data-stu-id="1c930-113">To display non-English languages or to select a different font for your app, please see [Languages](#Languages) and [Fonts](#Fonts) for our recommended fonts for UWP apps.</span></span>

:::row:::
    :::column:::
        ![do](images/do.svg)
        Pick one font for your UI.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Don't mix multiple fonts.
    :::column-end:::
:::row-end:::

## <a name="size-and-scaling"></a><span data-ttu-id="1c930-114">サイズとスケーリング</span><span class="sxs-lookup"><span data-stu-id="1c930-114">Size and scaling</span></span>

<span data-ttu-id="1c930-115">UWP アプリのフォント サイズは、すべてのデバイスで自動的に拡大縮小します。</span><span class="sxs-lookup"><span data-stu-id="1c930-115">Font sizes in UWP apps automatically scale on all devices.</span></span> <span data-ttu-id="1c930-116">スケーリング アルゴリズムによって、10 フィート離れた Surface Hub 上の 24 ピクセル フォントが、目の前にある 5 インチ サイズの電話の画面に表示された 24 ピクセル フォントと同じ読みやすさで表示されます。</span><span class="sxs-lookup"><span data-stu-id="1c930-116">The scaling algorithm ensures that a 24 px font on Surface Hub 10 feet away is just as legible as a 24 px font on 5" phone that's a few inches away.</span></span>

![さまざまなデバイスの視聴距離](images/type/scaling-chart.svg)

<span data-ttu-id="1c930-118">スケーリング システムのしくみを踏まえ、実際の物理ピクセルではなく、有効ピクセルに基づいてデザインしてください。異なる画面サイズや解像度に応じてフォント サイズを変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1c930-118">Because of how the scaling system works, you're designing in effective pixels, not actual physical pixels, and you shouldn't have to alter font sizes for different screens sizes or resolutions.</span></span>

:::row:::
    :::column:::
        ![do](images/do.svg)
        Follow the UWP [type ramp](#type-ramp) sizing.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Use a font size smaller than 12 px.
    :::column-end:::
:::row-end:::

## <a name="hierarchy"></a><span data-ttu-id="1c930-119">階層</span><span class="sxs-lookup"><span data-stu-id="1c930-119">Hierarchy</span></span>

:::row:::
    :::column:::
        Users rely on visual hierarchy when scanning a page: headers summarize content, and body text provides more detail. To create a clear visual hierarchy in your app, follow the UWP type ramp.
    :::column-end:::
    :::column:::
        ![text block styles](images/type/type-hierarchy.svg)
    :::column-end:::
:::row-end:::

### <a name="type-ramp"></a><span data-ttu-id="1c930-120">書体見本</span><span class="sxs-lookup"><span data-stu-id="1c930-120">Type ramp</span></span>

<span data-ttu-id="1c930-121">UWP 書体見本は、ユーザーがコンテンツを読みやすいように、ページ上の各書体スタイル間の重要な関係を定めたものです。</span><span class="sxs-lookup"><span data-stu-id="1c930-121">The UWP type ramp establishes crucial relationships between the type styles on a page, helping users read content easily.</span></span> <span data-ttu-id="1c930-122">すべてのサイズは有効ピクセル単位で示され、UWP アプリが動作するデバイスを問わず、常に最適に表示されるように調整されています。</span><span class="sxs-lookup"><span data-stu-id="1c930-122">All sizes are in effective pixels and are optimized for UWP apps running on all devices.</span></span>

![書体見本](images/type/type-ramp.svg)

### <a name="using-the-type-ramp"></a><span data-ttu-id="1c930-124">書体見本の使用</span><span class="sxs-lookup"><span data-stu-id="1c930-124">Using the type ramp</span></span>

:::row:::
    :::column:::
        You can access levels of the type ramp as XAML [static resources](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp). The styles follow the `*TextBlockStyle` naming convention.
    :::column-end:::
    :::column:::
        ![text block styles](images/type/text-block-type-ramp.svg)
    :::column-end:::
:::row-end:::

```XAML
<TextBlock Text="Header" Style="{StaticResource HeaderTextBlockStyle}"/>
<TextBlock Text="SubHeader" Style="{StaticResource SubheaderTextBlockStyle}"/>
<TextBlock Text="Title" Style="{StaticResource TitleTextBlockStyle}"/>
<TextBlock Text="SubTitle" Style="{StaticResource SubtitleTextBlockStyle}"/>
<TextBlock Text="Base" Style="{StaticResource BaseTextBlockStyle}"/>
<TextBlock Text="Body" Style="{StaticResource BodyTextBlockStyle}"/>
<TextBlock Text="Caption" Style="{StaticResource CaptionTextBlockStyle}"/>
```

:::row:::
    :::column:::
        ![do](images/do.svg)
        Use "Body" for most text.

        Use "Base" for titles when space is constrained.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Use "Caption" for primary action or any long strings.

        Use "Header" or "Subheader" if text needs to wrap.
    :::column-end:::
:::row-end:::

## <a name="alignment"></a><span data-ttu-id="1c930-125">配置</span><span class="sxs-lookup"><span data-stu-id="1c930-125">Alignment</span></span>

<span data-ttu-id="1c930-126">既定の [TextAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.textalignment) (行揃え) は Left (左揃え) です。ほとんどの場合、左揃え、右不揃いの形式でコンテンツを一貫してアンカー設定することで、均一なレイアウトが実現します。</span><span class="sxs-lookup"><span data-stu-id="1c930-126">The default [TextAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.textalignment) is Left, and in most instances, flush-left and ragged right provides consistent anchoring of the content and a uniform layout.</span></span> <span data-ttu-id="1c930-127">RTL 言語については、[グローバリゼーションをサポートするためのレイアウトとフォントの調整に関するページ](../globalizing/adjust-layout-and-fonts--and-support-rtl.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1c930-127">For RTL languages, see [Adjusting layout and fonts to support globalization](../globalizing/adjust-layout-and-fonts--and-support-rtl.md).</span></span>

![左揃えテキストを示します。](images/type/alignment.svg)

```xaml
<TextBlock TextAlignment="Left">
```

## <a name="character-count"></a><span data-ttu-id="1c930-129">文字カウント</span><span class="sxs-lookup"><span data-stu-id="1c930-129">Character count</span></span>

:::row:::
    :::column:::
        ![do](images/do.svg)
        Keep to 50–60 letters per line for ease of reading.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Less than 20 characters or more than 60 characters per line is difficult to read.
    :::column-end:::
:::row-end:::

## <a name="clipping-and-ellipses"></a><span data-ttu-id="1c930-130">クリッピングと省略記号</span><span class="sxs-lookup"><span data-stu-id="1c930-130">Clipping and ellipses</span></span>

<span data-ttu-id="1c930-131">テキストの量が利用可能なスペースを超えている場合は、テキストをクリッピングすることが推奨されます。クリッピングは、ほとんどの [UWP テキスト コントロール](../controls-and-patterns/text-controls.md) で既定の処理です。</span><span class="sxs-lookup"><span data-stu-id="1c930-131">When the amount of text extends beyond the space available, we recommend clipping text, which is the default behavior of most [UWP text controls](../controls-and-patterns/text-controls.md).</span></span>

![いくつかのテキスト クリッピングがあるデバイス フレームを示します。](images/type/clipping.svg)

```xaml
<TextBlock TextWrapping="WrapWholeWords" TextTrimming="Clip"/>
```

:::row:::
    :::column:::
        ![do](images/do.svg)
        Clip text, and wrap if multiple lines are enabled.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Use ellipses to avoid visual clutter.
    :::column-end:::
:::row-end:::

<span data-ttu-id="1c930-133">**注意**:コンテナーは適切に定義された場合 (例: 差別化の背景色なし)、またはその他のテキストを表示するリンクがある場合は、省略記号を使用しています。</span><span class="sxs-lookup"><span data-stu-id="1c930-133">**Note**: If containers are not well-defined (e.g. no differentiating background color), or when there is a link to see more text, then use ellipses.</span></span>

## <a name="languages"></a><span data-ttu-id="1c930-134">言語</span><span class="sxs-lookup"><span data-stu-id="1c930-134">Languages</span></span> 

<span data-ttu-id="1c930-135">Segoe UI は、英語、ヨーロッパの各言語、ギリシャ語、ヘブライ語、アルメニア語、ジョージア語、アラビア語に対応した弊社のフォントです。</span><span class="sxs-lookup"><span data-stu-id="1c930-135">Segoe UI is our font for English, European languages, Greek, Hebrew, Armenian, Georgian, and Arabic.</span></span> <span data-ttu-id="1c930-136">他の言語については、以下の推奨事項を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1c930-136">For other languages, see the following recommendations.</span></span>

### <a name="globalizinglocalizing-fonts"></a><span data-ttu-id="1c930-137">フォントのグローバリゼーション/ローカライズ</span><span class="sxs-lookup"><span data-stu-id="1c930-137">Globalizing/localizing fonts</span></span>

<span data-ttu-id="1c930-138">特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[LanguageFont フォント マッピング API](https://docs.microsoft.com/uwp/api/Windows.Globalization.Fonts.LanguageFont) を使ってください。</span><span class="sxs-lookup"><span data-stu-id="1c930-138">Use the [LanguageFont font-mapping APIs](https://docs.microsoft.com/uwp/api/Windows.Globalization.Fonts.LanguageFont) for programmatic access to the recommended font family, size, weight, and style for a particular language.</span></span> <span data-ttu-id="1c930-139">LanguageFont オブジェクトを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1c930-139">The LanguageFont object provides access to the correct font info for various categories of content including UI headers, notifications, body text, and user-editable document body fonts.</span></span> <span data-ttu-id="1c930-140">詳しくは、「[レイアウトとグローバリゼーションをサポートするフォントの調整](../globalizing/adjust-layout-and-fonts--and-support-rtl.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1c930-140">For more info, see [Adjusting layout and fonts to support globalization](../globalizing/adjust-layout-and-fonts--and-support-rtl.md).</span></span>

### <a name="fonts-for-non-latin-languages"></a><span data-ttu-id="1c930-141">ラテン語以外の言語用のフォント</span><span class="sxs-lookup"><span data-stu-id="1c930-141">Fonts for non-Latin languages</span></span>

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="1c930-142">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="1c930-142">Font-family</span></span></th>
<th align="left"><span data-ttu-id="1c930-143">スタイル</span><span class="sxs-lookup"><span data-stu-id="1c930-143">Styles</span></span></th>
<th align="left"><span data-ttu-id="1c930-144">メモ</span><span class="sxs-lookup"><span data-stu-id="1c930-144">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="font-family: Embrima;"><span data-ttu-id="1c930-145">Ebrima</span><span class="sxs-lookup"><span data-stu-id="1c930-145">Ebrima</span></span></td>
<td align="left"><span data-ttu-id="1c930-146">標準、太字</span><span class="sxs-lookup"><span data-stu-id="1c930-146">Regular, Bold</span></span></td>
<td align="left"><span data-ttu-id="1c930-147">アフリカのスクリプト (エチオピア文字、ンコ文字、オスマニア文字、ティフィナグ文字、ヴァイ文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-147">User-interface font for African scripts (Ethiopic, N'Ko, Osmanya, Tifinagh, Vai).</span></span></td>
</tr>
<tr class="even">
<td style="font-family: Gadugi;"><span data-ttu-id="1c930-148">Gadugi</span><span class="sxs-lookup"><span data-stu-id="1c930-148">Gadugi</span></span></td>
<td align="left"><span data-ttu-id="1c930-149">標準、太字</span><span class="sxs-lookup"><span data-stu-id="1c930-149">Regular, Bold</span></span></td>
<td align="left"><span data-ttu-id="1c930-150">北アメリカ スクリプト (カナダ音節文字、チェロキー文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-150">User-interface font for North American scripts (Canadian Syllabics, Cherokee).</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Leelawadee UI;"><span data-ttu-id="1c930-151">Leelawadee UI</span><span class="sxs-lookup"><span data-stu-id="1c930-151">Leelawadee UI</span></span></td>
<td align="left"><span data-ttu-id="1c930-152">通常、Semilight、太字</span><span class="sxs-lookup"><span data-stu-id="1c930-152">Regular, Semilight, Bold</span></span></td>
<td align="left"><span data-ttu-id="1c930-153">東南アジアのスクリプト (ブギス文字、ラオス文字、クメール文字、タイ文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-153">User-interface font for Southeast Asian scripts (Buginese, Lao, Khmer, Thai).</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Malgun Gothic;"><span data-ttu-id="1c930-154">Malgun Gothic</span><span class="sxs-lookup"><span data-stu-id="1c930-154">Malgun Gothic</span></span></td>
<td align="left"><span data-ttu-id="1c930-155">標準</span><span class="sxs-lookup"><span data-stu-id="1c930-155">Regular</span></span></td>
<td align="left"><span data-ttu-id="1c930-156">韓国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-156">User-interface font for Korean.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft JhengHei UI;"><span data-ttu-id="1c930-157">Microsoft JhengHei UI</span><span class="sxs-lookup"><span data-stu-id="1c930-157">Microsoft JhengHei UI</span></span></td>
<td align="left"><span data-ttu-id="1c930-158">標準、太字、細字</span><span class="sxs-lookup"><span data-stu-id="1c930-158">Regular, Bold, Light</span></span></td>
<td align="left"><span data-ttu-id="1c930-159">繁体字中国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-159">User-interface font for Traditional Chinese.</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Microsoft YaHei UI;"><span data-ttu-id="1c930-160">Microsoft YaHei UI</span><span class="sxs-lookup"><span data-stu-id="1c930-160">Microsoft YaHei UI</span></span></td>
<td align="left"><span data-ttu-id="1c930-161">標準、太字、細字</span><span class="sxs-lookup"><span data-stu-id="1c930-161">Regular, Bold, Light</span></span></td>
<td align="left"><span data-ttu-id="1c930-162">簡体字中国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-162">User-interface font for Simplified Chinese.</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Myanmar Text;"><span data-ttu-id="1c930-163">Myanmar Text</span><span class="sxs-lookup"><span data-stu-id="1c930-163">Myanmar Text</span></span></td>
<td align="left"><span data-ttu-id="1c930-164">標準</span><span class="sxs-lookup"><span data-stu-id="1c930-164">Regular</span></span></td>
<td align="left"><span data-ttu-id="1c930-165">ミャンマー文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-165">Fallback font for Myanmar script.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Nirmala UI;"><span data-ttu-id="1c930-166">Nirmala UI</span><span class="sxs-lookup"><span data-stu-id="1c930-166">Nirmala UI</span></span></td>
<td align="left"><span data-ttu-id="1c930-167">通常、Semilight、太字</span><span class="sxs-lookup"><span data-stu-id="1c930-167">Regular, Semilight, Bold</span></span></td>
<td align="left"><span data-ttu-id="1c930-168">南アジア言語のスクリプト (バングラ文字、デーバナーガリー文字、グジャラート文字、グルムキー文字、カンナダ文字、マラヤーラム文字、オディア文字、オル チキ文字、シンハラ文字、ソラング ソンペング文字、タミール文字、テルグ文字) 用のユーザー インターフェイス フォント</span><span class="sxs-lookup"><span data-stu-id="1c930-168">User-interface font for South Asian scripts (Bangla, Devanagari, Gujarati, Gurmukhi, Kannada, Malayalam, Odia, Ol Chiki, Sinhala, Sora Sompeng, Tamil, Telugu)</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: SimSun;"><span data-ttu-id="1c930-169">SimSun</span><span class="sxs-lookup"><span data-stu-id="1c930-169">SimSun</span></span></td>
<td align="left"><span data-ttu-id="1c930-170">標準</span><span class="sxs-lookup"><span data-stu-id="1c930-170">Regular</span></span></td>
<td align="left"><span data-ttu-id="1c930-171">中国語繁体字の UI フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-171">A legacy Chinese UI font.</span></span> </td>
</tr>
<tr class="even">
<td align="left" style="font-family: Yu Gothic UI;"><span data-ttu-id="1c930-172">Yu Gothic UI</span><span class="sxs-lookup"><span data-stu-id="1c930-172">Yu Gothic UI</span></span></td>
<td align="left"><span data-ttu-id="1c930-173">細字、中細、標準、中太、太字</span><span class="sxs-lookup"><span data-stu-id="1c930-173">Light, Semilight, Regular, Semibold, Bold</span></span></td>
<td align="left"><span data-ttu-id="1c930-174">日本語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-174">User-interface font for Japanese.</span></span></td>
</tr>
</tbody>
</table>

## <a name="fonts"></a><span data-ttu-id="1c930-175">フォント</span><span class="sxs-lookup"><span data-stu-id="1c930-175">Fonts</span></span>

### <a name="sans-serif-fonts"></a><span data-ttu-id="1c930-176">サンセリフ フォント</span><span class="sxs-lookup"><span data-stu-id="1c930-176">Sans-serif fonts</span></span>

<span data-ttu-id="1c930-177">サンセリフ フォントは、ヘッダーと UI 要素に適しています。</span><span class="sxs-lookup"><span data-stu-id="1c930-177">Sans-serif fonts are a great choice for headings and UI elements.</span></span> 

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="1c930-178">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="1c930-178">Font-family</span></span></th>
<th align="left"><span data-ttu-id="1c930-179">スタイル</span><span class="sxs-lookup"><span data-stu-id="1c930-179">Styles</span></span></th>
<th align="left"><span data-ttu-id="1c930-180">メモ</span><span class="sxs-lookup"><span data-stu-id="1c930-180">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left" style="font-family: Arial;"><span data-ttu-id="1c930-181">Arial</span><span class="sxs-lookup"><span data-stu-id="1c930-181">Arial</span></span></td>
<td align="left"><span data-ttu-id="1c930-182">通常、斜体、太字、太字斜体、黒</span><span class="sxs-lookup"><span data-stu-id="1c930-182">Regular, Italic, Bold, Bold Italic, Black</span></span></td>
<td align="left"><span data-ttu-id="1c930-183">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。極太の太さがサポートされているのはヨーロッパのスクリプトだけです。</span><span class="sxs-lookup"><span data-stu-id="1c930-183">Supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic, Armenian, and Hebrew) Black weight supports European scripts only.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Calibri;"><span data-ttu-id="1c930-184">Calibri</span><span class="sxs-lookup"><span data-stu-id="1c930-184">Calibri</span></span></td>
<td align="left"><span data-ttu-id="1c930-185">通常、斜体、太字、太字斜体、中細、中細斜体</span><span class="sxs-lookup"><span data-stu-id="1c930-185">Regular, Italic, Bold, Bold Italic, Light, Light Italic</span></span></td>
<td align="left"><span data-ttu-id="1c930-186">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア語、ヘブライ語) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1c930-186">Supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic and Hebrew).</span></span> <span data-ttu-id="1c930-187">アラビア語は縦書きでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="1c930-187">Arabic available in the uprights only.</span></span></td>
</tr>
<td style="font-family: Consolas;"><span data-ttu-id="1c930-188">Consolas</span><span class="sxs-lookup"><span data-stu-id="1c930-188">Consolas</span></span></td>
<td><span data-ttu-id="1c930-189">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="1c930-189">Regular, Italic, Bold, Bold Italic</span></span></td>
<td><span data-ttu-id="1c930-190">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートする等幅フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-190">Fixed width font that supports European scripts (Latin, Greek and Cyrillic).</span></span></td>
</tr>

<tr>
<td style="font-family: Segoe UI;"><span data-ttu-id="1c930-191">Segoe UI</span><span class="sxs-lookup"><span data-stu-id="1c930-191">Segoe UI</span></span></td>
<td><span data-ttu-id="1c930-192">標準、斜体、細字斜体、極太斜体、太字、太字斜体、細字、中細、中太、極太</span><span class="sxs-lookup"><span data-stu-id="1c930-192">Regular, Italic, Light Italic, Black Italic, Bold, Bold Italic, Light, Semilight, Semibold, Black</span></span></td>
<td><span data-ttu-id="1c930-193">ヨーロッパおよび中東のスクリプト (アラビア文字、アルメニア文字、キリル文字、ジョージア文字、ギリシャ文字、ヘブライ文字、ラテン文字) およびリス文字のスクリプト用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-193">User-interface font for European and Middle East scripts (Arabic, Armenian, Cyrillic, Georgian, Greek, Hebrew, Latin), and also Lisu script.</span></span></td>
</tr>

<tr class="even">
<td style="font-family: Selawik;"><span data-ttu-id="1c930-194">Selawik</span><span class="sxs-lookup"><span data-stu-id="1c930-194">Selawik</span></span></td>
<td align="left"><span data-ttu-id="1c930-195">標準、中細、細字、太字、中太</span><span class="sxs-lookup"><span data-stu-id="1c930-195">Regular, Semilight, Light, Bold, Semibold</span></span></td>
<td align="left"><span data-ttu-id="1c930-196">他のプラットフォーム上で動作する Segoe UI をバンドルしないアプリ向けの、Segoe UI と測定上の互換性があるオープン ソース フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-196">An open-source font that's metrically compatible with Segoe UI, intended for apps on other platforms that don’t want to bundle Segoe UI.</span></span> <span data-ttu-id="1c930-197"><a href="https://github.com/Microsoft/Selawik">GitHub の Selawik を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="1c930-197"><a href="https://github.com/Microsoft/Selawik">Get Selawik on GitHub.</a></span></span></td>
</tr>

</tbody>
</table>

### <a name="serif-fonts"></a><span data-ttu-id="1c930-198">セリフ フォント</span><span class="sxs-lookup"><span data-stu-id="1c930-198">Serif fonts</span></span>

<span data-ttu-id="1c930-199">セリフ フォントは、大量のテキストを表示するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="1c930-199">Serif fonts are good for presenting large amounts of text.</span></span> 

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="1c930-200">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="1c930-200">Font-family</span></span></th>
<th align="left"><span data-ttu-id="1c930-201">スタイル</span><span class="sxs-lookup"><span data-stu-id="1c930-201">Styles</span></span></th>
<th align="left"><span data-ttu-id="1c930-202">メモ</span><span class="sxs-lookup"><span data-stu-id="1c930-202">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="font-family: Cambria;"><span data-ttu-id="1c930-203">Cambria</span><span class="sxs-lookup"><span data-stu-id="1c930-203">Cambria</span></span></td>
<td align="left"><span data-ttu-id="1c930-204">標準</span><span class="sxs-lookup"><span data-stu-id="1c930-204">Regular</span></span></td>
<td align="left"><span data-ttu-id="1c930-205">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートするセリフ フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-205">Serif font that supports European scripts (Latin, Greek, Cyrillic).</span></span></td>
</tr>
<tr class="even">
<td style="font-family: Courier New;"><span data-ttu-id="1c930-206">Courier New</span><span class="sxs-lookup"><span data-stu-id="1c930-206">Courier New</span></span></td>
<td align="left"><span data-ttu-id="1c930-207">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="1c930-207">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="1c930-208">セリフ等幅フォントは、ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1c930-208">Serif fixed width font supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic, Armenian, and Hebrew).</span></span></td>
</tr>
<tr class="odd">
<td style="font-family: Georgia;"><span data-ttu-id="1c930-209">ジョージア</span><span class="sxs-lookup"><span data-stu-id="1c930-209">Georgia</span></span></td>
<td align="left"><span data-ttu-id="1c930-210">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="1c930-210">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="1c930-211">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1c930-211">Supports European scripts (Latin, Greek and Cyrillic).</span></span></td>
</tr>

<tr class="even">
<td style="font-family: Times New Roman;"><span data-ttu-id="1c930-212">Times New Roman</span><span class="sxs-lookup"><span data-stu-id="1c930-212">Times New Roman</span></span></td>
<td align="left"><span data-ttu-id="1c930-213">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="1c930-213">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="1c930-214">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしている従来のフォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-214">Legacy font that supports European scripts (Latin, Greek, Cyrillic, Arabic, Armenian, Hebrew).</span></span></td>
</tr>

</tbody>
</table>

### <a name="symbols-and-icons"></a><span data-ttu-id="1c930-215">シンボルとアイコン</span><span class="sxs-lookup"><span data-stu-id="1c930-215">Symbols and icons</span></span>

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="1c930-216">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="1c930-216">Font-family</span></span></th>
<th align="left"><span data-ttu-id="1c930-217">スタイル</span><span class="sxs-lookup"><span data-stu-id="1c930-217">Styles</span></span></th>
<th align="left"><span data-ttu-id="1c930-218">メモ</span><span class="sxs-lookup"><span data-stu-id="1c930-218">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="1c930-219">Segoe MDL2 アセット</span><span class="sxs-lookup"><span data-stu-id="1c930-219">Segoe MDL2 Assets</span></span></td>
<td align="left"><span data-ttu-id="1c930-220">標準</span><span class="sxs-lookup"><span data-stu-id="1c930-220">Regular</span></span></td>
<td align="left"><span data-ttu-id="1c930-221">アプリ アイコン用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="1c930-221">User-interface font for app icons.</span></span> <span data-ttu-id="1c930-222">詳しくは、<a href="segoe-ui-symbol-font.md">Segoe MDL2 アセットの記事</a>をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1c930-222">For more info, see the <a href="segoe-ui-symbol-font.md">Segoe MDL2 assets article</a>.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="1c930-223">Segoe UI Emoji</span><span class="sxs-lookup"><span data-stu-id="1c930-223">Segoe UI Emoji</span></span></td>
<td align="left"><span data-ttu-id="1c930-224">標準</span><span class="sxs-lookup"><span data-stu-id="1c930-224">Regular</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="1c930-225">Segoe UI Symbol</span><span class="sxs-lookup"><span data-stu-id="1c930-225">Segoe UI Symbol</span></span></td>
<td align="left"><span data-ttu-id="1c930-226">標準</span><span class="sxs-lookup"><span data-stu-id="1c930-226">Regular</span></span></td>
<td align="left"><span data-ttu-id="1c930-227">記号用のフォールバック フォント</span><span class="sxs-lookup"><span data-stu-id="1c930-227">Fallback font for symbols</span></span></td>
</tr>
</tbody>
</table>

## <a name="related-articles"></a><span data-ttu-id="1c930-228">関連記事</span><span class="sxs-lookup"><span data-stu-id="1c930-228">Related articles</span></span>

* [<span data-ttu-id="1c930-229">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="1c930-229">Text controls</span></span>](../controls-and-patterns/text-controls.md)
* [<span data-ttu-id="1c930-230">XAML のテーマのリソース</span><span class="sxs-lookup"><span data-stu-id="1c930-230">XAML theme resources</span></span>](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp)
* [<span data-ttu-id="1c930-231">XAML スタイル</span><span class="sxs-lookup"><span data-stu-id="1c930-231">XAML styles</span></span>](../controls-and-patterns/xaml-styles.md)
* [<span data-ttu-id="1c930-232">Microsoft の文字体裁</span><span class="sxs-lookup"><span data-stu-id="1c930-232">Microsoft Typography</span></span>](https://docs.microsoft.com/typography/)
