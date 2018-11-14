---
author: Mtoepke
title: Xbox One 上の UWP アプリとゲームのシステム リソース
description: Xbox 上の UWP のシステム リソース
ms.author: mstahl
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 12e87019-4315-424e-b73c-426d565deef9
ms.localizationpriority: medium
ms.openlocfilehash: f4c96fd3c124f8853a91f8db4385f7d42e254834
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6457709"
---
# <a name="system-resources-for-uwp-apps-and-games-on-xbox-one"></a><span data-ttu-id="85273-104">Xbox One 上の UWP アプリとゲームのシステム リソース</span><span class="sxs-lookup"><span data-stu-id="85273-104">System resources for UWP apps and games on Xbox One</span></span>

<span data-ttu-id="85273-105">Xbox One で実行されている UWP アプリは、システムやその他のアプリとリソースを共有します。</span><span class="sxs-lookup"><span data-stu-id="85273-105">UWP apps running on Xbox One share resources with the system and other apps.</span></span> <span data-ttu-id="85273-106">Xbox One アプリの UWP で利用可能なリソースは、アプリとして提出するか、Xbox Live クリエーターズ プログラム ゲームとして提出するかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="85273-106">The resources available to a UWP on Xbox One app depend on whether you submit as an app or as an Xbox Live Creators Program game.</span></span>

* <span data-ttu-id="85273-107">フォアグラウンドで実行されているときに利用可能な最大メモリ</span><span class="sxs-lookup"><span data-stu-id="85273-107">Maximum available memory while running in the foreground:</span></span>
    * <span data-ttu-id="85273-108">アプリ: 1 GB</span><span class="sxs-lookup"><span data-stu-id="85273-108">Apps: 1 GB</span></span>
    * <span data-ttu-id="85273-109">ゲーム: 5 GB</span><span class="sxs-lookup"><span data-stu-id="85273-109">Games: 5 GB</span></span>

<span data-ttu-id="85273-110">バックグラウンドで実行されているアプリに利用可能なメモリは最大 128 MB です。</span><span class="sxs-lookup"><span data-stu-id="85273-110">The maximum memory available to an app running in the background is 128 MB.</span></span> <span data-ttu-id="85273-111">バックグラウンド モードは、バックグラウンド ミュージック プレーヤーなどの同時アプリケーションにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="85273-111">Background mode only applies to concurrent applications, like background music players.</span></span>  <span data-ttu-id="85273-112">ゲームはバックグラウンドで一時停止および終了されます。</span><span class="sxs-lookup"><span data-stu-id="85273-112">Games will be suspended and terminated in the background.</span></span>

<span data-ttu-id="85273-113">これらの制限を超えると、メモリ割り当てエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="85273-113">Exceeding these limitations will cause memory allocation failures.</span></span> <span data-ttu-id="85273-114">メモリ使用量の監視について詳しくは、[MemoryManager クラス](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)のリファレンスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85273-114">For more information about monitoring memory use, see the [MemoryManager class](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) reference.</span></span>
    
    > [!NOTE]
    > When running your app or game from the Visual Studio debugger, these memory constraints do not apply. This limit is only applicable when not running in debugging mode.

* <span data-ttu-id="85273-115">CPU</span><span class="sxs-lookup"><span data-stu-id="85273-115">CPU</span></span>
    * <span data-ttu-id="85273-116">アプリ: システムで実行されているアプリとゲームの数に応じて、2 ～ 4 個の CPU コアを共有します。</span><span class="sxs-lookup"><span data-stu-id="85273-116">Apps: share of 2-4 CPU cores depending on the number of apps and games running on the system.</span></span>
    * <span data-ttu-id="85273-117">ゲーム: 4 基の排他的 CPU コアと 2 基の共有 CPU コア。</span><span class="sxs-lookup"><span data-stu-id="85273-117">Games: 4 exclusive and 2 shared CPU cores.</span></span>

