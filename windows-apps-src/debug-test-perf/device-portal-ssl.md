---
ms.assetid: e04ebe3f-479c-4b48-99d8-3dd4bb9bfaf4
title: カスタムの SSL 証明書で Device Portal のプロビジョニングを行う
description: HTTPS 通信で使用するためのカスタム証明書で Windows Device Portal をプロビジョニングする方法について説明します。
ms.date: 04/19/2019
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.custom: 19H1
ms.openlocfilehash: ce4e45bc23f4efb636618bb4891b9d6e9d207490
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63774141"
---
# <a name="provision-device-portal-with-a-custom-ssl-certificate"></a>カスタムの SSL 証明書で Device Portal のプロビジョニングを行う

Windows 10 Creators Update では、Windows Device Portal によって、デバイス管理者が HTTPS 通信で使用できるカスタム証明書のインストール手段が追加されています。

自身の PC で行うこともできますが、この機能は主に、既存の証明書インフラストラクチャを使用している企業を対象としています。  

たとえば、HTTPS で使用するイントラネット Web サイト用の証明書に署名するために、企業で証明機関 (CA) を保有している場合があります。 この機能は、そのようなインフラストラクチャ上で使用します。

## <a name="overview"></a>概要

既定では、Device Portal は自己署名ルート CA を生成し、これを使用して、リッスン対象のすべてのエンドポイント用に SSL 証明書への署名を行います。 これには、`localhost`、`127.0.0.1`、`::1` (IPv6 localhost) が含まれます。

また、デバイスのホスト名 (`https://LivingRoomPC` など) と、デバイスに割り当てられた各リンク ローカル IP アドレス (ネットワーク アダプターごとに最大 2 つの [IPv4, IPv6]) も含まれます。
デバイスのリンク ローカル IP アドレスは、Device Portal のネットワーク ツールで確認できます。 アドレスの先頭は、IPv4 の場合は `10.` または `192.`、IPv6 の場合は `fe80:` になります。

既定のセットアップの場合、信頼されていないルート CA が原因で、証明書警告がブラウザーに表示されることがあります。 具体的には、Device Portal によって提供される SSL 証明書は、ブラウザーまたは PC が信頼していないルート CA によって署名されています。 この問題は、新しい信頼されたルート CA を作成することで対処できます。

## <a name="create-a-root-ca"></a>ルート CA を作成する

この処理は、会社 (または家庭) に証明書インフラストラクチャがセットアップされていない場合にのみ、1 回だけ実行してください。 次の PowerShell スクリプトでは、_WdpTestCA.cer_ というルート CA を作成します。 このファイルをローカル コンピューターの [信頼されたルート証明機関] にインストールすると、このルート CA で署名した SSL 証明書がデバイスによって信頼されるようになります。 この .cer ファイルは、Windows Device Portal に接続する予定のある各 PC にインストールできます (また、その必要があります)。  

```PowerShell
$CN = "PickAName"
$OutputPath = "c:\temp\"

# Create root certificate authority
$FilePath = $OutputPath + "WdpTestCA.cer"
$Subject =  "CN="+$CN
$rootCA = New-SelfSignedCertificate -certstorelocation cert:\currentuser\my -Subject $Subject -HashAlgorithm "SHA512" -KeyUsage CertSign,CRLSign
$rootCAFile = Export-Certificate -Cert $rootCA -FilePath $FilePath
```

_WdpTestCA.cer_ の作成後は、このファイルを使用して SSL 証明書に署名することができます。

## <a name="create-an-ssl-certificate-with-the-root-ca"></a>ルート CA で SSL 証明書を作成する

SSL 証明書には 2 つの重要な機能があります。1 つは、暗号化による接続の保護、もう 1 つは、悪意のあるサード パーティではなくブラウザー バーに表示されているアドレス (Bing.com、192.168.1.37 など) が実際の通信先であることの確認です。

次の PowerShell スクリプトでは、`localhost` エンドポイントの SSL 証明書を作成します。 Device Portal がリッスンする各エンドポイントには、それぞれの証明書が必要です。スクリプトの `$IssuedTo` 引数は、デバイスの各エンドポイント (ホスト名、ローカルホスト、IP アドレス) に置き換えることができます。

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

複数のデバイスを使用している場合はローカルホストの .pfx ファイルを再利用できますが、これとは別に、各デバイスの IP アドレスとホスト名の証明書を作成する必要があります。

.pfx ファイルのバンドルが生成されたら、これらを Windows Device Portal に読み込む必要があります。

## <a name="provision-device-portal-with-the-certifications"></a>証明書で Device Portal のプロビジョニングを行う

デバイス用に作成した各 .pfx ファイルについて、管理者特権のコマンド プロンプトから、次のコマンドを実行する必要があります。

```cmd
WebManagement.exe -SetCert <Path to .pfx file> <password for pfx>
```

以下の使用例をご覧ください。

```cmd
WebManagement.exe -SetCert localhost.pfx PickAPassword
WebManagement.exe -SetCert --1.pfx PickAPassword
WebManagement.exe -SetCert MyLivingRoomPC.pfx PickAPassword
```

証明書をインストールしたら、変更を反映するためにサービスを再起動します。

```cmd
sc stop webmanagement
sc start webmanagement
```

> [!TIP]
> IP アドレスは、時間の経過に伴って変わることがあります。
多くのネットワークでは、各デバイスに常に以前と同じ IP アドレスが割り当てられることのないように、DHCP によって IP アドレスが提供されています。 デバイス上で IP アドレスに対して証明書を作成した場合、そのデバイスのアドレスが変わると、Windows Device Portal によって既存の自己署名証明書を使用して新しい証明書が生成され、元の証明書の使用が停止されます。 この場合は、ブラウザーに証明書の警告ページがもう一度表示されます。 このため、デバイスにはホスト名で接続することをお勧めします (Device Portal で設定できます)。 IP アドレスが変わっても、ホスト名に変わりはありません。
