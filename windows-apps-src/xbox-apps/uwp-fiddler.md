---
author: WilliamsJason
title: UWP を開発するときに Xbox One で Fiddler を使用する方法
description: フリーウェアの Fiddler ツールを使って、UWP Xbox One 開発機でのネットワーク トラフィックを確認する方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 9c133c77-fe9d-4b81-b4b3-462936333aa3
ms.localizationpriority: medium
ms.openlocfilehash: 9b0c91c2e7fa6e3076e53b0d3ae2e8d3713c81c5
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6983644"
---
# <a name="how-to-use-fiddler-with-xbox-one-when-developing-for-uwp"></a>UWP を開発するときに Xbox One で Fiddler を使用する方法

Fiddler は、Xbox One 開発機とインターネットの間のすべての HTTP および HTTPS トラフィックをログに記録する Web デバッグ プロキシです。 Fiddler を使って、Xbox サービスと証明書利用者 Web サービスとの間のトラフィックをログに記録し、Web サービスの呼び出しを確認してデバッグします。 

通常の操作では、プロキシ経由で通信するコンソールは、プロキシによって通信内容が変更されるリスクがあり、プレイヤーによる不適切な行為が発生する可能性があります。 そのため、コンソールはプロキシ経由の通信を許可しないように設計されています。 Xbox One 開発機で Fiddler を使うには、Fiddler プロキシの使用を許可するように、開発機で特別な構成手順を実行する必要があります。 

Fiddler はフリーウェアであり、[Fiddler の Web サイト](http://www.fiddler2.com/fiddler2/)からダウンロードできます。 

Fiddler は、コンソールで報告されるネットワーク ステータスに影響を与える場合があります。 Fiddler を実行しているコンピューターからのアップストリーム接続が無効になっている場合、コンソールの認証の有効期限が切れるまで、コンソールでこの切断が検出されない可能性があります。 Fiddler を使っている場合、Fiddler を使って切断をシミュレートするのではなく、必ずコンソールと Fiddler を実行しているコンピューターとの接続を切断してください。

### <a name="to-install-and-enable-fiddler-on-your-development-pc"></a>開発用 PC に Fiddler をインストールして有効にするには
次の手順に従って、Fiddler をインストールし、有効にして、開発機からのトラフィックを監視します。

1. [Fiddler の Web サイト](http://www.fiddler2.com/fiddler2/)に示されている手順に従って、開発用 PC に Fiddler をインストールします。 
2. Fiddler を起動し、**[Tools]** メニューの **[Fiddler Options]** を選択します。 
3. **[Connections]** タブを選択し、**[Allow remote computers to connect]** がオンになっていることを確認します。 
4. **[OK]** をクリックして設定の変更を確認します。 ダイアログ ボックスが表示され、変更を有効にするには Fiddler を再起動する必要があり、ファイアウォールを手動で構成することが必要になる可能性があるというメッセージが表示されます。 このダイアログ ボックスで **[OK]** をクリックしますが、*まだ Fiddler を再起動しないでください*。
5. リモート コンピューターに接続を許可するために必要なファイアウォール規則を構成します。 Windows ファイアウォール コントロール パネル アプレットを起動します。 **[詳細設定]**、**[受信の規則]** の順にクリックします。 "FiddlerProxy" という名前の規則を探し、右へスクロールして、この規則の各設定が次の表の設定と一致していることを確認します。
  
  | 設定           | 推奨値                |
  | ----              | ----                           |
  | 名前              | FiddlerProxy                   |
  | グループ             | *値なし* |
  | プロファイル           | すべて                            |
  | 有効           | はい                            |
  | 操作            | 許可                          |
  | 優先          | いいえ                             |
  | プログラム           | *Fiddler.exe へのパス*          |
  | ローカル アドレス      | 任意                            |
  | リモート アドレス     | 任意                            |
  | プロトコル          | TCP                            |
  | ローカル ポート         | 任意                            |
  | リモート ポート        | 任意                            |
  | 承認されているユーザー      | 任意                            |
  | 承認されているコンピューター  | 任意                            |


6. 次の手順に従って、HTTPS トラフィックのキャプチャして暗号化を解除するように Fiddler を構成します。
  1. 最適なパフォーマンスを実現するために、ボタン バーの **[Stream]** ボタンをクリックして、ストリーミング モードを使用するように Fiddler を設定します。
  2. Fiddler の **[Tools]** メニューで、**[Fiddler Options]** を選んで **[HTTPS]** をクリックします。
  3. **[Decrypt HTTPS traffic]** チェック ボックスをオンにします。 Windows で CA 証明書を信頼するかどうかを確認するダイアログ ボックスが表示された場合は、**[No]** をクリックします。
  4. **[Export Root Certificate to Desktop]** をクリックします。
7. Fiddler を終了して再起動します。

### <a name="to-configure-a-dev-kit-to-use-fiddler-as-its-proxy-to-the-internet"></a>インターネットへのプロキシとして Fiddler を使用するように開発機を構成するには

1. Xbox Device Portal の UI で**ネットワーク** ツールに移動します。
2. デスクトップにエクスポートした Fiddler のルート証明書を参照します。 
3. Fiddler を実行している開発用 PC の IP アドレスまたはホスト名を入力します。
4. Fiddler がリッスンしているポート番号 (既定では、Fiddler はポート 8888 を使用) を入力します。 
5. **[Enable]** をクリックします。 これにより、開発キットが再起動します。

### <a name="to-stop-using-fiddler"></a>Fiddler の使用を停止するには
インターネットへのプロキシとしての Fiddler の使用を停止 (し、Fiddler による開発機のすべてのネットワーク トラフィックのトレースを停止) するには、次の操作を行います。

1. Xbox Device Portal の UI で**ネットワーク** ツールに移動します。
2. **[無効]** をクリックします。

> [!NOTE]
> Fiddler がインストールされている各 PC では、異なる Fiddler ルート証明書を使用します。 開発機に Fiddler プロキシを提供するために、複数の PC を使用する可能性がある場合は、PC を切り替えたときに新しいルート証明書を選択する必要があります。 1 台の PC のみを使用している場合は、最初に Fiddler を有効にするときにのみルート証明書を選択する必要があります。 この場合も、IP アドレスとポートを指定する必要があります。

## <a name="see-also"></a>関連項目
- [Fiddler 設定 API のリファレンス](wdp-fiddler-api.md)
- [よく寄せられる質問](frequently-asked-questions.md)
- [Xbox One の UWP](index.md)



