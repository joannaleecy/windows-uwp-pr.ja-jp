---
title: Xbox One Web サーバー クイックスタート ガイド
author: KevinAsgari
description: Xbox One Web サーバーをセットアップする方法について説明します。
ms.assetid: 2f6831ab-2dea-4f21-bb32-39cb4de4799c
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Web サーバー
ms.localizationpriority: low
ms.openlocfilehash: e979767f127ad146c413a26266443273fe74cee4
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
---
# <a name="xbox-one-web-server-quickstart-guide"></a><span data-ttu-id="7a781-104">Xbox One Web サーバー クイックスタート ガイド</span><span class="sxs-lookup"><span data-stu-id="7a781-104">Xbox One Web Server QuickStart Guide</span></span>

> [!NOTE] 
> <span data-ttu-id="7a781-105">このトピックは、高度なトピックであり、対象パートナーと ID@Xbox メンバーだけが利用できるアクセス許可が制限されたサイトへのアクセスが必要です。</span><span class="sxs-lookup"><span data-stu-id="7a781-105">This topic is an advanced topic, and requires access to permission restricted sites which are only available to managed partners and ID@Xbox members.</span></span>

<span data-ttu-id="7a781-106">Xbox One 開発に使用するシンプルな Web サーバーのセットアップ手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="7a781-106">A step-by-step guide for setting up a simple web server for Xbox One development.</span></span>

