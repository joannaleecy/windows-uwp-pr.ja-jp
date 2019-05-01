---
author: knicholasa
description: Z 深度、または相対パスは深さを効率的かつ自然には、ユーザーが専念を支援するアプリに組み込む方法は 2 つの深さ、およびシャドウします。
title: Z 深さと UWP アプリのシャドウ
template: detail.hbs
ms.author: nichola
ms.date: 04/19/2019
ms.topic: article
ms.custom: 19H1
keywords: windows 10, uwp
pm-contact: chigy
ms.localizationpriority: medium
ms.openlocfilehash: ab49f13d3938e55750ce523f9e0d4ae241304763
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63817713"
---
# <a name="z-depth-and-shadow"></a><span data-ttu-id="ce237-104">Z 深度とシャドウ</span><span class="sxs-lookup"><span data-stu-id="ce237-104">Z-depth and shadow</span></span>

![灰色の 4 つの四角形を示す gif は積み上げ斜めの上に他のいずれかです。](images/elevation-shadow/shadow.gif)

<span data-ttu-id="ce237-107">UI に要素の階層構造を作成する UI を簡単にスキャンしに集中する重要なことを伝達します。</span><span class="sxs-lookup"><span data-stu-id="ce237-107">Creating a visual hierarchy of elements in your UI makes the UI easy to scan and conveys what is important to focus on.</span></span> <span data-ttu-id="ce237-108">昇格の転送、UI の要素を選択することを act がソフトウェアで、このような階層を実現するためによく使用されます。</span><span class="sxs-lookup"><span data-stu-id="ce237-108">Elevation, the act of bringing select elements of your UI forward, is often used to achieve such a hierarchy in software.</span></span> <span data-ttu-id="ce237-109">この記事では、z 深さとシャドウを使用して UWP アプリで昇格を作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ce237-109">This article discusses how to create elevation in a UWP app by using z-depth and shadow.</span></span>

<span data-ttu-id="ce237-110">Z 深さは、z 軸に沿って 2 つの画面間の距離を示すために 3D アプリ作成者の間で使用される用語です。</span><span class="sxs-lookup"><span data-stu-id="ce237-110">Z-depth is a term used amongst 3D app creators to denote the distance between two surfaces along the z-axis.</span></span> <span data-ttu-id="ce237-111">オブジェクトは、ビューアーに、閉じる方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ce237-111">It illustrates how close an object is to the viewer.</span></span> <span data-ttu-id="ce237-112">X に同様の概念を考えて/y 座標、z 方向の。</span><span class="sxs-lookup"><span data-stu-id="ce237-112">Think of it as a similar concept to x/y coordinates, but in the z direction.</span></span>

## <a name="why-use-z-depth"></a><span data-ttu-id="ce237-113">Z 深さを使用する理由</span><span class="sxs-lookup"><span data-stu-id="ce237-113">Why use z-depth?</span></span>

<span data-ttu-id="ce237-114">現実の世界では、私たちに近いオブジェクトに集中する傾向があります。</span><span class="sxs-lookup"><span data-stu-id="ce237-114">In the physical world, we tend to focus on objects that are closer to us.</span></span> <span data-ttu-id="ce237-115">この空間本能デジタル ui にも適用できます。</span><span class="sxs-lookup"><span data-stu-id="ce237-115">We can apply this spatial instinct to digital UI as well.</span></span> <span data-ttu-id="ce237-116">たとえば、ユーザーに近い要素を移行する場合、ユーザーは本能に集中して要素。</span><span class="sxs-lookup"><span data-stu-id="ce237-116">For example, if you bring an element closer to the user, then the user will instinctively focus on the element.</span></span> <span data-ttu-id="ce237-117">移動 UI 要素により近い z 軸で、ユーザー、アプリで、タスクを効率的かつ自然に完了を支援する、オブジェクト間のビジュアルの階層を確立できます。</span><span class="sxs-lookup"><span data-stu-id="ce237-117">By moving UI elements closer in z-axis, you can establish visual hierarchy between objects, helping users complete tasks naturally and efficiently in your app.</span></span>

