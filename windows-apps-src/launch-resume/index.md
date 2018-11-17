---
author: TylerMSFT
title: 起動、再開、バックグラウンド タスク
description: このセクションでは、ユニバーサル Windows プラットフォーム (UWP) アプリが起動、中断、再開、および終了されたときの動作について説明します。
ms.assetid: 75011D52-1511-4ECF-9DF6-52CBBDB15BD7
ms.author: twhitney
ms.date: 10/04/2017
ms.topic: article
keywords: windows 10, uwp, バック グラウンド タスクでは、アプリのサービスに接続されているデバイス、リモート システム
ms.localizationpriority: medium
ms.openlocfilehash: bb036f0150095e6f02857d227e73b1c7f29b23df
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7156310"
---
# <a name="launching-resuming-and-background-tasks"></a>起動、再開、およびバックグラウンド タスク


ここでは、次の項目について説明します。

- ユニバーサル Windows プラットフォーム (UWP) アプリが起動、中断、再開、および終了されたときの動作。
- URI またはファイルのアクティブ化によってアプリをアクティブ化する方法。
- ユニバーサル Windows プラットフォーム (UWP) アプリが、他のアプリとデータや機能を共有できるアプリ サービスの使用方法。
- バックグラウンド タスクを使って UWP アプリがフォアグラウンドにない場合でも処理を実行できるようにする方法。
- 接続されているデバイスを検出したり、別のデバイス上でアプリを起動したり、リモート デバイスのアプリ サービスと通信して、デバイスに依存しないユーザー エクスペリエンスを実現できるようにする方法。
- アプリの拡張とコンポーネント化に適切なテクノロジを選択する方法。
- アプリにスプラッシュ画面を追加して構成する方法。
- ユーザーが Microsoft Store からインストールできるパッケージを使用してアプリを書き込み拡張する方法。

## <a name="the-app-lifecycle"></a>アプリのライフサイクル

このセクションでは、Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリのライフサイクル (アプリがアクティブ化されたときから、アプリが閉じられるまで) について詳しく説明します。

| トピック | 説明 |
|-------|-------------|
| [アプリのライフ サイクル](app-lifecycle.md)               | UWP アプリのライフ サイクルと、Windows がアプリを起動、中断、再開したときの動作について説明します。 |
| [アプリの事前起動の処理](handle-app-prelaunch.md) | アプリの事前起動を処理する方法について説明します。                                                                              |
| [アプリのアクティブ化の処理](activate-an-app.md)     | アプリのアクティブ化を処理する方法について説明します。                                                                             |
| [アプリの中断の処理](suspend-an-app.md)         | システムがアプリを一時停止するときに重要なアプリケーション データを保存する方法を説明します。                                 |
| [アプリの再開の処理](resume-an-app.md)           | システムがアプリを再開するときに表示されるコンテンツを更新する方法について説明します。                                        |
| [アプリがバックグラウンドに移動したときの空きメモリ](reduce-memory-usage.md) | バックグラウンド状態になっているときにアプリで使用するメモリ量を減らして、アプリが終了しないようにする方法を説明します。|
| [延長実行を使ってアプリの中断を延期する](run-minimized-with-extended-execution.md) | 延長実行を使用して、アプリが最小化されているときにアプリの実行を保持する方法について説明します。 |

## <a name="launch-apps"></a>アプリの起動

| トピック | 説明 |
|-------|-------------|
| [ユニバーサル Windows プラットフォームを使用してコンソール アプリを作成する](console-uwp.md) | コンソール ウィンドウで実行されるユニバーサル Windows プラットフォーム アプリを作成する方法について説明します。 |
| [マルチインスタンスの UWP アプリを作成する](multi-instance-uwp.md) | マルチインスタンスのユニバーサル Windows プラットフォーム アプリを記述する方法について説明します。 |

「[URI を使ったアプリの起動](launch-app-with-uri.md)」セクションでは、URI (Uniform Resource Identifier) を使ってアプリを起動する方法について説明します。

