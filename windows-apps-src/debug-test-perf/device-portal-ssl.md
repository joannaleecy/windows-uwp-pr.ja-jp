---
author: PatrickFarley
ms.assetid: e04ebe3f-479c-4b48-99d8-3dd4bb9bfaf4
title: カスタムの SSL 証明書で Device Portal をプロビジョニングする
description: TBD
ms.author: pafarley
ms.date: 07/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、デバイスのポータル
ms.localizationpriority: medium
ms.openlocfilehash: 1192c200cd42ab28cc7e763c06fd8a5638aa3400
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2834491"
---
# <a name="provision-device-portal-with-a-custom-ssl-certificate"></a>カスタムの SSL 証明書で Device Portal をプロビジョニングする
Windows 10 の作成者 Update では、Windows デバイス ポータルは、HTTPS 通信で使用するカスタム証明書をインストールするデバイス管理者を追加します。 

独自の PC にこれを行うことができます、中に場所で既存の証明書インフラストラクチャはある企業向けのこの機能は、ほとんどの場合。  

たとえば、会社には、https served イントラネットの web サイトの証明書のサインインに使用する証明機関 (CA) があります。 この機能にインフラストラクチャを意味します。 

## <a name="overview"></a>概要
既定では、デバイス ポータルは、CA、自己署名のルートを生成し、待機しているすべてのエンドポイントの SSL 証明書に署名を使用しています。 これが含まれています`localhost`、 `127.0.0.1`、および`::1`(IPv6 ローカル ホスト)。

デバイスのホスト名も含まれています (たとえば、 `https://LivingRoomPC`) とデバイスに割り当てられている各リンク ローカル IP アドレス (最大 2 [IPv4、IPv6] ネットワーク アダプターごと)。 デバイス ポータルで、ネットワークのツールを見て、デバイスのリンク ローカル IP アドレスを表示できます。 開始`10.`または`192.`ipv4、または`fe80:`ipv6 します。 

既定の設定、証明書の警告が信頼されている ca の理由により、ブラウザーで表示されます。 具体的には、デバイスのポータルで提供された SSL 証明書は、ルート ブラウザーまたは PC が信頼しない CA によって署名されています。 新しい信頼できるルート CA を作成して、これが修正されることができます。

## <a name="create-a-root-ca"></a>ルート CA を作成します。

これにより、会社 (またはホーム) は、セットアップ、証明書のインフラストラクチャがあるない場合にのみ実行され、1 回のみ実行する必要があります。 次の PowerShell スクリプトでは、ルート_WdpTestCA.cer_と呼ばれる CA を作成します。 このファイルをローカル コンピューターの信頼できるルート証明機関にインストールするには、この ca によって署名されている SSL 証明書を信頼するデバイスによって発生します。 できます (とする必要があります) をインストールする Windows デバイス ポータルに接続する各コンピューター上には、この .cer ファイル。  

```PowerShell
$CN = "PickAName"
$OutputPath = "c:\temp\"

# Create root certificate authority
$FilePath = $OutputPath + "WdpTestCA.cer"
$Subject =  "CN="+$CN
$rootCA = New-SelfSignedCertificate -certstorelocation cert:\currentuser\my -Subject $Subject -HashAlgorithm "SHA512" -KeyUsage CertSign,CRLSign
$rootCAFile = Export-Certificate -Cert $rootCA -FilePath $FilePath
```

これが作成、SSL 証明書の署名に_WdpTestCA.cer_ファイルを使用することができます。 

## <a name="create-an-ssl-certificate-with-the-root-ca"></a>ルート CA と SSL 証明書を作成します。

SSL 証明書は、次の 2 つの重要な機能を持つ: 暗号化を使用する接続をセキュリティで保護して、ブラウザーのバーに表示されるアドレスを使って通信する実際に確認する (Bing.com、192.168.1.37 など) と悪意のあるサードパーティされません。

次の PowerShell スクリプトの SSL 証明書を作成する、`localhost`エンドポイントします。 ポータルのデバイスがリッスンする各端点に固有の証明書が必要があります。置き換えることができます、`$IssuedTo`お使いのデバイスで別の端点の各スクリプトで引数: [ホスト名、ローカル ホスト、および IP アドレスします。

```PowerShell
$IssuedTo = "localhost"
$Password = "PickAPassword"
$OutputPath = "c:\temp\"
$rootCA = Import-Certificate -FilePath C:\temp\WdpTestCA.cer -CertStoreLocation Cert:\CurrentUser\My\

# Create SSL cert signed by certificate authority
$IssuedToClean = $IssuedTo.Replace(":", "-").Replace(" ", "_")
$FilePath = $OutputPath + $IssuedToClean + ".pfx"
$Subject = "CN="+$IssuedTo
$cert = New-SelfSignedCertificate -certstorelocation cert:\localmachine\my -Subject $Subject -DnsName $IssuedTo -Signer $rootCA -HashAlgorithm "SHA512"
$certFile = Export-PfxCertificate -cert $cert -FilePath $FilePath -Password (ConvertTo-SecureString -String $Password -Force -AsPlainText)
```

複数のデバイスを使っている場合、ローカル ホスト .pfx ファイルを再利用することができますが、デバイスごとに IP アドレスとホスト名の証明書を個別に作成する必要があります。

.Pfx ファイルのバンドルを生成する場合は、Windows デバイス ポータルへのロードする必要があります。 

## <a name="provision-device-portal-with-the-certifications"></a>プロビジョニング デバイス ポータル、しません。

各 .pfx ファイルに対して作成したデバイス用には、管理者特権のコマンド プロンプトから、次のコマンドを実行する必要があります。

```
WebManagement.exe -SetCert <Path to .pfx file> <password for pfx> 
```

使用例の下を参照してください。
```
WebManagement.exe -SetCert localhost.pfx PickAPassword
WebManagement.exe -SetCert --1.pfx PickAPassword
WebManagement.exe -SetCert MyLivingRoomPC.pfx PickAPassword
```

証明書のインストールが完了したら、だけで、変更を反映するようにサービスを再起動します。

```
sc stop webmanagement
sc start webmanagement
```

> [!TIP]
> 時間の経過 IP アドレスを変更できます。
多くのネットワークでは、DHCP を使用して、デバイスが以前はあったが同じ IP アドレスを常に取得されないように、IP アドレスを入力します。 デバイスの IP アドレスの証明書を作成した、デバイスのアドレスが変更されている場合は、Windows デバイス ポータルには、既存の自己署名証明書を使用して、新しい証明書は生成し、作成した 1 つの使用を停止します。 これは、結果、証明書の警告] ページをもう一度お使いのブラウザーで表示します。 このため、デバイス ポータルで設定することができますが、ホスト名からデバイスへの接続をお勧めします。 IP アドレスに関係なく、同じこれらが残ります。
