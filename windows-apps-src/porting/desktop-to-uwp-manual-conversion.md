---
author: normesta
Description: Shows how to manually package a Windows desktop application (like Win32, WPF, and Windows Forms) for Windows 10.
Search.Product: eADQiWindows 10XVcnh
title: アプリを手動でパッケージ化する (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 05/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: e8c2a803-9803-47c5-b117-73c4af52c5b6
ms.localizationpriority: medium
ms.openlocfilehash: eeadd41debcfcf5cfde23948c52bdfe1ce32e9df
ms.sourcegitcommit: cd91724c9b81c836af4773df8cd78e9f808a0bb4
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/07/2018
ms.locfileid: "1989646"
---
# <a name="package-an-app-manually-desktop-bridge"></a><span data-ttu-id="8b963-103">アプリを手動でパッケージ化する (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="8b963-103">Package an app manually (Desktop Bridge)</span></span>

<span data-ttu-id="8b963-104">このトピックでは、Visual Studio、Desktop App Converter (DAC) などのツールを使用せずにアプリをパッケージ化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="8b963-104">This topic shows you how to package your app without using tools such as Visual Studio or the Desktop App Converter (DAC).</span></span>

<span data-ttu-id="8b963-105">アプリを手動でパッケージ化するには、パッケージ マニフェスト ファイルを作成してから、Windows アプリ パッケージを生成するコマンド ライン ツールを実行します。</span><span class="sxs-lookup"><span data-stu-id="8b963-105">To manually package your app, create a package manifest file, and then run a command line tool to generate a Windows app package.</span></span>

<span data-ttu-id="8b963-106">xcopy コマンドを使用してアプリをインストールする場合や、アプリのインストーラーがシステムに加える変更を熟知したうえで、プロセスをきめ細かく制御する必要がある場合は、手動によるパッケージ化を検討してください。</span><span class="sxs-lookup"><span data-stu-id="8b963-106">Consider manual packaging if you install your app by using the xcopy command, or you're familiar with the changes that your app's installer makes to the system and want more granular control over the process.</span></span>

<span data-ttu-id="8b963-107">インストーラーによってどのような変更がシステムに加えられるのかわからない場合や、自動化ツールを使用してパッケージ マニフェストを生成する場合は、[こちら](desktop-to-uwp-root.md#convert)のオプションのいずれかを検討してください。</span><span class="sxs-lookup"><span data-stu-id="8b963-107">If you're uncertain about what changes your installer makes to the system, or if you'd rather use automated tools to generate your package manifest, consider any of [these](desktop-to-uwp-root.md#convert) options.</span></span>

>[!IMPORTANT]
><span data-ttu-id="8b963-108">デスクトップ ブリッジは、Windows 10 Version 1607 で導入されており、Windows 10 Anniversary Update (10.0、ビルド 14393) 以降のリリースをターゲットとする Visual Studio プロジェクトでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="8b963-108">The Desktop Bridge was introduced in Windows 10, version 1607, and it can only be used in projects that target Windows 10 Anniversary Update (10.0; Build 14393) or a later release in Visual Studio.</span></span>

## <a name="first-prepare-your-application"></a><span data-ttu-id="8b963-109">まず、アプリケーションを準備します</span><span class="sxs-lookup"><span data-stu-id="8b963-109">First, prepare your application</span></span>

<span data-ttu-id="8b963-110">アプリケーションのパッケージの作成を開始する前に、必ず「[アプリのパッケージ化の準備 (デスクトップ ブリッジ)](desktop-to-uwp-prepare.md)」を確認してください。</span><span class="sxs-lookup"><span data-stu-id="8b963-110">Review this guide before you begin creating a package for your application: [Prepare to package an app (Desktop Bridge)](desktop-to-uwp-prepare.md).</span></span>

## <a name="create-a-package-manifest"></a><span data-ttu-id="8b963-111">パッケージ マニフェストを作成する</span><span class="sxs-lookup"><span data-stu-id="8b963-111">Create a package manifest</span></span>

<span data-ttu-id="8b963-112">ファイルを作成し、**appxmanifest.xml** という名前を付けて、以下の XML を追加します。</span><span class="sxs-lookup"><span data-stu-id="8b963-112">Create a file, name it **appxmanifest.xml**, and then add this XML to it.</span></span>

<span data-ttu-id="8b963-113">これは、パッケージに必要な要素や属性が含まれた基本テンプレートです。</span><span class="sxs-lookup"><span data-stu-id="8b963-113">It's a basic template that contains the elements and attributes that your package needs.</span></span> <span data-ttu-id="8b963-114">次のセクションで、これらに値を追加します。</span><span class="sxs-lookup"><span data-stu-id="8b963-114">We'll add values to these in the next section.</span></span>

```XML
<?xml version="1.0" encoding="utf-8"?>
<Package
    xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities">
  <Identity Name="" Version="" Publisher="" ProcessorArchitecture="" />
    <Properties>
       <DisplayName></DisplayName>
       <PublisherDisplayName></PublisherDisplayName>
             <Description></Description>
      <Logo></Logo>
    </Properties>
    <Resources>
      <Resource Language="" />
    </Resources>
      <Dependencies>
      <TargetDeviceFamily Name="Windows.Desktop" MinVersion="" MaxVersionTested="" />
      </Dependencies>
      <Capabilities>
        <rescap:Capability Name="runFullTrust"/>
      </Capabilities>
    <Applications>
      <Application Id="" Executable="" EntryPoint="Windows.FullTrustApplication">
        <uap:VisualElements DisplayName="" Description=""   Square150x150Logo=""
                   Square44x44Logo=""   BackgroundColor="" />
      </Application>
     </Applications>
  </Package>
```

## <a name="fill-in-the-package-level-elements-of-your-file"></a><span data-ttu-id="8b963-115">ファイルのパッケージ レベル要素に値を設定する</span><span class="sxs-lookup"><span data-stu-id="8b963-115">Fill in the package-level elements of your file</span></span>

<span data-ttu-id="8b963-116">このテンプレートに、パッケージを説明する情報を設定します。</span><span class="sxs-lookup"><span data-stu-id="8b963-116">Fill in this template with information that describes your package.</span></span>

### <a name="identity-information"></a><span data-ttu-id="8b963-117">Identity 情報</span><span class="sxs-lookup"><span data-stu-id="8b963-117">Identity information</span></span>

<span data-ttu-id="8b963-118">**Identity** 要素の例を以下に示します。各属性にはプレースホルダー テキストが指定されています。</span><span class="sxs-lookup"><span data-stu-id="8b963-118">Here's an example **Identity** element with placeholder text for the attributes.</span></span> <span data-ttu-id="8b963-119">``ProcessorArchitecture`` 属性は、``x64`` または ``x86`` に設定できます。</span><span class="sxs-lookup"><span data-stu-id="8b963-119">You can set the ``ProcessorArchitecture`` attribute to ``x64`` or ``x86``.</span></span>

```XML
<Identity Name="MyCompany.MySuite.MyApp"
          Version="1.0.0.0"
          Publisher="CN=MyCompany, O=MyCompany, L=MyCity, S=MyState, C=MyCountry"
                ProcessorArchitecture="x64">
```
> [!NOTE]
> <span data-ttu-id="8b963-120">Windows ストアでアプリ名を予約済みの場合は、Windows デベロッパー センターのダッシュ ボードを使用して、名前と発行元を取得できます。</span><span class="sxs-lookup"><span data-stu-id="8b963-120">If you've reserved your app name in the Windows store, you can obtain the Name and Publisher by using the Windows Dev Center dashboard.</span></span> <span data-ttu-id="8b963-121">アプリを他のシステムにサイドローディング展開する場合は、独自の名前を指定できます。ただし、選択する発行元名は、アプリへの署名に使用する証明書の名前と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b963-121">If you plan to sideload your app onto other systems, you can provide your own names for these as long as the publisher name that you choose matches the name on the certificate you use to sign your app.</span></span>

### <a name="properties"></a><span data-ttu-id="8b963-122">Properties</span><span class="sxs-lookup"><span data-stu-id="8b963-122">Properties</span></span>

<span data-ttu-id="8b963-123">[Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) 要素には、必須の子要素が 3 つあります。</span><span class="sxs-lookup"><span data-stu-id="8b963-123">The [Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) element has 3 required child elements.</span></span> <span data-ttu-id="8b963-124">次に示すのは、**Properties** ノードの例です。要素はプレースホルダー テキストが指定されています。</span><span class="sxs-lookup"><span data-stu-id="8b963-124">Here is an example **Properties** node with placeholder text for the elements.</span></span> <span data-ttu-id="8b963-125">**DisplayName** は、ストアにアップロードするアプリに対して、ストアで予約するアプリの名前です。</span><span class="sxs-lookup"><span data-stu-id="8b963-125">The **DisplayName** is the name of your app that you reserve in the store, for apps which are uploaded to the store.</span></span>

```XML
<Properties>
  <DisplayName>MyApp</DisplayName>
  <PublisherDisplayName>MyCompany</PublisherDisplayName>
  <Logo>images\icon.png</Logo>
</Properties>
```

### <a name="resources"></a><span data-ttu-id="8b963-126">Resources</span><span class="sxs-lookup"><span data-stu-id="8b963-126">Resources</span></span>

<span data-ttu-id="8b963-127">次に [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) ノードの例を示します。</span><span class="sxs-lookup"><span data-stu-id="8b963-127">Here is an example [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) node.</span></span>

```XML
<Resources>
  <Resource Language="en-us" />
</Resources>
```
### <a name="dependencies"></a><span data-ttu-id="8b963-128">依存関係</span><span class="sxs-lookup"><span data-stu-id="8b963-128">Dependencies</span></span>

<span data-ttu-id="8b963-129">デスクトップ ブリッジを使用してパッケージ化するデスクトップ アプリでは、常に ``Name`` 属性を ``Windows.Desktop`` に設定します。</span><span class="sxs-lookup"><span data-stu-id="8b963-129">For desktop apps that you package by using the desktop bridge, always set the ``Name`` attribute to ``Windows.Desktop``.</span></span>

```XML
<Dependencies>
<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14316.0" MaxVersionTested="10.0.15063.0" />
</Dependencies>
```

### <a name="capabilities"></a><span data-ttu-id="8b963-130">機能</span><span class="sxs-lookup"><span data-stu-id="8b963-130">Capabilities</span></span>
<span data-ttu-id="8b963-131">デスクトップ ブリッジを使用してパッケージ化するデスクトップ アプリでは、``runFullTrust`` 機能を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b963-131">For desktop apps that you package by using the desktop bridge, you'll have to add the ``runFullTrust`` capability.</span></span>

```XML
<Capabilities>
  <rescap:Capability Name="runFullTrust"/>
</Capabilities>
```
## <a name="fill-in-the-application-level-elements"></a><span data-ttu-id="8b963-132">アプリケーション レベル要素に値を設定する</span><span class="sxs-lookup"><span data-stu-id="8b963-132">Fill in the application-level elements</span></span>

<span data-ttu-id="8b963-133">このテンプレートに、アプリを説明する情報を指定します。</span><span class="sxs-lookup"><span data-stu-id="8b963-133">Fill in this template with information that describes your app.</span></span>

### <a name="application-element"></a><span data-ttu-id="8b963-134">Application 要素</span><span class="sxs-lookup"><span data-stu-id="8b963-134">Application element</span></span>

<span data-ttu-id="8b963-135">デスクトップ ブリッジを使用してパッケージ化するデスクトップ アプリでは、Application 要素の ``EntryPoint`` 属性は常に ``Windows.FullTrustApplication`` です。</span><span class="sxs-lookup"><span data-stu-id="8b963-135">For desktop apps that you package by using the desktop bridge, the ``EntryPoint`` attribute of the Application element is always ``Windows.FullTrustApplication``.</span></span>

```XML
<Applications>
  <Application Id="MyApp"     
        Executable="MyApp.exe" EntryPoint="Windows.FullTrustApplication">
   </Application>
</Applications>
```

### <a name="visual-elements"></a><span data-ttu-id="8b963-136">視覚要素</span><span class="sxs-lookup"><span data-stu-id="8b963-136">Visual elements</span></span>

<span data-ttu-id="8b963-137">次に [VisualElements](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) ノードの例を示します。</span><span class="sxs-lookup"><span data-stu-id="8b963-137">Here is an example [VisualElements](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) node.</span></span>

```XML
<uap:VisualElements
    BackgroundColor="#464646"
    DisplayName="My App"
    Square150x150Logo="images\icon.png"
    Square44x44Logo="images\small_icon.png"
    Description="A useful description" />
```
<a id="target-based-assets" />

## <a name="optional-add-target-based-unplated-assets"></a><span data-ttu-id="8b963-138">(省略可能) ターゲット ベースのプレートなしのアセットを追加する</span><span class="sxs-lookup"><span data-stu-id="8b963-138">(Optional) Add Target-based unplated assets</span></span>

<span data-ttu-id="8b963-139">ターゲット ベースのアセットは、Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したとき、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルで使用されます。</span><span class="sxs-lookup"><span data-stu-id="8b963-139">Target-based assets are for icons and tiles that appear on the Windows taskbar, task view, ALT+TAB, snap-assist, and the lower-right corner of Start tiles.</span></span> <span data-ttu-id="8b963-140">これらについて詳しくは、[こちら](https://docs.microsoft.com/windows/uwp/shell/tiles-and-notifications/app-assets#target-based-assets)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b963-140">You can read more about them [here](https://docs.microsoft.com/windows/uwp/shell/tiles-and-notifications/app-assets#target-based-assets).</span></span>

1. <span data-ttu-id="8b963-141">正しい 44 x 44 画像を取得して、画像保存用のフォルダー (Assets) にコピーします。</span><span class="sxs-lookup"><span data-stu-id="8b963-141">Obtain the correct 44x44 images and then copy them into the folder that contains your images (i.e., Assets).</span></span>

2. <span data-ttu-id="8b963-142">各 44 x 44 画像のコピーを同じフォルダーに作成し、ファイル名の末尾に **.targetsize-44_altform-unplated** を追加します。</span><span class="sxs-lookup"><span data-stu-id="8b963-142">For each 44x44 image, create a copy in the same folder and append **.targetsize-44_altform-unplated** to the file name.</span></span> <span data-ttu-id="8b963-143">これにより、同じ画像で異なる名前のアイコンが、2 つずつフォルダーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="8b963-143">You should have two copies of each icon, each named in a specific way.</span></span> <span data-ttu-id="8b963-144">たとえば、プロセスの完了後には、assets フォルダーに **MYAPP_44x44.png** と **MYAPP_44x44.targetsize-44_altform-unplated.png** のようなファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="8b963-144">For example, after completing the process, your assets folder might contain **MYAPP_44x44.png** and **MYAPP_44x44.targetsize-44_altform-unplated.png**.</span></span>

   > [!NOTE]
   > <span data-ttu-id="8b963-145">この例では、**MYAPP_44x44.png** という名前のアイコンは、Windows アプリ パッケージの ``Square44x44Logo`` ロゴ属性で参照するアイコンです。</span><span class="sxs-lookup"><span data-stu-id="8b963-145">In this example, the icon named **MYAPP_44x44.png** is the icon that you'll reference in the ``Square44x44Logo`` logo attribute of your Windows app package.</span></span>

3.  <span data-ttu-id="8b963-146">Windows アプリ パッケージで、透明にするすべてのアイコンについて ``BackgroundColor`` を設定します。</span><span class="sxs-lookup"><span data-stu-id="8b963-146">In the Windows app package, set the ``BackgroundColor`` for every icon you are making transparent.</span></span>

4. <span data-ttu-id="8b963-147">次のサブセクションに進み、新しいパッケージ リソース インデックス ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="8b963-147">Continue to the next subsection to generate a new Package Resource Index file.</span></span>

<a id="make-pri" />

### <a name="generate-a-package-resource-index-pri-file"></a><span data-ttu-id="8b963-148">パッケージ リソース インデックス (PRI) ファイルを生成する</span><span class="sxs-lookup"><span data-stu-id="8b963-148">Generate a Package Resource Index (PRI) file</span></span>

<span data-ttu-id="8b963-149">前のセクションで説明したようにターゲット ベースのアセットを作成する場合や、パッケージを作成した後、アプリのビジュアル アセットのいずれかを変更する場合は、新しい PRI ファイルを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b963-149">If you create target-based assets as described in the section above, or you modify any of the visual assets of your app after you've created the package, you'll have to generate a new PRI file.</span></span>

1.  <span data-ttu-id="8b963-150">**[開発者コマンド プロンプト for VS 2017]** を開きます。</span><span class="sxs-lookup"><span data-stu-id="8b963-150">Open a **Developer Command Prompt for VS 2017**.</span></span>

    ![開発者コマンド プロンプト](images/desktop-to-uwp/developer-command-prompt.png)

2.  <span data-ttu-id="8b963-152">パッケージのルート フォルダーにディレクトリを変更した後、``makepri createconfig /cf priconfig.xml /dq en-US`` コマンドを実行して priconfig.xml ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="8b963-152">Change directory to the package's root folder, and then create a priconfig.xml file by running the command ``makepri createconfig /cf priconfig.xml /dq en-US``.</span></span>

5.  <span data-ttu-id="8b963-153">コマンド ``makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml`` を使用して、resources.pri ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="8b963-153">Create the resources.pri file(s) by using the command ``makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml``.</span></span>

    <span data-ttu-id="8b963-154">たとえば、アプリのコマンドは、``makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml`` のようになります。</span><span class="sxs-lookup"><span data-stu-id="8b963-154">For example, the command for your app might look like this: ``makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml``.</span></span>

6.  <span data-ttu-id="8b963-155">次の手順の説明に従って Windows アプリ パッケージをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="8b963-155">Package your Windows app package by using the instructions in the next step.</span></span>

<a id="make-appx" />

## <a name="generate-a-windows-app-package"></a><span data-ttu-id="8b963-156">Windows アプリ パッケージを生成する</span><span class="sxs-lookup"><span data-stu-id="8b963-156">Generate a Windows app package</span></span>

<span data-ttu-id="8b963-157">**MakeAppx.exe** を使用して、プロジェクトの Windows アプリ パッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="8b963-157">Use **MakeAppx.exe** to generate a Windows app package for your project.</span></span> <span data-ttu-id="8b963-158">このツールは Windows 10 SDK に含まれています。Visual Studio をインストールしている場合は、お使いの Visual Studio バージョンの開発者コマンド プロンプトから簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="8b963-158">It's included with the Windows 10 SDK, and if you have Visual Studio installed, it can be easily accessed through the Developer Command Prompt for your Visual Studio version.</span></span>

<span data-ttu-id="8b963-159">「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b963-159">See [Create an app package with the MakeAppx.exe tool](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)</span></span>

## <a name="run-the-packaged-app"></a><span data-ttu-id="8b963-160">パッケージ アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="8b963-160">Run the packaged app</span></span>

<span data-ttu-id="8b963-161">証明書を取得して署名する作業を行わなくても、アプリをローカルで実行およびテストできます。</span><span class="sxs-lookup"><span data-stu-id="8b963-161">You can run your app to test it out locally without having to obtain a certificate and sign it.</span></span> <span data-ttu-id="8b963-162">次の PowerShell コマンドレットを実行するだけで済みます。</span><span class="sxs-lookup"><span data-stu-id="8b963-162">Just run this PowerShell cmdlet:</span></span>

```Add-AppxPackage –Register AppxManifest.xml```

<span data-ttu-id="8b963-163">アプリの .exe または .dll ファイルを更新するには、パッケージ内の既存のファイルを新しいファイルに置き換え、AppxManifest.xml のバージョン番号を繰り上げて、上記のコマンドをもう一度実行します。</span><span class="sxs-lookup"><span data-stu-id="8b963-163">To update your app's .exe or .dll files, replace the existing files in your package with the new ones, increase the version number in AppxManifest.xml, and then run the above command again.</span></span>

> [!NOTE]
> <span data-ttu-id="8b963-164">パッケージ アプリは、常に対話ユーザーとして実行されます。パッケージ アプリをインストールするドライブは、NTFS 形式にフォーマットされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b963-164">A packaged app always runs as an interactive user, and any drive that you install your packaged app on to must be formatted to NTFS format.</span></span>

## <a name="next-steps"></a><span data-ttu-id="8b963-165">次のステップ</span><span class="sxs-lookup"><span data-stu-id="8b963-165">Next steps</span></span>

**<span data-ttu-id="8b963-166">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="8b963-166">Find answers to your questions</span></span>**

<span data-ttu-id="8b963-167">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="8b963-167">Have questions?</span></span> <span data-ttu-id="8b963-168">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="8b963-168">Ask us on Stack Overflow.</span></span> <span data-ttu-id="8b963-169">Microsoft のチームでは、これらのチームがこれらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="8b963-169">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="8b963-170">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="8b963-170">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="8b963-171">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b963-171">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

**<span data-ttu-id="8b963-172">コードをステップ実行する/問題を見つけて修正する</span><span class="sxs-lookup"><span data-stu-id="8b963-172">Step through code / find and fix issues</span></span>**

<span data-ttu-id="8b963-173">[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b963-173">See [Run, debug, and test a packaged desktop app (Desktop Bridge)](desktop-to-uwp-debug.md)</span></span>

**<span data-ttu-id="8b963-174">アプリに署名して配布する</span><span class="sxs-lookup"><span data-stu-id="8b963-174">Sign your app and then distribute it</span></span>**

<span data-ttu-id="8b963-175">[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b963-175">See [Distribute a packaged desktop app (Desktop Bridge)](desktop-to-uwp-distribute.md)</span></span>
