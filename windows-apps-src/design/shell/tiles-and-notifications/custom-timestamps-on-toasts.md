---
Description: トースト通知でカスタムのタイムスタンプを使用する方法について説明します。
title: トーストでのカスタム タイムスタンプの表示
label: Custom timestamps on toasts
template: detail.hbs
ms.date: 12/15/2017
ms.topic: article
keywords: windows 10, uwp, トースト, カスタム タイムスタンプ, タイムスタンプ, 通知, アクション センター
ms.localizationpriority: medium
ms.openlocfilehash: c18c32e1dcee5486ff6545a1db0ec8f0cd67bfae
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57625817"
---
# <a name="custom-timestamps-on-toasts"></a>トーストでのカスタム タイムスタンプの表示

既定では、トースト通知のタイムスタンプ (アクション センター内に表示される) は、通知が送信された時刻に設定されます。

<img alt="Toast with custom timestamp" src="images/toast-customtimestamp.jpg" width="396"/>

開発者は、必要に応じてこのタイムスタンプを上書きし、通知の送信時刻ではなく、メッセージ、情報、コンテンツが実際に作成された時刻を表示することができます。 これにより、アクション センター内で通知が正しい順序 (時間順) で表示されます。 ほとんどのアプリでは、カスタム タイムスタンプを指定することが適切です。

> [!IMPORTANT]
> **Creators Update と通知ライブラリの 1.4.0 必要**:15063 以降に、カスタムのタイムスタンプを参照してください。 現在のビルドを実行する必要があります。 トーストのコンテンツにタイムスタンプを割り当てるには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 1.4.0 以上を使用する必要があります。

カスタム タイムスタンプは、**DisplayTimestamp** プロパティを **ToastContent** に割り当てるだけで使用できます。

```csharp
ToastContent toastContent = new ToastContent()
{
    DisplayTimestamp = new DateTime(2017, 04, 15, 19, 45, 00, DateTimeKind.Utc),
    ...
};
```

```xml
<toast displayTimestamp="2017-04-15T19:45:00Z">
  ...
</toast>
```

XML を使用している場合、日付を [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) で書式設定する必要があります。

> [!NOTE]
> 秒単位で使用できる小数点以下の桁数は、第 3 位までです (現実的には、それ以上精密な時刻を表示する意味はありません)。 それ以上の桁数を指定した場合は、ペイロードが無効になり、開発者に "New notification" 通知が送信されます。


## <a name="usage-guidance"></a>使い方のガイダンス

一般に、ほとんどのアプリでは、カスタム タイムスタンプを指定することが適切です。 これにより、ネットワーク遅延、機内モード、定期的なバックグラウンド タスクのための一定間隔の中断があっても、それらに関係なく、メッセージ、情報、コンテンツの生成時刻が通知のタイムスタンプに正確に反映されます。

たとえば、ニュース アプリが 15 分ごとにバックグラウンド タスクを実行して、新しい記事を確認し、通知を表示する場合があります。 カスタム スタンプが導入されるまで、タイムスタンプはトースト通知が生成された時刻に対応していました (そのため、常に 15 分間隔でした)。 しかし今では、記事が実際に発行された時刻が表示されるように、アプリがタイムスタンプを設定できます。 同様に、メール アプリやソーシャル ネットワーク アプリで、同じようなパターンの定期的なチェックを使用して通知が行われている場合も、この機能が役立ちます。

さらに、カスタム タイムスタンプを使用すると、ユーザーがインターネットから切断された場合でも、タイムスタンプが正確に表示されます。 たとえば、ユーザーがコンピューターをオンにし、バックグラウンド タスクを実行してようやく通知が表示された場合でも、通知のタイムスタンプは、ユーザーがコンピューターのスイッチを入れた時刻ではなく、メッセージが送信された時間を表します。


## <a name="default-timestamp"></a>既定のタイムスタンプ

カスタム タイムスタンプを設定しない場合、通知が送信された時刻が使用されます。

WNS 経由でプッシュ通知を送信した場合は、WNS サーバーが通知を受信した時刻が使用されます (したがって、デバイスへの通知の配信が遅れても、タイムスタンプには影響はありません)。

ローカルの通知を送信した場合、通知プラットフォームが通知を受信した時刻 (通常は送信直後) が使用されます。


## <a name="related-topics"></a>関連トピック

- [ローカルのトーストを送信します。](send-local-toast.md)
- [トーストのコンテンツのドキュメント](adaptive-interactive-toasts.md)