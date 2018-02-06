---
author: mijacobs
description: "半透明のテクスチャを作成するブラシの一種。"
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
ms.localizationpriority: high
ms.openlocfilehash: 8f8266878356ae182b6abf59a6729bf7066d6e4c
ms.sourcegitcommit: 4b522af988273946414a04fbbd1d7fde40f8ba5e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/08/2018
---
# <a name="acrylic-material"></a><span data-ttu-id="8a092-104">アクリル素材</span><span class="sxs-lookup"><span data-stu-id="8a092-104">Acrylic material</span></span>

<span data-ttu-id="8a092-105">アクリルは [Brush](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush) の一種であり、半透明のテクスチャを作成します。</span><span class="sxs-lookup"><span data-stu-id="8a092-105">Acrylic is a type of [Brush](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush) that creates a partially transparent texture.</span></span> <span data-ttu-id="8a092-106">アクリルをアプリ サーフェスに適用すると、奥行きを加えたり、視覚的な階層を確立したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-106">You can apply acrylic to app surfaces to add depth and help establish a visual hierarchy.</span></span>  <!-- By allowing user-selected wallpaper or colors to shine through, Acrylic keeps users in touch with the OS personalization they've chosen. -->

> <span data-ttu-id="8a092-107">**重要な API**: [AcrylicBrush クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush)、[Background プロパティ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Background)</span><span class="sxs-lookup"><span data-stu-id="8a092-107">**Important APIs**: [AcrylicBrush class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush), [Background property](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Background)</span></span>


![淡色テーマのアクリル](images/Acrylic_DarkTheme_Base.png)

![濃色テーマのアクリル](images/Acrylic_LightTheme_Base.png)

## <a name="examples"></a><span data-ttu-id="8a092-110">例</span><span class="sxs-lookup"><span data-stu-id="8a092-110">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="8a092-111">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="8a092-111">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="8a092-112"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Acrylic">アプリを開き、アクリルの動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-112">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Acrylic">open the app and see Acrylic in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="8a092-113">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="8a092-113">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="8a092-114">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="8a092-114">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="video-summary"></a><span data-ttu-id="8a092-115">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="8a092-115">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev002/player]

## <a name="acrylic-and-the-fluent-design-system"></a><span data-ttu-id="8a092-116">アクリルと Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="8a092-116">Acrylic and the Fluent Design System</span></span>

 <span data-ttu-id="8a092-117">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="8a092-117">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="8a092-118">アクリルは、アプリに物理的なテクスチャ (マテリアル) と深度を追加する Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="8a092-118">Acrylic is a Fluent Design System component that adds physical texture (material) and depth to your app.</span></span> <span data-ttu-id="8a092-119">詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8a092-119">To learn more, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

## <a name="when-to-use-acrylic"></a><span data-ttu-id="8a092-120">アクリルを使用する状況</span><span class="sxs-lookup"><span data-stu-id="8a092-120">When to use acrylic</span></span>

<span data-ttu-id="8a092-121">アプリ内ナビゲーションの要素やコマンド実行要素などのサポート UI は、アクリル サーフェス上に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-121">We recommend that you place supporting UI, such as in-app navigation or commanding elements, on an acrylic surface.</span></span> <span data-ttu-id="8a092-122">アクリル素材は、ダイアログやポップアップなどの一時的な UI の要素を使用する場合にも役立ちます。これは、この素材によって、一時的な UI をトリガーしたコンテンツとの視覚的な関係を維持することができるためです。</span><span class="sxs-lookup"><span data-stu-id="8a092-122">This material is also helpful for transient UI elements, such as dialogs and flyouts, because it helps maintain a visual relationship with the content that triggered the transient UI.</span></span> <span data-ttu-id="8a092-123">アクリルは、背景素材として使用し、視覚的に分離されたウィンドウ内に表示するように設計されています。そのため、アクリルは詳細な前景要素には適用しないでください。</span><span class="sxs-lookup"><span data-stu-id="8a092-123">We designed acrylic to be used as a background material and show in visually discrete panes, so don't apply acrylic to detailed foreground elements.</span></span>

<span data-ttu-id="8a092-124">アプリの主要なコンテンツの背後にあるサーフェスでは、単色で不透明な背景を使用してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-124">Surfaces behind primary app content should use solid, opaque backgrounds.</span></span>

<span data-ttu-id="8a092-125">滑らかな表示を実現するには、アクリルを、アプリの 1 つまたは複数の端にまで (ウィンドウのタイトル バーも含む) 拡張することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-125">Consider having acrylic extend to one or more edges of your app, including the window title bar, to improve visual flow.</span></span> <span data-ttu-id="8a092-126">ブレンドの種類が異なる複数のアクリルを相互に隣接するように重ねて、ストライプ効果を作成することは回避してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-126">Avoid creating a striping effect by stacking acrylics of different blend types adjacent to each other.</span></span> <span data-ttu-id="8a092-127">アクリルは、デザインで視覚的な調和をとるためのツールですが、正しく使用しないと、視覚的なノイズになる場合があります。</span><span class="sxs-lookup"><span data-stu-id="8a092-127">Acrylic is a tool to bring visual harmony to your designs but, when used incorrectly, can result in visual noise.</span></span>

<span data-ttu-id="8a092-128">次の使用パターンを検討して、アクリルをアプリに組み込むに最適な方法を決定してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-128">Consider the following usage patterns to decide how best to incorporate acrylic into your app.</span></span>

### <a name="vertical-acrylic-pane"></a><span data-ttu-id="8a092-129">垂直方向のアクリル ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="8a092-129">Vertical acrylic pane</span></span>

<span data-ttu-id="8a092-130">垂直方向のナビゲーションを行うアプリでは、アクリルを、ナビゲーション要素を含んでいるセカンダリ ウィンドウに適用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-130">For apps with vertical navigation, we recommend applying acrylic to the secondary pane containing navigation elements.</span></span>

![1 つの垂直方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_vertical.png)

