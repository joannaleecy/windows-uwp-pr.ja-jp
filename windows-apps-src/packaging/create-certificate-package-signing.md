---
author: laurenhughes
title: パッケージ署名用の証明書を作成する
description: PowerShell ツールを使用して、アプリ パッケージ署名用の証明書を作成してエクスポートします。
ms.author: lahugh
ms.date: 09/30/2018
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 7bc2006f-fc5a-4ff6-b573-60933882caf8
ms.localizationpriority: medium
ms.openlocfilehash: 419fa90dfd21c42d256aeea8848862b8c5eb3628
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6979494"
---
# <a name="create-a-certificate-for-package-signing"></a><span data-ttu-id="6af0c-104">パッケージ署名用の証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="6af0c-104">Create a certificate for package signing</span></span>


<span data-ttu-id="6af0c-105">この記事では、PowerShell ツールを使用して、アプリ パッケージ署名用の証明書を作成してエクスポートする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6af0c-105">This article explains how to create and export a certificate for app package signing using PowerShell tools.</span></span> <span data-ttu-id="6af0c-106">Visual Studio を使用して [UWP アプリをパッケージ化する](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)ことをお勧めしますが、Visual Studio を使用してアプリを開発していない場合は、ストア対応アプリを手動でパッケージ化することができます。</span><span class="sxs-lookup"><span data-stu-id="6af0c-106">It's recommended that you use Visual Studio for [Packaging UWP apps](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps), but you can still package a Store ready app manually if you did not use Visual Studio to develop your app.</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="6af0c-107">Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使って証明書をインポートし、アプリ パッケージに署名することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6af0c-107">If you used Visual Studio to develop your app, it's recommended that you use the Visual Studio wizard to import a certificate and sign your app package.</span></span> <span data-ttu-id="6af0c-108">詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6af0c-108">For more information, see [Package a UWP app with Visual Studio](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="6af0c-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="6af0c-109">Prerequisites</span></span>

- **<span data-ttu-id="6af0c-110">パッケージ化されている、またはパッケージ化されていないアプリ</span><span class="sxs-lookup"><span data-stu-id="6af0c-110">A packaged or unpackaged app</span></span>**  
<span data-ttu-id="6af0c-111">AppxManifest.xml ファイルを含むアプリ。</span><span class="sxs-lookup"><span data-stu-id="6af0c-111">An app containing an AppxManifest.xml file.</span></span> <span data-ttu-id="6af0c-112">マニフェスト ファイルを参照して、最終的なアプリ パッケージの署名に使われる証明書を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af0c-112">You will need to reference the manifest file while creating the certificate that will be used to sign the final app package.</span></span> <span data-ttu-id="6af0c-113">手動でアプリをパッケージ化する方法について詳しくは、「[MakeAppx.exe ツールを使ってアプリ パッケージを作成する](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6af0c-113">For details on how to manually package an app, see [Create an app package with the MakeAppx.exe tool](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool).</span></span>

