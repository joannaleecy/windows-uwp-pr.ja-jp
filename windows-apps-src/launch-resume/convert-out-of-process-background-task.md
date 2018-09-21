---
author: TylerMSFT
title: ポート、プロセス外のバック グラウンド タスクが、プロセス内のバック グラウンド タスク
description: アウト プロセスのバック グラウンド タスクが、フォア グラウンド アプリケーションのプロセス内で動作する、プロセス内のバック グラウンド タスクを移植します。
ms.author: twhitney
ms.date: 09/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、バック グラウンド タスク、アプリケーション サービス
ms.assetid: 5327e966-b78d-4859-9b97-5a61c362573e
ms.localizationpriority: medium
ms.openlocfilehash: b9010f82b0460bd46757bc1e0d58c01dec459104
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4114418"
---
# <a name="port-an-out-of-process-background-task-to-an-in-process-background-task"></a><span data-ttu-id="b9b2b-104">ポート、プロセス外のバック グラウンド タスクが、プロセス内のバック グラウンド タスク</span><span class="sxs-lookup"><span data-stu-id="b9b2b-104">Port an out-of-process background task to an in-process background task</span></span>

<span data-ttu-id="b9b2b-105">プロセス内のアクティビティには、アウト プロセス (OOP) バック グラウンド アクティビティを移植する最も簡単な方法は、 [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396)メソッドのコード、アプリケーション内を移動し、 [OnBackgroundActivated](/uwp/api/windows.ui.xaml.application.onbackgroundactivated)から開始することです。</span><span class="sxs-lookup"><span data-stu-id="b9b2b-105">The simplest way to port your out-of-process (OOP) background activity to in-process activity is to bring your [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) method code inside your application, and initiate it from [OnBackgroundActivated](/uwp/api/windows.ui.xaml.application.onbackgroundactivated).</span></span> <span data-ttu-id="b9b2b-106">OOP のバック グラウンド タスクから、プロセス内のバック グラウンド タスクへの shim を作成することについてここで説明されている手法ではありません。バージョン情報を書き換える (移植) プロセス内のバージョンに、OOP のバージョンです。</span><span class="sxs-lookup"><span data-stu-id="b9b2b-106">The technique being described here is not about creating a shim from an OOP background task to an in-process background task; it's about rewriting (or porting) an OOP version to an in-process version.</span></span>

<span data-ttu-id="b9b2b-107">アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。</span><span class="sxs-lookup"><span data-stu-id="b9b2b-107">If your app has multiple background tasks, the [Background Activation Sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) shows how you can use `BackgroundActivatedEventArgs.TaskInstance.Task.Name` to identify which task is being initiated.</span></span>

<span data-ttu-id="b9b2b-108">現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。</span><span class="sxs-lookup"><span data-stu-id="b9b2b-108">If you are currently communicating between background and foreground processes, you can remove that state management and communication code.</span></span>

## <a name="background-tasks-and-trigger-types-that-cannot-be-converted"></a><span data-ttu-id="b9b2b-109">変換できないバックグラウンド タスクとトリガーの種類</span><span class="sxs-lookup"><span data-stu-id="b9b2b-109">Background tasks and trigger types that cannot be converted</span></span>

* <span data-ttu-id="b9b2b-110">インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="b9b2b-110">In-process background tasks don't support activating a VoIP background task.</span></span>
* <span data-ttu-id="b9b2b-111">インプロセス バックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="b9b2b-111">In-process background tasks don't support the following triggers:  [DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396), [DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx) and **IoTStartupTask**</span></span>
