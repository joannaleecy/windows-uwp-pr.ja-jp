---
Description: キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に考えられる最適なエクスペリエンスを提供できるように、UWP アプリを最適化する方法について説明します。
title: キーボード操作
ms.assetid: FF819BAC-67C0-4EC9-8921-F087BE188138
label: Keyboard interactions
template: detail.hbs
keywords: キーボード, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作, ゲームパッド, リモート
ms.date: 03/29/2017
ms.topic: article
pm-contact: chigy
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.openlocfilehash: e3fcf6b792990fad9cb0071aece878cac31f5420
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662917"
---
# <a name="keyboard-interactions"></a><span data-ttu-id="625a5-104">キーボード操作</span><span class="sxs-lookup"><span data-stu-id="625a5-104">Keyboard interactions</span></span>

![キーボードのヒーロー画像](images/keyboard/keyboard-hero.jpg)

<span data-ttu-id="625a5-106">キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に考えられる最適なエクスペリエンスを提供できるように、UWP アプリを最適化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="625a5-106">Learn how to design and optimize your UWP apps so they provide the best experience possible for both keyboard power users and those with disabilities and other accessibility requirements.</span></span>

<span data-ttu-id="625a5-107">さまざまなデバイスを使う場合、キーボード入力はユニバーサル Windows プラットフォーム (UWP) の全体的な対話式操作エクスペリエンスの重要な部分を占めます。</span><span class="sxs-lookup"><span data-stu-id="625a5-107">Across devices, keyboard input is an important part of the overall Universal Windows Platform (UWP) interaction experience.</span></span> <span data-ttu-id="625a5-108">適切に設計されたキーボード エクスペリエンスがあれば、ユーザーが効率的にアプリの UI を移動し、手を持ち上げなくてもそのすべての機能にキーボードからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="625a5-108">A well-designed keyboard experience lets users efficiently navigate the UI of your app and access its full functionality without ever lifting their hands from the keyboard.</span></span>

![キーボードとゲームパッドのイメージ](images/keyboard/keyboard-gamepad.jpg)

<span data-ttu-id="625a5-110">***一般的な相互作用のパターンは、キーボード、ゲームパッドの間で共有されます。***</span><span class="sxs-lookup"><span data-stu-id="625a5-110">***Common interaction patterns are shared between keyboard and gamepad***</span></span>

