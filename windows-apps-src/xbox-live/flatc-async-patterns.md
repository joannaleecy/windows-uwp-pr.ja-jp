---
title: 非同期 C API の呼び出しパターン
author: aablackm
description: XSAPI C API の非同期 C API 呼び出しパターンについて説明します。
ms.author: aablackm
ms.date: 06/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 開発者プログラム,
ms.localizationpriority: medium
ms.openlocfilehash: 50d747128dcd85a16c5250997e9431b279203ae0
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4084118"
---
# <a name="calling-pattern-for-xsapi-flat-c-layer-async-calls"></a>XSAPI フラット C レイヤーの非同期呼び出しの呼び出しパターン

**非同期 API** は、すばやくを制御を返し、**非同期タスク**を開始する API で、タスクが完了すると結果が返されます。

従来のゲームでは、**完了コールバック**を使用する場合に、どのスレッドが**非同期タスク**を実行し、どのスレッドが結果を返すかをほとんど制御していません。  ゲームによっては、スレッドの同期の必要性を回避するために、ヒープのセクションを 1 つのスレッドでのみ操作できるように設計されているものもあります。 **完了コールバック**が、ゲームが制御するスレッドから呼び出されていない場合、**非同期タスク**の結果で共有状態を更新するには、スレッドの同期が必要になります。

XSAPI C API が公開する新しい非同期 C API では、開発者は、**XblSocialGetSocialRelationshipsAsync()**、**XblProfileGetUserProfileAsync()**、**XblAchievementsGetAchievementsForTitleIdAsync()** などの**非同期 API** 呼び出しを行う際に直接スレッドを制御できます。

**XblProfileGetUserProfileAsync** API の基本的な呼び出しのサンプルを以下に示します。

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

この呼び出しのパターンを理解するには、**AsyncBlock** と **AsyncQueue** の使用方法を理解する必要があります。

* **AsyncBlock** は、**非同期タスク**と**完了コールバック**に関連するすべての情報を保持します。

* **AsyncQueue** によって、**非同期タスク**を実行するスレッドと、AsyncBlock の**完了コールバック**を呼び出すスレッドを決定することができます。

## <a name="the-asyncblock"></a>**AsyncBlock**

**AsyncBlock** を詳しく見てみましょう。 これは、次のように定義された構造体です。

```cpp
typedef struct AsyncBlock
{
    AsyncCompletionRoutine* callback;
    void* context;
    async_queue_handle_t queue;
} AsyncBlock;
```

**AsyncBlock** には、次の要素が含まれます。

* *callback* - 非同期処理が完了した後に呼び出される、オプションのコールバック関数。  コールバックを指定しない場合、**GetAsyncStatus** を使用して **AsyncBlock** が完了するまで待機し、結果を取得します。
* *context* - データをコールバック関数に渡すことができるようにします。
* *queue* - **AsyncQueue** を指定するハンドルである async_queue_handle_t。 これが設定されていない場合、既定のキューが使用されます。

各非同期 API を呼び出すのヒープでは、新しい AsyncBlock を作成する必要があります。  AsyncBlock の完了コールバックが呼び出され、削除し、まで、AsyncBlock はライブする必要があります。

> [!IMPORTANT]
> **AsyncBlock** は、**非同期タスク**が完了するまでメモリ内に存在している必要があります。 動的に割り当てられる場合、AsyncBlock の**完了コールバック**内で削除できます。

### <a name="waiting-for-asynchronous-task"></a>**非同期タスク**の待機

**非同期タスク**が完了したことは、さまざまな方法で知ることができます。

* AsyncBlock の**完了コールバック**が呼び出される。
* **GetAsyncStatus** を呼び出して、true の場合は非同期タスクが完了するまで待機する。
* **AsyncBlock** で waitEvent を設定し、このイベントが通知されるまで待機する。

**GetAsyncStatus** と waitEvent では、**非同期タスク** は、AsyncBlock の**完了コールバック**が実行された後、完了したと見なされますが、AsyncBlock の**完了コールバック**は省略可能です。

**非同期タスク**が完了したら、結果を取得できます。

### <a name="getting-the-result-of-the-asynchronous-task"></a>**非同期タスク**の結果の取得

結果を取得するために、ほとんどの**非同期 API** 関数には、非同期呼び出しの結果を受け取るための対応する \[関数名\]Result 関数があります。 コード例の場合、**XblProfileGetUserProfileAsync** には、対応する **XblProfileGetUserProfileResult** 関数があります。 この関数を使用して、関数の結果を返し、それに応じて処理を実行できます。  結果の取得について詳しくは、それぞれの**非同期 API** のドキュメントを参照してください。

## <a name="the-asyncqueue"></a>**AsyncQueue**

**AsyncQueue** によって、**非同期タスク**を実行するスレッドと、AsyncBlock の**完了コールバック**を呼び出すスレッドを決定することができます。

*ディスパッチ モード*を設定することによって、どのスレッドがこれらの処理を実行するかを制御できます。 次の 3 つのディスパッチ モードを使用できます。

* *手動* - 手動のキューは自動的にディスパッチされません。  開発者が、必要なスレッドに処理をディスパッチする必要があります。 これを使用して、非同期呼び出しの作業側またはコールバック側のいずれかを特定のスレッドに割り当てることができます。  これについては、以下で詳しく説明します。

* *スレッド プール* - スレッド プールを使用してディスパッチします。  スレッド プールは、スレッド プールのスレッドが利用可能になると、キューから順番に実行する呼び出しを取り出して、呼び出しを並行して実行します。  これは、使用するのは最も簡単ですが、使用するスレッドの制御は最小限になります。

