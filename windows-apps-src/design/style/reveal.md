---
author: mijacobs
description: "表示は照明効果の 1 つで、アプリの対話型要素に奥行きを与え、焦点を当てるために役立ちます。"
title: "表示ハイライト"
template: detail.hbs
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: conrwi
dev-contact: jevansa
doc-status: Published
ms.localizationpriority: high
ms.openlocfilehash: 8ba0d9939d7ab1d9826ed2848e476499f09c628f
ms.sourcegitcommit: 4b522af988273946414a04fbbd1d7fde40f8ba5e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/08/2018
---
# <a name="reveal-highlight"></a><span data-ttu-id="0a4e1-104">表示ハイライト</span><span class="sxs-lookup"><span data-stu-id="0a4e1-104">Reveal highlight</span></span>

<span data-ttu-id="0a4e1-105">表示は照明効果の 1 つで、アプリの対話型要素に奥行きを与え、焦点を当てるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-105">Reveal is a lighting effect that helps bring depth and focus to your app's interactive elements.</span></span>

> <span data-ttu-id="0a4e1-106">**重要な API**: [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)、[RevealBackgroundBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush)、[RevealBorderBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush)、[RevealBrushHelper クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper)、[VisualState class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)</span><span class="sxs-lookup"><span data-stu-id="0a4e1-106">**Important APIs**: [RevealBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush), [RevealBackgroundBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush), [RevealBorderBrush class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush), [RevealBrushHelper class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper), [VisualState class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)</span></span>

<span data-ttu-id="0a4e1-107">表示動作は、ポインターが近くにある場合にクリック可能なコンテンツのコンテナーを表示することによりこれを行います。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-107">The Reveal behavior does this by revealing the clickable content’s container when the pointer is nearby.</span></span>

![表示のビジュアル効果](images/Nav_Reveal_Animation.gif)

<span data-ttu-id="0a4e1-109">オブジェクトの周囲にある非表示の境界線を明示すると、表示の動作によって、ユーザーが操作する領域の認識が容易になり、実行できる操作もわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-109">By exposing the hidden borders around objects, Reveal gives users a better understanding of the space that they are interacting with, and helps them understand the actions available.</span></span> <span data-ttu-id="0a4e1-110">これは、リスト コントロールやボタンのグループ化では特に重要です。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-110">This is especially important in list controls and groupings of buttons.</span></span>

## <a name="examples"></a><span data-ttu-id="0a4e1-111">例</span><span class="sxs-lookup"><span data-stu-id="0a4e1-111">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="0a4e1-112">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="0a4e1-112">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="0a4e1-113"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Reveal">アプリを開き、表示の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-113">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Reveal">open the app and see Reveal in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="0a4e1-114">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="0a4e1-114">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="0a4e1-115">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="0a4e1-115">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="video-summary"></a><span data-ttu-id="0a4e1-116">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="0a4e1-116">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev013/player]

## <a name="reveal-and-the-fluent-design-system"></a><span data-ttu-id="0a4e1-117">表示と Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="0a4e1-117">Reveal and the Fluent Design System</span></span>

 <span data-ttu-id="0a4e1-118">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-118">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="0a4e1-119">表示は、アプリにライトを追加する Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-119">Reveal is a Fluent Design System component that adds light to your app.</span></span> <span data-ttu-id="0a4e1-120">詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-120">To learn more, see the [Fluent Design for UWP overview](../fluent-design-system/index.md).</span></span>

## <a name="how-to-use-it"></a><span data-ttu-id="0a4e1-121">用途</span><span class="sxs-lookup"><span data-stu-id="0a4e1-121">How to use it</span></span>

<span data-ttu-id="0a4e1-122">表示は、一部のコントロールでは自動的に動作します。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-122">Reveal automatically works for some controls.</span></span> <span data-ttu-id="0a4e1-123">他のコントロールでは、コントロールに特別なスタイルを割り当てることにより表示を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-123">For other controls, you can enable reveal by assigning a special style to the control.</span></span>

