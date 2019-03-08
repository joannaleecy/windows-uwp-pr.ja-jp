---
ms.assetid: e04ebe3f-479c-4b48-99d8-3dd4bb9bfaf4
title: カスタムの SSL 証明書で Device Portal のプロビジョニングを行う
description: TBD
ms.date: 07/11/2017
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: faef15d523f56b6e45f77e0ccdbb2f5846f7a15a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616697"
---
# <a name="provision-device-portal-with-a-custom-ssl-certificate"></a><span data-ttu-id="ef43a-104">カスタムの SSL 証明書で Device Portal のプロビジョニングを行う</span><span class="sxs-lookup"><span data-stu-id="ef43a-104">Provision Device Portal with a custom SSL certificate</span></span>
<span data-ttu-id="ef43a-105">Windows 10 Creators Update では、Windows Device Portal によって、デバイス管理者が HTTPS 通信で使用できるカスタム証明書のインストール手段が追加されています。</span><span class="sxs-lookup"><span data-stu-id="ef43a-105">In the Windows 10 Creators Update, Windows Device Portal added a way for device administrators to install a custom certificate for use in HTTPS communication.</span></span> 

<span data-ttu-id="ef43a-106">自身の PC で行うこともできますが、この機能は主に、既存の証明書インフラストラクチャを使用している企業を対象としています。</span><span class="sxs-lookup"><span data-stu-id="ef43a-106">While you can do this on your own PC, this feature is mostly intended for enterprises that have an existing certificate infrastructure in place.</span></span>  

<span data-ttu-id="ef43a-107">たとえば、HTTPS で使用するイントラネット Web サイト用の証明書に署名するために、企業で証明機関 (CA) を保有している場合があります。</span><span class="sxs-lookup"><span data-stu-id="ef43a-107">For example, a company might have a certificate authority (CA) that it uses to sign certificates for intranet websites served over HTTPS.</span></span> <span data-ttu-id="ef43a-108">この機能は、そのようなインフラストラクチャ上で使用します。</span><span class="sxs-lookup"><span data-stu-id="ef43a-108">This feature stands on top of that infrastructure.</span></span> 

## <a name="overview"></a><span data-ttu-id="ef43a-109">概要</span><span class="sxs-lookup"><span data-stu-id="ef43a-109">Overview</span></span>
<span data-ttu-id="ef43a-110">既定では、Device Portal は自己署名ルート CA を生成し、これを使用して、リッスン対象のすべてのエンドポイント用に SSL 証明書への署名を行います。</span><span class="sxs-lookup"><span data-stu-id="ef43a-110">By default, Device Portal generates a self-signed root CA, and then uses that to sign SSL certificates for every endpoint it is listening on.</span></span> <span data-ttu-id="ef43a-111">これには、`localhost`、`127.0.0.1`、`::1` (IPv6 localhost) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ef43a-111">This includes `localhost`, `127.0.0.1`, and `::1` (IPv6 localhost).</span></span>

<span data-ttu-id="ef43a-112">また、デバイスのホスト名 (`https://LivingRoomPC` など) と、デバイスに割り当てられた各リンク ローカル IP アドレス (ネットワーク アダプターごとに最大 2 つの [IPv4, IPv6]) も含まれます。</span><span class="sxs-lookup"><span data-stu-id="ef43a-112">Also included are the device's hostname (for example, `https://LivingRoomPC`) and each link-local IP address assigned to the device (up to two [IPv4, IPv6] per network adaptor).</span></span> <span data-ttu-id="ef43a-113">デバイスのリンク ローカル IP アドレスは、Device Portal のネットワーク ツールで確認できます。</span><span class="sxs-lookup"><span data-stu-id="ef43a-113">You can see the link-local IP addresses for a device by looking at the Networking tool in Device Portal.</span></span> <span data-ttu-id="ef43a-114">アドレスの先頭は、IPv4 の場合は `10.` または `192.`、IPv6 の場合は `fe80:` になります。</span><span class="sxs-lookup"><span data-stu-id="ef43a-114">They'll start with `10.` or `192.` for IPv4, or `fe80:` for IPv6.</span></span> 

