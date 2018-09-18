---
title: Xbox Live API のバイナリを UWP プロジェクトに追加する
author: KevinAsgari
description: NuGet を使用して Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する方法について説明します。
ms.assetid: 1e77ce9f-8a0e-402c-9f46-e37f9cda90ed
ms.author: kevinasg
ms.date: 11/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, NuGet
ms.localizationpriority: medium
ms.openlocfilehash: 84d3ce8b56e5d1bf921eef48499d54b1d3fc4c22
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4017889"
---
# <a name="add-xbox-live-apis-binary-package-to-your-uwp-project"></a><span data-ttu-id="c983f-104">Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="c983f-104">Add Xbox Live APIs binary package to your UWP project</span></span>

## <a name="requirements"></a><span data-ttu-id="c983f-105">要件</span><span class="sxs-lookup"><span data-stu-id="c983f-105">Requirements</span></span>

2. <span data-ttu-id="c983f-106">**[Windows 10](https://microsoft.com/windows)**。</span><span class="sxs-lookup"><span data-stu-id="c983f-106">**[Windows 10](https://microsoft.com/windows)**.</span></span>
3. <span data-ttu-id="c983f-107">**[Visual Studio](https://www.visualstudio.com/)** します。</span><span class="sxs-lookup"><span data-stu-id="c983f-107">**[Visual Studio](https://www.visualstudio.com/)**.</span></span> <span data-ttu-id="c983f-108">Visual Studio 2015 Update 3 以降、UWP アプリを構築できます。</span><span class="sxs-lookup"><span data-stu-id="c983f-108">UWP apps can be built with Visual Studio 2015 Update 3 or later.</span></span> <span data-ttu-id="c983f-109">開発者とセキュリティ更新プログラムの最新リリースの Visual Studio を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c983f-109">We recommend that you use the latest release of Visual Studio for developer and security updates.</span></span>
4. <span data-ttu-id="c983f-110">**[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** 以降。</span><span class="sxs-lookup"><span data-stu-id="c983f-110">**[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** or later.</span></span>

## <a name="add-the-binary-package-via-nuget"></a><span data-ttu-id="c983f-111">NuGet を使ったバイナリ パッケージの追加</span><span class="sxs-lookup"><span data-stu-id="c983f-111">Add the binary package via NuGet</span></span>

<span data-ttu-id="c983f-112">プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使うか API ソースを追加してバイナリへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="c983f-112">To use the Xbox Live API from your project, you can either add references to the binaries by using NuGet packages or adding the API source.</span></span> <span data-ttu-id="c983f-113">NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。</span><span class="sxs-lookup"><span data-stu-id="c983f-113">Adding NuGet packages makes compilation quicker while adding the source makes debugging easier.</span></span> <span data-ttu-id="c983f-114">この記事では、NuGet パッケージを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c983f-114">This article will walk through using NuGet packages.</span></span> <span data-ttu-id="c983f-115">ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c983f-115">If you want to use source, then please see [Compiling the Xbox Live APIs Source In Your UWP Project](add-xbox-live-apis-source-to-a-uwp-project.md).</span></span>

<span data-ttu-id="c983f-116">Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあり名前空間の構造は **Microsoft.Xbox.Live.SDK.\*.UWP** と **Microsoft.Xbox.Live.SDK.\*.XboxOneXDK** です。</span><span class="sxs-lookup"><span data-stu-id="c983f-116">The Xbox Services API comes in flavors for both UWP and XDK, and for C++ and WinRT and have their namespace structured as **Microsoft.Xbox.Live.SDK.\*.UWP** and **Microsoft.Xbox.Live.SDK.\*.XboxOneXDK**.</span></span>

1. <span data-ttu-id="c983f-117">**UWP** は、PC、Xbox One、Windows Phone で実行できる UWP ゲームをビルドしている開発者向けのものです。</span><span class="sxs-lookup"><span data-stu-id="c983f-117">**UWP** is for developers who are building a UWP game, which can run on either PC, the Xbox One, or Windows Phone.</span></span>
2. <span data-ttu-id="c983f-118">**XboxOneXDK** は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。</span><span class="sxs-lookup"><span data-stu-id="c983f-118">**XboxOneXDK** is for ID@Xbox and managed developers who are using the Xbox One XDK.</span></span>
3. <span data-ttu-id="c983f-119">C++ SDK は C++ ゲーム エンジンに使用できます。 WinRT SDK は、C++、C#、JavaScript を使って記述されたゲーム エンジン用です。</span><span class="sxs-lookup"><span data-stu-id="c983f-119">The C++ SDK can be used for C++ game engines, where as the  WinRT SDK is for game engines written with C++, C#, or JavaScript.</span></span>
4. <span data-ttu-id="c983f-120">C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用してください。</span><span class="sxs-lookup"><span data-stu-id="c983f-120">When using WinRT with a C++ engine, you should use C++/CX which uses hats (^).</span></span> <span data-ttu-id="c983f-121">C++ は、C++ ゲーム エンジンで使用する際に推奨される API です。</span><span class="sxs-lookup"><span data-stu-id="c983f-121">C++ is the recommended API to use for C++ game engines.</span></span>  

> [!TIP]
> <span data-ttu-id="c983f-122">Xbox One での UWP の実行について詳しくは、「[Xbox One の UWP アプリ開発の概要](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c983f-122">You can read more about running UWP on Xbox One at [Getting started with UWP app development on Xbox One](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started).</span></span>

<span data-ttu-id="c983f-123">Xbox Live SDK NuGet パッケージは次の方法で追加できます。</span><span class="sxs-lookup"><span data-stu-id="c983f-123">You can add the Xbox Live SDK NuGet package by:</span></span>

1. <span data-ttu-id="c983f-124">Visual Studio では、**[ツール]** > **[NuGet パッケージ マネージャー]** > **[ソリューションの NuGet パッケージの管理...]** の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="c983f-124">In Visual Studio go to **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution...**.</span></span>
2. <span data-ttu-id="c983f-125">NuGet パッケージ マネージャーで、**[参照]** をクリックして検索ボックスに「**Xbox.Live.SDK**」と入力します。</span><span class="sxs-lookup"><span data-stu-id="c983f-125">In the NuGet package manager, click on **Browse** and enter **Xbox.Live.SDK** in the search box.</span></span>
3. <span data-ttu-id="c983f-126">左側の一覧から使う Xbox Live SDK のバージョンを選びます。</span><span class="sxs-lookup"><span data-stu-id="c983f-126">Select the version of the Xbox Live SDK that you want to use from the list on the left.</span></span>
3. <span data-ttu-id="c983f-127">ウィンドウの右側にある、プロジェクトの横にあるチェック ボックスをオンにして **[インストール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c983f-127">On the right side of the window, check the box next to your project and click **Install**.</span></span>

> [!NOTE]
> <span data-ttu-id="c983f-128">Xbox Live クリエーターズ プログラムの開発者は、XDK がサポートされていないため、UWP バージョンの Xbox Live SDK を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c983f-128">Xbox Live Creators Program developers must use one of the UWP versions of the Xbox Live SDK, as XDK is not supported.</span></span>

![NuGet による XBL の追加](../images/getting_started/vs-add-nuget-xbl.gif)

> [!IMPORTANT]
> <span data-ttu-id="c983f-130">`Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、必ずプロジェクトのソースにヘッダー `#include <xsapi\services.h>` を含めてください。</span><span class="sxs-lookup"><span data-stu-id="c983f-130">For `Microsoft.Xbox.Live.SDK.Cpp.*` based projects, make sure to include the header `#include <xsapi\services.h>` in your project's source.</span></span>
