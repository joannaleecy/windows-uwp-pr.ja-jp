---
author: drewbatgit
ms.assetid: eb690f2b-3bf8-4a65-99a4-2a3a8c7760b7
description: "この記事では、システム メディア トランスポート コントロールを操作する方法について説明します。"
title: "システム メディア トランスポート コントロールとの統合"
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: ca8910129ba0993597be905a24fb5b2c5c4061a4
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="integrate-with-the-system-media-transport-controls"></a>システム メディア トランスポート コントロールとの統合

この記事では、システム メディア トランスポート コントロール (SMTC) を操作する方法について説明します。 SMTC は、すべての Windows 10 デバイスに共通する一連のコントロールで、再生に [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) を使うすべての実行中のアプリのメディア再生をユーザーが制御するための一貫した方法を提供します。

SMTC との統合を示す完全なサンプルについては、[github のシステム メディア トランスポート コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/SystemMediaTransportControls)をご覧ください。
                    
##<a name="automatic-integration-with-smtc"></a>SMTC との自動統合
Windows 10 バージョン 1607 以降、メディアの再生に [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) クラスを使う UWP アプリは、既定で SMTC と自動的に統合されます。 **MediaPlayer** の新しいインスタンスをインスタンス化し、[**MediaSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource)、[**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem)、または [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList) をプレーヤーの [**Source**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Source) プロパティに割り当てるだけで、SMTC にアプリ名が表示され、SMTC コントロールを使って再生リストから再生、一時停止、再生リスト内の移動を行うことができます。 

アプリは一度に複数の **MediaPlayer** オブジェクトを作成し、使うことができます。 アプリ内のアクティブな **MediaPlayer** インスタンスごとに、SMTC に個別のタブが作成されるため、ユーザーはアクティブなメディア プレーヤーとその他の実行中のアプリのメディア プレーヤーを切り替えることができます。 SMTC で現在選択されているメディア プレーヤーが、コントロールが影響を与えるメディア プレーヤーとなります。

アプリで **MediaPlayer** を使う方法 (XAML ページで [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) にバインドするなど) について詳しくは、「[MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)」をご覧ください。 

**MediaSource**、**MediaPlaybackItem**、**MediaPlaybackList** の操作について詳しくは、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」をご覧ください。