## <a name="what-is-shadow"></a><span data-ttu-id="ce237-118">シャドウとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="ce237-118">What is shadow?</span></span>

<span data-ttu-id="ce237-119">シャドウは、ユーザーの昇格を認識する方法の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="ce237-119">Shadow is one way a user perceives elevation.</span></span> <span data-ttu-id="ce237-120">管理者特権でのオブジェクトの上のライトは、次の画面で影を作成します。</span><span class="sxs-lookup"><span data-stu-id="ce237-120">Light above an elevated object creates a shadow on the surface below.</span></span> <span data-ttu-id="ce237-121">オブジェクトが大きいほどより大きなおよび柔軟性の高い、シャドウになります。</span><span class="sxs-lookup"><span data-stu-id="ce237-121">The higher the object, the larger and softer the shadow becomes.</span></span> <span data-ttu-id="ce237-122">管理者特権でのオブジェクトの UI には、影ができる必要はありませんが、昇格時の外観を作成できます。</span><span class="sxs-lookup"><span data-stu-id="ce237-122">Elevated objects in your UI don’t need to have shadows, but they help create the appearance of elevation.</span></span>

<span data-ttu-id="ce237-123">UWP アプリでは、見た目のではなく、意図的な方法で影を使用してください。</span><span class="sxs-lookup"><span data-stu-id="ce237-123">In UWP apps, shadows should be used in a purposeful rather than aesthetic manner.</span></span> <span data-ttu-id="ce237-124">多すぎるの影を使用して、低下またはユーザーを集中する影のことを排除します。</span><span class="sxs-lookup"><span data-stu-id="ce237-124">Using too many shadows will decrease or eliminate the ability of the shadow to focus the user.</span></span>

<span data-ttu-id="ce237-125">標準のコントロールを使用する場合、UI に ThemeShadow 影を自動的に組み込まれる予定です。</span><span class="sxs-lookup"><span data-stu-id="ce237-125">If you use standard controls, ThemeShadow shadows will be incorporated automatically into your UI.</span></span> <span data-ttu-id="ce237-126">ただし、手動で追加できます影の UI に、ThemeShadow または DropShadow Api を使用しています。</span><span class="sxs-lookup"><span data-stu-id="ce237-126">However, you can manually include shadows in your UI by using either the ThemeShadow or the DropShadow APIs.</span></span> 

## <a name="themeshadow"></a><span data-ttu-id="ce237-127">ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="ce237-127">ThemeShadow</span></span>

<span data-ttu-id="ce237-128">型を描画するために任意の XAML 要素に適用できる ThemeShadow では、適切にに基づいて x、y、z 座標をシャドウします。</span><span class="sxs-lookup"><span data-stu-id="ce237-128">The ThemeShadow type can be applied to any XAML element to draw shadows appropriately based on x, y, z coordinates.</span></span> <span data-ttu-id="ce237-129">ThemeShadow が他の環境の仕様についても自動的に調整されます。</span><span class="sxs-lookup"><span data-stu-id="ce237-129">ThemeShadow also automatically adjusts for other environmental specifications:</span></span>

- <span data-ttu-id="ce237-130">ライティング、ユーザーのテーマ、アプリの環境、およびシェルの変更に適応します。</span><span class="sxs-lookup"><span data-stu-id="ce237-130">Adapts to changes in lighting, user theme, app environment, and shell.</span></span>
- <span data-ttu-id="ce237-131">要素の z 深さに基づいて自動的に影を適用します。</span><span class="sxs-lookup"><span data-stu-id="ce237-131">Applies shadows to elements automatically based on their z-depth.</span></span> 
- <span data-ttu-id="ce237-132">同期を保つ要素に移動し、昇格を変更します。</span><span class="sxs-lookup"><span data-stu-id="ce237-132">Keeps elements in sync as they move and change elevation.</span></span>
- <span data-ttu-id="ce237-133">全体とアプリケーション間で一貫性のあるシャドウを保持します。</span><span class="sxs-lookup"><span data-stu-id="ce237-133">Keeps shadows consistent throughout and across applications.</span></span>

