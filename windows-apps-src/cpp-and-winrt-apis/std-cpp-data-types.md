---
author: stevewhims
description: C++/WinRT では、標準的な C++ データ型を使用して Windows ランタイム API を呼び出すことができます。
title: 標準的な C++ のデータ型と C++/WinRT
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、データ、型
ms.localizationpriority: medium
ms.openlocfilehash: 0b004b5dfbeaa1d123398db780582382857eec25
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931144"
---
# <a name="standard-c-data-types-and-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>標準的な C++ のデータ型と [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)
C++/WinRT では、標準的な C++ データ型 (いくつかの C++ 標準ライブラリのデータ型を含む) を使用して Windows ランタイム API を呼び出すことができます。 Api を標準の文字列を渡すことができます (を参照してください[文字列の処理では C + + WinRT](strings.md))、渡すことができます初期化子リストと標準のコンテナーと同じ意味のコレクションを必要とする Api とします。

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

C++/WinRT は、Windows ランタイムのコレクション パラメーターとして **std::vector** をバインドします。 したがって、**std::vector&lt;winrt::hstring&gt;** を渡すと、Windows ランタイムの適切な **winrt::hstring** のコレクションに変換されます。 呼び出しが非同期の場合を念頭に、追加の詳細があります。 そのケースの実装の詳細のためのベクトルの移動やコピーを提供する必要がありますので、右辺値を提供する必要があります。 次のコード例で移動ベクトルの所有権、非同期呼び出しで許可されるパラメーターの型のオブジェクト (し、私たちはアクセスしないように注意してください`vecH`移行した後にもう一度)。 Rvalue の詳細を把握したい場合は、[値のカテゴリ、およびそれらへの参照](cpp-value-categories.md)を参照してください。

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const storageFile, std::vector<winrt::hstring> vecH)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecH)) };
}
```

ただし、Windows ランタイムのコレクションが予期されているところに **std::vector&lt;std::wstring&gt;** を渡すことはできません。 これは、Windows ランタイムの適切な **std::wstring** のコレクションに変換されたため、C++ 言語がそのコレクションの型パラメーターを強制的に変換しないことが原因です。 その結果、次のコード例はコンパイルされません (ソリューションは、渡すことと、 **std::vector&lt;winrt::hstring&gt;** 代わりに、上記のように)。

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile, std::vector<std::wstring> const& vecW)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecW)) }; // error! Can't convert from vector of wstring to async_iterable of hstring.
}
```

## <a name="raw-arrays-and-pointer-ranges"></a>未処理配列、およびポインターの範囲
将来の C++ 標準ライブラリで対応する型が存在する可能性があることに注意して、選択する場合、または必要に応じて、**array_view** を直接操作することもできます。

**array_view**の範囲と、生の配列からの変換のコンス トラクターには**T&ast; ** (要素の型へのポインター)。

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

## <a name="ivectorlttgt-and-standard-iteration-constructs"></a>**IVector&lt;T&gt;** と標準的な繰り返し構造
型のコレクションを取得する Windows ランタイム API の例では[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) [**IVector&lt;T&gt; **](/uwp/api/windows.foundation.collections.ivector_t_) (C + に投影/WinRT と**winrt::Windows::Foundation::Collections::IVector&lt;T&gt; **). 標準の繰り返しの構造を持つなど、このタイプを使用できる範囲に基づく`for`。

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

## <a name="c-coroutines-with-asynchronous-windows-runtime-apis"></a>非同期 Windows ランタイム Api と C++ のコルーチン
非同期 Windows ランタイム Api を呼び出す場合は、[並列パターン ライブラリ (PPL)](/cpp/parallel/concrt/parallel-patterns-library-ppl)を使用して続行することができます。 ただし、多くの場合、C++ コルーチンを提供、効率的でより簡単にコーディング手法非同期オブジェクトと対話するためです。 詳細な情報、およびコード例についてを参照してください[同時実行性と C + を使用して非同期の操作/WinRT](concurrency.md)。

## <a name="important-apis"></a>重要な API
* [IVector&lt;T&gt;インタ フェース](/uwp/api/windows.foundation.collections.ivector_t_)
* [winrt::array_view 構造体テンプレート](/uwp/cpp-ref-for-winrt/array-view)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での文字列の処理](strings.md)
