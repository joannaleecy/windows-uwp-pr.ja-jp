---
author: stevewhims
description: With C++/WinRT では、標準的な C++ ワイド文字列型を使用して Windows ランタイム API を呼び出すか、または winrt::hstring 型を使用することができます。
title: C++/WinRT での文字列の処理
ms.author: stwhi
ms.date: 10/03/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、文字列
ms.localizationpriority: medium
ms.openlocfilehash: 72032c3c522a8434d266842a83c443889e8efc19
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7169998"
---
# <a name="string-handling-in-cwinrt"></a><span data-ttu-id="35210-104">C++/WinRT での文字列の処理</span><span class="sxs-lookup"><span data-stu-id="35210-104">String handling in C++/WinRT</span></span>

<span data-ttu-id="35210-105">[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、 **std::wstring**などの C++ 標準ライブラリのワイド文字列型を使用して Windows ランタイム Api を呼び出すことができます (注: **:string**などの幅の狭い文字列型ではなく)。</span><span class="sxs-lookup"><span data-stu-id="35210-105">With [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), you can call Windows Runtime APIs using C++ Standard Library wide string types such as **std::wstring** (note: not with narrow string types such as **std::string**).</span></span> <span data-ttu-id="35210-106">C++/WinRT には [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) というカスタム文字列型があります (C++/WinRT 基本ライブラリ、`%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h` で定義)。</span><span class="sxs-lookup"><span data-stu-id="35210-106">C++/WinRT does have a custom string type called [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) (defined in the C++/WinRT base library, which is `%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h`).</span></span> <span data-ttu-id="35210-107">これは、Windows ランタイムのコンストラクター、関数、およびプロパティで実際に受け取られ、返される文字列型です。</span><span class="sxs-lookup"><span data-stu-id="35210-107">And that's the string type that Windows Runtime constructors, functions, and properties actually take and return.</span></span> <span data-ttu-id="35210-108">ただし、多くの場合、**hstring** の変換コンストラクターと変換演算子のおかげで、クライアント コードで **hstring** を認識するかどうかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="35210-108">But in many cases&mdash;thanks to **hstring**'s conversion constructors and conversion operators&mdash;you can choose whether or not to be aware of **hstring** in your client code.</span></span> <span data-ttu-id="35210-109">API を*作成している*場合は、**hstring** を理解しておく必要性が高くなると思われます。</span><span class="sxs-lookup"><span data-stu-id="35210-109">If you're *authoring* APIs, then you're more likely to need to know about **hstring**.</span></span>

<span data-ttu-id="35210-110">C++ には多くの文字列型があります。</span><span class="sxs-lookup"><span data-stu-id="35210-110">There are many string types in C++.</span></span> <span data-ttu-id="35210-111">C++ 標準ライブラリの **std::basic_string** に加えて、多くのライブラリにバリアントが存在します。</span><span class="sxs-lookup"><span data-stu-id="35210-111">Variants exist in many libraries in addition to **std::basic_string** from the C++ Standard Library.</span></span> <span data-ttu-id="35210-112">C++17 には、すべての文字列型間のギャップの橋渡しをする文字列変換ユーティリティと **std::basic_string_view** があります。</span><span class="sxs-lookup"><span data-stu-id="35210-112">C++17 has string conversion utilities, and **std::basic_string_view**, to bridge the gaps between all of the string types.</span></span>  <span data-ttu-id="35210-113">[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) は **std::wstring_view** と互換性があり、**std::basic_string_view** の設計目的である相互運用性が提供されます。</span><span class="sxs-lookup"><span data-stu-id="35210-113">[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) provides convertibility with **std::wstring_view** to provide the interoperability that **std::basic_string_view** was designed for.</span></span>

## <a name="using-stdwstring-and-optionally-winrthstring-with-uri"></a><span data-ttu-id="35210-114">Uri での **std::wstring** (および必要に応じて \*\*\*\*winrt::hstring\*\*\*\*) の使用</span><span class="sxs-lookup"><span data-stu-id="35210-114">Using **std::wstring** (and optionally **winrt::hstring**) with **Uri**</span></span>
<span data-ttu-id="35210-115">[**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) は [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) から作成されます。</span><span class="sxs-lookup"><span data-stu-id="35210-115">[**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) is constructed from a [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring).</span></span>

```cppwinrt
public:
    Uri(winrt::hstring uri) const;
```

<span data-ttu-id="35210-116">ただし、**hstring** には[変換コンストラクター](/uwp/api/windows.foundation.uri#hstringhstring-constructor)があるため、それを意識せずに操作することができます。</span><span class="sxs-lookup"><span data-stu-id="35210-116">But **hstring** has [conversion constructors](/uwp/api/windows.foundation.uri#hstringhstring-constructor) that let you work with it without needing to be aware of it.</span></span> <span data-ttu-id="35210-117">次のコード例で、ワイド文字列リテラル、ワイド文字列ビュー、および **std::wstring** から **Uri** を作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="35210-117">Here's a code example showing how to make a **Uri** from a wide string literal, from a wide string view, and from a **std::wstring**.</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <string_view>

using namespace winrt;
using namespace Windows::Foundation;

int main()
{
    using namespace std::literals;

    winrt::init_apartment();

    // You can make a Uri from a wide string literal.
    Uri contosoUri{ L"http://www.contoso.com" };

    // Or from a wide string view.
    Uri contosoSVUri{ L"http://www.contoso.com"sv };

    // Or from a std::wstring.
    std::wstring wideString{ L"http://www.adventure-works.com" };
    Uri awUri{ wideString };
}
```

<span data-ttu-id="35210-118">プロパティ アクセサー [**Uri::Domain**](https://docs.microsoft.com/uwp/api/windows.foundation.uri.Domain) の型は **hstring** です。</span><span class="sxs-lookup"><span data-stu-id="35210-118">The property accessor [**Uri::Domain**](https://docs.microsoft.com/uwp/api/windows.foundation.uri.Domain) is of type **hstring**.</span></span>

```cppwinrt
public:
    winrt::hstring Domain();
```

<span data-ttu-id="35210-119">ただし、この場合も、**hstring** の [**std::wstring_view への変換演算子**](/uwp/api/hstring#hstringoperator-stdwstringview)のおかげで、その詳細を認識するかどうかは任意です。</span><span class="sxs-lookup"><span data-stu-id="35210-119">But, again, being aware of that detail is optional thanks to **hstring**'s [conversion operator to **std::wstring_view**](/uwp/api/hstring#hstringoperator-stdwstringview).</span></span>

```cppwinrt
// Access a property of type hstring, via a conversion operator to a standard type.
std::wstring domainWstring{ contosoUri.Domain() }; // L"contoso.com"
domainWstring = awUri.Domain(); // L"adventure-works.com"

// Or, you can choose to keep the hstring unconverted.
hstring domainHstring{ contosoUri.Domain() }; // L"contoso.com"
domainHstring = awUri.Domain(); // L"adventure-works.com"
```

<span data-ttu-id="35210-120">同様に、[**IStringable::ToString**](https://msdn.microsoft.com/library/windows/desktop/dn302136) は hstring を返します。</span><span class="sxs-lookup"><span data-stu-id="35210-120">Similarly, [**IStringable::ToString**](https://msdn.microsoft.com/library/windows/desktop/dn302136) returns hstring.</span></span>

```cppwinrt
public:
    hstring ToString() const;
```

<span data-ttu-id="35210-121">**Uri** は [**IStringable**](https://msdn.microsoft.com/library/windows/desktop/dn302135) インターフェイスを実装しています。</span><span class="sxs-lookup"><span data-stu-id="35210-121">**Uri** implements the [**IStringable**](https://msdn.microsoft.com/library/windows/desktop/dn302135) interface.</span></span>

```cppwinrt
// Access hstring's IStringable::ToString, via a conversion operator to a standard type.
std::wstring tostringWstring{ contosoUri.ToString() }; // L"http://www.contoso.com/"
tostringWstring = awUri.ToString(); // L"http://www.adventure-works.com/"

// Or you can choose to keep the hstring unconverted.
hstring tostringHstring{ contosoUri.ToString() }; // L"http://www.contoso.com/"
tostringHstring = awUri.ToString(); // L"http://www.adventure-works.com/"
```

<span data-ttu-id="35210-122">[**hstring::c_str 関数**](/uwp/api/windows.foundation.uri#hstringcstr-function)を使用して、**hstring** から標準ワイド文字列を取得することができます (**std::wstring** から取得する場合と同様)。</span><span class="sxs-lookup"><span data-stu-id="35210-122">You can use the [**hstring::c_str function**](/uwp/api/windows.foundation.uri#hstringcstr-function) to get a standard wide string from an **hstring** (just as you can from a **std::wstring**).</span></span>

```cppwinrt
#include <iostream>
std::wcout << tostringHstring.c_str() << std::endl;
```
<span data-ttu-id="35210-123">**hstring** がある場合、そこから **Uri** を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="35210-123">If you have an **hstring** then you can make a **Uri** from it.</span></span>

```cppwinrt
Uri awUriFromHstring{ tostringHstring };
```

<span data-ttu-id="35210-124">**hstring** を受け取るメソッドを考えてみます。</span><span class="sxs-lookup"><span data-stu-id="35210-124">Consider a method that takes an **hstring**.</span></span>

```cppwinrt
public:
    Uri CombineUri(winrt::hstring relativeUri) const;
```

<span data-ttu-id="35210-125">そのような場合にも、前述したすべてのオプションが適用されます。</span><span class="sxs-lookup"><span data-stu-id="35210-125">All of the options you've just seen also apply in such cases.</span></span>

```cppwinrt
std::wstring contact{ L"contact" };
contosoUri = contosoUri.CombineUri(contact);
    
std::wcout << contosoUri.ToString().c_str() << std::endl;
```

<span data-ttu-id="35210-126">**hstring** は、メンバー **std::wstring_view** という変換演算子を持っており、コストを伴わずに変換が実行されます。</span><span class="sxs-lookup"><span data-stu-id="35210-126">**hstring** has a member **std::wstring_view** conversion operator, and the conversion is achieved at no cost.</span></span>

```cppwinrt
void legacy_print(std::wstring_view view);

void Print(winrt::hstring const& hstring)
{
    legacy_print(hstring);
}
```

## <a name="winrthstring-functions-and-operators"></a><span data-ttu-id="35210-127">**winrt::hstring** の関数と演算子</span><span class="sxs-lookup"><span data-stu-id="35210-127">**winrt::hstring** functions and operators</span></span>
<span data-ttu-id="35210-128">コンストラクター、演算子、関数、および反復子のホストが [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) に対して実装されています。</span><span class="sxs-lookup"><span data-stu-id="35210-128">A host of constructors, operators, functions, and iterators are implemented for  [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring).</span></span>

<span data-ttu-id="35210-129">**hstring** は範囲であるため、範囲ベースの `for`、または `std::for_each` で使用できます。</span><span class="sxs-lookup"><span data-stu-id="35210-129">An **hstring** is a range, so you can use it with range-based `for`, or with `std::for_each`.</span></span> <span data-ttu-id="35210-130">C++ 標準ライブラリ内の対応部分と自然かつ効率的に比較するための比較演算子も提供されます。</span><span class="sxs-lookup"><span data-stu-id="35210-130">It also provides comparison operators for naturally and efficiently comparing against its counterparts in the C++ Standard Library.</span></span> <span data-ttu-id="35210-131">また、関連コンテナーのキーとして **hstring** を使用するために必要なものがすべて含まれています。</span><span class="sxs-lookup"><span data-stu-id="35210-131">And it includes everything you need to use **hstring** as a key for associative containers.</span></span>

<span data-ttu-id="35210-132">多くの C++ ライブラリが **std::string** を使用し、UTF-8 テキストでのみ動作することは認識されています。</span><span class="sxs-lookup"><span data-stu-id="35210-132">We recognize that many C++ libraries use **std::string**, and work exclusively with UTF-8 text.</span></span> <span data-ttu-id="35210-133">利便性を考慮して、双方向に変換するための [**winrt::to_string**](/uwp/cpp-ref-for-winrt/to-string) や [**winrt::to_hstring**](/uwp/cpp-ref-for-winrt/to-hstring) などのヘルパーが提供されています。</span><span class="sxs-lookup"><span data-stu-id="35210-133">As a convenience, we provide helpers, such as [**winrt::to_string**](/uwp/cpp-ref-for-winrt/to-string) and [**winrt::to_hstring**](/uwp/cpp-ref-for-winrt/to-hstring), for converting back and forth.</span></span>

```cppwinrt
winrt::hstring w{ L"Hello, World!" };

std::string c = winrt::to_string(w);
WINRT_ASSERT(c == "Hello, World!");

w = winrt::to_hstring(c);
WINRT_ASSERT(w == L"Hello, World!");
```

<span data-ttu-id="35210-134">**hstring** の関数および演算子のその他の例および詳細については、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) API リファレンス トピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="35210-134">For more examples and info about **hstring** functions and operators, see the [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) API reference topic.</span></span>

## <a name="the-rationale-for-winrthstring-and-winrtparamhstring"></a><span data-ttu-id="35210-135">**winrt::hstring** および **winrt::param::hstring** の原理</span><span class="sxs-lookup"><span data-stu-id="35210-135">The rationale for **winrt::hstring** and **winrt::param::hstring**</span></span>
<span data-ttu-id="35210-136">Windows ランタイムは **wchar_t** 文字によって実装されていますが、Windows ランタイムのアプリケーション バイナリ インターフェイス (ABI) は **std::wstring** や **std::wstring_view** が提供するもののサブセットではありません。</span><span class="sxs-lookup"><span data-stu-id="35210-136">The Windows Runtime is implemented in terms of **wchar_t** characters, but the Windows Runtime's Application Binary Interface (ABI) is not a subset of what either **std::wstring** or **std::wstring_view** provide.</span></span> <span data-ttu-id="35210-137">これらを使用すると、効率が大幅に低下します。</span><span class="sxs-lookup"><span data-stu-id="35210-137">Using those would lead to significant inefficiency.</span></span> <span data-ttu-id="35210-138">代わりに、C++/WinRT は **winrt::hstring** を提供します。これは、基礎となる [HSTRING](https://msdn.microsoft.com/library/windows/desktop/br205775) と互換性がある不変文字列を表し、**std::wstring** の場合と同様にインターフェイスの背後に実装されています。</span><span class="sxs-lookup"><span data-stu-id="35210-138">Instead, C++/WinRT provides **winrt::hstring**, which represents an immutable string consistent with the underlying [HSTRING](https://msdn.microsoft.com/library/windows/desktop/br205775), and implemented behind an interface similar to that of **std::wstring**.</span></span> 

<span data-ttu-id="35210-139">論理的に **winrt::hstring** を受け入れるはずの C++/WinRT 入力パラメーターが、実際には **winrt::param::hstring** を予期している場合があります。</span><span class="sxs-lookup"><span data-stu-id="35210-139">You may notice that C++/WinRT input parameters that should logically accept **winrt::hstring** actually expect **winrt::param::hstring**.</span></span> <span data-ttu-id="35210-140">**param** 名前空間には、自然に C++ 標準ライブラリにバインドしてコピーやその他の非効率性を回避するために、入力パラメーターの最適化にのみ使用される一連の型が含まれています。</span><span class="sxs-lookup"><span data-stu-id="35210-140">The **param** namespace contains a set of types used exclusively to optimize input parameters to naturally bind to C++ Standard Library types and avoid copies and other inefficiencies.</span></span> <span data-ttu-id="35210-141">これらの型は直接使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="35210-141">You shouldn't use these types directly.</span></span> <span data-ttu-id="35210-142">独自の関数で最適化を使用する場合は、**std::wstring_view** を使用します。</span><span class="sxs-lookup"><span data-stu-id="35210-142">If you want to use an optimization for your own functions then use **std::wstring_view**.</span></span>

<span data-ttu-id="35210-143">重要なことは、Windows ランタイムの文字列管理の詳細はほとんど無視して、自分が理解していることを効率的に操作することができるということです。</span><span class="sxs-lookup"><span data-stu-id="35210-143">The upshot is that you can largely ignore the specifics of Windows Runtime string management, and just work with efficiency with what you know.</span></span> <span data-ttu-id="35210-144">また、これは Windows ランタイムで文字列を大量に使用する場合は重要になります。</span><span class="sxs-lookup"><span data-stu-id="35210-144">And that's important, given how heavily strings are used in the Windows Runtime.</span></span>

# <a name="formatting-strings"></a><span data-ttu-id="35210-145">文字列の書式設定</span><span class="sxs-lookup"><span data-stu-id="35210-145">Formatting strings</span></span>
<span data-ttu-id="35210-146">文字列の書式設定のための 1 つのオプションは **std::wstringstream** です。</span><span class="sxs-lookup"><span data-stu-id="35210-146">One option for string-formatting is **std::wstringstream**.</span></span> <span data-ttu-id="35210-147">次の例では、単純なデバッグ トレース メッセージを書式設定して表示します。</span><span class="sxs-lookup"><span data-stu-id="35210-147">Here's an example that formats and displays a simple debug trace message.</span></span>

```cppwinrt
#include <sstream>
...
void OnPointerPressed(IInspectable const&, PointerEventArgs const& args)
{
    float2 const point = args.CurrentPoint().Position();
    std::wstringstream wstringstream;
    wstringstream << L"Pointer pressed at (" << point.x << L"," << point.y << L")" << std::endl;
    ::OutputDebugString(wstringstream.str().c_str());
}
```

## <a name="important-apis"></a><span data-ttu-id="35210-148">重要な API</span><span class="sxs-lookup"><span data-stu-id="35210-148">Important APIs</span></span>
* [<span data-ttu-id="35210-149">winrt::hstring 構造体</span><span class="sxs-lookup"><span data-stu-id="35210-149">winrt::hstring struct</span></span>](/uwp/cpp-ref-for-winrt/hstring)
* [<span data-ttu-id="35210-150">winrt::to_hstring 関数</span><span class="sxs-lookup"><span data-stu-id="35210-150">winrt::to_hstring function</span></span>](/uwp/cpp-ref-for-winrt/to-hstring)
* [<span data-ttu-id="35210-151">winrt::to_string 関数</span><span class="sxs-lookup"><span data-stu-id="35210-151">winrt::to_string function</span></span>](/uwp/cpp-ref-for-winrt/to-string)
