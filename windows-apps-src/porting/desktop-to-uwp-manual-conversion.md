---
author: normesta
Description: "Windows 10 用の Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) を手動でパッケージ化する方法を示します。"
Search.Product: eADQiWindows 10XVcnh
title: "アプリを手動でパッケージ化する (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: e8c2a803-9803-47c5-b117-73c4af52c5b6
ms.openlocfilehash: e8a09b6e362662b9bb207117d8a3fcc905da6ef4
ms.sourcegitcommit: ae93435e1f9c010a054f55ed7d6bd2f268223957
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/10/2017
---
# <a name="package-an-app-manually-desktop-bridge"></a><span data-ttu-id="61cb0-104">アプリを手動でパッケージ化する (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="61cb0-104">Package an app manually (Desktop Bridge)</span></span>

<span data-ttu-id="61cb0-105">このトピックでは、Visual Studio、Desktop App Converter (DAC) などのツールを使用せずにアプリをパッケージ化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-105">This topic shows you how to package your app without using tools such as Visual Studio or the Desktop App Converter (DAC).</span></span>

<div style="float: left; padding: 10px">
    ![手動のフロー](images/desktop-to-uwp/manual-flow.png)
</div>

<span data-ttu-id="61cb0-107">アプリを手動でパッケージ化するには、パッケージ マニフェスト ファイルを作成してから、Windows アプリ パッケージを生成するコマンド ライン ツールを実行します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-107">To manually package your app, create a package manifest file, and then run a command line tool to generate a Windows app package.</span></span>

<span data-ttu-id="61cb0-108">xcopy コマンドを使用してアプリをインストールする場合や、アプリのインストーラーがシステムに加える変更を熟知したうえで、プロセスをきめ細かく制御する必要がある場合は、手動によるパッケージ化を検討してください。</span><span class="sxs-lookup"><span data-stu-id="61cb0-108">Consider manual packaging if you install your app by using the xcopy command, or you're familiar with the changes that your app's installer makes to the system and want more granular control over the process.</span></span>

