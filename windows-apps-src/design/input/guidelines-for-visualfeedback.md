---
author: Karl-Bridge-Microsoft
Description: Use visual feedback to show users when their interactions with a UWP app are detected, interpreted, and handled.
title: 視覚的なフィードバック
ms.assetid: bf2f3672-95f0-4c8c-9a72-0934f2d3b767
label: Visual feedback
template: detail.hbs
keywords: 視覚的なフィードバック, フォーカス フィードバック, タッチ フィードバック, 接触の視覚エフェクト, 入力, 操作
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 0a986d6de680a3024ae252ba640871f9c5d22141
ms.sourcegitcommit: 346b5c9298a6e9e78acf05944bfe13624ea7062e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/05/2018
ms.locfileid: "1707047"
---
# <a name="guidelines-for-visual-feedback"></a><span data-ttu-id="26f13-103">視覚的なフィードバックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="26f13-103">Guidelines for visual feedback</span></span>


<span data-ttu-id="26f13-104">視覚的なフィードバックは、対話式操作が検出、解釈、処理されていることをユーザーに示すために使います。</span><span class="sxs-lookup"><span data-stu-id="26f13-104">Use visual feedback to show users when their interactions are detected, interpreted, and handled.</span></span> <span data-ttu-id="26f13-105">視覚的なフィードバックは、対話式操作を促進することによってユーザーを支援します。</span><span class="sxs-lookup"><span data-stu-id="26f13-105">Visual feedback can help users by encouraging interaction.</span></span> <span data-ttu-id="26f13-106">対話式操作の成功を示すことによって、ユーザーのコントロール感を向上させます。</span><span class="sxs-lookup"><span data-stu-id="26f13-106">It indicates the success of an interaction, which improves the user's sense of control.</span></span> <span data-ttu-id="26f13-107">また、システム状態の中継やエラーの削減も可能になります。</span><span class="sxs-lookup"><span data-stu-id="26f13-107">It also relays system status and reduces errors.</span></span>