<span data-ttu-id="ce237-134">次に示します、MenuFlyout で ThemeShadow がどのように実装されています。</span><span class="sxs-lookup"><span data-stu-id="ce237-134">Here is how ThemeShadow has been implemented on a MenuFlyout.</span></span> <span data-ttu-id="ce237-135">MenuFlyout は、エクスペリエンスをメイン画面が 32px に昇格され、各追加のカスケード メニューが開かれた +-8 px から開く メニューの上に組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="ce237-135">MenuFlyout has a built in experience where the main surface is elevated to 32px and each additional cascading menu is opened +8px above the menu it opens from.</span></span>

![3 つのオープンな入れ子になったメニューで、MenuFlyout に適用される ThemeShadow のスクリーン ショット。](images/elevation-shadow/themeshadow-menuflyout.png)

### <a name="themeshadow-in-common-controls"></a><span data-ttu-id="ce237-138">ThemeShadow を共通の制御します。</span><span class="sxs-lookup"><span data-stu-id="ce237-138">ThemeShadow in common controls</span></span>

<span data-ttu-id="ce237-139">次の一般的なコントロールは、特に明記しない限り、32px 深さからシャドウをキャストするのに ThemeShadow を自動的に使用されます。</span><span class="sxs-lookup"><span data-stu-id="ce237-139">The following common controls will automatically use ThemeShadow to cast shadows from 32px depth unless otherwise specified:</span></span>

