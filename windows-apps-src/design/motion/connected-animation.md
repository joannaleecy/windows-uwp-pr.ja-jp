---
author: mijacobs
description: 接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。
title: 接続型アニメーション
template: detail.hbs
ms.author: jimwalk
ms.date: 10/25/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 77050103bb78788a5c1868a41d315edd6832a5fe
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5811690"
---
# <a name="connected-animation-for-uwp-apps"></a><span data-ttu-id="21100-104">UWP アプリ用の接続型アニメーション</span><span class="sxs-lookup"><span data-stu-id="21100-104">Connected animation for UWP apps</span></span>

<span data-ttu-id="21100-105">接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="21100-105">Connected animations let you create a dynamic and compelling navigation experience by animating the transition of an element between two different views.</span></span> <span data-ttu-id="21100-106">これにより、ユーザーはコンテキストを維持して、ビューの間の継続性を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="21100-106">This helps the user maintain their context and provides continuity between the views.</span></span>

<span data-ttu-id="21100-107">接続型アニメーションの場合は、引き続き""途切れることがなく、画面上で、ソース ビュー内の場所から新しいビューで先となる、UI のコンテンツの変更時に 2 つのビューの間で要素が表示されます。</span><span class="sxs-lookup"><span data-stu-id="21100-107">In a connected animation, an element appears to "continue" between two views during a change in UI content, flying across the screen from its location in the source view to its destination in the new view.</span></span> <span data-ttu-id="21100-108">これは、ビューの間で共通のコンテンツが強調され、移行の一環として、優れた美しさを持つで動的な効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="21100-108">This emphasizes the common content between the views and creates a beautiful and dynamic effect as part of a transition.</span></span>

> <span data-ttu-id="21100-109">**重要な Api**: [ConnectedAnimation クラス](/uwp/api/windows.ui.xaml.media.animation.connectedanimation)、 [ConnectedAnimationService クラス](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)</span><span class="sxs-lookup"><span data-stu-id="21100-109">**Important APIs**:  [ConnectedAnimation class](/uwp/api/windows.ui.xaml.media.animation.connectedanimation), [ConnectedAnimationService class](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)</span></span>

## <a name="see-it-in-action"></a><span data-ttu-id="21100-110">実際の動作を見る</span><span class="sxs-lookup"><span data-stu-id="21100-110">See it in action</span></span>

<span data-ttu-id="21100-111">この短いビデオでは、アプリは、アニメーション化し、「再開」次のページにあるヘッダーの一部となります項目のイメージに接続型アニメーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="21100-111">In this short video, an app uses a connected animation to animate an item image as it "continues" to become part of the header of the next page.</span></span> <span data-ttu-id="21100-112">この効果を利用すると、画面の切り替えでユーザー コンテキストを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="21100-112">The effect helps maintain user context across the transition.</span></span>

![接続型アニメーション](images/connected-animations/example.gif)

<!-- 
<iframe width=640 height=360 src='https://microsoft.sharepoint.com/portals/hub/_layouts/15/VideoEmbedHost.aspx?chId=552c725c%2De353%2D4118%2Dbd2b%2Dc2d0584c9848&amp;vId=b2daa5ee%2Dbe15%2D4503%2Db541%2D1328a6587c36&amp;width=640&amp;height=360&amp;autoPlay=false&amp;showInfo=true' allowfullscreen></iframe>
-->

## <a name="video-summary"></a><span data-ttu-id="21100-114">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="21100-114">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev005/player]

## <a name="connected-animation-and-the-fluent-design-system"></a><span data-ttu-id="21100-115">接続型アニメーションと Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="21100-115">Connected animation and the Fluent Design System</span></span>

 <span data-ttu-id="21100-116">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="21100-116">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="21100-117">接続型アニメーションは、アプリに動きを加える Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="21100-117">Connected animation is a Fluent Design System component that adds motion to your app.</span></span> <span data-ttu-id="21100-118">詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21100-118">To learn more, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

## <a name="why-connected-animation"></a><span data-ttu-id="21100-119">接続型アニメーションを使用する理由</span><span class="sxs-lookup"><span data-stu-id="21100-119">Why connected animation?</span></span>

