---
author: PatrickFarley
ms.assetid: bf0a8b01-79f1-4944-9d78-9741e235dbe9
title: Xbox 用 Device Portal
description: Xbox One 向けの Device Portal を有効にする方法について説明します。
ms.author: pafarley
ms.date: 02/12/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 404db3963d2f9508d7c81053abf96b0e742103f7
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2910313"
---
# <a name="device-portal-for-xbox"></a>Xbox 用 Device Portal

## <a name="set-up-device-portal-on-xbox"></a>Xbox で Device Portal をセットアップする

以下の手順では、開発用 Xbox へのリモート アクセスを提供する Xbox Device Portal を有効にする方法を示します。

1. Dev Home を開きます。 これは開発用 Xbox の起動時に既定で開きますが、ホーム画面からも開くこともできます。

    ![Device Portal の DevHome](images/device-portal-xbox-1.png)

2. Dev Home 内で、**[ホーム]** タブの **[リモート アクセス]** の下で、**[リモート アクセス設定]** を選択します。

    ![Device Portal の RemoteManagement ツール](images/device-portal-xbox-15.png)

3. **[Enable Xbox Device Portal]** (Xbox Device Portal を有効にする) 設定をオンにします。

4. **[認証]** で **[Set username and password]** (ユーザー名とパスワードの設定) を選択します。 ブラウザーから dev kit へのアクセスを認証するために使う **[ユーザー名]** と **[パスワード]** を入力し、**[保存]** します。

5. **[リモート アクセス]** ページの **[閉じる]** を選択し、**[ホーム]** タブの **[リモート アクセス]** の下に表示される URL を書き留めます。

6. その URL をブラウザーに入力し、構成した資格情報でサインインします。

7. 提供された証明書に関して、次の図のような警告が表示されます。 Edge で **[詳細]** をクリックし、**[Go on to the webpage]** (Web ページにアクセス) をクリックして、Xbox Device Portal にアクセスします。 表示されるダイアログで、前に Xbox に入力したユーザー名とパスワードを入力します。

    ![Device Portal の証明書エラー](images/device-portal-xbox-3.png)

## <a name="device-portal-pages"></a>Device Portal のページ

Xbox Device Portal では、Windows Device Portal で入手可能なものと同様の一連の標準的なページと共に、いくつかの固有のページが提供されます。 標準的なページについて詳しくは、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。 以下のセクションでは、Xbox Device Portal に固有のページについて説明します。

### <a name="home"></a>ホーム

Windows Device Portal の **[アプリ マネージャー]** ページと同様に、Xbox Device Portal の **[ホーム]** ページでは、**[マイ コレクション]** の下にインストールされているゲームとアプリの一覧が表示されます。 ゲームまたはアプリの名前をクリックして、その詳細を表示できます (**[パッケージ ファミリ名]** など)。 **[操作]** ドロップダウンで、ゲームまたはアプリに対して **[起動]** などの操作を行うことができます。

**[Xbox Live テスト アカウント]** で、お使いの Xbox に関連付けられているアカウントを管理することができます。 ユーザーとゲスト アカウントの追加、新しいユーザーの作成、ユーザーのサインインとサインアウト、アカウントの削除を行うことができます。

![ホーム](images/device-portal-xbox-16.png)

### <a name="xbox-live-game-saves"></a>Xbox Live (セーブ データ)

