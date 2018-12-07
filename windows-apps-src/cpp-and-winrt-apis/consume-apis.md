---
description: このトピックでは、C++/WinRT API を実装する Windows、サード パーティ コンポーネント ベンダー、またはユーザー自身に応じた使用方法について説明します。
title: C++/WinRT での API の使用
ms.date: 05/08/2018
ms.topic: article
keywords: windows 10、uwp、標準、c++、cpp、winrt、投影、プロジェクション、実装、ランタイム クラス、ライセンス認証
ms.localizationpriority: medium
ms.openlocfilehash: 59b056e160a1d7782e054ad4dbf1b63e91be42e9
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8782035"
---
# <a name="consume-apis-with-cwinrt"></a><span data-ttu-id="4e0ce-104">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="4e0ce-104">Consume APIs with C++/WinRT</span></span>

<span data-ttu-id="4e0ce-105">このトピックでは、使用する方法を示しています。 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Api、Windows の一部になっているかどうか、サード パーティ コンポーネント ベンダーで実装された、またはユーザー自身が実装されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-105">This topic shows how to consume [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) APIs, whether they're part of Windows, implemented by a third-party component vendor, or implemented by yourself.</span></span>

## <a name="if-the-api-is-in-a-windows-namespace"></a><span data-ttu-id="4e0ce-106">API が Windows 名前空間に含まれる場合</span><span class="sxs-lookup"><span data-stu-id="4e0ce-106">If the API is in a Windows namespace</span></span>
<span data-ttu-id="4e0ce-107">これは Windows ランタイム API を使用する際に最も一般的なケースです。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-107">This is the most common case in which you'll consume a Windows Runtime API.</span></span> <span data-ttu-id="4e0ce-108">メタデータで定義される Windows 名前空間のすべての型について、C++/WinRT は C++ 対応の同等の型を定義します (*投影された型*と呼ばれます)。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-108">For every type in a Windows namespace defined in metadata, C++/WinRT defines a C++-friendly equivalent (called the *projected type*).</span></span> <span data-ttu-id="4e0ce-109">投影された型には Windows の型と同じ完全修飾名がありますが、C++ の構文を使用して **winrt** 名前空間に配置されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-109">A projected type has the same fully-qualified name as the Windows type, but it's placed in the C++ **winrt** namespace using C++ syntax.</span></span> <span data-ttu-id="4e0ce-110">たとえば、[**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) は **winrt::Windows::Foundation::Uri** として C++/WinRT に投影されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-110">For example, [**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) is projected into C++/WinRT as **winrt::Windows::Foundation::Uri**.</span></span>

<span data-ttu-id="4e0ce-111">次に簡単なコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-111">Here's a simple code example.</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

