---
title: "高度な Xbox Live のサンドボックス"
author: KevinAsgari
description: "対象パートナーによる開発中に、サンドボックスを使用してコンテンツを分離する方法について説明します。"
ms.assetid: bd8a2c51-2434-4cfe-8601-76b08321a658
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Xbox One, XDK, 対象パートナー, サンドボックス, コンテンツの分離"
ms.openlocfilehash: c2dfd17d0548a73293c8c56341dc8a6859a75985
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="advanced-xbox-live-sandboxes"></a><span data-ttu-id="75f12-104">高度な Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="75f12-104">Advanced Xbox Live sandboxes</span></span>

> <span data-ttu-id="75f12-105">**注** この記事では、サンドボックスの高度な使用について説明します。この記事は主に、複数のチームが参加していて、アクセス許可の要件が複雑な大規模ゲーム スタジオに適用されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-105">**Note** This article explain advanced usage of sandboxes and is mainly applicable to large gaming studios which have multiple teams and complex permissions requirements.</span></span>  <span data-ttu-id="75f12-106">Xbox Live クリエーターズ プログラムに参加している場合、または ID@Xbox 開発者である場合、「[Xbox Live のサンドボックスの概要](xbox-live-sandboxes.md)」をお読みになることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="75f12-106">If you are part of the Xbox Live Creators Program or an ID@Xbox developer, it is recommended to look at the [Xbox Live Sandboxes Intro](xbox-live-sandboxes.md)</span></span>

<span data-ttu-id="75f12-107">Xbox Live の*サンドボックス*は、開発用の完全にプライベートな環境を提供します。</span><span class="sxs-lookup"><span data-stu-id="75f12-107">The Xbox Live *sandbox* provides an entire private environment for development.</span></span> <span data-ttu-id="75f12-108">このドキュメントでは、サンドボックスとは何か、サンドボックスが存在する理由、サンドボックスがパブリッシャーに適用されるしくみ、および、サンドボックスが内部の Xbox チームにどのような影響を及ぼすかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="75f12-108">This document explains what sandboxes are, why they exist, how they apply to publishers, and how they impact internal Xbox teams.</span></span> <span data-ttu-id="75f12-109">このドキュメントの対象読者は、Xbox One コンテンツを構築したり、サンドボックスを利用したりするパブリッシャーです。</span><span class="sxs-lookup"><span data-stu-id="75f12-109">The audience for this document is publishers who build Xbox One content and use sandboxes.</span></span>

## <a name="summary"></a><span data-ttu-id="75f12-110">概要</span><span class="sxs-lookup"><span data-stu-id="75f12-110">Summary</span></span>

<span data-ttu-id="75f12-111">Xbox Live では、単一の実稼働環境のみが存在し、すべてのプレリリース (開発中およびベータ) コンテンツ、サーティフィケーション コンテンツ、およびリテール コンテンツがその環境に存在します。</span><span class="sxs-lookup"><span data-stu-id="75f12-111">In Xbox Live, there is only a single production environment where all prerelease (in-development and beta), certification, and retail content resides.</span></span>

<span data-ttu-id="75f12-112">コンテンツの分離は、実稼働環境でパブリッシャーのコンテンツの漏洩がないことを保証するための手段です。</span><span class="sxs-lookup"><span data-stu-id="75f12-112">Content isolation is the way to ensure that there are no publisher content leaks in production.</span></span> <span data-ttu-id="75f12-113">その中心的な機能として、コンテンツの分離は、リソース (タイトルまたはサービス) にアクセスするための権限を要求するプリンシパル ユーザー、デバイス、またはタイトルが、リソースへのアクセスを承認されていることを保証します。</span><span class="sxs-lookup"><span data-stu-id="75f12-113">At its core, content isolation ensures that any principal user, device, or title that requests permission to access a resource (a title or a service) has been authorized to access the resource.</span></span> <span data-ttu-id="75f12-114">コンテンツの分離により、パーティションはサンドボックスに分割され、タイトルまたはサービスのデータはサンドボックスに格納されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-114">With content isolation, partitions are divided into sandboxes where title or service data is stored.</span></span> <span data-ttu-id="75f12-115">言い方を変えれば、承認ポリシーはサンドボックスのスコープの内部で定義されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-115">Said differently, authorization policies are defined within the scope of a sandbox.</span></span>

<span data-ttu-id="75f12-116">サンドボックスは、実稼働環境内のデータをパーティション分割するための手段です。</span><span class="sxs-lookup"><span data-stu-id="75f12-116">Sandboxes are a way to partition data that is in production.</span></span> <span data-ttu-id="75f12-117">Xbox 360 の ERA サービスでは、PartnerNet と ProductionNet は 2 つの異なる環境です。</span><span class="sxs-lookup"><span data-stu-id="75f12-117">With Xbox 360 era services, PartnerNet and ProductionNet are two distinct environments.</span></span> <span data-ttu-id="75f12-118">Xbox One の ERA サービスでは、単一の実稼働環境に *n* 個の異なる仮想化環境が含まれ、それぞれの仮想環境がサンドボックスと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="75f12-118">With Xbox One era services, a single production environment contains *n* distinct virtual environments where each virtual environment is called a sandbox.</span></span> <span data-ttu-id="75f12-119">すべてのコンテンツ向けの単一の実稼働環境が存在するので、サンドボックスは実際には、ある環境で生成されたデータが別の環境に移動できない一意の仮想環境です。</span><span class="sxs-lookup"><span data-stu-id="75f12-119">Because there is a single production environment for all content, sandboxes are actually unique virtual environments where data generated in one environment cannot cross over to another.</span></span>

<span data-ttu-id="75f12-120">次の図は単一の実稼働環境を示しており、パブリッシャーはこの環境に、自社用の非公開の開発サンドボックスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="75f12-120">The following figure shows a single production environment in which publishers can create their private development sandboxes.</span></span> <span data-ttu-id="75f12-121">承認されたデベロッパー アカウントまたは開発キットのみが、これらのサンドボックスへのアクセスを許可されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-121">Only authorized dev accounts or dev kits are permitted access to these sandboxes.</span></span>

<span data-ttu-id="75f12-122">図 1.</span><span class="sxs-lookup"><span data-stu-id="75f12-122">Figure 1.</span></span> <span data-ttu-id="75f12-123">実稼働環境内のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="75f12-123">Sandboxes in a production environment.</span></span>

![](images/sandboxes/sandboxes_image1.png)

<span data-ttu-id="75f12-124">PublisherA が自社用の開発サンドボックスを持っているのと同じように、他のパブリッシャーも自社専用の開発サンドボックスを持っています。</span><span class="sxs-lookup"><span data-stu-id="75f12-124">Just as PublisherA has her development sandboxes, other publishers have their own development sandboxes.</span></span> <span data-ttu-id="75f12-125">同じタイトル ID が複数の異なるサンドボックスに存在することもできますが、そのタイトル ID に対して生成されるデータはサンドボックス間で別個です。</span><span class="sxs-lookup"><span data-stu-id="75f12-125">The same title ID may reside in different sandboxes but the data generated for the title ID is distinct across sandboxes.</span></span>

