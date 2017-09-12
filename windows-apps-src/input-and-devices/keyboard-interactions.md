---
author: Karl-Bridge-Microsoft
Description: "キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に考えられる最適なエクスペリエンスを提供できるように、UWP アプリを最適化する方法について説明します。"
title: "キーボード操作"
ms.assetid: FF819BAC-67C0-4EC9-8921-F087BE188138
label: Keyboard interactions
template: detail.hbs
keywords: "キーボード, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作, ゲームパッド, リモート"
ms.author: kbridge
ms.date: 03/29/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
pm-contact: chigy
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.openlocfilehash: 22a95cfb77740d7521c62f0b7153130ccdc1b552
ms.sourcegitcommit: ba0d20f6fad75ce98c25ceead78aab6661250571
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/24/2017
---
# <a name="keyboard-interactions"></a><span data-ttu-id="c575f-104">キーボード操作</span><span class="sxs-lookup"><span data-stu-id="c575f-104">Keyboard interactions</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

![キーボードのヒーロー画像](images/keyboard/keyboard-hero.jpg)

<span data-ttu-id="c575f-106">キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に考えられる最適なエクスペリエンスを提供できるように、UWP アプリを最適化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c575f-106">Learn how to design and optimize your UWP apps so they provide the best experience possible for both keyboard power users and those with disabilities and other accessibility requirements.</span></span>

<span data-ttu-id="c575f-107">さまざまなデバイスを使う場合、キーボード入力はユニバーサル Windows プラットフォーム (UWP) の全体的な対話式操作エクスペリエンスの重要な部分を占めます。</span><span class="sxs-lookup"><span data-stu-id="c575f-107">Across devices, keyboard input is an important part of the overall Universal Windows Platform (UWP) interaction experience.</span></span> <span data-ttu-id="c575f-108">適切に設計されたキーボード エクスペリエンスがあれば、ユーザーが効率的にアプリの UI を移動し、手を持ち上げなくてもそのすべての機能にキーボードからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="c575f-108">A well-designed keyboard experience lets users efficiently navigate the UI of your app and access its full functionality without ever lifting their hands from the keyboard.</span></span>

![キーボードとゲームパッドのイメージ](images/keyboard/keyboard-gamepad.jpg)

***<span data-ttu-id="c575f-110">一般的な対話式操作パターンは、キーボードとゲームパッドの間で共有されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-110">Common interaction patterns are shared between keyboard and gamepad</span></span>***

