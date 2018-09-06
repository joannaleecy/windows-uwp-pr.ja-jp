---
author: stevewhims
description: C++/WinRT の使用をすぐに開始できるように、このトピックでは、単純なコード例について説明します。
title: C++/WinRT の概要
ms.author: stwhi
ms.date: 05/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 取得, 取得, 開始
ms.localizationpriority: medium
ms.openlocfilehash: 13aa1e61a2d81cfa7faed0236551dad41bd00057
ms.sourcegitcommit: 914b38559852aaefe7e9468f6f53a7465bf36e30
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3398924"
---
# <a name="get-started-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="24396-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) の概要</span><span class="sxs-lookup"><span data-stu-id="24396-104">Get started with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="24396-105">C++/WinRT の使用をすぐに開始できるように、このトピックでは、単純なコード例について説明します。</span><span class="sxs-lookup"><span data-stu-id="24396-105">To get you up to speed with using C++/WinRT, this topic walks through a simple code example.</span></span>

## <a name="a-cwinrt-quick-start"></a><span data-ttu-id="24396-106">C++/WinRT のクイックスタート</span><span class="sxs-lookup"><span data-stu-id="24396-106">A C++/WinRT quick-start</span></span>
> [!NOTE]
> <span data-ttu-id="24396-107">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24396-107">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

<span data-ttu-id="24396-108">新しい **Windows コンソール アプリケーション (C++/WinRT)** プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="24396-108">Create a new **Windows Console Application (C++/WinRT)** project.</span></span> <span data-ttu-id="24396-109">`pch.h` と `main.cpp` を次のように編集します。</span><span class="sxs-lookup"><span data-stu-id="24396-109">Edit `pch.h` and `main.cpp` to look like this.</span></span>

```cppwinrt
// pch.h
...
#include <iostream>
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
...
```

```cppwinrt
// main.cpp
#include "pch.h"

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

int main()
{
    winrt::init_apartment();

    Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    SyndicationClient syndicationClient;
    SyndicationFeed syndicationFeed = syndicationClient.RetrieveFeedAsync(rssFeedUri).get();
    for (const SyndicationItem syndicationItem : syndicationFeed.Items())
    {
        winrt::hstring titleAsHstring = syndicationItem.Title().Text();
        std::wcout << titleAsHstring.c_str() << std::endl;
    }
}
```

<span data-ttu-id="24396-110">上の簡単なコード例を 1 つずつ参照し、各部分に何が起こっているかを説明します。</span><span class="sxs-lookup"><span data-stu-id="24396-110">Let's take the short code example above piece by piece, and explain what's going on in each part.</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
```

<span data-ttu-id="24396-111">インクルードするヘッダーは SDK に含まれるもので、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt` フォルダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="24396-111">The headers that we include are part of the SDK, inside the folder `%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt`.</span></span> <span data-ttu-id="24396-112">Visual Studio には、その *IncludePath* マクロにそのパスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="24396-112">Visual Studio includes that path in its *IncludePath* macro.</span></span> <span data-ttu-id="24396-113">このヘッダーには、C++/WinRT に投影された Windows API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="24396-113">The headers contain Windows APIs projected into C++/WinRT.</span></span> <span data-ttu-id="24396-114">つまり、Windows の種類ごとに、C++/WinRT は C++ 対応の同等の型 (*投影された型*と呼ばれます) を定義します。</span><span class="sxs-lookup"><span data-stu-id="24396-114">In other words, for each Windows type, C++/WinRT defines a C++-friendly equivalent (called the *projected type*).</span></span> <span data-ttu-id="24396-115">投影された型には Windows の型と同じ完全修飾名がありますが、C++ **winrt** 名前空間に配置されます。</span><span class="sxs-lookup"><span data-stu-id="24396-115">A projected type has the same fully-qualified name as the Windows type, but it's placed in the C++ **winrt** namespace.</span></span> <span data-ttu-id="24396-116">これらのインクルードをプリコンパイル済みヘッダーに配置すると、段階的なビルド時間が短縮されます。</span><span class="sxs-lookup"><span data-stu-id="24396-116">Putting these includes in your precompiled header reduces incremental build times.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="24396-117">Windows 名前空間から型を使用する場合は、次に示すように、対応する C++/WinRT Windows 名前空間ヘッダー ファイルを含めます。</span><span class="sxs-lookup"><span data-stu-id="24396-117">Whenever you want to use a type from a Windows namespaces, include the corresponding C++/WinRT Windows namespace header file, as shown.</span></span> <span data-ttu-id="24396-118">*対応する*ヘッダーは、その型の名前空間と同じ名前を持つヘッダーです。</span><span class="sxs-lookup"><span data-stu-id="24396-118">The *corresponding* header is the one with the same name as the type's namespace.</span></span> <span data-ttu-id="24396-119">たとえば、C++/WinRT プロジェクションを [**Windows::Foundation::Collections::PropertySet**](/uwp/api/windows.foundation.collections.propertyset) ランタイム クラスに使用するには、`#include <winrt/Windows.Foundation.Collections.h>` を指定します。</span><span class="sxs-lookup"><span data-stu-id="24396-119">For example, to use the C++/WinRT projection for the [**Windows::Foundation::Collections::PropertySet**](/uwp/api/windows.foundation.collections.propertyset) runtime class, `#include <winrt/Windows.Foundation.Collections.h>`.</span></span>

