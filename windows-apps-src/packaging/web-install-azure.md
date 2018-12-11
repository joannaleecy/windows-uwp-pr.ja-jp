---
title: Azure Web サーバーからの UWP アプリのインストール
description: このチュートリアルでは、Azure Web サーバーをセットアップし、Web アプリでアプリ パッケージをホストできることを確認し、アプリ インストーラを効果的に起動して使用する方法を示しています。
ms.date: 11/30/2018
ms.topic: article
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ、Azure Web サーバー
ms.localizationpriority: medium
ms.openlocfilehash: 074a8e9941d4314bb35c28b0ee296e9d86fa23a5
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8896728"
---
# <a name="install-a-uwp-app-from-an-azure-web-app"></a><span data-ttu-id="77e35-104">Azure Web アプリからの UWP アプリのインストール</span><span class="sxs-lookup"><span data-stu-id="77e35-104">Install a UWP app from an Azure Web App</span></span>

<span data-ttu-id="77e35-105">アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。</span><span class="sxs-lookup"><span data-stu-id="77e35-105">The App Installer app allows developers and IT Pros to distribute Windows 10 apps by hosting them on their own Content Delivery Network (CDN).</span></span> <span data-ttu-id="77e35-106">これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="77e35-106">This is useful for enterprises that don't want or need to publish their apps to the Microsoft Store, but still want to take advantage of the Windows 10 packaging and deployment platform.</span></span>

<span data-ttu-id="77e35-107">このトピックでは、Azure Web サーバーが UWP アプリ パッケージをホストするように構成し、アプリ インストーラー アプリを使用してアプリ パッケージをインストールする手順を示しています。</span><span class="sxs-lookup"><span data-stu-id="77e35-107">This topic outlines the steps to configure an Azure Web Server to host UWP app packages, and how to use the App Installer app to install the app packages.</span></span>

## <a name="setup"></a><span data-ttu-id="77e35-108">セットアップ</span><span class="sxs-lookup"><span data-stu-id="77e35-108">Setup</span></span>

<span data-ttu-id="77e35-109">このチュートリアに正常に従うには、以下が必要になります。</span><span class="sxs-lookup"><span data-stu-id="77e35-109">To successfully follow this tutorial, you will need the following:</span></span>
 
1. <span data-ttu-id="77e35-110">Microsoft Azure サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="77e35-110">Microsoft Azure subscription</span></span> 
2. <span data-ttu-id="77e35-111">UWP アプリ パッケージ - 配布するアプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="77e35-111">UWP app package - The app package that you will distribute</span></span>

