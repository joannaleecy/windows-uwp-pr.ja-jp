---
author: serenaz
description: Z 深度または相対値、シャドウがより自然かつ効率的にユーザーが専念をできるように、アプリに奥行きを組み込むの 2 つの方法です。
title: Z 深度と UWP アプリ用のシャドウ
template: detail.hbs
ms.author: sezhen
ms.date: 02/12/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: chigy
design-contact: balrayit
ms.localizationpriority: medium
ms.openlocfilehash: a1433b131b994ee2b1323909bc7c195e00f43cde
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5439620"
---
# <a name="z-depth-and-shadow"></a><span data-ttu-id="c0fcb-104">Z 深度とシャドウ</span><span class="sxs-lookup"><span data-stu-id="c0fcb-104">Z-depth and shadow</span></span>

![深度の場合は true。](images/elevation-shadow/depth.svg)

<span data-ttu-id="c0fcb-106">Fluent の深度システムは、配置、細字、3 D などの物理的な概念を使用し、デジタルの UI にシャドウを認識するためより階層化された物理環境でします。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-106">The Fluent Depth System uses physical concepts like 3D positioning, light, and shadow to reinvent how digital UI can be perceived in a more layered, physical environment.</span></span> <span data-ttu-id="c0fcb-107">Z 深度または相対値、深度とシャドウは 2 つの方法で UWP アプリに奥行きを組み込みます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-107">Z-depth, or relative depth, and shadow are two ways to incorporate depth into your UWP app.</span></span>

## <a name="what-is-z-depth"></a><span data-ttu-id="c0fcb-108">Z 深度とは何ですか。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-108">What is z-depth?</span></span>

<span data-ttu-id="c0fcb-109">Z 深さは 2 つのサーフェスの z 軸に沿って間の距離と、オブジェクトは、ビューアーを閉じる方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-109">Z-depth is the distance between two surfaces along the z-axis, and it illustrates how close an object is to the viewer.</span></span>

![z 深度](images/elevation-shadow/elevation.svg)

### <a name="why-use-z-depth"></a><span data-ttu-id="c0fcb-111">Z 深度を使用する理由</span><span class="sxs-lookup"><span data-stu-id="c0fcb-111">Why use z-depth?</span></span>

<span data-ttu-id="c0fcb-112">現実の世界では、マイクロソフトに近いオブジェクトに焦点を傾向があります。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-112">In the physical world, we tend to focus on objects that are closer to us.</span></span> <span data-ttu-id="c0fcb-113">この空間本能デジタル UI に適用可能です。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-113">We can apply this spatial instinct to digital UI, as well.</span></span> <span data-ttu-id="c0fcb-114">たとえば、ユーザーに近い要素を表示する場合、ユーザーは本能重点を置きます要素。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-114">For example, if you bring an element closer to the user, then the user will instinctively focus on the element.</span></span> <span data-ttu-id="c0fcb-115">移動 UI 要素に近い z 軸で、アプリでタスクを完了自然かつ効率的にユーザーを支援のオブジェクト間で視覚的な階層を確立することができます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-115">By moving UI elements closer in z-axis, you can establish visual hierarchy between objects, helping users complete tasks naturally and efficiently in your app.</span></span> 

![コンテンツのメニューで z 深度](images/elevation-shadow/whyelevation.svg)

<span data-ttu-id="c0fcb-117">他を提供するわかりやすい視覚的な階層、z 深度もを作成するエクスペリエンスを実現シームレスに 2D から 3D 環境では、すべてのデバイスとフォーム ファクターでアプリをスケーリングします。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-117">In addition to providing meaningful visual hierarchy, z-depth also allows you to create experiences that flow seamlessly from 2D to 3D environments, scaling your app across all devices and form factors.</span></span> 

![2d に 3d での z 深度](images/elevation-shadow/elevation-2d3d.svg)

### <a name="how-is-z-depth-perceived"></a><span data-ttu-id="c0fcb-119">Z 深度の認識されるかどうか。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-119">How is z-depth perceived?</span></span>

<span data-ttu-id="c0fcb-120">現実の世界の奥行きを認識する方法に基づきでは、デジタル UI に近接通信を表示するために使用する方法はいくつか次に示します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-120">Based on how we perceive depth in the physical world, here are several techniques that can be used to show proximity in digital UI.</span></span>

