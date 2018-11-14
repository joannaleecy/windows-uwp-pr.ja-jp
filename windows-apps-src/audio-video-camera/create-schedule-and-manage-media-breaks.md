---
author: drewbatgit
ms.assetid: 0309c7a1-8e4c-4326-813a-cbd9f8b8300d
description: この記事では、メディア再生アプリ用にメディアの中断を作成、スケジュール、管理する方法について説明します。
title: メディアの中断の作成、スケジュール、管理
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0feb7f6771254bf500e4b64fd0e632daad9817e4
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6674673"
---
# <a name="create-schedule-and-manage-media-breaks"></a>メディアの中断の作成、スケジュール、管理

この記事では、メディア再生アプリ用にメディアの中断を作成、スケジュール、管理する方法について説明します。 通常、メディアの中断は、オーディオ広告やビデオ広告をメディア コンテンツに挿入する目的で使います。 Windows 10 バージョン 1607 以降では、[**MediaBreakManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager) クラスを使って、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) で再生する任意の [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem) にメディアの中断を簡単かつ迅速に追加できます。


メディアの中断を 1 つ以上スケジュールすると、再生中の指定した時間に、システムがメディア コンテンツを自動的に再生します。 **MediaBreakManager** では、ユーザーがメディアを中断、終了、またはスキップしたときにアプリが反応できるように、イベントが提供されています。 [**MediaPlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession) にアクセスしてメディアの中断を確認し、ダウンロードや進行状況の更新のバッファリングなどのイベントを監視することもできます。

## <a name="schedule-media-breaks"></a>メディアの中断のスケジュール
各 **MediaPlaybackItem** オブジェクトには、アイテムの再生時に再生されるメディアの中断の構成に使う独自の [**MediaBreakSchedule**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakSchedule) があります。 アプリでメディアの中断を使うための最初の手順は、メイン再生コンテンツ用の [ **MediaPlaybackItem** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem) の作成です。 

[!code-cs[MoviePlaybackItem](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetMoviePlaybackItem)]

**MediaPlaybackItem**、[**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList)、他の基本的なメディアの再生 API の操作の参照については、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」を参照してください。

次の例は、**MediaPlaybackItem** にプリロール区切りを追加する方法を示しています。これは、区切りが属する再生アイテムを再生する前に、システムがメディアの中断を再生することを意味します。 まず、新しい [**MediaBreak** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreak) オブジェクトがインスタンス化されます。 この例では、コンストラクター [**MediaBreakInsertionMethod.Interrupt**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakInsertionMethod) と共に呼び出されます。つまり、区切りコンテンツの再生中はメイン コンテンツが一時停止されます。 

次に、区切り中に再生されるコンテンツ (広告など) 用に新しい **MediaPlaybackItem** が作成されます。 この再生アイテムの [**CanSkip**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem.CanSkip) プロパティは false に設定されます。 つまり、ユーザーは組み込みのメディア コントロールを使ってアイテムをスキップできません。 ただし、[**SkipCurrentBreak**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager.SkipCurrentBreak) を呼び出すことで、広告をプログラムによりスキップすることを選ぶことはできます。 

メディアの中断の [**PlaybackList**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreak.PlaybackList) プロパティは、複数のメディア アイテムをプレイリストとして再生できるようにする [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList) です。 一覧の **Items** コレクションから 1 つまたは複数の **MediaPlaybackItem** オブジェクトを追加し、メディアの中断のプレイリストに含めます。

最後に、メイン コンテンツ再生アイテムの [ **BreakSchedule** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem.BreakSchedule) プロパティを使ってメディアの中断をスケジュールします。 プリロール区切りにする中断を、スケジュール オブジェクトの [ **PrerollBreak** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakSchedule.PrerollBreak) プロパティに割り当てることで指定します。

[!code-cs[PreRollBreak](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetPreRollBreak)]

これで、メイン メディア アイテムを再生できるようになりました。作成したメディアの中断は、メイン コンテンツの前に再生されます。 新しい [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) オブジェクトを作成し、オプションで [**AutoPlay**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.AutoPlay) プロパティをtrue に設定して再生を自動的に開始します。 **MediaPlayer** の [**Source**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Source) プロパティをメイン コンテンツ再生アイテムに設定します。 必須ではありませんが、**MediaPlayer** を [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) に割り当てて XAML ページでメディアをレンダリングできます。 **MediaPlayer** の使い方の詳細については、「[MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)」を参照してください。

