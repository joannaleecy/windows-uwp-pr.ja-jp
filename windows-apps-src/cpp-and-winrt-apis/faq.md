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
ms.openlocfilehash: eb4b7b78bf3ef0a561d102804a245c59b6519796
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/02/2018
ms.locfileid: "4264357"
---
# <a name="frequently-asked-questions-about-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="3b100-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) についてよく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="3b100-104">Frequently-asked questions about [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="3b100-105">C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。</span><span class="sxs-lookup"><span data-stu-id="3b100-105">Answers to questions that you're likely to have about authoring and consuming Windows Runtime APIs with C++/WinRT.</span></span>

> [!NOTE]
> <span data-ttu-id="3b100-106">質問の内容が、表示されたエラー メッセージに関するものである場合は、「[C++/WinRT に関する問題のトラブルシューティング](troubleshooting.md)」のトピックも参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b100-106">If your question is about an error message that you've seen, then also see the [Troubleshooting C++/WinRT](troubleshooting.md) topic.</span></span>

## <a name="how-do-i-retarget-my-cwinrt-project-to-a-later-version-of-the-windows-sdk"></a><span data-ttu-id="3b100-107">どの行う I 対象 my C + + 以降のバージョンの Windows SDK に WinRT プロジェクトかどうか。</span><span class="sxs-lookup"><span data-stu-id="3b100-107">How do I retarget my C++/WinRT project to a later version of the Windows SDK?</span></span>

<span data-ttu-id="3b100-108">Windows SDK の最新の一般公開バージョンは、10.0.17763.0 (Windows 10、バージョン 1809) です。</span><span class="sxs-lookup"><span data-stu-id="3b100-108">The latest generally-available version of the Windows SDK is 10.0.17763.0 (Windows 10, version 1809).</span></span> <span data-ttu-id="3b100-109">最小限のコンパイラとリンカーの問題が発生する可能性があるプロジェクトの再ターゲットのメソッドは、最も労力が必要もあります。</span><span class="sxs-lookup"><span data-stu-id="3b100-109">The method for retargeting your project that's likely to result in the fewest compiler and linker issue is also the most labor-intensive.</span></span> <span data-ttu-id="3b100-110">(任意の Windows SDK バージョンをターゲットと)、新しいプロジェクトを作成して、古いからは経由で新しいプロジェクトのファイルをコピーし、そのメソッドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="3b100-110">That method involves creating a new project (targeting the Windows SDK version of your choice), and then copying files over to your new project from your old.</span></span> <span data-ttu-id="3b100-111">古いのセクションがあります`.vcxproj`と`.vcxproj.filters`すればファイルのコピーで Visual Studio でファイルを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-111">There will be sections of your old `.vcxproj` and `.vcxproj.filters` files that you can just copy over to save you adding files in Visual Studio.</span></span>

<span data-ttu-id="3b100-112">ただし、Visual Studio でプロジェクトのターゲットを変更する他の 2 つの方法はあります。</span><span class="sxs-lookup"><span data-stu-id="3b100-112">However, there are two other ways to retarget your project in Visual Studio.</span></span>

- <span data-ttu-id="3b100-113">**一般的な**プロパティをプロジェクトに移動する \> **Windows SDK のバージョン**と選択の**すべての構成**と**すべてのプラットフォーム**です。</span><span class="sxs-lookup"><span data-stu-id="3b100-113">Go to project property **General** \> **Windows SDK Version**, and select **All Configurations** and **All Platforms**.</span></span> <span data-ttu-id="3b100-114">バージョンをターゲットにするには、 **Windows SDK バージョン**を設定します。</span><span class="sxs-lookup"><span data-stu-id="3b100-114">Set **Windows SDK Version** to the version that you want to target.</span></span>
- <span data-ttu-id="3b100-115">**ソリューション エクスプ ローラー**でプロジェクト ノードを右クリックして、**プロジェクトの再ターゲット**] をクリックを対象とするバージョンを選択し、 **[ok]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3b100-115">In **Solution Explorer**, right-click the project node, click **Retarget Projects**, choose the version(s) you wish to target, and then click **OK**.</span></span>

