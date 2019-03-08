---
Description: 特定のデバイスのアプリを調整するレスポンシブ デザイン手法について説明します
label: Responsive design techniques
template: detail.hbs
op-migration-status: ready
ms.date: 10/10/2017
ms.topic: article
keywords: windows 10, uwp
localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 9e06131da5d7dd56354e1871867f9956ad13aa2c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57624817"
---
# <a name="responsive-design-techniques"></a><span data-ttu-id="1adbc-103">レスポンシブ デザインの手法</span><span class="sxs-lookup"><span data-stu-id="1adbc-103">Responsive design techniques</span></span>

<span data-ttu-id="1adbc-104">UWP アプリでは、有効ピクセルを使用して、読みやすく、すべての Windows を利用したデバイスで使用可能な UI になることを保証します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-104">UWP apps use effective pixels to guarantee that your UI will be legible and usable on all Windows-powered devices.</span></span> <span data-ttu-id="1adbc-105">このため、特定のデバイス ファミリー向けにアプリの UI をカスタマイズする理由がありません。</span><span class="sxs-lookup"><span data-stu-id="1adbc-105">So, why would you ever want to customize your app's UI for a specific device family?</span></span>

- <span data-ttu-id="1adbc-106">**領域の最も効果的に使用して、移動する必要性が軽減するには**</span><span class="sxs-lookup"><span data-stu-id="1adbc-106">**To make the most effective use of space and reduce the need to navigate**</span></span>

    <span data-ttu-id="1adbc-107">小さな画面を備えたデバイスで適切に表示するアプリを設計する場合は、タブレットなど、アプリはくらい大きく表示、PC 上で使用されますが、無駄な領域の一部でしょう。</span><span class="sxs-lookup"><span data-stu-id="1adbc-107">If you design an app to look good on a device that has a small screen, such as a tablet, the app will be usable on a PC with a much bigger display, but there will probably be some wasted space.</span></span> <span data-ttu-id="1adbc-108">画面が特定のサイズを超える場合は、より多くのコンテンツを表示するように、アプリをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-108">You can customize the app to display more content when the screen is above a certain size.</span></span> <span data-ttu-id="1adbc-109">たとえば、ショッピング アプリは、タブレットで同時に 1 つの商品カテゴリを表示が、PC またはノート パソコンに複数のカテゴリと製品を同時に表示します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-109">For example, a shopping app might display one merchandise category at a time on a tablet, but show multiple categories and products simultaneously on a PC or laptop.</span></span>

    <span data-ttu-id="1adbc-110">より多くのコンテンツを画面に表示すると、ユーザーが実行する必要があるナビゲーションの量が減少します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-110">By putting more content on the screen, you reduce the amount of navigation that the user needs to perform.</span></span>

- <span data-ttu-id="1adbc-111">**デバイスの機能を活用するには**</span><span class="sxs-lookup"><span data-stu-id="1adbc-111">**To take advantage of devices' capabilities**</span></span>

    <span data-ttu-id="1adbc-112">一部のデバイスでは、特定のデバイス機能がある可能性が高くなります。</span><span class="sxs-lookup"><span data-stu-id="1adbc-112">Certain devices are more likely to have certain device capabilities.</span></span> <span data-ttu-id="1adbc-113">たとえば、ラップトップを持つ可能性が位置情報センサーとカメラ、TV いずれかがないです。</span><span class="sxs-lookup"><span data-stu-id="1adbc-113">For example, laptops are likely to have a location sensor and a camera, while a TV might not have either.</span></span> <span data-ttu-id="1adbc-114">アプリは、利用できる機能を検出し、それを使用する機能を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-114">Your app can detect which capabilities are available and enable features that use them.</span></span>

- <span data-ttu-id="1adbc-115">**入力用に最適化するには**</span><span class="sxs-lookup"><span data-stu-id="1adbc-115">**To optimize for input**</span></span>

    <span data-ttu-id="1adbc-116">ユニバーサル コントロール ライブラリは、すべての入力タイプ (タッチ、ペン、キーボード、マウス) と連携できますが、その場合も、UI 要素を再配置して、特定の入力タイプを最適化することができます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-116">The universal control library works with all input types (touch, pen, keyboard, mouse), but you can still optimize for certain input types by re-arranging your UI elements.</span></span> <span data-ttu-id="1adbc-117">たとえば、画面の下部にナビゲーション要素を配置すると、携帯電話のユーザーにとってはアクセスしやすくなりますが、ほとんどの PC ユーザーは、ナビゲーション要素は画面の上部に表示されると想定しています。</span><span class="sxs-lookup"><span data-stu-id="1adbc-117">For example, if you place navigation elements at the bottom of the screen, they'll be easier for phone users to access—but most PC users expect to see navigation elements toward the top of the screen.</span></span>