```cppwinrt
using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;
```

<span data-ttu-id="24396-120">`using namespace` ディレクティブはオプションですが、便利です。</span><span class="sxs-lookup"><span data-stu-id="24396-120">The `using namespace` directives are optional, but convenient.</span></span> <span data-ttu-id="24396-121">(**winrt** 名前空間で非修飾名による参照を許可する) ディレクティブに関する上記のパターンは、新しいプロジェクトを開始する場合に最適です。また、C++/WinRT はそのプロジェクト内で使用する唯一の言語プロジェクションです)。</span><span class="sxs-lookup"><span data-stu-id="24396-121">The pattern shown above for such directives (allowing unqualified name lookup for anything in the **winrt** namespace) is suitable for when you're beginning a new project and C++/WinRT is the only language projection you're using inside of that project.</span></span> <span data-ttu-id="24396-122">一方、C++/WinRT コードを [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) および SDK アプリケーション バイナリ インターフェイス (ABI) コードと混在させている (これらのモデルのいずれかまたは両方から移植しているか、相互運用している) 場合は、「[C++/WinRT と C++/CX 間の相互運用](interop-winrt-cx.md)」、「[C++/CX から C++/WinRT への移動](move-to-winrt-from-cx.md)」、「[C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md)」のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="24396-122">If, on the other hand, you're mixing C++/WinRT code with [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) and/or SDK application binary interface (ABI) code (you're either porting from, or interoperating with, one or both of those models), then see the topics [Interop between C++/WinRT and C++/CX](interop-winrt-cx.md), [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md), and [Interop between C++/WinRT and the ABI](interop-winrt-abi.md).</span></span>

```cppwinrt
winrt::init_apartment();
```

<span data-ttu-id="24396-123">**winrt::init_apartment** への呼び出しにより、既定では、マルチスレッド アパートメントで COM が初期化されます。</span><span class="sxs-lookup"><span data-stu-id="24396-123">The call to **winrt::init_apartment** initializes COM; by default, in a multithreaded apartment.</span></span>

```cppwinrt
Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
SyndicationClient syndicationClient;
```

