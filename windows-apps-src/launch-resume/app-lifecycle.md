---
author: TylerMSFT
title: "アプリのライフサイクル"
description: "このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリのライフサイクル (アプリがアクティブ化されたときから、アプリが閉じられるまで) について説明します。"
ms.assetid: 6C469E77-F1E3-4859-A27B-C326F9616D10
ms.sourcegitcommit: 213384a194513a0f98a5f37e7f0e0849bf0a66e2
ms.openlocfilehash: 8451942c05d5d44cafba243f7cbebceedbe86fc0

---

# アプリのライフサイクル


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**Windows.UI.Xaml.Application クラス**](https://msdn.microsoft.com/library/windows/apps/br242324)
-   [**Windows.ApplicationModel.Activation 名前空間**](https://msdn.microsoft.com/library/windows/apps/br224766)

このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリのライフサイクル (アプリがアクティブ化されたときから、アプリが閉じられるまで) について説明します。 多くのユーザーは複数のデバイスやアプリを使って作業や操作を行います。 ユーザーは、デバイスでマルチタスクを実行しているとき、アプリがその状態を記憶していることを望んでいます。 たとえば、中断したときと同じ位置までページがスクロールし、すべてのコントロールが中断前と同じ状態になっていることが求められています。 起動、中断、再開というアプリのライフサイクルを理解することによって、このようなシームレスな動作を提供できます。

## アプリの実行状態


次の図は、アプリの実行状態が切り替わるようすを示したものです。 このページの以降のセクションで、これらの状態とイベントについて説明します。 各状態に切り替わる状況とその際のアプリの処理について詳しくは、[**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) 列挙体に関するリファレンスをご覧ください。

![アプリの実行状態が切り替わるようすを示す状態図](images/state-diagram.png)

## 展開


アプリをアクティブ化するには、まずアプリを展開する必要があります。 アプリが展開されるのは、ユーザーがアプリをインストールするとき、または開発時やテスト時に Visual Studio を使ってアプリをビルドして実行するときです。 基本的な展開や高度な展開のシナリオについて詳しくは、「[アプリ パッケージと展開](https://msdn.microsoft.com/library/windows/apps/hh464929)」をご覧ください。

## アプリの起動


アプリは、**NotRunning** 状態であるときに、ユーザーがスタート画面またはアプリケーション リストでアプリのタイルをタップすると起動します。 使用頻度の高いアプリは事前起動して応答性を最適化することもできます (「[アプリの事前起動の処理](handle-app-prelaunch.md)」を参照)。 アプリが **NotRunning** 状態である理由としては、アプリがまだ起動されていないこと、アプリが実行中にクラッシュしたこと、またはアプリは中断されたがメモリに残すことができずにシステムによって終了されたことなどが考えられます。 起動はアクティブ化とは異なります。 アクティブ化は、アプリが検索コントラクトなどのコントラクトまたは拡張機能によってアクティブになることです。

アプリが起動されたときには、アプリが現在メモリ内で中断されているときを含め、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドが呼び出されます。 [
            **LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) パラメーターには、アプリの以前の状態とアクティブ化引数が含まれています。

ユーザーが終了したアプリに切り替えると、システムは [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) 引数を送信します。このとき、[**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) は **Launch** に設定され、[**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) は **Terminated** または **ClosedByUser** に設定されます。 アプリでは、保存されているアプリ データを読み込み、表示されているコンテンツを更新する必要があります。

[
            **PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) の値が **NotRunning** である場合は、初めて起動するときのように最初からアプリをやり直す必要があります。

アプリの起動時には、アプリのスプラッシュ画面が表示されます。 スプラッシュ画面を構成するには、「[スプラッシュ画面の追加](https://msdn.microsoft.com/library/windows/apps/xaml/hh465331)」をご覧ください。

スプラッシュ画面の表示中に、アプリはユーザー インターフェイスを準備する必要があります。 アプリの主なタスクに、イベント ハンドラーを登録して、初期ページの読み込みに必要なカスタム UI を設定するタスクがあります。 これらのタスクは数秒で完了する必要があります。 ネットワーク経由でデータを要求したり、ディスクから大量のデータを取得したりする必要がある場合、こうしたアクティビティはアクティブ化とは別に実行してください。 このような実行に時間がかかる操作が完了するまでの間、アプリでは、アプリ独自のカスタム読み込み UI や追加のスプラッシュ画面を使うことができます。 詳しくは、「[スプラッシュ画面の表示時間の延長](create-a-customized-splash-screen.md)」や「[スプラッシュ画面のサンプル](http://go.microsoft.com/fwlink/p/?linkid=234889)」をご覧ください。 アプリのアクティブ化が完了すると、アプリが **Running** 状態になり、スプラッシュ画面は消えます (スプラッシュ画面のすべてのリソースとオブジェクトは消去されます)。

## アプリのアクティブ化


アプリは、さまざまな拡張機能や、共有コントラクトなどのコントラクトによってアクティブ化されます。 アプリをアクティブ化する方法の一覧については、「[**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693)」をご覧ください。

[
            **Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) クラスで定義されているメソッドを上書きして、さまざまなアクティブ化の種類に対応することができます。 一部のアクティブ化の種類には、[**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331)、[**OnSearchActivated**](https://msdn.microsoft.com/library/windows/apps/br242336) など、上書きできる専用のメソッドがあります。それ以外のアクティブ化の種類では、[**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) メソッドをオーバーライドします。

アプリのアクティブ化コードを使うと、アクティブ化された理由を確認したり、既に **Running** 状態になっているかどうかを確認したりすることができます。

オペレーティング システムがアプリを終了させた後でユーザーが再びアプリを起動した場合は、アクティブ化するときに、保存されていたデータを復元することができます。 Windows では、アプリの中断後、さまざまな理由でアプリを終了することがあります。 たとえば、ユーザーが手動でアプリを閉じたときやサインアウトしたとき、システムのリソースが足りないときなどです。 Windows がアプリを終了させた後でユーザーがアプリを起動した場合、アプリは [**Application.OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) コールバックを受け取ります。ユーザーには、アプリがアクティブ化されるまで、アプリのスプラッシュ画面が表示されます。 このイベントを使って、前回中断されたときに保存されていたデータを復元する必要があるかどうか、アプリの既定のデータを読み込む必要があるかどうかを判断できます。 スプラッシュ画面が表示されているため、アプリのコードでは、ユーザーが気になるような遅延を発生させずに、ある程度の処理時間を費やしてこのイベントの処理を実行できます。ただし、アプリの再起動や継続を行うときには、前に説明した実行に時間がかかる操作に関する対応方法も考慮してください。

[
            **OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) イベント データには [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) プロパティが含まれており、アプリがアクティブ化される前の状態を確認することができます。 このプロパティの値は、[**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) 列挙体のいずれかの値になります。

| 終了した理由                                                        | [
            **PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) プロパティの値 | 実行する処理          |
|-------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------|-------------------------|
| システムによる終了 (リソースの制約などによる)       | **Terminated**                                                                                          | セッション データを復元する    |
| ユーザーによる終了 (ユーザーによるプロセスの終了)                             | **ClosedByUser**                                                                                        | 既定のデータで起動する |
| 予期しない終了 (*現在のユーザー セッション*の間にアプリが実行されていない) | **NotRunning**                                                                                          | 既定のデータで起動する |

 

**注**
            *現在のユーザー セッション*は、Windows ログオンに基づきます。 現在のユーザーが明示的にログオフやシャットダウンを行っていない、または他の理由で Windows が再起動していない限り、現在のユーザー セッションは、ロック画面認証やユーザーの切り替えなどのイベント間で保持されます。

 

[
              **PreviousExecutionState**
            ](https://msdn.microsoft.com/library/windows/apps/br224729) の値が **Running** または **Suspended** になる場合もありますが、その場合、アプリは終了されておらず、データはすべてメモリ内にあるため、データを復元する必要はありません。

**注**  

コンピューターの管理者アカウントを使ってログオンしている場合は、UWP アプリをアクティブ化できません。

詳しくは、「[アプリの拡張機能](https://msdn.microsoft.com/library/windows/apps/hh464906)」をご覧ください。

### **OnActivated** と特定のアクティブ化との比較

[
            **OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) メソッドは、発生する可能性があるすべてのアクティブ化の種類を処理するための方法となります。 ただし、最も一般的なアクティブ化の種類を処理する場合は別のメソッドを使い、あまり一般的ではないアクティブ化の種類を処理する際の代替手段としてのみ **OnActivated** を使うことが多くあります。 たとえば、[**Application**](https://msdn.microsoft.com/library/windows/apps/br242324) には、[**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693) が **Launch** である場合にコールバックとして呼び出される [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドがあります。このメソッドが、ほとんどのアプリで使われる一般的なアクティブ化の方法です。 特定のアクティブ化については、さらに 6 つの **On\*** メソッドがあります。それらは、[**OnCachedFileUpdaterActivated**](https://msdn.microsoft.com/library/windows/apps/hh701797)、[**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331)、[**OnFileOpenPickerActivated**](https://msdn.microsoft.com/library/windows/apps/hh701799)、[**OnFileSavePickerActivated**](https://msdn.microsoft.com/library/windows/apps/hh701801)、[**OnSearchActivated**](https://msdn.microsoft.com/library/windows/apps/br242336)、[**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/hh701806) です。 XAML アプリの開始テンプレートは、**OnLaunched** の実装と [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) のハンドラーを備えています。

## アプリの中断


ユーザーが別のアプリや、デスクトップまたはスタート画面に切り替えると、システムはアプリを中断します。 デバイスが低電力状態になったときに、アプリが中断される場合もあります。 ユーザーが元のアプリに戻すと、システムはアプリを再開します。 システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。 システムはアプリを厳密に中断前の状態に復元するので、ユーザーからはアプリがバックグラウンドで実行していたように見えます。

ユーザーがアプリをバックグラウンドに移行すると、Windows は、ユーザーがすぐにこのアプリに戻るかどうかを確かめるために数秒待機します。これにより、元のアプリに戻る場合、切り替えはすばやく行われます。 この時間枠内にアプリに戻らなかった場合、アプリは中断されます。

アプリの中断が進められているときに非同期作業が必要になった場合には、その作業が完了するまで中断の完了を遅らせる必要があります。 返された [**SuspendingDeferral**](https://msdn.microsoft.com/library/windows/apps/br224684) オブジェクトに [**Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) メソッドを呼び出すまで中断の完了を遅らせるには、[**SuspendingOperation**](https://msdn.microsoft.com/library/windows/apps/br224688) オブジェクト (イベント引数経由で利用可能) に対して [**GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) メソッドを使います。

システムは、アプリの一時停止中、アプリとそのデータをメモリに保持するよう試みます。 ただし、アプリをメモリに保持するためのリソースがシステムにない場合、システムはアプリを終了します。 アプリは終了通知を受け取らないため、アプリが中断されるタイミングがアプリのデータを保存する唯一のチャンスとなります。 終了後にアプリをアクティブ化するとき、アプリが中断する前と同じ状態になるように、中断時に保存したアプリのデータがアプリに読み込まれます。 中断されてから終了されたアプリにユーザーが戻るとき、アプリは [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドでアプリケーション データを復元する必要があります。 アプリが終了されるときは、システムはアプリに通知を送らないので、アプリは中断されたときにアプリケーション データを保存し、排他リソースとファイル ハンドルを解放して、アプリが終了後アクティブ化されるときにそれらを復元する必要があります。

アプリに [**Application.Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントのイベント ハンドラーが登録されている場合は、アプリが中断される直前にこのイベント ハンドラーが呼び出されます。 このイベント ハンドラーを使って、アプリ データとユーザー データを保存できます。 この場合は、アプリ データ API を使うことをお勧めします。アプリ データ API は、アプリが **Suspended** 状態になる前に必ず完了するためです。 詳しくは、「[設定と他のアプリ データを保存して取得する](https://msdn.microsoft.com/library/windows/apps/mt299098)」をご覧ください。

また、排他リソースとファイル ハンドルを、自分のアプリが使っていないときに他のアプリがアクセスできるように解放することをお勧めします。 排他リソースには、カメラ、I/O デバイス、外部デバイス、ネットワーク リソースなどがあります。 排他リソースとファイル ハンドルを明示的に解放すると、自分のアプリが使っていないときに他のアプリが排他リソースとファイル ハンドルにアクセスできるようになります。 アプリが終了後にアクティブ化されるときに、排他リソースとファイル ハンドルを再び開く必要があります。

一般に、アプリは中断イベントを処理するとすぐに、その状態を保存し、リソースとファイル ハンドルを解放します。コードでは、この処理を 1 秒以内で完了させる必要があります。 アプリが中断イベントから数秒以内に復帰しなかった場合、Windows はアプリが応答を停止したと判断してアプリを終了します。

アプリのシナリオによっては、バックグラウンド タスクを完了するためにアプリの実行を継続する必要があります。 たとえば、アプリではオーディオの再生をバックグラウンドで継続できます。詳しくは、「[バックグラウンド オーディオ](https://msdn.microsoft.com/library/windows/apps/mt282140)」をご覧ください。 また、バックグラウンドの転送処理は、アプリが中断または終了した場合でも引き続き実行されます。詳しくは、「[ファイルのダウンロード方法](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj152726.aspx#downloading_a_file_using_background_transfer)」をご覧ください。

ガイドラインについては、「[アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)」をご覧ください。

**Visual Studio によるデバッグに関する注意事項: **Visual Studio は、Visual Studio デバッガーにアタッチされているアプリを Windows が中断するのを防ぎます。 これは、アプリが実行されている間、ユーザーが Visual Studio デバッグの UI を確認できるようにするためです。 アプリのデバッグ中は、Visual Studio を使ってそのアプリに中断イベントを送信できます。 **[デバッグの場所]** ツール バーが表示されていることを確認し、**[中断]** アイコンをクリックします。

## アプリの表示


ユーザーがアプリを別のアプリに切り替えると、元のアプリは表示されなくなりますが、Windows によって中断されるまでは **Running** 状態が維持されます。 ユーザーがアプリを切り替えても、中断される前にそのアプリをアクティブ化したり再びそのアプリに切り替えた場合は、アプリは **Running** 状態のままになります。

アプリの表示が切り替わったときは、アプリは実行状態のままであるため、アクティブ化イベントを受け取りません。 必要に応じて、Windows でアプリの切り替えだけが行われます。 ユーザーがアプリを切り替えたときになんらかの処理を行う必要がある場合は、[**Window.VisibilityChanged**](https://msdn.microsoft.com/library/windows/apps/hh702458) イベントを処理します。

これらのイベントの特定の順序に依存しないでください。

## アプリの再開


中断中のアプリは、ユーザーがそのアプリに切り替えた場合、またはデバイスが低電力状態から復帰してアクティブなアプリになった場合に再開されます。

アプリが再開されたときのアプリの状態については、[**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) 列挙体を確認してください。 アプリが **Suspended** 状態から再開されると、**Running** 状態になり、中断された時点から再開されます。 メモリに格納されているアプリのデータは失われません。 したがって、ほとんどのアプリでは、再開時に処理を行う必要はありません。 ただし、アプリは長時間中断されていた可能性があります。 そのため、アプリのコンテンツやネットワーク接続が無効になっていると考えられる場合は、アプリの再開時にコンテンツやネットワーク接続を更新する必要があります。 アプリに [**Application.Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントのイベント ハンドラーが登録されている場合は、アプリが **Suspended** 状態から再開されるとこのイベント ハンドラーが呼び出されます。 このイベント ハンドラーを使ってアプリのコンテンツやデータを更新できます。

中断中のアプリがアクティブ化されてアプリ コントラクトまたは拡張機能に参加する場合は、まず **Resuming** イベントを受け取り、次に **Activated** イベントを受け取ります。

中断中、アプリは受信登録したネットワーク イベント項目を受け取りません。 これらのネットワーク イベントはキューに入れられず、受け取ることができません。 そのため、再開時にアプリでネットワーク ステータスをテストする必要があります。

**注:** [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントは UI とは異なるスレッドで発生するため、再開ハンドラーが UI とやり取りする場合はディスパッチャーを使う必要があります。

 

ガイドラインについては、「[アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)」をご覧ください。

## アプリを閉じる


一般に、アプリを閉じる処理はユーザーが行う必要はなく、Windows で管理されます。 ただし、ユーザーはジェスチャを使うか、Windows で Alt + F4 キーを押すか、Windows Phone でタスク スイッチャーを使って、アプリを閉じることができます。

ユーザーがアプリを閉じたことを示す専用のイベントはありません。

ユーザーがアプリを閉じると、中断された後に終了され、**NotRunning** 状態になります。

Windows 8.1 以降では、ユーザーがアプリを閉じても、アプリは明示的に終了されるのではなく、画面と切り替えリストから消えるだけです。

アプリに **Suspending** イベントのイベント ハンドラーが登録されている場合は、アプリが中断されるとこのイベント ハンドラーが呼び出されます。 このイベント ハンドラーを使って、関連するアプリ データとユーザー データを固定ストレージに保存できます。

**ユーザーが閉じた場合の動作: **ユーザーがアプリを閉じたときに、Windows によって閉じられたときとは異なる動作にする必要がある場合は、アクティブ化イベント ハンドラーを使って、アプリをユーザーが終了したか、または Windows によって終了されたかを特定できます。 [
            **ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) 列挙体に関するリファレンスの **ClosedByUser** 状態と **Terminated** 状態の説明をご覧ください。

必要でない限り、アプリをプログラムで閉じないことをお勧めします。 たとえば、メモリ リークが検出された場合などは、ユーザーの個人データのセキュリティを確保するためにアプリ自体で閉じてもかまいません。 アプリをプログラムで閉じると、システムではアプリのクラッシュとして処理されます。

## アプリのクラッシュ


システム クラッシュのエクスペリエンスは、ユーザーがそれまで行っていた作業にできるだけ迅速に戻れるようにすることを目的としています。 ユーザーを待たせることがないように、警告ダイアログなどによる通知は行わないでください。

アプリがクラッシュしたり、応答しなくなったり、例外が生成されたりすると、ユーザーの [フィードバックと診断の設定](http://go.microsoft.com/fwlink/p/?LinkID=614828) に従って、マイクロソフトに問題レポートが送られます。 Microsoft は、アプリの改善に役立つように、問題レポートに含まれるエラー データの一部を提供しています。 このデータは、ダッシュボードに表示されるアプリの [品質] ページで確認できます。

アプリがクラッシュした後にユーザーがアプリをアクティブ化すると、アクティブ化イベント ハンドラーは [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) の値として **NotRunning** を受け取り、アプリの最初の UI とデータを表示します。 クラッシュの後、**Suspended** に基づく **Resuming** で使ったアプリ データはそのまま使わないでください。これは、そのデータが破損している可能性があるためです。「[アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)」をご覧ください。

## アプリの削除


ユーザーがアプリを削除すると、アプリはすべてのローカル データと共に削除されます。 アプリの削除は、一般的な場所 (ドキュメント ライブラリやピクチャ ライブラリ内など) に格納されているユーザーのデータには影響しません。

## アプリのライフサイクルと Visual Studio のプロジェクト テンプレート


アプリのライフサイクルに関連する基本的なコードは、Visual Studio の開始プロジェクト テンプレートに用意されています。 基本的なアプリでは、起動アクティブ化を処理し、アプリ データを復元するための場所を提供して、独自のコードを追加する前であってもプライマリ UI を表示します。 詳しくは、「[アプリ用の C#、VB、C++ プロジェクト テンプレート](https://msdn.microsoft.com/library/windows/apps/hh768232)」をご覧ください。

## アプリケーションのライフサイクルに関する主要な API


-   [
              **Windows.ApplicationModel**
            ](https://msdn.microsoft.com/library/windows/apps/br224691) 名前空間
-   [
              **Windows.ApplicationModel.Activation**
            ](https://msdn.microsoft.com/library/windows/apps/br224766) 名前空間
-   [
              **Windows.ApplicationModel.Core**
            ](https://msdn.microsoft.com/library/windows/apps/br205865) 名前空間
-   [
              **Windows.UI.Xaml.Application**
            ](https://msdn.microsoft.com/library/windows/apps/br242324) クラス (XAML)
-   [
              **Windows.UI.Xaml.Window**
            ](https://msdn.microsoft.com/library/windows/apps/br209041) クラス (XAML)

**注**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください。

 

## 関連トピック


* [アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [アプリの事前起動の処理](handle-app-prelaunch.md)
* [アプリのアクティブ化の処理](activate-an-app.md)
* [アプリの中断の処理](suspend-an-app.md)
* [アプリの再開の処理](resume-an-app.md)

 

 



<!--HONumber=Jun16_HO4-->


