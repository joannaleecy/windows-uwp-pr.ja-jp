---
author: TylerMSFT
title: "バックグラウンド タスクのガイドライン"
description: "アプリがバックグラウンド タスクを実行するための要件を満たしていることを確認します。"
ms.assetid: 18FF1104-1F73-47E1-9C7B-E2AA036C18ED
translationtype: Human Translation
ms.sourcegitcommit: 9ef86dcd4ae3d922b713d585543f1def48fcb645
ms.openlocfilehash: 57f4fd2beeb04db44804689e3e46744b4fc03ce5

---

# バックグラウンド タスクのガイドライン

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、「[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)」をご覧ください。\]

アプリがバック グラウンド タスクを実行するための要件を満たしていることを確認します。

## バックグラウンド タスクのガイダンス

バックグラウンド タスクの開発時とアプリの公開前に、次のガイダンスについて検討します。

バックグラウンド タスクを使ってバックグラウンドでメディアを再生する場合、Windows 10 バージョン 1607 で簡単に行うことができる機能強化について、「[バックグラウンドでのメディアの再生](https://msdn.microsoft.com/en-us/windows/uwp/audio-video-camera/background-audio)」をご覧ください。

**単一プロセスのバックグラウンド タスクと個別プロセスのバックグラウンド タスク:** Windows 10 バージョン 1607 には、フォアグラウンド アプリと同じプロセスでバックグラウンド コードを実行できる[単一プロセスのバックグラウンド タスク](create-and-register-a-singleprocess-background-task.md) が導入されました。 バックグラウンド タスクに単一プロセスと個別プロセスのどちらを使うかを決定するときは、以下の要素を検討してください。

|考慮事項 | 影響 |
|--------------|--------|
|復元性   | バックグラウンド プロセスが別のプロセスで実行されている場合、バックグラウンド プロセスでクラッシュが発生してもフォアグラウンド アプリケーションがダウンしません。 さらに、実行時間制限を過ぎて実行された場合、アプリ内からでもバックグラウンド アクティビティを終了できます。 フォアグラウンド プロセスとバックグラウンド プロセスが互いに通信する必要がない場合は、バックグラウンド処理をフォアグラウンド アプリとは別個のタスクに分離することをお勧めします (単一プロセスのバックグラウンド タスクの主な利点の 1 つは、プロセス間通信が不要になることであるためです)。 |
|シンプルさ    | 単一プロセスのバックグラウンド タスクでは、プロセス間通信が不要のため、記述が複雑になりません。  |
|使用可能なトリガー | 単一プロセスのバックグラウンド タスクでは、[DeviceUseTrigger](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** の各トリガーがサポートされていません。 |
|VoIP | 単一プロセスのバックグラウンド タスクでは、アプリケーション内での VoIP バックグラウンド タスクのアクティブ化がサポートされていません。 |  

**CPU の割り当て:** バックグラウンド タスクは、トリガーの種類に基づいて取得するウォールクロック時間の長さによって使用が制限されます。 ほとんどのトリガーは、使用時間がウォールクロック時間で 30 秒に制限されますが、負荷の高いタスクを完了するために最大 10 分実行できるトリガーもあります。 バッテリの寿命を長くし、フォアグラウンド アプリのユーザー エクスペリエンスを高めるため、バックグラウンド タスクは軽量にしてください。 バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

**バックグラウンド タスクを管理する:** アプリでは、登録済みのバックグラウンド タスクの一覧を取得し、進行状況ハンドラーと完了ハンドラーを登録して、各イベントを適切に処理する必要があります。 バックグラウンド タスク クラスでは、進行状況、キャンセル、完了を報告する必要があります。 詳しくは、「[取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)」と「[バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)」をご覧ください。

**Use [BackgroundTaskDeferral](https://msdn.microsoft.com/library/windows/apps/hh700499)を使用する:** バックグラウンド タスク クラスで非同期コードを実行する場合は、保留を使ってください。 それ以外の場合、[Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) メソッド (単一プロセスのバックグラウンド タスクの場合は [OnBackgroundActivated](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) メソッド) により、バックグラウンド タスクが途中で終了する可能性があります。 詳しくは、「[バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。

別の方法として、保留を 1 回要求し、**async/await** を使って、非同期メソッドの呼び出しを完了させることもできます。 **await** メソッドを呼び出した後、保留を閉じます。

**アプリケーション マニフェストを更新する:** 個別プロセスで実行されるバックグラウンド タスクの場合、アプリケーション マニフェストで、各バックグラウンド タスクと共に、バックグラウンド タスクで使うトリガーの種類を宣言します。 この宣言がないと、アプリでは実行時にバックグラウンド タスクを登録できません。

フォアグラウンド アプリと同じプロセスで実行されるバックグラウンド タスクは、アプリケーション マニフェストでの自身を宣言する必要はありません。 個別プロセスで実行されるバックグラウンド タスクをマニフェストで宣言する方法について詳しくは、「[アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)」をご覧ください。

**アプリの更新を準備する:** アプリを更新する場合は、**ServicingComplete** バックグラウンド タスク (「SystemTriggerType[](https://msdn.microsoft.com/library/windows/apps/br224839)」をご覧ください) を作って登録し、以前のバージョンのアプリのバックグラウンド タスクを登録解除して新しいバージョンのバックグラウンド タスクを登録します。 これは、フォアグラウンドで実行中のコンテキストの外で必要となる可能性があるアプリの更新を実行するのに適したタイミングです。

**バックグラウンド タスクを実行する要求:**

> **重要**  Windows 10 以降、バックグラウンド タスクを実行する前提条件として、アプリをロック画面に配置する必要はなくなりました。

ユニバーサル Windows プラットフォーム (UWP) アプリは、ロック画面にピン留めしなくても、サポートされているすべての種類のタスクを実行できます。 ただし、どの種類のバックグラウンド タスクを登録する場合でも、その前にアプリが [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。 ユーザーがデバイス設定でバックグラウンド タスクに対するアプリのアクセス許可を明示的に拒否した場合、このメソッドは [**BackgroundAccessStatus.Denied**](https://msdn.microsoft.com/library/windows/apps/hh700439) を返します。
## バックグラウンド タスクのチェック リスト

*単一プロセスのバックグラウンド タスクと個別プロセスのバックグラウンド タスクの両方に適用されます*

-   バックグラウンド タスクを適切なトリガーに関連付けます。
-   条件を追加して、バックグラウンド タスクが適切に実行されるようにします。
-   バックグラウンド タスクの進行、完了、取り消しを処理します。
-   アプリ起動時にバックグラウンド タスクを再登録します。 これにより、初めてアプリを起動したときにそれらが登録されるようになります。 また、ユーザーがバックグラウンド タスク実行機能を無効にしたかどうかを検出する方法も提供されます (登録に失敗した場合)。
-   バックグラウンド タスクの登録エラーを確認します。 必要に応じて、別のパラメーター値でバックグラウンド タスクをもう一度登録してみます。
-   デスクトップ以外のすべてのデバイス ファミリでは、デバイスのメモリが少なくなった場合、バックグラウンド タスクが終了することがあります。 メモリ不足の例外が検出されないか、検出されてもアプリによって処理されない場合、バックグラウンド タスクは、警告や OnCanceled イベントの発生なしに終了します。 こうすることで、フォアグラウンドのアプリのユーザー エクスペリエンスが保証されます。 バックグラウンド タスクは、このシナリオを処理できるように設計する必要があります。

*個別プロセスのバックグラウンド タスクにのみ適用されます*

-   Windows ランタイム コンポーネントでバックグラウンド タスクを作成します。
-   バックグラウンド タスクでは、トースト、タイル、バッジの更新以外の UI は表示しません。
-   [Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) メソッドでは、各非同期メソッド呼び出しに対して保留を要求し、メソッドが終了した時点で閉じます。 または、**async/await** で保留を 1 回使用します。
-   固定ストレージを使って、バックグラウンド タスクとアプリ間でデータを共有します。
-   アプリケーション マニフェストで、各バックグラウンド タスクと共に、バックグラウンド タスクで使うトリガーの種類を宣言します。 エントリ ポイントとトリガーの種類が正しいことを確認します。
-   アプリと同じコンテキストで実行する必要があるトリガー ([**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) など) を使う場合を除き、マニフェストでは Executable 要素を指定しないでください。

*単一プロセスのバックグラウンド タスクにのみ適用されます*

- タスクをキャンセルするとき、キャンセルが発生するか、プロセス全体が終了する前に `BackgroundActivated` イベント ハンドラーが終了したことを確認してください。
-   バックグラウンド タスクの存続期間は短くします。 バックグラウンド タスクに使用できる時間は、ウォールクロック時間で 30 秒間に制限されています。
-   バックグラウンド タスクでのユーザー操作に依存することはできません。

## Windows: ロック画面対応アプリのバックグラウンド タスクのチェック リスト

ロック画面に配置できるアプリのバックグラウンド タスクを開発する際は、このガイダンスに従ってください。 また、「[ロック画面のタイルのガイドラインとチェック リスト](https://msdn.microsoft.com/library/windows/apps/hh465403)」のガイダンスにも従ってください。

-   ロック画面対応として開発する前に、アプリをロック画面に配置する必要があるかどうかを確認します。 詳しくは、「[ロック画面の概要](https://msdn.microsoft.com/library/windows/apps/hh779720)」を参照してください。

-   ロック画面に配置しなくてもアプリが動作することを確認します。

-   [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543)、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032)、または [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) で登録されたバックグラウンド タスクを組み込み、このタスクをアプリ マニフェストで宣言します。 エントリ ポイントとトリガーの種類が正しいことを確認します。 これは、認定の際に必要になります。これにより、ユーザーはロック画面にアプリを配置することができます。

**注**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブ ドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

## 関連トピック

* [単一プロセス バックグラウンド タスクの作成と登録](create-and-register-a-singleprocess-background-task.md)
* [別のプロセスで実行するバックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
* [バックグラウンドでのメディアの再生](https://msdn.microsoft.com/en-us/windows/uwp/audio-video-camera/background-audio)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [Windows ストア アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Aug16_HO4-->


