---
author: stevewhims
description: このトピックでは、C++/WinRT API を実装する Windows、サード パーティ コンポーネント ベンダー、またはユーザー自身に応じた使用方法について説明します。
title: C++/WinRT での API の使用
ms.author: stwhi
ms.date: 04/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、投影、プロジェクション、実装、ランタイム クラス、ライセンス認証
ms.localizationpriority: medium
ms.openlocfilehash: e777aca8f1d9f3892f67b10c785c056b14c8070c
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832246"
---
# <a name="consume-apis-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="19bcd-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) での API の使用</span><span class="sxs-lookup"><span data-stu-id="19bcd-104">Consume APIs with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
> [!NOTE]
> **<span data-ttu-id="19bcd-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="19bcd-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="19bcd-106">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="19bcd-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="19bcd-107">このトピックでは、C++/WinRT API が Windows に含まれるかどうか、サード パーティ コンポーネント ベンダーで実装するかどうか、またはユーザー自身が実装するかどうかに応じて、その使用方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-107">This topic shows how to consume C++/WinRT APIs, whether they're part of Windows, implemented by a third-party component vendor, or implemented by yourself.</span></span>

## <a name="if-the-api-is-in-a-windows-namespace"></a><span data-ttu-id="19bcd-108">API が Windows 名前空間に含まれる場合</span><span class="sxs-lookup"><span data-stu-id="19bcd-108">If the API is in a Windows namespace</span></span>
<span data-ttu-id="19bcd-109">これは Windows ランタイム API を使用する際に最も一般的なケースです。</span><span class="sxs-lookup"><span data-stu-id="19bcd-109">This is the most common case in which you'll consume a Windows Runtime API.</span></span> <span data-ttu-id="19bcd-110">次に簡単なコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-110">Here's a simple code example.</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

int main()
{
    winrt::init_apartment();
    Uri contosoUri{ L"http://www.contoso.com" };
}
```

<span data-ttu-id="19bcd-111">インクルードするヘッダー `winrt/Windows.Foundation.h` は SDK に含まれるもので、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt\` フォルダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="19bcd-111">The included header `winrt/Windows.Foundation.h` is part of the SDK, found inside the folder `%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt\`.</span></span> <span data-ttu-id="19bcd-112">このフォルダー内のヘッダーには、C++/WinRT に投影された Windows API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="19bcd-112">The headers in that folder contain Windows APIs projected into C++/WinRT.</span></span> <span data-ttu-id="19bcd-113">Windows 名前空間から型を使用する場合は、この名前空間に対応する C++/WinRT プロジェクション ヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="19bcd-113">Whenever you want to use a type from a Windows namespace, include the C++/WinRT projection header corresponding to that namespace.</span></span> <span data-ttu-id="19bcd-114">`using namespace` ディレクティブはオプションですが、便利です。</span><span class="sxs-lookup"><span data-stu-id="19bcd-114">The `using namespace` directives are optional, but convenient.</span></span>

<span data-ttu-id="19bcd-115">この例では、`winrt/Windows.Foundation.h` にランタイム クラス [**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) に投影された型が含まれています。</span><span class="sxs-lookup"><span data-stu-id="19bcd-115">In this example, `winrt/Windows.Foundation.h` contains the projected type for the runtime class [**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri).</span></span>

> [!TIP]
> <span data-ttu-id="19bcd-116">*投影された型*は、自身の API を使用するためのランタイム クラスに対するラッパーです。</span><span class="sxs-lookup"><span data-stu-id="19bcd-116">A *projected type* is a wrapper over a runtime class for purposes of consuming its APIs.</span></span> <span data-ttu-id="19bcd-117">*投影されたインターフェイス*は Windows ランタイム インターフェイスに対するラッパーです。</span><span class="sxs-lookup"><span data-stu-id="19bcd-117">A *projected interface* is a wrapper over a Windows Runtime interface.</span></span>

<span data-ttu-id="19bcd-118">上記のコード例では、C++/WinRT の初期化後、公開されているいずれかのコンストラクターを介して投影される型 **Uri** を作成します (この場合は、[**Uri(String)**](/uwp/api/windows.foundation.uri#Windows_Foundation_Uri__ctor_System_String_))。</span><span class="sxs-lookup"><span data-stu-id="19bcd-118">In the code example above, after initializing C++/WinRT, we construct the **Uri** projected type via one of its publicly documented constructors ([**Uri(String)**](/uwp/api/windows.foundation.uri#Windows_Foundation_Uri__ctor_System_String_), in this example).</span></span> <span data-ttu-id="19bcd-119">このため、最も一般的な使用事例を使用します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-119">For this, the most common use case, that's all you have to do.</span></span>

## <a name="if-the-api-is-implemented-in-a-windows-runtime-component"></a><span data-ttu-id="19bcd-120">API が Windows ランタイム コンポーネントに実装されている場合</span><span class="sxs-lookup"><span data-stu-id="19bcd-120">If the API is implemented in a Windows Runtime component</span></span>
<span data-ttu-id="19bcd-121">このセクションは、コンポーネントを自分で作成した場合またはベンダーから提供された場合に適用されます。</span><span class="sxs-lookup"><span data-stu-id="19bcd-121">This section applies whether you authored the component yourself, or it came from a vendor.</span></span>

> [!NOTE]
> <span data-ttu-id="19bcd-122">現在利用可能な C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) の詳細については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="19bcd-122">For info about the current availability of the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

<span data-ttu-id="19bcd-123">アプリケーション プロジェクトで、Windows ランタイム コンポーネントの Windows ランタイム メタデータ (`.winmd`) ファイルを参照してビルドします。</span><span class="sxs-lookup"><span data-stu-id="19bcd-123">In your application project, reference the Windows Runtime component's Windows Runtime metadata (`.winmd`) file, and build.</span></span> <span data-ttu-id="19bcd-124">作成中、`cppwinrt.exe` ツールで、コンポーネントの API サーフェイスをすべて定義する (*投影する*) 標準的な C++ ライブラリを生成します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-124">During the build, the `cppwinrt.exe` tool generates a standard C++ library that fully describes&mdash;or *projects*&mdash;the API surface for the component.</span></span> <span data-ttu-id="19bcd-125">つまり、生成されたライブラリにはコンポーネントに投影された型が含まれます。</span><span class="sxs-lookup"><span data-stu-id="19bcd-125">In other words, the generated library contains the projected types for the component.</span></span>

<span data-ttu-id="19bcd-126">次に、Windows 名前空間の型と同じように、いずれかのコンストラクターを介してヘッダーを追加し、投影された型を作成します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-126">Then, just as for a Windows namespace type, you include a header and construct the projected type via one of its constructors.</span></span> <span data-ttu-id="19bcd-127">アプリケーション プロジェクトのスタートアップ コードにより、ランタイム クラスが登録され、投影された型のコンストラクターは [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) を呼び出し、参照するコンポーネントからランタイム クラスをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-127">Your application project's startup code registers the runtime class, and the projected type's constructor calls [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) to activate the runtime class from the referenced component.</span></span>

```cppwinrt
#include <winrt/BankAccountWRC.h>

struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    BankAccountWRC::BankAccount bankAccount;
    ...
};
```

<span data-ttu-id="19bcd-128">詳細、コード、および Windows ランタイム コンポーネントに実装する API の使用に関するチュートリアルについては、「[C++/WinRT でのイベントの作成](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="19bcd-128">For more details, code, and a walkthrough of consuming APIs implemented in a Windows Runtime component, see [Author events in C++/WinRT](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component).</span></span>

## <a name="if-the-api-is-implemented-in-the-consuming-project"></a><span data-ttu-id="19bcd-129">API が使用中のプロジェクトに実装される場合</span><span class="sxs-lookup"><span data-stu-id="19bcd-129">If the API is implemented in the consuming project</span></span>
<span data-ttu-id="19bcd-130">XAML UI で使用する型が XAML と同じプロジェクト内にある場合でも、ランタイム クラスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="19bcd-130">A type that's consumed from XAML UI must be a runtime class, even if it's in the same project as the XAML.</span></span>

<span data-ttu-id="19bcd-131">このシナリオでは、ランタイム クラスの Windows ランタイム メタデータ (`.winmd`) から投影される型を生成します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-131">For this scenario, you generate a projected type from the runtime class's Windows Runtime metadata (`.winmd`).</span></span> <span data-ttu-id="19bcd-132">この場合も、ヘッダーを含めますが、自身の `nullptr` コンストラクターを介して投影される型を作成します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-132">Again, you include a header, but this time you construct the projected type via its `nullptr` constructor.</span></span> <span data-ttu-id="19bcd-133">このコンストラクターは初期化されないため、[**winrt::make**](/uwp/cpp-ref-for-winrt/make) ヘルパー関数を介してインスタンスに値を割り当て、必要なコンストラクター引数を渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="19bcd-133">That constructor doesn't perform any initialization, so you must next assign a value to the instance via the [**winrt::make**](/uwp/cpp-ref-for-winrt/make) helper function, passing any necessary constructor arguments.</span></span> <span data-ttu-id="19bcd-134">使用中のコードと同じプロジェクトに実装されるランタイム クラスは、Windows ランタイム/COM のアクティブ化を介して登録またはインスタンス化する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="19bcd-134">A runtime class implemented in the same project as the consuming code doesn't need to be registered, nor instantiated via Windows Runtime/COM activation.</span></span>

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
    m_mainViewModel = make<Bookstore::implementation::BookstoreViewModel>();
    ...
}
```

