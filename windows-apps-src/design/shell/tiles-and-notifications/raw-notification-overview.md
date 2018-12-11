---
Description: Raw notifications are short, general purpose push notifications.
title: 直接通知の概要
ms.assetid: A867C75D-D16E-4AB5-8B44-614EEB9179C7
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ad00090fdfc3ce7be34ef6271d16e76541b584bb
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8920679"
---
# <a name="raw-notification-overview"></a>直接通知の概要


直接通知は、短い汎用のプッシュ通知です。 説明のみを目的としており、UI コンポーネントは含まれません。 他のプッシュ通知と同様に、Windows プッシュ通知サービス (WNS) 機能は、クラウド サービスからアプリに直接通知を配信します。

直接通知は、ユーザーがアプリに権限を与えている場合にアプリによるバックグラウンド タスクの実行をトリガーするなど、さまざまな目的で使うことができます。 アプリとの通信に WNS を使うことで、固定ソケット接続の作成、HTTP GET メッセージの送信、サービスとアプリ間でのその他の接続などに伴う処理のオーバーヘッドを回避できます。

> [!IMPORTANT]
> 直接通知について理解するには、「[Windows プッシュ通知サービス (WNS) の概要](windows-push-notification-services--wns--overview.md)」で説明されている概念を理解していれば理想的です。

 

トースト、タイル、バッジのプッシュ通知の場合と同様に、直接通知は割り当てられたチャネルの URI (Uniform Resource Identifier) を介してアプリのクラウド サービスから WNS にプッシュされます。 その後、WNS はそのチャネルに関連付けられているデバイスとユーザー アカウントに通知を配信します。 他のプッシュ通知とは異なり、直接通知にはフォーマットの規定はありません。 ペイロードのコンテンツは、すべてアプリで定義されます。

直接通知を使うことによってメリットを得ることができるアプリの例として、理論上のドキュメント共同作業アプリについて考えてみましょう。 1 つのドキュメントを同時に編集している 2 人のユーザーがいるとします。 この共有ドキュメントをホストするクラウド サービスでは、一方のユーザーが変更を加えたときに、直接通知を使ってもう一方のユーザーに通知できます。 この直接通知には、ドキュメントに対する変更が含まれるとは限りません。この通知は、各ユーザーのアプリ コピーに対して、一元化された場所にアクセスして変更を同期するように伝えます。 直接通知を使うことによって、アプリとそのクラウド サービスは、ドキュメントが開かれている間、固定接続の保持に伴うオーバーヘッドを削減することができます。

## <a name="how-raw-notifications-work"></a>直接通知のしくみ


すべての直接通知はプッシュ通知です。 このため、プッシュ通知の送受信に必要な設定が直接通知にも適用されます。