<span data-ttu-id="ef43a-115">既定のセットアップの場合、信頼されていないルート CA が原因で、証明書警告がブラウザーに表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="ef43a-115">In the default setup, a certificate warning may appear in your browser because of the untrusted root CA.</span></span> <span data-ttu-id="ef43a-116">具体的には、Device Portal によって提供される SSL 証明書は、ブラウザーまたは PC が信頼していないルート CA によって署名されています。</span><span class="sxs-lookup"><span data-stu-id="ef43a-116">Specifically, the SSL cert provided by Device Portal is signed by a root CA that the browser or PC doesn't trust.</span></span> <span data-ttu-id="ef43a-117">この問題は、新しい信頼されたルート CA を作成することで対処できます。</span><span class="sxs-lookup"><span data-stu-id="ef43a-117">This can be fixed by creating a new trusted root CA.</span></span>

## <a name="create-a-root-ca"></a><span data-ttu-id="ef43a-118">ルート CA を作成する</span><span class="sxs-lookup"><span data-stu-id="ef43a-118">Create a root CA</span></span>

<span data-ttu-id="ef43a-119">この処理は、会社 (または家庭) に証明書インフラストラクチャがセットアップされていない場合にのみ、1 回だけ実行してください。</span><span class="sxs-lookup"><span data-stu-id="ef43a-119">This should only be done if your company (or home) doesn't have a certificate infrastructure set up, and should only be done once.</span></span> <span data-ttu-id="ef43a-120">次の PowerShell スクリプトでは、_WdpTestCA.cer_ というルート CA を作成します。</span><span class="sxs-lookup"><span data-stu-id="ef43a-120">The following PowerShell script creates a root CA called _WdpTestCA.cer_.</span></span> <span data-ttu-id="ef43a-121">このファイルをローカル コンピューターの [信頼されたルート証明機関] にインストールすると、このルート CA で署名した SSL 証明書がデバイスによって信頼されるようになります。</span><span class="sxs-lookup"><span data-stu-id="ef43a-121">Installing this file to the local machine's Trusted Root Certification Authorities will cause your device to trust SSL certs that are signed by this root CA.</span></span> <span data-ttu-id="ef43a-122">この .cer ファイルは、Windows Device Portal に接続する予定のある各 PC にインストールできます (また、その必要があります)。</span><span class="sxs-lookup"><span data-stu-id="ef43a-122">You can (and should) install this .cer file on each PC that you want to connect to Windows Device Portal.</span></span>  

```PowerShell
$CN = "PickAName"
$OutputPath = "c:\temp\"

# Create root certificate authority
$FilePath = $OutputPath + "WdpTestCA.cer"
$Subject =  "CN="+$CN
$rootCA = New-SelfSignedCertificate -certstorelocation cert:\currentuser\my -Subject $Subject -HashAlgorithm "SHA512" -KeyUsage CertSign,CRLSign
$rootCAFile = Export-Certificate -Cert $rootCA -FilePath $FilePath
```

<span data-ttu-id="ef43a-123">_WdpTestCA.cer_ の作成後は、このファイルを使用して SSL 証明書に署名することができます。</span><span class="sxs-lookup"><span data-stu-id="ef43a-123">Once this is created, you can use the _WdpTestCA.cer_ file to sign SSL certs.</span></span> 

## <a name="create-an-ssl-certificate-with-the-root-ca"></a><span data-ttu-id="ef43a-124">ルート CA で SSL 証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="ef43a-124">Create an SSL certificate with the root CA</span></span>

<span data-ttu-id="ef43a-125">SSL 証明書には 2 つの重要な機能があります。1 つは、暗号化による接続の保護、もう 1 つは、悪意のあるサード パーティではなくブラウザー バーに表示されているアドレス (Bing.com、192.168.1.37 など) が実際の通信先であることの確認です。</span><span class="sxs-lookup"><span data-stu-id="ef43a-125">SSL certificates have two critical functions: securing your connection through encryption and verifying that you are actually communicating with the address displayed in the browser bar (Bing.com, 192.168.1.37, etc.) and not a malicious third party.</span></span>

