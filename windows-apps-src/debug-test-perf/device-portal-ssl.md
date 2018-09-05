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
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3373674"
---
# <a name="provision-device-portal-with-a-custom-ssl-certificate"></a><span data-ttu-id="8320d-104">カスタムの SSL 証明書で Device Portal をプロビジョニングする</span><span class="sxs-lookup"><span data-stu-id="8320d-104">Provision Device Portal with a custom SSL certificate</span></span>
<span data-ttu-id="8320d-105">Windows 10 更新プログラムの作成者では、Windows デバイス ポータルは、HTTPS 通信で使用するカスタムの証明書をインストールするのにはデバイスの管理者を追加します。</span><span class="sxs-lookup"><span data-stu-id="8320d-105">In the Windows 10 Creators Update, Windows Device Portal added a way for device administrators to install a custom certificate for use in HTTPS communication.</span></span> 

<span data-ttu-id="8320d-106">自分の PC でこれを行うことができます、中に既存の証明書インフラストラクチャを適切に実装する企業向けのこの機能は、ほとんどの場合。</span><span class="sxs-lookup"><span data-stu-id="8320d-106">While you can do this on your own PC, this feature is mostly intended for enterprises that have an existing certificate infrastructure in place.</span></span>  

<span data-ttu-id="8320d-107">たとえば、会社には、HTTPS 経由で提供されたイントラネット web サイトの証明書に署名するために使用する証明機関 (CA) があります。</span><span class="sxs-lookup"><span data-stu-id="8320d-107">For example, a company might have a certificate authority (CA) that it uses to sign certificates for intranet websites served over HTTPS.</span></span> <span data-ttu-id="8320d-108">この機能をインフラストラクチャに意味します。</span><span class="sxs-lookup"><span data-stu-id="8320d-108">This feature stands on top of that infrastructure.</span></span> 

## <a name="overview"></a><span data-ttu-id="8320d-109">概要</span><span class="sxs-lookup"><span data-stu-id="8320d-109">Overview</span></span>
<span data-ttu-id="8320d-110">既定は、デバイスのポータルは、自己署名されたルート CA を生成し、待機しているすべてのエンドポイントの SSL 証明書に署名を使用しています。</span><span class="sxs-lookup"><span data-stu-id="8320d-110">By default, Device Portal generates a self-signed root CA, and then uses that to sign SSL certificates for every endpoint it is listening on.</span></span> <span data-ttu-id="8320d-111">これが含まれています`localhost`、 `127.0.0.1`、および`::1`(IPv6 ローカル ホスト)。</span><span class="sxs-lookup"><span data-stu-id="8320d-111">This includes `localhost`, `127.0.0.1`, and `::1` (IPv6 localhost).</span></span>

<span data-ttu-id="8320d-112">デバイスのホスト名も含まれています (たとえば、 `https://LivingRoomPC`) およびデバイスに割り当てられている各リンク ローカル IP アドレス (を 2 つ [IPv4、IPv6] ネットワーク アダプターごと)。</span><span class="sxs-lookup"><span data-stu-id="8320d-112">Also included are the device's hostname (for example, `https://LivingRoomPC`) and each link-local IP address assigned to the device (up to two [IPv4, IPv6] per network adaptor).</span></span> <span data-ttu-id="8320d-113">デバイスのポータルのネットワーク ツールを参照して、デバイスのリンク ローカル IP アドレスを表示できます。</span><span class="sxs-lookup"><span data-stu-id="8320d-113">You can see the link-local IP addresses for a device by looking at the Networking tool in Device Portal.</span></span> <span data-ttu-id="8320d-114">開始`10.`または`192.`ipv4 の場合、または`fe80:`IPv6 のためです。</span><span class="sxs-lookup"><span data-stu-id="8320d-114">They'll start with `10.` or `192.` for IPv4, or `fe80:` for IPv6.</span></span> 

