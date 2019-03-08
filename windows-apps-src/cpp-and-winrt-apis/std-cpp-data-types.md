---
description: C++/WinRT では、標準的な C++ データ型を使用して Windows ランタイム API を呼び出すことができます。
title: 標準的な C++ のデータ型と C++/WinRT
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、データ、型
ms.localizationpriority: medium
ms.openlocfilehash: 7b0b529bbf397b76acb1eb589095a84f5c85745c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654287"
---
# <a name="standard-c-data-types-and-cwinrt"></a>標準的な C++ のデータ型と C++/WinRT

[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、C++ 標準ライブラリの一部のデータ型を含む標準 C++ データ型を使用して Windows ランタイム Api を呼び出すことができます。 標準文字列を Api に渡すことができます (を参照してください[文字列 c++ 処理/cli WinRT](strings.md))、初期化子リストと標準のコンテナーに渡せる意味的に同等のコレクションを期待する Api とします。

## <a name="standard-initializer-lists"></a>標準的な初期化子リスト
初期化子リスト (**std::initializer_list**) は、C++ 標準ライブラリのコンストラクトです。 Windows ランタイムの特定のコンストラクターやメソッドを呼び出すときに初期化子リストを使用することができます。 たとえば、[**DataWriter::WriteBytes**](/uwp/api/windows.storage.streams.datawriter.writebytes) を呼び出すことができます。

```cppwinrt
#include <winrt/Windows.Storage.Streams.h>

using namespace winrt::Windows::Storage::Streams;

int main()
{
    winrt::init_apartment();

    InMemoryRandomAccessStream stream;
    DataWriter dataWriter{stream};
    dataWriter.WriteBytes({ 99, 98, 97 }); // the initializer list is converted to an array_view before being passed to WriteBytes.
}
```

この作業には 2 つの部分が含まれています。 最初に、**DataWriter::WriteBytes** メソッドは型が [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) であるパラメーターを受け取ります。

```cppwinrt
void WriteBytes(array_view<uint8_t const> value) const
```

 **array_view** は C++/WinRT のカスタム型で、連続した一連の値を安全に表します (C++/WinRT 基本ライブラリ、`%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h` で定義されています)。

2 番目に、**array_view** は初期化子リスト コンストラクターを持っています。

```cppwinrt
template <typename T> array_view(std::initializer_list<T> value) noexcept
```

多くの場合、プログラミングで **array_view** を認識するかどうかを選択できます。 認識*しない*ことを選択する場合は、対応する型が C++ 標準ライブラリに現れる場合に変更すべきコードはありません。

コレクション パラメーターを予期している Windows ランタイム API に初期化子リストを渡すことができます。 たとえば **StorageItemContentProperties::RetrievePropertiesAsync** です。

```cppwinrt
IAsyncOperation<IMap<winrt::hstring, IInspectable>> StorageItemContentProperties::RetrievePropertiesAsync(IIterable<winrt::hstring> propertiesToRetrieve) const;
```

次のような初期化子リストを使用してその API を呼び出すことができます。

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync({ L"System.ItemUrl" }) };
}
```

ここでは、2 つの要因が作用しています。 最初に、呼び出し先が初期化子リストから **std::vector** を作成します (この呼び出し先は非同期であるため、そのオブジェクトを所有することができます。これは必須です)。 2 番目に、C++/WinRT は、**std::vector** を Windows ランタイムのコレクション パラメーターとして透過的に (およびコピーを導入せずに) バインドします。

## <a name="standard-arrays-and-vectors"></a>標準的な配列とベクトル
**array_view** は、**std::vector** および **std::array** からの変換コンストラクターも持っています。

```cppwinrt
template <typename C, size_type N> array_view(std::array<C, N>& value) noexcept
template <typename C> array_view(std::vector<C>& vectorValue) noexcept
```

したがって、代わりに **std::vector** を使用して **DataWriter::WriteBytes** を呼び出すことができます。

```cppwinrt
std::vector<byte> theVector{ 99, 98, 97 };
dataWriter.WriteBytes(theVector); // theVector is converted to an array_view before being passed to WriteBytes.
```

または、**std::array** を使用します。

```cppwinrt
std::array<byte, 3> theArray{ 99, 98, 97 };
dataWriter.WriteBytes(theArray); // theArray is converted to an array_view before being passed to WriteBytes.
```

C++/WinRT は、Windows ランタイムのコレクション パラメーターとして **std::vector** をバインドします。 したがって、**std::vector&lt;winrt::hstring&gt;** を渡すと、Windows ランタイムの適切な **winrt::hstring** のコレクションに変換されます。 呼び出し先が非同期の場合に注意する追加の詳細があります。 そのケースの実装の詳細のためには、ベクターの移動やコピーを提供する必要がありますので、右辺値を提供する必要があります。 次のコード例で、非同期呼び出し先が受け取るパラメーターの型のオブジェクトに、ベクターの所有権を移動しました (アクセスしないように注意している`vecH`移動後にもう一度)。 右辺値の詳細を理解する場合は、「[値のカテゴリ、およびそれらへの参照](cpp-value-categories.md)します。

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const storageFile, std::vector<winrt::hstring> vecH)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecH)) };
}
```

