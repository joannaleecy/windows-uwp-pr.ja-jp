---
description: このトピックでは、アプリケーション バイナリ インターフェイス (ABI) と C++/WinRT オブジェクト間の変換方法について説明します。
title: C++/WinRT と ABI 間の相互運用
ms.date: 11/30/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、ポート、移行、相互運用、ABI
ms.localizationpriority: medium
ms.openlocfilehash: 1f84debc3fdf421db8f734d1c2184355d0508c8b
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8710712"
---
# <a name="interop-between-cwinrt-and-the-abi"></a>C++/WinRT と ABI 間の相互運用

このトピックでは、SDK アプリケーション バイナリ インターフェイス (ABI) の間で変換する方法を示しています。 と[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)オブジェクト。 これらの手法を使用すると、Windows ランタイムでこれら 2 つの手法によるプログラミングを使用するコード間を相互運用するか、ABI から C++/WinRT にコードを徐々に移動することができます。

## <a name="what-is-the-windows-runtime-abi-and-what-are-abi-types"></a>Windows ランタイム ABI および ABI の種類とは何ですか。
Windows ランタイム クラス (ランタイム クラス) は実際にはアブストラクションです。 このアブストラクションは、さまざまなプログラミング言語がオブジェクトと対話できるようにするバイナリ インターフェイス (アプリケーション バイナリ インターフェイス、または ABI) を定義します。 プログラミング言語に関係なく、クライアント コードと Windows ランタイム オブジェクトとの対話は最下位レベルで発生し、クライアントの言語の構成要素はオブジェクトの ABI への呼び出しに変換されます。

フォルダー "%WindowsSdkDir%Include\10.0.17134.0\winrt" (必要に応じて、状況に合った SDK バージョン番号に調整) 内の Windows SDK ヘッダーは、Windows ランタイム ABI ヘッダー ファイルです。 このヘッダーは MIDL コンパイラによって生成されます。 次のいずれかのヘッダーを含む例を示します。

```
#include <windows.foundation.h>
```

次に、特定の SDK ヘッダー内にあるいずれかの ABI 型の例を簡単に示します。 **ABI** 名前空間である **Windows::Foundation**、およびその他すべての Windows 名前空間は、**ABI** 名前空間内で SDK ヘッダーによって宣言される点に注意してください。

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

このトピックでは、アプリケーション バイナリ インターフェイス (ABI) レイヤーで機能するコードと相互運用するか、またはコードを移植する場合について説明しています。

## <a name="converting-to-and-from-abi-types-in-code"></a>コード内での ABI 型の変換
安全で分かりやすくするため、双方向の変換の場合は、[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)、[**com_ptr::as**](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function)、および [**winrt::Windows::Foundation::IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) のみを使用します。 次に、(**Console App** プロジェクト テンプレートに基づく) コード例を示します 。このコード例では、異なる断片の名前空間のエイリアスを使用して、C++/WinRT プロジェクションと ABI 間で生じる可能性のある他の名前空間の競合を処理する方法についても説明します。

```cppwinrt
// pch.h
#pragma once
#include <windows.foundation.h>
#include <unknwn.h>
#include "winrt/Windows.Foundation.h"

// main.cpp
#include "pch.h"

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
    winrt::com_ptr<abi::IStringable> ptr{ uri.as<abi::IStringable>() };

    // Convert from an ABI type.
    uri = ptr.as<winrt::Uri>();
    winrt::IStringable uriAsIStringable{ ptr.as<winrt::IStringable>() };
}
```

**as** 関数を実装すると、[**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) が呼び出されます。 [**AddRef**](https://msdn.microsoft.com/library/windows/desktop/ms691379) のみを呼び出す下位レベルの変換を行う場合は、[**winrt::copy_to_abi**](/uwp/cpp-ref-for-winrt/copy-to-abi) と [**winrt::copy_from_abi**](/uwp/cpp-ref-for-winrt/copy-from-abi) のヘルパー関数を使用できます。 次に、この下位レベル変換を上記のコード例に追加するコード例を示します。

```cppwinrt
int main()
{
    // The code in main() already shown above remains here.

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
    // The code in main() already shown above remains here.

    // Copy to an owning raw ABI pointer with copy_to_abi.
    abi::IStringable* owning{ nullptr };
    winrt::copy_to_abi(uri, *reinterpret_cast<void**>(&owning));

    // Copy from a raw ABI pointer.
    uri = nullptr;
    winrt::copy_from_abi(uri, owning);
    owning->Release();
```

下位レベルの変換の場合、アドレスをコピーするだけで、[**winrt::get_abi**](/uwp/cpp-ref-for-winrt/get-abi)、[**winrt::detach_abi**](/uwp/cpp-ref-for-winrt/detach-abi)、[**winrt::attach_abi**](/uwp/cpp-ref-for-winrt/attach-abi) の各ヘルパー関数を使用できます。

```cppwinrt
    // The code in main() already shown above remains here.

    // Lowest-level conversions that only copy addresses

    // Convert to a non-owning ABI object with get_abi.
    abi::IStringable* non_owning{ static_cast<abi::IStringable*>(winrt::get_abi(uri)) };
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
// pch.h
#pragma once
#include <windows.foundation.h>
#include <unknwn.h>
#include "winrt/Windows.Foundation.h"

// main.cpp
#include "pch.h"
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
    winrt::com_ptr<abi::IUriRuntimeClass> ptr{ uri.as<abi::IUriRuntimeClass>() };
    winrt::hstring domain;
    winrt::check_hresult(ptr->get_Domain(reinterpret_cast<HSTRING*>(put_abi(domain))));
    std::wcout << "ABI: " << domain.c_str() << std::endl;

    // Convert from an ABI type.
    winrt::Uri uri_from_abi{ convert_from_abi<winrt::Uri>(ptr.get()) };

    WINRT_ASSERT(uri.Domain() == uri_from_abi.Domain());
    WINRT_ASSERT(uri == uri_from_abi);
}
```

## <a name="important-apis"></a>重要な API
* [AddRef 関数](https://msdn.microsoft.com/library/windows/desktop/ms691379)
* [QueryInterface 関数](https://msdn.microsoft.com/library/windows/desktop/ms682521)
* [:attach_abi 関数](/uwp/cpp-ref-for-winrt/attach-abi)
* [winrt::com_ptr 構造体テンプレート](/uwp/cpp-ref-for-winrt/com-ptr)
* [winrt::copy_from_abi 関数](/uwp/cpp-ref-for-winrt/copy-from-abi)
* [winrt::copy_to_abi 関数](/uwp/cpp-ref-for-winrt/copy-to-abi)
* [winrt::detach_abi 関数](/uwp/cpp-ref-for-winrt/detach-abi)
* [winrt::get_abi 関数](/uwp/cpp-ref-for-winrt/get-abi)
* [winrt::Windows::Foundation::IUnknown::as メンバー関数](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)
* [winrt::Windows::Foundation::IUnknown::try_as メンバー関数](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)
