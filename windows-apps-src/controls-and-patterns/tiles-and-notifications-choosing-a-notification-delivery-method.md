---
Description: この記事では、タイルとバッジの更新およびトースト通知のコンテンツを配信するための 4 つの通知オプション (ローカル、スケジュール、定期的、プッシュ) について説明します。
title: 通知配信方法の選択
ms.assetid: FDB43EDE-C5F2-493F-952C-55401EC5172B
label: 通知配信方法の選択
template: detail.hbs
---

# 通知配信方法の選択


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


この記事では、タイルとバッジの更新およびトースト通知のコンテンツを配信するための 4 つの通知オプション (ローカル、スケジュール、定期的、プッシュ) について説明します。 タイルやトースト通知では、ユーザーがアプリを直接利用していないときでもユーザーに情報を伝えることができます。 アプリおよび配信する情報の性質と内容から、シナリオに最適な通知方法を決めることができます。

## <span id="Notification_delivery_methods__overview"></span><span id="notification_delivery_methods__overview"></span><span id="NOTIFICATION_DELIVERY_METHODS__OVERVIEW"></span>通知配信方法の概要


通知を配信するためにアプリで使用できるメカニズムには、次の 4 種類があります。

-   **ローカル**
-   **スケジュール**
-   **定期的**
-   **プッシュ**

次の表は、通知配信の種類をまとめたものです。

<table>
<colgroup>
<col width="25%" />
<col width="25%" />
<col width="25%" />
<col width="25%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">配信方法</th>
<th align="left">使用対象</th>
<th align="left">説明</th>
<th align="left">例</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">ローカル</td>
<td align="left">タイル、バッジ、トースト</td>
<td align="left">アプリが実行されている間、タイルやバッジを直接更新している間、またはトースト通知を送信している間に通知を送信する API 呼び出しのセットです。</td>
<td align="left"><ul>
<li>音楽アプリでは、タイルを更新して &quot;再生中&quot; の音楽を表示します。</li>
<li>ゲーム アプリでは、ユーザーがゲームから離れるとタイルを更新してユーザーのハイ スコアを表示します。</li>
<li>グリフでアプリに新しい情報があることが示されたバッジは、アプリがアクティブ化されるとクリアされます。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">スケジュール</td>
<td align="left">タイル、トースト</td>
<td align="left">指定した時間に更新が行われるように事前に通知をスケジュールする API 呼び出しのセットです。</td>
<td align="left"><ul>
<li>カレンダー アプリでは、予定されている会議用のトースト通知のアラームを設定します。</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">定期的</td>
<td align="left">タイル、バッジ</td>
<td align="left">クラウド サービスをポーリングして新しいコンテンツの有無を調べて、タイルとバッジを一定の間隔で定期的に更新する通知です。</td>
<td align="left"><ul>
<li>天気予報アプリでは、予報を表示するタイルを 30 分間隔で更新します。</li>
<li>&quot;日替わりセール情報&quot; サイトでは、本日のお買い得品を毎朝更新します。</li>
<li>イベントまでの日数を表示するタイルでは、表示される日数のカウントダウンを毎日深夜 0 時に更新します。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">プッシュ</td>
<td align="left">タイル、バッジ、トースト、直接</td>
<td align="left">アプリが実行されていなくてもクラウド サーバーから送信される通知です。</td>
<td align="left"><ul>
<li>ショッピング アプリでは、トースト通知を送信して、ユーザーが注目している商品のセール情報を知らせます。</li>
<li>ニュース アプリでは、ニュース速報が発生したときにタイルを更新します。</li>
<li>スポーツ アプリでは、試合の進行中にタイルを更新し続けます。</li>
<li>通信アプリでは、メッセージや電話の着信をアラートで知らせます。</li>
</ul></td>
</tr>
</tbody>
</table>

 

## <span id="Local_notifications"></span><span id="local_notifications"></span><span id="LOCAL_NOTIFICATIONS"></span>ローカル通知


アプリの実行中に行われるタイルまたはバッジの更新やトースト通知の表示は、ローカルの API 呼び出しのみが必要となる、最もシンプルな通知配信メカニズムです。 どのアプリでも、役立つ情報や興味を引く情報をタイルに表示することができます。これは、ユーザーがアプリを起動して操作を開始した後でのみコンテンツが変更される場合でも可能です。 他の通知メカニズムと併用する場合でも、ローカル通知はアプリのタイルを最新の状態にする手段として適しています。 たとえば、フォト アプリのタイルでは、最近追加されたアルバムの写真を表示できます。

