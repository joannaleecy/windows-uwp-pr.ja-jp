---
author: jnHs
Description: When submitting an add-on, the options on the Pricing and availability page determine what to charge for your add-on and how it should be offered to customers.
title: アドオンの価格と使用可能状況の設定
ms.assetid: B3D4B753-716B-460B-A3B1-ED5712ECD694
ms.author: wdg-dev-content
ms.date: 05/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アドオン, iap, 価格
ms.localizationpriority: medium
ms.openlocfilehash: b5b7a6424fea3d62849e992f56b0b40ab72a55f5
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4313358"
---
# <a name="set-add-on-pricing-and-availability"></a><span data-ttu-id="e3d5c-103">アドオンの価格と使用可能状況の設定</span><span class="sxs-lookup"><span data-stu-id="e3d5c-103">Set add-on pricing and availability</span></span>


<span data-ttu-id="e3d5c-104">アドオンを申請するときに、**[価格と使用可能状況]** ページのオプションで、アドオンの料金やユーザーに提供する方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-104">When submitting an add-on, the options on the **Pricing and availability** page determine what to charge for your add-on and how it should be offered to customers.</span></span>

## <a name="markets"></a><span data-ttu-id="e3d5c-105">市場</span><span class="sxs-lookup"><span data-stu-id="e3d5c-105">Markets</span></span>

<span data-ttu-id="e3d5c-106">既定では、アドオンは販売できるすべての市場 (今後追加される可能性のある市場も含む) にその基本価格で公開されます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-106">By default, your add-on will be listed in all possible markets, including any future markets that we may add later, at its base price.</span></span>

<span data-ttu-id="e3d5c-107">ただし、アプリと同様に、アドオンを提供する市場を選ぶためのオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-107">However, just as with an app, you have the option to choose the markets in which you'd like to offer your add-on.</span></span> <span data-ttu-id="e3d5c-108">ほとんどの場合、アプリと同じ一連の市場の選びますが、必要に応じて柔軟に変更できます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-108">In most cases you'll want to pick the same set of markets as the app, but you have the flexibility to make changes as needed.</span></span> 

