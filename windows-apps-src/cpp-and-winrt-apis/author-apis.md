---
author: stevewhims
description: このトピックでは、直接的または間接的に **winrt::implements** 基本構造体を使用して、C++/WinRT API を作成する方法を示します。
title: C++/WinRT での API の作成
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, 投影された, プロジェクション, 実装, インプリメント, ランタイム クラス, ライセンス認証
ms.localizationpriority: medium
ms.openlocfilehash: d613cb87297cdc810e4d8e16dfeb36d4804678d1
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4125507"
---
# <a name="author-apis-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="248bc-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) での API の作成</span><span class="sxs-lookup"><span data-stu-id="248bc-104">Author APIs with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>

> [!NOTE]
> **<span data-ttu-id="248bc-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="248bc-106">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="248bc-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="248bc-107">このトピックでは、直接的または間接的に [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) 基本構造体を使用して、C++/WinRT API を作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="248bc-107">This topic shows how to author C++/WinRT APIs by using the [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) base struct, either directly or indirectly.</span></span> <span data-ttu-id="248bc-108">このコンテキストで*作成者*の同義語は、*生成*、または*実装*です。</span><span class="sxs-lookup"><span data-stu-id="248bc-108">Synonyms for *author* in this context are *produce*, or *implement*.</span></span> <span data-ttu-id="248bc-109">このトピックでは、C++/WinRT で API を実装するために、次のシナリオをこの順序で説明します。</span><span class="sxs-lookup"><span data-stu-id="248bc-109">This topic covers the following scenarios for implementing APIs on a C++/WinRT type, in this order.</span></span>

- <span data-ttu-id="248bc-110">Windows ランタイム クラス (ランタイム クラス) は作成*しません*。アプリ内でのローカルの使用のために 1 つまたは複数の Windows ランタイム インターフェイスを実装するだけです。</span><span class="sxs-lookup"><span data-stu-id="248bc-110">You're *not* authoring a Windows Runtime class (runtime class); you just want to implement one or more Windows Runtime interfaces for local consumption within your app.</span></span> <span data-ttu-id="248bc-111">この場合、**winrt::implements** から直接派生し、機能を実装します。</span><span class="sxs-lookup"><span data-stu-id="248bc-111">You derive directly from **winrt::implements** in this case, and implement functions.</span></span>
- <span data-ttu-id="248bc-112">ランタイム クラスを作成*します*。</span><span class="sxs-lookup"><span data-stu-id="248bc-112">You *are* authoring a runtime class.</span></span> <span data-ttu-id="248bc-113">アプリで使用するコンポーネントを作成している場合があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-113">You might be authoring a component to be consumed from an app.</span></span> <span data-ttu-id="248bc-114">または、XAML ユーザー インターフェイス (UI) で使用する型を作成していることがあり、その場合は両方を実装して、同じのコンパイル ユニット内のランタイム クラスを使用しています。</span><span class="sxs-lookup"><span data-stu-id="248bc-114">Or you might be authoring a type to be consumed from XAML user interface (UI), and in that case you're both implementing and consuming a runtime class within the same compilation unit.</span></span> <span data-ttu-id="248bc-115">このような場合、ツールで **winrt::implements** から派生するクラスを生成することができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-115">In these cases, you let the tools generate classes for you that derive from **winrt::implements**.</span></span>

<span data-ttu-id="248bc-116">どちらの場合も、C++/WinRT API を実装する型は、*実装型*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="248bc-116">In both cases, the type that implements your C++/WinRT APIs is called the *implementation type*.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="248bc-117">実装型の概念を投影型と区別することは重要です。</span><span class="sxs-lookup"><span data-stu-id="248bc-117">It's important to distinguish the concept of an implementation type from that of a projected type.</span></span> <span data-ttu-id="248bc-118">投影型については、「[C++/WinRT での API の使用](consume-apis.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="248bc-118">The projected type is described in [Consume APIs with C++/WinRT](consume-apis.md).</span></span>

## <a name="if-youre-not-authoring-a-runtime-class"></a><span data-ttu-id="248bc-119">ランタイム クラスを作成*していない*場合</span><span class="sxs-lookup"><span data-stu-id="248bc-119">If you're *not* authoring a runtime class</span></span>
<span data-ttu-id="248bc-120">最も単純なシナリオは、ローカル使用のための Windows ランタイム インターフェイスを実装しているケースです。</span><span class="sxs-lookup"><span data-stu-id="248bc-120">The simplest scenario is where you're implementing a Windows Runtime interface for local consumption.</span></span> <span data-ttu-id="248bc-121">ランタイム クラスは必要ありません。通常の C++ のクラスだけです。</span><span class="sxs-lookup"><span data-stu-id="248bc-121">You don't need a runtime class; just an ordinary C++ class.</span></span> <span data-ttu-id="248bc-122">たとえば、[**CoreApplication**](/uwp/api/windows.applicationmodel.core.coreapplication) に基づいてアプリを記述している場合があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-122">For example, you might be writing an app based around [**CoreApplication**](/uwp/api/windows.applicationmodel.core.coreapplication).</span></span>

> [!NOTE]
> <span data-ttu-id="248bc-123">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="248bc-123">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

<span data-ttu-id="248bc-124">Visual Studio で、 **Visual C** > **Windows ユニバーサル** > **コア アプリ (、C++/WinRT)** プロジェクト テンプレートは**CoreApplication**パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="248bc-124">In Visual Studio, the **Visual C++** > **Windows Universal** > **Core App (C++/WinRT)** project template illustrates the **CoreApplication** pattern.</span></span> <span data-ttu-id="248bc-125">パターンは、[**Windows::ApplicationModel::Core::IFrameworkViewSource**](/uwp/api/windows.applicationmodel.core.iframeworkviewsource) の実装を [**coreapplication::run**](/uwp/api/windows.applicationmodel.core.coreapplication.run) に渡して開始します。</span><span class="sxs-lookup"><span data-stu-id="248bc-125">The pattern begins with passing an implementation of [**Windows::ApplicationModel::Core::IFrameworkViewSource**](/uwp/api/windows.applicationmodel.core.iframeworkviewsource) to [**CoreApplication::Run**](/uwp/api/windows.applicationmodel.core.coreapplication.run).</span></span>

