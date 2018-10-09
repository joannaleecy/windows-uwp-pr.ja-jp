---
author: normesta
Description: Run your packaged app and see how it looks without having to sign it. Then, set breakpoints and step through code. When you're ready to test your app in a production environment, sign your app and then install it.
Search.Product: eADQiWindows 10XVcnh
title: パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 08/31/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: f45d8b14-02d1-42e1-98df-6c03ce397fd3
ms.localizationpriority: medium
ms.openlocfilehash: b5110eebde087593f07704e89c2e4708b2fcbb8b
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4463513"
---
# <a name="run-debug-and-test-a-packaged-desktop-application"></a><span data-ttu-id="4b748-103">実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト</span><span class="sxs-lookup"><span data-stu-id="4b748-103">Run, debug, and test a packaged desktop application</span></span>

<span data-ttu-id="4b748-104">パッケージ化されたアプリケーションを実行し、それに署名することがなくの外観を確認します。</span><span class="sxs-lookup"><span data-stu-id="4b748-104">Run your packaged application and see how it looks without having to sign it.</span></span> <span data-ttu-id="4b748-105">その後、ブレークポイントを設定し、コード全体をステップ実行します。</span><span class="sxs-lookup"><span data-stu-id="4b748-105">Then, set breakpoints and step through code.</span></span> <span data-ttu-id="4b748-106">実稼働環境でアプリケーションをテストする準備ができたら、アプリケーションに署名し、それをインストールします。</span><span class="sxs-lookup"><span data-stu-id="4b748-106">When you're ready to test your application in a production environment, sign your application and then install it.</span></span> <span data-ttu-id="4b748-107">このトピックでは、これらの作業を行う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4b748-107">This topic shows you how to do each of these things.</span></span>

<a id="run-app" />

## <a name="run-your-application"></a><span data-ttu-id="4b748-108">アプリケーションを実行します。</span><span class="sxs-lookup"><span data-stu-id="4b748-108">Run your application</span></span>

<span data-ttu-id="4b748-109">証明書を取得し、それに署名することがなくローカルでテストするアプリケーションを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="4b748-109">You can run your application to test it out locally without having to obtain a certificate and sign it.</span></span> <span data-ttu-id="4b748-110">ツールによって異なりますアプリケーションを実行する方法、パッケージを作成するために使用します。</span><span class="sxs-lookup"><span data-stu-id="4b748-110">How you run the application depends on what tool you used to create the package.</span></span>

### <a name="you-created-the-package-by-using-visual-studio"></a><span data-ttu-id="4b748-111">Visual Studio を使ってパッケージを作成した</span><span class="sxs-lookup"><span data-stu-id="4b748-111">You created the package by using Visual Studio</span></span>

<span data-ttu-id="4b748-112">パッケージ プロジェクトをスタートアップ プロジェクトとして設定し、Ctrl キーを押しながら F5 キーを押してアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="4b748-112">Set the packaging project as the startup project, and then press CTRL+F5 to start your app.</span></span>

### <a name="you-created-the-package-manually-or-by-using-the-desktop-app-converter"></a><span data-ttu-id="4b748-113">手動で、または Desktop App Converter を使ってパッケージを作成した</span><span class="sxs-lookup"><span data-stu-id="4b748-113">You created the package manually or by using the Desktop App Converter</span></span>

<span data-ttu-id="4b748-114">Windows PowerShell コマンド プロンプトを開き、出力フォルダーの **PackageFiles** サブフォルダーからこのコマンドレットを実行します。</span><span class="sxs-lookup"><span data-stu-id="4b748-114">Open a Windows PowerShell command prompt, and from the **PackageFiles** subfolder of your output folder, run this cmdlet:</span></span>

```
Add-AppxPackage –Register AppxManifest.xml
```
<span data-ttu-id="4b748-115">アプリを起動するには、そのアプリを Windows スタート メニューで見つけます。</span><span class="sxs-lookup"><span data-stu-id="4b748-115">To start your app, find it in the Windows Start menu.</span></span>

![[スタート] メニューでパッケージ化されたアプリケーション](images/desktop-to-uwp/converted-app-installed.png)

> [!NOTE]
> <span data-ttu-id="4b748-117">パッケージ化されたアプリケーションでは、常には、対話ユーザーとして実行されにパッケージ化されたアプリケーションをインストールするすべてのドライブを NTFS 形式にフォーマットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b748-117">A packaged application always runs as an interactive user, and any drive that you install your packaged application on to must be formatted to NTFS format.</span></span>