int main()
{
    winrt::init_apartment();
    Uri contosoUri{ L"http://www.contoso.com" };
    Uri combinedUri = contosoUri.CombineUri(L"products");
}
```

<span data-ttu-id="4e0ce-112">インクルードするヘッダー `winrt/Windows.Foundation.h` は SDK に含まれるもので、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt\` フォルダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-112">The included header `winrt/Windows.Foundation.h` is part of the SDK, found inside the folder `%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt\`.</span></span> <span data-ttu-id="4e0ce-113">このフォルダー内のヘッダーには、C++/WinRT に投影された Windows の名前空間の型が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-113">The headers in that folder contain Windows namespace types projected into C++/WinRT.</span></span> <span data-ttu-id="4e0ce-114">この例では、`winrt/Windows.Foundation.h` に、ランタイム クラス [**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) に投影された型である**winrt::Windows::Foundation::Uri** が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-114">In this example, `winrt/Windows.Foundation.h` contains **winrt::Windows::Foundation::Uri**, which is the projected type for the runtime class [**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri).</span></span>

> [!TIP]
> <span data-ttu-id="4e0ce-115">Windows 名前空間から型を使用する場合は、この名前空間に対応する C++/WinRT ヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-115">Whenever you want to use a type from a Windows namespace, include the C++/WinRT header corresponding to that namespace.</span></span> <span data-ttu-id="4e0ce-116">`using namespace` ディレクティブはオプションですが、便利です。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-116">The `using namespace` directives are optional, but convenient.</span></span>

<span data-ttu-id="4e0ce-117">上記のコード例では、C++/WinRT の初期化後、公開されているいずれかのコンストラクターを介して投影される型 **winrt::Windows::Foundation::Uri** の値をスタックに割り当てます (この場合は、[**Uri(String)**](/uwp/api/windows.foundation.uri#Windows_Foundation_Uri__ctor_System_String_))。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-117">In the code example above, after initializing C++/WinRT, we stack-allocate a value of the **winrt::Windows::Foundation::Uri** projected type via one of its publicly documented constructors ([**Uri(String)**](/uwp/api/windows.foundation.uri#Windows_Foundation_Uri__ctor_System_String_), in this example).</span></span> <span data-ttu-id="4e0ce-118">このため、最も一般的な使用事例を使用します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-118">For this, the most common use case, that's typically all you have to do.</span></span> <span data-ttu-id="4e0ce-119">C++/WinRT 投影型の値を取得したら、それにはすべての同じメンバーが含まれるため、実際の Windows ランタイム型のインスタンスのように扱うことができます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-119">Once you have a C++/WinRT projected type value, you can treat it as if it were an instance of the actual Windows Runtime type, since it has all the same members.</span></span>

<span data-ttu-id="4e0ce-120">実際に、投影される値はプロキシです。基本的には、バッキング オブジェクトへのスマート ポインターに過ぎません。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-120">In fact, that projected value is a proxy; it's essentially just a smart pointer to a backing object.</span></span> <span data-ttu-id="4e0ce-121">投影された値のコンストラクターは [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) を呼び出し、Windows ランタイムのバッキング クラスのインスタンス (この場合は **Windows.Foundation.Uri**) を作成し、投影された新しい値の内部にそのオブジェクトの既定のインターフェイスを保存します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-121">The projected value's constructor(s) call [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) to create an instance of the backing Windows Runtime class (**Windows.Foundation.Uri**, in this case), and store that object's default interface inside the new projected value.</span></span> <span data-ttu-id="4e0ce-122">次のように、投影された値のメンバーを呼び出す実際に委任するバッキング オブジェクトにはスマート ポインターを介して状態の変更が発生することができます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-122">As illustrated below, your calls to the projected value's members actually delegate, via the smart pointer, to the backing object; which is where state changes occur.</span></span>

![投影された Windows::Foundation::Uri 型](images/uri.png)

<span data-ttu-id="4e0ce-124">`contosoUri` の値が範囲外になると破壊し、その参照を既定のインターフェイスに解放します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-124">When the `contosoUri` value falls out of scope, it destructs, and releases its reference to the default interface.</span></span> <span data-ttu-id="4e0ce-125">その参照が、Windows ランタイムの **Windows.Foundation.Uri** バッキング オブジェクトへの最後の参照である場合、そのバッキング オブジェクトも破壊します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-125">If that reference is the last reference to the backing Windows Runtime **Windows.Foundation.Uri** object, the backing object destructs as well.</span></span>

> [!TIP]
> <span data-ttu-id="4e0ce-126">*投影された型*は、自身の API を使用するためのランタイム クラスに対するラッパーです。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-126">A *projected type* is a wrapper over a runtime class for purposes of consuming its APIs.</span></span> <span data-ttu-id="4e0ce-127">*投影されたインターフェイス*は Windows ランタイム インターフェイスに対するラッパーです。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-127">A *projected interface* is a wrapper over a Windows Runtime interface.</span></span>

## <a name="cwinrt-projection-headers"></a><span data-ttu-id="4e0ce-128">C++/WinRT プロジェクション ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4e0ce-128">C++/WinRT projection headers</span></span>
<span data-ttu-id="4e0ce-129">Windows 名前空間 API を C++/WinRT から使用するには、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt` フォルダーからのヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-129">To consume Windows namespace APIs from C++/WinRT, you include headers from the `%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt` folder.</span></span> <span data-ttu-id="4e0ce-130">下位の名前空間の型では、その直接の親の名前空間の型を参照するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-130">It's common for a type in a subordinate namespace to reference types in its immediate parent namespace.</span></span> <span data-ttu-id="4e0ce-131">したがって、各 C++/WinRT プロジェクションのヘッダーには、その親の名前空間のヘッダー ファイルが自動的に含まれるため、それを明示的に含める*必要*はありません。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-131">Consequently, each C++/WinRT projection header automatically includes its parent namespace header file; so you don't *need* to explicitly include it.</span></span> <span data-ttu-id="4e0ce-132">ただし、含めてもエラーは発生しません。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-132">Although, if you do, there will be no error.</span></span>

