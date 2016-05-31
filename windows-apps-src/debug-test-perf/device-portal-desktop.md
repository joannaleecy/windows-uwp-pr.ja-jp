---
author: mcleblanc
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: デスクトップ用 Device Portal
description: Windows デスクトップで Windows Device Portal の診断と自動化を利用する方法について説明します。
---
# デスクトップ用 Device Portal

Windows 10 Version 1604 以降では、デスクトップで追加の開発者向け機能が利用できるようになりました。 これらの機能は、開発者モードが有効になっている場合にのみ利用可能です。

開発者モードを有効にする方法については、「[デバイスを開発用に有効にする](../get-started/enable-your-device-for-development.md)」をご覧ください。

Device Portal では、診断情報を表示し、使用しているブラウザーから HTTP 経由でデスクトップを操作できます。 Device Portal を使用すると、次の操作を実行できます。
- 実行されているプロセスの一覧を確認して操作する
- アプリをインストール、削除、起動、および終了する
- Wi-Fi プロファイルの変更、シグナルの強さの表示、ipconfig の確認を行う
- CPU、メモリ、I/O、ネットワーク、および GPU の使用率のライブ グラフを表示する
- プロセス ダンプを収集する
- ETW トレースを収集する 
- サイドローディングしたアプリの分離ストレージを操作する

## Windows Desktop で Device Portal をセットアップする

### Device Portal を有効にする

**[開発者向け設定]** メニューの [開発者モード] を有効にすると、Device Portal を有効にすることができます。  

Device Portal を有効にするときは、Device Portal のユーザー名とパスワードも作成する必要があります。 Microsoft アカウントやその他の Windows の資格情報を使わないでください。  

Device Portal を有効にしたら、**[設定]** セクション下部にリンクが表示されます。 URL の末尾に適用されるポート番号をメモします。このポート番号は、Device Portal を有効にするとランダムに生成されるものですが、デスクトップを再起動するまで同じ番号を使う必要があります。 同じ番号を使い続けるためにポート番号を手動で設定する場合は、「[ポート番号を設定する](device-portal-desktop.md#setting-port-numbers)」をご覧ください。

Device Portal に接続するには、ローカル ホスト接続と、ローカル ネットワーク (VPN を含む) 経由接続の 2 つの方法のいずれかを使うことができます。

**Device Portal に接続するには**

1. ブラウザーで、使っている接続の種類に応じて次のアドレスを入力します。

    - Localhost: `http://127.0.0.1:PORT` または `http://localhost:PORT`

    このアドレスを使用すると、Device Portal がローカルに表示されます。
    
    - ローカル ネットワーク: `https://<The IP address of the desktop>:PORT`

    このアドレスは、ローカル ネットワーク経由で接続するときに使います。

認証とセキュリティで保護された通信には HTTPS が必要です。

テスト ラボなど、保護された環境で Device Portal を使っている場合、ローカル ネットワーク上のすべてのユーザーを信頼していて、デバイス上に個人情報が保存されておらず、固有の要件もない場合は、認証を無効にできます。 これにより、暗号化されていない通信が有効化され、コンピューターの IP アドレスを知っているすべてのユーザーが制御できるようになります。

## Device Portal のページ

デスクトップの Device Portal では、標準のページのセットが提供されます。 詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。

- アプリ
- プロセス
- パフォーマンス
- デバッグ
- Windows イベント トレーシング (ETW)
- パフォーマンス トレース
- デバイス
- ネットワーク
- アプリのエクスプローラー 

## ポート番号を設定する

デバイス ポータルのポート番号 (80、443 など) を選択する場合は、次のレジストリ キーを設定することができます。

- HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service の下
    - UseDynamicPorts: 必要な DWORD。 選択したポート番号を保持するには、これを 0 に設定します。
    - HttpPort: 必要な DWORD。 Device Portal が HTTP 接続をリッスンするポート番号を指定します。  
    - HttpsPort: 必要な DWORD。 Device Portal が HTTPS 接続をリッスンするポート番号を指定します。

## 開発者モード パッケージのインストール エラー
ネットワークや互換性の問題により、開発者モードが正しくインストールされないことがあります。 開発者モード パッケージは、リモート展開 (Device Portal および SSH) で必要ですが、ローカル開発には必要ありません。  

### パッケージ検索エラー

"Developer Mode package couldn’t be located in Windows Update. Error Code 0x001234 Learn more"   

このエラーは、ネットワーク接続に問題がある場合、エンタープライズ設定になっている場合、またはパッケージが見つからない場合に発生することがあります。 

この問題を解決するには:

1. お使いのコンピューターがインターネットに接続されていることを確認します。 
2. ドメインに参加しているコンピューターの場合は、ネットワーク管理者に問い合わせます。 
3. [設定] > [更新プログラムとセキュリティ] > [[Windows の更新プログラム](ms-settings:windowsupdate)] で Windows の更新プログラムをチェックします。
4. [設定] > [システム] > [アプリと機能] > [[オプション機能を管理する]](ms-settings:optionalfeatures) に、Windows 開発者モード パッケージが存在することを確認します。 ない場合は、Windows はコンピューターの適切なパッケージを検出できません。 

上記の手順のいずれかを実行後、修正を確認するために、開発者モードを無効にし、もう一度有効にします。 


### パッケージ インストール エラー

"Developer Mode package failed to install. Error code 0x001234  Learn more"

このエラーは、Windows のビルドと開発者モード パッケージの間に互換性の問題がある場合に発生します。 

この問題を解決するには:

1. [設定] > [更新プログラムとセキュリティ] > [[Windows の更新プログラム](ms-settings:windowsupdate)] で Windows の更新プログラムをチェックします。
2. すべての更新プログラムを確実に適用するために、コンピューターを再起動します。


<!--HONumber=May16_HO2-->


