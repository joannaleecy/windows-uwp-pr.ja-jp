---
Description: ユーザーに操作の実行を指示する前に、ヒントを使ってコントロールに関する詳しい情報を表示します。
title: ヒント
ms.assetid: A21BB12B-301E-40C9-B84B-C055FD43D307
label: Tooltips
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: yulikl
design-contact: kimsea
dev-contact: stpete
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 80591abb1e3130540ea94bc1f8d2602b90edc590
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613667"
---
# <a name="tooltips"></a><span data-ttu-id="2feb7-104">ヒント</span><span class="sxs-lookup"><span data-stu-id="2feb7-104">Tooltips</span></span>

<span data-ttu-id="2feb7-105">ヒントは、他のコントロールまたはオブジェクトにリンクされた短い説明です。</span><span class="sxs-lookup"><span data-stu-id="2feb7-105">A tooltip is a short description that is linked to another control or object.</span></span> <span data-ttu-id="2feb7-106">ヒントを使うと、UI では直接説明されていない、なじみのないオブジェクトをユーザーが理解しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-106">Tooltips help users understand unfamiliar objects that aren't described directly in the UI.</span></span> <span data-ttu-id="2feb7-107">ヒントは、ユーザーがコントロールにフォーカスを移動する、コントロール上で長押しする、またはマウス ポインターをコントロール上にホバーすると、自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-107">They display automatically when the user moves focus to, presses and holds, or hovers the mouse pointer over a control.</span></span> <span data-ttu-id="2feb7-108">また、ヒントは数秒経過するか、ユーザーが指、ポインター、またはキーボード/ゲームパッドのフォーカスを移動すると消えます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-108">The tooltip disappears after a few seconds, or when the user moves the finger, pointer or keyboard/gamepad focus.</span></span>

![ヒント](images/controls/tool-tip.png)

> <span data-ttu-id="2feb7-110">**重要な API**:[ツールヒント クラス](/uwp/api/Windows.UI.Xaml.Controls.ToolTip)、 [ToolTipService クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltipservice)</span><span class="sxs-lookup"><span data-stu-id="2feb7-110">**Important APIs**: [ToolTip class](/uwp/api/Windows.UI.Xaml.Controls.ToolTip), [ToolTipService class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltipservice)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="2feb7-111">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="2feb7-111">Is this the right control?</span></span>

<span data-ttu-id="2feb7-112">ユーザーに操作の実行を指示する前に、ヒントを使ってコントロールに関する詳しい情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-112">Use a tooltip to reveal more info about a control before asking the user to perform an action.</span></span> <span data-ttu-id="2feb7-113">ヒントは慎重に使い、タスクを完了しようとしているユーザーにとって明らかに重要である場合にのみ追加します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-113">Tooltips should be used sparingly, and only when they are adding distinct value for the user who is trying to complete a task.</span></span> <span data-ttu-id="2feb7-114">1 つの目安は、情報が同じエクスペリエンスのどこかで入手できる場合、ヒントは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="2feb7-114">One rule of thumb is that if the information is available elsewhere in the same experience, you do not need a tooltip.</span></span> <span data-ttu-id="2feb7-115">価値あるヒントによって、不明瞭な操作を明確にします。</span><span class="sxs-lookup"><span data-stu-id="2feb7-115">A valuable tooltip will clarify an unclear action.</span></span>

<span data-ttu-id="2feb7-116">ヒントはどのような場合に使えばよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="2feb7-116">When should you use a tooltip?</span></span> <span data-ttu-id="2feb7-117">それを判断するには、以下の質問を考えます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-117">To decide, consider these questions:</span></span>

- <span data-ttu-id="2feb7-118">**ポインターのポインターを合わせるとベースの情報が表示される必要がありますか。**</span><span class="sxs-lookup"><span data-stu-id="2feb7-118">**Should info become visible based on pointer hover?**</span></span>
    <span data-ttu-id="2feb7-119">そうでない場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="2feb7-119">If not, use another control.</span></span> <span data-ttu-id="2feb7-120">ヒントは、ユーザーの操作の結果としてのみ表示します。自動的には表示しません。</span><span class="sxs-lookup"><span data-stu-id="2feb7-120">Display tips only as the result of user interaction, never display them on their own.</span></span>

