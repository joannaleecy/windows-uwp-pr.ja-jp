---
author: TylerMSFT
title: アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換
description: アウトプロセスのバックグラウンド タスクを、フォアグラウンド アプリ プロセスの内部で実行されるインプロセス バックグラウンド タスクに変換します。
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 5327e966-b78d-4859-9b97-5a61c362573e
ms.openlocfilehash: 390e7255e381bdbb004bfe5e0e95f3ccbcbeb490
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243728"
---
# <a name="convert-an-out-of-process-background-task-to-an-in-process-background-task"></a>アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換

アウト プロセス バックグラウンド アクティビティをインプロセス アクティビティに変換する最も簡単な方法は、[IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) メソッド コードをアプリケーションの内部に配置し、[OnBackgroundActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) から開始する方法です。

アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。

現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。

## <a name="background-tasks-and-trigger-types-that-cannot-be-converted"></a>変換できないバックグラウンド タスクとトリガーの種類

* インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。
* インプロセス バックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。
