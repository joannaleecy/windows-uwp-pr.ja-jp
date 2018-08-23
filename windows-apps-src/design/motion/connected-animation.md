---
author: mijacobs
description: 接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。
title: 接続型アニメーション
template: detail.hbs
ms.author: jimwalk
ms.date: 10/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a789a8f082192b79b3e96990827f9a4f6a0eacbc
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2815304"
---
# <a name="connected-animation-for-uwp-apps"></a><span data-ttu-id="e951a-104">UWP アプリ用の接続型アニメーション</span><span class="sxs-lookup"><span data-stu-id="e951a-104">Connected animation for UWP apps</span></span>

## <a name="what-is-connected-animation"></a><span data-ttu-id="e951a-105">接続型アニメーションとは</span><span class="sxs-lookup"><span data-stu-id="e951a-105">What is connected animation?</span></span>

<span data-ttu-id="e951a-106">接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="e951a-106">Connected animations let you create a dynamic and compelling navigation experience by animating the transition of an element between two different views.</span></span> <span data-ttu-id="e951a-107">これにより、ユーザーはコンテキストを維持して、ビューの間の継続性を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="e951a-107">This helps the user maintain their context and provides continuity between the views.</span></span>
<span data-ttu-id="e951a-108">接続型アニメーションでは、UI コンテンツが変化するとき (画面間を移動して、ソース ビュー内の要素の場所から新しいビュー内の切り替え先となる場所が表示されるとき)、要素が 2 つのビューの間で "途切れることなく" 表示されます。</span><span class="sxs-lookup"><span data-stu-id="e951a-108">In a connected animation, an element appears to “continue” between two views during a change in UI content, flying across the screen from its location in the source view to its destination in the new view.</span></span> <span data-ttu-id="e951a-109">これにより、ビューの間で共通するコンテンツが強調され、要素が切り替わるときに魅力的で動的な効果が発生します。</span><span class="sxs-lookup"><span data-stu-id="e951a-109">This emphasizes the common content in between the views and creates a beautiful and dynamic effect as part of a transition.</span></span>

## <a name="see-it-in-action"></a><span data-ttu-id="e951a-110">実際の動作を見る</span><span class="sxs-lookup"><span data-stu-id="e951a-110">See it in action</span></span>

<span data-ttu-id="e951a-111">この短い動画では、アプリは接続型アニメーションを使用して項目の画像をアニメーション化し、その画像が "途切れることなく" 切り替わり、次のページにあるヘッダーの一部となります。</span><span class="sxs-lookup"><span data-stu-id="e951a-111">In this short video, an app uses a connected animation to animate an item image as it “continues” to become part of the header of the next page.</span></span> <span data-ttu-id="e951a-112">この効果を利用すると、画面の切り替えでユーザー コンテキストを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="e951a-112">The effect helps maintain user context across the transition.</span></span>

![継続的なモーションの UI の例](images/continuous3.gif)

<!-- 
<iframe width=640 height=360 src='https://microsoft.sharepoint.com/portals/hub/_layouts/15/VideoEmbedHost.aspx?chId=552c725c%2De353%2D4118%2Dbd2b%2Dc2d0584c9848&amp;vId=b2daa5ee%2Dbe15%2D4503%2Db541%2D1328a6587c36&amp;width=640&amp;height=360&amp;autoPlay=false&amp;showInfo=true' allowfullscreen></iframe>
-->

## <a name="video-summary"></a><span data-ttu-id="e951a-114">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="e951a-114">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev005/player]

## <a name="connected-animation-and-the-fluent-design-system"></a><span data-ttu-id="e951a-115">接続型アニメーションと Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="e951a-115">Connected animation and the Fluent Design System</span></span>

 <span data-ttu-id="e951a-116">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="e951a-116">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="e951a-117">接続型アニメーションは、アプリに動きを加える Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="e951a-117">Connected animation is a Fluent Design System component that adds motion to your app.</span></span> <span data-ttu-id="e951a-118">詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e951a-118">To learn more, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

## <a name="why-connected-animation"></a><span data-ttu-id="e951a-119">接続型アニメーションを使用する理由</span><span class="sxs-lookup"><span data-stu-id="e951a-119">Why connected animation?</span></span>

