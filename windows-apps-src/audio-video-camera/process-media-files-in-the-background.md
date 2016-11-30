---
author: drewbatgit
ms.assetid: B5E3A66D-0453-4D95-A3DB-8E650540A300
description: "この記事では、MediaProcessingTrigger とバックグラウンド タスクを使って、バックグラウンドでメディア ファイルを処理する方法について説明します。"
title: "バックグラウンドでのメディア ファイルの処理"
translationtype: Human Translation
ms.sourcegitcommit: fb0e8a535ff4e27530fa45aca80b21f17a523c7b
ms.openlocfilehash: 8a65ce9ed9de050bbcee2612bf53c5bfd44ffc72

---

# バックグラウンドでのメディア ファイルの処理

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


この記事では、[**MediaProcessingTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806005) とバックグラウンド タスクを使って、バックグラウンドでメディア ファイルを処理する方法について説明します。

この記事で説明するサンプル アプリを使うと、ユーザーは入力メディア ファイルを選んでコード変換し、コード変換結果の出力ファイルを指定できます。 次に、バックグラウンド タスクが起動してコード変換操作が実行されます。 [**MediaProcessingTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806005) は、コード変換だけでなくさまざまなメディア処理シナリオ (ディスクへのメディア コンポジションのレンダリング、処理の完了後の処理済みメディア ファイルのアップロードなど) をサポートすることを目的としています。

このサンプルで利用されているさまざまなユニバーサル Windows アプリ機能について詳しくは、次をご覧ください。