<span data-ttu-id="75f12-126">CERT と RETAIL の 2 つのシステム サンドボックスは Microsoft のみが追加できます。</span><span class="sxs-lookup"><span data-stu-id="75f12-126">There are two system sandboxes that can only be populated by Microsoft: CERT and RETAIL.</span></span> <span data-ttu-id="75f12-127">名前が示すように、CERT サンドボックスはリリース前のサーティフィケーションを受けているタイトル用のサンドボックスであり、RETAIL サンドボックスはすべてのリテール ユーザーおよびリテール デバイスがアクセス可能な実際の製品を表しているサンドボックスです。</span><span class="sxs-lookup"><span data-stu-id="75f12-127">As the names suggest, the CERT sandbox is for titles that are undergoing certification prior to release, while the RETAIL sandbox is the sandbox representing real dollars that is accessible by all retail users and devices.</span></span>

<span data-ttu-id="75f12-128">タイトル ID は従来、Xbox Live 内で一意でしたが、現在ではタイトル ID にサンドボックス ID を加えたものが一意です。</span><span class="sxs-lookup"><span data-stu-id="75f12-128">Whereas a title ID was formerly unique in Xbox Live, now a title ID plus a sandbox ID is unique.</span></span> <span data-ttu-id="75f12-129">以前は一意のものとして扱われていたプロダクト ID やその他の ID 空間にも、同じことが当てはまります。</span><span class="sxs-lookup"><span data-stu-id="75f12-129">The same applies to product IDs and other ID spaces that were once treated as unique.</span></span> <span data-ttu-id="75f12-130">これらはサンドボックス ID とペアにすることが必要になりました。</span><span class="sxs-lookup"><span data-stu-id="75f12-130">They must now be paired with a sandbox ID.</span></span> <span data-ttu-id="75f12-131">Xbox Live のすべてのデータは主に、システム全体を通じてサンドボックス ID によってパーティション分割されることになります。</span><span class="sxs-lookup"><span data-stu-id="75f12-131">All data in Xbox Live will be primarily partitioned by the sandbox ID throughout the system.</span></span>

## <a name="initial-setup-for-a-title"></a><span data-ttu-id="75f12-132">タイトル用の初期セットアップ</span><span class="sxs-lookup"><span data-stu-id="75f12-132">Initial setup for a title</span></span>

<span data-ttu-id="75f12-133">タイトルは Xbox デベロッパー ポータル (XDP) または Windows デベロッパー センターで作成されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-133">A title is born in the Xbox Developer Portal (XDP) or Windows Dev Center.</span></span> <span data-ttu-id="75f12-134">タイトルには、タイトル ID、プロダクト ID、サービス構成 ID (SCID) が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="75f12-134">It is assigned a title ID and a product ID and a service configuration ID (SCID).</span></span>

<span data-ttu-id="75f12-135">この新しい世界では、タイトルまたはプロダクト単体では Xbox Live にとって何の意味もありません。</span><span class="sxs-lookup"><span data-stu-id="75f12-135">In this new world, a title or product on its own doesn’t mean anything to Xbox Live.</span></span> <span data-ttu-id="75f12-136">1 つのタイトルをリテールおよび開発に同時使用することをサポートする必要があるため、必要な区別を付けて維持するためにタイトルの*インスタンス化*をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-136">Because we must support simultaneous retail and development use of a single title, we must support *instancing* of titles in order to make and maintain the necessary distinctions.</span></span> <span data-ttu-id="75f12-137">タイトルのインスタンスはサンドボックスに存在し、これがサンドボックスの役割です。</span><span class="sxs-lookup"><span data-stu-id="75f12-137">An instance of a title resides in a sandbox and this is where sandboxes come in.</span></span>

<span data-ttu-id="75f12-138">タイトルを作成するために、パブリッシャーはプロダクト グループを作成し、プロダクト グループのジャンルを指定してから、その中に個別のプロダクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="75f12-138">In order to create a title, a publisher creates a product group, specifies the genre for the product group, and then creates individual products within it.</span></span> <span data-ttu-id="75f12-139">(詳細については、XDP ドキュメントを参照してください)。次の図は、プロダクト グループ、プロダクト、プロダクト インスタンス、およびサンドボックス間の関係を示しています。</span><span class="sxs-lookup"><span data-stu-id="75f12-139">(For more details, refer to the XDP documentation.) The following diagram illustrates the relationships between a product group, a product, a product instance, and a sandbox.</span></span>

<span data-ttu-id="75f12-140">図 2.</span><span class="sxs-lookup"><span data-stu-id="75f12-140">Figure 2.</span></span> <span data-ttu-id="75f12-141">プロダクト グループ、プロダクト、プロダクト インスタンス、およびサンドボックス間の関係</span><span class="sxs-lookup"><span data-stu-id="75f12-141">The relationships between a product group, a product, a product instance, and a sandbox.</span></span>

![](images/sandboxes/sandboxes_image2.png)

<a name="product-instances"></a><span data-ttu-id="75f12-142">プロダクト インスタンス</span><span class="sxs-lookup"><span data-stu-id="75f12-142">Product instances</span></span>
-----------------

<span data-ttu-id="75f12-143">*プロダクト インスタンス*は、特定のサンドボックス内のタイトル、プロダクト、および構成データを投影したものです。</span><span class="sxs-lookup"><span data-stu-id="75f12-143">A *product instance* is a projection of title, product, and configuration data in a specific sandbox.</span></span> <span data-ttu-id="75f12-144">このデータについて、サービス構成、カタログ メタデータ、およびバイナリの 3 つの領域に分けて説明します。</span><span class="sxs-lookup"><span data-stu-id="75f12-144">This data is described in the following three areas: service configuration, catalog metadata, and binaries.</span></span>

### <a name="service-configuration"></a><span data-ttu-id="75f12-145">サービス構成</span><span class="sxs-lookup"><span data-stu-id="75f12-145">Service configuration</span></span>

> <span data-ttu-id="75f12-146">サービス構成の定義 (イベント、統計、実績など)。</span><span class="sxs-lookup"><span data-stu-id="75f12-146">Service configuration definitions (events, stats, achievements, etc.).</span></span> <span data-ttu-id="75f12-147">サービス構成はプロダクト インスタンスのレベルで定義されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-147">The service configuration is defined at the product instance level.</span></span>

### <a name="catalog-metadata"></a><span data-ttu-id="75f12-148">カタログ メタデータ</span><span class="sxs-lookup"><span data-stu-id="75f12-148">Catalog metadata</span></span>

> <span data-ttu-id="75f12-149">カタログに含まれるメタデータであり、販促テキスト、アート アセット、提供/オファー情報、ライセンス データなどが含まれます。</span><span class="sxs-lookup"><span data-stu-id="75f12-149">The metadata which lives in the Catalog, including sell text, art assets, availability/offer information, licensing data, and more.</span></span>

### <a name="binary"></a><span data-ttu-id="75f12-150">バイナリ</span><span class="sxs-lookup"><span data-stu-id="75f12-150">Binary</span></span>

> <span data-ttu-id="75f12-151">バイナリは 2 つの形態のいずれかで表される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-151">A binary can be represented in either of two ways:</span></span>

1.  <span data-ttu-id="75f12-152">メタデータのみ。サイドローディングを可能にします。</span><span class="sxs-lookup"><span data-stu-id="75f12-152">Metadata only to enable sideloading.</span></span> <span data-ttu-id="75f12-153">これにはコンテンツ ID、バージョン情報、およびライセンス情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="75f12-153">This includes content ID, version info, and licensing info.</span></span>