## <a name="controls-that-automatically-use-reveal"></a><span data-ttu-id="0a4e1-124">表示を自動的に使用するコントロール</span><span class="sxs-lookup"><span data-stu-id="0a4e1-124">Controls that automatically use Reveal</span></span>

- [**<span data-ttu-id="0a4e1-125">ListView</span><span class="sxs-lookup"><span data-stu-id="0a4e1-125">ListView</span></span>**](../controls-and-patterns/lists.md)
- [**<span data-ttu-id="0a4e1-126">GridView</span><span class="sxs-lookup"><span data-stu-id="0a4e1-126">GridView</span></span>**](../controls-and-patterns/lists.md)
- [**<span data-ttu-id="0a4e1-127">TreeView</span><span class="sxs-lookup"><span data-stu-id="0a4e1-127">TreeView</span></span>**](../controls-and-patterns/tree-view.md)
- [**<span data-ttu-id="0a4e1-128">NavigationView</span><span class="sxs-lookup"><span data-stu-id="0a4e1-128">NavigationView</span></span>**](../controls-and-patterns/navigationview.md)
- [**<span data-ttu-id="0a4e1-129">AutosuggestBox</span><span class="sxs-lookup"><span data-stu-id="0a4e1-129">AutosuggestBox</span></span>**](../controls-and-patterns/auto-suggest-box.md)
- [**<span data-ttu-id="0a4e1-130">MediaTransportControl</span><span class="sxs-lookup"><span data-stu-id="0a4e1-130">MediaTransportControl</span></span>**](../controls-and-patterns/media-playback.md)
- [**<span data-ttu-id="0a4e1-131">CommandBar</span><span class="sxs-lookup"><span data-stu-id="0a4e1-131">CommandBar</span></span>**](../controls-and-patterns/app-bars.md)
- [**<span data-ttu-id="0a4e1-132">ComboBox</span><span class="sxs-lookup"><span data-stu-id="0a4e1-132">ComboBox</span></span>**](../controls-and-patterns/lists.md)

<span data-ttu-id="0a4e1-133">これらの図は、いくつかの異なるコントロールでの表示効果を示しています。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-133">These illustrations show the reveal effect on several different controls:</span></span>

![表示の例](images/RevealExamples_Collage.png)

## <a name="enabling-reveal-on-other-common-controls"></a><span data-ttu-id="0a4e1-135">他の一般的なコントロールで表示を有効にする</span><span class="sxs-lookup"><span data-stu-id="0a4e1-135">Enabling Reveal on other common controls</span></span>

<span data-ttu-id="0a4e1-136">表示の適用が必要なシナリオの場合 (シナリオで使用されるコントロールはメイン コンテンツである場合、またはそれらのコントロールがリストやコレクションに対応するために使用される場合)、オプトインのリソース スタイルが用意されているので、これらのスタイルを使用することで、そのような状況で表示を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-136">If you have a scenario where Reveal should be applied (these controls are main content and/or are used in a list or collection orientation), we've provided opt-in resource styles that allow you to enable Reveal for those types of situations.</span></span>

<span data-ttu-id="0a4e1-137">以下に示すコントロールは、既定では表示の機能を備えていません。これらのコントロールは小さなコントロールであり、通常は、アプリケーションの重要なコンテンツをサポートするヘルパー コントロールですが、アプリによってはその状況は異なります。これらのコントロールをアプリの多くの部分で使用する場合は、その表示をサポートするスタイルがいくつか用意されているのでご利用ください。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-137">These controls do not have Reveal by default as they are smaller controls that are usually helper controls to the main focal points of your application; but every app is different, and if these controls are used the most in your app, we've provided some styles to aid with that:</span></span>

