---
author: mijacobs
description: 表示は発光効果の 1 つで、アプリの対話型要素に奥行きを与え、焦点を当てるために役立ちます。
title: 表示ハイライト
template: detail.hbs
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: conrwi
dev-contact: jevansa
doc-status: Published
ms.localizationpriority: high
ms.openlocfilehash: 2ec95f757b041b74dda8bc0606ad8113881809d5
ms.sourcegitcommit: ef5a1e1807313a2caa9c9b35ea20b129ff7155d0
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/08/2018
---
# <a name="reveal-highlight"></a><span data-ttu-id="2ce93-104">表示ハイライト</span><span class="sxs-lookup"><span data-stu-id="2ce93-104">Reveal highlight</span></span>

<span data-ttu-id="2ce93-105">表示ハイライトは、ユーザーがポインターを近付けたときにコマンド バーなどの対話型要素を目立たせるための発光効果です。</span><span class="sxs-lookup"><span data-stu-id="2ce93-105">Reveal highlight is a lighting effect that highlights interactive elements, such as command bars, when the user moves the pointer near them.</span></span> 

> <span data-ttu-id="2ce93-106">**重要な API**: [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)、[RevealBackgroundBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush)、[RevealBorderBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush)、[RevealBrushHelper クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper)、[VisualState class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)</span><span class="sxs-lookup"><span data-stu-id="2ce93-106">**Important APIs**: [RevealBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush), [RevealBackgroundBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush), [RevealBorderBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush), [RevealBrushHelper class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper), [VisualState class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)</span></span>

## <a name="how-it-works"></a><span data-ttu-id="2ce93-107">動作のしくみ</span><span class="sxs-lookup"><span data-stu-id="2ce93-107">How it works</span></span>
<span data-ttu-id="2ce93-108">表示ハイライトでは、対話型要素に注意が向くように、ポインターが近付いたときに要素のコンテナーが明示されます (下図参照)。</span><span class="sxs-lookup"><span data-stu-id="2ce93-108">Reveal highlight calls attention to interactive elements by revealing the element's container when the pointer is nearby, as shown in this illustration:</span></span>

![表示のビジュアル効果](images/Nav_Reveal_Animation.gif)

<span data-ttu-id="2ce93-110">オブジェクトの周囲にある非表示の境界線を明示すると、表示の動作によって、ユーザーが操作する領域の認識が容易になり、実行できる操作もわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="2ce93-110">By exposing the hidden borders around objects, Reveal gives users a better understanding of the space that they are interacting with, and helps them understand the actions available.</span></span> <span data-ttu-id="2ce93-111">これは、リスト コントロールやボタンのグループ化では特に重要です。</span><span class="sxs-lookup"><span data-stu-id="2ce93-111">This is especially important in list controls and groupings of buttons.</span></span>

## <a name="examples"></a><span data-ttu-id="2ce93-112">例</span><span class="sxs-lookup"><span data-stu-id="2ce93-112">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="2ce93-113">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="2ce93-113">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="2ce93-114"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Reveal">アプリを開き、表示効果の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="2ce93-114">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Reveal">open the app and see Reveal in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="2ce93-115">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="2ce93-115">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="2ce93-116">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="2ce93-116">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="video-summary"></a><span data-ttu-id="2ce93-117">概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="2ce93-117">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev013/player]

## <a name="how-to-use-it"></a><span data-ttu-id="2ce93-118">使用方法</span><span class="sxs-lookup"><span data-stu-id="2ce93-118">How to use it</span></span>

