---
title: 非同期 C API の呼び出しパターン
description: XSAPI C API の非同期 C API 呼び出しパターンについて説明します。
ms.date: 06/10/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 開発者プログラム,
ms.localizationpriority: medium
ms.openlocfilehash: edc6248a363b844d94c8fa03ab7ce071cc941908
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8347057"
---
# <a name="calling-pattern-for-xsapi-flat-c-layer-async-calls"></a><span data-ttu-id="6af55-104">XSAPI フラット C レイヤーの非同期呼び出しの呼び出しパターン</span><span class="sxs-lookup"><span data-stu-id="6af55-104">Calling pattern for XSAPI flat C layer async calls</span></span>

<span data-ttu-id="6af55-105">**非同期 API** は、すばやくを制御を返し、**非同期タスク**を開始する API で、タスクが完了すると結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="6af55-105">An **asynchronous API** is an API that returns quickly but starts an **asynchronous task** and the result is returned after the task is finished.</span></span>

<span data-ttu-id="6af55-106">従来のゲームでは、**完了コールバック**を使用する場合に、どのスレッドが**非同期タスク**を実行し、どのスレッドが結果を返すかをほとんど制御していません。</span><span class="sxs-lookup"><span data-stu-id="6af55-106">Traditionally games have little control over which thread executes the **asynchronous task** and which thread returns the results when using a **completion callback**.</span></span>  <span data-ttu-id="6af55-107">ゲームによっては、スレッドの同期の必要性を回避するために、ヒープのセクションを 1 つのスレッドでのみ操作できるように設計されているものもあります。</span><span class="sxs-lookup"><span data-stu-id="6af55-107">Some games are designed so that a section of the heap is only touched by a single thread to avoid any need for thread synchronization.</span></span> <span data-ttu-id="6af55-108">**完了コールバック**が、ゲームが制御するスレッドから呼び出されていない場合、**非同期タスク**の結果で共有状態を更新するには、スレッドの同期が必要になります。</span><span class="sxs-lookup"><span data-stu-id="6af55-108">If the **completion callback** isn't called from a thread the game controls, updating shared state with the result of an **asynchronous task** will require thread synchronization.</span></span>

<span data-ttu-id="6af55-109">XSAPI C API が公開する新しい非同期 C API では、開発者は、**XblSocialGetSocialRelationshipsAsync()**、**XblProfileGetUserProfileAsync()**、**XblAchievementsGetAchievementsForTitleIdAsync()** などの**非同期 API** 呼び出しを行う際に直接スレッドを制御できます。</span><span class="sxs-lookup"><span data-stu-id="6af55-109">The XSAPI C API exposes a new asynchronous C API that gives developers direct thread control when making an **asynchronous API** call, such as **XblSocialGetSocialRelationshipsAsync()**, **XblProfileGetUserProfileAsync()** and **XblAchievementsGetAchievementsForTitleIdAsync()**.</span></span>

<span data-ttu-id="6af55-110">**XblProfileGetUserProfileAsync** API の基本的な呼び出しのサンプルを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="6af55-110">Here is a basic example calling the **XblProfileGetUserProfileAsync** API.</span></span>

```cpp
AsyncBlock* asyncBlock = new AsyncBlock {};
asyncBlock->queue = asyncQueue;
asyncBlock->context = customDataForCallback;
asyncBlock->callback = [](AsyncBlock* asyncBlock)
{
    XblUserProfile profile;
    if( SUCCEEDED( XblProfileGetUserProfileResult(asyncBlock, &profile) ) )
    {
        printf("Profile retrieved successfully\r\n");
    }
    delete asyncBlock;
};
XblProfileGetUserProfileAsync(asyncBlock, xboxLiveContext, xuid);
```

<span data-ttu-id="6af55-111">この呼び出しのパターンを理解するには、**AsyncBlock** と **AsyncQueue** の使用方法を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-111">To understand this calling pattern, you will need to understand how to use the **AsyncBlock** and the **AsyncQueue**.</span></span>

