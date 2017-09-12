---
author: mijacobs
description: 
title: "アクリル素材"
template: detail.hbs
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: rybick
dev-contact: jevansa
doc-status: Published
ms.openlocfilehash: 01c8d1bd961a5246a052d1dc7a746257687104e4
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="acrylic-material"></a><span data-ttu-id="5076d-103">アクリル素材</span><span class="sxs-lookup"><span data-stu-id="5076d-103">Acrylic material</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

> [!IMPORTANT]
> <span data-ttu-id="5076d-104">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5076d-104">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="5076d-105">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="5076d-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="5076d-106">アクリルは [Brush](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush) の一種であり、半透明のテクスチャを作成します。</span><span class="sxs-lookup"><span data-stu-id="5076d-106">Acrylic is a type of [Brush](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush) that creates a partially transparent texture.</span></span> <span data-ttu-id="5076d-107">アクリルをアプリ サーフェスに適用すると、奥行きを加えたり、視覚的な階層を確立したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-107">You can apply acrylic to app surfaces to add depth and help establish a visual hierarchy.</span></span>  <!-- By allowing user-selected wallpaper or colors to shine through, Acrylic keeps users in touch with the OS personalization they've chosen. -->

> <span data-ttu-id="5076d-108">**重要な API**: [AcrylicBrush クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush)、[Background プロパティ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Background)</span><span class="sxs-lookup"><span data-stu-id="5076d-108">**Important APIs**: [AcrylicBrush class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush), [Background property](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Background)</span></span>


![淡色テーマのアクリル](images/Acrylic_DarkTheme_Base.png)

![濃色テーマのアクリル](images/Acrylic_LightTheme_Base.png)

## <a name="acrylic-and-the-fluent-design-system"></a><span data-ttu-id="5076d-111">アクリルと Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="5076d-111">Acrylic and the Fluent Design System</span></span>

 <span data-ttu-id="5076d-112">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="5076d-112">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="5076d-113">アクリルは、アプリに物理的なテクスチャ (マテリアル) と深度を追加する Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="5076d-113">Acrylic is a Fluent Design System component that adds physical texture (material) and depth to your app.</span></span> 

## <a name="when-to-use-acrylic"></a><span data-ttu-id="5076d-114">アクリルを使用する状況</span><span class="sxs-lookup"><span data-stu-id="5076d-114">When to use acrylic</span></span>

<span data-ttu-id="5076d-115">アプリ内ナビゲーションの要素やコマンド実行要素などのサポート UI は、アクリル サーフェス上に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-115">We recommend that you place supporting UI, such as in-app navigation or commanding elements, on an acrylic surface.</span></span> <span data-ttu-id="5076d-116">アクリル素材は、ダイアログやポップアップなどの一時的な UI の要素を使用する場合にも役立ちます。これは、この素材によって、一時的な UI をトリガーしたコンテンツとの視覚的な関係を維持することができるためです。</span><span class="sxs-lookup"><span data-stu-id="5076d-116">This material is also helpful for transient UI elements, such as dialogs and flyouts, because it helps maintain a visual relationship with the content that triggered the transient UI.</span></span> <span data-ttu-id="5076d-117">アクリルは、背景素材として使用し、視覚的に分離されたウィンドウ内に表示するように設計されています。そのため、アクリルは詳細な前景要素には適用しないでください。</span><span class="sxs-lookup"><span data-stu-id="5076d-117">We designed acrylic to be used as a background material and show in visually discrete panes, so don't apply acrylic to detailed foreground elements.</span></span>

<span data-ttu-id="5076d-118">アプリの主要なコンテンツの背後にあるサーフェスでは、単色で不透明な背景を使用してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-118">Surfaces behind primary app content should use solid, opaque backgrounds.</span></span>

<span data-ttu-id="5076d-119">滑らかな表示を実現するには、アクリルを、アプリの 1 つまたは複数の端にまで (ウィンドウのタイトル バーも含む) 拡張することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-119">Consider having acrylic extend to one or more edges of your app, including the window title bar, to improve visual flow.</span></span> <span data-ttu-id="5076d-120">ブレンドの種類が異なる複数のアクリルを相互に隣接するように重ねて、ストライプ効果を作成することは回避してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-120">Avoid creating a striping effect by stacking acrylics of different blend types adjacent to each other.</span></span> <span data-ttu-id="5076d-121">アクリルは、デザインで視覚的な調和をとるためのツールですが、正しく使用しないと、視覚的なノイズになる場合があります。</span><span class="sxs-lookup"><span data-stu-id="5076d-121">Acrylic is a tool to bring visual harmony to your designs but, when used incorrectly, can result in visual noise.</span></span>

<span data-ttu-id="5076d-122">次の使用パターンを検討して、アクリルをアプリに組み込むに最適な方法を決定してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-122">Consider the following usage patterns to decide how best to incorporate acrylic into your app.</span></span>

### <a name="vertical-acrylic-pane"></a><span data-ttu-id="5076d-123">垂直方向のアクリル ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="5076d-123">Vertical acrylic pane</span></span>

<span data-ttu-id="5076d-124">垂直方向のナビゲーションを行うアプリでは、アクリルを、ナビゲーション要素を含んでいるセカンダリ ウィンドウに適用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-124">For apps with vertical navigation, we recommend applying acrylic to the secondary pane containing navigation elements.</span></span>

