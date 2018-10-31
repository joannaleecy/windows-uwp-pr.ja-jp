---
author: stevewhims
description: スカラー値は、**IInspectable** を想定している関数に渡す前に、参照クラス オブジェクト内にラップする必要があります。 このラッピング プロセスは、値の*ボックス化*と呼ばれます。
title: C++/WinRT を使用した IInspectable へのスカラー値のボックス化とボックス化解除
ms.author: stwhi
ms.date: 04/10/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、XAML、コントロール、ボックス化、スカラー、値
ms.localizationpriority: medium
ms.openlocfilehash: f4b99f587fbd517b677d85b50abb26fdf072b359
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5830142"
---
# <a name="boxing-and-unboxing-scalar-values-to-iinspectable-with-cwinrt"></a><span data-ttu-id="6f58c-105">C++/WinRT を使用した IInspectable へのスカラー値のボックス化とボックス化解除</span><span class="sxs-lookup"><span data-stu-id="6f58c-105">Boxing and unboxing scalar values to IInspectable with C++/WinRT</span></span>
 
<span data-ttu-id="6f58c-106">[**IInspectable インターフェイス**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) は、Windows ランタイム (WinRT) のすべてのランタイム クラスのルート インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="6f58c-106">The [**IInspectable interface**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) is the root interface of every runtime class in the Windows Runtime (WinRT).</span></span> <span data-ttu-id="6f58c-107">これは、すべての COM インターフェイスとクラスのルートである [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) や、すべての [共通型システム](https://docs.microsoft.com/dotnet/standard/base-types/common-type-system) クラスのルートである **System.Object** と似た概念です。</span><span class="sxs-lookup"><span data-stu-id="6f58c-107">This is an analogous idea to [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) being at the root of every COM interface and class; and **System.Object** being at the root of every [Common Type System](https://docs.microsoft.com/dotnet/standard/base-types/common-type-system) class.</span></span>

<span data-ttu-id="6f58c-108">つまり、**IInspectable** を想定している関数は、任意のランタイム クラスのインスタンスに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="6f58c-108">In other words, a function that expects **IInspectable** can be passed an instance of any runtime class.</span></span> <span data-ttu-id="6f58c-109">ただし、数字やテキスト値などのスカラー値を、またはそのような関数へ、直接渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="6f58c-109">But you can't directly pass a scalar value, such as a numeric or text value, to such a function.</span></span> <span data-ttu-id="6f58c-110">代わりに、スカラー値を参照クラス オブジェクト内にラップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f58c-110">Instead, a scalar value needs to be wrapped inside a reference class object.</span></span> <span data-ttu-id="6f58c-111">このラッピング プロセスは、値の*ボックス化*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="6f58c-111">That wrapping process is known as *boxing* the value.</span></span>

<span data-ttu-id="6f58c-112">[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)スカラー値を受け取り、 **IInspectable**をボックス化された値を返します[**winrt::box_value**](/uwp/cpp-ref-for-winrt/box-value)関数を提供します。</span><span class="sxs-lookup"><span data-stu-id="6f58c-112">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)  provides the [**winrt::box_value**](/uwp/cpp-ref-for-winrt/box-value) function, which takes a scalar value and returns the value boxed into an **IInspectable**.</span></span> <span data-ttu-id="6f58c-113">**IInspectable** をボックス化解除してスカラー値に戻すために、[**winrt::unbox_value**](/uwp/cpp-ref-for-winrt/unbox-value) および [**winrt::unbox_value_or**](/uwp/cpp-ref-for-winrt/unbox-value-or) 関数があります。</span><span class="sxs-lookup"><span data-stu-id="6f58c-113">For unboxing an **IInspectable** back into a scalar value, there are the [**winrt::unbox_value**](/uwp/cpp-ref-for-winrt/unbox-value) and  [**winrt::unbox_value_or**](/uwp/cpp-ref-for-winrt/unbox-value-or) functions.</span></span>

