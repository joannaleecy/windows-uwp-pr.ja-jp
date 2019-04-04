---
description: 接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。
title: 接続型アニメーション
template: detail.hbs
ms.date: 10/04/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a205fb151d1c9e6614dc97ccde639e43720aa8a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618197"
---
# <a name="connected-animation-for-uwp-apps"></a><span data-ttu-id="cb07e-104">UWP アプリ用の接続型アニメーション</span><span class="sxs-lookup"><span data-stu-id="cb07e-104">Connected animation for UWP apps</span></span>

<span data-ttu-id="cb07e-105">接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-105">Connected animations let you create a dynamic and compelling navigation experience by animating the transition of an element between two different views.</span></span> <span data-ttu-id="cb07e-106">これにより、ユーザーはコンテキストを維持して、ビューの間の継続性を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-106">This helps the user maintain their context and provides continuity between the views.</span></span>

<span data-ttu-id="cb07e-107">アニメーションの結び要素は、新しいビューにその先に、ソース ビュー内の場所から、画面上で飛行の UI コンテンツの変更中に 2 つのビューの間には、[続行] が表示されます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-107">In a connected animation, an element appears to "continue" between two views during a change in UI content, flying across the screen from its location in the source view to its destination in the new view.</span></span> <span data-ttu-id="cb07e-108">これにより、ビューの間の一般的なコンテンツを強調し、遷移の一部として美しいおよび動的な効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-108">This emphasizes the common content between the views and creates a beautiful and dynamic effect as part of a transition.</span></span>

> <span data-ttu-id="cb07e-109">**重要な Api**:[ConnectedAnimation クラス](/uwp/api/windows.ui.xaml.media.animation.connectedanimation)、 [ConnectedAnimationService クラス](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)</span><span class="sxs-lookup"><span data-stu-id="cb07e-109">**Important APIs**:  [ConnectedAnimation class](/uwp/api/windows.ui.xaml.media.animation.connectedanimation), [ConnectedAnimationService class](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)</span></span>

## <a name="see-it-in-action"></a><span data-ttu-id="cb07e-110">実際の動作を見る</span><span class="sxs-lookup"><span data-stu-id="cb07e-110">See it in action</span></span>

<span data-ttu-id="cb07e-111">この短いビデオでは、アプリは、「継続」次のページのヘッダーの一部となる項目のイメージをアニメーション化するのにアニメーションの結び付けを使用します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-111">In this short video, an app uses a connected animation to animate an item image as it "continues" to become part of the header of the next page.</span></span> <span data-ttu-id="cb07e-112">この効果を利用すると、画面の切り替えでユーザー コンテキストを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-112">The effect helps maintain user context across the transition.</span></span>

![接続型アニメーション](images/connected-animations/example.gif)

<!-- 
<iframe width=640 height=360 src='https://microsoft.sharepoint.com/portals/hub/_layouts/15/VideoEmbedHost.aspx?chId=552c725c%2De353%2D4118%2Dbd2b%2Dc2d0584c9848&amp;vId=b2daa5ee%2Dbe15%2D4503%2Db541%2D1328a6587c36&amp;width=640&amp;height=360&amp;autoPlay=false&amp;showInfo=true' allowfullscreen></iframe>
-->

## <a name="video-summary"></a><span data-ttu-id="cb07e-114">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="cb07e-114">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev005/player]

## <a name="connected-animation-and-the-fluent-design-system"></a><span data-ttu-id="cb07e-115">接続型アニメーションと Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="cb07e-115">Connected animation and the Fluent Design System</span></span>

 <span data-ttu-id="cb07e-116">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-116">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="cb07e-117">接続型アニメーションは、アプリに動きを加える Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="cb07e-117">Connected animation is a Fluent Design System component that adds motion to your app.</span></span> <span data-ttu-id="cb07e-118">詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cb07e-118">To learn more, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

## <a name="why-connected-animation"></a><span data-ttu-id="cb07e-119">接続型アニメーションを使用する理由</span><span class="sxs-lookup"><span data-stu-id="cb07e-119">Why connected animation?</span></span>

