---
author: mijacobs
Description: "目的がはっきりとしており、適切にデザインされたモーションは、アプリに強い印象を与え、精巧で完成度の高い操作性を感じさせます。 コンテキストの変化がわかりやすく、視覚的な切り替えがエクスペリエンスに結び付きます。"
title: "UWP アプリでのモーションとアニメーション"
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
ms.openlocfilehash: d24edf5eaacb65ca28f2f2727f441cb833141dcf
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="motion-for-uwp-apps"></a><span data-ttu-id="d81b4-105">UWP アプリのモーション</span><span class="sxs-lookup"><span data-stu-id="d81b4-105">Motion for UWP apps</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="d81b4-106">目的がはっきりとしており、適切にデザインされたモーションは、アプリに強い印象を与え、精巧で完成度の高い操作性を感じさせます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-106">Purposeful, well-designed motion brings your app to life and makes the experience feel crafted and polished.</span></span> <span data-ttu-id="d81b4-107">モーションは、ユーザーがコンテキストの変化を認識したり、アプリのナビゲーション階層のどこにいるかを把握したりする際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-107">Motion helps your users understand context changes and where they are within your app’s navigation hierarchy.</span></span> <span data-ttu-id="d81b4-108">またモーションによって、視覚的な切り替えとエクスペリエンスが結び付けられます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-108">It ties experiences together with visual transitions.</span></span> <span data-ttu-id="d81b4-109">モーションは、エクスペリエンスにペース配分と次元の感覚を追加します。</span><span class="sxs-lookup"><span data-stu-id="d81b4-109">Motion adds a sense of pacing and dimensionality to the experience.</span></span>

## <a name="benefits-of-motion"></a><span data-ttu-id="d81b4-110">モーションのメリット</span><span class="sxs-lookup"><span data-stu-id="d81b4-110">Benefits of motion</span></span>

<span data-ttu-id="d81b4-111">モーションは、単にものを動かすだけではありません。</span><span class="sxs-lookup"><span data-stu-id="d81b4-111">Motion is more than making things move.</span></span> <span data-ttu-id="d81b4-112">モーションは、ユーザーとアプリの関係を強化し、マウス、キーボード、タッチ、ペンなど、さまざまな種類の入力を通じて操作するための物理的なエコシステムを作り出すツールです。</span><span class="sxs-lookup"><span data-stu-id="d81b4-112">Motion is a tool for creating a physical ecosystem for the user to live inside and manipulate through a variety of input types, like mouse, keyboard, touch, and pen.</span></span> <span data-ttu-id="d81b4-113">エクスペリエンスの品質は、ユーザーに対するアプリの反応の良さと、UI が伝える個性の種類によって変わります。</span><span class="sxs-lookup"><span data-stu-id="d81b4-113">The quality of the experience depends on how well the app responds to the user, and what kind of personality the UI communicates.</span></span>

<span data-ttu-id="d81b4-114">モーションがアプリで目的を果たしていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="d81b4-114">Make sure motion serves a purpose in your app.</span></span> <span data-ttu-id="d81b4-115">優れたユニバーサル Windows プラットフォーム (UWP) アプリでは、モーションを使って UI を魅力的なものにしています。</span><span class="sxs-lookup"><span data-stu-id="d81b4-115">The best Universal Windows Platform (UWP) apps use motion to bring the UI to life.</span></span> <span data-ttu-id="d81b4-116">モーションは次の条件を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="d81b4-116">Motion should:</span></span>

- <span data-ttu-id="d81b4-117">ユーザーの動作に基づいてフィードバックを提供する。</span><span class="sxs-lookup"><span data-stu-id="d81b4-117">Give feedback based on the user's behavior.</span></span>
- <span data-ttu-id="d81b4-118">UI を操作する方法をユーザーに伝える。</span><span class="sxs-lookup"><span data-stu-id="d81b4-118">Teach the user how to interact with the UI.</span></span>
- <span data-ttu-id="d81b4-119">前または次のビューに移動する方法を示す。</span><span class="sxs-lookup"><span data-stu-id="d81b4-119">Indicate how to navigate to previous or succeeding views.</span></span>

