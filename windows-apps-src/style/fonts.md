---
author: Jwmsft
Description: "UWP アプリのフォントを選び、フォントのサイズと色を指定するときには、次のガイドラインに従ってください。"
title: "UWP アプリ用のフォント"
ms.assetid: 1B8B90AD-CDC4-4997-ACDE-871C1E94A929
label: Fonts
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 08f6a712d73c58d3719c0555cda6688b5aa138ab
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="fonts-for-uwp-apps"></a><span data-ttu-id="01261-104">UWP アプリ用のフォント</span><span class="sxs-lookup"><span data-stu-id="01261-104">Fonts for UWP apps</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="01261-105">この記事では、UWP アプリの推奨フォントを示します。</span><span class="sxs-lookup"><span data-stu-id="01261-105">This article lists the recommended fonts for UWP apps.</span></span> <span data-ttu-id="01261-106">これらのフォントは、UWP アプリをサポートするすべての Windows 10 エディションで利用可能なことが保証されています。</span><span class="sxs-lookup"><span data-stu-id="01261-106">These fonts are guaranteed to be available in all Windows 10 editions that support UWP apps.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="01261-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="01261-107">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="01261-108">FontFamily プロパティ</span><span class="sxs-lookup"><span data-stu-id="01261-108">FontFamily property</span></span>**](https://msdn.microsoft.com/library/windows/apps/br209655)</li>
</ul>
</div>

<span data-ttu-id="01261-109">[UWP 文字体裁ガイド](typography.md)ではアプリに Segoe UI フォントを使用するようお勧めしています。Segoe UI はほとんどのアプリに適した選択ですが、すべての場合にこれを使用しなければならないわけではありません。</span><span class="sxs-lookup"><span data-stu-id="01261-109">The [UWP typography guide](typography.md) recommends that apps use the Segoe UI font, and although Segoe UI is a great choice for most apps, you don't have to use it for everything.</span></span> <span data-ttu-id="01261-110">読み物や英語以外の特定の言語でのテキストの表示など、シナリオによっては、他のフォントを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="01261-110">You might use other fonts for certain scenarios, such as reading, or when displaying text in certain non-English languages.</span></span> 
 
## <a name="sans-serif-fonts"></a><span data-ttu-id="01261-111">サンセリフ フォント</span><span class="sxs-lookup"><span data-stu-id="01261-111">Sans-serif fonts</span></span>

<span data-ttu-id="01261-112">サンセリフ フォントは、ヘッダーと UI 要素に適しています。</span><span class="sxs-lookup"><span data-stu-id="01261-112">Sans-serif fonts are a great choice for headings and UI elements.</span></span> 

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="01261-113">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="01261-113">Font-family</span></span></th>
<th align="left"><span data-ttu-id="01261-114">スタイル</span><span class="sxs-lookup"><span data-stu-id="01261-114">Styles</span></span></th>
<th align="left"><span data-ttu-id="01261-115">コメント</span><span class="sxs-lookup"><span data-stu-id="01261-115">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left" style="font-family: Arial;"><span data-ttu-id="01261-116">Arial</span><span class="sxs-lookup"><span data-stu-id="01261-116">Arial</span></span></td>
<td align="left"><span data-ttu-id="01261-117">標準、斜体、太字、太字斜体、黒</span><span class="sxs-lookup"><span data-stu-id="01261-117">Regular, Italic, Bold, Bold Italic, Black</span></span></td>
<td align="left"><span data-ttu-id="01261-118">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。極太の太さがサポートされているのはヨーロッパのスクリプトだけです。</span><span class="sxs-lookup"><span data-stu-id="01261-118">Supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic, Armenian, and Hebrew) Black weight supports European scripts only.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Calibri;"><span data-ttu-id="01261-119">Calibri</span><span class="sxs-lookup"><span data-stu-id="01261-119">Calibri</span></span></td>
<td align="left"><span data-ttu-id="01261-120">標準、斜体、太字、太字斜体、細字、細字斜体</span><span class="sxs-lookup"><span data-stu-id="01261-120">Regular, Italic, Bold, Bold Italic, Light, Light Italic</span></span></td>
<td align="left"><span data-ttu-id="01261-121">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア語、ヘブライ語) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="01261-121">Supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic and Hebrew).</span></span> <span data-ttu-id="01261-122">アラビア語は縦書きでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="01261-122">Arabic available in the uprights only.</span></span></td>
</tr>
<td style="font-family: Consolas;"><span data-ttu-id="01261-123">Consolas</span><span class="sxs-lookup"><span data-stu-id="01261-123">Consolas</span></span></td>
<td><span data-ttu-id="01261-124">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="01261-124">Regular, Italic, Bold, Bold Italic</span></span></td>
<td><span data-ttu-id="01261-125">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートする等幅フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-125">Fixed width font that supports European scripts (Latin, Greek and Cyrillic).</span></span></td>
</tr>