* *固定スレッド* - 非同期キューを作成したスレッドで QueueUserAPC を使用してディスパッチします。 ユーザー モード APC がキューに入れられたときに、このスレッドがアラート可能な状態である場合を除き、スレッドは APC 関数を呼び出すよう指示されません。 **SleepEx**、**SignalObjectAndWait**、**WaitForSingleObjectEx**、**WaitForMultipleObjectsEx**、または**MsgWaitForMultipleObjectsEx** を使用してアラート可能な待機操作を実行することによって、スレッドはアラート可能な状態になります。

新しい **AsyncQueue** を作成するには、**CreateAsyncQueue** を呼び出す必要があります。

```cpp
STDAPI CreateAsyncQueue(
    _In_ AsyncQueueDispatchMode workDispatchMode,
    _In_ AsyncQueueDispatchMode completionDispatchMode,
    _Out_ async_queue_handle_t* queue);
```

ここで、AsyncQueueDispatchMode には、前に紹介した 3 つのディスパッチ モードが含まれています。

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

**workDispatchMode** は、非同期操作を処理するスレッドのディスパッチ モードを決定し、**completionDispatchMode** は、非同期操作の完了を処理するスレッドのディスパッチ モードを決定します。

**CreateSharedAsyncQueue** を呼び出し、キューの ID を指定することで、同じ種類のキューを使用して **AsyncQueue** を作成することもできます。

```cpp
STDAPI CreateSharedAsyncQueue(
    _In_ uint32_t id,
    _In_ AsyncQueueDispatchMode workerMode,
    _In_ AsyncQueueDispatchMode completionMode,
    _Out_ async_queue_handle_t* aQueue);
```

> [!NOTE]
> この ID を持つ、ディスパッチ モードのキューが既にある場合は、そのキューが参照されます。  それ以外の場合は、新しいキューが作成されます。

**AsyncQueue** を作成したら、単にそれを **AsyncBlock** に追加し、作業と完了関数のスレッド処理を制御します。
**AsyncQueue**を使用してが完了したら、通常、ゲームを終了すると、閉じることができますが**CloseAsyncQueue**で。

```cpp
STDAPI_(void) CloseAsyncQueue(
    _In_ async_queue_handle_t aQueue);
```

### <a name="manually-dispatching-an-asyncqueue"></a>手動での **AsyncQueue** のディスパッチ

**AsyncQueue** の作業または完了キューで、手動のキュー ディスパッチ モードを使用した場合、手動でディスパッチする必要があります。
**AsyncQueue** は、次のように作業キューと完了キューの両方が手動でディスパッチするように設定されている場合のために作成されました。

```cpp
CreateAsyncQueue(
    AsyncQueueDispatchMode_Manual,
    AsyncQueueDispatchMode_Manual,
    &queue);
```

**AsyncQueueDispatchMode_Manual** に割り当てられている作業をディスパッチするには、**DispatchAsyncQueue** 関数を使用してディスパッチする必要があります。

```cpp
STDAPI_(bool) DispatchAsyncQueue(
    _In_ async_queue_handle_t queue,
    _In_ AsyncQueueCallbackType type,
    _In_ uint32_t timeoutInMs);
```

* *キュー* - 作業をディスパッチする対象のキュー。
* *type* - **AsyncQueueCallbackType**列挙型のインスタンス。
* *timeoutInMs* - ミリ秒単位のタイムアウトを表す uint32_t。

**AsyncQueueCallbackType**列挙型によって定義されるコールバックには、2 つの種類があります。

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

### <a name="when-to-call-dispatchasyncqueue"></a>**DispatchAsyncQueue** を呼び出す場合

キューが新しい項目を受信したことを確認するために、**AddAsyncQueueCallbackSubmitted** を呼び出して、作業または完了をディスパッチする準備ができたことをコードで識別するためのイベント ハンドラーを設定できます。

```cpp
STDAPI AddAsyncQueueCallbackSubmitted(
    _In_ async_queue_handle_t queue,
    _In_opt_ void* context,
    _In_ AsyncQueueCallbackSubmitted* callback,
    _Out_ uint32_t* token);
```

**AddAsyncQueueCallbackSubmitted** は次のパラメーターを受け取ります。

* *queue* - コールバックを送信している対象の非同期キュー。
* *context* - 送信コールバックに渡す必要があるデータへのポインター。
* *callback* - 新しいコールバックがキューに送信されるときに呼び出される関数。
* *token* - コールバックを削除するために、以降の **RemoveAsynceCallbackSubmitted** の呼び出しで使用されるトークン。

たとえば、**AddAsyncQueueCallbackSubmitted** の呼び出しは次のようになります。

`AddAsyncQueueCallbackSubmitted(queue, nullptr, HandleAsyncQueueCallback, &m_callbackToken);`

対応する **AsyncQueueCallbackSubmitted** コールバックは次のように実装されます。

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

バック グラウンド スレッドでをスリープ解除し、 **DispatchAsyncQueue**を呼び出すには、このセマフォをリッスンすることができます。

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

お勧め Win32 セマフォ オブジェクトを使用して実装を使用することをお勧めします。  代わりに実装する場合、Win32 イベント オブジェクトを使用することを確認する必要があります忘れないすべてのイベントをコードで次のように。

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


[ソーシャル C サンプル AsyncIntegration.cpp](https://github.com/Microsoft/xbox-live-api/blob/master/InProgressSamples/Social/Xbox/C/AsyncIntegration.cpp)に非同期の統合のためのベスト プラクティスの例を表示することができます。

