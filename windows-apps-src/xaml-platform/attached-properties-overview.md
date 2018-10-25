---
author: jwmsft
description: XAML での添付プロパティの概念を説明し、例をいくつか紹介します。
title: 添付プロパティの概要
ms.assetid: 098C1DE0-D640-48B1-9961-D0ADF33266E2
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cpp
ms.openlocfilehash: 7f92b12ab9c8962fe98d8eed22b21e7d10330c99
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483398"
---
# <a name="attached-properties-overview"></a><span data-ttu-id="aaf08-104">添付プロパティの概要</span><span class="sxs-lookup"><span data-stu-id="aaf08-104">Attached properties overview</span></span>

<span data-ttu-id="aaf08-105">*添付プロパティ*は、XAML の概念です。</span><span class="sxs-lookup"><span data-stu-id="aaf08-105">An *attached property* is a XAML concept.</span></span> <span data-ttu-id="aaf08-106">添付プロパティは、追加のプロパティ/値ペアをオブジェクトに設定できますが、このプロパティは元のオブジェクト定義の一部ではありません。</span><span class="sxs-lookup"><span data-stu-id="aaf08-106">Attached properties enable additional property/value pairs to be set on an object, but the properties are not part of the original object definition.</span></span> <span data-ttu-id="aaf08-107">添付プロパティは、一般に、所有者型のオブジェクト モデルで従来のプロパティ ラッパーを持たない特殊な形式の依存関係プロパティとして定義されます。</span><span class="sxs-lookup"><span data-stu-id="aaf08-107">Attached properties are typically defined as a specialized form of dependency property that doesn't have a conventional property wrapper in the owner type's object model.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="aaf08-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="aaf08-108">Prerequisites</span></span>

<span data-ttu-id="aaf08-109">依存関係プロパティの基本的な概念を理解し、「[依存関係プロパティの概要](dependency-properties-overview.md)」を読んでいることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="aaf08-109">We assume that you understand the basic concept of dependency properties, and have read [Dependency properties overview](dependency-properties-overview.md).</span></span>

## <a name="attached-properties-in-xaml"></a><span data-ttu-id="aaf08-110">XAML での添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="aaf08-110">Attached properties in XAML</span></span>

<span data-ttu-id="aaf08-111">XAML では、_AttachedPropertyProvider.PropertyName_ 構文を使って添付プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-111">In XAML, you set attached properties by using the syntax _AttachedPropertyProvider.PropertyName_.</span></span> <span data-ttu-id="aaf08-112">XAML で [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) を設定する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-112">Here is an example of how you can set [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) in XAML.</span></span>

```xaml
<Canvas>
  <Button Canvas.Left="50">Hello</Button>
</Canvas>
```

