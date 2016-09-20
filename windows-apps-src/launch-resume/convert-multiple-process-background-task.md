---
author: TylerMSFT
title: "マルチプロセスのバックグラウンド タスクを単一プロセスのバックグラウンド タスクへ変換"
description: "別個のプロセスで実行されるバックグラウンド タスクを、フォアグラウンド アプリ プロセスの内部で実行されるバックグラウンド タスクに変換します。"
translationtype: Human Translation
ms.sourcegitcommit: 2c34ca40d3c930254500477ab5a2e41e5206d823
ms.openlocfilehash: e342667347cf3b89a5aa193495cbf7195263b276

---

# マルチプロセスのバックグラウンド タスクを単一プロセスのバックグラウンド タスクへ変換

複数プロセス バックグラウンド アクティビティを単一のプロセスに変換する最も簡単な方法は、[IBackgroundTask.Run](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) メソッド コードをアプリケーションの内部に配置し、[OnBackgroundActivated](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) から開始する方法です。

アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。

現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。

## 変換できないバックグラウンド タスクとトリガーの種類

* 単一プロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。
* 単一プロセスのバックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。



<!--HONumber=Aug16_HO3-->