<span data-ttu-id="77e35-112">オプション: GitHub での[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp)</span><span class="sxs-lookup"><span data-stu-id="77e35-112">Optional: [Starter Project](https://github.com/AppInstaller/MySampleWebApp) on GitHub.</span></span> <span data-ttu-id="77e35-113">これは、使用するアプリ パッケージまたは Web ページがないが、この機能を使用する方法を確認したい場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="77e35-113">This is helpful if you don't an app package or web page to work with, but would still like to learn how to use this feature.</span></span>

### <a name="step-1---get-an-azure-subscription"></a><span data-ttu-id="77e35-114">手順 1 - Azure サブスクリプションの取得</span><span class="sxs-lookup"><span data-stu-id="77e35-114">Step 1 - Get an Azure subscription</span></span>
<span data-ttu-id="77e35-115">Azure サブスクリプションを取得するには、[Azure アカウント ページ](https://azure.microsoft.com/free/)にアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="77e35-115">To get an Azure subscription, visit the [Azure account page](https://azure.microsoft.com/free/).</span></span> <span data-ttu-id="77e35-116">このチュートリアルの目的上、無料のメンバーシップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="77e35-116">For the purposes of this tutorial, you can use a free membership.</span></span>

### <a name="step-2---create-an-azure-web-app"></a><span data-ttu-id="77e35-117">手順 2 - Azure Web アプリの作成</span><span class="sxs-lookup"><span data-stu-id="77e35-117">Step 2 - Create an Azure Web App</span></span> 
<span data-ttu-id="77e35-118">Azure Portal ページで、**[+ Create a Resource] (+ リソースの作成)** ボタンをクリックし、**[Web アプリ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="77e35-118">In the Azure portal page, click the **+ Create a Resource** button and then select **Web App**</span></span>

![作成](images/azure-create-app.png)

<span data-ttu-id="77e35-120">一意の **[アプリ名]** を作成し、残りのフィールドは既定値のままにします。</span><span class="sxs-lookup"><span data-stu-id="77e35-120">Create a unique **App name** and leave the rest of the fields as default.</span></span> <span data-ttu-id="77e35-121">**[作成]** をクリックして Web アプリの作成ウィザードを閉じます。</span><span class="sxs-lookup"><span data-stu-id="77e35-121">Click **Create** to finish the Web App creation wizard.</span></span> 

![Web アプリの作成](images/azure-create-app-2.png)

### <a name="step-3---hosting-the-app-package-and-the-web-page"></a><span data-ttu-id="77e35-123">手順 3 - アプリ パッケージと Web ページのホスト</span><span class="sxs-lookup"><span data-stu-id="77e35-123">Step 3 - Hosting the app package and the web page</span></span> 
<span data-ttu-id="77e35-124">Web アプリを作成したら、Azure ポータルでダッシュ ボードからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="77e35-124">Once the web app had been created, you can access it from the dashboard on the Azure portal.</span></span> <span data-ttu-id="77e35-125">この手順では、Azure ポータルの GUI を備えた簡単な Web ページを作成します。</span><span class="sxs-lookup"><span data-stu-id="77e35-125">In this step, we're going to create a simple web page with the GUI of the Azure portal.</span></span>

<span data-ttu-id="77e35-126">新規に作成した Web アプリをダッシュ ボードから選択した後、検索フィールドを使用して **App Service エディター** を見つけて開きます。</span><span class="sxs-lookup"><span data-stu-id="77e35-126">After selecting the newly created web app from the dashboard, use the search field to find and open **App Service Editor**.</span></span> 

<span data-ttu-id="77e35-127">エディターには、既定の `hostingstart.html` ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="77e35-127">In the editor, there is a default `hostingstart.html` file.</span></span> <span data-ttu-id="77e35-128">エクスプローラー パネルの空白領域を右クリックし、**[ファイルのアップロード]** を選択してアプリ パッケージのアップロードを開始します。</span><span class="sxs-lookup"><span data-stu-id="77e35-128">Right-click in the empty space of file explorer panel and select **Upload Files** to begin uploading your app packages.</span></span>

> [!NOTE]
> <span data-ttu-id="77e35-129">利用可能なアプリ パッケージがない場合は、提供された GitHub の[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) リポジトリの一部であるアプリ パッケージを使用できます。</span><span class="sxs-lookup"><span data-stu-id="77e35-129">You can use the app package that is part of the provided [Starter Project](https://github.com/AppInstaller/MySampleWebApp) repository on GitHub if you don't have an app package available.</span></span> <span data-ttu-id="77e35-130">パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="77e35-130">The certificate (MySampleApp.cer) that the package was signed with is also with the sample on GitHub.</span></span> <span data-ttu-id="77e35-131">アプリをインストールする前に、デバイスに証明書がインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="77e35-131">You must have the certificate installed to your device prior to installing the app.</span></span>

![アップロード](images/azure-upload-file.png)

<span data-ttu-id="77e35-133">エクスプ ローラー パネルの空白領域を右クリックし、**[新しいファイル]** を選択して新しいファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="77e35-133">Right-click in the empty space of file explorer panel and select **New Files** to create a new file.</span></span> <span data-ttu-id="77e35-134">ファイルに `default.html` という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="77e35-134">Name the file: `default.html`.</span></span>

<span data-ttu-id="77e35-135">[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) で提供されたアプリ パッケージを使用している場合は、次の HTML コードをコピーして `default.html` という Web ページを新規に作成します。</span><span class="sxs-lookup"><span data-stu-id="77e35-135">If you're using the app package provided in the [Starter Project](https://github.com/AppInstaller/MySampleWebApp), copy the following HTML code to the newly create web page `default.html`.</span></span> <span data-ttu-id="77e35-136">独自のアプリ パッケージを使用している場合は、アプリ サービスの URL (`source=` の後の URL) を変更します。</span><span class="sxs-lookup"><span data-stu-id="77e35-136">If you're using your own app package, modify the app service URL (the URL after `source=`).</span></span> <span data-ttu-id="77e35-137">Azure ポータルで、アプリの概要ページから、アプリ サービスの URL を取得できます。</span><span class="sxs-lookup"><span data-stu-id="77e35-137">You can get the app service URL from your app's overview page in the Azure portal.</span></span>

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

### <a name="step-4---configure-the-web-app-for-app-package-mime-types"></a><span data-ttu-id="77e35-138">手順 4 - アプリ パッケージの MIME タイプ用の Web アプリの構成</span><span class="sxs-lookup"><span data-stu-id="77e35-138">Step 4 - Configure the web app for app package MIME types</span></span>

<span data-ttu-id="77e35-139">新しいファイルを `Web.config` という名前の Web アプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="77e35-139">Add a new file to the web app named: `Web.config`.</span></span> <span data-ttu-id="77e35-140">エクスプローラーから `Web.config` ファイルを開き、次の行を追加します。</span><span class="sxs-lookup"><span data-stu-id="77e35-140">Open the `Web.config` file from the explorer and add the following lines.</span></span> 

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

### <a name="step-5---run-and-test"></a><span data-ttu-id="77e35-141">手順 5 - 実行とテスト</span><span class="sxs-lookup"><span data-stu-id="77e35-141">Step 5 - Run and test</span></span>

<span data-ttu-id="77e35-142">作成した Web ページを起動するには、手順 3 の URL を `/default.html` に続けてブラウザーに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="77e35-142">To launch the web page that you created, use the URL from step 3 into the browser followed by `/default.html`.</span></span> 

![エッジ](images/edge.png)

<span data-ttu-id="77e35-144">[Install My Sample App] (マイ サンプル アプリのインストール) をクリックしてアプリ インストーラーを起動し、アプリ パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="77e35-144">Click "Install My Sample App" to launch App Installer and install your app package.</span></span> 

## <a name="troubleshooting-issues"></a><span data-ttu-id="77e35-145">問題のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="77e35-145">Troubleshooting Issues</span></span>

### <a name="app-installer-app-fails-to-install"></a><span data-ttu-id="77e35-146">アプリ インストーラー アプリのインストールの失敗</span><span class="sxs-lookup"><span data-stu-id="77e35-146">App Installer app fails to install</span></span> 
<span data-ttu-id="77e35-147">アプリ パッケージの署名に使用されている証明書がデバイスにインストールされていない場合、アプリのインストールは失敗します。</span><span class="sxs-lookup"><span data-stu-id="77e35-147">App install will fail if the certificate that the app package is signed with isn't installed on the device.</span></span> <span data-ttu-id="77e35-148">これを修正するには、アプリのインストール前に証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="77e35-148">To fix this, you will need to install the certificate prior to the installation of the app.</span></span> <span data-ttu-id="77e35-149">一般配布用アプリ パッケージをホストしている場合は、証明機関からの証明書を使用してアプリ パッケージを署名することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="77e35-149">If you are hosting an app package for public distribution, we recommended signing your app package with a certificate from a certificate authority.</span></span> 

![アプリ認定](images/aws-app-cert.png)

### <a name="nothing-happens-when-you-click-the-link"></a><span data-ttu-id="77e35-151">リンクをクリックしても何も反応がない</span><span class="sxs-lookup"><span data-stu-id="77e35-151">Nothing happens when you click the link</span></span> 
<span data-ttu-id="77e35-152">アプリ インストーラー アプリがインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="77e35-152">Ensure that the App Installer app is installed.</span></span> <span data-ttu-id="77e35-153">**[設定]** -> **[アプリと機能]** に移動し、インストールされたアプリの一覧でアプリ インストーラーを見つけます。</span><span class="sxs-lookup"><span data-stu-id="77e35-153">Go to **Settings** -> **Apps & Features** and find App Installer in the installed apps list.</span></span> 

