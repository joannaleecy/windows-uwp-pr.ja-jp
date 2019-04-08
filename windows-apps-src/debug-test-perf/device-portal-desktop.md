---
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: Windows デスクトップ用 Device Portal
description: Windows デスクトップで Windows Device Portal の診断と自動化を利用する方法について説明します。
ms.date: 02/6/2019
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 4fe1f2a51199dd12cd1d285c17c5d48c9a25b969
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654527"
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

Device Portal が有効になると、セクション下部に Web リンクが表示されます。 表示される URL の末尾に付加されたポート番号をメモします。このポート番号は、Device Portal が有効になるとランダムに生成されるものですが、デスクトップを再起動するまで同じ番号を使う必要があります。 

これらのリンクから、ローカル ネットワーク (VPN を含む) 経由、またはローカル ホスト経由のいずれかの方法で Device Portal に接続できます。

### <a name="connect-to-device-portal"></a>Device Portal に接続する

ローカル ホスト経由で接続するには、ブラウザー ウィンドウを開き、使用している接続の種類に関して次に示すアドレスを入力します。

* Localhost:`http://127.0.0.1:<PORT>`または `http://localhost:<PORT>`
* Local Network: `https://<IP address of the desktop>:<PORT>`

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
- Location
- スクラッチ

## <a name="more-device-portal-options"></a>Device Portal のその他のオプション

### <a name="registry-based-configuration-for-device-portal"></a>Device Portal のレジストリ ベースの構成

デバイス ポータルのポート番号 (80、443 など) を選択する場合は、次のレジストリ キーを設定することができます。

-  `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service`
    - `UseDynamicPorts` :必要な DWORD です。 選択したポート番号を保持するには、これを 0 に設定します。
    - `HttpPort` :必要な DWORD です。 Device Portal が HTTP 接続をリッスンするポート番号を指定します。    
    - `HttpsPort` :必要な DWORD です。 Device Portal が HTTPS 接続をリッスンするポート番号を指定します。
    
同じレジストリ キー パスの下で、認証要件をオフにすることもできます。
- `UseDefaultAuthorizer` - `0` 無効の場合、`1`有効になっています。  
    - これによって、各接続の基本認証要件と HTTP から HTTPS へのリダイレクトの両方が制御されます。  
    
### <a name="command-line-options-for-device-portal"></a>Device Portal のコマンド ライン オプション
管理コマンド プロンプトから、Device Portal の各部分を有効にして構成することができます。 実行することができます、最新のビルドでサポートされているコマンドのセットを表示するには `webmanagement /?`

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

## <a name="common-errors-and-issues"></a>一般的なエラーと問題

デバイスのポータルを設定するときに発生する一般的なエラーを次に示します。

### <a name="windowsupdatesearch-returns-invalid-number-of-updates-0x800f0950-cbseinvalidwindowsupdatecount"></a>WindowsUpdateSearch が更新プログラムの無効な数を返します (0x800f0950 CBS_E_INVALID_WINDOWS_UPDATE_COUNT)

Windows 10 のプレリリース版のビルドに開発者パッケージをインストールしようとするとき、このエラーが発生します。 これらのオンデマンドで機能 (FoD) パッケージは Windows 更新プログラムでホストされ、プレリリース ビルドをダウンロードするには、フライトを選択することが必要です。 フライティング適切なビルドおよびリング組み合わせのために、インストールが選択していない場合、ペイロードはダウンロードされません。 次のことを再確認してください。

1. 移動します**設定 > 更新とセキュリティ > Windows Insider Program**いることを確認し、 **Windows Insider アカウント**セクションには、正しいアカウント情報。 そのセクションが表示されない場合は、選択**Windows Insider アカウント リンク**、電子メール アカウントを追加し、現れることを確認、 **Windows Insider アカウント**見出し (を選択する必要があります**Windows Insider アカウント リンク**実際にリンクする、新しく追加されたアカウント時間を秒)。
 
2. **受信にどのような種類のコンテンツを指定しては?**、ことを確認します**Windows のアクティブな開発**が選択されています。
 
3. **新しいビルドを取得する速度ですか?**、ことを確認します**Windows Insider Fast**が選択されています。
 
4. 今すぐできる、FoDs をインストールします。 Windows Insider Fast にいるとまだことはできません、FoDs をインストール、くださいフィードバックを提供を下に、ログ ファイルのアタッチを確認したら場合**C:\Windows\Logs\CBS**します。

### <a name="sc-startservice-openservice-failed-1060-the-specified-service-does-not-exist-as-an-installed-service"></a>[SC]StartService:OpenService FAILED 1060:指定されたサービスがインストールされているサービスとして存在しません

開発者のパッケージがインストールされていない場合、このエラーが発生します。 せず、開発者のパッケージは、web 管理サービスはありません。 開発者のパッケージをもう一度インストールしてください。

### <a name="cbs-cannot-start-download-because-the-system-is-on-metered-network-cbsemeterednetwork"></a>システムが従量制課金接続 (CBS_E_METERED_NETWORK) 上にあるために、CBS はダウンロードを開始できません。

従量制インターネット接続の場合、このエラーが発生します。 従量制課金接続で開発者パッケージをダウンロードすることはできません。

## <a name="see-also"></a>関連項目

* [Windows Device Portal の概要](device-portal.md)
* [デバイス ポータル core API リファレンス](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)