## <a name="debug-your-app"></a><span data-ttu-id="4b748-118">アプリのデバッグ</span><span class="sxs-lookup"><span data-stu-id="4b748-118">Debug your app</span></span>

<span data-ttu-id="4b748-119">ツールによって異なりますアプリケーションをデバッグする方法について、パッケージを作成するために使用します。</span><span class="sxs-lookup"><span data-stu-id="4b748-119">How you debug the application depends on what tool you used to create the package.</span></span>

<span data-ttu-id="4b748-120">Visual Studio 2017 リリース 15.4 で使用可能な[新しいパッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md#new-packaging-project)を使ってパッケージを作成した場合、パッケージ プロジェクトをスタートアップ プロジェクトに設定するだけで、F5 キーを押すことでアプリをデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="4b748-120">If you created your package by using the [new packaging project](desktop-to-uwp-packaging-dot-net.md#new-packaging-project) available in the 15.4 release of Visual Studio 2017, Just set the packaging project as the startup project, and then press F5 to debug your app.</span></span>

<span data-ttu-id="4b748-121">その他のツールを使用してパッケージを作成した場合は、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="4b748-121">If you created your package by using any other tool, follow these steps.</span></span>

1. <span data-ttu-id="4b748-122">ローカル コンピューターにインストールされているようにパッケージ化されたアプリケーションで少なくとも 1 回を開始することを確認します。</span><span class="sxs-lookup"><span data-stu-id="4b748-122">Make sure that you start your packaged application at least one time so that it's installed on your local machine.</span></span>

   <span data-ttu-id="4b748-123">上の「[アプリを実行する](#run-app)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4b748-123">See the [Run your app](#run-app) section above.</span></span>

2. <span data-ttu-id="4b748-124">Visual Studio を起動します。</span><span class="sxs-lookup"><span data-stu-id="4b748-124">Start Visual Studio.</span></span>

   <span data-ttu-id="4b748-125">管理者特権のアクセス許可を使用してアプリケーションをデバッグする場合、**管理者として実行**] オプションを使用して、Visual Studio を起動します。</span><span class="sxs-lookup"><span data-stu-id="4b748-125">If you want to debug your application with elevated permissions, start Visual Studio by using the **Run as Administrator** option.</span></span>

3. <span data-ttu-id="4b748-126">Visual Studio で、**[デバッグ]**->**[その他のデバッグ ターゲット]**->**[インストールされているアプリケーション パッケージのデバッグ]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="4b748-126">In Visual Studio, choose **Debug**->**Other Debug Targets**->**Debug Installed App Package**.</span></span>

4. <span data-ttu-id="4b748-127">**[インストールされているアプリケーション パッケージのデバッグ]** リストで、目的のアプリ パッケージを選び、**[アタッチ]** ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="4b748-127">In the **Installed App Packages** list, select your app package, and then choose the **Attach** button.</span></span>

#### <a name="modify-your-application-in-between-debug-sessions"></a><span data-ttu-id="4b748-128">デバッグ セッションの間に、アプリケーションを変更します。</span><span class="sxs-lookup"><span data-stu-id="4b748-128">Modify your application in between debug sessions</span></span>

<span data-ttu-id="4b748-129">バグの修正をアプリケーションに変更を加えた場合は、MakeAppx ツールを使用して再パッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="4b748-129">If you make your changes to your application to fix bugs, repackage it by using the MakeAppx tool.</span></span> <span data-ttu-id="4b748-130">「[MakeAppx ツールを実行する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4b748-130">See [Run the MakeAppx tool](desktop-to-uwp-manual-conversion.md#make-appx).</span></span>

### <a name="debug-the-entire-application-lifecycle"></a><span data-ttu-id="4b748-131">全体のアプリケーションのライフ サイクルをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="4b748-131">Debug the entire application lifecycle</span></span>

<span data-ttu-id="4b748-132">場合によっては、開始する前に、アプリをデバッグする機能など、デバッグ プロセスを細かくきめ細かい制御を必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b748-132">In some cases, you might want finer-grained control over the debugging process, including the ability to debug your application before it starts.</span></span>

<span data-ttu-id="4b748-133">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx)を使用するには、中断、再開、および終了など、アプリケーションのライフ サイクルの完全な制御を取得します。</span><span class="sxs-lookup"><span data-stu-id="4b748-133">You can use [PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) to get full control over application lifecycle including suspending, resuming, and termination.</span></span>

<span data-ttu-id="4b748-134">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) は Windows SDK に含まれています。</span><span class="sxs-lookup"><span data-stu-id="4b748-134">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) is included with the Windows SDK.</span></span>

