---
title: IIS サーバーからの UWP アプリのインストール
description: このチュートリアルは、IIS サーバーを設定することを確認、web アプリできますアプリのパッケージをホストと呼び出すアプリのインストーラーを効果的に使用する方法を示します。
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10、uwp アプリのインストーラー、AppInstaller、サイドローディングを行う、関連の設定、省略可能なパッケージ、IIS サーバー
ms.localizationpriority: medium
ms.openlocfilehash: 6a4512229a29a7adc59d6b61edd596eaeb56a5a8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623567"
---
# <a name="install-a-uwp-app-from-an-iis-server"></a><span data-ttu-id="ffa9d-104">IIS サーバーからの UWP アプリのインストール</span><span class="sxs-lookup"><span data-stu-id="ffa9d-104">Install a UWP app from an IIS server</span></span>

<span data-ttu-id="ffa9d-105">このチュートリアルは、IIS サーバーを設定することを確認、web アプリできますアプリのパッケージをホストと呼び出すアプリのインストーラーを効果的に使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-105">This tutorial demonstrates how to set up an IIS server, verify that your web app can host app packages, and invoke and use App Installer effectively.</span></span>

<span data-ttu-id="ffa9d-106">アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-106">The App Installer app allows developers and IT Pros to distribute Windows 10 apps by hosting them on their own Content Delivery Network (CDN).</span></span> <span data-ttu-id="ffa9d-107">これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-107">This is useful for enterprises that don't want or need to publish their apps to the Microsoft Store, but still want to take advantage of the Windows 10 packaging and deployment platform.</span></span> 

## <a name="setup"></a><span data-ttu-id="ffa9d-108">セットアップ</span><span class="sxs-lookup"><span data-stu-id="ffa9d-108">Setup</span></span>

<span data-ttu-id="ffa9d-109">このチュートリアルで正常に移動に、以下の手順が必要されます。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-109">To successfully go through with this tutorial, you will need the following:</span></span>

1. <span data-ttu-id="ffa9d-110">Visual Studio 2017</span><span class="sxs-lookup"><span data-stu-id="ffa9d-110">Visual Studio 2017</span></span>  
2. <span data-ttu-id="ffa9d-111">Web 開発ツールと IIS</span><span class="sxs-lookup"><span data-stu-id="ffa9d-111">Web development tools and IIS</span></span> 
3. <span data-ttu-id="ffa9d-112">UWP アプリ パッケージ - 配布するアプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="ffa9d-112">UWP app package - The app package that you will distribute</span></span>

