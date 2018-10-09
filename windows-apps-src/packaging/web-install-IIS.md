---
author: laurenhughes
title: IIS サーバーから UWP アプリをインストールする
description: このチュートリアルでは、IIS サーバーをセットアップを web アプリのアプリ パッケージをホストしを呼び出すし、アプリ インストーラーを効果的に使用ことを確認する方法について説明します。
ms.author: cdon
ms.date: 05/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング、関連セット, オプション パッケージ、IIS サーバー
ms.localizationpriority: medium
ms.openlocfilehash: 214ddd2b55bca1acecbab0a841cf2048335e7b3a
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4469521"
---
# <a name="install-a-uwp-app-from-an-iis-server"></a><span data-ttu-id="f6b5c-104">IIS サーバーから UWP アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="f6b5c-104">Install a UWP app from an IIS server</span></span>

<span data-ttu-id="f6b5c-105">このチュートリアルでは、IIS サーバーをセットアップを web アプリのアプリ パッケージをホストしを呼び出すし、アプリ インストーラーを効果的に使用ことを確認する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-105">This tutorial demonstrates how to set up an IIS server, verify that your web app can host app packages, and invoke and use App Installer effectively.</span></span>

<span data-ttu-id="f6b5c-106">アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-106">The App Installer app allows developers and IT Pros to distribute Windows 10 apps by hosting them on their own Content Delivery Network (CDN).</span></span> <span data-ttu-id="f6b5c-107">これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-107">This is useful for enterprises that don't want or need to publish their apps to the Microsoft Store, but still want to take advantage of the Windows 10 packaging and deployment platform.</span></span> 

## <a name="setup"></a><span data-ttu-id="f6b5c-108">セットアップ</span><span class="sxs-lookup"><span data-stu-id="f6b5c-108">Setup</span></span>

<span data-ttu-id="f6b5c-109">正常に実行するこのチュートリアルで、以下が必要は。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-109">To successfully go through with this tutorial, you will need the following:</span></span>

1. <span data-ttu-id="f6b5c-110">Visual Studio 2017</span><span class="sxs-lookup"><span data-stu-id="f6b5c-110">Visual Studio 2017</span></span>  
2. <span data-ttu-id="f6b5c-111">Web 開発ツールと IIS</span><span class="sxs-lookup"><span data-stu-id="f6b5c-111">Web development tools and IIS</span></span> 
3. <span data-ttu-id="f6b5c-112">UWP アプリ パッケージ - 配布するアプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="f6b5c-112">UWP app package - The app package that you will distribute</span></span>

