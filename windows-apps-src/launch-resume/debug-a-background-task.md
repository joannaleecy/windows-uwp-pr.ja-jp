---
author: TylerMSFT
title: バックグラウンド タスクのデバッグ
description: バックグラウンド タスクをデバッグする方法について説明します。バックグラウンド タスクのアクティブ化のほか、Windows イベント ログでのデバッグ トレースなどについて取り上げます。
ms.assetid: 24E5AC88-1FD3-46ED-9811-C7E102E01E9C
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
ms.openlocfilehash: 03b1e6a5fce559e9e6bf900bae3e3f83921567e6
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6191535"
---
# <a name="debug-a-background-task"></a>バックグラウンド タスクのデバッグ


**重要な API**
-   [Windows.ApplicationModel.Background](https://msdn.microsoft.com/library/windows/apps/br224847)

バックグラウンド タスクをデバッグする方法について説明します。バックグラウンド タスクのアクティブ化のほか、Windows イベント ログでのデバッグ トレースなどについて取り上げます。

## <a name="debugging-out-of-process-vs-in-process-background-tasks"></a>アウトプロセス バックグラウンド タスクのデバッグとインプロセス バックグラウンド タスクのデバッグ
このトピックでは主に、ホスト アプリとは別のプロセスで実行されているバックグラウンド タスクについて扱います。 インプロセス バックグラウンド タスクをデバッグする場合、別個のバックグラウンド タスク プロジェクト タスクはいらず、**OnBackgroundActivated()** (インプロセス バックグラウンド コードが実行される場所) にブレークポイントを設定できます。実行するバックグラウンド コードをトリガーする手順については、以下の「[バックグラウンド タスク コードをデバッグするためバックグラウンド タスクを手動でトリガー](#trigger-background-tasks-manually-to-debug-background-task-code)」をご覧ください。

## <a name="make-sure-the-background-task-project-is-set-up-correctly"></a>バックグラウンド タスク プロジェクトが正しく設定されていることを確認

このトピックは、デバッグ対象のバックグラウンド タスクを備えたアプリが既に手元にあることを前提としています。 以下の内容は、アウトプロセスで実行されるバックグラウンド タスクに固有の内容であり、インプロセス バックグラウンド タスクには適用されません。

-   C# と C++ の場合、メイン プロジェクトがバックグラウンド タスク プロジェクトを参照していることを確認します。 この参照が行われない場合、アプリ パッケージにバックグラウンド タスクが含まれていない可能性があります。
-   C# と C++ の場合、バックグラウンド タスク プロジェクトの **Output type** が "Windows ランタイム コンポーネント" になっていることを確認します。
-   バック グラウンド クラスは、パッケージ マニフェストのエントリ ポイント属性で宣言する必要があります。

## <a name="trigger-background-tasks-manually-to-debug-background-task-code"></a>バックグラウンド タスク コードをデバッグするためバックグラウンド タスクを手動でトリガー

バックグラウンド タスクは、Microsoft Visual Studio を使って手動でトリガーできます。 その後で、コードをステップ実行してデバッグできます。

1.  C# では、バックグラウンド クラスの Run メソッドにブレークポイントを置き (インプロセス バックグラウンド タスクの場合は、App.OnBackgroundActivated() にブレークポイントを置きます)、[**System.Diagnostics**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441592.aspx) を使ってデバッグ出力を記述します。

    C++ では、バックグラウンド クラスの Run 関数にブレークポイントを置き (インプロセス バックグラウンド タスクの場合は、App.OnBackgroundActivated() にブレークポイントを置きます)、[**OutputDebugString**](https://msdn.microsoft.com/library/windows/desktop/aa363362) を使ってデバッグ出力を記述します。

2.  デバッガーでアプリケーションを実行し、**[ライフサイクル イベント]** ツール バーを使ってバックグラウンド タスクをトリガーします。 このドロップダウンには、Visual Studio でアクティブ化できるバックグラウンド タスクの名前が表示されます。

    この機能を使うには、バックグラウンド タスクが既に登録されていて、トリガーを待機する状態になっていることが必要です。 たとえば、1 回限りの TimeTrigger に対してバックグラウンド タスクを登録した場合、そのトリガーが起動された後に Visual Studio からそのタスクを起動しても何も起こりません。

> [!Note]
> 次のトリガーを使ったバックグラウンド タスクを、[**アプリケーション トリガー**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.applicationtrigger.aspx)、[**MediaProcessing トリガー**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.mediaprocessingtrigger.aspx)、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032)、[**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543)、[**SmsReceived**](https://msdn.microsoft.com/library/windows/apps/br224839) トリガー型の [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) を使ったバックグラウンド タスク、という方法でアクティブ化することはできません。  
> **Application trigger** と **MediaProcessingTrigger** は、`trigger.RequestAsync()` を使ってコードで手動通知できます。

![バック グラウンド タスクのデバッグ](images/debugging-activation.png)

3.  バックグラウンド タスクがアクティブになると、デバッガーがアタッチされて、デバッグ出力が VS に表示されます。

## <a name="debug-background-task-activation"></a>バックグラウンド タスクのアクティブ化のデバッグ

> [!NOTE]
> このセクションは、アウトプロセスで実行されるバックグラウンド タスクに固有の内容であり、インプロセス バックグラウンド タスクには適用されません。

バックグラウンド タスクのアクティブ化は、次の 3 つの点に依存します。

-   バック グラウンド タスク クラスの名前と名前空間
-   パッケージ マニフェストで指定されたエントリ ポイント属性
-   バックグラウンド タスクの登録時にアプリによって指定されたエントリ ポイント

1.  Visual Studio を使い、バックグラウンド タスクのエントリ ポイントを確認します。

    -   C# と C++ の場合、バックグラウンド タスク プロジェクトで指定されたバックグラウンド タスク クラスの名前と名前空間を確認します。

2.  マニフェスト デザイナーを使い、バックグラウンド タスクがパッケージ マニフェストで正しく宣言されているかどうかを確認します。

    -   C# と C++ の場合、エントリ ポイント属性が、クラス名の前のバックグラウンド タスク名前空間と一致している必要があります。 たとえば、RuntimeComponent1.MyBackgroundTask のようになります。
    -   タスクと共に使われるトリガー タイプがすべて指定されている必要があります。
    -   [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) または [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543) を使う場合以外、実行可能ファイルを指定しないでください。

3.  Windows のみ。 バックグラウンド タスクをアクティブ化するために Windows で使われるエントリ ポイントを確認するには、デバッグ トレースを有効にして Windows イベント ログを使います。

    この手順を実行し、その結果イベント ログにバックグラウンド タスクの間違ったエントリ ポイントまたはトリガーが表示される場合は、アプリにバックグラウンド タスクが正しく登録されていません。 このタスクのヘルプが必要な場合は、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。

    1.  スタート画面に移動して eventvwr.exe を検索し、イベント ビューアーを開きます。
    2.  **アプリケーションとサービス ログ**に移動 -&gt; **Microsoft**  - &gt; **Windows**  - &gt;イベント ビューアーで**BackgroundTaskInfrastructure**します。
    3.  [操作] ウィンドウ**のビュー**を選択 -&gt; **を表示する分析およびデバッグ ログ**診断ログを有効にします。
    4.  **診断ログ**を選び、**[ログの有効化]** をクリックします。
    5.  次に、アプリを使ってバックグラウンド タスクの登録とアクティブ化をもう一度試します。
    6.  診断ログで、詳しいエラー情報を確認します。 このログには、バックグラウンド タスクに登録されたエントリ ポイントが含まれます。

![イベント ビューアーでバックグラウンド タスクのデバッグ情報を表示](images/event-viewer.png)

## <a name="background-tasks-and-visual-studio-package-deployment"></a>バックグラウンド タスクと Visual Studio パッケージの展開

バックグラウンド タスクを使ったアプリが Visual Studio を使って展開され、その後、マニフェスト デザイナーで指定されたバージョン (メジャー バージョンとマイナー バージョン、またはそのどちらか一方) が更新された場合、以後、Visual Studio を使ってそのアプリを再展開すると、アプリのバックグラウンド タスクが停止することがあります。 これは、次のようにして対処できます。

-   更新したアプリを (Visual Studio ではなく) Windows PowerShell を使って展開します。パッケージと一緒に生成されるスクリプトを実行してください。
-   既に Visual Studio でアプリを展開したことによってアプリのバックグラウンド タスクが停止している場合は、再起動するか、いったんログオフしてからログインし直し、アプリのバックグラウンド タスクをもう一度作動させます。
-   C# プロジェクトでは、"パッケージを常に再インストール" というデバッグ オプションを選ぶことで、この問題を回避することができます。
-   展開用にアプリが最終確定するのを待ってパッケージのバージョンをインクリメントします (デバッグ中は変更しない)。

## <a name="remarks"></a>注釈

-   バックグラウンド タスクは、同じバックグラウンド タスクが登録されていないことをアプリ側で必ずチェックしたうえで登録してください。 同じバックグラウンド タスクを重複して登録すると、1 回のトリガーにつきバックグラウンド タスクが複数回実行され、予期しない結果を招きます。
-   バックグラウンド タスクがロック画面へのアクセスを必要とする場合は、バックグラウンド タスクをデバッグする前にロック画面にアプリを配置してください。 ロック画面対応アプリのマニフェスト オプションを指定する方法については、「[アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)」をご覧ください。
-   バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。

VS を使ってバック グラウンド タスクのデバッグについて詳しくは、以下を参照してください。[をトリガーする方法の一時停止、再開、および UWP アプリでイベントをバック グラウンド](https://msdn.microsoft.com/library/windows/apps/xaml/hh974425.aspx)します。

## <a name="related-topics"></a>関連トピック

* [アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [トリガーする方法の一時停止、再開、および UWP アプリでイベントをバック グラウンド](https://msdn.microsoft.com/library/windows/apps/xaml/hh974425.aspx)
* [Visual Studio のコード分析による UWP アプリのコードの品質の分析](https://msdn.microsoft.com/library/windows/apps/xaml/hh441471.aspx)

 

 
