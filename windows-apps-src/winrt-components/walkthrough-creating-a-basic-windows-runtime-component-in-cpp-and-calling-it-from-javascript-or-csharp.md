---
title: C++/CX での Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し
description: このチュートリアルでは、JavaScript、C#、または Visual Basic から呼び出すことができる基本的な Windows ランタイム コンポーネント DLL を作成する方法について説明します。
ms.assetid: 764CD9C6-3565-4DFF-88D7-D92185C7E452
ms.date: 05/14/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 50c9e80296510d327e60f8c7dba5e38f19b95b7f
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8328982"
---
# <a name="walkthrough-creating-a-windows-runtime-component-in-ccx-and-calling-it-from-javascript-or-c"></a><span data-ttu-id="2dc8b-104">チュートリアル: C++/CX での Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し</span><span class="sxs-lookup"><span data-stu-id="2dc8b-104">Walkthrough: Creating a Windows Runtime component in C++/CX, and calling it from JavaScript or C#</span></span>
> [!NOTE]
> <span data-ttu-id="2dc8b-105">このトピックは、C++/CX アプリケーションの管理ができるようにすることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-105">This topic exists to help you maintain your C++/CX application.</span></span> <span data-ttu-id="2dc8b-106">ただし、新しいアプリケーションには [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-106">But we recommend that you use [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) for new applications.</span></span> <span data-ttu-id="2dc8b-107">C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-107">C++/WinRT is an entirely standard modern C++17 language projection for Windows Runtime (WinRT) APIs, implemented as a header-file-based library, and designed to provide you with first-class access to the modern Windows API.</span></span> <span data-ttu-id="2dc8b-108">C + を使用して Windows ランタイム コンポーネントを作成する方法について/WinRT を参照してください[、C++ でのイベントの作成/WinRT](../cpp-and-winrt-apis/author-events.md)します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-108">To learn how to create a Windows Runtime Component using C++/WinRT, see [Author events in C++/WinRT](../cpp-and-winrt-apis/author-events.md).</span></span>

<span data-ttu-id="2dc8b-109">このチュートリアルでは、JavaScript、C#、または Visual Basic から呼び出すことができる基本的な Windows ランタイム コンポーネント DLL を作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-109">This walkthrough shows how to create a basic Windows Runtime Component DLL that's callable from JavaScript, C#, or Visual Basic.</span></span> <span data-ttu-id="2dc8b-110">このチュートリアルを開始する前に、抽象バイナリ インターフェイス (ABI)、ref クラス、Visual C++ コンポーネント拡張などの概念を必ず理解しておいてください。ref クラスの操作が容易になります。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-110">Before you begin this walkthrough, make sure that you understand concepts such as the Abstract Binary Interface (ABI), ref classes, and the Visual C++ Component Extensions that make working with ref classes easier.</span></span> <span data-ttu-id="2dc8b-111">詳しくは、「[C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)」および「[Visual C++ の言語リファレンス (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-111">For more information, see [Creating Windows Runtime Components in C++](creating-windows-runtime-components-in-cpp.md) and [Visual C++ Language Reference (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx).</span></span>

## <a name="creating-the-c-component-dll"></a><span data-ttu-id="2dc8b-112">C++ コンポーネント DLL の作成</span><span class="sxs-lookup"><span data-stu-id="2dc8b-112">Creating the C++ component DLL</span></span>
<span data-ttu-id="2dc8b-113">この例では、最初にコンポーネント プロジェクトを作成しますが、JavaScript プロジェクトを最初に作成しても構いません。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-113">In this example, we create the component project first, but you could create the JavaScript project first.</span></span> <span data-ttu-id="2dc8b-114">順序は重要ではありません。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-114">The order doesn’t matter.</span></span>

<span data-ttu-id="2dc8b-115">コンポーネントのメイン クラスには、プロパティとメソッドの定義およびイベント宣言の例が含まれています。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-115">Notice that the main class of the component contains examples of property and method definitions, and an event declaration.</span></span> <span data-ttu-id="2dc8b-116">これらは方法を示すことだけを目的に用意されており、</span><span class="sxs-lookup"><span data-stu-id="2dc8b-116">These are provided just to show you how it's done.</span></span> <span data-ttu-id="2dc8b-117">必須ではありません。この例では、生成されたコードはすべて独自のコードに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-117">They are not required, and in this example, we'll replace all of the generated code with our own code.</span></span>

