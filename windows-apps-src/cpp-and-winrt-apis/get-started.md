---
author: stevewhims
description: C++/WinRT の使用をすぐに開始できるように、このトピックでは、単純なコード例について説明します。
title: C++/WinRT の概要
ms.author: stwhi
ms.date: 10/19/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 取得, 取得, 開始
ms.localizationpriority: medium
ms.openlocfilehash: 6cb8e18904f61976103689c8d83475ec248eb38b
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6460846"
---
# <a name="get-started-with-cwinrt"></a><span data-ttu-id="5a707-104">C++/WinRT の使用を開始する</span><span class="sxs-lookup"><span data-stu-id="5a707-104">Get started with C++/WinRT</span></span>

<span data-ttu-id="5a707-105">使用してにすぐ開始[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、このトピックでは、新しいに基づいて単純なコード例を**Windows コンソール アプリケーション (、C++/WinRT)** プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="5a707-105">To get you up to speed with using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), this topic walks through a simple code example based on a new **Windows Console Application (C++/WinRT)** project.</span></span> <span data-ttu-id="5a707-106">このトピックで説明する方法[追加 C + + Windows デスクトップ アプリケーション プロジェクトに WinRT サポート](#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。</span><span class="sxs-lookup"><span data-stu-id="5a707-106">This topic also shows how to [add C++/WinRT support to a Windows Desktop application project](#modify-a-windows-desktop-application-project-to-add-cwinrt-support).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="5a707-107">Visual Studio 2017 を使用している場合 (バージョン 15.8.0 以降) をターゲットとする Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) し、新しく作成した、C++/WinRT プロジェクトをコンパイル エラーで失敗する可能性が"*エラー C3861: 'from_abi': 識別子しません。見つかった*"、および*base.h*でその他のエラー。</span><span class="sxs-lookup"><span data-stu-id="5a707-107">If you're using Visual Studio 2017 (version 15.8.0 or higher), and targeting the Windows SDK version 10.0.17134.0 (Windows 10, version 1803), then a newly created C++/WinRT project may fail to compile with the error "*error C3861: 'from_abi': identifier not found*", and with other errors originating in *base.h*.</span></span> <span data-ttu-id="5a707-108">解決策は、いずれかのターゲット以降 (詳しく準拠) のバージョンの Windows SDK、またはプロジェクトのプロパティを設定する**C/C++** > **言語** > **Conformance mode: いいえ**(また場合、 **/制限解除-** **プロジェクトのプロパティに表示されますC/C++** > **言語** > **コマンド ライン**[**その他のオプション**を削除します)。</span><span class="sxs-lookup"><span data-stu-id="5a707-108">The solution is to either target a later (more conformant) version of the Windows SDK, or set project property **C/C++** > **Language** > **Conformance mode: No** (also, if **/permissive-** appears in project property **C/C++** > **Language** > **Command Line** under **Additional Options**, then delete it).</span></span>

## <a name="a-cwinrt-quick-start"></a><span data-ttu-id="5a707-109">C++/WinRT のクイックスタート</span><span class="sxs-lookup"><span data-stu-id="5a707-109">A C++/WinRT quick-start</span></span>

> [!NOTE]
> <span data-ttu-id="5a707-110">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5a707-110">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

<span data-ttu-id="5a707-111">新しい **Windows コンソール アプリケーション (C++/WinRT)** プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="5a707-111">Create a new **Windows Console Application (C++/WinRT)** project.</span></span>

<span data-ttu-id="5a707-112">`pch.h` と `main.cpp` を次のように編集します。</span><span class="sxs-lookup"><span data-stu-id="5a707-112">Edit `pch.h` and `main.cpp` to look like this.</span></span>

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

<span data-ttu-id="5a707-113">上の簡単なコード例を 1 つずつ参照し、各部分に何が起こっているかを説明します。</span><span class="sxs-lookup"><span data-stu-id="5a707-113">Let's take the short code example above piece by piece, and explain what's going on in each part.</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
```

<span data-ttu-id="5a707-114">インクルードするヘッダーは SDK に含まれるもので、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt` フォルダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="5a707-114">The headers that we include are part of the SDK, inside the folder `%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt`.</span></span> <span data-ttu-id="5a707-115">Visual Studio には、その *IncludePath* マクロにそのパスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="5a707-115">Visual Studio includes that path in its *IncludePath* macro.</span></span> <span data-ttu-id="5a707-116">このヘッダーには、C++/WinRT に投影された Windows API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="5a707-116">The headers contain Windows APIs projected into C++/WinRT.</span></span> <span data-ttu-id="5a707-117">つまり、Windows の種類ごとに、C++/WinRT は C++ 対応の同等の型 (*投影された型*と呼ばれます) を定義します。</span><span class="sxs-lookup"><span data-stu-id="5a707-117">In other words, for each Windows type, C++/WinRT defines a C++-friendly equivalent (called the *projected type*).</span></span> <span data-ttu-id="5a707-118">投影された型には Windows の型と同じ完全修飾名がありますが、C++ **winrt** 名前空間に配置されます。</span><span class="sxs-lookup"><span data-stu-id="5a707-118">A projected type has the same fully-qualified name as the Windows type, but it's placed in the C++ **winrt** namespace.</span></span> <span data-ttu-id="5a707-119">これらのインクルードをプリコンパイル済みヘッダーに配置すると、段階的なビルド時間が短縮されます。</span><span class="sxs-lookup"><span data-stu-id="5a707-119">Putting these includes in your precompiled header reduces incremental build times.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="5a707-120">Windows 名前空間から型を使用する場合は、次に示すように、対応する C++/WinRT Windows 名前空間ヘッダー ファイルを含めます。</span><span class="sxs-lookup"><span data-stu-id="5a707-120">Whenever you want to use a type from a Windows namespaces, include the corresponding C++/WinRT Windows namespace header file, as shown.</span></span> <span data-ttu-id="5a707-121">*対応する*ヘッダーは、その型の名前空間と同じ名前を持つヘッダーです。</span><span class="sxs-lookup"><span data-stu-id="5a707-121">The *corresponding* header is the one with the same name as the type's namespace.</span></span> <span data-ttu-id="5a707-122">たとえば、C++/WinRT プロジェクションを [**Windows::Foundation::Collections::PropertySet**](/uwp/api/windows.foundation.collections.propertyset) ランタイム クラスに使用するには、`#include <winrt/Windows.Foundation.Collections.h>` を指定します。</span><span class="sxs-lookup"><span data-stu-id="5a707-122">For example, to use the C++/WinRT projection for the [**Windows::Foundation::Collections::PropertySet**](/uwp/api/windows.foundation.collections.propertyset) runtime class, `#include <winrt/Windows.Foundation.Collections.h>`.</span></span>

```cppwinrt
using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;
```

<span data-ttu-id="5a707-123">`using namespace` ディレクティブはオプションですが、便利です。</span><span class="sxs-lookup"><span data-stu-id="5a707-123">The `using namespace` directives are optional, but convenient.</span></span> <span data-ttu-id="5a707-124">(**winrt** 名前空間で非修飾名による参照を許可する) ディレクティブに関する上記のパターンは、新しいプロジェクトを開始する場合に最適です。また、C++/WinRT はそのプロジェクト内で使用する唯一の言語プロジェクションです)。</span><span class="sxs-lookup"><span data-stu-id="5a707-124">The pattern shown above for such directives (allowing unqualified name lookup for anything in the **winrt** namespace) is suitable for when you're beginning a new project and C++/WinRT is the only language projection you're using inside of that project.</span></span> <span data-ttu-id="5a707-125">一方、C++/WinRT コードを [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) および SDK アプリケーション バイナリ インターフェイス (ABI) コードと混在させている (これらのモデルのいずれかまたは両方から移植しているか、相互運用している) 場合は、「[C++/WinRT と C++/CX 間の相互運用](interop-winrt-cx.md)」、「[C++/CX から C++/WinRT への移動](move-to-winrt-from-cx.md)」、「[C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md)」のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="5a707-125">If, on the other hand, you're mixing C++/WinRT code with [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) and/or SDK application binary interface (ABI) code (you're either porting from, or interoperating with, one or both of those models), then see the topics [Interop between C++/WinRT and C++/CX](interop-winrt-cx.md), [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md), and [Interop between C++/WinRT and the ABI](interop-winrt-abi.md).</span></span>