<tr>
<td style="font-family: Segoe UI;"><span data-ttu-id="01261-126">Segoe UI</span><span class="sxs-lookup"><span data-stu-id="01261-126">Segoe UI</span></span></td>
<td><span data-ttu-id="01261-127">標準、斜体、細字斜体、極太斜体、太字、太字斜体、細字、中細、中太、極太</span><span class="sxs-lookup"><span data-stu-id="01261-127">Regular, Italic, Light Italic, Black Italic, Bold, Bold Italic, Light, Semilight, Semibold, Black</span></span></td>
<td><span data-ttu-id="01261-128">ヨーロッパおよび中東のスクリプト (アラビア文字、アルメニア文字、キリル文字、ジョージア文字、ギリシャ文字、ヘブライ文字、ラテン文字) およびリス文字のスクリプト用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-128">User-interface font for European and Middle East scripts (Arabic, Armenian, Cyrillic, Georgian, Greek, Hebrew, Latin), and also Lisu script.</span></span></td>
</tr>

<tr class="odd">
<td><span data-ttu-id="01261-129">Segoe UI Historic</span><span class="sxs-lookup"><span data-stu-id="01261-129">Segoe UI Historic</span></span></td>
<td align="left"><span data-ttu-id="01261-130">標準</span><span class="sxs-lookup"><span data-stu-id="01261-130">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-131">歴史上のスクリプト用のフォールバック フォント</span><span class="sxs-lookup"><span data-stu-id="01261-131">Fallback font for historic scripts</span></span></td>
</tr>

<tr class="even">
<td style="font-family: Selawik;"><span data-ttu-id="01261-132">Selawik</span><span class="sxs-lookup"><span data-stu-id="01261-132">Selawik</span></span></td>
<td align="left"><span data-ttu-id="01261-133">標準、中細、細字、太字、中太</span><span class="sxs-lookup"><span data-stu-id="01261-133">Regular, Semilight, Light, Bold, Semibold</span></span></td>
<td align="left"><span data-ttu-id="01261-134">他のプラットフォーム上で動作する Segoe UI をバンドルしないアプリ向けの、Segoe UI と測定上の互換性があるオープン ソース フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-134">An open-source font that's metrically compatible with Segoe UI, intended for apps on other platforms that don’t want to bundle Segoe UI.</span></span> [<span data-ttu-id="01261-135">Selawik は、GitHub で入手できます。</span><span class="sxs-lookup"><span data-stu-id="01261-135">Get Selawik on GitHub.</span></span>](https://github.com/Microsoft/Selawik)</td>
</tr>

<tr class="even">
<td style="font-family: Verdana;"><span data-ttu-id="01261-136">Verdana</span><span class="sxs-lookup"><span data-stu-id="01261-136">Verdana</span></span></td>
<td align="left"><span data-ttu-id="01261-137">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="01261-137">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="01261-138">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字、アルメニア文字) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="01261-138">Supports European scripts (Latin, Greek, Cyrillic and Armenian).</span></span></td>
</tr>

