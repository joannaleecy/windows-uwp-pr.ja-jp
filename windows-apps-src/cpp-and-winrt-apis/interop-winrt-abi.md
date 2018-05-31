---
author: stevewhims
description: このトピックでは、アプリケーション バイナリ インターフェイス (ABI) と C++/WinRT オブジェクト間の変換方法について説明します。
title: C++/WinRT と ABI 間の相互運用
ms.author: stwhi
ms.date: 05/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、ポート、移行、相互運用、ABI
ms.localizationpriority: medium
ms.openlocfilehash: 84f9f557134e69c396ed63ace3474325856c6cd0
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832046"
---
# <a name="interop-between-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-and-the-abi"></a><span data-ttu-id="f86f0-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) と ABI 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="f86f0-104">Interop between [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) and the ABI</span></span>
<span data-ttu-id="f86f0-105">このトピックでは、アプリケーション バイナリ インターフェイス (ABI) と C++/WinRT オブジェクト間の変換方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-105">This topic shows how to convert between application binary interface (ABI) and C++/WinRT objects.</span></span> <span data-ttu-id="f86f0-106">これらの手法を使用すると、Windows ランタイムでこれら 2 つの手法によるプログラミングを使用するコード間を相互運用するか、ABI から C++/WinRT にコードを徐々に移動することができます。</span><span class="sxs-lookup"><span data-stu-id="f86f0-106">You can use these techniques to interop between code that uses these two ways of programming with the Windows Runtime, or you can use them as you gradually move your code from the ABI to C++/WinRT.</span></span>

## <a name="what-are-windows-runtime-abi-types"></a><span data-ttu-id="f86f0-107">Windows ランタイム ABI の型とは</span><span class="sxs-lookup"><span data-stu-id="f86f0-107">What are Windows Runtime ABI types?</span></span>
<span data-ttu-id="f86f0-108">フォルダー "%WindowsSdkDir%Include\10.0.17134.0\winrt" (必要に応じて、状況に合った SDK バージョン番号に調整) 内の Windows SDK ヘッダーは、Windows ランタイム ABI ヘッダー ファイルです。</span><span class="sxs-lookup"><span data-stu-id="f86f0-108">The Windows SDK headers in the folder "%WindowsSdkDir%Include\10.0.17134.0\winrt" (adjust the SDK version number for your case, if necessary), are the Windows Runtime ABI header files.</span></span> <span data-ttu-id="f86f0-109">このヘッダーは MIDL コンパイラによって生成されます。</span><span class="sxs-lookup"><span data-stu-id="f86f0-109">They were produced by the MIDL compiler.</span></span> <span data-ttu-id="f86f0-110">次のいずれかのヘッダーを含む例を示します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-110">Here's an example of including one of these headers.</span></span>

```
#include <windows.foundation.h>
```

<span data-ttu-id="f86f0-111">次に、特定のヘッダー内にあるいずれかの ABI 型の例を簡単に示します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-111">And here's a simplified example of one of the ABI types that you'll find in that particular header.</span></span>

```
namespace ABI::Windows::Foundation
{
    IUriRuntimeClass : public IInspectable
    {
    public:
        /* [propget] */ virtual HRESULT STDMETHODCALLTYPE get_AbsoluteUri(/* [retval, out] */__RPC__deref_out_opt HSTRING * value) = 0;
        ...
    }
}
```