* <span data-ttu-id="6af55-112">**AsyncBlock** は、**非同期タスク**と**完了コールバック**に関連するすべての情報を保持します。</span><span class="sxs-lookup"><span data-stu-id="6af55-112">The **AsyncBlock** carries all of the information pertaining to the **asynchronous task** and **completion callback**.</span></span>

* <span data-ttu-id="6af55-113">**AsyncQueue** によって、**非同期タスク**を実行するスレッドと、AsyncBlock の**完了コールバック**を呼び出すスレッドを決定することができます。</span><span class="sxs-lookup"><span data-stu-id="6af55-113">The **AsyncQueue** allows you to determine which thread executes the **asynchronous task** and which thread calls the AsyncBlock's **completion callback**.</span></span>

## <a name="the-asyncblock"></a><span data-ttu-id="6af55-114">**AsyncBlock**</span><span class="sxs-lookup"><span data-stu-id="6af55-114">The **AsyncBlock**</span></span>

<span data-ttu-id="6af55-115">**AsyncBlock** を詳しく見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="6af55-115">Let's take a look at the **AsyncBlock** in detail.</span></span> <span data-ttu-id="6af55-116">これは、次のように定義された構造体です。</span><span class="sxs-lookup"><span data-stu-id="6af55-116">It is a struct defined as follows:</span></span>

```cpp
typedef struct AsyncBlock
{
    AsyncCompletionRoutine* callback;
    void* context;
    async_queue_handle_t queue;
} AsyncBlock;
```

<span data-ttu-id="6af55-117">**AsyncBlock** には、次の要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6af55-117">The **AsyncBlock** contains:</span></span>

* <span data-ttu-id="6af55-118">*callback* - 非同期処理が完了した後に呼び出される、オプションのコールバック関数。</span><span class="sxs-lookup"><span data-stu-id="6af55-118">*callback* - an optional callback function that will be called after the asynchronous work has been done.</span></span>  <span data-ttu-id="6af55-119">コールバックを指定しない場合、**GetAsyncStatus** を使用して **AsyncBlock** が完了するまで待機し、結果を取得します。</span><span class="sxs-lookup"><span data-stu-id="6af55-119">If you don't specify a callback, you can wait for the **AsyncBlock** to complete with **GetAsyncStatus** and then get the results.</span></span>
* <span data-ttu-id="6af55-120">*context* - データをコールバック関数に渡すことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="6af55-120">*context* - allows you to pass data to the callback function.</span></span>
* <span data-ttu-id="6af55-121">*queue* - **AsyncQueue** を指定するハンドルである async_queue_handle_t。</span><span class="sxs-lookup"><span data-stu-id="6af55-121">*queue* - an async_queue_handle_t which is a handle designating an **AsyncQueue**.</span></span> <span data-ttu-id="6af55-122">これが設定されていない場合、既定のキューが使用されます。</span><span class="sxs-lookup"><span data-stu-id="6af55-122">If this is not set, a default queue will be used.</span></span>

<span data-ttu-id="6af55-123">各非同期 API を呼び出すのヒープで新しい AsyncBlock を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-123">You should create a new AsyncBlock on the heap for each async API you call.</span></span>  <span data-ttu-id="6af55-124">まで、AsyncBlock の完了コールバックが呼び出され、削除し、AsyncBlock はライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-124">The AsyncBlock must live until the AsyncBlock's completion callback is called and then it can be deleted.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6af55-125">**AsyncBlock** は、**非同期タスク**が完了するまでメモリ内に存在している必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-125">An **AsyncBlock** must remain in memory until the **asynchronous task** completes.</span></span> <span data-ttu-id="6af55-126">動的に割り当てられる場合、AsyncBlock の**完了コールバック**内で削除できます。</span><span class="sxs-lookup"><span data-stu-id="6af55-126">If it is dynamically allocated, it can be deleted inside the AsyncBlock's **completion callback**.</span></span>

### <a name="waiting-for-asynchronous-task"></a><span data-ttu-id="6af55-127">**非同期タスク**の待機</span><span class="sxs-lookup"><span data-stu-id="6af55-127">Waiting for **asynchronous task**</span></span>