<span data-ttu-id="3b100-116">これら 2 つの方法のいずれかを使用した後、コンパイラやリンカーのエラーが発生するかどうかは、ソリューションをクリーンアップしてみてください (**ビルド** > **クリーンなソリューション**や、すべての一時フォルダーとファイルを手動で削除) もう一度ビルドを試みる前にします。</span><span class="sxs-lookup"><span data-stu-id="3b100-116">If you encounter any compiler or linker errors after using either of these two methods, then you can try cleaning the solution (**Build** > **Clean Solution** and/or manually delete all temporary folders and files) before trying to build again.</span></span>

<span data-ttu-id="3b100-117">C++ コンパイラーが場合"*エラー C2039: 'IUnknown': のメンバーでない '\'global 名前空間'*"、追加し、`#include <unknwn.h>`の先頭に、`pch.h`ファイル。</span><span class="sxs-lookup"><span data-stu-id="3b100-117">If the C++ compiler produces "*error C2039: 'IUnknown': is not a member of '\`global namespace''*", then add `#include <unknwn.h>` to the top of your `pch.h` file.</span></span>

<span data-ttu-id="3b100-118">追加する必要があります`#include <hstring.h>`後です。</span><span class="sxs-lookup"><span data-stu-id="3b100-118">You may also need to add `#include <hstring.h>` after that.</span></span>

<span data-ttu-id="3b100-119">C++ リンカーを生成する場合"*エラー lnk 2019: 外部シンボルは未解決_WINRT_CanUnloadNow@0関数で参照されている_VSDesignerCanUnloadNow@0*"を追加することで解決できます`#define _VSDESIGNER_DONT_LOAD_AS_DLL`を`pch.h`ファイル。</span><span class="sxs-lookup"><span data-stu-id="3b100-119">If the C++ linker produces "*error LNK2019: unresolved external symbol _WINRT_CanUnloadNow@0 referenced in function _VSDesignerCanUnloadNow@0*", then you can resolve that by adding `#define _VSDESIGNER_DONT_LOAD_AS_DLL` to your `pch.h` file.</span></span>


## <a name="why-wont-my-new-project-compile-im-using-visual-studio-2017-version-1580-or-higher-and-sdk-version-17134"></a><span data-ttu-id="3b100-120">新しいプロジェクトがコンパイルされません。</span><span class="sxs-lookup"><span data-stu-id="3b100-120">Why won't my new project compile?</span></span> <span data-ttu-id="3b100-121">Visual Studio 2017 を使用している (バージョン 15.8.0 以上)、および SDK バージョン 17134</span><span class="sxs-lookup"><span data-stu-id="3b100-121">I'm using Visual Studio 2017 (version 15.8.0 or higher), and SDK version 17134</span></span>

<span data-ttu-id="3b100-122">Visual Studio 2017 を使用している場合 (バージョン 15.8.0 以降) をターゲットとする Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) し、新しく作成した、C++/WinRT プロジェクトをコンパイル エラーで失敗する可能性が"*エラー C3861: 'from_abi': 識別子しません。見つかった*"、および*base.h*でその他のエラー。</span><span class="sxs-lookup"><span data-stu-id="3b100-122">If you're using Visual Studio 2017 (version 15.8.0 or higher), and targeting the Windows SDK version 10.0.17134.0 (Windows 10, version 1803), then a newly created C++/WinRT project may fail to compile with the error "*error C3861: 'from_abi': identifier not found*", and with other errors originating in *base.h*.</span></span> <span data-ttu-id="3b100-123">解決策は、いずれかのターゲット以降 (詳しく準拠) のバージョンの Windows SDK、またはプロジェクトのプロパティを設定する**C/C++** > **言語** > **Conformance mode: いいえ**(も場合、 **/制限解除-** **プロジェクトのプロパティに表示されますC/C++** > **言語** > **コマンド ライン**[**その他のオプション**を削除します)。</span><span class="sxs-lookup"><span data-stu-id="3b100-123">The solution is to either target a later (more conformant) version of the Windows SDK, or set project property **C/C++** > **Language** > **Conformance mode: No** (also, if **/permissive-** appears in project property **C/C++** > **Language** > **Command Line** under **Additional Options**, then delete it).</span></span>

