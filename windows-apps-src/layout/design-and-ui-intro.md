---
author: mijacobs
Description: "この記事では、デザインの観点からユニバーサル Windows プラットフォーム (UWP) の機能、利点、要件について説明します。 無料で提供されるプラットフォーム、自由に使うことができるツールを紹介します。"
title: "ユニバーサル Windows プラットフォーム (UWP) アプリ設計の概要 (Windows アプリ)"
ms.assetid: 50A5605E-3A91-41DB-800A-9180717C1E86
label: Intro to UWP app design
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 8db6dbe00c20b6371ae7007f07e628d16467ea9d
ms.sourcegitcommit: 0d5b3daddb3ae74f91178c58e35cbab33854cb7f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
#  <a name="introduction-to-uwp-app-design"></a><span data-ttu-id="1056d-105">UWP アプリ設計の概要</span><span class="sxs-lookup"><span data-stu-id="1056d-105">Introduction to UWP app design</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="1056d-106">ユニバーサル Windows プラットフォーム (UWP) アプリは、電話からタブレット、PC まで、任意の Windows ベース デバイスで実行できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-106">A Universal Windows Platform (UWP) app can run on any Windows-based device, from your phone to your tablet or PC.</span></span> 

<span data-ttu-id="1056d-107">さまざまなデバイスでアプリが適切に表示されるようにデザインすることが重要な課題となります。</span><span class="sxs-lookup"><span data-stu-id="1056d-107">Designing an app that looks good on such a wide variety of devices can be a big challenge.</span></span> <span data-ttu-id="1056d-108">ユニバーサル Windows プラットフォーム (UWP) には、一連の組み込み機能とユニバーサルな構成要素が用意されており、さまざまなデバイス、画面、入力方式で十分に機能する UX を作成できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-108">Fortunately, the Universal Windows Platform (UWP) provides a set of built-in features and universal building blocks that help you create a UX that works well with a variety of devices, screens, and input methods.</span></span> <span data-ttu-id="1056d-109">この記事では、UWP アプリの UI の機能と利点について説明し、UWP アプリを初めて作成する場合のいくつかの大まかな設計ガイダンスを紹介します。</span><span class="sxs-lookup"><span data-stu-id="1056d-109">This articles describes the UI features and benefits of UWP apps and provides some high-level design guidance for creating your first UWP app.</span></span> 

## <a name="video-summary"></a><span data-ttu-id="1056d-110">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="1056d-110">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Designing-Universal-Windows-Platform-apps/player]


<!--
![windows-powered devices](images/1894834-hig-device-primer-01-500.png)
-->

<!--
![A design for an app that runs on windows phone, tablets, and pcs](images/food-truck-finder/uap-foodtruck--md-detail.png)
-->


## <a name="uwp-features"></a><span data-ttu-id="1056d-111">UWP の機能</span><span class="sxs-lookup"><span data-stu-id="1056d-111">UWP features</span></span>

<span data-ttu-id="1056d-112">最初に、UWP アプリの作成時に利用できる一部の機能を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="1056d-112">Let's start by taking a look at some of the features that you get when you create a UWP app.</span></span>

### <a name="effective-pixels-and-scaling"></a><span data-ttu-id="1056d-113">有効ピクセルとスケーリング</span><span class="sxs-lookup"><span data-stu-id="1056d-113">Effective pixels and scaling</span></span>

<span data-ttu-id="1056d-114">UWP アプリは、すべてのデバイスで読みやすく、操作しやすいように、コントロール、フォント、およびその他の UI 要素のサイズを自動的に調整します。</span><span class="sxs-lookup"><span data-stu-id="1056d-114">UWP apps automatically adjust the size of controls, fonts, and other UI elements so that they are legible and easy to interact with on all devices.</span></span>

<span data-ttu-id="1056d-115">デバイスでアプリを実行するとき、システムでは、UI 要素を画面に表示する方法を正規化するアルゴリズムを使います。</span><span class="sxs-lookup"><span data-stu-id="1056d-115">When your app runs on a device, the system uses an algorithm to normalize the way UI elements display on the screen.</span></span> <span data-ttu-id="1056d-116">このスケーリング アルゴリズムでは、視聴距離と画面の密度 (ピクセル/インチ) を考慮して、体感的なサイズを最適化します (物理的なサイズではありません)。</span><span class="sxs-lookup"><span data-stu-id="1056d-116">This scaling algorithm takes into account viewing distance and screen density (pixels per inch) to optimize for perceived size (rather than physical size).</span></span> <span data-ttu-id="1056d-117">スケーリング アルゴリズムによって、10 フィート離れた Surface Hub における 24 ピクセルのフォントが、数インチ離れた 5 インチ サイズの電話における 24 ピクセルのフォントと同じようにユーザーに読みやすい状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-117">The scaling algorithm ensures that a 24 px font on Surface Hub 10 feet away is just as legible to the user as a 24 px font on 5" phone that's a few inches away.</span></span>

![さまざまなデバイスの視聴距離](images/1910808-hig-uap-toolkit-03.png)

<span data-ttu-id="1056d-119">スケーリング システムのしくみのため、UWP アプリをデザインするときには、実際の物理ピクセルではなく、*有効ピクセル*でデザインすることになります。</span><span class="sxs-lookup"><span data-stu-id="1056d-119">Because of how the scaling system works, when you design your UWP app, you're designing in *effective pixels*, not actual physical pixels.</span></span> <span data-ttu-id="1056d-120">それでは、これは、アプリの設計方法にどのような影響を及ぼすでしょうか。</span><span class="sxs-lookup"><span data-stu-id="1056d-120">So, how does that impact the way you design your app?</span></span>