<span data-ttu-id="21100-120">ページ間を移動するときには、移動後にどのような新しいコンテンツが表示されるか、その新しいコンテンツがページを移動するユーザーの目的とどのように関連しているかを、ユーザーが理解できるようにすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="21100-120">When navigating between pages, it’s important for the user to understand what new content is being presented after the navigation and how it relates to their intent when navigating.</span></span> <span data-ttu-id="21100-121">接続型アニメーションを利用すると、2 つのビューで共有されているコンテンツにユーザーを注目させることによって、2 つのビューの間の関係を強調する強力な視覚的メタファが実現されます。</span><span class="sxs-lookup"><span data-stu-id="21100-121">Connected animations provide a powerful visual metaphor that emphasizes the relationship between two views by drawing the user’s focus to the content shared between them.</span></span> <span data-ttu-id="21100-122">また、接続型アニメーションによって、ページを移動するときに、視覚的に注目を引く効果や洗練された視覚効果を発生させることができます。このことは、アプリのモーション デザインを特徴付ける際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="21100-122">Additionally, connected animations add visual interest and polish to page navigation that can help differentiate the motion design of your app.</span></span>

## <a name="when-to-use-connected-animation"></a><span data-ttu-id="21100-123">接続型アニメーションを使用するタイミング</span><span class="sxs-lookup"><span data-stu-id="21100-123">When to use connected animation</span></span>

<span data-ttu-id="21100-124">一般に、接続型アニメーションはページを変更するとき使用されます。ただし、UI のコンテンツを変更するときに、そのコンテンツが維持されるようにユーザーに対して表示する必要がある場合は、接続型アニメーションをどのようなエクスペリエンスにでも適用できます。</span><span class="sxs-lookup"><span data-stu-id="21100-124">Connected animations are generally used when changing pages, though they can be applied to any experience where you are changing content in a UI and want the user to maintain context.</span></span> <span data-ttu-id="21100-125">ソース ビューと切り替え先のビューの間で UI の画像や他の UI の要素が共有されている場合は、必ず、[ドリル インによるナビゲーション切り替え](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)ではなく、接続型アニメーションの使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="21100-125">You should consider using a connected animation instead of a [drill in navigation transition](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx) whenever there is an image or other piece of UI shared between the source and destination views.</span></span>

## <a name="configure-connected-animation"></a><span data-ttu-id="21100-126">接続型アニメーションを構成します。</span><span class="sxs-lookup"><span data-stu-id="21100-126">Configure connected animation</span></span>

