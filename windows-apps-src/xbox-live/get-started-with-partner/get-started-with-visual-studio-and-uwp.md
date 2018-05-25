---
title: UWP ゲーム用 Visual Studio の概要
author: StaceyHaffner
description: UWP ゲーム用に Xbox Live を有効にするように Visual Studio プロジェクトをセットアップする方法について説明します
ms.assetid: b53bc91f-79db-4d8f-8919-b9144e2d609b
ms.author: kevinasg
ms.date: 11/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: low
ms.openlocfilehash: 70e7ffcece0245767dc964cbc4675bec4bae8e1f
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="get-started-using-visual-studio-for-uwp-games"></a><span data-ttu-id="7362d-104">UWP ゲーム用 Visual Studio の使用に関する概要</span><span class="sxs-lookup"><span data-stu-id="7362d-104">Get started using Visual Studio for UWP games</span></span>

## <a name="requirements"></a><span data-ttu-id="7362d-105">要件</span><span class="sxs-lookup"><span data-stu-id="7362d-105">Requirements</span></span>

1. <span data-ttu-id="7362d-106">**[デベロッパー センターの開発者プログラム](https://developer.microsoft.com/store/register)** に登録します。</span><span class="sxs-lookup"><span data-stu-id="7362d-106">Enrollment in the **[Dev Center developer program](https://developer.microsoft.com/store/register)**.</span></span>
2. <span data-ttu-id="7362d-107">**[Windows 10](https://microsoft.com/windows)**。</span><span class="sxs-lookup"><span data-stu-id="7362d-107">**[Windows 10](https://microsoft.com/windows)**.</span></span>
3. <span data-ttu-id="7362d-108">**ユニバーサル Windows アプリ開発ツール**を搭載した **[Visual Studio 2015](https://www.visualstudio.com/)** (またはそれ以降)。</span><span class="sxs-lookup"><span data-stu-id="7362d-108">**[Visual Studio 2015](https://www.visualstudio.com/)** (or newer) with the **Universal Windows App Development Tools**.</span></span>
4. <span data-ttu-id="7362d-109">**[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** 以降。</span><span class="sxs-lookup"><span data-stu-id="7362d-109">**[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** or later.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7362d-110">Windows 10 SDK バージョン 10.0.15063.0 (Creators Update とも呼ばれます) 以降を使っている場合は、Visual Studio 2017 が必要です。</span><span class="sxs-lookup"><span data-stu-id="7362d-110">Visual Studio 2017 is required if using Windows 10 SDK version 10.0.15063.0 (also known as Creators Update) or later.</span></span>

## <a name="create-a-new-product-on-microsoft-dev-center"></a><span data-ttu-id="7362d-111">Microsoft デベロッパー センターで新しい製品を作成する</span><span class="sxs-lookup"><span data-stu-id="7362d-111">Create a new product on Microsoft Dev Center</span></span>

<span data-ttu-id="7362d-112">すべての Xbox Live タイトルには、[Microsoft デベロッパー センター](https://developer.microsoft.com/store)で作成された製品が必要です。これにより、サインインして Xbox Live サービスを呼び出すことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="7362d-112">Every Xbox Live title must have a product created on [Microsoft Dev Center](https://developer.microsoft.com/store) before you will be able to sign-in and make Xbox Live Service calls.</span></span> <span data-ttu-id="7362d-113">詳しくは、[UDC でのタイトルの作成に関するページ](create-a-new-title.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-113">See [Create a title on UDC](create-a-new-title.md) for more information.</span></span>

## <a name="configuring-your-development-device"></a><span data-ttu-id="7362d-114">開発用デバイスの構成</span><span class="sxs-lookup"><span data-stu-id="7362d-114">Configuring your development device</span></span>

<span data-ttu-id="7362d-115">正常に Xbox Live にログインし、さまざまな Xbox Live サービスを呼び出すことができるように、デバイスでは、次のセットアップ手順を事前に実行しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-115">The following preliminary setup steps are required on your device, so that you can successfully login with Xbox Live and call the various Xbox Live Services.</span></span>

### <a name="set-your-sandbox"></a><span data-ttu-id="7362d-116">サンドボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="7362d-116">Set your sandbox</span></span>

<span data-ttu-id="7362d-117">サンドボックスを使用すると、タイトルをリリースする準備ができるまで、[Xbox Live サービス構成](../xbox-live-service-configuration.md)を製品版から分離したままにしておくことができます。</span><span class="sxs-lookup"><span data-stu-id="7362d-117">Sandboxes offer a way to keep your [Xbox Live Service Configuration](../xbox-live-service-configuration.md) isolated from retail until you are ready to release your title.</span></span> <span data-ttu-id="7362d-118">蓄積するデータにはサンドボックス固有のものがあります。</span><span class="sxs-lookup"><span data-stu-id="7362d-118">Some data that you accumulate is specific to a sandbox.</span></span> <span data-ttu-id="7362d-119">たとえば、タイトルで*ヘッドショット*という統計が定義されていて、タイトルをテストしている間にユーザー アカウントにいくつかのヘッドショットが蓄積されているとします。</span><span class="sxs-lookup"><span data-stu-id="7362d-119">For example let's say that your title defines a stat called *Headshots*, and you accumulate some number of Headshots in a user account while testing your title.</span></span> <span data-ttu-id="7362d-120">この値は、タイトルの開発サンドボックスに固有であり、製品版のタイトルのプレイに切り替えた場合、ヘッドショットは繰り越されません。</span><span class="sxs-lookup"><span data-stu-id="7362d-120">This value would be specific to your title's development sandbox, and if you switched to playing the retail version of your title, the headshots would not carry over.</span></span>

<span data-ttu-id="7362d-121">詳しい情報およびサンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-121">See the [Xbox Live Sandboxes](../xbox-live-sandboxes.md) article to learn more and see how to set your sandbox.</span></span>

### <a name="sign-in-with-a-test-account"></a><span data-ttu-id="7362d-122">テスト アカウントによるサインイン</span><span class="sxs-lookup"><span data-stu-id="7362d-122">Sign-in with a test account</span></span>

<span data-ttu-id="7362d-123">開発サンドボックスにサインインするには、テスト アカウントを作成するか、サンドボックスにアクセスするための通常の Microsoft アカウント (MSA) をプロビジョニングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-123">To sign-in to your development sandbox, you must either create a test account, or provision a regular Microsoft Account (MSA) for access to your sandbox.</span></span> <span data-ttu-id="7362d-124">これにより、開発中のタイトルに対するセキュリティが向上し、他のメリットを受けることができます。</span><span class="sxs-lookup"><span data-stu-id="7362d-124">This provides improved security for your titles in development, as well as some other benefits.</span></span>

<span data-ttu-id="7362d-125">テスト アカウントとその作成方法について詳しくは、「[Xbox Live テスト アカウント](../xbox-live-test-accounts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-125">To learn more about test accounts and how to create one, see [Xbox Live Test Accounts](../xbox-live-test-accounts.md)</span></span>

## <a name="visual-studio-project-setup"></a><span data-ttu-id="7362d-126">Visual Studio プロジェクトのセットアップ</span><span class="sxs-lookup"><span data-stu-id="7362d-126">Visual Studio Project Setup</span></span>

### <a name="1-open-a-uwp-project"></a><span data-ttu-id="7362d-127">1. UWP プロジェクトを開く</span><span class="sxs-lookup"><span data-stu-id="7362d-127">1. Open a UWP project</span></span>
<span data-ttu-id="7362d-128">既存の UWP プロジェクトがない場合は、次の手順で作成できます。</span><span class="sxs-lookup"><span data-stu-id="7362d-128">If you do not already have an existing UWP project, you can create one by doing the following:</span></span>

1. <span data-ttu-id="7362d-129">Visual Studio で、**[ファイル]** > **[新規作成]** > **[プロジェクト]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="7362d-129">In Visual Studio, **File** > **New** > **Project**.</span></span>
2. <span data-ttu-id="7362d-130">**[新しいプロジェクト]** ダイアログ ボックスが表示されたら、左側のウィンドウで **[Visual C#]** > **[Windows]** > **[ユニバーサル]** ノードを選択し、右側のウィンドウで **[空白のアプリ (ユニバーサル Windows)]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7362d-130">In the **New Project** dialog box, select the **Visual C#** > **Windows** > **Universal** node in the left pane, and click **Blank App (Universal Windows)** from the right pane.</span></span> 
3. <span data-ttu-id="7362d-131">ダイアログ ボックスの下部で、プロジェクトに名前を付け、プロジェクトの場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="7362d-131">In the lower portion of the dialog, give the project a name and specify the location of the project.</span></span>
4. <span data-ttu-id="7362d-132">Windows 10 SDK のターゲット バージョンと最小バージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="7362d-132">Specify the Target Version and Minimum Version of the Windows 10 SDK.</span></span> <span data-ttu-id="7362d-133">詳しくは、「[UWP バージョンの選択](https://docs.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-133">See [Choose a UWP version](https://docs.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version) for more information.</span></span>

![VS でのプロジェクトの作成](../images/getting_started/vs-create-project.gif) 

> [!NOTE]
> <span data-ttu-id="7362d-135">Xbox Live API (XSAPI) は、バージョン 10.0.10586.0 以上でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="7362d-135">Xbox Live API (XSAPI) requires a minimum version 10.0.10586.0 or higher.</span></span>

### <a name="2-add-references-to-the-xbox-live-api-xsapi-in-your-project"></a><span data-ttu-id="7362d-136">2. プロジェクトで Xbox Live API (XSAPI) への参照を追加する</span><span class="sxs-lookup"><span data-stu-id="7362d-136">2. Add references to the Xbox Live API (XSAPI) in your project</span></span>

<span data-ttu-id="7362d-137">Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあり名前空間の構造は **Microsoft.Xbox.Live.SDK.*.UWP** と **Microsoft.Xbox.Live.SDK.*.XboxOneXDK** です。</span><span class="sxs-lookup"><span data-stu-id="7362d-137">The Xbox Services API comes in flavors for both UWP and XDK, and for C++ and WinRT and have their namespace structured as **Microsoft.Xbox.Live.SDK.*.UWP** and **Microsoft.Xbox.Live.SDK.*.XboxOneXDK**.</span></span> 

1. <span data-ttu-id="7362d-138">**UWP** は、PC、Xbox One、Windows Phone で実行できる UWP ゲームをビルドしている開発者向けのものです。</span><span class="sxs-lookup"><span data-stu-id="7362d-138">**UWP** is for developers who are building a UWP game, which can run on either PC, the Xbox One, or Windows Phone.</span></span> 
2. <span data-ttu-id="7362d-139">**XboxOneXDK** は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。</span><span class="sxs-lookup"><span data-stu-id="7362d-139">**XboxOneXDK** is for ID@Xbox and managed developers who are using the Xbox One XDK.</span></span> 
3. <span data-ttu-id="7362d-140">C++ SDK は C++ ゲーム エンジンに使用できます。 WinRT SDK は、C++、C#、JavaScript を使って記述されたゲーム エンジン用です。</span><span class="sxs-lookup"><span data-stu-id="7362d-140">The C++ SDK can be used for C++ game engines, where as the  WinRT SDK is for game engines written with C++, C#, or JavaScript.</span></span>
4. <span data-ttu-id="7362d-141">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用してください。</span><span class="sxs-lookup"><span data-stu-id="7362d-141">When using WinRT with a C++ engine, you should use C++/CX which uses hats (^).</span></span> <span data-ttu-id="7362d-142">C++ は、C++ ゲーム エンジンで使用する際に推奨される API です。</span><span class="sxs-lookup"><span data-stu-id="7362d-142">C++ is the recommended API to use for C++ game engines.</span></span>  

> [!TIP]
> <span data-ttu-id="7362d-143">Xbox One での UWP の実行について詳しくは、「[Xbox One の UWP アプリ開発の概要](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-143">You can read more about running UWP on Xbox One at [Getting started with UWP app development on Xbox One](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started).</span></span>

<span data-ttu-id="7362d-144">プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使うか API ソースを追加してバイナリへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="7362d-144">To use the Xbox Live API from your project, you can either add references to the binaries by using NuGet packages or adding the API source.</span></span> <span data-ttu-id="7362d-145">NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。</span><span class="sxs-lookup"><span data-stu-id="7362d-145">Adding NuGet packages makes compilation quicker while adding the source makes debugging easier.</span></span> <span data-ttu-id="7362d-146">この記事では、NuGet パッケージを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7362d-146">This article will walk through using NuGet packages.</span></span> <span data-ttu-id="7362d-147">ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-147">If you want to use source, then please see [Compiling the Xbox Live APIs Source In Your UWP Project](add-xbox-live-apis-source-to-a-uwp-project.md).</span></span> <span data-ttu-id="7362d-148">Xbox Live SDK NuGet パッケージは次の方法で追加できます。</span><span class="sxs-lookup"><span data-stu-id="7362d-148">You can add the Xbox Live SDK NuGet package by:</span></span>

1. <span data-ttu-id="7362d-149">Visual Studio では、**[ツール]** > **[NuGet パッケージ マネージャー]** > **[ソリューションの NuGet パッケージの管理...]** の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="7362d-149">In Visual Studio go to **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution...**.</span></span>
2. <span data-ttu-id="7362d-150">NuGet パッケージ マネージャーで、**[参照]** をクリックして検索ボックスに「**Xbox.Live.SDK**」と入力します。</span><span class="sxs-lookup"><span data-stu-id="7362d-150">In the NuGet package manager, click on **Browse** and enter **Xbox.Live.SDK** in the search box.</span></span> 
3. <span data-ttu-id="7362d-151">左側の一覧から使う Xbox Live SDK のバージョンを選びます。</span><span class="sxs-lookup"><span data-stu-id="7362d-151">Select the version of the Xbox Live SDK that you want to use from the list on the left.</span></span> <span data-ttu-id="7362d-152">この場合、Microsoft.Xbox.Live.UWP パッケージを使います。</span><span class="sxs-lookup"><span data-stu-id="7362d-152">In this case, we will use the Microsoft.Xbox.Live.SDK.WinRT.UWP package.</span></span>
3. <span data-ttu-id="7362d-153">ウィンドウの右側にある、プロジェクトの横にあるチェック ボックスをオンにして **[インストール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7362d-153">On the right side of the window, check the box next to your project and click **Install**.</span></span> 

![NuGet による XBL の追加](../images/getting_started/vs-add-nuget-xbl.gif)


> [!IMPORTANT]
> <span data-ttu-id="7362d-155">`Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、必ずプロジェクトのソースにヘッダー `#include <xsapi\services.h>` を含めてください。</span><span class="sxs-lookup"><span data-stu-id="7362d-155">For `Microsoft.Xbox.Live.SDK.Cpp.*` based projects, make sure to include the header `#include <xsapi\services.h>` in your project's source.</span></span>

### <a name="3-optional-using-connected-storage-andor-secure-sockets"></a><span data-ttu-id="7362d-156">3. (省略可能) 接続ストレージやセキュア ソケットを使う</span><span class="sxs-lookup"><span data-stu-id="7362d-156">3. (Optional) Using Connected Storage and/or Secure Sockets</span></span>
<span data-ttu-id="7362d-157">使う Windows SDK のバージョンによっては、Xbox Live の[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)やセキュア ソケットを使うために、追加のコンテンツをインストールしたり、プロジェクトに参照を手動で追加したりする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-157">Depending on the version of the Windows SDK that you are using, you may need to install additional content or manually add references to your project in order to use Xbox Live [Connected Storage](../storage-platform/connected-storage/connected-storage-technical-overview.md) or Secure Sockets.</span></span> <span data-ttu-id="7362d-158">接続ストレージ機能を使う場合、`Windows.Gaming.XboxLive.Storage` 名前空間にアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-158">If you want to use the Connected Storage feature, you will need to access the `Windows.Gaming.XboxLive.Storage` namespace.</span></span> <span data-ttu-id="7362d-159">セキュア ソケットを使う場合、`Windows.Networking.XboxLive` にアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-159">If you want to use Secure Sockets, you will need to access `Windows.Networking.XboxLive`.</span></span>

#### <a name="windows-10-sdk-version-10016299-or-higher"></a><span data-ttu-id="7362d-160">Windows 10 SDK バージョン 10.0.16299 以降</span><span class="sxs-lookup"><span data-stu-id="7362d-160">Windows 10 SDK version 10.0.16299 or higher</span></span>
<span data-ttu-id="7362d-161">Windows 10 SDK 10.0.16299 以降をターゲットとした場合、追加の作業を行わなくても接続ストレージ名前空間にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="7362d-161">If you've targeted Windows 10 SDK 10.0.16299 or higher, then you will be able to access the Connected Storage namespace without doing any additional work.</span></span> <span data-ttu-id="7362d-162">セキュア ソケットにアクセスには、**UWP 用の Windows デスクトップ拡張機能**に参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-162">To access Secure Sockets, you will need to add a reference to **Windows Desktop Extensions for UWP**.</span></span> <span data-ttu-id="7362d-163">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="7362d-163">You can do this by:</span></span>

1. <span data-ttu-id="7362d-164">**ソリューション エクスプローラー**で、**[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7362d-164">In the **Solution Explorer**, right click on the **References** node and pick **Add Reference...**</span></span> 
2. <span data-ttu-id="7362d-165">**[参照マネージャー]** ダイアログ ボックスの左側で、**[ユニバーサル Windows]** > **[拡張機能]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="7362d-165">On the left side of the **Reference Manager** dialog, select **Universal Windows** > **Extensions**.</span></span>
3. <span data-ttu-id="7362d-166">表示される一覧で、**[Windows Desktop Extensions for UWP]** を検索し、使っている Windows 10 SDK に一致するバージョンの横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="7362d-166">In the list that appears, search for **Windows Desktop Extensions for UWP** and select the checkbox next to the version that matches your Windows 10 SDK.</span></span> 
4. <span data-ttu-id="7362d-167">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7362d-167">Click **OK**.</span></span>

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-ref.png)

#### <a name="windows-10-sdk-version-10015063-or-lower"></a><span data-ttu-id="7362d-169">Windows 10 SDK バージョン 10.0.15063 以下</span><span class="sxs-lookup"><span data-stu-id="7362d-169">Windows 10 SDK version 10.0.15063 or lower</span></span>
<span data-ttu-id="7362d-170">接続ストレージまたはセキュア ソケットを使用する場合は、プロジェクトに参照を追加する前に、Xbox Live Platform Extensions SDK をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-170">If you want to use Connected Storage or Secure Sockets, you will need to install the Xbox Live Platforms Extensions SDK before you can add references to your project.</span></span> <span data-ttu-id="7362d-171">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="7362d-171">You can do this by:</span></span>

1. <span data-ttu-id="7362d-172">[Xbox Live Platform Extensions SDK](http://aka.ms/xblextsdk) をダウンロードして抽出します。</span><span class="sxs-lookup"><span data-stu-id="7362d-172">Download and extract the [Xbox Live Platform Extensions SDK](http://aka.ms/xblextsdk).</span></span>
2. <span data-ttu-id="7362d-173">抽出されたら、使っている Windows 10 SDK バージョンに対応するインクルード MSI ファイルを実行します。</span><span class="sxs-lookup"><span data-stu-id="7362d-173">Once extracted, run the included MSI file that matches the Windows 10 SDK version that you are using.</span></span> 

<span data-ttu-id="7362d-174">Xbox Live Platform Extensions SDK をインストールしたら、Visual Studio で参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-174">After you have installed the Xbox Live Platform Extensions SDK, you will need to add a reference to it in Visual Studio.</span></span> <span data-ttu-id="7362d-175">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="7362d-175">You can do this by:</span></span>

1. <span data-ttu-id="7362d-176">**ソリューション エクスプローラー**で、**[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7362d-176">In the **Solution Explorer**, right click on the **References** node and pick **Add Reference...**</span></span> 
2. <span data-ttu-id="7362d-177">**[参照マネージャー]** ダイアログ ボックスの左側で、**[ユニバーサル Windows]** > **[拡張機能]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="7362d-177">On the left side of the **Reference Manager** dialog, select **Universal Windows** > **Extensions**.</span></span>
3. <span data-ttu-id="7362d-178">表示される一覧で、**[Windows Desktop Extensions for UWP]** を検索し、使っている Windows 10 SDK に一致するバージョンの横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="7362d-178">In the list that appears, search for **Windows Desktop Extensions for UWP** and select the checkbox next to the version that matches your Windows 10 SDK.</span></span> 
4. <span data-ttu-id="7362d-179">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7362d-179">Click **OK**.</span></span>

### <a name="4-associate-your-visual-studio-project-with-your-uwp-app"></a><span data-ttu-id="7362d-180">4. Visual Studio のプロジェクトと UWP アプリを関連付ける</span><span class="sxs-lookup"><span data-stu-id="7362d-180">4. Associate your Visual Studio project with your UWP app</span></span>

<span data-ttu-id="7362d-181">ゲームがサインインするには、Microsoft デベロッパー センターで既に作成した製品に関連付けられる必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-181">For your game to be able to sign-in, it must be associated with the product you created on Microsoft Dev Center.</span></span> <span data-ttu-id="7362d-182">ゲームは、Visual Studio で Microsoft Store 関連付けウィザードを使って関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="7362d-182">You can associate your game in Visual Studio by using the Store Association wizard.</span></span> <span data-ttu-id="7362d-183">Visual Studio で、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="7362d-183">In Visual Studio, do the following:</span></span>

1.  <span data-ttu-id="7362d-184">プライマリー プロジェクト (スタートアップ プロジェクト) を右クリックし、**[Microsoft Store]** > **[アプリケーションを Microsoft Store と関連付ける...]** の順にクリックします</span><span class="sxs-lookup"><span data-stu-id="7362d-184">Right click the primary project (the StartUp Project), click **Store** > **Associate App with the Store...**</span></span>
2.  <span data-ttu-id="7362d-185">要求されたら、アプリの作成に使用した **Windows デベロッパー アカウント**でサインインし、画面の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="7362d-185">Sign-in with the **Windows Developer account** used for creating the app if asked and follow the prompts.</span></span>

> [!TIP]
> <span data-ttu-id="7362d-186">Microsoft Store 用のゲームの準備について詳しくは、「[アプリのパッケージ化](https://docs.microsoft.com/windows/uwp/packaging/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-186">See [Packaging apps](https://docs.microsoft.com/windows/uwp/packaging/) for more information on preparing your game for Windows Store.</span></span>

### <a name="5-add-internet-capabilities-to-your-visual-studio-project"></a><span data-ttu-id="7362d-187">5. インターネット機能を Visual Studio のプロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="7362d-187">5. Add Internet capabilities to your Visual Studio Project</span></span>
<span data-ttu-id="7362d-188">UWP プロジェクトが Xbox Live と通信するにはインターネット機能を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-188">Your UWP project will need to specify internet capabilities to communicate with Xbox Live.</span></span> <span data-ttu-id="7362d-189">これらのプロパティは、次の方法で設定できます。</span><span class="sxs-lookup"><span data-stu-id="7362d-189">You can set these properties by:</span></span>

1. <span data-ttu-id="7362d-190">Visual Studio で **package.appxmanifest** ファイルをダブルクリックして、**マニフェスト デザイナー**を開きます。</span><span class="sxs-lookup"><span data-stu-id="7362d-190">Double click on the **package.appxmanifest** file in Visual Studio to open the **Manifest Designer**.</span></span>
2. <span data-ttu-id="7362d-191">**[機能]** タブをクリックし、**[インターネット (クライアント)]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="7362d-191">Click on the **Capabilities** tab and check **Internet (Client)**.</span></span>

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-capability.png)

### <a name="6-associate-your-visual-studio-project-with-your-xbox-live-enabled-title"></a><span data-ttu-id="7362d-193">6. Visual Studio のプロジェクトと Xbox Live 対応のタイトルを関連付ける</span><span class="sxs-lookup"><span data-stu-id="7362d-193">6. Associate your Visual Studio project with your Xbox Live enabled title</span></span>

<span data-ttu-id="7362d-194">Xbox Live サービスと通信するには、プロジェクトにサービス構成ファイルを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-194">To talk to the Xbox Live service, you'll need to add a service configuration file to your project.</span></span> <span data-ttu-id="7362d-195">次の方法で行うと簡単です。</span><span class="sxs-lookup"><span data-stu-id="7362d-195">This can be done easily by:</span></span>

1. <span data-ttu-id="7362d-196">スタートアップ プロジェクトで、右クリックして **[追加]** > **[新しい項目]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="7362d-196">On your StartUp project, right click and select **Add** > **New Item**.</span></span>
2. <span data-ttu-id="7362d-197">種類として **[テキスト ファイル]** を選び、名前を **xboxservices.config** に設定します。</span><span class="sxs-lookup"><span data-stu-id="7362d-197">Select the **Text File** type and name it **xboxservices.config**.</span></span>
3. <span data-ttu-id="7362d-198">ファイルを右クリックして **[プロパティ]** を選び、以下の点を確認します。</span><span class="sxs-lookup"><span data-stu-id="7362d-198">Right click on the file, select **Properties** and ensure that:</span></span>
    1. <span data-ttu-id="7362d-199">**[ビルド アクション]** が **[コンテンツ]** に設定されている。</span><span class="sxs-lookup"><span data-stu-id="7362d-199">**Build Action** is set to **Content**, and</span></span>  
    2. <span data-ttu-id="7362d-200">**[出力ディレクトリにコピー]** が **[常にコピーする]** に設定されている。</span><span class="sxs-lookup"><span data-stu-id="7362d-200">**Copy to Output Directory** is set to **Copy Always**.</span></span>
5.  <span data-ttu-id="7362d-201">次のテンプレートを使用して構成ファイルを編集し、**TitleId** と **PrimaryServiceConfigId** をタイトルに適用される値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7362d-201">Edit the configuration file with the following template, replacing the **TitleId** and **PrimaryServiceConfigId** with the values applicable to your title.</span></span> <span data-ttu-id="7362d-202">Microsoft デベロッパー センターでのルート Xbox Live ページから適切な値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="7362d-202">You can get the correct values from the root Xbox Live page on Microsoft Dev Center.</span></span> <span data-ttu-id="7362d-203">**PrimaryServiceConfigId** は、Microsoft デベロッパー センターでは **SCID** として表示されます。</span><span class="sxs-lookup"><span data-stu-id="7362d-203">The **PrimaryServiceConfigId** appears on Microsoft Dev Center as **SCID**.</span></span>

```json
    {
       "TitleId" : "your title ID (JSON number in decimal)",
       "PrimaryServiceConfigId" : "your primary service config ID"
    }
```

<span data-ttu-id="7362d-204">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="7362d-204">For example:</span></span>

```json
    {
        "TitleId" : 1563044810,
        "PrimaryServiceConfigId" : "12200100-88da-4d8b-af88-e38f5d2a2bca"
    }
```

> [!TIP]
> <span data-ttu-id="7362d-205">xboxservices.config 内のすべての値で大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="7362d-205">All values inside xboxservices.config are case sensitive.</span></span> <span data-ttu-id="7362d-206">TitleID と PrimaryServiceConfigId の取得について詳しくは、「[サービス構成](../xbox-live-service-configuration.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-206">See [Service Configuration](../xbox-live-service-configuration.md) for more information on obtaining the TitleID and PrimaryServiceConfigId.</span></span>

### <a name="7-optional-add-multiplayer-capabilities"></a><span data-ttu-id="7362d-207">7. (省略可能) マルチプレイヤー機能を追加する</span><span class="sxs-lookup"><span data-stu-id="7362d-207">7. (Optional) Add multiplayer capabilities</span></span>

<span data-ttu-id="7362d-208">マルチプレイヤーのサポートをタイトルに追加する予定があり、プレイヤーが他のユーザーをマルチプレイヤー ゲームに招待する機能を実装する場合は、別のフィールドを AppXManifest ファイルに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7362d-208">If you plan to add Multiplayer support to your title, and want to implement the ability for players to invite other users for a multiplayer game, then you need to add another field to your AppXManifest file.</span></span> <span data-ttu-id="7362d-209">詳しくは、「[マルチプレイヤー用に AppXManifest を構成する](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7362d-209">See [Configure your AppXManifest For Multiplayer](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md) for more information.</span></span>

## <a name="learn-more"></a><span data-ttu-id="7362d-210">詳細情報</span><span class="sxs-lookup"><span data-stu-id="7362d-210">Learn More</span></span>

<span data-ttu-id="7362d-211">[Xbox Live SDK サンプル](https://github.com/Microsoft/xbox-live-samples)では、Xbox Live API の使用方法が示されており、ID@Xbox プログラムで開発者が利用できる API も挙げられています。</span><span class="sxs-lookup"><span data-stu-id="7362d-211">The [Xbox Live SDK samples](https://github.com/Microsoft/xbox-live-samples) are a good way to see how Xbox Live APIs are used and showcase the APIs available to developers in the ID@Xbox program.</span></span> <span data-ttu-id="7362d-212">サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。1。</span><span class="sxs-lookup"><span data-stu-id="7362d-212">To use the samples, you will need to change your sandbox to XDKS.1.</span></span> 
