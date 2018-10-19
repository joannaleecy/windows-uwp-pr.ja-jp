---
author: laurenhughes
title: アプリ インストーラー ファイルを使用して関連セットをインストールする
description: このセクションでは、アプリ インストーラーによる関連セットのインストールを許可するために必要な手順を確認します。 また、関連セットを定義する *.appinstaller ファイルの作成手順も確認します。
ms.author: lahugh
ms.date: 1/4/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: 965ef217fa00131504841ef2209dbe6aa54f50af
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4950612"
---
# <a name="install-a-related-set-using-an-app-installer-file"></a>アプリ インストーラー ファイルを使用して関連セットをインストールする

UWP オプション パッケージまたは関連セットの作業を始めたばかりであれば、開始にあたって参考にするリソースとして以下の記事が適しています。 

1.  [Extend your application using Optional Packages (オプション パッケージを使用してアプリケーションを拡張する)](https://blogs.msdn.microsoft.com/appinstaller/2017/04/05/uwpoptionalpackages/)
2.  [Build your first Optional Package (初めてのオプション パッケージを作成する)](https://blogs.msdn.microsoft.com/appinstaller/2017/05/09/build-your-first-optional-package/)
3.  [Loading code from an optional package (オプション パッケージからコードを読み込む)](https://blogs.msdn.microsoft.com/appinstaller/2017/05/11/loading-code-from-an-optional-package/)
4.  [Tooling to create a Related Set (関連セットを作成するためのツール)](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/)
5.  [オプション パッケージと関連セットの作成](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)

Windows 10 Fall Creators Update では、関連セットをアプリ インストーラーでインストールできるようになりました。 これにより、関連セット アプリ パッケージをユーザーに配布および展開することが可能になります。 

## <a name="how-to-install-a-related-set"></a>関連セットのインストール方法 
関連セットとは、1 つのエンティティではなく、メイン パッケージとオプション パッケージの組み合わせです。 関連セットを 1 つのエンティティとしてインストールするには、メイン パッケージとオプション パッケージを指定する必要があります。 これを行うには、".appinstaller" という拡張子を持つ XML ファイルを作成して、関連セットを定義する必要があります。 アプリ インストーラーでは *.appinstaller ファイルが使用され、ユーザーは定義されているすべてのパッケージを 1 回のクリックでインストールできます。 

詳しい説明に入る前に、完全な *.appinstaller ファイルの例を次に示します。

```xml
<?xml version="1.0" encoding="utf-8"?>
<AppInstaller
    xmlns="http://schemas.microsoft.com/appx/appinstaller/2017/2"
    Version="1.0.0.0" 
    Uri="http://mywebservice.azurewebsites.net/appset.appinstaller" > 
   
    <MainBundle 
        Name="Contoso.MainApp"
        Publisher="CN=Contoso"
        Version="2.23.12.43"
        Uri="http://mywebservice.azurewebsites.net/mainapp.appxbundle" />
        
    <OptionalPackages>
        <Bundle
            Name="Contoso.OptionalApp1"
            Publisher="CN=Contoso"
            Version="2.23.12.43"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp1.appxbundle" />

        <Bundle
            Name="Contoso.OptionalApp2"
            Publisher="CN=Contoso"
            Version="2.23.12.43"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp2.appxbundle" />

        <Package
            Name="Fabrikam.OptionalApp3"
            Publisher="CN=Fabrikam"
            Version="10.34.54.23"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp3.appx" />

    </OptionalPackages>

</AppInstaller>
```

展開時には、`Uri` 要素で参照されているアプリ パッケージに対してアプリ インストーラー ファイルの有効性が検証されます。 このため、`Name`、`Publisher`、および `Version` はアプリ パッケージ マニフェストの [Package/Identity](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) 要素に一致する必要があります。 

## <a name="how-to-create-an-app-installer-file"></a>アプリ インストーラー ファイルの作成方法 

関連セットを 1 つのエンティティとして配布するには、[appinstaller スキーマ](https://docs.microsoft.com/uwp/schemas/appinstallerschema/app-installer-file)に必要な要素が含まれたアプリ インストーラー ファイルを作成する必要があります。

### <a name="step-1-create-the-appinstaller-file"></a>手順 1: *.appinstaller ファイルの作成
テキスト エディターを使って、ファイル (XML が格納される) を作成し、&lt;ファイル名&gt;.appinstaller という名前を付けます。 

### <a name="step-2-add-the-basic-template"></a>手順 2: 基本的なテンプレートの追加
基本的なテンプレートには、アプリ インストーラー ファイルの情報が含まれています。 
```xml
<?xml version="1.0" encoding="utf-8"?>
<AppInstaller
    xmlns="http://schemas.microsoft.com/appx/appinstaller/2017/2"
    Version="1.0.0.0" 
    Uri="http://mywebservice.azurewebsites.net/appset.appinstaller" > 
</AppInstaller>
```

### <a name="step-3-add-the-main-package-information"></a>手順 3: メイン パッケージ情報の追加 
メイン アプリ パッケージが .appxbundle または .msixbundle ファイルの場合は使用し、`<MainBundle>`の下に表示します。 メイン アプリ パッケージが .appx または .msix ファイルの場合は使用し、`<MainPackage>`の代わりに`<MainBundle>`スニペットではします。 

```xml
<?xml version="1.0" encoding="utf-8"?>
<AppInstaller
    xmlns="http://schemas.microsoft.com/appx/appinstaller/2017/2"
    Version="1.0.0.0" 
    Uri="http://mywebservice.azurewebsites.net/appset.appinstaller" > 
   
    <MainBundle 
        Name="Contoso.MainApp"
        Publisher="CN=Contoso"
        Version="2.23.12.43"
        Uri="http://mywebservice.azurewebsites.net/mainapp.appxbundle" />

</AppInstaller>
```
`<MainBundle>` 属性または `<MainPackage>` 属性に含まれる情報は、それぞれアプリ バンドル マニフェストまたはアプリ パッケージ マニフェストの [Package/Identity](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) 要素に一致する必要があります。 

### <a name="step-4-add-the-optional-packages"></a>手順 4: オプション パッケージの追加 
メイン アプリ パッケージの属性と同様、オプション パッケージをアプリ パッケージまたはアプリ バンドルにできる場合は、`<OptionalPackages>` 属性内の子要素をそれぞれ `<Package>` または `<Bundle>` にする必要があります。 子要素内のパッケージ情報は、バンドルまたはパッケージのマニフェストの identity 要素と一致する必要があります。 

``` xml
<?xml version="1.0" encoding="utf-8"?>
<AppInstaller
    xmlns="http://schemas.microsoft.com/appx/appinstaller/2017/2"
    Version="1.0.0.0" 
    Uri="http://mywebservice.azurewebsites.net/appset.appinstaller" > 
   
    <MainBundle 
        Name="Contoso.MainApp"
        Publisher="CN=Contoso"
        Version="2.23.12.43"
        Uri="http://mywebservice.azurewebsites.net/mainapp.appxbundle" />
        
    <OptionalPackages>
        <Bundle
            Name="Contoso.OptionalApp1"
            Publisher="CN=Contoso"
            Version="2.23.12.43"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp1.appxbundle" />

        <Bundle
            Name="Contoso.OptionalApp2"
            Publisher="CN=Contoso"
            Version="2.23.12.43"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp2.appxbundle" />

        <Package
            Name="Fabrikam.OptionalApp3"
            Publisher="CN=Fabrikam"
            Version="10.34.54.23"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp3.appx" />

    </OptionalPackages>

</AppInstaller>
```

### <a name="step-5-add-dependencies"></a>手順 5: 依存関係の追加 
dependencies 要素では、メイン パッケージまたはオプション パッケージに必要なフレームワーク パッケージを指定できます。 

``` xml
<?xml version="1.0" encoding="utf-8"?>
<AppInstaller
    xmlns="http://schemas.microsoft.com/appx/appinstaller/2017/2"
    Version="1.0.0.0" 
    Uri="http://mywebservice.azurewebsites.net/appset.appinstaller" > 
   
    <MainBundle 
        Name="Contoso.MainApp"
        Publisher="CN=Contoso"
        Version="2.23.12.43"
        Uri="http://mywebservice.azurewebsites.net/mainapp.appxbundle" />
        
    <OptionalPackages>
        <Bundle
            Name="Contoso.OptionalApp1"
            Publisher="CN=Contoso"
            Version="2.23.12.43"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp1.appxbundle" />

        <Bundle
            Name="Contoso.OptionalApp2"
            Publisher="CN=Contoso"
            Version="2.23.12.43"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp2.appxbundle" />

        <Package
            Name="Fabrikam.OptionalApp3"
            Publisher="CN=Fabrikam"
            Version="10.34.54.23"
            ProcessorArchitecture="x86"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp3.appx" />

    </OptionalPackages>

    <Dependencies>
        <Package Name="Microsoft.VCLibs.140.00" Publisher="CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US" Version="14.0.24605.0" ProcessorArchitecture="x86" Uri="http://foobarbaz.com/fwkx86.appx" />
        <Package Name="Microsoft.VCLibs.140.00" Publisher="CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US" Version="14.0.24605.0" ProcessorArchitecture="x64" Uri="http://foobarbaz.com/fwkx64.appx" />
    </Dependencies>

</AppInstaller>
```

### <a name="step-6-add-update-setting"></a>手順 6: 更新設定の追加 
アプリ インストーラー ファイルでは、新しいアプリ インストーラー ファイルが公開されたときに関連セットを自動的に更新できるように、更新設定を指定することもできます。 **<UpdateSettings>** はオプションの要素です。 **<UpdateSettings>** 内で、OnLaunch オプションはアプリの起動時に更新プログラムのチェックを行うことを指定します。HoursBetweenUpdateChecks="12" は、更新プログラムのチェックを 12 時間おきに行うことを指定します。 HoursBetweenUpdateChecks が指定されていない場合、更新プログラムをチェックするために使用される既定の間隔は 24 時間です。
``` xml
<?xml version="1.0" encoding="utf-8"?>
<AppInstaller
    xmlns="http://schemas.microsoft.com/appx/appinstaller/2017/2"
    Version="1.0.0.0" 
    Uri="http://mywebservice.azurewebsites.net/appset.appinstaller" > 
   
    <MainBundle 
        Name="Contoso.MainApp"
        Publisher="CN=Contoso"
        Version="2.23.12.43"
        Uri="http://mywebservice.azurewebsites.net/mainapp.appxbundle" />
        
    <OptionalPackages>
        <Bundle
            Name="Contoso.OptionalApp1"
            Publisher="CN=Contoso"
            Version="2.23.12.43"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp1.appxbundle" />

        <Bundle
            Name="Contoso.OptionalApp2"
            Publisher="CN=Contoso"
            Version="2.23.12.43"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp2.appxbundle" />

        <Package
            Name="Fabrikam.OptionalApp3"
            Publisher="CN=Fabrikam"
            Version="10.34.54.23"
            ProcessorArchitecture="x86"
            Uri="http://mywebservice.azurewebsites.net/OptionalApp3.appx" />

    </OptionalPackages>

    <Dependencies>
        <Package Name="Microsoft.VCLibs.140.00" Publisher="CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US" Version="14.0.24605.0" ProcessorArchitecture="x86" Uri="http://foobarbaz.com/fwkx86.appx" />
        <Package Name="Microsoft.VCLibs.140.00" Publisher="CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US" Version="14.0.24605.0" ProcessorArchitecture="x64" Uri="http://foobarbaz.com/fwkx64.appx" />
    </Dependencies>
    
    <UpdateSettings>
        <OnLaunch HoursBetweenUpdateChecks="12" />
    </UpdateSettings>

</AppInstaller>
```

すべての XML スキーマについて詳しくは、「[アプリ インストーラー ファイル リファレンス](https://docs.microsoft.com/uwp/schemas/appinstallerschema/app-installer-file)」をご覧ください。

> [!NOTE]
> 
> アプリ インストーラー ファイルの種類は、Windows 10 Fall Creators Update の新機能です。 以前のバージョンの Windows 10 では、アプリ インストーラー ファイルの使用による UWP アプリの展開はサポートされていません。
> **HoursBetweenUpdateChecks** 要素は、Windows 10 の次のメジャー アップデートにおける新機能である点にも注意してください。
