---
author: serenaz
Description: An overview of the universal design features that are included in every UWP app to help you build apps that scale beautifully across a range of devices.
title: ユニバーサル Windows プラットフォーム (UWP) アプリ設計の概要 (Windows アプリ)
ms.assetid: 50A5605E-3A91-41DB-800A-9180717C1E86
ms.author: sezhen
ms.date: 12/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d0527866777c7b5dbbc10697bb313d664f4555fa
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1817280"
---
#  <a name="introduction-to-uwp-app-design"></a><span data-ttu-id="501e8-103">UWP アプリ設計の概要</span><span class="sxs-lookup"><span data-stu-id="501e8-103">Introduction to UWP app design</span></span>

<span data-ttu-id="501e8-104">ユニバーサル Windows プラットフォーム (UWP) の設計ガイダンスは、美しく洗練されたアプリを設計および構築するのに役立つリソースです。</span><span class="sxs-lookup"><span data-stu-id="501e8-104">The Universal Windows Platform (UWP) design guidance is a resource to help you design and build beautiful, polished apps.</span></span>

<span data-ttu-id="501e8-105">これは規範的な規則の一覧ではなく、進化する [Fluent Design System](../fluent-design-system/index.md)、およびアプリ構築コミュニティのニーズに適応するように設計された生きたドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="501e8-105">It's not a list of prescriptive rules - it's a living document, designed to adapt to our evolving [Fluent Design System](../fluent-design-system/index.md) as well as the needs of our app-building community.</span></span>

<span data-ttu-id="501e8-106">この記事では、あらゆる UWP アプリに含まれているユニバーサル デザイン機能の概要を説明します。これらの機能により、さまざまなデバイス間で美しくスケーリングされるユーザー インターフェイス (UI) を構築できます。</span><span class="sxs-lookup"><span data-stu-id="501e8-106">This introduction provides an overview of the universal design features that are included in every UWP app, helping you build user interfaces (UI) that scale beautifully across a range of devices.</span></span>

## <a name="video-summary"></a><span data-ttu-id="501e8-107">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="501e8-107">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Designing-Universal-Windows-Platform-apps/player]

## <a name="effective-pixels-and-scaling"></a><span data-ttu-id="501e8-108">有効ピクセルとスケーリング</span><span class="sxs-lookup"><span data-stu-id="501e8-108">Effective pixels and scaling</span></span>

<span data-ttu-id="501e8-109">UWP アプリは、[UWP アプリをサポートするすべてのデバイス](../devices/index.md)で読みやすく、操作しやすいように、コントロール、フォント、およびその他の UI 要素のサイズを自動的に調整します。</span><span class="sxs-lookup"><span data-stu-id="501e8-109">UWP apps automatically adjust the size of controls, fonts, and other UI elements so that they are legible and easy to interact with on [all devices that support UWP apps](../devices/index.md).</span></span>

<span data-ttu-id="501e8-110">デバイスでアプリを実行するとき、システムでは、UI 要素を画面に表示する方法を正規化するアルゴリズムを使います。</span><span class="sxs-lookup"><span data-stu-id="501e8-110">When your app runs on a device, the system uses an algorithm to normalize the way UI elements display on the screen.</span></span> <span data-ttu-id="501e8-111">このスケーリング アルゴリズムでは、視聴距離と画面の密度 (ピクセル/インチ) を考慮して、体感的なサイズを最適化します (物理的なサイズではありません)。</span><span class="sxs-lookup"><span data-stu-id="501e8-111">This scaling algorithm takes into account viewing distance and screen density (pixels per inch) to optimize for perceived size (rather than physical size).</span></span> <span data-ttu-id="501e8-112">スケーリング アルゴリズムによって、10 フィート離れた Surface Hub における 24 ピクセルのフォントが、数インチ離れた 5 インチ サイズの電話における 24 ピクセルのフォントと同じようにユーザーに読みやすい状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-112">The scaling algorithm ensures that a 24 px font on Surface Hub 10 feet away is just as legible to the user as a 24 px font on 5" phone that's a few inches away.</span></span>

