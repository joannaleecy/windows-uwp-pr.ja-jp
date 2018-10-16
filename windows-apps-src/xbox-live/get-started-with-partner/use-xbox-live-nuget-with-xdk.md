---
title: XDK で Xbox Live NuGet パッケージを使用する
author: KevinAsgari
description: Xbox Live API NuGet パッケージを使用して XDK タイトルを開発する方法について説明します。
ms.assetid: 2c5ae514-393d-48bb-afd8-a897d35f7938
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, NuGet
ms.localizationpriority: medium
ms.openlocfilehash: b8b12201c0511339c4dd38824e17f7586e03708e
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4694317"
---
# <a name="use-the-xbox-live-api-nuget-package-to-develop-xdk-titles"></a><span data-ttu-id="83978-104">Xbox Live API NuGet パッケージを使用して XDK タイトルを開発する</span><span class="sxs-lookup"><span data-stu-id="83978-104">Use the Xbox Live API NuGet package to develop XDK titles</span></span>

### <a name="1--ensure-you-have-the-latest-nuget-package-manager-installed"></a><span data-ttu-id="83978-105">1. 最新の NuGet パッケージ マネージャーがインストールされていることを確認する</span><span class="sxs-lookup"><span data-stu-id="83978-105">1.  Ensure you have the latest NuGet Package Manager installed</span></span>
1.  <span data-ttu-id="83978-106">現在のバージョンをチェックします。</span><span class="sxs-lookup"><span data-stu-id="83978-106">Check your current version:</span></span>
    - <span data-ttu-id="83978-107">メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。</span><span class="sxs-lookup"><span data-stu-id="83978-107">On the menu bar, select Tools-> Extensions and Updates.</span></span>
    - <span data-ttu-id="83978-108">[インストール済み] タブで、次を探します: </span><span class="sxs-lookup"><span data-stu-id="83978-108">Under the Installed tab,  look for</span></span> `NuGet Package Manager`
![](../images/nuget/nuget_uwp_install_1.png)
2.  <span data-ttu-id="83978-109">現在のバージョンを更新するには、以下を実行します。</span><span class="sxs-lookup"><span data-stu-id="83978-109">To update your current version:</span></span>
    - <span data-ttu-id="83978-110">メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。</span><span class="sxs-lookup"><span data-stu-id="83978-110">On the menu bar, select Tools-> Extensions and Updates.</span></span>
    - <span data-ttu-id="83978-111">[更新プログラム] -> [Visual Studio ギャラリー] タブで、次を選択します: </span><span class="sxs-lookup"><span data-stu-id="83978-111">Under the Updates->Visual Studio Gallery tab, select</span></span> `Update`
![](../images/nuget/nuget_uwp_install_2.png)

### <a name="2--add-reference-to-the-project"></a><span data-ttu-id="83978-112">2. プロジェクトに参照を追加する</span><span class="sxs-lookup"><span data-stu-id="83978-112">2.  Add reference to the project</span></span>
1.  <span data-ttu-id="83978-113">プロジェクトに参照を追加します</span><span class="sxs-lookup"><span data-stu-id="83978-113">Add reference to the project</span></span>
    1.  <span data-ttu-id="83978-114">プロジェクト ソリューションを右クリックし、[NuGet パッケージの管理] を選択します。</span><span class="sxs-lookup"><span data-stu-id="83978-114">Right click on your project solution and select "Manage NuGet Packages"</span></span>
