---
title: 高度な Xbox Live のサンドボックス
author: KevinAsgari
description: 対象パートナーによる開発中に、サンドボックスを使用してコンテンツを分離する方法について説明します。
ms.assetid: bd8a2c51-2434-4cfe-8601-76b08321a658
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Xbox One, XDK, 対象パートナー, サンドボックス, コンテンツの分離
ms.localizationpriority: medium
ms.openlocfilehash: 02817869aeba78ad1b86e12d4bbd31a1107d3195
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4685047"
---
# <a name="advanced-xbox-live-sandboxes"></a><span data-ttu-id="4dce5-104">高度な Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="4dce5-104">Advanced Xbox Live sandboxes</span></span>

> <span data-ttu-id="4dce5-105">**注** この記事では、サンドボックスの高度な使用について説明します。この記事は主に、複数のチームが参加していて、アクセス許可の要件が複雑な大規模ゲーム スタジオに適用されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-105">**Note** This article explain advanced usage of sandboxes and is mainly applicable to large gaming studios which have multiple teams and complex permissions requirements.</span></span>  <span data-ttu-id="4dce5-106">Xbox Live クリエーターズ プログラムに参加している場合、または ID@Xbox 開発者である場合は、「[Xbox Live のサンドボックスの概要](xbox-live-sandboxes.md)」をお読みになることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4dce5-106">If you are part of the Xbox Live Creators Program or an ID@Xbox developer, it is recommended to look at the [Xbox Live Sandboxes Intro](xbox-live-sandboxes.md)</span></span>

<span data-ttu-id="4dce5-107">Xbox Live の*サンドボックス*は、開発用の完全に非公開な環境を提供します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-107">The Xbox Live *sandbox* provides an entire private environment for development.</span></span> <span data-ttu-id="4dce5-108">このドキュメントでは、サンドボックスとは何か、サンドボックスが存在する理由、サンドボックスが公開元に適用されるしくみ、および、サンドボックスが内部の Xbox チームにどのような影響を及ぼすかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-108">This document explains what sandboxes are, why they exist, how they apply to publishers, and how they impact internal Xbox teams.</span></span> <span data-ttu-id="4dce5-109">このドキュメントの対象読者は、Xbox One コンテンツを構築したり、サンドボックスを利用したりする公開元です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-109">The audience for this document is publishers who build Xbox One content and use sandboxes.</span></span>

## <a name="summary"></a><span data-ttu-id="4dce5-110">概要</span><span class="sxs-lookup"><span data-stu-id="4dce5-110">Summary</span></span>

<span data-ttu-id="4dce5-111">Xbox Live では、単一の運用環境のみが存在し、プレリリース版 (開発中の製品とベータ版)、認定、および製品版に関するコンテンツがすべてその環境に存在します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-111">In Xbox Live, there is only a single production environment where all prerelease (in-development and beta), certification, and retail content resides.</span></span>

<span data-ttu-id="4dce5-112">コンテンツの分離は、運用環境で公開元のコンテンツの漏洩がないことを保証するための手段です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-112">Content isolation is the way to ensure that there are no publisher content leaks in production.</span></span> <span data-ttu-id="4dce5-113">その中心的な機能として、コンテンツの分離は、リソース (タイトルまたはサービス) にアクセスするための権限を要求するプリンシパル ユーザー、デバイス、またはタイトルが、リソースへのアクセスを承認されていることを保証します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-113">At its core, content isolation ensures that any principal user, device, or title that requests permission to access a resource (a title or a service) has been authorized to access the resource.</span></span> <span data-ttu-id="4dce5-114">コンテンツの分離により、パーティションはサンドボックスに分割され、タイトルまたはサービスのデータはサンドボックスに格納されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-114">With content isolation, partitions are divided into sandboxes where title or service data is stored.</span></span> <span data-ttu-id="4dce5-115">言い換えれば、承認ポリシーはサンドボックスの範囲内で定義されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-115">Said differently, authorization policies are defined within the scope of a sandbox.</span></span>

<span data-ttu-id="4dce5-116">サンドボックスは、運用環境内のデータをパーティション分割するための方法です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-116">Sandboxes are a way to partition data that is in production.</span></span> <span data-ttu-id="4dce5-117">Xbox 360 の ERA サービスでは、PartnerNet と ProductionNet は 2 つの異なる環境です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-117">With Xbox 360 era services, PartnerNet and ProductionNet are two distinct environments.</span></span> <span data-ttu-id="4dce5-118">Xbox One の era サービスでは、単一の運用環境には、 *n*の異なる仮想環境がそれぞれの仮想環境がサンド ボックスと呼ばれる場所が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-118">With Xbox One era services, a single production environment contains *n* distinct virtual environments where each virtual environment is called a sandbox.</span></span> <span data-ttu-id="4dce5-119">すべてのコンテンツを対象とした単一の運用環境が存在するので、サンドボックスは実際には、ある環境で生成されたデータが別の環境に移動できない一意の仮想環境です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-119">Because there is a single production environment for all content, sandboxes are actually unique virtual environments where data generated in one environment cannot cross over to another.</span></span>

<span data-ttu-id="4dce5-120">次の図は単一の運用環境を示しています。公開元は、この環境内に自社用の非公開の開発サンドボックスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-120">The following figure shows a single production environment in which publishers can create their private development sandboxes.</span></span> <span data-ttu-id="4dce5-121">承認された開発者アカウントまたは開発キットのみが、これらのサンドボックスへのアクセスを許可されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-121">Only authorized dev accounts or dev kits are permitted access to these sandboxes.</span></span>

<span data-ttu-id="4dce5-122">図 1.</span><span class="sxs-lookup"><span data-stu-id="4dce5-122">Figure 1.</span></span> <span data-ttu-id="4dce5-123">運用環境内のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="4dce5-123">Sandboxes in a production environment.</span></span>

![](images/sandboxes/sandboxes_image1.png)

<span data-ttu-id="4dce5-124">PublisherA が自社用の開発サンドボックスを持っているのと同じように、他の公開元も自社専用の開発サンドボックスを持っています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-124">Just as PublisherA has her development sandboxes, other publishers have their own development sandboxes.</span></span> <span data-ttu-id="4dce5-125">同じタイトル ID が複数の異なるサンドボックスに存在することもできますが、そのタイトル ID に対して生成されるデータは、サンドボックス間では別個のデータとなります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-125">The same title ID may reside in different sandboxes but the data generated for the title ID is distinct across sandboxes.</span></span>

