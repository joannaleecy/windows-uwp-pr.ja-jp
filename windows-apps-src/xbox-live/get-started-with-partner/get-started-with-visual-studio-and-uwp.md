---
title: UWP ゲーム用 Visual Studio の概要
author: KevinAsgari
description: UWP ゲーム用に Xbox Live を有効にするように Visual Studio プロジェクトをセットアップする方法について説明します
ms.assetid: b53bc91f-79db-4d8f-8919-b9144e2d609b
ms.author: kevinasg
ms.date: 11/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d727171b079bc05851e1c7ab4de6f01587ce460d
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4574748"
---
# <a name="get-started-using-visual-studio-for-uwp-games"></a><span data-ttu-id="e0db1-104">UWP ゲーム用 Visual Studio の使用に関する概要</span><span class="sxs-lookup"><span data-stu-id="e0db1-104">Get started using Visual Studio for UWP games</span></span>

## <a name="requirements"></a><span data-ttu-id="e0db1-105">要件</span><span class="sxs-lookup"><span data-stu-id="e0db1-105">Requirements</span></span>

1. <span data-ttu-id="e0db1-106">**[デベロッパー センターの開発者プログラム](https://developer.microsoft.com/store/register)** に登録します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-106">Enrollment in the **[Dev Center developer program](https://developer.microsoft.com/store/register)**.</span></span>
2. <span data-ttu-id="e0db1-107">**[Windows 10](https://microsoft.com/windows)**。</span><span class="sxs-lookup"><span data-stu-id="e0db1-107">**[Windows 10](https://microsoft.com/windows)**.</span></span>
3. <span data-ttu-id="e0db1-108">**[Visual Studio](https://www.visualstudio.com/)** の**ユニバーサル Windows アプリ開発ツール**を使用します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-108">**[Visual Studio](https://www.visualstudio.com/)** with the **Universal Windows App Development Tools**.</span></span> <span data-ttu-id="e0db1-109">UWP アプリのバージョンは、Visual Studio 2015 Update 3 を最低限に必要です。</span><span class="sxs-lookup"><span data-stu-id="e0db1-109">The minimum required version for UWP apps is Visual Studio 2015 Update 3.</span></span> <span data-ttu-id="e0db1-110">開発者とセキュリティ更新プログラムの最新リリースの Visual Studio を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-110">We recommend that you use the latest release of Visual Studio for developer and security updates.</span></span> 
4. <span data-ttu-id="e0db1-111">**[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** 以降。</span><span class="sxs-lookup"><span data-stu-id="e0db1-111">**[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** or later.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e0db1-112">Windows 10 SDK バージョン 10.0.15063.0 (Creators Update とも呼ばれます) 以降を使っている場合は、Visual Studio 2017 が必要です。</span><span class="sxs-lookup"><span data-stu-id="e0db1-112">Visual Studio 2017 is required if using Windows 10 SDK version 10.0.15063.0 (also known as Creators Update) or later.</span></span>

## <a name="create-a-new-product-on-microsoft-dev-center"></a><span data-ttu-id="e0db1-113">Microsoft デベロッパー センターで新しい製品を作成する</span><span class="sxs-lookup"><span data-stu-id="e0db1-113">Create a new product on Microsoft Dev Center</span></span>

<span data-ttu-id="e0db1-114">すべての Xbox Live タイトルには、[Microsoft デベロッパー センター](https://developer.microsoft.com/store)で作成された製品が必要です。これにより、サインインして Xbox Live サービスを呼び出すことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-114">Every Xbox Live title must have a product created on [Microsoft Dev Center](https://developer.microsoft.com/store) before you will be able to sign-in and make Xbox Live Service calls.</span></span> <span data-ttu-id="e0db1-115">詳しくは、[UDC でのタイトルの作成に関するページ](create-a-new-title.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-115">See [Create a title on UDC](create-a-new-title.md) for more information.</span></span>

## <a name="configuring-your-development-device"></a><span data-ttu-id="e0db1-116">開発用デバイスの構成</span><span class="sxs-lookup"><span data-stu-id="e0db1-116">Configuring your development device</span></span>

<span data-ttu-id="e0db1-117">正常に Xbox Live にログインし、さまざまな Xbox Live サービスを呼び出すことができるように、デバイスでは、次のセットアップ手順を事前に実行しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-117">The following preliminary setup steps are required on your device, so that you can successfully login with Xbox Live and call the various Xbox Live Services.</span></span>

### <a name="set-your-sandbox"></a><span data-ttu-id="e0db1-118">サンドボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="e0db1-118">Set your sandbox</span></span>

<span data-ttu-id="e0db1-119">サンドボックスを使用すると、タイトルをリリースする準備ができるまで、[Xbox Live サービス構成](../xbox-live-service-configuration.md)を製品版から分離したままにしておくことができます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-119">Sandboxes offer a way to keep your [Xbox Live Service Configuration](../xbox-live-service-configuration.md) isolated from retail until you are ready to release your title.</span></span> <span data-ttu-id="e0db1-120">蓄積するデータにはサンドボックス固有のものがあります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-120">Some data that you accumulate is specific to a sandbox.</span></span> <span data-ttu-id="e0db1-121">たとえば、タイトルで*ヘッドショット*という統計が定義されていて、タイトルをテストしている間にユーザー アカウントにいくつかのヘッドショットが蓄積されているとします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-121">For example let's say that your title defines a stat called *Headshots*, and you accumulate some number of Headshots in a user account while testing your title.</span></span> <span data-ttu-id="e0db1-122">この値は、タイトルの開発サンドボックスに固有であり、製品版のタイトルのプレイに切り替えた場合、ヘッドショットは繰り越されません。</span><span class="sxs-lookup"><span data-stu-id="e0db1-122">This value would be specific to your title's development sandbox, and if you switched to playing the retail version of your title, the headshots would not carry over.</span></span>

<span data-ttu-id="e0db1-123">詳しい情報およびサンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-123">See the [Xbox Live Sandboxes](../xbox-live-sandboxes.md) article to learn more and see how to set your sandbox.</span></span>

### <a name="sign-in-with-a-test-account"></a><span data-ttu-id="e0db1-124">テスト アカウントによるサインイン</span><span class="sxs-lookup"><span data-stu-id="e0db1-124">Sign-in with a test account</span></span>

<span data-ttu-id="e0db1-125">開発サンドボックスにサインインするには、テスト アカウントを作成するか、サンドボックスにアクセスするための通常の Microsoft アカウント (MSA) をプロビジョニングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-125">To sign-in to your development sandbox, you must either create a test account, or provision a regular Microsoft Account (MSA) for access to your sandbox.</span></span> <span data-ttu-id="e0db1-126">これにより、開発中のタイトルに対するセキュリティが向上し、他のメリットを受けることができます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-126">This provides improved security for your titles in development, as well as some other benefits.</span></span>

<span data-ttu-id="e0db1-127">テスト アカウントとその作成方法について詳しくは、「[Xbox Live テスト アカウント](../xbox-live-test-accounts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-127">To learn more about test accounts and how to create one, see [Xbox Live Test Accounts](../xbox-live-test-accounts.md)</span></span>

## <a name="visual-studio-project-setup"></a><span data-ttu-id="e0db1-128">Visual Studio プロジェクトのセットアップ</span><span class="sxs-lookup"><span data-stu-id="e0db1-128">Visual Studio Project Setup</span></span>

### <a name="1-open-a-uwp-project"></a><span data-ttu-id="e0db1-129">1. UWP プロジェクトを開く</span><span class="sxs-lookup"><span data-stu-id="e0db1-129">1. Open a UWP project</span></span>
<span data-ttu-id="e0db1-130">既存の UWP プロジェクトがない場合は、次の手順で作成できます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-130">If you do not already have an existing UWP project, you can create one by doing the following:</span></span>

1. <span data-ttu-id="e0db1-131">Visual Studio で、**[ファイル]** > **[新規作成]** > **[プロジェクト]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-131">In Visual Studio, **File** > **New** > **Project**.</span></span>
2. <span data-ttu-id="e0db1-132">**[新しいプロジェクト]** ダイアログ ボックスが表示されたら、左側のウィンドウで **[Visual C#]** > **[Windows]** > **[ユニバーサル]** ノードを選択し、右側のウィンドウで **[空白のアプリ (ユニバーサル Windows)]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-132">In the **New Project** dialog box, select the **Visual C#** > **Windows** > **Universal** node in the left pane, and click **Blank App (Universal Windows)** from the right pane.</span></span>
3. <span data-ttu-id="e0db1-133">ダイアログ ボックスの下部で、プロジェクトに名前を付け、プロジェクトの場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-133">In the lower portion of the dialog, give the project a name and specify the location of the project.</span></span>
4. <span data-ttu-id="e0db1-134">Windows 10 SDK のターゲット バージョンと最小バージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-134">Specify the Target Version and Minimum Version of the Windows 10 SDK.</span></span> <span data-ttu-id="e0db1-135">詳しくは、「[UWP バージョンの選択](https://docs.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-135">See [Choose a UWP version](https://docs.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version) for more information.</span></span>

![VS でのプロジェクトの作成](../images/getting_started/vs-create-project.gif)

> [!NOTE]
> <span data-ttu-id="e0db1-137">Xbox Live API (XSAPI) は、バージョン 10.0.10586.0 以上でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="e0db1-137">Xbox Live API (XSAPI) requires a minimum version 10.0.10586.0 or higher.</span></span>

### <a name="2-add-references-to-the-xbox-live-api-xsapi-in-your-project"></a><span data-ttu-id="e0db1-138">2. プロジェクトで Xbox Live API (XSAPI) への参照を追加する</span><span class="sxs-lookup"><span data-stu-id="e0db1-138">2. Add references to the Xbox Live API (XSAPI) in your project</span></span>

<span data-ttu-id="e0db1-139">Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあり名前空間の構造は **Microsoft.Xbox.Live.SDK.\*.UWP** と **Microsoft.Xbox.Live.SDK.\*.XboxOneXDK** です。</span><span class="sxs-lookup"><span data-stu-id="e0db1-139">The Xbox Services API comes in flavors for both UWP and XDK, and for C++ and WinRT and have their namespace structured as **Microsoft.Xbox.Live.SDK.\*.UWP** and **Microsoft.Xbox.Live.SDK.\*.XboxOneXDK**.</span></span>

1. <span data-ttu-id="e0db1-140">**UWP** は、PC、Xbox One、Windows Phone で実行できる UWP ゲームをビルドしている開発者向けのものです。</span><span class="sxs-lookup"><span data-stu-id="e0db1-140">**UWP** is for developers who are building a UWP game, which can run on either PC, the Xbox One, or Windows Phone.</span></span>
2. <span data-ttu-id="e0db1-141">**XboxOneXDK** は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-141">**XboxOneXDK** is for ID@Xbox and managed developers who are using the Xbox One XDK.</span></span>
3. <span data-ttu-id="e0db1-142">C++ SDK は C++ ゲーム エンジンに使用できます。 WinRT SDK は、C++、C#、JavaScript を使って記述されたゲーム エンジン用です。</span><span class="sxs-lookup"><span data-stu-id="e0db1-142">The C++ SDK can be used for C++ game engines, where as the  WinRT SDK is for game engines written with C++, C#, or JavaScript.</span></span>
4. <span data-ttu-id="e0db1-143">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用してください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-143">When using WinRT with a C++ engine, you should use C++/CX which uses hats (^).</span></span> <span data-ttu-id="e0db1-144">C++ は、C++ ゲーム エンジンで使用する際に推奨される API です。</span><span class="sxs-lookup"><span data-stu-id="e0db1-144">C++ is the recommended API to use for C++ game engines.</span></span>  

> [!TIP]
> <span data-ttu-id="e0db1-145">Xbox One での UWP の実行について詳しくは、「[Xbox One の UWP アプリ開発の概要](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-145">You can read more about running UWP on Xbox One at [Getting started with UWP app development on Xbox One](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started).</span></span>

<span data-ttu-id="e0db1-146">プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使うか API ソースを追加してバイナリへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-146">To use the Xbox Live API from your project, you can either add references to the binaries by using NuGet packages or adding the API source.</span></span> <span data-ttu-id="e0db1-147">NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-147">Adding NuGet packages makes compilation quicker while adding the source makes debugging easier.</span></span> <span data-ttu-id="e0db1-148">この記事では、NuGet パッケージを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-148">This article will walk through using NuGet packages.</span></span> <span data-ttu-id="e0db1-149">ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-149">If you want to use source, then please see [Compiling the Xbox Live APIs Source In Your UWP Project](add-xbox-live-apis-source-to-a-uwp-project.md).</span></span> <span data-ttu-id="e0db1-150">Xbox Live SDK NuGet パッケージは次の方法で追加できます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-150">You can add the Xbox Live SDK NuGet package by:</span></span>

1. <span data-ttu-id="e0db1-151">Visual Studio では、**[ツール]** > **[NuGet パッケージ マネージャー]** > **[ソリューションの NuGet パッケージの管理...]** の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-151">In Visual Studio go to **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution...**.</span></span>
2. <span data-ttu-id="e0db1-152">NuGet パッケージ マネージャーで、**[参照]** をクリックして検索ボックスに「**Xbox.Live.SDK**」と入力します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-152">In the NuGet package manager, click on **Browse** and enter **Xbox.Live.SDK** in the search box.</span></span>
3. <span data-ttu-id="e0db1-153">左側の一覧から使う Xbox Live SDK のバージョンを選びます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-153">Select the version of the Xbox Live SDK that you want to use from the list on the left.</span></span> <span data-ttu-id="e0db1-154">この場合、Microsoft.Xbox.Live.UWP パッケージを使います。</span><span class="sxs-lookup"><span data-stu-id="e0db1-154">In this case, we will use the Microsoft.Xbox.Live.SDK.WinRT.UWP package.</span></span>
3. <span data-ttu-id="e0db1-155">ウィンドウの右側にある、プロジェクトの横にあるチェック ボックスをオンにして **[インストール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-155">On the right side of the window, check the box next to your project and click **Install**.</span></span>

![NuGet による XBL の追加](../images/getting_started/vs-add-nuget-xbl.gif)


> [!IMPORTANT]
> <span data-ttu-id="e0db1-157">`Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、必ずプロジェクトのソースにヘッダー `#include <xsapi\services.h>` を含めてください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-157">For `Microsoft.Xbox.Live.SDK.Cpp.*` based projects, make sure to include the header `#include <xsapi\services.h>` in your project's source.</span></span>

### <a name="3-optional-using-connected-storage-andor-secure-sockets"></a><span data-ttu-id="e0db1-158">3. (省略可能) 接続ストレージやセキュア ソケットを使う</span><span class="sxs-lookup"><span data-stu-id="e0db1-158">3. (Optional) Using Connected Storage and/or Secure Sockets</span></span>
<span data-ttu-id="e0db1-159">使う Windows SDK のバージョンによっては、Xbox Live の[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)やセキュア ソケットを使うために、追加のコンテンツをインストールしたり、プロジェクトに参照を手動で追加したりする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-159">Depending on the version of the Windows SDK that you are using, you may need to install additional content or manually add references to your project in order to use Xbox Live [Connected Storage](../storage-platform/connected-storage/connected-storage-technical-overview.md) or Secure Sockets.</span></span> <span data-ttu-id="e0db1-160">接続ストレージ機能を使う場合、`Windows.Gaming.XboxLive.Storage` 名前空間にアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-160">If you want to use the Connected Storage feature, you will need to access the `Windows.Gaming.XboxLive.Storage` namespace.</span></span> <span data-ttu-id="e0db1-161">セキュア ソケットを使う場合、`Windows.Networking.XboxLive` にアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-161">If you want to use Secure Sockets, you will need to access `Windows.Networking.XboxLive`.</span></span>

#### <a name="windows-10-sdk-version-10016299-or-higher"></a><span data-ttu-id="e0db1-162">Windows 10 SDK バージョン 10.0.16299 以降</span><span class="sxs-lookup"><span data-stu-id="e0db1-162">Windows 10 SDK version 10.0.16299 or higher</span></span>
<span data-ttu-id="e0db1-163">Windows 10 SDK 10.0.16299 以降をターゲットとした場合、追加の作業を行わなくても接続ストレージ名前空間にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-163">If you've targeted Windows 10 SDK 10.0.16299 or higher, then you will be able to access the Connected Storage namespace without doing any additional work.</span></span> <span data-ttu-id="e0db1-164">セキュア ソケットにアクセスには、**UWP 用の Windows デスクトップ拡張機能**に参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-164">To access Secure Sockets, you will need to add a reference to **Windows Desktop Extensions for UWP**.</span></span> <span data-ttu-id="e0db1-165">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-165">You can do this by:</span></span>

1. <span data-ttu-id="e0db1-166">**ソリューション エクスプローラー**で、**[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-166">In the **Solution Explorer**, right click on the **References** node and pick **Add Reference...**</span></span>
2. <span data-ttu-id="e0db1-167">**[参照マネージャー]** ダイアログ ボックスの左側で、**[ユニバーサル Windows]** > **[拡張機能]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-167">On the left side of the **Reference Manager** dialog, select **Universal Windows** > **Extensions**.</span></span>
3. <span data-ttu-id="e0db1-168">表示される一覧で、**[Windows Desktop Extensions for UWP]** を検索し、使っている Windows 10 SDK に一致するバージョンの横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-168">In the list that appears, search for **Windows Desktop Extensions for UWP** and select the checkbox next to the version that matches your Windows 10 SDK.</span></span>
4. <span data-ttu-id="e0db1-169">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-169">Click **OK**.</span></span>

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-ref.png)

#### <a name="windows-10-sdk-version-10015063-or-lower"></a><span data-ttu-id="e0db1-171">Windows 10 SDK バージョン 10.0.15063 以下</span><span class="sxs-lookup"><span data-stu-id="e0db1-171">Windows 10 SDK version 10.0.15063 or lower</span></span>
<span data-ttu-id="e0db1-172">接続ストレージまたはセキュア ソケットを使用する場合は、プロジェクトに参照を追加する前に、Xbox Live Platform Extensions SDK をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-172">If you want to use Connected Storage or Secure Sockets, you will need to install the Xbox Live Platforms Extensions SDK before you can add references to your project.</span></span> <span data-ttu-id="e0db1-173">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-173">You can do this by:</span></span>

1. <span data-ttu-id="e0db1-174">[Xbox Live Platform Extensions SDK](http://aka.ms/xblextsdk) をダウンロードして抽出します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-174">Download and extract the [Xbox Live Platform Extensions SDK](http://aka.ms/xblextsdk).</span></span>
2. <span data-ttu-id="e0db1-175">抽出されたら、使っている Windows 10 SDK バージョンに対応するインクルード MSI ファイルを実行します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-175">Once extracted, run the included MSI file that matches the Windows 10 SDK version that you are using.</span></span>

<span data-ttu-id="e0db1-176">Xbox Live Platform Extensions SDK をインストールしたら、Visual Studio で参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-176">After you have installed the Xbox Live Platform Extensions SDK, you will need to add a reference to it in Visual Studio.</span></span> <span data-ttu-id="e0db1-177">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-177">You can do this by:</span></span>

1. <span data-ttu-id="e0db1-178">**ソリューション エクスプローラー**で、**[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-178">In the **Solution Explorer**, right click on the **References** node and pick **Add Reference...**</span></span>
2. <span data-ttu-id="e0db1-179">**[参照マネージャー]** ダイアログ ボックスの左側で、**[ユニバーサル Windows]** > **[拡張機能]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-179">On the left side of the **Reference Manager** dialog, select **Universal Windows** > **Extensions**.</span></span>
3. <span data-ttu-id="e0db1-180">表示される一覧で、**[Windows Desktop Extensions for UWP]** を検索し、使っている Windows 10 SDK に一致するバージョンの横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-180">In the list that appears, search for **Windows Desktop Extensions for UWP** and select the checkbox next to the version that matches your Windows 10 SDK.</span></span>
4. <span data-ttu-id="e0db1-181">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-181">Click **OK**.</span></span>

### <a name="4-associate-your-visual-studio-project-with-your-uwp-app"></a><span data-ttu-id="e0db1-182">4. Visual Studio のプロジェクトと UWP アプリを関連付ける</span><span class="sxs-lookup"><span data-stu-id="e0db1-182">4. Associate your Visual Studio project with your UWP app</span></span>

<span data-ttu-id="e0db1-183">ゲームがサインインするには、Microsoft デベロッパー センターで既に作成した製品に関連付けられる必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-183">For your game to be able to sign-in, it must be associated with the product you created on Microsoft Dev Center.</span></span> <span data-ttu-id="e0db1-184">ゲームは、Visual Studio で Microsoft Store 関連付けウィザードを使って関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-184">You can associate your game in Visual Studio by using the Store Association wizard.</span></span> <span data-ttu-id="e0db1-185">Visual Studio で、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-185">In Visual Studio, do the following:</span></span>

1.  <span data-ttu-id="e0db1-186">プライマリー プロジェクト (スタートアップ プロジェクト) を右クリックし、**[Microsoft Store]** > **[アプリケーションを Microsoft Store と関連付ける...]** の順にクリックします</span><span class="sxs-lookup"><span data-stu-id="e0db1-186">Right click the primary project (the StartUp Project), click **Store** > **Associate App with the Store...**</span></span>
2.  <span data-ttu-id="e0db1-187">要求されたら、アプリの作成に使用した **Windows デベロッパー アカウント**でサインインし、画面の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="e0db1-187">Sign-in with the **Windows Developer account** used for creating the app if asked and follow the prompts.</span></span>

> [!TIP]
> <span data-ttu-id="e0db1-188">Microsoft Store 用のゲームの準備について詳しくは、「[アプリのパッケージ化](https://docs.microsoft.com/windows/uwp/packaging/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-188">See [Packaging apps](https://docs.microsoft.com/windows/uwp/packaging/) for more information on preparing your game for Windows Store.</span></span>

### <a name="5-add-internet-capabilities-to-your-visual-studio-project"></a><span data-ttu-id="e0db1-189">5. インターネット機能を Visual Studio のプロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="e0db1-189">5. Add Internet capabilities to your Visual Studio Project</span></span>
<span data-ttu-id="e0db1-190">UWP プロジェクトが Xbox Live と通信するにはインターネット機能を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-190">Your UWP project will need to specify internet capabilities to communicate with Xbox Live.</span></span> <span data-ttu-id="e0db1-191">これらのプロパティは、次の方法で設定できます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-191">You can set these properties by:</span></span>

1. <span data-ttu-id="e0db1-192">Visual Studio で **package.appxmanifest** ファイルをダブルクリックして、**マニフェスト デザイナー**を開きます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-192">Double click on the **package.appxmanifest** file in Visual Studio to open the **Manifest Designer**.</span></span>
2. <span data-ttu-id="e0db1-193">**[機能]** タブをクリックし、**[インターネット (クライアント)]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="e0db1-193">Click on the **Capabilities** tab and check **Internet (Client)**.</span></span>

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-capability.png)

### <a name="6-associate-your-visual-studio-project-with-your-xbox-live-enabled-title"></a><span data-ttu-id="e0db1-195">6. Visual Studio のプロジェクトと Xbox Live 対応のタイトルを関連付ける</span><span class="sxs-lookup"><span data-stu-id="e0db1-195">6. Associate your Visual Studio project with your Xbox Live enabled title</span></span>

<span data-ttu-id="e0db1-196">Xbox Live サービスと通信するには、プロジェクトにサービス構成ファイルを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-196">To talk to the Xbox Live service, you'll need to add a service configuration file to your project.</span></span> <span data-ttu-id="e0db1-197">次の方法で行うと簡単です。</span><span class="sxs-lookup"><span data-stu-id="e0db1-197">This can be done easily by:</span></span>

1. <span data-ttu-id="e0db1-198">スタートアップ プロジェクトで、右クリックして **[追加]** > **[新しい項目]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-198">On your StartUp project, right click and select **Add** > **New Item**.</span></span>
2. <span data-ttu-id="e0db1-199">種類として **[テキスト ファイル]** を選び、名前を **xboxservices.config** に設定します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-199">Select the **Text File** type and name it **xboxservices.config**.</span></span>
3. <span data-ttu-id="e0db1-200">ファイルを右クリックして **[プロパティ]** を選び、以下の点を確認します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-200">Right click on the file, select **Properties** and ensure that:</span></span>
    1. <span data-ttu-id="e0db1-201">**[ビルド アクション]** が **[コンテンツ]** に設定されている。</span><span class="sxs-lookup"><span data-stu-id="e0db1-201">**Build Action** is set to **Content**, and</span></span>  
    2. <span data-ttu-id="e0db1-202">**[出力ディレクトリにコピー]** が **[常にコピーする]** に設定されている。</span><span class="sxs-lookup"><span data-stu-id="e0db1-202">**Copy to Output Directory** is set to **Copy Always**.</span></span>
5.  <span data-ttu-id="e0db1-203">次のテンプレートを使用して構成ファイルを編集し、**TitleId** と **PrimaryServiceConfigId** をタイトルに適用される値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-203">Edit the configuration file with the following template, replacing the **TitleId** and **PrimaryServiceConfigId** with the values applicable to your title.</span></span> <span data-ttu-id="e0db1-204">Microsoft デベロッパー センターでのルート Xbox Live ページから適切な値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-204">You can get the correct values from the root Xbox Live page on Microsoft Dev Center.</span></span> <span data-ttu-id="e0db1-205">**PrimaryServiceConfigId** は、Microsoft デベロッパー センターでは **SCID** として表示されます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-205">The **PrimaryServiceConfigId** appears on Microsoft Dev Center as **SCID**.</span></span>

```json
    {
       "TitleId" : "your title ID (JSON number in decimal)",
       "PrimaryServiceConfigId" : "your primary service config ID"
    }
```

<span data-ttu-id="e0db1-206">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="e0db1-206">For example:</span></span>

```json
    {
        "TitleId" : 1563044810,
        "PrimaryServiceConfigId" : "12200100-88da-4d8b-af88-e38f5d2a2bca"
    }
```

> [!TIP]
> <span data-ttu-id="e0db1-207">xboxservices.config 内のすべての値で大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="e0db1-207">All values inside xboxservices.config are case sensitive.</span></span> <span data-ttu-id="e0db1-208">TitleID と PrimaryServiceConfigId の取得について詳しくは、「[サービス構成](../xbox-live-service-configuration.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-208">See [Service Configuration](../xbox-live-service-configuration.md) for more information on obtaining the TitleID and PrimaryServiceConfigId.</span></span>

### <a name="7-optional-add-multiplayer-capabilities"></a><span data-ttu-id="e0db1-209">7. (省略可能) マルチプレイヤー機能を追加する</span><span class="sxs-lookup"><span data-stu-id="e0db1-209">7. (Optional) Add multiplayer capabilities</span></span>

<span data-ttu-id="e0db1-210">マルチプレイヤーのサポートをタイトルに追加する予定があり、プレイヤーが他のユーザーをマルチプレイヤー ゲームに招待する機能を実装する場合は、別のフィールドを AppXManifest ファイルに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0db1-210">If you plan to add Multiplayer support to your title, and want to implement the ability for players to invite other users for a multiplayer game, then you need to add another field to your AppXManifest file.</span></span> <span data-ttu-id="e0db1-211">詳しくは、「[マルチプレイヤー用に AppXManifest を構成する](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e0db1-211">See [Configure your AppXManifest For Multiplayer](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md) for more information.</span></span>

## <a name="learn-more"></a><span data-ttu-id="e0db1-212">詳細情報</span><span class="sxs-lookup"><span data-stu-id="e0db1-212">Learn More</span></span>

<span data-ttu-id="e0db1-213">[Xbox Live SDK サンプル](https://github.com/Microsoft/xbox-live-samples)では、Xbox Live API の使用方法が示されており、ID@Xbox プログラムで開発者が利用できる API も挙げられています。</span><span class="sxs-lookup"><span data-stu-id="e0db1-213">The [Xbox Live SDK samples](https://github.com/Microsoft/xbox-live-samples) are a good way to see how Xbox Live APIs are used and showcase the APIs available to developers in the ID@Xbox program.</span></span> <span data-ttu-id="e0db1-214">サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。1。</span><span class="sxs-lookup"><span data-stu-id="e0db1-214">To use the samples, you will need to change your sandbox to XDKS.1.</span></span>