2.  <span data-ttu-id="75f12-154">CDN に伝達されてクライアントにダウンロード可能となる完全なバイナリ。</span><span class="sxs-lookup"><span data-stu-id="75f12-154">Full binary propagated to a CDN and downloadable to a client.</span></span>

<a name="getting-the-access-right"></a><span data-ttu-id="75f12-155">アクセス権の取得</span><span class="sxs-lookup"><span data-stu-id="75f12-155">Getting the access right</span></span>
------------------------

<span data-ttu-id="75f12-156">Xbox One でのコンテンツへのアクセスには、以下の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-156">There are two distinct types of access to your content in Xbox One:</span></span>

<span data-ttu-id="75f12-157">*設計時アクセス* - PC からの XDP ツールを介したアクセスであり、プロダクトに携わる要員がコンテンツ、構成、およびメタデータをアップロード、整理、および操作することを許可しますが、プロダクトのインスタンスを実行または再生することは許可しません。</span><span class="sxs-lookup"><span data-stu-id="75f12-157">*Design-time access*—access from a PC via the XDP tool—allows people working on your products to upload, organize, and work with content, configuration, and metadata, but does not allow them to run or play instances of your products.</span></span>

<span data-ttu-id="75f12-158">*実行時アクセス* - Xbox 本体からのアクセスであり、デベロッパー、テスト担当者、レビュー担当者、そして最終的にはユーザーがプロダクト インスタンスを実行および再生することを許可します。</span><span class="sxs-lookup"><span data-stu-id="75f12-158">*Run-time access*—access from an Xbox console—allows your developers, testers, reviewers, and eventually your customers to run and play product instances.</span></span>

<span data-ttu-id="75f12-159">**注** 実行時アクセスが可能となるためには、プロダクト インスタンスがサンドボックスに配置されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-159">**Note** In order to be available for run-time access, a product instance must be placed in a sandbox.</span></span> <span data-ttu-id="75f12-160">ビルドがサンドボックスに配置されると、そのサンドボックスへのアクセスを許可されている XDP ユーザーまたは開発キット デバイスがインスタンスを実行できます。</span><span class="sxs-lookup"><span data-stu-id="75f12-160">Once a build is placed in a sandbox, XDP users or devkit devices that have been granted access to that sandbox can run the instance.</span></span> <span data-ttu-id="75f12-161">ユーザーまたはデバイスはそのために、各自のデベロッパー アカウント (実行時アクセスのための仮想ユーザーとして機能する特別なアカウント) の 1 つを使用して Xbox 本体から Xbox One にログオンします。</span><span class="sxs-lookup"><span data-stu-id="75f12-161">To do this, they log on to Xbox One via an Xbox console, using one of their dev accounts—special accounts that function as virtual users for run-time access.</span></span>

<span data-ttu-id="75f12-162">サンドボックスについて言及するとき、通常は、Xbox Live 上で実行されるコンテンツへの実行時アクセスのことを指しています。</span><span class="sxs-lookup"><span data-stu-id="75f12-162">When we are talking about sandboxes, we are typically talking about run-time access to content that runs on Xbox Live.</span></span> <span data-ttu-id="75f12-163">Xbox Live 内のサービスにアクセスするためには、タイトル ID が必要です。</span><span class="sxs-lookup"><span data-stu-id="75f12-163">In order to access a service in Xbox Live, a title ID is required.</span></span> <span data-ttu-id="75f12-164">**appxmanifest** にタイトル ID が入力されると、本体はタイトル ID を Xbox Live に送信します。</span><span class="sxs-lookup"><span data-stu-id="75f12-164">Once an **appxmanifest** contains a title ID, the console will send the title ID to Xbox Live.</span></span> <span data-ttu-id="75f12-165">プリンシパル (デバイスまたはユーザー) がタイトルへのアクセスを許可されていない場合、Xbox Live セキュリティ サービスは有効なトークンを返しません。</span><span class="sxs-lookup"><span data-stu-id="75f12-165">Xbox Live security services will not provide back a valid token unless the principal (device or user) has been given access to the title.</span></span>

<span data-ttu-id="75f12-166">この検証プロセスはコンテンツ分離の核心です。</span><span class="sxs-lookup"><span data-stu-id="75f12-166">This validation process is the crux of content isolation.</span></span> <span data-ttu-id="75f12-167">概略レベルで見た場合、以下のようになります。</span><span class="sxs-lookup"><span data-stu-id="75f12-167">When seen at a very high level:</span></span>

-   <span data-ttu-id="75f12-168">プリンシパル グループには Xbox ユーザー ID (XUID)、デバイス ID、タイトル ID、またはサービス ID が含まれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-168">A principal group can contain Xbox User IDs (XUIDs), device IDs, title IDs or service IDs.</span></span>

-   <span data-ttu-id="75f12-169">サンドボックスにはタイトル ID、プロダクト ID、またはサービス構成 ID (SCID) が含まれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-169">A sandbox can contain title IDs, product IDs or service config IDs (SCIDs).</span></span>

-   <span data-ttu-id="75f12-170">プリンシパル グループにはサンドボックスへのアクセス権が与えられます。</span><span class="sxs-lookup"><span data-stu-id="75f12-170">A principal group is given access to a sandbox.</span></span>

<span data-ttu-id="75f12-171">したがって、ユーザーまたはデバイスがサンドボックス内のプレリリース タイトルにアクセスするには、まず XDP を通じてアクセスを許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-171">So, for a user or device to access a pre-release title in a sandbox, access must be granted through XDP first.</span></span>

<span data-ttu-id="75f12-172">図 3.</span><span class="sxs-lookup"><span data-stu-id="75f12-172">Figure 3.</span></span> <span data-ttu-id="75f12-173">XDP を通じてアクセスをセットアップする場合のモデル</span><span class="sxs-lookup"><span data-stu-id="75f12-173">A model for setting up access through XDP.</span></span>

![](images/sandboxes/sandboxes_image3.png)

<span data-ttu-id="75f12-174">コンテンツの分離の有効性は、組織で以下のプロセスが実施されているという事実に基づきます。</span><span class="sxs-lookup"><span data-stu-id="75f12-174">The effectiveness of content isolation is based on the fact that your organization owns the following processes:</span></span>

-   <span data-ttu-id="75f12-175">XDP ユーザー アカウント、各ユーザーが実行時アクセスのためのログオンに使用するデベロッパー アカウント、および、その中で各ユーザーがメンバーシップを付与されるユーザー グループを作成します。</span><span class="sxs-lookup"><span data-stu-id="75f12-175">Creating your XDP user accounts, the dev accounts that each user will use to log on for run-time access, and the user groups in which each user is granted membership.</span></span>

-   <span data-ttu-id="75f12-176">信頼された本体のデバイス グループを作成します。</span><span class="sxs-lookup"><span data-stu-id="75f12-176">Creating device groups of trusted consoles.</span></span>

-   <span data-ttu-id="75f12-177">どのユーザー グループおよびデバイス グループがサンドボックス内のプロダクト インスタンスにアクセスできるかを、開発サンドボックスごとに正確に指定します。</span><span class="sxs-lookup"><span data-stu-id="75f12-177">Specifying for each of your development sandboxes precisely which user groups and device groups have access to the product instances in it.</span></span>