| <span data-ttu-id="0a4e1-138">コントロール名</span><span class="sxs-lookup"><span data-stu-id="0a4e1-138">Control Name</span></span>   | <span data-ttu-id="0a4e1-139">リソース名</span><span class="sxs-lookup"><span data-stu-id="0a4e1-139">Resource Name</span></span> |
|----------|:-------------:|
| <span data-ttu-id="0a4e1-140">Button</span><span class="sxs-lookup"><span data-stu-id="0a4e1-140">Button</span></span> |  <span data-ttu-id="0a4e1-141">ButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="0a4e1-141">ButtonRevealStyle</span></span> |
| <span data-ttu-id="0a4e1-142">ToggleButton</span><span class="sxs-lookup"><span data-stu-id="0a4e1-142">ToggleButton</span></span> | <span data-ttu-id="0a4e1-143">ToggleButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="0a4e1-143">ToggleButtonRevealStyle</span></span> |
| <span data-ttu-id="0a4e1-144">RepeatButton</span><span class="sxs-lookup"><span data-stu-id="0a4e1-144">RepeatButton</span></span> | <span data-ttu-id="0a4e1-145">RepeatButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="0a4e1-145">RepeatButtonRevealStyle</span></span> |
| <span data-ttu-id="0a4e1-146">AppBarButton</span><span class="sxs-lookup"><span data-stu-id="0a4e1-146">AppBarButton</span></span> | <span data-ttu-id="0a4e1-147">AppBarButtonRevealStyle</span><span class="sxs-lookup"><span data-stu-id="0a4e1-147">AppBarButtonRevealStyle</span></span> |
| <span data-ttu-id="0a4e1-148">SemanticZoom</span><span class="sxs-lookup"><span data-stu-id="0a4e1-148">SemanticZoom</span></span> | <span data-ttu-id="0a4e1-149">SemanticZoomRevealStyle</span><span class="sxs-lookup"><span data-stu-id="0a4e1-149">SemanticZoomRevealStyle</span></span> |

<span data-ttu-id="0a4e1-150">これらのスタイルを適用するには、Style プロパティを次のように更新するだけです。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-150">To apply these styles, simply update the Style property like so:</span></span>

```XAML
<Button Content="Button Content" Style="{StaticResource ButtonRevealStyle}"/>
```

## <a name="enabling-reveal-on-custom-controls"></a><span data-ttu-id="0a4e1-151">カスタム コントロールで表示を有効にする</span><span class="sxs-lookup"><span data-stu-id="0a4e1-151">Enabling Reveal on custom controls</span></span>

<span data-ttu-id="0a4e1-152">システム コントロールが表示を取得するかどうかを判断する際に考える必要がある一般的なルールは、すべてアプリで実行する包括的な機能またはアクションに関連している対話型要素のグループを作成する必要があるということです。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-152">The general rule to think about when deciding whether or not your custom control should get Reveal, is you must have a grouping of interactive elements that all relate to an overarching feature or action you wish to perform in your app.</span></span>

<span data-ttu-id="0a4e1-153">たとえば、NavigationView の項目はページ ナビゲーションに関連しています。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-153">For example, NavigationView's items are related to page navigation.</span></span> <span data-ttu-id="0a4e1-154">CommandBar のボタンは、メニューのアクションまたはページ機能のアクションに関連しています。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-154">CommandBar's buttons relate to menu actions or page feature actions.</span></span> <span data-ttu-id="0a4e1-155">その下にある MediaTransportControl のボタンは、すべて再生するメディアに関連しています。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-155">MediaTransportControl's buttons beneath all relate to the media being played.</span></span>

<span data-ttu-id="0a4e1-156">表示を取得するコントロールが互いに関連している必要はありません。高密度の領域に存在し、大きい目的に適合しているだけでかまいません。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-156">The controls that get Reveal do not have to be related to each other, they just have to be in a high-density area, and serve a greater purpose.</span></span>

<span data-ttu-id="0a4e1-157">カスタム コントロールや再テンプレート化されたコントロールで表示を有効にするには、そのコントロールのテンプレートの表示状態 (VisualState) でコントロールのスタイルを調べ、ルート グリッドで表示を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-157">To enable Reveal on custom controls or re-templated controls, you can go into the style for that control in the Visual States of that control's template and specify Reveal on the root grid:</span></span>

```xaml
<VisualState x:Name="PointerOver">
    <VisualState.Setters>
        <Setter Target="RootGrid.(RevealBrush.State)" Value="PointerOver" />
        <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPointerOver}" />
        <Setter Target="ContentPresenter.BorderBrush" Value="Transparent"/>
        <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPointerOver}" />
    </VisualState.Setters>
</VisualState>
```