> <span data-ttu-id="26f13-108">**重要な API**: [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648)、[**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、[**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)</span><span class="sxs-lookup"><span data-stu-id="26f13-108">**Important APIs**:  [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648), [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084), [**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)</span></span>

## <a name="recommendations"></a><span data-ttu-id="26f13-109">推奨事項</span><span class="sxs-lookup"><span data-stu-id="26f13-109">Recommendations</span></span>

-   <span data-ttu-id="26f13-110">最適なコントロールとアプリケーションのパフォーマンスを確保するために、できるだけ、元のコントロール テンプレートに近い状態を維持してください。</span><span class="sxs-lookup"><span data-stu-id="26f13-110">Try to remain as close to the original control template as possible, for optimal control and application performance.</span></span>
-   <span data-ttu-id="26f13-111">タッチの視覚エフェクトがアプリの使用を妨げる可能性がある場合は、使わないでください。</span><span class="sxs-lookup"><span data-stu-id="26f13-111">Don't use touch visualizations in situations where they might interfere with the use of the app.</span></span> <span data-ttu-id="26f13-112">詳しくは、「[**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26f13-112">For more info, see [**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969).</span></span>
-   <span data-ttu-id="26f13-113">どうしても必要な場合以外は、フィードバックを表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="26f13-113">Don't display feedback unless it is absolutely necessary.</span></span> <span data-ttu-id="26f13-114">その場所でしか意味がない場合を除き、視覚的なフィードバックを表示せずに、UI の簡潔さを維持してください。</span><span class="sxs-lookup"><span data-stu-id="26f13-114">Keep the UI clean and uncluttered by not showing visual feedback unless you are adding value that is not available elsewhere.</span></span>
-   <span data-ttu-id="26f13-115">Windows の組み込みジェスチャの視覚的なフィードバックの動作は大幅にカスタマイズしないでください。この動作をカスタマイズすると、ユーザー エクスペリエンスに一貫性がなくなり、混乱する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="26f13-115">Try not to dramatically customize the visual feedback behaviors of the built-in Windows gestures, as this can create an inconsistent and confusing user experience.</span></span>

## <a name="additional-usage-guidance"></a><span data-ttu-id="26f13-116">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="26f13-116">Additional usage guidance</span></span>

<span data-ttu-id="26f13-117">正確性が求められるタッチ操作では、接触の視覚エフェクトが特に重要です。</span><span class="sxs-lookup"><span data-stu-id="26f13-117">Contact visualizations are especially critical for touch interactions that require accuracy and precision.</span></span> <span data-ttu-id="26f13-118">たとえば、アプリでタップの位置を正確に示し、対象から外れていたかどうか、どの程度外れていたか、合わせるにはどうすればよいかをユーザーが把握できるようする必要があります。</span><span class="sxs-lookup"><span data-stu-id="26f13-118">For example, your app should clearly indicate the location of a tap to let a user know if they missed their target, how much they missed it by, and what adjustments they must make.</span></span>

<span data-ttu-id="26f13-119">利用可能な既定の XAML プラットフォーム コントロールを使うと、すべてのデバイスおよびすべての入力状況でアプリが正しく動作します。</span><span class="sxs-lookup"><span data-stu-id="26f13-119">Using the default XAML platform controls available ensures that your app works correctly on all devices and in all input situations.</span></span> <span data-ttu-id="26f13-120">カスタマイズされたフィードバックが必要なカスタム操作をアプリに実装する場合は、そのフィードバックが適切であり、各入力デバイスでそのフィードバックが示されることを確認してください。また、フィードバックがユーザーの作業を妨げないようにする必要もあります。</span><span class="sxs-lookup"><span data-stu-id="26f13-120">If your app features custom interactions that require customized feedback, you should ensure the feedback is appropriate, spans input devices, and doesn't distract a user from their task.</span></span> <span data-ttu-id="26f13-121">このことは、視覚的なフィードバックが重要な UI と競合したり、重要な UI を隠したりする可能性があるゲームや描画アプリでは特に重要です。</span><span class="sxs-lookup"><span data-stu-id="26f13-121">This can be a particular issue in game or drawing apps, where the visual feedback might conflict with or obscure critical UI.</span></span>

> [!Important] 
> <span data-ttu-id="26f13-122">組み込みジェスチャの操作の動作を変更することはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="26f13-122">We don't recommend changing the interaction behavior of the built-in gestures.</span></span> 

**<span data-ttu-id="26f13-123">複数のデバイスにおけるフィードバック</span><span class="sxs-lookup"><span data-stu-id="26f13-123">Feedback Across Devices</span></span>**

<span data-ttu-id="26f13-124">視覚的なフィードバックは、一般に入力デバイス (タッチ、タッチバッド、マウス、ペン/スタイラス、キーボードなど) に依存します。</span><span class="sxs-lookup"><span data-stu-id="26f13-124">Visual feedback is generally dependent on the input device (touch, touchpad, mouse, pen/stylus, keyboard, and so on).</span></span> <span data-ttu-id="26f13-125">たとえば、マウスの組み込みフィードバックには、通常はカーソルの移動と変化が伴います。一方、タッチとペンの場合は接触の視覚エフェクトが必要です。キーボードによる入力とナビゲーションの場合は、フォーカス用の四角形と強調表示を使います。</span><span class="sxs-lookup"><span data-stu-id="26f13-125">For example, the built-in feedback for a mouse usually involves moving and changing the cursor, while touch and pen require contact visualizations, and keyboard input and navigation uses focus rectangles and highlighting.</span></span>

<span data-ttu-id="26f13-126">プラットフォーム ジェスチャのフィードバック動作を設定するには、[**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969) を使います。</span><span class="sxs-lookup"><span data-stu-id="26f13-126">Use [**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969) to set feedback behavior for the platform gestures.</span></span>

<span data-ttu-id="26f13-127">フィードバック UI をカスタマイズする場合は、すべての入力モードをサポートした適切なフィードバックを提供してください。</span><span class="sxs-lookup"><span data-stu-id="26f13-127">If customizing feedback UI, ensure you provide feedback that supports, and is suitable for, all input modes.</span></span>

<span data-ttu-id="26f13-128">Windows には、次のような接触の視覚エフェクトが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="26f13-128">Here are some examples of built-in contact visualizations in Windows.</span></span>

| ![タッチ フィードバック](images/TouchFeedback.png) | ![マウス フィードバック](images/MouseFeedback.png) | ![ペン フィードバック](images/PenFeedback.png) | ![キーボード フィードバック](images/KeyboardFeedback.png) |
| --- | --- | --- | --- |
| <span data-ttu-id="26f13-133">タッチの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="26f13-133">Touch visualization</span></span> | <span data-ttu-id="26f13-134">マウス/タッチパッドの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="26f13-134">Mouse/touchpad visualization</span></span> | <span data-ttu-id="26f13-135">ペンの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="26f13-135">Pen visualization</span></span> | <span data-ttu-id="26f13-136">キーボードの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="26f13-136">Keyboard visualization</span></span> |

## <a name="high-visibility-focus-visuals"></a><span data-ttu-id="26f13-137">視認性の高いフォーカスの視覚効果</span><span class="sxs-lookup"><span data-stu-id="26f13-137">High Visibility Focus Visuals</span></span>

<span data-ttu-id="26f13-138">すべての Windows アプリでは、定義済みのさまざまなフォーカスの視覚効果が、アプリケーション内にある対話可能なコントロールの周囲に示されます。</span><span class="sxs-lookup"><span data-stu-id="26f13-138">All Windows apps sport a more defined focus visual around interactable controls within the application.</span></span> <span data-ttu-id="26f13-139">新しいフォーカスの視覚効果は、すべてカスタマイズ可能であり、必要に応じて無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="26f13-139">These new focus visuals are fully customizable as well as disableable when needed.</span></span>

## <a name="color-branding--customizing"></a><span data-ttu-id="26f13-140">色のブランド化とカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="26f13-140">Color Branding & Customizing</span></span>

**<span data-ttu-id="26f13-141">境界線のプロパティ</span><span class="sxs-lookup"><span data-stu-id="26f13-141">Border Properties</span></span>**

<span data-ttu-id="26f13-142">視認性の高いフォーカスの視覚効果は、プライマリ境界線とセカンダリ境界線という 2 つの部分で構成されます。</span><span class="sxs-lookup"><span data-stu-id="26f13-142">There are two parts to the high visibility focus visuals: the primary border and the secondary border.</span></span> <span data-ttu-id="26f13-143">プライマリ境界線は、**2 px** の幅があり、セカンダリ境界線の*外側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="26f13-143">The primary border is **2px** thick, and runs around the *outside* of the secondary border.</span></span> <span data-ttu-id="26f13-144">セカンダリ境界線は、**1 px** の幅があり、プライマリ境界線の*内側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="26f13-144">The secondary border is **1px** thick and runs around the *inside* of the primary border.</span></span>
![視認性の高いフォーカスの視覚効果 (赤線で示されています)](images/FocusRectRedlines.png)

<span data-ttu-id="26f13-146">それぞれの境界線 (プライマリおよびセカンダリ) の太さを変更するには、**FocusVisualPrimaryThickness** をプライマリ境界線に対して使用し、 **FocusVisualSecondaryThickness** をセカンダリ境界線に対して使用します。</span><span class="sxs-lookup"><span data-stu-id="26f13-146">To change the thickness of either border type (primary or secondary) use the **FocusVisualPrimaryThickness** or **FocusVisualSecondaryThickness**, respectively:</span></span>
```XAML
<Slider Width="200" FocusVisualPrimaryThickness="5" FocusVisualSecondaryThickness="2"/>
```
![視認性の高いフォーカスの視覚効果における余白部分の太さ](images/FocusMargin.png)

<span data-ttu-id="26f13-148">余白は [**Thickness**](https://msdn.microsoft.com/library/system.windows.thickness) という種類のプロパティで指定されます。このため、コントロールの特定の側にのみ表示されるように、余白をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="26f13-148">The margin is a property of type [**Thickness**](https://msdn.microsoft.com/library/system.windows.thickness), and therefore the margin can be customized to appear only on certain sides of the control.</span></span> <span data-ttu-id="26f13-149">次をご覧ください。![視認性の高いフォーカスの視覚効果 (余白部分を下端にのみ表示)</span><span class="sxs-lookup"><span data-stu-id="26f13-149">See below: ![High visibility focus visual margin thickness bottom only</span></span>](images/FocusThicknessSide.png)

<span data-ttu-id="26f13-150">余白は、コントロールの視覚的な境界線と、フォーカスの視覚効果で示される*セカンダリ境界線*の開始点との間にあるスペースです。</span><span class="sxs-lookup"><span data-stu-id="26f13-150">The margin is the space between the control's visual bounds and the start of the focus visuals *secondary border*.</span></span> <span data-ttu-id="26f13-151">既定の余白は、コントロールの境界線から **1 px** の幅で描画されます。</span><span class="sxs-lookup"><span data-stu-id="26f13-151">The default margin is **1px** away from the control bounds.</span></span> <span data-ttu-id="26f13-152">この余白はコントロールごとに変更できます。それには、**FocusVisualMargin** プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="26f13-152">You can edit this margin on a per-control basis, by changing the **FocusVisualMargin** property:</span></span>
```XAML
<Slider Width="200" FocusVisualMargin="-5"/>
```
![視認性の高いフォーカスの視覚効果における余白の違い](images/FocusPlusMinusMargin.png)

*<span data-ttu-id="26f13-154">負の値で示される余白は、コントロールの中央から遠ざけるようにして境界線を描画し、正の値で示される余白は、コントロールの中央に近づけるようにして境界線を描画します。</span><span class="sxs-lookup"><span data-stu-id="26f13-154">A negative margin will push the border away from the center of the control, and a positive margin will move the border closer to the center of the control.</span></span>*

<span data-ttu-id="26f13-155">コントロールでフォーカスの視覚効果を完全に無効にするには、**UseSystemFocusVisuals** を無効にするだけです。</span><span class="sxs-lookup"><span data-stu-id="26f13-155">To turn off focus visuals on the control entirely, simply disabled **UseSystemFocusVisuals**:</span></span>
```XAML
<Slider Width="200" UseSystemFocusVisuals="False"/>
```

<span data-ttu-id="26f13-156">太さ、余白、またはアプリ開発者がフォーカスの視覚効果を必要とするかどうかは、コントロールごとに決める必要があります。</span><span class="sxs-lookup"><span data-stu-id="26f13-156">The thickness, margin, or whether or not the app-developer wishes to have the focus visuals at all, is determined on a per-control basis.</span></span>

**<span data-ttu-id="26f13-157">色のプロパティ</span><span class="sxs-lookup"><span data-stu-id="26f13-157">Color Properties</span></span>**

<span data-ttu-id="26f13-158">フォーカスの視覚効果に関する色のプロパティには、プライマリ境界線の色とセカンダリ境界線の色という 2 つのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="26f13-158">There are only two color properties for the focus visuals: the primary border color, and the secondary border color.</span></span> <span data-ttu-id="26f13-159">これらのフォーカスの視覚効果における境界線の色は、ページ レベルでコントロールごとに変更したり、アプリ全体を対象としてグローバルに変更したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="26f13-159">These focus visual border colors can be changed per-control on an page level, and globally on an app-wide level:</span></span>

<span data-ttu-id="26f13-160">アプリ全体を対象としてフォーカスの視覚効果をブランド化するには、システム ブラシを上書きします。</span><span class="sxs-lookup"><span data-stu-id="26f13-160">To brand focus visuals app-wide, override the system brushes:</span></span>
```XAML
<SolidColorBrush x:Key="SystemControlFocusVisualPrimaryBrush" Color="DarkRed"/>
<SolidColorBrush x:Key="SystemControlFocusVisualSecondaryBrush" Color="Pink"/>
```
![視認性の高いフォーカスの視覚効果における色の変更](images/FocusRectColorChanges.png)

<span data-ttu-id="26f13-162">コントロールごとに色を変更するには、目的のコントロールが持つフォーカスの視覚効果のプロパティを編集するだけです。</span><span class="sxs-lookup"><span data-stu-id="26f13-162">To change the colors on a per-control basis, just edit the focus visual properties on the desired control:</span></span>
```XAML
<Slider Width="200" FocusVisualPrimaryBrush="DarkRed" FocusVisualSecondaryBrush="Pink"/>
```

## <a name="related-articles"></a><span data-ttu-id="26f13-163">関連記事</span><span class="sxs-lookup"><span data-stu-id="26f13-163">Related articles</span></span>

**<span data-ttu-id="26f13-164">デザイナー向け</span><span class="sxs-lookup"><span data-stu-id="26f13-164">For designers</span></span>**
* [<span data-ttu-id="26f13-165">パンのガイドライン</span><span class="sxs-lookup"><span data-stu-id="26f13-165">Guidelines for panning</span></span>](guidelines-for-panning.md)

**<span data-ttu-id="26f13-166">開発者向け</span><span class="sxs-lookup"><span data-stu-id="26f13-166">For developers</span></span>**
* [<span data-ttu-id="26f13-167">カスタム ユーザー操作</span><span class="sxs-lookup"><span data-stu-id="26f13-167">Custom user interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185599)

**<span data-ttu-id="26f13-168">サンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-168">Samples</span></span>**
* [<span data-ttu-id="26f13-169">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-169">Basic input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="26f13-170">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-170">Low latency input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="26f13-171">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-171">User interaction mode sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="26f13-172">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-172">Focus visuals sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="26f13-173">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="26f13-173">Archive samples</span></span>**
* [<span data-ttu-id="26f13-174">入力: XAML ユーザー入力イベントのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="26f13-174">Input: XAML user input events sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="26f13-175">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-175">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="26f13-176">入力: タッチのヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-176">Input: Touch hit testing sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="26f13-177">XAML のスクロール、パン、ズームのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="26f13-177">XAML scrolling, panning, and zooming sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="26f13-178">入力: 簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-178">Input: Simplified ink sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="26f13-179">入力: Windows 8 のジェスチャのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="26f13-179">Input: Windows 8 gestures sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="26f13-180">入力: 操作とジェスチャ (C++) のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="26f13-180">Input: Manipulations and gestures (C++) sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="26f13-181">DirectX タッチ入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="26f13-181">DirectX touch input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 
