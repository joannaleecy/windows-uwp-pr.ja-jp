---
Description: You can publish line-of-business (LOB) apps directly to enterprises for volume acquisition via the Microsoft Store for Business or Microsoft Store for Education, without making the apps broadly available in the Store.
title: LOB アプリの企業への配布
ms.assetid: 2050126E-CE49-4DE3-AC2B-A572AC895158
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, UWP, LOB, 基幹業務, エンタープライズ アプリ, ビジネス向け Store, 教育機関向け Store, 企業
ms.localizationpriority: medium
ms.openlocfilehash: c6e1eafbce5eca1570161da1656c0242228ff7de
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/04/2019
ms.locfileid: "9044589"
---
# <a name="distribute-lob-apps-to-enterprises"></a><span data-ttu-id="4da67-103">LOB アプリの企業への配布</span><span class="sxs-lookup"><span data-stu-id="4da67-103">Distribute LOB apps to enterprises</span></span>


<span data-ttu-id="4da67-104">ビジネス向け Microsoft ストアまたは教育機関向け Microsoft ストアでは、基幹業務 (LOB) アプリを企業に直接公開して、ボリューム取得を可能にすることができます。アプリをストアで一般公開する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4da67-104">You can publish line-of-business (LOB) apps directly to enterprises for volume acquisition via Microsoft Store for Business or Microsoft Store for Education, without making the apps broadly available in the Store.</span></span>

> [!NOTE]
> <span data-ttu-id="4da67-105">現在、ビジネス向け Microsoft ストアまたは教育機関向け Microsoft ストアを通じて企業に排他的に配布できるのは無料アプリだけです。</span><span class="sxs-lookup"><span data-stu-id="4da67-105">At this time, only free apps can be distributed exclusively to enterprises via Microsoft Store for Business or Microsoft Store for Education.</span></span> <span data-ttu-id="4da67-106">有料アプリを LOB として申請しても、企業が利用できるようにはなりません。</span><span class="sxs-lookup"><span data-stu-id="4da67-106">If you submit a paid app as LOB, it will not be available to the enterprise.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="4da67-107">[Microsoft Store 申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) を使って、LOB アプリを直接企業に公開することはできません。</span><span class="sxs-lookup"><span data-stu-id="4da67-107">You cannot use the [Microsoft Store submission API](../monetize/create-and-manage-submissions-using-windows-store-services.md) to publish LOB apps directly to enterprises.</span></span> <span data-ttu-id="4da67-108">パートナー センターで LOB アプリのすべての申請を公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-108">All submissions for LOB apps must be published through Partner Center.</span></span>


## <a name="set-up-the-enterprise-association"></a><span data-ttu-id="4da67-109">企業の関連付けの設定</span><span class="sxs-lookup"><span data-stu-id="4da67-109">Set up the enterprise association</span></span>

