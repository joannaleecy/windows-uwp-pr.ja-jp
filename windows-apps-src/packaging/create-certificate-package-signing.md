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
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7162411"
---
# <a name="create-a-certificate-for-package-signing"></a>パッケージ署名用の証明書を作成する


この記事では、PowerShell ツールを使用して、アプリ パッケージ署名用の証明書を作成してエクスポートする方法について説明します。 Visual Studio を使用して [UWP アプリをパッケージ化する](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)ことをお勧めしますが、Visual Studio を使用してアプリを開発していない場合は、ストア対応アプリを手動でパッケージ化することができます。

> [!IMPORTANT] 
> Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使って証明書をインポートし、アプリ パッケージに署名することをお勧めします。 詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。

## <a name="prerequisites"></a>前提条件

- **パッケージ化されている、またはパッケージ化されていないアプリ**  
AppxManifest.xml ファイルを含むアプリ。 マニフェスト ファイルを参照して、最終的なアプリ パッケージの署名に使われる証明書を作成する必要があります。 手動でアプリをパッケージ化する方法について詳しくは、「[MakeAppx.exe ツールを使ってアプリ パッケージを作成する](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。

- **公開キー基盤 (PKI) コマンドレット**  
署名証明書を作成およびエクスポートするには、PKI コマンドレットが必要です。 詳しくは、「[公開キー基盤コマンドレット](https://docs.microsoft.com/powershell/module/pkiclient/)」をご覧ください。

## <a name="create-a-self-signed-certificate"></a>自己署名証明書を作成する

自己署名証明書は、ストアに公開する準備が整う前に、アプリをテストするために便利です。 自己署名証明書を作成するには、このセクションで説明する手順に従います。

### <a name="determine-the-subject-of-your-packaged-app"></a>パッケージ アプリのサブジェクトを決定する  

証明書を使ってアプリ パッケージに署名するには、証明書の「サブジェクト」がアプリのマニフェストの [Publisher] セクションと**一致する必要**があります。

たとえば、アプリの AppxManifest.xml ファイルの [Identity] セクションは、次のようになります。
```
  <Identity Name="Contoso.AssetTracker" 
    Version="1.0.0.0" 
    Publisher="CN=Contoso Software, O=Contoso Corporation, C=US"/>
```

この例では [Publisher] は "CN=Contoso Software, O=Contoso Corporation, C=US" で、これを証明書の作成に使用する必要があります。 

### <a name="use-new-selfsignedcertificate-to-create-a-certificate"></a>**New-SelfSignedCertificate** を使って証明書を作成する
PowerShell コマンドレット **New-SelfSignedCertificate** を使用して自己署名証明書を作成します。 **New-SelfSignedCertificate** にはカスタマイズのためのいくつかのパラメーターがありますが、この記事では、**SignTool** で動作する簡単な証明書の作成を中心に説明します。 このコマンドレットの使用とその例について詳しくは、「[New-SelfSignedCertificate](https://docs.microsoft.com/powershell/module/pkiclient/New-SelfSignedCertificate)」をご覧ください。

前の例の AppxManifest.xml ファイルに基づいて、次の構文を使用して証明書を作成する必要があります。 管理者特権の PowerShell プロンプトで、次のコマンドを実行します。
```
New-SelfSignedCertificate -Type Custom -Subject "CN=Contoso Software, O=Contoso Corporation, C=US" -KeyUsage DigitalSignature -FriendlyName <Your Friendly Name> -CertStoreLocation "Cert:\LocalMachine\My"
```

このコマンドを実行すると、"-CertStoreLocation" パラメーターで指定されたローカル証明書ストアに証明書が追加されます。 コマンドの結果には、証明書のサムプリントも生成されます。  

**注意**  
次のコマンドを使って、PowerShell ウィンドウで証明書を表示できます。
```
Set-Location Cert:\LocalMachine\My
Get-ChildItem | Format-Table Subject, FriendlyName, Thumbprint
```
これにより、ローカル ストア内のすべての証明書が表示されます。

## <a name="export-a-certificate"></a>証明書のエクスポート 

ローカル ストアの証明書を Personal Information Exchange (.pfx) ファイルにエクスポートするには、**Export-PfxCertificate** コマンドレットを使用します。

**Export-PfxCertificate** コマンドレットを使用する場合は、パスワードを作成して使用するか、"-ProtectTo" パラメーターを使用して、パスワードなしでファイルにアクセスできるユーザーまたはグループを指定する必要があります。 "-Password" または "-ProtectTo" パラメーターのいずれかを使用しない場合、エラーが表示されます。

- **Password を使用**
```
$pwd = ConvertTo-SecureString -String <Your Password> -Force -AsPlainText 
Export-PfxCertificate -cert "Cert:\LocalMachine\My\<Certificate Thumbprint>" -FilePath <FilePath>.pfx -Password $pwd
```

- **ProtectTo を使用**
```
Export-PfxCertificate -cert Cert:\LocalMachine\My\<Certificate Thumbprint> -FilePath <FilePath>.pfx -ProtectTo <Username or group name>
```

証明書を作成してエクスポートしたら、**SignTool** を使ってアプリ パッケージに署名する準備が整いました。 手動によるパッケージ化プロセスの次の手順については、「[SignTool を使ったアプリ パッケージの署名](https://msdn.microsoft.com/windows/uwp/packaging/sign-app-package-using-signtool)」をご覧ください。

## <a name="security-considerations"></a>セキュリティの考慮事項 
[ローカル コンピューターの証明書ストア](https://msdn.microsoft.com/windows/hardware/drivers/install/local-machine-and-current-user-certificate-stores)に証明書を追加することによって、コンピューター上のすべてのユーザーの証明書の信頼に影響します。 システムの信頼性を損なうのを防ぐために、これらの証明書が不要になったときには、削除することをお勧めします。
