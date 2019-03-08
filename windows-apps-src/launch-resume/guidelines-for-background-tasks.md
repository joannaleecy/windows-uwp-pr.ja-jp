---
title: バックグラウンド タスクのガイドライン
description: アプリがバックグラウンド タスクを実行するための要件を満たしていることを確認します。
ms.assetid: 18FF1104-1F73-47E1-9C7B-E2AA036C18ED
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10、uwp、バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: af8e45e13eb89185e346c3c8e8cd5303da399471
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658737"
---
# <a name="guidelines-for-background-tasks"></a>バックグラウンド タスクのガイドライン


アプリがバックグラウンド タスクを実行するための要件を満たしていることを確認します。

## <a name="background-task-guidance"></a>バックグラウンド タスクのガイダンス

バックグラウンド タスクの開発時とアプリの公開前に、次のガイダンスについて検討します。

バックグラウンド タスクを使ってバックグラウンドでメディアを再生する場合、Windows 10 バージョン 1607 で簡単に行うことができる機能強化について、「[バックグラウンドでのメディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)」をご覧ください。

**プロセス内とプロセス外のバック グラウンド タスク。** Windows 10 version 1607 で導入された[プロセス内のバック グラウンド タスク](create-and-register-an-inproc-background-task.md)フォア グラウンド アプリと同じプロセス内でバック グラウンドのコードを実行できます。 インプロセス バックグラウンド タスクとアウトプロセス バックグラウンド タスクのどちらを使用するかを決定するときは、以下の事項を検討してください。

