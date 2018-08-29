---
title: アプリ間での証明書の共有
description: ユーザー ID とパスワードの組み合わせよりも安全な認証を必要とするユニバーサル Windows プラットフォーム (UWP) アプリでは、証明書を認証に使うことができます。
ms.assetid: 159BA284-9FD4-441A-BB45-A00E36A386F9
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 863658438ce53f2c74faddb845a7d17c6ec3130c
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2911897"
---
# <a name="share-certificates-between-apps"></a><span data-ttu-id="90e4f-104">アプリ間での証明書の共有</span><span class="sxs-lookup"><span data-stu-id="90e4f-104">Share certificates between apps</span></span>




<span data-ttu-id="90e4f-105">ユーザー ID とパスワードの組み合わせよりも安全な認証を必要とするユニバーサル Windows プラットフォーム (UWP) アプリでは、証明書を認証に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-105">Universal Windows Platform (UWP) apps that require secure authentication beyond a user Id and password combination can use certificates for authentication.</span></span> <span data-ttu-id="90e4f-106">証明書認証は、ユーザーの認証時に高レベルの信頼性を提供します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-106">Certificate authentication provides a high level of trust when authenticating a user.</span></span> <span data-ttu-id="90e4f-107">場合によっては、複数のアプリから複数のサービスのグループに対してユーザーを認証することがあります。</span><span class="sxs-lookup"><span data-stu-id="90e4f-107">In some cases, a group of services will want to authenticate a user for multiple apps.</span></span> <span data-ttu-id="90e4f-108">この記事では、1 つの証明書を使って複数のアプリを認証する方法と、セキュリティで保護された Web サービスにアクセスするための証明書をユーザーがインポートできる便利なコードを記述する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-108">This article shows how you can authenticate multiple apps using the same certificate, and how you can provide convenient code for a user to import a certificate that was provided to access secured web services.</span></span>

<span data-ttu-id="90e4f-109">アプリでは、証明書を使って Web サービスから認証を受けることができます。さらに、複数のアプリで証明書ストアにある 1 つの証明書を使って同じユーザーを認証できます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-109">Apps can authenticate to a web service using a certificate, and multiple apps can use a single certificate from the certificate store to authenticate the same user.</span></span> <span data-ttu-id="90e4f-110">証明書がストアに存在しない場合は、PFX ファイルから証明書をインポートするコードをアプリに追加できます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-110">If a certificate does not exist in the store, you can add code to your app to import a certificate from a PFX file.</span></span>

## <a name="enable-microsoft-internet-information-services-iis-and-client-certificate-mapping"></a><span data-ttu-id="90e4f-111">Microsoft インターネット インフォメーション サービス (IIS) とクライアント証明書のマッピングの有効化</span><span class="sxs-lookup"><span data-stu-id="90e4f-111">Enable Microsoft Internet Information Services (IIS) and client certificate mapping</span></span>


<span data-ttu-id="90e4f-112">この記事では、例を示すために Microsoft インターネット インフォメーション サービス (IIS) を使用します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-112">This article uses Microsoft Internet Information Services (IIS) for example purposes.</span></span> <span data-ttu-id="90e4f-113">IIS は、既定では有効になっていません。</span><span class="sxs-lookup"><span data-stu-id="90e4f-113">IIS is not enabled by default.</span></span> <span data-ttu-id="90e4f-114">IIS はコントロール パネルから有効にできます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-114">You can enable IIS by using the Control Panel.</span></span>

1.  <span data-ttu-id="90e4f-115">コントロール パネルを開き、**[プログラム]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-115">Open the Control Panel and select **Programs**.</span></span>
2.  <span data-ttu-id="90e4f-116">**[Windows の機能の有効化または無効化]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-116">Select **Turn Windows features on or off**.</span></span>
3.  <span data-ttu-id="90e4f-117">**[インターネット インフォメーション サービス]** を展開して、**[World Wide Web サービス]** を展開します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-117">Expand **Internet Information Services** and then expand **World Wide Web Services**.</span></span> <span data-ttu-id="90e4f-118">**[アプリケーション開発機能]** を展開して、**[ASP.NET 3.5]** と **[ASP.NET 4.5]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-118">Expand **Application Development Features** and select **ASP.NET 3.5** and **ASP.NET 4.5**.</span></span> <span data-ttu-id="90e4f-119">これらを選ぶと、自動的に **[インターネット インフォメーション サービス]** が有効になります。</span><span class="sxs-lookup"><span data-stu-id="90e4f-119">Making these selections will automatically enable **Internet Information Services**.</span></span>
4.  <span data-ttu-id="90e4f-120">**[OK]** をクリックして変更を適用します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-120">Click **OK** to apply the changes.</span></span>