| トピック | 説明 |
|-------|-------------|
| [URI に応じた既定のアプリの起動](launch-default-app.md) | URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。 URI を使うと、別のアプリを起動して特定の作業を実行できます。 また、Windows に組み込まれている多くの URI スキームの概要についても説明します。 |
| [URI のアクティブ化の処理](handle-uri-activation.md) | URI (Uniform Resource Identifier) スキーム名の既定のハンドラーとしてアプリを登録する方法について説明します。 |
| [結果を取得するためのアプリの起動](how-to-launch-an-app-for-results.md) | 別のアプリからアプリを起動し、2 つのアプリの間でデータを交換する方法について説明します。 これは、"結果を取得するためのアプリの起動" と呼ばれます。 |
| [ms-tonepicker URI スキームを使ったトーンの選択と保存](launch-ringtone-picker.md) | このトピックでは、ms-tonepicker URI スキームと、このスキームを使ってトーンの選択コントロールを表示し、トーンの選択、トーンの保存、トーンのフレンドリ名を取得する方法について説明します。 |
| [Windows 設定アプリの起動](launch-settings-app.md) | アプリから Windows 設定アプリを起動する方法について説明します。 ここでは、ms-settings URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。 |
| [Microsoft Store アプリの起動](launch-store-app.md) | このトピックでは、ms-windows-store URI スキームについて説明します。 アプリでこの URI スキームを使って、UWP アプリを起動し、Store 内の特定のページを表示できます。 |
| [Windows マップ アプリの起動](launch-maps-app.md) | アプリから Windows マップ アプリを起動する方法について説明します。 |
| [People アプリの起動](launch-people-apps.md) | ここでは、ms-people URI スキームについて説明します。 アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。 |
| [アプリの URI ハンドラーを使用して Web とアプリのリンクをサポートする](web-to-app-linking.md) | アプリの URI ハンドラーを使用して、ユーザーがアプリを利用するように促します。 |

「[ファイルのアクティブ化によるアプリの起動](launch-app-from-file.md)」セクションでは、特定の種類のファイルを開くと、アプリが起動するように設定する方法について説明します。

| トピック | 説明 |
|-------|-------------|
| [ファイルに応じた既定のアプリの起動](launch-the-default-app-for-a-file.md) | ファイルに応じて既定のアプリを起動する方法について説明します。 |
| [ファイルのアクティブ化の処理](handle-file-activation.md) | アプリを特定のファイルの種類の既定のハンドラーとして登録する方法について説明します。 |

アプリの起動に関するその他のトピックについては、以下をご覧ください。

| トピック | 説明 |
|-------|-------------|
| [デバイス間でもユーザーのアクティビティを継続する](useractivities.md) | ユーザーが放置した場所でアプリを起動することで、アプリを使用してユーザーとデバイス間でもつながります。 |
| [自動再生による自動起動](auto-launching-with-autoplay.md) | 自動再生を使って、コンピューターにデバイスが接続されたときのオプションとしてアプリを提供できます。 これには、カメラやメディア プレーヤーなどのボリューム デバイス以外のデバイス、または USB サム ドライブ、SD カード、DVD などのボリューム デバイスが含まれます。 |
| [予約済みのファイルと URI スキーム名](reserved-uri-scheme-names.md) | ここでは、アプリで利用できない予約済みのファイルと予約済みの URI スキーム名の一覧を示します。 |

## <a name="app-services-and-extensions"></a>アプリ サービスと拡張機能

「[アプリ サービスと拡張機能](app-services.md)」セクションでは、アプリ サービスを UWP アプリに統合して、アプリ間でデータと機能を共有できるようにする方法について説明します。

| トピック | 説明 |
|-------|-------------|
| [アプリ サービスの作成と利用](how-to-create-and-consume-an-app-service.md) | 他のユニバーサル Windows プラットフォーム (UWP) アプリにサービスを提供できる UWP アプリを作成する方法と、それらのサービスを利用する方法について説明します。 |
| [ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md) | 別のバックグラウンド プロセスで実行されたアプリ サービスのコードを、アプリ サービスのプロバイダーと同じプロセス内で実行されるコードに変換します。 |
| [アプリ サービス、拡張機能、パッケージでアプリを拡張する](extend-your-app-with-services-extensions-packages.md) | アプリを拡張してコンポーネント化するために使用する技術を判断し、それぞれの概要を確認します。 |
| [アプリ拡張機能の作成と利用](how-to-create-an-extension.md) | ユニバーサル Windows プラットフォーム (UWP) アプリの拡張機能を作成してホストすると、Microsoft Store からユーザーがインストールできるパッケージを介してアプリを拡張できます。 |

## <a name="background-tasks"></a>バックグラウンド タスク

「[バックグラウンド タスク](support-your-app-with-background-tasks.md)」セクションでは、トリガーに対応して軽量コードをバックグラウンドで実行する方法について説明します。

