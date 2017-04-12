---
author: TylerMSFT
Description: "イベント ビューアーを使用して、Microsoft テストのイベントとエラーをトラブルシューティングします。"
title: "イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします。"
ms.openlocfilehash: 1b99b959cfdde997f7995c1bdf40d51921b2f1d5
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
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
