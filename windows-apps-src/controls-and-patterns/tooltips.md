---
author: Jwmsft
Description: "ユーザーに操作の実行を指示する前に、ヒントを使ってコントロールに関する詳しい情報を表示します。"
title: "ヒント"
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
ms.openlocfilehash: d5bde19c1d3dfba375b370cf8aed46979b6173f0
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="tooltips"></a><span data-ttu-id="71a66-104">ヒント</span><span class="sxs-lookup"><span data-stu-id="71a66-104">Tooltips</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="71a66-105">ヒントは、他のコントロールまたはオブジェクトにリンクされた短い説明です。</span><span class="sxs-lookup"><span data-stu-id="71a66-105">A tooltip is a short description that is linked to another control or object.</span></span> <span data-ttu-id="71a66-106">ヒントを使うと、UI では直接説明されていない、なじみのないオブジェクトをユーザーが理解しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="71a66-106">Tooltips help users understand unfamiliar objects that aren't described directly in the UI.</span></span> <span data-ttu-id="71a66-107">ヒントは、ユーザーがコントロールにフォーカスを移動する、コントロール上で長押しする、またはマウス ポインターをコントロール上にホバーすると、自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="71a66-107">They display automatically when the user moves focus to, presses and holds, or hovers the mouse pointer over a control.</span></span> <span data-ttu-id="71a66-108">また、ヒントは数秒経過するか、ユーザーが指、ポインター、またはキーボード/ゲームパッドのフォーカスを移動すると消えます。</span><span class="sxs-lookup"><span data-stu-id="71a66-108">The tooltip disappears after a few seconds, or when the user moves the finger, pointer or keyboard/gamepad focus.</span></span>

![ヒント](images/controls/tool-tip.png)

