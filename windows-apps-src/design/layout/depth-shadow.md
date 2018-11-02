---
author: serenaz
description: Z 深度、または相対値、シャドウがより自然かつ効率的にユーザーが専念をできるように、アプリに奥行きを組み込む方法は 2 つです。
title: Z 深度と UWP アプリ用のシャドウ
template: detail.hbs
ms.author: sezhen
ms.date: 02/12/2018
ms.topic: article
keywords: Windows 10, UWP
pm-contact: chigy
design-contact: balrayit
ms.localizationpriority: medium
ms.openlocfilehash: 3a87e7366765b7c8b304e930fed0d3c45900aad9
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5971232"
---
# <a name="z-depth-and-shadow"></a><span data-ttu-id="d51f0-104">Z 深度とシャドウ</span><span class="sxs-lookup"><span data-stu-id="d51f0-104">Z-depth and shadow</span></span>

![深度の場合は true。](images/elevation-shadow/depth.svg)

<span data-ttu-id="d51f0-106">Fluent 深度システムは、配置、細字、3 D などの物理的な概念を使ってし、デジタル UI にシャドウを認識するためより階層化された物理環境でします。</span><span class="sxs-lookup"><span data-stu-id="d51f0-106">The Fluent Depth System uses physical concepts like 3D positioning, light, and shadow to reinvent how digital UI can be perceived in a more layered, physical environment.</span></span> <span data-ttu-id="d51f0-107">Z 深度、または相対値は、UWP アプリに奥行きを組み込む方法は 2 つの深度、およびシャドウします。</span><span class="sxs-lookup"><span data-stu-id="d51f0-107">Z-depth, or relative depth, and shadow are two ways to incorporate depth into your UWP app.</span></span>

## <a name="what-is-z-depth"></a><span data-ttu-id="d51f0-108">Z 深度とは何ですか。</span><span class="sxs-lookup"><span data-stu-id="d51f0-108">What is z-depth?</span></span>

<span data-ttu-id="d51f0-109">Z 深さは、z 軸に沿った 2 つのサーフェスの間の距離と、オブジェクトは、ビューアーを閉じる方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d51f0-109">Z-depth is the distance between two surfaces along the z-axis, and it illustrates how close an object is to the viewer.</span></span>

![z 深度](images/elevation-shadow/elevation.svg)

### <a name="why-use-z-depth"></a><span data-ttu-id="d51f0-111">Z 深度を使用する理由</span><span class="sxs-lookup"><span data-stu-id="d51f0-111">Why use z-depth?</span></span>

<span data-ttu-id="d51f0-112">現実の世界では、マイクロソフトに近いオブジェクトに焦点を傾向があります。</span><span class="sxs-lookup"><span data-stu-id="d51f0-112">In the physical world, we tend to focus on objects that are closer to us.</span></span> <span data-ttu-id="d51f0-113">この空間本能デジタル UI に適用可能です。</span><span class="sxs-lookup"><span data-stu-id="d51f0-113">We can apply this spatial instinct to digital UI, as well.</span></span> <span data-ttu-id="d51f0-114">たとえば、ユーザーに近い要素を表示する場合、ユーザーは本能重点を置きます要素です。</span><span class="sxs-lookup"><span data-stu-id="d51f0-114">For example, if you bring an element closer to the user, then the user will instinctively focus on the element.</span></span> <span data-ttu-id="d51f0-115">移動中の UI 要素近い z 軸で、アプリでタスクを完了自然かつ効率的にユーザーを支援のオブジェクト間で視覚的な階層を確立できます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-115">By moving UI elements closer in z-axis, you can establish visual hierarchy between objects, helping users complete tasks naturally and efficiently in your app.</span></span> 

![コンテンツのメニューで z 深度](images/elevation-shadow/whyelevation.svg)

<span data-ttu-id="d51f0-117">他を提供するわかりやすい視覚的な階層、z 深度もを作成するエクスペリエンスを実現シームレスに 2D から 3D 環境では、すべてのデバイスとフォーム ファクターでアプリをスケーリングします。</span><span class="sxs-lookup"><span data-stu-id="d51f0-117">In addition to providing meaningful visual hierarchy, z-depth also allows you to create experiences that flow seamlessly from 2D to 3D environments, scaling your app across all devices and form factors.</span></span> 

