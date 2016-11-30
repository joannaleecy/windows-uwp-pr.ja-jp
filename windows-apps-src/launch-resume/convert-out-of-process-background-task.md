---
author: TylerMSFT
title: "アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換"
description: "アウトプロセスのバックグラウンド タスクを、フォアグラウンド アプリ プロセスの内部で実行されるインプロセス バックグラウンド タスクに変換します。"
translationtype: Human Translation
ms.sourcegitcommit: 7d1c160f8b725cd848bf8357325c6ca284b632ae
ms.openlocfilehash: b361a558ecef2030370590eedbef69bd04cf68bd

---

# アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換

アウト プロセス バックグラウンド アクティビティをインプロセス アクティビティに変換する最も簡単な方法は、[IBackgroundTask.Run](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) メソッド コードをアプリケーションの内部に配置し、[OnBackgroundActivated](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) から開始する方法です。

アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。

現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。

## 変換できないバックグラウンド タスクとトリガーの種類

* インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。
* インプロセス バックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。



<!--HONumber=Nov16_HO1-->


