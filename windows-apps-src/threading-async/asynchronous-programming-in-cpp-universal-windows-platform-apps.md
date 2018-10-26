---
author: normesta
ms.assetid: 34C00F9F-2196-46A3-A32F-0067AB48291B
description: この記事では VisualC コンポーネント拡張機能での非同期メソッドに推奨される方法について説明します。 (、C++/cli CX) ppltasks.h の concurrency 名前空間で定義された task クラスを使用しています。
title: C++ での非同期プログラミング
ms.author: normesta
ms.date: 05/14/2018
ms.topic: article
keywords: Windows 10、UWP、スレッド、非同期、C++
ms.localizationpriority: medium
ms.openlocfilehash: 33b110e713608260cd5c19544292e9211904a730
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5638973"
---
# <a name="asynchronous-programming-in-ccx"></a><span data-ttu-id="85cac-104">C++/CX での非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="85cac-104">Asynchronous programming in C++/CX</span></span>
> [!NOTE]
> <span data-ttu-id="85cac-105">このトピックは、C++/CX アプリケーションの管理ができるようにすることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="85cac-105">This topic exists to help you maintain your C++/CX application.</span></span> <span data-ttu-id="85cac-106">ただし、新しいアプリケーションには [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85cac-106">But we recommend that you use [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) for new applications.</span></span> <span data-ttu-id="85cac-107">C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="85cac-107">C++/WinRT is an entirely standard modern C++17 language projection for Windows Runtime (WinRT) APIs, implemented as a header-file-based library, and designed to provide you with first-class access to the modern Windows API.</span></span>

<span data-ttu-id="85cac-108">この記事では VisualC コンポーネント拡張機能での非同期メソッドに推奨される方法について説明します。 (、C++/cli CX) を使用して、`task`クラスで定義されている、 `concurrency` ppltasks.h で名前空間です。</span><span class="sxs-lookup"><span data-stu-id="85cac-108">This article describes the recommended way to consume asynchronous methods in VisualC++ component extensions (C++/CX) by using the `task` class that's defined in the `concurrency` namespace in ppltasks.h.</span></span>

## <a name="universal-windows-platform-uwp-asynchronous-types"></a><span data-ttu-id="85cac-109">ユニバーサル Windows プラットフォーム (UWP) の非同期型</span><span class="sxs-lookup"><span data-stu-id="85cac-109">Universal Windows Platform (UWP) asynchronous types</span></span>
<span data-ttu-id="85cac-110">ユニバーサル Windows プラットフォーム (UWP) には、非同期メソッドを呼び出すためのモデルが明確に定義されており、非同期メソッドを使う必要がある型があります。</span><span class="sxs-lookup"><span data-stu-id="85cac-110">The Universal Windows Platform (UWP) features a well-defined model for calling asynchronous methods and provides the types that you need to consume such methods.</span></span> <span data-ttu-id="85cac-111">UWP の非同期モデルについて詳しくない場合は、この記事の前に「[非同期プログラミング][AsyncProgramming]」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85cac-111">If you are not familiar with the UWP asynchronous model, read [Asynchronous Programming][AsyncProgramming] before you read the rest of this article.</span></span>

<span data-ttu-id="85cac-112">非同期 UWP API は C++ で直接使うこともできますが、[**task class**][task-class] とそれに関連する型と関数を使うことをお勧めします。これは [**concurrency**][concurrencyNamespace] 名前空間のクラスで、`<ppltasks.h>` で定義されています。</span><span class="sxs-lookup"><span data-stu-id="85cac-112">Although you can consume the asynchronous UWP APIs directly in C++, the preferred approach is to use the [**task class**][task-class] and its related types and functions, which are contained in the [**concurrency**][concurrencyNamespace] namespace and defined in `<ppltasks.h>`.</span></span> <span data-ttu-id="85cac-113">**concurrency::task** は汎用型のクラスですが、**/ZW** コンパイラ スイッチ (ユニバーサル Windows プラットフォーム (UWP) アプリとそのコンポーネントには必須) を使うと、task クラスで UWP の非同期型をカプセル化して次の処理を簡単に行うことができます。</span><span class="sxs-lookup"><span data-stu-id="85cac-113">The **concurrency::task** is a general-purpose type, but when the **/ZW** compiler switch—which is required for Universal Windows Platform (UWP) apps and components—is used, the task class encapsulates the UWP asynchronous types so that it's easier to:</span></span>

-   <span data-ttu-id="85cac-114">複数の非同期操作や同期操作を 1 つのチェーンで連結する</span><span class="sxs-lookup"><span data-stu-id="85cac-114">chain multiple asynchronous and synchronous operations together</span></span>

-   <span data-ttu-id="85cac-115">タスク チェーンで例外を処理する</span><span class="sxs-lookup"><span data-stu-id="85cac-115">handle exceptions in task chains</span></span>

-   <span data-ttu-id="85cac-116">タスク チェーンで取り消しを実行する</span><span class="sxs-lookup"><span data-stu-id="85cac-116">perform cancellation in task chains</span></span>

-   <span data-ttu-id="85cac-117">各タスクを適切なスレッド コンテキストまたはスレッド アパートメントで実行する</span><span class="sxs-lookup"><span data-stu-id="85cac-117">ensure that individual tasks run in the appropriate thread context or apartment</span></span>

<span data-ttu-id="85cac-118">ここでは、**task** クラスを UWP の非同期 API で使う方法に関する基本的なガイダンスを示しています。</span><span class="sxs-lookup"><span data-stu-id="85cac-118">This article provides basic guidance about how to use the **task** class with the UWP asynchronous APIs.</span></span> <span data-ttu-id="85cac-119">**task** クラスと、[**create\_task**][createTask] を含む関連メソッドの詳細については、[タスクの並列処理 (同時実行ランタイム)][taskParallelism] を参照してください。</span><span class="sxs-lookup"><span data-stu-id="85cac-119">For more complete documentation about **task** and its related methods including [**create\_task**][createTask], see [Task Parallelism (Concurrency Runtime)][taskParallelism].</span></span> 

## <a name="consuming-an-async-operation-by-using-a-task"></a><span data-ttu-id="85cac-120">タスクを使った非同期操作の使用</span><span class="sxs-lookup"><span data-stu-id="85cac-120">Consuming an async operation by using a task</span></span>
<span data-ttu-id="85cac-121">次の例は、task クラスを使って、[**IAsyncOperation**][IAsyncOperation] インターフェイスを返す **async** メソッドを使う方法を示しています。この操作では値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-121">The following example shows how to use the task class to consume an **async** method that returns an [**IAsyncOperation**][IAsyncOperation] interface and whose operation produces a value.</span></span> <span data-ttu-id="85cac-122">基本的な手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="85cac-122">Here are the basic steps:</span></span>

1.  <span data-ttu-id="85cac-123">`create_task` メソッドを呼び出し、**IAsyncOperation** オブジェクトに渡します。</span><span class="sxs-lookup"><span data-stu-id="85cac-123">Call the `create_task` method and pass it the **IAsyncOperation^** object.</span></span>

2.  <span data-ttu-id="85cac-124">タスクのメンバー関数 [**task::then**][taskThen] を呼び出し、非同期操作の完了時に呼び出すラムダを指定します。</span><span class="sxs-lookup"><span data-stu-id="85cac-124">Call the member function [**task::then**][taskThen] on the task and supply a lambda that will be invoked when the asynchronous operation completes.</span></span>

``` cpp
#include <ppltasks.h>
using namespace concurrency;
using namespace Windows::Devices::Enumeration;
...
void App::TestAsync()
{    
    //Call the *Async method that starts the operation.
    IAsyncOperation<DeviceInformationCollection^>^ deviceOp =
        DeviceInformation::FindAllAsync();

    // Explicit construction. (Not recommended)
    // Pass the IAsyncOperation to a task constructor.
    // task<DeviceInformationCollection^> deviceEnumTask(deviceOp);

    // Recommended:
    auto deviceEnumTask = create_task(deviceOp);

    // Call the task's .then member function, and provide
    // the lambda to be invoked when the async operation completes.
    deviceEnumTask.then( [this] (DeviceInformationCollection^ devices )
    {       
        for(int i = 0; i < devices->Size; i++)
        {
            DeviceInformation^ di = devices->GetAt(i);
            // Do something with di...          
        }       
    }); // end lambda
    // Continue doing work or return...
}
```

<span data-ttu-id="85cac-125">[**task::then**][taskThen] 関数で作成されて返されるタスクのことを*後続タスク*と呼びます。</span><span class="sxs-lookup"><span data-stu-id="85cac-125">The task that's created and returned by the [**task::then**][taskThen] function is known as a *continuation*.</span></span> <span data-ttu-id="85cac-126">ユーザーが指定するラムダの入力引数は (この例の場合)、タスク操作の完了時に生成される結果です。</span><span class="sxs-lookup"><span data-stu-id="85cac-126">The input argument (in this case) to the user-provided lambda is the result that the task operation produces when it completes.</span></span> <span data-ttu-id="85cac-127">この値は、**IAsyncOperation** インターフェイスを直接使う場合に [**IAsyncOperation::GetResults**](https://msdn.microsoft.com/library/windows/apps/br206600) を呼び出して取得する値と同じになります。</span><span class="sxs-lookup"><span data-stu-id="85cac-127">It's the same value that would be retrieved by calling [**IAsyncOperation::GetResults**](https://msdn.microsoft.com/library/windows/apps/br206600) if you were using the **IAsyncOperation** interface directly.</span></span>

<span data-ttu-id="85cac-128">[**task::then**][taskThen] メソッドからは直ちに制御が返され、そのデリゲートは非同期作業が正常に完了するまで実行されません。</span><span class="sxs-lookup"><span data-stu-id="85cac-128">The [**task::then**][taskThen] method returns immediately, and its delegate doesn't run until the asynchronous work completes successfully.</span></span> <span data-ttu-id="85cac-129">この例では、非同期操作で例外がスローされるか、取り消し要求によって非同期操作が取り消された状態で終わると、継続は実行されません。</span><span class="sxs-lookup"><span data-stu-id="85cac-129">In this example, if the asynchronous operation causes an exception to be thrown, or ends in the canceled state as a result of a cancellation request, the continuation will never execute.</span></span> <span data-ttu-id="85cac-130">前のタスクが取り消されるか失敗しても実行される継続を記述する方法については後で説明します。</span><span class="sxs-lookup"><span data-stu-id="85cac-130">Later, we’ll describe how to write continuations that execute even if the previous task was cancelled or failed.</span></span>

<span data-ttu-id="85cac-131">タスクの変数はローカル スタックで宣言しますが、その有効期間は、操作が完了する前にメソッドから制御が返されても、すべての操作が完了してすべての参照がスコープ外になるまで削除されないように管理されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-131">Although you declare the task variable on the local stack, it manages its lifetime so that it is not deleted until all of its operations complete and all references to it go out of scope, even if the method returns before the operations complete.</span></span>

## <a name="creating-a-chain-of-tasks"></a><span data-ttu-id="85cac-132">タスクのチェーンの作成</span><span class="sxs-lookup"><span data-stu-id="85cac-132">Creating a chain of tasks</span></span>
<span data-ttu-id="85cac-133">非同期プログラミングでは、前のタスクが完了した場合にのみ継続が実行されるように、操作のシーケンス (*タスク チェーン*) を定義するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="85cac-133">In asynchronous programming, it's common to define a sequence of operations, also known as *task chains*, in which each continuation executes only when the previous one completes.</span></span> <span data-ttu-id="85cac-134">場合によっては、前のタスク (*先行タスク*) で生成された値を後続タスクが入力として受け取ることもあります。</span><span class="sxs-lookup"><span data-stu-id="85cac-134">In some cases, the previous (or *antecedent*) task produces a value that the continuation accepts as input.</span></span> <span data-ttu-id="85cac-135">[**task::then**][taskThen] メソッドを使うと、直観的な方法で簡単にタスク チェーンを作成できます。このメソッドは、**task<T>** (**T** はラムダ関数の戻り値の型) を返します。</span><span class="sxs-lookup"><span data-stu-id="85cac-135">By using the [**task::then**][taskThen] method, you can create task chains in an intuitive and straightforward manner; the method returns a **task<T>** where **T** is the return type of the lambda function.</span></span> <span data-ttu-id="85cac-136">複数の継続を含めて 1 つのタスク チェーンを構成することができます。</span><span class="sxs-lookup"><span data-stu-id="85cac-136">You can compose multiple continuations into a task chain:</span></span> `myTask.then(…).then(…).then(…);`

<span data-ttu-id="85cac-137">タスク チェーンは、継続で新しい非同期操作を作成する場合に特に便利です。このようなタスクのことを非同期タスクと呼びます。</span><span class="sxs-lookup"><span data-stu-id="85cac-137">Task chains are especially useful when a continuation creates a new asynchronous operation; such a task is known as an asynchronous task.</span></span> <span data-ttu-id="85cac-138">次の例は、2 つの継続を含むタスク チェーンを示しています。</span><span class="sxs-lookup"><span data-stu-id="85cac-138">The following example illustrates a task chain that has two continuations.</span></span> <span data-ttu-id="85cac-139">既存のファイルへのハンドルを取得する最初のタスクの操作が完了すると、1 つ目の継続でそのファイルを削除する新しい非同期操作が始まります。</span><span class="sxs-lookup"><span data-stu-id="85cac-139">The initial task acquires the handle to an existing file, and when that operation completes, the first continuation starts up a new asynchronous operation to delete the file.</span></span> <span data-ttu-id="85cac-140">その操作が完了すると、2 つ目の継続が実行され、確認メッセージが出力されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-140">When that operation completes, the second continuation runs, and outputs a confirmation message.</span></span>

``` cpp
#include <ppltasks.h>
using namespace concurrency;
...
void App::DeleteWithTasks(String^ fileName)
{    
    using namespace Windows::Storage;
    StorageFolder^ localFolder = ApplicationData::Current->LocalFolder;
    auto getFileTask = create_task(localFolder->GetFileAsync(fileName));

    getFileTask.then([](StorageFile^ storageFileSample) ->IAsyncAction^ {       
        return storageFileSample->DeleteAsync();
    }).then([](void) {
        OutputDebugString(L"File deleted.");
    });
}
```

<span data-ttu-id="85cac-141">この例で重要なポイントは次の 4 つです。</span><span class="sxs-lookup"><span data-stu-id="85cac-141">The previous example illustrates four important points:</span></span>

-   <span data-ttu-id="85cac-142">1 つ目の継続は、[**IAsyncAction^**][IAsyncAction] オブジェクトを **task<void>** に変換し、**task** を返します。</span><span class="sxs-lookup"><span data-stu-id="85cac-142">The first continuation converts the [**IAsyncAction^**][IAsyncAction] object to a **task<void>** and returns the **task**.</span></span>

-   <span data-ttu-id="85cac-143">2 つ目の継続は、エラー処理を実行しないため、**task<void>** ではなく **void** を入力として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="85cac-143">The second continuation performs no error handling, and therefore takes **void** and not **task<void>** as input.</span></span> <span data-ttu-id="85cac-144">これは値ベースの継続です。</span><span class="sxs-lookup"><span data-stu-id="85cac-144">It is a value-based continuation.</span></span>

-   <span data-ttu-id="85cac-145">2 つ目の後続タスクは、[**DeleteAsync**][deleteAsync] 操作が完了するまで実行されません。</span><span class="sxs-lookup"><span data-stu-id="85cac-145">The second continuation doesn't execute until the [**DeleteAsync**][deleteAsync] operation completes.</span></span>

-   <span data-ttu-id="85cac-146">2 つ目の後続タスクは値ベースであるため、[**DeleteAsync**][deleteAsync] を呼び出して開始された操作から例外がスローされると、2 つ目の後続タスクは実行されません。</span><span class="sxs-lookup"><span data-stu-id="85cac-146">Because the second continuation is value-based, if the operation that was started by the call to [**DeleteAsync**][deleteAsync] throws an exception, the second continuation doesn't execute at all.</span></span>

<span data-ttu-id="85cac-147">**注:** 非同期操作を作成する、 **task**クラスを使用する方法の 1 つは、タスク チェーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="85cac-147">**Note**Creating a task chain is just one of the ways to use the **task** class to compose asynchronous operations.</span></span> <span data-ttu-id="85cac-148">結合演算子 (**&&**) や選択演算子 (**||**) を使って操作を構成することもできます。</span><span class="sxs-lookup"><span data-stu-id="85cac-148">You can also compose operations by using join and choice operators **&&** and **||**.</span></span> <span data-ttu-id="85cac-149">詳しくは、「[タスクの並列処理 (同時実行ランタイム)][taskParallelism]」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85cac-149">For more information, see [Task Parallelism (Concurrency Runtime)][taskParallelism].</span></span>

## <a name="lambda-function-return-types-and-task-return-types"></a><span data-ttu-id="85cac-150">ラムダ関数の戻り値の型とタスクの戻り値の型</span><span class="sxs-lookup"><span data-stu-id="85cac-150">Lambda function return types and task return types</span></span>
<span data-ttu-id="85cac-151">継続タスクでは、ラムダ関数の戻り値の型が **task** オブジェクトでラップされます。</span><span class="sxs-lookup"><span data-stu-id="85cac-151">In a task continuation, the return type of the lambda function is wrapped in a **task** object.</span></span> <span data-ttu-id="85cac-152">ラムダが **double** を返す場合、継続タスクの型は **task<double>** になります。</span><span class="sxs-lookup"><span data-stu-id="85cac-152">If the lambda returns a **double**, then the type of the continuation task is **task<double>**.</span></span> <span data-ttu-id="85cac-153">ただし、タスク オブジェクトは、戻り値の型を必要以上に入れ子にしないように設計されています。</span><span class="sxs-lookup"><span data-stu-id="85cac-153">However, the task object is designed so that it doesn't produce needlessly nested return types.</span></span> <span data-ttu-id="85cac-154">ラムダが **IAsyncOperation<SyndicationFeed^>^** を返す場合、継続は、**task<task<SyndicationFeed^>>** や **task<IAsyncOperation<SyndicationFeed^>^>^** ではなく、**task<SyndicationFeed^>** を返します。</span><span class="sxs-lookup"><span data-stu-id="85cac-154">If a lambda returns an **IAsyncOperation<SyndicationFeed^>^**, the continuation returns a **task<SyndicationFeed^>**, not a **task<task<SyndicationFeed^>>** or **task<IAsyncOperation<SyndicationFeed^>^>^**.</span></span> <span data-ttu-id="85cac-155">*非同期ラップ解除*と呼ばれるこの処理により、さらに、継続内の非同期操作が完了しないと次の継続が呼び出されないようになります。</span><span class="sxs-lookup"><span data-stu-id="85cac-155">This process is known as *asynchronous unwrapping* and it also ensures that the asynchronous operation inside the continuation completes before the next continuation is invoked.</span></span>

<span data-ttu-id="85cac-156">前の例では、ラムダが [**IAsyncInfo**][IAsyncInfo] オブジェクトを返しているのに、タスクは **task<void>** を返しています。</span><span class="sxs-lookup"><span data-stu-id="85cac-156">In the previous example, notice that the task returns a **task<void>** even though its lambda returned an [**IAsyncInfo**][IAsyncInfo] object.</span></span> <span data-ttu-id="85cac-157">ラムダ関数とその外側のタスクの間で行われるこれらの型変換を次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="85cac-157">The following table summarizes the type conversions that occur between a lambda function and the enclosing task:</span></span>

| | |
|--------------------------------------------------------|---------------------|
| <span data-ttu-id="85cac-158">ラムダの戻り値の型</span><span class="sxs-lookup"><span data-stu-id="85cac-158">lambda return type</span></span>                                     | `.then` <span data-ttu-id="85cac-159">の戻り値の型</span><span class="sxs-lookup"><span data-stu-id="85cac-159">return type</span></span> |
| <span data-ttu-id="85cac-160">TResult</span><span class="sxs-lookup"><span data-stu-id="85cac-160">TResult</span></span>                                                | <span data-ttu-id="85cac-161">task</span><span class="sxs-lookup"><span data-stu-id="85cac-161">task</span></span><TResult> |
| <span data-ttu-id="85cac-162">IAsyncOperation<TResult>^</span><span class="sxs-lookup"><span data-stu-id="85cac-162">IAsyncOperation<TResult>^</span></span>                        | <span data-ttu-id="85cac-163">task</span><span class="sxs-lookup"><span data-stu-id="85cac-163">task</span></span><TResult> |
| <span data-ttu-id="85cac-164">IAsyncOperationWithProgress<TResult, TProgress>^</span><span class="sxs-lookup"><span data-stu-id="85cac-164">IAsyncOperationWithProgress<TResult, TProgress>^</span></span> | <span data-ttu-id="85cac-165">task</span><span class="sxs-lookup"><span data-stu-id="85cac-165">task</span></span><TResult> |
|<span data-ttu-id="85cac-166">IAsyncAction^</span><span class="sxs-lookup"><span data-stu-id="85cac-166">IAsyncAction^</span></span>                                           | <span data-ttu-id="85cac-167">task</span><span class="sxs-lookup"><span data-stu-id="85cac-167">task</span></span><void>    |
| <span data-ttu-id="85cac-168">IAsyncActionWithProgress<TProgress>^</span><span class="sxs-lookup"><span data-stu-id="85cac-168">IAsyncActionWithProgress<TProgress>^</span></span>             |<span data-ttu-id="85cac-169">task</span><span class="sxs-lookup"><span data-stu-id="85cac-169">task</span></span><void>     |
| <span data-ttu-id="85cac-170">task</span><span class="sxs-lookup"><span data-stu-id="85cac-170">task</span></span><TResult>                                    |<span data-ttu-id="85cac-171">task</span><span class="sxs-lookup"><span data-stu-id="85cac-171">task</span></span><TResult>  |


## <a name="canceling-tasks"></a><span data-ttu-id="85cac-172">タスクの取り消し</span><span class="sxs-lookup"><span data-stu-id="85cac-172">Canceling tasks</span></span>
<span data-ttu-id="85cac-173">通常、非同期操作をユーザーが取り消せるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85cac-173">It is often a good idea to give the user the option to cancel an asynchronous operation.</span></span> <span data-ttu-id="85cac-174">また、場合によっては、プログラムを使ってタスク チェーンの外側から操作を取り消さなければならないこともあります。</span><span class="sxs-lookup"><span data-stu-id="85cac-174">And in some cases you might have to cancel an operation programmatically from outside the task chain.</span></span> <span data-ttu-id="85cac-175">\**Async*\* のそれぞれの戻り値の型には [**IAsyncInfo**][IAsyncInfo] から継承した [**Cancel**][IAsyncInfoCancel] メソッドが含まれますが、それを外部のメソッドに公開する方法はあまりお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="85cac-175">Although each \***Async** return type has a [**Cancel**][IAsyncInfoCancel] method that it inherits from [**IAsyncInfo**][IAsyncInfo], it's awkward to expose it to outside methods.</span></span> <span data-ttu-id="85cac-176">タスク チェーンで取り消しをサポートするときは、[**cancellation\_token\_source**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749985.aspx) を使って [**cancellation\_token**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749975.aspx) を作成し、そのトークンを最初のタスクのコンストラクターに渡す方法をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85cac-176">The preferred way to support cancellation in a task chain is to use a [**cancellation\_token\_source**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749985.aspx) to create a [**cancellation\_token**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749975.aspx), and then pass the token to the constructor of the initial task.</span></span> <span data-ttu-id="85cac-177">キャンセル トークンを設定して非同期タスクを作成した場合、[**cancellation\_token\_source::cancel**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750076.aspx) が呼び出されたときに、**IAsync\*** 操作に対する **Cancel** が自動的に呼び出され、取り消し要求が後続のタスク チェーンに渡されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-177">If an asynchronous task is created with a cancellation token, and [**cancellation\_token\_source::cancel**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750076.aspx) is called, the task automatically calls **Cancel** on the **IAsync\*** operation and passes the cancellation request down its continuation chain.</span></span> <span data-ttu-id="85cac-178">この基本的な方法を示す疑似コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="85cac-178">The following pseudocode demonstrates the basic approach.</span></span>

``` cpp
//Class member:
cancellation_token_source m_fileTaskTokenSource;

// Cancel button event handler:
m_fileTaskTokenSource.cancel();

// task chain
auto getFileTask2 = create_task(documentsFolder->GetFileAsync(fileName),
                                m_fileTaskTokenSource.get_token());
//getFileTask2.then ...
```

<span data-ttu-id="85cac-179">タスクが取り消されると、[**task\_canceled**][taskCanceled]  例外がタスク チェーンを通じて伝達されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-179">When a task is canceled, a [**task\_canceled**][taskCanceled] exception is propagated down the task chain.</span></span> <span data-ttu-id="85cac-180">値ベースの後続タスクは実行されないだけですが、タスクベースの後続タスクでは、[**task::get**][taskGet] が呼び出されると例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="85cac-180">Value-based continuations will simply not execute, but task-based continuations will cause the exception to be thrown when [**task::get**][taskGet] is called.</span></span> <span data-ttu-id="85cac-181">エラー処理を行う継続がある場合は、**task\_canceled** 例外を明示的にキャッチするようにしてください </span><span class="sxs-lookup"><span data-stu-id="85cac-181">If you have an error-handling continuation, make sure that it catches the **task\_canceled** exception explicitly.</span></span> <span data-ttu-id="85cac-182">(これは [**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/xaml/hh755825.aspx) から派生した例外ではありません)。</span><span class="sxs-lookup"><span data-stu-id="85cac-182">(This exception is not derived from [**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/xaml/hh755825.aspx).)</span></span>

<span data-ttu-id="85cac-183">取り消しは連携して行います。</span><span class="sxs-lookup"><span data-stu-id="85cac-183">Cancellation is cooperative.</span></span> <span data-ttu-id="85cac-184">継続で、UWP メソッドを呼び出すだけでなく、時間のかかる作業を行うときは、キャンセル トークンの状態を定期的に確認し、取り消された場合は実行を中止する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85cac-184">If your continuation does some long-running work beyond just invoking a UWP method, then it is your responsibility to check the state of the cancellation token periodically and stop execution if it is canceled.</span></span> <span data-ttu-id="85cac-185">継続で割り当てられたすべてのリソースをクリーンアップした後、[**cancel\_current\_task**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749945.aspx) を呼び出してそのタスクを取り消し、以降の値ベースの継続に取り消しを伝達します。</span><span class="sxs-lookup"><span data-stu-id="85cac-185">After you clean up all resources that were allocated in the continuation, call [**cancel\_current\_task**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749945.aspx) to cancel that task and propagate the cancellation down to any value-based continuations that follow it.</span></span> <span data-ttu-id="85cac-186">また、別の例として、[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/BR207871) 操作の結果を表すタスク チェーンを作成するとします。</span><span class="sxs-lookup"><span data-stu-id="85cac-186">Here's another example: you can create a task chain that represents the result of a [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/BR207871) operation.</span></span> <span data-ttu-id="85cac-187">ユーザーが **[キャンセル]** ボタンをクリックした場合、[**IAsyncInfo::Cancel**][IAsyncInfoCancel] メソッドは呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="85cac-187">If the user chooses the **Cancel** button, the [**IAsyncInfo::Cancel**][IAsyncInfoCancel] method is not called.</span></span> <span data-ttu-id="85cac-188">代わりに、操作は完了しますが **nullptr** が返されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-188">Instead, the operation succeeds but returns **nullptr**.</span></span> <span data-ttu-id="85cac-189">この場合、継続で入力パラメーターをテストし、入力が **nullptr** の場合に **cancel\_current\_task** を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="85cac-189">The continuation can test the input parameter and call **cancel\_current\_task** if the input is **nullptr**.</span></span>

<span data-ttu-id="85cac-190">詳しくは、「[PPL での取り消し](https://msdn.microsoft.com/library/windows/apps/xaml/dd984117.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85cac-190">For more information, see [Cancellation in the PPL](https://msdn.microsoft.com/library/windows/apps/xaml/dd984117.aspx)</span></span>

## <a name="handling-errors-in-a-task-chain"></a><span data-ttu-id="85cac-191">タスク チェーンでのエラーの処理</span><span class="sxs-lookup"><span data-stu-id="85cac-191">Handling errors in a task chain</span></span>
<span data-ttu-id="85cac-192">先行タスクの取り消しや例外のスローが行われても継続を実行する場合は、継続のラムダ関数への入力を **task<TResult>** または **task<void>** (先行タスクのラムダが [**IAsyncAction^**][IAsyncAction] を返す場合) として指定して、継続をタスクベースにします。</span><span class="sxs-lookup"><span data-stu-id="85cac-192">If you want a continuation to execute even if the antecedent was canceled or threw an exception, then make the continuation a task-based continuation by specifying the input to its lambda function as a **task<TResult>** or **task<void>** if the lambda of the antecedent task returns an [**IAsyncAction^**][IAsyncAction].</span></span>

<span data-ttu-id="85cac-193">タスク チェーンでエラーや取り消しを処理するために、すべての後続タスクをタスクベースにしたり、スローする可能性があるすべての操作を `try…catch` ブロック内に含めたりする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="85cac-193">To handle errors and cancellation in a task chain, you don't have to make every continuation task-based or enclose every operation that might throw within a `try…catch` block.</span></span> <span data-ttu-id="85cac-194">代わりに、タスクベースの後続タスクをチェーンの最後に追加し、その後続タスクですべてのエラーを処理します。</span><span class="sxs-lookup"><span data-stu-id="85cac-194">Instead, you can add a task-based continuation at the end of the chain and handle all errors there.</span></span> <span data-ttu-id="85cac-195">例外 ( [**task\_canceled**][taskCanceled] 例外も含む) はタスク チェーンを通じて伝達され、値ベースの継続はバイパスされるため、エラー処理を行うタスクベースの継続で例外を処理できます。</span><span class="sxs-lookup"><span data-stu-id="85cac-195">Any exception—this includes a [**task\_canceled**][taskCanceled] exception—will propagate down the task chain and bypass any value-based continuations, so that you can handle it in the error-handling task-based continuation.</span></span> <span data-ttu-id="85cac-196">エラー処理を行うタスクベースの後続タスクを使うように前の例を書き換えると次のようになります。</span><span class="sxs-lookup"><span data-stu-id="85cac-196">We can rewrite the previous example to use an error-handling task-based continuation:</span></span>

``` cpp
#include <ppltasks.h>
void App::DeleteWithTasksHandleErrors(String^ fileName)
{    
    using namespace Windows::Storage;
    using namespace concurrency;

    StorageFolder^ documentsFolder = KnownFolders::DocumentsLibrary;
    auto getFileTask = create_task(documentsFolder->GetFileAsync(fileName));

    getFileTask.then([](StorageFile^ storageFileSample)
    {       
        return storageFileSample->DeleteAsync();
    })

    .then([](task<void> t)
    {

        try
        {
            t.get();
            // .get() didn' t throw, so we succeeded.
            OutputDebugString(L"File deleted.");
        }
        catch (Platform::COMException^ e)
        {
            //Example output: The system cannot find the specified file.
            OutputDebugString(e->Message->Data());
        }

    });
}
```

<span data-ttu-id="85cac-197">タスクベースの後続タスクで、メンバー関数 [**task::get**][taskGet] を呼び出してタスクの結果を取得しています。</span><span class="sxs-lookup"><span data-stu-id="85cac-197">In a task-based continuation, we call the member function [**task::get**][taskGet] to get the results of the task.</span></span> <span data-ttu-id="85cac-198">**task::get** は、結果を生成しない [**IAsyncAction**][IAsyncAction] 操作の場合でも呼び出す必要があります。これは、**task::get** ではタスクに送られた例外も取得するためです。</span><span class="sxs-lookup"><span data-stu-id="85cac-198">We still have to call **task::get** even if the operation was an [**IAsyncAction**][IAsyncAction] that produces no result because **task::get** also gets any exceptions that have been transported down to the task.</span></span> <span data-ttu-id="85cac-199">入力タスクに例外が格納されている場合、**task::get** の呼び出しでその例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="85cac-199">If the input task is storing an exception, it is thrown at the call to **task::get**.</span></span> <span data-ttu-id="85cac-200">**task::get** を呼び出していない場合、チェーンの最後でタスクベースの継続を使っていない場合、またはスローされた例外の種類をキャッチしていない場合は、タスクに対する参照がすべて削除されたときに **unobserved\_task\_exception** がスローされます。</span><span class="sxs-lookup"><span data-stu-id="85cac-200">If you don't call **task::get**, or don't use a task-based continuation at the end of the chain, or don't catch the exception type that was thrown, then an **unobserved\_task\_exception** is thrown when all references to the task have been deleted.</span></span>

<span data-ttu-id="85cac-201">キャッチする例外は処理できるものだけにしてください。</span><span class="sxs-lookup"><span data-stu-id="85cac-201">Only catch the exceptions that you can handle.</span></span> <span data-ttu-id="85cac-202">回復できないエラーがアプリで発生した場合は、不明な状態のままアプリの実行を続けるのではなく、アプリをクラッシュさせることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85cac-202">If your app encounters an error that you can't recover from, it's better to let the app crash than to let it continue to run in an unknown state.</span></span> <span data-ttu-id="85cac-203">また、一般に、**unobserved\_task\_exception** 自体はキャッチしないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85cac-203">Also, in general, don't attempt to catch the **unobserved\_task\_exception** itself.</span></span> <span data-ttu-id="85cac-204">この例外は、主に診断を目的としたものです。</span><span class="sxs-lookup"><span data-stu-id="85cac-204">This exception is mainly intended for diagnostic purposes.</span></span> <span data-ttu-id="85cac-205">**unobserved\_task\_exception** がスローされた場合、通常はコード内にバグがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="85cac-205">When **unobserved\_task\_exception** is thrown, it usually indicates a bug in the code.</span></span> <span data-ttu-id="85cac-206">原因のほとんどは、処理が必要な例外があること、またはコード内の他のエラーが原因で回復できない例外があることのどちらかです。</span><span class="sxs-lookup"><span data-stu-id="85cac-206">Often the cause is either an exception that should be handled, or an unrecoverable exception that's caused by some other error in the code.</span></span>

## <a name="managing-the-thread-context"></a><span data-ttu-id="85cac-207">スレッド コンテキストの管理</span><span class="sxs-lookup"><span data-stu-id="85cac-207">Managing the thread context</span></span>
<span data-ttu-id="85cac-208">UWP アプリの UI は、シングルスレッド アパートメント (STA) で実行されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-208">The UI of a UWP app runs in a single-threaded apartment (STA).</span></span> <span data-ttu-id="85cac-209">ラムダが [**IAsyncAction**][IAsyncAction] または [**IAsyncOperation**][IAsyncOperation] を返すタスクは、アパートメントを認識します。</span><span class="sxs-lookup"><span data-stu-id="85cac-209">A task whose lambda returns either an [**IAsyncAction**][IAsyncAction] or [**IAsyncOperation**][IAsyncOperation] is apartment-aware.</span></span> <span data-ttu-id="85cac-210">タスクが STA で作成されている場合、特に指定しない限り、その後続タスクもすべて STA で実行されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-210">If the task is created in the STA, then all of its continuations will run also run in it by default, unless you specify otherwise.</span></span> <span data-ttu-id="85cac-211">つまり、タスク チェーン全体が親タスクからアパートメントの認識を継承します。</span><span class="sxs-lookup"><span data-stu-id="85cac-211">In other words, the entire task chain inherits apartment-awareness from the parent task.</span></span> <span data-ttu-id="85cac-212">この動作により、STA からしかアクセスできない UI コントロールの操作が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="85cac-212">This behavior helps simplify interactions with UI controls, which can only be accessed from the STA.</span></span>

<span data-ttu-id="85cac-213">たとえば、UWP アプリの [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) コントロールを設定するとき、XAML ページを表す任意のクラスのメンバー関数で [**task::then**][taskThen] メソッド内から設定できるため、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) オブジェクトを使う必要がありません。</span><span class="sxs-lookup"><span data-stu-id="85cac-213">For example, in a UWP app, in the member function of any class that represents a XAML page, you can populate a [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) control from within a [**task::then**][taskThen] method without having to use the [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) object.</span></span>

``` cpp
#include <ppltasks.h>
void App::SetFeedText()
{    
    using namespace Windows::Web::Syndication;
    using namespace concurrency;
    String^ url = "http://windowsteamblog.com/windows_phone/b/wmdev/atom.aspx";
    SyndicationClient^ client = ref new SyndicationClient();
    auto feedOp = client->RetrieveFeedAsync(ref new Uri(url));

    create_task(feedOp).then([this]  (SyndicationFeed^ feed)
    {
        m_TextBlock1->Text = feed->Title->Text;
    });
}
```

<span data-ttu-id="85cac-214">[**IAsyncAction**][IAsyncAction] または [**IAsyncOperation**][IAsyncOperation] を返さないタスクは、アパートメントを認識しません。これらのタスクの後続タスクは、既定では、利用可能な最初のバックグラウンド スレッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-214">If a task doesn't return an [**IAsyncAction**][IAsyncAction] or [**IAsyncOperation**][IAsyncOperation], then it's not apartment-aware and, by default, its continuations are run on the first available background thread.</span></span>

<span data-ttu-id="85cac-215">既定のスレッド コンテキストは、どちらの種類のタスクについても、[**task\_continuation\_context**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749968.aspx) を受け取る [**task::then**][taskThen] のオーバーロードを使って上書きできます。</span><span class="sxs-lookup"><span data-stu-id="85cac-215">You can override the default thread context for either kind of task by using the overload of [**task::then**][taskThen] that takes a [**task\_continuation\_context**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749968.aspx).</span></span> <span data-ttu-id="85cac-216">たとえば、状況によっては、アパートメントを認識するタスクの後続タスクをバックグラウンド スレッドでスケジュールする方が適している場合もあります。</span><span class="sxs-lookup"><span data-stu-id="85cac-216">For example, in some cases, it might be desirable to schedule the continuation of an apartment-aware task on a background thread.</span></span> <span data-ttu-id="85cac-217">このような場合は、[**task\_continuation\_context::use\_arbitrary**][useArbitrary] を渡して、マルチスレッド アパートメント内の次に利用可能なスレッドでタスクの処理をスケジュールできます。</span><span class="sxs-lookup"><span data-stu-id="85cac-217">In such a case, you can pass [**task\_continuation\_context::use\_arbitrary**][useArbitrary] to schedule the task’s work on the next available thread in a multi-threaded apartment.</span></span> <span data-ttu-id="85cac-218">これにより、継続の作業を UI スレッドで発生する他の作業と同期する必要がないため、継続のパフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="85cac-218">This can improve the performance of the continuation because its work doesn't have to be synchronized with other work that's happening on the UI thread.</span></span>

<span data-ttu-id="85cac-219">次の例は、[**task\_continuation\_context::use\_arbitrary**][useArbitrary] オプションを指定すると役立つ状況の例を示しています。また、スレッド セーフでないコレクションの同時操作の同期に既定の継続のコンテキストがどのように役立つかも示しています。</span><span class="sxs-lookup"><span data-stu-id="85cac-219">The following example demonstrates when it's useful to specify the [**task\_continuation\_context::use\_arbitrary**][useArbitrary] option, and it also shows how the default continuation context is useful for synchronizing concurrent operations on non-thread-safe collections.</span></span> <span data-ttu-id="85cac-220">このコードでは、RSS フィードの URL の一覧をループ処理し、各 URL について、非同期操作を開始してフィード データを取得しています。</span><span class="sxs-lookup"><span data-stu-id="85cac-220">In this code, we loop through a list of URLs for RSS feeds, and for each URL, we start up an async operation to retrieve the feed data.</span></span> <span data-ttu-id="85cac-221">フィードを取得する順序は制御できませんが、ここでは問題ありません。</span><span class="sxs-lookup"><span data-stu-id="85cac-221">We can’t control the order in which the feeds are retrieved, and we don't really care.</span></span> <span data-ttu-id="85cac-222">[**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR210642) 操作が完了するたびに、1 つ目の継続が [**SyndicationFeed^**](https://msdn.microsoft.com/library/windows/apps/BR243485) オブジェクトを受け取り、それを使ってアプリで定義されている `FeedData^` オブジェクトを初期化します。</span><span class="sxs-lookup"><span data-stu-id="85cac-222">When each [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR210642) operation completes, the first continuation accepts the [**SyndicationFeed^**](https://msdn.microsoft.com/library/windows/apps/BR243485) object and uses it to initialize an app-defined `FeedData^` object.</span></span> <span data-ttu-id="85cac-223">これらの操作はそれぞれ独立した操作であるため、継続のコンテキストとして **task\_continuation\_context::use\_arbitrary** を指定すると処理が速くなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="85cac-223">Because each of these operations is independent from the others, we can potentially speed things up by specifying the **task\_continuation\_context::use\_arbitrary** continuation context.</span></span> <span data-ttu-id="85cac-224">ただし、それぞれの `FeedData` オブジェクトを初期化した後に、そのオブジェクトを [**Vector**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx) に追加する必要があり、スレッド セーフなコレクションではありません。</span><span class="sxs-lookup"><span data-stu-id="85cac-224">However, after each `FeedData` object is initialized, we have to add it to a [**Vector**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx), which is not a thread-safe collection.</span></span> <span data-ttu-id="85cac-225">そのため、ここでは、継続を作成して [**task\_continuation\_context::use\_current**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx) を指定することで、[**Append**](https://msdn.microsoft.com/library/windows/apps/BR206632) の呼び出しがすべて同じアプリケーション シングルスレッド アパートメント (ASTA) コンテキストで実行されるようにしています。</span><span class="sxs-lookup"><span data-stu-id="85cac-225">Therefore, we create a continuation and specify [**task\_continuation\_context::use\_current**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx) to ensure that all the calls to [**Append**](https://msdn.microsoft.com/library/windows/apps/BR206632) occur in the same Application Single-Threaded Apartment (ASTA) context.</span></span> <span data-ttu-id="85cac-226">[**task\_continuation\_context::use\_default**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx) は既定のコンテキストであるため、明示的に指定する必要はありませんが、ここではわかりやすいように指定しています。</span><span class="sxs-lookup"><span data-stu-id="85cac-226">Because [**task\_continuation\_context::use\_default**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx) is the default context, we don’t have to specify it explicitly, but we do so here for the sake of clarity.</span></span>

``` cpp
#include <ppltasks.h>
void App::InitDataSource(Vector<Object^>^ feedList, vector<wstring> urls)
{
                using namespace concurrency;
    SyndicationClient^ client = ref new SyndicationClient();

    std::for_each(std::begin(urls), std::end(urls), [=,this] (std::wstring url)
    {
        // Create the async operation. feedOp is an
        // IAsyncOperationWithProgress<SyndicationFeed^, RetrievalProgress>^
        // but we don't handle progress in this example.

        auto feedUri = ref new Uri(ref new String(url.c_str()));
        auto feedOp = client->RetrieveFeedAsync(feedUri);

        // Create the task object and pass it the async operation.
        // SyndicationFeed^ is the type of the return value
        // that the feedOp operation will eventually produce.

        // Then, initialize a FeedData object by using the feed info. Each
        // operation is independent and does not have to happen on the
        // UI thread. Therefore, we specify use_arbitrary.
        create_task(feedOp).then([this]  (SyndicationFeed^ feed) -> FeedData^
        {
            return GetFeedData(feed);
        }, task_continuation_context::use_arbitrary())

        // Append the initialized FeedData object to the list
        // that is the data source for the items collection.
        // This all has to happen on the same thread.
        // By using the use_default context, we can append
        // safely to the Vector without taking an explicit lock.
        .then([feedList] (FeedData^ fd)
        {
            feedList->Append(fd);
            OutputDebugString(fd->Title->Data());
        }, task_continuation_context::use_default())

        // The last continuation serves as an error handler. The
        // call to get() will surface any exceptions that were raised
        // at any point in the task chain.
        .then( [this] (task<void> t)
        {
            try
            {
                t.get();
            }
            catch(Platform::InvalidArgumentException^ e)
            {
                //TODO handle error.
                OutputDebugString(e->Message->Data());
            }
        }); //end task chain

    }); //end std::for_each
}
```

<span data-ttu-id="85cac-227">継続内で作成される入れ子になった新しいタスクは、最初のタスクのアパートメントの認識を継承しません。</span><span class="sxs-lookup"><span data-stu-id="85cac-227">Nested tasks, which are new tasks that are created inside a continuation, don't inherit apartment-awareness of the initial task.</span></span>

## <a name="handing-progress-updates"></a><span data-ttu-id="85cac-228">進行状況の更新の処理</span><span class="sxs-lookup"><span data-stu-id="85cac-228">Handing progress updates</span></span>
<span data-ttu-id="85cac-229">[**IAsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) または [**IAsyncActionWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206581.aspx) をサポートするメソッドは、実行中の操作が完了するまでの間、定期的に進行状況の更新を提供します。</span><span class="sxs-lookup"><span data-stu-id="85cac-229">Methods that support [**IAsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) or [**IAsyncActionWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206581.aspx) provide progress updates periodically while the operation is in progress, before it completes.</span></span> <span data-ttu-id="85cac-230">この進行状況の報告は、タスクや継続とは別に独立して処理されます。</span><span class="sxs-lookup"><span data-stu-id="85cac-230">Progress reporting is independent from the notion of tasks and continuations.</span></span> <span data-ttu-id="85cac-231">オブジェクトの [**Progress**](https://msdn.microsoft.com/library/windows/apps/br206594) プロパティのデリゲートを指定するだけでかまいません。</span><span class="sxs-lookup"><span data-stu-id="85cac-231">You just supply the delegate for the object’s [**Progress**](https://msdn.microsoft.com/library/windows/apps/br206594) property.</span></span> <span data-ttu-id="85cac-232">このデリゲートの一般的な用途は、UI の進行状況バーを更新することです。</span><span class="sxs-lookup"><span data-stu-id="85cac-232">A typical use of the delegate is to update a progress bar in the UI.</span></span>

## <a name="related-topics"></a><span data-ttu-id="85cac-233">関連トピック</span><span class="sxs-lookup"><span data-stu-id="85cac-233">Related topics</span></span>
* [<span data-ttu-id="85cac-234">UWP アプリ用に C++/CX で非同期操作を作成</span><span class="sxs-lookup"><span data-stu-id="85cac-234">Creating Asynchronous Operations in C++/CX for UWP apps</span></span>](https://msdn.microsoft.com/library/hh750082)
* [<span data-ttu-id="85cac-235">Visual C++ 言語のリファレンス</span><span class="sxs-lookup"><span data-stu-id="85cac-235">Visual C++ Language Reference</span></span>](http://msdn.microsoft.com/library/windows/apps/hh699871.aspx)
* <span data-ttu-id="85cac-236">[非同期プログラミング][AsyncProgramming]</span><span class="sxs-lookup"><span data-stu-id="85cac-236">[Asynchronous Programming][AsyncProgramming]</span></span>
* <span data-ttu-id="85cac-237">[タスクの並列処理 (同時実行ランタイム)][taskParallelism]</span><span class="sxs-lookup"><span data-stu-id="85cac-237">[Task Parallelism (Concurrency Runtime)][taskParallelism]</span></span>
* [<span data-ttu-id="85cac-238">concurrency::task</span><span class="sxs-lookup"><span data-stu-id="85cac-238">concurrency::task</span></span>](/cpp/parallel/concrt/reference/task-class)

<!-- LINKS -->
[AsyncProgramming]: <https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps> "AsyncProgramming"
[concurrencyNamespace]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/concurrency-namespace> "Concurrency 名前空間"
[createTask]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/concurrency-namespace-functions#create_task> "CreateTask"
[deleteAsync]: <https://msdn.microsoft.com/library/windows/apps/BR227199> "DeleteAsync"
[IAsyncAction]: <https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.aspx> "IAsyncAction"
[IAsyncOperation]: <https://msdn.microsoft.com/library/windows/apps/BR206598> "IAsyncOperation"
[IAsyncInfo]: <https://msdn.microsoft.com/library/windows/apps/BR206587> "IAsyncInfo"
[IAsyncInfoCancel]: <https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncinfo.cancel> "IAsyncInfoCancel"
[taskCanceled]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-canceled-class> "TaskCancelled"
[task-class]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class#get> "Task Class"
[taskGet]: <https://msdn.microsoft.com/library/windows/apps/xaml/hh750017.aspx> "TaskGet"
[taskParallelism]: <https://docs.microsoft.com/cpp/parallel/concrt/task-parallelism-concurrency-runtime> "タスクの並列処理"
[taskThen]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class#then> "TaskThen"
[useArbitrary]: <https://msdn.microsoft.com/library/windows/apps/xaml/hh750036.aspx> "UseArbitrary"
