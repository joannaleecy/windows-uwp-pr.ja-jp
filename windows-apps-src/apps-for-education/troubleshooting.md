---
Description: Troubleshoot Microsoft Take a Test events and errors with the event viewer.
title: イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします。
ms.assetid: 9218e542-f520-4616-98fc-b113d5a08e0f
ms.date: 10/06/2017
ms.topic: article
keywords: windows 10, uwp, 教育
ms.localizationpriority: medium
ms.openlocfilehash: 2f4bdcf45c7dd37dd540a666d99b5fa2fd2d49f8
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8947062"
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