<span data-ttu-id="d81b4-120">ユーザーがアプリ内で費やす時間が増えたり、アプリのタスクが高度になると、高品質なモーションの重要性が増します。モーションを使用すると、ユーザーが認識する際の負荷やアプリの使いやすさを感じる方法を変えることができます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-120">As a user spends more time inside your app, or as tasks in your app become more sophisticated, high-quality motion becomes increasingly important: it can be used to change how the user perceives their cognitive load and your app's ease of use.</span></span> <span data-ttu-id="d81b4-121">モーションには、他にも多くの直接的なメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="d81b4-121">Motion has many other direct benefits:</span></span>

- **<span data-ttu-id="d81b4-122">モーションは、操作と移動先の検出をサポートします。</span><span class="sxs-lookup"><span data-stu-id="d81b4-122">Motion supports interaction and wayfinding.</span></span>**

    <span data-ttu-id="d81b4-123">モーションには方向があり、前後に動いたり、コンテンツの内外に動いたりし、ユーザーが現在のビューまでどのように到達したかに関する概念的な "階層リンク" のような手掛かりを残します。</span><span class="sxs-lookup"><span data-stu-id="d81b4-123">Motion is directional: it moves forward and backward, in and out of content, leaving mental "breadcrumb" clues as to how the user arrived at the present view.</span></span> <span data-ttu-id="d81b4-124">切り替えによって、ユーザーは既によく知っているタスクとの類似性を引き出して新しいアプリケーションの操作方法を学習できます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-124">Transitions can help users learn how to operate new applications by drawing analogies to tasks that the user is already familiar with.</span></span>

- **<span data-ttu-id="d81b4-125">モーションは、パフォーマンスが向上した印象を与えます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-125">Motion can give the impression of enhanced performance.</span></span>**

    <span data-ttu-id="d81b4-126">ネットワークが遅延したり、システムが動作を一時停止したとき、アニメーションによってユーザーが感じる待ち時間を短くできます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-126">When network speeds lag or the system pauses to work, animations can make the user's wait feel shorter.</span></span> <span data-ttu-id="d81b4-127">アニメーションを使うと、ユーザーはアプリがフリーズしているのではなく処理中であることを知ることができ、ユーザーが関心を持つ可能性のある新しい情報を受動的に表示することができます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-127">Animations can be used to let the user know that the app is processing, not frozen, and it can passively surface new information that the user may be interested in.</span></span>

- **<span data-ttu-id="d81b4-128">モーションは、個性を加えます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-128">Motion adds personality.</span></span>**

    <span data-ttu-id="d81b4-129">モーションは、共通のスレッドを持つ場合があります。これにより、ユーザーがエクスペリエンスに沿って操作するときに、アプリの特徴を伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-129">Motion is often the common thread that communicates your apps personality as a user moves through an experience.</span></span>

- **<span data-ttu-id="d81b4-130">モーションは、洗練された印象を高めます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-130">Motion adds elegance.</span></span>**

    <span data-ttu-id="d81b4-131">滑らかで応答性の高いモーションによって、自然な操作性を感じさせるエクスペリエンスが実現され、エクスペリエンスとの感情面の結び付きが生みだされます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-131">Fluid, responsive, motion makes experiences feel natural, creating emotional connections to the experience.</span></span>

## <a name="examples-of-motion"></a><span data-ttu-id="d81b4-132">モーションの例</span><span class="sxs-lookup"><span data-stu-id="d81b4-132">Examples of motion</span></span>

<span data-ttu-id="d81b4-133">アプリでのモーションの例をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="d81b4-133">Here are some examples of motion in an app.</span></span>