## <a name="examples-of-boxing-a-value"></a><span data-ttu-id="6f58c-114">値をボックス化する例</span><span class="sxs-lookup"><span data-stu-id="6f58c-114">Examples of boxing a value</span></span>
<span data-ttu-id="6f58c-115">[**LaunchActivatedEventArgs::Arguments**](/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.Arguments) アクセサー関数は、スカラー値である [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を返します。</span><span class="sxs-lookup"><span data-stu-id="6f58c-115">The [**LaunchActivatedEventArgs::Arguments**](/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.Arguments) accessor function returns a [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring), which is a scalar value.</span></span> <span data-ttu-id="6f58c-116">その **hstring** 値をボックス化し、次のように **IInspectable** を想定している関数に渡します。</span><span class="sxs-lookup"><span data-stu-id="6f58c-116">We can box that **hstring** value and pass it to a function that expects **IInspectable** like this.</span></span>

```cppwinrt
void App::OnLaunched(LaunchActivatedEventArgs const& e)
{
    ...
    rootFrame.Navigate(winrt::xaml_typename<BlankApp1::MainPage>(), winrt::box_value(e.Arguments()));
    ...
}
```

<span data-ttu-id="6f58c-117">XAML [**Button**](/uwp/api/windows.ui.xaml.controls.button) のコンテンツ プロパティを設定するには、[**Button::Content**](/uwp/api/windows.ui.xaml.controls.contentcontrol.content?) ミューテーター関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6f58c-117">To set the content property of a XAML [**Button**](/uwp/api/windows.ui.xaml.controls.button), you call the [**Button::Content**](/uwp/api/windows.ui.xaml.controls.contentcontrol.content?) mutator function.</span></span> <span data-ttu-id="6f58c-118">コンテンツのプロパティを文字列値に設定するには、このコードを使用できます。</span><span class="sxs-lookup"><span data-stu-id="6f58c-118">To set the content property to a string value, you can use this code.</span></span>

```cppwinrt
Button().Content(winrt::box_value(L"Clicked"));
```

<span data-ttu-id="6f58c-119">まず、[**hstring**](/uwp/cpp-ref-for-winrt/hstring) 変換コンストラクターが文字列リテラルを **hstring** に変換します。</span><span class="sxs-lookup"><span data-stu-id="6f58c-119">First, the [**hstring**](/uwp/cpp-ref-for-winrt/hstring) conversion constructor converts the string literal into an **hstring**.</span></span> <span data-ttu-id="6f58c-120">次に **hstring** を受け取る **winrt::box_value** のオーバーロードが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6f58c-120">Then the overload of **winrt::box_value** that takes an **hstring** is invoked.</span></span>

## <a name="examples-of-unboxing-an-iinspectable"></a><span data-ttu-id="6f58c-121">IInspectable をボックス化解除する例</span><span class="sxs-lookup"><span data-stu-id="6f58c-121">Examples of unboxing an IInspectable</span></span>
<span data-ttu-id="6f58c-122">**IInspectable** を想定する独自の関数では、[**winrt::unbox_value**](/uwp/cpp-ref-for-winrt/unbox-value) を使用してボックス化解除することができます。また [**winrt::unbox_value_or**](/uwp/cpp-ref-for-winrt/unbox-value-or) を使用して既定値でボックス化解除することができます。</span><span class="sxs-lookup"><span data-stu-id="6f58c-122">In your own functions that expect **IInspectable**, you can use [**winrt::unbox_value**](/uwp/cpp-ref-for-winrt/unbox-value) to unbox, and you can use [**winrt::unbox_value_or**](/uwp/cpp-ref-for-winrt/unbox-value-or) to unbox with a default value.</span></span>

```cppwinrt
void Unbox(winrt::Windows::Foundation::IInspectable const& object)
{
    hstring hstringValue = unbox_value<hstring>(object); // Throws if object is not a boxed string.
    hstringValue = unbox_value_or<hstring>(object, L"Default"); // Returns L"Default" if object is not a boxed string.
    float floatValue = unbox_value_or<float>(object, 0.f); // Returns 0.0 if object is not a boxed float.
}
```

## <a name="determine-the-type-of-a-boxed-value"></a><span data-ttu-id="6f58c-123">ボックス化された値の型の判別</span><span class="sxs-lookup"><span data-stu-id="6f58c-123">Determine the type of a boxed value</span></span>
<span data-ttu-id="6f58c-124">ボックス化された値を受け取って、その値に含まれる型が不明な場合は (型はボックス化解除するために知っておく必要があります)、その [**IPropertyValue**](/uwp/api/windows.foundation.ipropertyvalue) でボックス化された値を照会し、そこで **Type** を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6f58c-124">If you receive a boxed value and you're unsure what type it contains (you need to know its type in order to unbox it), then you can query the boxed value for its [**IPropertyValue**](/uwp/api/windows.foundation.ipropertyvalue) interface, and then call **Type** on that.</span></span> <span data-ttu-id="6f58c-125">次にコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="6f58c-125">Here's a code example.</span></span>

```cppwinrt
float pi = 3.14f;
auto piInspectable = winrt::box_value(pi);
auto piPropertyValue = piInspectable.as<winrt::Windows::Foundation::IPropertyValue>();
WINRT_ASSERT(piPropertyValue.Type() == winrt::Windows::Foundation::PropertyType::Single);
```

## <a name="important-apis"></a><span data-ttu-id="6f58c-126">重要な API</span><span class="sxs-lookup"><span data-stu-id="6f58c-126">Important APIs</span></span>
* [<span data-ttu-id="6f58c-127">IInspectable インターフェイス</span><span class="sxs-lookup"><span data-stu-id="6f58c-127">IInspectable interface</span></span>](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)
* [<span data-ttu-id="6f58c-128">winrt::box_value 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="6f58c-128">winrt::box_value function template</span></span>](/uwp/cpp-ref-for-winrt/box-value)
* [<span data-ttu-id="6f58c-129">winrt::hstring 構造体</span><span class="sxs-lookup"><span data-stu-id="6f58c-129">winrt::hstring struct</span></span>](/uwp/cpp-ref-for-winrt/hstring)
* [<span data-ttu-id="6f58c-130">winrt::unbox_value 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="6f58c-130">winrt::unbox_value function template</span></span>](/uwp/cpp-ref-for-winrt/unbox-value)
* [<span data-ttu-id="6f58c-131">winrt::unbox_value_or 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="6f58c-131">winrt::unbox_value_or function template</span></span>](/uwp/cpp-ref-for-winrt/unbox-value-or)
