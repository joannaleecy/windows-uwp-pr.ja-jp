---
author: mijacobs
Description: Purposeful, well-designed motion brings your app to life and makes the experience feel crafted and polished. Help users understand context changes, and tie experiences together with visual transitions.
title: UWP アプリでのモーションとアニメーション
ms.assetid: 21AA1335-765E-433A-85D8-560B340AE966
label: Motion
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: jeffarn
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 1423aeff139758c780dcecb079141744931cdd7b
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1816537"
---
# <a name="motion-for-uwp-apps"></a><span data-ttu-id="be1ed-103">UWP アプリのモーション</span><span class="sxs-lookup"><span data-stu-id="be1ed-103">Motion for UWP apps</span></span>

<span data-ttu-id="be1ed-104">目的がはっきりとしており、適切にデザインされたモーションは、アプリに強い印象を与え、精巧で完成度の高い操作性を感じさせます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-104">Purposeful, well-designed motion brings your app to life and makes the experience feel crafted and polished.</span></span> <span data-ttu-id="be1ed-105">モーションは、ユーザーがコンテキストの変化を認識したり、アプリのナビゲーション階層のどこにいるかを把握したりする際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-105">Motion helps your users understand context changes and where they are within your app’s navigation hierarchy.</span></span> <span data-ttu-id="be1ed-106">またモーションによって、視覚的な切り替えとエクスペリエンスが結び付けられます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-106">It ties experiences together with visual transitions.</span></span> <span data-ttu-id="be1ed-107">モーションは、エクスペリエンスにペース配分と次元の感覚を追加します。</span><span class="sxs-lookup"><span data-stu-id="be1ed-107">Motion adds a sense of pacing and dimensionality to the experience.</span></span>

## <a name="benefits-of-motion"></a><span data-ttu-id="be1ed-108">モーションのメリット</span><span class="sxs-lookup"><span data-stu-id="be1ed-108">Benefits of motion</span></span>

<span data-ttu-id="be1ed-109">モーションは、単にものを動かすだけではありません。</span><span class="sxs-lookup"><span data-stu-id="be1ed-109">Motion is more than making things move.</span></span> <span data-ttu-id="be1ed-110">モーションは、ユーザーとアプリの関係を強化し、マウス、キーボード、タッチ、ペンなど、さまざまな種類の入力を通じて操作するための物理的なエコシステムを作り出すツールです。</span><span class="sxs-lookup"><span data-stu-id="be1ed-110">Motion is a tool for creating a physical ecosystem for the user to live inside and manipulate through a variety of input types, like mouse, keyboard, touch, and pen.</span></span> <span data-ttu-id="be1ed-111">エクスペリエンスの品質は、ユーザーに対するアプリの反応の良さと、UI が伝える個性の種類によって変わります。</span><span class="sxs-lookup"><span data-stu-id="be1ed-111">The quality of the experience depends on how well the app responds to the user, and what kind of personality the UI communicates.</span></span>

<span data-ttu-id="be1ed-112">モーションがアプリで目的を果たしていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="be1ed-112">Make sure motion serves a purpose in your app.</span></span> <span data-ttu-id="be1ed-113">優れたユニバーサル Windows プラットフォーム (UWP) アプリでは、モーションを使って UI を魅力的なものにしています。</span><span class="sxs-lookup"><span data-stu-id="be1ed-113">The best Universal Windows Platform (UWP) apps use motion to bring the UI to life.</span></span> <span data-ttu-id="be1ed-114">モーションは次の条件を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="be1ed-114">Motion should:</span></span>

- <span data-ttu-id="be1ed-115">ユーザーの動作に基づいてフィードバックを提供する。</span><span class="sxs-lookup"><span data-stu-id="be1ed-115">Give feedback based on the user's behavior.</span></span>
- <span data-ttu-id="be1ed-116">UI を操作する方法をユーザーに伝える。</span><span class="sxs-lookup"><span data-stu-id="be1ed-116">Teach the user how to interact with the UI.</span></span>
- <span data-ttu-id="be1ed-117">前または次のビューに移動する方法を示す。</span><span class="sxs-lookup"><span data-stu-id="be1ed-117">Indicate how to navigate to previous or succeeding views.</span></span>

