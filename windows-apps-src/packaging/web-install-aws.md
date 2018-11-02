---
author: laurenhughes
title: Web インストール用に AWS で UWP アプリ パッケージをホストする
description: アプリ インストーラー アプリ経由でアプリのインストールを検証する AWS web サーバーを設定するためのチュートリアル
ms.author: cdon
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10、Windows 10, UWP, アプリ インストーラー, AppInstaller, サイドローディングでは、関連セット, オプション パッケージ、AWS
ms.localizationpriority: medium
ms.openlocfilehash: f24abac93e2444a3c9f454c8883902e5db4d31be
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5972158"
---
# <a name="hosting-uwp-app-packages-on-aws-for-web-install"></a><span data-ttu-id="b1c52-104">Web インストール用に AWS で UWP アプリ パッケージをホストする</span><span class="sxs-lookup"><span data-stu-id="b1c52-104">Hosting UWP app packages on AWS for web install</span></span>

<span data-ttu-id="b1c52-105">アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。</span><span class="sxs-lookup"><span data-stu-id="b1c52-105">The App Installer app allows developers and IT Pros to distribute Windows 10 apps by hosting them on their own Content Delivery Network (CDN).</span></span> <span data-ttu-id="b1c52-106">これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="b1c52-106">This is useful for enterprises that don't want or need to publish their apps to the Microsoft Store, but still want to take advantage of the Windows 10 packaging and deployment platform.</span></span>

<span data-ttu-id="b1c52-107">このトピックでは、UWP アプリ パッケージをホストする、Amazon Web サービス (AWS) web サイトとアプリ パッケージをインストールするアプリ インストーラー アプリを使用する方法を構成する手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-107">This topic outlines the steps to configure an Amazon Web Services (AWS) website to host UWP app packages, and how to use the App Installer app to install the app packages.</span></span>

## <a name="setup"></a><span data-ttu-id="b1c52-108">セットアップ</span><span class="sxs-lookup"><span data-stu-id="b1c52-108">Setup</span></span>

<span data-ttu-id="b1c52-109">このチュートリアに正常に従うには、以下が必要になります。</span><span class="sxs-lookup"><span data-stu-id="b1c52-109">To successfully follow this tutorial, you will need the following:</span></span>
 
1. <span data-ttu-id="b1c52-110">AWS サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="b1c52-110">AWS subscription</span></span> 
2. <span data-ttu-id="b1c52-111">Web ページ</span><span class="sxs-lookup"><span data-stu-id="b1c52-111">Web page</span></span>
3. <span data-ttu-id="b1c52-112">UWP アプリ パッケージ - 配布するアプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="b1c52-112">UWP app package - The app package that you will distribute</span></span>