<span data-ttu-id="cb07e-120">ページ間を移動するときには、移動後にどのような新しいコンテンツが表示されるか、その新しいコンテンツがページを移動するユーザーの目的とどのように関連しているかを、ユーザーが理解できるようにすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="cb07e-120">When navigating between pages, it’s important for the user to understand what new content is being presented after the navigation and how it relates to their intent when navigating.</span></span> <span data-ttu-id="cb07e-121">接続型アニメーションを利用すると、2 つのビューで共有されているコンテンツにユーザーを注目させることによって、2 つのビューの間の関係を強調する強力な視覚的メタファが実現されます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-121">Connected animations provide a powerful visual metaphor that emphasizes the relationship between two views by drawing the user’s focus to the content shared between them.</span></span> <span data-ttu-id="cb07e-122">また、接続型アニメーションによって、ページを移動するときに、視覚的に注目を引く効果や洗練された視覚効果を発生させることができます。このことは、アプリのモーション デザインを特徴付ける際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-122">Additionally, connected animations add visual interest and polish to page navigation that can help differentiate the motion design of your app.</span></span>

## <a name="when-to-use-connected-animation"></a><span data-ttu-id="cb07e-123">接続型アニメーションを使用するタイミング</span><span class="sxs-lookup"><span data-stu-id="cb07e-123">When to use connected animation</span></span>

<span data-ttu-id="cb07e-124">一般に、接続型アニメーションはページを変更するとき使用されます。ただし、UI のコンテンツを変更するときに、そのコンテンツが維持されるようにユーザーに対して表示する必要がある場合は、接続型アニメーションをどのようなエクスペリエンスにでも適用できます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-124">Connected animations are generally used when changing pages, though they can be applied to any experience where you are changing content in a UI and want the user to maintain context.</span></span> <span data-ttu-id="cb07e-125">ソース ビューと切り替え先のビューの間で UI の画像や他の UI の要素が共有されている場合は、必ず、[ドリル インによるナビゲーション切り替え](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)ではなく、接続型アニメーションの使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="cb07e-125">You should consider using a connected animation instead of a [drill in navigation transition](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx) whenever there is an image or other piece of UI shared between the source and destination views.</span></span>

## <a name="configure-connected-animation"></a><span data-ttu-id="cb07e-126">アニメーションの結び付けを構成します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-126">Configure connected animation</span></span>

> [!IMPORTANT]
> <span data-ttu-id="cb07e-127">この機能では、アプリのターゲット バージョンの Windows 10、バージョンは 1809 である必要があります ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="cb07e-127">This feature requires that your app's Target version be Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later.</span></span> <span data-ttu-id="cb07e-128">構成プロパティは、以前の Sdk でご利用いただけません。</span><span class="sxs-lookup"><span data-stu-id="cb07e-128">The Configuration property is not available in earlier SDKs.</span></span> <span data-ttu-id="cb07e-129">SDK 17763 より前の最小バージョンを対象にするアダプティブ コードまたは条件付き XAML を使用します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-129">You can target a Minimum version lower than SDK 17763 using adaptive code or conditional XAML.</span></span> <span data-ttu-id="cb07e-130">詳細については、[バージョン アダプティブ アプリ](/windows/uwp/debug-test-perf/version-adaptive-apps)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cb07e-130">For more info, see [Version adaptive apps](/windows/uwp/debug-test-perf/version-adaptive-apps).</span></span>

<span data-ttu-id="cb07e-131">以降では、Windows 10、バージョンは 1809、アニメーションの結び付けさらに具体化 Fluent デザインのアニメーションを提供することで構成調整と旧バージョンと順方向専用のページ ナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="cb07e-131">Starting in Windows 10, version 1809, connected animations further embody Fluent design by providing animation configurations tailored specifically for forward and backwards page navigation.</span></span>

<span data-ttu-id="cb07e-132">アニメーションは、の構成を指定するには、構成プロパティ、ConnectedAnimation を設定します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-132">You specify an animation configuration by setting the Configuration property on the ConnectedAnimation.</span></span> <span data-ttu-id="cb07e-133">(紹介の例として、次のセクションでします。)</span><span class="sxs-lookup"><span data-stu-id="cb07e-133">(We’ll show examples of this in the next section.)</span></span>

