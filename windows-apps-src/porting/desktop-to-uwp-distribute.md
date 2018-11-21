---
author: normesta
Description: Distribute a packaged desktop application (Desktop Bridge)
Search.Product: eADQiWindows 10XVcnh
title: Microsoft ストアまたはサイドローディングをパッケージ化されたデスクトップ アプリケーションを公開して 1 つまたは複数のデバイスにします。
ms.author: normesta
ms.date: 05/18/2018
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: edff3787-cecb-4054-9a2d-1fbefa79efc4
ms.localizationpriority: medium
ms.openlocfilehash: f79e641b377f0e34ece8f0be434fae11cba621a6
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7435427"
---
# <a name="distribute-a-packaged-desktop-application"></a><span data-ttu-id="c8c72-103">デスクトップ アプリケーションのパッケージを配布します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-103">Distribute a packaged desktop application</span></span>

<span data-ttu-id="c8c72-104">Microsoft ストアまたはサイドローディングをパッケージ化されたデスクトップ アプリケーションを公開して 1 つまたは複数のデバイスにします。</span><span class="sxs-lookup"><span data-stu-id="c8c72-104">Publish your packaged desktop application to the Microsoft Store or sideload it onto one or more devices.</span></span>  

> [!NOTE]
> <span data-ttu-id="c8c72-105">パッケージ アプリにユーザーを移行する方法を計画していますか。</span><span class="sxs-lookup"><span data-stu-id="c8c72-105">Do you have a plan for how you might transition users to your packaged application?</span></span> <span data-ttu-id="c8c72-106">アプリを配布する前に、このガイドの「[パッケージ アプリにユーザーを移行する](#transition-users)」セクションを参照して、アイデアを得てください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-106">Before you distribute your app, see the [Transition users to your packaged app](#transition-users) section of this guide to get some ideas.</span></span>

## <a name="distribute-your-application-by-publishing-it-to-the-microsoft-store"></a><span data-ttu-id="c8c72-107">Microsoft Store に公開してアプリを配布します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-107">Distribute your application by publishing it to the Microsoft Store</span></span>

<span data-ttu-id="c8c72-108">[Microsoft Store](https://www.microsoft.com/store/apps) は、お客様がアプリを取得する場合に最も便利な方法です。</span><span class="sxs-lookup"><span data-stu-id="c8c72-108">The [Microsoft Store](https://www.microsoft.com/store/apps) is a convenient way for customers to get your app.</span></span>

<span data-ttu-id="c8c72-109">幅広いお客様を対象に、Microsoft Store にアプリを公開します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-109">Publish your application to the Microsoft Store to reach the broadest audience.</span></span> <span data-ttu-id="c8c72-110">また、組織のお客様は、[ビジネス向け Microsoft ストア](https://www.microsoft.com/business-store)を通じて、組織に内部的に配布するアプリを入手できます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-110">Also, organizational customers can acquire your application to distribute internally to their organizations through the [Microsoft Store for Business](https://www.microsoft.com/business-store).</span></span>

<span data-ttu-id="c8c72-111">Microsoft Store への公開を計画している場合は、申請プロセスの一部としていくつかの追加の質問をされます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-111">If you plan to publish to the Microsoft Store, you'll be asked a few extra questions as part of the submission process.</span></span> <span data-ttu-id="c8c72-112">これは、パッケージ マニフェストが **runFullTrust** という名前の制限付き機能を宣言し、弊社でアプリケーションによるその機能の使用を承認する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="c8c72-112">That's because your package manifest declares a restricted capability named **runFullTrust**, and we need to approve your application's use of that capability.</span></span> <span data-ttu-id="c8c72-113">この要件の詳細については、「[制限付き機能](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations#restricted-capabilities)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-113">You can read more about this requirement here: [Restricted capabilities](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations#restricted-capabilities).</span></span>

<span data-ttu-id="c8c72-114">ストアに提出する前に、アプリケーションに署名する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c8c72-114">You don't have to sign your application before you submit it to the Store.</span></span>

>[!IMPORTANT]
> <span data-ttu-id="c8c72-115">Microsoft Store にアプリを公開する場合は、アプリが Windows 10 秒を実行しているデバイスで正しく動作することを確認します。これは、ストア要件です。</span><span class="sxs-lookup"><span data-stu-id="c8c72-115">If you plan to publish your application to the Microsoft Store, make sure that your application operates correctly on devices that run Windows 10 S. This is a Store requirement.</span></span> <span data-ttu-id="c8c72-116">「[Windows アプリの Windows 10 S 対応をテストする](desktop-to-uwp-test-windows-s.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-116">See [Test your Windows app for Windows 10  S](desktop-to-uwp-test-windows-s.md).</span></span>

<a id="side-load" />

## <a name="distribute-your-application-without-placing-it-onto-the-microsoft-store"></a><span data-ttu-id="c8c72-117">Microsoft Store に掲載せずにアプリを配布します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-117">Distribute your application without placing it onto the Microsoft Store</span></span>

<span data-ttu-id="c8c72-118">配布するアプリのストアを使用せず場合、は、1 つまたは複数のデバイスにアプリを手動で配布できます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-118">If you'd rather distribute your application without using the Store, you can manually distribute apps to one or more devices.</span></span>

<span data-ttu-id="c8c72-119">この方法は、配布エクスペリエンスをきめ細かく制御する必要がある場合や、Microsoft Store の認定プロセスへの関与が望ましくない場合などに有効です。</span><span class="sxs-lookup"><span data-stu-id="c8c72-119">This might make sense if you want greater control over the distribution experience or you don't want to get involved with the Microsoft Store certification process.</span></span>

<span data-ttu-id="c8c72-120">ストアに掲載せずには、他のデバイスにアプリを配布するには、証明書を取得して、それらのデバイスにアプリを使用してその証明書、サイドローディングによって、アプリケーションに署名する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8c72-120">To distribute your application to other devices without placing it in the Store, you have to obtain a certificate, sign your application by using that certificate, and then sideload your application onto those devices.</span></span>

<span data-ttu-id="c8c72-121">[証明書を作成](../packaging/create-certificate-package-signing.md)することも、[Verisign](https://www.verisign.com/) などのポピュラーなベンダーから取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-121">You can [create a certificate](../packaging/create-certificate-package-signing.md) or obtain one from a popular vendor such as [Verisign](https://www.verisign.com/).</span></span>

<span data-ttu-id="c8c72-122">Windows 10 S を実行しているデバイスにアプリを配布する場合は、それらのデバイスにアプリを配布する前に、ストアの申請プロセスを通過する必要があるため、Microsoft Store に署名するアプリケーションを持ちます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-122">If you plan to distribute your application onto devices that run Windows 10 S, your application has to be signed by the Microsoft Store so you'll have to go through the Store submission process before you can distribute your application onto those devices.</span></span>

<span data-ttu-id="c8c72-123">証明書を作成する場合は、アプリを実行する各デバイスの証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8c72-123">If you create a certificate, you have to install it into the **Trusted Root** or **Trusted People** certificate store on each device that runs your app.</span></span> <span data-ttu-id="c8c72-124">ポピュラーなベンダーから証明書を取得する場合、システムにはアプリの他に何もインストールする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c8c72-124">If you get a certificate from a popular vendor, you won't have to install anything onto other systems besides your app.</span></span>  

> [!IMPORTANT]
> <span data-ttu-id="c8c72-125">証明書の発行元名がアプリの発行者名と一致することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-125">Make sure that the publisher name on your certificate matches the publisher name of your app.</span></span>

<span data-ttu-id="c8c72-126">証明書を使って、アプリケーションの署名、 [SignTool を使用する記号アプリケーション パッケージ](../packaging/sign-app-package-using-signtool.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-126">To sign your application by using a certificate, see [Sign an application package using SignTool](../packaging/sign-app-package-using-signtool.md).</span></span>

<span data-ttu-id="c8c72-127">サイドローディングは、他のデバイスに、アプリケーションは、 [LOB アプリのサイドローディングでは、Windows 10](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-127">To sideload your application onto other devices, see [Sideload LOB apps in Windows 10](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10).</span></span>

**<span data-ttu-id="c8c72-128">ビデオ</span><span class="sxs-lookup"><span data-stu-id="c8c72-128">Videos</span></span>**

|<span data-ttu-id="c8c72-129">Microsoft Store にアプリを公開します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-129">Publish your application into the Microsoft Store</span></span> |<span data-ttu-id="c8c72-130">エンタープライズ アプリケーションを配布します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-130">Distribute an enterprise application</span></span>  |
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Windows-Store-Publication-3cWyG5WhD_5506218965"      width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Distribution-for-Enterprise-Apps-XJ5Hd5WhD_1106218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<a id="transition-users" />

## <a name="transition-users-to-your-packaged-app"></a><span data-ttu-id="c8c72-131">パッケージ アプリへのユーザーの移行</span><span class="sxs-lookup"><span data-stu-id="c8c72-131">Transition users to your packaged app</span></span>

<span data-ttu-id="c8c72-132">ユーザーによってパッケージ アプリが使用されるようにするには、アプリを配布する前に、パッケージ マニフェストにいくつかの拡張機能を追加することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-132">Before you distribute your app, consider adding a few extensions to your package manifest to help users get into the habit of using your packaged app.</span></span> <span data-ttu-id="c8c72-133">次のようなことができます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-133">Here's a few things you can do.</span></span>

* <span data-ttu-id="c8c72-134">既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する。</span><span class="sxs-lookup"><span data-stu-id="c8c72-134">Point existing Start tiles and taskbar buttons to your packaged app.</span></span>
* <span data-ttu-id="c8c72-135">パッケージ アプリを一連のファイルの種類に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-135">Associate your packaged application with a set of file types.</span></span>
* <span data-ttu-id="c8c72-136">既定では、特定の種類のファイルを開き、パッケージ化されたアプリケーションを作成します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-136">Make your packaged application open certain types of files by default.</span></span>

<span data-ttu-id="c8c72-137">拡張機能の完全な一覧と使用方法のガイダンスについては、「[アプリにユーザーを移行する](desktop-to-uwp-extensions.md#transition-users-to-your-app)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-137">For the complete list of extensions and the guidance for how to use them, see [Transition users to your app](desktop-to-uwp-extensions.md#transition-users-to-your-app).</span></span>

<span data-ttu-id="c8c72-138">また、これらのタスクを達成するパッケージ化されたアプリケーションにコードを追加することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-138">Also, consider adding code to your packaged application that accomplishes these tasks:</span></span>

* <span data-ttu-id="c8c72-139">パッケージ アプリの適切なフォルダーの場所を検査するデスクトップ アプリケーションに関連付けられているユーザー データを移行します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-139">Migrates user data associated with your desktop application to the appropriate folder locations of your packaged app.</span></span>
* <span data-ttu-id="c8c72-140">アプリのデスクトップ バージョンをアンインストールするためのオプションをユーザーに示します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-140">Gives users the option to uninstall the desktop version of your app.</span></span>

<span data-ttu-id="c8c72-141">これらのタスクについて、それぞれ説明します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-141">Let's talk about each one of these tasks.</span></span> <span data-ttu-id="c8c72-142">ユーザー データの移行から開始します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-142">We'll start with user data migration.</span></span>

### <a name="migrate-user-data"></a><span data-ttu-id="c8c72-143">ユーザー データの移行</span><span class="sxs-lookup"><span data-stu-id="c8c72-143">Migrate user data</span></span>

<span data-ttu-id="c8c72-144">ユーザー データを移行するコードを追加する場合は、アプリケーションが初めて起動したときにのみ、そのコードを実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c8c72-144">If you're going to add code that migrates user data, it's best to run that code only when the application is first started.</span></span> <span data-ttu-id="c8c72-145">ユーザー データを移行する前に、ユーザーに対してダイアログ ボックスを表示して、何が起こっているか、なぜ移行が推奨されるのか、既存のデータにどのような影響があるかを説明します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-145">Before you migrate the users data, display a dialog box to the user that explains what is happening, why it is recommended, and what's going to happen to their existing data.</span></span>

<span data-ttu-id="c8c72-146">例として、.NET ベースのパッケージ アプリでの方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-146">Here's an example of how you could do this in a .NET-based packaged app.</span></span>

```csharp
private void MigrateUserData()
{
    String sourceDir = Environment.GetFolderPath
        (Environment.SpecialFolder.ApplicationData) + "\\AppName";

    if (sourceDir != null)
    {
        DialogResult migrateResult = MessageBox.Show
            ("Would you like to migrate your data from the previous version of this app?",
             "Data Migration", MessageBoxButtons.YesNo);

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

### <a name="uninstall-the-desktop-version-of-your-app"></a><span data-ttu-id="c8c72-147">アプリのデスクトップ バージョンをアンインストールする</span><span class="sxs-lookup"><span data-stu-id="c8c72-147">Uninstall the desktop version of your app</span></span>

<span data-ttu-id="c8c72-148">最初にアクセス許可を求めることがなく、ユーザーのデスクトップ アプリケーションをアンインストールしないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c8c72-148">It is better not to uninstall the users desktop application without first asking them for permission.</span></span> <span data-ttu-id="c8c72-149">ユーザーに許可を求めるには、そのためのダイアログ ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-149">Display a dialog box that asks the user for that permission.</span></span> <span data-ttu-id="c8c72-150">ユーザーによって、アプリのデスクトップ バージョンをアンインストールしないように指定されることも考えられます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-150">Users might decide not to uninstall the desktop version of your app.</span></span> <span data-ttu-id="c8c72-151">発生した場合は、デスクトップ アプリケーションの使用をブロックまたは両方のアプリのサイド バイ サイド使用をサポートするかどうかを決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8c72-151">If that happens, you'll have to decide whether you want to block usage of the desktop application or support the side-by-side use of both apps.</span></span>

<span data-ttu-id="c8c72-152">例として、.NET ベースのパッケージ アプリでの方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c8c72-152">Here's an example of how you could do this in a .NET-based packaged app.</span></span>

<span data-ttu-id="c8c72-153">このスニペットの完全なコンテキストを確認するには、「[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)」というサンプルの **MainWindow.cs** ファイルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-153">To view the complete context of this snippet, see the **MainWindow.cs** file of this sample [WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition).</span></span>

```csharp
private void RemoveDesktopApp()
{              
    //Typically, you can find your uninstall string at this location.
    String uninstallString = (String)Microsoft.Win32.Registry.GetValue
        (@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion" +
         @"\Uninstall\{7AD02FB8-B85E-44BC-8998-F4803BA5A0E3}\", "UninstallString", null);

    //Detect if the previous version of the Desktop application is installed.
    if (uninstallString != null)
    {
        DialogResult uninstallResult = MessageBox.Show
            ("To have the best experience, consider uninstalling the "
              + " previous version of this app. Would you like to do that now?",
              "Uninstall the previous version", MessageBoxButtons.YesNo);

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
                //Uninstallation was unsuccessful - You can choose to block the application here.
            }
        }
    }

}
```

### <a name="video"></a><span data-ttu-id="c8c72-154">ビデオ</span><span class="sxs-lookup"><span data-stu-id="c8c72-154">Video</span></span>

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Transition-Taskbar-Pins-Start-Tiles-File-Type-Associations-and-Protocol-Handlers-MD5mv5WhD_2406218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="next-steps"></a><span data-ttu-id="c8c72-155">次のステップ</span><span class="sxs-lookup"><span data-stu-id="c8c72-155">Next steps</span></span>

**<span data-ttu-id="c8c72-156">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="c8c72-156">Find answers to your questions</span></span>**

<span data-ttu-id="c8c72-157">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="c8c72-157">Have questions?</span></span> <span data-ttu-id="c8c72-158">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-158">Ask us on Stack Overflow.</span></span> <span data-ttu-id="c8c72-159">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="c8c72-159">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="c8c72-160">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-160">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="c8c72-161">Microsoft Store へのアプリの公開で問題が発生した場合は、この[ブログ投稿](https://blogs.msdn.microsoft.com/appconsult/2017/09/25/preparing-a-desktop-bridge-application-for-the-store-submission/)で役に立つヒントを参照できます。</span><span class="sxs-lookup"><span data-stu-id="c8c72-161">If you encounter issues publishing your application to the Store, this [blog post](https://blogs.msdn.microsoft.com/appconsult/2017/09/25/preparing-a-desktop-bridge-application-for-the-store-submission/) contains some useful tips.</span></span>

**<span data-ttu-id="c8c72-162">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="c8c72-162">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="c8c72-163">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8c72-163">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