<span data-ttu-id="be1ed-118">ユーザーがアプリ内で費やす時間が増えたり、アプリのタスクが高度になると、高品質なモーションの重要性が増します。モーションを使用すると、ユーザーが認識する際の負荷やアプリの使いやすさを感じる方法を変えることができます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-118">As a user spends more time inside your app, or as tasks in your app become more sophisticated, high-quality motion becomes increasingly important: it can be used to change how the user perceives their cognitive load and your app's ease of use.</span></span> <span data-ttu-id="be1ed-119">モーションには、他にも多くの直接的なメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="be1ed-119">Motion has many other direct benefits:</span></span>

- **<span data-ttu-id="be1ed-120">モーションは、操作と移動先の検出をサポートします。</span><span class="sxs-lookup"><span data-stu-id="be1ed-120">Motion supports interaction and wayfinding.</span></span>**

    <span data-ttu-id="be1ed-121">モーションには方向があり、前後に動いたり、コンテンツの内外に動いたりし、ユーザーが現在のビューまでどのように到達したかに関する概念的な "階層リンク" のような手掛かりを残します。</span><span class="sxs-lookup"><span data-stu-id="be1ed-121">Motion is directional: it moves forward and backward, in and out of content, leaving mental "breadcrumb" clues as to how the user arrived at the present view.</span></span> <span data-ttu-id="be1ed-122">切り替えによって、ユーザーは既によく知っているタスクとの類似性を引き出して新しいアプリケーションの操作方法を学習できます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-122">Transitions can help users learn how to operate new applications by drawing analogies to tasks that the user is already familiar with.</span></span>

- **<span data-ttu-id="be1ed-123">モーションは、パフォーマンスが向上した印象を与えます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-123">Motion can give the impression of enhanced performance.</span></span>**

    <span data-ttu-id="be1ed-124">ネットワークが遅延したり、システムが動作を一時停止したとき、アニメーションによってユーザーが感じる待ち時間を短くできます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-124">When network speeds lag or the system pauses to work, animations can make the user's wait feel shorter.</span></span> <span data-ttu-id="be1ed-125">アニメーションを使うと、ユーザーはアプリがフリーズしているのではなく処理中であることを知ることができ、ユーザーが関心を持つ可能性のある新しい情報を受動的に表示することができます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-125">Animations can be used to let the user know that the app is processing, not frozen, and it can passively surface new information that the user may be interested in.</span></span>

- **<span data-ttu-id="be1ed-126">モーションは、個性を加えます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-126">Motion adds personality.</span></span>**

    <span data-ttu-id="be1ed-127">モーションは、共通のスレッドを持つ場合があります。これにより、ユーザーがエクスペリエンスに沿って操作するときに、アプリの特徴を伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-127">Motion is often the common thread that communicates your apps personality as a user moves through an experience.</span></span>

- **<span data-ttu-id="be1ed-128">モーションは、洗練された印象を高めます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-128">Motion adds elegance.</span></span>**

    <span data-ttu-id="be1ed-129">滑らかで応答性の高いモーションによって、自然な操作性を感じさせるエクスペリエンスが実現され、エクスペリエンスとの感情面の結び付きが生みだされます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-129">Fluid, responsive, motion makes experiences feel natural, creating emotional connections to the experience.</span></span>

## <a name="examples-of-motion"></a><span data-ttu-id="be1ed-130">モーションの例</span><span class="sxs-lookup"><span data-stu-id="be1ed-130">Examples of motion</span></span>

<span data-ttu-id="be1ed-131">アプリでのモーションの例をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="be1ed-131">Here are some examples of motion in an app.</span></span>