<span data-ttu-id="6af55-128">**非同期タスク**が完了したことは、さまざまな方法で知ることができます。</span><span class="sxs-lookup"><span data-stu-id="6af55-128">You can tell an **asynchronous task** is complete a number of different ways:</span></span>

* <span data-ttu-id="6af55-129">AsyncBlock の**完了コールバック**が呼び出される。</span><span class="sxs-lookup"><span data-stu-id="6af55-129">the AsyncBlock's **completion callback** is called</span></span>
* <span data-ttu-id="6af55-130">**GetAsyncStatus** を呼び出して、true の場合は非同期タスクが完了するまで待機する。</span><span class="sxs-lookup"><span data-stu-id="6af55-130">Call **GetAsyncStatus** with true to wait until it completes.</span></span>
* <span data-ttu-id="6af55-131">**AsyncBlock** で waitEvent を設定し、このイベントが通知されるまで待機する。</span><span class="sxs-lookup"><span data-stu-id="6af55-131">Set a waitEvent in the **AsyncBlock** and wait for the event to be signaled</span></span>

<span data-ttu-id="6af55-132">**GetAsyncStatus**と waitEvent では、**非同期タスク**と見なされます完了したら、AsyncBlock の**完了コールバック**を実行した後ただし、AsyncBlock の**完了コールバック**は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="6af55-132">With **GetAsyncStatus** and waitEvent, the **asynchronous task** is considered complete after the AsyncBlock's **completion callback** executes however the AsyncBlock's **completion callback** is optional.</span></span>

<span data-ttu-id="6af55-133">**非同期タスク**が完了したら、結果を取得できます。</span><span class="sxs-lookup"><span data-stu-id="6af55-133">Once the **asynchronous task** is complete, you can get the results.</span></span>

### <a name="getting-the-result-of-the-asynchronous-task"></a><span data-ttu-id="6af55-134">**非同期タスク**の結果の取得</span><span class="sxs-lookup"><span data-stu-id="6af55-134">Getting the result of the **asynchronous task**</span></span>

<span data-ttu-id="6af55-135">結果を取得するために、ほとんどの**非同期 API** 関数には、非同期呼び出しの結果を受け取るための対応する \[関数名\]Result 関数があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-135">To get the result, most **asynchronous API** functions have a corresponding \[Name of Function\]Result function to receive the result of the asynchronous call.</span></span> <span data-ttu-id="6af55-136">コード例の場合、**XblProfileGetUserProfileAsync** には、対応する **XblProfileGetUserProfileResult** 関数があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-136">In our example code, **XblProfileGetUserProfileAsync** has a corresponding **XblProfileGetUserProfileResult** function.</span></span> <span data-ttu-id="6af55-137">この関数を使用して、関数の結果を返し、それに応じて処理を実行できます。</span><span class="sxs-lookup"><span data-stu-id="6af55-137">You can use this function to return the result of the function and act accordingly.</span></span>  <span data-ttu-id="6af55-138">結果の取得について詳しくは、それぞれの**非同期 API** のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="6af55-138">See the documention of each **asynchronous API** function for full details on retrieving results.</span></span>

## <a name="the-asyncqueue"></a><span data-ttu-id="6af55-139">**AsyncQueue**</span><span class="sxs-lookup"><span data-stu-id="6af55-139">The **AsyncQueue**</span></span>

<span data-ttu-id="6af55-140">**AsyncQueue** によって、**非同期タスク**を実行するスレッドと、AsyncBlock の**完了コールバック**を呼び出すスレッドを決定することができます。</span><span class="sxs-lookup"><span data-stu-id="6af55-140">The **AsyncQueue** allows you to determine which thread executes the **asynchronous task** and which thread calls the AsyncBlock's **completion callback**.</span></span>

<span data-ttu-id="6af55-141">*ディスパッチ モード*を設定することによって、どのスレッドがこれらの処理を実行するかを制御できます。</span><span class="sxs-lookup"><span data-stu-id="6af55-141">You can control which thread performs these operation by setting a *dispatch mode*.</span></span> <span data-ttu-id="6af55-142">次の 3 つのディスパッチ モードを使用できます。</span><span class="sxs-lookup"><span data-stu-id="6af55-142">There are three dispatch modes available:</span></span>

