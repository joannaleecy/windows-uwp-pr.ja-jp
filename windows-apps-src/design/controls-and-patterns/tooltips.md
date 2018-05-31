---
author: Jwmsft
Description: Use a tooltip to reveal more info about a control before asking the user to perform an action.
title: ヒント
ms.assetid: A21BB12B-301E-40C9-B84B-C055FD43D307
label: Tooltips
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: stpete
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: b60b06d9dbe8c0eb6216c2c909cc5184855056d5
ms.sourcegitcommit: 4b522af988273946414a04fbbd1d7fde40f8ba5e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/08/2018
ms.locfileid: "1493609"
---
# <a name="tooltips"></a><span data-ttu-id="3c18d-103">ヒント</span><span class="sxs-lookup"><span data-stu-id="3c18d-103">Tooltips</span></span>
 

<span data-ttu-id="3c18d-104">ヒントは、他のコントロールまたはオブジェクトにリンクされた短い説明です。</span><span class="sxs-lookup"><span data-stu-id="3c18d-104">A tooltip is a short description that is linked to another control or object.</span></span> <span data-ttu-id="3c18d-105">ヒントを使うと、UI では直接説明されていない、なじみのないオブジェクトをユーザーが理解しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="3c18d-105">Tooltips help users understand unfamiliar objects that aren't described directly in the UI.</span></span> <span data-ttu-id="3c18d-106">ヒントは、ユーザーがコントロールにフォーカスを移動する、コントロール上で長押しする、またはマウス ポインターをコントロール上にホバーすると、自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3c18d-106">They display automatically when the user moves focus to, presses and holds, or hovers the mouse pointer over a control.</span></span> <span data-ttu-id="3c18d-107">また、ヒントは数秒経過するか、ユーザーが指、ポインター、またはキーボード/ゲームパッドのフォーカスを移動すると消えます。</span><span class="sxs-lookup"><span data-stu-id="3c18d-107">The tooltip disappears after a few seconds, or when the user moves the finger, pointer or keyboard/gamepad focus.</span></span>

![ヒント](images/controls/tool-tip.png)

