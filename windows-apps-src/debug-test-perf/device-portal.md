---
author: PatrickFarley
ms.assetid: 60fc48dd-91a9-4dd6-a116-9292a7c1f3be
title: Windows Device Portal の概要
description: Windows Device Portal で、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行うための方法を説明します。
ms.author: pafarley
ms.date: 12/12/2017
ms.topic: article
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 240cbb84713fb09b0bc51d70ca93b640797f2752
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7429613"
---
# <a name="windows-device-portal-overview"></a>Windows Device Portal の概要

Windows Device Portal では、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行えます。 トラブルシューティングを実行し、Windows デバイスのリアルタイムのパフォーマンスを表示するための高度な診断ツールも提供されます。

Windows Device Portal は、PC 上の web ブラウザーから接続することができるデバイス上の web サーバーです。 デバイスの web ブラウザーである場合、またローカルにそのデバイスのブラウザーで接続できます。

Windows Device Portal では、各デバイス ファミリで利用できますが、機能とセットアップは、各デバイスの要件に基づいて異なります。 ここでは、Device Portal の一般的な説明と、各デバイス ファミリに関するさらに詳細な情報が掲載されている記事へのリンクを示します。

Windows Device Portal の機能は、データにアクセスし、デバイスをプログラムでコントロールを直接使用できる[REST Api](device-portal-api-core.md)を使って実装されます。

## <a name="setup"></a>セットアップ

Device Portal への接続の具体的な手順はデバイスによって異なりますが、どのデバイスでも次の一般的な手順が必要です。
1. (設定アプリで構成されている) デバイスで開発者モードと Device Portal を有効にします。
2. ローカル ネットワーク経由または USB デバイスと PC に接続します。
3. ブラウザーでデバイス ポータルのページに移動します。 次の表では、ポートとプロトコルの各デバイス ファミリで使用されるを示します。

デバイス ファミリ | 既定でオンになっているか | HTTP | HTTPS | USB
--------------|----------------|------|-------|----
HoloLens | 開発者モードでオン | 80 (既定) | 443 (既定) | http://127.0.0.1:10080
IoT | 開発者モードでオン | 8080 | レジストリ キーで有効化する | なし
Xbox | 開発者モードで有効化する | 無効 | 11443 | なし
Desktop| 開発者モードで有効化する | 50080\* | 50043\* | なし
Phone | 開発者モードで有効化する | 80| 443 | http://127.0.0.1:10080