```cppwinrt
using namespace Windows::ApplicationModel::Core;
int __stdcall wWinMain(HINSTANCE, HINSTANCE, PWSTR, int)
{
    IFrameworkViewSource source = ...
    CoreApplication::Run(source);
}
```

<span data-ttu-id="248bc-126">**CoreApplication** はインターフェイスを使用してアプリの最初のビューを作成します。</span><span class="sxs-lookup"><span data-stu-id="248bc-126">**CoreApplication** uses the interface to create the app's first view.</span></span> <span data-ttu-id="248bc-127">概念的には、**IFrameworkViewSource** は次のように見えます。</span><span class="sxs-lookup"><span data-stu-id="248bc-127">Conceptually, **IFrameworkViewSource** looks like this.</span></span>

```cppwinrt
struct IFrameworkViewSource : IInspectable
{
    IFrameworkView CreateView();
};
```

<span data-ttu-id="248bc-128">さらに、概念的には、**CoreApplication::run** の実装は次のように見えます。</span><span class="sxs-lookup"><span data-stu-id="248bc-128">Again conceptually, the implementation of **CoreApplication::Run** does this.</span></span>

```cppwinrt
void Run(IFrameworkViewSource viewSource) const
{
    IFrameworkView view = viewSource.CreateView();
    ...
}
```

<span data-ttu-id="248bc-129">したがって、開発者は、**IFrameworkViewSource** インターフェイスを実装します。</span><span class="sxs-lookup"><span data-stu-id="248bc-129">So you, as the developer, implement the **IFrameworkViewSource** interface.</span></span> <span data-ttu-id="248bc-130">C++/WinRT には、基本構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) があり、COM スタイルのプログラミングを使用せずにインターフェイス (1 つまたは複数) を簡単に実装することができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-130">C++/WinRT has the base struct template [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) to make it easy to implement an interface (or several) without resorting to COM-style programming.</span></span> <span data-ttu-id="248bc-131">**実装**から型を派生して、インターフェイスの機能を実装するだけです。</span><span class="sxs-lookup"><span data-stu-id="248bc-131">You just derive your type from **implements**, and then implement the interface's functions.</span></span> <span data-ttu-id="248bc-132">以下にその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="248bc-132">Here's how.</span></span>

```cppwinrt
// App.cpp
...
struct App : implements<App, IFrameworkViewSource>
{
    IFrameworkView CreateView()
    {
        return ...
    }
}
...
```

<span data-ttu-id="248bc-133">**IFrameworkViewSource** に対応済みです。</span><span class="sxs-lookup"><span data-stu-id="248bc-133">That's taken care of **IFrameworkViewSource**.</span></span> <span data-ttu-id="248bc-134">次に、**IFrameworkView** インターフェイスを実装するオブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="248bc-134">The next step is to return an object that implements the **IFrameworkView** interface.</span></span> <span data-ttu-id="248bc-135">**アプリ**上にそのインターフェイスを実装することも選択できます。</span><span class="sxs-lookup"><span data-stu-id="248bc-135">You can choose to implement that interface on **App**, too.</span></span> <span data-ttu-id="248bc-136">次のコード例は、少なくともウィンドウを起動してデスクトップ上で実行する最小限のアプリを表します。</span><span class="sxs-lookup"><span data-stu-id="248bc-136">This next code example represents a minimal app that will at least get a window up and running on the desktop.</span></span>

```cppwinrt
// App.cpp
...
struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    IFrameworkView CreateView()
    {
        return *this;
    }

    void Initialize(CoreApplicationView const &) {}

    void Load(hstring const&) {}

    void Run()
    {
        CoreWindow window = CoreWindow::GetForCurrentThread();
        window.Activate();

        CoreDispatcher dispatcher = window.Dispatcher();
        dispatcher.ProcessEvents(CoreProcessEventsOption::ProcessUntilQuit);
    }

    void SetWindow(CoreWindow const & window)
    {
        // Prepare app visuals here
    }

    void Uninitialize() {}
};
...
```

<span data-ttu-id="248bc-137">**アプリ**型*が ***IFrameworkViewSource** であるため、\*\*Run** に渡すことだけができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-137">Since your **App** type *is an* **IFrameworkViewSource**, you can just pass one to **Run**.</span></span>

```cppwinrt
using namespace Windows::ApplicationModel::Core;
int __stdcall wWinMain(HINSTANCE, HINSTANCE, PWSTR, int)
{
    CoreApplication::Run(App{});
}
```

## <a name="if-youre-authoring-a-runtime-class-in-a-windows-runtime-component"></a><span data-ttu-id="248bc-138">Windows ランタイム コンポーネントでランタイム クラスを作成する場合</span><span class="sxs-lookup"><span data-stu-id="248bc-138">If you're authoring a runtime class in a Windows Runtime Component</span></span>
<span data-ttu-id="248bc-139">型が、アプリケーションから使用する Windows ランタイム コンポーネントにパッケージ化されている場合は、ランタイム クラスである必要があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-139">If your type is packaged in a Windows Runtime Component for consumption from an application, then it needs to be a runtime class.</span></span>

> [!TIP]
> <span data-ttu-id="248bc-140">インターフェイス定義言語 (IDL) ファイルを編集するときに、ビルドのパフォーマンスを最適化するために、また IDL からその生成されたソース コード ファイルへの論理的な通信手段のために、各ランタイム クラスを独自の IDL (.idl) ファイル内で宣言することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="248bc-140">We recommend that you declare each runtime class in its own Interface Definition Language (IDL) (.idl) file, in order to optimize build performance when you edit an IDL file, and for logical correspondence of an IDL file to its generated source code files.</span></span> <span data-ttu-id="248bc-141">Visual Studio では、生成されるすべての `.winmd` ファイルをルート名前空間と同じ名前の単一のファイルにマージします。</span><span class="sxs-lookup"><span data-stu-id="248bc-141">Visual Studio merges all of the resulting `.winmd` files into a single file with the same name as the root namespace.</span></span> <span data-ttu-id="248bc-142">その最終的な `.winmd` ファイルが、コンポーネントのユーザーが参照するファイルになります。</span><span class="sxs-lookup"><span data-stu-id="248bc-142">That final `.winmd` file will be the one that the consumers of your component will reference.</span></span>