* <span data-ttu-id="6af55-143">*手動* - 手動のキューは自動的にディスパッチされません。</span><span class="sxs-lookup"><span data-stu-id="6af55-143">*Manual* - The manual queue are not automatically dispatched.</span></span>  <span data-ttu-id="6af55-144">開発者が、必要なスレッドに処理をディスパッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-144">It is up to the developer to dispatch them on any thread they want.</span></span> <span data-ttu-id="6af55-145">これを使用して、非同期呼び出しの作業側またはコールバック側のいずれかを特定のスレッドに割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="6af55-145">This can be used to assign either the work or callback side of an async call to a specific thread.</span></span>  <span data-ttu-id="6af55-146">これについては、以下で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="6af55-146">This is discussed in more detail below.</span></span>

* <span data-ttu-id="6af55-147">*スレッド プール* - スレッド プールを使用してディスパッチします。</span><span class="sxs-lookup"><span data-stu-id="6af55-147">*Thread Pool* - Dispatches using a thread pool.</span></span>  <span data-ttu-id="6af55-148">スレッド プールは、スレッド プールのスレッドが利用可能になると、キューから順番に実行する呼び出しを取り出して、呼び出しを並行して実行します。</span><span class="sxs-lookup"><span data-stu-id="6af55-148">The thread pool invokes the calls in parallel, taking a call to execute from the queue in turn as threadpool threads become available.</span></span>  <span data-ttu-id="6af55-149">これは、使用するのは最も簡単ですが、使用するスレッドの制御は最小限になります。</span><span class="sxs-lookup"><span data-stu-id="6af55-149">This is the easist to use but gives you the least amount of control over which thread is used.</span></span>

* <span data-ttu-id="6af55-150">*固定スレッド* - 非同期キューを作成したスレッドで QueueUserAPC を使用してディスパッチします。</span><span class="sxs-lookup"><span data-stu-id="6af55-150">*Fixed Thread* - Dispatches using QueueUserAPC on the thread that created the async queue.</span></span> <span data-ttu-id="6af55-151">ユーザー モード APC がキューに入れられたときに、このスレッドがアラート可能な状態である場合を除き、スレッドは APC 関数を呼び出すよう指示されません。</span><span class="sxs-lookup"><span data-stu-id="6af55-151">When a user-mode APC is queued, the thread is not directed to call the APC function unless it is in an alertable state.</span></span> <span data-ttu-id="6af55-152">**SleepEx**、**SignalObjectAndWait**、**WaitForSingleObjectEx**、**WaitForMultipleObjectsEx**、または**MsgWaitForMultipleObjectsEx** を使用してアラート可能な待機操作を実行することによって、スレッドはアラート可能な状態になります。</span><span class="sxs-lookup"><span data-stu-id="6af55-152">A thread enters an alertable state by using **SleepEx**, **SignalObjectAndWait**, **WaitForSingleObjectEx**, **WaitForMultipleObjectsEx**, or **MsgWaitForMultipleObjectsEx** to perform an alertable wait operation</span></span>

<span data-ttu-id="6af55-153">新しい **AsyncQueue** を作成するには、**CreateAsyncQueue** を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-153">To create a new **AsyncQueue** you will need to call **CreateAsyncQueue**.</span></span>

```cpp
STDAPI CreateAsyncQueue(
    _In_ AsyncQueueDispatchMode workDispatchMode,
    _In_ AsyncQueueDispatchMode completionDispatchMode,
    _Out_ async_queue_handle_t* queue);
```

<span data-ttu-id="6af55-154">ここで、AsyncQueueDispatchMode には、前に紹介した 3 つのディスパッチ モードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6af55-154">where AsyncQueueDispatchMode contains the three dispatch modes introduced earlier:</span></span>