<span data-ttu-id="4dce5-126">CERT と RETAIL の 2 つのシステム サンドボックスは Microsoft のみが設定できます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-126">There are two system sandboxes that can only be populated by Microsoft: CERT and RETAIL.</span></span> <span data-ttu-id="4dce5-127">名前が示すように、CERT サンドボックスはリリース前の認定を受けているタイトル用のサンドボックスであり、RETAIL サンドボックスはすべての製品ユーザーおよび製品デバイスがアクセスできる実際の製品を表しているサンドボックスです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-127">As the names suggest, the CERT sandbox is for titles that are undergoing certification prior to release, while the RETAIL sandbox is the sandbox representing real dollars that is accessible by all retail users and devices.</span></span>

<span data-ttu-id="4dce5-128">タイトル ID は従来、Xbox Live 内で一意でしたが、現在ではタイトル ID にサンドボックス ID を加えたものが一意な ID となります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-128">Whereas a title ID was formerly unique in Xbox Live, now a title ID plus a sandbox ID is unique.</span></span> <span data-ttu-id="4dce5-129">以前は一意の ID として扱われていた製品 ID やその他の ID 空間にも、同じことが当てはまります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-129">The same applies to product IDs and other ID spaces that were once treated as unique.</span></span> <span data-ttu-id="4dce5-130">これらはサンドボックス ID とペアにすることが必要になりました。</span><span class="sxs-lookup"><span data-stu-id="4dce5-130">They must now be paired with a sandbox ID.</span></span> <span data-ttu-id="4dce5-131">Xbox Live のすべてのデータは主に、システム全体を通じてサンドボックス ID によってパーティション分割されることになります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-131">All data in Xbox Live will be primarily partitioned by the sandbox ID throughout the system.</span></span>

## <a name="initial-setup-for-a-title"></a><span data-ttu-id="4dce5-132">タイトル用の初期セットアップ</span><span class="sxs-lookup"><span data-stu-id="4dce5-132">Initial setup for a title</span></span>

<span data-ttu-id="4dce5-133">タイトルは Xbox デベロッパー ポータル (XDP) または Windows デベロッパー センターで作成されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-133">A title is born in the Xbox Developer Portal (XDP) or Windows Dev Center.</span></span> <span data-ttu-id="4dce5-134">このドキュメントでは、XDP で作成されますタイトルについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-134">This document covers titles born in XDP.</span></span> <span data-ttu-id="4dce5-135">タイトルには、タイトル ID、製品 ID とサービス構成 ID (SCID) が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-135">Titles are assigned a title ID, product ID and a service configuration ID (SCID).</span></span>

<span data-ttu-id="4dce5-136">タイトルを新たに作成しても、タイトルや製品だけでは Xbox Live にとって何の意味もありません。</span><span class="sxs-lookup"><span data-stu-id="4dce5-136">In this new world, a title or product on its own doesn’t mean anything to Xbox Live.</span></span> <span data-ttu-id="4dce5-137">1 つのタイトルを、製品版や開発用に同時に使用できるようにする必要があります。そのため、タイトルの*インスタンス化*をサポートして、タイトルを必要に応じて区別し、これを維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-137">Because we must support simultaneous retail and development use of a single title, we must support *instancing* of titles in order to make and maintain the necessary distinctions.</span></span> <span data-ttu-id="4dce5-138">タイトルのインスタンスはサンドボックスに存在します。これがサンドボックスの役割です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-138">An instance of a title resides in a sandbox and this is where sandboxes come in.</span></span>

<span data-ttu-id="4dce5-139">XDP でタイトルを作成するためには、発行元は製品グループを作成、製品グループのジャンルを指定し、内の個々 の製品を作成します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-139">In order to create a title on XDP, a publisher creates a product group, specifies the genre for the product group, and then creates individual products within it.</span></span> <span data-ttu-id="4dce5-140">(詳しくは、XDP ドキュメントをご覧ください)。次の図は、製品グループ、製品、製品インスタンス、およびサンドボックス間の関係を示しています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-140">(For more details, refer to the XDP documentation.) The following diagram illustrates the relationships between a product group, a product, a product instance, and a sandbox.</span></span>

<span data-ttu-id="4dce5-141">図 2.</span><span class="sxs-lookup"><span data-stu-id="4dce5-141">Figure 2.</span></span> <span data-ttu-id="4dce5-142">製品グループ、製品、製品インスタンス、およびサンドボックス間の関係</span><span class="sxs-lookup"><span data-stu-id="4dce5-142">The relationships between a product group, a product, a product instance, and a sandbox.</span></span>

![](images/sandboxes/sandboxes_image2.png)

<a name="product-instances"></a><span data-ttu-id="4dce5-143">製品インスタンス</span><span class="sxs-lookup"><span data-stu-id="4dce5-143">Product instances</span></span>
-----------------

<span data-ttu-id="4dce5-144">*製品インスタンス*は、特定のサンドボックス内のタイトル、製品、および構成データを投影したものです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-144">A *product instance* is a projection of title, product, and configuration data in a specific sandbox.</span></span> <span data-ttu-id="4dce5-145">このデータについて、サービス構成、カタログ メタデータ、およびバイナリの 3 つの領域に分けて説明します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-145">This data is described in the following three areas: service configuration, catalog metadata, and binaries.</span></span>

### <a name="service-configuration"></a><span data-ttu-id="4dce5-146">サービス構成</span><span class="sxs-lookup"><span data-stu-id="4dce5-146">Service configuration</span></span>

> <span data-ttu-id="4dce5-147">サービス構成の定義 (イベント、統計、実績など)。</span><span class="sxs-lookup"><span data-stu-id="4dce5-147">Service configuration definitions (events, stats, achievements, etc.).</span></span> <span data-ttu-id="4dce5-148">サービス構成は製品インスタンスのレベルで定義されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-148">The service configuration is defined at the product instance level.</span></span>

### <a name="catalog-metadata"></a><span data-ttu-id="4dce5-149">カタログ メタデータ</span><span class="sxs-lookup"><span data-stu-id="4dce5-149">Catalog metadata</span></span>

> <span data-ttu-id="4dce5-150">カタログに含まれるメタデータであり、販促テキスト、アート アセット、可用性や提供に関する情報、ライセンス データなどが含まれます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-150">The metadata which lives in the Catalog, including sell text, art assets, availability/offer information, licensing data, and more.</span></span>

### <a name="binary"></a><span data-ttu-id="4dce5-151">バイナリ</span><span class="sxs-lookup"><span data-stu-id="4dce5-151">Binary</span></span>

> <span data-ttu-id="4dce5-152">バイナリは次の 2 つの形態のいずれかで表すことができます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-152">A binary can be represented in either of two ways:</span></span>

1.  <span data-ttu-id="4dce5-153">メタデータのみ。サイドローディングを可能にします。</span><span class="sxs-lookup"><span data-stu-id="4dce5-153">Metadata only to enable sideloading.</span></span> <span data-ttu-id="4dce5-154">これにはコンテンツ ID、バージョン情報、およびライセンス情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-154">This includes content ID, version info, and licensing info.</span></span>

