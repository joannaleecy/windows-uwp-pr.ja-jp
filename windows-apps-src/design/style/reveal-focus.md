---
description: フォーカスがあるユーザーがそれらにゲームパッドまたはキーボード フォーカスを移動すると、フォーカスを設定できる要素の境界線をアニメーション化する照明効果を表示します。
title: フォーカスを表示します。
template: detail.hbs
ms.date: 03/01/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: chphilip
design-contact: ''
dev-contact: stevenki
ms.localizationpriority: medium
ms.openlocfilehash: 7bcceb8d44b6d92cab05a9c077531b3fe1b05c79
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651757"
---
# <a name="reveal-focus"></a><span data-ttu-id="b054c-104">フォーカスを表示します。</span><span class="sxs-lookup"><span data-stu-id="b054c-104">Reveal Focus</span></span>

![ヒーロー イメージ](images/header-reveal-focus.svg)

<span data-ttu-id="b054c-106">表示のフォーカスがあるの照明効果を[10 フィート エクスペリエンス](/windows/uwp/design/devices/designing-for-tv)、Xbox One やテレビ画面など。</span><span class="sxs-lookup"><span data-stu-id="b054c-106">Reveal Focus is a lighting effect for [10-foot experiences](/windows/uwp/design/devices/designing-for-tv), such as Xbox One and television screens.</span></span> <span data-ttu-id="b054c-107">ユーザーがゲームパッドやキーボードのフォーカスをボタンなどのフォーカス可能な要素に移動したときに、その要素の境界線がアニメーション化されます。</span><span class="sxs-lookup"><span data-stu-id="b054c-107">It animates the border of focusable elements, such as buttons, when the user moves gamepad or keyboard focus to them.</span></span> <span data-ttu-id="b054c-108">表示フォーカスは既定で無効になっていますが、簡単に有効にできます。</span><span class="sxs-lookup"><span data-stu-id="b054c-108">It's turned off by default, but it's simple to enable.</span></span> 

<span data-ttu-id="b054c-109">(強調表示効果、対話型の要素を強調表示する照明に影響を参照してください、[強調表示の記事](/windows/uwp/design/style/reveal))。</span><span class="sxs-lookup"><span data-stu-id="b054c-109">(For the Reveal Highlight effect, a lighting affect that highlights interactive elements, see the [Reveal Highlight article](/windows/uwp/design/style/reveal).)</span></span>