<span data-ttu-id="b1c52-113">オプション: GitHub での[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp)</span><span class="sxs-lookup"><span data-stu-id="b1c52-113">Optional: [Starter Project](https://github.com/AppInstaller/MySampleWebApp) on GitHub.</span></span> <span data-ttu-id="b1c52-114">これは、使用するアプリ パッケージまたは Web ページがないが、この機能を使用する方法を確認したい場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="b1c52-114">This is helpful if you don't an app package or web page to work with, but would still like to learn how to use this feature.</span></span>

<span data-ttu-id="b1c52-115">このチュートリアルについては、セットアップの web ページと AWS でパッケージをホストする方法を経由します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-115">This tutorial will go over how to setup a web page and host packages on AWS.</span></span> <span data-ttu-id="b1c52-116">これによって、AWS サブスクリプションが必要です。</span><span class="sxs-lookup"><span data-stu-id="b1c52-116">This will require an AWS subscription.</span></span> <span data-ttu-id="b1c52-117">に応じて、操作のスケールは、このチュートリアルに従う無料のメンバーシップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b1c52-117">Depending on the scale of your operation, you can use their free membership to follow this tutorial.</span></span> 

## <a name="step-1---aws-membership"></a><span data-ttu-id="b1c52-118">手順 1 - AWS メンバーシップ</span><span class="sxs-lookup"><span data-stu-id="b1c52-118">Step 1 - AWS membership</span></span>
<span data-ttu-id="b1c52-119">AWS メンバーシップを取得するには、 [AWS アカウントの詳細ページ](https://aws.amazon.com/free/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b1c52-119">To get an AWS membership, visit the [AWS account details page](https://aws.amazon.com/free/).</span></span> <span data-ttu-id="b1c52-120">このチュートリアルの目的上、無料のメンバーシップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b1c52-120">For the purposes of this tutorial, you can use a free membership.</span></span>

## <a name="step-2---create-an-amazon-s3-bucket"></a><span data-ttu-id="b1c52-121">手順 2 -、Amazon S3 バケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-121">Step 2 - Create an Amazon S3 bucket</span></span>

<span data-ttu-id="b1c52-122">Amazon Simple Storage Service (S3) は、AWS の収集、保存データの分析を提供します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-122">Amazon Simple Storage Service (S3) is an AWS offering for collecting, storing and analyzing data.</span></span> <span data-ttu-id="b1c52-123">S3 バケットは、UWP アプリ パッケージをホストして配布するための web ページの便利な方法です。</span><span class="sxs-lookup"><span data-stu-id="b1c52-123">S3 buckets are a convenient way to host UWP app packages and web pages for distribution.</span></span> 

<span data-ttu-id="b1c52-124">ログインした後に AWS、資格情報を使って [`Services`検索`S3`します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-124">After logging in to AWS with your credentials, under `Services` find `S3`.</span></span> 

<span data-ttu-id="b1c52-125">**作成バケット**を選択し、web サイトの**バケット名**を入力します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-125">Select **Create bucket**, and enter a **Bucket name** for your website.</span></span> <span data-ttu-id="b1c52-126">プロパティとアクセス許可を設定するためのダイアログ ボックスの指示に従います。</span><span class="sxs-lookup"><span data-stu-id="b1c52-126">Follow the dialog prompts for setting properties and permissions.</span></span> <span data-ttu-id="b1c52-127">Web サイトから UWP アプリを配布でくためには、**読み取り**と**書き込み**のアクセス許可のバケツを有効にし、**このバケットにパブリック読み取りアクセスを許可**を選択します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-127">To ensure that your UWP app can be distributed from your website, enable **Read** and **Write** permissions for your bucket and select **Grant public read access to this bucket**.</span></span>

![Amazon S3 バケットにアクセス許可を設定します。](images/aws-permissions.png) 

<span data-ttu-id="b1c52-129">選択したオプションが反映されるかどうかを確認する概要を確認します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-129">Review the summary to make sure the selected options are reflected.</span></span> <span data-ttu-id="b1c52-130">この手順を完了**作成バケット**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b1c52-130">Click **Create bucket** to finish this step.</span></span> 

## <a name="step-3---upload-uwp-app-package-and-web-pages-to-an-s3-bucket"></a><span data-ttu-id="b1c52-131">手順 3 - UWP アプリ パッケージと web ページを S3 バケットにアップロードします。</span><span class="sxs-lookup"><span data-stu-id="b1c52-131">Step 3 - Upload UWP app package and web pages to an S3 bucket</span></span>

<span data-ttu-id="b1c52-132">Amazon S3 バケットを作成した 1 つは、Amazon S3 ビューで表示することができます。</span><span class="sxs-lookup"><span data-stu-id="b1c52-132">One you have created an Amazon S3 bucket, you will be able to see it in your Amazon S3 view.</span></span> <span data-ttu-id="b1c52-133">このデモ バケットがどのようにの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-133">Here's an example of what our demo bucket looks like:</span></span>

![Amazon S3 バケット ビュー](images/aws-post-create.png)

<span data-ttu-id="b1c52-135">アプリ パッケージと web ページをホストする、Amazon S3 バケットにしたいをアップロードする準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="b1c52-135">We are now ready to upload the app packages and web pages that we would like to host in our Amazon S3 bucket.</span></span> 

<span data-ttu-id="b1c52-136">新しく作成したコンテンツをアップロードするバケットをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b1c52-136">Click on the newly created bucket to upload content.</span></span> <span data-ttu-id="b1c52-137">バケツがまだ何もアップロードされた後に現在空です。</span><span class="sxs-lookup"><span data-stu-id="b1c52-137">The bucket is currently empty since nothing has been uploaded yet.</span></span> <span data-ttu-id="b1c52-138">[ **Upload** ] ボタンをクリックし、アプリ パッケージとをアップロードする web ページのファイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-138">Click the **Upload** button and select the app packages and web page files that you like to upload.</span></span>

> [!NOTE]
> <span data-ttu-id="b1c52-139">利用可能なアプリ パッケージがない場合は、提供された GitHub の[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) リポジトリの一部であるアプリ パッケージを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b1c52-139">You can use the app package that is part of the provided [Starter Project](https://github.com/AppInstaller/MySampleWebApp) repository on GitHub if you don't have an app package available.</span></span> <span data-ttu-id="b1c52-140">パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="b1c52-140">The certificate (MySampleApp.cer) that the package was signed with is also with the sample on GitHub.</span></span> <span data-ttu-id="b1c52-141">アプリをインストールする前に、デバイスに証明書がインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1c52-141">You must have the certificate installed to your device prior to installing the app.</span></span>

![アプリ パッケージをアップロードします。](images/aws-upload-package.png)

<span data-ttu-id="b1c52-143">Amazon S3 バケットを作成するためのアクセス許可と同様に、バケット内のコンテンツも必要**読み取り**、**書き込み**、およびアクセス許可の**このオブジェクトにパブリック読み取りアクセスを許可**します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-143">Similar to the permissions for creating an Amazon S3 bucket, the content in the bucket must also have **read**, **write**, and **Grant public read access to this object(s)** permissions.</span></span>

<span data-ttu-id="b1c52-144">テスト web ページでは、アップロードするがない場合は、[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp/blob/master/MySampleWebApp/default.html)からサンプル html ページ (default.html) を使用できます。</span><span class="sxs-lookup"><span data-stu-id="b1c52-144">If you would like to test uploading a web page, but don't have one, you can use the sample html page (default.html) from the [Starter Project](https://github.com/AppInstaller/MySampleWebApp/blob/master/MySampleWebApp/default.html).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b1c52-145">Web ページをアップロードする前に、web ページで、アプリ パッケージの参照が正しいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-145">Before you upload the web page, confirm that the app package reference in your web page is correct.</span></span> 

<span data-ttu-id="b1c52-146">アプリのパッケージ参照を取得するには、最初に、アプリ パッケージをアップロードし、アプリ パッケージの URL をコピーします。</span><span class="sxs-lookup"><span data-stu-id="b1c52-146">To get the app package reference, upload the app package first and copy the app package URL.</span></span> <span data-ttu-id="b1c52-147">適切なアプリ パッケージのパスを反映するように、html web ページを編集します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-147">Edit the html web page to reflect the correct app package path.</span></span> <span data-ttu-id="b1c52-148">詳細については、コード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b1c52-148">See the code example for more details.</span></span> 

<span data-ttu-id="b1c52-149">アプリ パッケージへのリンクを参照を取得するのにアップロードされたアプリ パッケージ ファイルを選択して、この例のような場合があります。</span><span class="sxs-lookup"><span data-stu-id="b1c52-149">Select the uploaded app package file to get the reference link to the app package, it should be similar to this example:</span></span>

![アップロードされたパッケージのパス](images/aws-package-path.png)

<span data-ttu-id="b1c52-151">**コピー**へのリンク、アプリをパッケージ化し、web ページで、参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-151">**Copy** the link to the app package and add the reference in your web page.</span></span> 

```html
<html>
    <head>
        <meta charset="utf-8" />
        <title> Install My Sample App</title>
    </head>
    <body>
        <a href="ms-appinstaller:?source=https://s3-us-west-2.amazonaws.com/appinstaller-aws-demo/MySampleApp.appxbundle"> Install My Sample App</a>
    </body>
</html>
```
<span data-ttu-id="b1c52-152">Html ファイルは、Amazon S3 バケットにアップロードします。</span><span class="sxs-lookup"><span data-stu-id="b1c52-152">Upload the html file to your Amazon S3 bucket.</span></span> <span data-ttu-id="b1c52-153">**読み取り**し、**書き込み**のアクセスを許可するアクセス許可を設定してください。</span><span class="sxs-lookup"><span data-stu-id="b1c52-153">Remember to set the permissions to allow **read** and **write** access.</span></span>

## <a name="step-4---test"></a><span data-ttu-id="b1c52-154">手順 4: テスト</span><span class="sxs-lookup"><span data-stu-id="b1c52-154">Step 4 - Test</span></span>

<span data-ttu-id="b1c52-155">Web ページ、Amazon S3 バケットには、アップロードは、アップロードされた html ファイルを選択することによって、web ページへのリンクを取得します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-155">Once the web page is uploaded into your Amazon S3 bucket, get the link to the web page by selecting the uploaded html file.</span></span>

<span data-ttu-id="b1c52-156">リンクを使用して、web ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="b1c52-156">Use the link to open the web page.</span></span> <span data-ttu-id="b1c52-157">に、アプリ パッケージと web ページへのパブリック アクセスを許可するアクセス許可を設定します web ページへのリンクを知っているユーザーにアクセスして、アプリ インストーラーを使用して、UWP アプリ パッケージをインストールすることになります。</span><span class="sxs-lookup"><span data-stu-id="b1c52-157">Since we set permissions to grant public access to the app package and web page, anyone with the link to the web page will be able to access it and install your UWP app packages using App Installer.</span></span> <span data-ttu-id="b1c52-158">アプリ インストーラーが Windows 10 プラットフォームの一部であることに注意します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-158">Note that App Installer is part of the Windows 10 platform.</span></span> <span data-ttu-id="b1c52-159">開発者は、任意のコードを追加または機能をアプリ インストーラーの使用を有効にするアプリを追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="b1c52-159">As a developer, you do not need to add any additional code or features to your app to enable the use of App Installer.</span></span> 

## <a name="troubleshooting"></a><span data-ttu-id="b1c52-160">トラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="b1c52-160">Troubleshooting</span></span>

### <a name="app-installer-fails-to-install"></a><span data-ttu-id="b1c52-161">アプリ インストーラーがインストールに失敗します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-161">App Installer fails to install</span></span> 

<span data-ttu-id="b1c52-162">デバイス上でアプリ パッケージが署名されている証明書がインストールされていない場合、アプリのインストールは失敗します。</span><span class="sxs-lookup"><span data-stu-id="b1c52-162">App installation will fail if the certificate that the app package is signed with isn't installed on the device.</span></span> <span data-ttu-id="b1c52-163">これを修正するには、アプリのインストール前に証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1c52-163">To fix this, you will need to install the certificate prior to the installation of the app.</span></span> <span data-ttu-id="b1c52-164">一般配布用アプリ パッケージをホストしている場合、証明機関から証明書を使ってアプリ パッケージに署名するにはお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b1c52-164">If you are hosting an app package for public distribution, it's recommended to sign your app package with a certificate from a certificate authority.</span></span> 


