---
author: jwmsft
title: "既存の ScrollViewer エクスペリエンスを強化する"
description: 
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, アニメーション"
localizationpriority: medium
ms.openlocfilehash: f941fd0e30fa1b52a514175cdfd4f71a9f0f1ec2
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
# <a name="enhance-existing-scrollviewer-experiences"></a><span data-ttu-id="1a2ad-103">既存の ScrollViewer エクスペリエンスを強化する</span><span class="sxs-lookup"><span data-stu-id="1a2ad-103">Enhance existing ScrollViewer experiences</span></span>

<span data-ttu-id="1a2ad-104">この記事では、XAML の ScrollViewer と ExpressionAnimations を使用して、動的な入力駆動型のモーション エクスペリエンスを作成する方法ついて説明します。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-104">This article explains how to use a XAML ScrollViewer and ExpressionAnimations to create dynamic input-driven motion experiences.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="1a2ad-105">前提条件</span><span class="sxs-lookup"><span data-stu-id="1a2ad-105">Prerequisites</span></span>

<span data-ttu-id="1a2ad-106">ここでは、以下の記事で説明されている概念を理解していることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-106">Here, we assume that you're familiar with the concepts discussed in these articles:</span></span>

- [<span data-ttu-id="1a2ad-107">入力駆動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="1a2ad-107">Input-driven animations</span></span>](input-driven-animations.md)
- [<span data-ttu-id="1a2ad-108">関係ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="1a2ad-108">Relation based animations</span></span>](relation-animations.md)

## <a name="why-build-on-top-of-scrollviewer"></a><span data-ttu-id="1a2ad-109">ScrollViewer の最上位に構築する理由</span><span class="sxs-lookup"><span data-stu-id="1a2ad-109">Why build on top of ScrollViewer?</span></span>

<span data-ttu-id="1a2ad-110">通常は既存の XAML ScrollViewer を使用して、スクロールとズームが可能なアプリ コンテンツのサーフェスを作成します。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-110">Typically, you use the existing XAML ScrollViewer to create a scrollable and zoomable surface for your app content.</span></span> <span data-ttu-id="1a2ad-111">Fluent Design 言語が導入されたことにより、現在では、サーフェスでのスクロールやズームの動作をどのように使用して、他のモーション エクスペリエンスを機能させるかといったことにも重点を置くことができます。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-111">With the introduction of the Fluent Design language, you should now also be focusing on how to use the act of scrolling or zooming a surface to drive other motion experiences.</span></span> <span data-ttu-id="1a2ad-112">たとえば、スクロールを使用して、背景のぼかしアニメーションを動作させたり、"固定ヘッダー" の位置を動かしたりします。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-112">For example, using scrolling to drive a blur animation of a background or drive the position of a "sticky header".</span></span>

<span data-ttu-id="1a2ad-113">こうしたシナリオでは、スクロールやズームなどの動作エクスペリエンスまたは操作エクスペリエンスを活用して、アプリの他の部分をより動的なものにすることができます。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-113">In these scenarios, you are leveraging the behavior or manipulation experiences like Scrolling and zooming to make other parts of your app more dynamic.</span></span> <span data-ttu-id="1a2ad-114">これにより、アプリの統一感が向上し、ユーザーにとってより覚えやすいエクスペリエンスを実現することができます。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-114">These in turn enable the app to feel more cohesive, making the experiences more memorable in the eyes of end users.</span></span> <span data-ttu-id="1a2ad-115">アプリの UI を覚えやすいものにすることで、エンド ユーザーがそのアプリを利用する頻度が高まり、長期にわたって使用するようになります。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-115">By making the app UI more memorable, end users will engage with the app more frequently and for longer periods.</span></span>

## <a name="what-can-you-build-on-top-of-scrollviewer"></a><span data-ttu-id="1a2ad-116">ScrollViewer の最上位に構築できるもの</span><span class="sxs-lookup"><span data-stu-id="1a2ad-116">What can you build on top of ScrollViewer?</span></span>