<span data-ttu-id="248bc-143">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="248bc-143">Here's an example.</span></span>

```idl
// MyRuntimeClass.idl
namespace MyProject
{
    runtimeclass MyRuntimeClass
    {
        // Declaring a constructor (or constructors) in the IDL causes the runtime class to be
        // activatable from outside the compilation unit.
        MyRuntimeClass();
        String Name;
    }
}
```

<span data-ttu-id="248bc-144">この IDL では、Windows ランタイム (ランタイム) クラスを宣言します。</span><span class="sxs-lookup"><span data-stu-id="248bc-144">This IDL declares a Windows Runtime (runtime) class.</span></span> <span data-ttu-id="248bc-145">ランタイム クラスは、通常実行可能な境界を越えて、モダン COM インターフェイス経由でアクティブ化および使用可能な型です。</span><span class="sxs-lookup"><span data-stu-id="248bc-145">A runtime class is a type that can be activated and consumed via modern COM interfaces, typically across executable boundaries.</span></span> <span data-ttu-id="248bc-146">プロジェクトに IDL ファイルを追加し、ビルドすると、C++/WinRT ツールチェーン (`midl.exe` および `cppwinrt.exe`) が実装型を生成します。</span><span class="sxs-lookup"><span data-stu-id="248bc-146">When you add an IDL file to your project, and build, the C++/WinRT toolchain (`midl.exe` and `cppwinrt.exe`) generate an implementation type for you.</span></span> <span data-ttu-id="248bc-147">上記の IDL の例を使用すると、実装型は、`\MyProject\MyProject\Generated Files\sources\MyRuntimeClass.h` と `MyRuntimeClass.cpp` という名前のソース コード ファイルの **winrt::MyProject::implementation::MyRuntimeClass** という名前の C++ 構造体スタブです。</span><span class="sxs-lookup"><span data-stu-id="248bc-147">Using the example IDL above, the implementation type is a C++ struct stub named **winrt::MyProject::implementation::MyRuntimeClass** in source code files named `\MyProject\MyProject\Generated Files\sources\MyRuntimeClass.h` and `MyRuntimeClass.cpp`.</span></span>

<span data-ttu-id="248bc-148">実装型は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="248bc-148">The implementation type looks like this.</span></span>

```cppwinrt
// MyRuntimeClass.h
...
namespace winrt::MyProject::implementation
{
    struct MyRuntimeClass : MyRuntimeClassT<MyRuntimeClass>
    {
        MyRuntimeClass() = default;

        hstring Name();
        void Name(hstring const& value);
    };
}

// winrt::MyProject::factory_implementation::MyRuntimeClass is here, too.
```

<span data-ttu-id="248bc-149">使用されている F バインド ポリモーフィズム パターンに注意してください (**MyRuntimeClass** は、その基本である **MyRuntimeClassT** へのテンプレート引数としてそれ自体を使用します)。</span><span class="sxs-lookup"><span data-stu-id="248bc-149">Note the F-bound polymorphism pattern being used (**MyRuntimeClass** uses itself as a template argument to its base, **MyRuntimeClassT**).</span></span> <span data-ttu-id="248bc-150">これは、CRTP (curiously recurring template pattern (奇妙に再帰したテンプレート パターン)) とも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="248bc-150">This is also called the curiously recurring template pattern (CRTP).</span></span> <span data-ttu-id="248bc-151">上方向に継承チェーンをたどると、**MyRuntimeClass_base** が見つかります。</span><span class="sxs-lookup"><span data-stu-id="248bc-151">If you follow the inheritance chain upwards, you'll come across **MyRuntimeClass_base**.</span></span>

```cppwinrt
template <typename D, typename... I>
struct MyRuntimeClass_base : implements<D, MyProject::IMyRuntimeClass, I...>
```

<span data-ttu-id="248bc-152">そのため、このシナリオでは、継承のルートの階層はもう一度 [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) 基本構造体のテンプレートです。</span><span class="sxs-lookup"><span data-stu-id="248bc-152">So, in this scenario, at the root of the inheritance hierarchy is the [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) base struct template once again.</span></span>