-   <span data-ttu-id="1056d-121">設計時には、ピクセル密度と実際の画面解像度を無視できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-121">You can ignore the pixel density and the actual screen resolution when designing.</span></span> <span data-ttu-id="1056d-122">その代わり、サイズ クラスの有効な解像度 (有効ピクセル単位の解像度) が向上するように設計します (詳しくは、「[画面のサイズとブレークポイント](screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="1056d-122">Instead, design for the effective resolution (the resolution in effective pixels) for a size class (for details, see the [Screen sizes and breakpoints article](screen-sizes-and-breakpoints-for-responsive-design.md)).</span></span>

-   <span data-ttu-id="1056d-123">システムによる UI のスケーリングは、4 の倍数単位で行われます。</span><span class="sxs-lookup"><span data-stu-id="1056d-123">When the system scales your UI, it does so by multiples of 4.</span></span> <span data-ttu-id="1056d-124">外観が鮮明になるように、4x4 のピクセル グリッドにデザインをスナップします。余白、UI 要素のサイズと位置を、4 有効ピクセルの倍数にします。</span><span class="sxs-lookup"><span data-stu-id="1056d-124">To ensure a crisp appearance, snap your designs to the 4x4 pixel grid: make margins, sizes, and the positions of UI elements a multiple of 4 effective pixels.</span></span> <span data-ttu-id="1056d-125">この要件は、テキストには必要ありません。テキストのサイズと位置に制限はありません。</span><span class="sxs-lookup"><span data-stu-id="1056d-125">Note that text doesn't have this requirement; the text can have any size and position.</span></span> 

<span data-ttu-id="1056d-126">次の図は、4x4 のピクセル グリッドにマップされるデザイン要素を示しています。</span><span class="sxs-lookup"><span data-stu-id="1056d-126">This illustration shows design elements that map to the 4x4 pixel grid.</span></span> <span data-ttu-id="1056d-127">デザイン要素には常に、はっきりした鮮明な縁があります。</span><span class="sxs-lookup"><span data-stu-id="1056d-127">The design element will always have crisp, sharp edges.</span></span>

![4x4 のピクセル グリッドへのスナップ](images/rsp-design/epx-4pixelgood.png)

> [!TIP]
> <span data-ttu-id="1056d-129">イメージ編集プログラムで画面のモックアップを作成するときは、DPI を 72 に設定し、画像サイズを、対象のサイズ クラスで有効な解像度に設定します</span><span class="sxs-lookup"><span data-stu-id="1056d-129">When creating screen mockups in image editing programs, set the DPI to 72 and set the image dimensions to the effective resolution for the size class you're targeting.</span></span> <span data-ttu-id="1056d-130">サイズ クラスと有効な解像度の一覧については、「[画面のサイズとブレークポイント](screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1056d-130">For a list of size classes and effective resolutions, see the [Screen sizes and breakpoints article](screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>


### <a name="universal-input-and-smart-interactions"></a><span data-ttu-id="1056d-131">ユニバーサル入力とスマート操作</span><span class="sxs-lookup"><span data-stu-id="1056d-131">Universal input and smart interactions</span></span>

<span data-ttu-id="1056d-132">UWP のもう 1 つの組み込み機能は、スマート操作によって有効になるユニバーサル入力です。</span><span class="sxs-lookup"><span data-stu-id="1056d-132">Another built-in capability of the UWP is universal input enabled via smart interactions.</span></span> <span data-ttu-id="1056d-133">特定の入力モードやデバイス用にアプリを設計することもできますが、そうする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1056d-133">Although you can design your apps for specific input modes and devices, you aren’t required to.</span></span> <span data-ttu-id="1056d-134">ユニバーサル Windows アプリでは、既定でスマート操作が使用されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-134">That’s because Universal Windows apps by default rely on smart interactions.</span></span> <span data-ttu-id="1056d-135">つまり、クリックの発生元が実際のマウス クリックであるか、指によるタップであるかどうかを認識または定義しなくても、クリック操作に対応したデザインを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-135">That means you can design around a click interaction without having to know or define whether the click comes from an actual mouse click or the tap of a finger.</span></span>

### <a name="universal-controls-and-styles"></a><span data-ttu-id="1056d-136">ユニバーサル コントロールとスタイル</span><span class="sxs-lookup"><span data-stu-id="1056d-136">Universal controls and styles</span></span>


<span data-ttu-id="1056d-137">UWP には、複数のデバイス ファミリに対応したアプリを簡単にデザインできる、便利な構成要素が用意されています。</span><span class="sxs-lookup"><span data-stu-id="1056d-137">The UWP also provides some useful building blocks that make it easier to design apps for multiple device families.</span></span>