<span data-ttu-id="f6b5c-113">オプション: GitHub での[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp)</span><span class="sxs-lookup"><span data-stu-id="f6b5c-113">Optional: [Starter Project](https://github.com/AppInstaller/MySampleWebApp) on GitHub.</span></span> <span data-ttu-id="f6b5c-114">これは、アプリ パッケージと併用する必要はありませんが、この機能を使用する方法についてをしたい場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-114">This is helpful if you don't have app packages to work with, but would still like to learn how to use this feature.</span></span>

## <a name="step-1---install-iis-and-aspnet"></a><span data-ttu-id="f6b5c-115">手順 1 - IIS と ASP.NET をインストールします。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-115">Step 1 - Install IIS and ASP.NET</span></span> 

<span data-ttu-id="f6b5c-116">[インターネット インフォメーション サービス](https://www.iis.net/)は、スタート メニューの [経由でインストールできる Windows 機能です。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-116">[Internet Information Services](https://www.iis.net/) is a Windows feature that can be installed via the Start menu.</span></span> <span data-ttu-id="f6b5c-117">**[スタート] メニュー**検索の対象に**Windows の機能のオンまたはオフに**します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-117">In **Start menu** search for **Turn Windows features on or off**.</span></span>

<span data-ttu-id="f6b5c-118">検索し、**インターネット インフォメーション サービス**を IIS のインストールを選択します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-118">Find and select **Internet Information Services** to install IIS.</span></span>

> [!NOTE]
> <span data-ttu-id="f6b5c-119">[インターネット インフォメーション サービスのすべてのチェック ボックスをオンにする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-119">You don't need to select all the check boxes under Internet Information Services.</span></span> <span data-ttu-id="f6b5c-120">**インターネット インフォメーション サービス**をチェックすると、選択されているだけで十分です。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-120">Only the ones selected when you check **Internet Information Services** are sufficient.</span></span>

<span data-ttu-id="f6b5c-121">また、ASP.NET 4.5 以上をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-121">You will also need to install ASP.NET 4.5 or greater.</span></span> <span data-ttu-id="f6b5c-122">インストールするには、検索**インターネット インフォメーション サービス] の [World Wide Web サービス アプリケーション開発機能]-> [** します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-122">To install it, locate **Internet Information Services -> World Wide Web Services -> Application Development Features**.</span></span> <span data-ttu-id="f6b5c-123">ASP.NET 4.5 以上 ASP.NET のバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-123">Select a version of ASP.NET that is greater than or equal to ASP.NET 4.5.</span></span>

![ASP.NET をインストールします。](images/install-asp.png)

## <a name="step-2---install-visual-studio-2017-and-web-development-tools"></a><span data-ttu-id="f6b5c-125">手順 2 - Visual Studio 2017 をインストールし、Web 開発ツール</span><span class="sxs-lookup"><span data-stu-id="f6b5c-125">Step 2 - Install Visual Studio 2017 and Web Development tools</span></span> 

<span data-ttu-id="f6b5c-126">[Visual Studio 2017 のインストール](https://docs.microsoft.com/visualstudio/install/install-visual-studio)を既にインストールしていない場合。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-126">[Install Visual Studio 2017](https://docs.microsoft.com/visualstudio/install/install-visual-studio) if you have not already installed it.</span></span> <span data-ttu-id="f6b5c-127">Visual Studio 2017 を既にある場合は、以下のワークロードがインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-127">If you already have Visual Studio 2017, ensure that the following workloads are installed.</span></span> <span data-ttu-id="f6b5c-128">ワークロードがない場合、インストールに存在する、([スタート] メニューからが見つかりません) Visual Studio インストーラーを使用してに従ってください。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-128">If the workloads are not present on your installation, follow along using the Visual Studio Installer (found from the Start menu).</span></span>  

<span data-ttu-id="f6b5c-129">インストール時に、 **ASP.NET と Web 開発**や興味のあるその他の任意のワークロードを選択します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-129">During installation, select **ASP.NET and Web development** and any other workloads that you are interested in.</span></span> 

<span data-ttu-id="f6b5c-130">インストールが完了した後、Visual Studio を起動し、新しいプロジェクトを作成 (**ファイル** -> **新しいプロジェクト**)。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-130">Once installation is complete, launch Visual Studio and create a new project (**File** -> **New Project**).</span></span>

## <a name="step-3---build-a-web-app"></a><span data-ttu-id="f6b5c-131">手順 3 - Web アプリを構築</span><span class="sxs-lookup"><span data-stu-id="f6b5c-131">Step 3 - Build a Web App</span></span>

<span data-ttu-id="f6b5c-132">**管理者**として Visual Studio 2017 を起動し、**空**のプロジェクト テンプレートを使って新しい**Visual c# Web アプリケーション**プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-132">Launch Visual Studio 2017 as **Administrator** and create a new **Visual C# Web Application** project with an **empty** project template.</span></span> 

![新しいプロジェクト](images/sample-web-app.png)

## <a name="step-4---configure-iis-with-our-web-app"></a><span data-ttu-id="f6b5c-134">手順 4 -、Web アプリでの IIS の構成</span><span class="sxs-lookup"><span data-stu-id="f6b5c-134">Step 4 - Configure IIS with our Web App</span></span> 

<span data-ttu-id="f6b5c-135">ソリューション エクスプ ローラーからルート プロジェクトを右クリックし、[**プロパティ**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-135">From the Solution Explorer, right click on the root project and select **Properties**.</span></span>

<span data-ttu-id="f6b5c-136">Web アプリのプロパティでは、 **Web** ] タブを選択します。**サーバー** 」セクションで、ドロップダウン メニューから**ローカル IIS**を選択し、**仮想ディレクトリの作成**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-136">In the web app properties, select the **Web** tab. In the **Servers** section, choose **Local IIS** from the drop down menu and click **Create Virtual Directory**.</span></span> 

![[web] タブ](images/web-tab.png)

## <a name="step-5---add-an-app-package-to-a-web-application"></a><span data-ttu-id="f6b5c-138">手順 5: web アプリケーションに、アプリ パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-138">Step 5 - Add an app package to a web application</span></span> 

<span data-ttu-id="f6b5c-139">Web アプリケーションに配布する予定のアプリ パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-139">Add the app package that you are going to distribute into the web application.</span></span> <span data-ttu-id="f6b5c-140">利用可能なアプリ パッケージがあるない場合は、GitHub で提供されている[スターター プロジェクトのパッケージ](https://github.com/AppInstaller/MySampleWebApp/tree/master/MySampleWebApp/packages)の一部であるアプリ パッケージを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-140">You can use the app package that is part of the provided [starter project packages](https://github.com/AppInstaller/MySampleWebApp/tree/master/MySampleWebApp/packages) on GitHub if you don't have an app package available.</span></span> <span data-ttu-id="f6b5c-141">パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-141">The certificate (MySampleApp.cer) that the package was signed with is also with the sample on GitHub.</span></span> <span data-ttu-id="f6b5c-142">アプリ (手順 9) をインストールする前に、デバイスにインストールされている証明書が必要です。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-142">You must have the certificate installed to your device prior to installing the app (Step 9).</span></span>

<span data-ttu-id="f6b5c-143">スターター プロジェクトの web アプリケーションに新しいフォルダーと呼ばれる web アプリに追加された`packages`配布するアプリ パッケージが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-143">In the starter project web application, a new folder was added to the web app called `packages` that contains the app packages to be distributed.</span></span> <span data-ttu-id="f6b5c-144">Visual Studio で、フォルダーを作成するには、ソリューション エクスプ ローラーのルートを右クリックして、**追加**] を選択 -> **新しいフォルダー**と名前を付けます`packages`します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-144">To create the folder in Visual Studio, right click on the root of the Solution Explorer, select **Add** -> **New Folder** and name it `packages`.</span></span> <span data-ttu-id="f6b5c-145">アプリ パッケージをフォルダーに追加するを右クリックして、`packages`フォルダーと [ **Add** -> 、アプリを参照し、**既存の項目**の場所をパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-145">To add app packages to the folder, right click on the `packages` folder and select **Add** -> **Existing Item...** and browse to the app package location.</span></span> 

![パッケージに追加します。](images/add-package.png)

## <a name="step-6---create-a-web-page"></a><span data-ttu-id="f6b5c-147">手順 6 - Web ページを作成します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-147">Step 6 - Create a Web Page</span></span>

<span data-ttu-id="f6b5c-148">このサンプルの web アプリでは、単純な HTML を使用します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-148">This sample web app uses simple HTML.</span></span> <span data-ttu-id="f6b5c-149">自由としてニーズごとに必要な web アプリをビルドします。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-149">You are free to build your web app as required per your needs.</span></span> 

<span data-ttu-id="f6b5c-150">ソリューション エクスプ ローラーのルート プロジェクトを右クリックして、**追加**] を選択 -> **新しい項目**では、 **Web**セクションから新しい**HTML ページ**を追加します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-150">Right click on the root project of the Solution explorer, select **Add** -> **New Item**, and add a new **HTML Page** from the **Web** section.</span></span>

<span data-ttu-id="f6b5c-151">HTML ページを作成した後は、ソリューション エクスプ ローラーでの HTML ページを右クリックし、**スタート ページに設定**を選択します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-151">Once the HTML page is created, right click on the HTML page in the Solution Explorer and select **Set As Start Page**.</span></span>  

<span data-ttu-id="f6b5c-152">コード エディター ウィンドウで開く HTML ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-152">Double-click the HTML file to open it in the code editor window.</span></span> <span data-ttu-id="f6b5c-153">このチュートリアルでは、必要な Windows 10 アプリをインストールするには、正常にアプリ インストーラー アプリを起動する web ページ内で要素のみが使用されます。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-153">In this tutorial, only the elements in the required in the web page to invoke the App Installer app successfully to install a Windows 10 app will be used.</span></span> 

<span data-ttu-id="f6b5c-154">次の HTML コードは、web ページに含めます。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-154">Include the following HTML code in your web page.</span></span> <span data-ttu-id="f6b5c-155">アプリ インストーラーを正常に実行するキーは、アプリ インストーラーが OS に登録されるカスタム スキームを使用する:`ms-appinstaller:?source=`します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-155">The key to successfully invoking App Installer is to use the custom scheme that App Installer registers with the OS: `ms-appinstaller:?source=`.</span></span> <span data-ttu-id="f6b5c-156">詳細については、次のコード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-156">See the code example below for more details.</span></span>

> [!NOTE]
> <span data-ttu-id="f6b5c-157">カスタム スキームが、VS ソリューションの [web] タブで、プロジェクトの Url と一致する後に指定された URL パスを確認します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-157">Ensure that the URL path specified after the custom scheme matches the Project Url in the web tab of your VS solution.</span></span>
 
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

## <a name="step-7---configure-the-web-app-for-app-package-mime-types"></a><span data-ttu-id="f6b5c-158">手順 7: アプリ パッケージの MIME タイプ用の web アプリの構成</span><span class="sxs-lookup"><span data-stu-id="f6b5c-158">Step 7 - Configure the web app for app package MIME types</span></span>

<span data-ttu-id="f6b5c-159">ソリューション エクスプ ローラーから、 **Web.config**ファイルを開き、内で、次の行を追加、`<configuration>`要素です。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-159">Open the **Web.config** file from the solution explorer and add the following lines within the `<configuration>` element.</span></span> 

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

## <a name="step-8---add-loopback-exemption-for-app-installer"></a><span data-ttu-id="f6b5c-160">手順 8 のアプリ インストーラーのループバックに関する除外を追加します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-160">Step 8 - Add loopback exemption for App Installer</span></span>

<span data-ttu-id="f6b5c-161">アプリ インストーラーなどの UWP アプリのような IP ループバック アドレスを使用してに制限されますネットワークの分離が原因http://localhost/します。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-161">Due to network isolation, UWP apps like App Installer are restricted to use IP loopback addresses like http://localhost/.</span></span> <span data-ttu-id="f6b5c-162">ローカル IIS サーバーを使用して、アプリ インストーラーがループバックの適用除外リストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-162">When using local IIS Server, App Installer must be added to the loopback exempt list.</span></span> 

<span data-ttu-id="f6b5c-163">これを行うには、**管理者**として**コマンド プロンプト**を開き、次を入力します: '' コマンド ライン CheckNetIsolation.exe LoopbackExempt-a-n=microsoft.desktopappinstaller_8wekyb3d8bbwe</span><span class="sxs-lookup"><span data-stu-id="f6b5c-163">To do this, open **Command Prompt** as an **Administrator** and enter the following: \`\`\`Command Line CheckNetIsolation.exe LoopbackExempt -a -n=microsoft.desktopappinstaller_8wekyb3d8bbwe</span></span>
```

To verify that the app is added to the exempt list, use the following command to display the apps in the loopback exempt list: 
```Command Line
CheckNetIsolation.exe LoopbackExempt -s
```

<span data-ttu-id="f6b5c-164">検索する必要があります`microsoft.desktopappinstaller_8wekyb3d8bbwe`一覧にします。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-164">You should find `microsoft.desktopappinstaller_8wekyb3d8bbwe` in the list.</span></span>

<span data-ttu-id="f6b5c-165">アプリ インストーラーでアプリのインストールのローカルの検証が完了したら後でこの手順で追加した、ループバックに関する除外を削除できます。</span><span class="sxs-lookup"><span data-stu-id="f6b5c-165">Once the local validation of app installation via App Installer is complete, you can remove the loopback exemption that you added in this step by:</span></span>

<span data-ttu-id="f6b5c-166">'' コマンド ライン CheckNetIsolation.exe LoopbackExempt-d-n=microsoft.desktopappinstaller_8wekyb3d8bbwe</span><span class="sxs-lookup"><span data-stu-id="f6b5c-166">\`\`\`Command Line CheckNetIsolation.exe LoopbackExempt -d -n=microsoft.desktopappinstaller_8wekyb3d8bbwe</span></span>
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
