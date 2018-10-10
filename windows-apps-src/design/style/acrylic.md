---
author: mijacobs
description: 半透明のテクスチャを作成するブラシの種類。
title: アクリル素材
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
ms.localizationpriority: medium
ms.openlocfilehash: 3bf91725a62c8d03c37448ddf69b072461288f11
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4500830"
---
# <a name="acrylic-material"></a><span data-ttu-id="13f13-104">アクリル素材</span><span class="sxs-lookup"><span data-stu-id="13f13-104">Acrylic material</span></span>

![ヒーロー イメージ](images/header-acrylic.svg)

<span data-ttu-id="13f13-106">アクリルは、半透明のテクスチャを作成する[ブラシ](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush)の種類です。</span><span class="sxs-lookup"><span data-stu-id="13f13-106">Acrylic is a type of [Brush](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Media.Brush) that creates a translucent texture.</span></span> <span data-ttu-id="13f13-107">アクリルをアプリ サーフェスに適用すると、奥行きを加えたり、視覚的な階層を確立したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="13f13-107">You can apply acrylic to app surfaces to add depth and help establish a visual hierarchy.</span></span>  <!-- By allowing user-selected wallpaper or colors to shine through, acrylic keeps users in touch with the OS personalization they've chosen. -->

> <span data-ttu-id="13f13-108">**重要な API**: [AcrylicBrush クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush)、[Background プロパティ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control.Background)</span><span class="sxs-lookup"><span data-stu-id="13f13-108">**Important APIs**: [AcrylicBrush class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.acrylicbrush), [Background property](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control.Background)</span></span>

:::row:::
    :::column:::
        Acrylic in light theme
        ![Acrylic in light theme](images/Acrylic_LightTheme_Base.png)
    :::column-end:::
    :::column:::
        Acrylic in dark theme
        ![Acrylic in dark theme](images/Acrylic_DarkTheme_Base.png)
    :::column-end:::
:::row-end:::

## <a name="acrylic-and-the-fluent-design-system"></a><span data-ttu-id="13f13-109">アクリルと Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="13f13-109">Acrylic and the Fluent Design System</span></span>

 <span data-ttu-id="13f13-110">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="13f13-110">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="13f13-111">アクリルは、アプリに物理的なテクスチャ (マテリアル) と深度を追加する Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="13f13-111">Acrylic is a Fluent Design System component that adds physical texture (material) and depth to your app.</span></span> <span data-ttu-id="13f13-112">詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="13f13-112">To learn more, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

 ## <a name="video-summary"></a><span data-ttu-id="13f13-113">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="13f13-113">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev002/player]

## <a name="examples"></a><span data-ttu-id="13f13-114">例</span><span class="sxs-lookup"><span data-stu-id="13f13-114">Examples</span></span>

:::row:::
    :::column span:::
        ![Some image](images/XAML-controls-gallery-app-icon.png)
    :::column-end:::
    :::column span="2":::
        **XAML Controls Gallery**<br>
        If you have the XAML Controls Gallery app installed, click <a href="xamlcontrolsgallery:/item/Acrylic">here</a> to open the app and see acrylic in action.

        <a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a><br>
        <a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">Get the source code (GitHub)</a>
    :::column-end:::
:::row-end:::

## <a name="acrylic-blend-types"></a><span data-ttu-id="13f13-115">アクリル ブレンドの種類</span><span class="sxs-lookup"><span data-stu-id="13f13-115">Acrylic blend types</span></span>
<span data-ttu-id="13f13-116">アクリルの最も注目すべき特徴は、その透明度です。</span><span class="sxs-lookup"><span data-stu-id="13f13-116">Acrylic's most noticeable characteristic is its transparency.</span></span> <span data-ttu-id="13f13-117">アクリル ブレンドの種類は 2 つあり、素材を通して何が表示されるかを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="13f13-117">There are two acrylic blend types that change what’s visible through the material:</span></span>
 - <span data-ttu-id="13f13-118">**背景アクリル**では、デスクトップの壁紙と現在アクティブになっているアプリの背後にある他のウィンドウが表示されます。これにより、アプリケーション ウィンドウの間に奥行きが出て、ユーザーが個人的に優先する画面を明示しておくことができます。</span><span class="sxs-lookup"><span data-stu-id="13f13-118">**Background acrylic** reveals the desktop wallpaper and other windows that are behind the currently active app, adding depth between application windows while celebrating the user’s personalization preferences.</span></span>
 - <span data-ttu-id="13f13-119">**アプリ内アクリル**では、アプリ フレーム内に奥行きの感覚がもたらされ、フォーカスと階層の両方が提供されます。</span><span class="sxs-lookup"><span data-stu-id="13f13-119">**In-app acrylic** adds a sense of depth within the app frame, providing both focus and hierarchy.</span></span>

 ![背景アクリル](images/BackgroundAcrylic_DarkTheme.png)

 ![アプリ内アクリル](images/AppAcrylic_DarkTheme.png)

 <span data-ttu-id="13f13-122">複数のアクリル サーフェス注意を: 背景アクリルの複数のレイヤーが煩わしくない目の錯覚を作成できます。</span><span class="sxs-lookup"><span data-stu-id="13f13-122">Layer multiple acrylic surfaces with caution: multiple layers of background acrylic can create distracting optical illusions.</span></span>

## <a name="when-to-use-acrylic"></a><span data-ttu-id="13f13-123">アクリルを使用する状況</span><span class="sxs-lookup"><span data-stu-id="13f13-123">When to use acrylic</span></span>