アプリによるタイルのローカルな更新は、アプリが最初に起動されたとき、またはアプリによってタイルに反映される変更をユーザーが加えた直後に行うことをお勧めします。 この更新内容は、ユーザーがアプリから離れるまで表示されせんが、アプリが使われている間にタイルを更新することで、ユーザーがアプリから離れたときにタイルは確実に最新の状態になります。

API 呼び出しはローカルですが、通知では Web 画像を参照できます。 Web 画像が、ダウンロードできない場合、破損している場合、または画像の仕様を満たしていない場合、タイルとトーストでは応答が次のように異なります。

-   タイル: 更新情報が表示されません。
-   トースト: 通知は表示されますが、プレースホルダー イメージが使われます。

ローカル通知は無期限ですが、有効期限を明示的に設定することをお勧めします。

詳しくは、次のトピックをご覧ください。

-   [ローカル タイル通知の送信](tiles-and-notifications-sending-a-local-tile-notification.md)
-   [ユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)

## <span id="Scheduled_notifications"></span><span id="scheduled_notifications"></span><span id="SCHEDULED_NOTIFICATIONS"></span>スケジュールされた通知


スケジュールされた通知は、タイルを更新する時刻またはトースト通知を表示する時刻を正確に指定できるローカル通知のサブセットです。 スケジュールされた通知は、会議の招集など、更新される内容があらかじめわかっている場合に適しています。 通知の内容が事前にわからない場合は、プッシュ通知または定期的な通知を使う必要があります。

スケジュールされた通知は、既定で配信されたときから 3 日後に有効期限切れになります。 必要に応じて、明示的な有効期限を設定してこの既定値を上書きできます。

詳しくは、次のトピックをご覧ください。

-   [スケジュールされた通知のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh761464)
-   [ユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)

## <span id="Periodic_notifications"></span><span id="periodic_notifications"></span><span id="PERIODIC_NOTIFICATIONS"></span>定期的な通知


定期的な通知では、最小限のクラウド サービスとクライアントの投資で、ライブ タイルを更新することができます。 この通知は、同じコンテンツを多数のユーザーに配信する方法としても優れています。 クライアント コードでは、Windows がタイルまたはバッジの更新の有無を確認するためにポーリングするクラウドの場所の URL と、ポーリングの頻度を指定します。 各ポーリング間隔で、Windows は URL にアクセスして指定された XML コンテンツをダウンロードして、タイルに表示します。

定期的な通知では、アプリがクラウド サービスをホストする必要があります。このサービスは、アプリをインストールしたすべてのユーザーから指定した間隔でポーリングされます。 トースト通知には定期的な更新を使うことができないので注意してください。トースト通知は、スケジュールされた通知またはプッシュ通知で適切に表示されます。

定期的な通知は、既定でポーリングが実行されたときから 3 日後に有効期限切れになります。 必要に応じて、明示的な有効期限を設定してこの既定値を上書きできます。

詳しくは、次のトピックをご覧ください。

-   [定期的な通知の概要](tiles-and-notifications-periodic-notification-overview.md)
-   [ユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)

## <span id="Push_notifications"></span><span id="push_notifications"></span><span id="PUSH_NOTIFICATIONS"></span>プッシュ通知


プッシュ通知は、リアルタイム データまたはユーザー向けにカスタマイズされたデータと通信する場合に適しています。 また、ニュース速報、ソーシャル ネットワークの更新、インスタント メッセージなどの予測不可能なタイミングで生成されるコンテンツについても、プッシュ通知が使われます。 プッシュ通知は、定期的な通知が適さない即時性を必要とするデータ (スポーツの試合中の得点など) にも役立ちます。

プッシュ通知を利用するには、プッシュ通知チャネルを管理して、通知を送信するタイミングと送信先のユーザーを判断するクラウド サービスが必要です。

プッシュ通知は、既定で Windows プッシュ通知サービス (WNS) によって受信されたときから 3 日後に有効期限切れになります。 必要に応じて、明示的な有効期限を設定してこの既定値を上書きできます。

詳しくは、次のトピックをご覧ください。

-   [Windows プッシュ通知サービス (WNS) の概要](tiles-and-notifications-windows-push-notification-services--wns--overview.md)
-   [プッシュ通知のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh761462)
-   [ユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)

**注**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

## <span id="related_topics"></span>関連トピック


* [ローカル タイル通知の送信](tiles-and-notifications-sending-a-local-tile-notification.md)
* [プッシュ通知のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh761462)
* [スケジュールされた通知のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh761464)
* [トースト通知のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465391)
* [定期的な通知の概要](tiles-and-notifications-periodic-notification-overview.md)
* [Windows プッシュ通知サービス (WNS) の概要](tiles-and-notifications-windows-push-notification-services--wns--overview.md)
* [GitHub でのユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)
 

 






<!--HONumber=Mar16_HO1-->


