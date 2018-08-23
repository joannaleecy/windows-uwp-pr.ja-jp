---
author: PatrickFarley
ms.assetid: 60fc48dd-91a9-4dd6-a116-9292a7c1f3be
title: Windows Device Portal の概要
description: Windows Device Portal で、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行うための方法を説明します。
ms.author: pafarley
ms.date: 12/12/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、デバイスのポータル
ms.localizationpriority: medium
ms.openlocfilehash: 08e7d8fcfbab0d0b22fffa3e3e0aecc38d5b095c
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2817669"
---
# <a name="windows-device-portal-overview"></a>Windows Device Portal の概要

Windows Device Portal では、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行えます。 また、トラブルシューティングを行うし、お使いの Windows デバイスのリアルタイムのパフォーマンスを表示するための高度な診断ツールを提供します。

Windows デバイス ポータルは、PC 上の web ブラウザーからに接続することができるデバイスで web サーバーです。 お使いのデバイスに web ブラウザーがある場合もローカル デバイス上のブラウザーを使用して接続できます。

Windows デバイス ポータルが、各デバイス ファミリで使用できますが、機能や設定は、各デバイスの要件によって異なります。 ここでは、Device Portal の一般的な説明と、各デバイス ファミリに関するさらに詳細な情報が掲載されている記事へのリンクを示します。

Windows デバイス ポータルの機能は[REST Api](device-portal-api-core.md)のデータにアクセスし、プログラムを使用して、デバイスをコントロールに直接使用することができます。

## <a name="setup"></a>セットアップ

Device Portal への接続の具体的な手順はデバイスによって異なりますが、どのデバイスでも次の一般的な手順が必要です。
1. (設定アプリで構成されている) デバイスでは、開発者モードとデバイス ポータルを有効にします。
2. USB またはローカル ネットワークを使用しているデバイスとコンピューターを接続します。
3. ブラウザーでデバイス ポータルのページに移動します。 次の表は、ポートとプロトコルの各デバイス ファミリによるを示します。

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

ページの上部にあるツールバーは、よく使用される機能へのアクセスを提供します。
- **Power**: power オプションにアクセスします。
  - **[Shutdown]** (シャットダウン): デバイスをオフにします。
  - **[Restart]** (再起動): デバイスの電源を入れ直します。
- **[Help]** (ヘルプ): ヘルプ ページを開きます。

ページの左側にあるナビゲーション ウィンドウのリンクを使用して、デバイスの管理と監視に利用可能なツールに移動します。

ここでは、デバイスのファミリに共通するツールについて説明します。 デバイスによってはその他のオプションを利用できる場合があります。 詳しくは、お使いのデバイスの種類の特定のページを参照してください。

### <a name="apps-manager"></a>アプリ マネージャー

アプリケーション マネージャーは、インストールまたはアンインストールし、アプリの管理機能パッケージをホスト デバイスにバンドルします。

![デバイス ポータルのアプリの管理] ページ](images/device-portal/wdp-apps.png)

- **インストールされているアプリ**:] ドロップダウン メニューを使用して削除したり、デバイスにインストールされているアプリを起動します。 新しいアプリを**追加**] をクリックしてインストールします。 これからローカル パッケージのアプリを展開するユーザー エクスペリエンスのインストールを開始、ネットワーク、または web をホストし、ネットワーク共有から柔軟なファイルを登録します。
- **アプリを実行している**: アプリを現在実行されていると、必要に応じて、終了に関する情報を取得します。

#### <a name="install-an-app"></a>アプリをインストールする

1.  アプリ パッケージを作成したら、デバイス上にリモートでインストールできます。 Visual Studio でビルドすると、出力フォルダーが生成されます。
  ![アプリのインストール](images/device-portal/iot-installapp0.png)
2.  デバイス ポータルのアプリの管理] セクションで、**追加**] をクリックし、[**ローカル記憶域からアプリ パッケージをインストール**します。
3.  [**参照**] をクリックし、アプリ パッケージを検索します。
3.  [**参照**] をクリックし、不要すべてのデバイスで。 証明書 (_.cer_) ファイルを検索
4.  省略可能なインストールしたい場合は、それぞれのボックスまたはアプリのインストールと framework パッケージを確認してください。 1 つ以上ある場合は、それぞれを個別に追加します。     
5.  **次**に、インストールを開始するには、次の手順と**インストール**の移動] をクリックします。 