<span data-ttu-id="75f12-178">このセットアップの例は次のように示されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-178">An example of this setup is illustrated in the figure below.</span></span>

<span data-ttu-id="75f12-179">図 4.</span><span class="sxs-lookup"><span data-stu-id="75f12-179">Figure 4.</span></span> <span data-ttu-id="75f12-180">承認されていないユーザーの資格情報ではサンドボックスへのアクセスに失敗します。承認された XDP ユーザー アカウントの通常の資格情報でも同様です。</span><span class="sxs-lookup"><span data-stu-id="75f12-180">An unauthorized user's credentials fail to gain access to the sandbox, as do the ordinary credentials of an authorized XDP user account.</span></span> <span data-ttu-id="75f12-181">承認された XDP ユーザー アカウントによって所有されるデベロッパー アカウントの資格情報のみが、サンドボックスと、現在そのサンドボックス内にあるすべてのプロダクト インスタンスへの実行時アクセスに成功します。</span><span class="sxs-lookup"><span data-stu-id="75f12-181">Only the credentials of the dev account owned by the authorized XDP user account succeed in gaining run-time access to the sandbox, and to all of the product instances currently in it.</span></span>

![](images/sandboxes/sandboxes_image4.png)

### <a name="dev-accounts-setup"></a><span data-ttu-id="75f12-182">デベロッパー アカウントのセットアップ</span><span class="sxs-lookup"><span data-stu-id="75f12-182">Dev accounts setup</span></span>

<span data-ttu-id="75f12-183">Xbox One のデベロッパー アカウントは、特別なルールが適用された標準の Microsoft アカウント (MSA) にすぎません。</span><span class="sxs-lookup"><span data-stu-id="75f12-183">Dev accounts in Xbox One are just standard Microsoft accounts (MSA) with special rules applied to them.</span></span> <span data-ttu-id="75f12-184">開発のために Xbox Live で使用されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-184">They are used in Xbox Live for development.</span></span> <span data-ttu-id="75f12-185">デベロッパー アカウントの特性は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="75f12-185">A dev account:</span></span>

-   <span data-ttu-id="75f12-186">XDP または Windows デベロッパー センターで作成される必要があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-186">Must be created from XDP or Windows Dev Center.</span></span>

-   <span data-ttu-id="75f12-187">パブリッシャーによって作成されるときに、外部デベロッパーのロールを割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="75f12-187">Is assigned the external developer role when created by publishers.</span></span>

-   <span data-ttu-id="75f12-188">開発アカウントを作成した XDP アカウントまたは Windows デベロッパー センター アカウントと結び付けられます。</span><span class="sxs-lookup"><span data-stu-id="75f12-188">Is tied to the XDP account or Windows Dev Center account that created the dev account.</span></span>

-   <span data-ttu-id="75f12-189">開発キットにしかログインできません。</span><span class="sxs-lookup"><span data-stu-id="75f12-189">Can only log in to dev kits.</span></span> <span data-ttu-id="75f12-190">リテール デバイス上ではデベロッパー アカウントへのログインは拒否されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-190">Login is denied to a dev account on retail devices.</span></span>

-   <span data-ttu-id="75f12-191">テストを行うために、Xbox Live デベロッパー ゴールド メンバーシップまたはその他のメンバーシップを無料で購入できます。</span><span class="sxs-lookup"><span data-stu-id="75f12-191">Can purchase Xbox Live Developer Gold subscription or other subscriptions for free in order to test.</span></span>

### <a name="user-group-setup"></a><span data-ttu-id="75f12-192">ユーザー グループのセットアップ</span><span class="sxs-lookup"><span data-stu-id="75f12-192">User group setup</span></span>

<span data-ttu-id="75f12-193">第 1 の種類のプリンシパル グループであるユーザー グループは XDP ユーザーのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="75f12-193">A user group, the first kind of principal group, is a collection of XDP users.</span></span> <span data-ttu-id="75f12-194">XDP ユーザーがユーザー グループに追加されるとき、これらの XDP ユーザーにはデベロッパー アカウントが付随します。</span><span class="sxs-lookup"><span data-stu-id="75f12-194">When XDP users are added to user groups, their dev accounts flow with these XDP users.</span></span>

<span data-ttu-id="75f12-195">したがって、ユーザー グループがサンドボックスに割り当てられるとき、そのユーザー グループ内の XDP ユーザーと関連付けられたデベロッパー アカウントが適切なプリンシパル グループに追加され、プリンシパル グループは、サンドボックスの裏付けとなるプライマリー リソース セットによってポリシーをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="75f12-195">So when a user group is assigned to a sandbox, the dev accounts associated with the XDP users in that user group get added to appropriate principal groups and the principal groups get a policy setup with the primary resource set backing the sandbox.</span></span>

<span data-ttu-id="75f12-196">**注** サンドボックスにアクセスするために作成されるユーザー グループは、プロダクト グループおよびプロダクトの XDP 内構成データへのアクセスを防ぐために使用されるものと同じユーザー グループです。</span><span class="sxs-lookup"><span data-stu-id="75f12-196">**Note** The user groups that are created to access sandboxes are the same user groups that are used to prevent access to configuration data in XDP for product groups and products.</span></span>

### <a name="device-setup"></a><span data-ttu-id="75f12-197">デバイスのセットアップ</span><span class="sxs-lookup"><span data-stu-id="75f12-197">Device setup</span></span>

<span data-ttu-id="75f12-198">デバイスもプリンシパル グループに追加されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-198">A device also gets added to a principal group.</span></span> <span data-ttu-id="75f12-199">Game Developer Store を通じて資格を購入し、デバイスを開発キットとしてプロビジョニングする場合、デバイスは開発キットとしてのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="75f12-199">A device can only be used as a dev kit if an entitlement is purchased through the Game Developer Store and the device is provisioned to be a dev kit.</span></span> <span data-ttu-id="75f12-200">デバイスが開発キットとしてプロビジョニングされると、デバイス グループに追加できるデバイスの一覧にそのデバイスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-200">Once a device is provisioned as a dev kit, the device shows up in the list of devices that can be added to device groups.</span></span>

### <a name="device-group-setup"></a><span data-ttu-id="75f12-201">デバイス グループのセットアップ</span><span class="sxs-lookup"><span data-stu-id="75f12-201">Device group setup</span></span>

<span data-ttu-id="75f12-202">第 2 の種類のプリンシパル グループであるデバイス グループにもサンドボックスへのアクセス権を付与できます。</span><span class="sxs-lookup"><span data-stu-id="75f12-202">A device group, the second kind of principal group, can also be given access to sandboxes.</span></span> <span data-ttu-id="75f12-203">セットアップは、前に詳しく説明したユーザー グループのセットアップと同様です。</span><span class="sxs-lookup"><span data-stu-id="75f12-203">The setup is similar to the user group setup detailed above.</span></span>

## <a name="sandboxes"></a><span data-ttu-id="75f12-204">サンドボックス</span><span class="sxs-lookup"><span data-stu-id="75f12-204">Sandboxes</span></span>

<a name="what-is-a-sandbox"></a><span data-ttu-id="75f12-205">サンドボックスとは</span><span class="sxs-lookup"><span data-stu-id="75f12-205">What is a sandbox?</span></span>
------------------