<span data-ttu-id="f86f0-112">**IUriRuntimeClass** は COM インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="f86f0-112">**IUriRuntimeClass** is a COM interface.</span></span> <span data-ttu-id="f86f0-113">ただしそれ以上に、ベースは **IInspectable** のため、**IUriRuntimeClass** は Windows ランタイム インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="f86f0-113">But more than that&mdash;since its base is **IInspectable**&mdash;**IUriRuntimeClass** is a Windows Runtime interface.</span></span> <span data-ttu-id="f86f0-114">**HRESULT** は例外よりも型を返します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-114">Note the **HRESULT** return type, rather than the raising of exceptions.</span></span> <span data-ttu-id="f86f0-115">**HSTRING** ハンドルなどのアーティファクトを使用します (完了したら、このハンドルを `nullptr` に戻すように設定することをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="f86f0-115">And the use of artifacts such as the **HSTRING** handle (it's good practice to set that handle back to `nullptr` when you're finished with it).</span></span> <span data-ttu-id="f86f0-116">これにより、アプリケーション バイナリ レベル、つまり、COM プログラミング レベルで Windows ランタイムの内容を把握できます。</span><span class="sxs-lookup"><span data-stu-id="f86f0-116">This gives a taste of what the Windows Runtime looks like at the application binary level; in other words, at the COM programming level.</span></span>

<span data-ttu-id="f86f0-117">Windows ランタイムはコンポーネント オブジェクト モデル (COM) API に基づいています。</span><span class="sxs-lookup"><span data-stu-id="f86f0-117">The Windows Runtime is based on Component Object Model (COM) APIs.</span></span> <span data-ttu-id="f86f0-118">この方法で Windows ランタイムにアクセスするか、*言語プロジェクション*を介してアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="f86f0-118">You can access the Windows Runtime that way, or you can access it through *language projections*.</span></span> <span data-ttu-id="f86f0-119">プロジェクションは、COM の詳細を隠し、特定の言語により自然なプログラミング エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-119">A projection hides the COM details, and provides a more natural programming experience for a given language.</span></span>

<span data-ttu-id="f86f0-120">たとえば、フォルダー "%WindowsSdkDir%Include\10.0.17134.0\cppwinrt\winrt" 内を見ると (必要に応じて、状況に合った SDK バージョン番号に調整)、C++/WinRT 言語プロジェクション ヘッダーがあります。</span><span class="sxs-lookup"><span data-stu-id="f86f0-120">For example, if you look in the folder "%WindowsSdkDir%Include\10.0.17134.0\cppwinrt\winrt" (again, adjust the SDK version number for your case, if necessary), then you'll find the C++/WinRT language projection headers.</span></span> <span data-ttu-id="f86f0-121">Windows 名前空間ごとに 1 つの ABI ヘッダーがあるように、Windows 名前空間それぞれにヘッダーがあります。</span><span class="sxs-lookup"><span data-stu-id="f86f0-121">There's a header for each Windows namespace, just like there's one ABI header per Windows namespace.</span></span> <span data-ttu-id="f86f0-122">次に、いずれかの C++/WinRT ヘッダーを含む例を示します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-122">Here's an example of including one of the C++/WinRT headers.</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.h>
```

<span data-ttu-id="f86f0-123">このヘッダーから、上記の ABI 型に相当する C++/WinRT を簡略化して次に示します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-123">And, from that header, here (simplified) is the C++/WinRT equivalent of that ABI type we just saw.</span></span>

```
namespace winrt::Windows::Foundation
{
    struct Uri : IUriRuntimeClass, ...
    {
        winrt::hstring AbsoluteUri() const { ... }
        ...
    };
}
```

<span data-ttu-id="f86f0-124">このインターフェイスは最新の標準的な C++ です。</span><span class="sxs-lookup"><span data-stu-id="f86f0-124">The interface here is modern, standard C++.</span></span> <span data-ttu-id="f86f0-125">**HRESULT** は削除されています (必要に応じて、C++/WinRT では例外が発生します)。</span><span class="sxs-lookup"><span data-stu-id="f86f0-125">It does away with **HRESULT**s (C++/WinRT raises exceptions if necessary).</span></span> <span data-ttu-id="f86f0-126">アクセサー関数は簡単な文字列オブジェクトを返します。このオブジェクトはその範囲の最後でクリーンアップされます。</span><span class="sxs-lookup"><span data-stu-id="f86f0-126">And the accessor function returns a simple string object, which is cleaned up at the end of its scope.</span></span>

## <a name="converting-to-and-from-abi-types-in-code"></a><span data-ttu-id="f86f0-127">コード内での ABI 型の変換</span><span class="sxs-lookup"><span data-stu-id="f86f0-127">Converting to and from ABI types in code</span></span>
<span data-ttu-id="f86f0-128">安全で分かりやすくするため、双方向の変換の場合は、[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)、[**com_ptr::as**](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function)、および [**winrt::Windows::Foundation::IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) のみを使用します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-128">For safety and simplicity, for conversions in both directions you can simply use [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr), [**com_ptr::as**](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function), and [**winrt::Windows::Foundation::IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function).</span></span> <span data-ttu-id="f86f0-129">次に、コード例を示します (**コンソール アプリ** プロジェクト テンプレートに基づいて)。また、プロジェクションと ABI 間の名前空間の競合を処理する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-129">Here's a code example (based on the **Console App** project template), which also illustrates how you can deal with namespace collisions between the projection and the ABI.</span></span>

```cppwinrt
// main.cpp
#include "pch.h"