2.  <span data-ttu-id="4dce5-155">CDN に伝達されてクライアントがダウンロードできるようになる完全なバイナリ。</span><span class="sxs-lookup"><span data-stu-id="4dce5-155">Full binary propagated to a CDN and downloadable to a client.</span></span>

<a name="getting-the-access-right"></a><span data-ttu-id="4dce5-156">アクセス権の取得</span><span class="sxs-lookup"><span data-stu-id="4dce5-156">Getting the access right</span></span>
------------------------

<span data-ttu-id="4dce5-157">Xbox One でのコンテンツへのアクセスには、以下の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-157">There are two distinct types of access to your content in Xbox One:</span></span>

<span data-ttu-id="4dce5-158">*設計時アクセス* - PC からの XDP ツールを介したアクセスであり、製品に携わる要員がコンテンツ、構成、メタデータをアップロード、整理、および操作することを許可しますが、製品のインスタンスを実行またはプレイすることは許可しません。</span><span class="sxs-lookup"><span data-stu-id="4dce5-158">*Design-time access*—access from a PC via the XDP tool—allows people working on your products to upload, organize, and work with content, configuration, and metadata, but does not allow them to run or play instances of your products.</span></span>

<span data-ttu-id="4dce5-159">*実行時アクセス* - Xbox 本体からのアクセスであり、開発者、テスト担当者、レビュー担当者、そして最終的にはユーザーが製品インスタンスを実行および再生することを許可します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-159">*Run-time access*—access from an Xbox console—allows your developers, testers, reviewers, and eventually your customers to run and play product instances.</span></span>

<span data-ttu-id="4dce5-160">**注** 実行時アクセスが可能となるためには、製品インスタンスがサンドボックスに配置されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-160">**Note** In order to be available for run-time access, a product instance must be placed in a sandbox.</span></span> <span data-ttu-id="4dce5-161">ビルドがサンドボックスに配置されると、そのサンドボックスへのアクセスを許可されている XDP ユーザーや開発キット デバイスは、インスタンスを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-161">Once a build is placed in a sandbox, XDP users or devkit devices that have been granted access to that sandbox can run the instance.</span></span> <span data-ttu-id="4dce5-162">実行するために、これらのユーザーやデバイスは、各自の開発者アカウント (実行時アクセスのための仮想ユーザーとして機能する特別なアカウント) の 1 つを使用して Xbox 本体から Xbox One にログオンします。</span><span class="sxs-lookup"><span data-stu-id="4dce5-162">To do this, they log on to Xbox One via an Xbox console, using one of their dev accounts—special accounts that function as virtual users for run-time access.</span></span>

<span data-ttu-id="4dce5-163">サンドボックスについて説明するとき、通常は、Xbox Live 上で実行されるコンテンツへの実行時アクセスに関する説明をしています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-163">When we are talking about sandboxes, we are typically talking about run-time access to content that runs on Xbox Live.</span></span> <span data-ttu-id="4dce5-164">Xbox Live 内のサービスにアクセスするためには、タイトル ID が必要です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-164">In order to access a service in Xbox Live, a title ID is required.</span></span> <span data-ttu-id="4dce5-165">**appxmanifest** にタイトル ID が入力されると、本体はタイトル ID を Xbox Live に送信します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-165">Once an **appxmanifest** contains a title ID, the console will send the title ID to Xbox Live.</span></span> <span data-ttu-id="4dce5-166">プリンシパル (デバイスまたはユーザー) がタイトルへのアクセスを許可されていない場合、Xbox Live セキュリティ サービスは有効なトークンを返しません。</span><span class="sxs-lookup"><span data-stu-id="4dce5-166">Xbox Live security services will not provide back a valid token unless the principal (device or user) has been given access to the title.</span></span>

<span data-ttu-id="4dce5-167">この検証プロセスは、コンテンツ分離の最も重要な機能です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-167">This validation process is the crux of content isolation.</span></span> <span data-ttu-id="4dce5-168">このプロセスの概要を次に説明します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-168">When seen at a very high level:</span></span>

-   <span data-ttu-id="4dce5-169">プリンシパル グループには、Xbox ユーザー ID (XUID)、デバイス ID、タイトル ID、またはサービス ID を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-169">A principal group can contain Xbox User IDs (XUIDs), device IDs, title IDs or service IDs.</span></span>

-   <span data-ttu-id="4dce5-170">サンドボックスには、タイトル ID、製品 ID、またはサービス構成 ID (SCID) を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-170">A sandbox can contain title IDs, product IDs or service config IDs (SCIDs).</span></span>

-   <span data-ttu-id="4dce5-171">プリンシパル グループにはサンドボックスへのアクセス権が与えられます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-171">A principal group is given access to a sandbox.</span></span>

<span data-ttu-id="4dce5-172">したがって、ユーザーやデバイスがサンドボックス内のプレリリース タイトルにアクセスするには、まず XDP を通じてアクセス権が与えられる必要があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-172">So, for a user or device to access a pre-release title in a sandbox, access must be granted through XDP first.</span></span>

<span data-ttu-id="4dce5-173">図 3.</span><span class="sxs-lookup"><span data-stu-id="4dce5-173">Figure 3.</span></span> <span data-ttu-id="4dce5-174">XDP を通じてアクセスをセットアップする場合のモデル</span><span class="sxs-lookup"><span data-stu-id="4dce5-174">A model for setting up access through XDP.</span></span>

![](images/sandboxes/sandboxes_image3.png)

<span data-ttu-id="4dce5-175">コンテンツの分離は、組織で以下のプロセスが実施されている場合に効果があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-175">The effectiveness of content isolation is based on the fact that your organization owns the following processes:</span></span>

-   <span data-ttu-id="4dce5-176">XDP ユーザー アカウント、各ユーザーが実行時アクセスのためのログオンに使用する開発者アカウント、およびユーザー グループを作成している (ユーザー グループ内で各ユーザーはメンバーシップを付与されます)。</span><span class="sxs-lookup"><span data-stu-id="4dce5-176">Creating your XDP user accounts, the dev accounts that each user will use to log on for run-time access, and the user groups in which each user is granted membership.</span></span>

-   <span data-ttu-id="4dce5-177">信頼された本体のデバイス グループを作成している。</span><span class="sxs-lookup"><span data-stu-id="4dce5-177">Creating device groups of trusted consoles.</span></span>

-   <span data-ttu-id="4dce5-178">どのユーザー グループおよびデバイス グループがサンドボックス内の製品インスタンスにアクセスできるかを、開発サンドボックスごとに正確に指定している。</span><span class="sxs-lookup"><span data-stu-id="4dce5-178">Specifying for each of your development sandboxes precisely which user groups and device groups have access to the product instances in it.</span></span>

