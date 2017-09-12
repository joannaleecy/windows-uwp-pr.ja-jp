---
author: mcleanbyron
ms.assetid: 3aeddb83-5314-447b-b294-9fc28273cd39
description: "Microsoft Advertising SDK をインストールする方法について説明します。"
title: "Microsoft Advertising SDK のインストール"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, インストール, SDK, Advertising ライブラリ"
ms.openlocfilehash: e953b327a32bc8385cc45190e5fd11dd5acee4b8
ms.sourcegitcommit: c5c96ec4b6ccef57f69eb341b06e6280994c9767
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/27/2017
---
# <a name="install-the-microsoft-advertising-sdk"></a><span data-ttu-id="3bf8c-104">Microsoft Advertising SDK のインストール</span><span class="sxs-lookup"><span data-stu-id="3bf8c-104">Install the Microsoft Advertising SDK</span></span>

<span data-ttu-id="3bf8c-105">Windows アプリで広告を表示するには、次の SDK のいずれかをインストールします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-105">To display ads in your Windows apps, install one of the following SDKs:</span></span>

* <span data-ttu-id="3bf8c-106">Windows 10 用の UWP アプリの場合は、[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-106">For UWP apps for Windows 10, install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp).</span></span> <span data-ttu-id="3bf8c-107">この SDK は、Visual Studio 2015 およびそれ以降のバージョンの拡張機能です。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-107">This SDK is an extension to Visual Studio 2015 and later versions.</span></span>
* <span data-ttu-id="3bf8c-108">Windows 8.1 および Windows Phone 8.x 用のアプリの場合は、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) を使用します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-108">For apps for Windows 8.1 and Windows Phone 8.x, install the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk).</span></span> <span data-ttu-id="3bf8c-109">この SDK は、Visual Studio 2015 と Visual Studio 2013 の拡張機能です。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-109">This SDK is an extension to Visual Studio 2015 and Visual Studio 2013.</span></span>