<span data-ttu-id="ffa9d-113">省略可能: [スタート プロジェクト](https://github.com/AppInstaller/MySampleWebApp)GitHub でします。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-113">Optional: [Starter Project](https://github.com/AppInstaller/MySampleWebApp) on GitHub.</span></span> <span data-ttu-id="ffa9d-114">これは、機能は、アプリ パッケージを使用すると、動作はありませんが、この機能を使用する方法を説明する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-114">This is helpful if you don't have app packages to work with, but would still like to learn how to use this feature.</span></span>

## <a name="step-1---install-iis-and-aspnet"></a><span data-ttu-id="ffa9d-115">手順 1 - IIS と ASP.NET のインストール</span><span class="sxs-lookup"><span data-stu-id="ffa9d-115">Step 1 - Install IIS and ASP.NET</span></span> 

<span data-ttu-id="ffa9d-116">[インターネット インフォメーション サービス](https://www.iis.net/)は [スタート] メニューを使用してインストールできる Windows の機能です。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-116">[Internet Information Services](https://www.iis.net/) is a Windows feature that can be installed via the Start menu.</span></span> <span data-ttu-id="ffa9d-117">**[スタート] メニュー**検索**オンまたはオフにする Windows 機能**します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-117">In **Start menu** search for **Turn Windows features on or off**.</span></span>

<span data-ttu-id="ffa9d-118">検索して選択**インターネット インフォメーション サービス**IIS をインストールします。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-118">Find and select **Internet Information Services** to install IIS.</span></span>

> [!NOTE]
> <span data-ttu-id="ffa9d-119">インターネット インフォメーション サービスのすべてのチェック ボックスをオンにする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-119">You don't need to select all the check boxes under Internet Information Services.</span></span> <span data-ttu-id="ffa9d-120">チェックするときに選択したもののみ**インターネット インフォメーション サービス**で十分です。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-120">Only the ones selected when you check **Internet Information Services** are sufficient.</span></span>

<span data-ttu-id="ffa9d-121">ASP.NET 4.5 以上をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-121">You will also need to install ASP.NET 4.5 or greater.</span></span> <span data-ttu-id="ffa9d-122">これをインストールするには、検索**インターネット インフォメーション サービス Web サイト]-> [サービス]、[アプリケーション開発機能**します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-122">To install it, locate **Internet Information Services -> World Wide Web Services -> Application Development Features**.</span></span> <span data-ttu-id="ffa9d-123">ASP.NET 4.5 以上である ASP.NET のバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-123">Select a version of ASP.NET that is greater than or equal to ASP.NET 4.5.</span></span>

![ASP.NET をインストールします。](images/install-asp.png)

## <a name="step-2---install-visual-studio-2017-and-web-development-tools"></a><span data-ttu-id="ffa9d-125">手順 2 - Visual Studio 2017 をインストールし、Web 開発ツール</span><span class="sxs-lookup"><span data-stu-id="ffa9d-125">Step 2 - Install Visual Studio 2017 and Web Development tools</span></span> 

<span data-ttu-id="ffa9d-126">[Visual Studio 2017 インストール](https://docs.microsoft.com/visualstudio/install/install-visual-studio)を既にインストールしていない場合。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-126">[Install Visual Studio 2017](https://docs.microsoft.com/visualstudio/install/install-visual-studio) if you have not already installed it.</span></span> <span data-ttu-id="ffa9d-127">Visual Studio 2017 が既にあるを場合は、次のワークロードがインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-127">If you already have Visual Studio 2017, ensure that the following workloads are installed.</span></span> <span data-ttu-id="ffa9d-128">ワークロードがインストールに存在しない場合は、([スタート] メニューから検出)、Visual Studio インストーラーを使用して作業を進めるにします。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-128">If the workloads are not present on your installation, follow along using the Visual Studio Installer (found from the Start menu).</span></span>  

<span data-ttu-id="ffa9d-129">インストール中に、次のように選択します。 **ASP.NET および Web 開発**と興味のあるその他の任意のワークロード。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-129">During installation, select **ASP.NET and Web development** and any other workloads that you are interested in.</span></span> 

<span data-ttu-id="ffa9d-130">インストールが完了すると Visual Studio を起動し、新しいプロジェクトを作成 (**ファイル** -> **新しいプロジェクト**)。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-130">Once installation is complete, launch Visual Studio and create a new project (**File** -> **New Project**).</span></span>

## <a name="step-3---build-a-web-app"></a><span data-ttu-id="ffa9d-131">手順 3 - Web アプリの構築</span><span class="sxs-lookup"><span data-stu-id="ffa9d-131">Step 3 - Build a Web App</span></span>

<span data-ttu-id="ffa9d-132">として Visual Studio 2017 を起動**管理者**され、新しい作成**Visual C# Web アプリケーション**でプロジェクトを**空**プロジェクト テンプレート。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-132">Launch Visual Studio 2017 as **Administrator** and create a new **Visual C# Web Application** project with an **empty** project template.</span></span> 

![新しいプロジェクト](images/sample-web-app.png)

## <a name="step-4---configure-iis-with-our-web-app"></a><span data-ttu-id="ffa9d-134">手順 4 - Web アプリでの IIS の構成</span><span class="sxs-lookup"><span data-stu-id="ffa9d-134">Step 4 - Configure IIS with our Web App</span></span> 

<span data-ttu-id="ffa9d-135">ソリューション エクスプ ローラーで、ルート プロジェクトを右クリックし、選択**プロパティ**します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-135">From the Solution Explorer, right click on the root project and select **Properties**.</span></span>

<span data-ttu-id="ffa9d-136">Web アプリのプロパティで、選択、 **Web**タブ。**サーバー**セクションで、選択**ローカル IIS**をクリックして、ドロップダウンから**仮想ディレクトリの作成**です。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-136">In the web app properties, select the **Web** tab. In the **Servers** section, choose **Local IIS** from the drop down menu and click **Create Virtual Directory**.</span></span> 

![[web] タブ](images/web-tab.png)

## <a name="step-5---add-an-app-package-to-a-web-application"></a><span data-ttu-id="ffa9d-138">手順 5 - web アプリケーションにアプリ パッケージを追加</span><span class="sxs-lookup"><span data-stu-id="ffa9d-138">Step 5 - Add an app package to a web application</span></span> 

<span data-ttu-id="ffa9d-139">Web アプリケーションに配布する予定のアプリ パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-139">Add the app package that you are going to distribute into the web application.</span></span> <span data-ttu-id="ffa9d-140">アプリ パッケージの一部であるを使用して[スターター プロジェクト パッケージ](https://github.com/AppInstaller/MySampleWebApp/tree/master/MySampleWebApp/packages)github アプリ パッケージを使用していない場合。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-140">You can use the app package that is part of the provided [starter project packages](https://github.com/AppInstaller/MySampleWebApp/tree/master/MySampleWebApp/packages) on GitHub if you don't have an app package available.</span></span> <span data-ttu-id="ffa9d-141">パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-141">The certificate (MySampleApp.cer) that the package was signed with is also with the sample on GitHub.</span></span> <span data-ttu-id="ffa9d-142">(手順 9)、アプリをインストールする前に、デバイスにインストールされている証明書が必要です。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-142">You must have the certificate installed to your device prior to installing the app (Step 9).</span></span>

<span data-ttu-id="ffa9d-143">スタート プロジェクトの web アプリケーションで新しいフォルダーがという名前の web アプリケーションに追加された`packages`配布するアプリ パッケージを格納しています。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-143">In the starter project web application, a new folder was added to the web app called `packages` that contains the app packages to be distributed.</span></span> <span data-ttu-id="ffa9d-144">Visual Studio で、フォルダーを作成するソリューション エクスプ ローラー、選択のルートを右クリックして**追加** -> **新しいフォルダー**名前を付けます`packages`します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-144">To create the folder in Visual Studio, right click on the root of the Solution Explorer, select **Add** -> **New Folder** and name it `packages`.</span></span> <span data-ttu-id="ffa9d-145">アプリ パッケージをフォルダーに追加する右クリック、`packages`フォルダーと選択**追加** -> **既存の項目.** し、アプリ パッケージの場所を参照します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-145">To add app packages to the folder, right click on the `packages` folder and select **Add** -> **Existing Item...** and browse to the app package location.</span></span> 

![パッケージを追加します。](images/add-package.png)

## <a name="step-6---create-a-web-page"></a><span data-ttu-id="ffa9d-147">手順 6 - Web ページの作成</span><span class="sxs-lookup"><span data-stu-id="ffa9d-147">Step 6 - Create a Web Page</span></span>

<span data-ttu-id="ffa9d-148">このサンプル web アプリでは、単純な HTML を使用します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-148">This sample web app uses simple HTML.</span></span> <span data-ttu-id="ffa9d-149">ニーズに合わせて必要に応じて、web アプリをビルドしてかまいません。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-149">You are free to build your web app as required per your needs.</span></span> 

<span data-ttu-id="ffa9d-150">ソリューション エクスプ ローラーのルート プロジェクトを右クリックして**追加** -> **新しい項目の**、し、新しい追加**HTML ページ**から、 **Web**セクション。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-150">Right click on the root project of the Solution explorer, select **Add** -> **New Item**, and add a new **HTML Page** from the **Web** section.</span></span>

<span data-ttu-id="ffa9d-151">HTML ページが作成されると、ソリューション エクスプ ローラーで HTML ページを右クリックし、選択**スタート ページとして設定**します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-151">Once the HTML page is created, right click on the HTML page in the Solution Explorer and select **Set As Start Page**.</span></span>  

<span data-ttu-id="ffa9d-152">コード エディター ウィンドウで開く、HTML ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-152">Double-click the HTML file to open it in the code editor window.</span></span> <span data-ttu-id="ffa9d-153">このチュートリアルでは、Windows 10 アプリをインストールするには、正常にアプリ インストーラー アプリを起動する web ページで、必要な内の要素のみが使用されます。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-153">In this tutorial, only the elements in the required in the web page to invoke the App Installer app successfully to install a Windows 10 app will be used.</span></span> 

<span data-ttu-id="ffa9d-154">Web ページでは、次の HTML コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-154">Include the following HTML code in your web page.</span></span> <span data-ttu-id="ffa9d-155">キーが正常に呼び出すアプリのインストーラーは、アプリのインストーラーは、OS を登録するカスタムのスキームを使用する:`ms-appinstaller:?source=`します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-155">The key to successfully invoking App Installer is to use the custom scheme that App Installer registers with the OS: `ms-appinstaller:?source=`.</span></span> <span data-ttu-id="ffa9d-156">詳細については、次のコード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-156">See the code example below for more details.</span></span>

> [!NOTE]
> <span data-ttu-id="ffa9d-157">カスタムのスキームに一致するプロジェクトの Url、VS ソリューションの [web] タブで後に指定された URL パスを確認します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-157">Ensure that the URL path specified after the custom scheme matches the Project Url in the web tab of your VS solution.</span></span>
 
```HTML
<html>
<head>
    <meta charset="utf-8" />
    <title> Install Page </title>
</head>
<body>
    <a href="ms-appinstaller:?source=http://localhost/SampleWebApp/packages/MySampleApp.appxbundle"> Install My Sample App</a>
</body>
</html>
```

## <a name="step-7---configure-the-web-app-for-app-package-mime-types"></a><span data-ttu-id="ffa9d-158">手順 7 - アプリ パッケージの MIME の種類の web アプリの構成</span><span class="sxs-lookup"><span data-stu-id="ffa9d-158">Step 7 - Configure the web app for app package MIME types</span></span>

<span data-ttu-id="ffa9d-159">開く、 **Web.config**ソリューション エクスプ ローラーからファイルを開き内で次の行を追加、`<configuration>`要素。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-159">Open the **Web.config** file from the solution explorer and add the following lines within the `<configuration>` element.</span></span> 

```xml
<system.webServer>
    <!--This is to allow the web server to serve resources with the appropriate file extension-->
    <staticContent>
      <mimeMap fileExtension=".appx" mimeType="application/appx" />
      <mimeMap fileExtension=".msix" mimeType="application/msix" />
      <mimeMap fileExtension=".appxbundle" mimeType="application/appxbundle" />
      <mimeMap fileExtension=".msixbundle" mimeType="application/msixbundle" />
      <mimeMap fileExtension=".appinstaller" mimeType="application/appinstaller" />
    </staticContent>
</system.webServer>
```

## <a name="step-8---add-loopback-exemption-for-app-installer"></a><span data-ttu-id="ffa9d-160">手順 8 - アプリのインストーラーのループバックの免除を追加</span><span class="sxs-lookup"><span data-stu-id="ffa9d-160">Step 8 - Add loopback exemption for App Installer</span></span>

<span data-ttu-id="ffa9d-161">ネットワークの分離によりアプリのインストーラーのような UWP アプリはなど、IP ループバック アドレスの使用に制限 http://localhost/します。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-161">Due to network isolation, UWP apps like App Installer are restricted to use IP loopback addresses like http://localhost/.</span></span> <span data-ttu-id="ffa9d-162">ローカル IIS サーバーを使用する場合、アプリのインストーラーはループバックの除外リストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-162">When using local IIS Server, App Installer must be added to the loopback exempt list.</span></span> 

<span data-ttu-id="ffa9d-163">これを行うには、開く**コマンド プロンプト**として、**管理者**」と入力します: '' コマンド ライン CheckNetIsolation.exe LoopbackExempt-a-n="microsoft.desktopappinstaller_8wekyb3d8bbwe"</span><span class="sxs-lookup"><span data-stu-id="ffa9d-163">To do this, open **Command Prompt** as an **Administrator** and enter the following: \`\`\`Command Line CheckNetIsolation.exe LoopbackExempt -a -n="microsoft.desktopappinstaller_8wekyb3d8bbwe"</span></span>
```

To verify that the app is added to the exempt list, use the following command to display the apps in the loopback exempt list: 
```Command Line
CheckNetIsolation.exe LoopbackExempt -s
```

<span data-ttu-id="ffa9d-164">検索する必要があります`microsoft.desktopappinstaller_8wekyb3d8bbwe`一覧にします。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-164">You should find `microsoft.desktopappinstaller_8wekyb3d8bbwe` in the list.</span></span>

<span data-ttu-id="ffa9d-165">アプリのインストーラーを使用してアプリのインストールのローカルな検証が完了すると、この手順で追加したループバックの免除を削除できます。</span><span class="sxs-lookup"><span data-stu-id="ffa9d-165">Once the local validation of app installation via App Installer is complete, you can remove the loopback exemption that you added in this step by:</span></span>

<span data-ttu-id="ffa9d-166">'' コマンド ライン CheckNetIsolation.exe LoopbackExempt-d-n="microsoft.desktopappinstaller_8wekyb3d8bbwe"</span><span class="sxs-lookup"><span data-stu-id="ffa9d-166">\`\`\`Command Line CheckNetIsolation.exe LoopbackExempt -d -n="microsoft.desktopappinstaller_8wekyb3d8bbwe"</span></span>
```

## Step 9 - Run the Web App 

Build and run the web application by clicking on the run button on the VS Ribbon as shown in the image below:

![run](images/run.png)

A web page will open in your browser:

![web page](images/web-page.png)

Click on the link in the web page to launch the App Installer app and install your Windows 10 app package.


## Troubleshooting issues

### Not sufficient privilege 

If running the web app in Visual Studio displays an error such as "You do not have sufficient privilege to access IIS web sites on your machine", you will need to run Visual Studio as an administrator. Close the current instance of Visual Studio and reopen it as an admin.

### Set start page 

If running the web app causes the browser to load with an HTTP 403.14 - Forbidden error, it's because the web app doesn't have a defined start page. Refer to Step 6 in this tutorial to learn how to define a start page.
