---
author: ridomin
title: Visual Studio を使ったアプリ インストーラー ファイルの作成
description: Visual Studio を使い、.appinstaller ファイルを使って自動更新を有効にする方法について説明します。
ms.author: rmpablos
ms.date: 5/2/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング
ms.localizationpriority: medium
ms.openlocfilehash: 6158b804e1d4ece3c76099a3f8d33d5fa562078d
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4355737"
---
# <a name="create-an-app-installer-file-with-visual-studio"></a><span data-ttu-id="b4147-104">Visual Studio を使ったアプリ インストーラー ファイルの作成</span><span class="sxs-lookup"><span data-stu-id="b4147-104">Create an App Installer file with Visual Studio</span></span>

<span data-ttu-id="b4147-105">Windows 10 バージョン 1804 と Visual Studio 2017 Update 15.7 以降では、`.appinstaller` ファイルを使って自動更新を受け取るようにサイドローディングされるアプリを構成できます。</span><span class="sxs-lookup"><span data-stu-id="b4147-105">Starting with Windows 10, Version 1804, and Visual Studio 2017, Update 15.7, sideloaded apps can be configured to receive automatic updates using an `.appinstaller` file.</span></span> <span data-ttu-id="b4147-106">Visual Studio では、このような更新の有効がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="b4147-106">Visual Studio supports enabling these updates.</span></span>

## <a name="app-installer-file-location"></a><span data-ttu-id="b4147-107">アプリ インストーラー ファイルの場所</span><span class="sxs-lookup"><span data-stu-id="b4147-107">App Installer file location</span></span>
<span data-ttu-id="b4147-108">`.appinstaller`ファイルは、HTTP エンドポイントや UNC 共有フォルダーなどの共有の場所にホストでき、インストールするアプリ パッケージを見つけるためのパスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b4147-108">The `.appinstaller` file can be hosted in a shared location like a HTTP endpoint or a UNC shared folder, and includes the path to find the app packages to be installed.</span></span> <span data-ttu-id="b4147-109">ユーザーは、共有の場所からアプリをインストールし、新しい更新プログラムの定期的なチェックを有効にします。</span><span class="sxs-lookup"><span data-stu-id="b4147-109">Users install the app from the shared location and enable periodic checks for new updates.</span></span> 


### <a name="configure-the-project-to-target-the-correct-windows-version"></a><span data-ttu-id="b4147-110">適切な Windows バージョンをターゲットとするプロジェクトの構成</span><span class="sxs-lookup"><span data-stu-id="b4147-110">Configure the project to target the correct Windows version</span></span>

<span data-ttu-id="b4147-111">`TargetPlatformMinVersion` プロパティは、プロジェクトを作成するときに構成するか、後でプロジェクトのプロパティから変更できます。</span><span class="sxs-lookup"><span data-stu-id="b4147-111">You can either configure the `TargetPlatformMinVersion` property when you create the project, or change it later from the project properties.</span></span> 

>[!IMPORTANT]
> <span data-ttu-id="b4147-112">アプリ インストーラー ファイルは、`TargetPlatformMinVersion` が Windows 10 バージョン 1804 以上の場合にのみ生成されます。</span><span class="sxs-lookup"><span data-stu-id="b4147-112">The app installer file is only generated when the `TargetPlatformMinVersion` is Windows 10, Version 1804 or greater.</span></span>


### <a name="create-packages"></a><span data-ttu-id="b4147-113">パッケージの作成</span><span class="sxs-lookup"><span data-stu-id="b4147-113">Create Packages</span></span>

<span data-ttu-id="b4147-114">サイドローディングを通じてアプリを配布するには、アプリ パッケージ (.appx/.msix) またはアプリ バンドル (.appxbundle/.msixbundle) を作成し、共有の場所に公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4147-114">To distribute an app via sideloading, you must create an app package (.appx/.msix) or app bundle (.appxbundle/.msixbundle) and publish it in a shared location.</span></span>