<span data-ttu-id="1a2ad-117">ScrollViewer の位置を利用して、さまざまな動的エクスペリエンスを構築することができます。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-117">You can leverage the position of a ScrollViewer to build a number of dynamic experiences:</span></span>

- <span data-ttu-id="1a2ad-118">視差 – ScrollViewer の位置を使用して、背景や前景のコンテンツをスクロール位置に対する相対速度で動かします。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-118">Parallax – use the position of a ScrollViewer to move background or foreground content at a relative rate to the scroll position.</span></span>
- <span data-ttu-id="1a2ad-119">StickyHeaders – ScrollViewer の位置を使用して、ヘッダーをアニメーション化し、任意の位置に "固定" します。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-119">StickyHeaders – use the position of a ScrollViewer to animate and "stick" a header to a position</span></span>
- <span data-ttu-id="1a2ad-120">入力駆動型効果 – Scrollviewer の位置を使用して、ぼかしなどのコンポジション効果をアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-120">Input-Driven Effects – use the position of a Scrollviewer to animate a Composition Effect such as Blur.</span></span>

<span data-ttu-id="1a2ad-121">一般に、ExpressionAnimation を使用して ScrollViewer の位置を参照することにより、相対的なスクロール量を動的に変化させるアニメーションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-121">In general, by referencing the position of a ScrollViewer with an ExpressionAnimation, you are able to create an animation that dynamically changes relative the scroll amount.</span></span>

![視差を利用したリスト ビュー](images/animation/parallax.gif)

![シャイ ヘッダー](images/animation/shy-header.gif)

## <a name="using-scrollmanipulationpropertyset"></a><span data-ttu-id="1a2ad-124">ScrollManipulationPropertySet の使用</span><span class="sxs-lookup"><span data-stu-id="1a2ad-124">Using ScrollManipulationPropertySet</span></span>

<span data-ttu-id="1a2ad-125">XAML ScrollViewer を使用して、上記のような動的エクスペリエンスを作成するには、アニメーション内のスクロール位置を参照できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-125">To create these dynamic experiences using a XAML ScrollViewer, you must be able to reference the scroll position in an animation.</span></span> <span data-ttu-id="1a2ad-126">そのためには、XAML ScrollViewer から CompositionPropertySet (ScrollManipulationPropertySet と呼ばれます) にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-126">This is done by accessing a CompositionPropertySet off of the XAML ScrollViewer called the ScrollManipulationPropertySet.</span></span>
<span data-ttu-id="1a2ad-127">ScrollManipulationPropertySet には、Translation と呼ばれる 1 つの Vector3 プロパティが含まれています。このプロパティによって、ScrollViewer のスクロール位置にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-127">The ScrollManipulationPropertySet contains a single Vector3 property called Translation that provides access to the scroll position of the ScrollViewer.</span></span> <span data-ttu-id="1a2ad-128">ScrollManipulationPropertySet にアクセスすると、ExpressionAnimation で他の CompositionPropertySet と同様に、このプロパティを参照することができます。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-128">You can then reference this like any other CompositionPropertySet in your ExpressionAnimation.</span></span>

<span data-ttu-id="1a2ad-129">作業を始める際の一般的な手順:</span><span class="sxs-lookup"><span data-stu-id="1a2ad-129">General Steps to getting started:</span></span>

1. <span data-ttu-id="1a2ad-130">ElementCompositionPreview を使用して ScrollManipulationPropertySet にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-130">Access the ScrollManipulationPropertySet via ElementCompositionPreview.</span></span>
    - `ElementCompositionPreview.GetScrollManipulationPropertySet(ScrollViewer scroller)`
1. <span data-ttu-id="1a2ad-131">PropertySet の Translation プロパティを参照する ExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-131">Create an ExpressionAnimation that references the Translation property from the PropertySet.</span></span>
    - <span data-ttu-id="1a2ad-132">参照パラメーターは必ず設定してください。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-132">Don’t forget to set the Reference Parameter!</span></span>
1. <span data-ttu-id="1a2ad-133">ExpressionAnimation を使用して CompositionObject のプロパティをターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-133">Target a CompositionObject’s property with the ExpressionAnimation.</span></span>