- <span data-ttu-id="c0fcb-121">**スケール**同じサイズの近くのオブジェクトよりも小さい遠くのオブジェクトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-121">**Scale** Farther objects appear smaller than closer objects of the same size.</span></span> <span data-ttu-id="c0fcb-122">メソッドは、このため、通常お勧めできませんを 2D 空間に効果的に説明するは困難です。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-122">This is method is difficult to demonstrate effectively in 2D space, so it is not generally recommended.</span></span> <span data-ttu-id="c0fcb-123">ただし、2 D 内のユーザーに近い場所に移動するオブジェクトの有効なシミュレーションを作成するスケールと[シャドウ](#what-is-shadow)を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-123">However, you can use scale and [shadow](#what-is-shadow) to create an effective simulation of objects moving closer to the user in 2D.</span></span>

    ![スケールを近接通信](images/elevation-shadow/elevation-scale.svg)

- <span data-ttu-id="c0fcb-125">**大気**オブジェクトには、遠くと「煙の充満」オーバーレイまたはその他の大気効果に焦点を表示できます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-125">**Atmosphere** Objects can appear farther away and out of focus with a “smoky” overlay or other atmospheric effect.</span></span>

    ![大気に近接通信](images/elevation-shadow/elevation-atmosphere.svg)

- <span data-ttu-id="c0fcb-127">**モーション**相対速度は、近接通信を示すために使用できます: 近くのオブジェクトをバック グラウンドの高い遠くのオブジェクトよりもすばやく移動します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-127">**Motion** Relative speed can be used to demonstrate proximity: closer objects move more quickly than distant background objects.</span></span> <span data-ttu-id="c0fcb-128">この効果を実装する方法については、[視差効果](../motion/parallax.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-128">To learn how to implement this effect, see [Parallax](../motion/parallax.md).</span></span>

    ![モーションを使って近接通信](images/elevation-shadow/elevation-motion.svg)

### <a name="recommendations-for-z-depth"></a><span data-ttu-id="c0fcb-130">Z 深度の推奨事項</span><span class="sxs-lookup"><span data-stu-id="c0fcb-130">Recommendations for z-depth</span></span>

<span data-ttu-id="c0fcb-131">チェック ボックスをオフに視覚的なフォーカスを提供する管理者特権の平面の数を減らします。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-131">Reduce the number of elevated planes to provide clear visual focus.</span></span> <span data-ttu-id="c0fcb-132">ほとんどのシナリオでは、2 つの平面の十分な: フォア グラウンドの項目 (high の近接通信) とバック グラウンド項目 (低近接通信) のいずれか。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-132">For most scenarios, two planes is enough: one for foreground items (high proximity) and another for background items (low proximity).</span></span> <span data-ttu-id="c0fcb-133">重ならない複数の管理者特権での項目がある場合は、グループ化を平面の数を減らすために同じ平面 (つまり、フォア グラウンド)。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-133">If you have multiple elevated items that don’t overlap, group them the same plane (i.e., foreground) to reduce the number of planes.</span></span>

![アプリ内の z 深度](images/elevation-shadow/app-depth.svg)

## <a name="what-is-shadow"></a><span data-ttu-id="c0fcb-135">シャドウとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-135">What is shadow?</span></span>

![shadow](images/elevation-shadow/shadow.svg)

<span data-ttu-id="c0fcb-137">シャドウは、昇格を認識する方法です。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-137">Shadow is a way to perceive elevation.</span></span> <span data-ttu-id="c0fcb-138">管理者特権でのオブジェクトの上のライトがある場合は、次のサーフェスが影がします。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-138">When there is light above an elevated object, there is a shadow on the surface below.</span></span> <span data-ttu-id="c0fcb-139">オブジェクトが大きいほどより大きなおよび柔らかい影になります。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-139">The higher the object, the larger and softer the shadow becomes.</span></span> <span data-ttu-id="c0fcb-140">管理者特権でのオブジェクトは、シャドウを持つ必要はありませんが、シャドウは昇格を示すために注意してください。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-140">Note that elevated objects don’t need to have shadows, but shadows do indicate elevation.</span></span>

<span data-ttu-id="c0fcb-141">シャドウは、UWP アプリでは、意図的なきれいいないする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-141">In UWP apps, shadows should be purposeful, not aesthetic.</span></span> <span data-ttu-id="c0fcb-142">シャドウは、フォーカスと生産性を損ねます場合、は、シャドウの使用を制限します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-142">If shadows detract from focus and productivity, then limit the use of shadow.</span></span>

<span data-ttu-id="c0fcb-143">ThemeShadow または DropShadow Api のいずれかでは、シャドウを使用できます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-143">You can use shadows with either the ThemeShadow or DropShadow APIs.</span></span>

## <a name="themeshadow"></a><span data-ttu-id="c0fcb-144">ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="c0fcb-144">ThemeShadow</span></span>

<span data-ttu-id="c0fcb-145">シャドウ適切にに基づいて x、y、z 座標する ThemeShadow の種類を描画する任意の XAML 要素に適用できます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-145">The ThemeShadow type can be applied to any XAML element to draw shadows appropriately based on x, y, z coordinates.</span></span> <span data-ttu-id="c0fcb-146">ThemeShadow は、その他の環境の仕様にも自動的に調整します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-146">ThemeShadow also automatically adjusts for other environmental specifications:</span></span>

- <span data-ttu-id="c0fcb-147">照明、ユーザーのテーマ、アプリの環境、シェルの変更に適応します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-147">Adapts to changes in lighting, user theme, app environment, and shell.</span></span>
- <span data-ttu-id="c0fcb-148">シャドウ要素昇格に基づいて自動的にを処理します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-148">Shadows elements automatically based on their elevation.</span></span>
- <span data-ttu-id="c0fcb-149">要素のによって同期が維持に移動し、昇格を変更します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-149">Keeps elements in sync as they move and change elevation.</span></span>
- <span data-ttu-id="c0fcb-150">全体にわたってとアプリケーション間で一貫性のあるシャドウを保持します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-150">Keeps shadows consistent throughout and across applications.</span></span>

<span data-ttu-id="c0fcb-151">次に、淡色テーマと濃色テーマのさまざまな高度に ThemeShadow の例を示します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-151">Here are examples of ThemeShadow at different elevations with the light and dark themes:</span></span>

![淡色テーマとスマート シャドウ](images/elevation-shadow/smartshadow-light.svg)

![濃色テーマのスマート シャドウ](images/elevation-shadow/smartshadow-dark.svg)

### <a name="themeshadow-in-common-controls"></a><span data-ttu-id="c0fcb-154">ThemeShadow を共通の制御します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-154">ThemeShadow in common controls</span></span>

<span data-ttu-id="c0fcb-155">自動的に次の一般的なコントロールは、ThemeShadow を使用して、シャドウを生じさせるのには。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-155">The following common controls will automatically use ThemeShadow to cast shadows:</span></span>

- [<span data-ttu-id="c0fcb-156">ダイアログとポップアップ</span><span class="sxs-lookup"><span data-stu-id="c0fcb-156">Dialogs and flyouts</span></span>](../controls-and-patterns/dialogs.md)
- [<span data-ttu-id="c0fcb-157">NavigationView</span><span class="sxs-lookup"><span data-stu-id="c0fcb-157">NavigationView</span></span>](../controls-and-patterns/navigationview.md)
- [<span data-ttu-id="c0fcb-158">メディア トランスポート コントロール</span><span class="sxs-lookup"><span data-stu-id="c0fcb-158">Media transport control</span></span>](../controls-and-patterns/media-playback.md)
- [<span data-ttu-id="c0fcb-159">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="c0fcb-159">Context menu</span></span>](../controls-and-patterns/menus.md)
- [<span data-ttu-id="c0fcb-160">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="c0fcb-160">Command bar</span></span>](../controls-and-patterns/app-bars.md)
- <span data-ttu-id="c0fcb-161">[自動提案](../controls-and-patterns/auto-suggest-box.md)、[コンボ ボックス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、[カレンダー、日付/時刻の選択](../controls-and-patterns/date-and-time.md)、[ヒント](../controls-and-patterns/tooltips.md)</span><span class="sxs-lookup"><span data-stu-id="c0fcb-161">[AutoSuggest](../controls-and-patterns/auto-suggest-box.md), [ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [Calendar/Date/Time pickers](../controls-and-patterns/date-and-time.md), [Tooltip](../controls-and-patterns/tooltips.md)</span></span>
- [<span data-ttu-id="c0fcb-162">アクセス キー</span><span class="sxs-lookup"><span data-stu-id="c0fcb-162">Access keys</span></span>](../input/access-keys.md)

### <a name="themeshadow-in-popups"></a><span data-ttu-id="c0fcb-163">ポップアップで ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="c0fcb-163">ThemeShadow in Popups</span></span>

<span data-ttu-id="c0fcb-164">ThemeShadow では、シャドウの[ポップアップ](/uwp/api/windows.ui.xaml.controls.primitives.popup)内の任意の XAML 要素に適用されると自動的にキャストします。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-164">ThemeShadow automatically casts shadows when applied to any XAML element in a [Popup](/uwp/api/windows.ui.xaml.controls.primitives.popup).</span></span> <span data-ttu-id="c0fcb-165">下にあるその他のオープンのポップアップの背後にあるアプリのバック グラウンドのコンテンツのシャドウを生じ、されます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-165">It will cast shadows on the app background content behind it and any other open Popups below it.</span></span>

<span data-ttu-id="c0fcb-166">ポップアップを持つ ThemeShadow を使用する、`Shadow`プロパティを XAML 要素に、ThemeShadow を適用します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-166">To use ThemeShadow with Popups, use the `Shadow` property to apply a ThemeShadow to a XAML element.</span></span> <span data-ttu-id="c0fcb-167">次に、昇格要素、背後にある他の要素からなどの z コンポーネントを使用して、`Translation`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-167">Then, elevate the element from other elements behind it, for example by using the z component of the `Translation` property.</span></span>
<span data-ttu-id="c0fcb-168">ほとんどのポップアップ UI では、アプリのバック グラウンドのコンテンツを基準としたことをお勧めの既定の昇格は 32 の有効ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-168">For most Popup UI, the recommended default elevation relative to the app background content is 32 effective pixels.</span></span>

<span data-ttu-id="c0fcb-169">この例は、アプリのバック グラウンド コンテンツと背後にある他のポップアップにシャドウをキャスト ポップアップ内の四角形を示します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-169">This example shows a Rectangle in a Popup casting a shadow onto the app background content and any other Popups behind it:</span></span>

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

![コード例からシャドウ](images/elevation-shadow/smartshadow-example.svg)

### <a name="themeshadow-in-other-elements"></a><span data-ttu-id="c0fcb-171">その他の要素で ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="c0fcb-171">ThemeShadow in other elements</span></span>

<span data-ttu-id="c0fcb-172">ポップアップではない XAML 要素からシャドウをキャストするは、その他の要素でシャドウを受け取ることができる明示的に指定する必要があります、`ThemeShadow.Receivers`コレクションです。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-172">To cast a shadow from a XAML element that isn't in a Popup, you must explicitly specify the other elements that can receive the shadow in the `ThemeShadow.Receivers` collection.</span></span>

<span data-ttu-id="c0fcb-173">この例は、それらの背後にあるグリッドにシャドウを生じさせる 2 つのボタンを示しています。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-173">This example shows two Buttons that cast shadows onto a Grid behind them:</span></span>

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

### <a name="performance-best-practices-for-themeshadow"></a><span data-ttu-id="c0fcb-174">ThemeShadow のパフォーマンスのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="c0fcb-174">Performance best practices for ThemeShadow</span></span>

1. <span data-ttu-id="c0fcb-175">最低限必要なカスタム レシーバー要素の数に制限します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-175">Limit the number of custom receiver elements to the minimum necessary.</span></span> 

2. <span data-ttu-id="c0fcb-176">複数の受信者要素が同じ昇格に場合は、代わりに、1 つの親要素をターゲットとしてそれらを結合するしてみてください。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-176">If multiple receiver elements are at the same elevation then try to combine them by targeting a single parent element instead.</span></span>

3. <span data-ttu-id="c0fcb-177">複数の要素のキャスト先と同じ種類レシーバーと同じ要素に影の場合は、共有リソースとして、シャドウを追加し、再利用します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-177">If multiple elements will cast the same type of shadow onto the same receiver elements then add the shadow as a shared resource and reuse it.</span></span>

## <a name="drop-shadow"></a><span data-ttu-id="c0fcb-178">ドロップ シャドウ</span><span class="sxs-lookup"><span data-stu-id="c0fcb-178">Drop shadow</span></span>

<span data-ttu-id="c0fcb-179">DropShadow はその環境への応答が自動的にではなく、光源を使用しません。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-179">DropShadow is not automatically responsive to its environment and does not use light sources.</span></span> <span data-ttu-id="c0fcb-180">たとえば、実装では、 [DropShadow クラス](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-180">For example implementations, see the [DropShadow Class](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow).</span></span>

## <a name="which-shadow-should-i-use"></a><span data-ttu-id="c0fcb-181">どのシャドウを使用する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-181">Which shadow should I use?</span></span>

| <span data-ttu-id="c0fcb-182">プロパティ</span><span class="sxs-lookup"><span data-stu-id="c0fcb-182">Property</span></span> | <span data-ttu-id="c0fcb-183">ThemeShadow</span><span class="sxs-lookup"><span data-stu-id="c0fcb-183">ThemeShadow</span></span> | <span data-ttu-id="c0fcb-184">DropShadow</span><span class="sxs-lookup"><span data-stu-id="c0fcb-184">DropShadow</span></span> |
| - | - | - | - |
| **<span data-ttu-id="c0fcb-185">Min SDK</span><span class="sxs-lookup"><span data-stu-id="c0fcb-185">Min SDK</span></span>** | <span data-ttu-id="c0fcb-186">RS5</span><span class="sxs-lookup"><span data-stu-id="c0fcb-186">RS5</span></span> | <span data-ttu-id="c0fcb-187">14393</span><span class="sxs-lookup"><span data-stu-id="c0fcb-187">14393</span></span> |
| **<span data-ttu-id="c0fcb-188">適応性</span><span class="sxs-lookup"><span data-stu-id="c0fcb-188">Adaptability</span></span>** | <span data-ttu-id="c0fcb-189">はい</span><span class="sxs-lookup"><span data-stu-id="c0fcb-189">Yes</span></span> | <span data-ttu-id="c0fcb-190">いいえ</span><span class="sxs-lookup"><span data-stu-id="c0fcb-190">No</span></span> |
| **<span data-ttu-id="c0fcb-191">カスタマイズ</span><span class="sxs-lookup"><span data-stu-id="c0fcb-191">Customization</span></span>** | <span data-ttu-id="c0fcb-192">いいえ</span><span class="sxs-lookup"><span data-stu-id="c0fcb-192">No</span></span> | <span data-ttu-id="c0fcb-193">はい</span><span class="sxs-lookup"><span data-stu-id="c0fcb-193">Yes</span></span> |
| **<span data-ttu-id="c0fcb-194">光源</span><span class="sxs-lookup"><span data-stu-id="c0fcb-194">Light source</span></span>** | <span data-ttu-id="c0fcb-195">自動 (既定では、グローバル アプリごとに上書きできますが、)</span><span class="sxs-lookup"><span data-stu-id="c0fcb-195">Automatic (global by default, but can override per app)</span></span> | <span data-ttu-id="c0fcb-196">なし</span><span class="sxs-lookup"><span data-stu-id="c0fcb-196">None</span></span> |
| **<span data-ttu-id="c0fcb-197">3D 環境でサポートされています。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-197">Supported in 3D environments</span></span>** | <span data-ttu-id="c0fcb-198">はい</span><span class="sxs-lookup"><span data-stu-id="c0fcb-198">Yes</span></span> | <span data-ttu-id="c0fcb-199">いいえ</span><span class="sxs-lookup"><span data-stu-id="c0fcb-199">No</span></span> |

- <span data-ttu-id="c0fcb-200">一般に、その環境に自動的に対応する、ThemeShadow の使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-200">Generally, we recommend using ThemeShadow, which adapts automatically to its environment.</span></span>
- <span data-ttu-id="c0fcb-201">カスタムの影のシナリオが高度な場合より詳細にカスタマイズできる、DropShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-201">If you have more advanced scenarios for custom shadows, then use DropShadow, which allows for greater customization.</span></span>
- <span data-ttu-id="c0fcb-202">下位互換性、DropShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-202">For backwards compatibility, use DropShadow.</span></span>
- <span data-ttu-id="c0fcb-203">パフォーマンスを懸念するには、シャドウ、数を制限するか、DropShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-203">For concerns about performance, limit the number of shadows, or use DropShadow.</span></span>
- <span data-ttu-id="c0fcb-204">True 3d HMDs、ThemeShadow を使用します。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-204">On HMDs in true 3D, use ThemeShadow.</span></span> <span data-ttu-id="c0fcb-205">側から、その親 visual から指定されたオフセット DropShadow を描画するため、空間ではフローティング状態などが検索されます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-205">Since DropShadow draws at a specified offset from the visual it is parented to, from the side, it will look like it's floating in space.</span></span> <span data-ttu-id="c0fcb-206">その一方で、ThemeShadow はレシーバーとして定義されている視覚効果の上にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="c0fcb-206">On the other hand, ThemeShadow is rendered on top of the visuals defined as receivers.</span></span>