> <span data-ttu-id="3c18d-109">**重要な API**: [ToolTip クラス](https://msdn.microsoft.com/library/windows/apps/br227608)、[ToolTipService クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltipservice)</span><span class="sxs-lookup"><span data-stu-id="3c18d-109">**Important APIs**: [ToolTip class](https://msdn.microsoft.com/library/windows/apps/br227608), [ToolTipService class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltipservice)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="3c18d-110">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="3c18d-110">Is this the right control?</span></span>

<span data-ttu-id="3c18d-111">ユーザーに操作の実行を指示する前に、ヒントを使ってコントロールに関する詳しい情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="3c18d-111">Use a tooltip to reveal more info about a control before asking the user to perform an action.</span></span> <span data-ttu-id="3c18d-112">ヒントは慎重に使い、タスクを完了しようとしているユーザーにとって明らかに重要である場合にのみ追加します。</span><span class="sxs-lookup"><span data-stu-id="3c18d-112">Tooltips should be used sparingly, and only when they are adding distinct value for the user who is trying to complete a task.</span></span> <span data-ttu-id="3c18d-113">1 つの目安は、情報が同じエクスペリエンスのどこかで入手できる場合、ヒントは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="3c18d-113">One rule of thumb is that if the information is available elsewhere in the same experience, you do not need a tooltip.</span></span> <span data-ttu-id="3c18d-114">価値あるヒントによって、不明瞭な操作を明確にします。</span><span class="sxs-lookup"><span data-stu-id="3c18d-114">A valuable tooltip will clarify an unclear action.</span></span>

<span data-ttu-id="3c18d-115">ヒントはどのような場合に使えばよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="3c18d-115">When should you use a tooltip?</span></span> <span data-ttu-id="3c18d-116">それを判断するには、以下の質問を考えます。</span><span class="sxs-lookup"><span data-stu-id="3c18d-116">To decide, consider these questions:</span></span>

-   **<span data-ttu-id="3c18d-117">情報はポインターのホバーに基づいて表示すべきですか?</span><span class="sxs-lookup"><span data-stu-id="3c18d-117">Should info become visible based on pointer hover?</span></span>**
    <span data-ttu-id="3c18d-118">そうでない場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="3c18d-118">If not, use another control.</span></span> <span data-ttu-id="3c18d-119">ヒントは、ユーザーの操作の結果としてのみ表示します。自動的には表示しません。</span><span class="sxs-lookup"><span data-stu-id="3c18d-119">Display tips only as the result of user interaction, never display them on their own.</span></span>

-   **<span data-ttu-id="3c18d-120">コントロールにはテキスト ラベルがありますか?</span><span class="sxs-lookup"><span data-stu-id="3c18d-120">Does a control have a text label?</span></span>**
    <span data-ttu-id="3c18d-121">ない場合は、ヒントを使ってラベルを表示します。</span><span class="sxs-lookup"><span data-stu-id="3c18d-121">If not, use a tooltip to provide the label.</span></span> <span data-ttu-id="3c18d-122">UX の設計では、ほとんどのコントロールにインラインでラベルを付けることをお勧めします。それらのコントロールには、ヒントは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="3c18d-122">It is a good UX design practice to label most controls inline and for these you don't need tooltips.</span></span> <span data-ttu-id="3c18d-123">アイコンだけが表示されるツール バー コントロールとコマンド ボタンには、ヒントが必要です。</span><span class="sxs-lookup"><span data-stu-id="3c18d-123">Toolbar controls and command buttons showing only icons need tooltips.</span></span>

-   **<span data-ttu-id="3c18d-124">説明や追加情報がオブジェクトに対して役立ちますか?</span><span class="sxs-lookup"><span data-stu-id="3c18d-124">Does an object benefit from a description or further info?</span></span>**
    <span data-ttu-id="3c18d-125">そうであれば、ヒントを使います。</span><span class="sxs-lookup"><span data-stu-id="3c18d-125">If so, use a tooltip.</span></span> <span data-ttu-id="3c18d-126">ただし、このテキストは、主要なタスクに必須なものではなく、補助的なものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c18d-126">But the text must be supplemental — that is, not essential to the primary tasks.</span></span> <span data-ttu-id="3c18d-127">必須なものであれば、直接 UI に配置して、ユーザーが探さなくても済むようにします。</span><span class="sxs-lookup"><span data-stu-id="3c18d-127">If it is essential, put it directly in the UI so that users don't have to discover or hunt for it.</span></span>

-   **<span data-ttu-id="3c18d-128">表示する補助的な情報は、エラー、警告、または状態ですか?</span><span class="sxs-lookup"><span data-stu-id="3c18d-128">Is the supplemental info an error, warning, or status?</span></span>**
    <span data-ttu-id="3c18d-129">その場合は、ポップアップなど、他の UI 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="3c18d-129">If so, use another UI element, such as a flyout.</span></span>

-   **<span data-ttu-id="3c18d-130">ユーザーがヒントを操作する必要がありますか?</span><span class="sxs-lookup"><span data-stu-id="3c18d-130">Do users need to interact with the tip?</span></span>**
    <span data-ttu-id="3c18d-131">その場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="3c18d-131">If so, use another control.</span></span> <span data-ttu-id="3c18d-132">ヒントはマウスを動かすと消えるため、ユーザーはヒントを操作できません。</span><span class="sxs-lookup"><span data-stu-id="3c18d-132">Users can't interact with tips because moving the mouse makes them disappear.</span></span>

-   **<span data-ttu-id="3c18d-133">ユーザーが補助的な情報を印刷する必要がありますか?</span><span class="sxs-lookup"><span data-stu-id="3c18d-133">Do users need to print the supplemental info?</span></span>**
    <span data-ttu-id="3c18d-134">その場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="3c18d-134">If so, use another control.</span></span>

-   **<span data-ttu-id="3c18d-135">ユーザーがヒントを煩わしいと感じますか?</span><span class="sxs-lookup"><span data-stu-id="3c18d-135">Will users find the tips annoying or distracting?</span></span>**
    <span data-ttu-id="3c18d-136">その場合は、別の手段を使うことを検討します。何もしない、という選択肢もあります。</span><span class="sxs-lookup"><span data-stu-id="3c18d-136">If so, consider using another solution — including doing nothing at all.</span></span> <span data-ttu-id="3c18d-137">煩わしいと感じる可能性があってもヒントを使う場合は、ユーザーがヒントをオフにできるようにします。</span><span class="sxs-lookup"><span data-stu-id="3c18d-137">If you do use tips where they might be distracting, allow users to turn them off.</span></span>

## <a name="example"></a><span data-ttu-id="3c18d-138">例</span><span class="sxs-lookup"><span data-stu-id="3c18d-138">Example</span></span>

<table>
<th align="left"><span data-ttu-id="3c18d-139">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="3c18d-139">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="3c18d-140"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/ToolTip">アプリを開き、ToolTip の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="3c18d-140">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/ToolTip">open the app and see the ToolTip in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="3c18d-141">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="3c18d-141">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="3c18d-142">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="3c18d-142">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="3c18d-143">Bing 地図アプリのヒントです。</span><span class="sxs-lookup"><span data-stu-id="3c18d-143">A tooltip in the Bing Maps app.</span></span>

![Bing Maps アプリのヒントです](images/control-examples/tool-tip-maps.png)

## <a name="recommendations"></a><span data-ttu-id="3c18d-145">推奨事項</span><span class="sxs-lookup"><span data-stu-id="3c18d-145">Recommendations</span></span>

- <span data-ttu-id="3c18d-146">ヒントは慎重に使います (または使わない)。</span><span class="sxs-lookup"><span data-stu-id="3c18d-146">Use tooltips sparingly (or not at all).</span></span> <span data-ttu-id="3c18d-147">ヒントは作業の中断になります。</span><span class="sxs-lookup"><span data-stu-id="3c18d-147">Tooltips are an interruption.</span></span> <span data-ttu-id="3c18d-148">ヒントはポップアップと同じように煩わしい場合があるため、大きな付加価値がない限り使わないでください。</span><span class="sxs-lookup"><span data-stu-id="3c18d-148">A tooltip can be as distracting as a pop-up, so don't use them unless they add significant value.</span></span>
- <span data-ttu-id="3c18d-149">ヒントのテキストは簡潔なものにします。</span><span class="sxs-lookup"><span data-stu-id="3c18d-149">Keep the tooltip text concise.</span></span> <span data-ttu-id="3c18d-150">ヒントは短い文やフレーズに適しています。</span><span class="sxs-lookup"><span data-stu-id="3c18d-150">Tooltips are perfect for short sentences and sentence fragments.</span></span> <span data-ttu-id="3c18d-151">大きなテキストのまとまりは圧迫感を与えることがあり、ユーザーが読み終える前にヒントがタイムアウトする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3c18d-151">Large blocks of text can be overwhelming and the tooltip may time out before the user has finished reading.</span></span>
- <span data-ttu-id="3c18d-152">役に立つ補足的なヒント テキストを作成します。</span><span class="sxs-lookup"><span data-stu-id="3c18d-152">Create helpful, supplemental tooltip text.</span></span> <span data-ttu-id="3c18d-153">ヒントのテキストは、情報として役に立つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c18d-153">Tooltip text must be informative.</span></span> <span data-ttu-id="3c18d-154">表示しなくても明らかな情報や、既に画面上に表示されている内容の繰り返しなどは避けます。</span><span class="sxs-lookup"><span data-stu-id="3c18d-154">Don't make it obvious or just repeat what is already on the screen.</span></span> <span data-ttu-id="3c18d-155">ヒントのテキストは常に表示されているわけではないため、ユーザーが必ずしも読まなくても問題がないような、補足的な情報である必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c18d-155">Because tooltip text isn't always visible, it should be supplemental info that users don't have to read.</span></span> <span data-ttu-id="3c18d-156">重要な情報は、名前から判別できるコントロール ラベルを使うか、補足的なテキストを適切な場所に配置することで伝えるようにします。</span><span class="sxs-lookup"><span data-stu-id="3c18d-156">Communicate important info using self-explanatory control labels or in-place supplemental text.</span></span>
- <span data-ttu-id="3c18d-157">状況に応じて画像を使います。</span><span class="sxs-lookup"><span data-stu-id="3c18d-157">Use images when appropriate.</span></span> <span data-ttu-id="3c18d-158">ヒント内に画像を使うとよい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="3c18d-158">Sometimes it's better to use an image in a tooltip.</span></span> <span data-ttu-id="3c18d-159">たとえば、ユーザーがハイパーリンクの上にカーソルを置いたときに、ヒントを使ってリンク先ページのプレビューを表示できます。</span><span class="sxs-lookup"><span data-stu-id="3c18d-159">For example, when the user hovers over a hyperlink, you can use a tooltip to show a preview of the linked page.</span></span>
- <span data-ttu-id="3c18d-160">既に UI に表示されているテキストは、ヒントとして表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="3c18d-160">Don't use a tooltip to display text already visible in the UI.</span></span> <span data-ttu-id="3c18d-161">たとえば、ボタンと同じテキストを表示するヒントをボタンに表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="3c18d-161">For example, don't put a tooltip on a button that shows the same text of the button.</span></span>
- <span data-ttu-id="3c18d-162">ヒント内に対話的なコントロールを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="3c18d-162">Don't put interactive controls inside the tooltip.</span></span>
- <span data-ttu-id="3c18d-163">対話的に見えるような画像をヒント内に配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="3c18d-163">Don't put images that look like they are interactive inside the tooltip.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="3c18d-164">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="3c18d-164">Get the sample code</span></span>

- <span data-ttu-id="3c18d-165">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="3c18d-165">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="3c18d-166">関連記事</span><span class="sxs-lookup"><span data-stu-id="3c18d-166">Related articles</span></span>

- [<span data-ttu-id="3c18d-167">ToolTip クラス</span><span class="sxs-lookup"><span data-stu-id="3c18d-167">ToolTip class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227608)