<span data-ttu-id="0a4e1-158">表示が十分に機能するため、表示状態ではブラシと setter の両方が必要である点に留意することは重要です。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-158">It's important to note that Reveal needs both the brush and the setters in it's Visual State in order to work fully.</span></span> <span data-ttu-id="0a4e1-159">コントロールのブラシをいずれかの表示ブラシ リソースに設定するだけでは、そのコントロールの表示が有効になりません。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-159">Simply setting a control's brush to one of our Reveal brush resources alone won't enable Reveal for that control.</span></span> <span data-ttu-id="0a4e1-160">反対に、表示ブラシとなる値がないターゲットまたは設定だけでも表示は有効になりません。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-160">Conversely, having only the targets or settings without the values being Reveal brushes will also not enable Reveal.</span></span>

<span data-ttu-id="0a4e1-161">UI のカスタマイズに使うことができる一連のシステム表示ブラシが作成されました。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-161">We've created a set of system Reveal brushes you can use to customize your UI.</span></span> <span data-ttu-id="0a4e1-162">たとえば、**ButtonRevealBackground** ブラシを使ってカスタム ボタンの背景を作成したり、カスタム一覧に **ListViewItemRevealBackground** ブラシを使ったりすることができます </span><span class="sxs-lookup"><span data-stu-id="0a4e1-162">For example, you can use the **ButtonRevealBackground** brush to create a custom button background, or the **ListViewItemRevealBackground** brush for custom lists, and so on.</span></span>

