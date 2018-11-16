---
author: drewbatgit
ms.assetid: 3848cd72-eccd-400e-93ff-13649cd81b6c
description: この記事では、従来のバックグラウンドでのメディアの再生モデルを使用するアプリにサポートを提供したり、新しいモデルに移行するためのガイダンスを提供します。
title: 従来のバックグラウンドでのメディアの再生
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 319343a06eeb49fc4ec0ca2fcd340f655654f718
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6981428"
---
# <a name="legacy-background-media-playback"></a>従来のバックグラウンドでのメディアの再生


この記事では、UWP アプリにバックグラウンド オーディオのサポートを追加できる従来の 2 プロセスのモデルについて説明します。 Windows 10 バージョン 1607 以降では、バックグラウンド オーディオ用に 1 プロセスのモデルが提供されているため、より簡単に実装できます。 バックグラウンド オーディオに対する現在の推奨事項について詳しくは、「[バックグラウンドでのメディアの再生](background-audio.md)」をご覧ください。 この記事は、従来の 2 プロセスのモデルを使用して既に開発されたアプリにサポートを提供することを目的としています。

> [!NOTE]
> Windows、バージョン 1703 以降では**BackgroundMediaPlayer**は非推奨し、将来のバージョンの Windows で利用可能なことができない可能性があります。

## <a name="background-audio-architecture"></a>バックグラウンド オーディオのアーキテクチャ

バックグラウンド再生を実行するアプリは、2 つのプロセスで構成されています。 最初のプロセスはメイン アプリです。アプリ UI とクライアント ロジックを含んでおり、フォアグラウンドで実行されます。 2 番目のプロセスはバックグラウンド再生タスクです。すべての UWP アプリのバックグラウンド タスクと同様、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) を実装しています。 バックグラウンド タスクには、オーディオ再生のロジックとバックグラウンド サービスが含まれています。 バックグラウンド タスクは、システム メディア トランスポート コントロールを通じてシステムと通信します。

次の図は、システムの設計概要を簡単に示しています。

![Windows 10 のバックグラウンド オーディオのアーキテクチャ](images/backround-audio-architecture-win10.png)
## <a name="mediaplayer"></a>MediaPlayer

