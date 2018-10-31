---
author: laurenhughes
title: IIS サーバーから UWP アプリをインストールする
description: このチュートリアルでは、IIS サーバーをセットアップとことを確認、web アプリをアプリ パッケージをホストを呼び出すアプリ インストーラーを効果的に使用する方法を示します。
ms.author: cdon
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング、関連セット, オプション パッケージ、IIS サーバー
ms.localizationpriority: medium
ms.openlocfilehash: 2898a3450f75379492bae1ade5c85581cc8e5a4e
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5821395"
---
# <a name="install-a-uwp-app-from-an-iis-server"></a><span data-ttu-id="56291-104">IIS サーバーから UWP アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="56291-104">Install a UWP app from an IIS server</span></span>

<span data-ttu-id="56291-105">このチュートリアルでは、IIS サーバーをセットアップとことを確認、web アプリをアプリ パッケージをホストを呼び出すアプリ インストーラーを効果的に使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="56291-105">This tutorial demonstrates how to set up an IIS server, verify that your web app can host app packages, and invoke and use App Installer effectively.</span></span>

<span data-ttu-id="56291-106">アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。</span><span class="sxs-lookup"><span data-stu-id="56291-106">The App Installer app allows developers and IT Pros to distribute Windows 10 apps by hosting them on their own Content Delivery Network (CDN).</span></span> <span data-ttu-id="56291-107">これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="56291-107">This is useful for enterprises that don't want or need to publish their apps to the Microsoft Store, but still want to take advantage of the Windows 10 packaging and deployment platform.</span></span> 

## <a name="setup"></a><span data-ttu-id="56291-108">セットアップ</span><span class="sxs-lookup"><span data-stu-id="56291-108">Setup</span></span>

<span data-ttu-id="56291-109">正常に実行するこのチュートリアルで、以下が必要は。</span><span class="sxs-lookup"><span data-stu-id="56291-109">To successfully go through with this tutorial, you will need the following:</span></span>

1. <span data-ttu-id="56291-110">Visual Studio 2017</span><span class="sxs-lookup"><span data-stu-id="56291-110">Visual Studio 2017</span></span>  
2. <span data-ttu-id="56291-111">Web 開発ツールと IIS</span><span class="sxs-lookup"><span data-stu-id="56291-111">Web development tools and IIS</span></span> 
3. <span data-ttu-id="56291-112">UWP アプリ パッケージ - 配布するアプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="56291-112">UWP app package - The app package that you will distribute</span></span>

