---
author: laurenhughes
title: "アプリ パッケージのアーキテクチャ"
description: "UWP アプリ パッケージを構築するときにどのプロセッサ アーキテクチャを使用するべきかについて説明します。"
ms.author: lahugh
ms.date: 7/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, パッケージ化, アーキテクチャ, パッケージの構成"
ms.openlocfilehash: 70188734e7fc26f66b68d0c31921071c47e8b7a8
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="app-package-architectures"></a><span data-ttu-id="7b1db-104">アプリ パッケージのアーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="7b1db-104">App package architectures</span></span>

<span data-ttu-id="7b1db-105">アプリ パッケージは、特定のプロセッサ アーキテクチャで実行するように構成されます。</span><span class="sxs-lookup"><span data-stu-id="7b1db-105">App packages are configured to run on a specific processor architecture.</span></span> <span data-ttu-id="7b1db-106">アーキテクチャを選択することで、アプリを実行するデバイスを指定することになります。</span><span class="sxs-lookup"><span data-stu-id="7b1db-106">By selecting an architecture, you are specifying which device(s) you want your app to run on.</span></span> <span data-ttu-id="7b1db-107">ユニバーサル Windows プラットフォーム (UWP) アプリは、次のアーキテクチャで実行するように構成できます。</span><span class="sxs-lookup"><span data-stu-id="7b1db-107">Universal Windows Platform (UWP) apps can be configured to run on the following architectures:</span></span>
- <span data-ttu-id="7b1db-108">x86</span><span class="sxs-lookup"><span data-stu-id="7b1db-108">x86</span></span>
- <span data-ttu-id="7b1db-109">x64</span><span class="sxs-lookup"><span data-stu-id="7b1db-109">x64</span></span>
- <span data-ttu-id="7b1db-110">ARM</span><span class="sxs-lookup"><span data-stu-id="7b1db-110">ARM</span></span>

<span data-ttu-id="7b1db-111">すべてのアーキテクチャを対象にしてアプリ パッケージを構築することを**強く**お勧めします。</span><span class="sxs-lookup"><span data-stu-id="7b1db-111">It is **highly** recommended that you build your app package to target all architectures.</span></span> <span data-ttu-id="7b1db-112">1 つのデバイス アーキテクチャを選択から外すと、アプリを実行できるデバイスの種類を制限することになり、アプリを使用できるユーザー数も抑制することになります。</span><span class="sxs-lookup"><span data-stu-id="7b1db-112">By deselecting a device architecture, you are limiting the number of devices your app can run on, which in turn will limit the amount of people who can use your app!</span></span>

## <a name="windows-10-devices-and-architectures"></a><span data-ttu-id="7b1db-113">Windows 10 デバイスとアーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="7b1db-113">Windows 10 devices and architectures</span></span>

> [!div class="mx-tableFixed"]
| <span data-ttu-id="7b1db-114">UWP のアーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="7b1db-114">UWP Architecture</span></span> | <span data-ttu-id="7b1db-115">デスクトップ (x86)</span><span class="sxs-lookup"><span data-stu-id="7b1db-115">Desktop (x86)</span></span>      | <span data-ttu-id="7b1db-116">デスクトップ (x64)</span><span class="sxs-lookup"><span data-stu-id="7b1db-116">Desktop (x64)</span></span>      | <span data-ttu-id="7b1db-117">デスクトップ (ARM)</span><span class="sxs-lookup"><span data-stu-id="7b1db-117">Desktop (ARM)</span></span>      | <span data-ttu-id="7b1db-118">モバイル</span><span class="sxs-lookup"><span data-stu-id="7b1db-118">Mobile</span></span>             | <span data-ttu-id="7b1db-119">HoloLens</span><span class="sxs-lookup"><span data-stu-id="7b1db-119">HoloLens</span></span>           | <span data-ttu-id="7b1db-120">Xbox</span><span class="sxs-lookup"><span data-stu-id="7b1db-120">Xbox</span></span>               | <span data-ttu-id="7b1db-121">IoT Core (デバイス依存)</span><span class="sxs-lookup"><span data-stu-id="7b1db-121">IoT Core (Device dependent)</span></span> | 
|------------------|--------------------|--------------------|--------------------|--------------------|--------------------|--------------------|-----------------------------|
| <span data-ttu-id="7b1db-122">x86</span><span class="sxs-lookup"><span data-stu-id="7b1db-122">x86</span></span>              | <span data-ttu-id="7b1db-123">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-123">:heavy_check_mark:</span></span> | <span data-ttu-id="7b1db-124">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-124">:heavy_check_mark:</span></span> | <span data-ttu-id="7b1db-125">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-125">:heavy_check_mark:</span></span> | <span data-ttu-id="7b1db-126">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-126">:x:</span></span>                | <span data-ttu-id="7b1db-127">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-127">:heavy_check_mark:</span></span> | <span data-ttu-id="7b1db-128">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-128">:x:</span></span>                | <span data-ttu-id="7b1db-129">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-129">:heavy_check_mark:</span></span>          |
| <span data-ttu-id="7b1db-130">x64</span><span class="sxs-lookup"><span data-stu-id="7b1db-130">x64</span></span>              | <span data-ttu-id="7b1db-131">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-131">:x:</span></span>                | <span data-ttu-id="7b1db-132">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-132">:heavy_check_mark:</span></span> | <span data-ttu-id="7b1db-133">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-133">:x:</span></span>                | <span data-ttu-id="7b1db-134">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-134">:x:</span></span>                | <span data-ttu-id="7b1db-135">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-135">:x:</span></span>                | <span data-ttu-id="7b1db-136">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-136">:heavy_check_mark:</span></span> | <span data-ttu-id="7b1db-137">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-137">:heavy_check_mark:</span></span>          |
| <span data-ttu-id="7b1db-138">ARM</span><span class="sxs-lookup"><span data-stu-id="7b1db-138">ARM</span></span>              | <span data-ttu-id="7b1db-139">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-139">:x:</span></span>                | <span data-ttu-id="7b1db-140">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-140">:x:</span></span>                | <span data-ttu-id="7b1db-141">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-141">:heavy_check_mark:</span></span> | <span data-ttu-id="7b1db-142">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-142">:heavy_check_mark:</span></span> | <span data-ttu-id="7b1db-143">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-143">:x:</span></span>                | <span data-ttu-id="7b1db-144">:x:</span><span class="sxs-lookup"><span data-stu-id="7b1db-144">:x:</span></span>                | <span data-ttu-id="7b1db-145">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="7b1db-145">:heavy_check_mark:</span></span>          |
 