<span data-ttu-id="4dce5-179">このセットアップに関する例を、次の図で示します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-179">An example of this setup is illustrated in the figure below.</span></span>

<span data-ttu-id="4dce5-180">図 4.</span><span class="sxs-lookup"><span data-stu-id="4dce5-180">Figure 4.</span></span> <span data-ttu-id="4dce5-181">承認されていないユーザーの資格情報ではサンドボックスへのアクセスに失敗します。承認された XDP ユーザー アカウントの通常の資格情報でも同様です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-181">An unauthorized user's credentials fail to gain access to the sandbox, as do the ordinary credentials of an authorized XDP user account.</span></span> <span data-ttu-id="4dce5-182">承認された XDP ユーザー アカウントによって所有される開発者アカウントの資格情報のみが、サンドボックスと、現在そのサンドボックス内にあるすべての製品インスタンスへの実行時アクセスに成功します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-182">Only the credentials of the dev account owned by the authorized XDP user account succeed in gaining run-time access to the sandbox, and to all of the product instances currently in it.</span></span>

![](images/sandboxes/sandboxes_image4.png)

### <a name="dev-accounts-setup"></a><span data-ttu-id="4dce5-183">開発者アカウントのセットアップ</span><span class="sxs-lookup"><span data-stu-id="4dce5-183">Dev accounts setup</span></span>

<span data-ttu-id="4dce5-184">Xbox One の開発者アカウントは、特別なルールが適用された標準の Microsoft アカウント (MSA) であり、</span><span class="sxs-lookup"><span data-stu-id="4dce5-184">Dev accounts in Xbox One are just standard Microsoft accounts (MSA) with special rules applied to them.</span></span> <span data-ttu-id="4dce5-185">開発のために Xbox Live で使用されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-185">They are used in Xbox Live for development.</span></span> <span data-ttu-id="4dce5-186">開発者アカウントについて次に説明します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-186">A dev account:</span></span>

-   <span data-ttu-id="4dce5-187">XDP または Windows デベロッパー センターで作成される必要があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-187">Must be created from XDP or Windows Dev Center.</span></span>

-   <span data-ttu-id="4dce5-188">公開元によって作成されるときに、外部開発者のロールが割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-188">Is assigned the external developer role when created by publishers.</span></span>

-   <span data-ttu-id="4dce5-189">開発者アカウントを作成した XDP アカウントや Windows デベロッパー センター アカウントと関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-189">Is tied to the XDP account or Windows Dev Center account that created the dev account.</span></span>

-   <span data-ttu-id="4dce5-190">開発キットのみにログインできます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-190">Can only log in to dev kits.</span></span> <span data-ttu-id="4dce5-191">製品デバイス上では開発者アカウントへのログインは拒否されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-191">Login is denied to a dev account on retail devices.</span></span>

-   <span data-ttu-id="4dce5-192">テストを目的とした場合は、Xbox Live 開発者向けのゴールド サブスクリプションまたは他のサブスクリプションを無料で購入できます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-192">Can purchase Xbox Live Developer Gold subscription or other subscriptions for free in order to test.</span></span>

### <a name="user-group-setup"></a><span data-ttu-id="4dce5-193">ユーザー グループのセットアップ</span><span class="sxs-lookup"><span data-stu-id="4dce5-193">User group setup</span></span>

<span data-ttu-id="4dce5-194">第 1 の種類のプリンシパル グループであるユーザー グループは XDP ユーザーのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-194">A user group, the first kind of principal group, is a collection of XDP users.</span></span> <span data-ttu-id="4dce5-195">XDP ユーザーがユーザー グループに追加されると、そのグループの開発者アカウントが、これらの XDP ユーザーに適用されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-195">When XDP users are added to user groups, their dev accounts flow with these XDP users.</span></span>

<span data-ttu-id="4dce5-196">したがって、ユーザー グループがサンドボックスに割り当てられるとき、そのユーザー グループ内の XDP ユーザーに関連付けられた開発者アカウントが適切なプリンシパル グループに追加され、プリンシパル グループは、サンドボックスの背景にあるプライマリー リソース セットによってポリシーをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="4dce5-196">So when a user group is assigned to a sandbox, the dev accounts associated with the XDP users in that user group get added to appropriate principal groups and the principal groups get a policy setup with the primary resource set backing the sandbox.</span></span>

<span data-ttu-id="4dce5-197">**注** サンドボックスにアクセスするために作成されるユーザー グループは、XDP 内にある製品グループや製品の構成データへのアクセスを防ぐために使用されるものと同じユーザー グループです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-197">**Note** The user groups that are created to access sandboxes are the same user groups that are used to prevent access to configuration data in XDP for product groups and products.</span></span>

### <a name="device-setup"></a><span data-ttu-id="4dce5-198">デバイスのセットアップ</span><span class="sxs-lookup"><span data-stu-id="4dce5-198">Device setup</span></span>

<span data-ttu-id="4dce5-199">デバイスもプリンシパル グループに追加されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-199">A device also gets added to a principal group.</span></span> <span data-ttu-id="4dce5-200">Game Developer Store を通じて資格を購入し、デバイスを開発キットとしてプロビジョニングする場合、デバイスは開発キットとしてのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-200">A device can only be used as a dev kit if an entitlement is purchased through the Game Developer Store and the device is provisioned to be a dev kit.</span></span> <span data-ttu-id="4dce5-201">デバイスが開発キットとしてプロビジョニングされると、デバイス グループに追加できるデバイスの一覧にそのデバイスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-201">Once a device is provisioned as a dev kit, the device shows up in the list of devices that can be added to device groups.</span></span>

### <a name="device-group-setup"></a><span data-ttu-id="4dce5-202">デバイス グループのセットアップ</span><span class="sxs-lookup"><span data-stu-id="4dce5-202">Device group setup</span></span>

<span data-ttu-id="4dce5-203">第 2 の種類のプリンシパル グループであるデバイス グループにもサンドボックスへのアクセス権を付与できます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-203">A device group, the second kind of principal group, can also be given access to sandboxes.</span></span> <span data-ttu-id="4dce5-204">セットアップは、前に詳しく説明したユーザー グループのセットアップと同様です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-204">The setup is similar to the user group setup detailed above.</span></span>

## <a name="sandboxes"></a><span data-ttu-id="4dce5-205">サンドボックス</span><span class="sxs-lookup"><span data-stu-id="4dce5-205">Sandboxes</span></span>

<a name="what-is-a-sandbox"></a><span data-ttu-id="4dce5-206">サンドボックスとは</span><span class="sxs-lookup"><span data-stu-id="4dce5-206">What is a sandbox?</span></span>
------------------

