---
Description: Troubleshoot Microsoft Take a Test events and errors with the event viewer.
title: イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします。
author: PatrickFarley
ms.author: pafarley
ms.assetid: 9218e542-f520-4616-98fc-b113d5a08e0f
ms.date: 10/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 教育
ms.localizationpriority: medium
ms.openlocfilehash: 3193525316d085e56244d6f03da99e3e07c6539f
ms.sourcegitcommit: 914b38559852aaefe7e9468f6f53a7465bf36e30
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3390348"
---
# <a name="troubleshoot-microsoft-take-a-test-with-the-event-viewer"></a>イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします

イベント ビューアーを使用して、テストのイベントとエラーを表示することができます。 テストでは、ロックダウン要求を受け取ったとき、デバイスの登録が成功したとき、ロックダウン ポリシーが正常に適用されたときなどに、イベントがログに記録されます。

イベント ビューアーでイベントの表示を有効にするには:
1. 次を開きます:  `Event Viewer`
2. 次に移動します:  `Applications and Services Logs > Microsoft > Windows > Management-SecureAssessment`
3. `Operational` を右クリックして、次を選びます:  `Enable Log`

イベント ログを保存するには:
1. 次を右クリックします:  `Operational`
2. 次をクリックします:  `Save All Events As…`
