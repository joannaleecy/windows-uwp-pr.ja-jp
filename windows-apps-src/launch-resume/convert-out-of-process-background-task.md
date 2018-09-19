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
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4055782"
---
# <a name="port-an-out-of-process-background-task-to-an-in-process-background-task"></a>インプロセス バック グラウンド タスクをアウト プロセス バック グラウンド タスクを移植します。

[OnBackgroundActivated](/uwp/api/windows.ui.xaml.application.onbackgroundactivated)から開始し、アプリケーション内では、 [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396)メソッドのコードをインプロセス アクティビティには、アウト プロセス (OOP) バック グラウンド アクティビティを移植する最も簡単な方法です。 ここで説明されている手法でない shim を OOP バック グラウンド タスクから、インプロセス バック グラウンド タスクを作成する方法そのについて書き直して (または移植)、プロセス内でのバージョンに OOP のバージョン。

アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。

現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。

## <a name="background-tasks-and-trigger-types-that-cannot-be-converted"></a>変換できないバックグラウンド タスクとトリガーの種類

* インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。
* インプロセス バックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。