> [!NOTE]
> <span data-ttu-id="1a2ad-134">GetScrollManipulationPropertySet メソッドから返された PropertySet をクラス変数に割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-134">It is recommended that you assign the PropertySet returned from the GetScrollManipulationPropertySet method to a class variable.</span></span> <span data-ttu-id="1a2ad-135">これにより、プロパティ セットがガベージ コレクションによってクリーンアップされなくなります。そのため、参照されている ExpressionAnimation は影響を受けません。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-135">This ensures that the property set does not get cleaned up by Garbage Collection and thus does not have any effect on the ExpressionAnimation it is referenced in.</span></span> <span data-ttu-id="1a2ad-136">ExpressionAnimations は、式で使用されているどのオブジェクトに対しても強参照を保持しません。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-136">ExpressionAnimations do not maintain a strong reference to any of the objects used in the equation.</span></span>

## <a name="example"></a><span data-ttu-id="1a2ad-137">例</span><span class="sxs-lookup"><span data-stu-id="1a2ad-137">Example</span></span>

<span data-ttu-id="1a2ad-138">前に示した視差のサンプルがどのように構成されているかを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-138">Let's take a look at how the Parallax sample shown above is put together.</span></span> <span data-ttu-id="1a2ad-139">アプリのすべてのソース コードについては、[Window UI Dev Labs repo on GitHub](https://github.com/Microsoft/WindowsUIDevLabs) (GitHub の Windows UI 開発ラボ リポジトリ) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-139">For reference, all the source code for the app is found in the [Window UI Dev Labs repo on GitHub](https://github.com/Microsoft/WindowsUIDevLabs).</span></span>

<span data-ttu-id="1a2ad-140">最初に、ScrollManipulationPropertySet への参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-140">The first thing is to get a reference to the ScrollManipulationPropertySet.</span></span>

```csharp
_scrollProperties =
    ElementCompositionPreview.GetScrollViewerManipulationPropertySet(myScrollViewer);
```

<span data-ttu-id="1a2ad-141">次の手順では、ScrollViewer のスクロール位置を利用する式を定義する ExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-141">The next step is to create the ExpressionAnimation that defines an equation that utilizes the scroll Position of the ScrollViewer.</span></span>

```csharp
_parallaxExpression = compositor.CreateExpressionAnimation();
_parallaxExpression.SetScalarParameter("StartOffset", 0.0f);
_parallaxExpression.SetScalarParameter("ParallaxValue", 0.5f);
_parallaxExpression.SetScalarParameter("ItemHeight", 0.0f);
_parallaxExpression.SetReferenceParameter("ScrollManipulation", _scrollProperties);
_parallaxExpression.Expression = "(ScrollManipulation.Translation.Y + StartOffset - (0.5 * ItemHeight)) * ParallaxValue - (ScrollManipulation.Translation.Y + StartOffset - (0.5 * ItemHeight))";
```

> [!NOTE]
> <span data-ttu-id="1a2ad-142">ExpressionBuilder ヘルパー クラスを利用して、これと同じ Expression を作成することもできます。次の文字列は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-142">You can also utilize ExpressionBuilder helper classes to construct this same Expression without the need for Strings:</span></span>

> ```csharp
> var scrollPropSet = _scrollProperties.GetSpecializedReference<ManipulationPropertySetReferenceNode>();
> var parallaxValue = 0.5f;
> var parallax = (scrollPropSet.Translation.Y + startOffset);
> _parallaxExpression = parallax * parallaxValue - parallax;
> ```

<span data-ttu-id="1a2ad-143">最後に、この ExpressionAnimation を実行し、視差で必要となる Visual をターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-143">Finally, you take this ExpressionAnimation and target the Visual that you want to parallax.</span></span> <span data-ttu-id="1a2ad-144">この場合、リストに表示される各項目用の画像がターゲットになります。</span><span class="sxs-lookup"><span data-stu-id="1a2ad-144">In this case, it is the image for each of the items in the list.</span></span>

```csharp
Visual visual = ElementCompositionPreview.GetElementVisual(image);
visual.StartAnimation("Offset.Y", _parallaxExpression);
```