\* デスクトップ上の Device Portal が、デバイス上の既存のポート要求との競合を避ける目的で ephemeral ポートの範囲 (>50,000) にあるポートを要求するため、この表が当てはまらない場合があります。 詳しくは、デスクトップに関する「[ポート番号を設定する](device-portal-desktop.md#registry-based-configuration-for-device-portal)」のセクションをご覧ください。  

デバイス固有のセットアップ手順については、以下をご覧ください。
- [HoloLens 用 Device Portal](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-hololens)
- [IoT 用 Device Portal](https://go.microsoft.com/fwlink/?LinkID=616499)
- [モバイル用 Device Portal](device-portal-mobile.md)
- [Xbox 用 Device Portal](device-portal-xbox.md)
- [デスクトップ用 Device Portal](device-portal-desktop.md#set-up-device-portal-on-windows-desktop)

## <a name="features"></a>機能

### <a name="toolbar-and-navigation"></a>ツールバーとナビゲーション

ページの上部にあるツールバーでは、よく使われる機能へのアクセスを提供します。
- **電源**: 電源オプションにアクセスします。
  - **[Shutdown]** (シャットダウン): デバイスをオフにします。
  - **[Restart]** (再起動): デバイスの電源を入れ直します。
- **[Help]** (ヘルプ): ヘルプ ページを開きます。

ページの左側にあるナビゲーション ウィンドウのリンクを使用して、デバイスの管理と監視に利用可能なツールに移動します。

ここでは、デバイス ファミリに共通するツールについて説明します。 デバイスによってはその他のオプションを利用できる場合があります。 詳しくは、デバイスの種類の特定のページをご覧ください。

### <a name="apps-manager"></a>アプリ マネージャー

アプリ マネージャーは、インストール/アンインストールを提供し、アプリの管理機能をパッケージ化し、ホスト デバイスでバンドルします。

![[デバイス ポータル アプリ マネージャー] ページ](images/device-portal/wdp-apps.png)

- **インストール済みアプリ**: ドロップダウン メニューを使用して削除したり、デバイスにインストールされているアプリを起動します。 **追加**] をクリックして新しいアプリをインストールします。 ローカルからパッケージ アプリを展開する UX のインストールが開始、ネットワークまたは web をホストし、ネットワーク共有からルーズ ファイルを登録します。
- **アプリの実行**: 現在実行しているし、必要に応じてそれらを閉じているアプリに関する情報を取得します。

#### <a name="install-an-app"></a>アプリをインストールする

1.  アプリ パッケージを作成したら、デバイス上にリモートでインストールできます。 Visual Studio でビルドすると、出力フォルダーが生成されます。
  ![アプリのインストール](images/device-portal/iot-installapp0.png)
2.  Device Portal のアプリ マネージャーのセクションでは、**追加**] をクリックし、**ローカル記憶域からのアプリ パッケージのインストール**を選択します。
3.  **参照**をクリックし、アプリ パッケージを検索します。
3.  [**参照**] をクリックし、(必要ありませんすべてのデバイスで)。 証明書 (_.cer_) ファイルを検索
4.  フレームワーク パッケージと共にアプリのインストール オプションをインストールする場合、それぞれのボックスを確認します。 1 つ以上ある場合は、それぞれを個別に追加します。     
5.  **[次へ]** をクリックして、インストールを開始するため、次の手順と**インストール**に移動します。 

#### <a name="uninstall-an-app"></a>アプリをアンインストールする
1.  アプリが実行中でないことを確認します。 
2.  場合は、**アプリの実行**に移動して閉じます。 アプリの実行中にアンインストールしようとする場合、アプリを再インストールしようとしたときに問題が発生されます。 
3.  ドロップダウン リストからアプリを選択し、[**削除**] をクリックします。

### <a name="running-processes"></a>実行中のプロセス

このページには、ホスト デバイスで現在実行されているプロセスの詳細が表示されます。 これには、アプリとシステムの両方のプロセスが含まれます。 (デスクトップ、IoT、および HoloLens) 一部のプラットフォームでは、プロセスを終了できます。

![ページを処理してポータルを実行しているデバイス](images/device-portal/mob-device-portal-processes.png)

### <a name="file-explorer"></a>エクスプローラー

このページを表示して、サイドローディングされたアプリによって保存されたファイルを操作できます。 [アプリのエクスプ ローラーを使って](https://blogs.windows.com/buildingapps/2016/06/08/using-the-app-file-explorer-to-see-your-app-data/)ブログ記事については、エクスプ ローラーとその使用方法の詳細を参照してください。 

![デバイス ポータル ファイル エクスプ ローラー] ページ](images/device-portal/mob-device-portal-AppFileExplorer.png)

### <a name="performance"></a>パフォーマンス

パフォーマンス ページには、グラフをリアルタイムでの電力消費、フレーム レートなどのシステムの診断情報が表示されます。 し、CPU を読み込みます。

利用可能なメトリックを次に示します。
- **CPU**: 合計利用可能な CPU 使用率の割合
- **メモリ**: 利用可能なコミット、ページ、および非ページの使用中の合計
- **I/O**: 読み取りと書き込みのデータ量
- **ネットワーク**: 受信し、データの送信
- **GPU**: エンジンの使用率の合計の利用可能な GPU の割合


![デバイス ポータル パフォーマンス ページ](images/device-portal/mob-device-portal-perf.png)

### <a name="event-tracing-for-windows-etw-logging"></a>Windows トレーシング (ETW) のイベント ログ

ETW ログ] ページでは、デバイスでのリアルタイムのイベント Windows トレーシング (ETW) 情報を管理します。

