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
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6199852"
---
# <a name="error-handling-with-cwinrt"></a><span data-ttu-id="c3a14-104">C++/WinRT でのエラー処理</span><span class="sxs-lookup"><span data-stu-id="c3a14-104">Error handling with C++/WinRT</span></span>

<span data-ttu-id="c3a14-105">このトピックで説明したプログラミングでは、エラーを処理するための戦略[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-105">This topic discusses strategies for handling errors when programming with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span> <span data-ttu-id="c3a14-106">一般的な情報、および背景については、「[エラーと例外の処理 (最新の C++)](/cpp/cpp/errors-and-exception-handling-modern-cpp)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c3a14-106">For more general info, and background, see [Errors and Exception Handling (Modern C++)](/cpp/cpp/errors-and-exception-handling-modern-cpp).</span></span>

## <a name="avoid-catching-and-throwing-exceptions"></a><span data-ttu-id="c3a14-107">例外のキャッチとスローの回避</span><span class="sxs-lookup"><span data-stu-id="c3a14-107">Avoid catching and throwing exceptions</span></span>
<span data-ttu-id="c3a14-108">引き続き[例外安全なコード](/cpp/cpp/how-to-design-for-exception-safety)を記述することをお勧めしますが、可能な限り、例外のキャッチとスローを回避します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-108">We recommend that you continue to write [exception-safe code](/cpp/cpp/how-to-design-for-exception-safety), but that you prefer to avoid catching and throwing exceptions whenever possible.</span></span> <span data-ttu-id="c3a14-109">例外のハンドラーがない場合、Windows は (クラッシュのミニダンプを含む) エラー レポートを自動的に生成します。このレポートは、問題のある場所を追跡するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-109">If there's no handler for an exception, then Windows automatically generates an error report (including a minidump of the crash), which will help you track down where the problem is.</span></span>

<span data-ttu-id="c3a14-110">キャッチすることが予想される例外をスローしないでください。</span><span class="sxs-lookup"><span data-stu-id="c3a14-110">Don't throw an exception that you expect to catch.</span></span> <span data-ttu-id="c3a14-111">また、予想されるエラーに対して例外を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="c3a14-111">And don't use exceptions for expected failures.</span></span> <span data-ttu-id="c3a14-112">*予期しないランタイム エラーが発生したときにのみ*例外をスローし、それ以外はすべてエラー コードまたは結果コードで直接処理し、エラーの原因を封印します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-112">Throw an exception *only when an unexpected runtime error occurs*, and handle everything else with error/result codes&mdash;directly, and close to the source of the failure.</span></span> <span data-ttu-id="c3a14-113">これにより、例外がスロー*された*ときに、原因がコード内のバグであるか、またはシステム内の例外的なエラー状態のいずれかであることがわかります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-113">That way, when an exception *is* thrown, you know that the cause is either a bug in your code, or an exceptional error state in the system.</span></span>

<span data-ttu-id="c3a14-114">Windows レジストリにアクセスするためのシナリオを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c3a14-114">Consider the scenario of accessing the Windows Registry.</span></span> <span data-ttu-id="c3a14-115">アプリがレジストリから値を読み取ることができなかった場合は、それが予想されることであり、適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-115">If your app fails to read a value from the Registry, then that's to be expected, and you should handle it gracefully.</span></span> <span data-ttu-id="c3a14-116">例外をスローしないで、その例外と、値が読み取られなかった理由を示す `bool` または `enum` の値を返します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-116">Don't throw an exception; rather return a `bool` or `enum` value indicating that, and perhaps why, the value wasn't read.</span></span> <span data-ttu-id="c3a14-117">一方、レジストリへの値の*書き込み*に失敗すると、アプリケーションで適切に処理できないほどの大きな問題があることが示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-117">Failing to *write* a value to the Registry, on the other hand, is likely to indicate that there's a bigger problem than you can handle sensibly in your application.</span></span> <span data-ttu-id="c3a14-118">そのような場合は、アプリケーションを続行させたくないため、結果としてエラー レポートを生じさせる例外は、アプリケーションが問題を起こさないようにする最も速い方法です。</span><span class="sxs-lookup"><span data-stu-id="c3a14-118">In a case like that, you don't want your application to continue, so an exception that results in an error report is the fastest way to keep your application from causing any harm.</span></span>

<span data-ttu-id="c3a14-119">別の例として、[**StorageFile.GetThumbnailAsync**](/uwp/api/windows.storage.storagefile.getthumbnailasync#Windows_Storage_StorageFile_GetThumbnailAsync_Windows_Storage_FileProperties_ThumbnailMode_) への呼び出しからサムネイル画像を取得し、そのサムネイルを [**BitmapSource.SetSourceAsync**](/uwp/api/windows.ui.xaml.media.imaging.bitmapsource.setsourceasync#Windows_UI_Xaml_Media_Imaging_BitmapSource_SetSourceAsync_Windows_Storage_Streams_IRandomAccessStream_) に渡すことを検討します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-119">For another example, consider retrieving a thumbnail image from a call to [**StorageFile.GetThumbnailAsync**](/uwp/api/windows.storage.storagefile.getthumbnailasync#Windows_Storage_StorageFile_GetThumbnailAsync_Windows_Storage_FileProperties_ThumbnailMode_), and then passing that thumbnail to [**BitmapSource.SetSourceAsync**](/uwp/api/windows.ui.xaml.media.imaging.bitmapsource.setsourceasync#Windows_UI_Xaml_Media_Imaging_BitmapSource_SetSourceAsync_Windows_Storage_Streams_IRandomAccessStream_).</span></span> <span data-ttu-id="c3a14-120">その呼び出しのシーケンスにより、`nullptr` を **SetSourceAsync** に渡し (イメージ ファイルは読み取ることができません。おそらく、そのファイル拡張子のためファイルにイメージ データが含まれているように見えて実際には含まれていません)、無効なポインター例外がスローされることになります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-120">If that sequence of calls causes you to pass `nullptr` to **SetSourceAsync** (the image file can't be read; perhaps its file extension makes it look like it contains image data, but it actually doesn't), then you'll cause an invalid pointer exception to be thrown.</span></span> <span data-ttu-id="c3a14-121">コードでそのようなケースが見つかったら、そのケースを例外としてキャッチして処理するのではなく **GetThumbnailAsync** から返される `nullptr` かどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-121">If you discover a case like that in your code, rather than catching and handling the case as an exception, instead check for `nullptr` returned from **GetThumbnailAsync**.</span></span>

<span data-ttu-id="c3a14-122">例外をスローすることは、エラー コードを使用するよりも遅くなる傾向があります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-122">Throwing exceptions tends to be slower than using error codes.</span></span> <span data-ttu-id="c3a14-123">致命的なエラーが発生した場合にのみ例外をスローする場合は、すべてがうまく行けばパフォーマンスの代償を払うことはありません。</span><span class="sxs-lookup"><span data-stu-id="c3a14-123">If you only throw an exception when a fatal error occurs, then if all goes well you'll never pay the performance price.</span></span>

<span data-ttu-id="c3a14-124">ただし、より可能性の高いパフォーマンスの影響として、例外がスローされる万が一のイベントで適切なデストラクターが呼び出されるのを確認することによる実行時のオーバーヘッドがあります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-124">But a more likely performance hit involves the runtime overhead of ensuring that the appropriate destructors are called in the unlikely event that an exception is thrown.</span></span> <span data-ttu-id="c3a14-125">この保証に関する代償は、例外が実際にスローされるかどうかで決まります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-125">The cost of this assurance comes whether an exception is actually thrown or not.</span></span> <span data-ttu-id="c3a14-126">そのため、どの関数が例外をスローする可能性があるかをコンパイラで十分に把握していることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-126">So, you should ensure that the compiler has a good idea of what functions can potentially throw exceptions.</span></span> <span data-ttu-id="c3a14-127">コンパイラが特定の関数 (`noexcept` 仕様) からの例外が発生しないことを証明できれば、生成されるコードを最適化できます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-127">If the compiler can prove that there won't be any exceptions from certain functions (the `noexcept` specification), then it can optimize the code it generates.</span></span>

## <a name="catching-exceptions"></a><span data-ttu-id="c3a14-128">例外のキャッチ</span><span class="sxs-lookup"><span data-stu-id="c3a14-128">Catching exceptions</span></span>
<span data-ttu-id="c3a14-129">[Windows ランタイム ABI](interop-winrt-abi.md#what-is-the-windows-runtime-abi-and-what-are-abi-types) レイヤーで発生するエラー状態は、HRESULT 値の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-129">An error condition that arises at the [Windows Runtime ABI](interop-winrt-abi.md#what-is-the-windows-runtime-abi-and-what-are-abi-types) layer is returned in the form of a HRESULT value.</span></span> <span data-ttu-id="c3a14-130">ただし、コードで HRESULT を処理する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c3a14-130">But you don't need to handle HRESULTs in your code.</span></span> <span data-ttu-id="c3a14-131">使用する側で API のために生成された C++/WinRT プロジェクション コードにより、ABI レイヤーで HRESULT エラー コードが検出され、そのコードが [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) 例外に変換されます。この例外はキャッチして処理できます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-131">The C++/WinRT projection code that's generated for an API on the consuming side detects an error HRESULT code at the ABI layer and converts the code into a [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) exception, which you can catch and handle.</span></span>

<span data-ttu-id="c3a14-132">たとえば、アプリケーションによるそのコレクションの反復処理中に、ユーザーが画像ライブラリのイメージを削除してしまった場合、プロジェクションにより例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-132">For example, if the user happens to delete an image from the Pictures Library while your application is iterating over that collection, then the projection throws an exception.</span></span> <span data-ttu-id="c3a14-133">また、このケースでは、その例外をキャッチして処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-133">And this is a case where you'll have to catch and handle that exception.</span></span> <span data-ttu-id="c3a14-134">このケースを示すコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-134">Here's a code example showing this case.</span></span>

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

<span data-ttu-id="c3a14-135">`co_await` された関数を呼び出すときにコルーチンでこれと同じパターンを使用します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-135">Use this same pattern in a coroutine when calling a `co_await`-ed function.</span></span> <span data-ttu-id="c3a14-136">この HRESULT から例外への変換の別の例として、コンポーネント API が E_OUTOFMEMORY を返すときに **std::bad_alloc** がスローされます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-136">Another example of this HRESULT-to-exception conversion is that when a component API returns E_OUTOFMEMORY, that causes a **std::bad_alloc** to be thrown.</span></span>

## <a name="throwing-exceptions"></a><span data-ttu-id="c3a14-137">例外のスロー</span><span class="sxs-lookup"><span data-stu-id="c3a14-137">Throwing exceptions</span></span>
<span data-ttu-id="c3a14-138">特定の関数への呼び出しが失敗した場合に、アプリケーションが回復できない (予想どおりに機能することを当てにできない) ように決定する場合があります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-138">There will be cases where you decide that, should your call to a given function fail, your application won't be able to recover (you'll no longer be able to rely on it to function predictably).</span></span> <span data-ttu-id="c3a14-139">次のコード例では、[**winrt::handle**](/uwp/cpp-ref-for-winrt/handle) 値を [**CreateEvent**](https://msdn.microsoft.com/library/windows/desktop/ms682396) から返された HANDLE 全体のラッパーとして使用します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-139">The code example below uses a [**winrt::handle**](/uwp/cpp-ref-for-winrt/handle) value as a wrapper around the HANDLE returned from [**CreateEvent**](https://msdn.microsoft.com/library/windows/desktop/ms682396).</span></span> <span data-ttu-id="c3a14-140">次にハンドルを (そこから `bool` 値を作成して) [**winrt::check_bool**](/uwp/cpp-ref-for-winrt/error-handling/check-bool) 関数テンプレートに渡します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-140">It then passes the handle (creating a `bool` value from it) to the [**winrt::check_bool**](/uwp/cpp-ref-for-winrt/error-handling/check-bool) function template.</span></span> <span data-ttu-id="c3a14-141">**winrt::check_bool** は、`bool` または `false` (エラーの状態) または `true` (成功の状態) と読み替えることができる任意の値と連携します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-141">**winrt::check_bool** works with a `bool`, or with any value that's convertible to `false` (an error condition), or `true` (a success condition).</span></span>

```cppwinrt
winrt::handle h{ ::CreateEvent(nullptr, false, false, nullptr) };
winrt::check_bool(bool{ h });
winrt::check_bool(::SetEvent(h.get()));
```

<span data-ttu-id="c3a14-142">[**winrt::check_bool**](/uwp/cpp-ref-for-winrt/error-handling/check-bool) に渡す値が false である場合、次の一連の処理が実行されます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-142">If the value that you pass to [**winrt::check_bool**](/uwp/cpp-ref-for-winrt/error-handling/check-bool) is false, then the following sequence of actions take place.</span></span>

- <span data-ttu-id="c3a14-143">**winrt::check_bool** が [**winrt::throw_last_error**](/uwp/cpp-ref-for-winrt/error-handling/throw-last-error) 関数を呼び出す。</span><span class="sxs-lookup"><span data-stu-id="c3a14-143">**winrt::check_bool** calls the [**winrt::throw_last_error**](/uwp/cpp-ref-for-winrt/error-handling/throw-last-error) function.</span></span>
- <span data-ttu-id="c3a14-144">**winrt::throw_last_error**では、呼び出しスレッドの最終エラー コードの値を取得する[**GetLastError**](https://msdn.microsoft.com/library/windows/desktop/ms679360)を呼び出し、 [**winrt::throw_hresult**](/uwp/cpp-ref-for-winrt/error-handling/throw-hresult)関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-144">**winrt::throw_last_error** calls [**GetLastError**](https://msdn.microsoft.com/library/windows/desktop/ms679360) to retrieve the calling thread's last-error code value, and then calls the [**winrt::throw_hresult**](/uwp/cpp-ref-for-winrt/error-handling/throw-hresult) function.</span></span>
- <span data-ttu-id="c3a14-145">**winrt::throw_hresult** が、エラー コードを表す [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) オブジェクト (または標準のオブジェクト) を使用して例外をスローする。</span><span class="sxs-lookup"><span data-stu-id="c3a14-145">**winrt::throw_hresult** throws an exception using a [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) object (or a standard object) that represents that error code.</span></span>

<span data-ttu-id="c3a14-146">Windows API では、さまざまな戻り値の型を使用して実行時エラーをレポートするため、**winrt::check_bool** 以外にも、値をチェックして例外をスローするためのその他の便利なヘルパー関数がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="c3a14-146">Because Windows APIs report run-time errors using various return-value types, there are in addition to **winrt::check_bool** a handful of other useful helper functions for checking values and throwing exceptions.</span></span>

- <span data-ttu-id="c3a14-147">[**winrt::check_hresult**](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)。</span><span class="sxs-lookup"><span data-stu-id="c3a14-147">[**winrt::check_hresult**](/uwp/cpp-ref-for-winrt/error-handling/check-hresult).</span></span> <span data-ttu-id="c3a14-148">HRESULT コードがエラーを表すかどうかをチェックし、エラーを表す場合は **winrt::throw_hresult** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-148">Checks whether the HRESULT code represents an error and, if so, calls **winrt::throw_hresult**.</span></span>
- <span data-ttu-id="c3a14-149">[**winrt::check_nt**](/uwp/cpp-ref-for-winrt/error-handling/check-nt)。</span><span class="sxs-lookup"><span data-stu-id="c3a14-149">[**winrt::check_nt**](/uwp/cpp-ref-for-winrt/error-handling/check-nt).</span></span> <span data-ttu-id="c3a14-150">コードがエラーを表すかどうかをチェックし、エラーを表す場合は **winrt::throw_hresult** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-150">Checks whether a code represents an error and, if so, calls **winrt::throw_hresult**.</span></span>
- <span data-ttu-id="c3a14-151">[**winrt::check_pointer**](/uwp/cpp-ref-for-winrt/error-handling/check-pointer)。</span><span class="sxs-lookup"><span data-stu-id="c3a14-151">[**winrt::check_pointer**](/uwp/cpp-ref-for-winrt/error-handling/check-pointer).</span></span> <span data-ttu-id="c3a14-152">ポインター が null かどうかをチェックし、null の場合は **winrt::throw_last_error** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-152">Checks whether a pointer is null and, if so, calls **winrt::throw_last_error**.</span></span>
- <span data-ttu-id="c3a14-153">[**winrt::check_win32**](/uwp/cpp-ref-for-winrt/error-handling/check-win32)。</span><span class="sxs-lookup"><span data-stu-id="c3a14-153">[**winrt::check_win32**](/uwp/cpp-ref-for-winrt/error-handling/check-win32).</span></span> <span data-ttu-id="c3a14-154">コードがエラーを表すかどうかをチェックし、エラーを表す場合は **winrt::throw_hresult** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-154">Checks whether a code represents an error and, if so, calls **winrt::throw_hresult**.</span></span>

<span data-ttu-id="c3a14-155">一般的なリターン コードの種類にこれらのヘルパー関数を使用するか、または任意のエラー状態に応答して、[**winrt::throw_last_error**](/uwp/cpp-ref-for-winrt/error-handling/throw-last-error) または [**winrt::throw_hresult**](/uwp/cpp-ref-for-winrt/error-handling/throw-hresult) を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-155">You can use these helper functions for common return code types, or you can respond to any error condition and call either [**winrt::throw_last_error**](/uwp/cpp-ref-for-winrt/error-handling/throw-last-error) or [**winrt::throw_hresult**](/uwp/cpp-ref-for-winrt/error-handling/throw-hresult).</span></span> 

## <a name="throwing-exceptions-when-authoring-an-api"></a><span data-ttu-id="c3a14-156">API を作成するときの例外のスロー</span><span class="sxs-lookup"><span data-stu-id="c3a14-156">Throwing exceptions when authoring an API</span></span>
<span data-ttu-id="c3a14-157">例外が [Windows ランタイム ABI](interop-winrt-abi.md#what-is-the-windows-runtime-abi-and-what-are-abi-types) の境界を越えることは無効であるため、実装で発生するエラー状態は、HRESULT エラー コードの形式で ABI レイヤーを介して返されます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-157">Since it's invalid for an exception to cross the [Windows Runtime ABI](interop-winrt-abi.md#what-is-the-windows-runtime-abi-and-what-are-abi-types) boundary, an error condition that arises in an implementation is returned across the ABI layer in the form of an HRESULT error code.</span></span> <span data-ttu-id="c3a14-158">C++/WinRT を使用して API を作成している場合、実装でスロー*する*例外を HRESULT に変換するためのコードが生成されます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-158">When you're authoring an API using C++/WinRT, code is generated for you to convert any exception that you *do* throw in your implementation into an HRESULT.</span></span> <span data-ttu-id="c3a14-159">このようなパターンで生成されたコードで [**winrt::to_hresult**](/uwp/cpp-ref-for-winrt/error-handling/to-hresult) 関数が使用されます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-159">The [**winrt::to_hresult**](/uwp/cpp-ref-for-winrt/error-handling/to-hresult) function is used in that generated code in a pattern like this.</span></span>

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

<span data-ttu-id="c3a14-160">[**winrt::to_hresult**](/uwp/cpp-ref-for-winrt/error-handling/to-hresult) では、**std::exception** から派生した例外、および [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) とその派生型を処理します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-160">[**winrt::to_hresult**](/uwp/cpp-ref-for-winrt/error-handling/to-hresult) handles exceptions derived from **std::exception**, and [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) and its derived types.</span></span> <span data-ttu-id="c3a14-161">実装では、API のユーザーが詳細なエラー情報を受け取るように、**winrt::hresult_error** または派生型を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c3a14-161">In your implementation, you should prefer **winrt::hresult_error**, or a derived type, so that consumers of your API receive rich error information.</span></span> <span data-ttu-id="c3a14-162">(E_FAIL にマップされる) **std::exception** は、標準テンプレート ライブラリを使用したことで例外が発生した場合にサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-162">**std::exception** (which maps to E_FAIL) is supported in case exceptions arise from your use of the Standard Template Library.</span></span>

## <a name="assertions"></a><span data-ttu-id="c3a14-163">アサーション</span><span class="sxs-lookup"><span data-stu-id="c3a14-163">Assertions</span></span>
<span data-ttu-id="c3a14-164">アプリケーションの内部の前提として、アサーションが用意されています。</span><span class="sxs-lookup"><span data-stu-id="c3a14-164">For internal assumptions in your application, there are assertions.</span></span> <span data-ttu-id="c3a14-165">可能な限り、コンパイル時の検証に **static_assert** を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c3a14-165">Prefer **static_assert** for compile-time validation, wherever possible.</span></span> <span data-ttu-id="c3a14-166">実行時条件には、ブール式による WINRT_ASSERT を使用します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-166">For run-time conditions, use WINRT_ASSERT with a Boolean expression.</span></span>

```cppwinrt
WINRT_ASSERT(pos < size());
```

<span data-ttu-id="c3a14-167">WINRT_ASSERT は、リテール ビルドでコンパイルされます。デバッグ用のビルドでは、アサーションがあるコード行でデバッガーでアプリケーションが停止します。</span><span class="sxs-lookup"><span data-stu-id="c3a14-167">WINRT_ASSERT is compiled away in release builds; in a debug build, it stops the application in the debugger on the line of code where the assertion is.</span></span>

<span data-ttu-id="c3a14-168">デストラクターで例外を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="c3a14-168">You shouldn't use exceptions in your destructors.</span></span> <span data-ttu-id="c3a14-169">そのため、少なくともデバッグ ビルドでは、WINRT_VERIFY (ブール式を含む) と WINRT_VERIFY_ (期待される結果とブール式を含む) を使用してデストラクターからの関数の呼び出しの結果をアサートできます。</span><span class="sxs-lookup"><span data-stu-id="c3a14-169">So, at least in debug builds, you can assert the result of calling a function from a destructor with WINRT_VERIFY (with a Boolean expression) and WINRT_VERIFY_ (with an expected result and a Boolean expression).</span></span>

```cppwinrt
WINRT_VERIFY(::CloseHandle(value));
WINRT_VERIFY_(TRUE, ::CloseHandle(value));
```

## <a name="important-apis"></a><span data-ttu-id="c3a14-170">重要な API</span><span class="sxs-lookup"><span data-stu-id="c3a14-170">Important APIs</span></span>
* [<span data-ttu-id="c3a14-171">winrt::check_bool 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3a14-171">winrt::check_bool function template</span></span>](/uwp/cpp-ref-for-winrt/error-handling/check-bool)
* [<span data-ttu-id="c3a14-172">winrt::check_hresult 関数</span><span class="sxs-lookup"><span data-stu-id="c3a14-172">winrt::check_hresult function</span></span>](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)
* [<span data-ttu-id="c3a14-173">winrt::check_nt 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3a14-173">winrt::check_nt function template</span></span>](/uwp/cpp-ref-for-winrt/error-handling/check-nt)
* [<span data-ttu-id="c3a14-174">winrt::check_pointer 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3a14-174">winrt::check_pointer function template</span></span>](/uwp/cpp-ref-for-winrt/error-handling/check-pointer)
* [<span data-ttu-id="c3a14-175">winrt::check_win32 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3a14-175">winrt::check_win32 function template</span></span>](/uwp/cpp-ref-for-winrt/error-handling/check-win32)
* [<span data-ttu-id="c3a14-176">winrt::handle 構造体</span><span class="sxs-lookup"><span data-stu-id="c3a14-176">winrt::handle struct</span></span>](/uwp/cpp-ref-for-winrt/handle)
* [<span data-ttu-id="c3a14-177">winrt::hresult_error 構造体</span><span class="sxs-lookup"><span data-stu-id="c3a14-177">winrt::hresult_error struct</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)
* [<span data-ttu-id="c3a14-178">winrt::throw_hresult 構造体</span><span class="sxs-lookup"><span data-stu-id="c3a14-178">winrt::throw_hresult function</span></span>](/uwp/cpp-ref-for-winrt/error-handling/throw-hresult)
* [<span data-ttu-id="c3a14-179">winrt::throw_last_error 構造体</span><span class="sxs-lookup"><span data-stu-id="c3a14-179">winrt::throw_last_error function</span></span>](/uwp/cpp-ref-for-winrt/error-handling/throw-last-error)
* [<span data-ttu-id="c3a14-180">winrt::to_hresult 構造体</span><span class="sxs-lookup"><span data-stu-id="c3a14-180">winrt::to_hresult function</span></span>](/uwp/cpp-ref-for-winrt/error-handling/to-hresult)

## <a name="related-topics"></a><span data-ttu-id="c3a14-181">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c3a14-181">Related topics</span></span>
* [<span data-ttu-id="c3a14-182">エラーと例外処理 (最新の C++)</span><span class="sxs-lookup"><span data-stu-id="c3a14-182">Errors and Exception Handling (Modern C++)</span></span>](/cpp/cpp/errors-and-exception-handling-modern-cpp)
* [<span data-ttu-id="c3a14-183">方法: 例外の安全性の設計</span><span class="sxs-lookup"><span data-stu-id="c3a14-183">How to: Design for Exception Safety</span></span>](/cpp/cpp/how-to-design-for-exception-safety)