> [!NOTE]
> <span data-ttu-id="aaf08-113">だけを使用します[**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771)例添付プロパティとして全部それを使用する理由。</span><span class="sxs-lookup"><span data-stu-id="aaf08-113">We're just using [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) as an example attached property without fully explaining why you'd use it.</span></span> <span data-ttu-id="aaf08-114">**Canvas.Left** の用途や、[**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) がそのレイアウトの子を処理する方法について詳しくは、[**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) のリファレンス トピックまたは「[XAML を使ったレイアウトの定義](https://msdn.microsoft.com/library/windows/apps/mt228350)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="aaf08-114">If you want to know more about what **Canvas.Left** is for and how [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) handles its layout children, see the [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) reference topic or [Define layouts with XAML](https://msdn.microsoft.com/library/windows/apps/mt228350).</span></span>

## <a name="why-use-attached-properties"></a><span data-ttu-id="aaf08-115">添付プロパティを使う理由</span><span class="sxs-lookup"><span data-stu-id="aaf08-115">Why use attached properties?</span></span>

<span data-ttu-id="aaf08-116">添付プロパティは、リレーションシップ内の別々のオブジェクトが実行時に情報をやり取りするのを防ぐようなコーディング規則を回避する方法の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="aaf08-116">Attached properties are a way to escape the coding conventions that might prevent different objects in a relationship from communicating information to each other at run time.</span></span> <span data-ttu-id="aaf08-117">共通の基底クラスにプロパティを設定し、各オブジェクトがそのプロパティを取得、設定できるようにすることも可能です。</span><span class="sxs-lookup"><span data-stu-id="aaf08-117">It's certainly possible to put properties on a common base class so that each object could just get and set that property.</span></span> <span data-ttu-id="aaf08-118">ただ、このようにする可能性のあるシナリオの数はきわめて多く、共有できるプロパティによって基底クラスが大きくなるおそれがあります。</span><span class="sxs-lookup"><span data-stu-id="aaf08-118">But eventually the sheer number of scenarios where you might want to do this will bloat your base classes with shareable properties.</span></span> <span data-ttu-id="aaf08-119">何百もの子孫のうちわずか 2 つしか使わないプロパティが存在するなどという事態が発生することも考えられます。</span><span class="sxs-lookup"><span data-stu-id="aaf08-119">It might even introduce cases where there might just be two of hundreds of descendants trying to use a property.</span></span> <span data-ttu-id="aaf08-120">これでは、優れたクラス設計にはなりません。</span><span class="sxs-lookup"><span data-stu-id="aaf08-120">That's not good class design.</span></span> <span data-ttu-id="aaf08-121">この問題に対処するため、添付プロパティの概念では、自らのクラス構造では定義されないプロパティに対してオブジェクトが値を割り当てられるようになっています。</span><span class="sxs-lookup"><span data-stu-id="aaf08-121">To address this, the attached property concept enables an object to assign a value for a property that its own class structure doesn't define.</span></span> <span data-ttu-id="aaf08-122">定義クラスでは、オブジェクト ツリーで各種オブジェクトが作成された後、実行時に子オブジェクトから値を読み取ります。</span><span class="sxs-lookup"><span data-stu-id="aaf08-122">The defining class can read the value from child objects at run time after the various objects are created in an object tree.</span></span>

<span data-ttu-id="aaf08-123">たとえば、子要素では添付プロパティを使用して、子要素がどのように UI に表示されるかを親要素に通知できます。</span><span class="sxs-lookup"><span data-stu-id="aaf08-123">For example, child elements can use attached properties to inform their parent element of how they are to be presented in the UI.</span></span> <span data-ttu-id="aaf08-124">[**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) 添付プロパティの場合がこれに該当します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-124">This is the case with the [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) attached property.</span></span> <span data-ttu-id="aaf08-125">**Canvas.Left** が添付プロパティとして作成されるのは、このプロパティが **Canvas** 自体ではなく [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) 要素に含まれる要素に対して設定されるためです。</span><span class="sxs-lookup"><span data-stu-id="aaf08-125">**Canvas.Left** is created as an attached property because it is set on elements that are contained within a [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) element, rather than on the **Canvas** itself.</span></span> <span data-ttu-id="aaf08-126">子要素は、**Canvas.Left** と [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/hh759772) を使って、レイアウト オフセットを親である **Canvas** レイアウト コンテナー内で指定します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-126">Any possible child element then uses **Canvas.Left** and [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/hh759772) to specify its layout offset within the **Canvas** layout container parent.</span></span> <span data-ttu-id="aaf08-127">基本の要素オブジェクト モデルに多数のプロパティがあり、それぞれのプロパティが多数のレイアウト コンテナーの 1 つのみに適用される場合でも、添付プロパティを使えば、そのオブジェクト モデルを煩雑な状態にすることなくこれを実現できます。</span><span class="sxs-lookup"><span data-stu-id="aaf08-127">Attached properties make it possible for this to work without cluttering the base element's object model with lots of properties that each apply to only one of the many possible layout containers.</span></span> <span data-ttu-id="aaf08-128">代わりに、レイアウト コンテナーの多くは独自の添付プロパティ セットを実装します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-128">Instead, many of the layout containers implement their own attached property set.</span></span>

<span data-ttu-id="aaf08-129">添付プロパティを実装するには、[**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) クラスは、[**Canvas.LeftProperty**](https://msdn.microsoft.com/library/windows/apps/br209272) という名前の静的な [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) フィールドを定義します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-129">To implement the attached property, the [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) class defines a static [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) field named [**Canvas.LeftProperty**](https://msdn.microsoft.com/library/windows/apps/br209272).</span></span> <span data-ttu-id="aaf08-130">次に **Canvas** では、[**SetLeft**](https://msdn.microsoft.com/library/windows/apps/br209273) メソッドと [**GetLeft**](https://msdn.microsoft.com/library/windows/apps/br209269) メソッドを添付プロパティのパブリック アクセサーとして提供して、XAML の設定とランタイム値のアクセスの両方を可能にします。</span><span class="sxs-lookup"><span data-stu-id="aaf08-130">Then, **Canvas** provides the [**SetLeft**](https://msdn.microsoft.com/library/windows/apps/br209273) and [**GetLeft**](https://msdn.microsoft.com/library/windows/apps/br209269) methods as public accessors for the attached property, to enable both XAML setting and run-time value access.</span></span> <span data-ttu-id="aaf08-131">XAML と依存関係プロパティ システムに対しては、この API のセットは添付プロパティ用の特定の XAML 構文を使い、依存関係プロパティ ストアに値を格納するパターンを実現できます。</span><span class="sxs-lookup"><span data-stu-id="aaf08-131">For XAML and for the dependency property system, this set of APIs satisfies a pattern that enables a specific XAML syntax for attached properties, and stores the value in the dependency property store.</span></span>

## <a name="how-the-owning-type-uses-attached-properties"></a><span data-ttu-id="aaf08-132">所有する型による添付プロパティの使用方法</span><span class="sxs-lookup"><span data-stu-id="aaf08-132">How the owning type uses attached properties</span></span>

<span data-ttu-id="aaf08-133">添付プロパティは任意の XAML 要素 (または基になる [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356)) に設定できますが、プロパティを設定することによって具体的な結果が生成されたり、値がアクセスされたりするわけではありません。</span><span class="sxs-lookup"><span data-stu-id="aaf08-133">Although attached properties can be set on any XAML element (or any underlying [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356)), that doesn't automatically mean that setting the property produces a tangible result, or that the value is ever accessed.</span></span> <span data-ttu-id="aaf08-134">添付プロパティを定義する型は、一般に次のいずれかのシナリオに従います。</span><span class="sxs-lookup"><span data-stu-id="aaf08-134">The type that defines the attached property typically follows one of these scenarios:</span></span>

- <span data-ttu-id="aaf08-135">添付プロパティを定義する型が、他のオブジェクトのリレーションシップで親になっている。</span><span class="sxs-lookup"><span data-stu-id="aaf08-135">The type that defines the attached property is the parent in a relationship of other objects.</span></span> <span data-ttu-id="aaf08-136">子オブジェクトは、添付プロパティの値を設定します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-136">The child objects will set values for the attached property.</span></span> <span data-ttu-id="aaf08-137">添付プロパティの所有者型には、オブジェクトの有効期間内のある時点に子要素を反復処理し、値を取得し、その値を処理するという動作が元からいくつか備わっています (レイアウト操作 [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/br208742) など)。</span><span class="sxs-lookup"><span data-stu-id="aaf08-137">The attached property owner type has some innate behavior that iterates through its child elements, obtains the values, and acts on those values at some point in object lifetime (a layout action, [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/br208742), etc.)</span></span>
- <span data-ttu-id="aaf08-138">添付プロパティを定義する型は、さまざまな親要素とコンテンツ モデルの子要素として使われますが、この情報はレイアウト情報である必要はありません。</span><span class="sxs-lookup"><span data-stu-id="aaf08-138">The type that defines the attached property is used as the child element for a variety of possible parent elements and content models, but the info isn't necessarily layout info.</span></span>
- <span data-ttu-id="aaf08-139">添付プロパティは、別の UI 要素ではなくサービスに情報を報告します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-139">The attached property reports info to a service, not to another UI element.</span></span>

<span data-ttu-id="aaf08-140">これらのシナリオや所有する型について詳しくは、「[カスタム添付プロパティ](custom-attached-properties.md)」の「Canvas.Left の詳細」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="aaf08-140">For more info on these scenarios and owning types, see the "More about Canvas.Left" section of [Custom attached properties](custom-attached-properties.md).</span></span>

## <a name="attached-properties-in-code"></a><span data-ttu-id="aaf08-141">コードでの添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="aaf08-141">Attached properties in code</span></span>

<span data-ttu-id="aaf08-142">添付プロパティには、他の依存関係プロパティのような、取得および設定アクセスを容易にする標準的なプロパティ ラッパーがありません。</span><span class="sxs-lookup"><span data-stu-id="aaf08-142">Attached properties don't have the typical property wrappers for easy get and set access like other dependency properties do.</span></span> <span data-ttu-id="aaf08-143">これは、添付プロパティが設定されているインスタンスのコード中心のオブジェクト モデルに、その添付プロパティが組み込まれているとは限らないからです。</span><span class="sxs-lookup"><span data-stu-id="aaf08-143">This is because the attached property is not necessarily part of the code-centered object model for instances where the property is set.</span></span> <span data-ttu-id="aaf08-144">(他の型で設定できると同時に、所有する型では従来の方法で使われる添付プロパティを定義することもできますが、決して一般的ではありません。)</span><span class="sxs-lookup"><span data-stu-id="aaf08-144">(It is permissible, though uncommon, to define a property that is both an attached property that other types can set on themselves, and that also has a conventional property usage on the owning type.)</span></span>

<span data-ttu-id="aaf08-145">コードでは 2 つの方法で添付プロパティを設定できます。1 つはプロパティ システムの API を使う方法、もう 1 つは XAML パターン アクセサーを使う方法です。</span><span class="sxs-lookup"><span data-stu-id="aaf08-145">There are two ways to set an attached property in code: use the property-system APIs, or use the XAML pattern accessors.</span></span> <span data-ttu-id="aaf08-146">これらの方法は最終的な結果という点ではほぼ同じため、どちらを使うかは主にコーディング スタイルによって決まります。</span><span class="sxs-lookup"><span data-stu-id="aaf08-146">These techniques are pretty much equivalent in terms of their end result, so which one to use is mostly a matter of coding style.</span></span>

### <a name="using-the-property-system"></a><span data-ttu-id="aaf08-147">プロパティ システムを使う場合</span><span class="sxs-lookup"><span data-stu-id="aaf08-147">Using the property system</span></span>

<span data-ttu-id="aaf08-148">Windows ランタイムの添付プロパティは依存関係プロパティとして実装されるため、プロパティ システムを使って共有依存関係プロパティ ストアに値を格納できます。</span><span class="sxs-lookup"><span data-stu-id="aaf08-148">Attached properties for the Windows Runtime are implemented as dependency properties, so that the values can be stored in the shared dependency-property store by the property system.</span></span> <span data-ttu-id="aaf08-149">したがって、添付プロパティは所有するクラスで依存関係プロパティ ID を公開します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-149">Therefore attached properties expose a dependency property identifier on the owning class.</span></span>

<span data-ttu-id="aaf08-150">コードで添付プロパティを設定するには、[**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) メソッドを呼び出し、その添付プロパティの ID となる [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) フィールドを渡します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-150">To set an attached property in code, you call the [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) method, and pass the [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) field that serves as the identifier for that attached property.</span></span> <span data-ttu-id="aaf08-151">(設定する値も渡します)。</span><span class="sxs-lookup"><span data-stu-id="aaf08-151">(You also pass the value to set.)</span></span>

<span data-ttu-id="aaf08-152">コードで添付プロパティの値を取得するには、[**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) メソッドを呼び出し、同じく ID となる [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) フィールドを渡します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-152">To get the value of an attached property in code, you call the [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) method, again passing the [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) field that serves as the identifier.</span></span>

### <a name="using-the-xaml-accessor-pattern"></a><span data-ttu-id="aaf08-153">XAML アクセサー パターンを使う場合</span><span class="sxs-lookup"><span data-stu-id="aaf08-153">Using the XAML accessor pattern</span></span>

<span data-ttu-id="aaf08-154">XAML をオブジェクト ツリーに解析するときは、XAML プロセッサが添付プロパティの値を設定できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="aaf08-154">A XAML processor must be able to set attached property values when XAML is parsed into an object tree.</span></span> <span data-ttu-id="aaf08-155">添付プロパティの所有者型は、形式で名前を付けた専用のアクセサー メソッドを実装する必要があります \**を取得する。 PropertyName*と \**設定。 PropertyName*します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-155">The owner type of the attached property must implement dedicated accessor methods named in the form \**Get\*\*\*PropertyName* and \**Set\*\*\*PropertyName*.</span></span> <span data-ttu-id="aaf08-156">この専用のアクセサー メソッドは、コードで添付プロパティを取得または設定する方法の 1 つでもあります。</span><span class="sxs-lookup"><span data-stu-id="aaf08-156">These dedicated accessor methods are also one way to get or set the attached property in code.</span></span> <span data-ttu-id="aaf08-157">コードの観点からすると、添付プロパティは、プロパティ アクセサーではなくメソッド アクセサーを持つバッキング フィールドに似ています。このバッキング フィールドは、どのオブジェクトにも存在する可能性があり、具体的に定義する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="aaf08-157">From a code perspective, an attached property is similar to a backing field that has method accessors instead of property accessors, and that backing field can exist on any object rather than having to be specifically defined.</span></span>

<span data-ttu-id="aaf08-158">次の例は、コードで XAML アクセサー API を使って添付プロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="aaf08-158">The next example shows how you can set an attached property in code via the XAML accessor API.</span></span> <span data-ttu-id="aaf08-159">この例の `myCheckBox` は、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) クラスのインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="aaf08-159">In this example, `myCheckBox` is an instance of the [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) class.</span></span> <span data-ttu-id="aaf08-160">実際に値を設定するコードは最後の行です。それまでの行では、インスタンスとその親子関係を設定しています。</span><span class="sxs-lookup"><span data-stu-id="aaf08-160">The last line is the code that actually sets the value; the lines before that just establish the instances and their parent-child relationship.</span></span> <span data-ttu-id="aaf08-161">コメント解除された最後の行は、プロパティ システムを使う場合の構文です。</span><span class="sxs-lookup"><span data-stu-id="aaf08-161">The uncommented last line is the syntax if you use the property system.</span></span> <span data-ttu-id="aaf08-162">コメント アウトされた最後の行は、XAML アクセサー パターンを使う場合の構文です。</span><span class="sxs-lookup"><span data-stu-id="aaf08-162">The commented last line is the syntax if you use the XAML accessor pattern.</span></span>

```csharp
    Canvas myC = new Canvas();
    CheckBox myCheckBox = new CheckBox();
    myCheckBox.Content = "Hello";
    myC.Children.Add(myCheckBox);
    myCheckBox.SetValue(Canvas.TopProperty,75);
    //Canvas.SetTop(myCheckBox, 75);
```

```vb
    Dim myC As Canvas = New Canvas()
    Dim myCheckBox As CheckBox= New CheckBox()
    myCheckBox.Content = "Hello"
    myC.Children.Add(myCheckBox)
    myCheckBox.SetValue(Canvas.TopProperty,75)
    ' Canvas.SetTop(myCheckBox, 75)
```

```cppwinrt
Canvas myC;
CheckBox myCheckBox;
myCheckBox.Content(winrt::box_value(L"Hello"));
myC.Children().Append(myCheckBox);
myCheckBox.SetValue(Canvas::TopProperty(), winrt::box_value(75));
// Canvas::SetTop(myCheckBox, 75);
```

```cpp
    Canvas^ myC = ref new Canvas();
    CheckBox^ myCheckBox = ref new CheckBox();
    myCheckBox->Content="Hello";
    myC->Children->Append(myCheckBox);
    myCheckBox->SetValue(Canvas::TopProperty,75);
    // Canvas::SetTop(myCheckBox, 75);
```

## <a name="custom-attached-properties"></a><span data-ttu-id="aaf08-163">カスタム添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="aaf08-163">Custom attached properties</span></span>

<span data-ttu-id="aaf08-164">カスタム添付プロパティの定義方法に関するコード例と添付プロパティを使うシナリオに関する詳しい情報については、「[カスタム添付プロパティ](custom-attached-properties.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="aaf08-164">For code examples of how to define custom attached properties, and more info about the scenarios for using an attached property, see [Custom attached properties](custom-attached-properties.md).</span></span>

## <a name="special-syntax-for-attached-property-references"></a><span data-ttu-id="aaf08-165">添付プロパティ参照の特別な構文</span><span class="sxs-lookup"><span data-stu-id="aaf08-165">Special syntax for attached property references</span></span>

<span data-ttu-id="aaf08-166">添付プロパティ名に含まれるドットは、識別パターンの重要な部分です。</span><span class="sxs-lookup"><span data-stu-id="aaf08-166">The dot in an attached property name is a key part of the identification pattern.</span></span> <span data-ttu-id="aaf08-167">ドットが別の意味に解釈される構文または状況では、あいまいさが生じる場合があります。</span><span class="sxs-lookup"><span data-stu-id="aaf08-167">Sometimes there are ambiguities when a syntax or situation treats the dot as having some other meaning.</span></span> <span data-ttu-id="aaf08-168">たとえば、バインディング パスではドットがオブジェクト モデル トラバーサルと見なされます。</span><span class="sxs-lookup"><span data-stu-id="aaf08-168">For example, a dot is treated as an object-model traversal for a binding path.</span></span> <span data-ttu-id="aaf08-169">あいまいさに関してほとんどの場合、添付プロパティ用の特別な構文によって、内部のドットは添付プロパティの _owner_**.**_property_ 区切り文字として解析されています。</span><span class="sxs-lookup"><span data-stu-id="aaf08-169">In most cases involving such ambiguity, there is a special syntax for an attached property that enables the inner dot still to be parsed as the _owner_**.**_property_ separator of an attached property.</span></span>

- <span data-ttu-id="aaf08-170">添付プロパティをアニメーション用ターゲット パスの一部として指定する場合は、添付プロパティ名をかっこ "()" で囲みます。たとえば、"(Canvas.Left)" のようにします。</span><span class="sxs-lookup"><span data-stu-id="aaf08-170">To specify an attached property as part of a target path for an animation, enclose the attached property name in parentheses ("()")—for example, "(Canvas.Left)".</span></span> <span data-ttu-id="aaf08-171">詳しくは、「[Property-path 構文](property-path-syntax.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="aaf08-171">For more info, see [Property-path syntax](property-path-syntax.md).</span></span>

> [!WARNING]
> <span data-ttu-id="aaf08-172">Windows ランタイム XAML 実装の既存の制限は、カスタム添付プロパティをアニメーション化することはできません。</span><span class="sxs-lookup"><span data-stu-id="aaf08-172">An existing limitation of the Windows Runtime XAML implementation is that you cannot animate a custom attached property.</span></span>

- <span data-ttu-id="aaf08-173">添付プロパティをリソース ファイルから **x:Uid** へのリソース参照のターゲット プロパティとして指定するには、コードスタイルの完全に修飾された **using:** 宣言を角かっこ ("\[\]") で囲む特別な構文を使って、故意にスコープ ブレークを作成します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-173">To specify an attached property as the target property for a resource reference from a resource file to **x:Uid**, use a special syntax that injects a code-style, fully qualified **using:** declaration inside square brackets ("\[\]"), to create a deliberate scope break.</span></span> <span data-ttu-id="aaf08-174">たとえば、要素が存在すると想定して`<TextBlock x:Uid="Title" />`、そのインスタンス**Canvas.Top**値をターゲットとするリソース ファイル内のリソース キーは"Title.\[using:Windows.UI.Xaml.Controls\]Canvas.Top"します。</span><span class="sxs-lookup"><span data-stu-id="aaf08-174">For example, assuming there exists an element `<TextBlock x:Uid="Title" />`, the resource key in the resource file that targets the **Canvas.Top** value on that instance is "Title.\[using:Windows.UI.Xaml.Controls\]Canvas.Top".</span></span> <span data-ttu-id="aaf08-175">リソース ファイルと XAML について詳しくは、「[クイック スタート: UI リソースの翻訳](https://msdn.microsoft.com/library/windows/apps/xaml/hh965329)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="aaf08-175">For more info on resource files and XAML, see [Quickstart: Translating UI resources](https://msdn.microsoft.com/library/windows/apps/xaml/hh965329).</span></span>

## <a name="related-topics"></a><span data-ttu-id="aaf08-176">関連トピック</span><span class="sxs-lookup"><span data-stu-id="aaf08-176">Related topics</span></span>

- [<span data-ttu-id="aaf08-177">カスタム添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="aaf08-177">Custom attached properties</span></span>](custom-attached-properties.md)
- [<span data-ttu-id="aaf08-178">依存関係プロパティの概要</span><span class="sxs-lookup"><span data-stu-id="aaf08-178">Dependency properties overview</span></span>](dependency-properties-overview.md)
- [<span data-ttu-id="aaf08-179">XAML を使ったレイアウトの定義</span><span class="sxs-lookup"><span data-stu-id="aaf08-179">Define layouts with XAML</span></span>](https://msdn.microsoft.com/library/windows/apps/mt228350)
- [<span data-ttu-id="aaf08-180">クイック スタート: UI リソースの翻訳</span><span class="sxs-lookup"><span data-stu-id="aaf08-180">Quickstart: Translating UI resources</span></span>](https://msdn.microsoft.com/library/windows/apps/hh943060)
- [**<span data-ttu-id="aaf08-181">SetValue</span><span class="sxs-lookup"><span data-stu-id="aaf08-181">SetValue</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242361)
- [**<span data-ttu-id="aaf08-182">GetValue</span><span class="sxs-lookup"><span data-stu-id="aaf08-182">GetValue</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242359)
