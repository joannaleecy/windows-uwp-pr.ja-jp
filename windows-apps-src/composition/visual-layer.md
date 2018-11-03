---
author: jwmsft
ms.assetid: a2751e22-6842-073a-daec-425fb981bafe
title: ビジュアル レイヤー
description: Windows.UI.Composition API を使うと、フレーム ワーク層 (XAML) とグラフィック層 (DirectX) との間のコンポジション層にアクセスできます。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2dd8c53dad735cf1094410bf97a81f6b0247bdc7
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5988391"
---
# <a name="visual-layer"></a><span data-ttu-id="32eb1-104">ビジュアル レイヤー</span><span class="sxs-lookup"><span data-stu-id="32eb1-104">Visual layer</span></span>

<span data-ttu-id="32eb1-105">ビジュアル レイヤーは、グラフィックス、効果、アニメーション用の高パフォーマンスの保持モード API を提供し、Windows デバイス間ですべての UI の基盤となります。</span><span class="sxs-lookup"><span data-stu-id="32eb1-105">The Visual layer provides a high performance, retained-mode API for graphics, effects and animations, and is the foundation for all UI across Windows devices.</span></span><span data-ttu-id="32eb1-106">宣言的な方法で UI を定義すると、ビジュアル レイヤーは、グラフィックス ハードウェア アクセラレータを利用し、アプリの UI スレッドから独立して、エラーのない、なめらかな方法でコンテンツ、効果、アニメーションをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="32eb1-106">You define your UI in a declarative manner and the Visual layer relies on graphics hardware acceleration to ensure your content, effects and animations are rendered in a smooth, glitch-free manner independent of the app's UI thread.</span></span>

<span data-ttu-id="32eb1-107">主な特長は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="32eb1-107">Notable highlights:</span></span>

* <span data-ttu-id="32eb1-108">使い慣れた WinRT API</span><span class="sxs-lookup"><span data-stu-id="32eb1-108">Familiar WinRT APIs</span></span>
* <span data-ttu-id="32eb1-109">さらに動的な UI と対話式操作を実現する設計</span><span class="sxs-lookup"><span data-stu-id="32eb1-109">Architected for more dynamic UI and interactions</span></span>
* <span data-ttu-id="32eb1-110">デザイン ツールとの一貫した概念</span><span class="sxs-lookup"><span data-stu-id="32eb1-110">Concepts aligned with design tools</span></span>
* <span data-ttu-id="32eb1-111">突然パフォーマンスが低下することがない直線的なスケーラビリティ</span><span class="sxs-lookup"><span data-stu-id="32eb1-111">Linear scalability with no sudden performance cliffs</span></span>

<span data-ttu-id="32eb1-112">Windows UWP アプリは、いずれかの UI フレームワークを介してビジュアル レイヤーを既に使用しています。</span><span class="sxs-lookup"><span data-stu-id="32eb1-112">Your Windows UWP apps are already using the Visual layer via one of the UI frameworks.</span></span> <span data-ttu-id="32eb1-113">非常にわずかな労力で、カスタム レンダリング、効果、アニメーションに直接ビジュアル レイヤーを利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-113">You can also take advantage of Visual layer directly for custom rendering, effects and animations with very little effort.</span></span>

![UI フレームワークの階層: フレームワーク レイヤー (Windows.UI.XAML) はビジュアル レイヤー (Windows.UI.Composition) を基盤とし、ビジュアル レイヤーはさらにグラフィック レイヤー (DirectX) を基盤としている](images/layers-win-ui-composition.png)

## <a name="whats-in-the-visual-layer"></a><span data-ttu-id="32eb1-115">ビジュアル レイヤーとは</span><span class="sxs-lookup"><span data-stu-id="32eb1-115">What's in the Visual layer?</span></span>

<span data-ttu-id="32eb1-116">ビジュアル レイヤーの主な機能は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="32eb1-116">The primary functions of the Visual layer are:</span></span>

1. <span data-ttu-id="32eb1-117">**コンテンツ**: カスタム描画コンテンツの軽量合成</span><span class="sxs-lookup"><span data-stu-id="32eb1-117">**Content**: Lightweight compositing of custom drawn content</span></span>
1. <span data-ttu-id="32eb1-118">**効果**: 効果をアニメーション化、チェーン化、カスタマイズできる、リアルタイム UI 効果システム</span><span class="sxs-lookup"><span data-stu-id="32eb1-118">**Effects**: Real-time UI effects system whose effects can be animated, chained and customized</span></span>
1. <span data-ttu-id="32eb1-119">**アニメーション**: UI スレッドから独立して実行される、表現力豊かな、フレームワークに依存しないアニメーション</span><span class="sxs-lookup"><span data-stu-id="32eb1-119">**Animations**: Expressive, framework-agnostic animations running independent of the UI thread</span></span>

### <a name="content"></a><span data-ttu-id="32eb1-120">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="32eb1-120">Content</span></span>

