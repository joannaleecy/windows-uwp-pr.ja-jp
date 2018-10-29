---
author: TylerMSFT
title: Windows 10 UWP アプリのライフサイクル
description: このトピックでは、Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリのライフサイクル (アプリがアクティブ化されたときから、アプリが閉じられるまで) について説明します。
keywords: アプリのライフサイクル 中断 再開 起動 アクティブ化
ms.assetid: 6C469E77-F1E3-4859-A27B-C326F9616D10
ms.author: twhitney
ms.date: 01/23/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: cf8496393c5b500ab30d08608e90a0e156422ce3
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5759309"
---
# <a name="windows-10-universal-windows-platform-uwp-app-lifecycle"></a>Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリのライフサイクル


このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリのライフサイクル (アプリが起動されたときから、アプリが閉じられるまで) について説明します。

## <a name="a-little-history"></a>簡単な経緯

Windows 8 より前は、アプリのライフサイクルは単純でした。 Win32 アプリや .NET アプリは、実行されているか、実行されていないかのどちらかです。 ユーザーがアプリを最小化し、他のアプリに切り替えても、アプリは引き続き実行されています。 ポータブル デバイスが台頭し、電源管理がますます重要になるまでは、これで問題はありませんでした。

Windows 8 では、UWP アプリにより新しいアプリケーション モデルが導入されました。 大まかに言うと、新しい中断状態が追加されました。 UWP アプリは、ユーザーがアプリを最小化するか、別のアプリに切り替えた後、すぐに中断されます。 つまり、アプリのスレッドは停止し、オペレーティング システムがリソースを再利用する必要がある場合を除き、アプリはメモリ内に残ります。 ユーザーが元のアプリに切り替えると、アプリはすばやく実行中の状態に復元されます。