<span data-ttu-id="625a5-111">このトピックでは、PC におけるキーボード入力の UWP アプリの設計について重点的に説明します。</span><span class="sxs-lookup"><span data-stu-id="625a5-111">In this topic, we focus specifically on UWP app design for keyboard input on PCs.</span></span> <span data-ttu-id="625a5-112">ただし、適切に設計されたキーボード エクスペリエンスは、Windows ナレーターなどのユーザー補助ツールをサポートするための重要なを使用して[ソフトウェア キーボード](#software-keyboard)タッチ キーボードやスクリーン キーボード (OSK)、およびその他の処理Xbox ゲームパッド、リモート制御など、デバイスの種類を入力します。</span><span class="sxs-lookup"><span data-stu-id="625a5-112">However, a well-designed keyboard experience is important for supporting accessibility tools such as Windows Narrator, using [software keyboards](#software-keyboard) such as the touch keyboard and the On-Screen Keyboard (OSK), and for handling other input device types, such as the Xbox gamepad and remote control.</span></span>

<span data-ttu-id="625a5-113">[フォーカスの視覚効果](#focus-visuals)、[アクセス キー](#access-keys)、[UI ナビゲーション](#navigation) など、ここで説明するガイドラインと推奨事項の多くは、これらの他のシナリオにも当てはまります。</span><span class="sxs-lookup"><span data-stu-id="625a5-113">Many of the guidelines and recommendations discussed here, including [focus visuals](#focus-visuals), [access keys](#access-keys), and [UI navigation](#navigation), are also applicable to these other scenarios.</span></span>

<span data-ttu-id="625a5-114">**注:**  テキスト入力はハードウェア キーボードとソフトウェア キーボードの両方に使用されますが、このトピックではナビゲーションと対話式操作に焦点を当てます。</span><span class="sxs-lookup"><span data-stu-id="625a5-114">**NOTE**  While both hardware and software keyboards are used for text input, the focus of this topic is navigation and interaction.</span></span>

## <a name="built-in-support"></a><span data-ttu-id="625a5-115">組み込みサポート</span><span class="sxs-lookup"><span data-stu-id="625a5-115">Built-in support</span></span>

<span data-ttu-id="625a5-116">マウスと共に、キーボードは PC で最もよく使われている周辺機器であるため、PC のエクスペリエンスの基本となる部分です。</span><span class="sxs-lookup"><span data-stu-id="625a5-116">Along with the mouse, the keyboard is the most widely used peripheral on PCs and, as such, is a fundamental part of the PC experience.</span></span> <span data-ttu-id="625a5-117">PC ユーザーは、キーボード入力への応答として、システムと個々のアプリの両方から総合的で一貫性のあるエクスペリエンスがあることを期待します。</span><span class="sxs-lookup"><span data-stu-id="625a5-117">PC users expect a comprehensive and consistent experience from both the system and individual apps in response to keyboard input.</span></span>

<span data-ttu-id="625a5-118">すべての UWP コントロールには、キーボードの豊富なエクスペリエンスとユーザー操作の組み込みサポートが含まれていますが、プラットフォーム自体にはカスタム コントロールとアプリの両方で最適と感じるキーボード エクスペリエンスを生み出すための広範な基盤が用意されています。</span><span class="sxs-lookup"><span data-stu-id="625a5-118">All UWP controls include built-in support for rich keyboard experiences and user interactions, while the platform itself provides an extensive foundation for creating keyboard experiences that you feel are best suited to both your custom controls and apps.</span></span>

![キーボードと携帯電話の画像](images/keyboard/keyboard-phone.jpg)

<span data-ttu-id="625a5-120">***UWP は、任意のデバイスでのキーボードをサポートしています***</span><span class="sxs-lookup"><span data-stu-id="625a5-120">***UWP supports keyboard with any device***</span></span>

## <a name="basic-experiences"></a><span data-ttu-id="625a5-121">基本的なエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="625a5-121">Basic experiences</span></span>
![フォーカス ベースのデバイス](images/keyboard/focus-based-devices.jpg)

<span data-ttu-id="625a5-123">前述のように、Xbox ゲームパッドやリモコンなどの入力デバイスと、ナレーターなどのアクセシビリティ ツールは、ナビゲーションとコマンド実行においてキーボードの入力エクスペリエンスの大半を共有します。</span><span class="sxs-lookup"><span data-stu-id="625a5-123">As mentioned previously, input devices such as the Xbox gamepad and remote control, and accessibility tools such as Narrator, share much of the keyboard input experience for navigation and commanding.</span></span> <span data-ttu-id="625a5-124">入力の種類とツールが異なってもエクスペリエンスが共通であれば、ユーザーの追加作業は最小限に抑えられ、ユニバーサル Windows プラットフォームの "1 回のビルドで、どこでも実行可能" という目標に貢献します。</span><span class="sxs-lookup"><span data-stu-id="625a5-124">This common experience across input types and tools minimizes additional work from you and contributes to the "build once, run anywhere" goal of the Universal Windows Platform.</span></span>

<span data-ttu-id="625a5-125">必要に応じて、する必要がありますに注意してくださいし、検討する必要があります、軽減策について説明します主な相違点を特定します。</span><span class="sxs-lookup"><span data-stu-id="625a5-125">Where necessary, we'll identify key differences you should be aware of and describe any mitigations you should consider.</span></span>

<span data-ttu-id="625a5-126">このトピックで説明するデバイスとツールを次に示します。</span><span class="sxs-lookup"><span data-stu-id="625a5-126">Here are the devices and tools discussed in this topic:</span></span>

| <span data-ttu-id="625a5-127">デバイス/ツール</span><span class="sxs-lookup"><span data-stu-id="625a5-127">Device/tool</span></span>                       | <span data-ttu-id="625a5-128">説明</span><span class="sxs-lookup"><span data-stu-id="625a5-128">Description</span></span>     |
|-----------------------------------|-----------------|
|<span data-ttu-id="625a5-129">キーボード (ハードウェアおよびソフトウェア)</span><span class="sxs-lookup"><span data-stu-id="625a5-129">Keyboard (hardware and software)</span></span>   |<span data-ttu-id="625a5-130">UWP アプリケーションが 2 つのソフトウェアのキーボードをサポートするだけでなく、標準のハードウェア キーボード:[タッチ (またはソフトウェア) のキーボード](#software-keyboard)と[スクリーン キーボード](#on-screen-keyboard)します。</span><span class="sxs-lookup"><span data-stu-id="625a5-130">In addition to the standard hardware keyboard, UWP applications support two software keyboards: the [touch (or software) keyboard](#software-keyboard) and the [On-Screen Keyboard](#on-screen-keyboard).</span></span>|
|<span data-ttu-id="625a5-131">ゲームパッドとリモート制御</span><span class="sxs-lookup"><span data-stu-id="625a5-131">Gamepad and remote control</span></span>         |<span data-ttu-id="625a5-132">Xbox のゲームパッドとリモコンは、[10 フィート エクスペリエンス](../devices/designing-for-tv.md)における基本的な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="625a5-132">The Xbox gamepad and remote control are fundamental input devices in the [10-foot experience](../devices/designing-for-tv.md).</span></span> <span data-ttu-id="625a5-133">UWP におけるゲームパッドとリモコンのサポートについて詳しくは、「[ゲームパッドとリモコンの操作](gamepad-and-remote-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="625a5-133">For specific details on UWP support for gamepad and remote control, see [Gamepad and remote control interactions](gamepad-and-remote-interactions.md).</span></span>|
|<span data-ttu-id="625a5-134">スクリーン リーダー (ナレーター)</span><span class="sxs-lookup"><span data-stu-id="625a5-134">Screen readers (Narrator)</span></span>          |<span data-ttu-id="625a5-135">ナレーターは、独自の操作エクスペリエンスと機能を提供する Windows の組み込みスクリーン リーダーですが、依然として基本的なキーボード ナビゲーションと入力に依存しています。</span><span class="sxs-lookup"><span data-stu-id="625a5-135">Narrator is a built-in screen reader for Windows that provides unique interaction experiences and functionality, but still relies on basic keyboard navigation and input.</span></span> <span data-ttu-id="625a5-136">ナレーターについて詳しくは、「[ナレーターの概要](https://support.microsoft.com/help/22798/windows-10-narrator-get-started)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="625a5-136">For Narrator details, see [Getting started with Narrator](https://support.microsoft.com/help/22798/windows-10-narrator-get-started).</span></span>|

## <a name="custom-experiences-and-efficient-keyboarding"></a><span data-ttu-id="625a5-137">カスタム エクスペリエンスと効率的なキーボード操作</span><span class="sxs-lookup"><span data-stu-id="625a5-137">Custom experiences and efficient keyboarding</span></span>
<span data-ttu-id="625a5-138">前述のとおり、さまざまなスキル、能力、期待を持ったユーザーにとってアプリケーションが十分に機能するために、キーボードのサポートは重要です。</span><span class="sxs-lookup"><span data-stu-id="625a5-138">As mentioned, keyboard support is integral to ensuring your applications work great for users with different skills, abilities, and expectations.</span></span> <span data-ttu-id="625a5-139">次の点を重視することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="625a5-139">We recommend that you prioritize the following.</span></span>
- <span data-ttu-id="625a5-140">キーボードを使った操作のサポート</span><span class="sxs-lookup"><span data-stu-id="625a5-140">Support keyboard navigation and interaction</span></span>
    - <span data-ttu-id="625a5-141">操作可能な項目をタブ位置として定義します (操作可能でない項目は、そうしないようにします)。ナビゲーションの順序が論理的かつ予測可能であるようにします ([タブ位置](#tab-stops)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-141">Ensure actionable items are identified as tab stops (and non-actionable items are not), and navigation order is logical and predictable (see [Tab stops](#tab-stops))</span></span>
    - <span data-ttu-id="625a5-142">初期フォーカスは、最も論理的な要素に設定します ([初期フォーカス](#initial-focus) をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-142">Set initial focus on the most logical element (see [Initial focus](#initial-focus))</span></span>
    - <span data-ttu-id="625a5-143">"内部ナビゲーション" には矢印キーのナビゲーションを提供します ([ナビゲーション](#navigation)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-143">Provide arrow key navigation for "inner navigations" (see [Navigation](#navigation))</span></span>
- <span data-ttu-id="625a5-144">キーボード ショートカットのサポート</span><span class="sxs-lookup"><span data-stu-id="625a5-144">Support keyboard shortcuts</span></span>
    - <span data-ttu-id="625a5-145">クイック アクションのためのアクセラレータ キーを提供します ([アクセラレータ](#accelerators)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-145">Provide accelerator keys for quick actions (see [Accelerators](#accelerators))</span></span>
    - <span data-ttu-id="625a5-146">アプリケーションの UI を移動するアクセス キーを指定 (を参照してください[アクセス キー](access-keys.md))</span><span class="sxs-lookup"><span data-stu-id="625a5-146">Provide access keys to navigate your application's UI (see [Access keys](access-keys.md))</span></span>

### <a name="focus-visuals"></a><span data-ttu-id="625a5-147">フォーカスのビジュアル</span><span class="sxs-lookup"><span data-stu-id="625a5-147">Focus visuals</span></span>

<span data-ttu-id="625a5-148">UWP は、あらゆる入力の種類とエクスペリエンスで適切に動作する 1 つのフォーカスの視覚効果デザインをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="625a5-148">The UWP supports a single focus visual design that works well for all input types and experiences.</span></span>
<span data-ttu-id="625a5-149">![フォーカス ビジュアル](images/keyboard/focus-visual.png)</span><span class="sxs-lookup"><span data-stu-id="625a5-149">![Focus visual](images/keyboard/focus-visual.png)</span></span>

<span data-ttu-id="625a5-150">フォーカスの視覚効果には次のような特徴があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-150">A focus visual:</span></span>

- <span data-ttu-id="625a5-151">UI 要素がキーボードやゲームパッド/リモコンからフォーカスを受け取ったときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-151">Is shown when a UI element receives focus from a keyboard and/or gamepad/remote control</span></span>
- <span data-ttu-id="625a5-152">実行すべき操作を示すため、強調表示された境界線および UI 要素としてレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="625a5-152">Is rendered as a highlighted border around the UI element to indicate an action can be taken</span></span>
- <span data-ttu-id="625a5-153">ユーザーが迷わすにアプリの UI を移動するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="625a5-153">Helps a user navigate an app UI without getting lost</span></span>
- <span data-ttu-id="625a5-154">アプリ用にカスタマイズできます (「[視認性の高いフォーカスの視覚効果](guidelines-for-visualfeedback.md#high-visibility-focus-visuals)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-154">Can be customized for your app (See [High visibility focus  visuals](guidelines-for-visualfeedback.md#high-visibility-focus-visuals))</span></span>

<span data-ttu-id="625a5-155">**注:** UWP のフォーカスの視覚効果は、ナレーターのフォーカスの四角形と同じではありません。</span><span class="sxs-lookup"><span data-stu-id="625a5-155">**NOTE** The UWP focus visual is not the same as the Narrator focus rectangle.</span></span>

### <a name="tab-stops"></a><span data-ttu-id="625a5-156">タブ位置</span><span class="sxs-lookup"><span data-stu-id="625a5-156">Tab stops</span></span>

<span data-ttu-id="625a5-157">キーボードでコントロール (ナビゲーション要素を含む) を操作するには、そのコントロールがフォーカスを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-157">To use a control (including navigation elements) with the keyboard, the control must have focus.</span></span> <span data-ttu-id="625a5-158">キーボード フォーカスを受け取るコントロールの 1 つの方法がタブとして識別する、タブのナビゲーションからアクセスできるようにすること、アプリケーションのタブ オーダー内で停止します。</span><span class="sxs-lookup"><span data-stu-id="625a5-158">One way for a control to receive keyboard focus is to make it accessible through tab navigation by identifying it as a tab stop in your application's tab order.</span></span>

<span data-ttu-id="625a5-159">タブ オーダーに含まれるコントロールの[IsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_IsEnabled)にプロパティを設定する必要があります**true**と[IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop)にプロパティを設定する必要があります**true**.</span><span class="sxs-lookup"><span data-stu-id="625a5-159">For a control to be included in the tab order, the [IsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_IsEnabled) property must be set to **true** and the [IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop) property must be set to **true**.</span></span>

<span data-ttu-id="625a5-160">タブ オーダーのコントロールが除外する設定、 [IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop)プロパティを**false**します。</span><span class="sxs-lookup"><span data-stu-id="625a5-160">To specifically exclude a control from the tab order, set the [IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop) property to **false**.</span></span>

<span data-ttu-id="625a5-161">既定では、タブ オーダーには UI 要素が作成される順序が反映されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-161">By default, tab order reflects the order in which UI elements are created.</span></span> <span data-ttu-id="625a5-162">たとえば、`StackPanel` には `Button`、`Checkbox`、`TextBox` が含まれ、タブ オーダーは `Button`、`Checkbox`、`TextBox` です。</span><span class="sxs-lookup"><span data-stu-id="625a5-162">For example, if a `StackPanel` contains a `Button`, a `Checkbox`, and a `TextBox`, tab order is `Button`, `Checkbox`, and `TextBox`.</span></span>

<span data-ttu-id="625a5-163">既定のタブ オーダーを設定して上書きできます、 [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="625a5-163">You can override the default tab order by setting the [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) property.</span></span>

#### <a name="tab-order-should-be-logical-and-predictable"></a><span data-ttu-id="625a5-164">タブ オーダーは、論理的かつ予測可能でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="625a5-164">Tab order should be logical and predictable</span></span>

<span data-ttu-id="625a5-165">論理的で予測可能なタブ オーダーを使った、適切に設計されたキーボード ナビゲーション モデルがあれば、アプリはより直感的になり、ユーザーは機能をより効率的かつ効果的に探して見つけ、アクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="625a5-165">A well-designed keyboard navigation model, using a logical and predictable tab order, makes your app more intuitive and helps users explore, discover, and access functionality more efficiently and effectively.</span></span>

<span data-ttu-id="625a5-166">すべての対話型コントロールがタブ ストップがある必要があります (である場合を除いて、[グループ](#control-group))、中、ラベルなどの非対話型コントロールにしない必要があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-166">All interactive controls should have tab stops (unless they are in a [group](#control-group)), while non-interactive controls, such as labels, should not.</span></span>

<span data-ttu-id="625a5-167">フォーカスがアプリケーション内をジャンプするようなカスタムのタブ オーダーは使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="625a5-167">Avoid a custom tab order that makes the focus jump around in your application.</span></span> <span data-ttu-id="625a5-168">たとえば、フォーム内のコントロールの一覧には、上から下および左から右へと移動するタブ オーダーが必要です (ロケールによって異なります)。</span><span class="sxs-lookup"><span data-stu-id="625a5-168">For example, a list of controls in a form should have a tab order that flows from top to bottom and left to right (depending on locale).</span></span>

<span data-ttu-id="625a5-169">参照してください[キーボード アクセシビリティ](../accessibility/keyboard-accessibility.md)タブ ストップをカスタマイズする方法の詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="625a5-169">See [Keyboard accessibility](../accessibility/keyboard-accessibility.md) for more details about customizing tab stops.</span></span>

#### <a name="try-to-coordinate-tab-order-and-visual-order"></a><span data-ttu-id="625a5-170">タブ オーダーと表示順序を調整してみる</span><span class="sxs-lookup"><span data-stu-id="625a5-170">Try to coordinate tab order and visual order</span></span>

<span data-ttu-id="625a5-171">タブ オーダーと視覚的な順序 (順序や表示順序を読む場合とも呼ばれます) を調整は、アプリケーションの UI から移動する際にユーザーの混乱を削減に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="625a5-171">Coordinating tab order and visual order (also referred to as reading order or display order) helps reduce confusion for users as they navigate through your application's UI.</span></span>

<span data-ttu-id="625a5-172">コマンド、コントロール、コンテンツを順序付けし、最も重要なものをタブ オーダーと表示順序の両方で最初に提示するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="625a5-172">Try to rank and present the most important commands, controls, and content first in both the tab order and the visual order.</span></span> <span data-ttu-id="625a5-173">ただし実際の表示位置は、親レイアウト コンテナーと、レイアウトに影響する子要素の特定のプロパティに左右されることがあります。</span><span class="sxs-lookup"><span data-stu-id="625a5-173">However, the actual display position can depend on the parent layout container and certain properties of the child elements that influence the layout.</span></span> <span data-ttu-id="625a5-174">特に、グリッド形式または表形式を使用しているレイアウトでは、表示順序がタブ オーダーとまったく異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-174">Specifically, layouts that use a grid metaphor or a table metaphor can have a visual order quite different from the tab order.</span></span>

<span data-ttu-id="625a5-175">**注:** 表示順序はロケールと言語にも依存します。</span><span class="sxs-lookup"><span data-stu-id="625a5-175">**NOTE** Visual order is also dependent on locale and language.</span></span>

### <a name="initial-focus"></a><span data-ttu-id="625a5-176">初期フォーカス</span><span class="sxs-lookup"><span data-stu-id="625a5-176">Initial focus</span></span>

<span data-ttu-id="625a5-177">初期フォーカスは、アプリケーションやページが最初に起動またはアクティブ化されたときにフォーカスを受け取る UI 要素を指定します。</span><span class="sxs-lookup"><span data-stu-id="625a5-177">Initial focus specifies the UI element that receives focus when an application or a page is first launched or activated.</span></span> <span data-ttu-id="625a5-178">キーボードを使用する場合、ユーザーが操作を開始、アプリケーションの UI を使用したこの要素からです。</span><span class="sxs-lookup"><span data-stu-id="625a5-178">When using a keyboard, it is from this element that a user starts interacting with your application's UI.</span></span>

<span data-ttu-id="625a5-179">UWP アプリで初期フォーカスは最高の値を持つ要素に設定されて[TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex)がフォーカスを受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="625a5-179">For UWP apps, initial focus is set to the element with the highest [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) that can receive focus.</span></span> <span data-ttu-id="625a5-180">コンテナー コントロールの子要素は無視されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-180">Child elements of container controls are ignored.</span></span> <span data-ttu-id="625a5-181">TIE の場合、表示ツリー内の最初の要素がフォーカスを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="625a5-181">In a tie, the first element in the visual tree receives focus.</span></span>

#### <a name="set-initial-focus-on-the-most-logical-element"></a><span data-ttu-id="625a5-182">初期フォーカスは、最も論理的な要素に設定します。</span><span class="sxs-lookup"><span data-stu-id="625a5-182">Set initial focus on the most logical element</span></span>

<span data-ttu-id="625a5-183">初期フォーカスは、ユーザーがアプリを起動したり、ページを移動したりするときに最初に実行する可能性が最も高い操作 (つまり、プライマリ操作) の UI 要素に設定します。</span><span class="sxs-lookup"><span data-stu-id="625a5-183">Set initial focus on the UI element for the first, or primary, action that users are most likely to take when launching your app or navigating to a page.</span></span> <span data-ttu-id="625a5-184">次のような例があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-184">Some examples include:</span></span>
-   <span data-ttu-id="625a5-185">フォーカスがギャラリー内の最初の項目に設定されているフォト アプリ</span><span class="sxs-lookup"><span data-stu-id="625a5-185">A photo app where focus is set to the first item in a gallery</span></span>
-   <span data-ttu-id="625a5-186">フォーカスが再生ボタンに設定されているミュージック アプリ</span><span class="sxs-lookup"><span data-stu-id="625a5-186">A music app where focus is set to the play button</span></span>

#### <a name="dont-set-initial-focus-on-an-element-that-exposes-a-potentially-negative-or-even-disastrous-outcome"></a><span data-ttu-id="625a5-187">可能性のある負の場合、またはさらに悲惨な結果を公開する要素に初期フォーカスを設定しないでください。</span><span class="sxs-lookup"><span data-stu-id="625a5-187">Don't set initial focus on an element that exposes a potentially negative, or even disastrous, outcome</span></span>

<span data-ttu-id="625a5-188">このレベルの機能には、ユーザーの選択必要があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-188">This level of functionality should be a user's choice.</span></span> <span data-ttu-id="625a5-189">重要な結果を生み出す要素に初期フォーカスを設定すると、意図しないデータ消失またはシステム アクセスが生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-189">Setting initial focus to an element with a significant outcome might result in unintended data loss or system access.</span></span> <span data-ttu-id="625a5-190">たとえば、しないにフォーカスを設定 delete ボタン電子メールに移動するとします。</span><span class="sxs-lookup"><span data-stu-id="625a5-190">For example, don't set focus to the delete button when navigating to an e-mail.</span></span>

<span data-ttu-id="625a5-191">参照してください[ナビゲーションを集中](focus-navigation.md)タブ オーダーをオーバーライドする方法についての詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="625a5-191">See [Focus navigation](focus-navigation.md) for more details about overriding tab order.</span></span>

### <a name="navigation"></a><span data-ttu-id="625a5-192">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="625a5-192">Navigation</span></span>

<span data-ttu-id="625a5-193">キーボード ナビゲーションは通常、Tab キーと方向キーによってサポートされます。</span><span class="sxs-lookup"><span data-stu-id="625a5-193">Keyboard navigation is typically supported through the Tab keys and the Arrow keys.</span></span>

![Tab + 方向キー](images/keyboard/tab-and-arrow.png)

<span data-ttu-id="625a5-195">既定では、UWP コントロールは以下の基本的なキーボード動作に従います。</span><span class="sxs-lookup"><span data-stu-id="625a5-195">By default, UWP controls follow these basic keyboard behaviors:</span></span>
-   <span data-ttu-id="625a5-196">**Tab キー**を使うと、実行可能な/アクティブなコントロール間をタブ オーダーで移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-196">**Tab keys** navigate between actionable/active controls in tab order.</span></span>
-   <span data-ttu-id="625a5-197">**Shift + Tab** キーを使うと、コントロールを逆タブ オーダーで移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-197">**Shift + Tab** navigate controls in reverse tab order.</span></span> <span data-ttu-id="625a5-198">ユーザーが方向キーを使ってコントロール内を移動した場合、フォーカスはコントロール内の最後の既知の値に設定されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-198">If user has navigated inside the control using arrow key, focus is set to the last known value inside the control.</span></span>
-   <span data-ttu-id="625a5-199">**方向キー**を使うと、コントロール固有の "内部ナビゲーション" が表示されます。ユーザーが "内部ナビゲーション" に入ると、方向キーを使ってもコントロール外に移動しません。</span><span class="sxs-lookup"><span data-stu-id="625a5-199">**Arrow keys** expose control-specific "inner navigation" When user enters "inner navigation,"" arrow keys do not navigate out of a control.</span></span> <span data-ttu-id="625a5-200">次のような例があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-200">Some examples include:</span></span>
    -   <span data-ttu-id="625a5-201">キーが内でフォーカスを移動/下矢印`ListView`と `MenuFlyout`</span><span class="sxs-lookup"><span data-stu-id="625a5-201">Up/Down arrow key moves focus inside `ListView` and `MenuFlyout`</span></span>
    -   <span data-ttu-id="625a5-202">現在選択されている値を変更`Slider`と `RatingsControl`</span><span class="sxs-lookup"><span data-stu-id="625a5-202">Modify currently selected values for `Slider` and `RatingsControl`</span></span>
    -   <span data-ttu-id="625a5-203">内側にキャレットを移動します。 `TextBox`</span><span class="sxs-lookup"><span data-stu-id="625a5-203">Move caret inside `TextBox`</span></span>
    -   <span data-ttu-id="625a5-204">内の項目の展開/折りたたみ `TreeView`</span><span class="sxs-lookup"><span data-stu-id="625a5-204">Expand/collapse items inside `TreeView`</span></span>

<span data-ttu-id="625a5-205">これらの既定の動作を使用すると、アプリケーションのキーボード ナビゲーションを最適化できます。</span><span class="sxs-lookup"><span data-stu-id="625a5-205">Use these default behaviors to optimize your application's keyboard navigation.</span></span>

#### <a name="use-inner-navigation-with-sets-of-related-controls"></a><span data-ttu-id="625a5-206">関連するコントロールのセットで ”内部ナビゲーション" を使う</span><span class="sxs-lookup"><span data-stu-id="625a5-206">Use "inner navigation" with sets of related controls</span></span>

<span data-ttu-id="625a5-207">関連するコントロールのセットに矢印キー ナビゲーションを提供するには、アプリケーションの UI の全体的な組織内の関係が促進されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-207">Providing arrow key navigation into a set of related controls reinforces their relationship within the overall organization of your application's UI.</span></span>

<span data-ttu-id="625a5-208">たとえば、ここに示す `ContentDialog` コントロールは、横 1 列のボタンに既定で内部ナビゲーションを提供します (カスタム コントロールについては、「[コントロール グループ](#control-group)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-208">For example, the `ContentDialog` control shown here provides inner navigation by default for a horizontal row of buttons (for custom controls, see the [Control Group](#control-group) section).</span></span>

![ダイアログの例](images/keyboard/dialog.png)

<span data-ttu-id="625a5-210">***関連するボタンのコレクションとの対話が矢印キー ナビゲーションを容易になります***</span><span class="sxs-lookup"><span data-stu-id="625a5-210">***Interaction with a collection of related buttons is made easier with arrow key navigation***</span></span>

<span data-ttu-id="625a5-211">項目が 1 列に表示されている場合、上/下方向キーによって項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-211">If items are displayed in a single column, Up/Down arrow key navigates items.</span></span> <span data-ttu-id="625a5-212">項目が 1 行に表示されている場合、右/左方向キーによって項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-212">If items are displayed in a single row, Right/Left arrow key navigates items.</span></span> <span data-ttu-id="625a5-213">項目が複数の列にある場合、4 つの方向キーすべてを使って移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-213">If items are multiple columns, all 4 arrow keys navigate.</span></span>

#### <a name="define-a-single-tab-stop-for-a-collection-of-related-controls"></a><span data-ttu-id="625a5-214">関連するコントロールのコレクションの 1 つのタブ ストップを定義します。</span><span class="sxs-lookup"><span data-stu-id="625a5-214">Define a single tab stop for a collection of related controls</span></span>

<span data-ttu-id="625a5-215">関連する、または、補完的なコントロールのコレクションの 1 つのタブ ストップを定義することで、アプリの全体的なタブ ストップの数を最小限に抑えることができます。</span><span class="sxs-lookup"><span data-stu-id="625a5-215">By defining a single tab stop for a collection of related, or complementary, controls, you can minimize the number of overall tab stops in your app.</span></span>

<span data-ttu-id="625a5-216">たとえば、次の図は縦に並んだ 2 つの `ListView` コントロールを示しています。</span><span class="sxs-lookup"><span data-stu-id="625a5-216">For example, the following images show two stacked `ListView` controls.</span></span> <span data-ttu-id="625a5-217">左の図は、`ListView` コントロール間を移動するタブ位置で使われる方向キー ナビゲーション を示しているのに対し、右の図は、Tab キーによって親コントロールを移動する必要をなくすことで、子要素間のナビゲーションがどのように簡単かつ効率的になるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="625a5-217">The image on the left shows arrow key navigation used with a tab stop to navigate between `ListView` controls, while the image on the right shows how navigation between child elements could be made easier and more efficient by eliminating the need for to traverse parent controls with a tab key.</span></span>


<table>
  <td><img src="images/keyboard/arrow-and-tab.png" alt="arrow and tab" /></td>
  <td><img src="images/keyboard/arrow-only.png" alt="arrow only" /></td>
</table>

<span data-ttu-id="625a5-218">***2 つの積み上げ ListView コントロールとの対話は、タブ ストップを排除し、方向キーだけを使用した移動によって簡単かつより効率的に作成できます。***</span><span class="sxs-lookup"><span data-stu-id="625a5-218">***Interaction with two stacked ListView controls can be made easier and more efficient by eliminating the tab stop and navigating with just arrow keys.***</span></span>

<span data-ttu-id="625a5-219">アプリケーション UI に最適化の例を適用する方法については、「[コントロール グループ](#control-group)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="625a5-219">Visit [Control Group](#control-group) section to learn how to apply the optimization examples to your application UI.</span></span>

### <a name="interaction-and-commanding"></a><span data-ttu-id="625a5-220">対話式操作とコマンド実行</span><span class="sxs-lookup"><span data-stu-id="625a5-220">Interaction and commanding</span></span>

<span data-ttu-id="625a5-221">コントロールにフォーカスが置かれると、ユーザーはそのコントロールを操作し、特定のキーボード入力を使って関連付けられている機能を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="625a5-221">Once a control has focus, a user can interact with it and invoke any associated functionality using specific keyboard input.</span></span>

#### <a name="text-entry"></a><span data-ttu-id="625a5-222">テキスト入力</span><span class="sxs-lookup"><span data-stu-id="625a5-222">Text entry</span></span>

<span data-ttu-id="625a5-223">`TextBox` や `RichEditBox` など、特にテキスト入力向けに設計されたコントロールの場合、テキストの入力や移動のためにすべてのキーボード入力が使用され、他のキーボード コマンドより優先されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-223">For those controls specifically designed for text input such as `TextBox` and `RichEditBox`, all keyboard input is used for entering or navigating text, which takes priority over other keyboard commands.</span></span> <span data-ttu-id="625a5-224">たとえば、`AutoSuggestBox` コントロールのドロップ ダウン メニューは **Space** キーを選択コマンドとして認識しません。</span><span class="sxs-lookup"><span data-stu-id="625a5-224">For example, the drop down menu for an `AutoSuggestBox` control does not recognize the **Space** key as a selection command.</span></span>

![テキスト入力](images/keyboard/text-entry.png)

#### <a name="space-key"></a><span data-ttu-id="625a5-226">Space キー</span><span class="sxs-lookup"><span data-stu-id="625a5-226">Space key</span></span>

<span data-ttu-id="625a5-227">テキスト入力モードではない場合、**Space** キーはフォーカスがあるコントロールに関連付けられた操作やコマンドを呼び出します (タッチによるタップやマウスによるクリックと同様)。</span><span class="sxs-lookup"><span data-stu-id="625a5-227">When not in text entry mode, the **Space** key invokes the action or command associated with the focused control (just like a tap with touch or a click with a mouse).</span></span>

![Space キー](images/keyboard/space-key.png)

#### <a name="enter-key"></a><span data-ttu-id="625a5-229">Enter キー</span><span class="sxs-lookup"><span data-stu-id="625a5-229">Enter key</span></span>

<span data-ttu-id="625a5-230">**Enter** キーは、フォーカスのあるコントロールに応じて、さまざまな共通ユーザー操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="625a5-230">The **Enter** key can perform a variety of common user interactions, depending on the control with focus:</span></span>
-   <span data-ttu-id="625a5-231">`Button` や `Hyperlink` などのコマンド コントロールをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="625a5-231">Activates command controls such as a `Button` or `Hyperlink`.</span></span> <span data-ttu-id="625a5-232">エンド ユーザーの混乱を避けるため、**Enter** キーは `ToggleButton` や `AppBarToggleButton` など、コマンド コントロールに似たコントロールもアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="625a5-232">To avoid end user confusion, the **Enter** key also activates controls that look like command controls such as `ToggleButton` or `AppBarToggleButton`.</span></span>
-   <span data-ttu-id="625a5-233">`ComboBox` や `DatePicker` などのコントロールのピッカー UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="625a5-233">Displays the picker UI for controls such as `ComboBox` and `DatePicker`.</span></span> <span data-ttu-id="625a5-234">**Enter** キーは、ピッカー UI もコミットして閉じます。</span><span class="sxs-lookup"><span data-stu-id="625a5-234">The **Enter** key also commits and closes the picker UI.</span></span>
-   <span data-ttu-id="625a5-235">`ListView`、`GridView`、`ComboBox` などのリスト コントロールをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="625a5-235">Activates list controls such as `ListView`, `GridView`, and `ComboBox`.</span></span>
    -   <span data-ttu-id="625a5-236">**Enter** キーは、選択操作をリストおよびグリッド項目の **Space** キーとして実行します。ただし、それらの項目に追加の操作が関連付けられている場合を除きます (新しいウィンドウを開くなど)。</span><span class="sxs-lookup"><span data-stu-id="625a5-236">The **Enter** key performs the selection action as the **Space** key for list and grid items, unless there is an additional action associated with these items (opening a new window).</span></span>
    -   <span data-ttu-id="625a5-237">コントロールに追加の操作が関連付けられている場合、**Enter** キーは追加の操作を実行し、**Space** キーは選択操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="625a5-237">If an additional action is associated with the control, the **Enter** key performs the additional action and the **Space** key performs the selection action.</span></span>

<span data-ttu-id="625a5-238">**注:\*\*\*\*Enter** キーと **Space** キーは、常に同じ操作を実行するわけではありませんが、多くの場合は同じ操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="625a5-238">**NOTE** The **Enter** key and **Space** key do not always perform the same action, but often do.</span></span>

![Enter キー](images/keyboard/enter-key.png)

<span data-ttu-id="625a5-240">Esc キーを使うと、ユーザーが一時的な UI (および、その UI における継続的な操作すべて) を取り消すことができます。</span><span class="sxs-lookup"><span data-stu-id="625a5-240">The Esc key lets a user cancel transient UI (along with any ongoing actions in that UI).</span></span>

<span data-ttu-id="625a5-241">このエクスペリエンスの例は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="625a5-241">Examples of this experience include:</span></span>
-   <span data-ttu-id="625a5-242">ユーザーが、選択した値を使って `ComboBox` を開き、方向キーを使ってフォーカスの選択を新しい値に移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-242">User opens a `ComboBox` with a selected value and uses the arrow keys to move the focus selection to a new value.</span></span> <span data-ttu-id="625a5-243">Esc キーを押すと `ComboBox` が閉じ、選択した値が元の値にリセットされます。</span><span class="sxs-lookup"><span data-stu-id="625a5-243">Pressing the Esc key closes the `ComboBox` and resets the selected value back to the original value.</span></span>
-   <span data-ttu-id="625a5-244">ユーザーがメールの永続的な削除アクションを呼び出すと、操作の確認を求める `ContentDialog` が表示されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-244">User invokes a permanent delete action for an email and is prompted with a `ContentDialog` to confirm the action.</span></span> <span data-ttu-id="625a5-245">ユーザーは、これが意図した操作でないと判断し、**Esc** キーを押してダイアログを閉じます。</span><span class="sxs-lookup"><span data-stu-id="625a5-245">The user decides this is not the intended action and presses the **Esc** key to close the dialog.</span></span> <span data-ttu-id="625a5-246">**Esc** キーは **[キャンセル]** ボタンに関連付けられているため、ダイアログが閉じ、操作は取り消されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-246">As the **Esc** key is associated with the **Cancel** button, the dialog is closed and the action is canceled.</span></span> <span data-ttu-id="625a5-247">**Esc** キーは一時的な UI にのみ影響を与えます。アプリの UI を閉じたり、戻ったりすることはありません。</span><span class="sxs-lookup"><span data-stu-id="625a5-247">The **Esc** key only affects transient UI, it does not close, or back navigate through, app UI.</span></span>

![Esc キー](images/keyboard/esc-key.png)

#### <a name="home-and-end-keys"></a><span data-ttu-id="625a5-249">Home キーと End キー</span><span class="sxs-lookup"><span data-stu-id="625a5-249">Home and End keys</span></span>

<span data-ttu-id="625a5-250">**Home** キーと **End** キーを使うと、ユーザーは UI 領域の先頭または末尾までスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="625a5-250">The **Home** and **End** keys let a user scroll to the beginning or end of a UI region.</span></span>

<span data-ttu-id="625a5-251">このエクスペリエンスの例は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="625a5-251">Examples of this experience include:</span></span>
-   <span data-ttu-id="625a5-252">`ListView` コントロールと `GridView` コントロールの場合、**Home** キーはフォーカスを最初の要素に移動してビューまでスクロールしますが、**End** キーはフォーカスを最後の要素に移動し、ビューまでスクロールします。</span><span class="sxs-lookup"><span data-stu-id="625a5-252">For `ListView` and `GridView` controls, the **Home** key moves focus to the first element and scrolls it into view, whereas the **End** key moves focus to the last element and scrolls it into view.</span></span>
-   <span data-ttu-id="625a5-253">`ScrollView` コントロールの場合、**Home** キーは領域の上までスクロールしますが、**End** キーは領域の下までスクロールします (フォーカスが変更されません)。</span><span class="sxs-lookup"><span data-stu-id="625a5-253">For a `ScrollView` control, the **Home** key scrolls to the top of the region, whereas the **End** key scrolls to the bottom of the region (focus is not changed).</span></span>

![Home キーと End キー](images/keyboard/home-and-end.png)

#### <a name="page-up-and-page-down-keys"></a><span data-ttu-id="625a5-255">PageUp キーと PageDown キー</span><span class="sxs-lookup"><span data-stu-id="625a5-255">Page up and Page down keys</span></span>

<span data-ttu-id="625a5-256">**Page** キーを使うと、ユーザーは一定の単位で UI 領域をスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="625a5-256">The **Page** keys let a user scroll a UI region in discrete increments.</span></span>

<span data-ttu-id="625a5-257">たとえば、`ListView` コントロールと `GridView` コントロールの場合、**PageUp** キーは領域を 1 "ページ" 分 (通常はビューポートの高さ) 上にスクロールし、領域の上にフォーカスを移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-257">For example, for `ListView` and `GridView` controls, the **Page up** key scrolls the region up by a "page" (typically the viewport height) and moves focus to the top of the region.</span></span> <span data-ttu-id="625a5-258">一方、**PageDown** キーは領域を 1 ページ分下に移動し、領域の下にフォーカスを移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-258">Alternately, the **Page down** key scrolls the region down by a page and moves focus to the bottom of the region.</span></span>

![PageUp キーと PageDown キー](images/keyboard/page-up-and-down.png)

### <a name="keyboard-shortcuts"></a><span data-ttu-id="625a5-260">キーボード ショートカット</span><span class="sxs-lookup"><span data-stu-id="625a5-260">Keyboard shortcuts</span></span>

<span data-ttu-id="625a5-261">キーボード ショートカットは、アプリを使いやすくアクセシビリティ サポートの強化し、ユーザーがキーボードの効率の向上の両方を提供することで。</span><span class="sxs-lookup"><span data-stu-id="625a5-261">Keyboard shortcuts can make your app easier to use by providing both enhanced support for accessibility and improved efficiency for keyboard users.</span></span>

<span data-ttu-id="625a5-262">アプリでのキーボード ナビゲーションとアクティブ化をサポートするだけでなくもショートカット、アプリケーションの機能を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="625a5-262">In addition to supporting keyboard navigation and activation in your app, it is also good practice to provide shortcuts for your application's functionality.</span></span> <span data-ttu-id="625a5-263">タブ ナビゲーションは、適切な基本的なレベルは、キーボードのサポートが同様のショートカット キーのサポートを追加するより複雑な UI を提供します。</span><span class="sxs-lookup"><span data-stu-id="625a5-263">Tab navigation provides a good, basic level of keyboard support, but with more complex UI you might want to add support for shortcut keys as well.</span></span> 

<span data-ttu-id="625a5-264">ショートカットは、ユーザーが効率的にアプリの機能にアクセスできるようにして、生産性を向上させるためのキーの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="625a5-264">A shortcut is a keyboard combination that enhances productivity by providing an efficient way for the user to access app functionality.</span></span> <span data-ttu-id="625a5-265">ショートカットには次の 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-265">There are two kinds of shortcut:</span></span>
-   <span data-ttu-id="625a5-266">[アクセラレータ](#accelerators)は、アプリのコマンドを呼び出すショートカットです。</span><span class="sxs-lookup"><span data-stu-id="625a5-266">[Accelerators](#accelerators) are shortcuts that invoke an app command.</span></span> <span data-ttu-id="625a5-267">アプリは、コマンドに対応する特定の UI を提供しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-267">Your app may or may not provide specific UI that corresponds to the command.</span></span> <span data-ttu-id="625a5-268">アクセラレータは通常、Ctrl キーとアルファベット キーで構成されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-268">Accelerators typically consist of the Ctrl key plus a letter key.</span></span>
-   <span data-ttu-id="625a5-269">[アクセス キー](#access-keys)アプリケーションで特定の UI にフォーカスを設定するためのショートカットを示します。</span><span class="sxs-lookup"><span data-stu-id="625a5-269">[Access keys](#access-keys) are shortcuts that set focus to specific UI in your application.</span></span> <span data-ttu-id="625a5-270">アクセス キー セレクトは、Alt キーとアルファベット キーで構成されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-270">Access keys typicaly consist of the Alt key plus a letter key.</span></span>

<span data-ttu-id="625a5-271">アプリケーション間で同様のタスクをサポートする一貫性のあるキーボード ショートカットを提供して、はるかに便利で強力になります、忘れないようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="625a5-271">Providing consistent keyboard shortcuts that support similar tasks across applications makes them much more useful and powerful and helps users remember them.</span></span>

#### <a name="accelerators"></a><span data-ttu-id="625a5-272">アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="625a5-272">Accelerators</span></span>

<span data-ttu-id="625a5-273">アクセラレータは、迅速かつ効率的に、アプリケーションで一般的なアクションを実行するユーザーを支援します。</span><span class="sxs-lookup"><span data-stu-id="625a5-273">Accelerators help users perform common actions in an application much more quickly and efficiently.</span></span> 

<span data-ttu-id="625a5-274">アクセラレータの例:</span><span class="sxs-lookup"><span data-stu-id="625a5-274">Examples of Accelerators:</span></span>
-   <span data-ttu-id="625a5-275">キーを押して Ctrl + N キー任意の場所、**メール**アプリが新しいメール アイテムを起動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-275">Pressing Ctrl + N key anywhere in the **Mail** app launches a new mail item.</span></span>
-   <span data-ttu-id="625a5-276">Ctrl + E キー Microsoft Edge で任意の場所 (および多くの Microsoft Store アプリケーション) を押して検索を起動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-276">Pressing Ctrl + E key anywhere in Microsoft Edge (and many Microsoft Store applications) launches search.</span></span>

<span data-ttu-id="625a5-277">アクセラレータには、次の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-277">Accelerators have the following characteristics:</span></span>
-   <span data-ttu-id="625a5-278">Ctrl キーと関数を使用して主に、キーのシーケンス (Windows システムのショートカット キーも使用 Alt + 英数字以外のキーと、Windows ロゴ キー)。</span><span class="sxs-lookup"><span data-stu-id="625a5-278">They primarily use Ctrl and Function key sequences (Windows system shortcut keys also use Alt + non-alphanumeric keys and the Windows logo key).</span></span>
-   <span data-ttu-id="625a5-279">特に使用頻度の高いコマンドにのみ割り当てます。</span><span class="sxs-lookup"><span data-stu-id="625a5-279">They are assigned only to the most commonly used commands.</span></span>
-   <span data-ttu-id="625a5-280">覚えて使うことを意図しており、メニュー、ツールヒント、ヘルプ内にのみ示されています。</span><span class="sxs-lookup"><span data-stu-id="625a5-280">They are intended to be memorized, and are documented only in menus, tooltips, and Help.</span></span>
-   <span data-ttu-id="625a5-281">サポートされている場合は、アプリケーション全体については、全体に影響があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-281">They have effect throughout the entire application, when supported.</span></span>
-   <span data-ttu-id="625a5-282">惜しまは直接記載されていないそのに一貫して割り当てする必要があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-282">They should be assigned consistently as they are memorized and not directly documented.</span></span>

#### <a name="access-keys"></a><span data-ttu-id="625a5-283">アクセス キー</span><span class="sxs-lookup"><span data-stu-id="625a5-283">Access keys</span></span>

<span data-ttu-id="625a5-284">UWP でアクセス キーをサポートする方法について詳しくは、「[アクセス キー](access-keys.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="625a5-284">See [Access keys](access-keys.md) page for more in-depth information for supporting access keys with UWP.</span></span>

<span data-ttu-id="625a5-285">アクセス キーを使うと、運動機能に障碍を持つユーザーが、一度に 1 つのキーを押して UI の特定の項目に対してアクションを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="625a5-285">Access keys help users with motor function disabilities an ability to press one key at a time to action on a specific item in the UI.</span></span> <span data-ttu-id="625a5-286">さらに、アクセス キーは上級ユーザーが操作をすばやく実行できるように、追加のショートカット キーを伝えるためにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="625a5-286">Moreover, access keys can be used to communicate additional shortcut keys to help advanced users perform actions quickly.</span></span>

<span data-ttu-id="625a5-287">アクセス キーには、次の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-287">Access keys have the following characteristics:</span></span>
-   <span data-ttu-id="625a5-288">Alt キーを押しながら英数字キーを押します。</span><span class="sxs-lookup"><span data-stu-id="625a5-288">They use the Alt key plus an alphanumeric key.</span></span>
-   <span data-ttu-id="625a5-289">主な目的はアクセシビリティです。</span><span class="sxs-lookup"><span data-stu-id="625a5-289">They are primarily for accessibility.</span></span>
-   <span data-ttu-id="625a5-290">コントロールの横にある、UI に直接記載されていますがを通じて[キー ヒント](access-keys.md)します。</span><span class="sxs-lookup"><span data-stu-id="625a5-290">They are documented directly in the UI, adjacent to the control, through [Key Tips](access-keys.md).</span></span>
-   <span data-ttu-id="625a5-291">アクセス キーは、対応するメニュー項目やコントロールへの移動に使用します。効力は現在のウィンドウ内に限られます。</span><span class="sxs-lookup"><span data-stu-id="625a5-291">They have effect only in the current window, and navigate to the corresponding menu item or control.</span></span>
-   <span data-ttu-id="625a5-292">アクセス キーはよく使用されるコマンド (特にコミット ボタン) を一貫して割り当てる必要があります可能な場合。</span><span class="sxs-lookup"><span data-stu-id="625a5-292">Access keys should be assigned consistently to commonly used commands (especially commit buttons), whenever possible.</span></span>
-   <span data-ttu-id="625a5-293">アクセス キーはローカライズされます。</span><span class="sxs-lookup"><span data-stu-id="625a5-293">They are localized.</span></span>

#### <a name="common-keyboard-shortcuts"></a><span data-ttu-id="625a5-294">一般的なキーボード ショートカット</span><span class="sxs-lookup"><span data-stu-id="625a5-294">Common keyboard shortcuts</span></span>

<span data-ttu-id="625a5-295">次の表では、頻繁に使用されるキーボード ショートカットの小さなサンプルを示します。</span><span class="sxs-lookup"><span data-stu-id="625a5-295">The following table is a small sample of frequently used keyboard shortcuts.</span></span> 

| <span data-ttu-id="625a5-296">アクション</span><span class="sxs-lookup"><span data-stu-id="625a5-296">Action</span></span>                               | <span data-ttu-id="625a5-297">キー コマンド</span><span class="sxs-lookup"><span data-stu-id="625a5-297">Key command</span></span>                                      |
|--------------------------------------|--------------------------------------------------|
| <span data-ttu-id="625a5-298">すべて選択</span><span class="sxs-lookup"><span data-stu-id="625a5-298">Select all</span></span>                           | <span data-ttu-id="625a5-299">Ctrl + A</span><span class="sxs-lookup"><span data-stu-id="625a5-299">Ctrl+A</span></span>                                           |
| <span data-ttu-id="625a5-300">連続して選択</span><span class="sxs-lookup"><span data-stu-id="625a5-300">Continuously select</span></span>                  | <span data-ttu-id="625a5-301">Shift + 方向キー</span><span class="sxs-lookup"><span data-stu-id="625a5-301">Shift+Arrow key</span></span>                                  |
| <span data-ttu-id="625a5-302">Save</span><span class="sxs-lookup"><span data-stu-id="625a5-302">Save</span></span>                                 | <span data-ttu-id="625a5-303">Ctrl + S</span><span class="sxs-lookup"><span data-stu-id="625a5-303">Ctrl+S</span></span>                                           |
| <span data-ttu-id="625a5-304">検索</span><span class="sxs-lookup"><span data-stu-id="625a5-304">Find</span></span>                                 | <span data-ttu-id="625a5-305">Ctrl + F</span><span class="sxs-lookup"><span data-stu-id="625a5-305">Ctrl+F</span></span>                                           |
| <span data-ttu-id="625a5-306">印刷</span><span class="sxs-lookup"><span data-stu-id="625a5-306">Print</span></span>                                | <span data-ttu-id="625a5-307">Ctrl + P</span><span class="sxs-lookup"><span data-stu-id="625a5-307">Ctrl+P</span></span>                                           |
| <span data-ttu-id="625a5-308">コピー</span><span class="sxs-lookup"><span data-stu-id="625a5-308">Copy</span></span>                                 | <span data-ttu-id="625a5-309">Ctrl + C</span><span class="sxs-lookup"><span data-stu-id="625a5-309">Ctrl+C</span></span>                                           |
| <span data-ttu-id="625a5-310">切り取り</span><span class="sxs-lookup"><span data-stu-id="625a5-310">Cut</span></span>                                  | <span data-ttu-id="625a5-311">Ctrl + X</span><span class="sxs-lookup"><span data-stu-id="625a5-311">Ctrl+X</span></span>                                           |
| <span data-ttu-id="625a5-312">Paste</span><span class="sxs-lookup"><span data-stu-id="625a5-312">Paste</span></span>                                | <span data-ttu-id="625a5-313">Ctrl + V</span><span class="sxs-lookup"><span data-stu-id="625a5-313">Ctrl+V</span></span>                                           |
| <span data-ttu-id="625a5-314">元に戻す</span><span class="sxs-lookup"><span data-stu-id="625a5-314">Undo</span></span>                                 | <span data-ttu-id="625a5-315">Ctrl + Z</span><span class="sxs-lookup"><span data-stu-id="625a5-315">Ctrl+Z</span></span>                                           |
| <span data-ttu-id="625a5-316">次のタブ</span><span class="sxs-lookup"><span data-stu-id="625a5-316">Next tab</span></span>                             | <span data-ttu-id="625a5-317">Ctrl + Tab</span><span class="sxs-lookup"><span data-stu-id="625a5-317">Ctrl+Tab</span></span>                                         |
| <span data-ttu-id="625a5-318">タブを閉じる</span><span class="sxs-lookup"><span data-stu-id="625a5-318">Close tab</span></span>                            | <span data-ttu-id="625a5-319">Ctrl + 4 または Ctrl + W</span><span class="sxs-lookup"><span data-stu-id="625a5-319">Ctrl+F4 or Ctrl+W</span></span>                                |
| <span data-ttu-id="625a5-320">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="625a5-320">Semantic zoom</span></span>                        | <span data-ttu-id="625a5-321">Ctrl + 正符号 (+) または Ctrl + マイナス記号 (-)</span><span class="sxs-lookup"><span data-stu-id="625a5-321">Ctrl++ or Ctrl+-</span></span>                                 |

<span data-ttu-id="625a5-322">Windows システムのショートカットの包括的な一覧は、[Windows 用のキーボード ショートカット](https://support.microsoft.com/help/12445/windows-keyboard-shortcuts)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="625a5-322">For a comprehensive list of Windows system shortcuts, see [keyboard shortcuts for Windows](https://support.microsoft.com/help/12445/windows-keyboard-shortcuts).</span></span> <span data-ttu-id="625a5-323">一般的なアプリケーション ショートカットでは、[Microsoft アプリケーション用のキーボード ショートカット](https://support.microsoft.com/help/13805/windows-keyboard-shortcuts-in-apps)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="625a5-323">For common application shortcuts, see [keyboard shortcuts for Microsoft applications](https://support.microsoft.com/help/13805/windows-keyboard-shortcuts-in-apps).</span></span>

## <a name="advanced-experiences"></a><span data-ttu-id="625a5-324">高度なエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="625a5-324">Advanced experiences</span></span>

<span data-ttu-id="625a5-325">このセクションでは、UWP アプリによりサポートされているより複雑なキーボード操作エクスペリエンスと、アプリをさまざまなデバイスやツールで使う場合に認識すべき動作についていくつか説明します。</span><span class="sxs-lookup"><span data-stu-id="625a5-325">In this section, we discuss some of the more complex keyboard interaction experiences supported by UWP apps, along with some of the behaviors you should be aware of when your app is used on different devices and with different tools.</span></span>

### <a name="control-group"></a><span data-ttu-id="625a5-326">コントロール グループ</span><span class="sxs-lookup"><span data-stu-id="625a5-326">Control group</span></span>

<span data-ttu-id="625a5-327">一連の関連する (または補完的な) コントロールを "コントロール グループ" (または方向領域) にまとめることで、方向キーを使った "内部ナビゲーション" が可能になります。</span><span class="sxs-lookup"><span data-stu-id="625a5-327">You can group a set of related, or complementary, controls in a "control group" (or directional area), which enables "inner navigation" using the arrow keys.</span></span> <span data-ttu-id="625a5-328">コントロール グループは、1 つのタブ位置にすることも、コントロール グループ内の複数のタブ位置を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="625a5-328">The control group can be a single tab stop, or you can specify multiple tab stops within the control group.</span></span>

#### <a name="arrow-key-navigation"></a><span data-ttu-id="625a5-329">方向キー ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="625a5-329">Arrow key navigation</span></span>

<span data-ttu-id="625a5-330">ユーザーは、UI 領域に似たような関連するコントロールのグループがあるとき、方向キー ナビゲーションがサポートされることを期待します。</span><span class="sxs-lookup"><span data-stu-id="625a5-330">Users expect support for arrow key navigation when there is a group of similar, related controls in a UI region:</span></span>
-   <span data-ttu-id="625a5-331">`AppBarButtons` で、 `CommandBar`</span><span class="sxs-lookup"><span data-stu-id="625a5-331">`AppBarButtons` in a `CommandBar`</span></span>
-   <span data-ttu-id="625a5-332">`ListItems` または`GridItems`内`ListView`または `GridView`</span><span class="sxs-lookup"><span data-stu-id="625a5-332">`ListItems` or `GridItems` inside `ListView` or `GridView`</span></span>
-   <span data-ttu-id="625a5-333">`Buttons` 中に `ContentDialog`</span><span class="sxs-lookup"><span data-stu-id="625a5-333">`Buttons` inside `ContentDialog`</span></span>

<span data-ttu-id="625a5-334">UWP コントロールは、方向キー ナビゲーションを既定でサポートします。</span><span class="sxs-lookup"><span data-stu-id="625a5-334">UWP controls support arrow key navigation by default.</span></span> <span data-ttu-id="625a5-335">カスタム レイアウトおよびコントロール グループでは、`XYFocusKeyboardNavigation="Enabled"` を使って同様の動作を提供します。</span><span class="sxs-lookup"><span data-stu-id="625a5-335">For custom layouts and control groups, use `XYFocusKeyboardNavigation="Enabled"` to provide similar behavior.</span></span>

<span data-ttu-id="625a5-336">次のコントロールを使用する場合、方向キーによる移動のサポートを追加することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="625a5-336">Consider adding support for arrow key navigation when using the following controls:</span></span>

<table>
  <tr>
    <td>
      <p><img src="images/keyboard/dialog.png" alt="Dialog buttons"/></p>
      <p><span data-ttu-id="625a5-337"><sup>ダイアログのボタン</sup></span><span class="sxs-lookup"><span data-stu-id="625a5-337"><sup>Dialog buttons</sup></span></span></p>
      <p><img src="images/keyboard/radiobutton.png" alt="Radio buttons"/></p>
      <p><span data-ttu-id="625a5-338"><sup>オプション ボタン</sup></span><span class="sxs-lookup"><span data-stu-id="625a5-338"><sup>RadioButtons</sup></span></span></p>     
    </td>
    <td>
      <p><img src="images/keyboard/appbar.png" alt="AppBar buttons"/></p>
      <p><span data-ttu-id="625a5-339"><sup>AppBarButtons</sup></span><span class="sxs-lookup"><span data-stu-id="625a5-339"><sup>AppBarButtons</sup></span></span></p>
      <p><img src="images/keyboard/list-and-grid-items.png" alt="List and Grid items"/></p>
      <p><span data-ttu-id="625a5-340"><sup>リスト項目および GridItems</sup></span><span class="sxs-lookup"><span data-stu-id="625a5-340"><sup>ListItems and GridItems</sup></span></span></p>
    </td>    
  </tr>
</table>

#### <a name="tab-stops"></a><span data-ttu-id="625a5-341">タブ位置</span><span class="sxs-lookup"><span data-stu-id="625a5-341">Tab stops</span></span>

<span data-ttu-id="625a5-342">によって、アプリケーションの機能とレイアウト、コントロールのグループに最適なナビゲーション オプションに矢印ナビゲーションを子要素、複数のタブ ストップまたはいくつかの組み合わせを使用した 1 つのタブ ストップ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-342">Depending on your application's functionality and layout, the best navigation option for a control group might be a single tab stop with arrow navigation to child elements, multiple tab stops, or some combination.</span></span>

##### <a name="use-multiple-tab-stops-and-arrow-keys-for-buttons"></a><span data-ttu-id="625a5-343">ボタンに複数のタブ位置と方向キーを使う</span><span class="sxs-lookup"><span data-stu-id="625a5-343">Use multiple tab stops and arrow keys for buttons</span></span>

<span data-ttu-id="625a5-344">アクセシビリティ ユーザーは、通常はボタンのコレクションの移動に方向キーを使わない、実績のあるキーボード ナビゲーション ルールに依存しています。</span><span class="sxs-lookup"><span data-stu-id="625a5-344">Accessibility users rely on well-established keyboard navigation rules, which do not typically use arrow keys to navigate a collection of buttons.</span></span> <span data-ttu-id="625a5-345">ただし、視覚に障碍のないユーザーは、動作が自然であると感じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-345">However, users without visual impairments might feel that the behavior is natural.</span></span>

<span data-ttu-id="625a5-346">この場合、既定の UWP の動作の例は `ContentDialog` です。</span><span class="sxs-lookup"><span data-stu-id="625a5-346">An example of default UWP behavior in this case is the `ContentDialog`.</span></span> <span data-ttu-id="625a5-347">方向キーはボタン間の移動に使うことができますが、各ボタンはタブ位置でもあります。</span><span class="sxs-lookup"><span data-stu-id="625a5-347">While arrow keys can be used to navigate between buttons, each button is also a tab stop.</span></span>

##### <a name="assign-single-tab-stop-to-familiar-ui-patterns"></a><span data-ttu-id="625a5-348">使い慣れた UI パターンに 1 つのタブ位置を割り当てる</span><span class="sxs-lookup"><span data-stu-id="625a5-348">Assign single tab stop to familiar UI patterns</span></span>

<span data-ttu-id="625a5-349">レイアウトがコントロール グループのよく知られている UI パターンに従っている場合、グループに 1 つのタブ位置を割り当てるとユーザーのナビゲーション効率を向上することがあります。</span><span class="sxs-lookup"><span data-stu-id="625a5-349">In cases where your layout follows a well-known UI pattern for control groups, assigning a single tab stop to the group can improve navigation efficiency for users.</span></span>

<span data-ttu-id="625a5-350">たとえば、次のものがあります。</span><span class="sxs-lookup"><span data-stu-id="625a5-350">Examples include:</span></span>
-   `RadioButtons`
-   <span data-ttu-id="625a5-351">複数`ListViews`のようになり、1 つのように動作します。 `ListView`</span><span class="sxs-lookup"><span data-stu-id="625a5-351">Multiple `ListViews` that look like and behave like a single `ListView`</span></span>
-   <span data-ttu-id="625a5-352">タイルのグリッドと外観や動作が似ている UI (スタート メニューのタイルなど)</span><span class="sxs-lookup"><span data-stu-id="625a5-352">Any UI made to look and behave like grid of tiles (such as the Start menu tiles)</span></span>

#### <a name="specifying-control-group-behavior"></a><span data-ttu-id="625a5-353">コントロール グループの動作を指定する</span><span class="sxs-lookup"><span data-stu-id="625a5-353">Specifying control group behavior</span></span>

<span data-ttu-id="625a5-354">カスタム コントロール グループの動作は、以下の API を使ってサポートします (すべてこのトピックの後半で詳しく説明します)。</span><span class="sxs-lookup"><span data-stu-id="625a5-354">Use the following APIs to support custom control group behavior (all are discussed in more detail later in this topic):</span></span>

-   <span data-ttu-id="625a5-355">[XYFocusKeyboardNavigation](focus-navigation.md#2d-directional-navigation-for-keyboard) は、コントロール間での方向キー ナビゲーションを可能にします。</span><span class="sxs-lookup"><span data-stu-id="625a5-355">[XYFocusKeyboardNavigation](focus-navigation.md#2d-directional-navigation-for-keyboard) enables arrow key navigation between controls</span></span>
-   <span data-ttu-id="625a5-356">[TabFocusNavigation](focus-navigation.md#tab-navigation) は、タブ位置が複数か 1 つかを示します。</span><span class="sxs-lookup"><span data-stu-id="625a5-356">[TabFocusNavigation](focus-navigation.md#tab-navigation) indicates whether there are multiple tab stops or single tab stop</span></span>
-   <span data-ttu-id="625a5-357">[FindFirstFocusableElement and FindLastFocusableElement](focus-navigation-programmatic.md#find-the-first-and-last-focusable-element) は、フォーカスを **Home** キーによって最初の項目に、**End** キーによって最後の項目に設定します。</span><span class="sxs-lookup"><span data-stu-id="625a5-357">[FindFirstFocusableElement and FindLastFocusableElement](focus-navigation-programmatic.md#find-the-first-and-last-focusable-element) sets focus on the first item with **Home** key and the last item with **End** key</span></span>

<span data-ttu-id="625a5-358">次の図は、関連付けれらたラジオ ボタンのコントロール グループにおける直感的なキーボード ナビゲーションの動作を示しています。</span><span class="sxs-lookup"><span data-stu-id="625a5-358">The following image shows an intuitive keyboard navigation behavior for a control group of associated radio buttons.</span></span> <span data-ttu-id="625a5-359">この場合、コントロール グループの 1 つのタブ位置、方向キーを使ったラジオ ボタン間の内部ナビゲーション、最初のラジオ ボタンにバインドされた **Home** キー、最後のラジオ ボタンにバインドされた **End** キーをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="625a5-359">In this case, we recommend a single tab stop for the control group, inner navigation between the radio buttons using the arrow keys, **Home** key bound to the first radio button, and **End** key bound to the last radio button.</span></span>

![組み立てる](images/keyboard/putting-it-all-together.png)

### <a name="keyboard-and-narrator"></a><span data-ttu-id="625a5-361">キーボードとナレーター</span><span class="sxs-lookup"><span data-stu-id="625a5-361">Keyboard and Narrator</span></span>

<span data-ttu-id="625a5-362">ナレーターは、キーボード ユーザーを対象に用意された UI アクセシビリティ ツールです (他の入力の種類もサポートされます)。</span><span class="sxs-lookup"><span data-stu-id="625a5-362">Narrator is a UI accessibility tool geared towards keyboard users (other input types are also supported).</span></span> <span data-ttu-id="625a5-363">ただし、ナレーター機能は UWP アプリによりサポートされているキーボード操作を上回るため、ナレーター用に UWP アプリを設計するときは特別な注意が必要です </span><span class="sxs-lookup"><span data-stu-id="625a5-363">However, Narrator functionality goes beyond the keyboard interactions supported by UWP apps and extra care is required when designing your UWP app for Narrator.</span></span> <span data-ttu-id="625a5-364">(ナレーターのユーザー エクスペリエンスについては、「[ナレーターの基本について](https://support.microsoft.com/help/22808/windows-10-narrator-learning-basics)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-364">(The [Narrator basics page](https://support.microsoft.com/help/22808/windows-10-narrator-learning-basics) guides you through the Narrator user experience.)</span></span>

<span data-ttu-id="625a5-365">UWP のキーボードの動作とナレーターによりサポートされている動作の違いには、以下のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="625a5-365">Some of the differences between UWP keyboard behaviors and those supported by Narrator include:</span></span>
-   <span data-ttu-id="625a5-366">標準的なキーボード ナビゲーションでは表示されない UI 要素にナビゲーションするための追加のキーの組み合わせ (CapsLock + 方向キーを使ってコントロール ラベルを読み上げるなど)。</span><span class="sxs-lookup"><span data-stu-id="625a5-366">Extra key combinations for navigation to UI elements that are not exposed through standard keyboard navigation, such as Caps lock + arrow keys to read control labels.</span></span>
-   <span data-ttu-id="625a5-367">無効な項目へのナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="625a5-367">Navigation to disabled items.</span></span> <span data-ttu-id="625a5-368">既定では、無効な項目は標準的なキーボード ナビゲーションによって表示されません。</span><span class="sxs-lookup"><span data-stu-id="625a5-368">By default, disabled items are not exposed through standard keyboard navigation.</span></span>
    -   <span data-ttu-id="625a5-369">UI の細かさに基づいてすばやくナビゲーションするための コントロール "ビュー"。</span><span class="sxs-lookup"><span data-stu-id="625a5-369">Control "views" for quicker navigation based on UI granularity.</span></span> <span data-ttu-id="625a5-370">ユーザーは、項目、文字、単語、行、段落、リンク、見出し、表、ランドマーク、および候補に移動できます。</span><span class="sxs-lookup"><span data-stu-id="625a5-370">Users can navigate to items, characters, word, lines, paragraphs, links, headings, tables, landmarks, and suggestions.</span></span> <span data-ttu-id="625a5-371">標準的なキーボード ナビゲーションでは、これらのオブジェクトが階層のないリストとして表示されるため、ショートカット キーがないとナビゲーションしにくくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-371">Standard keyboard navigation exposes these objects as a flat list, which might make navigation cumbersome unless you provide shortcut keys.</span></span>

#### <a name="case-study--autosuggestbox-control"></a><span data-ttu-id="625a5-372">ケース スタディ – AutoSuggestBox コントロール</span><span class="sxs-lookup"><span data-stu-id="625a5-372">Case Study – AutoSuggestBox control</span></span>

<span data-ttu-id="625a5-373">`AutoSuggestBox` の検索ボタンでは、ユーザーが **Enter** キーを押して検索クエリを送信できるため、Tab および方向キーを使って標準的なキーボード ナビゲーションにアクセスすることができません。</span><span class="sxs-lookup"><span data-stu-id="625a5-373">The search button for the `AutoSuggestBox` is not accessible to standard keyboard navigation using tab and arrow keys because the user can press the **Enter** key to submit the search query.</span></span> <span data-ttu-id="625a5-374">ただし、ユーザーが CapsLock + 方向キーを押すとナレーターを通じてアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="625a5-374">However, it is accessible through Narrator when the user presses Caps Lock + an arrow key.</span></span>

![自動提案のキーボード フォーカス](images/keyboard/auto-suggest-keyboard.png)

<span data-ttu-id="625a5-376">*キーボードとユーザー キーを押して、* ***Enter*** *検索クエリを送信するキー*</span><span class="sxs-lookup"><span data-stu-id="625a5-376">*With keyboard, users press the* ***Enter*** *key to submit search query*</span></span>

<table>
  <tr>
    <td>
      <p><img src="images/keyboard/auto-suggest-narrator-1.png" alt="autosuggest narrator focus"/></p>
      <p><span data-ttu-id="625a5-377"><em>ナレーターとユーザー キーを押して、 <strong>Enter</strong>検索クエリを送信するキー</em></span><span class="sxs-lookup"><span data-stu-id="625a5-377"><em>With Narrator, users press the <strong>Enter</strong> key to submit search query</em></span></span></p>
    </td>
    <td>
      <p><img src="images/keyboard/auto-suggest-narrator-2.png" alt="autosuggest narrator focus on search"/></p>
      <p><span data-ttu-id="625a5-378"><em>ナレーターでのユーザーは、検索ボタンを使用してアクセスすることも、 <strong>Caps Lock + 右方向キー</strong>、キーを押して<strong>領域</strong>キー</em></span><span class="sxs-lookup"><span data-stu-id="625a5-378"><em>With Narrator, users are also able to access the search button using the <strong>Caps Lock + Right arrow key</strong>, then pressing <strong>Space</strong> key</em></span></span></p>
    </td>
  </tr>
</table>

### <a name="keyboard-and-the-xbox-gamepad-and-remote-control"></a><span data-ttu-id="625a5-379">キーボードと Xbox ゲームパッドおよびリモコン</span><span class="sxs-lookup"><span data-stu-id="625a5-379">Keyboard and the Xbox gamepad and remote control</span></span>

<span data-ttu-id="625a5-380">Xbox のゲームパッドとリモコンは、UWP の多くのキーボード動作とエクスペリエンスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="625a5-380">Xbox gamepads and remote controls support many UWP keyboard behaviors and experiences.</span></span> <span data-ttu-id="625a5-381">ただし、キーボードで使用可能なさまざまなキー オプションが不足しているため、ゲームパッドとリモコンに多くのキーボード最適化がありません (リモコンはゲームパッドよりもさらに制限されます)。</span><span class="sxs-lookup"><span data-stu-id="625a5-381">However, due to the lack of various key options available on a keyboard, gamepad and remote control lack many keyboard optimizations (remote control is even more limited than gamepad).</span></span>

<span data-ttu-id="625a5-382">参照してください[ゲームパッドとリモート制御の相互作用](gamepad-and-remote-interactions.md)ゲームパッドとリモコン入力の UWP サポートの詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="625a5-382">See [Gamepad and remote control interactions](gamepad-and-remote-interactions.md) for more detail on UWP support for gamepad and remote control input.</span></span>

<span data-ttu-id="625a5-383">キーボード、ゲームパッド、リモコンにおける対応するキーの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="625a5-383">The following shows some key mappings between keyboard, gamepad, and remote control.</span></span>

| <span data-ttu-id="625a5-384">**キーボード**</span><span class="sxs-lookup"><span data-stu-id="625a5-384">**Keyboard**</span></span>  | <span data-ttu-id="625a5-385">**Gamepad**</span><span class="sxs-lookup"><span data-stu-id="625a5-385">**Gamepad**</span></span>                         | <span data-ttu-id="625a5-386">**リモート_コントロール**</span><span class="sxs-lookup"><span data-stu-id="625a5-386">**Remote control**</span></span>  |
|---------------|-------------------------------------|---------------------|
| <span data-ttu-id="625a5-387">Space</span><span class="sxs-lookup"><span data-stu-id="625a5-387">Space</span></span>         | <span data-ttu-id="625a5-388">A ボタン</span><span class="sxs-lookup"><span data-stu-id="625a5-388">A button</span></span>                            | <span data-ttu-id="625a5-389">[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="625a5-389">Select button</span></span>       |
| <span data-ttu-id="625a5-390">以下に</span><span class="sxs-lookup"><span data-stu-id="625a5-390">Enter</span></span>         | <span data-ttu-id="625a5-391">A ボタン</span><span class="sxs-lookup"><span data-stu-id="625a5-391">A button</span></span>                            | <span data-ttu-id="625a5-392">[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="625a5-392">Select button</span></span>       |
| <span data-ttu-id="625a5-393">Esc キー</span><span class="sxs-lookup"><span data-stu-id="625a5-393">Escape</span></span>        | <span data-ttu-id="625a5-394">B ボタン</span><span class="sxs-lookup"><span data-stu-id="625a5-394">B button</span></span>                            | <span data-ttu-id="625a5-395">[戻る] ボタン</span><span class="sxs-lookup"><span data-stu-id="625a5-395">Back button</span></span>         |
| <span data-ttu-id="625a5-396">Home/End</span><span class="sxs-lookup"><span data-stu-id="625a5-396">Home/End</span></span>      | <span data-ttu-id="625a5-397">なし</span><span class="sxs-lookup"><span data-stu-id="625a5-397">N/A</span></span>                                 | <span data-ttu-id="625a5-398">なし</span><span class="sxs-lookup"><span data-stu-id="625a5-398">N/A</span></span>                 |
| <span data-ttu-id="625a5-399">PageUp/PageDown</span><span class="sxs-lookup"><span data-stu-id="625a5-399">Page Up/Down</span></span>  | <span data-ttu-id="625a5-400">縦スクロールはトリガー ボタン、横スクロールはバンパー ボタン</span><span class="sxs-lookup"><span data-stu-id="625a5-400">Trigger button for vertical scroll, Bumper button for horizontal scroll</span></span>   | <span data-ttu-id="625a5-401">なし</span><span class="sxs-lookup"><span data-stu-id="625a5-401">N/A</span></span>                 |

<span data-ttu-id="625a5-402">ゲームパッドとリモコンを使う UWP アプリを設計する際に注意すべきいくつかキーの相違点は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="625a5-402">Some key differences you should be aware of when designing your UWP app for use with gamepad and remote control usage include:</span></span>
-   <span data-ttu-id="625a5-403">テキストを入力するには、ユーザーは A を押してテキスト コントロールをアクティブ化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-403">Text entry requires the user to press A to activate a text control.</span></span>
-   <span data-ttu-id="625a5-404">フォーカス ナビゲーションは、コントロール グループに限定されるわけではありません。ユーザーは、アプリ内のフォーカス可能な任意の UI 要素に自由に移動できます。</span><span class="sxs-lookup"><span data-stu-id="625a5-404">Focus navigation is not limited to control groups, users can navigate freely to any focusable UI element in the app.</span></span>

    <span data-ttu-id="625a5-405">**NOTE** フォーカスは、キーを押した方向にあるフォーカス可能な任意の UI 要素に移動できます。ただし、その要素がオーバーレイ UI にある場合や、[フォーカス エンゲージメント](gamepad-and-remote-interactions.md#focus-engagement)が指定されている場合 (A ボタンによってエンゲージ/エンゲージ解除されるまでフォーカスが領域に入ったり出たりすることができないため) を除きます。</span><span class="sxs-lookup"><span data-stu-id="625a5-405">**NOTE** Focus can move to any focusable UI element in the key press direction unless it is in an overlay UI or [focus engagement](gamepad-and-remote-interactions.md#focus-engagement) is specified, which prevents focus from entering/exiting a region until engaged/disengaged with the A button.</span></span> <span data-ttu-id="625a5-406">詳しくは、「[方向ナビゲーション](#directional-navigation)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="625a5-406">For more info, see the [directional navigation](#directional-navigation) section.</span></span>
-   <span data-ttu-id="625a5-407">コントロール間、および内部ナビゲーション用にフォーカスを移動するには、方向パッドと左スティックのボタンが使用されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-407">D-pad and left stick buttons are used to move focus between controls and for inner navigation.</span></span>

    <span data-ttu-id="625a5-408">**注** ゲームパッドとリモコンは、方向キーが押されたとき、同じ表示順序内にある項目のみ移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-408">**NOTE** Gamepad and remote control only navigate to items that are in the same visual order as the directional key pressed.</span></span> <span data-ttu-id="625a5-409">フォーカスを受け取ることができる後続の要素がない場合、その方向のナビゲーションは無効になります。</span><span class="sxs-lookup"><span data-stu-id="625a5-409">Navigation is disabled in that direction when there is no subsequent element that can receive focus.</span></span> <span data-ttu-id="625a5-410">状況によっては、キーボード ユーザーは必ずしもそのような制約を持っているわけではありません。</span><span class="sxs-lookup"><span data-stu-id="625a5-410">Depending on the situation, keyboard users do not always have that constraint.</span></span> <span data-ttu-id="625a5-411">詳しくは、「[組み込みキーボードの最適化](#built-in-keyboard-optimization)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="625a5-411">See the [Built in keyboard optimization](#built-in-keyboard-optimization) section for more info.</span></span>

#### <a name="directional-navigation"></a><span data-ttu-id="625a5-412">方向ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="625a5-412">Directional navigation</span></span>

<span data-ttu-id="625a5-413">方向ナビゲーションは、UWP [Focus Manager](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.FocusManager) ヘルパー クラスにより管理されます。このヘルパー クラスは、方向キーが押されたことを認識し (方向キー、方向パッド)、対応する視覚的な向きにフォーカスを移動しようとします。</span><span class="sxs-lookup"><span data-stu-id="625a5-413">Directional navigation is managed by a UWP [Focus Manager](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.FocusManager) helper class, which takes the directional key pressed (arrow key, D-pad) and attempts to move focus in the corresponding visual direction.</span></span>

<span data-ttu-id="625a5-414">キーボードでのアプリを選んだときとは異なり[マウス モード](gamepad-and-remote-interactions.md#mouse-mode)ゲームパッド、リモート制御のアプリケーション全体で方向ナビゲーションが適用されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-414">Unlike the keyboard, when an app opts out of [Mouse Mode](gamepad-and-remote-interactions.md#mouse-mode), directional navigation is applied across the entire application for gamepad and remote control.</span></span> <span data-ttu-id="625a5-415">参照してください[ゲームパッドとリモート制御の相互作用](gamepad-and-remote-interactions.md)方向ナビゲーションの最適化の詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="625a5-415">See [Gamepad and remote control interactions](gamepad-and-remote-interactions.md) for more detail on directional navigation optimization.</span></span>

<span data-ttu-id="625a5-416">**注**キーボードの Tab キーを使ったナビゲーションは、方向ナビゲーションとは見なされません。</span><span class="sxs-lookup"><span data-stu-id="625a5-416">**NOTE** Navigation using the keyboard Tab key is not considered directional navigation.</span></span> <span data-ttu-id="625a5-417">詳しくは、「[タブ位置](#tab-stops)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="625a5-417">For more info, see the [Tab stops](#tab-stops) section.</span></span>

<table>
  <tr>
    <td>
      <p><img src="images/keyboard/directional-navigation.png" alt="directional navigation"/></p>
      <p><span data-ttu-id="625a5-418"><em><strong>方向ナビゲーションがサポートされています</strong></span><span class="sxs-lookup"><span data-stu-id="625a5-418"><em><strong>Directional navigation supported</strong></span></span></br><span data-ttu-id="625a5-419">(キーボードの矢印、ゲームパッド、リモート_コントロール パッド) の方向キーを使用して、ユーザーがさまざまなコントロール間で移動できます。</em></span><span class="sxs-lookup"><span data-stu-id="625a5-419">Using directional keys (keyboard arrows, gamepad and remote control D-pad), user can navigate between different controls.</em></span></span></p>
    </td>
    <td>
      <p><img src="images/keyboard/no-directional-navigation.png" alt="no directional navigation"/></p>
      <p><span data-ttu-id="625a5-420"><em><strong>方向ナビゲーションがサポートされていません</strong> </span><span class="sxs-lookup"><span data-stu-id="625a5-420"><em><strong>Directional navigation not supported</strong> </span></span></br><span data-ttu-id="625a5-421">ユーザーは、方向キーを使ってコントロール間を移動することはできません。</span><span class="sxs-lookup"><span data-stu-id="625a5-421">User cannot navigate between different controls using directional keys.</span></span> <span data-ttu-id="625a5-422">(Tab キー) のコントロール間を移動するには、他のメソッドは影響ありません。</em></span><span class="sxs-lookup"><span data-stu-id="625a5-422">Other methods of navigating between controls (tab key) are not impacted.</em></span></span></p>
    </td>
  </tr>
</table>

### <a name="built-in-keyboard-optimization"></a><span data-ttu-id="625a5-423">キーボードの最適化に組み込まれています</span><span class="sxs-lookup"><span data-stu-id="625a5-423">Built in keyboard optimization</span></span>

<span data-ttu-id="625a5-424">使用されているレイアウトとコントロールによっては、特にキーボード入力に合わせて UWP アプリを最適化できます。</span><span class="sxs-lookup"><span data-stu-id="625a5-424">Depending on the layout and controls used, UWP apps can be optimized specifically for keyboard input.</span></span>

<span data-ttu-id="625a5-425">次の例は、1 つのタブ位置に割り当てられているリスト項目、グリッド項目、メニュー項目のグループを示しています (「[タブ位置](#tab-stops)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-425">The following example shows a group of list items, grid items, and menu items that have been assigned to a single tab stop (see the [Tab stops](#tab-stops) section).</span></span> <span data-ttu-id="625a5-426">グループにフォーカスがある場合、方向キーによって、対応する表示順序で内部ナビゲーションが実行されます (「[ナビゲーション」](#navigation)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-426">When the group has focus, inner navigation is performed with the directional arrow keys in the corresponding visual order (see [Navigation](#navigation) section).</span></span>

![単一列の方向キー ナビゲーション](images/keyboard/single-column-arrow.png)

<span data-ttu-id="625a5-428">***矢印キー ナビゲーションを 1 つの列***</span><span class="sxs-lookup"><span data-stu-id="625a5-428">***Single Column Arrow Key Navigation***</span></span>

![単一行の方向キー ナビゲーション](images/keyboard/single-row-arrow.png)

<span data-ttu-id="625a5-430">***1 つの行方向キーによる移動***</span><span class="sxs-lookup"><span data-stu-id="625a5-430">***Single Row Arrow Key Navigation***</span></span>

![複数列および行の方向キー ナビゲーション](images/keyboard/multiple-column-and-row-navigation.png)

<span data-ttu-id="625a5-432">***複数の列や行の矢印キー ナビゲーション***</span><span class="sxs-lookup"><span data-stu-id="625a5-432">***Multiple Column/Row Arrow Key Navigation***</span></span>

#### <a name="wrapping-homogeneous-list-and-grid-view-items"></a><span data-ttu-id="625a5-433">同種のリスト項目およびグリッド ビュー項目の折り返し</span><span class="sxs-lookup"><span data-stu-id="625a5-433">Wrapping homogeneous List and Grid View Items</span></span>

<span data-ttu-id="625a5-434">List 項目と GridView 項目の複数の行と列を移動する場合、必ずしも方向ナビゲーションが最も効率的な方法とは限りません。</span><span class="sxs-lookup"><span data-stu-id="625a5-434">Directional navigation is not always the most efficient way to navigate multiple rows and columns of List and GridView items.</span></span>

<span data-ttu-id="625a5-435">**注** メニュー項目は通常単一列のリストですが、場合によっては特別なフォーカス ルールが適用されることがあります (「[ポップアップ UI](#popup-ui)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="625a5-435">**NOTE** Menu items are typically single column lists, but special focus rules might apply in some cases (see [Popup UI](#popup-ui)).</span></span>

<span data-ttu-id="625a5-436">リスト オブジェクトとグリッド オブジェクトは複数の行と列を使って作成されることがあります。</span><span class="sxs-lookup"><span data-stu-id="625a5-436">List and Grid objects can be created with multiple rows and columns.</span></span> <span data-ttu-id="625a5-437">このようなオブジェクトには通常、行優先順序 (まず項目が行全体に入力されてから、次の行に入力される) または列優先順序 (まず項目が列全体に入力されてから次の列に入力される) が適用されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-437">These are typically in row-major (where items fill entire row first before filling in the next row) or column-major (where items fill entire column first before filling in the next column) order.</span></span> <span data-ttu-id="625a5-438">行または列優先順序は、スクロールの方向によって決まり、項目の順序がこの方向と競合しないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-438">Row or column major order depends on scroll direction and you should ensure that item order does not conflict with this direction.</span></span>

<span data-ttu-id="625a5-439">行優先順序 (項目が左から右、上から下に入力される) では、フォーカスが行内の最後の項目に置かれて右方向キーが押されると、フォーカスは次の行の最初の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-439">In row-major order (where items fill in left to right, top to bottom), when the focus is on the last item in a row and the Right arrow key is pressed, focus is moved to the first item in the next row.</span></span> <span data-ttu-id="625a5-440">これと同じ動作が逆の順序で発生します。行の最初の項目にフォーカスが設定し、左方向キーを押すと、フォーカスは移動最後の項目の前の行でします。</span><span class="sxs-lookup"><span data-stu-id="625a5-440">This same behavior occurs in reverse: When focus is set to the first item in a row and the Left arrow key is pressed, focus is moved to the last item in the previous row.</span></span>

<span data-ttu-id="625a5-441">列優先順序 (項目が上から下、左から右に入力される) では、フォーカスが列内の最後に項目に置かれて、ユーザーが下方向キーを押すと、フフォーカスが次の列の最初の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-441">In column-major order (where items fill in top to bottom, left to right), when the focus is on the last item in a column and user presses the Down arrow key, focus is moved to the first item in the next column.</span></span> <span data-ttu-id="625a5-442">これと同じ動作が逆の順序で発生します。列の最初の項目にフォーカスが設定し、上向きの矢印キーを押すと、フォーカスは移動最後の項目、前回のコラムでします。</span><span class="sxs-lookup"><span data-stu-id="625a5-442">This same behavior occurs in reverse: When focus is set to the first item in a column and the Up arrow key is pressed, focus is moved to the last item in the previous column.</span></span>

<table>
  <tr>
    <td>
      <p><img src="images/keyboard/row-major-keyboard.png" alt="row major keyboard navigation"/></p>
      <p><span data-ttu-id="625a5-443"><em>行の主なキーボード ナビゲーション</em></span><span class="sxs-lookup"><span data-stu-id="625a5-443"><em>Row major keyboard navigation</em></span></span></p>
    </td>
    <td>
      <p><img src="images/keyboard/column-major-keyboard.png" alt="column major keyboard navigation"/></p>
      <p><span data-ttu-id="625a5-444"><em>列の主なキーボード ナビゲーション</em></span><span class="sxs-lookup"><span data-stu-id="625a5-444"><em>Column major keyboard navigation</em></span></span></p>
    </td>
  </tr>
</table>

#### <a name="popup-ui"></a><span data-ttu-id="625a5-445">ポップアップ UI</span><span class="sxs-lookup"><span data-stu-id="625a5-445">Popup UI</span></span>

<span data-ttu-id="625a5-446">前述のように、方向ナビゲーションは、アプリケーションの UI コントロールの視覚的な順序に対応することを確認しようとする必要があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-446">As mentioned, you should try to ensure directional navigation corresponds to the visual order of the controls in your application's UI.</span></span>

<span data-ttu-id="625a5-447">ContextMenu、AppBarOverflowMenu、AutoSuggest などのいくつかのコントロールには、場所と (可能な画面領域に基づく) プライマリ コントロールに対する相対的な方向に表示されるメニュー ポップアップが含まれます。</span><span class="sxs-lookup"><span data-stu-id="625a5-447">Some controls, such as ContextMenu, AppBarOverflowMenu, and AutoSuggest, include a menu popup that is displayed in a location and direction relative to the primary control (based on available screen space).</span></span> <span data-ttu-id="625a5-448">たとえば、メニューが下方向 (既定の方向) に開くのに十分な領域がない場合は、上方向に開きます。</span><span class="sxs-lookup"><span data-stu-id="625a5-448">For example, when there is insufficient space for the menu to open downwards (the default direction), it opens upwards.</span></span> <span data-ttu-id="625a5-449">メニューが毎回同じ方向に表示されるという保証はありません。</span><span class="sxs-lookup"><span data-stu-id="625a5-449">There is no guarantee that the menu opens in the same direction every time.</span></span>

<table>
  <td><img src="images/keyboard/command-bar-open-down.png" alt="command bar opens down with down arrow key" /></td>
  <td><img src="images/keyboard/command-bar-open-up.png" alt="command bar opens up with down arrow key" /></td>
</table>

<span data-ttu-id="625a5-450">これらのコントロールでは、メニューが最初に開かれたとき (ユーザーによって項目が選択されていない状態)、下方向キーは常に最初の項目にフォーカスを設定し、上方向キーは常にフォーカスをメニューの最後の項目に設定します。</span><span class="sxs-lookup"><span data-stu-id="625a5-450">For these controls, when the menu is first opened (and no item has been selected by the user), the Down arrow key always sets focus to the first item and the Up arrow key always sets focus to the last item on the menu.</span></span> <span data-ttu-id="625a5-451">同様に、最後の項目が選択されて下方向キーが押されると、フォーカスはメニューの最初の項目に移動し、最初の項目が選択されて上方向キーが押されると、フォーカスはメニューの最後の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="625a5-451">Similarly, when the last item is selected and the Down arrow key is pressed, focus moves to the first item on the menu and when the first item is selected and the Up arrow key is pressed, focus moves to the last item on the menu.</span></span>

<span data-ttu-id="625a5-452">これと同じ動作をカスタム コントロールでエミュレートしてみてください。</span><span class="sxs-lookup"><span data-stu-id="625a5-452">You should try to emulate these same behaviors in your custom controls.</span></span> <span data-ttu-id="625a5-453">この動作を実装する方法のコード サンプルが記載[プログラムによるフォーカスのナビゲーション](focus-navigation-programmatic.md#find-the-first-and-last-focusable-element)ドキュメント。</span><span class="sxs-lookup"><span data-stu-id="625a5-453">Code sample on how to implement this behavior can be found in [Programmatic focus navigation](focus-navigation-programmatic.md#find-the-first-and-last-focusable-element) documentation.</span></span>

## <a name="test-your-app"></a><span data-ttu-id="625a5-454">アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="625a5-454">Test your app</span></span>

<span data-ttu-id="625a5-455">サポートされているすべての入力デバイスを使ってアプリをテストし、UI 要素が一貫した直感的な方法で移動できることと、要素と目的のタブ位置の予期しない干渉がないことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="625a5-455">Test your app with all supported input devices to ensure UI elements can be navigated to in a coherent and intuitive way and that no unexpected elements interfere with the desired tab order.</span></span>

## <a name="related-articles"></a><span data-ttu-id="625a5-456">関連記事</span><span class="sxs-lookup"><span data-stu-id="625a5-456">Related articles</span></span>
* [<span data-ttu-id="625a5-457">キーボード イベント</span><span class="sxs-lookup"><span data-stu-id="625a5-457">Keyboard events</span></span>](keyboard-events.md)
* [<span data-ttu-id="625a5-458">入力デバイスの識別</span><span class="sxs-lookup"><span data-stu-id="625a5-458">Identify input devices</span></span>](identify-input-devices.md)
* [<span data-ttu-id="625a5-459">タッチ キーボードの存在に応答します。</span><span class="sxs-lookup"><span data-stu-id="625a5-459">Respond to the presence of the touch keyboard</span></span>](respond-to-the-presence-of-the-touch-keyboard.md)
* [<span data-ttu-id="625a5-460">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="625a5-460">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

## <a name="appendix"></a><span data-ttu-id="625a5-461">付録</span><span class="sxs-lookup"><span data-stu-id="625a5-461">Appendix</span></span>

### <a name="software-keyboard"></a><span data-ttu-id="625a5-462">ソフトウェアのキーボード</span><span class="sxs-lookup"><span data-stu-id="625a5-462">Software keyboard</span></span>

<span data-ttu-id="625a5-463">ソフトウェア キーボードは、物理的なキーボードの代わりにユーザーが使うことができる画面上のキーボードです。タッチ、マウス、ペン/スタイラス、またはその他のポインティング デバイスを通じてデータを入力します (タッチ スクリーンは必須ではありません)。</span><span class="sxs-lookup"><span data-stu-id="625a5-463">Software keyboard is a keyboard that is displayed on screen that user can use instead of the physical keyboard to type and enter data using touch, mouse, pen/stylus or other pointing device (a touch screen is not required).</span></span> <span data-ttu-id="625a5-464">タッチ画面では、これらのキーボードを直接タッチしてテキストを入力することもできます。</span><span class="sxs-lookup"><span data-stu-id="625a5-464">On touch screen, these keyboards can be touched directly to enter text as well.</span></span> <span data-ttu-id="625a5-465">Xbox One デバイスでは、ゲームパッドやリモコンを使ってフォーカス表示を移動したりショートカット キーを使ったりすることで、個々のキーを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="625a5-465">On Xbox One devices, individual keys need to be selected by moving focus visual or using shortcut keys using gamepad or remote control.</span></span>

![Windows 10 のタッチ キーボード](images/keyboard/default.png)

<span data-ttu-id="625a5-467">***Windows 10 タッチ キーボード***</span><span class="sxs-lookup"><span data-stu-id="625a5-467">***Windows 10 Touch Keyboard***</span></span>

![Xbox One のスクリーン キーボード](images/keyboard/xbox-onscreen-keyboard.png)

<span data-ttu-id="625a5-469">***Xbox One スクリーン キーボード***</span><span class="sxs-lookup"><span data-stu-id="625a5-469">***Xbox One Onscreen Keyboard***</span></span>

<span data-ttu-id="625a5-470">デバイスに応じて、ソフトウェア キーボードは、テキスト フィールドやその他の編集可能なテキスト コントロールがフォーカスを取得したとき、またはユーザーが**通知センター**で手動でタッチ キーボードを有効にしたときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="625a5-470">Depending on the device, the software keyboard appears when a text field or other editable text control gets focus, or when the user manually enables it through the **Notification Center**:</span></span>

![通知センターでのタッチ キーボードのアイコン](images/keyboard/touch-keyboard-notificationcenter.png)

<span data-ttu-id="625a5-472">テキスト入力コントロールへのフォーカスをプログラムで設定するアプリの場合、タッチ キーボードは呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="625a5-472">If your app sets focus programmatically to a text input control, the touch keyboard is not invoked.</span></span> <span data-ttu-id="625a5-473">これにより、ユーザーの直接的な操作による予期しない動作を回避できます。</span><span class="sxs-lookup"><span data-stu-id="625a5-473">This eliminates unexpected behaviors not instigated directly by the user.</span></span> <span data-ttu-id="625a5-474">ただし、プログラムによってキーボードがテキスト入力コントロール以外に移動されると、キーボードが自動的に非表示になります。</span><span class="sxs-lookup"><span data-stu-id="625a5-474">However, the keyboard does automatically hide when focus is moved programmatically to a non-text input control.</span></span>

<span data-ttu-id="625a5-475">通常、ユーザーがフォームでコントロール間を移動している間は、タッチ キーボードは表示されたままです。</span><span class="sxs-lookup"><span data-stu-id="625a5-475">The touch keyboard typically remains visible while the user navigates between controls in a form.</span></span> <span data-ttu-id="625a5-476">この動作は、フォーム内の他のコントロールの種類に基づいて異なります。</span><span class="sxs-lookup"><span data-stu-id="625a5-476">This behavior can vary based on the other control types within the form.</span></span>

<span data-ttu-id="625a5-477">タッチ キーボードを使用するテキスト入力セッション中に、キーボードを閉じずにフォーカスを受け取ることができる非編集コントロールの一覧を次に示します。</span><span class="sxs-lookup"><span data-stu-id="625a5-477">The following is a list of non-edit controls that can receive focus during a text entry session using the touch keyboard without dismissing the keyboard.</span></span> <span data-ttu-id="625a5-478">ユーザーがこれらのコントロールとタッチ キーボードによるテキスト入力との間で何度も行き来することが考えられるため、UI の表示を不必要に切り替えてユーザーを混乱させることのないよう、タッチ キーボードは表示されたままになります。</span><span class="sxs-lookup"><span data-stu-id="625a5-478">Rather than needlessly churn the UI and potentially disorient the user, the touch keyboard remains in view because the user is likely to go back and forth between these controls and text entry with the touch keyboard.</span></span>

-   <span data-ttu-id="625a5-479">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="625a5-479">Check box</span></span>
-   <span data-ttu-id="625a5-480">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="625a5-480">Combo box</span></span>
-   <span data-ttu-id="625a5-481">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="625a5-481">Radio button</span></span>
-   <span data-ttu-id="625a5-482">スクロール バー</span><span class="sxs-lookup"><span data-stu-id="625a5-482">Scroll bar</span></span>
-   <span data-ttu-id="625a5-483">ツリー</span><span class="sxs-lookup"><span data-stu-id="625a5-483">Tree</span></span>
-   <span data-ttu-id="625a5-484">ツリー項目</span><span class="sxs-lookup"><span data-stu-id="625a5-484">Tree item</span></span>
-   <span data-ttu-id="625a5-485">Menu</span><span class="sxs-lookup"><span data-stu-id="625a5-485">Menu</span></span>
-   <span data-ttu-id="625a5-486">メニュー バー</span><span class="sxs-lookup"><span data-stu-id="625a5-486">Menu bar</span></span>
-   <span data-ttu-id="625a5-487">メニュー項目</span><span class="sxs-lookup"><span data-stu-id="625a5-487">Menu item</span></span>
-   <span data-ttu-id="625a5-488">ツール バー</span><span class="sxs-lookup"><span data-stu-id="625a5-488">Toolbar</span></span>
-   <span data-ttu-id="625a5-489">一覧</span><span class="sxs-lookup"><span data-stu-id="625a5-489">List</span></span>
-   <span data-ttu-id="625a5-490">一覧項目</span><span class="sxs-lookup"><span data-stu-id="625a5-490">List item</span></span>

<span data-ttu-id="625a5-491">次に、タッチ キーボードのさまざまなモードの例を示します。</span><span class="sxs-lookup"><span data-stu-id="625a5-491">Here are examples of different modes for the touch keyboard.</span></span> <span data-ttu-id="625a5-492">最初の画像は既定のレイアウトであり、2 つ目の画像は親指レイアウトです (一部の言語では利用できません)。</span><span class="sxs-lookup"><span data-stu-id="625a5-492">The first image is the default layout, the second is the thumb layout (which might not be available in all languages).</span></span>

![既定のレイアウト モードのタッチ キーボード](images/keyboard/default.png)

<span data-ttu-id="625a5-494">***既定のキーボード、タッチのレイアウト モード***</span><span class="sxs-lookup"><span data-stu-id="625a5-494">***The touch keyboard in default layout mode***</span></span>

![拡張レイアウト モードのタッチ キーボード](images/keyboard/extendedview.png)

<span data-ttu-id="625a5-496">***展開されたレイアウト モードでタッチ キーボード***</span><span class="sxs-lookup"><span data-stu-id="625a5-496">***The touch keyboard in expanded layout mode***</span></span>

<span data-ttu-id="625a5-497">キーボード操作に成功すると、ユーザーはキーボードのみを使って基本のアプリ シナリオを実行できます。つまり、ユーザーはすべての対話型要素にアクセスし、既定の機能をアクティブにすることができます。</span><span class="sxs-lookup"><span data-stu-id="625a5-497">Successful keyboard interactions enable users to accomplish basic app scenarios using only the keyboard; that is, users can reach all interactive elements and activate default functionality.</span></span> <span data-ttu-id="625a5-498">成功の度合いには、キーボード ナビゲーション、アクセシビリティ対応のアクセス キー、上級ユーザー用のアクセラレータ (ショートカット) キーなど、さまざまな要因が影響します。</span><span class="sxs-lookup"><span data-stu-id="625a5-498">A number of factors can affect the degree of success, including keyboard navigation, access keys for accessibility, and accelerator (or shortcut) keys for advanced users.</span></span>

<span data-ttu-id="625a5-499">**注**  タッチ キーボードが切り替えとシステムのほとんどのコマンドをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="625a5-499">**NOTE**  The touch keyboard does not support toggle and most system commands.</span></span>

#### <a name="on-screen-keyboard"></a><span data-ttu-id="625a5-500">スクリーン キーボード</span><span class="sxs-lookup"><span data-stu-id="625a5-500">On-Screen Keyboard</span></span>
<span data-ttu-id="625a5-501">ソフトウェア キーボードと同様、スクリーン キーボードは、物理的なキーボードの代わりに使うことができる視覚的なソフトウェア キーボードです。タッチ、マウス、ペン/スタイラス、またはその他のポインティング デバイスを通じてデータを入力します (タッチ スクリーンは必須ではありません)。</span><span class="sxs-lookup"><span data-stu-id="625a5-501">Like software keyboard, the On-Screen Keyboard is a visual, software keyboard that you can use instead of the physical keyboard to type and enter data using touch, mouse, pen/stylus or other pointing device (a touch screen is not required).</span></span> <span data-ttu-id="625a5-502">スクリーン キーボードは、物理的なキーボードが存在しないシステムや、運動障碍により一般的な物理入力デバイスを使うことができないユーザーのために用意されています。</span><span class="sxs-lookup"><span data-stu-id="625a5-502">The On-Screen Keyboard is provided for systems that don't have a physical keyboard, or for users whose mobility impairments prevent them from using traditional physical input devices.</span></span> <span data-ttu-id="625a5-503">スクリーン キーボードは、ハードウェア キーボードの機能のすべて、または少なくともほとんどをエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="625a5-503">The On-Screen Keyboard emulates most, if not all, the functionality of a hardware keyboard.</span></span>

<span data-ttu-id="625a5-504">スクリーン キーボードは、[設定] &gt; [簡単操作] の [キーボード] ページから有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="625a5-504">The On-Screen Keyboard can be turned on from the Keyboard page in Settings &gt; Ease of access.</span></span>

<span data-ttu-id="625a5-505">**注** スクリーン キーボードの方がタッチ キーボードより優先され、スクリーン キーボードが表示されている場合はタッチ キーボードは表示されません。</span><span class="sxs-lookup"><span data-stu-id="625a5-505">**NOTE** The On-Screen Keyboard has priority over the touch keyboard, which won't be shown if the On-Screen Keyboard is present.</span></span>

![スクリーン キーボード](images/keyboard/osk.png)

<span data-ttu-id="625a5-507">***スクリーン キーボード***</span><span class="sxs-lookup"><span data-stu-id="625a5-507">***On-Screen Keyboard***</span></span>

<span data-ttu-id="625a5-508">スクリーン キーボードについて詳しくは、[スクリーン キーボードに関するページ](https://support.microsoft.com/help/10762/windows-use-on-screen-keyboard)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="625a5-508">Visit [On-Screen keyboard page](https://support.microsoft.com/help/10762/windows-use-on-screen-keyboard) for more details about On-Screen Keyboard.</span></span>

## <a name="related-articles"></a><span data-ttu-id="625a5-509">関連記事</span><span class="sxs-lookup"><span data-stu-id="625a5-509">Related articles</span></span>

- [<span data-ttu-id="625a5-510">キーボードのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="625a5-510">Keyboard accessibility</span></span>](../accessibility/keyboard-accessibility.md)
