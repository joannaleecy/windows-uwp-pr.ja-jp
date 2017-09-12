---
author: mijacobs
description: "表示は新しい相互作用モデルで、アプリケーションでのフォーカスの効果を高め、魅力的なアプリケーションを作成する際に役立ちます。"
title: "表示"
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
ms.openlocfilehash: d50e3f47faad5fff0ef461a4b5312127a0b9ec9c
ms.sourcegitcommit: 0d5b3daddb3ae74f91178c58e35cbab33854cb7f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="reveal"></a><span data-ttu-id="4be8c-104">表示</span><span class="sxs-lookup"><span data-stu-id="4be8c-104">Reveal</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4be8c-105">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4be8c-105">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="4be8c-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="4be8c-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="4be8c-107">表示は照明効果の 1 つで、アプリの対話型要素に奥行きを与え、焦点を当てるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="4be8c-107">Reveal is a lighting effect that helps bring depth and focus to your app's interactive elements.</span></span>

> <span data-ttu-id="4be8c-108">**重要な API**: [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)、[RevealBackgroundBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush)、[RevealBorderBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush)、[RevealBrushHelper クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper)、[VisualState class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)</span><span class="sxs-lookup"><span data-stu-id="4be8c-108">**Important APIs**: [RevealBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush), [RevealBackgroundBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush), [RevealBorderBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush), [RevealBrushHelper class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper), [VisualState class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)</span></span>

<span data-ttu-id="4be8c-109">表示の動作は、マウスやフォーカス用の四角形が目的の領域の上に置かれたときに、ヒーロー コンテンツ (重要なコンテンツ) の周囲にある要素を明確に表示することによって実現されます。</span><span class="sxs-lookup"><span data-stu-id="4be8c-109">The Reveal behavior does this by revealing pieces of elements around hero (or focal) content when the mouse or focus rectangle is over the desired areas.</span></span>

![表示のビジュアル効果](images/Nav_Reveal_Animation.gif)

<span data-ttu-id="4be8c-111">オブジェクトの周囲にある非表示の境界線を明示すると、表示の動作によって、ユーザーが操作する領域の認識が容易になり、実行できる操作もわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="4be8c-111">Through exposing the hidden borders around objects, Reveal gives users a better understanding of the space that they are interacting with, and helps them understand the actions available.</span></span> <span data-ttu-id="4be8c-112">これは、リスト コントロールやバック プレートを持つコントロールでは特に重要です。</span><span class="sxs-lookup"><span data-stu-id="4be8c-112">This is especially important in list controls and controls with backplates.</span></span>

## <a name="reveal-and-the-fluent-design-system"></a><span data-ttu-id="4be8c-113">表示と Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="4be8c-113">Reveal and the Fluent Design System</span></span>

 <span data-ttu-id="4be8c-114">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="4be8c-114">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="4be8c-115">表示は、アプリにライトを追加する Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="4be8c-115">Reveal is a Fluent Design System component that adds light to your app.</span></span> 

## <a name="what-is-reveal"></a><span data-ttu-id="4be8c-116">表示とは</span><span class="sxs-lookup"><span data-stu-id="4be8c-116">What is reveal?</span></span>

<span data-ttu-id="4be8c-117">表示には 2 つの主要な視覚コンポーネントがあります。それらは、**ホバーによる表示**動作と**境界線による表示**動作です。</span><span class="sxs-lookup"><span data-stu-id="4be8c-117">There are two main visual components to Reveal: the **Hover Reveal** behavior, and the **Border Reveal** behavior.</span></span>

![表示レイヤー](images/RevealLayers.png)

<span data-ttu-id="4be8c-119">ホバーによる表示は、ポインターやフォーカス入力によってポイントされるコンテンツに直接関連付けられており、ポイントされる項目やフォーカスが置かれる項目の周囲に滑らかなハロー型を適用し、その項目が操作可能であることを示します。</span><span class="sxs-lookup"><span data-stu-id="4be8c-119">The Hover Reveal is tied directly to the content being hovered over (via pointer or focus input), and applies a gentle halo shape around the hovered or focused item, letting you know you can interact with it.</span></span>

<span data-ttu-id="4be8c-120">境界線による表示は、フォーカスが置かれる項目やその近くにある項目に適用されます。</span><span class="sxs-lookup"><span data-stu-id="4be8c-120">The Border Reveal is applied to the focused item and items nearby.</span></span> <span data-ttu-id="4be8c-121">これにより、オブジェクトの近くにある項目に対して、現在フォーカスが置かれている項目と類似した操作を実行できること示されます。</span><span class="sxs-lookup"><span data-stu-id="4be8c-121">This shows you that those nearby objects can take actions similar to the one currently focused.</span></span>

