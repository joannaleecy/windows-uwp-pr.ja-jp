---
title: パッケージ署名用証明書を作成する
description: PowerShell ツールを使ってアプリ パッケージ署名用を作成し、エクスポートします。
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 7bc2006f-fc5a-4ff6-b573-60933882caf8
ms.localizationpriority: medium
ms.openlocfilehash: a8d94f43edbdc3ec410ae7f878b38d41cddf5145
ms.sourcegitcommit: f15cf141c299bde9cb19965d8be5198d7f85adf8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2019
ms.locfileid: "58358607"
---
# <a name="create-a-certificate-for-package-signing"></a><span data-ttu-id="c26d9-104">パッケージ署名用証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="c26d9-104">Create a certificate for package signing</span></span>


<span data-ttu-id="c26d9-105">この記事では、PowerShell ツールを使用して、アプリ パッケージ署名用の証明書を作成してエクスポートする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-105">This article explains how to create and export a certificate for app package signing using PowerShell tools.</span></span> <span data-ttu-id="c26d9-106">Visual Studio を使用して [UWP アプリをパッケージ化する](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)ことをお勧めしますが、Visual Studio を使用してアプリを開発していない場合は、ストア対応アプリを手動でパッケージ化することができます。</span><span class="sxs-lookup"><span data-stu-id="c26d9-106">It's recommended that you use Visual Studio for [Packaging UWP apps](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps), but you can still package a Store ready app manually if you did not use Visual Studio to develop your app.</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="c26d9-107">Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使って証明書をインポートし、アプリ パッケージに署名することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c26d9-107">If you used Visual Studio to develop your app, it's recommended that you use the Visual Studio wizard to import a certificate and sign your app package.</span></span> <span data-ttu-id="c26d9-108">詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c26d9-108">For more information, see [Package a UWP app with Visual Studio](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="c26d9-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="c26d9-109">Prerequisites</span></span>

- <span data-ttu-id="c26d9-110">**パッケージまたはパッケージ化されていないアプリ**</span><span class="sxs-lookup"><span data-stu-id="c26d9-110">**A packaged or unpackaged app**</span></span>  
<span data-ttu-id="c26d9-111">AppxManifest.xml ファイルを含むアプリ。</span><span class="sxs-lookup"><span data-stu-id="c26d9-111">An app containing an AppxManifest.xml file.</span></span> <span data-ttu-id="c26d9-112">マニフェスト ファイルを参照して、最終的なアプリ パッケージの署名に使われる証明書を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c26d9-112">You will need to reference the manifest file while creating the certificate that will be used to sign the final app package.</span></span> <span data-ttu-id="c26d9-113">手動でアプリをパッケージ化する方法について詳しくは、「[MakeAppx.exe ツールを使ってアプリ パッケージを作成する](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c26d9-113">For details on how to manually package an app, see [Create an app package with the MakeAppx.exe tool](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool).</span></span>

