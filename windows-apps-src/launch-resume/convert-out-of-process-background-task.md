---
title: アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクに移植する
description: フォア グラウンド アプリのプロセス内で実行されるプロセス内のバック グラウンド タスクに、プロセス外のバック グラウンド タスクを移植します。
ms.date: 09/19/2018
ms.topic: article
keywords: アプリ サービス、windows 10、uwp、バック グラウンド タスク
ms.assetid: 5327e966-b78d-4859-9b97-5a61c362573e
ms.localizationpriority: medium
ms.openlocfilehash: 97dd249165877591743892a136d51e0969dd902a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601207"
---
# <a name="port-an-out-of-process-background-task-to-an-in-process-background-task"></a>アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクに移植する

プロセス アクティビティには、アウト プロセス (OOP) バック グラウンド アクティビティを移植する最も簡単な方法を取り込む、 [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396)メソッドは、アプリケーション内のコードし、開始から[OnBackgroundActivated](/uwp/api/windows.ui.xaml.application.onbackgroundactivated). ここで説明されている手法が、OOP のバック グラウンド タスクから、プロセス内のバック グラウンド タスクに shim を作成する方法について書き換え (または移植) をプロセス内のバージョンに、OOP バージョン。

アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。

現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。

## <a name="background-tasks-and-trigger-types-that-cannot-be-converted"></a>変換できないバックグラウンド タスクとトリガーの種類

* インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。
* プロセス内のバック グラウンド タスクは、次のトリガーをサポートしません。[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、 [DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)と**IoTStartupTask**
