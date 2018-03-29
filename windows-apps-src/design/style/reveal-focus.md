---
author: cphilippona
description: 表示効果のフォーカスは、ユーザーがゲームパッドやキーボードのフォーカスをフォーカス可能な要素に移動したときに、その要素の境界線をアニメーション化する発光効果です。
title: 表示フォーカス
template: detail.hbs
ms.author: mijacobs
ms.date: 03/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
pm-contact: chphilip
design-contact: ''
dev-contact: stevenki
ms.localizationpriority: high
ms.openlocfilehash: 0a5f3dca3c8310bddbcd63c814d2d883151ff1f3
ms.sourcegitcommit: ef5a1e1807313a2caa9c9b35ea20b129ff7155d0
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/08/2018
---
# <a name="reveal-focus"></a><span data-ttu-id="e1046-104">表示フォーカス</span><span class="sxs-lookup"><span data-stu-id="e1046-104">Reveal focus</span></span>

<span data-ttu-id="e1046-105">表示フォーカスは、Xbox One やテレビ画面などの [10 フィート エクスペリエンス](/windows/uwp/design/devices/designing-for-tv)を想定した発光効果です。</span><span class="sxs-lookup"><span data-stu-id="e1046-105">Reveal focus is a lighting effect for [10 foot experiences](/windows/uwp/design/devices/designing-for-tv), such as Xbox One and television screens.</span></span> <span data-ttu-id="e1046-106">ユーザーがゲームパッドやキーボードのフォーカスをボタンなどのフォーカス可能な要素に移動したときに、その要素の境界線がアニメーション化されます。</span><span class="sxs-lookup"><span data-stu-id="e1046-106">It  animates the border of focusable elements, such as buttons, when the user moves gamepad or keyboard focus to them.</span></span> <span data-ttu-id="e1046-107">表示フォーカスは既定で無効になっていますが、簡単に有効にできます。</span><span class="sxs-lookup"><span data-stu-id="e1046-107">It's turned off by default, but it's simple to enable.</span></span> 