<span data-ttu-id="cb07e-134">このテーブルには、使用可能な構成について説明します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-134">This table describes the available configurations.</span></span> <span data-ttu-id="cb07e-135">これらのアニメーションに適用されるモーション原則の詳細については、[の方向や重力](index.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cb07e-135">For more information about the motion principles applied in these animations, see [Directionality and gravity](index.md).</span></span>

| [<span data-ttu-id="cb07e-136">GravityConnectedAnimationConfiguration</span><span class="sxs-lookup"><span data-stu-id="cb07e-136">GravityConnectedAnimationConfiguration</span></span>](/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration) |
| - |
| <span data-ttu-id="cb07e-137">既定の構成では、これは"進む"ナビゲーション推奨します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-137">This is the default configuration, and is recommended for forward navigation.</span></span> |
<span data-ttu-id="cb07e-138">アプリ (A B から) での前方移動している間、ユーザー、物理的に"pull がページ外"に接続されている要素が表示されます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-138">As the user navigates forward in the app (A to B), the connected element appears to physically “pull off the page”.</span></span> <span data-ttu-id="cb07e-139">そうでは、要素は、z 座標で前方に移動するが表示され、重力を保留中の影響を少しで、削除します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-139">In doing so, the element appears to move forward in z-space and drops a bit as an effect of gravity taking hold.</span></span> <span data-ttu-id="cb07e-140">重力の影響をなくすためには、要素は速度の向上し、を迅速に、最後の位置。</span><span class="sxs-lookup"><span data-stu-id="cb07e-140">To overcome the effects of gravity, the element gains velocity and accelerates into its final position.</span></span> <span data-ttu-id="cb07e-141">「スケールと dip」アニメーションになります。</span><span class="sxs-lookup"><span data-stu-id="cb07e-141">The result is a “scale and dip” animation.</span></span> |

| [<span data-ttu-id="cb07e-142">DirectConnectedAnimationConfiguration</span><span class="sxs-lookup"><span data-stu-id="cb07e-142">DirectConnectedAnimationConfiguration</span></span>](/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration) |
| - |
| <span data-ttu-id="cb07e-143">ユーザーはアプリ (B) では後方移動したときにアニメーションがより直接的にします。</span><span class="sxs-lookup"><span data-stu-id="cb07e-143">As the user navigates backwards in the app (B to A), the animation is more direct.</span></span> <span data-ttu-id="cb07e-144">接続されている要素は、直線的には減速 3 次ベジエ イージング関数を使用して、B から変換します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-144">The connected element linearly translates from B to A using a decelerate cubic Bezier easing function.</span></span> <span data-ttu-id="cb07e-145">旧バージョンと visual アフォー ダンスは、できるだけ高速、ナビゲーションのフローのコンテキストを維持しながら、ユーザーを以前の状態に返します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-145">The backwards visual affordance returns the user to their previous state as fast as possible while still maintaining the context of the navigation flow.</span></span> |

| [<span data-ttu-id="cb07e-146">BasicConnectedAnimationConfiguration</span><span class="sxs-lookup"><span data-stu-id="cb07e-146">BasicConnectedAnimationConfiguration</span></span>](/uwp/api/windows.ui.xaml.media.animation.basicconnectedanimationconfiguration) |
| - |
| <span data-ttu-id="cb07e-147">これは、既定値 (および専用) Windows 10、バージョンは 1809 より前のバージョンで使用されるアニメーション ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk))。</span><span class="sxs-lookup"><span data-stu-id="cb07e-147">This is the default (and only) animation used in versions prior to Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)).</span></span> |

### <a name="connectedanimationservice-configuration"></a><span data-ttu-id="cb07e-148">ConnectedAnimationService 構成</span><span class="sxs-lookup"><span data-stu-id="cb07e-148">ConnectedAnimationService configuration</span></span>