<span data-ttu-id="e3d5c-109">詳しい情報と利用可能な市場の一覧については、「[市場の選択の定義](define-pricing-and-market-selection.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-109">For more info and a full list of the available markets, see [Define market selection](define-pricing-and-market-selection.md).</span></span>

## <a name="visibility"></a><span data-ttu-id="e3d5c-110">表示</span><span class="sxs-lookup"><span data-stu-id="e3d5c-110">Visibility</span></span>

<span data-ttu-id="e3d5c-111">アドオンをユーザーが購入できるようにするかどうかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-111">You can determine whether your add-on should be offered for purchase to customers.</span></span> 

<span data-ttu-id="e3d5c-112">既定のオプションは **[親製品のストア登録情報に表示することができます]** です。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-112">The default option is **Can be displayed in the parent product’s Store listing**.</span></span> <span data-ttu-id="e3d5c-113">アドオンをすべてのユーザーに提供する場合は、このオプションをオンのままにしておきます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-113">Leave this option checked for add-ons that will be made available to any customer.</span></span> 

<span data-ttu-id="e3d5c-114">広範囲に公開したくないアドオンについては、**[ストアに表示しない]** と、次のいずれかのオプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-114">For add-ons that you don't want to make broadly available, select **Hidden in the Store** and one of the following options:</span></span>

-   <span data-ttu-id="e3d5c-115">**[親製品内のみから購入することができます]**: このオプションを選ぶと、ユーザーはアプリ内からアドオンを購入できますが、アドオンはアプリのストア登録情報ページには表示されません。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-115">**Available for purchase from within the parent product only**: Choosing this option allows any customer to purchase the add-on from within your app, but the add-on will not be displayed in your app's Store listing.</span></span> <span data-ttu-id="e3d5c-116">初期の内部テスト期間中など、一般に広く公開されていない場合にのみ、このオプションを使います。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-116">Use this only when the offer is not broadly available, for example during initial periods of internal testing.</span></span>
-   <span data-ttu-id="e3d5c-117">**[購入の停止: 直接リンクを知っているユーザーは製品のストア登録情報を表示できます。ただし、製品をダウンロードできるのは、以前にその製品を所有していたか、またはプロモーション コードを持っている場合で、かつ Windows 10 デバイスを使用している場合のみです。このアドオンは、親製品のストア登録情報には表示されません]**: このオプションを選ぶと、アドオンはアプリの登録情報ページに表示されず、新しいユーザーはアドオンを購入することができません。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-117">**Stop acquisition: Any customer with a direct link can see the product’s Store listing, but they can only download it if they owned the product before, or have a promotional code and are using a Windows 10 device. This add-on is not displayed in the parent product's listing**: Choosing this option means that the add-on won't be displayed in your app's listing, and no new customers may purchase the add-on.</span></span> <span data-ttu-id="e3d5c-118">ただし、**このオプションは、Windows 8.1 またはそれ以前のバージョンのユーザーについてはサポートされていません**。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-118">However, **this option is not supported for customers on Windows 8.1 or earlier**.</span></span> <span data-ttu-id="e3d5c-119">アプリが Windows 8.1 またはそれ以前のバージョンで利用できる場合、それらのユーザーは引き続きアドオンを購入できます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-119">If your app is available on Windows 8.1 or earlier, the add-on will still be available for purchase to those customers.</span></span> <span data-ttu-id="e3d5c-120">Windows 8.1 またはそれ以前バージョンのユーザーに対して、このアドオンの提供を停止するには、アプリを更新してアドオンを提供するコードを削除し、新しいアプリの提出パッケージを公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-120">To stop offering the add-on to customers on Windows 8.1 or earlier, you'll need to update your app to remove the code that offers the add-on, then publish a new submission for the app.</span></span> <span data-ttu-id="e3d5c-121">アプリが Windows 8.1 またはそれ以前のバージョンを対象としていない場合でも、この方法をお勧めします。利用できないようにすることを選択したアドオンをユーザーに提供しないことは、ユーザーのエクスペリエンス向上につながります。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-121">This is recommended even if your app doesn't target Windows 8.1 or earlier; it's a better experience for your customers if you never offer them an add-on that you've opted to make unavailable.</span></span>
    
 > [!NOTE] 
 > <span data-ttu-id="e3d5c-122">**[購入の停止]** オプションを選んだ場合や、アプリのコードからアドオンを削除するアプリの更新プログラムを提出した場合でも、オペレーティング システムに関係なく、アドオンを購入済みのユーザーには影響しません。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-122">Choosing the **Stop acquisition** option, and/or submitting an app update that removes the add-on from your app's code, does not affect customers who have already purchased the add-on, regardless of their operating system.</span></span>


## <a name="schedule"></a><span data-ttu-id="e3d5c-123">スケジュール</span><span class="sxs-lookup"><span data-stu-id="e3d5c-123">Schedule</span></span>

<span data-ttu-id="e3d5c-124">既定では (**[表示]** セクションで **[ストアに表示しない]** のオプションのいずれかを選択した場合を除き)、アドオンが認定に合格して公開プロセスが完了すると、そのアプリはすぐにユーザーが利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-124">By default (unless you have selected one of the **Hidden in the Store** options in the **Visibility** section), your add-on will be available to customers as soon as it passes certification and complete the publishing process.</span></span> <span data-ttu-id="e3d5c-125">他の日付を選択するには、**[オプションの表示]** を選択してこのセクションを展開します。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-125">To choose other dates, select **Show options** to expand this section.</span></span> 

<span data-ttu-id="e3d5c-126">詳しくは、「[正確なリリース スケジュールの構成](configure-precise-release-scheduling.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-126">For more info, see [Configure precise release scheduling](configure-precise-release-scheduling.md).</span></span>


## <a name="pricing"></a><span data-ttu-id="e3d5c-127">価格設定</span><span class="sxs-lookup"><span data-stu-id="e3d5c-127">Pricing</span></span>

<span data-ttu-id="e3d5c-128">(**購入の停止]** オプションを選択した場合は、**可視性**」セクションで) を除き、アドオンの基本価格を選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-128">You must select a base price for your add-on (unless you have selected the **Stop acquisition** option in the **Visibility** section).</span></span> <span data-ttu-id="e3d5c-129">既定の選択は、**無料**、有料のアドオンの場合は、必ず (米ドル.99 以降) 利用可能な価格帯のいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-129">The default selection is **Free**, so if you want to charge money for the add-on, be sure to choose one of the available price tiers (starting at .99 USD).</span></span>

<span data-ttu-id="e3d5c-130">価格変更をスケジュールして、アドオンの価格を変更する日時を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-130">You can also schedule price changes to indicate the date and time at which the add-on’s price should change.</span></span> <span data-ttu-id="e3d5c-131">さらに、これらの変更を特定の市場向けにカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-131">Additionally, you have the option to customize these changes for specific markets.</span></span> 

> [!TIP]
> <span data-ttu-id="e3d5c-132">サブスクリプション アドオンの場合、それ以降の申請でより高い基本価格を選択することによって、または価格の増加価格変更をスケジュールすることによって、アドオンの公開後の価格を上げることはできません。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-132">For subscription add-ons, you can't raise the price after you publish the add-on, either by selecting a higher base price in a later submission or by scheduling a price change that increases the price.</span></span> <span data-ttu-id="e3d5c-133">これらのメソッドのいずれかを使用して、割引価格を選択することができますが、価格を下げるとその新しい価格より高いさせるできなくなります。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-133">You can select a lower price using either of these methods, but once the price is lowered you won't be able to raise it higher than that new price.</span></span> <span data-ttu-id="e3d5c-134">このため、サブスクリプション アドオンの適切な価格帯を選択するかを確認することが特に重要です。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-134">Because of this, it's especially important to be sure you select the appropriate price tier for subscription add-ons.</span></span> 

<span data-ttu-id="e3d5c-135">詳しくは、「[アプリの価格の設定とスケジュール](set-and-schedule-app-pricing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-135">For more info, see [Set and schedule app pricing](set-and-schedule-app-pricing.md).</span></span>


## <a name="sale-pricing"></a><span data-ttu-id="e3d5c-136">セール価格</span><span class="sxs-lookup"><span data-stu-id="e3d5c-136">Sale pricing</span></span>

<span data-ttu-id="e3d5c-137">期間限定でアドオンを割引価格で提供する場合は、特売を作成し、そのスケジュールを設定できます。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-137">If you want to offer your add-on at a reduced price for a limited period of time, you can create and schedule a sale.</span></span> <span data-ttu-id="e3d5c-138">詳しくは、「[アプリとアドオンの販売](put-apps-and-add-ons-on-sale.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e3d5c-138">For more info, see [Put apps and add-ons on sale](put-apps-and-add-ons-on-sale.md).</span></span>