[**Windows.Media.Playback**](https://msdn.microsoft.com/library/windows/apps/dn640562) 名前空間には、バックグラウンドでオーディオを再生するために使用する API が含まれています。 再生が発生するアプリごとに、単一の [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/dn652535) インスタンスが存在します。 バックグラウンド オーディオ アプリは、**MediaPlayer** クラスのメソッドを呼び出し、プロパティを設定することで、現在のトラックの設定、再生の開始、一時停止、早送り、巻き戻しなどのコマンドを行います。 MediaPlayer オブジェクトのインスタンスには、常に [**BackgroundMediaPlayer.Current**](https://msdn.microsoft.com/library/windows/apps/dn652528) プロパティを通じてアクセスします。

## <a name="mediaplayer-proxy-and-stub"></a>MediaPlayer プロキシとスタブ

アプリのバックグラウンド プロセスから **BackgroundMediaPlayer.Current** にアクセスすると、**MediaPlayer** インスタンスがバックグラウンド タスク ホストでアクティブ化され、直接操作できるようになります。

フォアグラウンド アプリケーションから **BackgroundMediaPlayer.Current** にアクセスした場合に返される **MediaPlayer** インスタンスは、実際には、バックグラウンド プロセスでスタブと通信するプロキシです。 このスタブは、実際の **MediaPlayer** インスタンスとやり取りしますが、このインスタンスもバックグラウンド プロセスでホストされています。

フォアグラウンドとバックグラウンドの両方のプロセスで、**MediaPlayer** インスタンスのほとんどのプロパティにアクセスできます。ただし、[**MediaPlayer.Source**](https://msdn.microsoft.com/library/windows/apps/dn987010) と [**MediaPlayer.SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn926635) は例外で、これらはバックグラウンド プロセスからのみアクセスできます。 フォアグラウンド アプリとバックグラウンド プロセスはいずれも、[**MediaOpened**](https://msdn.microsoft.com/library/windows/apps/dn652609)、[**MediaEnded**](https://msdn.microsoft.com/library/windows/apps/dn652603)、[**MediaFailed**](https://msdn.microsoft.com/library/windows/apps/dn652606) など、メディア固有のイベントに関する通知を受け取ることができます。

## <a name="playback-lists"></a>プレイリスト

バックグラウンド オーディオ アプリケーションの一般的なシナリオでは、複数の項目が連続して再生されます。 これをバックグラウンド プロセスで最も簡単に実行するには、[**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955) オブジェクトを使います。このオブジェクトは、[**MediaPlayer.Source**](https://msdn.microsoft.com/library/windows/apps/dn987010) プロパティに割り当てることで、**MediaPlayer** のソースとして設定できます。

バックグラウンド プロセスに設定された **MediaPlaybackList** にフォアグラウンド プロセスからアクセスすることはできません。

## <a name="system-media-transport-controls"></a>システム メディア トランスポート コントロール

ユーザーは、アプリの UI を直接使用しなくても、Bluetooth デバイス、SmartGlass、システム メディア トランスポート コントロールなどの手段で、オーディオの再生を制御できます。 バックグラウンド タスクでは、[**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) クラスを使って、ユーザーが開始するこれらのシステム イベントの受信登録を行います。

バックグラウンド プロセスから **SystemMediaTransportControls** インスタンスを取得するには、[**MediaPlayer.SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn926635) プロパティを使います。 フォアグラウンド アプリは、[**SystemMediaTransportControls.GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/dn278708) を呼び出すことでクラスのインスタンスを取得しますが、返されるインスタンスはフォアグラウンドのみのインスタンスであり、バックグラウンド タスクとは関係ありません。

## <a name="sending-messages-between-tasks"></a>タスク間のメッセージ送信

バックグラウンド オーディオ アプリの 2 つのプロセス間で通信することが必要になる場合があります。 たとえば、新しいトラックの再生が始まるときにバックグラウンド タスクからフォアグラウンド タスクに通知し、新しい曲のタイトルをフォアグラウンド タスクに送って画面に表示させることがあります。

単純な通信メカニズムにより、フォアグラウンド プロセスとバックグラウンド プロセスの両方でイベントを発生させることができます。 [**SendMessageToForeground**](https://msdn.microsoft.com/library/windows/apps/dn652533) メソッドと [**SendMessageToBackground**](https://msdn.microsoft.com/library/windows/apps/dn652532) メソッドは、それぞれ対応するプロセスでイベントを呼び出します。 [**MessageReceivedFromBackground**](https://msdn.microsoft.com/library/windows/apps/dn652530) イベントと [**MessageReceivedFromForeground**](https://msdn.microsoft.com/library/windows/apps/dn652531) イベントの受信登録を行うことで、メッセージを受信することができます。

データは引数としてメッセージ送信メソッドに渡され、次にメッセージ受信イベント ハンドラーに渡されます。 データを渡すには、[**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) クラスを使います。 このクラスは、文字列をキーとして格納し、その他の値の型を値として格納するディクショナリです。 渡すことができるのは、整数型、文字列型、ブール型など、単純型の値です。

## <a name="background-task-life-cycle"></a>バックグラウンド タスクの有効期間

バックグラウンド タスクの有効期間は、アプリの現在の再生状態に密接に関係します。 たとえば、ユーザーがオーディオ再生を一時停止すると、システムは状況に応じてアプリを終了させたり、取り消したりします。 オーディオが再生されることなく一定の時間が経過すると、システムが自動的にバックグラウンド タスクをシャットダウンします。

[**IBackgroundTask.Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドが呼び出されるのは、初めてアプリがフォアグラウンド アプリで実行中のコードから [**BackgroundMediaPlayer.Current**](https://msdn.microsoft.com/library/windows/apps/dn652528) にアクセスしたときと、[**MessageReceivedFromBackground**](https://msdn.microsoft.com/library/windows/apps/dn652530) イベントに対するハンドラーを登録したときのうち、早い方です。 バックグラウンド プロセスから送信されたメッセージをフォアグラウンド アプリで逃すことのないよう、初めて **BackgroundMediaPlayer.Current** を呼び出す前にメッセージ受信ハンドラーに登録しておくことをお勧めします。

バックグラウンド タスクを有効な状態に維持するために、アプリでは **Run** メソッドから [**BackgroundTaskDeferral**](https://msdn.microsoft.com/library/windows/apps/hh700499) を要求し、タスク インスタンスが [**Canceled**](https://msdn.microsoft.com/library/windows/apps/br224798) イベントまたは [**Completed**](https://msdn.microsoft.com/library/windows/apps/br224788) イベントを受け取るときに [**BackgroundTaskDeferral.Complete**](https://msdn.microsoft.com/library/windows/apps/hh700504) を呼び出す必要があります。 **Run** メソッドではループ処理または待機を行わないでください。リソースが消費され、アプリのバックグラウンド タスクがシステムによって終了される原因になることがあります。

**Run** メソッドが完了し、遅延が要求されない場合、バックグラウンド タスクは **Completed** イベントを取得します。 場合によっては、アプリで **Canceled** イベントを取得したときに、その後に **Completed** イベントが続くことがあります。 タスクでは、**Run** の実行中に **Canceled** イベントを受け取ることがあるため、このような同時実行の可能性に必ず対処してください。

バックグラウンド タスクが取り消される状況には、次のような場合があります。

-   専用サブポリシーが適用されるシステムで、オーディオ再生機能を備えた新しいアプリが起動した場合。 後の「[バックグラウンド オーディオ タスクの有効期間に関するシステム ポリシー](#system-policies-for-background-audio-task-lifetime)」をご覧ください。

-   バックグラウンド タスクが起動したが、音楽はまだ再生されず、フォアグラウンド アプリが中断された場合。

-   他のメディアの割り込み (着信通話や VoIP 通話など)。

バックグラウンド タスクが予告なしに終了される状況には、次のような場合があります。

-   VoIP 通話の着信があるが、バックグラウンド タスクを存続させるための十分なメモリがシステムにない場合。

-   リソース ポリシーの違反が発生した場合。

-   タスクの取り消しまたは完了が適切に終わらない場合。

## <a name="system-policies-for-background-audio-task-lifetime"></a>バックグラウンド オーディオ タスクの有効期間に関するシステム ポリシー

バックグラウンド オーディオ タスクの有効期間をシステムでどのように管理するかを決定するには、次のポリシーが役立ちます。

### <a name="exclusivity"></a>Exclusivity (排他)

このサブポリシーが有効であれば、バックグラウンド オーディオ タスクの数が常に 1 件以内に制限されます。 モバイルやその他の非デスクトップ SKU で有効に設定されます。

### <a name="inactivity-timeout"></a>無通信タイムアウト

リソースの制約により、システムは、非アクティブな状態が一定期間続いた後にバックグラウンド タスクを終了する可能性があります。

バックグラウンド タスクは、以下の条件が満たされた場合に "非アクティブ" と見なされます。

-   フォアグラウンド アプリが表示されていない (中断または終了済み)。

-   バックグラウンドのメディア プレーヤーが再生中の状態ではない。

両方の条件が満たされている場合、バックグラウンド メディアのシステム ポリシーは、タイマーを開始します。 タイマーの有効期限が切れたときにどちらの条件にも変化がない場合、バックグラウンド メディアのシステム ポリシーによってバックグラウンド タスクが終了されます。

### <a name="shared-lifetime"></a>Shared Lifetime (共有の有効期間)

このサブポリシーが有効であれば、バックグラウンド タスクがフォアグラウンド タスクの有効期間に依存するように強制されます。 ユーザーまたはシステムによってフォアグラウンド タスクがシャットダウンされると、バックグラウンド タスクもシャットダウンされます。

ただし、フォアグラウンドはバックグラウンドに依存しません。 バックグラウンド タスクがシャットダウンしても、これによってフォアグラウンド タスクがシャットダウンされるわけではありません。

次の表は、デバイスの種類によって適用されるポリシーを示します。

| サブポリシー             | デスクトップ  | モバイル   | その他    |
|------------------------|----------|----------|----------|
| **Exclusivity (排他)**        | 無効 | 有効  | 有効  |
| **無通信タイムアウト** | 無効 | 有効  | 無効 |
| **Shared Lifetime (共有の有効期間)**    | 有効  | 無効 | 無効 |


 

 




