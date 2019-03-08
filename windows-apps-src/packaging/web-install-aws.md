---
title: Web インストールのための UWP アプリ パッケージの AWS へのホスト
description: アプリ インストーラー アプリを使用してアプリのインストールを検証する AWS web サーバーを設定するためのチュートリアル
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10、Windows 10 では、UWP、関連する設定、省略可能なパッケージ、AWS のアプリ インストーラー、AppInstaller、サイドローディングを行う
ms.localizationpriority: medium
ms.openlocfilehash: 53fe01a1c1a825377e886e042b4eef3868cbf5eb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628057"
---
# <a name="hosting-uwp-app-packages-on-aws-for-web-install"></a><span data-ttu-id="8969d-104">Web インストールのための UWP アプリ パッケージの AWS へのホスト</span><span class="sxs-lookup"><span data-stu-id="8969d-104">Hosting UWP app packages on AWS for web install</span></span>

<span data-ttu-id="8969d-105">アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。</span><span class="sxs-lookup"><span data-stu-id="8969d-105">The App Installer app allows developers and IT Pros to distribute Windows 10 apps by hosting them on their own Content Delivery Network (CDN).</span></span> <span data-ttu-id="8969d-106">これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="8969d-106">This is useful for enterprises that don't want or need to publish their apps to the Microsoft Store, but still want to take advantage of the Windows 10 packaging and deployment platform.</span></span>

<span data-ttu-id="8969d-107">このトピックでは、UWP アプリのパッケージのホストを Amazon Web Services (AWS) の web サイトとアプリのインストーラー アプリを使用して、アプリ パッケージをインストールする方法を構成する手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="8969d-107">This topic outlines the steps to configure an Amazon Web Services (AWS) website to host UWP app packages, and how to use the App Installer app to install the app packages.</span></span>

## <a name="setup"></a><span data-ttu-id="8969d-108">セットアップ</span><span class="sxs-lookup"><span data-stu-id="8969d-108">Setup</span></span>

<span data-ttu-id="8969d-109">このチュートリアに正常に従うには、以下が必要になります。</span><span class="sxs-lookup"><span data-stu-id="8969d-109">To successfully follow this tutorial, you will need the following:</span></span>
 
1. <span data-ttu-id="8969d-110">AWS サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="8969d-110">AWS subscription</span></span> 
2. <span data-ttu-id="8969d-111">Web ページ</span><span class="sxs-lookup"><span data-stu-id="8969d-111">Web page</span></span>
3. <span data-ttu-id="8969d-112">UWP アプリ パッケージ - 配布するアプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="8969d-112">UWP app package - The app package that you will distribute</span></span>

