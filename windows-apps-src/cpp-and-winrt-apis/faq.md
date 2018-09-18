---
author: stevewhims
description: C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。
title: C++/WinRT についてよく寄せられる質問
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: wwindows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 頻繁, 質問, 質問, faq
ms.localizationpriority: medium
ms.openlocfilehash: 9316a29a50970bdaa288a4744f3aab7d873cbe4e
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4024328"
---
# <a name="frequently-asked-questions-about-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="e149d-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) についてよく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="e149d-104">Frequently-asked questions about [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="e149d-105">C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。</span><span class="sxs-lookup"><span data-stu-id="e149d-105">Answers to questions that you're likely to have about authoring and consuming Windows Runtime APIs with C++/WinRT.</span></span>

> [!NOTE]
> <span data-ttu-id="e149d-106">質問の内容が、表示されたエラー メッセージに関するものである場合は、「[C++/WinRT に関する問題のトラブルシューティング](troubleshooting.md)」のトピックも参照してください。</span><span class="sxs-lookup"><span data-stu-id="e149d-106">If your question is about an error message that you've seen, then also see the [Troubleshooting C++/WinRT](troubleshooting.md) topic.</span></span>

## <a name="why-wont-my-new-project-compile-im-using-visual-studio-2017-version-1580-or-higher-and-sdk-version-17134"></a><span data-ttu-id="e149d-107">新しいプロジェクトがコンパイルされません。</span><span class="sxs-lookup"><span data-stu-id="e149d-107">Why won't my new project compile?</span></span> <span data-ttu-id="e149d-108">Visual Studio 2017 を使用している (バージョン 15.8.0 以上)、および SDK バージョン 17134</span><span class="sxs-lookup"><span data-stu-id="e149d-108">I'm using Visual Studio 2017 (version 15.8.0 or higher), and SDK version 17134</span></span>

<span data-ttu-id="e149d-109">Visual Studio 2017 を使用している場合 (バージョン 15.8.0 以降) をターゲットとする Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) し、新しく作成した、C++/WinRT プロジェクトをコンパイル エラーで失敗する可能性が"*エラー C3861: 'from_abi': 識別子しません。見つかった*"、および*base.h*でその他のエラー。</span><span class="sxs-lookup"><span data-stu-id="e149d-109">If you're using Visual Studio 2017 (version 15.8.0 or higher), and targeting the Windows SDK version 10.0.17134.0 (Windows 10, version 1803), then a newly created C++/WinRT project may fail to compile with the error "*error C3861: 'from_abi': identifier not found*", and with other errors originating in *base.h*.</span></span> <span data-ttu-id="e149d-110">解決策は、いずれかのターゲット以降 (詳しく準拠) のバージョンの Windows SDK、またはプロジェクトのプロパティを設定する**C/C++** > **言語** > **Conformance mode: いいえ**(も場合、 **/制限解除-** **プロジェクトのプロパティに表示されますC/C++** > **言語** > **コマンド ライン**[**その他のオプション**を削除します)。</span><span class="sxs-lookup"><span data-stu-id="e149d-110">The solution is to either target a later (more conformant) version of the Windows SDK, or set project property **C/C++** > **Language** > **Conformance mode: No** (also, if **/permissive-** appears in project property **C/C++** > **Language** > **Command Line** under **Additional Options**, then delete it).</span></span>