#include <windows.foundation.h>
#include <winrt/Windows.Foundation.h>

namespace winrt
{
    using namespace Windows::Foundation;
}

namespace abi
{
    using namespace ABI::Windows::Foundation;
};

int main()
{
    winrt::init_apartment();
    
    winrt::Uri uri(L"http://aka.ms/cppwinrt");

    // Convert to an ABI type.
    winrt::com_ptr<abi::IStringable> ptr = uri.as<abi::IStringable>();

    // Convert from an ABI type.
    uri = ptr.as<winrt::Uri>();
    winrt::IStringable uriAsIStringable = ptr.as<winrt::IStringable>();
}
```

<span data-ttu-id="f86f0-130">**as** 関数を実装すると、[**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="f86f0-130">The implementations of the **as** functions call [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521).</span></span> <span data-ttu-id="f86f0-131">[**AddRef**](https://msdn.microsoft.com/library/windows/desktop/ms691379) のみを呼び出す下位レベルの変換を行う場合は、[**winrt::copy_to_abi**](/uwp/cpp-ref-for-winrt/copy-to-abi) と [**winrt::copy_from_abi**](/uwp/cpp-ref-for-winrt/copy-from-abi) のヘルパー関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f86f0-131">If you want lower-level conversions that only call [**AddRef**](https://msdn.microsoft.com/library/windows/desktop/ms691379), then you can use the [**winrt::copy_to_abi**](/uwp/cpp-ref-for-winrt/copy-to-abi) and [**winrt::copy_from_abi**](/uwp/cpp-ref-for-winrt/copy-from-abi) helper functions.</span></span> <span data-ttu-id="f86f0-132">次に、この下位レベル変換を上記のコード例に追加するコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-132">This next code example adds these lower-level conversions to the code example above.</span></span>

```cppwinrt
int main()
{
    ...

    // Lower-level conversions that only call AddRef.

    // Convert to an ABI type.
    ptr = nullptr;
    winrt::copy_to_abi(uri, *ptr.put_void());

    // Convert from an ABI type.
    uri = nullptr;
    winrt::copy_from_abi(uri, ptr.get());
    ptr = nullptr;
}
```

<span data-ttu-id="f86f0-133">次に、他の同様の下位レベルの変換手法を示しますが、ここでは ABI インターフェイスの型 (Windows SDK ヘッダーで定義されている型) に生のポインターを使用しています。</span><span class="sxs-lookup"><span data-stu-id="f86f0-133">Here are other similarly low-level conversions techniques but using raw pointers to ABI interface types (those defined by the Windows SDK headers) this time.</span></span>

```cppwinrt
    ...
    
    // Copy to an owning raw ABI pointer with copy_to_abi.
    abi::IStringable* owning = nullptr;
    winrt::copy_to_abi(uri, *reinterpret_cast<void**>(&owning));
    
    // Copy from a raw ABI pointer.
    uri = nullptr;
    winrt::copy_from_abi(uri, owning);
    owning->Release();