<span data-ttu-id="8320d-115">既定の設定、証明書の警告がルート CA が信頼されていないため、ブラウザーで表示されます。</span><span class="sxs-lookup"><span data-stu-id="8320d-115">In the default setup, a certificate warning may appear in your browser because of the untrusted root CA.</span></span> <span data-ttu-id="8320d-116">具体的には、デバイスのポータルによって提供されている SSL 証明書は、ブラウザーや PC は信頼できる ca によって署名されています。</span><span class="sxs-lookup"><span data-stu-id="8320d-116">Specifically, the SSL cert provided by Device Portal is signed by a root CA that the browser or PC doesn't trust.</span></span> <span data-ttu-id="8320d-117">これは、新しい信頼されたルート CA を作成することによって修正されることができます。</span><span class="sxs-lookup"><span data-stu-id="8320d-117">This can be fixed by creating a new trusted root CA.</span></span>

## <a name="create-a-root-ca"></a><span data-ttu-id="8320d-118">ルート CA を作成します。</span><span class="sxs-lookup"><span data-stu-id="8320d-118">Create a root CA</span></span>

<span data-ttu-id="8320d-119">これは会社 (または自宅) は、証明書インフラストラクチャをされていない場合にのみ行う必要があり、一度だけ実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8320d-119">This should only be done if your company (or home) doesn't have a certificate infrastructure set up, and should only be done once.</span></span> <span data-ttu-id="8320d-120">次の PowerShell スクリプトは、 _WdpTestCA.cer_と呼ばれる CA ルートを作成します。</span><span class="sxs-lookup"><span data-stu-id="8320d-120">The following PowerShell script creates a root CA called _WdpTestCA.cer_.</span></span> <span data-ttu-id="8320d-121">このファイルをローカル コンピューターの信頼されたルート証明機関をインストールすると、このルート CA によって署名された SSL 証明書を信頼するようにデバイスが発生します。</span><span class="sxs-lookup"><span data-stu-id="8320d-121">Installing this file to the local machine's Trusted Root Certification Authorities will cause your device to trust SSL certs that are signed by this root CA.</span></span> <span data-ttu-id="8320d-122">(したりする必要があります) をインストールする Windows のデバイスのポータルに接続する各コンピューター上には、この .cer ファイル。</span><span class="sxs-lookup"><span data-stu-id="8320d-122">You can (and should) install this .cer file on each PC that you want to connect to Windows Device Portal.</span></span>  

```PowerShell
$CN = "PickAName"
$OutputPath = "c:\temp\"

# Create root certificate authority
$FilePath = $OutputPath + "WdpTestCA.cer"
$Subject =  "CN="+$CN
$rootCA = New-SelfSignedCertificate -certstorelocation cert:\currentuser\my -Subject $Subject -HashAlgorithm "SHA512" -KeyUsage CertSign,CRLSign
$rootCAFile = Export-Certificate -Cert $rootCA -FilePath $FilePath
```

<span data-ttu-id="8320d-123">これが作成されると、SSL 証明書に署名するのに_WdpTestCA.cer_ファイルを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8320d-123">Once this is created, you can use the _WdpTestCA.cer_ file to sign SSL certs.</span></span> 

## <a name="create-an-ssl-certificate-with-the-root-ca"></a><span data-ttu-id="8320d-124">ルート CA からの SSL 証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="8320d-124">Create an SSL certificate with the root CA</span></span>

<span data-ttu-id="8320d-125">SSL 証明書がある 2 つの重要な機能: 暗号化を使用して接続をセキュリティで保護して、ブラウザーのバーに表示されるアドレスと実際に通信しているかを確認 (Bing.com、192.168.1.37 など)、悪意のあるサードパーティ製ではありません。</span><span class="sxs-lookup"><span data-stu-id="8320d-125">SSL certificates have two critical functions: securing your connection through encryption and verifying that you are actually communicating with the address displayed in the browser bar (Bing.com, 192.168.1.37, etc.) and not a malicious third party.</span></span>

<span data-ttu-id="8320d-126">次の PowerShell スクリプト用の SSL 証明書の作成、`localhost`エンドポイントです。</span><span class="sxs-lookup"><span data-stu-id="8320d-126">The following PowerShell script creates an SSL certificate for the `localhost` endpoint.</span></span> <span data-ttu-id="8320d-127">ポータルのデバイスがリッスンするエンドポイントごとに必要な独自の証明書です。置き換えることができます、 `$IssuedTo` 、デバイスのさまざまなエンドポイントの各スクリプトの引数: ホスト名、ローカル ホスト、および、IP アドレスです。</span><span class="sxs-lookup"><span data-stu-id="8320d-127">Each endpoint that Device Portal listens on needs its own certificate; you can replace the `$IssuedTo` argument in the script with each of the different endpoints for your device: the hostname, localhost, and the IP addresses.</span></span>

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

