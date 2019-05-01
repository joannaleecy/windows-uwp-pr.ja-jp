---
Description: アドオンを申請するときには、[価格と使用可能状況] ページのオプションで、アドオンの価格やユーザーに提供する方法を指定します。
title: アドオンの価格と使用可能状況の設定
ms.assetid: B3D4B753-716B-460B-A3B1-ED5712ECD694
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, アドオン, iap, 価格
ms.localizationpriority: medium
ms.openlocfilehash: c6384b5890466ff13c72a1b90eb9b27194d51fff
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63788272"
---
# <a name="set-add-on-pricing-and-availability"></a><span data-ttu-id="3a8d2-104">アドオンの価格と使用可能状況の設定</span><span class="sxs-lookup"><span data-stu-id="3a8d2-104">Set add-on pricing and availability</span></span>

<span data-ttu-id="3a8d2-105">アドオンを送信するときに[パートナー センター](https://partner.microsoft.com/dashboard)、オプション、**価格と可用性**ページは、アドオンの顧客と顧客にどのように提供されるべき充電量を決定します。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-105">When submitting an add-on in [Partner Center](https://partner.microsoft.com/dashboard), the options on the **Pricing and availability** page determine how much to charge customers for your add-on and how it should be offered to customers.</span></span>

## <a name="markets"></a><span data-ttu-id="3a8d2-106">市場</span><span class="sxs-lookup"><span data-stu-id="3a8d2-106">Markets</span></span>

<span data-ttu-id="3a8d2-107">既定では、アドオンは販売できるすべての市場 (今後追加される可能性のある市場も含む) にその基本価格で公開されます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-107">By default, your add-on will be listed in all possible markets, including any future markets that we may add later, at its base price.</span></span>

<span data-ttu-id="3a8d2-108">ただし、アプリと同様に、アドオンを提供する市場を選ぶためのオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-108">However, just as with an app, you have the option to choose the markets in which you'd like to offer your add-on.</span></span> <span data-ttu-id="3a8d2-109">ほとんどの場合、アプリと同じ一連の市場の選びますが、必要に応じて柔軟に変更できます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-109">In most cases you'll want to pick the same set of markets as the app, but you have the flexibility to make changes as needed.</span></span> 

<span data-ttu-id="3a8d2-110">詳しい情報と利用可能な市場の一覧については、「[市場の選択の定義](define-pricing-and-market-selection.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-110">For more info and a full list of the available markets, see [Define market selection](define-pricing-and-market-selection.md).</span></span>

## <a name="visibility"></a><span data-ttu-id="3a8d2-111">表示</span><span class="sxs-lookup"><span data-stu-id="3a8d2-111">Visibility</span></span>

<span data-ttu-id="3a8d2-112">アドオンをユーザーが購入できるようにするかどうかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-112">You can determine whether your add-on should be offered for purchase to customers.</span></span> 

<span data-ttu-id="3a8d2-113">既定のオプションは **[親製品のストア登録情報に表示することができます]** です。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-113">The default option is **Can be displayed in the parent product’s Store listing**.</span></span> <span data-ttu-id="3a8d2-114">アドオンをすべてのユーザーに提供する場合は、このオプションをオンのままにしておきます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-114">Leave this option checked for add-ons that will be made available to any customer.</span></span> 

<span data-ttu-id="3a8d2-115">広範囲に公開したくないアドオンについては、**[ストアに表示しない]** と、次のいずれかのオプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-115">For add-ons that you don't want to make broadly available, select **Hidden in the Store** and one of the following options:</span></span>

-   <span data-ttu-id="3a8d2-116">**親製品のみ内からのご購入いただけます**:アプリケーション内からアドオンを購入するすべての顧客は、このオプションを選択しますが、アプリのストアの一覧に表示されているか、ストアで検索できる、アドオンは設定されません。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-116">**Available for purchase from within the parent product only**: Choosing this option allows any customer to purchase the add-on from within your app, but the add-on will not be displayed in your app's Store listing or discoverable in the Store.</span></span> <span data-ttu-id="3a8d2-117">初期の内部テスト期間中など、一般に広く公開されていない場合にのみ、このオプションを使います。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-117">Use this only when the offer is not broadly available, for example during initial periods of internal testing.</span></span>
-   <span data-ttu-id="3a8d2-118">**取得を停止します。直接リンクを持つすべての顧客は一覧から、製品のストアを確認できますが、前に、製品を所有しているが、プロモーション コードがあるし、Windows 10 デバイスを使用している場合のみダウンロードできます。このアドオンは、親製品の一覧に表示されていない**:このオプションを選ぶと、アドオンはアプリの内容ページに表示されず、新しいユーザーはアドオンを購入することができません。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-118">**Stop acquisition: Any customer with a direct link can see the product’s Store listing, but they can only download it if they owned the product before, or have a promotional code and are using a Windows 10 device. This add-on is not displayed in the parent product's listing**: Choosing this option means that the add-on won't be displayed in your app's listing, and no new customers may purchase the add-on.</span></span> <span data-ttu-id="3a8d2-119">ただし、**お客様の Windows 8.1 またはそれ以前にこのオプションはサポートされていません**します。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-119">However, **this option is not supported for customers on Windows 8.1 or earlier**.</span></span> <span data-ttu-id="3a8d2-120">公開されていたアプリが Windows 8.1 で利用可能な以前の場合は、アドオンはお客様にご購入いただけますできます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-120">If your previously-published app is available on Windows 8.1 or earlier, the add-on will still be available for purchase to those customers.</span></span> <span data-ttu-id="3a8d2-121">アドオンを Windows 8.1 またはそれ以前の顧客に提供を停止するには、アドオンを提供するコードを削除するアプリを更新し、アプリの新規サブミッションを発行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-121">To stop offering the add-on to customers on Windows 8.1 or earlier, you'll need to update your app to remove the code that offers the add-on, then publish a new submission for the app.</span></span> <span data-ttu-id="3a8d2-122">アプリ、Windows 8.1 またはそれ以前はそうでない場合でもこれはお勧めします決してを提供する場合に使用できないようにすることを選択するアドオンは、お客様のエクスペリエンスを向上させるを勧めします。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-122">This is recommended even if your app doesn't target Windows 8.1 or earlier; it's a better experience for your customers if you never offer them an add-on that you've opted to make unavailable.</span></span>
    
 > [!NOTE] 
 > <span data-ttu-id="3a8d2-123">**[購入の停止]** オプションを選んだ場合や、アプリのコードからアドオンを削除するアプリの更新プログラムを提出した場合でも、オペレーティング システムに関係なく、アドオンを購入済みのユーザーには影響しません。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-123">Choosing the **Stop acquisition** option, and/or submitting an app update that removes the add-on from your app's code, does not affect customers who have already purchased the add-on, regardless of their operating system.</span></span>


## <a name="schedule"></a><span data-ttu-id="3a8d2-124">[スケジュール]</span><span class="sxs-lookup"><span data-stu-id="3a8d2-124">Schedule</span></span>

<span data-ttu-id="3a8d2-125">既定では (**[表示]** セクションで **[ストアに表示しない]** のオプションのいずれかを選択した場合を除き)、アドオンが認定に合格して公開プロセスが完了すると、そのアプリはすぐにユーザーが利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-125">By default (unless you have selected one of the **Hidden in the Store** options in the **Visibility** section), your add-on will be available to customers as soon as it passes certification and complete the publishing process.</span></span> <span data-ttu-id="3a8d2-126">他の日付を選択するには、**[オプションの表示]** を選択してこのセクションを展開します。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-126">To choose other dates, select **Show options** to expand this section.</span></span> 

<span data-ttu-id="3a8d2-127">詳しくは、「[正確なリリース スケジュールの構成](configure-precise-release-scheduling.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-127">For more info, see [Configure precise release scheduling](configure-precise-release-scheduling.md).</span></span>


## <a name="pricing"></a><span data-ttu-id="3a8d2-128">価格設定</span><span class="sxs-lookup"><span data-stu-id="3a8d2-128">Pricing</span></span>

<span data-ttu-id="3a8d2-129">アドオンの基準価格を選択する必要があります (選択した場合を除き、**の取得を停止**オプション、**可視性**セクション)。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-129">You must select a base price for your add-on (unless you have selected the **Stop acquisition** option in the **Visibility** section).</span></span> <span data-ttu-id="3a8d2-130">既定の選択は**Free**、有料のアドオンは、(.99 米国ドルから始まります) 使用可能な価格レベルのいずれかを選択することを確認する場合は。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-130">The default selection is **Free**, so if you want to charge money for the add-on, be sure to choose one of the available price tiers (starting at .99 USD).</span></span>

<span data-ttu-id="3a8d2-131">価格変更をスケジュールして、アドオンの価格を変更する日時を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-131">You can also schedule price changes to indicate the date and time at which the add-on’s price should change.</span></span> <span data-ttu-id="3a8d2-132">さらに、これらの変更を特定の市場向けにカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-132">Additionally, you have the option to customize these changes for specific markets.</span></span> 

> [!TIP]
> <span data-ttu-id="3a8d2-133">以降の送信で高い基準価格を選択するか、により、価格の価格の変更をスケジュールすることによって、アドオンをパブリッシュした後、サブスクリプションのアドオンの価格を上げることができません。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-133">For subscription add-ons, you can't raise the price after you publish the add-on, either by selecting a higher base price in a later submission or by scheduling a price change that increases the price.</span></span> <span data-ttu-id="3a8d2-134">これらのメソッドのいずれかを使用して、低価格を選択できますが、価格の引き下げ後は、その新しい価格よりも高いさせるしませんできます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-134">You can select a lower price using either of these methods, but once the price is lowered you won't be able to raise it higher than that new price.</span></span> <span data-ttu-id="3a8d2-135">このためには、サブスクリプションのアドオンの適切な価格レベルを選択したことを確認することが特に重要です。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-135">Because of this, it's especially important to be sure you select the appropriate price tier for subscription add-ons.</span></span> 

<span data-ttu-id="3a8d2-136">詳しくは、「[アプリの価格の設定とスケジュール](set-and-schedule-app-pricing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-136">For more info, see [Set and schedule app pricing](set-and-schedule-app-pricing.md).</span></span>


## <a name="sale-pricing"></a><span data-ttu-id="3a8d2-137">セール価格</span><span class="sxs-lookup"><span data-stu-id="3a8d2-137">Sale pricing</span></span>

<span data-ttu-id="3a8d2-138">期間限定でアドオンを割引価格で提供する場合は、特売を作成し、そのスケジュールを設定できます。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-138">If you want to offer your add-on at a reduced price for a limited period of time, you can create and schedule a sale.</span></span> <span data-ttu-id="3a8d2-139">詳しくは、「[アプリとアドオンの販売](put-apps-and-add-ons-on-sale.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8d2-139">For more info, see [Put apps and add-ons on sale](put-apps-and-add-ons-on-sale.md).</span></span>



