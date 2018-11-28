---
Description: Learn how to use Universal Dismiss on your toast notifications.
title: ユニバーサル無視
label: Universal Dismiss
template: detail.hbs
ms.date: 12/15/2017
ms.topic: article
keywords: windows 10, uwp, トースト, クラウド環境にあるアクション センター, ユニバーサル無視, 通知, クロス デバイス, 一括承諾
ms.localizationpriority: medium
ms.openlocfilehash: 0dc87e8856e35d60660c2643b70b820b2857b488
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7835178"
---
# <a name="universal-dismiss"></a>ユニバーサル無視

ユニバーサル無視は、クラウド環境にあるアクション センターによって提供され、1 つのデバイスで通知を無視すると、他のデバイス上の同じ通知が併せて無視される機能です。

> [!IMPORTANT]
> **Anniversary Update が必要**: ユニバーサル無視を使用するには、SDK 14393 以降をターゲットとし、ビルド 14393 以降を実行している必要があります。

このシナリオの一般的な例に、カレンダーのリマインダーがあります。電話とデスクトップの両方にカレンダー アプリがインストールされていて、両方のデバイスでリマインダーを受け取った場合、デスクトップで無視のボタンをクリックすれば、ユニバーサル無視の機能により、電話のリマインダーも併せて無視されます。 **ユニバーサル無視は、コードに 1 行追加するだけで有効にすることができます。**

<img alt="Diagram of Universal Dismiss" src="images/universal-dismiss.gif" width="406"/>

このシナリオの重要なポイントは、**複数のデバイスに同じアプリがインストールされていること**、つまり、**既に両方のデバイスが通知を受信する状態にあること**です。 カレンダー アプリはこの代表的な例です。通常、カレンダー アプリは、Windows PC と電話の両方にインストールされ、アプリのそれぞれのインスタンスが既にそれそれのデバイスにリマインダーを送信しています。 ユニバーサル無視のサポートを追加すると、同じリマインダーの複数のインスタンスをデバイス間でリンクできます。


## <a name="how-to-enable-universal-dismiss"></a>ユニバーサル無視を有効にする方法

開発者にとって、ユニバーサル無視を有効にする手順は非常に簡単です。 必要なのは、デバイス間で通知をリンクできるように ID を指定することだけです。これにより、ユーザーが 1 つのデバイスで通知を無視すると、それに対応するリンクされた通知が他のデバイスで無視されます。

![ユニバーサル無視の RemoteId の図](images/universal-dismiss-remoteid.jpg)

> **RemoteId**: *複数のデバイス間で*通知を一意に識別する識別子です。

RemoteId は、コードに 1 行追加するだけで設定でき、それによってユニバーサル無視のサポートが有効になります。 RemoteId の生成方法は開発者が自由に決定できますが、複数のデバイス間で通知を一意に識別でき、かつ異なるデバイス上で動作する同じアプリの異なるインスタンスで、同一の識別子を生成できる必要があります。

たとえば、宿題プランナー アプリについて有効にする場合を考えてみましょう。まず、種類が "reminder" であることを指定して RemoteId を生成した後、宿題項目のオンライン アカウント ID とオンライン識別子を設定します。 これらのオンライン ID はデバイス間で共有されているため、通知を送信するデバイスにかかわらず、同じ正確な RemoteId を一貫して生成することができます。

```csharp
var toast = new ScheduledToastNotification(content.GetXml(), startTime);
 
// If the RemoteId property is present
if (ApiInformation.IsPropertyPresent(typeof(ScheduledToastNotification).FullName, nameof(ScheduledToastNotification.RemoteId)))
{
    // Assign the RemoteId to add support for Universal Dismiss
    toast.RemoteId = $"reminder_{account.AccountId}_{homework.Identifier}"
}
  
ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
```

以下のコードは、電話アプリとデスクトップ アプリの両方で実行されるため、両方のデバイスの通知は、同じ RemoteId を持つことになります。

必要な作業はこれだけです。 ユーザーが通知を無視 (またはクリック) すると、アプリはそれが RemoteId であるかどうかを確認し、そうである場合は、ユーザーのすべてのデバイスに対してその RemoteId を無視するように情報を拡散します。

**既知の問題**: `ToastNotificationHistory.GetHistory()` API 経由で **RemoteId** を取得すると、指定した **RemoteId** ではなく、常に空の文字列が返されます。 しかし心配は要りません。誤っているのは取得された値のみで、それ以外はすべて正常に機能しています。

> [!NOTE]
> 通知はクラウド上には存在しないため、ユーザーや企業がアプリで[通知のミラーリング](notification-mirroring.md)を無効にすると (または通知のミラーリング自体を完全に無効にすると)、ユニバーサル無視が機能しなくなります。


## <a name="supported-devices"></a>サポートされるデバイス

Anniversary Update 以降、ユニバーサル無視は、Windows Mobile および Windows デスクトップでサポートされます。 ユニバーサル無視は、PC 間、PC と電話間、電話間で双方向に機能します。