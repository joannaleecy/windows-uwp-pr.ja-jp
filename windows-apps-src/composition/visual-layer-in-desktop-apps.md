---
title: ビジュアル層を使用して、デスクトップ アプリを最新化します。
description: ビジュアル層は、.NET や Win32 デスクトップ アプリの UI を強化するために使用します。
ms.date: 03/18/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 05793c023fa0a0b08d4487e859f31442c7c1d53a
ms.sourcegitcommit: e63fbd7a63a7e8c03c52f4219f34513f4b2bb411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/18/2019
ms.locfileid: "58174110"
---
# <a name="modernize-your-desktop-app-using-the-visual-layer"></a><span data-ttu-id="a7508-104">ビジュアル層を使用して、デスクトップ アプリを最新化します。</span><span class="sxs-lookup"><span data-stu-id="a7508-104">Modernize your desktop app using the Visual layer</span></span>

<span data-ttu-id="a7508-105">外観、外観と、Windows フォーム、WPF の機能を強化するために、デスクトップ アプリケーションを UWP 以外で UWP Api を使用することができますようになりましたしC++Win32 アプリケーションでのみ UWP を使用して利用できる最新の Windows 10 の UI 機能を活用してください。</span><span class="sxs-lookup"><span data-stu-id="a7508-105">You can now use UWP APIs in non-UWP desktop applications to enhance the look, feel, and functionality of your WPF, Windows Forms, and C++ Win32 applications, and take advantage of the latest Windows 10 UI features that are only available via UWP.</span></span>

<span data-ttu-id="a7508-106">使用することが多くのシナリオ[XAML 諸島](../xaml-platform/xaml-host-controls.md)アプリに最新の XAML コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="a7508-106">For many scenarios, you can use [XAML islands](../xaml-platform/xaml-host-controls.md) to add modern XAML controls to your app.</span></span> <span data-ttu-id="a7508-107">ただし、組み込みのコントロールだけでなくカスタム エクスペリエンスを作成する必要がある場合は、ビジュアル層の Api にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="a7508-107">However, when you need to create custom experiences that go beyond the built-in controls, you can access the Visual layer APIs.</span></span>

<span data-ttu-id="a7508-108">ビジュアル層では、高パフォーマンスのグラフィック、エフェクト、およびアニメーションの保持モード API を提供します。</span><span class="sxs-lookup"><span data-stu-id="a7508-108">The Visual layer provides a high performance, retained-mode API for graphics, effects, and animations.</span></span> <span data-ttu-id="a7508-109">Windows 10 デバイス間で UI の基盤になります。</span><span class="sxs-lookup"><span data-stu-id="a7508-109">It's the foundation for UI across Windows 10 devices.</span></span> <span data-ttu-id="a7508-110">UWP XAML コントロールは、ビジュアル層で構築され、これにより、さまざまな側面、 [Fluent Design System](../design/fluent-design-system/index.md)光、深さ、モーション、マテリアル、およびスケールなど。</span><span class="sxs-lookup"><span data-stu-id="a7508-110">UWP XAML controls are built on the Visual layer, and it enables many aspects of the [Fluent Design System](../design/fluent-design-system/index.md), such as Light, Depth, Motion, Material, and Scale.</span></span>

![ビジュアル層で作成されたユーザー インターフェイス](images/interop/pull-to-animate.gif)

> <span data-ttu-id="a7508-112">_ビジュアル層で作成されたユーザー インターフェイス_</span><span class="sxs-lookup"><span data-stu-id="a7508-112">_User interface created with the visual layer_</span></span>

## <a name="create-a-visually-engaging-user-interface-in-any-windows-app"></a><span data-ttu-id="a7508-113">すべての Windows アプリでの視覚的に魅力的なユーザー インターフェイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="a7508-113">Create a visually engaging user interface in any Windows app</span></span>

<span data-ttu-id="a7508-114">ビジュアル層では、カスタムの描画コンテンツ (ビジュアル) の軽量の合成を使用して、アプリケーションでそれらのオブジェクトに対して強力なアニメーション、エフェクト、および操作を適用して魅力的なエクスペリエンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="a7508-114">The Visual layer lets you create engaging experiences by using lightweight compositing of custom drawn content (visuals) and applying powerful animations, effects, and manipulations on those objects in your application.</span></span> <span data-ttu-id="a7508-115">ビジュアル層は、既存の UI フレームワークに代わるもの代わりに、これらのフレームワークを補足するため貴重になります。</span><span class="sxs-lookup"><span data-stu-id="a7508-115">The Visual layer doesn't replace any existing UI framework; instead, it's a valuable supplement to those frameworks.</span></span>