## <a name="create-and-publish-a-secured-web-service"></a><span data-ttu-id="90e4f-121">セキュリティで保護された Web サービスの作成と発行</span><span class="sxs-lookup"><span data-stu-id="90e4f-121">Create and publish a secured web service</span></span>


1.  <span data-ttu-id="90e4f-122">管理者として Microsoft Visual Studio を実行し、スタート ページで **[新しいプロジェクト]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-122">Run Microsoft Visual Studio as administrator and select **New Project** from the start page.</span></span> <span data-ttu-id="90e4f-123">Web サービスを IIS サーバーに発行するには、管理者のアクセス権が必要です。</span><span class="sxs-lookup"><span data-stu-id="90e4f-123">Administrator access is required to publish a web service to an IIS server.</span></span> <span data-ttu-id="90e4f-124">[新しいプロジェクト] ダイアログで、フレームワークを **[.NET Framework 3.5]** に変更します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-124">In the New Project dialog, change the framework to **.NET Framework 3.5**.</span></span> <span data-ttu-id="90e4f-125">**[Visual C#]** -&gt; **[Web]** -&gt; **[Visual Studio]** -&gt; **[ASP.NET Web サービス アプリケーション]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-125">Select **Visual C#** -&gt; **Web** -&gt; **Visual Studio** -&gt; **ASP.NET Web Service Application**.</span></span> <span data-ttu-id="90e4f-126">アプリケーションに "FirstContosoBank" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-126">Name the application "FirstContosoBank".</span></span> <span data-ttu-id="90e4f-127">**[OK]** をクリックしてプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="90e4f-127">Click **OK** to create the project.</span></span>
2.  <span data-ttu-id="90e4f-128">**Service1.asmx.cs** ファイルで、既定の **HelloWorld** Web メソッドを次の "Login" メソッドに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-128">In the **Service1.asmx.cs** file, replace the default **HelloWorld** web method with the following "Login" method.</span></span>
    ```cs
            [WebMethod]
            public string Login()
            {
                // Verify certificate with CA
                var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(
                    this.Context.Request.ClientCertificate.Certificate);
                bool test = cert.Verify();
                return test.ToString();
            }
    ```

3.  <span data-ttu-id="90e4f-129">**Service1.asmx.cs** ファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-129">Save the **Service1.asmx.cs** file.</span></span>
4.  <span data-ttu-id="90e4f-130">**ソリューション エクスプローラー**で、"FirstContosoBank" アプリを右クリックし、**[発行]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-130">In the **Solution Explorer**, right-click the "FirstContosoBank" app and select **Publish**.</span></span>
5.  <span data-ttu-id="90e4f-131">**[Web の発行]** ダイアログで、新しいプロファイルを作って "ContosoProfile" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-131">In the **Publish Web** dialog, create a new profile and name it "ContosoProfile".</span></span> <span data-ttu-id="90e4f-132">**[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-132">Click **Next.**</span></span>
6.  <span data-ttu-id="90e4f-133">次のページで、IIS サーバーのサーバー名を入力し、"Default Web Site/FirstContosoBank" のサイト名を指定します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-133">On the next page, enter the server name for your IIS server, and specify a site name of "Default Web Site/FirstContosoBank".</span></span> <span data-ttu-id="90e4f-134">**[発行]** をクリックして Web サービスを発行します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-134">Click **Publish** to publish your web service.</span></span>

## <a name="configure-your-web-service-to-use-client-certificate-authentication"></a><span data-ttu-id="90e4f-135">クライアント証明書認証を使うための Web サービスの構成</span><span class="sxs-lookup"><span data-stu-id="90e4f-135">Configure your web service to use client certificate authentication</span></span>


1.  <span data-ttu-id="90e4f-136">**インターネット インフォメーション サービス (IIS) マネージャー**を実行します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-136">Run the **Internet Information Services (IIS) Manager**.</span></span>
2.  <span data-ttu-id="90e4f-137">IIS サーバーのサイトを展開します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-137">Expand the sites for your IIS server.</span></span> <span data-ttu-id="90e4f-138">**[Default Web Site]** で、新しい "FirstContosoBank" Web サービスを選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-138">Under the **Default Web Site**, select the new "FirstContosoBank" web service.</span></span> <span data-ttu-id="90e4f-139">**[操作]** セクションで、**[詳細設定]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-139">In the **Actions** section, select **Advanced Settings...**.</span></span>
3.  <span data-ttu-id="90e4f-140">**[アプリケーション プール]** を **[.NET v2.0]** に設定し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-140">Set the **Application Pool** to **.NET v2.0** and click **OK**.</span></span>
4.  <span data-ttu-id="90e4f-141">**インターネット インフォメーション サービス (IIS) マネージャー**で、IIS サーバーを選んで **[サーバー証明書]** をダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-141">In the **Internet Information Services (IIS) Manager**, select your IIS server and then double-click **Server Certificates**.</span></span> <span data-ttu-id="90e4f-142">**[操作]** セクションで、**[自己署名入り証明書の作成...]** を選びます。証明書のフレンドリ名として "ContosoBank" と入力し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-142">In the **Actions** section, select **Create Self-Signed Certificate...**. Enter "ContosoBank" as the friendly name for the certificate and click **OK**.</span></span> <span data-ttu-id="90e4f-143">これにより、IIS サーバーで使われる新しい証明書が "&lt;サーバー名&gt;.&lt;ドメイン名&gt;" の形式で作成されます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-143">This will create a new certificate for use by the IIS server in the form of "&lt;server-name&gt;.&lt;domain-name&gt;".</span></span>
5.  <span data-ttu-id="90e4f-144">**インターネット インフォメーション サービス (IIS) マネージャー**で、既定の Web サイトを選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-144">In the **Internet Information Services (IIS) Manager**, select the default web site.</span></span> <span data-ttu-id="90e4f-145">**[操作]** セクションで **[バインド]** を選び、**[追加]** をクリックします。種類として "https" を選び、ポートを "443" に設定して、IIS サーバーの完全なホスト名 ("&lt;サーバー名&gt;.&lt;ドメイン名&gt;") を入力します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-145">In the **Actions** section, select **Binding** and then click **Add...**. Select "https" as the type, set the port to "443", and enter the full host name for your IIS server ("&lt;server-name&gt;.&lt;domain-name&gt;").</span></span> <span data-ttu-id="90e4f-146">SSL 証明書を "ContosoBank" に設定します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-146">Set the SSL certificate to "ContosoBank".</span></span> <span data-ttu-id="90e4f-147">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-147">Click **OK**.</span></span> <span data-ttu-id="90e4f-148">**[サイト バインド]** ウィンドウの **[閉じる]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-148">Click **Close** in the **Site Bindings** window.</span></span>
6.  <span data-ttu-id="90e4f-149">**インターネット インフォメーション サービス (IIS) マネージャー**で、"FirstContosoBank" Web サービスを選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-149">In the **Internet Information Services (IIS) Manager**, select the "FirstContosoBank" web service.</span></span> <span data-ttu-id="90e4f-150">**[SSL 設定]** をダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-150">Double-click **SSL Settings**.</span></span> <span data-ttu-id="90e4f-151">**[SSL が必要]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-151">Check **Require SSL**.</span></span> <span data-ttu-id="90e4f-152">**[クライアント証明書]** で **[必要]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-152">Under **Client certificates**, select **Require**.</span></span> <span data-ttu-id="90e4f-153">**[操作]** セクションで、**[適用]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-153">In the **Actions** section, click **Apply**.</span></span>
7.  <span data-ttu-id="90e4f-154">Web サービスが正しく構成されたことを確認するには、Web ブラウザーを開き、Web アドレスとして「https://&lt;サーバー名&gt;.&lt;ドメイン名&gt;/FirstContosoBank/Service1.asmx」を入力します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-154">You can verify that the web service is configured correctly by opening your web browser and entering the following web address: "https://&lt;server-name&gt;.&lt;domain-name&gt;/FirstContosoBank/Service1.asmx".</span></span> <span data-ttu-id="90e4f-155">たとえば、"https://myserver.example.com/FirstContosoBank/Service1.asmx" などです。</span><span class="sxs-lookup"><span data-stu-id="90e4f-155">For example, "https://myserver.example.com/FirstContosoBank/Service1.asmx".</span></span> <span data-ttu-id="90e4f-156">Web サービスが正しく構成されていれば、Web サービスにアクセスするためのクライアント証明書を選ぶように求められます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-156">If your web service is configured correctly, you will be prompted to select a client certificate in order to access the web service.</span></span>

<span data-ttu-id="90e4f-157">前の手順を繰り返すことで、同じクライアント証明書を使ってアクセスできる複数の Web サービスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-157">You can repeat the previous steps to create multiple web services that can be accessed using the same client certificate.</span></span>

## <a name="create-a-uwp-app-that-uses-certificate-authentication"></a><span data-ttu-id="90e4f-158">証明書認証を使う UWP アプリの作成</span><span class="sxs-lookup"><span data-stu-id="90e4f-158">Create a UWP app that uses certificate authentication</span></span>


<span data-ttu-id="90e4f-159">これでセキュリティで保護された Web サービスが 1 つ以上できたので、証明書を使ってこれらの Web サービスから認証を受けるアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-159">Now that you have one or more secured web services, your apps can use certificates to authenticate to those web services.</span></span> <span data-ttu-id="90e4f-160">[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) オブジェクトを使って認証 Web サービスへの要求を作成する場合、最初の要求にはクライアント証明書が含まれません。</span><span class="sxs-lookup"><span data-stu-id="90e4f-160">When you make a request to an authenticated web service using the [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) object, the initial request will not contain a client certificate.</span></span> <span data-ttu-id="90e4f-161">認証 Web サービスは、応答としてクライアント認証を要求します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-161">The authenticated web service will respond with a request for client authentication.</span></span> <span data-ttu-id="90e4f-162">この応答を受け取ると、Windows クライアントは自動的に証明書ストアを照会して、使用できるクライアント証明書を取得します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-162">When this occurs, the Windows client will automatically query the certificate store for available client certificates.</span></span> <span data-ttu-id="90e4f-163">ユーザーは、これらの証明書の中から Web サービスへの認証に使うものを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-163">Your user can select from these certificates to authenticate to the web service.</span></span> <span data-ttu-id="90e4f-164">証明書によってはパスワードで保護されていることがあるので、証明書のパスワードを入力するための手段をユーザーに提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90e4f-164">Some certificates are password protected, so you will need to provide the user with a way to input the password for a certificate.</span></span>

<span data-ttu-id="90e4f-165">使用できるクライアント証明書がない場合は、ユーザーが証明書ストアに証明書を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90e4f-165">If there are no client certificates available, then the user will need to add a certificate to the certificate store.</span></span> <span data-ttu-id="90e4f-166">そこで、クライアント証明書の PFX ファイルをユーザーに選んでもらい、その証明書をクライアント証明書ストアにインポートするコードをアプリに含めることができます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-166">You can include code in your app that enables a user to select a PFX file that contains a client certificate and then import that certificate into the client certificate store.</span></span>

<span data-ttu-id="90e4f-167">**ヒント** makecert.exe を使うと、このクイック スタートで使うことのできる PFX ファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-167">**Tip**  You can use makecert.exe to create a PFX file to use with this quickstart.</span></span> <span data-ttu-id="90e4f-168">makecert.exe の使い方の詳細については、「[MakeCert](https://msdn.microsoft.com/library/windows/desktop/aa386968)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90e4f-168">For information on using makecert.exe, see [MakeCert.](https://msdn.microsoft.com/library/windows/desktop/aa386968)</span></span>

 

1.  <span data-ttu-id="90e4f-169">Visual Studio を開き、スタート ページで新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-169">Open Visual Studio and create a new project from the start page.</span></span> <span data-ttu-id="90e4f-170">新しいプロジェクトに "FirstContosoBankApp" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-170">Name the new project "FirstContosoBankApp".</span></span> <span data-ttu-id="90e4f-171">**[OK]** をクリックして新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-171">Click **OK** to create the new project.</span></span>
2.  <span data-ttu-id="90e4f-172">MainPage.xaml ファイルで、次の XAML を既定の **Grid** 要素に追加します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-172">In the MainPage.xaml file, add the following XAML to the default **Grid** element.</span></span> <span data-ttu-id="90e4f-173">この XAML には、インポートする PFX ファイルを参照するボタン、PFX ファイルがパスワードで保護されている場合にパスワードを入力するテキスト ボックス、選んだ PFX ファイルをインポートするボタン、セキュリティで保護された Web サービスにログインするボタン、現在の操作の状態を表示するテキスト ブロックが含まれています。</span><span class="sxs-lookup"><span data-stu-id="90e4f-173">This XAML includes a button to browse for a PFX file to import, a text box to enter a password for a password-protected PFX file, a button to import a selected PFX file, a button to log in to the secured web service, and a text block to display the status of the current action.</span></span>
    ```xml
    <Button x:Name="Import" Content="Import Certificate (PFX file)" HorizontalAlignment="Left" Margin="352,305,0,0" VerticalAlignment="Top" Height="77" Width="260" Click="Import_Click" FontSize="16"/>
    <Button x:Name="Login" Content="Login" HorizontalAlignment="Left" Margin="611,305,0,0" VerticalAlignment="Top" Height="75" Width="240" Click="Login_Click" FontSize="16"/>
    <TextBlock x:Name="Result" HorizontalAlignment="Left" Margin="355,398,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Height="153" Width="560"/>
    <PasswordBox x:Name="PfxPassword" HorizontalAlignment="Left" Margin="483,271,0,0" VerticalAlignment="Top" Width="229"/>
    <TextBlock HorizontalAlignment="Left" Margin="355,271,0,0" TextWrapping="Wrap" Text="PFX password" VerticalAlignment="Top" FontSize="18" Height="32" Width="123"/>
    <Button x:Name="Browse" Content="Browse for PFX file" HorizontalAlignment="Left" Margin="352,189,0,0" VerticalAlignment="Top" Click="Browse_Click" Width="499" Height="68" FontSize="16"/>
    <TextBlock HorizontalAlignment="Left" Margin="717,271,0,0" TextWrapping="Wrap" Text="(Optional)" VerticalAlignment="Top" Height="32" Width="83" FontSize="16"/>
    ```
    
3.  <span data-ttu-id="90e4f-174">MainPage.xaml ファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-174">Save the MainPage.xaml file.</span></span>
4.  <span data-ttu-id="90e4f-175">MainPage.xaml.cs ファイルに、次の using ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-175">In the MainPage.xaml.cs file, add the following using statements.</span></span>
    ```cs
    using Windows.Web.Http;
    using System.Text;
    using Windows.Security.Cryptography.Certificates;
    using Windows.Storage.Pickers;
    using Windows.Storage;
    using Windows.Storage.Streams;
    ```

5.  <span data-ttu-id="90e4f-176">MainPage.xaml.cs ファイルで、次の変数を **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-176">In the MainPage.xaml.cs file, add the following variables to the **MainPage** class.</span></span> <span data-ttu-id="90e4f-177">ここでは、"FirstContosoBank" Web サービスのセキュリティで保護された "Login" メソッドのアドレスと、証明書ストアにインポートする PFX 証明書を保持するグローバル変数を指定しています。</span><span class="sxs-lookup"><span data-stu-id="90e4f-177">They specify the address for the secured "Login" method of your "FirstContosoBank" web service, and a global variable that holds a PFX certificate to import into the certificate store.</span></span> <span data-ttu-id="90e4f-178">&lt;サーバー名&gt; は Microsoft Internet Information (IIS) サーバーの完全修飾名に更新してください。</span><span class="sxs-lookup"><span data-stu-id="90e4f-178">Update the &lt;server-name&gt; to the fully-qualified server name for your Microsoft Internet Information Server (IIS) server.</span></span>
    ```cs
    private Uri requestUri = new Uri("https://<server-name>/FirstContosoBank/Service1.asmx?op=Login");
    private string pfxCert = null;
    ```

6.  <span data-ttu-id="90e4f-179">MainPage.xaml.cs ファイルで、次に示すように、ログイン ボタンのクリック ハンドラーと、セキュリティで保護された Web サービスにアクセスするためのメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-179">In the MainPage.xaml.cs file, add the following click handler for the login button and method to access the secured web service.</span></span>
    ```cs
    private void Login_Click(object sender, RoutedEventArgs e)
    {
        MakeHttpsCall();
    }

    private async void MakeHttpsCall()
    {

        StringBuilder result = new StringBuilder("Login ");
        HttpResponseMessage response;
        try
        {
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
            response = await httpClient.GetAsync(requestUri);
            if (response.StatusCode == HttpStatusCode.Ok)
            {
                result.Append("successful");
            }
            else
            {
                result = result.Append("failed with ");
                result = result.Append(response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            result = result.Append("failed with ");
            result = result.Append(ex.Message);
        }

        Result.Text = result.ToString();
    }
    ```

7.  <span data-ttu-id="90e4f-180">MainPage.xaml.cs ファイルで、次に示すように、PFX ファイルを参照するボタンのクリック ハンドラーと、選ばれた PFX ファイルを証明書ストアにインポートするボタンのクリック ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="90e4f-180">In the MainPage.xaml.cs file, add the following click handlers for the button to browse for a PFX file and the button to import a selected PFX file into the certificate store.</span></span>
    ```cs
    private async void Import_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Result.Text = "Importing selected certificate into user certificate store....";
            await CertificateEnrollmentManager.UserCertificateEnrollmentManager.ImportPfxDataAsync(
                pfxCert,
                PfxPassword.Password,
                ExportOption.Exportable,
                KeyProtectionLevel.NoConsent,
                InstallOptions.DeleteExpired,
                "Import Pfx");

            Result.Text = "Certificate import succeded";
        }
        catch (Exception ex)
        {
            Result.Text = "Certificate import failed with " + ex.Message;
        }
    }

    private async void Browse_Click(object sender, RoutedEventArgs e)
    {

        StringBuilder result = new StringBuilder("Pfx file selection ");
        FileOpenPicker pfxFilePicker = new FileOpenPicker();
        pfxFilePicker.FileTypeFilter.Add(".pfx");
        pfxFilePicker.CommitButtonText = "Open";
        try
        {
            StorageFile pfxFile = await pfxFilePicker.PickSingleFileAsync();
            if (pfxFile != null)
            {
                IBuffer buffer = await FileIO.ReadBufferAsync(pfxFile);
                using (DataReader dataReader = DataReader.FromBuffer(buffer))
                {
                    byte[] bytes = new byte[buffer.Length];
                    dataReader.ReadBytes(bytes);
                    pfxCert = System.Convert.ToBase64String(bytes);
                    PfxPassword.Password = string.Empty;
                    result.Append("succeeded");
                }
            }
            else
            {
                result.Append("failed");
            }
        }
        catch (Exception ex)
        {
            result.Append("failed with ");
            result.Append(ex.Message); ;
        }

        Result.Text = result.ToString();
    }
    ```

8.  <span data-ttu-id="90e4f-181">アプリを実行し、セキュリティで保護された Web サービスにログインして、PFX ファイルをローカル証明書ストアにインポートします。</span><span class="sxs-lookup"><span data-stu-id="90e4f-181">Run your app and log in to your secured web service as well as import a PFX file into the local certificate store.</span></span>

<span data-ttu-id="90e4f-182">これらの手順を繰り返すことで、同じユーザー証明書を使ってセキュリティで保護された同じ Web サービスや別の Web サービスにアクセスする複数のアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="90e4f-182">You can use these steps to create multiple apps that use the same user certificate to access the same or different secured web services.</span></span>