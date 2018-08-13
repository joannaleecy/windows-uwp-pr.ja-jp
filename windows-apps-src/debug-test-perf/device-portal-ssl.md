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
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2ccdef5c9462f18c1a7044fcc3a683c749177349
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1070921"
---
# <a name="provision-device-portal-with-a-custom-ssl-certificate"></a><span data-ttu-id="9abd1-104">カスタムの SSL 証明書で Device Portal をプロビジョニングする</span><span class="sxs-lookup"><span data-stu-id="9abd1-104">Provision Device Portal with a custom SSL certificate</span></span>
<span data-ttu-id="9abd1-105">Windows 10 の作成者 Update では、Windows デバイス ポータルは、HTTPS 通信で使用するカスタム証明書をインストールするデバイス管理者を追加します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-105">In the Windows 10 Creators Update, Windows Device Portal added a way for device administrators to install a custom certificate for use in HTTPS communication.</span></span> 

<span data-ttu-id="9abd1-106">独自の PC にこれを行うことができます、中に場所で既存の証明書インフラストラクチャはある企業向けのこの機能は、ほとんどの場合。</span><span class="sxs-lookup"><span data-stu-id="9abd1-106">While you can do this on your own PC, this feature is mostly intended for enterprises that have an existing certificate infrastructure in place.</span></span>  

<span data-ttu-id="9abd1-107">たとえば、会社には、https served イントラネットの web サイトの証明書のサインインに使用する証明機関 (CA) があります。</span><span class="sxs-lookup"><span data-stu-id="9abd1-107">For example, a company might have a certificate authority (CA) that it uses to sign certificates for intranet websites served over HTTPS.</span></span> <span data-ttu-id="9abd1-108">この機能にインフラストラクチャを意味します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-108">This feature stands on top of that infrastructure.</span></span> 

## <a name="overview"></a><span data-ttu-id="9abd1-109">概要</span><span class="sxs-lookup"><span data-stu-id="9abd1-109">Overview</span></span>
<span data-ttu-id="9abd1-110">既定では、デバイス ポータルは、CA、自己署名のルートを生成し、待機しているすべてのエンドポイントの SSL 証明書に署名を使用しています。</span><span class="sxs-lookup"><span data-stu-id="9abd1-110">By default, Device Portal generates a self-signed root CA, and then uses that to sign SSL certificates for every endpoint it is listening on.</span></span> <span data-ttu-id="9abd1-111">これが含まれています`localhost`、 `127.0.0.1`、および`::1`(IPv6 ローカル ホスト)。</span><span class="sxs-lookup"><span data-stu-id="9abd1-111">This includes `localhost`, `127.0.0.1`, and `::1` (IPv6 localhost).</span></span>

<span data-ttu-id="9abd1-112">デバイスのホスト名も含まれています (たとえば、 `https://LivingRoomPC`) とデバイスに割り当てられている各リンク ローカル IP アドレス (最大 2 [IPv4、IPv6] ネットワーク アダプターごと)。</span><span class="sxs-lookup"><span data-stu-id="9abd1-112">Also included are the device's hostname (for example, `https://LivingRoomPC`) and each link-local IP address assigned to the device (up to two [IPv4, IPv6] per network adaptor).</span></span> <span data-ttu-id="9abd1-113">デバイス ポータルで、ネットワークのツールを見て、デバイスのリンク ローカル IP アドレスを表示できます。</span><span class="sxs-lookup"><span data-stu-id="9abd1-113">You can see the link-local IP addresses for a device by looking at the Networking tool in Device Portal.</span></span> <span data-ttu-id="9abd1-114">開始`10.`または`192.`ipv4、または`fe80:`ipv6 します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-114">They'll start with `10.` or `192.` for IPv4, or `fe80:` for IPv6.</span></span> 