<span data-ttu-id="75f12-206">簡潔に言えば、*サンドボックスは実稼働環境のデータをパーティション分割するための手段です*。</span><span class="sxs-lookup"><span data-stu-id="75f12-206">Stated simply, *a sandbox is a way to partition data in production*.</span></span>

<a name="why-do-we-need-sandboxes"></a><span data-ttu-id="75f12-207">サンドボックスが必要な理由</span><span class="sxs-lookup"><span data-stu-id="75f12-207">Why do we need sandboxes?</span></span>
-------------------------

<span data-ttu-id="75f12-208">ユーザーやデバイスがタイトルにアクセスするのと同じように、タイトルはサービスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="75f12-208">Just as users and devices access titles, titles access services.</span></span> <span data-ttu-id="75f12-209">タイトルの集合がサービス リソースへのアクセスを許可される "タイトル グループ" の概念が導入されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-209">We introduce a concept of “title group” where sets of titles are granted access to service resources.</span></span>

<span data-ttu-id="75f12-210">Xbox One では、すべてのコンテンツ (プレリリースおよびリテール) 向けの単一の実稼働環境しか存在しないため、リソースの同じインスタンス上で 1 つのタイトルの複数のインスタンス (プレリリース/リテール) を稼働させることは避ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-210">Because there is a single production environment for Xbox One for all content (pre-release and retail), multiple instances (pre-release/retail) of a title must be prevented from operating on the same instances of resources.</span></span>

<a name="what-is-in-a-sandbox"></a><span data-ttu-id="75f12-211">サンドボックスの内容</span><span class="sxs-lookup"><span data-stu-id="75f12-211">What is in a sandbox?</span></span>
---------------------

<span data-ttu-id="75f12-212">サンドボックスには、サンドボックスに追加されるすべてのタイトルのプロダクト インスタンスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="75f12-212">A sandbox contains a product instance for every title that gets added to the sandbox.</span></span>

<a name="what-is-a-sandbox-id"></a><span data-ttu-id="75f12-213">サンドボックス ID とは</span><span class="sxs-lookup"><span data-stu-id="75f12-213">What is a sandbox ID?</span></span>
---------------------

<span data-ttu-id="75f12-214">サンドボックス ID は、タイトル、プロダクト、またはサービス構成のデータのパーティション分割単位です。</span><span class="sxs-lookup"><span data-stu-id="75f12-214">A sandbox ID is a partitioning unit of data for a title, product, or service config.</span></span> <span data-ttu-id="75f12-215">複数のタイトルが同じサンドボックスに共存でき、そのことは、それらのタイトルが何らかのサービス構成データを共有するための前提条件です。</span><span class="sxs-lookup"><span data-stu-id="75f12-215">Multiple titles can exist in the same sandbox, which is a prerequisite for them to share any service config data.</span></span>

<span data-ttu-id="75f12-216">大文字と小文字が区別されるサンドボックス ID は、&lt;PublisherMoniker&gt;.*n* という形式の文字列です。</span><span class="sxs-lookup"><span data-stu-id="75f12-216">A sandbox ID (case sensitive) is a string in the following format: &lt;PublisherMoniker&gt;.*n*.</span></span> <span data-ttu-id="75f12-217">XLDP.5 というサンドボックス ID の例の説明は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="75f12-217">An example sandbox ID, XLDP.5, is explained below:</span></span>

-   <span data-ttu-id="75f12-218">*パブリッシャー モニカー*はすべてのパブリッシャー間で一意です。</span><span class="sxs-lookup"><span data-stu-id="75f12-218">The *publisher moniker* is unique across all publishers.</span></span> <span data-ttu-id="75f12-219">したがって、"XLPD" はこの特定のパブリッシャーのパブリッシャー モニカーです。</span><span class="sxs-lookup"><span data-stu-id="75f12-219">So, “XLPD” is the publisher moniker for this particular publisher.</span></span> <span data-ttu-id="75f12-220">パブリッシャー モニカーは、デベロッパー アカウント マネージャーによってパブリッシャーが XDP 内で "アクティベーション" されるときに作成されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-220">A publisher moniker is created when a publisher is “activated” in XDP by the developer account manager.</span></span>

-   <span data-ttu-id="75f12-221">数字 "*n*" はサンドボックスの数を識別します。</span><span class="sxs-lookup"><span data-stu-id="75f12-221">The digit *“n”* identifies the number of the sandbox.</span></span> <span data-ttu-id="75f12-222">この場合、"5" はこのパブリッシャー用に作成される 6 番目のサンドボックスです。</span><span class="sxs-lookup"><span data-stu-id="75f12-222">In this case, “5” is the sixth sandbox created for this publisher.</span></span>

<span data-ttu-id="75f12-223">タイトルのデータがサービスを通って移動するとき、Xbox サービスはサンドボックス ID を使用して、生成されるデータの "環境" を一意に識別します。</span><span class="sxs-lookup"><span data-stu-id="75f12-223">When the title data moves through services, Xbox services use the sandbox ID to uniquely identify the “environment” for the data that is generated.</span></span>

<a name="what-data-is-sandboxed"></a><span data-ttu-id="75f12-224">どのようなデータがサンドボックス化されるか</span><span class="sxs-lookup"><span data-stu-id="75f12-224">What data is sandboxed?</span></span>
-----------------------

<span data-ttu-id="75f12-225">次の図では、どのようなユーザー データやタイトル データがサンドボックス化されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="75f12-225">The diagram below shows what user and title data is sandboxed.</span></span>

![](images/sandboxes/sandboxes_image5.png)

<a name="global-override-sandbox"></a><span data-ttu-id="75f12-226">グローバル オーバーライド サンドボックス</span><span class="sxs-lookup"><span data-stu-id="75f12-226">Global override sandbox</span></span>
-----------------------

<span data-ttu-id="75f12-227">デベロッパーは、開発キット上でサンドボックス ID を設定することによって、開発キットが動作するサンドボックスを設定します。これはグローバル オーバーライド サンドボックスとも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="75f12-227">A developer sets the sandbox ID on her dev kit and thus sets the sandbox that the dev kit runs in; this is also known as the global override sandbox.</span></span> <span data-ttu-id="75f12-228">したがって、開発キットで Xbox Live サービス (実績、マッチメイキング、ライセンス、EDS など) に対してタイトル (シェル アプリおよび通常のアプリ) から実行されるすべての要求はそのサンドボックスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-228">Thus, all requests made to Xbox Live services (for example, achievements, matchmaking, licensing, EDS, etc.) from the titles (shell apps and regular apps) in the dev kit are made in that sandbox.</span></span>

<span data-ttu-id="75f12-229">グローバル オーバーライド サンドボックスには、このサンドボックスに取り込まれたコンテンツのみがブラウズ時に表示されるという効力もあります。</span><span class="sxs-lookup"><span data-stu-id="75f12-229">The global override sandbox also implies that only the content ingested in the global override sandbox is visible when being browsed.</span></span>

<a name="types-of-sandboxes"></a><span data-ttu-id="75f12-230">サンドボックスの種類</span><span class="sxs-lookup"><span data-stu-id="75f12-230">Types of sandboxes</span></span>
-------------------------------------------------------------------------------------------------------------------------------------------------------