##<a name="add-metadata-to-be-displayed-by-the-smtc"></a>SMTC で表示するメタデータを追加する
ビデオや曲のタイトルなど、SMTC でメディア項目に表示するメタデータを追加または変更する場合、メディア項目を表す **MediaPlaybackItem** の表示プロパティを更新する必要があります。 まず、[**GetDisplayProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem.GetDisplayProperties) を呼び出して、[**MediaItemDisplayProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaItemDisplayProperties) オブジェクトへの参照を取得します。 次に、[**Type**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaItemDisplayProperties.Type) プロパティを持つ項目に、メディアの種類 (音楽またはビデオ) を設定します。 その後、指定したメディアの種類によって、[**MusicProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaItemDisplayProperties.MusicProperties) または [**VideoProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaItemDisplayProperties.VideoProperties) のフィールドを設定できます。 最後に、[**ApplyDisplayProperties**](https://msdn.microsoft.com/library/windows/apps/mt489923) を呼び出して、メディア項目のメタデータを更新します。

[!code-cs[SetVideoProperties](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetSetVideoProperties)]

[!code-cs[SetMusicProperties](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetSetMusicProperties)]

##<a name="use-commandmanager-to-modify-or-override-the-default-smtc-commands"></a>CommandManager を使って既定の SMTC コマンドを変更またはオーバーライドする
アプリでは、[**MediaPlaybackCommandManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager) クラスを使って SMTC コントロールの動作を変更または完全にオーバーライドできます。 [**CommandManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.CommandManager) プロパティにアクセスすると、**MediaPlayer** クラスのインスタンスごとにコマンド マネージャー インスタンスを取得できます。

既定では **MediaPlaybackList** の次の項目にスキップする *Next* コマンドなどのすべてのコマンドに、コマンド マネージャーは [**NextReceived**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.NextReceived) のような受信イベントと、[**NextBehavior**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.NextBehavior) のようにコマンドの動作を管理するオブジェクトを公開します。 

次の例では、**NextReceived** イベントのハンドラーと、**NextBehavior** の [**IsEnabledChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManagerCommandBehavior.IsEnabledChanged) イベントのハンドラーを登録します。

[!code-cs[AddNextHandler](./code/SMTC_RS1/cs/MainPage.xaml.cs#SnippetAddNextHandler)]

次の例は、ユーザーが再生リスト内の 5 個の項目をクリックスルーした後、アプリが *Next* コマンドを無効にするシナリオを示しています。おそらくは、コンテンツを引き続き再生する前に、何らかのユーザー操作が必要になります。 **NextReceived** イベントが発生するたびに、カウンターがインクリメントされます。 カウンターが目標の数値に達すると、*Next* コマンドの [**EnablingRule**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManagerCommandBehavior.EnablingRule) が [**Never**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaCommandEnablingRule) に設定され、コマンドが無効になります。 

[!code-cs[NextReceived](./code/SMTC_RS1/cs/MainPage.xaml.cs#SnippetNextReceived)]

コマンドを **Always** に設定することもできます。これは、*Next* コマンドの例では、再生リスト内にこれ以上項目がない場合でも、コマンドが常に有効になっていることを示します。 または、コマンドを **Auto** に設定することもできます。この設定では、現在再生中のコンテンツに基づいてコマンドを有効にする必要があるかどうかがシステムによって判断されます。

上記のシナリオでは、ある時点でアプリが *Next* コマンドを再度有効にする必要があるため、**EnablingRule** を **Auto** に設定することでそれを行います。

[!code-cs[EnableNextButton](./code/SMTC_RS1/cs/MainPage.xaml.cs#SnippetEnableNextButton)]

アプリには、アプリがフォアグラウンドで動作しているときに再生を制御するための独自の UI が備わっている可能性があるため、[**IsEnabledChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManagerCommandBehavior.IsEnabledChanged) イベントを使って独自の UI を SMTC と一致するように更新し、ハンドラーに渡された [**MediaPlaybackCommandManagerCommandBehavior**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManagerCommandBehavior) の [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManagerCommandBehavior.IsEnabled) にアクセスすることによってコマンドを有効または無効にすることができます。

[!code-cs[IsEnabledChanged](./code/SMTC_RS1/cs/MainPage.xaml.cs#SnippetIsEnabledChanged)]

場合によっては、SMTC コマンドの動作を完全にオーバーライドすることもできます。 次の例は、アプリが *Next* コマンドと *Previous* コマンドを使って、現在の再生リスト内のトラック間をスキップするのではなく、インターネット ラジオ局どうしを切り替えるシナリオを示しています。 前の例と同様に、ハンドラーはコマンドの受信時に登録されます。ここでは、[**PreviousReceived**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.PreviousReceived) イベントの受信時となります。

[!code-cs[AddPreviousHandler](./code/SMTC_RS1/cs/MainPage.xaml.cs#SnippetAddPreviousHandler)]

**PreviousReceived** ハンドラーでは、まず、ハンドラーに渡された [**MediaPlaybackCommandManagerPreviousReceivedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManagerPreviousReceivedEventArgs) の [**GetDeferral**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManagerPreviousReceivedEventArgs.GetDeferral) を呼び出すことによって、[**Deferral**](https://msdn.microsoft.com/library/windows/apps/Windows.Foundation.Deferral) が取得されます。 これにより、システムは Deferral が完了するのを待機してからコマンドを実行するよう通知されます。 これは、ハンドラーで非同期呼び出しを行う場合に非常に重要です。 この時点で、この例では前のラジオ局を表す **MediaPlaybackItem** を返すカスタム メソッドを呼び出します。

次に、[**Handled**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManagerPreviousReceivedEventArgs.Handled) プロパティで、イベントが別のハンドラーによってまだ処理されていないかどうかが確認されます。 処理済みの場合、**Handled** プロパティが true に設定されます。 これにより、SMTC と、その他の受信登録されたハンドラーは、イベントが既に処理済みなのでこのコマンドを実行する必要がないことを把握できます。 その後、コードはメディア プレーヤーの新しいソースを設定し、プレーヤーを開始します。

最後に、保留オブジェクトで [**Complete**](https://msdn.microsoft.com/library/windows/apps/Windows.Foundation.Deferral.Complete) が呼び出されて、システムはコマンドの処理が完了したことを把握できます。

[!code-cs[PreviousReceived](./code/SMTC_RS1/cs/MainPage.xaml.cs#SnippetPreviousReceived)]
                 
##<a name="manual-control-of-the-smtc"></a>SMTC の手動制御
この記事で既に説明したように、SMTC はアプリによって作成される **MediaPlayer** のすべてのインスタンスに関する情報を自動的に検出して表示します。 **MediaPlayer** のインスタンスを複数使うが、SMTC ではアプリのエントリを 1 つだけ提供する場合、自動統合を使うのではなく、SMTC を手動で制御する必要があります。 また、[**MediaTimelineController**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaTimelineController) を使って 1 つ以上のメディア プレーヤーを制御する場合、手動 SMTC 統合を使う必要があります。 アプリが **MediaPlayer** 以外の API ([**AudioGraph**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioGraph) クラスなど) を使ってメディアを再生する場合も、ユーザーが SMTC を使ってアプリを制御できるように、手動 SMTC 統合を実装する必要があります。 SMTC を手動で制御する方法について詳しくは、「[システム メディア トランスポート コントロールの手動制御](system-media-transport-controls.md)」をご覧ください。



## <a name="related-topics"></a>関連トピック
* [メディア再生](media-playback.md)
* [MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)
* [システム メディア トランスポート コントロールの手動制御](system-media-transport-controls.md)
* [github のシステム メディア トランスポート コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/SystemMediaTransportControls)
 

 