<span data-ttu-id="d81b4-134">次の例では、アプリは接続型アニメーションを使用して項目の画像をアニメーション化し、その画像が "途切れることなく" 切り替わり、次のページにあるヘッダーの一部となります。</span><span class="sxs-lookup"><span data-stu-id="d81b4-134">Here, an app uses a connected animation to animate an item image as it “continues” to become part of the header of the next page.</span></span> <span data-ttu-id="d81b4-135">この効果を利用すると、画面の切り替えでユーザー コンテキストを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-135">The effect helps maintain user context across the transition.</span></span>

![接続型アニメーション](images/connected-animations/example.gif)

<span data-ttu-id="d81b4-137">次の例では、視覚的な視差効果を利用し、UI のスクロールやパンを行うときに、さまざまなオブジェクトをさまざまな速度で動かします。これにより、奥行き、遠近感、および動きといった感覚が引き起こされます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-137">Here, a visual parallax effect moves different objects at different rates when the UI scrolls or pans to create a feeling of depth, perspective, and movement.</span></span>

![リストと背景画像を使用した視差の例](images/_Parallax_v2.gif)


## <a name="types-of-motion"></a><span data-ttu-id="d81b4-139">モーションの種類</span><span class="sxs-lookup"><span data-stu-id="d81b4-139">Types of motion</span></span>

