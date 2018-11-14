---
author: TylerMSFT
title: アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクに移植する
description: アウト プロセス バック グラウンド タスクを移植する、フォア グラウンド アプリ プロセス内で実行されるインプロセスのバック グラウンド タスク。
ms.author: twhitney
ms.date: 09/19/2018
ms.topic: article
keywords: windows 10、uwp、バック グラウンド タスク、アプリ サービス
ms.assetid: 5327e966-b78d-4859-9b97-5a61c362573e
ms.localizationpriority: medium
ms.openlocfilehash: 47008fd7ba0b7724aa8fbdc2dd6cbd55288faea0
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6164698"
---
# <a name="port-an-out-of-process-background-task-to-an-in-process-background-task"></a>アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクに移植する

インプロセス アクティビティには、アウト プロセス (OOP) バック グラウンド アクティビティを移植する最も簡単な方法では、アプリケーション内で、 [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396)メソッドのコードと[OnBackgroundActivated](/uwp/api/windows.ui.xaml.application.onbackgroundactivated)から開始します。 ここで説明されている手法でない shim を OOP のバック グラウンド タスクから、インプロセス バック グラウンド タスクを作成する方法そのについて書き直して (または移植)、プロセス内でのバージョンに OOP のバージョン。

アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。

現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。

## <a name="background-tasks-and-trigger-types-that-cannot-be-converted"></a>変換できないバックグラウンド タスクとトリガーの種類

* インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。
* インプロセス バックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。
