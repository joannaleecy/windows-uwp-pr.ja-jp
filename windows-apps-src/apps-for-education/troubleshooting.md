---
Description: イベント ビューアーを使用して、Microsoft テストのイベントとエラーをトラブルシューティングします。
title: イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします。
ms.assetid: 9218e542-f520-4616-98fc-b113d5a08e0f
ms.date: 10/06/2017
ms.topic: article
keywords: windows 10、uwp、教育機関
ms.localizationpriority: medium
ms.openlocfilehash: 2f4bdcf45c7dd37dd540a666d99b5fa2fd2d49f8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598477"
---
# <a name="troubleshoot-microsoft-take-a-test-with-the-event-viewer"></a>イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします

イベント ビューアーを使用して、テストのイベントとエラーを表示することができます。 テストでは、ロックダウン要求を受け取ったとき、デバイスの登録が成功したとき、ロックダウン ポリシーが正常に適用されたときなどに、イベントがログに記録されます。

イベント ビューアーでイベントの表示を有効にするには:
1. 開いている、 `Event Viewer`
2. 移動します `Applications and Services Logs > Microsoft > Windows > Management-SecureAssessment`
3. 右クリックして`Operational`し選択します `Enable Log`

イベント ログを保存するには:
1. 右クリックします。 `Operational`
2. をクリックします。 `Save All Events As…`