<span data-ttu-id="be1ed-132">次の例では、アプリは接続型アニメーションを使用して項目の画像をアニメーション化し、その画像が "途切れることなく" 切り替わり、次のページにあるヘッダーの一部となります。</span><span class="sxs-lookup"><span data-stu-id="be1ed-132">Here, an app uses a connected animation to animate an item image as it “continues” to become part of the header of the next page.</span></span> <span data-ttu-id="be1ed-133">この効果を利用すると、画面の切り替えでユーザー コンテキストを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-133">The effect helps maintain user context across the transition.</span></span>

![接続型アニメーション](images/connected-animations/example.gif)

<span data-ttu-id="be1ed-135">次の例では、視覚的な視差効果を利用し、UI のスクロールやパンを行うときに、さまざまなオブジェクトをさまざまな速度で動かします。これにより、奥行き、遠近感、および動きといった感覚が引き起こされます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-135">Here, a visual parallax effect moves different objects at different rates when the UI scrolls or pans to create a feeling of depth, perspective, and movement.</span></span>

![リストと背景画像を使用した視差の例](images/_Parallax_v2.gif)


## <a name="types-of-motion"></a><span data-ttu-id="be1ed-137">モーションの種類</span><span class="sxs-lookup"><span data-stu-id="be1ed-137">Types of motion</span></span>

