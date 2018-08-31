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
ms.sourcegitcommit: 1e5590dd10d606a910da6deb67b6a98f33235959
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/31/2018
ms.locfileid: "3239416"
---
# <a name="provision-device-portal-with-a-custom-ssl-certificate"></a><span data-ttu-id="497ad-104">カスタムの SSL 証明書で Device Portal をプロビジョニングする</span><span class="sxs-lookup"><span data-stu-id="497ad-104">Provision Device Portal with a custom SSL certificate</span></span>
<span data-ttu-id="497ad-105">Windows 10 の Creators Update では、Windows Device Portal には、デバイスの管理者を HTTPS 通信で使われるカスタム証明書をインストールするための方法が追加されました。</span><span class="sxs-lookup"><span data-stu-id="497ad-105">In the Windows 10 Creators Update, Windows Device Portal added a way for device administrators to install a custom certificate for use in HTTPS communication.</span></span> 

<span data-ttu-id="497ad-106">自分の PC でこれを行うことができます、中に場所には既存の証明書のインフラストラクチャが含まれている企業向けのこの機能は、ほとんどの場合。</span><span class="sxs-lookup"><span data-stu-id="497ad-106">While you can do this on your own PC, this feature is mostly intended for enterprises that have an existing certificate infrastructure in place.</span></span>  

<span data-ttu-id="497ad-107">たとえば、企業には、HTTPS 経由で提供されたイントラネット web サイト用の証明書の署名に使われる証明書機関 (CA) があります。</span><span class="sxs-lookup"><span data-stu-id="497ad-107">For example, a company might have a certificate authority (CA) that it uses to sign certificates for intranet websites served over HTTPS.</span></span> <span data-ttu-id="497ad-108">この機能にインフラストラクチャを意味します。</span><span class="sxs-lookup"><span data-stu-id="497ad-108">This feature stands on top of that infrastructure.</span></span> 

## <a name="overview"></a><span data-ttu-id="497ad-109">概要</span><span class="sxs-lookup"><span data-stu-id="497ad-109">Overview</span></span>
<span data-ttu-id="497ad-110">既定では、Device Portal は、自己署名されたルート CA を生成し、待機しているすべてのエンドポイントの SSL 証明書に署名を使用しています。</span><span class="sxs-lookup"><span data-stu-id="497ad-110">By default, Device Portal generates a self-signed root CA, and then uses that to sign SSL certificates for every endpoint it is listening on.</span></span> <span data-ttu-id="497ad-111">これには`localhost`、 `127.0.0.1`、および`::1`(IPv6 localhost)。</span><span class="sxs-lookup"><span data-stu-id="497ad-111">This includes `localhost`, `127.0.0.1`, and `::1` (IPv6 localhost).</span></span>

<span data-ttu-id="497ad-112">デバイスのホスト名も含まれています (たとえば、 `https://LivingRoomPC`) と、デバイスに割り当てられている各リンク ローカル IP アドレス (最大で 2 つ [IPv4] IPv6 ネットワーク アダプターあたり)。</span><span class="sxs-lookup"><span data-stu-id="497ad-112">Also included are the device's hostname (for example, `https://LivingRoomPC`) and each link-local IP address assigned to the device (up to two [IPv4, IPv6] per network adaptor).</span></span> <span data-ttu-id="497ad-113">Device Portal で、ネットワークのツールを見ているによって、デバイスのリンク ローカル IP アドレスを確認できます。</span><span class="sxs-lookup"><span data-stu-id="497ad-113">You can see the link-local IP addresses for a device by looking at the Networking tool in Device Portal.</span></span> <span data-ttu-id="497ad-114">作業を始めますが`10.`または`192.`ipv4、または`fe80:`IPv6 のします。</span><span class="sxs-lookup"><span data-stu-id="497ad-114">They'll start with `10.` or `192.` for IPv4, or `fe80:` for IPv6.</span></span> 

