---
title: XDK で Xbox Live NuGet パッケージを使用する
description: Xbox Live API NuGet パッケージを使用して XDK タイトルを開発する方法について説明します。
ms.assetid: 2c5ae514-393d-48bb-afd8-a897d35f7938
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, NuGet
ms.localizationpriority: medium
ms.openlocfilehash: c955ca42c09075e5125683588c335cfa47443f00
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655037"
---
# <a name="use-the-xbox-live-api-nuget-package-to-develop-xdk-titles"></a><span data-ttu-id="ae066-104">Xbox Live API NuGet パッケージを使用して XDK タイトルを開発する</span><span class="sxs-lookup"><span data-stu-id="ae066-104">Use the Xbox Live API NuGet package to develop XDK titles</span></span>

### <a name="1--ensure-you-have-the-latest-nuget-package-manager-installed"></a><span data-ttu-id="ae066-105">1. インストールされている最新の NuGet パッケージ マネージャーをしたことを確認します。</span><span class="sxs-lookup"><span data-stu-id="ae066-105">1.  Ensure you have the latest NuGet Package Manager installed</span></span>
1.  <span data-ttu-id="ae066-106">現在のバージョンをチェックします。</span><span class="sxs-lookup"><span data-stu-id="ae066-106">Check your current version:</span></span>
    - <span data-ttu-id="ae066-107">メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。</span><span class="sxs-lookup"><span data-stu-id="ae066-107">On the menu bar, select Tools-> Extensions and Updates.</span></span>
    - <span data-ttu-id="ae066-108">[インストール済み] タブを探します `NuGet Package Manager`
![](../images/nuget/nuget_uwp_install_1.png)</span><span class="sxs-lookup"><span data-stu-id="ae066-108">Under the Installed tab,  look for `NuGet Package Manager`
![](../images/nuget/nuget_uwp_install_1.png)</span></span>
2.  <span data-ttu-id="ae066-109">現在のバージョンを更新するには、以下を実行します。</span><span class="sxs-lookup"><span data-stu-id="ae066-109">To update your current version:</span></span>
    - <span data-ttu-id="ae066-110">メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。</span><span class="sxs-lookup"><span data-stu-id="ae066-110">On the menu bar, select Tools-> Extensions and Updates.</span></span>
    - <span data-ttu-id="ae066-111">更新プログラム [Visual Studio ギャラリー] タブ -> で、選択 `Update`
![](../images/nuget/nuget_uwp_install_2.png)</span><span class="sxs-lookup"><span data-stu-id="ae066-111">Under the Updates->Visual Studio Gallery tab, select `Update`
![](../images/nuget/nuget_uwp_install_2.png)</span></span>

### <a name="2--add-reference-to-the-project"></a><span data-ttu-id="ae066-112">2. プロジェクトに参照を追加します</span><span class="sxs-lookup"><span data-stu-id="ae066-112">2.  Add reference to the project</span></span>
1.  <span data-ttu-id="ae066-113">プロジェクトに参照を追加します</span><span class="sxs-lookup"><span data-stu-id="ae066-113">Add reference to the project</span></span>
    1.  <span data-ttu-id="ae066-114">プロジェクト ソリューションを右クリックし、[NuGet パッケージの管理] を選択します。</span><span class="sxs-lookup"><span data-stu-id="ae066-114">Right click on your project solution and select "Manage NuGet Packages"</span></span>