![デバイス ポータル ETW ログ] ページ](images/device-portal/mob-device-portal-etw.png)

**[Hide Providers]** (プロバイダを非表示にする) チェックボックスをオンにすると、イベントの一覧のみが表示されます。
- **登録済みプロバイダー**: イベント プロバイダーとトレース レベルを選択します。 トレース レベルは、これらの値のいずれかを示します。
  1. 異常終了または終了
  2. 重大なエラー
  3. 警告
  4. エラーではない警告
  5. 詳細なトレース

  トレースを開始するには、**[Enable]** (有効にする) をクリックまたはタップします。 **[Enabled Providers]** (有効なプロバイダー) ドロップダウン リストにプロバイダーが追加されます。
- **[Custom providers]** (カスタム プロバイダー): カスタム ETW プロバイダーとトレース レベルを選択します。 GUID を使用してプロバイダーを識別します。 GUID には、かっこを含めないでください。
- **Enabled プロバイダー**。 これにより、有効なプロバイダーを一覧表示します。 ドロップダウンからプロバイダーを選択し、**[Disable]** (無効にする) をクリックまたはタップしてトレースを停止します。 すべてのトレースを中断するには、**[Stop All]** (すべて停止) をクリックまたはタップします。
- **プロバイダー履歴**: これは、現在のセッション中に有効になった ETW プロバイダーを示しています。 無効になっているプロバイダーをアクティブ化するには、**[Enable]** (有効にする) をクリックまたはタップします。 履歴をクリアするには、**[Clear]** (クリア) をクリックまたはタップします。
- **フィルター/イベント**: [**イベント**] セクションの表の形式で選択したプロバイダーからの ETW イベントの一覧を示します。 表は、リアルタイムで更新されます。 イベントが表示されるカスタム フィルターを設定するには、**フィルターを使って**メニューを使用します。 すべての ETW イベントを表から削除する**クリア**] ボタンをクリックします。 これによってプロバイダーが無効になることはありません。 現在収集されている ETW イベントをローカルの CSV ファイルにエクスポートする**ファイルを保存する**をクリックすることができます。

ETW ログの使用について詳しくは、[デバッグ ログを表示するデバイス ポータルを使用](https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/)ブログの記事を参照してください。 

### <a name="performance-tracing"></a>パフォーマンス トレース

