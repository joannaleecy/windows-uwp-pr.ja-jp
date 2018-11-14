---
author: mijacobs
Description: Periodic notifications, which are also called polled notifications, update tiles and badges at a fixed interval by downloading content from a cloud service.
title: 定期的な通知の概要
ms.assetid: 1EB79BF6-4B94-451F-9FAB-0A1B45B4D01C
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d02bfb8b8bd112a969895d4f2bd5d324fce9d6b8
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6450257"
---
# <a name="periodic-notification-overview"></a>定期的な通知の概要
 


定期的な通知 (ポーリング通知とも呼ばれます) では、クラウド サービスから直接コンテンツをダウンロードして、一定の間隔でタイルやバッジを更新します。 定期的な通知を使うには、クライアント アプリのコードで 2 つの情報を指定する必要があります。

-   アプリのタイルやバッジの更新がないかどうかを調べるために Windows でポーリングする Web 上の場所の Uniform Resource Identifier (URI)
-   URI をポーリングする頻度

定期的な通知では、最小限のクラウド サービスとクライアントの投資で、ライブ タイルを更新することができます。 定期的な通知は、同じコンテンツを多数のユーザーに配信する優れた方法です。

**注:**  Windows8.1[プッシュ通知と定期的な通知のサンプル](http://go.microsoft.com/fwlink/p/?linkid=231476)をダウンロードし、windows 10 アプリでソース コードを再利用して、詳細については、します。

 

## <a name="how-it-works"></a>しくみ


定期的な通知では、アプリでクラウド サービスをホストする必要があります。 このサービスは、アプリをインストールしているすべてのユーザーによって定期的にポーリングされます。 Windows では、ポーリング間隔 (1 時間に 1 回など) に従って URI に HTTP GET 要求を送り、この要求に対する応答として提供される要求したタイルまたはバッジのコンテンツ (XML 形式) をダウンロードして、アプリのタイルにそのコンテンツを表示します。

定期的な更新をトースト通知で使うことはできません。 トーストの配信には、[スケジュールされた通知](https://msdn.microsoft.com/library/windows/apps/hh465417)または[プッシュ通知](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252)が適しています。

## <a name="uri-location-and-xml-content"></a>URI の場所と XML コンテンツ


ポーリングする URI には、HTTP や HTTPS の有効な Web アドレスを使うことができます。

クラウド サーバーからの応答には、ダウンロードされたコンテンツが含まれます。 URI から返されるコンテンツは、[タイル](adaptive-tiles-schema.md)または[バッジ](https://msdn.microsoft.com/library/windows/apps/br212851)の XML スキーマの仕様に準拠し、UTF-8 の形式でエンコードされている必要があります。 仕様で規定されている HTTP ヘッダーを使うと、通知の[有効期限](#expiration-of-tile-and-badge-notifications)やタグを指定することができます。

## <a name="polling-behavior"></a>ポーリングの動作


ポーリングを開始するには次のメソッドのいずれかを呼び出します。

-   [**StartPeriodicUpdate**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater#Windows_UI_Notifications_TileUpdater_StartPeriodicUpdate_Windows_Foundation_Uri_Windows_Foundation_DateTime_Windows_UI_Notifications_PeriodicUpdateRecurrence_) (タイル)
-   [**StartPeriodicUpdate**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.BadgeUpdater#Windows_UI_Notifications_BadgeUpdater_StartPeriodicUpdate_Windows_Foundation_Uri_Windows_Foundation_DateTime_Windows_UI_Notifications_PeriodicUpdateRecurrence_) (バッジ)
-   [**StartPeriodicUpdateBatch**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater#Windows_UI_Notifications_TileUpdater_StartPeriodicUpdateBatch_Windows_Foundation_Collections_IIterable_1_Windows_UI_Notifications_PeriodicUpdateRecurrence_) (タイル)

これらのいずれかのメソッドを呼び出すと、URI がすぐにポーリングされて、受け取ったコンテンツでタイルやバッジが更新されます。 この最初のポーリングの後は、要求した間隔で更新が提供されます。 ポーリングは、明示的に停止するか ([**TileUpdater.StopPeriodicUpdate**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater.StopPeriodicUpdate) を使用)、アプリをアンインストールするか、(セカンダリ タイルの場合は) タイルを削除するまで続けられます。 それまでの間は、アプリが起動されなくても、タイルやバッジの更新がないかどうかを調べるために継続的にポーリングが行われます。

### <a name="the-recurrence-interval"></a>繰り返し間隔

繰り返し間隔は、上記のメソッドのパラメーターとして指定します。 Windows は要求された間隔でポーリングを適切に実行しますが、多少の誤差が生じる場合もあります。 Windows の判断により、要求したポーリング間隔よりも最大で 15 分ほど遅れる可能性があります。

### <a name="the-start-time"></a>開始時刻

必要に応じて、ポーリングを開始する時刻を指定できます。 タイルのコンテンツが 1 日に 1 回しか変更されないようなアプリでは、 ポーリングの開始時刻をクラウド サービスの更新時刻の直後に設定することをお勧めします。 たとえば、毎朝 8 時にその日のサービス品が公開されるショッピング サイトであれば、午前 8 時すぎにポーリングを行ってタイルの新しいコンテンツがないかどうかを調べます。

開始時刻を指定した場合、メソッドを最初に呼び出したときに、すぐにポーリングが行われコンテンツが確認されます。 それ以降の定期的なポーリングは、指定した開始時刻の 15 分以内に開始されます。

### <a name="automatic-retry-behavior"></a>自動再試行の動作

URI がポーリングされるのは、デバイスがオンラインになっている場合だけです。 ネットワークが利用可能でも、任意の理由で URI にアクセスできない場合は、ポーリング間隔の反復が 1 回スキップされ、次の間隔で再び URI がポーリングされます。 ポーリング間隔に達したときにデバイスがオフ、スリープ、または休止状態になっていた場合、URI は、デバイスがオフ状態やスリープ状態から回復したときにポーリングされます。

### <a name="handling-app-updates"></a>アプリの更新プログラムの処理

ポーリング URI を変更するアプリの更新プログラムをリリースする場合は、タイルが必ず新しい URI を使用するように、新しい URI と共に StartPeriodicUpdate を呼び出す、毎日の[時刻のトリガーによるバックグラウンド タスク](../../../launch-resume/run-a-background-task-on-a-timer-.md)を追加する必要があります。 そうしないと、ユーザーがアプリの更新プログラムを受け取ってもアプリを起動しない場合、ユーザーのタイルは古い URI を使い続けるため、URI が無効になった場合や返されたペイロードが存在しないローカル画像を参照している場合に、表示に失敗することがあります。

## <a name="expiration-of-tile-and-badge-notifications"></a>タイル通知とバッジ通知の有効期限


既定では、定期的なタイル通知とバッジ通知は、ダウンロードされたときから 3 日後に有効期限切れになります。 通知の有効期限が切れると、バッジ、タイル、キューからコンテンツが削除され、ユーザーに表示されなくなります。 すべての定期的なタイル通知とバッジ通知には、アプリや通知に適した時間を使って有効期限を明示的に設定し、コンテンツの意味がなくなっても保持されないようにすることをお勧めします。 明示的な有効期限は、コンテンツの存続期間が決まっている場合に重要です。 また、クラウド サービスにアクセスできなくなった場合や、ユーザーがネットワークに長時間接続していない場合に、古いコンテンツが確実に削除されます。

クラウド サービスでは、応答のペイロードに X-WNS-Expires HTTP ヘッダーを含めることによって、通知の有効期限の日時が明示的に設定されます。 X-WNS-Expires HTTP ヘッダーは、[HTTP-date 形式](http://go.microsoft.com/fwlink/p/?linkid=253706)に準拠します。 詳しくは、「[**StartPeriodicUpdate**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater#Windows_UI_Notifications_TileUpdater_StartPeriodicUpdate_Windows_Foundation_Uri_Windows_Foundation_DateTime_Windows_UI_Notifications_PeriodicUpdateRecurrence_)」または「[**StartPeriodicUpdateBatch**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater#Windows_UI_Notifications_TileUpdater_StartPeriodicUpdateBatch_Windows_Foundation_Collections_IIterable_1_Windows_UI_Notifications_PeriodicUpdateRecurrence_)」をご覧ください。

たとえば、株式市場の取引が活発な日は、株価の更新の有効期限をポーリング間隔の有効期限の 2 倍に設定することをお勧めします (ポーリング間隔が 30 分の場合は有効期限を受け取り後 1 時間にするなど)。 また、ニュース アプリの場合、毎日のニュースを表示するタイルの更新の有効期限は 1 日が適しています。

## <a name="periodic-notifications-in-the-notification-queue"></a>通知キューでの定期的な通知


定期的なタイルの更新は[通知の循環](https://msdn.microsoft.com/library/windows/apps/hh781199)と併用できます。 既定では、スタート画面のタイルには、新しい通知によって置き換えられるまで、1 つの通知のコンテンツが表示されます。 循環を有効にすると、最大で 5 つの通知がキューに入れられ、タイルに循環して表示されます。

キューの通知の数が限度の 5 個になると、次の新しい通知によってキューの最も古い通知が置き換えられます。 ただし、通知にタグを設定することで、キューの置き換えポリシーを操作できます。 タグは大文字と小文字が区別されないアプリ固有の文字列 (最大 16 文字の英数字) で、応答のペイロードの [X-WNS-Tag](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_tag) HTTP ヘッダーで指定されます。 着信した通知のタグは、既にキューにあるすべての通知のタグと比較され、 一致するものが見つかると、キューにある同じタグを持つ通知が新しい通知に置き換えられます。 一致するものが見つからない場合は、既定の置き換え規則が適用され、キューの最も古い通知が新しい通知に置き換えられます。

通知のキューとタグを使うと、充実した通知シナリオを実装できます。 たとえば、株価アプリでは、それぞれの銘柄名をタグに使って異なる 5 銘柄の通知を送ることができます。 このようにすると、同じ銘柄の複数の通知がキューに入れられて、有効期限が切れた古い通知が表示されるようなことがなくなります。

詳しくは、「[通知キューの使用](https://msdn.microsoft.com/library/windows/apps/hh781199)」をご覧ください。

### <a name="enabling-the-notification-queue"></a>通知キューを有効にする

通知キューを実装するには、最初に、タイルに対してキューを有効にする必要があります (「[ローカル通知で通知キューを使用する方法](https://blogs.msdn.microsoft.com/tiles_and_toasts/2016/01/05/quickstart-how-to-use-the-tile-notification-queue-with-local-notifications/)」を参照)。 キューを有効にする呼び出しはアプリの存続期間で 1 回だけ実行する必要がありますが、アプリが起動されるたびに呼び出しても問題はありません。

### <a name="polling-for-more-than-one-notification-at-a-time"></a>一度に複数の通知をポーリングする

Windows でダウンロードを行うタイルの通知ごとに、一意の URI を指定する必要があります。 [**StartPeriodicUpdateBatch**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater#Windows_UI_Notifications_TileUpdater_StartPeriodicUpdateBatch_Windows_Foundation_Collections_IIterable_1_Windows_UI_Notifications_PeriodicUpdateRecurrence_) メソッドを使うと、通知キューで使う URI を一度に 5 つまで指定できます。 各 URI がポーリングされ、ほぼ同じ時間にそれぞれ 1 つの通知ペイロードが返されます。 ポーリングされる各 URI からは、それぞれ固有の有効期限とタグ値を返すこともできます。

## <a name="related-topics"></a>関連トピック


* [定期的な通知のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh761461)
* [バッジの定期的な通知を設定する方法](https://msdn.microsoft.com/library/windows/apps/hh761476)
* [タイルの定期的な通知を設定する方法](https://msdn.microsoft.com/library/windows/apps/hh761476)
 