<span data-ttu-id="0a4e1-163">(XAMl でのリソースのしくみについて詳しくは、[Xaml リソース ディクショナリに関する記事](../controls-and-patterns/resourcedictionary-and-xaml-resource-references.md)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-163">(To learn about how resources work in XAMl, check out the [Xaml Resource Dictionary](../controls-and-patterns/resourcedictionary-and-xaml-resource-references.md) article.)</span></span>

### <a name="reveal-on-listview-controls-with-nested-buttons"></a><span data-ttu-id="0a4e1-164">入れ子になったボタンのある ListView コントロールでの表示</span><span class="sxs-lookup"><span data-stu-id="0a4e1-164">Reveal on ListView controls with nested buttons</span></span>

<span data-ttu-id="0a4e1-165">[ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) があり、その [ListViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listviewitem) 要素内でボタンや呼び出し可能なコンテンツが入れ子になっている場合、入れ子になった項目の表示を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-165">If you have a [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) and also have buttons or invokable content nested inside its [ListViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listviewitem) elements, you should enable Reveal for the nested items.</span></span>

<span data-ttu-id="0a4e1-166">ボタン、またはListViewItem 内のボタンのようなコントロールの場合、コントロールの [Style](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_Style) プロパティを **ButtonRevealStyle** 静的リソースに設定するだけです。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-166">In the case of Buttons, or button-like controls in a ListViewItem, simply set the control's  [Style](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_Style) property to the **ButtonRevealStyle** static resource.</span></span> 

![入れ子になった表示](images/NestedListContent.png)

<span data-ttu-id="0a4e1-168">この例では、ListViewItem 内のいくつかのボタンで表示を有効にします。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-168">This example enables Reveal on several buttons inside a ListViewItem.</span></span> 

```XAML
<ListViewItem>
    <StackPanel Orientation="Horizontal">
        <TextBlock Margin="5">Test Text: lorem ipsum.</TextBlock>
        <StackPanel Orientation="Horizontal">
            <Button Content="&#xE71B;" FontFamily="Segoe MDL2 Assets" Width="45" Height="45" Margin="5" Style="{StaticResource ButtonRevealStyle}"/>
            <Button Content="&#xE728;" FontFamily="Segoe MDL2 Assets" Width="45" Height="45" Margin="5" Style="{StaticResource ButtonRevealStyle}"/>
            <Button Content="&#xE74D;" FontFamily="Segoe MDL2 Assets" Width="45" Height="45" Margin="5" Style="{StaticResource ButtonRevealStyle}"/>
         </StackPanel>
    </StackPanel>
</ListViewItem>
```

### <a name="listviewitempresenter-with-reveal"></a><span data-ttu-id="0a4e1-169">表示のある ListViewItemPresenter</span><span class="sxs-lookup"><span data-stu-id="0a4e1-169">ListViewItemPresenter with Reveal</span></span>

<span data-ttu-id="0a4e1-170">一覧は、XAML では少し特別です。表示のケースでは、ListViewItemPresenter 内で表示専用の Visual State Manager を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-170">Lists are a bit special in XAML, and for Reveal's case we'll have to define the Visual State Manager for Reveal only inside the ListViewItemPresenter:</span></span>

```XAML
<ListViewItemPresenter>
<!-- ContentTransitions, SelectedForeground, etc. properties -->
RevealBackground="{ThemeResource ListViewItemRevealBackground}"
RevealBorderThickness="{ThemeResource ListViewItemRevealBorderThemeThickness}"
RevealBorderBrush="{ThemeResource ListViewItemRevealBorderBrush}">
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="CommonStates">
        <VisualState x:Name="Normal" />
        <VisualState x:Name="Selected" />
        <VisualState x:Name="PointerOver">
            <VisualState.Setters>
                <Setter Target="Root.(RevealBrush.State)" Value="PointerOver" />
            </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="PointerOverSelected">
                <VisualState.Setters>
                    <Setter Target="Root.(RevealBrush.State)" Value="PointerOver" />
                </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="PointerOverPressed">
                <VisualState.Setters>
                    <Setter Target="Root.(RevealBrush.State)" Value="Pressed" />
                </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="Pressed">
                <VisualState.Setters>
                    <Setter Target="Root.(RevealBrush.State)" Value="Pressed" />
                </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="PressedSelected">
                <VisualState.Setters>
                    <Setter Target="Root.(RevealBrush.State)" Value="Pressed" />
                </VisualState.Setters>
            </VisualState>
            </VisualStateGroup>
                <VisualStateGroup x:Name="EnabledGroup">
                    <VisualState x:Name="Enabled" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                             <Setter Target="Root.RevealBorderThickness" Value="0"/>
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</ListViewItemPresenter>
```

<span data-ttu-id="0a4e1-171">これは、表示固有の表示状態 setter を持つ ListViewItemPresenter 内のプロパティ コレクションの末尾に追加することを意味します。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-171">This means appending to the end of the property collection within the ListViewItemPresenter with the Reveal specific Visual State setters.</span></span>

### <a name="full-template-example"></a><span data-ttu-id="0a4e1-172">テンプレート全体の例</span><span class="sxs-lookup"><span data-stu-id="0a4e1-172">Full Template Example</span></span>

<span data-ttu-id="0a4e1-173">表示ボタンの外観を示すテンプレート全体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-173">Here's an entire template for what a Reveal Button would look like:</span></span>

```XAML
<Style TargetType="Button" x:Key="ButtonStyle1">
    <Setter Property="Background" Value="{ThemeResource ButtonRevealBackground}" />
    <Setter Property="Foreground" Value="{ThemeResource ButtonForeground}" />
    <Setter Property="BorderBrush" Value="{ThemeResource ButtonRevealBorderBrush}" />
    <Setter Property="BorderThickness" Value="2" />
    <Setter Property="Padding" Value="8,4,8,4" />
    <Setter Property="HorizontalAlignment" Value="Left" />
    <Setter Property="VerticalAlignment" Value="Center" />
    <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}" />
    <Setter Property="FontWeight" Value="Normal" />
    <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}" />
    <Setter Property="UseSystemFocusVisuals" Value="True" />
    <Setter Property="FocusVisualMargin" Value="-3" />
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="Button">
                <Grid x:Name="RootGrid" Background="{TemplateBinding Background}">

                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal">

                                <Storyboard>
                                    <PointerUpThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="PointerOver">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.(RevealBrush.State)" Value="PointerOver" />
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPointerOver}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="Transparent"/>
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPointerOver}" />
                                </VisualState.Setters>

                                <Storyboard>
                                    <PointerUpThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="Pressed">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.(RevealBrush.State)" Value="Pressed" />
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPressed}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBackgroundPressed}" />
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPressed}" />
                                </VisualState.Setters>

                                <Storyboard>
                                    <PointerDownThemeAnimation Storyboard.TargetName="RootGrid" />
                                </Storyboard>
                            </VisualState>

                            <VisualState x:Name="Disabled">
                                <VisualState.Setters>
                                    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundDisabled}" />
                                    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBorderBrushDisabled}" />
                                    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundDisabled}" />
                                </VisualState.Setters>
                            </VisualState>
                        </VisualStateGroup>

              </VisualStateManager.VisualStateGroups>
                    <ContentPresenter x:Name="ContentPresenter"
                    BorderBrush="{TemplateBinding BorderBrush}"
                    BorderThickness="{TemplateBinding BorderThickness}"
                    Content="{TemplateBinding Content}"
                    ContentTransitions="{TemplateBinding ContentTransitions}"
                    ContentTemplate="{TemplateBinding ContentTemplate}"
                    Padding="{TemplateBinding Padding}"
                    HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}"
                    VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}"
                    AutomationProperties.AccessibilityView="Raw" />
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

## <a name="dos-and-donts"></a><span data-ttu-id="0a4e1-174">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="0a4e1-174">Do's and don'ts</span></span>
- <span data-ttu-id="0a4e1-175">ユーザーが操作を実行できる要素 (ボタン、選択肢) では表示を使う</span><span class="sxs-lookup"><span data-stu-id="0a4e1-175">Do use Reveal on elements where the user can take action (buttons, selections)</span></span>
- <span data-ttu-id="0a4e1-176">既定で視覚的な区切り記号がない対話型要素のグループ (一覧、コマンド バー) では表示を使う</span><span class="sxs-lookup"><span data-stu-id="0a4e1-176">Do use Reveal in groupings of interactive elements that do not have visual separators by default (lists, command bars)</span></span>
- <span data-ttu-id="0a4e1-177">対話型要素が高密度な領域では表示を使う</span><span class="sxs-lookup"><span data-stu-id="0a4e1-177">Do use Reveal in areas with a high density of interactive elements</span></span>
- <span data-ttu-id="0a4e1-178">静的コンテンツ (背景、テキスト) では表示を使わない</span><span class="sxs-lookup"><span data-stu-id="0a4e1-178">Don’t use Reveal on static content (backgrounds, text)</span></span>
- <span data-ttu-id="0a4e1-179">1 回限りの個別の状況では表示を使わない</span><span class="sxs-lookup"><span data-stu-id="0a4e1-179">Don’t use Reveal in one-off, isolated situations</span></span>
- <span data-ttu-id="0a4e1-180">非常に多くの項目 (500 epx 超) では表示を使わない</span><span class="sxs-lookup"><span data-stu-id="0a4e1-180">Don’t use Reveal on very large items (greater than 500epx)</span></span>
- <span data-ttu-id="0a4e1-181">セキュリティ上の決定を行う場合には表示を使わない (ユーザーに提供する必要があるメッセージから注意がそれる可能性があるため)</span><span class="sxs-lookup"><span data-stu-id="0a4e1-181">Don’t use Reveal in security decisions, as it may draw attention away from the message you need to deliver to your user</span></span>

## <a name="how-we-designed-reveal"></a><span data-ttu-id="0a4e1-182">表示をどのように設計したか</span><span class="sxs-lookup"><span data-stu-id="0a4e1-182">How we designed Reveal</span></span>

<span data-ttu-id="0a4e1-183">表示には 2 つの主要な視覚コンポーネントがあります。それらは、**ホバーによる表示**動作と**境界線による表示**動作です。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-183">There are two main visual components to Reveal: the **Hover Reveal** behavior, and the **Border Reveal** behavior.</span></span>

![表示レイヤー](images/RevealLayers.png)

<span data-ttu-id="0a4e1-185">ホバーによる表示は、ポインターやフォーカス入力によってポイントされるコンテンツに直接関連付けられており、ポイントされる項目やフォーカスが置かれる項目の周囲に滑らかなハロー型を適用し、その項目が操作可能であることを示します。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-185">The Hover Reveal is tied directly to the content being hovered over (via pointer or focus input), and applies a gentle halo shape around the hovered or focused item, letting you know you can interact with it.</span></span>

<span data-ttu-id="0a4e1-186">境界線による表示は、フォーカスが置かれる項目やその近くにある項目に適用されます。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-186">The Border Reveal is applied to the focused item and items nearby.</span></span> <span data-ttu-id="0a4e1-187">これにより、オブジェクトの近くにある項目に対して、現在フォーカスが置かれている項目と類似した操作を実行できること示されます。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-187">This shows you that those nearby objects can take actions similar to the one currently focused.</span></span>

<span data-ttu-id="0a4e1-188">表示のレシピには以下のものがあります。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-188">The Reveal recipe breakdown is:</span></span>

- <span data-ttu-id="0a4e1-189">境界線による表示は、すべてのコンテンツの最上位にありますが、指定されたエッジの上に配置されます</span><span class="sxs-lookup"><span data-stu-id="0a4e1-189">Border Reveal will be on top of all content but on the designated edges</span></span>
- <span data-ttu-id="0a4e1-190">テキストとコンテンツは、境界線による表示の直下に表示されます</span><span class="sxs-lookup"><span data-stu-id="0a4e1-190">Text and content will be displayed directly under Border Reveal</span></span>
- <span data-ttu-id="0a4e1-191">ホバーによる表示は、コンテンツとテキストの下にあります</span><span class="sxs-lookup"><span data-stu-id="0a4e1-191">Hover Reveal will be beneath content and text</span></span>
- <span data-ttu-id="0a4e1-192">バック プレート (ホバーによる表示をオンにして有効にします)</span><span class="sxs-lookup"><span data-stu-id="0a4e1-192">The backplate (that turns on and enables Hover Reveal)</span></span>
- <span data-ttu-id="0a4e1-193">背景 (コントロールの背景です)</span><span class="sxs-lookup"><span data-stu-id="0a4e1-193">The background (background of control)</span></span>

<!--
<div class=”microsoft-internal-note”>
To create your own Reveal lighting effect for static comps or prototype purposes, see the full [uni design guidance](http://uni/DesignDepot.FrontEnd/#/ProductNav/3020/1/dv/?t=Resources%7CToolkit%7CReveal&f=Neon) for this effect in illustrator.
</div>
-->  

## <a name="get-the-sample-code"></a><span data-ttu-id="0a4e1-194">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="0a4e1-194">Get the sample code</span></span>

- <span data-ttu-id="0a4e1-195">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="0a4e1-195">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="0a4e1-196">関連記事</span><span class="sxs-lookup"><span data-stu-id="0a4e1-196">Related articles</span></span>

- [<span data-ttu-id="0a4e1-197">RevealBrush クラス</span><span class="sxs-lookup"><span data-stu-id="0a4e1-197">RevealBrush class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)
- [<span data-ttu-id="0a4e1-198">アクリル</span><span class="sxs-lookup"><span data-stu-id="0a4e1-198">Acrylic</span></span>](acrylic.md)
- [<span data-ttu-id="0a4e1-199">コンポジションの効果</span><span class="sxs-lookup"><span data-stu-id="0a4e1-199">Composition Effects</span></span>](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [<span data-ttu-id="0a4e1-200">UWP の Fluent Design</span><span class="sxs-lookup"><span data-stu-id="0a4e1-200">Fluent Design for UWP</span></span>](../fluent-design-system/index.md)
- [<span data-ttu-id="0a4e1-201">システムの科学: Fluent Design と奥行き</span><span class="sxs-lookup"><span data-stu-id="0a4e1-201">Science in the System: Fluent Design and Depth</span></span>](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [<span data-ttu-id="0a4e1-202">システムの科学: Fluent Design と明るさ</span><span class="sxs-lookup"><span data-stu-id="0a4e1-202">Science in the System: Fluent Design and Light</span></span>](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
