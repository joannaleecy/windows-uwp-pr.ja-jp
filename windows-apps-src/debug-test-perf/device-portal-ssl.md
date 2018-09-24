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
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 1192c200cd42ab28cc7e763c06fd8a5638aa3400
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4148297"
---
# <a name="provision-device-portal-with-a-custom-ssl-certificate"></a>カスタムの SSL 証明書で Device Portal をプロビジョニングする
Windows 10 の Creators Update では、Windows Device Portal には、デバイスの管理者 HTTPS 通信で使われるカスタム証明書をインストールするための方法が追加されました。 

これを行うには、独自の PC で中、か所で証明書の既存のインフラストラクチャを保有している企業のこの機能は、ほとんどの場合。  

たとえば、企業には、HTTPS 経由で提供されたイントラネット web サイト用の証明書の署名に使われる証明書機関 (CA) があります。 この機能にインフラストラクチャを意味します。 

## <a name="overview"></a>概要
既定では、Device Portal は自己署名されたルート CA が生成され、使用して、待機しているすべてのエンドポイントの SSL 証明書に署名します。 ここでは`localhost`、 `127.0.0.1`、および`::1`(IPv6 localhost)。

デバイスのホスト名も含まれています (たとえば、 `https://LivingRoomPC`) と、デバイスに割り当てられている各リンク ローカル IP アドレス (最大で 2 つ [IPv4] IPv6 ネットワーク アダプターあたり)。 Device Portal のネットワー キング ツールを見ているによって、デバイスのリンク ローカル IP アドレスを確認できます。 作業を始めますが`10.`または`192.`ipv4、または`fe80:`IPv6 用です。 

既定の設定、信頼されていないルート CA があるためのブラウザーで証明書の警告が表示されます。 具体的には、Device Portal によって提供される SSL 証明書は、ルートのブラウザーまたは PC が信頼できない CA によって署名されています。 これは、新しい信頼されたルート CA を作成して修正できます。

## <a name="create-a-root-ca"></a>ルート CA を作成します。

これにより、会社 (またはホーム) は、セットアップ、証明書のインフラストラクチャがあるない場合にのみ行ってくださいされ、1 回だけ実行する必要があります。 次の PowerShell スクリプトは、ルート CA _WdpTestCA.cer_と呼ばれるを作成します。 ローカル コンピューターの信頼されたルート証明機関にこのファイルをインストールすると、このルート CA によって署名されている SSL 証明書を信頼するためにデバイスが発生します。 できます (および必要があります) をインストールする各 PC に Windows Device Portal に接続するのには、この .cer ファイル。  

```PowerShell
$CN = "PickAName"
$OutputPath = "c:\temp\"

# Create root certificate authority
$FilePath = $OutputPath + "WdpTestCA.cer"
$Subject =  "CN="+$CN
$rootCA = New-SelfSignedCertificate -certstorelocation cert:\currentuser\my -Subject $Subject -HashAlgorithm "SHA512" -KeyUsage CertSign,CRLSign
$rootCAFile = Export-Certificate -Cert $rootCA -FilePath $FilePath
```

これを作成した後は、SSL 証明書の署名に_WdpTestCA.cer_ファイルを使用することができます。 

## <a name="create-an-ssl-certificate-with-the-root-ca"></a>ルート CA と SSL 証明書を作成します。

SSL 証明書がある 2 つの重要な機能: 安全な接続を暗号化を使用し、ブラウザーのバーに表示されるアドレスと通信して実際に確認する (Bing.com、192.168.1.37 など) と悪意のあるサード パーティではありません。

次の PowerShell スクリプトの SSL 証明書の作成、`localhost`エンドポイントです。 Device Portal がリッスンする各エンドポイントには、独自の証明書が必要があります。要素に置き換えること、`$IssuedTo`お使いのデバイスのさまざまなエンドポイントのそれぞれで、スクリプト内の引数: ホスト名、ローカル ホスト、および IP アドレスです。

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

複数のデバイスを使っている場合、localhost .pfx ファイルを再利用することができますが、個別に各デバイスの IP アドレスやホスト名の証明書を作成する必要があります。

.Pfx ファイルのバンドルの生成時に Windows Device Portal に読み込む必要があります。 

## <a name="provision-device-portal-with-the-certifications"></a>Device Portal の認定をプロビジョニング

各 .pfx ファイルの作成したデバイスの場合、管理者特権のコマンド プロンプトから次のコマンドを実行する必要があります。

```
WebManagement.exe -SetCert <Path to .pfx file> <password for pfx> 
```

使用例以下をご覧ください。
```
WebManagement.exe -SetCert localhost.pfx PickAPassword
WebManagement.exe -SetCert --1.pfx PickAPassword
WebManagement.exe -SetCert MyLivingRoomPC.pfx PickAPassword
```

証明書をインストールした後、サービスを再起動するだけで変更を反映するようにします。

```
sc stop webmanagement
sc start webmanagement
```

> [!TIP]
> IP アドレスは、時間の経過と共に変更できます。
多くのネットワークでは、DHCP を使用しているため、デバイスしない常にあった以前と同じ IP アドレス、IP アドレスを提供します。 デバイスの IP アドレス用の証明書を作成したら、デバイスのアドレスが変更された場合 Windows Device Portal は既存の自己署名証明書を使用して、新しい証明書を生成し、作成した 1 つの使用は停止します。 証明書の警告ページをブラウザーでもう一度表示になります。 このため、Device Portal で設定できますが、ホスト名をデバイスへの接続をお勧めします。 IP アドレスに関係なく同じこれらが残ります。