<span data-ttu-id="4dce5-207">簡潔に言えば、*サンドボックスは運用環境のデータをパーティション分割するための方法です*。</span><span class="sxs-lookup"><span data-stu-id="4dce5-207">Stated simply, *a sandbox is a way to partition data in production*.</span></span>

<a name="why-do-we-need-sandboxes"></a><span data-ttu-id="4dce5-208">サンドボックスが必要な理由</span><span class="sxs-lookup"><span data-stu-id="4dce5-208">Why do we need sandboxes?</span></span>
-------------------------

<span data-ttu-id="4dce5-209">ユーザーやデバイスがタイトルにアクセスするのと同じように、タイトルはサービスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="4dce5-209">Just as users and devices access titles, titles access services.</span></span> <span data-ttu-id="4dce5-210">一連のタイトルに対してサービス リソースへのアクセスを許可するために、"タイトル グループ" という概念が採用されました。</span><span class="sxs-lookup"><span data-stu-id="4dce5-210">We introduce a concept of “title group” where sets of titles are granted access to service resources.</span></span>

<span data-ttu-id="4dce5-211">Xbox One では、すべてのコンテンツ (プレリリース版および製品版) を対象とした運用環境は 1 つしか存在しないため、リソースの同じインスタンス上で、1 つのタイトルに関する複数のインスタンス (プレリリース版/製品版) を稼働させることは避ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-211">Because there is a single production environment for Xbox One for all content (pre-release and retail), multiple instances (pre-release/retail) of a title must be prevented from operating on the same instances of resources.</span></span>

<a name="what-is-in-a-sandbox"></a><span data-ttu-id="4dce5-212">サンドボックスの内容</span><span class="sxs-lookup"><span data-stu-id="4dce5-212">What is in a sandbox?</span></span>
---------------------

<span data-ttu-id="4dce5-213">サンドボックスには、サンドボックスに追加されるすべてのタイトルの製品インスタンスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-213">A sandbox contains a product instance for every title that gets added to the sandbox.</span></span>

<a name="what-is-a-sandbox-id"></a><span data-ttu-id="4dce5-214">サンドボックス ID とは</span><span class="sxs-lookup"><span data-stu-id="4dce5-214">What is a sandbox ID?</span></span>
---------------------

<span data-ttu-id="4dce5-215">サンドボックス ID は、タイトル、製品、サービス構成に関するデータのパーティション分割単位を表します。複数のタイトルが同じサンドボックス内に共存することができます。これは、それらのタイトルがサービス構成データを共有するための前提条件となります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-215">A sandbox ID is a partitioning unit of data for a title, product, or service config. Multiple titles can exist in the same sandbox, which is a prerequisite for them to share any service config data.</span></span>

<span data-ttu-id="4dce5-216">(大文字と小文字が区別) サンド ボックス ID は、次の形式で文字列: &lt;PublisherMoniker&gt;します。*n*します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-216">A sandbox ID (case sensitive) is a string in the following format: &lt;PublisherMoniker&gt;.*n*.</span></span> <span data-ttu-id="4dce5-217">XLDP.5 というサンドボックス ID の例について、次に説明します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-217">An example sandbox ID, XLDP.5, is explained below:</span></span>

-   <span data-ttu-id="4dce5-218">*パブリッシャー モニカー*はすべての公開元の間で一意です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-218">The *publisher moniker* is unique across all publishers.</span></span> <span data-ttu-id="4dce5-219">したがって、"XLPD" はこの特定の公開元のパブリッシャー モニカーとなります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-219">So, “XLPD” is the publisher moniker for this particular publisher.</span></span> <span data-ttu-id="4dce5-220">パブリッシャー モニカーは、開発者アカウント情報マネージャーによって公開元が XDP 内で "アクティブ化" されるときに作成されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-220">A publisher moniker is created when a publisher is “activated” in XDP by the developer account manager.</span></span>

-   <span data-ttu-id="4dce5-221">数字 "*n*" はサンドボックスの数を示します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-221">The digit *“n”* identifies the number of the sandbox.</span></span> <span data-ttu-id="4dce5-222">この場合、"5" はこの公開元用に作成される 6 番目のサンドボックスです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-222">In this case, “5” is the sixth sandbox created for this publisher.</span></span>

<span data-ttu-id="4dce5-223">タイトルのデータがサービスを介して移行されるとき、Xbox サービスはサンドボックス ID を使用して、生成されるデータの "環境" を一意に識別します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-223">When the title data moves through services, Xbox services use the sandbox ID to uniquely identify the “environment” for the data that is generated.</span></span>

<a name="what-data-is-sandboxed"></a><span data-ttu-id="4dce5-224">どのようなデータがサンドボックス化されるか</span><span class="sxs-lookup"><span data-stu-id="4dce5-224">What data is sandboxed?</span></span>
-----------------------

<span data-ttu-id="4dce5-225">次の図では、どのようなユーザー データやタイトル データがサンドボックス化されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-225">The diagram below shows what user and title data is sandboxed.</span></span>

![](images/sandboxes/sandboxes_image5.png)

<a name="global-override-sandbox"></a><span data-ttu-id="4dce5-226">グローバル オーバーライド サンドボックス</span><span class="sxs-lookup"><span data-stu-id="4dce5-226">Global override sandbox</span></span>
-----------------------

<span data-ttu-id="4dce5-227">開発者は、開発キット上でサンドボックス ID を設定することによって、開発キットが動作するサンドボックスを設定します。これはグローバル オーバーライド サンドボックスとも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-227">A developer sets the sandbox ID on her dev kit and thus sets the sandbox that the dev kit runs in; this is also known as the global override sandbox.</span></span> <span data-ttu-id="4dce5-228">したがって、開発キットで Xbox Live サービス (実績、マッチメイキング、ライセンス、EDS など) に対してタイトル (シェル アプリおよび通常のアプリ) から実行されるすべての要求はそのサンドボックスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-228">Thus, all requests made to Xbox Live services (for example, achievements, matchmaking, licensing, EDS, etc.) from the titles (shell apps and regular apps) in the dev kit are made in that sandbox.</span></span>

<span data-ttu-id="4dce5-229">グローバル オーバーライド サンドボックスでは、このサンドボックスに取り込まれたコンテンツのみが参照時に表示されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-229">The global override sandbox also implies that only the content ingested in the global override sandbox is visible when being browsed.</span></span>

<a name="types-of-sandboxes"></a><span data-ttu-id="4dce5-230">サンドボックスの種類</span><span class="sxs-lookup"><span data-stu-id="4dce5-230">Types of sandboxes</span></span>
-------------------------------------------------------------------------------------------------------------------------------------------------------

<span data-ttu-id="4dce5-231">サンドボックスには 2 つの異なるカテゴリーがあります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-231">There are two different categories of sandboxes.</span></span> <span data-ttu-id="4dce5-232">これらのカテゴリーは以下のように定義されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-232">These categories are defined as follows:</span></span>