* <span data-ttu-id="13f13-124">NavigationView またはインラインのコマンド実行要素などの UI をサポートするためには、アプリ内アクリルを使用します。</span><span class="sxs-lookup"><span data-stu-id="13f13-124">Use in-app acrylic for supporting UI, such as NavigationView or in-line commanding elements.</span></span> 
* <span data-ttu-id="13f13-125">コンテキスト メニューのポップアップ、および光 dimsissable UI などの一時的な UI 要素の背景アクリルを使用します。</span><span class="sxs-lookup"><span data-stu-id="13f13-125">Use background acrylic for transient UI elements, such as context menus, flyouts, and light-dimsissable UI.</span></span><br /><span data-ttu-id="13f13-126">一時的なシナリオでアクリルを使用すると、一時的な UI をトリガーしたコンテンツと視覚的な関係を維持できます。</span><span class="sxs-lookup"><span data-stu-id="13f13-126">Using Acrylic in transient scenarios helps maintain a visual relationship with the content that triggered the transient UI.</span></span>

<span data-ttu-id="13f13-127">ナビゲーションのサーフェスをアプリ内アクリルを使用している場合をアプリのフローを向上させるためのアクリル ウィンドウの下にあるコンテンツを拡張することを検討します。</span><span class="sxs-lookup"><span data-stu-id="13f13-127">If you are using in-app acrylic on navigation surfaces, consider extending content beneath the acrylic pane to improve the flow on your app.</span></span> <span data-ttu-id="13f13-128">NavigationView を使用して、これは、自動的にします。</span><span class="sxs-lookup"><span data-stu-id="13f13-128">Using NavigationView will do this for you automatically.</span></span> <span data-ttu-id="13f13-129">ただし、ストライプ効果の作成を回避するため、複数のアクリルのエッジ - を配置しないでくださいぼやけたの 2 つのサーフェスの間、望ましくない継ぎ目を作成このことができます。</span><span class="sxs-lookup"><span data-stu-id="13f13-129">However, to avoid creating a striping effect, try not to place multiple pieces of acrylic edge-to-edge - this can create an unwanted seam between the two blurred surfaces.</span></span> <span data-ttu-id="13f13-130">アクリルをするために視覚的に適合するように設計ツールしますが、適切に使用できますノイズ。</span><span class="sxs-lookup"><span data-stu-id="13f13-130">Acrylic is a tool to bring visual harmony to your designs, but when used incorrectly, can result in visual noise.</span></span>

<span data-ttu-id="13f13-131">アクリルをアプリに組み込むに最適な方法を決定する次の使用パターンを検討してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-131">Consider the following usage patterns to decide how best to incorporate acrylic into your app:</span></span>

### <a name="horizontal-navigation-or-commanding"></a><span data-ttu-id="13f13-132">水平方向のナビゲーションやコマンド実行</span><span class="sxs-lookup"><span data-stu-id="13f13-132">Horizontal navigation or commanding</span></span>