ただし、Windows ランタイムのコレクションが予期されているところに **std::vector&lt;std::wstring&gt;** を渡すことはできません。 これは、Windows ランタイムの適切な **std::wstring** のコレクションに変換されたため、C++ 言語がそのコレクションの型パラメーターを強制的に変換しないことが原因です。 その結果、次のコード例はコンパイルされません (解決策は、渡すと、 **std::vector&lt;winrt::hstring&gt;** 代わりに、上記の)。

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile, std::vector<std::wstring> const& vecW)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecW)) }; // error! Can't convert from vector of wstring to async_iterable of hstring.
}
```

## <a name="raw-arrays-and-pointer-ranges"></a>未処理配列、およびポインターの範囲
将来の C++ 標準ライブラリで対応する型が存在する可能性があることに注意して、選択する場合、または必要に応じて、**array_view** を直接操作することもできます。

**array_view**の範囲と、生の配列からの変換コンス トラクターを持つ**T&ast;**  (要素の型へのポインター)。

```cppwinrt
using namespace winrt;
...
byte theRawArray[]{ 99, 98, 97 };
array_view<byte const> fromRawArray{ theRawArray };
dataWriter.WriteBytes(fromRawArray); // the array_view is passed to WriteBytes.

array_view<byte const> fromRange{ theArray.data(), theArray.data() + 2 }; // just the first two elements.
dataWriter.WriteBytes(fromRange); // the array_view is passed to WriteBytes.
```

## <a name="winrtarrayview-functions-and-operators"></a>winrt::array_view の関数と演算子
コンストラクター、演算子、関数、および反復子のホストが **array_view** に対して実装されています。 **array_view** は範囲であるため、範囲ベースの `for`、または **std::for_each** で使用できます。

その他の例や詳細については、[**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) API リファレンス トピックをご覧ください。

## <a name="ivectorlttgt-and-standard-iteration-constructs"></a>**IVector&lt;T&gt;** および標準のイテレーションの構成要素
[**SyndicationFeed.Items** ](/uwp/api/windows.web.syndication.syndicationfeed.items)型のコレクションを返す Windows ランタイム API の例は、 [ **IVector&lt;T&gt;**  ](/uwp/api/windows.foundation.collections.ivector_t_) (C + に投影します。/Cli として WinRT **winrt::Windows::Foundation::Collections::IVector&lt;T&gt;**)。 この型は、標準のイテレーションの構成要素をなど、使用できる範囲に基づく`for`します。

```cppwinrt
// main.cpp
#include "pch.h"
#include <winrt/Windows.Web.Syndication.h>
#include <iostream>

using namespace winrt;
using namespace Windows::Web::Syndication;

void PrintFeed(SyndicationFeed const& syndicationFeed)
{
    for (SyndicationItem const& syndicationItem : syndicationFeed.Items())
    {
        std::wcout << syndicationItem.Title().Text().c_str() << std::endl;
    }
}
```

## <a name="c-coroutines-with-asynchronous-windows-runtime-apis"></a>非同期 Windows ランタイム Api を使用した C++ のコルーチン
引き続き使用できます、[並列パターン ライブラリ (PPL)](/cpp/parallel/concrt/parallel-patterns-library-ppl)非同期 Windows ランタイム Api を呼び出すときにします。 ただし、多くの場合、C++ コルーチン提供、効率的でより簡単にコーディングされた表現する形式の非同期オブジェクトを操作します。 詳細については、およびコード例は、次を参照してください。[同時実行と非同期操作を C +/cli WinRT](concurrency.md)します。

## <a name="important-apis"></a>重要な API
* [IVector&lt;T&gt;インターフェイス](/uwp/api/windows.foundation.collections.ivector_t_)
* [winrt::array_view 構造体のテンプレート](/uwp/cpp-ref-for-winrt/array-view)

## <a name="related-topics"></a>関連トピック
* [文字列処理 c++/cli WinRT](strings.md)
