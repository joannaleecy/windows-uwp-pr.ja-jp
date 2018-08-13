---
author: PatrickFarley
ms.assetid: 60fc48dd-91a9-4dd6-a116-9292a7c1f3be
title: Windows Device Portal の概要
description: Windows Device Portal で、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行うための方法を説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: f22600f2bbd5dc43996550c853c6defd04565ad4
ms.sourcegitcommit: e8cc657d85566768a6efb7cd972ebf64c25e0628
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/26/2017
ms.locfileid: "693478"
---
# <a name="windows-device-portal-overview"></a>Windows Device Portal の概要

Windows Device Portal では、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行えます。 また、Windows デバイスのトラブルシューティングを行ったり、リアルタイムのパフォーマンスを表示するための高度な診断ツールも用意されています。

デバイス ポータルは、お使いの PC に Web ブラウザーから接続することができるデバイス上の Web サーバーです。 デバイスに Web ブラウザーがある場合、デバイスのブラウザーにローカル接続することもできます。

各デバイス ファミリで Windows Device Portal を利用できますが、機能とセットアップはデバイスの要件によって異なります。 ここでは、Device Portal の一般的な説明と、各デバイス ファミリに関するさらに詳細な情報が掲載されている記事へのリンクを示します。

Windows Device Portal のすべての機能は [REST API](device-portal-api-core.md) の上に構築されます。REST API を使用してデータにアクセスしたり、プログラムを使ってデバイスを制御することができます。

## <a name="setup"></a>セットアップ

Device Portal への接続の具体的な手順はデバイスによって異なりますが、どのデバイスでも次の一般的な手順が必要です。
1. デバイスで開発者モードと Device Portal を有効にします。
2. デバイスと PC をローカル ネットワークまたは USB 経由で接続します。
3. ブラウザーでデバイス ポータルのページに移動します。 次の表は、各デバイス ファミリで使用されるポートとプロトコルを示しています。

デバイス ファミリ | 既定でオンになっているか | HTTP | HTTPS | USB
--------------|----------------|------|-------|----
HoloLens | 開発者モードでオン | 80 (既定) | 443 (既定) | http://127.0.0.1:10080
IoT | 開発者モードでオン | 8080 | レジストリ キーで有効化する | なし
Xbox | 開発者モードで有効化する | 無効 | 11443 | なし
Desktop| 開発者モードで有効化する | 50080\* | 50043\* | なし
Phone | 開発者モードで有効化する | 80| 443 | http://127.0.0.1:10080