<span data-ttu-id="24396-124">2 つのオブジェクトをスタックに割り当てます。これらのオブジェクトは Windows ブログの URI と配信クライアントを表します。</span><span class="sxs-lookup"><span data-stu-id="24396-124">Stack-allocate two objects: they represent the uri of the Windows blog, and a syndication client.</span></span> <span data-ttu-id="24396-125">単純なワイド文字列リテラルで URI を作成します (その他の文字列の操作方法については、「[C++/WinRT での文字列の処理](strings.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="24396-125">We construct the uri with a simple wide string literal (see [String handling in C++/WinRT](strings.md) for more ways you can work with strings).</span></span>

```cppwinrt
SyndicationFeed syndicationFeed = syndicationClient.RetrieveFeedAsync(rssFeedUri).get();
```

<span data-ttu-id="24396-126">[**SyndicationClient::RetrieveFeedAsync**](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、非同期 Windows ランタイム関数の例です。</span><span class="sxs-lookup"><span data-stu-id="24396-126">[**SyndicationClient::RetrieveFeedAsync**](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) is an example of an asynchronous Windows Runtime function.</span></span> <span data-ttu-id="24396-127">コード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、呼び出しスレッドをブロックし、その結果 (この場合は配信フィード) を待機するように、このオブジェクトで **get** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="24396-127">The code example receives an asynchronous operation object from **RetrieveFeedAsync**, and it calls **get** on that object to block the calling thread and wait for the result (which is a syndication feed, in this case).</span></span> <span data-ttu-id="24396-128">同時実行、および非ブロッキングの手法の詳細については、「[C++/WinRT での同時実行と非同期操作](concurrency.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24396-128">For more about concurrency, and for non-blocking techniques, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md).</span></span>

```cppwinrt
for (const SyndicationItem syndicationItem : syndicationFeed.Items()) { ... }
```

<span data-ttu-id="24396-129">[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) は、**begin** および **end** 関数 (またはそれらの定数、逆、および定数逆バリアント) から返される反復子によって定義される範囲です。</span><span class="sxs-lookup"><span data-stu-id="24396-129">[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) is a range, defined by the iterators returned from **begin** and **end** functions (or their constant, reverse, and constant-reverse variants).</span></span> <span data-ttu-id="24396-130">このため、範囲ベースの `for` ステートメント、または **std::for_each** テンプレート関数とともに **Items** を列挙できます。</span><span class="sxs-lookup"><span data-stu-id="24396-130">Because of this, you can enumerate **Items** with either a range-based `for` statement, or with the **std::for_each** template function.</span></span>

```cppwinrt
winrt::hstring titleAsHstring = syndicationItem.Title().Text();
std::wcout << titleAsHstring.c_str() << std::endl;
```

<span data-ttu-id="24396-131">フィードのタイトル テキストを、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) オブジェクトとして取得します (詳細については「[C++/WinRT での文字列処理](strings.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="24396-131">Gets the feed's title text, as a [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) object (more details in [String handling in C++/WinRT](strings.md)).</span></span> <span data-ttu-id="24396-132">次に **c_str** 関数で **hstring** が出力され、C++ 標準ライブラリの文字列で使用されるパターンが反映されます。</span><span class="sxs-lookup"><span data-stu-id="24396-132">The **hstring** is then output, via the **c_str** function, which reflects the pattern used with C++ Standard Library strings.</span></span>

<span data-ttu-id="24396-133">おわかりのように、C++/WinRT では、`syndicationItem.Title().Text()` などの、最新のクラスのような C++ の式を奨励しています。</span><span class="sxs-lookup"><span data-stu-id="24396-133">As you can see, C++/WinRT encourages modern, and class-like, C++ expressions such as `syndicationItem.Title().Text()`.</span></span> <span data-ttu-id="24396-134">これは、従来の COM プログラミングとは異なる、よりクリーンなプログラミング スタイルです。</span><span class="sxs-lookup"><span data-stu-id="24396-134">This is a different, and cleaner, programming style from traditional COM programming.</span></span> <span data-ttu-id="24396-135">直接 COM を初期化し、COM ポインターを操作する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="24396-135">You don't need to directly initialize COM, work with COM pointers.</span></span>

<span data-ttu-id="24396-136">HRESULT リターン コードを処理する必要もありません。</span><span class="sxs-lookup"><span data-stu-id="24396-136">Nor do you need to handle HRESULT return codes.</span></span> <span data-ttu-id="24396-137">C++/WinRT では、エラーの HRESULT を [**winrt::hresult-error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) のような自然かつ最新のプログラミング スタイルの例外に変換します。</span><span class="sxs-lookup"><span data-stu-id="24396-137">C++/WinRT converts error HRESULTs to exceptions such as [**winrt::hresult-error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) for a natural and modern programming style.</span></span> <span data-ttu-id="24396-138">エラー処理の詳細とコード例の詳細については、「[C++/WinRT でのエラー処理](error-handling.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24396-138">For more info about error-handling, and code examples, see [Error handling with C++/WinRT](error-handling.md).</span></span>

## <a name="important-apis"></a><span data-ttu-id="24396-139">重要な API</span><span class="sxs-lookup"><span data-stu-id="24396-139">Important APIs</span></span>
* [<span data-ttu-id="24396-140">SyndicationClient::RetrieveFeedAsync</span><span class="sxs-lookup"><span data-stu-id="24396-140">SyndicationClient::RetrieveFeedAsync</span></span>](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [<span data-ttu-id="24396-141">SyndicationFeed.Items</span><span class="sxs-lookup"><span data-stu-id="24396-141">SyndicationFeed.Items</span></span>](/uwp/api/windows.web.syndication.syndicationfeed.items)
* [<span data-ttu-id="24396-142">winrt::hstring 構造体</span><span class="sxs-lookup"><span data-stu-id="24396-142">winrt::hstring struct</span></span>](/uwp/cpp-ref-for-winrt/hstring)
* [<span data-ttu-id="24396-143">winrt::hresul エラー</span><span class="sxs-lookup"><span data-stu-id="24396-143">winrt::hresult-error</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)

## <a name="related-topics"></a><span data-ttu-id="24396-144">関連トピック</span><span class="sxs-lookup"><span data-stu-id="24396-144">Related topics</span></span>
* [<span data-ttu-id="24396-145">C++/CX</span><span class="sxs-lookup"><span data-stu-id="24396-145">C++/CX</span></span>](/cpp/cppcx/visual-c-language-reference-c-cx)
* [<span data-ttu-id="24396-146">C++/WinRT でのエラー処理</span><span class="sxs-lookup"><span data-stu-id="24396-146">Error handling with C++/WinRT</span></span>](error-handling.md)
* [<span data-ttu-id="24396-147">C++/WinRT と C++/CX 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="24396-147">Interop between C++/WinRT and C++/CX</span></span>](interop-winrt-cx.md)
* [<span data-ttu-id="24396-148">C++/WinRT と ABI 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="24396-148">Interop between C++/WinRT and the ABI</span></span>](interop-winrt-abi.md)
* [<span data-ttu-id="24396-149">C++/CX から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="24396-149">Move to C++/WinRT from C++/CX</span></span>](move-to-winrt-from-cx.md)
* [<span data-ttu-id="24396-150">C++/WinRT での文字列の処理</span><span class="sxs-lookup"><span data-stu-id="24396-150">String handling in C++/WinRT</span></span>](strings.md)
