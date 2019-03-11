---
description: ''
title: オブジェクトとしてのコンテンツ
template: detail.hbs
ms.localizationpriority: medium
ms.openlocfilehash: ed2ac8530d69929cc0e0e921cfb1cc5368058cd2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593117"
---
# <a name="content-as-objects"></a><span data-ttu-id="4f5f2-102">オブジェクトとしてのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="4f5f2-102">Content as objects</span></span>

 

<span data-ttu-id="4f5f2-103">要素の深度、つまり z オーダーを操作し、視覚的な階層を作成すると、アプリを簡単に使用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-103">You can manipulating the depth, or z-order, of elements to create a visual hierarchy that helps makes your app easier to use.</span></span>  

> <span data-ttu-id="4f5f2-104">注:この記事では、Windows 10 RS2 の新機能の初期ドラフトです。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-104">Note: This article is an early draft for a new feature of Windows 10 RS2.</span></span> <span data-ttu-id="4f5f2-105">機能名、用語、および機能は最終版ではありません。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-105">Feature names, terminology, and functionality are not final.</span></span> 

## <a name="why-visual-hierarchy-is-important"></a><span data-ttu-id="4f5f2-106">視覚的な階層が重要な理由</span><span class="sxs-lookup"><span data-stu-id="4f5f2-106">Why visual hierarchy is important</span></span>

<span data-ttu-id="4f5f2-107">注意を必要とする要求が絶えず表示されます。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-107">Users are constantly being bombarded with requests for their attention.</span></span> <span data-ttu-id="4f5f2-108">画面上のすべての要素が表示され、テキストのすべての文字列が読み取れ、すべてのボタンがクリックできます。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-108">Every element on the screen begs to be looked at, every string of text wants to be read, every button clicked.</span></span> <span data-ttu-id="4f5f2-109">視覚的な環境がより混乱かつ複雑になるにつれて、状況を把握し、何が起こっているかを理解するのに時間がかかります。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-109">As the visual environment grows more jumbled and chaotic, it takes more effort to parse the scene and figure out what's going on.</span></span>  

<span data-ttu-id="4f5f2-110">このため、ユーザー インターフェイスの要素を慎重に選択し、UI 要素間で分かりやすい視覚的な階層を確立するレイアウトを作成することが重要です。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-110">That's why it's so important to carefully select the elements of your user interface, and why it's important to create a layout that establishes a clear visual hierarchy among your UI elements.</span></span> <!-- Every element is competing for the user's attention, and every time you add an element, you add a mental tax to the user. -->

<span data-ttu-id="4f5f2-111">視覚的な階層を分かりやすくすると、最も重要な要素が明確になり、要素間の関係が確立されます。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-111">A clear visual hierarchy tells users which elements are the most important and creates relationships between the elements.</span></span> <span data-ttu-id="4f5f2-112">視覚的な階層が優れていると、ページのレイアウトを一目で理解し、実行しようとしているタスクに集中できます。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-112">With a good visual hierarchy, users understand the layout of the page at a glance and can focus on the task they're trying to accomplish.</span></span> 

<p></p>


<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
  <p><span data-ttu-id="4f5f2-113">それでは、分かりやすい視覚的な階層はどのように作成するのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-113">So, how do you create a clear visual hierarchy?</span></span> <span data-ttu-id="4f5f2-114">以前のバージョンの Windows 10 では、視覚的な階層を定義するために、空白、位置、および文字体裁を使用することができました。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-114">With earlier versions of Windows 10, you could use white space, position, and typography to define a visual hierarchy.</span></span> </p>
  </div>
  <div class="side-by-side-content-right"><span data-ttu-id="4f5f2-115">
    <a href="images/content-as-objects/flat-layout.png">フラットなレイアウト</a>
    
  </span><span class="sxs-lookup"><span data-stu-id="4f5f2-115">
    <a href="images/content-as-objects/flat-layout.png">A flat layout</a>
    
  </span></span></div>
</div>
</div>

<span data-ttu-id="4f5f2-116">Windows 10 RS2 では、深度という文字通り別の次元が追加されました。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-116">With Windows 10 RS2, we literally added another dimension: depth.</span></span> 

<span data-ttu-id="4f5f2-117"><a href="images/content-as-objects/depth-in-layout2.png">レイアウト内での深度</a></span><span class="sxs-lookup"><span data-stu-id="4f5f2-117"><a href="images/content-as-objects/depth-in-layout2.png">Depth in layout</a></span></span>


## <a name="use-depth-to-establish-a-hierarchy"></a><span data-ttu-id="4f5f2-118">深度を使用して階層を確立する</span><span class="sxs-lookup"><span data-stu-id="4f5f2-118">Use depth to establish a hierarchy</span></span> 