-   [メディア ファイルのコード変換](transcode-media-files.md)
-   [起動、再開、バックグラウンド タスク](https://msdn.microsoft.com/library/windows/apps/mt227652)
-   [タイル、バッジ、および通知](https://msdn.microsoft.com/library/windows/apps/mt185606)

## メディア処理のバックグラウンド タスクの作成

Microsoft Visual Studio で既存のソリューションにバックグラウンド タスクを追加するには、コンポーネントの名前を入力します。

1.  **[ファイル]** メニューの **[追加]** をクリックし、**[新しいプロジェクト]** をクリックします。
2.  プロジェクトの種類として **[Windows ランタイム コンポーネント (ユニバーサル アプリ)]** を選びます。
3.  新しいコンポーネント プロジェクトの名前を入力します。 この例では、プロジェクト名として **MediaProcessingBackgroundTask** を使います。
4.  [OK] をクリックします。

**ソリューション エクスプ ローラー**で、既定で作成された "Class1.cs" ファイルのアイコンを右クリックし、**[名前の変更]** をクリックします。 ファイル名を "MediaProcessingTask.cs" に変更します。 Visual Studio に、このクラスへのすべての参照の名前を変更するかどうかを確認するメッセージが表示されたら、**[はい]** をクリックします。

名前が変更されたクラス ファイルで、次の **using** ディレクティブを追加してこれらの名前空間をプロジェクトに含めます。
                                  
[!code-cs[BackgroundUsing](./code/MediaProcessingTriggerWin10/cs/MediaProcessingBackgroundTask/MediaProcessingTask.cs#SnippetBackgroundUsing)]

クラスの宣言を更新して、クラスを [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) から継承します。

[!code-cs[BackgroundClass](./code/MediaProcessingTriggerWin10/cs/MediaProcessingBackgroundTask/MediaProcessingTask.cs#SnippetBackgroundClass)]

次のメンバー変数をクラスに追加します。

-   [**IBackgroundTaskInstance**](https://msdn.microsoft.com/library/windows/apps/br224797)。バックグラウンド タスクの進行状況によってフォアグラウンド アプリを更新するために使われます。
-   [**BackgroundTaskDeferral**](https://msdn.microsoft.com/library/windows/apps/hh700499)。メディアのコード変換が非同期的に実行されている間も、システムがバックグラウンド タスクをシャットダウンしないようにします。
-   **CancellationTokenSource** オブジェクト。非同期コード変換操作を取り消すために使うことができます。
-   [**MediaTranscoder**](https://msdn.microsoft.com/library/windows/apps/br207080) オブジェクト。メディア ファイルのコード変換に使われます。

[!code-cs[BackgroundMembers](./code/MediaProcessingTriggerWin10/cs/MediaProcessingBackgroundTask/MediaProcessingTask.cs#SnippetBackgroundMembers)]

タスクが起動すると、システムはバックグラウンド タスクの [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドを呼び出します。 メソッドに渡される [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) オブジェクトを、対応するメンバー変数に設定します。 システムがバックグラウンド タスクをシャットダウンする必要がある場合に発生する [**Canceled**](https://msdn.microsoft.com/library/windows/apps/br224798) イベントのハンドラーを登録します。 次に、[**Progress**](https://msdn.microsoft.com/library/windows/apps/br224800) プロパティを 0 に設定します。

次に、バックグラウンド タスク オブジェクトの [**GetDeferral**](https://msdn.microsoft.com/library/windows/apps/hh700507) メソッドを呼び出して保留を取得します。 非同期操作の実行中のため、タスクをシャットダウンしないようにシステムに指示されます。

次に、次のセクションで定義するヘルパー メソッド **TranscodeFileAsync** を呼び出します。 正常に完了した場合、ヘルパー メソッドが呼び出され、コード変換が完了したことをユーザーに通知するトースト通知が起動されます。

**Run** メソッドの最後に、保留オブジェクトで [**Complete**](https://msdn.microsoft.com/library/windows/apps/hh700504) を呼び出して、バックグラウンド タスクが完了したため終了できることをシステムが認識できるようにします。

[!code-cs[Run](./code/MediaProcessingTriggerWin10/cs/MediaProcessingBackgroundTask/MediaProcessingTask.cs#SnippetRun)]

**TranscodeFileAsync** ヘルパー メソッドで、コード変換操作の入力ファイルと出力ファイルのファイル名がアプリの [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) から取得されます。 これらの値は、フォアグラウンド アプリによって設定されます。 入力ファイルと出力ファイルの [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを作成し、コード変換に使うエンコード プロファイルを作成します。

入力ファイル、出力ファイル、エンコード プロファイルを渡して [**PrepareFileTranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700936) を呼び出します。 この呼び出しから返される [**PrepareTranscodeResult**](https://msdn.microsoft.com/library/windows/apps/hh700941) オブジェクトにより、コード変換を実行できるかどうかを把握できます。 [**CanTranscode**](https://msdn.microsoft.com/library/windows/apps/hh700942) プロパティが true の場合、[**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) を呼び出してコード変換操作を実行します。

**AsTask** メソッドを使うと、非同期操作の進行状況を追跡したり、取り消したりできます。 必要な進行状況の単位と、タスクの現在の進行状況について通知するために呼び出されるメソッドの名前を指定して、新しい **Progress** オブジェクトを作成します。 タスクの取り消しを可能にするキャンセル トークンと共に、**Progress** オブジェクトを **AsTask** メソッドに渡します。

[!code-cs[TranscodeFileAsync](./code/MediaProcessingTriggerWin10/cs/MediaProcessingBackgroundTask/MediaProcessingTask.cs#SnippetTranscodeFileAsync)]

前の手順で Progress オブジェクトを作成するために使ったメソッド **Progress** で、バックグラウンド タスク インスタンスの進行状況を設定します。 これにより、進行状況がフォアグラウンド アプリ (実行されている場合) に渡されます。

[!code-cs[進行状況](./code/MediaProcessingTriggerWin10/cs/MediaProcessingBackgroundTask/MediaProcessingTask.cs#SnippetProgress)]

**SendToastNotification** ヘルパー メソッドは、テキスト コンテンツしかないトーストのテンプレート XML ドキュメントを取得することによって新しいトースト通知を作成します。 トースト XML のテキスト要素が設定された後、XML ドキュメントから新しい [**ToastNotification**](https://msdn.microsoft.com/library/windows/apps/br208641) オブジェクトが作成されます。 最後に、[**ToastNotifier.Show**](https://msdn.microsoft.com/library/windows/apps/br208659) を呼び出すことによってトーストがユーザーに表示されます。

[!code-cs[SendToastNotification](./code/MediaProcessingTriggerWin10/cs/MediaProcessingBackgroundTask/MediaProcessingTask.cs#SnippetSendToastNotification)]

システムがバック グラウンド タスクをキャンセルしたときに呼び出される [**Canceled**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Background.IBackgroundTaskInstance.Canceled) イベントのハンドラーでは、利用統計情報を取集するためにログにエラーを記録することができます。

[!code-cs[OnCanceled](./code/MediaProcessingTriggerWin10/cs/MediaProcessingBackgroundTask/MediaProcessingTask.cs#SnippetOnCanceled)]

## バックグラウンド タスクの登録と起動

フォアグラウンド アプリからバックグラウンド タスクを起動するには、フォアグラウンド アプリの Package.appmanifest ファイルを更新して、アプリがバックグラウンド タスクを使っていることをシステムに認識させる必要があります。

1.  **ソリューション エクスプローラー**で、Package.appmanifest アイコンをダブルクリックしてマニフェスト エディターを開きます。
2.  **[宣言]** タブをクリックします。
3.  **[使用可能な宣言]** で、**[バックグラウンド タスク]** を選び、**[追加]** をクリックします。
4.  **[サポートされる宣言]** で、**[バックグラウンド タスク]** 項目が選択されていることを確認します。 **[プロパティ]** で、**[Media processing]** (メディア処理) チェック ボックスをオンにします。
5.  **[エントリ ポイント]** ボックスで、バックグラウンド テストの名前空間とクラス名を、ピリオドで区切って指定します。 この例では、エントリは次のとおりです。
   ```csharp
   MediaProcessingBackgroundTask.MediaProcessingTask
   ```
次に、フォアグラウンド アプリにバックグラウンド タスクへの参照を追加する必要があります。
1.  **ソリューション エクスプローラー**のフォアグラウンド アプリ プロジェクトで、**[参照]** フォルダーを右クリックし、**[参照の追加]** を選択します。
2.  **[プロジェクト]** ノードを展開し、**[ソリューション]** を選択します。
3.  バックグラウンド プロジェクトの横のボックスをオンにし、**[OK]** をクリックします。

この例のコードの残りの部分をフォアグラウンド アプリに追加する必要があります。 まず、次の名前空間をプロジェクトに追加する必要があります。

[!code-cs[ForegroundUsing](./code/MediaProcessingTriggerWin10/cs/MediaProcessingTriggerWin10/MainPage.xaml.cs#SnippetForegroundUsing)]

次に、バックグラウンド タスクの登録に必要な次のメンバー変数を追加します。

[!code-cs[ForegroundMembers](./code/MediaProcessingTriggerWin10/cs/MediaProcessingTriggerWin10/MainPage.xaml.cs#SnippetForegroundMembers)]

**PickFilesToTranscode** ヘルパー メソッドは、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) と [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使ってコード変換用の入力ファイルと出力ファイルを開きます。 アプリがアクセスできない場所にあるファイルをユーザーが選ぶ可能性があります。 バックグラウンド タスクがファイルを開けるようにするには、ファイルをアプリの [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) に追加します。

最後に、アプリの [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) で入力ファイルと出力ファイルの名前のエントリを設定します。 バックグラウンド タスクは、この場所からファイル名を取得します。

[!code-cs[PickFilesToTranscode](./code/MediaProcessingTriggerWin10/cs/MediaProcessingTriggerWin10/MainPage.xaml.cs#SnippetPickFilesToTranscode)]

バックグラウンド タスクを登録するには、新しい [**MediaProcessingTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806005) と新しい [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) を作成します。 後で識別できるようにバックグラウンド タスク ビルダーの名前を設定します。 [**TaskEntryPoint**](https://msdn.microsoft.com/library/windows/apps/br224774) を、マニフェスト ファイルで使ったのと同じ名前空間とクラス名文字列に設定します。 [**Trigger**](https://msdn.microsoft.com/library/windows/apps/dn641725) プロパティを **MediaProcessingTrigger** インスタンスに設定します。

タスクを登録する前に、[**AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) コレクションをループ処理し、[**BackgroundTaskBuilder.Name**](https://msdn.microsoft.com/library/windows/apps/br224771) プロパティで指定した名前を持つすべてのタスクで [**Unregister**](https://msdn.microsoft.com/library/windows/apps/br229870) を呼び出すことにより、以前に登録したタスクを必ず登録解除してください。

[**Register**](https://msdn.microsoft.com/library/windows/apps/br224772) を呼び出してバックグラウンド タスクを登録します。 [**Completed**](https://msdn.microsoft.com/library/windows/apps/br224788) イベントと [**Progress**](https://msdn.microsoft.com/library/windows/apps/br224808) イベントのハンドラーを登録します。

[!code-cs[RegisterBackgroundTask](./code/MediaProcessingTriggerWin10/cs/MediaProcessingTriggerWin10/MainPage.xaml.cs#SnippetRegisterBackgroundTask)]

**MediaProcessingTrigger** オブジェクトの [**RequestAsync**](https://msdn.microsoft.com/library/windows/apps/dn765071) メソッドを呼び出してバックグラウンド タスクを起動します。 このメソッドによって返される [**MediaProcessingTriggerResult**](https://msdn.microsoft.com/library/windows/apps/dn806007) オブジェクトにより、バックグラウンド タスクが正常に起動されたかどうかを把握することができます。正常に起動されなかった場合は、バックグラウンド タスクが起動しなかった理由を把握できます。

[!code-cs[LaunchBackgroundTask](./code/MediaProcessingTriggerWin10/cs/MediaProcessingTriggerWin10/MainPage.xaml.cs#SnippetLaunchBackgroundTask)]

バックグラウンド タスクが操作の進行状況を更新すると、**OnProgress** イベント ハンドラーが呼び出されます。 この機会を使って、進行状況情報によって UI を更新することができます。

[!code-cs[OnProgress](./code/MediaProcessingTriggerWin10/cs/MediaProcessingTriggerWin10/MainPage.xaml.cs#SnippetOnProgress)]

バックグラウンド タスクの実行が完了すると、**OnCompleted** イベント ハンドラーが呼び出されます。 ここでも、UI を更新してユーザーに状態情報を示すことができます。

[!code-cs[OnCompleted](./code/MediaProcessingTriggerWin10/cs/MediaProcessingTriggerWin10/MainPage.xaml.cs#SnippetOnCompleted)]


 

 







<!--HONumber=Nov16_HO1-->