- <span data-ttu-id="ce237-140">[コンテキスト メニュー](../controls-and-patterns/menus.md)、[コマンド バー](../controls-and-patterns/app-bars.md)、[コマンド バーのフライアウト](../controls-and-patterns/command-bar-flyout.md)、[メニュー バー](../controls-and-patterns/menus.md#create-a-menu-bar)</span><span class="sxs-lookup"><span data-stu-id="ce237-140">[Context menu](../controls-and-patterns/menus.md), [Command bar](../controls-and-patterns/app-bars.md), [Command bar flyout](../controls-and-patterns/command-bar-flyout.md), [MenuBar](../controls-and-patterns/menus.md#create-a-menu-bar)</span></span>
- <span data-ttu-id="ce237-141">[ダイアログとフライアウト](../controls-and-patterns/dialogs.md)(64px に ダイアログ ボックス)</span><span class="sxs-lookup"><span data-stu-id="ce237-141">[Dialogs and flyouts](../controls-and-patterns/dialogs.md) (Dialog at 64px)</span></span>
- [<span data-ttu-id="ce237-142">NavigationView</span><span class="sxs-lookup"><span data-stu-id="ce237-142">NavigationView</span></span>](../controls-and-patterns/navigationview.md)
- <span data-ttu-id="ce237-143">[コンボ ボックス](../controls-and-patterns/combo-box.md)、 [DropDownButton、SplitButton、ToggleSplitButton](../controls-and-patterns/buttons.md)</span><span class="sxs-lookup"><span data-stu-id="ce237-143">[ComboBox](../controls-and-patterns/combo-box.md), [DropDownButton, SplitButton, ToggleSplitButton](../controls-and-patterns/buttons.md)</span></span>
- [<span data-ttu-id="ce237-144">TeachingTip</span><span class="sxs-lookup"><span data-stu-id="ce237-144">TeachingTip</span></span>](../controls-and-patterns/dialogs-and-flyouts/teaching-tip.md)
- [<span data-ttu-id="ce237-145">AutoSuggestBox</span><span class="sxs-lookup"><span data-stu-id="ce237-145">AutoSuggestBox</span></span>](../controls-and-patterns/auto-suggest-box.md) 
- [<span data-ttu-id="ce237-146">予定表/日付/時刻の選択</span><span class="sxs-lookup"><span data-stu-id="ce237-146">Calendar/Date/Time pickers</span></span>](../controls-and-patterns/date-and-time.md)
- <span data-ttu-id="ce237-147">[ツールヒント](../controls-and-patterns/tooltips.md)(16 px)</span><span class="sxs-lookup"><span data-stu-id="ce237-147">[Tooltip](../controls-and-patterns/tooltips.md) (16px)</span></span>
- <span data-ttu-id="ce237-148">[メディアの輸送コントロール](../controls-and-patterns/media-playback.md#media-transport-controls)、 [InkToolbar](../controls-and-patterns/inking-controls.md)</span><span class="sxs-lookup"><span data-stu-id="ce237-148">[Media transport control](../controls-and-patterns/media-playback.md#media-transport-controls), [InkToolbar](../controls-and-patterns/inking-controls.md)</span></span>
- [<span data-ttu-id="ce237-149">アニメーションの結び付け</span><span class="sxs-lookup"><span data-stu-id="ce237-149">Connected animation</span></span>](../motion/connected-animation.md)

<span data-ttu-id="ce237-150">注:フライアウトは ThemeShadow Windows 10 のバージョンが 1903 または最新の SDK に対してコンパイルされるときにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="ce237-150">Note: Flyouts will only apply ThemeShadow when compiled against Windows 10 version 1903 or a more recent SDK.</span></span>

### <a name="themeshadow-in-popups"></a><span data-ttu-id="ce237-151">ポップアップで ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="ce237-151">ThemeShadow in Popups</span></span>

<span data-ttu-id="ce237-152">アプリの UI ポップアップを使用するシナリオのユーザーの通知とクイック アクション必要がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="ce237-152">It is often the case that your app's UI uses a popup for scenarios where you need user's attention and quick action.</span></span> <span data-ttu-id="ce237-153">これらは、シャドウをアプリの UI で階層を作成するために使用する必要がありますとの優れた例です。</span><span class="sxs-lookup"><span data-stu-id="ce237-153">These are great examples when shadow should be used to help create hierarchy in your app's UI.</span></span>

<span data-ttu-id="ce237-154">ThemeShadow は影の任意の XAML 要素に適用すると自動的にキャスト、[ポップアップ](/uwp/api/windows.ui.xaml.controls.primitives.popup)します。</span><span class="sxs-lookup"><span data-stu-id="ce237-154">ThemeShadow automatically casts shadows when applied to any XAML element in a [Popup](/uwp/api/windows.ui.xaml.controls.primitives.popup).</span></span> <span data-ttu-id="ce237-155">その下にあるその他のオープンのポップアップの背後にあるアプリのバック グラウンドのコンテンツにシャドウ、キャストされます。</span><span class="sxs-lookup"><span data-stu-id="ce237-155">It will cast shadows on the app background content behind it and any other open Popups below it.</span></span>

<span data-ttu-id="ce237-156">ポップアップを持つ ThemeShadow を使用する、 `Shadow` ThemeShadow を XAML 要素に適用するプロパティ。</span><span class="sxs-lookup"><span data-stu-id="ce237-156">To use ThemeShadow with Popups, use the `Shadow` property to apply a ThemeShadow to a XAML element.</span></span> <span data-ttu-id="ce237-157">次に、昇格要素、その背後にあるその他の要素からなどの z コンポーネントを使用して、`Translation`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="ce237-157">Then, elevate the element from other elements behind it, for example by using the z component of the `Translation` property.</span></span>
<span data-ttu-id="ce237-158">ほとんどのポップアップ UI では、アプリのバック グラウンドのコンテンツを基準とした推奨される既定の昇格は 32 有効ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="ce237-158">For most Popup UI, the recommended default elevation relative to the app background content is 32 effective pixels.</span></span>

<span data-ttu-id="ce237-159">この例は、アプリのバック グラウンド コンテンツとその背後にあるその他のすべてのポップアップに影を落とすのポップアップで、四角形に示します。</span><span class="sxs-lookup"><span data-stu-id="ce237-159">This example shows a Rectangle in a Popup casting a shadow onto the app background content and any other Popups behind it:</span></span>

```xaml
<Popup>
    <Rectangle x:Name="PopupRectangle" Fill="Lavender" Height="48" Width="96">
        <Rectangle.Shadow>
            <ThemeShadow />
        </Rectangle.Shadow>
    </Rectangle>
</Popup>
```

```csharp
// Elevate the rectangle by 32px
PopupRectangle.Translation += new Vector3(0, 0, 32);
```

![シャドウが付いた長方形 1 つポップアップします。](images/elevation-shadow/PopupRectangle.png)

### <a name="disabling-default-themeshadow-on-custom-flyout-controls"></a><span data-ttu-id="ce237-161">既定値を無効にするカスタム フライアウトで ThemeShadow 制御します。</span><span class="sxs-lookup"><span data-stu-id="ce237-161">Disabling default ThemeShadow on custom Flyout controls</span></span>

<span data-ttu-id="ce237-162">コントロールがに基づいて[フライアウト](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.flyout)、 [DatePickerFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datepickerflyout)、 [MenuFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.menuflyout)または[TimePickerFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.timepickerflyout)自動的にキャストする ThemeShadow を使用します。シャドウします。</span><span class="sxs-lookup"><span data-stu-id="ce237-162">Controls based on [Flyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.flyout), [DatePickerFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datepickerflyout), [MenuFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.menuflyout) or [TimePickerFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.timepickerflyout) automatically use ThemeShadow to cast a shadow.</span></span>

<span data-ttu-id="ce237-163">設定を無効にすることができますし、コントロールのコンテンツで正しい既定シャドウと異なる場合は、 [IsDefaultShadowEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.flyoutpresenter.isdefaultshadowenabled)プロパティを`false`に関連付けられている FlyoutPresenter:</span><span class="sxs-lookup"><span data-stu-id="ce237-163">If the default shadow doesn't look correct on your control's content then you can disable it by setting the [IsDefaultShadowEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.flyoutpresenter.isdefaultshadowenabled) property to `false` on the associated FlyoutPresenter:</span></span>

```xaml
<Flyout>
    <Flyout.FlyoutPresenterStyle>
        <Style TargetType="FlyoutPresenter">
            <Setter Property="IsDefaultShadowEnabled" Value="False" />
        </Style>
    </Flyout.FlyoutPresenterStyle>
</Flyout>
```

### <a name="themeshadow-in-other-elements"></a><span data-ttu-id="ce237-164">その他の要素で ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="ce237-164">ThemeShadow in other elements</span></span>

<span data-ttu-id="ce237-165">一般にシャドウの使用について慎重に検討し、意味のあるビジュアル階層が導入されている場合に、その使用を制限することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ce237-165">In general we encourage you to think carefully about your use of shadow and limit its use to cases where it introduces meaningful visual hierarchy.</span></span> <span data-ttu-id="ce237-166">ただし、これが必要になるシナリオが高度な場合に任意の UI 要素の影をキャストする方法は提供します。</span><span class="sxs-lookup"><span data-stu-id="ce237-166">However, we do provide a way to cast a shadow from any UI element in case you have advanced scenarios that necessitate it.</span></span>

<span data-ttu-id="ce237-167">ポップアップに表示されていないされる XAML 要素の影をキャストするは、他の要素の影を受け取ることができる明示的に指定する必要があります、`ThemeShadow.Receivers`コレクション。</span><span class="sxs-lookup"><span data-stu-id="ce237-167">To cast a shadow from a XAML element that isn't in a Popup, you must explicitly specify the other elements that can receive the shadow in the `ThemeShadow.Receivers` collection.</span></span> <span data-ttu-id="ce237-168">受信側は、ビジュアル ツリー内の魔法の先祖をすることはできません。</span><span class="sxs-lookup"><span data-stu-id="ce237-168">Receivers cannot be an ancestor of the caster in the visual tree.</span></span>

<span data-ttu-id="ce237-169">この例では、その背後のグリッドに影をキャストする 2 つの四角形を示します。</span><span class="sxs-lookup"><span data-stu-id="ce237-169">This example shows two Rectangles that cast shadows onto a Grid behind them:</span></span>

```xaml
<Grid>
    <Grid.Resources>
        <ThemeShadow x:Name="SharedShadow" />
    </Grid.Resources>

    <Grid x:Name="BackgroundGrid" Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" />

    <Rectangle x:Name="Rectangle1" Height="100" Width="100" Fill="Turquoise" Shadow="{StaticResource SharedShadow}" />

    <Rectangle x:Name="Rectangle2" Height="100" Width="100" Fill="Turquoise" Shadow="{StaticResource SharedShadow}" />
</Grid>
```

```csharp
/// Add BackgroundGrid as a shadow receiver and elevate the casting buttons above it
SharedShadow.Receivers.Add(BackgroundGrid);

Rectangle1.Translation += new Vector3(0, 0, 16);
Rectangle2.Translation += new Vector3(120, 0, 32);
```

![相互、影が両方の横にある 2 つ青緑色四角形。](images/elevation-shadow/SharedShadow.png)

### <a name="performance-best-practices-for-themeshadow"></a><span data-ttu-id="ce237-171">ThemeShadow のパフォーマンスのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="ce237-171">Performance best practices for ThemeShadow</span></span>

1. <span data-ttu-id="ce237-172">システムは、キャスターと受信者のペアが 5 の制限を設定し、これを超えた場合、シャドウ オフになります。</span><span class="sxs-lookup"><span data-stu-id="ce237-172">The system sets a limit of 5 caster-receiver pairs, and will turn off shadow if this is exceeded.</span></span> <span data-ttu-id="ce237-173">5 キャスターと受信者のペアのシステムによって適用される制限を引き続き使用します。</span><span class="sxs-lookup"><span data-stu-id="ce237-173">Stick to the system-enforced limit of 5 caster-receiver pairs.</span></span>

2. <span data-ttu-id="ce237-174">最低限必要なカスタム レシーバー要素の数を制限します。</span><span class="sxs-lookup"><span data-stu-id="ce237-174">Limit the number of custom receiver elements to the minimum necessary.</span></span>

3. <span data-ttu-id="ce237-175">複数のレシーバー要素は、同じ権限の昇格では場合を 1 つの親要素をターゲットにする代わりにそれらを結合してみます。</span><span class="sxs-lookup"><span data-stu-id="ce237-175">If multiple receiver elements are at the same elevation, try to combine them by targeting a single parent element instead.</span></span>

4. <span data-ttu-id="ce237-176">複数の要素は、同一のレシーバー要素の上に影の同じ型にキャストする場合は、共有リソースとして、シャドウを追加し、再利用します。</span><span class="sxs-lookup"><span data-stu-id="ce237-176">If multiple elements will cast the same type of shadow onto the same receiver elements then add the shadow as a shared resource and reuse it.</span></span>

## <a name="drop-shadow"></a><span data-ttu-id="ce237-177">ドロップ シャドウ</span><span class="sxs-lookup"><span data-stu-id="ce237-177">Drop shadow</span></span>

<span data-ttu-id="ce237-178">DropShadow がその環境に自動的に応答しないと、光源を使用しません。</span><span class="sxs-lookup"><span data-stu-id="ce237-178">DropShadow is not automatically responsive to its environment and does not use light sources.</span></span> <span data-ttu-id="ce237-179">たとえば、実装を参照してください、 [DropShadow クラス](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow)します。</span><span class="sxs-lookup"><span data-stu-id="ce237-179">For example implementations, see the [DropShadow Class](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow).</span></span>

## <a name="which-shadow-should-i-use"></a><span data-ttu-id="ce237-180">どのシャドウを使用する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="ce237-180">Which shadow should I use?</span></span>

| <span data-ttu-id="ce237-181">プロパティ</span><span class="sxs-lookup"><span data-stu-id="ce237-181">Property</span></span> | <span data-ttu-id="ce237-182">ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="ce237-182">ThemeShadow</span></span> | <span data-ttu-id="ce237-183">DropShadow</span><span class="sxs-lookup"><span data-stu-id="ce237-183">DropShadow</span></span> |
| - | - | - | - |
| <span data-ttu-id="ce237-184">**SDK の最小値**</span><span class="sxs-lookup"><span data-stu-id="ce237-184">**Min SDK**</span></span> | <span data-ttu-id="ce237-185">Windows 10 のバージョンが 1903</span><span class="sxs-lookup"><span data-stu-id="ce237-185">Windows 10 version 1903</span></span> | <span data-ttu-id="ce237-186">14393</span><span class="sxs-lookup"><span data-stu-id="ce237-186">14393</span></span> |
| <span data-ttu-id="ce237-187">**適応性**</span><span class="sxs-lookup"><span data-stu-id="ce237-187">**Adaptability**</span></span> | <span data-ttu-id="ce237-188">〇</span><span class="sxs-lookup"><span data-stu-id="ce237-188">Yes</span></span> | <span data-ttu-id="ce237-189">X</span><span class="sxs-lookup"><span data-stu-id="ce237-189">No</span></span> |
| <span data-ttu-id="ce237-190">**カスタマイズ**</span><span class="sxs-lookup"><span data-stu-id="ce237-190">**Customization**</span></span> | <span data-ttu-id="ce237-191">X</span><span class="sxs-lookup"><span data-stu-id="ce237-191">No</span></span> | <span data-ttu-id="ce237-192">〇</span><span class="sxs-lookup"><span data-stu-id="ce237-192">Yes</span></span> |
| <span data-ttu-id="ce237-193">**光源**</span><span class="sxs-lookup"><span data-stu-id="ce237-193">**Light source**</span></span> | <span data-ttu-id="ce237-194">自動 (既定では、グローバルですがアプリごとにオーバーライドできます)</span><span class="sxs-lookup"><span data-stu-id="ce237-194">Automatic (global by default, but can override per app)</span></span> | <span data-ttu-id="ce237-195">なし</span><span class="sxs-lookup"><span data-stu-id="ce237-195">None</span></span> |
| <span data-ttu-id="ce237-196">**3D 環境でサポートされています**</span><span class="sxs-lookup"><span data-stu-id="ce237-196">**Supported in 3D environments**</span></span> | <span data-ttu-id="ce237-197">〇</span><span class="sxs-lookup"><span data-stu-id="ce237-197">Yes</span></span> | <span data-ttu-id="ce237-198">X</span><span class="sxs-lookup"><span data-stu-id="ce237-198">No</span></span> |

- <span data-ttu-id="ce237-199">シャドウの目的は、単純な視覚的処理ではなく、意味のある階層を提供することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ce237-199">Keep in mind that the purpose of shadow is to provide meaningful hierarchy, not as a simple visual treatment.</span></span>
- <span data-ttu-id="ce237-200">一般に、その環境に自動的に対応する、ThemeShadow の使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ce237-200">Generally, we recommend using ThemeShadow, which adapts automatically to its environment.</span></span>
- <span data-ttu-id="ce237-201">パフォーマンスの問題の影の数を制限するか、その他のビジュアルの処理方法を使用して、DropShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="ce237-201">For concerns about performance, limit the number of shadows, use other visual treatment, or use DropShadow.</span></span>
- <span data-ttu-id="ce237-202">ビジュアルの階層を実現するシナリオが高度な場合は、その他の視覚的処理 (例: 色) を使用することを検討します。</span><span class="sxs-lookup"><span data-stu-id="ce237-202">If you have more advanced scenarios to achieve visual hierarchy, consider using other visual treatment (e.g. color).</span></span> <span data-ttu-id="ce237-203">シャドウが必要な場合は、DropShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="ce237-203">If shadow is needed, then use DropShadow.</span></span>