- <span data-ttu-id="2feb7-121">**コントロールには、テキスト ラベルがありますか。**</span><span class="sxs-lookup"><span data-stu-id="2feb7-121">**Does a control have a text label?**</span></span>
    <span data-ttu-id="2feb7-122">ない場合は、ヒントを使ってラベルを表示します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-122">If not, use a tooltip to provide the label.</span></span> <span data-ttu-id="2feb7-123">UX の設計では、ほとんどのコントロールにインラインでラベルを付けることをお勧めします。それらのコントロールには、ヒントは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="2feb7-123">It is a good UX design practice to label most controls inline and for these you don't need tooltips.</span></span> <span data-ttu-id="2feb7-124">アイコンだけが表示されるツール バー コントロールとコマンド ボタンには、ヒントが必要です。</span><span class="sxs-lookup"><span data-stu-id="2feb7-124">Toolbar controls and command buttons showing only icons need tooltips.</span></span>

- <span data-ttu-id="2feb7-125">**オブジェクトは、これ以上の情報の説明から特典教えてください。**</span><span class="sxs-lookup"><span data-stu-id="2feb7-125">**Does an object benefit from a description or further info?**</span></span>
    <span data-ttu-id="2feb7-126">そうであれば、ヒントを使います。</span><span class="sxs-lookup"><span data-stu-id="2feb7-126">If so, use a tooltip.</span></span> <span data-ttu-id="2feb7-127">ただし、このテキストは、主要なタスクに必須なものではなく、補助的なものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-127">But the text must be supplemental — that is, not essential to the primary tasks.</span></span> <span data-ttu-id="2feb7-128">必須なものであれば、直接 UI に配置して、ユーザーが探さなくても済むようにします。</span><span class="sxs-lookup"><span data-stu-id="2feb7-128">If it is essential, put it directly in the UI so that users don't have to discover or hunt for it.</span></span>

- <span data-ttu-id="2feb7-129">**補足情報と、エラー、警告、または状態は**</span><span class="sxs-lookup"><span data-stu-id="2feb7-129">**Is the supplemental info an error, warning, or status?**</span></span>
    <span data-ttu-id="2feb7-130">その場合は、ポップアップなど、他の UI 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="2feb7-130">If so, use another UI element, such as a flyout.</span></span>

- <span data-ttu-id="2feb7-131">**ユーザーは、チップと対話する必要がありますか。**</span><span class="sxs-lookup"><span data-stu-id="2feb7-131">**Do users need to interact with the tip?**</span></span>
    <span data-ttu-id="2feb7-132">その場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="2feb7-132">If so, use another control.</span></span> <span data-ttu-id="2feb7-133">ヒントはマウスを動かすと消えるため、ユーザーはヒントを操作できません。</span><span class="sxs-lookup"><span data-stu-id="2feb7-133">Users can't interact with tips because moving the mouse makes them disappear.</span></span>

- <span data-ttu-id="2feb7-134">**ユーザーは、補足情報を印刷する必要がありますか。**</span><span class="sxs-lookup"><span data-stu-id="2feb7-134">**Do users need to print the supplemental info?**</span></span>
    <span data-ttu-id="2feb7-135">その場合は、別のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="2feb7-135">If so, use another control.</span></span>

- <span data-ttu-id="2feb7-136">**ユーザーは増やしたり、いたずらのヒントを検索しますか。**</span><span class="sxs-lookup"><span data-stu-id="2feb7-136">**Will users find the tips annoying or distracting?**</span></span>
    <span data-ttu-id="2feb7-137">その場合は、別の手段を使うことを検討します。何もしない、という選択肢もあります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-137">If so, consider using another solution — including doing nothing at all.</span></span> <span data-ttu-id="2feb7-138">煩わしいと感じる可能性があってもヒントを使う場合は、ユーザーがヒントをオフにできるようにします。</span><span class="sxs-lookup"><span data-stu-id="2feb7-138">If you do use tips where they might be distracting, allow users to turn them off.</span></span>

## <a name="example"></a><span data-ttu-id="2feb7-139">例</span><span class="sxs-lookup"><span data-stu-id="2feb7-139">Example</span></span>