<span data-ttu-id="75f12-231">サンドボックスには 2 つの異なるカテゴリーがあります。</span><span class="sxs-lookup"><span data-stu-id="75f12-231">There are two different categories of sandboxes.</span></span> <span data-ttu-id="75f12-232">これらのカテゴリーは以下のように定義されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-232">These categories are defined as follows:</span></span>

-   <span data-ttu-id="75f12-233">*パブリッシャー サンドボックス*。</span><span class="sxs-lookup"><span data-stu-id="75f12-233">*Publisher sandboxes*.</span></span> <span data-ttu-id="75f12-234">パブリッシャーは各自の開発中サンドボックスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="75f12-234">Publishers have access to their in-development sandboxes.</span></span> <span data-ttu-id="75f12-235">これらは XLDP.0、XLDP.1、XLDP.2、XLDP.3 のような名前になります。これは、パブリッシャーが自社タイトルのプロダクト インスタンスを配置する場所です。</span><span class="sxs-lookup"><span data-stu-id="75f12-235">These may look like XLDP.0, XLDP.1, XLDP.2, XLDP.3, etc. This is where publishers would put their title product instances.</span></span> <span data-ttu-id="75f12-236">これらのサンドボックスへのアクセスは、パブリッシャーがアクセスを許可するユーザー/デバイスに限定されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-236">Access to these sandboxes is gated to the users/devices that the publishers grants access to</span></span>

-   <span data-ttu-id="75f12-237">*Microsoft サンドボックス*。</span><span class="sxs-lookup"><span data-stu-id="75f12-237">*Microsoft sandboxes*.</span></span> <span data-ttu-id="75f12-238">これらは組み込みのサンドボックスである RETAIL および CERT です。Microsoft のみが、これらの保護されたサンドボックスに公開することを許可されています。</span><span class="sxs-lookup"><span data-stu-id="75f12-238">These are the built-in sandboxes: RETAIL and CERT Only Microsoft is allowed to publish to these protected sandboxes.</span></span>

<a name="cert-sandbox"></a><span data-ttu-id="75f12-239">CERT サンドボックス</span><span class="sxs-lookup"><span data-stu-id="75f12-239">CERT sandbox</span></span>
------------

<span data-ttu-id="75f12-240">一般提供の準備ができたタイトルは、まずサーティフィケーションを通過する必要があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-240">When a title is ready for general availability, it needs to go through certification first.</span></span> <span data-ttu-id="75f12-241">CERT サンドボックスは Microsoft が管理するサンドボックスであり、サーティフィケーションの担当者のみがアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="75f12-241">The CERT sandbox is a Microsoft-controlled sandbox that only individuals in certification have access to.</span></span> <span data-ttu-id="75f12-242">パブリッシャーは、自社が保有するどのコンテンツがサーティフィケーションを通過しているかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="75f12-242">Publishers can see what content they own is going through certification.</span></span>

<span data-ttu-id="75f12-243">サーティフィケーション中に不合格となったプロダクト インスタンスは、パブリッシャーが XDP を使用してデバッグと修正を行えるよう、開発サンドボックスに戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="75f12-243">Any product instances that fail while in certification can be brought back to a development sandbox to be debugged and fixed by the publishers using XDP.</span></span>

<a name="retail-sandbox"></a><span data-ttu-id="75f12-244">RETAIL サンドボックス</span><span class="sxs-lookup"><span data-stu-id="75f12-244">RETAIL sandbox</span></span>
--------------

<span data-ttu-id="75f12-245">RETAIL サンドボックスは、Xbox One 向けに作成されるすべてのコンテンツの最終目的地です。</span><span class="sxs-lookup"><span data-stu-id="75f12-245">The RETAIL sandbox is the final destination for all content that is created for Xbox One.</span></span>

<span data-ttu-id="75f12-246">サーティフィケーションに合格した後、タイトルは RETAIL サンドボックスに追加されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-246">After a title passes certification, it is added to the RETAIL sandbox.</span></span> <span data-ttu-id="75f12-247">署名済みコンテンツのみが RETAIL サンドボックスでの実行を許可されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-247">Only green signed content is permitted to run in the RETAIL sandbox.</span></span> <span data-ttu-id="75f12-248">これには、パブリッシャー主導型のベータも RETAIL サンドボックスで実行されるという重要な意味があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-248">This has an important implication that publisher-driven betas are also done in the RETAIL sandbox.</span></span> <span data-ttu-id="75f12-249">RETAIL サンドボックスで生成されるデータは実際の顧客の実稼働データを表します。</span><span class="sxs-lookup"><span data-stu-id="75f12-249">Data generated in the RETAIL sandbox represents real customer production data.</span></span>

<span data-ttu-id="75f12-250">RETAIL サンドボックス内のコンテンツへのアクセスは、引き続き、コンテンツの分離を通じて制御可能であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="75f12-250">Note that access to content is the RETAIL sandbox is still controllable through content isolation.</span></span>

<span data-ttu-id="75f12-251">たとえば、パブリッシャー主導型のベータは RETAIL サンドボックスで実行され、ここでは、パブリッシャーが定義するベータ リソース セット タイトルにどのプリンシパル グループがアクセスできるかをパブリッシャーが選択します。</span><span class="sxs-lookup"><span data-stu-id="75f12-251">For example, publisher-driven betas are run in the RETAIL sandbox, where the publisher chooses which principal groups get to access publisher-defined beta resource set titles.</span></span> <span data-ttu-id="75f12-252">ベータ タイトルによって生成されるサービス データは実際の実稼働データであり、タイトルが一般提供に移行した後も存続します。</span><span class="sxs-lookup"><span data-stu-id="75f12-252">The service data generated by the beta titles is real prod data and continues to exist once the title goes to general availability.</span></span>

<a name="cross-sandbox-data-interaction"></a><span data-ttu-id="75f12-253">サンドボックス間のデータのやり取り</span><span class="sxs-lookup"><span data-stu-id="75f12-253">Cross-sandbox data interaction</span></span>
------------------------------

<span data-ttu-id="75f12-254">定義によれば、サンドボックスはデータの共有を制限するコンテナーです。</span><span class="sxs-lookup"><span data-stu-id="75f12-254">By definition, a sandbox is a container that restricts data sharing.</span></span> <span data-ttu-id="75f12-255">したがって、サンドボックス間のデータのやり取りは不可能です。</span><span class="sxs-lookup"><span data-stu-id="75f12-255">Thus, cross-sandbox data interaction is not possible.</span></span>

## <a name="organizing-your-sandboxes"></a><span data-ttu-id="75f12-256">サンドボックスの整理</span><span class="sxs-lookup"><span data-stu-id="75f12-256">Organizing your sandboxes</span></span>

<span data-ttu-id="75f12-257">このセクションでは、パブリッシャーが実行できるサンドボックスの整理方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="75f12-257">This section provides an example of how a publisher can organize sandboxes.</span></span> <span data-ttu-id="75f12-258">パブリッシャーは、サンドボックスを使用してデータを整理する方法を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="75f12-258">A publisher needs to understand how to use sandboxes to organize data.</span></span>