<span data-ttu-id="c575f-111">このトピックでは、PC におけるキーボード入力の UWP アプリの設計について重点的に説明します。</span><span class="sxs-lookup"><span data-stu-id="c575f-111">In this topic, we focus specifically on UWP app design for keyboard input on PCs.</span></span> <span data-ttu-id="c575f-112">ただし、適切に設計されたキーボード エクスペリエンスは、Windows ナレーターなどのアクセシビリティ ツールをサポートするため、[タッチ キーボード](#touch-keyboard)や[スクリーン キーボード (OSK)](#osk) などのソフトウェア キーボードを使うため、Xbox ゲームパッドやリモコンなどの他の入力デバイスの種類を処理するために重要です。</span><span class="sxs-lookup"><span data-stu-id="c575f-112">However, a well-designed keyboard experience is important for supporting accessibility tools such as Windows Narrator, using software keyboards such as the [touch keyboard](#touch-keyboard) and the [On-Screen Keyboard (OSK)](#osk), and for handling other input device types, such as the Xbox gamepad and remote control.</span></span>

<span data-ttu-id="c575f-113">[フォーカスの視覚効果](#focus-visual)、[アクセス キー](#access-keys)、[UI ナビゲーション](#navigation) など、ここで説明するガイドラインと推奨事項の多くは、これらの他のシナリオにも当てはまります。</span><span class="sxs-lookup"><span data-stu-id="c575f-113">Many of the guidelines and recommendations discussed here, including [focus visuals](#focus-visual), [access keys](#access-keys), and [UI navigation](#navigation), are also applicable to these other scenarios.</span></span>

<span data-ttu-id="c575f-114">**注:**  テキスト入力はハードウェア キーボードとソフトウェア キーボードの両方に使用されますが、このトピックではナビゲーションと対話式操作に焦点を当てます。</span><span class="sxs-lookup"><span data-stu-id="c575f-114">**NOTE**  While both hardware and software keyboards are used for text input, the focus of this topic is navigation and interaction.</span></span>

## <a name="built-in-support"></a><span data-ttu-id="c575f-115">組み込みサポート</span><span class="sxs-lookup"><span data-stu-id="c575f-115">Built-in support</span></span>

<span data-ttu-id="c575f-116">マウスと共に、キーボードは PC で最もよく使われている周辺機器であるため、PC のエクスペリエンスの基本となる部分です。</span><span class="sxs-lookup"><span data-stu-id="c575f-116">Along with the mouse, the keyboard is the most widely used peripheral on PCs and, as such, is a fundamental part of the PC experience.</span></span> <span data-ttu-id="c575f-117">PC ユーザーは、キーボード入力への応答として、システムと個々のアプリの両方から総合的で一貫性のあるエクスペリエンスがあることを期待します。</span><span class="sxs-lookup"><span data-stu-id="c575f-117">PC users expect a comprehensive and consistent experience from both the system and individual apps in response to keyboard input.</span></span>

<span data-ttu-id="c575f-118">すべての UWP コントロールには、キーボードの豊富なエクスペリエンスとユーザー操作の組み込みサポートが含まれていますが、プラットフォーム自体にはカスタム コントロールとアプリの両方で最適と感じるキーボード エクスペリエンスを生み出すための広範な基盤が用意されています。</span><span class="sxs-lookup"><span data-stu-id="c575f-118">All UWP controls include built-in support for rich keyboard experiences and user interactions, while the platform itself provides an extensive foundation for creating keyboard experiences that you feel are best suited to both your custom controls and apps.</span></span>

![キーボードと携帯電話の画像](images/keyboard/keyboard-phone.jpg)

***<span data-ttu-id="c575f-120">UWP は、あらゆるデバイスのキーボードをサポートします</span><span class="sxs-lookup"><span data-stu-id="c575f-120">UWP supports keyboard with any device</span></span>***

## <a name="basic-experiences"></a><span data-ttu-id="c575f-121">基本的なエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="c575f-121">Basic experiences</span></span>
![フォーカス ベースのデバイス](images/keyboard/focus-based-devices.jpg)

<span data-ttu-id="c575f-123">前述のように、Xbox ゲームパッドやリモコンなどの入力デバイスと、ナレーターなどのアクセシビリティ ツールは、ナビゲーションとコマンド実行においてキーボードの入力エクスペリエンスの大半を共有します。</span><span class="sxs-lookup"><span data-stu-id="c575f-123">As mentioned previously, input devices such as the Xbox gamepad and remote control, and accessibility tools such as Narrator, share much of the keyboard input experience for navigation and commanding.</span></span> <span data-ttu-id="c575f-124">入力の種類とツールが異なってもエクスペリエンスが共通であれば、ユーザーの追加作業は最小限に抑えられ、ユニバーサル Windows プラットフォームの "1 回のビルドで、どこでも実行可能" という目標に貢献します。</span><span class="sxs-lookup"><span data-stu-id="c575f-124">This common experience across input types and tools minimizes additional work from you and contributes to the "build once, run anywhere" goal of the Universal Windows Platform.</span></span>

<span data-ttu-id="c575f-125">必要に応じて、注意すべき主な違いを取り上げ、考慮する必要がある軽減策について説明します。</span><span class="sxs-lookup"><span data-stu-id="c575f-125">Where necessary, we’ll identify key differences you should be aware of and describe any mitigations you should consider.</span></span>

<span data-ttu-id="c575f-126">このトピックで説明するデバイスとツールを次に示します。</span><span class="sxs-lookup"><span data-stu-id="c575f-126">Here are the devices and tools discussed in this topic:</span></span>

| <span data-ttu-id="c575f-127">デバイス/ツール</span><span class="sxs-lookup"><span data-stu-id="c575f-127">Device/tool</span></span>                       | <span data-ttu-id="c575f-128">説明</span><span class="sxs-lookup"><span data-stu-id="c575f-128">Description</span></span>     |
|-----------------------------------|-----------------|
|<span data-ttu-id="c575f-129">キーボード (ハードウェアおよびソフトウェア)</span><span class="sxs-lookup"><span data-stu-id="c575f-129">Keyboard (hardware and software)</span></span>   |<span data-ttu-id="c575f-130">UWP アプリは、標準的なハードウェア キーボードに加えて、[タッチ (つまりソフトウェア キーボード)](#touch-keyboard) と[スクリーン キーボード](#osk)の 2 つのソフトウェア キーボードをサポートします。</span><span class="sxs-lookup"><span data-stu-id="c575f-130">In addition to the standard hardware keyboard, UWP apps support two software keyboards: the [touch (or software keyboard)](#touch-keyboard) and the [On-Screen Keyboard](#osk).</span></span>|
|<span data-ttu-id="c575f-131">ゲームパッドとリモコン</span><span class="sxs-lookup"><span data-stu-id="c575f-131">Gamepad and remote control</span></span>         |<span data-ttu-id="c575f-132">Xbox のゲームパッドとリモコンは、[10 フィート エクスペリエンス](designing-for-tv.md)における基本的な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="c575f-132">The Xbox gamepad and remote control are fundamental input devices in the [10-foot experience](designing-for-tv.md).</span></span>
<span data-ttu-id="c575f-133">UWP におけるゲームパッドとリモコンのサポートについて詳しくは、「[ゲームパッドとリモコンの操作](gamepad-and-remote-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-133">For specific details on UWP support for gamepad and remote control, see [Gamepad and remote control interactions](gamepad-and-remote-interactions.md).</span></span>|
|<span data-ttu-id="c575f-134">スクリーン リーダー (ナレーター)</span><span class="sxs-lookup"><span data-stu-id="c575f-134">Screen readers (Narrator)</span></span>          |<span data-ttu-id="c575f-135">ナレーターは、独自の操作エクスペリエンスと機能を提供する Windows の組み込みスクリーン リーダーですが、依然として基本的なキーボード ナビゲーションと入力に依存しています。</span><span class="sxs-lookup"><span data-stu-id="c575f-135">Narrator is a built-in screen reader for Windows that provides unique interaction experiences and functionality, but still relies on basic keyboard navigation and input.</span></span>
<span data-ttu-id="c575f-136">ナレーターについて詳しくは、「[ナレーターの概要](https://support.microsoft.com/help/22798/windows-10-narrator-get-started)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-136">For Narrator details, see [Getting started with Narrator](https://support.microsoft.com/help/22798/windows-10-narrator-get-started).</span></span>|

## <a name="custom-experiences-and-efficient-keyboarding"></a><span data-ttu-id="c575f-137">カスタム エクスペリエンスと効率的なキーボード操作</span><span class="sxs-lookup"><span data-stu-id="c575f-137">Custom experiences and efficient keyboarding</span></span>
<span data-ttu-id="c575f-138">前述のとおり、さまざまなスキル、能力、期待を持ったユーザーにとってアプリケーションが十分に機能するために、キーボードのサポートは重要です。</span><span class="sxs-lookup"><span data-stu-id="c575f-138">As mentioned, keyboard support is integral to ensuring your applications work great for users with different skills, abilities, and expectations.</span></span> <span data-ttu-id="c575f-139">次の点を重視することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c575f-139">We recommend that you prioritize the following.</span></span>
- <span data-ttu-id="c575f-140">キーボードを使った操作のサポート</span><span class="sxs-lookup"><span data-stu-id="c575f-140">Support keyboard navigation and interaction</span></span>
    - <span data-ttu-id="c575f-141">操作可能な項目をタブ位置として定義します (操作可能でない項目は、そうしないようにします)。ナビゲーションの順序が論理的かつ予測可能であるようにします ([タブ位置](#tab-stops)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-141">Ensure actionable items are identified as tab stops (and non-actionable items are not), and navigation order is logical and predictable (see [Tab stops](#tab-stops))</span></span>
    - <span data-ttu-id="c575f-142">初期フォーカスは、最も論理的な要素に設定します ([初期フォーカス](#initial-focus) をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-142">Set initial focus on the most logical element (see [Initial focus](#initial-focus))</span></span>
    - <span data-ttu-id="c575f-143">"内部ナビゲーション" には矢印キーのナビゲーションを提供します ([ナビゲーション](#navigation)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-143">Provide arrow key navigation for "inner navigations" (see [Navigation](#navigation))</span></span>
- <span data-ttu-id="c575f-144">キーボード ショートカットのサポート</span><span class="sxs-lookup"><span data-stu-id="c575f-144">Support keyboard shortcuts</span></span>
    - <span data-ttu-id="c575f-145">クイック アクションのためのアクセラレータ キーを提供します ([アクセラレータ](#accelerators)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-145">Provide accelerator keys for quick actions (see [Accelerators](#accelerators))</span></span>
    - <span data-ttu-id="c575f-146">アプリの UI のナビゲーションのためのアクセス キーを提供します ([アクセス キー](access-keys.md)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-146">Provide access keys to navigate your app's UI (see [Access keys](access-keys.md))</span></span>

### <a name="focus-visuals-a-namefocus-visual"></a><span data-ttu-id="c575f-147">フォーカスの視覚効果 <a name="focus-visual"></span><span class="sxs-lookup"><span data-stu-id="c575f-147">Focus visuals <a name="focus-visual"></span></span>

<span data-ttu-id="c575f-148">UWP は、あらゆる入力の種類とエクスペリエンスで適切に動作する 1 つのフォーカスの視覚効果デザインをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="c575f-148">The UWP supports a single focus visual design that works well for all input types and experiences.</span></span>
![フォーカスの視覚効果](images/keyboard/focus-visual.png)

<span data-ttu-id="c575f-150">フォーカスの視覚効果には次のような特徴があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-150">A focus visual:</span></span>
-   <span data-ttu-id="c575f-151">UI 要素がキーボードやゲームパッド/リモコンからフォーカスを受け取ったときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-151">Is shown when a UI element receives focus from a keyboard and/or gamepad/remote control</span></span>
-   <span data-ttu-id="c575f-152">実行すべき操作を示すため、強調表示された境界線および UI 要素としてレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="c575f-152">Is rendered as a highlighted border around the UI element to indicate an action can be taken</span></span>
-   <span data-ttu-id="c575f-153">ユーザーが迷わすにアプリの UI を移動するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c575f-153">Helps a user navigate an app UI without getting lost</span></span>
-   <span data-ttu-id="c575f-154">アプリ用にカスタマイズできます (「[視認性の高いフォーカスの視覚効果](guidelines-for-visualfeedback.md#high-visibility-focus-visuals)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-154">Can be customized for your app (See [High visibility focus  visuals](guidelines-for-visualfeedback.md#high-visibility-focus-visuals))</span></span>

<span data-ttu-id="c575f-155">**注:** UWP のフォーカスの視覚効果は、ナレーターのフォーカスの四角形と同じではありません。</span><span class="sxs-lookup"><span data-stu-id="c575f-155">**NOTE** The UWP focus visual is not the same as the Narrator focus rectangle.</span></span>

### <a name="tab-stops-a-nametab-stops"></a><span data-ttu-id="c575f-156">タブ位置 <a name="tab-stops"></span><span class="sxs-lookup"><span data-stu-id="c575f-156">Tab stops <a name="tab-stops"></span></span>

<span data-ttu-id="c575f-157">キーボードでコントロール (ナビゲーション要素を含む) を操作するには、そのコントロールがフォーカスを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-157">To use a control (including navigation elements) with the keyboard, the control must have focus.</span></span> <span data-ttu-id="c575f-158">キーボード フォーカスを受け取るコントロールの 1 つの方法は、アプリのタブ オーダーでタブ位置として識別することによりタブ ナビゲーションを通じてアクセスできるようにする方法です。</span><span class="sxs-lookup"><span data-stu-id="c575f-158">One way for a control to receive keyboard focus is to make it accessible through tab navigation by identifying it as a tab stop in your app’s tab order.</span></span>

<span data-ttu-id="c575f-159">タブ オーダーに含まれるコントロールの場合、[**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/br209419) プロパティを **true** に設定し、[**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/br209422) プロパティを **true** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-159">For a control to be included in the tab order, the [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/br209419) property must be set to **true** and the [**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/br209422) property must be set to **true.**</span></span>

<span data-ttu-id="c575f-160">タブ オーダーからコントロールを明示的に除外するには、[**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/br209422) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="c575f-160">To specifically exclude a control from the tab order, set the [**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/br209422) property to **false.**</span></span>

<span data-ttu-id="c575f-161">既定では、タブ オーダーには UI 要素が作成される順序が反映されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-161">By default, tab order reflects the order in which UI elements are created.</span></span> <span data-ttu-id="c575f-162">たとえば、`StackPanel` には `Button`、`Checkbox`、`TextBox` が含まれ、タブ オーダーは `Button`、`Checkbox`、`TextBox` です。</span><span class="sxs-lookup"><span data-stu-id="c575f-162">For example, if a `StackPanel` contains a `Button`, a `Checkbox`, and a `TextBox`, tab order is `Button`, `Checkbox`, and `TextBox`.</span></span>

<span data-ttu-id="c575f-163">[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/br209461) プロパティを設定することで、既定のタブ オーダーを上書きできます。</span><span class="sxs-lookup"><span data-stu-id="c575f-163">You can override the default tab order by setting the [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/br209461) property.</span></span>

#### <a name="tab-order-should-be-logical-and-predictable"></a><span data-ttu-id="c575f-164">タブ オーダーは、論理的かつ予測可能でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="c575f-164">Tab order should be logical and predictable</span></span>

<span data-ttu-id="c575f-165">論理的で予測可能なタブ オーダーを使った、適切に設計されたキーボード ナビゲーション モデルがあれば、アプリはより直感的になり、ユーザーは機能をより効率的かつ効果的に探して見つけ、アクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="c575f-165">A well-designed keyboard navigation model, using a logical and predictable tab order, makes your app more intuitive and helps users explore, discover, and access functionality more efficiently and effectively.</span></span>

<span data-ttu-id="c575f-166">すべての対話的なコントロールには ([グループ](#control-group)内のコントロールでなければ) タブ位置があり、`labels`など非対話型のコントロールにはありません。</span><span class="sxs-lookup"><span data-stu-id="c575f-166">All interactive controls should have tab stops (unless they are in a [group](#control-group)), while non-interactive controls, such as `labels`, should not.</span></span>

<span data-ttu-id="c575f-167">フォーカスがアプリケーション内をジャンプするようなタブ オーダーは避けてください。</span><span class="sxs-lookup"><span data-stu-id="c575f-167">Avoid tab order that make the focus jump around in your application.</span></span> <span data-ttu-id="c575f-168">たとえば、フォームのような UI のコントロールの一覧には、上から下および左から右へと移動するタブ オーダーが必要です。</span><span class="sxs-lookup"><span data-stu-id="c575f-168">For example, a list of controls in a form-like UI should have a tab order that flows top to bottom and left to right.</span></span>

<span data-ttu-id="c575f-169">タブ位置のカスタマイズについて詳しくは、「[キーボードのアクセシビリティ](../accessibility/keyboard-accessibility.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-169">See [Keyboard accessibility](../accessibility/keyboard-accessibility.md) page for more details about customizing tab stops.</span></span>

#### <a name="try-to-coordinate-tab-order-and-visual-order"></a><span data-ttu-id="c575f-170">タブ オーダーと表示順序を調整してみる</span><span class="sxs-lookup"><span data-stu-id="c575f-170">Try to coordinate tab order and visual order</span></span>

<span data-ttu-id="c575f-171">タブ オーダーと表示順序 (読み取り順序とも呼ばれます) を調整すると、ユーザーがアプリの UI を使って移動する際の混乱を減らすことができます。</span><span class="sxs-lookup"><span data-stu-id="c575f-171">Coordinating tab order and visual order (also referred to as reading order or display order) helps reduce confusion for users as they navigate through your app’s UI.</span></span>

<span data-ttu-id="c575f-172">コマンド、コントロール、コンテンツを順序付けし、最も重要なものをタブ オーダーと表示順序の両方で最初に提示するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="c575f-172">Try to rank and present the most important commands, controls, and content first in both the tab order and the visual order.</span></span> <span data-ttu-id="c575f-173">ただし実際の表示位置は、親レイアウト コンテナーと、レイアウトに影響する子要素の特定のプロパティに左右されることがあります。</span><span class="sxs-lookup"><span data-stu-id="c575f-173">However, the actual display position can depend on the parent layout container and certain properties of the child elements that influence the layout.</span></span> <span data-ttu-id="c575f-174">特に、グリッド形式または表形式を使用しているレイアウトでは、表示順序がタブ オーダーとまったく異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-174">Specifically, layouts that use a grid metaphor or a table metaphor can have a visual order quite different from the tab order.</span></span>

<span data-ttu-id="c575f-175">**注:** 表示順序はロケールと言語にも依存します。</span><span class="sxs-lookup"><span data-stu-id="c575f-175">**NOTE** Visual order is also dependent on locale and language.</span></span>

### <a name="initial-focus-a-nameinitial-focus"></a><span data-ttu-id="c575f-176">初期フォーカス<a name="initial-focus"></span><span class="sxs-lookup"><span data-stu-id="c575f-176">Initial focus <a name="initial-focus"></span></span>

<span data-ttu-id="c575f-177">初期フォーカスは、アプリケーションやページが最初に起動またはアクティブ化されたときにフォーカスを受け取る UI 要素を指定します。</span><span class="sxs-lookup"><span data-stu-id="c575f-177">Initial focus specifies the UI element that receives focus when an application or a page is first launched or activated.</span></span> <span data-ttu-id="c575f-178">キーボードを使っている場合、ユーザーはアプリの UI の操作をこの要素から開始します。</span><span class="sxs-lookup"><span data-stu-id="c575f-178">When using a keyboard, it is from this element that a user starts interacting with your app’s UI.</span></span>

<span data-ttu-id="c575f-179">UWP アプリの場合、初期フォーカスはフォーカスを受け取ることができる最上位の [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/br209461) を持つ要素に設定されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-179">For UWP apps, initial focus is set to the element with the highest [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/br209461) that can receive focus.</span></span> <span data-ttu-id="c575f-180">コンテナー コントロールの子要素は無視されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-180">Child elements of container controls are ignored.</span></span> <span data-ttu-id="c575f-181">TIE の場合、表示ツリー内の最初の要素がフォーカスを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="c575f-181">In a tie, the first element in the visual tree receives focus.</span></span>

#### <a name="set-initial-focus-on-the-most-logical-element"></a><span data-ttu-id="c575f-182">初期フォーカスは、最も論理的な要素に設定します。</span><span class="sxs-lookup"><span data-stu-id="c575f-182">Set initial focus on the most logical element</span></span>

<span data-ttu-id="c575f-183">初期フォーカスは、ユーザーがアプリを起動したり、ページを移動したりするときに最初に実行する可能性が最も高い操作 (つまり、プライマリ操作) の UI 要素に設定します。</span><span class="sxs-lookup"><span data-stu-id="c575f-183">Set initial focus on the UI element for the first, or primary, action that users are most likely to take when launching your app or navigating to a page.</span></span> <span data-ttu-id="c575f-184">次のような例があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-184">Some examples include:</span></span>
-   <span data-ttu-id="c575f-185">フォーカスがギャラリー内の最初の項目に設定されているフォト アプリ</span><span class="sxs-lookup"><span data-stu-id="c575f-185">A photo app where focus is set to the first item in a gallery</span></span>
-   <span data-ttu-id="c575f-186">フォーカスが再生ボタンに設定されているミュージック アプリ</span><span class="sxs-lookup"><span data-stu-id="c575f-186">A music app where focus is set to the play button</span></span>

#### <a name="dont-set-initial-focus-on-an-element-that-exposes-a-potentially-negative-or-even-disastrous-outcome"></a><span data-ttu-id="c575f-187">初期フォーカスは、ネガティブ (または破滅的) な結果を招く可能性のある要素に設定しないでください。</span><span class="sxs-lookup"><span data-stu-id="c575f-187">Don’t set initial focus on an element that exposes a potentially negative, or even disastrous, outcome</span></span>

<span data-ttu-id="c575f-188">このレベルの機能はユーザーが選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="c575f-188">This level of functionality should be a user’s choice.</span></span> <span data-ttu-id="c575f-189">重要な結果を生み出す要素に初期フォーカスを設定すると、意図しないデータ消失またはシステム アクセスが生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-189">Setting initial focus to an element with a significant outcome might result in unintended data loss or system access.</span></span> <span data-ttu-id="c575f-190">たとえば、メールに移動するときにフォーカスを削除ボタンに設定しないでください。</span><span class="sxs-lookup"><span data-stu-id="c575f-190">For example, don’t set focus to the delete button when navigating to an e-mail.</span></span>

<span data-ttu-id="c575f-191">タブ オーダーの上書きについて詳しくは、「[キーボードのアクセシビリティ](../accessibility/keyboard-accessibility.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-191">See [Keyboard accessibility](../accessibility/keyboard-accessibility.md) page for more details about overriding tab order.</span></span>

### <a name="navigation-a-namenavigation"></a><span data-ttu-id="c575f-192">ナビゲーション <a name="navigation"></span><span class="sxs-lookup"><span data-stu-id="c575f-192">Navigation <a name="navigation"></span></span>

<span data-ttu-id="c575f-193">キーボード ナビゲーションは通常、Tab キーと方向キーによってサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c575f-193">Keyboard navigation is typically supported through the Tab keys and the Arrow keys.</span></span>

![Tab + 方向キー](images/keyboard/tab-and-arrow.png)

<span data-ttu-id="c575f-195">既定では、UWP コントロールは以下の基本的なキーボード動作に従います。</span><span class="sxs-lookup"><span data-stu-id="c575f-195">By default, UWP controls follow these basic keyboard behaviors:</span></span>
-   <span data-ttu-id="c575f-196">**Tab キー**を使うと、実行可能な/アクティブなコントロール間をタブ オーダーで移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-196">**Tab keys** navigate between actionable/active controls in tab order.</span></span>
-   <span data-ttu-id="c575f-197">**Shift + Tab** キーを使うと、コントロールを逆タブ オーダーで移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-197">**Shift + Tab** navigate controls in reverse tab order.</span></span> <span data-ttu-id="c575f-198">ユーザーが方向キーを使ってコントロール内を移動した場合、フォーカスはコントロール内の最後の既知の値に設定されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-198">If user has navigated inside the control using arrow key, focus is set to the last known value inside the control.</span></span>
-   <span data-ttu-id="c575f-199">**方向キー**を使うと、コントロール固有の "内部ナビゲーション" が表示されます。ユーザーが "内部ナビゲーション" に入ると、方向キーを使ってもコントロール外に移動しません。</span><span class="sxs-lookup"><span data-stu-id="c575f-199">**Arrow keys** expose control-specific "inner navigation" When user enters "inner navigation,"" arrow keys do not navigate out of a control.</span></span> <span data-ttu-id="c575f-200">次のような例があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-200">Some examples include:</span></span>
    -   <span data-ttu-id="c575f-201">上/下方向キーを使うと、`ListView` 内でフォーカスが移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-201">Up/Down arrow key moves focus inside `ListView` and</span></span> `MenuFlyout`
    -   <span data-ttu-id="c575f-202">`Slider` の現在選択されている値が変更されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-202">Modify currently selected values for `Slider` and</span></span> `RatingsControl`
    -   <span data-ttu-id="c575f-203">内部でカーソルが移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-203">Move caret inside</span></span> `TextBox`
    -   <span data-ttu-id="c575f-204">内部で項目が展開/折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="c575f-204">Expand/collapse items inside</span></span> `TreeView`

<span data-ttu-id="c575f-205">アプリのキーボード ナビゲーションを最適化するには、これらの既定の動作を使用します。</span><span class="sxs-lookup"><span data-stu-id="c575f-205">Use these default behaviors to optimize your app’s keyboard navigation.</span></span>

#### <a name="use-inner-navigation-with-sets-of-related-controls"></a><span data-ttu-id="c575f-206">関連するコントロールのセットで ”内部ナビゲーション" を使う</span><span class="sxs-lookup"><span data-stu-id="c575f-206">Use "inner navigation" with sets of related controls</span></span>

<span data-ttu-id="c575f-207">一連の関連するコントロールに方向キー ナビゲーションを提供すると、アプリの UI の全体的な組織内の関係が強化されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-207">Providing arrow key navigation into a set of related controls reinforces their relationship within the overall organization of your app’s UI.</span></span>

<span data-ttu-id="c575f-208">たとえば、ここに示す `ContentDialog` コントロールは、横 1 列のボタンに既定で内部ナビゲーションを提供します (カスタム コントロールについては、「[コントロール グループ](#control-group)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-208">For example, the `ContentDialog` control shown here provides inner navigation by default for a horizontal row of buttons (for custom controls, see the [Control Group](#control-group) section).</span></span>

![ダイアログの例](images/keyboard/dialog.png)

***<span data-ttu-id="c575f-210">方向キー ナビゲーションを使うと、関連するボタンのコレクションの操作が簡単になる</span><span class="sxs-lookup"><span data-stu-id="c575f-210">Interaction with a collection of related buttons is made easier with arrow key navigation</span></span>***

<span data-ttu-id="c575f-211">項目が 1 列に表示されている場合、上/下方向キーによって項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-211">If items are displayed in a single column, Up/Down arrow key navigates items.</span></span> <span data-ttu-id="c575f-212">項目が 1 行に表示されている場合、右/左方向キーによって項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-212">If items are displayed in a single row, Right/Left arrow key navigates items.</span></span> <span data-ttu-id="c575f-213">項目が複数の列にある場合、4 つの方向キーすべてを使って移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-213">If items are multiple columns, all 4 arrow keys navigate.</span></span>

#### <a name="make-a-set-of-related-controls-a-single-tab-stop"></a><span data-ttu-id="c575f-214">一連の関連するコントロールを 1 つのタブ位置にする</span><span class="sxs-lookup"><span data-stu-id="c575f-214">Make a set of related controls a single tab stop</span></span>

<span data-ttu-id="c575f-215">一連の関連する (または補完的な) コントロールを 1つのタブ位置にすることにより、アプリ内の全体的なタブ位置の数を最小限に抑えることができます。</span><span class="sxs-lookup"><span data-stu-id="c575f-215">By making a set of related, or complementary, controls a single tab stop, you can minimize the number of overall tab stops in your app.</span></span>

<span data-ttu-id="c575f-216">たとえば、次の図は縦に並んだ 2 つの `ListView` コントロールを示しています。</span><span class="sxs-lookup"><span data-stu-id="c575f-216">For example, the following images show two stacked `ListView` controls.</span></span> <span data-ttu-id="c575f-217">左の図は、`ListView` コントロール間を移動するタブ位置で使われる方向キー ナビゲーション を示しているのに対し、右の図は、Tab キーによって親コントロールを移動する必要をなくすことで、子要素間のナビゲーションがどのように簡単かつ効率的になるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="c575f-217">The image on the left shows arrow key navigation used with a tab stop to navigate between `ListView` controls, while the image on the right shows how navigation between child elements could be made easier and more efficient by eliminating the need for to traverse parent controls with a tab key.</span></span>


<table>
  <td>![方向キーと Tab キー](images/keyboard/arrow-and-tab.png)</td>
  <td>![方向キーのみ](images/keyboard/arrow-only.png)</td>
</table>

***<span data-ttu-id="c575f-220">縦に並んだ 2 つの ListView コントロールの操作は、タブ位置をなくして方向キーだけで移動することにより、簡単かつ効率的になります。</span><span class="sxs-lookup"><span data-stu-id="c575f-220">Interaction with two stacked ListView controls can be made easier and more efficient by eliminating the tab stop and navigating with just arrow keys.</span></span>***

<span data-ttu-id="c575f-221">アプリケーション UI に最適化の例を適用する方法については、「[コントロール グループ](#control-group)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-221">Visit [Control Group](#control-group) section to learn how to apply the optimization examples to your application UI.</span></span>

### <a name="interaction-and-commanding"></a><span data-ttu-id="c575f-222">対話式操作とコマンド実行</span><span class="sxs-lookup"><span data-stu-id="c575f-222">Interaction and commanding</span></span>

<span data-ttu-id="c575f-223">コントロールにフォーカスが置かれると、ユーザーはそのコントロールを操作し、特定のキーボード入力を使って関連付けられている機能を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c575f-223">Once a control has focus, a user can interact with it and invoke any associated functionality using specific keyboard input.</span></span>

#### <a name="text-entry"></a><span data-ttu-id="c575f-224">テキスト入力</span><span class="sxs-lookup"><span data-stu-id="c575f-224">Text entry</span></span>

<span data-ttu-id="c575f-225">`TextBox` や `RichEditBox` など、特にテキスト入力向けに設計されたコントロールの場合、テキストの入力や移動のためにすべてのキーボード入力が使用され、他のキーボード コマンドより優先されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-225">For those controls specifically designed for text input such as `TextBox` and `RichEditBox`, all keyboard input is used for entering or navigating text, which takes priority over other keyboard commands.</span></span> <span data-ttu-id="c575f-226">たとえば、`AutoSuggestBox` コントロールのドロップ ダウン メニューは **Space** キーを選択コマンドとして認識しません。</span><span class="sxs-lookup"><span data-stu-id="c575f-226">For example, the drop down menu for an `AutoSuggestBox` control does not recognize the **Space** key as a selection command.</span></span>

![テキスト入力](images/keyboard/text-entry.png)

#### <a name="space-key"></a><span data-ttu-id="c575f-228">Space キー</span><span class="sxs-lookup"><span data-stu-id="c575f-228">Space key</span></span>

<span data-ttu-id="c575f-229">テキスト入力モードではない場合、**Space** キーはフォーカスがあるコントロールに関連付けられた操作やコマンドを呼び出します (タッチによるタップやマウスによるクリックと同様)。</span><span class="sxs-lookup"><span data-stu-id="c575f-229">When not in text entry mode, the **Space** key invokes the action or command associated with the focused control (just like a tap with touch or a click with a mouse).</span></span>

![Space キー](images/keyboard/space-key.png)

#### <a name="enter-key"></a><span data-ttu-id="c575f-231">Enter キー</span><span class="sxs-lookup"><span data-stu-id="c575f-231">Enter key</span></span>

<span data-ttu-id="c575f-232">**Enter** キーは、フォーカスのあるコントロールに応じて、さまざまな共通ユーザー操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-232">The **Enter** key can perform a variety of common user interactions, depending on the control with focus:</span></span>
-   <span data-ttu-id="c575f-233">`Button` や `Hyperlink` などのコマンド コントロールをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="c575f-233">Activates command controls such as a `Button` or `Hyperlink`.</span></span> <span data-ttu-id="c575f-234">エンド ユーザーの混乱を避けるため、**Enter** キーは `ToggleButton` や `AppBarToggleButton` など、コマンド コントロールに似たコントロールもアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="c575f-234">To avoid end user confusion, the **Enter** key also activates controls that look like command controls such as `ToggleButton` or `AppBarToggleButton`.</span></span>
-   <span data-ttu-id="c575f-235">`ComboBox` や `DatePicker` などのコントロールのピッカー UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="c575f-235">Displays the picker UI for controls such as `ComboBox` and `DatePicker`.</span></span> <span data-ttu-id="c575f-236">**Enter** キーは、ピッカー UI もコミットして閉じます。</span><span class="sxs-lookup"><span data-stu-id="c575f-236">The **Enter** key also commits and closes the picker UI.</span></span>
-   <span data-ttu-id="c575f-237">`ListView`、`GridView`、`ComboBox` などのリスト コントロールをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="c575f-237">Activates list controls such as `ListView`, `GridView`, and `ComboBox`.</span></span>
    -   <span data-ttu-id="c575f-238">**Enter** キーは、選択操作をリストおよびグリッド項目の **Space** キーとして実行します。ただし、それらの項目に追加の操作が関連付けられている場合を除きます (新しいウィンドウを開くなど)。</span><span class="sxs-lookup"><span data-stu-id="c575f-238">The **Enter** key performs the selection action as the **Space** key for list and grid items, unless there is an additional action associated with these items (opening a new window).</span></span>
    -   <span data-ttu-id="c575f-239">コントロールに追加の操作が関連付けられている場合、**Enter** キーは追加の操作を実行し、**Space** キーは選択操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="c575f-239">If an additional action is associated with the control, the **Enter** key performs the additional action and the **Space** key performs the selection action.</span></span>

<span data-ttu-id="c575f-240">**注:** **Enter** キーと **Space** キーは、常に同じ操作を実行するわけではありませんが、多くの場合は同じ操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="c575f-240">**NOTE** The **Enter** key and **Space** key do not always perform the same action, but often do.</span></span>

![Enter キー](images/keyboard/enter-key.png)

<span data-ttu-id="c575f-242">Esc キーを使うと、ユーザーが一時的な UI (および、その UI における継続的な操作すべて) を取り消すことができます。</span><span class="sxs-lookup"><span data-stu-id="c575f-242">The Esc key lets a user cancel transient UI (along with any ongoing actions in that UI).</span></span>

<span data-ttu-id="c575f-243">このエクスペリエンスの例は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c575f-243">Examples of this experience include:</span></span>
-   <span data-ttu-id="c575f-244">ユーザーが、選択した値を使って `ComboBox` を開き、方向キーを使ってフォーカスの選択を新しい値に移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-244">User opens a `ComboBox` with a selected value and uses the arrow keys to move the focus selection to a new value.</span></span> <span data-ttu-id="c575f-245">Esc キーを押すと `ComboBox` が閉じ、選択した値が元の値にリセットされます。</span><span class="sxs-lookup"><span data-stu-id="c575f-245">Pressing the Esc key closes the `ComboBox` and resets the selected value back to the original value.</span></span>
-   <span data-ttu-id="c575f-246">ユーザーがメールの永続的な削除アクションを呼び出すと、操作の確認を求める `ContentDialog` が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-246">User invokes a permanent delete action for an email and is prompted with a `ContentDialog` to confirm the action.</span></span> <span data-ttu-id="c575f-247">ユーザーは、これが意図した操作でないと判断し、**Esc** キーを押してダイアログを閉じます。</span><span class="sxs-lookup"><span data-stu-id="c575f-247">The user decides this is not the intended action and presses the **Esc** key to close the dialog.</span></span> <span data-ttu-id="c575f-248">**Esc** キーは **[キャンセル]** ボタンに関連付けられているため、ダイアログが閉じ、操作は取り消されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-248">As the **Esc** key is associated with the **Cancel** button, the dialog is closed and the action is canceled.</span></span> <span data-ttu-id="c575f-249">**Esc** キーは一時的な UI にのみ影響を与えます。アプリの UI を閉じたり、戻ったりすることはありません。</span><span class="sxs-lookup"><span data-stu-id="c575f-249">The **Esc** key only affects transient UI, it does not close, or back navigate through, app UI.</span></span>

![Esc キー](images/keyboard/esc-key.png)

#### <a name="home-and-end-keys"></a><span data-ttu-id="c575f-251">Home キーと End キー</span><span class="sxs-lookup"><span data-stu-id="c575f-251">Home and End keys</span></span>

<span data-ttu-id="c575f-252">**Home** キーと **End** キーを使うと、ユーザーは UI 領域の先頭または末尾までスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="c575f-252">The **Home** and **End** keys let a user scroll to the beginning or end of a UI region.</span></span>

<span data-ttu-id="c575f-253">このエクスペリエンスの例は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c575f-253">Examples of this experience include:</span></span>
-   <span data-ttu-id="c575f-254">`ListView` コントロールと `GridView` コントロールの場合、**Home** キーはフォーカスを最初の要素に移動してビューまでスクロールしますが、**End** キーはフォーカスを最後の要素に移動し、ビューまでスクロールします。</span><span class="sxs-lookup"><span data-stu-id="c575f-254">For `ListView` and `GridView` controls, the **Home** key moves focus to the first element and scrolls it into view, whereas the **End** key moves focus to the last element and scrolls it into view.</span></span>
-   <span data-ttu-id="c575f-255">`ScrollView` コントロールの場合、**Home** キーは領域の上までスクロールしますが、**End** キーは領域の下までスクロールします (フォーカスが変更されません)。</span><span class="sxs-lookup"><span data-stu-id="c575f-255">For a `ScrollView` control, the **Home** key scrolls to the top of the region, whereas the **End** key scrolls to the bottom of the region (focus is not changed).</span></span>

![Home キーと End キー](images/keyboard/home-and-end.png)

#### <a name="page-up-and-page-down-keys"></a><span data-ttu-id="c575f-257">PageUp キーと PageDown キー</span><span class="sxs-lookup"><span data-stu-id="c575f-257">Page up and Page down keys</span></span>

<span data-ttu-id="c575f-258">**Page** キーを使うと、ユーザーは一定の単位で UI 領域をスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="c575f-258">The **Page** keys let a user scroll a UI region in discrete increments.</span></span>

<span data-ttu-id="c575f-259">たとえば、`ListView` コントロールと `GridView` コントロールの場合、**PageUp** キーは領域を 1 "ページ" 分 (通常はビューポートの高さ) 上にスクロールし、領域の上にフォーカスを移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-259">For example, for `ListView` and `GridView` controls, the **Page up** key scrolls the region up by a "page" (typically the viewport height) and moves focus to the top of the region.</span></span> <span data-ttu-id="c575f-260">一方、**PageDown** キーは領域を 1 ページ分下に移動し、領域の下にフォーカスを移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-260">Alternately, the **Page down** key scrolls the region down by a page and moves focus to the bottom of the region.</span></span>

![PageUp キーと PageDown キー](images/keyboard/page-up-and-down.png)

### <a name="keyboard-shortcuts"></a><span data-ttu-id="c575f-262">キーボード ショートカット</span><span class="sxs-lookup"><span data-stu-id="c575f-262">Keyboard shortcuts</span></span>

<span data-ttu-id="c575f-263">キーボード ショートカットを使うと、アプリを簡単かつ効率的に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c575f-263">Keyboard shortcuts can make your app easier and more efficient to use.</span></span>

<span data-ttu-id="c575f-264">キーボードのナビゲーションのアクティブ化をアプリに実装するだけでなく、ショートカットをアプリの機能に実装することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c575f-264">In addition to implementing keyboard navigation and activation for your app, it is a good practice to implement shortcuts for your app's functionality.</span></span> <span data-ttu-id="c575f-265">基本的なキーボードのサポートとしてはタブ ナビゲーションで十分ですが、複雑なフォームではショートカット キーのサポートも追加すると効果的です。</span><span class="sxs-lookup"><span data-stu-id="c575f-265">Tab navigation provides a good, basic level of keyboard support, but with complex forms you may want to add support for shortcut keys as well.</span></span> <span data-ttu-id="c575f-266">これにより、キーボードとポインティング デバイスの両方を使うユーザーにも使いやすいアプリになります。</span><span class="sxs-lookup"><span data-stu-id="c575f-266">This can make your application more efficient to use, even for people who use both a keyboard and pointing devices.</span></span>

<span data-ttu-id="c575f-267">ショートカットは、ユーザーが効率的にアプリの機能にアクセスできるようにして、生産性を向上させるためのキーの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="c575f-267">A shortcut is a keyboard combination that enhances productivity by providing an efficient way for the user to access app functionality.</span></span> <span data-ttu-id="c575f-268">ショートカットには次の 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-268">There are two kinds of shortcut:</span></span>
-   <span data-ttu-id="c575f-269">[ショートカット キー](#accelerators)は、アプリ コマンドへのショートカットです。</span><span class="sxs-lookup"><span data-stu-id="c575f-269">An [accelerator key](#accelerators) is a shortcut to an app command.</span></span> <span data-ttu-id="c575f-270">アプリにはコマンドに正確に対応する UI がある場合とない場合があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-270">Your app may or may not have UI that corresponds exactly to the command.</span></span> <span data-ttu-id="c575f-271">ショートカット キーは、Ctrl キーと文字キーの組み合わせで構成されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-271">Accelerator keys consist of the Ctrl key plus a letter key.</span></span>
-   <span data-ttu-id="c575f-272">[アクセス キー](#access-keys)は、アプリ内の個別の UI 要素へのショートカットです。</span><span class="sxs-lookup"><span data-stu-id="c575f-272">An [access key](#access-keys) is a shortcut to a piece of UI in your app.</span></span> <span data-ttu-id="c575f-273">アクセス キーは、Alt キーと文字キーの組み合わせで構成されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-273">Access keys consist of the Alt key plus a letter key.</span></span>

<span data-ttu-id="c575f-274">[Windows のキーボード ショートカット](https://support.microsoft.com/help/12445/windows-keyboard-shortcuts)と、Microsoft により開発されたアプリケーションで使用される [アプリケーション固有のキーボード ショートカット](https://support.microsoft.com/help/13805/windows-keyboard-shortcuts-in-apps)をすべて網羅した一覧については、このページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-274">Visit this page for exhaustive listing of [keyboard shortcuts for Windows](https://support.microsoft.com/help/12445/windows-keyboard-shortcuts) as well as [application specific keyboard shortcuts](https://support.microsoft.com/help/13805/windows-keyboard-shortcuts-in-apps) used by applications developed by Microsoft.</span></span>

#### <a name="accelerators-a-nameaccelerators"></a><span data-ttu-id="c575f-275">アクセラレータ <a name="accelerators"></span><span class="sxs-lookup"><span data-stu-id="c575f-275">Accelerators <a name="accelerators"></span></span>

<span data-ttu-id="c575f-276">アクセラレータを使うと、ユーザーはアプリケーションに存在する一般的な操作をすばやく実行できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-276">Accelerators help users perform common actions that exists on application quickly.</span></span> <span data-ttu-id="c575f-277">ユーザーが簡単に記憶でき、同じようなタスクを実行するアプリケーションで使うことができる一貫性したアクセラレータ キーを提供することは、アクセラレータを便利で強力なものとするために非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="c575f-277">Providing a consistent accelerator keys that users can easily remember and use across applications that offer similar tasks is very important for making accelerator useful as well as powerful.</span></span>

<span data-ttu-id="c575f-278">アクセラレータの例:</span><span class="sxs-lookup"><span data-stu-id="c575f-278">Examples of Accelerators:</span></span>
-   <span data-ttu-id="c575f-279">メール アプリの任意の場所で Ctrl + N キーを押すと、新しいメール アイテムが起動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-279">Pressing Ctrl + N key anywhere in Mail app launches a new mail item.</span></span>
-   <span data-ttu-id="c575f-280">Edge やストア アプリの任意の場所で Ctrl + E キーを押すと、ユーザーが検索ボックスにすばやくテキストを入力できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-280">Pressing Ctrl + E key anywhere in Edge and Store app lets user quickly enter text in search box.</span></span>

<span data-ttu-id="c575f-281">アクセラレータには、次の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-281">Accelerators have the following characteristics:</span></span>
-   <span data-ttu-id="c575f-282">主に Ctrl キーとファンクション キーのシーケンスを使用します (Windows のシステム ショートカット キーには、Alt キーと英数字以外のキーの組み合わせと Windows ロゴ キーが使用されています)。</span><span class="sxs-lookup"><span data-stu-id="c575f-282">They primarily use Ctrl and Function key sequences (Windows system shortcut keys also use Alt+non-alphanumeric keys and the Windows logo key).</span></span>
-   <span data-ttu-id="c575f-283">ショートカット キーの主な目的は、上級ユーザーによる使用の効率です。</span><span class="sxs-lookup"><span data-stu-id="c575f-283">They are primarily for efficiency for advanced users.</span></span>
-   <span data-ttu-id="c575f-284">特に使用頻度の高いコマンドにのみ割り当てます。</span><span class="sxs-lookup"><span data-stu-id="c575f-284">They are assigned only to the most commonly used commands.</span></span>
-   <span data-ttu-id="c575f-285">覚えて使うことを意図しており、メニュー、ツールヒント、ヘルプ内にのみ示されています。</span><span class="sxs-lookup"><span data-stu-id="c575f-285">They are intended to be memorized, and are documented only in menus, tooltips, and Help.</span></span>
-   <span data-ttu-id="c575f-286">効力はプログラム全体に及びますが、該当しない場合には効力がありません。</span><span class="sxs-lookup"><span data-stu-id="c575f-286">They have effect throughout the entire program, but have no effect if they don't apply.</span></span>
-   <span data-ttu-id="c575f-287">覚えて使うことを意図しており、直接示されないため、割り当てに一貫性が必要です。</span><span class="sxs-lookup"><span data-stu-id="c575f-287">They must be assigned consistently because they are memorized and not directly documented.</span></span>

#### <a name="access-keys-a-nameaccess-keys"></a><span data-ttu-id="c575f-288">アクセス キー <a name="access-keys"></span><span class="sxs-lookup"><span data-stu-id="c575f-288">Access keys <a name="access-keys"></span></span>

<span data-ttu-id="c575f-289">アクセス キーは、アクセシビリティ要件を持つユーザーとキーボードを使いこなす上級ユーザーの両方が、アプリの UI を効率的かつ効果的に移動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="c575f-289">Access keys provide both users with accessibility requirements and advanced keyboard users with an efficient and effective way to navigate your app’s UI.</span></span>

<span data-ttu-id="c575f-290">UWP でアクセス キーをサポートする方法について詳しくは、「[アクセス キー](access-keys.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-290">See [Access keys](access-keys.md) page for more in-depth information for supporting access keys with UWP.</span></span>

<span data-ttu-id="c575f-291">アクセス キーを使うと、運動機能に障碍を持つユーザーが、一度に 1 つのキーを押して UI の特定の項目に対してアクションを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="c575f-291">Access keys help users with motor function disabilities an ability to press one key at a time to action on a specific item in the UI.</span></span> <span data-ttu-id="c575f-292">さらに、アクセス キーは上級ユーザーが操作をすばやく実行できるように、追加のショートカット キーを伝えるためにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-292">Moreover, access keys can be used to communicate additional shortcut keys to help advanced users perform actions quickly.</span></span>

<span data-ttu-id="c575f-293">アクセス キーには、次の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-293">Access keys have the following characteristics:</span></span>
-   <span data-ttu-id="c575f-294">Alt キーを押しながら英数字キーを押します。</span><span class="sxs-lookup"><span data-stu-id="c575f-294">They use the Alt key plus an alphanumeric key.</span></span>
-   <span data-ttu-id="c575f-295">主な目的はアクセシビリティです。</span><span class="sxs-lookup"><span data-stu-id="c575f-295">They are primarily for accessibility.</span></span>
-   <span data-ttu-id="c575f-296">[キーのヒント](access-keys.md)のヒントを使うことで、コントロールの横にある UI に直接内容が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-296">They are documented directly in the UI adjacent to the control by use of [Key Tips](access-keys.md).</span></span>
-   <span data-ttu-id="c575f-297">アクセス キーは、対応するメニュー項目やコントロールへの移動に使用します。効力は現在のウィンドウ内に限られます。</span><span class="sxs-lookup"><span data-stu-id="c575f-297">They have effect only in the current window, and navigate to the corresponding menu item or control.</span></span>
-   <span data-ttu-id="c575f-298">常に一貫して割り当てることはできないため、割り当てに一貫性はありません。</span><span class="sxs-lookup"><span data-stu-id="c575f-298">They aren't assigned consistently because they can't always be.</span></span> <span data-ttu-id="c575f-299">ただし、使用頻度の高いコマンド (特にコミット ボタン) については、アクセス キーの割り当てに一貫性が必要です。</span><span class="sxs-lookup"><span data-stu-id="c575f-299">However, access keys should be assigned consistently for commonly used commands, especially commit buttons.</span></span>
-   <span data-ttu-id="c575f-300">アクセス キーはローカライズされます。</span><span class="sxs-lookup"><span data-stu-id="c575f-300">They are localized.</span></span>

#### <a name="common-keyboard-shortcuts"></a><span data-ttu-id="c575f-301">一般的なキーボード ショートカット</span><span class="sxs-lookup"><span data-stu-id="c575f-301">Common keyboard shortcuts</span></span>

<span data-ttu-id="c575f-302">次の表は、よく使われるキーボード コマンドの簡単なサンプルです。</span><span class="sxs-lookup"><span data-stu-id="c575f-302">The following table is a small sample of frequently used keyboard commands.</span></span> <span data-ttu-id="c575f-303">キーボード コマンドの一覧については、[Windows のキーボード ショートカット キーに関するページ](https://support.microsoft.com/kb/126449)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-303">For a complete list of keyboard commands, see [Windows Keyboard Shortcut Keys](https://support.microsoft.com/kb/126449).</span></span>

| <span data-ttu-id="c575f-304">操作</span><span class="sxs-lookup"><span data-stu-id="c575f-304">Action</span></span>                               | <span data-ttu-id="c575f-305">キー コマンド</span><span class="sxs-lookup"><span data-stu-id="c575f-305">Key command</span></span>                                      |
|--------------------------------------|--------------------------------------------------|
| <span data-ttu-id="c575f-306">すべて選択</span><span class="sxs-lookup"><span data-stu-id="c575f-306">Select all</span></span>                           | <span data-ttu-id="c575f-307">Ctrl + A</span><span class="sxs-lookup"><span data-stu-id="c575f-307">Ctrl+A</span></span>                                           |
| <span data-ttu-id="c575f-308">連続して選択</span><span class="sxs-lookup"><span data-stu-id="c575f-308">Continuously select</span></span>                  | <span data-ttu-id="c575f-309">Shift + 方向キー</span><span class="sxs-lookup"><span data-stu-id="c575f-309">Shift+Arrow key</span></span>                                  |
| <span data-ttu-id="c575f-310">上書き保存</span><span class="sxs-lookup"><span data-stu-id="c575f-310">Save</span></span>                                 | <span data-ttu-id="c575f-311">Ctrl + S</span><span class="sxs-lookup"><span data-stu-id="c575f-311">Ctrl+S</span></span>                                           |
| <span data-ttu-id="c575f-312">検索</span><span class="sxs-lookup"><span data-stu-id="c575f-312">Find</span></span>                                 | <span data-ttu-id="c575f-313">Ctrl + F</span><span class="sxs-lookup"><span data-stu-id="c575f-313">Ctrl+F</span></span>                                           |
| <span data-ttu-id="c575f-314">印刷</span><span class="sxs-lookup"><span data-stu-id="c575f-314">Print</span></span>                                | <span data-ttu-id="c575f-315">Ctrl + P</span><span class="sxs-lookup"><span data-stu-id="c575f-315">Ctrl+P</span></span>                                           |
| <span data-ttu-id="c575f-316">コピー</span><span class="sxs-lookup"><span data-stu-id="c575f-316">Copy</span></span>                                 | <span data-ttu-id="c575f-317">Ctrl + C</span><span class="sxs-lookup"><span data-stu-id="c575f-317">Ctrl+C</span></span>                                           |
| <span data-ttu-id="c575f-318">切り取り</span><span class="sxs-lookup"><span data-stu-id="c575f-318">Cut</span></span>                                  | <span data-ttu-id="c575f-319">Ctrl + X</span><span class="sxs-lookup"><span data-stu-id="c575f-319">Ctrl+X</span></span>                                           |
| <span data-ttu-id="c575f-320">貼り付け</span><span class="sxs-lookup"><span data-stu-id="c575f-320">Paste</span></span>                                | <span data-ttu-id="c575f-321">Ctrl + V</span><span class="sxs-lookup"><span data-stu-id="c575f-321">Ctrl+V</span></span>                                           |
| <span data-ttu-id="c575f-322">元に戻す</span><span class="sxs-lookup"><span data-stu-id="c575f-322">Undo</span></span>                                 | <span data-ttu-id="c575f-323">Ctrl + Z</span><span class="sxs-lookup"><span data-stu-id="c575f-323">Ctrl+Z</span></span>                                           |
| <span data-ttu-id="c575f-324">次のタブ</span><span class="sxs-lookup"><span data-stu-id="c575f-324">Next tab</span></span>                             | <span data-ttu-id="c575f-325">Ctrl + Tab</span><span class="sxs-lookup"><span data-stu-id="c575f-325">Ctrl+Tab</span></span>                                         |
| <span data-ttu-id="c575f-326">タブを閉じる</span><span class="sxs-lookup"><span data-stu-id="c575f-326">Close tab</span></span>                            | <span data-ttu-id="c575f-327">Ctrl + 4 または Ctrl + W</span><span class="sxs-lookup"><span data-stu-id="c575f-327">Ctrl+F4 or Ctrl+W</span></span>                                |
| <span data-ttu-id="c575f-328">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="c575f-328">Semantic zoom</span></span>                        | <span data-ttu-id="c575f-329">Ctrl + 正符号 (+) または Ctrl + マイナス記号 (-)</span><span class="sxs-lookup"><span data-stu-id="c575f-329">Ctrl++ or Ctrl+-</span></span>                                 |

## <a name="advanced-experiences"></a><span data-ttu-id="c575f-330">高度なエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="c575f-330">Advanced experiences</span></span>

<span data-ttu-id="c575f-331">このセクションでは、UWP アプリによりサポートされているより複雑なキーボード操作エクスペリエンスと、アプリをさまざまなデバイスやツールで使う場合に認識すべき動作についていくつか説明します。</span><span class="sxs-lookup"><span data-stu-id="c575f-331">In this section, we discuss some of the more complex keyboard interaction experiences supported by UWP apps, along with some of the behaviors you should be aware of when your app is used on different devices and with different tools.</span></span>

### <a name="control-group-a-namecontrol-group"></a><span data-ttu-id="c575f-332">コントロール グループ <a name="control-group"></span><span class="sxs-lookup"><span data-stu-id="c575f-332">Control group <a name="control-group"></span></span>

<span data-ttu-id="c575f-333">一連の関連する (または補完的な) コントロールを "コントロール グループ" (または方向領域) にまとめることで、方向キーを使った "内部ナビゲーション" が可能になります。</span><span class="sxs-lookup"><span data-stu-id="c575f-333">You can group a set of related, or complementary, controls in a "control group" (or directional area), which enables "inner navigation" using the arrow keys.</span></span> <span data-ttu-id="c575f-334">コントロール グループは、1 つのタブ位置にすることも、コントロール グループ内の複数のタブ位置を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="c575f-334">The control group can be a single tab stop, or you can specify multiple tab stops within the control group.</span></span>

#### <a name="arrow-key-navigation"></a><span data-ttu-id="c575f-335">方向キー ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c575f-335">Arrow key navigation</span></span>

<span data-ttu-id="c575f-336">ユーザーは、UI 領域に似たような関連するコントロールのグループがあるとき、方向キー ナビゲーションがサポートされることを期待します。</span><span class="sxs-lookup"><span data-stu-id="c575f-336">Users expect support for arrow key navigation when there is a group of similar, related controls in a UI region:</span></span>
-   `AppBarButtons` <span data-ttu-id="c575f-337">-</span><span class="sxs-lookup"><span data-stu-id="c575f-337">in a</span></span> `CommandBar`
-   `ListItems` <span data-ttu-id="c575f-338">または `GridItems` - `ListView` または</span><span class="sxs-lookup"><span data-stu-id="c575f-338">or `GridItems` inside `ListView` or</span></span> `GridView`
-   `Buttons` <span data-ttu-id="c575f-339">-</span><span class="sxs-lookup"><span data-stu-id="c575f-339">inside</span></span> `ContentDialog`

<span data-ttu-id="c575f-340">UWP コントロールは、方向キー ナビゲーションを既定でサポートします。</span><span class="sxs-lookup"><span data-stu-id="c575f-340">UWP controls support arrow key navigation by default.</span></span> <span data-ttu-id="c575f-341">カスタム レイアウトおよびコントロール グループでは、`XYFocusKeyboardNavigation="Enabled"` を使って同様の動作を提供します。</span><span class="sxs-lookup"><span data-stu-id="c575f-341">For custom layouts and control groups, use `XYFocusKeyboardNavigation="Enabled"` to provide similar behavior.</span></span>

<span data-ttu-id="c575f-342">次のコントロールがある場合、方向キー ナビゲーションのサポートを追加することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c575f-342">Consider adding support for arrow key navigation when you have for following controls:</span></span>

<table>
  <tr>
    <td>
      <p>![dialog](images/keyboard/dialog.png)</p>
      <p>**<span data-ttu-id="c575f-344">Buttons</span><span class="sxs-lookup"><span data-stu-id="c575f-344">Buttons</span></span>**</p>
      <p>![radiobutton](images/keyboard/radiobutton.png)</p>
      <p>**<span data-ttu-id="c575f-346">RadioButtons</span><span class="sxs-lookup"><span data-stu-id="c575f-346">RadioButtons</span></span>**</p>     
    </td>
    <td>
      <p>![appbar](images/keyboard/appbar.png)</p>
      <p>**<span data-ttu-id="c575f-348">AppBarButtons</span><span class="sxs-lookup"><span data-stu-id="c575f-348">AppBarButtons</span></span>**</p>
      <p>![リスト項目とグリッド項目](images/keyboard/list-and-grid-items.png)</p>
      <p>**<span data-ttu-id="c575f-350">ListItems および GridItems</span><span class="sxs-lookup"><span data-stu-id="c575f-350">ListItems and GridItems</span></span>**</p>
    </td>    
  </tr>
</table>

#### <a name="tab-stops"></a><span data-ttu-id="c575f-351">タブ位置</span><span class="sxs-lookup"><span data-stu-id="c575f-351">Tab stops</span></span>

<span data-ttu-id="c575f-352">アプリの機能とレイアウトによっては、子要素、複数のタブ位置、またはいくつかの組み合わせに対する方向キー ナビゲーションによる 1 つのタブ位置がコントロール グループのナビゲーション オプションとして最適な場合があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-352">Depending on your app’s functionality and layout, the best navigation option for a control group might be a single tab stop with arrow navigation to child elements, multiple tab stops, or some combination.</span></span>

##### <a name="use-multiple-tab-stops-and-arrow-keys-for-buttons"></a><span data-ttu-id="c575f-353">ボタンに複数のタブ位置と方向キーを使う</span><span class="sxs-lookup"><span data-stu-id="c575f-353">Use multiple tab stops and arrow keys for buttons</span></span>

<span data-ttu-id="c575f-354">アクセシビリティ ユーザーは、通常はボタンのコレクションの移動に方向キーを使わない、実績のあるキーボード ナビゲーション ルールに依存しています。</span><span class="sxs-lookup"><span data-stu-id="c575f-354">Accessibility users rely on well-established keyboard navigation rules, which do not typically use arrow keys to navigate a collection of buttons.</span></span> <span data-ttu-id="c575f-355">ただし、視覚に障碍のないユーザーは、動作が自然であると感じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-355">However, users without visual impairments might feel that the behavior is natural.</span></span>

<span data-ttu-id="c575f-356">この場合、既定の UWP の動作の例は `ContentDialog` です。</span><span class="sxs-lookup"><span data-stu-id="c575f-356">An example of default UWP behavior in this case is the `ContentDialog`.</span></span> <span data-ttu-id="c575f-357">方向キーはボタン間の移動に使うことができますが、各ボタンはタブ位置でもあります。</span><span class="sxs-lookup"><span data-stu-id="c575f-357">While arrow keys can be used to navigate between buttons, each button is also a tab stop.</span></span>

##### <a name="assign-single-tab-stop-to-familiar-ui-patterns"></a><span data-ttu-id="c575f-358">使い慣れた UI パターンに 1 つのタブ位置を割り当てる</span><span class="sxs-lookup"><span data-stu-id="c575f-358">Assign single tab stop to familiar UI patterns</span></span>

<span data-ttu-id="c575f-359">レイアウトがコントロール グループのよく知られている UI パターンに従っている場合、グループに 1 つのタブ位置を割り当てるとユーザーのナビゲーション効率を向上することがあります。</span><span class="sxs-lookup"><span data-stu-id="c575f-359">In cases where your layout follows a well-known UI pattern for control groups, assigning a single tab stop to the group can improve navigation efficiency for users.</span></span>

<span data-ttu-id="c575f-360">たとえば、次のものがあります。</span><span class="sxs-lookup"><span data-stu-id="c575f-360">Examples include:</span></span>
-   `RadioButtons`
-   <span data-ttu-id="c575f-361">複数の `ListViews` は似ており、次と同様に動作: </span><span class="sxs-lookup"><span data-stu-id="c575f-361">Multiple `ListViews` that look like and behave like a single</span></span> `ListView`
-   <span data-ttu-id="c575f-362">タイルのグリッドと外観や動作が似ている UI (スタート メニューのタイルなど)</span><span class="sxs-lookup"><span data-stu-id="c575f-362">Any UI made to look and behave like grid of tiles (such as the Start menu tiles)</span></span>

#### <a name="specifying-control-group-behavior"></a><span data-ttu-id="c575f-363">コントロール グループの動作を指定する</span><span class="sxs-lookup"><span data-stu-id="c575f-363">Specifying control group behavior</span></span>

<span data-ttu-id="c575f-364">カスタム コントロール グループの動作は、以下の API を使ってサポートします (すべてこのトピックの後半で詳しく説明します)。</span><span class="sxs-lookup"><span data-stu-id="c575f-364">Use the following APIs to support custom control group behavior (all are discussed in more detail later in this topic):</span></span>

-   <span data-ttu-id="c575f-365">[XYFocusKeyboardNavigation](custom-keyboard-interactions.md#xyfocuskeyboardnavigation) は、コントロール間での方向キー ナビゲーションを可能にします。</span><span class="sxs-lookup"><span data-stu-id="c575f-365">[XYFocusKeyboardNavigation](custom-keyboard-interactions.md#xyfocuskeyboardnavigation) enables arrow key navigation between controls</span></span>
-   <span data-ttu-id="c575f-366">[TabFocusNavigation](custom-keyboard-interactions.md#tab-navigation) は、タブ位置が複数か 1 つかを示します。</span><span class="sxs-lookup"><span data-stu-id="c575f-366">[TabFocusNavigation](custom-keyboard-interactions.md#tab-navigation) indicates whether there are multiple tab stops or single tab stop</span></span>
-   <span data-ttu-id="c575f-367">[FindFirstFocusableElement and FindLastFocusableElement](managing-focus-navigation.md#findfirstfocusableelement) は、フォーカスを **Home** キーによって最初の項目に、**End** キーによって最後の項目に設定します。</span><span class="sxs-lookup"><span data-stu-id="c575f-367">[FindFirstFocusableElement and FindLastFocusableElement](managing-focus-navigation.md#findfirstfocusableelement) sets focus on the first item with **Home** key and the last item with **End** key</span></span>

<span data-ttu-id="c575f-368">次の図は、関連付けれらたラジオ ボタンのコントロール グループにおける直感的なキーボード ナビゲーションの動作を示しています。</span><span class="sxs-lookup"><span data-stu-id="c575f-368">The following image shows an intuitive keyboard navigation behavior for a control group of associated radio buttons.</span></span> <span data-ttu-id="c575f-369">この場合、コントロール グループの 1 つのタブ位置、方向キーを使ったラジオ ボタン間の内部ナビゲーション、最初のラジオ ボタンにバインドされた **Home** キー、最後のラジオ ボタンにバインドされた **End** キーをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c575f-369">In this case, we recommend a single tab stop for the control group, inner navigation between the radio buttons using the arrow keys, **Home** key bound to the first radio button, and **End** key bound to the last radio button.</span></span>

![組み立てる](images/keyboard/putting-it-all-together.png)

### <a name="keyboard-and-narrator"></a><span data-ttu-id="c575f-371">キーボードとナレーター</span><span class="sxs-lookup"><span data-stu-id="c575f-371">Keyboard and Narrator</span></span>

<span data-ttu-id="c575f-372">ナレーターは、キーボード ユーザーを対象に用意された UI アクセシビリティ ツールです (他の入力の種類もサポートされます)。</span><span class="sxs-lookup"><span data-stu-id="c575f-372">Narrator is a UI accessibility tool geared towards keyboard users (other input types are also supported).</span></span> <span data-ttu-id="c575f-373">ただし、ナレーター機能は UWP アプリによりサポートされているキーボード操作を上回るため、ナレーター用に UWP アプリを設計するときは特別な注意が必要です </span><span class="sxs-lookup"><span data-stu-id="c575f-373">However, Narrator functionality goes beyond the keyboard interactions supported by UWP apps and extra care is required when designing your UWP app for Narrator.</span></span> <span data-ttu-id="c575f-374">(ナレーターのユーザー エクスペリエンスについては、「[ナレーターの基本について](https://support.microsoft.com/help/22808/windows-10-narrator-learning-basics)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-374">(The [Narrator basics page](https://support.microsoft.com/help/22808/windows-10-narrator-learning-basics) guides you through the Narrator user experience.)</span></span>

<span data-ttu-id="c575f-375">UWP のキーボードの動作とナレーターによりサポートされている動作の違いには、以下のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="c575f-375">Some of the differences between UWP keyboard behaviors and those supported by Narrator include:</span></span>
-   <span data-ttu-id="c575f-376">標準的なキーボード ナビゲーションでは表示されない UI 要素にナビゲーションするための追加のキーの組み合わせ (CapsLock + 方向キーを使ってコントロール ラベルを読み上げるなど)。</span><span class="sxs-lookup"><span data-stu-id="c575f-376">Extra key combinations for navigation to UI elements that are not exposed through standard keyboard navigation, such as Caps lock + arrow keys to read control labels.</span></span>
-   <span data-ttu-id="c575f-377">無効な項目へのナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="c575f-377">Navigation to disabled items.</span></span> <span data-ttu-id="c575f-378">既定では、無効な項目は標準的なキーボード ナビゲーションによって表示されません。</span><span class="sxs-lookup"><span data-stu-id="c575f-378">By default, disabled items are not exposed through standard keyboard navigation.</span></span>
    -   <span data-ttu-id="c575f-379">UI の細かさに基づいてすばやくナビゲーションするための コントロール "ビュー"。</span><span class="sxs-lookup"><span data-stu-id="c575f-379">Control "views" for quicker navigation based on UI granularity.</span></span> <span data-ttu-id="c575f-380">ユーザーは、項目、文字、単語、行、段落、リンク、見出し、表、ランドマーク、および候補に移動できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-380">Users can navigate to items, characters, word, lines, paragraphs, links, headings, tables, landmarks, and suggestions.</span></span> <span data-ttu-id="c575f-381">標準的なキーボード ナビゲーションでは、これらのオブジェクトが階層のないリストとして表示されるため、ショートカット キーがないとナビゲーションしにくくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-381">Standard keyboard navigation exposes these objects as a flat list, which might make navigation cumbersome unless you provide shortcut keys.</span></span>

#### <a name="case-study--autosuggestbox-control"></a><span data-ttu-id="c575f-382">ケース スタディ – AutoSuggestBox コントロール</span><span class="sxs-lookup"><span data-stu-id="c575f-382">Case Study – AutoSuggestBox control</span></span>

<span data-ttu-id="c575f-383">`AutoSuggestBox` の検索ボタンでは、ユーザーが **Enter** キーを押して検索クエリを送信できるため、Tab および方向キーを使って標準的なキーボード ナビゲーションにアクセスすることができません。</span><span class="sxs-lookup"><span data-stu-id="c575f-383">The search button for the `AutoSuggestBox` is not accessible to standard keyboard navigation using tab and arrow keys because the user can press the **Enter** key to submit the search query.</span></span> <span data-ttu-id="c575f-384">ただし、ユーザーが CapsLock + 方向キーを押すとナレーターを通じてアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="c575f-384">However, it is accessible through Narrator when the user presses Caps Lock + an arrow key.</span></span>

![自動提案のキーボード フォーカス](images/keyboard/auto-suggest-keyboard.png)

<span data-ttu-id="c575f-386">***キーボードでは***、*ユーザーは * ***Enter*** *キーを使って検索クエリを送信する*</span><span class="sxs-lookup"><span data-stu-id="c575f-386">***With keyboard***, *users use* ***Enter*** *key to submit search query*</span></span>

<table>
  <tr>
    <td>
      <p>![自動提案のナレーター フォーカス](images/keyboard/auto-suggest-narrator-1.png)</p>
      <p><span data-ttu-id="c575f-388">**ナレーターでは、***ユーザーは Enter キーを使って検索クエリを送信する*</span><span class="sxs-lookup"><span data-stu-id="c575f-388">**With Narrator,** *users can use Enter key to submit search query*</span></span></P>
    </td>
    <td>
      <p>![検索における自動提案のナレーター フォーカス](images/keyboard/auto-suggest-narrator-2.png)</p>
      <p>*<span data-ttu-id="c575f-390">ユーザーは、CapsLock + 右方向キーを使って検索ボタンにアクセスし、Space キーを押すこともできる</span><span class="sxs-lookup"><span data-stu-id="c575f-390">User is also able to access the search button by Caps Lock + Right arrow key, then press Space key</span></span>*</p>
    </td>
  </tr>
</table>

### <a name="keyboard-and-the-xbox-gamepad-and-remote-control"></a><span data-ttu-id="c575f-391">キーボードと Xbox ゲームパッドおよびリモコン</span><span class="sxs-lookup"><span data-stu-id="c575f-391">Keyboard and the Xbox gamepad and remote control</span></span>

<span data-ttu-id="c575f-392">Xbox のゲームパッドとリモコンは、UWP の多くのキーボード動作とエクスペリエンスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="c575f-392">Xbox gamepads and remote controls support many UWP keyboard behaviors and experiences.</span></span> <span data-ttu-id="c575f-393">ただし、キーボードで使用可能なさまざまなキー オプションが不足しているため、ゲームパッドとリモコンに多くのキーボード最適化がありません (リモコンはゲームパッドよりもさらに制限されます)。</span><span class="sxs-lookup"><span data-stu-id="c575f-393">However, due to the lack of various key options available on a keyboard, gamepad and remote control lack many keyboard optimizations (remote control is even more limited than gamepad).</span></span>

<span data-ttu-id="c575f-394">ゲームパッドおよびリモコン入力の UWP によるサポートについて詳しくは、「[Xbox およびテレビ向け設計](designing-for-tv.md#gamepad-and-remote-control)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-394">See [designing for Xbox and TV](designing-for-tv.md#gamepad-and-remote-control) for more detail on UWP support for gamepad and remote control input.</span></span>

<span data-ttu-id="c575f-395">キーボード、ゲームパッド、リモコンにおける対応するキーの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="c575f-395">The following shows some key mappings between keyboard, gamepad, and remote control.</span></span>

| **<span data-ttu-id="c575f-396">キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-396">Keyboard</span></span>**  | **<span data-ttu-id="c575f-397">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="c575f-397">Gamepad</span></span>**                         | **<span data-ttu-id="c575f-398">リモコン</span><span class="sxs-lookup"><span data-stu-id="c575f-398">Remote control</span></span>**  |
|---------------|-------------------------------------|---------------------|
| <span data-ttu-id="c575f-399">Space</span><span class="sxs-lookup"><span data-stu-id="c575f-399">Space</span></span>         | <span data-ttu-id="c575f-400">A ボタン</span><span class="sxs-lookup"><span data-stu-id="c575f-400">A button</span></span>                            | <span data-ttu-id="c575f-401">[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="c575f-401">Select button</span></span>       |
| <span data-ttu-id="c575f-402">Enter</span><span class="sxs-lookup"><span data-stu-id="c575f-402">Enter</span></span>         | <span data-ttu-id="c575f-403">A ボタン</span><span class="sxs-lookup"><span data-stu-id="c575f-403">A button</span></span>                            | <span data-ttu-id="c575f-404">[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="c575f-404">Select button</span></span>       |
| <span data-ttu-id="c575f-405">Esc</span><span class="sxs-lookup"><span data-stu-id="c575f-405">Escape</span></span>        | <span data-ttu-id="c575f-406">B ボタン</span><span class="sxs-lookup"><span data-stu-id="c575f-406">B button</span></span>                            | <span data-ttu-id="c575f-407">[戻る] ボタン</span><span class="sxs-lookup"><span data-stu-id="c575f-407">Back button</span></span>         |
| <span data-ttu-id="c575f-408">Home/End</span><span class="sxs-lookup"><span data-stu-id="c575f-408">Home/End</span></span>      | <span data-ttu-id="c575f-409">該当なし</span><span class="sxs-lookup"><span data-stu-id="c575f-409">N/A</span></span>                                 | <span data-ttu-id="c575f-410">該当なし</span><span class="sxs-lookup"><span data-stu-id="c575f-410">N/A</span></span>                 |
| <span data-ttu-id="c575f-411">PageUp/PageDown</span><span class="sxs-lookup"><span data-stu-id="c575f-411">Page Up/Down</span></span>  | <span data-ttu-id="c575f-412">縦スクロールはトリガー ボタン、横スクロールはバンパー ボタン</span><span class="sxs-lookup"><span data-stu-id="c575f-412">Trigger button for vertical scroll, Bumper button for horizontal scroll</span></span>   | <span data-ttu-id="c575f-413">該当なし</span><span class="sxs-lookup"><span data-stu-id="c575f-413">N/A</span></span>                 |

<span data-ttu-id="c575f-414">ゲームパッドとリモコンを使う UWP アプリを設計する際に注意すべきいくつかキーの相違点は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c575f-414">Some key differences you should be aware of when designing your UWP app for use with gamepad and remote control usage include:</span></span>
-   <span data-ttu-id="c575f-415">テキストを入力するには、ユーザーは A を押してテキスト コントロールをアクティブ化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-415">Text entry requires the user to press A to activate a text control.</span></span>
-   <span data-ttu-id="c575f-416">フォーカス ナビゲーションは、コントロール グループに限定されるわけではありません。ユーザーは、アプリ内のフォーカス可能な任意の UI 要素に自由に移動できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-416">Focus navigation is not limited to control groups, users can navigate freely to any focusable UI element in the app.</span></span>

    <span data-ttu-id="c575f-417">**NOTE** フォーカスは、キーを押した方向にあるフォーカス可能な任意の UI 要素に移動できます。ただし、その要素がオーバーレイ UI にある場合や、[フォーカス エンゲージメント](designing-for-tv.md#focus-engagement)が指定されている場合 (A ボタンによってエンゲージ/エンゲージ解除されるまでフォーカスが領域に入ったり出たりすることができないため) を除きます。</span><span class="sxs-lookup"><span data-stu-id="c575f-417">**NOTE** Focus can move to any focusable UI element in the key press direction unless it is in an overlay UI or [focus engagement](designing-for-tv.md#focus-engagement) is specified, which prevents focus from entering/exiting a region until engaged/disengaged with the A button.</span></span> <span data-ttu-id="c575f-418">詳しくは、「[方向ナビゲーション](#directional-navigation)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-418">For more info, see the [directional navigation](#directional-navigation) section.</span></span>
-   <span data-ttu-id="c575f-419">コントロール間、および内部ナビゲーション用にフォーカスを移動するには、方向パッドと左スティックのボタンが使用されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-419">D-pad and left stick buttons are used to move focus between controls and for inner navigation.</span></span>

    <span data-ttu-id="c575f-420">**注** ゲームパッドとリモコンは、方向キーが押されたとき、同じ表示順序内にある項目のみ移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-420">**NOTE** Gamepad and remote control only navigate to items that are in the same visual order as the directional key pressed.</span></span> <span data-ttu-id="c575f-421">フォーカスを受け取ることができる後続の要素がない場合、その方向のナビゲーションは無効になります。</span><span class="sxs-lookup"><span data-stu-id="c575f-421">Navigation is disabled in that direction when there is no subsequent element that can receive focus.</span></span> <span data-ttu-id="c575f-422">状況によっては、キーボード ユーザーは必ずしもそのような制約を持っているわけではありません。</span><span class="sxs-lookup"><span data-stu-id="c575f-422">Depending on the situation, keyboard users do not always have that constraint.</span></span> <span data-ttu-id="c575f-423">詳しくは、「[組み込みキーボードの最適化](#built-in-keyboard-optimization)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-423">See the [Built in keyboard optimization](#built-in-keyboard-optimization) section for more info.</span></span>

#### <a name="directional-navigation-a-namedirectional-navigation"></a><span data-ttu-id="c575f-424">方向ナビゲーション <a name="directional-navigation"></span><span class="sxs-lookup"><span data-stu-id="c575f-424">Directional navigation <a name="directional-navigation"></span></span>

<span data-ttu-id="c575f-425">方向ナビゲーションは、UWP [Focus Manager](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.FocusManager) ヘルパー クラスにより管理されます。このヘルパー クラスは、方向キーが押されたことを認識し (方向キー、方向パッド)、対応する視覚的な向きにフォーカスを移動しようとします。</span><span class="sxs-lookup"><span data-stu-id="c575f-425">Directional navigation is managed by a UWP [Focus Manager](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.FocusManager) helper class, which takes the directional key pressed (arrow key, D-pad) and attempts to move focus in the corresponding visual direction.</span></span>

<span data-ttu-id="c575f-426">キーボードとは異なり、アプリが[マウス モード](designing-for-tv.md#mouse-mode)をオプトアウトした場合、ゲームパッドとリモコンを使うアプリケーション全体にわたって方向ナビゲーションが適用されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-426">Unlike the keyboard, when an app opts out of [Mouse Mode](designing-for-tv.md#mouse-mode), directional navigation is applied across the entire application for gamepad and remote control .</span></span> <span data-ttu-id="c575f-427">ゲームパッドとリモコン用の方向ナビゲーションの最適化について詳しくは、[XY フォーカス ナビゲーションと対話式操作に関する記事](designing-for-tv.md#xy-focus-navigation-and-interaction)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-427">Visit [XY focus navigation and interaction article](designing-for-tv.md#xy-focus-navigation-and-interaction) for more detail on directional navigation optimizations for gamepad and remote control.</span></span>

<span data-ttu-id="c575f-428">**注**キーボードの Tab キーを使ったナビゲーションは、方向ナビゲーションとは見なされません。</span><span class="sxs-lookup"><span data-stu-id="c575f-428">**NOTE** Navigation using the keyboard Tab key is not considered directional navigation.</span></span> <span data-ttu-id="c575f-429">詳しくは、「[タブ位置](#tab-stops)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-429">For more info, see the [Tab stops](#tab-stops) section.</span></span>

<table>
  <tr>
    <td>
      <p>![方向ナビゲーション](images/keyboard/directional-navigation.png)</p>
      <p>***<span data-ttu-id="c575f-431">サポートされている方向ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c575f-431">Directional navigation supported</span></span>*** </br>*<span data-ttu-id="c575f-432">方向キー (キーボードの方向キー、ゲームパッドとリモコンの方向パッド) を使って、ユーザーはコントロール間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-432">Using directional keys (keyboard arrows, gamepad and remote control D-pad), user can navigate between different controls.</span></span>*</p>
    </td>
    <td>
      <p>![方向ナビゲーションなし](images/keyboard/no-directional-navigation.png)</p>
      <p>***<span data-ttu-id="c575f-434">サポートされていない方向ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c575f-434">Directional navigation not supported</span></span>*** </br>*<span data-ttu-id="c575f-435">ユーザーは、方向キーを使ってコントロール間を移動することはできません。</span><span class="sxs-lookup"><span data-stu-id="c575f-435">User cannot navigate between different controls using directional keys.</span></span> <span data-ttu-id="c575f-436">コントロール間を移動する他の方法 (Tab キー) は影響を受けません。</span><span class="sxs-lookup"><span data-stu-id="c575f-436">Other methods of navigating between controls (tab key) are not impacted.</span></span>*</p>
    </td>
  </tr>
</table>

### <a name="built-in-keyboard-optimization-a-namebuilt-in-keyboard-optimization"></a><span data-ttu-id="c575f-437">組み込みキーボードの最適化 <a name="built-in-keyboard-optimization"></span><span class="sxs-lookup"><span data-stu-id="c575f-437">Built in keyboard optimization <a name="built-in-keyboard-optimization"></span></span>

<span data-ttu-id="c575f-438">使用されているレイアウトとコントロールによっては、特にキーボード入力に合わせて UWP アプリを最適化できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-438">Depending on the layout and controls used, UWP apps can be optimized specifically for keyboard input.</span></span>

<span data-ttu-id="c575f-439">次の例は、1 つのタブ位置に割り当てられているリスト項目、グリッド項目、メニュー項目のグループを示しています (「[タブ位置](#tab-stops)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-439">The following example shows a group of list items, grid items, and menu items that have been assigned to a single tab stop (see the [Tab stops](#tab-stops) section).</span></span> <span data-ttu-id="c575f-440">グループにフォーカスがある場合、方向キーによって、対応する表示順序で内部ナビゲーションが実行されます (「[ナビゲーション」](#navigation)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-440">When the group has focus, inner navigation is performed with the directional arrow keys in the corresponding visual order (see [Navigation](#navigation) section).</span></span>

![単一列の方向キー ナビゲーション](images/keyboard/single-column-arrow.png)

***<span data-ttu-id="c575f-442">単一列の方向キー ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c575f-442">Single Column Arrow Key Navigation</span></span>***

![単一行の方向キー ナビゲーション](images/keyboard/single-row-arrow.png)

***<span data-ttu-id="c575f-444">単一行の方向キー ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c575f-444">Single Row Arrow Key Navigation</span></span>***

![複数列および行の方向キー ナビゲーション](images/keyboard/multiple-column-and-row-navigation.png)

***<span data-ttu-id="c575f-446">複数列および行の方向キー ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c575f-446">Multiple Column/Row Arrow Key Navigation</span></span>***

#### <a name="wrapping-homogeneous-list-and-grid-view-items"></a><span data-ttu-id="c575f-447">同種のリスト項目およびグリッド ビュー項目の折り返し</span><span class="sxs-lookup"><span data-stu-id="c575f-447">Wrapping homogeneous List and Grid View Items</span></span>

<span data-ttu-id="c575f-448">List 項目と GridView 項目の複数の行と列を移動する場合、必ずしも方向ナビゲーションが最も効率的な方法とは限りません。</span><span class="sxs-lookup"><span data-stu-id="c575f-448">Directional navigation is not always the most efficient way to navigate multiple rows and columns of List and GridView items.</span></span>

<span data-ttu-id="c575f-449">**注** メニュー項目は通常単一列のリストですが、場合によっては特別なフォーカス ルールが適用されることがあります (「[ポップアップ UI](#popup-ui)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c575f-449">**NOTE** Menu items are typically single column lists, but special focus rules might apply in some cases (see [Popup UI](#popup-ui)).</span></span>

<span data-ttu-id="c575f-450">リスト オブジェクトとグリッド オブジェクトは複数の行と列を使って作成されることがあります。</span><span class="sxs-lookup"><span data-stu-id="c575f-450">List and Grid objects can be created with multiple rows and columns.</span></span> <span data-ttu-id="c575f-451">このようなオブジェクトには通常、行優先順序 (まず項目が行全体に入力されてから、次の行に入力される) または列優先順序 (まず項目が列全体に入力されてから次の列に入力される) が適用されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-451">These are typically in row-major (where items fill entire row first before filling in the next row) or column-major (where items fill entire column first before filling in the next column) order.</span></span> <span data-ttu-id="c575f-452">行または列優先順序は、スクロールの方向によって決まり、項目の順序がこの方向と競合しないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-452">Row or column major order depends on scroll direction and you should ensure that item order does not conflict with this direction.</span></span>

<span data-ttu-id="c575f-453">行優先順序 (項目が左から右、上から下に入力される) では、フォーカスが行内の最後の項目に置かれて右方向キーが押されると、フォーカスは次の行の最初の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-453">In row-major order (where items fill in left to right, top to bottom), when the focus is on the last item in a row and the Right arrow key is pressed, focus is moved to the first item in the next row.</span></span> <span data-ttu-id="c575f-454">これと同じ動作が逆の順序で発生します。フォーカスが行内の最初の項目に置かれて左方向キーが押されると、フォーカスは前の行の最後の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-454">This same behavior occurs in reverse: When focus is set to the first item in a row and the Left arrow key is pressed, focus is moved to the last item in the previous row.</span></span>

<span data-ttu-id="c575f-455">列優先順序 (項目が上から下、左から右に入力される) では、フォーカスが列内の最後に項目に置かれて、ユーザーが下方向キーを押すと、フフォーカスが次の列の最初の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-455">In column-major order (where items fill in top to bottom, left to right), when the focus is on the last item in a column and user presses the Down arrow key, focus is moved to the first item in the next column.</span></span> <span data-ttu-id="c575f-456">これと同じ動作が逆の順序で発生します。フォーカスが列内の最初の項目に置かれて上方向キーが押されると、フォーカスは前の列の最後の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-456">This same behavior occurs in reverse: When focus is set to the first item in a column and the Up arrow key is pressed, focus is moved to the last item in the previous column.</span></span>

<table>
  <tr>
    <td>
      <p>![行優先キーボード ナビゲーション](images/keyboard/row-major-keyboard.png)</p>
      <p>***<span data-ttu-id="c575f-458">行優先キーボード ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c575f-458">Row major keyboard navigation</span></span>***</p>
    </td>
    <td>
      <p>![列優先キーボード ナビゲーション](images/keyboard/column-major-keyboard.png)</p>
      <p>***<span data-ttu-id="c575f-460">列優先キーボード ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c575f-460">Column major keyboard navigation</span></span>***</p>
    </td>
  </tr>
</table>

#### <a name="popup-ui-a-namepopup-ui"></a><span data-ttu-id="c575f-461">ポップアップ UI <a name="popup-ui"></span><span class="sxs-lookup"><span data-stu-id="c575f-461">Popup UI <a name="popup-ui"></span></span>

<span data-ttu-id="c575f-462">前述のように、方向ナビゲーションがアプリの UI におけるコントロールの表示順序に対応するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="c575f-462">As mentioned, you should try to ensure directional navigation corresponds to the visual order of the controls in your app’s UI.</span></span>

<span data-ttu-id="c575f-463">`ContextMenu`、`AppBarOverflowMenu`、`AutoSuggest` など、一部のコントロールには、プライマリ コントロールを基準とする場所と方向で表示される (使用可能な画面領域に基づく) メニュー ポップアップが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c575f-463">Some controls, such as `ContextMenu`, `AppBarOverflowMenu`, and `AutoSuggest`, include a menu popup that is displayed in a location and direction relative to the primary control (based on available screen space).</span></span> <span data-ttu-id="c575f-464">たとえば、メニューが下方向 (既定の方向) に開くのに十分な領域がない場合は、上方向に開きます。</span><span class="sxs-lookup"><span data-stu-id="c575f-464">For example, when there is insufficient space for the menu to open downwards (the default direction), it opens upwards.</span></span> <span data-ttu-id="c575f-465">メニューが毎回同じ方向に表示されるという保証はありません。</span><span class="sxs-lookup"><span data-stu-id="c575f-465">There is no guarantee that the menu opens in the same direction every time.</span></span>

<table>
  <td>![下方向キーによってコマンド バーが下方向に開く](images/keyboard/command-bar-open-down.png)</td>
  <td>![下方向キーによってコマンド バーが上方向に開く](images/keyboard/command-bar-open-up.png)</td>
</table>

<span data-ttu-id="c575f-468">これらのコントロールでは、メニューが最初に開かれたとき (ユーザーによって項目が選択されていない状態)、下方向キーは常に最初の項目にフォーカスを設定し、上方向キーは常にフォーカスをメニューの最後の項目に設定します。</span><span class="sxs-lookup"><span data-stu-id="c575f-468">For these controls, when the menu is first opened (and no item has been selected by the user), the Down arrow key always sets focus to the first item and the Up arrow key always sets focus to the last item on the menu.</span></span> <span data-ttu-id="c575f-469">同様に、最後の項目が選択されて下方向キーが押されると、フォーカスはメニューの最初の項目に移動し、最初の項目が選択されて上方向キーが押されると、フォーカスはメニューの最後の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="c575f-469">Similarly, when the last item is selected and the Down arrow key is pressed, focus moves to the first item on the menu and when the first item is selected and the Up arrow key is pressed, focus moves to the last item on the menu.</span></span>

<span data-ttu-id="c575f-470">これと同じ動作をカスタム コントロールでエミュレートしてみてください。</span><span class="sxs-lookup"><span data-stu-id="c575f-470">You should try to emulate these same behaviors in your custom controls.</span></span> <span data-ttu-id="c575f-471">この動作を実装する方法を示すコード サンプルは、「[フォーカス ナビゲーションの管理](managing-focus-navigation.md#popup-ui-code-sample)」にあります。</span><span class="sxs-lookup"><span data-stu-id="c575f-471">Code sample on how to implement this behavior can be found in [Managing focus navigation](managing-focus-navigation.md#popup-ui-code-sample) documentation.</span></span>

## <a name="test-your-app"></a><span data-ttu-id="c575f-472">アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="c575f-472">Test your app</span></span>

<span data-ttu-id="c575f-473">サポートされているすべての入力デバイスを使ってアプリをテストし、UI 要素が一貫した直感的な方法で移動できることと、要素と目的のタブ位置の予期しない干渉がないことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="c575f-473">Test your app with all supported input devices to ensure UI elements can be navigated to in a coherent and intuitive way and that no unexpected elements interfere with the desired tab order.</span></span>

## <a name="related-articles"></a><span data-ttu-id="c575f-474">関連記事</span><span class="sxs-lookup"><span data-stu-id="c575f-474">Related articles</span></span>
* [<span data-ttu-id="c575f-475">キーボード イベント</span><span class="sxs-lookup"><span data-stu-id="c575f-475">Keyboard events</span></span>](keyboard-events.md)
* [<span data-ttu-id="c575f-476">入力デバイスの識別</span><span class="sxs-lookup"><span data-stu-id="c575f-476">Identify input devices</span></span>](identify-input-devices.md)
* [<span data-ttu-id="c575f-477">タッチ キーボードの表示への応答</span><span class="sxs-lookup"><span data-stu-id="c575f-477">Respond to the presence of the touch keyboard</span></span>](respond-to-the-presence-of-the-touch-keyboard.md)
* [<span data-ttu-id="c575f-478">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="c575f-478">Focus visuals sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619895)

## <a name="appendix"></a><span data-ttu-id="c575f-479">付録</span><span class="sxs-lookup"><span data-stu-id="c575f-479">Appendix</span></span>

### <a name="software-keyboard-a-nametouch-keyboard"></a><span data-ttu-id="c575f-480">ソフトウェア キーボード <a name="touch-keyboard"></span><span class="sxs-lookup"><span data-stu-id="c575f-480">Software keyboard <a name="touch-keyboard"></span></span>

<span data-ttu-id="c575f-481">ソフトウェア キーボードは、物理的なキーボードの代わりにユーザーが使うことができる画面上のキーボードです。タッチ、マウス、ペン/スタイラス、またはその他のポインティング デバイスを通じてデータを入力します (タッチ スクリーンは必須ではありません)。</span><span class="sxs-lookup"><span data-stu-id="c575f-481">Software keyboard is a keyboard that is displayed on screen that user can use instead of the physical keyboard to type and enter data using touch, mouse, pen/stylus or other pointing device (a touch screen is not required).</span></span> <span data-ttu-id="c575f-482">タッチ画面では、これらのキーボードを直接タッチしてテキストを入力することもできます。</span><span class="sxs-lookup"><span data-stu-id="c575f-482">On touch screen, these keyboards can be touched directly to enter text as well.</span></span> <span data-ttu-id="c575f-483">Xbox One デバイスでは、ゲームパッドやリモコンを使ってフォーカス表示を移動したりショートカット キーを使ったりすることで、個々のキーを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c575f-483">On Xbox One devices, individual keys need to be selected by moving focus visual or using shortcut keys using gamepad or remote control.</span></span>

![Windows 10 のタッチ キーボード](images/keyboard/kbdpcdefault.png)

***<span data-ttu-id="c575f-485">Windows 10 のタッチ キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-485">Windows 10 Touch Keyboard</span></span>***

![Windows 10 スマートフォンのタッチ キーボード](images/keyboard/kbdwpdefault.png)

***<span data-ttu-id="c575f-487">Windows Phone 10 のタッチ キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-487">Windows Phone 10 Touch Keyboard</span></span>***

![Xbox One のスクリーン キーボード](images/keyboard/xbox-onscreen-keyboard.png)

***<span data-ttu-id="c575f-489">Xbox One のスクリーン キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-489">Xbox One Onscreen Keyboard</span></span>***

<span data-ttu-id="c575f-490">デバイスに応じて、ソフトウェア キーボードは、テキスト フィールドやその他の編集可能なテキスト コントロールがフォーカスを取得したとき、またはユーザーが**通知センター**で手動でタッチ キーボードを有効にしたときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="c575f-490">Depending on the device, the software keyboard appears when a text field or other editable text control gets focus, or when the user manually enables it through the **Notification Center**:</span></span>

![通知センターでのタッチ キーボードのアイコン](images/keyboard/touch-keyboard-notificationcenter.png)

<span data-ttu-id="c575f-492">テキスト入力コントロールへのフォーカスをプログラムで設定するアプリの場合、タッチ キーボードは呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="c575f-492">If your app sets focus programmatically to a text input control, the touch keyboard is not invoked.</span></span> <span data-ttu-id="c575f-493">これにより、ユーザーの直接的な操作による予期しない動作を回避できます。</span><span class="sxs-lookup"><span data-stu-id="c575f-493">This eliminates unexpected behaviors not instigated directly by the user.</span></span> <span data-ttu-id="c575f-494">ただし、プログラムによってキーボードがテキスト入力コントロール以外に移動されると、キーボードが自動的に非表示になります。</span><span class="sxs-lookup"><span data-stu-id="c575f-494">However, the keyboard does automatically hide when focus is moved programmatically to a non-text input control.</span></span>

<span data-ttu-id="c575f-495">通常、ユーザーがフォームでコントロール間を移動している間は、タッチ キーボードは表示されたままです。</span><span class="sxs-lookup"><span data-stu-id="c575f-495">The touch keyboard typically remains visible while the user navigates between controls in a form.</span></span> <span data-ttu-id="c575f-496">この動作は、フォーム内の他のコントロールの種類に基づいて異なります。</span><span class="sxs-lookup"><span data-stu-id="c575f-496">This behavior can vary based on the other control types within the form.</span></span>

<span data-ttu-id="c575f-497">タッチ キーボードを使用するテキスト入力セッション中に、キーボードを閉じずにフォーカスを受け取ることができる非編集コントロールの一覧を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c575f-497">The following is a list of non-edit controls that can receive focus during a text entry session using the touch keyboard without dismissing the keyboard.</span></span> <span data-ttu-id="c575f-498">ユーザーがこれらのコントロールとタッチ キーボードによるテキスト入力との間で何度も行き来することが考えられるため、UI の表示を不必要に切り替えてユーザーを混乱させることのないよう、タッチ キーボードは表示されたままになります。</span><span class="sxs-lookup"><span data-stu-id="c575f-498">Rather than needlessly churn the UI and potentially disorient the user, the touch keyboard remains in view because the user is likely to go back and forth between these controls and text entry with the touch keyboard.</span></span>

-   <span data-ttu-id="c575f-499">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="c575f-499">Check box</span></span>
-   <span data-ttu-id="c575f-500">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="c575f-500">Combo box</span></span>
-   <span data-ttu-id="c575f-501">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="c575f-501">Radio button</span></span>
-   <span data-ttu-id="c575f-502">スクロール バー</span><span class="sxs-lookup"><span data-stu-id="c575f-502">Scroll bar</span></span>
-   <span data-ttu-id="c575f-503">ツリー</span><span class="sxs-lookup"><span data-stu-id="c575f-503">Tree</span></span>
-   <span data-ttu-id="c575f-504">ツリー項目</span><span class="sxs-lookup"><span data-stu-id="c575f-504">Tree item</span></span>
-   <span data-ttu-id="c575f-505">メニュー</span><span class="sxs-lookup"><span data-stu-id="c575f-505">Menu</span></span>
-   <span data-ttu-id="c575f-506">メニュー バー</span><span class="sxs-lookup"><span data-stu-id="c575f-506">Menu bar</span></span>
-   <span data-ttu-id="c575f-507">メニュー項目</span><span class="sxs-lookup"><span data-stu-id="c575f-507">Menu item</span></span>
-   <span data-ttu-id="c575f-508">ツール バー</span><span class="sxs-lookup"><span data-stu-id="c575f-508">Toolbar</span></span>
-   <span data-ttu-id="c575f-509">一覧</span><span class="sxs-lookup"><span data-stu-id="c575f-509">List</span></span>
-   <span data-ttu-id="c575f-510">一覧項目</span><span class="sxs-lookup"><span data-stu-id="c575f-510">List item</span></span>

<span data-ttu-id="c575f-511">次に、タッチ キーボードのさまざまなモードの例を示します。</span><span class="sxs-lookup"><span data-stu-id="c575f-511">Here are examples of different modes for the touch keyboard.</span></span> <span data-ttu-id="c575f-512">最初の画像は既定のレイアウトであり、2 つ目の画像は親指レイアウトです (一部の言語では利用できません)。</span><span class="sxs-lookup"><span data-stu-id="c575f-512">The first image is the default layout, the second is the thumb layout (which might not be available in all languages).</span></span>

![既定のレイアウト モードのタッチ キーボード](images/keyboard/touchkeyboard-standard.png)

***<span data-ttu-id="c575f-514">既定のレイアウト モードのタッチ キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-514">The touch keyboard in default layout mode</span></span>***

![拡張レイアウト モードのタッチ キーボード](images/keyboard/touchkeyboard-expanded.png)

***<span data-ttu-id="c575f-516">拡張レイアウト モードのタッチ キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-516">The touch keyboard in expanded layout mode</span></span>***

![親指レイアウト モードのタッチ キーボード](images/keyboard/touchkeyboard-thumb.png)

***<span data-ttu-id="c575f-518">既定の親指レイアウト モードのタッチ キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-518">The touch keyboard in default thumb layout mode</span></span>***

![数字親指レイアウト モードのタッチ キーボード](images/keyboard/touchkeyboard-numeric-thumb.png)

***<span data-ttu-id="c575f-520">数字親指レイアウト モードのタッチ キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-520">The touch keyboard in numeric thumb layout mode</span></span>***

<span data-ttu-id="c575f-521">キーボード操作に成功すると、ユーザーはキーボードのみを使って基本のアプリ シナリオを実行できます。つまり、ユーザーはすべての対話型要素にアクセスし、既定の機能をアクティブにすることができます。</span><span class="sxs-lookup"><span data-stu-id="c575f-521">Successful keyboard interactions enable users to accomplish basic app scenarios using only the keyboard; that is, users can reach all interactive elements and activate default functionality.</span></span> <span data-ttu-id="c575f-522">成功の度合いには、キーボード ナビゲーション、アクセシビリティ対応のアクセス キー、上級ユーザー用のアクセラレータ (ショートカット) キーなど、さまざまな要因が影響します。</span><span class="sxs-lookup"><span data-stu-id="c575f-522">A number of factors can affect the degree of success, including keyboard navigation, access keys for accessibility, and accelerator (or shortcut) keys for advanced users.</span></span>

<span data-ttu-id="c575f-523">**注**  タッチ キーボードでは、トグルや、ほとんどのシステム コマンドがサポートされません。</span><span class="sxs-lookup"><span data-stu-id="c575f-523">**NOTE**  The touch keyboard does not support toggle and most system commands.</span></span>

#### <a name="on-screen-keyboard-a-nameosk"></a><span data-ttu-id="c575f-524">スクリーン キーボード <a name="osk"></span><span class="sxs-lookup"><span data-stu-id="c575f-524">On-Screen Keyboard <a name="osk"></span></span>
<span data-ttu-id="c575f-525">ソフトウェア キーボードと同様、スクリーン キーボードは、物理的なキーボードの代わりに使うことができる視覚的なソフトウェア キーボードです。タッチ、マウス、ペン/スタイラス、またはその他のポインティング デバイスを通じてデータを入力します (タッチ スクリーンは必須ではありません)。</span><span class="sxs-lookup"><span data-stu-id="c575f-525">Like software keyboard, the On-Screen Keyboard is a visual, software keyboard that you can use instead of the physical keyboard to type and enter data using touch, mouse, pen/stylus or other pointing device (a touch screen is not required).</span></span> <span data-ttu-id="c575f-526">スクリーン キーボードは、物理的なキーボードが存在しないシステムや、運動障碍により一般的な物理入力デバイスを使うことができないユーザーのために用意されています。</span><span class="sxs-lookup"><span data-stu-id="c575f-526">The On-Screen Keyboard is provided for systems that don't have a physical keyboard, or for users whose mobility impairments prevent them from using traditional physical input devices.</span></span> <span data-ttu-id="c575f-527">スクリーン キーボードは、ハードウェア キーボードの機能のすべて、または少なくともほとんどをエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="c575f-527">The On-Screen Keyboard emulates most, if not all, the functionality of a hardware keyboard.</span></span>

<span data-ttu-id="c575f-528">スクリーン キーボードは、[設定] &gt; [簡単操作] の [キーボード] ページから有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="c575f-528">The On-Screen Keyboard can be turned on from the Keyboard page in Settings &gt; Ease of access.</span></span>

<span data-ttu-id="c575f-529">**注** スクリーン キーボードの方がタッチ キーボードより優先され、スクリーン キーボードが表示されている場合はタッチ キーボードは表示されません。</span><span class="sxs-lookup"><span data-stu-id="c575f-529">**NOTE** The On-Screen Keyboard has priority over the touch keyboard, which won't be shown if the On-Screen Keyboard is present.</span></span>

![スクリーン キーボード](images/keyboard/osk.png)

***<span data-ttu-id="c575f-531">スクリーン キーボード</span><span class="sxs-lookup"><span data-stu-id="c575f-531">On-Screen Keyboard</span></span>***

<span data-ttu-id="c575f-532">スクリーン キーボードについて詳しくは、[スクリーン キーボードに関するページ](https://support.microsoft.com/help/10762/windows-use-on-screen-keyboard)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c575f-532">Visit [On-Screen keyboard page](https://support.microsoft.com/help/10762/windows-use-on-screen-keyboard) for more details about On-Screen Keyboard.</span></span>