<span data-ttu-id="32eb1-121">コンテンツは、ビジュアルを使用するアニメーションおよび効果システムで使用できるように、ホスト、変換、提供されます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-121">Content is hosted, transformed and made available for use by the animation and effects system using visuals.</span></span> <span data-ttu-id="32eb1-122">クラス階層の基底クラスは [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) クラスで、コンポジターでビジュアル状態を処理するアプリ プロセスにおける、軽量でスレッド アジャイルなプロキシです。</span><span class="sxs-lookup"><span data-stu-id="32eb1-122">At the base of the class hierarchy is the [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) class, a lightweight, thread-agile proxy in the app process for visual state in the compositor.</span></span> <span data-ttu-id="32eb1-123">Visual のサブクラスでは、子コンテンツの視覚効果とが含まれている[**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433)のツリーを作成できるようにする [**ContainerVisual**](https://msdn.microsoft.com/library/windows/apps/Dn706810)を含めるし、カスタム描画コンテンツ、視覚効果、単色で塗りつぶすことができます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-123">Sub-classes of Visual include [**ContainerVisual**](https://msdn.microsoft.com/library/windows/apps/Dn706810) to allow for children to create trees of visuals and [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) that contains content and can be painted with either solid colors, custom drawn content or visual effects.</span></span> <span data-ttu-id="32eb1-124">また、これらの種類のビジュアルは 2D UI 用のビジュアル ツリー構造を構成し、多くの表示される XAML FrameworkElements を強化します。</span><span class="sxs-lookup"><span data-stu-id="32eb1-124">Together, these Visual types make up the visual tree structure for 2D UI and back most visible XAML FrameworkElements.</span></span>

<span data-ttu-id="32eb1-125">詳しくは、[コンポジションのビジュアル](composition-visual-tree.md)の概要をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="32eb1-125">For more information, see the [Composition Visual](composition-visual-tree.md) overview.</span></span>

### <a name="effects"></a><span data-ttu-id="32eb1-126">効果</span><span class="sxs-lookup"><span data-stu-id="32eb1-126">Effects</span></span>

<span data-ttu-id="32eb1-127">ビジュアル レイヤーの効果システムでは、ビジュアルやビジュアル ツリーにフィルターや透明効果のチェーンを適用できます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-127">The Effects system in the Visual layer lets you apply a chain of filter and transparency effects to a Visual or a tree of Visuals.</span></span> <span data-ttu-id="32eb1-128">これは UI 効果システムであり、画像やメディアの効果を混同しないでください。</span><span class="sxs-lookup"><span data-stu-id="32eb1-128">This is a UI effects system, not to be confused with image and media effects.</span></span> <span data-ttu-id="32eb1-129">効果はアニメーション システムとの組み合わせで動作し、ユーザーは、UI スレッドから独立してレンダリングされる、スムーズで動的な効果プロパティのアニメーションを実現できます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-129">Effects work in conjunction with the Animation system, allowing users to achieve smooth and dynamic animations of Effect properties, rendered independent of the UI thread.</span></span> <span data-ttu-id="32eb1-130">ビジュアル レイヤーの効果は、カスタマイズされたと対話型エクスペリエンスを構築するために組み合わせてアニメーション化できる、創造的な構成要素を提供します。</span><span class="sxs-lookup"><span data-stu-id="32eb1-130">Effects in the Visual Layer provide the creative building blocks that can be combined and animated to construct tailored and interactive experiences.</span></span>

<span data-ttu-id="32eb1-131">ビジュアル レイヤーは、アニメーション化可能な効果のチェーンに加えて、アニメーション化可能なライトに応答することにより、ビジュアルでマテリアル プロパティを模倣できるようにする照明モデルもサポートします。</span><span class="sxs-lookup"><span data-stu-id="32eb1-131">In addition to animatable effect chains, the Visual Layer also supports a lighting model that allows Visuals to mimic material properties by responding to animatable lights.</span></span> <span data-ttu-id="32eb1-132">ビジュアルによって、シャドウを生じさせることもできます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-132">Visuals may also cast shadows.</span></span> <span data-ttu-id="32eb1-133">照明とシャドウを組み合わせて使うことで、奥行きとリアルさを感じられるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-133">Lighting and shadows can be combined to create a perception of depth and realism.</span></span>

<span data-ttu-id="32eb1-134">詳しくは、[コンポジション効果](composition-effects.md)の概要をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="32eb1-134">For more information, see the [Composition Effects](composition-effects.md) overview.</span></span>

### <a name="animations"></a><span data-ttu-id="32eb1-135">アニメーション</span><span class="sxs-lookup"><span data-stu-id="32eb1-135">Animations</span></span>

<span data-ttu-id="32eb1-136">ビジュアル レイヤーのアニメーション システムによって、移動の視覚効果、効果のアニメーション化、変換、クリップ、その他のプロパティの駆動を実現できます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-136">The animation system in the Visual layer lets you move visuals, animate effects, and drive transformations, clips, and other properties.</span></span><span data-ttu-id="32eb1-137">これは、パフォーマンスを考慮して一から設計された、フレームワークに依存しないシステムです。</span><span class="sxs-lookup"><span data-stu-id="32eb1-137"> It is a framework agnostic system that has been designed from the ground up with performance in mind.</span></span><span data-ttu-id="32eb1-138">UI スレッドから独立して実行されるため、滑らかさとスケーラビリティが実現されます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-138"> It runs independently from the UI thread to ensure smoothness and scalability.</span></span><span data-ttu-id="32eb1-139">使い慣れたキー フレーム アニメーションを使って時間の経過に伴うプロパティの変化を駆動できる一方で、ユーザー入力を含む、さまざまなプロパティ間の数学的な関係を設定して、シームレスな演出エクスペリエンスを直接作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-139"> While it lets you use familiar KeyFrame animations to drive property changes over time, it also lets you set up mathematical relationships between different properties, including user input, letting you directly craft seamless choreographed experiences.</span></span>

<span data-ttu-id="32eb1-140">詳しくは、[コンポジションのアニメーション](composition-animation.md)の概要をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="32eb1-140">For more information, see the [Composition animations](composition-animation.md) overview.</span></span>

### <a name="working-with-your-xaml-uwp-app"></a><span data-ttu-id="32eb1-141">XAML UWP アプリの操作</span><span class="sxs-lookup"><span data-stu-id="32eb1-141">Working with your XAML UWP app</span></span>

<span data-ttu-id="32eb1-142">[**Windows.UI.Xaml.Hosting**](https://msdn.microsoft.com/library/windows/apps/Hh701908) の [**ElementCompositionPreview**](https://msdn.microsoft.com/library/windows/apps/Mt608976) クラスを使用して、XAML フレームワークによってビジュアルを作成できるようになり、表示可能な FrameworkElement を強化することができます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-142">You can get to a Visual created by the XAML framework, and backing a visible FrameworkElement, using the [**ElementCompositionPreview**](https://msdn.microsoft.com/library/windows/apps/Mt608976) class in [**Windows.UI.Xaml.Hosting**](https://msdn.microsoft.com/library/windows/apps/Hh701908).</span></span> <span data-ttu-id="32eb1-143">フレームワークによって作成されたビジュアルには、カスタマイズに関するいくつかの制限があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="32eb1-143">Note that Visuals created for you by the framework come with some limits on customization.</span></span> <span data-ttu-id="32eb1-144">これは、フレームワークがオフセット、変換、有効期間を管理するためです。</span><span class="sxs-lookup"><span data-stu-id="32eb1-144">This is because the framework is managing offsets, transforms and lifetimes.</span></span> <span data-ttu-id="32eb1-145">ただし、独自のビジュアルを作成し、ElementCompositionPreview によって、またはビジュアル ツリー構造内のどこかに既にある ContainerVisual に追加することにより、既存の XAML 要素にアタッチできます。</span><span class="sxs-lookup"><span data-stu-id="32eb1-145">You can however create your own Visuals and attach them to an existing XAML element via ElementCompositionPreview, or by adding it to an existing ContainerVisual somewhere in the visual tree structure.</span></span>

<span data-ttu-id="32eb1-146">詳しくは、[XAML でのビジュアル レイヤーの使用](using-the-visual-layer-with-xaml.md)の概要をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="32eb1-146">For more information, see the [Using the Visual layer with XAML](using-the-visual-layer-with-xaml.md) overview.</span></span>

## <a name="additional-resources"></a><span data-ttu-id="32eb1-147">その他の資料</span><span class="sxs-lookup"><span data-stu-id="32eb1-147">Additional resources</span></span>

* [**<span data-ttu-id="32eb1-148">API に関する詳しいリファレンス ドキュメント</span><span class="sxs-lookup"><span data-stu-id="32eb1-148">Full reference documentation for the API</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn706878)
* <span data-ttu-id="32eb1-149">[WindowsUIDevLabs GitHub](https://github.com/microsoft/windowsuidevlabs) にある高度な UI とコンポジションのサンプル</span><span class="sxs-lookup"><span data-stu-id="32eb1-149">Advanced UI and Composition samples in the [WindowsUIDevLabs GitHub](https://github.com/microsoft/windowsuidevlabs)</span></span>
* [<span data-ttu-id="32eb1-150">Windows.UI.Composition サンプル ギャラリー</span><span class="sxs-lookup"><span data-stu-id="32eb1-150">Windows.UI.Composition Sample Gallery</span></span>](https://aka.ms/winuiapp)
* [<span data-ttu-id="32eb1-151">@windowsui Twitter フィード</span><span class="sxs-lookup"><span data-stu-id="32eb1-151">@windowsui Twitter feed</span></span> ](https://twitter.com/windowsui)
* <span data-ttu-id="32eb1-152">この API に関する Kenny Kerr の MSDN 記事:「[グラフィックスとアニメーション - 10 年目を迎える Windows Composition](https://msdn.microsoft.com/magazine/mt590968)」</span><span class="sxs-lookup"><span data-stu-id="32eb1-152">Read Kenny Kerr's MSDN Article on this API: [Graphics and Animation - Windows Composition Turns 10](https://msdn.microsoft.com/magazine/mt590968)</span></span>
