---
author: normesta
ms.assetid: 95CF7F3D-9E3A-40AC-A083-D8A375272181
title: スレッド プールを使うためのベスト プラクティス
description: このトピックでは、スレッド プールを使った操作のベスト プラクティスについて説明します。
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、スレッド、スレッド プール
ms.localizationpriority: medium
ms.openlocfilehash: ff607e3b39ea9d9a3731cc1f231fe1eb27b0b155
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6456468"
---
# <a name="best-practices-for-using-the-thread-pool"></a><span data-ttu-id="241fb-104">スレッド プールを使うためのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="241fb-104">Best practices for using the thread pool</span></span>

<span data-ttu-id="241fb-105">このトピックでは、スレッド プールを使った操作のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="241fb-105">This topic describes best practices for working with the thread pool.</span></span>

## <a name="dos"></a><span data-ttu-id="241fb-106">推奨</span><span class="sxs-lookup"><span data-stu-id="241fb-106">Do's</span></span>


-   <span data-ttu-id="241fb-107">スレッド プールを使って、アプリの並列処理を実行します。</span><span class="sxs-lookup"><span data-stu-id="241fb-107">Use the thread pool to do parallel work in your app.</span></span>

-   <span data-ttu-id="241fb-108">作業項目を使って、UI スレッドをブロックせずに広範なタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="241fb-108">Use work items to accomplish extended tasks without blocking the UI thread.</span></span>

-   <span data-ttu-id="241fb-109">有効期間が短く独立した作業項目を作成します。</span><span class="sxs-lookup"><span data-stu-id="241fb-109">Create work items that are short-lived and independent.</span></span> <span data-ttu-id="241fb-110">作業項目は非同期に実行され、キューから任意の順番でプールに送ることができます。</span><span class="sxs-lookup"><span data-stu-id="241fb-110">Work items run asynchronously and they can be submitted to the pool in any order from the queue.</span></span>

-   <span data-ttu-id="241fb-111">[**Windows.UI.Core.CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) を使って更新を UI スレッドにディスパッチします。</span><span class="sxs-lookup"><span data-stu-id="241fb-111">Dispatch updates to the UI thread with the [**Windows.UI.Core.CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211).</span></span>

-   <span data-ttu-id="241fb-112">**Sleep** 関数ではなく [**ThreadPoolTimer.CreateTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967921) 関数を使います。</span><span class="sxs-lookup"><span data-stu-id="241fb-112">Use [**ThreadPoolTimer.CreateTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967921) instead of the **Sleep** function.</span></span>

-   <span data-ttu-id="241fb-113">独自のスレッド管理システムを作成するのではなく、スレッド プールを使います。</span><span class="sxs-lookup"><span data-stu-id="241fb-113">Use the thread pool instead of creating your own thread management system.</span></span> <span data-ttu-id="241fb-114">スレッド プールは、OS レベルで高度な機能を使って実行され、プロセス内およびシステム全体のデバイス リソースとアクティビティに従って動的にスケーリングされるように最適化されています。</span><span class="sxs-lookup"><span data-stu-id="241fb-114">The thread pool runs at the OS level with advanced capability and is optimized to dynamically scale according to device resources and activity within the process and across the system.</span></span>

-   <span data-ttu-id="241fb-115">C++ の場合、作業項目委任でアジャイル スレッド モデルを使うようにします (C++ 委任は既定でアジャイルです)。</span><span class="sxs-lookup"><span data-stu-id="241fb-115">In C++, ensure that work item delegates use the agile threading model (C++ delegates are agile by default).</span></span>

-   <span data-ttu-id="241fb-116">使用の時点でリソース割り当ての失敗を許容できない場合は、あらかじめ割り当てられた作業項目を使用します。</span><span class="sxs-lookup"><span data-stu-id="241fb-116">Use pre-allocated work items when you can't tolerate a resource allocation failure at time of use.</span></span>

## <a name="donts"></a><span data-ttu-id="241fb-117">非推奨</span><span class="sxs-lookup"><span data-stu-id="241fb-117">Don'ts</span></span>


-   <span data-ttu-id="241fb-118">*period* の値が 1 ミリ秒未満 (0 秒を含む) の定期タイマーを作成しないでください。</span><span class="sxs-lookup"><span data-stu-id="241fb-118">Don't create periodic timers with a *period* value of &lt;1 millisecond (including 0).</span></span> <span data-ttu-id="241fb-119">この場合、作業項目は 1 回限りのタイマーとして動作します。</span><span class="sxs-lookup"><span data-stu-id="241fb-119">This will cause the work item to behave as a single-shot timer.</span></span>

-   <span data-ttu-id="241fb-120">*period* パラメーターで指定した時間よりも完了までに時間がかかる定期的な作業項目を送信しないでください。</span><span class="sxs-lookup"><span data-stu-id="241fb-120">Don't submit periodic work items that take longer to complete than the amount of time you specified in the *period* parameter.</span></span>

-   <span data-ttu-id="241fb-121">バックグラウンド タスクからディスパッチされている作業項目から、UI 更新 (トーストと通知を除く) を送信しないでください。</span><span class="sxs-lookup"><span data-stu-id="241fb-121">Don't try to send UI updates (other than toasts and notifications) from a work item dispatched from a background task.</span></span> <span data-ttu-id="241fb-122">代わりに、バックグラウンド タスクの進行ハンドラーと完了ハンドラー ([**IBackgroundTaskInstance.Progress**](https://msdn.microsoft.com/library/windows/apps/BR224800) など) を使います。</span><span class="sxs-lookup"><span data-stu-id="241fb-122">Instead, use background task progress and completion handlers - for example, [**IBackgroundTaskInstance.Progress**](https://msdn.microsoft.com/library/windows/apps/BR224800).</span></span>

-   <span data-ttu-id="241fb-123">**async** キーワードを使用する作業項目ハンドラーを使用する場合は、ハンドラーのすべてのコードの実行が完了する前にスレッド プール作業項目が完了状態に設定される可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="241fb-123">When you use work-item handlers that use the **async** keyword, be aware that the thread pool work item may be set to the complete state before all of the code in the handler has executed.</span></span> <span data-ttu-id="241fb-124">ハンドラー内の **await** キーワードに続くコードは、作業項目が完了状態に設定された後で実行される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="241fb-124">Code following an **await** keyword within the handler may execute after the work item has been set to the complete state.</span></span>

-   <span data-ttu-id="241fb-125">あらかじめ割り当てられた作業項目を複数回実行する場合は、1 回実行するたびに再初期化してください。</span><span class="sxs-lookup"><span data-stu-id="241fb-125">Don't try to run a pre-allocated work item more than once without reinitializing it.</span></span> [<span data-ttu-id="241fb-126">定期的な作業項目の作成</span><span class="sxs-lookup"><span data-stu-id="241fb-126">Create a periodic work item</span></span>](create-a-periodic-work-item.md)

## <a name="related-topics"></a><span data-ttu-id="241fb-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="241fb-127">Related topics</span></span>


* [<span data-ttu-id="241fb-128">定期的な作業項目の作成</span><span class="sxs-lookup"><span data-stu-id="241fb-128">Create a periodic work item</span></span>](create-a-periodic-work-item.md)
* [<span data-ttu-id="241fb-129">スレッド プールへの作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="241fb-129">Submit a work item to the thread pool</span></span>](submit-a-work-item-to-the-thread-pool.md)
* [<span data-ttu-id="241fb-130">タイマーを使った作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="241fb-130">Use a timer to submit a work item</span></span>](use-a-timer-to-submit-a-work-item.md)
