---
author: QuinnRadich
title: Windows 10 の開発者向け新着情報、ツール、機能
description: Windows 10 ビルド 16299 と新しい開発者ツールでは、ユニバーサル Windows プラットフォームによって強化されたツール、機能、エクスペリエンスを利用できます。
keywords: 新着情報, 新機能, 更新, 更新プログラム, 機能, 新規, Windows 10, 1709, 10 月, 最新, 開発者, 16299, Fall Creators
ms.author: quradic
ms.date: 11/02/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: ffe7de94e4a8564b4971fda0b64f6648d9b6088b
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4156535"
---
# <a name="whats-new-in-windows-10-for-developers-build-16299"></a>Windows 10 ビルド 16299 の開発者向け新着情報

Windows 10 ビルド 16299 (Fall Creators Update またはバージョン 1709 とも呼ばれます) と Visual Studio 2017 および更新された SDK には、優れたユニバーサル Windows プラットフォーム アプリを作るためのツール、機能、エクスペリエンスが用意されています。 Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

ここには、Windows 開発者にとって重要なこのリリースの新機能、強化された機能、ガイダンスを集めました。 Windows SDK に追加されたすべての新しい名前空間の一覧については、「[Windows 10 ビルド 16299 API の変更点](windows-10-build-16299-api-diff.md)」をご覧ください。 Windows 10 での注目すべき機能について詳しくは、「[Windows 10 の優れた機能](http://go.microsoft.com/fwlink/?LinkId=823181)」をご覧ください。 また、Windows プラットフォームに過去に追加された機能と今後追加される機能の概要については、[Windows 開発者向けプラットフォーム機能に関するページ](https://developer.microsoft.com/windows/platform/features)をご覧ください。

## <a name="design--ui"></a>設計および UI

機能 | 説明
 :------ | :------
条件付き XAML | [バージョン アダプティブ アプリ](../debug-test-perf/version-adaptive-apps.md)の作成を可能にする[条件付き XAML](../debug-test-perf/conditional-xaml.md) を使うことができるようになりました。 条件付き XAML では、XAML マークアップで **ApiInformation.IsApiContractPresent** メソッドを使用できるため、分離コードを使わなくても、API の有無に基づいてマークアップでプロパティの設定やオブジェクトのインスタンス化を行うことができます。
設計ツールキット | [UWP アプリ用の設計ツールキットとリソース](../design/downloads/index.md)が拡張され、スケッチ ツールキットと Adobe XD ツールキットが追加されました。 既存のツールキットも刷新され、より堅牢なコントロールとレイアウト テンプレートが UWP アプリに提供されます。 さらに、例やヒントを提供するため、新しいツールとサンプルが追加されました。
Fluent Design の効果 | これらの新しい効果は Fluent Design System の一部であり、重要な UI 要素にユーザーが専念できるように、深度、視点、および動きが使用されています。 </br>* [アクリル素材](../design/style/acrylic.md)は、透明なテクスチャを作成できる、ブラシの種類の 1 つです。 </br>* [視差効果](../design/motion/parallax.md)を使用すると、3 次元の深度と視点をアプリに追加できます。 </br>* [表示](../design/style/reveal.md)を使用すると、アプリの重要な要素を強調できます。 </br> 詳しくは、[Fluent Design の概要に関するページ](https://fluent.microsoft.com/)をご覧ください。
キーボード アクセラレータ | [キーボード アクセラレータ](../design/input/keyboard-accelerators.md)、つまりショートカットによって、アプリのアクセシビリティと使いやすさが向上します。 ユーザーがアプリの UI を移動しなくても直感的な方法で一般的な操作やコマンドを呼び出すことができ、必要な機能のスコープに合わせて構成することができます。
インク操作 | [CoreIncrementalInkStroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.core.coreincrementalinkstroke) API を使うと、個々の **InkPoint** オブジェクトを使って段階的にレンダリングできる個々のインク ストロークを作成できます。 </br></br> [CoreInkPresenterHost](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.core.coreinkpresenterhost) API を使うと、関連する **InkCanvas** コントロールがなくても **InkPresenter** オブジェクトをホストできます。
ラジアル コントローラー | [RadialControllerConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollerconfiguration) API は、**RadialController** メニューをアプリのビューまたはプロセスに絞り込む機能によって更新されました。
ライブ タイル | [Desktop Bridge Win32 アプリからセカンダリタイルをピン留め](../design/shell/tiles-and-notifications/secondary-tiles-desktop-pinning.md)します。
トースト通知 | ボタンに[保留更新](../design/shell/tiles-and-notifications/toast-pending-update.md)を使用して、トースト内に複数ステップの対話機能を作成します。
UI コントロール | 新しいコントロールを使用すると、優れた外観の UI をすばやく簡単に作成できます。 </br>* [カラー ピッカー コントロール](../design/controls-and-patterns/color-picker.md)では、ユーザーが色を自由に確認しながら選択できます。 </br>* [ナビゲーション ビュー コントロール](../design/controls-and-patterns/navigationview.md)を使うと、トップレベルのナビゲーションを簡単にアプリに追加できます。 </br>* [ユーザー画像コントロール](../design/controls-and-patterns/person-picture.md)では、人物のアバター画像を表示できます。 </br>* [評価コントロール](../design/controls-and-patterns/rating.md)では、ユーザーが評価の確認と設定を簡単に行うことができます。評価には、コンテンツやサービスに関する満足度が反映されます。
ボイスとトーン | 新しい [UWP アプリでのトーンのボイスに関するガイダンス](../design/style/voice-and-tone.md)が追加され、アプリでテキストを記述するためのアドバイスを提供します。 作成する対象に関係なく、使用する言葉が親しみやすく、友好的で、有益であることが重要です。

## <a name="gaming"></a>ゲーム

機能 | 説明
 :------ | :------
ゲームのブロードキャスト | **[Windows.Media.AppBroadcasting](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting)** 名前空間の新しい API を使うと、システムが提供するゲーム ブロードキャスト UI をアプリが起動できるようになります。 </br>ブロードキャストが開始または停止したときにアプリに通知するイベントを登録することもできます。 **[Windows.Media.AppRecording](https://docs.microsoft.com/uwp/api/windows.media.apprecording)** 名前空間の新しい API を使うと、ゲームプレイのオーディオおよびビデオを録画または録音して画面をキャプチャできます。 </br>システムがブロードキャストに埋め込むメタデータを提供してストリームをキャプチャすることもできるため、アプリはゲームプレイ イベントと同期された表示エクスペリエンスを提供できるようになります。 これらの機能について詳しくは、「[ゲームのブロードキャストとキャプチャ](../gaming/game-broadcast-and-capture.md)」をご覧ください。
ゲーム チャット オーバーレイ | [GameChatOverlay クラス](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamechatoverlay)は、既定のゲーム チャット オーバーレイ インスタンスを取得するメソッド、オーバーレイの目的の位置を設定するメソッド、メッセージを追加するメソッドを提供します。
ゲーム デバイス情報 | さまざまなコンソール機能があるため、ユニバーサル Windows プラットフォーム (UWP) ゲームの開発者には、ハードウェアの最適な使用方法を実行時に選択するため、ゲームが実行されているコンソールの種類を決定する方法が必要です。 **&lt;gamingdeviceinformation.h&gt;** の[ゲーム デバイス情報](https://aka.ms/gamingdeviceinfo) API がこの機能を提供します。
ゲーム モード | ユニバーサル Windows プラットフォーム (UWP) 用の[ゲーム モード](https://msdn.microsoft.com/library/windows/desktop/mt808808) API では、Windows 10 のゲーム モードを利用することで最適化されたゲーム エクスペリエンスを実現できます。 これらの API は **&lt;expandedresources.h&gt;** ヘッダーに含まれています。
ゲーム モニター | [GameMonitor クラス](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamemonitor)を使うと、アプリがデバイスのアクセス許可の状態を監視するゲームを取得し、必要に応じてゲームの監視を有効にするようユーザーに確認できるようになります。
TruePlay | [TruePlay](https://aka.ms/trueplay) は、PC ゲーム内での不正な行為の防止するための新しいツール セットを開発者に提供します。 TruePlay に登録されているゲームは、保護されたプロセスで実行されるため、一般的な種類の攻撃が軽減されます。 ユニバーサル Windows プラットフォーム (UWP) 用の TruePlay API を使うと、Windows 10 PC におけるゲームとゲーム監視システムの間の操作を制限することができます。 これらの API は **&lt;gamemonitor.h&gt;** ヘッダーに含まれています。
Xbox Live | Xbox Live 開発者向けに、UWP ゲームと Xbox 開発キット (XDK) のゲームの両方に関するドキュメントが追加されました。 </br>* 「[Xbox Live 開発者向けガイド](../xbox-live/index.md)」では、Xbox Live API を使ってゲームを Xbox Live ソーシャル ゲーミング ネットワークに接続する方法について説明します。 </br>* [Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を利用すると、UWP ゲーム開発者はだれでも、PC と Xbox One の両方で Xbox Live 対応ゲームを開発して公開できます。 </br>* Xbox Live 開発者向けに提供されているプログラムと機能については、「[Xbox Live 開発者プログラムの概要](../xbox-live/developer-program-overview.md)」をご覧ください。

## <a name="develop-windows-apps"></a>Windows アプリの開発

機能 | 説明
 :------ | :------
UWP アプリのアクティブ化 | 次の新機能が利用可能になりました。 </br>* [StartupTask クラス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.startuptask)を使って、ユーザーがログオンしたとき、またはシステムの起動時に UWP アプリが起動するように指定します。 </br> * UWP アプリが[コマンド ラインから起動](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Activation.ActivationKind)されたかどうかを識別します。 </br>* [RequestRestartAsync() および RequestRestartForUserAsync()](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplication) API を使って UWP アプリを再起動することをプログラムにより要求します。 </br>「* [Windows 設定アプリの起動](../launch-resume/launch-settings-app.md)」が更新され、`ms-settings:storagesense`, `ms-settings:cortana-notifications` などの新しい URI スキームが反映されました。
アプリのパッケージ化 | アプリ インストーラーが拡張され、Web ページから UWP アプリ パッケージをダウンロードできるようになりました。 さらに、関連するアプリ パッケージ セットをアプリ インストーラーと同時にダウンロードできるようになりました。 詳しくは、新しい「[アプリ インストーラーで UWP アプリをインストールする](../packaging/appinstaller-root.md)」をご覧ください。
アプリ サービスと拡張機能 | ユニバーサル Windows プラットフォーム (UWP) アプリの拡張機能を作成してホストすると、Microsoft Store からユーザーがインストールできるパッケージを介してアプリを拡張できるように、新しいガイド「[アプリ拡張機能の作成と利用](../launch-resume/how-to-create-an-extension.md)」を追加しました。 </br></br> アプリの拡張とコンポーネント化に使うことができる Windows 10 のさまざまなテクノロジが分類された、新しいガイド「[Extend your app with services, extensions, and packages](../launch-resume/extend-your-app-with-services-extensions-packages.md)」を追加しました。
バックグラウンド タスク | バックグラウンド タスクの活用に役立つ次の 3 つのガイドを追加しました。</br></br> * [バックグラウンドで無期限に実行する](../launch-resume/run-in-the-background-indefinetly.md): バックグラウンド実行や延長実行の調整を指定せずに、デバイスで利用可能なすべてのリソースを使います。 これは、エンタープライズ UWP アプリと、Microsoft Store に提出されない UWP アプリに適用されます。 </br></br> * [アプリ内からのバックグラウンド タスクのトリガー](../launch-resume/trigger-background-task-from-app.md): アプリ内からバックグラウンド タスクをアクティブ化します。 </br></br>* [UWP アプリが更新された際のバックグラウンド タスクの実行](../launch-resume/run-a-background-task-during-updatetask.md): UWP アプリが更新されたときに実行されるバックグラウンド タスクを作成します。
Cortana | Cortana の自然な機能を拡張し、アプリやサービスと対話させるスキルを追加およびテストするには、[Cortana スキル キット](https://docs.microsoft.com/cortana/skills/overview)を使います。
デスクトップ ブリッジ | Windows 10 のデスクトップ アプリケーションに最新のエクスペリエンスを実装するために役立つ 3 つのガイドが追加されました。 </br>* [Windows 10 向けのデスクトップ アプリを強化する](../porting/desktop-to-uwp-enhance.md): 適切なファイルを見つけて参照し、Windows 10 ユーザーの UWP エクスペリエンスを向上させるコードを記述する方法について説明します。 </br></br>* [最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](../porting/desktop-to-uwp-extend.md): UWP アプリ コンテナーで実行される最新の XAML UI やその他の UWP エクスペリエンスを組み込む方法について説明します。 </br></br>* [アプリケーションをユニバーサル Windows プラットフォームに移行する](../porting/desktop-to-uwp-migrate.md): WPF、Windows フォーム、UWP、Android、および iOS アプリケーション間でコードを共有する方法について説明します。
デスクトップ ブリッジ パッケージ | Visual Studio には、完全に信頼できるデスクトップ アプリケーションのパッケージ化に必要であった手動ステップをすべてなくす新しい[パッケージ プロジェクト](../porting/desktop-to-uwp-packaging-dot-net.md)が導入されています。 パッケージ プロジェクトを追加して、デスクトップ プロジェクトを参照し、F5 キーを押してアプリをデバッグするだけです。 手動で調整する必要はありません。 この新しい効率化されたエクスペリエンスは、以前のバージョンの Visual Studio のエクスペリエンスから大幅に向上しています。
診断とスレッド | 新しい診断 API は、実行中のアプリに関する情報を提供します。 </br></br>* [AppMemoryReport](https://docs.microsoft.com/uwp/api/Windows.System.AppMemoryReport) クラスは、アプリの予想されるコミット制限、プライベート コミット使用量などの情報を提供します。 </br>* [AppDiagnosticInfo](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfo) クラスは、アプリやタスクの実行状態を監視できるようになり、実行状態が変化したときに通知を行います。 </br>* [MemoryManager](https://docs.microsoft.com/uwp/api/windows.system.memorymanager) クラスには、アプリのメモリ使用制限を設定し、予想されるアプリのメモリ使用制限を報告する新しいメソッドがあります。 </br></br>優先度順にタスクをキューに入れ、[DispatcherQueue](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueue) クラスを使って別のスレッドで実行することができます。 この機能は、[CreateDispatcherQueueController](https://msdn.microsoft.com/library/windows/desktop/mt826210.aspx) 関数経由で Win32 から利用することもできます。
EdgeHTML 16 | Microsoft Edge および JS ベースのユニバーサル Windows プラットフォーム アプリに対応する Web プラットフォームは、EdgeHTML 16 に更新され、F12 開発者ツール、CSS グリッド レイアウトのサポート、他の重要な機能が大幅に強化されました。 </br></br> * [CSS グリッド レイアウト](https://docs.microsoft.com/microsoft-edge/dev-guide/css/grid-layout)が Microsoft Edge でサポートされるようになりました。 グリッド レイアウトは、フローティングまたはスクリプトを使って配置するよりもレイアウトの流動性が高いグリッド ベースの 2 次元レイアウト システムを定義します。</br></br> * [Microsoft Edge F12 DevTools ドキュメント](https://docs.microsoft.com/microsoft-edge/f12-devtools-guide)が更新され、堅牢性とパフォーマンスが向上しました。 開発エクスペリエンスを最適化するために新機能も追加されました。 </br></br>* Microsoft Edge 内でのみ、[WebVR](https://docs.microsoft.com/microsoft-edge/webvr/) によって[モーション コントローラー](https://docs.microsoft.com/microsoft-edge/webvr/input#controller-buttons)とさまざまな [Windows Mixed Reality ヘッドセット](https://docs.microsoft.com/microsoft-edge/webvr/hardware)のサポートが追加されました。 さらに、WebVR は最大 1 秒あたりの 90 フレームをサポートするように最適化されています。 </br></br> すべての変更内容と新たにサポートされた API については、[Microsoft Edge 開発者ガイド](https://docs.microsoft.com/microsoft-edge/dev-guide)をご覧ください。
マップの 3D 要素 | 3 次元オブジェクトをマップに追加できます。 新しい [MapModel3D](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapmodel3d) クラスを使って、[3D Manufacturing Format (3MF)](http://3mf.io/specification/) ファイルから 3D オブジェクトをインポートできます。
マップの要素のスタイル設定 | マップの要素の外観をカスタマイズするには、2 つの新しい [MapElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement) プロパティである [MapStyleSheetEntry](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement.MapStyleSheetEntry) と [MapStyleSheetEntryState](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement.MapStyleSheetEntryState) を使います。 </br></br>* [MapStyleSheetEntry](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement.MapStyleSheetEntry) プロパティを使うと、マップの要素の外観をベース マップの一部であるかのようにすることができます (例: マップ スタイル シートで、要素のスタイルを *Water* などの既存のエントリに設定します)。 </br></br>* [MapStyleSheetEntryState](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement.MapStyleSheetEntryState) プロパティを使うと、マップ スタイル シートで *Hover* や *Selected* などの既定の状態を利用してマップの要素の外観を変更したり、それらの状態を上書きして独自の状態を作成したりすることができます。
マップ レイヤー | 対象の要素の点を[マップ レイヤー](../maps-and-location/display-poi.md#layers)に追加し、XAML をそのレイヤーに直接バインドできます。 要素をレイヤーにグループ化します。 その後、各レイヤーを互いに独立して操作することができます。 たとえば、各レイヤーには独自のイベント セットがあるため、特定のレイヤーのイベントに応答し、そのイベントに固有の操作を実行することができます。
マップの場所の情報 | UI 要素またはユーザーがタッチするアプリの領域の上下左右にある[軽量なポップアップ ウィンドウ](../maps-and-location/display-maps.md#placecard)の内部にマップを表示できます。  このウィンドウは、ユーザーがコンテキストを変更すると消えます。 これにより、ユーザーが別のアプリやブラウザー ウィンドウに切り替えて場所に関する情報を取得する必要がなくなります。
マップ サービス | 観光旅行の場合は、 新しい [MapRouteOptimization.Scenic](https://docs.microsoft.com/uwp/api/windows.services.maps.maprouteoptimization) 値を使って最も景色の良い道を通るようにルートを最適化し、[MapRoute.IsScenic](https://docs.microsoft.com/uwp/api/windows.services.maps.maproute) を使って既存のルートに景色の良い道が含まれているかどうかを調べることができます。
メディア キャプチャ | 「[MediaFrameReader を使ったメディア フレームの処理](../audio-video-camera/process-media-frames-with-mediaframereader.md)」が更新され、新しい [MultiSourceMediaFrameReader](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereader) クラスの使用方法が追加されました。このクラスを使うと、複数のメディア ソースから時間相関フレームを取得できます。 </br></br>「[MediaFrameReader を使ったメディア フレームの処理](../audio-video-camera/process-media-frames-with-mediaframereader.md)」が更新され、バッファリングされたフレーム取得モードの説明が追加されました。このモードでは、アプリが前のフレームを処理していたときに取得したフレームを破棄せずに、取得したフレームを順番にアプリに提供することをアプリが要求できます。 </br></br>さらに、1 つ以上のメディア フレーム ソースを含むメディア フレーム ソース グループを使って **MediaCapture** オブジェクトが初期化されると、XAML ページ内の **MediaPlayerElement** コントロールにメディア フレームを表示できるようにする **[MediaSource](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource)** オブジェクトを作成できます。</br></br>詳しくは、「[MediaFrameReader を使ったメディア フレームの処理](../audio-video-camera/process-media-frames-with-mediaframereader.md)」をご覧ください。
メディア再生 | メディア再生の基本について説明する記事に、新しいセクション「[MediaPlayer を使ったオーディオとビデオの再生](../audio-video-camera/play-audio-and-video-with-mediaplayer.md)」が追加されました。 </br></br>* 「[MediaPlayer を使った球面ビデオの再生](../audio-video-camera/play-audio-and-video-with-mediaplayer.md)」セクションでは、球状にエンコードされたビデオの再生方法を示します。サポートされる形式に合わせて視野やビューの向きを調整する方法についても説明しています。 </br></br>* 「[フレーム サーバー モードでの MediaPlayer の使用](../audio-video-camera/play-audio-and-video-with-mediaplayer.md#use-mediaplayer-in-frame-server-mode)」セクションでは、[MediaPlayer](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlayer) で再生されるメディアから Direct3D サーフェスにフレームをコピーする方法を示します。 これにより、ピクセル シェーダーを使ってリアルタイムの効果を適用するといったシナリオを実現できます。 コード例では、Win2D を使ってビデオ再生にぼかし効果を適用する簡単な実装を紹介しています。
マイ連絡先 | マイ連絡先では、ユーザーがアプリケーションから直接、タスク バーに連絡先をピン留めできます。 [アプリケーションにマイ連絡先のサポートを追加する方法については、こちらをご覧ください。](../contacts-and-calendar/my-people-support.md) </br></br>* [マイ連絡先の共有](../contacts-and-calendar/my-people-sharing.md)では、アプリケーションを通じて、ユーザーがタスク バーから直接ファイルを共有できます。 </br>* [マイ連絡先の通知](../contacts-and-calendar/my-people-support.md)は、ピン留めした連絡先にユーザーが通知を送信できる新しい種類のトースト通知です。
.NET Standard 2.0 | ユニバーサル Windows プラットフォームに [.NET Standard 2.0](https://docs.microsoft.com/dotnet/standard/net-standard#net-implementation-support) が完全に実装されました。 この新しいバージョンの標準では、お気に入りの NuGet パッケージとサード パーティ製ライブラリに対する互換性 shim が追加されているだけでなく、.NET API の数が大幅に増えています。 </br></br> iOS や Android などの他のプラットフォームをターゲットとする予定の場合、またはデスクトップ アプリケーションを持っていて UWP アプリを作成したいと思っている場合は、コードを .NET Standard 2.0 クラス ライブラリに移動し、アプリの各バージョンでそのコードを再利用できます。
タスク バーへのピン留め | 新しい TaskbarManager クラスでは、[アプリをタスク バーにピン留め](../design/shell/pin-to-taskbar.md)するようにユーザーに勧めることができます。
POS (店舗販売時点管理) | [POS (店舗販売時点管理) サービス](../devices-sensors/pos-get-started.md)を利用する場合に役立つ新しいガイドが追加されました。 このガイドでは、デバイスの列挙、デバイス機能の確認、デバイスの要求、デバイスの共有といったトピックについて説明します。
音声認識 | Web サービス [SpeechRecognitionTopicConstraint](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechRecognition.SpeechRecognitionTopicConstraint) と共に [SpeechRecognitionListConstraint](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechRecognition.SpeechRecognitionListConstraint) を使って、ディクテーション中に使うと予想されるドメイン固有の一連のキーワードを指定することにより、ディクテーションの精度を上げることができるようになりました。
ユーザー アクティビティ | 新しい [Windows.ApplicationModel.UserActivities](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities) API を使うと、後で再開する可能性がある (場合によっては別のデバイスで) ユーザー タスクをカプセル化できるようになりました。

## <a name="publish--monetize-windows-apps"></a>Windows アプリを公開および収益化する

このセクションの機能は、Windows 1703 の以前のバージョンのリリース以降に追加されました。 これらは、すべての Windows 開発者が利用でき、更新された SDK を必要としません。

機能 | 説明
 :------ | :------
アカウント管理 | [Azure AD テナントとデベロッパー センター アカウントに関連付け](../publish/associate-azure-ad-with-dev-center.md)て複数のアカウント ユーザーを追加するときの柔軟性が向上しました。 複数の Azure AD テナントを 1 つのデベロッパー センターに関連付ける、または、1 つの Azure AD テナントを複数のデベロッパー センター アカウントに関連付けることができます。
広告 | Microsoft Advertising SDK で、アプリ内に[ネイティブ広告](../monetize/native-ads.md)を表示できるようになりました。 ネイティブ広告は、コンポーネント ベースの広告形式で、各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が個々の要素としてアプリに配信されます。 ネイティブ広告は、現在はパイロット プログラムに参加している開発者にのみ提供されますが、まもなくすべての開発者がこの機能を利用できるようになる予定です。
価格と使用可能状況 |  新しい価格と利用可能状況のオプションでは、[価格変更のスケジュール](../publish/set-and-schedule-app-pricing.md)や[正確なリリース日の設定](../publish/configure-precise-release-scheduling.md)を行うことができます。
Store 分析 API | [Microsoft Store 分析 API](../monetize/access-analytics-data-using-windows-store-services.md) に、[アプリのエラーの CAB ファイルをダウンロード](../monetize/download-the-cab-file-for-an-error-in-your-app.md)するために使用できるメソッドが追加されました。
Store 登録情報 | Store 登録情報が、利用を検討しているユーザーを引き付けることができる新機能によって強化されました。 </br>* アプリの Store 登録情報に[ビデオ トレーラー](../publish/app-screenshots-and-images.md#trailers)を含めることができるようになりました。 </br></br>* [Store 登録情報のインポートとエクスポート](../publish/import-and-export-store-listings.md)を使うと、更新にかかる時間を短縮できます。これは特に、登録情報を多数の言語で提供している場合に役立ちます。
申請 API | [Microsoft Store 申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) で、アプリの申請に[ビデオ トレーラー](../monetize/manage-app-submissions.md#trailer-object)や[ゲーム オプション](../monetize/manage-app-submissions.md#gaming-options-object)を含めることができるようになりました。
対象のプラン | [ターゲット オファー](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)では、特定のユーザー セグメントをターゲットに設定し、ユーザーに合わせた魅力的なコンテンツを提供して、エンゲージメント、ユーザー維持率、収益性を高めることができます。

## <a name="samples"></a>サンプル

### <a name="lunch-scheduler"></a>ランチ スケジューラ

[ランチ スケジューラ](https://github.com/Microsoft/Windows-appsample-lunch-scheduler) サンプルでは、友人や同僚とのランチをスケジュールします。 ランチを作成し、興味のあるレストランに友人を招待するだけで、すべての関係者のランチ管理がアプリによって処理されます。 このアプリには次のような特徴があります。

- Facebook や Microsoft Graph などのサービスとの統合による認証、グラフ ベースの操作、友だちの検索をデモンストレーションします。
- Yelp および Bing マップと連動しておすすめのレストランを表示します。
- UWP アプリに、アクリル、表示、接続型アニメーションといった Fluent Design System の要素を取り入れます。

### <a name="quiz-game"></a>クイズ ゲーム

[クイズ ゲーム アプリ (リモート システム セッション API)](https://github.com/microsoft/Windows-appsample-remote-system-sessions) サンプルは、クイズ ゲーム シナリオのコンテキストでリモート システム セッション API を使う方法をデモンストレーションします。 ホストが近接デバイスに質問を送信し、参加者が自分のデバイスで質問に回答します。

リモート システム セッション API により、いずれかのデバイスで、近くにある他のデバイスから検出できるセッションをホストすることが可能になります。 その後、それらのデバイスがこのセッションに参加し、ホストとその他の参加者にメッセージを送信できます。 