-   <span data-ttu-id="4dce5-233">*パブリッシャー サンドボックス*。</span><span class="sxs-lookup"><span data-stu-id="4dce5-233">*Publisher sandboxes*.</span></span> <span data-ttu-id="4dce5-234">公開元はそれぞれの開発中サンドボックスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-234">Publishers have access to their in-development sandboxes.</span></span> <span data-ttu-id="4dce5-235">これらのサンドボックスは、XLDP.0、XLDP.1、XLDP.2、XLDP.3 のような名前になります。これは、公開元が自社タイトルの製品インスタンスを配置する場所です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-235">These may look like XLDP.0, XLDP.1, XLDP.2, XLDP.3, etc. This is where publishers would put their title product instances.</span></span> <span data-ttu-id="4dce5-236">これらのサンドボックスへのアクセスは、公開元がアクセスを許可するユーザー/デバイスに限定されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-236">Access to these sandboxes is gated to the users/devices that the publishers grants access to</span></span>

-   <span data-ttu-id="4dce5-237">*Microsoft サンドボックス*。</span><span class="sxs-lookup"><span data-stu-id="4dce5-237">*Microsoft sandboxes*.</span></span> <span data-ttu-id="4dce5-238">これらは組み込みのサンドボックスである RETAIL および CERT です。Microsoft のみが、これらの保護されたサンドボックスに公開することを許可されています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-238">These are the built-in sandboxes: RETAIL and CERT Only Microsoft is allowed to publish to these protected sandboxes.</span></span>

<a name="cert-sandbox"></a><span data-ttu-id="4dce5-239">CERT サンドボックス</span><span class="sxs-lookup"><span data-stu-id="4dce5-239">CERT sandbox</span></span>
------------

<span data-ttu-id="4dce5-240">一般提供の準備ができたタイトルは、まず認定に合格する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-240">When a title is ready for general availability, it needs to go through certification first.</span></span> <span data-ttu-id="4dce5-241">CERT サンドボックスは Microsoft が管理するサンドボックスであり、認定の担当者のみがアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-241">The CERT sandbox is a Microsoft-controlled sandbox that only individuals in certification have access to.</span></span> <span data-ttu-id="4dce5-242">公開元は、自社が保有するどのコンテンツが認定に合格しているかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-242">Publishers can see what content they own is going through certification.</span></span>

<span data-ttu-id="4dce5-243">認定で不合格となった製品インスタンスは、デバッグと修正、公開元が XDP または Windows デベロッパー センターを使用して、開発サンド ボックスに戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-243">Any product instances that fail while in certification can be brought back to a development sandbox to be debugged and fixed by the publishers using XDP or Windows Dev Center.</span></span>

<a name="retail-sandbox"></a><span data-ttu-id="4dce5-244">RETAIL サンドボックス</span><span class="sxs-lookup"><span data-stu-id="4dce5-244">RETAIL sandbox</span></span>
--------------

<span data-ttu-id="4dce5-245">RETAIL サンドボックスは、Xbox One 向けに作成されるすべてのコンテンツの最終目的地です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-245">The RETAIL sandbox is the final destination for all content that is created for Xbox One.</span></span>

<span data-ttu-id="4dce5-246">認定に合格した後、タイトルは RETAIL サンドボックスに追加されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-246">After a title passes certification, it is added to the RETAIL sandbox.</span></span> <span data-ttu-id="4dce5-247">署名済みコンテンツのみが RETAIL サンドボックスでの実行を許可されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-247">Only green signed content is permitted to run in the RETAIL sandbox.</span></span> <span data-ttu-id="4dce5-248">これには、発行元が運用できるベータ版も RETAIL サンドボックスで実行されるという重要な意味があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-248">This has an important implication that publisher-driven betas are also done in the RETAIL sandbox.</span></span> <span data-ttu-id="4dce5-249">RETAIL サンドボックスで生成されるデータは、実際の顧客の運用データを表します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-249">Data generated in the RETAIL sandbox represents real customer production data.</span></span>

<span data-ttu-id="4dce5-250">RETAIL サンドボックス内のコンテンツへのアクセスは、引き続き、コンテンツの分離を通じて制御可能であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4dce5-250">Note that access to content is the RETAIL sandbox is still controllable through content isolation.</span></span>

<span data-ttu-id="4dce5-251">たとえば、発行元が運用できるベータ版は RETAIL サンドボックスで実行され、この場合、発行元が定義するベータ リソース セットのタイトルにどのプリンシパル グループがアクセスできるかを、発行元が選択します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-251">For example, publisher-driven betas are run in the RETAIL sandbox, where the publisher chooses which principal groups get to access publisher-defined beta resource set titles.</span></span> <span data-ttu-id="4dce5-252">ベータ タイトルによって生成されるサービス データは実際の運用データであり、タイトルが一般提供に移行した後も保持されます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-252">The service data generated by the beta titles is real prod data and continues to exist once the title goes to general availability.</span></span>

<a name="cross-sandbox-data-interaction"></a><span data-ttu-id="4dce5-253">サンドボックス間のデータのやり取り</span><span class="sxs-lookup"><span data-stu-id="4dce5-253">Cross-sandbox data interaction</span></span>
------------------------------

<span data-ttu-id="4dce5-254">定義によれば、サンドボックスはデータの共有を制限するコンテナーです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-254">By definition, a sandbox is a container that restricts data sharing.</span></span> <span data-ttu-id="4dce5-255">したがって、サンドボックス間のデータのやり取りは不可能です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-255">Thus, cross-sandbox data interaction is not possible.</span></span>

## <a name="organizing-your-sandboxes"></a><span data-ttu-id="4dce5-256">サンドボックスの整理</span><span class="sxs-lookup"><span data-stu-id="4dce5-256">Organizing your sandboxes</span></span>

<span data-ttu-id="4dce5-257">このセクションでは、公開元が実行できるサンドボックスの整理方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-257">This section provides an example of how a publisher can organize sandboxes.</span></span> <span data-ttu-id="4dce5-258">公開元は、サンドボックスを使用してデータを整理する方法を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-258">A publisher needs to understand how to use sandboxes to organize data.</span></span>

<span data-ttu-id="4dce5-259">**注** 以下の例では、コンテンツの分離による実行時アクセスの管理のみを示しています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-259">**Note** The examples below only show run-time access management with content isolation.</span></span>

### <a name="scenario-1-two-titles-one-sandbox"></a><span data-ttu-id="4dce5-260">シナリオ 1: 2 つのタイトル、1 つのサンドボックス</span><span class="sxs-lookup"><span data-stu-id="4dce5-260">Scenario 1: Two titles, one sandbox</span></span>

