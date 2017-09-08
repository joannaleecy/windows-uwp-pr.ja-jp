---
title: "UWP ゲーム用 Visual Studio の概要"
author: KevinAsgari
description: "UWP ゲーム用に Xbox Live を有効にするように Visual Studio プロジェクトをセットアップする方法について説明します"
ms.assetid: b53bc91f-79db-4d8f-8919-b9144e2d609b
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: 9dc93bc0adf4709f586366145b5a978aa3fc2e77
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="get-started-using-visual-studio-for-uwp-games"></a><span data-ttu-id="0fe6e-104">UWP ゲーム用 Visual Studio の使用に関する概要</span><span class="sxs-lookup"><span data-stu-id="0fe6e-104">Get started using Visual Studio for UWP games</span></span>

## <a name="setup"></a><span data-ttu-id="0fe6e-105">セットアップ</span><span class="sxs-lookup"><span data-stu-id="0fe6e-105">Setup</span></span>

### <a name="software-requirements"></a><span data-ttu-id="0fe6e-106">ソフトウェア要件</span><span class="sxs-lookup"><span data-stu-id="0fe6e-106">Software Requirements</span></span>

- <span data-ttu-id="0fe6e-107">Windows オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="0fe6e-107">Windows operating system</span></span>
    - <span data-ttu-id="0fe6e-108">Windows 8.1 (開発用コンピューターとして)</span><span class="sxs-lookup"><span data-stu-id="0fe6e-108">Windows 8.1 (as development machine)</span></span>
    - <span data-ttu-id="0fe6e-109">Windows 10 (開発用/テスト用コンピューターとして)</span><span class="sxs-lookup"><span data-stu-id="0fe6e-109">Windows 10 (as development and/or test machine)</span></span>