> [!IMPORTANT]
> <span data-ttu-id="21100-127">この機能は、アプリのターゲット バージョンは、RS5 である必要があります (Windows SDK バージョン 10.0.NNNNN.0 (Windows 10、バージョン YYMM) 以上。</span><span class="sxs-lookup"><span data-stu-id="21100-127">This feature requires that your app's Target version be RS5 (Windows SDK version 10.0.NNNNN.0 (Windows 10, version YYMM) or greater.</span></span> <span data-ttu-id="21100-128">構成プロパティでは、以前の Sdk で利用できません。</span><span class="sxs-lookup"><span data-stu-id="21100-128">The Configuration property is not available in earlier SDKs.</span></span> <span data-ttu-id="21100-129">RS5 より小さい最小バージョンをターゲットにする (Windows SDK バージョン 10.0.NNNNN.0 (Windows 10、バージョン YYMM) を使用してアダプティブ コードや条件付き XAML します。</span><span class="sxs-lookup"><span data-stu-id="21100-129">You can target a Minimum version lower than RS5 (Windows SDK version 10.0.NNNNN.0 (Windows 10, version YYMM) using adaptive code or conditional XAML.</span></span> <span data-ttu-id="21100-130">詳しくは、[バージョン アダプティブ アプリ](/debug-test-perf/version-adaptive-apps)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="21100-130">For more info, see [Version adaptive apps](/debug-test-perf/version-adaptive-apps).</span></span>

<span data-ttu-id="21100-131">接続型アニメーションをさらには、Fluent design を具体化以降 RS5 では、アニメーションを提供することによって構成に合わせた前方用と前に戻るページのナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="21100-131">Starting in RS5, connected animations further embody Fluent design by providing animation configurations tailored specifically for forward and backwards page navigation.</span></span>

<span data-ttu-id="21100-132">アニメーションは、構成を指定するには、ConnectedAnimation に構成プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="21100-132">You specify an animation configuration by setting the Configuration property on the ConnectedAnimation.</span></span> <span data-ttu-id="21100-133">(これの例を示しますが、次のセクションに表示されます)。</span><span class="sxs-lookup"><span data-stu-id="21100-133">(We’ll show examples of this in the next section.)</span></span>

<span data-ttu-id="21100-134">次の表では、利用可能な構成について説明します。</span><span class="sxs-lookup"><span data-stu-id="21100-134">This table describes the available configurations.</span></span> <span data-ttu-id="21100-135">これらのアニメーションに適用されるモーションの原則について詳しくは、[方向性と重力](index.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="21100-135">For more information about the motion principles applied in these animations, see [Directionality and gravity](index.md).</span></span>

| [<span data-ttu-id="21100-136">GravityConnectedAnimationConfiguration</span><span class="sxs-lookup"><span data-stu-id="21100-136">GravityConnectedAnimationConfiguration</span></span>]() |
| - |
| <span data-ttu-id="21100-137">これは、既定の構成であり、転送のナビゲーションをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="21100-137">This is the default configuration, and is recommended for forward navigation.</span></span> |
<span data-ttu-id="21100-138">ユーザーが (A B から) アプリでの前方に移動するように物理的に"ページ"、接続されている要素が表示されます。</span><span class="sxs-lookup"><span data-stu-id="21100-138">As the user navigates forward in the app (A to B), the connected element appears to physically “pull off the page”.</span></span> <span data-ttu-id="21100-139">これによりは、要素は、z 座標で前方に移動する表示され、重力の影響の保留を受けるとしてビットを削除します。</span><span class="sxs-lookup"><span data-stu-id="21100-139">In doing so, the element appears to move forward in z-space and drops a bit as an effect of gravity taking hold.</span></span> <span data-ttu-id="21100-140">重力の影響をなくすためには、要素は速度を向上し、最終的な位置に高速化します。</span><span class="sxs-lookup"><span data-stu-id="21100-140">To overcome the effects of gravity, the element gains velocity and accelerates into its final position.</span></span> <span data-ttu-id="21100-141">結果は、「スケールと dip」のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="21100-141">The result is a “scale and dip” animation.</span></span> |

| [<span data-ttu-id="21100-142">DirectConnectedAnimationConfiguration</span><span class="sxs-lookup"><span data-stu-id="21100-142">DirectConnectedAnimationConfiguration</span></span>]() |
| - |
| <span data-ttu-id="21100-143">(A から b、B) アプリでは、ユーザーが前に戻る移動、アニメーションはより直接的です。</span><span class="sxs-lookup"><span data-stu-id="21100-143">As the user navigates backwards in the app (B to A), the animation is more direct.</span></span> <span data-ttu-id="21100-144">接続されている要素は、減速三次ベジエ イージング関数を使用する B から線形に変換します。</span><span class="sxs-lookup"><span data-stu-id="21100-144">The connected element linearly translates from B to A using a decelerate cubic Bezier easing function.</span></span> <span data-ttu-id="21100-145">前に戻る移動の視覚的アフォー ダンスは、できるだけ早く、ナビゲーション フローのコンテキストを維持しつつ、ユーザーを以前の状態に返します。</span><span class="sxs-lookup"><span data-stu-id="21100-145">The backwards visual affordance returns the user to their previous state as fast as possible while still maintaining the context of the navigation flow.</span></span> |

| [<span data-ttu-id="21100-146">BasicConnectedAnimationConfiguration</span><span class="sxs-lookup"><span data-stu-id="21100-146">BasicConnectedAnimationConfiguration</span></span>]() |
| - |
| <span data-ttu-id="21100-147">これは、既定の (およびのみ) RS5 より前の SDK バージョンで使用されるアニメーション (Windows SDK バージョン 10.0.NNNNN.0 (Windows 10、バージョン YYMM)。</span><span class="sxs-lookup"><span data-stu-id="21100-147">This is the default (and only) animation used in SDK versions prior to RS5 (Windows SDK version 10.0.NNNNN.0 (Windows 10, version YYMM).</span></span> |

### <a name="connectedanimationservice-configuration"></a><span data-ttu-id="21100-148">ConnectedAnimationService の構成</span><span class="sxs-lookup"><span data-stu-id="21100-148">ConnectedAnimationService configuration</span></span>

<span data-ttu-id="21100-149">[ConnectedAnimationService](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)クラスには、全体のサービスではなく、個々 のアニメーションに適用する 2 つのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="21100-149">The [ConnectedAnimationService](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice) class has two properties that apply to the individual animations rather than the overall service.</span></span>

- [<span data-ttu-id="21100-150">DefaultDuration</span><span class="sxs-lookup"><span data-stu-id="21100-150">DefaultDuration</span></span>](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.defaultduration)
- [<span data-ttu-id="21100-151">DefaultEasingFunction</span><span class="sxs-lookup"><span data-stu-id="21100-151">DefaultEasingFunction</span></span>](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.defaulteasingfunction)

<span data-ttu-id="21100-152">さまざまな効果を実現するには、いくつかの構成が ConnectedAnimationService に対してこれらのプロパティを無視し、代わりに、次の表で説明したよう独自の値を使用します。</span><span class="sxs-lookup"><span data-stu-id="21100-152">To achieve the various effects, some configurations ignore these properties on ConnectedAnimationService and use their own values instead, as described in this table.</span></span>

| <span data-ttu-id="21100-153">構成</span><span class="sxs-lookup"><span data-stu-id="21100-153">Configuration</span></span> | <span data-ttu-id="21100-154">点 DefaultDuration かどうか。</span><span class="sxs-lookup"><span data-stu-id="21100-154">Respects DefaultDuration?</span></span> | <span data-ttu-id="21100-155">点 DefaultEasingFunction かどうか。</span><span class="sxs-lookup"><span data-stu-id="21100-155">Respects DefaultEasingFunction?</span></span> |
| - | - | - |
| <span data-ttu-id="21100-156">重力</span><span class="sxs-lookup"><span data-stu-id="21100-156">Gravity</span></span> | <span data-ttu-id="21100-157">はい</span><span class="sxs-lookup"><span data-stu-id="21100-157">Yes</span></span> | <span data-ttu-id="21100-158">○\*</span><span class="sxs-lookup"><span data-stu-id="21100-158">Yes\*</span></span> <br/> <span data-ttu-id="21100-159">\**A から b、b の基本的な翻訳が、このイージング関数を使用しますが、"重力 dip"が、独自のイージング関数。*</span><span class="sxs-lookup"><span data-stu-id="21100-159">\**The basic translation from A to B uses this easing function, but the "gravity dip" has its own easing function.*</span></span>  |
| <span data-ttu-id="21100-160">直接</span><span class="sxs-lookup"><span data-stu-id="21100-160">Direct</span></span> | <span data-ttu-id="21100-161">いいえ</span><span class="sxs-lookup"><span data-stu-id="21100-161">No</span></span> <br/> *<span data-ttu-id="21100-162">150 ミリ秒を超えるをアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="21100-162">Animates over 150ms.</span></span>*| <span data-ttu-id="21100-163">いいえ</span><span class="sxs-lookup"><span data-stu-id="21100-163">No</span></span> <br/> *<span data-ttu-id="21100-164">減速のイージング関数を使用します。</span><span class="sxs-lookup"><span data-stu-id="21100-164">Uses the Decelerate easing function.</span></span>* |
| <span data-ttu-id="21100-165">基本</span><span class="sxs-lookup"><span data-stu-id="21100-165">Basic</span></span> | <span data-ttu-id="21100-166">はい</span><span class="sxs-lookup"><span data-stu-id="21100-166">Yes</span></span> | <span data-ttu-id="21100-167">はい</span><span class="sxs-lookup"><span data-stu-id="21100-167">Yes</span></span> |

## <a name="how-to-implement-connected-animation"></a><span data-ttu-id="21100-168">接続型アニメーションを実装する方法</span><span class="sxs-lookup"><span data-stu-id="21100-168">How to implement connected animation</span></span>

<span data-ttu-id="21100-169">接続型アニメーションのセットアップでは、次の 2 つの手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="21100-169">Setting up a connected animation involves two steps:</span></span>

1. <span data-ttu-id="21100-170">*環境の準備*ソース] ページで、システムに、ソース要素が接続型アニメーションに参加することを示すアニメーション オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="21100-170">*Prepare* an animation object on the source page, which indicates to the system that the source element will participate in the connected animation.</span></span>
1. <span data-ttu-id="21100-171">アニメーションを*開始*レプリケーション先] ページで、切り替え先の要素への参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="21100-171">*Start* the animation on the destination page, passing a reference to the destination element.</span></span>

<span data-ttu-id="21100-172">ソース ページから移動、するときは、 [ConnectedAnimationService.GetForCurrentView](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getforcurrentview)の ConnectedAnimationService インスタンスを取得するを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="21100-172">When navigating from the source page, call [ConnectedAnimationService.GetForCurrentView](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getforcurrentview) to get an instance of ConnectedAnimationService.</span></span> <span data-ttu-id="21100-173">アニメーションを準備するには、このインスタンスでは、 [PrepareToAnimate](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.preparetoanimate)を呼び出し、一意のキーと、切り替えで使用する UI 要素に渡します。</span><span class="sxs-lookup"><span data-stu-id="21100-173">To prepare an animation, call [PrepareToAnimate](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.preparetoanimate) on this instance, and pass in a unique key and the UI element you want to use in the transition.</span></span> <span data-ttu-id="21100-174">一意のキーを使用して、切り替え先のページに後でアニメーションを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21100-174">The unique key lets you retrieve the animation later on the destination page.</span></span>

```csharp
ConnectedAnimationService.GetForCurrentView()
    .PrepareToAnimate("forwardAnimation", SourceImage);
```

<span data-ttu-id="21100-175">ナビゲーションが発生した場合、切り替え先のページでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="21100-175">When the navigation occurs, start the animation in the destination page.</span></span> <span data-ttu-id="21100-176">アニメーションを開始するには、[ConnectedAnimation.TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="21100-176">To start the animation, call [ConnectedAnimation.TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart).</span></span> <span data-ttu-id="21100-177">アニメーションの作成時に指定した一意のキーを使用して [ConnectedAnimationService.GetAnimation](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getanimation) を呼び出すことにより、適切なアニメーションのインスタンスを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21100-177">You can retrieve the right animation instance by calling [ConnectedAnimationService.GetAnimation](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getanimation) with the unique key you provided when creating the animation.</span></span>

```csharp
ConnectedAnimation animation =
    ConnectedAnimationService.GetForCurrentView().GetAnimation("forwardAnimation");
if (animation != null)
{
    animation.TryStart(DestinationImage);
}
```

### <a name="forward-navigation"></a><span data-ttu-id="21100-178">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="21100-178">Forward navigation</span></span>

<span data-ttu-id="21100-179">この例では、2 つのページ (Page_B に Page_A) 間のナビゲーションが前方の切り替えを作成する ConnectedAnimationService を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="21100-179">This example shows how to use ConnectedAnimationService to create a transition for forward navigation between two pages (Page_A to Page_B).</span></span>

<span data-ttu-id="21100-180">ナビゲーションの推奨されるアニメーションの構成では、 [GravityConnectedAnimationConfiguration]()です。</span><span class="sxs-lookup"><span data-stu-id="21100-180">The recommended animation configuration for forward navigation is [GravityConnectedAnimationConfiguration]().</span></span> <span data-ttu-id="21100-181">これは、既定では、さまざまな構成を指定する場合を除き、[構成](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.configuration)プロパティを設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="21100-181">This is the default, so you don't need to set the [Configuration](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.configuration) property unless you want to specify a different configuration.</span></span>

<span data-ttu-id="21100-182">ソース ページでアニメーションを設定します。</span><span class="sxs-lookup"><span data-stu-id="21100-182">Set up the animation in the source page.</span></span>

```xaml
<!-- Page_A.xaml -->

<Image x:Name="SourceImage"
       HorizontalAlignment="Left" VerticalAlignment="Top"
       Width="200" Height="200"
       Stretch="Fill"
       Source="Assets/StoreLogo.png"
       PointerPressed="SourceImage_PointerPressed"/>
```

```csharp
// Page_A.xaml.cs

private void SourceImage_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    // Navigate to detail page.
    // Suppress the default animation to avoid conflict with the connected animation.
    Frame.Navigate(typeof(Page_B), null, new SuppressNavigationTransitionInfo());
}

protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
{
    ConnectedAnimationService.GetForCurrentView()
        .PrepareToAnimate("forwardAnimation", SourceImage);
    // You don't need to explicitly set the Configuration property because
    // the recommended Gravity configuration is default.
    // For custom animation, use:
    // animation.Configuration = new BasicConnectedAnimationConfiguration();
}
```

<span data-ttu-id="21100-183">切り替え先のページでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="21100-183">Start the animation in the destination page.</span></span>

```xaml
<!-- Page_B.xaml -->

<Image x:Name="DestinationImage"
       Width="400" Height="400"
       Stretch="Fill"
       Source="Assets/StoreLogo.png" />
```

```csharp
// Page_B.xaml.cs

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    ConnectedAnimation animation =
        ConnectedAnimationService.GetForCurrentView().GetAnimation("forwardAnimation");
    if (animation != null)
    {
        animation.TryStart(DestinationImage);
    }
}
```

### <a name="back-navigation"></a><span data-ttu-id="21100-184">"戻る"ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="21100-184">Back navigation</span></span>

<span data-ttu-id="21100-185">"戻る"ナビゲーション (Page_A に Page_B) では、同じの手順に従うが元とレプリケーション先のページが逆になります。</span><span class="sxs-lookup"><span data-stu-id="21100-185">For back navigation (Page_B to Page_A), you follow the same steps, but the source and destination pages are reversed.</span></span>

<span data-ttu-id="21100-186">ユーザーが戻る移動したとき、できるだけ早く以前の状態に返されるアプリを期待します。</span><span class="sxs-lookup"><span data-stu-id="21100-186">When the user navigates back, they expect the app to be returned to the previous state as soon as possible.</span></span> <span data-ttu-id="21100-187">したがって、推奨される構成は、 [DirectConnectedAnimationConfiguration]()です。</span><span class="sxs-lookup"><span data-stu-id="21100-187">Therefore, the recommended configuration is [DirectConnectedAnimationConfiguration]().</span></span> <span data-ttu-id="21100-188">このアニメーションはより迅速で直接的であり、減速のイージングを使用します。</span><span class="sxs-lookup"><span data-stu-id="21100-188">This animation is quicker, more direct, and uses the decelerate easing.</span></span>

<span data-ttu-id="21100-189">ソース ページでアニメーションを設定します。</span><span class="sxs-lookup"><span data-stu-id="21100-189">Set up the animation in the source page.</span></span>

```csharp
// Page_B.xaml.cs

protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
{
    if (e.NavigationMode == NavigationMode.Back)
    {
        ConnectedAnimationService.GetForCurrentView()
            .PrepareToAnimate("backAnimation", DestinationImage);

        // Use the recommended configuration for back animation.
        animation.Configuration = new DirectConnectedAnimationConfiguration();
    }
}
```

<span data-ttu-id="21100-190">切り替え先のページでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="21100-190">Start the animation in the destination page.</span></span>

```csharp
// Page_A.xaml.cs

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    ConnectedAnimation animation =
        ConnectedAnimationService.GetForCurrentView().GetAnimation("backAnimation");
    if (animation != null)
    {
        animation.TryStart(SourceImage);
    }
}
```

<span data-ttu-id="21100-191">までの間、アニメーションがセットアップされるとが開始されたときに、ソース要素には、アプリでは、他の UI 上でフリーズが表示されます。</span><span class="sxs-lookup"><span data-stu-id="21100-191">Between the time that the animation is set up and when it's started, the source element appears frozen above other UI in the app.</span></span> <span data-ttu-id="21100-192">これにより、他の切り替えアニメーションを同時に実行できます。</span><span class="sxs-lookup"><span data-stu-id="21100-192">This lets you perform any other transition animations simultaneously.</span></span> <span data-ttu-id="21100-193">このため、ソース要素の有無を煩わしいと感じるもになる可能性がありますので以上 250 ミリ秒を 2 つの手順の間を待機しないようにします。</span><span class="sxs-lookup"><span data-stu-id="21100-193">For this reason, you shouldn't wait more than ~250 milliseconds in between the two steps because the presence of the source element may become distracting.</span></span> <span data-ttu-id="21100-194">アニメーションを準備しても、アニメーションを 3 秒以内に開始しないと、システムによってアニメーションが破棄され、後続の [TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) の呼び出しは失敗します。</span><span class="sxs-lookup"><span data-stu-id="21100-194">If you prepare an animation and do not start it within three seconds, the system will dispose of the animation and any subsequent calls to [TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) will fail.</span></span>

## <a name="connected-animation-in-list-and-grid-experiences"></a><span data-ttu-id="21100-195">リスト エクスペリエンスとグリッド エクスペリエンスでの接続型アニメーション</span><span class="sxs-lookup"><span data-stu-id="21100-195">Connected animation in list and grid experiences</span></span>

<span data-ttu-id="21100-196">多くの場合、リスト コントロールやグリッド コントロール間の切り替えで接続型アニメーションの作成が必要になります。</span><span class="sxs-lookup"><span data-stu-id="21100-196">Often, you will want to create a connected animation from or to a list or grid control.</span></span> <span data-ttu-id="21100-197">[ListView](/uwp/api/windows.ui.xaml.controls.listview)と[GridView](/uwp/api/windows.ui.xaml.controls.gridview)、 [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation)と[TryStartConnectedAnimationAsync](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync)で 2 つのメソッドを使用すると、このプロセスを簡略化します。</span><span class="sxs-lookup"><span data-stu-id="21100-197">You can use the two methods on [ListView](/uwp/api/windows.ui.xaml.controls.listview) and [GridView](/uwp/api/windows.ui.xaml.controls.gridview), [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation) and [TryStartConnectedAnimationAsync](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync), to simplify this process.</span></span>

<span data-ttu-id="21100-198">たとえば、データ テンプレート内に "PortraitEllipse" という名前の要素を含んでいる **ListView** があるとします。</span><span class="sxs-lookup"><span data-stu-id="21100-198">For example, say you have a **ListView** that contains an element with the name "PortraitEllipse" in its data template.</span></span>

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

<span data-ttu-id="21100-199">特定のリスト項目に対応する楕円と接続型アニメーションを準備するには、一意のキー、項目、および"portraitellipse という"名前で[PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation)メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="21100-199">To prepare a connected animation with the ellipse corresponding to a given list item, call the [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation) method with a unique key, the item, and the name "PortraitEllipse".</span></span>

```csharp
void PrepareAnimationWithItem(ContactsItem item)
{
     ContactsListView.PrepareConnectedAnimation("portrait", item, "PortraitEllipse");
}
```

<span data-ttu-id="21100-200">この要素と、詳細ビューから戻る移動するときなど、レプリケーション先としてアニメーションを開始するには、 [TryStartConnectedAnimationAsync](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync)を使用します。</span><span class="sxs-lookup"><span data-stu-id="21100-200">To start an animation with this element as the destination, such as when navigating back from a detail view, use [TryStartConnectedAnimationAsync](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync).</span></span> <span data-ttu-id="21100-201">ListView のデータ ソースが読み込まれると、TryStartConnectedAnimationAsync は、対応する項目コンテナーが作成されるまで、アニメーションが開始されるのを待機します。</span><span class="sxs-lookup"><span data-stu-id="21100-201">If you have just loaded the data source for the ListView, TryStartConnectedAnimationAsync will wait to start the animation until the corresponding item container has been created.</span></span>

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

## <a name="coordinated-animation"></a><span data-ttu-id="21100-202">連動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="21100-202">Coordinated animation</span></span>

![連動型アニメーション](images/connected-animations/coordinated_example.gif)

<!--
<iframe width=640 height=360 src='https://microsoft.sharepoint.com/portals/hub/_layouts/15/VideoEmbedHost.aspx?chId=552c725c%2De353%2D4118%2Dbd2b%2Dc2d0584c9848&amp;vId=9066bbbe%2Dcf58%2D4ab4%2Db274%2D595616f5d0a0&amp;width=640&amp;height=360&amp;autoPlay=false&amp;showInfo=true' allowfullscreen></iframe>
-->

<span data-ttu-id="21100-204">*連動型アニメーション*は、特殊な種類の開始アニメーション、画面上で移動するときに、接続型アニメーションの要素と連動してアニメーション化、接続型アニメーションのターゲットと共に要素が表示されます。</span><span class="sxs-lookup"><span data-stu-id="21100-204">A *coordinated animation* is a special type of entrance animation where an element appears along with the connected animation target, animating in tandem with the connected animation element as it moves across the screen.</span></span> <span data-ttu-id="21100-205">連動型アニメーションによって、ビューの切り替え時に視覚的にさらに注目を引く効果が発生し、ソース ビューと切り替え先のビューの間で共有されているコンテキストにユーザーを注目させることができます。</span><span class="sxs-lookup"><span data-stu-id="21100-205">Coordinated animations can add more visual interest to a transition and further draw the user’s attention to the context that is shared between the source and destination views.</span></span> <span data-ttu-id="21100-206">上記の画像では、連動型アニメーションを使用して、項目のキャプション UI がアニメーション化されています。</span><span class="sxs-lookup"><span data-stu-id="21100-206">In these images, the caption UI for the item is animating using a coordinated animation.</span></span>

<span data-ttu-id="21100-207">連動型アニメーションは、重力の構成を使用する場合は、重力が接続型アニメーションの要素と連動型の要素の両方に適用されます。</span><span class="sxs-lookup"><span data-stu-id="21100-207">When a coordinated animation uses the gravity configuration, gravity is applied to both the connected animation element and the coordinated elements.</span></span> <span data-ttu-id="21100-208">連動型の要素は"swoop"、接続されている要素と共に、本当に連動型の要素を維持します。</span><span class="sxs-lookup"><span data-stu-id="21100-208">The coordinated elements will "swoop" alongside the connected element so the elements stay truly coordinated.</span></span>

<span data-ttu-id="21100-209">**TryStart** の 2 つのパラメーター オーバーロードを使用して、連動型の要素を接続型アニメーションに追加します。</span><span class="sxs-lookup"><span data-stu-id="21100-209">Use the two-parameter overload of **TryStart** to add coordinated elements to a connected animation.</span></span> <span data-ttu-id="21100-210">この例では、"CoverImage"という名前の接続型アニメーションの要素と連動して入力"DescriptionRoot"という名前のグリッド レイアウトの連動型アニメーションを示します。</span><span class="sxs-lookup"><span data-stu-id="21100-210">This example demonstrates a coordinated animation of a Grid layout named "DescriptionRoot" that enters in tandem with a connected animation element named "CoverImage".</span></span>

```xaml
<!-- DestinationPage.xaml -->
<Grid>
    <Image x:Name="CoverImage" />
    <Grid x:Name="DescriptionRoot" />
</Grid>
```

```csharp
// DestinationPage.xaml.cs
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

## <a name="dos-and-donts"></a><span data-ttu-id="21100-211">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="21100-211">Do’s and don’ts</span></span>

- <span data-ttu-id="21100-212">接続型アニメーションは、ソース ページと切り替え先のページの間で要素が共有されている場合に、ページの切り替えで使用してください。</span><span class="sxs-lookup"><span data-stu-id="21100-212">Use a connected animation in page transitions where an element is shared between the source and destination pages.</span></span>
- <span data-ttu-id="21100-213">ナビゲーションの[GravityConnectedAnimationConfiguration]()を使用します。</span><span class="sxs-lookup"><span data-stu-id="21100-213">Use [GravityConnectedAnimationConfiguration]() for forward navigation.</span></span>
- <span data-ttu-id="21100-214">"戻る"ナビゲーション[DirectConnectedAnimationConfiguration]()を使用します。</span><span class="sxs-lookup"><span data-stu-id="21100-214">Use [DirectConnectedAnimationConfiguration]() for back navigation.</span></span>
- <span data-ttu-id="21100-215">ネットワーク要求や他の実行時間の長い非同期の操作の準備と接続型アニメーションの開始の間待機しないでください。</span><span class="sxs-lookup"><span data-stu-id="21100-215">Don't wait on network requests or other long-running asynchronous operations in between preparing and starting a connected animation.</span></span> <span data-ttu-id="21100-216">早めに切り替えを実行するには、必要な情報を事前に読み込んでおく必要があります。または、高解像度の画像が切り替え先のビューに読み込まれるときに、低解像度のプレースホルダー画像を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21100-216">You may need to pre-load the necessary information to run the transition ahead of time, or use a low-resolution placeholder image while a high-resolution image loads in the destination view.</span></span>
- <span data-ttu-id="21100-217">[SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo)を使用して、接続型アニメーションは、既定のナビゲーションを同時に使用できるものであるために、 **ConnectedAnimationService**を使用している場合は、**フレーム**内の切り替えアニメーションを防止するには移行します。</span><span class="sxs-lookup"><span data-stu-id="21100-217">Use [SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) to prevent a transition animation in a **Frame** if you are using **ConnectedAnimationService**, since connected animations aren't meant to be used simultaneously with the default navigation transitions.</span></span> <span data-ttu-id="21100-218">ナビゲーション切り替えの使用方法について詳しくは、「[NavigationThemeTransition](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21100-218">See [NavigationThemeTransition](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition) for more info on how to use navigation transitions.</span></span>

## <a name="download-the-code-samples"></a><span data-ttu-id="21100-219">コード サンプルのダウンロード</span><span class="sxs-lookup"><span data-stu-id="21100-219">Download the code samples</span></span>

<span data-ttu-id="21100-220">[WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) サンプル ギャラリーの[接続型アニメーションのサンプル](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21100-220">See the [Connected Animation sample](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample) in the [WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) sample gallery.</span></span>

## <a name="related-articles"></a><span data-ttu-id="21100-221">関連記事</span><span class="sxs-lookup"><span data-stu-id="21100-221">Related articles</span></span>

[<span data-ttu-id="21100-222">ConnectedAnimation</span><span class="sxs-lookup"><span data-stu-id="21100-222">ConnectedAnimation</span></span>](/uwp/api/windows.ui.xaml.media.animation.connectedanimation)

[<span data-ttu-id="21100-223">ConnectedAnimationService</span><span class="sxs-lookup"><span data-stu-id="21100-223">ConnectedAnimationService</span></span>](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)

[<span data-ttu-id="21100-224">NavigationThemeTransition</span><span class="sxs-lookup"><span data-stu-id="21100-224">NavigationThemeTransition</span></span>](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition)