<span data-ttu-id="4dce5-261">公開元にとっての基本的な構造として次のようなものが考えられます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-261">The basic structure for a publisher could be:</span></span>

-   <span data-ttu-id="4dce5-262">設計時と実行時のどちらの場合も、公開元が所有するすべてのユーザーとすべてのデバイスがアクセスできる 2 つのタイトル。</span><span class="sxs-lookup"><span data-stu-id="4dce5-262">Two titles that are accessible to all users and devices owned by the publisher for both design time and runtime.</span></span>

-   <span data-ttu-id="4dce5-263">タイトルごとに 1 つの製品インスタンス。</span><span class="sxs-lookup"><span data-stu-id="4dce5-263">One product instance per title.</span></span>

<span data-ttu-id="4dce5-264">この場合、公開元に必要なのは、すべてのプレリリース コンテンツ用の 1 つのサンドボックスだけです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-264">In this instance, the publisher just needs a single sandbox for all pre-release content.</span></span>

<span data-ttu-id="4dce5-265">次の図にユーザー グループを示します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-265">The diagram below shows a user group.</span></span> <span data-ttu-id="4dce5-266">公開元は、必要に応じてユーザー グループの代わりにデバイス グループを使用することもできます (デバイス グループの方が簡単である場合など)。</span><span class="sxs-lookup"><span data-stu-id="4dce5-266">The publisher may choose to use a device group instead of a user group, if deemed easier.</span></span> <span data-ttu-id="4dce5-267">また、このユーザー グループは、サンドボックス XLDP.1 とこのサンドボックス内のタイトルに、実行時および設計時にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-267">Also, this user group has run-time and design-time access to sandbox XLDP.1 and the titles in this sandbox.</span></span>

![](images/sandboxes/sandboxes_image6.png)

### <a name="scenario-2-one-title-different-teams"></a><span data-ttu-id="4dce5-268">シナリオ 2: 1 つのタイトル、異なるチーム</span><span class="sxs-lookup"><span data-stu-id="4dce5-268">Scenario 2: One title, different teams</span></span>

<span data-ttu-id="4dce5-269">このモデルでの要件は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-269">In this model, the requirements are:</span></span>

-   <span data-ttu-id="4dce5-270">1 つのタイトル。</span><span class="sxs-lookup"><span data-stu-id="4dce5-270">One title.</span></span>

-   <span data-ttu-id="4dce5-271">開発チームは日単位のビルドを使用して作業する。</span><span class="sxs-lookup"><span data-stu-id="4dce5-271">Dev team works on daily builds.</span></span>

-   <span data-ttu-id="4dce5-272">QA チームは週単位の LKG を使用して作業する。</span><span class="sxs-lookup"><span data-stu-id="4dce5-272">QA team works on weekly LKGs.</span></span>

-   <span data-ttu-id="4dce5-273">バグがあった場合、開発チームは週単位の LKG をデバッグする必要がある。</span><span class="sxs-lookup"><span data-stu-id="4dce5-273">Dev team needs to debug weekly LKGs in case of bugs.</span></span>

-   <span data-ttu-id="4dce5-274">ファイナンス チームは、タイトルのカタログ リリースに関連する価格カードやその他のメタデータにアクセスする必要がある。</span><span class="sxs-lookup"><span data-stu-id="4dce5-274">The finance team needs access to the price cards and other metadata related to the catalog release of a title.</span></span>

<span data-ttu-id="4dce5-275">次の図は、TitleX に 2 つの製品インスタンス PI-1 と PI-2 があることを示しています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-275">The figure below shows that TitleX has two product instances: PI-1 and PI-2.</span></span> <span data-ttu-id="4dce5-276">製品インスタンスはサンドボックス内に存在する必要がありますが、同じタイトルの 2 つの製品インスタンスが同じサンドボックス内に存在することはできません。</span><span class="sxs-lookup"><span data-stu-id="4dce5-276">A product instance has to be in a sandbox and two product instances of the same title cannot be in the same sandbox.</span></span> <span data-ttu-id="4dce5-277">そのため、TitleX-PI-1 はサンドボックス XLDP.1 内にあり、TitleX-PI-2 はサンドボックス XLDP.2 内にあります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-277">Thus, TitleX-PI-1 is in sandbox XLDP.1 and TitleX-PI-2 is in sandbox XLDP.2.</span></span>

<span data-ttu-id="4dce5-278">開発ユーザー グループは両方のサンドボックスにアクセスできますが、QA ユーザー グループはサンドボックス XLDP.2 にしかアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="4dce5-278">The dev user group has access to both sandboxes, whereas the QA user group has access to only sandbox XLDP.2.</span></span>

<span data-ttu-id="4dce5-279">また、ファイナンス ユーザー (Group C) は TitleX への設計時アクセスが可能です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-279">Also, the finance user (Group C) has design-time access to TitleX.</span></span> <span data-ttu-id="4dce5-280">ファイナンス ユーザー グループは通常、タイトルの実行時デバッグにはかかわらないため、分離されています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-280">Because the finance user group will not typically do any run-time debugging of a title, they are separated out.</span></span>

<span data-ttu-id="4dce5-281">**注** 組織に関係なく、XDP ユーザーは複数のユーザー グループに属することができます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-281">**Note** Irrespective of the organization, an XDP user can belong in more than one user group.</span></span>

![](images/sandboxes/sandboxes_image7.png)

### <a name="scenario-3-two-titles-completely-separate"></a><span data-ttu-id="4dce5-282">シナリオ 3: 2 つのタイトル、完全に分離</span><span class="sxs-lookup"><span data-stu-id="4dce5-282">Scenario 3: Two titles, completely separate</span></span>

<span data-ttu-id="4dce5-283">この例では、要件が少し異なります。</span><span class="sxs-lookup"><span data-stu-id="4dce5-283">In this example, the requirements change a bit:</span></span>

-   <span data-ttu-id="4dce5-284">2 つのタイトル。</span><span class="sxs-lookup"><span data-stu-id="4dce5-284">Two titles.</span></span>

-   <span data-ttu-id="4dce5-285">各タイトルへのアクセスを特定の個人の集合に制限する必要がある。</span><span class="sxs-lookup"><span data-stu-id="4dce5-285">Access to each title should be limited to a certain set of individuals.</span></span>

-   <span data-ttu-id="4dce5-286">タイトルごとに 1 つの製品インスタンス。</span><span class="sxs-lookup"><span data-stu-id="4dce5-286">One product instance per title.</span></span>