<span data-ttu-id="61cb0-109">インストーラーによってどのような変更がシステムに加えられるのかわからない場合や、自動化ツールを使用してパッケージ マニフェストを生成する場合は、[こちら](desktop-to-uwp-root.md#convert)のオプションのいずれかを検討してください。</span><span class="sxs-lookup"><span data-stu-id="61cb0-109">If you're uncertain about what changes your installer makes to the system, or if you'd rather use automated tools to generate your package manifest, consider any of [these](desktop-to-uwp-root.md#convert) options.</span></span>

## <a name="first-consider-how-youll-distribute-your-app"></a><span data-ttu-id="61cb0-110">まず、アプリの配布方法を検討する</span><span class="sxs-lookup"><span data-stu-id="61cb0-110">First, consider how you'll distribute your app</span></span>
<span data-ttu-id="61cb0-111">アプリを [Windows ストア](https://www.microsoft.com/store/apps)に公開する予定であれば、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)への記入から開始します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-111">If you plan to publish your app to the [Windows Store](https://www.microsoft.com/store/apps), start by filling out [this form](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge).</span></span> <span data-ttu-id="61cb0-112">Microsoft から、オンボード プロセスを開始するための連絡があります。</span><span class="sxs-lookup"><span data-stu-id="61cb0-112">Microsoft will contact you to start the onboarding process.</span></span> <span data-ttu-id="61cb0-113">このプロセスでは、ストア内の名前を予約し、アプリをパッケージ化するための情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-113">As part of this process, you'll reserve a name in the store, and obtain information that you'll need to package your app.</span></span>

## <a name="create-a-package-manifest"></a><span data-ttu-id="61cb0-114">パッケージ マニフェストを作成する</span><span class="sxs-lookup"><span data-stu-id="61cb0-114">Create a package manifest</span></span>

<span data-ttu-id="61cb0-115">ファイルを作成し、**appxmanifest.xml** という名前を付けて、以下の XML を追加します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-115">Create a file, name it **appxmanifest.xml**, and then add this XML to it.</span></span>

<span data-ttu-id="61cb0-116">これは、パッケージに必要な要素や属性が含まれた基本テンプレートです。</span><span class="sxs-lookup"><span data-stu-id="61cb0-116">It's a basic template that contains the elements and attributes that your package needs.</span></span> <span data-ttu-id="61cb0-117">次のセクションで、これらに値を追加します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-117">We'll add values to these in the next section.</span></span>

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

## <a name="fill-in-the-package-level-elements-of-your-file"></a><span data-ttu-id="61cb0-118">ファイルのパッケージ レベル要素に値を設定する</span><span class="sxs-lookup"><span data-stu-id="61cb0-118">Fill in the package-level elements of your file</span></span>

<span data-ttu-id="61cb0-119">このテンプレートに、パッケージを説明する情報を設定します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-119">Fill in this template with information that describes your package.</span></span>

### <a name="identity-information"></a><span data-ttu-id="61cb0-120">Identity 情報</span><span class="sxs-lookup"><span data-stu-id="61cb0-120">Identity information</span></span>

<span data-ttu-id="61cb0-121">**Identity** 要素の例を以下に示します。各属性にはプレースホルダー テキストが指定されています。</span><span class="sxs-lookup"><span data-stu-id="61cb0-121">Here's an example **Identity** element with placeholder text for the attributes.</span></span> <span data-ttu-id="61cb0-122">``ProcessorArchitecture`` 属性は、``x64`` または ``x86`` に設定できます。</span><span class="sxs-lookup"><span data-stu-id="61cb0-122">You can set the ``ProcessorArchitecture`` attribute to ``x64`` or ``x86``.</span></span>

```XML
<Identity Name="MyCompany.MySuite.MyApp"
          Version="1.0.0.0"
          Publisher="CN=MyCompany, O=MyCompany, L=MyCity, S=MyState, C=MyCountry"
                ProcessorArchitecture="x64">
```
> [!NOTE]
> <span data-ttu-id="61cb0-123">Windows ストアでアプリ名を予約済みの場合は、Windows デベロッパー センターのダッシュ ボードを使用して、名前と発行元を取得できます。</span><span class="sxs-lookup"><span data-stu-id="61cb0-123">If you've reserved your app name in the Windows store, you can obtain the Name and Publisher by using the Windows Dev Center dashboard.</span></span> <span data-ttu-id="61cb0-124">アプリを他のシステムにサイドローディング展開する場合は、独自の名前を指定できます。ただし、選択する発行元名は、アプリへの署名に使用する証明書の名前と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="61cb0-124">If you plan to sideload your app onto other systems, you can provide your own names for these as long as the publisher name that you choose matches the name on the certificate you use to sign your app.</span></span>

### <a name="properties"></a><span data-ttu-id="61cb0-125">Properties</span><span class="sxs-lookup"><span data-stu-id="61cb0-125">Properties</span></span>

<span data-ttu-id="61cb0-126">[Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) 要素には、必須の子要素が 3 つあります。</span><span class="sxs-lookup"><span data-stu-id="61cb0-126">The [Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) element has 3 required child elements.</span></span> <span data-ttu-id="61cb0-127">次に示すのは、**Properties** ノードの例です。要素はプレースホルダー テキストが指定されています。</span><span class="sxs-lookup"><span data-stu-id="61cb0-127">Here is an example **Properties** node with placeholder text for the elements.</span></span> <span data-ttu-id="61cb0-128">**DisplayName** は、ストアにアップロードするアプリに対して、ストアで予約するアプリの名前です。</span><span class="sxs-lookup"><span data-stu-id="61cb0-128">The **DisplayName** is the name of your app that you reserve in the store, for apps which are uploaded to the store.</span></span>

```XML
<Properties>
  <DisplayName>MyApp</DisplayName>
  <PublisherDisplayName>MyCompany</PublisherDisplayName>
  <Logo>images\icon.png</Logo>
</Properties>
```

### <a name="resources"></a><span data-ttu-id="61cb0-129">Resources</span><span class="sxs-lookup"><span data-stu-id="61cb0-129">Resources</span></span>

<span data-ttu-id="61cb0-130">次に [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) ノードの例を示します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-130">Here is an example [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) node.</span></span>

```XML
<Resources>
  <Resource Language="en-us" />
</Resources>
```
### <a name="dependencies"></a><span data-ttu-id="61cb0-131">Dependencies</span><span class="sxs-lookup"><span data-stu-id="61cb0-131">Dependencies</span></span>

<span data-ttu-id="61cb0-132">デスクトップ ブリッジ アプリでは、``Name`` 属性は常に ``Windows.Desktop`` に設定します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-132">For desktop bridge apps, always set the ``Name`` attribute to ``Windows.Desktop``.</span></span>

```XML
<Dependencies>
<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14316.0" MaxVersionTested="10.0.15063.0" />
</Dependencies>
```

### <a name="capabilities"></a><span data-ttu-id="61cb0-133">Capabilities</span><span class="sxs-lookup"><span data-stu-id="61cb0-133">Capabilities</span></span>
<span data-ttu-id="61cb0-134">デスクトップ ブリッジ アプリには、``runFullTrust`` 機能を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="61cb0-134">For desktop bridge apps, you'll have to add the ``runFullTrust`` capability.</span></span>

```XML
<Capabilities>
  <rescap:Capability Name="runFullTrust"/>
</Capabilities>
```
## <a name="fill-in-the-application-level-elements"></a><span data-ttu-id="61cb0-135">アプリケーション レベル要素に値を設定する</span><span class="sxs-lookup"><span data-stu-id="61cb0-135">Fill in the application-level elements</span></span>

<span data-ttu-id="61cb0-136">このテンプレートに、アプリを説明する情報を指定します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-136">Fill in this template with information that describes your app.</span></span>

### <a name="application-element"></a><span data-ttu-id="61cb0-137">Application 要素</span><span class="sxs-lookup"><span data-stu-id="61cb0-137">Application element</span></span>

<span data-ttu-id="61cb0-138">デスクトップ ブリッジ アプリの場合、Application 要素の ``EntryPoint`` 属性は常に ``Windows.FullTrustApplication`` です。</span><span class="sxs-lookup"><span data-stu-id="61cb0-138">For desktop bridge apps, the ``EntryPoint`` attribute of the Application element is always ``Windows.FullTrustApplication``.</span></span>

```XML
<Applications>
  <Application Id="MyApp"     
        Executable="MyApp.exe" EntryPoint="Windows.FullTrustApplication">
   </Application>
</Applications>
```

### <a name="visual-elements"></a><span data-ttu-id="61cb0-139">VisualElements</span><span class="sxs-lookup"><span data-stu-id="61cb0-139">Visual elements</span></span>

<span data-ttu-id="61cb0-140">次に [VisualElements](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) ノードの例を示します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-140">Here is an example [VisualElements](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) node.</span></span>

```XML
<uap:VisualElements
    BackgroundColor="#464646"
    DisplayName="My App"
    Square150x150Logo="images\icon.png"
    Square44x44Logo="images\small_icon.png"
    Description="A useful description" />
```

## <a name="optional-add-target-based-unplated-assets"></a><span data-ttu-id="61cb0-141">(省略可能) ターゲット ベースのプレートなしのアセットを追加する</span><span class="sxs-lookup"><span data-stu-id="61cb0-141">(Optional) Add Target-based unplated assets</span></span>

<span data-ttu-id="61cb0-142">ターゲット ベースのアセットは、Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したとき、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルで使用されます。</span><span class="sxs-lookup"><span data-stu-id="61cb0-142">Target-based assets are for icons and tiles that appear on the Windows taskbar, task view, ALT+TAB, snap-assist, and the lower-right corner of Start tiles.</span></span> <span data-ttu-id="61cb0-143">これらについて詳しくは、[こちら](https://docs.microsoft.com/windows/uwp/controls-and-patterns/tiles-and-notifications-app-assets#target-based-assets)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="61cb0-143">You can read more about them [here](https://docs.microsoft.com/windows/uwp/controls-and-patterns/tiles-and-notifications-app-assets#target-based-assets).</span></span>

1. <span data-ttu-id="61cb0-144">正しい 44 x 44 画像を取得して、画像保存用のフォルダー (Assets) にコピーします。</span><span class="sxs-lookup"><span data-stu-id="61cb0-144">Obtain the correct 44x44 images and then copy them into the folder that contains your images (i.e., Assets).</span></span>

2. <span data-ttu-id="61cb0-145">各 44 x 44 画像のコピーを同じフォルダーに作成し、ファイル名の末尾に **.targetsize-44_altform-unplated** を追加します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-145">For each 44x44 image, create a copy in the same folder and append **.targetsize-44_altform-unplated** to the file name.</span></span> <span data-ttu-id="61cb0-146">これにより、同じ画像で異なる名前のアイコンが、2 つずつフォルダーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="61cb0-146">You should have two copies of each icon, each named in a specific way.</span></span> <span data-ttu-id="61cb0-147">たとえば、プロセスの完了後には、assets フォルダーに **MYAPP_44x44.png** と **MYAPP_44x44.targetsize-44_altform-unplated.png** のようなファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="61cb0-147">For example, after completing the process, your assets folder might contain **MYAPP_44x44.png** and **MYAPP_44x44.targetsize-44_altform-unplated.png**.</span></span>

   > [!NOTE]
   > <span data-ttu-id="61cb0-148">この例では、**MYAPP_44x44.png** という名前のアイコンは、Windows アプリ パッケージの ``Square44x44Logo`` ロゴ属性で参照するアイコンです。</span><span class="sxs-lookup"><span data-stu-id="61cb0-148">In this example, the icon named **MYAPP_44x44.png** is the icon that you'll reference in the ``Square44x44Logo`` logo attribute of your Windows app package.</span></span>

3.  <span data-ttu-id="61cb0-149">Windows アプリ パッケージで、透明にするすべてのアイコンについて ``BackgroundColor`` を設定します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-149">In the Windows app package, set the ``BackgroundColor`` for every icon you are making transparent.</span></span>

4.  <span data-ttu-id="61cb0-150">CMD を開き、パッケージのルート フォルダーにディレクトリを変更した後、コマンド ``makepri createconfig /cf priconfig.xml /dq en-US`` を実行して priconfig.xml ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-150">Open CMD, change directory to the package's root folder, and then create a priconfig.xml file by running the command ``makepri createconfig /cf priconfig.xml /dq en-US``.</span></span>

5.  <span data-ttu-id="61cb0-151">コマンド ``makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml`` を使用して、resources.pri ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-151">Create the resources.pri file(s) by using the command ``makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml``.</span></span>

    <span data-ttu-id="61cb0-152">たとえば、アプリのコマンドは、``makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml`` のようになります。</span><span class="sxs-lookup"><span data-stu-id="61cb0-152">For example, the command for your app might look like this: ``makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml``.</span></span>

6.  <span data-ttu-id="61cb0-153">次の手順の説明に従って Windows アプリ パッケージをパッケージ化し、結果を確認します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-153">Package your Windows app package by using the instructions in the next step to see the results.</span></span>

<span id="make-appx" />
## <a name="generate-a-windows-app-package"></a><span data-ttu-id="61cb0-154">Windows アプリ パッケージを生成する</span><span class="sxs-lookup"><span data-stu-id="61cb0-154">Generate a Windows app package</span></span>

<span data-ttu-id="61cb0-155">**MakeAppx.exe** を使用して、プロジェクトの Windows アプリ パッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-155">Use **MakeAppx.exe** to generate a Windows app package for your project.</span></span> <span data-ttu-id="61cb0-156">このツールは Windows 10 SDK に含まれています。Visual Studio をインストールしている場合は、お使いの Visual Studio バージョンの開発者コマンド プロンプトから簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="61cb0-156">It's included with the Windows 10 SDK, and if you have Visual Studio installed, it can be easily accessed through the Developer Command Prompt for your Visual Studio version.</span></span>

<span data-ttu-id="61cb0-157">「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="61cb0-157">See [Create an app package with the MakeAppx.exe tool](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)</span></span>

## <a name="run-the-packaged-app"></a><span data-ttu-id="61cb0-158">パッケージ アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="61cb0-158">Run the packaged app</span></span>

<span data-ttu-id="61cb0-159">証明書を取得して署名する作業を行わなくても、アプリをローカルで実行およびテストできます。</span><span class="sxs-lookup"><span data-stu-id="61cb0-159">You can run your app to test it out locally without having to obtain a certificate and sign it.</span></span> <span data-ttu-id="61cb0-160">次の PowerShell コマンドレットを実行するだけで済みます。</span><span class="sxs-lookup"><span data-stu-id="61cb0-160">Just run this PowerShell cmdlet:</span></span>

```Add-AppxPackage –Register AppxManifest.xml```

<span data-ttu-id="61cb0-161">アプリの .exe または .dll ファイルを更新するには、パッケージ内の既存のファイルを新しいファイルに置き換え、AppxManifest.xml のバージョン番号を繰り上げて、上記のコマンドをもう一度実行します。</span><span class="sxs-lookup"><span data-stu-id="61cb0-161">To update your app's .exe or .dll files, replace the existing files in your package with the new ones, increase the version number in AppxManifest.xml, and then run the above command again.</span></span>

> [!NOTE]
> <span data-ttu-id="61cb0-162">パッケージ アプリは、常に対話ユーザーとして実行されます。パッケージ アプリをインストールするドライブは、NTFS 形式にフォーマットされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="61cb0-162">A packaged app always runs as an interactive user, and any drive that you install your packaged app on to must be formatted to NTFS format.</span></span>

## <a name="next-steps"></a><span data-ttu-id="61cb0-163">次のステップ</span><span class="sxs-lookup"><span data-stu-id="61cb0-163">Next steps</span></span>

**<span data-ttu-id="61cb0-164">コードをステップ実行する/問題を見つけて修正する</span><span class="sxs-lookup"><span data-stu-id="61cb0-164">Step through code / find and fix issues</span></span>**

<span data-ttu-id="61cb0-165">[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="61cb0-165">See [Run, debug, and test a packaged desktop app (Desktop Bridge)](desktop-to-uwp-debug.md)</span></span>

**<span data-ttu-id="61cb0-166">アプリに署名して配布する</span><span class="sxs-lookup"><span data-stu-id="61cb0-166">Sign your app and then distribute it</span></span>**

<span data-ttu-id="61cb0-167">[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="61cb0-167">See [Distribute a packaged desktop app (Desktop Bridge)](desktop-to-uwp-distribute.md)</span></span>

**<span data-ttu-id="61cb0-168">特定の質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="61cb0-168">Find answers to specific questions</span></span>**

<span data-ttu-id="61cb0-169">マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="61cb0-169">Our team monitors these [StackOverflow tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

**<span data-ttu-id="61cb0-170">この記事に関するフィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="61cb0-170">Give feedback about this article</span></span>**

<span data-ttu-id="61cb0-171">下のコメント セクションをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="61cb0-171">Use the comments section below.</span></span>