<span data-ttu-id="75f12-259">**注** 以下の例では、コンテンツの分離による実行時アクセス管理のみを示します。</span><span class="sxs-lookup"><span data-stu-id="75f12-259">**Note** The examples below only show run-time access management with content isolation.</span></span>

### <a name="scenario-1-two-titles-one-sandbox"></a><span data-ttu-id="75f12-260">シナリオ 1: 2 つのタイトル、1 つのサンドボックス</span><span class="sxs-lookup"><span data-stu-id="75f12-260">Scenario 1: Two titles, one sandbox</span></span>

<span data-ttu-id="75f12-261">パブリッシャーにとっての基本的な構造として次のようなものが考えられます。</span><span class="sxs-lookup"><span data-stu-id="75f12-261">The basic structure for a publisher could be:</span></span>

-   <span data-ttu-id="75f12-262">設計時と実行時のいずれにおいても、すべてのユーザー、およびパブリッシャーが保有するすべてのデバイスがアクセスできる 2 つのタイトル。</span><span class="sxs-lookup"><span data-stu-id="75f12-262">Two titles that are accessible to all users and devices owned by the publisher for both design time and runtime.</span></span>

-   <span data-ttu-id="75f12-263">タイトルごとに 1 つのプロダクト インスタンス。</span><span class="sxs-lookup"><span data-stu-id="75f12-263">One product instance per title.</span></span>

<span data-ttu-id="75f12-264">この場合、パブリッシャーに必要なのは、すべてのプレリリース コンテンツ用の 1 つのサンドボックスだけです。</span><span class="sxs-lookup"><span data-stu-id="75f12-264">In this instance, the publisher just needs a single sandbox for all pre-release content.</span></span>

<span data-ttu-id="75f12-265">次の図にユーザー グループを示します。</span><span class="sxs-lookup"><span data-stu-id="75f12-265">The diagram below shows a user group.</span></span> <span data-ttu-id="75f12-266">パブリッシャーは、その方が容易だと思われるのであれば、ユーザー グループの代わりにデバイス グループを使用してもかまいません。</span><span class="sxs-lookup"><span data-stu-id="75f12-266">The publisher may choose to use a device group instead of a user group, if deemed easier.</span></span> <span data-ttu-id="75f12-267">また、このユーザー グループは、サンドボックス XLDP.1 とこのサンドボックス内のタイトルに、実行時および設計時にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="75f12-267">Also, this user group has run-time and design-time access to sandbox XLDP.1 and the titles in this sandbox.</span></span>

![](images/sandboxes/sandboxes_image6.png)

### <a name="scenario-2-one-title-different-teams"></a><span data-ttu-id="75f12-268">シナリオ 2: 1 つのタイトル、異なるチーム</span><span class="sxs-lookup"><span data-stu-id="75f12-268">Scenario 2: One title, different teams</span></span>

<span data-ttu-id="75f12-269">このモデルでの要件は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="75f12-269">In this model, the requirements are:</span></span>

-   <span data-ttu-id="75f12-270">1 つのタイトル。</span><span class="sxs-lookup"><span data-stu-id="75f12-270">One title.</span></span>

-   <span data-ttu-id="75f12-271">開発チームは日単位のビルドを使用して作業する。</span><span class="sxs-lookup"><span data-stu-id="75f12-271">Dev team works on daily builds.</span></span>

-   <span data-ttu-id="75f12-272">QA チームは週単位の LKG を使用して作業する。</span><span class="sxs-lookup"><span data-stu-id="75f12-272">QA team works on weekly LKGs.</span></span>

-   <span data-ttu-id="75f12-273">バグがあった場合、開発チームは週単位の LKG をデバッグする必要がある。</span><span class="sxs-lookup"><span data-stu-id="75f12-273">Dev team needs to debug weekly LKGs in case of bugs.</span></span>

-   <span data-ttu-id="75f12-274">ファイナンス チームは、タイトルのカタログ リリースに関連する価格カードやその他のメタデータにアクセスする必要がある。</span><span class="sxs-lookup"><span data-stu-id="75f12-274">The finance team needs access to the price cards and other metadata related to the catalog release of a title.</span></span>

<span data-ttu-id="75f12-275">次の図は、TitleX に 2 つのプロダクト インスタンス PI-1 および PI-2 があることを示します。</span><span class="sxs-lookup"><span data-stu-id="75f12-275">The figure below shows that TitleX has two product instances: PI-1 and PI-2.</span></span> <span data-ttu-id="75f12-276">プロダクト インスタンスはサンドボックス内に存在する必要がありますが、同じタイトルの 2 つのプロダクト インスタンスが同じサンドボックス内に存在することはできません。</span><span class="sxs-lookup"><span data-stu-id="75f12-276">A product instance has to be in a sandbox and two product instances of the same title cannot be in the same sandbox.</span></span> <span data-ttu-id="75f12-277">そのため、TitleX-PI-1 はサンドボックス XLDP.1 内にあり、TitleX-PI-2 はサンドボックス XLDP.2 内にあります。</span><span class="sxs-lookup"><span data-stu-id="75f12-277">Thus, TitleX-PI-1 is in sandbox XLDP.1 and TitleX-PI-2 is in sandbox XLDP.2.</span></span>

<span data-ttu-id="75f12-278">開発ユーザー グループは両方のサンドボックスにアクセスできますが、QA ユーザー グループはサンドボックス XLDP.2 にしかアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="75f12-278">The dev user group has access to both sandboxes, whereas the QA user group has access to only sandbox XLDP.2.</span></span>

<span data-ttu-id="75f12-279">また、ファイナンス ユーザー (Group C) は TitleX への設計時アクセスが可能です。</span><span class="sxs-lookup"><span data-stu-id="75f12-279">Also, the finance user (Group C) has design-time access to TitleX.</span></span> <span data-ttu-id="75f12-280">ファイナンス ユーザー グループは通常、タイトルの実行時デバッグにはかかわらないため、分離されています。</span><span class="sxs-lookup"><span data-stu-id="75f12-280">Because the finance user group will not typically do any run-time debugging of a title, they are separated out.</span></span>

<span data-ttu-id="75f12-281">**注** 組織に関係なく、XDP ユーザーは複数のユーザー グループに属することができます。</span><span class="sxs-lookup"><span data-stu-id="75f12-281">**Note** Irrespective of the organization, an XDP user can belong in more than one user group.</span></span>

![](images/sandboxes/sandboxes_image7.png)

### <a name="scenario-3-two-titles-completely-separate"></a><span data-ttu-id="75f12-282">シナリオ 3: 2 つのタイトル、完全に分離</span><span class="sxs-lookup"><span data-stu-id="75f12-282">Scenario 3: Two titles, completely separate</span></span>

<span data-ttu-id="75f12-283">この例では、要件が少し異なります。</span><span class="sxs-lookup"><span data-stu-id="75f12-283">In this example, the requirements change a bit:</span></span>

-   <span data-ttu-id="75f12-284">2 つのタイトル。</span><span class="sxs-lookup"><span data-stu-id="75f12-284">Two titles.</span></span>

-   <span data-ttu-id="75f12-285">各タイトルへのアクセスを特定の個人の集合に制限する必要がある。</span><span class="sxs-lookup"><span data-stu-id="75f12-285">Access to each title should be limited to a certain set of individuals.</span></span>