- <span data-ttu-id="0fe6e-110">Visual Studio</span><span class="sxs-lookup"><span data-stu-id="0fe6e-110">Visual Studio</span></span>
    - <span data-ttu-id="0fe6e-111">Visual Studio 2015。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-111">Visual Studio 2015.</span></span>  <span data-ttu-id="0fe6e-112">[https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx](https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx) をご覧ください</span><span class="sxs-lookup"><span data-stu-id="0fe6e-112">See [https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx](https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx)</span></span>
        - <span data-ttu-id="0fe6e-113">Windows 10 SDK v10.0.14393.0 以降 [https://developer.microsoft.com/ja-JP/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)</span><span class="sxs-lookup"><span data-stu-id="0fe6e-113">Windows 10 SDK v10.0.14393.0 or later [https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)</span></span>

### <a name="install-the-windows-10-sdk"></a><span data-ttu-id="0fe6e-114">Windows 10 SDK をインストールする</span><span class="sxs-lookup"><span data-stu-id="0fe6e-114">Install the Windows 10 SDK</span></span>

<span data-ttu-id="0fe6e-115">Windows 10 SDK には、Windows 10 アプリを作成するための最新のヘッダー、ライブラリー、メタデータ、ツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-115">The Windows 10 SDK provides the latest headers, libraries, metadata and tools for building Windows 10 apps.</span></span> <span data-ttu-id="0fe6e-116">この SDK、最新の Visual Studio 2015 リリース、IDE 環境をインストールすることにより、新しい Windows 10 API にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-116">By installing this SDK, the latest Visual Studio 2015 release, and your IDE environment you will be able to access the new Windows 10 APIs.</span></span> <span data-ttu-id="0fe6e-117">Windows 10 SDK を使用すると、ユニバーサル Windows アプリだけでなく Windows 10 用のデスクトップ アプリも作成できます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-117">The Windows 10 SDK allows you to build Universal Windows apps as well as desktop apps for Windows 10.</span></span>

<span data-ttu-id="0fe6e-118">この SDK は、通常、Visual Studio 2015 によってインストールおよび更新されます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-118">This is typically installed and updated by Visual Studio 2015.</span></span>  <span data-ttu-id="0fe6e-119">既に Visual Studio 2015 がインストールされている場合は、メニューの [ツール]、[拡張機能と更新プログラム] の順に移動し、[更新] タブを調べて、最新の Windows SDK をインストールします。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-119">If you already have Visual Studio 2015 installed, go to the menu Tools, Extensions and Updates, and check the Updates tab to install the latest Windows SDK.</span></span>

<span data-ttu-id="0fe6e-120">Visual Studio 2015 をお持ちでない場合は、[https://developer.microsoft.com/ja-JP/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk) でスタンドアロン バージョンをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-120">Otherwise you can install a standalone version at [https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)</span></span>

### <a name="create-a-new-title-on-windows-dev-center"></a><span data-ttu-id="0fe6e-121">Windows デベロッパー センターで新しいタイトルを作成する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-121">Create a new title on Windows Dev Center</span></span>

<span data-ttu-id="0fe6e-122">Xbox Live にサインインできるようにするには、デベロッパー センターで新しい UWP タイトルを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-122">You need to create a new UWP title on Dev Center before you can sign-in to Xbox Live.</span></span>  <span data-ttu-id="0fe6e-123">実績の定義付けなど、サービス構成はタイトルに関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-123">Your service configuration, such as what Achievements are defined, are associated with a title.</span></span>

<span data-ttu-id="0fe6e-124">新しいタイトルを作成する方法については、「[新しいタイトルを作成する](create-a-new-title.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-124">See [Create A New Title](create-a-new-title.md) to learn how to create a new title.</span></span>

### <a name="configuring-your-development-device"></a><span data-ttu-id="0fe6e-125">開発用デバイスの構成</span><span class="sxs-lookup"><span data-stu-id="0fe6e-125">Configuring your development device</span></span>

<span data-ttu-id="0fe6e-126">正常に Xbox Live にログインし、さまざまな Xbox Live サービスを呼び出すことができるように、デバイスでは、次のセットアップ手順を事前に実行しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-126">The following preliminary setup steps are required on your device, so that you can successfully login with Xbox Live and call the various Xbox Live Services.</span></span>

#### <a name="set-your-sandbox"></a><span data-ttu-id="0fe6e-127">サンドボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-127">Set your sandbox</span></span>

<span data-ttu-id="0fe6e-128">サンドボックスについて詳しくは、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-128">More detail on Sandboxes is available in the [Xbox Live Sandboxes](../xbox-live-sandboxes.md) article.</span></span>  <span data-ttu-id="0fe6e-129">記事を読んでからここに戻ってくることもできますが、簡単な概要は以下で確認できます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-129">Feel free to read that article and come back here after, but a brief summary will be provided below.</span></span>

<span data-ttu-id="0fe6e-130">サンドボックスを使用すると、タイトルをリリースする準備ができるまで、[Xbox Live サービス構成](../xbox-live-service-configuration.md)を製品版から分離したままにしておくことができます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-130">Sandboxes offer a way to keep your [Xbox Live Service Configuration](../xbox-live-service-configuration.md) isolated from retail until you are ready to release your title.</span></span>  <span data-ttu-id="0fe6e-131">蓄積するデータにはサンドボックス固有のものがあります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-131">Some data that you accumulate is specific to a sandbox.</span></span>  <span data-ttu-id="0fe6e-132">たとえば、タイトルで*ヘッドショット*という統計が定義されていて、タイトルをテストしている間にユーザー アカウントにいくつかのヘッドショットが蓄積されているとします。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-132">For example let's say that your title defines a stat called *Headshots*, and you accumulate some number of Headshots in a user account while testing your title.</span></span>  <span data-ttu-id="0fe6e-133">この値は、タイトルの開発サンドボックスに固有であり、製品版のタイトルをプレイしている場合、それらのヘッドショットは繰り越されません。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-133">This value would be specific to your title's development sandbox, and if you were playing the retail version of your title, those headshots would not carry over.</span></span>

<span data-ttu-id="0fe6e-134">詳しい情報およびサンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-134">See the [Xbox Live Sandboxes](../xbox-live-sandboxes.md) article to learn more and see how to set your sandbox.</span></span>

#### <a name="sign-in-with-a-test-account"></a><span data-ttu-id="0fe6e-135">テスト アカウントによるサインイン</span><span class="sxs-lookup"><span data-stu-id="0fe6e-135">Sign-in with a test account</span></span>

<span data-ttu-id="0fe6e-136">開発サンドボックスにサインインするには、テスト アカウントを作成するか、サンドボックスにアクセスするための通常の Microsoft アカウント (MSA) をプロビジョニングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-136">To sign-in to your development sandbox, you must either create a test account, or provision a regular Microsoft Account (MSA) for access to your sandbox.</span></span>  <span data-ttu-id="0fe6e-137">これにより、開発中のタイトルに対するセキュリティが向上し、他のメリットを受けることができます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-137">This provides improved security for your titles in development, as well as some other benefits.</span></span>

<span data-ttu-id="0fe6e-138">テスト アカウントとその作成方法について詳しくは、「[Xbox Live テスト アカウント](../xbox-live-test-accounts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-138">To learn more about test accounts and how to create one, see [Xbox Live Test Accounts](../xbox-live-test-accounts.md)</span></span>

#### <a name="sdk-samples"></a><span data-ttu-id="0fe6e-139">SDK サンプル</span><span class="sxs-lookup"><span data-stu-id="0fe6e-139">SDK Samples</span></span>

<span data-ttu-id="0fe6e-140">Xbox Live API の使用方法を確認するには、SDK サンプルが適しています。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-140">The SDK samples are a good way to see how Xbox Live APIs are used.</span></span>

<span data-ttu-id="0fe6e-141">[https://github.com/Microsoft/xbox-live-samples](https://github.com/Microsoft/xbox-live-samples) の /Samples/ID@Xbox/ にあるサンプルでは、ID@Xbox プログラムの開発者が利用できる API を紹介しています。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-141">The samples found at [https://github.com/Microsoft/xbox-live-samples](https://github.com/Microsoft/xbox-live-samples) under /Samples/ID@Xbox/ showcase the APIs available to developers in the ID@Xbox program.</span></span>  

<span data-ttu-id="0fe6e-142">サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。サンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-142">To use the samples, you will need to change your sandbox to XDKS.1 See the [Xbox Live Sandboxes](../xbox-live-sandboxes.md) on how to set the sandbox.</span></span>

## <a name="visual-studio-project-setup"></a><span data-ttu-id="0fe6e-143">Visual Studio プロジェクトのセットアップ</span><span class="sxs-lookup"><span data-stu-id="0fe6e-143">Visual Studio Project Setup</span></span>

### <a name="1-create-a-blank-project"></a><span data-ttu-id="0fe6e-144">1. 空のプロジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-144">1. Create a blank project</span></span>

<span data-ttu-id="0fe6e-145">UWP アプリが既にある場合は、このステップを省略できます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-145">You can skip this step if you already have an existing UWP app.</span></span>

<span data-ttu-id="0fe6e-146">[スタート] メニューまたはタスク バーから Visual Studio 2015 を起動します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-146">Start Visual Studio 2015 from the Start Menu or the Taskbar.</span></span>  
<span data-ttu-id="0fe6e-147">Visual Studio 2015 がインストールされていない場合は、[https://www.visualstudio.com/](https://www.visualstudio.com/) で入手できます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-147">If you don't have Visual Studio 2015 installed, you can find it at [https://www.visualstudio.com/](https://www.visualstudio.com/)</span></span>

![Visual Studio の起動](../images/VisualStudioStart.png)

<span data-ttu-id="0fe6e-149">Visual Studio を起動した後、図のように **[ファイル]** -> **[新規作成]** -> **[プロジェクト]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-149">After Visual Studio starts, select **File** -> **New** -> **Project** as shown.</span></span>

![](../images/VS_new_project.png)

<span data-ttu-id="0fe6e-150">**[新しいプロジェクト]** ダイアログ ボックスが表示されたら、左側のウィンドウで **[Visual C#]**、**[Windows]**、**[ユニバーサル]** ノードを選択し、右側のウィンドウで **[空白のアプリ (ユニバーサル Windows)]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-150">When the **New Project** dialog box appears, select the **Visual C#**, **Windows**, **Universal** node in the left pane, and click **Blank App (Universal Windows)** from the right pane.</span></span>  <span data-ttu-id="0fe6e-151">ダイアログ ボックスの下部で、プロジェクトの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-151">In the lower portion of the dialog, give the project a name.</span></span>

### <a name="2-add-references-to-the-xbox-live-api-xsapi-in-your-project"></a><span data-ttu-id="0fe6e-152">2. プロジェクトで Xbox Live API (XSAPI) への参照を追加する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-152">2. Add references to the Xbox Live API (XSAPI) in your project</span></span>

<span data-ttu-id="0fe6e-153">プロジェクトから Xbox Live API を使用するには、次のいずれかを実行します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-153">To use the Xbox Live API from your project, do one of these:</span></span>

* <span data-ttu-id="0fe6e-154">Xbox Live API `binaries`への参照を NuGet パッケージの形式でプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-154">Add references to Xbox Live API `binaries` to your project in the form of NuGet packages.</span></span>  <span data-ttu-id="0fe6e-155">`binaries`を参照すると、コンパイルの時間が短くなります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-155">Referencing `binaries` makes compilation quicker.</span></span>
<p/>
`or`
<p/>
* <span data-ttu-id="0fe6e-156">プロジェクトで Xbox Live API `source`への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-156">Add references to the Xbox Live API `source` to your project.</span></span>  <span data-ttu-id="0fe6e-157">`source`を参照すると、デバッグが容易になります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-157">Referencing `source` makes debugging easier.</span></span>

<span data-ttu-id="0fe6e-158">この記事では、NuGet パッケージを使用していると想定します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-158">This article will assume you're using NuGet packages.</span></span>  <span data-ttu-id="0fe6e-159">ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-159">If you want to use source, then please see [Compiling the Xbox Live APIs Source In Your UWP Project](add-xbox-live-apis-source-to-a-uwp-project.md)</span></span>

#### <a name="add-references-to-xbox-live-api-binaries-to-your-project"></a><span data-ttu-id="0fe6e-160">プロジェクトに Xbox Live API バイナリへの参照を追加する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-160">Add references to Xbox Live API binaries to your project</span></span>
<span data-ttu-id="0fe6e-161">プロジェクトに Xbox Live API NuGet パッケージへの参照を追加するには、Visual Studio の [Nuget パッケージの管理] に移動します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-161">To add references to Xbox Live API NuGet packages in your project, in Visual Studio go to "Manage Nuget Packages"</span></span>

![](../images/getting_started/first_vstitle_nuget.png)

#### <a name="locate-xbox-live"></a><span data-ttu-id="0fe6e-162">Xbox Live を検索する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-162">Locate Xbox Live</span></span>
<span data-ttu-id="0fe6e-163">NuGet の検索フィールドに "Xbox Live" (ただし引用符は付けない) と入力すると、以下に示す 4 種類の Xbox Live SDK が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-163">You can enter "Xbox Live" (without quotes) in the search field in NuGet and you will find four variants of the Xbox Live SDK shown below.</span></span>

![](../images/getting_started/first_vstitle_nuget_xbox.png)

<span data-ttu-id="0fe6e-164">Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-164">The Xbox Services API comes in flavors for both UWP and XDK, and for C++ and WinRT.</span></span>  

<span data-ttu-id="0fe6e-165">`Microsoft.Xbox.Live.SDK.*.UWP` または `Microsoft.Xbox.Live.SDK.*.XboxOneXDK` を選択します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-165">Choose between `Microsoft.Xbox.Live.SDK.*.UWP` and `Microsoft.Xbox.Live.SDK.*.XboxOneXDK`.</span></span>  `XboxOneXDK` <span data-ttu-id="0fe6e-166">は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-166">is for ID@Xbox and Managed developers who are using the Xbox One XDK.</span></span>  `UWP` <span data-ttu-id="0fe6e-167">は、PC、Xbox One、Windows Phone で実行できる UWP ゲーム用のものです。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-167">is for UWP games which can run on either PC, the Xbox One, or Windows Phone.</span></span>  <span data-ttu-id="0fe6e-168">Xbox One での UWP の実行について詳しくは、[https://docs.microsoft.com/ja-jp/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-168">You can read more about running UWP on Xbox One at [https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)</span></span>

<span data-ttu-id="0fe6e-169">`Microsoft.Xbox.Live.SDK.Cpp.*` または `Microsoft.Xbox.Live.SDK.WinRT.*` を選択します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-169">Choose between `Microsoft.Xbox.Live.SDK.Cpp.*` and `Microsoft.Xbox.Live.SDK.WinRT.*`.</span></span> `Cpp` <span data-ttu-id="0fe6e-170">は、Xbox Live API を使用している C++ ゲーム エンジン用のものです。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-170">is for C++ game engines using the Xbox Live APIs.</span></span>  `WinRT` <span data-ttu-id="0fe6e-171">は、Xbox Live API を使用し、C++、C#、または Javascript で記述されたゲーム エンジン用のものです。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-171">is for game engines written with C++, C#, or Javascript using the Xbox Live APIs.</span></span>  <span data-ttu-id="0fe6e-172">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-172">When using WinRT with a C++ engine, you would use C++/CX which uses hats (^).</span></span>  `Cpp` <span data-ttu-id="0fe6e-173">は、C++ ゲーム エンジンで使用する際に推奨される API です。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-173">is the recommended API to use for C++ game engines.</span></span>   

### <a name="optional-install-the-xbox-live-platform-extensions-sdk"></a><span data-ttu-id="0fe6e-174">(オプション) Xbox Live Platform Extensions SDK をインストールする</span><span class="sxs-lookup"><span data-stu-id="0fe6e-174">(Optional) Install the Xbox Live Platform Extensions SDK</span></span>

<span data-ttu-id="0fe6e-175">接続ストレージまたはセキュア ソケットを使用する場合は、Xbox Live Platform Extensions SDK の zip ファイルを [http://aka.ms/xblextsdk](http://aka.ms/xblextsdk) からダウンロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-175">If you want to use Connected Storage or Secure Sockets, you will need to download the Xbox Live Platform Extensions SDK zip file from [http://aka.ms/xblextsdk](http://aka.ms/xblextsdk).</span></span>

> <span data-ttu-id="0fe6e-176">**注:** Xbox Live クリエーターズ プログラムに参加している場合は、セキュア ソケットにはアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-176">**Note** If you are in the Xbox Live Creators Program, you do not have access to Secure Sockets.</span></span>  <span data-ttu-id="0fe6e-177">ただし、接続ストレージを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-177">You may use Connected Storage however.</span></span>

<span data-ttu-id="0fe6e-178">zip ファイルをダウンロードした後、任意のフォルダーに内容を展開して、MSI をインストールします。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-178">After you download the zip file, extract the contents to a folder of your choice and install the MSI.</span></span>  
<span data-ttu-id="0fe6e-179">パッケージには、UWP プラットフォーム用のネットワークのセキュリティ保護機能および接続ストレージ機能に関する winmd ファイルとドキュメントが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-179">The package contains winmd files and documentation related to Secure Networking and Connected Storage features for the UWP platform.</span></span>

<span data-ttu-id="0fe6e-180">Xbox Live Platform Extensions SDK をインストールすると、Visual Studio を使用して Extensions SDK への参照を追加し、次の名前空間をユニバーサル Windows プラットフォーム (UWP) ゲームで使用できます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-180">After you have installed the Xbox Live Platform Extensions SDK, you can use Visual Studio to add a reference to the Extensions SDK and use the following namespaces in your Universal Windows Platform (UWP) game:</span></span>

- <span data-ttu-id="0fe6e-181">Windows.Gaming.XboxLive.Storage</span><span class="sxs-lookup"><span data-stu-id="0fe6e-181">Windows.Gaming.XboxLive.Storage</span></span>
- <span data-ttu-id="0fe6e-182">Windows.Networking.XboxLive</span><span class="sxs-lookup"><span data-stu-id="0fe6e-182">Windows.Networking.XboxLive</span></span>

### <a name="3-associate-your-visual-studio-project-with-your-uwp-app"></a><span data-ttu-id="0fe6e-183">3. Visual Studio のプロジェクトと UWP アプリを関連付ける</span><span class="sxs-lookup"><span data-stu-id="0fe6e-183">3. Associate your Visual Studio project with your UWP app</span></span>

<span data-ttu-id="0fe6e-184">アプリがサインインできるようにするには、デベロッパー センターで既に作成した UWP アプリにリンクする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-184">For your app to be able to sign-in, it must be linked to the UWP app you created on Dev Center earlier.</span></span>  <span data-ttu-id="0fe6e-185">この関連付けを作成する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-185">We will show you how to make this association.</span></span>

<span data-ttu-id="0fe6e-186">**[ストア]** -> **[アプリケーションをストアと関連付ける…]** </span><span class="sxs-lookup"><span data-stu-id="0fe6e-186">If the **Store** -> **Associate App with the Store…**</span></span> <span data-ttu-id="0fe6e-187">オプションを Visual Studio で利用できる場合は、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-187">option is available in Visual Studio follow these steps:</span></span>

1.  <span data-ttu-id="0fe6e-188">Visual Studio 2015 でプロジェクトを開きます</span><span class="sxs-lookup"><span data-stu-id="0fe6e-188">Open your project in Visual Studio 2015</span></span>
1.  <span data-ttu-id="0fe6e-189">プライマリー プロジェクト (スタートアップ プロジェクト) を右クリックし、**[ストア]** -> **[アプリケーションをストアと関連付ける...]** の順にクリックします</span><span class="sxs-lookup"><span data-stu-id="0fe6e-189">Right click the primary project (the StartUp Project), click **Store** -> **Associate App with the Store...**</span></span>
1.  <span data-ttu-id="0fe6e-190">要求されたら、アプリの作成に使用した **Windows デベロッパー アカウント**でサインインします</span><span class="sxs-lookup"><span data-stu-id="0fe6e-190">Sign-in with the **Windows Developer account** used for creating the app if asked</span></span>
1.  <span data-ttu-id="0fe6e-191">次のページで、作成したアプリを選択し、情報を確認して、**[関連付け]** をクリックします</span><span class="sxs-lookup"><span data-stu-id="0fe6e-191">On the next page, select the app you just created, confirm the information, and click **Associate**</span></span>

<span data-ttu-id="0fe6e-192">**[ストア]** -> **[アプリケーションをストアと関連付ける…]** </span><span class="sxs-lookup"><span data-stu-id="0fe6e-192">If the **Store** -> **Associate App with the Store…**</span></span> <span data-ttu-id="0fe6e-193">オプションを Visual Studio で利用できない場合は、アプリのストア パッケージ ID を使用するように、アプリのパッケージ マニフェストを手動で更新することができます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-193">option is not available in Visual Studio, you can manually update the app's package manifest to use the app’s Store package identity:</span></span>

1.  <span data-ttu-id="0fe6e-194">Package.appxmanifest ファイルをテキスト エディターで開き、Identity ノードを **[アプリ名の予約]** セクションの **[アプリケーション ID]** に更新します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-194">Open your Package.appxmanifest file in a text editor and update the Identity node to the **Application Identity** from **Reserving an app name** section.</span></span>
1.  <span data-ttu-id="0fe6e-195">プロジェクトから .pfx ファイルを削除します (プロジェクトから除外するのでは不十分です)。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-195">Delete (exclusion from project is not enough) the .pfx file from the project</span></span>

### <a name="4-associate-your-visual-studio-project-with-your-xbox-live-enabled-title"></a><span data-ttu-id="0fe6e-196">4. Visual Studio のプロジェクトと Xbox Live 対応のタイトルを関連付ける</span><span class="sxs-lookup"><span data-stu-id="0fe6e-196">4. Associate your Visual Studio project with your Xbox Live enabled title</span></span>

<span data-ttu-id="0fe6e-197">これを行うには、実行時に読み取るように Xbox Live SDK の構成ファイルを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-197">To do this, you need to add a configuration file for the Xbox Live SDK to read at runtime.</span></span>

1.  <span data-ttu-id="0fe6e-198">テキスト ファイルを作成し、名前を **xboxservices.config** に設定します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-198">Create a text file and name it **xboxservices.config**.</span></span>  <span data-ttu-id="0fe6e-199">ファイル拡張子が .config であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-199">Note the file extension is .config</span></span>
1.  <span data-ttu-id="0fe6e-200">プライマリー プロジェクト (スタートアップ プロジェクト) にテキスト ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-200">Add the text file to your primary project (the StartUp Project)</span></span>
1.  <span data-ttu-id="0fe6e-201">ファイルを右クリックし、[プロパティ] を選択して、**[コンテンツ]** が **[はい]** に設定されているか、または **[ビルド アクション]** が **[コンテンツ]** に設定されていることを確認して、**[出力ディレクトリにコピー]** の **[常にコピーする]** を設定します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-201">Right click on the file, select Properties and ensure that either **Content** is **Yes** or **Build Action** is set to **Content** and set **Copy always** for **Copy to Output Directory**.</span></span>  <span data-ttu-id="0fe6e-202">これにより、ファイルは正しく AppX フォルダーにコピーされます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-202">This will ensure the file is copied correctly in the AppX folder.</span></span>
1.  <span data-ttu-id="0fe6e-203">[項目の種類] は **[ビルドに含めない]** のままで問題ありません。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-203">You can leave the Item Type to **Does not participate in build**</span></span>
1.  <span data-ttu-id="0fe6e-204">次のテンプレートを使用して JSON ファイルを編集し、TitleId と PrimaryServiceConfigId を Windows デベロッパー センターから取得した値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-204">Edit the JSON file with the following template, and replace the TitleId, PrimaryServiceConfigId with the values you get from Windows Dev Center.</span></span>  <span data-ttu-id="0fe6e-205">PrimaryServiceConfigId は、Windows デベロッパー センターでは "SCID" として表示されます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-205">The PrimaryServiceConfigId appears on Windows Dev Center as "SCID"</span></span>

```
    {
       "TitleId" : your title ID (JSON number in decimal),
       "PrimaryServiceConfigId" : "{your primary service config ID}"
    }
```

<span data-ttu-id="0fe6e-206">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-206">For example:</span></span>

```
    {
        "TitleId" : 1563044810,
        "PrimaryServiceConfigId" : "12200100-88da-4d8b-af88-e38f5d2a2bca"
    }
```

### <a name="5-if-you-plan-to-use-multiplayer-update-your-appxmanifest"></a><span data-ttu-id="0fe6e-207">5. マルチプレイヤーを使う予定の場合は、AppXManifest を更新する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-207">5. If you plan to use Multiplayer, update your AppXManifest</span></span>

<span data-ttu-id="0fe6e-208">マルチプレイヤーのサポートをタイトルに追加する予定があり、プレイヤーが他のユーザーをマルチプレイヤー ゲームに招待する機能を実装する場合は、別のフィールドを AppXManifest ファイルに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-208">If you plan to add Multiplayer support to your title, and want to implement the ability for players to invite other users for a multiplayer game, then you need to add another field to your AppXManifest file.</span></span>  <span data-ttu-id="0fe6e-209">「[マルチプレイヤー用に AppXManifest を構成する](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-209">Please see [Configure your AppXManifest For Multiplayer](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md)</span></span>

### <a name="6-add-internet-capabilities-to-your-visual-studio-project"></a><span data-ttu-id="0fe6e-210">6. インターネット機能を Visual Studio のプロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-210">6. Add Internet capabilities to your Visual Studio Project</span></span>

1. <span data-ttu-id="0fe6e-211">Visual Studio 2015 で **package.appxmanifest** ファイルをダブルクリックして、マニフェスト デザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-211">Double click on the **package.appxmanifest** file in Visual Studio 2015 to open the Manifest Designer.</span></span>
2. <span data-ttu-id="0fe6e-212">**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-212">Click on the **Capabilities** tab</span></span>
3. <span data-ttu-id="0fe6e-213">**[インターネット (クライアント)]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-213">Click on **Internet (Client)**</span></span>
4. <span data-ttu-id="0fe6e-214">ファイルを閉じて変更を保存します。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-214">Close the file and save the changes.</span></span>

### <a name="7-change-the-sandbox-of-your-target-device"></a><span data-ttu-id="0fe6e-215">7. ターゲット デバイスのサンドボックスを変更する</span><span class="sxs-lookup"><span data-stu-id="0fe6e-215">7. Change the sandbox of your target device</span></span>

<span data-ttu-id="0fe6e-216">サンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-216">See the [Xbox Live Sandboxes](../xbox-live-sandboxes.md) on how to set the sandbox.</span></span>

### <a name="8-learn-more"></a><span data-ttu-id="0fe6e-217">8. 詳細情報</span><span class="sxs-lookup"><span data-stu-id="0fe6e-217">8. Learn More</span></span>

<span data-ttu-id="0fe6e-218">[https://github.com/Microsoft/xbox-live-samples](https://github.com/Microsoft/xbox-live-samples) の /Samples/ID@Xbox/ にあるサンプルでは、ID@Xbox プログラムの開発者が利用できる API を紹介しています。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-218">The samples found at [https://github.com/Microsoft/xbox-live-samples](https://github.com/Microsoft/xbox-live-samples) under /Samples/ID@Xbox/ showcase the APIs available to developers in the ID@Xbox program.</span></span>  <span data-ttu-id="0fe6e-219">サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fe6e-219">To use the samples, you will need to change your sandbox to XDKS.1</span></span>