#### <a name="uninstall-an-app"></a>アプリをアンインストールする
1.  アプリが実行中でないことを確認します。 
2.  する場合は、**アプリを実行している**に移動して、閉じます。 アプリの実行中にアンインストールする場合は、アプリを再インストールしようとしたときに問題が発生してされます。 
3.  ドロップダウン リストから、アプリを選択し、[**削除**] をクリックします。

### <a name="running-processes"></a>プロセスを実行します。

このページには、ホスト デバイスで現在実行されているプロセスに関する詳細情報が表示されます。 これには、アプリとシステムの両方のプロセスが含まれます。 一部プラットフォーム (デスクトップ、IoT、および HoloLens)、プロセスを終了することができます。

![ページを処理するポータルを実行しているデバイス](images/device-portal/mob-device-portal-processes.png)

### <a name="file-explorer"></a>エクスプローラー

このページを使用すると、表示し、アプリの sideloaded によって保存されているファイルを操作できます。 [アプリのエクスプ ローラーを使って](https://blogs.windows.com/buildingapps/2016/06/08/using-the-app-file-explorer-to-see-your-app-data/)ブログ ファイル エクスプ ローラーとその使用方法の詳細については、投稿記事を参照してください。 

![デバイス ポータル ファイル エクスプ ローラー] ページ](images/device-portal/mob-device-portal-AppFileExplorer.png)

### <a name="performance"></a>パフォーマンス

CPU を読み込むし、パフォーマンス] ページがリアルタイムのグラフの電力消費、フレーム レートのようなシステムの診断情報を示します。

利用可能なメトリックを次に示します。
- **CPU**: 使用可能な合計の CPU 使用率の割合
- **メモリ**: 合計を使用して、使用可能なコミット、ページ、および非ページ
- **I/O**: 読み取りおよび書き込みデータの量
- **ネットワーク**: データの送受信
- **GPU**: % の合計の利用可能な GPU エンジン使用率


![ポータル パフォーマンス [デバイス] ページ](images/device-portal/mob-device-portal-perf.png)

### <a name="event-tracing-for-windows-etw-logging"></a>イベントのトレースの Windows (ETW) のログ記録

ETW ログ] ページでは、デバイス上のリアルタイムのイベントのトレースの Windows (ETW) 情報を管理します。

![デバイスのポータル ETW ログ] ページ](images/device-portal/mob-device-portal-etw.png)

**[Hide Providers]** (プロバイダを非表示にする) チェックボックスをオンにすると、イベントの一覧のみが表示されます。
- **[登録されているプロバイダー**: イベント プロバイダーとトレース レベルを選択します。 トレース レベルでは、以下の値のいずれかです。
  1. 異常終了または終了
  2. 重大なエラー
  3. 警告
  4. エラーではない警告
  5. 詳細なトレース

  トレースを開始するには、**[Enable]** (有効にする) をクリックまたはタップします。 **[Enabled Providers]** (有効なプロバイダー) ドロップダウン リストにプロバイダーが追加されます。
- **[Custom providers]** (カスタム プロバイダー): カスタム ETW プロバイダーとトレース レベルを選択します。 GUID を使用してプロバイダーを識別します。 GUID に角かっこを含めません。
- **有効プロバイダー**: これは有効になっているプロバイダーを一覧表示します。 ドロップダウンからプロバイダーを選択し、**[Disable]** (無効にする) をクリックまたはタップしてトレースを停止します。 すべてのトレースを中断するには、**[Stop All]** (すべて停止) をクリックまたはタップします。
- **プロバイダー履歴**: 現在のセッション中に有効になっている ETW プロバイダーが表示されます。 無効になっているプロバイダーをアクティブ化するには、**[Enable]** (有効にする) をクリックまたはタップします。 履歴をクリアするには、**[Clear]** (クリア) をクリックまたはタップします。
- **フィルター/イベント**: **[イベント**] セクションには、表形式で選択されたプロバイダーから ETW イベントが一覧表示します。 テーブルがリアルタイムで更新されます。 イベントを表示するユーザー設定フィルターを設定するのには、[**フィルター** ] メニューを使用します。 テーブルからすべての ETW イベントを削除するのには [**消去**] をクリックします。 これによってプロバイダーが無効になることはありません。 収集されている ETW イベントをローカル .CSV ファイルにエクスポートする**ファイルを保存する**をクリックすることができます。

ETW のログの使用の詳細については、[デバッグ ログを表示するデバイス ポータルを使用する](https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/)ブログ投稿記事を参照してください。 

### <a name="performance-tracing"></a>パフォーマンス トレース

パフォーマンスのトレース] ページできますビューのホストのデバイスから[Windows パフォーマンス記録 (WPR)](https://msdn.microsoft.com/library/hh448205.aspx)トレース。

![デバイス ポータル パフォーマンスのトレース] ページ](images/device-portal/mob-device-portal-perf-tracing.png)