<span data-ttu-id="cb07e-149">[ConnectedAnimationService](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)クラス全体のサービスではなく、個々 のアニメーションに適用される 2 つのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="cb07e-149">The [ConnectedAnimationService](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice) class has two properties that apply to the individual animations rather than the overall service.</span></span>

- [<span data-ttu-id="cb07e-150">DefaultDuration</span><span class="sxs-lookup"><span data-stu-id="cb07e-150">DefaultDuration</span></span>](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.defaultduration)
- [<span data-ttu-id="cb07e-151">DefaultEasingFunction</span><span class="sxs-lookup"><span data-stu-id="cb07e-151">DefaultEasingFunction</span></span>](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.defaulteasingfunction)

<span data-ttu-id="cb07e-152">さまざまな効果を実現するためにいくつかの構成は ConnectedAnimationService でこれらのプロパティを無視して、独自の値を使用して、代わりに、この表で説明します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-152">To achieve the various effects, some configurations ignore these properties on ConnectedAnimationService and use their own values instead, as described in this table.</span></span>

| <span data-ttu-id="cb07e-153">構成</span><span class="sxs-lookup"><span data-stu-id="cb07e-153">Configuration</span></span> | <span data-ttu-id="cb07e-154">保護に努めています DefaultDuration でしょうか。</span><span class="sxs-lookup"><span data-stu-id="cb07e-154">Respects DefaultDuration?</span></span> | <span data-ttu-id="cb07e-155">保護に努めています DefaultEasingFunction でしょうか。</span><span class="sxs-lookup"><span data-stu-id="cb07e-155">Respects DefaultEasingFunction?</span></span> |
| - | - | - |
| <span data-ttu-id="cb07e-156">重力</span><span class="sxs-lookup"><span data-stu-id="cb07e-156">Gravity</span></span> | <span data-ttu-id="cb07e-157">〇</span><span class="sxs-lookup"><span data-stu-id="cb07e-157">Yes</span></span> | <span data-ttu-id="cb07e-158">○\*</span><span class="sxs-lookup"><span data-stu-id="cb07e-158">Yes\*</span></span> <br/> <span data-ttu-id="cb07e-159">\**A から B への基本的な変換がこのイージング関数を使用しますが、"重力 dip"が、独自のイージング関数。*</span><span class="sxs-lookup"><span data-stu-id="cb07e-159">\**The basic translation from A to B uses this easing function, but the "gravity dip" has its own easing function.*</span></span>  |
| <span data-ttu-id="cb07e-160">ダイレクト</span><span class="sxs-lookup"><span data-stu-id="cb07e-160">Direct</span></span> | <span data-ttu-id="cb07e-161">X</span><span class="sxs-lookup"><span data-stu-id="cb07e-161">No</span></span> <br/> <span data-ttu-id="cb07e-162">*超える 150ms をアニメーション化します。*</span><span class="sxs-lookup"><span data-stu-id="cb07e-162">*Animates over 150ms.*</span></span>| <span data-ttu-id="cb07e-163">X</span><span class="sxs-lookup"><span data-stu-id="cb07e-163">No</span></span> <br/> <span data-ttu-id="cb07e-164">*イージング関数は、減速を使用します。*</span><span class="sxs-lookup"><span data-stu-id="cb07e-164">*Uses the Decelerate easing function.*</span></span> |
| <span data-ttu-id="cb07e-165">基本</span><span class="sxs-lookup"><span data-stu-id="cb07e-165">Basic</span></span> | <span data-ttu-id="cb07e-166">〇</span><span class="sxs-lookup"><span data-stu-id="cb07e-166">Yes</span></span> | <span data-ttu-id="cb07e-167">〇</span><span class="sxs-lookup"><span data-stu-id="cb07e-167">Yes</span></span> |

## <a name="how-to-implement-connected-animation"></a><span data-ttu-id="cb07e-168">アニメーションの結び付けを実装する方法</span><span class="sxs-lookup"><span data-stu-id="cb07e-168">How to implement connected animation</span></span>