```cpp
typedef enum AsyncQueueDispatchMode
{
    /// <summary>
    /// Async callbacks are invoked manually by DispatchAsyncQueue
    /// </summary>
    AsyncQueueDispatchMode_Manual,

    /// <summary>
    /// Async callbacks are queued to the thread that created the queue
    /// and will be processed when the thread is alertable.
    /// </summary>
    AsyncQueueDispatchMode_FixedThread,

    /// <summary>
    /// Async callbacks are queued to the system thread pool and will
    /// be processed in order by the threadpool.
    /// </summary>
    AsyncQueueDispatchMode_ThreadPool

} AsyncQueueDispatchMode;
```

<span data-ttu-id="6af55-155">**workDispatchMode** は、非同期操作を処理するスレッドのディスパッチ モードを決定し、**completionDispatchMode** は、非同期操作の完了を処理するスレッドのディスパッチ モードを決定します。</span><span class="sxs-lookup"><span data-stu-id="6af55-155">**workDispatchMode** determines the dispatch mode for the thread which handles the async work, while **completionDispatchMode** determines the dispatch mode for the thread which handles the completion of the async operation.</span></span>

<span data-ttu-id="6af55-156">**CreateSharedAsyncQueue** を呼び出し、キューの ID を指定することで、同じ種類のキューを使用して **AsyncQueue** を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="6af55-156">You can also call **CreateSharedAsyncQueue** to create an **AsyncQueue** with the same queue type by specifying an ID for the queue.</span></span>

```cpp
STDAPI CreateSharedAsyncQueue(
    _In_ uint32_t id,
    _In_ AsyncQueueDispatchMode workerMode,
    _In_ AsyncQueueDispatchMode completionMode,
    _Out_ async_queue_handle_t* aQueue);
```

> [!NOTE]
> <span data-ttu-id="6af55-157">この ID を持つ、ディスパッチ モードのキューが既にある場合は、そのキューが参照されます。</span><span class="sxs-lookup"><span data-stu-id="6af55-157">If there is already a queue with this ID and dispatch  modes, it will be referenced.</span></span>  <span data-ttu-id="6af55-158">それ以外の場合は、新しいキューが作成されます。</span><span class="sxs-lookup"><span data-stu-id="6af55-158">Otherwise a new queue will be created.</span></span>

<span data-ttu-id="6af55-159">**AsyncQueue** を作成したら、単にそれを **AsyncBlock** に追加し、作業と完了関数のスレッド処理を制御します。</span><span class="sxs-lookup"><span data-stu-id="6af55-159">Once you have created your **AsyncQueue** simply add it to the **AsyncBlock** to control threading on your work and completion functions.</span></span>
<span data-ttu-id="6af55-160">**AsyncQueue**を使用してが完了したら、通常、ゲームを終了すると、閉じることができますが**CloseAsyncQueue**と。</span><span class="sxs-lookup"><span data-stu-id="6af55-160">When you are finished using the **AsyncQueue**, typically when the game is ending, you can close it with **CloseAsyncQueue**:</span></span>

```cpp
STDAPI_(void) CloseAsyncQueue(
    _In_ async_queue_handle_t aQueue);
```

### <a name="manually-dispatching-an-asyncqueue"></a><span data-ttu-id="6af55-161">手動での **AsyncQueue** のディスパッチ</span><span class="sxs-lookup"><span data-stu-id="6af55-161">Manually dispatching an **AsyncQueue**</span></span>

<span data-ttu-id="6af55-162">**AsyncQueue** の作業または完了キューで、手動のキュー ディスパッチ モードを使用した場合、手動でディスパッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-162">If you used the manual queue dispatch mode for an **AsyncQueue** work or completion queue, you will need to manually dispatch.</span></span>
<span data-ttu-id="6af55-163">**AsyncQueue** は、次のように作業キューと完了キューの両方が手動でディスパッチするように設定されている場合のために作成されました。</span><span class="sxs-lookup"><span data-stu-id="6af55-163">Let us say that an **AsyncQueue** was created where both the work queue and the completion queue are set to dispatch manually like so:</span></span>

```cpp
CreateAsyncQueue(
    AsyncQueueDispatchMode_Manual,
    AsyncQueueDispatchMode_Manual,
    &queue);
```