* <span data-ttu-id="85273-118">GPU</span><span class="sxs-lookup"><span data-stu-id="85273-118">GPU</span></span>
    * <span data-ttu-id="85273-119">アプリ: システムで実行されているアプリとゲームの数に応じて、GPU の 45% を共有します。</span><span class="sxs-lookup"><span data-stu-id="85273-119">Apps: share of 45% of the GPU depending on the number of apps and games running on the system.</span></span>
    * <span data-ttu-id="85273-120">ゲーム: 利用可能な GPU サイクルへのフル アクセス。</span><span class="sxs-lookup"><span data-stu-id="85273-120">Games: full access to available GPU cycles.</span></span>

* <span data-ttu-id="85273-121">DirectX のサポート</span><span class="sxs-lookup"><span data-stu-id="85273-121">DirectX support</span></span>
    * <span data-ttu-id="85273-122">アプリ: DirectX 11 機能レベル 10。</span><span class="sxs-lookup"><span data-stu-id="85273-122">Apps: DirectX 11 Feature Level 10.</span></span>
    * <span data-ttu-id="85273-123">ゲーム: DirectX 12、および DirectX 11 の機能レベル 10。</span><span class="sxs-lookup"><span data-stu-id="85273-123">Games: DirectX 12, and DirectX 11 Feature Level 10.</span></span>

* <span data-ttu-id="85273-124">アプリおよびゲームを Xbox 向けに開発または Microsoft Store に提出するには、必ず x64 アーキテクチャをターゲットにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="85273-124">All apps and games must target the x64 architecture in order to be developed or submitted to the store for Xbox.</span></span>  

<span data-ttu-id="85273-125">**アプリケーション開発**の場合、利用可能なリソースは標準 PC と比べて限られることがあり、システムで実行されているアプリやゲームの数によって異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="85273-125">For **application development**, resources available may be limited in comparison to a standard PC and can vary based on the number of apps and games running on the system.</span></span>

<span data-ttu-id="85273-126">**ゲーム開発**の場合、Xbox One は、他のゲーム コンソールと同様に、その潜在的な機能を最大限に利用するために特定のハードウェア ベースの開発キットを必要とする、特殊なハードウェアです。</span><span class="sxs-lookup"><span data-stu-id="85273-126">For **games development**, Xbox One, like other games consoles, is a specialized piece of hardware that requires a specific hardware-based development kit to access its full potential.</span></span> <span data-ttu-id="85273-127">Xbox One のハードウェアの機能を最大限に利用する必要があるゲームを開発している場合、[ID@Xbox](http://www.xbox.com/Developers/id) プログラムに登録して Xbox One 開発キットにアクセスすることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="85273-127">If you are working on a game that requires access to the maximum potential of the Xbox One hardware, consider registering with the [ID@Xbox](http://www.xbox.com/Developers/id) program to get access to an Xbox One development kit.</span></span>


<span data-ttu-id="85273-128">Xbox One での UWP アプリのシステム リソースについて詳しくは、次のビデオの最初の部分をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85273-128">For more information about system resources for UWP apps on Xbox One, see the first part of this video.</span></span>
</br>
</br>
<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developing-xbox-one-applications-16860/Video-What-s-Unique--vk0fOPf9C_2006218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="see-also"></a><span data-ttu-id="85273-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="85273-129">See also</span></span>
- [<span data-ttu-id="85273-130">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="85273-130">UWP on Xbox One</span></span>](index.md)
- [<span data-ttu-id="85273-131">Xbox Live クリエーターズ プログラムの概要</span><span class="sxs-lookup"><span data-stu-id="85273-131">Get started with the Xbox Live Creators Program</span></span>](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)
- [<span data-ttu-id="85273-132">DirectX と xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="85273-132">DirectX and UWP on Xbox One</span></span>](https://blogs.msdn.microsoft.com/chuckw/2017/12/15/directx-and-uwp-on-xbox-one/)

