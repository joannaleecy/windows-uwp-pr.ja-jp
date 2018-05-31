---
author: normesta
Description: Distribute a packaged desktop app (Desktop Bridge)
Search.Product: eADQiWindows 10XVcnh
title: パッケージ デスクトップ アプリは、Microsoft Store に公開することも、1 台以上のデバイスにサイドローディングで展開することもできます。
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: edff3787-cecb-4054-9a2d-1fbefa79efc4
ms.localizationpriority: medium
ms.openlocfilehash: 8aff2635094064c0758f9d0d2ca56b7aa73cfda1
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1816837"
---
# <a name="distribute-a-packaged-desktop-app-desktop-bridge"></a><span data-ttu-id="0f275-103">パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="0f275-103">Distribute a packaged desktop app (Desktop Bridge)</span></span>

<span data-ttu-id="0f275-104">パッケージ デスクトップ アプリは、Windows ストアに公開することも、1 台以上のデバイスにサイドローディングで展開することもできます。</span><span class="sxs-lookup"><span data-stu-id="0f275-104">Publish your packaged desktop app to a Windows store or sideload it onto one or more devices.</span></span>  

> [!NOTE]
> <span data-ttu-id="0f275-105">パッケージ アプリにユーザーを移行する方法について、計画はありますか? </span><span class="sxs-lookup"><span data-stu-id="0f275-105">Do you have a plan for how you might transition users to your packaged app?</span></span> <span data-ttu-id="0f275-106">アプリを配布する前に、このガイドの「[デスクトップ ブリッジ アプリにユーザーを移行する](#transition-users)」セクションを参照して、アイデアを得てください。</span><span class="sxs-lookup"><span data-stu-id="0f275-106">Before you distribute your app, see the [Transition users to your desktop bridge app](#transition-users) section of this guide to get some ideas.</span></span>

## <a name="distribute-your-app-by-publishing-it-to-the-microsoft-store"></a><span data-ttu-id="0f275-107">Microsoft Store に公開してアプリを配布する</span><span class="sxs-lookup"><span data-stu-id="0f275-107">Distribute your app by publishing it to the Microsoft Store</span></span>

<span data-ttu-id="0f275-108">[Microsoft Store](https://www.microsoft.com/store/apps) は、お客様がアプリを取得する場合に最も便利な方法です。</span><span class="sxs-lookup"><span data-stu-id="0f275-108">The [Microsoft Store](https://www.microsoft.com/store/apps) is a convenient way for customers to get your app.</span></span>

<span data-ttu-id="0f275-109">Microsoft Store では、幅広いお客様を対象にしてアプリを公開できます。</span><span class="sxs-lookup"><span data-stu-id="0f275-109">Publish your app to that store to reach the broadest audience.</span></span> <span data-ttu-id="0f275-110">また、組織のお客様は[ビジネス向け Microsoft Store](https://www.microsoft.com/business-store) を通じてアプリを入手し、組織内で配布できます。</span><span class="sxs-lookup"><span data-stu-id="0f275-110">Also, Also, organizational customers can acquire your app to distribute internally to their organizations through the [Microsoft Store for Business](https://www.microsoft.com/business-store).</span></span>

<span data-ttu-id="0f275-111">Microsoft Store への公開を計画していて、まだマイクロソフトにご連絡いただいていない場合は、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)にご記入ください。オンボード プロセスについて、マイクロソフトからご連絡させていただきます。</span><span class="sxs-lookup"><span data-stu-id="0f275-111">If you plan to publish to the Microsoft Store, and you haven't reached out to us yet, please fill out [this form](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge), and Microsoft will contact you to start the onboarding process.</span></span>

<span data-ttu-id="0f275-112">Microsoft Store に提出する前に、アプリに署名する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="0f275-112">You don't have to sign your app before you submit it to the store.</span></span>

>[!IMPORTANT]
> <span data-ttu-id="0f275-113">Microsoft Store にアプリを公開する場合は、Windows 10 S を実行するデバイスでアプリが正しく動作することを確認してください。これは、Store 要件です。</span><span class="sxs-lookup"><span data-stu-id="0f275-113">If you plan to publish your app to the Microsoft Store, make sure that your app operates correctly on devices that run Windows 10 S. This is a store requirement.</span></span> <span data-ttu-id="0f275-114">「[Windows アプリの Windows 10 S 対応をテストする](desktop-to-uwp-test-windows-s.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f275-114">See [Test your Windows app for Windows 10  S](desktop-to-uwp-test-windows-s.md).</span></span>

<a id="side-load" />

## <a name="distribute-your-app-without-placing-it-onto-the-microsoft-store"></a><span data-ttu-id="0f275-115">Microsoft Store に掲載せずにアプリを配布する</span><span class="sxs-lookup"><span data-stu-id="0f275-115">Distribute your app without placing it onto the Microsoft Store</span></span>

<span data-ttu-id="0f275-116">Microsoft Store を使用せずにアプリを配布する場合は、1 台または複数のデバイスにアプリを手動で配布できます。</span><span class="sxs-lookup"><span data-stu-id="0f275-116">If you'd rather distribute your app without using the store, you can manually distribute apps to one or more devices.</span></span>

<span data-ttu-id="0f275-117">この方法は、配布エクスペリエンスをきめ細かく制御する必要がある場合や、Microsoft Store の認定プロセスへの関与が望ましくない場合などに有効です。</span><span class="sxs-lookup"><span data-stu-id="0f275-117">This might make sense if you want greater control over the distribution experience or you don't want to get involved with the Microsoft Store certification process.</span></span>

<span data-ttu-id="0f275-118">アプリをストアに掲載せずに他のデバイスに配布するには、証明書を取得し、その証明書を使ってアプリに署名して、各デバイスにアプリをサイドローディング展開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f275-118">To distribute your app to other devices without placing it onto the store, you have to obtain a certificate, sign your app by using that certificate, and then sideload your app onto those devices.</span></span>

<span data-ttu-id="0f275-119">[証明書を作成](../packaging/create-certificate-package-signing.md)することも、[Verisign](https://www.verisign.com/) などのポピュラーなベンダーから取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="0f275-119">You can [create a certificate](../packaging/create-certificate-package-signing.md) or obtain one from a popular vendor such as [Verisign](https://www.verisign.com/).</span></span>

<span data-ttu-id="0f275-120">Windows 10 S を実行するデバイスへのアプリ配布を計画している場合、Microsoft Store によるアプリへの署名が必要であるため、デバイスへのアプリ配布を開始する前に、Microsoft Store 提出プロセスを実施する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f275-120">If you plan to distribute your app onto devices that run Windows 10 S, your app has to be signed by the Microsoft Store so you'll have to go through the Store submission process before you can distribute your app onto those devices.</span></span>

<span data-ttu-id="0f275-121">証明書を作成する場合は、アプリを実行する各デバイスの証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f275-121">If you create a certificate, you have to install it into the **Trusted Root** or **Trusted People** certificate store on each device that runs your app.</span></span> <span data-ttu-id="0f275-122">ポピュラーなベンダーから証明書を取得する場合、システムにはアプリの他に何もインストールする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="0f275-122">If you get a certificate from a popular vendor, you won't have to install anything onto other systems besides your app.</span></span>  

> [!IMPORTANT]
> <span data-ttu-id="0f275-123">証明書の発行元名がアプリの発行者名と一致することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="0f275-123">Make sure that the publisher name on your certificate matches the publisher name of your app.</span></span>

<span data-ttu-id="0f275-124">証明書を使ってアプリに署名する方法については、「[SignTool を使ってアプリ パッケージに署名する](../packaging/sign-app-package-using-signtool.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f275-124">To sign your app by using a certificate, see [Sign an app package using SignTool](../packaging/sign-app-package-using-signtool.md).</span></span>

<span data-ttu-id="0f275-125">他のデバイスにアプリをサイドローディング展開する方法については、「[Windows 10 での LOB アプリのサイドローディング](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f275-125">To sideload your app onto other devices, see [Sideload LOB apps in Windows 10](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10).</span></span>

**<span data-ttu-id="0f275-126">ビデオ</span><span class="sxs-lookup"><span data-stu-id="0f275-126">Videos</span></span>**

|<span data-ttu-id="0f275-127">Microsoft Store へのアプリ公開</span><span class="sxs-lookup"><span data-stu-id="0f275-127">Publish your app into the Microsoft Store</span></span> |<span data-ttu-id="0f275-128">エンタープライズ アプリの配布</span><span class="sxs-lookup"><span data-stu-id="0f275-128">Distribute an enterprise app</span></span>  |
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Windows-Store-Publication-3cWyG5WhD_5506218965"      width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Distribution-for-Enterprise-Apps-XJ5Hd5WhD_1106218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<a id="transition-users" />

## <a name="transition-users-to-your-desktop-bridge-app"></a><span data-ttu-id="0f275-129">デスクトップ ブリッジ アプリにユーザーを移行する</span><span class="sxs-lookup"><span data-stu-id="0f275-129">Transition users to your desktop bridge app</span></span>

<span data-ttu-id="0f275-130">ユーザーによってデスクトップ ブリッジ アプリが使用されるようにするには、アプリを配布する前に、パッケージ マニフェストにいくつかの拡張機能を追加することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="0f275-130">Before you distribute your app, consider adding a few extensions to your package manifest to help users get into the habit of using your desktop bridge app.</span></span> <span data-ttu-id="0f275-131">次のようなことができます。</span><span class="sxs-lookup"><span data-stu-id="0f275-131">Here's a few things you can do.</span></span>

* <span data-ttu-id="0f275-132">既存のスタート タイルとタスク バー ボタンの参照先をデスクトップ ブリッジ アプリに設定します。</span><span class="sxs-lookup"><span data-stu-id="0f275-132">Point existing Start tiles and taskbar buttons to your desktop bridge app.</span></span>
* <span data-ttu-id="0f275-133">パッケージ アプリを一連のファイルの種類に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="0f275-133">Associate your packaged app with a set of file types.</span></span>
* <span data-ttu-id="0f275-134">特定の種類のファイルが既定でデスクトップ ブリッジ アプリによって開かれるように設定します。</span><span class="sxs-lookup"><span data-stu-id="0f275-134">Make your desktop bridge app open certain types of files by default.</span></span>

<span data-ttu-id="0f275-135">拡張機能の完全な一覧と使用方法のガイダンスについては、「[アプリにユーザーを移行する](desktop-to-uwp-extensions.md#transition-users-to-your-app)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f275-135">For the complete list of extensions and the guidance for how to use them, see [Transition users to your app](desktop-to-uwp-extensions.md#transition-users-to-your-app).</span></span>

<span data-ttu-id="0f275-136">また、次のようなタスクを実行するコードをデスクトップ ブリッジ アプリに追加することも検討してください。</span><span class="sxs-lookup"><span data-stu-id="0f275-136">Also, consider adding code to your desktop bridge app that accomplishes these tasks:</span></span>

* <span data-ttu-id="0f275-137">デスクトップ ブリッジ アプリの適切なフォルダーに、デスクトップ アプリに関連付けられているユーザー データを移行します。</span><span class="sxs-lookup"><span data-stu-id="0f275-137">Migrates user data associated with your desktop app to the appropriate folder locations of your desktop bridge app.</span></span>
* <span data-ttu-id="0f275-138">アプリのデスクトップ バージョンをアンインストールするためのオプションをユーザーに示します。</span><span class="sxs-lookup"><span data-stu-id="0f275-138">Gives users the option to uninstall the desktop version of your app.</span></span>

<span data-ttu-id="0f275-139">これらのタスクについて、それぞれ説明します。</span><span class="sxs-lookup"><span data-stu-id="0f275-139">Let's talk about each one of these tasks.</span></span> <span data-ttu-id="0f275-140">ユーザー データの移行から開始します。</span><span class="sxs-lookup"><span data-stu-id="0f275-140">We'll start with user data migration.</span></span>

### <a name="migrate-user-data"></a><span data-ttu-id="0f275-141">ユーザー データの移行</span><span class="sxs-lookup"><span data-stu-id="0f275-141">Migrate user data</span></span>

<span data-ttu-id="0f275-142">ユーザー データを移行するためのコードを追加する場合、そのコードはアプリを初めて起動したときにのみ実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0f275-142">If you're going to add code that migrates user data, it's best to run that code only when the app is first started.</span></span> <span data-ttu-id="0f275-143">ユーザー データを移行する前に、ユーザーに対してダイアログ ボックスを表示して、何が起こっているか、なぜ移行が推奨されるのか、既存のデータにどのような影響があるかを説明します。</span><span class="sxs-lookup"><span data-stu-id="0f275-143">Before you migrate the users data, display a dialog box to the user that explains what is happening, why it is recommended, and what's going to happen to their existing data.</span></span>

<span data-ttu-id="0f275-144">例として、.NET ベースのデスクトップ ブリッジ アプリでの方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0f275-144">Here's an example of how you could do this in a .NET-based desktop bridge app.</span></span>

```csharp
private void MigrateUserData()
{
    String sourceDir = Environment.GetFolderPath
        (Environment.SpecialFolder.ApplicationData) + "\\AppName";

    if (sourceDir != null)
    {
        String migrateMessage =
            "Would you like to migrate your data from the previous version of this app?";

        DialogResult migrateResult = MessageBox.Show
            (migrateMessage, "Data Migration", MessageBoxButtons.YesNo);

        if (migrateResult.Equals(DialogResult.Yes))
        {
            String destinationDir =
                Windows.Storage.ApplicationData.Current.LocalFolder.Path + "\\AppName";

            Process process = new Process();
            process.StartInfo.FileName = "robocopy.exe";
            process.StartInfo.Arguments = "%LOCALAPPDATA%\\AppName " + destinationDir + " /move";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();

            if (process.ExitCode > 1)
            {
                //Migration was unsuccessful -- you can choose to block/retry/other action
            }
        }
    }
}
```

### <a name="uninstall-the-desktop-version-of-your-app"></a><span data-ttu-id="0f275-145">アプリのデスクトップ バージョンをアンインストールする</span><span class="sxs-lookup"><span data-stu-id="0f275-145">Uninstall the desktop version of your app</span></span>

<span data-ttu-id="0f275-146">先に許可を求めずにユーザーのデスクトップ アプリをアンインストールすることは、好ましくありません。</span><span class="sxs-lookup"><span data-stu-id="0f275-146">It is better not to uninstall the users desktop app without first asking them for permission.</span></span> <span data-ttu-id="0f275-147">ユーザーに許可を求めるには、そのためのダイアログ ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="0f275-147">Display a dialog box that asks the user for that permission.</span></span> <span data-ttu-id="0f275-148">ユーザーによって、アプリのデスクトップ バージョンをアンインストールしないように指定されることも考えられます。</span><span class="sxs-lookup"><span data-stu-id="0f275-148">Users might decide not to uninstall the desktop version of your app.</span></span> <span data-ttu-id="0f275-149">その場合に、デスクトップ アプリの使用をブロックするか、両方のアプリのサイド バイ サイド使用をサポートするかを決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f275-149">If that happens, you'll have to decide whether you want to block usage of the desktop app or support the side-by-side use of both apps.</span></span>

<span data-ttu-id="0f275-150">例として、.NET ベースのデスクトップ ブリッジ アプリでの方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0f275-150">Here's an example of how you could do this in a .NET-based desktop bridge app.</span></span>

<span data-ttu-id="0f275-151">このスニペットの完全なコンテキストを確認するには、「[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)」というサンプルの**MainWindow.cs** ファイルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f275-151">To view the complete context of this snippet, see the **MainWindow.cs** file of this sample [WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition).</span></span>

```csharp
private void RemoveDesktopApp()
{              
    //Typically, you can find your uninstall string at this location.
    String uninstallString = (String)Microsoft.Win32.Registry.GetValue
        (@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion" +
         @"\Uninstall\{7AD02FB8-B85E-44BC-8998-F4803BA5A0E3}\", "UninstallString", null);

    //Detect if the previous version of the Desktop App is installed.
    if (uninstallString != null)
    {
        String uninstallMessage = "To have the best experience, consider uninstalling the "
            +" previous version of this app. Would you like to do that now?";

        DialogResult uninstallResult = MessageBox.Show
            (uninstallMessage, "Uninstall the previous version", MessageBoxButtons.YesNo);

        if (uninstallResult.Equals(DialogResult.Yes))
        {
                    string[] uninstallArgs = uninstallString.Split(' ');

            Process process = new Process();
            process.StartInfo.FileName = uninstallArgs[0];
            process.StartInfo.Arguments = uninstallArgs[1];
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                //Uninstallation was unsuccessful - You can choose to block the app here.
            }
        }
    }

}
```

### <a name="video"></a><span data-ttu-id="0f275-152">ビデオ</span><span class="sxs-lookup"><span data-stu-id="0f275-152">Video</span></span>

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Transition-Taskbar-Pins-Start-Tiles-File-Type-Associations-and-Protocol-Handlers-MD5mv5WhD_2406218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="next-steps"></a><span data-ttu-id="0f275-153">次のステップ</span><span class="sxs-lookup"><span data-stu-id="0f275-153">Next steps</span></span>

**<span data-ttu-id="0f275-154">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="0f275-154">Find answers to your questions</span></span>**

<span data-ttu-id="0f275-155">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="0f275-155">Have questions?</span></span> <span data-ttu-id="0f275-156">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="0f275-156">Ask us on Stack Overflow.</span></span> <span data-ttu-id="0f275-157">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="0f275-157">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="0f275-158">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="0f275-158">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="0f275-159">Microsoft Store へのアプリの公開で問題が発生した場合は、この[ブログ投稿](https://blogs.msdn.microsoft.com/appconsult/2017/09/25/preparing-a-desktop-bridge-application-for-the-store-submission/)で役に立つヒントを参照できます。</span><span class="sxs-lookup"><span data-stu-id="0f275-159">If you encounter issues publishing your application to the Store, this [blog post](https://blogs.msdn.microsoft.com/appconsult/2017/09/25/preparing-a-desktop-bridge-application-for-the-store-submission/) contains some useful tips.</span></span>

**<span data-ttu-id="0f275-160">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="0f275-160">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="0f275-161">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f275-161">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