<table>
    <tr>
        <th align="left"><span data-ttu-id="be1ed-138">モーションの種類</span><span class="sxs-lookup"><span data-stu-id="be1ed-138">Motion type</span></span></th>
        <th align="left"><span data-ttu-id="be1ed-139">説明</span><span class="sxs-lookup"><span data-stu-id="be1ed-139">Description</span></span></th>
    </tr>
    <tr>
        <td><a href="motion-list.md"><span data-ttu-id="be1ed-140">追加と削除</span><span class="sxs-lookup"><span data-stu-id="be1ed-140">Add and delete</span></span></a>
        </td>
        <td><span data-ttu-id="be1ed-141">リスト アニメーションを使うと、写真のアルバムや検索結果の一覧などのコレクションに対して任意の数の項目を挿入または削除できます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-141">List animations let you insert or remove single or multiple items from a collection, such as a photo album or a list of search results.</span></span>
        </td>
    </tr>
    <tr>
        <td><a href="connected-animation.md"><span data-ttu-id="be1ed-142">接続型アニメーション</span><span class="sxs-lookup"><span data-stu-id="be1ed-142">Connected animation</span></span></a>
        </td>
        <td><span data-ttu-id="be1ed-143">接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-143">Connected animations let you create a dynamic and compelling navigation experience by animating the transition of an element between two different views.</span></span> <span data-ttu-id="be1ed-144">これにより、ユーザーはコンテキストを維持して、ビューの間の継続性を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-144">This helps the user maintain their context and provides continuity between the views.</span></span> <span data-ttu-id="be1ed-145">接続型アニメーションでは、UI コンテンツが変化するとき (画面間を移動して、ソース ビュー内の要素の場所から新しいビュー内の切り替え先となる場所が表示されるとき)、要素が 2 つのビューの間で "途切れることなく" 表示されます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-145">In a connected animation, an element appears to “continue” between two views during a change in UI content, flying across the screen from its location in the source view to its destination in the new view.</span></span> <span data-ttu-id="be1ed-146">これにより、ビューの間で共通するコンテンツが強調され、要素が切り替わるときに魅力的で動的な効果が発生します。</span><span class="sxs-lookup"><span data-stu-id="be1ed-146">This emphasizes the common content in between the views and creates a beautiful and dynamic effect as part of a transition.</span></span> 
        </td>
    </tr>
    <tr>
        <td><a href="content-transition-animations.md"><span data-ttu-id="be1ed-147">コンテンツ切り替え</span><span class="sxs-lookup"><span data-stu-id="be1ed-147">Content transition</span></span></a>
        </td>
        <td><span data-ttu-id="be1ed-148">コンテンツ切り替えアニメーションを使うと、コンテナーや背景はそのままに、画面のある領域のコンテンツを変更できます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-148">Content transition animations let you change the content of an area of the screen while keeping the container or background constant.</span></span> <span data-ttu-id="be1ed-149">新しいコンテンツはフェード インします。</span><span class="sxs-lookup"><span data-stu-id="be1ed-149">New content fades in.</span></span> <span data-ttu-id="be1ed-150">既にあるコンテンツを差し替える場合、そのコンテンツはフェード アウトします。</span><span class="sxs-lookup"><span data-stu-id="be1ed-150">If there is existing content to be replaced, that content fades out.</span></span> </td>
    </tr>
    <tr>
        <td><a href="motion-fade.md"><span data-ttu-id="be1ed-151">フェード</span><span class="sxs-lookup"><span data-stu-id="be1ed-151">Fade</span></span></a>
        </td>
        <td><span data-ttu-id="be1ed-152">フェード アニメーションは、項目を画面に表示したり、項目を画面から非表示にするときに使います。</span><span class="sxs-lookup"><span data-stu-id="be1ed-152">Use fade animations to bring items into a view or to take items out of a view.</span></span> <span data-ttu-id="be1ed-153">一般的なフェード アニメーションは、フェード インとフェード アウトの 2 つです。</span><span class="sxs-lookup"><span data-stu-id="be1ed-153">The two common fade animations are fade-in and fade-out.</span></span> </td>
    </tr>
    <tr>
        <td><a href="page-transitions.md"><span data-ttu-id="be1ed-154">ページ切り替え効果</span><span class="sxs-lookup"><span data-stu-id="be1ed-154">Page transitions</span></span></a>
        </td>
        <td><span data-ttu-id="be1ed-155">ページ切り替え効果により、ユーザーがアプリ内のページ間を移動するため、ページ間の関係がフィードバックされます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-155">Page transitions navigate users between pages in an app, providing feedback as the relationship between pages.</span></span>
        </td>
    </tr>
    <tr>
        <td><a href="parallax.md"><span data-ttu-id="be1ed-156">視差</span><span class="sxs-lookup"><span data-stu-id="be1ed-156">Parallax</span></span></a>
        </td>
        <td><span data-ttu-id="be1ed-157">視覚的な視差効果を利用すると、奥行き、遠近感、動きといった感覚を引き起こすことができます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-157">A visual parallax effect helps create a feeling of depth, perspective, and movement.</span></span> <span data-ttu-id="be1ed-158">こうした効果は、UI のスクロールやパンを行うときに、さまざまなオブジェクトをさまざまな速度で動かすことによって実現されます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-158">It achieves this effect by moving different objects at different rates when the UI scrolls or pans.</span></span>
        </td>
    </tr> 
    <tr>
        <td><a href="motion-pointer.md"><span data-ttu-id="be1ed-159">タップやクリックのフィードバック</span><span class="sxs-lookup"><span data-stu-id="be1ed-159">Press feedback</span></span></a>
        </td>
        <td><span data-ttu-id="be1ed-160">ポインター プレス アニメーションは、ユーザーが項目をタップまたはクリックしたときに視覚的なフィードバックをユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="be1ed-160">Pointer press animations provide users with visual feedback when the user taps on an item.</span></span> <span data-ttu-id="be1ed-161">ポインター ダウン アニメーション (押された項目を若干縮小して傾ける) は、項目が最初にタップされたときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-161">The pointer down animation slightly shrinks and tilts the pressed item, and plays when an item is first tapped.</span></span> <span data-ttu-id="be1ed-162">ポインター アップ アニメーション (項目を元の位置に復元する) は、ユーザーがポインターから指を離したときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="be1ed-162">The pointer up animation, which restores the item to its original position, is played when the user releases the pointer.</span></span>
        </td>
    </tr>
</table>

## <a name="animations-in-xaml"></a><span data-ttu-id="be1ed-163">XAML でのアニメーション</span><span class="sxs-lookup"><span data-stu-id="be1ed-163">Animations in XAML</span></span>

<span data-ttu-id="be1ed-164">XAML で組み込みアニメーションを使用する方法または独自に作成する方法については、「[XAML のアニメーション](xaml-animation.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="be1ed-164">To learn more about how to use built-in animations in XAML or create your own, check out [Animations in XAML](xaml-animation.md).</span></span> 