<span data-ttu-id="a7508-116">ビジュアル層を使用して、アプリケーションの一意のルック アンド フィールを提供し、他のアプリケーションとは別に設定された id を確立できます。</span><span class="sxs-lookup"><span data-stu-id="a7508-116">You can use the Visual layer to give your application a unique look and feel, and establish an identity that sets it apart from other applications.</span></span> <span data-ttu-id="a7508-117">ユーザーからに対するエンゲージメントの描画を使用するには、アプリケーションを簡単に設計された Fluent デザインの原則もできます。</span><span class="sxs-lookup"><span data-stu-id="a7508-117">It also enables Fluent Design principles, which are designed to make your applications easier to use, drawing more engagement from users.</span></span> <span data-ttu-id="a7508-118">たとえば、視覚的な手掛かりと画面上の項目間の関係を示すアニメーション遷移の作成に使用できます。</span><span class="sxs-lookup"><span data-stu-id="a7508-118">For example, you can use it to create visual cues and animated screen transitions that show relationships among items on the screen.</span></span>

## <a name="visual-layer-features"></a><span data-ttu-id="a7508-119">ビジュアル層の機能</span><span class="sxs-lookup"><span data-stu-id="a7508-119">Visual layer features</span></span>

### <a name="brushes"></a><span data-ttu-id="a7508-120">ブラシ</span><span class="sxs-lookup"><span data-stu-id="a7508-120">Brushes</span></span>

<span data-ttu-id="a7508-121">[合成ブラシ](composition-brushes.md)純色、グラデーション、イメージ、ビデオ、複雑な特殊効果、および詳細を UI オブジェクトを描画することができます。</span><span class="sxs-lookup"><span data-stu-id="a7508-121">[Composition brushes](composition-brushes.md) let you paint UI objects with solid colors, gradients, images, videos, complex effects, and more.</span></span>

![マテリアルの作成者で作成された、卵](images/interop/egg.gif)