<table>
<th align="left"><span data-ttu-id="2feb7-140">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="2feb7-140">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="2feb7-141"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/ToolTip">アプリを開き、ToolTip の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="2feb7-141">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/ToolTip">open the app and see the ToolTip in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="2feb7-142"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></span><span class="sxs-lookup"><span data-stu-id="2feb7-142"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="2feb7-143"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></span><span class="sxs-lookup"><span data-stu-id="2feb7-143"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="2feb7-144">Bing 地図アプリのヒントです。</span><span class="sxs-lookup"><span data-stu-id="2feb7-144">A tooltip in the Bing Maps app.</span></span>

![Bing Maps アプリのヒントです](images/control-examples/tool-tip-maps.png)

## <a name="create-a-tooltip"></a><span data-ttu-id="2feb7-146">ToolTip の作成</span><span class="sxs-lookup"><span data-stu-id="2feb7-146">Create a tooltip</span></span>

<span data-ttu-id="2feb7-147">[ToolTip](/uwp/api/Windows.UI.Xaml.Controls.ToolTip) は、その所有者である別の UI 要素に割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-147">A [ToolTip](/uwp/api/Windows.UI.Xaml.Controls.ToolTip) must be assigned to another UI element that is its owner.</span></span> <span data-ttu-id="2feb7-148">[ToolTipService](/uwp/api/windows.ui.xaml.controls.tooltipservice) クラスは静的メソッドを提供し、ToolTip を表示します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-148">The [ToolTipService](/uwp/api/windows.ui.xaml.controls.tooltipservice) class provides static methods to display a ToolTip.</span></span>

<span data-ttu-id="2feb7-149">XAML では、**ToolTipService.Tooltip** 添付プロパティを使用して ToolTip を所有者に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-149">In XAML, use the **ToolTipService.Tooltip** attached property to assign the ToolTip to an owner.</span></span>

```xaml
<Button Content="Submit" ToolTipService.ToolTip="Click to submit"/>
```

<span data-ttu-id="2feb7-150">コードで、[ToolTipService.SetToolTip](/uwp/api/windows.ui.xaml.controls.tooltipservice.settooltip) メソッドを使用して ToolTip を所有者に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-150">In code, use the [ToolTipService.SetToolTip](/uwp/api/windows.ui.xaml.controls.tooltipservice.settooltip) method to assign the ToolTip to an owner.</span></span>

```xaml
<Button x:Name="submitButton" Content="Submit"/>
```

```csharp
ToolTip toolTip = new ToolTip();
toolTip.Content = "Click to submit";
ToolTipService.SetToolTip(submitButton, toolTip);
```

### <a name="content"></a><span data-ttu-id="2feb7-151">Content</span><span class="sxs-lookup"><span data-stu-id="2feb7-151">Content</span></span>

<span data-ttu-id="2feb7-152">任意のオブジェクトを ToolTip の[コンテンツ](/uwp/api/windows.ui.xaml.controls.contentcontrol.content)として使用できます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-152">You can use any object as the [Content](/uwp/api/windows.ui.xaml.controls.contentcontrol.content) of a ToolTip.</span></span> <span data-ttu-id="2feb7-153">ToolTip で[イメージ](/uwp/api/windows.ui.xaml.controls.image)を使用する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-153">Here's an example of using an [Image](/uwp/api/windows.ui.xaml.controls.image) in a ToolTip.</span></span>

```xaml
<TextBlock Text="store logo">
    <ToolTipService.ToolTip>
        <Image Source="Assets/StoreLogo.png"/>
    </ToolTipService.ToolTip>
</TextBlock>
```

### <a name="placement"></a><span data-ttu-id="2feb7-154">配置</span><span class="sxs-lookup"><span data-stu-id="2feb7-154">Placement</span></span>

<span data-ttu-id="2feb7-155">既定では、ToolTip はポインターの上部に中央揃えで表示されます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-155">By default, a ToolTip is displayed centered above the pointer.</span></span> <span data-ttu-id="2feb7-156">配置はアプリ ウィンドウによって制約されていないため、ToolTip が部分的に表示されたり、完全にアプリ ウィンドウの境界の外部に表示されたりすることがあります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-156">The placement is not constrained by the app window, so the ToolTip might be displayed partially or completely outside of the app window bounds.</span></span>