-   <span data-ttu-id="4dce5-287">タイトルの設計時 XDP 構成データにアクセスする必要がある管理ユーザー グループ。</span><span class="sxs-lookup"><span data-stu-id="4dce5-287">An admin user group who needs access to design-time XDP config data for the titles.</span></span> <span data-ttu-id="4dce5-288">このグループ内の個人は全員が公開元の管理者であり、カタログに公開されるすべてのデータ (カタログ メタデータ、ファイナンス、マーケティング、認定の申請などに関するデータ) を制御できます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-288">The individuals in this group are all admins for the publisher and can control all data that is published to the catalog (catalog metadata, finance, marketing, certification submission, etc.)</span></span>

<span data-ttu-id="4dce5-289">このモデルでは、公開元は両方のタイトルを完全に分離しておくことを選択し、これら 2 つのタイトルを 2 つの異なるサンドボックスに割り当てました。</span><span class="sxs-lookup"><span data-stu-id="4dce5-289">In this model, the publisher has chosen to keep both titles completely separated and thus assigned these two titles in two different sandboxes.</span></span> <span data-ttu-id="4dce5-290">また公開元は、独立した管理ユーザー グループを作成することを選択し、2 つの製品へのアクセスを割り当てました。</span><span class="sxs-lookup"><span data-stu-id="4dce5-290">The publisher has also chosen to create a separate admin user group and assigned access to the two products.</span></span>

![](images/sandboxes/sandboxes_image8.png)

### <a name="scenario-4-anyway-you-like-it"></a><span data-ttu-id="4dce5-291">シナリオ 4: 自由自在に</span><span class="sxs-lookup"><span data-stu-id="4dce5-291">Scenario 4: Anyway you like it</span></span>

<span data-ttu-id="4dce5-292">以下の例では、接続の数を少なくして説明を短くするために、サンドボックスの実行時接続のみを示しました。</span><span class="sxs-lookup"><span data-stu-id="4dce5-292">Due to the number of connections and to keep the verbiage short, we have chosen to show only the sandbox run-time connections.</span></span> <span data-ttu-id="4dce5-293">設計時のその他のアクセス許可も自由に追加することができます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-293">Nothing prevents you from adding other design-time access permissions as well.</span></span>

<span data-ttu-id="4dce5-294">この例では、要件は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-294">In this example, the requirements are:</span></span>

-   <span data-ttu-id="4dce5-295">公開元内部の特定の要員のみが特定のタイトルにアクセスできる。</span><span class="sxs-lookup"><span data-stu-id="4dce5-295">Only certain people have access to certain titles inside their publisher.</span></span>

-   <span data-ttu-id="4dce5-296">公開元はさまざまな企業のベンダーと協業し、これらのベンダーは短期契約である場合がある。</span><span class="sxs-lookup"><span data-stu-id="4dce5-296">The publisher works with vendors from different companies and these vendors may be short-term.</span></span>

-   <span data-ttu-id="4dce5-297">公開元は、タイトルを使用停止にすることによって、ベンダーまたは FTE がアクセスしていたデータへのアクセスを遮断できる必要がある。</span><span class="sxs-lookup"><span data-stu-id="4dce5-297">The publisher should be able to decommission a title and by doing so, prevent access to any data that the vendors or FTEs had access to.</span></span>

<span data-ttu-id="4dce5-298">この要件をモデル化するために、次のような構造を採用することができます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-298">In order to model this requirement, a structure such as the one below can be adopted.</span></span>

<span data-ttu-id="4dce5-299">使用したモデルは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4dce5-299">The model followed below is:</span></span>

-   <span data-ttu-id="4dce5-300">TitleX と TitleY の製品インスタンスが、サンドボックス XLDP.1 にそれぞれ 1 つだけある。</span><span class="sxs-lookup"><span data-stu-id="4dce5-300">TitleX and TitleY have only one product instance each in sandbox XLDP.1.</span></span>

-   <span data-ttu-id="4dce5-301">TitleZ には 2 つの製品インスタンスがあり、1 つはサンドボックス XLDP.2 に、もう 1 つはサンドボックス XLDP.3 にある。</span><span class="sxs-lookup"><span data-stu-id="4dce5-301">TitleZ has two product instances, one in sandbox XLDP.2 and another in sandbox XLDP.3.</span></span>

-   <span data-ttu-id="4dce5-302">FTE User Group B は、すべてのサンドボックス内の製品インスタンスへのアクセスが許可される。</span><span class="sxs-lookup"><span data-stu-id="4dce5-302">FTE User Group B is given access to product instances in all sandboxes.</span></span>

-   <span data-ttu-id="4dce5-303">Vendor User Group A はベンダーのみのユーザー グループであり、サンドボックス XLDP.1 へのアクセスが許可される。</span><span class="sxs-lookup"><span data-stu-id="4dce5-303">Vendor User Group A is a vendor-only user group that is given access to sandbox XLDP.1.</span></span>

-   <span data-ttu-id="4dce5-304">Vendor Device Group C はベンダーのみのユーザー グループであり、サンドボックス XLDP.3 へのアクセスが許可される。</span><span class="sxs-lookup"><span data-stu-id="4dce5-304">Vendor Device Group C is a vendor-only user group that is given access to sandbox XLDP.3.</span></span>

![](images/sandboxes/sandboxes_image9.png)

## <a name="summary"></a><span data-ttu-id="4dce5-305">まとめ</span><span class="sxs-lookup"><span data-stu-id="4dce5-305">Summary</span></span>

<span data-ttu-id="4dce5-306">Xbox Live 開発では、運用品質のサービスと運用レベルの MSA 開発者アカウントを使用して運用環境でテストを実行できるため、公開元にとっては非常に有用な開発を実現できます。</span><span class="sxs-lookup"><span data-stu-id="4dce5-306">Xbox Live development provides tremendous opportunity to publishers to test in production with production-quality services and production MSA developer accounts.</span></span> <span data-ttu-id="4dce5-307">機能と柔軟性の向上に伴い、開発中および一般提供後、タイトル データを作成したり、タイトルへのアクセスを管理したりするための新しい構成手順が XDP で必要になっています。</span><span class="sxs-lookup"><span data-stu-id="4dce5-307">The increase in functionality and flexibility requires new configuration steps in XDP to create title data and manage access to the titles while in development and in general availability.</span></span>

<span data-ttu-id="4dce5-308">サンドボックスは運用環境のデータをパーティション分割するための方法です。</span><span class="sxs-lookup"><span data-stu-id="4dce5-308">Sandboxes are a way to partition data in production.</span></span> <span data-ttu-id="4dce5-309">すべてのコンテンツを対象とした運用環境は 1 だけしか存在しないため、サンドボックスは、ある環境で生成されたデータが他の環境に移行されない "仮想環境" として機能します。</span><span class="sxs-lookup"><span data-stu-id="4dce5-309">Because there is a single production environment for all content, sandboxes act as “virtual environments” where data generated in one environment does not cross over to the other.</span></span>