## <a name="test-your-app"></a><span data-ttu-id="4b748-135">アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="4b748-135">Test your app</span></span>

<span data-ttu-id="4b748-136">配布用に準備する現実的な設定で、アプリケーションをテストするには、アプリケーションに署名し、それをインストールすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4b748-136">To test your application in a realistic setting as you prepare for distribution, it's best to sign your application and then install it.</span></span>

### <a name="test-an-application-that-you-packaged-by-using-visual-studio"></a><span data-ttu-id="4b748-137">Visual Studio を使ってパッケージ化されたアプリケーションをテストします。</span><span class="sxs-lookup"><span data-stu-id="4b748-137">Test an application that you packaged by using Visual Studio</span></span>

<span data-ttu-id="4b748-138">Visual Studio では、テスト証明書を使用して、アプリケーションが署名します。</span><span class="sxs-lookup"><span data-stu-id="4b748-138">Visual Studio signs your application by using a test certificate.</span></span> <span data-ttu-id="4b748-139">その証明書は、**アプリ パッケージの作成**ウィザードにより生成される出力フォルダーに置かれます。</span><span class="sxs-lookup"><span data-stu-id="4b748-139">You'll find that certificate in the output folder that the **Create App Packages** wizard generates.</span></span> <span data-ttu-id="4b748-140">証明書ファイルには、 *.cer*拡張機能と、アプリケーションでテストする PC 上の**信頼されたルート証明機関**ストアにその証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b748-140">The certificate file has the *.cer* extension and you'll have to install that certificate into the **Trusted Root Certification Authorities** store on the PC that you want to test your application on.</span></span> <span data-ttu-id="4b748-141">「[アプリ パッケージをサイドローディングする](../packaging/packaging-uwp-apps.md#sideload-your-app-package)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4b748-141">See [Sideload your package](../packaging/packaging-uwp-apps.md#sideload-your-app-package).</span></span>

### <a name="test-an-application-that-you-packaged-by-using-the-desktop-app-converter-dac"></a><span data-ttu-id="4b748-142">Desktop App Converter (DAC) を使用してパッケージ化されたアプリケーションをテストします。</span><span class="sxs-lookup"><span data-stu-id="4b748-142">Test an application that you packaged by using the Desktop App Converter (DAC)</span></span>

<span data-ttu-id="4b748-143">Desktop App Converter を使用して、アプリケーションをパッケージ化する場合は使ってできます、``sign``パラメーターを自動的に生成された証明書を使用して、アプリケーションに署名します。</span><span class="sxs-lookup"><span data-stu-id="4b748-143">If you package your application by using the Desktop App Converter, you can use the ``sign`` parameter to automatically sign your application by using a generated certificate.</span></span> <span data-ttu-id="4b748-144">その証明書をインストールしてから、アプリをインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b748-144">You'll have to install that certificate, and then install the app.</span></span> <span data-ttu-id="4b748-145">「[パッケージ アプリを実行する](desktop-to-uwp-run-desktop-app-converter.md#run-app)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4b748-145">See [Run the packaged app](desktop-to-uwp-run-desktop-app-converter.md#run-app).</span></span>   


### <a name="manually-sign-apps-optional"></a><span data-ttu-id="4b748-146">アプリに手動で署名する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="4b748-146">Manually sign apps (Optional)</span></span>

<span data-ttu-id="4b748-147">また、アプリケーションを手動で署名できます。</span><span class="sxs-lookup"><span data-stu-id="4b748-147">You can also sign your application manually.</span></span> <span data-ttu-id="4b748-148">その方法は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4b748-148">Here's how</span></span>

1. <span data-ttu-id="4b748-149">証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="4b748-149">Create a certificate.</span></span> <span data-ttu-id="4b748-150">「[証明書を作成する](../packaging/create-certificate-package-signing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4b748-150">See [Create a certificate](../packaging/create-certificate-package-signing.md).</span></span>

2. <span data-ttu-id="4b748-151">その証明書をシステム上の証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールします。</span><span class="sxs-lookup"><span data-stu-id="4b748-151">Install that certificate into the **Trusted Root** or **Trusted People** certificate store on your system.</span></span>

3. <span data-ttu-id="4b748-152">その証明書を使用して、アプリケーションの署名、[サインイン、アプリ パッケージが SignTool を使って](../packaging/sign-app-package-using-signtool.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4b748-152">Sign your application by using that certificate, see [Sign an app package using SignTool](../packaging/sign-app-package-using-signtool.md).</span></span>

  > [!IMPORTANT]
  > <span data-ttu-id="4b748-153">証明書の発行元名がアプリの発行者名と一致することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="4b748-153">Make sure that the publisher name on your certificate matches the publisher name of your app.</span></span>

    **<span data-ttu-id="4b748-154">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="4b748-154">Related sample</span></span>**

    [<span data-ttu-id="4b748-155">SigningCerts</span><span class="sxs-lookup"><span data-stu-id="4b748-155">SigningCerts</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SigningCerts)


### <a name="test-your-application-for-windows-10-s"></a><span data-ttu-id="4b748-156">アプリケーションを Windows 10 S をテストします。</span><span class="sxs-lookup"><span data-stu-id="4b748-156">Test your application for Windows 10 S</span></span>

<span data-ttu-id="4b748-157">アプリを公開する前に Windows 10 秒を実行するデバイスで正しく動作すること確認します。実際には、Microsoft Store にアプリを公開する場合は、する必要がありますこれを行うため、これはストア要件です。</span><span class="sxs-lookup"><span data-stu-id="4b748-157">Before you publish your app, make sure that it will operate correctly on devices that run Windows 10 S. In fact, if you plan to publish your application to the Microsoft Store, you must do this because it is a store requirement.</span></span> <span data-ttu-id="4b748-158">Windows 10 S を実行するデバイスで正しく動作しないアプリは認定されません。</span><span class="sxs-lookup"><span data-stu-id="4b748-158">Apps that don't operate correctly on devices that run Windows 10 S won't be certified.</span></span>

<span data-ttu-id="4b748-159">[テストの Windows 10 S、Windows アプリケーション](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4b748-159">See [Test your Windows application for Windows 10 S](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s).</span></span>

### <a name="run-another-process-inside-the-full-trust-container"></a><span data-ttu-id="4b748-160">完全な信頼コンテナー内で別のプロセスを実行する</span><span class="sxs-lookup"><span data-stu-id="4b748-160">Run another process inside the full trust container</span></span>

<span data-ttu-id="4b748-161">指定されたアプリ パッケージのコンテナー内でカスタムのプロセスを起動することができます。</span><span class="sxs-lookup"><span data-stu-id="4b748-161">You can invoke custom processes inside the container of a specified app package.</span></span> <span data-ttu-id="4b748-162">これは、シナリオをテストするために役立つ場合があります (たとえば、カスタムのテスト ハーネスがあり、アプリの出力をテストする必要がある場合など)。</span><span class="sxs-lookup"><span data-stu-id="4b748-162">This can be useful for testing scenarios (for example, if you have a custom test harness and want to test output of the app).</span></span> <span data-ttu-id="4b748-163">これを行うには、```Invoke-CommandInDesktopPackage``` PowerShell コマンドレットを使用します。</span><span class="sxs-lookup"><span data-stu-id="4b748-163">To do so, use the ```Invoke-CommandInDesktopPackage``` PowerShell cmdlet:</span></span>

```CMD
Invoke-CommandInDesktopPackage [-PackageFamilyName] <string> [-AppId] <string> [-Command] <string> [[-Args]
    <string>]  [<CommonParameters>]
```

## <a name="next-steps"></a><span data-ttu-id="4b748-164">次のステップ</span><span class="sxs-lookup"><span data-stu-id="4b748-164">Next steps</span></span>

**<span data-ttu-id="4b748-165">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="4b748-165">Find answers to your questions</span></span>**

<span data-ttu-id="4b748-166">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="4b748-166">Have questions?</span></span> <span data-ttu-id="4b748-167">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="4b748-167">Ask us on Stack Overflow.</span></span> <span data-ttu-id="4b748-168">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="4b748-168">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="4b748-169">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="4b748-169">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="4b748-170">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="4b748-170">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="4b748-171">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4b748-171">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