<span data-ttu-id="497ad-115">既定の設定、信頼されていないルート CA のためのブラウザーで証明書の警告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="497ad-115">In the default setup, a certificate warning may appear in your browser because of the untrusted root CA.</span></span> <span data-ttu-id="497ad-116">具体的には、Device Portal によって提供される SSL 証明書は、ルートのブラウザーまたは PC が信頼できない CA による署名です。</span><span class="sxs-lookup"><span data-stu-id="497ad-116">Specifically, the SSL cert provided by Device Portal is signed by a root CA that the browser or PC doesn't trust.</span></span> <span data-ttu-id="497ad-117">これは、新しい信頼されたルート CA を作成して修正されることができます。</span><span class="sxs-lookup"><span data-stu-id="497ad-117">This can be fixed by creating a new trusted root CA.</span></span>

## <a name="create-a-root-ca"></a><span data-ttu-id="497ad-118">ルート CA を作成します。</span><span class="sxs-lookup"><span data-stu-id="497ad-118">Create a root CA</span></span>

<span data-ttu-id="497ad-119">これにより、会社 (またはホーム) には、セットアップ、証明書のインフラストラクチャを持っていない場合にのみ実行され、1 回だけ実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="497ad-119">This should only be done if your company (or home) doesn't have a certificate infrastructure set up, and should only be done once.</span></span> <span data-ttu-id="497ad-120">次の PowerShell スクリプトは、ルート CA _WdpTestCA.cer_と呼ばれるを作成します。</span><span class="sxs-lookup"><span data-stu-id="497ad-120">The following PowerShell script creates a root CA called _WdpTestCA.cer_.</span></span> <span data-ttu-id="497ad-121">このファイルをローカル コンピューターの信頼されたルート証明機関をインストールすると、このルート CA によって署名されている SSL 証明書を信頼するデバイスが発生します。</span><span class="sxs-lookup"><span data-stu-id="497ad-121">Installing this file to the local machine's Trusted Root Certification Authorities will cause your device to trust SSL certs that are signed by this root CA.</span></span> <span data-ttu-id="497ad-122">できます (とする必要があります) をインストールする各 PC に Windows Device Portal に接続するのには、この .cer ファイル。</span><span class="sxs-lookup"><span data-stu-id="497ad-122">You can (and should) install this .cer file on each PC that you want to connect to Windows Device Portal.</span></span>  

```PowerShell
$CN = "PickAName"
$OutputPath = "c:\temp\"

# Create root certificate authority
$FilePath = $OutputPath + "WdpTestCA.cer"
$Subject =  "CN="+$CN
$rootCA = New-SelfSignedCertificate -certstorelocation cert:\currentuser\my -Subject $Subject -HashAlgorithm "SHA512" -KeyUsage CertSign,CRLSign
$rootCAFile = Export-Certificate -Cert $rootCA -FilePath $FilePath
```

<span data-ttu-id="497ad-123">これが作成されると、SSL 証明書の署名に_WdpTestCA.cer_ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="497ad-123">Once this is created, you can use the _WdpTestCA.cer_ file to sign SSL certs.</span></span> 

## <a name="create-an-ssl-certificate-with-the-root-ca"></a><span data-ttu-id="497ad-124">ルート CA と SSL 証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="497ad-124">Create an SSL certificate with the root CA</span></span>

<span data-ttu-id="497ad-125">SSL 証明書がある 2 つの重要な機能: 暗号化で接続をセキュリティで保護して、ブラウザーのバーで表示されたアドレスで実際に通信していることを確認 (Bing.com、192.168.1.37 など) と悪意のあるサード パーティではありません。</span><span class="sxs-lookup"><span data-stu-id="497ad-125">SSL certificates have two critical functions: securing your connection through encryption and verifying that you are actually communicating with the address displayed in the browser bar (Bing.com, 192.168.1.37, etc.) and not a malicious third party.</span></span>