<span data-ttu-id="cb07e-169">接続型アニメーションのセットアップでは、次の 2 つの手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-169">Setting up a connected animation involves two steps:</span></span>

1. <span data-ttu-id="cb07e-170">*準備*ソース ページで、システムに、ソース要素がアニメーションの結び付けに参加することを示すアニメーション オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="cb07e-170">*Prepare* an animation object on the source page, which indicates to the system that the source element will participate in the connected animation.</span></span>
1. <span data-ttu-id="cb07e-171">*開始*ターゲット要素への参照を渡して、移動先ページのアニメーション。</span><span class="sxs-lookup"><span data-stu-id="cb07e-171">*Start* the animation on the destination page, passing a reference to the destination element.</span></span>

<span data-ttu-id="cb07e-172">元のページからの移動時に呼び出す[ConnectedAnimationService.GetForCurrentView](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getforcurrentview) ConnectedAnimationService のインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-172">When navigating from the source page, call [ConnectedAnimationService.GetForCurrentView](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getforcurrentview) to get an instance of ConnectedAnimationService.</span></span> <span data-ttu-id="cb07e-173">アニメーションを準備するには、呼び出す[PrepareToAnimate](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.preparetoanimate)このインスタンスし、一意のキーと、移行で使用する UI 要素を渡します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-173">To prepare an animation, call [PrepareToAnimate](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.preparetoanimate) on this instance, and pass in a unique key and the UI element you want to use in the transition.</span></span> <span data-ttu-id="cb07e-174">一意のキーを使用して、移動先ページでは後で、アニメーションを取得できます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-174">The unique key lets you retrieve the animation later on the destination page.</span></span>

```csharp
ConnectedAnimationService.GetForCurrentView()
    .PrepareToAnimate("forwardAnimation", SourceImage);
```

<span data-ttu-id="cb07e-175">ナビゲーションが発生したときに、移動先ページで、アニメーションを起動します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-175">When the navigation occurs, start the animation in the destination page.</span></span> <span data-ttu-id="cb07e-176">アニメーションを開始するには、[ConnectedAnimation.TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-176">To start the animation, call [ConnectedAnimation.TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart).</span></span> <span data-ttu-id="cb07e-177">アニメーションの作成時に指定した一意のキーを使用して [ConnectedAnimationService.GetAnimation](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getanimation) を呼び出すことにより、適切なアニメーションのインスタンスを取得できます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-177">You can retrieve the right animation instance by calling [ConnectedAnimationService.GetAnimation](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getanimation) with the unique key you provided when creating the animation.</span></span>

```csharp
ConnectedAnimation animation =
    ConnectedAnimationService.GetForCurrentView().GetAnimation("forwardAnimation");
if (animation != null)
{
    animation.TryStart(DestinationImage);
}
```

### <a name="forward-navigation"></a><span data-ttu-id="cb07e-178">"進む"ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="cb07e-178">Forward navigation</span></span>

<span data-ttu-id="cb07e-179">この例では、ConnectedAnimationService を使用して、2 つのページ (Page_B に Page_A)"進む"ナビゲーションの遷移を作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-179">This example shows how to use ConnectedAnimationService to create a transition for forward navigation between two pages (Page_A to Page_B).</span></span>

<span data-ttu-id="cb07e-180">"進む"ナビゲーション推奨されるアニメーションの構成が[GravityConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration)します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-180">The recommended animation configuration for forward navigation is [GravityConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration).</span></span> <span data-ttu-id="cb07e-181">設定する必要はありませんは、既定値は、これは、[構成](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.configuration)プロパティを別の構成を指定しない場合。</span><span class="sxs-lookup"><span data-stu-id="cb07e-181">This is the default, so you don't need to set the [Configuration](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.configuration) property unless you want to specify a different configuration.</span></span>

<span data-ttu-id="cb07e-182">ソース ページでアニメーションを設定します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-182">Set up the animation in the source page.</span></span>

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

<span data-ttu-id="cb07e-183">移動先ページでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-183">Start the animation in the destination page.</span></span>

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