<span data-ttu-id="1adbc-118">アプリの UI を特定の画面の幅に合わせて最適化することは、レスポンシブ デザインの作成と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-118">When you optimize your app's UI for specific screen widths, we say that you're creating a responsive design.</span></span> <span data-ttu-id="1adbc-119">ここでは、アプリの UI のカスタマイズに使用できる 6 種類のレスポンシブ デザイン手法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-119">Here are six responsive design techniques you can use to customize your app's UI.</span></span>

>[!TIP]
> <span data-ttu-id="1adbc-120">UWP コントロールの多くは、これらの応答性の高い動作を自動的に実装します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-120">Many UWP controls automatically implement these responsive behaviors.</span></span> <span data-ttu-id="1adbc-121">レスポンシブ UI を作成するをお勧めのチェック アウト、 [UWP コントロール](../controls-and-patterns/index.md)します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-121">To create a responsive UI, we recommend checking out the [UWP controls](../controls-and-patterns/index.md).</span></span>

## <a name="reposition"></a><span data-ttu-id="1adbc-122">位置の変更</span><span class="sxs-lookup"><span data-stu-id="1adbc-122">Reposition</span></span>

<span data-ttu-id="1adbc-123">ウィンドウのサイズを最大限に活用する UI 要素の位置と場所を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-123">You can alter the location and position of UI elements to make the most of the window size.</span></span> <span data-ttu-id="1adbc-124">この例では、小さいウィンドウは、要素を垂直方向にスタックします。</span><span class="sxs-lookup"><span data-stu-id="1adbc-124">In this example, the smaller window stacks elements vertically.</span></span> <span data-ttu-id="1adbc-125">アプリ変換される場合より大きなウィンドウに、要素より多くのウィンドウの幅の利用できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-125">When the app translates to a larger window, elements can take advantage of the wider window width.</span></span>

![位置の変更](images/rsp-design/rspd-reposition2.gif)

<span data-ttu-id="1adbc-127">写真アプリ向けのこの設計の例では、写真アプリのコンテンツは大きな画面に再配置されます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-127">In this example design for a photo app, the photo app repositions its content on larger screens.</span></span>

## <a name="resize"></a><span data-ttu-id="1adbc-128">サイズ変更</span><span class="sxs-lookup"><span data-stu-id="1adbc-128">Resize</span></span>

<span data-ttu-id="1adbc-129">ウィンドウ サイズの UI 要素のサイズと余白を調整することによって最適化できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-129">You can optimize for the window size by adjusting the margins and size of UI elements.</span></span> <span data-ttu-id="1adbc-130">たとえば、コンテンツ フレームを単純に拡大することによりより大きな画面での読みやすさを補強これでした。</span><span class="sxs-lookup"><span data-stu-id="1adbc-130">For example, this could augment the reading experience on a larger screen by simply growing the content frame.</span></span>

![デザイン要素のサイズ変更](images/rsp-design/rspd-resize2.gif)

## <a name="reflow"></a><span data-ttu-id="1adbc-132">再配置</span><span class="sxs-lookup"><span data-stu-id="1adbc-132">Reflow</span></span>

<span data-ttu-id="1adbc-133">デバイスと向きに応じて UI 要素のフローを変更すると、アプリでコンテンツの表示を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-133">By changing the flow of UI elements based on device and orientation, your app can offer an optimal display of content.</span></span> <span data-ttu-id="1adbc-134">たとえばより大きな画面になると、有意義なこと列の追加または拡大のコンテナーを使用して、別の方法でリスト項目を生成します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-134">For instance, when going to a larger screen, it might make sense to add columns, use larger containers, or generate list items in a different way.</span></span>

<span data-ttu-id="1adbc-135">この例では、1 つの列のテキストの 2 つの列を表示するより大きな画面に折り返すことができますを小さな画面上のコンテンツを垂直方向にスクロールする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-135">This example shows how a single column of vertically scrolling content on a smaller screen that can be reflowed on a larger screen to display two columns of text.</span></span>

![デザイン要素の再配置](images/rsp-design/rspd_reflow.gif)

## <a name="showhide"></a><span data-ttu-id="1adbc-137">［表示］/［非表示］</span><span class="sxs-lookup"><span data-stu-id="1adbc-137">Show/hide</span></span>

<span data-ttu-id="1adbc-138">UI 要素は、画面領域に基づいて表示したり、非表示にしたり、デバイスが追加機能、特定の状況、または推奨される画面の向きをサポートする場合にあわせて、表示したり、非表示にしたりできます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-138">You can show or hide UI elements based on screen real estate, or when the device supports additional functionality, specific situations, or preferred screen orientations.</span></span>

![デザイン要素の非表示](images/rsp-design/rspd-revealhide.gif)

<span data-ttu-id="1adbc-140">たとえば、メディア プレーヤーのコントロールは、小さい画面にボタンのセットを削減し、大きい画面で展開します。</span><span class="sxs-lookup"><span data-stu-id="1adbc-140">For example, media player controls reduce the button set on smaller screens and expand on larger screens.</span></span> <span data-ttu-id="1adbc-141">大きなウィンドウで、media player がはるかに多くの画面に処理できる機能よりも小さいウィンドウのことができます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-141">The media player on a larger window can handle far more on-screen functionality than it can on a smaller window.</span></span>