<span data-ttu-id="13f13-133">アプリは NavigationView を活用することはできません、独自にアクリルを追加する場合は、60% の濃淡の不透明度で比較的半透明のアクリルの使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f13-133">If your app is not able to leverage NavigationView and you plan on adding acrylic on your own, we recommend using relatively translucent acrylic with 60% tint opacity.</span></span>
 - <span data-ttu-id="13f13-134">ウィンドウが他のアプリ コンテンツ上でオーバーレイとして開くときは、[60% のアプリ内アクリル](#acrylic-theme-resources)にする必要があります</span><span class="sxs-lookup"><span data-stu-id="13f13-134">When the pane opens as an overlay above other app content, this should be [60% in-app acrylic](#acrylic-theme-resources)</span></span>
 - <span data-ttu-id="13f13-135">ウィンドウがメイン アプリ コンテンツと並んで開かれるときは、[60% の背景アクリル](#acrylic-theme-resources)にする必要があります</span><span class="sxs-lookup"><span data-stu-id="13f13-135">When the pane opens side-by-side with main app content, this should be [60% background acrylic](#acrylic-theme-resources)</span></span>

![アプリ内の水平方向のによるコマンド実行を使ったマップ アプリ](images/Maps_In_App_Acrylic_1.png)

<span data-ttu-id="13f13-137">さらに、上部に、コンテンツの拡張または、アクリルの下にスクロールをことにより、アプリより没入型とシームレスなエクスペリエンスします。</span><span class="sxs-lookup"><span data-stu-id="13f13-137">In addition, having your content extend or scroll under the acrylic at the top will give your app a more immersive and seamless experience.</span></span>

### <a name="vertical-panes"></a><span data-ttu-id="13f13-138">垂直方向のウィンドウ</span><span class="sxs-lookup"><span data-stu-id="13f13-138">Vertical Panes</span></span>

<span data-ttu-id="13f13-139">垂直方向のウィンドウまたはサーフェスに役立つ、アプリのコンテンツをオフのセクションでは、不透明な背景アクリル代わりに使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f13-139">For vertical panes or surfaces that help section off content of your app, we recommend you use an opaque background instead of acrylic.</span></span> <span data-ttu-id="13f13-140">コンテンツの上を垂直方向のウィンドウを開く場合と同様に NavigationView の**Collapsed**または**最小限**のモードでお勧めします、ユーザーがあるこのウィンドウを開いているときに、ページのコンテキストを維持するためにアプリ内アクリルを使用します。</span><span class="sxs-lookup"><span data-stu-id="13f13-140">If your vertical panes open on top of content, like in NavigationView's **Collapsed** or **Minimal** modes, we suggest you use in-app acrylic to help maintain the page's context when the user has this pane open.</span></span>

### <a name="transient-surfaces"></a><span data-ttu-id="13f13-141">一時的なサーフェス</span><span class="sxs-lookup"><span data-stu-id="13f13-141">Transient surfaces</span></span>

<span data-ttu-id="13f13-142">メニュー ポップアップ、非モーダル ポップアップでは、アプリのウィンドウ、簡易または背景アクリルを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f13-142">For apps with menu flyouts, non-modal popups, or light-dismiss panes, it is recommended to use background acrylic.</span></span>

![情報のポップアップを使用してメール アプリのパターン](images/Mail_TransientContextMenu.png)

<span data-ttu-id="13f13-144">アクリルは、既定では多くのコントロールの使用されます。</span><span class="sxs-lookup"><span data-stu-id="13f13-144">Many of our controls will use acrylic by default.</span></span> <span data-ttu-id="13f13-145">[MenuFlyouts](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/menus)、 [AutoSuggestBox](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/auto-suggest-box)、[コンボ ボックス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox)などの光 dimiss ポップアップを持つコントロールはすべてを使用して一時的なアクリルときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="13f13-145">[MenuFlyouts](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/menus), [AutoSuggestBox](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/auto-suggest-box), [ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox) and similar controls with light-dimiss popups will all use the transient acrylic when they are invoked.</span></span>

> [!Note]
> <span data-ttu-id="13f13-146">アクリル サーフェスのレンダリングでは GPU を多用するデバイスの電力消費量を増やすし、バッテリーの寿命を短くことができます。</span><span class="sxs-lookup"><span data-stu-id="13f13-146">Rendering acrylic surfaces is GPU-intensive, which can increase device power consumption and shorten battery life.</span></span> <span data-ttu-id="13f13-147">アクリルの効果は自動的に無効にデバイスがバッテリー節約機能モードを入力し、ユーザーは、すべてのアプリでアクリルの効果を無効にできますを選択した場合。</span><span class="sxs-lookup"><span data-stu-id="13f13-147">Acrylic effects are automatically disabled when devices enter Battery Saver mode, and users can disable acrylic effects for all apps, if they choose.</span></span>

## <a name="usability-and-adaptability"></a><span data-ttu-id="13f13-148">使いやすさと適応性</span><span class="sxs-lookup"><span data-stu-id="13f13-148">Usability and adaptability</span></span>
<span data-ttu-id="13f13-149">アクリルの外観は、さまざまなデバイスやコンテキストに合うように自動的に対応します。</span><span class="sxs-lookup"><span data-stu-id="13f13-149">Acrylic automatically adapts its appearance for a wide variety of devices and contexts.</span></span>

<span data-ttu-id="13f13-150">ハイ コントラスト モードでは、ユーザーが選んだ見慣れた背景色が、アクリルの代わりに引き続き表示されます。</span><span class="sxs-lookup"><span data-stu-id="13f13-150">In High Contrast mode, users continue to see the familiar background color of their choosing in place of acrylic.</span></span> <span data-ttu-id="13f13-151">さらに、背景アクリルとアプリ内アクリルのどちらも、単色として表示されます。</span><span class="sxs-lookup"><span data-stu-id="13f13-151">In addition, both background acrylic and in-app acrylic appear as a solid color:</span></span>
 - <span data-ttu-id="13f13-152">ユーザーが設定で透明度をオフにすると > [パーソナル設定] > 色</span><span class="sxs-lookup"><span data-stu-id="13f13-152">When the user turns off transparency in Settings > Personalization > Color</span></span>
 - <span data-ttu-id="13f13-153">バッテリー節約機能モードがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="13f13-153">When Battery Saver mode is activated</span></span>
 - <span data-ttu-id="13f13-154">アプリがローエンド ハードウェアで実行されている場合</span><span class="sxs-lookup"><span data-stu-id="13f13-154">When the app runs on low-end hardware</span></span>

<span data-ttu-id="13f13-155">さらに、背景アクリルのみ、その透明度とテクスチャを置き換える単色。</span><span class="sxs-lookup"><span data-stu-id="13f13-155">In addition, only background acrylic will replace its translucency and texture with a solid color:</span></span>
 - <span data-ttu-id="13f13-156">アプリ ウィンドウがデスクトップで非アクティブ化されている場合</span><span class="sxs-lookup"><span data-stu-id="13f13-156">When an app window on desktop deactivates</span></span>
 - <span data-ttu-id="13f13-157">UWP アプリが、電話、Xbox、HoloLens、またはタブレット モードで実行されている場合</span><span class="sxs-lookup"><span data-stu-id="13f13-157">When the UWP app is running on phone, Xbox, HoloLens or tablet mode</span></span>

### <a name="legibility-considerations"></a><span data-ttu-id="13f13-158">見やすくするための考慮事項</span><span class="sxs-lookup"><span data-stu-id="13f13-158">Legibility considerations</span></span>
<span data-ttu-id="13f13-159">アプリがユーザーに表示するすべてのテキストでは、[コントラスト比を適切な値にする](../accessibility/accessible-text-requirements.md)ことが重要です。</span><span class="sxs-lookup"><span data-stu-id="13f13-159">It’s important to ensure that any text your app presents to users [meets contrast ratios](../accessibility/accessible-text-requirements.md).</span></span> <span data-ttu-id="13f13-160">ハイカラーの黒や白のテキスト、またはミディアムカラーの灰色のテキストがアクリル上で適切なコントラスト比になるように、アクリルのレシピは最適化されています。</span><span class="sxs-lookup"><span data-stu-id="13f13-160">We’ve optimized the acrylic recipe so that high-color black, white or even medium-color gray text meets contrast ratios on top of acrylic.</span></span> <span data-ttu-id="13f13-161">プラットフォームによって提供されるテーマ リソースは、既定で、濃淡の色のコントラストが 80% の不透明度に設定されます。</span><span class="sxs-lookup"><span data-stu-id="13f13-161">The theme resources provided by the platform default to contrasting tint colors at 80% opacity.</span></span> <span data-ttu-id="13f13-162">ハイカラーの本文テキストをアクリル上に配置する場合、濃淡の不透明度を下げて、見やすさを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="13f13-162">When placing high-color body text on acrylic, you can reduce tint opacity while maintaining legibility.</span></span> <span data-ttu-id="13f13-163">ダーク モードでは濃淡の不透明度を 70% にすることができ、ライト モードのアクリルではコントラスト比を 50% の不透明度に合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="13f13-163">In dark mode, tint opacity can be 70%, while light mode acrylic will meet contrast ratios at 50% opacity.</span></span>

<span data-ttu-id="13f13-164">アクリル サーフェスの上にアクセント カラーのテキストを配置することはお勧めしません。これは、これらの組み合わせが、15 ピクセルのフォント サイズでのコントラスト比の最小要件を満たさない可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="13f13-164">We don't recommend placing accent-colored text on your acrylic surfaces because these combinations are likely to not pass minimum contrast ratio requirements at 15px font size.</span></span> <span data-ttu-id="13f13-165">[ハイパーリンク](../controls-and-patterns/hyperlinks.md)はアクリル要素上には配置しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="13f13-165">Try to avoid placing [hyperlinks](../controls-and-patterns/hyperlinks.md) over acrylic elements.</span></span> <span data-ttu-id="13f13-166">また、アクリルの濃淡の色や透明度のレベルを、テーマ リソースによって提供されるプラットフォームの既定値以外にカスタマイズする場合は、見やすさへの影響を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-166">Also, if you choose to customize the acrylic tint color or opacity level outside of the platform defaults provided by the theme resource, keep the impact on legibility in mind.</span></span>

## <a name="acrylic-theme-resources"></a><span data-ttu-id="13f13-167">アクリルのテーマ リソース</span><span class="sxs-lookup"><span data-stu-id="13f13-167">Acrylic theme resources</span></span>
<span data-ttu-id="13f13-168">新しい XAML AcrylicBrush テーマ リソースや定義済みの AcrylicBrush テーマ リソースを使用して、アクリルをアプリのサーフェスに簡単に適用できます。</span><span class="sxs-lookup"><span data-stu-id="13f13-168">You can easily apply acrylic to your app’s surfaces using the new XAML AcrylicBrush or predefined AcrylicBrush theme resources.</span></span> <span data-ttu-id="13f13-169">まず、アプリ内アクリルまたは背景アクリルのどちらを使用するかを決める必要があります。</span><span class="sxs-lookup"><span data-stu-id="13f13-169">First, you’ll need to decide whether to use in-app or background acrylic.</span></span> <span data-ttu-id="13f13-170">この記事で推奨事項として既に説明した一般的なアプリのパターンを確認してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-170">Be sure to review common app patterns described earlier in this article for recommendations.</span></span>

<span data-ttu-id="13f13-171">背景アクリルやアプリ内アクリルの両方を対象としたブラシのテーマ リソースのコレクションが作成されています。これらのリソースでは、アプリのテーマが重視され、必要に応じて、単色にフォール バックします。</span><span class="sxs-lookup"><span data-stu-id="13f13-171">We’ve created a collection of brush theme resources for both background and in-app acrylic types that respect the app’s theme and fall back to solid colors as needed.</span></span> <span data-ttu-id="13f13-172">*AcrylicWindow* という名前のリソースは背景アクリルを表し、*AcrylicElement* はアプリ内アクリルを表します。</span><span class="sxs-lookup"><span data-stu-id="13f13-172">Resources named *AcrylicWindow* represent background acrylic, while *AcrylicElement* refers to in-app acrylic.</span></span>

<table>
    <tr>
        <th align="center"><span data-ttu-id="13f13-173">リソース キー</span><span class="sxs-lookup"><span data-stu-id="13f13-173">Resource key</span></span></th>
        <th align="center"><span data-ttu-id="13f13-174">濃淡の不透明度</span><span class="sxs-lookup"><span data-stu-id="13f13-174">Tint opacity</span></span></th>
        <th align="center"><a href="color.md"><span data-ttu-id="13f13-175">フォールバックの色</span><span class="sxs-lookup"><span data-stu-id="13f13-175">Fallback color</span></span></a> </th>
    </tr>
    <tr>
        <td> <span data-ttu-id="13f13-176">SystemControlAcrylicWindowBrush、SystemControlAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-176">SystemControlAcrylicWindowBrush, SystemControlAcrylicElementBrush</span></span> <br/> <span data-ttu-id="13f13-177">SystemControlChromeLowAcrylicWindowBrush、SystemControlChromeLowAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-177">SystemControlChromeLowAcrylicWindowBrush, SystemControlChromeLowAcrylicElementBrush</span></span> <br/> <span data-ttu-id="13f13-178">SystemControlBaseHighAcrylicWindowBrush、SystemControlBaseHighAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-178">SystemControlBaseHighAcrylicWindowBrush, SystemControlBaseHighAcrylicElementBrush</span></span> <br/> <span data-ttu-id="13f13-179">SystemControlBaseLowAcrylicWindowBrush、SystemControlBaseLowAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-179">SystemControlBaseLowAcrylicWindowBrush, SystemControlBaseLowAcrylicElementBrush</span></span> <br/> <span data-ttu-id="13f13-180">SystemControlAltHighAcrylicWindowBrush、SystemControlAltHighAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-180">SystemControlAltHighAcrylicWindowBrush, SystemControlAltHighAcrylicElementBrush</span></span> <br/> <span data-ttu-id="13f13-181">SystemControlAltLowAcrylicWindowBrush、SystemControlAltLowAcrylicElementBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-181">SystemControlAltLowAcrylicWindowBrush, SystemControlAltLowAcrylicElementBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="13f13-182">80%</span><span class="sxs-lookup"><span data-stu-id="13f13-182">80%</span></span> </td>
        <td> <span data-ttu-id="13f13-183">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="13f13-183">ChromeMedium</span></span> <br/> <span data-ttu-id="13f13-184">ChromeLow</span><span class="sxs-lookup"><span data-stu-id="13f13-184">ChromeLow</span></span> <br/><br/> <span data-ttu-id="13f13-185">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="13f13-185">BaseHigh</span></span> <br/><br/> <span data-ttu-id="13f13-186">BaseLow</span><span class="sxs-lookup"><span data-stu-id="13f13-186">BaseLow</span></span> <br/><br/> <span data-ttu-id="13f13-187">AltHigh</span><span class="sxs-lookup"><span data-stu-id="13f13-187">AltHigh</span></span> <br/><br/> <span data-ttu-id="13f13-188">AltLow</span><span class="sxs-lookup"><span data-stu-id="13f13-188">AltLow</span></span> </td>
    </tr>
    </tr>
        <td> <span data-ttu-id="13f13-189"><b>推奨する使用方法:</b> これらは、汎用的なアクリルのリソースであり、さまざまな使用方法で適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="13f13-189"><b>Recommended usage:</b> These are general-purpose acrylic resources that work well in a wide variety of usages.</span></span> <span data-ttu-id="13f13-190">アプリで使用するセカンダリ テキストの色が AltMedium で、そのサイズが 18 ピクセルよりも小さい場合は、<a href="../accessibility/accessible-text-requirements.md">コントラスト比の要件を満たすように</a>、80% のアクリル リソースをテキストの背景に配置してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-190">If your app uses secondary text of AltMedium color with text size smaller than 18px, place an 80% acrylic resource behind the text to <a href="../accessibility/accessible-text-requirements.md">meet contrast ratio requirements</a>.</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="13f13-191">SystemControlAcrylicWindowMediumHighBrush、SystemControlAcrylicElementMediumHighBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-191">SystemControlAcrylicWindowMediumHighBrush, SystemControlAcrylicElementMediumHighBrush</span></span> <br/> <span data-ttu-id="13f13-192">SystemControlBaseHighAcrylicWindowMediumHighBrush、SystemControlBaseHighAcrylicElementMediumHighBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-192">SystemControlBaseHighAcrylicWindowMediumHighBrush, SystemControlBaseHighAcrylicElementMediumHighBrush</span></span> </td>
        <td align="center"> <span data-ttu-id="13f13-193">70%</span><span class="sxs-lookup"><span data-stu-id="13f13-193">70%</span></span> </td>
        <td> <span data-ttu-id="13f13-194">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="13f13-194">ChromeMedium</span></span> <br/><br/> <span data-ttu-id="13f13-195">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="13f13-195">BaseHigh</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="13f13-196"><b>推奨する使用方法:</b>アプリでは、テキストのサイズが 18 ピクセル以上で AltMedium 色のセカンダリ テキストを使用している場合は、これら以上半透明 70% のテキストの背景アクリル リソースを配置できます。</span><span class="sxs-lookup"><span data-stu-id="13f13-196"><b>Recommended usage:</b> If your app uses secondary text of AltMedium color with a text size of 18px or larger, you can place these more translucent 70% acrylic resources behind the text.</span></span> <span data-ttu-id="13f13-197">これらのリソースは、アプリの最上部にある水平方向のナビゲーション領域やコマンド実行領域で使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f13-197">We recommend using these resources in your app's top horizontal navigation and commanding areas.</span></span>  </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="13f13-198">SystemControlChromeHighAcrylicWindowMediumBrush、SystemControlChromeHighAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-198">SystemControlChromeHighAcrylicWindowMediumBrush, SystemControlChromeHighAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="13f13-199">SystemControlChromeMediumAcrylicWindowMediumBrush、SystemControlChromeMediumAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-199">SystemControlChromeMediumAcrylicWindowMediumBrush, SystemControlChromeMediumAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="13f13-200">SystemControlChromeMediumLowAcrylicWindowMediumBrush、SystemControlChromeMediumLowAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-200">SystemControlChromeMediumLowAcrylicWindowMediumBrush, SystemControlChromeMediumLowAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="13f13-201">SystemControlBaseHighAcrylicWindowMediumBrush、SystemControlBaseHighAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-201">SystemControlBaseHighAcrylicWindowMediumBrush, SystemControlBaseHighAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="13f13-202">SystemControlBaseMediumLowAcrylicWindowMediumBrush、SystemControlBaseMediumLowAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-202">SystemControlBaseMediumLowAcrylicWindowMediumBrush, SystemControlBaseMediumLowAcrylicElementMediumBrush</span></span> <br/> <span data-ttu-id="13f13-203">SystemControlAltMediumLowAcrylicWindowMediumBrush、SystemControlAltMediumLowAcrylicElementMediumBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-203">SystemControlAltMediumLowAcrylicWindowMediumBrush, SystemControlAltMediumLowAcrylicElementMediumBrush</span></span>  </td>
        <td align="center"> <span data-ttu-id="13f13-204">60%</span><span class="sxs-lookup"><span data-stu-id="13f13-204">60%</span></span> </td>
        <td> <span data-ttu-id="13f13-205">ChromeHigh</span><span class="sxs-lookup"><span data-stu-id="13f13-205">ChromeHigh</span></span> <br/><br/> <span data-ttu-id="13f13-206">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="13f13-206">ChromeMedium</span></span> <br/><br/> <span data-ttu-id="13f13-207">ChromeMediumLow</span><span class="sxs-lookup"><span data-stu-id="13f13-207">ChromeMediumLow</span></span> <br/><br/> <span data-ttu-id="13f13-208">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="13f13-208">BaseHigh</span></span> <br/><br/> <span data-ttu-id="13f13-209">BaseLow</span><span class="sxs-lookup"><span data-stu-id="13f13-209">BaseLow</span></span> <br/><br/> <span data-ttu-id="13f13-210">AltMediumLow</span><span class="sxs-lookup"><span data-stu-id="13f13-210">AltMediumLow</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="13f13-211"><b>推奨する使用方法:</b> プライマリ テキストの色が AltHigh で、このテキストのみをアクリルの上に配置する場合は、これらの 60% のリソースを利用できます。</span><span class="sxs-lookup"><span data-stu-id="13f13-211"><b>Recommended usage:</b> When placing only primary text of AltHigh color over acrylic, your app can utilize these 60% resources.</span></span> <span data-ttu-id="13f13-212">アプリの<a href="../controls-and-patterns/navigationview.md">垂直方向のナビゲーション ウィンドウ</a> (ハンバーガー メニュー) を描画するときは、60% のアクリルを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f13-212">We recommend painting your app's <a href="../controls-and-patterns/navigationview.md">vertical navigation pane</a>, i.e. hamburger menu, with 60% acrylic.</span></span> </td>
    </tr>
</table>

<span data-ttu-id="13f13-213">中間色のアクリルに加え、ユーザーが指定したアクセント カラーを使用してアクリルに濃淡を付けるリソースも追加しました。</span><span class="sxs-lookup"><span data-stu-id="13f13-213">In addition to color-neutral acrylic, we've also added resources that tint acrylic using the user-specified accent color.</span></span> <span data-ttu-id="13f13-214">色が付いたアクリルは慎重に使用してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-214">We recommend using colored acrylic sparingly.</span></span> <span data-ttu-id="13f13-215">提供されている dark1 と dark2 のバリアントを使用する場合、濃色テーマのテキストの色と調和するように、白または明るい色のテキストをこれらのリソース上に配置してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-215">For the dark1 and dark2 variants provided, place white or light-colored text consistent with dark theme text color over these resources.</span></span>
<table>
    <tr>
        <th align="center"><span data-ttu-id="13f13-216">リソース キー</span><span class="sxs-lookup"><span data-stu-id="13f13-216">Resource key</span></span></th>
        <th align="center"><span data-ttu-id="13f13-217">濃淡の不透明度</span><span class="sxs-lookup"><span data-stu-id="13f13-217">Tint opacity</span></span></th>
        <th align="center"><a href="color.md"><span data-ttu-id="13f13-218">濃淡とフォールバックの色</span><span class="sxs-lookup"><span data-stu-id="13f13-218">Tint and Fallback colors</span></span></a> </th>
    </tr>
    <tr>
        <td> <span data-ttu-id="13f13-219">SystemControlAccentAcrylicWindowAccentMediumHighBrush、SystemControlAccentAcrylicElementAccentMediumHighBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-219">SystemControlAccentAcrylicWindowAccentMediumHighBrush, SystemControlAccentAcrylicElementAccentMediumHighBrush</span></span>  </td>
        <td align="center"> <span data-ttu-id="13f13-220">70%</span><span class="sxs-lookup"><span data-stu-id="13f13-220">70%</span></span> </td>
        <td> <span data-ttu-id="13f13-221">SystemAccentColor</span><span class="sxs-lookup"><span data-stu-id="13f13-221">SystemAccentColor</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="13f13-222">SystemControlAccentDark1AcrylicWindowAccentDark1Brush、SystemControlAccentDark1AcrylicElementAccentDark1Brush</span><span class="sxs-lookup"><span data-stu-id="13f13-222">SystemControlAccentDark1AcrylicWindowAccentDark1Brush, SystemControlAccentDark1AcrylicElementAccentDark1Brush</span></span>  </td>
        <td align="center"> <span data-ttu-id="13f13-223">80%</span><span class="sxs-lookup"><span data-stu-id="13f13-223">80%</span></span> </td>
        <td> <span data-ttu-id="13f13-224">SystemAccentColorDark1</span><span class="sxs-lookup"><span data-stu-id="13f13-224">SystemAccentColorDark1</span></span> </td>
    </tr>
    <tr>
        <td> <span data-ttu-id="13f13-225">SystemControlAccentDark2AcrylicWindowAccentDark2MediumHighBrush、SystemControlAccentDark2AcrylicElementAccentDark2MediumHighBrush</span><span class="sxs-lookup"><span data-stu-id="13f13-225">SystemControlAccentDark2AcrylicWindowAccentDark2MediumHighBrush, SystemControlAccentDark2AcrylicElementAccentDark2MediumHighBrush</span></span>  </td>
        <td align="center"> <span data-ttu-id="13f13-226">70%</span><span class="sxs-lookup"><span data-stu-id="13f13-226">70%</span></span> </td>
        <td> <span data-ttu-id="13f13-227">SystemAccentColorDark2</span><span class="sxs-lookup"><span data-stu-id="13f13-227">SystemAccentColorDark2</span></span> </td>
    </tr>
</table>


<span data-ttu-id="13f13-228">特定のサーフェスを塗りつぶすには、上記のテーマ リソースのいずれかを、他のブラシ リソースを適用する要素の背景に適用します。</span><span class="sxs-lookup"><span data-stu-id="13f13-228">To paint a specific surface, apply one of the above theme resources to element backgrounds just as you would apply any other brush resource.</span></span>

```xaml
<Grid Background="{ThemeResource SystemControlAcrylicElementBrush}">
```

## <a name="custom-acrylic-brush"></a><span data-ttu-id="13f13-229">カスタム アクリル ブラシ</span><span class="sxs-lookup"><span data-stu-id="13f13-229">Custom acrylic brush</span></span>
<span data-ttu-id="13f13-230">色の濃淡をアプリのアクリルに加えて、ブランドを表示したり、ページ上にある他の要素と視覚的にバランスをとったりすることができます。</span><span class="sxs-lookup"><span data-stu-id="13f13-230">You may choose to add a color tint to your app’s acrylic to show branding or provide visual balance with other elements on the page.</span></span> <span data-ttu-id="13f13-231">グレースケール以外の色を表示するには、次のプロパティを使って、独自のアクリル ブラシを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="13f13-231">To show color rather than greyscale, you’ll need to define your own acrylic brushes using the following properties.</span></span>
 - <span data-ttu-id="13f13-232">**TintColor**: 色/濃淡のオーバーレイ レイヤーです。</span><span class="sxs-lookup"><span data-stu-id="13f13-232">**TintColor**: the color/tint overlay layer.</span></span> <span data-ttu-id="13f13-233">RGB の色の値とアルファ チャネルの不透明度の両方を指定することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-233">Consider specifying both the RGB color value and alpha channel opacity.</span></span>
 - <span data-ttu-id="13f13-234">**TintOpacity**: 濃淡レイヤーの不透明度です。</span><span class="sxs-lookup"><span data-stu-id="13f13-234">**TintOpacity**: the opacity of the tint layer.</span></span> <span data-ttu-id="13f13-235">異なる色がより魅力的に他の translucencies を表示することがありますが、開始点として 80% の不透明度お勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f13-235">We recommend 80% opacity as a starting point, although different colors may look more compelling at other translucencies.</span></span>
 - <span data-ttu-id="13f13-236">**BackgroundSource**: 背景アクリルまたはアプリ内アクリルのどちらを使用するかを指定するフラグです。</span><span class="sxs-lookup"><span data-stu-id="13f13-236">**BackgroundSource**: the flag to specify whether you want background or in-app acrylic.</span></span>
 - <span data-ttu-id="13f13-237">**FallbackColor**: 単色のバッテリー節約機能のアクリルに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="13f13-237">**FallbackColor**: the solid color that replaces acrylic in Battery Saver.</span></span> <span data-ttu-id="13f13-238">背景アクリルでは、フォールバックの色は、アプリが作業中のデスクトップ ウィンドウにない場合、またはアプリが電話や Xbox 上で実行されている場合にもアクリルと置き換わります。</span><span class="sxs-lookup"><span data-stu-id="13f13-238">For background acrylic, fallback color also replaces acrylic when your app isn’t in the active desktop window or when the app is running on phone and Xbox.</span></span>

![淡色テーマのアクリルの見本](images/CustomAcrylic_Swatches_LightTheme.png)

![濃色テーマのアクリルの見本](images/CustomAcrylic_Swatches_DarkTheme.png)

<span data-ttu-id="13f13-241">アクリル ブラシを追加するには、濃色テーマ、淡色テーマ、ハイ コントラスト テーマの 3 つのリソースを定義します。</span><span class="sxs-lookup"><span data-stu-id="13f13-241">To add an acrylic brush, define the three resources for dark, light and high contrast themes.</span></span> <span data-ttu-id="13f13-242">ハイ コントラストでは、濃色/淡色の AcrylicBrush と同じ x:Key で SolidColorBrush を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f13-242">Note that in high contrast, we recommend using a SolidColorBrush with the same x:Key as the dark/light AcrylicBrush.</span></span>

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

<span data-ttu-id="13f13-243">次のサンプルは、コードで AcrylicBrush を宣言する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="13f13-243">The following sample shows how to declare AcrylicBrush in code.</span></span> <span data-ttu-id="13f13-244">アプリが複数の OS ターゲットをサポートする場合は、この API がユーザーのコンピューターで利用できることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-244">If your app supports multiple OS targets, be sure to check that this API is available on the user’s machine.</span></span>

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

## <a name="extend-acrylic-into-the-title-bar"></a><span data-ttu-id="13f13-245">アクリルをタイトル バーに拡張する</span><span class="sxs-lookup"><span data-stu-id="13f13-245">Extend acrylic into the title bar</span></span>

<span data-ttu-id="13f13-246">アプリのウィンドウを滑らかな外観にするには、タイトル バー領域にアクリルを使います。</span><span class="sxs-lookup"><span data-stu-id="13f13-246">To give your app's window a seamless look, you can use acrylic in the title bar area.</span></span> <span data-ttu-id="13f13-247">この例では、[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar) オブジェクトの [ButtonBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar.ButtonBackgroundColor) および [ButtonInactiveBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar.ButtonInactiveBackgroundColor) プロパティを [Colors.Transparent](https://docs.microsoft.com/uwp/api/Windows.UI.Colors.Transparent) に設定することで、アクリルをタイトル バーに拡張します。</span><span class="sxs-lookup"><span data-stu-id="13f13-247">This example extends acrylic into the title bar by setting the [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar) object's [ButtonBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar.ButtonBackgroundColor) and [ButtonInactiveBackgroundColor](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.ApplicationViewTitleBar.ButtonInactiveBackgroundColor) properties to [Colors.Transparent](https://docs.microsoft.com/uwp/api/Windows.UI.Colors.Transparent).</span></span> 

```csharp
/// Extend acrylic into the title bar. 
private void ExtendAcrylicIntoTitleBar()
{
    CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
    ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
    titleBar.ButtonBackgroundColor = Colors.Transparent;
    titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
}
```

<span data-ttu-id="13f13-248">このコードは、ここに示すようにアプリの [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) メソッド (_App.xaml.cs_) 内の [Window.Activate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.Activate) の呼び出しの後か、アプリの最初のページに配置できます。</span><span class="sxs-lookup"><span data-stu-id="13f13-248">This code can be placed in your app's [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) method (_App.xaml.cs_), after the call to [Window.Activate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.Activate), as shown here, or in your app's first page.</span></span> 


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
        ExtendAcrylicIntoTitleBar();
    }
}
```

<span data-ttu-id="13f13-249">また、通常はタイトル バーに自動的に表示されるアプリのタイトルを、`CaptionTextBlockStyle` を使用した TextBlock で描画する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="13f13-249">In addition, you'll need to draw your app's title, which normally appears automatically in the title bar, with a TextBlock using `CaptionTextBlockStyle`.</span></span> <span data-ttu-id="13f13-250">詳しくは、「[タイトル バーのカスタマイズ](../shell/title-bar.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="13f13-250">For more info, see [Title bar customization](../shell/title-bar.md).</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="13f13-251">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="13f13-251">Do's and don'ts</span></span>
* <span data-ttu-id="13f13-252">アクリルは、ナビゲーション ウィンドウなど、アプリのプライマリ サーフェス以外のサーフェスで背景素材として使用してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-252">Do use acrylic as the background material of non-primary app surfaces like navigation panes.</span></span>
* <span data-ttu-id="13f13-253">シームレスなエクスペリエンスを実現するには、アプリの周囲とわずかにブレンドするようにして、アクリルをアプリの 1 つ以上の端にまで拡張してください。</span><span class="sxs-lookup"><span data-stu-id="13f13-253">Do extend acrylic to at least one edge of your app to provide a seamless experience by subtly blending with the app’s surroundings.</span></span>
* <span data-ttu-id="13f13-254">アプリのバック グラウンドの大規模なサーフェスにデスクトップ arylic を配置しないでください - この一時的なサーフェスに主に使用されているアクリルの概念的モデルを中断します。</span><span class="sxs-lookup"><span data-stu-id="13f13-254">Don't put desktop arylic on large background surfaces of your app - this breaks the mental model of acrylic being used primarily for transient surfaces.</span></span>
* <span data-ttu-id="13f13-255">アプリ内アクリルと背景アクリルは、継ぎ目部分での視覚的なテンションを回避するために、隣接するようには配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="13f13-255">Don’t place in-app and background acrylics directly adjacent to avoid visual tension at the seams.</span></span>
* <span data-ttu-id="13f13-256">複数のアクリル ウィンドウを、同じ濃淡や不透明度で隣接するように配置しないでください。このようにすると、望ましくない継ぎ目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="13f13-256">Don't place multiple acrylic panes with the same tint and opacity next to each other because this results in an undesirable visible seam.</span></span>
* <span data-ttu-id="13f13-257">アクリル サーフェスの上には、アクセント カラーのテキストを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="13f13-257">Don’t place accent-colored text over acrylic surfaces.</span></span>

## <a name="how-we-designed-acrylic"></a><span data-ttu-id="13f13-258">アクリルをどのように設計したか</span><span class="sxs-lookup"><span data-stu-id="13f13-258">How we designed acrylic</span></span>

<span data-ttu-id="13f13-259">アクリルの主要なコンポーネントを微調整して、ユニークな外観とプロパティを作成しました。</span><span class="sxs-lookup"><span data-stu-id="13f13-259">We fine-tuned acrylic’s key components to arrive at its unique appearance and properties.</span></span> <span data-ttu-id="13f13-260">透明度、ぼかし、ノイズ平坦なサーフェスに視覚的な奥行きとディメンションを追加するを利用しました。</span><span class="sxs-lookup"><span data-stu-id="13f13-260">We started with translucency, blur and noise to add visual depth and dimension to flat surfaces.</span></span> <span data-ttu-id="13f13-261">除外ブレンド モード レイヤーを追加して、アクリルの背景に配置される UI のコントラストと見やすさを確保しました。</span><span class="sxs-lookup"><span data-stu-id="13f13-261">We added an exclusion blend mode layer to ensure contrast and legibility of UI placed on an acrylic background.</span></span> <span data-ttu-id="13f13-262">最後に、ユーザーの個性を反映できるように、色の濃淡を追加しました。</span><span class="sxs-lookup"><span data-stu-id="13f13-262">Finally, we added color tint for personalization opportunities.</span></span> <span data-ttu-id="13f13-263">次のレイヤーを組み合わせることで、新しくて使いやすい素材が生みだされます。</span><span class="sxs-lookup"><span data-stu-id="13f13-263">In concert these layers add up to a fresh, usable material.</span></span>

![アクリルのレシピ](images/AcrylicRecipe_Diagram.jpg)
<br/><span data-ttu-id="13f13-265">アクリルのレシピ: 背景、ぼかし、除外ブレンド、色/濃淡のオーバーレイ、ノイズ</span><span class="sxs-lookup"><span data-stu-id="13f13-265">The acrylic recipe: background, blur, exclusion blend, color/tint overlay, noise</span></span>


## <a name="get-the-sample-code"></a><span data-ttu-id="13f13-266">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="13f13-266">Get the sample code</span></span>

- <span data-ttu-id="13f13-267">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="13f13-267">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="13f13-268">関連記事</span><span class="sxs-lookup"><span data-stu-id="13f13-268">Related articles</span></span>

[**<span data-ttu-id="13f13-269">表示ハイライト</span><span class="sxs-lookup"><span data-stu-id="13f13-269">Reveal highlight</span></span>**](reveal.md)