> [!NOTE]
> <span data-ttu-id="3bf8c-110">JavaScript/HTML UWP アプリを開発していて、Windows 10 SDK (14393) 以降をインストールしている場合、WinJS ライブラリもインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-110">If you are developing a JavaScript/HTML UWP app and you have installed Windows 10 SDK (14393) or later, you must also install the WinJS library.</span></span> <span data-ttu-id="3bf8c-111">このライブラリは以前のバージョンの Windows 10 SDK に含まれていましたが、Windows 10 SDK (14393) 以降ではこのライブラリを別個にインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-111">This library used to be included in previous versions of the Windows 10 SDK, but starting with the Windows 10 SDK (14393) this library must be installed separately.</span></span> <span data-ttu-id="3bf8c-112">WinJS をインストールする場合は、「[Get WinJS (WinJS を入手する)](http://try.buildwinjs.com/download/GetWinJS/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-112">To install WinJS, see [Get WinJS](http://try.buildwinjs.com/download/GetWinJS/).</span></span>

<span id="install-msi" />
## <a name="install-via-msi"></a><span data-ttu-id="3bf8c-113">MSI によるインストール</span><span class="sxs-lookup"><span data-stu-id="3bf8c-113">Install via MSI</span></span>

<span data-ttu-id="3bf8c-114">MSI インストーラーを使って Microsoft Advertising SDK をインストールするには</span><span class="sxs-lookup"><span data-stu-id="3bf8c-114">To install the Microsoft Advertising SDK via the MSI installer:</span></span>

1.  <span data-ttu-id="3bf8c-115">Visual Studio のすべてのインスタンスを閉じます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-115">Close all instances of Visual Studio.</span></span>

2. <span data-ttu-id="3bf8c-116">Microsoft Advertising SDK、Universal Ad Client SDK、Ad Mediator 拡張、または Microsoft Store Engagement and Monetization SDK の以前のバージョンを以前にインストールしていた場合は、これらの SDK のバージョンをアンインストールします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-116">If you previously installed any previous version of the Microsoft Advertising SDK, Universal Ad Client SDK, Ad Mediator extension, or Microsoft Store Engagement and Monetization SDK, uninstall these SDK versions now.</span></span> <span data-ttu-id="3bf8c-117">必要に応じて、**コマンド プロンプト** ウィンドウを開き、次のコマンドを実行して、Visual Studio と共にインストールされている可能性があり、コンピューター上のインストールされているプログラムの一覧には表示されない可能性がある、古い広告 SDK のバージョンをすべて削除します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-117">Optionally, open a **Command Prompt** window and run these commands to clean out any older advertising SDK versions that may have been installed with Visual Studio, but which may not appear in the list of installed programs on your computer:</span></span>
  ```
  MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
  MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
  MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
  ```

3.  <span data-ttu-id="3bf8c-118">[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) (Windows 10 用 UWP アプリ向け) または [Windows および Windows Phone 8.x 用 Microsoft Advertising SDK](http://aka.ms/store-8-sdk) (Windows 8.1 および Windows Phone 8.x 用 XAML および JavaScript/HTML アプリ向け) をダウンロードしてインストールします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-118">Download and install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) (for UWP apps for Windows 10) or [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk) (for XAML and JavaScript/HTML apps for Windows 8.1 and Windows Phone 8.x).</span></span> <span data-ttu-id="3bf8c-119">インストールには数分かかることがあります。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-119">It may take a few minutes to install.</span></span> <span data-ttu-id="3bf8c-120">確実に処理が完了するまでお待ちください。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-120">Be sure and wait until the process has finished.</span></span>

4.  <span data-ttu-id="3bf8c-121">Visual Studio を再起動します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-121">Restart Visual Studio.</span></span>

5.  <span data-ttu-id="3bf8c-122">以前のバージョンの Microsoft Advertising SDK、Universal Ad Client SDK、Microsoft Store Engagement and Monetization SDK の Advertising ライブラリを参照する既存のプロジェクトがある場合には、Visual Studio でプロジェクトを開き、プロジェクトをクリーンしてリビルドすることをお勧めします (**ソリューション エクスプ ローラー**でプロジェクト ノードを右クリックして、**[クリーン]** を選択し、次にもう一度プロジェクト ノードを右クリックして、**[リビルド]** を選択します)。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-122">If you have an existing project that references advertising libraries from any earlier version of the Microsoft Advertising SDK, Universal Ad Client SDK, or Microsoft Store Engagement and Monetization SDK, we recommend that you open your project in Visual Studio and clean and rebuild your project (in **Solution Explorer**, right-click your project node and choose **Clean**, and then right-click your project node again and choose **Rebuild**).</span></span>

  <span data-ttu-id="3bf8c-123">または、プロジェクトで初めて Microsoft Advertising SDK を使う場合には、[Microsoft Advertising SDK への参照を追加](#reference)することができます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-123">Otherwise, if you are using the Microsoft Advertising SDK for the first time in your project, you are now ready to [add a reference to the Microsoft Advertising SDK](#reference).</span></span>

<span id="install-nuget" />
## <a name="install-via-nuget-uwp-only"></a><span data-ttu-id="3bf8c-124">NuGet によるインストール (UWP のみ)</span><span class="sxs-lookup"><span data-stu-id="3bf8c-124">Install via NuGet (UWP only)</span></span>

<span data-ttu-id="3bf8c-125">NuGet を使って特定の UWP プロジェクトに Microsoft Advertising SDK をインストールするには</span><span class="sxs-lookup"><span data-stu-id="3bf8c-125">To install the Microsoft Advertising SDK in a specific UWP project via NuGet:</span></span>

1.  <span data-ttu-id="3bf8c-126">Visual Studio のすべてのインスタンスを閉じます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-126">Close all instances of Visual Studio.</span></span>

2.  <span data-ttu-id="3bf8c-127">Microsoft Advertising SDK、Universal Ad Client SDK、Ad Mediator 拡張、または Microsoft Store Engagement and Monetization SDK の以前のバージョンを以前にインストールしていた場合は、これらの SDK のバージョンをアンインストールします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-127">If you previously installed any previous version of the Microsoft Advertising SDK, Universal Ad Client SDK, Ad Mediator extension, or Microsoft Store Engagement and Monetization SDK, uninstall these SDK versions now.</span></span> <span data-ttu-id="3bf8c-128">必要に応じて、**コマンド プロンプト** ウィンドウを開き、次のコマンドを実行して、Visual Studio と共にインストールされている可能性があり、コンピューター上のインストールされているプログラムの一覧には表示されない可能性がある、古い広告 SDK のバージョンをすべて削除します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-128">Optionally, open a **Command Prompt** window and run these commands to clean out any older advertising SDK versions that may have been installed with Visual Studio, but which may not appear in the list of installed programs on your computer:</span></span>
  ```
  MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
  MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
  MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
  ```

3.  <span data-ttu-id="3bf8c-129">Visual Studio を起動し、Microsoft Advertising SDK を使用するプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-129">Start Visual Studio and open the project in which you want to use the Microsoft Advertising SDK.</span></span>
    > [!NOTE]
    > <span data-ttu-id="3bf8c-130">プロジェクトに SDK の以前の MSI インストールからのライブラリの参照が既に含まれている場合は、これらの参照をプロジェクトから削除します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-130">If your project already includes library references from an earlier MSI installation of the SDK, remove these references from your project.</span></span> <span data-ttu-id="3bf8c-131">これらの参照は、参照先のライブラリが前の手順で削除されたため、その隣に警告アイコンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-131">These references will have warning icons next to them because the libraries they reference were removed in the previous steps.</span></span>

4. <span data-ttu-id="3bf8c-132">Visual Studio で、**[プロジェクト]** と **[NuGet パッケージの管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-132">In Visual Studio, click **Project** and **Manage NuGet Packages**.</span></span>

5. <span data-ttu-id="3bf8c-133">検索ボックスに、「**Microsoft.Advertising.XAML**」(XAML プロジェクト用) または「**Microsoft.Advertising.JS**」(JavaScript/HTML プロジェクト用) と入力し、対応するパッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-133">In the search box, type **Microsoft.Advertising.XAML** (for a XAML project) or **Microsoft.Advertising.JS** (for a JavaScript/HTML project) and install the corresponding package.</span></span> <span data-ttu-id="3bf8c-134">パッケージのインストールが完了したら、ソリューションを保存します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-134">When the package is done installing, save your solution.</span></span>
    > [!NOTE]
    > <span data-ttu-id="3bf8c-135">**[出力]** ウィンドウに、指定されたパスが長すぎることを示す*インストール パッケージ* エラーが表示されたとき、場合によっては、NuGet を構成して、既定の場所よりも短いパスで示される別の場所にパッケージを展開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-135">If the **Output** window reports an *Install-Package* error that indicates the specified path is too long, you may need to configure NuGet to extract packages to an alternate location with a shorter path than the default location.</span></span> <span data-ttu-id="3bf8c-136">これを行うには、```repositoryPath``` 値をコンピューターの nuget.config ファイルに追加し、それを短いフォルダーのパスに割り当て、そこに NuGet パッケージが展開されるようにします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-136">To do this, add the ```repositoryPath``` value to a nuget.config file on your computer and assign it to a short folder path where NuGet packages can be extracted.</span></span> <span data-ttu-id="3bf8c-137">詳しくは、NuGet ドキュメントの[この記事](http://docs.nuget.org/ndocs/consume-packages/configuring-nuget-behavior)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-137">For more information, see [this article](http://docs.nuget.org/ndocs/consume-packages/configuring-nuget-behavior) in the NuGet documentation.</span></span> <span data-ttu-id="3bf8c-138">または、Visual Studio プロジェクトを短いパスを持つ別のフォルダーに移動してみることができます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-138">Alternatively, you can try moving your Visual Studio project to an alternate folder with a shorter path.</span></span>

6. <span data-ttu-id="3bf8c-139">ソリューションを閉じ、再度開きます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-139">Close your solution and then reopen it.</span></span>

7.  <span data-ttu-id="3bf8c-140">プロジェクトが NuGet によりインストールされた以前のバージョンの Microsoft Advertising SDK のライブラリを既に参照している場合で、プロジェクトを SDK の新しいリリースに更新する場合には、プロジェクトをクリーンしてリビルドすることをお勧めします (**ソリューション エクスプローラー**でプロジェクト ノードを右クリックして、**[クリーン]**を選択し、次にもう一度プロジェクト ノードを右クリックして、**[リビルド]** を選択します)。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-140">If your project already references libraries from an earlier version of the Microsoft Advertising SDK that was installed via NuGet and you have updated your project to a newer release of the SDK, we recommend that you clean and rebuild your project (in **Solution Explorer**, right-click your project node and choose **Clean**, and then right-click your project node again and choose **Rebuild**).</span></span>

  <span data-ttu-id="3bf8c-141">または、プロジェクトで初めて Microsoft Advertising SDK を使う場合には、[Microsoft Advertising SDK への参照を追加](#reference)することができます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-141">Otherwise, if you are using the SDK for the first time in your project, you are now ready to [add a reference to the Microsoft Advertising SDK](#reference).</span></span>

<span id="reference" />
## <a name="add-a-reference-to-the-microsoft-advertising-sdk"></a><span data-ttu-id="3bf8c-142">Microsoft Advertising SDK への参照を追加する</span><span class="sxs-lookup"><span data-stu-id="3bf8c-142">Add a reference to the Microsoft Advertising SDK</span></span>

<span data-ttu-id="3bf8c-143">Microsoft Advertising SDK をインストールした後、次の手順に従ってプロジェクト内の SDK を参照すると、アドバタイズ API を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-143">After you install the Microsoft Advertising SDK, follow these instructions to reference the SDK in your project so you can use the advertising APIs.</span></span>

1. <span data-ttu-id="3bf8c-144">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-144">Open your project in Visual Studio.</span></span>
    > [!NOTE]
    > <span data-ttu-id="3bf8c-145">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-145">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="3bf8c-146">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising SDK への参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-146">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft Advertising SDK in the following steps.</span></span> <span data-ttu-id="3bf8c-147">詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-147">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

2. <span data-ttu-id="3bf8c-148">**ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-148">In **Solution Explorer**, right click **References** and select **Add Reference…**</span></span>

3. <span data-ttu-id="3bf8c-149">**参照マネージャー**で、プロジェクトの種類に応じて次のいずれかの参照を選択します。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-149">In **Reference Manager**, select one of the following references depending on your project type:</span></span>

    -   <span data-ttu-id="3bf8c-150">ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開して **[拡張機能]** をクリックし、**[Microsoft Advertising SDK for XAML]** (XAML アプリの場合) または **[Microsoft Advertising SDK for JavaScript]** (JavaScript と HTML を使って構築されたアプリの場合) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-150">For a Universal Windows Platform (UWP) project: Expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (for XAML apps) or **Microsoft Advertising SDK for JavaScript** (for apps built using JavaScript and HTML).</span></span>

    -   <span data-ttu-id="3bf8c-151">Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開して **[拡張機能]** をクリックし、**[Ad Mediator SDK for Windows 8.1 XAML]** (XAML アプリの場合) または **[Microsoft Advertising SDK for Windows 8.1 Native (JS)]** (JavaScript と HTML を使って構築されたアプリの場合) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-151">For a Windows 8.1 project: Expand **Windows 8.1**, click **Extensions**, and then select the check box next to **Ad Mediator SDK for Windows 8.1 XAML** (for XAML apps) or **Microsoft Advertising SDK for Windows 8.1 Native (JS)** (for apps built using JavaScript and HTML).</span></span>

    -   <span data-ttu-id="3bf8c-152">Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開して **[拡張機能]** をクリックし、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** (XAML アプリの場合) または **[Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)]** (JavaScript と HTML を使って構築されたアプリの場合) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-152">For a Windows Phone 8.1 project: Expand **Windows Phone 8.1**, click **Extensions**, and then select the check box next to **Ad Mediator SDK for Windows Phone 8.1 XAML** (for XAML apps) or **Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)** (for apps built using JavaScript and HTML).</span></span>

4.  <span data-ttu-id="3bf8c-153">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-153">In **Reference Manager**, click OK.</span></span>

<span data-ttu-id="3bf8c-154">アドバタイズ API を使い始める方法を示すチュートリアルでは、次の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-154">For walkthroughs that show how to get started using the advertising APIs, see the following articles:</span></span>

* [<span data-ttu-id="3bf8c-155">スポット広告</span><span class="sxs-lookup"><span data-stu-id="3bf8c-155">Interstitial ads</span></span>](interstitial-ads.md)
* [<span data-ttu-id="3bf8c-156">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="3bf8c-156">Native ads</span></span>](native-ads.md)
* [<span data-ttu-id="3bf8c-157">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="3bf8c-157">AdControl in XAML and .NET</span></span>](adcontrol-in-xaml-and--net.md)
* [<span data-ttu-id="3bf8c-158">HTML 5 および Javascript の AdControl</span><span class="sxs-lookup"><span data-stu-id="3bf8c-158">AdControl in HTML 5 and Javascript</span></span>](adcontrol-in-html-5-and-javascript.md)

<span id="framework" />
## <a name="understanding-framework-packages-in-the-microsoft-advertising-sdk-uwp-only"></a><span data-ttu-id="3bf8c-159">Microsoft Advertising SDK (UWP only) のフレームワーク パッケージについて</span><span class="sxs-lookup"><span data-stu-id="3bf8c-159">Understanding framework packages in the Microsoft Advertising SDK (UWP only)</span></span>

<span data-ttu-id="3bf8c-160">(UWP アプリ用) [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) の Microsoft.Advertising.dll ライブラリは、*フレームワーク パッケージ*として構成されています。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-160">The Microsoft.Advertising.dll library in the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) (for UWP apps) is configured as a *framework package*.</span></span> <span data-ttu-id="3bf8c-161">このライブラリには、[Microsoft.Advertising](https://msdn.microsoft.com/library/windows/apps/mt313187.aspx) のアドバタイズ API と [Microsoft.Advertising.WinRT.UI](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.aspx) 名前空間が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-161">This library contains the advertising APIs in the [Microsoft.Advertising](https://msdn.microsoft.com/library/windows/apps/mt313187.aspx) and [Microsoft.Advertising.WinRT.UI](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.aspx) namespaces.</span></span>

<span data-ttu-id="3bf8c-162">このライブラリはフレームワーク パッケージであるため、このライブラリを使用するバージョンのアプリをユーザーがインストールすると、このライブラリは、修正されてパフォーマンスが向上した新しいバージョンのライブラリが公開されるたびに、ユーザーのデバイスで Windows Update によって自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-162">Because this library is a framework package, this means that after a user installs a version of your app that uses this library, this library is automatically updated on their device through Windows Update whenever we publish a new version of the library with fixes and performance improvements.</span></span> <span data-ttu-id="3bf8c-163">これにより、利用できる最新バージョンのライブラリがユーザーのデバイスに確実にインストールされます。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-163">This helps to ensure that your customers always have the latest available version of the library installed on their devices.</span></span>

<span data-ttu-id="3bf8c-164">このライブラリに新しい API や機能が導入された新しいバージョンの SDK がリリースされた場合は、これらの機能を使用するために最新バージョンの SDK をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-164">If we release a new version of the SDK that introduces new APIs or features in this library, you will need to install the latest version of the SDK to use those features.</span></span> <span data-ttu-id="3bf8c-165">このシナリオでは、更新されたアプリをストアに公開する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="3bf8c-165">In this scenario, you would also need to publish your updated app to the Store.</span></span>