</tbody>
</table>


## <a name="serif-fonts"></a><span data-ttu-id="01261-139">セリフ フォント</span><span class="sxs-lookup"><span data-stu-id="01261-139">Serif fonts</span></span>

<span data-ttu-id="01261-140">セリフ フォントは、大量のテキストを表示するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="01261-140">Serif fonts are good for presenting large amounts of text.</span></span> 

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="01261-141">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="01261-141">Font-family</span></span></th>
<th align="left"><span data-ttu-id="01261-142">スタイル</span><span class="sxs-lookup"><span data-stu-id="01261-142">Styles</span></span></th>
<th align="left"><span data-ttu-id="01261-143">コメント</span><span class="sxs-lookup"><span data-stu-id="01261-143">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="font-family: Cambria;"><span data-ttu-id="01261-144">Cambria</span><span class="sxs-lookup"><span data-stu-id="01261-144">Cambria</span></span></td>
<td align="left"><span data-ttu-id="01261-145">標準</span><span class="sxs-lookup"><span data-stu-id="01261-145">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-146">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートするセリフ フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-146">Serif font that supports European scripts (Latin, Greek, Cyrillic).</span></span></td>
</tr>
<tr class="even">
<td style="font-family: Courier New;"><span data-ttu-id="01261-147">Courier New</span><span class="sxs-lookup"><span data-stu-id="01261-147">Courier New</span></span></td>
<td align="left"><span data-ttu-id="01261-148">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="01261-148">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="01261-149">セリフ等幅フォントは、ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="01261-149">Serif fixed width font supports European and Middle Eastern scripts (Latin, Greek, Cyrillic, Arabic, Armenian, and Hebrew).</span></span></td>
</tr>
<tr class="odd">
<td style="font-family: Georgia;"><span data-ttu-id="01261-150">Georgia</span><span class="sxs-lookup"><span data-stu-id="01261-150">Georgia</span></span></td>
<td align="left"><span data-ttu-id="01261-151">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="01261-151">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="01261-152">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="01261-152">Supports European scripts (Latin, Greek and Cyrillic).</span></span></td>
</tr>


<tr class="even">
<td style="font-family: Times New Roman;"><span data-ttu-id="01261-153">Times New Roman</span><span class="sxs-lookup"><span data-stu-id="01261-153">Times New Roman</span></span></td>
<td align="left"><span data-ttu-id="01261-154">標準、斜体、太字、太字斜体</span><span class="sxs-lookup"><span data-stu-id="01261-154">Regular, Italic, Bold, Bold Italic</span></span></td>
<td align="left"><span data-ttu-id="01261-155">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしている従来のフォント。</span><span class="sxs-lookup"><span data-stu-id="01261-155">Legacy font that supports European scripts (Latin, Greek, Cyrillic, Arabic, Armenian, Hebrew).</span></span></td>
</tr>

</tbody>
</table>

## <a name="symbols-and-icons"></a><span data-ttu-id="01261-156">シンボルとアイコン</span><span class="sxs-lookup"><span data-stu-id="01261-156">Symbols and icons</span></span>


