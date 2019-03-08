---
Description: Windows 10 用の Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) を手動でパッケージ化する方法を示します。
Search.Product: eADQiWindows 10XVcnh
title: アプリケーションを手動でパッケージ化 (デスクトップ ブリッジ)
ms.date: 05/18/2018
ms.topic: article
keywords: windows 10, uwp
ms.assetid: e8c2a803-9803-47c5-b117-73c4af52c5b6
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 1dd159b7cd04a7641bf3f89605e054a00a0bad58
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651177"
---
# <a name="package-a-desktop-application-manually"></a><span data-ttu-id="38e2b-104">デスクトップ アプリケーションを手動でパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-104">Package a desktop application manually</span></span>

<span data-ttu-id="38e2b-105">このトピックでは、Visual Studio や Desktop App Converter (DAC) などのツールを使用せず、アプリケーションをパッケージ化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-105">This topic shows you how to package your application without using tools such as Visual Studio or the Desktop App Converter (DAC).</span></span>

<span data-ttu-id="38e2b-106">アプリを手動でパッケージ化するには、パッケージ マニフェスト ファイルを作成してから、Windows アプリ パッケージを生成するコマンド ライン ツールを実行します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-106">To manually package your app, create a package manifest file, and then run a command line tool to generate a Windows app package.</span></span>

<span data-ttu-id="38e2b-107">プロセスをより詳細な制御と xcopy コマンドを使用して、アプリケーションをインストールすることも、アプリのインストーラーが、システムに変更を使い慣れている場合は、手動のパッケージ化を検討してください。</span><span class="sxs-lookup"><span data-stu-id="38e2b-107">Consider manual packaging if you install your application by using the xcopy command, or you're familiar with the changes that your app's installer makes to the system and want more granular control over the process.</span></span>