<table>
    <tr>
        <th align="left"><span data-ttu-id="d81b4-140">モーションの種類</span><span class="sxs-lookup"><span data-stu-id="d81b4-140">Motion type</span></span></th>
        <th align="left"><span data-ttu-id="d81b4-141">説明</span><span class="sxs-lookup"><span data-stu-id="d81b4-141">Description</span></span></th>
    </tr>
    <tr>
        <td>[<span data-ttu-id="d81b4-142">追加と削除</span><span class="sxs-lookup"><span data-stu-id="d81b4-142">Add and delete</span></span>](motion-list.md)
        </td>
        <td><span data-ttu-id="d81b4-143">リスト アニメーションを使うと、写真のアルバムや検索結果の一覧などのコレクションに対して任意の数の項目を挿入または削除できます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-143">List animations let you insert or remove single or multiple items from a collection, such as a photo album or a list of search results.</span></span>
        </td>
    </tr>
    <tr>
        <td>[<span data-ttu-id="d81b4-144">接続型アニメーション</span><span class="sxs-lookup"><span data-stu-id="d81b4-144">Connected animation</span></span>](connected-animation.md)
        </td>
        <td><span data-ttu-id="d81b4-145">接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-145">Connected animations let you create a dynamic and compelling navigation experience by animating the transition of an element between two different views.</span></span> <span data-ttu-id="d81b4-146">これにより、ユーザーはコンテキストを維持して、ビューの間の継続性を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-146">This helps the user maintain their context and provides continuity between the views.</span></span> <span data-ttu-id="d81b4-147">接続型アニメーションでは、UI コンテンツが変化するとき (画面間を移動して、ソース ビュー内の要素の場所から新しいビュー内の切り替え先となる場所が表示されるとき)、要素が 2 つのビューの間で "途切れることなく" 表示されます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-147">In a connected animation, an element appears to “continue” between two views during a change in UI content, flying across the screen from its location in the source view to its destination in the new view.</span></span> <span data-ttu-id="d81b4-148">これにより、ビューの間で共通するコンテンツが強調され、要素が切り替わるときに魅力的で動的な効果が発生します。</span><span class="sxs-lookup"><span data-stu-id="d81b4-148">This emphasizes the common content in between the views and creates a beautiful and dynamic effect as part of a transition.</span></span> 
        </td>
    </tr>
    <tr>
        <td>[<span data-ttu-id="d81b4-149">コンテンツ切り替え</span><span class="sxs-lookup"><span data-stu-id="d81b4-149">Content transition</span></span>](content-transition-animations.md)
        </td>
        <td><span data-ttu-id="d81b4-150">コンテンツ切り替えアニメーションを使うと、コンテナーや背景はそのままに、画面のある領域のコンテンツを変更できます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-150">Content transition animations let you change the content of an area of the screen while keeping the container or background constant.</span></span> <span data-ttu-id="d81b4-151">新しいコンテンツはフェード インします。</span><span class="sxs-lookup"><span data-stu-id="d81b4-151">New content fades in.</span></span> <span data-ttu-id="d81b4-152">既にあるコンテンツを差し替える場合、そのコンテンツはフェード アウトします。</span><span class="sxs-lookup"><span data-stu-id="d81b4-152">If there is existing content to be replaced, that content fades out.</span></span>
        </td>
    </tr>
    <tr>
        <td>[<span data-ttu-id="d81b4-153">ドリル</span><span class="sxs-lookup"><span data-stu-id="d81b4-153">Drill</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.drillinthemeanimation)
        </td>
        <td><span data-ttu-id="d81b4-154">ユーザーが論理階層を順方向に移動するときは (マスター リストから詳細ページへ移動する場合など)、ドリルイン アニメーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="d81b4-154">Use a drill-in animation when a user navigates forward in a logical hierarchy, like from a master list to a detail page.</span></span> <span data-ttu-id="d81b4-155">ユーザーが論理階層を逆方向に移動するときは (詳細ページからマスター ページに移動する場合など)、ドリルアウト アニメーションを表します。</span><span class="sxs-lookup"><span data-stu-id="d81b4-155">Use a drill-out animation when a user navigates backward in a logical hierarchy, like from a detail page to a master page.</span></span>
        </td>
    </tr>
    <tr>
        <td>[<span data-ttu-id="d81b4-156">フェード</span><span class="sxs-lookup"><span data-stu-id="d81b4-156">Fade</span></span>](motion-fade.md)
        </td>
        <td><span data-ttu-id="d81b4-157">フェード アニメーションは、項目を画面に表示したり、項目を画面から非表示にするときに使います。</span><span class="sxs-lookup"><span data-stu-id="d81b4-157">Use fade animations to bring items into a view or to take items out of a view.</span></span> <span data-ttu-id="d81b4-158">一般的なフェード アニメーションは、フェード インとフェード アウトの 2 つです。</span><span class="sxs-lookup"><span data-stu-id="d81b4-158">The two common fade animations are fade-in and fade-out.</span></span>
        </td>
    </tr>
        <tr>
        <td>[<span data-ttu-id="d81b4-159">視差</span><span class="sxs-lookup"><span data-stu-id="d81b4-159">Parallax</span></span>](parallax.md)
        </td>
        <td><span data-ttu-id="d81b4-160">視覚的な視差効果を利用すると、奥行き、遠近感、動きといった感覚を引き起こすことができます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-160">A visual parallax effect helps create a feeling of depth, perspective, and movement.</span></span> <span data-ttu-id="d81b4-161">こうした効果は、UI のスクロールやパンを行うときに、さまざまなオブジェクトをさまざまな速度で動かすことによって実現されます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-161">It achieves this effect by moving different objects at different rates when the UI scrolls or pans.</span></span>
        </td>
    </tr> 
    <tr>
        <td>[<span data-ttu-id="d81b4-162">タップやクリックのフィードバック</span><span class="sxs-lookup"><span data-stu-id="d81b4-162">Press feedback</span></span>](motion-pointer.md)
        </td>
        <td><span data-ttu-id="d81b4-163">ポインター プレス アニメーションは、ユーザーが項目をタップまたはクリックしたときに視覚的なフィードバックをユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="d81b4-163">Pointer press animations provide users with visual feedback when the user taps on an item.</span></span> <span data-ttu-id="d81b4-164">ポインター ダウン アニメーション (押された項目を若干縮小して傾ける) は、項目が最初にタップされたときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-164">The pointer down animation slightly shrinks and tilts the pressed item, and plays when an item is first tapped.</span></span> <span data-ttu-id="d81b4-165">ポインター アップ アニメーション (項目を元の位置に復元する) は、ユーザーがポインターから指を離したときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="d81b4-165">The pointer up animation, which restores the item to its original position, is played when the user releases the pointer.</span></span>
        </td>
    </tr>
</table>