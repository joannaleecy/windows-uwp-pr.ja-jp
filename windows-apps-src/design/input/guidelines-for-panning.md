---
Description: Panning or scrolling lets users navigate within a single view, to display the content of the view that does not fit within the viewport. Examples of views include the folder structure of a computer, a library of documents, or a photo album.
title: パン
ms.assetid: b419f538-c7fb-4e7c-9547-5fb2494c0b71
label: Panning
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 340289c16cfd9c63f578c63827b1c0b35162cdfd
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8190114"
---
# <a name="guidelines-for-panning"></a><span data-ttu-id="dc053-103">パンのガイドライン</span><span class="sxs-lookup"><span data-stu-id="dc053-103">Guidelines for panning</span></span>


<span data-ttu-id="dc053-104">パンとスクロールにより、ユーザーは単一ビュー内で移動し、ビューポートに収まらないビューのコンテンツを表示できます。</span><span class="sxs-lookup"><span data-stu-id="dc053-104">Panning or scrolling lets users navigate within a single view, to display the content of the view that does not fit within the viewport.</span></span> <span data-ttu-id="dc053-105">ビューの例として、コンピューターのフォルダー構造、ドキュメントのライブラリ、フォト アルバムなどがあります。</span><span class="sxs-lookup"><span data-stu-id="dc053-105">Examples of views include the folder structure of a computer, a library of documents, or a photo album.</span></span>

