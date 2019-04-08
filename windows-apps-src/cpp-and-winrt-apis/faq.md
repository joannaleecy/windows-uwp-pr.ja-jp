---
description: C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。
title: C++/WinRT についてよく寄せられる質問
ms.date: 10/26/2018
ms.topic: article
keywords: wwindows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 頻繁, 質問, 質問, faq
ms.localizationpriority: medium
ms.openlocfilehash: 9dd051ffe3af9e18370666f5c6c772b7f188e54a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635577"
---
# <a name="frequently-asked-questions-about-cwinrt"></a><span data-ttu-id="c9c2f-104">C++/WinRT についてよく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="c9c2f-104">Frequently-asked questions about C++/WinRT</span></span>
<span data-ttu-id="c9c2f-105">作成と使用の Windows ランタイム Api を利用する可能性がある質問の回答を[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-105">Answers to questions that you're likely to have about authoring and consuming Windows Runtime APIs with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span>

> [!NOTE]
> <span data-ttu-id="c9c2f-106">質問の内容が、表示されたエラー メッセージに関するものである場合は、「[C++/WinRT に関する問題のトラブルシューティング](troubleshooting.md)」のトピックも参照してください。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-106">If your question is about an error message that you've seen, then also see the [Troubleshooting C++/WinRT](troubleshooting.md) topic.</span></span>

## <a name="how-do-i-retarget-my-cwinrt-project-to-a-later-version-of-the-windows-sdk"></a><span data-ttu-id="c9c2f-107">方法は再ターゲット、C +/cli WinRT プロジェクトは、以降のバージョンの Windows SDK をでしょうか。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-107">How do I retarget my C++/WinRT project to a later version of the Windows SDK?</span></span>
<span data-ttu-id="c9c2f-108">参照してください[方法の再ターゲットすると、C +/cli WinRT プロジェクトは、以降のバージョンの Windows SDK を](news.md#how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk)します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-108">See [How to retarget your C++/WinRT project to a later version of the Windows SDK](news.md#how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk).</span></span>

## <a name="why-wont-my-new-project-compile-im-using-visual-studio-2017-version-1580-or-higher-and-sdk-version-17134"></a><span data-ttu-id="c9c2f-109">新しいプロジェクトがコンパイルされません。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-109">Why won't my new project compile?</span></span> <span data-ttu-id="c9c2f-110">Visual Studio 2017 を使用している (15.8.0 バージョンまたはそれ以降)、および SDK version 17134</span><span class="sxs-lookup"><span data-stu-id="c9c2f-110">I'm using Visual Studio 2017 (version 15.8.0 or higher), and SDK version 17134</span></span>
<span data-ttu-id="c9c2f-111">Visual Studio 2017 を使用している場合 (バージョン 15.8.0 またはそれ以降)、およびターゲットの Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) し、新しく作成した C +/cli WinRT プロジェクトがエラーでコンパイルに失敗する可能性があります"*エラー C3861: 'from_abi'。識別子が見つかりません*"、発信元がその他のエラーの*base.h*します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-111">If you're using Visual Studio 2017 (version 15.8.0 or higher), and targeting the Windows SDK version 10.0.17134.0 (Windows 10, version 1803), then a newly created C++/WinRT project may fail to compile with the error "*error C3861: 'from_abi': identifier not found*", and with other errors originating in *base.h*.</span></span> <span data-ttu-id="c9c2f-112">いずれかのターゲットに以降 (詳細について準拠) は、ソリューションのバージョンの Windows SDK、またはプロジェクトのプロパティを設定**C/C++** > **言語** > **準拠モード。いいえ**(また場合、 **/permissive -** プロジェクト プロパティに表示されます**C/C++** > **コマンド ライン\*\*\*\*追加のオプション**から削除します)。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-112">The solution is to either target a later (more conformant) version of the Windows SDK, or set project property **C/C++** > **Language** > **Conformance mode: No** (also, if **/permissive-** appears in project property **C/C++** > **Command Line** under **Additional Options**, then delete it).</span></span>

## <a name="how-do-i-resolve-the-build-error-the-cwinrt-vsix-no-longer-provides-project-build-support--please-add-a-project-reference-to-the-microsoftwindowscppwinrt-nuget-package"></a><span data-ttu-id="c9c2f-113">ビルド エラーを解決する方法"c++/cli WinRT VSIX プロジェクトのビルドのサポートは提供されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-113">How do I resolve the build error "The C++/WinRT VSIX no longer provides project build support.</span></span>  <span data-ttu-id="c9c2f-114">追加してください、Microsoft.Windows.CppWinRT Nuget パッケージへの参照をプロジェクト"でしょうか。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-114">Please add a project reference to the Microsoft.Windows.CppWinRT Nuget package"?</span></span>
<span data-ttu-id="c9c2f-115">インストール、 **Microsoft.Windows.CppWinRT**をプロジェクトに NuGet パッケージ。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-115">Install the **Microsoft.Windows.CppWinRT** NuGet package into your project.</span></span> <span data-ttu-id="c9c2f-116">詳細については、次を参照してください。 [VSIX 拡張機能の以前のバージョン](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension)します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-116">For details, see [Earlier versions of the VSIX extension](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension).</span></span>

## <a name="what-are-the-requirements-for-the-cwinrt-visual-studio-extension-vsix"></a><span data-ttu-id="c9c2f-117">C++ の要件は何/cli WinRT Visual Studio Extension (VSIX) でしょうか。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-117">What are the requirements for the C++/WinRT Visual Studio Extension (VSIX)?</span></span>
<span data-ttu-id="c9c2f-118">バージョン 1.0.190128.4 VSIX 拡張機能と後で、次を参照してください。 [Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-118">For version 1.0.190128.4 of the VSIX extension and later, see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package).</span></span> <span data-ttu-id="c9c2f-119">その他のバージョンでは、次を参照してください。 [VSIX 拡張機能の以前のバージョン](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension)します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-119">For other versions, see [Earlier versions of the VSIX extension](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension).</span></span>

## <a name="whats-a-runtime-class"></a><span data-ttu-id="c9c2f-120">*ランタイム クラス*とは</span><span class="sxs-lookup"><span data-stu-id="c9c2f-120">What's a *runtime class*?</span></span>
<span data-ttu-id="c9c2f-121">ランタイム クラスは、通常実行可能な境界を越えて、モダン COM インターフェイス経由でアクティブ化および使用可能な型です。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-121">A runtime class is a type that can be activated and consumed via modern COM interfaces, typically across executable boundaries.</span></span> <span data-ttu-id="c9c2f-122">ただし、ランタイム クラスは、それを実装するコンパイル ユニット内でも使用できます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-122">However, a runtime class can also be used within the compilation unit that implements it.</span></span> <span data-ttu-id="c9c2f-123">インターフェイス定義言語 (IDL) でランタイム クラスを宣言し、C++/WinRT を使用した標準の C++ で実装することができます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-123">You declare a runtime class in Interface Definition Language (IDL), and you can implement it in standard C++ using C++/WinRT.</span></span>

## <a name="what-do-the-projected-type-and-the-implementation-type-mean"></a><span data-ttu-id="c9c2f-124">*プロジェクションされる型*と*実装型*とは</span><span class="sxs-lookup"><span data-stu-id="c9c2f-124">What do *the projected type* and *the implementation type* mean?</span></span>
<span data-ttu-id="c9c2f-125">Windows ランタイム クラス (ランタイム クラス) を*使用*する場合のみ、*プロジェクションされる型*を排他的に処理します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-125">If you're only *consuming* a Windows Runtime class (runtime class), then you'll be dealing exclusively with *projected types*.</span></span> <span data-ttu-id="c9c2f-126">C++/WinRT は*言語のプロジェクション*であるため、プロジェクションされる型は、C++/WinRT を使用した C++ に*プロジェクション*される Windows ランタイムの画面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-126">C++/WinRT is a *language projection*, so projected types are part of the surface of the Windows Runtime that's *projected* into C++ with C++/WinRT.</span></span> <span data-ttu-id="c9c2f-127">詳細については、次を参照してください。 [C + を使用して Api を消費する/cli WinRT](consume-apis.md)します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-127">For more details, see [Consume APIs with C++/WinRT](consume-apis.md).</span></span>

<span data-ttu-id="c9c2f-128">*実装型*にはランタイム クラスの実装が含まれるため、ランタイム クラスを実装するプロジェクトでのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-128">The *implementation type* contains the implementation of a runtime class, so it's only available in the project that implements the runtime class.</span></span> <span data-ttu-id="c9c2f-129">ランタイム クラス (Windows ランタイム コンポーネント プロジェクト、つまり XAML UI を使用するプロジェクト) を実装するプロジェクトで作業している場合、ランタイム クラスの実装型と C++/WinRT にプロジェクションされたランタイム クラスを表すプロジェクションされる型との違いを習熟することが重要です。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-129">When you're working in a project that implements runtime classes (a Windows Runtime component project, or a project that uses XAML UI), it's important to be comfortable with the distinction between your implementation type for a runtime class, and the projected type that represents the runtime class projected into C++/WinRT.</span></span> <span data-ttu-id="c9c2f-130">詳細については、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-130">For more details, see [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="do-i-need-to-declare-a-constructor-in-my-runtime-classs-idl"></a><span data-ttu-id="c9c2f-131">使用するランタイム クラスの IDL でコンストラクターを宣言する必要性</span><span class="sxs-lookup"><span data-stu-id="c9c2f-131">Do I need to declare a constructor in my runtime class's IDL?</span></span>
<span data-ttu-id="c9c2f-132">ランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合のみ</span><span class="sxs-lookup"><span data-stu-id="c9c2f-132">Only if the runtime class is designed to be consumed from outside its implementing compilation unit (it's a Windows Runtime component intended for general consumption by Windows Runtime client apps).</span></span> <span data-ttu-id="c9c2f-133">IDL のコンストラクターを宣言する際の目的と影響の詳細については、「[ランタイム クラス コンストラクター](author-apis.md#runtime-class-constructors)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-133">For full details on the purpose and consequences of declaring constructor(s) in IDL, see [Runtime class constructors](author-apis.md#runtime-class-constructors).</span></span>

## <a name="why-is-the-linker-giving-me-a-lnk2019-unresolved-external-symbol-error"></a><span data-ttu-id="c9c2f-134">理由は、リンカーを与えてくれた、"LNK2019:未解決の外部シンボル"エラーでしょうか。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-134">Why is the linker giving me a "LNK2019: Unresolved external symbol" error?</span></span>
<span data-ttu-id="c9c2f-135">未解決のシンボルが (**winrt** 名前空間内の) C++/WinRT プロジェクションの Windows 名前空間ヘッダーからの API である場合、その API は含まれているヘッダー内で事前宣言されていますが、その定義は含まれていないヘッダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-135">If the unresolved symbol is an API from the Windows namespace headers for the C++/WinRT projection (in the **winrt** namespace), then the API is forward-declared in a header that you've included, but its definition is in a header that you haven't yet included.</span></span> <span data-ttu-id="c9c2f-136">API の名前空間で付けられた名前のヘッダーを含めてから、リビルドしてください。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-136">Include the header named for the API's namespace, and rebuild.</span></span> <span data-ttu-id="c9c2f-137">詳細については、「[C++/WinRT プロジェクション ヘッダー](consume-apis.md#cwinrt-projection-headers)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-137">For more info, see [C++/WinRT projection headers](consume-apis.md#cwinrt-projection-headers).</span></span>

<span data-ttu-id="c9c2f-138">未解決のシンボルなど、Windows ランタイムの free 関数は、かどうか[RoInitialize](https://msdn.microsoft.com/library/br224650)を明示的にリンクする必要があります、 [WindowsApp.lib](/uwp/win32-and-com/win32-apis)プロジェクトでの包括的なライブラリ。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-138">If the unresolved symbol is a Windows Runtime free function, such as [RoInitialize](https://msdn.microsoft.com/library/br224650), then you'll need to explicitly link the [WindowsApp.lib](/uwp/win32-and-com/win32-apis) umbrella library in your project.</span></span> <span data-ttu-id="c9c2f-139">C++/WinRT プロジェクションは、これらの一部の自由 (非メンバー) 関数とエントリ ポイントに依存します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-139">The C++/WinRT projection depends on some of these free (non-member) functions and entry points.</span></span> <span data-ttu-id="c9c2f-140">アプリケーションでいずれかの [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) プロジェクト テンプレートを使用する場合は、`WindowsApp.lib` が自動的にリンクされます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-140">If you use one of the [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) project templates for your application, then `WindowsApp.lib` is linked for you automatically.</span></span> <span data-ttu-id="c9c2f-141">それ以外の場合、プロジェクトのリンク設定を使用して含めるか、またはソース コードでそれを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-141">Otherwise, you can use project link settings to include it, or do it in source code.</span></span>

```cppwinrt
#pragma comment(lib, "windowsapp")
```

<span data-ttu-id="c9c2f-142">リンクすることによって、リンカー エラーを解決することを強く**WindowsApp.lib** 、代替のスタティック リンク ライブラリではなくそれ以外の場合、アプリケーションに渡さない、 [Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)テストが Visual Studio では、Microsoft Store で送信 (したがってできませんが、Microsoft Store に正常に取り込まれたデータに、アプリケーションの意味) を検証するために使用します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-142">It's important that you resolve any linker errors that you can by linking **WindowsApp.lib** instead of an alternative static-link library, otherwise your application won't pass the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) tests used by Visual Studio and by the Microsoft Store to validate submissions (meaning that it consequently won't be possible for your application to be successfully ingested into the Microsoft Store).</span></span>

## <a name="should-i-implement-windowsfoundationiclosableuwpapiwindowsfoundationiclosable-and-if-so-how"></a><span data-ttu-id="c9c2f-143">[  **Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) を実装するかどうかとその方法</span><span class="sxs-lookup"><span data-stu-id="c9c2f-143">Should I implement [**Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) and, if so, how?</span></span>
<span data-ttu-id="c9c2f-144">自身のデストラクターのリソースを解放するランタイム クラスを使用し、そのランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合、確定終了処理が不足する言語でランタイム クラスの使用をサポートするために、**IClosable** も実装することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-144">If you have a runtime class that frees resources in its destructor, and that runtime class is designed to be consumed from outside its implementing compilation unit (it's a Windows Runtime component intended for general consumption by Windows Runtime client apps), then we recommend that you also implement **IClosable** in order to support the consumption of your runtime class by languages that lack deterministic finalization.</span></span> <span data-ttu-id="c9c2f-145">デストラクター、[**IClosable::Close**](/uwp/api/windows.foundation.iclosable.close)、または両方が呼び出されたときにリソースが解放されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-145">Make sure that your resources are freed whether the destructor, [**IClosable::Close**](/uwp/api/windows.foundation.iclosable.close), or both are called.</span></span> <span data-ttu-id="c9c2f-146">**IClosable::Close** は必要に応じて呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-146">**IClosable::Close** may be called an arbitrary number of times.</span></span>

## <a name="do-i-need-to-call-iclosablecloseuwpapiwindowsfoundationiclosableclose-on-runtime-classes-that-i-consume"></a><span data-ttu-id="c9c2f-147">使用するランタイム クラスで [**IClosable::Close**](/uwp/api/windows.foundation.iclosable.close) を読み出す必要性</span><span class="sxs-lookup"><span data-stu-id="c9c2f-147">Do I need to call [**IClosable::Close**](/uwp/api/windows.foundation.iclosable.close) on runtime classes that I consume?</span></span>
<span data-ttu-id="c9c2f-148">**IClosable** は確定終了処理が不足する言語をサポートします。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-148">**IClosable** exists to support languages that lack deterministic finalization.</span></span> <span data-ttu-id="c9c2f-149">そのため、シャットダウン状態やデッドロック状態といった非常にまれな場合を除いて、C++/WinRT から **IClosable::Close** を呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-149">So, you shouldn't call **IClosable::Close** from C++/WinRT, except in very rare cases involving shutdown races or semi-deadly embraces.</span></span> <span data-ttu-id="c9c2f-150">たとえば、**Windows.UI.Composition** を使用していて、設定順序でオブジェクトを破棄する場合、その代わりとして、C++/WinRT ラッパーを破棄することができます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-150">If you're using **Windows.UI.Composition** types, as an example, then you may encounter cases where you want to dispose objects in a set sequence, as an alternative to allowing the destruction of the C++/WinRT wrapper do the work for you.</span></span>

## <a name="can-i-use-llvmclang-to-compile-with-cwinrt"></a><span data-ttu-id="c9c2f-151">LLVM/Clang を使用して C++/WinRT でコンパイルすることはできますか。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-151">Can I use LLVM/Clang to compile with C++/WinRT?</span></span>
<span data-ttu-id="c9c2f-152">C++/WinRT の LLVM および Clang ツール チェーンはサポートしていませんが、C++/WinRT の標準への準拠を検証するためにそれを内部で使用します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-152">We don't support the LLVM and Clang toolchain for C++/WinRT, but we do make use of it internally to validate C++/WinRT's standards conformance.</span></span> <span data-ttu-id="c9c2f-153">たとえば、マイクロソフトが内部で行っている内容をエミュレートする場合は、次に説明するような実験を試してみることができます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-153">For example, if you wanted to emulate what we do internally, then you could try an experiment such as the one described below.</span></span>

<span data-ttu-id="c9c2f-154">[LLVM ダウンロード ページ](https://releases.llvm.org/download.html)に移動し、**[Download LLVM 6.0.0] (LLVM 6.0.0 のダウンロード)** > **[Pre-Built Binaries] (事前ビルドされたバイナリ)** を探し、**[Clang for Windows (64-bit)] (Windows の Clang (64 ビット))** をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-154">Go to the [LLVM Download Page](https://releases.llvm.org/download.html), look for **Download LLVM 6.0.0** > **Pre-Built Binaries**, and download **Clang for Windows (64-bit)**.</span></span> <span data-ttu-id="c9c2f-155">インストール中に、コマンド プロンプトから起動できるように、PATH システム変数に LLVM を追加することを選択します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-155">During installation, opt to add LLVM to the PATH system variable so that you'll be able to invoke it from a command prompt.</span></span> <span data-ttu-id="c9c2f-156">この実験の目的上、"Failed to find MSBuild toolsets directory (MSBuild ツールセット ディレクトリの検索に失敗しました)" または "MSVC integration install failed (MSVC 統合インストールに失敗しました)" というエラーが表示された場合には無視できます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-156">For the purposes of this experiment, you can ignore any "Failed to find MSBuild toolsets directory" and/or "MSVC integration install failed" errors, if you see them.</span></span> <span data-ttu-id="c9c2f-157">LLVM/Clang を起動するさまざまな方法があります。次の例は、1 つの方法のみを示しています。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-157">There are a variety of ways to invoke LLVM/Clang; the example below shows just one way.</span></span>

```
C:\ExperimentWithLLVMClang>type main.cpp
// main.cpp
#pragma comment(lib, "windowsapp")
#pragma comment(lib, "ole32")

#include <winrt/Windows.Foundation.h>
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

<span data-ttu-id="c9c2f-158">C++/WinRT では C++17 標準の機能を使用するため、そのサポートを受けるために必要なコンパイラ フラグを使用する必要があります。そのようなフラグはコンパイラによって異なります。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-158">Because C++/WinRT uses features from the C++17 standard, you'll need to use whatever compiler flags are necessary to get that support; such flags differ from one compiler to another.</span></span>

<span data-ttu-id="c9c2f-159">Visual Studio は、マイクロソフトがサポートし、C++/WinRT 用に推奨する開発ツールです。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-159">Visual Studio is the development tool that we support and recommend for C++/WinRT.</span></span> <span data-ttu-id="c9c2f-160">参照してください[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-160">See [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package).</span></span>

## <a name="why-doesnt-the-generated-implementation-function-for-a-read-only-property-have-the-const-qualifier"></a><span data-ttu-id="c9c2f-161">読み取り専用プロパティの実装が生成された関数がない理由、`const`修飾子ですか?</span><span class="sxs-lookup"><span data-stu-id="c9c2f-161">Why doesn't the generated implementation function for a read-only property have the `const` qualifier?</span></span>
<span data-ttu-id="c9c2f-162">読み取り専用プロパティを宣言するときに[MIDL 3.0](/uwp/midl-3/)、想像、`cppwinrt.exe`実装の機能を生成するツールが`const`-修飾 (const 関数の処理、*この*定数としてのポインター)。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-162">When you declare a read-only property in [MIDL 3.0](/uwp/midl-3/), you might expect the `cppwinrt.exe` tool to generate an implementation function for you that is `const`-qualified (a const function treats the *this* pointer as const).</span></span>

<span data-ttu-id="c9c2f-163">確かに可能な限り、定数の使用をお勧めは`cppwinrt.exe`ツール自体の実装について関数が考えも const とする可能性がある理由は行われません。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-163">We certainly recommend using const wherever possible, but the `cppwinrt.exe` tool itself doesn't attempt to reason about which implementation functions might conceivably be const, and which might not.</span></span> <span data-ttu-id="c9c2f-164">この例のように、const、実装する関数のいずれかのことを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-164">You can choose to make any of your implementation functions const, as in this example.</span></span>

```cppwinrt
struct MyStringable : winrt::implements<MyStringable, winrt::Windows::Foundation::IStringable>
{
    winrt::hstring ToString() const
    {
        return L"MyStringable";
    }
};
```

<span data-ttu-id="c9c2f-165">削除することができます`const`で修飾子**ToString**実装でいくつかのオブジェクト状態を変更する必要がありますを決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-165">You can remove that `const` qualifier on **ToString** should you decide that you need to alter some object state in its implementation.</span></span> <span data-ttu-id="c9c2f-166">メンバーの両方ではなく関数 const または非定数のいずれか。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-166">But make each of your member functions either const or non-const, not both.</span></span> <span data-ttu-id="c9c2f-167">つまり、しないオーバー ロードの実装の機能で`const`します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-167">In other words, don't overload an implementation function on `const`.</span></span>

<span data-ttu-id="c9c2f-168">別に、実装関数では、const が配置他別に画像が Windows ランタイム関数の射影では。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-168">Aside from your implementation functions, another other place where const comes into the picture is in Windows Runtime function projections.</span></span> <span data-ttu-id="c9c2f-169">このコードを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-169">Consider this code.</span></span>

```cppwinrt
int main()
{
    winrt::Windows::Foundation::IStringable s{ winrt::make<MyStringable>() };
    auto result{ s.ToString() };
}
```

<span data-ttu-id="c9c2f-170">呼び出しに**ToString** 、上、**宣言へ移動**Visual Studio でのコマンドを示します Windows ランタイムの投影**IStringable::ToString** C +/cliWinRT は、次のように検索します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-170">For the call to **ToString** above, the **Go To Declaration** command in Visual Studio shows that the projection of the Windows Runtime **IStringable::ToString** into C++/WinRT looks like this.</span></span>

```
winrt::hstring ToString() const;
```

<span data-ttu-id="c9c2f-171">投影の関数は、それらの実装を修飾するために選択する方法に関係なく const です。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-171">Functions on the projection are const no matter how you choose to qualify your implementation of them.</span></span> <span data-ttu-id="c9c2f-172">バック グラウンドでは、プロジェクションは、アプリケーション バイナリ インターフェイス (ABI) COM インターフェイス ポインターからの呼び出しには、その場合を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-172">Behind the scenes, the projection calls the application binary interface (ABI), which amounts to a call through a COM interface pointer.</span></span> <span data-ttu-id="c9c2f-173">唯一の状態、射影された**ToString**対話は COM インターフェイス ポインター。 が確実に必要としないので、関数が const、そのポインターを変更します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-173">The only state that the projected **ToString** interacts with is that COM interface pointer; and it certainly has no need to modify that pointer, so the function is const.</span></span> <span data-ttu-id="c9c2f-174">これにより、確実にについて何も変更されません、 **IStringable**参照を通じて、呼び出し先を呼び出すことができるようになります**ToString** へのconst参照でも**IStringable**します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-174">This gives you the assurance that it won't change anything about the **IStringable** reference that you're calling through, and it ensures that you can call **ToString** even with a const reference to an **IStringable**.</span></span>

<span data-ttu-id="c9c2f-175">理解これらの例の`const`C + の実装の詳細は/cli WinRT プロジェクションと実装には、特典のコードの検疫が構成します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-175">Understand that these examples of `const` are implementation details of C++/WinRT projections and implementations; they constitute code hygiene for your benefit.</span></span> <span data-ttu-id="c9c2f-176">ようなものがない`const`COM も (メンバー関数) 用の Windows ランタイム ABI にします。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-176">There's no such thing as `const` on the COM nor Windows Runtime ABI (for member functions).</span></span>

## <a name="do-you-have-any-recommendations-for-decreasing-the-code-size-for-cwinrt-binaries"></a><span data-ttu-id="c9c2f-177">C++ コードのサイズを減らすための推奨事項がある/cli WinRT バイナリでしょうか。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-177">Do you have any recommendations for decreasing the code size for C++/WinRT binaries?</span></span>
<span data-ttu-id="c9c2f-178">Windows ランタイム オブジェクトを使用する場合は、バイナリ コードを生成するために必要なは、それによって、アプリケーションに悪影響を及ぼすことがあるできますので、次に示すコーディング パターンを避ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-178">When working with Windows Runtime objects, you should avoid the coding pattern shown below because it can have a negative impact on your application by causing more binary code than necessary to be generated.</span></span>

```cppwinrt
anobject.b().c().d();
anobject.b().c().e();
anobject.b().c().f();
```

<span data-ttu-id="c9c2f-179">Windows ランタイムの世界も、コンパイラの値をキャッシュできる`c()`または間接参照を通じて呼び出される各メソッドのインターフェイス ('. ')。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-179">In the Windows Runtime world, the compiler is unable to cache either the value of `c()` or the interfaces for each method that's called through an indirection ('.').</span></span> <span data-ttu-id="c9c2f-180">介入した場合を除き、複数の仮想呼び出しおよび参照カウントのオーバーヘッドが発生します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-180">Unless you intervene, that results in more virtual calls and reference counting overhead.</span></span> <span data-ttu-id="c9c2f-181">上記のパターンに厳密に必要な 2 回の多くのコードを生成簡単でした。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-181">The pattern above could easily generate twice as much code as strictly needed.</span></span> <span data-ttu-id="c9c2f-182">代わりに、できる任意の場所の下に示すパターンを使用します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-182">Instead, prefer the pattern shown below wherever you can.</span></span> <span data-ttu-id="c9c2f-183">少量のコードを生成し、実行時のパフォーマンスを向上させることができますも大幅にします。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-183">It generates a lot less code, and it can also dramatically improve your run time performance.</span></span>

```cppwinrt
auto a{ anobject.b().c() };
a.d();
a.e();
a.f();
```

<span data-ttu-id="c9c2f-184">上記の推奨されるパターンは、C + にだけでなく適用/cli WinRT がすべての Windows ランタイム言語プロジェクションにします。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-184">The recommended pattern shown above applies not just to C++/WinRT but to all Windows Runtime language projections.</span></span>

## <a name="how-do-i-turn-a-string-into-a-typemdashfor-navigation-for-example"></a><span data-ttu-id="c9c2f-185">型に文字列にどのように&mdash;例については、ナビゲーションのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-185">How do I turn a string into a type&mdash;for navigation, for example?</span></span>
<span data-ttu-id="c9c2f-186">最後に、[ナビゲーションの表示のコード例](/windows/uwp/design/controls-and-patterns/navigationview#code-example)(のほとんどの場合はC#) は c++/cli これを行う方法を示す、WinRT コード スニペット。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-186">At the end of the [Navigation view code example](/windows/uwp/design/controls-and-patterns/navigationview#code-example) (which is mostly in C#), there's a C++/WinRT code snippet showing how to do this.</span></span>

> [!NOTE]
> <span data-ttu-id="c9c2f-187">このトピックでは、質問に答えしていないかどうかを参照してくださいヘルプを見つけることがあります、[開発者コミュニティの Visual Studio C](https://developercommunity.visualstudio.com/spaces/62/index.html)、またはを使用して、 [ `c++-winrt` Stack Overflow でタグ付け](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="c9c2f-187">If this topic didn't answer your question, then you might find help by visiting the [Visual Studio C++ developer community](https://developercommunity.visualstudio.com/spaces/62/index.html), or by using the [`c++-winrt` tag on Stack Overflow](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt).</span></span>
