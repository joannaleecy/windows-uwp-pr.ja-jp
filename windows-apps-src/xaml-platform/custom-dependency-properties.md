---
description: C++、C#、または Visual Basic を使った Windows ランタイム アプリでカスタム依存関係プロパティを定義および実装する方法を説明します。
title: カスタム依存関係プロパティ
ms.assetid: 5ADF7935-F2CF-4BB6-B1A5-F535C2ED8EF8
ms.date: 07/12/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cppwinrt
- cpp
ms.openlocfilehash: 1231643e17ce30c68f71967f016f5bdeea546b2f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57619047"
---
# <a name="custom-dependency-properties"></a><span data-ttu-id="4c6fa-104">カスタム依存関係プロパティ</span><span class="sxs-lookup"><span data-stu-id="4c6fa-104">Custom dependency properties</span></span>

<span data-ttu-id="4c6fa-105">ここでは、C++、C#、または Visual Basic を使った Windows ランタイム アプリで固有の依存関係プロパティを定義および実装する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-105">Here we explain how to define and implement your own dependency properties for a Windows Runtime app using C++, C#, or Visual Basic.</span></span> <span data-ttu-id="4c6fa-106">アプリ開発者とコンポーネント作成者がカスタム依存関係プロパティを作成する理由の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-106">We list reasons why app developers and component authors might want to create custom dependency properties.</span></span> <span data-ttu-id="4c6fa-107">カスタム依存関係プロパティの実装手順と、依存関係プロパティのパフォーマンス、操作性、または汎用性を向上させることのできるいくつかのヒントについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-107">We describe the implementation steps for a custom dependency property, as well as some best practices that can improve performance, usability, or versatility of the dependency property.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="4c6fa-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="4c6fa-108">Prerequisites</span></span>

<span data-ttu-id="4c6fa-109">「[依存関係プロパティの概要](dependency-properties-overview.md)」を読み、依存関係プロパティを既にある依存関係プロパティのユーザーの観点から理解していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-109">We assume that you have read the [Dependency properties overview](dependency-properties-overview.md) and that you understand dependency properties from the perspective of a consumer of existing dependency properties.</span></span> <span data-ttu-id="4c6fa-110">このトピックの例を参考にするには、XAML について理解し、C++、C#、または Visual Basic を使った基本的な Windows ランタイム アプリを作る方法を理解している必要もあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-110">To follow the examples in this topic, you should also understand XAML and know how to write a basic Windows Runtime app using C++, C#, or Visual Basic.</span></span>

## <a name="what-is-a-dependency-property"></a><span data-ttu-id="4c6fa-111">依存関係プロパティとは</span><span class="sxs-lookup"><span data-stu-id="4c6fa-111">What is a dependency property?</span></span>