<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="01261-157">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="01261-157">Font-family</span></span></th>
<th align="left"><span data-ttu-id="01261-158">スタイル</span><span class="sxs-lookup"><span data-stu-id="01261-158">Styles</span></span></th>
<th align="left"><span data-ttu-id="01261-159">コメント</span><span class="sxs-lookup"><span data-stu-id="01261-159">Notes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="01261-160">Segoe MDL2 アセット</span><span class="sxs-lookup"><span data-stu-id="01261-160">Segoe MDL2 Assets</span></span></td>
<td align="left"><span data-ttu-id="01261-161">標準</span><span class="sxs-lookup"><span data-stu-id="01261-161">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-162">アプリ アイコン用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-162">User-interface font for app icons.</span></span> <span data-ttu-id="01261-163">詳しくは、[Segoe MDL2 アセットの記事](segoe-ui-symbol-font.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="01261-163">For more info, see the [Segoe MDL2 assets article](segoe-ui-symbol-font.md).</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="01261-164">Segoe UI Emoji</span><span class="sxs-lookup"><span data-stu-id="01261-164">Segoe UI Emoji</span></span></td>
<td align="left"><span data-ttu-id="01261-165">標準</span><span class="sxs-lookup"><span data-stu-id="01261-165">Regular</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="01261-166">Segoe UI Symbol</span><span class="sxs-lookup"><span data-stu-id="01261-166">Segoe UI Symbol</span></span></td>
<td align="left"><span data-ttu-id="01261-167">標準</span><span class="sxs-lookup"><span data-stu-id="01261-167">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-168">記号用のフォールバック フォント</span><span class="sxs-lookup"><span data-stu-id="01261-168">Fallback font for symbols</span></span></td>
</tr>
</tbody>
</table>



## <a name="fonts-for-non-latin-languages"></a><span data-ttu-id="01261-169">ラテン語以外の言語用のフォント</span><span class="sxs-lookup"><span data-stu-id="01261-169">Fonts for non-Latin languages</span></span>

<span data-ttu-id="01261-170">ただし、これらのフォントの多くでは、ラテン文字が提供されています。</span><span class="sxs-lookup"><span data-stu-id="01261-170">Although many of these fonts provide Latin characters.</span></span>

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="01261-171">フォント ファミリー</span><span class="sxs-lookup"><span data-stu-id="01261-171">Font-family</span></span></th>
<th align="left"><span data-ttu-id="01261-172">スタイル</span><span class="sxs-lookup"><span data-stu-id="01261-172">Styles</span></span></th>
<th align="left"><span data-ttu-id="01261-173">コメント</span><span class="sxs-lookup"><span data-stu-id="01261-173">Notes</span></span></th>
</tr>
</thead>
<tbody>

<tr class="odd">
<td style="font-family: Embrima;"><span data-ttu-id="01261-174">Ebrima</span><span class="sxs-lookup"><span data-stu-id="01261-174">Ebrima</span></span></td>
<td align="left"><span data-ttu-id="01261-175">標準、太字</span><span class="sxs-lookup"><span data-stu-id="01261-175">Regular, Bold</span></span></td>
<td align="left"><span data-ttu-id="01261-176">アフリカのスクリプト (エチオピア文字、ンコ文字、オスマニア文字、ティフィナグ文字、ヴァイ文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-176">User-interface font for African scripts (Ethiopic, N'Ko, Osmanya, Tifinagh, Vai).</span></span></td>
</tr>
<tr class="even">
<td style="font-family: Gadugi;"><span data-ttu-id="01261-177">Gadugi</span><span class="sxs-lookup"><span data-stu-id="01261-177">Gadugi</span></span></td>
<td align="left"><span data-ttu-id="01261-178">標準、太字</span><span class="sxs-lookup"><span data-stu-id="01261-178">Regular, Bold</span></span></td>
<td align="left"><span data-ttu-id="01261-179">北アメリカ スクリプト (カナダ音節文字、チェロキー文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-179">User-interface font for North American scripts (Canadian Syllabics, Cherokee).</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="01261-180">ジャワ文字のスクリプト用のジャワ文字のテキストの標準フォールバック フォント</span><span class="sxs-lookup"><span data-stu-id="01261-180">Javanese Text Regular Fallback font for Javanese script</span></span></td>
<td align="left"><span data-ttu-id="01261-181">標準</span><span class="sxs-lookup"><span data-stu-id="01261-181">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-182">ジャワ文字のスクリプト用のフォールバック フォント</span><span class="sxs-lookup"><span data-stu-id="01261-182">Fallback font for Javanese script</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Leelawadee UI;"><span data-ttu-id="01261-183">Leelawadee UI</span><span class="sxs-lookup"><span data-stu-id="01261-183">Leelawadee UI</span></span></td>
<td align="left"><span data-ttu-id="01261-184">通常、Semilight、太字</span><span class="sxs-lookup"><span data-stu-id="01261-184">Regular, Semilight, Bold</span></span></td>
<td align="left"><span data-ttu-id="01261-185">東南アジアのスクリプト (ブギス文字、ラオス文字、クメール文字、タイ文字) 用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-185">User-interface font for Southeast Asian scripts (Buginese, Lao, Khmer, Thai).</span></span></td>
</tr>

<tr class="odd">
<td align="left" style="font-family: Malgun Gothic;"><span data-ttu-id="01261-186">Malgun Gothic</span><span class="sxs-lookup"><span data-stu-id="01261-186">Malgun Gothic</span></span></td>
<td align="left"><span data-ttu-id="01261-187">標準</span><span class="sxs-lookup"><span data-stu-id="01261-187">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-188">韓国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-188">User-interface font for Korean.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft Himalaya;"><span data-ttu-id="01261-189">Microsoft Himalaya</span><span class="sxs-lookup"><span data-stu-id="01261-189">Microsoft Himalaya</span></span></td>
<td align="left"><span data-ttu-id="01261-190">標準</span><span class="sxs-lookup"><span data-stu-id="01261-190">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-191">チベット文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-191">Fallback font for Tibetan script.</span></span></td>
</tr>
<!--
<tr class="odd">
<td align="left" style="font-family: Microsoft JhengHei;">Microsoft JhengHei</td>
<td align="left">Regular</td>
<td align="left"></td>
</tr>
-->
<tr class="even">
<td align="left" style="font-family: Microsoft JhengHei UI;"><span data-ttu-id="01261-192">Microsoft JhengHei UI</span><span class="sxs-lookup"><span data-stu-id="01261-192">Microsoft JhengHei UI</span></span></td>
<td align="left"><span data-ttu-id="01261-193">標準、太字、細字</span><span class="sxs-lookup"><span data-stu-id="01261-193">Regular, Bold, Light</span></span></td>
<td align="left"><span data-ttu-id="01261-194">繁体字中国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-194">User-interface font for Traditional Chinese.</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Microsoft New Tai Lue;"><span data-ttu-id="01261-195">Microsoft New Tai Lue</span><span class="sxs-lookup"><span data-stu-id="01261-195">Microsoft New Tai Lue</span></span></td>
<td align="left"><span data-ttu-id="01261-196">標準</span><span class="sxs-lookup"><span data-stu-id="01261-196">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-197">新タイ ロ文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-197">Fallback font for New Tai Lue script.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft PhagsPa;"><span data-ttu-id="01261-198">Microsoft PhagsPa</span><span class="sxs-lookup"><span data-stu-id="01261-198">Microsoft PhagsPa</span></span></td>
<td align="left"><span data-ttu-id="01261-199">標準</span><span class="sxs-lookup"><span data-stu-id="01261-199">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-200">パスパ文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-200">Fallback font for Phags-pa script.</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Microsoft Tai Le;"><span data-ttu-id="01261-201">Microsoft Tai Le</span><span class="sxs-lookup"><span data-stu-id="01261-201">Microsoft Tai Le</span></span></td>
<td align="left"><span data-ttu-id="01261-202">標準</span><span class="sxs-lookup"><span data-stu-id="01261-202">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-203">タイ ロ文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-203">Fallback font for Tai Le script.</span></span></td>
</tr>
<!--
<tr class="even">
<td align="left" style="font-family: Microsoft YaHei;">Microsoft YaHei</td>
<td align="left">Regular</td>
<td align="left"></td>
</tr>
-->
<tr class="odd">
<td align="left" style="font-family: Microsoft YaHei UI;"><span data-ttu-id="01261-204">Microsoft YaHei UI</span><span class="sxs-lookup"><span data-stu-id="01261-204">Microsoft YaHei UI</span></span></td>
<td align="left"><span data-ttu-id="01261-205">標準、太字、細字</span><span class="sxs-lookup"><span data-stu-id="01261-205">Regular, Bold, Light</span></span></td>
<td align="left"><span data-ttu-id="01261-206">簡体字中国語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-206">User-interface font for Simplified Chinese.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft Yi Baiti;"><span data-ttu-id="01261-207">Microsoft Yi Baiti</span><span class="sxs-lookup"><span data-stu-id="01261-207">Microsoft Yi Baiti</span></span></td>
<td align="left"><span data-ttu-id="01261-208">標準</span><span class="sxs-lookup"><span data-stu-id="01261-208">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-209">イ文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-209">Fallback font for Yi script.</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Mongolian Baiti;"><span data-ttu-id="01261-210">Mongolian Baiti</span><span class="sxs-lookup"><span data-stu-id="01261-210">Mongolian Baiti</span></span></td>
<td align="left"><span data-ttu-id="01261-211">標準</span><span class="sxs-lookup"><span data-stu-id="01261-211">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-212">モンゴル文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-212">Fallback font for Mongolian script.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: MV Boli;"><span data-ttu-id="01261-213">MV Boli</span><span class="sxs-lookup"><span data-stu-id="01261-213">MV Boli</span></span></td>
<td align="left"><span data-ttu-id="01261-214">標準</span><span class="sxs-lookup"><span data-stu-id="01261-214">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-215">ターナ文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-215">Fallback font for Thaana script.</span></span></td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Myanmar Text;"><span data-ttu-id="01261-216">Myanmar Text</span><span class="sxs-lookup"><span data-stu-id="01261-216">Myanmar Text</span></span></td>
<td align="left"><span data-ttu-id="01261-217">標準</span><span class="sxs-lookup"><span data-stu-id="01261-217">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-218">ミャンマー文字のスクリプト用のフォールバック フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-218">Fallback font for Myanmar script.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Nirmala UI;"><span data-ttu-id="01261-219">Nirmala UI</span><span class="sxs-lookup"><span data-stu-id="01261-219">Nirmala UI</span></span></td>
<td align="left"><span data-ttu-id="01261-220">標準、中細、太字</span><span class="sxs-lookup"><span data-stu-id="01261-220">Regular, Semilight, Bold</span></span></td>
<td align="left"><span data-ttu-id="01261-221">南アジア言語のスクリプト (バングラ文字、デーバナーガリー文字、グジャラート文字、グルムキー文字、カンナダ文字、マラヤーラム文字、オディア文字、オル チキ文字、シンハラ文字、ソラング ソンペング文字、タミール文字、テルグ文字) 用のユーザー インターフェイス フォント</span><span class="sxs-lookup"><span data-stu-id="01261-221">User-interface font for South Asian scripts (Bangla, Devanagari, Gujarati, Gurmukhi, Kannada, Malayalam, Odia, Ol Chiki, Sinhala, Sora Sompeng, Tamil, Telugu)</span></span></td>
</tr>

<tr class="odd">
<td align="left" style="font-family: SimSun;"><span data-ttu-id="01261-222">SimSun</span><span class="sxs-lookup"><span data-stu-id="01261-222">SimSun</span></span></td>
<td align="left"><span data-ttu-id="01261-223">標準</span><span class="sxs-lookup"><span data-stu-id="01261-223">Regular</span></span></td>
<td align="left"><span data-ttu-id="01261-224">中国語繁体字の UI フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-224">A legacy Chinese UI font.</span></span> </td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Yu Gothic;"><span data-ttu-id="01261-225">Yu Gothic</span><span class="sxs-lookup"><span data-stu-id="01261-225">Yu Gothic</span></span></td>
<td align="left"><span data-ttu-id="01261-226">細字、標準、中字、太字</span><span class="sxs-lookup"><span data-stu-id="01261-226">Light, Regular, Medium, Bold</span></span></td>
<td align="left"><span data-ttu-id="01261-227">本文のテキストおよび類似したコンテンツに Yu Gothic 中字を使用します。</span><span class="sxs-lookup"><span data-stu-id="01261-227">Use Yu Gothic Medium for body text and similar content.</span></span></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Yu Gothic UI;"><span data-ttu-id="01261-228">Yu Gothic UI</span><span class="sxs-lookup"><span data-stu-id="01261-228">Yu Gothic UI</span></span></td>
<td align="left"><span data-ttu-id="01261-229">細字、中細、標準、中太、太字</span><span class="sxs-lookup"><span data-stu-id="01261-229">Light, Semilight, Regular, Semibold, Bold</span></span></td>
<td align="left"><span data-ttu-id="01261-230">日本語用のユーザー インターフェイス フォント。</span><span class="sxs-lookup"><span data-stu-id="01261-230">User-interface font for Japanese.</span></span></td>
</tr>
</tbody>
</table>


## <a name="globalizinglocalizing-fonts"></a><span data-ttu-id="01261-231">フォントのグローバリゼーション/ローカライズ</span><span class="sxs-lookup"><span data-stu-id="01261-231">Globalizing/localizing fonts</span></span>
<span data-ttu-id="01261-232">特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[LanguageFont フォント マッピング API](https://msdn.microsoft.com/library/windows/apps/br206864) を使ってください。</span><span class="sxs-lookup"><span data-stu-id="01261-232">Use the [LanguageFont font-mapping APIs](https://msdn.microsoft.com/library/windows/apps/br206864) for programmatic access to the recommended font family, size, weight, and style for a particular language.</span></span> <span data-ttu-id="01261-233">LanguageFont オブジェクトを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="01261-233">The LanguageFont object provides access to the correct font info for various categories of content including UI headers, notifications, body text, and user-editable document body fonts.</span></span> <span data-ttu-id="01261-234">詳しくは、「[レイアウトとグローバリゼーションをサポートするフォントの調整](https://msdn.microsoft.com/windows/uwp/globalizing/adjust-layout-and-fonts--and-support-rtl)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="01261-234">For more info, see [Adjusting layout and fonts to support globalization](https://msdn.microsoft.com/windows/uwp/globalizing/adjust-layout-and-fonts--and-support-rtl).</span></span>


## <a name="get-the-samples"></a><span data-ttu-id="01261-235">サンプルの入手</span><span class="sxs-lookup"><span data-stu-id="01261-235">Get the samples</span></span>

* [<span data-ttu-id="01261-236">ダウンロード可能なフォントのサンプル</span><span class="sxs-lookup"><span data-stu-id="01261-236">Downloadable fonts sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlCloudFontIntegration)
* [<span data-ttu-id="01261-237">UI の基本のサンプル</span><span class="sxs-lookup"><span data-stu-id="01261-237">UI basics sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)
* [<span data-ttu-id="01261-238">DirectWrite を使用した行間のサンプル</span><span class="sxs-lookup"><span data-stu-id="01261-238">Line spacing with DirectWrite sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/DWriteLineSpacingModes) 

## <a name="related-articles"></a><span data-ttu-id="01261-239">関連記事</span><span class="sxs-lookup"><span data-stu-id="01261-239">Related articles</span></span>

* [<span data-ttu-id="01261-240">レイアウトとグローバリゼーションをサポートするフォントの調整</span><span class="sxs-lookup"><span data-stu-id="01261-240">Adjusting layout and fonts to support globalization</span></span>](https://msdn.microsoft.com/windows/uwp/globalizing/adjust-layout-and-fonts--and-support-rtl)
* [<span data-ttu-id="01261-241">Segoe MDL2</span><span class="sxs-lookup"><span data-stu-id="01261-241">Segoe MDL2</span></span>](segoe-ui-symbol-font.md)
* [<span data-ttu-id="01261-242">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="01261-242">Text controls)</span></span>](../controls-and-patterns/text-controls.md)
* [<span data-ttu-id="01261-243">XAML テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="01261-243">XAML theme resources</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187274)

 

 