<span data-ttu-id="ef43a-126">次の PowerShell スクリプトでは、`localhost` エンドポイントの SSL 証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="ef43a-126">The following PowerShell script creates an SSL certificate for the `localhost` endpoint.</span></span> <span data-ttu-id="ef43a-127">Device Portal がリッスンする各エンドポイントには、それぞれの証明書が必要です。スクリプトの `$IssuedTo` 引数は、デバイスの各エンドポイント (ホスト名、ローカルホスト、IP アドレス) に置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="ef43a-127">Each endpoint that Device Portal listens on needs its own certificate; you can replace the `$IssuedTo` argument in the script with each of the different endpoints for your device: the hostname, localhost, and the IP addresses.</span></span>

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

<span data-ttu-id="ef43a-128">複数のデバイスを使用している場合はローカルホストの .pfx ファイルを再利用できますが、これとは別に、各デバイスの IP アドレスとホスト名の証明書を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef43a-128">If you have multiple devices, you can reuse the localhost .pfx files, but you'll still need to create IP address and hostname certificates for each device separately.</span></span>

<span data-ttu-id="ef43a-129">.pfx ファイルのバンドルが生成されたら、これらを Windows Device Portal に読み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef43a-129">When the bundle of .pfx files is generated, you will need to load them into Windows Device Portal.</span></span> 

## <a name="provision-device-portal-with-the-certifications"></a><span data-ttu-id="ef43a-130">証明書で Device Portal のプロビジョニングを行う</span><span class="sxs-lookup"><span data-stu-id="ef43a-130">Provision Device Portal with the certification(s)</span></span>

<span data-ttu-id="ef43a-131">デバイス用に作成した各 .pfx ファイルについて、管理者特権のコマンド プロンプトから、次のコマンドを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef43a-131">For each .pfx file that you've created for a device, you'll need to run the following command from an elevated command prompt.</span></span>

```
WebManagement.exe -SetCert <Path to .pfx file> <password for pfx> 
```

<span data-ttu-id="ef43a-132">以下の使用例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ef43a-132">See below for example usage:</span></span>
```
WebManagement.exe -SetCert localhost.pfx PickAPassword
WebManagement.exe -SetCert --1.pfx PickAPassword
WebManagement.exe -SetCert MyLivingRoomPC.pfx PickAPassword
```

<span data-ttu-id="ef43a-133">証明書をインストールしたら、変更を反映するためにサービスを再起動します。</span><span class="sxs-lookup"><span data-stu-id="ef43a-133">Once you have installed the certificates, simply restart the service so the changes can take effect:</span></span>

```
sc stop webmanagement
sc start webmanagement
```

> [!TIP]
> <span data-ttu-id="ef43a-134">IP アドレスは、時間の経過に伴って変わることがあります。</span><span class="sxs-lookup"><span data-stu-id="ef43a-134">IP addresses can change over time.</span></span>
<span data-ttu-id="ef43a-135">多くのネットワークでは、各デバイスに常に以前と同じ IP アドレスが割り当てられることのないように、DHCP によって IP アドレスが提供されています。</span><span class="sxs-lookup"><span data-stu-id="ef43a-135">Many networks use DHCP to give out IP addresses, so devices don't always get the same IP address they had previously.</span></span> <span data-ttu-id="ef43a-136">デバイス上で IP アドレスに対して証明書を作成した場合、そのデバイスのアドレスが変わると、Windows Device Portal によって既存の自己署名証明書を使用して新しい証明書が生成され、元の証明書の使用が停止されます。</span><span class="sxs-lookup"><span data-stu-id="ef43a-136">If you've created a certificate for an IP address on a device and that device's address has changed, Windows Device Portal will generate a new certificate using the existing self-signed cert, and it will stop using the one you created.</span></span> <span data-ttu-id="ef43a-137">この場合は、ブラウザーに証明書の警告ページがもう一度表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef43a-137">This will cause the cert warning page to appear in your browser again.</span></span> <span data-ttu-id="ef43a-138">このため、デバイスにはホスト名で接続することをお勧めします (Device Portal で設定できます)。</span><span class="sxs-lookup"><span data-stu-id="ef43a-138">For this reason, we recommend connecting to your devices through their hostnames, which you can set in Device Portal.</span></span> <span data-ttu-id="ef43a-139">IP アドレスが変わっても、ホスト名に変わりはありません。</span><span class="sxs-lookup"><span data-stu-id="ef43a-139">These will stay the same regardless of IP addresses.</span></span>