<span data-ttu-id="497ad-126">次の PowerShell スクリプトの SSL 証明書を作成する、`localhost`エンドポイント。</span><span class="sxs-lookup"><span data-stu-id="497ad-126">The following PowerShell script creates an SSL certificate for the `localhost` endpoint.</span></span> <span data-ttu-id="497ad-127">Device Portal がリッスンする各エンドポイントには、独自の証明書が必要があります。要素に置き換えること、`$IssuedTo`デバイスのさまざまなエンドポイントのそれぞれで、スクリプト内の引数: ホスト名、ローカル ホスト、および IP アドレスします。</span><span class="sxs-lookup"><span data-stu-id="497ad-127">Each endpoint that Device Portal listens on needs its own certificate; you can replace the `$IssuedTo` argument in the script with each of the different endpoints for your device: the hostname, localhost, and the IP addresses.</span></span>

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

<span data-ttu-id="497ad-128">複数のデバイスの場合は、localhost .pfx ファイルで、再利用することができますが、各デバイスの IP アドレスやホスト名の証明書を個別に作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="497ad-128">If you have multiple devices, you can reuse the localhost .pfx files, but you'll still need to create IP address and hostname certificates for each device separately.</span></span>

<span data-ttu-id="497ad-129">.Pfx ファイルのバンドルの生成時に Windows デバイス ポータルに読み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="497ad-129">When the bundle of .pfx files is generated, you will need to load them into Windows Device Portal.</span></span> 

## <a name="provision-device-portal-with-the-certifications"></a><span data-ttu-id="497ad-130">Device Portal の認定をプロビジョニング</span><span class="sxs-lookup"><span data-stu-id="497ad-130">Provision Device Portal with the certification(s)</span></span>

<span data-ttu-id="497ad-131">各 .pfx ファイルの作成されたデバイスの場合、管理者特権のコマンド プロンプトから次のコマンドを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="497ad-131">For each .pfx file that you've created for a device, you'll need to run the following command from an elevated command prompt.</span></span>

```
WebManagement.exe -SetCert <Path to .pfx file> <password for pfx> 
```

<span data-ttu-id="497ad-132">使用例を以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="497ad-132">See below for example usage:</span></span>
```
WebManagement.exe -SetCert localhost.pfx PickAPassword
WebManagement.exe -SetCert --1.pfx PickAPassword
WebManagement.exe -SetCert MyLivingRoomPC.pfx PickAPassword
```

<span data-ttu-id="497ad-133">証明書をインストールした後、サービスを再起動するだけで、変更を反映するようにします。</span><span class="sxs-lookup"><span data-stu-id="497ad-133">Once you have installed the certificates, simply restart the service so the changes can take effect:</span></span>

```
sc stop webmanagement
sc start webmanagement
```

> [!TIP]
> <span data-ttu-id="497ad-134">IP アドレスは、時間の経過と共に変更できます。</span><span class="sxs-lookup"><span data-stu-id="497ad-134">IP addresses can change over time.</span></span>
<span data-ttu-id="497ad-135">多くのネットワークでは、DHCP を使用して、デバイスしない常に、同じ IP アドレスを取得したを持っていたため、IP アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="497ad-135">Many networks use DHCP to give out IP addresses, so devices don't always get the same IP address they had previously.</span></span> <span data-ttu-id="497ad-136">デバイスの IP アドレス用の証明書を作成したら、デバイスのアドレスが変更された場合 Windows Device Portal は、既存の自己署名証明書を使用して、新しい証明書を生成し、作成した 1 つの使用を停止します。</span><span class="sxs-lookup"><span data-stu-id="497ad-136">If you've created a certificate for an IP address on a device and that device's address has changed, Windows Device Portal will generate a new certificate using the existing self-signed cert, and it will stop using the one you created.</span></span> <span data-ttu-id="497ad-137">ブラウザーでもう一度表示されるように証明書の警告ページこれが発生します。</span><span class="sxs-lookup"><span data-stu-id="497ad-137">This will cause the cert warning page to appear in your browser again.</span></span> <span data-ttu-id="497ad-138">このため、Device Portal で設定できますが、ホスト名で、デバイスへの接続をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="497ad-138">For this reason, we recommend connecting to your devices through their hostnames, which you can set in Device Portal.</span></span> <span data-ttu-id="497ad-139">IP アドレスに関係なく同じこれらが残ります。</span><span class="sxs-lookup"><span data-stu-id="497ad-139">These will stay the same regardless of IP addresses.</span></span>