<span data-ttu-id="4be8c-122">表示のレシピには以下のものがあります。</span><span class="sxs-lookup"><span data-stu-id="4be8c-122">The Reveal recipe breakdown is:</span></span>

- <span data-ttu-id="4be8c-123">境界線による表示は、すべてのコンテンツの最上位にありますが、指定されたエッジの上に配置されます</span><span class="sxs-lookup"><span data-stu-id="4be8c-123">Border Reveal will be on top of all content but on the designated edges</span></span>
- <span data-ttu-id="4be8c-124">テキストとコンテンツは、境界線による表示の直下に表示されます</span><span class="sxs-lookup"><span data-stu-id="4be8c-124">Text and content will be displayed directly under Border Reveal</span></span>
- <span data-ttu-id="4be8c-125">ホバーによる表示は、コンテンツとテキストの下にあります</span><span class="sxs-lookup"><span data-stu-id="4be8c-125">Hover Reveal will be beneath content and text</span></span>
- <span data-ttu-id="4be8c-126">バック プレート (ホバーによる表示をオンにして有効にします)</span><span class="sxs-lookup"><span data-stu-id="4be8c-126">The backplate (that turns on and enables Hover Reveal)</span></span>
- <span data-ttu-id="4be8c-127">背景 (コントロールの背景です)</span><span class="sxs-lookup"><span data-stu-id="4be8c-127">The background (background of control)</span></span>

