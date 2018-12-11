---
ms.assetid: f1297b7d-1a10-52ae-dd84-6d1ad2ae2fe6
title: コンポジションのビジュアル
description: コンポジションのビジュアル オブジェクト ツリー構造は、コンポジション API の他のすべての機能でベースとして使われます。 この API により、開発者は 1 つまたは複数のビジュアル オブジェクトを作成して定義できます。それぞれがビジュアル オブジェクト ツリーの 1 つのノードを表します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 6b1c0b78ca45d98428f38518b337b5889f595c49
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8875067"
---
# <a name="composition-visual"></a><span data-ttu-id="6e90f-105">コンポジションのビジュアル</span><span class="sxs-lookup"><span data-stu-id="6e90f-105">Composition visual</span></span>

<span data-ttu-id="6e90f-106">コンポジションのビジュアル オブジェクト ツリー構造は、コンポジション API の他のすべての機能でベースとして使われます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-106">Composition Visuals make up the visual tree structure which all other features of the composition API use and build on.</span></span> <span data-ttu-id="6e90f-107">この API により、開発者は 1 つまたは複数のビジュアル オブジェクトを作成して定義できます。それぞれがビジュアル オブジェクト ツリーの 1 つのノードを表します。</span><span class="sxs-lookup"><span data-stu-id="6e90f-107">The API allows developers to define and create one or many visual objects each representing a single node in a visual tree.</span></span>

## <a name="visuals"></a><span data-ttu-id="6e90f-108">ビジュアル オブジェクト</span><span class="sxs-lookup"><span data-stu-id="6e90f-108">Visuals</span></span>

<span data-ttu-id="6e90f-109">ビジュアル オブジェクト ツリー構造には、3 種類のビジュアル オブジェクトが含まれ、加えて、ビジュアル オブジェクトの内容に影響を与える基本ブラシ クラスと複数のサブクラスがあります。</span><span class="sxs-lookup"><span data-stu-id="6e90f-109">There are three visual types that make up the visual tree structure plus a base brush class with multiple subclasses that affect the content of a visual:</span></span>

