---
author: stevewhims
description: このトピックでは、C++/CX と C++/WinRT オブジェクト間の変換に使用できる 2 つのヘルパー関数について説明します。
title: C++/WinRT と C++/CX 間の相互運用
ms.author: stwhi
ms.date: 05/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、ポート、移行、相互運用、C++/CX
ms.localizationpriority: medium
ms.openlocfilehash: d265189c338d95a8c8f206fd196e99d5b0a1e068
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4155453"
---
# <a name="interop-between-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-and-ccx"></a><span data-ttu-id="34998-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) と C++/CX 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="34998-104">Interop between [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) and C++/CX</span></span>
<span data-ttu-id="34998-105">このトピックでは、[C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live) と C++/WinRT オブジェクト間の変換に使用できる 2 つのヘルパー関数について説明します。</span><span class="sxs-lookup"><span data-stu-id="34998-105">This topic shows two helper functions that can be used to convert between [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live) and C++/WinRT objects.</span></span> <span data-ttu-id="34998-106">それらを使用するには、2 つの言語プロジェクションを使用するコード間で相互運用機能または関数を使用するには、C + からコードを徐々 に移動するよう/CX を C++/WinRT (を参照してください[C + への移行/C + から WinRT/CX](move-to-winrt-from-cx.md))。</span><span class="sxs-lookup"><span data-stu-id="34998-106">You can use them to interop between code that uses the two language projections, or you can use the functions as you gradually move your code from C++/CX to C++/WinRT (see [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md)).</span></span>

## <a name="fromcx-and-tocx-functions"></a><span data-ttu-id="34998-107">from_cx and to_cx 関数</span><span class="sxs-lookup"><span data-stu-id="34998-107">from_cx and to_cx functions</span></span>
<span data-ttu-id="34998-108">以下のヘルパー関数では、C++/CX オブジェクトを同等の C++/WinRT オブジェクトに変換します。</span><span class="sxs-lookup"><span data-stu-id="34998-108">The helper function below converts a C++/CX object to an equivalent C++/WinRT object.</span></span> <span data-ttu-id="34998-109">この関数は、C++/CX オブジェクトを基礎となる [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) インターフェイス ポインターにキャストします。</span><span class="sxs-lookup"><span data-stu-id="34998-109">The function casts a C++/CX object to its underlying [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) interface pointer.</span></span> <span data-ttu-id="34998-110">次に、このポインター上で [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) を呼び出し、C++/WinRT オブジェクトの既定のインターフェイスを照会します。</span><span class="sxs-lookup"><span data-stu-id="34998-110">It then calls [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) on that pointer to query for the default interface of the C++/WinRT object.</span></span> <span data-ttu-id="34998-111">**QueryInterface**は、C++/CX safe_cast 拡張と同等の Windows ランタイム アプリケーション バイナリ インターフェイス (ABI) です。</span><span class="sxs-lookup"><span data-stu-id="34998-111">**QueryInterface** is the Windows Runtime application binary interface (ABI) equivalent of the C++/CX safe_cast extension.</span></span> <span data-ttu-id="34998-112">[**winrt::put_abi**](/uwp/cpp-ref-for-winrt/put-abi) 関数は、別の値に設定できるように C++/WinRT オブジェクトの基礎となる **IUnknown** インターフェイス ポインターのアドレスを取得します。</span><span class="sxs-lookup"><span data-stu-id="34998-112">And, the [**winrt::put_abi**](/uwp/cpp-ref-for-winrt/put-abi) function retrieves the address of a C++/WinRT object's underlying **IUnknown** interface pointer so that it can be set to another value.</span></span>

```cppwinrt
template <typename T>
T from_cx(Platform::Object^ from)
{
    T to{ nullptr };

    winrt::check_hresult(reinterpret_cast<::IUnknown*>(from)
        ->QueryInterface(winrt::guid_of<T>(),
            reinterpret_cast<void**>(winrt::put_abi(to))));

    return to;
}
```

<span data-ttu-id="34998-113">以下のヘルパー関数では、C++/WinRT オブジェクトを同等の C++/CX オブジェクトに変換します。</span><span class="sxs-lookup"><span data-stu-id="34998-113">The helper function below converts a C++/WinRT object to an equivalent C++/CX object.</span></span> <span data-ttu-id="34998-114">[**winrt::get_abi**](/uwp/cpp-ref-for-winrt/get-abi) 関数は、C++/WinRT オブジェクトの基礎となる **IUnknown** インターフェイスのポインターを取得します。</span><span class="sxs-lookup"><span data-stu-id="34998-114">The [**winrt::get_abi**](/uwp/cpp-ref-for-winrt/get-abi) function retrieves a pointer to a C++/WinRT object's underlying **IUnknown** interface.</span></span> <span data-ttu-id="34998-115">この関数は、C++/CX safe_cast 拡張を使用して要求された C++/CX 型を照会する前に、このポインターを C++/CX オブジェクトにキャストします。</span><span class="sxs-lookup"><span data-stu-id="34998-115">The function casts that pointer to a C++/CX object before using the C++/CX safe_cast extension to query for the requested C++/CX type.</span></span>