> <span data-ttu-id="a7508-123">_作成された、egg、[マテリアル作成者デモ アプリ](https://github.com/Microsoft/WindowsCompositionSamples/tree/master/Demos/MaterialCreator)します。_</span><span class="sxs-lookup"><span data-stu-id="a7508-123">_An egg created with the [Material Creator demo app](https://github.com/Microsoft/WindowsCompositionSamples/tree/master/Demos/MaterialCreator)._</span></span>

### <a name="effects"></a><span data-ttu-id="a7508-124">効果</span><span class="sxs-lookup"><span data-stu-id="a7508-124">Effects</span></span>

<span data-ttu-id="a7508-125">[合成効果](composition-effects.md)ライト、シャドウ、およびフィルター効果の一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a7508-125">[Composition effects](composition-effects.md) include light, shadow, and a list of filter effects.</span></span> <span data-ttu-id="a7508-126">それらをアニメーション化、カスタマイズすると連結するなどしてビジュアルに直接適用。</span><span class="sxs-lookup"><span data-stu-id="a7508-126">They can be animated, customized, and chained, then applied directly to visuals.</span></span> <span data-ttu-id="a7508-127">大気、深さ、資料を作成する合成照明と組み合わせて、SceneLightingEffect 使用できます。</span><span class="sxs-lookup"><span data-stu-id="a7508-127">The SceneLightingEffect can be combined with composition lighting to create atmosphere, depth and materials.</span></span>

![ライトとマテリアル](images/interop/light-interop.gif)

> <span data-ttu-id="a7508-129">_ライトと素材の説明、[サンプル ギャラリーの Windows UI コンポジション](https://github.com/Microsoft/WindowsCompositionSamples/tree/master/SampleGallery)します。_</span><span class="sxs-lookup"><span data-stu-id="a7508-129">_Lights and material demonstrated in the [Windows UI Composition sample gallery](https://github.com/Microsoft/WindowsCompositionSamples/tree/master/SampleGallery)._</span></span>

### <a name="animations"></a><span data-ttu-id="a7508-130">アニメーション</span><span class="sxs-lookup"><span data-stu-id="a7508-130">Animations</span></span>

<span data-ttu-id="a7508-131">[合成アニメーション](composition-animation.md)コンポジター プロセスでは、UI スレッドから独立してで直接実行します。</span><span class="sxs-lookup"><span data-stu-id="a7508-131">[Composition animations](composition-animation.md) run directly in the compositor process, independent of the UI thread.</span></span> <span data-ttu-id="a7508-132">これにより、滑らかさとスケール、多数の同時実行、明示的なアニメーションを実行できるようにします。</span><span class="sxs-lookup"><span data-stu-id="a7508-132">This ensures smoothness and scale, so you can run large numbers of concurrent, explicit animations.</span></span> <span data-ttu-id="a7508-133">時間の経過と共にドライブ プロパティの変更に使い慣れたキーフレーム アニメーション、だけでなく、ユーザー入力を含む、各種プロパティ間の数学的な関係を設定する式を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="a7508-133">In addition to familiar KeyFrame animations to drive property changes over time, you can use expressions to set up mathematical relationships between different properties, including user input.</span></span> <span data-ttu-id="a7508-134">入力の駆動型アニメーションでは、動的かつ流動的に応答する可能性が高いユーザー エンゲージメントをユーザー入力の UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="a7508-134">Input driven animations let you create UI that dynamically and fluidly responds to user input, which can result in higher user engagement.</span></span>

![ビジュアル層で作成されたユーザー インターフェイス](images/interop/swipe-scroller.gif)

> <span data-ttu-id="a7508-136">_示されているモーション、[サンプル ギャラリーの Windows UI コンポジション](https://github.com/Microsoft/WindowsCompositionSamples/tree/master/SampleGallery)します。_</span><span class="sxs-lookup"><span data-stu-id="a7508-136">_Motion demonstrated in the [Windows UI Composition sample gallery](https://github.com/Microsoft/WindowsCompositionSamples/tree/master/SampleGallery)._</span></span>

## <a name="keep-your-existing-codebase-and-adopt-incrementally"></a><span data-ttu-id="a7508-137">既存のコードベースを保持し、段階的に採用</span><span class="sxs-lookup"><span data-stu-id="a7508-137">Keep your existing codebase and adopt incrementally</span></span>

<span data-ttu-id="a7508-138">既存のアプリケーションでコードが失われるしたくない多大な投資を表します。</span><span class="sxs-lookup"><span data-stu-id="a7508-138">The code in your existing applications represents a significant investment that you don't want to lose.</span></span> <span data-ttu-id="a7508-139">移行することができます_諸島_ビジュアル層を使用し、その既存のフレームワークで、残りの UI へのコンテンツの。</span><span class="sxs-lookup"><span data-stu-id="a7508-139">You can migrate _islands_ of content to use the Visual layer and keep the rest of the UI in its existing framework.</span></span> <span data-ttu-id="a7508-140">これは、行うことができます重要な更新プログラムと機能強化、アプリケーションの UI に、既存のコードに広範な変更を加えることがなく基本ことを意味します。</span><span class="sxs-lookup"><span data-stu-id="a7508-140">This means you can make significant updates and enhancements to your application UI without needing to make extensive changes to your existing code base.</span></span>

## <a name="samples-and-tutorials"></a><span data-ttu-id="a7508-141">サンプルおよびチュートリアル</span><span class="sxs-lookup"><span data-stu-id="a7508-141">Samples and tutorials</span></span>

<span data-ttu-id="a7508-142">サンプルを使って試してみる、アプリケーションで、ビジュアル レイヤーを使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a7508-142">Learn how to use the Visual layer in your applications by experimenting with our samples.</span></span> <span data-ttu-id="a7508-143">これらのサンプルとチュートリアル ヘルプ ビジュアル層の使用を開始し、機能のしくみを説明します。</span><span class="sxs-lookup"><span data-stu-id="a7508-143">These samples and tutorials help you get started using the Visual layer and show you how features work.</span></span>

### <a name="win32"></a><span data-ttu-id="a7508-144">Win32</span><span class="sxs-lookup"><span data-stu-id="a7508-144">Win32</span></span>

- <span data-ttu-id="a7508-145">[ビジュアル層を使用して、Win32 で](using-the-visual-layer-with-win32.md)チュートリアル</span><span class="sxs-lookup"><span data-stu-id="a7508-145">[Using the Visual layer with Win32](using-the-visual-layer-with-win32.md) tutorial</span></span>
  - [<span data-ttu-id="a7508-146">こんにちはコンポジションのサンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-146">Hello Composition sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/cpp/HelloComposition)
- [<span data-ttu-id="a7508-147">こんにちはベクトルのサンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-147">Hello Vectors sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/cpp/HelloVectors)
- [<span data-ttu-id="a7508-148">仮想サーフェスのサンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-148">Virtual Surfaces sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/cpp/VirtualSurfaces)
- [<span data-ttu-id="a7508-149">画面キャプチャのサンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-149">Screen Capture sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/cpp/ScreenCaptureforHWND)

### <a name="windows-forms"></a><span data-ttu-id="a7508-150">Windows フォーム</span><span class="sxs-lookup"><span data-stu-id="a7508-150">Windows Forms</span></span>

- <span data-ttu-id="a7508-151">[ビジュアル層を使用して Windows フォームで](using-the-visual-layer-with-windows-forms.md)チュートリアル</span><span class="sxs-lookup"><span data-stu-id="a7508-151">[Using the Visual layer with Windows Forms](using-the-visual-layer-with-windows-forms.md) tutorial</span></span>
  - [<span data-ttu-id="a7508-152">こんにちはコンポジションのサンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-152">Hello Composition sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WinForms/HelloComposition)
- [<span data-ttu-id="a7508-153">ビジュアル層の統合サンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-153">Visual Layer Integration sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WinForms/VisualLayerIntegration)

### <a name="wpf"></a><span data-ttu-id="a7508-154">WPF</span><span class="sxs-lookup"><span data-stu-id="a7508-154">WPF</span></span>

- <span data-ttu-id="a7508-155">[WPF のビジュアル層を使用して](using-the-visual-layer-with-wpf.md)チュートリアル</span><span class="sxs-lookup"><span data-stu-id="a7508-155">[Using the Visual layer with WPF](using-the-visual-layer-with-wpf.md) tutorial</span></span>
  - [<span data-ttu-id="a7508-156">こんにちはコンポジションのサンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-156">Hello Composition sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/HelloComposition)
- [<span data-ttu-id="a7508-157">ビジュアル層の統合サンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-157">Visual Layer Integration sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/VisualLayerIntegration)
- [<span data-ttu-id="a7508-158">画面キャプチャのサンプル</span><span class="sxs-lookup"><span data-stu-id="a7508-158">Screen Capture sample</span></span>](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/ScreenCapture)

## <a name="limitations"></a><span data-ttu-id="a7508-159">制限事項</span><span class="sxs-lookup"><span data-stu-id="a7508-159">Limitations</span></span>

<span data-ttu-id="a7508-160">ビジュアル層の多くの機能は、UWP アプリでのように、デスクトップ アプリケーションでホストされているときでも同じ動作、一部の機能は制限があります。</span><span class="sxs-lookup"><span data-stu-id="a7508-160">While many Visual Layer features work the same when hosted in a desktop application as they do in a UWP app, some features do have limitations.</span></span> <span data-ttu-id="a7508-161">ここで注意すべき制限事項の一部を示します。</span><span class="sxs-lookup"><span data-stu-id="a7508-161">Here are some of the limitations to be aware of:</span></span>

- <span data-ttu-id="a7508-162">効果のチェーンが依存[Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm)効果の説明についてはします。</span><span class="sxs-lookup"><span data-stu-id="a7508-162">Effect chains rely on [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) for the effect descriptions.</span></span> <span data-ttu-id="a7508-163">[Win2D NuGet パッケージ](https://www.nuget.org/packages/Win2D.uwp)から再コンパイルすることになるために、デスクトップ アプリケーションでサポートされていない、[ソース コード](https://github.com/Microsoft/Win2D)します。</span><span class="sxs-lookup"><span data-stu-id="a7508-163">The [Win2D NuGet package](https://www.nuget.org/packages/Win2D.uwp) is not supported in desktop applications, so you would need to recompile it from the [source code](https://github.com/Microsoft/Win2D).</span></span>
- <span data-ttu-id="a7508-164">実行のヒット テストを自分でビジュアル ツリーをウォークして境界の計算を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7508-164">To do hit testing, you need to do bounds calculations by walking the visual tree yourself.</span></span> <span data-ttu-id="a7508-165">これは、UWP でのビジュアル層と同じです。 ここでのヒット テストにバインドできます簡単に XAML 要素がない点が異なります。</span><span class="sxs-lookup"><span data-stu-id="a7508-165">This is the same as the Visual Layer in UWP, except in this case there's no XAML element you can easily bind to for hit testing.</span></span>
- <span data-ttu-id="a7508-166">ビジュアル層では、テキストのレンダリング プリミティブはありません。</span><span class="sxs-lookup"><span data-stu-id="a7508-166">The Visual Layer does not have a primitive for rendering text.</span></span>
- <span data-ttu-id="a7508-167">2 つの異なる UI テクノロジが一緒に使用される場合は各画面で、独自のピクセルの描画など、WPF とビジュアル層では、およびピクセルを共有することはできません。</span><span class="sxs-lookup"><span data-stu-id="a7508-167">When two different UI technologies are used together, such as WPF and the Visual Layer, they are each responsible for drawing their own pixels on the screen, and they can't share pixels.</span></span> <span data-ttu-id="a7508-168">その結果、ビジュアル層のコンテンツは常に、その他の UI コンテンツの上にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="a7508-168">As a result, Visual Layer content is always rendered on top of other UI content.</span></span> <span data-ttu-id="a7508-169">(これと呼ばれますが、_空域_問題です)。追加のコーディングを行う必要があり、テスト、ビジュアル層のコンテンツをホストの UI とサイズを変更して、その他のコンテンツがありません。</span><span class="sxs-lookup"><span data-stu-id="a7508-169">(This is known as the _airspace_ issue.) You might need to do extra coding and testing to ensure your Visual layer content resizes with the host UI and doesn't occlude other content.</span></span>
- <span data-ttu-id="a7508-170">デスクトップ アプリケーションでホストされているコンテンツは、自動的にサイズを変更または DPI のスケール。</span><span class="sxs-lookup"><span data-stu-id="a7508-170">Content hosted in a desktop application doesn't automatically resize or scale for DPI.</span></span> <span data-ttu-id="a7508-171">追加の手順は、コンテンツは、DPI の変更を処理することを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7508-171">Extra steps might required to ensure your content handles DPI changes.</span></span> <span data-ttu-id="a7508-172">(詳細についてはプラットフォーム固有のチュートリアルを参照してください)。</span><span class="sxs-lookup"><span data-stu-id="a7508-172">(See the platform specific tutorials for more info.)</span></span>

## <a name="additional-resources"></a><span data-ttu-id="a7508-173">その他のリソース</span><span class="sxs-lookup"><span data-stu-id="a7508-173">Additional Resources</span></span>

- [<span data-ttu-id="a7508-174">ビジュアル レイヤー</span><span class="sxs-lookup"><span data-stu-id="a7508-174">Visual layer</span></span>](visual-layer.md)
- [<span data-ttu-id="a7508-175">合成ビジュアル</span><span class="sxs-lookup"><span data-stu-id="a7508-175">Composition visual</span></span>](composition-visual-tree.md)
- [<span data-ttu-id="a7508-176">合成ブラシ</span><span class="sxs-lookup"><span data-stu-id="a7508-176">Composition brushes</span></span>](composition-brushes.md)
- [<span data-ttu-id="a7508-177">合成効果</span><span class="sxs-lookup"><span data-stu-id="a7508-177">Composition effects</span></span>](composition-effects.md)
- [<span data-ttu-id="a7508-178">合成アニメーション</span><span class="sxs-lookup"><span data-stu-id="a7508-178">Composition animations</span></span>](composition-animation.md)

<span data-ttu-id="a7508-179">API リファレンス</span><span class="sxs-lookup"><span data-stu-id="a7508-179">API reference</span></span>

- [<span data-ttu-id="a7508-180">Windows.UI.Composition</span><span class="sxs-lookup"><span data-stu-id="a7508-180">Windows.UI.Composition</span></span>](/uwp/api/Windows.UI.Composition)