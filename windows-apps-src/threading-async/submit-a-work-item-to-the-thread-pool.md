---
author: normesta
ms.assetid: E2A1200C-9583-40FA-AE4D-C9E6F6C32BCF
title: スレッド プールへの作業項目の送信
description: スレッド プールに作業項目を送信することで独立したスレッドで作業を実行する方法について説明します。
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, スレッド, スレッド プール
ms.localizationpriority: medium
ms.openlocfilehash: fe73520782b18fb7419807695296bc6487f9c018
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6967704"
---
# <a name="submit-a-work-item-to-the-thread-pool"></a><span data-ttu-id="0626c-104">スレッド プールへの作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="0626c-104">Submit a work item to the thread pool</span></span>

<span data-ttu-id="0626c-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="0626c-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="0626c-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="0626c-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="0626c-107">\*\* 重要な API \*\*</span><span class="sxs-lookup"><span data-stu-id="0626c-107">\*\* Important APIs \*\*</span></span>

-   [**<span data-ttu-id="0626c-108">RunAsync</span><span class="sxs-lookup"><span data-stu-id="0626c-108">RunAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR230593)
-   [**<span data-ttu-id="0626c-109">IAsyncAction</span><span class="sxs-lookup"><span data-stu-id="0626c-109">IAsyncAction</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206580)

<span data-ttu-id="0626c-110">スレッド プールに作業項目を送信することで独立したスレッドで作業を実行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0626c-110">Learn how to do work in a separate thread by submitting a work item to the thread pool.</span></span> <span data-ttu-id="0626c-111">これによって、非常に時間のかかる作業を実行しながら UI の応答性を確保でき、また複数のタスクを並行して実行することができます。</span><span class="sxs-lookup"><span data-stu-id="0626c-111">Use this to maintain a responsive UI while still completing work that takes a noticeable amount of time, and use it to complete multiple tasks in parallel.</span></span>

## <a name="create-and-submit-the-work-item"></a><span data-ttu-id="0626c-112">作業項目の作成と送信</span><span class="sxs-lookup"><span data-stu-id="0626c-112">Create and submit the work item</span></span>