<span data-ttu-id="56291-113">オプション: GitHub での[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp)</span><span class="sxs-lookup"><span data-stu-id="56291-113">Optional: [Starter Project](https://github.com/AppInstaller/MySampleWebApp) on GitHub.</span></span> <span data-ttu-id="56291-114">これは、アプリ パッケージと併用する必要はありませんをこの機能を使用する方法について説明したい場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="56291-114">This is helpful if you don't have app packages to work with, but would still like to learn how to use this feature.</span></span>

## <a name="step-1---install-iis-and-aspnet"></a><span data-ttu-id="56291-115">手順 1 - IIS と ASP.NET をインストールします。</span><span class="sxs-lookup"><span data-stu-id="56291-115">Step 1 - Install IIS and ASP.NET</span></span> 

<span data-ttu-id="56291-116">[インターネット インフォメーション サービス](https://www.iis.net/)は、[スタート] メニュー経由でインストールできる Windows 機能です。</span><span class="sxs-lookup"><span data-stu-id="56291-116">[Internet Information Services](https://www.iis.net/) is a Windows feature that can be installed via the Start menu.</span></span> <span data-ttu-id="56291-117">**[スタート] メニュー**検索の対象に**有効にする Windows の機能のオンまたはオフに**します。</span><span class="sxs-lookup"><span data-stu-id="56291-117">In **Start menu** search for **Turn Windows features on or off**.</span></span>

<span data-ttu-id="56291-118">検索し、**インターネット インフォメーション サービス**を IIS のインストールを選択します。</span><span class="sxs-lookup"><span data-stu-id="56291-118">Find and select **Internet Information Services** to install IIS.</span></span>

> [!NOTE]
> <span data-ttu-id="56291-119">[インターネット インフォメーション サービスのすべてのチェック ボックスをオンにする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="56291-119">You don't need to select all the check boxes under Internet Information Services.</span></span> <span data-ttu-id="56291-120">**インターネット インフォメーション サービス**をチェックすると、選択されているだけで十分です。</span><span class="sxs-lookup"><span data-stu-id="56291-120">Only the ones selected when you check **Internet Information Services** are sufficient.</span></span>

<span data-ttu-id="56291-121">また、ASP.NET 4.5 以上をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="56291-121">You will also need to install ASP.NET 4.5 or greater.</span></span> <span data-ttu-id="56291-122">インストールするには、検索**インターネット インフォメーション サービス] の [World Wide Web サービス アプリケーション開発機能]-> [** します。</span><span class="sxs-lookup"><span data-stu-id="56291-122">To install it, locate **Internet Information Services -> World Wide Web Services -> Application Development Features**.</span></span> <span data-ttu-id="56291-123">ASP.NET 4.5 以上 ASP.NET のバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="56291-123">Select a version of ASP.NET that is greater than or equal to ASP.NET 4.5.</span></span>

![ASP.NET をインストールします。](images/install-asp.png)

## <a name="step-2---install-visual-studio-2017-and-web-development-tools"></a><span data-ttu-id="56291-125">手順 2 - Visual Studio 2017 をインストールし、Web 開発ツール</span><span class="sxs-lookup"><span data-stu-id="56291-125">Step 2 - Install Visual Studio 2017 and Web Development tools</span></span> 

<span data-ttu-id="56291-126">[Visual Studio 2017 のインストール](https://docs.microsoft.com/visualstudio/install/install-visual-studio)を既にインストールしていない場合。</span><span class="sxs-lookup"><span data-stu-id="56291-126">[Install Visual Studio 2017](https://docs.microsoft.com/visualstudio/install/install-visual-studio) if you have not already installed it.</span></span> <span data-ttu-id="56291-127">Visual Studio 2017 を既にある場合は、以下のワークロードがインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="56291-127">If you already have Visual Studio 2017, ensure that the following workloads are installed.</span></span> <span data-ttu-id="56291-128">ワークロードがない場合、インストールに存在する、([スタート] メニューからが見つかりません) Visual Studio インストーラーを使用してに従ってください。</span><span class="sxs-lookup"><span data-stu-id="56291-128">If the workloads are not present on your installation, follow along using the Visual Studio Installer (found from the Start menu).</span></span>  

<span data-ttu-id="56291-129">インストール中には、 **ASP.NET と Web 開発**と興味のあるその他のワークロードを選択します。</span><span class="sxs-lookup"><span data-stu-id="56291-129">During installation, select **ASP.NET and Web development** and any other workloads that you are interested in.</span></span> 

<span data-ttu-id="56291-130">インストールが完了したら、Visual Studio を起動し、新しいプロジェクトの作成 (**ファイル** -> **新しいプロジェクト**)。</span><span class="sxs-lookup"><span data-stu-id="56291-130">Once installation is complete, launch Visual Studio and create a new project (**File** -> **New Project**).</span></span>

## <a name="step-3---build-a-web-app"></a><span data-ttu-id="56291-131">手順 3 - Web アプリを構築</span><span class="sxs-lookup"><span data-stu-id="56291-131">Step 3 - Build a Web App</span></span>

<span data-ttu-id="56291-132">**管理者**として Visual Studio 2017 を起動し、**空**のプロジェクト テンプレートを使って新しい**Visual c# Web アプリケーション**プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="56291-132">Launch Visual Studio 2017 as **Administrator** and create a new **Visual C# Web Application** project with an **empty** project template.</span></span> 

![新しいプロジェクト](images/sample-web-app.png)

## <a name="step-4---configure-iis-with-our-web-app"></a><span data-ttu-id="56291-134">手順 4 -、Web アプリでの IIS の構成</span><span class="sxs-lookup"><span data-stu-id="56291-134">Step 4 - Configure IIS with our Web App</span></span> 

<span data-ttu-id="56291-135">ソリューション エクスプ ローラーで、ルート プロジェクトを右クリックし、[**プロパティ**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="56291-135">From the Solution Explorer, right click on the root project and select **Properties**.</span></span>

<span data-ttu-id="56291-136">Web アプリのプロパティでは、 **Web** ] タブを選択します。**サーバー**のセクションでは、ドロップダウン メニューから**ローカル IIS**を選択し、**仮想ディレクトリの作成**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="56291-136">In the web app properties, select the **Web** tab. In the **Servers** section, choose **Local IIS** from the drop down menu and click **Create Virtual Directory**.</span></span> 

![[web] タブ](images/web-tab.png)

## <a name="step-5---add-an-app-package-to-a-web-application"></a><span data-ttu-id="56291-138">手順 5: web アプリケーションに、アプリ パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="56291-138">Step 5 - Add an app package to a web application</span></span> 

<span data-ttu-id="56291-139">Web アプリケーションに配布する予定のアプリ パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="56291-139">Add the app package that you are going to distribute into the web application.</span></span> <span data-ttu-id="56291-140">利用可能なアプリ パッケージがない場合、GitHub 上に提供されている[スターター プロジェクトのパッケージ](https://github.com/AppInstaller/MySampleWebApp/tree/master/MySampleWebApp/packages)の一部であるアプリのパッケージを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="56291-140">You can use the app package that is part of the provided [starter project packages](https://github.com/AppInstaller/MySampleWebApp/tree/master/MySampleWebApp/packages) on GitHub if you don't have an app package available.</span></span> <span data-ttu-id="56291-141">パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="56291-141">The certificate (MySampleApp.cer) that the package was signed with is also with the sample on GitHub.</span></span> <span data-ttu-id="56291-142">(手順 9) アプリをインストールする前に、デバイスにインストールされている証明書が必要です。</span><span class="sxs-lookup"><span data-stu-id="56291-142">You must have the certificate installed to your device prior to installing the app (Step 9).</span></span>

<span data-ttu-id="56291-143">スターター プロジェクトの web アプリケーションに新しいフォルダーと呼ばれる web アプリに追加された`packages`配布するアプリ パッケージが含まれています。</span><span class="sxs-lookup"><span data-stu-id="56291-143">In the starter project web application, a new folder was added to the web app called `packages` that contains the app packages to be distributed.</span></span> <span data-ttu-id="56291-144">Visual Studio で、フォルダーを作成するには、ソリューション エクスプ ローラーのルート右クリックし、**追加**] を選択 -> **新しいフォルダー**と名前を付けます`packages`します。</span><span class="sxs-lookup"><span data-stu-id="56291-144">To create the folder in Visual Studio, right click on the root of the Solution Explorer, select **Add** -> **New Folder** and name it `packages`.</span></span> <span data-ttu-id="56291-145">アプリ パッケージをフォルダーを追加するを右クリックして、`packages`フォルダーと [ **Add** -> 、アプリを参照し、**既存の項目**の場所をパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="56291-145">To add app packages to the folder, right click on the `packages` folder and select **Add** -> **Existing Item...** and browse to the app package location.</span></span> 

![パッケージに追加します。](images/add-package.png)

## <a name="step-6---create-a-web-page"></a><span data-ttu-id="56291-147">手順 6 - Web ページを作成します。</span><span class="sxs-lookup"><span data-stu-id="56291-147">Step 6 - Create a Web Page</span></span>

<span data-ttu-id="56291-148">このサンプルの web アプリでは、単純な HTML を使用します。</span><span class="sxs-lookup"><span data-stu-id="56291-148">This sample web app uses simple HTML.</span></span> <span data-ttu-id="56291-149">自由にお客様のニーズごとに必要に応じて、web アプリを構築します。</span><span class="sxs-lookup"><span data-stu-id="56291-149">You are free to build your web app as required per your needs.</span></span> 

<span data-ttu-id="56291-150">ソリューション エクスプ ローラーのルート プロジェクトを右クリックしてで、**追加**の選択 -> **新しい項目**では、 **Web** ] セクションから新しい**HTML ページ**を追加します。</span><span class="sxs-lookup"><span data-stu-id="56291-150">Right click on the root project of the Solution explorer, select **Add** -> **New Item**, and add a new **HTML Page** from the **Web** section.</span></span>

<span data-ttu-id="56291-151">HTML ページを作成した後は、ソリューション エクスプ ローラーでの HTML ページを右クリックし、**スタート ページに設定**を選択します。</span><span class="sxs-lookup"><span data-stu-id="56291-151">Once the HTML page is created, right click on the HTML page in the Solution Explorer and select **Set As Start Page**.</span></span>  

<span data-ttu-id="56291-152">コード エディター ウィンドウで開く HTML ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="56291-152">Double-click the HTML file to open it in the code editor window.</span></span> <span data-ttu-id="56291-153">このチュートリアルでは、Windows 10 アプリをインストールするには、正常にアプリ インストーラー アプリを起動する web ページで必須要素のみが使用されます。</span><span class="sxs-lookup"><span data-stu-id="56291-153">In this tutorial, only the elements in the required in the web page to invoke the App Installer app successfully to install a Windows 10 app will be used.</span></span> 

<span data-ttu-id="56291-154">次の HTML コードは、web ページに含めます。</span><span class="sxs-lookup"><span data-stu-id="56291-154">Include the following HTML code in your web page.</span></span> <span data-ttu-id="56291-155">アプリ インストーラーを正常に実行するキーは、OS にアプリ インストーラーが登録されるカスタム スキームを使用する:`ms-appinstaller:?source=`します。</span><span class="sxs-lookup"><span data-stu-id="56291-155">The key to successfully invoking App Installer is to use the custom scheme that App Installer registers with the OS: `ms-appinstaller:?source=`.</span></span> <span data-ttu-id="56291-156">詳細については、次のコード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="56291-156">See the code example below for more details.</span></span>

> [!NOTE]
> <span data-ttu-id="56291-157">カスタム スキームが、VS ソリューションの [web] タブで、プロジェクトの Url と一致する後に指定された URL パスを確認します。</span><span class="sxs-lookup"><span data-stu-id="56291-157">Ensure that the URL path specified after the custom scheme matches the Project Url in the web tab of your VS solution.</span></span>
 
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

## <a name="step-7---configure-the-web-app-for-app-package-mime-types"></a><span data-ttu-id="56291-158">手順 7: アプリ パッケージの MIME タイプ用の web アプリを構成します。</span><span class="sxs-lookup"><span data-stu-id="56291-158">Step 7 - Configure the web app for app package MIME types</span></span>

<span data-ttu-id="56291-159">ソリューション エクスプ ローラーから、 **Web.config**ファイルを開き、内で、次の行を追加、`<configuration>`要素です。</span><span class="sxs-lookup"><span data-stu-id="56291-159">Open the **Web.config** file from the solution explorer and add the following lines within the `<configuration>` element.</span></span> 

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

## <a name="step-8---add-loopback-exemption-for-app-installer"></a><span data-ttu-id="56291-160">手順 8 のアプリ インストーラーのループバックに関する除外を追加します。</span><span class="sxs-lookup"><span data-stu-id="56291-160">Step 8 - Add loopback exemption for App Installer</span></span>

<span data-ttu-id="56291-161">ネットワークの分離のためアプリ インストーラーなどの UWP アプリがなど、IP ループバック アドレスを使用する制限されてhttp://localhost/します。</span><span class="sxs-lookup"><span data-stu-id="56291-161">Due to network isolation, UWP apps like App Installer are restricted to use IP loopback addresses like http://localhost/.</span></span> <span data-ttu-id="56291-162">ローカル IIS サーバーを使用して、アプリ インストーラーがループバックの除外一覧に追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="56291-162">When using local IIS Server, App Installer must be added to the loopback exempt list.</span></span> 

<span data-ttu-id="56291-163">これを行うには、**管理者**として**コマンド プロンプト**を開き、次を入力します: '' コマンド ライン CheckNetIsolation.exe LoopbackExempt-a-n=microsoft.desktopappinstaller_8wekyb3d8bbwe</span><span class="sxs-lookup"><span data-stu-id="56291-163">To do this, open **Command Prompt** as an **Administrator** and enter the following: \`\`\`Command Line CheckNetIsolation.exe LoopbackExempt -a -n=microsoft.desktopappinstaller_8wekyb3d8bbwe</span></span>
```

To verify that the app is added to the exempt list, use the following command to display the apps in the loopback exempt list: 
```Command Line
CheckNetIsolation.exe LoopbackExempt -s
```

<span data-ttu-id="56291-164">検索する必要があります`microsoft.desktopappinstaller_8wekyb3d8bbwe`一覧にします。</span><span class="sxs-lookup"><span data-stu-id="56291-164">You should find `microsoft.desktopappinstaller_8wekyb3d8bbwe` in the list.</span></span>

<span data-ttu-id="56291-165">アプリ インストーラーでアプリのインストールのローカルの検証が完了したら後でこの手順で追加した、ループバックに関する除外を削除できます。</span><span class="sxs-lookup"><span data-stu-id="56291-165">Once the local validation of app installation via App Installer is complete, you can remove the loopback exemption that you added in this step by:</span></span>

<span data-ttu-id="56291-166">'' コマンド ライン CheckNetIsolation.exe LoopbackExempt-d-n=microsoft.desktopappinstaller_8wekyb3d8bbwe</span><span class="sxs-lookup"><span data-stu-id="56291-166">\`\`\`Command Line CheckNetIsolation.exe LoopbackExempt -d -n=microsoft.desktopappinstaller_8wekyb3d8bbwe</span></span>
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