```cppwinrt
template <typename T>
T^ to_cx(winrt::Windows::Foundation::IUnknown const& from)
{
    return safe_cast<T^>(reinterpret_cast<Platform::Object^>(winrt::get_abi(from)));
}
```

## <a name="code-example"></a><span data-ttu-id="34998-116">コードの例</span><span class="sxs-lookup"><span data-stu-id="34998-116">Code example</span></span>
<span data-ttu-id="34998-117">次に、使用中の 2 つのヘルパー関数を表すコード例 (C++/CX **空のアプリ** プロジェクト テンプレートに基づく) を示します。</span><span class="sxs-lookup"><span data-stu-id="34998-117">Here's a code example (based on the C++/CX **Blank App** project template) showing the two helper functions in use.</span></span> <span data-ttu-id="34998-118">このコード例では、異なる断片の名前空間のエイリアスを使用して、C++/WinRT プロジェクションと C++/CX プロジェクション間で生じる可能性のある他の名前空間の競合を処理する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="34998-118">It also illustrates how you can use namespace aliases for the different islands to deal with otherwise potential namespace collisions between the C++/WinRT projection and the C++/CX projection.</span></span>

```cppwinrt
// MainPage.xaml.cpp

#include "pch.h"
#include "MainPage.xaml.h"
#include <winrt/Windows.Foundation.h>
#include <sstream>

using namespace InteropExample;

namespace cx
{
    using namespace Windows::Foundation;
}

namespace winrt
{
    using namespace Windows::Foundation;
}

template <typename T>
T from_cx(Platform::Object^ from)
{
    T to{ nullptr };

    winrt::check_hresult(reinterpret_cast<::IUnknown*>(from)
        ->QueryInterface(winrt::guid_of<T>(),
            reinterpret_cast<void**>(winrt::put_abi(to))));

    return to;
}

template <typename T>
T^ to_cx(winrt::Windows::Foundation::IUnknown const& from)
{
    return safe_cast<T^>(reinterpret_cast<Platform::Object^>(winrt::get_abi(from)));
}

MainPage::MainPage()
{
    InitializeComponent();

    winrt::init_apartment(winrt::apartment_type::single_threaded);

    winrt::Uri uri(L"http://aka.ms/cppwinrt");
    std::wstringstream wstringstream;
    wstringstream << L"C++/WinRT: " << uri.Domain().c_str() << std::endl;

    // Convert from a C++/WinRT type to a C++/CX type.
    cx::Uri^ cx = to_cx<cx::Uri>(uri);
    wstringstream << L"C++/CX: " << cx->Domain->Data() << std::endl;
    ::OutputDebugString(wstringstream.str().c_str());

    // Convert from a C++/CX type to a C++/WinRT type.
    winrt::Uri uri_from_cx = from_cx<winrt::Uri>(cx);
    WINRT_ASSERT(uri.Domain() == uri_from_cx.Domain());
    WINRT_ASSERT(uri == uri_from_cx);
}
```

## <a name="important-apis"></a><span data-ttu-id="34998-119">重要な API</span><span class="sxs-lookup"><span data-stu-id="34998-119">Important APIs</span></span>
* [<span data-ttu-id="34998-120">IUnknown インターフェイス</span><span class="sxs-lookup"><span data-stu-id="34998-120">IUnknown interface</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms680509)
* [<span data-ttu-id="34998-121">QueryInterface 関数</span><span class="sxs-lookup"><span data-stu-id="34998-121">QueryInterface function</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms682521)
* [<span data-ttu-id="34998-122">winrt::get_abi 関数</span><span class="sxs-lookup"><span data-stu-id="34998-122">winrt::get_abi function</span></span>](/uwp/cpp-ref-for-winrt/get-abi)
* [<span data-ttu-id="34998-123">winrt::put_abi 関数</span><span class="sxs-lookup"><span data-stu-id="34998-123">winrt::put_abi function</span></span>](/uwp/cpp-ref-for-winrt/put-abi)

## <a name="related-topics"></a><span data-ttu-id="34998-124">関連トピック</span><span class="sxs-lookup"><span data-stu-id="34998-124">Related topics</span></span>
* [<span data-ttu-id="34998-125">C++/CX</span><span class="sxs-lookup"><span data-stu-id="34998-125">C++/CX</span></span>](/cpp/cppcx/visual-c-language-reference-c-cx)