<span data-ttu-id="1adbc-142">表示/非表示の手法の一部には、より多くのメタデータを表示するタイミングの選択が含まれます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-142">Part of the reveal-or-hide technique includes choosing when to display more metadata.</span></span> <span data-ttu-id="1adbc-143">小さい windows では、最小限のメタデータを表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1adbc-143">With smaller windows, it's best to show a minimal amount of metadata.</span></span> <span data-ttu-id="1adbc-144">大きな windows は、大量のメタデータを表示できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-144">With larger windows, a significant amount of metadata can be surfaced.</span></span> <span data-ttu-id="1adbc-145">いくつかの例の場合またはメタデータを非表示には次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="1adbc-145">Some examples of when to show or hide metadata include:</span></span>

- <span data-ttu-id="1adbc-146">メール アプリでは、ユーザーのアバターを表示できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-146">In an email app, you can display the user's avatar.</span></span>
- <span data-ttu-id="1adbc-147">音楽アプリでは、アルバムやアーティストの詳細情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-147">In a music app, you can display more info about an album or artist.</span></span>
- <span data-ttu-id="1adbc-148">ビデオ アプリでは、キャストとスタッフの詳細表示など、映画やショーの詳細情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-148">In a video app, you can display more info about a film or a show, such as showing cast and crew details.</span></span>
- <span data-ttu-id="1adbc-149">どのアプリでも、列を分割して、さらに詳細な情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-149">In any app, you can break apart columns and reveal more details.</span></span>
- <span data-ttu-id="1adbc-150">どのアプリでも、縦に並べられたものを横に並べて配置することができます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-150">In any app, you can take something that's vertically stacked and lay it out horizontally.</span></span> <span data-ttu-id="1adbc-151">携帯電話やファブレットから大型デバイスに移行する場合、縦に並べられたリスト項目は、リスト項目の行とメタデータの列の表示に変更できます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-151">When going from phone or phablet to larger devices, stacked list items can change to reveal rows of list items and columns of metadata.</span></span>

## <a name="replace"></a><span data-ttu-id="1adbc-152">置換</span><span class="sxs-lookup"><span data-stu-id="1adbc-152">Replace</span></span>

<span data-ttu-id="1adbc-153">この手法では、ユーザー インターフェイスの特定のブレークポイントを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-153">This technique lets you switch the user interface for a specific breakpoints.</span></span> <span data-ttu-id="1adbc-154">次の例、ナビゲーション ウィンドウとその最適化では、一時的な UI は、小さな画面に適してがより大きな画面では、タブの方が適切可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1adbc-154">In this example, the nav pane and its compact, transient UI works well for a smaller screen, but on a larger screen, tabs might be a better choice.</span></span>

![デザイン要素の置き換え](images/rsp-design/rspd-replace.gif)

<span data-ttu-id="1adbc-156">[NavigationView](../controls-and-patterns/navigationview.md)コントロールは、左または上にウィンドウの位置を設定することでこの応答性の高い方法をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1adbc-156">The [NavigationView](../controls-and-patterns/navigationview.md) control supports this responsive technique, by letting users set the pane position to either top or left.</span></span>

## <a name="re-architect"></a><span data-ttu-id="1adbc-157">再構築</span><span class="sxs-lookup"><span data-stu-id="1adbc-157">Re-architect</span></span>

<span data-ttu-id="1adbc-158">アプリのアーキテクチャを折りたたんだり、分岐させたりして、対象となる特定のデバイスをより明確にすることができます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-158">You can collapse or fork the architecture of your app to better target specific devices.</span></span> <span data-ttu-id="1adbc-159">この例で、ウィンドウの展開全体のマスター/詳細パターンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="1adbc-159">In this example, expanding the window shows the entire master/details pattern.</span></span>

![ユーザー インターフェイスの再設計の例](images/rsp-design/rspd-rearchitect.gif)

## <a name="related-topics"></a><span data-ttu-id="1adbc-161">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1adbc-161">Related topics</span></span>

- [<span data-ttu-id="1adbc-162">画面のサイズとブレークポイント</span><span class="sxs-lookup"><span data-stu-id="1adbc-162">Screen sizes and breakpoints</span></span>](screen-sizes-and-breakpoints-for-responsive-design.md)
- [<span data-ttu-id="1adbc-163">XAML で応答性の高いレイアウト</span><span class="sxs-lookup"><span data-stu-id="1adbc-163">Responsive layouts with XAML</span></span>](layouts-with-xaml.md)
- [<span data-ttu-id="1adbc-164">UWP コントロールとパターン</span><span class="sxs-lookup"><span data-stu-id="1adbc-164">UWP controls and patterns</span></span>](../controls-and-patterns/index.md)
