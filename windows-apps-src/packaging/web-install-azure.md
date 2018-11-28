---
title: Azure Web サーバーからの UWP アプリのインストール
description: このチュートリアルでは、Azure Web サーバーをセットアップし、Web アプリでアプリ パッケージをホストできることを確認し、アプリ インストーラを効果的に起動して使用する方法を示しています。
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ、Azure Web サーバー
ms.localizationpriority: medium
ms.openlocfilehash: 0f0e4fe6cd2b05c2de4648a410ba43ce27e48922
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7969843"
---
# <a name="install-a-uwp-app-from-an-azure-web-app"></a><span data-ttu-id="169dc-104">Azure Web アプリからの UWP アプリのインストール</span><span class="sxs-lookup"><span data-stu-id="169dc-104">Install a UWP app from an Azure Web App</span></span>

<span data-ttu-id="169dc-105">アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。</span><span class="sxs-lookup"><span data-stu-id="169dc-105">The App Installer app allows developers and IT Pros to distribute Windows 10 apps by hosting them on their own Content Delivery Network (CDN).</span></span> <span data-ttu-id="169dc-106">これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="169dc-106">This is useful for enterprises that don't want or need to publish their apps to the Microsoft Store, but still want to take advantage of the Windows 10 packaging and deployment platform.</span></span>

<span data-ttu-id="169dc-107">このトピックでは、Azure Web サーバーが UWP アプリ パッケージをホストするように構成し、アプリ インストーラー アプリを使用してアプリ パッケージをインストールする手順を示しています。</span><span class="sxs-lookup"><span data-stu-id="169dc-107">This topic outlines the steps to configure an Azure Web Server to host UWP app packages, and how to use the App Installer app to install the app packages.</span></span>

<span data-ttu-id="169dc-108">このチュートリアルでは、IIS サーバーをセットアップし、Web アプリケーションが適切にアプリ パッケージをホストし、アプリ インストーラー アプリを効果的に起動して使用できることをローカルで確認する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="169dc-108">In this tutorial, we will go over setting up an IIS server to locally verify that your web application can properly host the app packages and invoke and use App Installer app effectively.</span></span> <span data-ttu-id="169dc-109">また、現場で一般的なクラウド Web サービス (Azure および AWS) で Web アプリケーションを適切にホストし、それらのアプリケーションがアプリ インストーラーの Web インストール要件を満たしていることを確認するためのチュートリアルもあります。</span><span class="sxs-lookup"><span data-stu-id="169dc-109">We will also have tutorials for hosting your web applications properly on the popular cloud web services in the field (Azure and AWS) to ensure that they meets the App Installer web install requirements.</span></span> <span data-ttu-id="169dc-110">この手順を説明したチュートリアルには専門知識は必要なく、非常に簡単に理解できます。</span><span class="sxs-lookup"><span data-stu-id="169dc-110">This step-by-step tutorial doesn't require any expertise and is very easy to follow.</span></span> 

## <a name="setup"></a><span data-ttu-id="169dc-111">セットアップ</span><span class="sxs-lookup"><span data-stu-id="169dc-111">Setup</span></span>

<span data-ttu-id="169dc-112">このチュートリアに正常に従うには、以下が必要になります。</span><span class="sxs-lookup"><span data-stu-id="169dc-112">To successfully follow this tutorial, you will need the following:</span></span>
 
1. <span data-ttu-id="169dc-113">Microsoft Azure サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="169dc-113">Microsoft Azure subscription</span></span> 
2. <span data-ttu-id="169dc-114">UWP アプリ パッケージ - 配布するアプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="169dc-114">UWP app package - The app package that you will distribute</span></span>

