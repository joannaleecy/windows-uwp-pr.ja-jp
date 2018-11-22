---
author: laurenhughes
title: アプリ インストーラー ファイルを使用して関連セットをインストールする
description: このセクションでは、アプリ インストーラーによる関連セットのインストールを許可するために必要な手順を確認します。 また、関連セットを定義する *.appinstaller ファイルの作成手順も確認します。
ms.author: lahugh
ms.date: 1/4/2018
ms.topic: article
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: 4caf4333bb3d442779aedac2028b0996cbd17645
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7576466"
---
# <a name="install-a-related-set-using-an-app-installer-file"></a><span data-ttu-id="2d082-105">アプリ インストーラー ファイルを使用して関連セットをインストールする</span><span class="sxs-lookup"><span data-stu-id="2d082-105">Install a related set using an App Installer file</span></span>

<span data-ttu-id="2d082-106">UWP オプション パッケージまたは関連セットの作業を始めたばかりであれば、開始にあたって参考にするリソースとして以下の記事が適しています。</span><span class="sxs-lookup"><span data-stu-id="2d082-106">If you're just starting out with UWP optional packages or related sets, the following articles are good resources to get started.</span></span> 

1.  [<span data-ttu-id="2d082-107">Extend your application using Optional Packages (オプション パッケージを使用してアプリケーションを拡張する)</span><span class="sxs-lookup"><span data-stu-id="2d082-107">Extend your application using Optional Packages</span></span>](https://blogs.msdn.microsoft.com/appinstaller/2017/04/05/uwpoptionalpackages/)
2.  [<span data-ttu-id="2d082-108">Build your first Optional Package (初めてのオプション パッケージを作成する)</span><span class="sxs-lookup"><span data-stu-id="2d082-108">Build your first Optional Package</span></span>](https://blogs.msdn.microsoft.com/appinstaller/2017/05/09/build-your-first-optional-package/)
3.  [<span data-ttu-id="2d082-109">Loading code from an optional package (オプション パッケージからコードを読み込む)</span><span class="sxs-lookup"><span data-stu-id="2d082-109">Loading code from an optional package</span></span>](https://blogs.msdn.microsoft.com/appinstaller/2017/05/11/loading-code-from-an-optional-package/)
4.  [<span data-ttu-id="2d082-110">Tooling to create a Related Set (関連セットを作成するためのツール)</span><span class="sxs-lookup"><span data-stu-id="2d082-110">Tooling to create a Related Set</span></span>](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/)
5.  [<span data-ttu-id="2d082-111">オプション パッケージと関連セットの作成</span><span class="sxs-lookup"><span data-stu-id="2d082-111">Optional packages and related set authoring</span></span>](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)

<span data-ttu-id="2d082-112">Windows 10 Fall Creators Update では、関連セットをアプリ インストーラーでインストールできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="2d082-112">With the Windows 10 Fall Creators Update, related sets can now be installed via App Installer.</span></span> <span data-ttu-id="2d082-113">これにより、関連セット アプリ パッケージをユーザーに配布および展開することが可能になります。</span><span class="sxs-lookup"><span data-stu-id="2d082-113">This allows distribution and deployment of related set app packages to users.</span></span> 

## <a name="how-to-install-a-related-set"></a><span data-ttu-id="2d082-114">関連セットのインストール方法</span><span class="sxs-lookup"><span data-stu-id="2d082-114">How to install a related set</span></span> 
<span data-ttu-id="2d082-115">関連セットとは、1 つのエンティティではなく、メイン パッケージとオプション パッケージの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="2d082-115">A related set is not one entity, but rather a combination of a main package and optional packages.</span></span> <span data-ttu-id="2d082-116">関連セットを 1 つのエンティティとしてインストールするには、メイン パッケージとオプション パッケージを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d082-116">To be able to install a related set as one entity, we must be able to specify the main package and optional package as one.</span></span> <span data-ttu-id="2d082-117">これを行うには、".appinstaller" という拡張子を持つ XML ファイルを作成して、関連セットを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d082-117">To do this, we will need to create an XML file with a ".appinstaller" extension to define a related set.</span></span> <span data-ttu-id="2d082-118">アプリ インストーラーでは \*.appinstaller ファイルが使用され、ユーザーは定義されているすべてのパッケージを 1 回のクリックでインストールできます。</span><span class="sxs-lookup"><span data-stu-id="2d082-118">App Installer consumes the \*.appinstaller file and allows the user to install all of the defined packages with a single click.</span></span> 

<span data-ttu-id="2d082-119">詳しい説明に入る前に、完全な \*.appinstaller ファイルの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="2d082-119">Before we go in to more detail, here is a complete sample \*.appinstaller file:</span></span>

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

<span data-ttu-id="2d082-120">展開時には、`Uri` 要素で参照されているアプリ パッケージに対してアプリ インストーラー ファイルの有効性が検証されます。</span><span class="sxs-lookup"><span data-stu-id="2d082-120">During deployment, the App Installer file is validated against the app packages referenced in the `Uri` element.</span></span> <span data-ttu-id="2d082-121">このため、`Name`、`Publisher`、および `Version` はアプリ パッケージ マニフェストの [Package/Identity](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) 要素に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d082-121">So, the `Name`, `Publisher` and `Version` should match the [Package/Identity](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) element in the app package manifest.</span></span> 

## <a name="how-to-create-an-app-installer-file"></a><span data-ttu-id="2d082-122">アプリ インストーラー ファイルの作成方法</span><span class="sxs-lookup"><span data-stu-id="2d082-122">How to create an App Installer file</span></span> 

<span data-ttu-id="2d082-123">関連セットを 1 つのエンティティとして配布するには、[appinstaller スキーマ](https://docs.microsoft.com/uwp/schemas/appinstallerschema/app-installer-file)に必要な要素が含まれたアプリ インストーラー ファイルを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d082-123">To distribute your related set as one entity, you must create an App Installer file that contains the elements that are required by that [appinstaller schema](https://docs.microsoft.com/uwp/schemas/appinstallerschema/app-installer-file).</span></span>

### <a name="step-1-create-the-appinstaller-file"></a><span data-ttu-id="2d082-124">手順 1: \*.appinstaller ファイルの作成</span><span class="sxs-lookup"><span data-stu-id="2d082-124">Step 1: Create the \*.appinstaller file</span></span>
<span data-ttu-id="2d082-125">テキスト エディターを使って、ファイル (XML が格納される) を作成し、&lt;ファイル名&gt;.appinstaller という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="2d082-125">Using a text editor, create a file (which will contain XML) and name it &lt;filename&gt;.appinstaller</span></span> 

### <a name="step-2-add-the-basic-template"></a><span data-ttu-id="2d082-126">手順 2: 基本的なテンプレートの追加</span><span class="sxs-lookup"><span data-stu-id="2d082-126">Step 2: Add the basic template</span></span>
<span data-ttu-id="2d082-127">基本的なテンプレートには、アプリ インストーラー ファイルの情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="2d082-127">The basic template includes the App Installer file information.</span></span> 
```xml
<?xml version="1.0" encoding="utf-8"?>
<AppInstaller
    xmlns="http://schemas.microsoft.com/appx/appinstaller/2017/2"
    Version="1.0.0.0" 
    Uri="http://mywebservice.azurewebsites.net/appset.appinstaller" > 
</AppInstaller>
```

### <a name="step-3-add-the-main-package-information"></a><span data-ttu-id="2d082-128">手順 3: メイン パッケージ情報の追加</span><span class="sxs-lookup"><span data-stu-id="2d082-128">Step 3: Add the main package information</span></span> 
<span data-ttu-id="2d082-129">使用して、メイン アプリ パッケージが .appxbundle または .msixbundle ファイルの場合、`<MainBundle>`の下に表示します。</span><span class="sxs-lookup"><span data-stu-id="2d082-129">If the main app package is an .appxbundle or .msixbundle file, then use the `<MainBundle>` shown below.</span></span> <span data-ttu-id="2d082-130">メイン アプリ パッケージが .appx または .msix ファイルの場合は使用し、`<MainPackage>`の代わりに`<MainBundle>`スニペットでします。</span><span class="sxs-lookup"><span data-stu-id="2d082-130">If the main app package is an .appx or .msix file, then use `<MainPackage>` in place of `<MainBundle>` in the snippet.</span></span> 

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
<span data-ttu-id="2d082-131">`<MainBundle>` 属性または `<MainPackage>` 属性に含まれる情報は、それぞれアプリ バンドル マニフェストまたはアプリ パッケージ マニフェストの [Package/Identity](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) 要素に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d082-131">The information in the `<MainBundle>` or `<MainPackage>` attribute should match the [Package/Identity](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) element in the app bundle manifest or app package manifest respectively.</span></span> 

### <a name="step-4-add-the-optional-packages"></a><span data-ttu-id="2d082-132">手順 4: オプション パッケージの追加</span><span class="sxs-lookup"><span data-stu-id="2d082-132">Step 4: Add the optional packages</span></span> 
<span data-ttu-id="2d082-133">メイン アプリ パッケージの属性と同様、オプション パッケージをアプリ パッケージまたはアプリ バンドルにできる場合は、`<OptionalPackages>` 属性内の子要素をそれぞれ `<Package>` または `<Bundle>` にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d082-133">Similar to the main app package attribute, if the optional package can be either an app package or an app bundle, the child element within the `<OptionalPackages>` attribute should be `<Package>` or `<Bundle>` respectively.</span></span> <span data-ttu-id="2d082-134">子要素内のパッケージ情報は、バンドルまたはパッケージのマニフェストの identity 要素と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d082-134">The package information in the child elements should match the identity element in the bundle or package manifest.</span></span> 

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

### <a name="step-5-add-dependencies"></a><span data-ttu-id="2d082-135">手順 5: 依存関係の追加</span><span class="sxs-lookup"><span data-stu-id="2d082-135">Step 5: Add dependencies</span></span> 
<span data-ttu-id="2d082-136">dependencies 要素では、メイン パッケージまたはオプション パッケージに必要なフレームワーク パッケージを指定できます。</span><span class="sxs-lookup"><span data-stu-id="2d082-136">In the dependencies element, you can specify the required framework packages for the main package or the optional packages.</span></span> 

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

### <a name="step-6-add-update-setting"></a><span data-ttu-id="2d082-137">手順 6: 更新設定の追加</span><span class="sxs-lookup"><span data-stu-id="2d082-137">Step 6: Add Update setting</span></span> 
<span data-ttu-id="2d082-138">アプリ インストーラー ファイルでは、新しいアプリ インストーラー ファイルが公開されたときに関連セットを自動的に更新できるように、更新設定を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="2d082-138">The App Installer file can also specify update setting so that the related sets can be automatically updated when a newer App Installer file is published.</span></span> <span data-ttu-id="2d082-139">**<UpdateSettings>** はオプションの要素です。</span><span class="sxs-lookup"><span data-stu-id="2d082-139">**<UpdateSettings>** is an optional element.</span></span> <span data-ttu-id="2d082-140">**<UpdateSettings>** 内で、OnLaunch オプションはアプリの起動時に更新プログラムのチェックを行うことを指定します。HoursBetweenUpdateChecks="12" は、更新プログラムのチェックを 12 時間おきに行うことを指定します。</span><span class="sxs-lookup"><span data-stu-id="2d082-140">Within  **<UpdateSettings>** the OnLaunch option specifies that update checks should be made on app launch, and HoursBetweenUpdateChecks="12" specifies that an update check should be made every 12 hours.</span></span> <span data-ttu-id="2d082-141">HoursBetweenUpdateChecks が指定されていない場合、更新プログラムをチェックするために使用される既定の間隔は 24 時間です。</span><span class="sxs-lookup"><span data-stu-id="2d082-141">If HoursBetweenUpdateChecks is not specified, the default interval used to check for updates is 24 hours.</span></span>
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

<span data-ttu-id="2d082-142">すべての XML スキーマについて詳しくは、「[アプリ インストーラー ファイル リファレンス](https://docs.microsoft.com/uwp/schemas/appinstallerschema/app-installer-file)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d082-142">For all of the details on the XML schema, see [App Installer file reference](https://docs.microsoft.com/uwp/schemas/appinstallerschema/app-installer-file).</span></span>

> [!NOTE]
> 
> <span data-ttu-id="2d082-143">アプリ インストーラー ファイルの種類は、Windows 10 Fall Creators Update の新機能です。</span><span class="sxs-lookup"><span data-stu-id="2d082-143">The App Installer file type is new in the Windows 10 Fall Creators Update.</span></span> <span data-ttu-id="2d082-144">以前のバージョンの Windows 10 では、アプリ インストーラー ファイルの使用による UWP アプリの展開はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="2d082-144">There is no support for deployment of UWP apps using an App Installer file on previous versions of Windows 10.</span></span>
> <span data-ttu-id="2d082-145">**HoursBetweenUpdateChecks** 要素は、Windows 10 の次のメジャー アップデートにおける新機能である点にも注意してください。</span><span class="sxs-lookup"><span data-stu-id="2d082-145">It also should be noted that the **HoursBetweenUpdateChecks** element is new in the next major update to Windows 10.</span></span>