<span data-ttu-id="e951a-120">ページ間を移動するときには、移動後にどのような新しいコンテンツが表示されるか、その新しいコンテンツがページを移動するユーザーの目的とどのように関連しているかを、ユーザーが理解できるようにすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="e951a-120">When navigating between pages, it’s important for the user to understand what new content is being presented after the navigation and how it relates to their intent when navigating.</span></span> <span data-ttu-id="e951a-121">接続型アニメーションを利用すると、2 つのビューで共有されているコンテンツにユーザーを注目させることによって、2 つのビューの間の関係を強調する強力な視覚的メタファが実現されます。</span><span class="sxs-lookup"><span data-stu-id="e951a-121">Connected animations provide a powerful visual metaphor that emphasizes the relationship between two views by drawing the user’s focus to the content shared between them.</span></span> <span data-ttu-id="e951a-122">また、接続型アニメーションによって、ページを移動するときに、視覚的に注目を引く効果や洗練された視覚効果を発生させることができます。このことは、アプリのモーション デザインを特徴付ける際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e951a-122">Additionally, connected animations add visual interest and polish to page navigation that can help differentiate the motion design of your app.</span></span>

## <a name="when-to-use-connected-animation"></a><span data-ttu-id="e951a-123">接続型アニメーションを使用するタイミング</span><span class="sxs-lookup"><span data-stu-id="e951a-123">When to use connected animation</span></span>

<span data-ttu-id="e951a-124">一般に、接続型アニメーションはページを変更するとき使用されます。ただし、UI のコンテンツを変更するときに、そのコンテンツが維持されるようにユーザーに対して表示する必要がある場合は、接続型アニメーションをどのようなエクスペリエンスにでも適用できます。</span><span class="sxs-lookup"><span data-stu-id="e951a-124">Connected animations are generally used when changing pages, though they can be applied to any experience where you are changing content in a UI and want the user to maintain context.</span></span> <span data-ttu-id="e951a-125">ソース ビューと切り替え先のビューの間で UI の画像や他の UI の要素が共有されている場合は、必ず、[ドリル インによるナビゲーション切り替え](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)ではなく、接続型アニメーションの使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="e951a-125">You should consider using a connected animation instead of a [drill in navigation transition](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx) whenever there is an image or other piece of UI shared between the source and destination views.</span></span>

## <a name="how-to-implement"></a><span data-ttu-id="e951a-126">実装方法</span><span class="sxs-lookup"><span data-stu-id="e951a-126">How to implement</span></span>

<span data-ttu-id="e951a-127">接続型アニメーションのセットアップでは、次の 2 つの手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e951a-127">Setting up a connected animation involves two steps:</span></span>

1.  <span data-ttu-id="e951a-128">ソース ページでアニメーション オブジェクトを*準備*します。この手順では、ソース要素が接続型アニメーションに参加することを、システムに伝えます。</span><span class="sxs-lookup"><span data-stu-id="e951a-128">*Prepare* an animation object on the source page, which indicates to the system that the source element will participate in the connected animation</span></span> 
2.  <span data-ttu-id="e951a-129">切り替え先のページでアニメーションを*開始*します。この手順では、切り替え先の要素に参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="e951a-129">*Start* the animation on the destination page, passing a reference to the destination element</span></span>

<span data-ttu-id="e951a-130">2 つの手順の間では、ソース要素がアプリの他の UI 上でフリーズしているかのように見えます。このとき、他の切り替えアニメーションを同時に実行できてしまいます。</span><span class="sxs-lookup"><span data-stu-id="e951a-130">In between the two steps, the source element will appear frozen above other UI in the app, allowing you to perform any other transition animations simultaneously.</span></span> <span data-ttu-id="e951a-131">このため、2 つの手順の間の待機時間は 250 ミリ秒を超えないようにしてください。250 ミリ秒を超えると、ソース要素が存在することで問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e951a-131">For this reason, you shouldn’t wait more than ~250 milliseconds in between the two steps since the presence of the source element may become distracting.</span></span> <span data-ttu-id="e951a-132">アニメーションを準備しても、アニメーションを 3 秒以内に開始しないと、システムによってアニメーションが破棄され、後続の **TryStart** の呼び出しは失敗します。</span><span class="sxs-lookup"><span data-stu-id="e951a-132">If you prepare an animation and do not start it within three seconds, the system will dispose of the animation and any subsequent calls to **TryStart** will fail.</span></span>