-   <span data-ttu-id="75f12-286">タイトルごとに 1 つのプロダクト インスタンス。</span><span class="sxs-lookup"><span data-stu-id="75f12-286">One product instance per title.</span></span>

-   <span data-ttu-id="75f12-287">タイトルの設計時 XDP 構成データにアクセスする必要がある管理ユーザー グループ。</span><span class="sxs-lookup"><span data-stu-id="75f12-287">An admin user group who needs access to design-time XDP config data for the titles.</span></span> <span data-ttu-id="75f12-288">このグループ内の個人は全員がパブリッシャーの管理者であり、カタログに発行されるすべてのデータ (カタログ メタデータ、ファイナンス、マーケティング、サーティフィケーション提出物など) を制御できます。</span><span class="sxs-lookup"><span data-stu-id="75f12-288">The individuals in this group are all admins for the publisher and can control all data that is published to the catalog (catalog metadata, finance, marketing, certification submission, etc.)</span></span>

<span data-ttu-id="75f12-289">このモデルでは、パブリッシャーは両方のタイトルの完全な分離を維持することを選択し、これら 2 つのタイトルを 2 つの異なるサンドボックスに割り当てました。</span><span class="sxs-lookup"><span data-stu-id="75f12-289">In this model, the publisher has chosen to keep both titles completely separated and thus assigned these two titles in two different sandboxes.</span></span> <span data-ttu-id="75f12-290">またパブリッシャーは、別個の管理ユーザー グループを作成することを選択し、2 つのプロダクトへのアクセスを割り当てました。</span><span class="sxs-lookup"><span data-stu-id="75f12-290">The publisher has also chosen to create a separate admin user group and assigned access to the two products.</span></span>

![](images/sandboxes/sandboxes_image8.png)

### <a name="scenario-4-anyway-you-like-it"></a><span data-ttu-id="75f12-291">シナリオ 4: 自由自在に</span><span class="sxs-lookup"><span data-stu-id="75f12-291">Scenario 4: Anyway you like it</span></span>

<span data-ttu-id="75f12-292">以下の例では、接続の数を少なくして説明を短くするために、サンドボックスの実行時接続のみを示しました。</span><span class="sxs-lookup"><span data-stu-id="75f12-292">Due to the number of connections and to keep the verbiage short, we have chosen to show only the sandbox run-time connections.</span></span> <span data-ttu-id="75f12-293">設計時のその他のアクセス許可も自由に追加することができます。</span><span class="sxs-lookup"><span data-stu-id="75f12-293">Nothing prevents you from adding other design-time access permissions as well.</span></span>

<span data-ttu-id="75f12-294">この例では、要件は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="75f12-294">In this example, the requirements are:</span></span>

-   <span data-ttu-id="75f12-295">パブリッシャー内部の特定の要員のみが特定のタイトルにアクセスできる。</span><span class="sxs-lookup"><span data-stu-id="75f12-295">Only certain people have access to certain titles inside their publisher.</span></span>

-   <span data-ttu-id="75f12-296">パブリッシャーはさまざまな企業のベンダーと協業し、これらのベンダーは短期契約である場合がある。</span><span class="sxs-lookup"><span data-stu-id="75f12-296">The publisher works with vendors from different companies and these vendors may be short-term.</span></span>

-   <span data-ttu-id="75f12-297">パブリッシャーは、タイトルを使用停止にすることによって、ベンダーまたは FTE がアクセスしていたデータへのアクセスを遮断できる必要がある。</span><span class="sxs-lookup"><span data-stu-id="75f12-297">The publisher should be able to decommission a title and by doing so, prevent access to any data that the vendors or FTEs had access to.</span></span>

<span data-ttu-id="75f12-298">この要件をモデル化するために、次のような構造を採用することができます。</span><span class="sxs-lookup"><span data-stu-id="75f12-298">In order to model this requirement, a structure such as the one below can be adopted.</span></span>

<span data-ttu-id="75f12-299">従ったモデルは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="75f12-299">The model followed below is:</span></span>

-   <span data-ttu-id="75f12-300">TitleX と TitleY のプロダクト インスタンスが、サンドボックス XLDP.1 にそれぞれ 1 つだけある。</span><span class="sxs-lookup"><span data-stu-id="75f12-300">TitleX and TitleY have only one product instance each in sandbox XLDP.1.</span></span>

-   <span data-ttu-id="75f12-301">TitleZ には 2 つのプロダクト インスタンスがあり、1 つはサンドボックス XLDP.2 に、もう 1 つはサンドボックス XLDP.3 にある。</span><span class="sxs-lookup"><span data-stu-id="75f12-301">TitleZ has two product instances, one in sandbox XLDP.2 and another in sandbox XLDP.3.</span></span>

-   <span data-ttu-id="75f12-302">FTE User Group B は、すべてのサンドボックス内のプロダクト インスタンスへのアクセスを付与される。</span><span class="sxs-lookup"><span data-stu-id="75f12-302">FTE User Group B is given access to product instances in all sandboxes.</span></span>

-   <span data-ttu-id="75f12-303">Vendor User Group A はベンダーのみのユーザー グループであり、サンドボックス XLDP.1 へのアクセスを付与される。</span><span class="sxs-lookup"><span data-stu-id="75f12-303">Vendor User Group A is a vendor-only user group that is given access to sandbox XLDP.1.</span></span>

-   <span data-ttu-id="75f12-304">Vendor Device Group C はベンダーのみのユーザー グループであり、サンドボックス XLDP.3 へのアクセスを付与される。</span><span class="sxs-lookup"><span data-stu-id="75f12-304">Vendor Device Group C is a vendor-only user group that is given access to sandbox XLDP.3.</span></span>

![](images/sandboxes/sandboxes_image9.png)

## <a name="summary"></a><span data-ttu-id="75f12-305">まとめ</span><span class="sxs-lookup"><span data-stu-id="75f12-305">Summary</span></span>

<span data-ttu-id="75f12-306">Xbox Live 開発では、実稼働品質のサービスと MSA デベロッパー アカウントを使用して実稼働環境でテストを行うための、これ以上ない機会がパブリッシャーに提供されます。</span><span class="sxs-lookup"><span data-stu-id="75f12-306">Xbox Live development provides tremendous opportunity to publishers to test in production with production-quality services and production MSA developer accounts.</span></span> <span data-ttu-id="75f12-307">機能と柔軟性の向上に伴い、開発中および一般提供後、タイトル データを作成したり、タイトルへのアクセスを管理したりするための新しい構成手順が XDP で必要になっています。</span><span class="sxs-lookup"><span data-stu-id="75f12-307">The increase in functionality and flexibility requires new configuration steps in XDP to create title data and manage access to the titles while in development and in general availability.</span></span>

<span data-ttu-id="75f12-308">サンドボックスは実稼働環境のデータをパーティション分割するための手段です。</span><span class="sxs-lookup"><span data-stu-id="75f12-308">Sandboxes are a way to partition data in production.</span></span> <span data-ttu-id="75f12-309">すべてのコンテンツ向けの単一の実稼働環境が存在するので、サンドボックスは、ある環境で生成されたデータが他の環境に移動しない "仮想環境" として機能します。</span><span class="sxs-lookup"><span data-stu-id="75f12-309">Because there is a single production environment for all content, sandboxes act as “virtual environments” where data generated in one environment does not cross over to the other.</span></span>