<span data-ttu-id="38e2b-108">インストーラーによってどのような変更がシステムに加えられるのかわからない場合や、自動化ツールを使用してパッケージ マニフェストを生成する場合は、[こちら](desktop-to-uwp-root.md#convert)のオプションのいずれかを検討してください。</span><span class="sxs-lookup"><span data-stu-id="38e2b-108">If you're uncertain about what changes your installer makes to the system, or if you'd rather use automated tools to generate your package manifest, consider any of [these](desktop-to-uwp-root.md#convert) options.</span></span>

>[!IMPORTANT]
><span data-ttu-id="38e2b-109">(それ以外の場合は、デスクトップ ブリッジと呼ばれます) デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能は Windows 10 バージョン 1607 で導入され、Windows 10 Anniversary Update (10.0; を対象とするプロジェクトでのみ使用できます。ビルド 14393) または Visual Studio の今後のリリース。</span><span class="sxs-lookup"><span data-stu-id="38e2b-109">The ability to create a Windows app package for your desktop application (otherwise known as the Desktop Bridge) was introduced in Windows 10, version 1607, and it can only be used in projects that target Windows 10 Anniversary Update (10.0; Build 14393) or a later release in Visual Studio.</span></span>

## <a name="first-prepare-your-application"></a><span data-ttu-id="38e2b-110">まず、アプリケーションを準備します</span><span class="sxs-lookup"><span data-stu-id="38e2b-110">First, prepare your application</span></span>

<span data-ttu-id="38e2b-111">アプリケーションのパッケージの作成を開始する前に、このガイドを確認します。[デスクトップ アプリケーションをパッケージ化するための準備](desktop-to-uwp-prepare.md)します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-111">Review this guide before you begin creating a package for your application: [Prepare to package a desktop application](desktop-to-uwp-prepare.md).</span></span>

## <a name="create-a-package-manifest"></a><span data-ttu-id="38e2b-112">パッケージ マニフェストを作成する</span><span class="sxs-lookup"><span data-stu-id="38e2b-112">Create a package manifest</span></span>

<span data-ttu-id="38e2b-113">ファイルを作成し、**appxmanifest.xml** という名前を付けて、以下の XML を追加します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-113">Create a file, name it **appxmanifest.xml**, and then add this XML to it.</span></span>

<span data-ttu-id="38e2b-114">これは、パッケージに必要な要素や属性が含まれた基本テンプレートです。</span><span class="sxs-lookup"><span data-stu-id="38e2b-114">It's a basic template that contains the elements and attributes that your package needs.</span></span> <span data-ttu-id="38e2b-115">次のセクションで、これらに値を追加します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-115">We'll add values to these in the next section.</span></span>

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

## <a name="fill-in-the-package-level-elements-of-your-file"></a><span data-ttu-id="38e2b-116">ファイルのパッケージ レベル要素に値を設定する</span><span class="sxs-lookup"><span data-stu-id="38e2b-116">Fill in the package-level elements of your file</span></span>

<span data-ttu-id="38e2b-117">このテンプレートに、パッケージを説明する情報を設定します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-117">Fill in this template with information that describes your package.</span></span>

### <a name="identity-information"></a><span data-ttu-id="38e2b-118">Identity 情報</span><span class="sxs-lookup"><span data-stu-id="38e2b-118">Identity information</span></span>

<span data-ttu-id="38e2b-119">**Identity** 要素の例を以下に示します。各属性にはプレースホルダー テキストが指定されています。</span><span class="sxs-lookup"><span data-stu-id="38e2b-119">Here's an example **Identity** element with placeholder text for the attributes.</span></span> <span data-ttu-id="38e2b-120">``ProcessorArchitecture`` 属性は、``x64`` または ``x86`` に設定できます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-120">You can set the ``ProcessorArchitecture`` attribute to ``x64`` or ``x86``.</span></span>

```XML
<Identity Name="MyCompany.MySuite.MyApp"
          Version="1.0.0.0"
          Publisher="CN=MyCompany, O=MyCompany, L=MyCity, S=MyState, C=MyCountry"
                ProcessorArchitecture="x64">
```
> [!NOTE]
> <span data-ttu-id="38e2b-121">パブリッシャーと名前を取得を使用して Microsoft Store でアプリケーション名に予約した場合[パートナー センター](https://partner.microsoft.com/dashboard)します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-121">If you've reserved your application name in the Microsoft Store, you can obtain the Name and Publisher by using [Partner Center](https://partner.microsoft.com/dashboard).</span></span> <span data-ttu-id="38e2b-122">他のシステム上にアプリをサイドロードにする場合、アプリに署名する証明書の名前と一致するを選択したパブリッシャー名を使用する限り、これらの独自の名前を指定できます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-122">If you plan to sideload your application onto other systems, you can provide your own names for these as long as the publisher name that you choose matches the name on the certificate you use to sign your app.</span></span>

### <a name="properties"></a><span data-ttu-id="38e2b-123">プロパティ</span><span class="sxs-lookup"><span data-stu-id="38e2b-123">Properties</span></span>

<span data-ttu-id="38e2b-124">[Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) 要素には、必須の子要素が 3 つあります。</span><span class="sxs-lookup"><span data-stu-id="38e2b-124">The [Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) element has 3 required child elements.</span></span> <span data-ttu-id="38e2b-125">次に示すのは、**Properties** ノードの例です。要素はプレースホルダー テキストが指定されています。</span><span class="sxs-lookup"><span data-stu-id="38e2b-125">Here is an example **Properties** node with placeholder text for the elements.</span></span> <span data-ttu-id="38e2b-126">**DisplayName**アプリ ストアにアップロードされるストア内に予約するアプリケーションの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-126">The **DisplayName** is the name of your application that you reserve in the Store, for apps which are uploaded to the Store.</span></span>

```XML
<Properties>
  <DisplayName>MyApp</DisplayName>
  <PublisherDisplayName>MyCompany</PublisherDisplayName>
  <Logo>images\icon.png</Logo>
</Properties>
```

### <a name="resources"></a><span data-ttu-id="38e2b-127">参考資料</span><span class="sxs-lookup"><span data-stu-id="38e2b-127">Resources</span></span>

<span data-ttu-id="38e2b-128">次に [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) ノードの例を示します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-128">Here is an example [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) node.</span></span>

```XML
<Resources>
  <Resource Language="en-us" />
</Resources>
```
### <a name="dependencies"></a><span data-ttu-id="38e2b-129">依存関係</span><span class="sxs-lookup"><span data-stu-id="38e2b-129">Dependencies</span></span>

<span data-ttu-id="38e2b-130">デスクトップのアプリのパッケージを作成するで、常に設定、``Name``属性を``Windows.Desktop``します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-130">For desktop apps that you create a package for, always set the ``Name`` attribute to ``Windows.Desktop``.</span></span>

```XML
<Dependencies>
<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14316.0" MaxVersionTested="10.0.15063.0" />
</Dependencies>
```

### <a name="capabilities"></a><span data-ttu-id="38e2b-131">機能</span><span class="sxs-lookup"><span data-stu-id="38e2b-131">Capabilities</span></span>
<span data-ttu-id="38e2b-132">パッケージを作成する、追加する必要がありますのデスクトップ アプリ、``runFullTrust``機能します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-132">For desktop apps that you create a package for, you'll have to add the ``runFullTrust`` capability.</span></span>

```XML
<Capabilities>
  <rescap:Capability Name="runFullTrust"/>
</Capabilities>
```
## <a name="fill-in-the-application-level-elements"></a><span data-ttu-id="38e2b-133">アプリケーション レベル要素に値を設定する</span><span class="sxs-lookup"><span data-stu-id="38e2b-133">Fill in the application-level elements</span></span>

<span data-ttu-id="38e2b-134">このテンプレートに、アプリを説明する情報を指定します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-134">Fill in this template with information that describes your app.</span></span>

### <a name="application-element"></a><span data-ttu-id="38e2b-135">Application 要素</span><span class="sxs-lookup"><span data-stu-id="38e2b-135">Application element</span></span>

<span data-ttu-id="38e2b-136">パッケージを作成するデスクトップ アプリ、 ``EntryPoint`` Application 要素の属性は常に``Windows.FullTrustApplication``します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-136">For desktop apps that you create a package for, the ``EntryPoint`` attribute of the Application element is always ``Windows.FullTrustApplication``.</span></span>

```XML
<Applications>
  <Application Id="MyApp"     
        Executable="MyApp.exe" EntryPoint="Windows.FullTrustApplication">
   </Application>
</Applications>
```

### <a name="visual-elements"></a><span data-ttu-id="38e2b-137">視覚要素</span><span class="sxs-lookup"><span data-stu-id="38e2b-137">Visual elements</span></span>

<span data-ttu-id="38e2b-138">次に [VisualElements](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) ノードの例を示します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-138">Here is an example [VisualElements](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) node.</span></span>

```XML
<uap:VisualElements
    BackgroundColor="#464646"
    DisplayName="My App"
    Square150x150Logo="images\icon.png"
    Square44x44Logo="images\small_icon.png"
    Description="A useful description" />
```
<a id="target-based-assets" />

## <a name="optional-add-target-based-unplated-assets"></a><span data-ttu-id="38e2b-139">(省略可能) ターゲット ベースのプレートなしのアセットを追加する</span><span class="sxs-lookup"><span data-stu-id="38e2b-139">(Optional) Add Target-based unplated assets</span></span>

<span data-ttu-id="38e2b-140">ターゲット ベースのアセットは、Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したとき、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルで使用されます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-140">Target-based assets are for icons and tiles that appear on the Windows taskbar, task view, ALT+TAB, snap-assist, and the lower-right corner of Start tiles.</span></span> <span data-ttu-id="38e2b-141">これらについて詳しくは、[こちら](https://docs.microsoft.com/windows/uwp/design/style/app-icons-and-logos#unplated-assets)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="38e2b-141">You can read more about them [here](https://docs.microsoft.com/windows/uwp/design/style/app-icons-and-logos#unplated-assets).</span></span>

1. <span data-ttu-id="38e2b-142">正しい 44 x 44 画像を取得して、画像保存用のフォルダー (Assets) にコピーします。</span><span class="sxs-lookup"><span data-stu-id="38e2b-142">Obtain the correct 44x44 images and then copy them into the folder that contains your images (i.e., Assets).</span></span>

2. <span data-ttu-id="38e2b-143">各 44 x 44 画像のコピーを同じフォルダーに作成し、ファイル名の末尾に **.targetsize-44_altform-unplated** を追加します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-143">For each 44x44 image, create a copy in the same folder and append **.targetsize-44_altform-unplated** to the file name.</span></span> <span data-ttu-id="38e2b-144">これにより、同じ画像で異なる名前のアイコンが、2 つずつフォルダーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-144">You should have two copies of each icon, each named in a specific way.</span></span> <span data-ttu-id="38e2b-145">たとえば、プロセスの完了後には、assets フォルダーに **MYAPP_44x44.png** と **MYAPP_44x44.targetsize-44_altform-unplated.png** のようなファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="38e2b-145">For example, after completing the process, your assets folder might contain **MYAPP_44x44.png** and **MYAPP_44x44.targetsize-44_altform-unplated.png**.</span></span>

   > [!NOTE]
   > <span data-ttu-id="38e2b-146">この例では、**MYAPP_44x44.png** という名前のアイコンは、Windows アプリ パッケージの ``Square44x44Logo`` ロゴ属性で参照するアイコンです。</span><span class="sxs-lookup"><span data-stu-id="38e2b-146">In this example, the icon named **MYAPP_44x44.png** is the icon that you'll reference in the ``Square44x44Logo`` logo attribute of your Windows app package.</span></span>

3.  <span data-ttu-id="38e2b-147">Windows アプリ パッケージで、透明にするすべてのアイコンについて ``BackgroundColor`` を設定します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-147">In the Windows app package, set the ``BackgroundColor`` for every icon you are making transparent.</span></span>

4. <span data-ttu-id="38e2b-148">次のサブセクションに進み、新しいパッケージ リソース インデックス ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-148">Continue to the next subsection to generate a new Package Resource Index file.</span></span>

<a id="make-pri" />

### <a name="generate-a-package-resource-index-pri-file"></a><span data-ttu-id="38e2b-149">パッケージ リソース インデックス (PRI) ファイルを生成する</span><span class="sxs-lookup"><span data-stu-id="38e2b-149">Generate a Package Resource Index (PRI) file</span></span>

<span data-ttu-id="38e2b-150">ターゲット ベースの資産を作成するように、上記のセクションで説明されている場合は、パッケージを作成した後、アプリケーションのビジュアル資産のいずれかを変更する、新しい PRI ファイルを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="38e2b-150">If you create target-based assets as described in the section above, or you modify any of the visual assets of your application after you've created the package, you'll have to generate a new PRI file.</span></span>

1.  <span data-ttu-id="38e2b-151">**[開発者コマンド プロンプト for VS 2017]** を開きます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-151">Open a **Developer Command Prompt for VS 2017**.</span></span>

    ![開発者コマンド プロンプト](images/desktop-to-uwp/developer-command-prompt.png)

2.  <span data-ttu-id="38e2b-153">パッケージのルート フォルダーにディレクトリを変更した後、``makepri createconfig /cf priconfig.xml /dq en-US`` コマンドを実行して priconfig.xml ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-153">Change directory to the package's root folder, and then create a priconfig.xml file by running the command ``makepri createconfig /cf priconfig.xml /dq en-US``.</span></span>

5.  <span data-ttu-id="38e2b-154">コマンド ``makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml`` を使用して、resources.pri ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-154">Create the resources.pri file(s) by using the command ``makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml``.</span></span>

    <span data-ttu-id="38e2b-155">たとえば、アプリケーションのコマンドが、これのようになります。:``makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml``します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-155">For example, the command for your application might look like this: ``makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml``.</span></span>

6.  <span data-ttu-id="38e2b-156">次の手順の説明に従って Windows アプリ パッケージをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-156">Package your Windows app package by using the instructions in the next step.</span></span>

<a id="make-appx" />

## <a name="generate-a-windows-app-package"></a><span data-ttu-id="38e2b-157">Windows アプリ パッケージを生成する</span><span class="sxs-lookup"><span data-stu-id="38e2b-157">Generate a Windows app package</span></span>

<span data-ttu-id="38e2b-158">**MakeAppx.exe** を使用して、プロジェクトの Windows アプリ パッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-158">Use **MakeAppx.exe** to generate a Windows app package for your project.</span></span> <span data-ttu-id="38e2b-159">このツールは Windows 10 SDK に含まれています。Visual Studio をインストールしている場合は、お使いの Visual Studio バージョンの開発者コマンド プロンプトから簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-159">It's included with the Windows 10 SDK, and if you have Visual Studio installed, it can be easily accessed through the Developer Command Prompt for your Visual Studio version.</span></span>

<span data-ttu-id="38e2b-160">「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="38e2b-160">See [Create an app package with the MakeAppx.exe tool](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)</span></span>

## <a name="run-the-packaged-app"></a><span data-ttu-id="38e2b-161">パッケージ アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="38e2b-161">Run the packaged app</span></span>

<span data-ttu-id="38e2b-162">証明書を取得し、署名することがなくローカルでテストするアプリケーションを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-162">You can run your application to test it out locally without having to obtain a certificate and sign it.</span></span> <span data-ttu-id="38e2b-163">次の PowerShell コマンドレットを実行するだけで済みます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-163">Just run this PowerShell cmdlet:</span></span>

```Add-AppxPackage –Register AppxManifest.xml```

<span data-ttu-id="38e2b-164">アプリの .exe または .dll ファイルを更新するには、パッケージ内の既存のファイルを新しいファイルに置き換え、AppxManifest.xml のバージョン番号を繰り上げて、上記のコマンドをもう一度実行します。</span><span class="sxs-lookup"><span data-stu-id="38e2b-164">To update your app's .exe or .dll files, replace the existing files in your package with the new ones, increase the version number in AppxManifest.xml, and then run the above command again.</span></span>

> [!NOTE]
> <span data-ttu-id="38e2b-165">パッケージ化されたアプリケーションでは、常には、対話型のユーザーとして実行されにパッケージ化されたアプリケーションをインストールする任意のドライブを NTFS 形式に書式設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="38e2b-165">A packaged application always runs as an interactive user, and any drive that you install your packaged application on to must be formatted to NTFS format.</span></span>

## <a name="next-steps"></a><span data-ttu-id="38e2b-166">次のステップ</span><span class="sxs-lookup"><span data-stu-id="38e2b-166">Next steps</span></span>

<span data-ttu-id="38e2b-167">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="38e2b-167">**Find answers to your questions**</span></span>

<span data-ttu-id="38e2b-168">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="38e2b-168">Have questions?</span></span> <span data-ttu-id="38e2b-169">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="38e2b-169">Ask us on Stack Overflow.</span></span> <span data-ttu-id="38e2b-170">Microsoft のチームでは、これらのチームがこれらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="38e2b-170">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="38e2b-171">**ご意見や機能を提案します。**</span><span class="sxs-lookup"><span data-stu-id="38e2b-171">**Give feedback or make feature suggestions**</span></span>

<span data-ttu-id="38e2b-172">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="38e2b-172">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

<span data-ttu-id="38e2b-173">**コードをステップ実行/検索、および問題を修正**</span><span class="sxs-lookup"><span data-stu-id="38e2b-173">**Step through code / find and fix issues**</span></span>

<span data-ttu-id="38e2b-174">参照してください[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)</span><span class="sxs-lookup"><span data-stu-id="38e2b-174">See [Run, debug, and test a packaged desktop application](desktop-to-uwp-debug.md)</span></span>

<span data-ttu-id="38e2b-175">**アプリケーションに署名し、配布**</span><span class="sxs-lookup"><span data-stu-id="38e2b-175">**Sign your application and then distribute it**</span></span>

<span data-ttu-id="38e2b-176">参照してください[パッケージ化されたデスクトップ アプリケーションの配布](desktop-to-uwp-distribute.md)</span><span class="sxs-lookup"><span data-stu-id="38e2b-176">See [Distribute a packaged desktop application](desktop-to-uwp-distribute.md)</span></span>