アプリがバックグラウンドにあるときに、アプリの実行を継続する必要がある場合、さまざまな方法があります。[バックグラウンド タスク](support-your-app-with-background-tasks.md)、[延長実行](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.aspx)、アクティビティ スポンサード実行 (たとえば、アプリが[バックグラウンドでのメディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)を続行できるようにする **BackgroundMediaEnabled** 機能) などです。 また、バックグラウンド転送操作は、アプリが中断または終了した場合でも続行できます。 詳しくは、「[ファイルのダウンロード方法](https://msdn.microsoft.com/library/windows/apps/xaml/jj152726.aspx#downloading_a_file_using_background_transfer)」をご覧ください。

既定では、フォアグラウンドにないアプリは中断され、その結果として、電力が節約され、現在フォアグラウンドにあるアプリが利用できるリソースが増加します。

中断状態では、オペレーティング システムはリソースを解放するためには中断中のアプリを終了することがあるため、開発者にとっては新しい要件が追加されます。 終了されたアプリは、引き続きタスク バーに表示されます。 ユーザーがこのアプリをクリックした場合、アプリは終了される前の状態を復元する必要があります。ユーザーは、システムがアプリを閉じたことを認識できないためです。 ユーザーは、他の作業を行っている間、アプリがバックグラウンドで待機していたと考え、他のアプリに切り替えたときと同じ状態であることを期待しています。 このトピックでは、これを実現する方法について取り上げます。

Windows 10 バージョン 1607 では、もう 2 つのアプリ モデルの状態が導入されています。**フォアグラウンドでの実行**と**バックグラウンドでの実行**です。 以下のセクションでこれらの新しい状態についても説明します。

## <a name="app-execution-state"></a>アプリの実行状態

次の図は、Windows 10、バージョン 1607 以降での、可能なアプリ モデルの状態を表しています。 UWP アプリの一般的なライフサイクルを順に見ていきましょう。

![アプリの実行状態が切り替わるようすを示す状態図](images/updated-lifecycle.png)

アプリは、起動またはアクティブ化されると、バックグラウンドでの実行状態になります。 アプリを取得し、アプリがフォアグラウンドで起動したためにフォアグラウンドに移動する必要がある場合、アプリは [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) イベントを取得します。

「起動」と「アクティブ化」の用語は似ているように見えますが、オペレーティング システムがアプリを起動する際の異なる方法を示しています。 まず、アプリの起動を見てみましょう。

## <a name="app-launch"></a>アプリの起動

アプリが起動されると、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドが呼び出されます。 このメソッドに [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) パラメーターが渡されます。このパラメーターは、特に、アプリに渡された引数、アプリを起動したタイルの識別子、アプリの以前の状態を提供します。

アプリの以前の状態は、[ApplicationExecutionState](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.activation.applicationexecutionstate.aspx) を返す [LaunchActivatedEventArgs.PreviousExecutionState](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.activation.launchactivatedeventargs.previousexecutionstate) から取得します。 その値とその状態に対する適切なアクションは次のとおりです。

| ApplicationExecutionState | 説明 | 実行するアクション |
|-------|-------------|----------------|
| **NotRunning** | アプリがこの状態になるのは、ユーザーが前回再起動するか、ログインしてから、アプリが起動されていないためである可能性があります。 また、アプリが実行中であったがクラッシュした場合や、ユーザーが以前にアプリを閉じたために、この状態になっている可能性もあります。| 現在のユーザー セッションで初めて実行する場合と同様に、アプリを初期化します。 |
|**Suspended** | ユーザーがアプリを最小化したか、アプリを切り替えてから、数秒以内にそのアプリに戻っていません。 | アプリが中断されると、アプリの状態はメモリ内に保持されます。 必要な処理は、アプリが中断されたときに解放したファイル ハンドルやその他のリソースを再取得することだけです。 |
| **Terminated** | アプリは、以前に中断されましたが、システムがメモリを再利用する必要があったため、ある時点でシャットダウンされました。 | ユーザーがアプリを切り替えたときのアプリの状態を復元します。|
|**ClosedByUser** | ユーザーは、タブレット モードでの閉じるジェスチャや、Alt キーを押しながら F4 キーを押すことによって、アプリを終了しました。 ユーザーがアプリを閉じた場合、アプリはまず中断され、次に終了します。 | アプリは基本的に Terminated 状態に至る手順と同じ手順に従うため、Terminated 状態と同じ方法でこれを処理します。|
|**Running** | ユーザーがアプリを起動しようとしたときに、アプリは既に開いていました。 | なし。 アプリの別のインスタンスが起動されないことに注意してください。 既に実行中のインスタンスが、単にアクティブ化されます。 |

**注:***現在のユーザー セッション*は、Windows ログオンに基づいています。 現在のユーザーがログオフ、Windows のシャットダウンや再起動を行っていない限り、現在のユーザー セッションは、ロック画面認証やユーザーの切り替えなどのイベント間で保持されます。 

注意すべき重要な状況が 1 つあります。デバイスに十分なリソースがある場合、応答性の最適化のために事前起動がオプトインされている、使用頻度の高いアプリをオペレーティング システムが事前起動することです。 事前起動されたアプリは、バックグラウンドで起動され、すぐに中断されます。これにより、ユーザーがこれらのアプリに切り替えたときに、アプリを起動するよりも高速に再開することができます。

事前起動のために、アプリの **OnLaunched()** メソッドは、ユーザーではなく、システムによって開始される可能性があります。 アプリはバックグラウンドで事前起動されるため、**OnLaunched()** で異なるアクションが必要になる可能性があります。 たとえば、アプリが起動時に音楽の再生を開始する場合、アプリはバックグラウンドで事前起動されるため、どこから音楽が再生されているのかわかりません。 アプリがバックグラウンドで事前起動されたら、続けて **Application.Suspending** を呼び出します。 その後、ユーザーがアプリを起動したときに、**OnLaunched()** メソッドと共に再開イベントが呼び出されます。 事前起動のシナリオを処理する方法について詳しくは、「[アプリの事前起動の処理](handle-app-prelaunch.md)」をご覧ください。 オプトインしているアプリだけが事前起動されます。

Windows によって、アプリの起動時に、アプリのスプラッシュ画面が表示されます。 スプラッシュ画面を構成するには、「[スプラッシュ画面の追加](https://msdn.microsoft.com/library/windows/apps/xaml/hh465331)」をご覧ください。

スプラッシュ画面が表示されているときに、アプリはイベント ハンドラーを登録し、最初のページに必要なカスタム UI を設定する必要があります。 アプリのコンストラクターや **OnLaunched()** で実行されるこれらのタスクが数秒以内に完了することを確認します。数秒以内に完了しない場合、システムはアプリが応答していないと判断し、アプリを終了する可能性があります。 アプリがネットワーク経由でデータを要求したり、ディスクから大量のデータを取得したりする必要がある場合、こうしたアクティビティは起動とは別に実行してください。 実行に時間がかかる操作が完了するまでの間、アプリでは、アプリ独自のカスタム読み込み UI や追加のスプラッシュ画面を使うことができます。 詳しくは、「[スプラッシュ画面の表示時間の延長](create-a-customized-splash-screen.md)」や「[スプラッシュ画面のサンプル](http://go.microsoft.com/fwlink/p/?linkid=234889)」をご覧ください。

アプリの起動が完了すると、アプリが **Running** 状態になり、スプラッシュ画面は消えて、スプラッシュ画面のすべてのリソースとオブジェクトは消去されます。

## <a name="app-activation"></a>アプリのアクティブ化

ユーザーによる起動とは対照的には、システムによってアプリをアクティブ化できます。 アプリは、共有コントラクトなどのコントラクトによってアクティブ化される可能性があります。 また、カスタム URI プロトコルや、アプリが処理するように登録されている拡張子を持つファイルを処理するためにアクティブ化される可能性があります。 アプリをアクティブ化する方法の一覧については、「[**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693)」をご覧ください。

[**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) クラスで定義されているメソッドをオーバーライドして、アプリをアクティブ化するさまざまな方法に対応することができます。
[**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) は、発生する可能性があるすべてのアクティブ化の種類を処理できます。 ただし、最も一般的なアクティブ化の種類を処理する場合は特定のメソッドを使い、あまり一般的ではないアクティブ化の種類を処理する際の代替手段としてのみ **OnActivated** を使うことが多くあります。 特定のアクティブ化については、次のような追加のメソッドがあります。

[**OnCachedFileUpdaterActivated**](https://msdn.microsoft.com/library/windows/apps/hh701797)  
[**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331)  
[**OnFileOpenPickerActivated**](https://msdn.microsoft.com/library/windows/apps/hh701799)  [**OnFileSavePickerActivated**](https://msdn.microsoft.com/library/windows/apps/hh701801)  
[**OnSearchActivated**](https://msdn.microsoft.com/library/windows/apps/br242336)  
[**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/hh701806)

これらのメソッドのイベント データには、既に説明した同じ [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) プロパティが含まれており、アプリがアクティブ化される前の状態を確認することができます。 前の「[アプリの起動](#app-launch)」セクションで説明した方法と同じ方法で、状態と対処を解釈します。

**注:** 場合は、コンピューターの管理者アカウントを使用してログオンには、UWP アプリをアクティブ化することはできません。

## <a name="running-in-the-background"></a>バックグラウンドでの実行 ##

Windows 10 バージョン 1607 以降では、アプリは、アプリ自体と同じプロセスでバックグラウンド タスクを実行できます。 詳しくは、[シングル プロセス モデルでのバックグラウンド アクティビティに関する記事](https://blogs.windows.com/buildingapps/2016/06/07/background-activity-with-the-single-process-model/#tMmI7wUuYu5CEeRm.99)をご覧ください。 インプロセスのバックグラウンド処理については、この記事では詳しく説明しませんが、アプリのライフサイクルへの影響として、アプリをバックグラウンドで実行する場合に関連する 2 つの新しいイベントが追加されています。 [**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) と [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) です。

これらのイベントは、アプリの UI を表示するかどうかも反映します。

バックグラウンドでの実行は、アプリが起動、アクティブ化、再開されたときの既定の状態です。 この状態では、アプリの UI はまだ表示されません。

## <a name="running-in-the-foreground"></a>フォアグラウンドでの実行 ##

フォアグラウンドでの実行は、アプリの UI が表示されていることを意味します。

**LeavingBackground** イベントは、アプリの UI が表示される直前で、フォアグラウンドでの実行状態になる前に発生します。 また、ユーザーが元のアプリに切り替えるときにも発生します。

以前は、UI のアセットを読み込むのに最適な場所が、**Activated** または **Resuming** イベント ハンドラーでした。 現在は、**LeavingBackground** が UI の準備ができていることを確認するのに最適な場所です。

この時点でビジュアル アセットの準備が完了していることを確認すること重要です。これが、ユーザーに対してアプリが表示される前に処理を実行する最後の機会であるためです。 このイベント ハンドラー内でのすべての UI 処理は、迅速に完了する必要があります。これは、ユーザーが経験する起動時間や再開時間に影響を与えるためです。 **LeavingBackground** は、UI の最初のフレームの準備ができていることを確認するタイミングです。 その後、このイベント ハンドラーが制御を戻すことができるように、長時間にわたるストレージやネットワークの呼び出し処理を非同期的に処理する必要があります。

ユーザーが他のアプリに切り替えると、元のアプリは再びバックグラウンドでの実行状態に戻ります。

## <a name="reentering-the-background-state"></a>バックグラウンド状態に戻る

**EnteredBackground**イベントは、アプリがフォアグラウンドに表示されなくなったことを示します。 デスクトップでは、**EnteredBackground** はアプリが最小化されたときに発生します。電話では、ホーム画面や別のアプリに切り替えたときに発生します。

### <a name="reduce-your-apps-memory-usage"></a>アプリのメモリ使用量を減らす

アプリがユーザーに表示されなくなったため、これは UI のレンダリング処理とアニメーションを停止するのに最適な場所です。 **LeavingBackground** を使って、もう一度その作業を開始できます。

バックグラウンドで処理を実行する場合、ここで処理を準備することができます。 [MemoryManager.AppMemoryUsageLevel](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.appmemoryusagelevel.aspx) を確認し、必要に応じてバックグラウンドでの実行時のアプリのメモリ使用量を減らすことにより、システムがリソースを解放するためにアプリを終了するリスクを下げることをお勧めします。

詳しくは、[アプリがバックグラウンドの状態に移行したときにメモリ使用量を減らす方法に関する記事](reduce-memory-usage.md)をご覧ください。

### <a name="save-your-state"></a>状態を保存する

中断イベント ハンドラーは、アプリの状態を保存するのに最適な場所です。 しかし、バックグラウンドでの処理を行う場合 (オーディオの再生、延長実行セッションの使用、インプロセス バックグラウンド タスクなど) は、**EnteredBackground** イベント ハンドラーから非同期的にデータを保存することもお勧めします。 これは、アプリがバックグラウンドにある間に優先順位が低く、アプリが終了される可能性があるためです。 また、その場合、アプリは中断状態を経ないため、データは失われます。

バックグラウンド アクティビティが開始される前に、**EnteredBackground** イベント ハンドラーでデータを保存することにより、ユーザーがアプリをフォアグラウンドに戻したときに、優れたユーザー エクスペリエンスを提供できます。 アプリケーション データ API を使用して、データと設定を保存することができます。 詳しくは、「[設定と他のアプリ データを保存して取得する](https://msdn.microsoft.com/library/windows/apps/mt299098)」をご覧ください。

データを保存した後、メモリ使用量の上限を超えている場合、後で再読み込みできるため、メモリからデータを解放できます。 これによりメモリが解放され、バックグラウンド アクティビティに必要なアセットで使用できます。

アプリのバックグラウンド アクティビティで進行中である場合、中断状態を経ずに、バックグラウンドでの実行状態からフォアグラウンドでの実行状態に移行できることに注意してください。

### <a name="asynchronous-work-and-deferrals"></a>非同期処理と保留

ハンドラー内で非同期呼び出しを行う場合、制御はその非同期呼び出しからすぐに戻ります。 つまり、非同期呼び出しがまだ完了していない場合でも、イベント ハンドラーから制御が戻り、アプリを次の状態に移行できます。 イベント ハンドラーに渡される [**EnteredBackgroundEventArgs**](http://aka.ms/Ag2yh4) オブジェクトの [**GetDeferral**](http://aka.ms/Kt66iv) メソッドを使用して、[**Windows.Foundation.Deferral**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.aspx) オブジェクトの [**Complete**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.complete.aspx) メソッドを呼び出した後まで中断を延期することができます。

遅延では、アプリが終了する前に、実行する必要があるコードの量を増やす必要はありません。 遅延の *Complete* メソッドが呼び出されるか、または期限になるか、*どちらか早い方*まで、終了が延期されるだけです。

状態を保存するためにより多くの時間が必要な場合は、アプリがバックグラウンドの状態になる前に、段階的に状態を保存し、**EnteredBackground** イベント ハンドラーで保存する状態の情報を少なくする方法を調べます。 または、[ExtendedExecutionSession](https://msdn.microsoft.com/magazine/mt590969.aspx) を呼び出して、より多くの時間を取得します。 ただし、要求が許可される保証はないため、状態を保存するために必要な時間を最小限に抑える方法を見つけることをお勧めします。

## <a name="app-suspend"></a>アプリの中断

ユーザーがアプリを最小化したとき、Windows は、ユーザーが再び元のアプリに切り替えるかどうかを確認するために数秒待機します。 ユーザーがこの時間内に再び元のアプリに切り替えることがなく、延長実行、バックグラウンド タスク、アクティビティ スポンサード実行がどれもアクティブではない場合、Windows はアプリを中断します。 アプリは、延長実行セッションなどがそのアプリでアクティブではない限り、ロック画面が表示されているときにも中断されます。

アプリは、中断されると、[**Application.Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントを呼び出します。 Visual Studio の UWP プロジェクト テンプレートでは、**App.xaml.cs** に **OnSuspending** と呼ばれるこのイベントのハンドラーが用意されています。 Windows 10 バージョン 1607 より前のバージョンでは、状態を保存するコードをここに記述していました。 現在は、前述のように、バックグラウンド状態に移行するときにアプリの状態を保存することをお勧めします。

また、排他リソースとファイル ハンドルを、自分のアプリが中断されているときに他のアプリがアクセスできるように解放することをお勧めします。 排他リソースには、カメラ、I/O デバイス、外部デバイス、ネットワーク リソースなどがあります。 排他リソースとファイル ハンドルを明示的に解放すると、自分のアプリが中断されているときに他のアプリが排他リソースとファイル ハンドルにアクセスできるようになります。 アプリが再開されるときに、排他リソースとファイル ハンドルを再取得する必要があります。

### <a name="be-aware-of-the-deadline"></a>期限に注意する

高速で応答性の高いデバイスを実現するために、中断イベント ハンドラーでコードを実行する時間には制限があります。 この制限はデバイスごとに異なり、[**SuspendingOperation**](https://msdn.microsoft.com/library/windows/apps/br224688) オブジェクトの Deadline と呼ばれるプロパティを使って制限を確認できます。

**EnteredBackground** イベント ハンドラーと同様に、ハンドラーから非同期呼び出しを行う場合、制御はその非同期呼び出しからすぐに戻ります。 つまり、非同期呼び出しがまだ完了していない場合でも、イベント ハンドラーから制御が戻り、アプリを中断状態に移行できます。 返された [**SuspendingDeferral**](https://msdn.microsoft.com/library/windows/apps/br224684) オブジェクトに [**Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) メソッドを呼び出すまで中断状態への移行を遅らせるには、[**SuspendingOperation**](https://msdn.microsoft.com/library/windows/apps/br224688) オブジェクト (イベント引数経由で利用可能) に対して [**GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) メソッドを使います。

さらに多くの時間が必要な場合は、[ExtendedExecutionSession](https://msdn.microsoft.com/magazine/mt590969.aspx) を要求することができます。 ただし、要求が許可される保証はないため、**Suspended** イベント ハンドラーで必要な時間を最小限に抑える方法を見つけることをお勧めします。

### <a name="app-terminate"></a>アプリの終了

システムは、アプリの中断中に、アプリとそのデータをメモリに保持するよう試みます。 ただし、アプリをメモリに保持するためのリソースがシステムにない場合、システムはアプリを終了します。 アプリは終了通知を受け取らないため、アプリのデータを保存するには、**OnSuspension** イベント ハンドラーで行うか、**EnteredBackground** ハンドラーで非同期的に行う必要があります。

終了されたアプリをアクティブ化するとき、アプリが終了する前と同じ状態になるように、保存したアプリのデータを読み込む必要があります。 中断されてから終了されたアプリにユーザーが戻るとき、アプリは [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドでアプリケーション データを復元する必要があります。 アプリが終了されるときは、システムはアプリに通知を送らないので、アプリは中断される前にアプリケーション データを保存し、排他リソースとファイル ハンドルを解放して、アプリが終了後アクティブ化されるときにそれらを復元する必要があります。

**Visual Studio によるデバッグに関する注意事項:** Visual Studio は、Visual Studio デバッガーにアタッチされているアプリを Windows が中断するのを防ぎます。 これは、アプリが実行されている間、ユーザーが Visual Studio デバッグの UI を確認できるようにするためです。 アプリのデバッグ中は、Visual Studio を使ってそのアプリに中断イベントを送信できます。 **[デバッグの場所]** ツール バーが表示されていることを確認し、**[中断]** アイコンをクリックします。

## <a name="app-resume"></a>アプリの再開

中断中のアプリは、ユーザーがそのアプリに切り替えた場合、またはデバイスが低電力状態から復帰してアクティブなアプリになった場合に再開されます。

**Suspended** 状態からアプリを再開するとき、アプリは**バックグラウンドでの実行**状態に移行し、システムはアプリを中断前の状態に復元するので、ユーザーからはアプリがバックグラウンドでずっと実行されていたように見えます。 メモリに格納されているアプリのデータは失われません。 したがって、アプリは中断されたときに解放したファイル ハンドルやデバイス ハンドルを再取得し、中断されたときに明示的に解放された状態を復元する必要はありますが、ほとんどのアプリでは再開時に状態を復元する必要はありません。

アプリは、数時間から数日間中断される場合があります。 そのため、アプリのコンテンツやネットワーク接続が無効になっていると考えられる場合は、アプリの再開時にコンテンツやネットワーク接続を更新する必要があります。 アプリに [**Application.Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントのイベント ハンドラーが登録されている場合は、アプリが **Suspended** 状態から再開されるとこのイベント ハンドラーが呼び出されます。 このイベント ハンドラーでアプリのコンテンツやデータを更新できます。

中断中のアプリがアクティブ化されてアプリ コントラクトまたは拡張機能に参加する場合は、まず **Resuming** イベントを受け取り、次に **Activated** イベントを受け取ります。

中断中のアプリが終了されていた場合、**Resuming** イベントはなく、代わりに **Terminated** の **ApplicationExecutionState** を使って **OnLaunched()** が呼び出されます。 アプリが中断されたときに状態を保存しているため、ユーザーからはそのアプリから他に切り替えたときと同じに見えるように、**OnLaunched()** でその状態を復元できます。

アプリは、中断されている間、受信登録したネットワーク イベントを受け取りません。 これらのネットワーク イベントはキューに入れられず、受け取ることができません。 そのため、再開時にアプリでネットワーク ステータスをテストする必要があります。

**注:**、再開ハンドラーのコードは、UI と通信する場合は、 [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339)イベントがないに発生するため、UI スレッドからディスパッチャーを使う必要があります。 これを行う方法のコード例については、[バックグラウンド スレッドからの UI スレッドの更新に関するページ](https://github.com/Microsoft/Windows-task-snippets/blob/master/tasks/UI-thread-access-from-background-thread.md)をご覧ください。

一般的なガイドラインについては、[アプリの中断と再開のガイドラインに関するページ](https://msdn.microsoft.com/library/windows/apps/hh465088)をご覧ください。

## <a name="app-close"></a>アプリを閉じる

一般に、アプリを閉じる処理はユーザーが行う必要はなく、Windows で管理されます。 ただし、ユーザーはジェスチャを使うか、Alt + F4 キーを押すか、Windows Phone でタスク スイッチャーを使って、アプリを閉じることができます。

ユーザーがアプリを閉じたことを示すイベントはありません。 アプリがユーザーによって閉じられたとき、その状態を保存する機会を提供するために、アプリはまず中断されます。 Windows8.1 以降では、アプリは、ユーザーによって閉じられると、アプリが画面から削除されると切り替えリストが明示的に終了します。

**ユーザーによって閉じられた動作:** アプリは、Windows によって閉じられたよりも、ユーザーが閉じたときに、異なる処理を実行する必要がある場合、アプリのユーザーによって、または Windows によって終了されたかどうかを判断する、アクティブ化イベント ハンドラーを使用することができます。 [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) 列挙体に関するリファレンスの **ClosedByUser** 状態と **Terminated** 状態の説明をご覧ください。

必要でない限り、アプリをプログラムで閉じないことをお勧めします。 たとえば、メモリ リークが検出された場合などは、ユーザーの個人データのセキュリティを確保するためにアプリ自体で閉じてもかまいません。

## <a name="app-crash"></a>アプリのクラッシュ

システム クラッシュのエクスペリエンスは、ユーザーがそれまで行っていた作業にできるだけ迅速に戻れるようにすることを目的としています。 ユーザーを待たせることがないように、警告ダイアログなどによる通知は行わないでください。

アプリがクラッシュしたり、応答しなくなったり、例外が生成されたりすると、ユーザーの [フィードバックと診断の設定](http://go.microsoft.com/fwlink/p/?LinkID=614828) に従って、マイクロソフトに問題レポートが送られます。 Microsoft は、アプリの改善に役立つように、問題レポートに含まれるエラー データの一部を提供しています。 このデータは、ダッシュボードに表示されるアプリの [品質] ページで確認できます。

アプリがクラッシュした後にユーザーがアプリをアクティブ化すると、アクティブ化イベント ハンドラーは [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) の値として **NotRunning** を受け取り、アプリの最初の UI とデータを表示します。 クラッシュの後、**Suspended** に基づく **Resuming** で使ったアプリ データはそのまま使わないでください。これは、そのデータが破損している可能性があるためです。「[アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)」をご覧ください。

## <a name="app-removal"></a>アプリの削除

ユーザーがアプリを削除すると、アプリはすべてのローカル データと共に削除されます。 アプリの削除は、一般的な場所 (ドキュメント ライブラリやピクチャ ライブラリ内など) に格納されているユーザーのデータには影響しません。

## <a name="app-lifecycle-and-the-visual-studio-project-templates"></a>アプリのライフサイクルと Visual Studio のプロジェクト テンプレート

アプリのライフサイクルに関連する基本的なコードは、Visual Studio のプロジェクト テンプレートに用意されています。 基本的なアプリでは、起動アクティブ化を処理し、アプリ データを復元するための場所を提供して、独自のコードを追加する前であってもプライマリ UI を表示します。 詳しくは、「[アプリ用の C#、VB、C++ プロジェクト テンプレート](https://msdn.microsoft.com/library/windows/apps/hh768232)」をご覧ください。

## <a name="key-application-lifecycle-apis"></a>主要なアプリケーション ライフサイクル API

-   [**Windows.ApplicationModel**](https://msdn.microsoft.com/library/windows/apps/br224691) 名前空間
-   [**Windows.ApplicationModel.Activation**](https://msdn.microsoft.com/library/windows/apps/br224766) 名前空間
-   [**Windows.ApplicationModel.Core**](https://msdn.microsoft.com/library/windows/apps/br205865) 名前空間
-   [**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) クラス (XAML)
-   [**Windows.UI.Xaml.Window**](https://msdn.microsoft.com/library/windows/apps/br209041) クラス (XAML)

## <a name="related-topics"></a>関連トピック

* [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694)
* [アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [アプリの事前起動の処理](handle-app-prelaunch.md)
* [アプリのアクティブ化の処理](activate-an-app.md)
* [アプリの中断の処理](suspend-an-app.md)
* [アプリの再開の処理](resume-an-app.md)
* [シングル プロセス モデルでのバックグラウンド アクティビティ](https://blogs.windows.com/buildingapps/2016/06/07/background-activity-with-the-single-process-model/#tMmI7wUuYu5CEeRm.99)
* [バックグラウンドでのメディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)

 

 