## <a name="what-are-the-requirements-for-the-cwinrt-visual-studio-extension-vsixhttpsakamscppwinrtvsix"></a><span data-ttu-id="3b100-124"> [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) の要件</span><span class="sxs-lookup"><span data-stu-id="3b100-124">What are the requirements for the [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)?</span></span>
<span data-ttu-id="3b100-125">[VSIX](https://aka.ms/cppwinrt/vsix) の最小要件は、Windows SDK ターゲット バージョン 10.0.17134.0 (Windows 10、バージョン 1803) です。</span><span class="sxs-lookup"><span data-stu-id="3b100-125">The [VSIX](https://aka.ms/cppwinrt/vsix) enforces a minimum Windows SDK target version of 10.0.17134.0 (Windows 10, version 1803).</span></span> <span data-ttu-id="3b100-126">Visual Studio 2017 (バージョン 15.6 以上、15.7 以上を推奨) も必要になります 。</span><span class="sxs-lookup"><span data-stu-id="3b100-126">You'll also need Visual Studio 2017 (at least version 15.6; we recommend at least 15.7).</span></span> <span data-ttu-id="3b100-127">`.vcxproj` ファイルの `<PropertyGroup Label="Globals">` に `<CppWinRTEnabled>true</CppWinRTEnabled>` があるかどうかによって、VSIX を使用するプロジェクトを特定できます。</span><span class="sxs-lookup"><span data-stu-id="3b100-127">You can identify a project that uses the VSIX by the presence of `<CppWinRTEnabled>true</CppWinRTEnabled>` in `<PropertyGroup Label="Globals">` in the `.vcxproj` file.</span></span> <span data-ttu-id="3b100-128">詳しくは、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b100-128">For more info, see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="whats-a-runtime-class"></a><span data-ttu-id="3b100-129">*ランタイム クラス*とは</span><span class="sxs-lookup"><span data-stu-id="3b100-129">What's a *runtime class*?</span></span>
<span data-ttu-id="3b100-130">ランタイム クラスは、通常実行可能な境界を越えて、モダン COM インターフェイス経由でアクティブ化および使用可能な型です。</span><span class="sxs-lookup"><span data-stu-id="3b100-130">A runtime class is a type that can be activated and consumed via modern COM interfaces, typically across executable boundaries.</span></span> <span data-ttu-id="3b100-131">ただし、ランタイム クラスは、それを実装するコンパイル ユニット内でも使用できます。</span><span class="sxs-lookup"><span data-stu-id="3b100-131">However, a runtime class can also be used within the compilation unit that implements it.</span></span> <span data-ttu-id="3b100-132">インターフェイス定義言語 (IDL) でランタイム クラスを宣言し、C++/WinRT を使用した標準の C++ で実装することができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-132">You declare a runtime class in Interface Definition Language (IDL), and you can implement it in standard C++ using C++/WinRT.</span></span>

## <a name="what-do-the-projected-type-and-the-implementation-type-mean"></a><span data-ttu-id="3b100-133">*プロジェクションされる型*と*実装型*とは</span><span class="sxs-lookup"><span data-stu-id="3b100-133">What do *the projected type* and *the implementation type* mean?</span></span>
<span data-ttu-id="3b100-134">Windows ランタイム クラス (ランタイム クラス) を*使用*する場合のみ、*プロジェクションされる型*を排他的に処理します。</span><span class="sxs-lookup"><span data-stu-id="3b100-134">If you're only *consuming* a Windows Runtime class (runtime class), then you'll be dealing exclusively with *projected types*.</span></span> <span data-ttu-id="3b100-135">C++/WinRT は*言語のプロジェクション*であるため、プロジェクションされる型は、C++/WinRT を使用した C++ に*プロジェクション*される Windows ランタイムの画面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b100-135">C++/WinRT is a *language projection*, so projected types are part of the surface of the Windows Runtime that's *projected* into C++ with C++/WinRT.</span></span> <span data-ttu-id="3b100-136">詳しくは、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b100-136">For more details, see see [Consume APIs with C++/WinRT](consume-apis.md).</span></span>

<span data-ttu-id="3b100-137">*実装型*にはランタイム クラスの実装が含まれるため、ランタイム クラスを実装するプロジェクトでのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="3b100-137">The *implementation type* contains the implementation of a runtime class, so it's only available in the project that implements the runtime class.</span></span> <span data-ttu-id="3b100-138">ランタイム クラス (Windows ランタイム コンポーネント プロジェクト、つまり XAML UI を使用するプロジェクト) を実装するプロジェクトで作業している場合、ランタイム クラスの実装型と C++/WinRT にプロジェクションされたランタイム クラスを表すプロジェクションされる型との違いを習熟することが重要です。</span><span class="sxs-lookup"><span data-stu-id="3b100-138">When you're working in a project that implements runtime classes (a Windows Runtime component project, or a project that uses XAML UI), it's important to be comfortable with the distinction between your implementation type for a runtime class, and the projected type that represents the runtime class projected into C++/WinRT.</span></span> <span data-ttu-id="3b100-139">詳細については、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b100-139">For more details, see [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="do-i-need-to-declare-a-constructor-in-my-runtime-classs-idl"></a><span data-ttu-id="3b100-140">使用するランタイム クラスの IDL でコンストラクターを宣言する必要性</span><span class="sxs-lookup"><span data-stu-id="3b100-140">Do I need to declare a constructor in my runtime class's IDL?</span></span>
<span data-ttu-id="3b100-141">ランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合のみ</span><span class="sxs-lookup"><span data-stu-id="3b100-141">Only if the runtime class is designed to be consumed from outside its implementing compilation unit (it's a Windows Runtime component intended for general consumption by Windows Runtime client apps).</span></span> <span data-ttu-id="3b100-142">IDL のコンストラクターを宣言する際の目的と影響の詳細については、「[ランタイム クラス コンストラクター](author-apis.md#runtime-class-constructors)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b100-142">For full details on the purpose and consequences of declaring constructor(s) in IDL, see [Runtime class constructors](author-apis.md#runtime-class-constructors).</span></span>

## <a name="why-is-the-linker-giving-me-a-lnk2019-unresolved-external-symbol-error"></a><span data-ttu-id="3b100-143">リンカーで "LNK2019: 外部シンボルは未解決です" というエラーが表示されるのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="3b100-143">Why is the linker giving me a "LNK2019: Unresolved external symbol" error?</span></span>
<span data-ttu-id="3b100-144">未解決のシンボルが (**winrt** 名前空間内の) C++/WinRT プロジェクションの Windows 名前空間ヘッダーからの API である場合、その API は含まれているヘッダー内で事前宣言されていますが、その定義は含まれていないヘッダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="3b100-144">If the unresolved symbol is an API from the Windows namespace headers for the C++/WinRT projection (in the **winrt** namespace), then the API is forward-declared in a header that you've included, but its definition is in a header that you haven't yet included.</span></span> <span data-ttu-id="3b100-145">API の名前空間で付けられた名前のヘッダーを含めてから、リビルドしてください。</span><span class="sxs-lookup"><span data-stu-id="3b100-145">Include the header named for the API's namespace, and rebuild.</span></span> <span data-ttu-id="3b100-146">詳細については、「[C++/WinRT プロジェクション ヘッダー](consume-apis.md#cwinrt-projection-headers)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b100-146">For more info, see [C++/WinRT projection headers](consume-apis.md#cwinrt-projection-headers).</span></span>

<span data-ttu-id="3b100-147">未解決のシンボルが [RoInitialize](https://msdn.microsoft.com/library/br224650) などの Windows ランタイムの自由関数である場合、[WindowsApp.lib](/uwp/win32-and-com/win32-apis) の包括的なライブラリを明示的にプロジェクトに含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3b100-147">If the unresolved symbol is a Windows Runtime free function, such as [RoInitialize](https://msdn.microsoft.com/library/br224650), then you'll need to explicitly include the [WindowsApp.lib](/uwp/win32-and-com/win32-apis) umbrella library in your project.</span></span> <span data-ttu-id="3b100-148">C++/WinRT プロジェクションは、これらの一部の自由 (非メンバー) 関数とエントリ ポイントに依存します。</span><span class="sxs-lookup"><span data-stu-id="3b100-148">The C++/WinRT projection depends on some of these free (non-member) functions and entry points.</span></span> <span data-ttu-id="3b100-149">アプリケーションでいずれかの [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) プロジェクト テンプレートを使用する場合は、`WindowsApp.lib` が自動的にリンクされます。</span><span class="sxs-lookup"><span data-stu-id="3b100-149">If you use one of the [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) project templates for your application, then `WindowsApp.lib` is linked for you automatically.</span></span> <span data-ttu-id="3b100-150">それ以外の場合、プロジェクトのリンク設定を使用して含めるか、またはソース コードでそれを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-150">Otherwise, you can use project link settings to include it, or do it in source code.</span></span>

```cppwinrt
#pragma comment(lib, "windowsapp")
```

## <a name="should-i-implement-windowsfoundationiclosableuwpapiwindowsfoundationiclosable-and-if-so-how"></a><span data-ttu-id="3b100-151">[**Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) を実装するかどうかとその方法</span><span class="sxs-lookup"><span data-stu-id="3b100-151">Should I implement [**Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) and, if so, how?</span></span>
<span data-ttu-id="3b100-152">自身のデストラクターのリソースを解放するランタイム クラスを使用し、そのランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合、確定終了処理が不足する言語でランタイム クラスの使用をサポートするために、**IClosable** も実装することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3b100-152">If you have a runtime class that frees resources in its destructor, and that runtime class is designed to be consumed from outside its implementing compilation unit (it's a Windows Runtime component intended for general consumption by Windows Runtime client apps), then we recommend that you also implement **IClosable** in order to support the consumption of your runtime class by languages that lack deterministic finalization.</span></span> <span data-ttu-id="3b100-153">デストラクター、[**IClosable::Close**](/uwp/api/windows.foundation.iclosable.Close)、または両方が呼び出されたときにリソースが解放されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="3b100-153">Make sure that your resources are freed whether the destructor, [**IClosable::Close**](/uwp/api/windows.foundation.iclosable.Close), or both are called.</span></span> <span data-ttu-id="3b100-154">**IClosable::Close** は必要に応じて呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-154">**IClosable::Close** may be called an arbitrary number of times.</span></span>

## <a name="do-i-need-to-call-iclosablecloseuwpapiwindowsfoundationiclosablewindowsfoundationiclosableclose-on-runtime-classes-that-i-consume"></a><span data-ttu-id="3b100-155">使用するランタイム クラスで [**IClosable::Close**](/uwp/api/windows.foundation.iclosable#Windows_Foundation_IClosable_Close_) を読み出す必要性</span><span class="sxs-lookup"><span data-stu-id="3b100-155">Do I need to call [**IClosable::Close**](/uwp/api/windows.foundation.iclosable#Windows_Foundation_IClosable_Close_) on runtime classes that I consume?</span></span>
<span data-ttu-id="3b100-156">**IClosable** は確定終了処理が不足する言語をサポートします。</span><span class="sxs-lookup"><span data-stu-id="3b100-156">**IClosable** exists to support languages that lack deterministic finalization.</span></span> <span data-ttu-id="3b100-157">そのため、シャットダウン状態やデッドロック状態といった非常にまれな場合を除いて、C++/WinRT から **IClosable::Close** を呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="3b100-157">So, you shouldn't call **IClosable::Close** from C++/WinRT, except in very rare cases involving shutdown races or semi-deadly embraces.</span></span> <span data-ttu-id="3b100-158">たとえば、**Windows.UI.Composition** を使用していて、設定順序でオブジェクトを破棄する場合、その代わりとして、C++/WinRT ラッパーを破棄することができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-158">If you're using **Windows.UI.Composition** types, as an example, then you may encounter cases where you want to dispose objects in a set sequence, as an alternative to allowing the destruction of the C++/WinRT wrapper do the work for you.</span></span>

## <a name="can-i-use-llvmclang-to-compile-with-cwinrt"></a><span data-ttu-id="3b100-159">LLVM/Clang を使用して C++/WinRT でコンパイルすることはできますか。</span><span class="sxs-lookup"><span data-stu-id="3b100-159">Can I use LLVM/Clang to compile with C++/WinRT?</span></span>
<span data-ttu-id="3b100-160">C++/WinRT の LLVM および Clang ツール チェーンはサポートしていませんが、C++/WinRT の標準への準拠を検証するためにそれを内部で使用します。</span><span class="sxs-lookup"><span data-stu-id="3b100-160">We don't support the LLVM and Clang toolchain for C++/WinRT, but we do make use of it internally to validate C++/WinRT's standards conformance.</span></span> <span data-ttu-id="3b100-161">たとえば、マイクロソフトが内部で行っている内容をエミュレートする場合は、次に説明するような実験を試してみることができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-161">For example, if you wanted to emulate what we do internally, then you could try an experiment such as the one described below.</span></span>

<span data-ttu-id="3b100-162">[LLVM ダウンロード ページ](https://releases.llvm.org/download.html)に移動し、**[Download LLVM 6.0.0] (LLVM 6.0.0 のダウンロード)** > **[Pre-Built Binaries] (事前ビルドされたバイナリ)** を探し、**[Clang for Windows (64-bit)] (Windows の Clang (64 ビット))** をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="3b100-162">Go to the [LLVM Download Page](https://releases.llvm.org/download.html), look for **Download LLVM 6.0.0** > **Pre-Built Binaries**, and download **Clang for Windows (64-bit)**.</span></span> <span data-ttu-id="3b100-163">インストール中に、コマンド プロンプトから起動できるように、PATH システム変数に LLVM を追加することを選択します。</span><span class="sxs-lookup"><span data-stu-id="3b100-163">During installation, opt to add LLVM to the PATH system variable so that you'll be able to invoke it from a command prompt.</span></span> <span data-ttu-id="3b100-164">この実験の目的上、"Failed to find MSBuild toolsets directory (MSBuild ツールセット ディレクトリの検索に失敗しました)" または "MSVC integration install failed (MSVC 統合インストールに失敗しました)" というエラーが表示された場合には無視できます。</span><span class="sxs-lookup"><span data-stu-id="3b100-164">For the purposes of this experiment, you can ignore any "Failed to find MSBuild toolsets directory" and/or "MSVC integration install failed" errors, if you see them.</span></span> <span data-ttu-id="3b100-165">LLVM/Clang を起動するさまざまな方法があります。次の例は、1 つの方法のみを示しています。</span><span class="sxs-lookup"><span data-stu-id="3b100-165">There are a variety of ways to invoke LLVM/Clang; the example below shows just one way.</span></span>

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

<span data-ttu-id="3b100-166">C++/WinRT では C++17 標準の機能を使用するため、そのサポートを受けるために必要なコンパイラ フラグを使用する必要があります。そのようなフラグはコンパイラによって異なります。</span><span class="sxs-lookup"><span data-stu-id="3b100-166">Because C++/WinRT uses features from the C++17 standard, you'll need to use whatever compiler flags are necessary to get that support; such flags differ from one compiler to another.</span></span>

<span data-ttu-id="3b100-167">Visual Studio は、マイクロソフトがサポートし、C++/WinRT 用に推奨する開発ツールです。</span><span class="sxs-lookup"><span data-stu-id="3b100-167">Visual Studio is the development tool that we support and recommend for C++/WinRT.</span></span> <span data-ttu-id="3b100-168">「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b100-168">See [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="why-doesnt-the-generated-implementation-function-for-a-read-only-property-have-the-const-qualifier"></a><span data-ttu-id="3b100-169">読み取り専用プロパティの実装が生成された関数がない理由、`const`修飾子かどうか。</span><span class="sxs-lookup"><span data-stu-id="3b100-169">Why doesn't the generated implementation function for a read-only property have the `const` qualifier?</span></span>

<span data-ttu-id="3b100-170">期待どおり[MIDL 3.0](/uwp/midl-3/)で読み取り専用プロパティを宣言するとき、`cppwinrt.exe`されるツールの実装の機能を生成する`const`-修飾 (const 関数は、定数として*この*ポインターを扱う)。</span><span class="sxs-lookup"><span data-stu-id="3b100-170">When you declare a read-only property in [MIDL 3.0](/uwp/midl-3/), you might expect the `cppwinrt.exe` tool to generate an implementation function for you that is `const`-qualified (a const function treats the *this* pointer as const).</span></span>

<span data-ttu-id="3b100-171">可能であれば、定数を使用してを確実にお勧めしますが`cppwinrt.exe`のどの実装について関数考え const する可能性がある理由ツール自体は行われません。</span><span class="sxs-lookup"><span data-stu-id="3b100-171">We certainly recommend using const wherever possible, but the `cppwinrt.exe` tool itself doesn't attempt to reason about which implementation functions might conceivably be const, and which might not.</span></span> <span data-ttu-id="3b100-172">この例のように、const させる、実装する関数のいずれかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="3b100-172">You can choose to make any of your implementation functions const, as in this example.</span></span>

```cppwinrt
struct MyStringable : winrt::implements<MyStringable, winrt::Windows::Foundation::IStringable>
{
    winrt::hstring ToString() const
    {
        return L"MyStringable";
    }
};
```

<span data-ttu-id="3b100-173">削除することができます`const` **ToString**の修飾子すべき実装ではいくつかオブジェクトの状態を変更する必要があることを決定します。</span><span class="sxs-lookup"><span data-stu-id="3b100-173">You can remove that `const` qualifier on **ToString** should you decide that you need to alter some object state in its implementation.</span></span> <span data-ttu-id="3b100-174">各メンバーの両方ではなく関数 const または非定数のいずれか。</span><span class="sxs-lookup"><span data-stu-id="3b100-174">But make each of your member functions either const or non-const, not both.</span></span> <span data-ttu-id="3b100-175">つまり、しないオーバー ロードの実装の機能で`const`します。</span><span class="sxs-lookup"><span data-stu-id="3b100-175">In other words, don't overload an implementation function on `const`.</span></span>

<span data-ttu-id="3b100-176">Const 場所に配置別の他の実装の関数を除くが使えるように画像は、Windows ランタイム関数のプロジェクションにします。</span><span class="sxs-lookup"><span data-stu-id="3b100-176">Aside from your implementation functions, another other place where const comes into the picture is in Windows Runtime function projections.</span></span> <span data-ttu-id="3b100-177">このコードを検討してください。</span><span class="sxs-lookup"><span data-stu-id="3b100-177">Consider this code.</span></span>

```cppwinrt
int main()
{
    winrt::Windows::Foundation::IStringable s{ winrt::make<MyStringable>() };
    auto result{ s.ToString() };
}
```

<span data-ttu-id="3b100-178">**ToString**上記を呼び出し、Visual Studio で**宣言へ移動**コマンド示されている C++ に**istringable::tostring** Windows ランタイムのプロジェクション/WinRT は次のようです。</span><span class="sxs-lookup"><span data-stu-id="3b100-178">For the call to **ToString** above, the **Go To Declaration** command in Visual Studio shows that the projection of the Windows Runtime **IStringable::ToString** into C++/WinRT looks like this.</span></span>

```
winrt::hstring ToString() const;
```

<span data-ttu-id="3b100-179">プロジェクションの関数は、資格を得ることの実装を選択する方法に関係なく const。</span><span class="sxs-lookup"><span data-stu-id="3b100-179">Functions on the projection are const no matter how you choose to qualify your implementation of them.</span></span> <span data-ttu-id="3b100-180">背後では、プロジェクションは、アプリケーション バイナリ インターフェイス (ABI)、COM インターフェイス ポインターを使用して、呼び出しをどの金額を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3b100-180">Behind the scenes, the projection calls the application binary interface (ABI), which amounts to a call through a COM interface pointer.</span></span> <span data-ttu-id="3b100-181">投影された**ToString**と対話する唯一の状態がその COM インターフェイスのポインターです。その確実に不要になったため、関数は const そのポインターを変更します。</span><span class="sxs-lookup"><span data-stu-id="3b100-181">The only state that the projected **ToString** interacts with is that COM interface pointer; and it certainly has no need to modify that pointer, so the function is const.</span></span> <span data-ttu-id="3b100-182">これにより、 **IStringable**を参照する保証を通じてを呼び出している**IStringable**の参照について何も変わりませんことと、これにより、const しても**ToString**を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-182">This gives you the assurance that it won't change anything about the **IStringable** reference that you're calling through, and it ensures that you can call **ToString** even with a const reference to an **IStringable**.</span></span>

<span data-ttu-id="3b100-183">理解するこれらの例の`const`は、C++ の実装の詳細/WinRT プロジェクションおよび実装します。やすくするコードに対する予防措置を構成しています。</span><span class="sxs-lookup"><span data-stu-id="3b100-183">Understand that these examples of `const` are implementation details of C++/WinRT projections and implementations; they constitute code hygiene for your benefit.</span></span> <span data-ttu-id="3b100-184">このようなものはありません`const`COM も (メンバー関数) 用の Windows ランタイム ABI のします。</span><span class="sxs-lookup"><span data-stu-id="3b100-184">There's no such thing as `const` on the COM nor Windows Runtime ABI (for member functions).</span></span>

## <a name="do-you-have-any-recommendations-for-decreasing-the-code-size-for-cwinrt-binaries"></a><span data-ttu-id="3b100-185">C++ コードのサイズを小さくに関する推奨事項がある/WinRT バイナリかどうか。</span><span class="sxs-lookup"><span data-stu-id="3b100-185">Do you have any recommendations for decreasing the code size for C++/WinRT binaries?</span></span>

<span data-ttu-id="3b100-186">Windows ランタイム オブジェクトを使用する際は、指定できるので否定的な影響をアプリケーションで以上バイナリのコードを生成するために必要なことで、次に示すコーディング パターンを避ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="3b100-186">When working with Windows Runtime objects, you should avoid the coding pattern shown below because it can have a negative impact on your application by causing more binary code than necessary to be generated.</span></span>

```cppwinrt
anobject.b().c().d();
anobject.b().c().e();
anobject.b().c().f();
```

<span data-ttu-id="3b100-187">Windows ランタイムの世界でコンパイラことができないの値をキャッシュ`c()`または間接参照から呼び出されるメソッドでは各インターフェイス ('.")。</span><span class="sxs-lookup"><span data-stu-id="3b100-187">In the Windows Runtime world, the compiler is unable to cache either the value of `c()` or the interfaces for each method that's called through an indirection ('.').</span></span> <span data-ttu-id="3b100-188">介入する場合を除き、複数の仮想呼び出しと参照カウントのオーバーヘッドを結果します。</span><span class="sxs-lookup"><span data-stu-id="3b100-188">Unless you intervene, that results in more virtual calls and reference counting overhead.</span></span> <span data-ttu-id="3b100-189">上記のパターンでは、として厳密に必要な 2 回の多くのコードを簡単に作成可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3b100-189">The pattern above could easily generate twice as much code as strictly needed.</span></span> <span data-ttu-id="3b100-190">代わりに、以下を参照することができる場合は必ずパターンを好みます。</span><span class="sxs-lookup"><span data-stu-id="3b100-190">Instead, prefer the pattern shown below wherever you can.</span></span> <span data-ttu-id="3b100-191">大幅に減少コードを生成し、実行時のパフォーマンスも大幅に向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-191">It generates a lot less code, and it can also dramatically improve your run time performance.</span></span>

```cppwinrt
auto a{ anobject.b().c() };
a.d();
a.e();
a.f();
```

<span data-ttu-id="3b100-192">上記の推奨パターンの対象だけでなく、C++/WinRT が、すべての Windows ランタイム言語プロジェクションにします。</span><span class="sxs-lookup"><span data-stu-id="3b100-192">The recommended pattern shown above applies not just to C++/WinRT but to all Windows Runtime language projections.</span></span>

> [!NOTE]
> <span data-ttu-id="3b100-193">このトピックで質問の回答が得られない場合は、[Stack Overflow で `c++-winrt` タグ](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt)を使用してヘルプ情報を見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="3b100-193">If this topic didn't answer your question, you might find help by using the [`c++-winrt` tag on Stack Overflow](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt).</span></span>