<span data-ttu-id="19bcd-135">詳細、コード、および使用中のプロジェクトに実装するランタイム クラスの使用に関するチュートリアルについては、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="19bcd-135">For more details, code, and a walkthrough of consuming a runtime class implemented in the consuming project, see [XAML controls; bind to a C++/WinRT property](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage).</span></span>

## <a name="instantiating-and-returning-projected-types-and-interfaces"></a><span data-ttu-id="19bcd-136">投影された型とインターフェイスをインスタンス化して返す</span><span class="sxs-lookup"><span data-stu-id="19bcd-136">Instantiating and returning projected types and interfaces</span></span>
<span data-ttu-id="19bcd-137">次に、使用中のプロジェクトで投影された型とインターフェイスの例を示します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-137">Here's an example of what projected types and interfaces might look like in your consuming project.</span></span>

```cppwinrt
struct MyRuntimeClass : MyProject::IMyRuntimeClass, impl::require<MyRuntimeClass,
    Windows::Foundation::IStringable, Windows::Foundation::IClosable>
```

<span data-ttu-id="19bcd-138">**MyRuntimeClass** は投影された型で、投影されたインターフェイスには、**IMyRuntimeClass**、**IStringable**、および **IClosable** が含まれます。</span><span class="sxs-lookup"><span data-stu-id="19bcd-138">**MyRuntimeClass** is a projected type; projected interfaces include **IMyRuntimeClass**, **IStringable**, and **IClosable**.</span></span> <span data-ttu-id="19bcd-139">このトピックでは、投影された型をインスタンス化する際のさまざまな方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-139">This topic has shown the different ways in which you can instantiate a projected type.</span></span> <span data-ttu-id="19bcd-140">次の、**MyRuntimeClass** を使用する際のリマインダーと概要の例を示します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-140">Here's a reminder and summary, using **MyRuntimeClass** as an example.</span></span>

```cppwinrt
// The runtime class is implemented in another compilation unit (it's either a Windows API,
// or it's implemented in a second- or third-party component).
MyProject::MyRuntimeClass myrc1;

// The runtime class is implemented in the same compilation unit.
MyProject::MyRuntimeClass myrc2{ nullptr };
myrc2 = winrt::make<MyProject::implementation::MyRuntimeClass>();
```

- <span data-ttu-id="19bcd-141">投影された型のすべてのインターフェイスのメンバーにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="19bcd-141">You can access the members of all of the interfaces of a projected type.</span></span>
- <span data-ttu-id="19bcd-142">投影された型を呼び出し元に返すことができます。</span><span class="sxs-lookup"><span data-stu-id="19bcd-142">You can return a projected type to a caller.</span></span>
- <span data-ttu-id="19bcd-143">投影される型とインターフェイスは [**winrt::Windows::Foundation::IUnknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown) から取得します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-143">Projected types and interfaces derive from [**winrt::Windows::Foundation::IUnknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown).</span></span> <span data-ttu-id="19bcd-144">そのため、投影された型またはインターフェイスで [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) を呼び出すと、投影された他のインターフェイスもクエリされるため、使用するか、呼び出し元に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="19bcd-144">So, you can call [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) on a projected type or interface to query for other projected interfaces, which you can also either use or return to a caller.</span></span> <span data-ttu-id="19bcd-145">**as** メンバー関数は [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) と同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="19bcd-145">The **as** member function works like [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521).</span></span>

```cppwinrt
void f(MyProject::MyRuntimeClass const& myrc)
{
    myrc.ToString();
    myrc.Close();
    IClosable iclosable = myrc.as<IClosable>();
    iclosable.Close();
}
```

## <a name="important-apis"></a><span data-ttu-id="19bcd-146">重要な API</span><span class="sxs-lookup"><span data-stu-id="19bcd-146">Important APIs</span></span>
* [<span data-ttu-id="19bcd-147">winrt::make 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="19bcd-147">winrt::make function template</span></span>](/uwp/cpp-ref-for-winrt/make)
* [<span data-ttu-id="19bcd-148">winrt::Windows::Foundation::IUnknown::as</span><span class="sxs-lookup"><span data-stu-id="19bcd-148">winrt::Windows::Foundation::IUnknown::as</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)

## <a name="related-topics"></a><span data-ttu-id="19bcd-149">関連トピック</span><span class="sxs-lookup"><span data-stu-id="19bcd-149">Related topics</span></span>
* [<span data-ttu-id="19bcd-150">C++/WinRT でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="19bcd-150">Author events in C++/WinRT</span></span>](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)
* [<span data-ttu-id="19bcd-151">XAML コントロール、C++/WinRT プロパティへのバインド</span><span class="sxs-lookup"><span data-stu-id="19bcd-151">XAML controls; bind to a C++/WinRT property</span></span>](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)