Windows Device Portal と Xbox Device Portal のいずれにも **[Xbox Live]** ページがあります。 ただし、Xbox Device Portal には独自のセクション、**[Xbox Live セーブ データ]** があります。このセクションで、Xbox にインストールされているゲームのデータを保存することができます。 タイトルとセーブ データに関連付けられた **[サービス構成 ID (SCID)]** (詳しくは、「[Xbox Live サービス構成](../xbox-live/xbox-live-service-configuration.md#get-your-ids)」を参照)、**[メンバー名 (MSA)]**、および **[パッケージ ファミリ名 (PFN)]** を入力し、**[入力ファイル (.json または .xml)]** を参照して、セーブ データを操作するためにいずれかのボタン (**[リセット]**、**[インポート]**、**[エクスポート]**、**[削除]**) を選択します。

**[生成]** セクションで、ダミー データを生成し、指定した入力ファイルに保存できます。 **[コンテナー (既定値は 2)]**、**[BLOB (既定値は 3)]**、および **[BLOB サイズ (既定値は 1024)]** を入力し、**[生成]** を選択するだけです。

![Xbox Live](images/device-portal-xbox-17.png)

### <a name="http-monitor"></a>HTTP モニター

HTTP モニターを使うと、アプリやゲームが Xbox One で実行されているときに、それらからの暗号化が解除された HTTP および HTTPS トラフィックを表示することができます。

![HTTP モニター](images/device-portal-xbox-18.png)

有効にするには、Xbox One で Dev Home を開き、**[設定]** タブに移動して、**[HTTP Monitor Settings]** (HTTP モニターの設定) で **[Enable HTTP Monitor]** (HTTP モニターを有効にする) をオンにします。

![Dev Home: ネットワーキング](images/device-portal-xbox-14.png)

有効にすると、Xbox Device Portal でそれぞれのボタンを選択することで、HTTP および HTTPS トラフィックを **[停止]**、**[クリア]**、および **[ファイルに保存]** することができます。

### <a name="network-fiddler-tracing"></a>ネットワーク (Fiddler のトレース)

Xbox Device Portal の **[ネットワーク]** ページは Windows Device Portal の **[ネットワーク]** ページとほぼ同じですが、**[Fiddler のトレース]** は例外で、Xbox Device Portal に固有のものです。 これにより、PC で Fiddler を実行して、Xbox One とインターネットの間の HTTP および HTTPS トラフィックログに記録し、検査することができます。 詳しくは、「[UWP を開発するときに、Xbox One で Fiddler を使用する方法](../xbox-apps/uwp-fiddler.md)」をご覧ください。

![ネットワーク](images/device-portal-xbox-19.png)

### <a name="media-capture"></a>メディアのキャプチャ

**[メディアのキャプチャ]** ページで、**[スクリーンショットをキャプチャする]** を選択して Xbox One のスクリーン ショットを撮ることができます。 撮影すると、ファイルをダウンロードするよう求められます。 HDR でスクリーン ショットを撮る場合は (本体でサポートされている場合)、**[Prefer HDR]** (HDR 優先) をオンにできます。

![メディアのキャプチャ](images/device-portal-xbox-12.png)

### <a name="settings"></a>設定

**[設定]** ページで、Xbox One のいくつかの設定を表示および編集することができます。 上部で、**[インポート]** を選択してファイルから設定をインポートし、**[エクスポート]** を選択して現在の設定を .txt ファイルにエクスポートすることができます。 設定をインポートすると、一括編集が簡単になり、特に複数の本体を構成するときに役に立ちます。 インポートする設定ファイルを作成するには、必要に応じて設定を変更してから、設定をエクスポートします。 その後、このファイルを使用して、他の本体用に設定を迅速かつ簡単にインポートすることができます。

さまざまな設定があり、表示/編集するためのセクションがいくつかあります。これらについて以下で説明します。

![設定](images/device-portal-xbox-20.png)

![設定](images/device-portal-xbox-21.png)

#### <a name="device-information"></a>デバイス情報

* **デバイス名**: デバイスの名前。 編集するには、ボックス内で名前を変更し、**[保存]** を選択します。

* **OS バージョン**: 読み取り専用。 オペレーティング システムのバージョン番号。

* **OS エディション**: 読み取り専用。 オペレーティング システムのメジャー リリースの名前。

* **Xbox Live デバイス ID**: 読み取り専用。

* **本体の ID**: 読み取り専用。

* **シリアル番号**: 読み取り専用。

* **本体の種類**: 読み取り専用。 Xbox One デバイスの種類 (Xbox One、Xbox One S、または Xbox One X)。

* **開発モード**: 読み取り専用。 デバイスに適用されている開発者モード。

#### <a name="audio-settings"></a>オーディオ設定

* **オーディオ ビットストリーム形式**: オーディオ データの形式。

* **HDMI オーディオ**: HDMI ポートを経由するオーディオの種類。

* **ヘッドセット形式**: ヘッドフォンを経由するオーディオの形式。

* **光デジタル オーディオ**: 光ポートを経由するオーディオの種類。

* **Use HDMI or optical audio headset** (HDMI または光デジタル オーディオ ヘッドセットを使用する): HDMI 経由または光経由で接続されたヘッドセットを使用している場合、このボックスをオンにします。

#### <a name="display-settings"></a>ディスプレイの設定

* **色深度**: 単一ピクセルの各カラー成分で使用されるビット数。

* **色空間**: ディスプレイで使用可能な色域。

* **ディスプレイの解像度**: ディスプレイの解像度。

* **Display connection** (ディスプレイの接続): ディスプレイへの接続の種類。

* **Allow high dynamic range (HDR)** (ハイ ダイナミック レンジ (HDR) を使用する): ディスプレイで HDR を有効にします。 互換性のあるディスプレイでのみ使用できます。

* **4K を許可**: ディスプレイで 4K 解像度を有効にします。 互換性のあるディスプレイでのみ使用できます。

* **Allow Variable Refresh Rate (VRR)** (可変リフレッシュ レート (VRR) を許可する): ディスプレイで VRR を有効にします。 互換性のあるディスプレイでのみ使用できます。

#### <a name="kinect-settings"></a>Kinect の管理

これらの設定を変更するために、Kinect センサーは本体に接続されている必要があります。

* **Enable Kinect** (Kinect を有効にする): 接続されている Kinect センサーを有効にします。

* **Force Kinect reload on app change** (アプリの変更時に Kinect の再読み込みを強制する): 別のアプリやゲームが実行されるたびに、接続されている Kinect センサーを再読み込みします。

#### <a name="localization-settings"></a>ローカライズ設定

* **Geographic region** (地理的領域): デバイスに設定されている地域。 特定の 2 文字の国コードである必要があります (たとえば、米国の場合は **US**)。

* **優先言語**: デバイスに設定されている言語。

* **タイム ゾーン**: デバイスに設定されているタイム ゾーン。

#### <a name="network-settings"></a>ネットワーク設定

* **Wireless radio settings** (ワイヤレス無線の設定): デバイスのワイヤレス設定 (ワイヤレス LAN などの特定の要素はオンかオフか)。

#### <a name="power-settings"></a>電源設定

* **When idle, dim screen after (minutes)** (アイドル時、次の時間 (分) が経過後に画面を暗くする): アイドル状態でこの時間が経過後、画面が暗くなります。 画面を暗くしない場合は、**0** に設定します。

* **When idle, turn off after** (アイドル時、次の時間が経過後に電源を切る): アイドル状態でこの時間が経過後、デバイスをシャット ダウンします。

* **電源モード**: デバイスの電源モード。 詳しくは、「[省電力モードとクイック起動電源モードについて](http://support.xbox.com/xbox-one/console/learn-about-power-modes)」をご覧ください。

* **Automatically boot console when connected to power** (電源に接続されたときに本体を自動的に起動): 電源に接続されると、デバイスが自動的にオンになります。

#### <a name="preference-settings"></a>基本設定

* **既定のホーム エクスペリエンス**: デバイスがオンになったときに表示されるホーム画面を設定します。

* **Xbox アプリからの接続を許可**: Windows 10 PC など、別のデバイス上の Xbox アプリがこの本体に接続できます。

* **Treat UWP apps as games by default** (既定で UWP アプリをゲームとして扱う): ゲームやアプリが、Xbox で割り当てられたさまざまなリソースを取得します。 このボックスをオンにすると、すべての UWP パッケージはゲームとして識別され、より多くのリソースを取得します。

#### <a name="user-settings"></a>ユーザー設定

* **Auto sign in user** (自動サインイン ユーザー): デバイスがオンになったとき、選択されたユーザーに自動的にサインインします。

* **Auto sign in user controller** (自動サインイン ユーザー コントローラー): 特定のコントローラーの種類を、自動的に特定のユーザーと関連付けます。

#### <a name="xbox-live-sandbox"></a>Xbox Live のサンドボックス

ここで、デバイスに適用する Xbox Live サンド ボックスを変更できます。 ボックスにサンドボックスの名前を入力し、**[変更]** を選択します。

### <a name="scratch"></a>スクラッチ

これは空のワークスペースで、自由にカスタマイズすることができます。 メニューを使用して (左上にあるメニュー ボタンをクリックします)、ツールを追加することができます (**[Add tools to workspace]** (ワークスペースにツールを追加する) を選択して、追加するツールを選択し、**[追加]** を選択します)。 このメニューを使用すると、任意のワークスペースにツールを追加すると共に、ワークスペース自体を管理することもできます。

![ワークスペースにツールを追加する](images/device-portal-xbox-13.png)

### <a name="game-event-data"></a>ゲーム イベント データ

**ゲーム イベントのデータ**ページで、できますグラフを表示するリアルタイムそのストリームでは現在、Xbox One で記録されているイベント Windows トレーシング (ETW) ゲームのイベントの数。 (イベント名、イベントの発生、およびゲーム タイトル) の詳細を表示できますも、システムで記録されているゲームのイベントがある場合は、データ グラフの下のデータ テーブル内の各イベントを説明します。 テーブルには、記録されたイベントがある場合は、できるだけです。

![ゲーム イベント データ](images/device-portal-xbox-22.PNG)

## <a name="see-also"></a>関連項目

* [Windows Device Portal の概要](device-portal.md)
* [デバイス ポータル コア API リファレンス](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)