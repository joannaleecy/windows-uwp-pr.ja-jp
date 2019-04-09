---
description: C++/WinRT の使用をすぐに開始できるように、このトピックでは、単純なコード例について説明します。
title: C++/WinRT の使用を開始する
ms.date: 04/03/2019
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 取得, 取得, 開始
ms.localizationpriority: medium
ms.openlocfilehash: 4928540d9b6e7e1c3df67f7c247aa3664618a65c
ms.sourcegitcommit: c315ec3e17489aeee19f5095ec4af613ad2837e1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2019
ms.locfileid: "58921688"
---
# <a name="get-started-with-cwinrt"></a><span data-ttu-id="4ecd2-104">C++/WinRT の使用を開始する</span><span class="sxs-lookup"><span data-stu-id="4ecd2-104">Get started with C++/WinRT</span></span>

<span data-ttu-id="4ecd2-105">使用して短縮にするため[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、このトピックでは、新しいに基づいて単純なコード例によって説明**Windows コンソール アプリケーション (C +/cli WinRT)** プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-105">To get you up to speed with using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), this topic walks through a simple code example based on a new **Windows Console Application (C++/WinRT)** project.</span></span> <span data-ttu-id="4ecd2-106">このトピックで説明する方法[追加 C +/cli WinRT サポートし、Windows デスクトップ アプリケーション プロジェクトに](#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-106">This topic also shows how to [add C++/WinRT support to a Windows Desktop application project](#modify-a-windows-desktop-application-project-to-add-cwinrt-support).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4ecd2-107">Visual Studio 2017 を使用している場合 (バージョン 15.8.0 またはそれ以降)、し、新しく作成した Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) を対象としてC++WinRT プロジェクトがエラーでコンパイルに失敗する可能性があります/"*エラー C3861: 'from_abi'。識別子が見つかりません*"、発信元がその他のエラーの*base.h*します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-107">If you're using Visual Studio 2017 (version 15.8.0 or higher), and targeting the Windows SDK version 10.0.17134.0 (Windows 10, version 1803), then a newly created C++/WinRT project may fail to compile with the error "*error C3861: 'from_abi': identifier not found*", and with other errors originating in *base.h*.</span></span> <span data-ttu-id="4ecd2-108">いずれかのターゲットに以降 (詳細について準拠) は、ソリューションのバージョンの Windows SDK、またはプロジェクトのプロパティを設定**C/C++** > **言語** > **準拠モード。いいえ**(また場合、 **/permissive -** プロジェクト プロパティに表示されます**C/C++** > **言語** > **コマンドライン** **追加オプション**から削除します)。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-108">The solution is to either target a later (more conformant) version of the Windows SDK, or set project property **C/C++** > **Language** > **Conformance mode: No** (also, if **/permissive-** appears in project property **C/C++** > **Language** > **Command Line** under **Additional Options**, then delete it).</span></span>

## <a name="a-cwinrt-quick-start"></a><span data-ttu-id="4ecd2-109">C++/WinRT のクイックスタート</span><span class="sxs-lookup"><span data-stu-id="4ecd2-109">A C++/WinRT quick-start</span></span>

> [!NOTE]
> <span data-ttu-id="4ecd2-110">インストールと使用について、 C++WinRT Visual Studio Extension (VSIX) と (をまとめてプロジェクト テンプレートを提供し、ビルドのサポート)、NuGet パッケージを参照してください。 [Visual Studio のサポートC++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-110">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) and the NuGet package (which together provide project template and build support), see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package).</span></span>

<span data-ttu-id="4ecd2-111">新しい **Windows コンソール アプリケーション (C++/WinRT)** プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-111">Create a new **Windows Console Application (C++/WinRT)** project.</span></span>

<span data-ttu-id="4ecd2-112">`pch.h` と `main.cpp` を次のように編集します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-112">Edit `pch.h` and `main.cpp` to look like this.</span></span>

```cppwinrt
// pch.h
...
#include <iostream>
#include <winrt/Windows.Foundation.Collections.h>
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

<span data-ttu-id="4ecd2-113">上の簡単なコード例を 1 つずつ参照し、各部分に何が起こっているかを説明します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-113">Let's take the short code example above piece by piece, and explain what's going on in each part.</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.Collections.h>
#include <winrt/Windows.Web.Syndication.h>
```

<span data-ttu-id="4ecd2-114">インクルードするヘッダーは SDK に含まれるもので、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt` フォルダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-114">The headers that we include are part of the SDK, inside the folder `%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt`.</span></span> <span data-ttu-id="4ecd2-115">Visual Studio には、その *IncludePath* マクロにそのパスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-115">Visual Studio includes that path in its *IncludePath* macro.</span></span> <span data-ttu-id="4ecd2-116">このヘッダーには、C++/WinRT に投影された Windows API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-116">The headers contain Windows APIs projected into C++/WinRT.</span></span> <span data-ttu-id="4ecd2-117">つまり、Windows の種類ごとに、C++/WinRT は C++ 対応の同等の型 (*投影された型*と呼ばれます) を定義します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-117">In other words, for each Windows type, C++/WinRT defines a C++-friendly equivalent (called the *projected type*).</span></span> <span data-ttu-id="4ecd2-118">投影された型には Windows の型と同じ完全修飾名がありますが、C++ **winrt** 名前空間に配置されます。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-118">A projected type has the same fully-qualified name as the Windows type, but it's placed in the C++ **winrt** namespace.</span></span> <span data-ttu-id="4ecd2-119">これらのインクルードをプリコンパイル済みヘッダーに配置すると、段階的なビルド時間が短縮されます。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-119">Putting these includes in your precompiled header reduces incremental build times.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4ecd2-120">Windows 名前空間から型を使用する場合は、次に示すように、対応する C++/WinRT Windows 名前空間ヘッダー ファイルを含めます。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-120">Whenever you want to use a type from a Windows namespaces, include the corresponding C++/WinRT Windows namespace header file, as shown.</span></span> <span data-ttu-id="4ecd2-121">*対応する*ヘッダーは、その型の名前空間と同じ名前を持つヘッダーです。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-121">The *corresponding* header is the one with the same name as the type's namespace.</span></span> <span data-ttu-id="4ecd2-122">たとえば、C++/WinRT プロジェクションを [**Windows::Foundation::Collections::PropertySet**](/uwp/api/windows.foundation.collections.propertyset) ランタイム クラスに使用するには、`#include <winrt/Windows.Foundation.Collections.h>` を指定します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-122">For example, to use the C++/WinRT projection for the [**Windows::Foundation::Collections::PropertySet**](/uwp/api/windows.foundation.collections.propertyset) runtime class, `#include <winrt/Windows.Foundation.Collections.h>`.</span></span>

```cppwinrt
using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;
```

<span data-ttu-id="4ecd2-123">`using namespace` ディレクティブはオプションですが、便利です。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-123">The `using namespace` directives are optional, but convenient.</span></span> <span data-ttu-id="4ecd2-124">(**winrt** 名前空間で非修飾名による参照を許可する) ディレクティブに関する上記のパターンは、新しいプロジェクトを開始する場合に最適です。また、C++/WinRT はそのプロジェクト内で使用する唯一の言語プロジェクションです)。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-124">The pattern shown above for such directives (allowing unqualified name lookup for anything in the **winrt** namespace) is suitable for when you're beginning a new project and C++/WinRT is the only language projection you're using inside of that project.</span></span> <span data-ttu-id="4ecd2-125">一方、C++/WinRT コードを [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) および SDK アプリケーション バイナリ インターフェイス (ABI) コードと混在させている (これらのモデルのいずれかまたは両方から移植しているか、相互運用している) 場合は、「[C++/WinRT と C++/CX 間の相互運用](interop-winrt-cx.md)」、「[C++/CX から C++/WinRT への移動](move-to-winrt-from-cx.md)」、「[C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md)」のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-125">If, on the other hand, you're mixing C++/WinRT code with [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) and/or SDK application binary interface (ABI) code (you're either porting from, or interoperating with, one or both of those models), then see the topics [Interop between C++/WinRT and C++/CX](interop-winrt-cx.md), [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md), and [Interop between C++/WinRT and the ABI](interop-winrt-abi.md).</span></span>

```cppwinrt
winrt::init_apartment();
```

<span data-ttu-id="4ecd2-126">**winrt::init_apartment** への呼び出しにより、既定では、マルチスレッド アパートメントで COM が初期化されます。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-126">The call to **winrt::init_apartment** initializes COM; by default, in a multithreaded apartment.</span></span>

```cppwinrt
Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
SyndicationClient syndicationClient;
```

<span data-ttu-id="4ecd2-127">2 つのオブジェクトをスタックに割り当てます。これらのオブジェクトは Windows ブログの URI と配信クライアントを表します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-127">Stack-allocate two objects: they represent the uri of the Windows blog, and a syndication client.</span></span> <span data-ttu-id="4ecd2-128">単純なワイド文字列リテラルで URI を作成します (その他の文字列の操作方法については、「[C++/WinRT での文字列の処理](strings.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-128">We construct the uri with a simple wide string literal (see [String handling in C++/WinRT](strings.md) for more ways you can work with strings).</span></span>

```cppwinrt
SyndicationFeed syndicationFeed = syndicationClient.RetrieveFeedAsync(rssFeedUri).get();
```

<span data-ttu-id="4ecd2-129">[**SyndicationClient::RetrieveFeedAsync** ](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)非同期 Windows ランタイム関数の例を示します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-129">[**SyndicationClient::RetrieveFeedAsync**](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) is an example of an asynchronous Windows Runtime function.</span></span> <span data-ttu-id="4ecd2-130">コード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、呼び出しスレッドをブロックし、その結果 (この場合は配信フィード) を待機するように、このオブジェクトで **get** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-130">The code example receives an asynchronous operation object from **RetrieveFeedAsync**, and it calls **get** on that object to block the calling thread and wait for the result (which is a syndication feed, in this case).</span></span> <span data-ttu-id="4ecd2-131">同時実行、および非ブロッキングの手法の詳細については、「[C++/WinRT での同時実行と非同期操作](concurrency.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-131">For more about concurrency, and for non-blocking techniques, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md).</span></span>

```cppwinrt
for (const SyndicationItem syndicationItem : syndicationFeed.Items()) { ... }
```

<span data-ttu-id="4ecd2-132">[**SyndicationFeed.Items** ](/uwp/api/windows.web.syndication.syndicationfeed.items)から返された反復子によって定義された範囲は、**開始**と**エンド**関数 (または、定数、反転、および定数反転のバリアント)。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-132">[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) is a range, defined by the iterators returned from **begin** and **end** functions (or their constant, reverse, and constant-reverse variants).</span></span> <span data-ttu-id="4ecd2-133">このため、範囲ベースの `for` ステートメント、または **std::for_each** テンプレート関数とともに **Items** を列挙できます。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-133">Because of this, you can enumerate **Items** with either a range-based `for` statement, or with the **std::for_each** template function.</span></span>

```cppwinrt
winrt::hstring titleAsHstring = syndicationItem.Title().Text();
std::wcout << titleAsHstring.c_str() << std::endl;
```

<span data-ttu-id="4ecd2-134">フィードのタイトル テキストを、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) オブジェクトとして取得します (詳細については「[C++/WinRT での文字列処理](strings.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-134">Gets the feed's title text, as a [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) object (more details in [String handling in C++/WinRT](strings.md)).</span></span> <span data-ttu-id="4ecd2-135">次に **c_str** 関数で **hstring** が出力され、C++ 標準ライブラリの文字列で使用されるパターンが反映されます。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-135">The **hstring** is then output, via the **c_str** function, which reflects the pattern used with C++ Standard Library strings.</span></span>

<span data-ttu-id="4ecd2-136">おわかりのように、C++/WinRT では、`syndicationItem.Title().Text()` などの、最新のクラスのような C++ の式を奨励しています。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-136">As you can see, C++/WinRT encourages modern, and class-like, C++ expressions such as `syndicationItem.Title().Text()`.</span></span> <span data-ttu-id="4ecd2-137">これは、従来の COM プログラミングとは異なる、よりクリーンなプログラミング スタイルです。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-137">This is a different, and cleaner, programming style from traditional COM programming.</span></span> <span data-ttu-id="4ecd2-138">直接 COM を初期化し、COM ポインターを操作する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-138">You don't need to directly initialize COM, work with COM pointers.</span></span>

<span data-ttu-id="4ecd2-139">HRESULT リターン コードを処理する必要もありません。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-139">Nor do you need to handle HRESULT return codes.</span></span> <span data-ttu-id="4ecd2-140">C++/WinRT では、エラーの HRESULT を [**winrt::hresult-error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) のような自然かつ最新のプログラミング スタイルの例外に変換します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-140">C++/WinRT converts error HRESULTs to exceptions such as [**winrt::hresult-error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) for a natural and modern programming style.</span></span> <span data-ttu-id="4ecd2-141">エラー処理の詳細とコード例の詳細については、「[C++/WinRT でのエラー処理](error-handling.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-141">For more info about error-handling, and code examples, see [Error handling with C++/WinRT](error-handling.md).</span></span>

## <a name="modify-a-windows-desktop-application-project-to-add-cwinrt-support"></a><span data-ttu-id="4ecd2-142">C + を追加する Windows デスクトップ アプリケーション プロジェクトを変更する/cli WinRT のサポート</span><span class="sxs-lookup"><span data-stu-id="4ecd2-142">Modify a Windows Desktop application project to add C++/WinRT support</span></span>

<span data-ttu-id="4ecd2-143">このセクションで説明する追加方法 C +/cli WinRT サポートを所持している Windows デスクトップ アプリケーション プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-143">This section shows you how you can add C++/WinRT support to a Windows Desktop application project that you might have.</span></span> <span data-ttu-id="4ecd2-144">場合は、既存の Windows デスクトップ アプリケーション プロジェクトは、最初の作成のいずれかでと共に次の手順に従うことができますし、必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-144">If you don't have an existing Windows Desktop application project, then you can follow along with these steps by first creating one.</span></span> <span data-ttu-id="4ecd2-145">たとえば、Visual Studio を開き、作成、 **Visual C** \> **Windows デスクトップ** \> **Windows デスクトップ アプリケーション**プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-145">For example, open Visual Studio and create a **Visual C++** \> **Windows Desktop** \> **Windows Desktop Application** project.</span></span>

<span data-ttu-id="4ecd2-146">必要に応じてインストールすることができます、 [ C++WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)と NuGet パッケージ。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-146">You can optionally install the [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) and the NuGet package.</span></span> <span data-ttu-id="4ecd2-147">詳細については、次を参照してください。 [Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-147">For details, see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package).</span></span>

### <a name="set-project-properties"></a><span data-ttu-id="4ecd2-148">プロジェクト プロパティの設定</span><span class="sxs-lookup"><span data-stu-id="4ecd2-148">Set project properties</span></span>

<span data-ttu-id="4ecd2-149">プロジェクトのプロパティに移動して**全般** \> **Windows SDK バージョン**を選択し、**すべての構成**と**すべてのプラットフォーム**します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-149">Go to project property **General** \> **Windows SDK Version**, and select **All Configurations** and **All Platforms**.</span></span> <span data-ttu-id="4ecd2-150">いることを確認**Windows SDK バージョン**10.0.17134.0 (Windows 10、バージョン 1803) に設定されているか、大きい。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-150">Ensure that **Windows SDK Version** is set to 10.0.17134.0 (Windows 10, version 1803) or greater.</span></span>

<span data-ttu-id="4ecd2-151">発生していないを確認[自分の新しいプロジェクトがコンパイルされない理由ですか?](/windows/uwp/cpp-and-winrt-apis/faq)します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-151">Confirm that you're not affected by [Why won't my new project compile?](/windows/uwp/cpp-and-winrt-apis/faq).</span></span>

<span data-ttu-id="4ecd2-152">C++WinRT c++ 17 標準的な設定プロジェクト プロパティから機能を使用して**C/C++** > **言語** >   **C++言語標準**に*ISO c++ 17 標準 (//std:c + + 17)* します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-152">Because C++/WinRT uses features from the C++17 standard, set project property **C/C++** > **Language** > **C++ Language Standard** to *ISO C++17 Standard (/std:c++17)*.</span></span>

### <a name="the-precompiled-header"></a><span data-ttu-id="4ecd2-153">プリコンパイル済みヘッダー</span><span class="sxs-lookup"><span data-stu-id="4ecd2-153">The precompiled header</span></span>

<span data-ttu-id="4ecd2-154">既定のプロジェクト テンプレートがという名前のプリコンパイル済みヘッダーを作成します`framework.h`、または`stdafx.h`します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-154">The default project template creates a precompiled header for you, named either `framework.h`, or `stdafx.h`.</span></span> <span data-ttu-id="4ecd2-155">名前を変更する`pch.h`します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-155">Rename that to `pch.h`.</span></span> <span data-ttu-id="4ecd2-156">ある場合、`stdafx.cpp`ファイルをその名前を変更して`pch.cpp`します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-156">If you have a `stdafx.cpp` file, then rename that to `pch.cpp`.</span></span> <span data-ttu-id="4ecd2-157">プロジェクトのプロパティを設定**C/C++** > **プリコンパイル済みヘッダー** > **プリコンパイル済みヘッダー ファイル**に*pch.h*します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-157">Set project property **C/C++** > **Precompiled Headers** > **Precompiled Header File** to *pch.h*.</span></span>

<span data-ttu-id="4ecd2-158">検索し、置換すべて`#include "framework.h"`(または`#include "stdafx.h"`) と`#include "pch.h"`します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-158">Find and replace all `#include "framework.h"` (or `#include "stdafx.h"`) with `#include "pch.h"`.</span></span>

<span data-ttu-id="4ecd2-159">`pch.h`、含める`winrt/base.h`します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-159">In `pch.h`, include `winrt/base.h`.</span></span>

```cppwinrt
// pch.h
...
#include <winrt/base.h>
```

### <a name="linking"></a><span data-ttu-id="4ecd2-160">リンク</span><span class="sxs-lookup"><span data-stu-id="4ecd2-160">Linking</span></span>

<span data-ttu-id="4ecd2-161">C++/cli へのリンクは WinRT 言語プロジェクションは、特定の (メンバーではない) 関数の無料で Windows ランタイム、およびエントリ ポイントに依存するを必要と、 [WindowsApp.lib](/uwp/win32-and-com/win32-apis)包括的なライブラリ。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-161">The C++/WinRT language projection depends on certain Windows Runtime free (non-member) functions, and entry points, that require linking to the [WindowsApp.lib](/uwp/win32-and-com/win32-apis) umbrella library.</span></span> <span data-ttu-id="4ecd2-162">このセクションでは、リンカーが満たされる 3 つの方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-162">This section describes three ways of satisfying the linker.</span></span>

<span data-ttu-id="4ecd2-163">最初のオプションは、Visual Studio に追加するプロジェクトのすべての c++/cli WinRT MSBuild プロパティとターゲット。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-163">The first option is to add to your Visual Studio project all of the C++/WinRT MSBuild properties and targets.</span></span> <span data-ttu-id="4ecd2-164">これを行うには、インストール、 [Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)をプロジェクトにします。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-164">To do this, install the [Microsoft.Windows.CppWinRT NuGet package](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/) into your project.</span></span> <span data-ttu-id="4ecd2-165">開いている Visual Studio でプロジェクトをクリックして**プロジェクト** \> **NuGet パッケージの管理.**\> **[参照]** 入力するか貼り付けて**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、順にクリックします**インストール**そのプロジェクトのパッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-165">Open the project in Visual Studio, click **Project** \> **Manage NuGet Packages...** \> **Browse**, type or paste **Microsoft.Windows.CppWinRT** in the search box, select the item in search results, and then click **Install** to install the package for that project.</span></span>

<span data-ttu-id="4ecd2-166">明示的にリンクするプロジェクト リンクの設定を使用することもできます。`WindowsApp.lib`します。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-166">You can also use project link settings to explicitly link `WindowsApp.lib`.</span></span> <span data-ttu-id="4ecd2-167">または、ソース コードで行うことができます (で`pch.h`など) のようです。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-167">Or, you can do it in source code (in `pch.h`, for example) like this.</span></span>

```cppwinrt
#pragma comment(lib, "windowsapp")
```

<span data-ttu-id="4ecd2-168">コンパイルおよびリンク、および追加C++/WinRT コードをプロジェクトに (たとえば、コードに示すような[A C++/WinRT クイック スタート](#a-cwinrt-quick-start)セクションで、上記の)。</span><span class="sxs-lookup"><span data-stu-id="4ecd2-168">You can now compile and link, and add C++/WinRT code to your project (for example, code similar to that shown in the [A C++/WinRT quick-start](#a-cwinrt-quick-start) section, above).</span></span>

## <a name="important-apis"></a><span data-ttu-id="4ecd2-169">重要な API</span><span class="sxs-lookup"><span data-stu-id="4ecd2-169">Important APIs</span></span>
* [<span data-ttu-id="4ecd2-170">SyndicationClient::RetrieveFeedAsync メソッド</span><span class="sxs-lookup"><span data-stu-id="4ecd2-170">SyndicationClient::RetrieveFeedAsync method</span></span>](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [<span data-ttu-id="4ecd2-171">SyndicationFeed.Items プロパティ</span><span class="sxs-lookup"><span data-stu-id="4ecd2-171">SyndicationFeed.Items property</span></span>](/uwp/api/windows.web.syndication.syndicationfeed.items)
* [<span data-ttu-id="4ecd2-172">winrt::hstring 構造体</span><span class="sxs-lookup"><span data-stu-id="4ecd2-172">winrt::hstring struct</span></span>](/uwp/cpp-ref-for-winrt/hstring)
* [<span data-ttu-id="4ecd2-173">winrt::hresult エラー構造体</span><span class="sxs-lookup"><span data-stu-id="4ecd2-173">winrt::hresult-error struct</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)

## <a name="related-topics"></a><span data-ttu-id="4ecd2-174">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4ecd2-174">Related topics</span></span>
* [<span data-ttu-id="4ecd2-175">C++/CX</span><span class="sxs-lookup"><span data-stu-id="4ecd2-175">C++/CX</span></span>](/cpp/cppcx/visual-c-language-reference-c-cx)
* [<span data-ttu-id="4ecd2-176">C++/WinRT でのエラー処理</span><span class="sxs-lookup"><span data-stu-id="4ecd2-176">Error handling with C++/WinRT</span></span>](error-handling.md)
* [<span data-ttu-id="4ecd2-177">C++/WinRT と C++/CX 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="4ecd2-177">Interop between C++/WinRT and C++/CX</span></span>](interop-winrt-cx.md)
* [<span data-ttu-id="4ecd2-178">C++/WinRT と ABI 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="4ecd2-178">Interop between C++/WinRT and the ABI</span></span>](interop-winrt-abi.md)
* [<span data-ttu-id="4ecd2-179">C++/CX から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="4ecd2-179">Move to C++/WinRT from C++/CX</span></span>](move-to-winrt-from-cx.md)
* [<span data-ttu-id="4ecd2-180">C++/WinRT での文字列の処理</span><span class="sxs-lookup"><span data-stu-id="4ecd2-180">String handling in C++/WinRT</span></span>](strings.md)
