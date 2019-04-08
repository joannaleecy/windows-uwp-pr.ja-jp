---
title: キーボード、ゲームパッド、リモコン、アクセシビリティ ツールのフォーカス ナビゲーション
Description: フォーカスのナビゲーションを使用して、キーボード ユーザーが power、障碍を持つものとその他のアクセシビリティ要件だけでなく、10 フィート エクスペリエンスのため、UWP アプリとカスタム コントロールでの包括的で一貫性のある相互作用のエクスペリエンスを提供する方法について説明しますテレビ画面および Xbox One です。
label: ''
template: detail.hbs
keywords: キーボード, ゲーム コントローラー, リモコン, ナビゲーション, 方向内部ナビゲーション, 方向領域, ナビゲーション方法, 入力, ユーザーの操作, アクセシビリティ, 操作性
ms.date: 03/02/2018
ms.topic: article
pm-contact: miguelrb
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a699ef00b3f377656940e66e6d35bfcba1cc5762
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57625827"
---
# <a name="focus-navigation-for-keyboard-gamepad-remote-control-and-accessibility-tools"></a><span data-ttu-id="47a85-104">キーボード、ゲームパッド、リモコン、アクセシビリティ ツールのフォーカス ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="47a85-104">Focus navigation for keyboard, gamepad, remote control, and accessibility tools</span></span>

![キーボード、リモート、および方向パッド](images/dpad-remote/dpad-remote-keyboard.png)

<span data-ttu-id="47a85-106">フォーカス ナビゲーションを使用すると、キーボードを使い慣れているパワー ユーザーや障碍およびその他のアクセシビリティ要件を持っているユーザーは、総合的で一貫性のあるエクスペリエンスを UWP アプリやカスタム コントロールで利用できるようになります。また、テレビ画面と Xbox One の 10 フィート エクスペリエンスも利用することができます。</span><span class="sxs-lookup"><span data-stu-id="47a85-106">Use focus navigation to provide comprehensive and consistent interaction experiences in your UWP apps and custom controls for keyboard power users, those with disabilities and other accessibility requirements, as well as the 10-foot experience of television screens and the Xbox One.</span></span>

## <a name="overview"></a><span data-ttu-id="47a85-107">概要</span><span class="sxs-lookup"><span data-stu-id="47a85-107">Overview</span></span>

<span data-ttu-id="47a85-108">フォーカス ナビゲーションとは、キーボード、ゲームパッド、リモコンを使用して、ユーザーが UWP アプリケーションの UI 間を移動したり、これらの UI を操作したりできるようにする基本的なメカニズムです。</span><span class="sxs-lookup"><span data-stu-id="47a85-108">Focus navigation refers to the underlying mechanism that enables users to navigate and interact with the UI of a UWP application using a keyboard, gamepad, or remote control.</span></span>

> [!NOTE]
> <span data-ttu-id="47a85-109">通常、入力デバイスは、ポインティング デバイス (タッチ、タッチパッド、ペン、マウスなど)、および非ポインティング デバイス (キーボード、ゲームパッド、リモコンなど) に分類されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-109">Input devices are typically classified as pointing devices, such as touch, touchpad, pen, and mouse, and non-pointing devices, such as keyboard, gamepad, and remote control.</span></span>

<span data-ttu-id="47a85-110">このトピックでは、UWP アプリケーションを最適化し、非ポインティングの入力タイプを必要としているユーザー向けにカスタム操作エクスペリエンスを構築する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="47a85-110">This topic describes how to optimize a UWP application and build custom interaction experiences for users that rely on non-pointing input types.</span></span> 

<span data-ttu-id="47a85-111">PC 上の UWP アプリのカスタム コントロールではキーボード入力に焦点を当てていますが、タッチ キーボードやスクリーン キーボード (OSK) などのソフトウェア キーボード、Windows ナレーターなどのアクセシビリティ ツールのサポート、および 10 フィート エクスペリエンスのサポートのために、適切に設計されたキーボード エクスペリエンスも重要となります。</span><span class="sxs-lookup"><span data-stu-id="47a85-111">Even though we focus on keyboard input for custom controls in UWP apps on PCs, a well-designed keyboard experience is also important for software keyboards such as the touch keyboard and the On-Screen Keyboard (OSK), supporting accessibility tools such as Windows Narrator, and supporting the 10-foot experience.</span></span>