<span data-ttu-id="e951a-133">現在の ConnectedAnimationService インスタンスにアクセスするには、**ConnectedAnimationService.GetForCurrentView** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e951a-133">You can get access to the current ConnectedAnimationService instance by calling **ConnectedAnimationService.GetForCurrentView**.</span></span> <span data-ttu-id="e951a-134">アニメーションを準備するには、このインスタンスの **PrepareToAnimate** を呼び出し、切り替えで使用する一意のキーと UI 要素への参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="e951a-134">To prepare an animation, call **PrepareToAnimate** on this instance, passing a reference to a unique key and the UI element you want to use in the transition.</span></span> <span data-ttu-id="e951a-135">一意のキーを使用すると、アニメーションを後で取得することができます。たとえば、別のページ上でアニメーションを取得できます。</span><span class="sxs-lookup"><span data-stu-id="e951a-135">The unique key allows you to retrieve the animation later, for example on a different page.</span></span>

```csharp
ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image", SourceImage);
```

<span data-ttu-id="e951a-136">アニメーションを開始するには、**ConnectedAnimation.TryStart** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e951a-136">To start the animation, call **ConnectedAnimation.TryStart**.</span></span> <span data-ttu-id="e951a-137">アニメーションの作成時に指定した一意のキーを使用して **ConnectedAnimationService.GetAnimation** を呼び出すことにより、適切なアニメーションのインスタンスを取得できます。</span><span class="sxs-lookup"><span data-stu-id="e951a-137">You can retrieve the right animation instance by calling **ConnectedAnimationService.GetAnimation** with the unique key you provided when creating the animation.</span></span>

```csharp
ConnectedAnimation imageAnimation = 
    ConnectedAnimationService.GetForCurrentView().GetAnimation("image");
if (imageAnimation != null)
{
    imageAnimation.TryStart(DestinationImage);
}
```

<span data-ttu-id="e951a-138">ConnectedAnimationService を使用して 2 つのページ間の切り替えを作成する完全な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e951a-138">Here is a full example of using ConnectedAnimationService to create a transition between two pages.</span></span>

*<span data-ttu-id="e951a-139">SourcePage.xaml</span><span class="sxs-lookup"><span data-stu-id="e951a-139">SourcePage.xaml</span></span>*

```xaml
<Image x:Name="SourceImage"
       Width="200"
       Height="200"
       Stretch="Fill"
       Source="Assets/StoreLogo.png" />
```

*<span data-ttu-id="e951a-140">SourcePage.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="e951a-140">SourcePage.xaml.cs</span></span>*

```csharp
private void NavigateToDestinationPage()
{
    ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image", SourceImage);
    Frame.Navigate(typeof(DestinationPage));
}
```

*<span data-ttu-id="e951a-141">DestinationPage.xaml</span><span class="sxs-lookup"><span data-stu-id="e951a-141">DestinationPage.xaml</span></span>*

```xaml
<Image x:Name="DestinationImage"
       Width="400"
       Height="400"
       Stretch="Fill"
       Source="Assets/StoreLogo.png" />
```

*<span data-ttu-id="e951a-142">DestinationPage.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="e951a-142">DestinationPage.xaml.cs</span></span>*

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    ConnectedAnimation imageAnimation = 
        ConnectedAnimationService.GetForCurrentView().GetAnimation("image");
    if (imageAnimation != null)
    {
        imageAnimation.TryStart(DestinationImage);
    }
}
```

## <a name="connected-animation-in-list-and-grid-experiences"></a><span data-ttu-id="e951a-143">リスト エクスペリエンスとグリッド エクスペリエンスでの接続型アニメーション</span><span class="sxs-lookup"><span data-stu-id="e951a-143">Connected animation in list and grid experiences</span></span>

<span data-ttu-id="e951a-144">多くの場合、リスト コントロールやグリッド コントロール間の切り替えで接続型アニメーションの作成が必要になります。</span><span class="sxs-lookup"><span data-stu-id="e951a-144">Often, you will want to create a connected animation from or to a list or grid control.</span></span> <span data-ttu-id="e951a-145">**ListView** と **GridView** の 2 つの新しいメソッドである、**PrepareConnectedAnimation** と **TryStartConnectedAnimationAsync** を使用して、このプロセスを簡略化できます。</span><span class="sxs-lookup"><span data-stu-id="e951a-145">You can use two new methods of **ListView** and **GridView**, **PrepareConnectedAnimation** and **TryStartConnectedAnimationAsync**, to simplify this process.</span></span>
<span data-ttu-id="e951a-146">たとえば、データ テンプレート内に "PortraitEllipse" という名前の要素を含んでいる **ListView** があるとします。</span><span class="sxs-lookup"><span data-stu-id="e951a-146">For example, say you have a **ListView** that contains an element with the name "PortraitEllipse" in its data template.</span></span>

```xaml
<ListView x:Name="ContactsListView" Loaded="ContactsListView_Loaded">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="vm:ContactsItem">
            <Grid>
                …
                <Ellipse x:Name="PortraitEllipse" … />
            </Grid>
        </DataTemplate> 
    </ListView.ItemTemplate>