| トピック | 説明 |
|-------|-------------|
| [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)                                       | アプリがバックグラウンド タスクを実行するための要件を満たしていることを確認します。 |
| [バックグラウンド タスクからのセンサーやデバイスへのアクセス](access-sensors-and-devices-from-a-background-task.md)   | [**DeviceUseTrigger**](https://msdn.microsoft.com/library/windows/apps/dn297337) を使うと、フォアグラウンド アプリが中断しているときにも、バックグラウンドでユニバーサル Windows アプリからセンサーや周辺機器にアクセスできます。 |
| [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)       | フォアグラウンド アプリと同じプロセスで実行されるバックグラウンド タスクを作成して登録します。 |
| [アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)           | アプリとは別のプロセスで実行されるバックグラウンド タスクを作成して登録し、アプリがフォアグラウンドにないときに実行するように登録します。 |
| [アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクに移植する](convert-out-of-process-background-task.md) | フォア グラウンド アプリと同じプロセスで実行されるインプロセスのバック グラウンド タスクをアウト プロセス バック グラウンド タスクを移植する方法について説明します。|
| [バックグラウンド タスクのデバッグ](debug-a-background-task.md)                                                       | バックグラウンド タスクをデバッグする方法について説明します。バックグラウンド タスクのアクティブ化のほか、Windows イベント ログでのデバッグ トレースなどについて取り上げます。 |
| [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md) | アプリ マニフェストでバックグラウンド タスクを拡張機能として宣言し、バックグラウンド タスクを使うことができるようにします。 |
| [バックグラウンド タスクの登録のグループ化](group-background-tasks.md)                                             | グループによってバックグラウンド タスクの登録を分離します。 |
| [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)                                 | 取り消し要求を認識し、作業を停止して、固定ストレージを使っているアプリの取り消しを報告するバックグラウンド タスクの作成方法について説明します。 |
| [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)       | バックグラウンド タスクの進行状況と完了をアプリから認識する方法について説明します。 |
| [バックグラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) |バックグラウンドで消費されるエネルギーを低減する方法や、バックグラウンド アクティビティの設定を操作する方法を説明します。 |
| [バックグラウンド タスクの登録](register-a-background-task.md)                                                 | ほとんどのバックグラウンド タスクを安全に登録できる再利用可能な関数の作成方法について説明します。 |
| [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)         | [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) イベントに応答するバックグラウンド タスクを作成する方法について説明します。 |
| [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)                                    | 1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。 |
| [バックグラウンドで無期限に実行する](run-in-the-background-indefinetly.md)                                    | 機能を使用すると、バックグラウンドで無期限にバックグラウンド タスクまたは延長実行セッションを実行できます。 |
| [アプリ内からのバックグラウンド タスクのトリガー](trigger-background-task-from-app.md) | [ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger) を使ってアプリ内からバックグラウンド タスクをアクティブ化する方法について説明します。|
| [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)             | バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。 |
| [バックグラウンドでのデータの転送](https://msdn.microsoft.com/library/windows/apps/mt280377)                 | バックグラウンド転送 API を使って、バックグラウンドでファイルをコピーします。 |
| [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)                   | アプリのライブ タイルを新しいコンテンツで更新するためにバックグラウンド タスクを使います。 |
| [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)                                                   | デバイスが接続されているときに、[**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) クラスを使って軽量のコードをバックグラウンドで実行する方法について説明します。 |

## <a name="remote-systems"></a>リモート システム

「[接続されているアプリやデバイス ("Rome" プロジェクト)](connected-apps-and-devices.md)」セクションでは、Remote Systems プラットフォームを使って、リモート デバイスの検出、リモート デバイスでのアプリの起動、リモート デバイス上のアプリ サービスとの通信を行う方法について説明します。

| トピック | 説明 |
|-------|-------------|
| [リモート デバイスの検出](discover-remote-devices.md)  | 接続できるデバイスを検出する方法について説明します。 |
| [リモート デバイスでのアプリの起動](launch-a-remote-app.md) | リモート デバイスでアプリを起動する方法について説明します。  |
| [リモート アプリ サービスとの通信](communicate-with-a-remote-app-service.md) | リモート デバイスのアプリを操作する方法について説明します。 |
| [リモート セッションでデバイスを接続する](remote-sessions.md) | リモート セッションで複数のデバイスを結合することにより、これらのデバイス間で共有エクスペリエンスを作成します。 |

## <a name="splash-screens"></a>スプラッシュ画面

「[スプラッシュ画面](splash-screens.md)」セクションでは、アプリのスプラッシュ画面を設定および構成する方法について説明します。

| トピック | 説明 |
|-------|-------------|
| [スプラッシュ画面の追加](add-a-splash-screen.md) | アプリのスプラッシュ画面の画像と背景色を設定します。 |
| [スプラッシュ画面の表示時間の延長](create-a-customized-splash-screen.md) | アプリに追加スプラッシュ画面を作成すれば、より長い時間、スプラッシュ画面を表示することができます。 この追加画面は、アプリを起動したときに表示されるスプラッシュ画面に似ていますが、カスタマイズできます。 |
