---
title: バックグラウンドで無期限に実行する
description: extendedExecutionUnconstrained 機能を使用すると、バックグラウンドで無期限にバックグラウンド タスクまたは延長実行セッションを実行できます。
ms.assetid: 6E48B8B6-D3BF-4AE2-85FB-D463C448C9D3
keywords: バック グラウンド タスク、延長実行セッション, リソース, 制限, バック グラウンド タスク
ms.date: 10/3/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: aedd948fe58efcc3edc160db971478189d9cb4ad
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7846090"
---
# <a name="run-in-the-background-indefinitely"></a><span data-ttu-id="65c81-104">バックグラウンドで無期限に実行する</span><span class="sxs-lookup"><span data-stu-id="65c81-104">Run in the background indefinitely</span></span>

<span data-ttu-id="65c81-105">ユーザーに最適なエクスペリエンスを提供するために、Windows によりユニバーサル Windows プラットフォーム (UWP) アプリにリソース制限が適用されます。</span><span class="sxs-lookup"><span data-stu-id="65c81-105">To provide the best experience for users, Windows imposes resource limits on Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="65c81-106">フォアグラウンド アプリに最も多くのメモリ量と実行時間が割り当てられ、バックグラウンド アプリへの割り当ては少なくなります。</span><span class="sxs-lookup"><span data-stu-id="65c81-106">Foreground apps are given the most memory and execution time; background apps get less.</span></span> <span data-ttu-id="65c81-107">これによってユーザーは、フォアグラウンド アプリのパフォーマンスを維持し、大量のバッテリ消費を回避できます。</span><span class="sxs-lookup"><span data-stu-id="65c81-107">Users are thus protected from poor foreground app performance and heavy battery drain.</span></span>

