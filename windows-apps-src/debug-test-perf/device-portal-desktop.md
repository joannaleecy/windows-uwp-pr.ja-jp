---
author: PatrickFarley
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: "デスクトップ用 Device Portal"
description: "Windows デスクトップで Windows Device Portal の診断と自動化を利用する方法について説明します。"
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 32155bfbb676a5f79dd4b1629f0a88368da36828
ms.sourcegitcommit: 0fa9ae00117e8e6b04ed38956e605bb74c1261c6
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/07/2017
---
# <a name="device-portal-for-desktop"></a>デスクトップ用 Device Portal

Windows 10 Version 1607 以降では、デスクトップで追加の開発者向け機能が利用できるようになりました。 これらの機能は、開発者モードが有効になっている場合にのみ利用可能です。

開発者モードを有効にする方法については、「[デバイスを開発用に有効にする](../get-started/enable-your-device-for-development.md)」をご覧ください。

Device Portal では、診断情報を表示し、使用しているブラウザーから HTTP 経由でデスクトップを操作できます。 Device Portal を使用すると、次の操作を実行できます。
- 実行されているプロセスの一覧を確認して操作する
- アプリをインストール、削除、起動、および終了する
- Wi-Fi プロファイルの変更、シグナルの強さの表示、ipconfig の確認を行う
- CPU、メモリ、I/O、ネットワーク、および GPU の使用率のライブ グラフを表示する
- プロセス ダンプを収集する
- ETW トレースを収集する 
- サイドローディングしたアプリの分離ストレージを操作する

## <a name="set-up-device-portal-on-windows-desktop"></a>Windows Desktop で Device Portal をセットアップする

### <a name="turn-on-device-portal"></a>Device Portal を有効にする

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

## <a name="device-portal-pages"></a>Device Portal のページ

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

## <a name="setting-port-numbers"></a>ポート番号を設定する

デバイス ポータルのポート番号 (80、443 など) を選択する場合は、次のレジストリ キーを設定することができます。

- HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service の下
    - UseDynamicPorts: 必要な DWORD。 選択したポート番号を保持するには、これを 0 に設定します。
    - HttpPort: 必要な DWORD。 Device Portal が HTTP 接続をリッスンするポート番号を指定します。  
    - HttpsPort: 必要な DWORD。 Device Portal が HTTPS 接続をリッスンするポート番号を指定します。

## <a name="failure-to-install-developer-mode-package"></a>開発者モード パッケージのインストール エラー
ネットワークや互換性の問題により、開発者モードが正しくインストールされないことがあります。 開発者モード パッケージは、PC への**リモート**展開 (ブラウザーから Device Portal を使うか、デバイスの検出を使って SSH を有効にする場合) に必要ですが、ローカル展開には必要ありません。  これらの問題が発生した場合でも、Visual Studio を使用してローカルでアプリを展開できます。 

これらの問題に対する回避策については、[既知の問題](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22)フォーラムと[開発者モードに関するページ](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#failure-to-install-developer-mode-package)をご覧ください。 