<span data-ttu-id="2feb7-157">広範な調整は、使用、[配置](/uwp/api/windows.ui.xaml.controls.tooltip.placement)プロパティまたは**ToolTipService.Placement**添付プロパティを上、左、下、またはポインターの右にツールヒントを描画する必要があるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-157">For broad adjustments, use the [Placement](/uwp/api/windows.ui.xaml.controls.tooltip.placement) property or **ToolTipService.Placement** attached property to specify whether the ToolTip should draw above, below, left, or right of the pointer.</span></span> <span data-ttu-id="2feb7-158">設定することができます、 [VerticalOffset](/uwp/api/windows.ui.xaml.controls.tooltip.verticaloffset)または[HorizontalOffset](/uwp/api/windows.ui.xaml.controls.tooltip.horizontaloffset)プロパティをポインターと、ツールヒントの間の距離を変更します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-158">You can set the [VerticalOffset](/uwp/api/windows.ui.xaml.controls.tooltip.verticaloffset) or [HorizontalOffset](/uwp/api/windows.ui.xaml.controls.tooltip.horizontaloffset) properties to change the distance between the pointer and the ToolTip.</span></span> <span data-ttu-id="2feb7-159">2 つのオフセット値の 1 つだけ配置のままにすると配置は、上部または下部にある HorizontalOffset と verticaloffset があるか、右の最後の位置に影響します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-159">Only one of the two offset values will influence the final position - VerticalOffset when Placement is Top or Bottom, HorizontalOffset when Placement is Left or Right.</span></span>

```xaml
<!-- An Image with an offset ToolTip. -->
<Image Source="Assets/StoreLogo.png">
    <ToolTipService.ToolTip>
        <ToolTip Content="Offset ToolTip."
                 Placement="Right"
                 HorizontalOffset="20"/>
    </ToolTipService.ToolTip>
</Image>
```

<span data-ttu-id="2feb7-160">正確に新しいを使用して、配置を調整するには、ツールヒントを参照しているコンテンツが隠れる場合、 **PlacementRect**プロパティ。</span><span class="sxs-lookup"><span data-stu-id="2feb7-160">If a ToolTip obscures the content it is referring to, you can adjust its placement precisely using the new **PlacementRect** property.</span></span> <span data-ttu-id="2feb7-161">PlacementRect は、ツールヒントの位置に固定し、この領域の外側にツールヒントを描画するための十分な画面領域が提供される、ツールヒントがありませんが、領域としても機能します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-161">PlacementRect anchors the ToolTip's position and also serves as an area that ToolTip will not occlude, provided there’s sufficient screen space to draw ToolTip outside this area.</span></span> <span data-ttu-id="2feb7-162">ツールヒントの所有者、および高さの相対的な四角形の原点と、排他領域の幅を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-162">You can specify the origin of the rectangle relative to the ToolTip’s owner, and the height and width of the exclusion area.</span></span> <span data-ttu-id="2feb7-163">[配置](/uwp/api/windows.ui.xaml.controls.tooltip.placement)プロパティは、上、左、下、または、PlacementRect の右にツールヒントが描画する場合を定義します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-163">The [Placement](/uwp/api/windows.ui.xaml.controls.tooltip.placement) property will define if ToolTip should draw above, below, left, or right of the PlacementRect.</span></span> 

```xaml
<!-- An Image with a non-occluding ToolTip. -->
<Image Source="Assets/StoreLogo.png" Height="64" Width="96">
    <ToolTipService.ToolTip>
        <ToolTip Content="Non-occluding ToolTip."
                 PlacementRect="0,0,96,64"/>
    </ToolTipService.ToolTip>
</Image>
```

## <a name="recommendations"></a><span data-ttu-id="2feb7-164">推奨事項</span><span class="sxs-lookup"><span data-stu-id="2feb7-164">Recommendations</span></span>