- **[Available profiles]** (利用可能なプロファイル): ドロップダウン リストから WPR プロファイルを選択し、**[Start]** (開始) をクリックまたはタップすると、トレースを開始できます。
- **[Custom profiles]** (カスタム プロファイル): **[Browse]** (参照) をクリックまたはタップして、PC から WPR プロファイルを選択します。 **[Upload and start]** (アップロードして開始) をクリックまたはタップすると、トレースが開始します。

トレースを停止するには、**[Stop]** (停止) をクリックします。 このページで、目的のトレース ファイルを維持 (します。ETL) のダウンロードが完了します。

キャプチャされます。分析のために、「 [Windows Performance Analyzer](https://msdn.microsoft.com/library/windows/desktop/hh448170.aspx)ETL ファイルを開くことができます。

### <a name="device-manager"></a>デバイス マネージャー

[デバイス マネージャー] ページでは、お使いのデバイスに接続されているすべての周辺を列挙します。 それぞれのプロパティを表示する設定アイコンをクリックします。

![デバイス ポータル デバイス マネージャー] ページ](images/device-portal/mob-device-portal-devices.png)

### <a name="networking"></a>ネットワーク

[ネットワーク] ページでは、デバイスでネットワーク接続を管理します。 USB 経由デバイス ポータルに接続すると、これらの設定を変更する、可能性が高いを除きするデバイス ポータルから.
- **利用可能なネットワーク**: デバイスに利用可能な WiFi ネットワークを示しています。 ネットワークをクリックまたはタップすると、そのネットワークに接続し、必要に応じてパスキーを提供できます。 まだ、デバイスのポータルでは、エンタープライズ認証をサポートしていません。 しようとすると、既知のデバイスに WiFi プロファイルのいずれかに接続する**プロファイル**] ドロップダウンを使用することもできます。
- **IP 構成**: デバイスのネットワーク ポートのホストのそれぞれのアドレス情報を表示します。

![デバイスのネットワークのポータル ページ](images/device-portal/mob-device-portal-network.png)

## <a name="service-features-and-notes"></a>サービスの機能とノート

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
> この保護機能には、(コマンド ライン ユーティリティ) などのスタンドアロン クライアントから REST Api の使用状況ができなくなります。 これは 3 つの方法で解決できます。 
> - 「自動的に」ユーザー名を使用します。 クライアントはユーザー名の前に "auto-" を追加することによって、CSRF に対する保護を迂回できます。 このユーザー名は、ブラウザーから Device Portal にログインするために使用しないでください。サービスが CSRF 攻撃を受ける可能性があります。 例: Device Portal のユーザー名が "admin" である場合、CSRF に対する保護を迂回するために ```curl -u auto-admin:password <args>``` を使用します。 
> - クライアントで cookie-to-header スキームを実装します。 そのためには、GET 要求でセッション Cookie を確立し、それ以降のすべての要求にヘッダーと Cookie の両方を含めます。 
> - 認証を無効にして、HTTP を使用します。 CSRF に対する保護は HTTPS エンドポイントにのみ適用されるため、HTTP エンドポイントに接続する場合、上記のいずれの操作も必要ありません。 

#### <a name="cross-site-websocket-hijacking-cswsh-protection"></a>クロスサイト WebSocket ハイジャック (CSWSH) に対する保護

[CSWSH 攻撃](https://www.christian-schneider.net/CrossSiteWebSocketHijacking.html)を防御するために、Device Portal に対して WebSocket 接続を開くすべてのクライアントは、Host ヘッダーと一致する Origin ヘッダーも提供する必要があります。 これにより、Device Portal に対して、要求が Device Portal の UI または有効なクライアント アプリケーションからの要求であることを証明します。 Origin ヘッダーがない場合、要求は拒否されます。 