-   **<span data-ttu-id="1056d-138">ユニバーサル コントロール</span><span class="sxs-lookup"><span data-stu-id="1056d-138">Universal controls</span></span>**

    <span data-ttu-id="1056d-139">UWP には、すべての Windows デバイスで適切に動作することが保証されている一連のユニバーサル コントロールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="1056d-139">The UWP provides a set of universal controls that are guaranteed to work well on all Windows-powered devices.</span></span> <span data-ttu-id="1056d-140">この一連のユニバーサル コントロールには、オプション ボタンやテキスト ボックスなどの一般的なフォーム コントロールから、データ ストリームやテンプレートから項目の一覧を生成できるグリッド ビューやリスト ビューなどの高度なコントロールまで、すべてのコントロールが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1056d-140">This set of universal controls includes everything from common form controls like radio button and text box to sophisticated controls like grid view and list view that can generate lists of items from a stream of data and a template.</span></span> <span data-ttu-id="1056d-141">これらのコントロールは入力に対応しており、各デバイス ファミリに適した、一連の入力アフォーダンス、イベント状態、および全体的な機能と共に展開されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-141">These controls are input-aware and deploy with the proper set of input affordances, event states, and overall functionality for each device family.</span></span>

    <span data-ttu-id="1056d-142">これらのコントロールとこれらのコントロールに基づいて作成できるパターンの全一覧については、「[コントロールとパターン](https://dev.windows.com/design/controls-patterns)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1056d-142">For a complete list of these controls and the patterns you can make from them, see the [Controls and patterns](https://dev.windows.com/design/controls-patterns) section.</span></span>

-   **<span data-ttu-id="1056d-143">ユニバーサル スタイル</span><span class="sxs-lookup"><span data-stu-id="1056d-143">Universal styles</span></span>**

    <span data-ttu-id="1056d-144">UWP アプリは、次の機能を実現できる既定のスタイル セットを自動的に取得します。</span><span class="sxs-lookup"><span data-stu-id="1056d-144">Your UWP app automatically gets a default set of styles that gives you these features:</span></span>

    -   <span data-ttu-id="1056d-145">一連のスタイルによって、アプリに淡色や濃色のテーマを自動的に適用したり (ユーザーが選ぶことができます)、ユーザーのアクセント カラーの設定を組み込んだりすることができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-145">A set of styles that automatically gives your app a light or dark theme (your choice) and can incorporate the user's accent color preference.</span></span>

        ![淡色テーマと濃色テーマ](images/1910808-hig-uap-toolkit-01.png)

    -   <span data-ttu-id="1056d-147">すべてのデバイスでアプリのテキストを鮮明に表示する Segoe ベースの書体見本 (type ramp)。</span><span class="sxs-lookup"><span data-stu-id="1056d-147">A Segoe-based type ramp that ensures that app text looks crisp on all devices.</span></span>
    -   <span data-ttu-id="1056d-148">対話式操作のための既定のアニメーション。</span><span class="sxs-lookup"><span data-stu-id="1056d-148">Default animations for interactions.</span></span>
    -   <span data-ttu-id="1056d-149">ハイ コントラスト モードを自動的にサポート。</span><span class="sxs-lookup"><span data-stu-id="1056d-149">Automatic support for high-contrast modes.</span></span> <span data-ttu-id="1056d-150">適用するスタイルはハイ コントラストとなるようにデザインされているため、アプリがハイ コントラスト モードのデバイスで実行されているときに正確に表示されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-150">Our styles were designed with high-contrast in mind, so when your app runs on a device in high-contrast mode, it will display properly.</span></span>
    -   <span data-ttu-id="1056d-151">その他の言語を自動的にサポート。</span><span class="sxs-lookup"><span data-stu-id="1056d-151">Automatic support for other languages.</span></span> <span data-ttu-id="1056d-152">既定のスタイルでは、Windows がサポートするすべての言語に対して、自動的に正しいフォントが適用されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-152">Our default styles automatically select the correct font for every language that Windows supports.</span></span> <span data-ttu-id="1056d-153">1 つのアプリで複数の言語を使って、正確に表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="1056d-153">You can even use multiple languages in the same app and they'll be displayed properly.</span></span>
    -   <span data-ttu-id="1056d-154">RTL の読み取り順序に対する組み込みサポート。</span><span class="sxs-lookup"><span data-stu-id="1056d-154">Built-in support for RTL reading order.</span></span>

    <span data-ttu-id="1056d-155">これら既定のスタイルをカスタマイズして、アプリを個性的なものにしたり、既定のスタイルをユーザー固有のスタイルと完全に置き換えて、独自の視覚的効果を実現したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-155">You can customize these default styles to give your app a personal touch, or you can completely replace them with your own to create a unique visual experience.</span></span> <span data-ttu-id="1056d-156">たとえば、独自の視覚スタイルを使った天気予報アプリのデザインを次に示します。</span><span class="sxs-lookup"><span data-stu-id="1056d-156">For example, here's a design for a weather app with a unique visual style:</span></span>

    ![独自の視覚スタイルを使った天気予報アプリ](images/weather/uwp-weather-tab-phone-700.png)

## <a name="uwp-and-the-fluent-design-system"></a><span data-ttu-id="1056d-158">UWP と Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="1056d-158">UWP and the Fluent Design System</span></span>

 <span data-ttu-id="1056d-159">Fluent Design System では、ライト、深度、モーション、マテリアル、およびスケールが組み込まれた、モダンでクリーンな UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-159">The Fluent Design System helps you create modern, clean UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="1056d-160">Fluent Design は、さまざまな Windows 10 デバイスとアプリにわたって適用され、美しく、魅力的で直感的なエクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="1056d-160">Fluent Design is being applied across Windows 10 devices and apps to create beautiful, engaging, and intuitive experiences.</span></span> 
 
 <span data-ttu-id="1056d-161">アプリに Fluent Design を組み込む方法</span><span class="sxs-lookup"><span data-stu-id="1056d-161">How can you incorporate Fluent Design into your app?</span></span> <span data-ttu-id="1056d-162">組み込みを簡単にするための、新しいコントロールと機能が、継続的に追加されています。</span><span class="sxs-lookup"><span data-stu-id="1056d-162">We're continually adding new controls and features that make it easy.</span></span> <span data-ttu-id="1056d-163">UWP 向けの現在の Fluent Design の機能の一覧を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1056d-163">Here's a list of current Fluent Design features for UWP:</span></span>  

* <span data-ttu-id="1056d-164">[アクリル](../style/acrylic.md)は、半透明サーフェスを作成できる、ブラシの種類です。</span><span class="sxs-lookup"><span data-stu-id="1056d-164">[Acrylic](../style/acrylic.md) is a type of brush that creates semi-transparent surfaces.</span></span>
* <span data-ttu-id="1056d-165">[視差効果](../style/parallax.md)を使用すると、3 次元の視点、深度、および動きを追加できます。たとえばリストなどのスクロールするコンテンツに適用できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-165">[Parallax](../style/parallax.md) adds three-dimensional perspective, depth, and movement to scrolling content, such as lists.</span></span>
* <span data-ttu-id="1056d-166">[表示](../style/reveal.md)は光を使用して、対話型の UI 要素を照らすホバー効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="1056d-166">[Reveal](../style/reveal.md) uses light to create a hover effect that illuminates interactive UI elements.</span></span> 
* <span data-ttu-id="1056d-167">[接続型アニメーション](../style/connected-animation.md)はシーンをスムーズに切り替えます。コンテキストを維持し、継続性を実現することで、使いやすさを向上させます。</span><span class="sxs-lookup"><span data-stu-id="1056d-167">[Connected animations](../style/connected-animation.md) provide graceful scene transitions that improve usability by maintaining context and providing continuity.</span></span> 

<span data-ttu-id="1056d-168">さらに[設計ガイドライン](https://developer.microsoft.com/windows/apps/design) (現在お読みの、このドキュメントです) が Fluent Design の原則に基づくように更新されました。</span><span class="sxs-lookup"><span data-stu-id="1056d-168">We've also updated our [design guidelines](https://developer.microsoft.com/windows/apps/design) (which you're current reading) so they're based on Fluent Design principles.</span></span>

## <a name="the-anatomy-of-a-typical-uwp-app"></a><span data-ttu-id="1056d-169">一般的な UWP アプリの構造</span><span class="sxs-lookup"><span data-stu-id="1056d-169">The anatomy of a typical UWP app</span></span>

<span data-ttu-id="1056d-170">ここまで、UWP アプリの構成要素について説明しました。次に、それらを組み合わせて UI を作成する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="1056d-170">Now that we've described the building blocks of UWP apps, let's take a look at how to put them together to create a UI.</span></span>

<span data-ttu-id="1056d-171">最新のユーザー インターフェイスは複雑であり、テキスト、形状、色、アニメーションで構成されますが、それらは最終的には使っているデバイスの画面の個々のピクセルで構成されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-171">A modern user interface is a complex thing, made up of text, shapes, colors, and animations which are ultimately made up out of individual pixels of the screen of the device you're using.</span></span> <span data-ttu-id="1056d-172">ユーザー インターフェイスの設計を開始すると、選択肢が多すぎて圧倒されることがあります。</span><span class="sxs-lookup"><span data-stu-id="1056d-172">When you start designing a user interface, the sheer number of choices can be overwhelming.</span></span>

<span data-ttu-id="1056d-173">シンプルに考えることができるように、アプリの構造をデザインの観点から定義してみましょう。</span><span class="sxs-lookup"><span data-stu-id="1056d-173">To make things simpler, let's define the anatomy of an app from a design perspective.</span></span> <span data-ttu-id="1056d-174">アプリが画面とページで構成されるとしましょう。</span><span class="sxs-lookup"><span data-stu-id="1056d-174">Let's say that an app is made up of screens and pages.</span></span> <span data-ttu-id="1056d-175">各ページには、3 種類の UI 要素 (ナビゲーション、コマンド実行、コンテンツ) で構成されるユーザー インターフェイスがあります。</span><span class="sxs-lookup"><span data-stu-id="1056d-175">Each page has a user interface, made up of three types of UI elements: navigation, commanding, and content elements.</span></span>



<table class="uwpd-noborder" >
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left"><p><img src="images/1895065-hig-anatomyofanapp-02.png" alt="Navigation, command, and content areas of an address book app" /></p>
<p></p></td>
<td align="left"><strong><span data-ttu-id="1056d-176">ナビゲーション要素</span><span class="sxs-lookup"><span data-stu-id="1056d-176">Navigation elements</span></span></strong>
<p><span data-ttu-id="1056d-177">ナビゲーション要素は、表示するコンテンツをユーザーが選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="1056d-177">Navigation elements help users choose the content they want to display.</span></span> <span data-ttu-id="1056d-178">ナビゲーション要素の例には、[タブとピボット](../controls-and-patterns/tabs-pivot.md)、[ハイパーリンク](../controls-and-patterns/hyperlinks.md)、[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)などがあります。</span><span class="sxs-lookup"><span data-stu-id="1056d-178">Examples of navigation elements include [tabs and pivots](../controls-and-patterns/tabs-pivot.md), [hyperlinks](../controls-and-patterns/hyperlinks.md), and [nav panes](../controls-and-patterns/navigationview.md).</span></span></p>
<p><span data-ttu-id="1056d-179">ナビゲーション要素の詳細については、「[ナビゲーション デザインの基本](navigation-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1056d-179">Navigation elements are covered in detail in the [Navigation design basics](navigation-basics.md) article.</span></span></p>
<strong><span data-ttu-id="1056d-180">コマンド要素</span><span class="sxs-lookup"><span data-stu-id="1056d-180">Command elements</span></span></strong>
<p><span data-ttu-id="1056d-181">コマンド要素は、操作、保存、コンテンツの共有などの操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="1056d-181">Command elements initiate actions, such as manipulating, saving, or sharing content.</span></span> <span data-ttu-id="1056d-182">コマンド要素の例には、[ボタン](../controls-and-patterns/buttons.md)や[コマンド バー](../controls-and-patterns/app-bars.md)があります。</span><span class="sxs-lookup"><span data-stu-id="1056d-182">Examples of command elements include [button](../controls-and-patterns/buttons.md) and the [command bar](../controls-and-patterns/app-bars.md).</span></span> <span data-ttu-id="1056d-183">コマンド要素には、実際には画面に表示されないキーボード ショートカットも含めることができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-183">Command elements can also include keyboard shortcuts that aren't actually visible on the screen.</span></span></p>
<p><span data-ttu-id="1056d-184">コマンド要素の詳細については、「[コマンド設計の基本](commanding-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1056d-184">Command elements are covered in detail in the [Command design basics](commanding-basics.md) article.</span></span></p>
<strong><span data-ttu-id="1056d-185">コンテンツ要素</span><span class="sxs-lookup"><span data-stu-id="1056d-185">Content elements</span></span></strong>
<p><span data-ttu-id="1056d-186">コンテンツ要素は、アプリのコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="1056d-186">Content elements display the app's content.</span></span> <span data-ttu-id="1056d-187">ペイント アプリでは、コンテンツは描画になり、ニュース アプリでは、コンテンツはニュース記事になります。</span><span class="sxs-lookup"><span data-stu-id="1056d-187">For a painting app, the content might be a drawing; for a news app, the content might be a news article.</span></span></p>
<p><span data-ttu-id="1056d-188">コンテンツ要素の詳細については、「[コンテンツ デザインの基本](content-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1056d-188">Content elements are covered in detail in the [Content design basics](content-basics.md) article.</span></span></p></td>
</tr>
</tbody>
</table>

 

<span data-ttu-id="1056d-189">少なくとも、アプリは、スプラッシュ画面と、ユーザー インターフェイスを定義するホーム ページで構成されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-189">At a minimum, an app has a splash screen and a home page that defines the user interface.</span></span> <span data-ttu-id="1056d-190">一般的なアプリは複数のページと画面で構成され、ナビゲーション要素、コマンド要素、コンテンツ要素はページごとに変化します。</span><span class="sxs-lookup"><span data-stu-id="1056d-190">A typical app will have multiple pages and screens, and navigation, command, and content elements might change from page to page.</span></span>

<span data-ttu-id="1056d-191">アプリに適切な UI 要素を決めるときには、アプリが実行されるデバイスや画面サイズも考慮に入れるかもしれません。</span><span class="sxs-lookup"><span data-stu-id="1056d-191">When deciding on the right UI elements for your app, you might also consider the devices and the screen sizes your app will run on.</span></span>

## <a name="tailoring-your-app-for-specific-devices-and-screen-sizes"></a><span data-ttu-id="1056d-192">特定のデバイスと画面サイズに合わせたアプリの調整</span><span class="sxs-lookup"><span data-stu-id="1056d-192">Tailoring your app for specific devices and screen sizes.</span></span>

<span data-ttu-id="1056d-193">UWP アプリでは、すべての Windows デバイスで、デザイン要素が見やすく操作しやすい効果的なピクセルが使用されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-193">UWP apps use effective pixels to guarantee that your design elements will be legible and usable on all Windows-powered devices.</span></span> <span data-ttu-id="1056d-194">このため、特定のデバイス ファミリー向けにアプリの UI をカスタマイズする理由がありません。</span><span class="sxs-lookup"><span data-stu-id="1056d-194">So, why would you ever want to customize your app's UI for a specific device family?</span></span>

**<span data-ttu-id="1056d-195">注</span><span class="sxs-lookup"><span data-stu-id="1056d-195">Note</span></span>**  
<span data-ttu-id="1056d-196">先に進む前に知っておくべきですが、アプリが実行されている特定のデバイスをアプリが検出する手段は、Windows では提供されていません。</span><span class="sxs-lookup"><span data-stu-id="1056d-196">Before we go any further, Windows doesn't provide a way for your app to detect the specific device your app is running on.</span></span> <span data-ttu-id="1056d-197">アプリが実行されているデバイス ファミリー (モバイル、デスクトップなど)、効果的な解像度、およびアプリが利用できる画面領域の量 (アプリのウィンドウのサイズ) は伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-197">It can tell you the device family (mobile, desktop, etc) the app is running on, the effective resolution, and the amount of screen space available to the app (the size of the app's window).</span></span>

 

-   **<span data-ttu-id="1056d-198">最も効果的に領域を使用し、移動する必要を減らすには</span><span class="sxs-lookup"><span data-stu-id="1056d-198">To make the most effective use of space and reduce the need to navigate</span></span>**

    <span data-ttu-id="1056d-199">携帯電話など、画面の小さいデバイスで適切に表示するアプリを設計した場合、そのアプリは、はるかに大きいディスプレイを備えた PC でも使用可能ですが、おそらく、無駄な領域があります。</span><span class="sxs-lookup"><span data-stu-id="1056d-199">If you design an app to look good on a device that has a small screen, such as a phone, the app will be usable on a PC with a much bigger display, but there will probably be some wasted space.</span></span> <span data-ttu-id="1056d-200">画面が特定のサイズを超える場合は、より多くのコンテンツを表示するように、アプリをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="1056d-200">You can customize the app to display more content when the screen is above a certain size.</span></span> <span data-ttu-id="1056d-201">たとえば、あるショッピング アプリでは、携帯電話には、一度に 1 つのカテゴリの商品が表示されますが、PC またはノート PC には、複数のカテゴリと製品が同時に表示されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-201">For example, a shopping app might display one merchandise category at a time on a phone, but show multiple categories and products simultaneously on a PC or laptop.</span></span>

    <span data-ttu-id="1056d-202">より多くのコンテンツを画面に表示すると、ユーザーが実行する必要があるナビゲーションの量が減少します。</span><span class="sxs-lookup"><span data-stu-id="1056d-202">By putting more content on the screen, you reduce the amount of navigation that the user needs to perform.</span></span>

-   **<span data-ttu-id="1056d-203">デバイスの機能を活用するには</span><span class="sxs-lookup"><span data-stu-id="1056d-203">To take advantage of devices' capabilities</span></span>**

    <span data-ttu-id="1056d-204">一部のデバイスでは、特定のデバイス機能がある可能性が高くなります。</span><span class="sxs-lookup"><span data-stu-id="1056d-204">Certain devices are more likely to have certain device capabilities.</span></span> <span data-ttu-id="1056d-205">たとえば、電話では、位置センサーとカメラが付属している可能性が高く、PC では、どちらも付属していない可能性が高くなります。</span><span class="sxs-lookup"><span data-stu-id="1056d-205">For example, phones are likely to have a location sensor and a camera, while a PC might not have either.</span></span> <span data-ttu-id="1056d-206">アプリは、利用できる機能を検出し、それを使用する機能を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-206">Your app can detect which capabilities are available and enable features that use them.</span></span>

-   **<span data-ttu-id="1056d-207">入力用に最適化するには</span><span class="sxs-lookup"><span data-stu-id="1056d-207">To optimize for input</span></span>**

    <span data-ttu-id="1056d-208">ユニバーサル コントロール ライブラリは、すべての入力タイプ (タッチ、ペン、キーボード、マウス) と連携できますが、その場合も、UI 要素を再配置して、特定の入力タイプを最適化することができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-208">The universal control library works with all input types (touch, pen, keyboard, mouse), but you can still optimize for certain input types by re-arranging your UI elements.</span></span> <span data-ttu-id="1056d-209">たとえば、画面の下部にナビゲーション要素を配置すると、携帯電話のユーザーにとってはアクセスしやすくなりますが、ほとんどの PC ユーザーは、ナビゲーション要素は画面の上部に表示されると想定しています。</span><span class="sxs-lookup"><span data-stu-id="1056d-209">For example, if you place navigation elements at the bottom of the screen, they'll be easier for phone users to access—but most PC users expect to see navigation elements toward the top of the screen.</span></span>

## <a name="responsive-design-techniques"></a><span data-ttu-id="1056d-210">レスポンシブ デザインの手法</span><span class="sxs-lookup"><span data-stu-id="1056d-210">Responsive design techniques</span></span>


<span data-ttu-id="1056d-211">アプリの UI を特定の画面の幅に合わせて最適化することは、レスポンシブ デザインの作成と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="1056d-211">When you optimize your app's UI for specific screen widths, we say that you're creating a responsive design.</span></span> <span data-ttu-id="1056d-212">ここでは、アプリの UI のカスタマイズに使用できる 6 種類のレスポンシブ デザイン手法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="1056d-212">Here are six responsive design techniques you can use to customize your app's UI.</span></span>

### <a name="reposition"></a><span data-ttu-id="1056d-213">位置の変更</span><span class="sxs-lookup"><span data-stu-id="1056d-213">Reposition</span></span>

<span data-ttu-id="1056d-214">アプリの UI 要素の場所と位置を変更して、各デバイスを最大限に活用することができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-214">You can alter the location and position of app UI elements to get the most out of each device.</span></span> <span data-ttu-id="1056d-215">この例では、電話やファブレットのビューが縦向きであり、完全なフレームが一度に 1 つだけ表示されるため、スクロール UI が必要です。</span><span class="sxs-lookup"><span data-stu-id="1056d-215">In this example, the portrait view on phone or phablet necessitates a scrolling UI because only one full frame is visible at a time.</span></span> <span data-ttu-id="1056d-216">縦方向か横方向かを問わず、2 つの画面フレームを表示できるデバイスでアプリが使用される場合、フレーム B は、専用の領域を占有できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-216">When the app translates to a device that allows two full on-screen frames, whether in portrait or landscape orientation, frame B can occupy a dedicated space.</span></span> <span data-ttu-id="1056d-217">グリッドを使用して配置する場合は、UI 要素が再配置されるときに同じグリッドに従うことができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-217">If you're using a grid for positioning, you can stick to the same grid when UI elements are repositioned.</span></span>

![位置の変更](images/rsp-design/rspd-reposition.png)

<span data-ttu-id="1056d-219">写真アプリ向けのこの設計の例では、写真アプリのコンテンツは大きな画面に再配置されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-219">In this example design for a photo app, the photo app repositions its content on larger screens.</span></span>

![大きな画面にコンテンツに再配置するアプリの設計](images/rsp-design/rspd-reposition-type1.png)

### <a name="resize"></a><span data-ttu-id="1056d-221">サイズ変更</span><span class="sxs-lookup"><span data-stu-id="1056d-221">Resize</span></span>

<span data-ttu-id="1056d-222">余白と UI 要素のサイズを調整して、フレーム サイズを最適化できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-222">You can optimize the frame size by adjusting the margins and size of UI elements.</span></span> <span data-ttu-id="1056d-223">次の例が示すように、これにより、コンテンツ フレームを拡大するだけで、より大きな画面で画面を見やすくすることができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-223">This could allow you, as the example here shows, to augment the reading experience on a larger screen by simply growing the content frame.</span></span>

![デザイン要素のサイズ変更](images/rsp-design/rspd-resize.png)

### <a name="reflow"></a><span data-ttu-id="1056d-225">再配置</span><span class="sxs-lookup"><span data-stu-id="1056d-225">Reflow</span></span>

<span data-ttu-id="1056d-226">デバイスと向きに応じて UI 要素のフローを変更すると、アプリでコンテンツの表示を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-226">By changing the flow of UI elements based on device and orientation, your app can offer an optimal display of content.</span></span> <span data-ttu-id="1056d-227">たとえば、より大きな画面を対象にする場合は、より大きなコンテナーに切り替え、列を追加し、別の方法でリスト項目を生成することが効果的である可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1056d-227">For instance, when going to a larger screen, it might make sense to switch larger containers, add columns, and generate list items in a different way.</span></span>

<span data-ttu-id="1056d-228">次の例は、携帯電話またはファブレットの縦にスクロールするコンテンツの 1 列をより大きな画面に再配置して、2 列のテキストを表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1056d-228">This example shows how a single column of vertically scrolling content on phone or phablet can be reflowed on a larger screen to display two columns of text.</span></span>

![デザイン要素の再配置](images/rsp-design/rspd-reflow.png)

### <a name="showhide"></a><span data-ttu-id="1056d-230">［表示］/［非表示］</span><span class="sxs-lookup"><span data-stu-id="1056d-230">Show/hide</span></span>

<span data-ttu-id="1056d-231">UI 要素は、画面領域に基づいて表示したり、非表示にしたり、デバイスが追加機能、特定の状況、または推奨される画面の向きをサポートする場合にあわせて、表示したり、非表示にしたりできます。</span><span class="sxs-lookup"><span data-stu-id="1056d-231">You can show or hide UI elements based on screen real estate, or when the device supports additional functionality, specific situations, or preferred screen orientations.</span></span>

<span data-ttu-id="1056d-232">タブを示す次の例では、カメラ アイコンがある中央のタブが携帯電話またはファブレットのアプリに固有であり、大型のデバイスには適用されません。そのため、右側のデバイスでは表示されています。</span><span class="sxs-lookup"><span data-stu-id="1056d-232">In this example with tabs, the middle tab with the camera icon might be specific to the app on phone or phablet and not be applicable on larger devices, which is why it's revealed in the device on the right.</span></span> <span data-ttu-id="1056d-233">UI の表示/非表示のもう 1 つの一般的な例は、メディア プレーヤーのコントロールです。この場合、ボタン セットは、小型のデバイスでは縮小され、使用できる画面領域が大きい大型デバイスでは展開されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-233">Another common example of revealing or hiding UI applies to media player controls, where the button set is reduced on smaller devices and expanded on larger devices.</span></span> <span data-ttu-id="1056d-234">たとえば、PC では、メディア プレーヤーが処理できる画面上の機能は、携帯電話での機能よりもはるかに多くなっています。</span><span class="sxs-lookup"><span data-stu-id="1056d-234">The media player on PC, for instance, can handle far more on-screen functionality than it can on a phone.</span></span>

![デザイン要素の非表示](images/rsp-design/rspd-revealhide.png)

<span data-ttu-id="1056d-236">表示/非表示の手法の一部には、より多くのメタデータを表示するタイミングの選択が含まれます。</span><span class="sxs-lookup"><span data-stu-id="1056d-236">Part of the reveal-or-hide technique includes choosing when to display more metadata.</span></span> <span data-ttu-id="1056d-237">携帯電話やファブレットなど、領域が貴重である場合は、表示するメタデータの量を最小限にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1056d-237">When real estate is at a premium, such as with a phone or phablet, it's best to show a minimal amount of metadata.</span></span> <span data-ttu-id="1056d-238">ノート PC やデスクトップ PC では、かなりの量のメタデータを表示できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-238">With a laptop or desktop PC, a significant amount of metadata can be surfaced.</span></span> <span data-ttu-id="1056d-239">メタデータの表示または非表示を処理する方法の例は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="1056d-239">Some examples of how to handle showing or hiding metadata include:</span></span>

-   <span data-ttu-id="1056d-240">メール アプリでは、ユーザーのアバターを表示できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-240">In an email app, you can display the user's avatar.</span></span>
-   <span data-ttu-id="1056d-241">音楽アプリでは、アルバムやアーティストの詳細情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-241">In a music app, you can display more info about an album or artist.</span></span>
-   <span data-ttu-id="1056d-242">ビデオ アプリでは、キャストとスタッフの詳細表示など、映画やショーの詳細情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-242">In a video app, you can display more info about a film or a show, such as showing cast and crew details.</span></span>
-   <span data-ttu-id="1056d-243">どのアプリでも、列を分割して、さらに詳細な情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-243">In any app, you can break apart columns and reveal more details.</span></span>
-   <span data-ttu-id="1056d-244">どのアプリでも、縦に並べられたものを横に並べて配置することができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-244">In any app, you can take something that's vertically stacked and lay it out horizontally.</span></span> <span data-ttu-id="1056d-245">携帯電話やファブレットから大型デバイスに移行する場合、縦に並べられたリスト項目は、リスト項目の行とメタデータの列の表示に変更できます。</span><span class="sxs-lookup"><span data-stu-id="1056d-245">When going from phone or phablet to larger devices, stacked list items can change to reveal rows of list items and columns of metadata.</span></span>

### <a name="replace"></a><span data-ttu-id="1056d-246">置換</span><span class="sxs-lookup"><span data-stu-id="1056d-246">Replace</span></span>

<span data-ttu-id="1056d-247">この手法では、特定のデバイスのサイズ クラスまたは向きにユーザー インターフェイスを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-247">This technique lets you switch the user interface for a specific device size-class or orientation.</span></span> <span data-ttu-id="1056d-248">次の例では、ナビゲーション ウィンドウとそのコンパクトで一時的な UI は小型デバイスに適していますが、大型デバイスには、タブの方が適しています。</span><span class="sxs-lookup"><span data-stu-id="1056d-248">In this example, the nav pane and its compact, transient UI works well for a smaller device, but on a larger device tabs might be a better choice.</span></span>

![デザイン要素の置き換え](images/rsp-design/rspd-replace.png)

###  <a name="re-architect"></a><span data-ttu-id="1056d-250">再構築</span><span class="sxs-lookup"><span data-stu-id="1056d-250">Re-architect</span></span>

<span data-ttu-id="1056d-251">アプリのアーキテクチャを折りたたんだり、分岐させたりして、対象となる特定のデバイスをより明確にすることができます。</span><span class="sxs-lookup"><span data-stu-id="1056d-251">You can collapse or fork the architecture of your app to better target specific devices.</span></span> <span data-ttu-id="1056d-252">次の例では、左側のデバイスから右側のデバイスに移動すると、ページが結合されます。</span><span class="sxs-lookup"><span data-stu-id="1056d-252">In this example, going from the left device to the right device demonstrates the joining of pages.</span></span>

![ユーザー インターフェイスの再設計の例](images/rsp-design/rspd-rearchitect.png)

<span data-ttu-id="1056d-254">ここでは、スマート ホーム アプリの設計に適用される、この手法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="1056d-254">Here's an example of this technique applied to the design for a smart home app.</span></span>

![レスポンシブ デザインの再構築手法を使用する設計の例](images/rsp-design/rspd-rearchitect-type1.png)

## <a name="tools-and-design-toolkits"></a><span data-ttu-id="1056d-256">ツールと設計ツールキット</span><span class="sxs-lookup"><span data-stu-id="1056d-256">Tools and design toolkits</span></span>

<span data-ttu-id="1056d-257">UWP アプリを設計するのに役立つさまざまなツールが提供されています。</span><span class="sxs-lookup"><span data-stu-id="1056d-257">We provide a variety of tools to help you design you UWP app.</span></span> <span data-ttu-id="1056d-258">[設計ツールキットのページ](../design-downloads/index.md)をご覧ください。XD、Illustrator、Photoshop、Framer、Sketch の各ツールキット、および追加の設計ツールやフォントのダウンロードが提供されています。</span><span class="sxs-lookup"><span data-stu-id="1056d-258">See our [Design toolkits page](../design-downloads/index.md) for XD, Illustrator, Photoshop, Framer, and Sketch toolkits, as well as additional design tools and font downloads.</span></span> 

<span data-ttu-id="1056d-259">コンピューターを設定して実際に UWP アプリのコードを記述できるようにするには、[作業の開始と準備](../get-started/get-set-up.md)の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1056d-259">To get your machine set up to actually code UWP apps, see our [Get started &gt; Get set up](../get-started/get-set-up.md) article.</span></span> 

## <a name="related-articles"></a><span data-ttu-id="1056d-260">関連記事</span><span class="sxs-lookup"><span data-stu-id="1056d-260">Related articles</span></span>

- [<span data-ttu-id="1056d-261">UWP アプリとは</span><span class="sxs-lookup"><span data-stu-id="1056d-261">What's a UWP app?</span></span>](https://msdn.microsoft.com/library/windows/apps/dn726767.aspx)
- [<span data-ttu-id="1056d-262">設計ツールキット</span><span class="sxs-lookup"><span data-stu-id="1056d-262">Design toolkits</span></span>](../design-downloads/index.md)

 
