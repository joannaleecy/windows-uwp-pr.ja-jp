---
author: TylerMSFT
title: アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換
description: アウトプロセスのバックグラウンド タスクを、フォアグラウンド アプリ プロセスの内部で実行されるインプロセス バックグラウンド タスクに変換します。
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、バック グラウンド タスク、アプリ サービス
ms.assetid: 5327e966-b78d-4859-9b97-5a61c362573e
ms.localizationpriority: medium
ms.openlocfilehash: 1144443f943f134991d050dea1457f252eaaf36d
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3959128"
---
# <a name="convert-an-out-of-process-background-task-to-an-in-process-background-task"></a><span data-ttu-id="57dfc-104">アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換</span><span class="sxs-lookup"><span data-stu-id="57dfc-104">Convert an out-of-process background task to an in-process background task</span></span>

<span data-ttu-id="57dfc-105">アウト プロセス バックグラウンド アクティビティをインプロセス アクティビティに変換する最も簡単な方法は、[IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) メソッド コードをアプリケーションの内部に配置し、[OnBackgroundActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) から開始する方法です。</span><span class="sxs-lookup"><span data-stu-id="57dfc-105">The simplest way to convert your out-of-process background activity into in-process activity is to bring your [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) method code inside your application and initiate it from [OnBackgroundActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx).</span></span>

<span data-ttu-id="57dfc-106">アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。</span><span class="sxs-lookup"><span data-stu-id="57dfc-106">If your app has multiple background tasks, the [Background Activation Sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) shows how you can use `BackgroundActivatedEventArgs.TaskInstance.Task.Name` to identify which task is being initiated.</span></span>

<span data-ttu-id="57dfc-107">現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。</span><span class="sxs-lookup"><span data-stu-id="57dfc-107">If you are currently communicating between background and foreground processes, you can remove that state management and communication code.</span></span>

## <a name="background-tasks-and-trigger-types-that-cannot-be-converted"></a><span data-ttu-id="57dfc-108">変換できないバックグラウンド タスクとトリガーの種類</span><span class="sxs-lookup"><span data-stu-id="57dfc-108">Background tasks and trigger types that cannot be converted</span></span>

* <span data-ttu-id="57dfc-109">インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="57dfc-109">In-process background tasks don't support activating a VoIP background task.</span></span>
* <span data-ttu-id="57dfc-110">インプロセス バックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="57dfc-110">In-process background tasks don't support the following triggers:  [DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396), [DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx) and **IoTStartupTask**</span></span>