<span data-ttu-id="9abd1-115">既定の設定、証明書の警告が信頼されている ca の理由により、ブラウザーで表示されます。</span><span class="sxs-lookup"><span data-stu-id="9abd1-115">In the default setup, a certificate warning may appear in your browser because of the untrusted root CA.</span></span> <span data-ttu-id="9abd1-116">具体的には、デバイスのポータルで提供された SSL 証明書は、ルート ブラウザーまたは PC が信頼しない CA によって署名されています。</span><span class="sxs-lookup"><span data-stu-id="9abd1-116">Specifically, the SSL cert provided by Device Portal is signed by a root CA that the browser or PC doesn't trust.</span></span> <span data-ttu-id="9abd1-117">新しい信頼できるルート CA を作成して、これが修正されることができます。</span><span class="sxs-lookup"><span data-stu-id="9abd1-117">This can be fixed by creating a new trusted root CA.</span></span>

## <a name="create-a-root-ca"></a><span data-ttu-id="9abd1-118">ルート CA を作成します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-118">Create a root CA</span></span>

<span data-ttu-id="9abd1-119">これにより、会社 (またはホーム) は、セットアップ、証明書のインフラストラクチャがあるない場合にのみ実行され、1 回のみ実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9abd1-119">This should only be done if your company (or home) doesn't have a certificate infrastructure set up, and should only be done once.</span></span> <span data-ttu-id="9abd1-120">次の PowerShell スクリプトでは、ルート_WdpTestCA.cer_と呼ばれる CA を作成します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-120">The following PowerShell script creates a root CA called _WdpTestCA.cer_.</span></span> <span data-ttu-id="9abd1-121">このファイルをローカル コンピューターの信頼できるルート証明機関にインストールするには、この ca によって署名されている SSL 証明書を信頼するデバイスによって発生します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-121">Installing this file to the local machine's Trusted Root Certification Authorities will cause your device to trust SSL certs that are signed by this root CA.</span></span> <span data-ttu-id="9abd1-122">できます (とする必要があります) をインストールする Windows デバイス ポータルに接続する各コンピューター上には、この .cer ファイル。</span><span class="sxs-lookup"><span data-stu-id="9abd1-122">You can (and should) install this .cer file on each PC that you want to connect to Windows Device Portal.</span></span>  

```PowerShell
$CN = "PickAName"
$OutputPath = "c:\temp\"

# Create root certificate authority
$FilePath = $OutputPath + "WdpTestCA.cer"
$Subject =  "CN="+$CN
$rootCA = New-SelfSignedCertificate -certstorelocation cert:\currentuser\my -Subject $Subject -HashAlgorithm "SHA512" -KeyUsage CertSign,CRLSign
$rootCAFile = Export-Certificate -Cert $rootCA -FilePath $FilePath
```

<span data-ttu-id="9abd1-123">これが作成、SSL 証明書の署名に_WdpTestCA.cer_ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="9abd1-123">Once this is created, you can use the _WdpTestCA.cer_ file to sign SSL certs.</span></span> 

## <a name="create-an-ssl-certificate-with-the-root-ca"></a><span data-ttu-id="9abd1-124">ルート CA と SSL 証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-124">Create an SSL certificate with the root CA</span></span>

<span data-ttu-id="9abd1-125">SSL 証明書は、次の 2 つの重要な機能を持つ: 暗号化を使用する接続をセキュリティで保護して、ブラウザーのバーに表示されるアドレスを使って通信する実際に確認する (Bing.com、192.168.1.37 など) と悪意のあるサードパーティされません。</span><span class="sxs-lookup"><span data-stu-id="9abd1-125">SSL certificates have two critical functions: securing your connection through encryption and verifying that you are actually communicating with the address displayed in the browser bar (Bing.com, 192.168.1.37, etc.) and not a malicious third party.</span></span>