<span data-ttu-id="4da67-110">LOB アプリを専用アプリとして企業に公開するには、最初に、お使いのアカウントと企業のプライベート ストアを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="4da67-110">The first step in publishing LOB apps exclusively to an enterprise is to establish the association between your account and the enterprise’s private store.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4da67-111">この関連付けプロセスは、企業が開始する必要があります。また、開発者アカウントの作成に使った Microsoft アカウントに関連付けられているメール アドレスを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-111">This association process must be initiated by the enterprise, and must use the email address associated with the Microsoft account that was used to create the developer account.</span></span> <span data-ttu-id="4da67-112">詳しくは、「[基幹業務アプリの操作](https://go.microsoft.com/fwlink/p/?LinkId=698846)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4da67-112">For more info, see [Working with line-of-business apps](https://go.microsoft.com/fwlink/p/?LinkId=698846).</span></span>

<span data-ttu-id="4da67-113">企業は、専用アプリを公開してほしいと思う開発者に、関連付けを確認するためのリンクを含むメールを送信します。</span><span class="sxs-lookup"><span data-stu-id="4da67-113">When an enterprise chooses to invite you to publish apps for their exclusive use, you’ll get an email that includes a link to confirm the association.</span></span> <span data-ttu-id="4da67-114">**[アカウント設定]** の **[企業団体]** セクションに移動することで、これらの関連付けを確認することもできます (開発者アカウントを開くために使った Microsoft アカウントでサインインしている場合に限ります)。</span><span class="sxs-lookup"><span data-stu-id="4da67-114">You can also confirm these associations by going to the **Enterprise associations** section of your **Account settings** (as long as you are signed in with the Microsoft account that was used to open the developer account).</span></span>

<span data-ttu-id="4da67-115">関連付けを確認するには、**[承諾]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4da67-115">To confirm the association, click **Accept**.</span></span> <span data-ttu-id="4da67-116">お使いのアカウントが、その企業専用のアプリを公開できるようになります。</span><span class="sxs-lookup"><span data-stu-id="4da67-116">Your account will then be able to publish apps for that enterprise’s exclusive use.</span></span>


## <a name="submit-lob-apps"></a><span data-ttu-id="4da67-117">LOB アプリの提出</span><span class="sxs-lookup"><span data-stu-id="4da67-117">Submit LOB apps</span></span>

<span data-ttu-id="4da67-118">企業専用のアプリを公開する準備ができたら、プロセスは、アプリの申請プロセスとほぼ同じです。</span><span class="sxs-lookup"><span data-stu-id="4da67-118">Once you’re ready to publish an app for an enterprise’s exclusive use, the process is similar to the app submission process.</span></span> <span data-ttu-id="4da67-119">アプリは同じ[認定プロセス](the-app-certification-process.md)で処理され、すべての [Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)に準拠している必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-119">The app goes through the same [certification process](the-app-certification-process.md), and must comply with all [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span> <span data-ttu-id="4da67-120">異なる点はわずかです。</span><span class="sxs-lookup"><span data-stu-id="4da67-120">There are just a few parts of the process that are different.</span></span>


### <a name="visibility"></a><span data-ttu-id="4da67-121">表示</span><span class="sxs-lookup"><span data-stu-id="4da67-121">Visibility</span></span>

<span data-ttu-id="4da67-122">企業の関連付けを設定したら、アプリを申請するたびに、その申請の **[価格と使用可能状況]** ページの **[表示]** セクションにドロップダウン ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4da67-122">After you've set up an enterprise association, every time you submit an app you’ll see a drop-down box in the **Visibility** section of the submission’s **Pricing and availability** page.</span></span> <span data-ttu-id="4da67-123">既定では、これは **[小売配布]** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="4da67-123">By default, this is set to **Retail distribution**.</span></span> <span data-ttu-id="4da67-124">アプリを企業専用にするには、**[基幹業務 (LOB) 配布]** を選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-124">To make the app exclusive to an enterprise, you’ll need to choose **Line-of-business (LOB) distribution**.</span></span>

<span data-ttu-id="4da67-125">**[基幹業務 (LOB) 配布]** を選択すると、通常の **[表示]** オプションが専用アプリの公開先として選択できる企業の一覧に変わります。</span><span class="sxs-lookup"><span data-stu-id="4da67-125">Once **Line-of-business (LOB) distribution** is selected, the usual **Visibility** options will be replaced with a list of the enterprises to which you can publish exclusive apps.</span></span> <span data-ttu-id="4da67-126">選択した企業の外部のユーザーは、アプリを表示することもダウンロードすることもできません。</span><span class="sxs-lookup"><span data-stu-id="4da67-126">No one outside of the enterprise(s) you select will be able to view or download the app.</span></span>

<span data-ttu-id="4da67-127">基幹業務アプリとして公開するには、少なくとも 1 つの企業を選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-127">You must select at least one enterprise in order to publish an app as line-of-business.</span></span>

<span id="organizational" />

### <a name="organizational-licensing"></a><span data-ttu-id="4da67-128">組織のライセンス</span><span class="sxs-lookup"><span data-stu-id="4da67-128">Organizational licensing</span></span>

<span data-ttu-id="4da67-129">既定では、アプリを申請するとき、**[ストアで管理される (オンライン) ボリューム ライセンスと配布]** のチェック ボックスはオンになっています。</span><span class="sxs-lookup"><span data-stu-id="4da67-129">By default, the box for **Store-managed (online) volume licensing** is checked when you submit an app.</span></span> <span data-ttu-id="4da67-130">LOB アプリを公開するとき、このチェック ボックスは、企業がアプリをボリューム取得できるようにオンにしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-130">When publishing LOB apps, this box must remain checked so that the enterprise can acquire your app in volume.</span></span> <span data-ttu-id="4da67-131">このように設定しても、**[分布と認知度]** セクションで選択した企業以外のユーザーが、このアプリを利用できるようになるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="4da67-131">This will not make the app available to anyone outside of the enterprise(s) that you selected in the **Distribution and visibility** section.</span></span>

<span data-ttu-id="4da67-132">未接続状態 (オフライン) のライセンスによって企業がアプリを利用できるようにするには、**[組織で管理される (オフライン) ライセンスと配布]** チェック ボックスもオンにします。</span><span class="sxs-lookup"><span data-stu-id="4da67-132">If you’d like to make the app available to the enterprise via disconnected (offline) licensing, you can check the **Disconnected (offline) licensing** box as well.</span></span>

<span data-ttu-id="4da67-133">詳しくは、「[組織のライセンス オプション](organizational-licensing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4da67-133">For more info, see [Organizational licensing options](organizational-licensing.md).</span></span>


### <a name="age-ratings"></a><span data-ttu-id="4da67-134">年齢区分</span><span class="sxs-lookup"><span data-stu-id="4da67-134">Age ratings</span></span>

<span data-ttu-id="4da67-135">LOB アプリでの申請のプロセスの[年齢区分](age-ratings.md)の手順は、販売アプリと同様ですが、アンケートへの回答や既存の IARC 評価 ID のインポートを行わずに、ストアの年齢区分を手動で指定できる追加のオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="4da67-135">For LOB apps, the [age ratings](age-ratings.md) step of the submission process works the same as for retail apps, but you also have an additional option that allows you to indicate the Store age rating of your app manually rather than completing the questionnaire or importing an existing IARC rating ID.</span></span> <span data-ttu-id="4da67-136">この手動の区分は、基幹業務 (LOB) 配布のみで使うことができます。そのため、アプリの **[表示]** の設定を \*\*[小売配布] \*\* に変更する場合には、申請を行う前に、年齢区分のアンケートへの回答を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-136">This manual rating can only be used with LOB distribution, so if you ever change the **Visibility** setting of the app to **Retail distribution**, you'll need to take the age ratings questionnaire before you can publish the submission.</span></span>


## <a name="enterprise-deployment-of-lob-apps"></a><span data-ttu-id="4da67-137">LOB アプリの企業展開</span><span class="sxs-lookup"><span data-stu-id="4da67-137">Enterprise deployment of LOB apps</span></span>

<span data-ttu-id="4da67-138">**[ストアに提出]** をクリックすると、アプリの認定プロセスが開始します。</span><span class="sxs-lookup"><span data-stu-id="4da67-138">After you click **Submit to the Store**, the app will go through the certification process.</span></span> <span data-ttu-id="4da67-139">準備ができたら、企業の管理者が、そのアプリをビジネス向け Microsoft ストアまたは教育機関向け Microsoft ストア ポータルのプライベート ストアに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-139">Once it’s ready, an admin for the enterprise must add it to their private store in the Microsoft Store for Business or Microsoft Store for Education portal.</span></span> <span data-ttu-id="4da67-140">その後、企業はそのアプリをユーザーに展開できます。</span><span class="sxs-lookup"><span data-stu-id="4da67-140">The enterprise can then deploy the app to its users.</span></span>

> [!NOTE]
> <span data-ttu-id="4da67-141">LOB アプリを取得するには、組織が[サポート対象の市場](https://technet.microsoft.com/itpro/windows/whats-new/windows-store-for-business-overview#supported-markets)に含まれている必要があります。また、アプリを提出する際に、その[市場を除外](define-pricing-and-market-selection.md)することはできません。</span><span class="sxs-lookup"><span data-stu-id="4da67-141">In order to get your LOB app, the organization must be located in a [supported market](https://technet.microsoft.com/itpro/windows/whats-new/windows-store-for-business-overview#supported-markets), and you must not have [excluded that market](define-pricing-and-market-selection.md) when submitting your app.</span></span> 

<span data-ttu-id="4da67-142">詳しくは、[基幹業務アプリの操作](https://go.microsoft.com/fwlink/p/?LinkId=698846)に関するページ、および[プライベート ストアを使用したアプリの配布](https://go.microsoft.com/fwlink/p/?LinkId=698847)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4da67-142">For more info, see [Working with line-of-business apps](https://go.microsoft.com/fwlink/p/?LinkId=698846) and [Distribute apps using your private store](https://go.microsoft.com/fwlink/p/?LinkId=698847).</span></span>


## <a name="update-lob-apps"></a><span data-ttu-id="4da67-143">LOB アプリの更新</span><span class="sxs-lookup"><span data-stu-id="4da67-143">Update LOB apps</span></span>

<span data-ttu-id="4da67-144">LOB として既に公開したアプリに更新プログラムを公開するには、新しい申請を作成するだけです。</span><span class="sxs-lookup"><span data-stu-id="4da67-144">To publish updates to an app that you’ve already published as LOB, simply create a new submission.</span></span> <span data-ttu-id="4da67-145">新しいパッケージをアップロードするか、変更を加えて、**[ストアに提出]** をクリックし、更新されたバージョンを利用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="4da67-145">You can upload new packages or make any other changes, then click **Submit to the Store** to make the updated version available.</span></span> <span data-ttu-id="4da67-146">**[表示]** で選択されている企業はそのままにしてください (アプリを取得できるようにする企業を追加する、前にアプリを配布していた企業を削除するなど、意図的に変更する場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="4da67-146">Be sure to keep the enterprise selections in **Visibility** the same, unless you intentionally want to make changes such as selecting an additional enterprise to acquire the app, or removing one of the enterprises to which you’d previously distributed it.</span></span>

<span data-ttu-id="4da67-147">前に基幹業務として公開したアプリの提供を終了して、これ以上取得できないようにするには、新しい申請を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4da67-147">If you want to stop offering an app that you’ve previously published as line-of-business, and prevent any new acquisitions, you’ll need to create a new submission.</span></span> <span data-ttu-id="4da67-148">最初に、**[表示]** セクションを **[基幹業務 (LOB) 配布]** から **[小売配布]** に変更します。</span><span class="sxs-lookup"><span data-stu-id="4da67-148">First, you’ll need to change your **Visibility** selection from **Line-of-business (LOB) distribution** to **Retail distribution**.</span></span> <span data-ttu-id="4da67-149">次に [[Discoverability]](choose-visibility-options.md#discoverability) (見つけやすさ) セクションで **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** と **[購入の停止]** オプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="4da67-149">Then, in the [Discoverability](choose-visibility-options.md#discoverability) section, choose **Make this product available but not discoverable in the Store** with the **Stop acquisition** option.</span></span>

<span data-ttu-id="4da67-150">申請の認定プロセスが完了すると、以降そのアプリは取得できなくなります (アプリを既に所有しているユーザーは引き続き使用できます)。</span><span class="sxs-lookup"><span data-stu-id="4da67-150">After the submission goes through the certification process, the app will no longer be available for new acquisitions (although anyone who already has it will continue to be able to use it).</span></span>

> [!NOTE]
> <span data-ttu-id="4da67-151">アプリを **[小売配布]** に変更する場合には、[年齢区分のアンケート](age-ratings.md)に回答していない場合、回答する必要があります (アプリが新規取得用に提供されない場合でも同様です)。</span><span class="sxs-lookup"><span data-stu-id="4da67-151">When changing an app to **Retail distribution**, you'll need to complete the [age ratings questionnaire](age-ratings.md) if you haven't done so already, even if the app will not be available for new acquisitions.</span></span>


## <a name="distribute-lob-apps-through-sideloading"></a><span data-ttu-id="4da67-152">サイドローディングによる LOB アプリの配布</span><span class="sxs-lookup"><span data-stu-id="4da67-152">Distribute LOB apps through sideloading</span></span>

<span data-ttu-id="4da67-153">ビジネス向け Microsoft ストアまたは教育向け Microsoft ストアで企業にアプリを提供することで、アプリはストアによって確実に署名され、標準的なストア ポリシーに準拠します。</span><span class="sxs-lookup"><span data-stu-id="4da67-153">Making apps available to an enterprise through Microsoft Store for Business or Microsoft Store for Education ensures that the app has been signed by the Store and complies with the standard Store Policies.</span></span>

<span data-ttu-id="4da67-154">場合によっては、企業可能性があります (コンプライアンス上の理由やその他の機能を必要とするアプリなど)、パートナー センターを通じて提出するには、その LOB アプリをしません。</span><span class="sxs-lookup"><span data-stu-id="4da67-154">In some cases, companies may not want their LOB apps to be submitted through Partner Center (such as for compliance reasons or for apps that need additional capabilities).</span></span> <span data-ttu-id="4da67-155">このような企業では、ビジネス向け Microsoft ストアや教育向け Microsoft ストアを使わずに、サイドローディングによってアプリをコンピューターに直接展開できます。</span><span class="sxs-lookup"><span data-stu-id="4da67-155">In this case, the enterprise can deploy apps directly to machines via sideloading, without using Microsoft Store for Business or Microsoft Store for Education.</span></span>

<span data-ttu-id="4da67-156">詳しくは、「[Windows 10 での LOB アプリのサイドローディング](https://go.microsoft.com/fwlink/p/?LinkId=623433)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4da67-156">For more info, see [Sideload LOB apps in Windows 10](https://go.microsoft.com/fwlink/p/?LinkId=623433).</span></span>

 

 