<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
     <p><span data-ttu-id="4f5f2-119">深度 (z オーダー) を他のデザイン ツール (空白、位置、文字体裁) と共に使用すると、階層を確立できます。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-119">You can use depth (z-order), along with your other design tools (whitespace, position, typography) to establish a hierarchy.</span></span> <span data-ttu-id="4f5f2-120">最も重要な要素を一番手前のレイヤーに昇格します。重要度の低い UI を表示するには、下位のレイヤーを使用します。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-120">Elevate your most important elements to the forward-most layer; use lower layers to display less critical UI.</span></span> 

    The relative importance of an element can change throughout an experience, so you can bring elements forward as they become more important and backward as they become less important. 
    </p>
  </div>
  <div class="side-by-side-content-right"><span data-ttu-id="4f5f2-121">
    <a href="images/content-as-objects/elements-forward-backward.png">レイアウト内での深度</a> 
    
  </span><span class="sxs-lookup"><span data-stu-id="4f5f2-121">
    <a href="images/content-as-objects/elements-forward-backward.png">Depth in layout</a> 
    
  </span></span></div>
</div>
</div>

## <a name="how-does-it-work"></a><span data-ttu-id="4f5f2-122">その場合、どのように処理されますか?</span><span class="sxs-lookup"><span data-stu-id="4f5f2-122">How does it work?</span></span>
> <span data-ttu-id="4f5f2-123">TODO:要素の z オーダーを制御する方法の簡単な説明。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-123">TODO: Brief description of how you can control the z-order of elements.</span></span> <span data-ttu-id="4f5f2-124">z オーダーを明示的にハードコードするために、セマンティック ランク付けシステムはありますか?</span><span class="sxs-lookup"><span data-stu-id="4f5f2-124">To you explicitly hard-code the z-order, or is there a semantic ranking system?</span></span> <span data-ttu-id="4f5f2-125">項目を 1 つのレイヤーから別のレイヤーにどのように移動しますか?</span><span class="sxs-lookup"><span data-stu-id="4f5f2-125">How do items move from one layer to another?</span></span> <span data-ttu-id="4f5f2-126">システムが自動的に処理する内容、デザイナー/開発者が気を付けることは何ですか?</span><span class="sxs-lookup"><span data-stu-id="4f5f2-126">What does the system do automatically, and what do designers/developers need to worry about?</span></span> 

## <a name="the-four-layers-of-a-typical-app-layers"></a><span data-ttu-id="4f5f2-127">一般的なアプリの 4 つのレイヤー</span><span class="sxs-lookup"><span data-stu-id="4f5f2-127">The four layers of a typical app layers</span></span>

<p><span data-ttu-id="4f5f2-128">一般的なアプリには 4 つのレイヤーがあります。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-128">A typical app has 4 layers.</span></span></p>
<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left"><span data-ttu-id="4f5f2-129">
<b>バック グラウンドを超えて</b>アプリの背後にあるこのレイヤーに存在します。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-129">
<b>Beyond background</b> This layer lives behind the app.</span></span>  <span data-ttu-id="4f5f2-130">要素をこのレイヤーに移動する場合は、非対話型の要素にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-130">When elements move to this layer, we recommend making them non-interactive.</span></span> <span data-ttu-id="4f5f2-131">このレイヤーの要素は、視差が最も少なく、アプリ ウィンドウにクリップされます。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-131">Elements at this layer has the slowest parallax and are clipped to the app window.</span></span> <span data-ttu-id="4f5f2-132">TODO:この層はスケールですか。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-132">TODO: Does this layer scale?</span></span> 

<p><span data-ttu-id="4f5f2-133">背景要素の例では、コンテンツ、TODO の背後にあるイメージを含めます。例では、TODO:例です。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-133">Example background elements include image behind content, TODO: Example, TODO: Example.</span></span></p>
  </div>
  <div class="side-by-side-content-right"><span data-ttu-id="4f5f2-134">
    <a href="images/content-as-objects/elements-forward-backward.png">以外にも、アプリのレイヤーをバック グラウンドします。</a>
    
  </span><span class="sxs-lookup"><span data-stu-id="4f5f2-134">
    <a href="images/content-as-objects/elements-forward-backward.png">The beyond background layer of an app</a>
    
  </span></span></div>
</div>
</div>

<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left"><span data-ttu-id="4f5f2-135">
<b>パッシブ レイヤー</b>アプリの基本レイヤーは、この既定ではどこで UI 要素。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-135">
<b>Passive layer</b> This is the base layer of the app, where UI elements live by default.</span></span>  <span data-ttu-id="4f5f2-136">要素はこのレイヤー上をリアルタイムに移動し (視差なし)、アプリ ウィンドウにクリップされます。倍率は 100% です。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-136">Elements move in real-time on this layer (no parallax), are clipped to the app window, and are rendered at 100% scale.</span></span> 