|考慮事項 | 影響 |
|--------------|--------|
|復元性   | バックグラウンド プロセスが別のプロセスで実行されている場合、バックグラウンド プロセスでクラッシュが発生してもフォアグラウンド アプリケーションがダウンしません。 さらに、実行時間制限を過ぎて実行された場合、アプリ内からでもバックグラウンド アクティビティを終了できます。 フォアグラウンド プロセスとバックグラウンド プロセスが互いに通信する必要がない場合は、バックグラウンド処理をフォアグラウンド アプリとは別のタスクに分離することをお勧めします (インプロセス バックグラウンド タスクの主な利点の 1 つは、プロセス間通信が不要になることであるためです)。 |
|シンプルさ    | インプロセス バックグラウンド タスクでは、プロセス間通信が不要のため、記述内容は複雑になりません。  |
|使用可能なトリガー | プロセス内のバック グラウンド タスクは、次のトリガーをサポートしません。[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、 [DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)と**IoTStartupTask**します。 |
|VoIP | インプロセス バックグラウンド タスクでは、アプリケーション内での VoIP バックグラウンド タスクのアクティブ化がサポートされていません。 |  

**トリガーのインスタンスの数の制限:** アプリを登録できるいくつかのトリガーのインスタンスの数の制限があります。 アプリが [ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger)、[MediaProcessingTrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.mediaprocessingtrigger)、および [DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396) を登録できるのは、アプリのインスタンスごとに 1 回のみです。 アプリでこの制限を超えると、登録で例外がスローされます。

**CPU クォータ:** バック グラウンド タスクは、トリガーの種類に基づいて、取得、ウォール クロック使用時間の量によって制限されます。 ほとんどのトリガーは、使用時間がウォールクロック時間で 30 秒に制限されますが、負荷の高いタスクを完了するために最大 10 分実行できるトリガーもあります。 バッテリの寿命を長くし、フォアグラウンド アプリのユーザー エクスペリエンスを高めるため、バックグラウンド タスクは軽量にしてください。 バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

**バック グラウンド タスクを管理するには。** アプリでは、登録されているバック グラウンド タスクの一覧を取得、進行状況と完了ハンドラーの登録、およびそれらのイベントを適切に処理する必要があります。 バックグラウンド タスク クラスでは、進行状況、キャンセル、完了を報告する必要があります。 詳しくは、「[取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)」と「[バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)」をご覧ください。

**使用[BackgroundTaskDeferral](https://msdn.microsoft.com/library/windows/apps/hh700499):** バック グラウンド タスク クラスは、非同期コードを実行する場合は、遅延を使用して確認します。 それ以外の場合、[Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) メソッド (インプロセス バックグラウンド タスクの場合は [OnBackgroundActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) メソッド) により、バックグラウンド タスクが途中で終了する可能性があります。 詳しくは、「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください

別の方法として、保留を 1 回要求し、**async/await** を使って、非同期メソッドの呼び出しを完了させることもできます。 **await** メソッドを呼び出した後、保留を閉じます。

**アプリケーション マニフェストを更新します。** アウト プロセスを実行するバック グラウンド タスクと共に使用するトリガーの種類と共に、アプリケーション マニフェスト内の各バック グラウンド タスクを宣言します。 この宣言がないと、アプリでは実行時にバックグラウンド タスクを登録できません。

複数のバック グラウンド タスクがある場合は、同じホスト プロセスで実行する必要があるか、または別のホスト プロセスに分離する必要があるかどうかを検討してください。 1 つのバック グラウンド タスクでエラーが発生したときに別のバック グラウンド タスクが停止することが心配な場合は、別のホスト プロセスに配置します。  マニフェスト デザイナーの **リソース グループ** エントリを使用してバックグラウンド タスクを別のホスト プロセスにグループ化します。 

**リソース グループ**を設定するには、Package.appxmanifest デザイナーを開き、**[宣言]** を選択し、**[アプリ サービス]** 宣言を追加します。

![リソース グループの設定](images/resourcegroup.png)

リソース グループの設定の詳細については、「[アプリケーション スキーマ リファレンス](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-application)」を参照してください。

フォアグラウンド アプリと同じプロセスで実行されるバックグラウンド タスクは、アプリケーション マニフェストでの自身を宣言する必要はありません。 アウトプロセスで実行されるバックグラウンド タスクをマニフェストで宣言する方法について詳しくは、「[アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)」をご覧ください。

**アプリの更新プログラムを準備します。** 作成し、登録、アプリを更新する場合、 **ServicingComplete**バック グラウンド タスク (を参照してください[SystemTriggerType](https://msdn.microsoft.com/library/windows/apps/br224839))、アプリの以前のバージョンのバック グラウンド タスクを登録解除と登録、新しいバージョンのバック グラウンド タスク。 これは、フォアグラウンドで実行中のコンテキストの外で必要となる可能性があるアプリの更新を実行するのに適したタイミングです。

**バック グラウンド タスクを実行する要求:**

> **重要な**  以降 Windows 10 では、アプリが不要にバック グラウンド タスクを実行する前提条件として、ロック画面上にします。

ユニバーサル Windows プラットフォーム (UWP) アプリは、ロック画面にピン留めしなくても、サポートされているすべての種類のタスクを実行できます。 ただし、どの種類のバックグラウンド タスクを登録する場合でも、その前にアプリが [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。 ユーザーがデバイス設定でバックグラウンド タスクに対するアプリのアクセス許可を明示的に拒否した場合、このメソッドは [**BackgroundAccessStatus.DeniedByUser**](https://msdn.microsoft.com/library/windows/apps/hh700439) を返します。 バックグラウンド アクティビティとバッテリー節約機能についてのユーザーの選択について詳しくは、「[バックグラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)」をご覧ください。 
## <a name="background-task-checklist"></a>バックグラウンド タスクのチェック リスト

*両方のインプロセスおよびアウト プロセスのバック グラウンド タスクに適用されます。*

-   バックグラウンド タスクを適切なトリガーに関連付けます。
-   条件を追加して、バックグラウンド タスクが適切に実行されるようにします。
-   バックグラウンド タスクの進行、完了、取り消しを処理します。
-   アプリ起動時にバックグラウンド タスクを再登録します。 これにより、初めてアプリを起動したときにそれらが登録されるようになります。 また、ユーザーがバックグラウンド タスク実行機能を無効にしたかどうかを検出する方法も提供されます (登録に失敗した場合)。
-   バックグラウンド タスクの登録エラーを確認します。 必要に応じて、別のパラメーター値でバックグラウンド タスクをもう一度登録してみます。
-   デスクトップ以外のすべてのデバイス ファミリでは、デバイスのメモリが少なくなった場合、バックグラウンド タスクが終了することがあります。 メモリ不足の例外が検出されないか、検出されてもアプリによって処理されない場合、バックグラウンド タスクは、警告や OnCanceled イベントの発生なしに終了します。 こうすることで、フォアグラウンドのアプリのユーザー エクスペリエンスが保証されます。 バックグラウンド タスクは、このシナリオを処理できるように設計する必要があります。

*プロセス外のバック グラウンド タスクにのみ適用されます。*

-   Windows ランタイム コンポーネントでバックグラウンド タスクを作成します。
-   バックグラウンド タスクでは、トースト、タイル、バッジの更新以外の UI は表示しません。
-   [Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) メソッドでは、各非同期メソッド呼び出しに対して保留を要求し、メソッドが終了した時点で閉じます。 または、**async/await** で保留を 1 回使用します。
-   固定ストレージを使って、バックグラウンド タスクとアプリ間でデータを共有します。
-   アプリケーション マニフェストで、各バックグラウンド タスクと共に、バックグラウンド タスクで使うトリガーの種類を宣言します。 エントリ ポイントとトリガーの種類が正しいことを確認します。
-   アプリと同じコンテキストで実行する必要があるトリガー ([**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) など) を使う場合を除き、マニフェストでは Executable 要素を指定しないでください。

*プロセス内のバック グラウンド タスクにのみ適用されます。*

- タスクをキャンセルするとき、キャンセルが発生するか、プロセス全体が終了する前に `BackgroundActivated` イベント ハンドラーが終了したことを確認してください。
-   バックグラウンド タスクの存続期間は短くします。 バックグラウンド タスクに使用できる時間は、ウォールクロック時間で 30 秒間に制限されています。
-   バックグラウンド タスクでのユーザー操作に依存することはできません。

## <a name="related-topics"></a>関連トピック

* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)
* [作成して、プロセス外のバック グラウンド タスクの登録](create-and-register-a-background-task.md)
* [アプリケーション マニフェストでバック グラウンド タスクを宣言します。](declare-background-tasks-in-the-application-manifest.md)
* [バック グラウンドでメディアを再生します。](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)
* [取り消されたバック グラウンド タスクを処理します。](handle-a-cancelled-background-task.md)
* [バック グラウンド タスクの進行状況と完了を監視します。](monitor-background-task-progress-and-completion.md)
* [バック グラウンド タスクを登録します。](register-a-background-task.md)
* [バック グラウンド タスクでシステム イベントに応答します。](respond-to-system-events-with-background-tasks.md)
* [バック グラウンド タスクを実行するための条件を設定します。](set-conditions-for-running-a-background-task.md)
* [バック グラウンド タスクからのライブ タイルを更新します。](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーを使用します。](use-a-maintenance-trigger.md)
* [タイマーでバック グラウンド タスクを実行します。](run-a-background-task-on-a-timer-.md)
* [バック グラウンド タスクをデバッグします。](debug-a-background-task.md)
* [トリガーする方法を中断、再開、および (デバッグ) 場合は、UWP アプリでイベントをバック グラウンド](https://go.microsoft.com/fwlink/p/?linkid=254345)

 

 