<br/>
![](../images/nuget/nuget_xbox_install_4.png)
1.  <span data-ttu-id="83978-115">`Xbox Live` を探し、適切なパッケージを選択して、[`Install`] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="83978-115">Search for `Xbox Live` and select the appropriate package and click `Install`.</span></span>
  - <span data-ttu-id="83978-116">Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあります。</span><span class="sxs-lookup"><span data-stu-id="83978-116">The Xbox Services API comes in flavors for both UWP and XDK, and for C++ and WinRT.</span></span>  
  - <span data-ttu-id="83978-117">`Microsoft.Xbox.Live.SDK.*.UWP` または `Microsoft.Xbox.Live.SDK.*.XboxOneXDK` を選択します。</span><span class="sxs-lookup"><span data-stu-id="83978-117">Choose between `Microsoft.Xbox.Live.SDK.*.UWP` and `Microsoft.Xbox.Live.SDK.*.XboxOneXDK`.</span></span>  `XboxOneXDK` <span data-ttu-id="83978-118">は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。</span><span class="sxs-lookup"><span data-stu-id="83978-118">is for ID@Xbox and Managed developers who are using the Xbox One XDK.</span></span>  `UWP` <span data-ttu-id="83978-119">は、PC、Xbox One、Windows Phone で実行できる UWP ゲーム用のものです。</span><span class="sxs-lookup"><span data-stu-id="83978-119">is for UWP games which can run on either PC, the Xbox One, or Windows Phone.</span></span>  <span data-ttu-id="83978-120">詳しくは Xbox One で UWP の実行について[https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)</span><span class="sxs-lookup"><span data-stu-id="83978-120">You can read more about running UWP on Xbox One at [https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)</span></span>
  - <span data-ttu-id="83978-121">`Microsoft.Xbox.Live.SDK.Cpp.*` または `Microsoft.Xbox.Live.SDK.WinRT.*` を選択します。</span><span class="sxs-lookup"><span data-stu-id="83978-121">Choose between `Microsoft.Xbox.Live.SDK.Cpp.*` and `Microsoft.Xbox.Live.SDK.WinRT.*`.</span></span> `Cpp` <span data-ttu-id="83978-122">は、Xbox Live API を使用している C++ ゲーム エンジン用のものです。</span><span class="sxs-lookup"><span data-stu-id="83978-122">is for C++ game engines using the Xbox Live APIs.</span></span>  `WinRT` <span data-ttu-id="83978-123">は、Xbox Live API を使用し、C++、C#、または Javascript で記述されたゲーム エンジン用のものです。</span><span class="sxs-lookup"><span data-stu-id="83978-123">is for game engines written with C++, C#, or Javascript using the Xbox Live APIs.</span></span>  <span data-ttu-id="83978-124">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。</span><span class="sxs-lookup"><span data-stu-id="83978-124">When using WinRT with a C++ engine, you would use C++/CX which uses hats (^).</span></span>  `Cpp` <span data-ttu-id="83978-125">は、C++ ゲーム エンジンで使用する際に推奨される API です。</span><span class="sxs-lookup"><span data-stu-id="83978-125">is the recommended API to use for C++ game engines.</span></span>    
![](../images/nuget/nuget_xbox_install_5.png)
![](../images/nuget/nuget_uwp_install_7.png)
1. <span data-ttu-id="83978-126">ライセンスの TOS を受け入れた後、パッケージが正常に追加されるまで待機します。</span><span class="sxs-lookup"><span data-stu-id="83978-126">After accepting the License TOS, wait until the package has been successfully added.</span></span>  <span data-ttu-id="83978-127">パッケージ マネージャーの出力ウィンドウに次のログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="83978-127">You should see this log in the Package Manger output window:</span></span>

```
========== Finished ==========
```

### <a name="3--optionally-include-header"></a><span data-ttu-id="83978-128">3. オプションでインクルードするヘッダー</span><span class="sxs-lookup"><span data-stu-id="83978-128">3.  Optionally include header</span></span>
* <span data-ttu-id="83978-129">`Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、プロジェクトのソースに `#include <xsapi\services.h>` を指定できます。</span><span class="sxs-lookup"><span data-stu-id="83978-129">For `Microsoft.Xbox.Live.SDK.Cpp.*` based projects `#include <xsapi\services.h>` in your project's source.</span></span>
* <span data-ttu-id="83978-130">`Microsoft.Xbox.Live.SDK.WinRT.*` ベースのプロジェクトの場合は、ヘッダーをインクルードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="83978-130">For `Microsoft.Xbox.Live.SDK.WinRT.*` based projects, no need to include any headers.</span></span>   
