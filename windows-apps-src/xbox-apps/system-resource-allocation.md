---
author: Mtoepke
title: "Xbox One 上の UWP アプリとゲームのシステム リソース"
description: "Xbox 上の UWP のシステム リソース"
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 12e87019-4315-424e-b73c-426d565deef9
ms.openlocfilehash: 76c9d372cdfd98ef86f123862c35d238b24fe2ed
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="system-resources-for-uwp-apps-and-games-on-xbox-one"></a><span data-ttu-id="e4ff9-104">Xbox One 上の UWP アプリとゲームのシステム リソース</span><span class="sxs-lookup"><span data-stu-id="e4ff9-104">System resources for UWP apps and games on Xbox One</span></span>

<span data-ttu-id="e4ff9-105">Xbox One で実行されている UWP アプリとゲームは、システムやその他のアプリとリソースを共有します。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-105">UWP apps and games running on Xbox One share resources with the system and other apps.</span></span> <span data-ttu-id="e4ff9-106">そのため、UWP アプリやゲームは次のリソースにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-106">Therefore, UWP apps and games will have access to the following resources:</span></span>

* <span data-ttu-id="e4ff9-107">フォアグラウンドで実行されているアプリに利用可能なメモリは最大 1 GB です。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-107">The maximum memory available to an app running in the foreground is 1 GB.</span></span>
    * <span data-ttu-id="e4ff9-108">バックグラウンドで実行されているアプリに利用可能なメモリは最大 128 MB です。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-108">The maximum memory available to an app running in the background is 128 MB.</span></span>
    * <span data-ttu-id="e4ff9-109">これらのメモリ要件を超えているアプリでは、メモリの割り当てエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-109">Apps that exceed these memory requirements will encounter memory allocation failures.</span></span> <span data-ttu-id="e4ff9-110">メモリ使用量の監視について詳しくは、[MemoryManager クラス](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)のリファレンスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-110">For more information about monitoring memory use, see the [MemoryManager class](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) reference.</span></span>
    
    > [!NOTE]
    > <span data-ttu-id="e4ff9-111">アプリケーションやゲームを Visual Studio デバッガーから実行している場合、これらのメモリ制限は適用されません。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-111">When running your application or game from the Visual Studio debugger, these memory constraints do not apply.</span></span> <span data-ttu-id="e4ff9-112">この制限は、デバッグ モードで実行されていないときにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-112">This limit is only applicable when not running in debugging mode.</span></span>

* <span data-ttu-id="e4ff9-113">システムで実行されているアプリとゲームの数に応じて、2 ～ 4 個の CPU コアを共有します。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-113">Share of 2-4 CPU cores depending on the number of apps and games running on the system.</span></span>

* <span data-ttu-id="e4ff9-114">システムで実行されているアプリとゲームの数に応じて、GPU の 45% を共有します。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-114">Share of 45% of the GPU depending on the number of apps and games running on the system.</span></span>

* <span data-ttu-id="e4ff9-115">Xbox One の UWP は、DirectX 11 の機能レベル 10 をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-115">UWP on Xbox One supports DirectX 11 Feature Level 10.</span></span> <span data-ttu-id="e4ff9-116">現時点では DirectX 12 はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-116">DirectX 12 is not supported at this time.</span></span>

* <span data-ttu-id="e4ff9-117">アプリを Xbox 向けに開発またはストアに提出するには、必ず x64 アーキテクチャをターゲットにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-117">All apps must target the x64 architecture in order to be developed or submitted to the store for Xbox.</span></span>  

<span data-ttu-id="e4ff9-118">**アプリケーション開発**の場合、標準的な PC と比較して、利用可能なリソースが制限される可能性があることに留意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-118">For **application development**, it's important to keep in mind that the resources available may be limited in comparison to a standard PC.</span></span>

<span data-ttu-id="e4ff9-119">**ゲーム開発**の場合、Xbox One は、他のゲーム コンソールと同様に、その潜在的な機能を最大限に利用するために特定のハードウェア ベースの開発キットを必要とする、特殊なハードウェアであることに留意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-119">For **games development**, it’s important to keep in mind that Xbox One, like other games consoles, is a specialized piece of hardware that requires a specific hardware-based development kit to access its full potential.</span></span> <span data-ttu-id="e4ff9-120">Xbox One のハードウェアの機能を最大限に利用する必要があるゲームを開発している場合、[ID@Xbox](http://www.xbox.com/Developers/id) プログラムに登録することで、DirectX 12 のサポートを含む Xbox One 開発キットにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-120">If you are working on a game that requires access to the maximum potential of the Xbox One hardware, you can register with the [ID@Xbox](http://www.xbox.com/Developers/id) program to get access to Xbox One development kits, which include DirectX 12 support.</span></span>


<span data-ttu-id="e4ff9-121">Xbox One での UWP アプリのシステム リソースについてもう少し詳しく知りたい場合は、次のビデオの最初の部分をチェックしてください。</span><span class="sxs-lookup"><span data-stu-id="e4ff9-121">For a little more explanation about the system resources for UWP apps on Xbox One, check out the first bit of this video.</span></span>
</br>
</br>
<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developing-xbox-one-applications-16860/Video-What-s-Unique--vk0fOPf9C_2006218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="see-also"></a><span data-ttu-id="e4ff9-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="e4ff9-122">See also</span></span>
- [<span data-ttu-id="e4ff9-123">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="e4ff9-123">UWP on Xbox One</span></span>](index.md)