### <a name="back-navigation"></a><span data-ttu-id="cb07e-184">戻るナビゲーション</span><span class="sxs-lookup"><span data-stu-id="cb07e-184">Back navigation</span></span>

<span data-ttu-id="cb07e-185">戻るナビゲーション (Page_A に Page_B) のため、同じ手順に従いますが、元とコピー先のページが取り消されます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-185">For back navigation (Page_B to Page_A), you follow the same steps, but the source and destination pages are reversed.</span></span>

<span data-ttu-id="cb07e-186">ユーザーがバックアップに移動したときに、以前の状態に、できるだけ早く返されるアプリが期待されます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-186">When the user navigates back, they expect the app to be returned to the previous state as soon as possible.</span></span> <span data-ttu-id="cb07e-187">そのため、推奨される構成は[DirectConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration)します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-187">Therefore, the recommended configuration is [DirectConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration).</span></span> <span data-ttu-id="cb07e-188">このアニメーションは高速より直接的にあり、減速のイージングを使用します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-188">This animation is quicker, more direct, and uses the decelerate easing.</span></span>

<span data-ttu-id="cb07e-189">ソース ページでアニメーションを設定します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-189">Set up the animation in the source page.</span></span>

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

<span data-ttu-id="cb07e-190">移動先ページでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-190">Start the animation in the destination page.</span></span>

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

<span data-ttu-id="cb07e-191">までの時間は起動時に、アニメーションが設定されていると、ソース要素は、アプリで他の UI の上に固定表示されます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-191">Between the time that the animation is set up and when it's started, the source element appears frozen above other UI in the app.</span></span> <span data-ttu-id="cb07e-192">その他の遷移のアニメーションを同時に実行できます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-192">This lets you perform any other transition animations simultaneously.</span></span> <span data-ttu-id="cb07e-193">このため、ソース要素の存在を無駄になる可能性がありますので、2 つの手順の間 ~ 250 以上のミリ秒の待機することはできません。</span><span class="sxs-lookup"><span data-stu-id="cb07e-193">For this reason, you shouldn't wait more than ~250 milliseconds in between the two steps because the presence of the source element may become distracting.</span></span> <span data-ttu-id="cb07e-194">アニメーションを準備しても、アニメーションを 3 秒以内に開始しないと、システムによってアニメーションが破棄され、後続の [TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) の呼び出しは失敗します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-194">If you prepare an animation and do not start it within three seconds, the system will dispose of the animation and any subsequent calls to [TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) will fail.</span></span>

## <a name="connected-animation-in-list-and-grid-experiences"></a><span data-ttu-id="cb07e-195">リスト エクスペリエンスとグリッド エクスペリエンスでの接続型アニメーション</span><span class="sxs-lookup"><span data-stu-id="cb07e-195">Connected animation in list and grid experiences</span></span>

<span data-ttu-id="cb07e-196">多くの場合、リスト コントロールやグリッド コントロール間の切り替えで接続型アニメーションの作成が必要になります。</span><span class="sxs-lookup"><span data-stu-id="cb07e-196">Often, you will want to create a connected animation from or to a list or grid control.</span></span> <span data-ttu-id="cb07e-197">2 つのメソッドを使用するには[ListView](/uwp/api/windows.ui.xaml.controls.listview)と[GridView](/uwp/api/windows.ui.xaml.controls.gridview)、 [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation)と[trystartconnectedanimationasync です](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync)、このプロセスが簡略化します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-197">You can use the two methods on [ListView](/uwp/api/windows.ui.xaml.controls.listview) and [GridView](/uwp/api/windows.ui.xaml.controls.gridview), [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation) and [TryStartConnectedAnimationAsync](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync), to simplify this process.</span></span>

<span data-ttu-id="cb07e-198">たとえば、データ テンプレート内に "PortraitEllipse" という名前の要素を含んでいる **ListView** があるとします。</span><span class="sxs-lookup"><span data-stu-id="cb07e-198">For example, say you have a **ListView** that contains an element with the name "PortraitEllipse" in its data template.</span></span>

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