<span data-ttu-id="169dc-115">オプション: GitHub での[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp)</span><span class="sxs-lookup"><span data-stu-id="169dc-115">Optional: [Starter Project](https://github.com/AppInstaller/MySampleWebApp) on GitHub.</span></span> <span data-ttu-id="169dc-116">これは、使用するアプリ パッケージまたは Web ページがないが、この機能を使用する方法を確認したい場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="169dc-116">This is helpful if you don't an app package or web page to work with, but would still like to learn how to use this feature.</span></span>

### <a name="step-1---get-an-azure-subscription"></a><span data-ttu-id="169dc-117">手順 1 - Azure サブスクリプションの取得</span><span class="sxs-lookup"><span data-stu-id="169dc-117">Step 1 - Get an Azure subscription</span></span>
<span data-ttu-id="169dc-118">Azure サブスクリプションを取得するには、[Azure アカウント ページ](https://azure.microsoft.com/free/)にアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="169dc-118">To get an Azure subscription, visit the [Azure account page](https://azure.microsoft.com/free/).</span></span> <span data-ttu-id="169dc-119">このチュートリアルの目的上、無料のメンバーシップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="169dc-119">For the purposes of this tutorial, you can use a free membership.</span></span>

### <a name="step-2---create-an-azure-web-app"></a><span data-ttu-id="169dc-120">手順 2 - Azure Web アプリの作成</span><span class="sxs-lookup"><span data-stu-id="169dc-120">Step 2 - Create an Azure Web App</span></span> 
<span data-ttu-id="169dc-121">Azure Portal ページで、**[+ Create a Resource] (+ リソースの作成)** ボタンをクリックし、**[Web アプリ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="169dc-121">In the Azure portal page, click the **+ Create a Resource** button and then select **Web App**</span></span>

![作成](images/azure-create-app.png)

<span data-ttu-id="169dc-123">一意の **[アプリ名]** を作成し、残りのフィールドは既定値のままにします。</span><span class="sxs-lookup"><span data-stu-id="169dc-123">Create a unique **App name** and leave the rest of the fields as default.</span></span> <span data-ttu-id="169dc-124">**[作成]** をクリックして Web アプリの作成ウィザードを閉じます。</span><span class="sxs-lookup"><span data-stu-id="169dc-124">Click **Create** to finish the Web App creation wizard.</span></span> 

![Web アプリの作成](images/azure-create-app-2.png)

### <a name="step-3---hosting-the-app-package-and-the-web-page"></a><span data-ttu-id="169dc-126">手順 3 - アプリ パッケージと Web ページのホスト</span><span class="sxs-lookup"><span data-stu-id="169dc-126">Step 3 - Hosting the app package and the web page</span></span> 
<span data-ttu-id="169dc-127">Web アプリを作成したら、Azure ポータルでダッシュ ボードからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="169dc-127">Once the web app had been created, you can access it from the dashboard on the Azure portal.</span></span> <span data-ttu-id="169dc-128">この手順では、Azure ポータルの GUI を備えた簡単な Web ページを作成します。</span><span class="sxs-lookup"><span data-stu-id="169dc-128">In this step, we're going to create a simple web page with the GUI of the Azure portal.</span></span>

<span data-ttu-id="169dc-129">新規に作成した Web アプリをダッシュ ボードから選択した後、検索フィールドを使用して **App Service エディター** を見つけて開きます。</span><span class="sxs-lookup"><span data-stu-id="169dc-129">After selecting the newly created web app from the dashboard, use the search field to find and open **App Service Editor**.</span></span> 

<span data-ttu-id="169dc-130">エディターには、既定の `hostingstart.html` ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="169dc-130">In the editor, there is a default `hostingstart.html` file.</span></span> <span data-ttu-id="169dc-131">エクスプローラー パネルの空白領域を右クリックし、**[ファイルのアップロード]** を選択してアプリ パッケージのアップロードを開始します。</span><span class="sxs-lookup"><span data-stu-id="169dc-131">Right-click in the empty space of file explorer panel and select **Upload Files** to begin uploading your app packages.</span></span>

> [!NOTE]
> <span data-ttu-id="169dc-132">利用可能なアプリ パッケージがない場合は、提供された GitHub の[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) リポジトリの一部であるアプリ パッケージを使用できます。</span><span class="sxs-lookup"><span data-stu-id="169dc-132">You can use the app package that is part of the provided [Starter Project](https://github.com/AppInstaller/MySampleWebApp) repository on GitHub if you don't have an app package available.</span></span> <span data-ttu-id="169dc-133">パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="169dc-133">The certificate (MySampleApp.cer) that the package was signed with is also with the sample on GitHub.</span></span> <span data-ttu-id="169dc-134">アプリをインストールする前に、デバイスに証明書がインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="169dc-134">You must have the certificate installed to your device prior to installing the app.</span></span>

![アップロード](images/azure-upload-file.png)

<span data-ttu-id="169dc-136">エクスプ ローラー パネルの空白領域を右クリックし、**[新しいファイル]** を選択して新しいファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="169dc-136">Right-click in the empty space of file explorer panel and select **New Files** to create a new file.</span></span> <span data-ttu-id="169dc-137">ファイルに `default.html` という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="169dc-137">Name the file: `default.html`.</span></span>

<span data-ttu-id="169dc-138">[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) で提供されたアプリ パッケージを使用している場合は、次の HTML コードをコピーして `default.html` という Web ページを新規に作成します。</span><span class="sxs-lookup"><span data-stu-id="169dc-138">If you're using the app package provided in the [Starter Project](https://github.com/AppInstaller/MySampleWebApp), copy the following HTML code to the newly create web page `default.html`.</span></span> <span data-ttu-id="169dc-139">独自のアプリ パッケージを使用している場合は、アプリ サービスの URL (`source=` の後の URL) を変更します。</span><span class="sxs-lookup"><span data-stu-id="169dc-139">If you're using your own app package, modify the app service URL (the URL after `source=`).</span></span> <span data-ttu-id="169dc-140">Azure ポータルで、アプリの概要ページから、アプリ サービスの URL を取得できます。</span><span class="sxs-lookup"><span data-stu-id="169dc-140">You can get the app service URL from your app's overview page in the Azure portal.</span></span>

```html
<html>
<head>
    <meta charset="utf-8" />
    <title> Install My Sample App</title>
</head>
<body>
    <a href="ms-appinstaller:?source=https://appinstaller-azure-demo.azurewebsites.net/MySampleApp.appxbundle"> Install My Sample App</a>
</body>
</html>
```

### <a name="step-4---configure-the-web-app-for-app-package-mime-types"></a><span data-ttu-id="169dc-141">手順 4 - アプリ パッケージの MIME タイプ用の Web アプリの構成</span><span class="sxs-lookup"><span data-stu-id="169dc-141">Step 4 - Configure the web app for app package MIME types</span></span>

<span data-ttu-id="169dc-142">新しいファイルを `Web.config` という名前の Web アプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="169dc-142">Add a new file to the web app named: `Web.config`.</span></span> <span data-ttu-id="169dc-143">エクスプローラーから `Web.config` ファイルを開き、次の行を追加します。</span><span class="sxs-lookup"><span data-stu-id="169dc-143">Open the `Web.config` file from the explorer and add the following lines.</span></span> 

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
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
</configuration>
```

### <a name="step-5---run-and-test"></a><span data-ttu-id="169dc-144">手順 5 - 実行とテスト</span><span class="sxs-lookup"><span data-stu-id="169dc-144">Step 5 - Run and test</span></span>

<span data-ttu-id="169dc-145">作成した Web ページを起動するには、手順 3 の URL を `/default.html` に続けてブラウザーに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="169dc-145">To launch the web page that you created, use the URL from step 3 into the browser followed by `/default.html`.</span></span> 

![エッジ](images/edge.png)

<span data-ttu-id="169dc-147">[Install My Sample App] (マイ サンプル アプリのインストール) をクリックしてアプリ インストーラーを起動し、アプリ パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="169dc-147">Click "Install My Sample App" to launch App Installer and install your app package.</span></span> 

## <a name="troubleshooting-issues"></a><span data-ttu-id="169dc-148">問題のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="169dc-148">Troubleshooting Issues</span></span>

### <a name="app-installer-app-fails-to-install"></a><span data-ttu-id="169dc-149">アプリ インストーラー アプリのインストールの失敗</span><span class="sxs-lookup"><span data-stu-id="169dc-149">App Installer app fails to install</span></span> 
<span data-ttu-id="169dc-150">アプリ パッケージの署名に使用されている証明書がデバイスにインストールされていない場合、アプリのインストールは失敗します。</span><span class="sxs-lookup"><span data-stu-id="169dc-150">App install will fail if the certificate that the app package is signed with isn't installed on the device.</span></span> <span data-ttu-id="169dc-151">これを修正するには、アプリのインストール前に証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="169dc-151">To fix this, you will need to install the certificate prior to the installation of the app.</span></span> <span data-ttu-id="169dc-152">一般配布用アプリ パッケージをホストしている場合は、証明機関からの証明書を使用してアプリ パッケージを署名することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="169dc-152">If you are hosting an app package for public distribution, we recommended signing your app package with a certificate from a certificate authority.</span></span> 

![アプリ認定](images/aws-app-cert.png)

### <a name="nothing-happens-when-you-click-the-link"></a><span data-ttu-id="169dc-154">リンクをクリックしても何も反応がない</span><span class="sxs-lookup"><span data-stu-id="169dc-154">Nothing happens when you click the link</span></span> 
<span data-ttu-id="169dc-155">アプリ インストーラー アプリがインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="169dc-155">Ensure that the App Installer app is installed.</span></span> <span data-ttu-id="169dc-156">**[設定]** -> **[アプリと機能]** に移動し、インストールされたアプリの一覧でアプリ インストーラーを見つけます。</span><span class="sxs-lookup"><span data-stu-id="169dc-156">Go to **Settings** -> **Apps & Features** and find App Installer in the installed apps list.</span></span> 