<span data-ttu-id="4e0ce-133">たとえば、[**Windows::Security::Cryptography::Certificates**](/uwp/api/windows.security.cryptography.certificates) 名前空間では、それと同等の C++/WinRT 型定義が `winrt/Windows.Security.Cryptography.Certificates.h` に存在します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-133">For example, for the [**Windows::Security::Cryptography::Certificates**](/uwp/api/windows.security.cryptography.certificates) namespace, the equivalent C++/WinRT type definitions reside in `winrt/Windows.Security.Cryptography.Certificates.h`.</span></span> <span data-ttu-id="4e0ce-134">**Windows::Security::Cryptography::Certificates** の型には、親である **Windows::Security::Cryptography** 名前空間の型が必要であり、その名前空間の型には、自信の親である **Windows::Security** の型が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-134">Types in **Windows::Security::Cryptography::Certificates** require types in the parent **Windows::Security::Cryptography** namespace; and types in that namespace could require types in its own parent, **Windows::Security**.</span></span>

<span data-ttu-id="4e0ce-135">そのため、`winrt/Windows.Security.Cryptography.Certificates.h` を含める場合、そのファイルには `winrt/Windows.Security.Cryptography.h` が含まれ、`winrt/Windows.Security.Cryptography.h` には `winrt/Windows.Security.h` が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-135">So, when you include `winrt/Windows.Security.Cryptography.Certificates.h`, that file in turn includes `winrt/Windows.Security.Cryptography.h`; and `winrt/Windows.Security.Cryptography.h` includes `winrt/Windows.Security.h`.</span></span> <span data-ttu-id="4e0ce-136">`winrt/Windows.h` は存在しないため、その証跡はそこで停止します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-136">That's where the trail stops, since there is no `winrt/Windows.h`.</span></span> <span data-ttu-id="4e0ce-137">この推移的な包含プロセスは、第 2 レベルの名前空間で停止します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-137">This transitive inclusion process stops at the second-level namespace.</span></span>

<span data-ttu-id="4e0ce-138">このプロセスには、必要な*宣言*を指定するヘッダー ファイルと、親の名前空間で定義されたクラスの*実装*が推移的に含まれます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-138">This process transitively includes the header files that provide the necessary *declarations* and *implementations* for the classes defined in parent namespaces.</span></span>

<span data-ttu-id="4e0ce-139">1 つの名前空間内の型のメンバーは、他の関連のない名前空間で 1 つまたは複数の型を参照できます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-139">A member of a type in one namespace can reference one or more types in other, unrelated, namespaces.</span></span> <span data-ttu-id="4e0ce-140">コンパイラがこれらのメンバーの定義を正常にコンパイルするためには、コンパイラーはこれらのすべての型の終了の型の宣言を参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-140">In order for the compiler to compile these member definitions successfully, the compiler needs to see the type declarations for the closure of all these types.</span></span> <span data-ttu-id="4e0ce-141">したがって、各 C++/WinRT プロジェクション ヘッダーには、任意の依存タイプを*宣言*する必要がある名前空間ヘッダーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-141">Consequently, each C++/WinRT projection header includes the namespace headers it needs to *declare* any dependent types.</span></span> <span data-ttu-id="4e0ce-142">親の名前空間とは異なり、このプロセスは参照された型の*実装*を追加*しません*。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-142">Unlike for parent namespaces, this process does *not* pull in the *implementations* for referenced types.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4e0ce-143">関連しない名前空間で宣言されている型 (インスタンス化、メソッドの呼び出しなど) を実際に*使用*する場合は、その型の適切な名前空間ヘッダー ファイルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-143">When you want to actually *use* a type (instantiate, call methods, etc.) declared in an unrelated namespace, you must include the appropriate namespace header file for that type.</span></span> <span data-ttu-id="4e0ce-144">*実装*ではなく*宣言*のみが自動的に含められます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-144">Only *declarations*, not *implementations*, are automatically included.</span></span>

<span data-ttu-id="4e0ce-145">たとえば、`winrt/Windows.Security.Cryptography.Certificates.h` のみを含める場合、これらの名前空間などから推移的に宣言が取得されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-145">For example, if you only include `winrt/Windows.Security.Cryptography.Certificates.h`, then that causes declarations to be pulled in from these namespaces (and so on, transitively).</span></span>