<span data-ttu-id="cb07e-199">特定のリスト項目に対応する楕円をアニメーションの結び付けを準備するには、呼び出し、 [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation)一意キー、アイテム、および"PortraitEllipse"という名前を持つメソッド。</span><span class="sxs-lookup"><span data-stu-id="cb07e-199">To prepare a connected animation with the ellipse corresponding to a given list item, call the [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation) method with a unique key, the item, and the name "PortraitEllipse".</span></span>

```csharp
void PrepareAnimationWithItem(ContactsItem item)
{
     ContactsListView.PrepareConnectedAnimation("portrait", item, "PortraitEllipse");
}
```

<span data-ttu-id="cb07e-200">など、詳細ビューから後方に移動すると、変換先として、この要素にアニメーションを開始するには使用[trystartconnectedanimationasync です](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync)します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-200">To start an animation with this element as the destination, such as when navigating back from a detail view, use [TryStartConnectedAnimationAsync](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync).</span></span> <span data-ttu-id="cb07e-201">ListView のデータ ソースが読み込んだ trystartconnectedanimationasync ですは対応する項目コンテナーが作成されるまで、アニメーションの開始を待機します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-201">If you have just loaded the data source for the ListView, TryStartConnectedAnimationAsync will wait to start the animation until the corresponding item container has been created.</span></span>

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

## <a name="coordinated-animation"></a><span data-ttu-id="cb07e-202">連動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="cb07e-202">Coordinated animation</span></span>

![連動型アニメーション](images/connected-animations/coordinated_example.gif)

<!--
<iframe width=640 height=360 src='https://microsoft.sharepoint.com/portals/hub/_layouts/15/VideoEmbedHost.aspx?chId=552c725c%2De353%2D4118%2Dbd2b%2Dc2d0584c9848&amp;vId=9066bbbe%2Dcf58%2D4ab4%2Db274%2D595616f5d0a0&amp;width=640&amp;height=360&amp;autoPlay=false&amp;showInfo=true' allowfullscreen></iframe>
-->

<span data-ttu-id="cb07e-204">A*アニメーションを調整*特殊な種類の開始のアニメーションは、要素が画面上で移動するときに、アニメーションの結び付け要素と連携してアニメーション化、アニメーションの結び付けターゲットと共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-204">A *coordinated animation* is a special type of entrance animation where an element appears along with the connected animation target, animating in tandem with the connected animation element as it moves across the screen.</span></span> <span data-ttu-id="cb07e-205">連動型アニメーションによって、ビューの切り替え時に視覚的にさらに注目を引く効果が発生し、ソース ビューと切り替え先のビューの間で共有されているコンテキストにユーザーを注目させることができます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-205">Coordinated animations can add more visual interest to a transition and further draw the user’s attention to the context that is shared between the source and destination views.</span></span> <span data-ttu-id="cb07e-206">上記の画像では、連動型アニメーションを使用して、項目のキャプション UI がアニメーション化されています。</span><span class="sxs-lookup"><span data-stu-id="cb07e-206">In these images, the caption UI for the item is animating using a coordinated animation.</span></span>

<span data-ttu-id="cb07e-207">調整されたアニメーションは、重力構成を使用する場合は、重力がアニメーションの結び付け要素と調整の要素の両方に適用されます。</span><span class="sxs-lookup"><span data-stu-id="cb07e-207">When a coordinated animation uses the gravity configuration, gravity is applied to both the connected animation element and the coordinated elements.</span></span> <span data-ttu-id="cb07e-208">連携のとれた要素は"swoop"接続されている要素と共に、真の連携した要素を維持します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-208">The coordinated elements will "swoop" alongside the connected element so the elements stay truly coordinated.</span></span>

<span data-ttu-id="cb07e-209">**TryStart** の 2 つのパラメーター オーバーロードを使用して、連動型の要素を接続型アニメーションに追加します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-209">Use the two-parameter overload of **TryStart** to add coordinated elements to a connected animation.</span></span> <span data-ttu-id="cb07e-210">この例では、"CoverImage"という名前のアニメーションの結び付け要素が連携して入力した"DescriptionRoot"という名前のグリッド レイアウトの調整されたアニメーションを示します。</span><span class="sxs-lookup"><span data-stu-id="cb07e-210">This example demonstrates a coordinated animation of a Grid layout named "DescriptionRoot" that enters in tandem with a connected animation element named "CoverImage".</span></span>

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

