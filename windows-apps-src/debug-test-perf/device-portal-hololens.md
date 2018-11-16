---
author: PatrickFarley
ms.assetid: bf0a8b01-79f1-4944-9d78-9741e235dbe9
title: HoloLens 用 Device Portal
description: HoloLens 用 Windows Device Portal を使って、リモートから HoloLens デバイスの構成と管理を行う方法について説明します。
ms.author: pafarley
ms.date: 09/26/2017
ms.topic: article
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 017a3061fbb72c45bd46ed4e1f134c022284ecfe
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6837503"
---
# <a name="device-portal-for-hololens"></a>HoloLens 用 Device Portal


## <a name="set-up-device-portal-on-hololens"></a>HoloLens で Device Portal をセットアップする

### <a name="enable-device-portal"></a>Device Portal を有効にする

1. HoloLens の電源を入れ、デバイスを装着します。
2. [ブルーム](https://dev.windows.com/holographic/Gestures.html#Bloom) ジェスチャを実行して、メイン メニューを開きます。
3. **[Settings]** (設定) タイルを見つめて、[エア タップ](https://dev.windows.com/holographic/Gestures.html#Press_and_release) ジェスチャを実行します。 2 回目のエア タップを実行して、アプリを環境内に配置します。 配置すると、設定アプリが起動します。
4. **[Update]** (更新) メニュー項目を選択します。
5. **[For developers]** (開発者向け) メニュー項目を選択します。
6. **[Developer Mode]** (開発者モード) を有効にします。
7. [下へスクロール](https://dev.windows.com/holographic/Gestures.html#Navigation) し、Device Portal を有効にします。


### <a name="pair-your-device"></a>デバイスをペアリングする

#### <a name="connect-over-wi-fi"></a>Wi-Fi 経由で接続する 

1. HoloLens を Wi-Fi に接続します。
2. デバイスの IP アドレスを調べます。デバイスで、[Settings] (設定)、[Network & Internet] (ネットワークとインターネット)、[Wi-Fi]、[Advanced Options] (詳細オプション) の順に移動して IP アドレスを確認します。
    または、「Hey Cortana, what is my IP address?」 (コルタナさん、IP アドレスを教えて) のようにたずねることもできます。

3. PC 上の Web ブラウザーから、 にアクセスします。 `https://<YOUR_HOLOLENS_IP_ADDRESS>`
    - ブラウザーから、"この Web サイトのセキュリティ証明書に問題があります" というメッセージが表示されます。 これは、Device Portal に発行された証明書がテスト証明書であるためです。 ここでは、この証明書エラーを無視して続行できます。

#### <a name="connect-over-usb"></a>USB 経由で接続する 

1. PC に Visual Studio Update 1 と Windows 10 開発者ツールをインストールします。 これで USB 接続が有効になります。
2. マイクロ USB ケーブルを使って HoloLens を PC に接続します。
3. PC 上の Web ブラウザーから、`http://127.0.0.1:10080` にアクセスします。

> [!IMPORTANT]
> お使いの PC がデバイスを検出することでない場合、HoloLens デバイスの実際のネットワークの IP アドレスを使用してみてくださいなく`http://127.0.0.1:10080`します。

#### <a name="connect-to-an-emulator"></a>エミュレーターに接続する 

Device Portal はエミュレーターで使うこともできます。 Device Portal に接続するには、ツール バーを使います。 次のアイコンをクリックします。
- [Open Device Portal] (Device Portal を開く): エミュレーターで HoloLens OS の Windows Device Portal を開きます。

#### <a name="create-a-username-and-password"></a>ユーザー名とパスワードを作成する 

HoloLens で初めて Device Portal に接続するときは、ユーザー名とパスワードを作成する必要があります。
1. PC 上の Web ブラウザーで、HoloLens の IP アドレスを入力します。 [Set up access] (アクセスのセットアップ) ページが開きます。
2. [Request pin] (PIN の要求) をクリックまたはタップし、生成された PIN を HoloLens のディスプレイで確認します。
3. [PIN displayed on your device] (デバイスに表示された PIN) テキスト ボックスに PIN を入力します。
4. Device Portal への接続に使うユーザー名を入力します。 Microsoft アカウント (MSA) 名やドメイン アカウント名を指定する必要はありません。
5. パスワードを入力し、確認用にもう一度入力します。 パスワードは 7 文字以上にする必要があります。 MSA やドメインのパスワードと同じにする必要はありません。
6. [Pair] (ペアリング) をクリックして、HoloLens の Windows Device Portal に接続します。

このユーザー名またはパスワードは、デバイスのセキュリティ ページでこの手順を繰り返すことでいつでも変更できます。デバイスのセキュリティ ページを表示するには、右上にある [Security] (セキュリティ) リンクをクリックするか、`https://<YOUR_HOLOLENS_IP_ADDRESS>/devicesecurity.htm` にアクセスします。

#### <a name="security-certificate"></a>セキュリティ証明書 

ブラウザーで "証明書エラー" が表示される場合は、デバイスとの信頼関係を作成することで修正できます。

ぞれぞれの HoloLens では、SSL 接続用に一意の自己署名証明書が生成されます。 既定では、この証明書が PC の Web ブラウザーによって信頼されていないため、"証明書エラー" が発生することがあります。 この証明書を HoloLens から (USB または信頼している Wi-Fi ネットワーク経由で) ダウンロードし、PC で信頼すると、デバイスに安全に接続できます。
1. 安全なネットワーク (USB または信頼している Wi-Fi ネットワーク) に接続していることを確認します。
2. Device Portal の [Security] (セキュリティ) ページから、このデバイスの証明書をダウンロードします。ページを表示するには、右上にあるアイコンの一覧で [Security] (セキュリティ) リンクをクリックするか、 にアクセスします。 `https://<YOUR_HOLOLENS_IP_ADDRESS>/devicesecurity.htm`

3. PC の [信頼されたルート証明機関] ストアに証明書をインストールします。Windows メニューから「コンピューター証明書の管理」と入力し、アプレットを起動します。
    - [信頼されたルート証明機関] フォルダーを展開します。
    - [証明書] フォルダーをクリックします。
    - [操作] メニューの [すべてのタスク] をクリックし、[インポート] をクリックします。
    - Device Portal からダウンロードした証明書ファイルを使って、証明書のインポート ウィザードを完了します。

4. ブラウザーを再起動します。


## <a name="device-portal-pages"></a>Device Portal のページ 

### <a name="home"></a>Home (ホーム) 

Device Portal セッションは Home (ホーム) ページから始まります。 他のページにアクセスするには、ホーム ページの左側にあるナビゲーション バーを使います。

ページの最上部にあるツール バーでは、よく使われる状態や機能にアクセスできます。
- **[Online]** (オンライン): デバイスが Wi-Fi に接続しているかどうかを示します。
- **[Shutdown]** (シャットダウン): デバイスをオフにします。
- **[Restart]** (再起動): デバイスの電源を入れ直します。
- **[Security]** (セキュリティ): [Device Security] (デバイスのセキュリティ) ページを開きます。
- **[Cool]** (低温): デバイスの温度を示します。
- **[A/C]**: デバイスが電源に接続され、充電されているかどうかを示します。
- **[Help]** (ヘルプ): REST インターフェイスのドキュメント ページを開きます。

ホーム ページには次の情報が表示されます。
- **[Device** Status] (デバイスの状態): デバイスの正常性を監視し、重大なエラーを報告します。
- **[Windows information]** (Windows の情報): HoloLens の名前と、現在インストールされている Windows のバージョンを表示します。
- **[Preferences]** (設定) セクションには次の設定が含まれます。
    - **[IPD]**: 瞳孔間距離 (IPD) を設定します。これは、ユーザーがまっすぐ前を向いたときの瞳孔の中心間の距離をミリメートル単位で示すものです。 設定はすぐに反映されます。 既定値は、デバイスのセットアップ時に自動的に計算された値です。
    - **[Device name]** (デバイス名): HoloLens に名前を割り当てます。 この値を変更した場合、変更を有効にするにはデバイスを再起動する必要があります。 [Save] (保存) をクリックすると、デバイスを今すぐ再起動するか、後で再起動するかをたずねるダイアログが表示されます。
    - **[Sleep settings]** (スリープの設定): デバイスが電源に接続されているときとバッテリで動作しているときの、スリープ状態に移行するまでの待ち時間の長さを設定します。

### <a name="3d-view"></a>3D View (3D ビュー) 

[3D View] (3D ビュー) ページを使うと、HoloLens がどのように周囲を解釈するかを確認できます。 ビュー内を移動するには、マウスを次のように使います。
- **回転**: 左クリック + マウス
- **パン**: 右クリック + マウス
- **ズーム**: マウス スクロール。
- **[Tracking options]** (追跡オプション): [Force visual tracking] (視覚追跡を強制) をオンにすると、連続的な視覚追跡が有効になります。 [Pause] (一時停止) は視覚追跡を停止します。
- **[View options]** (表示オプション): 3D ビューのオプションを設定します。- [Tracking] (追跡): 視覚追跡がアクティブかどうかを示します。
- **[Show floor]** (フロアを表示): チェック模様のフロア平面を表示します。
- **[Show frustum]** (視錐台を表示): 視錐台を表示します。
- **[Show stabilization plane]** (手ブレ補正平面を表示): HoloLens でモーションの手ブレ補正用に使われる平面を表示します。
- **[Show mesh]** (メッシュを表示): 周囲を表すサーフェス マッピング メッシュを表示します。
- **[Show details]** (詳細を表示): 手の位置、頭部の回転の四元数、デバイスの原点のベクトルを、動きに合わせてリアルタイムで表示します。
- **[Full screen]** (全画面表示) ボタン: 3D ビューを全画面表示モードで表示します。 Esc キーを押すと全画面表示を終了します。

- [Surface reconstruction] (サーフェスの認識): [Update] (更新) をクリックまたはタップすると、デバイスから最新の空間マッピング メッシュを表示します。 全体の処理が完了するまでには、最大で数秒かかる可能性があります。 3D ビューではメッシュは自動的に更新されないため、デバイスから最新のメッシュを取得するには、手動で [Update] (更新) をクリックする必要があります。 [Save] (保存) をクリックすると、現在の空間マッピング メッシュを obj ファイルとして PC に保存します。

### <a name="mixed-reality-capture"></a>Mixed Reality Capture (複合現実キャプチャ) 

[Mixed Reality Capture] (複合現実キャプチャ) ページを使うと、HoloLens からメディア ストリームを保存できます。
- 設定: 次の設定をオンにして、キャプチャするメディア ストリームを制御します。- [Holograms] (ホログラム): ビデオ ストリームのホログラフィック コンテンツをキャプチャします。 ホログラムは、ステレオではなくモノラルでレンダリングされます。
- **[PV camera]** (PV カメラ): 写真/ビデオ カメラからビデオ ストリームをキャプチャします。
- **[Mic Audio]** (マイク オーディオ): マイク配列からオーディオをキャプチャします。
- **[App Audio]** (アプリ オーディオ): 現在実行中のアプリからオーディオをキャプチャします。
- **[Live preview quality]** (ライブ プレビューの品質): ライブ プレビューの画面解像度、フレーム レート、ストリーミング レートを選択します。

- [Live preview] (ライブ プレビュー) ボタンをクリックまたはタップすると、キャプチャ ストリームを表示します。 [Stop live preview] (ライブ プレビューの停止) は、キャプチャ ストリームを停止します。
- [Record] (記録) をクリックまたはタップすると、指定された設定を使って複合現実ストリームのレコーディングを開始します。 [Stop recording] (記録の終了) は、レコーディングを終了して保存します。
- [Take photo] (写真の撮影) をクリックまたはタップすると、キャプチャ ストリームから静止画像を取得します。
- **[Videos and photos]** (ビデオと写真): デバイスで取得されたビデオと写真のキャプチャの一覧を表示します。

Device Portal からライブ プレビューを記録またはストリーミングしている間、HoloLens アプリでは MRC の写真やビデオをキャプチャできないことに注意してください。

### <a name="system-performance"></a>System Performance (システム パフォーマンス) 

HoloLens の System Performance (システム パフォーマンス) ツールでは、3 つの追加のメトリックを記録できます。 

利用可能なメトリックを次に示します。
- **[SoC power]** (SoC 電力): System on a Chip の瞬間的な電力使用量 (1 秒あたりの平均)
- **[System power]** (システム電力): システムの瞬間的な電力使用量 (1 秒あたりの平均)
- **[Frame rate]** (フレーム レート): 1 秒あたりのフレーム数、1 秒あたりに失敗した VBlank 数、連続で失敗した VBlank 数

### <a name="app-crash-dumps-page"></a>App Crash Dumps (アプリのクラッシュ ダンプ) ページ 

このページでは、サイドローディングしたアプリのクラッシュ ダンプを収集できます。 クラッシュ ダンプを収集する各アプリについて、[Crash Dumps Enabled] (クラッシュ ダンプ有効) チェック ボックスをオンにします。 後でこのページに戻ると、クラッシュ ダンプが収集されています。 ダンプ ファイルは、デバッグ用に Visual Studio で開くことができます。

### <a name="kiosk-mode"></a>Kiosk Mode (キオスク モード) 

キオスク モードを有効にします。キオスク モードではユーザーの操作が制限され、新しいアプリを起動したり、実行中のアプリを変更したりすることができなくなります。 キオスク モードを有効にすると、ブルーム ジェスチャと Cortana は無効になり、配置済みのアプリもユーザーの周囲に表示されなくなります。

[Enable Kiosk Mode] (キオスク モードを有効にする) をオンにすると、HoloLens がキオスク モードになります。 [Startup app] (スタートアップ アプリ) ドロップダウンで、起動時に実行するアプリを選択します。 設定を決定するには、[Save] (保存) をクリックまたはタップします。

選択したアプリは、キオスク モードが有効になっていない場合でも起動時に実行されます。 起動時にアプリが実行されないようにするには、[None] (なし) を選択します。

### <a name="simulation"></a>Simulation (シミュレーション) 

テスト用に入力データを記録して再生できます。
- **[Capture room]** (ルームのキャプチャ): シミュレートされたルーム ファイルをダウンロードするために使います。このファイルには、ユーザーの周囲の空間マッピング メッシュが含まれます。 ルームに名前を付けて [Capture] (キャプチャ) をクリックすると、データが .xef ファイルとして PC に保存されます。 このルーム ファイルは、HoloLens エミュレーターに読み込むことができます。
- **[Recording]** (レコーディング): レコーディングを開始します。記録するストリームをオンにし、レコーディングに名前を付けて、[Record] (記録) をクリックまたはタップします。 HoloLens でアクションを実行した後、[Stop] (停止) をクリックすると、データが .xef ファイルとして PC に保存されます。 このファイルは、HoloLens エミュレーターまたはデバイスで読み込むことができます。
- **[Playback]** (再生): [Upload recording] (レコーディングのアップロード) をクリックまたはタップし、PC から xef ファイルを選択して、そのデータを HoloLens に送信します。
- **[Control mode]** (制御モード): HoloLens のモードを選択します。ドロップダウンから [Default] (既定) または [Simulation] (シミュレーション) を選択し、[Set] (設定) ボタンをクリックまたはタップします。 [Simulation] (シミュレーション) を選ぶと、HoloLens の実際のセンサーは無効になり、アップロードされたシミュレーション データが代わりに使われます。 [Simulation] (シミュレーション) に切り替えると、[Default] (既定) に戻すまで、HoloLens は実際のユーザーに応答しなくなります。


### <a name="virtual-input"></a>Virtual Input (仮想入力) 

リモート コンピューターから HoloLens にキーボード入力を送信します。

[Virtual keyboard] (仮想キーボード) の下にある領域をクリックまたはタップすると、HoloLens にキー入力を送信できるようになります。 [Input text] (テキストの入力) テキスト ボックスに入力し、[Send] (送信) をクリックまたはタップすると、アクティブなアプリにキー入力が送信されます。

## <a name="see-also"></a>関連項目

* [Windows Device Portal の概要](device-portal.md)
* [デバイス ポータル コア API リファレンス](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)(すべての Windows 10 デバイスに共通する API)
* [デバイス ポータル Mixed Reality API リファレンス](https://docs.microsoft.com/windows/mixed-reality/device-portal-api-reference)(HoloLens で利用できるすべての REST API の拡張リスト)