- <span data-ttu-id="4e0ce-146">Windows.Foundation</span><span class="sxs-lookup"><span data-stu-id="4e0ce-146">Windows.Foundation</span></span>
- <span data-ttu-id="4e0ce-147">Windows.Foundation.Collections</span><span class="sxs-lookup"><span data-stu-id="4e0ce-147">Windows.Foundation.Collections</span></span>
- <span data-ttu-id="4e0ce-148">Windows.Networking</span><span class="sxs-lookup"><span data-stu-id="4e0ce-148">Windows.Networking</span></span>
- <span data-ttu-id="4e0ce-149">Windows.Storage.Streams</span><span class="sxs-lookup"><span data-stu-id="4e0ce-149">Windows.Storage.Streams</span></span>
- <span data-ttu-id="4e0ce-150">Windows.Security.Cryptography</span><span class="sxs-lookup"><span data-stu-id="4e0ce-150">Windows.Security.Cryptography</span></span>

<span data-ttu-id="4e0ce-151">つまり、一部の API は含まれているヘッダー内で事前宣言されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-151">In other words, some APIs are forward-declared in a header that you've included.</span></span> <span data-ttu-id="4e0ce-152">ただし、その定義はまだ含まれていないヘッダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-152">But their definitions are in a header that you haven't yet included.</span></span> <span data-ttu-id="4e0ce-153">そのため、[**Windows::Foundation::Uri::RawUri**](/uwp/api/windows.foundation.uri.rawuri) を呼び出す場合は、メンバーが未定義であることを示すリンカ エラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-153">So, if you then call [**Windows::Foundation::Uri::RawUri**](/uwp/api/windows.foundation.uri.rawuri), then you'll receive a linker error indicating that the member is undefined.</span></span> <span data-ttu-id="4e0ce-154">解決策として、`#include <winrt/Windows.Foundation.h>` を明示的に指定します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-154">The solution is to explicitly `#include <winrt/Windows.Foundation.h>`.</span></span> <span data-ttu-id="4e0ce-155">一般に、このようなリンカ エラーが表示された場合は、API の名前空間で付けられた名前のヘッダーを含めてから、リビルドしてください。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-155">In general, when you see a linker error such as this, include the header named for the API's namespace, and rebuild.</span></span>

## <a name="accessing-members-via-the-object-via-an-interface-or-via-the-abi"></a><span data-ttu-id="4e0ce-156">オブジェクト、インターフェイス、ABI を介したメンバーへのアクセス</span><span class="sxs-lookup"><span data-stu-id="4e0ce-156">Accessing members via the object, via an interface, or via the ABI</span></span>
<span data-ttu-id="4e0ce-157">C++/WinRT プロジェクションでは、Windows ランタイム クラスのランタイム表現は、基になる ABI インターフェイスに過ぎません。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-157">With the C++/WinRT projection, the runtime representation of a Windows Runtime class is no more than the underlying ABI interfaces.</span></span> <span data-ttu-id="4e0ce-158">ただし、必要に応じて、その作成者が意図した方法でクラスに対してコードを記述することができます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-158">But, for your convenience, you can code against classes in the way that their author intended.</span></span> <span data-ttu-id="4e0ce-159">たとえば、[**Uri**](/uwp/api/windows.foundation.uri) の **ToString** メソッドをクラスのメソッドのように呼び出すことができます (実際、バックグラウンドでは、それは別の **IStringable** インターフェイスのメソッドです)。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-159">For example, you can call the **ToString** method of a [**Uri**](/uwp/api/windows.foundation.uri) as if that were a method of the class (in fact, under the covers, it's a method on the separate **IStringable** interface).</span></span>

```cppwinrt
Uri contosoUri{ L"http://www.contoso.com" };
WINRT_ASSERT(contosoUri.ToString() == L"http://www.contoso.com/"); // QueryInterface is called at this point.
```

<span data-ttu-id="4e0ce-160">この利便性は、適切なインターフェイスに対するクエリによって実現されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-160">This convenience is achieved via a query for the appropriate interface.</span></span> <span data-ttu-id="4e0ce-161">ただし、常に開発者が制御できます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-161">But you're always in control.</span></span> <span data-ttu-id="4e0ce-162">IStringable インターフェイスを自身で取得し、それを直接使用することで、多少のパフォーマンスのためにその利便性を若干手放すことを選択することもできます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-162">You can opt to give away a little of that convenience for a little performance by retrieving the IStringable interface yourself and using it directly.</span></span> <span data-ttu-id="4e0ce-163">次のコード例では、実行時に (1 回限りのクエリにより) 実際の IStringable インターフェイス ポインターを取得します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-163">In the code example below, you obtain an actual IStringable interface pointer at run time (via a one-time query).</span></span> <span data-ttu-id="4e0ce-164">その後、**ToString** への呼び出しは直接的であり、**QueryInterface** へのそれ以降の呼び出しを回避します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-164">After that, your call to **ToString** is direct, and avoids any further call to **QueryInterface**.</span></span>