<span data-ttu-id="8320d-128">複数のデバイスがある場合は、localhost の .pfx ファイルを再利用することができますが、各デバイスの IP アドレスとホスト名の証明書を個別に作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8320d-128">If you have multiple devices, you can reuse the localhost .pfx files, but you'll still need to create IP address and hostname certificates for each device separately.</span></span>

<span data-ttu-id="8320d-129">.Pfx ファイルのバンドルを生成する場合は、Windows デバイスのポータルにそれらをロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8320d-129">When the bundle of .pfx files is generated, you will need to load them into Windows Device Portal.</span></span> 

## <a name="provision-device-portal-with-the-certifications"></a><span data-ttu-id="8320d-130">プロビジョニング デバイスのポータル、しないと</span><span class="sxs-lookup"><span data-stu-id="8320d-130">Provision Device Portal with the certification(s)</span></span>

<span data-ttu-id="8320d-131">.Pfx、ファイルごとに作成したデバイスの管理者特権のコマンド プロンプトから次のコマンドを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8320d-131">For each .pfx file that you've created for a device, you'll need to run the following command from an elevated command prompt.</span></span>

```
WebManagement.exe -SetCert <Path to .pfx file> <password for pfx> 
```

<span data-ttu-id="8320d-132">などの使用状況の下を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8320d-132">See below for example usage:</span></span>
```
WebManagement.exe -SetCert localhost.pfx PickAPassword
WebManagement.exe -SetCert --1.pfx PickAPassword
WebManagement.exe -SetCert MyLivingRoomPC.pfx PickAPassword
```

<span data-ttu-id="8320d-133">証明書をインストールした後は、単にサービスを再起動して変更を反映できるようにします。</span><span class="sxs-lookup"><span data-stu-id="8320d-133">Once you have installed the certificates, simply restart the service so the changes can take effect:</span></span>

```
sc stop webmanagement
sc start webmanagement
```

> [!TIP]
> <span data-ttu-id="8320d-134">IP アドレスは、時間の経過とともに変更できます。</span><span class="sxs-lookup"><span data-stu-id="8320d-134">IP addresses can change over time.</span></span>
<span data-ttu-id="8320d-135">多くのネットワークでは、デバイスが同じ IP アドレスが以前にあったことを常に取得しないように、IP アドレスを DHCP を使用します。</span><span class="sxs-lookup"><span data-stu-id="8320d-135">Many networks use DHCP to give out IP addresses, so devices don't always get the same IP address they had previously.</span></span> <span data-ttu-id="8320d-136">デバイス上の IP アドレス用の証明書を作成し、デバイスのアドレスが変更された場合は、Windows デバイスのポータルは、既存の自己署名証明書を使用して新しい証明書を生成し、作成したものを使用して停止します。</span><span class="sxs-lookup"><span data-stu-id="8320d-136">If you've created a certificate for an IP address on a device and that device's address has changed, Windows Device Portal will generate a new certificate using the existing self-signed cert, and it will stop using the one you created.</span></span> <span data-ttu-id="8320d-137">お使いのブラウザーで再度表示するのには証明書の警告] ページになります。</span><span class="sxs-lookup"><span data-stu-id="8320d-137">This will cause the cert warning page to appear in your browser again.</span></span> <span data-ttu-id="8320d-138">このため、それらのホスト名は、ポータルでデバイスを設定することができますから、デバイスへの接続をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8320d-138">For this reason, we recommend connecting to your devices through their hostnames, which you can set in Device Portal.</span></span> <span data-ttu-id="8320d-139">これらは常に同一の IP アドレスに関係なく。</span><span class="sxs-lookup"><span data-stu-id="8320d-139">These will stay the same regardless of IP addresses.</span></span>
