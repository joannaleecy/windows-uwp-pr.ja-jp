---
ms.assetid: 3aeddb83-5314-447b-b294-9fc28273cd39
description: Microsoft Advertising SDK をインストールする方法について説明します。
title: Microsoft Advertising SDK のインストール
ms.date: 08/23/2017
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, インストール, SDK, Advertising ライブラリ
ms.localizationpriority: medium
ms.openlocfilehash: 2066d055f7abf0e9a34e245d9c6a95e14596d362
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8939340"
---
# <a name="install-the-microsoft-advertising-sdk"></a><span data-ttu-id="c6c3a-104">Microsoft Advertising SDK のインストール</span><span class="sxs-lookup"><span data-stu-id="c6c3a-104">Install the Microsoft Advertising SDK</span></span>

<span data-ttu-id="c6c3a-105">Windows 10 用の UWP アプリで広告を表示するには、[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-105">To display ads in your UWP apps for Windows 10, install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp).</span></span> <span data-ttu-id="c6c3a-106">この SDK は、Visual Studio 2015 およびそれ以降のバージョンの拡張機能です。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-106">This SDK is an extension to Visual Studio 2015 and later versions.</span></span>

> [!NOTE]
> <span data-ttu-id="c6c3a-107">開発している場合は、JAVASCRIPT/HTML UWP アプリと Windows 10 SDK バージョン 10.0.14393 (Anniversary Update) インストールされているか、後で、する必要があります、 [WinJS](https://github.com/winjs/winjs)ライブラリもインストールします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-107">If you are developing a JavaScript/HTML UWP app and you have installed Windows 10 SDK version 10.0.14393 (Anniversary Update) or later, you must also install the [WinJS](https://github.com/winjs/winjs) library.</span></span> <span data-ttu-id="c6c3a-108">このライブラリは以前のバージョンの Windows 10 SDK に含まれていましたが、Windows 10 SDK バージョン 10.0.14393 (Anniversary Update) 以降ではこのライブラリを別個にインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-108">This library used to be included in previous versions of the Windows 10 SDK, but starting with the Windows 10 SDK version 10.0.14393 (Anniversary Update) this library must be installed separately.</span></span>

<span id="install-msi" />

## <a name="install-via-msi"></a><span data-ttu-id="c6c3a-109">MSI によるインストール</span><span class="sxs-lookup"><span data-stu-id="c6c3a-109">Install via MSI</span></span>

<span data-ttu-id="c6c3a-110">MSI インストーラーを使って Microsoft Advertising SDK をインストールするには</span><span class="sxs-lookup"><span data-stu-id="c6c3a-110">To install the Microsoft Advertising SDK via the MSI installer:</span></span>

1.  <span data-ttu-id="c6c3a-111">Visual Studio のすべてのインスタンスを閉じます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-111">Close all instances of Visual Studio.</span></span>

2. <span data-ttu-id="c6c3a-112">Microsoft Advertising SDK、Universal Ad Client SDK、Ad Mediator 拡張、または Microsoft Store Engagement and Monetization SDK の以前のバージョンを以前にインストールしていた場合は、これらの SDK のバージョンをアンインストールします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-112">If you previously installed any previous version of the Microsoft Advertising SDK, Universal Ad Client SDK, Ad Mediator extension, or Microsoft Store Engagement and Monetization SDK, uninstall these SDK versions now.</span></span> <span data-ttu-id="c6c3a-113">必要に応じて、**コマンド プロンプト** ウィンドウを開き、次のコマンドを実行して、Visual Studio と共にインストールされている可能性があり、コンピューター上のインストールされているプログラムの一覧には表示されない可能性がある、古い広告 SDK のバージョンをすべて削除します。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-113">Optionally, open a **Command Prompt** window and run these commands to clean out any older advertising SDK versions that may have been installed with Visual Studio, but which may not appear in the list of installed programs on your computer:</span></span>
    ```
    MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
    MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
    MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
    ```

3.  <span data-ttu-id="c6c3a-114">[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をダウンロードしてインストールします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-114">Download and install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp).</span></span> <span data-ttu-id="c6c3a-115">インストールには数分かかることがあります。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-115">It may take a few minutes to install.</span></span> <span data-ttu-id="c6c3a-116">確実に処理が完了するまでお待ちください。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-116">Be sure and wait until the process has finished.</span></span>

4.  <span data-ttu-id="c6c3a-117">Visual Studio を再起動します。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-117">Restart Visual Studio.</span></span>

5.  <span data-ttu-id="c6c3a-118">以前のバージョンの Microsoft Advertising SDK、Universal Ad Client SDK、Microsoft Store Engagement and Monetization SDK の Advertising ライブラリを参照する既存のプロジェクトがある場合には、Visual Studio でプロジェクトを開き、プロジェクトをクリーンしてリビルドすることをお勧めします (**ソリューション エクスプ ローラー**でプロジェクト ノードを右クリックして、**[クリーン]** を選択し、次にもう一度プロジェクト ノードを右クリックして、**[リビルド]** を選択します)。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-118">If you have an existing project that references advertising libraries from any earlier version of the Microsoft Advertising SDK, Universal Ad Client SDK, or Microsoft Store Engagement and Monetization SDK, we recommend that you open your project in Visual Studio and clean and rebuild your project (in **Solution Explorer**, right-click your project node and choose **Clean**, and then right-click your project node again and choose **Rebuild**).</span></span>

  <span data-ttu-id="c6c3a-119">または、プロジェクトで初めて Microsoft Advertising SDK を使う場合には、[Microsoft Advertising SDK への参照を追加](#reference)することができます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-119">Otherwise, if you are using the Microsoft Advertising SDK for the first time in your project, you are now ready to [add a reference to the Microsoft Advertising SDK](#reference).</span></span>

<span id="install-nuget" />

## <a name="install-via-nuget"></a><span data-ttu-id="c6c3a-120">NuGet によるインストール</span><span class="sxs-lookup"><span data-stu-id="c6c3a-120">Install via NuGet</span></span>

<span data-ttu-id="c6c3a-121">NuGet を使って特定の UWP プロジェクトに Microsoft Advertising SDK をインストールするには:</span><span class="sxs-lookup"><span data-stu-id="c6c3a-121">To install the Microsoft Advertising SDK in a specific UWP project via NuGet:</span></span>

1.  <span data-ttu-id="c6c3a-122">Visual Studio のすべてのインスタンスを閉じます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-122">Close all instances of Visual Studio.</span></span>

2.  <span data-ttu-id="c6c3a-123">Microsoft Advertising SDK、Universal Ad Client SDK、Ad Mediator 拡張、または Microsoft Store Engagement and Monetization SDK の以前のバージョンを以前にインストールしていた場合は、これらの SDK のバージョンをアンインストールします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-123">If you previously installed any previous version of the Microsoft Advertising SDK, Universal Ad Client SDK, Ad Mediator extension, or Microsoft Store Engagement and Monetization SDK, uninstall these SDK versions now.</span></span> <span data-ttu-id="c6c3a-124">必要に応じて、**コマンド プロンプト** ウィンドウを開き、次のコマンドを実行して、Visual Studio と共にインストールされている可能性があり、コンピューター上のインストールされているプログラムの一覧には表示されない可能性がある、古い広告 SDK のバージョンをすべて削除します。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-124">Optionally, open a **Command Prompt** window and run these commands to clean out any older advertising SDK versions that may have been installed with Visual Studio, but which may not appear in the list of installed programs on your computer:</span></span>
    ```
    MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
    MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
    MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
    ```

3.  <span data-ttu-id="c6c3a-125">Visual Studio を起動し、Microsoft Advertising SDK を使用するプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-125">Start Visual Studio and open the project in which you want to use the Microsoft Advertising SDK.</span></span>
    > [!NOTE]
    > <span data-ttu-id="c6c3a-126">プロジェクトに SDK の以前の MSI インストールからのライブラリの参照が既に含まれている場合は、これらの参照をプロジェクトから削除します。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-126">If your project already includes library references from an earlier MSI installation of the SDK, remove these references from your project.</span></span> <span data-ttu-id="c6c3a-127">これらの参照は、参照先のライブラリが前の手順で削除されたため、その隣に警告アイコンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-127">These references will have warning icons next to them because the libraries they reference were removed in the previous steps.</span></span>

4. <span data-ttu-id="c6c3a-128">Visual Studio で、**[プロジェクト]** と **[NuGet パッケージの管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-128">In Visual Studio, click **Project** and **Manage NuGet Packages**.</span></span>

5. <span data-ttu-id="c6c3a-129">検索ボックスに、「**Microsoft.Advertising.XAML**」(XAML プロジェクト用) または「**Microsoft.Advertising.JS**」(JavaScript/HTML プロジェクト用) と入力し、対応するパッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-129">In the search box, type **Microsoft.Advertising.XAML** (for a XAML project) or **Microsoft.Advertising.JS** (for a JavaScript/HTML project) and install the corresponding package.</span></span> <span data-ttu-id="c6c3a-130">パッケージのインストールが完了したら、ソリューションを保存します。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-130">When the package is done installing, save your solution.</span></span>
    > [!NOTE]
    > <span data-ttu-id="c6c3a-131">**[出力]** ウィンドウに、指定されたパスが長すぎることを示す*インストール パッケージ* エラーが表示されたとき、場合によっては、NuGet を構成して、既定の場所よりも短いパスで示される別の場所にパッケージを展開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-131">If the **Output** window reports an *Install-Package* error that indicates the specified path is too long, you may need to configure NuGet to extract packages to an alternate location with a shorter path than the default location.</span></span> <span data-ttu-id="c6c3a-132">これを行うには、```repositoryPath``` 値をコンピューターの nuget.config ファイルに追加し、それを短いフォルダーのパスに割り当て、そこに NuGet パッケージが展開されるようにします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-132">To do this, add the ```repositoryPath``` value to a nuget.config file on your computer and assign it to a short folder path where NuGet packages can be extracted.</span></span> <span data-ttu-id="c6c3a-133">詳しくは、NuGet ドキュメントの[この記事](http://docs.nuget.org/ndocs/consume-packages/configuring-nuget-behavior)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-133">For more information, see [this article](http://docs.nuget.org/ndocs/consume-packages/configuring-nuget-behavior) in the NuGet documentation.</span></span> <span data-ttu-id="c6c3a-134">または、Visual Studio プロジェクトを短いパスを持つ別のフォルダーに移動してみることができます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-134">Alternatively, you can try moving your Visual Studio project to an alternate folder with a shorter path.</span></span>

6. <span data-ttu-id="c6c3a-135">ソリューションを閉じ、再度開きます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-135">Close your solution and then reopen it.</span></span>

7.  <span data-ttu-id="c6c3a-136">プロジェクトが NuGet によりインストールされた以前のバージョンの Microsoft Advertising SDK のライブラリを既に参照している場合で、プロジェクトを SDK の新しいリリースに更新する場合には、プロジェクトをクリーンしてリビルドすることをお勧めします (**ソリューション エクスプローラー**でプロジェクト ノードを右クリックして、**[クリーン]** を選択し、次にもう一度プロジェクト ノードを右クリックして、**[リビルド]** を選択します)。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-136">If your project already references libraries from an earlier version of the Microsoft Advertising SDK that was installed via NuGet and you have updated your project to a newer release of the SDK, we recommend that you clean and rebuild your project (in **Solution Explorer**, right-click your project node and choose **Clean**, and then right-click your project node again and choose **Rebuild**).</span></span>

  <span data-ttu-id="c6c3a-137">または、プロジェクトで初めて Microsoft Advertising SDK を使う場合には、[Microsoft Advertising SDK への参照を追加](#reference)することができます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-137">Otherwise, if you are using the SDK for the first time in your project, you are now ready to [add a reference to the Microsoft Advertising SDK](#reference).</span></span>

<span id="reference" />

## <a name="add-a-reference-to-the-microsoft-advertising-sdk"></a><span data-ttu-id="c6c3a-138">Microsoft Advertising SDK への参照を追加する</span><span class="sxs-lookup"><span data-stu-id="c6c3a-138">Add a reference to the Microsoft Advertising SDK</span></span>

<span data-ttu-id="c6c3a-139">Microsoft Advertising SDK をインストールした後、次の手順に従ってプロジェクト内の SDK を参照すると、アドバタイズ API を使用できます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-139">After you install the Microsoft Advertising SDK, follow these instructions to reference the SDK in your project so you can use the advertising APIs.</span></span>

1. <span data-ttu-id="c6c3a-140">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-140">Open your project in Visual Studio.</span></span>
    > [!NOTE]
    > <span data-ttu-id="c6c3a-141">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-141">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="c6c3a-142">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising SDK への参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-142">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft Advertising SDK in the following steps.</span></span> <span data-ttu-id="c6c3a-143">詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-143">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

2. <span data-ttu-id="c6c3a-144">**ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-144">In **Solution Explorer**, right click **References** and select **Add Reference…**</span></span>

3. <span data-ttu-id="c6c3a-145">**[参照マネージャー]** で **[ユニバーサル Windows]** を展開して **[拡張機能]** をクリックし、**[Microsoft Advertising XAML for XAML]** (XAML アプリの場合) または **[Microsoft Advertising SDK for JavaScript]** (JavaScript と HTML を使って構築されたアプリの場合) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-145">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (for XAML apps) or **Microsoft Advertising SDK for JavaScript** (for apps built using JavaScript and HTML).</span></span>

4.  <span data-ttu-id="c6c3a-146">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-146">In **Reference Manager**, click OK.</span></span>

<span data-ttu-id="c6c3a-147">アドバタイズ API を使い始める方法を示すチュートリアルでは、次の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-147">For walkthroughs that show how to get started using the advertising APIs, see the following articles:</span></span>

* [<span data-ttu-id="c6c3a-148">スポット広告</span><span class="sxs-lookup"><span data-stu-id="c6c3a-148">Interstitial ads</span></span>](interstitial-ads.md)
* [<span data-ttu-id="c6c3a-149">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="c6c3a-149">Native ads</span></span>](native-ads.md)
* [<span data-ttu-id="c6c3a-150">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="c6c3a-150">AdControl in XAML and .NET</span></span>](adcontrol-in-xaml-and--net.md)
* [<span data-ttu-id="c6c3a-151">HTML 5 および Javascript の AdControl</span><span class="sxs-lookup"><span data-stu-id="c6c3a-151">AdControl in HTML 5 and Javascript</span></span>](adcontrol-in-html-5-and-javascript.md)

<span id="framework" />

## <a name="understanding-framework-packages-in-the-microsoft-advertising-sdk"></a><span data-ttu-id="c6c3a-152">Microsoft Advertising SDK のフレームワーク パッケージについて</span><span class="sxs-lookup"><span data-stu-id="c6c3a-152">Understanding framework packages in the Microsoft Advertising SDK</span></span>

<span data-ttu-id="c6c3a-153">(UWP アプリ用) [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) の Microsoft.Advertising.dll ライブラリは、*フレームワーク パッケージ*として構成されています。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-153">The Microsoft.Advertising.dll library in the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) (for UWP apps) is configured as a *framework package*.</span></span> <span data-ttu-id="c6c3a-154">このライブラリには、[Microsoft.Advertising](https://docs.microsoft.com/uwp/api/microsoft.advertising) のアドバタイズ API と [Microsoft.Advertising.WinRT.UI](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui) 名前空間が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-154">This library contains the advertising APIs in the [Microsoft.Advertising](https://docs.microsoft.com/uwp/api/microsoft.advertising) and [Microsoft.Advertising.WinRT.UI](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui) namespaces.</span></span>

<span data-ttu-id="c6c3a-155">このライブラリはフレームワーク パッケージであるため、このライブラリを使用するバージョンのアプリをユーザーがインストールすると、このライブラリは、修正されてパフォーマンスが向上した新しいバージョンのライブラリが公開されるたびに、ユーザーのデバイスで Windows Update によって自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-155">Because this library is a framework package, this means that after a user installs a version of your app that uses this library, this library is automatically updated on their device through Windows Update whenever we publish a new version of the library with fixes and performance improvements.</span></span> <span data-ttu-id="c6c3a-156">これにより、利用できる最新バージョンのライブラリがユーザーのデバイスに確実にインストールされます。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-156">This helps to ensure that your customers always have the latest available version of the library installed on their devices.</span></span>

<span data-ttu-id="c6c3a-157">このライブラリに新しい API や機能が導入された新しいバージョンの SDK がリリースされた場合は、これらの機能を使用するために最新バージョンの SDK をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-157">If we release a new version of the SDK that introduces new APIs or features in this library, you will need to install the latest version of the SDK to use those features.</span></span> <span data-ttu-id="c6c3a-158">このシナリオでは、更新されたアプリをストアに公開する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="c6c3a-158">In this scenario, you would also need to publish your updated app to the Store.</span></span>