```cppwinrt
IStringable stringable = contosoUri; // One-off QueryInterface.
WINRT_ASSERT(stringable.ToString() == L"http://www.contoso.com/");
```

<span data-ttu-id="4e0ce-165">同じインターフェイスでいくつかのメソッドを呼び出すことがわかっている場合は、この方法を選択できます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-165">You might choose this technique if you know you'll be calling several methods on the same interface.</span></span>

<span data-ttu-id="4e0ce-166">また、ABI レベルでメンバーにアクセスする場合にも選択することができます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-166">Incidentally, if you do want to access members at the ABI level then you can.</span></span> <span data-ttu-id="4e0ce-167">次のコード例で方法を示します。また、[C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md)に詳細とコード例が記載されています。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-167">The code example below shows how, and there are more details and code examples in [Interop between C++/WinRT and the ABI](interop-winrt-abi.md).</span></span>

```cppwinrt
int port = contosoUri.Port(); // Access the Port "property" accessor via C++/WinRT.

winrt::com_ptr<ABI::Windows::Foundation::IUriRuntimeClass> abiUri = contosoUri.as<ABI::Windows::Foundation::IUriRuntimeClass>();
HRESULT hr = abiUri->get_Port(&port); // Access the get_Port ABI function.
```

## <a name="delayed-initialization"></a><span data-ttu-id="4e0ce-168">初期化の遅延</span><span class="sxs-lookup"><span data-stu-id="4e0ce-168">Delayed initialization</span></span>
<span data-ttu-id="4e0ce-169">投影された型の既定のコンストラクターでも、Windows ランタイムのバッキング オブジェクトが作成されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-169">Even the default constructor of a projected type causes a backing Windows Runtime object to be created.</span></span> <span data-ttu-id="4e0ce-170">作業を後に遅らせることができるように、Windows ランタイム オブジェクトを作成しないで投影された型の変数を作成する場合は、これを実行できます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-170">If you want to construct a variable of a projected type without it in turn constructing a Windows Runtime object (so that you can delay that work until later), then you can.</span></span> <span data-ttu-id="4e0ce-171">投影された型の特別な C++/WinRT `nullptr_t` コンストラクターを使用して変数またはフィールドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-171">Declare your variable or field using the projected type's special C++/WinRT `nullptr_t` constructor.</span></span>

```cppwinrt
#include <winrt/Windows.Storage.Streams.h>
using namespace winrt::Windows::Storage::Streams;

struct Sample
{
    void DelayedInit()
    {
        // Allocate the actual buffer.
        m_gamerPicBuffer = Buffer(MAX_IMAGE_SIZE);
    }

private:
    Buffer m_gamerPicBuffer{ nullptr };
};
```

<span data-ttu-id="4e0ce-172">`nullptr_t` コンストラクターを*除く*投影された型のすべてのコンストラクターにより、Windows ランタイムのバッキング オブジェクトが作成されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-172">All constructors on the projected type *except* the `nullptr_t` constructor cause a backing Windows Runtime object to be created.</span></span> <span data-ttu-id="4e0ce-173">`nullptr_t` コンストラクターは、基本的には何もしません。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-173">The `nullptr_t` constructor is essentially a no-op.</span></span> <span data-ttu-id="4e0ce-174">投影されたオブジェクトがそれ以降に初期化されることが想定されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-174">It expects the projected object to be initialized at a subsequent time.</span></span> <span data-ttu-id="4e0ce-175">そのため、ランタイム クラスに既定のコンストラクターがあるかどうかに関係なく、効率的な初期化の遅延にこの方法を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-175">So, whether a runtime class has a default constructor or not, you can use this technique for efficient delayed initialization.</span></span>

## <a name="if-the-api-is-implemented-in-a-windows-runtime-component"></a><span data-ttu-id="4e0ce-176">API が Windows ランタイム コンポーネントに実装されている場合</span><span class="sxs-lookup"><span data-stu-id="4e0ce-176">If the API is implemented in a Windows Runtime component</span></span>
<span data-ttu-id="4e0ce-177">このセクションは、コンポーネントを自分で作成した場合またはベンダーから提供された場合に適用されます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-177">This section applies whether you authored the component yourself, or it came from a vendor.</span></span>

