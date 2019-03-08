---
Description: UWP アプリとの対話が検出された、解釈、および処理時にユーザーを表示するのにには、視覚的なフィードバックを使用します。
title: 視覚的なフィードバック
ms.assetid: bf2f3672-95f0-4c8c-9a72-0934f2d3b767
label: Visual feedback
template: detail.hbs
keywords: 視覚的なフィードバック, フォーカス フィードバック, タッチ フィードバック, 接触の視覚エフェクト, 入力, 操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: b043ec71eb7d5883a1b22c4f0d8f43824034d454
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640787"
---
# <a name="guidelines-for-visual-feedback"></a><span data-ttu-id="6197f-104">視覚的なフィードバックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="6197f-104">Guidelines for visual feedback</span></span>

<span data-ttu-id="6197f-105">視覚的なフィードバックは、対話式操作が検出、解釈、処理されていることをユーザーに示すために使います。</span><span class="sxs-lookup"><span data-stu-id="6197f-105">Use visual feedback to show users when their interactions are detected, interpreted, and handled.</span></span> <span data-ttu-id="6197f-106">視覚的なフィードバックは、対話式操作を促進することによってユーザーを支援します。</span><span class="sxs-lookup"><span data-stu-id="6197f-106">Visual feedback can help users by encouraging interaction.</span></span> <span data-ttu-id="6197f-107">対話式操作の成功を示すことによって、ユーザーのコントロール感を向上させます。</span><span class="sxs-lookup"><span data-stu-id="6197f-107">It indicates the success of an interaction, which improves the user's sense of control.</span></span> <span data-ttu-id="6197f-108">また、システム状態の中継やエラーの削減も可能になります。</span><span class="sxs-lookup"><span data-stu-id="6197f-108">It also relays system status and reduces errors.</span></span>