## **<a name="to-create-the-c-component-project"></a><span data-ttu-id="2dc8b-118">C++ コンポーネント プロジェクトを作成するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-118">To create the C++ component project</span></span>**
<span data-ttu-id="2dc8b-119">Visual Studio のメニュー バーで、**[ファイル]、[新規作成]、[プロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-119">On the Visual Studio menu bar, choose **File, New, Project**.</span></span>

<span data-ttu-id="2dc8b-120">**[新しいプロジェクト]** ダイアログ ボックスの左ペインで、**[Visual C++]** を展開し、ユニバーサル Windows アプリのノードを選択します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-120">In the **New Project** dialog box, in the left pane, expand **Visual C++** and then select the node for Universal Windows apps.</span></span>

<span data-ttu-id="2dc8b-121">中央ペインで **[Windows ランタイム コンポーネント]** を選び、プロジェクトに WinRT\_CPP という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-121">In the center pane, select **Windows Runtime Component** and then name the project WinRT\_CPP.</span></span>

<span data-ttu-id="2dc8b-122">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-122">Choose the **OK** button.</span></span>

## **<a name="to-add-an-activatable-class-to-the-component"></a><span data-ttu-id="2dc8b-123">コンポーネントにアクティブ化可能なクラスを追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-123">To add an activatable class to the component</span></span>**
<span data-ttu-id="2dc8b-124">アクティブ化可能なクラスとは、クライアント コードで **new** 式 (Visual Basic では **New**、C++ では **ref new**) を使って作成できるクラスのことです。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-124">An activatable class is one that client code can create by using a **new** expression (**New** in Visual Basic, or **ref new** in C++).</span></span> <span data-ttu-id="2dc8b-125">コンポーネントでは、**public ref class sealed** として宣言します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-125">In your component, you declare it as **public ref class sealed**.</span></span> <span data-ttu-id="2dc8b-126">実際には、Class1.h ファイルと .cpp ファイルに ref クラスが既に含まれています。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-126">In fact, the Class1.h and .cpp files already have a ref class.</span></span> <span data-ttu-id="2dc8b-127">名前を変更することはできますが、この例では既定の名前 (Class1) を使います。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-127">You can change the name, but in this example we’ll use the default name—Class1.</span></span> <span data-ttu-id="2dc8b-128">必要に応じて、コンポーネント内で追加の ref クラスまたは regular クラスを定義できます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-128">You can define additional ref classes or regular classes in your component if they are required.</span></span> <span data-ttu-id="2dc8b-129">ref クラスについて詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-129">For more information about ref classes, see [Type System (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx).</span></span>

<span data-ttu-id="2dc8b-130">次の \#include ディレクティブを Class1.h に追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-130">Add these \#include directives to Class1.h:</span></span>

```cpp
#include <collection.h>
#include <ppl.h>
#include <amp.h>
#include <amp_math.h>
```

<span data-ttu-id="2dc8b-131">collection.h は、Windows ランタイムによって定義されている言語に依存しないインターフェイスを実装する C++ の具象クラス (Platform::Collections::Vector クラスや Platform::Collections::Map クラスなど) のヘッダー ファイルです。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-131">collection.h is the header file for C++ concrete classes such as the Platform::Collections::Vector class and the Platform::Collections::Map class, which implement language-neutral interfaces that are defined by the Windows Runtime.</span></span> <span data-ttu-id="2dc8b-132">amp ヘッダーは、GPU で計算を実行する際に使用されます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-132">The amp headers are used to run computations on the GPU.</span></span> <span data-ttu-id="2dc8b-133">Windows ランタイムには amp ヘッダーに相当するものはありませんが、これらはプライベートであるため、問題はありません。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-133">They have no Windows Runtime equivalents, and that’s fine because they are private.</span></span> <span data-ttu-id="2dc8b-134">一般に、パフォーマンス上の理由から、コンポーネント内部では ISO C++ コードと標準ライブラリを使います。Windows ランタイム型で表現する必要があるのは、Windows ランタイム インターフェイスだけです。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-134">In general, for performance reasons you should use ISO C++ code and standard libraries internally within the component; it’s just the Windows Runtime interface that must be expressed in Windows Runtime types.</span></span>

## <a name="to-add-a-delegate-at-namespace-scope"></a><span data-ttu-id="2dc8b-135">名前空間スコープでデリゲートを追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-135">To add a delegate at namespace scope</span></span>
<span data-ttu-id="2dc8b-136">デリゲートとは、メソッドのパラメーターと戻り値の型を定義するコンストラクトです。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-136">A delegate is a construct that defines the parameters and return type for methods.</span></span> <span data-ttu-id="2dc8b-137">イベントは特定のデリゲート型のインスタンスであり、イベントにサブスクライブするイベント ハンドラー メソッドには、デリゲートで指定されているシグネチャが必要です。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-137">An event is an instance of a particular delegate type, and any event handler method that subscribes to the event must have the signature that's specified in the delegate.</span></span> <span data-ttu-id="2dc8b-138">次のコードでは、int を受け取り、void を返すデリゲート型を定義します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-138">The following code defines a delegate type that takes an int and returns void.</span></span> <span data-ttu-id="2dc8b-139">次に、このコードでこの型のパブリック イベントを宣言します。これにより、クライアント コードはイベントが発生したときに呼び出されるメソッドを提供できるようになります。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-139">Next the code declares a public event of this type; this enables client code to provide methods that are invoked when the event is fired.</span></span>

<span data-ttu-id="2dc8b-140">Class1.h で、Class1 宣言の直前に名前空間スコープで次のデリゲート宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-140">Add the following delegate declaration at namespace scope in Class1.h, just before the Class1 declaration.</span></span>

```cpp
public delegate void PrimeFoundHandler(int result);
```

<span data-ttu-id="2dc8b-141">Visual Studio に貼り付けたときにコードが整列されていない場合は、Ctrl + K + D キーを押すと、ファイル全体のインデントが修正されます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-141">If the code isn’t lining up correctly when you paste it into Visual Studio, just press Ctrl+K+D to fix the indentation for the entire file.</span></span>

## <a name="to-add-the-public-members"></a><span data-ttu-id="2dc8b-142">パブリック メンバーを追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-142">To add the public members</span></span>
<span data-ttu-id="2dc8b-143">クラスで 3 つのパブリック メソッドと 1 つのパブリック イベントを公開します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-143">The class exposes three public methods and one public event.</span></span> <span data-ttu-id="2dc8b-144">最初のメソッドは常に高速で実行されるので、同期メソッドです。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-144">The first method is synchronous because it always executes very fast.</span></span> <span data-ttu-id="2dc8b-145">他の 2 つのメソッドは時間がかかる場合があるので、UI スレッドをブロックしないように非同期にします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-145">Because the other two methods might take some time, they are asynchronous so that they don’t block the UI thread.</span></span> <span data-ttu-id="2dc8b-146">これらのメソッドは、IAsyncOperationWithProgress と IAsyncActionWithProgress を返します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-146">These methods return IAsyncOperationWithProgress and IAsyncActionWithProgress.</span></span> <span data-ttu-id="2dc8b-147">前者は結果を返す非同期メソッドを定義し、後者は void を返す非同期メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-147">The former defines an async method that returns a result, and the latter defines an async method that returns void.</span></span> <span data-ttu-id="2dc8b-148">また、これらのインターフェイスにより、クライアント コードは操作の進行状況の更新を受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-148">These interfaces also enable client code to receive updates on the progress of the operation.</span></span>

```cpp
public:

        // Synchronous method.
        Windows::Foundation::Collections::IVector<double>^  ComputeResult(double input);

        // Asynchronous methods
        Windows::Foundation::IAsyncOperationWithProgress<Windows::Foundation::Collections::IVector<int>^, double>^
            GetPrimesOrdered(int first, int last);
        Windows::Foundation::IAsyncActionWithProgress<double>^ GetPrimesUnordered(int first, int last);

        // Event whose type is a delegate "class"
        event PrimeFoundHandler^ primeFoundEvent;

```
## <a name="to-add-the-private-members"></a><span data-ttu-id="2dc8b-149">プライベート メンバーを追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-149">To add the private members</span></span>
<span data-ttu-id="2dc8b-150">クラスには 3 つのプライベート メンバーが含まれています。数値計算用の 2 つのヘルパー メソッドと、ワーカー スレッドから UI スレッドにイベント呼び出しをマーシャリングするために使われる CoreDispatcher オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-150">The class contains three private members: two helper methods for the numeric computations and a CoreDispatcher object that’s used to marshal the event invocations from worker threads back to the UI thread.</span></span>

```cpp
private:
        bool is_prime(int n);
        Windows::UI::Core::CoreDispatcher^ m_dispatcher;
```

## <a name="to-add-the-header-and-namespace-directives"></a><span data-ttu-id="2dc8b-151">ヘッダーと名前空間のディレクティブを追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-151">To add the header and namespace directives</span></span>
<span data-ttu-id="2dc8b-152">Class1.cpp で、次の #include ディレクティブを追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-152">In Class1.cpp, add these #include directives:</span></span>

```cpp
#include <ppltasks.h>
#include <concurrent_vector.h>
```

<span data-ttu-id="2dc8b-153">次の using ステートメントを追加して必要な名前空間を追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-153">Now add these using statements to pull in the required namespaces:</span></span>

```cpp
using namespace concurrency;
using namespace Platform::Collections;
using namespace Windows::Foundation::Collections;
using namespace Windows::Foundation;
using namespace Windows::UI::Core;
```

## <a name="to-add-the-implementation-for-computeresult"></a><span data-ttu-id="2dc8b-154">ComputeResult の実装を追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-154">To add the implementation for ComputeResult</span></span>
<span data-ttu-id="2dc8b-155">Class1.cpp で、次のメソッド実装を追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-155">In Class1.cpp, add the following method implementation.</span></span> <span data-ttu-id="2dc8b-156">このメソッドは呼び出しスレッドで同期的に実行されますが、C++ AMP を使って GPU での計算を並列化するため、非常に高速です。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-156">This method executes synchronously on the calling thread, but it is very fast because it uses C++ AMP to parallelize the computation on the GPU.</span></span> <span data-ttu-id="2dc8b-157">詳しくは、「C++ AMP の概要」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-157">For more information, see C++ AMP Overview.</span></span> <span data-ttu-id="2dc8b-158">結果は Platform::Collections::Vector<T> 具象型に追加されます。この型は、返されるときに Windows::Foundation::Collections::IVector<T> に暗黙的に変換されます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-158">The results are appended to a Platform::Collections::Vector<T> concrete type, which is implicitly converted to a Windows::Foundation::Collections::IVector<T> when it is returned.</span></span>

```cpp
//Public API
IVector<double>^ Class1::ComputeResult(double input)
{
    // Implement your function in ISO C++ or
    // call into your C++ lib or DLL here. This example uses AMP.
    float numbers[] = { 1.0, 10.0, 60.0, 100.0, 600.0, 10000.0 };
    array_view<float, 1> logs(6, numbers);

    // See http://msdn.microsoft.com/en-us/library/hh305254.aspx
    parallel_for_each(
        logs.extent,
        [=] (index<1> idx) restrict(amp)
    {
        logs[idx] = concurrency::fast_math::log10(logs[idx]);
    }
    );

    // Return a Windows Runtime-compatible type across the ABI
    auto res = ref new Vector<double>();
    int len = safe_cast<int>(logs.extent.size());
    for(int i = 0; i < len; i++)
    {      
        res->Append(logs[i]);
    }

    // res is implicitly cast to IVector<double>
    return res;
}
```
## <a name="to-add-the-implementation-for-getprimesordered-and-its-helper-method"></a><span data-ttu-id="2dc8b-159">GetPrimesOrdered とそのヘルパー メソッドの実装を追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-159">To add the implementation for GetPrimesOrdered and its helper method</span></span>
<span data-ttu-id="2dc8b-160">Class1.cpp で、GetPrimesOrdered と is_prime ヘルパー メソッドの実装を追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-160">In Class1.cpp, add the implementations for GetPrimesOrdered and the is_prime helper method.</span></span> <span data-ttu-id="2dc8b-161">GetPrimesOrdered は、concurrent_vector クラスと parallel_for 関数ループを使って作業を分割し、プログラムが実行されているコンピューターのリソースを最大限に使って結果を生成します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-161">GetPrimesOrdered uses a concurrent_vector class and a parallel_for function loop to divide up the work and use the maximum resources of the computer on which the program is running to produce results.</span></span> <span data-ttu-id="2dc8b-162">結果の計算、保存、並べ替えが終わると、結果は Platform::Collections::Vector<T> に追加され、Windows::Foundation::Collections::IVector<T> としてクライアント コードに返されます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-162">After the results are computed, stored, and sorted, they are added to a Platform::Collections::Vector<T> and returned as Windows::Foundation::Collections::IVector<T> to client code.</span></span>

<span data-ttu-id="2dc8b-163">進行状況レポーターのコードに注意してください。このコードにより、クライアントは操作の予想される所要時間をユーザーに示す進行状況バーまたは他の UI をフックできます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-163">Notice the code for the progress reporter, which enables the client to hook up a progress bar or other UI to show the user how much longer the operation is going to take.</span></span> <span data-ttu-id="2dc8b-164">進行状況レポートにはコストがかかります。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-164">Progress reporting has a cost.</span></span> <span data-ttu-id="2dc8b-165">イベントはコンポーネント側で発生させ、UI スレッドで処理する必要があります。また、イテレーションごとに進行状況値を保存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-165">An event must be fired on the component side and handled on the UI thread, and the progress value must be stored on each iteration.</span></span> <span data-ttu-id="2dc8b-166">コストを最小限に抑える 1 つの方法として、進行状況イベントの発生頻度を制限します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-166">One way to minimize the cost is by limiting the frequency at which a progress event is fired.</span></span> <span data-ttu-id="2dc8b-167">それでもコストがかかりすぎる場合や、操作の所要時間を推定できない場合は、完了までの残り時間は示さず、操作が進行中であることだけを示すプログレス リングを使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-167">If the cost is still prohibitive, or if you can't estimate the length of the operation, then consider using a progress ring, which shows that an operation is in progress but doesn't show time remaining until completion.</span></span>

```cpp
// Determines whether the input value is prime.
bool Class1::is_prime(int n)
{
    if (n < 2)
        return false;
    for (int i = 2; i < n; ++i)
    {
        if ((n % i) == 0)
            return false;
    }
    return true;
}

// This method computes all primes, orders them, then returns the ordered results.
IAsyncOperationWithProgress<IVector<int>^, double>^ Class1::GetPrimesOrdered(int first, int last)
{
    return create_async([this, first, last]
    (progress_reporter<double> reporter) -> IVector<int>^ {
        // Ensure that the input values are in range.
        if (first < 0 || last < 0) {
            throw ref new InvalidArgumentException();
        }
        // Perform the computation in parallel.
        concurrent_vector<int> primes;
        long operation = 0;
        long range = last - first + 1;
        double lastPercent = 0.0;

        parallel_for(first, last + 1, [this, &primes, &operation,
            range, &lastPercent, reporter](int n) {

                // Increment and store the number of times the parallel
                // loop has been called on all threads combined. There
                // is a performance cost to maintaining a count, and
                // passing the delegate back to the UI thread, but it's
                // necessary if we want to display a determinate progress
                // bar that goes from 0 to 100%. We can avoid the cost by
                // setting the ProgressBar IsDeterminate property to false
                // or by using a ProgressRing.
                if(InterlockedIncrement(&operation) % 100 == 0)
                {
                    reporter.report(100.0 * operation / range);
                }

                // If the value is prime, add it to the local vector.
                if (is_prime(n)) {
                    primes.push_back(n);
                }
        });

        // Sort the results.
        std::sort(begin(primes), end(primes), std::less<int>());        
        reporter.report(100.0);

        // Copy the results to a Vector object, which is
        // implicitly converted to the IVector return type. IVector
        // makes collections of data available to other
        // Windows Runtime components.
        return ref new Vector<int>(primes.begin(), primes.end());
    });
}
```

## <a name="to-add-the-implementation-for-getprimesunordered"></a><span data-ttu-id="2dc8b-168">GetPrimesUnordered の実装を追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-168">To add the implementation for GetPrimesUnordered</span></span>
<span data-ttu-id="2dc8b-169">C++ コンポーネントを作成する最後の手順として、Class1.cpp で GetPrimesUnordered の実装を追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-169">The last step to create the C++ component is to add the implementation for the GetPrimesUnordered in Class1.cpp.</span></span> <span data-ttu-id="2dc8b-170">このメソッドは、すべての結果が見つかるまで待たずに、結果が見つかるたびに各結果を返します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-170">This method returns each result as it is found, without waiting until all results are found.</span></span> <span data-ttu-id="2dc8b-171">各結果はイベント ハンドラー内で返され、UI にリアルタイムで表示されます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-171">Each result is returned in the event handler and displayed on the UI in real time.</span></span> <span data-ttu-id="2dc8b-172">ここでも進行状況レポーターが使われていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-172">Again, notice that a progress reporter is used.</span></span> <span data-ttu-id="2dc8b-173">このメソッドも、is_prime ヘルパー メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-173">This method also uses the is_prime helper method.</span></span>

```cpp
// This method returns no value. Instead, it fires an event each time a
// prime is found, and passes the prime through the event.
// It also passes progress info.
IAsyncActionWithProgress<double>^ Class1::GetPrimesUnordered(int first, int last)
{

    auto window = Windows::UI::Core::CoreWindow::GetForCurrentThread();
    m_dispatcher = window->Dispatcher;


    return create_async([this, first, last](progress_reporter<double> reporter) {

        // Ensure that the input values are in range.
        if (first < 0 || last < 0) {
            throw ref new InvalidArgumentException();
        }

        // In this particular example, we don't actually use this to store
        // results since we pass results one at a time directly back to
        // UI as they are found. However, we have to provide this variable
        // as a parameter to parallel_for.
        concurrent_vector<int> primes;
        long operation = 0;
        long range = last - first + 1;
        double lastPercent = 0.0;

        // Perform the computation in parallel.
        parallel_for(first, last + 1,
            [this, &primes, &operation, range, &lastPercent, reporter](int n)
        {
            // Store the number of times the parallel loop has been called  
            // on all threads combined. See comment in previous method.
            if(InterlockedIncrement(&operation) % 100 == 0)
            {
                reporter.report(100.0 * operation / range);
            }

            // If the value is prime, pass it immediately to the UI thread.
            if (is_prime(n))
            {                
                // Since this code is probably running on a worker
                // thread, and we are passing the data back to the
                // UI thread, we have to use a CoreDispatcher object.
                m_dispatcher->RunAsync( CoreDispatcherPriority::Normal,
                    ref new DispatchedHandler([this, n, operation, range]()
                {
                    this->primeFoundEvent(n);

                }, Platform::CallbackContext::Any));

            }
        });
        reporter.report(100.0);
    });
}
```

## <a name="creating-a-javascript-client-app"></a><span data-ttu-id="2dc8b-174">JavaScript クライアント アプリケーションの作成</span><span class="sxs-lookup"><span data-stu-id="2dc8b-174">Creating a JavaScript client app</span></span>
<span data-ttu-id="2dc8b-175">C# クライアントだけを作成する場合は、このセクションをスキップして構いません。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-175">If you just want to create a C# client, you can skip this section.</span></span>

## <a name="to-create-a-javascript-project"></a><span data-ttu-id="2dc8b-176">JavaScript プロジェクトを作成するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-176">To create a JavaScript project</span></span>
<span data-ttu-id="2dc8b-177">ソリューション エクスプローラーで、[ソリューション] ノードのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-177">In Solution Explorer, open the shortcut menu for the Solution node and choose **Add, New Project**.</span></span>

<span data-ttu-id="2dc8b-178">[JavaScript] (**[他の言語]** の下に入れ子になっていることがあります) を展開し、**[空白のアプリ (ユニバーサル Windows)]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-178">Expand JavaScript (it might be nested under **Other Languages**) and choose **Blank App (Universal Windows)**.</span></span>

<span data-ttu-id="2dc8b-179">**[OK]** をクリックして、既定の名前 (App1) を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-179">Accept the default name—App1—by choosing the **OK** button.</span></span>

<span data-ttu-id="2dc8b-180">App1 プロジェクト ノードのショートカット メニューを開き、**[スタートアップ プロジェクトに設定]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-180">Open the shortcut menu for the App1 project node and choose **Set as Startup Project**.</span></span>

<span data-ttu-id="2dc8b-181">WinRT_CPP へのプロジェクト参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-181">Add a project reference to WinRT_CPP:</span></span>

<span data-ttu-id="2dc8b-182">[参照] ノードのショートカット メニューを開き、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-182">Open the shortcut menu for the References node and choose **Add Reference**.</span></span>

<span data-ttu-id="2dc8b-183">[参照マネージャー] ダイアログ ボックスの左ペインで、**[プロジェクト]** をクリックし、**[ソリューション]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-183">In the left pane of the References Manager dialog box, select **Projects** and then select **Solution**.</span></span>

<span data-ttu-id="2dc8b-184">中央ペインで [WinRT_CPP] を選択し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-184">In the center pane, select WinRT_CPP and then choose the **OK** button</span></span>

## <a name="to-add-the-html-that-invokes-the-javascript-event-handlers"></a><span data-ttu-id="2dc8b-185">JavaScript イベント ハンドラーを呼び出す HTML を追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-185">To add the HTML that invokes the JavaScript event handlers</span></span>
<span data-ttu-id="2dc8b-186">default.html ページの <body> ノードに、次の HTML を貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-186">Paste this HTML into the <body> node of the default.html page:</span></span>

```HTML
<div id="LogButtonDiv">
     <button id="logButton">Logarithms using AMP</button>
 </div>
 <div id="LogResultDiv">
     <p id="logResult"></p>
 </div>
 <div id="OrderedPrimeButtonDiv">
     <button id="orderedPrimeButton">Primes using parallel_for with sort</button>
 </div>
 <div id="OrderedPrimeProgress">
     <progress id="OrderedPrimesProgressBar" value="0" max="100"></progress>
 </div>
 <div id="OrderedPrimeResultDiv">
     <p id="orderedPrimes">
         Primes found (ordered):
     </p>
 </div>
 <div id="UnorderedPrimeButtonDiv">
     <button id="ButtonUnordered">Primes returned as they are produced.</button>
 </div>
 <div id="UnorderedPrimeDiv">
     <progress id="UnorderedPrimesProgressBar" value="0" max="100"></progress>
 </div>
 <div id="UnorderedPrime">
     <p id="unorderedPrimes">
         Primes found (unordered):
     </p>
 </div>
 <div id="ClearDiv">
     <button id="Button_Clear">Clear</button>
 </div>
```

## <a name="to-add-styles"></a><span data-ttu-id="2dc8b-187">スタイルを追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-187">To add styles</span></span>
<span data-ttu-id="2dc8b-188">default.css で body スタイルを削除し、次のスタイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-188">In default.css, remove the body style and then add these styles:</span></span>

```css
#LogButtonDiv {
border: orange solid 1px;
-ms-grid-row: 1; /* default is 1 */
-ms-grid-column: 1; /* default is 1 */
}
#LogResultDiv {
background: black;
border: red solid 1px;
-ms-grid-row: 1;
-ms-grid-column: 2;
}
#UnorderedPrimeButtonDiv, #OrderedPrimeButtonDiv {
border: orange solid 1px;
-ms-grid-row: 2;   
-ms-grid-column:1;
}
#UnorderedPrimeProgress, #OrderedPrimeProgress {
border: red solid 1px;
-ms-grid-column-span: 2;
height: 40px;
}
#UnorderedPrimeResult, #OrderedPrimeResult {
border: red solid 1px;
font-size:smaller;
-ms-grid-row: 2;
-ms-grid-column: 3;
-ms-overflow-style:scrollbar;
}
```

## <a name="to-add-the-javascript-event-handlers-that-call-into-the-component-dll"></a><span data-ttu-id="2dc8b-189">コンポーネント DLL を呼び出す JavaScript イベント ハンドラーを追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-189">To add the JavaScript event handlers that call into the component DLL</span></span>
<span data-ttu-id="2dc8b-190">default.js ファイルの末尾に次の関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-190">Add the following functions at the end of the default.js file.</span></span> <span data-ttu-id="2dc8b-191">これらの関数は、メイン ページのボタンが選択されたときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-191">These functions are called when the buttons on the main page are chosen.</span></span> <span data-ttu-id="2dc8b-192">JavaScript が C++ クラスをアクティブにして、そのメソッドを呼び出し、戻り値を使って HTML ラベルを設定する手順に注目してください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-192">Notice how JavaScript activates the C++ class, and then calls its methods and uses the return values to populate the HTML labels.</span></span>

```JavaScript
var nativeObject = new WinRT_CPP.Class1();

function LogButton_Click() {

    var val = nativeObject.computeResult(0);
    var result = "";

    for (i = 0; i < val.length; i++) {
        result += val[i] + "<br/>";
    }

    document.getElementById('logResult').innerHTML = result;
}

function ButtonOrdered_Click() {
    document.getElementById('orderedPrimes').innerHTML = "Primes found (ordered): ";

    nativeObject.getPrimesOrdered(2, 10000).then(
        function (v) {
            for (var i = 0; i < v.length; i++)
                document.getElementById('orderedPrimes').innerHTML += v[i] + " ";
        },
        function (error) {
            document.getElementById('orderedPrimes').innerHTML += " " + error.description;
        },
        function (p) {
            var progressBar = document.getElementById("OrderedPrimesProgressBar");
            progressBar.value = p;
        });
}

function ButtonUnordered_Click() {
    document.getElementById('unorderedPrimes').innerHTML = "Primes found (unordered): ";
    nativeObject.onprimefoundevent = handler_unordered;

    nativeObject.getPrimesUnordered(2, 10000).then(
        function () { },
        function (error) {
            document.getElementById("unorderedPrimes").innerHTML += " " + error.description;
        },
        function (p) {
            var progressBar = document.getElementById("UnorderedPrimesProgressBar");
            progressBar.value = p;
        });
}

var handler_unordered = function (n) {
    document.getElementById('unorderedPrimes').innerHTML += n.target.toString() + " ";
};

function ButtonClear_Click() {

    document.getElementById('logResult').innerHTML = "";
    document.getElementById("unorderedPrimes").innerHTML = "";
    document.getElementById('orderedPrimes').innerHTML = "";
    document.getElementById("UnorderedPrimesProgressBar").value = 0;
    document.getElementById("OrderedPrimesProgressBar").value = 0;
}
```

<span data-ttu-id="2dc8b-193">default.js 内の app.onactivated での WinJS.UI.processAll の既存の呼び出しを、then ブロックでイベント登録を実装する次のコードに置き換えて、イベント リスナーを追加するコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-193">Add code to add the event listeners by replacing the existing call to WinJS.UI.processAll in app.onactivated in default.js with the following code that implements event registration in a then block.</span></span> <span data-ttu-id="2dc8b-194">詳しくは、「"Hello, world" アプリを作成する (JS)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-194">For a detailed explanation of this, see Create a "Hello World" app (JS).</span></span>

```JavaScript
args.setPromise(WinJS.UI.processAll().then( function completed() {
    var logButton = document.getElementById("logButton");
    logButton.addEventListener("click", LogButton_Click, false);
    var orderedPrimeButton = document.getElementById("orderedPrimeButton");
    orderedPrimeButton.addEventListener("click", ButtonOrdered_Click, false);
    var buttonUnordered = document.getElementById("ButtonUnordered");
    buttonUnordered.addEventListener("click", ButtonUnordered_Click, false);
    var buttonClear = document.getElementById("Button_Clear");
    buttonClear.addEventListener("click", ButtonClear_Click, false);
}));
```

<span data-ttu-id="2dc8b-195">F5 キーを押してアプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-195">Press F5 to run the app.</span></span>

## <a name="creating-a-c-client-app"></a><span data-ttu-id="2dc8b-196">C# クライアント アプリケーションの作成</span><span class="sxs-lookup"><span data-stu-id="2dc8b-196">Creating a C# client app</span></span>

## <a name="to-create-a-c-project"></a><span data-ttu-id="2dc8b-197">C# プロジェクトを作成するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-197">To create a C# project</span></span>
<span data-ttu-id="2dc8b-198">ソリューション エクスプローラーで、[ソリューション] ノードのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-198">In Solution Explorer, open the shortcut menu for the Solution node and then choose **Add, New Project**.</span></span>

<span data-ttu-id="2dc8b-199">[Visual C#] (**[他の言語]** の下に入れ子になっていることがあります) を展開し、**[Windows]** をクリックします。左ペインで **[ユニバーサル]** をクリックし、中央ペインで **[空のアプリケーション]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-199">Expand Visual C# (it might be nested under **Other Languages**), select **Windows** and then **Universal** in the left pane, and then select **Blank App** in the middle pane.</span></span>

<span data-ttu-id="2dc8b-200">このアプリケーションに CS_Client という名前を付け、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-200">Name this app CS_Client and then choose the **OK** button.</span></span>

<span data-ttu-id="2dc8b-201">CS_Client プロジェクト ノードのショートカット メニューを開き、**[スタートアップ プロジェクトに設定]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-201">Open the shortcut menu for the CS_Client project node and choose **Set as Startup Project**.</span></span>

<span data-ttu-id="2dc8b-202">WinRT_CPP へのプロジェクト参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-202">Add a project reference to WinRT_CPP:</span></span>

<span data-ttu-id="2dc8b-203">**[参照]** ノードのショートカット メニューを開き、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-203">Open the shortcut menu for the **References** node and choose **Add Reference**.</span></span>

<span data-ttu-id="2dc8b-204">**[参照マネージャー]** ダイアログ ボックスの左ペインで、**[プロジェクト]** をクリックし、**[ソリューション]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-204">In the left pane of the **References Manager** dialog box, select **Projects** and then select **Solution**.</span></span>

<span data-ttu-id="2dc8b-205">中央ペインで [WinRT_CPP] を選択し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-205">In the center pane, select WinRT_CPP and then choose the **OK** button.</span></span>

## <a name="to-add-the-xaml-that-defines-the-user-interface"></a><span data-ttu-id="2dc8b-206">ユーザー インターフェイスを定義する XAML を追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-206">To add the XAML that defines the user interface</span></span>
<span data-ttu-id="2dc8b-207">MainPage.xaml 内の Grid 要素に次のコードをコピーします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-207">Copy the following code into the Grid element in MainPage.xaml.</span></span>

```xaml
<ScrollViewer>
            <StackPanel Width="1400">

                <Button x:Name="Button1" Width="340" Height="50"  Margin="0,20,20,20" Content="Synchronous Logarithm Calculation" FontSize="16" Click="Button1_Click_1"/>
                <TextBlock x:Name="Result1" Height="100" FontSize="14"></TextBlock>
            <Button x:Name="PrimesOrderedButton" Content="Prime Numbers Ordered" FontSize="16" Width="340" Height="50" Margin="0,20,20,20" Click="PrimesOrderedButton_Click_1"></Button>
            <ProgressBar x:Name="PrimesOrderedProgress" IsIndeterminate="false" Height="40"></ProgressBar>
                <TextBlock x:Name="PrimesOrderedResult" MinHeight="100" FontSize="10" TextWrapping="Wrap"></TextBlock>
            <Button x:Name="PrimesUnOrderedButton" Width="340" Height="50" Margin="0,20,20,20" Click="PrimesUnOrderedButton_Click_1" Content="Prime Numbers Unordered" FontSize="16"></Button>
            <ProgressBar x:Name="PrimesUnOrderedProgress" IsIndeterminate="false" Height="40" ></ProgressBar>
            <TextBlock x:Name="PrimesUnOrderedResult" MinHeight="100" FontSize="10" TextWrapping="Wrap"></TextBlock>

            <Button x:Name="Clear_Button" Content="Clear" HorizontalAlignment="Left" Margin="0,20,20,20" VerticalAlignment="Top" Width="341" Click="Clear_Button_Click" FontSize="16"/>
        </StackPanel>
</ScrollViewer>
```

## <a name="to-add-the-event-handlers-for-the-buttons"></a><span data-ttu-id="2dc8b-208">ボタンのイベント ハンドラーを追加するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-208">To add the event handlers for the buttons</span></span>
<span data-ttu-id="2dc8b-209">ソリューション エクスプローラーで、MainPage.xaml.cs を開きます </span><span class="sxs-lookup"><span data-stu-id="2dc8b-209">In Solution Explorer, open MainPage.xaml.cs.</span></span> <span data-ttu-id="2dc8b-210">(このファイルは MainPage.xaml の下に入れ子になっていることがあります)。System.Text の using ディレクティブを追加し、MainPage クラスに対数計算用のイベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-210">(The file might be nested under MainPage.xaml.) Add a using directive for System.Text, and then add the event handler for the Logarithm calculation in the MainPage class.</span></span>

```csharp
private void Button1_Click_1(object sender, RoutedEventArgs e)
{
    // Create the object
    var nativeObject = new WinRT_CPP.Class1();

    // Call the synchronous method. val is an IList that
    // contains the results.
    var val = nativeObject.ComputeResult(0);
    StringBuilder result = new StringBuilder();
    foreach (var v in val)
    {
        result.Append(v).Append(System.Environment.NewLine);
    }
    this.Result1.Text = result.ToString();
}
```

<span data-ttu-id="2dc8b-211">順序付けされた結果のイベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-211">Add the event handler for the ordered result:</span></span>

```csharp
async private void PrimesOrderedButton_Click_1(object sender, RoutedEventArgs e)
{
    var nativeObject = new WinRT_CPP.Class1();

    StringBuilder sb = new StringBuilder();
    sb.Append("Primes found (ordered): ");

    PrimesOrderedResult.Text = sb.ToString();

    // Call the asynchronous method
    var asyncOp = nativeObject.GetPrimesOrdered(2, 100000);

    // Before awaiting, provide a lambda or named method
    // to handle the Progress event that is fired at regular
    // intervals by the asyncOp object. This handler updates
    // the progress bar in the UI.
    asyncOp.Progress = (asyncInfo, progress) =>
        {
            PrimesOrderedProgress.Value = progress;
        };

    // Wait for the operation to complete
    var asyncResult = await asyncOp;

    // Convert the results to strings
    foreach (var result in asyncResult)
    {
        sb.Append(result).Append(" ");
    }

    // Display the results
    PrimesOrderedResult.Text = sb.ToString();
}
```

<span data-ttu-id="2dc8b-212">順序付けされていない結果のイベント ハンドラーと、コードを再度実行できるように結果をクリアするボタンのイベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-212">Add the event handler for the unordered result, and for the button that clears the results so that you can run the code again.</span></span>

```csharp
private void PrimesUnOrderedButton_Click_1(object sender, RoutedEventArgs e)
{
    var nativeObject = new WinRT_CPP.Class1();

    StringBuilder sb = new StringBuilder();
    sb.Append("Primes found (unordered): ");
    PrimesUnOrderedResult.Text = sb.ToString();

    // primeFoundEvent is a user-defined event in nativeObject
    // It passes the results back to this thread as they are produced
    // and the event handler that we define here immediately displays them.
    nativeObject.primeFoundEvent += (n) =>
    {
        sb.Append(n.ToString()).Append(" ");
        PrimesUnOrderedResult.Text = sb.ToString();
    };

    // Call the async method.
    var asyncResult = nativeObject.GetPrimesUnordered(2, 100000);

    // Provide a handler for the Progress event that the asyncResult
    // object fires at regular intervals. This handler updates the progress bar.
    asyncResult.Progress += (asyncInfo, progress) =>
        {
            PrimesUnOrderedProgress.Value = progress;
        };
}

private void Clear_Button_Click(object sender, RoutedEventArgs e)
{
    PrimesOrderedProgress.Value = 0;
    PrimesUnOrderedProgress.Value = 0;
    PrimesUnOrderedResult.Text = "";
    PrimesOrderedResult.Text = "";
    Result1.Text = "";
}
```

## <a name="running-the-app"></a><span data-ttu-id="2dc8b-213">アプリの実行</span><span class="sxs-lookup"><span data-stu-id="2dc8b-213">Running the app</span></span>
<span data-ttu-id="2dc8b-214">ソリューション エクスプローラーでプロジェクト ノードのショートカット メニューを開き、**[スタートアップ プロジェクトに設定]** をクリックして、C# プロジェクトまたは JavaScript プロジェクトをスタートアップ プロジェクトとして選択します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-214">Select either the C# project or JavaScript project as the startup project by opening the shortcut menu for the project node in Solution Explorer and choosing **Set As Startup Project**.</span></span> <span data-ttu-id="2dc8b-215">デバッグして実行する場合は、F5 キーを押します。デバッグせずに実行する場合は、Ctrl キーを押しながら F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-215">Then press F5 to run with debugging, or Ctrl+F5 to run without debugging.</span></span>

## <a name="inspecting-your-component-in-object-browser-optional"></a><span data-ttu-id="2dc8b-216">オブジェクト ブラウザーでのコンポーネントの検査 (省略可能)</span><span class="sxs-lookup"><span data-stu-id="2dc8b-216">Inspecting your component in Object Browser (optional)</span></span>
<span data-ttu-id="2dc8b-217">オブジェクト ブラウザーで、.winmd ファイルで定義されているすべての Windows ランタイム型を検査できます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-217">In Object Browser, you can inspect all Windows Runtime types that are defined in .winmd files.</span></span> <span data-ttu-id="2dc8b-218">これには、Platform 名前空間と既定の名前空間の型が含まれます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-218">This includes the types in the Platform namespace and the default namespace.</span></span> <span data-ttu-id="2dc8b-219">ただし、Platform::Collections 名前空間の型は、winmd ファイルではなく、collections.h ヘッダー ファイルで定義されているため、オブジェクト ブラウザーでは表示されません。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-219">However, because the types in the Platform::Collections namespace are defined in the header file collections.h, not in a winmd file, they don’t appear in Object Browser.</span></span>

## **<a name="to-inspect-a-component"></a><span data-ttu-id="2dc8b-220">コンポーネントを検査するには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-220">To inspect a component</span></span>**
<span data-ttu-id="2dc8b-221">メニュー バーで、**[表示]、[オブジェクト ブラウザー]** の順にクリックします (または、Ctrl + Alt + J キーを押します)。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-221">On the menu bar, choose **View, Object Browser** (Ctrl+Alt+J).</span></span>

<span data-ttu-id="2dc8b-222">オブジェクト ブラウザーの左ペインで、[WinRT\_CPP] ノードを展開して、コンポーネントで定義されている型とメソッドを表示します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-222">In the left pane of the Object Browser, expand the WinRT\_CPP node to show the types and methods that are defined on your component.</span></span>

## <a name="debugging-tips"></a><span data-ttu-id="2dc8b-223">デバッグのヒント</span><span class="sxs-lookup"><span data-stu-id="2dc8b-223">Debugging tips</span></span>
<span data-ttu-id="2dc8b-224">デバッグ操作を向上させるには、パブリックな Microsoft シンボル サーバーからデバッグ シンボルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-224">For a better debugging experience, download the debugging symbols from the public Microsoft symbol servers:</span></span>

## **<a name="to-download-debugging-symbols"></a><span data-ttu-id="2dc8b-225">デバッグ シンボルをダウンロードするには</span><span class="sxs-lookup"><span data-stu-id="2dc8b-225">To download debugging symbols</span></span>**
<span data-ttu-id="2dc8b-226">メニュー バーで、**[ツール]、[オプション]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-226">On the menu bar, choose **Tools, Options**.</span></span>

<span data-ttu-id="2dc8b-227">**[オプション]** ダイアログ ボックスで、**[デバッグ]** を展開し、**[シンボル]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-227">In the **Options** dialog box, expand **Debugging** and select **Symbols**.</span></span>

<span data-ttu-id="2dc8b-228">**[Microsoft シンボル サーバー]** を選択し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-228">Select **Microsoft Symbol Servers** and the choose the **OK** button.</span></span>

<span data-ttu-id="2dc8b-229">シンボルを初めてダウンロードするときは時間がかかる場合があります。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-229">It might take some time to download the symbols the first time.</span></span> <span data-ttu-id="2dc8b-230">次回 F5 キーを押したときのパフォーマンスを向上させるには、シンボルをキャッシュするローカル ディレクトリを指定します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-230">For faster performance the next time you press F5, specify a local directory in which to cache the symbols.</span></span>

<span data-ttu-id="2dc8b-231">コンポーネント DLL を含む JavaScript ソリューションをデバッグするときは、コンポーネントでスクリプトのステップ実行またはネイティブ コードのステップ実行を有効にするようにデバッガーを設定できますが、この両方を同時に有効にすることはできません。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-231">When you debug a JavaScript solution that has a component DLL, you can set the debugger to enable either stepping through script or stepping through native code in the component, but not both at the same time.</span></span> <span data-ttu-id="2dc8b-232">設定を変更するには、ソリューション エクスプローラーで JavaScript プロジェクト ノードのショートカット メニューを開き、**[プロパティ]、[デバッグ]、[デバッガーの種類]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-232">To change the setting, open the shortcut menu for the JavaScript project node in Solution Explorer and choose **Properties, Debugging, Debugger Type**.</span></span>

<span data-ttu-id="2dc8b-233">パッケージ デザイナーで必ず適切な機能を選択してください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-233">Be sure to select appropriate capabilities in the package designer.</span></span> <span data-ttu-id="2dc8b-234">パッケージ デザイナーを開くには、Package.appxmanifest ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-234">You can open the package designer by opening the Package.appxmanifest file.</span></span> <span data-ttu-id="2dc8b-235">たとえば、プログラムを使ってピクチャ フォルダーのファイルにアクセスする場合は、パッケージ デザイナーの **[機能]** ペインで **[画像ライブラリ]** チェック ボックスをオンにしてください。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-235">For example, if you are attempting to programmatically access files in the Pictures folder, be sure to select the **Pictures Library** check box in the **Capabilities** pane of the package designer.</span></span>

<span data-ttu-id="2dc8b-236">JavaScript コードがコンポーネントのパブリック プロパティまたはパブリック メソッドを認識しない場合は、JavaScript で camel 規約を使っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-236">If your JavaScript code doesn't recognize the public properties or methods in the component, make sure that in JavaScript you are using camel casing.</span></span> <span data-ttu-id="2dc8b-237">たとえば、`ComputeResult` C++ メソッドは、JavaScript で `computeResult` として参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-237">For example, the `ComputeResult` C++ method must be referenced as `computeResult` in JavaScript.</span></span>

<span data-ttu-id="2dc8b-238">C++ Windows ランタイム コンポーネント プロジェクトをソリューションから削除する場合、JavaScript プロジェクトからプロジェクト参照も手動で削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-238">If you remove a C++ Windows Runtime Component project from a solution, you must also manually remove the project reference from the JavaScript project.</span></span> <span data-ttu-id="2dc8b-239">これを行わないと、後続のデバッグまたはビルド操作が妨げられます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-239">Failure to do so prevents subsequent debug or build operations.</span></span> <span data-ttu-id="2dc8b-240">その後、必要に応じてアセンブリ参照を DLL に追加できます。</span><span class="sxs-lookup"><span data-stu-id="2dc8b-240">If necessary, you can then add an assembly reference to the DLL.</span></span>

## <a name="related-topics"></a><span data-ttu-id="2dc8b-241">関連トピック</span><span class="sxs-lookup"><span data-stu-id="2dc8b-241">Related topics</span></span>
* [<span data-ttu-id="2dc8b-242">C++/CX での Windows ランタイム コンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="2dc8b-242">Creating Windows Runtime Components in C++/CX</span></span>](creating-windows-runtime-components-in-cpp.md)