<p><span data-ttu-id="4f5f2-137">要素の例:アプリの背景、テキスト、アプリのナビゲーション UI などのセカンダリ UI。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-137">Example elements: The app background, text, secondary UI, such as app navigation UI.</span></span></p>
  </div>
  <div class="side-by-side-content-right"><span data-ttu-id="4f5f2-138">
    <a href="images/content-as-objects/elements-forward-backward.png">アプリのパッシブ レイヤー</a>
    
  </span><span class="sxs-lookup"><span data-stu-id="4f5f2-138">
    <a href="images/content-as-objects/elements-forward-backward.png">The passive layer of an app</a>
    
  </span></span></div>
</div>
</div>

<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left"><span data-ttu-id="4f5f2-139">
<b>行動喚起</b>この層はパッシブ レイヤー要素の上に優先する対話型の項目。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-139">
<b>Calls to action</b> This layer is for interactive items that you prioritize above passive layer elements.</span></span> <span data-ttu-id="4f5f2-140">このレイヤーの要素は、中程度の視差があり、アプリ ウィンドウにクリップされます。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-140">Elements on this layer have medium parallax and are clipped to the app window.</span></span> <span data-ttu-id="4f5f2-141">TODO:この層のスケールの要素のドロップ シャドウがあるか</span><span class="sxs-lookup"><span data-stu-id="4f5f2-141">TODO: Do elements at this layer scale or have a drop shadow?</span></span>

<p><span data-ttu-id="4f5f2-142">要素の例: リスト、グリッド、主要なコマンド (TODO:Such as.)。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-142">Example elements: lists, grids, primary commands (TODO: Such as...).</span></span></p> 
  </div>
  <div class="side-by-side-content-right"><span data-ttu-id="4f5f2-143">
    <a href="images/content-as-objects/elements-forward-backward.png">アプリのアクション呼び出しレイヤー</a>
    
  </span><span class="sxs-lookup"><span data-stu-id="4f5f2-143">
    <a href="images/content-as-objects/elements-forward-backward.png">The call-to-action layer of an app</a>
    
  </span></span></div>
</div>
</div>

<p></p>
<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left"><span data-ttu-id="4f5f2-144">
<b>Hero レイヤー</b>時にこのレイヤーでは、画面上の最高の優先度要素をします。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-144">
<b>Hero layer</b> This layer is for the highest priority element on the screen at the time.</span></span>  <span data-ttu-id="4f5f2-145">このレイヤーの要素はアプリ ウィンドウの境界を分割したり、拡大縮小したり、ドロップ シャドウを自動的に追加したりできます。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-145">Elements on this layer can break the bounds of the app window, they can scale, and they automatically get a drop shadow.</span></span>

<p><span data-ttu-id="4f5f2-146">要素の例: 写真要素、現在選択されている項目。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-146">Example elements: photographic elements, the currently selected item.</span></span></p>  
  </div>
  <div class="side-by-side-content-right"><span data-ttu-id="4f5f2-147">
    <a href="images/content-as-objects/elements-forward-backward.png">アプリのヒーロー レイヤー</a>
    
  </span><span class="sxs-lookup"><span data-stu-id="4f5f2-147">
    <a href="images/content-as-objects/elements-forward-backward.png">The hero layer of an app</a>
    
  </span></span></div>
</div>
</div>



<!--
Depth is meaningful; it establishes visual and interactive hierarchy for users to efficiently complete tasks. Depth orients users in our system. 
-->

## <a name="example-tbd"></a><span data-ttu-id="4f5f2-148">以下に例を示します。TBD</span><span class="sxs-lookup"><span data-stu-id="4f5f2-148">Example: TBD</span></span>
> <span data-ttu-id="4f5f2-149">TODO:Z オーダーを使用する一般的な UI パターンを調整する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-149">TODO: Show how to adapt a common UI pattern to use z-ordering.</span></span> <span data-ttu-id="4f5f2-150">図とコードを示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-150">We should show illustrations and code.</span></span> 

## <a name="download-the-code-samples"></a><span data-ttu-id="4f5f2-151">コード サンプルのダウンロード</span><span class="sxs-lookup"><span data-stu-id="4f5f2-151">Download the code samples</span></span>
><span data-ttu-id="4f5f2-152">TODO:この機能を示すサンプルへのリンクします。</span><span class="sxs-lookup"><span data-stu-id="4f5f2-152">TODO: Link to samples that demonstrate this feature.</span></span> 


## <a name="related-articles"></a><span data-ttu-id="4f5f2-153">関連記事</span><span class="sxs-lookup"><span data-stu-id="4f5f2-153">Related articles</span></span>
* [<span data-ttu-id="4f5f2-154">コンテンツの基本</span><span class="sxs-lookup"><span data-stu-id="4f5f2-154">Content basics</span></span>](../basics/content-basics.md)