> <span data-ttu-id="6197f-109">**重要な Api**:[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648)、 [ **Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、 [ **Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)</span><span class="sxs-lookup"><span data-stu-id="6197f-109">**Important APIs**:  [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648), [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084), [**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)</span></span>

## <a name="recommendations"></a><span data-ttu-id="6197f-110">推奨事項</span><span class="sxs-lookup"><span data-stu-id="6197f-110">Recommendations</span></span>

- <span data-ttu-id="6197f-111">広範囲な変更はコントロールとアプリケーションの両方のパフォーマンスとアクセシビリティに影響を与える可能性があるため、コントロール テンプレートの変更を、設計意図に直接関連するものに制限するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="6197f-111">Try to limit modifcations of a control template to those directly related to your design intent, as extensive changes can impact the performance and accessibility of both the control and your application.</span></span> 
    - <span data-ttu-id="6197f-112">表示状態のプロパティなど、コントロールのプロパティのカスタマイズの詳細については、「[XAML スタイル](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/xaml-styles)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6197f-112">See [XAML styles](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/xaml-styles) for more info on customizing the properties of a control, including visual state properties.</span></span>
    - <span data-ttu-id="6197f-113">コントロール テンプレートに対する変更の詳細については、「[UserControl クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6197f-113">See the [UserControl Class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol) for details on making changes to a control template</span></span>
    - <span data-ttu-id="6197f-114">コントロール テンプレートに大幅な変更を加える必要がある場合は、独自にテンプレート化したカスタム コントロールを作成することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="6197f-114">Consider creating your own custom templated control if you need to make significant changes to a control template.</span></span> <span data-ttu-id="6197f-115">テンプレート化したカスタム コントロールの例については、「[カスタム編集コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6197f-115">For an example of a custom templated control, see the [Custom Edit Control sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl).</span></span>
- <span data-ttu-id="6197f-116">タッチの視覚エフェクトがアプリの使用を妨げる可能性がある場合は、使わないでください。</span><span class="sxs-lookup"><span data-stu-id="6197f-116">Don't use touch visualizations in situations where they might interfere with the use of the app.</span></span> <span data-ttu-id="6197f-117">詳しくは、「[**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6197f-117">For more info, see [**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969).</span></span>
- <span data-ttu-id="6197f-118">どうしても必要な場合以外は、フィードバックを表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="6197f-118">Don't display feedback unless it is absolutely necessary.</span></span> <span data-ttu-id="6197f-119">その場所でしか意味がない場合を除き、視覚的なフィードバックを表示せずに、UI の簡潔さを維持してください。</span><span class="sxs-lookup"><span data-stu-id="6197f-119">Keep the UI clean and uncluttered by not showing visual feedback unless you are adding value that is not available elsewhere.</span></span>
- <span data-ttu-id="6197f-120">Windows の組み込みジェスチャの視覚的なフィードバックの動作は大幅にカスタマイズしないでください。この動作をカスタマイズすると、ユーザー エクスペリエンスに一貫性がなくなり、混乱する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6197f-120">Try not to dramatically customize the visual feedback behaviors of the built-in Windows gestures, as this can create an inconsistent and confusing user experience.</span></span>

## <a name="additional-usage-guidance"></a><span data-ttu-id="6197f-121">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="6197f-121">Additional usage guidance</span></span>

<span data-ttu-id="6197f-122">正確性が求められるタッチ操作では、接触の視覚エフェクトが特に重要です。</span><span class="sxs-lookup"><span data-stu-id="6197f-122">Contact visualizations are especially critical for touch interactions that require accuracy and precision.</span></span> <span data-ttu-id="6197f-123">たとえば、アプリでタップの位置を正確に示し、対象から外れていたかどうか、どの程度外れていたか、合わせるにはどうすればよいかをユーザーが把握できるようする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6197f-123">For example, your app should clearly indicate the location of a tap to let a user know if they missed their target, how much they missed it by, and what adjustments they must make.</span></span>

<span data-ttu-id="6197f-124">利用可能な既定の XAML プラットフォーム コントロールを使うと、すべてのデバイスおよびすべての入力状況でアプリが正しく動作します。</span><span class="sxs-lookup"><span data-stu-id="6197f-124">Using the default XAML platform controls available ensures that your app works correctly on all devices and in all input situations.</span></span> <span data-ttu-id="6197f-125">カスタマイズされたフィードバックが必要なカスタム操作をアプリに実装する場合は、そのフィードバックが適切であり、各入力デバイスでそのフィードバックが示されることを確認してください。また、フィードバックがユーザーの作業を妨げないようにする必要もあります。</span><span class="sxs-lookup"><span data-stu-id="6197f-125">If your app features custom interactions that require customized feedback, you should ensure the feedback is appropriate, spans input devices, and doesn't distract a user from their task.</span></span> <span data-ttu-id="6197f-126">このことは、視覚的なフィードバックが重要な UI と競合したり、重要な UI を隠したりする可能性があるゲームや描画アプリでは特に重要です。</span><span class="sxs-lookup"><span data-stu-id="6197f-126">This can be a particular issue in game or drawing apps, where the visual feedback might conflict with or obscure critical UI.</span></span>

> [!Important]
> <span data-ttu-id="6197f-127">組み込みジェスチャの操作の動作を変更することはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="6197f-127">We don't recommend changing the interaction behavior of the built-in gestures.</span></span>

<span data-ttu-id="6197f-128">**複数のデバイスからのフィードバック**</span><span class="sxs-lookup"><span data-stu-id="6197f-128">**Feedback Across Devices**</span></span>

<span data-ttu-id="6197f-129">視覚的なフィードバックは、一般に入力デバイス (タッチ、タッチバッド、マウス、ペン/スタイラス、キーボードなど) に依存します。</span><span class="sxs-lookup"><span data-stu-id="6197f-129">Visual feedback is generally dependent on the input device (touch, touchpad, mouse, pen/stylus, keyboard, and so on).</span></span> <span data-ttu-id="6197f-130">たとえば、マウスの組み込みフィードバックには、通常はカーソルの移動と変化が伴います。一方、タッチとペンの場合は接触の視覚エフェクトが必要です。キーボードによる入力とナビゲーションの場合は、フォーカス用の四角形と強調表示を使います。</span><span class="sxs-lookup"><span data-stu-id="6197f-130">For example, the built-in feedback for a mouse usually involves moving and changing the cursor, while touch and pen require contact visualizations, and keyboard input and navigation uses focus rectangles and highlighting.</span></span>

<span data-ttu-id="6197f-131">プラットフォーム ジェスチャのフィードバック動作を設定するには、[**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969) を使います。</span><span class="sxs-lookup"><span data-stu-id="6197f-131">Use [**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969) to set feedback behavior for the platform gestures.</span></span>

<span data-ttu-id="6197f-132">フィードバック UI をカスタマイズする場合は、すべての入力モードをサポートした適切なフィードバックを提供してください。</span><span class="sxs-lookup"><span data-stu-id="6197f-132">If customizing feedback UI, ensure you provide feedback that supports, and is suitable for, all input modes.</span></span>

<span data-ttu-id="6197f-133">Windows には、次のような接触の視覚エフェクトが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="6197f-133">Here are some examples of built-in contact visualizations in Windows.</span></span>

| ![タッチ フィードバック](images/TouchFeedback.png) | ![マウス フィードバック](images/MouseFeedback.png) | ![ペン フィードバック](images/PenFeedback.png) | ![キーボード フィードバック](images/KeyboardFeedback.png) |
| --- | --- | --- | --- |
| <span data-ttu-id="6197f-138">タッチの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="6197f-138">Touch visualization</span></span> | <span data-ttu-id="6197f-139">マウス/タッチパッドの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="6197f-139">Mouse/touchpad visualization</span></span> | <span data-ttu-id="6197f-140">ペンの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="6197f-140">Pen visualization</span></span> | <span data-ttu-id="6197f-141">キーボードの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="6197f-141">Keyboard visualization</span></span> |

## <a name="high-visibility-focus-visuals"></a><span data-ttu-id="6197f-142">視認性の高いフォーカスの視覚効果</span><span class="sxs-lookup"><span data-stu-id="6197f-142">High Visibility Focus Visuals</span></span>

<span data-ttu-id="6197f-143">すべての Windows アプリでは、定義済みのさまざまなフォーカスの視覚効果が、アプリケーション内にある対話可能なコントロールの周囲に示されます。</span><span class="sxs-lookup"><span data-stu-id="6197f-143">All Windows apps sport a more defined focus visual around interactable controls within the application.</span></span> <span data-ttu-id="6197f-144">新しいフォーカスの視覚効果は、すべてカスタマイズ可能であり、必要に応じて無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="6197f-144">These new focus visuals are fully customizable as well as disableable when needed.</span></span>

<span data-ttu-id="6197f-145">Xbox とテレビの使用で一般的な **10 フィート エクスペリエンス**では、Windows は**表示フォーカス**をサポートします。これは、ボタンなどのフォーカス可能な要素がゲームパッドやキーボードの入力でフォーカスを取得したときに、その境界線をアニメーション化する照明効果です。</span><span class="sxs-lookup"><span data-stu-id="6197f-145">For the **10-foot experience** typical of Xbox and TV usage, Windows supports **Reveal focus**, a lighting effect that animates the border of focusable elements, such as a button, when they get focus through gamepad or keyboard input.</span></span> <span data-ttu-id="6197f-146">詳細については、「[Xbox およびテレビ向け設計](https://docs.microsoft.com/windows/uwp/design/devices/designing-for-tv#reveal-focus)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6197f-146">For more info, see [Designing for Xbox and TV](https://docs.microsoft.com/windows/uwp/design/devices/designing-for-tv#reveal-focus).</span></span>

## <a name="color-branding--customizing"></a><span data-ttu-id="6197f-147">色のブランド化とカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="6197f-147">Color Branding & Customizing</span></span>

<span data-ttu-id="6197f-148">**罫線のプロパティ**</span><span class="sxs-lookup"><span data-stu-id="6197f-148">**Border Properties**</span></span>

<span data-ttu-id="6197f-149">視認性の高いフォーカスの視覚効果は、プライマリ境界線とセカンダリ境界線という 2 つの部分で構成されます。</span><span class="sxs-lookup"><span data-stu-id="6197f-149">There are two parts to the high visibility focus visuals: the primary border and the secondary border.</span></span> <span data-ttu-id="6197f-150">プライマリ境界線は、**2 px** の幅があり、セカンダリ境界線の*外側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="6197f-150">The primary border is **2px** thick, and runs around the *outside* of the secondary border.</span></span> <span data-ttu-id="6197f-151">セカンダリ境界線は、**1 px** の幅があり、プライマリ境界線の*内側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="6197f-151">The secondary border is **1px** thick and runs around the *inside* of the primary border.</span></span>
<span data-ttu-id="6197f-152">![可視性の高いフォーカス ビジュアルの赤線します。](images/FocusRectRedlines.png)</span><span class="sxs-lookup"><span data-stu-id="6197f-152">![High visibility focus visual redlines](images/FocusRectRedlines.png)</span></span>

<span data-ttu-id="6197f-153">それぞれの境界線 (プライマリおよびセカンダリ) の太さを変更するには、**FocusVisualPrimaryThickness** をプライマリ境界線に対して使用し、 **FocusVisualSecondaryThickness** をセカンダリ境界線に対して使用します。</span><span class="sxs-lookup"><span data-stu-id="6197f-153">To change the thickness of either border type (primary or secondary) use the **FocusVisualPrimaryThickness** or **FocusVisualSecondaryThickness**, respectively:</span></span>
```XAML
<Slider Width="200" FocusVisualPrimaryThickness="5" FocusVisualSecondaryThickness="2"/>
```
![視認性の高いフォーカスの視覚効果における余白部分の太さ](images/FocusMargin.png)

<span data-ttu-id="6197f-155">余白は [**Thickness**](https://msdn.microsoft.com/library/system.windows.thickness) という種類のプロパティで指定されます。このため、コントロールの特定の側にのみ表示されるように、余白をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="6197f-155">The margin is a property of type [**Thickness**](https://msdn.microsoft.com/library/system.windows.thickness), and therefore the margin can be customized to appear only on certain sides of the control.</span></span> <span data-ttu-id="6197f-156">以下に例を示します。![可視性の高いフォーカス ビジュアルの余白の厚み下端のみ](images/FocusThicknessSide.png)</span><span class="sxs-lookup"><span data-stu-id="6197f-156">See below: ![High visibility focus visual margin thickness bottom only](images/FocusThicknessSide.png)</span></span>

<span data-ttu-id="6197f-157">余白は、コントロールの視覚的な境界線と、フォーカスの視覚効果で示される*セカンダリ境界線*の開始点との間にあるスペースです。</span><span class="sxs-lookup"><span data-stu-id="6197f-157">The margin is the space between the control's visual bounds and the start of the focus visuals *secondary border*.</span></span> <span data-ttu-id="6197f-158">既定の余白は、コントロールの境界線から **1 px** の幅で描画されます。</span><span class="sxs-lookup"><span data-stu-id="6197f-158">The default margin is **1px** away from the control bounds.</span></span> <span data-ttu-id="6197f-159">この余白はコントロールごとに変更できます。それには、**FocusVisualMargin** プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="6197f-159">You can edit this margin on a per-control basis, by changing the **FocusVisualMargin** property:</span></span>
```XAML
<Slider Width="200" FocusVisualMargin="-5"/>
```
![視認性の高いフォーカスの視覚効果における余白の違い](images/FocusPlusMinusMargin.png)

<span data-ttu-id="6197f-161">*負の値の余白は、コントロールの中央から離れて、境界線をプッシュし、正の余白が境界線の近くをコントロールの中央に移動します。*</span><span class="sxs-lookup"><span data-stu-id="6197f-161">*A negative margin will push the border away from the center of the control, and a positive margin will move the border closer to the center of the control.*</span></span>

<span data-ttu-id="6197f-162">コントロールでフォーカスの視覚効果を完全に無効にするには、**UseSystemFocusVisuals** を無効にするだけです。</span><span class="sxs-lookup"><span data-stu-id="6197f-162">To turn off focus visuals on the control entirely, simply disabled **UseSystemFocusVisuals**:</span></span>
```XAML
<Slider Width="200" UseSystemFocusVisuals="False"/>
```

<span data-ttu-id="6197f-163">太さ、余白、またはアプリ開発者がフォーカスの視覚効果を必要とするかどうかは、コントロールごとに決める必要があります。</span><span class="sxs-lookup"><span data-stu-id="6197f-163">The thickness, margin, or whether or not the app-developer wishes to have the focus visuals at all, is determined on a per-control basis.</span></span>

<span data-ttu-id="6197f-164">**色のプロパティ**</span><span class="sxs-lookup"><span data-stu-id="6197f-164">**Color Properties**</span></span>

<span data-ttu-id="6197f-165">フォーカスの視覚効果に関する色のプロパティには、プライマリ境界線の色とセカンダリ境界線の色という 2 つのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="6197f-165">There are only two color properties for the focus visuals: the primary border color, and the secondary border color.</span></span> <span data-ttu-id="6197f-166">これらのフォーカスの視覚効果における境界線の色は、ページ レベルでコントロールごとに変更したり、アプリ全体を対象としてグローバルに変更したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="6197f-166">These focus visual border colors can be changed per-control on an page level, and globally on an app-wide level:</span></span>

<span data-ttu-id="6197f-167">アプリ全体を対象としてフォーカスの視覚効果をブランド化するには、システム ブラシを上書きします。</span><span class="sxs-lookup"><span data-stu-id="6197f-167">To brand focus visuals app-wide, override the system brushes:</span></span>
```XAML
<SolidColorBrush x:Key="SystemControlFocusVisualPrimaryBrush" Color="DarkRed"/>
<SolidColorBrush x:Key="SystemControlFocusVisualSecondaryBrush" Color="Pink"/>
```
![視認性の高いフォーカスの視覚効果における色の変更](images/FocusRectColorChanges.png)

<span data-ttu-id="6197f-169">コントロールごとに色を変更するには、目的のコントロールが持つフォーカスの視覚効果のプロパティを編集するだけです。</span><span class="sxs-lookup"><span data-stu-id="6197f-169">To change the colors on a per-control basis, just edit the focus visual properties on the desired control:</span></span>
```XAML
<Slider Width="200" FocusVisualPrimaryBrush="DarkRed" FocusVisualSecondaryBrush="Pink"/>
```

## <a name="related-articles"></a><span data-ttu-id="6197f-170">関連記事</span><span class="sxs-lookup"><span data-stu-id="6197f-170">Related articles</span></span>

<span data-ttu-id="6197f-171">**デザイナー向け**</span><span class="sxs-lookup"><span data-stu-id="6197f-171">**For designers**</span></span>
* [<span data-ttu-id="6197f-172">パンのガイドライン</span><span class="sxs-lookup"><span data-stu-id="6197f-172">Guidelines for panning</span></span>](guidelines-for-panning.md)

<span data-ttu-id="6197f-173">**開発者向け**</span><span class="sxs-lookup"><span data-stu-id="6197f-173">**For developers**</span></span>
* [<span data-ttu-id="6197f-174">カスタム ユーザー操作</span><span class="sxs-lookup"><span data-stu-id="6197f-174">Custom user interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185599)

<span data-ttu-id="6197f-175">**サンプル**</span><span class="sxs-lookup"><span data-stu-id="6197f-175">**Samples**</span></span>
* [<span data-ttu-id="6197f-176">基本的な入力サンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-176">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="6197f-177">低待機時間の入力サンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-177">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="6197f-178">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-178">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="6197f-179">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-179">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

<span data-ttu-id="6197f-180">**サンプルのアーカイブ**</span><span class="sxs-lookup"><span data-stu-id="6197f-180">**Archive samples**</span></span>
* [<span data-ttu-id="6197f-181">入力:XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-181">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="6197f-182">入力:デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-182">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="6197f-183">入力:タッチ ヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-183">Input: Touch hit testing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="6197f-184">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-184">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="6197f-185">入力:簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-185">Input: Simplified ink sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="6197f-186">入力:Windows 8 のジェスチャのサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-186">Input: Windows 8 gestures sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="6197f-187">入力:操作とジェスチャ (C++) のサンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-187">Input: Manipulations and gestures (C++) sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="6197f-188">DirectX のタッチ入力サンプル</span><span class="sxs-lookup"><span data-stu-id="6197f-188">DirectX touch input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 