<!--
<div class=”microsoft-internal-note”>
To create your own Reveal lighting effect for static comps or prototype purposes, see the full [uni design guidance](http://uni/DesignDepot.FrontEnd/#/ProductNav/3020/1/dv/?t=Resources%7CToolkit%7CReveal&f=Neon) for this effect in illustrator.
</div>
-->

## <a name="how-to-use-it"></a><span data-ttu-id="4be8c-128">用途</span><span class="sxs-lookup"><span data-stu-id="4be8c-128">How to use it</span></span>

<span data-ttu-id="4be8c-129">表示を使用すると、必要に応じてカーソルの周囲にジオメトリが明示され、カーソルが離れるとそのジオメトリがシームレスにフェード アウトします。</span><span class="sxs-lookup"><span data-stu-id="4be8c-129">Reveal exposes geometry around your cursor when you need it, and seamlessly fades it out once you’ve moved on.</span></span>

<span data-ttu-id="4be8c-130">表示は、境界やバック プレートが暗示的に示されている、アプリの主要なコンテンツ (ヒーロー コンテンツ) 上で有効にするのが最適な使用方法です。</span><span class="sxs-lookup"><span data-stu-id="4be8c-130">Reveal is best used when enabled on the main content of your app (hero content) that has implied boundries and backplates to them.</span></span> <span data-ttu-id="4be8c-131">また、表示をコレクションやリストのようなコントロールで使用することもお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4be8c-131">Reveal should additionally be used on collection or list-like controls.</span></span>

## <a name="controls-that-automatically-use-reveal"></a><span data-ttu-id="4be8c-132">表示を自動的に使用するコントロール</span><span class="sxs-lookup"><span data-stu-id="4be8c-132">Controls that automatically use Reveal</span></span>

- [**<span data-ttu-id="4be8c-133">ListView</span><span class="sxs-lookup"><span data-stu-id="4be8c-133">ListView</span></span>**](../controls-and-patterns/lists.md)
- [**<span data-ttu-id="4be8c-134">TreeView</span><span class="sxs-lookup"><span data-stu-id="4be8c-134">TreeView</span></span>**](../controls-and-patterns/tree-view.md)
- [**<span data-ttu-id="4be8c-135">NavigationView</span><span class="sxs-lookup"><span data-stu-id="4be8c-135">NavigationView</span></span>**](../controls-and-patterns/navigationview.md)
- [**<span data-ttu-id="4be8c-136">AutosuggestBox</span><span class="sxs-lookup"><span data-stu-id="4be8c-136">AutosuggestBox</span></span>**](../controls-and-patterns/auto-suggest-box.md)

## <a name="enabling-reveal-on-other-common-controls"></a><span data-ttu-id="4be8c-137">他の一般的なコントロールで表示を有効にする</span><span class="sxs-lookup"><span data-stu-id="4be8c-137">Enabling Reveal on other common controls</span></span>

<span data-ttu-id="4be8c-138">表示の適用が必要なシナリオの場合 (シナリオで使用されるコントロールはメイン コンテンツである場合、またはそれらのコントロールがリストやコレクションに対応するために使用される場合)、オプトインのリソース スタイルが用意されているので、これらのスタイルを使用することで、そのような状況で表示を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="4be8c-138">If you have a scenario where Reveal should be applied (these controls are main content and/or are used in a list or collection orientation), we've provided opt-in resourse styles that allow you to enable Reveal for those types of situations.</span></span>

<span data-ttu-id="4be8c-139">以下に示すコントロールは、既定では表示の機能を備えていません。これらのコントロールは小さなコントロールであり、通常は、アプリケーションの重要なコンテンツをサポートするヘルパー コントロールですが、アプリによってはその状況は異なります。これらのコントロールをアプリの多くの部分で使用する場合は、その表示をサポートするスタイルがいくつか用意されているのでご利用ください。</span><span class="sxs-lookup"><span data-stu-id="4be8c-139">These controls do not have Reveal by default as they are smaller controls that are usually helper controls to the main focal points of your application; but every app is different, and if these controls are used the most in your app, we've provided some styles to aid with that:</span></span>

| <span data-ttu-id="4be8c-140">コントロール名</span><span class="sxs-lookup"><span data-stu-id="4be8c-140">Control Name</span></span>   | <span data-ttu-id="4be8c-141">リソース名</span><span class="sxs-lookup"><span data-stu-id="4be8c-141">Resource Name</span></span> |
|----------|:-------------:|
| <span data-ttu-id="4be8c-142">Button</span><span class="sxs-lookup"><span data-stu-id="4be8c-142">Button</span></span> |  <span data-ttu-id="4be8c-143">ButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="4be8c-143">ButtonRevealStyle</span></span> |
| <span data-ttu-id="4be8c-144">ToggleButton</span><span class="sxs-lookup"><span data-stu-id="4be8c-144">ToggleButton</span></span> | <span data-ttu-id="4be8c-145">ToggleButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="4be8c-145">ToggleButtonRevealStyle</span></span> |
| <span data-ttu-id="4be8c-146">RepeatButton</span><span class="sxs-lookup"><span data-stu-id="4be8c-146">RepeatButton</span></span> | <span data-ttu-id="4be8c-147">RepeatButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="4be8c-147">RepeatButtonRevealStyle</span></span> |
| <span data-ttu-id="4be8c-148">AppBarButton</span><span class="sxs-lookup"><span data-stu-id="4be8c-148">AppBarButton</span></span> | <span data-ttu-id="4be8c-149">AppBarButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="4be8c-149">AppBarButtonRevealStyle</span></span> |
| <span data-ttu-id="4be8c-150">SemanticZoom</span><span class="sxs-lookup"><span data-stu-id="4be8c-150">SemanticZoom</span></span> | <span data-ttu-id="4be8c-151">SemanticZoomRevealStyle</span><span class="sxs-lookup"><span data-stu-id="4be8c-151">SemanticZoomRevealStyle</span></span> |
| <span data-ttu-id="4be8c-152">ComboBoxItem</span><span class="sxs-lookup"><span data-stu-id="4be8c-152">ComboBoxItem</span></span> | <span data-ttu-id="4be8c-153">ComboxBoxItemRevealStyle</span><span class="sxs-lookup"><span data-stu-id="4be8c-153">ComboxBoxItemRevealStyle</span></span> |

<span data-ttu-id="4be8c-154">これらのスタイルを適用するには、Style プロパティを次のように更新するだけです。</span><span class="sxs-lookup"><span data-stu-id="4be8c-154">To apply these styles, simply update the Style property like so:</span></span>

```XAML
<Button Content="Button Content" Style="{StaticResource ButtonRevealStyle}"/>
```

> [!NOTE]
> <span data-ttu-id="4be8c-155">SDK バージョン 16190 では、これらのスタイルは自動的には提供されません。</span><span class="sxs-lookup"><span data-stu-id="4be8c-155">The 16190 version of the SDK does not make these styles automatically available.</span></span> <span data-ttu-id="4be8c-156">これらを使うには、generic.xaml から手動でアプリにコピーする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4be8c-156">To get them, you need to manually copy them from generic.xaml into your app.</span></span> <span data-ttu-id="4be8c-157">generic.xaml は通常、C:\Program Files (x86)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\10.0.16190.0\Generic に配置されています。</span><span class="sxs-lookup"><span data-stu-id="4be8c-157">Generic.xaml is typically located at C:\Program Files (x86)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\10.0.16190.0\Generic.</span></span> <span data-ttu-id="4be8c-158">この問題は今後のビルドで修正される予定です。</span><span class="sxs-lookup"><span data-stu-id="4be8c-158">This issue will be fixed in a later build.</span></span> 

## <a name="enabling-reveal-on-custom-controls"></a><span data-ttu-id="4be8c-159">カスタム コントロールで表示を有効にする</span><span class="sxs-lookup"><span data-stu-id="4be8c-159">Enabling Reveal on custom controls</span></span>

<span data-ttu-id="4be8c-160">カスタム コントロールや再テンプレート化されたコントロールで表示を有効にするには、そのコントロールのテンプレートの表示状態 (VisualState) でコントロールのスタイルを調べ、ルート グリッドで表示を指定します。</span><span class="sxs-lookup"><span data-stu-id="4be8c-160">To enable Reveal on custom controls or re-templated controls, you can go into the style for that control in the Visual States of that control's template, specify Reveal on the root grid:</span></span>

```xaml
<VisualState x:Name="PointerOver">
  <VisualState.Setters>
    <Setter Target="RootGrid.(RevealBrushHelper.State)" Value="PointerOver" />
    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPointerOver}"/>
    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBorderBrushPointerOver}"/>
    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPointerOver}"/>
  </VisualState.Setters>
</VisualState>
```

<span data-ttu-id="4be8c-161">表示のプル効果を実現するには、PressedState に同じ RevealBrushHelper を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4be8c-161">To get the pull effect of Reveal you'll need to add the same RevealBrushHelper to the PressedState as well:</span></span>

```xaml
<VisualState x:Name="Pressed">
  <VisualState.Setters>
    <Setter Target="RootGrid.(RevealBrushHelper.State)" Value="Pressed" />
    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPressed}"/>
    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBorderBrushPressed}"/>
    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPressed}"/>
  </VisualState.Setters>
</VisualState>
```


<span data-ttu-id="4be8c-162">システム リソースである "表示" を使用することは、すべてのテーマの変更が自動的に処理されることを意味します。</span><span class="sxs-lookup"><span data-stu-id="4be8c-162">Using our system resource Reveal means we will handle all the theme changes for you.</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="4be8c-163">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="4be8c-163">Do's and don'ts</span></span>
- <span data-ttu-id="4be8c-164">表示は、ユーザーが操作できる要素に対して使用してください - 表示は、静的なコンテンツに対しては使用しないでください</span><span class="sxs-lookup"><span data-stu-id="4be8c-164">Do have Reveal on elements that the user can take actions on - Reveal should not be on static content</span></span>
- <span data-ttu-id="4be8c-165">データのリストやコレクションで表示の効果を利用してください</span><span class="sxs-lookup"><span data-stu-id="4be8c-165">Do show Reveal in lists or collections of data</span></span>
- <span data-ttu-id="4be8c-166">表示は、バック プレートを持ち、明示的に含まれているコンテンツに適用してください</span><span class="sxs-lookup"><span data-stu-id="4be8c-166">Do apply Reveal to clearly contained content with backplates</span></span>
- <span data-ttu-id="4be8c-167">操作することができない静的な背景、テキスト、画像では表示の効果を利用しないでください</span><span class="sxs-lookup"><span data-stu-id="4be8c-167">Don’t show Reveal on static backgrounds, text, or images that you can’t interact with</span></span>
- <span data-ttu-id="4be8c-168">無関係な浮動コンテンツには表示を適用しないでください</span><span class="sxs-lookup"><span data-stu-id="4be8c-168">Don’t apply Reveal to unrelated floating content</span></span>
- <span data-ttu-id="4be8c-169">1 回限りの個別の状況 (コンテンツ ダイアログや通知など) では表示を使用しないでください</span><span class="sxs-lookup"><span data-stu-id="4be8c-169">Don’t use Reveal in one-off, isolated situations, like content dialogs or notifications</span></span>
- <span data-ttu-id="4be8c-170">セキュリティ上の決定を行う場合には表示を使用しないでください (ユーザーに提供する必要があるメッセージから注意がそれる可能性があるため)</span><span class="sxs-lookup"><span data-stu-id="4be8c-170">Don’t use Reveal in security decisions, as it may draw attention away from the message you need to deliver to your user</span></span>

## <a name="related-articles"></a><span data-ttu-id="4be8c-171">関連記事</span><span class="sxs-lookup"><span data-stu-id="4be8c-171">Related articles</span></span>

- [<span data-ttu-id="4be8c-172">RevealBrush クラス</span><span class="sxs-lookup"><span data-stu-id="4be8c-172">RevealBrush class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)
- [**<span data-ttu-id="4be8c-173">アクリル</span><span class="sxs-lookup"><span data-stu-id="4be8c-173">Acrylic</span></span>**](acrylic.md)
- [**<span data-ttu-id="4be8c-174">コンポジションの効果</span><span class="sxs-lookup"><span data-stu-id="4be8c-174">Composition Effects</span></span>**](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
