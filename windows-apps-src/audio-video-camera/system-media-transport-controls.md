---
ms.assetid: EFCF84D0-2F4C-454D-97DA-249E9EAA806C
description: SystemMediaTransportControls クラスを使うと、Windows に組み込まれているシステム メディア トランスポート コントロールをアプリで使って、現在アプリで再生中のメディアに関してコントロールに表示されるメタデータを更新できるようになります。
title: システム メディア トランスポート コントロール
---

# システム メディア トランスポート コントロール

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


[
            **SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) クラスを使うと、Windows に組み込まれているシステム メディア トランスポート コントロールをアプリで使って、現在アプリで再生中のメディアに関してコントロールに表示されるメタデータを更新できるようになります。

システム トランスポート コントロールは、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) オブジェクトのトランスポート コントロールとは異なります。 システム トランスポート コントロールは、ヘッドホンのボリューム コントロールやキーボードのメディア ボタンなどのハードウェア メディア キーを押すとポップアップするコントロールです。 ユーザーがキーボードの一時停止キーを押し、アプリが [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) をサポートしている場合、アプリは通知を受け取り、ユーザーは適切なアクションを実行できます。

アプリでは、[**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) に表示される曲のタイトル、サムネイル画像などのメディア情報も更新できます。

**注**  
[システム メディア トランスポート コントロール UWP サンプル](http://go.microsoft.com/fwlink/?LinkId=619488)は、この概要で説明するコードを実装します。 サンプルをダウンロードすると、コンテキスト内のコードを確認できます。独自のアプリの出発点として使うこともできます。

## トランスポート コントロールをセットアップする

ページの XAML ファイルで、システム メディア トランスポート コントロールによって制御する [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) を定義します。 [
            **CurrentStateChanged**](https://msdn.microsoft.com/library/windows/apps/br227375) イベントと [**MediaOpened**](https://msdn.microsoft.com/library/windows/apps/br227394) イベントは、システム メディア トランスポート コントロールを更新するために使われ、この記事の後半で説明します。

[!code-xml[MediaElementSystemMediaTransportControls](./code/SMTCWin10/cs/MainPage.xaml#SnippetMediaElementSystemMediaTransportControls)]

再生するファイルをユーザーが選択できるようにするボタンを XAML ファイルに追加します。

[!code-xml[OpenButton](./code/SMTCWin10/cs/MainPage.xaml#SnippetOpenButton)]

分離コード ページで、次の名前空間の using ディレクティブを追加します。

[!code-cs[Namespace](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetNamespace)]

[
            **FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使ってユーザーがファイルを選択するためのボタン クリック ハンドラーを追加します。次に、それを **MediaElement** のアクティブ ファイルにするために、[**SetSource**](https://msdn.microsoft.com/library/windows/apps/br244338) を呼び出します。

[!code-cs[OpenMediaFile](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetOpenMediaFile)]

[
            **GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/dn278708) を呼び出して、[**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) のインスタンスを取得します。

**SystemMediaTransportControls** オブジェクトの対応する "is enabled" プロパティ ([**IsPlayEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278714)、[**IsPauseEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278713)、[**IsNextEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278712)、[**IsPreviousEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278715) など) を設定することで、アプリで使うボタンを有効にします。 利用可能なすべてのコントロールの一覧については、**SystemMediaTransportControls** のリファレンス ドキュメントをご覧ください。

ユーザーがボタンを押したときに通知を受信するために、[**ButtonPressed**](https://msdn.microsoft.com/library/windows/apps/dn278706) イベントのハンドラーを登録します。

[!code-cs[SystemMediaTransportControlsSetup](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetSystemMediaTransportControlsSetup)]

## システム メディア トランスポート コントロールの押されたボタンを処理する

[
            **ButtonPressed**](https://msdn.microsoft.com/library/windows/apps/dn278706) イベントは、有効なボタンの 1 つが押されたときにシステム トランスポート コントロールで発生します。 イベント ハンドラーに渡される [**SystemMediaTransportControlsButtonPressedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn278683) の [**Button**](https://msdn.microsoft.com/library/windows/apps/dn278685) プロパティは、有効なボタンのうちどれが押されたかを示す [**SystemMediaTransportControlsButton**](https://msdn.microsoft.com/library/windows/apps/dn278681) 列挙体のメンバーです。

[
            **ButtonPressed**](https://msdn.microsoft.com/library/windows/apps/dn278706) イベント ハンドラーから UI スレッド上のオブジェクト ([**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) オブジェクトなど) を更新するには、[**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) を介して呼び出しをマーシャリングする必要があります。 これは、**ButtonPressed** イベント ハンドラーが UI スレッドから呼び出されず、UI を直接変更しようとすると例外が発生するためです。

[!code-cs[SystemMediaTransportControlsButtonPressed](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetSystemMediaTransportControlsButtonPressed)]

## 現在のメディアの状態でシステム メディア トランスポート コントロールを更新する

システムで現在の状態を反映してコントロールを更新できるように、メディアの状態が変更されたときには、それを [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) に通知する必要があります。 そのためには、メディアの状態が変更されたときに発生する [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) の [**CurrentStateChanged**](https://msdn.microsoft.com/library/windows/apps/br227375) イベント内から、[**PlaybackStatus**](https://msdn.microsoft.com/library/windows/apps/dn278719) プロパティを適切な [**MediaPlaybackStatus**](https://msdn.microsoft.com/library/windows/apps/dn278665) 値に設定します。

[!code-cs[SystemMediaTransportControlsStateChange](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetSystemMediaTransportControlsStateChange)]

## メディアの情報と縮小表示でシステム メディア トランスポート コントロールを更新する

[
            **SystemMediaTransportControlsDisplayUpdater**](https://msdn.microsoft.com/library/windows/apps/dn278686) クラスを使って、現在再生されているメディア項目の曲のタイトルやアルバム アートなど、トランスポート コントロールに表示されるメディア情報を更新します。 [
            **SystemMediaTransportControls.DisplayUpdater**](https://msdn.microsoft.com/library/windows/apps/dn278707) プロパティを使って、このクラスのインスタンスを取得します。 一般的なシナリオの場合、メタデータを渡すための推奨される方法は、現在再生中のメディア ファイルを渡して [**CopyFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn278694) を呼び出すことです。 表示アップデーターによって、ファイルからメタデータと縮小表示画像が自動的に抽出されます。

[
            **Update**](https://msdn.microsoft.com/library/windows/apps/dn278701) を呼び出すことで、システム メディア トランスポート コントロールの UI が新しいメタデータと縮小表示によって更新されます。

[!code-cs[SystemMediaTransportControlsUpdater](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetSystemMediaTransportControlsUpdater)]

必要に応じて、[**DisplayUpdater**](https://msdn.microsoft.com/library/windows/apps/dn278707) クラスによって公開される [**MusicProperties**](https://msdn.microsoft.com/library/windows/apps/dn278696)、[**ImageProperties**](https://msdn.microsoft.com/library/windows/apps/dn278695)、または [**VideoProperties**](https://msdn.microsoft.com/library/windows/apps/dn278702) オブジェクトの値を設定することにより、システム メディア トランスポート コントロールに表示されるメタデータを手動で更新できます。

[!code-cs[SystemMediaTransportControlsUpdaterManual](./code/SMTCWin10/cs/MainPage.xaml.cs#SystemMediaTransportControlsUpdaterManual)]

## システム メディア トランスポート コントロールのタイムライン プロパティを更新する

システム トランスポート コントロールには、メディア項目の現在の再生位置、開始時刻、終了時刻など、現在再生中のメディア項目のタイムラインに関する情報が表示されます。 システム メディア トランスポート コントロールのタイムライン プロパティを更新するには、新しい [**SystemMediaTransportControlsTimelineProperties**](https://msdn.microsoft.com/library/windows/apps/mt218746) オブジェクトを作成します。 再生中のメディア項目の現在の状態を反映するように、オブジェクトのプロパティを設定します。 [
            **SystemMediaTransportControls.UpdateTimelineProperties**](https://msdn.microsoft.com/library/windows/apps/mt218760) を呼び出して、コントロールのタイムラインを更新します。

[!code-cs[UpdateTimelineProperties](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetUpdateTimelineProperties)]

-   再生中の項目のタイムラインをシステム コントロールに表示するには、[**StartTime**](https://msdn.microsoft.com/library/windows/apps/mt218751)、[**EndTime**](https://msdn.microsoft.com/library/windows/apps/mt218747)、および [**Position**](https://msdn.microsoft.com/library/windows/apps/mt218755) の値を指定する必要があります。

-   [**MinSeekTime**](https://msdn.microsoft.com/library/windows/apps/mt218749) と [**MaxSeekTime**](https://msdn.microsoft.com/library/windows/apps/mt218748) を使うと、ユーザーがシークできるタイムライン内の範囲を指定できます。 一般的なシナリオとしては、コンテンツ プロバイダーがメディアに広告を含める場合などがあります。

    [
            **PositionChangeRequest**](https://msdn.microsoft.com/library/windows/apps/mt218755) を発生させるには、[**MinSeekTime**](https://msdn.microsoft.com/library/windows/apps/mt218749) と [**MaxSeekTime**](https://msdn.microsoft.com/library/windows/apps/mt218748) を設定する必要があります。

-   システム コントロールは、メディアの再生と同期させておくことをお勧めします。そのためには、再生中にこれらのプロパティを約 5 秒ごとに更新し、一時停止や新しい位置へのシークなど、再生に変更が加えられたときには、再度更新します。

## プレーヤーのプロパティの変更に応答する

再生中のメディア項目の状態ではなく、メディア プレーヤー自体の現在の状態に関連した、一連のシステム トランスポート コントロール プロパティがあります。 これらの各プロパティは、ユーザーが関連するコントロールを調整したときに発生するイベントと対応しています。 これらのプロパティとイベントを次に示します。

| プロパティ                                                                  | イベント                                                                                                   |
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------|
| [**AutoRepeatMode**](https://msdn.microsoft.com/library/windows/apps/mt218753) | [**AutoRepeatModeChangeRequested**](https://msdn.microsoft.com/library/windows/apps/mt218754) |
| [**PlaybackRate**](https://msdn.microsoft.com/library/windows/apps/mt218756)     | [**PlaybackRateChangeRequested**](https://msdn.microsoft.com/library/windows/apps/mt218757)     |
| [**ShuffleEnabled**](https://msdn.microsoft.com/library/windows/apps/mt218758) | [**ShuffleEnabledChangeRequested**](https://msdn.microsoft.com/library/windows/apps/mt218759) |

 
これらのコントロールの 1 つに対するユーザーの操作を処理するには、最初に、関連付けられているイベントのハンドラーを登録します。

[!code-cs[RegisterPlaybackChangedHandler](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetRegisterPlaybackChangedHandler)]

まず、イベントのハンドラーで、要求された値が有効な予想される範囲内にあることを確認します。 範囲内の場合は、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) の対応するプロパティを設定してから、[**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) オブジェクトの対応するプロパティを設定します。

[!code-cs[PlaybackChangedHandler](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetPlaybackChangedHandler)]

-   これらのプレーヤー プロパティ イベントの 1 つが発生するためには、プロパティの初期値を設定する必要があります。 たとえば、[**PlaybackRateChangeRequested**](https://msdn.microsoft.com/library/windows/apps/mt218757) は、[**PlaybackRate**](https://msdn.microsoft.com/library/windows/apps/mt218756) プロパティの値を少なくとも 1 回設定するまでは発生しません。

## バックグラウンド オーディオに対してシステム メディア トランスポート コントロールを使う

バックグラウンド オーディオに対してシステム メディア トランスポート コントロールを使うには、[**IsPlayEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278714) と [**IsPauseEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278713) を true に設定して、再生ボタンと一時停止ボタンを有効にする必要があります。 アプリは、[**ButtonPressed**](https://msdn.microsoft.com/library/windows/apps/dn278706) イベントも処理する必要があります。

アプリのバック グラウンド タスク内から [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) のインスタンスを取得するには、フォアグラウンド アプリからしか使えない [**GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/dn278708) の代わりに、[**BackgroundMediaPlayer.Current.SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn926635) を使う必要があります。

バックグラウンドでのオーディオ再生について詳しくは、「[バックグラウンド オーディオ](background-audio.md)」をご覧ください。

 

 






<!--HONumber=Mar16_HO1-->