<span data-ttu-id="9abd1-126">次の PowerShell スクリプトの SSL 証明書を作成する、`localhost`エンドポイントします。</span><span class="sxs-lookup"><span data-stu-id="9abd1-126">The following PowerShell script creates an SSL certificate for the `localhost` endpoint.</span></span> <span data-ttu-id="9abd1-127">ポータルのデバイスがリッスンする各端点に固有の証明書が必要があります。置き換えることができます、`$IssuedTo`お使いのデバイスで別の端点の各スクリプトで引数: [ホスト名、ローカル ホスト、および IP アドレスします。</span><span class="sxs-lookup"><span data-stu-id="9abd1-127">Each endpoint that Device Portal listens on needs its own certificate; you can replace the `$IssuedTo` argument in the script with each of the different endpoints for your device: the hostname, localhost, and the IP addresses.</span></span>

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

<span data-ttu-id="9abd1-128">複数のデバイスを使っている場合、ローカル ホスト .pfx ファイルを再利用することができますが、デバイスごとに IP アドレスとホスト名の証明書を個別に作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9abd1-128">If you have multiple devices, you can reuse the localhost .pfx files, but you'll still need to create IP address and hostname certificates for each device separately.</span></span>

<span data-ttu-id="9abd1-129">.Pfx ファイルのバンドルを生成する場合は、Windows デバイス ポータルへのロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9abd1-129">When the bundle of .pfx files is generated, you will need to load them into Windows Device Portal.</span></span> 

## <a name="provision-device-portal-with-the-certifications"></a><span data-ttu-id="9abd1-130">プロビジョニング デバイス ポータル、しません。</span><span class="sxs-lookup"><span data-stu-id="9abd1-130">Provision Device Portal with the certification(s)</span></span>

<span data-ttu-id="9abd1-131">各 .pfx ファイルに対して作成したデバイス用には、管理者特権のコマンド プロンプトから、次のコマンドを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9abd1-131">For each .pfx file that you've created for a device, you'll need to run the following command from an elevated command prompt.</span></span>

```
WebManagement.exe -SetCert <Path to .pfx file> <password for pfx> 
```

<span data-ttu-id="9abd1-132">使用例の下を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9abd1-132">See below for example usage:</span></span>
```
WebManagement.exe -SetCert localhost.pfx PickAPassword
WebManagement.exe -SetCert --1.pfx PickAPassword
WebManagement.exe -SetCert MyLivingRoomPC.pfx PickAPassword
```

<span data-ttu-id="9abd1-133">証明書のインストールが完了したら、だけで、変更を反映するようにサービスを再起動します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-133">Once you have installed the certificates, simply restart the service so the changes can take effect:</span></span>

```
sc stop webmanagement
sc start webmanagement
```

> [!TIP]
> <span data-ttu-id="9abd1-134">時間の経過 IP アドレスを変更できます。</span><span class="sxs-lookup"><span data-stu-id="9abd1-134">IP addresses can change over time.</span></span>
<span data-ttu-id="9abd1-135">多くのネットワークでは、DHCP を使用して、デバイスが以前はあったが同じ IP アドレスを常に取得されないように、IP アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-135">Many networks use DHCP to give out IP addresses, so devices don't always get the same IP address they had previously.</span></span> <span data-ttu-id="9abd1-136">デバイスの IP アドレスの証明書を作成した、デバイスのアドレスが変更されている場合は、Windows デバイス ポータルには、既存の自己署名証明書を使用して、新しい証明書は生成し、作成した 1 つの使用を停止します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-136">If you've created a certificate for an IP address on a device and that device's address has changed, Windows Device Portal will generate a new certificate using the existing self-signed cert, and it will stop using the one you created.</span></span> <span data-ttu-id="9abd1-137">これは、結果、証明書の警告] ページをもう一度お使いのブラウザーで表示します。</span><span class="sxs-lookup"><span data-stu-id="9abd1-137">This will cause the cert warning page to appear in your browser again.</span></span> <span data-ttu-id="9abd1-138">このため、デバイス ポータルで設定することができますが、ホスト名からデバイスへの接続をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9abd1-138">For this reason, we recommend connecting to your devices through their hostnames, which you can set in Device Portal.</span></span> <span data-ttu-id="9abd1-139">IP アドレスに関係なく、同じこれらが残ります。</span><span class="sxs-lookup"><span data-stu-id="9abd1-139">These will stay the same regardless of IP addresses.</span></span>
