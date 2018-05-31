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
ms.openlocfilehash: 0f8d443bc201d0e60387673edb7f9b73e2e47490
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1662682"
---
# <a name="run-debug-and-test-a-packaged-desktop-app-desktop-bridge"></a><span data-ttu-id="64921-103">パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="64921-103">Run, debug, and test a packaged desktop app (Desktop Bridge)</span></span>

<span data-ttu-id="64921-104">署名せずにパッケージ アプリを実行し、その外観を確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="64921-104">Run your packaged app and see how it looks without having to sign it.</span></span> <span data-ttu-id="64921-105">その後、ブレークポイントを設定し、コード全体をステップ実行します。</span><span class="sxs-lookup"><span data-stu-id="64921-105">Then, set breakpoints and step through code.</span></span> <span data-ttu-id="64921-106">運用環境でアプリをテストする準備ができたら、アプリに署名してインストールします。</span><span class="sxs-lookup"><span data-stu-id="64921-106">When you're ready to test your app in a production environment, sign your app and then install it.</span></span> <span data-ttu-id="64921-107">このトピックでは、これらの作業を行う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="64921-107">This topic shows you how to do each of these things.</span></span>

<a id="run-app" />

## <a name="run-your-app"></a><span data-ttu-id="64921-108">アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="64921-108">Run your app</span></span>

<span data-ttu-id="64921-109">証明書を取得して署名する作業を行わなくても、アプリをローカルで実行およびテストできます。</span><span class="sxs-lookup"><span data-stu-id="64921-109">You can run your app to test it out locally without having to obtain a certificate and sign it.</span></span> <span data-ttu-id="64921-110">アプリを実行する方法は、パッケージの作成に使うツールによって異なります。</span><span class="sxs-lookup"><span data-stu-id="64921-110">How you run the app depends on what tool you used to create the package.</span></span>

### <a name="you-created-the-package-by-using-visual-studio"></a><span data-ttu-id="64921-111">Visual Studio を使ってパッケージを作成した</span><span class="sxs-lookup"><span data-stu-id="64921-111">You created the package by using Visual Studio</span></span>

<span data-ttu-id="64921-112">パッケージ プロジェクトをスタートアップ プロジェクトとして設定し、Ctrl キーを押しながら F5 キーを押してアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="64921-112">Set the packaging project as the startup project, and then press CTRL+F5 to start your app.</span></span>

### <a name="you-created-the-package-manually-or-by-using-the-desktop-app-converter"></a><span data-ttu-id="64921-113">手動で、または Desktop App Converter を使ってパッケージを作成した</span><span class="sxs-lookup"><span data-stu-id="64921-113">You created the package manually or by using the Desktop App Converter</span></span>

<span data-ttu-id="64921-114">Windows PowerShell コマンド プロンプトを開き、出力フォルダーの **PackageFiles** サブフォルダーからこのコマンドレットを実行します。</span><span class="sxs-lookup"><span data-stu-id="64921-114">Open a Windows PowerShell command prompt, and from the **PackageFiles** subfolder of your output folder, run this cmdlet:</span></span>

```
Add-AppxPackage –Register AppxManifest.xml
```
<span data-ttu-id="64921-115">アプリを起動するには、そのアプリを Windows スタート メニューで見つけます。</span><span class="sxs-lookup"><span data-stu-id="64921-115">To start your app, find it in the Windows Start menu.</span></span>

![スタート メニューに表示されたパッケージ アプリ](images/desktop-to-uwp/converted-app-installed.png)

> [!NOTE]
> <span data-ttu-id="64921-117">パッケージ アプリは、常に対話ユーザーとして実行されます。パッケージ アプリをインストールするドライブは、NTFS 形式にフォーマットされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="64921-117">A packaged app always runs as an interactive user, and any drive that you install your packaged app on to must be formatted to NTFS format.</span></span>

## <a name="debug-your-app"></a><span data-ttu-id="64921-118">アプリのデバッグ</span><span class="sxs-lookup"><span data-stu-id="64921-118">Debug your app</span></span>