```

<span data-ttu-id="f86f0-134">下位レベルの変換の場合、アドレスをコピーするだけで、[**winrt::get_abi**](/uwp/cpp-ref-for-winrt/get-abi)、[**winrt::detach_abi**](/uwp/cpp-ref-for-winrt/detach-abi)、[**winrt::attach_abi**](/uwp/cpp-ref-for-winrt/attach-abi) の各ヘルパー関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f86f0-134">For the lowest-level conversions, which only copy addresses, you can use the [**winrt::get_abi**](/uwp/cpp-ref-for-winrt/get-abi), [**winrt::detach_abi**](/uwp/cpp-ref-for-winrt/detach-abi), and [**winrt::attach_abi**](/uwp/cpp-ref-for-winrt/attach-abi) helper functions.</span></span>

```cppwinrt
    ...
    
    // Lowest-level conversions that only copy addresses
    
    // Convert to a non-owning ABI object with get_abi.
    abi::IStringable* non_owning = static_cast<abi::IStringable*>(winrt::get_abi(uri));
    WINRT_ASSERT(non_owning);
    
    // Avoid interlocks this way.
    owning = static_cast<abi::IStringable*>(winrt::detach_abi(uri));
    WINRT_ASSERT(!uri);
    winrt::attach_abi(uri, owning);
    WINRT_ASSERT(uri);
```

## <a name="convertfromabi-function"></a><span data-ttu-id="f86f0-135">convert_from_abi 関数</span><span class="sxs-lookup"><span data-stu-id="f86f0-135">convert_from_abi function</span></span>
<span data-ttu-id="f86f0-136">このヘルパー関数では、最小限のオーバーヘッドで生の ABI インターフェイス ポインターを同等の C++/WinRT オブジェクトに変換します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-136">This helper function converts a raw ABI interface pointer to an equivalent C++/WinRT object, with minimal overhead.</span></span>

```cppwinrt
template <typename T>
T convert_from_abi(::IUnknown* from)
{
    T to{ nullptr };

    winrt::check_hresult(from->QueryInterface(winrt::guid_of<T>(),
        reinterpret_cast<void**>(winrt::put_abi(to))));

    return to;
}
```

<span data-ttu-id="f86f0-137">この関数は、[**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) を呼び出し、要求された C++/WinRT 型の既定のインターフェイスを照会するだけです。</span><span class="sxs-lookup"><span data-stu-id="f86f0-137">The function simply calls [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) to query for the default interface of the requested C++/WinRT type.</span></span>

<span data-ttu-id="f86f0-138">既に説明したように、C++/WinRT オブジェクトから同等の ABI インターフェイス ポインターへの変換には、ヘルパー関数は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="f86f0-138">As we've seen, a helper function is not required to convert from a C++/WinRT object to the equivalent ABI interface pointer.</span></span> <span data-ttu-id="f86f0-139">[**winrt::Windows::Foundation::IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) (または [**try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)) メンバー関数を使用して、要求されたインターフェイスを照会するだけです。</span><span class="sxs-lookup"><span data-stu-id="f86f0-139">Simply use the [**winrt::Windows::Foundation::IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) (or [**try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)) member function to query for the requested interface.</span></span> <span data-ttu-id="f86f0-140">**as** 関数と **try_as** 関数は、要求された ABI 型をラップする [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-140">The **as** and **try_as** functions return a [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) object wrapping the requested ABI type.</span></span>

## <a name="code-example-using-convertfromabi"></a><span data-ttu-id="f86f0-141">convert_from_abi を使用したコード例</span><span class="sxs-lookup"><span data-stu-id="f86f0-141">Code example using convert_from_abi</span></span>
<span data-ttu-id="f86f0-142">次に、このヘルパー関数を表す実践的なコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="f86f0-142">Here's a code example showing this helper function in practice.</span></span>

```cppwinrt
// main.cpp
#include "pch.h"