</ListView>
```

<span data-ttu-id="e951a-147">指定されたリスト項目に対応する楕円を表示する接続型アニメーションを準備するには、一意のキー、項目、および "PortraitEllipse" という名前を指定して、**PrepareConnectedAnimation** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e951a-147">To prepare a connected animation with the ellipse corresponding to a given list item, call the **PrepareConnectedAnimation** method with a unique key, the item, and the name “PortraitEllipse”.</span></span>

```csharp
void PrepareAnimationWithItem(ContactsItem item)
{
     ContactsListView.PrepareConnectedAnimation("portrait", item, "PortraitEllipse");
}
```

<span data-ttu-id="e951a-148">また、この要素を切り替え先として使用してアニメーションを開始するには (たとえば、詳細ビューから戻ったときなど)、**TryStartConnectedAnimationAsync** を使用します。</span><span class="sxs-lookup"><span data-stu-id="e951a-148">Alternatively, to start an animation with this element as the destination, for example when navigating back from a detail view, use **TryStartConnectedAnimationAsync**.</span></span> <span data-ttu-id="e951a-149">**ListView** のデータ ソースが読み込まれると、**TryStartConnectedAnimationAsync** は、対応する項目コンテナーが作成されるまで、アニメーションが開始されるのを待機します。</span><span class="sxs-lookup"><span data-stu-id="e951a-149">If you have just loaded the data source for the **ListView**, **TryStartConnectedAnimationAsync** will wait to start the animation until the corresponding item container has been created.</span></span>

```csharp
private void ContactsListView_Loaded(object sender, RoutedEventArgs e)
{
    ContactsItem item = GetPersistedItem(); // Get persisted item
    if (item != null)
    {
        ContactsListView.ScrollIntoView(item);
        ConnectedAnimation animation = 
            ConnectedAnimationService.GetForCurrentView().GetAnimation("portrait");
        if (animation != null)
        {
            await ContactsListView.TryStartConnectedAnimationAsync(
                animation, item, "PortraitEllipse");
        }
    }
}
```

## <a name="coordinated-animation"></a><span data-ttu-id="e951a-150">連動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="e951a-150">Coordinated animation</span></span>

![連動型アニメーション](images/connected-animations/coordinated_example.gif)

<!--
<iframe width=640 height=360 src='https://microsoft.sharepoint.com/portals/hub/_layouts/15/VideoEmbedHost.aspx?chId=552c725c%2De353%2D4118%2Dbd2b%2Dc2d0584c9848&amp;vId=9066bbbe%2Dcf58%2D4ab4%2Db274%2D595616f5d0a0&amp;width=640&amp;height=360&amp;autoPlay=false&amp;showInfo=true' allowfullscreen></iframe>
-->

<span data-ttu-id="e951a-152">*連動型アニメーション*は特殊な種類の開始アニメーションで、要素が接続型アニメーションのターゲットと共に表示され、接続型アニメーションの要素と連動してアニメーション化され、画面上を横切って移動します。</span><span class="sxs-lookup"><span data-stu-id="e951a-152">A *coordinated animation* is a special type of entrance animation where an element will appear alongside the connected animation target, animating in tandem with the connected animation element as it moves across the screen.</span></span> <span data-ttu-id="e951a-153">連動型アニメーションによって、ビューの切り替え時に視覚的にさらに注目を引く効果が発生し、ソース ビューと切り替え先のビューの間で共有されているコンテキストにユーザーを注目させることができます。</span><span class="sxs-lookup"><span data-stu-id="e951a-153">Coordinated animations can add more visual interest to a transition and further draw the user’s attention to the context that is shared between the source and destination views.</span></span> <span data-ttu-id="e951a-154">上記の画像では、連動型アニメーションを使用して、項目のキャプション UI がアニメーション化されています。</span><span class="sxs-lookup"><span data-stu-id="e951a-154">In these images, the caption UI for the item is animating using a coordinated animation.</span></span>

<span data-ttu-id="e951a-155">**TryStart** の 2 つのパラメーター オーバーロードを使用して、連動型の要素を接続型アニメーションに追加します。</span><span class="sxs-lookup"><span data-stu-id="e951a-155">Use the two-parameter overload of **TryStart** to add coordinated elements to a connected animation.</span></span> <span data-ttu-id="e951a-156">次の例では、“DescriptionRoot” という名前のグリッド レイアウトの連動型アニメーションを説明します。このアニメーションは、“CoverImage” という名前の接続型アニメーションの要素と連動して表示されます。</span><span class="sxs-lookup"><span data-stu-id="e951a-156">This example demonstrates a coordinated animation of a Grid layout named “DescriptionRoot” that will enter in tandem with a connected animation element named “CoverImage”.</span></span>

*<span data-ttu-id="e951a-157">DestinationPage.xaml</span><span class="sxs-lookup"><span data-stu-id="e951a-157">DestinationPage.xaml</span></span>*

```xaml
<Grid>
    <Image x:Name="CoverImage" />
    <Grid x:Name="DescriptionRoot" />