![2 d に 3d で z 深度](images/elevation-shadow/elevation-2d3d.svg)

### <a name="how-is-z-depth-perceived"></a><span data-ttu-id="d51f0-119">Z 深度の認識されるかどうか。</span><span class="sxs-lookup"><span data-stu-id="d51f0-119">How is z-depth perceived?</span></span>

<span data-ttu-id="d51f0-120">現実の世界の奥行きが認識できるようにする方法に基づきでは、デジタル UI に近接通信を表示するために使用できる方法をいくつか次に示します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-120">Based on how we perceive depth in the physical world, here are several techniques that can be used to show proximity in digital UI.</span></span>

- <span data-ttu-id="d51f0-121">**スケール**同じサイズの近くのオブジェクトよりも小さい遠くのオブジェクトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-121">**Scale** Farther objects appear smaller than closer objects of the same size.</span></span> <span data-ttu-id="d51f0-122">これは、メソッドは一般にお勧めしないためを 2D 空間に効果的にデモンストレーションするは困難です。</span><span class="sxs-lookup"><span data-stu-id="d51f0-122">This is method is difficult to demonstrate effectively in 2D space, so it is not generally recommended.</span></span> <span data-ttu-id="d51f0-123">ただし、2 D 内のユーザーに近い場所に移動するオブジェクトの有効なシミュレーションを作成するスケールと[シャドウ](#what-is-shadow)を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-123">However, you can use scale and [shadow](#what-is-shadow) to create an effective simulation of objects moving closer to the user in 2D.</span></span>

    ![スケールを近接通信](images/elevation-shadow/elevation-scale.svg)

- <span data-ttu-id="d51f0-125">**大気**オブジェクトは遠くと「煙の充満」オーバーレイまたはその他の大気効果に焦点を表示できます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-125">**Atmosphere** Objects can appear farther away and out of focus with a “smoky” overlay or other atmospheric effect.</span></span>

    ![大気に近接通信](images/elevation-shadow/elevation-atmosphere.svg)

- <span data-ttu-id="d51f0-127">**モーション**相対速度を近接通信を示すために使用することができます: 近くのオブジェクトがバック グラウンドの高い遠くのオブジェクトよりもすばやく移動します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-127">**Motion** Relative speed can be used to demonstrate proximity: closer objects move more quickly than distant background objects.</span></span> <span data-ttu-id="d51f0-128">この効果を実装する方法については、[視差効果](../motion/parallax.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d51f0-128">To learn how to implement this effect, see [Parallax](../motion/parallax.md).</span></span>

    ![モーションを使って、近接通信](images/elevation-shadow/elevation-motion.svg)

### <a name="recommendations-for-z-depth"></a><span data-ttu-id="d51f0-130">Z 深度の推奨事項</span><span class="sxs-lookup"><span data-stu-id="d51f0-130">Recommendations for z-depth</span></span>

<span data-ttu-id="d51f0-131">チェック ボックスをオフに視覚的なフォーカスを提供する管理者特権の平面の数を減らします。</span><span class="sxs-lookup"><span data-stu-id="d51f0-131">Reduce the number of elevated planes to provide clear visual focus.</span></span> <span data-ttu-id="d51f0-132">ほとんどのシナリオでは、2 つの平面十分です。 項目 (高近接) のフォア グラウンドとバック グラウンド項目 (低近接) のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="d51f0-132">For most scenarios, two planes is enough: one for foreground items (high proximity) and another for background items (low proximity).</span></span> <span data-ttu-id="d51f0-133">重ならない複数の管理者特権での項目がある場合は、グループ化を平面の数を減らすために同一平面 (つまり、フォア グラウンド)。</span><span class="sxs-lookup"><span data-stu-id="d51f0-133">If you have multiple elevated items that don’t overlap, group them the same plane (i.e., foreground) to reduce the number of planes.</span></span>

![アプリ内で z 深度](images/elevation-shadow/app-depth.svg)

## <a name="what-is-shadow"></a><span data-ttu-id="d51f0-135">シャドウとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="d51f0-135">What is shadow?</span></span>

![shadow](images/elevation-shadow/shadow.svg)

<span data-ttu-id="d51f0-137">シャドウは、昇格が認識できるようにする方法です。</span><span class="sxs-lookup"><span data-stu-id="d51f0-137">Shadow is a way to perceive elevation.</span></span> <span data-ttu-id="d51f0-138">の管理者特権でのオブジェクトの上のライトがある場合は、次のサーフェス上、シャドウがあります。</span><span class="sxs-lookup"><span data-stu-id="d51f0-138">When there is light above an elevated object, there is a shadow on the surface below.</span></span> <span data-ttu-id="d51f0-139">オブジェクトが大きいほどより大きなおよび柔らかい影になります。</span><span class="sxs-lookup"><span data-stu-id="d51f0-139">The higher the object, the larger and softer the shadow becomes.</span></span> <span data-ttu-id="d51f0-140">管理者特権でのオブジェクトは、シャドウを持つ必要はありませんが、シャドウの昇格を示すことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d51f0-140">Note that elevated objects don’t need to have shadows, but shadows do indicate elevation.</span></span>

<span data-ttu-id="d51f0-141">シャドウは、UWP アプリでは、意図的なきれいいないする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d51f0-141">In UWP apps, shadows should be purposeful, not aesthetic.</span></span> <span data-ttu-id="d51f0-142">シャドウを損ねますフォーカスと生産性を場合は、シャドウの使用を制限します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-142">If shadows detract from focus and productivity, then limit the use of shadow.</span></span>

<span data-ttu-id="d51f0-143">ThemeShadow または DropShadow Api のいずれかにシャドウを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-143">You can use shadows with either the ThemeShadow or DropShadow APIs.</span></span>

## <a name="themeshadow"></a><span data-ttu-id="d51f0-144">ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="d51f0-144">ThemeShadow</span></span>

<span data-ttu-id="d51f0-145">型を描画する任意の XAML 要素に適用できる ThemeShadow を適切にに基づいて x、y、z 座標シャドウします。</span><span class="sxs-lookup"><span data-stu-id="d51f0-145">The ThemeShadow type can be applied to any XAML element to draw shadows appropriately based on x, y, z coordinates.</span></span> <span data-ttu-id="d51f0-146">ThemeShadow は、その他の環境の仕様にも自動的に調整します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-146">ThemeShadow also automatically adjusts for other environmental specifications:</span></span>

- <span data-ttu-id="d51f0-147">照明、ユーザーのテーマ、アプリの環境、およびシェルの変更に合わせて変化します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-147">Adapts to changes in lighting, user theme, app environment, and shell.</span></span>
- <span data-ttu-id="d51f0-148">シャドウ要素昇格に基づいて自動的にを処理します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-148">Shadows elements automatically based on their elevation.</span></span>
- <span data-ttu-id="d51f0-149">要素のによって同期が維持に移動し、昇格を変更します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-149">Keeps elements in sync as they move and change elevation.</span></span>
- <span data-ttu-id="d51f0-150">シャドウ全体にわたってとアプリケーション間で一貫性が維持されます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-150">Keeps shadows consistent throughout and across applications.</span></span>

<span data-ttu-id="d51f0-151">次に、淡色テーマと濃色テーマのさまざまな高度に ThemeShadow の例を示します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-151">Here are examples of ThemeShadow at different elevations with the light and dark themes:</span></span>

![淡色テーマとスマート シャドウ](images/elevation-shadow/smartshadow-light.svg)

![濃色テーマのスマート シャドウ](images/elevation-shadow/smartshadow-dark.svg)

### <a name="themeshadow-in-common-controls"></a><span data-ttu-id="d51f0-154">ThemeShadow は共通のコントロールします。</span><span class="sxs-lookup"><span data-stu-id="d51f0-154">ThemeShadow in common controls</span></span>

<span data-ttu-id="d51f0-155">次の一般的なコントロールでは、シャドウを生じさせるを ThemeShadow を自動的に使用されます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-155">The following common controls will automatically use ThemeShadow to cast shadows:</span></span>

- [<span data-ttu-id="d51f0-156">ダイアログとポップアップ</span><span class="sxs-lookup"><span data-stu-id="d51f0-156">Dialogs and flyouts</span></span>](../controls-and-patterns/dialogs.md)
- [<span data-ttu-id="d51f0-157">NavigationView</span><span class="sxs-lookup"><span data-stu-id="d51f0-157">NavigationView</span></span>](../controls-and-patterns/navigationview.md)
- [<span data-ttu-id="d51f0-158">メディア トランスポート コントロール</span><span class="sxs-lookup"><span data-stu-id="d51f0-158">Media transport control</span></span>](../controls-and-patterns/media-playback.md)
- [<span data-ttu-id="d51f0-159">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="d51f0-159">Context menu</span></span>](../controls-and-patterns/menus.md)
- [<span data-ttu-id="d51f0-160">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="d51f0-160">Command bar</span></span>](../controls-and-patterns/app-bars.md)
- <span data-ttu-id="d51f0-161">[自動提案](../controls-and-patterns/auto-suggest-box.md)、[コンボ ボックス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、[カレンダー/日付/時刻の選択機能](../controls-and-patterns/date-and-time.md)、[ヒント](../controls-and-patterns/tooltips.md)</span><span class="sxs-lookup"><span data-stu-id="d51f0-161">[AutoSuggest](../controls-and-patterns/auto-suggest-box.md), [ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [Calendar/Date/Time pickers](../controls-and-patterns/date-and-time.md), [Tooltip](../controls-and-patterns/tooltips.md)</span></span>
- [<span data-ttu-id="d51f0-162">アクセス キー</span><span class="sxs-lookup"><span data-stu-id="d51f0-162">Access keys</span></span>](../input/access-keys.md)

### <a name="themeshadow-in-popups"></a><span data-ttu-id="d51f0-163">In Popups ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="d51f0-163">ThemeShadow in Popups</span></span>

<span data-ttu-id="d51f0-164">ThemeShadow では、シャドウの[ポップアップ](/uwp/api/windows.ui.xaml.controls.primitives.popup)内の任意の XAML 要素に適用されると自動的にキャストします。</span><span class="sxs-lookup"><span data-stu-id="d51f0-164">ThemeShadow automatically casts shadows when applied to any XAML element in a [Popup](/uwp/api/windows.ui.xaml.controls.primitives.popup).</span></span> <span data-ttu-id="d51f0-165">下にあるその他のオープンのポップアップの背後にあるアプリのバック グラウンド コンテンツでシャドウを生じ、されます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-165">It will cast shadows on the app background content behind it and any other open Popups below it.</span></span>

<span data-ttu-id="d51f0-166">ポップアップを持つ ThemeShadow を使用する、`Shadow`プロパティを XAML 要素に、ThemeShadow を適用します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-166">To use ThemeShadow with Popups, use the `Shadow` property to apply a ThemeShadow to a XAML element.</span></span> <span data-ttu-id="d51f0-167">次に、昇格要素、背後にある他の要素からなどの z コンポーネントを使用して、`Translation`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="d51f0-167">Then, elevate the element from other elements behind it, for example by using the z component of the `Translation` property.</span></span>
<span data-ttu-id="d51f0-168">ほとんどのポップアップ UI では、アプリのバック グラウンドのコンテンツを基準としたことをお勧めの既定の昇格は 32 有効ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="d51f0-168">For most Popup UI, the recommended default elevation relative to the app background content is 32 effective pixels.</span></span>

<span data-ttu-id="d51f0-169">この例は、アプリのバック グラウンド コンテンツやその他の背後にあるポップアップに影をキャスト ポップアップで四角形を示します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-169">This example shows a Rectangle in a Popup casting a shadow onto the app background content and any other Popups behind it:</span></span>

```xaml
<Popup>
    <Rectangle x:Name="PopupRectangle" Fill="White" Height="48" Width="96">
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

![シャドウのコード例](images/elevation-shadow/smartshadow-example.svg)

### <a name="themeshadow-in-other-elements"></a><span data-ttu-id="d51f0-171">その他の要素で ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="d51f0-171">ThemeShadow in other elements</span></span>

<span data-ttu-id="d51f0-172">ポップアップではない XAML 要素から、シャドウをキャストは、その他の要素でシャドウを受け取ることができる明示的に指定する必要があります、`ThemeShadow.Receivers`コレクションです。</span><span class="sxs-lookup"><span data-stu-id="d51f0-172">To cast a shadow from a XAML element that isn't in a Popup, you must explicitly specify the other elements that can receive the shadow in the `ThemeShadow.Receivers` collection.</span></span>

<span data-ttu-id="d51f0-173">この例では、それらの背後にあるグリッドにシャドウを生じさせる 2 つのボタンを示します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-173">This example shows two Buttons that cast shadows onto a Grid behind them:</span></span>

```xaml
<Grid x:Name="BackgroundGrid" Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.Resources>
        <ThemeShadow x:Name="SharedShadow" />
    </Grid.Resources>

    <Button x:Name="Button1" Content="Button 1" Shadow="{StaticResource SharedShadow}" Margin="10" />

    <Button x:Name="Button2" Content="Button 2" Shadow="{StaticResource SharedShadow}" Margin="120" />
</Grid>
```

```csharp
/// Add BackgroundGrid as a shadow receiver and elevate the casting buttons above it
SharedShadow.Receivers.Add(BackgroundGrid);

Button1.Translation += new Vector3(0, 0, 16);
Button2.Translation += new Vector3(0, 0, 32);
```

### <a name="performance-best-practices-for-themeshadow"></a><span data-ttu-id="d51f0-174">ThemeShadow のパフォーマンスのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="d51f0-174">Performance best practices for ThemeShadow</span></span>

1. <span data-ttu-id="d51f0-175">必要な最小にカスタム レシーバー要素の数に制限します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-175">Limit the number of custom receiver elements to the minimum necessary.</span></span> 

2. <span data-ttu-id="d51f0-176">複数の受信者要素が同じ昇格に場合は、代わりに、1 つの親要素をターゲットとしてそれらを結合するしてみてください。</span><span class="sxs-lookup"><span data-stu-id="d51f0-176">If multiple receiver elements are at the same elevation then try to combine them by targeting a single parent element instead.</span></span>

3. <span data-ttu-id="d51f0-177">複数の要素のキャスト先と同じ種類レシーバーと同じ要素に影の場合は、共有リソースとして、シャドウを追加し、再利用します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-177">If multiple elements will cast the same type of shadow onto the same receiver elements then add the shadow as a shared resource and reuse it.</span></span>

## <a name="drop-shadow"></a><span data-ttu-id="d51f0-178">ドロップ シャドウ</span><span class="sxs-lookup"><span data-stu-id="d51f0-178">Drop shadow</span></span>

<span data-ttu-id="d51f0-179">DropShadow はその環境への応答が自動的に注意して光源を使用しません。</span><span class="sxs-lookup"><span data-stu-id="d51f0-179">DropShadow is not automatically responsive to its environment and does not use light sources.</span></span> <span data-ttu-id="d51f0-180">たとえば、実装では、 [DropShadow クラス](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d51f0-180">For example implementations, see the [DropShadow Class](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow).</span></span>

## <a name="which-shadow-should-i-use"></a><span data-ttu-id="d51f0-181">どのシャドウを使用する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="d51f0-181">Which shadow should I use?</span></span>

| <span data-ttu-id="d51f0-182">プロパティ</span><span class="sxs-lookup"><span data-stu-id="d51f0-182">Property</span></span> | <span data-ttu-id="d51f0-183">ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="d51f0-183">ThemeShadow</span></span> | <span data-ttu-id="d51f0-184">DropShadow</span><span class="sxs-lookup"><span data-stu-id="d51f0-184">DropShadow</span></span> |
| - | - | - | - |
| **<span data-ttu-id="d51f0-185">Min SDK</span><span class="sxs-lookup"><span data-stu-id="d51f0-185">Min SDK</span></span>** | <span data-ttu-id="d51f0-186">RS5</span><span class="sxs-lookup"><span data-stu-id="d51f0-186">RS5</span></span> | <span data-ttu-id="d51f0-187">14393</span><span class="sxs-lookup"><span data-stu-id="d51f0-187">14393</span></span> |
| **<span data-ttu-id="d51f0-188">適応性</span><span class="sxs-lookup"><span data-stu-id="d51f0-188">Adaptability</span></span>** | <span data-ttu-id="d51f0-189">はい</span><span class="sxs-lookup"><span data-stu-id="d51f0-189">Yes</span></span> | <span data-ttu-id="d51f0-190">いいえ</span><span class="sxs-lookup"><span data-stu-id="d51f0-190">No</span></span> |
| **<span data-ttu-id="d51f0-191">カスタマイズ</span><span class="sxs-lookup"><span data-stu-id="d51f0-191">Customization</span></span>** | <span data-ttu-id="d51f0-192">いいえ</span><span class="sxs-lookup"><span data-stu-id="d51f0-192">No</span></span> | <span data-ttu-id="d51f0-193">はい</span><span class="sxs-lookup"><span data-stu-id="d51f0-193">Yes</span></span> |
| **<span data-ttu-id="d51f0-194">光源</span><span class="sxs-lookup"><span data-stu-id="d51f0-194">Light source</span></span>** | <span data-ttu-id="d51f0-195">自動 (既定では、グローバル アプリごとに上書きできますが、)</span><span class="sxs-lookup"><span data-stu-id="d51f0-195">Automatic (global by default, but can override per app)</span></span> | <span data-ttu-id="d51f0-196">なし</span><span class="sxs-lookup"><span data-stu-id="d51f0-196">None</span></span> |
| **<span data-ttu-id="d51f0-197">3D 環境でサポートされています。</span><span class="sxs-lookup"><span data-stu-id="d51f0-197">Supported in 3D environments</span></span>** | <span data-ttu-id="d51f0-198">はい</span><span class="sxs-lookup"><span data-stu-id="d51f0-198">Yes</span></span> | <span data-ttu-id="d51f0-199">いいえ</span><span class="sxs-lookup"><span data-stu-id="d51f0-199">No</span></span> |

- <span data-ttu-id="d51f0-200">一般に、その環境に自動的に対応する、ThemeShadow の使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d51f0-200">Generally, we recommend using ThemeShadow, which adapts automatically to its environment.</span></span>
- <span data-ttu-id="d51f0-201">カスタム シャドウのシナリオをより高度なが場合、より詳細にカスタマイズできる、DropShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-201">If you have more advanced scenarios for custom shadows, then use DropShadow, which allows for greater customization.</span></span>
- <span data-ttu-id="d51f0-202">下位互換性、DropShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-202">For backwards compatibility, use DropShadow.</span></span>
- <span data-ttu-id="d51f0-203">パフォーマンスを懸念するには、シャドウ、数を制限するか、DropShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-203">For concerns about performance, limit the number of shadows, or use DropShadow.</span></span>
- <span data-ttu-id="d51f0-204">True 3D で HMDs、ThemeShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="d51f0-204">On HMDs in true 3D, use ThemeShadow.</span></span> <span data-ttu-id="d51f0-205">ビジュアルの側から、その親から指定されたオフセット DropShadow を描画するため空間ではフローティング状態などが検索されます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-205">Since DropShadow draws at a specified offset from the visual it is parented to, from the side, it will look like it's floating in space.</span></span> <span data-ttu-id="d51f0-206">その一方で、ThemeShadow はレシーバーとして定義されている視覚効果の上にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="d51f0-206">On the other hand, ThemeShadow is rendered on top of the visuals defined as receivers.</span></span>
