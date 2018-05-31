---
author: stevewhims
description: このトピックでは、C++/CX と C++/WinRT オブジェクト間の変換に使用できる 2 つのヘルパー関数について説明します。
title: C++/WinRT と C++/CX 間の相互運用
ms.author: stwhi
ms.date: 04/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、ポート、移行、相互運用、C++/CX
ms.localizationpriority: medium
ms.openlocfilehash: 616bd9ea8c4b89599e703ef9467206b028fd596b
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1831786"
---
# <a name="interop-between-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-and-ccx"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) と C++/CX 間の相互運用
このトピックでは、[C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live) と C++/WinRT オブジェクト間の変換に使用できる 2 つのヘルパー関数について説明します。 ヘルパー関数を使用すると、2 つの言語プロジェクションを使用するコード間で相互運用したり、C++/CX から C++/WinRT にコードを徐々に移動したりすることができます。

## <a name="fromcx-and-tocx-functions"></a>from_cx and to_cx 関数
以下のヘルパー関数では、C++/CX オブジェクトを同等の C++/WinRT オブジェクトに変換します。 この関数は、C++/CX オブジェクトを基礎となる [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) インターフェイス ポインターにキャストします。 次に、このポインター上で [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) を呼び出し、C++/WinRT オブジェクトの既定のインターフェイスを照会します。 **QueryInterface**は、C++/CX safe_cast 拡張と同等の Windows ランタイム アプリケーション バイナリ インターフェイス (ABI) です。 [**winrt::put_abi**](/uwp/cpp-ref-for-winrt/put-abi) 関数は、別の値に設定できるように C++/WinRT オブジェクトの基礎となる **IUnknown** インターフェイス ポインターのアドレスを取得します。

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

以下のヘルパー関数では、C++/WinRT オブジェクトを同等の C++/CX オブジェクトに変換します。 [**winrt::get_abi**](/uwp/cpp-ref-for-winrt/get-abi) 関数は、C++/WinRT オブジェクトの基礎となる **IUnknown** インターフェイスのポインターを取得します。 この関数は、C++/CX safe_cast 拡張を使用して要求された C++/CX 型を照会する前に、このポインターを C++/CX オブジェクトにキャストします。

```cppwinrt
template <typename T>
T^ to_cx(winrt::Windows::Foundation::IUnknown const& from)
{
    return safe_cast<T^>(reinterpret_cast<Platform::Object^>(winrt::get_abi(from)));
}
```

## <a name="code-example"></a>コードの例
次に、使用中の 2 つのヘルパー関数を表すコード例 (C++/CX **空のアプリ** プロジェクト テンプレートに基づく) を示します。 また、2 つのプロジェクション間で名前空間の競合を処理する方法についても説明します。

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

## <a name="important-apis"></a>重要な API
* [IUnknown インターフェイス](https://msdn.microsoft.com/library/windows/desktop/ms680509)
* [QueryInterface](https://msdn.microsoft.com/library/windows/desktop/ms682521)
* [winrt::get_abi 関数](/uwp/cpp-ref-for-winrt/get-abi)
* [winrt::put_abi 関数](/uwp/cpp-ref-for-winrt/put-abi)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