<span data-ttu-id="b4147-115">これを行うには、Visual Studio で**アプリ パッケージの作成**ウィザードを使って手順に従います。</span><span class="sxs-lookup"><span data-stu-id="b4147-115">To do that, use the **Create App Packages** wizard in Visual Studio with the following steps.</span></span>

1. <span data-ttu-id="b4147-116">プロジェクトを右クリックし、**[Microsoft Store]**  ->  **[アプリ パッケージの作成]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="b4147-116">Right-click the project and choose **Store** -> **Create App Packages**.</span></span>  

![コンテキスト メニューと [アプリ パッケージの作成] へのナビゲーション](images/packaging-screen2.jpg)   

<span data-ttu-id="b4147-118">**アプリ パッケージの作成**ウィザードが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b4147-118">The **Create App Packages** wizard appears.</span></span>

2. <span data-ttu-id="b4147-119">**[I want to create packages for sideloading]** (サイドローディング用のパッケージを作成する)</span><span class="sxs-lookup"><span data-stu-id="b4147-119">Select **I want to create packages for sideloading.**</span></span> <span data-ttu-id="b4147-120">と **[自動更新を有効にする]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="b4147-120">and **Enable automatic updates**</span></span>  

![[パッケージの作成] ダイアログ ウィンドウ](images/select-sideloading.png)  

<span data-ttu-id="b4147-122">**[自動更新を有効にする]** は、プロジェクトの `TargetPlatformMinVersion` が正しいバージョンの Windows 10 に設定されている場合のみオンになります。</span><span class="sxs-lookup"><span data-stu-id="b4147-122">**Enable automatic updates** is enabled only if the project's `TargetPlatformMinVersion` is set to the correct version of Windows 10.</span></span>

3. <span data-ttu-id="b4147-123">**[パッケージの選択と構成]** ダイアログ ボックスでは、サポートされているアーキテクチャ構成を選択できます。</span><span class="sxs-lookup"><span data-stu-id="b4147-123">The **Select and Configure Packages** dialog allows you to select the supported architecture configurations.</span></span> <span data-ttu-id="b4147-124">バンドルを選択した場合、単一のインストーラーが生成されますが、バンドルではなくアーキテクチャごとに 1 つのパッケージが必要な場合、アーキテクチャごとにも 1 つのインストーラー ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="b4147-124">If you select a bundle it will generate a single installer, however if you don't want a bundle and prefer one package per architecture you will also get one installer file per architecture.</span></span>  <span data-ttu-id="b4147-125">どのアーキテクチャを選べばよいかわからない場合や、各種デバイスにより使用されるアーキテクチャについて詳しく調べる場合は、「[アプリ パッケージのアーキテクチャ](device-architecture.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4147-125">If you're unsure which architecture(s) to choose, or want to learn more about which architectures are used by various devices, see [App package architectures](device-architecture.md).</span></span>

4. <span data-ttu-id="b4147-126">バージョンの番号付けやパッケージの出力場所など、他の詳細情報を構成します。</span><span class="sxs-lookup"><span data-stu-id="b4147-126">Configure any additional details, such as version numbering or the package output location.</span></span>

![[アプリ パッケージの作成] ウィンドウのパッケージ構成画面](images/packaging-screen5.jpg)  

5. <span data-ttu-id="b4147-128">手順 2 で **[自動更新を有効にする]** をオンにした場合、**[更新設定の構成]** ダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b4147-128">If you checked **Enable automatic updates** in Step 2, the **Configure Update Settings** dialog will appear.</span></span> <span data-ttu-id="b4147-129">ここでは、**[インストールの URL]** と更新チェックの頻度を指定できます。</span><span class="sxs-lookup"><span data-stu-id="b4147-129">Here, you can specify the **Installation URL** and the frequency of update checks.</span></span>

![[更新設定の構成] ウィンドウの公開場所の構成画面](images/sideloading-screen.png)  