<span data-ttu-id="64921-119">アプリをデバッグする方法は、パッケージの作成に使うツールによって異なります。</span><span class="sxs-lookup"><span data-stu-id="64921-119">How you debug the app depends on what tool you used to create the package.</span></span>

<span data-ttu-id="64921-120">Visual Studio 2017 リリース 15.4 で使用可能な[新しいパッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md#new-packaging-project)を使ってパッケージを作成した場合、パッケージ プロジェクトをスタートアップ プロジェクトに設定するだけで、F5 キーを押すことでアプリをデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="64921-120">If you created your package by using the [new packaging project](desktop-to-uwp-packaging-dot-net.md#new-packaging-project) available in the 15.4 release of Visual Studio 2017, Just set the packaging project as the startup project, and then press F5 to debug your app.</span></span>

<span data-ttu-id="64921-121">その他のツールを使用してパッケージを作成した場合は、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="64921-121">If you created your package by using any other tool, follow these steps.</span></span>

1. <span data-ttu-id="64921-122">パッケージ アプリがローカル コンピューターにインストールされるように、必ず、パッケージ アプリを 1 回以上起動します。</span><span class="sxs-lookup"><span data-stu-id="64921-122">Make sure that you start your packaged app at least one time so that it's installed on your local machine.</span></span>

   <span data-ttu-id="64921-123">上の「[アプリを実行する](#run-app)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64921-123">See the [Run your app](#run-app) section above.</span></span>

2. <span data-ttu-id="64921-124">Visual Studio を起動します。</span><span class="sxs-lookup"><span data-stu-id="64921-124">Start Visual Studio.</span></span>

   <span data-ttu-id="64921-125">管理者特権でアプリをデバッグする場合は、**[管理者として実行]** オプションを使用して Visual Studio を起動します。</span><span class="sxs-lookup"><span data-stu-id="64921-125">If you want to debug your app with elevated permissions, start Visual Studio by using the **Run as Administrator** option.</span></span>

3. <span data-ttu-id="64921-126">Visual Studio で、**[デバッグ]**->**[その他のデバッグ ターゲット]**->**[インストールされているアプリケーション パッケージのデバッグ]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="64921-126">In Visual Studio, choose **Debug**->**Other Debug Targets**->**Debug Installed App Package**.</span></span>

4. <span data-ttu-id="64921-127">**[インストールされているアプリケーション パッケージのデバッグ]** リストで、目的のアプリ パッケージを選び、**[アタッチ]** ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="64921-127">In the **Installed App Packages** list, select your app package, and then choose the **Attach** button.</span></span>

#### <a name="modify-your-app-in-between-debug-sessions"></a><span data-ttu-id="64921-128">デバッグ セッションと次のデバッグ セッションの間にアプリを変更する</span><span class="sxs-lookup"><span data-stu-id="64921-128">Modify your app in between debug sessions</span></span>

<span data-ttu-id="64921-129">バグを修正するための変更をアプリに加えた場合は、MakeAppx ツールを使ってアプリを再パッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="64921-129">If you make your changes to your app to fix bugs, repackage it by using the MakeAppx tool.</span></span> <span data-ttu-id="64921-130">「[MakeAppx ツールを実行する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64921-130">See [Run the MakeAppx tool](desktop-to-uwp-manual-conversion.md#make-appx).</span></span>

### <a name="debug-the-entire-app-lifecycle"></a><span data-ttu-id="64921-131">アプリ全体のライフ サイクルについてデバッグする</span><span class="sxs-lookup"><span data-stu-id="64921-131">Debug the entire app lifecycle</span></span>

<span data-ttu-id="64921-132">場合によっては、アプリを開始する前にデバッグを行うなど、デバッグ プロセスを細かく制御する必要があります。</span><span class="sxs-lookup"><span data-stu-id="64921-132">In some cases, you might want finer-grained control over the debugging process, including the ability to debug your app before it starts.</span></span>

<span data-ttu-id="64921-133">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) を使用すると、中断、再開、終了などを含むアプリのライフ サイクルについて、完全に制御できます。</span><span class="sxs-lookup"><span data-stu-id="64921-133">You can use [PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) to get full control over app lifecycle including suspending, resuming, and termination.</span></span>

<span data-ttu-id="64921-134">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) は Windows SDK に含まれています。</span><span class="sxs-lookup"><span data-stu-id="64921-134">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) is included with the Windows SDK.</span></span>