-   直接通知を送るためには有効な WNS チャネルが必要です。 プッシュ通知チャネルの取得について詳しくは、「[通知チャネルを要求、作成、保存する方法](https://msdn.microsoft.com/library/windows/apps/hh465412)」をご覧ください。
-   アプリ マニフェストに **インターネット** 機能を含める必要があります。 Microsoft Visual Studio マニフェスト エディターでは、**[機能]** タブの **[インターネット (クライアント)]** としてこのオプションが用意されています。 詳しくは、「[**Capabilities**](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-capabilities)」をご覧ください。

通知の本文は、アプリで定義された形式に従います。 クライアントは、アプリだけが認識すればよい、NULL で終了する文字列 (**HSTRING**) としてデータを受け取ります。

クライアントがオフラインの場合は、[X-WNS-Cache-Policy](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_cache) ヘッダーが通知に含まれるときにのみ、直接通知が WNS によってキャッシュされます。 ただし、デバイスがオンラインに戻った時点でキャッシュされて配信されるのは 1 つの直接通知だけです。

直接通知がクライアントで使うパスは 3 つしかありません。直接通知は、実行中のアプリに通知配信イベントをとおして配信されるか、バックグラウンド タスクに送られるか、またはドロップされます。 したがって、クライアントがオフラインの状態で WNS が直接通知の配信を試みた場合、その通知はドロップされます。

## <a name="creating-a-raw-notification"></a>直接通知の作成


直接通知の送信はタイル、トースト、またはバッジのプッシュ通知の送信に似ていますが、次の違いがあります。

-   HTTP の Content-Type ヘッダーは、"application/octet-stream" に設定する必要があります。
-   HTTP の [X-WNS-Type](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_type) ヘッダーは "wns/raw" に設定する必要があります。
-   通知の本文には、ペイロードが 5 KB 未満の任意の文字列を含めることができます。

直接通知は、アプリでのアクション (サービスに直接アクセスして大量のデータを同期する、通知コンテンツに基づいて局部的な状態変更を行うなど) の実行をトリガーする短いメッセージとして使うことを意図しています。 WNS プッシュ通知は配信されるとは限らないため、アプリとクラウド サービスで、クライアントがオフラインの場合などには直接通知がクライアントに届かない可能性があることを示しておく必要があります。

プッシュ通知の送信について詳しくは、「[クイック スタート: プッシュ通知の送信](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252)」をご覧ください。

## <a name="receiving-a-raw-notification"></a>直接通知の受信


アプリで直接通知を受け取る方法は 2 とおりあります。

-   アプリケーションの実行中に[通知配信イベント](#notification-delivery-events)で受け取る。
-   アプリでバックグラウンド タスクを実行できる場合、[直接通知によってトリガーされるバックグラウンド タスク](#background-tasks-triggered-by-raw-notifications)で受け取る。

アプリでは、両方のメカニズムを使って直接通知を受け取ることができます。 通知配信イベント ハンドラーと、直接通知によってトリガーされるバックグラウンド タスクの両方をアプリが実装している場合、アプリの実行時には通知配信イベントが優先されます。

-   アプリが実行中の場合、バックグラウンド タスクよりも通知配信イベントが優先され、最初に通知を処理するのはそのアプリになります。
-   通知配信イベント ハンドラーは、イベントの [**PushNotificationReceivedEventArgs.Cancel**](https://docs.microsoft.com/uwp/api/Windows.Networking.PushNotifications.PushNotificationReceivedEventArgs.Cancel) プロパティを **true** に設定することで、そのハンドラーの終了後に直接通知がそのバックグラウンド タスクに渡されないよう指定できます。 **Cancel** プロパティを **false** に設定するか、またはこのプロパティを設定しない (デフォルト値は **false**) 場合、通知配信イベント ハンドラーによる処理の完了後、直接通知によってバックグラウンド タスクがトリガーされます。

### <a name="notification-delivery-events"></a>通知配信イベント

アプリで通知配信イベント ([**PushNotificationReceived**](https://docs.microsoft.com/uwp/api/Windows.Networking.PushNotifications.PushNotificationChannel.PushNotificationReceived)) を使うと、アプリの実行中に直接通知を受信できます。 クラウド サービスが直接通知を送る場合、実行中のアプリはチャネル URI 上の通知配信イベントを処理することによって直接通知を受け取ることができます。

アプリが実行されておらず、[バックグラウンド タスク](#background-tasks-triggered-by-raw-notifications)を使わない場合、そのアプリに送られる直接通知はすべて受信時に WNS によってドロップされます。 クラウド サービスのリソースの消費を削減するには、アプリがアクティブであるかどうかを追跡するロジックをサービスに実装することを検討する必要があります。 このロジックの情報源は 2 種類あります。アプリが通知を受け取る準備ができたことをサービスに明示的に伝えることも、WNS が停止するタイミングをサービスに伝えることもできます。

-   **アプリがクラウド サービスに通知する**: アプリは、サービスにアクセスし、アプリがフォアグラウンドで実行されていると知らせることができます。 この方法の欠点は、アプリがサービスに頻繁にアクセスするようになる可能性があるということです。 ただし、到着した直接通知をアプリが受け取ることができるタイミングをサービスが常に把握しているという利点もあります。 この他、アプリがそのサービスにアクセスする際に、サービスがブロードキャストではなく直接通知をそのアプリの特定のインスタンスに送る必要があるとわかるという利点もあります。
-   **クラウド サービスが WNS 応答メッセージに応答する**: アプリ サービスは、WNS によって返された [X-WNS-NotificationStatus](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_notification) の情報と [X-WNS-DeviceConnectionStatus](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_dcs) の情報を使って、アプリへの直接通知の送信を停止するタイミングを判断できます。 サービスが通知を HTTP POST としてチャネルに送る場合、サービスは応答で以下のメッセージの 1 つを受け取ることがあります。

    -   **X-WNS-NotificationStatus: dropped**: クライアントが通知を受け取らなかったことを示します。 **dropped** 応答は、ユーザー デバイスのフォアグラウンドに存在しなくなったアプリによって引き起こされたと考えることができます。
    -   **X-WNS-DeviceConnectionStatus: disconnected** または **X-WNS-DeviceConnectionStatus: tempconnected**: Windows クライアントがもう WNS に接続されていないことを示します。 このメッセージを WNS から受け取るには、通知の HTTP POST に [X-WNS-RequestForStatus](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_request) ヘッダーを設定して受け取りを要求する必要があります。

    アプリのクラウド サービスは、これらのステータス メッセージ内の情報を使って、直接通知による通信要求を停止できます。 アプリがフォアグラウンドに戻り、サービスにアクセスした時点で、サービスは直接通知の送信を再開できます。

    通知がクライアントに正常に配信されたかどうかは、[X-WNS-NotificationStatus](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_notification) を基準にして判断しないでください。

    詳しくは、「[プッシュ通知サービスの要求ヘッダーと応答ヘッダー](https://msdn.microsoft.com/library/windows/apps/hh465435)」を参照してください。

### <a name="background-tasks-triggered-by-raw-notifications"></a>直接通知によってトリガーされるバックグラウンド タスク

> [!IMPORTANT]
> 直接通知のバックグラウンド タスクを使用する前に、[**BackgroundExecutionManager.RequestAccessAsync**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundExecutionManager#Windows_ApplicationModel_Background_BackgroundExecutionManager_RequestAccessAsync_System_String_) を使用してアプリにバックグラウンド アクセスを許可する必要があります。

 

バックグラウンド タスクは [**PushNotificationTrigger**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.PushNotificationTrigger) に登録する必要があります。 登録されていないと、直接通知を受け取ったときにそのタスクが実行されません。

直接通知によってトリガーされたバックグラウンド タスクを使うと、アプリが実行されていないときでも (実行をトリガーする場合もありますが)、アプリのクラウド サービスでアプリにアクセスできます。 そのためにアプリが継続的な接続を維持する必要はありません。 直接通知は、バックグラウンド タスクをトリガーできる唯一の通知の種類です。 トースト、タイル、バッジのプッシュ通知ではバックグラウンド タスクをトリガーできませんが、直接通知によってトリガーされたバックグラウンド タスクによって、ローカル API 呼び出しを介してタイルを更新し、トースト通知を呼び出すことはできます。

直接通知によってトリガーされたバックグラウンド タスクがどのように機能するかを知るため、電子書籍の読み取りに使うアプリを考えてみましょう。 まず、ユーザーが (他のデバイスを使って) ネット上で電子書籍を購入したとします。 応答として、アプリのクラウド サービスは、電子書籍が購入されたこと、アプリでこの電子書籍がダウンロードされることを示すペイロードを付けて、ユーザーの個々のデバイスに直接通知を送ることができます。 この後、アプリがそのクラウド サービスに直接アクセスし、この新しい書籍のダウンロードをバックグラウンドで開始します。これにより、ユーザーがアプリを起動するときには、この書籍が既に存在し、読むことができる状態になっています。

直接通知を使ってバックグラウンド タスクをトリガーするには、アプリで以下を行う必要があります。

1.  [**BackgroundExecutionManager.RequestAccessAsync**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundExecutionManager#Windows_ApplicationModel_Background_BackgroundExecutionManager_RequestAccessAsync_System_String_) を使用して、バックグラウンドでタスクを実行するための許可 (ユーザーはいつでも取り消すことが可能) を要求する。
2.  バックグラウンド タスクを実装する。 詳しくは、「[バックグラウンド タスクによるアプリのサポート](../../../launch-resume/support-your-app-with-background-tasks.md)」をご覧ください。

これで、アプリで直接通知を受け取るたびに、[**PushNotificationTrigger**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.PushNotificationTrigger) への応答としてバックグラウンド タスクが呼び出されるようになります。 バックグラウンド タスクは、直接通知のアプリ固有ペイロードを解釈し、ペイロードに対する処理を行います。

各アプリで同時に実行できるバックグラウンド タスクは 1 つだけです。 バックグラウンド タスクが既に実行されているアプリでバックグラウンド タスクがトリガーされた場合、最初のバックグラウンド タスクが完了するまで新しいバックグラウンド タスクは実行されません。

## <a name="other-resources"></a>その他のリソース


Windows8.1、および[プッシュ通知と定期的な通知のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=231476)の Windows8.1、[直接通知のサンプル](http://go.microsoft.com/fwlink/p/?linkid=241553)をダウンロードして、windows 10 アプリでそれらのソース コードを再利用して詳しくを知ることができます。

## <a name="related-topics"></a>関連トピック

* [直接通知のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh761463)
* [クイック スタート: 直接通知のバックグラウンド タスクの作成と登録](https://msdn.microsoft.com/library/windows/apps/jj676800)
* [クイック スタート: 実行中のアプリのプッシュ通知の中断](https://msdn.microsoft.com/library/windows/apps/jj709908)
* [**RawNotification**](https://docs.microsoft.com/uwp/api/Windows.Networking.PushNotifications.RawNotification)
* [**BackgroundExecutionManager.RequestAccessAsync**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundExecutionManager#Windows_ApplicationModel_Background_BackgroundExecutionManager_RequestAccessAsync_System_String_)
 

 