> <span data-ttu-id="dc053-106">**重要な API**: [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、[**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span><span class="sxs-lookup"><span data-stu-id="dc053-106">**Important APIs**: [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084), [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="dc053-107">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="dc053-107">Dos and don'ts</span></span>


**<span data-ttu-id="dc053-108">パン インジケーターとスクロール バー</span><span class="sxs-lookup"><span data-stu-id="dc053-108">Panning indicators and scroll bars</span></span>**

-   <span data-ttu-id="dc053-109">アプリにコンテンツを読み込む前に、パン/スクロールが可能であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="dc053-109">Ensure panning/scrolling is possible before loading content into your app.</span></span>

-   <span data-ttu-id="dc053-110">パン インジケーターとスクロール バーを表示して、位置とサイズがわかるようにします。カスタム ナビゲーション機能を提供する場合には、これらのコントロールを非表示にします。</span><span class="sxs-lookup"><span data-stu-id="dc053-110">Display panning indicators and scroll bars to provide location and size cues. Hide them if you provide a custom navigation feature.</span></span>

    <span data-ttu-id="dc053-111">**注:** 標準的なスクロール バー、パン インジケーターとは異なりは純粋なわかりやすいでしょう。</span><span class="sxs-lookup"><span data-stu-id="dc053-111">**Note**Unlike standard scroll bars, panning indicators are purely informative.</span></span> <span data-ttu-id="dc053-112">入力デバイスには公開されず、一切操作できません。</span><span class="sxs-lookup"><span data-stu-id="dc053-112">They are not exposed to input devices and cannot be manipulated in any way.</span></span>

     

**<span data-ttu-id="dc053-113">単一軸パン (1 次元のオーバーフロー)</span><span class="sxs-lookup"><span data-stu-id="dc053-113">Single-axis panning (one-dimensional overflow)</span></span>**

-   <span data-ttu-id="dc053-114">コンテンツ領域が 1 つのビューポート境界 (垂直方向または水平方向) を超えている場合は、単一軸のパンを使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-114">Use one-axis panning for content regions that extend beyond one viewport boundary (vertical or horizontal).</span></span>

    -   <span data-ttu-id="dc053-115">1 次元の項目の一覧の場合は、垂直方向のパンを使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-115">Vertical panning for a one-dimensional list of items.</span></span>
    -   <span data-ttu-id="dc053-116">項目のグリッドの場合は、水平方向のパンを使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-116">Horizontal panning for a grid of items.</span></span>
-   <span data-ttu-id="dc053-117">ユーザーのパン操作をスナップ位置以外の位置で停止できるようにする必要がある場合は、単一軸パンで強制スナップ位置を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="dc053-117">Don’t use mandatory snap-points with single-axis panning if a user must be able to pan and stop between snap-points.</span></span> <span data-ttu-id="dc053-118">強制スナップ位置を使うと、スナップ位置で必ず停止します。</span><span class="sxs-lookup"><span data-stu-id="dc053-118">Mandatory snap-points guarantee that the user will stop on a snap-point.</span></span> <span data-ttu-id="dc053-119">代わりに、近接スナップ位置を使ってください。</span><span class="sxs-lookup"><span data-stu-id="dc053-119">Use proximity snap-points instead.</span></span>

**<span data-ttu-id="dc053-120">フリーフォーム パン (2 次元のオーバーフロー)</span><span class="sxs-lookup"><span data-stu-id="dc053-120">Freeform panning (two-dimensional overflow)</span></span>**

-   <span data-ttu-id="dc053-121">コンテンツ領域が両方のビューポート境界 (垂直方向と水平方向) を超えている場合は、2 軸のパンを使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-121">Use two-axis panning for content regions that extend beyond both viewport boundaries (vertical and horizontal).</span></span>

    -   <span data-ttu-id="dc053-122">複数の方向へ動かされる可能性がある、構造化されていないコンテンツの場合は、既定のレール動作を上書きしてフリーフォーム パンを使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-122">Override the default rails behavior and use freeform panning for unstructured content where the user is likely to move in multiple directions.</span></span>
-   <span data-ttu-id="dc053-123">フリーフォーム パンは通常、画像や地図内の移動に適しています。</span><span class="sxs-lookup"><span data-stu-id="dc053-123">Freeform panning is typically suited to navigating within images or maps.</span></span>

**<span data-ttu-id="dc053-124">ページ ビュー</span><span class="sxs-lookup"><span data-stu-id="dc053-124">Paged view</span></span>**

-   <span data-ttu-id="dc053-125">コンテンツが個別の要素で構成されている場合、または 1 つの要素全体を表示する必要がある場合は、強制スナップ位置を使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-125">Use mandatory snap-points when the content is composed of discrete elements or you want to display an entire element.</span></span> <span data-ttu-id="dc053-126">書籍や雑誌のページ、項目の列、個々の画像がその例です。</span><span class="sxs-lookup"><span data-stu-id="dc053-126">This can include pages of a book or magazine, a column of items, or individual images.</span></span>

    -   <span data-ttu-id="dc053-127">スナップ位置はそれぞれの論理的な境界に置く必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-127">A snap-point should be placed at each logical boundary.</span></span>
    -   <span data-ttu-id="dc053-128">各要素のサイズや倍率を、ビューに収まるように調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-128">Each element should be sized or scaled to fit the view.</span></span>

**<span data-ttu-id="dc053-129">論理的な位置と主要位置</span><span class="sxs-lookup"><span data-stu-id="dc053-129">Logical and key points</span></span>**

-   <span data-ttu-id="dc053-130">コンテンツ内にユーザーが停止する可能性が高い主要位置または論理的な位置がある場合は、近接スナップ位置を使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-130">Use proximity snap-points if there are key points or logical places in the content that a user will likely stop.</span></span> <span data-ttu-id="dc053-131">たとえば、セクション ヘッダーなどです。</span><span class="sxs-lookup"><span data-stu-id="dc053-131">For example, a section header.</span></span>

-   <span data-ttu-id="dc053-132">最大サイズと最小サイズの制限または範囲が定義されている場合には、視覚的なフィードバックを使って、ユーザーがこの制限に達したことや超過したことを示します。</span><span class="sxs-lookup"><span data-stu-id="dc053-132">If maximum and minimum size constraints or boundaries are defined, use visual feedback to demonstrate when the user reaches or exceeds those boundaries.</span></span>

**<span data-ttu-id="dc053-133">埋め込まれたコンテンツまたは入れ子になったコンテンツの連結</span><span class="sxs-lookup"><span data-stu-id="dc053-133">Chaining embedded or nested content</span></span>**

-   <span data-ttu-id="dc053-134">テキストとグリッド ベースのコンテンツに対して単一軸パン (通常は水平方向) と列レイアウトを使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-134">Use single-axis panning (typically horizontal) and column layouts for text and grid-based content.</span></span> <span data-ttu-id="dc053-135">このような場合は、コンテンツは通常列から列へと自然に折り返し、遷移するので、UWP アプリ全体で一貫性があり見つけやすいユーザー エクスペリエンスを維持できます。</span><span class="sxs-lookup"><span data-stu-id="dc053-135">In these cases, content typically wraps and flows naturally from column to column and keeps the user experience consistent and discoverable across UWP apps.</span></span>

-   <span data-ttu-id="dc053-136">テキストまたは項目の一覧を表示する目的で、埋め込まれたパン対応領域を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="dc053-136">Don't use embedded pannable regions to display text or item lists.</span></span> <span data-ttu-id="dc053-137">領域内で入力の接触が検出されたときしかパン インジケーターとスクロール バーが表示されず、直感的で見つけやすいユーザー エクスペリエンスが得られません。</span><span class="sxs-lookup"><span data-stu-id="dc053-137">Because the panning indicators and scroll bars are displayed only when the input contact is detected within the region, it is not an intuitive or discoverable user experience.</span></span>

-   <span data-ttu-id="dc053-138">ここで示すように、2 つのパン対応領域がどちらも同じ方向にパンする場合は、パン対応領域を別のパン対応領域内に連結 (配置) しないでください。</span><span class="sxs-lookup"><span data-stu-id="dc053-138">Don't chain or place one pannable region within another pannable region if they both pan in the same direction, as shown here.</span></span> <span data-ttu-id="dc053-139">この場合に連結すると、子領域の境界に到達したときに親領域が意図せずパンされる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-139">This can result in the parent area being panned unintentionally when a boundary for the child area is reached.</span></span> <span data-ttu-id="dc053-140">パンの軸は相互に対して垂直になるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="dc053-140">Consider making the panning axis perpendicular.</span></span>

    ![コンテナーと同じ方向にスクロールする埋め込まれたパン対応領域を示す図](images/scrolling-embedded3.png)

## <a name="additional-usage-guidance"></a><span data-ttu-id="dc053-142">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="dc053-142">Additional usage guidance</span></span>

<span data-ttu-id="dc053-143">タッチでのパン (1 本または複数の指でのスワイプまたはスライド ジェスチャ) は、マウスでのスクロールと似ています。</span><span class="sxs-lookup"><span data-stu-id="dc053-143">Panning with touch, by using a swipe or slide gesture with one or more fingers, is like scrolling with the mouse.</span></span> <span data-ttu-id="dc053-144">パンはスクロール バーのクリックよりも、マウス ホイールの回転やスクロール ボックスのスライドに最も近い操作です。</span><span class="sxs-lookup"><span data-stu-id="dc053-144">The panning interaction is most similar to rotating the mouse wheel or sliding the scroll box, rather than clicking the scroll bar.</span></span> <span data-ttu-id="dc053-145">場合を除き、区別 API でいくつかのデバイスに固有の電源で必要とされる、単に両方の操作のパンと呼びます。</span><span class="sxs-lookup"><span data-stu-id="dc053-145">Unless a distinction is made in an API or required by some device-specific WindowsUI, we simply refer to both interactions as panning.</span></span>

> <div id="main">
> <strong><span data-ttu-id="dc053-146">Windows 10 Fall Creators Update - 動作の変更</span><span class="sxs-lookup"><span data-stu-id="dc053-146">Windows 10 Fall Creators Update - Behavior change</span></span></strong>
> </div>
> <span data-ttu-id="dc053-147">既定では、UWP アプリでのアクティブ ペンは、テキストの選択ではなく、(タッチ、タッチパッド、パッシブ ペンなどと同様に) スクロール/パンを実行するようになりました。</span><span class="sxs-lookup"><span data-stu-id="dc053-147">By default, instead of text selection, an active pen now scrolls/pans in UWP apps (like touch, touchpad, and passive pen).</span></span>  
> <span data-ttu-id="dc053-148">アプリが以前の動作に依存している場合は、ペン スクロールを上書きして、以前の動作に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="dc053-148">If your app depends on the previous behavior, you can override pen scrolling and revert to the previous behavior.</span></span> <span data-ttu-id="dc053-149">詳細については、 [ScrollViewer クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer)の API リファレンス トピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="dc053-149">See the [ScrollViewer Class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer) API reference topic for details.</span></span>

<span data-ttu-id="dc053-150">入力デバイスに応じて、ユーザーは次のいずれかを使って、パン対応領域内でパンを実行します。</span><span class="sxs-lookup"><span data-stu-id="dc053-150">Depending on the input device, the user pans within a pannable region by using one of these:</span></span>

-   <span data-ttu-id="dc053-151">マウス、タッチパッド、またはアクティブなペン/スタイラスを使って、スクロール矢印をクリックするか、スクロール ボックスをドラッグするか、スクロール バー内をクリックする。</span><span class="sxs-lookup"><span data-stu-id="dc053-151">A mouse, touchpad, or active pen/stylus to click the scroll arrows, drag the scroll box, or click within the scroll bar.</span></span>
-   <span data-ttu-id="dc053-152">マウスのホイール ボタンを使って、スクロール ボックスのドラッグと同じ動作を実現する。</span><span class="sxs-lookup"><span data-stu-id="dc053-152">The wheel button of the mouse to emulate dragging the scroll box.</span></span>
-   <span data-ttu-id="dc053-153">マウスでサポートされている場合は、拡張ボタン (XBUTTON1 と XBUTTON2)。</span><span class="sxs-lookup"><span data-stu-id="dc053-153">The extended buttons (XBUTTON1 and XBUTTON2), if supported by the mouse.</span></span>
-   <span data-ttu-id="dc053-154">キーボードの方向キーを使ってスクロール ボックスのドラッグと同じ動作を実現するか、ページ キーを使ってスクロール バー内のクリックと同じ動作を実現する。</span><span class="sxs-lookup"><span data-stu-id="dc053-154">The keyboard arrow keys to emulate dragging the scroll box or the page keys to emulate clicking within the scroll bar.</span></span>
-   <span data-ttu-id="dc053-155">タッチ、タッチパッド、またはパッシブなペン/スタイラスを使って、任意の方向に指をスライドまたはスワイプする。</span><span class="sxs-lookup"><span data-stu-id="dc053-155">Touch, touchpad, or passive pen/stylus to slide or swipe the fingers in the desired direction.</span></span>

<span data-ttu-id="dc053-156">スライドでは、指をパン方向にゆっくり移動します。</span><span class="sxs-lookup"><span data-stu-id="dc053-156">Sliding involves moving the fingers slowly in the panning direction.</span></span> <span data-ttu-id="dc053-157">これにより、コンテンツが指と同じ速度で同じ距離だけパンする 1 対 1 の関係ができます。</span><span class="sxs-lookup"><span data-stu-id="dc053-157">This results in a one-to-one relationship, where the content pans at the same speed and distance as the fingers.</span></span> <span data-ttu-id="dc053-158">スワイプ (指をすばやくスライドして離す) では、パンのアニメーションに次の物理的効果が適用されます。</span><span class="sxs-lookup"><span data-stu-id="dc053-158">Swiping, which involves rapidly sliding and lifting the fingers, results in the following physics being applied to the panning animation:</span></span>

-   <span data-ttu-id="dc053-159">減速 (慣性): 指を離すとパンが減速し始めます。</span><span class="sxs-lookup"><span data-stu-id="dc053-159">Deceleration (inertia): Lifting the fingers causes panning to start decelerating.</span></span> <span data-ttu-id="dc053-160">これは滑りやすい表面で滑っている状態から止まるまでの動きに似ています。</span><span class="sxs-lookup"><span data-stu-id="dc053-160">This is similar to sliding to a stop on a slippery surface.</span></span>
-   <span data-ttu-id="dc053-161">吸収: 減速時に、パン操作の勢いがスナップ位置またはコンテンツ領域の境界まで保たれた場合、反対方向に少し押し戻される効果があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-161">Absorption: Panning momentum during deceleration causes a slight bounce-back effect if either a snap point or a content area boundary is reached.</span></span>

**<span data-ttu-id="dc053-162">パンの種類</span><span class="sxs-lookup"><span data-stu-id="dc053-162">Types of panning</span></span>**

<span data-ttu-id="dc053-163">Windows8 には、3 種類のパンがサポートしています。</span><span class="sxs-lookup"><span data-stu-id="dc053-163">Windows8 supports three types of panning:</span></span>

-   <span data-ttu-id="dc053-164">単一軸: 一方向 (水平または垂直) へのパンのみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="dc053-164">Single axis - panning is supported in one direction only (horizontal or vertical).</span></span>
-   <span data-ttu-id="dc053-165">レール: 全方向へのパンがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="dc053-165">Rails - panning is supported in all directions.</span></span> <span data-ttu-id="dc053-166">ただし、特定の方向への距離のしきい値を超えると、パンはその軸に制限されます。</span><span class="sxs-lookup"><span data-stu-id="dc053-166">However, once the user crosses a distance threshold in a specific direction, then panning is restricted to that axis.</span></span>
-   <span data-ttu-id="dc053-167">フリーフォーム: 全方向へのパンがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="dc053-167">Freeform - panning is supported in all directions.</span></span>

**<span data-ttu-id="dc053-168">パンの UI</span><span class="sxs-lookup"><span data-stu-id="dc053-168">Panning UI</span></span>**

<span data-ttu-id="dc053-169">パンの操作エクスペリエンスは、機能的には類似していても、入力デバイスごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="dc053-169">The interaction experience for panning is unique to the input device while still providing similar functionality.</span></span>

<span data-ttu-id="dc053-170">**パン対応領域** パン対応領域の動作は、JavaScript を使った UWP アプリの開発者に対して、設計時にカスケード スタイル シート (CSS) を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="dc053-170">**Pannable regions** Pannable region behaviors are exposed to UWP app using JavaScript developers at design time through Cascading Style Sheets (CSS).</span></span>

<span data-ttu-id="dc053-171">検出された入力デバイスに基づいて、次の 2 種類のパン表示モードが使われます。</span><span class="sxs-lookup"><span data-stu-id="dc053-171">There are two panning display modes based on the input device detected:</span></span>

-   <span data-ttu-id="dc053-172">パン インジケーター (タッチを使う場合)。</span><span class="sxs-lookup"><span data-stu-id="dc053-172">Panning indicators for touch.</span></span>
-   <span data-ttu-id="dc053-173">スクロール バー (マウス、タッチパッド、キーボード、スタイラスなど、その他の入力デバイスを使う場合)。</span><span class="sxs-lookup"><span data-stu-id="dc053-173">Scroll bars for other input devices, including mouse, touchpad, keyboard, and stylus.</span></span>

<span data-ttu-id="dc053-174">**注:** パン インジケーターは、タッチによる接触がパン対応領域内にあるときにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc053-174">**Note**Panning indicators are only visible when the touch contact is within the pannable region.</span></span> <span data-ttu-id="dc053-175">同様に、スクロール バーは、スクロール対応領域内にマウス カーソル、ペン/スタイラス カーソル、またはキーボード フォーカスがあるときにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc053-175">Similarly, the scroll bar is only visible when the mouse cursor, pen/stylus cursor, or keyboard focus is within the scrollable region.</span></span>

 

<span data-ttu-id="dc053-176">**パン インジケーター** パン インジケーターは、スクロール バーのスクロール ボックスに似ています。</span><span class="sxs-lookup"><span data-stu-id="dc053-176">**Panning indicators** Panning indicators are similar to the scroll box in a scroll bar.</span></span> <span data-ttu-id="dc053-177">パン対応領域全体に対する表示されているコンテンツの比率と、パン対応領域内の表示されているコンテンツの相対的な位置を示します。</span><span class="sxs-lookup"><span data-stu-id="dc053-177">They indicate the proportion of displayed content to total pannable area and the relative position of the displayed content in the pannable area.</span></span>

<span data-ttu-id="dc053-178">次の図は、長さが異なる 2 つのパン対応領域とそれらのパン インジケーターを示しています。</span><span class="sxs-lookup"><span data-stu-id="dc053-178">The following diagram shows two pannable areas of different lengths and their panning indicators.</span></span>

![長さが異なる 2 つのパン対応領域とそれらのパン インジケーターを示す図](images/scrolling-indicators.png)

<span data-ttu-id="dc053-180">**パンの動作**
**スナップ位置** パンとスワイプ ジェスチャを使うと、タッチによる接触が離れたときの対話式操作に慣性の動作が生じます。</span><span class="sxs-lookup"><span data-stu-id="dc053-180">**Panning behaviors**
**Snap points** Panning with the swipe gesture introduces inertia behavior into the interaction when the touch contact is lifted.</span></span> <span data-ttu-id="dc053-181">慣性によって、コンテンツのパンは、ユーザーによる直接入力がなければ距離のしきい値に到達するまで継続されます。</span><span class="sxs-lookup"><span data-stu-id="dc053-181">With inertia, the content continues to pan until some distance threshold is reached without direct input from the user.</span></span> <span data-ttu-id="dc053-182">この慣性の動作を変更するには、スナップ位置を使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-182">Use snap points to modify this inertia behavior.</span></span>

<span data-ttu-id="dc053-183">スナップ位置は、アプリのコンテンツの論理的な停止を指定します。</span><span class="sxs-lookup"><span data-stu-id="dc053-183">Snap points specify logical stops in your app content.</span></span> <span data-ttu-id="dc053-184">スナップ位置は、認識に基づくユーザー用のページング メカニズムとして機能し、ユーザーが大きなパン対応領域でスライドまたはスワイプしすぎて疲れるのを防ぎます。</span><span class="sxs-lookup"><span data-stu-id="dc053-184">Cognitively, snap points act as a paging mechanism for the user and minimize fatigue from excessive sliding or swiping in large pannable regions.</span></span> <span data-ttu-id="dc053-185">これらを使用すると、不正確なユーザー入力を処理し、コンテンツの特定の部分や主要な情報がビューポートに確実に表示されるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="dc053-185">With them, you can handle imprecise user input and ensure a specific subset of content or key information is displayed in the viewport.</span></span>

<span data-ttu-id="dc053-186">スナップ位置には次の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-186">There are two types of snap-points:</span></span>

-   <span data-ttu-id="dc053-187">近接: 指を離した後、スナップ位置の距離のしきい値の範囲内で慣性に従った動きが止まると、スナップ位置が選ばれます。</span><span class="sxs-lookup"><span data-stu-id="dc053-187">Proximity - After the contact is lifted, a snap point is selected if inertia stops within a distance threshold of the snap point.</span></span> <span data-ttu-id="dc053-188">パンは近接スナップ位置の中間で停止することもできます。</span><span class="sxs-lookup"><span data-stu-id="dc053-188">Panning can still stop between proximity snap points.</span></span>
-   <span data-ttu-id="dc053-189">強制: 指を離す前に通過した最後のスナップ位置の直前または直後のスナップ位置が選ばれます (ジェスチャの方向と速度によって異なります)。</span><span class="sxs-lookup"><span data-stu-id="dc053-189">Mandatory - The snap point selected is the one that immediately precedes or succeeds the last snap point crossed before the contact was lifted (depending on the direction and velocity of the gesture).</span></span> <span data-ttu-id="dc053-190">パンは強制スナップ位置で停止する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-190">Panning must stop on a mandatory snap point.</span></span>

<span data-ttu-id="dc053-191">パンのスナップ位置は、ページ付けされたコンテンツと同じ動作を実現したり、項目を論理的にグループ化して、ビューポートまたはディスプレイに収まるように動的に再グループ化できるようにしたりする、Web ブラウザーやフォト アルバムのようなアプリで便利です。</span><span class="sxs-lookup"><span data-stu-id="dc053-191">Panning snap-points are useful for applications such as web browsers and photo albums that emulate paginated content or have logical groupings of items that can be dynamically regrouped to fit within a viewport or display.</span></span>

<span data-ttu-id="dc053-192">次の図は、特定の位置にパンして離すことでコンテンツを論理的な位置に自動的にパンする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="dc053-192">The following diagrams show how panning to a certain point and releasing causes the content to automatically pan to a logical location.</span></span>

|                                                                |                                                                                         |                                                                                                                 |
|----------------------------------------------------------------|-----------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------|
| ![パン対応領域を示す図](images/ux-panning-snap1.png) | ![左にパンされているパン対応領域を示す図](images/ux-panning-snap2.png) | ![論理的なスナップ位置でパンを停止したパン対応領域を示す図](images/ux-panning-snap3.png) |
| <span data-ttu-id="dc053-196">スワイプしてパンします。</span><span class="sxs-lookup"><span data-stu-id="dc053-196">Swipe to pan.</span></span>                                                  | <span data-ttu-id="dc053-197">タッチによる接触を離します。</span><span class="sxs-lookup"><span data-stu-id="dc053-197">Lift touch contact.</span></span>                                                                     | <span data-ttu-id="dc053-198">パン対応領域は、タッチによる接触が離れた場所ではなく、スナップ位置で停止します。</span><span class="sxs-lookup"><span data-stu-id="dc053-198">Pannable region stops at the snap point, not where the touch contact was lifted.</span></span>                                |

 

<span data-ttu-id="dc053-199">**レール** コンテンツは、ディスプレイ デバイスのサイズと解像度より広かったり高かったりする場合があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-199">**Rails** Content can be wider and taller than the dimensions and resolution of a display device.</span></span> <span data-ttu-id="dc053-200">このため、2 次元のパン (水平方向と垂直方向) が必要になることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="dc053-200">For this reason, two-dimensional panning (horizontal and vertical) is often necessary.</span></span> <span data-ttu-id="dc053-201">レールは、このような場合に動作の主軸 (垂直方向または水平方向) に沿ってパンを強調表示することで、ユーザー エクスペリエンスを向上させます。</span><span class="sxs-lookup"><span data-stu-id="dc053-201">Rails improve the user experience in these cases by emphasizing panning along the axis of motion (vertical or horizontal).</span></span>

<span data-ttu-id="dc053-202">次の図は、レールの概念を示しています。</span><span class="sxs-lookup"><span data-stu-id="dc053-202">The following diagram demonstrates the concept of rails.</span></span>

![パンを制約するレールの画面の図](images/ux-panning-rails.png)

**<span data-ttu-id="dc053-204">埋め込まれたコンテンツまたは入れ子になったコンテンツの連結</span><span class="sxs-lookup"><span data-stu-id="dc053-204">Chaining embedded or nested content</span></span>**

<span data-ttu-id="dc053-205">他のズーム可能またはスクロール可能な要素の入れ子になっている要素のズームまたはスクロールが限界に達した後で、親要素が子要素のズーム操作またはスクロール操作を継続して開始するかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="dc053-205">After a user hits a zoom or scroll limit on an element that has been nested within another zoomable or scrollable element, you can specify whether that parent element should continue the zooming or scrolling operation begun in its child element.</span></span> <span data-ttu-id="dc053-206">これはズームまたはスクロールのチェーンと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="dc053-206">This is called zoom or scroll chaining.</span></span>

<span data-ttu-id="dc053-207">1 つ以上の単一軸パン領域またはフリーフォーム パン領域が含まれる単一軸のコンテンツ領域内で (これらの子領域のいずれかでタッチによる接触があったときに) パンを行う場合は、連結を使います。</span><span class="sxs-lookup"><span data-stu-id="dc053-207">Chaining is used for panning within a single-axis content area that contains one or more single-axis or freeform panning regions (when the touch contact is within one of these child regions).</span></span> <span data-ttu-id="dc053-208">子領域の特定の方向のパン境界に到達すると、親領域の同じ方向にパンがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="dc053-208">When the panning boundary of the child region is reached in a specific direction, panning is then activated on the parent region in the same direction.</span></span>

<span data-ttu-id="dc053-209">パン対応領域を別のパン対応領域内に入れ子にするときは、コンテナーと埋め込まれたコンテンツ間に十分な領域を指定することが重要です。</span><span class="sxs-lookup"><span data-stu-id="dc053-209">When a pannable region is nested inside another pannable region it's important to specify enough space between the container and the embedded content.</span></span> <span data-ttu-id="dc053-210">次の図では、パン対応領域が別のパン対応領域内に置かれており、それぞれが相互に対して垂直方向に移動します。</span><span class="sxs-lookup"><span data-stu-id="dc053-210">In the following diagrams, one pannable region is placed inside another pannable region, each going in perpendicular directions.</span></span> <span data-ttu-id="dc053-211">各領域にユーザーがパンできる十分な領域があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-211">There is plenty of space for users to pan in each region.</span></span>

![埋め込まれたパン対応領域を示す図](images/scrolling-embedded.png)

<span data-ttu-id="dc053-213">十分な領域がないと、次の図に示すように、埋め込まれたパン対応領域によってコンテナーでのパンが妨げられ、1 つ以上のパン対応領域で意図しないパンが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dc053-213">Without enough space, as shown in the following diagram, the embedded pannable region can interfere with panning in the container and result in unintentional panning in one or more of the pannable regions.</span></span>

![埋め込まれたパン対応領域の余白不足を示す図](images/ux-panning-embedded-wrong.png)

<span data-ttu-id="dc053-215">このガイダンスは、たとえば、フォト アルバムや地図のようなアプリでも役に立ちます。各画像または地図内の制約のないパンをサポートしながら、アルバム内の前の画像または次の画像や詳細な領域への単一軸パンもサポートできます。</span><span class="sxs-lookup"><span data-stu-id="dc053-215">This guidance is also useful for apps such as photo albums or mapping apps that support unconstrained panning within an individual image or map while also supporting single-axis panning within the album (to the previous or next images) or details area.</span></span> <span data-ttu-id="dc053-216">フリーフォーム パンの画像や地図に対応する詳細領域またはオプション領域を提供するアプリでは、ページ レイアウトを詳細領域やオプション領域で始めることをお勧めします。画像や地図の制約のないパン領域が、詳細領域へのパンを妨げる可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="dc053-216">In apps that provide a detail or options area corresponding to a freeform panning image or map, we recommend that the page layout start with the details and options area as the unconstrained panning area of the image or map might interfere with panning to the details area.</span></span>

## <a name="related-articles"></a><span data-ttu-id="dc053-217">関連記事</span><span class="sxs-lookup"><span data-stu-id="dc053-217">Related articles</span></span>


* [<span data-ttu-id="dc053-218">カスタム ユーザー操作</span><span class="sxs-lookup"><span data-stu-id="dc053-218">Custom user interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185599)
* [<span data-ttu-id="dc053-219">ListView と GridView の最適化</span><span class="sxs-lookup"><span data-stu-id="dc053-219">Optimize ListView and GridView</span></span>](https://msdn.microsoft.com/library/windows/apps/mt204776)
* [<span data-ttu-id="dc053-220">キーボードのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="dc053-220">Keyboard accessibility</span></span>](https://msdn.microsoft.com/library/windows/apps/mt244347)

**<span data-ttu-id="dc053-221">サンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-221">Samples</span></span>**
* [<span data-ttu-id="dc053-222">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-222">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="dc053-223">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-223">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="dc053-224">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-224">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="dc053-225">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-225">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="dc053-226">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="dc053-226">Archive samples</span></span>**
* [<span data-ttu-id="dc053-227">入力: XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-227">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="dc053-228">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-228">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="dc053-229">入力: タッチのヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-229">Input: Touch hit testing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="dc053-230">XAML のスクロール、パン、ズームのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="dc053-230">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="dc053-231">入力: 簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-231">Input: Simplified ink sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="dc053-232">入力: Windows 8 のジェスチャのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="dc053-232">Input: Windows 8 gestures sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="dc053-233">入力: 操作とジェスチャ (C++) のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="dc053-233">Input: Manipulations and gestures (C++) sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="dc053-234">DirectX タッチ入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="dc053-234">DirectX touch input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 




