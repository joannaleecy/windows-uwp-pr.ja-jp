---
author: TylerMSFT
title: インプロセス バック グラウンド タスクをアウト プロセス バック グラウンド タスクを移植します。
description: フォア グラウンド アプリのプロセス内で実行されるインプロセスのバック グラウンド タスクをアウト プロセス バック グラウンド タスクを移植します。
ms.author: twhitney
ms.date: 09/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、バック グラウンド タスク、アプリ サービス
ms.assetid: 5327e966-b78d-4859-9b97-5a61c362573e
ms.localizationpriority: medium
ms.openlocfilehash: b9010f82b0460bd46757bc1e0d58c01dec459104
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4153737"
---
# <a name="port-an-out-of-process-background-task-to-an-in-process-background-task"></a><span data-ttu-id="71b14-104">インプロセス バック グラウンド タスクをアウト プロセス バック グラウンド タスクを移植します。</span><span class="sxs-lookup"><span data-stu-id="71b14-104">Port an out-of-process background task to an in-process background task</span></span>

<span data-ttu-id="71b14-105">[OnBackgroundActivated](/uwp/api/windows.ui.xaml.application.onbackgroundactivated)から開始し、アプリケーション内では、 [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396)メソッドのコードをインプロセス アクティビティには、アウト プロセス (OOP) バック グラウンド アクティビティを移植する最も簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="71b14-105">The simplest way to port your out-of-process (OOP) background activity to in-process activity is to bring your [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) method code inside your application, and initiate it from [OnBackgroundActivated](/uwp/api/windows.ui.xaml.application.onbackgroundactivated).</span></span> <span data-ttu-id="71b14-106">ここで説明されている手法でない shim を OOP バック グラウンド タスクから、インプロセス バック グラウンド タスクを作成する方法そのについて書き直して (または移植)、プロセス内でのバージョンに OOP のバージョン。</span><span class="sxs-lookup"><span data-stu-id="71b14-106">The technique being described here is not about creating a shim from an OOP background task to an in-process background task; it's about rewriting (or porting) an OOP version to an in-process version.</span></span>

<span data-ttu-id="71b14-107">アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。</span><span class="sxs-lookup"><span data-stu-id="71b14-107">If your app has multiple background tasks, the [Background Activation Sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) shows how you can use `BackgroundActivatedEventArgs.TaskInstance.Task.Name` to identify which task is being initiated.</span></span>

<span data-ttu-id="71b14-108">現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。</span><span class="sxs-lookup"><span data-stu-id="71b14-108">If you are currently communicating between background and foreground processes, you can remove that state management and communication code.</span></span>

## <a name="background-tasks-and-trigger-types-that-cannot-be-converted"></a><span data-ttu-id="71b14-109">変換できないバックグラウンド タスクとトリガーの種類</span><span class="sxs-lookup"><span data-stu-id="71b14-109">Background tasks and trigger types that cannot be converted</span></span>

* <span data-ttu-id="71b14-110">インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="71b14-110">In-process background tasks don't support activating a VoIP background task.</span></span>
* <span data-ttu-id="71b14-111">インプロセス バックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="71b14-111">In-process background tasks don't support the following triggers:  [DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396), [DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx) and **IoTStartupTask**</span></span>