![1 つの垂直方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_vertical.png)

<span data-ttu-id="5076d-126">[NavigationView](../controls-and-patterns/navigationview.md) は、ナビゲーションをアプリに追加し、そのビジュアル デザインにアクリルを取り込むための新しいコモン コントロール です。</span><span class="sxs-lookup"><span data-stu-id="5076d-126">[NavigationView](../controls-and-patterns/navigationview.md) is a new common control for adding navigation to your app and includes acrylic in its visual design.</span></span> <span data-ttu-id="5076d-127">NavigationView のウィンドウでは、ウィンドウが主要なコンテンツと並んで開かれるとき、背景アクリルが表示されます。また、ウィンドウがオーバーレイとして開くと、自動的にアプリ内アクリルに切り替わります。</span><span class="sxs-lookup"><span data-stu-id="5076d-127">NavigationView’s pane shows background acrylic when the pane is open side-by-side with primary content, and automatically transitions to in-app acrylic when the pane is open as an overlay.</span></span>

<span data-ttu-id="5076d-128">アプリでは NavigationView を利用できず、独自にアクリルを追加することを検討している場合は、比較的透明なアクリル (濃淡の透明度が 60%) を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-128">If your app is not able to leverage NavigationView and you plan on adding acrylic on your own, we recommend using relatively transparent acrylic with 60% tint opacity.</span></span>
 - <span data-ttu-id="5076d-129">ウィンドウが他のアプリ コンテンツ上でオーバーレイとして開くときは、[60% のアプリ内アクリル](#acrylic-theme-resources)にする必要があります</span><span class="sxs-lookup"><span data-stu-id="5076d-129">When the pane opens as an overlay above other app content, this should be [60% in-app acrylic](#acrylic-theme-resources)</span></span>
 - <span data-ttu-id="5076d-130">ウィンドウがメイン アプリ コンテンツと並んで開かれるときは、[60% の背景アクリル](#acrylic-theme-resources)にする必要があります</span><span class="sxs-lookup"><span data-stu-id="5076d-130">When the pane opens side-by-side with main app content, this should be [60% background acrylic](#acrylic-theme-resources)</span></span>

### <a name="multiple-acrylic-panes"></a><span data-ttu-id="5076d-131">複数のアクリル ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="5076d-131">Multiple acrylic panes</span></span>

<span data-ttu-id="5076d-132">3 つの異なる垂直方向のウィンドウを持つアプリでは、アクリルを主要なコンテンツ以外のコンテンツに追加することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-132">For apps with three distinct vertical panes, we recommend adding acrylic to non-primary content.</span></span>
 - <span data-ttu-id="5076d-133">主要なコンテンツの最も近くに表示される第 2 ウィンドウでは、[80% の背景アクリル](#acrylic-theme-resources)を使用します</span><span class="sxs-lookup"><span data-stu-id="5076d-133">For the secondary pane closest to primary content, use [80% background acrylic](#acrylic-theme-resources)</span></span>
 - <span data-ttu-id="5076d-134">主要なコンテンツから離れて表示される第 3 ウィンドウでは、[60% の背景アクリル](#acrylic-theme-resources)を使用します</span><span class="sxs-lookup"><span data-stu-id="5076d-134">For the tertiary pane further away from primary content, use [60% background acrylic](#acrylic-theme-resources)</span></span>

![2 つの垂直方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_double-vertical.png)

### <a name="horizontal-acrylic-pane"></a><span data-ttu-id="5076d-136">水平方向のアクリル ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="5076d-136">Horizontal acrylic pane</span></span>

<span data-ttu-id="5076d-137">水平方向のナビゲーションやコマンド実行を行ったり、アプリの上部で水平方向に他の重要な要素が表示されるアプリでは、この視覚要素に [70% のアクリル](#acrylic-theme-resources)を適用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-137">For apps with horizontal navigation, commanding, or other strong horizontal elements across the top of the app, we recommend applying [70% acrylic](#acrylic-theme-resources) to this visual element.</span></span>

![水平方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_horizontal.png)

<span data-ttu-id="5076d-139">連続性があるズーム可能なコンテンツに重点を置くキャンバス アプリでは、上部のバーでアプリ内アクリルを使用し、ユーザーがこのコンテンツにアクセスできるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="5076d-139">Canvas apps with emphasis on continuous, zoomable content should use in-app acrylic in the top bar to let users connect with this content.</span></span> <span data-ttu-id="5076d-140">キャンバス アプリには、マップや各種の描画を含んでいるものがあります。</span><span class="sxs-lookup"><span data-stu-id="5076d-140">Examples of canvas apps include maps, painting and drawing.</span></span>

<span data-ttu-id="5076d-141">単一の連続したキャンバスのないアプリでは、背景アクリルを使用して、ユーザーがデスクトップ環境全体にアクセスできるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-141">For apps without a single continuous canvas, we recommend using background acrylic to connect users to their overall desktop environment.</span></span>

### <a name="acrylic-in-utility-apps"></a><span data-ttu-id="5076d-142">ユーティリティ アプリでのアクリル</span><span class="sxs-lookup"><span data-stu-id="5076d-142">Acrylic in utility apps</span></span>

<span data-ttu-id="5076d-143">ウィジェットや軽量アプリでは、アプリ ウィンドウの内部いっぱいにアクリルを描画して、ユーティリティ アプリとしての用途を強化することができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-143">Widgets or light-weight apps can reinforce their usage as utility apps by drawing acrylic edge-to-edge inside their app window.</span></span> <span data-ttu-id="5076d-144">このカテゴリのアプリは、ユーザーによる使用時間が短く、ユーザーのデスクトップ画面全体を占有することもないのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="5076d-144">Apps belonging to this category typically have brief user engagement times and are unlikely to occupy the user's entire desktop screen.</span></span> <span data-ttu-id="5076d-145">たとえば、電卓やアクション センターが該当します。</span><span class="sxs-lookup"><span data-stu-id="5076d-145">Examples include calculator and action center.</span></span>

![アクリルを背景全体として使用した電卓ユーティリティ アプリ](images/acrylic_app-pattern_full.png)

> [!Note]
> <span data-ttu-id="5076d-147">アクリル サーフェスのレンダリングでは GPU を集中的に使用するため、デバイスの電力消費が増加し、バッテリー残量が少なくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5076d-147">Rendering acrylic surfaces is GPU intensive, which can increase device power consumption and shorten battery life.</span></span> <span data-ttu-id="5076d-148">デバイスがバッテリー節約モードになると、アクリルの効果は自動的に無効になります。また、ユーザーは、必要に応じてすべてのアプリでアクリルの効果を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-148">Acrylic effects are automatically disabled when devices enter battery saver mode, and users can disable acrylic effects for all apps, if they choose.</span></span>


## <a name="acrylic-blend-types"></a><span data-ttu-id="5076d-149">アクリル ブレンドの種類</span><span class="sxs-lookup"><span data-stu-id="5076d-149">Acrylic blend types</span></span>
<span data-ttu-id="5076d-150">アクリルの最も注目すべき特徴は、その透明度です。</span><span class="sxs-lookup"><span data-stu-id="5076d-150">Acrylic's most noticeable characteristic is its transparency.</span></span> <span data-ttu-id="5076d-151">アクリル ブレンドの種類は 2 つあり、素材を通して何が表示されるかを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-151">There are two acrylic blend types that change what’s visible through the material:</span></span>
 - <span data-ttu-id="5076d-152">**背景アクリル**では、デスクトップの壁紙と現在アクティブになっているアプリの背後にある他のウィンドウが表示されます。これにより、アプリケーション ウィンドウの間に奥行きが出て、ユーザーが個人的に優先する画面を明示しておくことができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-152">**Background acrylic** reveals the desktop wallpaper and other windows that are behind the currently active app, adding depth between application windows while celebrating the user’s personalization preferences.</span></span>
 - <span data-ttu-id="5076d-153">**アプリ内アクリル**では、アプリ フレーム内に奥行きの感覚がもたらされ、フォーカスと階層の両方が提供されます。</span><span class="sxs-lookup"><span data-stu-id="5076d-153">**In-app acrylic** adds a sense of depth within the app frame, providing both focus and hierarchy.</span></span>

 ![背景アクリル](images/BackgroundAcrylic_DarkTheme.png)

 ![アプリ内アクリル](images/AppAcrylic_DarkTheme.png)

 <span data-ttu-id="5076d-156">複数のアクリル サーフェスを重ねる場合には注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="5076d-156">Layer multiple acrylic surfaces with caution.</span></span> <span data-ttu-id="5076d-157">背景アクリルは、その名前が示すように、Z オーダーではユーザーの最も近くには表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="5076d-157">Background acrylic, as its name implies, should not be closest to the user in z-order.</span></span> <span data-ttu-id="5076d-158">背景アクリルの複数のレイヤーは、予期しない目の錯覚を引き起こす傾向があるので、使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="5076d-158">Multiple layers of background acrylic tend to result in unexpected optical illusions and should also be avoided.</span></span> <span data-ttu-id="5076d-159">アクリルを重ねる場合は、アプリ内アクリルを重ねてください。また、アクリルの濃淡が薄くなるように値を設定して、アクリルのレイヤーが視覚的に閲覧者の近くに表示されるようにすることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-159">If you choose to layer acrylics, do so with in-app acrylic and consider making acrylic’s tint lighter in value to help visually bring the layers forward to the viewer.</span></span>


## <a name="usability-and-adaptability"></a><span data-ttu-id="5076d-160">使いやすさと適応性</span><span class="sxs-lookup"><span data-stu-id="5076d-160">Usability and adaptability</span></span>
<span data-ttu-id="5076d-161">アクリルの外観は、さまざまなデバイスやコンテキストに合うように自動的に対応します。</span><span class="sxs-lookup"><span data-stu-id="5076d-161">Acrylic automatically adapts its appearance for a wide variety of devices and contexts.</span></span>

<span data-ttu-id="5076d-162">ハイ コントラスト モードでは、ユーザーが選んだ見慣れた背景色が、アクリルの代わりに引き続き表示されます。</span><span class="sxs-lookup"><span data-stu-id="5076d-162">In High Contrast mode, users continue to see the familiar background color of their choosing in place of acrylic.</span></span> <span data-ttu-id="5076d-163">また次の場合には、背景アクリルとアプリ内アクリルはどちらも、単色として表示されます。</span><span class="sxs-lookup"><span data-stu-id="5076d-163">In addition, both background acrylic and in-app acrylic appear as a solid color</span></span>
 - <span data-ttu-id="5076d-164">ユーザーが個人用設定で透明度をオフにした場合</span><span class="sxs-lookup"><span data-stu-id="5076d-164">When the user turns off transparency in Personalization settings</span></span>
 - <span data-ttu-id="5076d-165">バッテリー節約機能モードがアクティブ化されている場合</span><span class="sxs-lookup"><span data-stu-id="5076d-165">When battery saver mode is activated</span></span>
 - <span data-ttu-id="5076d-166">アプリがローエンド ハードウェアで実行されている場合</span><span class="sxs-lookup"><span data-stu-id="5076d-166">When the app runs on low-end hardware</span></span>

<span data-ttu-id="5076d-167">また次の場合には、背景アクリルのみ、その透明度とテクスチャを単色で置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-167">In addition, only background acrylic will replace its transparency and texture with a solid color</span></span>
 - <span data-ttu-id="5076d-168">アプリ ウィンドウがデスクトップで非アクティブ化されている場合</span><span class="sxs-lookup"><span data-stu-id="5076d-168">When an app window on desktop deactivates</span></span>
 - <span data-ttu-id="5076d-169">UWP アプリが、電話、Xbox、HoloLens、またはタブレット モードで実行されている場合</span><span class="sxs-lookup"><span data-stu-id="5076d-169">When the UWP app is running on phone, Xbox, HoloLens or tablet mode</span></span>

### <a name="legibility-considerations"></a><span data-ttu-id="5076d-170">見やすくするための考慮事項</span><span class="sxs-lookup"><span data-stu-id="5076d-170">Legibility considerations</span></span>
<span data-ttu-id="5076d-171">アプリがユーザーに表示するすべてのテキストでは、[コントラスト比を適切な値にする](../accessibility/accessible-text-requirements.md)ことが重要です。</span><span class="sxs-lookup"><span data-stu-id="5076d-171">It’s important to ensure that any text your app presents to users [meets contrast ratios](../accessibility/accessible-text-requirements.md).</span></span> <span data-ttu-id="5076d-172">ハイカラーの黒や白のテキスト、またはミディアムカラーの灰色のテキストがアクリル上で適切なコントラスト比になるように、アクリルのレシピは最適化されています。</span><span class="sxs-lookup"><span data-stu-id="5076d-172">We’ve optimized the acrylic recipe so that high-color black, white or even medium-color gray text meets contrast ratios on top of acrylic.</span></span> <span data-ttu-id="5076d-173">プラットフォームによって提供されるテーマ リソースは、既定で、濃淡の色のコントラストが 80% の不透明度に設定されます。</span><span class="sxs-lookup"><span data-stu-id="5076d-173">The theme resources provided by the platform default to contrasting tint colors at 80% opacity.</span></span> <span data-ttu-id="5076d-174">ハイカラーの本文テキストをアクリル上に配置する場合、濃淡の不透明度を下げて、見やすさを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-174">When placing high-color body text on acrylic, you can reduce tint opacity while maintaining legibility.</span></span> <span data-ttu-id="5076d-175">ダーク モードでは濃淡の不透明度を 70% にすることができ、ライト モードのアクリルではコントラスト比を 50% の不透明度に合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-175">In dark mode, tint opacity can be 70%, while light mode acrylic will meet contrast ratios at 50% opacity.</span></span>

<span data-ttu-id="5076d-176">アクリル サーフェスの上にアクセント カラーのテキストを配置することはお勧めしません。これは、これらの組み合わせが、15 ピクセルのフォント サイズでのコントラスト比の最小要件を満たさない可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="5076d-176">We don't recommend placing accent-colored text on your acrylic surfaces because these combinations are likely to not pass minimum contrast ratio requirements at 15px font size.</span></span> <span data-ttu-id="5076d-177">[ハイパーリンク](../controls-and-patterns/hyperlinks.md)はアクリル要素上には配置しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="5076d-177">Try to avoid placing [hyperlinks](../controls-and-patterns/hyperlinks.md) over acrylic elements.</span></span> <span data-ttu-id="5076d-178">また、アクリルの濃淡の色や透明度のレベルを、テーマ リソースによって提供されるプラットフォームの既定値以外にカスタマイズする場合は、見やすさへの影響を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-178">Also, if you choose to customize the acrylic tint color or opacity level outside of the platform defaults provided by the theme resource, keep the impact on legibility in mind.</span></span>

## <a name="acrylic-theme-resources"></a><span data-ttu-id="5076d-179">アクリルのテーマ リソース</span><span class="sxs-lookup"><span data-stu-id="5076d-179">Acrylic theme resources</span></span>
<span data-ttu-id="5076d-180">新しい XAML AcrylicBrush テーマ リソースや定義済みの AcrylicBrush テーマ リソースを使用して、アクリルをアプリのサーフェスに簡単に適用できます。</span><span class="sxs-lookup"><span data-stu-id="5076d-180">You can easily apply acrylic to your app’s surfaces using the new XAML AcrylicBrush or predefined AcrylicBrush theme resources.</span></span> <span data-ttu-id="5076d-181">まず、アプリ内アクリルまたは背景アクリルのどちらを使用するかを決める必要があります。</span><span class="sxs-lookup"><span data-stu-id="5076d-181">First, you’ll need to decide whether to use in-app or background acrylic.</span></span> <span data-ttu-id="5076d-182">この記事で推奨事項として既に説明した一般的なアプリのパターンを確認してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-182">Be sure to review common app patterns described earlier in this article for recommendations.</span></span>

<span data-ttu-id="5076d-183">背景アクリルやアプリ内アクリルの両方を対象としたブラシのテーマ リソースのコレクションが作成されています。これらのリソースでは、アプリのテーマが重視され、必要に応じて、単色にフォール バックします。</span><span class="sxs-lookup"><span data-stu-id="5076d-183">We’ve created a collection of brush theme resources for both background and in-app acrylic types that respect the app’s theme and fall back to solid colors as needed.</span></span> <span data-ttu-id="5076d-184">*Acrylic\*WindowBrush* という名前のリソースは背景アクリルを表し、*Acrylic\*ElementBrush* はアプリ内アクリルを表します。</span><span class="sxs-lookup"><span data-stu-id="5076d-184">Resources named *Acrylic\*WindowBrush* represent background acrylic, while *Acrylic\*ElementBrush* refers to in-app acrylic.</span></span>

<table>
    <tr>
        <th align="center"><span data-ttu-id="5076d-185">リソース キー</span><span class="sxs-lookup"><span data-stu-id="5076d-185">Resource key</span></span></th>
        <th align="center"><span data-ttu-id="5076d-186">濃淡の不透明度</span><span class="sxs-lookup"><span data-stu-id="5076d-186">Tint opacity</span></span></th>
        <th align="center">[<span data-ttu-id="5076d-187">フォールバックの色</span><span class="sxs-lookup"><span data-stu-id="5076d-187">Fallback color</span></span>](color.md)</th>
    </tr>
    <tr>
        <td> <span data-ttu-id="5076d-188">SystemControlAcrylicWindowBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-188">SystemControlAcrylicWindowBrush</span></span><br/><span data-ttu-id="5076d-189">SystemControlAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-189">SystemControlAcrylicElementBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="5076d-190">80%</span><span class="sxs-lookup"><span data-stu-id="5076d-190">80%</span></span> </td>
        <td> <span data-ttu-id="5076d-191">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="5076d-191">ChromeMedium</span></span> </td>
    </tr>
    </tr>
        <td> <span data-ttu-id="5076d-192">**推奨する使用方法:** これらは、汎用的なアクリルのリソースであり、さまざまな使用方法で適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="5076d-192">**Recommended usage:** These are general-purpose acrylic resources that work well in a wide variety of usages.</span></span> <span data-ttu-id="5076d-193">アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセルよりも小さい場合は、[コントラスト比の要件を満たすように](../accessibility/accessible-text-requirements.md)、80% のアクリル リソースをテキストの背景に配置してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-193">If your app uses secondary text of AltMedium color with text size smaller than 18px, place an 80% acrylic resource behind the text to [meet contrast ratio requirements](../accessibility/accessible-text-requirements.md).</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="5076d-194">SystemControlAcrylicMediumHighWindowBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-194">SystemControlAcrylicMediumHighWindowBrush</span></span><br/><span data-ttu-id="5076d-195">SystemControlAcrylicMediumHighElementBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-195">SystemControlAcrylicMediumHighElementBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="5076d-196">70%</span><span class="sxs-lookup"><span data-stu-id="5076d-196">70%</span></span> </td>
        <td> <span data-ttu-id="5076d-197">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="5076d-197">ChromeMedium</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="5076d-198">**推奨する使用方法:** アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセル以上になる場合は、これらのより透過的な 70% のアクリル リソースをテキストの背景に配置できます。</span><span class="sxs-lookup"><span data-stu-id="5076d-198">**Recommended usage:** If your app uses secondary text of AltMedium color with a text size of 18px or larger, you can place these more transparent 70% acrylic resources behind the text.</span></span> <span data-ttu-id="5076d-199">これらのリソースは、アプリの最上部にある水平方向のナビゲーション領域やコマンド実行領域で使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-199">We recommend using these resources in your app's top horizontal navigation and commanding areas.</span></span>  </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="5076d-200">SystemControlAcrylicMediumWindowBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-200">SystemControlAcrylicMediumWindowBrush</span></span><br/><span data-ttu-id="5076d-201">SystemControlAcrylicMediumElementBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-201">SystemControlAcrylicMediumElementBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="5076d-202">60%</span><span class="sxs-lookup"><span data-stu-id="5076d-202">60%</span></span> </td>
        <td> <span data-ttu-id="5076d-203">ChromeMediumLow</span><span class="sxs-lookup"><span data-stu-id="5076d-203">ChromeMediumLow</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="5076d-204">**推奨する使用方法:** プライマリ テキストの色が AltHigh で、このテキストのみをアクリルの上に配置する場合は、これらの 60% のリソースを利用できます。</span><span class="sxs-lookup"><span data-stu-id="5076d-204">**Recommended usage:** When placing only primary text of AltHigh color over acrylic, your app can utilize these 60% resources.</span></span> <span data-ttu-id="5076d-205">アプリの[垂直方向のナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md) (ハンバーガー メニュー) を描画するときは、60% のアクリルを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-205">We recommend painting your app's [vertical navigation pane](../controls-and-patterns/navigationview.md), i.e. hamburger menu, with 60% acrylic.</span></span> </td>
    </tr>
</table>

<span data-ttu-id="5076d-206">中間色のアクリルに加え、ユーザーが指定したアクセント カラーを使用してアクリルに濃淡を付けるリソースも追加しました。</span><span class="sxs-lookup"><span data-stu-id="5076d-206">In addition to color-neutral acrylic, we've also added resources that tint acrylic using the user-specified accent color.</span></span> <span data-ttu-id="5076d-207">色が付いたアクリルは慎重に使用してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-207">We recommend using colored acrylic sparingly.</span></span> <span data-ttu-id="5076d-208">提供されている dark1 と dark2 のバリアントを使用する場合、濃色テーマのテキストの色と調和するように、白または明るい色のテキストをこれらのリソース上に配置してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-208">For the dark1 and dark2 variants provided, place white or light-colored text consistent with dark theme text color over these resources.</span></span>
<table>
    <tr>
        <th align="center"><span data-ttu-id="5076d-209">リソース キー</span><span class="sxs-lookup"><span data-stu-id="5076d-209">Resource key</span></span></th>
        <th align="center"><span data-ttu-id="5076d-210">濃淡の不透明度</span><span class="sxs-lookup"><span data-stu-id="5076d-210">Tint opacity</span></span></th>
        <th align="center">[<span data-ttu-id="5076d-211">濃淡とフォールバックの色</span><span class="sxs-lookup"><span data-stu-id="5076d-211">Tint and Fallback colors</span></span>](color.md)</th>
    </tr>
    <tr>
        <td> <span data-ttu-id="5076d-212">SystemControlAcrylicAccentMediumHighWindowBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-212">SystemControlAcrylicAccentMediumHighWindowBrush</span></span><br/><span data-ttu-id="5076d-213">SystemControlAcrylicAccentMediumHighElementBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-213">SystemControlAcrylicAccentMediumHighElementBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="5076d-214">70%</span><span class="sxs-lookup"><span data-stu-id="5076d-214">70%</span></span> </td>
        <td> <span data-ttu-id="5076d-215">SystemAccentColor</span><span class="sxs-lookup"><span data-stu-id="5076d-215">SystemAccentColor</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="5076d-216">SystemControlAcrylicAccentDark1WindowBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-216">SystemControlAcrylicAccentDark1WindowBrush</span></span><br/><span data-ttu-id="5076d-217">SystemControlAcrylicAccentDark1ElementBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-217">SystemControlAcrylicAccentDark1ElementBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="5076d-218">80%</span><span class="sxs-lookup"><span data-stu-id="5076d-218">80%</span></span> </td>
        <td> <span data-ttu-id="5076d-219">SystemAccentColorDark1</span><span class="sxs-lookup"><span data-stu-id="5076d-219">SystemAccentColorDark1</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="5076d-220">SystemControlAcrylicAccentDark2MediumHighWindowBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-220">SystemControlAcrylicAccentDark2MediumHighWindowBrush</span></span><br/><span data-ttu-id="5076d-221">SystemControlAcrylicAccentDark2MediumHighElementBrush</span><span class="sxs-lookup"><span data-stu-id="5076d-221">SystemControlAcrylicAccentDark2MediumHighElementBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="5076d-222">70%</span><span class="sxs-lookup"><span data-stu-id="5076d-222">70%</span></span> </td>
        <td> <span data-ttu-id="5076d-223">SystemAccentColorDark2</span><span class="sxs-lookup"><span data-stu-id="5076d-223">SystemAccentColorDark2</span></span> </td>
    </tr>
</table>


<span data-ttu-id="5076d-224">特定のサーフェスを塗りつぶすには、上記のテーマ リソースのいずれかを、他のブラシ リソースを適用する要素の背景に適用します。</span><span class="sxs-lookup"><span data-stu-id="5076d-224">To paint a specific surface, apply one of the above theme resources to element backgrounds just as you would apply any other brush resource.</span></span>

```xaml
<Grid Background="{ThemeResource SystemControlAcrylicElementBrush}">
```

## <a name="custom-acrylic-brush"></a><span data-ttu-id="5076d-225">カスタム アクリル ブラシ</span><span class="sxs-lookup"><span data-stu-id="5076d-225">Custom acrylic brush</span></span>
<span data-ttu-id="5076d-226">色の濃淡をアプリのアクリルに加えて、ブランドを表示したり、ページ上にある他の要素と視覚的にバランスをとったりすることができます。</span><span class="sxs-lookup"><span data-stu-id="5076d-226">You may choose to add a color tint to your app’s acrylic to show branding or provide visual balance with other elements on the page.</span></span> <span data-ttu-id="5076d-227">グレースケール以外の色を表示するには、次のプロパティを使って、独自のアクリル ブラシを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5076d-227">To show color rather than greyscale, you’ll need to define your own acrylic brushes using the following properties.</span></span>
 - <span data-ttu-id="5076d-228">**TintColor**: 色/濃淡のオーバーレイ レイヤーです。</span><span class="sxs-lookup"><span data-stu-id="5076d-228">**TintColor**: the color/tint overlay layer.</span></span> <span data-ttu-id="5076d-229">RGB の色の値とアルファ チャネルの不透明度の両方を指定することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-229">Consider specifying both the RGB color value and alpha channel opacity.</span></span>
 - <span data-ttu-id="5076d-230">**TintOpacity**: 濃淡レイヤーの不透明度です。</span><span class="sxs-lookup"><span data-stu-id="5076d-230">**TintOpacity**: the opacity of the tint layer.</span></span> <span data-ttu-id="5076d-231">開始点として 80% の不透明度をお勧めします。ただし、透明度が異なると、別の色を使用したほうがより魅力的に表示される可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="5076d-231">We recommend 80% opacity as a starting point, although different colors may look more compelling at other transparencies.</span></span>
 - <span data-ttu-id="5076d-232">**BackgroundSource**: 背景アクリルまたはアプリ内アクリルのどちらを使用するかを指定するフラグです。</span><span class="sxs-lookup"><span data-stu-id="5076d-232">**BackgroundSource**: the flag to specify whether you want background or in-app acrylic.</span></span>
 - <span data-ttu-id="5076d-233">**FallbackColor**: バッテリ低下モードでアクリルと置き換わる単色です。</span><span class="sxs-lookup"><span data-stu-id="5076d-233">**FallbackColor**: the solid color that replaces acrylic in low-battery mode.</span></span> <span data-ttu-id="5076d-234">背景アクリルでは、フォールバックの色は、アプリが作業中のデスクトップ ウィンドウにない場合、またはアプリが電話や Xbox 上で実行されている場合にもアクリルと置き換わります。</span><span class="sxs-lookup"><span data-stu-id="5076d-234">For background acrylic, fallback color also replaces acrylic when your app isn’t in the active desktop window or when the app is running on phone and Xbox.</span></span>


![淡色テーマのアクリルの見本](images/CustomAcrylic_Swatches_LightTheme.png)

![濃色テーマのアクリルの見本](images/CustomAcrylic_Swatches_DarkTheme.png)

<span data-ttu-id="5076d-237">アクリル ブラシを追加するには、濃色テーマ、淡色テーマ、ハイ コントラスト テーマの 3 つのリソースを定義します。</span><span class="sxs-lookup"><span data-stu-id="5076d-237">To add an acrylic brush, define the three resources for dark, light and high contrast themes.</span></span> <span data-ttu-id="5076d-238">ハイ コントラストでは、濃色/淡色の AcrylicBrush と同じ x:Key で SolidColorBrush を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-238">Note that in high contrast, we recommend using a SolidColorBrush with the same x:Key as the dark/light AcrylicBrush.</span></span>

```xaml
<ResourceDictionary.ThemeDictionaries>
    <ResourceDictionary x:Key="Default">
        <AcrylicBrush x:Key="MyAcrylicBrush"
            BackgroundSource="HostBackdrop"
            TintColor="#FFFF0000"
            TintOpacity="0.8"
            FallbackColor="#FF7F0000"/>
    </ResourceDictionary>

    <ResourceDictionary x:Key="HighContrast">
        <SolidColorBrush x:Key="MyAcrylicBrush"
            Color="{ThemeResource SystemColorWindowColor}"/>
    </ResourceDictionary>

    <ResourceDictionary x:Key="Light">
        <AcrylicBrush x:Key="MyAcrylicBrush"
            BackgroundSource="HostBackdrop"
            TintColor="#FFFF0000"
            TintOpacity="0.8"
            FallbackColor="#FFFF7F7F"/>
    </ResourceDictionary>
</ResourceDictionary.ThemeDictionaries>
```

<span data-ttu-id="5076d-239">次のサンプルは、コードで AcrylicBrush を宣言する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="5076d-239">The following sample shows how to declare AcrylicBrush in code.</span></span> <span data-ttu-id="5076d-240">アプリが複数の OS ターゲットをサポートする場合は、この API がユーザーのコンピューターで利用できることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-240">If your app supports multiple OS targets, be sure to check that this API is available on the user’s machine.</span></span>

```csharp
if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
{
    Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
    myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
    myBrush.TintColor = Color.FromArgb(255, 202, 24, 37);
    myBrush.FallbackColor = Color.FromArgb(255, 202, 24, 37);
    myBrush.TintOpacity = 0.6;

    grid.Fill = myBrush;
}
else
{
    SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

    grid.Fill = myBrush;
}
```

## <a name="extending-acrylic-into-your-title-bar"></a><span data-ttu-id="5076d-241">アクリルをタイトル バーに拡張する</span><span class="sxs-lookup"><span data-stu-id="5076d-241">Extending acrylic into your title bar</span></span>

<span data-ttu-id="5076d-242">アプリのウィンドウ内でシームレスで滑らかな表示を実現するには、アクリルをアプリのタイトル バー領域に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5076d-242">For a seamless, flowing look within your app's window, we recommend placing acrylic in your app's title bar area.</span></span> <span data-ttu-id="5076d-243">そのためには、次のコードを App.xaml.cs に追加します。</span><span class="sxs-lookup"><span data-stu-id="5076d-243">To do so, add the following code to your App.xaml.cs.</span></span>

```csharp
CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
titleBar.ButtonBackgroundColor = Colors.Transparent;
titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
```

<span data-ttu-id="5076d-244">また、通常はタイトル バーに自動的に表示されるアプリのタイトルを、`CaptionTextBlockStyle` を使用した TextBlock で描画する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="5076d-244">In addition, you'll need to draw your app's title, which normally appears automatically in the title bar, with a TextBlock using `CaptionTextBlockStyle`.</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="5076d-245">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="5076d-245">Do's and don'ts</span></span>
* <span data-ttu-id="5076d-246">アクリルは、ナビゲーション ウィンドウなど、アプリのプライマリ サーフェス以外のサーフェスで背景素材として使用してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-246">Do use acrylic as the background material of non-primary app surfaces like navigation panes.</span></span>
* <span data-ttu-id="5076d-247">シームレスなエクスペリエンスを実現するには、アプリの周囲とわずかにブレンドするようにして、アクリルをアプリの 1 つ以上の端にまで拡張してください。</span><span class="sxs-lookup"><span data-stu-id="5076d-247">Do extend acrylic to at least one edge of your app to provide a seamless experience by subtly blending with the app’s surroundings.</span></span>
* <span data-ttu-id="5076d-248">アプリ内アクリルと背景アクリルは、継ぎ目部分での視覚的なテンションを回避するために、隣接するようには配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="5076d-248">Don’t place in-app and background acrylics directly adjacent to avoid visual tension at the seams.</span></span>
* <span data-ttu-id="5076d-249">複数のアクリル ウィンドウを、同じ濃淡や不透明度で隣接するように配置しないでください。このようにすると、望ましくない継ぎ目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="5076d-249">Don't place multiple acrylic panes with the same tint and opacity next to each other because this results in an undesirable visible seam.</span></span>
* <span data-ttu-id="5076d-250">アクリル サーフェスの上には、アクセント カラーのテキストを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="5076d-250">Don’t place accent-colored text over acrylic surfaces.</span></span>

## <a name="how-we-designed-acrylic"></a><span data-ttu-id="5076d-251">アクリルをどのように設計したか</span><span class="sxs-lookup"><span data-stu-id="5076d-251">How we designed acrylic</span></span>

<span data-ttu-id="5076d-252">アクリルの主要なコンポーネントを微調整して、ユニークな外観とプロパティを作成しました。</span><span class="sxs-lookup"><span data-stu-id="5076d-252">We fine-tuned acrylic’s key components to arrive at its unique appearance and properties.</span></span> <span data-ttu-id="5076d-253">設計の開始時には透明度、ぼかし、ノイズを使い、平坦なサーフェスに視覚的な奥行きとディメンションを追加しました。</span><span class="sxs-lookup"><span data-stu-id="5076d-253">We started with transparency, blur and noise to add visual depth and dimension to flat surfaces.</span></span> <span data-ttu-id="5076d-254">除外ブレンド モード レイヤーを追加して、アクリルの背景に配置される UI のコントラストと見やすさを確保しました。</span><span class="sxs-lookup"><span data-stu-id="5076d-254">We added an exclusion blend mode layer to ensure contrast and legibility of UI placed on an acrylic background.</span></span> <span data-ttu-id="5076d-255">最後に、ユーザーの個性を反映できるように、色の濃淡を追加しました。</span><span class="sxs-lookup"><span data-stu-id="5076d-255">Finally, we added color tint for personalization opportunities.</span></span> <span data-ttu-id="5076d-256">次のレイヤーを組み合わせることで、新しくて使いやすい素材が生みだされます。</span><span class="sxs-lookup"><span data-stu-id="5076d-256">In concert these layers add up to a fresh, usable material.</span></span>

![アクリルのレシピ](images/AcrylicRecipe_Diagram.png)
<br/><span data-ttu-id="5076d-258">アクリルのレシピ: 背景、ぼかし、除外ブレンド、色/濃淡のオーバーレイ、ノイズ</span><span class="sxs-lookup"><span data-stu-id="5076d-258">The acrylic recipe: background, blur, exclusion blend, color/tint overlay, noise</span></span>

<!--
<div class="microsoft-internal-note">
When designing your app, please utilize these [design resources](http://uni/DesignDepot.FrontEnd/#/Search?t=Resources%7CNeon%7CToolkit&f=Acrylic%20Material) to show acrylic in comps. The linked templates are the most accurate way to represent acrylic material in Photoshop and Illustrator. The ordering, as noted in the recipe diagram above, should start from the top: <br/>
 - Noise asset (tiled) at 4% opacity <br/>
 - Base color/tint/alpha layer <br/>
 - Exclusion blend (white @ 10% opacity) <br/>
 - Gaussian blur (30px radius) <br/>
</div>
-->


## <a name="related-articles"></a><span data-ttu-id="5076d-259">関連記事</span><span class="sxs-lookup"><span data-stu-id="5076d-259">Related articles</span></span>
[**<span data-ttu-id="5076d-260">表示</span><span class="sxs-lookup"><span data-stu-id="5076d-260">Reveal</span></span>**](reveal.md)