<br/>
![](../images/nuget/nuget_xbox_install_4.png)
1.  <span data-ttu-id="ae066-115">`Xbox Live` を探し、適切なパッケージを選択して、[`Install`] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ae066-115">Search for `Xbox Live` and select the appropriate package and click `Install`.</span></span>
  - <span data-ttu-id="ae066-116">Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあります。</span><span class="sxs-lookup"><span data-stu-id="ae066-116">The Xbox Services API comes in flavors for both UWP and XDK, and for C++ and WinRT.</span></span>  
  - <span data-ttu-id="ae066-117">`Microsoft.Xbox.Live.SDK.*.UWP` または `Microsoft.Xbox.Live.SDK.*.XboxOneXDK` を選択します。</span><span class="sxs-lookup"><span data-stu-id="ae066-117">Choose between `Microsoft.Xbox.Live.SDK.*.UWP` and `Microsoft.Xbox.Live.SDK.*.XboxOneXDK`.</span></span>  <span data-ttu-id="ae066-118">`XboxOneXDK` ID@Xboxおよびマネージ開発者が Xbox One XDK を使用しています。</span><span class="sxs-lookup"><span data-stu-id="ae066-118">`XboxOneXDK` is for ID@Xbox and Managed developers who are using the Xbox One XDK.</span></span>  <span data-ttu-id="ae066-119">`UWP` PC、Xbox One または Windows Phone で実行できる UWP ゲームです。</span><span class="sxs-lookup"><span data-stu-id="ae066-119">`UWP` is for UWP games which can run on either PC, the Xbox One, or Windows Phone.</span></span>  <span data-ttu-id="ae066-120">詳細に Xbox One での UWP を実行する方法 [https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)</span><span class="sxs-lookup"><span data-stu-id="ae066-120">You can read more about running UWP on Xbox One at [https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)</span></span>
  - <span data-ttu-id="ae066-121">`Microsoft.Xbox.Live.SDK.Cpp.*` または `Microsoft.Xbox.Live.SDK.WinRT.*` を選択します。</span><span class="sxs-lookup"><span data-stu-id="ae066-121">Choose between `Microsoft.Xbox.Live.SDK.Cpp.*` and `Microsoft.Xbox.Live.SDK.WinRT.*`.</span></span> <span data-ttu-id="ae066-122">`Cpp` Xbox Live Api を使用して C++ ゲーム エンジンです。</span><span class="sxs-lookup"><span data-stu-id="ae066-122">`Cpp` is for C++ game engines using the Xbox Live APIs.</span></span>  <span data-ttu-id="ae066-123">`WinRT` C++ で記述されたゲーム エンジンC#、または Xbox Live Api を使用した Javascript。</span><span class="sxs-lookup"><span data-stu-id="ae066-123">`WinRT` is for game engines written with C++, C#, or Javascript using the Xbox Live APIs.</span></span>  <span data-ttu-id="ae066-124">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。</span><span class="sxs-lookup"><span data-stu-id="ae066-124">When using WinRT with a C++ engine, you would use C++/CX which uses hats (^).</span></span>  <span data-ttu-id="ae066-125">`Cpp` C++ ゲーム エンジンを使用する推奨の API です。</span><span class="sxs-lookup"><span data-stu-id="ae066-125">`Cpp` is the recommended API to use for C++ game engines.</span></span>    
![](../images/nuget/nuget_xbox_install_5.png)
![](../images/nuget/nuget_uwp_install_7.png)
1. <span data-ttu-id="ae066-126">ライセンスの TOS を受け入れた後、パッケージが正常に追加されるまで待機します。</span><span class="sxs-lookup"><span data-stu-id="ae066-126">After accepting the License TOS, wait until the package has been successfully added.</span></span>  <span data-ttu-id="ae066-127">パッケージ マネージャーの出力ウィンドウに次のログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ae066-127">You should see this log in the Package Manger output window:</span></span>

```
========== Finished ==========
```

### <a name="3--optionally-include-header"></a><span data-ttu-id="ae066-128">3.必要に応じてヘッダーを含める</span><span class="sxs-lookup"><span data-stu-id="ae066-128">3.  Optionally include header</span></span>
* <span data-ttu-id="ae066-129">`Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、プロジェクトのソースに `#include <xsapi\services.h>` を指定できます。</span><span class="sxs-lookup"><span data-stu-id="ae066-129">For `Microsoft.Xbox.Live.SDK.Cpp.*` based projects `#include <xsapi\services.h>` in your project's source.</span></span>
* <span data-ttu-id="ae066-130">`Microsoft.Xbox.Live.SDK.WinRT.*` ベースのプロジェクトの場合は、ヘッダーをインクルードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ae066-130">For `Microsoft.Xbox.Live.SDK.WinRT.*` based projects, no need to include any headers.</span></span>   
