---
Description: 署名せずにパッケージ アプリを実行し、その外観を確認してみましょう。 その後、ブレークポイントを設定し、コード全体をステップ実行します。 運用環境でアプリをテストする準備ができたら、アプリに署名してインストールします。
Search.Product: eADQiWindows 10XVcnh
title: パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)
ms.date: 08/31/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: f45d8b14-02d1-42e1-98df-6c03ce397fd3
ms.localizationpriority: medium
ms.openlocfilehash: 8b2350c8164548121baec231335e747166f1c082
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589757"
---
# <a name="run-debug-and-test-a-packaged-desktop-application"></a><span data-ttu-id="573c6-106">実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト</span><span class="sxs-lookup"><span data-stu-id="573c6-106">Run, debug, and test a packaged desktop application</span></span>

<span data-ttu-id="573c6-107">パッケージ化されたアプリケーションを実行し、それに署名することがなくの外観を確認します。</span><span class="sxs-lookup"><span data-stu-id="573c6-107">Run your packaged application and see how it looks without having to sign it.</span></span> <span data-ttu-id="573c6-108">その後、ブレークポイントを設定し、コード全体をステップ実行します。</span><span class="sxs-lookup"><span data-stu-id="573c6-108">Then, set breakpoints and step through code.</span></span> <span data-ttu-id="573c6-109">運用環境でアプリケーションをテストする準備ができたら、アプリケーションに署名してからインストールします。</span><span class="sxs-lookup"><span data-stu-id="573c6-109">When you're ready to test your application in a production environment, sign your application and then install it.</span></span> <span data-ttu-id="573c6-110">このトピックでは、これらの作業を行う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="573c6-110">This topic shows you how to do each of these things.</span></span>

<a id="run-app" />

## <a name="run-your-application"></a><span data-ttu-id="573c6-111">アプリケーションを実行します。</span><span class="sxs-lookup"><span data-stu-id="573c6-111">Run your application</span></span>

<span data-ttu-id="573c6-112">証明書を取得し、署名することがなくローカルでテストするアプリケーションを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="573c6-112">You can run your application to test it out locally without having to obtain a certificate and sign it.</span></span> <span data-ttu-id="573c6-113">どのようなツールに依存アプリケーションを実行する方法、パッケージを作成するために使用します。</span><span class="sxs-lookup"><span data-stu-id="573c6-113">How you run the application depends on what tool you used to create the package.</span></span>

### <a name="you-created-the-package-by-using-visual-studio"></a><span data-ttu-id="573c6-114">Visual Studio を使ってパッケージを作成した</span><span class="sxs-lookup"><span data-stu-id="573c6-114">You created the package by using Visual Studio</span></span>

<span data-ttu-id="573c6-115">パッケージ プロジェクトをスタートアップ プロジェクトとして設定し、Ctrl キーを押しながら F5 キーを押してアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="573c6-115">Set the packaging project as the startup project, and then press CTRL+F5 to start your app.</span></span>

### <a name="you-created-the-package-manually-or-by-using-the-desktop-app-converter"></a><span data-ttu-id="573c6-116">手動で、または Desktop App Converter を使ってパッケージを作成した</span><span class="sxs-lookup"><span data-stu-id="573c6-116">You created the package manually or by using the Desktop App Converter</span></span>

<span data-ttu-id="573c6-117">Windows PowerShell コマンド プロンプトを開き、出力フォルダーの **PackageFiles** サブフォルダーからこのコマンドレットを実行します。</span><span class="sxs-lookup"><span data-stu-id="573c6-117">Open a Windows PowerShell command prompt, and from the **PackageFiles** subfolder of your output folder, run this cmdlet:</span></span>

```
Add-AppxPackage –Register AppxManifest.xml
```
<span data-ttu-id="573c6-118">アプリを起動するには、そのアプリを Windows スタート メニューで見つけます。</span><span class="sxs-lookup"><span data-stu-id="573c6-118">To start your app, find it in the Windows Start menu.</span></span>

![[スタート] メニューで、パッケージ化されたアプリケーション](images/desktop-to-uwp/converted-app-installed.png)

> [!NOTE]
> <span data-ttu-id="573c6-120">パッケージ化されたアプリケーションでは、常には、対話型のユーザーとして実行されにパッケージ化されたアプリケーションをインストールする任意のドライブを NTFS 形式に書式設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="573c6-120">A packaged application always runs as an interactive user, and any drive that you install your packaged application on to must be formatted to NTFS format.</span></span>