- **<span data-ttu-id="6af0c-114">公開キー基盤 (PKI) コマンドレット</span><span class="sxs-lookup"><span data-stu-id="6af0c-114">Public Key Infrastructure (PKI) Cmdlets</span></span>**  
<span data-ttu-id="6af0c-115">署名証明書を作成およびエクスポートするには、PKI コマンドレットが必要です。</span><span class="sxs-lookup"><span data-stu-id="6af0c-115">You need PKI cmdlets to create and export your signing certificate.</span></span> <span data-ttu-id="6af0c-116">詳しくは、「[公開キー基盤コマンドレット](https://docs.microsoft.com/powershell/module/pkiclient/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6af0c-116">For more information, see [Public Key Infrastructure Cmdlets](https://docs.microsoft.com/powershell/module/pkiclient/).</span></span>

## <a name="create-a-self-signed-certificate"></a><span data-ttu-id="6af0c-117">自己署名証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="6af0c-117">Create a self signed certificate</span></span>

<span data-ttu-id="6af0c-118">自己署名証明書は、ストアに公開する準備が整う前に、アプリをテストするために便利です。</span><span class="sxs-lookup"><span data-stu-id="6af0c-118">A self signed certificate is useful for testing your app before you're ready to publish it to the store.</span></span> <span data-ttu-id="6af0c-119">自己署名証明書を作成するには、このセクションで説明する手順に従います。</span><span class="sxs-lookup"><span data-stu-id="6af0c-119">Follow the steps outlined in this section to create a self signed certificate.</span></span>

### <a name="determine-the-subject-of-your-packaged-app"></a><span data-ttu-id="6af0c-120">パッケージ アプリのサブジェクトを決定する</span><span class="sxs-lookup"><span data-stu-id="6af0c-120">Determine the subject of your packaged app</span></span>  

<span data-ttu-id="6af0c-121">証明書を使ってアプリ パッケージに署名するには、証明書の「サブジェクト」がアプリのマニフェストの [Publisher] セクションと**一致する必要**があります。</span><span class="sxs-lookup"><span data-stu-id="6af0c-121">To use a certificate to sign your app package, the "Subject" in the certificate **must** match the "Publisher" section in your app's manifest.</span></span>

<span data-ttu-id="6af0c-122">たとえば、アプリの AppxManifest.xml ファイルの [Identity] セクションは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="6af0c-122">For example, the "Identity" section in your app's AppxManifest.xml file should look something like this:</span></span>
```
  <Identity Name="Contoso.AssetTracker" 
    Version="1.0.0.0" 
    Publisher="CN=Contoso Software, O=Contoso Corporation, C=US"/>
```

<span data-ttu-id="6af0c-123">この例では [Publisher] は "CN=Contoso Software, O=Contoso Corporation, C=US" で、これを証明書の作成に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af0c-123">The "Publisher", in this case, is "CN=Contoso Software, O=Contoso Corporation, C=US" which needs to be used for creating your certificate.</span></span> 

### <a name="use-new-selfsignedcertificate-to-create-a-certificate"></a><span data-ttu-id="6af0c-124">**New-SelfSignedCertificate** を使って証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="6af0c-124">Use **New-SelfSignedCertificate** to create a certificate</span></span>
<span data-ttu-id="6af0c-125">PowerShell コマンドレット **New-SelfSignedCertificate** を使用して自己署名証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="6af0c-125">Use the **New-SelfSignedCertificate** PowerShell cmdlet to create a self signed certificate.</span></span> <span data-ttu-id="6af0c-126">**New-SelfSignedCertificate** にはカスタマイズのためのいくつかのパラメーターがありますが、この記事では、**SignTool** で動作する簡単な証明書の作成を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="6af0c-126">**New-SelfSignedCertificate** has several parameters for customization, but for the purpose of this article, we'll focus on creating a simple certificate that will work with **SignTool**.</span></span> <span data-ttu-id="6af0c-127">このコマンドレットの使用とその例について詳しくは、「[New-SelfSignedCertificate](https://docs.microsoft.com/powershell/module/pkiclient/New-SelfSignedCertificate)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6af0c-127">For more examples and uses of this cmdlet, see [New-SelfSignedCertificate](https://docs.microsoft.com/powershell/module/pkiclient/New-SelfSignedCertificate).</span></span>

<span data-ttu-id="6af0c-128">前の例の AppxManifest.xml ファイルに基づいて、次の構文を使用して証明書を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af0c-128">Based on the AppxManifest.xml file from the previous example, you should use the following syntax to create a certificate.</span></span> <span data-ttu-id="6af0c-129">管理者特権の PowerShell プロンプトで、次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="6af0c-129">In an elevated PowerShell prompt:</span></span>
```
New-SelfSignedCertificate -Type Custom -Subject "CN=Contoso Software, O=Contoso Corporation, C=US" -KeyUsage DigitalSignature -FriendlyName <Your Friendly Name> -CertStoreLocation "Cert:\LocalMachine\My"
```

<span data-ttu-id="6af0c-130">このコマンドを実行すると、"-CertStoreLocation" パラメーターで指定されたローカル証明書ストアに証明書が追加されます。</span><span class="sxs-lookup"><span data-stu-id="6af0c-130">After running this command, the certificate will be added to the local certificate store, as specified in the "-CertStoreLocation" parameter.</span></span> <span data-ttu-id="6af0c-131">コマンドの結果には、証明書のサムプリントも生成されます。</span><span class="sxs-lookup"><span data-stu-id="6af0c-131">The result of the command will also produce the certificate's thumbprint.</span></span>  

**<span data-ttu-id="6af0c-132">注意</span><span class="sxs-lookup"><span data-stu-id="6af0c-132">Note</span></span>**  
<span data-ttu-id="6af0c-133">次のコマンドを使って、PowerShell ウィンドウで証明書を表示できます。</span><span class="sxs-lookup"><span data-stu-id="6af0c-133">You can view your certificate in a PowerShell window by using the following commands:</span></span>
```
Set-Location Cert:\LocalMachine\My
Get-ChildItem | Format-Table Subject, FriendlyName, Thumbprint
```
<span data-ttu-id="6af0c-134">これにより、ローカル ストア内のすべての証明書が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6af0c-134">This will display all of the certificates in your local store.</span></span>

## <a name="export-a-certificate"></a><span data-ttu-id="6af0c-135">証明書のエクスポート</span><span class="sxs-lookup"><span data-stu-id="6af0c-135">Export a certificate</span></span> 

<span data-ttu-id="6af0c-136">ローカル ストアの証明書を Personal Information Exchange (.pfx) ファイルにエクスポートするには、**Export-PfxCertificate** コマンドレットを使用します。</span><span class="sxs-lookup"><span data-stu-id="6af0c-136">To export the certificate in the local store to a Personal Information Exchange (PFX) file, use the **Export-PfxCertificate** cmdlet.</span></span>

<span data-ttu-id="6af0c-137">**Export-PfxCertificate** コマンドレットを使用する場合は、パスワードを作成して使用するか、"-ProtectTo" パラメーターを使用して、パスワードなしでファイルにアクセスできるユーザーまたはグループを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af0c-137">When using **Export-PfxCertificate**, you must either create and use a password or use the "-ProtectTo" parameter to specify which users or groups can access the file without a password.</span></span> <span data-ttu-id="6af0c-138">"-Password" または "-ProtectTo" パラメーターのいずれかを使用しない場合、エラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="6af0c-138">Note that an error will be displayed if you don't use either the "-Password" or "-ProtectTo" parameter.</span></span>

- **<span data-ttu-id="6af0c-139">Password を使用</span><span class="sxs-lookup"><span data-stu-id="6af0c-139">Password usage</span></span>**
```
$pwd = ConvertTo-SecureString -String <Your Password> -Force -AsPlainText 
Export-PfxCertificate -cert "Cert:\LocalMachine\My\<Certificate Thumbprint>" -FilePath <FilePath>.pfx -Password $pwd
```

- **<span data-ttu-id="6af0c-140">ProtectTo を使用</span><span class="sxs-lookup"><span data-stu-id="6af0c-140">ProtectTo usage</span></span>**
```
Export-PfxCertificate -cert Cert:\LocalMachine\My\<Certificate Thumbprint> -FilePath <FilePath>.pfx -ProtectTo <Username or group name>
```

<span data-ttu-id="6af0c-141">証明書を作成してエクスポートしたら、**SignTool** を使ってアプリ パッケージに署名する準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="6af0c-141">After you create and export your certificate, you're ready to sign your app package with **SignTool**.</span></span> <span data-ttu-id="6af0c-142">手動によるパッケージ化プロセスの次の手順については、「[SignTool を使ったアプリ パッケージの署名](https://msdn.microsoft.com/windows/uwp/packaging/sign-app-package-using-signtool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6af0c-142">For the next step in the manual packaging process, see [Sign an app package using SignTool](https://msdn.microsoft.com/windows/uwp/packaging/sign-app-package-using-signtool).</span></span>

## <a name="security-considerations"></a><span data-ttu-id="6af0c-143">セキュリティの考慮事項</span><span class="sxs-lookup"><span data-stu-id="6af0c-143">Security Considerations</span></span> 
<span data-ttu-id="6af0c-144">[ローカル コンピューターの証明書ストア](https://msdn.microsoft.com/windows/hardware/drivers/install/local-machine-and-current-user-certificate-stores)に証明書を追加することによって、コンピューター上のすべてのユーザーの証明書の信頼に影響します。</span><span class="sxs-lookup"><span data-stu-id="6af0c-144">By adding a certificate to [local machine certificate stores](https://msdn.microsoft.com/windows/hardware/drivers/install/local-machine-and-current-user-certificate-stores), you affect the certificate trust of all users on the computer.</span></span> <span data-ttu-id="6af0c-145">システムの信頼性を損なうのを防ぐために、これらの証明書が不要になったときには、削除することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6af0c-145">It is recommended that you remove those certificates when they are no longer necessary to prevent them from being used to compromise system trust.</span></span>
