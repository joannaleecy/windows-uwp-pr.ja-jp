---
author: PatrickFarley
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: Windows デスクトップ用 Device Portal
description: Windows デスクトップで Windows Device Portal の診断と自動化を利用する方法について説明します。
ms.author: pafarley
ms.date: 03/15/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 146cce82275047c112d70cfb3d022eab723f49e6
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3934291"
---
# <a name="device-portal-for-windows-desktop"></a>Windows デスクトップ用 Device Portal



Windows Device Portal では、診断情報を表示し、ブラウザー ウィンドウから HTTP 経由でデスクトップを操作することができます。 Device Portal を使用すると、次の操作を実行できます。
- 実行されているプロセスの一覧を確認して操作する
- アプリをインストール、削除、起動、および終了する
- Wi-Fi プロファイルの変更、シグナルの強さの表示、ipconfig の確認を行う
- CPU、メモリ、I/O、ネットワーク、および GPU の使用率のライブ グラフを表示する
- プロセス ダンプを収集する
- ETW トレースを収集する 
- サイドローディングされたアプリの分離ストレージを操作する

## <a name="set-up-device-portal-on-windows-desktop"></a>Windows デスクトップで Device Portal をセットアップする

### <a name="turn-on-developer-mode"></a>開発者モードをオンにする

Windows 10 バージョン 1607 以降では、デスクトップ用の新しい機能の一部は開発者モードが有効なときだけ利用できます。 開発者モードを有効にする方法については、「[デバイスを開発用に有効にする](../get-started/enable-your-device-for-development.md)」をご覧ください。

> [!IMPORTANT]
> ネットワークや互換性の問題により、お使いのデバイスに開発者モードが正しくインストールされないことがあります。 これらの問題のトラブルシューティングについては、「[デバイスを開発用に有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#failure-to-install-developer-mode-package)」の関連セクションをご覧ください。

### <a name="turn-on-device-portal"></a>Device Portal をオンにする

**[設定]** の **[開発者向け]** セクションで、Device Portal を有効にすることができます。 Device Portal を有効にするときは、対応するユーザー名とパスワードも作成する必要があります。 Microsoft アカウントやその他の Windows の資格情報を使わないでください。 

![設定アプリの [Device Portal] セクション](images/device-portal/device-portal-desk-settings.png) 

Device Portal が有効になると、セクション下部に Web リンクが表示されます。 表示される URL の末尾に付加されたポート番号をメモします。このポート番号は、Device Portal が有効になるとランダムに生成されるものですが、デスクトップを再起動するまで同じ番号を使う必要があります。 同じ番号を使い続けるためにポート番号を手動で設定する場合は、「[ポート番号を設定する](device-portal-desktop.md#setting-port-numbers)」をご覧ください。

これらのリンクから、ローカル ネットワーク (VPN を含む) 経由、またはローカル ホスト経由のいずれかの方法で Device Portal に接続できます。

### <a name="connect-to-device-portal"></a>Device Portal に接続する

ローカル ホスト経由で接続するには、ブラウザー ウィンドウを開き、使用している接続の種類に関して次に示すアドレスを入力します。

* ローカルホスト: `http://127.0.0.1:<PORT>` または `http://localhost:<PORT>`
* ローカル ネットワーク:  `https://<IP address of the desktop>:<PORT>`

認証とセキュリティで保護された通信には HTTPS が必要です。

テスト ラボなど、保護された環境で Device Portal を使っている場合、ローカル ネットワーク上のすべてのユーザーを信頼していて、デバイス上に個人情報が保存されておらず、固有の要件もない場合は、[認証] オプションを無効にできます。 これにより、暗号化されていない通信が有効化され、コンピューターの IP アドレスを知っているすべてのユーザーが接続して制御できるようになります。

## <a name="device-portal-content-on-windows-desktop"></a>Windows デスクトップ上の Device Portal のコンテンツ

Windows デスクトップの Device Portal では、標準のページのセットが提供されます。 これらの詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。

- アプリ マネージャー
- エクスプローラー
- 実行中のプロセス
- パフォーマンス
- デバッグ
- Windows イベント トレーシング (ETW)
- パフォーマンス トレース
- デバイス マネージャー
- ネットワーク
- クラッシュ データ
- 機能
- Mixed Reality
- ストリーミング インストール デバッガー
- 位置情報
- スクラッチ

## <a name="more-device-portal-options"></a>Device Portal のその他のオプション
### <a name="registry-based-configuration-for-device-portal"></a>Device Portal のレジストリ ベースの構成

デバイス ポータルのポート番号 (80、443 など) を選択する場合は、次のレジストリ キーを設定することができます。

- 以下のパスの下 `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service`
    - `UseDynamicPorts`: 必須の DWORD。 選択したポート番号を保持するには、これを 0 に設定します。
    - `HttpPort`: 必須の DWORD。 Device Portal が HTTP 接続をリッスンするポート番号を指定します。    
    - `HttpsPort`: 必須の DWORD。 Device Portal が HTTPS 接続をリッスンするポート番号を指定します。
    
同じレジストリ キー パスの下で、認証要件をオフにすることもできます。
- `UseDefaultAuthorizer` - `0` (無効)、`1` (有効)。  
    - これによって、各接続の基本認証要件と HTTP から HTTPS へのリダイレクトの両方が制御されます。  
    
### <a name="command-line-options-for-device-portal"></a>Device Portal のコマンド ライン オプション
管理コマンド プロンプトから、Device Portal の各部分を有効にして構成することができます。 ビルドでサポートされている最新のコマンド セットを表示するには、このコマンドを実行することができます。 `webmanagement /?`

- `sc start webmanagement` または `sc stop webmanagement` 
    - サービスをオンまたはオフにします。 ここでも、開発者モードを有効にする必要があります。 
- `-Credentials <username> <password>` 
    - Device Portal のユーザー名とパスワードを設定します。 ユーザー名は基本認証の標準に準拠している必要があるため、コロン (:) を含めることはできません。また、ブラウザーは標準的な方法ではすべての文字セットを解析しないため、標準の ASCII 文字 (a-z、A-Z、0-9) で構成されている必要があります。  
- `-DeleteSSL` 
    - このオプションを指定すると、HTTPS 接続に使用される SSL 証明書のキャッシュがリセットされます。 予期される証明書の警告ではなく、バイパスすることができない TLS 接続エラーが発生した場合は、このオプションで問題が解決される可能性があります。 
- `-SetCert <pfxPath> <pfxPassword>`
    - 詳しくは、「[カスタムの SSL 証明書で Device Portal をプロビジョニングする](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-ssl)」をご覧ください。  
    - このオプションを指定すると、独自の SSL 証明書をインストールして、通常 Device Portal に表示される SSL 警告ページを修正することができます。 
- `-Debug <various options for authentication, port selection, and tracing level>`
    - 特定の構成と視覚的なデバッグ メッセージを使用して、Device Portal のスタンドアロン バージョンを実行します。 これは、[パッケージ プラグイン](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-plugin)を構築するときに最も役立ちます。 
    - これをシステムとして実行して、パッケージ プラグインを完全にテストする方法について詳しくは、[MSDN Magazine の記事](https://msdn.microsoft.com/en-us/magazine/mt826332.aspx)をご覧ください。

## <a name="see-also"></a>関連項目

* [Windows Device Portal の概要](device-portal.md)
* [デバイス ポータル コア API リファレンス](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)
