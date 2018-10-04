---
title: Visual Studio を使用してクリエーターズ タイトルを開発する
author: aablackm
description: Visual Studio を使用して、Xbox Live クリエーターズ プログラムのタイトルの開発を開始する
ms.assetid: 6952dac0-66ff-4717-b3c7-8b3792e834e3
ms.author: aablackm
ms.date: 11/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Xbox Live クリエーターズ, Visual Studio
ms.localizationpriority: medium
ms.openlocfilehash: 19ee781a7143c0da5b1549776646ab5b133a9667
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4352858"
---
# <a name="get-started-developing-an-xbox-live-creators-program-title-with-visual-studio"></a><span data-ttu-id="e4101-104">Visual Studio を使用して、Xbox Live クリエーターズ プログラムのタイトルの開発を開始する</span><span class="sxs-lookup"><span data-stu-id="e4101-104">Get started developing an Xbox Live Creators Program title with Visual Studio</span></span>

> [!NOTE]
> <span data-ttu-id="e4101-105">Unity で開発されたゲームに利用できるプラグインがあります。</span><span class="sxs-lookup"><span data-stu-id="e4101-105">There is a plugin available for games that are being developed with Unity.</span></span> <span data-ttu-id="e4101-106">詳しくは、「[Unity を使用してクリエーターズ タイトルを開発する](develop-creators-title-with-unity.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-106">See the [Develop a Creators title with Unity](develop-creators-title-with-unity.md) article for more information.</span></span>

## <a name="requirements"></a><span data-ttu-id="e4101-107">要件</span><span class="sxs-lookup"><span data-stu-id="e4101-107">Requirements</span></span>

1. <span data-ttu-id="e4101-108">**[デベロッパー センターの開発者プログラム](https://developer.microsoft.com/store/register)** に登録します。</span><span class="sxs-lookup"><span data-stu-id="e4101-108">Enrollment in the **[Dev Center developer program](https://developer.microsoft.com/store/register)**.</span></span>
2. <span data-ttu-id="e4101-109">**[Windows 10](https://microsoft.com/windows)**。</span><span class="sxs-lookup"><span data-stu-id="e4101-109">**[Windows 10](https://microsoft.com/windows)**.</span></span>
3. <span data-ttu-id="e4101-110">**ユニバーサル Windows アプリ開発ツール**を搭載した **[Visual Studio 2015](https://www.visualstudio.com/)** (またはそれ以降)。</span><span class="sxs-lookup"><span data-stu-id="e4101-110">**[Visual Studio 2015](https://www.visualstudio.com/)** (or newer) with the **Universal Windows App Development Tools**.</span></span>
4. <span data-ttu-id="e4101-111">**[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** 以降。</span><span class="sxs-lookup"><span data-stu-id="e4101-111">**[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** or later.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e4101-112">Windows 10 SDK バージョン 10.0.15063.0 (Creators Update とも呼ばれます) 以降を使っている場合は、Visual Studio 2017 が必要です。</span><span class="sxs-lookup"><span data-stu-id="e4101-112">Visual Studio 2017 is required if using Windows 10 SDK version 10.0.15063.0 (also known as Creators Update) or later.</span></span>

## <a name="create-a-new-product-on-microsoft-dev-center"></a><span data-ttu-id="e4101-113">Microsoft デベロッパー センターで新しい製品を作成する</span><span class="sxs-lookup"><span data-stu-id="e4101-113">Create a new product on Microsoft Dev Center</span></span>

<span data-ttu-id="e4101-114">すべての Xbox Live タイトルには、[Microsoft デベロッパー センター](https://developer.microsoft.com/store)で作成された製品が必要です。これにより、サインインして Xbox Live サービスを呼び出すことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="e4101-114">Every Xbox Live title must have a product created on [Microsoft Dev Center](https://developer.microsoft.com/store) before you will be able to sign-in and make Xbox Live Service calls.</span></span> <span data-ttu-id="e4101-115">詳しくは、「[新しいクリエーターズ タイトルの作成](create-and-test-a-new-creators-title.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-115">See [Creating a new Creators title](create-and-test-a-new-creators-title.md) for more information.</span></span>

## <a name="configuring-your-development-device"></a><span data-ttu-id="e4101-116">開発用デバイスの構成</span><span class="sxs-lookup"><span data-stu-id="e4101-116">Configuring your development device</span></span>

<span data-ttu-id="e4101-117">正常に Xbox Live にログインし、さまざまな Xbox Live サービスを呼び出すことができるように、デバイスでは、次のセットアップ手順を事前に実行しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-117">The following preliminary setup steps are required on your device, so that you can successfully login with Xbox Live and call the various Xbox Live Services.</span></span>

### <a name="set-your-sandbox"></a><span data-ttu-id="e4101-118">サンドボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="e4101-118">Set your sandbox</span></span>

<span data-ttu-id="e4101-119">サンドボックスを使用すると、タイトルをリリースする準備ができるまで、[Xbox Live サービス構成](xbox-live-service-configuration-creators.md)を製品版から分離したままにしておくことができます。</span><span class="sxs-lookup"><span data-stu-id="e4101-119">Sandboxes offer a way to keep your [Xbox Live Service Configuration](xbox-live-service-configuration-creators.md) isolated from retail until you are ready to release your title.</span></span> <span data-ttu-id="e4101-120">蓄積するデータにはサンドボックス固有のものがあります。</span><span class="sxs-lookup"><span data-stu-id="e4101-120">Some data that you accumulate is specific to a sandbox.</span></span> <span data-ttu-id="e4101-121">たとえば、タイトルで*ヘッドショット*という統計が定義されていて、タイトルをテストしている間にユーザー アカウントにいくつかのヘッドショットが蓄積されているとします。</span><span class="sxs-lookup"><span data-stu-id="e4101-121">For example let's say that your title defines a stat called *Headshots*, and you accumulate some number of Headshots in a user account while testing your title.</span></span> <span data-ttu-id="e4101-122">この値は、タイトルの開発サンドボックスに固有であり、製品版のタイトルのプレイに切り替えた場合、ヘッドショットは繰り越されません。</span><span class="sxs-lookup"><span data-stu-id="e4101-122">This value would be specific to your title's development sandbox, and if you switched to playing the retail version of your title, the headshots would not carry over.</span></span>

<span data-ttu-id="e4101-123">詳しい情報およびサンドボックスの設定方法については、「[Xbox Live のサンドボックス](xbox-live-sandboxes-creators.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-123">See the [Xbox Live Sandboxes](xbox-live-sandboxes-creators.md) article to learn more and see how to set your sandbox.</span></span>

### <a name="sign-in-with-an-xbox-live-account-that-has-been-authorized-for-testing"></a><span data-ttu-id="e4101-124">テスト用に承認された Xbox Live アカウントでログインする</span><span class="sxs-lookup"><span data-stu-id="e4101-124">Sign-in with an Xbox Live account that has been authorized for testing</span></span>

<span data-ttu-id="e4101-125">開発サンドボックスにログインするには、サンドボックスへのアクセス用に通常の Microsoft アカウント (MSA) をプロビジョニングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-125">To sign-in to your development sandbox, you must provision a regular Microsoft Account (MSA) for access to your sandbox.</span></span> <span data-ttu-id="e4101-126">これにより、開発中のタイトルに対するセキュリティが向上し、他のメリットを受けることができます。</span><span class="sxs-lookup"><span data-stu-id="e4101-126">This provides improved security for your titles in development, as well as some other benefits.</span></span>

<span data-ttu-id="e4101-127">テスト アカウントとその作成方法について詳しくは、「[環境内でテスト用の Xbox Live アカウントを承認する](authorize-xbox-live-accounts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-127">To learn more about test accounts and how to create one, see [Authorize Xbox Live Accounts for Testing in your environment](authorize-xbox-live-accounts.md).</span></span>

## <a name="visual-studio-project-setup"></a><span data-ttu-id="e4101-128">Visual Studio プロジェクトのセットアップ</span><span class="sxs-lookup"><span data-stu-id="e4101-128">Visual Studio Project Setup</span></span>

### <a name="1-open-a-uwp-project"></a><span data-ttu-id="e4101-129">1. UWP プロジェクトを開く</span><span class="sxs-lookup"><span data-stu-id="e4101-129">1. Open a UWP project</span></span>
<span data-ttu-id="e4101-130">既存の UWP プロジェクトがない場合は、次の手順で作成できます。</span><span class="sxs-lookup"><span data-stu-id="e4101-130">If you do not already have an existing UWP project, you can create one by doing the following:</span></span>

1. <span data-ttu-id="e4101-131">Visual Studio で、**[ファイル]** > **[新規作成]** > **[プロジェクト]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="e4101-131">In Visual Studio, **File** > **New** > **Project**.</span></span>
2. <span data-ttu-id="e4101-132">**[新しいプロジェクト]** ダイアログ ボックスが表示されたら、左側のウィンドウで **[Visual C#]** > **[Windows]** > **[ユニバーサル]** ノードを選択し、右側のウィンドウで **[空白のアプリ (ユニバーサル Windows)]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e4101-132">In the **New Project** dialog box, select the **Visual C#** > **Windows** > **Universal** node in the left pane, and click **Blank App (Universal Windows)** from the right pane.</span></span>
3. <span data-ttu-id="e4101-133">ダイアログ ボックスの下部で、プロジェクトに名前を付け、プロジェクトの場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="e4101-133">In the lower portion of the dialog, give the project a name and specify the location of the project.</span></span>
4. <span data-ttu-id="e4101-134">Windows 10 SDK のターゲット バージョンと最小バージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="e4101-134">Specify the Target Version and Minimum Version of the Windows 10 SDK.</span></span> <span data-ttu-id="e4101-135">詳しくは、「[UWP バージョンの選択](https://docs.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-135">See [Choose a UWP version](https://docs.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version) for more information.</span></span>

![VS でのプロジェクトの作成](../images/getting_started/vs-create-project.gif)

> [!NOTE]
> > <span data-ttu-id="e4101-137">Xbox Live API (XSAPI) は、バージョン 10.0.10586.0 以上でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="e4101-137">Xbox Live API (XSAPI) requires a minimum version 10.0.10586.0 or higher.</span></span>

### <a name="2-add-references-to-the-xbox-live-api-xsapi-in-your-project"></a><span data-ttu-id="e4101-138">2. プロジェクトで Xbox Live API (XSAPI) への参照を追加する</span><span class="sxs-lookup"><span data-stu-id="e4101-138">2. Add references to the Xbox Live API (XSAPI) in your project</span></span>
<span data-ttu-id="e4101-139">Xbox Services API には、C++ に使用できるものと WinRT に使用できるものがあり、名前の構造は **Microsoft.Xbox.Live.SDK.\*.UWP** です。</span><span class="sxs-lookup"><span data-stu-id="e4101-139">The Xbox Services API comes in flavors for C++ and WinRT and have their naming structured as **Microsoft.Xbox.Live.SDK.\*.UWP**.</span></span> <span data-ttu-id="e4101-140">Xbox One での UWP の実行について詳しくは、[https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-140">You can read more about running UWP on Xbox One at [https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started).</span></span> <span data-ttu-id="e4101-141">C++ SDK は C++ ゲーム エンジンに使用できます。 WinRT SDK は、C++、C#、JavaScript を使って記述されたゲーム エンジン用です。</span><span class="sxs-lookup"><span data-stu-id="e4101-141">The C++ SDK can be used for C++ game engines, where as the  WinRT SDK is for game engines written with C++, C#, or JavaScript.</span></span> <span data-ttu-id="e4101-142">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。</span><span class="sxs-lookup"><span data-stu-id="e4101-142">When using WinRT with a C++ engine, you would use C++/CX which uses hats (^).</span></span> <span data-ttu-id="e4101-143">C++ は、C++ ゲーム エンジンで使用する際に推奨される API です。</span><span class="sxs-lookup"><span data-stu-id="e4101-143">C++ is the recommended API to use for C++ game engines.</span></span>  

<span data-ttu-id="e4101-144">プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使うか API ソースを追加してバイナリへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="e4101-144">To use the Xbox Live API from your project, you can either add references to the binaries by using NuGet packages or adding the API source.</span></span> <span data-ttu-id="e4101-145">NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。</span><span class="sxs-lookup"><span data-stu-id="e4101-145">Adding NuGet packages makes compilation quicker while adding the source makes debugging easier.</span></span> <span data-ttu-id="e4101-146">この記事では、NuGet パッケージを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e4101-146">This article will walk through using NuGet packages.</span></span> <span data-ttu-id="e4101-147">ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](../get-started-with-partner/add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-147">If you want to use source, then please see [Compiling the Xbox Live APIs Source In Your UWP Project](../get-started-with-partner/add-xbox-live-apis-source-to-a-uwp-project.md).</span></span> <span data-ttu-id="e4101-148">Xbox Live SDK NuGet パッケージは次の方法で追加できます。</span><span class="sxs-lookup"><span data-stu-id="e4101-148">You can add the Xbox Live SDK NuGet package by:</span></span>

1. <span data-ttu-id="e4101-149">Visual Studio では、**[ツール]** > **[NuGet パッケージ マネージャー]** > **[ソリューションの NuGet パッケージの管理...]** の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="e4101-149">In Visual Studio go to **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution...**.</span></span>
2. <span data-ttu-id="e4101-150">NuGet パッケージ マネージャーで、**[参照]** をクリックして検索ボックスに「**Xbox.Live.SDK**」と入力します。</span><span class="sxs-lookup"><span data-stu-id="e4101-150">In the NuGet package manager, click on **Browse** and enter **Xbox.Live.SDK** in the search box.</span></span>
3. <span data-ttu-id="e4101-151">左側の一覧から使う Xbox Live SDK のバージョンを選びます。</span><span class="sxs-lookup"><span data-stu-id="e4101-151">Select the version of the Xbox Live SDK that you want to use from the list on the left.</span></span> <span data-ttu-id="e4101-152">この場合、Microsoft.Xbox.Live.UWP パッケージを使います。</span><span class="sxs-lookup"><span data-stu-id="e4101-152">In this case, we will use the Microsoft.Xbox.Live.SDK.WinRT.UWP package.</span></span>
3. <span data-ttu-id="e4101-153">ウィンドウの右側にある、プロジェクトの横にあるチェック ボックスをオンにして **[インストール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e4101-153">On the right side of the window, check the box next to your project and click **Install**.</span></span>

![NuGet による XBL の追加](../images/getting_started/vs-add-nuget-xbl.gif)

#### <a name="optionally-include-xsapi-header-in-your-project"></a><span data-ttu-id="e4101-155">必要に応じて、XSAPI ヘッダーをプロジェクトにインクルードする</span><span class="sxs-lookup"><span data-stu-id="e4101-155">Optionally include XSAPI header in your project</span></span>

<span data-ttu-id="e4101-156">Microsoft.Xbox.Live.SDK.Cpp.\* ベースのプロジェクトの場合は、`xsapi\\services.h` を C++ プロジェクトにインクルードして、Xbox Live Service API (XSAPI) NuGet パッケージのヘッダーを取り込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-156">For Microsoft.Xbox.Live.SDK.Cpp.\* based projects, you will need to include `xsapi\\services.h` to in your C++ project to bring in the header for the Xbox Live Service API (XSAPI) NuGet package.</span></span> <span data-ttu-id="e4101-157">XSAPI ヘッダーをインクルードする前に、`XBOX_LIVE_CREATORS_SDK` を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-157">Before including the XSAPI header, you must define `XBOX_LIVE_CREATORS_SDK`.</span></span> <span data-ttu-id="e4101-158">これにより、Xbox Live クリエーターズ プログラムの開発者が使用できる API のみに、API サーフェス領域が制限されます。</span><span class="sxs-lookup"><span data-stu-id="e4101-158">This limits the API surface area to only those APIs that are usable by developers in the Xbox Live Creators Program.</span></span> <span data-ttu-id="e4101-159">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="e4101-159">For example:</span></span>

```c++
#define XBOX_LIVE_CREATORS_SDK
#include "xsapi\services.h"
```
### <a name="3-optional-using-connected-storage"></a><span data-ttu-id="e4101-160">3. (省略可能) 接続ストレージを使う</span><span class="sxs-lookup"><span data-stu-id="e4101-160">3. (Optional) Using Connected Storage</span></span>
<span data-ttu-id="e4101-161">[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)サービスを使う場合、`Windows.Gaming.XboxLive.Storage` 名前空間にアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-161">If you want to use the [Connected Storage](../storage-platform/connected-storage/connected-storage-technical-overview.md) service, you will need to access the `Windows.Gaming.XboxLive.Storage` namespace.</span></span> <span data-ttu-id="e4101-162">使う Windows SDK のバージョンによっては、それを使うために、追加のコンテンツをインストールしたり、プロジェクトに参照を手動で追加したりする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-162">Depending on the version of the Windows SDK that you are using, you may need to install additional content or manually add references to your project to use it.</span></span> <span data-ttu-id="e4101-163">Windows 10 SDK 10.0.16299 以降をターゲットとした場合、追加の作業を行わなくても接続ストレージ名前空間にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="e4101-163">If you've targeted Windows 10 SDK 10.0.16299 or higher, then you will be able to access the Connected Storage namespace without doing any additional work.</span></span>

#### <a name="windows-10-sdk-version-10015063-or-lower"></a><span data-ttu-id="e4101-164">Windows 10 SDK バージョン 10.0.15063 以下</span><span class="sxs-lookup"><span data-stu-id="e4101-164">Windows 10 SDK version 10.0.15063 or lower</span></span>
<span data-ttu-id="e4101-165">接続ストレージを使用する場合は、プロジェクトに参照を追加する前に、Xbox Live Platform Extensions SDK をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-165">If you want to use Connected Storage, you will need to install the Xbox Live Platforms Extensions SDK before you can add references to your project.</span></span> <span data-ttu-id="e4101-166">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="e4101-166">You can do this by:</span></span>

1. <span data-ttu-id="e4101-167">[Xbox Live Platform Extensions SDK](http://aka.ms/xblextsdk) をダウンロードして抽出します。</span><span class="sxs-lookup"><span data-stu-id="e4101-167">Download and extract the [Xbox Live Platform Extensions SDK](http://aka.ms/xblextsdk).</span></span>
2. <span data-ttu-id="e4101-168">抽出されたら、使っている Windows 10 SDK バージョンに対応するインクルード MSI ファイルを実行します。</span><span class="sxs-lookup"><span data-stu-id="e4101-168">Once extracted, run the included MSI file that matches the Windows 10 SDK version that you are using.</span></span>

<span data-ttu-id="e4101-169">Xbox Live Platform Extensions SDK をインストールしたら、Visual Studio で参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-169">After you have installed the Xbox Live Platform Extensions SDK, you will need to add a reference to it in Visual Studio.</span></span> <span data-ttu-id="e4101-170">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="e4101-170">You can do this by:</span></span>

1. <span data-ttu-id="e4101-171">**ソリューション エクスプローラー**で、**[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e4101-171">In the **Solution Explorer**, right click on the **References** node and pick **Add Reference...**</span></span>
2. <span data-ttu-id="e4101-172">**[参照マネージャー]** ダイアログ ボックスの左側で、**[ユニバーサル Windows]** > **[拡張機能]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="e4101-172">On the left side of the **Reference Manager** dialog, select **Universal Windows** > **Extensions**.</span></span>
3. <span data-ttu-id="e4101-173">表示される一覧で、**[Windows Desktop Extensions for UWP]** を検索し、使っている Windows 10 SDK に一致するバージョンの横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="e4101-173">In the list that appears, search for **Windows Desktop Extensions for UWP** and select the checkbox next to the version that matches your Windows 10 SDK.</span></span>
4. <span data-ttu-id="e4101-174">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e4101-174">Click **OK**.</span></span>

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-ref.png)

### <a name="4-associate-your-visual-studio-project-with-your-uwp-app"></a><span data-ttu-id="e4101-176">4. Visual Studio のプロジェクトと UWP アプリを関連付ける</span><span class="sxs-lookup"><span data-stu-id="e4101-176">4. Associate your Visual Studio project with your UWP app</span></span>

<span data-ttu-id="e4101-177">ゲームがサインインするには、Microsoft デベロッパー センターで既に作成した製品に関連付けられる必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-177">For your game to be able to sign-in, it must be associated with the product you created on Microsoft Dev Center.</span></span> <span data-ttu-id="e4101-178">ゲームは、Visual Studio で Microsoft Store 関連付けウィザードを使って関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="e4101-178">You can associate your game in Visual Studio by using the Store Association wizard.</span></span> <span data-ttu-id="e4101-179">Visual Studio で、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="e4101-179">In Visual Studio, do the following:</span></span>

1.  <span data-ttu-id="e4101-180">プライマリー プロジェクト (スタートアップ プロジェクト) を右クリックし、**[Microsoft Store]** > **[アプリケーションを Microsoft Store と関連付ける...]** の順にクリックします</span><span class="sxs-lookup"><span data-stu-id="e4101-180">Right click the primary project (the StartUp Project), click **Store** > **Associate App with the Store...**</span></span>
2.  <span data-ttu-id="e4101-181">要求されたら、アプリの作成に使用した **Windows デベロッパー アカウント**でサインインし、画面の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="e4101-181">Sign-in with the **Windows Developer account** used for creating the app if asked and follow the prompts.</span></span>

> [!TIP]
> <span data-ttu-id="e4101-182">Microsoft Store 用のゲームの準備について詳しくは、「[アプリのパッケージ化](https://docs.microsoft.com/windows/uwp/packaging/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-182">See [Packaging apps](https://docs.microsoft.com/windows/uwp/packaging/) for more information on preparing your game for Windows Store.</span></span>

### <a name="5-add-internet-capabilities-to-your-visual-studio-project"></a><span data-ttu-id="e4101-183">5. インターネット機能を Visual Studio のプロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="e4101-183">5. Add Internet capabilities to your Visual Studio Project</span></span>
<span data-ttu-id="e4101-184">UWP プロジェクトが Xbox Live と通信するにはインターネット機能を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-184">Your UWP project will need to specify internet capabilities to communicate with Xbox Live.</span></span> <span data-ttu-id="e4101-185">これらのプロパティは、次の方法で設定できます。</span><span class="sxs-lookup"><span data-stu-id="e4101-185">You can set these properties by:</span></span>

1. <span data-ttu-id="e4101-186">Visual Studio で **package.appxmanifest** ファイルをダブルクリックして、**マニフェスト デザイナー**を開きます。</span><span class="sxs-lookup"><span data-stu-id="e4101-186">Double click on the **package.appxmanifest** file in Visual Studio to open the **Manifest Designer**.</span></span>
2. <span data-ttu-id="e4101-187">**[機能]** タブをクリックし、**[インターネット (クライアント)]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="e4101-187">Click on the **Capabilities** tab and check **Internet (Client)**.</span></span>

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-capability.png)

### <a name="6-associate-your-visual-studio-project-with-your-xbox-live-enabled-title"></a><span data-ttu-id="e4101-189">6. Visual Studio のプロジェクトと Xbox Live 対応のタイトルを関連付ける</span><span class="sxs-lookup"><span data-stu-id="e4101-189">6. Associate your Visual Studio project with your Xbox Live enabled title</span></span>

<span data-ttu-id="e4101-190">Xbox Live サービスと通信するには、プロジェクトにサービス構成ファイルを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4101-190">To talk to the Xbox Live service, you'll need to add a service configuration file to your project.</span></span> <span data-ttu-id="e4101-191">次の方法で行うと簡単です。</span><span class="sxs-lookup"><span data-stu-id="e4101-191">This can be done easily by:</span></span>

1. <span data-ttu-id="e4101-192">スタートアップ プロジェクトで、右クリックして **[追加]** > **[新しい項目]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="e4101-192">On your StartUp project, right click and select **Add** > **New Item**.</span></span>
2. <span data-ttu-id="e4101-193">種類として **[テキスト ファイル]** を選び、名前を **xboxservices.config** に設定します。</span><span class="sxs-lookup"><span data-stu-id="e4101-193">Select the **Text File** type and name it **xboxservices.config**.</span></span>
3. <span data-ttu-id="e4101-194">ファイルを右クリックして **[プロパティ]** を選び、以下の点を確認します。</span><span class="sxs-lookup"><span data-stu-id="e4101-194">Right click on the file, select **Properties** and ensure that:</span></span>
    1. <span data-ttu-id="e4101-195">**[ビルド アクション]** が **[コンテンツ]** に設定されている。</span><span class="sxs-lookup"><span data-stu-id="e4101-195">**Build Action** is set to **Content**, and</span></span>  
    2. <span data-ttu-id="e4101-196">**[出力ディレクトリにコピー]** が **[常にコピーする]** に設定されている。</span><span class="sxs-lookup"><span data-stu-id="e4101-196">**Copy to Output Directory** is set to **Copy Always**.</span></span>
5.  <span data-ttu-id="e4101-197">次のテンプレートを使用して構成ファイルを編集し、**TitleId** と **PrimaryServiceConfigId** をタイトルに適用される値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="e4101-197">Edit the configuration file with the following template, replacing the **TitleId** and **PrimaryServiceConfigId** with the values applicable to your title.</span></span> <span data-ttu-id="e4101-198">Microsoft デベロッパー センターでのルート Xbox Live ページから適切な値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="e4101-198">You can get the correct values from the root Xbox Live page on Microsoft Dev Center.</span></span> <span data-ttu-id="e4101-199">**PrimaryServiceConfigId** は、Microsoft デベロッパー センターでは **SCID** として表示されます。</span><span class="sxs-lookup"><span data-stu-id="e4101-199">The **PrimaryServiceConfigId** appears on Microsoft Dev Center as **SCID**.</span></span>

```json
    {
       "TitleId" : "your title ID (JSON number in decimal)",
       "PrimaryServiceConfigId" : "your primary service config ID",
       "XboxLiveCreatorsTitle" : true
    }
```

<span data-ttu-id="e4101-200">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="e4101-200">For example:</span></span>

```json
    {
        "TitleId" : 1563044810,
        "PrimaryServiceConfigId" : "12200100-88da-4d8b-af88-e38f5d2a2bca",
        "XboxLiveCreatorsTitle" : true
    }
```

> [!TIP]
> <span data-ttu-id="e4101-201">xboxservices.config 内のすべての値で大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="e4101-201">All values inside xboxservices.config are case sensitive.</span></span> <span data-ttu-id="e4101-202">TitleID と PrimaryServiceConfigId の取得について詳しくは、「[サービス構成](../xbox-live-service-configuration.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4101-202">See [Service Configuration](../xbox-live-service-configuration.md) for more information on obtaining the TitleID and PrimaryServiceConfigId.</span></span>

## <a name="learn-more"></a><span data-ttu-id="e4101-203">詳細情報</span><span class="sxs-lookup"><span data-stu-id="e4101-203">Learn More</span></span>

<span data-ttu-id="e4101-204">[Xbox Live SDK サンプル](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/CreatorsSDK)では、Xbox Live クリエーターズ プログラムの開発者が使用可能な API が示されています。</span><span class="sxs-lookup"><span data-stu-id="e4101-204">The [Xbox Live SDK samples](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/CreatorsSDK) under showcase the APIs available to developers in the Xbox Live Creators program.</span></span> <span data-ttu-id="e4101-205">サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。1。</span><span class="sxs-lookup"><span data-stu-id="e4101-205">To use the samples, you will need to change your sandbox to XDKS.1.</span></span>
