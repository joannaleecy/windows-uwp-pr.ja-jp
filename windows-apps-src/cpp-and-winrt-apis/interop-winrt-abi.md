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
# <a name="interop-between-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-and-the-abi"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) と ABI 間の相互運用
このトピックでは、アプリケーション バイナリ インターフェイス (ABI) と C++/WinRT オブジェクト間の変換方法について説明します。 これらの手法を使用すると、Windows ランタイムでこれら 2 つの手法によるプログラミングを使用するコード間を相互運用するか、ABI から C++/WinRT にコードを徐々に移動することができます。

## <a name="what-are-windows-runtime-abi-types"></a>Windows ランタイム ABI の型とは
フォルダー "%WindowsSdkDir%Include\10.0.17134.0\winrt" (必要に応じて、状況に合った SDK バージョン番号に調整) 内の Windows SDK ヘッダーは、Windows ランタイム ABI ヘッダー ファイルです。 このヘッダーは MIDL コンパイラによって生成されます。 次のいずれかのヘッダーを含む例を示します。

```
#include <windows.foundation.h>
```

次に、特定のヘッダー内にあるいずれかの ABI 型の例を簡単に示します。

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

**IUriRuntimeClass** は COM インターフェイスです。 ただしそれ以上に、ベースは **IInspectable** のため、**IUriRuntimeClass** は Windows ランタイム インターフェイスです。 **HRESULT** は例外よりも型を返します。 **HSTRING** ハンドルなどのアーティファクトを使用します (完了したら、このハンドルを `nullptr` に戻すように設定することをお勧めします)。 これにより、アプリケーション バイナリ レベル、つまり、COM プログラミング レベルで Windows ランタイムの内容を把握できます。

Windows ランタイムはコンポーネント オブジェクト モデル (COM) API に基づいています。 この方法で Windows ランタイムにアクセスするか、*言語プロジェクション*を介してアクセスすることができます。 プロジェクションは、COM の詳細を隠し、特定の言語により自然なプログラミング エクスペリエンスを提供します。

たとえば、フォルダー "%WindowsSdkDir%Include\10.0.17134.0\cppwinrt\winrt" 内を見ると (必要に応じて、状況に合った SDK バージョン番号に調整)、C++/WinRT 言語プロジェクション ヘッダーがあります。 Windows 名前空間ごとに 1 つの ABI ヘッダーがあるように、Windows 名前空間それぞれにヘッダーがあります。 次に、いずれかの C++/WinRT ヘッダーを含む例を示します。

```cppwinrt
#include <winrt/Windows.Foundation.h>
```

このヘッダーから、上記の ABI 型に相当する C++/WinRT を簡略化して次に示します。

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

このインターフェイスは最新の標準的な C++ です。 **HRESULT** は削除されています (必要に応じて、C++/WinRT では例外が発生します)。 アクセサー関数は簡単な文字列オブジェクトを返します。このオブジェクトはその範囲の最後でクリーンアップされます。

## <a name="converting-to-and-from-abi-types-in-code"></a>コード内での ABI 型の変換
安全で分かりやすくするため、双方向の変換の場合は、[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)、[**com_ptr::as**](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function)、および [**winrt::Windows::Foundation::IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) のみを使用します。 次に、コード例を示します (**コンソール アプリ** プロジェクト テンプレートに基づいて)。また、プロジェクションと ABI 間の名前空間の競合を処理する方法についても説明します。

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

**as** 関数を実装すると、[**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) が呼び出されます。 [**AddRef**](https://msdn.microsoft.com/library/windows/desktop/ms691379) のみを呼び出す下位レベルの変換を行う場合は、[**winrt::copy_to_abi**](/uwp/cpp-ref-for-winrt/copy-to-abi) と [**winrt::copy_from_abi**](/uwp/cpp-ref-for-winrt/copy-from-abi) のヘルパー関数を使用できます。 次に、この下位レベル変換を上記のコード例に追加するコード例を示します。

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

次に、他の同様の下位レベルの変換手法を示しますが、ここでは ABI インターフェイスの型 (Windows SDK ヘッダーで定義されている型) に生のポインターを使用しています。

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

下位レベルの変換の場合、アドレスをコピーするだけで、[**winrt::get_abi**](/uwp/cpp-ref-for-winrt/get-abi)、[**winrt::detach_abi**](/uwp/cpp-ref-for-winrt/detach-abi)、[**winrt::attach_abi**](/uwp/cpp-ref-for-winrt/attach-abi) の各ヘルパー関数を使用できます。

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

## <a name="convertfromabi-function"></a>convert_from_abi 関数
このヘルパー関数では、最小限のオーバーヘッドで生の ABI インターフェイス ポインターを同等の C++/WinRT オブジェクトに変換します。

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

この関数は、[**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) を呼び出し、要求された C++/WinRT 型の既定のインターフェイスを照会するだけです。

既に説明したように、C++/WinRT オブジェクトから同等の ABI インターフェイス ポインターへの変換には、ヘルパー関数は必要ありません。 [**winrt::Windows::Foundation::IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) (または [**try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)) メンバー関数を使用して、要求されたインターフェイスを照会するだけです。 **as** 関数と **try_as** 関数は、要求された ABI 型をラップする [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) オブジェクトを返します。

## <a name="code-example-using-convertfromabi"></a>convert_from_abi を使用したコード例
次に、このヘルパー関数を表す実践的なコード例を示します。

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

## <a name="important-apis"></a>重要な API
* [AddRef](https://msdn.microsoft.com/library/windows/desktop/ms691379)
* [QueryInterface](https://msdn.microsoft.com/library/windows/desktop/ms682521)
* [winrt::attach_abi](/uwp/cpp-ref-for-winrt/attach-abi)
* [winrt::com_ptr 構造体テンプレート](/uwp/cpp-ref-for-winrt/com-ptr)
* [winrt::copy_from_abi](/uwp/cpp-ref-for-winrt/copy-from-abi)
* [winrt::copy_to_abi](/uwp/cpp-ref-for-winrt/copy-to-abi)
* [winrt::detach_abi](/uwp/cpp-ref-for-winrt/detach-abi)
* [winrt::get_abi](/uwp/cpp-ref-for-winrt/get-abi)
* [winrt::Windows::Foundation::IUnknown::as メンバー関数](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)
* [winrt::Windows::Foundation::IUnknown::try_as メンバー関数](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)
