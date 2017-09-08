---
title: "Xbox Live API のバイナリを UWP プロジェクトに追加する"
author: KevinAsgari
description: "NuGet を使用して Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する方法について説明します。"
ms.assetid: 1e77ce9f-8a0e-402c-9f46-e37f9cda90ed
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, NuGet"
ms.openlocfilehash: f861b4b53dd4f1e89eb32c1cc1d9428e6576dcd1
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="add-xbox-live-apis-binary-package-to-your-uwp-project"></a><span data-ttu-id="d2165-104">Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="d2165-104">Add Xbox Live APIs binary package to your UWP project</span></span>

<span data-ttu-id="d2165-105">次の手順を実行すると、NuGet を使用して最新の Xbox Live API をゲームにインポートできます。</span><span class="sxs-lookup"><span data-stu-id="d2165-105">You can use NuGet to import the latest Xbox Live APIs into your game by following these steps:</span></span>

### <a name="1-ensure-you-have-the-windows-10-rtm-and-visual-studio-2015-or-later-installed"></a><span data-ttu-id="d2165-106">1. Windows 10 RTM および Visual Studio 2015 以降がインストールされていることを確認する</span><span class="sxs-lookup"><span data-stu-id="d2165-106">1. Ensure you have the Windows 10 RTM and Visual Studio 2015 or later installed.</span></span>

