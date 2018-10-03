---
author: jwmsft
description: XAML 添付プロパティを依存関係プロパティとして実装する方法と、添付プロパティを XAML で使うために必要なアクセサー変換を定義する方法を説明します。
title: カスタム添付プロパティ
ms.assetid: E9C0C57E-6098-4875-AA3E-9D7B36E160E0
ms.author: jimwalk
ms.date: 07/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cppwinrt
- cpp
ms.openlocfilehash: ce26242f1f5093afcbfb652a7d1736897975cb3a
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4314634"
---
# <a name="custom-attached-properties"></a><span data-ttu-id="8fe65-104">カスタム添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="8fe65-104">Custom attached properties</span></span>

<span data-ttu-id="8fe65-105">*添付プロパティ*は、XAML の概念です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-105">An *attached property* is a XAML concept.</span></span> <span data-ttu-id="8fe65-106">添付プロパティは、通常は依存関係プロパティの特殊な形式として定義されます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-106">Attached properties are typically defined as a specialized form of dependency property.</span></span> <span data-ttu-id="8fe65-107">このトピックでは、添付プロパティを依存関係プロパティとして実装する方法と、添付プロパティを XAML で使うために必要なアクセサー変換を定義する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-107">This topic explains how to implement an attached property as a dependency property and how to define the accessor convention that is necessary for your attached property to be usable in XAML.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="8fe65-108">必要条件</span><span class="sxs-lookup"><span data-stu-id="8fe65-108">Prerequisites</span></span>

<span data-ttu-id="8fe65-109">依存関係プロパティを既にある依存関係プロパティのユーザーの観点から理解し、「[依存関係プロパティの概要](dependency-properties-overview.md)」を読んでいることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="8fe65-109">We assume that you understand dependency properties from the perspective of a consumer of existing dependency properties, and that you have read the [Dependency properties overview](dependency-properties-overview.md).</span></span> <span data-ttu-id="8fe65-110">「[添付プロパティの概要](attached-properties-overview.md)」も読んでいる必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-110">You should also have read [Attached properties overview](attached-properties-overview.md).</span></span> <span data-ttu-id="8fe65-111">このトピックの例を参考にするには、XAML について理解し、C++、C#、または Visual Basic を使った基本的な Windows ランタイム アプリを作る方法を理解している必要もあります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-111">To follow the examples in this topic, you should also understand XAML and know how to write a basic Windows Runtime app using C++, C#, or Visual Basic.</span></span>

## <a name="scenarios-for-attached-properties"></a><span data-ttu-id="8fe65-112">添付プロパティのシナリオ</span><span class="sxs-lookup"><span data-stu-id="8fe65-112">Scenarios for attached properties</span></span>