- <span data-ttu-id="c26d9-114">**公開キー基盤 (PKI) のコマンドレット**</span><span class="sxs-lookup"><span data-stu-id="c26d9-114">**Public Key Infrastructure (PKI) Cmdlets**</span></span>  
<span data-ttu-id="c26d9-115">署名証明書を作成およびエクスポートするには、PKI コマンドレットが必要です。</span><span class="sxs-lookup"><span data-stu-id="c26d9-115">You need PKI cmdlets to create and export your signing certificate.</span></span> <span data-ttu-id="c26d9-116">詳しくは、「[公開キー基盤コマンドレット](https://docs.microsoft.com/powershell/module/pkiclient/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c26d9-116">For more information, see [Public Key Infrastructure Cmdlets](https://docs.microsoft.com/powershell/module/pkiclient/).</span></span>

## <a name="create-a-self-signed-certificate"></a><span data-ttu-id="c26d9-117">自己署名証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="c26d9-117">Create a self-signed certificate</span></span>

<span data-ttu-id="c26d9-118">自己署名証明書は、ストアに発行する準備ができた前に、アプリのテストに便利です。</span><span class="sxs-lookup"><span data-stu-id="c26d9-118">A self-signed certificate is useful for testing your app before you're ready to publish it to the Store.</span></span> <span data-ttu-id="c26d9-119">自己署名証明書を作成するには、このセクションで説明されている手順に従います。</span><span class="sxs-lookup"><span data-stu-id="c26d9-119">Follow the steps outlined in this section to create a self-signed certificate.</span></span>

### <a name="determine-the-subject-of-your-packaged-app"></a><span data-ttu-id="c26d9-120">パッケージ アプリのサブジェクトを決定する</span><span class="sxs-lookup"><span data-stu-id="c26d9-120">Determine the subject of your packaged app</span></span>  

<span data-ttu-id="c26d9-121">証明書を使ってアプリ パッケージに署名するには、証明書の「サブジェクト」がアプリのマニフェストの [Publisher] セクションと**一致する必要**があります。</span><span class="sxs-lookup"><span data-stu-id="c26d9-121">To use a certificate to sign your app package, the "Subject" in the certificate **must** match the "Publisher" section in your app's manifest.</span></span>

<span data-ttu-id="c26d9-122">たとえば、アプリの AppxManifest.xml ファイルの [Identity] セクションは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="c26d9-122">For example, the "Identity" section in your app's AppxManifest.xml file should look something like this:</span></span>

```xml
  <Identity Name="Contoso.AssetTracker" 
    Version="1.0.0.0" 
    Publisher="CN=Contoso Software, O=Contoso Corporation, C=US"/>
```

<span data-ttu-id="c26d9-123">この例では [Publisher] は "CN=Contoso Software, O=Contoso Corporation, C=US" で、これを証明書の作成に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c26d9-123">The "Publisher", in this case, is "CN=Contoso Software, O=Contoso Corporation, C=US" which needs to be used for creating your certificate.</span></span>

### <a name="use-new-selfsignedcertificate-to-create-a-certificate"></a><span data-ttu-id="c26d9-124">**New-SelfSignedCertificate** を使って証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="c26d9-124">Use **New-SelfSignedCertificate** to create a certificate</span></span>

<span data-ttu-id="c26d9-125">PowerShell コマンドレット **New-SelfSignedCertificate** を使用して自己署名証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-125">Use the **New-SelfSignedCertificate** PowerShell cmdlet to create a self signed certificate.</span></span> <span data-ttu-id="c26d9-126">**New-SelfSignedCertificate** にはカスタマイズのためのいくつかのパラメーターがありますが、この記事では、**SignTool** で動作する簡単な証明書の作成を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-126">**New-SelfSignedCertificate** has several parameters for customization, but for the purpose of this article, we'll focus on creating a simple certificate that will work with **SignTool**.</span></span> <span data-ttu-id="c26d9-127">このコマンドレットの使用とその例について詳しくは、「[New-SelfSignedCertificate](https://docs.microsoft.com/powershell/module/pkiclient/New-SelfSignedCertificate)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c26d9-127">For more examples and uses of this cmdlet, see [New-SelfSignedCertificate](https://docs.microsoft.com/powershell/module/pkiclient/New-SelfSignedCertificate).</span></span>

<span data-ttu-id="c26d9-128">前の例の AppxManifest.xml ファイルに基づいて、次の構文を使用して証明書を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c26d9-128">Based on the AppxManifest.xml file from the previous example, you should use the following syntax to create a certificate.</span></span> <span data-ttu-id="c26d9-129">管理者特権の PowerShell プロンプトで、次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-129">In an elevated PowerShell prompt:</span></span>

```powershell
New-SelfSignedCertificate -Type Custom -Subject "CN=Contoso Software, O=Contoso Corporation, C=US" -KeyUsage DigitalSignature -FriendlyName "Your friendly name goes here" -CertStoreLocation "Cert:\LocalMachine\My" -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}")
```

<span data-ttu-id="c26d9-130">一部のパラメーターの詳細については、次の詳細を確認してください。</span><span class="sxs-lookup"><span data-stu-id="c26d9-130">Note the following details about some of the parameters:</span></span>

- <span data-ttu-id="c26d9-131">**KeyUsage**:このパラメーターは、証明書が使用目的を定義します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-131">**KeyUsage**: This parameter defines what the certificate may be used for.</span></span> <span data-ttu-id="c26d9-132">自己署名証明書の場合にこのパラメーターを設定する必要があります**DigitalSignature**します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-132">For a self-signing certificate, this parameter should be set to **DigitalSignature**.</span></span>

- <span data-ttu-id="c26d9-133">**TextExtension**:このパラメーターには、次の拡張機能の設定が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c26d9-133">**TextExtension**: This parameter includes settings for the following extensions:</span></span>

  - <span data-ttu-id="c26d9-134">拡張キー使用法 (EKU)。この拡張機能では、他の目的で、認定公開キーを使えることを示します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-134">Extended Key Usage (EKU): This extension indicates additional purposes for which the certified public key may be used.</span></span> <span data-ttu-id="c26d9-135">自己署名証明書では、このパラメーターは、拡張子の文字列を含める必要があります **"2.5.29.37={text}1.3.6.1.5.5.7.3.3"**、証明書がコード署名に使用することを示します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-135">For a self-signing certificate, this parameter should include the extension string **"2.5.29.37={text}1.3.6.1.5.5.7.3.3"**, which indicates that the certificate is to be used for code signing.</span></span>

  - <span data-ttu-id="c26d9-136">基本的な制約:この拡張機能は、証明書が証明書機関 (CA) かどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-136">Basic Constraints: This extension indicates whether or not the certificate is a Certificate Authority (CA).</span></span> <span data-ttu-id="c26d9-137">自己署名証明書では、このパラメーターは、拡張子の文字列を含める必要があります **"2.5.29.19={text}"**、証明書がエンド エンティティ (CA ではない) を示します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-137">For a self-signing certificate, this parameter should include the extension string **"2.5.29.19={text}"**, which indicates that the certificate is an end entity (not a CA).</span></span>

<span data-ttu-id="c26d9-138">このコマンドを実行すると、"-CertStoreLocation" パラメーターで指定されたローカル証明書ストアに証明書が追加されます。</span><span class="sxs-lookup"><span data-stu-id="c26d9-138">After running this command, the certificate will be added to the local certificate store, as specified in the "-CertStoreLocation" parameter.</span></span> <span data-ttu-id="c26d9-139">コマンドの結果には、証明書の拇印も生成されます。</span><span class="sxs-lookup"><span data-stu-id="c26d9-139">The result of the command will also produce the certificate's thumbprint.</span></span>  

<span data-ttu-id="c26d9-140">次のコマンドを使って、PowerShell ウィンドウで証明書を表示できます。</span><span class="sxs-lookup"><span data-stu-id="c26d9-140">You can view your certificate in a PowerShell window by using the following commands:</span></span>

```powershell
Set-Location Cert:\LocalMachine\My
Get-ChildItem | Format-Table Subject, FriendlyName, Thumbprint
```

<span data-ttu-id="c26d9-141">これにより、ローカル ストア内のすべての証明書が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c26d9-141">This will display all of the certificates in your local store.</span></span>

## <a name="export-a-certificate"></a><span data-ttu-id="c26d9-142">証明書のエクスポート</span><span class="sxs-lookup"><span data-stu-id="c26d9-142">Export a certificate</span></span> 

<span data-ttu-id="c26d9-143">ローカル ストアの証明書を Personal Information Exchange (.pfx) ファイルにエクスポートするには、**Export-PfxCertificate** コマンドレットを使用します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-143">To export the certificate in the local store to a Personal Information Exchange (PFX) file, use the **Export-PfxCertificate** cmdlet.</span></span>

<span data-ttu-id="c26d9-144">**Export-PfxCertificate** コマンドレットを使用する場合は、パスワードを作成して使用するか、"-ProtectTo" パラメーターを使用して、パスワードなしでファイルにアクセスできるユーザーまたはグループを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c26d9-144">When using **Export-PfxCertificate**, you must either create and use a password or use the "-ProtectTo" parameter to specify which users or groups can access the file without a password.</span></span> <span data-ttu-id="c26d9-145">"-Password" または "-ProtectTo" パラメーターのいずれかを使用しない場合、エラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c26d9-145">Note that an error will be displayed if you don't use either the "-Password" or "-ProtectTo" parameter.</span></span>

### <a name="password-usage"></a><span data-ttu-id="c26d9-146">Password を使用</span><span class="sxs-lookup"><span data-stu-id="c26d9-146">Password usage</span></span>

```powershell
$pwd = ConvertTo-SecureString -String <Your Password> -Force -AsPlainText 
Export-PfxCertificate -cert "Cert:\LocalMachine\My\<Certificate Thumbprint>" -FilePath <FilePath>.pfx -Password $pwd
```

### <a name="protectto-usage"></a><span data-ttu-id="c26d9-147">ProtectTo を使用</span><span class="sxs-lookup"><span data-stu-id="c26d9-147">ProtectTo usage</span></span>

```powershell
Export-PfxCertificate -cert Cert:\LocalMachine\My\<Certificate Thumbprint> -FilePath <FilePath>.pfx -ProtectTo <Username or group name>
```

<span data-ttu-id="c26d9-148">証明書を作成してエクスポートしたら、**SignTool** を使ってアプリ パッケージに署名する準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="c26d9-148">After you create and export your certificate, you're ready to sign your app package with **SignTool**.</span></span> <span data-ttu-id="c26d9-149">手動によるパッケージ化プロセスの次の手順については、「[SignTool を使ったアプリ パッケージの署名](https://msdn.microsoft.com/windows/uwp/packaging/sign-app-package-using-signtool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c26d9-149">For the next step in the manual packaging process, see [Sign an app package using SignTool](https://msdn.microsoft.com/windows/uwp/packaging/sign-app-package-using-signtool).</span></span>

## <a name="security-considerations"></a><span data-ttu-id="c26d9-150">セキュリティの考慮事項</span><span class="sxs-lookup"><span data-stu-id="c26d9-150">Security considerations</span></span>

<span data-ttu-id="c26d9-151">[ローカル コンピューターの証明書ストア](https://msdn.microsoft.com/windows/hardware/drivers/install/local-machine-and-current-user-certificate-stores)に証明書を追加することによって、コンピューター上のすべてのユーザーの証明書の信頼に影響します。</span><span class="sxs-lookup"><span data-stu-id="c26d9-151">By adding a certificate to [local machine certificate stores](https://msdn.microsoft.com/windows/hardware/drivers/install/local-machine-and-current-user-certificate-stores), you affect the certificate trust of all users on the computer.</span></span> <span data-ttu-id="c26d9-152">システムの信頼性を損なうのを防ぐために、これらの証明書が不要になったときには、削除することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c26d9-152">It is recommended that you remove those certificates when they are no longer necessary to prevent them from being used to compromise system trust.</span></span>