-   [<span data-ttu-id="7a781-107">概要</span><span class="sxs-lookup"><span data-stu-id="7a781-107">Introduction</span></span>](#introduction)
-   [<span data-ttu-id="7a781-108">サーバーのセットアップ</span><span class="sxs-lookup"><span data-stu-id="7a781-108">Server setup</span></span>](#server-setup)
-   [<span data-ttu-id="7a781-109">SimpleAuthService サンプル Web サイトの配置用の構築</span><span class="sxs-lookup"><span data-stu-id="7a781-109">Building the SimpleAuthService sample website for deployment</span></span>](#build-sample-website)
-   [<span data-ttu-id="7a781-110">IIS の構成とサンプル Web サイトの実行</span><span class="sxs-lookup"><span data-stu-id="7a781-110">Configuring IIS and running the sample website</span></span>](#configure-sample-website)
-   [<span data-ttu-id="7a781-111">証明書利用者および XSTS トークンのセットアップの検証</span><span class="sxs-lookup"><span data-stu-id="7a781-111">Verifying Relying Party and XSTS token setup</span></span>](#verify-tokens)
-   [<span data-ttu-id="7a781-112">Web サービスの HTTPS の有効化</span><span class="sxs-lookup"><span data-stu-id="7a781-112">Enabling HTTPS for your web service</span></span>](#enable-https)
-   [<span data-ttu-id="7a781-113">FAQ とトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="7a781-113">FAQs and troubleshooting</span></span>](#faqs-and-troubleshooting)


## <a name="introduction"></a><span data-ttu-id="7a781-114">概要</span><span class="sxs-lookup"><span data-stu-id="7a781-114">Introduction</span></span>

<span data-ttu-id="7a781-115">Xbox One および Xbox Live プラットフォームでは、RESTful HTTPS 通信が多用されます。</span><span class="sxs-lookup"><span data-stu-id="7a781-115">Xbox One and the Xbox Live platform rely heavily on the use of RESTful HTTPS communication.</span></span> <span data-ttu-id="7a781-116">また Xbox One では、デベロッパーは、Xbox 360 で必須とされていた Xbox Live サーバー プラットフォーム (XLSP) 接続ではなく、HTTPS を使用した独自のゲーム サーバーをセットアップできます。</span><span class="sxs-lookup"><span data-stu-id="7a781-116">And on Xbox One, developers can set up their game servers over HTTPS rather than an Xbox Live Server Platform (XLSP) connection, which was originally required on Xbox 360.</span></span> <span data-ttu-id="7a781-117">これにより、さらに柔軟で、高速で、信頼性の高いゲーム サービスをタイトルで提供できるようになります。</span><span class="sxs-lookup"><span data-stu-id="7a781-117">This extends titles' ability to provide flexible game services that are quick and reliable.</span></span>

<span data-ttu-id="7a781-118">このクイックスタート ガイドでは、Game Developer Network (GDN) から入手できる Simple Web Server サンプル ("SimpleAuthService") を使用して、動作する HTTP/HTTPS Web サービスを Xbox One タイトルのためにセットアップする方法について学びます。</span><span class="sxs-lookup"><span data-stu-id="7a781-118">In this QuickStart guide, you will learn how to set up a working HTTP/HTTPS web service for your Xbox One title by using the Simple Web Server Sample ("SimpleAuthService") available on Game Developer Network (GDN).</span></span> <span data-ttu-id="7a781-119">ガイドでは、Xbox One タイトルおよびサーバー間の通信に Xbox Secure Token Service (XSTS) トークンおよび HTTPS を使用した検証を開始できるよう、サンプルの Web サービスを実行する Windows サーバーのセットアップについてひととおり説明します。</span><span class="sxs-lookup"><span data-stu-id="7a781-119">The guide walks you through setting up a Windows server running the sample web service so you can start exploring the use of Xbox Secure Token Service (XSTS) tokens and HTTPS for communication between your Xbox One title and your servers.</span></span> <span data-ttu-id="7a781-120">Microsoft Azure を通じて、サーバー用の新しい仮想マシンをすばやく簡単にセットアップする手順についても説明します。</span><span class="sxs-lookup"><span data-stu-id="7a781-120">It also provides the steps to quickly and easily set up a new virtual machine for your server through Microsoft Azure.</span></span>


## <a name="server-setup"></a><span data-ttu-id="7a781-121">サーバーのセットアップ</span><span class="sxs-lookup"><span data-stu-id="7a781-121">Server setup</span></span>

<span data-ttu-id="7a781-122">Xbox One Web サービスを実行するための Relying Party SDK およびサンプルは GDN で提供され、Windows Server 2008 R2 以降で動作します。</span><span class="sxs-lookup"><span data-stu-id="7a781-122">The Relying Party SDK and samples provided on GDN for running an Xbox One web service will work with Windows Server 2008 R2 or later.</span></span> <span data-ttu-id="7a781-123">以下の手順は、Windows Server 2012 R2 を実行するサーバーをセットアップすることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="7a781-123">The instructions that follow are tailored to setting up a server running Windows Server 2012 R2.</span></span> <span data-ttu-id="7a781-124">バージョンが異なっていても必要なセットアップは基本的に同じですが、サーバーのセットアップ機能のいくつかについて、アクセスする場所が若干異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-124">The required setup should be essentially the same across versions, but where to access some of the server setup features might be slightly different.</span></span> <span data-ttu-id="7a781-125">Windows Server ソフトウェアがインストールされた物理マシンをサーバーとして使用するか、または Azure を使用して仮想マシンをセットアップすることができます。</span><span class="sxs-lookup"><span data-stu-id="7a781-125">You can use a physical machine equipped with Windows Server software as your server, or you can set up a virtual machine with Azure.</span></span>

-   [<span data-ttu-id="7a781-126">Azure 仮想マシンのセットアップ</span><span class="sxs-lookup"><span data-stu-id="7a781-126">Azure virtual machine setup</span></span>](#azure-virtual-machine-setup)
-   [<span data-ttu-id="7a781-127">サーバーの役割と機能のセットアップ</span><span class="sxs-lookup"><span data-stu-id="7a781-127">Server roles and features setup</span></span>](#server-roles-and-features-setup)
-   [<span data-ttu-id="7a781-128">証明書のインストール</span><span class="sxs-lookup"><span data-stu-id="7a781-128">Certificate installation</span></span>](#certificate-installation)


### <a name="azure-virtual-machine-setup"></a><span data-ttu-id="7a781-129">Azure 仮想マシンのセットアップ</span><span class="sxs-lookup"><span data-stu-id="7a781-129">Azure virtual machine setup</span></span>

<span data-ttu-id="7a781-130">Azure にアクセスできる場合、開発およびテスト用の仮想サーバーをすばやく簡単にセットアップできます。</span><span class="sxs-lookup"><span data-stu-id="7a781-130">If you have access to Azure, setting up your virtual server for development and testing is straightforward and quick.</span></span> <span data-ttu-id="7a781-131">以下の手順に従うだけです。</span><span class="sxs-lookup"><span data-stu-id="7a781-131">Simply follow these steps:</span></span>

1. <span data-ttu-id="7a781-132">自分のアカウントを使用して [Azure Portal](https://manage.windowsazure.com/) にログインします。</span><span class="sxs-lookup"><span data-stu-id="7a781-132">Log on with your account to the [Azure Portal](https://manage.windowsazure.com/).</span></span>

1. <span data-ttu-id="7a781-133">**[仮想マシン]** を選択して **[+ 新規]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-133">Select **Virtual Machines** and click **+NEW**.</span></span>

1. <span data-ttu-id="7a781-134">**[簡易作成]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-134">Select **QUICK CREATE**.</span></span>

1. <span data-ttu-id="7a781-135">サービスの DNS 名を入力します。</span><span class="sxs-lookup"><span data-stu-id="7a781-135">Enter a DNS name for your service.</span></span> <span data-ttu-id="7a781-136">その名前に ".cloudapp.net" を付け加えたものが、サーバーの HTTP 呼び出しを行うために使用するドメイン名になります。</span><span class="sxs-lookup"><span data-stu-id="7a781-136">With ".cloudapp.net" appended to it, this will be the domain name that you use to make HTTP calls to the server.</span></span>

1. <span data-ttu-id="7a781-137">[Windows Server 2012 R2] と、[A1] のサイズ設定を選択します (他のサイズも選択できますが、サンプルは A1 で正常に動作します)。</span><span class="sxs-lookup"><span data-stu-id="7a781-137">Select Windows Server 2012 R2 and Size setting A1 (you can choose others, but A1 works fine for the sample).</span></span>

1. <span data-ttu-id="7a781-138">仮想マシンへのリモート デスクトップ接続 (RDC) に使用するユーザー名とパスワードを入力します。また、サーバーを実行する地域 (できるだけ実際の所在地に近い地域) を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-138">Enter a username and password that you will use for a Remote Desktop Connection (RDC) into the virtual machine; also select which region you want the server to run in (preferably closer to your physical location).</span></span>

1. <span data-ttu-id="7a781-139">終了するには、**[仮想マシンの作成]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-139">To finish, click **CREATE A VIRTUAL MACHINE**.</span></span>

1. <span data-ttu-id="7a781-140">プロビジョニングが完了するまで少し待ってから、マシンの名前をクリックして Azure 構成設定を開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-140">Wait a few moments for provisioning to complete, and then click the machine's name to open the Azure configuration settings.</span></span>

1. <span data-ttu-id="7a781-141">**[エンドポイント]** タブを選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-141">Select the **ENDPOINTS** tab.</span></span>

1. <span data-ttu-id="7a781-142">**[+ 追加]** をクリックし、**[スタンドアロン エンドポイントの追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-142">Click **+ADD** and select **ADD A STAND-ALONE ENDPOINT**.</span></span>

1. <span data-ttu-id="7a781-143">**[名前]** ドロップダウン リストから **[HTTP (TCP ポート 80)]** を選択し、**[OK]** (またはチェックマーク ボタン) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-143">Select **HTTP (TCP port 80)** from the **NAME** drop-down list and click **OK** (or the checkmark button).</span></span>

| <span data-ttu-id="7a781-144">注</span><span class="sxs-lookup"><span data-stu-id="7a781-144">Note</span></span>                                                                                                                |
|----------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="7a781-145">[DIRECT SERVER RETURN の有効化] オプションをオンにしないでください。オンにすると、Web サービスへの着信トラフィックを実際にブロックする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-145">Do not check the Enable Direct Server Return option, because doing so could actually block incoming traffic to your web service.</span></span> |

1. <span data-ttu-id="7a781-146">HTTP エンドポイントを追加した後で、HTTPS 用の別のエンドポイントを追加します。</span><span class="sxs-lookup"><span data-stu-id="7a781-146">After you have added the HTTP endpoint, add another endpoint for HTTPS:</span></span>
 1.  <span data-ttu-id="7a781-147">**[エンドポイント]** タブを選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-147">Select the **ENDPOINTS** tab.</span></span>
 1.  <span data-ttu-id="7a781-148">**[+ 追加]** をクリックし、**[スタンドアロン エンドポイントの追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-148">Click **+ADD** and select **ADD A STAND-ALONE ENDPOINT**.</span></span>
 1.  <span data-ttu-id="7a781-149">**[名前]** ドロップダウン リストから **[HTTPS (TCP ポート 443)]** を選択し、**[OK]** (またはチェックマーク ボタン) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-149">Select **HTTPS (TCP port 443)** from the **NAME** drop-down list and click **OK** (or the checkmark button).</span></span>

1. <span data-ttu-id="7a781-150">**[ダッシュボード]** タブに移動し、仮想マシンが起動していることを確認し、**[接続]** を選択して .rdp ファイルを開き、RDC を使用してマシンに接続します。</span><span class="sxs-lookup"><span data-stu-id="7a781-150">Go to the **DASHBOARD** tab, make sure that the virtual machine is started, and select **CONNECT** to open the .rdp file and use RDC to connect to the machine.</span></span>
1. <span data-ttu-id="7a781-151">手順 6 で設定したユーザー名とパスワードを使用してマシンにログインします。</span><span class="sxs-lookup"><span data-stu-id="7a781-151">Log in to the machine with the username and password you set up in Step 6.</span></span>

| <span data-ttu-id="7a781-152">注</span><span class="sxs-lookup"><span data-stu-id="7a781-152">Note</span></span>                                                                                                     |
|-----------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="7a781-153">ドメインに参加中のコンピューターを操作している場合、マシンに直接ログインするために "\\選択したユーザー名" を使用することが必要なことがあります。</span><span class="sxs-lookup"><span data-stu-id="7a781-153">If you are on a domain-joined computer, you might need to use "\\UserNameYouChose" to log in to the machine directly.</span></span> |


### <a name="server-roles-and-features-setup"></a><span data-ttu-id="7a781-154">サーバーの役割と機能のセットアップ</span><span class="sxs-lookup"><span data-stu-id="7a781-154">Server roles and features setup</span></span>

<span data-ttu-id="7a781-155">Azure 仮想マシンを実行した後、または Windows Server を物理マシンにインストールした後に、インターネット インフォメーション サービス (IIS) を実行する Web サーバーにマシンを変える必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-155">After you have your Azure virtual machine running or you have installed Windows Server on your physical machine, you need to turn the machine into a web server running Internet Information Services (IIS).</span></span> <span data-ttu-id="7a781-156">これを行うには、役割をサーバーに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-156">To do this you need to add roles to the server:</span></span>

1.  <span data-ttu-id="7a781-157">**スタート** メニューから [サーバー マネージャー] を開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-157">Open the Server Manager from the **Start** menu.</span></span>
2.  <span data-ttu-id="7a781-158">**[管理]** をクリックし、**[役割と機能の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-158">Click **Manage** and select **Add Roles and Features**.</span></span>
3.  <span data-ttu-id="7a781-159">オプションから **[役割ベース]** または **[機能ベース]** のインストールを選択して **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-159">Select **Role-Based** or **Feature-Based** installation from the options and click **Next**.</span></span>
4.  <span data-ttu-id="7a781-160">[サーバー プール] リストからサーバーを選択して **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-160">Highlight your server from the Server Pool list and click **Next**.</span></span>
5.  <span data-ttu-id="7a781-161">[サーバーの役割] リストから、[アプリケーション サーバー] および [Web サーバー (IIS)] を選択して [次へ] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-161">From the Server Roles list, select Application Server and Web Server (IIS) and then click Next.</span></span>
6.  <span data-ttu-id="7a781-162">**[機能]** リストで、**[.NET Framework 4.5 Features]** の下にある **[ASP.NET 4.5]** と、同じグループ内の **[WCF サービス]** の下にある **[HTTP アクティベーション]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-162">On the **Features** list, select **ASP.NET 4.5** under **.NET Framework 4.5 Features** and **HTTP Activation** under **WCF Services** in the same group.</span></span>
7.  <span data-ttu-id="7a781-163">**[次へ]** を数回クリックして、[アプリケーション サーバー] の [役割サービス] 画面を表示します。</span><span class="sxs-lookup"><span data-stu-id="7a781-163">Click **Next** until you are at the Application Server Role Services screen.</span></span>
8.  <span data-ttu-id="7a781-164">**[Web サーバー (IIS) サポート]** をオンにし、ポップアップ表示されたウィンドウで **[機能の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-164">Check **Web Server (IIS) Support** and **Add Features** on the window that pops up.</span></span>
9.  <span data-ttu-id="7a781-165">**[次へ]** を数回クリックして、**[Web サーバーの役割 (IIS) サービス]** 画面を表示します。</span><span class="sxs-lookup"><span data-stu-id="7a781-165">Click **Next** until you are at the **Web Server Role (IIS) Services** screen.</span></span>
10. <span data-ttu-id="7a781-166">すべての既定値がオンになった状態のままで **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-166">Leave all the default values checked and click **Next**.</span></span>
11. <span data-ttu-id="7a781-167">インストールされる項目のリストを確認したら **[インストール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-167">Review the list of items that will be installed and then click **Install**.</span></span>
12. <span data-ttu-id="7a781-168">すべてのソフトウェアおよびサービスのインストールが完了するまで待ちます。</span><span class="sxs-lookup"><span data-stu-id="7a781-168">Wait until the installation of all the software and services is complete.</span></span>


### <a name="certificate-installation"></a><span data-ttu-id="7a781-169">証明書のインストール</span><span class="sxs-lookup"><span data-stu-id="7a781-169">Certificate installation</span></span>

<span data-ttu-id="7a781-170">Xbox Secure Token Service (XSTS) トークンを使用して Xbox One 本体から独自サーバーへの Web サービス呼び出しを行えるようにするには、以下の証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-170">You will need to install the following certificates to enable the Xbox One console to make web service calls to your server with Xbox Secure Token Service (XSTS) tokens:</span></span>

-   [<span data-ttu-id="7a781-171">XSTS 署名証明書</span><span class="sxs-lookup"><span data-stu-id="7a781-171">XSTS Signing certificate</span></span>](https://developer.xboxlive.com/_layouts/xna/download.ashx?file=xsts.auth.xboxlive.com.cer.zip&folder=platform/RelyingParty)
    -   <span data-ttu-id="7a781-172">証明書をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="7a781-172">Download the certificate.</span></span>
    -   <span data-ttu-id="7a781-173">"ローカル コンピューター/個人" および "ローカル コンピューター/信頼されたユーザー" 証明書ストアに証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="7a781-173">Install the certificate to the "Local Computer/Personal" and "Local Computer/Trusted People" certificate stores.</span></span>

| <span data-ttu-id="7a781-174">重要</span><span class="sxs-lookup"><span data-stu-id="7a781-174">Important</span></span>                                                                                                                                                                                                                                                                                                                                                   |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="7a781-175">MMC から web.config ファイルに証明書のサムプリントを直接貼り付けると、サムプリントに非表示の Unicode 文字が追加される場合があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-175">Directly pasting a certificate thumbprint into the web.config file from the MMC can add an extra invisible Unicode character to the thumbprint.</span></span> <span data-ttu-id="7a781-176">この問題とその修正方法の詳細については、「[Certificate thumbprint displayed in MMC certificate snap-in has extra invisible unicode character](http://support.microsoft.com/kb/2023835?wa=wsignin1.0)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7a781-176">For more information about this issue and how to fix it, see [Certificate thumbprint displayed in MMC certificate snap-in has extra invisible unicode character](http://support.microsoft.com/kb/2023835?wa=wsignin1.0).</span></span> |

-   <span data-ttu-id="7a781-177">独自サービスの証明書利用者証明書</span><span class="sxs-lookup"><span data-stu-id="7a781-177">Your service's Relying Party certificate</span></span>
    -   <span data-ttu-id="7a781-178">証明書利用者の証明書の公開キーは、XDP を介してアップロードされます。</span><span class="sxs-lookup"><span data-stu-id="7a781-178">The Relying Party certificate's public key is uploaded through XDP.</span></span> <span data-ttu-id="7a781-179">XDP でサンドボックスに移動し、**[Manage]**、**[Web Services]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-179">In XDP, navigate to your sandbox, click **Manage**, and then click **Web Services**.</span></span> <span data-ttu-id="7a781-180">**[Web Services]** ページで、既存の Web サービスを使用するか、新規作成します。</span><span class="sxs-lookup"><span data-stu-id="7a781-180">On the **Web Services** page, use an existing Web service or create a new one.</span></span> <span data-ttu-id="7a781-181">Web サービスのエンドポイントを作成した後、新しいトークンの定義を追加して、キーをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-181">Once you have created an endpoint for the Web service, you must add a new token definition and then upload the key.</span></span> <span data-ttu-id="7a781-182">XDP 内での Web サービスの設定の詳細については、[XDP のドキュメント](https://developer.xboxlive.com/en-us/xdp/documentation/xdphelp/Pages/AboutWebServiceManagement_SS_xdpdocs.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7a781-182">For more information about setting up Web services in XDP, see the [XDP Documentation](https://developer.xboxlive.com/en-us/xdp/documentation/xdphelp/Pages/AboutWebServiceManagement_SS_xdpdocs.aspx).</span></span>
    -   <span data-ttu-id="7a781-183">"ローカル コンピューター/個人" 証明書ストアに証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="7a781-183">Install the certificate to the "Local Computer/Personal" certificate store.</span></span>

<span data-ttu-id="7a781-184">さらに、独自の Web サービスがユーザーの代わりに Xbox Live サービスと直接やり取りする場合 (代理認証)、次の証明書が必要です。</span><span class="sxs-lookup"><span data-stu-id="7a781-184">Additionally, if your web service will be talking directly to the Xbox Live service on behalf of the user (delegated authentication), you will need the following certificate:</span></span>

### <a name="business-partner-certificate"></a><span data-ttu-id="7a781-185">ビジネス パートナー証明書</span><span class="sxs-lookup"><span data-stu-id="7a781-185">Business Partner certificate</span></span>

<span data-ttu-id="7a781-186">この証明書は、『Xbox One Service Config Workbook』の「ビジネス パートナー証明書」タブに記載されている手順に従って、開発者またはパブリッシャーが作成します。</span><span class="sxs-lookup"><span data-stu-id="7a781-186">You or your publisher create this certificate by following the steps outlined on the Business Partner Certificate tab of the Xbox One Service Config Workbook.</span></span> <span data-ttu-id="7a781-187">ワークブックには、証明書の作成後、証明書についてマイクロソフトに提出する必要がある情報に関するガイダンスも含まれています。</span><span class="sxs-lookup"><span data-stu-id="7a781-187">The workbook also includes guidance regarding the information you'll have to provide to Microsoft about the certificate after you've created it.</span></span>
-   <span data-ttu-id="7a781-188">"ローカル コンピューター/個人" 証明書ストアに証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="7a781-188">Install the certificate to the "Local Computer/Personal" certificate store.</span></span>

| <span data-ttu-id="7a781-189">注</span><span class="sxs-lookup"><span data-stu-id="7a781-189">Note</span></span>                                                                                                                                                                                                                                |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="7a781-190">証明書利用者証明書またはビジネス パートナー証明書をまだ用意していない場合、『Service Config Workbook』の指示に従い、担当の開発者アカウント マネージャーに問い合わせて、証明書をマイクロソフトに提出するための準備を行います。</span><span class="sxs-lookup"><span data-stu-id="7a781-190">If you do not already have a Relying Party or Business Partner certificate, follow the instructions in the Service Config Workbook and contact your developer account manager to make arrangements for submitting the certificates to Microsoft.</span></span> |

<span data-ttu-id="7a781-191">証明書が正しい場所にインストールされていることを確認し、秘密キーへの適切なアクセス許可を付与するための最も簡単な方法は、Microsoft 管理コンソール (mmc.exe) を使用することです。</span><span class="sxs-lookup"><span data-stu-id="7a781-191">The easiest way to ensure that the certificates are installed in the right place and give the proper permissions to the private keys is through the Microsoft Management Console (mmc.exe):</span></span>

1.  <span data-ttu-id="7a781-192">スタート メニューから mmc.exe を開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-192">Open mmc.exe from the Start menu.</span></span>
2.  <span data-ttu-id="7a781-193">**[ファイル]** メニューから **[スナップ インの追加と削除]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-193">From the **File** menu, select **Add/Remove Snap-in**.</span></span>
3.  <span data-ttu-id="7a781-194">**[証明書]** を選択して **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-194">Select **Certificates** and click **Add**.</span></span>
4.  <span data-ttu-id="7a781-195">**[コンピューター アカウント]** を選択して **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-195">Select **Computer Account** and click **Next**.</span></span>
5.  <span data-ttu-id="7a781-196">[ローカル コンピューター] が選択されていることを確認して **[完了]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-196">Ensure that Local computer is selected and click **Finish**.</span></span>
6.  <span data-ttu-id="7a781-197">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-197">Click **OK**.</span></span>
7.  <span data-ttu-id="7a781-198">**[証明書 (ローカル コンピューター)]** リストを展開します。</span><span class="sxs-lookup"><span data-stu-id="7a781-198">Expand the **Certificates (Local Computer)** list.</span></span>
8.  <span data-ttu-id="7a781-199">証明書をインポートするフォルダー (証明書ストア) を開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-199">Open the folder or certificate store where you want to import the certificate.</span></span>
9.  <span data-ttu-id="7a781-200">**[操作]**-&gt;**[すべてのタスク]**-&gt;**[インポート]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-200">Select **Action**-&gt;**All Tasks**-&gt;**Import**.</span></span>
10. <span data-ttu-id="7a781-201">証明書のインポート ウィザードに従って、証明書の .pfx または .cer ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="7a781-201">Follow the Certificate Import Wizard by specifying the .pfx or .cer file for the certificate.</span></span>

| <span data-ttu-id="7a781-202">注</span><span class="sxs-lookup"><span data-stu-id="7a781-202">Note</span></span> |
|------|
| <span data-ttu-id="7a781-203">ファイル ピッカーの既定のファイルの種類は .cer です。</span><span class="sxs-lookup"><span data-stu-id="7a781-203">.cer is the file type by default in the file picker.</span></span> <span data-ttu-id="7a781-204">証明書利用者証明書またはビジネス パートナー証明書をインストールするために、ファイルの種類を **[すべてのファイル (\*.\*)]** に変更することが必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-204">To install your Relying Party or Business Partner certificates, you might need to change the view to **All Files** (\*.\*).</span></span> |

<span data-ttu-id="7a781-205">また、証明書利用者証明書およびビジネス パートナー証明書には、XSTS トークンを処理するために IIS サービスが読み取る必要がある秘密キーが存在します。</span><span class="sxs-lookup"><span data-stu-id="7a781-205">Also, your Relying Party and Business Partner certificates will have private keys that the IIS service needs to read in order to handle XSTS tokens.</span></span> <span data-ttu-id="7a781-206">秘密キーへのアクセスを IIS サービスに許可するには、mmc.exe 内で次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="7a781-206">To give the IIS service access to the private keys, do the following from within mmc.exe:</span></span>

1.  <span data-ttu-id="7a781-207">証明書の名前を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-207">Right-click the name of the certificate.</span></span>
2.  <span data-ttu-id="7a781-208">**[すべてのタスク]**-&gt;**[秘密キーの管理]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-208">Select **All Tasks**-&gt;**Manage Private Keys**.</span></span>
3.  <span data-ttu-id="7a781-209">**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-209">Click **Add**.</span></span>
4.  <span data-ttu-id="7a781-210">\[ローカル コンピューター名\]\\SERVICE アカウントを追加して **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-210">Add the \[Local Computer Name\]\\SERVICE account and click **OK**.</span></span>
5.  <span data-ttu-id="7a781-211">SERVICE アカウントに秘密キーの読み取りアクセスが付与されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-211">Ensure that the SERVICE account has Read access to the private key.</span></span>
6.  <span data-ttu-id="7a781-212">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-212">Click **OK**.</span></span>


## <a name="building-the-simpleauthservice-sample-website-for-deployment-a-namebuild-sample-website"></a><span data-ttu-id="7a781-213">SimpleAuthService サンプル Web サイトの配置用の構築 <a name="build-sample-website"></span><span class="sxs-lookup"><span data-stu-id="7a781-213">Building the SimpleAuthService sample website for deployment <a name="build-sample-website"></span></span>

<span data-ttu-id="7a781-214">サーバーを構成し、IIS が正しくセットアップされていることを確認した後で、サンプルをセットアップしてコンパイルし、Web サーバー上で実行できます。</span><span class="sxs-lookup"><span data-stu-id="7a781-214">After you have configured your server and verified that IIS is set up properly, you can set up the sample and compile it to run on your web server.</span></span>

1.  <span data-ttu-id="7a781-215">Visual Studio 2012 がインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-215">Ensure that you have Visual Studio 2012 installed.</span></span>
2.  <span data-ttu-id="7a781-216">最新の Xbox One Simple Web Server サンプル ("SimpleAuthService") を、GDN の [XDK ソフトウェア ダウンロード](https://developer.xboxlive.com/en-us/platform/development/downloads/Pages/home.aspx) ページからダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="7a781-216">Download the latest Xbox One Simple Web Server Sample ("SimpleAuthService") from the [XDK software downloads](https://developer.xboxlive.com/en-us/platform/development/downloads/Pages/home.aspx) page on GDN.</span></span>
3.  <span data-ttu-id="7a781-217">Xbox One Relying Party SDK を、GDN のソフトウェア ダウンロード ページからダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="7a781-217">Download the Xbox One Relying Party SDK from the software downloads page on GDN.</span></span>
4.  <span data-ttu-id="7a781-218">SimpleAuthService プロジェクトを Visual Studio で開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-218">Open the SimpleAuthService project in Visual Studio.</span></span>
5.  <span data-ttu-id="7a781-219">[JSON Web Token (JWT) 処理用 IdentityModel](https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens.JWT) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="7a781-219">Install the [IdentityModel for handling JSON Web Tokens (JWT)](https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens.JWT).</span></span>
6.  <span data-ttu-id="7a781-220">SimpleAuthService プロジェクトを右クリックして **[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-220">Right-click the SimpleAuthService project and select **Add Reference**.</span></span>
7.  <span data-ttu-id="7a781-221">**[参照]** を選択し、Relying Party SDK から展開した Microsoft.XboxLive.Auth.dll をターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="7a781-221">Select **Browse** and target the Microsoft.XboxLive.Auth.dll that was unpacked from the Relying Party SDK.</span></span>
8.  <span data-ttu-id="7a781-222">**[OK]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-222">Select **OK**.</span></span>
9.  <span data-ttu-id="7a781-223">Web.config ファイルを開き、audienceUris ノードを探します。</span><span class="sxs-lookup"><span data-stu-id="7a781-223">Open the Web.config file and find the audienceUris node.</span></span>
10. <span data-ttu-id="7a781-224">パブリッシャーまたはサービスの証明書利用者名を反映するように <http://Your_Relying_Party.com/> を変更します。</span><span class="sxs-lookup"><span data-stu-id="7a781-224">Change <http://Your_Relying_Party.com/> to reflect your publisher or service's Relying Party name.</span></span>
11. <span data-ttu-id="7a781-225">Web サイトがアクティブであることの確認テストのために、Web.config ファイルで directoryBrowse 設定を true に変更して、ディレクトリの参照を一時的に有効にします。</span><span class="sxs-lookup"><span data-stu-id="7a781-225">For testing to make sure the website is active, enable directory browsing temporarily in the Web.config file by changing the directoryBrowse setting to true.</span></span> <span data-ttu-id="7a781-226">この設定の既定値は false です。</span><span class="sxs-lookup"><span data-stu-id="7a781-226">The default value for this setting is false:</span></span>
12. <span data-ttu-id="7a781-227">ソリューションをコンパイルし、成功を確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-227">Compile the solution to verify that it succeeds.</span></span> <span data-ttu-id="7a781-228">成功した場合、サービスを発行する準備ができています。</span><span class="sxs-lookup"><span data-stu-id="7a781-228">If it does, you are now ready to publish the service.</span></span>
13. <span data-ttu-id="7a781-229">**SimpleAuthService** プロジェクトを右クリックして **[発行]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-229">Right-click the **SimpleAuthService** project and select **Publish**.</span></span>
14. <span data-ttu-id="7a781-230">ドロップダウン リストから [&lt;新しいプロファイル...&gt;] を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-230">From the drop-down list, select &lt;New Profile...&gt;.</span></span>
15. <span data-ttu-id="7a781-231">発行プロファイルに「**SimpleAuthService**」という名前を付けて **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-231">Name your publish profile **SimpleAuthService** and click **Next**.</span></span>
16. <span data-ttu-id="7a781-232">[接続] ページで、ドロップダウン リストから **[ファイル システム]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-232">On the Connection page, select **File System** from the drop-down list.</span></span>
17. <span data-ttu-id="7a781-233">ターゲットの場所を開発用 PC 上の新しいフォルダーに設定して **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-233">Set the target location to a new folder on your development computer and click **Next**.</span></span>
18. <span data-ttu-id="7a781-234">必要な場合にサイトを後からデバッグできるよう、構成に対して **[デバッグ]** を選択し、**[発行]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-234">Select **Debug** for the configuration so that you can debug the site later if needed, then click **Publish**.</span></span>
19. <span data-ttu-id="7a781-235">手順 16 の出力フォルダーに生成されたファイルを、サーバー上の C:\\SampleService\\ フォルダーにコピーします。</span><span class="sxs-lookup"><span data-stu-id="7a781-235">Copy the resulting files in your output folder from Step 16 to the C:\\SampleService\\ folder on your server.</span></span>


## <a name="configuring-iis-and-running-the-sample-website-a-nameconfigure-sample-website"></a><span data-ttu-id="7a781-236">IIS の構成とサンプル Web サイトの実行<a name="configure-sample-website"></span><span class="sxs-lookup"><span data-stu-id="7a781-236">Configuring IIS and running the sample website <a name="configure-sample-website"></span></span>

<span data-ttu-id="7a781-237">本体が Web サーバーと通信できるようにするには、IIS でサービスを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-237">Before the console will be able to talk to your web server, you'll have to configure your service in IIS.</span></span> <span data-ttu-id="7a781-238">単純化のために、SimpleAuthService サンプルを実行するところから始めます。</span><span class="sxs-lookup"><span data-stu-id="7a781-238">For simplicity, first start with running the SimpleAuthService sample.</span></span> <span data-ttu-id="7a781-239">以下の手順により、このサンプル用に IIS を通じて HTTP/HTTPS Web サービスをセットアップできます。</span><span class="sxs-lookup"><span data-stu-id="7a781-239">The following steps will help you set up an HTTP/HTTPS web service through IIS for that sample.</span></span>

1.  <span data-ttu-id="7a781-240">インターネット インフォメーション サービス (IIS) マネージャーを開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-240">Open the Internet Information Services (IIS) Manager.</span></span>
2.  <span data-ttu-id="7a781-241">サーバーのリストを展開して **[アプリケーション プール]** を右クリックし、**[新しいプールの追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-241">Expand your server's list and right-click **Application Pools**; then select **Add New Pool**.</span></span>
3.  <span data-ttu-id="7a781-242">プールに「SampleServicePool」という名前を付け、プールを [.NET Framework 4.0] に設定します。</span><span class="sxs-lookup"><span data-stu-id="7a781-242">Name the pool "SampleServicePool" and set the pool to .NET Framework 4.0.</span></span>
4.  <span data-ttu-id="7a781-243">**[サイト]** リストを展開して **[Default Web Site]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-243">Expand the **Sites** list and select **Default Web Site**.</span></span>
5.  <span data-ttu-id="7a781-244">**[Web サイトの管理]** で、**[停止]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-244">Under **Manage Website**, select **Stop**.</span></span>
6.  <span data-ttu-id="7a781-245">**[サイト]** を右クリックして **[Web サイトの追加...]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-245">Now right-click **Sites** and select **Add Website...**</span></span>
7.  <span data-ttu-id="7a781-246">サイトに「SampleService」という名前を付け、アプリケーション プールを [SampleServicePool] に設定し、物理パスを C:\\SampleService\\ に設定します。</span><span class="sxs-lookup"><span data-stu-id="7a781-246">Name the site "SampleService," set the Application Pool to SampleServicePool, and set the physical path to C:\\SampleService\\.</span></span>
8.  <span data-ttu-id="7a781-247">バインドのポートを既定の 80 のままにして **[OK]** をクリックし、バインドの警告に対して **[はい]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-247">Leave the default binding to port 80, click **OK**, then click **Yes** on the binding warning.</span></span>
9.  <span data-ttu-id="7a781-248">管理者のコマンド プロンプトから次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="7a781-248">Run the following command from an Administrator Command Prompt:</span></span>

           %windir%\Microsoft.Net\Framework64\v4.0.30319\aspnet_regiis.exe -ir

10. <span data-ttu-id="7a781-249">[サイト] で、既定の Web サイトが停止していることを確認し、Web サービスを再起動します。</span><span class="sxs-lookup"><span data-stu-id="7a781-249">Under Sites, make sure that the default web site is stopped and restart your web service.</span></span>

<span data-ttu-id="7a781-250">この時点では、サーバーは HTTP トラフィック用にセットアップされているはずです。</span><span class="sxs-lookup"><span data-stu-id="7a781-250">At this point your server should be set up for HTTP traffic.</span></span> <span data-ttu-id="7a781-251">すべての Xbox One リテール環境で、すべての Web ベース通信には HTTPS が必要ですが、HTTPS を有効にする手順に進む前に、IIS で構成したサイト上で、HTTP のみが有効な状態でシステムが稼働していることを確認することが重要です。</span><span class="sxs-lookup"><span data-stu-id="7a781-251">Before moving on to enable HTTPS—which is required for all web-based communication in any Xbox One retail environment—it is important for you to ensure that the system is working with only HTTP enabled on the site you configured in IIS.</span></span> <span data-ttu-id="7a781-252">これにより、この文書の後のセクションで説明する、HTTPS を有効にしたときに起きる可能性がある問題のトラブルシューティングが行いやすくなります。</span><span class="sxs-lookup"><span data-stu-id="7a781-252">This will help you better troubleshoot issues that might arise when enabling HTTPS, described later in this document.</span></span>

<span data-ttu-id="7a781-253">ここまでの手順で問題がないことを検証するには、`http://localhost/` にアクセスしてみて、配置した SampleService Web サイトのディレクトリ情報が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-253">To verify that everything is working so far, try to access `http://localhost/` and confirm that you see the directory information for your deployed SampleService website.</span></span> <span data-ttu-id="7a781-254">この時点でパブリック インターネットからサーバーにアクセスできる場合、Web.config ファイルで directoryBrowse の設定を更新して false に戻すことによって、ディレクトリの参照を無効にします。</span><span class="sxs-lookup"><span data-stu-id="7a781-254">If your server is accessible through the public Internet at this point, you will want to turn off directory browsing by updating the directoryBrowse setting back to false in your Web.config file.</span></span> <span data-ttu-id="7a781-255">これにより、サービスの不正アクセスおよび検出を防ぎます。</span><span class="sxs-lookup"><span data-stu-id="7a781-255">This will prevent unauthorized access and discovery of your service:</span></span>

      <directoryBrowse enabled=?false?>

<span data-ttu-id="7a781-256">IIS がセットアップされていることが確認できたので、サーバーからいずれかのサービスを呼び出してみて、.json 応答が戻ることを検証します。</span><span class="sxs-lookup"><span data-stu-id="7a781-256">Now that you know that IIS is set up, try calling one of the services from the server and verify that you get a .json response back:</span></span>

      http://localhost/RESTService.svc/messageoftheday


## <a name="verifying-relying-party-and-xsts-token-setup-a-nameverify-tokens"></a><span data-ttu-id="7a781-257">証明書利用者および XSTS トークンのセットアップの検証 <a name="verify-tokens"></span><span class="sxs-lookup"><span data-stu-id="7a781-257">Verifying Relying Party and XSTS token setup <a name="verify-tokens"></span></span>

<span data-ttu-id="7a781-258">配置されたサービスを HTTP を通じてサーバー上で実行できるようになったので、次のステップとして、XSTS トークンを使用して Xbox One 本体から呼び出しを行い、証明書が正しくインストールされていることを検証します。</span><span class="sxs-lookup"><span data-stu-id="7a781-258">Now that you are able to run the deployed service through HTTP on your server, the next step is to make a call from an Xbox One console with an XSTS token and verify that your certificates are installed properly.</span></span>

<span data-ttu-id="7a781-259">Xbox One 用の Web Services コード サンプルを [GDN のサンプル ページ](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx)からダウンロードし、Xbox One XDK がインストールされている開発用 PC に展開します。</span><span class="sxs-lookup"><span data-stu-id="7a781-259">Download the Web Services code sample for Xbox One from the [samples page on GDN](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx) and extract it to your development computer with the Xbox One XDK installed.</span></span>
<span data-ttu-id="7a781-260">\\live\\WebServices\\WebServices110.sln ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-260">Open the \\live\\WebServices\\WebServices110.sln file.</span></span>
<span data-ttu-id="7a781-261">WebServices.cpp ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-261">Open the WebServices.cpp file.</span></span>
<span data-ttu-id="7a781-262">MYSERVERNAME の定義をテスト サーバーのドメイン (例: yourserver.cloudapp.net) に更新します。</span><span class="sxs-lookup"><span data-stu-id="7a781-262">Update the MYSERVERNAME definition to be the domain of your test server (for instance, yourserver.cloudapp.net).</span></span>
<span data-ttu-id="7a781-263">Package.Appxmanifest を開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-263">Open Package.Appxmanifest.</span></span>
<span data-ttu-id="7a781-264">TitleID および PrimaryServiceConfigID の値を、開発タイトルのそれらの値と一致するように更新します。</span><span class="sxs-lookup"><span data-stu-id="7a781-264">Update the TitleID and PrimaryServiceConfigID values to match those of your development title.</span></span>
<span data-ttu-id="7a781-265">Xbox One 開発用本体 (開発キット) が、証明書利用者証明書がセットアップされているサンドボックス内にあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-265">Make sure that your Xbox One development console (devkit) is in the sandbox where your Relying Party certificate is set up.</span></span>
<span data-ttu-id="7a781-266">開発キット上で、自分の開発者アカウントのいずれかを使用してサインインします。</span><span class="sxs-lookup"><span data-stu-id="7a781-266">Sign in with one of your developer accounts on your devkit.</span></span>
<span data-ttu-id="7a781-267">NSAL.json ファイルを開いて更新し、テスト サーバー ホストおよび証明書利用者 (証明書利用者証明書のネットワーク セキュリティ承認リスト (NSAL) 設定をまだセットアップしていない場合) をターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="7a781-267">Open the NSAL.json file and update it to target your test server host and relying party (if you have not already set up your Network Security Authorization List (NSAL) settings for your Relying Party certificate).</span></span>

<span data-ttu-id="7a781-268">NSAL.json ファイルの構成の詳細については、エンターテインメント デベロッパー フォーラムの投稿「How to configure the NSAL.json file」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7a781-268">For more information on configuring the NSAL.json file, review this post on the Entertainment Developer Forums: How to configure the NSAL.json file.</span></span>

1.  <span data-ttu-id="7a781-269">SetNSAL.bat コマンドを実行し、必要な NSAL ファイルを開発キットにコピーします。</span><span class="sxs-lookup"><span data-stu-id="7a781-269">Run the SetNSAL.bat command to copy the needed NSAL files to your devkit.</span></span>

<span data-ttu-id="7a781-270">ソリューションをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="7a781-270">Compile and run the solution.</span></span>
<span data-ttu-id="7a781-271">**Y** ボタンを押して People サービスの呼び出しを行い、クライアント サンプルが正しく実行されていることを検証します。</span><span class="sxs-lookup"><span data-stu-id="7a781-271">Press the **Y** button to make a call to the People Service and verify that the client sample is running properly.</span></span>
<span data-ttu-id="7a781-272">**A** および **X** ボタンを押して、テスト Web サービスの呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="7a781-272">Press the **A** and **X** buttons to make calls to your test web service.</span></span>


## <a name="enabling-https-for-your-web-service-a-nameenable-https"></a><span data-ttu-id="7a781-273">Web サービスの HTTPS の有効化 <a name="enable-https"></span><span class="sxs-lookup"><span data-stu-id="7a781-273">Enabling HTTPS for your web service <a name="enable-https"></span></span>

-   [<span data-ttu-id="7a781-274">自己署名証明書の公開キーをエクスポートする</span><span class="sxs-lookup"><span data-stu-id="7a781-274">Export the self-signed certificate's public key</span></span>](#export-key)
-   [<span data-ttu-id="7a781-275">IIS で Web サービスの HTTPS バインドを作成する</span><span class="sxs-lookup"><span data-stu-id="7a781-275">Create an HTTPS binding for your web service in IIS</span></span>](#create-https-binding)
-   [<span data-ttu-id="7a781-276">自己署名証明書を Xbox One 本体にインストールする</span><span class="sxs-lookup"><span data-stu-id="7a781-276">Install the self-signed certificate on your Xbox One console</span></span>](#install-certificate)

<span data-ttu-id="7a781-277">サーバーがセットアップされ、HTTP 経由で Xbox One 本体とエンド ツー エンドで稼働していることを検証した後で、HTTPS トラフィックを受け入れるようにサーバーのセットアップを更新します。</span><span class="sxs-lookup"><span data-stu-id="7a781-277">After you have verified that the server is set up and working end to end with an Xbox One console over HTTP, update your server setup to accept HTTPS traffic.</span></span> <span data-ttu-id="7a781-278">以前に述べたように、Xbox One では、本体からリテール環境へのすべての Web ベース トラフィックに HTTPS が必須です。</span><span class="sxs-lookup"><span data-stu-id="7a781-278">As previously noted, HTTPS is required for all web-based traffic from the console to any retail environment on Xbox One.</span></span>

<span data-ttu-id="7a781-279">Azure を通じてサーバーをセットアップした場合、サーバーでは既に証明書の準備ができています。</span><span class="sxs-lookup"><span data-stu-id="7a781-279">If you have set up your server through Azure, your server will already have a certificate ready.</span></span> <span data-ttu-id="7a781-280">これを検証するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="7a781-280">To verify this, do the following:</span></span>

1.  <span data-ttu-id="7a781-281">スタート メニューから [インターネット インフォメーション サービス (IIS) マネージャー] を開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-281">Open Internet Information Services (IIS) Manager from the Start menu.</span></span>
2.  <span data-ttu-id="7a781-282">[接続] ページからサーバー名を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-282">Select your server name from the Connections page.</span></span>
3.  <span data-ttu-id="7a781-283">**[サーバー証明書]** を開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-283">Open **Server Certificates**.</span></span>
4.  <span data-ttu-id="7a781-284">サーバーのドメイン (例: server.cloudapp.net) の証明書がリストにあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-284">Verify that there is a certificate with your server's domain (for instance, server.cloudapp.net) in the list.</span></span>
5.  <span data-ttu-id="7a781-285">証明書を選択して **[表示...]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-285">Select the certificate and click **View...**</span></span>
6.  <span data-ttu-id="7a781-286">[証明のパス] を選択し、サーバーの DNS 名 (例: server.cloudapp.net) が入っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-286">Select the Certification Path and verify that it has your server's DNS name (for instance, server.cloudapp.net).</span></span>

<span data-ttu-id="7a781-287">Azure を使用していないか、SSL 通信用の証明書を作成する必要がある場合、次のホワイトペーパーの手順に従って自己署名証明書を作成できます。</span><span class="sxs-lookup"><span data-stu-id="7a781-287">If you are not using Azure or you need to create a certificate for SSL communication, you can create a self-signed certificate by following the instructions in this article:</span></span>

[<span data-ttu-id="7a781-288">方法: 開発中に使う一時的な証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="7a781-288">How to: Create Temporary Certificates for Use During Development</span></span>](http://msdn.microsoft.com/en-us/library/ms733813(v=vs.110).aspx)

<span data-ttu-id="7a781-289">証明書を作成するときは必ず、証明書の名前にサーバーの完全 DNS 名 (server.contoso.com など) を使用します。</span><span class="sxs-lookup"><span data-stu-id="7a781-289">Make sure when creating your certificate that you use the full DNS name of your server (such as server.contoso.com) for the certificate name.</span></span> <span data-ttu-id="7a781-290">そうしないと、証明書の名前とサーバー名が厳密に一致せず、本体は証明書を信頼しません。</span><span class="sxs-lookup"><span data-stu-id="7a781-290">Otherwise, the certificate name and the server name will not match exactly, and the console will not trust the certificate.</span></span> <span data-ttu-id="7a781-291">証明書の準備ができたら、サーバーのセットアップで他の証明書について行ったように、マシンの [個人] 証明書ストアに証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="7a781-291">When the certificate is ready, install it in the machine's Personal certificate store as you did with the other certificates in the server setup.</span></span>


### <a name="export-the-self-signed-certificates-public-key-a-nameexport-key"></a><span data-ttu-id="7a781-292">自己署名証明書の公開キーをエクスポートする <a name="export-key"></span><span class="sxs-lookup"><span data-stu-id="7a781-292">Export the self-signed certificate's public key <a name="export-key"></span></span>

1.  <span data-ttu-id="7a781-293">スタート メニューから mmc.exe を開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-293">Open mmc.exe from the Start menu.</span></span>
2.  <span data-ttu-id="7a781-294">**[ファイル]** メニューから **[スナップ インの追加と削除]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-294">From the **File** menu, select **Add/Remove Snap-in**.</span></span>
3.  <span data-ttu-id="7a781-295">**[証明書]** を選択して **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-295">Select **Certificates** and click **Add**.</span></span>
4.  <span data-ttu-id="7a781-296">**[コンピューター アカウント]** を選択して **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-296">Select **Computer Account** and click **Next**.</span></span>
5.  <span data-ttu-id="7a781-297">[ローカル コンピューター] が選択されていることを確認して **[完了]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-297">Ensure that Local computer is selected and click **Finish**.</span></span>
6.  <span data-ttu-id="7a781-298">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-298">Click **OK**.</span></span>
7.  <span data-ttu-id="7a781-299">[証明書 (ローカル コンピューター)]、[個人]、[証明書] の順にリストを展開します。</span><span class="sxs-lookup"><span data-stu-id="7a781-299">Expand the Certificates (Local Computer)\\Personal\\Certificates list.</span></span>
8.  <span data-ttu-id="7a781-300">以前に作成した (または、マシン上に既に作成されている) 自己署名 SSL 証明書の名前を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-300">Right-click the name of the self-signed SSL certificate that you created earlier (or that was already created on your machine).</span></span>
9.  <span data-ttu-id="7a781-301">**[すべてのタスク]**、**[エクスポート...]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-301">Select **All Tasks** and **Export...**</span></span>
10. <span data-ttu-id="7a781-302">証明書のエクスポート ウィザードで、**[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-302">Click **Next** on the Certificate Export Wizard.</span></span>
11. <span data-ttu-id="7a781-303">**[いいえ、秘密キーをエクスポートしません]** を選択して **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-303">Select **No, do not export the private key** and click **Next**.</span></span>
12. <span data-ttu-id="7a781-304">**[Base-64 encoded X.509 (.CER)]** を選択して **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-304">Select **Base-64 encoded X.509 (.CER)** and click **Next**.</span></span>
13. <span data-ttu-id="7a781-305">サーバーの認識可能な名前を証明書ファイルに付けて **[次へ]** をクリックし、**[完了]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-305">Name the certificate file with a recognizable name for your server, click **Next**, and then click **Finish**.</span></span>
14. <span data-ttu-id="7a781-306">生成された .cer ファイルを開発用コンピューターにコピーします。</span><span class="sxs-lookup"><span data-stu-id="7a781-306">Copy the resulting .cer file to your development computer.</span></span>


### <a name="create-an-https-binding-for-your-web-service-in-iis-a-namecreate-https-binding"></a><span data-ttu-id="7a781-307">IIS で Web サービスの HTTPS バインドを作成する <a name="create-https-binding"></span><span class="sxs-lookup"><span data-stu-id="7a781-307">Create an HTTPS binding for your web service in IIS <a name="create-https-binding"></span></span>

1.  <span data-ttu-id="7a781-308">サービスの Web サイトを IIS マネージャーで開きます。</span><span class="sxs-lookup"><span data-stu-id="7a781-308">Open your service website in IIS Manager.</span></span>
2.  <span data-ttu-id="7a781-309">**[バインド]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-309">Click **Bindings**.</span></span>
3.  <span data-ttu-id="7a781-310">**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-310">Select **Add**.</span></span>
4.  <span data-ttu-id="7a781-311">ドロップダウン リストから **[https]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-311">Select **https** from the drop-down list.</span></span>
5.  <span data-ttu-id="7a781-312">SSL 証明書のドロップダウン リストから自己署名証明書を選択します。</span><span class="sxs-lookup"><span data-stu-id="7a781-312">Select your self-signed certificate from the SSL certificate drop-down list.</span></span>
6.  <span data-ttu-id="7a781-313">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a781-313">Click **OK**.</span></span>

<span data-ttu-id="7a781-314">これで https://localhost を試行することが可能になり、試行すると、Web サイトの証明書に問題があるという警告が Internet Explorer で表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a781-314">You should now be able to try https://localhost, which will give you a warning in Internet Explorer that there is a problem with the website's certificate.</span></span> <span data-ttu-id="7a781-315">その理由は単に、証明書が自己署名であり、信頼された証明機関 (CA) にチェーンがつながらないためです。</span><span class="sxs-lookup"><span data-stu-id="7a781-315">This is only because the certificate is self-signed and does not chain up to a trusted certification authority (CA).</span></span> <span data-ttu-id="7a781-316">タイトルをリリースする前に、信頼された CA に依頼して、独自ドメイン用の真正な証明書を取得し、Web サービスにセットアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-316">Before you ship your title, you will have to set up your web service with a real certificate for your domain that is requested through a trusted CA.</span></span>

<span data-ttu-id="7a781-317">https://localhost/RESTService.svc/messageoftheday にアクセスしようとすると、エラー メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a781-317">If you try to go to https://localhost/RESTService.svc/messageoftheday you will get an error message.</span></span> <span data-ttu-id="7a781-318">その理由は、HTTPS 要求をサポートするようにサービスの Web.config ファイルを更新する必要もあるためです。</span><span class="sxs-lookup"><span data-stu-id="7a781-318">The reason is that you will also have to update the Web.config file for the service to support HTTPS requests.</span></span> <span data-ttu-id="7a781-319">それを行うには、次の設定のコメントを解除して、Web.config ファイルを保存し、リンクを再試行します。</span><span class="sxs-lookup"><span data-stu-id="7a781-319">To do so, uncomment the following setting, save the Web.config file, and try the link again:</span></span>

      <!-- Uncomment this block to enable HTTPS

      <endpoint behaviorConfiguration="webHttpBehavior" binding="webHttpBinding"
      bindingConfiguration="webHttpsBindingConfig" contract="SimpleAuthService.IRESTService" /> -->

<span data-ttu-id="7a781-320">インターネット ブラウザーを使用して HTTPS 経由でサービスに到達できるようになったので、最後のステップとして、開発キットから HTTPS 経由でサービス呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="7a781-320">Now that you are able to reach your service over HTTPS through an Internet browser, the last step is getting your devkit to make the service call over HTTPS.</span></span> <span data-ttu-id="7a781-321">信頼された CA にチェーンがつながる SSL 証明書をサーバーが使用している場合、追加の手順なしで Web サービスの HTTPS バージョンをそのまま呼び出すことができるはずです。</span><span class="sxs-lookup"><span data-stu-id="7a781-321">If your server is using an SSL certificate that chains up to a trusted CA, then you should be able to just call the HTTPS version of your web service without any additional steps.</span></span> <span data-ttu-id="7a781-322">または、前に説明したように SSL 通信用の自己署名証明書を作成した場合、証明書を取得して本体にインストールする必要があります。そうしないと、本体は、HTTPS 経由で通信しようとしているサーバーを信頼しません。</span><span class="sxs-lookup"><span data-stu-id="7a781-322">Alternatively, if you created a self-signed certificate for SSL communication as outlined above, you will need to get the certificate and install it on your console; otherwise the console will not trust the server it is trying to talk to over HTTPS.</span></span> <span data-ttu-id="7a781-323">また、本体をシャットダウンすると一時的な証明書がすべて削除されるため、本体を再起動するたびに証明書を再インストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a781-323">And because the console wipes all temporary certificates when it is shut down, you'll have to reinstall the certificate every time you restart the console.</span></span>


### <a name="install-the-self-signed-certificate-on-your-xbox-one-console-a-nameinstall-certificate"></a><span data-ttu-id="7a781-324">自己署名証明書を Xbox One 本体にインストールする <a name="install-certificate"></span><span class="sxs-lookup"><span data-stu-id="7a781-324">Install the self-signed certificate on your Xbox One console <a name="install-certificate"></span></span>

1.  <span data-ttu-id="7a781-325">Xbox One XDK コマンド プロンプトを開き、サーバーの SSL 証明書を保存した場所に移動します。</span><span class="sxs-lookup"><span data-stu-id="7a781-325">Open up an Xbox One XDK Command Prompt and navigate to where you saved your server's SSL certificate.</span></span>
2.  <span data-ttu-id="7a781-326">以下のコマンドを実行します (証明書をすばやく簡単に再インストールするには、.bat ファイルを使用します)。</span><span class="sxs-lookup"><span data-stu-id="7a781-326">Run the following commands (using a .bat file is an easy way to quickly reinstall the certificate):</span></span>

        xbcp "%DurangoXDK%\bin\setproxy.exe" xd:\
        xbcp "%DurangoXDK%\bin\certmgr.exe" xd:\
        xbcp [YourSSLCert].cer xd:\
        xbrun /o d:\certmgr.exe -add -all d:\[YourSSLCert].cer -s -r localmachine root

<span data-ttu-id="7a781-327">最後のステップでは、単に現在の HTTP 定義をコピーしてプロトコルの値を *HTTPS* に更新することによって、NSAL.json ファイルにサービスの HTTPS 定義を含めます。</span><span class="sxs-lookup"><span data-stu-id="7a781-327">The final step is to update your NSAL.json file to include the HTTPS definition for your service by simply copying the current HTTP definition and updating the protocol value to *HTTPS*.</span></span>


## <a name="faqs-and-troubleshooting"></a><span data-ttu-id="7a781-328">FAQ とトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="7a781-328">FAQs and troubleshooting</span></span>

 **<span data-ttu-id="7a781-329">クライアント側サンプルがサービスを呼び出そうとすると、GetTokenAndSignatureAsync() からエラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="7a781-329">When the client-side sample tries to call our service it is getting errors from GetTokenAndSignatureAsync().</span></span> <span data-ttu-id="7a781-330">どうすればこれらのエラーを解決できますか。</span><span class="sxs-lookup"><span data-stu-id="7a781-330">How can I resolve these errors?</span></span>**   
<span data-ttu-id="7a781-331">本体から返される、NSAL またはトークン関連のエラーの大半は 0x87DD\* で始まります。</span><span class="sxs-lookup"><span data-stu-id="7a781-331">Most of the NSAL or token-related errors from the console start with 0x87DD\*.</span></span> <span data-ttu-id="7a781-332">[XboxLive.com のこのフォーラム投稿](https://forums.xboxlive.com/AnswerPage.aspx?qid=10ef67c1-db3a-4f29-b4bf-3eacd77313cb&tgt=1)で、最も起こりやすいエラーの一覧とそれらの解決方法が示されています。</span><span class="sxs-lookup"><span data-stu-id="7a781-332">[This Forum post on XboxLive.com](https://forums.xboxlive.com/AnswerPage.aspx?qid=10ef67c1-db3a-4f29-b4bf-3eacd77313cb&tgt=1) provides a list of the most common errors and how to resolve them.</span></span>

 **<span data-ttu-id="7a781-333">Web サービスの URL にアクセスしようとすると HTTP エラー 404.3 が返されます。</span><span class="sxs-lookup"><span data-stu-id="7a781-333">When trying to access a web service URL I'm getting HTTP error 404.3.</span></span> <span data-ttu-id="7a781-334">この原因は何ですか。どうすれば修正できますか。</span><span class="sxs-lookup"><span data-stu-id="7a781-334">What is causing this and how do I fix it?</span></span>**   
<span data-ttu-id="7a781-335">サーバーにサンプルを最初にセットアップしようとするときの 404 エラーは通常、.NET 3.5、4.5、または ASP.NET のコンポーネントが不足していることを示します。</span><span class="sxs-lookup"><span data-stu-id="7a781-335">When initially trying to set up your server with the sample, a 404 error usually indicates that there is a missing component to .NET 3.5, 4.5, or ASP.NET.</span></span> <span data-ttu-id="7a781-336">役割と機能の追加ウィザードで、以下のサービスの役割 (機能) が有効になっていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="7a781-336">Make sure that the following Service roles (Features) are enabled in the Add Roles and Features Wizard:</span></span>

-   <span data-ttu-id="7a781-337">.NET 3.5 の HTTP アクティベーション (Windows Server 2008)</span><span class="sxs-lookup"><span data-stu-id="7a781-337">HTTP Activation under .NET 3.5 (Windows Server 2008)</span></span>
-   <span data-ttu-id="7a781-338">.NET 4.5 の ASP.NET 4.5</span><span class="sxs-lookup"><span data-stu-id="7a781-338">ASP.NET 4.5 under .NET 4.5</span></span>
-   <span data-ttu-id="7a781-339">.NET 4.5 / WCF サービスの HTTP アクティベーション</span><span class="sxs-lookup"><span data-stu-id="7a781-339">HTTP Activation under .NET 4.5 / WCF Services</span></span>

<span data-ttu-id="7a781-340">Windows Server 2008 R2 上で実行している場合、管理者のコマンド プロンプトから次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="7a781-340">If you are running on Windows Server 2008 R2, run the following command from an Administrator Command Prompt:</span></span>

      %windir%\"Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ servicemodelreg" –i

 **<span data-ttu-id="7a781-341">Windows Server 2008 R2 – 構成エラー: セクション宣言が見つからないため、構成セクション "system.serviceModel" を読み取れません。</span><span class="sxs-lookup"><span data-stu-id="7a781-341">Windows Server 2008 R2 – Config Error: The configuration section "system.serviceModel" cannot be read because it is missing a section declaration.</span></span>**   
<span data-ttu-id="7a781-342">.NET 3.5 をインストールします。</span><span class="sxs-lookup"><span data-stu-id="7a781-342">Install .NET 3.5.</span></span> <span data-ttu-id="7a781-343">詳細については、[こちらの MSDN の技術情報](http://blogs.msdn.com/b/sqlblog/archive/2010/01/08/how-to-install-net-framework-3-5-sp1-on-windows-server-2008-r2-environments.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7a781-343">See [This article on MSDN](http://blogs.msdn.com/b/sqlblog/archive/2010/01/08/how-to-install-net-framework-3-5-sp1-on-windows-server-2008-r2-environments.aspx) for more information.</span></span>

 **<span data-ttu-id="7a781-344">Windows Server 2008 R2 – HTTP エラー 500.21: ハンドラー "svc-Integrated" のモジュール リストにあるモジュール "ManagedPipelineHandler" が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="7a781-344">Windows Server 2008 R2 – HTTP Error 500.21: Handler "svc-Integrated" has a bad module "ManagedPipelineHandler" in its module list.</span></span>**   
<span data-ttu-id="7a781-345">管理者のコマンド プロンプトから、次を実行します。</span><span class="sxs-lookup"><span data-stu-id="7a781-345">From an Administrator Command Prompt, run:</span></span>

    %windir%\Microsoft.NET\Framework\v4.0.21006\aspnet_regiis.exe –i

 **<span data-ttu-id="7a781-346">HTTP エラー 500.19 および 0x80070021 とは何ですか。</span><span class="sxs-lookup"><span data-stu-id="7a781-346">What is HTTP Error 500.19 and 0x80070021?</span></span>**   
<span data-ttu-id="7a781-347">サーバー上の handlers セクションが現在ロックされています。</span><span class="sxs-lookup"><span data-stu-id="7a781-347">The handlers section on your server is currently locked.</span></span> <span data-ttu-id="7a781-348">管理者のコマンド プロンプトから次のコマンドを実行すると、問題が修正されるはずです。</span><span class="sxs-lookup"><span data-stu-id="7a781-348">Running the following command from an Administrator Command Prompt should fix it:</span></span>

    %windir%\system32\inetsrv\appcmd.exe unlock config "Default Web Site/exchange" -section:handlers -commitpath:apphost

 **<span data-ttu-id="7a781-349">HTTPS 経由で本体から Web サービスを呼び出そうとすると HRESULT エラー 0x800c0019 が返されます。</span><span class="sxs-lookup"><span data-stu-id="7a781-349">I get HRESULT Error 0x800c0019 when trying to call my web service over HTTPS from the console.</span></span> <span data-ttu-id="7a781-350">どうしてでしょうか。</span><span class="sxs-lookup"><span data-stu-id="7a781-350">Why?</span></span>**   
<span data-ttu-id="7a781-351">これは、HTTPS トラフィックに使用した SSL 証明書が本体によって信頼されていないか、サーバー上で正しく構成されていないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="7a781-351">This means that the SSL certificate you used for HTTPS traffic is not trusted by the console or has been misconfigured on the server.</span></span> <span data-ttu-id="7a781-352">まず、サーバーの SSL 用に作成および使用した証明書について、エクスポートした .cer ファイルをダブルクリックしたときに、サーバーの完全ドメイン名が [発行先:] の値に入っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-352">First, make sure that the certificate you created and used for SSL on your server has the full domain name of your server in the Issued to: value when you double-click on the exported .cer file.</span></span> <span data-ttu-id="7a781-353">たとえば、[発行先: Server.Contoso.com] のようになります。次に、.cer ファイルをエクスポートしたときに Base-64 オプションを選択したことを確認します。</span><span class="sxs-lookup"><span data-stu-id="7a781-353">Example: Issued to: Server.Contoso.com. Next, make sure that when you exported the .cer file you selected the Base-64 option.</span></span> <span data-ttu-id="7a781-354">最後に、IIS を開き、別の証明書ではなくエクスポートした証明書を HTTPS ポート (443) で使用していることを確認できます。</span><span class="sxs-lookup"><span data-stu-id="7a781-354">Finally, you can look in IIS to make sure that the HTTPS port (443) is using the certificate that you exported and not another one.</span></span> <span data-ttu-id="7a781-355">また、証明書を開発キットに確実に再インストールします。</span><span class="sxs-lookup"><span data-stu-id="7a781-355">Also make sure to reinstall the certificate on your devkit.</span></span>
