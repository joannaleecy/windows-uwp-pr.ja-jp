---
title: Fiddler を使用した Xbox Live のトラブルシューティング
author: KevinAsgari
description: Fiddler を使って Xbox Live サービス呼び出しをトラブルシューティングする方法について説明します。
ms.assetid: 7d76e444-027b-4659-80d5-5b2bf56d199e
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, fiddler, サービス呼び出し, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: e8d1acabbf6059b8a5989a471c01d98243e53fb4
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6199416"
---
# <a name="troubleshooting-xbox-live-using-fiddler"></a>Fiddler を使用した Xbox Live のトラブルシューティング

Fiddler は、デバイスとインターネットの間のすべての HTTP および HTTPS トラフィックをログに記録する Web デバッグ プロキシです。 これを使用して Xbox Live サービスおよび証明書利用者 Web サービスとの間のトラフィックをログに記録および検査して、Web サービス呼び出しを把握し、デバッグします。

## <a name="for-windows-uwp-pc-apps"></a>Windows UWP PC アプリの場合

1. 現在のユーザーが、PC の Administrator グループのメンバーであることを確認します
1. Fiddler からのダウンロードします。[http://www.telerik.com/fiddler](http://www.telerik.com/fiddler)
1. "Built for .NET 4" のバージョンを選択します
1. インストールが済んだら、[Tools] の [Fiddler Options] で、[Capture HTTPS CONNECTs] と [Decrypt HTTPS traffic] を有効にします。  ランタイムと Xbox Live サービスの間の通信はすべて、SSL で暗号化されます。  このオプションを指定しないと、役に立つ情報は何も得られません。  Fiddler のすべてのポップアップ ダイアログを受け入れます (UAC を含めて 5 個のダイアログが表示されるはずです)。
1. [WinConfig]、[Exempt All]、[Save Changes] の順に移動します。  このようにしないと、Fiddler はストア アプリで動作しません。
1. アプリを実行すると、アプリ、ランタイム、Xbox Live の間の要求/応答が表示されます。

通常は必要ないが、サインインおよびゲーム内イベントのデバッグ時に役立つ UWP OS レベルの呼び出しをデバッグするには、WinHTTP トラフィックをキャプチャするように Fiddler を構成する必要があります。
このためには、次のようにします。
```cpp
    netsh winhttp set proxy 127.0.0.1:8888 "<-loopback>"
```
ここで、ポート 8888 は Fiddler の [Tools] | [Options] | [Connections] タブで構成したポートに一致します (既定値は 8888)。
これを取り消すには、次のようにします。
```cpp
    netsh winhttp reset proxy
```

## <a name="for-xbox-one-uwp-based-projects"></a>Xbox One UWP ベースのプロジェクトの場合

次の手順に従います[https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/uwp-fiddler](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/uwp-fiddler)

## <a name="for-xbox-one-xdk-based-projects"></a>Xbox One XDK ベースのプロジェクトの場合

通常の操作では、プロキシ経由で通信するコンソールは、プロキシによって通信内容が変更されるリスクがあり、プレイヤーによる不適切な行為が発生する可能性があります。 そのため、コンソールはプロキシ経由の通信を許可しないように設計されています。 Xbox One 開発機で Fiddler を使うには、Fiddler プロキシの使用を許可するように、開発機で特別な構成手順を実行する必要があります。

Fiddler はフリーウェアであり、[Fiddler の Web サイト](http://www.telerik.com/fiddler/)からダウンロードできます。

Fiddler は、コンソールで報告されるネットワーク ステータスに影響を与える場合があります。 Fiddler を実行しているコンピューターからのアップストリーム接続が無効になっている場合、コンソールの認証の有効期限が切れるまで、コンソールでこの切断が検出されない可能性があります。 Fiddler を使っている場合、Fiddler を使って切断をシミュレートするのではなく、必ずコンソールと Fiddler を実行しているコンピューターとの接続を切断してください。 もっと良いのは、ネットワーク負荷ツールを使用して、テストのために切断をシミュレートすることです。

開発用 PC への Fiddler のインストールと有効化

Fiddler をインストールして有効化し、開発キットからのトラフィックを監視するには、以下の手順に従います。

1. [Fiddler の Web サイト](http://www.telerik.com/fiddler/)に示されている手順に従って、開発用 PC に Fiddler をインストールします。
1. Fiddler を起動し、[Tools] メニューの [Fiddler Options] を選択します。
1. [Connections] タブを選択し、[Allow remote computers to connect] チェック ボックスがオンになっていることを確認します。
1. [OK] をクリックして設定の変更を確認します。 ダイアログ ボックスが表示され、変更を有効にするには Fiddler を再起動する必要があり、ファイアウォールを手動で構成することが必要になる可能性があるというメッセージが表示されます。 このダイアログ ボックスで [OK] をクリックしますが、まだ Fiddler を再起動しないでください。
1. リモート コンピューターに接続を許可するために必要なファイアウォール規則を構成します。 Windows ファイアウォール コントロール パネル アプレットを起動します。 [詳細設定]、[受信の規則] の順にクリックします。 "FiddlerProxy" という名前の規則を探し、右にスクロールして、この規則の設定値が以下のとおりであることを確認します。

| 設定          | 推奨値                |
|------------------|--------------------------------|
| 名前             | FiddlerProxy                   |
| Group            | (グループの値は設定しない) |
| Profile          | すべて                            |
| 有効          | はい                            |
| 操作           | 許可                          |
| 優先         | いいえ                             |
| プログラム          | fiddler.exe のパス            |
| ローカル アドレス     | 任意                            |
| リモート アドレス    | 任意                            |
| プロトコル         | TCP                            |
| ローカル ポート        | 任意                            |
| リモート ポート       | 任意                            |
| 承認されているユーザー     | 任意                            |
| 承認されているコンピューター | 任意                            |


1. HTTPS トラフィックをキャプチャーおよび復号化するために Fiddler を構成します。
    1. 最適なパフォーマンスを実現するために、ボタン バーの [Stream] ボタンをクリックして、ストリーミング モードを使用するように Fiddler を設定します。
    1. Fiddler で、[Tools]、[Fiddler Options]、[HTTPS] の順に選択します。
    1. [Decrypt HTTPS traffic] チェック ボックスをオンにします。 CA 証明書を信頼するように Windows を構成するかどうかの確認に対して [No] をクリックします。
    1. [Export Root Certificate to Desktop] ボタンをクリックします。
1. Fiddler を終了し、再び起動します。

### <a name="to-configure-a-dev-kit-to-use-fiddler-as-its-proxy-to-the-internet"></a>インターネットへのプロキシとして Fiddler を使用するように開発機を構成するには
開発キットでの Fiddler の構成方法は、以前のリリースで使用されていたものよりも簡素化されています。

1. デスクトップにエクスポートした Fiddler ルート証明書を、開発キットに ``` xs:\Microsoft\Cert\FiddlerRoot.cer``` としてコピーします。  次のコマンドを使用できます。  ```xbcp [local Fiddler Root directory]\FiddlerRoot.cer xs:\Microsoft\Cert\FiddlerRoot.cer```
1. ```ProxyAddress.txt``` という名前のテキスト ファイルを作成し、そのファイルに、Fiddler を実行する開発用 PC の IP アドレスまたはホスト名と、Fiddler が唯一のコンテンツとしてリッスンするポート番号を記述します。 ホスト名または IP アドレスとポートは "HOST:PORT" の書式にします  (既定では、Fiddler はポート 8888 を使用)。たとえば、"10.124.220.250:8888" や "my_dev_pc.contoso.com:8888" などです。 このファイルを開発キットに xs:\Microsoft\Fiddler\ProxyAddress.txt としてコピーします。  次のコマンドを使用できます。  ```xbcp [local Proxy Address file directory]\ProxyAddress.txt xs:\Microsoft\Fiddler\ProxyAddress.txt```
1. コマンド プロンプトで「```xbreboot```」と入力して開発キットを再起動します。

### <a name="to-stop-using-fiddler"></a>Fiddler の使用を停止するには

Fiddler をインターネットへのプロキシとして使用して Fiddler で開発キットのすべてのネットワーク トラフィックをトレースすることを停止するには、開発キット上の FiddlerRoot.cer ファイルの名前を変更するか、または削除して、開発キットを再起動するだけです。

### <a name="how-it-works"></a>方法

起動時に xs:\Microsoft\Cert\FiddlerRoot.cer ファイルおよび xs:\Microsoft\Fiddler\ProxyAddress.txt ファイルの両方が存在している場合、開発キットは ProxyAddress.txt で指定されたプロキシ サーバーを使用するように自動的に構成されます。 どちらかのファイルが存在しない場合、開発キットは Fiddler プロキシ経由で動作するように構成されません。

Fiddler がインストールされている各 PC では、異なる Fiddler ルート証明書を使用します。 開発キットに Fiddler プロキシを提供するために使用できる PC が複数ある場合は、各 PC の Fiddler ルート証明書を xs:\Microsoft\Cert ディレクトリにコピーすることができます。ただし、それらのうちの 1 つが FiddlerRoot.cer という名前である必要があります。 Fiddler プロキシが認証されるときに、Cert ディレクトリ内のすべての証明書がチェックされます。 ProxyAddress.txt に含まれるどの PC のアドレスの Fiddler インスタンスでも、その証明書が Cert ディレクトリ内に存在していれば、プロキシとして使用されます。