- <span data-ttu-id="2feb7-165">ヒントは慎重に使います (または使わない)。</span><span class="sxs-lookup"><span data-stu-id="2feb7-165">Use tooltips sparingly (or not at all).</span></span> <span data-ttu-id="2feb7-166">ヒントは作業の中断になります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-166">Tooltips are an interruption.</span></span> <span data-ttu-id="2feb7-167">ヒントはポップアップと同じように煩わしい場合があるため、大きな付加価値がない限り使わないでください。</span><span class="sxs-lookup"><span data-stu-id="2feb7-167">A tooltip can be as distracting as a pop-up, so don't use them unless they add significant value.</span></span>
- <span data-ttu-id="2feb7-168">ヒントのテキストは簡潔なものにします。</span><span class="sxs-lookup"><span data-stu-id="2feb7-168">Keep the tooltip text concise.</span></span> <span data-ttu-id="2feb7-169">ヒントは短い文やフレーズに適しています。</span><span class="sxs-lookup"><span data-stu-id="2feb7-169">Tooltips are perfect for short sentences and sentence fragments.</span></span> <span data-ttu-id="2feb7-170">大きなテキストのまとまりは圧迫感を与えることがあり、ユーザーが読み終える前にヒントがタイムアウトする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-170">Large blocks of text can be overwhelming and the tooltip may time out before the user has finished reading.</span></span>
- <span data-ttu-id="2feb7-171">役に立つ補足的なヒント テキストを作成します。</span><span class="sxs-lookup"><span data-stu-id="2feb7-171">Create helpful, supplemental tooltip text.</span></span> <span data-ttu-id="2feb7-172">ヒントのテキストは、情報として役に立つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-172">Tooltip text must be informative.</span></span> <span data-ttu-id="2feb7-173">表示しなくても明らかな情報や、既に画面上に表示されている内容の繰り返しなどは避けます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-173">Don't make it obvious or just repeat what is already on the screen.</span></span> <span data-ttu-id="2feb7-174">ヒントのテキストは常に表示されているわけではないため、ユーザーが必ずしも読まなくても問題がないような、補足的な情報である必要があります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-174">Because tooltip text isn't always visible, it should be supplemental info that users don't have to read.</span></span> <span data-ttu-id="2feb7-175">重要な情報は、名前から判別できるコントロール ラベルを使うか、補足的なテキストを適切な場所に配置することで伝えるようにします。</span><span class="sxs-lookup"><span data-stu-id="2feb7-175">Communicate important info using self-explanatory control labels or in-place supplemental text.</span></span>
- <span data-ttu-id="2feb7-176">状況に応じて画像を使います。</span><span class="sxs-lookup"><span data-stu-id="2feb7-176">Use images when appropriate.</span></span> <span data-ttu-id="2feb7-177">ヒント内に画像を使うとよい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="2feb7-177">Sometimes it's better to use an image in a tooltip.</span></span> <span data-ttu-id="2feb7-178">たとえば、ユーザーがハイパーリンクの上にカーソルを置いたときに、ヒントを使ってリンク先ページのプレビューを表示できます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-178">For example, when the user hovers over a hyperlink, you can use a tooltip to show a preview of the linked page.</span></span>
- <span data-ttu-id="2feb7-179">既に UI に表示されているテキストは、ヒントとして表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="2feb7-179">Don't use a tooltip to display text already visible in the UI.</span></span> <span data-ttu-id="2feb7-180">たとえば、ボタンと同じテキストを表示するヒントをボタンに表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="2feb7-180">For example, don't put a tooltip on a button that shows the same text of the button.</span></span>
- <span data-ttu-id="2feb7-181">ヒント内に対話的なコントロールを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="2feb7-181">Don't put interactive controls inside the tooltip.</span></span>
- <span data-ttu-id="2feb7-182">対話的に見えるような画像をヒント内に配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="2feb7-182">Don't put images that look like they are interactive inside the tooltip.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="2feb7-183">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="2feb7-183">Get the sample code</span></span>

- <span data-ttu-id="2feb7-184">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="2feb7-184">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="2feb7-185">関連記事</span><span class="sxs-lookup"><span data-stu-id="2feb7-185">Related articles</span></span>

- [<span data-ttu-id="2feb7-186">ツールヒント クラス</span><span class="sxs-lookup"><span data-stu-id="2feb7-186">ToolTip class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227608)
