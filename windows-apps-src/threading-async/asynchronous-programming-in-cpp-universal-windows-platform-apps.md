---
ms.assetid: 34C00F9F-2196-46A3-A32F-0067AB48291B
description: この記事では、Visual C コンポーネント拡張機能での非同期メソッドを使用することをお勧めの方法を説明します。 (C +/cli CX) ppltasks.h で同時実行の名前空間で定義されているタスク クラスを使用しています。
title: C++ での非同期プログラミング
ms.date: 05/14/2018
ms.topic: article
keywords: Windows 10、UWP、スレッド、非同期、C++
ms.localizationpriority: medium
ms.openlocfilehash: beab78415ab36fc7bc0659af1b3466b2c3601d88
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662837"
---
# <a name="asynchronous-programming-in-ccx"></a><span data-ttu-id="ada63-104">C++/CX での非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="ada63-104">Asynchronous programming in C++/CX</span></span>
> [!NOTE]
> <span data-ttu-id="ada63-105">このトピックは、C++/CX アプリケーションの管理ができるようにすることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="ada63-105">This topic exists to help you maintain your C++/CX application.</span></span> <span data-ttu-id="ada63-106">ただし、新しいアプリケーションには [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ada63-106">But we recommend that you use [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) for new applications.</span></span> <span data-ttu-id="ada63-107">C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="ada63-107">C++/WinRT is an entirely standard modern C++17 language projection for Windows Runtime (WinRT) APIs, implemented as a header-file-based library, and designed to provide you with first-class access to the modern Windows API.</span></span>

<span data-ttu-id="ada63-108">この記事では、Visual C コンポーネント拡張機能での非同期メソッドを使用することをお勧めの方法を説明します。 (C +/cli CX) を使用して、`task`クラスで定義されている、 `concurrency` ppltasks.h 内の名前空間。</span><span class="sxs-lookup"><span data-stu-id="ada63-108">This article describes the recommended way to consume asynchronous methods in Visual C++ component extensions (C++/CX) by using the `task` class that's defined in the `concurrency` namespace in ppltasks.h.</span></span>

## <a name="universal-windows-platform-uwp-asynchronous-types"></a><span data-ttu-id="ada63-109">ユニバーサル Windows プラットフォーム (UWP) の非同期型</span><span class="sxs-lookup"><span data-stu-id="ada63-109">Universal Windows Platform (UWP) asynchronous types</span></span>
<span data-ttu-id="ada63-110">ユニバーサル Windows プラットフォーム (UWP) には、非同期メソッドを呼び出すためのモデルが明確に定義されており、非同期メソッドを使う必要がある型があります。</span><span class="sxs-lookup"><span data-stu-id="ada63-110">The Universal Windows Platform (UWP) features a well-defined model for calling asynchronous methods and provides the types that you need to consume such methods.</span></span> <span data-ttu-id="ada63-111">UWP の非同期モデルについて詳しくない場合は、この記事の前に「[非同期プログラミング][AsyncProgramming]」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ada63-111">If you are not familiar with the UWP asynchronous model, read [Asynchronous Programming][AsyncProgramming] before you read the rest of this article.</span></span>

<span data-ttu-id="ada63-112">非同期 UWP API は C++ で直接使うこともできますが、[**task class**][task-class] とそれに関連する型と関数を使うことをお勧めします。これは [**concurrency**][concurrencyNamespace] 名前空間のクラスで、`<ppltasks.h>` で定義されています。</span><span class="sxs-lookup"><span data-stu-id="ada63-112">Although you can consume the asynchronous UWP APIs directly in C++, the preferred approach is to use the [**task class**][task-class] and its related types and functions, which are contained in the [**concurrency**][concurrencyNamespace] namespace and defined in `<ppltasks.h>`.</span></span> <span data-ttu-id="ada63-113">**concurrency::task** は汎用型のクラスですが、**/ZW** コンパイラ スイッチ (ユニバーサル Windows プラットフォーム (UWP) アプリとそのコンポーネントには必須) を使うと、task クラスで UWP の非同期型をカプセル化して次の処理を簡単に行うことができます。</span><span class="sxs-lookup"><span data-stu-id="ada63-113">The **concurrency::task** is a general-purpose type, but when the **/ZW** compiler switch—which is required for Universal Windows Platform (UWP) apps and components—is used, the task class encapsulates the UWP asynchronous types so that it's easier to:</span></span>

-   <span data-ttu-id="ada63-114">複数の非同期操作や同期操作を 1 つのチェーンで連結する</span><span class="sxs-lookup"><span data-stu-id="ada63-114">chain multiple asynchronous and synchronous operations together</span></span>

-   <span data-ttu-id="ada63-115">タスク チェーンで例外を処理する</span><span class="sxs-lookup"><span data-stu-id="ada63-115">handle exceptions in task chains</span></span>

-   <span data-ttu-id="ada63-116">タスク チェーンで取り消しを実行する</span><span class="sxs-lookup"><span data-stu-id="ada63-116">perform cancellation in task chains</span></span>

-   <span data-ttu-id="ada63-117">各タスクを適切なスレッド コンテキストまたはスレッド アパートメントで実行する</span><span class="sxs-lookup"><span data-stu-id="ada63-117">ensure that individual tasks run in the appropriate thread context or apartment</span></span>

<span data-ttu-id="ada63-118">ここでは、**task** クラスを UWP の非同期 API で使う方法に関する基本的なガイダンスを示しています。</span><span class="sxs-lookup"><span data-stu-id="ada63-118">This article provides basic guidance about how to use the **task** class with the UWP asynchronous APIs.</span></span> <span data-ttu-id="ada63-119">詳細については、に関するドキュメントを完成**タスク**およびその関連メソッドを含む[**作成\_タスク**][createTask]を参照してください。[タスクの並列化 (同時実行ランタイム)][taskParallelism]します。</span><span class="sxs-lookup"><span data-stu-id="ada63-119">For more complete documentation about **task** and its related methods including [**create\_task**][createTask], see [Task Parallelism (Concurrency Runtime)][taskParallelism].</span></span> 

## <a name="consuming-an-async-operation-by-using-a-task"></a><span data-ttu-id="ada63-120">タスクを使った非同期操作の使用</span><span class="sxs-lookup"><span data-stu-id="ada63-120">Consuming an async operation by using a task</span></span>
<span data-ttu-id="ada63-121">次の例は、task クラスを使って、[**IAsyncOperation**][IAsyncOperation] インターフェイスを返す **async** メソッドを使う方法を示しています。この操作では値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-121">The following example shows how to use the task class to consume an **async** method that returns an [**IAsyncOperation**][IAsyncOperation] interface and whose operation produces a value.</span></span> <span data-ttu-id="ada63-122">基本的な手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ada63-122">Here are the basic steps:</span></span>

1.  <span data-ttu-id="ada63-123">`create_task` メソッドを呼び出し、**IAsyncOperation** オブジェクトに渡します。</span><span class="sxs-lookup"><span data-stu-id="ada63-123">Call the `create_task` method and pass it the **IAsyncOperation^** object.</span></span>

2.  <span data-ttu-id="ada63-124">タスクのメンバー関数 [**task::then**][taskThen] を呼び出し、非同期操作の完了時に呼び出すラムダを指定します。</span><span class="sxs-lookup"><span data-stu-id="ada63-124">Call the member function [**task::then**][taskThen] on the task and supply a lambda that will be invoked when the asynchronous operation completes.</span></span>

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

<span data-ttu-id="ada63-125">[  **task::then**][taskThen] 関数で作成されて返されるタスクのことを*後続タスク*と呼びます。</span><span class="sxs-lookup"><span data-stu-id="ada63-125">The task that's created and returned by the [**task::then**][taskThen] function is known as a *continuation*.</span></span> <span data-ttu-id="ada63-126">ユーザーが指定するラムダの入力引数は (この例の場合)、タスク操作の完了時に生成される結果です。</span><span class="sxs-lookup"><span data-stu-id="ada63-126">The input argument (in this case) to the user-provided lambda is the result that the task operation produces when it completes.</span></span> <span data-ttu-id="ada63-127">この値は、**IAsyncOperation** インターフェイスを直接使う場合に [**IAsyncOperation::GetResults**](https://msdn.microsoft.com/library/windows/apps/br206600) を呼び出して取得する値と同じになります。</span><span class="sxs-lookup"><span data-stu-id="ada63-127">It's the same value that would be retrieved by calling [**IAsyncOperation::GetResults**](https://msdn.microsoft.com/library/windows/apps/br206600) if you were using the **IAsyncOperation** interface directly.</span></span>

<span data-ttu-id="ada63-128">[  **task::then**][taskThen] メソッドからは直ちに制御が返され、そのデリゲートは非同期作業が正常に完了するまで実行されません。</span><span class="sxs-lookup"><span data-stu-id="ada63-128">The [**task::then**][taskThen] method returns immediately, and its delegate doesn't run until the asynchronous work completes successfully.</span></span> <span data-ttu-id="ada63-129">この例では、非同期操作で例外がスローされるか、取り消し要求によって非同期操作が取り消された状態で終わると、継続は実行されません。</span><span class="sxs-lookup"><span data-stu-id="ada63-129">In this example, if the asynchronous operation causes an exception to be thrown, or ends in the canceled state as a result of a cancellation request, the continuation will never execute.</span></span> <span data-ttu-id="ada63-130">前のタスクが取り消されるか失敗しても実行される継続を記述する方法については後で説明します。</span><span class="sxs-lookup"><span data-stu-id="ada63-130">Later, we’ll describe how to write continuations that execute even if the previous task was cancelled or failed.</span></span>

<span data-ttu-id="ada63-131">タスクの変数はローカル スタックで宣言しますが、その有効期間は、操作が完了する前にメソッドから制御が返されても、すべての操作が完了してすべての参照がスコープ外になるまで削除されないように管理されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-131">Although you declare the task variable on the local stack, it manages its lifetime so that it is not deleted until all of its operations complete and all references to it go out of scope, even if the method returns before the operations complete.</span></span>

## <a name="creating-a-chain-of-tasks"></a><span data-ttu-id="ada63-132">タスクのチェーンの作成</span><span class="sxs-lookup"><span data-stu-id="ada63-132">Creating a chain of tasks</span></span>
<span data-ttu-id="ada63-133">非同期プログラミングでは、前のタスクが完了した場合にのみ継続が実行されるように、操作のシーケンス (*タスク チェーン*) を定義するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="ada63-133">In asynchronous programming, it's common to define a sequence of operations, also known as *task chains*, in which each continuation executes only when the previous one completes.</span></span> <span data-ttu-id="ada63-134">場合によっては、前のタスク (*先行タスク*) で生成された値を継続が入力として受け取ることもあります。</span><span class="sxs-lookup"><span data-stu-id="ada63-134">In some cases, the previous (or *antecedent*) task produces a value that the continuation accepts as input.</span></span> <span data-ttu-id="ada63-135">[  **task::then**][taskThen] メソッドを使うと、直観的な方法で簡単にタスク チェーンを作成できます。このメソッドは、**task<T>** (**T** はラムダ関数の戻り値の型) を返します。</span><span class="sxs-lookup"><span data-stu-id="ada63-135">By using the [**task::then**][taskThen] method, you can create task chains in an intuitive and straightforward manner; the method returns a **task<T>** where **T** is the return type of the lambda function.</span></span> <span data-ttu-id="ada63-136">複数の継続を含めて 1 つのタスク チェーンを構成することができます。`myTask.then(…).then(…).then(…);`</span><span class="sxs-lookup"><span data-stu-id="ada63-136">You can compose multiple continuations into a task chain: `myTask.then(…).then(…).then(…);`</span></span>

<span data-ttu-id="ada63-137">タスク チェーンは、継続で新しい非同期操作を作成する場合に特に便利です。このようなタスクのことを非同期タスクと呼びます。</span><span class="sxs-lookup"><span data-stu-id="ada63-137">Task chains are especially useful when a continuation creates a new asynchronous operation; such a task is known as an asynchronous task.</span></span> <span data-ttu-id="ada63-138">次の例は、2 つの継続を含むタスク チェーンを示しています。</span><span class="sxs-lookup"><span data-stu-id="ada63-138">The following example illustrates a task chain that has two continuations.</span></span> <span data-ttu-id="ada63-139">既存のファイルへのハンドルを取得する最初のタスクの操作が完了すると、1 つ目の継続でそのファイルを削除する新しい非同期操作が始まります。</span><span class="sxs-lookup"><span data-stu-id="ada63-139">The initial task acquires the handle to an existing file, and when that operation completes, the first continuation starts up a new asynchronous operation to delete the file.</span></span> <span data-ttu-id="ada63-140">その操作が完了すると、2 つ目の継続が実行され、確認メッセージが出力されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-140">When that operation completes, the second continuation runs, and outputs a confirmation message.</span></span>

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

<span data-ttu-id="ada63-141">この例で重要なポイントは次の 4 つです。</span><span class="sxs-lookup"><span data-stu-id="ada63-141">The previous example illustrates four important points:</span></span>

-   <span data-ttu-id="ada63-142">1 つ目の継続は、[**IAsyncAction^**][IAsyncAction] オブジェクトを **task<void>** に変換し、**task** を返します。</span><span class="sxs-lookup"><span data-stu-id="ada63-142">The first continuation converts the [**IAsyncAction^**][IAsyncAction] object to a **task<void>** and returns the **task**.</span></span>

-   <span data-ttu-id="ada63-143">2 つ目の継続は、エラー処理を実行しないため、**task<void>** ではなく **void** を入力として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ada63-143">The second continuation performs no error handling, and therefore takes **void** and not **task<void>** as input.</span></span> <span data-ttu-id="ada63-144">これは値ベースの継続です。</span><span class="sxs-lookup"><span data-stu-id="ada63-144">It is a value-based continuation.</span></span>

-   <span data-ttu-id="ada63-145">2 つ目の後続タスクは、[**DeleteAsync**][deleteAsync] 操作が完了するまで実行されません。</span><span class="sxs-lookup"><span data-stu-id="ada63-145">The second continuation doesn't execute until the [**DeleteAsync**][deleteAsync] operation completes.</span></span>

-   <span data-ttu-id="ada63-146">2 つ目の後続タスクは値ベースであるため、[**DeleteAsync**][deleteAsync] を呼び出して開始された操作から例外がスローされると、2 つ目の後続タスクは実行されません。</span><span class="sxs-lookup"><span data-stu-id="ada63-146">Because the second continuation is value-based, if the operation that was started by the call to [**DeleteAsync**][deleteAsync] throws an exception, the second continuation doesn't execute at all.</span></span>

<span data-ttu-id="ada63-147">**注**  を使用する方法の 1 つは、タスクのチェーンを作成、**タスク**非同期操作を構成するクラス。</span><span class="sxs-lookup"><span data-stu-id="ada63-147">**Note**  Creating a task chain is just one of the ways to use the **task** class to compose asynchronous operations.</span></span> <span data-ttu-id="ada63-148">結合演算子 (**&&**) や選択演算子 (**||**) を使って操作を構成することもできます。</span><span class="sxs-lookup"><span data-stu-id="ada63-148">You can also compose operations by using join and choice operators **&&** and **||**.</span></span> <span data-ttu-id="ada63-149">詳しくは、「[タスクの並列処理 (同時実行ランタイム)][taskParallelism]」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ada63-149">For more information, see [Task Parallelism (Concurrency Runtime)][taskParallelism].</span></span>

## <a name="lambda-function-return-types-and-task-return-types"></a><span data-ttu-id="ada63-150">ラムダ関数の戻り値の型とタスクの戻り値の型</span><span class="sxs-lookup"><span data-stu-id="ada63-150">Lambda function return types and task return types</span></span>
<span data-ttu-id="ada63-151">継続タスクでは、ラムダ関数の戻り値の型が **task** オブジェクトでラップされます。</span><span class="sxs-lookup"><span data-stu-id="ada63-151">In a task continuation, the return type of the lambda function is wrapped in a **task** object.</span></span> <span data-ttu-id="ada63-152">ラムダが **double** を返す場合、継続タスクの型は **task<double>** になります。</span><span class="sxs-lookup"><span data-stu-id="ada63-152">If the lambda returns a **double**, then the type of the continuation task is **task<double>**.</span></span> <span data-ttu-id="ada63-153">ただし、タスク オブジェクトは、戻り値の型を必要以上に入れ子にしないように設計されています。</span><span class="sxs-lookup"><span data-stu-id="ada63-153">However, the task object is designed so that it doesn't produce needlessly nested return types.</span></span> <span data-ttu-id="ada63-154">ラムダが **IAsyncOperation<SyndicationFeed^>^** を返す場合、継続は、**task<task<SyndicationFeed^>>** や **task<IAsyncOperation<SyndicationFeed^>^>^** ではなく、**task<SyndicationFeed^>** を返します。</span><span class="sxs-lookup"><span data-stu-id="ada63-154">If a lambda returns an **IAsyncOperation<SyndicationFeed^>^**, the continuation returns a **task<SyndicationFeed^>**, not a **task<task<SyndicationFeed^>>** or **task<IAsyncOperation<SyndicationFeed^>^>^**.</span></span> <span data-ttu-id="ada63-155">*非同期ラップ解除*と呼ばれるこの処理により、さらに、継続内の非同期操作が完了しないと次の継続が呼び出されないようになります。</span><span class="sxs-lookup"><span data-stu-id="ada63-155">This process is known as *asynchronous unwrapping* and it also ensures that the asynchronous operation inside the continuation completes before the next continuation is invoked.</span></span>

<span data-ttu-id="ada63-156">前の例では、ラムダが [**IAsyncInfo**][IAsyncInfo] オブジェクトを返しているのに、タスクは **task<void>** を返しています。</span><span class="sxs-lookup"><span data-stu-id="ada63-156">In the previous example, notice that the task returns a **task<void>** even though its lambda returned an [**IAsyncInfo**][IAsyncInfo] object.</span></span> <span data-ttu-id="ada63-157">ラムダ関数とその外側のタスクの間で行われるこれらの型変換を次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="ada63-157">The following table summarizes the type conversions that occur between a lambda function and the enclosing task:</span></span>

| | |
|--------------------------------------------------------|---------------------|
| <span data-ttu-id="ada63-158">ラムダの戻り値の型</span><span class="sxs-lookup"><span data-stu-id="ada63-158">lambda return type</span></span>                                     | <span data-ttu-id="ada63-159">`.then` の戻り値の型</span><span class="sxs-lookup"><span data-stu-id="ada63-159">`.then` return type</span></span> |
| <span data-ttu-id="ada63-160">TResult</span><span class="sxs-lookup"><span data-stu-id="ada63-160">TResult</span></span>                                                | <span data-ttu-id="ada63-161">タスク<TResult></span><span class="sxs-lookup"><span data-stu-id="ada63-161">task<TResult></span></span> |
| <span data-ttu-id="ada63-162">IAsyncOperation<TResult>^</span><span class="sxs-lookup"><span data-stu-id="ada63-162">IAsyncOperation<TResult>^</span></span>                        | <span data-ttu-id="ada63-163">タスク<TResult></span><span class="sxs-lookup"><span data-stu-id="ada63-163">task<TResult></span></span> |
| <span data-ttu-id="ada63-164">IAsyncOperationWithProgress<TResult, TProgress>^</span><span class="sxs-lookup"><span data-stu-id="ada63-164">IAsyncOperationWithProgress<TResult, TProgress>^</span></span> | <span data-ttu-id="ada63-165">タスク<TResult></span><span class="sxs-lookup"><span data-stu-id="ada63-165">task<TResult></span></span> |
|<span data-ttu-id="ada63-166">IAsyncAction^</span><span class="sxs-lookup"><span data-stu-id="ada63-166">IAsyncAction^</span></span>                                           | <span data-ttu-id="ada63-167">タスク<void></span><span class="sxs-lookup"><span data-stu-id="ada63-167">task<void></span></span>    |
| <span data-ttu-id="ada63-168">IAsyncActionWithProgress<TProgress>^</span><span class="sxs-lookup"><span data-stu-id="ada63-168">IAsyncActionWithProgress<TProgress>^</span></span>             |<span data-ttu-id="ada63-169">タスク<void></span><span class="sxs-lookup"><span data-stu-id="ada63-169">task<void></span></span>     |
| <span data-ttu-id="ada63-170">タスク<TResult></span><span class="sxs-lookup"><span data-stu-id="ada63-170">task<TResult></span></span>                                    |<span data-ttu-id="ada63-171">タスク<TResult></span><span class="sxs-lookup"><span data-stu-id="ada63-171">task<TResult></span></span>  |


## <a name="canceling-tasks"></a><span data-ttu-id="ada63-172">タスクの取り消し</span><span class="sxs-lookup"><span data-stu-id="ada63-172">Canceling tasks</span></span>
<span data-ttu-id="ada63-173">通常、非同期操作をユーザーが取り消せるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ada63-173">It is often a good idea to give the user the option to cancel an asynchronous operation.</span></span> <span data-ttu-id="ada63-174">また、場合によっては、プログラムを使ってタスク チェーンの外側から操作を取り消さなければならないこともあります。</span><span class="sxs-lookup"><span data-stu-id="ada63-174">And in some cases you might have to cancel an operation programmatically from outside the task chain.</span></span> <span data-ttu-id="ada63-175">各\* **Async**戻り型を[**キャンセル**] [ IAsyncInfoCancel]メソッドから継承した[ **IAsyncInfo**][IAsyncInfo]、外側のメソッドを公開するため不適切です。</span><span class="sxs-lookup"><span data-stu-id="ada63-175">Although each \***Async** return type has a [**Cancel**][IAsyncInfoCancel] method that it inherits from [**IAsyncInfo**][IAsyncInfo], it's awkward to expose it to outside methods.</span></span> <span data-ttu-id="ada63-176">タスク チェーンでキャンセルをサポートするために推奨される方法は使用する、 [**キャンセル\_トークン\_ソース**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749985.aspx)を作成する、 [**キャンセル\_トークン**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749975.aspx)、最初のタスクのコンス トラクターにトークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="ada63-176">The preferred way to support cancellation in a task chain is to use a [**cancellation\_token\_source**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749985.aspx) to create a [**cancellation\_token**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749975.aspx), and then pass the token to the constructor of the initial task.</span></span> <span data-ttu-id="ada63-177">キャンセル トークンを使用する非同期タスクを作成した場合と[**キャンセル\_トークン\_source::cancel** ](https://msdn.microsoft.com/library/windows/apps/xaml/hh750076.aspx)が呼び出されると、タスクに自動的に呼び出す**キャンセル**上、 **IAsync\*** その継続のチェーンをキャンセルが要求操作を渡します。</span><span class="sxs-lookup"><span data-stu-id="ada63-177">If an asynchronous task is created with a cancellation token, and [**cancellation\_token\_source::cancel**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750076.aspx) is called, the task automatically calls **Cancel** on the **IAsync\*** operation and passes the cancellation request down its continuation chain.</span></span> <span data-ttu-id="ada63-178">この基本的な方法を示す疑似コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="ada63-178">The following pseudocode demonstrates the basic approach.</span></span>

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

<span data-ttu-id="ada63-179">タスクが取り消されたときに、 [**タスク\_キャンセル**] [ taskCanceled]チェーン内のタスクに例外が反映されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-179">When a task is canceled, a [**task\_canceled**][taskCanceled] exception is propagated down the task chain.</span></span> <span data-ttu-id="ada63-180">値ベースの後続タスクは実行されないだけですが、タスクベースの後続タスクでは、[**task::get**][taskGet] が呼び出されると例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="ada63-180">Value-based continuations will simply not execute, but task-based continuations will cause the exception to be thrown when [**task::get**][taskGet] is called.</span></span> <span data-ttu-id="ada63-181">エラー処理の継続がある場合は場合、キャッチすることを確認、**タスク\_キャンセル**例外明示的にします。</span><span class="sxs-lookup"><span data-stu-id="ada63-181">If you have an error-handling continuation, make sure that it catches the **task\_canceled** exception explicitly.</span></span> <span data-ttu-id="ada63-182">(これは [**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/xaml/hh755825.aspx) から派生した例外ではありません)。</span><span class="sxs-lookup"><span data-stu-id="ada63-182">(This exception is not derived from [**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/xaml/hh755825.aspx).)</span></span>

<span data-ttu-id="ada63-183">取り消しは連携して行います。</span><span class="sxs-lookup"><span data-stu-id="ada63-183">Cancellation is cooperative.</span></span> <span data-ttu-id="ada63-184">継続で、UWP メソッドを呼び出すだけでなく、時間のかかる作業を行うときは、キャンセル トークンの状態を定期的に確認し、取り消された場合は実行を中止する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ada63-184">If your continuation does some long-running work beyond just invoking a UWP method, then it is your responsibility to check the state of the cancellation token periodically and stop execution if it is canceled.</span></span> <span data-ttu-id="ada63-185">継続タスクに割り当てられたすべてのリソースをクリーンアップする後[**キャンセル\_現在\_タスク**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749945.aspx)そのタスクをキャンセルし、いずれかにキャンセルを伝達するにはそれに続く値ベースの継続します。</span><span class="sxs-lookup"><span data-stu-id="ada63-185">After you clean up all resources that were allocated in the continuation, call [**cancel\_current\_task**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749945.aspx) to cancel that task and propagate the cancellation down to any value-based continuations that follow it.</span></span> <span data-ttu-id="ada63-186">また、別の例として、[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/BR207871) 操作の結果を表すタスク チェーンを作成するとします。</span><span class="sxs-lookup"><span data-stu-id="ada63-186">Here's another example: you can create a task chain that represents the result of a [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/BR207871) operation.</span></span> <span data-ttu-id="ada63-187">ユーザーが **[キャンセル]** ボタンをクリックした場合、[**IAsyncInfo::Cancel**][IAsyncInfoCancel] メソッドは呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="ada63-187">If the user chooses the **Cancel** button, the [**IAsyncInfo::Cancel**][IAsyncInfoCancel] method is not called.</span></span> <span data-ttu-id="ada63-188">代わりに、操作は完了しますが **nullptr** が返されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-188">Instead, the operation succeeds but returns **nullptr**.</span></span> <span data-ttu-id="ada63-189">継続は、入力パラメーターと呼び出しをテストできます**キャンセル\_現在\_タスク**場合は、入力が**nullptr**します。</span><span class="sxs-lookup"><span data-stu-id="ada63-189">The continuation can test the input parameter and call **cancel\_current\_task** if the input is **nullptr**.</span></span>

<span data-ttu-id="ada63-190">詳しくは、「[PPL での取り消し](https://msdn.microsoft.com/library/windows/apps/xaml/dd984117.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ada63-190">For more information, see [Cancellation in the PPL](https://msdn.microsoft.com/library/windows/apps/xaml/dd984117.aspx)</span></span>

## <a name="handling-errors-in-a-task-chain"></a><span data-ttu-id="ada63-191">タスク チェーンでのエラーの処理</span><span class="sxs-lookup"><span data-stu-id="ada63-191">Handling errors in a task chain</span></span>
<span data-ttu-id="ada63-192">先行タスクの取り消しや例外のスローが行われても継続を実行する場合は、継続のラムダ関数への入力を **task<TResult>** または **task<void>** (先行タスクのラムダが [**IAsyncAction^**][IAsyncAction] を返す場合) として指定して、継続をタスクベースにします。</span><span class="sxs-lookup"><span data-stu-id="ada63-192">If you want a continuation to execute even if the antecedent was canceled or threw an exception, then make the continuation a task-based continuation by specifying the input to its lambda function as a **task<TResult>** or **task<void>** if the lambda of the antecedent task returns an [**IAsyncAction^**][IAsyncAction].</span></span>

<span data-ttu-id="ada63-193">タスク チェーンでエラーや取り消しを処理するために、すべての継続をタスクベースにしたり、スローする可能性があるすべての操作を `try…catch` ブロック内に含めたりする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ada63-193">To handle errors and cancellation in a task chain, you don't have to make every continuation task-based or enclose every operation that might throw within a `try…catch` block.</span></span> <span data-ttu-id="ada63-194">代わりに、タスクベースの継続をチェーンの最後に追加し、その継続ですべてのエラーを処理します。</span><span class="sxs-lookup"><span data-stu-id="ada63-194">Instead, you can add a task-based continuation at the end of the chain and handle all errors there.</span></span> <span data-ttu-id="ada63-195">例外: これが含まれています、 [**タスク\_キャンセル**] [ taskCanceled]例外: チェーン内のタスクに反映され、すべての値ベースの継続をバイパスようにこれは、エラー処理のタスク ベースの継続で処理できます。</span><span class="sxs-lookup"><span data-stu-id="ada63-195">Any exception—this includes a [**task\_canceled**][taskCanceled] exception—will propagate down the task chain and bypass any value-based continuations, so that you can handle it in the error-handling task-based continuation.</span></span> <span data-ttu-id="ada63-196">エラー処理を行うタスクベースの継続を使うように前の例を書き換えると次のようになります。</span><span class="sxs-lookup"><span data-stu-id="ada63-196">We can rewrite the previous example to use an error-handling task-based continuation:</span></span>

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

<span data-ttu-id="ada63-197">タスクベースの後続タスクで、メンバー関数 [**task::get**][taskGet] を呼び出してタスクの結果を取得しています。</span><span class="sxs-lookup"><span data-stu-id="ada63-197">In a task-based continuation, we call the member function [**task::get**][taskGet] to get the results of the task.</span></span> <span data-ttu-id="ada63-198">**task::get** は、結果を生成しない [**IAsyncAction**][IAsyncAction] 操作の場合でも呼び出す必要があります。これは、**task::get** ではタスクに送られた例外も取得するためです。</span><span class="sxs-lookup"><span data-stu-id="ada63-198">We still have to call **task::get** even if the operation was an [**IAsyncAction**][IAsyncAction] that produces no result because **task::get** also gets any exceptions that have been transported down to the task.</span></span> <span data-ttu-id="ada63-199">入力タスクに例外が格納されている場合、**task::get** の呼び出しでその例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="ada63-199">If the input task is storing an exception, it is thrown at the call to **task::get**.</span></span> <span data-ttu-id="ada63-200">呼び出さない場合**task::get**、スローされた例外の種類の例外をキャッチしないまたはチェーンの最後に、タスク ベースの継続を使用しないでください、**無視された\_タスク\_例外**タスクにすべての参照が削除された場合にスローされます。</span><span class="sxs-lookup"><span data-stu-id="ada63-200">If you don't call **task::get**, or don't use a task-based continuation at the end of the chain, or don't catch the exception type that was thrown, then an **unobserved\_task\_exception** is thrown when all references to the task have been deleted.</span></span>

<span data-ttu-id="ada63-201">キャッチする例外は処理できるものだけにしてください。</span><span class="sxs-lookup"><span data-stu-id="ada63-201">Only catch the exceptions that you can handle.</span></span> <span data-ttu-id="ada63-202">回復できないエラーがアプリで発生した場合は、不明な状態のままアプリの実行を続けるのではなく、アプリをクラッシュさせることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ada63-202">If your app encounters an error that you can't recover from, it's better to let the app crash than to let it continue to run in an unknown state.</span></span> <span data-ttu-id="ada63-203">また、一般に、しないでキャッチ、**無視された\_タスク\_例外**自体。</span><span class="sxs-lookup"><span data-stu-id="ada63-203">Also, in general, don't attempt to catch the **unobserved\_task\_exception** itself.</span></span> <span data-ttu-id="ada63-204">この例外は、主に診断を目的としたものです。</span><span class="sxs-lookup"><span data-stu-id="ada63-204">This exception is mainly intended for diagnostic purposes.</span></span> <span data-ttu-id="ada63-205">ときに**無視された\_タスク\_例外**がスローされると、通常を示します、コードのバグです。</span><span class="sxs-lookup"><span data-stu-id="ada63-205">When **unobserved\_task\_exception** is thrown, it usually indicates a bug in the code.</span></span> <span data-ttu-id="ada63-206">原因のほとんどは、処理が必要な例外があること、またはコード内の他のエラーが原因で回復できない例外があることのどちらかです。</span><span class="sxs-lookup"><span data-stu-id="ada63-206">Often the cause is either an exception that should be handled, or an unrecoverable exception that's caused by some other error in the code.</span></span>

## <a name="managing-the-thread-context"></a><span data-ttu-id="ada63-207">スレッド コンテキストの管理</span><span class="sxs-lookup"><span data-stu-id="ada63-207">Managing the thread context</span></span>
<span data-ttu-id="ada63-208">UWP アプリの UI は、シングルスレッド アパートメント (STA) で実行されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-208">The UI of a UWP app runs in a single-threaded apartment (STA).</span></span> <span data-ttu-id="ada63-209">ラムダが [**IAsyncAction**][IAsyncAction] または [**IAsyncOperation**][IAsyncOperation] を返すタスクは、アパートメントを認識します。</span><span class="sxs-lookup"><span data-stu-id="ada63-209">A task whose lambda returns either an [**IAsyncAction**][IAsyncAction] or [**IAsyncOperation**][IAsyncOperation] is apartment-aware.</span></span> <span data-ttu-id="ada63-210">タスクが STA で作成されている場合、特に指定しない限り、その継続もすべて STA で実行されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-210">If the task is created in the STA, then all of its continuations will run also run in it by default, unless you specify otherwise.</span></span> <span data-ttu-id="ada63-211">つまり、タスク チェーン全体が親タスクからアパートメントの認識を継承します。</span><span class="sxs-lookup"><span data-stu-id="ada63-211">In other words, the entire task chain inherits apartment-awareness from the parent task.</span></span> <span data-ttu-id="ada63-212">この動作により、STA からしかアクセスできない UI コントロールの操作が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="ada63-212">This behavior helps simplify interactions with UI controls, which can only be accessed from the STA.</span></span>

<span data-ttu-id="ada63-213">たとえば、UWP アプリの [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) コントロールを設定するとき、XAML ページを表す任意のクラスのメンバー関数で [**task::then**][taskThen] メソッド内から設定できるため、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) オブジェクトを使う必要がありません。</span><span class="sxs-lookup"><span data-stu-id="ada63-213">For example, in a UWP app, in the member function of any class that represents a XAML page, you can populate a [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) control from within a [**task::then**][taskThen] method without having to use the [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) object.</span></span>

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

<span data-ttu-id="ada63-214">[  **IAsyncAction**][IAsyncAction] または [**IAsyncOperation**][IAsyncOperation] を返さないタスクは、アパートメントを認識しません。これらのタスクの後続タスクは、既定では、利用可能な最初のバックグラウンド スレッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-214">If a task doesn't return an [**IAsyncAction**][IAsyncAction] or [**IAsyncOperation**][IAsyncOperation], then it's not apartment-aware and, by default, its continuations are run on the first available background thread.</span></span>

<span data-ttu-id="ada63-215">オーバー ロードを使用してタスクのいずれかの種類の既定のスレッド コンテキストをオーバーライドすることができます[ **task::then** ] [ taskThen]を受け取る、 [**タスク\_継続\_コンテキスト**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749968.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="ada63-215">You can override the default thread context for either kind of task by using the overload of [**task::then**][taskThen] that takes a [**task\_continuation\_context**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749968.aspx).</span></span> <span data-ttu-id="ada63-216">たとえば、状況によっては、アパートメントを認識するタスクの継続をバックグラウンド スレッドでスケジュールする方が適している場合もあります。</span><span class="sxs-lookup"><span data-stu-id="ada63-216">For example, in some cases, it might be desirable to schedule the continuation of an apartment-aware task on a background thread.</span></span> <span data-ttu-id="ada63-217">このような場合は、渡すことができます[**タスク\_継続\_context::use\_任意**] [ useArbitrary]でタスクの作業をスケジュールする、マルチ スレッド アパートメントで [次へ] の使用可能なスレッド。</span><span class="sxs-lookup"><span data-stu-id="ada63-217">In such a case, you can pass [**task\_continuation\_context::use\_arbitrary**][useArbitrary] to schedule the task’s work on the next available thread in a multi-threaded apartment.</span></span> <span data-ttu-id="ada63-218">これにより、継続の作業を UI スレッドで発生する他の作業と同期する必要がないため、継続のパフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="ada63-218">This can improve the performance of the continuation because its work doesn't have to be synchronized with other work that's happening on the UI thread.</span></span>

<span data-ttu-id="ada63-219">次の例で指定すると便利な場合、 [**タスク\_継続\_context::use\_任意**] [ useArbitrary]オプション、およびそれも表示方法、既定の継続コンテキストはスレッド セーフのコレクションでの同時操作を同期するために便利です。</span><span class="sxs-lookup"><span data-stu-id="ada63-219">The following example demonstrates when it's useful to specify the [**task\_continuation\_context::use\_arbitrary**][useArbitrary] option, and it also shows how the default continuation context is useful for synchronizing concurrent operations on non-thread-safe collections.</span></span> <span data-ttu-id="ada63-220">このコードでは、RSS フィードの URL の一覧をループ処理し、各 URL について、非同期操作を開始してフィード データを取得しています。</span><span class="sxs-lookup"><span data-stu-id="ada63-220">In this code, we loop through a list of URLs for RSS feeds, and for each URL, we start up an async operation to retrieve the feed data.</span></span> <span data-ttu-id="ada63-221">フィードを取得する順序は制御できませんが、ここでは問題ありません。</span><span class="sxs-lookup"><span data-stu-id="ada63-221">We can’t control the order in which the feeds are retrieved, and we don't really care.</span></span> <span data-ttu-id="ada63-222">[  **RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR210642) 操作が完了するたびに、1 つ目の継続が [**SyndicationFeed^**](https://msdn.microsoft.com/library/windows/apps/BR243485) オブジェクトを受け取り、それを使ってアプリで定義されている `FeedData^` オブジェクトを初期化します。</span><span class="sxs-lookup"><span data-stu-id="ada63-222">When each [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR210642) operation completes, the first continuation accepts the [**SyndicationFeed^**](https://msdn.microsoft.com/library/windows/apps/BR243485) object and uses it to initialize an app-defined `FeedData^` object.</span></span> <span data-ttu-id="ada63-223">これらの各操作は、他のユーザーから独立しているためできる場合もあります速度を向上させるを指定することによって、**タスク\_継続\_context::use\_任意**継続コンテキスト.</span><span class="sxs-lookup"><span data-stu-id="ada63-223">Because each of these operations is independent from the others, we can potentially speed things up by specifying the **task\_continuation\_context::use\_arbitrary** continuation context.</span></span> <span data-ttu-id="ada63-224">ただし、それぞれの `FeedData` オブジェクトを初期化した後に、そのオブジェクトを [**Vector**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx) に追加する必要があり、スレッド セーフなコレクションではありません。</span><span class="sxs-lookup"><span data-stu-id="ada63-224">However, after each `FeedData` object is initialized, we have to add it to a [**Vector**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx), which is not a thread-safe collection.</span></span> <span data-ttu-id="ada63-225">そのため、継続を作成し、指定[**タスク\_継続\_context::use\_現在**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx)ことに、すべての呼び出しを確認する[**Append** ](https://msdn.microsoft.com/library/windows/apps/BR206632)同じ Application Single-Threaded アパートメント (ASTA) コンテキストで発生します。</span><span class="sxs-lookup"><span data-stu-id="ada63-225">Therefore, we create a continuation and specify [**task\_continuation\_context::use\_current**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx) to ensure that all the calls to [**Append**](https://msdn.microsoft.com/library/windows/apps/BR206632) occur in the same Application Single-Threaded Apartment (ASTA) context.</span></span> <span data-ttu-id="ada63-226">[**タスク\_継続\_context::use\_既定**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx)既定のコンテキストには、それを明示的に指定する必要はありませんがこちらから行うことの sake のわかりやすくするためです。</span><span class="sxs-lookup"><span data-stu-id="ada63-226">Because [**task\_continuation\_context::use\_default**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx) is the default context, we don’t have to specify it explicitly, but we do so here for the sake of clarity.</span></span>

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

<span data-ttu-id="ada63-227">継続内で作成される入れ子になった新しいタスクは、最初のタスクのアパートメントの認識を継承しません。</span><span class="sxs-lookup"><span data-stu-id="ada63-227">Nested tasks, which are new tasks that are created inside a continuation, don't inherit apartment-awareness of the initial task.</span></span>

## <a name="handing-progress-updates"></a><span data-ttu-id="ada63-228">進行状況の更新の処理</span><span class="sxs-lookup"><span data-stu-id="ada63-228">Handing progress updates</span></span>
<span data-ttu-id="ada63-229">[  **IAsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) または [**IAsyncActionWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206581.aspx) をサポートするメソッドは、実行中の操作が完了するまでの間、定期的に進行状況の更新を提供します。</span><span class="sxs-lookup"><span data-stu-id="ada63-229">Methods that support [**IAsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) or [**IAsyncActionWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206581.aspx) provide progress updates periodically while the operation is in progress, before it completes.</span></span> <span data-ttu-id="ada63-230">この進行状況の報告は、タスクや継続とは別に独立して処理されます。</span><span class="sxs-lookup"><span data-stu-id="ada63-230">Progress reporting is independent from the notion of tasks and continuations.</span></span> <span data-ttu-id="ada63-231">オブジェクトの [**Progress**](https://msdn.microsoft.com/library/windows/apps/br206594) プロパティのデリゲートを指定するだけでかまいません。</span><span class="sxs-lookup"><span data-stu-id="ada63-231">You just supply the delegate for the object’s [**Progress**](https://msdn.microsoft.com/library/windows/apps/br206594) property.</span></span> <span data-ttu-id="ada63-232">このデリゲートの一般的な用途は、UI の進行状況バーを更新することです。</span><span class="sxs-lookup"><span data-stu-id="ada63-232">A typical use of the delegate is to update a progress bar in the UI.</span></span>

## <a name="related-topics"></a><span data-ttu-id="ada63-233">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ada63-233">Related topics</span></span>
* [<span data-ttu-id="ada63-234">非同期操作を作成する c++/cli CX UWP アプリ用</span><span class="sxs-lookup"><span data-stu-id="ada63-234">Creating Asynchronous Operations in C++/CX for UWP apps</span></span>](https://msdn.microsoft.com/library/hh750082)
* [<span data-ttu-id="ada63-235">Visual C 言語リファレンス</span><span class="sxs-lookup"><span data-stu-id="ada63-235">Visual C++ Language Reference</span></span>](https://msdn.microsoft.com/library/windows/apps/hh699871.aspx)
* <span data-ttu-id="ada63-236">[非同期プログラミング][AsyncProgramming]</span><span class="sxs-lookup"><span data-stu-id="ada63-236">[Asynchronous Programming][AsyncProgramming]</span></span>
* <span data-ttu-id="ada63-237">[タスクの並列処理 (同時実行ランタイム)][taskParallelism]</span><span class="sxs-lookup"><span data-stu-id="ada63-237">[Task Parallelism (Concurrency Runtime)][taskParallelism]</span></span>
* [<span data-ttu-id="ada63-238">concurrency::task</span><span class="sxs-lookup"><span data-stu-id="ada63-238">concurrency::task</span></span>](/cpp/parallel/concrt/reference/task-class)

<!-- LINKS -->
[AsyncProgramming]: <https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps> "AsyncProgramming"
[concurrencyNamespace]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/concurrency-namespace> "同時実行 Namespace"
[createTask]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/concurrency-namespace-functions#create_task> "CreateTask"
[deleteAsync]: <https://msdn.microsoft.com/library/windows/apps/BR227199> "DeleteAsync"
[IAsyncAction]: <https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.aspx> "IAsyncAction"
[IAsyncOperation]: <https://msdn.microsoft.com/library/windows/apps/BR206598> "IAsyncOperation"
[IAsyncInfo]: <https://msdn.microsoft.com/library/windows/apps/BR206587> "IAsyncInfo"
[IAsyncInfoCancel]: <https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncinfo.cancel> "IAsyncInfoCancel"
[taskCanceled]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-canceled-class> "TaskCancelled"
[task-class]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class#get> "Task クラス"
[taskGet]: <https://msdn.microsoft.com/library/windows/apps/xaml/hh750017.aspx> "TaskGet"
[taskParallelism]: <https://docs.microsoft.com/cpp/parallel/concrt/task-parallelism-concurrency-runtime> "タスクの並列化"
[taskThen]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class#then> "TaskThen"
[useArbitrary]: <https://msdn.microsoft.com/library/windows/apps/xaml/hh750036.aspx> "UseArbitrary"
