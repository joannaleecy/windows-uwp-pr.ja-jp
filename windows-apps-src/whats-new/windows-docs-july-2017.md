---
author: QuinnRadich
title: Windows ドキュメントの最新情報、2017 年 7 月 - UWP アプリの開発
description: 2017 年 7 月版の Windows 10 開発者向けドキュメントには、新しい機能、サンプル、開発者向けガイダンスが追加されました
keywords: 最新情報, 更新, 機能, 開発者向けガイダンス, Windows 10
ms.author: quradic
ms.date: 07/05/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: e439c0b1c20f03c9519d29a24979e5008f3de94e
ms.sourcegitcommit: 1eabcf511c7c7803a19eb31f600c6ac4a0067786
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1691841"
---
# <a name="whats-new-in-the-windows-developer-docs-in-july-2017"></a>Windows 開発者向けドキュメントの最新情報、2017 年 7 月

Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。 ここに示す機能概要、開発者向けガイダンス、コード サンプルは最近公開されたもので、Windows 開発者向けの新しい情報や更新情報を含んでいます。

Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/your-first-app.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

## <a name="features"></a>機能

### <a name="fluent-design"></a>Fluent Design

次の効果は、[Windows Insider](https://insider.windows.com/) を対象に SDK Preview Build で提供されます。これらの新しい効果は、深度、視点、動きを使って、重要な UI 要素にユーザーが集中できるようにします。

[アクリル素材](../design/style/acrylic.md)は、透明なテクスチャを作成できる、ブラシの種類の 1 つです。 

![淡色テーマのアクリル](../design/style/images/Acrylic_DarkTheme_Base.png)

[視差効果](../design/motion/parallax.md)を使用すると、3 次元の深度と視点をアプリに追加できます。

![リストと背景画像を使用した視差の例](../design/style/images/_Parallax_v2.gif)

[表示](../design/style/reveal.md)を使用すると、アプリの重要な要素を強調できます。 

![表示のビジュアル効果](../design/style/images/Nav_Reveal_Animation.gif)

### <a name="ui-controls"></a>UI コントロール

次のコントロールは、[Windows Insider](https://insider.windows.com/) を対象に SDK Preview Build で提供されます。これらの新しいコントロールを使うと、優れた外観の UI をすばやく簡単に作成できます。

[カラー ピッカー コントロール](../design/controls-and-patterns/color-picker.md)では、ユーザーが色を自由に確認しながら選択できます。  

![既定のカラー ピッカー](../design/controls-and-patterns/images/color-picker-default.png)

[ナビゲーション ビュー コントロール](../design/controls-and-patterns/navigationview.md)を使うと、トップレベルのナビゲーションを簡単にアプリに追加できます。

![ナビゲーション ビューのセクション](../design/controls-and-patterns/images/navview_sections.png)

[ユーザー画像コントロール](../design/controls-and-patterns/person-picture.md)では、人物のアバター画像を表示できます。

![ユーザー画像コントロール](../design/controls-and-patterns/images/person-picture/person-picture_hero.png)

[評価コントロール](../design/controls-and-patterns/rating.md)では、ユーザーが評価の確認と設定を簡単に行うことができます。評価には、コンテンツやサービスに関する満足度が反映されます。

![評価コントロールの例](../design/controls-and-patterns/images/rating_rs2_doc_ratings_intro.png)

### <a name="design-toolkits"></a>設計ツールキット

[UWP アプリ用の設計ツールキットとリソース](../design/downloads/index.md)が拡張され、スケッチ ツールキットと Adobe XD ツールキットが追加されました。 既存のツールキットも刷新され、より堅牢なコントロールとレイアウト テンプレートが UWP アプリに提供されます。

### <a name="dashboard-monetization-and-store-services"></a>ダッシュボード、収益化、ストア サービス

次の新機能が利用可能になりました。

* Microsoft Advertising SDK で、アプリ内に[ネイティブ広告](../monetize/native-ads.md)を表示できるようになりました。 ネイティブ広告は、コンポーネント ベースの広告形式で、各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が個々の要素としてアプリに配信されます。 ネイティブ広告は、現在はパイロット プログラムに参加している開発者にのみ提供されますが、まもなくすべての開発者がこの機能を利用できるようになる予定です。

* [Microsoft Store 分析 API](../monetize/access-analytics-data-using-windows-store-services.md) に、[アプリのエラーの CAB ファイルをダウンロード](../monetize/download-the-cab-file-for-an-error-in-your-app.md)するために使用できるメソッドが追加されました。

* [ターゲット オファー](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)では、特定のユーザー セグメントをターゲットに設定し、ユーザーに合わせた魅力的なコンテンツを提供して、エンゲージメント、ユーザー維持率、収益性を高めることができます。 

* アプリのストア登録情報に[ビデオ トレーラー](../publish/app-screenshots-and-images.md#trailers)を含めることができるようになりました。

* 新しい価格と利用可能状況のオプションでは、[価格変更のスケジュール](../publish/set-and-schedule-app-pricing.md)や[正確なリリース日の設定](..//publish/configure-precise-release-scheduling.md)を行うことができます。

* [ストア登録情報のインポートとエクスポート](../publish/import-and-export-store-listings.md)を使うと、更新にかかる時間を短縮できます。これは特に、登録情報を多数の言語で提供している場合に役立ちます。

### <a name="my-people"></a>マイ連絡先

[Windows Insider](https://insider.windows.com/) を対象に SDK Preview Build で提供されるマイ連絡先機能を使うと、アプリケーションからユーザーのタスク バーに連絡先を直接ピン留めすることができます。 [アプリケーションにマイ連絡先のサポートを追加する方法については、こちらをご覧ください。](../contacts-and-calendar/my-people-support.md)

![マイ連絡先の連絡先パネル](images/my-people.png)

[マイ連絡先の共有](../contacts-and-calendar/my-people-sharing.md)では、アプリケーションを通じて、ユーザーがタスク バーから直接ファイルを共有できます。

![マイ連絡先の共有](images/my-people-sharing.png)

[マイ連絡先の通知](../contacts-and-calendar/my-people-support.md)は、ピン留めした連絡先にユーザーが通知を送信できる新しい種類のトースト通知です。

![マイ連絡先の通知](images/my-people-notification.png)

### <a name="pin-to-taskbar"></a>タスク バーにピン留め

[Windows Insider](https://insider.windows.com/) を対象に SDK Preview Build で提供される新しい TaskbarManager クラスでは、[アプリをタスク バーにピン留めする](../design/shell/pin-to-taskbar.md)ようにユーザーに勧めることができます。

## <a name="developer-guidance"></a>開発者向けガイダンス

### <a name="media-playback"></a>メディア再生

メディア再生の基本について説明する記事に、新しいセクション「[MediaPlayer を使ったオーディオとビデオの再生](../audio-video-camera/play-audio-and-video-with-mediaplayer.md)」が追加されました。 「[MediaPlayer を使った球面ビデオの再生](../audio-video-camera/play-audio-and-video-with-mediaplayer.md)」セクションでは、球状にエンコードされたビデオの再生方法を示します。サポートされる形式に合わせて視野やビューの向きを調整する方法についても説明しています。 「[フレーム サーバー モードでの MediaPlayer の使用](../audio-video-camera/play-audio-and-video-with-mediaplayer.md#use-mediaplayer-in-frame-server-mode)」セクションでは、[MediaPlayer](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlayer) で再生されるメディアから Direct3D サーフェスにフレームをコピーする方法を示します。 これにより、ピクセル シェーダーを使ってリアルタイムの効果を適用するといったシナリオを実現できます。 コード例では、Win2D を使ってビデオ再生にぼかし効果を適用する簡単な実装を紹介しています。

### <a name="media-capture"></a>メディア キャプチャ

「[MediaFrameReader を使ったメディア フレームの処理](../audio-video-camera/process-media-frames-with-mediaframereader.md)」が更新され、新しい [MultiSourceMediaFrameReader](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereader) クラスの使用方法が追加されました。このクラスを使うと、複数のメディア ソースから時間相関フレームを取得できます。 これは、深度カメラやカラー カメラなどのさまざまなソースからのフレームを処理する必要があり、各ソースからのフレームが時間的に近くなるようにキャプチャする必要がある場合に便利です。 詳しくは、[MultiSourceMediaFrameReader を使った複数のソースからの時間相関フレームの取得](../audio-video-camera/process-media-frames-with-mediaframereader.md#use-multisourcemediaframereader-to-get-time-corellated-frames-from-multiple-sources)に関するセクションをご覧ください。

### <a name="scoped-search"></a>スコープを指定した検索

docs.microsoft.com の [UWP の概念](../get-started/universal-application-platform-guide.md)と [API リファレンス](https://docs.microsoft.com/en-us/uwp/api/)のドキュメントに、"UWP" というスコープが追加されました。このスコープを非アクティブ化しない限り、これらの領域から検索を行うと UWP のドキュメントだけが返されます。

![スコープを指定した検索](images/scoped-search.png)

### <a name="test-your-windows-app-for-windows-10-s"></a>Windows アプリの Windows 10 S 対応のテスト

Windows アプリをテストして、Windows S を実行するデバイスで正しく動作することを確認します。方法については、[新しいガイド](../porting/desktop-to-uwp-test-windows-s.md)をご覧ください。 

## <a name="samples"></a>サンプル

### <a name="annotated-audio-app-sample"></a>注釈付きオーディオ アプリのサンプル

[オーディオ、インク、OneDrive データ ローミングのシナリオを紹介するミニ アプリのサンプル](https://github.com/Microsoft/Windows-appsample-annotated-audio)です。 このサンプルでは、オーディオを録音しながらインク注釈を同期的キャプチャする例を示します。これにより、メモを取ったときに何が議論されていたかを後で思い出すことができます。

![注釈付きオーディオ アプリのサンプルのスクリーンショット](images/Playback.png)  

### <a name="shopping-app-sample"></a>ショッピング アプリのサンプル

[ユーザーが絵文字を購入できる基本的なショッピング エクスペリエンスを提供するミニ アプリ](https://github.com/Microsoft/Windows-appsample-shopping)です。 このアプリは、[支払い要求 API](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments) を使ってチェックアウト処理を実装する方法を示しています。

![ショッピング アプリのサンプルのスクリーンショット](images/shoppingcart.png)  

## <a name="videos"></a>ビデオ

### <a name="accessibility"></a>アクセシビリティ

アプリにアクセシビリティ機能を組み込むと、より幅広いユーザー層をターゲットにすることができます。 まずは[ビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Developing-Apps-for-Accessibility)をご覧になってから、「[アクセシビリティのためのアプリ開発](https://developer.microsoft.com/en-us/windows/accessible-apps)」で詳細を確認してください。

### <a name="payments-request-api"></a>支払い要求 API

支払い要求 API は、顧客と販売者がオンライン チェック アウト プロセスをシームレスに完了できるように支援します。 まずは[ビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-the-Payments-Request-API)をご覧になってから、[支払い要求のドキュメント](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-the-Payments-Request-API)で詳細を確認してください。

### <a name="windows-10-iot-core"></a>Windows 10 IoT Core

Windows 10 IoT Core とユニバーサル Windows プラットフォームを利用すると、視覚情報とコンポーネントを連携させるプロジェクトのプロトタイプ作成と構築をすばやく行うことができます。たとえば、ペットを認識して開閉するドアを実現できます。 まずは[ビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Building-a-Pet-Recognition-Door-Using-Windows-10-IoT-Core)をご覧になってから、[Windows 10 IoT Core を使い始める](https://developer.microsoft.com/en-us/windows/iot)方法の詳細を確認してください。