<span data-ttu-id="248bc-153">詳細、コード、および Windows ランタイム コンポーネントの API の作成に関するチュートリアルについては、「[C++/WinRT でのイベントの作成](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="248bc-153">For more details, code, and a walkthrough of authoring APIs in a Windows Runtime component, see [Author events in C++/WinRT](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component).</span></span>

## <a name="if-youre-authoring-a-runtime-class-to-be-referenced-in-your-xaml-ui"></a><span data-ttu-id="248bc-154">XAML UI で参照されるランタイム クラスを作成する場合</span><span class="sxs-lookup"><span data-stu-id="248bc-154">If you're authoring a runtime class to be referenced in your XAML UI</span></span>
<span data-ttu-id="248bc-155">型が XAML UI によって参照される場合、XAML と同じプロジェクトになっていても、ランタイム クラスである必要があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-155">If your type is referenced by your XAML UI, then it needs to be a runtime class, even though it's in the same project as the XAML.</span></span> <span data-ttu-id="248bc-156">通常は実行可能な境界を越えてアクティブ化されますが、ランタイム クラスでは、代わりにそれを実装するコンパイル ユニット内で使用できます。</span><span class="sxs-lookup"><span data-stu-id="248bc-156">Although they are typically activated across executable boundaries, a runtime class can instead be used within the compilation unit that implements it.</span></span>

<span data-ttu-id="248bc-157">このシナリオでは、API を使用する \* および \* のどちらも作成します。</span><span class="sxs-lookup"><span data-stu-id="248bc-157">In this scenario, you're both authoring *and* consuming the APIs.</span></span> <span data-ttu-id="248bc-158">ランタイム クラスを実装するための手順は、Windows ランタイム コンポーネントと基本的に同じです。</span><span class="sxs-lookup"><span data-stu-id="248bc-158">The procedure for implementing your runtime class is essentially the same as that for a Windows Runtime Component.</span></span> <span data-ttu-id="248bc-159">このため、前のセクション [Windows ランタイム コンポーネントでランタイム クラスを作成する場合](#if-youre-authoring-a-runtime-class-in-a-windows-runtime-component)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="248bc-159">So, see the previous section&mdash;[If you're authoring a runtime class in a Windows Runtime Component](#if-youre-authoring-a-runtime-class-in-a-windows-runtime-component).</span></span> <span data-ttu-id="248bc-160">これと唯一異なる詳細な点は、IDL から、C++/WinRT ツールチェーンが、実装型だけでなく投影型も生成することです。</span><span class="sxs-lookup"><span data-stu-id="248bc-160">The only detail that differs is that, from the IDL, the C++/WinRT toolchain generates not only an implementation type but also a projected type.</span></span> <span data-ttu-id="248bc-161">このシナリオでは "**MyRuntimeClass**" というだけではあいまいなことを理解することは重要です。これは、その名前を持つさまざまな種類の複数のエンティティがあるためです。</span><span class="sxs-lookup"><span data-stu-id="248bc-161">It's important to appreciate that saying only "**MyRuntimeClass**" in this scenario may be ambiguous; there are several entities with that name, of different kinds.</span></span>

- <span data-ttu-id="248bc-162">**MyRuntimeClass** はランタイム クラスの名前です。</span><span class="sxs-lookup"><span data-stu-id="248bc-162">**MyRuntimeClass** is the name of a runtime class.</span></span> <span data-ttu-id="248bc-163">ただし、これは実際には IDL で宣言され、一部のプログラミング言語で実装されたアブストラクションです。</span><span class="sxs-lookup"><span data-stu-id="248bc-163">But this is really an abstraction: declared in IDL, and implemented in some programming language.</span></span>
- <span data-ttu-id="248bc-164">**MyRuntimeClass** は、C++ 構造体 **winrt::MyProject::implementation::MyRuntimeClass** の名前です。これはランタイム クラスの C++/WinRT の実装です。</span><span class="sxs-lookup"><span data-stu-id="248bc-164">**MyRuntimeClass** is the name of the C++ struct **winrt::MyProject::implementation::MyRuntimeClass**, which is the C++/WinRT implementation of the runtime class.</span></span> <span data-ttu-id="248bc-165">すでに見たように、プロジェクトを別に実装および使用している場合、この構造体は実装しているプロジェクトにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="248bc-165">As we've seen, if there are separate implementing and consuming projects, then this struct exists only in the implementing project.</span></span> <span data-ttu-id="248bc-166">これは*実装型*、または*実装*です。</span><span class="sxs-lookup"><span data-stu-id="248bc-166">This is *the implementation type*, or *the implementation*.</span></span> <span data-ttu-id="248bc-167">この型は、(`cppwinrt.exe` ツールによって) ファイル `\MyProject\MyProject\Generated Files\sources\MyRuntimeClass.h` と `MyRuntimeClass.cpp` で生成されます。</span><span class="sxs-lookup"><span data-stu-id="248bc-167">This type is generated (by the `cppwinrt.exe` tool) in the files `\MyProject\MyProject\Generated Files\sources\MyRuntimeClass.h` and `MyRuntimeClass.cpp`.</span></span>
- <span data-ttu-id="248bc-168">**MyRuntimeClass** は C++ 構造体 **winrt::MyProject::MyRuntimeClass** の形式の投影型の名前です。</span><span class="sxs-lookup"><span data-stu-id="248bc-168">**MyRuntimeClass** is the name of the projected type in the form of the C++ struct **winrt::MyProject::MyRuntimeClass**.</span></span> <span data-ttu-id="248bc-169">プロジェクトを別に実装および使用している場合、この構造体は使用しているプロジェクトにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="248bc-169">If there are separate implementing and consuming projects, then this struct exists only in the consuming project.</span></span> <span data-ttu-id="248bc-170">これは*投影型*、または*投影*です。</span><span class="sxs-lookup"><span data-stu-id="248bc-170">This is *the projected type*, or *the projection*.</span></span> <span data-ttu-id="248bc-171">この型は、(`cppwinrt.exe` によって) ファイル `\MyProject\MyProject\Generated Files\winrt\impl\MyProject.2.h` で生成されます。</span><span class="sxs-lookup"><span data-stu-id="248bc-171">This type is generated (by `cppwinrt.exe`) in the file `\MyProject\MyProject\Generated Files\winrt\impl\MyProject.2.h`.</span></span>

![投影型と実装型](images/myruntimeclass.png)

<span data-ttu-id="248bc-173">このトピックに関連する投影型の一部を次に示します。</span><span class="sxs-lookup"><span data-stu-id="248bc-173">Here are the parts of the projected type that are relevant to this topic.</span></span>

```cppwinrt
// MyProject.2.h
...
namespace winrt::MyProject
{
    struct MyRuntimeClass : MyProject::IMyRuntimeClass
    {
        MyRuntimeClass(std::nullptr_t) noexcept {}
        MyRuntimeClass();
    };
}
```

<span data-ttu-id="248bc-174">ランタイム クラスで **INotifyPropertyChanged** インターフェイスを実装する例のチュートリアルについては、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="248bc-174">For an example walkthrough of implementing the **INotifyPropertyChanged** interface on a runtime class, see [XAML controls; bind to a C++/WinRT property](binding-property.md).</span></span>

<span data-ttu-id="248bc-175">このシナリオでランタイム クラスを使用するための手順は、「[C++/WinRT での API の使用](consume-apis.md#if-the-api-is-implemented-in-the-consuming-project)」で説明しています。</span><span class="sxs-lookup"><span data-stu-id="248bc-175">The procedure for consuming your runtime class in this scenario is described in [Consume APIs with C++/WinRT](consume-apis.md#if-the-api-is-implemented-in-the-consuming-project).</span></span>

## <a name="runtime-class-constructors"></a><span data-ttu-id="248bc-176">ランタイム クラスのコンストラクター</span><span class="sxs-lookup"><span data-stu-id="248bc-176">Runtime class constructors</span></span>
<span data-ttu-id="248bc-177">上記で見た一覧から除くためのポイントを次に示します。</span><span class="sxs-lookup"><span data-stu-id="248bc-177">Here are some points to take away from the listings we've seen above.</span></span>

- <span data-ttu-id="248bc-178">各コンストラクターを IDL で宣言することで、コンストラクターは実装型と投影型の両方で生成されます。</span><span class="sxs-lookup"><span data-stu-id="248bc-178">Each constructor you declare in your IDL causes a constructor to be generated on both your implementation type and on your projected type.</span></span> <span data-ttu-id="248bc-179">IDL で宣言したコンストラクターは、*別の*コンパイル ユニットからランタイム クラスを使用するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="248bc-179">IDL-declared constructors are used to consume the runtime class from *a different* compilation unit.</span></span>
- <span data-ttu-id="248bc-180">コンストラクターを IDL で宣言してもしなくても、`nullptr_t` をとるコンストラクターのオーバーロードは投影型で生成されます。</span><span class="sxs-lookup"><span data-stu-id="248bc-180">Whether you have IDL-declared constructor(s) or not, a constructor overload that takes `nullptr_t` is generated on your projected type.</span></span> <span data-ttu-id="248bc-181">`nullptr_t` コンストラクターの呼び出しは、*同じ*コンパイル ユニットからのランタイム クラスの使用における *2 つの手順のうちの最初の手順*です。</span><span class="sxs-lookup"><span data-stu-id="248bc-181">Calling the `nullptr_t` constructor is *the first of two steps* in consuming the runtime class from *the same* compilation unit.</span></span> <span data-ttu-id="248bc-182">詳細とコード例については、「[C++/WinRT での API の使用](consume-apis.md#if-the-api-is-implemented-in-the-consuming-project)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="248bc-182">For more details, and a code example, see [Consume APIs with C++/WinRT](consume-apis.md#if-the-api-is-implemented-in-the-consuming-project).</span></span>
- <span data-ttu-id="248bc-183">*同じ*コンパイル ユニットからランタイム クラスを使用している場合、(`MyRuntimeClass.h` の) 実装型で非既定のコンストラクターを直接実装することもできます。</span><span class="sxs-lookup"><span data-stu-id="248bc-183">If you're consuming the runtime class from *the same* compilation unit, then you can also implement non-default constructors directly on the implementation type (which, remember, is in `MyRuntimeClass.h`).</span></span>

> [!NOTE]
> <span data-ttu-id="248bc-184">ランタイム クラスが別のコンパイル ユニットから使用することが予測される場合は (これは一般的です)、IDL にコンストラクター (少なくとも既定のコンストラクター) を含めます。</span><span class="sxs-lookup"><span data-stu-id="248bc-184">If you expect your runtime class to be consumed from a different compilation unit (which is common), then include constructor(s) in your IDL (at least a default constructor).</span></span> <span data-ttu-id="248bc-185">これを行うことで、実装型とともにファクトリの実装も取得します。</span><span class="sxs-lookup"><span data-stu-id="248bc-185">By doing that, you'll also get a factory implementation alongside your implementation type.</span></span>
> 
> <span data-ttu-id="248bc-186">同じコンパイル ユニット内でのみランタイム クラスを作成および使用する場合は、IDL でコンストラクターを宣言しないでください。</span><span class="sxs-lookup"><span data-stu-id="248bc-186">If you want to author and consume your runtime class only within the same compilation unit, then don't declare any constructor(s) in your IDL.</span></span> <span data-ttu-id="248bc-187">ファクトリの実装は不要であり、生成されません。</span><span class="sxs-lookup"><span data-stu-id="248bc-187">You don't need a factory implementation, and one won't be generated.</span></span> <span data-ttu-id="248bc-188">実装型の既定のコンストラクターが削除されますが、簡単に編集して、代わりに既定にすることができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-188">Your implementation type's default constructor will be deleted, but you can easily edit it and default it instead.</span></span>
> 
> <span data-ttu-id="248bc-189">同じコンパイル ユニット内でのみランタイム クラスを作成および使用する場合は、コンストラクターのパラメーターが必要であり、実装型で直接必要なコンストラクターを作成します。</span><span class="sxs-lookup"><span data-stu-id="248bc-189">If you want to author and consume your runtime class only within the same compilation unit, and you need constructor parameters, then author the constructor(s) that you need directly on your implementation type.</span></span>

## <a name="instantiating-and-returning-implementation-types-and-interfaces"></a><span data-ttu-id="248bc-190">実装型とインターフェイスをインスタンス化して返す</span><span class="sxs-lookup"><span data-stu-id="248bc-190">Instantiating and returning implementation types and interfaces</span></span>
<span data-ttu-id="248bc-191">このセクションでは、[**IStringable**](/uwp/api/windows.foundation.istringable) および [**IClosable**](/uwp/api/windows.foundation.iclosable) インターフェイスを実装する、**MyType** という名前の実装型を例として見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="248bc-191">For this section, let's take as an example an implementation type named **MyType**, which implements the [**IStringable**](/uwp/api/windows.foundation.istringable) and [**IClosable**](/uwp/api/windows.foundation.iclosable) interfaces.</span></span>

<span data-ttu-id="248bc-192">[**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) から直接 **MyType** を派生できます (ランタイム クラスではありません)。</span><span class="sxs-lookup"><span data-stu-id="248bc-192">You can derive **MyType** directly from [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) (it's not a runtime class).</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

struct MyType : implements<MyType, IStringable, IClosable>
{
    winrt::hstring ToString(){ ... }
    void Close(){}
};
```

<span data-ttu-id="248bc-193">または IDL から生成することができます (これはランタイム クラスです)。</span><span class="sxs-lookup"><span data-stu-id="248bc-193">Or you can generate it from IDL (it's a runtime class).</span></span>

```idl
// MyType.idl
namespace MyProject
{
    runtimeclass MyType: Windows.Foundation.IStringable, Windows.Foundation.IClosable
    {
        MyType();
    }    
}
```

<span data-ttu-id="248bc-194">**MyType** から、プロジェクションの一部として使用するまたは返すことができる **IStringable** または **IClosable** オブジェクトへ移動するには、[**winrt::make**](/uwp/cpp-ref-for-winrt/make) 関数テンプレートを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-194">To go from **MyType** to an **IStringable** or **IClosable** object that you can use or return as part of your projection, you can call the [**winrt::make**](/uwp/cpp-ref-for-winrt/make) function template.</span></span> <span data-ttu-id="248bc-195">**ように**実装型の既定のインターフェイスを返します。</span><span class="sxs-lookup"><span data-stu-id="248bc-195">**make** returns the implementation type's default interface.</span></span>

```cppwinrt
IStringable istringable = winrt::make<MyType>();
```

> [!NOTE]
> <span data-ttu-id="248bc-196">ただし、XAML UI から型を参照している場合は、同じプロジェクト内に実装型と投影型の両方があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-196">However, if you're referencing your type from your XAML UI, then there will be both an implementation type and a projected type in the same project.</span></span> <span data-ttu-id="248bc-197">その場合は、**ように**投影された型のインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="248bc-197">In that case, **make** returns an instance of the projected type.</span></span> <span data-ttu-id="248bc-198">そのシナリオのコード例については、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="248bc-198">For a code example of that scenario, see [XAML controls; bind to a C++/WinRT property](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage).</span></span>

<span data-ttu-id="248bc-199">**IStringable** インターフェイスのメンバーを呼び出すには (上記のコード例の場合) `istringable` のみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="248bc-199">We can only use `istringable` (in the code example above) to call the members of the **IStringable** interface.</span></span> <span data-ttu-id="248bc-200">ただし C++/WinRT インターフェイス (投影されたインターフェイス) は [**winrt::Windows::Foundation::IUnknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown) から派生します。</span><span class="sxs-lookup"><span data-stu-id="248bc-200">But a C++/WinRT interface (which is a projected interface) derives from [**winrt::Windows::Foundation::IUnknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown).</span></span> <span data-ttu-id="248bc-201">そのため、他の投影された型またはインターフェイスも使うかを返す[**iunknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) (または[**iunknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)) でクエリを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-201">So, you can call [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) (or [**IUnknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)) on it to query for other projected types or interfaces, which you can also either use or return.</span></span>

```cppwinrt
istringable.ToString();
IClosable iclosable = istringable.as<IClosable>();
iclosable.Close();
```

<span data-ttu-id="248bc-202">すべての実装のメンバーにアクセスし、後でインターフェイスを呼び出し元に返す必要がある場合、[**winrt::make_self**](/uwp/cpp-ref-for-winrt/make-self) 関数テンプレートを使用します。</span><span class="sxs-lookup"><span data-stu-id="248bc-202">If you need to access all of the implementation's members, and then later return an interface to a caller, then use the [**winrt::make_self**](/uwp/cpp-ref-for-winrt/make-self) function template.</span></span> <span data-ttu-id="248bc-203">**make_self** は、実装型をラッピングする [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) を返します。</span><span class="sxs-lookup"><span data-stu-id="248bc-203">**make_self** returns a [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) wrapping the implementation type.</span></span> <span data-ttu-id="248bc-204">(矢印演算子を使用して) そのインターフェイスのすべてのメンバーにアクセスすることができます。これをそのまま呼び出し元に返すか、またはそこで **as** を呼び出して結果として得られるインターフェイス オブジェクトを呼び出し元に返します。</span><span class="sxs-lookup"><span data-stu-id="248bc-204">You can access the members of all of its interfaces (using the arrow operator), you can return it to a caller as-is, or you can call **as** on it and return the resulting interface object to a caller.</span></span>

```cppwinrt
winrt::com_ptr<MyType> myimpl = winrt::make_self<MyType>();
myimpl->ToString();
myimpl->Close();
IClosable iclosable = myimpl.as<IClosable>();
iclosable.Close();
```

<span data-ttu-id="248bc-205">**MyType** クラスは、プロジェクションの一部ではなく、実装です。</span><span class="sxs-lookup"><span data-stu-id="248bc-205">The **MyType** class is not part of the projection; it's the implementation.</span></span> <span data-ttu-id="248bc-206">ただしこの方法では、仮想関数呼び出しのオーバーヘッドがなく、その実装メソッドを直接呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-206">But this way you can call its implementation methods directly, without the overhead of a virtual function call.</span></span> <span data-ttu-id="248bc-207">上記の例では、**MyType::ToString** が **IStringable** で投影されたメソッドと同じ署名を使用するにもかかわらず、アプリケーション バイナリ インターフェイス (ABI) を交差することなく非仮想メソッドを直接呼び出しています。</span><span class="sxs-lookup"><span data-stu-id="248bc-207">In the example above, even though **MyType::ToString** uses the same signature as the projected method on **IStringable**, we're calling the non-virtual method directly, without crossing the application binary interface (ABI).</span></span> <span data-ttu-id="248bc-208">**Com_ptr** は **MyType** 構造体へのポインターを保持するだけであるため、`myimpl` 変数と矢印演算子を介して、**MyType** の他の内部の詳細にもアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="248bc-208">The **com_ptr** simply holds a pointer to the **MyType** struct, so you can also access any other internal details of **MyType** via the `myimpl` variable and the arrow operator.</span></span>

<span data-ttu-id="248bc-209">インターフェイス オブジェクトがあり、実装上のインターフェイスであることが分かる場合、[**from_abi**](/uwp/cpp-ref-for-winrt/from-abi) 関数テンプレートを使用して実装に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-209">In the case where you have an interface object, and you happen to know that it's an interface on your implementation, then you can get back to the implementation using the [**from_abi**](/uwp/cpp-ref-for-winrt/from-abi) function template.</span></span> <span data-ttu-id="248bc-210">もう一度、これは仮想関数の呼び出しを回避し、実装で直接取得することができる手法です。</span><span class="sxs-lookup"><span data-stu-id="248bc-210">Again, it's a technique that avoids virtual function calls, and lets you get directly at the implementation.</span></span>

> [!NOTE]
> <span data-ttu-id="248bc-211">[Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)をインストールした場合、後を呼び出すときに[**winrt::from_abi**](/uwp/cpp-ref-for-winrt/from-abi)ではなく[**winrt::get_self**](/uwp/cpp-ref-for-winrt/get-self)します。</span><span class="sxs-lookup"><span data-stu-id="248bc-211">If you've installed the [Windows 10 SDK Preview Build 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK), or later, then you can call [**winrt::get_self**](/uwp/cpp-ref-for-winrt/get-self) instead of [**winrt::from_abi**](/uwp/cpp-ref-for-winrt/from-abi).</span></span>

<span data-ttu-id="248bc-212">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="248bc-212">Here's an example.</span></span> <span data-ttu-id="248bc-213">[ **BgLabelControl**カスタム コントロール クラスの実装](xaml-cust-ctrl.md#implement-the-bglabelcontrol-custom-control-class)には、別の例があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-213">There's another example in [Implement the **BgLabelControl** custom control class](xaml-cust-ctrl.md#implement-the-bglabelcontrol-custom-control-class).</span></span>

```cppwinrt
void ImplFromIClosable(IClosable const& from)
{
    MyType* myimpl = winrt::from_abi<MyType>(from);
    myimpl->ToString();
    myimpl->Close();
}
```

<span data-ttu-id="248bc-214">ただし元のインターフェイス オブジェクトのみ参照に保持されます。</span><span class="sxs-lookup"><span data-stu-id="248bc-214">But only the original interface object holds on to a reference.</span></span> <span data-ttu-id="248bc-215">\*\* これを保持する場合は、[**com_ptr::copy_from**](/uwp/cpp-ref-for-winrt/com-ptr#comptrcopyfrom-function) を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="248bc-215">If *you* want to hold on to it, then you can call [**com_ptr::copy_from**](/uwp/cpp-ref-for-winrt/com-ptr#comptrcopyfrom-function).</span></span>

```cppwinrt
winrt::com_ptr<MyType> impl;
impl.copy_from(winrt::from_abi<MyType>(from));
// com_ptr::copy_from ensures that AddRef is called.
```

<span data-ttu-id="248bc-216">実装型自体は、**winrt::Windows::Foundation::IUnknown** から派生したものではないため、**as** 関数はありません。</span><span class="sxs-lookup"><span data-stu-id="248bc-216">The implementation type itself doesn't derive from **winrt::Windows::Foundation::IUnknown**, so it has no **as** function.</span></span> <span data-ttu-id="248bc-217">その場合でも、1 つのインスタンスを作成し、そのインターフェイスのすべてのメンバーにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="248bc-217">Even so, you can instantiate one, and access the members of all of its interfaces.</span></span> <span data-ttu-id="248bc-218">ただしこれを行う場合、未処理の実装型のインスタンスを呼び出し元に返さないでください。</span><span class="sxs-lookup"><span data-stu-id="248bc-218">But if you do this, then don't return the raw implementation type instance to the caller.</span></span> <span data-ttu-id="248bc-219">代わりに、前に示した手法のいずれかを使用して、投影されるインターフェイスまたは **com_ptr** を返します。</span><span class="sxs-lookup"><span data-stu-id="248bc-219">Instead, use one of the techniques shown above and return a projected interface, or a **com_ptr**.</span></span>

```cppwinrt
MyType myimpl;
myimpl.ToString();
myimpl.Close();
IClosable ic1 = myimpl.as<IClosable>(); // error
```

<span data-ttu-id="248bc-220">実装型のインスタンスがある場合は、対応する投影型を想定している関数にこれを渡す必要があり、その後実行できます。</span><span class="sxs-lookup"><span data-stu-id="248bc-220">If you have an instance of your implementation type, and you need to pass it to a function that expects the corresponding projected type, then you can do so.</span></span> <span data-ttu-id="248bc-221">実装型に存在する変換演算子 (によって実装型が生成された、`cppwinrt.exe`ツール) によりこのできます。</span><span class="sxs-lookup"><span data-stu-id="248bc-221">A conversion operator exists on your implementation type (provided that the implementation type was generated by the `cppwinrt.exe` tool) that makes this possible.</span></span>

## <a name="deriving-from-a-type-that-has-a-non-default-constructor"></a><span data-ttu-id="248bc-222">既定以外のコンス トラクターを持つ型からの派生</span><span class="sxs-lookup"><span data-stu-id="248bc-222">Deriving from a type that has a non-default constructor</span></span>
<span data-ttu-id="248bc-223">[**ToggleButtonAutomationPeer::ToggleButtonAutomationPeer(ToggleButton)**](/uwp/api/windows.ui.xaml.automation.peers.togglebuttonautomationpeer.-ctor#Windows_UI_Xaml_Automation_Peers_ToggleButtonAutomationPeer__ctor_Windows_UI_Xaml_Controls_Primitives_ToggleButton_)は、既定以外のコンス トラクターの例を示します。</span><span class="sxs-lookup"><span data-stu-id="248bc-223">[**ToggleButtonAutomationPeer::ToggleButtonAutomationPeer(ToggleButton)**](/uwp/api/windows.ui.xaml.automation.peers.togglebuttonautomationpeer.-ctor#Windows_UI_Xaml_Automation_Peers_ToggleButtonAutomationPeer__ctor_Windows_UI_Xaml_Controls_Primitives_ToggleButton_) is an example of a non-default constructor.</span></span> <span data-ttu-id="248bc-224">既定のコンストラクターがないので、**ToggleButtonAutomationPeer** を作成するには、*オーナー* に渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-224">There's no default constructor so, to construct a **ToggleButtonAutomationPeer**, you need to pass an *owner*.</span></span> <span data-ttu-id="248bc-225">したがって、**ToggleButtonAutomationPeer** から派生する場合、*オーナー* を受け取りベースに渡すコンストラクターを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="248bc-225">Consequently, if you derive from **ToggleButtonAutomationPeer**, then you need to provide a constructor that takes an *owner* and passes it to the base.</span></span> <span data-ttu-id="248bc-226">実際には次のようになります。</span><span class="sxs-lookup"><span data-stu-id="248bc-226">Let's see what that looks like in practice.</span></span>

```idl
// MySpecializedToggleButton.idl
namespace MyNamespace
{
    runtimeclass MySpecializedToggleButton :
        Windows.UI.Xaml.Controls.Primitives.ToggleButton
    {
        ...
    };
}
```

```idl
// MySpecializedToggleButtonAutomationPeer.idl
namespace MyNamespace
{
    runtimeclass MySpecializedToggleButtonAutomationPeer :
        Windows.UI.Xaml.Automation.Peers.ToggleButtonAutomationPeer
    {
        MySpecializedToggleButtonAutomationPeer(MySpecializedToggleButton owner);
    };
}
```

<span data-ttu-id="248bc-227">実装型の生成されるコンストラクターは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="248bc-227">The generated constructor for your implementation type looks like this.</span></span>

```cppwinrt
// MySpecializedToggleButtonAutomationPeer.cpp
...
MySpecializedToggleButtonAutomationPeer::MySpecializedToggleButtonAutomationPeer
    (MyNamespace::MySpecializedToggleButton const& owner)
{
    ...
}
...
```

<span data-ttu-id="248bc-228">唯一のない部分は、基底クラスにコンストラクター パラメーターを渡す必要があることです。</span><span class="sxs-lookup"><span data-stu-id="248bc-228">The only piece missing is that you need to pass that constructor parameter on to the base class.</span></span> <span data-ttu-id="248bc-229">上述の F バインド ポリモーフィズム パターンを覚えていますか。</span><span class="sxs-lookup"><span data-stu-id="248bc-229">Remember the F-bound polymorphism pattern that we mentioned above?</span></span> <span data-ttu-id="248bc-230">C++/WinRT で使われるそのパターンの詳細を理解したら、基底クラスと呼ばれるものが何かを理解することができます (または実装クラスのヘッダー ファイルだけを参照することができます)。</span><span class="sxs-lookup"><span data-stu-id="248bc-230">Once you're familiar with the details of that pattern as used by C++/WinRT, you can figure out what your base class is called (or you can just look in your implementation class's header file).</span></span> <span data-ttu-id="248bc-231">これは、このケースで基底クラス コンストラクターを呼び出す方法です。</span><span class="sxs-lookup"><span data-stu-id="248bc-231">This is how to call the base class constructor in this case.</span></span>

```cppwinrt
// MySpecializedToggleButtonAutomationPeer.cpp
...
MySpecializedToggleButtonAutomationPeer::MySpecializedToggleButtonAutomationPeer
    (MyNamespace::MySpecializedToggleButton const& owner) : 
    MySpecializedToggleButtonAutomationPeerT<MySpecializedToggleButtonAutomationPeer>(owner)
{
    ...
}
...
```

<span data-ttu-id="248bc-232">基底クラス コンストラクターは、**ToggleButton** を期待します。</span><span class="sxs-lookup"><span data-stu-id="248bc-232">The base class constructor expects a **ToggleButton**.</span></span> <span data-ttu-id="248bc-233">そして **MySpecializedToggleButton**\* は \***ToggleButton** です。</span><span class="sxs-lookup"><span data-stu-id="248bc-233">And **MySpecializedToggleButton** *is a* **ToggleButton**.</span></span>

<span data-ttu-id="248bc-234">(基底クラスにコンストラクター パラメーターを渡すために) 上記で説明した編集を行うまで、コンパイラは、コンストラクターにフラグを設定し、(この場合は)  **MySpecializedToggleButtonAutomationPeer_base&lt;MySpecializedToggleButtonAutomationPeer&gt;** と呼ばれる型で利用可能な適切な既定のコンストラクターがないことを指摘します。</span><span class="sxs-lookup"><span data-stu-id="248bc-234">Until you make the edit described above (to pass that constructor parameter on to the base class), the compiler will flag your constructor and point out that there's no appropriate default constructor available on a type called (in this case) **MySpecializedToggleButtonAutomationPeer_base&lt;MySpecializedToggleButtonAutomationPeer&gt;**.</span></span> <span data-ttu-id="248bc-235">実際には、実装型の基底クラスの基底クラスです。</span><span class="sxs-lookup"><span data-stu-id="248bc-235">That's actually the base class of the bass class of your implementation type.</span></span>

## <a name="important-apis"></a><span data-ttu-id="248bc-236">重要な API</span><span class="sxs-lookup"><span data-stu-id="248bc-236">Important APIs</span></span>
* [<span data-ttu-id="248bc-237">winrt::com_ptr 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="248bc-237">winrt::com_ptr struct template</span></span>](/uwp/cpp-ref-for-winrt/com-ptr)
* [<span data-ttu-id="248bc-238">winrt::com_ptr::copy_from 関数</span><span class="sxs-lookup"><span data-stu-id="248bc-238">winrt::com_ptr::copy_from function</span></span>](/uwp/cpp-ref-for-winrt/com-ptr#comptrcopyfrom-function)
* [<span data-ttu-id="248bc-239">winrt::from_abi 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="248bc-239">winrt::from_abi function template</span></span>](/uwp/cpp-ref-for-winrt/from-abi)
* [<span data-ttu-id="248bc-240">winrt::get_self 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="248bc-240">winrt::get_self function template</span></span>](/uwp/cpp-ref-for-winrt/get-self)
* [<span data-ttu-id="248bc-241">winrt::implements 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="248bc-241">winrt::implements struct template</span></span>](/uwp/cpp-ref-for-winrt/implements)
* [<span data-ttu-id="248bc-242">winrt::make 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="248bc-242">winrt::make function template</span></span>](/uwp/cpp-ref-for-winrt/make)
* [<span data-ttu-id="248bc-243">winrt::make_self 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="248bc-243">winrt::make_self function template</span></span>](/uwp/cpp-ref-for-winrt/make-self)
* [<span data-ttu-id="248bc-244">winrt::Windows::Foundation::IUnknown::as 関数</span><span class="sxs-lookup"><span data-stu-id="248bc-244">winrt::Windows::Foundation::IUnknown::as function</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)

## <a name="related-topics"></a><span data-ttu-id="248bc-245">関連トピック</span><span class="sxs-lookup"><span data-stu-id="248bc-245">Related topics</span></span>
* [<span data-ttu-id="248bc-246">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="248bc-246">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="248bc-247">XAML コントロール、C++/WinRT プロパティへのバインド</span><span class="sxs-lookup"><span data-stu-id="248bc-247">XAML controls; bind to a C++/WinRT property</span></span>](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)