<span data-ttu-id="6af55-164">**AsyncQueueDispatchMode_Manual** に割り当てられている作業をディスパッチするには、**DispatchAsyncQueue** 関数を使用してディスパッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-164">In order to dispatch work that has been assigned **AsyncQueueDispatchMode_Manual** you will have to dispatch it with the **DispatchAsyncQueue** function.</span></span>

```cpp
STDAPI_(bool) DispatchAsyncQueue(
    _In_ async_queue_handle_t queue,
    _In_ AsyncQueueCallbackType type,
    _In_ uint32_t timeoutInMs);
```

* <span data-ttu-id="6af55-165">*キュー* - 作業をディスパッチする対象のキュー。</span><span class="sxs-lookup"><span data-stu-id="6af55-165">*queue* - which queue to dispatch work on</span></span>
* <span data-ttu-id="6af55-166">*type* - **AsyncQueueCallbackType**列挙型のインスタンス。</span><span class="sxs-lookup"><span data-stu-id="6af55-166">*type* - an instance of the **AsyncQueueCallbackType** enum</span></span>
* <span data-ttu-id="6af55-167">*timeoutInMs* - ミリ秒単位のタイムアウトを表す uint32_t。</span><span class="sxs-lookup"><span data-stu-id="6af55-167">*timeoutInMs* - a uint32_t for the timeout in milliseconds.</span></span>

<span data-ttu-id="6af55-168">**AsyncQueueCallbackType**列挙型によって定義されるコールバックには、2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="6af55-168">There are two callback types defined by the **AsyncQueueCallbackType** enum:</span></span>

```cpp
typedef enum AsyncQueueCallbackType
{
    /// <summary>
    /// Async work callbacks
    /// </summary>
    AsyncQueueCallbackType_Work,

    /// <summary>
    /// Completion callbacks after work is done
    /// </summary>
    AsyncQueueCallbackType_Completion
} AsyncQueueCallbackType;
```

### <a name="when-to-call-dispatchasyncqueue"></a><span data-ttu-id="6af55-169">**DispatchAsyncQueue** を呼び出す場合</span><span class="sxs-lookup"><span data-stu-id="6af55-169">When to call **DispatchAsyncQueue**</span></span>

<span data-ttu-id="6af55-170">キューが新しい項目を受信したことを確認するために、**AddAsyncQueueCallbackSubmitted** を呼び出して、作業または完了をディスパッチする準備ができたことをコードで識別するためのイベント ハンドラーを設定できます。</span><span class="sxs-lookup"><span data-stu-id="6af55-170">In order to check when the queue has received a new item you can call **AddAsyncQueueCallbackSubmitted** to set an event handler to let your code know that either work or completions are ready to be dispatched.</span></span>

```cpp
STDAPI AddAsyncQueueCallbackSubmitted(
    _In_ async_queue_handle_t queue,
    _In_opt_ void* context,
    _In_ AsyncQueueCallbackSubmitted* callback,
    _Out_ uint32_t* token);
```

<span data-ttu-id="6af55-171">**AddAsyncQueueCallbackSubmitted** は次のパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="6af55-171">**AddAsyncQueueCallbackSubmitted** takes the following parameters:</span></span>

* <span data-ttu-id="6af55-172">*queue* - コールバックを送信している対象の非同期キュー。</span><span class="sxs-lookup"><span data-stu-id="6af55-172">*queue* - the async queue you are submitting the callback for.</span></span>
* <span data-ttu-id="6af55-173">*context* - 送信コールバックに渡す必要があるデータへのポインター。</span><span class="sxs-lookup"><span data-stu-id="6af55-173">*context* - a pointer to data that should be passed to the submit callback.</span></span>
* <span data-ttu-id="6af55-174">*callback* - 新しいコールバックがキューに送信されるときに呼び出される関数。</span><span class="sxs-lookup"><span data-stu-id="6af55-174">*callback* - the function that will be invoked when a new callback is submitted to the queue.</span></span>
* <span data-ttu-id="6af55-175">*token* - コールバックを削除するために、以降の **RemoveAsynceCallbackSubmitted** の呼び出しで使用されるトークン。</span><span class="sxs-lookup"><span data-stu-id="6af55-175">*token* - a token that will be used in a later call to **RemoveAsynceCallbackSubmitted** to remove the callback.</span></span>