<span data-ttu-id="65c81-108">ただし、個人利用を目的とした UWP アプリ (Microsoft Store で公開しないサイドローディング アプリ) を作成する場合や、エンタープライズ UWP アプリを作成する場合は、バックグラウンド実行や延長実行の調整を指定せずに、すべてのリソースをデバイスで利用可能にしておくこともできます。</span><span class="sxs-lookup"><span data-stu-id="65c81-108">However, developers writing UWP apps for personal use (that is, side loaded apps that won't be published in the Microsoft Store), or developers writing Enterprise UWP apps, may want to use all resources available on the device without any background or extended execution throttling.</span></span> <span data-ttu-id="65c81-109">基幹アプリケーションや個人用の UWP アプリケーションでは、Windows Creators Update (Version 1703) の API を使用して、調整をオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="65c81-109">Line of business and personal UWP applications can use APIs in the Windows Creators Update (version 1703) to turn off throttling.</span></span> <span data-ttu-id="65c81-110">ただし、これらの API を使用している場合はアプリを Microsoft Store に公開できないため、注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="65c81-110">Be aware that you can't put an app into the Microsoft Store if it uses these APIs.</span></span>

## <a name="run-while-minimized"></a><span data-ttu-id="65c81-111">最小化状態での実行</span><span class="sxs-lookup"><span data-stu-id="65c81-111">Run while minimized</span></span>

<span data-ttu-id="65c81-112">フォアグラウンドで実行されていない UWP アプリは一時停止状態になります。</span><span class="sxs-lookup"><span data-stu-id="65c81-112">UWP apps move to a suspended state when they are not running in the foreground.</span></span> <span data-ttu-id="65c81-113">デスクトップでは、ユーザーがアプリを最小化すると、この状態になります。</span><span class="sxs-lookup"><span data-stu-id="65c81-113">On desktop, this occurs when a user minimizes the app.</span></span> <span data-ttu-id="65c81-114">最小化状態でもアプリの実行を継続するには、延長実行セッションを使用します。</span><span class="sxs-lookup"><span data-stu-id="65c81-114">Apps use an extended execution session in order to continue running while minimized.</span></span> <span data-ttu-id="65c81-115">Microsoft Store で承認されている延長実行 API については、「[延長実行を使ってアプリの中断を延期する](https://docs.microsoft.com/windows/uwp/launch-resume/run-minimized-with-extended-execution)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="65c81-115">The extended execution APIs that are accepted by the Microsoft Store are detailed in [Postpone app suspension with extended execution](https://docs.microsoft.com/windows/uwp/launch-resume/run-minimized-with-extended-execution).</span></span>

<span data-ttu-id="65c81-116">開発中のアプリを Microsoft Store に提出する予定がない場合は、制限された機能 `extendedExecutionUnconstrained` を指定して [ExtendedExecutionForegroundSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundsession) を使用できます。これにより、アプリはデバイスの電力状態を問わず、最小化状態でも実行を継続します。</span><span class="sxs-lookup"><span data-stu-id="65c81-116">If you are developing an app that is not intended to be submitted into the Microsoft Store, then you can use the [ExtendedExecutionForegroundSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundsession) with the `extendedExecutionUnconstrained` restricted capability so that your app can continue to run while minimized, regardless of the energy state of the device.</span></span>  

<span data-ttu-id="65c81-117">`extendedExecutionUnconstrained` 機能は、制限された機能としてアプリのマニフェストに追加されます。</span><span class="sxs-lookup"><span data-stu-id="65c81-117">The `extendedExecutionUnconstrained` capability is added as a restricted capability in your app's manifest.</span></span> <span data-ttu-id="65c81-118">制限された機能について詳しくは、「[アプリ機能の宣言](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="65c81-118">See [App capability declarations](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations) for more information about restricted capabilities.</span></span>

_<span data-ttu-id="65c81-119">Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="65c81-119">Package.appxmanifest</span></span>_
```xml
<Package ...>
...
  <Capabilities>  
    <rescap:Capability Name="extendedExecutionUnconstrained"/>  
  </Capabilities>  
</Package>
```

<span data-ttu-id="65c81-120">`extendedExecutionUnconstrained` 機能を使用する場合は、[ExtendedExecutionSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.extendedexecutionsession) と [ExtendedExecutionReason](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.extendedexecutionreason) ではなく [ExtendedExecutionForegroundSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundsession) と [ExtendedExecutionForegroundReason](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundreason) が使用されます。</span><span class="sxs-lookup"><span data-stu-id="65c81-120">When you use the `extendedExecutionUnconstrained` capability, [ExtendedExecutionForegroundSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundsession) and [ExtendedExecutionForegroundReason](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundreason) are used rather than [ExtendedExecutionSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.extendedexecutionsession) and [ExtendedExecutionReason](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.extendedexecutionreason).</span></span> <span data-ttu-id="65c81-121">この場合も、セッションの作成、メンバーの設定、非同期的な延長要求は同じパターンになります。</span><span class="sxs-lookup"><span data-stu-id="65c81-121">The same pattern for creating the session, setting members, and requesting the extension asynchronously still applies:</span></span> 

```cs
var newSession = new ExtendedExecutionForegroundSession();  
newSession.Reason = ExtendedExecutionForegroundReason.Unconstrained;  
newSession.Description = "Long Running Processing";  
newSession.Revoked += SessionRevoked;  
ExtendedExecutionResult result = await newSession.RequestExtensionAsync();  
switch (result)  
{  
    case ExtendedExecutionResult.Allowed:  
        DoLongRunningWork();  
        break;  

    default:  
    case ExtendedExecutionResult.Denied:  
        DoShortRunningWork();  
        break;  
}
```

<span data-ttu-id="65c81-122">アプリがフォアグラウンドになるとすぐに、この延長実行セッションを要求できます。</span><span class="sxs-lookup"><span data-stu-id="65c81-122">You can request this extended execution session as soon as the app comes to the foreground.</span></span> <span data-ttu-id="65c81-123">制限のない延長実行セッションは、割り当て電力やオペレーティング システムのバッテリー節約機能によって制限されません。</span><span class="sxs-lookup"><span data-stu-id="65c81-123">Unconstrained extended execution sessions are not limited by energy quotas or by the operating system battery saver.</span></span> <span data-ttu-id="65c81-124">セッション オブジェクトへの参照が存在する限り、アプリは実行状態を維持し、中断状態に移行しません。</span><span class="sxs-lookup"><span data-stu-id="65c81-124">As long as a reference to the session object exists, the app will stay in the running state and not enter the suspended state.</span></span> <span data-ttu-id="65c81-125">ユーザーによってアプリが閉じられると、セッションは失効します。</span><span class="sxs-lookup"><span data-stu-id="65c81-125">If the app is closed by the user, the session will be revoked.</span></span>

<span data-ttu-id="65c81-126">**Revoked** イベントに登録すると、アプリは必要なクリーンアップ作業を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="65c81-126">Registering for the **Revoked** event will enable your app to do any cleanup work required.</span></span> <span data-ttu-id="65c81-127">中断状態では、[ExtendedExecutionReason.SavingData](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.extendedexecutionreason) を使用して延長実行セッションを作成することにより、アプリが中断されメモリから削除される前にユーザー データを保存できます。</span><span class="sxs-lookup"><span data-stu-id="65c81-127">In the suspending state, you can create an extended execution session with   [ExtendedExecutionReason.SavingData](https://docs.microsoft.com/uwp/api/windows.applicationmodel.extendedexecution.extendedexecutionreason) to save user data before the app is terminated and removed from memory.</span></span>

## <a name="run-background-tasks-indefinitely"></a><span data-ttu-id="65c81-128">バックグラウンド タスクを無期限に実行する</span><span class="sxs-lookup"><span data-stu-id="65c81-128">Run background tasks indefinitely</span></span>

<span data-ttu-id="65c81-129">ユニバーサル Windows プラットフォームのバックグラウンド タスクは、どのような形のユーザー インターフェイスも持たない、バックグラウンドで実行されるプロセスです。</span><span class="sxs-lookup"><span data-stu-id="65c81-129">In the Universal Windows Platform, background tasks are processes that run in the background without any form of user interface.</span></span> <span data-ttu-id="65c81-130">一般的に、バックグラウンド タスクは取り消されるまで最長で 25 秒間実行できます。</span><span class="sxs-lookup"><span data-stu-id="65c81-130">Background tasks may generally run for a maximum of twenty-five seconds before they are cancelled.</span></span> <span data-ttu-id="65c81-131">長時間実行されるタスクについても、バックグラウンド タスクのアイドル状態やメモリ使用について確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="65c81-131">Some of the longer-running tasks also have a check to ensure that the background task is not sitting idle or using memory.</span></span> <span data-ttu-id="65c81-132">Windows Creators Update (Version 1703) では、制限された機能 [extendedBackgroundTaskTime](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations) が導入され、これらの制限が解消されました。</span><span class="sxs-lookup"><span data-stu-id="65c81-132">In the Windows Creators Update (version 1703), the [extendedBackgroundTaskTime](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations) restricted capability was introduced to remove these limits.</span></span> <span data-ttu-id="65c81-133">**extendedBackgroundTaskTime** 機能は、制限された機能としてアプリのマニフェスト ファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="65c81-133">The **extendedBackgroundTaskTime** capability is added as a restricted capability in your app's manifest file:</span></span>

_<span data-ttu-id="65c81-134">Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="65c81-134">Package.appxmanifest</span></span>_
```xml
<Package ...>
   <Capabilities>  
       <rescap:Capability Name="extendedBackgroundTaskTime"/>  
   </Capabilities>  
</Package>
```

<span data-ttu-id="65c81-135">この機能を使用すると、実行時間の制限とアイドル タスクに対するウォッチドッグが解除されます。</span><span class="sxs-lookup"><span data-stu-id="65c81-135">This capability removes execution time limitations and the idle task watchdog.</span></span> <span data-ttu-id="65c81-136">トリガーまたはアプリ サービスの呼び出しによってバックグラウンド タスクが開始され、**Run** メソッドで指定された [BackgroundTaskInstance](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.IBackgroundTaskInstance) によって延期されると、そのバックグラウンド タスクは無期限に実行されます。</span><span class="sxs-lookup"><span data-stu-id="65c81-136">Once a background task has started, whether by a trigger or an app service call, once it takes a deferral on the [BackgroundTaskInstance](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.IBackgroundTaskInstance) provided by the **Run** method, it can run indefinitely.</span></span> <span data-ttu-id="65c81-137">アプリが **[Windows で管理]** に設定されている場合は、割り当て電力が指定されていることがあり、バッテリー節約機能が有効であればバックグラウンド タスクがアクティブになりません。</span><span class="sxs-lookup"><span data-stu-id="65c81-137">If the app is set to **Managed By Windows**, then it still may have an energy quota applied to it, and its background tasks will not activated when Battery Saver is active.</span></span><span data-ttu-id="65c81-138">この動作は OS の設定で変更できます。</span><span class="sxs-lookup"><span data-stu-id="65c81-138"> This can be changed with OS settings.</span></span> <span data-ttu-id="65c81-139">詳しくは、「[バックグラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="65c81-139">More information is available in [Optimizing Background Activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity).</span></span>

<span data-ttu-id="65c81-140">ユニバーサル Windows プラットフォームでは、バッテリ寿命を維持し、フォアグラウンド アプリで最適なエクスペリエンスを提供するために、バックグラウンド タスクの実行が監視されます。</span><span class="sxs-lookup"><span data-stu-id="65c81-140">The Universal Windows Platform monitors background task execution to ensure good battery life and a smooth foreground app experience.</span></span> <span data-ttu-id="65c81-141">ただし、個人用アプリや企業の基幹業務アプリでは、延長実行と **extendedBackgroundTaskTime** 機能を使用して、デバイス リソースの可用性にかかわらず、必要な限り実行されるアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="65c81-141">However, personal apps and Enterprise line-of-Business apps can use extended execution and the **extendedBackgroundTaskTime** capability to create apps that will run as long as needed regardless of the device's resource availability.</span></span>

<span data-ttu-id="65c81-142">ただし、**extendedExecutionUnconstrained** 機能と **extendedBackgroundTaskTime** 機能では UWP アプリの既定ポリシーが上書きされ、大幅にバッテリが消耗することがあるため、注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="65c81-142">Be aware that the **extendedExecutionUnconstrained** and **extendedBackgroundTaskTime** capabilities can override default policy for UWP apps and may cause significant battery drain.</span></span> <span data-ttu-id="65c81-143">これらの機能を使用する前に、まず延長実行およびバックグラウンド タスクの時間に関する既定のポリシーがニーズに合っていないことを確認し、バッテリに制約のある状態でテストを実行して、アプリがデバイスに与える影響を把握してください。</span><span class="sxs-lookup"><span data-stu-id="65c81-143">Before using these capabilities, first confirm that the default extended execution and background task time policies do not meet your needs and perform testing in battery-constrained conditions to understand the impact your app will have on a device.</span></span>

## <a name="see-also"></a><span data-ttu-id="65c81-144">関連項目</span><span class="sxs-lookup"><span data-stu-id="65c81-144">See also</span></span>

[<span data-ttu-id="65c81-145">バックグラウンド タスクのリソース制限を解除する</span><span class="sxs-lookup"><span data-stu-id="65c81-145">Remove background task resource restrictions</span></span>](https://docs.microsoft.com/windows/application-management/enterprise-background-activity-controls)