> <span data-ttu-id="b054c-110">**重要な Api**:[Application.FocusVisualKind プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.FocusVisualKind)、 [FocusVisualKind enum](https://docs.microsoft.com/uwp/api/windows.ui.xaml.focusvisualkind)、 [Control.UseSystemFocusVisuals プロパティ](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)</span><span class="sxs-lookup"><span data-stu-id="b054c-110">**Important APIs**: [Application.FocusVisualKind property](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.FocusVisualKind), [FocusVisualKind enum](https://docs.microsoft.com/uwp/api/windows.ui.xaml.focusvisualkind), [Control.UseSystemFocusVisuals property](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)</span></span>

## <a name="how-it-works"></a><span data-ttu-id="b054c-111">方法</span><span class="sxs-lookup"><span data-stu-id="b054c-111">How it works</span></span>
<span data-ttu-id="b054c-112">フォーカスされた要素に絞る呼び出しを明らかには、要素の境界線のアニメーションの光彩の追加。</span><span class="sxs-lookup"><span data-stu-id="b054c-112">Reveal Focus calls attention to focused elements by adding an animated glow around the element's border:</span></span>

![表示のビジュアル効果](images/traveling-focus-fullscreen-light-rf.gif)

<span data-ttu-id="b054c-114">これは、場所、ユーザーことがある注意を怠る完全なテレビ画面全体を 10-foot シナリオで特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="b054c-114">This is especially helpful in 10-foot scenarios where the user might not be paying full attention to the entire TV screen.</span></span> 

## <a name="examples"></a><span data-ttu-id="b054c-115">例</span><span class="sxs-lookup"><span data-stu-id="b054c-115">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="b054c-116">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="b054c-116">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="b054c-117">ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/RevealFocus">アプリを開き、操作の表示のフォーカスを参照してください</a>します。</span><span class="sxs-lookup"><span data-stu-id="b054c-117">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/RevealFocus">open the app and see Reveal Focus in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="b054c-118"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></span><span class="sxs-lookup"><span data-stu-id="b054c-118"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="b054c-119"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="b054c-119"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

## <a name="how-to-use-it"></a><span data-ttu-id="b054c-120">使用方法</span><span class="sxs-lookup"><span data-stu-id="b054c-120">How to use it</span></span>

<span data-ttu-id="b054c-121">明らかにフォーカスが既定ではオフです。</span><span class="sxs-lookup"><span data-stu-id="b054c-121">Reveal Focus is off by default.</span></span> <span data-ttu-id="b054c-122">有効にするには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="b054c-122">To enable it:</span></span>
1. <span data-ttu-id="b054c-123">アプリのコンストラクターで、[AnalyticsInfo.VersionInfo.DeviceFamily](/uwp/api/windows.system.profile.analyticsversioninfo.DeviceFamily) プロパティを呼び出し、現在のデバイス ファミリが `Windows.Xbox` かどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="b054c-123">In your app's constructor, call the [AnalyticsInfo.VersionInfo.DeviceFamily](/uwp/api/windows.system.profile.analyticsversioninfo.DeviceFamily) property and check whether the current device family is `Windows.Xbox`.</span></span>
2. <span data-ttu-id="b054c-124">デバイス ファミリが `Windows.Xbox` である場合は、[Application.FocusVisualKind](/uwp/api/windows.ui.xaml.application.FocusVisualKind) プロパティを `FocusVisualKind.Reveal` に設定します。</span><span class="sxs-lookup"><span data-stu-id="b054c-124">If the device family is `Windows.Xbox`, set the [Application.FocusVisualKind](/uwp/api/windows.ui.xaml.application.FocusVisualKind) property to `FocusVisualKind.Reveal`.</span></span> 

```csharp
    if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox")
    {
        this.FocusVisualKind = FocusVisualKind.Reveal;
    }
```

<span data-ttu-id="b054c-125">設定した後、 **FocusVisualKind**プロパティ、システムは自動的に表示フォーカス効果を適用のすべてのコントロール[UseSystemFocusVisuals](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)プロパティに設定されて**True**(ほとんどのコントロールの既定値)。</span><span class="sxs-lookup"><span data-stu-id="b054c-125">After you set the **FocusVisualKind** property, the system automatically applies the Reveal Focus effect to all controls whose [UseSystemFocusVisuals](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals) property is set to **True** (the default value for most controls).</span></span> 

## <a name="why-isnt-reveal-focus-on-by-default"></a><span data-ttu-id="b054c-126">既定でフォーカスの表示にできない理由ですか。</span><span class="sxs-lookup"><span data-stu-id="b054c-126">Why isn't Reveal Focus on by default?</span></span> 
<span data-ttu-id="b054c-127">ご覧のとおり、Xbox で実行されているアプリが検出したときに表示フォーカスをオンにすることは簡単です。</span><span class="sxs-lookup"><span data-stu-id="b054c-127">As you can see, it's fairly easy to turn on Reveal Focus when the app detects it's running on an Xbox.</span></span> <span data-ttu-id="b054c-128">それでは、システムによって自動的に有効にならないのはなぜでしょうか。</span><span class="sxs-lookup"><span data-stu-id="b054c-128">So, why doesn't the system just turn it on for you?</span></span> <span data-ttu-id="b054c-129">フォーカスの表示には、フォーカスのビジュアルのサイズが増加するため、UI レイアウトの問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b054c-129">Because Reveal Focus increases the size of the focus visual, which might cause issues with your UI layout.</span></span> <span data-ttu-id="b054c-130">場合によっては、アプリ用に最適化する表示のフォーカスの効果をカスタマイズするします。</span><span class="sxs-lookup"><span data-stu-id="b054c-130">In some cases, you'll want to customize the Reveal Focus effect to optimize it for your app.</span></span>

## <a name="customizing-reveal-focus"></a><span data-ttu-id="b054c-131">表示フォーカスをカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="b054c-131">Customizing Reveal Focus</span></span>

<span data-ttu-id="b054c-132">各コントロールのフォーカス ビジュアルのプロパティを変更することで、フォーカスの表示の効果をカスタマイズできます。[FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness)、 [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness)、 [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush)、および[FocusVisualSecondaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)します。</span><span class="sxs-lookup"><span data-stu-id="b054c-132">You can customize the Reveal Focus effect by modifying the focus visual properties for each control: [FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness), [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness), [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush), and [FocusVisualSecondaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush).</span></span> <span data-ttu-id="b054c-133">これらのプロパティでは、フォーカスの四角形の色と太さをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="b054c-133">These properties let you customize the color and thickness of the focus rectangle.</span></span> <span data-ttu-id="b054c-134">(これらは、[視認性の高いフォーカスの視覚効果](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#high-visibility-focus-visuals)を作成する場合と同じプロパティです。)</span><span class="sxs-lookup"><span data-stu-id="b054c-134">(They're the same properties you use for creating [High Visibility focus visuals](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#high-visibility-focus-visuals).)</span></span> 

<span data-ttu-id="b054c-135">カスタマイズを開始する前に、それをお勧め表示フォーカスを構成するコンポーネントについて少し詳しく知る。</span><span class="sxs-lookup"><span data-stu-id="b054c-135">But before you start customzing it, it's helpful to know a little more about the components that make up Reveal Focus.</span></span>

<span data-ttu-id="b054c-136">既定の表示のフォーカス ビジュアルに 3 つの部分があります。 プライマリの枠線、セカンダリの境界線およびグロー表示します。</span><span class="sxs-lookup"><span data-stu-id="b054c-136">There are three parts to the default Reveal Focus visuals: the primary border, the secondary border and the Reveal glow.</span></span> <span data-ttu-id="b054c-137">プライマリ境界線は、**2 px** の幅があり、セカンダリ境界線の*外側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="b054c-137">The primary border is **2px** thick, and runs around the *outside* of the secondary border.</span></span> <span data-ttu-id="b054c-138">セカンダリ境界線は、**1 px** の幅があり、プライマリ境界線の*内側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="b054c-138">The secondary border is **1px** thick and runs around the *inside* of the primary border.</span></span> <span data-ttu-id="b054c-139">表示フォーカス光彩がプライマリの境界線の太さに比例した幅と実行、*外*のプライマリの境界線。</span><span class="sxs-lookup"><span data-stu-id="b054c-139">The Reveal Focus glow has a thickness proportional to the thickness of the primary border and runs around the *outside* of the primary border.</span></span>

<span data-ttu-id="b054c-140">表示のフォーカスのビジュアル機能だけでなく、静的な要素の pulsates に置いたときに、フォーカスを移動するときに、フォーカスの方向に移動するアニメーションの光。</span><span class="sxs-lookup"><span data-stu-id="b054c-140">In addition to the static elements, Reveal Focus visuals feature an animated light that pulsates when at rests and moves in the direction of focus when moving focus.</span></span>

![フォーカスのレイヤーを表示します。](images/reveal-breakdown.svg)

## <a name="customize-the-border-thickness"></a><span data-ttu-id="b054c-142">境界線の幅のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="b054c-142">Customize the border thickness</span></span>

<span data-ttu-id="b054c-143">コントロールの境界線の種類ごとに幅を変更するには、以下のプロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="b054c-143">To change the thickness of the border types of a control, use these properties:</span></span>

| <span data-ttu-id="b054c-144">境界線の種類</span><span class="sxs-lookup"><span data-stu-id="b054c-144">Border type</span></span> | <span data-ttu-id="b054c-145">プロパティ</span><span class="sxs-lookup"><span data-stu-id="b054c-145">Property</span></span> |
| --- | --- |
| <span data-ttu-id="b054c-146">プライマリ、グロー</span><span class="sxs-lookup"><span data-stu-id="b054c-146">Primary, Glow</span></span>   | [<span data-ttu-id="b054c-147">FocusVisualPrimaryThickness</span><span class="sxs-lookup"><span data-stu-id="b054c-147">FocusVisualPrimaryThickness</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness)<br/> <span data-ttu-id="b054c-148">(プライマリ境界線を変更すると、グロー部分の幅も比例して変化します。)</span><span class="sxs-lookup"><span data-stu-id="b054c-148">(Changing the primary border changes the thickness of the glow proportionately.)</span></span>   |
| <span data-ttu-id="b054c-149">セカンダリ</span><span class="sxs-lookup"><span data-stu-id="b054c-149">Secondary</span></span>   | [<span data-ttu-id="b054c-150">FocusVisualSecondaryThickness</span><span class="sxs-lookup"><span data-stu-id="b054c-150">FocusVisualSecondaryThickness</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness)   |


<span data-ttu-id="b054c-151">この例では、ボタンのフォーカス視覚効果で、境界線の幅を変更しています。</span><span class="sxs-lookup"><span data-stu-id="b054c-151">This example changes the border thickness of a button's focus visual:</span></span>

```xaml
<Button FocusVisualPrimaryThickness="2" FocusVisualSecondaryThickness="1"/>
```

## <a name="customize-the-margin"></a><span data-ttu-id="b054c-152">余白のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="b054c-152">Customize the margin</span></span>

<span data-ttu-id="b054c-153">余白は、コントロールの視覚的な境界線と、フォーカスの視覚効果で示されるセカンダリ境界線の開始点との間にあるスペースです。</span><span class="sxs-lookup"><span data-stu-id="b054c-153">The margin is the space between the control's visual bounds and the start of the focus visuals secondary border.</span></span> <span data-ttu-id="b054c-154">既定の余白は、コントロールの境界線から 1 px の幅になります。</span><span class="sxs-lookup"><span data-stu-id="b054c-154">The default margin is 1px away from the control bounds.</span></span> <span data-ttu-id="b054c-155">この余白は、[FocusVisualMargin](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualMargin) プロパティを変更することでコントロールごとに変更できます。</span><span class="sxs-lookup"><span data-stu-id="b054c-155">You can edit this margin on a per-control basis by changing the [FocusVisualMargin](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualMargin) property:</span></span>

```xaml
<Button FocusVisualPrimaryThickness="2" FocusVisualSecondaryThickness="1" FocusVisualMargin="-3"/>
```

<span data-ttu-id="b054c-156">余白が負の値の場合は境界線がコントロールの中央から遠くなり、正の値の場合はコントロールの中央に近くなります。</span><span class="sxs-lookup"><span data-stu-id="b054c-156">A negative margin pushes the border away from the center of the control, and a positive margin moves the border closer to the center of the control.</span></span>

## <a name="customize-the-color"></a><span data-ttu-id="b054c-157">色のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="b054c-157">Customize the color</span></span>

<span data-ttu-id="b054c-158">表示のフォーカス ビジュアルの色を変更するには、使用、 [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush)と[FocusVisualSecondaryBrush](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="b054c-158">To change color of the Reveal Focus visual, use the [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush) and [FocusVisualSecondaryBrush](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush) properties.</span></span>

| <span data-ttu-id="b054c-159">プロパティ</span><span class="sxs-lookup"><span data-stu-id="b054c-159">Property</span></span> | <span data-ttu-id="b054c-160">既定のリソース</span><span class="sxs-lookup"><span data-stu-id="b054c-160">Default resource</span></span> | <span data-ttu-id="b054c-161">既定のリソースの値</span><span class="sxs-lookup"><span data-stu-id="b054c-161">Default resource value</span></span> |
| ---- | ---- | --- | 
| [<span data-ttu-id="b054c-162">FocusVisualPrimaryBrush</span><span class="sxs-lookup"><span data-stu-id="b054c-162">FocusVisualPrimaryBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush) | <span data-ttu-id="b054c-163">SystemControlRevealFocusVisualBrush</span><span class="sxs-lookup"><span data-stu-id="b054c-163">SystemControlRevealFocusVisualBrush</span></span>  | <span data-ttu-id="b054c-164">SystemAccentColor</span><span class="sxs-lookup"><span data-stu-id="b054c-164">SystemAccentColor</span></span> |
| [<span data-ttu-id="b054c-165">FocusVisualSecondaryBrush</span><span class="sxs-lookup"><span data-stu-id="b054c-165">FocusVisualSecondaryBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)  | <span data-ttu-id="b054c-166">SystemControlFocusVisualSecondaryBrush</span><span class="sxs-lookup"><span data-stu-id="b054c-166">SystemControlFocusVisualSecondaryBrush</span></span>  | <span data-ttu-id="b054c-167">SystemAltMediumColor</span><span class="sxs-lookup"><span data-stu-id="b054c-167">SystemAltMediumColor</span></span> |

<span data-ttu-id="b054c-168">(FocusPrimaryBrush プロパティに既定の **SystemControlRevealFocusVisualBrush** リソースが使用されるのは、**FocusVisualKind** が **Reveal** に設定されている場合のみです。</span><span class="sxs-lookup"><span data-stu-id="b054c-168">(The FocusPrimaryBrush property only defaults to the **SystemControlRevealFocusVisualBrush** resources when **FocusVisualKind** is set to **Reveal**.</span></span> <span data-ttu-id="b054c-169">それ以外の場合は、**SystemControlFocusVisualPrimaryBrush** が使用されます。)</span><span class="sxs-lookup"><span data-stu-id="b054c-169">Otherwise, it uses **SystemControlFocusVisualPrimaryBrush**.)</span></span>


<span data-ttu-id="b054c-170">個々のコントロールのフォーカス視覚効果の色を変更するには、コントロールのプロパティを直接設定します。</span><span class="sxs-lookup"><span data-stu-id="b054c-170">To change the color of the focus visual of an individual control, set the properties directly on the control.</span></span> <span data-ttu-id="b054c-171">次の例では、ボタンのフォーカス視覚効果の色を上書きしています。</span><span class="sxs-lookup"><span data-stu-id="b054c-171">This example overrides the focus visual colors of a button.</span></span>

```xaml

<!-- Specifying a color directly -->
<Button
    FocusVisualPrimaryBrush="DarkRed"
    FocusVisualSecondaryBrush="Pink"/>

<!-- Using theme resources -->
<Button
    FocusVisualPrimaryBrush="{ThemeResource SystemBaseHighColor}"
    FocusVisualSecondaryBrush="{ThemeResource SystemAccentColor}"/>    
```

<span data-ttu-id="b054c-172">アプリ全体ですべてのフォーカス視覚効果の色を変更するには、**SystemControlRevealFocusVisualBrush** リソースと **SystemControlFocusVisualSecondaryBrush** リソースを独自定義で上書きします。</span><span class="sxs-lookup"><span data-stu-id="b054c-172">To change the color of all focus visuals in your entire app, override the **SystemControlRevealFocusVisualBrush** and  **SystemControlFocusVisualSecondaryBrush** resources with your own definition:</span></span>

```xaml
<!-- App.xaml -->
<Application.Resources>

    <!-- Override Reveal Focus default resources. -->
    <SolidColorBrush x:Key="SystemControlRevealFocusVisualBrush" Color="{ThemeResource SystemBaseHighColor}"/>
    <SolidColorBrush x:Key="SystemControlFocusVisualSecondaryBrush" Color="{ThemeResource SystemAccentColor}"/>
</Application.Resources>
```

<span data-ttu-id="b054c-173">フォーカス視覚効果の色の変更について詳しくは、「[色のブランド化とカスタマイズ](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#color-branding--customizing)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b054c-173">For more information on modifying the focus visual's color, see [Color Branding & Customizing](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#color-branding--customizing).</span></span>


## <a name="show-just-the-glow"></a><span data-ttu-id="b054c-174">グロー部分のみを表示する</span><span class="sxs-lookup"><span data-stu-id="b054c-174">Show just the glow</span></span>

<span data-ttu-id="b054c-175">プライマリまたはセカンダリのフォーカス視覚効果は使用せず、グローのみを使用する場合は、コントロールの [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush) プロパティを `Transparent` に設定し、[FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness) を `0` に設定します。</span><span class="sxs-lookup"><span data-stu-id="b054c-175">If you'd like to use only the glow without the primary or secondary focus visual, simply set the control's [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush) property to `Transparent` and the [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness)  to `0`.</span></span> <span data-ttu-id="b054c-176">この場合は、グローにコントロールの背景色が使用され、境界線がない外観になります。</span><span class="sxs-lookup"><span data-stu-id="b054c-176">In this case, the glow will adopt the color of the control background to provide a borderless feel.</span></span> <span data-ttu-id="b054c-177">[FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness) を使用して、グローの幅を変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="b054c-177">You can modify the thickness of the glow using [FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness).</span></span>

```xaml

<!-- Show just the glow -->
<Button
    FocusVisualPrimaryBrush="Transparent"
    FocusVisualSecondaryThickness="0" />    
```


## <a name="use-your-own-focus-visuals"></a><span data-ttu-id="b054c-178">独自のフォーカス視覚効果を使用する</span><span class="sxs-lookup"><span data-stu-id="b054c-178">Use your own focus visuals</span></span>

<span data-ttu-id="b054c-179">フォーカスの表示をカスタマイズするもう 1 つの方法は、独自のビジュアル状態を使用して描画することによって、システム指定のフォーカスのビジュアルをオプトアウトします。</span><span class="sxs-lookup"><span data-stu-id="b054c-179">Another way to customize Reveal Focus is to opt out of the system-provided focus visuals by drawing your own using visual states.</span></span> <span data-ttu-id="b054c-180">詳しくは、「[フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b054c-180">To learn more, see the [Focus visuals sample](https://go.microsoft.com/fwlink/p/?LinkID=619895).</span></span>


## <a name="reveal-focus-and-the-fluent-design-system"></a><span data-ttu-id="b054c-181">フォーカスと Fluent デザイン システムを表示します。</span><span class="sxs-lookup"><span data-stu-id="b054c-181">Reveal Focus and the Fluent Design System</span></span>

<span data-ttu-id="b054c-182">フォーカスがあるアプリに光を追加する Fluent Design System コンポーネントを表示します。</span><span class="sxs-lookup"><span data-stu-id="b054c-182">Reveal Focus is a Fluent Design System component that adds light to your app.</span></span> <span data-ttu-id="b054c-183">Fluent Design System およびその他のコンポーネントについて詳しくは、[UWP 用の Fluent Design の概要](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b054c-183">To learn more about the Fluent Design system and its other components, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

## <a name="related-articles"></a><span data-ttu-id="b054c-184">関連記事</span><span class="sxs-lookup"><span data-stu-id="b054c-184">Related articles</span></span>

- [<span data-ttu-id="b054c-185">強調表示を表示します。</span><span class="sxs-lookup"><span data-stu-id="b054c-185">Reveal Highlight</span></span>](https://docs.microsoft.com/windows/uwp/design/style/reveal)
- [<span data-ttu-id="b054c-186">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="b054c-186">Designing for Xbox and TV</span></span>](/windows/uwp/design/devices/designing-for-tv)
- [<span data-ttu-id="b054c-187">ゲームパッドとリモート制御の相互作用</span><span class="sxs-lookup"><span data-stu-id="b054c-187">Gamepad and remote control interactions</span></span>](https://docs.microsoft.com/windows/uwp/design/input/gamepad-and-remote-interactions)
- [<span data-ttu-id="b054c-188">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="b054c-188">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)
- [<span data-ttu-id="b054c-189">合成効果</span><span class="sxs-lookup"><span data-stu-id="b054c-189">Composition Effects</span></span>](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [<span data-ttu-id="b054c-190">システムで科学:Fluent デザインと深さ</span><span class="sxs-lookup"><span data-stu-id="b054c-190">Science in the System: Fluent Design and Depth</span></span>](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [<span data-ttu-id="b054c-191">システムで科学:Fluent デザインおよびライト</span><span class="sxs-lookup"><span data-stu-id="b054c-191">Science in the System: Fluent Design and Light</span></span>](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