</Grid>
```

*<span data-ttu-id="e951a-158">DestinationPage.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="e951a-158">DestinationPage.xaml.cs</span></span>*

```csharp
void OnNavigatedTo(NavigationEventArgs e)
{
    var animationService = ConnectedAnimationService.GetForCurrentView();
    var animation = animationService.GetAnimation("coverImage");
    
    if (animation != null)
    {
        // Don’t need to capture the return value as we are not scheduling any subsequent
        // animations
        animation.TryStart(CoverImage, new UIElement[] { DescriptionRoot });
     }
}
```

## <a name="dos-and-donts"></a><span data-ttu-id="e951a-159">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="e951a-159">Do’s and don’ts</span></span>

- <span data-ttu-id="e951a-160">接続型アニメーションは、ソース ページと切り替え先のページの間で要素が共有されている場合に、ページの切り替えで使用してください。</span><span class="sxs-lookup"><span data-stu-id="e951a-160">Use a connected animation in page transitions where an element is shared between the source and destination pages.</span></span>
- <span data-ttu-id="e951a-161">接続型アニメーションの準備と開始の間で発生する、ネットワーク要求や他の実行時間の長い非同期操作を待機しないでください。</span><span class="sxs-lookup"><span data-stu-id="e951a-161">Don’t wait on network requests or other long-running asynchronous operations in between preparing and starting a connected animation.</span></span> <span data-ttu-id="e951a-162">早めに切り替えを実行するには、必要な情報を事前に読み込んでおく必要があります。または、高解像度の画像が切り替え先のビューに読み込まれるときに、低解像度のプレースホルダー画像を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e951a-162">You may need to pre-load the necessary information to run the transition ahead of time, or use a low-resolution placeholder image while a high-resolution image loads in the destination view.</span></span>
- <span data-ttu-id="e951a-163">**ConnectedAnimationService** を使用する場合、**Frame** 内で切り替えアニメーションが使われないようにするには、[SuppressNavigationTransitionInfo](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) を使用します。これは、接続型アニメーションが既定のナビゲーション切り替えとは同時に使用できないアニメーションであるためです。</span><span class="sxs-lookup"><span data-stu-id="e951a-163">Use [SuppressNavigationTransitionInfo](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) to prevent a transition animation in a **Frame** if you are using **ConnectedAnimationService**, since connected animations aren’t meant to be used simultaneously with the default navigation transitions.</span></span> <span data-ttu-id="e951a-164">ナビゲーション切り替えの使用方法について詳しくは、「[NavigationThemeTransition](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e951a-164">See [NavigationThemeTransition](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx) for more info on how to use navigation transitions.</span></span>


## <a name="download-the-code-samples"></a><span data-ttu-id="e951a-165">コード サンプルのダウンロード</span><span class="sxs-lookup"><span data-stu-id="e951a-165">Download the code samples</span></span>

<span data-ttu-id="e951a-166">[WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) サンプル ギャラリーの[接続型アニメーションのサンプル](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e951a-166">See the [Connected Animation sample](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample) in the [WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) sample gallery.</span></span>

## <a name="related-articles"></a><span data-ttu-id="e951a-167">関連記事</span><span class="sxs-lookup"><span data-stu-id="e951a-167">Related articles</span></span>

- [<span data-ttu-id="e951a-168">ConnectedAnimation</span><span class="sxs-lookup"><span data-stu-id="e951a-168">ConnectedAnimation</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimation)
- [<span data-ttu-id="e951a-169">ConnectedAnimationService</span><span class="sxs-lookup"><span data-stu-id="e951a-169">ConnectedAnimationService</span></span>](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.animation.connectedanimation.aspx)
- [<span data-ttu-id="e951a-170">NavigationThemeTransition</span><span class="sxs-lookup"><span data-stu-id="e951a-170">NavigationThemeTransition</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)