## <a name="what-are-the-requirements-for-the-cwinrt-visual-studio-extension-vsixhttpsakamscppwinrtvsix"></a><span data-ttu-id="e149d-111"> [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) の要件</span><span class="sxs-lookup"><span data-stu-id="e149d-111">What are the requirements for the [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)?</span></span>
<span data-ttu-id="e149d-112">[VSIX](https://aka.ms/cppwinrt/vsix) の最小要件は、Windows SDK ターゲット バージョン 10.0.17134.0 (Windows 10、バージョン 1803) です。</span><span class="sxs-lookup"><span data-stu-id="e149d-112">The [VSIX](https://aka.ms/cppwinrt/vsix) enforces a minimum Windows SDK target version of 10.0.17134.0 (Windows 10, version 1803).</span></span> <span data-ttu-id="e149d-113">Visual Studio 2017 (バージョン 15.6 以上、15.7 以上を推奨) も必要になります 。</span><span class="sxs-lookup"><span data-stu-id="e149d-113">You'll also need Visual Studio 2017 (at least version 15.6; we recommend at least 15.7).</span></span> <span data-ttu-id="e149d-114">`.vcxproj` ファイルの `<PropertyGroup Label="Globals">` に `<CppWinRTEnabled>true</CppWinRTEnabled>` があるかどうかによって、VSIX を使用するプロジェクトを特定できます。</span><span class="sxs-lookup"><span data-stu-id="e149d-114">You can identify a project that uses the VSIX by the presence of `<CppWinRTEnabled>true</CppWinRTEnabled>` in `<PropertyGroup Label="Globals">` in the `.vcxproj` file.</span></span> <span data-ttu-id="e149d-115">詳しくは、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e149d-115">For more info, see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="whats-a-runtime-class"></a><span data-ttu-id="e149d-116">*ランタイム クラス*とは</span><span class="sxs-lookup"><span data-stu-id="e149d-116">What's a *runtime class*?</span></span>
<span data-ttu-id="e149d-117">ランタイム クラスは、通常実行可能な境界を越えて、モダン COM インターフェイス経由でアクティブ化および使用可能な型です。</span><span class="sxs-lookup"><span data-stu-id="e149d-117">A runtime class is a type that can be activated and consumed via modern COM interfaces, typically across executable boundaries.</span></span> <span data-ttu-id="e149d-118">ただし、ランタイム クラスは、それを実装するコンパイル ユニット内でも使用できます。</span><span class="sxs-lookup"><span data-stu-id="e149d-118">However, a runtime class can also be used within the compilation unit that implements it.</span></span> <span data-ttu-id="e149d-119">インターフェイス定義言語 (IDL) でランタイム クラスを宣言し、C++/WinRT を使用した標準の C++ で実装することができます。</span><span class="sxs-lookup"><span data-stu-id="e149d-119">You declare a runtime class in Interface Definition Language (IDL), and you can implement it in standard C++ using C++/WinRT.</span></span>

## <a name="what-do-the-projected-type-and-the-implementation-type-mean"></a><span data-ttu-id="e149d-120">*プロジェクションされる型*と*実装型*とは</span><span class="sxs-lookup"><span data-stu-id="e149d-120">What do *the projected type* and *the implementation type* mean?</span></span>
<span data-ttu-id="e149d-121">Windows ランタイム クラス (ランタイム クラス) を*使用*する場合のみ、*プロジェクションされる型*を排他的に処理します。</span><span class="sxs-lookup"><span data-stu-id="e149d-121">If you're only *consuming* a Windows Runtime class (runtime class), then you'll be dealing exclusively with *projected types*.</span></span> <span data-ttu-id="e149d-122">C++/WinRT は*言語のプロジェクション*であるため、プロジェクションされる型は、C++/WinRT を使用した C++ に*プロジェクション*される Windows ランタイムの画面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e149d-122">C++/WinRT is a *language projection*, so projected types are part of the surface of the Windows Runtime that's *projected* into C++ with C++/WinRT.</span></span> <span data-ttu-id="e149d-123">詳しくは、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e149d-123">For more details, see see [Consume APIs with C++/WinRT](consume-apis.md).</span></span>

<span data-ttu-id="e149d-124">*実装型*にはランタイム クラスの実装が含まれるため、ランタイム クラスを実装するプロジェクトでのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="e149d-124">The *implementation type* contains the implementation of a runtime class, so it's only available in the project that implements the runtime class.</span></span> <span data-ttu-id="e149d-125">ランタイム クラス (Windows ランタイム コンポーネント プロジェクト、つまり XAML UI を使用するプロジェクト) を実装するプロジェクトで作業している場合、ランタイム クラスの実装型と C++/WinRT にプロジェクションされたランタイム クラスを表すプロジェクションされる型との違いを習熟することが重要です。</span><span class="sxs-lookup"><span data-stu-id="e149d-125">When you're working in a project that implements runtime classes (a Windows Runtime component project, or a project that uses XAML UI), it's important to be comfortable with the distinction between your implementation type for a runtime class, and the projected type that represents the runtime class projected into C++/WinRT.</span></span> <span data-ttu-id="e149d-126">詳細については、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e149d-126">For more details, see [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="do-i-need-to-declare-a-constructor-in-my-runtime-classs-idl"></a><span data-ttu-id="e149d-127">使用するランタイム クラスの IDL でコンストラクターを宣言する必要性</span><span class="sxs-lookup"><span data-stu-id="e149d-127">Do I need to declare a constructor in my runtime class's IDL?</span></span>
<span data-ttu-id="e149d-128">ランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合のみ</span><span class="sxs-lookup"><span data-stu-id="e149d-128">Only if the runtime class is designed to be consumed from outside its implementing compilation unit (it's a Windows Runtime component intended for general consumption by Windows Runtime client apps).</span></span> <span data-ttu-id="e149d-129">IDL のコンストラクターを宣言する際の目的と影響の詳細については、「[ランタイム クラス コンストラクター](author-apis.md#runtime-class-constructors)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e149d-129">For full details on the purpose and consequences of declaring constructor(s) in IDL, see [Runtime class constructors](author-apis.md#runtime-class-constructors).</span></span>

## <a name="why-is-the-linker-giving-me-a-lnk2019-unresolved-external-symbol-error"></a><span data-ttu-id="e149d-130">リンカーで "LNK2019: 外部シンボルは未解決です" というエラーが表示されるのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="e149d-130">Why is the linker giving me a "LNK2019: Unresolved external symbol" error?</span></span>
<span data-ttu-id="e149d-131">未解決のシンボルが (**winrt** 名前空間内の) C++/WinRT プロジェクションの Windows 名前空間ヘッダーからの API である場合、その API は含まれているヘッダー内で事前宣言されていますが、その定義は含まれていないヘッダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="e149d-131">If the unresolved symbol is an API from the Windows namespace headers for the C++/WinRT projection (in the **winrt** namespace), then the API is forward-declared in a header that you've included, but its definition is in a header that you haven't yet included.</span></span> <span data-ttu-id="e149d-132">API の名前空間で付けられた名前のヘッダーを含めてから、リビルドしてください。</span><span class="sxs-lookup"><span data-stu-id="e149d-132">Include the header named for the API's namespace, and rebuild.</span></span> <span data-ttu-id="e149d-133">詳細については、「[C++/WinRT プロジェクション ヘッダー](consume-apis.md#cwinrt-projection-headers)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e149d-133">For more info, see [C++/WinRT projection headers](consume-apis.md#cwinrt-projection-headers).</span></span>

<span data-ttu-id="e149d-134">未解決のシンボルが [RoInitialize](https://msdn.microsoft.com/library/br224650) などの Windows ランタイムの自由関数である場合、[WindowsApp.lib](/uwp/win32-and-com/win32-apis) の包括的なライブラリを明示的にプロジェクトに含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e149d-134">If the unresolved symbol is a Windows Runtime free function, such as [RoInitialize](https://msdn.microsoft.com/library/br224650), then you'll need to explicitly include the [WindowsApp.lib](/uwp/win32-and-com/win32-apis) umbrella library in your project.</span></span> <span data-ttu-id="e149d-135">C++/WinRT プロジェクションは、これらの一部の自由 (非メンバー) 関数とエントリ ポイントに依存します。</span><span class="sxs-lookup"><span data-stu-id="e149d-135">The C++/WinRT projection depends on some of these free (non-member) functions and entry points.</span></span> <span data-ttu-id="e149d-136">アプリケーションでいずれかの [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) プロジェクト テンプレートを使用する場合は、`WindowsApp.lib` が自動的にリンクされます。</span><span class="sxs-lookup"><span data-stu-id="e149d-136">If you use one of the [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) project templates for your application, then `WindowsApp.lib` is linked for you automatically.</span></span> <span data-ttu-id="e149d-137">それ以外の場合、プロジェクトのリンク設定を使用して含めるか、またはソース コードでそれを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="e149d-137">Otherwise, you can use project link settings to include it, or do it in source code.</span></span>

```cppwinrt
#pragma comment(lib, "windowsapp")
```

## <a name="should-i-implement-windowsfoundationiclosableuwpapiwindowsfoundationiclosable-and-if-so-how"></a><span data-ttu-id="e149d-138">[**Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) を実装するかどうかとその方法</span><span class="sxs-lookup"><span data-stu-id="e149d-138">Should I implement [**Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) and, if so, how?</span></span>
<span data-ttu-id="e149d-139">自身のデストラクターのリソースを解放するランタイム クラスを使用し、そのランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合、確定終了処理が不足する言語でランタイム クラスの使用をサポートするために、**IClosable** も実装することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e149d-139">If you have a runtime class that frees resources in its destructor, and that runtime class is designed to be consumed from outside its implementing compilation unit (it's a Windows Runtime component intended for general consumption by Windows Runtime client apps), then we recommend that you also implement **IClosable** in order to support the consumption of your runtime class by languages that lack deterministic finalization.</span></span> <span data-ttu-id="e149d-140">デストラクター、[**IClosable::Close**](/uwp/api/windows.foundation.iclosable.Close)、または両方が呼び出されたときにリソースが解放されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="e149d-140">Make sure that your resources are freed whether the destructor, [**IClosable::Close**](/uwp/api/windows.foundation.iclosable.Close), or both are called.</span></span> <span data-ttu-id="e149d-141">**IClosable::Close** は必要に応じて呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="e149d-141">**IClosable::Close** may be called an arbitrary number of times.</span></span>

## <a name="do-i-need-to-call-iclosablecloseuwpapiwindowsfoundationiclosablewindowsfoundationiclosableclose-on-runtime-classes-that-i-consume"></a><span data-ttu-id="e149d-142">使用するランタイム クラスで [**IClosable::Close**](/uwp/api/windows.foundation.iclosable#Windows_Foundation_IClosable_Close_) を読み出す必要性</span><span class="sxs-lookup"><span data-stu-id="e149d-142">Do I need to call [**IClosable::Close**](/uwp/api/windows.foundation.iclosable#Windows_Foundation_IClosable_Close_) on runtime classes that I consume?</span></span>
<span data-ttu-id="e149d-143">**IClosable** は確定終了処理が不足する言語をサポートします。</span><span class="sxs-lookup"><span data-stu-id="e149d-143">**IClosable** exists to support languages that lack deterministic finalization.</span></span> <span data-ttu-id="e149d-144">そのため、シャットダウン状態やデッドロック状態といった非常にまれな場合を除いて、C++/WinRT から **IClosable::Close** を呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="e149d-144">So, you shouldn't call **IClosable::Close** from C++/WinRT, except in very rare cases involving shutdown races or semi-deadly embraces.</span></span> <span data-ttu-id="e149d-145">たとえば、**Windows.UI.Composition** を使用していて、設定順序でオブジェクトを破棄する場合、その代わりとして、C++/WinRT ラッパーを破棄することができます。</span><span class="sxs-lookup"><span data-stu-id="e149d-145">If you're using **Windows.UI.Composition** types, as an example, then you may encounter cases where you want to dispose objects in a set sequence, as an alternative to allowing the destruction of the C++/WinRT wrapper do the work for you.</span></span>

## <a name="can-i-use-llvmclang-to-compile-with-cwinrt"></a><span data-ttu-id="e149d-146">LLVM/Clang を使用して C++/WinRT でコンパイルすることはできますか。</span><span class="sxs-lookup"><span data-stu-id="e149d-146">Can I use LLVM/Clang to compile with C++/WinRT?</span></span>
<span data-ttu-id="e149d-147">C++/WinRT の LLVM および Clang ツール チェーンはサポートしていませんが、C++/WinRT の標準への準拠を検証するためにそれを内部で使用します。</span><span class="sxs-lookup"><span data-stu-id="e149d-147">We don't support the LLVM and Clang toolchain for C++/WinRT, but we do make use of it internally to validate C++/WinRT's standards conformance.</span></span> <span data-ttu-id="e149d-148">たとえば、マイクロソフトが内部で行っている内容をエミュレートする場合は、次に説明するような実験を試してみることができます。</span><span class="sxs-lookup"><span data-stu-id="e149d-148">For example, if you wanted to emulate what we do internally, then you could try an experiment such as the one described below.</span></span>

<span data-ttu-id="e149d-149">[LLVM ダウンロード ページ](https://releases.llvm.org/download.html)に移動し、**[Download LLVM 6.0.0] (LLVM 6.0.0 のダウンロード)** > **[Pre-Built Binaries] (事前ビルドされたバイナリ)** を探し、**[Clang for Windows (64-bit)] (Windows の Clang (64 ビット))** をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="e149d-149">Go to the [LLVM Download Page](https://releases.llvm.org/download.html), look for **Download LLVM 6.0.0** > **Pre-Built Binaries**, and download **Clang for Windows (64-bit)**.</span></span> <span data-ttu-id="e149d-150">インストール中に、コマンド プロンプトから起動できるように、PATH システム変数に LLVM を追加することを選択します。</span><span class="sxs-lookup"><span data-stu-id="e149d-150">During installation, opt to add LLVM to the PATH system variable so that you'll be able to invoke it from a command prompt.</span></span> <span data-ttu-id="e149d-151">この実験の目的上、"Failed to find MSBuild toolsets directory (MSBuild ツールセット ディレクトリの検索に失敗しました)" または "MSVC integration install failed (MSVC 統合インストールに失敗しました)" というエラーが表示された場合には無視できます。</span><span class="sxs-lookup"><span data-stu-id="e149d-151">For the purposes of this experiment, you can ignore any "Failed to find MSBuild toolsets directory" and/or "MSVC integration install failed" errors, if you see them.</span></span> <span data-ttu-id="e149d-152">LLVM/Clang を起動するさまざまな方法があります。次の例は、1 つの方法のみを示しています。</span><span class="sxs-lookup"><span data-stu-id="e149d-152">There are a variety of ways to invoke LLVM/Clang; the example below shows just one way.</span></span>

```
C:\ExperimentWithLLVMClang>type main.cpp
// main.cpp
#pragma comment(lib, "windowsapp")
#pragma comment(lib, "ole32")

#include "winrt/Windows.Foundation.h"
#include <stdio.h>
#include <iostream>

using namespace winrt;

int main()
{
    winrt::init_apartment();
    Windows::Foundation::Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    std::wcout << rssFeedUri.Domain().c_str() << std::endl;
}

C:\ExperimentWithLLVMClang>clang-cl main.cpp /EHsc /I ..\.. -Xclang -std=c++17 -Xclang -Wno-delete-non-virtual-dtor -o app.exe

C:\ExperimentWithLLVMClang>app
windows.com
```

<span data-ttu-id="e149d-153">C++/WinRT では C++17 標準の機能を使用するため、そのサポートを受けるために必要なコンパイラ フラグを使用する必要があります。そのようなフラグはコンパイラによって異なります。</span><span class="sxs-lookup"><span data-stu-id="e149d-153">Because C++/WinRT uses features from the C++17 standard, you'll need to use whatever compiler flags are necessary to get that support; such flags differ from one compiler to another.</span></span>

<span data-ttu-id="e149d-154">Visual Studio は、マイクロソフトがサポートし、C++/WinRT 用に推奨する開発ツールです。</span><span class="sxs-lookup"><span data-stu-id="e149d-154">Visual Studio is the development tool that we support and recommend for C++/WinRT.</span></span> <span data-ttu-id="e149d-155">「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e149d-155">See [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="why-doesnt-the-generated-implementation-function-for-a-read-only-property-have-the-const-qualifier"></a><span data-ttu-id="e149d-156">読み取り専用プロパティの実装が生成された関数がない理由、`const`修飾子かどうか。</span><span class="sxs-lookup"><span data-stu-id="e149d-156">Why doesn't the generated implementation function for a read-only property have the `const` qualifier?</span></span>

<span data-ttu-id="e149d-157">期待どおり[MIDL 3.0](/uwp/midl-3/)で読み取り専用プロパティを宣言するとき、`cppwinrt.exe`されるツールの実装の機能を生成する`const`-修飾 (const 関数は、定数として*この*ポインターを扱う)。</span><span class="sxs-lookup"><span data-stu-id="e149d-157">When you declare a read-only property in [MIDL 3.0](/uwp/midl-3/), you might expect the `cppwinrt.exe` tool to generate an implementation function for you that is `const`-qualified (a const function treats the *this* pointer as const).</span></span>

<span data-ttu-id="e149d-158">可能であれば、定数を使用してを確実にお勧めしますが`cppwinrt.exe`のどの実装について関数考え const する可能性がある理由ツール自体は行われません。</span><span class="sxs-lookup"><span data-stu-id="e149d-158">We certainly recommend using const wherever possible, but the `cppwinrt.exe` tool itself doesn't attempt to reason about which implementation functions might conceivably be const, and which might not.</span></span> <span data-ttu-id="e149d-159">この例のように、const させる、実装する関数のいずれかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="e149d-159">You can choose to make any of your implementation functions const, as in this example.</span></span>

```cppwinrt
struct MyStringable : winrt::implements<MyStringable, winrt::Windows::Foundation::IStringable>
{
    winrt::hstring ToString() const
    {
        return L"MyStringable";
    }
};
```

<span data-ttu-id="e149d-160">削除することができます`const` **ToString**の修飾子すべき実装ではいくつかオブジェクトの状態を変更する必要があることを決定します。</span><span class="sxs-lookup"><span data-stu-id="e149d-160">You can remove that `const` qualifier on **ToString** should you decide that you need to alter some object state in its implementation.</span></span> <span data-ttu-id="e149d-161">各メンバーの両方ではなく関数 const または非定数のいずれか。</span><span class="sxs-lookup"><span data-stu-id="e149d-161">But make each of your member functions either const or non-const, not both.</span></span> <span data-ttu-id="e149d-162">つまり、しないオーバー ロードの実装の機能で`const`します。</span><span class="sxs-lookup"><span data-stu-id="e149d-162">In other words, don't overload an implementation function on `const`.</span></span>

<span data-ttu-id="e149d-163">Const 場所に配置別の他の実装の関数を除くが使えるように画像は、Windows ランタイム関数のプロジェクションにします。</span><span class="sxs-lookup"><span data-stu-id="e149d-163">Aside from your implementation functions, another other place where const comes into the picture is in Windows Runtime function projections.</span></span> <span data-ttu-id="e149d-164">このコードを検討してください。</span><span class="sxs-lookup"><span data-stu-id="e149d-164">Consider this code.</span></span>

```cppwinrt
int main()
{
    winrt::Windows::Foundation::IStringable s{ winrt::make<MyStringable>() };
    auto result{ s.ToString() };
}
```

<span data-ttu-id="e149d-165">**ToString**上記を呼び出し、Visual Studio で**宣言へ移動**コマンド示されている C++ に**istringable::tostring** Windows ランタイムのプロジェクション/WinRT は次のようです。</span><span class="sxs-lookup"><span data-stu-id="e149d-165">For the call to **ToString** above, the **Go To Declaration** command in Visual Studio shows that the projection of the Windows Runtime **IStringable::ToString** into C++/WinRT looks like this.</span></span>

```
winrt::hstring ToString() const;
```

<span data-ttu-id="e149d-166">プロジェクションの関数は、資格を得ることの実装を選択する方法に関係なく const。</span><span class="sxs-lookup"><span data-stu-id="e149d-166">Functions on the projection are const no matter how you choose to qualify your implementation of them.</span></span> <span data-ttu-id="e149d-167">背後では、プロジェクションは、アプリケーション バイナリ インターフェイス (ABI)、COM インターフェイス ポインターを使用して、呼び出しをどの金額を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e149d-167">Behind the scenes, the projection calls the application binary interface (ABI), which amounts to a call through a COM interface pointer.</span></span> <span data-ttu-id="e149d-168">投影された**ToString**と対話する唯一の状態がその COM インターフェイスのポインターです。その確実に不要になったため、関数は const そのポインターを変更します。</span><span class="sxs-lookup"><span data-stu-id="e149d-168">The only state that the projected **ToString** interacts with is that COM interface pointer; and it certainly has no need to modify that pointer, so the function is const.</span></span> <span data-ttu-id="e149d-169">これにより、 **IStringable**を参照する保証を通じてを呼び出している**IStringable**の参照について何も変わりませんことと、これにより、const しても**ToString**を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="e149d-169">This gives you the assurance that it won't change anything about the **IStringable** reference that you're calling through, and it ensures that you can call **ToString** even with a const reference to an **IStringable**.</span></span>

<span data-ttu-id="e149d-170">理解するこれらの例の`const`は、C++ の実装の詳細/WinRT プロジェクションおよび実装します。やすくするコードに対する予防措置を構成しています。</span><span class="sxs-lookup"><span data-stu-id="e149d-170">Understand that these examples of `const` are implementation details of C++/WinRT projections and implementations; they constitute code hygiene for your benefit.</span></span> <span data-ttu-id="e149d-171">このようなものはありません`const`COM も (メンバー関数) 用の Windows ランタイム ABI のします。</span><span class="sxs-lookup"><span data-stu-id="e149d-171">There's no such thing as `const` on the COM nor Windows Runtime ABI (for member functions).</span></span>

## <a name="do-you-have-any-recommendations-for-decreasing-the-code-size-for-cwinrt-binaries"></a><span data-ttu-id="e149d-172">C++ コードのサイズを小さくに関する推奨事項がある/WinRT バイナリかどうか。</span><span class="sxs-lookup"><span data-stu-id="e149d-172">Do you have any recommendations for decreasing the code size for C++/WinRT binaries?</span></span>

<span data-ttu-id="e149d-173">Windows ランタイム オブジェクトを使用する際は、指定できるので否定的な影響をアプリケーションで以上バイナリのコードを生成するために必要なことで、次に示すコーディング パターンを避ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="e149d-173">When working with Windows Runtime objects, you should avoid the coding pattern shown below because it can have a negative impact on your application by causing more binary code than necessary to be generated.</span></span>

```cppwinrt
anobject.b().c().d();
anobject.b().c().e();
anobject.b().c().f();
```

<span data-ttu-id="e149d-174">Windows ランタイムの世界でコンパイラことができないの値をキャッシュ`c()`または間接参照から呼び出されるメソッドでは各インターフェイス ('.")。</span><span class="sxs-lookup"><span data-stu-id="e149d-174">In the Windows Runtime world, the compiler is unable to cache either the value of `c()` or the interfaces for each method that's called through an indirection ('.').</span></span> <span data-ttu-id="e149d-175">介入する場合を除き、複数の仮想呼び出しと参照カウントのオーバーヘッドを結果します。</span><span class="sxs-lookup"><span data-stu-id="e149d-175">Unless you intervene, that results in more virtual calls and reference counting overhead.</span></span> <span data-ttu-id="e149d-176">上記のパターンでは、として厳密に必要な 2 回の多くのコードを簡単に作成可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e149d-176">The pattern above could easily generate twice as much code as strictly needed.</span></span> <span data-ttu-id="e149d-177">代わりに、以下を参照することができる場合は必ずパターンを好みます。</span><span class="sxs-lookup"><span data-stu-id="e149d-177">Instead, prefer the pattern shown below wherever you can.</span></span> <span data-ttu-id="e149d-178">大幅に減少コードを生成し、実行時のパフォーマンスも大幅に向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="e149d-178">It generates a lot less code, and it can also dramatically improve your run time performance.</span></span>

```cppwinrt
auto a{ anobject.b().c() };
a.d();
a.e();
a.f();
```

<span data-ttu-id="e149d-179">上記の推奨パターンの対象だけでなく、C++/WinRT が、すべての Windows ランタイム言語プロジェクションにします。</span><span class="sxs-lookup"><span data-stu-id="e149d-179">The recommended pattern shown above applies not just to C++/WinRT but to all Windows Runtime language projections.</span></span>

> [!NOTE]
> <span data-ttu-id="e149d-180">このトピックで質問の回答が得られない場合は、[Stack Overflow で `c++-winrt` タグ](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt)を使用してヘルプ情報を見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="e149d-180">If this topic didn't answer your question, you might find help by using the [`c++-winrt` tag on Stack Overflow](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt).</span></span>