![さまざまなデバイスの視聴距離](images/1910808-hig-uap-toolkit-03.png)

<span data-ttu-id="501e8-114">スケーリング システムのしくみのため、UWP アプリをデザインするときには、実際の物理ピクセルではなく、有効ピクセルでデザインすることになります。</span><span class="sxs-lookup"><span data-stu-id="501e8-114">Because of how the scaling system works, when you design your UWP app, you're designing in effective pixels, not actual physical pixels.</span></span> <span data-ttu-id="501e8-115">有効ピクセル (epx) は仮想的な測定単位で、画面の密度とは無関係にレイアウトのサイズと間隔を表すために使用されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-115">Effective pixels (epx) are a virtual unit of measurement, and they're used to express layout dimensions and spacing, independent of screen density.</span></span> <span data-ttu-id="501e8-116">(ガイドラインでは、epx、ep、および px を区別しないで使用しています。)</span><span class="sxs-lookup"><span data-stu-id="501e8-116">(In our guidelines, epx, ep, and px are used interchangeably.)</span></span>

<span data-ttu-id="501e8-117">設計時には、ピクセル密度と実際の画面解像度を無視できます。</span><span class="sxs-lookup"><span data-stu-id="501e8-117">You can ignore the pixel density and the actual screen resolution when designing.</span></span> <span data-ttu-id="501e8-118">その代わり、サイズ クラスの有効な解像度 (有効ピクセル単位の解像度) が向上するように設計します (詳しくは、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="501e8-118">Instead, design for the effective resolution (the resolution in effective pixels) for a size class (for details, see the [Screen sizes and breakpoints article](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)).</span></span>

> [!TIP]
> <span data-ttu-id="501e8-119">イメージ編集プログラムで画面のモックアップを作成するときは、DPI を 72 に設定し、画像サイズを、対象のサイズ クラスで有効な解像度に設定します</span><span class="sxs-lookup"><span data-stu-id="501e8-119">When creating screen mockups in image editing programs, set the DPI to 72 and set the image dimensions to the effective resolution for the size class you're targeting.</span></span> <span data-ttu-id="501e8-120">サイズ クラスと有効な解像度の一覧については、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-120">For a list of size classes and effective resolutions, see the [Screen sizes and breakpoints article](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>


## <a name="layout"></a><span data-ttu-id="501e8-121">レイアウト</span><span class="sxs-lookup"><span data-stu-id="501e8-121">Layout</span></span>

### <a name="margins-spacing-and-positioning"></a><span data-ttu-id="501e8-122">余白、間隔、および配置</span><span class="sxs-lookup"><span data-stu-id="501e8-122">Margins, spacing, and positioning</span></span> 
![グリッド](images/4epx.png)

<span data-ttu-id="501e8-124">システムによるアプリの UI のスケーリングは、4 の倍数単位で行われます。</span><span class="sxs-lookup"><span data-stu-id="501e8-124">When the system scales your app's UI, it does so by multiples of 4.</span></span>

<span data-ttu-id="501e8-125">そのため、UI 要素のサイズ、余白、および位置は、**必ず 4 epx の倍数になります**。</span><span class="sxs-lookup"><span data-stu-id="501e8-125">As a result, the sizes, margins, and positions of **UI elements should always be in multiples of 4 epx**.</span></span> <span data-ttu-id="501e8-126">結果として、ピクセル全体で調整することにより最適なレンダリングが得られます。</span><span class="sxs-lookup"><span data-stu-id="501e8-126">This results in the best rendering by aligning with whole pixels.</span></span> <span data-ttu-id="501e8-127">UI 要素に鮮明で鋭いエッジがあることも保証されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-127">It also ensures that UI elements have crisp, sharp edges.</span></span> 

<span data-ttu-id="501e8-128">この要件はテキストには必要ありません。テキストのサイズと位置に制限はありません。</span><span class="sxs-lookup"><span data-stu-id="501e8-128">Note that text doesn't have this requirement; text can have any size and position.</span></span> <span data-ttu-id="501e8-129">テキストを他の UI 要素と揃える方法のガイダンスについては、「[UWP 文字体裁ガイド](../style/typography.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-129">For guidance on how to align text with other UI elements, see the [UWP Typography Guide](../style/typography.md).</span></span>

![グリッドでのスケーリング](images/epx-4pixelgood.png)

### <a name="layout-patterns"></a><span data-ttu-id="501e8-131">レイアウト パターン</span><span class="sxs-lookup"><span data-stu-id="501e8-131">Layout patterns</span></span>

![一般的なレイアウト パターン](images/page-components.png)

<span data-ttu-id="501e8-133">ユーザー インターフェイスは、次の 3 種類の要素で構成されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-133">The user interface is made up of three types of elements:</span></span> 
1. <span data-ttu-id="501e8-134">**ナビゲーション要素**は、表示するコンテンツをユーザーが選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="501e8-134">**Navigation elements** help users choose the content they want to display.</span></span> <span data-ttu-id="501e8-135">「[ナビゲーションの基本](navigation-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-135">See [navigation basics](navigation-basics.md).</span></span>
2. <span data-ttu-id="501e8-136">**コマンド要素**は、操作、保存、コンテンツの共有などの操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="501e8-136">**Command  elements** initiate actions, such as manipulating, saving, or sharing content.</span></span> <span data-ttu-id="501e8-137">「[コマンドの基本](commanding-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-137">See [command basics](commanding-basics.md).</span></span>
3. <span data-ttu-id="501e8-138">**コンテンツ要素**は、アプリのコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="501e8-138">**Content elements** display the app's content.</span></span> <span data-ttu-id="501e8-139">「[コンテンツの基本](content-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-139">See [content basics](content-basics.md).</span></span>

### <a name="adaptive-behavior"></a><span data-ttu-id="501e8-140">アダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="501e8-140">Adaptive behavior</span></span>
![電話とデスクトップのアダプティブ動作](../controls-and-patterns/images/patterns_masterdetail.png)

<span data-ttu-id="501e8-142">アプリの UI はすべての Windows デバイスで読みやすく使用可能ですが、特定のデバイスや画面サイズ向けにアプリの UI をカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="501e8-142">While your app's UI will be legible and usable on all Windows-powered devices, you might want to customize your app's UI for specific devices and screen sizes.</span></span> <span data-ttu-id="501e8-143">詳しいガイダンスについては、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」と「[レスポンシブ デザイン テクニック](../layout/responsive-design.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-143">For more specific guidance, see [screen sizes and breakpoints](../layout/screen-sizes-and-breakpoints-for-responsive-design.md) and [responsive design techniques](../layout/responsive-design.md).</span></span>

## <a name="type"></a><span data-ttu-id="501e8-144">書体</span><span class="sxs-lookup"><span data-stu-id="501e8-144">Type</span></span>

<span data-ttu-id="501e8-145">既定では、UWP アプリは **Segoe UI** フォントを使用します。UWP 書体見本には、すべての表示サイズで最も効率的なアプローチが得られるように、7 つのクラスの文字体裁が含まれています。</span><span class="sxs-lookup"><span data-stu-id="501e8-145">By default, UWP apps use the **Segoe UI** font, and the UWP type ramp includes seven classes of typography, striving for the most efficient approach across all display sizes.</span></span> 

![書体見本](images/type-ramp.png)

<span data-ttu-id="501e8-147">書体見本について詳しくは、「[UWP 文字体裁ガイド](../style/typography.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-147">For details on the type ramp, see the [UWP Typography Guide](../style/typography.md).</span></span> <span data-ttu-id="501e8-148">アプリでさまざまなレベルの UWP 書体見本を使用する方法については、「[テーマ リソース](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-148">To learn how to use the different levels of the UWP type ramp in your app, see [theme resources](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp).</span></span>

## <a name="color"></a><span data-ttu-id="501e8-149">色</span><span class="sxs-lookup"><span data-stu-id="501e8-149">Color</span></span>

<span data-ttu-id="501e8-150">色を使うことで、ユーザーに直感的に情報を伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="501e8-150">Color provides an intuitive way of communicating information to users.</span></span> <span data-ttu-id="501e8-151">対話的に通知したり、ユーザーの操作にフィードバックを返したり、状態情報を伝えたり、インターフェイスに連続感を与えたりするために色を使用できます。</span><span class="sxs-lookup"><span data-stu-id="501e8-151">It can be used to signal interactivity, give feedback to user actions, convey state information, and give your interface a sense of visual continuity.</span></span> 

<span data-ttu-id="501e8-152">Windows 10 では、シェルと UWP アプリ全体に適用される、48 色の共有ユニバーサル カラー パレットが提供されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-152">Windows 10 provides a shared universal color palette of 48 colors, which is applied across the shell and UWP apps.</span></span> 

![ユニバーサル windows カラー パレット](images/colors.png)

<span data-ttu-id="501e8-154">システムは、システムのアクセント カラーを使用して UWP アプリに自動的に色を適用します。</span><span class="sxs-lookup"><span data-stu-id="501e8-154">The system automatically applies color to your UWP app with the system accent color.</span></span> <span data-ttu-id="501e8-155">ユーザーが [設定] でカラー パレットからアクセント カラーを選択すると、その色がシステム テーマの一部として表示されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-155">When users choose an accent color from the color palette in their Settings, the color appears as part of their system theme.</span></span> <span data-ttu-id="501e8-156">ユーザーの基本設定によっては、スタート画面、スタート タイル、タスク バー、およびタイトル バーにもシステムのアクセント カラーを表示できます。</span><span class="sxs-lookup"><span data-stu-id="501e8-156">Depending on user preferences, the system accent color can also show on Start, Start Tiles, taskbar, and title bars.</span></span> 

![設定でアクセント カラーを選択](images/selectcolor.png)

<span data-ttu-id="501e8-158">UWP アプリ内では、コモン コントロール内のハイパーリンクと選択した状態にシステムのアクセント カラーが反映されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-158">Within your UWP app, hyperlinks and selected states within common controls will reflect the system accent color.</span></span>

![コントロールでのシステムのアクセント カラー](images/accentcolor.png)

<span data-ttu-id="501e8-160">UWP アプリでは、[軽量なスタイル設定](../controls-and-patterns/xaml-styles.md#lightweight-styling)を使用するか、[カスタム コントロール](../controls-and-patterns/control-templates.md)を作成することで、コントロールでの表示からシステムのアクセント カラーを上書きできます。</span><span class="sxs-lookup"><span data-stu-id="501e8-160">UWP apps can override the system accent color from displaying in controls by using [lightweight styling](../controls-and-patterns/xaml-styles.md#lightweight-styling) or by creating [custom controls](../controls-and-patterns/control-templates.md).</span></span>

<span data-ttu-id="501e8-161">UWP アプリでの色の使用に関するその他のガイダンスについては、[色](../style/color.md)の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-161">For additional guidance on using color in your UWP app, see the [Color](../style/color.md) article.</span></span>

### <a name="themes"></a><span data-ttu-id="501e8-162">テーマ</span><span class="sxs-lookup"><span data-stu-id="501e8-162">Themes</span></span>

<span data-ttu-id="501e8-163">ユーザーは、淡色テーマ、濃色テーマ、またはハイ コントラストのテーマから選択できます。</span><span class="sxs-lookup"><span data-stu-id="501e8-163">Users can choose between a light, dark, or high contrast theme.</span></span> <span data-ttu-id="501e8-164">ユーザーのテーマの優先順位に基づいてアプリの外観を変更するか、無効にするかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="501e8-164">You can choose to alter the look of your app based on the user’s theme preference, or to opt out.</span></span>

<span data-ttu-id="501e8-165">淡色テーマは、生産性向上が必要なタスクや読み取り作業に最適です。</span><span class="sxs-lookup"><span data-stu-id="501e8-165">The light theme is best suited to productivity tasks and reading.</span></span>

<span data-ttu-id="501e8-166">濃色テーマを使用すると、メディアを中心とするアプリや多数のビデオや画像が含まれるシナリオで、コンテンツのコントラストを上げることができます。</span><span class="sxs-lookup"><span data-stu-id="501e8-166">The dark theme allows for more visible contrasts in media-centric apps and scenarios that include an abundance of videos or imagery.</span></span> <span data-ttu-id="501e8-167">これらのシナリオでは、主な作業は読み取りより映画の視聴であり、低光量の周囲条件下で行われると考えられます。</span><span class="sxs-lookup"><span data-stu-id="501e8-167">In these scenarios, the primary task is more likely to be movie-watching than reading, and to take place under low-light ambient conditions.</span></span>

![淡色テーマと濃色テーマで表示された電卓](images/light-dark.png)

<span data-ttu-id="501e8-169">ハイ コントラスト テーマは、少ない数のコントラスト カラーで構成されるパレットを使い、インターフェイスを見やすくします。</span><span class="sxs-lookup"><span data-stu-id="501e8-169">The high contrast theme uses a small palette of contrasting colors that makes the interface easier to see.</span></span>
![淡色テーマと黒のハイ コントラスト テーマで表示された電卓。](../accessibility/images/high-contrast-calculators.png)


<span data-ttu-id="501e8-171">アプリでのテーマと UWP 色見本の使用について詳しくは、「[テーマ リソース](../controls-and-patterns/xaml-theme-resources.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-171">For more information about using themes and the UWP color ramp in your app, see [theme resources](../controls-and-patterns/xaml-theme-resources.md).</span></span>

## <a name="icons"></a><span data-ttu-id="501e8-172">アイコン</span><span class="sxs-lookup"><span data-stu-id="501e8-172">Icons</span></span>
![アイコン](images/icons.png)

<span data-ttu-id="501e8-174">アイコンは日常生活で染み込んだ視覚言語です。</span><span class="sxs-lookup"><span data-stu-id="501e8-174">Icons are a type of visual language that have become engrained in our everyday lives.</span></span> <span data-ttu-id="501e8-175">アイコンを使うと、視覚的に説得力のある方法で概念や操作を表すことができ、画面領域を節約できます。アイコンは、デジタル ライフのナビゲーターとして機能します。</span><span class="sxs-lookup"><span data-stu-id="501e8-175">They let us express concepts and actions in a visually compelling way, save screen space, and serve as a way of navigating our digital life.</span></span> 

<span data-ttu-id="501e8-176">すべての UWP アプリは、[Segoe MDL2 フォント](../style/segoe-ui-symbol-font.md)でアイコンにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="501e8-176">All UWP apps have access to the icons in the [Segoe MDL2 font](../style/segoe-ui-symbol-font.md).</span></span> <span data-ttu-id="501e8-177">これらのアイコンは定着した形を使用しており、一般的で誰にでも簡単に識別しやすいものですが、片手で描いたように感じられる現代的な形に更新されています。</span><span class="sxs-lookup"><span data-stu-id="501e8-177">These icons rely on established forms that are familiar and easily identifiable to everyone, but they're also modernized to make them feel like they were drawn by one hand.</span></span>

<span data-ttu-id="501e8-178">独自のアイコンを作成する方法については、「[UWP アプリのアイコン](../style/icons.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-178">If you'd like to create your own icons, see [Icons for UWP apps](../style/icons.md).</span></span>

## <a name="tiles"></a><span data-ttu-id="501e8-179">タイル</span><span class="sxs-lookup"><span data-stu-id="501e8-179">Tiles</span></span>
![スタート メニューのタイル](images/tiles.png)

<span data-ttu-id="501e8-181">タイルは [スタート] メニューに表示され、アプリで何が行われるのかを簡単に示します。</span><span class="sxs-lookup"><span data-stu-id="501e8-181">Tiles are displayed in the Start menu, and they provide a glimpse of what's going on in your app.</span></span> <span data-ttu-id="501e8-182">タイルのパワーは、背後にあるコンテンツ、および提供するインテリジェンスと技術によるものです。</span><span class="sxs-lookup"><span data-stu-id="501e8-182">Their power comes from the content behind them, and the intelligence and craft with which they're offered up.</span></span> 

<span data-ttu-id="501e8-183">UWP アプリには 4 つのタイル サイズ (小、中、横長、大) があり、アプリのアイコンと ID でカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="501e8-183">UWP apps have four tile sizes (small, medium, wide, and large) that can be customized with the app's icon and identity.</span></span> <span data-ttu-id="501e8-184">UWP アプリのタイルのデザインに関するガイダンスについては、「[タイルとアイコン アセットのガイドライン](../shell/tiles-and-notifications/app-assets.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-184">For guidance on designing tiles for your UWP app, see [Guidelines for tile and icon assets](../shell/tiles-and-notifications/app-assets.md).</span></span>

## <a name="controls"></a><span data-ttu-id="501e8-185">コントロール</span><span class="sxs-lookup"><span data-stu-id="501e8-185">Controls</span></span>
![ボタン コントロール](images/1910808-hig-uap-toolkit-01.png)

<span data-ttu-id="501e8-187">UWP には、すべての Windows デバイスで適切に動作することが保証されている一連のコモン コントロールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="501e8-187">UWP provides a set of common controls that are guaranteed to work well on all Windows-powered devices.</span></span> <span data-ttu-id="501e8-188">これらのコントロールには、ボタンやテキスト要素などの単純なコントロールから、一連のデータとテンプレートからリストを生成する高度なコントロールまで、すべてのものが含まれます。</span><span class="sxs-lookup"><span data-stu-id="501e8-188">These controls include everything from simple controls, like buttons and text elements, to sophisticated controls that can generate lists from a set of data and a template.</span></span>

<span data-ttu-id="501e8-189">UWP コントロールは、システム テーマとアクセント カラーを自動的に反映し、すべての入力の種類に対応し、すべてのデバイスに合わせて拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-189">UWP controls automatically relect the system theme and accent color, work with all input types, and scale to all devices.</span></span> <span data-ttu-id="501e8-190">また、これらは高度にカスタマイズでき、コントロールの前景色を変更することも、外観を完全にカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="501e8-190">And they're highly customizable, too--you can change the foreground color of a control or completely customize it's appearance.</span></span> 

<span data-ttu-id="501e8-191">UWP コントロールとコントロールに基づいて作成できるパターンの全一覧については、「[コントロールとパターン](../controls-and-patterns/index.md)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-191">For a complete list of UWP controls and the patterns you can make from them, see the [controls and patterns section](../controls-and-patterns/index.md).</span></span>

## <a name="input"></a><span data-ttu-id="501e8-192">入力</span><span class="sxs-lookup"><span data-stu-id="501e8-192">Input</span></span>
![入力](../input/images/input-interactions/icons-inputdevices03.png)

<span data-ttu-id="501e8-194">UWP アプリではスマート操作が使用されます。</span><span class="sxs-lookup"><span data-stu-id="501e8-194">UWP apps rely on smart interactions.</span></span> <span data-ttu-id="501e8-195">クリックの発生元がマウスか、スタイラスか、指によるタップかを認識または定義しなくても、クリック操作に対応したデザインを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="501e8-195">You can design around a click interaction without having to know or define whether the click comes from a mouse, a stylus, or a tap of a finger.</span></span> <span data-ttu-id="501e8-196">ただし、[特定の入力モードやデバイス](../input/input-primer.md)向けにアプリを設計することもできます。</span><span class="sxs-lookup"><span data-stu-id="501e8-196">However, you can also design your apps for [specific input modes and devices](../input/input-primer.md).</span></span>

## <a name="accessibility"></a><span data-ttu-id="501e8-197">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="501e8-197">Accessibility</span></span>
![包括的な設計の担当者](images/inclusive.png)

<span data-ttu-id="501e8-199">最後に重要な点として、アクセシビリティの目的は、アプリのエクスペリエンスをすべてのユーザーに開かれたものにすることです。</span><span class="sxs-lookup"><span data-stu-id="501e8-199">Last but not least, accessibility is about making your app's experience open to all users.</span></span> <span data-ttu-id="501e8-200">障碍のある人だけでなく、すべての人に関係します。</span><span class="sxs-lookup"><span data-stu-id="501e8-200">It's relevant to everyone, not just those with disabilities.</span></span> <span data-ttu-id="501e8-201">すべての人が、本当に包括的なユーザー エクスペリエンスの恩恵を受けます。すべてのユーザーに対してアプリを使いやすくする方法については、「[UWP アプリの操作性](../usability/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-201">Everyone can benefit from truly inclusive user experiences - see [usability for UWP apps](../usability/index.md) to see how to make your app easy to use for everyone.</span></span> <span data-ttu-id="501e8-202">視覚障碍、聴覚障碍、運動障碍を持つユーザーに関して、「[アクセシビリティ機能](../accessibility/accessibility-overview.md)」も検討してください。</span><span class="sxs-lookup"><span data-stu-id="501e8-202">You might also want to consider [accessibility features](../accessibility/accessibility-overview.md) for users with limited sight, hearing, and mobility.</span></span> 

<span data-ttu-id="501e8-203">アクセシビリティが最初から設計に組み込まれている場合は、[アプリをアクセシビリティ対応にする](../accessibility/accessibility-in-the-store.md)ことにほとんど時間と労力がかかりません。</span><span class="sxs-lookup"><span data-stu-id="501e8-203">If accessibility is built into your design from the start, then [making your app accessible](../accessibility/accessibility-in-the-store.md) should take very little extra time and effort.</span></span>

## <a name="tools-and-design-toolkits"></a><span data-ttu-id="501e8-204">ツールと設計ツールキット</span><span class="sxs-lookup"><span data-stu-id="501e8-204">Tools and design toolkits</span></span>
<span data-ttu-id="501e8-205">基本的な設計機能がわかったので、UWP アプリの設計を開始しましょう。</span><span class="sxs-lookup"><span data-stu-id="501e8-205">Now that you know about the basic design features, how about getting started with designing your UWP app?</span></span>

<span data-ttu-id="501e8-206">設計プロセスで役立つさまざまなツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="501e8-206">We provide a variety of tools to help your design process:</span></span>

* <span data-ttu-id="501e8-207">[設計ツールキットのページ](../downloads/index.md)をご覧ください。XD、Illustrator、Photoshop、Framer、Sketch の各ツールキット、および追加の設計ツールやフォントのダウンロードが提供されています。</span><span class="sxs-lookup"><span data-stu-id="501e8-207">See our [Design toolkits page](../downloads/index.md) for XD, Illustrator, Photoshop, Framer, and Sketch toolkits, as well as additional design tools and font downloads.</span></span> 

* <span data-ttu-id="501e8-208">コンピューターを設定して UWP アプリのコードを記述できるようにするには、「[作業の開始と準備](../../get-started/get-set-up.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-208">To get your machine set up to write code for UWP apps, see our [Get started &gt; Get set up](../../get-started/get-set-up.md) article.</span></span> 

* <span data-ttu-id="501e8-209">UWP の UI を実装する方法については、エンド ツー エンドの「[サンプル UWP アプリ](https://developer.microsoft.com/windows/samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-209">For inspiration on how to implement UI for UWP, take a look at our end-to-end [sample UWP apps](https://developer.microsoft.com/windows/samples).</span></span>

## <a name="next-fluent-design-system"></a><span data-ttu-id="501e8-210">次: Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="501e8-210">Next: Fluent Design System</span></span>
<span data-ttu-id="501e8-211">Fluent Design (Microsoft のデザイン システム) の背後にある原則や、UWP アプリに組み込むことができる多くの機能について確認する場合は、引き続き「[Fluent Design System](../fluent-design-system/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501e8-211">If you'd like to learn about the principles behind Fluent Design (Microsoft's design system) and see more features you can incorporate into your UWP app, continue on to [Fluent Design System](../fluent-design-system/index.md).</span></span>