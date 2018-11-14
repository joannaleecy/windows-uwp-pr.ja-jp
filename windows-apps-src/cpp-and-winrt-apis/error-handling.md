---
author: stevewhims
description: このトピックでは、C++/WinRT でのプログラミング時にエラーを処理するための方法について説明します。
title: C++/WinRT でのエラー処理
ms.author: stwhi
ms.date: 05/21/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, エラー, 処理, 例外
ms.localizationpriority: medium
ms.openlocfilehash: 15432202e61322191e27e89920f7791878177c8b
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6453533"
---
# <a name="error-handling-with-cwinrt"></a>C++/WinRT でのエラー処理

このトピックで説明したプログラミングでは、エラーを処理するための戦略[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。 一般的な情報、および背景については、「[エラーと例外の処理 (最新の C++)](/cpp/cpp/errors-and-exception-handling-modern-cpp)」を参照してください。

## <a name="avoid-catching-and-throwing-exceptions"></a>例外のキャッチとスローの回避
引き続き[例外安全なコード](/cpp/cpp/how-to-design-for-exception-safety)を記述することをお勧めしますが、可能な限り、例外のキャッチとスローを回避します。 例外のハンドラーがない場合、Windows は (クラッシュのミニダンプを含む) エラー レポートを自動的に生成します。このレポートは、問題のある場所を追跡するのに役立ちます。

キャッチすることが予想される例外をスローしないでください。 また、予想されるエラーに対して例外を使用しないでください。 *予期しないランタイム エラーが発生したときにのみ*例外をスローし、それ以外はすべてエラー コードまたは結果コードで直接処理し、エラーの原因を封印します。 これにより、例外がスロー*された*ときに、原因がコード内のバグであるか、またはシステム内の例外的なエラー状態のいずれかであることがわかります。

Windows レジストリにアクセスするためのシナリオを検討してください。 アプリがレジストリから値を読み取ることができなかった場合は、それが予想されることであり、適切に処理する必要があります。 例外をスローしないで、その例外と、値が読み取られなかった理由を示す `bool` または `enum` の値を返します。 一方、レジストリへの値の*書き込み*に失敗すると、アプリケーションで適切に処理できないほどの大きな問題があることが示される可能性があります。 そのような場合は、アプリケーションを続行させたくないため、結果としてエラー レポートを生じさせる例外は、アプリケーションが問題を起こさないようにする最も速い方法です。

別の例として、[**StorageFile.GetThumbnailAsync**](/uwp/api/windows.storage.storagefile.getthumbnailasync#Windows_Storage_StorageFile_GetThumbnailAsync_Windows_Storage_FileProperties_ThumbnailMode_) への呼び出しからサムネイル画像を取得し、そのサムネイルを [**BitmapSource.SetSourceAsync**](/uwp/api/windows.ui.xaml.media.imaging.bitmapsource.setsourceasync#Windows_UI_Xaml_Media_Imaging_BitmapSource_SetSourceAsync_Windows_Storage_Streams_IRandomAccessStream_) に渡すことを検討します。 その呼び出しのシーケンスにより、`nullptr` を **SetSourceAsync** に渡し (イメージ ファイルは読み取ることができません。おそらく、そのファイル拡張子のためファイルにイメージ データが含まれているように見えて実際には含まれていません)、無効なポインター例外がスローされることになります。 コードでそのようなケースが見つかったら、そのケースを例外としてキャッチして処理するのではなく **GetThumbnailAsync** から返される `nullptr` かどうかを確認します。

例外をスローすることは、エラー コードを使用するよりも遅くなる傾向があります。 致命的なエラーが発生した場合にのみ例外をスローする場合は、すべてがうまく行けばパフォーマンスの代償を払うことはありません。

ただし、より可能性の高いパフォーマンスの影響として、例外がスローされる万が一のイベントで適切なデストラクターが呼び出されるのを確認することによる実行時のオーバーヘッドがあります。 この保証に関する代償は、例外が実際にスローされるかどうかで決まります。 そのため、どの関数が例外をスローする可能性があるかをコンパイラで十分に把握していることを確認する必要があります。 コンパイラが特定の関数 (`noexcept` 仕様) からの例外が発生しないことを証明できれば、生成されるコードを最適化できます。

## <a name="catching-exceptions"></a>例外のキャッチ
[Windows ランタイム ABI](interop-winrt-abi.md#what-is-the-windows-runtime-abi-and-what-are-abi-types) レイヤーで発生するエラー状態は、HRESULT 値の形式で返されます。 ただし、コードで HRESULT を処理する必要はありません。 使用する側で API のために生成された C++/WinRT プロジェクション コードにより、ABI レイヤーで HRESULT エラー コードが検出され、そのコードが [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) 例外に変換されます。この例外はキャッチして処理できます。

たとえば、アプリケーションによるそのコレクションの反復処理中に、ユーザーが画像ライブラリのイメージを削除してしまった場合、プロジェクションにより例外がスローされます。 また、このケースでは、その例外をキャッチして処理する必要があります。 このケースを示すコード例を次に示します。

```cppwinrt
using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Storage;
using namespace Windows::UI::Xaml::Media::Imaging;

IAsyncAction MakeThumbnailsAsync()
{
    auto imageFiles{ co_await KnownFolders::PicturesLibrary().GetFilesAsync() };

    for (StorageFile const& imageFile : imageFiles)
    {
        BitmapImage bitmapImage;
        try
        {
            auto thumbnail{ co_await imageFile.GetThumbnailAsync(FileProperties::ThumbnailMode::PicturesView) };
            if (thumbnail) bitmapImage.SetSource(thumbnail);
        }
        catch (winrt::hresult_error const& ex)
        {
            HRESULT hr = ex.to_abi(); // HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND).
            winrt::hstring message = ex.message(); // The system cannot find the file specified.
        }
    }
}
```

`co_await` された関数を呼び出すときにコルーチンでこれと同じパターンを使用します。 この HRESULT から例外への変換の別の例として、コンポーネント API が E_OUTOFMEMORY を返すときに **std::bad_alloc** がスローされます。

## <a name="throwing-exceptions"></a>例外のスロー
特定の関数への呼び出しが失敗した場合に、アプリケーションが回復できない (予想どおりに機能することを当てにできない) ように決定する場合があります。 次のコード例では、[**winrt::handle**](/uwp/cpp-ref-for-winrt/handle) 値を [**CreateEvent**](https://msdn.microsoft.com/library/windows/desktop/ms682396) から返された HANDLE 全体のラッパーとして使用します。 次にハンドルを (そこから `bool` 値を作成して) [**winrt::check_bool**](/uwp/cpp-ref-for-winrt/error-handling/check-bool) 関数テンプレートに渡します。 **winrt::check_bool** は、`bool` または `false` (エラーの状態) または `true` (成功の状態) と読み替えることができる任意の値と連携します。

```cppwinrt
winrt::handle h{ ::CreateEvent(nullptr, false, false, nullptr) };
winrt::check_bool(bool{ h });
winrt::check_bool(::SetEvent(h.get()));
```

[**winrt::check_bool**](/uwp/cpp-ref-for-winrt/error-handling/check-bool) に渡す値が false である場合、次の一連の処理が実行されます。

- **winrt::check_bool** が [**winrt::throw_last_error**](/uwp/cpp-ref-for-winrt/error-handling/throw-last-error) 関数を呼び出す。
- **winrt::throw_last_error**では、呼び出しスレッドの最終エラー コードの値を取得する[**GetLastError**](https://msdn.microsoft.com/library/windows/desktop/ms679360)を呼び出し、 [**winrt::throw_hresult**](/uwp/cpp-ref-for-winrt/error-handling/throw-hresult)関数を呼び出します。
- **winrt::throw_hresult** が、エラー コードを表す [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) オブジェクト (または標準のオブジェクト) を使用して例外をスローする。

Windows API では、さまざまな戻り値の型を使用して実行時エラーをレポートするため、**winrt::check_bool** 以外にも、値をチェックして例外をスローするためのその他の便利なヘルパー関数がいくつかあります。

- [**winrt::check_hresult**](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)。 HRESULT コードがエラーを表すかどうかをチェックし、エラーを表す場合は **winrt::throw_hresult** を呼び出します。
- [**winrt::check_nt**](/uwp/cpp-ref-for-winrt/error-handling/check-nt)。 コードがエラーを表すかどうかをチェックし、エラーを表す場合は **winrt::throw_hresult** を呼び出します。
- [**winrt::check_pointer**](/uwp/cpp-ref-for-winrt/error-handling/check-pointer)。 ポインター が null かどうかをチェックし、null の場合は **winrt::throw_last_error** を呼び出します。
- [**winrt::check_win32**](/uwp/cpp-ref-for-winrt/error-handling/check-win32)。 コードがエラーを表すかどうかをチェックし、エラーを表す場合は **winrt::throw_hresult** を呼び出します。

一般的なリターン コードの種類にこれらのヘルパー関数を使用するか、または任意のエラー状態に応答して、[**winrt::throw_last_error**](/uwp/cpp-ref-for-winrt/error-handling/throw-last-error) または [**winrt::throw_hresult**](/uwp/cpp-ref-for-winrt/error-handling/throw-hresult) を呼び出すことができます。 

## <a name="throwing-exceptions-when-authoring-an-api"></a>API を作成するときの例外のスロー
例外が [Windows ランタイム ABI](interop-winrt-abi.md#what-is-the-windows-runtime-abi-and-what-are-abi-types) の境界を越えることは無効であるため、実装で発生するエラー状態は、HRESULT エラー コードの形式で ABI レイヤーを介して返されます。 C++/WinRT を使用して API を作成している場合、実装でスロー*する*例外を HRESULT に変換するためのコードが生成されます。 このようなパターンで生成されたコードで [**winrt::to_hresult**](/uwp/cpp-ref-for-winrt/error-handling/to-hresult) 関数が使用されます。

```cppwinrt
HRESULT DoWork() noexcept
{
    try
    {
        // Shim through to your C++/WinRT implementation.
        return S_OK;
    }
    catch (...)
    {
        return winrt::to_hresult(); // Convert any exception to an HRESULT.
    }
}
```

[**winrt::to_hresult**](/uwp/cpp-ref-for-winrt/error-handling/to-hresult) では、**std::exception** から派生した例外、および [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) とその派生型を処理します。 実装では、API のユーザーが詳細なエラー情報を受け取るように、**winrt::hresult_error** または派生型を使用することをお勧めします。 (E_FAIL にマップされる) **std::exception** は、標準テンプレート ライブラリを使用したことで例外が発生した場合にサポートされます。

## <a name="assertions"></a>アサーション
アプリケーションの内部の前提として、アサーションが用意されています。 可能な限り、コンパイル時の検証に **static_assert** を使用することをお勧めします。 実行時条件には、ブール式による WINRT_ASSERT を使用します。

```cppwinrt
WINRT_ASSERT(pos < size());
```

WINRT_ASSERT は、リテール ビルドでコンパイルされます。デバッグ用のビルドでは、アサーションがあるコード行でデバッガーでアプリケーションが停止します。

デストラクターで例外を使用しないでください。 そのため、少なくともデバッグ ビルドでは、WINRT_VERIFY (ブール式を含む) と WINRT_VERIFY_ (期待される結果とブール式を含む) を使用してデストラクターからの関数の呼び出しの結果をアサートできます。

```cppwinrt
WINRT_VERIFY(::CloseHandle(value));
WINRT_VERIFY_(TRUE, ::CloseHandle(value));
```

## <a name="important-apis"></a>重要な API
* [winrt::check_bool 関数テンプレート](/uwp/cpp-ref-for-winrt/error-handling/check-bool)
* [winrt::check_hresult 関数](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)
* [winrt::check_nt 関数テンプレート](/uwp/cpp-ref-for-winrt/error-handling/check-nt)
* [winrt::check_pointer 関数テンプレート](/uwp/cpp-ref-for-winrt/error-handling/check-pointer)
* [winrt::check_win32 関数テンプレート](/uwp/cpp-ref-for-winrt/error-handling/check-win32)
* [winrt::handle 構造体](/uwp/cpp-ref-for-winrt/handle)
* [winrt::hresult_error 構造体](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)
* [winrt::throw_hresult 構造体](/uwp/cpp-ref-for-winrt/error-handling/throw-hresult)
* [winrt::throw_last_error 構造体](/uwp/cpp-ref-for-winrt/error-handling/throw-last-error)
* [winrt::to_hresult 構造体](/uwp/cpp-ref-for-winrt/error-handling/to-hresult)

## <a name="related-topics"></a>関連トピック
* [エラーと例外処理 (最新の C++)](/cpp/cpp/errors-and-exception-handling-modern-cpp)
* [方法: 例外の安全性の設計](/cpp/cpp/how-to-design-for-exception-safety)