<span data-ttu-id="8969d-113">省略可能: [スタート プロジェクト](https://github.com/AppInstaller/MySampleWebApp)GitHub でします。</span><span class="sxs-lookup"><span data-stu-id="8969d-113">Optional: [Starter Project](https://github.com/AppInstaller/MySampleWebApp) on GitHub.</span></span> <span data-ttu-id="8969d-114">これは、使用するアプリ パッケージまたは Web ページがないが、この機能を使用する方法を確認したい場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="8969d-114">This is helpful if you don't an app package or web page to work with, but would still like to learn how to use this feature.</span></span>

<span data-ttu-id="8969d-115">このチュートリアルは、セットアップの web ページと AWS のパッケージをホストする方法が変わります。</span><span class="sxs-lookup"><span data-stu-id="8969d-115">This tutorial will go over how to setup a web page and host packages on AWS.</span></span> <span data-ttu-id="8969d-116">AWS サブスクリプションが必要になります。</span><span class="sxs-lookup"><span data-stu-id="8969d-116">This will require an AWS subscription.</span></span> <span data-ttu-id="8969d-117">によって、スケール操作のでは、このチュートリアルに従うの無料のメンバーシップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8969d-117">Depending on the scale of your operation, you can use their free membership to follow this tutorial.</span></span> 

## <a name="step-1---aws-membership"></a><span data-ttu-id="8969d-118">手順 1 - AWS メンバーシップ</span><span class="sxs-lookup"><span data-stu-id="8969d-118">Step 1 - AWS membership</span></span>
<span data-ttu-id="8969d-119">AWS のメンバーシップを取得するには、次を参照してください。、 [AWS アカウントの詳細ページ](https://aws.amazon.com/free/)します。</span><span class="sxs-lookup"><span data-stu-id="8969d-119">To get an AWS membership, visit the [AWS account details page](https://aws.amazon.com/free/).</span></span> <span data-ttu-id="8969d-120">このチュートリアルの目的上、無料のメンバーシップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8969d-120">For the purposes of this tutorial, you can use a free membership.</span></span>

## <a name="step-2---create-an-amazon-s3-bucket"></a><span data-ttu-id="8969d-121">手順 2 - Amazon S3 バケットの作成</span><span class="sxs-lookup"><span data-stu-id="8969d-121">Step 2 - Create an Amazon S3 bucket</span></span>

<span data-ttu-id="8969d-122">Amazon Simple Storage Service (S3) では、収集、保存、およびデータの分析のための製品、AWS です。</span><span class="sxs-lookup"><span data-stu-id="8969d-122">Amazon Simple Storage Service (S3) is an AWS offering for collecting, storing and analyzing data.</span></span> <span data-ttu-id="8969d-123">S3 バケットは、UWP アプリのパッケージをホストおよび配布用の web ページに便利な方法です。</span><span class="sxs-lookup"><span data-stu-id="8969d-123">S3 buckets are a convenient way to host UWP app packages and web pages for distribution.</span></span> 

<span data-ttu-id="8969d-124">ログイン後 AWS の資格情報を `Services`検索`S3`します。</span><span class="sxs-lookup"><span data-stu-id="8969d-124">After logging in to AWS with your credentials, under `Services` find `S3`.</span></span> 

<span data-ttu-id="8969d-125">選択**を作成するバケット**を入力し、**バケット名**web サイトの。</span><span class="sxs-lookup"><span data-stu-id="8969d-125">Select **Create bucket**, and enter a **Bucket name** for your website.</span></span> <span data-ttu-id="8969d-126">プロパティとアクセス許可を設定するためのダイアログ プロンプトに従います。</span><span class="sxs-lookup"><span data-stu-id="8969d-126">Follow the dialog prompts for setting properties and permissions.</span></span> <span data-ttu-id="8969d-127">UWP アプリは、web サイトから配布できることを確認するには、有効にする**読み取り**と**書き込み**アクセス許可を選択して、バケット**このバケットにパブリックの読み取りアクセス権を付与**.</span><span class="sxs-lookup"><span data-stu-id="8969d-127">To ensure that your UWP app can be distributed from your website, enable **Read** and **Write** permissions for your bucket and select **Grant public read access to this bucket**.</span></span>

![Amazon S3 バケットに権限を設定します。](images/aws-permissions.png) 

<span data-ttu-id="8969d-129">選択したオプションが反映されるかどうかを確認する概要を確認します。</span><span class="sxs-lookup"><span data-stu-id="8969d-129">Review the summary to make sure the selected options are reflected.</span></span> <span data-ttu-id="8969d-130">クリックして**作成バケット**この手順を完了します。</span><span class="sxs-lookup"><span data-stu-id="8969d-130">Click **Create bucket** to finish this step.</span></span> 

## <a name="step-3---upload-uwp-app-package-and-web-pages-to-an-s3-bucket"></a><span data-ttu-id="8969d-131">手順 3 - UWP アプリのパッケージと web ページ、S3 バケットをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="8969d-131">Step 3 - Upload UWP app package and web pages to an S3 bucket</span></span>

<span data-ttu-id="8969d-132">Amazon S3 バケットを作成した 1 つ、Amazon S3 ビューで表示することができます。</span><span class="sxs-lookup"><span data-stu-id="8969d-132">One you have created an Amazon S3 bucket, you will be able to see it in your Amazon S3 view.</span></span> <span data-ttu-id="8969d-133">次のように、デモのバケットの外観の例に示します。</span><span class="sxs-lookup"><span data-stu-id="8969d-133">Here's an example of what our demo bucket looks like:</span></span>

![Amazon S3 バケットのビュー](images/aws-post-create.png)

<span data-ttu-id="8969d-135">これで、アプリ パッケージと、Amazon S3 バケットでホストするたい web ページをアップロードする準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="8969d-135">We are now ready to upload the app packages and web pages that we would like to host in our Amazon S3 bucket.</span></span> 

<span data-ttu-id="8969d-136">コンテンツのアップロードを新しく作成したバケットをクリックします。</span><span class="sxs-lookup"><span data-stu-id="8969d-136">Click on the newly created bucket to upload content.</span></span> <span data-ttu-id="8969d-137">まだ何もアップロードされているため、バケットは現在空です。</span><span class="sxs-lookup"><span data-stu-id="8969d-137">The bucket is currently empty since nothing has been uploaded yet.</span></span> <span data-ttu-id="8969d-138">をクリックして、**アップロード**ボタンをクリックし、アプリ パッケージとアップロードしたい web ページのファイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="8969d-138">Click the **Upload** button and select the app packages and web page files that you like to upload.</span></span>

> [!NOTE]
> <span data-ttu-id="8969d-139">利用可能なアプリ パッケージがない場合は、提供された GitHub の[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) リポジトリの一部であるアプリ パッケージを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8969d-139">You can use the app package that is part of the provided [Starter Project](https://github.com/AppInstaller/MySampleWebApp) repository on GitHub if you don't have an app package available.</span></span> <span data-ttu-id="8969d-140">パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="8969d-140">The certificate (MySampleApp.cer) that the package was signed with is also with the sample on GitHub.</span></span> <span data-ttu-id="8969d-141">アプリをインストールする前に、デバイスに証明書がインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="8969d-141">You must have the certificate installed to your device prior to installing the app.</span></span>

![アプリ パッケージをアップロードします。](images/aws-upload-package.png)

<span data-ttu-id="8969d-143">Amazon S3 バケットを作成するためのアクセス許可と同様に、バケット内のコンテンツも必要**読み取り**、**書き込み**、および**このオブジェクトにパブリックの読み取りアクセス権を付与**アクセス許可。</span><span class="sxs-lookup"><span data-stu-id="8969d-143">Similar to the permissions for creating an Amazon S3 bucket, the content in the bucket must also have **read**, **write**, and **Grant public read access to this object(s)** permissions.</span></span>

<span data-ttu-id="8969d-144">Web ページでは、アップロードをテストするには、お持ちでない場合からサンプル html ページ (default.html) を使用することができます、[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp/blob/master/MySampleWebApp/default.html)します。</span><span class="sxs-lookup"><span data-stu-id="8969d-144">If you would like to test uploading a web page, but don't have one, you can use the sample html page (default.html) from the [Starter Project](https://github.com/AppInstaller/MySampleWebApp/blob/master/MySampleWebApp/default.html).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8969d-145">Web ページをアップロードする前に、web ページでアプリのパッケージ参照が正しいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="8969d-145">Before you upload the web page, confirm that the app package reference in your web page is correct.</span></span> 

<span data-ttu-id="8969d-146">アプリ パッケージの参照を取得するには、最初に、アプリ パッケージをアップロードし、アプリ パッケージの URL をコピーします。</span><span class="sxs-lookup"><span data-stu-id="8969d-146">To get the app package reference, upload the app package first and copy the app package URL.</span></span> <span data-ttu-id="8969d-147">正しいアプリ パッケージのパスを反映するように html web ページを編集します。</span><span class="sxs-lookup"><span data-stu-id="8969d-147">Edit the html web page to reflect the correct app package path.</span></span> <span data-ttu-id="8969d-148">詳細については、コード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8969d-148">See the code example for more details.</span></span> 

<span data-ttu-id="8969d-149">アプリ パッケージへの参照リンクを取得するアップロードされたアプリ パッケージ ファイルを選択して、この例のような場合があります。</span><span class="sxs-lookup"><span data-stu-id="8969d-149">Select the uploaded app package file to get the reference link to the app package, it should be similar to this example:</span></span>

![アップロードされたパッケージのパス](images/aws-package-path.png)

<span data-ttu-id="8969d-151">**コピー**アプリへのリンクをパッケージ化し、web ページで、参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="8969d-151">**Copy** the link to the app package and add the reference in your web page.</span></span> 

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
<span data-ttu-id="8969d-152">Amazon S3 バケットには、html ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="8969d-152">Upload the html file to your Amazon S3 bucket.</span></span> <span data-ttu-id="8969d-153">許可するアクセス許可を設定してください**読み取り**と**書き込み**アクセスします。</span><span class="sxs-lookup"><span data-stu-id="8969d-153">Remember to set the permissions to allow **read** and **write** access.</span></span>

## <a name="step-4---test"></a><span data-ttu-id="8969d-154">手順 4 - テスト</span><span class="sxs-lookup"><span data-stu-id="8969d-154">Step 4 - Test</span></span>

<span data-ttu-id="8969d-155">Web ページは、Amazon S3 バケットに、アップロードは、アップロードされた html ファイルを選択して web ページへのリンクを取得します。</span><span class="sxs-lookup"><span data-stu-id="8969d-155">Once the web page is uploaded into your Amazon S3 bucket, get the link to the web page by selecting the uploaded html file.</span></span>

<span data-ttu-id="8969d-156">リンクを使用して、web ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="8969d-156">Use the link to open the web page.</span></span> <span data-ttu-id="8969d-157">アプリ パッケージと web ページへのパブリック アクセスを付与するアクセス許可を設定しますのでは、アクセスして、アプリのインストーラーを使用して、UWP アプリのパッケージをインストールする web ページへのリンクを持つユーザーはできます。</span><span class="sxs-lookup"><span data-stu-id="8969d-157">Since we set permissions to grant public access to the app package and web page, anyone with the link to the web page will be able to access it and install your UWP app packages using App Installer.</span></span> <span data-ttu-id="8969d-158">アプリのインストーラーは、Windows 10 プラットフォームの一部であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="8969d-158">Note that App Installer is part of the Windows 10 platform.</span></span> <span data-ttu-id="8969d-159">開発者は、アプリのインストーラーの使用を有効にするアプリにコードを追加または機能を追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8969d-159">As a developer, you do not need to add any additional code or features to your app to enable the use of App Installer.</span></span> 

## <a name="troubleshooting"></a><span data-ttu-id="8969d-160">トラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="8969d-160">Troubleshooting</span></span>

### <a name="app-installer-fails-to-install"></a><span data-ttu-id="8969d-161">アプリのインストーラーがインストールに失敗します。</span><span class="sxs-lookup"><span data-stu-id="8969d-161">App Installer fails to install</span></span> 

<span data-ttu-id="8969d-162">デバイス上でアプリ パッケージが署名された証明書がインストールされていない場合、アプリのインストールは失敗します。</span><span class="sxs-lookup"><span data-stu-id="8969d-162">App installation will fail if the certificate that the app package is signed with isn't installed on the device.</span></span> <span data-ttu-id="8969d-163">これを修正するには、アプリのインストール前に証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8969d-163">To fix this, you will need to install the certificate prior to the installation of the app.</span></span> <span data-ttu-id="8969d-164">パブリック配布用アプリケーション パッケージをホストしている場合、証明機関から証明書で、アプリ パッケージに署名するがお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8969d-164">If you are hosting an app package for public distribution, it's recommended to sign your app package with a certificate from a certificate authority.</span></span> 