[!code-cs[Play](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetPlay)]

プリロール区切りを同じ手法を使って、メイン コンテンツを含む **MediaPlaybackItem** の再生が終わったら再生されるポストロール区切りを追加します。ただし、**MediaBreak** オブジェクトを[**PostrollBreak**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakSchedule.PostrollBreak) プロパティに再生する点が異なります。

[!code-cs[PostRollBreak](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetPostRollBreak)]

メイン コンテンツの再生中の指定した時点で再生されるミッドロール区切りを 1 つ以上スケジュールすることもできます。 次の例では、メイン メディア アイテムの再生中に区切りが生成される時間を指定する **TimeSpan** オブジェクトを受け入れるコンストラクター オーバーロードを使って [**MediaBreak**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreak) が作成されます。 ここでも、[**MediaBreakInsertionMethod.Interrupt**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakInsertionMethod) が指定され、区切りの生成中にメイン コンテンツの再生が一時停止されることが示されます。 [**InsertMidrollBreak**](https://msdn.microsoft.com/library/windows/apps/mt670692) を呼び出すことで、ミッドロール区切りがスケジュールに追加されます。 [**MidrollBreaks**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakSchedule.MidrollBreaks) プロパティにアクセスすることで、スケジュールに含まれている現在のミッドロール区切りの読み取り専用一覧を取得できます。

[!code-cs[MidrollBreak](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetMidrollBreak)]

次のミッドロール区切りの例では、[**MediaBreakInsertionMethod.Replace**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakInsertionMethod) 挿入メソッドを使います。つまり、区切りの再生中もメイン コンテンツの再生が続けられます。 このオプションは通常、広告の再生中にライブ ストリームを一時停止して遅れを生じさせたくないライブ ストリーミング メディア アプリにより使われます。 

この例では、2 つの [**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/Windows.Foundation.TimeSpan) パラメーターを受け入れる [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem) コンストラクターのオーバーロードも使います。 最初のパラメーターは、メディアの中断アイテム内の、再生が開始される開始点を指定します。 2 番目のパラメーターは、メディアの中断アイテムが再生される時間の長さを指定します。 したがって、次の例では、20 分の時点でメイン コンテンツに対して **MediaBreak** が再生を開始します。 再生されると、区切りメディア アイテムの先頭から 30 秒後にメディア アイテムが開始され、15 秒間再生されてからメイン メディア コンテンツが再生を再開します。

[!code-cs[MidrollBreak2](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetMidrollBreak2)]

## <a name="skip-media-breaks"></a>メディアの中断のスキップ
この記事で既に説明したように、**MediaPlaybackItem** の [**CanSkip**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem.CanSkip) プロパティを設定し、ユーザーが組み込みコントロールを使ってコンテンツをスキップできないようにすることができます。 ただし、いつでもコードから [**SkipCurrentBreak**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager.SkipCurrentBreak) を呼び出すと現在の中断をスキップできます。

[!code-cs[SkipButtonClick](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetSkipButtonClick)]

## <a name="handle-mediabreak-events"></a>MediaBreak イベントの処理

メディアの中断の状態の変化に基づいてアクションを実行するために登録できる、メディアの中断に関連するいくつかのイベントがあります。

[!code-cs[RegisterMediaBreakEvents](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetRegisterMediaBreakEvents)]

[**BreakStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager.BreakStarted) は、メディアの中断が開始すると発生します。 メディア コンテンツを再生していることがユーザーにわかるように UI を更新できます。 この例では、ハンドラーに渡された [**MediaBreakStartedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakStartedEventArgs) を使って、開始されたメディアの中断への参照を取得します。 次に、[**CurrentItemIndex**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList.CurrentItemIndex) プロパティを使って、メディアの中断のプレイリストにある再生メディア アイテムが決定されます。 その後、UI が更新され、現在の広告インデックスと中断中の残りの広告数がユーザーに表示されます。 UI の更新は UI スレッドに加える必要があるため、[**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) の呼び出し内で呼び出しを行う必要がある点に注意してください。 

[!code-cs[BreakStarted](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetBreakStarted)]

[**BreakEnded**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager.BreakEnded) は、中断内のすべてのメディア アイテムが再生を終えるか、スキップされたときに発生します。 このイベントのハンドラーを使って UI を更新し、メディアの中断コンテンツがそれ以上再生されないことを示すことができます。

[!code-cs[BreakEnded](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetBreakEnded)]

**BreakSkipped** イベントは、[**CanSkip**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem.CanSkip) が true になっているアイテムの再生中ユーザーが組み込み UI の *[次へ]* ボタンを押したとき、または [**SkipCurrentBreak**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager.SkipCurrentBreak) を呼び出すことでコードで中断をスキップしたときに発生します。

次の例では、**MediaPlayer** の [**Source**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Source) プロパティを使って、メイン コンテンツのメディア アイテムへの参照を取得します。 スキップされたメディアの中断は、このアイテムの中断スケジュールに属しています。 次に、スキップされたメディアの中断がスケジュールの [**PrerollBreak**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakSchedule.PrerollBreak) プロパティに設定されたメディアの中断と同じであるかどうかをコードがチェックします。 同じである場合、プリロール区切りがスキップされた中断であることを意味します。この場合、新しいミッドロール区切りが作成され、メイン コンテンツの 10 分の時点で再生されるようにスケジュールされます。

[!code-cs[BreakSkipped](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetBreakSkipped)]

[**BreaksSeekedOver**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager.BreaksSeekedOver) は、メイン メディア アイテムの再生位置が、1 つ以上のメディアの中断のスケジュールされた時間を超えたときに発生します。 次の例では、1 つ以上のメディアの中断が要求されたかどうか、再生位置が先に移動されたかどうか、先に移動された時間が 10 分未満であるかどうかがチェックされます。 その場合、要求された最初の中断 (イベント引数により開示された [**SeekedOverBreaks**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakSeekedOverEventArgs.SeekedOverBreaks) コレクションから取得されます) が、**MediaPlayer.BreakManager** の [**PlayBreak**](https://msdn.microsoft.com/library/windows/apps/mt670689) メソッドを呼び出すことですぐに再生されます。

[!code-cs[BreakSeekedOver](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetBreakSeekedOver)]


## <a name="access-the-current-playback-session"></a>現在の再生セッションへのアクセス
[**MediaPlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession) オブジェクトは、**MediaPlayer** クラスを使って、現在再生中のメディア コンテンツに関連するデータとイベントを提供します。 [ **MediaBreakManager** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager) にも、再生中のメディアの中断コンテンツに特に関連するデータとイベントを取得するためにアクセスできる **MediaPlaybackSession** があります。 再生セッションから入手できる情報には、現在の再生状態、再生中か一時停止中か、コンテンツ内の現在の再生位置などがあります。 メディアの中断コンテンツの縦横比がメイン コンテンツと異なる場合、[**NaturalVideoWidth**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.NaturalVideoWidth) プロパティおよび [**NaturalVideoHeight**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.NaturalVideoHeight) プロパティと [**NaturalVideoSizeChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.NaturalVideoSizeChanged) を使って、ビデオ UI を調整することができます。 アプリのパフォーマンスに関する貴重な利用統計情報を示す、[**BufferingStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.BufferingStarted)、[**BufferingEnded**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.BufferingEnded)、[**DownloadProgressChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.DownloadProgressChanged) などのイベントを受け取ることもできます。

次の例では、**BufferingProgressChanged イベント**のハンドラーを登録します。イベント ハンドラーでは、UI が更新されて現在のバッファリングの進行状況が表示されます。

[!code-cs[RegisterBufferingProgressChanged](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetRegisterBufferingProgressChanged)]

[!code-cs[BufferingProgressChanged](./code/MediaBreaks_RS1/cs/MainPage.xaml.cs#SnippetBufferingProgressChanged)]

## <a name="related-topics"></a>関連トピック
* [メディア再生](media-playback.md)
* [MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)
* [システム メディア トランスポート コントロールの手動制御](system-media-transport-controls.md)

 

 




