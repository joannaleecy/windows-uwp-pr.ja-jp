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
# <a name="port-an-out-of-process-background-task-to-an-in-process-background-task"></a>ポート、プロセス外のバック グラウンド タスクが、プロセス内のバック グラウンド タスク

プロセス内のアクティビティには、アウト プロセス (OOP) バック グラウンド アクティビティを移植する最も簡単な方法は、 [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396)メソッドのコード、アプリケーション内を移動し、 [OnBackgroundActivated](/uwp/api/windows.ui.xaml.application.onbackgroundactivated)から開始することです。 OOP のバック グラウンド タスクから、プロセス内のバック グラウンド タスクへの shim を作成することについてここで説明されている手法ではありません。バージョン情報を書き換える (移植) プロセス内のバージョンに、OOP のバージョンです。

アプリに複数バックグラウンド タスクがある場合、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) に、`BackgroundActivatedEventArgs.TaskInstance.Task.Name` を使って開始されるタスクを識別する方法が示されています。

現在、バックグラウンド プロセスとフォアグラウンド プロセスの間で通信している場合、その状態管理および通信コードを削除できます。

## <a name="background-tasks-and-trigger-types-that-cannot-be-converted"></a>変換できないバックグラウンド タスクとトリガーの種類

* インプロセスのバックグラウンド タスクでは、VoIP バックグラウンド タスクのアクティブ化がサポートされていません。
* インプロセス バックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。