- <span data-ttu-id="6e90f-110">[**Visual**
            ](https://msdn.microsoft.com/library/windows/apps/Dn706858) – ベース オブジェクト。プロパティの大半はここにあり、他のビジュアル オブジェクトによって継承されます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-110">[**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) – base object, the majority of the properties are here, and inherited by the other Visual objects.</span></span>
- <span data-ttu-id="6e90f-111">[**ContainerVisual**](https://msdn.microsoft.com/library/windows/apps/Dn706810) – [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) から派生し、子ビジュアル オブジェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-111">[**ContainerVisual**](https://msdn.microsoft.com/library/windows/apps/Dn706810) – derives from [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858), and adds the ability to create children.</span></span>
- <span data-ttu-id="6e90f-112">[**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) – [**ContainerVisual**](https://msdn.microsoft.com/library/windows/apps/Dn706810) から派生し、ブラシを関連付けることができます。それにより、ビジュアル オブジェクトは画像、効果、単色などのピクセルをレンダリングできるようになります。</span><span class="sxs-lookup"><span data-stu-id="6e90f-112">[**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) – derives from [**ContainerVisual**](https://msdn.microsoft.com/library/windows/apps/Dn706810) and adds the ability to associate a brush so that the Visual can render pixels including images, effects or a solid color.</span></span>

<span data-ttu-id="6e90f-113">[**CompositionBrush**](https://msdn.microsoft.com/library/windows/apps/Mt589398) とそのサブクラスである [**CompositionColorBrush**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)、[**CompositionSurfaceBrush**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)、[**CompositionEffectBrush**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) を使用して、コンテンツと効果を SpriteVisual に適用できます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-113">You can apply content and effects to SpriteVisuals using the [**CompositionBrush**](https://msdn.microsoft.com/library/windows/apps/Mt589398) and its subclasses including the [**CompositionColorBrush**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush), [**CompositionSurfaceBrush**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) and [**CompositionEffectBrush**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush).</span></span> <span data-ttu-id="6e90f-114">ブラシについて詳しくは、「[**CompositionBrush の概要**](https://docs.microsoft.com/windows/uwp/composition/composition-brushes)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6e90f-114">To learn more about brushes see our [**CompositionBrush Overview**](https://docs.microsoft.com/windows/uwp/composition/composition-brushes).</span></span>

## <a name="the-compositionvisual-sample"></a><span data-ttu-id="6e90f-115">CompositionVisual のサンプル</span><span class="sxs-lookup"><span data-stu-id="6e90f-115">The CompositionVisual Sample</span></span>

<span data-ttu-id="6e90f-116">ここでは、前に説明した 3 つの種類のビジュアル タイプを使用する、いくつかのサンプル コードについて説明します。</span><span class="sxs-lookup"><span data-stu-id="6e90f-116">Here, we'll look at some sample code that demonstrates the three different visual types listed previously.</span></span> <span data-ttu-id="6e90f-117">このサンプルでは、アニメーションや複雑な効果のような概念は取り上げていませんが、それらのシステムで使われるビルディング ブロックは含まれています。</span><span class="sxs-lookup"><span data-stu-id="6e90f-117">While this sample doesn’t cover concepts like Animations or more complex effects, it contains the building blocks that all of those systems use.</span></span> <span data-ttu-id="6e90f-118">(完全なサンプル コードは、この記事の最後に示されています。)</span><span class="sxs-lookup"><span data-stu-id="6e90f-118">(The full sample code is listed at the end of this article.)</span></span>

<span data-ttu-id="6e90f-119">このサンプルでは、画面でクリックしてドラッグできる複数の単色の正方形を使います。</span><span class="sxs-lookup"><span data-stu-id="6e90f-119">In the sample are a number of solid color squares that can be clicked on and dragged about the screen.</span></span> <span data-ttu-id="6e90f-120">正方形がクリックされると、前面に移動して 45 度回転し、ドラッグされると不透明になります。</span><span class="sxs-lookup"><span data-stu-id="6e90f-120">When a square is clicked on, it will come to the front, rotate 45 degrees, and become opaque when dragged about.</span></span>

<span data-ttu-id="6e90f-121">ここでは、次のように API の操作について多数の基本的な概念を示します。</span><span class="sxs-lookup"><span data-stu-id="6e90f-121">This shows a number of basic concepts for working with the API including:</span></span>

- <span data-ttu-id="6e90f-122">コンポジターの作成</span><span class="sxs-lookup"><span data-stu-id="6e90f-122">Creating a compositor</span></span>
- <span data-ttu-id="6e90f-123">SpriteVisual と CompositionColorBrush の作成</span><span class="sxs-lookup"><span data-stu-id="6e90f-123">Creating a SpriteVisual with a CompositionColorBrush</span></span>
- <span data-ttu-id="6e90f-124">ビジュアル オブジェクトのクリッピング</span><span class="sxs-lookup"><span data-stu-id="6e90f-124">Clipping the Visual</span></span>
- <span data-ttu-id="6e90f-125">ビジュアル オブジェクトの回転</span><span class="sxs-lookup"><span data-stu-id="6e90f-125">Rotating the Visual</span></span>
- <span data-ttu-id="6e90f-126">不透明度の設定</span><span class="sxs-lookup"><span data-stu-id="6e90f-126">Setting Opacity</span></span>
- <span data-ttu-id="6e90f-127">コレクション内のビジュアル オブジェクトの位置変更</span><span class="sxs-lookup"><span data-stu-id="6e90f-127">Changing the Visual’s position in the collection.</span></span>

## <a name="creating-a-compositor"></a><span data-ttu-id="6e90f-128">コンポジターの作成</span><span class="sxs-lookup"><span data-stu-id="6e90f-128">Creating a Compositor</span></span>

<span data-ttu-id="6e90f-129">[**Compositor**](https://msdn.microsoft.com/library/windows/apps/Dn706789) を作成し、ファクトリ用に変数に格納するのは簡単です。</span><span class="sxs-lookup"><span data-stu-id="6e90f-129">Creating a [**Compositor**](https://msdn.microsoft.com/library/windows/apps/Dn706789) and storing it in a variable for use as a factory is a simple task.</span></span> <span data-ttu-id="6e90f-130">次のスニペットでは、新しい **Compositor** の作成方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6e90f-130">The following snippet shows creating a new **Compositor**:</span></span>

```cs
_compositor = new Compositor();
```

## <a name="creating-a-spritevisual-and-colorbrush"></a><span data-ttu-id="6e90f-131">SpriteVisual と ColorBrush の作成</span><span class="sxs-lookup"><span data-stu-id="6e90f-131">Creating a SpriteVisual and ColorBrush</span></span>

<span data-ttu-id="6e90f-132">[**Compositor**](https://msdn.microsoft.com/library/windows/apps/Dn706789) を使って、必要なときにオブジェクト、たとえば [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) や [**CompositionColorBrush**](https://msdn.microsoft.com/library/windows/apps/Mt589399) を作成するのは簡単です。</span><span class="sxs-lookup"><span data-stu-id="6e90f-132">Using the [**Compositor**](https://msdn.microsoft.com/library/windows/apps/Dn706789) it's easy to create objects whenever you need them, such as a [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) and a [**CompositionColorBrush**](https://msdn.microsoft.com/library/windows/apps/Mt589399):</span></span>

```cs
var visual = _compositor.CreateSpriteVisual();
visual.Brush = _compositor.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
```

<span data-ttu-id="6e90f-133">これはわずか数行のコードですが、強力な概念を示しており、[**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) オブジェクトは効果システムの中核となります。</span><span class="sxs-lookup"><span data-stu-id="6e90f-133">While this is only a few lines of code, it demonstrates a powerful concept: [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) objects are the heart of the effects system.</span></span> <span data-ttu-id="6e90f-134">**SpriteVisual** を使うと、色、画像、効果の作成で高い柔軟性と関係性を得られます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-134">The **SpriteVisual** allows for great flexibility and interplay in color, image and effect creation.</span></span> <span data-ttu-id="6e90f-135">**SpriteVisual** は、ブラシで (この例では単色) で 2D 四角形を塗りつぶすことのできるビジュアル オブジェクトの一種です。</span><span class="sxs-lookup"><span data-stu-id="6e90f-135">The **SpriteVisual** is a single visual type that can fill a 2D rectangle with a brush, in this case, a solid color.</span></span>

## <a name="clipping-a-visual"></a><span data-ttu-id="6e90f-136">ビジュアル オブジェクトのクリップ</span><span class="sxs-lookup"><span data-stu-id="6e90f-136">Clipping a Visual</span></span>

<span data-ttu-id="6e90f-137">[**Compositor**](https://msdn.microsoft.com/library/windows/apps/Dn706789) は、[**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) に対するクリップを作成するためにも使えます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-137">The [**Compositor**](https://msdn.microsoft.com/library/windows/apps/Dn706789) can also be used to create clips to a [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858).</span></span> <span data-ttu-id="6e90f-138">次に示しているのは、ビジュアル オブジェクトの両側をトリミングする [**InsetClip**](https://msdn.microsoft.com/library/windows/apps/Dn706825) を使ったサンプルからの例です。</span><span class="sxs-lookup"><span data-stu-id="6e90f-138">Below is an example from the sample of using the [**InsetClip**](https://msdn.microsoft.com/library/windows/apps/Dn706825) to trim each side of the visual:</span></span>

```cs
var clip = _compositor.CreateInsetClip();
clip.LeftInset = 1.0f;
clip.RightInset = 1.0f;
clip.TopInset = 1.0f;
clip.BottomInset = 1.0f;
_currentVisual.Clip = clip;
```

<span data-ttu-id="6e90f-139">API の他のオブジェクトと同様、[**InsetClip**](https://msdn.microsoft.com/library/windows/apps/Dn706825) のプロパティにもアニメーションを適用できます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-139">Like other objects in the API, [**InsetClip**](https://msdn.microsoft.com/library/windows/apps/Dn706825) can have animations applied to its properties.</span></span>

## <a name="span-idrotatingaclipspanspan-idrotatingaclipspanspan-idrotatingaclipspanrotating-a-clip"></a><span data-ttu-id="6e90f-140"><span id="Rotating_a_Clip"></span><span id="rotating_a_clip"></span><span id="ROTATING_A_CLIP"></span>クリップの回転</span><span class="sxs-lookup"><span data-stu-id="6e90f-140"><span id="Rotating_a_Clip"></span><span id="rotating_a_clip"></span><span id="ROTATING_A_CLIP"></span>Rotating a Clip</span></span>

<span data-ttu-id="6e90f-141">[**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) は回転により変換できます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-141">A [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) can be transformed with a rotation.</span></span> <span data-ttu-id="6e90f-142">[**RotationAngle**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.rotationangle) では、ラジアンと度の両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="6e90f-142">Note that [**RotationAngle**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.rotationangle) supports both radians and degrees.</span></span> <span data-ttu-id="6e90f-143">既定ではラジアンになりますが、次のコードに示しているように、度を指定するのは簡単です。</span><span class="sxs-lookup"><span data-stu-id="6e90f-143">It defaults to radians, but it’s easy to specify degrees as shown in the following snippet:</span></span>

```cs
child.RotationAngleInDegrees = 45.0f;
```

<span data-ttu-id="6e90f-144">Rotation は、変換が簡単になるように API に用意された一連の変換コンポーネントのほんの一例です。</span><span class="sxs-lookup"><span data-stu-id="6e90f-144">Rotation is just one example of a set of transform components provided by the API to make these tasks easier.</span></span> <span data-ttu-id="6e90f-145">そのほかにも Offset、Scale、Orientation、RotationAxis、4x4 TransformMatrix などがあります。</span><span class="sxs-lookup"><span data-stu-id="6e90f-145">Others include Offset, Scale, Orientation, RotationAxis, and 4x4 TransformMatrix.</span></span>

## <a name="setting-opacity"></a><span data-ttu-id="6e90f-146">不透明度の設定</span><span class="sxs-lookup"><span data-stu-id="6e90f-146">Setting Opacity</span></span>

<span data-ttu-id="6e90f-147">ビジュアル オブジェクトの不透明度の設定も簡単で、浮動小数値を使って指定するだけです。</span><span class="sxs-lookup"><span data-stu-id="6e90f-147">Setting the opacity of a visual is a simple operation using a float value.</span></span> <span data-ttu-id="6e90f-148">たとえば、このサンプルでは、すべての正方形の不透明度は .8 から始めています。</span><span class="sxs-lookup"><span data-stu-id="6e90f-148">For example, in the sample all the squares start at .8 opacity:</span></span>

```cs
visual.Opacity = 0.8f;
```

<span data-ttu-id="6e90f-149">Rotation と同様、[**Opacity**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.opacity) のプロパティにもアニメーションを適用できます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-149">Like rotation, the [**Opacity**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.opacity) property can be animated.</span></span>

## <a name="changing-the-visuals-position-in-the-collection"></a><span data-ttu-id="6e90f-150">コレクション内のビジュアル オブジェクトの位置変更</span><span class="sxs-lookup"><span data-stu-id="6e90f-150">Changing the Visual's position in the collection</span></span>

<span data-ttu-id="6e90f-151">コンポジション API を使うと、[**VisualCollection**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection) でのビジュアルの位置を多くの方法で変更できます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-151">The Composition API allows for a Visual's position in a [**VisualCollection**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection) to be changed in a number of ways.</span></span> <span data-ttu-id="6e90f-152">たとえば、[**InsertAbove**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection.insertabove) を使うと、別のビジュアルの上に、[**InsertBelow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection.insertbelow) を使うと、下に配置できます。[**InsertAtTop**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection.insertattop) を使うと、先頭に、[**InsertAtBottom**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection.insertatbottom) を使うと、末尾に移動できます。</span><span class="sxs-lookup"><span data-stu-id="6e90f-152">It can be placed above another Visual with [**InsertAbove**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection.insertabove), placed below with [**InsertBelow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection.insertbelow), moved to the top with [**InsertAtTop**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection.insertattop), or the bottom with [**InsertAtBottom**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visualcollection.insertatbottom).</span></span>

<span data-ttu-id="6e90f-153">このサンプルでは、クリックされた [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) は先頭に並べ替えられています。</span><span class="sxs-lookup"><span data-stu-id="6e90f-153">In the sample, a [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) that has been clicked is sorted to the top:</span></span>

```cs
parent.Children.InsertAtTop(_currentVisual);
```

## <a name="full-example"></a><span data-ttu-id="6e90f-154">完全な例</span><span class="sxs-lookup"><span data-stu-id="6e90f-154">Full Example</span></span>

<span data-ttu-id="6e90f-155">完全なサンプルでは、これまで説明した概念のすべてを一緒に使って、[**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) オブジェクトの単純なツリーを作成してたどり、XAML、WWA、または DirectX を使わずに不透明度を変更しています。</span><span class="sxs-lookup"><span data-stu-id="6e90f-155">In the full sample, all of the concepts above are used together to construct and walk a simple tree of [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) objects to change opacity without using XAML, WWA, or DirectX.</span></span> <span data-ttu-id="6e90f-156">このサンプルでは、どのように子 **Visual** オブジェクトが作成されて追加され、プロパティが変更されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="6e90f-156">This sample shows how child **Visual** objects are created and added and how properties are changed.</span></span>

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Core;

namespace compositionvisual
{
    class VisualProperties : IFrameworkView
    {
        //------------------------------------------------------------------------------
        //
        // VisualProperties.Initialize
        //
        // This method is called during startup to associate the IFrameworkView with the
        // CoreApplicationView.
        //
        //------------------------------------------------------------------------------

        void IFrameworkView.Initialize(CoreApplicationView view)
        {
            _view = view;
            _random = new Random();
        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.SetWindow
        //
        // This method is called when the CoreApplication has created a new CoreWindow,
        // allowing the application to configure the window and start producing content
        // to display.
        //
        //------------------------------------------------------------------------------

        void IFrameworkView.SetWindow(CoreWindow window)
        {
            _window = window;
            InitNewComposition();
            _window.PointerPressed += OnPointerPressed;
            _window.PointerMoved += OnPointerMoved;
            _window.PointerReleased += OnPointerReleased;
        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.OnPointerPressed
        //
        // This method is called when the user touches the screen, taps it with a stylus
        // or clicks the mouse.
        //
        //------------------------------------------------------------------------------

        void OnPointerPressed(CoreWindow window, PointerEventArgs args)
        {
            Point position = args.CurrentPoint.Position;

            //
            // Walk our list of visuals to determine who, if anybody, was selected
            //
            foreach (var child in _root.Children)
            {
                //
                // Did we hit this child?
                //
                Vector3 offset = child.Offset;
                Vector2 size = child.Size;

                if ((position.X >= offset.X) &&
                    (position.X < offset.X + size.X) &&
                    (position.Y >= offset.Y) &&
                    (position.Y < offset.Y + size.Y))
                {
                    //
                    // This child was hit. Since the children are stored back to front,
                    // the last one hit is the front-most one so it wins
                    //
                    _currentVisual = child as ContainerVisual;
                    _offsetBias = new Vector2((float)(offset.X - position.X),
                                              (float)(offset.Y - position.Y));
                }
            }

            //
            // If a visual was hit, bring it to the front of the Z order
            //
            if (_currentVisual != null)
            {
                ContainerVisual parent = _currentVisual.Parent as ContainerVisual;
                parent.Children.Remove(_currentVisual);
                parent.Children.InsertAtTop(_currentVisual);
            }
        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.OnPointerMoved
        //
        // This method is called when the user moves their finger, stylus or mouse with
        // a button pressed over the screen.
        //
        //------------------------------------------------------------------------------

        void OnPointerMoved(CoreWindow window, PointerEventArgs args)
        {
            //
            // If a visual is selected, drag it with the pointer position and
            // make it opaque while we drag it
            //
            if (_currentVisual != null)
            {
                //
                // Set up the properties of the visual the first time it is
                // dragged. This will last for the duration of the drag
                //
                if (!_dragging)
                {
                    _currentVisual.Opacity = 1.0f;

                    //
                    // Transform the first child of the current visual so that
                    // the image is rotated
                    //
                    foreach (var child in _currentVisual.Children)
                    {
                        child.RotationAngleInDegrees = 45.0f;
                        child.CenterPoint = new Vector3(_currentVisual.Size.X / 2, _currentVisual.Size.Y / 2, 0);
                        break;
                    }

                    //
                    // Clip the visual to its original layout rect by using an inset
                    // clip with a one-pixel margin all around
                    //
                    var clip = _compositor.CreateInsetClip();
                    clip.LeftInset = 1.0f;
                    clip.RightInset = 1.0f;
                    clip.TopInset = 1.0f;
                    clip.BottomInset = 1.0f;
                    _currentVisual.Clip = clip;

                    _dragging = true;
                }

                Point position = args.CurrentPoint.Position;
                _currentVisual.Offset = new Vector3((float)(position.X + _offsetBias.X),
                                                    (float)(position.Y + _offsetBias.Y),
                                                    0.0f);
            }
        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.OnPointerReleased
        //
        // This method is called when the user lifts their finger or stylus from the
        // screen, or lifts the mouse button.
        //
        //------------------------------------------------------------------------------

        void OnPointerReleased(CoreWindow window, PointerEventArgs args)
        {
            //
            // If a visual was selected, make it transparent again when it is
            // released and restore the transform and clip
            //
            if (_currentVisual != null)
            {
                if (_dragging)
                {
                    //
                    // Remove the transform from the first child
                    //
                    foreach (var child in _currentVisual.Children)
                    {
                        child.RotationAngle = 0.0f;
                        child.CenterPoint = new Vector3(0.0f, 0.0f, 0.0f);
                        break;
                    }

                    _currentVisual.Opacity = 0.8f;
                    _currentVisual.Clip = null;
                    _dragging = false;
                }

                _currentVisual = null;
            }
        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.Load
        //
        // This method is called when a specific page is being loaded in the
        // application.  It is not used for this application.
        //
        //------------------------------------------------------------------------------

        void IFrameworkView.Load(string unused)
        {

        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.Run
        //
        // This method is called by CoreApplication.Run() to actually run the
        // dispatcher's message pump.
        //
        //------------------------------------------------------------------------------

        void IFrameworkView.Run()
        {
            _window.Activate();
            _window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.Uninitialize
        //
        // This method is called during shutdown to disconnect the CoreApplicationView,
        // and CoreWindow from the IFrameworkView.
        //
        //------------------------------------------------------------------------------

        void IFrameworkView.Uninitialize()
        {
            _window = null;
            _view = null;
        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.InitNewComposition
        //
        // This method is called by SetWindow(), where we initialize Composition after
        // the CoreWindow has been created.
        //
        //------------------------------------------------------------------------------

        void InitNewComposition()
        {
            //
            // Set up Windows.UI.Composition Compositor, root ContainerVisual, and associate with
            // the CoreWindow.
            //

            _compositor = new Compositor();

            _root = _compositor.CreateContainerVisual();



            _compositionTarget = _compositor.CreateTargetForCurrentView();
            _compositionTarget.Root = _root;

            //
            // Create a few visuals for our window
            //
            for (int index = 0; index < 20; index++)
            {
                _root.Children.InsertAtTop(CreateChildElement());
            }
        }

        //------------------------------------------------------------------------------
        //
        // VisualProperties.CreateChildElement
        //
        // Creates a small sub-tree to represent a visible element in our application.
        //
        //------------------------------------------------------------------------------

        Visual CreateChildElement()
        {
            //
            // Each element consists of three visuals, which produce the appearance
            // of a framed rectangle
            //
            var element = _compositor.CreateContainerVisual();
            element.Size = new Vector2(100.0f, 100.0f);

            //
            // Position this visual randomly within our window
            //
            element.Offset = new Vector3((float)(_random.NextDouble() * 400), (float)(_random.NextDouble() * 400), 0.0f);

            //
            // The outer rectangle is always white
            //
            //Note to preview API users - SpriteVisual and Color Brush replace SolidColorVisual
            //for example instead of doing
            //var visual = _compositor.CreateSolidColorVisual() and
            //visual.Color = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
            //we now use the below

            var visual = _compositor.CreateSpriteVisual();
            element.Children.InsertAtTop(visual);
            visual.Brush = _compositor.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
            visual.Size = new Vector2(100.0f, 100.0f);

            //
            // The inner rectangle is inset from the outer by three pixels all around
            //
            var child = _compositor.CreateSpriteVisual();
            visual.Children.InsertAtTop(child);
            child.Offset = new Vector3(3.0f, 3.0f, 0.0f);
            child.Size = new Vector2(94.0f, 94.0f);

            //
            // Pick a random color for every rectangle
            //
            byte red = (byte)(0xFF * (0.2f + (_random.NextDouble() / 0.8f)));
            byte green = (byte)(0xFF * (0.2f + (_random.NextDouble() / 0.8f)));
            byte blue = (byte)(0xFF * (0.2f + (_random.NextDouble() / 0.8f)));
            child.Brush = _compositor.CreateColorBrush(Color.FromArgb(0xFF, red, green, blue));

            //
            // Make the subtree root visual partially transparent. This will cause each visual in the subtree
            // to render partially transparent, since a visual's opacity is multiplied with its parent's
            // opacity
            //
            element.Opacity = 0.8f;

            return element;
        }

        // CoreWindow / CoreApplicationView
        private CoreWindow _window;
        private CoreApplicationView _view;

        // Windows.UI.Composition
        private Compositor _compositor;
        private CompositionTarget _compositionTarget;
        private ContainerVisual _root;
        private ContainerVisual _currentVisual;
        private Vector2 _offsetBias;
        private bool _dragging;

        // Helpers
        private Random _random;
    }


    public sealed class VisualPropertiesFactory : IFrameworkViewSource
    {
        //------------------------------------------------------------------------------
        //
        // VisualPropertiesFactory.CreateView
        //
        // This method is called by CoreApplication to provide a new IFrameworkView for
        // a CoreWindow that is being created.
        //
        //------------------------------------------------------------------------------

        IFrameworkView IFrameworkViewSource.CreateView()
        {
            return new VisualProperties();
        }


        //------------------------------------------------------------------------------
        //
        // main
        //
        //------------------------------------------------------------------------------

        static int Main(string[] args)
        {
            CoreApplication.Run(new VisualPropertiesFactory());

            return 0;
        }
    }
}
```