## <a name="debug-your-app"></a><span data-ttu-id="573c6-121">アプリのデバッグ</span><span class="sxs-lookup"><span data-stu-id="573c6-121">Debug your app</span></span>

<span data-ttu-id="573c6-122">どのようなツールに依存アプリケーションをデバッグする方法について、パッケージを作成するために使用します。</span><span class="sxs-lookup"><span data-stu-id="573c6-122">How you debug the application depends on what tool you used to create the package.</span></span>

<span data-ttu-id="573c6-123">Visual Studio 2017 リリース 15.4 で使用可能な[新しいパッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md#new-packaging-project)を使ってパッケージを作成した場合、パッケージ プロジェクトをスタートアップ プロジェクトに設定するだけで、F5 キーを押すことでアプリをデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="573c6-123">If you created your package by using the [new packaging project](desktop-to-uwp-packaging-dot-net.md#new-packaging-project) available in the 15.4 release of Visual Studio 2017, Just set the packaging project as the startup project, and then press F5 to debug your app.</span></span>

<span data-ttu-id="573c6-124">その他のツールを使用してパッケージを作成した場合は、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="573c6-124">If you created your package by using any other tool, follow these steps.</span></span>

1. <span data-ttu-id="573c6-125">ローカル コンピューターにインストールができるようにパッケージ化されたアプリケーションに少なくとも 1 つの時間を始めることを確認します。</span><span class="sxs-lookup"><span data-stu-id="573c6-125">Make sure that you start your packaged application at least one time so that it's installed on your local machine.</span></span>

   <span data-ttu-id="573c6-126">上の「[アプリを実行する](#run-app)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="573c6-126">See the [Run your app](#run-app) section above.</span></span>

2. <span data-ttu-id="573c6-127">Visual Studio を起動します。</span><span class="sxs-lookup"><span data-stu-id="573c6-127">Start Visual Studio.</span></span>

   <span data-ttu-id="573c6-128">昇格されたアクセス許可を使用してアプリケーションをデバッグする場合を使用して Visual Studio を起動、**管理者として実行**オプション。</span><span class="sxs-lookup"><span data-stu-id="573c6-128">If you want to debug your application with elevated permissions, start Visual Studio by using the **Run as Administrator** option.</span></span>

3. <span data-ttu-id="573c6-129">Visual Studio で、**[デバッグ]**->**[その他のデバッグ ターゲット]**->**[インストールされているアプリケーション パッケージのデバッグ]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="573c6-129">In Visual Studio, choose **Debug**->**Other Debug Targets**->**Debug Installed App Package**.</span></span>

4. <span data-ttu-id="573c6-130">**[インストールされているアプリケーション パッケージのデバッグ]** リストで、目的のアプリ パッケージを選び、**[アタッチ]** ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="573c6-130">In the **Installed App Packages** list, select your app package, and then choose the **Attach** button.</span></span>

#### <a name="modify-your-application-in-between-debug-sessions"></a><span data-ttu-id="573c6-131">デバッグ セッションの間、アプリケーションを変更します。</span><span class="sxs-lookup"><span data-stu-id="573c6-131">Modify your application in between debug sessions</span></span>

<span data-ttu-id="573c6-132">バグを修正するアプリケーションに変更を加えた場合は、MakeAppx ツールを使用して再パッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="573c6-132">If you make your changes to your application to fix bugs, repackage it by using the MakeAppx tool.</span></span> <span data-ttu-id="573c6-133">「[MakeAppx ツールを実行する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="573c6-133">See [Run the MakeAppx tool](desktop-to-uwp-manual-conversion.md#make-appx).</span></span>

### <a name="debug-the-entire-application-lifecycle"></a><span data-ttu-id="573c6-134">全体のアプリケーションのライフ サイクルをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="573c6-134">Debug the entire application lifecycle</span></span>

<span data-ttu-id="573c6-135">場合によっては、開始する前に、アプリケーションをデバッグする機能など、デバッグ プロセスをより細かく制御する必要があります。</span><span class="sxs-lookup"><span data-stu-id="573c6-135">In some cases, you might want finer-grained control over the debugging process, including the ability to debug your application before it starts.</span></span>

<span data-ttu-id="573c6-136">使用することができます[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx)中断、再開、終了などのアプリケーション ライフ サイクルを完全に制御を取得します。</span><span class="sxs-lookup"><span data-stu-id="573c6-136">You can use [PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) to get full control over application lifecycle including suspending, resuming, and termination.</span></span>

<span data-ttu-id="573c6-137">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) は Windows SDK に含まれています。</span><span class="sxs-lookup"><span data-stu-id="573c6-137">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) is included with the Windows SDK.</span></span>

## <a name="test-your-app"></a><span data-ttu-id="573c6-138">アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="573c6-138">Test your app</span></span>

<span data-ttu-id="573c6-139">ディストリビューションを準備するときは、現実的な設定で、アプリケーションをテストするには、アプリケーションに署名し、インストールすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="573c6-139">To test your application in a realistic setting as you prepare for distribution, it's best to sign your application and then install it.</span></span>

### <a name="test-an-application-that-you-packaged-by-using-visual-studio"></a><span data-ttu-id="573c6-140">Visual Studio を使用してパッケージ化されているアプリケーションをテストします。</span><span class="sxs-lookup"><span data-stu-id="573c6-140">Test an application that you packaged by using Visual Studio</span></span>

<span data-ttu-id="573c6-141">Visual Studio テスト証明書を使用して、アプリケーションに署名します。</span><span class="sxs-lookup"><span data-stu-id="573c6-141">Visual Studio signs your application by using a test certificate.</span></span> <span data-ttu-id="573c6-142">その証明書は、**アプリ パッケージの作成**ウィザードにより生成される出力フォルダーに置かれます。</span><span class="sxs-lookup"><span data-stu-id="573c6-142">You'll find that certificate in the output folder that the **Create App Packages** wizard generates.</span></span> <span data-ttu-id="573c6-143">証明書ファイルが、 *.cer*と拡張機能は、その証明書をインストールする必要があります、**信頼されたルート証明機関**でアプリケーションをテストする PC に保存します。</span><span class="sxs-lookup"><span data-stu-id="573c6-143">The certificate file has the *.cer* extension and you'll have to install that certificate into the **Trusted Root Certification Authorities** store on the PC that you want to test your application on.</span></span> <span data-ttu-id="573c6-144">「[アプリ パッケージをサイドローディングする](../packaging/packaging-uwp-apps.md#sideload-your-app-package)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="573c6-144">See [Sideload your package](../packaging/packaging-uwp-apps.md#sideload-your-app-package).</span></span>

### <a name="test-an-application-that-you-packaged-by-using-the-desktop-app-converter-dac"></a><span data-ttu-id="573c6-145">Desktop App Converter (DAC) を使用してパッケージ化されているアプリケーションをテストします。</span><span class="sxs-lookup"><span data-stu-id="573c6-145">Test an application that you packaged by using the Desktop App Converter (DAC)</span></span>

<span data-ttu-id="573c6-146">使用することができます、Desktop App Converter を使用して、アプリケーションをパッケージ化する場合、``sign``パラメーターを自動的に生成された証明書を使用して、アプリケーションに署名します。</span><span class="sxs-lookup"><span data-stu-id="573c6-146">If you package your application by using the Desktop App Converter, you can use the ``sign`` parameter to automatically sign your application by using a generated certificate.</span></span> <span data-ttu-id="573c6-147">その証明書をインストールしてから、アプリをインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="573c6-147">You'll have to install that certificate, and then install the app.</span></span> <span data-ttu-id="573c6-148">「[パッケージ アプリを実行する](desktop-to-uwp-run-desktop-app-converter.md#run-app)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="573c6-148">See [Run the packaged app](desktop-to-uwp-run-desktop-app-converter.md#run-app).</span></span>   


### <a name="manually-sign-apps-optional"></a><span data-ttu-id="573c6-149">アプリに手動で署名する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="573c6-149">Manually sign apps (Optional)</span></span>

<span data-ttu-id="573c6-150">また、アプリケーションを手動でサインインできます。</span><span class="sxs-lookup"><span data-stu-id="573c6-150">You can also sign your application manually.</span></span> <span data-ttu-id="573c6-151">その方法は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="573c6-151">Here's how</span></span>

1. <span data-ttu-id="573c6-152">証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="573c6-152">Create a certificate.</span></span> <span data-ttu-id="573c6-153">「[証明書を作成する](../packaging/create-certificate-package-signing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="573c6-153">See [Create a certificate](../packaging/create-certificate-package-signing.md).</span></span>

2. <span data-ttu-id="573c6-154">その証明書をシステム上の証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールします。</span><span class="sxs-lookup"><span data-stu-id="573c6-154">Install that certificate into the **Trusted Root** or **Trusted People** certificate store on your system.</span></span>

3. <span data-ttu-id="573c6-155">その証明書を使用して、アプリケーションの署名は、「 [SignTool を使用して、アプリ パッケージの署名](../packaging/sign-app-package-using-signtool.md)します。</span><span class="sxs-lookup"><span data-stu-id="573c6-155">Sign your application by using that certificate, see [Sign an app package using SignTool](../packaging/sign-app-package-using-signtool.md).</span></span>

  > [!IMPORTANT]
  > <span data-ttu-id="573c6-156">証明書の発行元名がアプリの発行者名と一致することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="573c6-156">Make sure that the publisher name on your certificate matches the publisher name of your app.</span></span>

<span data-ttu-id="573c6-157">**関連のサンプル**</span><span class="sxs-lookup"><span data-stu-id="573c6-157">**Related sample**</span></span>

[<span data-ttu-id="573c6-158">SigningCerts</span><span class="sxs-lookup"><span data-stu-id="573c6-158">SigningCerts</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SigningCerts)


### <a name="test-your-application-for-windows-10-s"></a><span data-ttu-id="573c6-159">Windows 10 S 用アプリケーションをテストします。</span><span class="sxs-lookup"><span data-stu-id="573c6-159">Test your application for Windows 10 S</span></span>

<span data-ttu-id="573c6-160">アプリを発行する前に Windows 10 s. を実行するデバイスで正しく動作は、必ず実際には、Microsoft Store にアプリケーションを発行する場合は、これを行うストアの要件があるためです。</span><span class="sxs-lookup"><span data-stu-id="573c6-160">Before you publish your app, make sure that it will operate correctly on devices that run Windows 10 S. In fact, if you plan to publish your application to the Microsoft Store, you must do this because it is a store requirement.</span></span> <span data-ttu-id="573c6-161">Windows 10 S を実行するデバイスで正しく動作しないアプリは認定されません。</span><span class="sxs-lookup"><span data-stu-id="573c6-161">Apps that don't operate correctly on devices that run Windows 10 S won't be certified.</span></span>

<span data-ttu-id="573c6-162">参照してください[Windows アプリケーションの Windows 10 S テスト](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s)します。</span><span class="sxs-lookup"><span data-stu-id="573c6-162">See [Test your Windows application for Windows 10 S](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s).</span></span>

### <a name="run-another-process-inside-the-full-trust-container"></a><span data-ttu-id="573c6-163">完全な信頼コンテナー内で別のプロセスを実行する</span><span class="sxs-lookup"><span data-stu-id="573c6-163">Run another process inside the full trust container</span></span>

<span data-ttu-id="573c6-164">指定されたアプリ パッケージのコンテナー内でカスタムのプロセスを起動することができます。</span><span class="sxs-lookup"><span data-stu-id="573c6-164">You can invoke custom processes inside the container of a specified app package.</span></span> <span data-ttu-id="573c6-165">これは、シナリオをテストするために役立つ場合があります (たとえば、カスタムのテスト ハーネスがあり、アプリの出力をテストする必要がある場合など)。</span><span class="sxs-lookup"><span data-stu-id="573c6-165">This can be useful for testing scenarios (for example, if you have a custom test harness and want to test output of the app).</span></span> <span data-ttu-id="573c6-166">これを行うには、```Invoke-CommandInDesktopPackage``` PowerShell コマンドレットを使用します。</span><span class="sxs-lookup"><span data-stu-id="573c6-166">To do so, use the ```Invoke-CommandInDesktopPackage``` PowerShell cmdlet:</span></span>

```CMD
Invoke-CommandInDesktopPackage [-PackageFamilyName] <string> [-AppId] <string> [-Command] <string> [[-Args]
    <string>]  [<CommonParameters>]
```

## <a name="next-steps"></a><span data-ttu-id="573c6-167">次のステップ</span><span class="sxs-lookup"><span data-stu-id="573c6-167">Next steps</span></span>

<span data-ttu-id="573c6-168">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="573c6-168">**Find answers to your questions**</span></span>

<span data-ttu-id="573c6-169">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="573c6-169">Have questions?</span></span> <span data-ttu-id="573c6-170">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="573c6-170">Ask us on Stack Overflow.</span></span> <span data-ttu-id="573c6-171">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="573c6-171">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="573c6-172">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="573c6-172">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="573c6-173">**ご意見や機能を提案します。**</span><span class="sxs-lookup"><span data-stu-id="573c6-173">**Give feedback or make feature suggestions**</span></span>

<span data-ttu-id="573c6-174">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="573c6-174">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
