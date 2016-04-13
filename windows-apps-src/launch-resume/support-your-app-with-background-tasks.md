---
title: バックグラウンド タスクによるアプリのサポート
description: このセクションのトピックでは、バックグラウンド タスクでトリガーに応答することによって、ユーザー独自の軽量コードをバックグラウンドで実行する方法について説明します。
ms.assetid: EFF7CBFB-D309-4ACB-A2A5-28E19D447E32
---

# バックグラウンド タスクによるアプリのサポート


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


このセクションのトピックでは、バックグラウンド タスクでトリガーに応答することによって、ユーザー独自の軽量コードをバックグラウンドで実行する方法について説明します。 バックグラウンド タスクは、OS がバックグラウンドで実行する軽量のクラスです。 バックグラウンド タスクを使えば、アプリが中断されている、または実行されていないときに機能を提供できます。 また、VOIP、メール、IM などのリアルタイム通信アプリにバックグラウンド タスクを使うこともできます。

バックグラウンド タスクは、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する独立したクラスです。 [
            **BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) クラスを使ってバックグラウンド タスクを登録します。 このクラス名は、バックグラウンド タスクの登録時にエントリ ポイントとして指定するために使われます。

バックグラウンド タスクを直ちに構築する場合は、「[バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。

**ヒント**  Windows 10 以降、バック グラウンド タスクを登録するために、アプリをロック画面に配置する必要はなくなりました。

 

## システム イベントに対するバックグラウンド タスク


アプリでは、[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) クラスを使ってバックグラウンド タスクを登録することにより、システムで生成されたイベントに応答することができます。 アプリは、次のシステム イベント トリガー ([**SystemTriggerType**](https://msdn.microsoft.com/library/windows/apps/br224839) で定義されている) を使うことができます。

| トリガー名                     | 説明                                                                                                    |
|----------------------------------|----------------------------------------------------------------------------------------------------------------|
| **InternetAvailable**            | インターネットが利用可能になります。                                                                                |
| **NetworkStateChange**           | コストや接続の変更などネットワークの変更が行われます。                                              |
| **OnlineIdConnectedStateChange** | アカウントに関連付けられたオンライン ID が変更されます。                                                                 |
| **SmsReceived**                  | インストールされたモバイル ブロードバンド デバイスにより、新しい SMS メッセージが受け取られます。                                         |
| **TimeZoneChange**               | デバイスでタイム ゾーンが変更されます (たとえば、システムが夏時間に合わせて時刻を調整したとき)。 |

 

詳しくは、「[バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)」をご覧ください。

## バックグラウンド タスクの条件


条件を追加すると、バックグラウンド タスクがトリガーされた後でも、バックグラウンド タスクを実行するタイミングを制御することができます。 バックグラウンド タスクは、トリガーされても、条件がすべて満たされるまで実行されません。 次の条件 ([**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) 列挙型で表されます) を使うことができます。

| 条件名           | 説明                       |
|--------------------------|-----------------------------------|
| **InternetAvailable**    | インターネットが利用可能である必要があります。   |
| **InternetNotAvailable** | インターネットが利用不可である必要があります。 |
| **SessionConnected**     | セッションが接続されている必要があります。    |
| **SessionDisconnected**  | セッションが切断されている必要があります。 |
| **UserNotPresent**       | ユーザーが不在である必要があります。            |
| **UserPresent**          | ユーザーが在席している必要があります。         |

 

詳しくは、「[バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)」をご覧ください。

## アプリケーション マニフェストの要件


アプリでバックグラウンド タスクが正常に登録されるには、アプリケーション マニフェストでバックグラウンド タスクを宣言する必要があります。 詳しくは、「[アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)」をご覧ください。

## バックグラウンド タスク


次のリアルタイム トリガーを使うと、バックグラウンドで軽量なカスタム コードを実行できます。

**コントロール チャネル:  **バックグラウンド タスクでは、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) を使って接続が有効な状態を維持し、コントロール チャネルでメッセージを受け取ることができます。 アプリがソケットをリッスンしている場合は、**ControlChannelTrigger** の代わりにソケット ブローカーを使うことができます。 ソケット ブローカーの使用について詳しくは、「[SocketActivityTrigger](https://msdn.microsoft.com/library/windows/apps/dn806009)」をご覧ください。 **ControlChannelTrigger** は、Windows Phone ではサポートされていません。

**タイマー:  **バックグラウンド タスクは、15 分おきに実行できます。また、[**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を使って特定の時刻に実行するように設定することもできます。 詳しくは、「[タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)」をご覧ください。

**プッシュ通知:  **バックグラウンド タスクは、[**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543) に応答して、直接プッシュ通知を受け取ります。

**注**  

ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。

更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。 詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

## システム イベント トリガー


> **注**  [**SystemTriggerType**](https://msdn.microsoft.com/library/windows/apps/br224839) 列挙体には、次のシステム イベント トリガーが含まれています。

| トリガー名            | 説明                                                       |
|-------------------------|-------------------------------------------------------------------|
| **UserPresent**         | ユーザーが在席になったら、バックグラウンド タスクがトリガーされます。   |
| **UserAway**            | ユーザーが不在になったら、バックグラウンド タスクがトリガーされます。    |
| **ControlChannelReset** | コントロール チャネルがリセットされたら、バックグラウンド タスクがトリガーされます。 |
| **SessionConnected**    | セッションが接続されたら、バックグラウンド タスクがトリガーされます。   |

 

以下のシステム イベント トリガーにより、ユーザーがいつアプリをロック画面に配置したか、またアプリをロック画面から削除したか認識できるようになります。

| トリガー名                     | 説明                                  |
|----------------------------------|----------------------------------------------|
| **LockScreenApplicationAdded**   | アプリのタイルがロック画面に追加されます。     |
| **LockScreenApplicationRemoved** | アプリのタイルがロック画面から削除されます。 |

 
## バックグラウンド タスク リソースの制限


バックグラウンド タスクは軽量です。 バックグラウンドの実行を最小限に抑えることにより、フォアグラウンド アプリでの最適なユーザー エクスペリエンスとバッテリ寿命が保証されます。 この設定は、リソース制約をバックグラウンド タスクに適用することにより、強制的に適用されます。

-   バックグラウンド タスクに使用できる時間は、ウォールクロック時間で 30 秒間に制限されています。

## その他のバックグラウンド タスク リソースの制限


### メモリの制限

リソースには制約があるため (特にメモリの少ないデバイスの場合)、バックグラウンド タスクにはメモリの制限が存在する場合があり、これによってバックグラウンド タスクが使うことができるメモリの最大容量が決まります。 バック グラウンド タスクがこの制限を超過する操作を試行すると、操作は失敗し、タスクで処理できるメモリ不足例外が生成されることがあります。 メモリ不足例外がタスクで処理されない場合や、試行された操作がメモリ不足例外を生じさせる性質のものではなかった場合は、タスクが直ちに終了されます。 上限 (あれば) を検出し、進行中のバック グラウンド タスクのメモリ使用量を監視するには、[**MemoryManager**](https://msdn.microsoft.com/library/windows/apps/dn633831) API を使って、現在のメモリ使用量と制限を問い合わせることができます。

### メモリの少ないデバイスにおけるバックグラウンド タスクのあるアプリのデバイスごとの制限

メモリに制約のあるデバイスでは、デバイスにインストールでき、いつでもバックグラウンド タスクを使うことができるアプリの数に制限があります。 この数を超えると、すべてのバックグラウンド タスクを登録するのに必要な [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の呼び出しが失敗します。

### バッテリー セーバー

バッテリー セーバー機能が有効であってもバックグラウンド タスクを実行しプッシュ通知を受信するようにアプリを設定していない限り、デバイスが外部電源に接続されていない状態でバッテリー残量が指定量を下回ると、バッテリー セーバー機能 (有効な場合) によりバックグラウンド タスクが実行されなくなります。 これによりバックグラウンド タスクを登録できなくなることはありません。

## リアルタイム通信に対するバックグラウンド タスク リソース保証


リソース クォータがリアルタイム通信機能に干渉することがないように、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) と [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543) を使ったバックグラウンド タスクごとに CPU リソース保証クォータが確保されます。 リソース クォータは、先ほど説明したように、これらのバックグラウンド タスクに対して一定のままです。

アプリでは、特に何も行わなくても、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) と [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543) を使ったバックグラウンド タスクごとにリソース保証クォータが確保されます。 システムは、これらのタスクを常に重要なバックグラウンド タスクとして扱います。

## メンテナンス トリガー


メンテナンス タスクは、デバイスが AC 電源に接続されているときにだけ実行されます。 詳しくは、「[メンテナンス トリガーの使用](use-a-maintenance-trigger.md)」をご覧ください。

## センサーとデバイスのバックグラウンド タスク


アプリでは、[**DeviceUseTrigger**](https://msdn.microsoft.com/library/windows/apps/dn297337) クラスによりバックグラウンド タスクからセンサーと周辺デバイスにアクセスできます。 このトリガーは、データの同期や監視など長期間にわたる操作に使用できます。 システム イベントのタスクとは異なり、**DeviceUseTrigger** タスクは、アプリがフォアグラウンドで実行されており条件が設定されていない場合にのみトリガーできます。

時間がかかるファームウェア更新など、一部の重要なデバイス操作は、[**DeviceUseTrigger**](https://msdn.microsoft.com/library/windows/apps/dn297337) では実行できません。 このような操作は PC でのみ、[**DeviceServicingTrigger**](https://msdn.microsoft.com/library/windows/apps/dn297315) を使う特権アプリによってのみ実行できます。 *特権アプリ*とは、これらの操作を実行する権限をデバイス製造元から与えられているアプリです。 デバイス メタデータを使って、どのアプリがデバイスの特権アプリであるか (存在する場合) を指定します。 詳しくは、「[Windows ストア デバイス アプリによるデバイスの同期と更新](http://go.microsoft.com/fwlink/p/?LinkId=306619)」をご覧ください。

## バックグラウンド タスクの管理


バックグラウンド タスクは、イベントとローカル ストレージを使って進行状況、完了、キャンセルをアプリに報告できます。 アプリは、バックグラウンド タスクがスローした例外をキャッチしたり、アプリの更新中にバックグラウンド タスクの登録を行うこともできます。 詳しくは、次のトピックをご覧ください。

[取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)

[バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)

**注**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

## 関連トピック


**Windows 10 におけるマルチタスクの概念的ガイダンス**

* [起動、再開、マルチタスク](index.md)

**関連するバックグラウンド タスクのガイダンス**

* [バックグラウンド タスクからのセンサーやデバイスへのアクセス](access-sensors-and-devices-from-a-background-task.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [Windows ストア アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)
* [Windows ストア デバイス アプリによるデバイスの同期と更新](http://go.microsoft.com/fwlink/p/?LinkId=306619)

 

 





<!--HONumber=Mar16_HO1-->