<span data-ttu-id="4c6fa-112">プロパティのスタイル設定、データ バインディング、アニメーション、既定値をサポートするには、依存関係プロパティとして実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-112">To support styling, data binding, animations, and default values for a property, then it should be implemented as a dependency property.</span></span> <span data-ttu-id="4c6fa-113">依存関係プロパティの値はフィールドとしてクラスに格納されるのではなく、xaml フレームワークによって格納され、キーを使って参照されます。キーは、[**DependencyProperty.Register**](https://msdn.microsoft.com/library/windows/apps/hh701829)メソッドを呼び出すことにより、プロパティが Windows ランタイム プロパティ システムに登録されるときに取得されます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-113">Dependency property values are not stored as fields on the class, they are stored by the xaml framework, and are referenced using a key, which is retrieved when the property is registered with the Windows Runtime property system by calling the [**DependencyProperty.Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) method.</span></span>   <span data-ttu-id="4c6fa-114">依存関係プロパティは、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生した型でのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-114">Dependency properties can be used only by types deriving from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356).</span></span> <span data-ttu-id="4c6fa-115">ただし、**DependencyObject** はクラス階層のかなり上位にあるため、UI とプレゼンテーションのサポートを目的とするクラスの大半は、依存関係プロパティをサポートできます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-115">But **DependencyObject** is quite high in the class hierarchy, so the majority of classes that are intended for UI and presentation support can support dependency properties.</span></span> <span data-ttu-id="4c6fa-116">依存関係プロパティと、このドキュメントでそれらを説明するために使っている用語と表記規則の一部については、「[依存関係プロパティの概要](dependency-properties-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-116">For more information about dependency properties and some of the terminology and conventions used for describing them in this documentation, see [Dependency properties overview](dependency-properties-overview.md).</span></span>

<span data-ttu-id="4c6fa-117">Windows ランタイムの依存関係プロパティの例は次のとおりです。[**されたルックアップ**](https://msdn.microsoft.com/library/windows/apps/br209395)、 [ **FrameworkElement.Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width)、および[ **TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/br209702)、多くの間でその他。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-117">Examples of dependency properties in the Windows Runtime are: [**Control.Background**](https://msdn.microsoft.com/library/windows/apps/br209395), [**FrameworkElement.Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width), and [**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/br209702), among many others.</span></span>

<span data-ttu-id="4c6fa-118">規則として、クラスで公開されている各依存関係プロパティには、依存関係プロパティの識別子を提供する同じクラスで公開される [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) 型の対応する **public static readonly** プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-118">Convention is that each dependency property exposed by a class has a corresponding **public static readonly** property of type [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) that is exposed on that same class the provides the identifier for the dependency property.</span></span> <span data-ttu-id="4c6fa-119">識別子の名前は、依存関係プロパティの名前の終わりに "Property" という文字列を追加した名前です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-119">The identifier's name follows this convention: the name of the dependency property, with the string "Property" added to the end of the name.</span></span> <span data-ttu-id="4c6fa-120">たとえば、**Control.Background** プロパティに対応する **DependencyProperty** 識別子は [**Control.BackgroundProperty**](https://msdn.microsoft.com/library/windows/apps/br209396) です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-120">For example, the corresponding **DependencyProperty** identifier for the **Control.Background** property is [**Control.BackgroundProperty**](https://msdn.microsoft.com/library/windows/apps/br209396).</span></span> <span data-ttu-id="4c6fa-121">識別子を登録したときに依存関係プロパティに関する情報が格納され、[**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) の呼び出しなど、依存関係プロパティに関係する他の操作でその識別子を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-121">The identifier stores the information about the dependency property as it was registered, and can then be used for other operations involving the dependency property, such as calling [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361).</span></span>

## <a name="property-wrappers"></a><span data-ttu-id="4c6fa-122">プロパティ ラッパー</span><span class="sxs-lookup"><span data-stu-id="4c6fa-122">Property wrappers</span></span>

<span data-ttu-id="4c6fa-123">通常、依存関係プロパティにはラッパー実装があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-123">Dependency properties typically have a wrapper implementation.</span></span> <span data-ttu-id="4c6fa-124">ラッパーがない場合は、依存関係プロパティのユーティリティ メソッド [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) および [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) を使って識別子をパラメーターとして渡す方法でのみプロパティを取得または設定できます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-124">Without the wrapper, the only way to get or set the properties would be to use the dependency property utility methods [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) and [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) and to pass the identifier to them as a parameter.</span></span> <span data-ttu-id="4c6fa-125">これは、明らかにプロパティであるものについては不自然な使用方法です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-125">This is a rather unnatural usage for something that is ostensibly a property.</span></span> <span data-ttu-id="4c6fa-126">しかし、ラッパーがあれば、お使いのコード、および依存関係プロパティを参照する他のコードで、使っている言語にとって自然な単純なオブジェクト プロパティ構文を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-126">But with the wrapper, your code and any other code that references the dependency property can use a straightforward object-property syntax that is natural for the language you're using.</span></span>

<span data-ttu-id="4c6fa-127">カスタム依存関係プロパティを自分で実装し、パブリックにして簡単に呼び出すには、プロパティ ラッパーも定義します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-127">If you implement a custom dependency property yourself and want it to be public and easy to call, define the property wrappers too.</span></span> <span data-ttu-id="4c6fa-128">プロパティ ラッパーは、依存関係プロパティに関する基本情報をリフレクション プロセスまたは静的分析プロセスにレポートする場合にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-128">The property wrappers are also useful for reporting basic information about the dependency property to reflection or static analysis processes.</span></span> <span data-ttu-id="4c6fa-129">具体的には、ラッパーは [**ContentPropertyAttribute**](https://msdn.microsoft.com/library/windows/apps/br228011) などの属性を配置する場所です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-129">Specifically, the wrapper is where you place attributes such as [**ContentPropertyAttribute**](https://msdn.microsoft.com/library/windows/apps/br228011).</span></span>

## <a name="when-to-implement-a-property-as-a-dependency-property"></a><span data-ttu-id="4c6fa-130">プロパティを依存関係プロパティとして実装する状況</span><span class="sxs-lookup"><span data-stu-id="4c6fa-130">When to implement a property as a dependency property</span></span>

<span data-ttu-id="4c6fa-131">クラスにパブリック読み取り/書き込みプロパティを実装する場合、クラスが [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生する限り、プロパティを依存関係プロパティとして機能させるオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-131">Whenever you implement a public read/write property on a class, as long as your class derives from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356), you have the option to make your property work as a dependency property.</span></span> <span data-ttu-id="4c6fa-132">場合によっては、プライベート フィールドでプロパティをバッキングする標準的な手法で十分です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-132">Sometimes the typical technique of backing your property with a private field is adequate.</span></span> <span data-ttu-id="4c6fa-133">カスタム プロパティを依存関係プロパティとして定義することは、必ずしも必須または適切ではありません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-133">Defining your custom property as a dependency property is not always necessary or appropriate.</span></span> <span data-ttu-id="4c6fa-134">どれを選ぶかは、プロパティでサポートするシナリオによって決まります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-134">The choice will depend on the scenarios that you intend your property to support.</span></span>

<span data-ttu-id="4c6fa-135">Windows ランタイムまたは Windows ランタイム アプリの次の機能の 1 つ以上をサポートする場合は、プロパティを依存関係プロパティとして実装することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-135">You might consider implementing your property as a dependency property when you want it to support one or more of these features of the Windows Runtime or of Windows Runtime apps:</span></span>

- <span data-ttu-id="4c6fa-136">[  **Style**](https://msdn.microsoft.com/library/windows/apps/br208849) によるプロパティの設定</span><span class="sxs-lookup"><span data-stu-id="4c6fa-136">Setting the property through a [**Style**](https://msdn.microsoft.com/library/windows/apps/br208849)</span></span>
- <span data-ttu-id="4c6fa-137">[  **{Binding}**](binding-markup-extension.md) によるデータ バインディングの有効なターゲット プロパティとしての機能</span><span class="sxs-lookup"><span data-stu-id="4c6fa-137">Acting as valid target property for data binding with [**{Binding}**](binding-markup-extension.md)</span></span>
- <span data-ttu-id="4c6fa-138">[  **Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) によるアニメーション化された値のサポート</span><span class="sxs-lookup"><span data-stu-id="4c6fa-138">Supporting animated values through a [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490)</span></span>
- <span data-ttu-id="4c6fa-139">プロパティの値が次のものによって変更された場合のレポート:</span><span class="sxs-lookup"><span data-stu-id="4c6fa-139">Reporting when the value of the property has been changed by:</span></span>
  - <span data-ttu-id="4c6fa-140">プロパティ システム自体によって実行されたアクション</span><span class="sxs-lookup"><span data-stu-id="4c6fa-140">Actions taken by the property system itself</span></span>
  - <span data-ttu-id="4c6fa-141">環境</span><span class="sxs-lookup"><span data-stu-id="4c6fa-141">The environment</span></span>
  - <span data-ttu-id="4c6fa-142">ユーザーの操作</span><span class="sxs-lookup"><span data-stu-id="4c6fa-142">User actions</span></span>
  - <span data-ttu-id="4c6fa-143">スタイルの読み取りと書き込み</span><span class="sxs-lookup"><span data-stu-id="4c6fa-143">Reading and writing styles</span></span>

## <a name="checklist-for-defining-a-dependency-property"></a><span data-ttu-id="4c6fa-144">依存関係プロパティの定義のチェック リスト</span><span class="sxs-lookup"><span data-stu-id="4c6fa-144">Checklist for defining a dependency property</span></span>

<span data-ttu-id="4c6fa-145">依存関係プロパティの定義は、一連の概念と考えることができます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-145">Defining a dependency property can be thought of as a set of concepts.</span></span> <span data-ttu-id="4c6fa-146">いくつかの概念は実装の単一コード行で処理できるため、これらの概念は必ずしも手順ではありません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-146">These concepts are not necessarily procedural steps, because several concepts can be addressed in a single line of code in the implementation.</span></span> <span data-ttu-id="4c6fa-147">このリストでは、概要のみ示します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-147">This list gives just a quick overview.</span></span> <span data-ttu-id="4c6fa-148">各概念については後でこのトピックで詳しく説明し、複数の言語でのコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-148">We'll explain each concept in more detail later in this topic, and we'll show you example code in several languages.</span></span>

- <span data-ttu-id="4c6fa-149">プロパティ名をプロパティ システムに登録して ([**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) を呼び出す)、所有者型とプロパティ値の型を指定します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-149">Register the property name with the property system (call [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829)), specifying an owner type and the type of the property value.</span></span>
  - <span data-ttu-id="4c6fa-150">[  **Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) にはプロパティ メタデータを要求する必須パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-150">There's a required parameter for [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) that expects property metadata.</span></span> <span data-ttu-id="4c6fa-151">これに **null** を指定するか、プロパティ変更動作や、[**ClearValue**](https://msdn.microsoft.com/library/windows/apps/br242357) を呼び出すことによって復元できるメタデータ ベースの既定値が必要な場合は、[**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.propertymetadata) のインスタンスを指定します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-151">Specify **null** for this, or if you want property-changed behavior, or a metadata-based default value that can be restored by calling [**ClearValue**](https://msdn.microsoft.com/library/windows/apps/br242357), specify an instance of [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.propertymetadata).</span></span>
- <span data-ttu-id="4c6fa-152">[  **DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) 識別子を所有者型の **public static readonly** プロパティ メンバーとして定義します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-152">Define a [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) identifier as a **public static readonly** property member on the owner type.</span></span>
- <span data-ttu-id="4c6fa-153">実装する言語で使うプロパティ アクセサー モデルに従ってラッパー プロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-153">Define a wrapper property, following the property accessor model that's used in the language you are implementing.</span></span> <span data-ttu-id="4c6fa-154">ラッパー プロパティ名は、[**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) で使った *name* 文字列と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-154">The wrapper property name should match the *name* string that you used in [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829).</span></span> <span data-ttu-id="4c6fa-155">[  **GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) と [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) を呼び出し、独自のプロパティの識別子をパラメーターとして渡すことで、**get** アクセサーと **set** アクセサーを実装して、ラップする依存関係プロパティにラッパーを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-155">Implement the **get** and **set** accessors to connect the wrapper with the dependency property that it wraps, by calling [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) and [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) and passing your own property's identifier as a parameter.</span></span>
- <span data-ttu-id="4c6fa-156">(省略可能) ラッパーに [**ContentPropertyAttribute**](https://msdn.microsoft.com/library/windows/apps/br228011) などの属性を配置します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-156">(Optional) Place attributes such as [**ContentPropertyAttribute**](https://msdn.microsoft.com/library/windows/apps/br228011) on the wrapper.</span></span>

> [!NOTE]
> <span data-ttu-id="4c6fa-157">カスタム添付プロパティを定義する場合は、ラッパー通常省略します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-157">If you are defining a custom attached property, you generally omit the wrapper.</span></span> <span data-ttu-id="4c6fa-158">代わりに、XAML プロセッサで使うことのできる別のスタイルのアクセサーを作ります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-158">Instead, you write a different style of accessor that a XAML processor can use.</span></span> <span data-ttu-id="4c6fa-159">詳しくは、「[カスタム添付プロパティ](custom-attached-properties.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-159">See [Custom attached properties](custom-attached-properties.md).</span></span> 

## <a name="registering-the-property"></a><span data-ttu-id="4c6fa-160">プロパティの登録</span><span class="sxs-lookup"><span data-stu-id="4c6fa-160">Registering the property</span></span>

<span data-ttu-id="4c6fa-161">プロパティを依存関係プロパティにするには、Windows ランタイム プロパティ システムでメンテナンスされるプロパティ ストアにプロパティを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-161">For your property to be a dependency property, you must register the property into a property store maintained by the Windows Runtime property system.</span></span>  <span data-ttu-id="4c6fa-162">プロパティを登録するには、[**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-162">To register the property, you call the [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) method.</span></span>

<span data-ttu-id="4c6fa-163">Microsoft .NET 言語 (C# と Microsoft Visual Basic) では、クラスの本文 (クラス内だがメンバー定義の外部) で [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-163">For Microsoft .NET languages (C# and Microsoft Visual Basic) you call [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) within the body of your class (inside the class, but outside any member definitions).</span></span> <span data-ttu-id="4c6fa-164">識別子は、[**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) メソッド呼び出しで戻り値として提供されます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-164">The identifier is provided by the [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) method call, as the return value.</span></span> <span data-ttu-id="4c6fa-165">[  **Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) 呼び出しは通常、静的コンストラクターとして、またはクラスの一部である型 [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) の **public static readonly** プロパティ初期化の一部として行われます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-165">The [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) call is typically made as a static constructor or as part of the initialization of a **public static readonly** property of type [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) as part of your class.</span></span> <span data-ttu-id="4c6fa-166">このプロパティは、依存関係プロパティの識別子を公開します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-166">This property exposes the identifier for your dependency property.</span></span> <span data-ttu-id="4c6fa-167">[  **Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) 呼び出しの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-167">Here are examples of the [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) call.</span></span>

> [!NOTE]
> <span data-ttu-id="4c6fa-168">依存関係プロパティの登録が、プロパティの定義に通常の実装が、識別子の一部として、クラスの静的コンストラクターで依存関係プロパティを登録することもできます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-168">Registering the dependency property as part of the identifier property definition is the typical implementation, but you can also register a dependency property in the class static constructor.</span></span> <span data-ttu-id="4c6fa-169">このアプローチは、依存関係プロパティの初期化に複数のコード行が必要な場合に意味を持つことがあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-169">This approach may make sense if you need more than one line of code to initialize the dependency property.</span></span>

<span data-ttu-id="4c6fa-170">C++/cli CX、ヘッダーと、コード ファイルの間の実装を分割する方法のオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-170">For C++/CX, you have options for how you split the implementation between the header and the code file.</span></span> <span data-ttu-id="4c6fa-171">一般的な分割では、**set** ではなく **get** 実装で、識別子自体をヘッダーで **public static** プロパティとして宣言します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-171">The typical split is to declare the identifier itself as **public static** property in the header, with a **get** implementation but no **set**.</span></span> <span data-ttu-id="4c6fa-172">**get** 実装は、初期化されていない [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) インスタンスであるプライベート フィールドを参照します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-172">The **get** implementation refers to a private field, which is an uninitialized [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) instance.</span></span> <span data-ttu-id="4c6fa-173">ラッパー、およびラッパーの **get** 実装と **set** 実装を宣言することもできます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-173">You can also declare the wrappers and the **get** and **set** implementations of the wrapper.</span></span> <span data-ttu-id="4c6fa-174">この場合、ヘッダーにはいくつかの最小限の実装が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-174">In this case the header includes some minimal implementation.</span></span> <span data-ttu-id="4c6fa-175">ラッパーに Windows ランタイム属性が必要な場合は、ヘッダーにも属性が必要です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-175">If the wrapper needs Windows Runtime attribution, attribute in the header too.</span></span> <span data-ttu-id="4c6fa-176">コード ファイルの最初にアプリが初期化するときにのみ実行されるヘルパー関数内に [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) の呼び出しを配置します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-176">Put the [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) call in the code file, within a helper function that only gets run when the app initializes the first time.</span></span> <span data-ttu-id="4c6fa-177">**Register** の戻り値を使って、ヘッダーで宣言した初期化されていない静的識別子を入力します。これは実装ファイルのルート スコープで当初は **nullptr** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-177">Use the return value of **Register** to fill the static but uninitialized identifiers that you declared in the header, which you initially set to **nullptr** at the root scope of the implementation file.</span></span>

```csharp
public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
  "Label",
  typeof(String),
  typeof(ImageWithLabelControl),
  new PropertyMetadata(null)
);
```

```vb
Public Shared ReadOnly LabelProperty As DependencyProperty = 
    DependencyProperty.Register("Label", 
      GetType(String), 
      GetType(ImageWithLabelControl), 
      New PropertyMetadata(Nothing))
```

```cppwinrt
// ImageWithLabelControl.idl
namespace ImageWithLabelControlApp
{
    runtimeclass ImageWithLabelControl : Windows.UI.Xaml.Controls.Control
    {
        ImageWithLabelControl();
        static Windows.UI.Xaml.DependencyProperty LabelProperty{ get; };
        String Label;
    }
}

// ImageWithLabelControl.h
...
private:
    static Windows::UI::Xaml::DependencyProperty m_labelProperty;
...

// ImageWithLabelControl.cpp
...
Windows::UI::Xaml::DependencyProperty ImageWithLabelControl::m_labelProperty =
    Windows::UI::Xaml::DependencyProperty::Register(
        L"Label",
        winrt::xaml_typename<winrt::hstring>(),
        winrt::xaml_typename<ImageWithLabelControlApp::ImageWithLabelControl>(),
        Windows::UI::Xaml::PropertyMetadata{ nullptr }
);
...
```

```cpp
//.h file
//using namespace Windows::UI::Xaml::Controls;
//using namespace Windows::UI::Xaml::Interop;
//using namespace Windows::UI::Xaml;
//using namespace Platform;

public ref class ImageWithLabelControl sealed : public Control
{
private:
    static DependencyProperty^ _LabelProperty;
...
public:
    static void RegisterDependencyProperties();
    static property DependencyProperty^ LabelProperty
    {
        DependencyProperty^ get() {return _LabelProperty;}
    }
...
};

//.cpp file
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml.Interop;

DependencyProperty^ ImageWithLabelControl::_LabelProperty = nullptr;

// This function is called from the App constructor in App.xaml.cpp
// to register the properties
void ImageWithLabelControl::RegisterDependencyProperties()
{ 
    if (_LabelProperty == nullptr)
    { 
        _LabelProperty = DependencyProperty::Register(
          "Label", Platform::String::typeid, ImageWithLabelControl::typeid, nullptr);
    } 
}
```

> [!NOTE]
> <span data-ttu-id="4c6fa-178">C++/cli CX のコードは、理由があるプライベート フィールドとパブリックの読み取り専用プロパティ表示する理由、 [ **DependencyProperty** ](https://msdn.microsoft.com/library/windows/apps/br242362)依存関係プロパティを使用している他の呼び出し元も使用できるようにするにはプロパティ システム ユーティリティ Api を公開する識別子が必要です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-178">For the C++/CX code, the reason why you have a private field and a public read-only property that surfaces the [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) is so that other callers who use your dependency property can also use property-system utility APIs that require the identifier to be public.</span></span> <span data-ttu-id="4c6fa-179">識別子をプライベートのままにした場合、他のユーザーはこれらのユーティリティ API を使うことができません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-179">If you keep the identifier private, people can't use these utility APIs.</span></span> <span data-ttu-id="4c6fa-180">このような API とシナリオの例には、[**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359)、任意の [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361)、[**ClearValue**](https://msdn.microsoft.com/library/windows/apps/br242357)、[**GetAnimationBaseValue**](https://msdn.microsoft.com/library/windows/apps/br242358)、[**SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257)、および [**Setter.Property**](https://msdn.microsoft.com/library/windows/apps/br208836) があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-180">Examples of such API and scenarios include [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) or [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) by choice, [**ClearValue**](https://msdn.microsoft.com/library/windows/apps/br242357), [**GetAnimationBaseValue**](https://msdn.microsoft.com/library/windows/apps/br242358), [**SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257), and [**Setter.Property**](https://msdn.microsoft.com/library/windows/apps/br208836).</span></span> <span data-ttu-id="4c6fa-181">Windows ランタイム メタデータの規則ではパブリック フィールドが許可されないため、これにパブリック フィールドを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-181">You can't use a public field for this, because Windows Runtime metadata rules don't allow for public fields.</span></span>

## <a name="dependency-property-name-conventions"></a><span data-ttu-id="4c6fa-182">依存関係プロパティの命名規則</span><span class="sxs-lookup"><span data-stu-id="4c6fa-182">Dependency property name conventions</span></span>

<span data-ttu-id="4c6fa-183">依存関係プロパティには命名規則があります。例外的な状況を除き、これに従ってください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-183">There are naming conventions for dependency properties; follow them in all but exceptional circumstances.</span></span> <span data-ttu-id="4c6fa-184">依存関係プロパティ自体には、[**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) の最初のパラメーターとして与えられる基本的な名前 (前の例では "Label") があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-184">The dependency property itself has a basic name ("Label" in the preceding example) that is given as the first parameter of [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829).</span></span> <span data-ttu-id="4c6fa-185">名前は登録の種類ごとに一意である必要があり、一意性の要件は継承されるメンバーにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-185">The name must be unique within each registering type, and the uniqueness requirement also applies to any inherited members.</span></span> <span data-ttu-id="4c6fa-186">基本型を通じて継承された依存関係プロパティは、既に登録型の一部と見なされます。継承されたプロパティの名前を再び登録することはできません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-186">Dependency properties inherited through base types are considered to be part of the registering type already; names of inherited properties cannot be registered again.</span></span>

> [!WARNING]
> <span data-ttu-id="4c6fa-187">ここで、任意の文字列識別子を指定することができます、指定した名前が選択した言語のプログラミングでは有効な XAML でも、依存関係プロパティを設定することをする通常。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-187">Although the name you provide here can be any string identifier that is valid in programming for your language of choice, you usually want to be able to set your dependency property in XAML too.</span></span> <span data-ttu-id="4c6fa-188">XAML で設定するには、選ぶプロパティが有効な XAML 名である必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-188">To be set in XAML, the property name you choose must be a valid XAML name.</span></span> <span data-ttu-id="4c6fa-189">詳しくは、「[XAML の概要](xaml-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-189">For more info, see [XAML overview](xaml-overview.md).</span></span>

<span data-ttu-id="4c6fa-190">識別子プロパティを作る場合は、登録したプロパティの名前にサフィックス "Property" を結合します ("LabelProperty" など)。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-190">When you create the identifier property, combine the name of the property as you registered it with the suffix "Property" ("LabelProperty", for example).</span></span> <span data-ttu-id="4c6fa-191">このプロパティは依存関係プロパティの識別子であり、独自のプロパティ ラッパーで呼び出す [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) と [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) の入力として使われます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-191">This property is your identifier for the dependency property, and it is used as an input for the [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) and [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) calls you make in your own property wrappers.</span></span> <span data-ttu-id="4c6fa-192">プロパティ システムや、[**{x:bind}:**](x-bind-markup-extension.md) などの他の XAML プロセッサによっても使われます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-192">It is also used by the property system and other XAML processors such as [**{x:Bind}**](x-bind-markup-extension.md)</span></span>

## <a name="implementing-the-wrapper"></a><span data-ttu-id="4c6fa-193">ラッパーの実装</span><span class="sxs-lookup"><span data-stu-id="4c6fa-193">Implementing the wrapper</span></span>

<span data-ttu-id="4c6fa-194">プロパティ ラッパーでは、**get** 実装の [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) と **set** 実装の [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-194">Your property wrapper should call [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) in the **get** implementation, and [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) in the **set** implementation.</span></span>

> [!WARNING]
> <span data-ttu-id="4c6fa-195">例外的な状況で、ラッパーの実装をのみ実行する必要があります、 [ **GetValue** ](https://msdn.microsoft.com/library/windows/apps/br242359)と[ **SetValue** ](https://msdn.microsoft.com/library/windows/apps/br242361)操作です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-195">In all but exceptional circumstances, your wrapper implementations should perform only the [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) and [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) operations.</span></span> <span data-ttu-id="4c6fa-196">そうしないと、プロパティは XAML で設定された場合とコードで設定された場合とで動作が異なります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-196">Otherwise, you'll get different behavior when your property is set via XAML versus when it is set via code.</span></span> <span data-ttu-id="4c6fa-197">効率を高めるため、依存関係プロパティを設定するときに XAML パーサーはラッパーをバイパスし、**SetValue** 経由でバッキング ストアとやり取りします。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-197">For efficiency, the XAML parser bypasses wrappers when setting dependency properties; and talks to the backing store via **SetValue**.</span></span>

```csharp
public String Label
{
    get { return (String)GetValue(LabelProperty); }
    set { SetValue(LabelProperty, value); }
}
```

```vb
Public Property Label() As String
    Get
        Return DirectCast(GetValue(LabelProperty), String) 
    End Get 
    Set(ByVal value As String)
        SetValue(LabelProperty, value)
    End Set
End Property
```

```cppwinrt
// ImageWithLabelControl.h
...
winrt::hstring Label()
{
    return winrt::unbox_value<winrt::hstring>(GetValue(m_labelProperty));
}

void Label(winrt::hstring const& value)
{
    SetValue(m_labelProperty, winrt::box_value(value));
}
...
```

```cpp
//using namespace Platform;
public:
...
  property String^ Label
  {
    String^ get() {
      return (String^)GetValue(LabelProperty);
    }
    void set(String^ value) {
      SetValue(LabelProperty, value);
    }
  }
```

## <a name="property-metadata-for-a-custom-dependency-property"></a><span data-ttu-id="4c6fa-198">カスタム依存関係プロパティのプロパティ メタデータ</span><span class="sxs-lookup"><span data-stu-id="4c6fa-198">Property metadata for a custom dependency property</span></span>

<span data-ttu-id="4c6fa-199">プロパティ メタデータが依存関係プロパティに割り当てられている場合、同じメタデータが、プロパティ所有者型のすべてのインスタンスまたはそのサブクラスのそのプロパティに適用されます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-199">When property metadata is assigned to a dependency property, the same metadata is applied to that property for every instance of the property-owner type or its subclasses.</span></span> <span data-ttu-id="4c6fa-200">プロパティ メタデータでは、次の 2 つの動作を指定できます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-200">In property metadata, you can specify two behaviors:</span></span>

- <span data-ttu-id="4c6fa-201">プロパティ システムがプロパティのすべてのケースに割り当てる既定値。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-201">A default value that the property system assigns to all cases of the property.</span></span>
- <span data-ttu-id="4c6fa-202">プロパティ値の変更が検出されるたびにプロパティ システム内で自動的に呼び出される静的コールバック メソッド。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-202">A static callback method that is automatically invoked within the property system whenever a property value change is detected.</span></span>

### <a name="calling-register-with-property-metadata"></a><span data-ttu-id="4c6fa-203">プロパティ メタデータでの登録の呼び出し</span><span class="sxs-lookup"><span data-stu-id="4c6fa-203">Calling Register with property metadata</span></span>

<span data-ttu-id="4c6fa-204">前に示した [**DependencyProperty.Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) を呼び出す例では、*propertyMetadata* パラメーターに null 値を渡しました。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-204">In the previous examples of calling [**DependencyProperty.Register**](https://msdn.microsoft.com/library/windows/apps/hh701829), we passed a null value for the *propertyMetadata* parameter.</span></span> <span data-ttu-id="4c6fa-205">依存関係プロパティを有効にして、既定値を提供するかプロパティ変更コールバックを使うには、これらの機能のいずれかまたは両方を提供する、[**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) インスタンスを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-205">To enable a dependency property to provide a default value or use a property-changed callback, you must define a [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) instance that provides one or both of these capabilities.</span></span>

<span data-ttu-id="4c6fa-206">通常、[**DependencyProperty.Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) のパラメーター内で、インラインで作られたインスタンスとして [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) を提供します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-206">Typically you provide a [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) as an inline-created instance, within the parameters for [**DependencyProperty.Register**](https://msdn.microsoft.com/library/windows/apps/hh701829).</span></span>

> [!NOTE]
> <span data-ttu-id="4c6fa-207">定義する場合、 [ **CreateDefaultValueCallback** ](https://msdn.microsoft.com/library/windows/apps/hh701812)実装、ユーティリティ メソッドを使用する必要があります[ **PropertyMetadata.Create** ](https://msdn.microsoft.com/library/windows/apps/hh702099)呼び出すのではなく、 [ **PropertyMetadata** ](https://msdn.microsoft.com/library/windows/apps/br208771)コンストラクターを定義する、 **PropertyMetadata**インスタンス。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-207">If you are defining a [**CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812) implementation, you must use the utility method [**PropertyMetadata.Create**](https://msdn.microsoft.com/library/windows/apps/hh702099) rather than calling a [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) constructor to define the **PropertyMetadata** instance.</span></span>

<span data-ttu-id="4c6fa-208">次の例では、前に示した [**DependencyProperty.Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) の例を、[**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) インスタンスを [**PropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/br208770) 値を使って参照することで変更します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-208">This next example modifies the previously shown [**DependencyProperty.Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) examples by referencing a [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) instance with a [**PropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/br208770) value.</span></span> <span data-ttu-id="4c6fa-209">"OnLabelChanged" コールバックの実装については、このセクションの後半で説明します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-209">The implementation of the "OnLabelChanged" callback will be shown later in this section.</span></span>

```csharp
public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
  "Label",
  typeof(String),
  typeof(ImageWithLabelControl),
  new PropertyMetadata(null,new PropertyChangedCallback(OnLabelChanged))
);
```

```vb
Public Shared ReadOnly LabelProperty As DependencyProperty =
    DependencyProperty.Register("Label",
      GetType(String),
      GetType(ImageWithLabelControl),
      New PropertyMetadata(
        Nothing, new PropertyChangedCallback(AddressOf OnLabelChanged)))
```

```cppwinrt
// ImageWithLabelControl.cpp
...
Windows::UI::Xaml::DependencyProperty ImageWithLabelControl::m_labelProperty =
    Windows::UI::Xaml::DependencyProperty::Register(
        L"Label",
        winrt::xaml_typename<winrt::hstring>(),
        winrt::xaml_typename<ImageWithLabelControlApp::ImageWithLabelControl>(),
        Windows::UI::Xaml::PropertyMetadata{ nullptr, Windows::UI::Xaml::PropertyChangedCallback{ &ImageWithLabelControl::OnLabelChanged } }
);
...
```

```cpp
DependencyProperty^ ImageWithLabelControl::_LabelProperty =
    DependencyProperty::Register("Label",
    Platform::String::typeid,
    ImageWithLabelControl::typeid,
    ref new PropertyMetadata(nullptr,
      ref new PropertyChangedCallback(&ImageWithLabelControl::OnLabelChanged))
    );
```

### <a name="default-value"></a><span data-ttu-id="4c6fa-210">既定値</span><span class="sxs-lookup"><span data-stu-id="4c6fa-210">Default value</span></span>

<span data-ttu-id="4c6fa-211">プロパティが設定されていないときには常に特定の既定値が返されるように、依存関係プロパティに既定値を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-211">You can specify a default value for a dependency property such that the property always returns a particular default value when it is unset.</span></span> <span data-ttu-id="4c6fa-212">この値は、そのプロパティの型固有の既定値とは別の値にすることができます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-212">This value can be different than the inherent default value for the type of that property.</span></span>

<span data-ttu-id="4c6fa-213">既定値が指定されていない場合、参照型の依存関係プロパティの既定値は null になるか、値型または言語プリミティブの型の既定になります (たとえば、整数の場合は 0、文字列の場合は空の文字列)。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-213">If a default value is not specified, the default value for a dependency property is null for a reference type, or the default of the type for a value type or language primitive (for example, 0 for an integer or an empty string for a string).</span></span> <span data-ttu-id="4c6fa-214">既定値を設定する主な理由は、プロパティに対して [**ClearValue**](https://msdn.microsoft.com/library/windows/apps/br242357) を呼び出すときに、この値が復元されるためです。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-214">The main reason for establishing a default value is that this value is restored when you call [**ClearValue**](https://msdn.microsoft.com/library/windows/apps/br242357) on the property.</span></span> <span data-ttu-id="4c6fa-215">プロパティごとに既定値を設定すると、値型の場合には特に、コンストラクターで既定値を設定するよりも便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-215">Establishing a default value on a per-property basis might be more convenient than establishing default values in constructors, particularly for value types.</span></span> <span data-ttu-id="4c6fa-216">ただし、参照型の場合は、既定値を設定しても意図しないシングルトン パターンが作られないことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-216">However, for reference types, make sure that establishing a default value does not create an unintentional singleton pattern.</span></span> <span data-ttu-id="4c6fa-217">詳しくは、このトピックの「[ベスト プラクティス](#best-practices)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-217">For more info, see [Best practices](#best-practices) later in this topic</span></span>

```cppwinrt
// ImageWithLabelControl.cpp
...
Windows::UI::Xaml::DependencyProperty ImageWithLabelControl::m_labelProperty =
    Windows::UI::Xaml::DependencyProperty::Register(
        L"Label",
        winrt::xaml_typename<winrt::hstring>(),
        winrt::xaml_typename<ImageWithLabelControlApp::ImageWithLabelControl>(),
        Windows::UI::Xaml::PropertyMetadata{ winrt::box_value(L"default label"), Windows::UI::Xaml::PropertyChangedCallback{ &ImageWithLabelControl::OnLabelChanged } }
);
...
```

> [!NOTE]
> <span data-ttu-id="4c6fa-218">既定値を登録しないで[ **UnsetValue**](https://msdn.microsoft.com/library/windows/apps/br242371)します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-218">Do not register with a default value of [**UnsetValue**](https://msdn.microsoft.com/library/windows/apps/br242371).</span></span> <span data-ttu-id="4c6fa-219">登録すると、プロパティのユーザーが混乱し、プロパティ システム内で意図しない結果が発生します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-219">If you do, it will confuse property consumers and will have unintended consequences within the property system.</span></span>

### <a name="createdefaultvaluecallback"></a><span data-ttu-id="4c6fa-220">CreateDefaultValueCallback</span><span class="sxs-lookup"><span data-stu-id="4c6fa-220">CreateDefaultValueCallback</span></span>

<span data-ttu-id="4c6fa-221">シナリオによっては、複数の UI スレッドで使われるオブジェクトの依存関係プロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-221">In some scenarios, you are defining dependency properties for objects that are used on more than one UI thread.</span></span> <span data-ttu-id="4c6fa-222">これは、複数のアプリで使われるデータ オブジェクト、または複数のアプリで使用するコントロールを定義している場合に当てはまることがあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-222">This might be the case if you are defining a data object that is used by multiple apps, or a control that you use in more than one app.</span></span> <span data-ttu-id="4c6fa-223">プロパティを登録したスレッドと関連している、既定値インスタンスではなく [**CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812) の実装を提供することで、さまざまな UI スレッド間でオブジェクトの交換を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-223">You can enable the exchange of the object between different UI threads by providing a [**CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812) implementation rather than a default value instance, which is tied to the thread that registered the property.</span></span> <span data-ttu-id="4c6fa-224">基本的に、[**CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812) は既定値のファクトリを定義します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-224">Basically a [**CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812) defines a factory for default values.</span></span> <span data-ttu-id="4c6fa-225">**CreateDefaultValueCallback** により返された値は、オブジェクトを使っている現在の UI **CreateDefaultValueCallback** スレッドと常に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-225">The value returned by **CreateDefaultValueCallback** is always associated with the current UI **CreateDefaultValueCallback** thread that is using the object.</span></span>

<span data-ttu-id="4c6fa-226">[  **CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812) を指定するメタデータを定義するには、[**PropertyMetadata.Create**](https://msdn.microsoft.com/library/windows/apps/hh702115) を呼び出して、メタデータ インスタンスを返す必要があります。[**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) コンストラクターには **CreateDefaultValueCallback** パラメーターを含むシグネチャがありません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-226">To define metadata that specifies a [**CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812), you must call [**PropertyMetadata.Create**](https://msdn.microsoft.com/library/windows/apps/hh702115) to return a metadata instance; the [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) constructors do not have a signature that includes a **CreateDefaultValueCallback** parameter.</span></span>

<span data-ttu-id="4c6fa-227">[  **CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812) の一般的な実装パターンでは、新しい [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) クラスを作成し、**DependencyObject** の各プロパティの特定のプロパティ値を目的の既定値に設定してから、**CreateDefaultValueCallback** メソッドの戻り値によって新しいクラスを **Object** リファレンスとして返します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-227">The typical implementation pattern for a [**CreateDefaultValueCallback**](https://msdn.microsoft.com/library/windows/apps/hh701812) is to create a new [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) class, set the specific property value of each property of the **DependencyObject** to the intended default, and then return the new class as an **Object** reference via the return value of the **CreateDefaultValueCallback** method.</span></span>

### <a name="property-changed-callback-method"></a><span data-ttu-id="4c6fa-228">プロパティ変更コールバック メソッド</span><span class="sxs-lookup"><span data-stu-id="4c6fa-228">Property-changed callback method</span></span>

<span data-ttu-id="4c6fa-229">プロパティ変更コールバック メソッドを定義して、プロパティと他の依存関係プロパティの対話を定義することや、プロパティが変更されるたびに内部プロパティまたはオブジェクトの状態を更新することができます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-229">You can define a property-changed callback method to define your property's interactions with other dependency properties, or to update an internal property or state of your object whenever the property changes.</span></span> <span data-ttu-id="4c6fa-230">コールバックが呼び出された場合、プロパティ システムは有効なプロパティ値の変更があるかどうかを判断しています。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-230">If your callback is invoked, the property system has determined that there is an effective property value change.</span></span> <span data-ttu-id="4c6fa-231">コールバック メソッドは静的であるため、変更をレポートしたクラスのインスタンスを示すコールバックの *d* パラメーターは重要です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-231">Because the callback method is static, the *d* parameter of the callback is important because it tells you which instance of the class has reported a change.</span></span> <span data-ttu-id="4c6fa-232">標準的な実装では、通常は *d* として渡されるオブジェクトに対して他の変更を実行することで、イベント データの [**NewValue**](https://msdn.microsoft.com/library/windows/apps/br242364) プロパティを使い、その値をいずれかの方法で処理します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-232">A typical implementation uses the [**NewValue**](https://msdn.microsoft.com/library/windows/apps/br242364) property of the event data and processes that value in some manner, usually by performing some other change on the object passed as *d*.</span></span> <span data-ttu-id="4c6fa-233">プロパティ変更に対する追加の応答では、**NewValue** でレポートされる値を拒否、[**OldValue**](https://msdn.microsoft.com/library/windows/apps/br242365) を復元、または **NewValue** に適用されるプログラムの制約に値を設定します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-233">Additional responses to a property change are to reject the value reported by **NewValue**, to restore [**OldValue**](https://msdn.microsoft.com/library/windows/apps/br242365), or to set the value to a programmatic constraint applied to the **NewValue**.</span></span>

<span data-ttu-id="4c6fa-234">次の例では、[**PropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/br208770) の実装を示しています。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-234">This next example shows a [**PropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/br208770) implementation.</span></span> <span data-ttu-id="4c6fa-235">これは、前の [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) の例で参照したメソッドを、[**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) の構成引数の一部として実装します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-235">It implements the method you saw referenced in the previous [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) examples, as part of the construction arguments for the [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771).</span></span> <span data-ttu-id="4c6fa-236">このコールバックで処理するシナリオは、クラスに "HasLabelValue" という名前の計算された読み取り専用プロパティもある場合です (実装は示していません)。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-236">The scenario addressed by this callback is that the class also has a calculated read-only property named "HasLabelValue" (implementation not shown).</span></span> <span data-ttu-id="4c6fa-237">"Label" プロパティが再評価されるたびに、このコールバック メソッドが呼び出され、コールバックは依存する計算された値が依存関係プロパティに対する変更との同期を保てるようにします。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-237">Whenever the "Label" property gets reevaluated, this callback method is invoked, and the callback enables the dependent calculated value to remain in synchronization with changes to the dependency property.</span></span>

```csharp
private static void OnLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
    ImageWithLabelControl iwlc = d as ImageWithLabelControl; //null checks omitted
    String s = e.NewValue as String; //null checks omitted
    if (s == String.Empty)
    {
        iwlc.HasLabelValue = false;
    } else {
        iwlc.HasLabelValue = true;
    }
}
```

```vb
    Private Shared Sub OnLabelChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim iwlc As ImageWithLabelControl = CType(d, ImageWithLabelControl) ' null checks omitted
        Dim s As String = CType(e.NewValue,String) ' null checks omitted
        If s Is String.Empty Then
            iwlc.HasLabelValue = False
        Else
            iwlc.HasLabelValue = True
        End If
    End Sub
```

```cppwinrt
void ImageWithLabelControl::OnLabelChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& e)
{
    auto iwlc{ d.as<ImageWithLabelControlApp::ImageWithLabelControl>() };
    auto s{ winrt::unbox_value<winrt::hstring>(e.NewValue()) };
    iwlc.HasLabelValue(s.size() != 0);
}
```

```cpp
static void OnLabelChanged(DependencyObject^ d, DependencyPropertyChangedEventArgs^ e)
{
    ImageWithLabelControl^ iwlc = (ImageWithLabelControl^)d;
    Platform::String^ s = (Platform::String^)(e->NewValue);
    if (s->IsEmpty()) {
        iwlc->HasLabelValue=false;
    }
}
```

### <a name="property-changed-behavior-for-structures-and-enumerations"></a><span data-ttu-id="4c6fa-238">構造体と列挙に対するプロパティ変更動作</span><span class="sxs-lookup"><span data-stu-id="4c6fa-238">Property changed behavior for structures and enumerations</span></span>

<span data-ttu-id="4c6fa-239">[  **DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) の型が列挙または構造体である場合、構造体または列挙値の内部値が変更されなかった場合でも、コールバックが呼び出されることがあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-239">If the type of a [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) is an enumeration or a structure, the callback may be invoked even if the internal values of the structure or the enumeration value did not change.</span></span> <span data-ttu-id="4c6fa-240">これは、値が変更された場合にのみ呼び出される、文字列などのシステム プリミティブとは異なります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-240">This is different from a system primitive such as a string where it only is invoked if the value changed.</span></span> <span data-ttu-id="4c6fa-241">これは、内部で実行されたこれらの値でのボックスとボックス解除操作による影響です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-241">This is a side effect of box and unbox operations on these values that is done internally.</span></span> <span data-ttu-id="4c6fa-242">値が列挙または構造体であるプロパティに [**PropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/br208770) メソッドがある場合、自分で値をキャストし、now-cast 値に使用可能なオーバーロードされた比較演算子を使用して、[**OldValue**](https://msdn.microsoft.com/library/windows/apps/br242365) と [**NewValue**](https://msdn.microsoft.com/library/windows/apps/br242364) を比較する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-242">If you have a [**PropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/br208770) method for a property where your value is an enumeration or structure, you need to compare the [**OldValue**](https://msdn.microsoft.com/library/windows/apps/br242365) and [**NewValue**](https://msdn.microsoft.com/library/windows/apps/br242364) by casting the values yourself and using the overloaded comparison operators that are available to the now-cast values.</span></span> <span data-ttu-id="4c6fa-243">または、このような演算子が使用できなければ (カスタム構造の場合など)、個別の値を比較する必要がある場合もあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-243">Or, if no such operator is available (which might be the case for a custom structure), you may need to compare the individual values.</span></span> <span data-ttu-id="4c6fa-244">値が変更されていないという結果の場合、通常は何もしないことを選びます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-244">You would typically choose to do nothing if the result is that the values have not changed.</span></span>

```csharp
private static void OnVisibilityValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
    if ((Visibility)e.NewValue != (Visibility)e.OldValue)
    {
        //value really changed, invoke your changed logic here
    } // else this was invoked because of boxing, do nothing
}
```

```vb
Private Shared Sub OnVisibilityValueChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    If CType(e.NewValue,Visibility) != CType(e.OldValue,Visibility) Then
        '  value really changed, invoke your changed logic here
    End If
    '  else this was invoked because of boxing, do nothing
End Sub
```

```cppwinrt
static void OnVisibilityValueChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& e)
{
    auto oldVisibility{ winrt::unbox_value<Windows::UI::Xaml::Visibility>(e.OldValue()) };
    auto newVisibility{ winrt::unbox_value<Windows::UI::Xaml::Visibility>(e.NewValue()) };

    if (newVisibility != oldVisibility)
    {
        // The value really changed; invoke your property-changed logic here.
    }
    // Otherwise, OnVisibilityValueChanged was invoked because of boxing; do nothing.
}
```

```cpp
static void OnVisibilityValueChanged(DependencyObject^ d, DependencyPropertyChangedEventArgs^ e)
{
    if ((Visibility)e->NewValue != (Visibility)e->OldValue)
    {
        //value really changed, invoke your changed logic here
    } 
    // else this was invoked because of boxing, do nothing
    }
}
```

## <a name="best-practices"></a><span data-ttu-id="4c6fa-245">ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="4c6fa-245">Best practices</span></span>

<span data-ttu-id="4c6fa-246">カスタム依存関係プロパティを定義するときには、次の考慮事項をヒントとして念頭に置いてください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-246">Keep the following considerations in mind as best practices when as you define your custom dependency property.</span></span>

### <a name="dependencyobject-and-threading"></a><span data-ttu-id="4c6fa-247">DependencyObject とスレッド</span><span class="sxs-lookup"><span data-stu-id="4c6fa-247">DependencyObject and threading</span></span>

<span data-ttu-id="4c6fa-248">すべての [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) インスタンスは、Windows ランタイム アプリによって表示される現在の [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) と関連付けられている UI スレッド上で作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-248">All [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) instances must be created on the UI thread which is associated with the current [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) that is shown by a Windows Runtime app.</span></span> <span data-ttu-id="4c6fa-249">それぞれの **DependencyObject** はメイン UI スレッド上で作成する必要がありますが、オブジェクトは、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br230616) を呼び出すことにより、他のスレッドからディスパッチャー参照を使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-249">Although each **DependencyObject** must be created on the main UI thread, the objects can be accessed using a dispatcher reference from other threads, by calling [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br230616).</span></span>

<span data-ttu-id="4c6fa-250">[  **DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) のスレッドの側面も問題となります。それは、通常、UI スレッド上で実行されるコードのみが依存関係プロパティの値を変更または読み取ることができることを意味するためです。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-250">The threading aspects of [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) are relevant because it generally means that only code that runs on the UI thread can change or even read the value of a dependency property.</span></span> <span data-ttu-id="4c6fa-251">通常、**非同期**パターンとバックグラウンド ワーカー スレッドを適切に使う一般的な UI コードでは、スレッドの問題を回避できます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-251">Threading issues can usually be avoided in typical UI code that makes correct use of **async** patterns and background worker threads.</span></span> <span data-ttu-id="4c6fa-252">独自に **DependencyObject** 型を定義し、それをデータ ソースや **DependencyObject** が必ずしも適切でないその他のシナリオで使おうとすると、通常は **DependencyObject** に関連するスレッドの問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-252">You typically only run into **DependencyObject**-related threading issues if you are defining your own **DependencyObject** types and you attempt to use them for data sources or other scenarios where a **DependencyObject** isn't necessarily appropriate.</span></span>

### <a name="avoiding-unintentional-singletons"></a><span data-ttu-id="4c6fa-253">意図しないシングルトンの回避</span><span class="sxs-lookup"><span data-stu-id="4c6fa-253">Avoiding unintentional singletons</span></span>

<span data-ttu-id="4c6fa-254">意図しないシングルトンは、参照型を受け取る依存関係プロパティを宣言し、その参照型のコンストラクターを、[**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) を設定するコードの一部として呼び出す場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-254">An unintentional singleton can happen if you are declaring a dependency property that takes a reference type, and you call a constructor for that reference type as part of the code that establishes your [**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771).</span></span> <span data-ttu-id="4c6fa-255">その場合、使用するすべての依存関係が **PropertyMetadata** の 1 つのインスタンスを共有し、したがって構築した単一の参照型を共有しようとします。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-255">What happens is that all usages of the dependency property share just one instance of **PropertyMetadata** and thus try to share the single reference type you constructed.</span></span> <span data-ttu-id="4c6fa-256">依存関係プロパティで設定するその値型のすべてのサブプロパティは、おそらく意図しない方法で他のオブジェクトに伝播されます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-256">Any subproperties of that value type that you set through your dependency property then propagate to other objects in ways you may not have intended.</span></span>

<span data-ttu-id="4c6fa-257">クラス コンストラクターを使うと、null 以外の値が必要な場合に参照型の依存関係プロパティの初期値を設定できますが、[依存関係プロパティの概要](dependency-properties-overview.md)の趣旨に沿って、これはローカル値と見なされることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-257">You can use class constructors to set initial values for a reference-type dependency property if you want a non-null value, but be aware that this would be considered a local value for purposes of [Dependency properties overview](dependency-properties-overview.md).</span></span> <span data-ttu-id="4c6fa-258">クラスでテンプレートがサポートされる場合は、この目的にテンプレートを使う方が適切な場合があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-258">It might be more appropriate to use a template for this purpose, if your class supports templates.</span></span> <span data-ttu-id="4c6fa-259">シングルトン パターンを回避すると同時に便利な既定値を提供する別の方法は、そのクラスの値に適した既定値を提供する静的プロパティを参照型で公開することです。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-259">Another way to avoid a singleton pattern, but still provide a useful default, is to expose a static property on the reference type that provides a suitable default for the values of that class.</span></span>

### <a name="collection-type-dependency-properties"></a><span data-ttu-id="4c6fa-260">コレクション型の依存関係プロパティ</span><span class="sxs-lookup"><span data-stu-id="4c6fa-260">Collection-type dependency properties</span></span>

<span data-ttu-id="4c6fa-261">コレクション型の依存関係プロパティでは、いくつかの実装の問題を追加で考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-261">Collection-type dependency properties have some additional implementation issues to consider.</span></span>

<span data-ttu-id="4c6fa-262">コレクション型の依存関係プロパティは、Windows ランタイム API では比較的まれです。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-262">Collection-type dependency properties are relatively rare in the Windows Runtime API.</span></span> <span data-ttu-id="4c6fa-263">ほとんどの場合、項目が [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) サブクラスであるコレクションを使うことができますが、コレクション プロパティ自体は従来の CLR または C++ プロパティとして実装されます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-263">In most cases, you can use collections where the items are a [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) subclass, but the collection property itself is implemented as a conventional CLR or C++ property.</span></span> <span data-ttu-id="4c6fa-264">これは、依存関係プロパティが関与するいくつかの典型的なシナリオにはコレクションが必ずしも適さないためです。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-264">This is because collections do not necessarily suit some typical scenarios where dependency properties are involved.</span></span> <span data-ttu-id="4c6fa-265">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-265">For example:</span></span>

- <span data-ttu-id="4c6fa-266">通常は、コレクションをアニメーション化しません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-266">You do not typically animate a collection.</span></span>
- <span data-ttu-id="4c6fa-267">通常、スタイルまたはテンプレートを持つコレクションには項目を事前設定しません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-267">You do not typically prepopulate the items in a collection with styles or a template.</span></span>
- <span data-ttu-id="4c6fa-268">コレクションへのバインディングは主要なシナリオですが、コレクションはバインディング ソースとなる依存関係プロパティでなくてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-268">Although binding to collections is a major scenario, a collection does not need to be a dependency property to be a binding source.</span></span> <span data-ttu-id="4c6fa-269">バインディング ターゲットの場合は、[**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/br242803) または [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348) のサブクラスを使ってコレクション項目をサポートするか、ビュー モデル パターンを使う方が一般的です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-269">For binding targets, it is more typical to use subclasses of [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/br242803) or [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348) to support collection items, or to use view-model patterns.</span></span> <span data-ttu-id="4c6fa-270">コレクションとのバインディングについて詳しくは、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-270">For more info about binding to and from collections, see [Data binding in depth](https://msdn.microsoft.com/library/windows/apps/mt210946).</span></span>
- <span data-ttu-id="4c6fa-271">コレクションの変更の通知は、**INotifyPropertyChanged** や **INotifyCollectionChanged** などのインターフェイスを通じて処理するか、[**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/ms668604.aspx) からコレクション型を派生させることで処理する方が適切です。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-271">Notifications for collection changes are better addressed through interfaces such as **INotifyPropertyChanged** or **INotifyCollectionChanged**, or by deriving the collection type from [**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/ms668604.aspx).</span></span>

<span data-ttu-id="4c6fa-272">それでも、コレクション型の依存関係プロパティのシナリオは存在します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-272">Nevertheless, scenarios for collection-type dependency properties do exist.</span></span> <span data-ttu-id="4c6fa-273">次の 3 つのセクションでは、コレクション型の依存関係プロパティを実装する方法に関するガイダンスを示します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-273">The next three sections provide some guidance on how to implement a collection-type dependency property.</span></span>

### <a name="initializing-the-collection"></a><span data-ttu-id="4c6fa-274">コレクションの初期化</span><span class="sxs-lookup"><span data-stu-id="4c6fa-274">Initializing the collection</span></span>

<span data-ttu-id="4c6fa-275">依存関係プロパティを作る場合は、依存関係プロパティ メタデータを使って既定値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-275">When you create a dependency property, you can establish a default value by means of dependency property metadata.</span></span> <span data-ttu-id="4c6fa-276">ただし、シングルトン静的コレクションを既定値として使わないように注意してください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-276">But be careful to not use a singleton static collection as the default value.</span></span> <span data-ttu-id="4c6fa-277">代わりに、コレクション プロパティの所有者クラスのクラス コンストラクター ロジックの一部として、コレクション値を一意の (インスタンス) コレクションに意図的に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-277">Instead, you must deliberately set the collection value to a unique (instance) collection as part of class-constructor logic for the owner class of the collection property.</span></span>

### <a name="change-notifications"></a><span data-ttu-id="4c6fa-278">変更通知</span><span class="sxs-lookup"><span data-stu-id="4c6fa-278">Change notifications</span></span>

<span data-ttu-id="4c6fa-279">コレクションを依存関係プロパティとして定義しても、"PropertyChanged" コールバック メソッドを呼び出すプロパティ システムによってコレクションの項目の変更通知が自動的に提供されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-279">Defining the collection as a dependency property does not automatically provide change notification for the items in the collection by virtue of the property system invoking the "PropertyChanged" callback method.</span></span> <span data-ttu-id="4c6fa-280">たとえばデータ バインディング シナリオなどでコレクションまたはコレクション項目の通知が必要な場合は、**INotifyPropertyChanged** インターフェイスまたは **INotifyCollectionChanged** インターフェイスを実装します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-280">If you want notifications for collections or collection items—for example, for a data-binding scenario— implement the **INotifyPropertyChanged** or **INotifyCollectionChanged** interface.</span></span> <span data-ttu-id="4c6fa-281">詳しくは、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-281">For more info, see [Data binding in depth](https://msdn.microsoft.com/library/windows/apps/mt210946).</span></span>

### <a name="dependency-property-security-considerations"></a><span data-ttu-id="4c6fa-282">依存関係プロパティのセキュリティに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="4c6fa-282">Dependency property security considerations</span></span>

<span data-ttu-id="4c6fa-283">依存関係プロパティはパブリック プロパティとして宣言します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-283">Declare dependency properties as public properties.</span></span> <span data-ttu-id="4c6fa-284">依存関係プロパティ識別子は、**public static readonly** メンバーとして宣言します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-284">Declare dependency property identifiers as **public static readonly** members.</span></span> <span data-ttu-id="4c6fa-285">言語で許可されている他のアクセス レベル (**protected** など) を宣言しようとした場合でも、依存関係プロパティは常に、プロパティ システム API と組み合わせた識別子を使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-285">Even if you attempt to declare other access levels permitted by a language (such as **protected**), a dependency property can always be accessed through the identifier in combination with the property-system APIs.</span></span> <span data-ttu-id="4c6fa-286">依存関係プロパティ識別子を内部またはプライベートして宣言すると、プロパティ システムは正常に動作できないため、このような宣言は機能しません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-286">Declaring the dependency property identifier as internal or private will not work, because then the property system cannot operate properly.</span></span>

<span data-ttu-id="4c6fa-287">ラッパー プロパティは便宜だけが目的であるため、ラッパーに適用されるセキュリティ メカニズムは [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) または [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) を代わりに呼び出すことでバイパスできます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-287">Wrapper properties are really just for convenience, Security mechanisms applied to the wrappers can be bypassed by calling [**GetValue**](https://msdn.microsoft.com/library/windows/apps/br242359) or [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) instead.</span></span> <span data-ttu-id="4c6fa-288">したがって、ラッパー プロパティはパブリックのままにしてください。そうしないと、正当な呼び出し元がプロパティを使いにくくなるだけで、実際のセキュリティ上の利点はありません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-288">So keep wrapper properties public; otherwise you just make your property harder for legitimate callers to use without providing any real security benefit.</span></span>

<span data-ttu-id="4c6fa-289">Windows ランタイムには、カスタム依存関係プロパティを読み取り専用として登録する方法は用意されていません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-289">The Windows Runtime does not provide a way to register a custom dependency property as read-only.</span></span>

### <a name="dependency-properties-and-class-constructors"></a><span data-ttu-id="4c6fa-290">依存関係プロパティとクラス コンストラクター</span><span class="sxs-lookup"><span data-stu-id="4c6fa-290">Dependency properties and class constructors</span></span>

<span data-ttu-id="4c6fa-291">クラス コンストラクターは仮想メソッドを呼び出してはならないという一般的な原則があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-291">There is a general principle that class constructors should not call virtual methods.</span></span> <span data-ttu-id="4c6fa-292">これは、コンストラクターは派生クラス コンストラクターの基本の初期化を実行するために呼び出すことができ、構築されるオブジェクト インスタンスの初期化がまだ完了していないときにコンストラクターから仮想メソッドに入ることがあるためです。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-292">This is because constructors can be called to accomplish base initialization of a derived class constructor, and entering the virtual method through the constructor might occur when the object instance being constructed is not yet completely initialized.</span></span> <span data-ttu-id="4c6fa-293">[  **DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から既に派生したクラスから派生する場合は、プロパティ システム自体がそのサービスの一部として仮想メソッドを内部的に呼び出し、公開することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-293">When you derive from any class that already derives from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356), remember that the property system itself calls and exposes virtual methods internally as part of its services.</span></span> <span data-ttu-id="4c6fa-294">実行時の初期化での潜在的な問題を回避するために、クラスのコンストラクター内では依存関係プロパティを設定しないでください。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-294">To avoid potential problems with run-time initialization, don't set dependency property values within constructors of classes.</span></span>

### <a name="registering-the-dependency-properties-for-ccx-apps"></a><span data-ttu-id="4c6fa-295">C++/CX アプリの依存関係プロパティの登録</span><span class="sxs-lookup"><span data-stu-id="4c6fa-295">Registering the dependency properties for C++/CX apps</span></span>

<span data-ttu-id="4c6fa-296">C++/CX のプロパティ登録の実装は、C# より込み入っています。それは、ヘッダー ファイルと実装ファイルに分かれているためと、実装ファイルのルート スコープでの初期化が好ましくないためです </span><span class="sxs-lookup"><span data-stu-id="4c6fa-296">The implementation for registering a property in C++/CX is trickier than C#, both because of the separation into header and implementation file and also because initialization at the root scope of the implementation file is a bad practice.</span></span> <span data-ttu-id="4c6fa-297">(Visual C コンポーネント拡張 (C +/cli CX) 静的初期化子コードでは、直接にルート スコープから**DllMain**であるのに対しC#コンパイラがクラスに静的初期化子を割り当てるし、なくなり**DllMain**ロックの問題をロードします。)。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-297">(Visual C++ component extensions (C++/CX) puts static initializer code from the root scope directly into **DllMain**, whereas C# compilers assign the static initializers to classes and thus avoid **DllMain** load lock issues.).</span></span> <span data-ttu-id="4c6fa-298">ここでのベスト プラクティスは、クラスごとに 1 つ、そのクラスの依存関係プロパティの登録をすべて実行するヘルパー関数を宣言することです。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-298">The best practice here is to declare a helper function that does all your dependency property registration for a class, one function per class.</span></span> <span data-ttu-id="4c6fa-299">続いて、アプリで使う各カスタム クラスについて、使う各カスタム クラスが公開したヘルパー登録関数を参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-299">Then for each custom class your app consumes, you'll have to reference the helper registration function that's exposed by each custom class you want to use.</span></span> <span data-ttu-id="4c6fa-300">`InitializeComponent` の前に、[**Application constructor**](https://msdn.microsoft.com/library/windows/apps/br242325) (`App::App()`) の一環として各ヘルパー登録関数を 1 回だけ呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-300">Call each helper registration function once as part of the [**Application constructor**](https://msdn.microsoft.com/library/windows/apps/br242325) (`App::App()`), prior to `InitializeComponent`.</span></span> <span data-ttu-id="4c6fa-301">そのコンストラクターは、アプリが実際に初めて参照されたときにだけ実行され、たとえば中断されたアプリが再開された場合には実行されません。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-301">That constructor only runs when the app is really referenced for the first time, it won't run again if a suspended app resumes, for example.</span></span> <span data-ttu-id="4c6fa-302">また、前の C++ 登録の例に示すように、各 [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) 呼び出し時の **nullptr** チェックが重要です。これによって、関数の呼び出し元がプロパティを 2 回登録できないことが保証されます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-302">Also, as seen in the previous C++ registration example, the **nullptr** check around each [**Register**](https://msdn.microsoft.com/library/windows/apps/hh701829) call is important: it's insurance that no caller of the function can register the property twice.</span></span> <span data-ttu-id="4c6fa-303">このようなチェックをしないで 2 回、登録を呼び出すと、プロパティ名が重複するためアプリはおそらくクラッシュします。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-303">A second registration call would probably crash your app without such a check because the property name would be a duplicate.</span></span> <span data-ttu-id="4c6fa-304">[XAML ユーザー コントロールとカスタム コントロールのサンプルに関するページ](https://go.microsoft.com/fwlink/p/?linkid=238581)でサンプルの C++/CX バージョンのコードを参照すると、この実装パターンを確認できます。</span><span class="sxs-lookup"><span data-stu-id="4c6fa-304">You can see this implementation pattern in the [XAML user and custom controls sample](https://go.microsoft.com/fwlink/p/?linkid=238581) if you look at the code for the C++/CX version of the sample.</span></span>

## <a name="related-topics"></a><span data-ttu-id="4c6fa-305">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4c6fa-305">Related topics</span></span>

- [<span data-ttu-id="4c6fa-306">**DependencyObject**</span><span class="sxs-lookup"><span data-stu-id="4c6fa-306">**DependencyObject**</span></span>](https://msdn.microsoft.com/library/windows/apps/br242356)
- [<span data-ttu-id="4c6fa-307">**DependencyProperty.Register**</span><span class="sxs-lookup"><span data-stu-id="4c6fa-307">**DependencyProperty.Register**</span></span>](https://msdn.microsoft.com/library/windows/apps/hh701829)
- [<span data-ttu-id="4c6fa-308">依存関係プロパティの概要</span><span class="sxs-lookup"><span data-stu-id="4c6fa-308">Dependency properties overview</span></span>](dependency-properties-overview.md)
- [<span data-ttu-id="4c6fa-309">XAML ユーザーとカスタム コントロールのサンプル</span><span class="sxs-lookup"><span data-stu-id="4c6fa-309">XAML user and custom controls sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=238581)
 