#include <windows.foundation.h>
#include <winrt/Windows.Foundation.h>
#include <iostream>

using namespace winrt;
using namespace Windows::Foundation;

namespace winrt
{
    using namespace Windows::Foundation;
}

namespace abi
{
    using namespace ABI::Windows::Foundation;
};

template <typename T>
T convert_from_abi(::IUnknown* from)
{
    T to{ nullptr };

    winrt::check_hresult(from->QueryInterface(winrt::guid_of<T>(),
        reinterpret_cast<void**>(winrt::put_abi(to))));

    return to;
}

int main()
{
    winrt::init_apartment();

    winrt::Uri uri(L"http://aka.ms/cppwinrt");
    std::wcout << "C++/WinRT: " << uri.Domain().c_str() << std::endl;

    // Convert to an ABI type.
    winrt::com_ptr<abi::IUriRuntimeClass> ptr = uri.as<abi::IUriRuntimeClass>();
    winrt::hstring domain;
    winrt::check_hresult(ptr->get_Domain(put_abi(domain)));
    std::wcout << "ABI: " << domain.c_str() << std::endl;

    // Convert from an ABI type.
    winrt::Uri uri_from_abi = convert_from_abi<winrt::Uri>(ptr.get());

    WINRT_ASSERT(uri.Domain() == uri_from_abi.Domain());
    WINRT_ASSERT(uri == uri_from_abi);
}
```

## <a name="important-apis"></a><span data-ttu-id="f86f0-143">重要な API</span><span class="sxs-lookup"><span data-stu-id="f86f0-143">Important APIs</span></span>
* [<span data-ttu-id="f86f0-144">AddRef</span><span class="sxs-lookup"><span data-stu-id="f86f0-144">AddRef</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms691379)
* [<span data-ttu-id="f86f0-145">QueryInterface</span><span class="sxs-lookup"><span data-stu-id="f86f0-145">QueryInterface</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms682521)
* [<span data-ttu-id="f86f0-146">winrt::attach_abi</span><span class="sxs-lookup"><span data-stu-id="f86f0-146">winrt::attach_abi</span></span>](/uwp/cpp-ref-for-winrt/attach-abi)
* [<span data-ttu-id="f86f0-147">winrt::com_ptr 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="f86f0-147">winrt::com_ptr struct template</span></span>](/uwp/cpp-ref-for-winrt/com-ptr)
* [<span data-ttu-id="f86f0-148">winrt::copy_from_abi</span><span class="sxs-lookup"><span data-stu-id="f86f0-148">winrt::copy_from_abi</span></span>](/uwp/cpp-ref-for-winrt/copy-from-abi)
* [<span data-ttu-id="f86f0-149">winrt::copy_to_abi</span><span class="sxs-lookup"><span data-stu-id="f86f0-149">winrt::copy_to_abi</span></span>](/uwp/cpp-ref-for-winrt/copy-to-abi)
* [<span data-ttu-id="f86f0-150">winrt::detach_abi</span><span class="sxs-lookup"><span data-stu-id="f86f0-150">winrt::detach_abi</span></span>](/uwp/cpp-ref-for-winrt/detach-abi)
* [<span data-ttu-id="f86f0-151">winrt::get_abi</span><span class="sxs-lookup"><span data-stu-id="f86f0-151">winrt::get_abi</span></span>](/uwp/cpp-ref-for-winrt/get-abi)
* [<span data-ttu-id="f86f0-152">winrt::Windows::Foundation::IUnknown::as メンバー関数</span><span class="sxs-lookup"><span data-stu-id="f86f0-152">winrt::Windows::Foundation::IUnknown::as member function</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)
* [<span data-ttu-id="f86f0-153">winrt::Windows::Foundation::IUnknown::try_as メンバー関数</span><span class="sxs-lookup"><span data-stu-id="f86f0-153">winrt::Windows::Foundation::IUnknown::try_as member function</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)