<span data-ttu-id="8fe65-113">定義クラス以外のクラスで利用できるプロパティ設定メカニズムが必要な場合は、添付プロパティを作成できます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-113">You might create an attached property when there is a reason to have a property-setting mechanism available for classes other than the defining class.</span></span> <span data-ttu-id="8fe65-114">その最も一般的なシナリオは、レイアウトとサービス サポートです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-114">The most common scenarios for this are layout and services support.</span></span> <span data-ttu-id="8fe65-115">既にあるレイアウト プロパティの例として、[**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/hh759773) と [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/hh759772) があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-115">Examples of existing layout properties are [**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/hh759773) and [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/hh759772).</span></span> <span data-ttu-id="8fe65-116">レイアウトのシナリオでは、レイアウト制御要素の子要素として存在する要素は親要素に対するレイアウト要件を個別に表現でき、それぞれ、親が添付プロパティとして定義するプロパティ値を設定します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-116">In a layout scenario, elements that exist as child elements to layout-controlling elements can express layout requirements to their parent elements individually, each setting a property value that the parent defines as an attached property.</span></span> <span data-ttu-id="8fe65-117">Windows ランタイム API のサービス サポートのシナリオの例は、[**ScrollViewer.IsZoomChainingEnabled**](https://msdn.microsoft.com/library/windows/apps/br209561) など、[**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/br209527) の添付プロパティのセットです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-117">An example of the services-support scenario in the Windows Runtime API is set of the attached properties of [**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/br209527), such as [**ScrollViewer.IsZoomChainingEnabled**](https://msdn.microsoft.com/library/windows/apps/br209561).</span></span>

> [!WARNING]
> <span data-ttu-id="8fe65-118">Windows ランタイム XAML 実装の既存の制限は、カスタム添付プロパティをアニメーション化することはできません。</span><span class="sxs-lookup"><span data-stu-id="8fe65-118">An existing limitation of the Windows Runtime XAML implementation is that you cannot animate your custom attached property.</span></span>

## <a name="registering-a-custom-attached-property"></a><span data-ttu-id="8fe65-119">カスタム添付プロパティの登録</span><span class="sxs-lookup"><span data-stu-id="8fe65-119">Registering a custom attached property</span></span>

<span data-ttu-id="8fe65-120">他の種類で使う添付プロパティを厳密に定義する場合、プロパティが登録されているクラスが [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8fe65-120">If you are defining the attached property strictly for use on other types, the class where the property is registered does not have to derive from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356).</span></span> <span data-ttu-id="8fe65-121">ただし、添付プロパティが依存関係プロパティでもある標準モデルに従う場合は、バッキング プロパティ ストアを使うことができるように、アクセサーのターゲット パラメーターで **DependencyObject** を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-121">But you do need to have the target parameter for accessors use **DependencyObject** if you follow the typical model of having your attached property also be a dependency property, so that you can use the backing property store.</span></span>

<span data-ttu-id="8fe65-122">[**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) 型の **public** **static** **readonly** プロパティを宣言することで、添付プロパティを依存関係プロパティとして定義します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-122">Define your attached property as a dependency property by declaring a **public** **static** **readonly** property of type [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362).</span></span> <span data-ttu-id="8fe65-123">このプロパティは、[**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) メソッドの戻り値を使って定義します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-123">You define this property by using the return value of the [**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) method.</span></span> <span data-ttu-id="8fe65-124">プロパティ名は、**RegisterAttached** *name* パラメーターとして指定した添付プロパティ名の終わりに "Property" という文字列を追加した名前と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-124">The property name must match the attached property name you specify as the **RegisterAttached** *name* parameter, with the string "Property" added to the end.</span></span> <span data-ttu-id="8fe65-125">これは、依存関係プロパティが表すプロパティとの関連で依存関係プロパティの識別子に名前を付ける場合の確立された規則です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-125">This is the established convention for naming the identifiers of dependency properties in relation to the properties that they represent.</span></span>

<span data-ttu-id="8fe65-126">カスタム添付プロパティを定義する主要領域は、アクセサーまたはラッパーを定義する方法の点でカスタム依存関係プロパティとは異なります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-126">The main area where defining a custom attached property differs from a custom dependency property is in how you define the accessors or wrappers.</span></span> <span data-ttu-id="8fe65-127">使って[カスタム依存関係プロパティ](custom-dependency-properties.md)で説明されているラッパー手法ではなく、静的なを提供する必要がありますも \**を取得する。 PropertyName*と \**設定。 PropertyName*メソッドを添付プロパティのアクセサーとしてします。</span><span class="sxs-lookup"><span data-stu-id="8fe65-127">Instead of the using the wrapper technique described in [Custom dependency properties](custom-dependency-properties.md), you must also provide static \**Get\*\*\*PropertyName* and \**Set\*\*\*PropertyName* methods as accessors for the attached property.</span></span> <span data-ttu-id="8fe65-128">アクセサーは主に XAML パーサーで使われますが、XAML 以外のシナリオでは他の任意の呼び出し元もこれらを使って値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-128">The accessors are used mostly by the XAML parser, although any other caller can also use them to set values in non-XAML scenarios.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8fe65-129">アクセサーを正しく定義していない場合は、XAML プロセッサが添付プロパティにアクセスできないおそらくはそれを使用しようとするすべてのユーザーは、XAML 解析エラーを取得します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-129">If you don't define the accessors correctly, the XAML processor can't access your attached property and anyone who tries to use it will probably get a XAML parser error.</span></span> <span data-ttu-id="8fe65-130">また、デザイン ツールとコーディング ツールは、参照されるアセンブリでカスタム依存関係プロパティを検出した場合に、"\*Property" という識別子の命名規則に依存することがよくあります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-130">Also, design and coding tools often rely on the "\*Property" conventions for naming identifiers when they encounter a custom dependency property in a referenced assembly.</span></span>

## <a name="accessors"></a><span data-ttu-id="8fe65-131">アクセサー</span><span class="sxs-lookup"><span data-stu-id="8fe65-131">Accessors</span></span>

<span data-ttu-id="8fe65-132">**Get**_PropertyName_ アクセサーのシグネチャは次のようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-132">The signature for the **Get**_PropertyName_ accessor must be this.</span></span>

`public static` <span data-ttu-id="8fe65-133">_valueType_ **Get**_PropertyName_</span><span class="sxs-lookup"><span data-stu-id="8fe65-133">_valueType_ **Get**_PropertyName_</span></span> `(DependencyObject target)`

<span data-ttu-id="8fe65-134">Microsoft Visual Basic の場合は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-134">For Microsoft Visual Basic, it is this.</span></span>

`Public Shared Function Get`<span data-ttu-id="8fe65-135">_PropertyName_`(ByVal target As DependencyObject) As `_valueType_</span><span class="sxs-lookup"><span data-stu-id="8fe65-135">_PropertyName_`(ByVal target As DependencyObject) As `_valueType_</span></span>`)`

<span data-ttu-id="8fe65-136">*target* オブジェクトは実装でより具体的な型にすることができますが、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-136">The *target* object can be of a more specific type in your implementation, but must derive from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356).</span></span> <span data-ttu-id="8fe65-137">*valueType* 戻り値も、実装でより具体的な型にすることができます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-137">The *valueType* return value can also be of a more specific type in your implementation.</span></span> <span data-ttu-id="8fe65-138">基本的な **Object** 型が受け入れられますが、多くの場合、添付プロパティにタイプ セーフを適用します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-138">The basic **Object** type is acceptable, but often you'll want your attached property to enforce type safety.</span></span> <span data-ttu-id="8fe65-139">タイプ セーフ手法として、getter シグネチャと setter シグネチャで型指定を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8fe65-139">The use of typing in the getter and setter signatures is a recommended type-safety technique.</span></span>

<span data-ttu-id="8fe65-140">シグネチャは、\**設定。 PropertyName*アクセサーはこれである必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-140">The signature for the \**Set\*\*\*PropertyName* accessor must be this.</span></span>

`public static void Set`<span data-ttu-id="8fe65-141">_PropertyName_` (DependencyObject target , `_valueType_</span><span class="sxs-lookup"><span data-stu-id="8fe65-141">_PropertyName_` (DependencyObject target , `_valueType_</span></span>` value)`

<span data-ttu-id="8fe65-142">Visual Basic の場合は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-142">For Visual Basic, it is this.</span></span>

`Public Shared Sub Set`<span data-ttu-id="8fe65-143">_PropertyName_` (ByVal target As DependencyObject, ByVal value As `_valueType_</span><span class="sxs-lookup"><span data-stu-id="8fe65-143">_PropertyName_` (ByVal target As DependencyObject, ByVal value As `_valueType_</span></span>`)`

<span data-ttu-id="8fe65-144">*target* オブジェクトは実装でより具体的な型にすることができますが、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-144">The *target* object can be of a more specific type in your implementation, but must derive from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356).</span></span> <span data-ttu-id="8fe65-145">*value* オブジェクトとその *valueType* は、実装でより具体的な型にすることができます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-145">The *value* object and its *valueType* can be of a more specific type in your implementation.</span></span> <span data-ttu-id="8fe65-146">添付プロパティがマークアップに検出された場合、このメソッドの値は XAML プロセッサからの入力であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="8fe65-146">Remember that the value for this method is the input that comes from the XAML processor when it encounters your attached property in markup.</span></span> <span data-ttu-id="8fe65-147">属性値 (最終的には単なる文字列) から適切な型を作成できるように、使う型の型変換または既存のマークアップ拡張サポートが必要です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-147">There must be type conversion or existing markup extension support for the type you use, so that the appropriate type can be created from an attribute value (which is ultimately just a string).</span></span> <span data-ttu-id="8fe65-148">基本的な **Object** 型が受け入れられますが、多くの場合、さらにタイプ セーフにします。</span><span class="sxs-lookup"><span data-stu-id="8fe65-148">The basic **Object** type is acceptable, but often you'll want further type safety.</span></span> <span data-ttu-id="8fe65-149">これを実現するには、アクセサーに型を適用します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-149">To accomplish that, put type enforcement in the accessors.</span></span>

> [!NOTE]
> <span data-ttu-id="8fe65-150">使うことを意図がプロパティ要素構文では、添付プロパティを定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-150">It's also possible to define an attached property where the intended usage is through property element syntax.</span></span> <span data-ttu-id="8fe65-151">その場合、値の型変換は必要ではありませんが、意図した値を XAML で確実に作成できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-151">In that case you don't need type conversion for the values, but you do need to assure that the values you intend can be constructed in XAML.</span></span> <span data-ttu-id="8fe65-152">[**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) は、プロパティ要素の使用だけをサポートする既存の添付プロパティの例です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-152">[**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) is an example of an existing attached property that only supports property element usage.</span></span>

## <a name="code-example"></a><span data-ttu-id="8fe65-153">コードの例</span><span class="sxs-lookup"><span data-stu-id="8fe65-153">Code example</span></span>

<span data-ttu-id="8fe65-154">この例は、([**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) メソッドを使った) 依存関係プロパティの登録と、カスタム添付プロパティの **Get** アクセサーと **Set** アクセサーを示しています。</span><span class="sxs-lookup"><span data-stu-id="8fe65-154">This example shows the dependency property registration (using the [**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) method), as well as the **Get** and **Set** accessors, for a custom attached property.</span></span> <span data-ttu-id="8fe65-155">この例では、添付プロパティ名は `IsMovable` です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-155">In the example, the attached property name is `IsMovable`.</span></span> <span data-ttu-id="8fe65-156">したがって、アクセサーの名前は `GetIsMovable` と `SetIsMovable` にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-156">Therefore, the accessors must be named `GetIsMovable` and `SetIsMovable`.</span></span> <span data-ttu-id="8fe65-157">添付プロパティの所有者は `GameService` という名前の独自の UI を持たないサービス クラスです。その目的は **GameService.IsMovable** 添付プロパティを使うときに、添付プロパティ サービスを提供することだけです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-157">The owner of the attached property is a service class named `GameService` that doesn't have a UI of its own; its purpose is only to provide the attached property services when the **GameService.IsMovable** attached property is used.</span></span>

<span data-ttu-id="8fe65-158">添付プロパティを C++ で定義 +/CX は、少し複雑です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-158">Defining the attached property in C++/CX is a bit more complex.</span></span> <span data-ttu-id="8fe65-159">ヘッダーとコード ファイル間の関連性を決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-159">You have to decide how to factor between the header and code file.</span></span> <span data-ttu-id="8fe65-160">また、「[カスタム依存関係プロパティ](custom-dependency-properties.md)」で説明している理由から、識別子を **get** アクセサーのみ持つプロパティとして公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-160">Also, you should expose the identifier as a property with only a **get** accessor, for reasons discussed in [Custom dependency properties](custom-dependency-properties.md).</span></span> <span data-ttu-id="8fe65-161">C++/cli CX このプロパティとフィールドの関係を定義する必要があります単純なプロパティのバッキング .NET **readonly**キーワードと暗黙的な証明書利用者のではなく明示的にします。</span><span class="sxs-lookup"><span data-stu-id="8fe65-161">In C++/CX you must define this property-field relationship explicitly rather than relying on .NET **readonly** keywording and implicit backing of simple properties.</span></span> <span data-ttu-id="8fe65-162">また、アプリが最初に開始されたとき、添付プロパティを必要とする XAML ページが読み込まれる前に、1 回だけ実行されるヘルパー関数内で、添付プロパティの登録を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-162">You also need to perform the registration of the attached property within a helper function that only gets run once, when the app first starts but before any XAML pages that need the attached property are loaded.</span></span> <span data-ttu-id="8fe65-163">依存関係プロパティまたは添付プロパティのプロパティ登録ヘルパー関数を呼び出す一般的な場所は、app.xaml ファイルのコードの **App** / [**Application**](https://msdn.microsoft.com/library/windows/apps/br242325) コンストラクターの内部からです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-163">The typical place to call your property registration helper functions for any and all dependency or attached properties is from within the **App** / [**Application**](https://msdn.microsoft.com/library/windows/apps/br242325) constructor in the code for your app.xaml file.</span></span>

```csharp
public class GameService : DependencyObject
{
    public static readonly DependencyProperty IsMovableProperty = 
    DependencyProperty.RegisterAttached(
      "IsMovable",
      typeof(Boolean),
      typeof(GameService),
      new PropertyMetadata(false)
    );
    public static void SetIsMovable(UIElement element, Boolean value)
    {
        element.SetValue(IsMovableProperty, value);
    }
    public static Boolean GetIsMovable(UIElement element)
    {
        return (Boolean)element.GetValue(IsMovableProperty);
    }
}
```

```vb
Public Class GameService
    Inherits DependencyObject

    Public Shared ReadOnly IsMovableProperty As DependencyProperty = 
        DependencyProperty.RegisterAttached("IsMovable",  
        GetType(Boolean), 
        GetType(GameService), 
        New PropertyMetadata(False))

    Public Shared Sub SetIsMovable(ByRef element As UIElement, value As Boolean)
        element.SetValue(IsMovableProperty, value)
    End Sub

    Public Shared Function GetIsMovable(ByRef element As UIElement) As Boolean
        GetIsMovable = CBool(element.GetValue(IsMovableProperty))
    End Function
End Class
```

```cppwinrt
// GameService.idl
namespace UserAndCustomControls
{
    runtimeclass GameService : Windows.UI.Xaml.DependencyObject
    {
        GameService();
        static Windows.UI.Xaml.DependencyProperty IsMovableProperty{ get; };
        Boolean IsMovable;
    }
}

// GameService.h
...
    bool IsMovable(){ return winrt::unbox_value<bool>(GetValue(m_IsMovableProperty)); }
    void IsMovable(bool value){ SetValue(m_IsMovableProperty, winrt::box_value(value)); }
    Windows::UI::Xaml::DependencyProperty IsMovableProperty(){ return m_IsMovableProperty; }

private:
    static Windows::UI::Xaml::DependencyProperty m_IsMovableProperty;
...

// GameService.cpp
...
Windows::UI::Xaml::DependencyProperty GameService::m_IsMovableProperty =
    Windows::UI::Xaml::DependencyProperty::RegisterAttached(
        L"IsMovable",
        winrt::xaml_typename<bool>(),
        winrt::xaml_typename<UserAndCustomControls::GameService>(),
        Windows::UI::Xaml::PropertyMetadata{ winrt::box_value(false) }
);
...
```

```cpp
// GameService.h
#pragma once

#include "pch.h"
//namespace WUX = Windows::UI::Xaml;

namespace UserAndCustomControls {
    public ref class GameService sealed : public WUX::DependencyObject {
    private:
        static WUX::DependencyProperty^ _IsMovableProperty;
    public:
        GameService::GameService();
        void GameService::RegisterDependencyProperties();
        static property WUX::DependencyProperty^ IsMovableProperty
        {
            WUX::DependencyProperty^ get() {
                return _IsMovableProperty;
            }
        };
        static bool GameService::GetIsMovable(WUX::UIElement^ element) {
            return (bool)element->GetValue(_IsMovableProperty);
        };
        static void GameService::SetIsMovable(WUX::UIElement^ element, bool value) {
            element->SetValue(_IsMovableProperty,value);
        }
    };
}

// GameService.cpp
#include "pch.h"
#include "GameService.h"

using namespace UserAndCustomControls;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Documents;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Interop;
using namespace Windows::UI::Xaml::Media;

GameService::GameService() {};

GameService::RegisterDependencyProperties() {
    DependencyProperty^ GameService::_IsMovableProperty = DependencyProperty::RegisterAttached(
         "IsMovable", Platform::Boolean::typeid, GameService::typeid, ref new PropertyMetadata(false));
}
```

## <a name="using-your-custom-attached-property-in-xaml"></a><span data-ttu-id="8fe65-164">XAML でのカスタム添付プロパティの使用</span><span class="sxs-lookup"><span data-stu-id="8fe65-164">Using your custom attached property in XAML</span></span>

<span data-ttu-id="8fe65-165">添付プロパティを定義し、そのサポート メンバーをカスタム型の一部として含めたら、定義を XAML で利用できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-165">After you have defined your attached property and included its support members as part of a custom type, you must then make the definitions available for XAML usage.</span></span> <span data-ttu-id="8fe65-166">そのためには、関連クラスを含むコード名前空間を参照する XAML 名前空間をマップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-166">To do this, you must map a XAML namespace that will reference the code namespace that contains the relevant class.</span></span> <span data-ttu-id="8fe65-167">添付プロパティをライブラリの一部として定義した場合は、そのライブラリをアプリのアプリ パッケージの一部として含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-167">In cases where you have defined the attached property as part of a library, you must include that library as part of the app package for the app.</span></span>

<span data-ttu-id="8fe65-168">XAML の XML 名前空間マッピングは、通常は XAML ページのルート要素に配置されます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-168">An XML namespace mapping for XAML is typically placed in the root element of a XAML page.</span></span> <span data-ttu-id="8fe65-169">たとえば、前のスニペットで示した添付プロパティ定義を含む名前空間 `UserAndCustomControls` に `GameService` という名前のクラスがある場合、マッピングは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-169">For example, for the class named `GameService` in the namespace `UserAndCustomControls` that contains the attached property definitions shown in preceding snippets, the mapping might look like this.</span></span>

```xaml
<UserControl
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:uc="using:UserAndCustomControls"
  ... >
```

<span data-ttu-id="8fe65-170">マッピングを使うと、Windows ランタイムで定義された既にある型も含め、ターゲット定義に一致する任意の要素に `GameService.IsMovable` 添付プロパティを設定できます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-170">Using the mapping, you can set your `GameService.IsMovable` attached property on any element that matches your target definition, including an existing type that Windows Runtime defines.</span></span>

```xaml
<Image uc:GameService.IsMovable="True" .../>
```

<span data-ttu-id="8fe65-171">同じマップされた XML 名前空間内にもある要素にプロパティを設定する場合でも、添付プロパティ名にプレフィックスを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-171">If you are setting the property on an element that is also within the same mapped XML namespace, you still must include the prefix on the attached property name.</span></span> <span data-ttu-id="8fe65-172">これは、プレフィックスによって所有者型が修飾されるためです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-172">This is because the prefix qualifies the owner type.</span></span> <span data-ttu-id="8fe65-173">標準 XML 規則により属性が要素から名前空間を継承できる場合でも、添付プロパティの属性がその属性を含む要素と同じ XML 名前空間にあることは想定できません。</span><span class="sxs-lookup"><span data-stu-id="8fe65-173">The attached property's attribute cannot be assumed to be within the same XML namespace as the element where the attribute is included, even though, by normal XML rules, attributes can inherit namespace from elements.</span></span> <span data-ttu-id="8fe65-174">たとえば、`GameService.IsMovable` を `ImageWithLabelControl` のカスタム型 (定義は示しません) に設定する場合、その両方が同じプレフィックスにマップされる同じコード名前空間に定義されていても、XAML は依然として次のようになります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-174">For example, if you are setting `GameService.IsMovable` on a custom type of `ImageWithLabelControl` (definition not shown), and even if both were defined in the same code namespace mapped to same prefix, the XAML would still be this.</span></span>

```xaml
<uc:ImageWithLabelControl uc:GameService.IsMovable="True" .../>
```

> [!NOTE]
> <span data-ttu-id="8fe65-175">C++ での XAML UI を作成する場合、XAML ページが、その型を使用して、いつでも、添付プロパティを定義するカスタム型のヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-175">If you are writing a XAML UI with C++, you must include the header for the custom type that defines the attached property, any time that a XAML page uses that type.</span></span> <span data-ttu-id="8fe65-176">各 XAML ページには、.xaml.h コード ビハインド ヘッダーが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="8fe65-176">Each XAML page has an associated .xaml.h code-behind header.</span></span> <span data-ttu-id="8fe65-177">ここに、添付プロパティの所有者型の定義のヘッダーを (**\#include** を使って) 含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-177">This is where you should include (using **\#include**) the header for the definition of the attached property's owner type.</span></span>

## <a name="value-type-of-a-custom-attached-property"></a><span data-ttu-id="8fe65-178">カスタム添付プロパティの値型</span><span class="sxs-lookup"><span data-stu-id="8fe65-178">Value type of a custom attached property</span></span>

<span data-ttu-id="8fe65-179">カスタム添付プロパティの値型として使われる型は、使用方法、定義、または使用方法と定義の両方に影響します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-179">The type that is used as the value type of a custom attached property affects the usage, the definition, or both the usage and definition.</span></span> <span data-ttu-id="8fe65-180">添付プロパティの値型は、複数の場所で (**Get** アクセサー メソッドと **Set** アクセサー メソッド両方のシグネチャで、また [**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) 呼び出しの *propertyType* パラメーターとして) 宣言されます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-180">The attached property's value type is declared in several places: in the signatures of both the **Get** and **Set** accessor methods, and also as the *propertyType* parameter of the [**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) call.</span></span>

<span data-ttu-id="8fe65-181">添付プロパティ (カスタムまたはそれ以外) で最も一般的な値型は、単純な文字列です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-181">The most common value type for attached properties (custom or otherwise) is a simple string.</span></span> <span data-ttu-id="8fe65-182">これは、添付プロパティは一般に XAML 属性で使われることが意図されており、文字列を値型として使うとプロパティが軽量になるためです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-182">This is because attached properties are generally intended for XAML attribute usage, and using a string as the value type keeps the properties lightweight.</span></span> <span data-ttu-id="8fe65-183">整数、倍精度浮動小数点、列挙値など、文字列メソッドへのネイティブ変換を持つその他のプリミティブも、添付プロパティの値型として一般的です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-183">Other primitives that have native conversion to string methods, such as integer, double, or an enumeration value, are also common as value types for attached properties.</span></span> <span data-ttu-id="8fe65-184">ネイティブ文字列変換をサポートしない他の値型を添付プロパティ値として使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-184">You can use other value types—ones that don't support native string conversion—as the attached property value.</span></span> <span data-ttu-id="8fe65-185">ただし、その場合は、使用方法または実装について選択が必要です。</span><span class="sxs-lookup"><span data-stu-id="8fe65-185">However, this entails making a choice about either the usage or the implementation:</span></span>

- <span data-ttu-id="8fe65-186">添付プロパティはそのままにすることができますが、添付プロパティでは、添付プロパティがプロパティ要素であり、値がオブジェクト要素として宣言される使用方法のみサポートできます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-186">You can leave the attached property as it is, but the attached property can support usage only where the attached property is a property element, and the value is declared as an object element.</span></span> <span data-ttu-id="8fe65-187">この場合、プロパティ型はオブジェクト要素としての XAML の使用をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-187">In this case, the property type does have to support XAML usage as an object element.</span></span> <span data-ttu-id="8fe65-188">既にある Windows ランタイム参照クラスの場合は、XAML 構文を調べて、型が XAML オブジェクト要素の使用をサポートすることを確認します。</span><span class="sxs-lookup"><span data-stu-id="8fe65-188">For existing Windows Runtime reference classes, check the XAML syntax to make sure that the type supports XAML object element usage.</span></span>
- <span data-ttu-id="8fe65-189">添付プロパティはそのままにすることができますが、文字列として表現できる **Binding** や **StaticResource** などの XAML 参照手法で属性を使う場合にのみ使います。</span><span class="sxs-lookup"><span data-stu-id="8fe65-189">You can leave the attached property as it is, but use it only in an attribute usage through a XAML reference technique such as a **Binding** or **StaticResource** that can be expressed as a string.</span></span>

## <a name="more-about-the-canvasleft-example"></a><span data-ttu-id="8fe65-190">**Canvas.Left** の例に関する詳細</span><span class="sxs-lookup"><span data-stu-id="8fe65-190">More about the **Canvas.Left** example</span></span>

<span data-ttu-id="8fe65-191">添付プロパティの使用法として前に挙げた例では、[**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) 添付プロパティを設定するさまざまな方法を説明しました。</span><span class="sxs-lookup"><span data-stu-id="8fe65-191">In earlier examples of attached property usages we showed different ways to set the [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) attached property.</span></span> <span data-ttu-id="8fe65-192">しかし、それによって [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) がオブジェクトとやり取りする方法やタイミングがどのように変わるのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="8fe65-192">But what does that change about how a [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) interacts with your object, and when does that happen?</span></span> <span data-ttu-id="8fe65-193">ここでは、この例をさらに詳しく検討します。添付プロパティを実装しており、他のオブジェクトで添付プロパティの値が検出された場合に、典型的な添付プロパティの所有者クラスが添付プロパティの値に対して実行する処理を理解するのは意味のあることだからです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-193">We'll examine this particular example further, because if you implement an attached property, it's interesting to see what else a typical attached property owner class intends to do with its attached property values if it finds them on other objects.</span></span>

<span data-ttu-id="8fe65-194">[**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) の主な機能は、UI で絶対位置の決まったレイアウト コンテナーとなることです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-194">The main function of a [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) is to be an absolute-positioned layout container in UI.</span></span> <span data-ttu-id="8fe65-195">**Canvas** の子は、基底クラスの定義済みプロパティ [**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) に格納されます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-195">The children of a **Canvas** are stored in a base-class defined property [**Children**](https://msdn.microsoft.com/library/windows/apps/br227514).</span></span> <span data-ttu-id="8fe65-196">パネルのうち、**Canvas** だけが絶対配置を使います。</span><span class="sxs-lookup"><span data-stu-id="8fe65-196">Of all the panels **Canvas** is the only one that uses absolute positioning.</span></span> <span data-ttu-id="8fe65-197">**Canvas** や特定の **UIElement** が **UIElement** の子要素になっている場合にのみ関係するプロパティを追加した場合には、共通の [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) 型のオブジェクト モデルが大きくなっていたおそれがあります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-197">It would've bloated the object model of the common [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) type to add properties that might only be of concern to **Canvas** and those particular **UIElement** cases where they are child elements of a **UIElement**.</span></span> <span data-ttu-id="8fe65-198">**Canvas** のレイアウト コントロールのプロパティを、どの **UIElement** でも使用できる添付プロパティに定義すると、オブジェクト モデルをすっきりした状態に保つことができます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-198">Defining the layout control properties of a **Canvas** to be attached properties that any **UIElement** can use keeps the object model cleaner.</span></span>

<span data-ttu-id="8fe65-199">[**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) にはパネルを実用的にするため、フレームワーク レベルの [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) と [**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914) メソッドを上書きするという動作があります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-199">In order to be a practical panel, [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) has behavior that overrides the framework-level [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) and [**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914) methods.</span></span> <span data-ttu-id="8fe65-200">**Canvas** が子について実際に添付プロパティを確認するのはここです。</span><span class="sxs-lookup"><span data-stu-id="8fe65-200">This is where **Canvas** actually checks for attached property values on its children.</span></span> <span data-ttu-id="8fe65-201">**Measure** と **Arrange** の両パターンの一部は、コンテンツを反復処理するループです。また、パネルには、パネルの子とされるものを明確にする [**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-201">Part of both the **Measure** and **Arrange** patterns is a loop that iterates over any content, and a panel has the [**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) property that makes it explicit what's supposed to be considered the child of a panel.</span></span> <span data-ttu-id="8fe65-202">このため、**Canvas** レイアウトの動作は、子を反復処理したうえで、子のそれぞれについて [**Canvas.GetLeft**](https://msdn.microsoft.com/library/windows/apps/br209269) と [**Canvas.GetTop**](https://msdn.microsoft.com/library/windows/apps/br209270) の静的呼び出しを実行し、その添付プロパティに既定以外の値 (既定値は 0) が含まれているかどうかを確認するというものになります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-202">So the **Canvas** layout behavior iterates through these children, and makes static [**Canvas.GetLeft**](https://msdn.microsoft.com/library/windows/apps/br209269) and [**Canvas.GetTop**](https://msdn.microsoft.com/library/windows/apps/br209270) calls on each child to see whether those attached properties contain a non-default value (default is 0).</span></span> <span data-ttu-id="8fe65-203">確認された値はその後、**Canvas** の利用可能なレイアウト スペースで子のそれぞれが提供する値に応じて、子の絶対位置を設定するのに使われた後、**Arrange** を使ってコミットされます。</span><span class="sxs-lookup"><span data-stu-id="8fe65-203">These values are then used to absolutely position each child in the **Canvas** available layout space according to the specific values provided by each child, and committed using **Arrange**.</span></span>

<span data-ttu-id="8fe65-204">コードは、次の擬似コードのようになります。</span><span class="sxs-lookup"><span data-stu-id="8fe65-204">The code looks something like this pseudocode.</span></span>

```syntax
protected override Size ArrangeOverride(Size finalSize)
{
    foreach (UIElement child in Children)
    {
        double x = (double) Canvas.GetLeft(child);
        double y = (double) Canvas.GetTop(child);
        child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
    }
    return base.ArrangeOverride(finalSize); 
    // real Canvas has more sophisticated sizing
}
```

> [!NOTE]
> <span data-ttu-id="8fe65-205">パネルの動作について詳しくは、 [XAML カスタム パネルの概要](https://msdn.microsoft.com/library/windows/apps/mt228351)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8fe65-205">For more info on how panels work, see [XAML custom panels overview](https://msdn.microsoft.com/library/windows/apps/mt228351).</span></span>

## <a name="related-topics"></a><span data-ttu-id="8fe65-206">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8fe65-206">Related topics</span></span>

* [**<span data-ttu-id="8fe65-207">RegisterAttached</span><span class="sxs-lookup"><span data-stu-id="8fe65-207">RegisterAttached</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701833)
* [<span data-ttu-id="8fe65-208">添付プロパティの概要</span><span class="sxs-lookup"><span data-stu-id="8fe65-208">Attached properties overview</span></span>](attached-properties-overview.md)
* [<span data-ttu-id="8fe65-209">カスタム依存関係プロパティ</span><span class="sxs-lookup"><span data-stu-id="8fe65-209">Custom dependency properties</span></span>](custom-dependency-properties.md)
* [<span data-ttu-id="8fe65-210">XAML の概要</span><span class="sxs-lookup"><span data-stu-id="8fe65-210">XAML overview</span></span>](xaml-overview.md)