6. <span data-ttu-id="b4147-131">アプリが正常にパッケージ化されると、ダイアログ ボックスにアプリ パッケージを含む出力フォルダーの場所が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b4147-131">When your app has been successfully packaged, a dialog will display the location of the output folder containing your app package.</span></span> <span data-ttu-id="b4147-132">出力フォルダーには、アプリの宣伝に使用できる HTML ページなど、アプリのサイドローディングに必要なすべてのファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b4147-132">The output folder includes all the files needed to sideload the app, including an HTML page that can be used to promote your app.</span></span>

### <a name="publish-packages"></a><span data-ttu-id="b4147-133">パッケージの公開</span><span class="sxs-lookup"><span data-stu-id="b4147-133">Publish packages</span></span>

<span data-ttu-id="b4147-134">アプリケーションを利用可能にするには、生成されたファイルを指定した場所に公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4147-134">To make the application available the generated files must be published to the location specified:</span></span>

#### <a name="publish-to-shared-folders-unc"></a><span data-ttu-id="b4147-135">共有フォルダー (UNC) への公開</span><span class="sxs-lookup"><span data-stu-id="b4147-135">Publish to shared folders (UNC)</span></span>

<span data-ttu-id="b4147-136">汎用名前付け規則 (UNC) 共有フォルダーを使ってパッケージを公開する場合、アプリ パッケージの出力フォルダーとインストールの URL (詳しくは手順 6 を参照) を同じパスに構成します。</span><span class="sxs-lookup"><span data-stu-id="b4147-136">If you want to publish your packages over Universal Naming Convention (UNC) shared folders, configure the app package output folder and the Installation URL (see Step 6 for details) to the same path.</span></span> <span data-ttu-id="b4147-137">ウィザードにより、適切な場所にファイルが生成され、ユーザーは同じパスからアプリと今後の更新プログラムの両方を取得します。</span><span class="sxs-lookup"><span data-stu-id="b4147-137">The wizard will generate the files in the correct location, and users will get both the app and future updates from the same path.</span></span>

#### <a name="publish-to-a-web-location-http"></a><span data-ttu-id="b4147-138">Web 上の場所 (HTTP) への公開</span><span class="sxs-lookup"><span data-stu-id="b4147-138">Publish to a web location (HTTP)</span></span>

<span data-ttu-id="b4147-139">Web 上の場所に公開するには、Web サーバーにコンテンツを公開するためのアクセス権が必要です。最終的な URL がウィザードで定義されたインストールの URL と一致することを確認してください (詳しくは手順 6 を参照)。</span><span class="sxs-lookup"><span data-stu-id="b4147-139">Publishing to a web location requires access to publish content to the web server, making sure the final URL matches the Installation URL defined in the wizard (see Step 6 for details).</span></span> <span data-ttu-id="b4147-140">通常、ファイル転送プロトコル (FTP) または SSH ファイル転送プロトコル (SFTP) を使ってファイルをアップロードしますが、Web プロバイダーによっては MSDeploy、SSH、Blob ストレージなどの他の公開方法が用意されています。</span><span class="sxs-lookup"><span data-stu-id="b4147-140">Typically, File Transfer Protocol (FTP) or SSH File Transfer Protocol (SFTP) are used to upload the files, but there are other publishing methods like MSDeploy, SSH, or Blob storage, depending on your web provider.</span></span>

<span data-ttu-id="b4147-141">Web サーバーを構成するには、使うファイルの種類に使用される MIME タイプを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4147-141">To configure the web server you must verify the MIME types used for the file types in use.</span></span> <span data-ttu-id="b4147-142">この例では、インターネット インフォメーション サービス (IIS) の `web.config` です。</span><span class="sxs-lookup"><span data-stu-id="b4147-142">This example is of the `web.config` for Internet Information Services (IIS):</span></span>

```xml
<configuration>
  <system.webServer>
    <staticContent>
      <mimeMap fileExtension=".appx" mimeType="application/vns.ms-appx" />
      <mimeMap fileExtension=".appxbundle" mimeType="application/vns.ms-appx" />
      <mimeMap fileExtension=".appinstaller" mimeType="application/xml" />
    </staticContent>  
  </system.webServer>  
</configuration>
```




