## <a name="test-your-app"></a><span data-ttu-id="64921-135">アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="64921-135">Test your app</span></span>

<span data-ttu-id="64921-136">配布用の準備の一環として現実的な設定でアプリをテストするには、アプリに署名し、インストールすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="64921-136">To test your app in a realistic setting as you prepare for distribution, it's best to sign your app and then install it.</span></span>

### <a name="test-an-app-that-you-packaged-by-using-visual-studio"></a><span data-ttu-id="64921-137">Visual Studio を使ってパッケージ化したアプリをテストする</span><span class="sxs-lookup"><span data-stu-id="64921-137">Test an app that you packaged by using Visual Studio</span></span>

<span data-ttu-id="64921-138">Visual Studio は、テスト証明書を使ってアプリに署名します。</span><span class="sxs-lookup"><span data-stu-id="64921-138">Visual Studio signs your app by using a test certificate.</span></span> <span data-ttu-id="64921-139">その証明書は、**アプリ パッケージの作成**ウィザードにより生成される出力フォルダーに置かれます。</span><span class="sxs-lookup"><span data-stu-id="64921-139">You'll find that certificate in the output folder that the **Create App Packages** wizard generates.</span></span> <span data-ttu-id="64921-140">証明書ファイルに *.cer* 拡張子が付いている場合、アプリをテストする PC の**信頼されたルート証明機関**ストアにその証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="64921-140">The certificate file has the *.cer* extension and you'll have to install that certificate into the **Trusted Root Certification Authorities** store on the PC that you want to test your app on.</span></span> <span data-ttu-id="64921-141">「[アプリ パッケージをサイドローディングする](../packaging/packaging-uwp-apps.md#sideload-your-app-package)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64921-141">See [Sideload your package](../packaging/packaging-uwp-apps.md#sideload-your-app-package).</span></span>

### <a name="test-an-app-that-you-packaged-by-using-the-desktop-app-converter-dac"></a><span data-ttu-id="64921-142">Desktop App Converter (DAC)を使ってパッケージ化したアプリをテストする</span><span class="sxs-lookup"><span data-stu-id="64921-142">Test an app that you packaged by using the Desktop App Converter (DAC)</span></span>

<span data-ttu-id="64921-143">Desktop App Converter を使用してアプリをパッケージ化する場合は、``sign`` パラメーターを使用し、生成された証明書を使って、アプリに自動的に署名します。</span><span class="sxs-lookup"><span data-stu-id="64921-143">If you package your app by using the Desktop App Converter, you can use the ``sign`` parameter to automatically sign your app by using a generated certificate.</span></span> <span data-ttu-id="64921-144">その証明書をインストールしてから、アプリをインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="64921-144">You'll have to install that certificate, and then install the app.</span></span> <span data-ttu-id="64921-145">「[パッケージ アプリを実行する](desktop-to-uwp-run-desktop-app-converter.md#run-app)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64921-145">See [Run the packaged app](desktop-to-uwp-run-desktop-app-converter.md#run-app).</span></span>   


### <a name="manually-sign-apps-optional"></a><span data-ttu-id="64921-146">アプリに手動で署名する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="64921-146">Manually sign apps (Optional)</span></span>

<span data-ttu-id="64921-147">アプリには、手動で署名することもできます。</span><span class="sxs-lookup"><span data-stu-id="64921-147">You can also sign your app manually.</span></span> <span data-ttu-id="64921-148">その方法は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="64921-148">Here's how</span></span>

1. <span data-ttu-id="64921-149">証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="64921-149">Create a certificate.</span></span> <span data-ttu-id="64921-150">「[証明書を作成する](../packaging/create-certificate-package-signing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64921-150">See [Create a certificate](../packaging/create-certificate-package-signing.md).</span></span>

2. <span data-ttu-id="64921-151">その証明書をシステム上の証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールします。</span><span class="sxs-lookup"><span data-stu-id="64921-151">Install that certificate into the **Trusted Root** or **Trusted People** certificate store on your system.</span></span>

3. <span data-ttu-id="64921-152">その証明書を使ってアプリに署名します。「[SignTool を使ってアプリ パッケージに署名する](../packaging/sign-app-package-using-signtool.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64921-152">Sign your app by using that certificate, see [Sign an app package using SignTool](../packaging/sign-app-package-using-signtool.md).</span></span>

  > [!IMPORTANT]
  > <span data-ttu-id="64921-153">証明書の発行元名がアプリの発行者名と一致することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="64921-153">Make sure that the publisher name on your certificate matches the publisher name of your app.</span></span>

    **<span data-ttu-id="64921-154">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="64921-154">Related sample</span></span>**

    [<span data-ttu-id="64921-155">SigningCerts</span><span class="sxs-lookup"><span data-stu-id="64921-155">SigningCerts</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SigningCerts)


### <a name="test-your-app-for-windows-10-s"></a><span data-ttu-id="64921-156">アプリの Windows 10 S 対応をテストする</span><span class="sxs-lookup"><span data-stu-id="64921-156">Test your app for Windows 10 S</span></span>

<span data-ttu-id="64921-157">アプリを公開する前に、Windows 10 S を実行するデバイスでそのアプリが正しく動作することを確認してください。実際、Microsoft Store にアプリを公開する予定がある場合はこの作業を行わなければなりません。それが Microsoft Store 要件になっているためです。</span><span class="sxs-lookup"><span data-stu-id="64921-157">Before you publish your app, make sure that it will operate correctly on devices that run Windows 10 S. In fact, if you plan to publish your app to the Microsoft Store, you must do this because it is a store requirement.</span></span> <span data-ttu-id="64921-158">Windows 10 S を実行するデバイスで正しく動作しないアプリは認定されません。</span><span class="sxs-lookup"><span data-stu-id="64921-158">Apps that don't operate correctly on devices that run Windows 10 S won't be certified.</span></span>

<span data-ttu-id="64921-159">「[Windows アプリの Windows 10 S 対応をテストする](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64921-159">See [Test your Windows app for Windows 10 S](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s).</span></span>

### <a name="run-another-process-inside-the-full-trust-container"></a><span data-ttu-id="64921-160">完全な信頼コンテナー内で別のプロセスを実行する</span><span class="sxs-lookup"><span data-stu-id="64921-160">Run another process inside the full trust container</span></span>

<span data-ttu-id="64921-161">指定されたアプリ パッケージのコンテナー内でカスタムのプロセスを起動することができます。</span><span class="sxs-lookup"><span data-stu-id="64921-161">You can invoke custom processes inside the container of a specified app package.</span></span> <span data-ttu-id="64921-162">これは、シナリオをテストするために役立つ場合があります (たとえば、カスタムのテスト ハーネスがあり、アプリの出力をテストする必要がある場合など)。</span><span class="sxs-lookup"><span data-stu-id="64921-162">This can be useful for testing scenarios (for example, if you have a custom test harness and want to test output of the app).</span></span> <span data-ttu-id="64921-163">これを行うには、```Invoke-CommandInDesktopPackage``` PowerShell コマンドレットを使用します。</span><span class="sxs-lookup"><span data-stu-id="64921-163">To do so, use the ```Invoke-CommandInDesktopPackage``` PowerShell cmdlet:</span></span>

```CMD
Invoke-CommandInDesktopPackage [-PackageFamilyName] <string> [-AppId] <string> [-Command] <string> [[-Args]
    <string>]  [<CommonParameters>]
```

## <a name="next-steps"></a><span data-ttu-id="64921-164">次のステップ</span><span class="sxs-lookup"><span data-stu-id="64921-164">Next steps</span></span>

**<span data-ttu-id="64921-165">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="64921-165">Find answers to your questions</span></span>**

<span data-ttu-id="64921-166">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="64921-166">Have questions?</span></span> <span data-ttu-id="64921-167">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="64921-167">Ask us on Stack Overflow.</span></span> <span data-ttu-id="64921-168">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="64921-168">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="64921-169">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="64921-169">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="64921-170">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="64921-170">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="64921-171">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64921-171">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