<span data-ttu-id="6af55-176">たとえば、**AddAsyncQueueCallbackSubmitted** の呼び出しは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="6af55-176">For example, here is a call to **AddAsyncQueueCallbackSubmitted**:</span></span>

`AddAsyncQueueCallbackSubmitted(queue, nullptr, HandleAsyncQueueCallback, &m_callbackToken);`

<span data-ttu-id="6af55-177">対応する **AsyncQueueCallbackSubmitted** コールバックは次のように実装されます。</span><span class="sxs-lookup"><span data-stu-id="6af55-177">The corresponding **AsyncQueueCallbackSubmitted** callback might be implemented as follows:</span></span>

```cpp
void CALLBACK HandleAsyncQueueCallback(
    _In_ void* context,
    _In_ async_queue_handle_t queue,
    _In_ AsyncQueueCallbackType type)
{
    switch (type)
    {
    case AsyncQueueCallbackType::AsyncQueueCallbackType_Work:
        ReleaseSemaphore(g_workReadyHandle, 1, nullptr);
        break;
    }
}
```

<span data-ttu-id="6af55-178">バック グラウンド スレッドでをスリープ解除し、 **DispatchAsyncQueue**を呼び出すには、このセマフォをリッスンすることができます。</span><span class="sxs-lookup"><span data-stu-id="6af55-178">Then in a background thread you can listen for this semaphore to wake up and call **DispatchAsyncQueue**.</span></span>

```cpp
DWORD WINAPI BackgroundWorkThreadProc(LPVOID lpParam)
{
    HANDLE hEvents[2] =
    {
        g_workReadyHandle.get(),
        g_stopRequestedHandle.get()
    };

    async_queue_handle_t queue = static_cast<async_queue_handle_t>(lpParam);

    bool stop = false;
    while (!stop)
    {
        DWORD dwResult = WaitForMultipleObjectsEx(2, hEvents, false, INFINITE, false);
        switch (dwResult)
        {
        case WAIT_OBJECT_0: 
            // Background work is ready to be dispatched
            DispatchAsyncQueue(queue, AsyncQueueCallbackType_Work, 0);
            break;

        case WAIT_OBJECT_0 + 1:
        default:
            stop = true;
            break;
        }
    }

    CloseAsyncQueue(queue);
    return 0;
}
```

<span data-ttu-id="6af55-179">お勧め Win32 セマフォ オブジェクトを使用して実装を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6af55-179">It is best practice to use implement with Win32 Semaphore object.</span></span>  <span data-ttu-id="6af55-180">代わりに実装する場合、Win32 イベント オブジェクトを使用することを確認する必要があります忘れないすべてのイベントをコードで次のように。</span><span class="sxs-lookup"><span data-stu-id="6af55-180">If instead you implement using a Win32 Event object, then you'll need to ensure don't miss any events with code such as:</span></span>

```cpp
    case WAIT_OBJECT_0: 
        // Background work is ready to be dispatched
        DispatchAsyncQueue(queue, AsyncQueueCallbackType_Work, 0);        
        
        if (!IsAsyncQueueEmpty(queue, AsyncQueueCallbackType_Work))
        {
            // If there's more pending work, then set the event to process them
            SetEvent(g_workReadyHandle.get());
        }
        break;
```


<span data-ttu-id="6af55-181">[ソーシャル C サンプル AsyncIntegration.cpp](https://github.com/Microsoft/xbox-live-api/blob/master/InProgressSamples/Social/Xbox/C/AsyncIntegration.cpp)に非同期の統合のためのベスト プラクティスの例を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="6af55-181">You can view an example of the best practices for async integration at [Social C Sample AsyncIntegration.cpp](https://github.com/Microsoft/xbox-live-api/blob/master/InProgressSamples/Social/Xbox/C/AsyncIntegration.cpp)</span></span>