<span data-ttu-id="e1046-108">(対話型要素を発光効果で強調する表示ハイライト効果については、「[表示ハイライト](/windows/uwp/design/style/reveal)」をご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="e1046-108">(For the Reveal highlight effect, a lighting affect that highlights interactive elements, see the [Reveal highlight article](/windows/uwp/design/style/reveal).)</span></span>


> <span data-ttu-id="e1046-109">**重要な API**: [Application.FocusVisualKind プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_FocusVisualKind)、[FocusVisualKind 列挙](https://docs.microsoft.com/uwp/api/windows.ui.xaml.focusvisualkind)、[Control.UseSystemFocusVisuals プロパティ](/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_UseSystemFocusVisuals)</span><span class="sxs-lookup"><span data-stu-id="e1046-109">**Important APIs**: [Application.FocusVisualKind property](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_FocusVisualKind), [FocusVisualKind enum](https://docs.microsoft.com/uwp/api/windows.ui.xaml.focusvisualkind), [Control.UseSystemFocusVisuals property](/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_UseSystemFocusVisuals)</span></span>

## <a name="how-it-works"></a><span data-ttu-id="e1046-110">動作のしくみ</span><span class="sxs-lookup"><span data-stu-id="e1046-110">How it works</span></span>
<span data-ttu-id="e1046-111">表示フォーカスでは、フォーカスが置かれた要素に注意が向くように、要素の境界線の周囲にアニメーション化されたグロー (蛍光ライト効果) が追加されます。</span><span class="sxs-lookup"><span data-stu-id="e1046-111">Reveal focus calls attention to focused elements by adding an animated glow around the element's border:</span></span>

![表示のビジュアル効果](images/traveling-focus-fullscreen-light-rf.gif)

<span data-ttu-id="e1046-113">この効果は、ユーザーがテレビ画面全体を注視していない場合のような 10 フィート シナリオで特に便利です。</span><span class="sxs-lookup"><span data-stu-id="e1046-113">This is especially helpful in 10 foot scenarios where the user might not be paying full attention to the entire TV screen.</span></span> 

## <a name="examples"></a><span data-ttu-id="e1046-114">例</span><span class="sxs-lookup"><span data-stu-id="e1046-114">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="e1046-115">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="e1046-115">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="e1046-116"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合は、こちらをクリックして<a href="xamlcontrolsgallery:/item/RevealFocus">アプリを開き、表示フォーカスの動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="e1046-116">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/RevealFocus">open the app and see Reveal focus in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="e1046-117">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="e1046-117">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="e1046-118">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="e1046-118">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="how-to-use-it"></a><span data-ttu-id="e1046-119">使用方法</span><span class="sxs-lookup"><span data-stu-id="e1046-119">How to use it</span></span>

<span data-ttu-id="e1046-120">既定では、表示フォーカスは無効になっています。</span><span class="sxs-lookup"><span data-stu-id="e1046-120">Reveal focus is off by default.</span></span> <span data-ttu-id="e1046-121">有効にするには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e1046-121">To enable it:</span></span>
1. <span data-ttu-id="e1046-122">アプリのコンストラクターで、[AnalyticsInfo.VersionInfo.DeviceFamily](/uwp/api/windows.system.profile.analyticsversioninfo#Windows_System_Profile_AnalyticsVersionInfo_DeviceFamily) プロパティを呼び出し、現在のデバイス ファミリが `Windows.Xbox` かどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="e1046-122">In your app's constructor, call the [AnalyticsInfo.VersionInfo.DeviceFamily](/uwp/api/windows.system.profile.analyticsversioninfo#Windows_System_Profile_AnalyticsVersionInfo_DeviceFamily) property and check whether the current device family is `Windows.Xbox`.</span></span>
2. <span data-ttu-id="e1046-123">デバイス ファミリが `Windows.Xbox` である場合は、[Application.FocusVisualKind](/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_FocusVisualKind) プロパティを `FocusVisualKind.Reveal` に設定します。</span><span class="sxs-lookup"><span data-stu-id="e1046-123">If the device family is `Windows.Xbox`, set the [Application.FocusVisualKind](/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_FocusVisualKind) property to `FocusVisualKind.Reveal`.</span></span> 

```csharp
    if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox")
    {
        this.FocusVisualKind = FocusVisualKind.Reveal;
    }
```

<span data-ttu-id="e1046-124">**FocusVisualKind** プロパティを設定すると、[UseSystemFocusVisuals](/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_UseSystemFocusVisuals) プロパティが **True** (ほとんどのコントロールの既定値) に設定されているすべてのコントロールに対して、表示フォーカス効果がシステムによって自動的に適用されます。</span><span class="sxs-lookup"><span data-stu-id="e1046-124">After you set the **FocusVisualKind** property, the system automatically applies the reveal focus effect to all controls whose [UseSystemFocusVisuals](/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_UseSystemFocusVisuals) property is set to **True** (the default value for most controls).</span></span> 

## <a name="why-isnt-reveal-focus-on-by-default"></a><span data-ttu-id="e1046-125">表示フォーカスが既定で有効になっていない理由</span><span class="sxs-lookup"><span data-stu-id="e1046-125">Why isn't Reveal focus on by default?</span></span> 
<span data-ttu-id="e1046-126">ご覧のように、Xbox での実行中であるとアプリが検出した場合は、表示フォーカスを有効にすることは非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="e1046-126">As you can see, it's fairly easy to turn on Reveal focus when the app detects it's running on an Xbox.</span></span> <span data-ttu-id="e1046-127">それでは、システムによって自動的に有効にならないのはなぜでしょうか。</span><span class="sxs-lookup"><span data-stu-id="e1046-127">So, why doesn't the system just turn it on for you?</span></span> <span data-ttu-id="e1046-128">表示フォーカスを使用すると、フォーカスの視覚効果のサイズが増加し、UI レイアウトに問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e1046-128">Because Reveal focus increases the size of the focus visual, which might cause issues with your UI layout.</span></span> <span data-ttu-id="e1046-129">場合によっては、表示フォーカス効果をカスタマイズし、アプリに合わせて最適化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1046-129">In some cases, you'll want to customize the Reveal focus effect to optimize it for your app.</span></span>

## <a name="customizing-reveal-focus"></a><span data-ttu-id="e1046-130">表示フォーカスのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="e1046-130">Customizing Reveal focus</span></span>

<span data-ttu-id="e1046-131">表示フォーカス効果は、各コントロールのフォーカス視覚効果プロパティ ([FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryThickness)、[FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryThickness)、[FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryBrush)、[FocusVisualSecondaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryBrush)) を変更することによってカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="e1046-131">You can customize the Reveal focus effect by modifying the focus visual properties for each control: [FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryThickness), [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryThickness), [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryBrush), and [FocusVisualSecondaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryBrush).</span></span> <span data-ttu-id="e1046-132">これらのプロパティでは、フォーカスの四角形の色と太さをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="e1046-132">These properties let you customize the color and thickness of the focus rectangle.</span></span> <span data-ttu-id="e1046-133">(これらは、[視認性の高いフォーカスの視覚効果](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#high-visibility-focus-visuals)を作成する場合と同じプロパティです。)</span><span class="sxs-lookup"><span data-stu-id="e1046-133">(They're the same properties you use for creating [High Visibility focus visuals](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#high-visibility-focus-visuals).)</span></span> 

<span data-ttu-id="e1046-134">カスタマイズを開始する前に、表示フォーカスを構成しているコンポーネントについてもう少し詳しく知っておくと便利です。</span><span class="sxs-lookup"><span data-stu-id="e1046-134">But before you start customzing it, it's helpful to know a little more about about the components that make up Reveal focus.</span></span>

<span data-ttu-id="e1046-135">既定の表示フォーカス視覚効果は、プライマリ境界線、セカンダリ境界線、表示グローという 3 つの部分で構成されています。</span><span class="sxs-lookup"><span data-stu-id="e1046-135">There are three parts to the default Reveal focus visuals: the primary border, the secondary border and the Reveal glow.</span></span> <span data-ttu-id="e1046-136">プライマリ境界線は、**2 px** の幅があり、セカンダリ境界線の*外側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="e1046-136">The primary border is **2px** thick, and runs around the *outside* of the secondary border.</span></span> <span data-ttu-id="e1046-137">セカンダリ境界線は、**1 px** の幅があり、プライマリ境界線の*内側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="e1046-137">The secondary border is **1px** thick and runs around the *inside* of the primary border.</span></span> <span data-ttu-id="e1046-138">表示フォーカスのグロー部分は、プライマリ境界線の幅に比例した幅があり、プライマリ境界線の*外側*に描画されます。</span><span class="sxs-lookup"><span data-stu-id="e1046-138">The Reveal focus glow has a thickness proportional to the thickness of the primary border and runs around the *outside* of the primary border.</span></span>

<span data-ttu-id="e1046-139">静的な要素に加えて、表示フォーカスの資格効果では、アニメーション化された光が使用されます。この光は、フォーカスの停止中は鼓動し、フォーカスの移動時にはフォーカス方向に移動します。</span><span class="sxs-lookup"><span data-stu-id="e1046-139">In addition to the static elements, Reveal focus visuals feature an animated light that pulsates when at rests and moves in the direction of focus when moving focus.</span></span>

![表示フォーカス レイヤー](images/reveal-breakdown.svg)

## <a name="customize-the-border-thickness"></a><span data-ttu-id="e1046-141">境界線の幅のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="e1046-141">Customize the border thickness</span></span>

<span data-ttu-id="e1046-142">コントロールの境界線の種類ごとに幅を変更するには、以下のプロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="e1046-142">To change the thickness of the border types of a control, use these properties:</span></span>

| <span data-ttu-id="e1046-143">境界線の種類</span><span class="sxs-lookup"><span data-stu-id="e1046-143">Border type</span></span> | <span data-ttu-id="e1046-144">プロパティ</span><span class="sxs-lookup"><span data-stu-id="e1046-144">Property</span></span> |
| --- | --- |
| <span data-ttu-id="e1046-145">プライマリ、グロー</span><span class="sxs-lookup"><span data-stu-id="e1046-145">Primary, Glow</span></span>   | [<span data-ttu-id="e1046-146">FocusVisualPrimaryThickness</span><span class="sxs-lookup"><span data-stu-id="e1046-146">FocusVisualPrimaryThickness</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryThickness)<br/> <span data-ttu-id="e1046-147">(プライマリ境界線を変更すると、グロー部分の幅も比例して変化します。)</span><span class="sxs-lookup"><span data-stu-id="e1046-147">(Changing the primary border changes the thickness of the glow proportionately.)</span></span>   |
| <span data-ttu-id="e1046-148">セカンダリ</span><span class="sxs-lookup"><span data-stu-id="e1046-148">Secondary</span></span>   | [<span data-ttu-id="e1046-149">FocusVisualSecondaryThickness</span><span class="sxs-lookup"><span data-stu-id="e1046-149">FocusVisualSecondaryThickness</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryThickness)   |


<span data-ttu-id="e1046-150">この例では、ボタンのフォーカス視覚効果で、境界線の幅を変更しています。</span><span class="sxs-lookup"><span data-stu-id="e1046-150">This example changes the border thickness of a button's focus visual:</span></span>

```xaml
<Button FocusVisualPrimaryThickness="2" FocusVisualSecondaryThickness="1"/>
```

## <a name="customize-the-margin"></a><span data-ttu-id="e1046-151">余白のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="e1046-151">Customize the margin</span></span>

<span data-ttu-id="e1046-152">余白は、コントロールの視覚的な境界線と、フォーカスの視覚効果で示されるセカンダリ境界線の開始点との間にあるスペースです。</span><span class="sxs-lookup"><span data-stu-id="e1046-152">The margin is the space between the control's visual bounds and the start of the focus visuals secondary border.</span></span> <span data-ttu-id="e1046-153">既定の余白は、コントロールの境界線から 1 px の幅になります。</span><span class="sxs-lookup"><span data-stu-id="e1046-153">The default margin is 1px away from the control bounds.</span></span> <span data-ttu-id="e1046-154">この余白は、[FocusVisualMargin](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualMargin) プロパティを変更することでコントロールごとに変更できます。</span><span class="sxs-lookup"><span data-stu-id="e1046-154">You can edit this margin on a per-control basis by changing the [FocusVisualMargin](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualMargin) property:</span></span>

```xaml
<Button FocusVisualPrimaryThickness="2" FocusVisualSecondaryThickness="1" FocusVisualMargin="-3"/>
```

<span data-ttu-id="e1046-155">余白が負の値の場合は境界線がコントロールの中央から遠くなり、正の値の場合はコントロールの中央に近くなります。</span><span class="sxs-lookup"><span data-stu-id="e1046-155">A negative margin pushes the border away from the center of the control, and a positive margin moves the border closer to the center of the control.</span></span>

## <a name="customize-the-color"></a><span data-ttu-id="e1046-156">色のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="e1046-156">Customize the color</span></span>

<span data-ttu-id="e1046-157">表示フォーカス視覚効果の色を変更するには、[FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryBrush) プロパティと [FocusVisualSecondaryBrush](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryBrush) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="e1046-157">To change color of the reveal focus visual, use the [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryBrush) and [FocusVisualSecondaryBrush](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryBrush) properties.</span></span>

| <span data-ttu-id="e1046-158">プロパティ</span><span class="sxs-lookup"><span data-stu-id="e1046-158">Property</span></span> | <span data-ttu-id="e1046-159">既定のリソース</span><span class="sxs-lookup"><span data-stu-id="e1046-159">Default resource</span></span> | <span data-ttu-id="e1046-160">既定のリソースの値</span><span class="sxs-lookup"><span data-stu-id="e1046-160">Default resource value</span></span> |
| ---- | ---- | --- | 
| [<span data-ttu-id="e1046-161">FocusVisualPrimaryBrush</span><span class="sxs-lookup"><span data-stu-id="e1046-161">FocusVisualPrimaryBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryBrush) | <span data-ttu-id="e1046-162">SystemControlRevealFocusVisualBrush</span><span class="sxs-lookup"><span data-stu-id="e1046-162">SystemControlRevealFocusVisualBrush</span></span>  | <span data-ttu-id="e1046-163">SystemAccentColor</span><span class="sxs-lookup"><span data-stu-id="e1046-163">SystemAccentColor</span></span> |
| [<span data-ttu-id="e1046-164">FocusVisualSecondaryBrush</span><span class="sxs-lookup"><span data-stu-id="e1046-164">FocusVisualSecondaryBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryBrush)  | <span data-ttu-id="e1046-165">SystemControlFocusVisualSecondaryBrush</span><span class="sxs-lookup"><span data-stu-id="e1046-165">SystemControlFocusVisualSecondaryBrush</span></span>  | <span data-ttu-id="e1046-166">SystemAltMediumColor</span><span class="sxs-lookup"><span data-stu-id="e1046-166">SystemAltMediumColor</span></span> |

<span data-ttu-id="e1046-167">(FocusPrimaryBrush プロパティに既定の **SystemControlRevealFocusVisualBrush** リソースが使用されるのは、**FocusVisualKind** が **Reveal** に設定されている場合のみです。</span><span class="sxs-lookup"><span data-stu-id="e1046-167">(The FocusPrimaryBrush property only defaults to the **SystemControlRevealFocusVisualBrush** resources when **FocusVisualKind** is set to **Reveal**.</span></span> <span data-ttu-id="e1046-168">それ以外の場合は、**SystemControlFocusVisualPrimaryBrush** が使用されます。)</span><span class="sxs-lookup"><span data-stu-id="e1046-168">Otherwise, it uses **SystemControlFocusVisualPrimaryBrush**.)</span></span>


<span data-ttu-id="e1046-169">個々のコントロールのフォーカス視覚効果の色を変更するには、コントロールのプロパティを直接設定します。</span><span class="sxs-lookup"><span data-stu-id="e1046-169">To change the color of the focus visual of an individual control, set the properties directly on the control.</span></span> <span data-ttu-id="e1046-170">次の例では、ボタンのフォーカス視覚効果の色を上書きしています。</span><span class="sxs-lookup"><span data-stu-id="e1046-170">This example overrides the focus visual colors of a button.</span></span>

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

<span data-ttu-id="e1046-171">アプリ全体ですべてのフォーカス視覚効果の色を変更するには、**SystemControlRevealFocusVisualBrush** リソースと **SystemControlFocusVisualSecondaryBrush** リソースを独自定義で上書きします。</span><span class="sxs-lookup"><span data-stu-id="e1046-171">To change the color of all focus visuals in your entire app, override the **SystemControlRevealFocusVisualBrush** and  **SystemControlFocusVisualSecondaryBrush** resources with your own definition:</span></span>

```xaml
<!-- App.xaml -->
<Application.Resources>

    <!-- Override Reveal focus default resources. -->
    <SolidColorBrush x:Key="SystemControlRevealFocusVisualBrush" Color="{ThemeResource SystemBaseHighColor}"/>
    <SolidColorBrush x:Key="SystemControlFocusVisualSecondaryBrush" Color="{ThemeResource SystemAccentColor}"/>
</Application.Resources>
```

<span data-ttu-id="e1046-172">フォーカス視覚効果の色の変更について詳しくは、「[色のブランド化とカスタマイズ](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#color-branding--customizing)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1046-172">For more information on modifying the focus visual's color, see [Color Branding & Customizing](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#color-branding--customizing).</span></span>


## <a name="show-just-the-glow"></a><span data-ttu-id="e1046-173">グロー部分のみを表示する</span><span class="sxs-lookup"><span data-stu-id="e1046-173">Show just the glow</span></span>

<span data-ttu-id="e1046-174">プライマリまたはセカンダリのフォーカス視覚効果は使用せず、グローのみを使用する場合は、コントロールの [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryBrush) プロパティを `Transparent` に設定し、[FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryThickness) を `0` に設定します。</span><span class="sxs-lookup"><span data-stu-id="e1046-174">If you'd like to use only the glow without the primary or secondary focus visual, simply set the control's [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryBrush) property to `Transparent` and the [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualSecondaryThickness)  to `0`.</span></span> <span data-ttu-id="e1046-175">この場合は、グローにコントロールの背景色が使用され、境界線がない外観になります。</span><span class="sxs-lookup"><span data-stu-id="e1046-175">In this case, the glow will adopt the color of the control background to provide a borderless feel.</span></span> <span data-ttu-id="e1046-176">[FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryThickness) を使用して、グローの幅を変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="e1046-176">You can modify the thickness of the glow using [FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_FocusVisualPrimaryThickness).</span></span>

```xaml

<!-- Show just the glow -->
<Button
    FocusVisualPrimaryBrush="Transparent"
    FocusVisualSecondaryThickness="0" />    
```


## <a name="use-your-own-focus-visuals"></a><span data-ttu-id="e1046-177">独自のフォーカス視覚効果を使用する</span><span class="sxs-lookup"><span data-stu-id="e1046-177">Use your own focus visuals</span></span>

<span data-ttu-id="e1046-178">表示フォーカスをカスタマイズするもう 1 つの方法は、表示状態を使って独自のフォーカス表示効果を描画することにより、システムから提供されるフォーカス表示効果を除外することです。</span><span class="sxs-lookup"><span data-stu-id="e1046-178">Another way to customize reveal focus is to opt out of the system-provided focus visuals by drawing your own using visual states.</span></span> <span data-ttu-id="e1046-179">詳しくは、「[フォーカスの視覚効果のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619895)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1046-179">To learn more, see the [Focus visuals sample](http://go.microsoft.com/fwlink/p/?LinkID=619895).</span></span>


## <a name="reveal-focus-and-the-fluent-design-system"></a><span data-ttu-id="e1046-180">表示フォーカスと Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="e1046-180">Reveal focus and the Fluent Design System</span></span>

<span data-ttu-id="e1046-181">表示フォーカスは、アプリに発光効果を加える Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="e1046-181">Reveal focus is a Fluent Design System component that adds light to your app.</span></span> <span data-ttu-id="e1046-182">Fluent Design System およびその他のコンポーネントについて詳しくは、[UWP 用の Fluent Design の概要](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1046-182">To learn more about the Fluent Design system and its other components, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

## <a name="related-articles"></a><span data-ttu-id="e1046-183">関連記事</span><span class="sxs-lookup"><span data-stu-id="e1046-183">Related articles</span></span>

- [<span data-ttu-id="e1046-184">表示ハイライト</span><span class="sxs-lookup"><span data-stu-id="e1046-184">Reveal highlight</span></span>](https://docs.microsoft.com/windows/uwp/design/style/reveal)
- [<span data-ttu-id="e1046-185">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="e1046-185">Designing for Xbox and TV</span></span>](/windows/uwp/design/devices/designing-for-tv)
- [<span data-ttu-id="e1046-186">ゲームパッドとリモコンの操作</span><span class="sxs-lookup"><span data-stu-id="e1046-186">Gamepad and remote control interactions</span></span>](https://docs.microsoft.com/windows/uwp/design/input/gamepad-and-remote-interactions)
- [<span data-ttu-id="e1046-187">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="e1046-187">Focus visuals sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619895)
- [<span data-ttu-id="e1046-188">コンポジションの効果</span><span class="sxs-lookup"><span data-stu-id="e1046-188">Composition Effects</span></span>](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [<span data-ttu-id="e1046-189">システムの科学: Fluent Design と奥行き</span><span class="sxs-lookup"><span data-stu-id="e1046-189">Science in the System: Fluent Design and Depth</span></span>](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [<span data-ttu-id="e1046-190">システムの科学: Fluent Design と明るさ</span><span class="sxs-lookup"><span data-stu-id="e1046-190">Science in the System: Fluent Design and Light</span></span>](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