<span data-ttu-id="0626c-113">[**RunAsync**](https://msdn.microsoft.com/library/windows/apps/BR230593) を呼び出して作業項目を作成します。</span><span class="sxs-lookup"><span data-stu-id="0626c-113">Create a work item by calling [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/BR230593).</span></span> <span data-ttu-id="0626c-114">作業を実行するデリゲートを指定します (ラムダやデリゲート関数を使うことができます)。</span><span class="sxs-lookup"><span data-stu-id="0626c-114">Supply a delegate to do the work (you can use a lambda, or a delegate function).</span></span> <span data-ttu-id="0626c-115">**RunAsync** が [**IAsyncAction**](https://msdn.microsoft.com/library/windows/apps/BR206580) オブジェクトを返すことに注意してください。このオブジェクトは次の手順で使うために格納しておきます。</span><span class="sxs-lookup"><span data-stu-id="0626c-115">Note that **RunAsync** returns an [**IAsyncAction**](https://msdn.microsoft.com/library/windows/apps/BR206580) object; store this object for use in the next step.</span></span>

<span data-ttu-id="0626c-116">3 つのバージョンの [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/BR230593) を使うことができるため、必要に応じて作業項目の優先度を指定し、他の作業項目と同時に実行するかどうかを制御できます。</span><span class="sxs-lookup"><span data-stu-id="0626c-116">Three versions of [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/BR230593) are available so that you can optionally specify the priority of the work item, and control whether it runs concurrently with other work items.</span></span>

>[!NOTE]
><span data-ttu-id="0626c-117">[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317)を使用して、UI スレッドにアクセスし、作業項目の進捗状況を表示します。</span><span class="sxs-lookup"><span data-stu-id="0626c-117">Use [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) to access the UI thread and show progress from the work item.</span></span>

<span data-ttu-id="0626c-118">次の例では作業項目を作成し、作業を実行するラムダを指定します。</span><span class="sxs-lookup"><span data-stu-id="0626c-118">The following example creates a work item and supplies a lambda to do the work:</span></span>

```csharp
// The nth prime number to find.
const uint n = 9999;

// A shared pointer to the result.
// We use a shared pointer to keep the result alive until the
// thread is done.
ulong nthPrime = 0;

// Simulates work by searching for the nth prime number. Uses a
// naive algorithm and counts 2 as the first prime number.
IAsyncAction asyncAction = Windows.System.Threading.ThreadPool.RunAsync(
    (workItem) =>
{
    uint  progress = 0; // For progress reporting.
    uint  primes = 0;   // Number of primes found so far.
    ulong i = 2;        // Number iterator.

    if ((n >= 0) && (n <= 2))
    {
        nthPrime = n;
        return;
    }

    while (primes < (n - 1))
    {
        if (workItem.Status == AsyncStatus.Canceled)
        {
            break;
        }

        // Go to the next number.
        i++;

        // Check for prime.
        bool prime = true;
        for (uint j = 2; j < i; ++j)
        {
            if ((i % j) == 0)
            {
                prime = false;
                break;
            }
        };

        if (prime)
        {
            // Found another prime number.
            primes++;

            // Report progress at every 10 percent.
            uint temp = progress;
            progress = (uint)(10.0*primes/n);

            if (progress != temp)
            {
                String updateString;
                updateString = "Progress to " + n + "th prime: "
                    + (10 * progress) + "%\n";

                // Update the UI thread with the CoreDispatcher.
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.High,
                    new DispatchedHandler(() =>
                {
                    UpdateUI(updateString);
                }));
            }
        }
    }

    // Return the nth prime number.
    nthPrime = i;
});

// A reference to the work item is cached so that we can trigger a
// cancellation when the user presses the Cancel button.
m_workItem = asyncAction;
```

```cppwinrt
// The nth prime number to find.
const unsigned int n{ 9999 };

unsigned long nthPrime{ 0 };

// Simulates work by searching for the nth prime number. Uses a
// naive algorithm and counts 2 as the first prime number.

// A reference to the work item is cached so that we can trigger a
// cancellation when the user presses the Cancel button.
m_workItem = Windows::System::Threading::ThreadPool::RunAsync([&](Windows::Foundation::IAsyncAction const& workItem)
{
    unsigned int progress = 0; // For progress reporting.
    unsigned int primes = 0;   // Number of primes found so far.
    unsigned long int i = 2;   // Number iterator.

    if ((n >= 0) && (n <= 2))
    {
        nthPrime = n;
        return;
    }

    while (primes < (n - 1))
    {
        if (workItem.Status() == Windows::Foundation::AsyncStatus::Canceled)
        {
            break;
        }

        // Go to the next number.
        i++;

        // Check for prime.
        bool prime = true;
        for (unsigned int j = 2; j < i; ++j)
        {
            if ((i % j) == 0)
            {
                prime = false;
                break;
            }
        };

        if (prime)
        {
            // Found another prime number.
            primes++;

            // Report progress at every 10 percent.
            unsigned int temp = progress;
            progress = static_cast<unsigned int>(10.f*primes / n);

            if (progress != temp)
            {
                std::wstringstream updateString;
                updateString << L"Progress to " << n << L"th prime: " << (10 * progress) << std::endl;

                // Update the UI thread with the CoreDispatcher.
                Windows::ApplicationModel::Core::CoreApplication::MainView().CoreWindow().Dispatcher().RunAsync(
                    Windows::UI::Core::CoreDispatcherPriority::High,
                    Windows::UI::Core::DispatchedHandler([&]()
                {
                    UpdateUI(updateString.str());
                }));
            }
        }
    }
    // Return the nth prime number.
    nthPrime = i;
});
```

```cpp
// The nth prime number to find.
const unsigned int n = 9999;

// A shared pointer to the result.
// We use a shared pointer to keep the result alive until the
// thread is done.
std::shared_ptr<unsigned long> nthPrime = make_shared<unsigned long int>(0);

// Simulates work by searching for the nth prime number. Uses a
// naive algorithm and counts 2 as the first prime number.
auto workItem = ref new WorkItemHandler(
    \[this, n, nthPrime](IAsyncAction^ workItem)
{
    unsigned int progress = 0; // For progress reporting.
    unsigned int primes = 0;   // Number of primes found so far.
    unsigned long int i = 2;   // Number iterator.

    if ((n >= 0) && (n <= 2))
    {
        *nthPrime = n;
        return;
    }

    while (primes < (n - 1))
    {
        if (workItem->Status == AsyncStatus::Canceled)
       {
           break;
       }

       // Go to the next number.
       i++;

       // Check for prime.
       bool prime = true;
       for (unsigned int j = 2; j < i; ++j)
       {
           if ((i % j) == 0)
           {
               prime = false;
               break;
           }
       };

       if (prime)
       {
           // Found another prime number.
           primes++;

           // Report progress at every 10 percent.
           unsigned int temp = progress;
           progress = static_cast<unsigned int>(10.f*primes / n);

           if (progress != temp)
           {
               String^ updateString;
               updateString = "Progress to " + n + "th prime: "
                   + (10 * progress).ToString() + "%\n";

               // Update the UI thread with the CoreDispatcher.
               CoreApplication::MainView->CoreWindow->Dispatcher->RunAsync(
                   CoreDispatcherPriority::High,
                   ref new DispatchedHandler([this, updateString]()
               {
                   UpdateUI(updateString);
               }));
           }
       }
   }
   // Return the nth prime number.
   *nthPrime = i;
});

auto asyncAction = ThreadPool::RunAsync(workItem);

// A reference to the work item is cached so that we can trigger a
// cancellation when the user presses the Cancel button.
m_workItem = asyncAction;
```

<span data-ttu-id="0626c-119">[**RunAsync**](https://msdn.microsoft.com/library/windows/apps/BR230593) が呼び出された後に、スレッド プールで作業項目がキューに入れられ、スレッドが使用可能になったときに実行されます。</span><span class="sxs-lookup"><span data-stu-id="0626c-119">Following the call to [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/BR230593), the work item is queued by the thread pool and runs when a thread becomes available.</span></span> <span data-ttu-id="0626c-120">スレッド プールの作業項目は非同期に実行されます。任意の順番で実行されることがあるため、作業項目は単独で機能するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="0626c-120">Thread pool work items run asynchronously and they can run in any order, so make sure your work items function independently.</span></span>

<span data-ttu-id="0626c-121">作業項目は [**IAsyncInfo.Status**](https://msdn.microsoft.com/library/windows/apps/BR206593) プロパティをチェックし、作業項目が取り消されている場合は終了することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0626c-121">Note that the work item checks the [**IAsyncInfo.Status**](https://msdn.microsoft.com/library/windows/apps/BR206593) property, and exits if the work item is cancelled.</span></span>

## <a name="handle-work-item-completion"></a><span data-ttu-id="0626c-122">作業項目の完了の処理</span><span class="sxs-lookup"><span data-stu-id="0626c-122">Handle work item completion</span></span>

<span data-ttu-id="0626c-123">作業項目の [**IAsyncAction.Completed**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.completed.aspx) プロパティを設定することで、完了ハンドラーを指定します。</span><span class="sxs-lookup"><span data-stu-id="0626c-123">Provide a completion handler by setting the [**IAsyncAction.Completed**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.completed.aspx) property of the work item.</span></span> <span data-ttu-id="0626c-124">作業項目の完了を処理するデリゲートを指定します (ラムダやデリゲート関数を使うことができます)。</span><span class="sxs-lookup"><span data-stu-id="0626c-124">Supply a delegate (you can use a lambda or a delegate function) to handle work item completion.</span></span> <span data-ttu-id="0626c-125">たとえば、UI スレッドにアクセスしたり、結果を表示したりするには、[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) を使います。</span><span class="sxs-lookup"><span data-stu-id="0626c-125">For example, use [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) to access the UI thread and show the result.</span></span>

<span data-ttu-id="0626c-126">次の例では、手順 1. で送信した作業項目の結果を使って UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="0626c-126">The following example updates the UI with the result of the work item submitted in step 1:</span></span>

```cpp
asyncAction->Completed = ref new AsyncActionCompletedHandler(
    \[this, n, nthPrime](IAsyncAction^ asyncInfo, AsyncStatus asyncStatus)
{
    if (asyncStatus == AsyncStatus::Canceled)
    {
        return;
    }

    String^ updateString;
    updateString = "\n" + "The " + n + "th prime number is "
        + (*nthPrime).ToString() + ".\n";

    // Update the UI thread with the CoreDispatcher.
    CoreApplication::MainView->CoreWindow->Dispatcher->RunAsync(
        CoreDispatcherPriority::High,
        ref new DispatchedHandler([this, updateString]()
    {
        UpdateUI(updateString);
    }));
});
```

```cppwinrt
m_workItem.Completed([&](Windows::Foundation::IAsyncAction const& asyncInfo, Windows::Foundation::AsyncStatus const& asyncStatus)
{
    if (asyncStatus == Windows::Foundation::AsyncStatus::Canceled)
    {
        return;
    }

    std::wstringstream updateString;
    updateString << std::endl << L"The " << n << L"th prime number is " << nthPrime << std::endl;

    // Update the UI thread with the CoreDispatcher.
    Windows::ApplicationModel::Core::CoreApplication::MainView().CoreWindow().Dispatcher().RunAsync(
        Windows::UI::Core::CoreDispatcherPriority::High,
        Windows::UI::Core::DispatchedHandler([&]()
    {
        UpdateUI(updateString.str());
    }));
});
```

```c#
asyncAction.Completed = new AsyncActionCompletedHandler(
    (IAsyncAction asyncInfo, AsyncStatus asyncStatus) =>
{
    if (asyncStatus == AsyncStatus.Canceled)
    {
        return;
    }

    String updateString;
    updateString = "\n" + "The " + n + "th prime number is "
        + nthPrime + ".\n";

    // Update the UI thread with the CoreDispatcher.
    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
        CoreDispatcherPriority.High,
        new DispatchedHandler(()=>
    {
        UpdateUI(updateString);
    }));
});
```

<span data-ttu-id="0626c-127">完了ハンドラーは、UI 更新をディスパッチする前に作業項目が取り消されたかどうかをチェックします。</span><span class="sxs-lookup"><span data-stu-id="0626c-127">Note that the completion handler checks whether the work item was cancelled before dispatching a UI update.</span></span>

## <a name="summary-and-next-steps"></a><span data-ttu-id="0626c-128">要約と次の手順</span><span class="sxs-lookup"><span data-stu-id="0626c-128">Summary and next steps</span></span>

<span data-ttu-id="0626c-129">[項目のサンプルを使用して、スレッド プールを作成](http://go.microsoft.com/fwlink/p/?LinkID=328569)、Windows8.1 向けに書かれたでこのクイック スタートのコードのダウンロードの詳細については、win \_unap windows 10 アプリでソース コードを再利用しているとします。</span><span class="sxs-lookup"><span data-stu-id="0626c-129">You can learn more by downloading the code from this quickstart in the [Creating a ThreadPool work item sample](http://go.microsoft.com/fwlink/p/?LinkID=328569) written for Windows8.1, and re-using the source code in a win\_unap Windows10 app.</span></span>

## <a name="related-topics"></a><span data-ttu-id="0626c-130">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0626c-130">Related topics</span></span>

* [<span data-ttu-id="0626c-131">スレッド プールへの作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="0626c-131">Submit a work item to the thread pool</span></span>](submit-a-work-item-to-the-thread-pool.md)
* [<span data-ttu-id="0626c-132">スレッド プールを使うためのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="0626c-132">Best practices for using the thread pool</span></span>](best-practices-for-using-the-thread-pool.md)
* [<span data-ttu-id="0626c-133">タイマーを使った作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="0626c-133">Use a timer to submit a work item</span></span>](use-a-timer-to-submit-a-work-item.md)
 
