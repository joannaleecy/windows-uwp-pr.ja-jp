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
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2916759"
---
# <a name="provision-device-portal-with-a-custom-ssl-certificate"></a>カスタムの SSL 証明書で Device Portal をプロビジョニングする
Windows 10 更新プログラムの作成者では、Windows デバイス ポータルは、HTTPS 通信で使用するカスタムの証明書をインストールするのにはデバイスの管理者を追加します。 

自分の PC でこれを行うことができます、中に既存の証明書インフラストラクチャを適切に実装する企業向けのこの機能は、ほとんどの場合。  

たとえば、会社には、HTTPS 経由で提供されたイントラネット web サイトの証明書に署名するために使用する証明機関 (CA) があります。 この機能をインフラストラクチャに意味します。 

## <a name="overview"></a>概要
既定は、デバイスのポータルは、自己署名されたルート CA を生成し、待機しているすべてのエンドポイントの SSL 証明書に署名を使用しています。 これが含まれています`localhost`、 `127.0.0.1`、および`::1`(IPv6 ローカル ホスト)。

デバイスのホスト名も含まれています (たとえば、 `https://LivingRoomPC`) およびデバイスに割り当てられている各リンク ローカル IP アドレス (を 2 つ [IPv4、IPv6] ネットワーク アダプターごと)。 デバイスのポータルのネットワーク ツールを参照して、デバイスのリンク ローカル IP アドレスを表示できます。 開始`10.`または`192.`ipv4 の場合、または`fe80:`IPv6 のためです。 

既定の設定、証明書の警告がルート CA が信頼されていないため、ブラウザーで表示されます。 具体的には、デバイスのポータルによって提供されている SSL 証明書は、ブラウザーや PC は信頼できる ca によって署名されています。 これは、新しい信頼されたルート CA を作成することによって修正されることができます。

## <a name="create-a-root-ca"></a>ルート CA を作成します。

これは会社 (または自宅) は、証明書インフラストラクチャをされていない場合にのみ行う必要があり、一度だけ実行する必要があります。 次の PowerShell スクリプトは、 _WdpTestCA.cer_と呼ばれる CA ルートを作成します。 このファイルをローカル コンピューターの信頼されたルート証明機関をインストールすると、このルート CA によって署名された SSL 証明書を信頼するようにデバイスが発生します。 (したりする必要があります) をインストールする Windows のデバイスのポータルに接続する各コンピューター上には、この .cer ファイル。  

```PowerShell
$CN = "PickAName"
$OutputPath = "c:\temp\"

# Create root certificate authority
$FilePath = $OutputPath + "WdpTestCA.cer"
$Subject =  "CN="+$CN
$rootCA = New-SelfSignedCertificate -certstorelocation cert:\currentuser\my -Subject $Subject -HashAlgorithm "SHA512" -KeyUsage CertSign,CRLSign
$rootCAFile = Export-Certificate -Cert $rootCA -FilePath $FilePath
```

これが作成されると、SSL 証明書に署名するのに_WdpTestCA.cer_ファイルを使用できます。 

## <a name="create-an-ssl-certificate-with-the-root-ca"></a>ルート CA からの SSL 証明書を作成します。

SSL 証明書がある 2 つの重要な機能: 暗号化を使用して接続をセキュリティで保護して、ブラウザーのバーに表示されるアドレスと実際に通信しているかを確認 (Bing.com、192.168.1.37 など)、悪意のあるサードパーティ製ではありません。

次の PowerShell スクリプト用の SSL 証明書の作成、`localhost`エンドポイントです。 ポータルのデバイスがリッスンするエンドポイントごとに必要な独自の証明書です。置き換えることができます、 `$IssuedTo` 、デバイスのさまざまなエンドポイントの各スクリプトの引数: ホスト名、ローカル ホスト、および、IP アドレスです。

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

複数のデバイスがある場合は、localhost の .pfx ファイルを再利用することができますが、各デバイスの IP アドレスとホスト名の証明書を個別に作成する必要があります。

.Pfx ファイルのバンドルを生成する場合は、Windows デバイスのポータルにそれらをロードする必要があります。 

## <a name="provision-device-portal-with-the-certifications"></a>プロビジョニング デバイスのポータル、しないと

.Pfx、ファイルごとに作成したデバイスの管理者特権のコマンド プロンプトから次のコマンドを実行する必要があります。

```
WebManagement.exe -SetCert <Path to .pfx file> <password for pfx> 
```

などの使用状況の下を参照してください。
```
WebManagement.exe -SetCert localhost.pfx PickAPassword
WebManagement.exe -SetCert --1.pfx PickAPassword
WebManagement.exe -SetCert MyLivingRoomPC.pfx PickAPassword
```

証明書をインストールした後は、単にサービスを再起動して変更を反映できるようにします。

```
sc stop webmanagement
sc start webmanagement
```

> [!TIP]
> IP アドレスは、時間の経過とともに変更できます。
多くのネットワークでは、デバイスが同じ IP アドレスが以前にあったことを常に取得しないように、IP アドレスを DHCP を使用します。 デバイス上の IP アドレス用の証明書を作成し、デバイスのアドレスが変更された場合は、Windows デバイスのポータルは、既存の自己署名証明書を使用して新しい証明書を生成し、作成したものを使用して停止します。 お使いのブラウザーで再度表示するのには証明書の警告] ページになります。 このため、それらのホスト名は、ポータルでデバイスを設定することができますから、デバイスへの接続をお勧めします。 これらは常に同一の IP アドレスに関係なく。
