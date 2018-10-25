---
title: Social Manager のメモリーとパフォーマンス
author: KevinAsgari
description: Xbox Live Social Manager API マネージャーを使う場合のメモリとパフォーマンスに関する考慮事項について説明します。
ms.assetid: 2540145e-b8e2-4ab5-9390-65e2c9b19792
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, social manager, people
ms.localizationpriority: medium
ms.openlocfilehash: 4e32ea2c1938bc72642d8affa031dffd538d4feb
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5471158"
---
# <a name="social-manager-memory-and-performance-overview"></a><span data-ttu-id="09adf-104">Social Manager のメモリーとパフォーマンスの概要</span><span class="sxs-lookup"><span data-stu-id="09adf-104">Social Manager Memory and Performance Overview</span></span>

## <a name="memory"></a><span data-ttu-id="09adf-105">メモリ</span><span class="sxs-lookup"><span data-stu-id="09adf-105">Memory</span></span>
<span data-ttu-id="09adf-106">Social Manager は、割り当てられた永続的なメモリーをタイトル領域内に保持できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="09adf-106">Social Manager now allows it's allocated persistent memory to be held in title space.</span></span> <span data-ttu-id="09adf-107">Social Manager が使用するためのカスタム メモリー アロケーターを指定するには、`xbox_live_services_settings::set_memory_allocation_hooks()` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="09adf-107">A custom memory allocator for use by social manager can be specified by calling `xbox_live_services_settings::set_memory_allocation_hooks()`.</span></span> <span data-ttu-id="09adf-108">このメモリー アロケーターのフックは、Xbox Live API (XSAPI) が使用する将来の大規模なメモリーの割り当てに使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="09adf-108">This memory allocator hook will may also be used for future large memory allocations that the Xbox Live API (XSAPI) uses.</span></span>

<span data-ttu-id="09adf-109">Social Manager によるメモリーの割り当ては、既定では最も少ない場合で約 4.75 MB です (1)。</span><span class="sxs-lookup"><span data-stu-id="09adf-109">The worst case for memory allocation by social manager by default should be around 4.75 mb (1).</span></span> <span data-ttu-id="09adf-110">RTA および HTTP の更新に基づいて、Social Manager によって追加のオーバーヘッドが割り当てられる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="09adf-110">There is some additional overhead that social manager may allocate based on RTA and HTTP updates.</span></span> <span data-ttu-id="09adf-111">リストから `xbox_social_user_group` を作成する場合、追加されるメンバーごとにさらに 2.43 KB が使用されます。</span><span class="sxs-lookup"><span data-stu-id="09adf-111">If creating an `xbox_social_user_group` from list, each added member will take up an additional 2.43 kb.</span></span> <span data-ttu-id="09adf-112">ユーザーが `create_social_social_user_group_from_list` もしくは `update_social_user_group` を介して追加された場合、またはユーザーがタイトルの外部でフレンドを追加した場合には、連続したメモリー領域を検索するために再割り当てが行われることがあります。</span><span class="sxs-lookup"><span data-stu-id="09adf-112">If a user is added either via the `create_social_social_user_group_from_list`, `update_social_user_group`, or the user adding a friend outside of the title, this may cause a realloc to find contiguous memory space.</span></span>

<span data-ttu-id="09adf-113">(1) 4.75 MB の根拠は、`xbox_social_user` 1000人分 (各 2.43 KB × 2) です。</span><span class="sxs-lookup"><span data-stu-id="09adf-113">(1) The 4.75 mb comes from = 1000 `xbox_social_user` at 2.43 kb each \* 2.</span></span> <span data-ttu-id="09adf-114">2 倍は、ソーシャル マネージャーが保持するメモリ バッファーが 2 つあるからです。</span><span class="sxs-lookup"><span data-stu-id="09adf-114">The 2 is that social manager keeps a double memory buffer.</span></span>

## <a name="additional-user-limits"></a><span data-ttu-id="09adf-115">その他のユーザーの制限</span><span class="sxs-lookup"><span data-stu-id="09adf-115">Additional User Limits</span></span>
<span data-ttu-id="09adf-116">現在、Social Manager にはグラフに追加できるユーザー数に 100 人の制限があります。</span><span class="sxs-lookup"><span data-stu-id="09adf-116">Social Manager currently has a restriction of 100 added users to the graph.</span></span> <span data-ttu-id="09adf-117">これは、以下の 2 つの問題が原因です。</span><span class="sxs-lookup"><span data-stu-id="09adf-117">This is due to two problems:</span></span>

1. <span data-ttu-id="09adf-118">ユーザーが持つことができる RTA サブスクリプションの最大数は、1100 です。</span><span class="sxs-lookup"><span data-stu-id="09adf-118">The maximum number of RTA subscriptions that a user can have is 1100.</span></span> <span data-ttu-id="09adf-119">ローカルのユーザーに、1000 人のフレンドがいる場合は、追加のサブスクリプションは 100 人分だけです。</span><span class="sxs-lookup"><span data-stu-id="09adf-119">If a local user has 1000 friends, that only leaves 100 for additional subscriptions.</span></span>
2. <span data-ttu-id="09adf-120">PeopleHub に送信できるユーザーの最大バッチ数は現在、約 100 です。</span><span class="sxs-lookup"><span data-stu-id="09adf-120">The max amount of batch size of users that can be sent to PeopleHub is currently around 100.</span></span>

<span data-ttu-id="09adf-121">Social Manager は、これらの制限のために、リストのソーシャル ユーザー グループに 100 人を超えるユーザーを追加することを許可しません。</span><span class="sxs-lookup"><span data-stu-id="09adf-121">Social Manager communicates this by not allowing a social user group from list to contain more than 100 users.</span></span> <span data-ttu-id="09adf-122">`create_social_user_group_from_list` を介して任意の時点でシステム内に存在できる追加ユーザーの合計には、100 というグローバルな制限があります。</span><span class="sxs-lookup"><span data-stu-id="09adf-122">There is a global limit of 100 total additional users that can be in the system at any time via `create_social_user_group_from_list`.</span></span>

## <a name="processing-time"></a><span data-ttu-id="09adf-123">Processing Time の収集</span><span class="sxs-lookup"><span data-stu-id="09adf-123">Processing Time</span></span>
<span data-ttu-id="09adf-124">Social Manager は、最も少ない場合で 1100 人のユーザーを処理します。</span><span class="sxs-lookup"><span data-stu-id="09adf-124">Social Manager will have at worst case 1100 users.</span></span> <span data-ttu-id="09adf-125">Xbox One の Social Manager のパフォーマンス特性は、作成するソーシャル グラフの数に応じて、`do_work` について最も低い場合で 0.3 ms ～ 0.5 ms です。</span><span class="sxs-lookup"><span data-stu-id="09adf-125">The performance characteristics of social manager on a Xbox One has a worst case of 0.3 ms to 0.5 ms for `do_work` depending on number of social graphs created.</span></span> <span data-ttu-id="09adf-126">典型的な例では、グループが作成されない場合は 0.01 ms、中に 1000 人のユーザーがいるグループの場合は最大 0.2 ms です。</span><span class="sxs-lookup"><span data-stu-id="09adf-126">The typical case is 0.01 ms for with no groups created and up to 0.2  ms for a group with 1000 users in it.</span></span>