> [!NOTE]
> <span data-ttu-id="4e0ce-178">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-178">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

<span data-ttu-id="4e0ce-179">アプリケーション プロジェクトで、Windows ランタイム コンポーネントの Windows ランタイム メタデータ (`.winmd`) ファイルを参照してビルドします。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-179">In your application project, reference the Windows Runtime component's Windows Runtime metadata (`.winmd`) file, and build.</span></span> <span data-ttu-id="4e0ce-180">作成中、`cppwinrt.exe` ツールで、コンポーネントの API サーフェイスをすべて定義する (*投影する*) 標準的な C++ ライブラリを生成します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-180">During the build, the `cppwinrt.exe` tool generates a standard C++ library that fully describes&mdash;or *projects*&mdash;the API surface for the component.</span></span> <span data-ttu-id="4e0ce-181">つまり、生成されたライブラリにはコンポーネントに投影された型が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-181">In other words, the generated library contains the projected types for the component.</span></span>

<span data-ttu-id="4e0ce-182">次に、Windows 名前空間の型と同じように、いずれかのコンストラクターを介してヘッダーを追加し、投影された型を作成します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-182">Then, just as for a Windows namespace type, you include a header and construct the projected type via one of its constructors.</span></span> <span data-ttu-id="4e0ce-183">アプリケーション プロジェクトのスタートアップ コードにより、ランタイム クラスが登録され、投影された型のコンストラクターは [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) を呼び出し、参照するコンポーネントからランタイム クラスをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-183">Your application project's startup code registers the runtime class, and the projected type's constructor calls [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) to activate the runtime class from the referenced component.</span></span>

```cppwinrt
#include <winrt/BankAccountWRC.h>

struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    BankAccountWRC::BankAccount bankAccount;
    ...
};
```