## <a name="dos-and-donts"></a><span data-ttu-id="cb07e-211">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="cb07e-211">Do’s and don’ts</span></span>

- <span data-ttu-id="cb07e-212">接続型アニメーションは、ソース ページと切り替え先のページの間で要素が共有されている場合に、ページの切り替えで使用してください。</span><span class="sxs-lookup"><span data-stu-id="cb07e-212">Use a connected animation in page transitions where an element is shared between the source and destination pages.</span></span>
- <span data-ttu-id="cb07e-213">使用[GravityConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration) "進む"ナビゲーションの。</span><span class="sxs-lookup"><span data-stu-id="cb07e-213">Use [GravityConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration) for forward navigation.</span></span>
- <span data-ttu-id="cb07e-214">使用[DirectConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration)のナビゲーションをバックアップします。</span><span class="sxs-lookup"><span data-stu-id="cb07e-214">Use [DirectConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration) for back navigation.</span></span>
- <span data-ttu-id="cb07e-215">ネットワーク要求または他の実行時間の長い非同期の操作を準備して、接続されているアニメーションの開始の間に待機はありません。</span><span class="sxs-lookup"><span data-stu-id="cb07e-215">Don't wait on network requests or other long-running asynchronous operations in between preparing and starting a connected animation.</span></span> <span data-ttu-id="cb07e-216">早めに切り替えを実行するには、必要な情報を事前に読み込んでおく必要があります。または、高解像度の画像が切り替え先のビューに読み込まれるときに、低解像度のプレースホルダー画像を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cb07e-216">You may need to pre-load the necessary information to run the transition ahead of time, or use a low-resolution placeholder image while a high-resolution image loads in the destination view.</span></span>
- <span data-ttu-id="cb07e-217">使用[SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo)の遷移のアニメーションを防ぐために、**フレーム**を使用する場合**ConnectedAnimationService**、アニメーションの結び付け以降既定のナビゲーションの切り替えを同時に使用するためのものはありません。</span><span class="sxs-lookup"><span data-stu-id="cb07e-217">Use [SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) to prevent a transition animation in a **Frame** if you are using **ConnectedAnimationService**, since connected animations aren't meant to be used simultaneously with the default navigation transitions.</span></span> <span data-ttu-id="cb07e-218">ナビゲーション切り替えの使用方法について詳しくは、「[NavigationThemeTransition](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cb07e-218">See [NavigationThemeTransition](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition) for more info on how to use navigation transitions.</span></span>

## <a name="download-the-code-samples"></a><span data-ttu-id="cb07e-219">コード サンプルのダウンロード</span><span class="sxs-lookup"><span data-stu-id="cb07e-219">Download the code samples</span></span>

<span data-ttu-id="cb07e-220">[WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) サンプル ギャラリーの[接続型アニメーションのサンプル](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cb07e-220">See the [Connected Animation sample](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample) in the [WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) sample gallery.</span></span>

## <a name="related-articles"></a><span data-ttu-id="cb07e-221">関連記事</span><span class="sxs-lookup"><span data-stu-id="cb07e-221">Related articles</span></span>

[<span data-ttu-id="cb07e-222">ConnectedAnimation</span><span class="sxs-lookup"><span data-stu-id="cb07e-222">ConnectedAnimation</span></span>](/uwp/api/windows.ui.xaml.media.animation.connectedanimation)

[<span data-ttu-id="cb07e-223">ConnectedAnimationService</span><span class="sxs-lookup"><span data-stu-id="cb07e-223">ConnectedAnimationService</span></span>](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)

[<span data-ttu-id="cb07e-224">NavigationThemeTransition</span><span class="sxs-lookup"><span data-stu-id="cb07e-224">NavigationThemeTransition</span></span>](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition)