\* デスクトップ上の Device Portal が、デバイス上の既存のポート要求との競合を避ける目的で ephemeral ポートの範囲 (>50,000) にあるポートを要求するため、この表が当てはまらない場合があります。  詳しくは、デスクトップに関する「[ポート番号を設定する](device-portal-desktop.md#setting-port-numbers)」のセクションをご覧ください。  

デバイス固有のセットアップ手順については、以下をご覧ください。
- [HoloLens 用 Device Portal](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-hololens)
- [IoT 用 Device Portal](https://go.microsoft.com/fwlink/?LinkID=616499)
- [モバイル用 Device Portal](device-portal-mobile.md)
- [Xbox 用 Device Portal](device-portal-xbox.md)
- [デスクトップ用 Device Portal](device-portal-desktop.md#set-up-device-portal-on-windows-desktop)

## <a name="features"></a>機能

### <a name="toolbar-and-navigation"></a>ツールバーとナビゲーション

ページの最上部にあるツール バーでは、よく使われる状態や機能にアクセスできます。
- **[Shutdown]** (シャットダウン): デバイスをオフにします。
- **[Restart]** (再起動): デバイスの電源を入れ直します。
- **[Help]** (ヘルプ): ヘルプ ページを開きます。

ページの左側にあるナビゲーション ウィンドウのリンクを使用して、デバイスの管理と監視に利用可能なツールに移動します。

ここでは、すべてのデバイスに共通のツールについて説明します。 デバイスによってはその他のオプションを利用できる場合があります。 詳しくは、お使いのデバイス用のページをご覧ください。

### <a name="home"></a>ホーム

デバイス ポータル セッションはホーム ページで開始します。 通常、ホーム ページには、名前や OS のバージョンなどのデバイスに関する情報、およびデバイスについて設定できる項目が表示されます。

### <a name="apps"></a>アプリ

デバイスへの AppX パッケージとバンドルのインストール/アンインストールおよび管理を行う機能を提供します。

![モバイル用 Device Portal](images/device-portal/mob-device-portal-apps.png)

- **[Installed apps]** (インストール済みのアプリ): アプリを削除および起動します。
- **[Running apps]** (実行中のアプリ): 現在実行されているアプリを一覧表示し、アプリを閉じるためのオプションを提供します。
- **[Install app]** (アプリのインストール): コンピューターまたはネットワーク上のフォルダーからインストールするアプリ パッケージを選択します。
- **[Dependency]** (依存関係): インストールするアプリの依存関係を追加します。
- **[Deploy]** (展開): 選択したアプリと依存関係をデバイスに展開します。

**アプリをインストールするには**

1.  [アプリ パッケージを作成](https://msdn.microsoft.com/library/windows/apps/xaml/hh454036(v=vs.140).aspx)したら、デバイス上にリモートでインストールできます。 Visual Studio でビルドすると、出力フォルダーが生成されます。

    ![アプリのインストール](images/device-portal/iot-installapp0.png)
2.  [参照] をクリックして、アプリ パッケージ (.appx) を検索します。
3.  [参照] をクリックして、証明書ファイル (.cer) を検索します。 (デバイスによっては不要です。)
4.  依存関係を追加します。 1 つ以上ある場合は、それぞれを個別に追加します。     
5.  **[Deploy]** (展開) の下の **[Go]** (進む) をクリックします。 
6.  別のアプリをインストールするには、**[Reset]** (リセット) ボタンをクリックしてフィールドをクリアします。


**アプリをアンインストールするには**

1.  アプリが実行中でないことを確認します。 
2.  実行中の場合、[Running apps] に移動してそのアプリを閉じます。 アプリの実行中にアンインストールすると、そのアプリを再インストールしようとするときに問題が発生することがあります。 
3.  準備ができたら、**[Uninstall]** (アンインストール) をクリックします。

### <a name="processes"></a>プロセス

現在実行中のプロセスに関する詳細を表示します。 これには、アプリとシステムの両方のプロセスが含まれます。

このページでは、PC のタスク マネージャーと同様に、現在実行されているプロセスと、そのプロセスのメモリ使用量を確認できます。  一部のプラットフォーム (Desktop、IoT、および HoloLens) では、プロセスを終了することができます。

![モバイル用 Device Portal](images/device-portal/mob-device-portal-processes.png)

### <a name="performance"></a>パフォーマンス

電力消費、フレーム レート、CPU 負荷など、システムの診断情報のグラフをリアルタイムで表示します。

利用可能なメトリックを次に示します。
- **[CPU]**: 使用可能量の合計に対するパーセント
- **[Memory]** (メモリ): 合計メモリ、使用中のメモリ、使用可能なコミット メモリ、ページ メモリ、および非ページ メモリ
- **[GPU]**: GPU エンジンの使用率、使用可能量の合計に対するパーセント
- **[I/O]**: 読み取りと書き込み
- **[Network]** (ネットワーク): 受信と送信

![モバイル用 Device Portal](images/device-portal/mob-device-portal-perf.png)

### <a name="event-tracing-for-windows-etw"></a>Windows イベント トレーシング (ETW)

デバイス上の Windows イベント トレーシング (ETW) をリアルタイムで管理します。

![モバイル用 Device Portal](images/device-portal/mob-device-portal-etw.png)

**[Hide Providers]** (プロバイダを非表示にする) チェックボックスをオンにすると、イベントの一覧のみが表示されます。
- **[Registered providers]** (登録済みプロバイダー): ETW プロバイダーとトレース レベルを選択します。 トレース レベルは次のいずれかの値になります。
    1. 異常終了または終了
    2. 重大なエラー
    3. 警告
    4. エラーではない警告
    5. 詳細なトレース (*)

トレースを開始するには、**[Enable]** (有効にする) をクリックまたはタップします。 **[Enabled Providers]** (有効なプロバイダー) ドロップダウン リストにプロバイダーが追加されます。
- **[Custom providers]** (カスタム プロバイダー): カスタム ETW プロバイダーとトレース レベルを選択します。 GUID を使用してプロバイダーを識別します。 GUID にはかっこを含めないでください。
- **[Enabled providers]** (有効なプロバイダー): 有効なプロバイダーを一覧表示します。 ドロップダウンからプロバイダーを選択し、**[Disable]** (無効にする) をクリックまたはタップしてトレースを停止します。 すべてのトレースを中断するには、**[Stop All]** (すべて停止) をクリックまたはタップします。
- **[Providers history]** (プロバイダー履歴): 現在のセッション中に有効になった ETW プロバイダーを表示します。 無効になっているプロバイダーをアクティブ化するには、**[Enable]** (有効にする) をクリックまたはタップします。 履歴をクリアするには、**[Clear]** (クリア) をクリックまたはタップします。
- **[Events]** (イベント): 選択したプロバイダーの ETW イベントを表形式で一覧表示します。 この表は、リアルタイムで更新されます。 すべての ETW イベントを表から削除するには、表の下にある **[Clear]** (クリア) ボタンをクリックします。 これによってプロバイダーが無効になることはありません。 **[Save to file]** (ファイルに保存) をクリックすると、現在収集されている ETW イベントをローカルの CSV ファイルにエクスポートできます。

ETW トレースの使い方について詳しくは、アプリからリアルタイムのログを収集する方法に関する[ブログの記事](https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/)をご覧ください。 

### <a name="performance-tracing"></a>パフォーマンス トレース

[Windows Performance Recorder](https://msdn.microsoft.com/library/windows/hardware/hh448205.aspx) (WPR) のトレースをデバイスからキャプチャします。

![モバイル用 Device Portal](images/device-portal/mob-device-portal-perf-tracing.png)

- **[Available profiles]** (利用可能なプロファイル): ドロップダウン リストから WPR プロファイルを選択し、**[Start]** (開始) をクリックまたはタップすると、トレースを開始できます。
- **[Custom profiles]** (カスタム プロファイル): **[Browse]** (参照) をクリックまたはタップして、PC から WPR プロファイルを選択します。 **[Upload and start]** (アップロードして開始) をクリックまたはタップすると、トレースが開始します。

トレースを停止するには、**[Stop]** (停止) をクリックします。 トレース ファイル (.ETL) のダウンロードが完了するまで、このページを閉じないでください。

キャプチャした ETL ファイルは、[Windows Performance Analyzer](https://msdn.microsoft.com/library/windows/hardware/hh448170.aspx) で開いて分析に使用できます。

### <a name="devices"></a>デバイス

デバイスに接続されているすべての周辺機器を列挙します。

![モバイル用 Device Portal](images/device-portal/mob-device-portal-devices.png)

### <a name="networking"></a>ネットワーク

デバイス上のネットワーク接続を管理します。  デバイス ポータルに USB 経由で接続している場合を除き、これらの設定を変更するとデバイス ポータルとの接続が切断される可能性があります。
- **[Profiles]** (プロファイル): 使用する Wi-Fi プロファイルを選択します。  
- **[Available networks]** (利用可能なネットワーク): デバイスで利用可能な Wi-Fi ネットワーク。 ネットワークをクリックまたはタップすると、そのネットワークに接続し、必要に応じてパスキーを提供できます。 注: Device Portal では Enterprise Authentication はまだサポートされていません。 

![モバイル用 Device Portal](images/device-portal/mob-device-portal-network.png)

### <a name="app-file-explorer"></a>アプリのエクスプローラー

サイドロードされたアプリによって保存されたファイルを表示および操作できるようにします。  これは、Windows Phone 8.1 の[分離ストレージ エクスプローラー](https://msdn.microsoft.com/library/windows/apps/hh286408(v=vs.105).aspx)の新しいクロスプラットフォーム バージョンです。アプリのエクスプローラーとその使用方法について詳しくは、[こちらのブログの投稿](https://blogs.windows.com/buildingapps/2016/06/08/using-the-app-file-explorer-to-see-your-app-data/)をご覧ください。 

![モバイル用 Device Portal](images/device-portal/mob-device-portal-AppFileExplorer.png)

## <a name="service-features-and-notes"></a>サービスの機能と注意事項

### <a name="dns-sd"></a>DNS-SD

Device Portal は DNS-SD を使用して、ローカル ネットワーク上でその存在をアドバタイズします  Device Portal のすべてのインスタンスは、デバイスの種類に関係なく、"WDP._wdp._tcp.local" でアドバタイズします。 サービス インスタンスの TXT レコードは、次の情報を提供します。

キー | 型 | 説明 
----|------|-------------
S | int | Device Portal 用のセキュリティで保護されたポート。  0 (ゼロ) の場合、Device Portal は HTTPS 接続をリッスンしていません。 
D | string | デバイスの種類。  "Windows.*" の形式 (Windows.Xbox、Windows.Desktop など) になります。
A | string | デバイスのアーキテクチャ。  これは、ARM、x86、AMD64 のいずれかです。  
T | null 文字で区切られた string のリスト | ユーザーが適用したデバイスのタグ。 使い方については、タグの REST API に関する説明をご覧ください。 リストは 2 つの null で終了します。  

DNS-SD レコードでアドバタイズされる HTTP ポートですべてのデバイスがリッスンしているわけではないため、HTTPS ポートでの接続をお勧めします。 

### <a name="csrf-protection-and-scripting"></a>CSRF に対する保護とスクリプト

[CSRF 攻撃](https://wikipedia.org/wiki/Cross-site_request_forgery)に対する保護のために、すべての非 GET 要求に一意のトークンが必要です。 このトークン、X-CSRF-Token 要求ヘッダーは、セッション Cookie、CSRF-Token から派生します。 Device Portal の Web UI では、CSRF-Token Cookie が、各要求の X-CSRF-Token にコピーされます。

**重要:** この保護によって、スタンドアロン クライアント (コマンド ライン ユーティリティなど) から REST API を使用できなくなります。 これは 3 つの方法で解決できます。 

1. "auto-" というユーザー名を使用します。 クライアントはユーザー名の前に "auto-" を追加することによって、CSRF に対する保護を迂回できます。 このユーザー名は、ブラウザーから Device Portal にログインするために使用しないでください。サービスが CSRF 攻撃を受ける可能性があります。 例: Device Portal のユーザー名が "admin" である場合、CSRF に対する保護を迂回するために ```curl -u auto-admin:password <args>``` を使用します。 

2. クライアントで cookie-to-header スキームを実装します。 そのためには、GET 要求でセッション Cookie を確立し、それ以降のすべての要求にヘッダーと Cookie の両方を含めます。 
 
3. 認証を無効にして、HTTP を使用します。 CSRF に対する保護は HTTPS エンドポイントにのみ適用されるため、HTTP エンドポイントに接続する場合、上記のいずれの操作も必要ありません。 

**注**: ユーザー名が "auto-" で始まる場合、ブラウザーを使用して Device Portal にログインできません。  

#### <a name="cross-site-websocket-hijacking-cswsh-protection"></a>クロスサイト WebSocket ハイジャック (CSWSH) に対する保護

[CSWSH 攻撃](https://www.christian-schneider.net/CrossSiteWebSocketHijacking.html)を防御するために、Device Portal に対して WebSocket 接続を開くすべてのクライアントは、Host ヘッダーと一致する Origin ヘッダーも提供する必要があります。  これにより、Device Portal に対して、要求が Device Portal の UI または有効なクライアント アプリケーションからの要求であることを証明します。  Origin ヘッダーがない場合、要求は拒否されます。 