<span data-ttu-id="4e0ce-184">詳細、コード、および Windows ランタイム コンポーネントに実装する API の使用に関するチュートリアルについては、「[C++/WinRT でのイベントの作成](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-184">For more details, code, and a walkthrough of consuming APIs implemented in a Windows Runtime component, see [Author events in C++/WinRT](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component).</span></span>

## <a name="if-the-api-is-implemented-in-the-consuming-project"></a><span data-ttu-id="4e0ce-185">API が使用中のプロジェクトに実装される場合</span><span class="sxs-lookup"><span data-stu-id="4e0ce-185">If the API is implemented in the consuming project</span></span>
<span data-ttu-id="4e0ce-186">XAML UI で使用する型が XAML と同じプロジェクト内にある場合でも、ランタイム クラスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-186">A type that's consumed from XAML UI must be a runtime class, even if it's in the same project as the XAML.</span></span>

<span data-ttu-id="4e0ce-187">このシナリオでは、ランタイム クラスの Windows ランタイム メタデータ (`.winmd`) から投影される型を生成します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-187">For this scenario, you generate a projected type from the runtime class's Windows Runtime metadata (`.winmd`).</span></span> <span data-ttu-id="4e0ce-188">この場合も、ヘッダーを含めますが、自身の `nullptr` コンストラクターを介して投影される型を作成します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-188">Again, you include a header, but this time you construct the projected type via its `nullptr` constructor.</span></span> <span data-ttu-id="4e0ce-189">このコンストラクターは初期化されないため、[**winrt::make**](/uwp/cpp-ref-for-winrt/make) ヘルパー関数を介してインスタンスに値を割り当て、必要なコンストラクター引数を渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-189">That constructor doesn't perform any initialization, so you must next assign a value to the instance via the [**winrt::make**](/uwp/cpp-ref-for-winrt/make) helper function, passing any necessary constructor arguments.</span></span> <span data-ttu-id="4e0ce-190">使用中のコードと同じプロジェクトに実装されるランタイム クラスは、Windows ランタイム/COM のアクティブ化を介して登録またはインスタンス化する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-190">A runtime class implemented in the same project as the consuming code doesn't need to be registered, nor instantiated via Windows Runtime/COM activation.</span></span>

```cppwinrt
// MainPage.h
...
struct MainPage : MainPageT<MainPage>
{
    ...
    private:
        Bookstore::BookstoreViewModel m_mainViewModel{ nullptr };
        ...
    };
}
...
// MainPage.cpp
...
#include "BookstoreViewModel.h"

MainPage::MainPage()
{
    m_mainViewModel = winrt::make<Bookstore::implementation::BookstoreViewModel>();
    ...
}
```

<span data-ttu-id="4e0ce-191">詳細、コード、および使用中のプロジェクトに実装するランタイム クラスの使用に関するチュートリアルについては、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-191">For more details, code, and a walkthrough of consuming a runtime class implemented in the consuming project, see [XAML controls; bind to a C++/WinRT property](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage).</span></span>

## <a name="instantiating-and-returning-projected-types-and-interfaces"></a><span data-ttu-id="4e0ce-192">投影された型とインターフェイスをインスタンス化して返す</span><span class="sxs-lookup"><span data-stu-id="4e0ce-192">Instantiating and returning projected types and interfaces</span></span>
<span data-ttu-id="4e0ce-193">次に、使用中のプロジェクトで投影された型とインターフェイスの例を示します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-193">Here's an example of what projected types and interfaces might look like in your consuming project.</span></span> <span data-ttu-id="4e0ce-194">(など、いずれかの例ではこの)、投影された型ツールで生成されたは、作成することは自分で何かに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-194">Remember that a projected type (such as the one in this example), is tool-generated, and is not something that you'd author yourself.</span></span>

```cppwinrt
struct MyRuntimeClass : MyProject::IMyRuntimeClass, impl::require<MyRuntimeClass,
    Windows::Foundation::IStringable, Windows::Foundation::IClosable>
```

<span data-ttu-id="4e0ce-195">**MyRuntimeClass** は投影された型で、投影されたインターフェイスには、**IMyRuntimeClass**、**IStringable**、および **IClosable** が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-195">**MyRuntimeClass** is a projected type; projected interfaces include **IMyRuntimeClass**, **IStringable**, and **IClosable**.</span></span> <span data-ttu-id="4e0ce-196">このトピックでは、投影された型をインスタンス化する際のさまざまな方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-196">This topic has shown the different ways in which you can instantiate a projected type.</span></span> <span data-ttu-id="4e0ce-197">次の、**MyRuntimeClass** を使用する際のリマインダーと概要の例を示します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-197">Here's a reminder and summary, using **MyRuntimeClass** as an example.</span></span>

```cppwinrt
// The runtime class is implemented in another compilation unit (it's either a Windows API,
// or it's implemented in a second- or third-party component).
MyProject::MyRuntimeClass myrc1;

// The runtime class is implemented in the same compilation unit.
MyProject::MyRuntimeClass myrc2{ nullptr };
myrc2 = winrt::make<MyProject::implementation::MyRuntimeClass>();
```

- <span data-ttu-id="4e0ce-198">投影された型のすべてのインターフェイスのメンバーにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-198">You can access the members of all of the interfaces of a projected type.</span></span>
- <span data-ttu-id="4e0ce-199">投影された型を呼び出し元に返すことができます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-199">You can return a projected type to a caller.</span></span>
- <span data-ttu-id="4e0ce-200">投影される型とインターフェイスは [**winrt::Windows::Foundation::IUnknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown) から取得します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-200">Projected types and interfaces derive from [**winrt::Windows::Foundation::IUnknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown).</span></span> <span data-ttu-id="4e0ce-201">そのため、投影された型またはインターフェイスで [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) を呼び出すと、投影された他のインターフェイスもクエリされるため、使用するか、呼び出し元に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-201">So, you can call [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) on a projected type or interface to query for other projected interfaces, which you can also either use or return to a caller.</span></span> <span data-ttu-id="4e0ce-202">**as** メンバー関数は [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) と同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-202">The **as** member function works like [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521).</span></span>

```cppwinrt
void f(MyProject::MyRuntimeClass const& myrc)
{
    myrc.ToString();
    myrc.Close();
    IClosable iclosable = myrc.as<IClosable>();
    iclosable.Close();
}
```

## <a name="activation-factories"></a><span data-ttu-id="4e0ce-203">アクティベーション ファクトリ</span><span class="sxs-lookup"><span data-stu-id="4e0ce-203">Activation factories</span></span>
<span data-ttu-id="4e0ce-204">C++/WinRT オブジェクトを作成する便利で直接的な方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-204">The convenient, direct way to create a C++/WinRT object is as follows.</span></span>

```cppwinrt
using namespace winrt::Windows::Globalization::NumberFormatting;
...
CurrencyFormatter currency{ L"USD" };
```

<span data-ttu-id="4e0ce-205">ただし、場合によっては、自分でアクティベーション ファクトリを作成し、都合のよいときにそこからオブジェクトを作成することが必要になります。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-205">But there may be times that you'll want to create the activation factory yourself, and then create objects from it at your convenience.</span></span> <span data-ttu-id="4e0ce-206">[**winrt::get_activation_factory**](/uwp/cpp-ref-for-winrt/get-activation-factory) 関数テンプレートを使用して行う方法を示す例をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-206">Here are some examples showing you how, using the [**winrt::get_activation_factory**](/uwp/cpp-ref-for-winrt/get-activation-factory) function template.</span></span>

```cppwinrt
using namespace winrt::Windows::Globalization::NumberFormatting;
...
auto factory = winrt::get_activation_factory<CurrencyFormatter, ICurrencyFormatterFactory>();
CurrencyFormatter currency = factory.CreateCurrencyFormatterCode(L"USD");
```

```cppwinrt
using namespace winrt::Windows::Foundation;
...
auto factory = winrt::get_activation_factory<Uri, IUriRuntimeClassFactory>();
Uri account = factory.CreateUri(L"http://www.contoso.com");
```

<span data-ttu-id="4e0ce-207">上の 2 つの例のクラスとは、Windows の名前空間の型です。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-207">The classes in the two examples above are types from a Windows namespace.</span></span> <span data-ttu-id="4e0ce-208">次の例では、**BankAccountWRC::BankAccount** は Windows ランタイム コンポーネントに実装されたカスタム型です。</span><span class="sxs-lookup"><span data-stu-id="4e0ce-208">In this next example, **BankAccountWRC::BankAccount** is a custom type implemented in a Windows Runtime Component.</span></span>

```cppwinrt
auto factory = winrt::get_activation_factory<BankAccountWRC::BankAccount>();
BankAccountWRC::BankAccount account = factory.ActivateInstance<BankAccountWRC::BankAccount>();
```

## <a name="important-apis"></a><span data-ttu-id="4e0ce-209">重要な API</span><span class="sxs-lookup"><span data-stu-id="4e0ce-209">Important APIs</span></span>
* [<span data-ttu-id="4e0ce-210">QueryInterface インターフェイス</span><span class="sxs-lookup"><span data-stu-id="4e0ce-210">QueryInterface interface</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms682521)
* [<span data-ttu-id="4e0ce-211">RoActivateInstance 関数</span><span class="sxs-lookup"><span data-stu-id="4e0ce-211">RoActivateInstance function</span></span>](https://msdn.microsoft.com/library/br224646)
* [<span data-ttu-id="4e0ce-212">Windows::Foundation::Uri クラス</span><span class="sxs-lookup"><span data-stu-id="4e0ce-212">Windows::Foundation::Uri class</span></span>](/uwp/api/windows.foundation.uri)
* [<span data-ttu-id="4e0ce-213">winrt::get_activation_factory 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="4e0ce-213">winrt::get_activation_factory function template</span></span>](/uwp/cpp-ref-for-winrt/get-activation-factory)
* [<span data-ttu-id="4e0ce-214">winrt::make 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="4e0ce-214">winrt::make function template</span></span>](/uwp/cpp-ref-for-winrt/make)
* [<span data-ttu-id="4e0ce-215">winrt::Windows::Foundation::IUnknown 構造体</span><span class="sxs-lookup"><span data-stu-id="4e0ce-215">winrt::Windows::Foundation::IUnknown struct</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)

## <a name="related-topics"></a><span data-ttu-id="4e0ce-216">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4e0ce-216">Related topics</span></span>
* [<span data-ttu-id="4e0ce-217">C++/WinRT でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="4e0ce-217">Author events in C++/WinRT</span></span>](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)
* [<span data-ttu-id="4e0ce-218">C++/WinRT と ABI 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="4e0ce-218">Interop between C++/WinRT and the ABI</span></span>](interop-winrt-abi.md)
* [<span data-ttu-id="4e0ce-219">C++/WinRT の概要</span><span class="sxs-lookup"><span data-stu-id="4e0ce-219">Introduction to C++/WinRT</span></span>](intro-to-using-cpp-with-winrt.md)
* [<span data-ttu-id="4e0ce-220">XAML コントロール、C++/WinRT プロパティへのバインド</span><span class="sxs-lookup"><span data-stu-id="4e0ce-220">XAML controls; bind to a C++/WinRT property</span></span>](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)
