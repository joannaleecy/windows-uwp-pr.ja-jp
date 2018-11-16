---
author: adwilso
Description: Windows Push Notification Services (WNS) enables third-party developers to send toast, tile, badge, and raw updates from their own cloud service. There are many ways to send the notifications depending on the needs of your application
title: 適切なプッシュ通知チャネルの種類を選択する
ms.author: mijacobs
ms.date: 07/07/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: db2cf1c732669a2ae45b8a5eb427e8864446c800
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6991873"
---
# <a name="choosing-the-right-push-notification-channel-type"></a>適切なプッシュ通知チャネルの種類を選択する

この記事では、アプリのコンテンツの提供に役立つ、3 つの種類の UWP プッシュ通知 (プライマリ、セカンダリ、および代替) について説明します。 

(プッシュ通知を作成する方法について詳しくは、 [Windows プッシュ通知サービス (WNS) の概要](../tiles-and-notifications/windows-push-notification-services--wns--overview.md)を参照してください)。 

## <a name="types-of-push-channels"></a>プッシュ チャネルの種類 

UWP アプリに通知を送信するために使用される、3 種類のプッシュ チャネルがあります。 それらは以下のとおりです。 

[プライマリ チャネル](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - "従来型" のプッシュ チャネルです。 任意のストア アプリで、トースト通知、タイル通知、直接通知、バッジ通知 (トースト、タイル、バッジの説明へのリンク) の送信に使用できます。

[セカンダリ タイルのチャネル](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - セカンダリ タイルへのタイルの更新をプッシュするために使用します。 ユーザーのスタート画面にピン留めされているセカンダリ タイルに、タイルやバッジ通知を送信するためのみに使用できます。

[代替チャネル](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - Creators Update で追加された新しい種類のチャネルです。 ストアに登録されていないアプリを含め、任意の UWP アプリに直接通知を送信できます。 

> [!NOTE]
> どのプッシュ チャネルを使用する場合でも、アプリがデバイスで実行されると、ローカルのトースト、タイル、バッジ通知をいつでも送信することができます。 アプリは、フォア グラウンド アプリ プロセスまたはバックグラウンド タスクから、ローカル通知を送信できます。 


## <a name="primary-channels"></a>プライマリ チャネル

これは、Windows で現在、最も一般的に使用されているチャネルです。Microsoft Store を通じて配布されるアプリのほとんどのシナリオに適しています。 アプリにすべての種類の通知を送信できます。 

### <a name="what-do-primary-channels-enable"></a>プライマリ チャネルで可能なこと

-   **プライマリ タイルへのタイルやバッジの更新を送信します。** ユーザーがスタート画面にタイルをピン留めした場合、プライマリ チャネルの効果を発揮できます。 アプリ内で、役に立つ情報の更新やエクスペリエンスのリマインダーを送信できます。 
-   **トースト通知を送信します。** トースト通知を使うと、ユーザーの前に直ちに情報を提供できます。 シェルによりほとんどのアプリの一番上に描画され、さらにアクション センターに残るため、ユーザーは後から参照して操作することができます。 
-   **バックグラウンド タスクをトリガーする直接通知を送信します。** 通知に基づいて、ユーザーに代わって作業を行うことができます。 直接通知を使うと、アプリのバックグラウンド タスクを実行できます。 
-   **Windows は TLS を使用して、転送中のメッセージを暗号化します。** ネットワーク上のメッセージは、WNS の受信メッセージとデバイスへの送信メッセージの両方が暗号化されます。  

### <a name="limitations-of-primary-channels"></a>プライマリ チャネルの制限事項

-   デバイス ベンダー間で標準ではないプッシュ通知には、WNS REST API を使用する必要があります。 
-   アプリごとに 1 つだけのチャネルを作成することができます。 
-   アプリを Microsoft Store に登録する必要があります。

### <a name="creating-a-primary-channel"></a>プライマリ チャネルを作成する 

```csharp
PushNotificationChannel channel = 
    await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
```

## <a name="secondary-tile-channels"></a>セカンダリ タイル チャネル

セカンダリ タイルへタイルとバッジの更新をプッシュするために使用できるチャネルです。 アプリが使用して、ユーザーに関心のあるアクションを通知したり、アプリで操作できる情報を通知したりできます。たとえば、グループ チャットの新しいメッセージや試合のスコアの最新情報などです。 

### <a name="what-do-secondary-tile-channels-enable"></a>セカンダリ タイル チャネルで可能なこと

-   セカンダリ タイルにタイル通知またはバッジ通知を送信します。 セカンダリ タイルは、ユーザーがアプリを繰り返して使うための優れた方法です。 セカンダリ タイルは、ユーザーが関心を持つ情報へのディープ リンクです。タイルにユーザーが関心を持つ情報を表示することにより、アプリを繰り返して使用するようにできます。
-   さまざまなタイル間のチャネルを分離 (期限切れに) します。 これにより、ユーザーによってスタート画面にピン留めされた、さまざまな種類のセカンダリ タイルの間で、バックエンドのロジックを分離することができます。 
-   Windows は TLS を使用して、転送中のメッセージを暗号化します。 ネットワーク上のメッセージは、WNS の受信メッセージとデバイスへの送信メッセージの両方が暗号化されます。  

### <a name="limitations-of-secondary-tile-channels"></a>セカンダリ タイルのチャネルの制限事項

-   トースト通知または直接通知はできません。 セカンダリ タイルに送信されるトースト通知または直接通知は、システムによって無視されます。
-   アプリを Microsoft Store に登録する必要があります。


### <a name="creating-a-secondary-tile-channel"></a>セカンダリ タイルのチャネルを作成する 

```csharp
PushNotificationChannel channel = 
    await PushNotificationChannelManager.CreatePushNotificationChannelForSecondaryTileAsync(tileId);
```

## <a name="alternate-channels"></a>代替チャネル

代替チャネルを使うと、アプリは、Microsoft Store へ登録したりアプリに作成されたプライマリ チャネル以外にプッシュ チャネルを作成したりすることなく、プッシュ通知を送信できます。 
 
### <a name="what-do-alternate-channels-enable"></a>代替チャネルで可能なこと
-   任意の Windows デバイスで実行されている UWP への直接プッシュ通知を送信します。 代替チャネルのみが直接通知を送信できます。
-   アプリは、アプリ内でのさまざまな機能のために、複数の直接プッシュ チャネルを作成できます。 アプリは、最大 1000 の代替チャネルを作成できます。各チャネルは 30 日間有効です。 アプリは各チャネルを個別に管理したり、取り消したりすることができます。
-   代替プッシュ チャネルは、アプリを Microsoft Store に登録することなく、作成できます。 アプリを Microsoft Store に登録することなく、デバイスにインストールする場合でも、プッシュ通知を受信することができます。
-   サーバーは、W3C 標準の REST API および VAPID プロトコルを使用して、通知をプッシュできます。 代替チャネルは、W3C 標準プロトコルを使用します。これにより、保守が必要なサーバー ロジックを簡素化できます。
-   エンド ツー エンドでメッセージの完全な暗号化を行います。 プライマリ チャネルは転送中の暗号化を提供しますが、より高いセキュリティを必要とする場合には、代替チャネルを使うと、アプリは暗号化ヘッダーをパス スルーしてメッセージを保護できます。 

### <a name="limitations-of-alternate-channels"></a>代替チャネルの制限事項
-   アプリは、トースト通知、タイル通知、バッジ通知を送信できません。 代替チャネルは、他の種類の通知の送信機能を制限します。 アプリは、バックグラウンド タスクから、ローカル通知を送信することは可能です。 
-   プライマリ チャネルやセカンダリ タイルのチャネルとは異なる REST API が必要です。 標準 W3C REST API を使用するため、アプリでは、トーストやタイルのプッシュ更新を送信するロジックとは異なるロジックを必要とします。

### <a name="creating-an-alternate-channel"></a>代替チャネルを作成する 

```csharp
PushNotificationChannel webChannel = 
    await PushNotificationChannelManager.Current.CreateRawPushNotificationChannelWithAlternateKeyForApplicationAsync(applicationServerKey, appChannelId);
```

## <a name="channel-type-comparison"></a>チャネルの種類の比較
さまざまな種類のチャネルの比較表を次に示します。

<table>

<tr class="header">
<th align="left"><b>種類</b></th>
<th align="left"><b>トーストをプッシュする</b></th>
<th align="left"><b>タイルバッジをプッシュする</b></th>
<th align="left"><b>直接通知をプッシュする</b></th>
<th align="left"><b>認証</b></th>
<th align="left"><b>API</b></th>
<th align="left"><b>ストアへの登録の必要性</b></th>
<th align="left"><b>チャネル</b></th>
<th align="left"><b>暗号化</b></th>
</tr>


<tr class="odd">
<td align="left">プライマリ</td>
<td align="left">はい</td>
<td align="left">〇 - プライマリ タイルのみ</td>
<td align="left">はい</td>
<td align="left">OAuth</td>
<td align="left">WNS REST API</td>
<td align="left">はい</td>
<td align="left">アプリごとに 1 つ</td>
<td align="left">転送中</td>
</tr>
<tr class="even">
<td align="left">セカンダリ タイル</td>
<td align="left">X</td>
<td align="left">〇 - セカンダリ タイルのみ</td>
<td align="left">X</td>
<td align="left">OAuth</td>
<td align="left">WNS REST API</td>
<td align="left">はい</td>
<td align="left">セカンダリ タイルごとに 1 つ</td>
<td align="left">転送中</td>
</tr>
<tr class="odd">
<td align="left">代替</td>
<td align="left">X</td>
<td align="left">いいえ</td>
<td align="left">はい</td>
<td align="left">VAPID</td>
<td align="left">WebPush W3C 標準</td>
<td align="left">X</td>
<td align="left">アプリあたり 1,000</td>
<td align="left">転送中 + ヘッダー パススルーによりエンドツーエンドの暗号化が可能 (アプリ コードが必要)</td>
</tr>
</table>

## <a name="choosing-the-right-channel"></a>適切なチャンネルを選択する

一般に、いくつかの例外を除き、アプリではプライマリ チャネルを使用することをお勧めします。 

1. セカンダリ タイルにタイルの更新をプッシュする場合は、セカンダリ タイルのプッシュ チャネルを使用します。
2. 他のサービス (ブラウザーの場合など) にチャネルを渡す場合には、代替チャンネルを使用します。
3. Windows ストアに登録しないアプリ (LOB アプリなど) を作成する場合、代替チャネルを使用します。
4. サーバーにある既存の Web プッシュ コードを再利用する場合や、バックエンド サービスで複数のチャネルの必要性がある場合には、代替チャネルを使用します。

## <a name="related-articles"></a>関連記事

* [ローカル タイル通知の送信](../tiles-and-notifications/sending-a-local-tile-notification.md)
* [アダプティブ トースト通知と対話型トースト通知](../tiles-and-notifications/adaptive-interactive-toasts.md)
* [クイック スタート: プッシュ通知の送信](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252)
* [プッシュ通知を使用してバッジを更新する方法](https://msdn.microsoft.com/library/windows/apps/hh465450)
* [通知チャネルを要求、作成、保存する方法](https://msdn.microsoft.com/library/windows/apps/hh465412)
* [実行中のアプリの通知を中断する方法](https://msdn.microsoft.com/library/windows/apps/hh465450)
* [Windows プッシュ通知サービス (WNS) に対して認証する方法](https://msdn.microsoft.com/library/windows/apps/hh465407)
* [プッシュ通知サービスの要求ヘッダーと応答ヘッダー](https://msdn.microsoft.com/library/windows/apps/hh465435)
* [プッシュ通知のガイドラインとチェック リスト](https://msdn.microsoft.com/library/windows/apps/hh761462)
* [直接通知](raw-notification-overview.md)