<span data-ttu-id="8a092-132">[NavigationView](../controls-and-patterns/navigationview.md) は、ナビゲーションをアプリに追加し、そのビジュアル デザインにアクリルを取り込むための新しいコモン コントロール です。</span><span class="sxs-lookup"><span data-stu-id="8a092-132">[NavigationView](../controls-and-patterns/navigationview.md) is a new common control for adding navigation to your app and includes acrylic in its visual design.</span></span> <span data-ttu-id="8a092-133">NavigationView のウィンドウでは、ウィンドウが主要なコンテンツと並んで開かれるとき、背景アクリルが表示されます。また、ウィンドウがオーバーレイとして開くと、自動的にアプリ内アクリルに切り替わります。</span><span class="sxs-lookup"><span data-stu-id="8a092-133">NavigationView’s pane shows background acrylic when the pane is open side-by-side with primary content, and automatically transitions to in-app acrylic when the pane is open as an overlay.</span></span>

<span data-ttu-id="8a092-134">アプリでは NavigationView を利用できず、独自にアクリルを追加することを検討している場合は、比較的透明なアクリル (濃淡の透明度が 60%) を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-134">If your app is not able to leverage NavigationView and you plan on adding acrylic on your own, we recommend using relatively transparent acrylic with 60% tint opacity.</span></span>
 - <span data-ttu-id="8a092-135">ウィンドウが他のアプリ コンテンツ上でオーバーレイとして開くときは、[60% のアプリ内アクリル](#acrylic-theme-resources)にする必要があります</span><span class="sxs-lookup"><span data-stu-id="8a092-135">When the pane opens as an overlay above other app content, this should be [60% in-app acrylic](#acrylic-theme-resources)</span></span>
 - <span data-ttu-id="8a092-136">ウィンドウがメイン アプリ コンテンツと並んで開かれるときは、[60% の背景アクリル](#acrylic-theme-resources)にする必要があります</span><span class="sxs-lookup"><span data-stu-id="8a092-136">When the pane opens side-by-side with main app content, this should be [60% background acrylic](#acrylic-theme-resources)</span></span>

### <a name="multiple-acrylic-panes"></a><span data-ttu-id="8a092-137">複数のアクリル ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="8a092-137">Multiple acrylic panes</span></span>

<span data-ttu-id="8a092-138">3 つの異なる垂直方向のウィンドウを持つアプリでは、アクリルを主要なコンテンツ以外のコンテンツに追加することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-138">For apps with three distinct vertical panes, we recommend adding acrylic to non-primary content.</span></span>
 - <span data-ttu-id="8a092-139">主要なコンテンツの最も近くに表示される第 2 ウィンドウでは、[80% の背景アクリル](#acrylic-theme-resources)を使用します</span><span class="sxs-lookup"><span data-stu-id="8a092-139">For the secondary pane closest to primary content, use [80% background acrylic](#acrylic-theme-resources)</span></span>
 - <span data-ttu-id="8a092-140">主要なコンテンツから離れて表示される第 3 ウィンドウでは、[60% の背景アクリル](#acrylic-theme-resources)を使用します</span><span class="sxs-lookup"><span data-stu-id="8a092-140">For the tertiary pane further away from primary content, use [60% background acrylic](#acrylic-theme-resources)</span></span>

![2 つの垂直方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_double-vertical.png)

### <a name="horizontal-acrylic-pane"></a><span data-ttu-id="8a092-142">水平方向のアクリル ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="8a092-142">Horizontal acrylic pane</span></span>

<span data-ttu-id="8a092-143">水平方向のナビゲーションやコマンド実行を行ったり、アプリの上部で水平方向に他の重要な要素が表示されるアプリでは、この視覚要素に [70% のアクリル](#acrylic-theme-resources)を適用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-143">For apps with horizontal navigation, commanding, or other strong horizontal elements across the top of the app, we recommend applying [70% acrylic](#acrylic-theme-resources) to this visual element.</span></span>

![水平方向のアクリル ウィンドウを使用するアプリのパターン](images/acrylic_app-pattern_horizontal.png)

<span data-ttu-id="8a092-145">連続性があるズーム可能なコンテンツに重点を置くキャンバス アプリでは、上部のバーでアプリ内アクリルを使用し、ユーザーがこのコンテンツにアクセスできるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="8a092-145">Canvas apps with emphasis on continuous, zoomable content should use in-app acrylic in the top bar to let users connect with this content.</span></span> <span data-ttu-id="8a092-146">キャンバス アプリには、マップや各種の描画を含んでいるものがあります。</span><span class="sxs-lookup"><span data-stu-id="8a092-146">Examples of canvas apps include maps, painting and drawing.</span></span>

<span data-ttu-id="8a092-147">単一の連続したキャンバスのないアプリでは、背景アクリルを使用して、ユーザーがデスクトップ環境全体にアクセスできるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-147">For apps without a single continuous canvas, we recommend using background acrylic to connect users to their overall desktop environment.</span></span>

### <a name="acrylic-in-utility-apps"></a><span data-ttu-id="8a092-148">ユーティリティ アプリでのアクリル</span><span class="sxs-lookup"><span data-stu-id="8a092-148">Acrylic in utility apps</span></span>

<span data-ttu-id="8a092-149">ウィジェットや軽量アプリでは、アプリ ウィンドウの内部いっぱいにアクリルを描画して、ユーティリティ アプリとしての用途を強化することができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-149">Widgets or light-weight apps can reinforce their usage as utility apps by drawing acrylic edge-to-edge inside their app window.</span></span> <span data-ttu-id="8a092-150">このカテゴリのアプリは、ユーザーによる使用時間が短く、ユーザーのデスクトップ画面全体を占有することもないのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="8a092-150">Apps belonging to this category typically have brief user engagement times and are unlikely to occupy the user's entire desktop screen.</span></span> <span data-ttu-id="8a092-151">たとえば、電卓やアクション センターが該当します。</span><span class="sxs-lookup"><span data-stu-id="8a092-151">Examples include calculator and action center.</span></span>

![アクリルを背景全体として使用した電卓ユーティリティ アプリ](images/acrylic_app-pattern_full.png)

> [!Note]
> <span data-ttu-id="8a092-153">アクリル サーフェスのレンダリングでは GPU を集中的に使用するため、デバイスの電力消費が増加し、バッテリー残量が少なくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8a092-153">Rendering acrylic surfaces is GPU intensive, which can increase device power consumption and shorten battery life.</span></span> <span data-ttu-id="8a092-154">デバイスがバッテリー節約モードになると、アクリルの効果は自動的に無効になります。また、ユーザーは、必要に応じてすべてのアプリでアクリルの効果を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-154">Acrylic effects are automatically disabled when devices enter battery saver mode, and users can disable acrylic effects for all apps, if they choose.</span></span>


## <a name="acrylic-blend-types"></a><span data-ttu-id="8a092-155">アクリル ブレンドの種類</span><span class="sxs-lookup"><span data-stu-id="8a092-155">Acrylic blend types</span></span>
<span data-ttu-id="8a092-156">アクリルの最も注目すべき特徴は、その透明度です。</span><span class="sxs-lookup"><span data-stu-id="8a092-156">Acrylic's most noticeable characteristic is its transparency.</span></span> <span data-ttu-id="8a092-157">アクリル ブレンドの種類は 2 つあり、素材を通して何が表示されるかを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-157">There are two acrylic blend types that change what’s visible through the material:</span></span>
 - <span data-ttu-id="8a092-158">**背景アクリル**では、デスクトップの壁紙と現在アクティブになっているアプリの背後にある他のウィンドウが表示されます。これにより、アプリケーション ウィンドウの間に奥行きが出て、ユーザーが個人的に優先する画面を明示しておくことができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-158">**Background acrylic** reveals the desktop wallpaper and other windows that are behind the currently active app, adding depth between application windows while celebrating the user’s personalization preferences.</span></span>
 - <span data-ttu-id="8a092-159">**アプリ内アクリル**では、アプリ フレーム内に奥行きの感覚がもたらされ、フォーカスと階層の両方が提供されます。</span><span class="sxs-lookup"><span data-stu-id="8a092-159">**In-app acrylic** adds a sense of depth within the app frame, providing both focus and hierarchy.</span></span>

 ![背景アクリル](images/BackgroundAcrylic_DarkTheme.png)

 ![アプリ内アクリル](images/AppAcrylic_DarkTheme.png)

 <span data-ttu-id="8a092-162">複数のアクリル サーフェスを重ねる場合には注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="8a092-162">Layer multiple acrylic surfaces with caution.</span></span> <span data-ttu-id="8a092-163">背景アクリルは、その名前が示すように、Z オーダーではユーザーの最も近くには表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="8a092-163">Background acrylic, as its name implies, should not be closest to the user in z-order.</span></span> <span data-ttu-id="8a092-164">背景アクリルの複数のレイヤーは、予期しない目の錯覚を引き起こす傾向があるので、使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="8a092-164">Multiple layers of background acrylic tend to result in unexpected optical illusions and should also be avoided.</span></span> <span data-ttu-id="8a092-165">アクリルを重ねる場合は、アプリ内アクリルを重ねてください。また、アクリルの濃淡が薄くなるように値を設定して、アクリルのレイヤーが視覚的に閲覧者の近くに表示されるようにすることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-165">If you choose to layer acrylics, do so with in-app acrylic and consider making acrylic’s tint lighter in value to help visually bring the layers forward to the viewer.</span></span>


## <a name="usability-and-adaptability"></a><span data-ttu-id="8a092-166">使いやすさと適応性</span><span class="sxs-lookup"><span data-stu-id="8a092-166">Usability and adaptability</span></span>
<span data-ttu-id="8a092-167">アクリルの外観は、さまざまなデバイスやコンテキストに合うように自動的に対応します。</span><span class="sxs-lookup"><span data-stu-id="8a092-167">Acrylic automatically adapts its appearance for a wide variety of devices and contexts.</span></span>

<span data-ttu-id="8a092-168">ハイ コントラスト モードでは、ユーザーが選んだ見慣れた背景色が、アクリルの代わりに引き続き表示されます。</span><span class="sxs-lookup"><span data-stu-id="8a092-168">In High Contrast mode, users continue to see the familiar background color of their choosing in place of acrylic.</span></span> <span data-ttu-id="8a092-169">また次の場合には、背景アクリルとアプリ内アクリルはどちらも、単色として表示されます。</span><span class="sxs-lookup"><span data-stu-id="8a092-169">In addition, both background acrylic and in-app acrylic appear as a solid color</span></span>
 - <span data-ttu-id="8a092-170">ユーザーが個人用設定で透明度をオフにした場合</span><span class="sxs-lookup"><span data-stu-id="8a092-170">When the user turns off transparency in Personalization settings</span></span>
 - <span data-ttu-id="8a092-171">バッテリー節約機能モードがアクティブ化されている場合</span><span class="sxs-lookup"><span data-stu-id="8a092-171">When battery saver mode is activated</span></span>
 - <span data-ttu-id="8a092-172">アプリがローエンド ハードウェアで実行されている場合</span><span class="sxs-lookup"><span data-stu-id="8a092-172">When the app runs on low-end hardware</span></span>

<span data-ttu-id="8a092-173">また次の場合には、背景アクリルのみ、その透明度とテクスチャを単色で置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-173">In addition, only background acrylic will replace its transparency and texture with a solid color</span></span>
 - <span data-ttu-id="8a092-174">アプリ ウィンドウがデスクトップで非アクティブ化されている場合</span><span class="sxs-lookup"><span data-stu-id="8a092-174">When an app window on desktop deactivates</span></span>
 - <span data-ttu-id="8a092-175">UWP アプリが、電話、Xbox、HoloLens、またはタブレット モードで実行されている場合</span><span class="sxs-lookup"><span data-stu-id="8a092-175">When the UWP app is running on phone, Xbox, HoloLens or tablet mode</span></span>

### <a name="legibility-considerations"></a><span data-ttu-id="8a092-176">見やすくするための考慮事項</span><span class="sxs-lookup"><span data-stu-id="8a092-176">Legibility considerations</span></span>
<span data-ttu-id="8a092-177">アプリがユーザーに表示するすべてのテキストでは、[コントラスト比を適切な値にする](../accessibility/accessible-text-requirements.md)ことが重要です。</span><span class="sxs-lookup"><span data-stu-id="8a092-177">It’s important to ensure that any text your app presents to users [meets contrast ratios](../accessibility/accessible-text-requirements.md).</span></span> <span data-ttu-id="8a092-178">ハイカラーの黒や白のテキスト、またはミディアムカラーの灰色のテキストがアクリル上で適切なコントラスト比になるように、アクリルのレシピは最適化されています。</span><span class="sxs-lookup"><span data-stu-id="8a092-178">We’ve optimized the acrylic recipe so that high-color black, white or even medium-color gray text meets contrast ratios on top of acrylic.</span></span> <span data-ttu-id="8a092-179">プラットフォームによって提供されるテーマ リソースは、既定で、濃淡の色のコントラストが 80% の不透明度に設定されます。</span><span class="sxs-lookup"><span data-stu-id="8a092-179">The theme resources provided by the platform default to contrasting tint colors at 80% opacity.</span></span> <span data-ttu-id="8a092-180">ハイカラーの本文テキストをアクリル上に配置する場合、濃淡の不透明度を下げて、見やすさを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-180">When placing high-color body text on acrylic, you can reduce tint opacity while maintaining legibility.</span></span> <span data-ttu-id="8a092-181">ダーク モードでは濃淡の不透明度を 70% にすることができ、ライト モードのアクリルではコントラスト比を 50% の不透明度に合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-181">In dark mode, tint opacity can be 70%, while light mode acrylic will meet contrast ratios at 50% opacity.</span></span>

<span data-ttu-id="8a092-182">アクリル サーフェスの上にアクセント カラーのテキストを配置することはお勧めしません。これは、これらの組み合わせが、15 ピクセルのフォント サイズでのコントラスト比の最小要件を満たさない可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="8a092-182">We don't recommend placing accent-colored text on your acrylic surfaces because these combinations are likely to not pass minimum contrast ratio requirements at 15px font size.</span></span> <span data-ttu-id="8a092-183">[ハイパーリンク](../controls-and-patterns/hyperlinks.md)はアクリル要素上には配置しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="8a092-183">Try to avoid placing [hyperlinks](../controls-and-patterns/hyperlinks.md) over acrylic elements.</span></span> <span data-ttu-id="8a092-184">また、アクリルの濃淡の色や透明度のレベルを、テーマ リソースによって提供されるプラットフォームの既定値以外にカスタマイズする場合は、見やすさへの影響を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-184">Also, if you choose to customize the acrylic tint color or opacity level outside of the platform defaults provided by the theme resource, keep the impact on legibility in mind.</span></span>

## <a name="acrylic-theme-resources"></a><span data-ttu-id="8a092-185">アクリルのテーマ リソース</span><span class="sxs-lookup"><span data-stu-id="8a092-185">Acrylic theme resources</span></span>
<span data-ttu-id="8a092-186">新しい XAML AcrylicBrush テーマ リソースや定義済みの AcrylicBrush テーマ リソースを使用して、アクリルをアプリのサーフェスに簡単に適用できます。</span><span class="sxs-lookup"><span data-stu-id="8a092-186">You can easily apply acrylic to your app’s surfaces using the new XAML AcrylicBrush or predefined AcrylicBrush theme resources.</span></span> <span data-ttu-id="8a092-187">まず、アプリ内アクリルまたは背景アクリルのどちらを使用するかを決める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a092-187">First, you’ll need to decide whether to use in-app or background acrylic.</span></span> <span data-ttu-id="8a092-188">この記事で推奨事項として既に説明した一般的なアプリのパターンを確認してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-188">Be sure to review common app patterns described earlier in this article for recommendations.</span></span>

<span data-ttu-id="8a092-189">背景アクリルやアプリ内アクリルの両方を対象としたブラシのテーマ リソースのコレクションが作成されています。これらのリソースでは、アプリのテーマが重視され、必要に応じて、単色にフォール バックします。</span><span class="sxs-lookup"><span data-stu-id="8a092-189">We’ve created a collection of brush theme resources for both background and in-app acrylic types that respect the app’s theme and fall back to solid colors as needed.</span></span> <span data-ttu-id="8a092-190">*AcrylicWindow* という名前のリソースは背景アクリルを表し、*AcrylicElement* はアプリ内アクリルを表します。</span><span class="sxs-lookup"><span data-stu-id="8a092-190">Resources named *AcrylicWindow* represent background acrylic, while *AcrylicElement* refers to in-app acrylic.</span></span>

<table>
    <tr>
        <th align="center"><span data-ttu-id="8a092-191">リソース キー</span><span class="sxs-lookup"><span data-stu-id="8a092-191">Resource key</span></span></th>
        <th align="center"><span data-ttu-id="8a092-192">濃淡の不透明度</span><span class="sxs-lookup"><span data-stu-id="8a092-192">Tint opacity</span></span></th>
        <th align="center">[<span data-ttu-id="8a092-193">フォールバックの色</span><span class="sxs-lookup"><span data-stu-id="8a092-193">Fallback color</span></span>](color.md)</th>
    </tr>
    <tr>
        <td> <span data-ttu-id="8a092-194">SystemControlAcrylicWindowBrush、SystemControlAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-194">SystemControlAcrylicWindowBrush, SystemControlAcrylicElementBrush</span></span> <br/> <span data-ttu-id="8a092-195">SystemControlChromeLowAcrylicWindowBrush、SystemControlChromeLowAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-195">SystemControlChromeLowAcrylicWindowBrush, SystemControlChromeLowAcrylicElementBrush</span></span> <br/> <span data-ttu-id="8a092-196">SystemControlBaseHighAcrylicWindowBrush、SystemControlBaseHighAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-196">SystemControlBaseHighAcrylicWindowBrush, SystemControlBaseHighAcrylicElementBrush</span></span> <br/> <span data-ttu-id="8a092-197">SystemControlBaseLowAcrylicWindowBrush、SystemControlBaseLowAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-197">SystemControlBaseLowAcrylicWindowBrush, SystemControlBaseLowAcrylicElementBrush</span></span> <br/> <span data-ttu-id="8a092-198">SystemControlAltHighAcrylicWindowBrush、SystemControlAltHighAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-198">SystemControlAltHighAcrylicWindowBrush, SystemControlAltHighAcrylicElementBrush</span></span> <br/> <span data-ttu-id="8a092-199">SystemControlAltLowAcrylicWindowBrush、SystemControlAltLowAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-199">SystemControlAltLowAcrylicWindowBrush, SystemControlAltLowAcrylicElementBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="8a092-200">80%</span><span class="sxs-lookup"><span data-stu-id="8a092-200">80%</span></span> </td>
        <td> <span data-ttu-id="8a092-201">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="8a092-201">ChromeMedium</span></span> <br/> <span data-ttu-id="8a092-202">ChromeLow</span><span class="sxs-lookup"><span data-stu-id="8a092-202">ChromeLow</span></span> <br/><br/> <span data-ttu-id="8a092-203">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="8a092-203">BaseHigh</span></span> <br/><br/> <span data-ttu-id="8a092-204">BaseLow</span><span class="sxs-lookup"><span data-stu-id="8a092-204">BaseLow</span></span> <br/><br/> <span data-ttu-id="8a092-205">AltHigh</span><span class="sxs-lookup"><span data-stu-id="8a092-205">AltHigh</span></span> <br/><br/> <span data-ttu-id="8a092-206">AltLow</span><span class="sxs-lookup"><span data-stu-id="8a092-206">AltLow</span></span> </td>
    </tr>
    </tr>
        <td> <span data-ttu-id="8a092-207">**推奨する使用方法:** これらは、汎用的なアクリルのリソースであり、さまざまな使用方法で適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="8a092-207">**Recommended usage:** These are general-purpose acrylic resources that work well in a wide variety of usages.</span></span> <span data-ttu-id="8a092-208">アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセルよりも小さい場合は、[コントラスト比の要件を満たすように](../accessibility/accessible-text-requirements.md)、80% のアクリル リソースをテキストの背景に配置してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-208">If your app uses secondary text of AltMedium color with text size smaller than 18px, place an 80% acrylic resource behind the text to [meet contrast ratio requirements](../accessibility/accessible-text-requirements.md).</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="8a092-209">SystemControlAcrylicWindowMediumHighBrush、SystemControlAcrylicElementMediumHighBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-209">SystemControlAcrylicWindowMediumHighBrush, SystemControlAcrylicElementMediumHighBrush</span></span> <br/> <span data-ttu-id="8a092-210">SystemControlBaseHighAcrylicWindowMediumHighBrush、SystemControlBaseHighAcrylicElementMediumHighBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-210">SystemControlBaseHighAcrylicWindowMediumHighBrush, SystemControlBaseHighAcrylicElementMediumHighBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="8a092-211">70%</span><span class="sxs-lookup"><span data-stu-id="8a092-211">70%</span></span> </td>
        <td> <span data-ttu-id="8a092-212">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="8a092-212">ChromeMedium</span></span> <br/><br/> <span data-ttu-id="8a092-213">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="8a092-213">BaseHigh</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="8a092-214">**推奨する使用方法:** アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセル以上になる場合は、これらのより透過的な 70% のアクリル リソースをテキストの背景に配置できます。</span><span class="sxs-lookup"><span data-stu-id="8a092-214">**Recommended usage:** If your app uses secondary text of AltMedium color with a text size of 18px or larger, you can place these more transparent 70% acrylic resources behind the text.</span></span> <span data-ttu-id="8a092-215">これらのリソースは、アプリの最上部にある水平方向のナビゲーション領域やコマンド実行領域で使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-215">We recommend using these resources in your app's top horizontal navigation and commanding areas.</span></span>  </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="8a092-216">SystemControlChromeHighAcrylicWindowMediumBrush、SystemControlChromeHighAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-216">SystemControlChromeHighAcrylicWindowMediumBrush, SystemControlChromeHighAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="8a092-217">SystemControlChromeMediumAcrylicWindowMediumBrush、SystemControlChromeMediumAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-217">SystemControlChromeMediumAcrylicWindowMediumBrush, SystemControlChromeMediumAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="8a092-218">SystemControlChromeMediumLowAcrylicWindowMediumBrush、SystemControlChromeMediumLowAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-218">SystemControlChromeMediumLowAcrylicWindowMediumBrush, SystemControlChromeMediumLowAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="8a092-219">SystemControlBaseHighAcrylicWindowMediumBrush、SystemControlBaseHighAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-219">SystemControlBaseHighAcrylicWindowMediumBrush, SystemControlBaseHighAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="8a092-220">SystemControlBaseMediumLowAcrylicWindowMediumBrush、SystemControlBaseMediumLowAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-220">SystemControlBaseMediumLowAcrylicWindowMediumBrush, SystemControlBaseMediumLowAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="8a092-221">SystemControlAltMediumLowAcrylicWindowMediumBrush、SystemControlAltMediumLowAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-221">SystemControlAltMediumLowAcrylicWindowMediumBrush, SystemControlAltMediumLowAcrylicElementMediumBrush</span></span>  </td>
        <td align="center"> <span data-ttu-id="8a092-222">60%</span><span class="sxs-lookup"><span data-stu-id="8a092-222">60%</span></span> </td>
        <td> <span data-ttu-id="8a092-223">ChromeHigh</span><span class="sxs-lookup"><span data-stu-id="8a092-223">ChromeHigh</span></span> <br/><br/> <span data-ttu-id="8a092-224">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="8a092-224">ChromeMedium</span></span> <br/><br/> <span data-ttu-id="8a092-225">ChromeMediumLow</span><span class="sxs-lookup"><span data-stu-id="8a092-225">ChromeMediumLow</span></span> <br/><br/> <span data-ttu-id="8a092-226">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="8a092-226">BaseHigh</span></span> <br/><br/> <span data-ttu-id="8a092-227">BaseLow</span><span class="sxs-lookup"><span data-stu-id="8a092-227">BaseLow</span></span> <br/><br/> <span data-ttu-id="8a092-228">AltMediumLow</span><span class="sxs-lookup"><span data-stu-id="8a092-228">AltMediumLow</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="8a092-229">**推奨する使用方法:** プライマリ テキストの色が AltHigh で、このテキストのみをアクリルの上に配置する場合は、これらの 60% のリソースを利用できます。</span><span class="sxs-lookup"><span data-stu-id="8a092-229">**Recommended usage:** When placing only primary text of AltHigh color over acrylic, your app can utilize these 60% resources.</span></span> <span data-ttu-id="8a092-230">アプリの[垂直方向のナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md) (ハンバーガー メニュー) を描画するときは、60% のアクリルを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-230">We recommend painting your app's [vertical navigation pane](../controls-and-patterns/navigationview.md), i.e. hamburger menu, with 60% acrylic.</span></span> </td>
    </tr>
</table>

<span data-ttu-id="8a092-231">中間色のアクリルに加え、ユーザーが指定したアクセント カラーを使用してアクリルに濃淡を付けるリソースも追加しました。</span><span class="sxs-lookup"><span data-stu-id="8a092-231">In addition to color-neutral acrylic, we've also added resources that tint acrylic using the user-specified accent color.</span></span> <span data-ttu-id="8a092-232">色が付いたアクリルは慎重に使用してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-232">We recommend using colored acrylic sparingly.</span></span> <span data-ttu-id="8a092-233">提供されている dark1 と dark2 のバリアントを使用する場合、濃色テーマのテキストの色と調和するように、白または明るい色のテキストをこれらのリソース上に配置してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-233">For the dark1 and dark2 variants provided, place white or light-colored text consistent with dark theme text color over these resources.</span></span>
<table>
    <tr>
        <th align="center"><span data-ttu-id="8a092-234">リソース キー</span><span class="sxs-lookup"><span data-stu-id="8a092-234">Resource key</span></span></th>
        <th align="center"><span data-ttu-id="8a092-235">濃淡の不透明度</span><span class="sxs-lookup"><span data-stu-id="8a092-235">Tint opacity</span></span></th>
        <th align="center">[<span data-ttu-id="8a092-236">濃淡とフォールバックの色</span><span class="sxs-lookup"><span data-stu-id="8a092-236">Tint and Fallback colors</span></span>](color.md)</th>
    </tr>
    <tr>
        <td> <span data-ttu-id="8a092-237">SystemControlAccentAcrylicWindowAccentMediumHighBrush、SystemControlAccentAcrylicElementAccentMediumHighBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-237">SystemControlAccentAcrylicWindowAccentMediumHighBrush, SystemControlAccentAcrylicElementAccentMediumHighBrush</span></span>  </td>
        <td align="center"> <span data-ttu-id="8a092-238">70%</span><span class="sxs-lookup"><span data-stu-id="8a092-238">70%</span></span> </td>
        <td> <span data-ttu-id="8a092-239">SystemAccentColor</span><span class="sxs-lookup"><span data-stu-id="8a092-239">SystemAccentColor</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="8a092-240">SystemControlAccentDark1AcrylicWindowAccentDark1Brush、SystemControlAccentDark1AcrylicElementAccentDark1Brush</span><span class="sxs-lookup"><span data-stu-id="8a092-240">SystemControlAccentDark1AcrylicWindowAccentDark1Brush, SystemControlAccentDark1AcrylicElementAccentDark1Brush</span></span>  </td>
        <td align="center"> <span data-ttu-id="8a092-241">80%</span><span class="sxs-lookup"><span data-stu-id="8a092-241">80%</span></span> </td>
        <td> <span data-ttu-id="8a092-242">SystemAccentColorDark1</span><span class="sxs-lookup"><span data-stu-id="8a092-242">SystemAccentColorDark1</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="8a092-243">SystemControlAccentDark2AcrylicWindowAccentDark2MediumHighBrush、SystemControlAccentDark2AcrylicElementAccentDark2MediumHighBrush</span><span class="sxs-lookup"><span data-stu-id="8a092-243">SystemControlAccentDark2AcrylicWindowAccentDark2MediumHighBrush, SystemControlAccentDark2AcrylicElementAccentDark2MediumHighBrush</span></span>  </td>
        <td align="center"> <span data-ttu-id="8a092-244">70%</span><span class="sxs-lookup"><span data-stu-id="8a092-244">70%</span></span> </td>
        <td> <span data-ttu-id="8a092-245">SystemAccentColorDark2</span><span class="sxs-lookup"><span data-stu-id="8a092-245">SystemAccentColorDark2</span></span> </td>
    </tr>
</table>


<span data-ttu-id="8a092-246">特定のサーフェスを塗りつぶすには、上記のテーマ リソースのいずれかを、他のブラシ リソースを適用する要素の背景に適用します。</span><span class="sxs-lookup"><span data-stu-id="8a092-246">To paint a specific surface, apply one of the above theme resources to element backgrounds just as you would apply any other brush resource.</span></span>

```xaml
<Grid Background="{ThemeResource SystemControlAcrylicElementBrush}">
```

## <a name="custom-acrylic-brush"></a><span data-ttu-id="8a092-247">カスタム アクリル ブラシ</span><span class="sxs-lookup"><span data-stu-id="8a092-247">Custom acrylic brush</span></span>
<span data-ttu-id="8a092-248">色の濃淡をアプリのアクリルに加えて、ブランドを表示したり、ページ上にある他の要素と視覚的にバランスをとったりすることができます。</span><span class="sxs-lookup"><span data-stu-id="8a092-248">You may choose to add a color tint to your app’s acrylic to show branding or provide visual balance with other elements on the page.</span></span> <span data-ttu-id="8a092-249">グレースケール以外の色を表示するには、次のプロパティを使って、独自のアクリル ブラシを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a092-249">To show color rather than greyscale, you’ll need to define your own acrylic brushes using the following properties.</span></span>
 - <span data-ttu-id="8a092-250">**TintColor**: 色/濃淡のオーバーレイ レイヤーです。</span><span class="sxs-lookup"><span data-stu-id="8a092-250">**TintColor**: the color/tint overlay layer.</span></span> <span data-ttu-id="8a092-251">RGB の色の値とアルファ チャネルの不透明度の両方を指定することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-251">Consider specifying both the RGB color value and alpha channel opacity.</span></span>
 - <span data-ttu-id="8a092-252">**TintOpacity**: 濃淡レイヤーの不透明度です。</span><span class="sxs-lookup"><span data-stu-id="8a092-252">**TintOpacity**: the opacity of the tint layer.</span></span> <span data-ttu-id="8a092-253">開始点として 80% の不透明度をお勧めします。ただし、透明度が異なると、別の色を使用したほうがより魅力的に表示される可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="8a092-253">We recommend 80% opacity as a starting point, although different colors may look more compelling at other transparencies.</span></span>
 - <span data-ttu-id="8a092-254">**BackgroundSource**: 背景アクリルまたはアプリ内アクリルのどちらを使用するかを指定するフラグです。</span><span class="sxs-lookup"><span data-stu-id="8a092-254">**BackgroundSource**: the flag to specify whether you want background or in-app acrylic.</span></span>
 - <span data-ttu-id="8a092-255">**FallbackColor**: バッテリ低下モードでアクリルと置き換わる単色です。</span><span class="sxs-lookup"><span data-stu-id="8a092-255">**FallbackColor**: the solid color that replaces acrylic in low-battery mode.</span></span> <span data-ttu-id="8a092-256">背景アクリルでは、フォールバックの色は、アプリが作業中のデスクトップ ウィンドウにない場合、またはアプリが電話や Xbox 上で実行されている場合にもアクリルと置き換わります。</span><span class="sxs-lookup"><span data-stu-id="8a092-256">For background acrylic, fallback color also replaces acrylic when your app isn’t in the active desktop window or when the app is running on phone and Xbox.</span></span>


![淡色テーマのアクリルの見本](images/CustomAcrylic_Swatches_LightTheme.png)

![濃色テーマのアクリルの見本](images/CustomAcrylic_Swatches_DarkTheme.png)

<span data-ttu-id="8a092-259">アクリル ブラシを追加するには、濃色テーマ、淡色テーマ、ハイ コントラスト テーマの 3 つのリソースを定義します。</span><span class="sxs-lookup"><span data-stu-id="8a092-259">To add an acrylic brush, define the three resources for dark, light and high contrast themes.</span></span> <span data-ttu-id="8a092-260">ハイ コントラストでは、濃色/淡色の AcrylicBrush と同じ x:Key で SolidColorBrush を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a092-260">Note that in high contrast, we recommend using a SolidColorBrush with the same x:Key as the dark/light AcrylicBrush.</span></span>

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

<span data-ttu-id="8a092-261">次のサンプルは、コードで AcrylicBrush を宣言する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8a092-261">The following sample shows how to declare AcrylicBrush in code.</span></span> <span data-ttu-id="8a092-262">アプリが複数の OS ターゲットをサポートする場合は、この API がユーザーのコンピューターで利用できることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-262">If your app supports multiple OS targets, be sure to check that this API is available on the user’s machine.</span></span>

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

## <a name="extend-acrylic-into-the-title-bar"></a><span data-ttu-id="8a092-263">アクリルをタイトル バーに拡張する</span><span class="sxs-lookup"><span data-stu-id="8a092-263">Extend acrylic into the title bar</span></span>

<span data-ttu-id="8a092-264">アプリのウィンドウを滑らかな外観にするには、タイトル バー領域にアクリルを使います。</span><span class="sxs-lookup"><span data-stu-id="8a092-264">To give your app's window a seamless look, you can use acrylic in the title bar area.</span></span> <span data-ttu-id="8a092-265">この例では、[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar) オブジェクトの [ButtonBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar#Windows_UI_ViewManagement_ApplicationViewTitleBar_ButtonBackgroundColor) および [ButtonInactiveBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar#Windows_UI_ViewManagement_ApplicationViewTitleBar_ButtonInactiveBackgroundColor) プロパティを [Colors.Transparent](https://docs.microsoft.com/uwp/api/Windows.UI.Colors#Windows_UI_Colors_Transparent) に設定することで、アクリルをタイトル バーに拡張します。</span><span class="sxs-lookup"><span data-stu-id="8a092-265">This example extends acrylic into the title bar by setting the [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar) object's [ButtonBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar#Windows_UI_ViewManagement_ApplicationViewTitleBar_ButtonBackgroundColor) and [ButtonInactiveBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar#Windows_UI_ViewManagement_ApplicationViewTitleBar_ButtonInactiveBackgroundColor) properties to [Colors.Transparent](https://docs.microsoft.com/uwp/api/Windows.UI.Colors#Windows_UI_Colors_Transparent).</span></span> 

```csharp
/// Extend acrylic into the title bar. 
private void extendAcrylicIntoTitleBar()
{
    CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
    ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
    titleBar.ButtonBackgroundColor = Colors.Transparent;
    titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
}
```

<span data-ttu-id="8a092-266">このコードは、ここに示すようにアプリの [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) メソッド (_App.xaml.cs_) 内の [Window.Activate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window#Windows_UI_Xaml_Window_Activate) の呼び出しの後か、アプリの最初のページに配置できます。</span><span class="sxs-lookup"><span data-stu-id="8a092-266">This code can be placed in your app's [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) method (_App.xaml.cs_), after the call to [Window.Activate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window#Windows_UI_Xaml_Window_Activate), as shown here, or in your app's first page.</span></span> 


```csharp
// Call your extend acrylic code in the OnLaunched event, after 
// calling Window.Current.Activate.
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == null)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
    }

    if (e.PrelaunchActivated == false)
    {
        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(MainPage), e.Arguments);
        }
        // Ensure the current window is active
        Window.Current.Activate();

        // Extend acrylic
        extendAcrylicIntoTitleBar();
    }
}
```

<span data-ttu-id="8a092-267">また、通常はタイトル バーに自動的に表示されるアプリのタイトルを、`CaptionTextBlockStyle` を使用した TextBlock で描画する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="8a092-267">In addition, you'll need to draw your app's title, which normally appears automatically in the title bar, with a TextBlock using `CaptionTextBlockStyle`.</span></span> <span data-ttu-id="8a092-268">詳しくは、「[タイトル バーのカスタマイズ](../shell/title-bar.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8a092-268">For more info, see [Title bar customization](../shell/title-bar.md).</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="8a092-269">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="8a092-269">Do's and don'ts</span></span>
* <span data-ttu-id="8a092-270">アクリルは、ナビゲーション ウィンドウなど、アプリのプライマリ サーフェス以外のサーフェスで背景素材として使用してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-270">Do use acrylic as the background material of non-primary app surfaces like navigation panes.</span></span>
* <span data-ttu-id="8a092-271">シームレスなエクスペリエンスを実現するには、アプリの周囲とわずかにブレンドするようにして、アクリルをアプリの 1 つ以上の端にまで拡張してください。</span><span class="sxs-lookup"><span data-stu-id="8a092-271">Do extend acrylic to at least one edge of your app to provide a seamless experience by subtly blending with the app’s surroundings.</span></span>
* <span data-ttu-id="8a092-272">アプリ内アクリルと背景アクリルは、継ぎ目部分での視覚的なテンションを回避するために、隣接するようには配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="8a092-272">Don’t place in-app and background acrylics directly adjacent to avoid visual tension at the seams.</span></span>
* <span data-ttu-id="8a092-273">複数のアクリル ウィンドウを、同じ濃淡や不透明度で隣接するように配置しないでください。このようにすると、望ましくない継ぎ目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="8a092-273">Don't place multiple acrylic panes with the same tint and opacity next to each other because this results in an undesirable visible seam.</span></span>
* <span data-ttu-id="8a092-274">アクリル サーフェスの上には、アクセント カラーのテキストを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="8a092-274">Don’t place accent-colored text over acrylic surfaces.</span></span>

## <a name="how-we-designed-acrylic"></a><span data-ttu-id="8a092-275">アクリルをどのように設計したか</span><span class="sxs-lookup"><span data-stu-id="8a092-275">How we designed acrylic</span></span>

<span data-ttu-id="8a092-276">アクリルの主要なコンポーネントを微調整して、ユニークな外観とプロパティを作成しました。</span><span class="sxs-lookup"><span data-stu-id="8a092-276">We fine-tuned acrylic’s key components to arrive at its unique appearance and properties.</span></span> <span data-ttu-id="8a092-277">設計の開始時には透明度、ぼかし、ノイズを使い、平坦なサーフェスに視覚的な奥行きとディメンションを追加しました。</span><span class="sxs-lookup"><span data-stu-id="8a092-277">We started with transparency, blur and noise to add visual depth and dimension to flat surfaces.</span></span> <span data-ttu-id="8a092-278">除外ブレンド モード レイヤーを追加して、アクリルの背景に配置される UI のコントラストと見やすさを確保しました。</span><span class="sxs-lookup"><span data-stu-id="8a092-278">We added an exclusion blend mode layer to ensure contrast and legibility of UI placed on an acrylic background.</span></span> <span data-ttu-id="8a092-279">最後に、ユーザーの個性を反映できるように、色の濃淡を追加しました。</span><span class="sxs-lookup"><span data-stu-id="8a092-279">Finally, we added color tint for personalization opportunities.</span></span> <span data-ttu-id="8a092-280">次のレイヤーを組み合わせることで、新しくて使いやすい素材が生みだされます。</span><span class="sxs-lookup"><span data-stu-id="8a092-280">In concert these layers add up to a fresh, usable material.</span></span>

![アクリルのレシピ](images/AcrylicRecipe_Diagram.png)
<br/><span data-ttu-id="8a092-282">アクリルのレシピ: 背景、ぼかし、除外ブレンド、色/濃淡のオーバーレイ、ノイズ</span><span class="sxs-lookup"><span data-stu-id="8a092-282">The acrylic recipe: background, blur, exclusion blend, color/tint overlay, noise</span></span>

<!--
<div class="microsoft-internal-note">
When designing your app, please utilize these [design resources](http://uni/DesignDepot.FrontEnd/#/Search?t=Resources%7CNeon%7CToolkit&f=Acrylic%20Material) to show acrylic in comps. The linked templates are the most accurate way to represent acrylic material in Photoshop and Illustrator. The ordering, as noted in the recipe diagram above, should start from the top: <br/>
 - Noise asset (tiled) at 2% opacity <br/>
 - Base color/tint/alpha layer <br/>
 - Exclusion blend (white @ 10% opacity) <br/>
 - Gaussian blur (30px radius) <br/>
</div>
-->

## <a name="get-the-sample-code"></a><span data-ttu-id="8a092-283">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="8a092-283">Get the sample code</span></span>

- <span data-ttu-id="8a092-284">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="8a092-284">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="8a092-285">関連記事</span><span class="sxs-lookup"><span data-stu-id="8a092-285">Related articles</span></span>

[**<span data-ttu-id="8a092-286">表示ハイライト</span><span class="sxs-lookup"><span data-stu-id="8a092-286">Reveal highlight</span></span>**](reveal.md)