> <span data-ttu-id="71a66-110">**重要な API**: [ToolTip クラス](https://msdn.microsoft.com/library/windows/apps/br227608)、[ToolTipService クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltipservice)</span><span class="sxs-lookup"><span data-stu-id="71a66-110">**Important APIs**: [ToolTip class](https://msdn.microsoft.com/library/windows/apps/br227608), [ToolTipService class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltipservice)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="71a66-111">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="71a66-111">Is this the right control?</span></span>

<span data-ttu-id="71a66-112">ユーザーに操作の実行を指示する前に、ヒントを使ってコントロールに関する詳しい情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="71a66-112">Use a tooltip to reveal more info about a control before asking the user to perform an action.</span></span> <span data-ttu-id="71a66-113">ヒントは慎重に使い、タスクを完了しようとしているユーザーにとって明らかに重要である場合にのみ追加します。</span><span class="sxs-lookup"><span data-stu-id="71a66-113">Tooltips should be used sparingly, and only when they are adding distinct value for the user who is trying to complete a task.</span></span> <span data-ttu-id="71a66-114">1 つの目安は、情報が同じエクスペリエンスのどこかで入手できる場合、ヒントは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="71a66-114">One rule of thumb is that if the information is available elsewhere in the same experience, you do not need a tooltip.</span></span> <span data-ttu-id="71a66-115">価値あるヒントによって、不明瞭な操作を明確にします。</span><span class="sxs-lookup"><span data-stu-id="71a66-115">A valuable tooltip will clarify an unclear action.</span></span>

<span data-ttu-id="71a66-116">ヒントはどのような場合に使えばよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="71a66-116">When should you use a tooltip?</span></span> <span data-ttu-id="71a66-117">それを判断するには、以下の質問を考えます。</span><span class="sxs-lookup"><span data-stu-id="71a66-117">To decide, consider these questions:</span></span>

-   **<span data-ttu-id="71a66-118">情報はポインターのホバーに基づいて表示すべきですか?</span><span class="sxs-lookup"><span data-stu-id="71a66-118">Should info become visible based on pointer hover?</span></span>**
    <span data-ttu-id="71a66-119">そうでない場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="71a66-119">If not, use another control.</span></span> <span data-ttu-id="71a66-120">ヒントは、ユーザーの操作の結果としてのみ表示します。自動的には表示しません。</span><span class="sxs-lookup"><span data-stu-id="71a66-120">Display tips only as the result of user interaction, never display them on their own.</span></span>

-   **<span data-ttu-id="71a66-121">コントロールにはテキスト ラベルがありますか?</span><span class="sxs-lookup"><span data-stu-id="71a66-121">Does a control have a text label?</span></span>**
    <span data-ttu-id="71a66-122">ない場合は、ヒントを使ってラベルを表示します。</span><span class="sxs-lookup"><span data-stu-id="71a66-122">If not, use a tooltip to provide the label.</span></span> <span data-ttu-id="71a66-123">UX の設計では、ほとんどのコントロールにインラインでラベルを付けることをお勧めします。それらのコントロールには、ヒントは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="71a66-123">It is a good UX design practice to label most controls inline and for these you don't need tooltips.</span></span> <span data-ttu-id="71a66-124">アイコンだけが表示されるツール バー コントロールとコマンド ボタンには、ヒントが必要です。</span><span class="sxs-lookup"><span data-stu-id="71a66-124">Toolbar controls and command buttons showing only icons need tooltips.</span></span>

-   **<span data-ttu-id="71a66-125">説明や追加情報がオブジェクトに対して役立ちますか?</span><span class="sxs-lookup"><span data-stu-id="71a66-125">Does an object benefit from a description or further info?</span></span>**
    <span data-ttu-id="71a66-126">そうであれば、ヒントを使います。</span><span class="sxs-lookup"><span data-stu-id="71a66-126">If so, use a tooltip.</span></span> <span data-ttu-id="71a66-127">ただし、このテキストは、主要なタスクに必須なものではなく、補助的なものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="71a66-127">But the text must be supplemental — that is, not essential to the primary tasks.</span></span> <span data-ttu-id="71a66-128">必須なものであれば、直接 UI に配置して、ユーザーが探さなくても済むようにします。</span><span class="sxs-lookup"><span data-stu-id="71a66-128">If it is essential, put it directly in the UI so that users don't have to discover or hunt for it.</span></span>

-   **<span data-ttu-id="71a66-129">表示する補助的な情報は、エラー、警告、または状態ですか?</span><span class="sxs-lookup"><span data-stu-id="71a66-129">Is the supplemental info an error, warning, or status?</span></span>**
    <span data-ttu-id="71a66-130">その場合は、ポップアップなど、他の UI 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="71a66-130">If so, use another UI element, such as a flyout.</span></span>

-   **<span data-ttu-id="71a66-131">ユーザーがヒントを操作する必要がありますか?</span><span class="sxs-lookup"><span data-stu-id="71a66-131">Do users need to interact with the tip?</span></span>**
    <span data-ttu-id="71a66-132">その場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="71a66-132">If so, use another control.</span></span> <span data-ttu-id="71a66-133">ヒントはマウスを動かすと消えるため、ユーザーはヒントを操作できません。</span><span class="sxs-lookup"><span data-stu-id="71a66-133">Users can't interact with tips because moving the mouse makes them disappear.</span></span>

-   **<span data-ttu-id="71a66-134">ユーザーが補助的な情報を印刷する必要がありますか?</span><span class="sxs-lookup"><span data-stu-id="71a66-134">Do users need to print the supplemental info?</span></span>**
    <span data-ttu-id="71a66-135">その場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="71a66-135">If so, use another control.</span></span>

-   **<span data-ttu-id="71a66-136">ユーザーがヒントを煩わしいと感じますか?</span><span class="sxs-lookup"><span data-stu-id="71a66-136">Will users find the tips annoying or distracting?</span></span>**
    <span data-ttu-id="71a66-137">その場合は、別の手段を使うことを検討します。何もしない、という選択肢もあります。</span><span class="sxs-lookup"><span data-stu-id="71a66-137">If so, consider using another solution — including doing nothing at all.</span></span> <span data-ttu-id="71a66-138">煩わしいと感じる可能性があってもヒントを使う場合は、ユーザーがヒントをオフにできるようにします。</span><span class="sxs-lookup"><span data-stu-id="71a66-138">If you do use tips where they might be distracting, allow users to turn them off.</span></span>

## <a name="example"></a><span data-ttu-id="71a66-139">例</span><span class="sxs-lookup"><span data-stu-id="71a66-139">Example</span></span>

<span data-ttu-id="71a66-140">Bing Maps アプリのヒントです。</span><span class="sxs-lookup"><span data-stu-id="71a66-140">A tooltip in the Bing Maps app.</span></span>

![Bing Maps アプリのヒントです](images/control-examples/tool-tip-maps.png)

## <a name="recommendations"></a><span data-ttu-id="71a66-142">推奨事項</span><span class="sxs-lookup"><span data-stu-id="71a66-142">Recommendations</span></span>

-   <span data-ttu-id="71a66-143">ヒントは慎重に使います (または使わない)。</span><span class="sxs-lookup"><span data-stu-id="71a66-143">Use tooltips sparingly (or not at all).</span></span> <span data-ttu-id="71a66-144">ヒントは作業の中断になります。</span><span class="sxs-lookup"><span data-stu-id="71a66-144">Tooltips are an interruption.</span></span> <span data-ttu-id="71a66-145">ヒントはポップアップと同じように煩わしい場合があるため、大きな付加価値がない限り使わないでください。</span><span class="sxs-lookup"><span data-stu-id="71a66-145">A tooltip can be as distracting as a pop-up, so don't use them unless they add significant value.</span></span>
-   <span data-ttu-id="71a66-146">ヒントのテキストは簡潔なものにします。</span><span class="sxs-lookup"><span data-stu-id="71a66-146">Keep the tooltip text concise.</span></span> <span data-ttu-id="71a66-147">ヒントは短い文やフレーズに適しています。</span><span class="sxs-lookup"><span data-stu-id="71a66-147">Tooltips are perfect for short sentences and sentence fragments.</span></span> <span data-ttu-id="71a66-148">大きなテキストのまとまりは圧迫感を与えることがあり、ユーザーが読み終える前にヒントがタイムアウトする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="71a66-148">Large blocks of text can be overwhelming and the tooltip may time out before the user has finished reading.</span></span>
-   <span data-ttu-id="71a66-149">役に立つ補足的なヒント テキストを作成します。</span><span class="sxs-lookup"><span data-stu-id="71a66-149">Create helpful, supplemental tooltip text.</span></span> <span data-ttu-id="71a66-150">ヒントのテキストは、情報として役に立つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="71a66-150">Tooltip text must be informative.</span></span> <span data-ttu-id="71a66-151">表示しなくても明らかな情報や、既に画面上に表示されている内容の繰り返しなどは避けます。</span><span class="sxs-lookup"><span data-stu-id="71a66-151">Don't make it obvious or just repeat what is already on the screen.</span></span> <span data-ttu-id="71a66-152">ヒントのテキストは常に表示されているわけではないため、ユーザーが必ずしも読まなくても問題がないような、補足的な情報である必要があります。</span><span class="sxs-lookup"><span data-stu-id="71a66-152">Because tooltip text isn't always visible, it should be supplemental info that users don't have to read.</span></span> <span data-ttu-id="71a66-153">重要な情報は、名前から判別できるコントロール ラベルを使うか、補足的なテキストを適切な場所に配置することで伝えるようにします。</span><span class="sxs-lookup"><span data-stu-id="71a66-153">Communicate important info using self-explanatory control labels or in-place supplemental text.</span></span>
-   <span data-ttu-id="71a66-154">状況に応じて画像を使います。</span><span class="sxs-lookup"><span data-stu-id="71a66-154">Use images when appropriate.</span></span> <span data-ttu-id="71a66-155">ヒント内に画像を使うとよい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="71a66-155">Sometimes it's better to use an image in a tooltip.</span></span> <span data-ttu-id="71a66-156">たとえば、ユーザーがハイパーリンクの上にカーソルを置いたときに、ヒントを使ってリンク先ページのプレビューを表示できます。</span><span class="sxs-lookup"><span data-stu-id="71a66-156">For example, when the user hovers over a hyperlink, you can use a tooltip to show a preview of the linked page.</span></span>
-   <span data-ttu-id="71a66-157">既に UI に表示されているテキストは、ヒントとして表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="71a66-157">Don't use a tooltip to display text already visible in the UI.</span></span> <span data-ttu-id="71a66-158">たとえば、ボタンと同じテキストを表示するヒントをボタンに表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="71a66-158">For example, don't put a tooltip on a button that shows the same text of the button.</span></span>
-   <span data-ttu-id="71a66-159">ヒント内に対話的なコントロールを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="71a66-159">Don't put interactive controls inside the tooltip.</span></span>
-   <span data-ttu-id="71a66-160">対話的に見えるような画像をヒント内に配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="71a66-160">Don't put images that look like they are interactive inside the tooltip.</span></span>

<span data-ttu-id="71a66-161">関連トピック</span><span class="sxs-lookup"><span data-stu-id="71a66-161">Related topics</span></span>

* [<span data-ttu-id="71a66-162">ToolTip クラス</span><span class="sxs-lookup"><span data-stu-id="71a66-162">ToolTip class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227608)