<span data-ttu-id="7b1db-146">これらのアーキテクチャについて詳しく説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="7b1db-146">Let’s talk about these architectures in more detail.</span></span> 

### <a name="x86"></a><span data-ttu-id="7b1db-147">x86</span><span class="sxs-lookup"><span data-stu-id="7b1db-147">x86</span></span>
<span data-ttu-id="7b1db-148">x86 はほぼすべてのデバイスで実行されるため、一般的に、アプリ パッケージでは x86 を選ぶのが最も安全な構成になります。</span><span class="sxs-lookup"><span data-stu-id="7b1db-148">Choosing x86 is generally the safest configuration for an app package since it will run on nearly every device.</span></span> <span data-ttu-id="7b1db-149">Xbox や一部の IoT Core デバイスなど、デバイスの中には x86 構成のアプリ パッケージを実行できないものもあります。</span><span class="sxs-lookup"><span data-stu-id="7b1db-149">On some devices, an app package with the x86 configuration won't run, such as the Xbox or some IoT Core devices.</span></span> <span data-ttu-id="7b1db-150">ただし、PC の場合は x86 パッケージが最も安全な選択肢であり、最も広い範囲のデバイスに展開できます。</span><span class="sxs-lookup"><span data-stu-id="7b1db-150">However, for a PC, an x86 package is the safest choice and has the largest reach for device deployment.</span></span> <span data-ttu-id="7b1db-151">Windows 10 デバイスの大部分は、引き続き x86 バージョンの Windows を実行しています。</span><span class="sxs-lookup"><span data-stu-id="7b1db-151">A substantial portion of Windows 10 devices continue to run the x86 version of Windows.</span></span> 

### <a name="x64"></a><span data-ttu-id="7b1db-152">x64</span><span class="sxs-lookup"><span data-stu-id="7b1db-152">x64</span></span>
<span data-ttu-id="7b1db-153">この構成は x86 構成に比べると使用される頻度は低くなります。</span><span class="sxs-lookup"><span data-stu-id="7b1db-153">This configuration is used less frequently than the x86 configuration.</span></span> <span data-ttu-id="7b1db-154">この構成は、64 ビットバージョンの Windows 10 を採用しているデスクトップ、[Xbox の UWP アプリ](https://docs.microsoft.com/windows/uwp/xbox-apps/system-resource-allocation)、および Intel Joule の Windows 10 IoT Core 向けのものであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="7b1db-154">It should be noted that this configuation is reserved for desktops using 64-bit versions of Windows 10, [UWP apps on Xbox](https://docs.microsoft.com/windows/uwp/xbox-apps/system-resource-allocation), and Windows 10 IoT Core on the Intel Joule.</span></span>

### <a name="arm"></a><span data-ttu-id="7b1db-155">ARM</span><span class="sxs-lookup"><span data-stu-id="7b1db-155">ARM</span></span>
<span data-ttu-id="7b1db-156">ARM 版 Windows 10 構成には、デスクトップ PC、モバイル デバイス、および一部の IoT Core デバイス (Rasperry Pi 2、Raspberry Pi 3、および DragonBoard) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="7b1db-156">The Windows 10 on ARM configuration includes desktop PCs, mobile devices, and some IoT Core devices (Rasperry Pi 2, Raspberry Pi 3, and DragonBoard).</span></span> <span data-ttu-id="7b1db-157">ARM 版 Windows 10 デスクトップ PC が Windows ファミリに新たに加わりました。そのため、UWP アプリ開発者がこれらの PC で最適なエクスペリエンスを実現するには ARM パッケージをストアに提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b1db-157">Windows 10 on ARM desktop PCs are a new addition to the Windows family, so if you are UWP app developer, you should submit ARM packages to the Store for the best experience on these PCs.</span></span> 

<span data-ttu-id="7b1db-158">[ARM 版 Windows 10](https://channel9.msdn.com/Events/Build/2017/P4171) のデモを確認し、そのしくみを詳しく知るには、この //Build トークをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b1db-158">Check out this //Build talk to see a demo of [Windows 10 on ARM](https://channel9.msdn.com/Events/Build/2017/P4171) and learn more about how it works.</span></span> 

<span data-ttu-id="7b1db-159">IoT 固有のトピックについて詳しくは、[Visual Studio を使ったアプリの展開に関するページ](https://developer.microsoft.com/windows/iot/Docs/AppDeployment)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b1db-159">For more information IoT specific topics, see [Deploying an App with Visual Studio](https://developer.microsoft.com/windows/iot/Docs/AppDeployment).</span></span>