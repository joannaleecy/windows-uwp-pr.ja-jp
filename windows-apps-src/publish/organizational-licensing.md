---
author: jnHs
Description: You can indicate whether and how your app can be offered for volume purchases through the Microsoft Store for Business and Microsoft Store for Education in the Organizational licensing section of an app submission.
title: "組織のライセンス オプション"
ms.assetid: 1EB139B0-67E7-4F66-AAEF-491B1E52E96F
ms.author: wdg-dev-content
ms.date: 01/12/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, ビジネス向け Store, 教育機関向け Store, 組織, ボリューム ライセンス, 企業, 教育機関 Store, ビジネス Store, ボリューム購入, 一括"
localizationpriority: high
ms.openlocfilehash: 7437b087c0966939bb5f5d8110d310f4dd5e73df
ms.sourcegitcommit: 446fe2861651f51a129baa80791f565f81b4f317
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/12/2018
---
# <a name="organizational-licensing-options"></a><span data-ttu-id="158da-103">組織のライセンス オプション</span><span class="sxs-lookup"><span data-stu-id="158da-103">Organizational licensing options</span></span>


<span data-ttu-id="158da-104">アプリの申請の [[価格と使用可能状況]](set-app-pricing-and-availability.md#organizational-licensing) ページの **[組織のライセンス]** セクションでは、ビジネス向け Microsoft ストアと教育機関向け Microsoft ストアでアプリのボリューム購入を提供するかどうかと、その提供方法を指定できます。</span><span class="sxs-lookup"><span data-stu-id="158da-104">You can indicate whether and how your app can be offered for volume purchases through Microsoft Store for Business and Microsoft Store for Education in the **Organizational licensing** section of the [Pricing and availability](set-app-pricing-and-availability.md#organizational-licensing) page of an app submission.</span></span>

<span data-ttu-id="158da-105">これらの設定を通じて、ユーザー用に複数のライセンスを取得し展開する組織 (ビジネスおよび教育機関) にアプリを提供することができ、PC、タブレット、電話など、各種 Windows 10 デバイスを使用する組織を取り込むチャンスを拡大できます。</span><span class="sxs-lookup"><span data-stu-id="158da-105">Through these settings, you can opt to allow your app to be made available to organizations (business and educational) who acquire and deploy multiple licenses for their users, providing an opportunity to increase your reach to organizations across Windows 10 device types, including PCs, tablets and phones.</span></span>

<span data-ttu-id="158da-106">企業に直接公開する[基幹業務 (LOB) アプリ](distribute-lob-apps-to-enterprises.md)に対して組織のライセンスを許可する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="158da-106">You will also need to allow organizational licensing for any [line-of-business (LOB) apps](distribute-lob-apps-to-enterprises.md) that you publish directly to enterprises.</span></span>

> [!NOTE]
> <span data-ttu-id="158da-107">各アプリの選択はそれぞれ独立して構成します。</span><span class="sxs-lookup"><span data-stu-id="158da-107">Selections for each of your apps are configured independently from each other.</span></span> <span data-ttu-id="158da-108">アプリの基本設定は、新しい申請を作成することでいつでも変更できます。また、変更は申請が[認定プロセス](the-app-certification-process.md)を完了した後に有効になります。</span><span class="sxs-lookup"><span data-stu-id="158da-108">You may change your preferences for an app at any time by creating a new submission, and your changes will take effect after the submission completes the [certification process](the-app-certification-process.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="158da-109">[Microsoft Store 申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) を使う申請は、ビジネス向け Microsoft Store と教育機関向け Microsoft Store では利用可能になりません。</span><span class="sxs-lookup"><span data-stu-id="158da-109">Submissions that use the [Microsoft Store submission API](../monetize/create-and-manage-submissions-using-windows-store-services.md) won't be made available to Microsoft Store for Business and Microsoft Store for Education.</span></span> <span data-ttu-id="158da-110">組織がアプリをボリューム購入できるようにするには、Windows デベロッパー センター ダッシュボードを使って申請を作成および提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="158da-110">To make your app available for volume purchases by organizations, you must use the Windows Dev Center dashboard to create and submit your submissions.</span></span>


## <a name="allowing-your-app-to-be-offered-to-organizations"></a><span data-ttu-id="158da-111">組織へのアプリの提供の許可</span><span class="sxs-lookup"><span data-stu-id="158da-111">Allowing your app to be offered to organizations</span></span>

<span data-ttu-id="158da-112">既定では、**[ストアで管理される (オンライン) ボリューム ライセンスと配布に基づいて組織がこのアプリを購入できるようにする]** チェック ボックスはオンになっています。</span><span class="sxs-lookup"><span data-stu-id="158da-112">By default, the box labeled **Make my app available to organizations with Store-managed (online) licensing and distribution** is checked.</span></span> <span data-ttu-id="158da-113">これは、組織がボリューム取得できるアプリのカタログにアプリを含め、ストアのオンライン ライセンス システムでアプリのライセンスが管理されるようにすることを意味します。</span><span class="sxs-lookup"><span data-stu-id="158da-113">This means that you wish your app to be available for inclusion in catalogs of apps that will be made available to organizations for volume acquisition, with app licenses managed through the Store's online licensing system.</span></span>

> [!NOTE]
> <span data-ttu-id="158da-114">すべての組織がアプリを利用できるようになるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="158da-114">This does not guarantee that your app will be made available to all organizations.</span></span>

<span data-ttu-id="158da-115">組織がアプリをボリューム取得できるようにしない場合は、このチェック ボックスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="158da-115">If you prefer not to allow us to offer your app to organizations for volume acquisition, uncheck this box.</span></span> <span data-ttu-id="158da-116">この変更はアプリが認定プロセスを完了した後にのみ有効になることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="158da-116">Note that this change will only take place after the app completes the certification process.</span></span> <span data-ttu-id="158da-117">組織が以前にアプリのライセンスを取得していた場合、これらのライセンスは有効であり、アプリを既に持っているユーザーは使い続けることができます。</span><span class="sxs-lookup"><span data-stu-id="158da-117">If any organizations had previously acquired licenses to your app, those licenses will still be valid, and the people who have the app already can continue to use it.</span></span>

> [!TIP]
> <span data-ttu-id="158da-118">基幹業務 (LOB) アプリを特定の組織に対してのみ公開するには、企業の関連付けを設定して、組織がアプリをプライベート ストアに直接追加できるようにします。</span><span class="sxs-lookup"><span data-stu-id="158da-118">To publish line-of-business (LOB) apps exclusively to a specific organization, you can set up an enterprise association and allow the organization to add the apps directly their private store.</span></span> <span data-ttu-id="158da-119">詳しくは、「[LOB アプリの企業への配布](distribute-lob-apps-to-enterprises.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="158da-119">For more info, see [Distribute LOB apps to enterprises](distribute-lob-apps-to-enterprises.md).</span></span>


## <a name="allowing-disconnected-offline-licensing"></a><span data-ttu-id="158da-120">未接続状態 (オフライン) のライセンスの許可</span><span class="sxs-lookup"><span data-stu-id="158da-120">Allowing disconnected (offline) licensing</span></span>

<span data-ttu-id="158da-121">オフラインのライセンスに対応したアプリを多くの組織が必要としています。</span><span class="sxs-lookup"><span data-stu-id="158da-121">Many organizations need apps enabled for offline licensing.</span></span> <span data-ttu-id="158da-122">たとえば、一部の組織では、インターネットに接続することがまったくないか、ほとんどないデバイスにアプリを展開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="158da-122">For example, some organizations need to deploy apps to devices which rarely or never connect to the internet.</span></span> <span data-ttu-id="158da-123">このようなユーザーがアプリを利用できるようにする場合は、**[組織に対して、組織で管理される (オフライン) ライセンスと配布を許可する]** というチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="158da-123">If you want to allow your app to be made available to these customers, check the box labeled **Allow organization-managed (offline) licensing and distribution for organizations**.</span></span>

<span data-ttu-id="158da-124">既定では、このチェック ボックスは**オフ**です。</span><span class="sxs-lookup"><span data-stu-id="158da-124">Note that this box is **unchecked** by default.</span></span> <span data-ttu-id="158da-125">検証済みの組織が組織で管理する (オフライン) ライセンスを使用してインストールできるように、Microsoft ストアからアプリを提供する場合は、このチェック ボックスをオンにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="158da-125">You must check the box to allow us to make your app available to verified organizations who will install it using organization-managed (offline) licensing.</span></span> <span data-ttu-id="158da-126">この方法で有料アプリをエンド ユーザーにインストールするためには、組織は追加の検証を受ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="158da-126">Organizations must go through additional validation in order to install paid apps to their end users in this way.</span></span>

<span data-ttu-id="158da-127">オフラインのライセンスでは、組織はボリューム ベースでアプリを取得し、各デバイスがストアのライセンス システムに問い合わせる必要なくアプリをインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="158da-127">Offline licensing allows organizations to acquire your app on a volume basis, and then install the app without requiring each device to contact the Store's licensing system.</span></span> <span data-ttu-id="158da-128">組織はライセンスと共にアプリのパッケージをダウンロードすることができ、このライセンスでは特定のライセンスが使用されているときにストアに通知することなく、(独自の管理ツールを使用するか、OS イメージにアプリを事前に読み込むことによって) アプリをデバイスにインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="158da-128">The organization is able to download your app's package along with a license which lets them install it to devices (via their own management tools or by preloading apps on OS images) without notifying the Store when a particular license has been used.</span></span> <span data-ttu-id="158da-129">このシナリオを有効にすることで展開の柔軟性が大幅に増し、ユーザーにとってのアプリの魅力が大きく高まる場合があります。</span><span class="sxs-lookup"><span data-stu-id="158da-129">Enabling this scenario greatly increases deployment flexibility, and it may substantially increase the attractiveness of your app with these customers.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="158da-130">.xap パッケージでは、オフラインのライセンスはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="158da-130">Offline licensing is not supported for .xap packages.</span></span>  

 
## <a name="paid-app-support"></a><span data-ttu-id="158da-131">有料アプリのサポート</span><span class="sxs-lookup"><span data-stu-id="158da-131">Paid app support</span></span>

<span data-ttu-id="158da-132">現在、特定の市場の開発者アカウントでは、有料アプリをビジネス向け Microsoft ストアでボリューム取得用に提供することができます。</span><span class="sxs-lookup"><span data-stu-id="158da-132">Currently, developer accounts located in certain markets are able to offer paid apps for volume acquisition through Microsoft Store for Business.</span></span> 

> [!NOTE]
> <span data-ttu-id="158da-133">一部の市場では、ビジネス向け Microsoft Store や教育機関向け Microsoft Store に表示されるアプリの価格が、Microsoft Store の同じ価格帯で小売顧客に表示される価格と異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="158da-133">In some markets, the price shown for an app in Microsoft Store for Business or Microsoft Store for Education may be different than the price shown to retail customers in the Microsoft Store for the same price tier.</span></span> <span data-ttu-id="158da-134">組織による購入の収益の支払いは、コンシューマーによるアプリの購入の場合と同様に機能します。</span><span class="sxs-lookup"><span data-stu-id="158da-134">Payout of proceeds from organizational purchases works just the same as it does for consumer purchases of your app.</span></span> <span data-ttu-id="158da-135">詳しくは、「[支払いの受け取り](getting-paid-apps.md)」と「[アプリ開発者契約](https://msdn.microsoft.com/library/windows/apps/hh694058)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="158da-135">For more info, see [Getting paid](getting-paid-apps.md) and the [App Developer Agreement](https://msdn.microsoft.com/library/windows/apps/hh694058).</span></span> <span data-ttu-id="158da-136">ビジネス向け Microsoft ストアと教育機関向け Microsoft ストアを利用できる市場の一覧については、「[ビジネス向け Microsoft ストアと教育機関向け Microsoft ストアの概要](https://technet.microsoft.com/itpro/windows/manage/windows-store-for-business-overview#supported-markets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="158da-136">For a list of markets where Microsoft Store for Business and Microsoft Store for Education are available, see [Microsoft Store for Business and Microsoft Store for Education overview](https://technet.microsoft.com/itpro/windows/manage/windows-store-for-business-overview#supported-markets).</span></span>

<span data-ttu-id="158da-137">お住まいの国または地域が以下の一覧にない場合は、現在、有料アプリをビジネス向け Microsoft ストアと教育機関向け Microsoft ストアで提供することはできません。</span><span class="sxs-lookup"><span data-stu-id="158da-137">If your country or region is not listed below, your paid apps currently will not be offered in Microsoft Store for Business and Microsoft Store for Education.</span></span> <span data-ttu-id="158da-138">この場合、有料アプリ用に選択した組織のライセンスの設定は後で適用されることがあります。Microsoft ストアでは、他の開発者アカウント市場からの申請に対するサポートを将来追加することがあるためです。</span><span class="sxs-lookup"><span data-stu-id="158da-138">If this is the case, the organizational licensing selections you make for your paid apps may be applied at a later time, as we may add support for submissions from additional developer account markets in the future.</span></span>

<span data-ttu-id="158da-139">現時点では、ビジネス向け Microsoft ストアと教育機関向け Microsoft ストアで組織の顧客に有料アプリを配付できるのは、以下の国または地域の開発者です。</span><span class="sxs-lookup"><span data-stu-id="158da-139">At this time, developers located in the following countries and regions can distribute paid apps to organizational customers via Microsoft Store for Business and Microsoft Store for Education:</span></span>

- <span data-ttu-id="158da-140">オーストリア</span><span class="sxs-lookup"><span data-stu-id="158da-140">Austria</span></span>
- <span data-ttu-id="158da-141">ベルギー</span><span class="sxs-lookup"><span data-stu-id="158da-141">Belgium</span></span>
- <span data-ttu-id="158da-142">ブルガリア</span><span class="sxs-lookup"><span data-stu-id="158da-142">Bulgaria</span></span>
- <span data-ttu-id="158da-143">カナダ</span><span class="sxs-lookup"><span data-stu-id="158da-143">Canada</span></span>
- <span data-ttu-id="158da-144">クロアチア</span><span class="sxs-lookup"><span data-stu-id="158da-144">Croatia</span></span>
- <span data-ttu-id="158da-145">キプロス</span><span class="sxs-lookup"><span data-stu-id="158da-145">Cyprus</span></span>
- <span data-ttu-id="158da-146">チェコ共和国</span><span class="sxs-lookup"><span data-stu-id="158da-146">Czech Republic</span></span>
- <span data-ttu-id="158da-147">デンマーク</span><span class="sxs-lookup"><span data-stu-id="158da-147">Denmark</span></span>
- <span data-ttu-id="158da-148">エストニア</span><span class="sxs-lookup"><span data-stu-id="158da-148">Estonia</span></span>
- <span data-ttu-id="158da-149">フィンランド</span><span class="sxs-lookup"><span data-stu-id="158da-149">Finland</span></span>
- <span data-ttu-id="158da-150">フランス</span><span class="sxs-lookup"><span data-stu-id="158da-150">France</span></span>
- <span data-ttu-id="158da-151">ドイツ</span><span class="sxs-lookup"><span data-stu-id="158da-151">Germany</span></span>
- <span data-ttu-id="158da-152">ギリシャ</span><span class="sxs-lookup"><span data-stu-id="158da-152">Greece</span></span>
- <span data-ttu-id="158da-153">ハンガリー</span><span class="sxs-lookup"><span data-stu-id="158da-153">Hungary</span></span>
- <span data-ttu-id="158da-154">アイルランド</span><span class="sxs-lookup"><span data-stu-id="158da-154">Ireland</span></span>
- <span data-ttu-id="158da-155">マン島</span><span class="sxs-lookup"><span data-stu-id="158da-155">Isle of Man</span></span>
- <span data-ttu-id="158da-156">イタリア</span><span class="sxs-lookup"><span data-stu-id="158da-156">Italy</span></span>
- <span data-ttu-id="158da-157">ラトビア</span><span class="sxs-lookup"><span data-stu-id="158da-157">Latvia</span></span>
- <span data-ttu-id="158da-158">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="158da-158">Liechtenstein</span></span>
- <span data-ttu-id="158da-159">リトアニア</span><span class="sxs-lookup"><span data-stu-id="158da-159">Lithuania</span></span>
- <span data-ttu-id="158da-160">ルクセンブルク</span><span class="sxs-lookup"><span data-stu-id="158da-160">Luxembourg</span></span>
- <span data-ttu-id="158da-161">マルタ</span><span class="sxs-lookup"><span data-stu-id="158da-161">Malta</span></span>
- <span data-ttu-id="158da-162">モナコ</span><span class="sxs-lookup"><span data-stu-id="158da-162">Monaco</span></span>
- <span data-ttu-id="158da-163">オランダ</span><span class="sxs-lookup"><span data-stu-id="158da-163">Netherlands</span></span>
- <span data-ttu-id="158da-164">ノルウェー</span><span class="sxs-lookup"><span data-stu-id="158da-164">Norway</span></span>
- <span data-ttu-id="158da-165">ポーランド</span><span class="sxs-lookup"><span data-stu-id="158da-165">Poland</span></span>
- <span data-ttu-id="158da-166">ポルトガル</span><span class="sxs-lookup"><span data-stu-id="158da-166">Portugal</span></span>
- <span data-ttu-id="158da-167">ルーマニア</span><span class="sxs-lookup"><span data-stu-id="158da-167">Romania</span></span>
- <span data-ttu-id="158da-168">スロバキア</span><span class="sxs-lookup"><span data-stu-id="158da-168">Slovakia</span></span>
- <span data-ttu-id="158da-169">スロベニア</span><span class="sxs-lookup"><span data-stu-id="158da-169">Slovenia</span></span>
- <span data-ttu-id="158da-170">スペイン</span><span class="sxs-lookup"><span data-stu-id="158da-170">Spain</span></span>
- <span data-ttu-id="158da-171">スウェーデン</span><span class="sxs-lookup"><span data-stu-id="158da-171">Sweden</span></span>
- <span data-ttu-id="158da-172">スイス</span><span class="sxs-lookup"><span data-stu-id="158da-172">Switzerland</span></span>
- <span data-ttu-id="158da-173">英国</span><span class="sxs-lookup"><span data-stu-id="158da-173">United Kingdom</span></span>
- <span data-ttu-id="158da-174">米国</span><span class="sxs-lookup"><span data-stu-id="158da-174">United States</span></span>