<span data-ttu-id="2ce93-119">表示効果は、一部のコントロールでは自動的に動作します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-119">Reveal automatically works for some controls.</span></span> <span data-ttu-id="2ce93-120">他のコントロールでは、コントロールに特別なスタイルを割り当てることにより表示効果を有効にできます。この記事の「[他のコントロールで表示効果を有効にする](#enabling-reveal-on-other-controls)」と「[カスタム コントロールで表示効果を有効にする](#enabling-reveal-on-custom-controls)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2ce93-120">For other controls, you can enable reveal by assigning a special style to the control, as described in the [Enabling Reveal on other controls](#enabling-reveal-on-other-controls) and [Enabling Reveal on custom controls](#enabling-reveal-on-custom-controls) sections of this article.</span></span>

## <a name="controls-that-automatically-use-reveal"></a><span data-ttu-id="2ce93-121">表示効果が自動的に使用されるコントロール</span><span class="sxs-lookup"><span data-stu-id="2ce93-121">Controls that automatically use Reveal</span></span>

- [**<span data-ttu-id="2ce93-122">ListView</span><span class="sxs-lookup"><span data-stu-id="2ce93-122">ListView</span></span>**](../controls-and-patterns/lists.md)
- [**<span data-ttu-id="2ce93-123">GridView</span><span class="sxs-lookup"><span data-stu-id="2ce93-123">GridView</span></span>**](../controls-and-patterns/lists.md)
- [**<span data-ttu-id="2ce93-124">TreeView</span><span class="sxs-lookup"><span data-stu-id="2ce93-124">TreeView</span></span>**](../controls-and-patterns/tree-view.md)
- [**<span data-ttu-id="2ce93-125">NavigationView</span><span class="sxs-lookup"><span data-stu-id="2ce93-125">NavigationView</span></span>**](../controls-and-patterns/navigationview.md)
- [**<span data-ttu-id="2ce93-126">MediaTransportControl</span><span class="sxs-lookup"><span data-stu-id="2ce93-126">MediaTransportControl</span></span>**](../controls-and-patterns/media-playback.md)
- [**<span data-ttu-id="2ce93-127">CommandBar</span><span class="sxs-lookup"><span data-stu-id="2ce93-127">CommandBar</span></span>**](../controls-and-patterns/app-bars.md)

<span data-ttu-id="2ce93-128">以下の図は、種類が異なるコントロールでの表示効果を示しています。</span><span class="sxs-lookup"><span data-stu-id="2ce93-128">These illustrations show the reveal effect on several different controls:</span></span>

![表示効果の例](images/RevealExamples_Collage.png)


## <a name="enabling-reveal-on-other-controls"></a><span data-ttu-id="2ce93-130">他のコントロールで表示効果を有効にする</span><span class="sxs-lookup"><span data-stu-id="2ce93-130">Enabling Reveal on other controls</span></span>

<span data-ttu-id="2ce93-131">表示の適用が必要なシナリオの場合 (シナリオで使用されるコントロールはメイン コンテンツである場合、またはそれらのコントロールがリストやコレクションに対応するために使用される場合)、オプトインのリソース スタイルが用意されているので、これらのスタイルを使用することで、そのような状況で表示を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-131">If you have a scenario where Reveal should be applied (these controls are main content and/or are used in a list or collection orientation), we've provided opt-in resource styles that allow you to enable Reveal for those types of situations.</span></span>

<span data-ttu-id="2ce93-132">以下に示すコントロールは、既定では表示の機能を備えていません。これらのコントロールは小さなコントロールであり、通常は、アプリケーションの重要なコンテンツをサポートするヘルパー コントロールですが、アプリによってはその状況は異なります。これらのコントロールをアプリの多くの部分で使用する場合は、その表示をサポートするスタイルがいくつか用意されているのでご利用ください。</span><span class="sxs-lookup"><span data-stu-id="2ce93-132">These controls do not have Reveal by default as they are smaller controls that are usually helper controls to the main focal points of your application; but every app is different, and if these controls are used the most in your app, we've provided some styles to aid with that:</span></span>

| <span data-ttu-id="2ce93-133">コントロール名</span><span class="sxs-lookup"><span data-stu-id="2ce93-133">Control Name</span></span>   | <span data-ttu-id="2ce93-134">リソース名</span><span class="sxs-lookup"><span data-stu-id="2ce93-134">Resource Name</span></span> |
|----------|:-------------:|
| <span data-ttu-id="2ce93-135">Button</span><span class="sxs-lookup"><span data-stu-id="2ce93-135">Button</span></span> |  <span data-ttu-id="2ce93-136">ButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="2ce93-136">ButtonRevealStyle</span></span> |
| <span data-ttu-id="2ce93-137">ToggleButton</span><span class="sxs-lookup"><span data-stu-id="2ce93-137">ToggleButton</span></span> | <span data-ttu-id="2ce93-138">ToggleButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="2ce93-138">ToggleButtonRevealStyle</span></span> |
| <span data-ttu-id="2ce93-139">RepeatButton</span><span class="sxs-lookup"><span data-stu-id="2ce93-139">RepeatButton</span></span> | <span data-ttu-id="2ce93-140">RepeatButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="2ce93-140">RepeatButtonRevealStyle</span></span> |
| <span data-ttu-id="2ce93-141">AppBarButton</span><span class="sxs-lookup"><span data-stu-id="2ce93-141">AppBarButton</span></span> | <span data-ttu-id="2ce93-142">AppBarButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="2ce93-142">AppBarButtonRevealStyle</span></span> |
| <span data-ttu-id="2ce93-143">AppBarToggleButton</span><span class="sxs-lookup"><span data-stu-id="2ce93-143">AppBarToggleButton</span></span> | <span data-ttu-id="2ce93-144">AppBarToggleButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="2ce93-144">AppBarToggleButtonRevealStyle</span></span> |
| <span data-ttu-id="2ce93-145">GridViewItem (表示効果がコンテンツより手前)</span><span class="sxs-lookup"><span data-stu-id="2ce93-145">GridViewItem (Reveal overtop of content)</span></span> | <span data-ttu-id="2ce93-146">GridViewItemRevealBackgroundShowsAboveContentStyle</span><span class="sxs-lookup"><span data-stu-id="2ce93-146">GridViewItemRevealBackgroundShowsAboveContentStyle</span></span> |

<span data-ttu-id="2ce93-147">これらのスタイルを適用するには、コントロールの [Style](/uwp/api/Windows.UI.Xaml.Style) プロパティを次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-147">To apply these styles, simply set the control's [Style](/uwp/api/Windows.UI.Xaml.Style) property:</span></span>

```xaml
<Button Content="Button Content" Style="{StaticResource ButtonRevealStyle}"/>
```

### <a name="reveal-in-themes"></a><span data-ttu-id="2ce93-148">テーマ内の表示効果</span><span class="sxs-lookup"><span data-stu-id="2ce93-148">Reveal in themes</span></span>

<span data-ttu-id="2ce93-149">表示効果は、コントロール、アプリ、またはユーザー設定で指定されているテーマによって少し異なります。</span><span class="sxs-lookup"><span data-stu-id="2ce93-149">Reveal changes slightly depending on the requested theme of the control, app or user setting.</span></span> <span data-ttu-id="2ce93-150">黒テーマの表示効果では境界線とホバー ライトが白ですが、白テーマでは境界線が明るい灰色になります。</span><span class="sxs-lookup"><span data-stu-id="2ce93-150">In Dark theme Reveal's Border and Hover light is white, but in Light theme just the Borders darken to a light gray.</span></span>

![黒テーマと白テーマでの表示効果](images/Dark_vs_LightReveal.png)

<span data-ttu-id="2ce93-152">白テーマのときに白の境界線を有効にするには、コントロールに指定されたテーマを黒に設定します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-152">To enabled white borders while in light theme, simply set the requested theme on the control to Dark.</span></span>

```xaml
<Grid RequestedTheme="Dark">
    <Button Content="Button" Click="Button_Click" Style="{ThemeResource ButtonRevealStyle}"/>
</Grid>
```

<span data-ttu-id="2ce93-153">または、RevealBorderBrush の TargetTheme を黒に変更します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-153">Or change the TargetTheme on the RevealBorderBrush to Dark.</span></span> <span data-ttu-id="2ce93-154">注意: </span><span class="sxs-lookup"><span data-stu-id="2ce93-154">Remember!</span></span> <span data-ttu-id="2ce93-155">TargetTheme が黒に設定されている場合、表示効果は白になりますが、TargetTheme が白に設定されている場合、表示効果の境界線は灰色になります。</span><span class="sxs-lookup"><span data-stu-id="2ce93-155">If the TargetTheme is set to Dark, then Reveal will be white, but if it's set to Light, Reveal's borders will be gray.</span></span>

```xaml
 <RevealBorderBrush x:Key="MyLightBorderBrush" TargetTheme="Dark" Color="{ThemeResource SystemAccentColor}" FallbackColor="{ThemeResource SystemAccentColor}" />
```

## <a name="enabling-reveal-on-custom-controls"></a><span data-ttu-id="2ce93-156">カスタム コントロールで表示効果を有効にする</span><span class="sxs-lookup"><span data-stu-id="2ce93-156">Enabling Reveal on custom controls</span></span>

<span data-ttu-id="2ce93-157">表示効果は、カスタム コントロールにも追加できます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-157">You can add Reveal to custom controls.</span></span> <span data-ttu-id="2ce93-158">その前に、表示効果の動作についてもう少し詳しく知っておくと便利です。</span><span class="sxs-lookup"><span data-stu-id="2ce93-158">Before you do, it's helpful to know a little more about about how the Reveal effect works.</span></span> <span data-ttu-id="2ce93-159">表示効果は、2 つの独立した効果 (**表示効果の境界線**と**表示効果のホバー**) で構成されています。</span><span class="sxs-lookup"><span data-stu-id="2ce93-159">Reveal is made up of two separate effects: **Reveal border** and **Reveal hover**.</span></span>

- <span data-ttu-id="2ce93-160">**表示効果の境界線**では、ポインターが近付くと、対話型要素の境界線が表示されます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-160">**Border** shows the borders of interactive elements when a pointer is nearby by.</span></span> <span data-ttu-id="2ce93-161">この効果では、現在フォーカスが置かれているオブジェクトと類似したアクションを、近くにある他のオブジェクトでも実行できることが示されます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-161">This effect shows you that those nearby objects can take actions similar to the one currently focused.</span></span>
- <span data-ttu-id="2ce93-162">**表示効果のホバー**では、ホバーされた (フォーカスが置かれた) 項目の周囲に淡く発光する図形が描画され、クリック時には押下操作のアニメーションが再生されます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-162">**Hover**  applies a gentle halo shape around the hovered or focused item and plays a press animation on click.</span></span> 

![表示効果のレイヤー](images/RevealLayers.png)

<!-- The Reveal recipe breakdown is:

- Border reveal will be on top of all content but on the designated edges
- Text and content will be displayed directly under Border Reveal
- Hover reveal will be beneath content and text
- The backplate (that turns on and enables Hover Reveal)
- The background (background of control) -->


<span data-ttu-id="2ce93-164">これらの効果は、次の 2 つのブラシによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-164">These effects are defined by two brushes:</span></span> 
* <span data-ttu-id="2ce93-165">表示効果の境界線は、**RevealBorderBrush** で定義されます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-165">Border reveal is defined by  **RevealBorderBrush**</span></span>
* <span data-ttu-id="2ce93-166">表示効果のホバーは、**RevealBackgroundBrush** で定義されます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-166">Hover reveal is defined by **RevealBackgroundBrush**</span></span>

```xaml
<RevealBorderBrush x:Key="MyRevealBorderBrush" TargetTheme="Light" Color="{ThemeResource SystemAccentColor}" FallbackColor="{ThemeResource SystemAccentColor}"/>
<RevealBackgroundBrush x:Key="MyRevealBackgroundBrush" TargetTheme="Light" Color="{StaticResource SystemAccentColor}" FallbackColor="{StaticResource SystemAccentColor}" />
```
<span data-ttu-id="2ce93-167">ほとんどの場合、特定のコントロールについては、表示効果が自動的に有効になってこれらの使用が処理されます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-167">In most cases we handle the usage of both of them by turning Reveal on automatically for a certain controls.</span></span> <span data-ttu-id="2ce93-168">その他のコントロールでは、スタイルを適用するかテンプレートを直接変更することで、有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2ce93-168">However, other controls will need to be enabled through applying a style, or changing their templates directly.</span></span>

### <a name="when-to-add-reveal"></a><span data-ttu-id="2ce93-169">表示効果の用途</span><span class="sxs-lookup"><span data-stu-id="2ce93-169">When to add Reveal</span></span>
<span data-ttu-id="2ce93-170">カスタム コントロールにも表示効果を追加できますが、その前に、コントロールの種類と動作を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="2ce93-170">You can add Reveal to your custom controls--but before you do, consider the type of control and how it behaves.</span></span> 
* <span data-ttu-id="2ce93-171">カスタム コントロールが単独の対話型要素であり、メニュー内のメニュー項目のように、類似する複数のコントロールが同じ場所にない場合は、そのカスタム コントロールには表示効果が不要である可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2ce93-171">If your custom control is a single interactive element and doesn't have similar controls sharing it's space (such as menu items in a menu), it's likely that your custom control doesn't need Reveal.</span></span>  
* <span data-ttu-id="2ce93-172">関連する対話型コンテンツまたは要素のグループがある場合は、アプリのその領域に表示効果が必要である可能性があります。これは一般的に、[コマンド実行](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/collection-commanding)サーフェスと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-172">If you have a grouping of related interactive content or elements, then it's likely that that region of your app does need Reveal - this is commonly referred to as a [Commanding](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/collection-commanding) surface.</span></span>

<span data-ttu-id="2ce93-173">たとえば、単独のボタンに表示効果は適していませんが、コマンド バー上の一連のボタンには表示効果が適しています。</span><span class="sxs-lookup"><span data-stu-id="2ce93-173">For example, a button by itself shouldn't use reveal, but a set of buttons in a command bar should use Reveal.</span></span>

<!-- For example, NavigationView's items are related to page navigation. CommandBar's buttons relate to menu actions or page feature actions. MediaTransportControl's buttons beneath all relate to the media being played. -->

### <a name="using-the-control-template-to-add-reveal"></a><span data-ttu-id="2ce93-174">コントロール テンプレートを使用して表示効果を追加する</span><span class="sxs-lookup"><span data-stu-id="2ce93-174">Using the control template to add Reveal</span></span> 
<span data-ttu-id="2ce93-175">カスタム コントロールまたは再テンプレート化されたコントロールで表示効果を有効にするには、コントロールのコントロール テンプレートを変更します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-175">To enable Reveal on custom controls or re-templated controls, you modify the control's control template.</span></span> <span data-ttu-id="2ce93-176">ほとんどのコントロール テンプレートでは、ルートにグリッドがあります。そのルート グリッドで表示効果を使用できるように [VisualState](/uwp/api/windows.ui.xaml.visualstate) を更新します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-176">Most control templates have a grid at the root; update the [VisualState](/uwp/api/windows.ui.xaml.visualstate) of that root grid to use Reveal:</span></span>

```xaml
<VisualState x:Name="PointerOver">
    <VisualState.Setters>
        <Setter Target="RootGrid.(RevealBrush.State)" Value="PointerOver" />
        <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPointerOver}" />
        <Setter Target="ContentPresenter.BorderBrush" Value="Transparent"/>
        <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPointerOver}" />
    </VisualState.Setters>
</VisualState>
```

<span data-ttu-id="2ce93-177">表示効果が正しく機能するためには、VisualState 内にブラシと setter の両方が必要である点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="2ce93-177">It's important to note that Reveal needs both the brush and the setters in it's Visual State to work correctly.</span></span> <span data-ttu-id="2ce93-178">コントロールのブラシをいずれかの表示ブラシ リソースに設定するだけでは、そのコントロールに対して表示効果は有効になりません。</span><span class="sxs-lookup"><span data-stu-id="2ce93-178">Simply setting a control's brush to one of our Reveal brush resources alone won't enable Reveal for that control.</span></span> <span data-ttu-id="2ce93-179">逆に、ターゲットまたは設定があっても表示ブラシを指定する値がなければ、表示効果は有効になりません。</span><span class="sxs-lookup"><span data-stu-id="2ce93-179">Conversely, having only the targets or settings without the values being Reveal brushes will also not enable Reveal.</span></span>

<span data-ttu-id="2ce93-180">コントロール テンプレートの変更について詳しくは、[XAML コントロール テンプレート](../controls-and-patterns/control-templates.md)に関する記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2ce93-180">To learn more about modifying control templates, see the [XAML control templates](../controls-and-patterns/control-templates.md) article.</span></span>

<span data-ttu-id="2ce93-181">テンプレートのカスタマイズに使うことができる一連のシステム表示ブラシが作成されました。</span><span class="sxs-lookup"><span data-stu-id="2ce93-181">We've created a set of system Reveal brushes you can use to customize your template.</span></span> <span data-ttu-id="2ce93-182">たとえば、**ButtonRevealBackground** ブラシを使ってカスタム ボタンの背景を作成したり、カスタム一覧に **ListViewItemRevealBackground** ブラシを使ったりすることができます </span><span class="sxs-lookup"><span data-stu-id="2ce93-182">For example, you can use the **ButtonRevealBackground** brush to create a custom button background, or the **ListViewItemRevealBackground** brush for custom lists, and so on.</span></span> <span data-ttu-id="2ce93-183">(XAMl でのリソースのしくみについて詳しくは、[Xaml リソース ディクショナリに関する記事](../controls-and-patterns/resourcedictionary-and-xaml-resource-references.md)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="2ce93-183">(To learn about how resources work in XAMl, check out the [Xaml Resource Dictionary](../controls-and-patterns/resourcedictionary-and-xaml-resource-references.md) article.)</span></span>

### <a name="full-template-example"></a><span data-ttu-id="2ce93-184">テンプレート全体の例</span><span class="sxs-lookup"><span data-stu-id="2ce93-184">Full template example</span></span>

<span data-ttu-id="2ce93-185">表示ボタンの外観を示すテンプレート全体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-185">Here's an entire template for what a Reveal Button would look like:</span></span>

```xaml
<Style TargetType="Button" x:Key="ButtonStyle1">
    <Setter Property="Background" Value="{ThemeResource ButtonRevealBackground}" />
    <Setter Property="Foreground" Value="{ThemeResource ButtonForeground}" />
    <Setter Property="BorderBrush" Value="{ThemeResource ButtonRevealBorderBrush}" />
    <Setter Property="BorderThickness" Value="2" />
    <Setter Property="Padding" Value="8,4,8,4" />
    <Setter Property="HorizontalAlignment" Value="Left" />
    <Setter Property="VerticalAlignment" Value="Center" />
    <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}" />
    <Setter Property="FontWeight" Value="Normal" />
    <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}" />
    <Setter Property="UseSystemFocusVisuals" Value="True" />
    <Setter Property="FocusVisualMargin" Value="-3" />
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="Button">
                <Grid x:Name="RootGrid" Background="{TemplateBinding Background}">

                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal">

                                <Storyboard>
                                    <PointerUpThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="PointerOver">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.(RevealBrush.State)" Value="PointerOver" />
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPointerOver}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="Transparent"/>
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPointerOver}" />
                                </VisualState.Setters>

                                <Storyboard>
                                    <PointerUpThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="Pressed">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.(RevealBrush.State)" Value="Pressed" />
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPressed}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBackgroundPressed}" />
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPressed}" />
                                </VisualState.Setters>

                                <Storyboard>
                                    <PointerDownThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="Disabled">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundDisabled}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBorderBrushDisabled}" />
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundDisabled}" />
                                </VisualState.Setters>
                            </VisualState>
                        </VisualStateGroup>

              </VisualStateManager.VisualStateGroups>
                    <ContentPresenter x:Name="ContentPresenter"
                    BorderBrush="{TemplateBinding BorderBrush}"
                    BorderThickness="{TemplateBinding BorderThickness}"
                    Content="{TemplateBinding Content}"
                    ContentTransitions="{TemplateBinding ContentTransitions}"
                    ContentTemplate="{TemplateBinding ContentTemplate}"
                    Padding="{TemplateBinding Padding}"
                    HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}"
                    VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}"
                    AutomationProperties.AccessibilityView="Raw" />
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

### <a name="fine-tuning-the-reveal-effect-on-a-custom-control"></a><span data-ttu-id="2ce93-186">カスタム コントロールに対する表示効果を微調整する</span><span class="sxs-lookup"><span data-stu-id="2ce93-186">Fine-tuning the Reveal effect on a custom control</span></span> 

<span data-ttu-id="2ce93-187">カスタム コントロールまたは再テンプレート化されたコントロールや、カスタムのコマンド実行サーフェスで表示効果を有効にする場合、その効果を最適化するには以下のヒントが役立ちます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-187">When you enable reveal on a custom or re-templated control or a custom commanding surface, these tips can help you optimize the effect:</span></span>
 
* <span data-ttu-id="2ce93-188">隣接する項目の高さまたは幅が一致しない場合 (特に、リスト内): 境界線のアプローチ動作を削除し、ホバー時のみ境界線を表示しておきます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-188">On adjacent items with sizes that do not align either in height or width (particularly in lists): Remove the border approach behavior and keep the borders shown on hover only.</span></span>
* <span data-ttu-id="2ce93-189">無効状態への移行と解除が頻繁に発生するコマンド実行項目の場合: 境界線アプローチのブラシを要素のバックプレートとバックプレートの境界線に配置して、状態を強調します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-189">For commanding items that frequently go in and out of the disabled state: Place the border approach brush on the elements' backplates as well as their borders to emphasize their state.</span></span>
* <span data-ttu-id="2ce93-190">隣接するコマンド実行要素の間隔が狭すぎて接触する場合: 2 つの要素間に 1 px の余白を追加します。</span><span class="sxs-lookup"><span data-stu-id="2ce93-190">For adjacent commanding elements that are so close they touch: Add a 1px margin between the two elements.</span></span> 

## <a name="dos-and-donts"></a><span data-ttu-id="2ce93-191">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="2ce93-191">Do's and don'ts</span></span>
- <span data-ttu-id="2ce93-192">ユーザーが多数の操作を実行できる要素 (CommandBar、ナビゲーション メニュー) で表示効果を使う</span><span class="sxs-lookup"><span data-stu-id="2ce93-192">Do use Reveal on elements where the user can take many actions (CommandBars, Navigation menus)</span></span>
- <span data-ttu-id="2ce93-193">既定で視覚的な区切りがない対話型要素のグループ (一覧、リボン) 内で表示効果を使う</span><span class="sxs-lookup"><span data-stu-id="2ce93-193">Do use Reveal in groupings of interactive elements that do not have visual separators by default (lists, ribbons)</span></span>
- <span data-ttu-id="2ce93-194">対話型要素が密集している領域では表示を使う (コマンド実行シナリオ)</span><span class="sxs-lookup"><span data-stu-id="2ce93-194">Do use Reveal in areas with a high density of interactive elements (commanding scenarios)</span></span>
- <span data-ttu-id="2ce93-195">表示効果を適用する項目と項目の間に 1 px の余白を配置する</span><span class="sxs-lookup"><span data-stu-id="2ce93-195">Do put 1px margin spaces between Reveal items</span></span>
- <span data-ttu-id="2ce93-196">静的コンテンツ (背景、テキスト) では表示効果を使わない</span><span class="sxs-lookup"><span data-stu-id="2ce93-196">Don’t use Reveal on static content (backgrounds, text)</span></span>
- <span data-ttu-id="2ce93-197">ポップアップやドロップダウンでは表示効果を使わない</span><span class="sxs-lookup"><span data-stu-id="2ce93-197">Don't use Reveal on popups, flyouts or dropdowns</span></span>
- <span data-ttu-id="2ce93-198">1 回限りの個別の状況では表示効果を使わない</span><span class="sxs-lookup"><span data-stu-id="2ce93-198">Don’t use Reveal in one-off, isolated situations</span></span>
- <span data-ttu-id="2ce93-199">非常に多くの項目 (500 epx 超) では表示効果を使わない</span><span class="sxs-lookup"><span data-stu-id="2ce93-199">Don’t use Reveal on very large items (greater than 500epx)</span></span>
- <span data-ttu-id="2ce93-200">セキュリティ上の決定を行う場面では表示効果を使わない (ユーザーに提供する必要があるメッセージから注意がそれる可能性があるため)</span><span class="sxs-lookup"><span data-stu-id="2ce93-200">Don’t use Reveal in security decisions, as it may draw attention away from the message you need to deliver to your user</span></span>


## <a name="get-the-sample-code"></a><span data-ttu-id="2ce93-201">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="2ce93-201">Get the sample code</span></span>

- <span data-ttu-id="2ce93-202">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-202">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="reveal-and-the-fluent-design-system"></a><span data-ttu-id="2ce93-203">表示効果と Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="2ce93-203">Reveal and the Fluent Design System</span></span>

 <span data-ttu-id="2ce93-204">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="2ce93-204">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="2ce93-205">表示は、アプリに発光効果を加える Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="2ce93-205">Reveal is a Fluent Design System component that adds light to your app.</span></span> <span data-ttu-id="2ce93-206">詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2ce93-206">To learn more, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

## <a name="related-articles"></a><span data-ttu-id="2ce93-207">関連記事</span><span class="sxs-lookup"><span data-stu-id="2ce93-207">Related articles</span></span>

- [<span data-ttu-id="2ce93-208">RevealBrush クラス</span><span class="sxs-lookup"><span data-stu-id="2ce93-208">RevealBrush class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)
- [<span data-ttu-id="2ce93-209">アクリル</span><span class="sxs-lookup"><span data-stu-id="2ce93-209">Acrylic</span></span>](acrylic.md)
- [<span data-ttu-id="2ce93-210">コンポジションの効果</span><span class="sxs-lookup"><span data-stu-id="2ce93-210">Composition Effects</span></span>](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [<span data-ttu-id="2ce93-211">UWP の Fluent Design</span><span class="sxs-lookup"><span data-stu-id="2ce93-211">Fluent Design for UWP</span></span>](../fluent-design-system/index.md)
- [<span data-ttu-id="2ce93-212">システムの科学: Fluent Design と奥行き</span><span class="sxs-lookup"><span data-stu-id="2ce93-212">Science in the System: Fluent Design and Depth</span></span>](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [<span data-ttu-id="2ce93-213">システムの科学: Fluent Design と明るさ</span><span class="sxs-lookup"><span data-stu-id="2ce93-213">Science in the System: Fluent Design and Light</span></span>](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