```cppwinrt
winrt::init_apartment();
```

<span data-ttu-id="5a707-126">**winrt::init_apartment** への呼び出しにより、既定では、マルチスレッド アパートメントで COM が初期化されます。</span><span class="sxs-lookup"><span data-stu-id="5a707-126">The call to **winrt::init_apartment** initializes COM; by default, in a multithreaded apartment.</span></span>

```cppwinrt
Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
SyndicationClient syndicationClient;
```

<span data-ttu-id="5a707-127">2 つのオブジェクトをスタックに割り当てます。これらのオブジェクトは Windows ブログの URI と配信クライアントを表します。</span><span class="sxs-lookup"><span data-stu-id="5a707-127">Stack-allocate two objects: they represent the uri of the Windows blog, and a syndication client.</span></span> <span data-ttu-id="5a707-128">単純なワイド文字列リテラルで URI を作成します (その他の文字列の操作方法については、「[C++/WinRT での文字列の処理](strings.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="5a707-128">We construct the uri with a simple wide string literal (see [String handling in C++/WinRT](strings.md) for more ways you can work with strings).</span></span>

```cppwinrt
SyndicationFeed syndicationFeed = syndicationClient.RetrieveFeedAsync(rssFeedUri).get();
```

<span data-ttu-id="5a707-129">[**SyndicationClient::RetrieveFeedAsync**](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、非同期 Windows ランタイム関数の例です。</span><span class="sxs-lookup"><span data-stu-id="5a707-129">[**SyndicationClient::RetrieveFeedAsync**](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) is an example of an asynchronous Windows Runtime function.</span></span> <span data-ttu-id="5a707-130">コード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、呼び出しスレッドをブロックし、その結果 (この場合は配信フィード) を待機するように、このオブジェクトで **get** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5a707-130">The code example receives an asynchronous operation object from **RetrieveFeedAsync**, and it calls **get** on that object to block the calling thread and wait for the result (which is a syndication feed, in this case).</span></span> <span data-ttu-id="5a707-131">同時実行、および非ブロッキングの手法の詳細については、「[C++/WinRT での同時実行と非同期操作](concurrency.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5a707-131">For more about concurrency, and for non-blocking techniques, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md).</span></span>

```cppwinrt
for (const SyndicationItem syndicationItem : syndicationFeed.Items()) { ... }
```

<span data-ttu-id="5a707-132">[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) は、**begin** および **end** 関数 (またはそれらの定数、逆、および定数逆バリアント) から返される反復子によって定義される範囲です。</span><span class="sxs-lookup"><span data-stu-id="5a707-132">[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) is a range, defined by the iterators returned from **begin** and **end** functions (or their constant, reverse, and constant-reverse variants).</span></span> <span data-ttu-id="5a707-133">このため、範囲ベースの `for` ステートメント、または **std::for_each** テンプレート関数とともに **Items** を列挙できます。</span><span class="sxs-lookup"><span data-stu-id="5a707-133">Because of this, you can enumerate **Items** with either a range-based `for` statement, or with the **std::for_each** template function.</span></span>

```cppwinrt
winrt::hstring titleAsHstring = syndicationItem.Title().Text();
std::wcout << titleAsHstring.c_str() << std::endl;
```

<span data-ttu-id="5a707-134">フィードのタイトル テキストを、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) オブジェクトとして取得します (詳細については「[C++/WinRT での文字列処理](strings.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="5a707-134">Gets the feed's title text, as a [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) object (more details in [String handling in C++/WinRT](strings.md)).</span></span> <span data-ttu-id="5a707-135">次に **c_str** 関数で **hstring** が出力され、C++ 標準ライブラリの文字列で使用されるパターンが反映されます。</span><span class="sxs-lookup"><span data-stu-id="5a707-135">The **hstring** is then output, via the **c_str** function, which reflects the pattern used with C++ Standard Library strings.</span></span>

<span data-ttu-id="5a707-136">おわかりのように、C++/WinRT では、`syndicationItem.Title().Text()` などの、最新のクラスのような C++ の式を奨励しています。</span><span class="sxs-lookup"><span data-stu-id="5a707-136">As you can see, C++/WinRT encourages modern, and class-like, C++ expressions such as `syndicationItem.Title().Text()`.</span></span> <span data-ttu-id="5a707-137">これは、従来の COM プログラミングとは異なる、よりクリーンなプログラミング スタイルです。</span><span class="sxs-lookup"><span data-stu-id="5a707-137">This is a different, and cleaner, programming style from traditional COM programming.</span></span> <span data-ttu-id="5a707-138">直接 COM を初期化し、COM ポインターを操作する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5a707-138">You don't need to directly initialize COM, work with COM pointers.</span></span>

<span data-ttu-id="5a707-139">HRESULT リターン コードを処理する必要もありません。</span><span class="sxs-lookup"><span data-stu-id="5a707-139">Nor do you need to handle HRESULT return codes.</span></span> <span data-ttu-id="5a707-140">C++/WinRT では、エラーの HRESULT を [**winrt::hresult-error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) のような自然かつ最新のプログラミング スタイルの例外に変換します。</span><span class="sxs-lookup"><span data-stu-id="5a707-140">C++/WinRT converts error HRESULTs to exceptions such as [**winrt::hresult-error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) for a natural and modern programming style.</span></span> <span data-ttu-id="5a707-141">エラー処理の詳細とコード例の詳細については、「[C++/WinRT でのエラー処理](error-handling.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5a707-141">For more info about error-handling, and code examples, see [Error handling with C++/WinRT](error-handling.md).</span></span>

## <a name="modify-a-windows-desktop-application-project-to-add-cwinrt-support"></a><span data-ttu-id="5a707-142">追加するには、C++ の Windows デスクトップ アプリケーション プロジェクトを変更する/WinRT のサポート</span><span class="sxs-lookup"><span data-stu-id="5a707-142">Modify a Windows Desktop application project to add C++/WinRT support</span></span>

<span data-ttu-id="5a707-143">このセクションでは、追加する方法、C++/cli/winrt サポートする必要があります Windows デスクトップ アプリケーション プロジェクトをします。</span><span class="sxs-lookup"><span data-stu-id="5a707-143">This section shows you how you can add C++/WinRT support to a Windows Desktop application project that you might have.</span></span> <span data-ttu-id="5a707-144">しないがある場合、既存の Windows デスクトップ アプリケーション プロジェクトで作成する最初のいずれかで次の手順に従ってすることができます。</span><span class="sxs-lookup"><span data-stu-id="5a707-144">If you don't have an existing Windows Desktop application project, then you can follow along with these steps by first creating one.</span></span> <span data-ttu-id="5a707-145">たとえば、Visual Studio を開き、 **Visual C**を作成 \> **Windows デスクトップ** \> **Windows デスクトップ アプリケーション**プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="5a707-145">For example, open Visual Studio and create a **Visual C++** \> **Windows Desktop** \> **Windows Desktop Application** project.</span></span>

### <a name="set-project-properties"></a><span data-ttu-id="5a707-146">プロジェクトのプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="5a707-146">Set project properties</span></span>

<span data-ttu-id="5a707-147">**一般的な**プロパティをプロジェクトに移動する \> **Windows SDK バージョン**、および選択の**すべての構成**と**すべてのプラットフォーム**です。</span><span class="sxs-lookup"><span data-stu-id="5a707-147">Go to project property **General** \> **Windows SDK Version**, and select **All Configurations** and **All Platforms**.</span></span> <span data-ttu-id="5a707-148">**Windows SDK バージョン**を 10.0.17134.0 (Windows 10、バージョン 1803) に設定されていることを確認またはそれ以上。</span><span class="sxs-lookup"><span data-stu-id="5a707-148">Ensure that **Windows SDK Version** is set to 10.0.17134.0 (Windows 10, version 1803) or greater.</span></span>

<span data-ttu-id="5a707-149">いる影響を受けないことを確認[新しいプロジェクトがコンパイルされません理由ですか?](/windows/uwp/cpp-and-winrt-apis/faq)します。</span><span class="sxs-lookup"><span data-stu-id="5a707-149">Confirm that you're not affected by [Why won't my new project compile?](/windows/uwp/cpp-and-winrt-apis/faq).</span></span>

<span data-ttu-id="5a707-150">C++/WinRT の c++ 17 標準から機能を使用して、プロジェクト プロパティ**C/C++** 設定 > **言語** > **標準的な C++ 言語**に*ISO C 17 標準 (//std:c では 17)* します。</span><span class="sxs-lookup"><span data-stu-id="5a707-150">Because C++/WinRT uses features from the C++17 standard, set project property **C/C++** > **Language** > **C++ Language Standard** to *ISO C++17 Standard (/std:c++17)*.</span></span>

### <a name="the-precompiled-header"></a><span data-ttu-id="5a707-151">プリコンパイル済みヘッダー</span><span class="sxs-lookup"><span data-stu-id="5a707-151">The precompiled header</span></span>

<span data-ttu-id="5a707-152">名前を変更して`stdafx.h`と`stdafx.cpp`を`pch.h`と`pch.cpp`、それぞれします。</span><span class="sxs-lookup"><span data-stu-id="5a707-152">Rename your `stdafx.h` and `stdafx.cpp` to `pch.h` and `pch.cpp`, respectively.</span></span> <span data-ttu-id="5a707-153">**C/C++** プロジェクトのプロパティを設定 > **プリコンパイル済みヘッダー** >  *pch.h*を**プリコンパイル済みヘッダー ファイル**です。</span><span class="sxs-lookup"><span data-stu-id="5a707-153">Set project property **C/C++** > **Precompiled Headers** > **Precompiled Header File** to *pch.h*.</span></span>

<span data-ttu-id="5a707-154">検索し、置換すべて`#include "stdafx.h"`と`#include "pch.h"`します。</span><span class="sxs-lookup"><span data-stu-id="5a707-154">Find and replace all `#include "stdafx.h"` with `#include "pch.h"`.</span></span>

<span data-ttu-id="5a707-155">`pch.h`、含める`winrt/base.h`します。</span><span class="sxs-lookup"><span data-stu-id="5a707-155">In `pch.h`, include `winrt/base.h`.</span></span>

```cppwinrt
// pch.h
...
#include <winrt/base.h>
```

### <a name="linking"></a><span data-ttu-id="5a707-156">リンク</span><span class="sxs-lookup"><span data-stu-id="5a707-156">Linking</span></span>

<span data-ttu-id="5a707-157">C++/cli [WindowsApp.lib](/uwp/win32-and-com/win32-apis)包括的なライブラリへのリンクは/winrt 言語プロジェクションは、特定の Windows ランタイムの自由 (非メンバー) 関数とエントリ ポイントに依存するを必要とします。</span><span class="sxs-lookup"><span data-stu-id="5a707-157">The C++/WinRT language projection depends on certain Windows Runtime free (non-member) functions, and entry points, that require linking to the [WindowsApp.lib](/uwp/win32-and-com/win32-apis) umbrella library.</span></span> <span data-ttu-id="5a707-158">このセクションでは、リンカーを満たすの 3 つの方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a707-158">This section describes three ways of satisfying the linker.</span></span>

<span data-ttu-id="5a707-159">最初のオプションは、Visual Studio を追加するプロジェクトのすべての c++/cli/winrt MSBuild プロパティとターゲット。</span><span class="sxs-lookup"><span data-stu-id="5a707-159">The first option is to add to your Visual Studio project all of the C++/WinRT MSBuild properties and targets.</span></span> <span data-ttu-id="5a707-160">編集、`.vcxproj`ファイルで、見つけ`<PropertyGroup Label="Globals">`そのプロパティ グループ内でプロパティを設定して、`<CppWinRTEnabled>true</CppWinRTEnabled>`します。</span><span class="sxs-lookup"><span data-stu-id="5a707-160">Edit your `.vcxproj` file, find `<PropertyGroup Label="Globals">` and, inside that property group, set the property `<CppWinRTEnabled>true</CppWinRTEnabled>`.</span></span>

<span data-ttu-id="5a707-161">明示的にリンクするプロジェクトのリンク設定を使用する代わりに、`WindowsApp.lib`します。</span><span class="sxs-lookup"><span data-stu-id="5a707-161">Alternatively, you can use project link settings to explicitly link `WindowsApp.lib`.</span></span>

<span data-ttu-id="5a707-162">または、ソース コードで行うことができます (で`pch.h`など) のようにします。</span><span class="sxs-lookup"><span data-stu-id="5a707-162">Or, you can do it in source code (in `pch.h`, for example) like this.</span></span>

```cppwinrt
#pragma comment(lib, "windowsapp")
```

<span data-ttu-id="5a707-163">ようになりましたコンパイルし、リンクを追加でき、C++/cli をプロジェクトに WinRT コード (に示すコード例では、 [A 内容//winrt のクイック スタート](#a-cwinrt-quick-start)セクションは、上記の)</span><span class="sxs-lookup"><span data-stu-id="5a707-163">You can now compile and link, and add C++/WinRT code to your project (for example, the code shown in the [A C++/WinRT quick-start](#a-cwinrt-quick-start) section, above)</span></span>

## <a name="important-apis"></a><span data-ttu-id="5a707-164">重要な API</span><span class="sxs-lookup"><span data-stu-id="5a707-164">Important APIs</span></span>
* [<span data-ttu-id="5a707-165">Syndicationclient::retrievefeedasync メソッド</span><span class="sxs-lookup"><span data-stu-id="5a707-165">SyndicationClient::RetrieveFeedAsync method</span></span>](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [<span data-ttu-id="5a707-166">SyndicationFeed.Items プロパティ</span><span class="sxs-lookup"><span data-stu-id="5a707-166">SyndicationFeed.Items property</span></span>](/uwp/api/windows.web.syndication.syndicationfeed.items)
* [<span data-ttu-id="5a707-167">winrt::hstring 構造体</span><span class="sxs-lookup"><span data-stu-id="5a707-167">winrt::hstring struct</span></span>](/uwp/cpp-ref-for-winrt/hstring)
* [<span data-ttu-id="5a707-168">:hresult-error 構造体</span><span class="sxs-lookup"><span data-stu-id="5a707-168">winrt::hresult-error struct</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)

## <a name="related-topics"></a><span data-ttu-id="5a707-169">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5a707-169">Related topics</span></span>
* [<span data-ttu-id="5a707-170">C++/CX</span><span class="sxs-lookup"><span data-stu-id="5a707-170">C++/CX</span></span>](/cpp/cppcx/visual-c-language-reference-c-cx)
* [<span data-ttu-id="5a707-171">C++/WinRT でのエラー処理</span><span class="sxs-lookup"><span data-stu-id="5a707-171">Error handling with C++/WinRT</span></span>](error-handling.md)
* [<span data-ttu-id="5a707-172">C++/WinRT と C++/CX 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="5a707-172">Interop between C++/WinRT and C++/CX</span></span>](interop-winrt-cx.md)
* [<span data-ttu-id="5a707-173">C++/WinRT と ABI 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="5a707-173">Interop between C++/WinRT and the ABI</span></span>](interop-winrt-abi.md)
* [<span data-ttu-id="5a707-174">C++/CX から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="5a707-174">Move to C++/WinRT from C++/CX</span></span>](move-to-winrt-from-cx.md)
* [<span data-ttu-id="5a707-175">C++/WinRT での文字列の処理</span><span class="sxs-lookup"><span data-stu-id="5a707-175">String handling in C++/WinRT</span></span>](strings.md)