- <span data-ttu-id="d2165-107">Visual Studio 2015。</span><span class="sxs-lookup"><span data-stu-id="d2165-107">Visual Studio 2015.</span></span>  <span data-ttu-id="d2165-108">[https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx](https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx) をご覧ください</span><span class="sxs-lookup"><span data-stu-id="d2165-108">See [https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx](https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx)</span></span>
- <span data-ttu-id="d2165-109">Windows 10 SDK v10.0.14393.0 以降 [https://developer.microsoft.com/ja-JP/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)</span><span class="sxs-lookup"><span data-stu-id="d2165-109">Windows 10 SDK v10.0.14393.0 or later [https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)</span></span>

### <a name="2--ensure-you-have-the-latest-nuget-package-manager-installed"></a><span data-ttu-id="d2165-110">2. 最新の NuGet パッケージ マネージャーがインストールされていることを確認する</span><span class="sxs-lookup"><span data-stu-id="d2165-110">2.  Ensure you have the latest NuGet Package Manager installed</span></span>

1.  <span data-ttu-id="d2165-111">現在のバージョンをチェックします。</span><span class="sxs-lookup"><span data-stu-id="d2165-111">Check your current version:</span></span>
    - <span data-ttu-id="d2165-112">メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。</span><span class="sxs-lookup"><span data-stu-id="d2165-112">On the menu bar, select Tools-> Extensions and Updates.</span></span>
    - <span data-ttu-id="d2165-113">[インストール済み] タブで、次を探します: </span><span class="sxs-lookup"><span data-stu-id="d2165-113">Under the Installed tab,  look for</span></span> `NuGet Package Manager`
![](../images/nuget/nuget_uwp_install_1.png)
2.  <span data-ttu-id="d2165-114">現在のバージョンを更新するには、以下を実行します。</span><span class="sxs-lookup"><span data-stu-id="d2165-114">To update your current version:</span></span>
    - <span data-ttu-id="d2165-115">メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。</span><span class="sxs-lookup"><span data-stu-id="d2165-115">On the menu bar, select Tools-> Extensions and Updates.</span></span>
    - <span data-ttu-id="d2165-116">[更新プログラム] -> [Visual Studio ギャラリー] タブで、次を選択します: </span><span class="sxs-lookup"><span data-stu-id="d2165-116">Under the Updates->Visual Studio Gallery tab, select</span></span> `Update`
![](../images/nuget/nuget_uwp_install_2.png)

### <a name="3--add-reference-to-the-project"></a><span data-ttu-id="d2165-117">3. プロジェクトに参照を追加する</span><span class="sxs-lookup"><span data-stu-id="d2165-117">3.  Add reference to the project</span></span>
1.  <span data-ttu-id="d2165-118">プロジェクト ソリューションを右クリックし、次を選択します: </span><span class="sxs-lookup"><span data-stu-id="d2165-118">Right click on your project solution and select</span></span> `Manage NuGet Packages`
![](../images/nuget/nuget_uwp_install_6.png)
1.  <span data-ttu-id="d2165-119">`Xbox Live` を探し、適切なパッケージを選択して、[`Install`] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d2165-119">Search for `Xbox Live` and select the appropriate package and click `Install`.</span></span>
  - <span data-ttu-id="d2165-120">Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあります。</span><span class="sxs-lookup"><span data-stu-id="d2165-120">The Xbox Services API comes in flavors for both UWP and XDK, and for C++ and WinRT.</span></span>  
  - <span data-ttu-id="d2165-121">`Microsoft.Xbox.Live.SDK.*.UWP` または `Microsoft.Xbox.Live.SDK.*.XboxOneXDK` を選択します。</span><span class="sxs-lookup"><span data-stu-id="d2165-121">Choose between `Microsoft.Xbox.Live.SDK.*.UWP` and `Microsoft.Xbox.Live.SDK.*.XboxOneXDK`.</span></span>  `XboxOneXDK` <span data-ttu-id="d2165-122">は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。</span><span class="sxs-lookup"><span data-stu-id="d2165-122">is for ID@Xbox and Managed developers who are using the Xbox One XDK.</span></span>  `UWP` <span data-ttu-id="d2165-123">は、PC、Xbox One、Windows Phone で実行できる UWP ゲーム用のものです。</span><span class="sxs-lookup"><span data-stu-id="d2165-123">is for UWP games which can run on either PC, the Xbox One, or Windows Phone.</span></span>  <span data-ttu-id="d2165-124">Xbox One での UWP の実行について詳しくは、[https://docs.microsoft.com/ja-jp/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2165-124">You can read more about running UWP on Xbox One at [https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)</span></span>
  - <span data-ttu-id="d2165-125">`Microsoft.Xbox.Live.SDK.Cpp.*` または `Microsoft.Xbox.Live.SDK.WinRT.*` を選択します。</span><span class="sxs-lookup"><span data-stu-id="d2165-125">Choose between `Microsoft.Xbox.Live.SDK.Cpp.*` and `Microsoft.Xbox.Live.SDK.WinRT.*`.</span></span> `Cpp` <span data-ttu-id="d2165-126">は、Xbox Live API を使用している C++ ゲーム エンジン用のものです。</span><span class="sxs-lookup"><span data-stu-id="d2165-126">is for C++ game engines using the Xbox Live APIs.</span></span>  `WinRT` <span data-ttu-id="d2165-127">は、Xbox Live API を使用し、C++、C#、または Javascript で記述されたゲーム用のものです。</span><span class="sxs-lookup"><span data-stu-id="d2165-127">is games written with C++, C#, or Javascript using the Xbox Live APIs.</span></span>  <span data-ttu-id="d2165-128">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。</span><span class="sxs-lookup"><span data-stu-id="d2165-128">When using WinRT with a C++ engine, you would use C++/CX which uses hats (^).</span></span>  `Cpp` <span data-ttu-id="d2165-129">は、C++ ゲーム エンジンで使用する際に推奨される API です。</span><span class="sxs-lookup"><span data-stu-id="d2165-129">is the recommended API to use for C++ game engines.</span></span>    
  -  <span data-ttu-id="d2165-130">Xbox Live クリエーターズ プログラムに参加している場合は、次のオプションのいずれも使うことができます: 1) Microsoft.Xbox.Live.SDK.Cpp.UWP (C++ の UWP ゲーム エンジン用)、2) Microsoft.Xbox.Live.SDK.WinRT.UWP (C# または JavaScript の UWP ゲーム エンジン用)。</span><span class="sxs-lookup"><span data-stu-id="d2165-130">If you are part of the Xbox Live Creators Program, you can use any of these options: 1) Microsoft.Xbox.Live.SDK.Cpp.UWP for C++ UWP game engines, 2) Microsoft.Xbox.Live.SDK.WinRT.UWP for C# or JavaScript UWP game engines.</span></span> <span data-ttu-id="d2165-131">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d2165-131">When using WinRT with a C++ engine, you can use C++/CX which uses hats (^).</span></span>  <span data-ttu-id="d2165-132">Microsoft.Xbox.Live.SDK.Cpp.UWP は、C++ ゲーム エンジンで使用する際に推奨される API です。</span><span class="sxs-lookup"><span data-stu-id="d2165-132">Microsoft.Xbox.Live.SDK.Cpp.UWP is the recommended API to use for C++ game engines.</span></span> <span data-ttu-id="d2165-133">3) Unity。</span><span class="sxs-lookup"><span data-stu-id="d2165-133">3) Unity.</span></span>  <span data-ttu-id="d2165-134">詳しくは、「[Unity を使用してクリエーターズ タイトルを開発する](../get-started-with-creators/develop-creators-title-with-unity.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2165-134">See the [Develop a Creators title with Unity](../get-started-with-creators/develop-creators-title-with-unity.md) article for specifics.</span></span>
![](../images/nuget/nuget_uwp_install_7.png)
1. <span data-ttu-id="d2165-135">ライセンスの TOS を受け入れた後、パッケージが正常に追加されるまで待機します。</span><span class="sxs-lookup"><span data-stu-id="d2165-135">After accepting the License TOS, wait until the package has been successfully added.</span></span>  <span data-ttu-id="d2165-136">パッケージ マネージャーの出力ウィンドウに次のログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d2165-136">You should see this log in the Package Manger output window:</span></span>

```
========== Finished ==========
```

### <a name="4--optionally-include-header"></a><span data-ttu-id="d2165-137">4. オプションでインクルードするヘッダー</span><span class="sxs-lookup"><span data-stu-id="d2165-137">4.  Optionally include header</span></span>
* <span data-ttu-id="d2165-138">`Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、プロジェクトのソースに `#include <xsapi\services.h>` を指定できます。</span><span class="sxs-lookup"><span data-stu-id="d2165-138">For `Microsoft.Xbox.Live.SDK.Cpp.*` based projects `#include <xsapi\services.h>` in your project's source.</span></span>
* <span data-ttu-id="d2165-139">`Microsoft.Xbox.Live.SDK.WinRT.*` ベースのプロジェクトの場合は、ヘッダーをインクルードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d2165-139">For `Microsoft.Xbox.Live.SDK.WinRT.*` based projects, no need to include any headers.</span></span>   