パフォーマンス トレース ページは、ホスト デバイスから[Windows Performance Recorder (WPR)](https://msdn.microsoft.com/library/hh448205.aspx)のトレース表示できます。

![デバイス ポータル パフォーマンス トレース ページ](images/device-portal/mob-device-portal-perf-tracing.png)

- **[Available profiles]** (利用可能なプロファイル): ドロップダウン リストから WPR プロファイルを選択し、**[Start]** (開始) をクリックまたはタップすると、トレースを開始できます。
- **[Custom profiles]** (カスタム プロファイル): **[Browse]** (参照) をクリックまたはタップして、PC から WPR プロファイルを選択します。 **[Upload and start]** (アップロードして開始) をクリックまたはタップすると、トレースが開始します。

トレースを停止するには、**[Stop]** (停止) をクリックします。 トレース ファイルまで、このページで保持される (します。ETL) のダウンロードが完了します。

キャプチャされます。ETL ファイルを開いて[Windows Performance Analyzer](https://msdn.microsoft.com/library/windows/desktop/hh448170.aspx)で分析できます。

### <a name="device-manager"></a>デバイス マネージャー

[デバイス マネージャー] ページでは、お使いのデバイスに接続されているすべての周辺機器を列挙します。 それぞれのプロパティを表示する設定アイコンをクリックすることができます。

![[デバイス ポータル デバイス マネージャー] ページ](images/device-portal/mob-device-portal-devices.png)

### <a name="networking"></a>ネットワーク

ネットワーク ページでは、デバイス上のネットワーク接続を管理します。 USB 経由の Device Portal に接続している場合を除き、これらの設定を変更する切断される可能性が Device Portal からです。
- **利用可能なネットワーク**: デバイスに利用可能な WiFi ネットワークを示しています。 ネットワークをクリックまたはタップすると、そのネットワークに接続し、必要に応じてパスキーを提供できます。 Device Portal はまだサポートされていませんエンタープライズ認証します。 既知のデバイスに WiFi プロファイルのいずれかに接続しようとするのに**プロファイル**ドロップダウン リストを使用することもできます。
- **IP 構成**: デバイスのネットワーク ポートの各ホストのアドレス情報を示しています。

![デバイス ポータルのネットワーク ページ](images/device-portal/mob-device-portal-network.png)

## <a name="service-features-and-notes"></a>サービスの機能と注意事項

### <a name="dns-sd"></a>DNS-SD

Device Portal は DNS-SD を使用して、ローカル ネットワーク上でその存在をアドバタイズします Device Portal のすべてのインスタンスは、デバイスの種類に関係なく、"WDP._wdp._tcp.local" でアドバタイズします。 サービス インスタンスの TXT レコードは、次の情報を提供します。

キー | 型 | 説明 
----|------|-------------
S | int | Device Portal 用のセキュリティで保護されたポート。 0 (ゼロ) の場合、Device Portal は HTTPS 接続をリッスンしていません。 
D | string | デバイスの種類。 "Windows.*" の形式 (Windows.Xbox、Windows.Desktop など) になります。
A | string | デバイスのアーキテクチャ。 これは、ARM、x86、AMD64 のいずれかです。  
T | null 文字で区切られた string のリスト | ユーザーが適用したデバイスのタグ。 使い方については、タグの REST API に関する説明をご覧ください。 リストは 2 つの null で終了します。  

DNS-SD レコードでアドバタイズされる HTTP ポートですべてのデバイスがリッスンしているわけではないため、HTTPS ポートでの接続をお勧めします。 

### <a name="csrf-protection-and-scripting"></a>CSRF に対する保護とスクリプト

[CSRF 攻撃](https://wikipedia.org/wiki/Cross-site_request_forgery)に対する保護のために、すべての非 GET 要求に一意のトークンが必要です。 このトークン、X-CSRF-Token 要求ヘッダーは、セッション Cookie、CSRF-Token から派生します。 Device Portal の Web UI では、CSRF-Token Cookie が、各要求の X-CSRF-Token にコピーされます。

> [!IMPORTANT]
> この保護は、スタンドアロン クライアント (コマンド ライン ユーティリティ) などから REST Api の使用法を防ぎます。 これは 3 つの方法で解決できます。 
> - "Auto-"というユーザー名を使用します。 クライアントはユーザー名の前に "auto-" を追加することによって、CSRF に対する保護を迂回できます。 このユーザー名は、ブラウザーから Device Portal にログインするために使用しないでください。サービスが CSRF 攻撃を受ける可能性があります。 例: Device Portal のユーザー名が "admin" である場合、CSRF に対する保護を迂回するために ```curl -u auto-admin:password <args>``` を使用します。 
> - クライアントで cookie-to-header スキームを実装します。 そのためには、GET 要求でセッション Cookie を確立し、それ以降のすべての要求にヘッダーと Cookie の両方を含めます。 
> - 認証を無効にして、HTTP を使用します。 CSRF に対する保護は HTTPS エンドポイントにのみ適用されるため、HTTP エンドポイントに接続する場合、上記のいずれの操作も必要ありません。 

#### <a name="cross-site-websocket-hijacking-cswsh-protection"></a>クロスサイト WebSocket ハイジャック (CSWSH) に対する保護

[CSWSH 攻撃](https://www.christian-schneider.net/CrossSiteWebSocketHijacking.html)を防御するために、Device Portal に対して WebSocket 接続を開くすべてのクライアントは、Host ヘッダーと一致する Origin ヘッダーも提供する必要があります。 これにより、Device Portal に対して、要求が Device Portal の UI または有効なクライアント アプリケーションからの要求であることを証明します。 Origin ヘッダーがない場合、要求は拒否されます。 