<span data-ttu-id="47a85-112">ポインティング デバイスのために UWP アプリケーションでカスタム エクスペリエンスを構築する方法のガイダンスについては、「[ポインター入力の処理](handle-pointer-input.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="47a85-112">See [Handle pointer input](handle-pointer-input.md) for guidance on building custom experiences in UWP applications for pointing devices.</span></span>

<span data-ttu-id="47a85-113">キーボード用にアプリとエクスペリエンスを構築する方法の一般的な情報については、「[キーボード操作](keyboard-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="47a85-113">For more general information on building apps and experiences for keyboard, see [Keyboard Interaction](keyboard-interactions.md).</span></span>

## <a name="general-guidance"></a><span data-ttu-id="47a85-114">一般的なガイドライン</span><span class="sxs-lookup"><span data-stu-id="47a85-114">General guidance</span></span>

<span data-ttu-id="47a85-115">フォーカス ナビゲーションをサポートする必要があるのは、ユーザーの操作を必要とする UI 要素のみです。操作を必要としない要素 (静的な画像など) では、キーボード フォーカスは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="47a85-115">Only those UI elements that require user interaction should support focus navigation, elements that don’t require an action, such as static images, do not need keyboard focus.</span></span> <span data-ttu-id="47a85-116">スクリーン リーダー、およびこれに類似したアクセシビリティ ツールでは、こうした静的な要素がフォーカス ナビゲーションの対象となっていない場合でも、これらの要素の読み上げが行われます。</span><span class="sxs-lookup"><span data-stu-id="47a85-116">Screen readers and similar accessibility tools still announce these static elements, even when they are not included in focus navigation.</span></span> 

<span data-ttu-id="47a85-117">マウスやタッチなどのポインター デバイスによるナビゲーションとは異なり、フォーカス ナビゲーションは直線的であることを覚えておくことは大切です。</span><span class="sxs-lookup"><span data-stu-id="47a85-117">It is important to remember that unlike navigating with a pointer device such as a mouse or touch, focus navigation is linear.</span></span> <span data-ttu-id="47a85-118">フォーカス ナビゲーションを実装するときは、ユーザーがアプリケーションを操作する方法や論理的なナビゲーションについて考慮してください。</span><span class="sxs-lookup"><span data-stu-id="47a85-118">When implementing focus navigation, consider how a user will interact with your application and what the logical navigation should be.</span></span> <span data-ttu-id="47a85-119">ほとんどの場合、カスタム フォーカス ナビゲーションの動作は、ユーザーのカルチャで適切とされる読み取りパターンに従うようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47a85-119">In most cases, we recommend custom focus navigation behavior follows the preferred reading pattern of the user's culture.</span></span>

<span data-ttu-id="47a85-120">フォーカス ナビゲーションでは、その他に次の点も考慮してください。</span><span class="sxs-lookup"><span data-stu-id="47a85-120">Some other focus navigation considerations include:</span></span>

- <span data-ttu-id="47a85-121">コントロールが論理的にグループ化されているか。</span><span class="sxs-lookup"><span data-stu-id="47a85-121">Are controls grouped logically?</span></span>
- <span data-ttu-id="47a85-122">これらのコントロールのグループを重視する必要があるか。</span><span class="sxs-lookup"><span data-stu-id="47a85-122">Are there groups of controls with greater importance?</span></span>
  - <span data-ttu-id="47a85-123">重視する場合は、これらのグループにサブグループを含めるかどうか。</span><span class="sxs-lookup"><span data-stu-id="47a85-123">If yes, do those groups contain sub-groups?</span></span>
- <span data-ttu-id="47a85-124">レイアウトではカスタムの方向ナビゲーション (方向キー) とタブ オーダーが必要となるか。</span><span class="sxs-lookup"><span data-stu-id="47a85-124">Does the layout require custom directional navigation (arrow keys) and tab order?</span></span>

<span data-ttu-id="47a85-125">[Engineering Software for Accessibility](https://www.microsoft.com/download/details.aspx?id=19262) eBook (アクセシビリティ ソフトウェアのエンジニアリングに関する eBook) の「*Designing the Logical Hierarchy*」(論理的な階層の設計) の章では、これらのことがわかりやすく説明されています。</span><span class="sxs-lookup"><span data-stu-id="47a85-125">The [Engineering Software for Accessibility](https://www.microsoft.com/download/details.aspx?id=19262) eBook has an excellent chapter on *Designing the Logical Hierarchy*.</span></span>

## <a name="2d-directional-navigation-for-keyboard"></a><span data-ttu-id="47a85-126">キーボードの 2D 方向ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="47a85-126">2D directional navigation for keyboard</span></span>

<span data-ttu-id="47a85-127">コントロールやコントロール グループの 2D 内部ナビゲーション領域のことを、"方向領域" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="47a85-127">The 2D inner navigation region of a control, or control group, is referred to as its "directional area".</span></span> <span data-ttu-id="47a85-128">フォーカがこのオブジェクトに移動すると、キーボードの方向キー (左、右、上、下) を使用して、方向領域内の子要素間を移動することができます。</span><span class="sxs-lookup"><span data-stu-id="47a85-128">When focus shifts to this object, the keyboard arrow keys (left, right, up, and down) can be used to navigate between child elements within the directional area.</span></span>

<span data-ttu-id="47a85-129">![方向性のある領域](images/keyboard/directional-area-small.png)
*2D 内部のナビゲーション領域、またはコントロールのグループの方向の領域*</span><span class="sxs-lookup"><span data-stu-id="47a85-129">![directional area](images/keyboard/directional-area-small.png)
*2D Inner navigation region, or directional area, of a control group*</span></span>

<span data-ttu-id="47a85-130">[XYFocusKeyboardNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_XYFocusKeyboardNavigation) プロパティ (設定できる値は [Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)、[Enabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)、[Disabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)) を使用して、キーボードの方向キーでの 2D 内部ナビゲーションを管理できます。</span><span class="sxs-lookup"><span data-stu-id="47a85-130">You can use the [XYFocusKeyboardNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_XYFocusKeyboardNavigation) property (which has possible values of [Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode), [Enabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode), or [Disabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)) to manage 2D inner navigation with the keyboard arrow keys.</span></span>

> [!NOTE]
> <span data-ttu-id="47a85-131">タブ オーダーは、このプロパティの影響を受けません。</span><span class="sxs-lookup"><span data-stu-id="47a85-131">Tab order is not affected by this property.</span></span> <span data-ttu-id="47a85-132">ナビゲーション エクスペリエンスがわかりにくくならないように、アプリケーションのタブ ナビゲーションの順序では、方向領域の子要素を明示的に*指定しない*ことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47a85-132">To avoid a confusing navigation experience, we recommend that child elements of a directional area *not* be explicitly specified in the tab navigation order of your application.</span></span> <span data-ttu-id="47a85-133">要素のタブ移動動作について詳しくは、[UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) プロパティと [TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) プロパティをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="47a85-133">See the [UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) and [TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) properties for more detail on tabbing behavior for an element.</span></span>

### <a name="autohttpsdocsmicrosoftcomuwpapiwindowsuixamlinputxyfocuskeyboardnavigationmode-default-behavior"></a><span data-ttu-id="47a85-134">[Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode) (既定の動作)</span><span class="sxs-lookup"><span data-stu-id="47a85-134">[Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode) (default behavior)</span></span>

<span data-ttu-id="47a85-135">Auto に設定すると、方向ナビゲーションの動作は要素の先祖 (継承階層) に基づいて決まります。</span><span class="sxs-lookup"><span data-stu-id="47a85-135">When set to Auto, directional navigation behavior is determined by the element’s ancestry, or inheritance hierarchy.</span></span> <span data-ttu-id="47a85-136">すべての先祖が既定のモードになっている場合 (**Auto** に設定されている場合)、キーボードを使用した方向ナビゲーションは*サポートされません*。</span><span class="sxs-lookup"><span data-stu-id="47a85-136">If all ancestors are in default mode (set to **Auto**), directional navigation with the keyboard is *not* supported.</span></span>

### <a name="disabledhttpsdocsmicrosoftcomuwpapiwindowsuixamlinputxyfocuskeyboardnavigationmode"></a>[<span data-ttu-id="47a85-137">無効になっています。</span><span class="sxs-lookup"><span data-stu-id="47a85-137">Disabled</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)

<span data-ttu-id="47a85-138">**XYFocusKeyboardNavigation** を **Disabled** に設定すると、コントロールとその子要素への方向ナビゲーションがブロックされます。</span><span class="sxs-lookup"><span data-stu-id="47a85-138">Set **XYFocusKeyboardNavigation** to **Disabled** to block directional navigation to the control and its child elements.</span></span>

<span data-ttu-id="47a85-139">![XYFocusKeyboardNavigation 動作を無効になっている](images/keyboard/xyfocuskeyboardnav-disabled.gif)
*XYFocusKeyboardNavigation 動作を無効になっています*</span><span class="sxs-lookup"><span data-stu-id="47a85-139">![XYFocusKeyboardNavigation disabled behavior](images/keyboard/xyfocuskeyboardnav-disabled.gif)
*XYFocusKeyboardNavigation disabled behavior*</span></span>

<span data-ttu-id="47a85-140">この例では、プライマリの [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerPrimary) で **XYFocusKeyboardNavigation** が **Enabled** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="47a85-140">In this example, the primary [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerPrimary) has **XYFocusKeyboardNavigation** set to **Enabled**.</span></span> <span data-ttu-id="47a85-141">すべての子要素はこの設定を継承し、方向キーを使用して、これらの子要素への移動が可能になります。</span><span class="sxs-lookup"><span data-stu-id="47a85-141">All child elements inherit this setting, and can be navigated to with the arrow keys.</span></span> <span data-ttu-id="47a85-142">ただし、B3 要素と B4 要素はセカンダリの [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerSecondary) 内にあり、その **XYFocusKeyboardNavigation** が **Disabled** に設定されています。この設定は、プライマリ コンテナーよりも優先され、セカンダリ コンテナー自体への方向キー ナビゲーションとその子要素間の方向キー ナビゲーションは無効になります。</span><span class="sxs-lookup"><span data-stu-id="47a85-142">However, the B3 and B4 elements are in a secondary [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerSecondary) with **XYFocusKeyboardNavigation** set to **Disabled**, which overrides the primary container and disables arrow key navigation to itself and between its child elements.</span></span>

```XAML
<Grid 
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" 
    TabFocusNavigation="Cycle">
    <Grid.RowDefinitions>
        <RowDefinition Height="40"/>
        <RowDefinition Height="75"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <TextBlock Name="KeyPressed"
                Grid.Row="0" 
                FontWeight="ExtraBold" 
                HorizontalTextAlignment="Center"
                TextWrapping="Wrap" 
                Padding="10" />
    <StackPanel Name="ContainerPrimary" 
                XYFocusKeyboardNavigation="Enabled" 
                KeyDown="ContainerPrimary_KeyDown" 
                Orientation="Horizontal" 
                BorderBrush="Green" 
                BorderThickness="2" 
                Grid.Row="1" 
                Padding="10" 
                MaxWidth="200">
        <Button Name="B1" 
                Content="B1" 
                GettingFocus="Btn_GettingFocus" />
        <Button Name="B2" 
                Content="B2" 
                GettingFocus="Btn_GettingFocus" />
        <StackPanel Name="ContainerSecondary" 
                    XYFocusKeyboardNavigation="Disabled" 
                    Orientation="Horizontal" 
                    BorderBrush="Red" 
                    BorderThickness="2">
            <Button Name="B3" 
                    Content="B3" 
                    GettingFocus="Btn_GettingFocus" />
            <Button Name="B4" 
                    Content="B4" 
                    GettingFocus="Btn_GettingFocus" />
        </StackPanel>
    </StackPanel>
</Grid>
```

### <a name="enabledhttpsdocsmicrosoftcomuwpapiwindowsuixamlinputxyfocuskeyboardnavigationmode"></a>[<span data-ttu-id="47a85-143">Enabled</span><span class="sxs-lookup"><span data-stu-id="47a85-143">Enabled</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)

<span data-ttu-id="47a85-144">**XYFocusKeyboardNavigation** を **Enabled** に設定すると、コントロールとその [UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) 子オブジェクトそれぞれへの 2D 方向ナビゲーションがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="47a85-144">Set **XYFocusKeyboardNavigation** to **Enabled** to support 2D directional navigation to a control and each of its [UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) child objects.</span></span>

<span data-ttu-id="47a85-145">設定すると、方向キーを使用したナビゲーションは、方向領域内の要素に限定されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-145">When set, navigation with the arrow keys is restricted to elements within the directional area.</span></span> <span data-ttu-id="47a85-146">タブ ナビゲーションは影響を受けません。これは、すべてのコントロールはタブ オーダー階層を使用してアクセス可能な状態になっているためです。</span><span class="sxs-lookup"><span data-stu-id="47a85-146">Tab navigation is not affected, as all controls remain accessible through their tab order hierarchy.</span></span>

<span data-ttu-id="47a85-147">![XYFocusKeyboardNavigation 動作を有効になっている](images/keyboard/xyfocuskeyboardnav-enabled.gif)
*XYFocusKeyboardNavigation 動作を有効になっています。*</span><span class="sxs-lookup"><span data-stu-id="47a85-147">![XYFocusKeyboardNavigation enabled behavior](images/keyboard/xyfocuskeyboardnav-enabled.gif)
*XYFocusKeyboardNavigation enabled behavior*</span></span>

<span data-ttu-id="47a85-148">この例では、プライマリの [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerPrimary) で **XYFocusKeyboardNavigation** が **Enabled** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="47a85-148">In this example, the primary [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerPrimary) has **XYFocusKeyboardNavigation** set to **Enabled**.</span></span> <span data-ttu-id="47a85-149">すべての子要素はこの設定を継承し、方向キーを使用して、これらの子要素への移動が可能になります。</span><span class="sxs-lookup"><span data-stu-id="47a85-149">All child elements inherit this setting, and can be navigated to with the arrow keys.</span></span> <span data-ttu-id="47a85-150">B3 要素と B4 要素はセカンダリの [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerSecondary) 内にあり、その **XYFocusKeyboardNavigation** は設定されていません。このため、プライマリ コンテナーの設定が継承されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-150">The B3 and B4 elements are in a secondary [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerSecondary) where **XYFocusKeyboardNavigation** is not set, which then inherits the primary container setting.</span></span> <span data-ttu-id="47a85-151">B5 要素は宣言された方向領域内に存在せず、方向キー ナビゲーションをサポートしていませんが、標準的なタブ ナビゲーションの動作はサポートします。</span><span class="sxs-lookup"><span data-stu-id="47a85-151">The B5 element is not within a declared directional area, and does not support arrow key navigation but does support standard tab navigation behavior.</span></span>

```xaml
<Grid
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"
    TabFocusNavigation="Cycle">
    <Grid.RowDefinitions>
        <RowDefinition Height="40"/>
        <RowDefinition Height="100"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <TextBlock Name="KeyPressed"
               Grid.Row="0"
               FontWeight="ExtraBold"
               HorizontalTextAlignment="Center"
               TextWrapping="Wrap"
               Padding="10" />
    <StackPanel Grid.Row="1"
                Orientation="Horizontal"
                HorizontalAlignment="Center">
        <StackPanel Name="ContainerPrimary"
                    XYFocusKeyboardNavigation="Enabled"
                    KeyDown="ContainerPrimary_KeyDown"
                    Orientation="Horizontal"
                    BorderBrush="Green"
                    BorderThickness="2"
                    Padding="5" Margin="5">
            <Button Name="B1"
                    Content="B1"
                    GettingFocus="Btn_GettingFocus" Margin="5" />
            <Button Name="B2"
                    Content="B2"
                    GettingFocus="Btn_GettingFocus" />
            <StackPanel Name="ContainerSecondary"
                        Orientation="Horizontal"
                        BorderBrush="Red"
                        BorderThickness="2"
                        Margin="5">
                <Button Name="B3"
                        Content="B3"
                        GettingFocus="Btn_GettingFocus"
                        Margin="5" />
                <Button Name="B4"
                        Content="B4"
                        GettingFocus="Btn_GettingFocus"
                        Margin="5" />
            </StackPanel>
        </StackPanel>
        <Button Name="B5"
                Content="B5"
                GettingFocus="Btn_GettingFocus"
                Margin="5" />
    </StackPanel>
</Grid>
```

<span data-ttu-id="47a85-152">入れ子になった方向領域を複数レベル設定することができます。</span><span class="sxs-lookup"><span data-stu-id="47a85-152">You can have multiple levels of nested directional areas.</span></span> <span data-ttu-id="47a85-153">すべての親要素の XYFocusKeyboardNavigation が Enabled に設定されている場合、内部ナビゲーション領域の境界は無視されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-153">If all parent elements have XYFocusKeyboardNavigation set to Enabled, inner navigation region boundaries are ignored.</span></span>

<span data-ttu-id="47a85-154">2D 方向ナビゲーションを明示的にサポートしていない要素に含まれる、2 つの入れ子になった方向領域の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="47a85-154">Here's an example of two nested directional areas within an element that does not explicitly support 2D directional navigation.</span></span> <span data-ttu-id="47a85-155">この場合、2 つの入れ子になった領域間の方向ナビゲーションはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="47a85-155">In this case, directional navigation is not supported between the two nested areas.</span></span>

<span data-ttu-id="47a85-156">![XYFocusKeyboardNavigation が有効になっており、動作を入れ子になった](images/keyboard/xyfocuskeyboardnav-enabled-nested1.gif)
*XYFocusKeyboardNavigation が有効になっており、動作を入れ子になった*</span><span class="sxs-lookup"><span data-stu-id="47a85-156">![XYFocusKeyboardNavigation enabled and nested behavior](images/keyboard/xyfocuskeyboardnav-enabled-nested1.gif)
*XYFocusKeyboardNavigation enabled and nested behavior*</span></span>

<span data-ttu-id="47a85-157">3 つの入れ子になった方向領域を使った、より複雑な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="47a85-157">Here’s a more complex example of three nested directional areas where:</span></span>

-   <span data-ttu-id="47a85-158">B1 にフォーカスがある場合は、XYFocusKeyboardNavigation が Disabled に設定されている方向領域の境界が存在し、方向キーによって B2、B3、B4 には移動できないため、B5 にのみ移動できます (B5 から B1 への移動も同様)</span><span class="sxs-lookup"><span data-stu-id="47a85-158">When B1 has focus, only B5 can be navigated to (and vice versa) because there is a directional area boundary where XYFocusKeyboardNavigation set to Disabled, making B2, B3, and B4 unreachable with the arrow keys</span></span>
-   <span data-ttu-id="47a85-159">B2 にフォーカスがある場合は、方向領域の境界によって B1、B4、B5 への方向キー ナビゲーションが禁止されているため、B3 にのみ移動できます (B3 から B2 への移動も同様)。</span><span class="sxs-lookup"><span data-stu-id="47a85-159">When B2 has focus, only B3 can be navigated to (and vice versa) because the directional area boundary prevents arrow key navigation to B1, B4, and B5</span></span>
-   <span data-ttu-id="47a85-160">B4 にフォーカスがある場合は、コントロール間を移動するために Tab キーを使用する必要があります</span><span class="sxs-lookup"><span data-stu-id="47a85-160">When B4 has focus, the Tab key must be used to navigate between controls</span></span>

![XYFocusKeyboardNavigation によって有効になり、複雑な入れ子になった動作](images/keyboard/xyfocuskeyboardnav-enabled-nested2.gif)

<span data-ttu-id="47a85-162">*XYFocusKeyboardNavigation が有効になっており、複雑な動作を入れ子になった*</span><span class="sxs-lookup"><span data-stu-id="47a85-162">*XYFocusKeyboardNavigation enabled and complex nested behavior*</span></span>

## <a name="tab-navigation"></a><span data-ttu-id="47a85-163">タブ ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="47a85-163">Tab navigation</span></span>

<span data-ttu-id="47a85-164">方向キーはコントロールやコントロール グループ内の 2D 方向ナビゲーションで使用できますが、Tab キーを使用すると、UWP アプリケーションのすべてのコントロール間を移動することができます。</span><span class="sxs-lookup"><span data-stu-id="47a85-164">While the arrow keys can be used for 2D directional navigation witin a control, or control group, the Tab key can be used to navigate between all controls in a UWP application.</span></span> 

<span data-ttu-id="47a85-165">すべての対話型のコントロールは、既定で Tab キーによるナビゲーションをサポートしています ([IsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_IsEnabled) プロパティと [IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop) プロパティが **true**)。論理的なタブ オーダーは、アプリケーションのコントロール レイアウトからから派生します。</span><span class="sxs-lookup"><span data-stu-id="47a85-165">All interactive controls support Tab key navigation by default ([IsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_IsEnabled) and [IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop) property are **true**), with the logical tab order derived from the control layout in your application.</span></span> <span data-ttu-id="47a85-166">ただし、既定の順序は表示順序と対応するとは限りません。</span><span class="sxs-lookup"><span data-stu-id="47a85-166">However, the default order does not necessarily correspond to the visual order.</span></span> <span data-ttu-id="47a85-167">実際の表示位置は親レイアウト コンテナーと特定のプロパティに依存し、それらを子要素で設定することでレイアウトに影響することがあります。</span><span class="sxs-lookup"><span data-stu-id="47a85-167">The actual display position might depend on the parent layout container and certain properties that you can set on the child elements to influence the layout.</span></span>

<span data-ttu-id="47a85-168">フォーカスがアプリケーション内をジャンプするようなカスタムのタブ オーダーは使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="47a85-168">Avoid a custom tab order that makes the focus jump around in your application.</span></span> <span data-ttu-id="47a85-169">たとえば、フォーム内のコントロールの一覧には、上から下および左から右へと移動するタブ オーダーが必要です (ロケールによって異なります)。</span><span class="sxs-lookup"><span data-stu-id="47a85-169">For example, a list of controls in a form should have a tab order that flows from top to bottom and left to right (depending on locale).</span></span>

<span data-ttu-id="47a85-170">このセクションでは、アプリに合わせてこのタブ オーダーを完全にカスタマイズする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="47a85-170">In this section we describe how this tab order can be fully customized to suit your app.</span></span>

### <a name="set-the-tab-navigation-behavior"></a><span data-ttu-id="47a85-171">タブ ナビゲーションの動作を設定する</span><span class="sxs-lookup"><span data-stu-id="47a85-171">Set the tab navigation behavior</span></span>

<span data-ttu-id="47a85-172">[UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) の [TabFocusNavigation](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_TabFocusNavigation) プロパティは、オブジェクト ツリー全体 (または方向領域) のタブ ナビゲーションの動作を指定します。</span><span class="sxs-lookup"><span data-stu-id="47a85-172">The [TabFocusNavigation](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_TabFocusNavigation) property of [UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) specifies the tab navigation behavior for its entire object tree (or directional area).</span></span>

> [!NOTE]
> <span data-ttu-id="47a85-173">[ControlTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate) を使わないオブジェクトに対して [Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation) プロパティの代わりにこのプロパティを使用して、それらのオブジェクトの外観を定義します。</span><span class="sxs-lookup"><span data-stu-id="47a85-173">Use this property instead of the [Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation) property for objects that do not use a [ControlTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate) to define their appearance.</span></span>

<span data-ttu-id="47a85-174">前のセクションで説明したように、ナビゲーション エクスペリエンスがわかりにくくならないように、アプリケーションのタブ ナビゲーションの順序では、方向領域の子要素を明示的に*指定しない*ことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47a85-174">As we mentioned in the previous section, to avoid a confusing navigation experience, we recommend that child elements of a directional area *not* be explicitly specified in the tab navigation order of your application.</span></span> <span data-ttu-id="47a85-175">要素のタブ移動動作について詳しくは、[UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) プロパティと [TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) プロパティをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="47a85-175">See the [UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) and the [TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) properties for more detail on tabbing behavior for an element.</span></span>   
> <span data-ttu-id="47a85-176">Windows 10 Creators Update (ビルド 10.0.15063) より前のバージョンでは、タブ設定は [ControlTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate) オブジェクトに制限されていました。</span><span class="sxs-lookup"><span data-stu-id="47a85-176">For versions older than Windows 10 Creators Update (build 10.0.15063), tab settings were limited to [ControlTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate) objects.</span></span> <span data-ttu-id="47a85-177">詳しくは、[Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="47a85-177">For more info, see [Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation).</span></span>

<span data-ttu-id="47a85-178">[TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) は、[KeyboardNavigationMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardnavigationmode) 型の値を保持します。設定できる値は次のとおりです (以下の例はカスタム コントロール グループではありません。また、方向キーでの内部ナビゲーションを必要としていません)。</span><span class="sxs-lookup"><span data-stu-id="47a85-178">[TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) has a value of type [KeyboardNavigationMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardnavigationmode) with the following possible values (note that these examples are not custom control groups and do not require inner navigation with the arrow keys):</span></span>

- <span data-ttu-id="47a85-179">**Local** (既定)</span><span class="sxs-lookup"><span data-stu-id="47a85-179">**Local** (default)</span></span>   
  <span data-ttu-id="47a85-180">タブ インデックスは、コンテナー内のローカル サブツリーで認識されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-180">Tab indexes are recognized on the local subtree inside the container.</span></span> <span data-ttu-id="47a85-181">この例では、タブ オーダーは B1、B2、B3、B4、B5、B6、B7、B1 です。</span><span class="sxs-lookup"><span data-stu-id="47a85-181">For this example, the tab order is B1, B2, B3, B4, B5, B6, B7, B1.</span></span>

   !["Local" タブ ナビゲーションの動作](images/keyboard/tabnav-local.gif)

   <span data-ttu-id="47a85-183">*「ローカル」タブ ナビゲーションの動作*</span><span class="sxs-lookup"><span data-stu-id="47a85-183">*"Local" tab navigation behavior*</span></span>

- <span data-ttu-id="47a85-184">**ある時**</span><span class="sxs-lookup"><span data-stu-id="47a85-184">**Once**</span></span>  
  <span data-ttu-id="47a85-185">コンテナーとすべての子要素は、フォーカスを 1 回だけ受け取ります。</span><span class="sxs-lookup"><span data-stu-id="47a85-185">The container and all child elements receive focus once.</span></span> <span data-ttu-id="47a85-186">この例では、タブ オーダーは B1、B2、B7、B1 です (方向キーによる内部ナビゲーションも示されています)。</span><span class="sxs-lookup"><span data-stu-id="47a85-186">For this example, the tab order is B1, B2, B7, B1 (inner navigation with arrow key is also demonstrated).</span></span>

   !["Once" タブ ナビゲーションの動作](images/keyboard/tabnav-once.gif)

   <span data-ttu-id="47a85-188">*ナビゲーションの動作を「1 回」タブします。*</span><span class="sxs-lookup"><span data-stu-id="47a85-188">*"Once" tab navigation behavior*</span></span>

- <span data-ttu-id="47a85-189">**サイクル** </span><span class="sxs-lookup"><span data-stu-id="47a85-189">**Cycle** </span></span>  
  <span data-ttu-id="47a85-190">フォーカスは循環して、コンテナー内のフォーカス可能な最初の要素に戻ります。</span><span class="sxs-lookup"><span data-stu-id="47a85-190">Focus cycles back to the initial focusable element inside a container.</span></span> <span data-ttu-id="47a85-191">この例では、タブ オーダーは B1、B2、B3、B4、B5、B6、B2... です。</span><span class="sxs-lookup"><span data-stu-id="47a85-191">For this example, the tab order is B1, B2, B3, B4, B5, B6, B2...</span></span>

   !["Cycle" タブ ナビゲーションの動作](images/keyboard/tabnav-cycle.gif)

   <span data-ttu-id="47a85-193">*タブ ナビゲーションの動作を「循環」*</span><span class="sxs-lookup"><span data-stu-id="47a85-193">*"Cycle" tab navigation behavior*</span></span>

<span data-ttu-id="47a85-194">上記の例で使用されるコードを次に示します (TabFocusNavigation ="Cycle")。</span><span class="sxs-lookup"><span data-stu-id="47a85-194">Here's the code for the preceding examples (with TabFocusNavigation ="Cycle").</span></span>

```XAML
<Grid 
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" 
    TabFocusNavigation="Cycle">
    <Grid.RowDefinitions>
        <RowDefinition Height="40"/>
        <RowDefinition Height="300"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <TextBlock Name="KeyPressed"
               Grid.Row="0" 
               FontWeight="ExtraBold" 
               HorizontalTextAlignment="Center"
               TextWrapping="Wrap" 
               Padding="10" />
    <StackPanel Name="ContainerPrimary"
                KeyDown="Container_KeyDown" 
                Orientation="Horizontal" 
                HorizontalAlignment="Center"
                BorderBrush="Green" 
                BorderThickness="2" 
                Grid.Row="1" 
                Padding="10" 
                MaxWidth="200">
        <Button Name="B1" 
                Content="B1" 
                GettingFocus="Btn_GettingFocus" 
                Margin="5"/>
        <StackPanel Name="ContainerSecondary" 
                    KeyDown="Container_KeyDown"
                    XYFocusKeyboardNavigation="Enabled" 
                    TabFocusNavigation ="Cycle"
                    Orientation="Vertical" 
                    VerticalAlignment="Center"
                    BorderBrush="Red" 
                    BorderThickness="2"
                    Padding="5" Margin="5">
            <Button Name="B2" 
                    Content="B2" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
            <Button Name="B3" 
                    Content="B3" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
            <Button Name="B4" 
                    Content="B4" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
            <Button Name="B5" 
                    Content="B5" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
            <Button Name="B6" 
                    Content="B6" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
        </StackPanel>
        <Button Name="B7" 
                Content="B7" 
                GettingFocus="Btn_GettingFocus" 
                Margin="5"/>
    </StackPanel>
</Grid>
```

### <a name="tabindexhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscontrolwindowsuixamlcontrolscontroltabindex"></a>[<span data-ttu-id="47a85-195">TabIndex</span><span class="sxs-lookup"><span data-stu-id="47a85-195">TabIndex</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex)

<span data-ttu-id="47a85-196">[TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) を使用して、ユーザーが Tab キーを使用してコントロール間を移動するときに要素がフォーカスを受け取る順序を指定します。</span><span class="sxs-lookup"><span data-stu-id="47a85-196">Use [TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) to specify the order in which elements receive focus when the user navigates through controls using the Tab key.</span></span> <span data-ttu-id="47a85-197">小さい値のタブ インデックスを持つコントロールは、より大きい値のインデックスを持つコントロールより前にフォーカスを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="47a85-197">A control with a lower tab index receives focus before a control with a higher index.</span></span>

<span data-ttu-id="47a85-198">コントロールに [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) が指定されていない場合、スコープに基づいて、ビジュアル ツリーにあるすべての対話型のコントロールで現在最大の値を持つインデックス (および優先順位が最も低いインデックス) よりも大きなインデックス値が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="47a85-198">When a control has no [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) specified, it is assigned a higher index value than the current highest index value (and the lowest priority) of all interactive controls in the visual tree, based on scope.</span></span> 

<span data-ttu-id="47a85-199">コントロールのすべての子要素がスコープと見なされます。また、こうしたスコープの要素のいずれか 1 つにさらに子要素がある場合、それらの子要素は別のスコープと見なされます。</span><span class="sxs-lookup"><span data-stu-id="47a85-199">All child elements of a control are considered a scope, and if one of these elements also has child elements, they are considered another scope.</span></span> <span data-ttu-id="47a85-200">スコープのビジュアル ツリーにある最初の要素を選ぶことにより、あいまいさが解決されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-200">Any ambiguity is resolved by choosing the first element on the visual tree of the scope.</span></span> 

<span data-ttu-id="47a85-201">タブ オーダーからコントロールを除外するには、[IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="47a85-201">To exclude a control from the tab order, set the [IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop) property to **false**.</span></span>

<span data-ttu-id="47a85-202">[TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) プロパティを設定することで、既定のタブ オーダーを上書きできます。</span><span class="sxs-lookup"><span data-stu-id="47a85-202">Override the default tab order by setting the [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) property.</span></span>

> [!NOTE] 
> <span data-ttu-id="47a85-203">[TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) は、[UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) および [Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation) と同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="47a85-203">[TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) works the same way with both [UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) and [Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation).</span></span>


<span data-ttu-id="47a85-204">フォーカス ナビゲーションが特定の要素の [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) プロパティによってどのような影響を受けるかを次に示します。</span><span class="sxs-lookup"><span data-stu-id="47a85-204">Here, we show how focus navigation can be affected by the [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) property on specific elements.</span></span> 

![TabIndex を使用した "Local" タブ ナビゲーションの動作](images/keyboard/tabnav-tabindex.gif)

<span data-ttu-id="47a85-206">*「ローカル」タブ TabIndex 動作によるナビゲーション*</span><span class="sxs-lookup"><span data-stu-id="47a85-206">*"Local" tab navigation with TabIndex behavior*</span></span>

<span data-ttu-id="47a85-207">前の例では、次の 2 つのスコープがあります。</span><span class="sxs-lookup"><span data-stu-id="47a85-207">In the preceding example, there are two scopes:</span></span> 
- <span data-ttu-id="47a85-208">B1、方向領域 (B2 - B6)、B7</span><span class="sxs-lookup"><span data-stu-id="47a85-208">B1, directional area (B2 - B6), and B7</span></span>
- <span data-ttu-id="47a85-209">方向領域 (B2 - B6)</span><span class="sxs-lookup"><span data-stu-id="47a85-209">directional area (B2 - B6)</span></span>

<span data-ttu-id="47a85-210">B3 (方向領域内) がフォーカスを取得すると、スコープが変更され、タブ ナビゲーションが方向領域に移動します。この方向領域では、後続のフォーカスについて最適な候補が指定されています。</span><span class="sxs-lookup"><span data-stu-id="47a85-210">When B3 (in the directional area) gets focus, the scope changes and tab navigation transfers to the directional area where the best candidate for subsequent focus is identified.</span></span> <span data-ttu-id="47a85-211">この場合、B2 の後に B4、B5、B6 が続きます。</span><span class="sxs-lookup"><span data-stu-id="47a85-211">In this case, B2 followed by B4, B5, and B6.</span></span> <span data-ttu-id="47a85-212">その後で、スコープがもう一度変更され、フォーカスが B1 に移動します。</span><span class="sxs-lookup"><span data-stu-id="47a85-212">Scope then changes again, and focus moves to B1.</span></span>

<span data-ttu-id="47a85-213">この例のコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="47a85-213">Here's the code for this example.</span></span>

```xaml
<Grid
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"
    TabFocusNavigation="Cycle">
    <Grid.RowDefinitions>
        <RowDefinition Height="40"/>
        <RowDefinition Height="300"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <TextBlock Name="KeyPressed"
               Grid.Row="0"
               FontWeight="ExtraBold"
               HorizontalTextAlignment="Center"
               TextWrapping="Wrap"
               Padding="10" />
    <StackPanel Name="ContainerPrimary"
                KeyDown="Container_KeyDown"
                Orientation="Horizontal"
                HorizontalAlignment="Center"
                BorderBrush="Green"
                BorderThickness="2"
                Grid.Row="1"
                Padding="10"
                MaxWidth="200">
        <Button Name="B1"
                Content="B1"
                TabIndex="1"
                ToolTipService.ToolTip="TabIndex = 1"
                GettingFocus="Btn_GettingFocus"
                Margin="5"/>
        <StackPanel Name="ContainerSecondary"
                    KeyDown="Container_KeyDown"
                    TabFocusNavigation ="Local"
                    Orientation="Vertical"
                    VerticalAlignment="Center"
                    BorderBrush="Red"
                    BorderThickness="2"
                    Padding="5" Margin="5">
            <Button Name="B2"
                    Content="B2"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
            <Button Name="B3"
                    Content="B3"
                    TabIndex="3"
                    ToolTipService.ToolTip="TabIndex = 3"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
            <Button Name="B4"
                    Content="B4"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
            <Button Name="B5"
                    Content="B5"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
            <Button Name="B6"
                    Content="B6"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
        </StackPanel>
        <Button Name="B7"
                Content="B7"
                TabIndex="2"
                ToolTipService.ToolTip="TabIndex = 2"
                GettingFocus="Btn_GettingFocus"
                Margin="5"/>
    </StackPanel>
</Grid>
```

## <a name="2d-directional-navigation-for-keyboard-gamepad-and-remote-control"></a><span data-ttu-id="47a85-214">キーボード、ゲームパッド、リモコンの 2D 方向ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="47a85-214">2D directional navigation for keyboard, gamepad, and remote control</span></span>

<span data-ttu-id="47a85-215">非ポインターの入力タイプ (キーボード、ゲームパッド、リモコン、および Windows ナレーターなどのアクセシビリティ ツール) では、UWP アプリケーションの UI 間を移動したり、これらの UI を操作したりするための、一般的で基本的なメカニズムを共有します。</span><span class="sxs-lookup"><span data-stu-id="47a85-215">Non-pointer input types such as keyboard, gamepad, remote control, and accessibility tools like Windows Narrator, share a common, underlying mechanism for navigating and interacting with the UI of your UWP application.</span></span>

<span data-ttu-id="47a85-216">このセクションでは、お勧めのナビゲーション方法をどのように指定するかについて説明します。また、フォーカス ベースである非ポインターの入力タイプすべてをサポートする一連のナビゲーション方法のプロパティを使用して、アプリケーション内でのフォーカス ナビゲーションを細かく調整する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="47a85-216">In this section, we cover how to specify a preferred navigation strategy and fine tune focus navigation within your application through a set of navigation strategy properties that support all focus-based, non-pointer input types.</span></span>

<span data-ttu-id="47a85-217">Xbox/TV のアプリおよびエクスペリエンスの構築に一般的な情報は、次を参照してください[キーボードの相互作用](keyboard-interactions.md)、 [Xbox やテレビの設計](../devices/designing-for-tv.md)、および[ゲームパッド、リモート_コントロールの相互作用](gamepad-and-remote-interactions.md).</span><span class="sxs-lookup"><span data-stu-id="47a85-217">For more general information on building apps and experiences for Xbox/TV, see [Keyboard Interaction](keyboard-interactions.md), [Designing for Xbox and TV](../devices/designing-for-tv.md), and [Gamepad and remote control interactions](gamepad-and-remote-interactions.md).</span></span>

### <a name="navigation-strategies"></a><span data-ttu-id="47a85-218">ナビゲーション方法</span><span class="sxs-lookup"><span data-stu-id="47a85-218">Navigation Strategies</span></span>

> <span data-ttu-id="47a85-219">ナビゲーション方法は、キーボード、ゲームパッド、リモコン、およびさまざまなアクセシビリティ ツールに適用できます。</span><span class="sxs-lookup"><span data-stu-id="47a85-219">Navigation strategies are applicable to keyboard, gamepad, remote control, and various accessibility tools.</span></span>

<span data-ttu-id="47a85-220">次のナビゲーション方法のプロパティを使用すると、方向キーや方向パッド (D パッド) ボタン、または類似した押下操作に基づいて、どのコンピューターがフォーカスを受け取るかを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="47a85-220">The following navigation strategy properties let you influence which control receives focus based on the arrow key, directional pad (D-pad) button, or similar pressed.</span></span> 

-   <span data-ttu-id="47a85-221">XYFocusUpNavigationStrategy</span><span class="sxs-lookup"><span data-stu-id="47a85-221">XYFocusUpNavigationStrategy</span></span>
-   <span data-ttu-id="47a85-222">XYFocusDownNavigationStrategy</span><span class="sxs-lookup"><span data-stu-id="47a85-222">XYFocusDownNavigationStrategy</span></span>
-   <span data-ttu-id="47a85-223">XYFocusLeftNavigationStrategy</span><span class="sxs-lookup"><span data-stu-id="47a85-223">XYFocusLeftNavigationStrategy</span></span>
-   <span data-ttu-id="47a85-224">XYFocusRightNavigationStrategy</span><span class="sxs-lookup"><span data-stu-id="47a85-224">XYFocusRightNavigationStrategy</span></span>

<span data-ttu-id="47a85-225">これらのプロパティに設定できる値は、[Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy) (既定)、[NavigationDirectionDistance](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy)、[Projection](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy)、[RectilinearDistance ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy) です。</span><span class="sxs-lookup"><span data-stu-id="47a85-225">These properties have possible values of [Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy) (default), [NavigationDirectionDistance](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy), [Projection](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy), or [RectilinearDistance ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy).</span></span>

<span data-ttu-id="47a85-226">**Auto** に設定された場合、要素の動作は要素の先祖に基づいて決まります。</span><span class="sxs-lookup"><span data-stu-id="47a85-226">If set to **Auto**, the behavior of the element is based on the ancestors of the element.</span></span> <span data-ttu-id="47a85-227">すべての要素が **Auto** に設定されている場合、**Projection** が使用されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-227">If all elements are set to **Auto**, **Projection** is used.</span></span>

> [!NOTE]
> <span data-ttu-id="47a85-228">前にフォーカスがあった要素やナビゲーション方向の軸までの近さなど、その他の要因により、結果が影響を受ける場合があります。</span><span class="sxs-lookup"><span data-stu-id="47a85-228">Other factors, such as the previously focused element or proximity to the axis of the navigation direction, can influence the result.</span></span>

### <a name="projection"></a><span data-ttu-id="47a85-229">Projection</span><span class="sxs-lookup"><span data-stu-id="47a85-229">Projection</span></span>

<span data-ttu-id="47a85-230">Projection 方法を使うと、現在フォーカスがある要素の端をナビゲーションの方向に*投影*するときに接触した最初の要素にフォーカスが移動します。</span><span class="sxs-lookup"><span data-stu-id="47a85-230">The Projection strategy moves focus to the first element encountered when the edge of the currently focused element is *projected* in the direction of navigation.</span></span>

<span data-ttu-id="47a85-231">この例では、各フォーカス ナビゲーションの方向は Projection に設定されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-231">In this example, each focus navigation direction is set to Projection.</span></span> <span data-ttu-id="47a85-232">フォーカスが B3 をバイパスして、B1 から B4 にどのように移動するかについて注意してください。</span><span class="sxs-lookup"><span data-stu-id="47a85-232">Notice how focus moves down from B1 to B4, bypassing B3.</span></span> <span data-ttu-id="47a85-233">こうした移動は、B3 が射影ゾーンにないことが原因です。</span><span class="sxs-lookup"><span data-stu-id="47a85-233">This is because, B3 is not in the projection zone.</span></span> <span data-ttu-id="47a85-234">また、B1 から左に移動するときに、フォーカス候補がどうして識別されないのかについても注意してください。</span><span class="sxs-lookup"><span data-stu-id="47a85-234">Also notice how a focus candidate is not identified when moving left from B1.</span></span> <span data-ttu-id="47a85-235">これは、B1 に対する B2 の相対的な位置によって、B3 が候補から除外されるためです。</span><span class="sxs-lookup"><span data-stu-id="47a85-235">This is because the position of B2 relative to B1 eliminates B3 as a candidate.</span></span> <span data-ttu-id="47a85-236">B3 が B2 と同じ行にあれば、B3 は左側へのナビゲーションに対して有効な候補となります。</span><span class="sxs-lookup"><span data-stu-id="47a85-236">If B3 was in the same row as B2, it would be a viable candidate for left navigation.</span></span> <span data-ttu-id="47a85-237">B2 のナビゲーション方向の軸までの近さには遮るものがないため、B2 は有効な候補となります。</span><span class="sxs-lookup"><span data-stu-id="47a85-237">B2 is a viable candidate due to its unobstructed proximity to the axis of navigation direction.</span></span>

![Projection によるナビゲーション方法](images/keyboard/xyfocusnavigationstrategy-projection.gif)

<span data-ttu-id="47a85-239">*プロジェクション ナビゲーション戦略*</span><span class="sxs-lookup"><span data-stu-id="47a85-239">*Projection navigation strategy*</span></span>

### <a name="navigationdirectiondistance"></a><span data-ttu-id="47a85-240">NavigationDirectionDistance</span><span class="sxs-lookup"><span data-stu-id="47a85-240">NavigationDirectionDistance</span></span>

<span data-ttu-id="47a85-241">NavigationDirectionDistance 方法では、ナビゲーション方向の軸に最も近い要素にフォーカスが移動します。</span><span class="sxs-lookup"><span data-stu-id="47a85-241">The NavigationDirectionDistance strategy moves focus to the element closest to the axis of the navigation direction.</span></span>

<span data-ttu-id="47a85-242">ナビゲーション方向に対応する境界の四角形の端が*拡張*され、*投影*されて、ターゲットとなる候補が識別されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-242">The edge of the bounding rect corresponding to the navigation direction is *extended* and *projected* to identify candidate targets.</span></span> <span data-ttu-id="47a85-243">最初に接触した要素がターゲットとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-243">The first element encountered is identified as the target.</span></span> <span data-ttu-id="47a85-244">複数の候補がある場合は、最も近い要素がターゲットとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-244">In the case of multiple candidates, the closest element is identified as the target.</span></span> <span data-ttu-id="47a85-245">さらに複数の候補がある場合には、最も上で最も左の要素が候補として識別されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-245">If there are still multiple candidates, the topmost/leftmost element is identified as the candidate.</span></span>

![NavigationDirectionDistance によるナビゲーション方法](images/keyboard/xyfocusnavigationstrategy-navigationdirectiondistance.gif)

<span data-ttu-id="47a85-247">*NavigationDirectionDistance ナビゲーション戦略*</span><span class="sxs-lookup"><span data-stu-id="47a85-247">*NavigationDirectionDistance navigation strategy*</span></span>

### <a name="rectilineardistance"></a><span data-ttu-id="47a85-248">RectilinearDistance</span><span class="sxs-lookup"><span data-stu-id="47a85-248">RectilinearDistance</span></span>

<span data-ttu-id="47a85-249">RectilinearDistance 方法では、2D 直線距離に基づいて最も近い要素にフォーカスが移動します ([タクシー幾何学](https://en.wikipedia.org/wiki/Taxicab_geometry))。</span><span class="sxs-lookup"><span data-stu-id="47a85-249">The RectilinearDistance strategy moves focus to the closest element based on 2D rectilinear distance ([Taxicab geometry](https://en.wikipedia.org/wiki/Taxicab_geometry)).</span></span>

<span data-ttu-id="47a85-250">潜在的な各候補までのプライマリ距離とセカンダリ距離を加算することによって、最適な候補が識別されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-250">The sum of the primary distance and the secondary distance to each potential candidate is used to identify the best candidtate.</span></span> <span data-ttu-id="47a85-251">TIE では、要求された方向が上または下の場合は左方向の最初の要素が選択され、要求された方向が左または右の場合は上方向の最初の要素が選択されます。</span><span class="sxs-lookup"><span data-stu-id="47a85-251">In a tie, the first element to the left is selected if the requested direction is up or down, and the first element to the top is selected if the requested direction is left or right.</span></span>

![RectilinearDistance によるナビゲーション方法](images/keyboard/xyfocusnavigationstrategy-rectilineardistance.gif)

<span data-ttu-id="47a85-253">*RectilinearDistance ナビゲーション戦略*</span><span class="sxs-lookup"><span data-stu-id="47a85-253">*RectilinearDistance navigation strategy*</span></span>

<span data-ttu-id="47a85-254">この画像は、B1 にフォーカスがあり、要求された方向が下の場合に、B3 がどのようにして RectilinearDistance のフォーカス候補となるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="47a85-254">This image shows how, when B1 has focus and down is the requested direction, B3 is the RectilinearDistance focus candidate.</span></span> <span data-ttu-id="47a85-255">これは、この例における次の計算に基づいています。</span><span class="sxs-lookup"><span data-stu-id="47a85-255">This is based on the following calcualations for this example:</span></span>
-   <span data-ttu-id="47a85-256">距離 (B1、B3、下) は 10 + 0 = 10</span><span class="sxs-lookup"><span data-stu-id="47a85-256">Distance (B1, B3, Down) is 10 + 0 = 10</span></span>
-   <span data-ttu-id="47a85-257">距離 (B1、B2、下) は 0 + 40 = 30</span><span class="sxs-lookup"><span data-stu-id="47a85-257">Distance (B1, B2, Down) is 0 + 40 = 30</span></span>
-   <span data-ttu-id="47a85-258">距離 (B1、D、下) は 30 + 0 = 30</span><span class="sxs-lookup"><span data-stu-id="47a85-258">Distance (B1, D, Down) is 30 + 0 = 30</span></span>


## <a name="related-articles"></a><span data-ttu-id="47a85-259">関連記事</span><span class="sxs-lookup"><span data-stu-id="47a85-259">Related articles</span></span>
- [<span data-ttu-id="47a85-260">プログラムによるフォーカスのナビゲーション</span><span class="sxs-lookup"><span data-stu-id="47a85-260">Programmatic focus navigation</span></span>](focus-navigation-programmatic.md)
- [<span data-ttu-id="47a85-261">キーボードの相互作用</span><span class="sxs-lookup"><span data-stu-id="47a85-261">Keyboard interactions</span></span>](keyboard-interactions.md)
- [<span data-ttu-id="47a85-262">キーボードのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="47a85-262">Keyboard accessibility</span></span>](../accessibility/keyboard-accessibility.md) 



