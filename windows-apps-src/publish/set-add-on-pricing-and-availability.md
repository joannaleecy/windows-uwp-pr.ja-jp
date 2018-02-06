---
author: jnHs
Description: When submitting an add-on, the options on the Pricing and availability page determine what to charge for your add-on and how it should be offered to customers.
title: "アドオンの価格と使用可能状況の設定"
ms.assetid: B3D4B753-716B-460B-A3B1-ED5712ECD694
ms.author: wdg-dev-content
ms.date: 01/12/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, アドオン, iap, 価格"
ms.localizationpriority: high
ms.openlocfilehash: 8eb2321ec6d2bc8602438e2dc66ca1d96690a3f8
ms.sourcegitcommit: 446fe2861651f51a129baa80791f565f81b4f317
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/12/2018
---
# <a name="set-add-on-pricing-and-availability"></a><span data-ttu-id="be1b7-103">アドオンの価格と使用可能状況の設定</span><span class="sxs-lookup"><span data-stu-id="be1b7-103">Set add-on pricing and availability</span></span>


<span data-ttu-id="be1b7-104">アドオンを申請するときには、**[価格と使用可能状況]** ページのオプションで、アドオンの価格やユーザーに提供する方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="be1b7-104">When submitting an add-on, the options on the **Pricing and availability** page determine what to charge for your add-on and how it should be offered to customers.</span></span>

## <a name="markets"></a><span data-ttu-id="be1b7-105">市場</span><span class="sxs-lookup"><span data-stu-id="be1b7-105">Markets</span></span>

<span data-ttu-id="be1b7-106">既定では、アドオンは販売できるすべての市場 (今後追加される可能性のある市場も含む) にその基本価格で公開されます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-106">By default, your add-on will be listed in all possible markets, including any future markets that we may add later, at its base price.</span></span>

<span data-ttu-id="be1b7-107">ただし、アプリと同様に、アドオンを提供する市場を選ぶためのオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="be1b7-107">However, just as with an app, you have the option to choose the markets in which you'd like to offer your add-on.</span></span> <span data-ttu-id="be1b7-108">ほとんどの場合、アプリと同じ一連の市場の選びますが、必要に応じて柔軟に変更できます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-108">In most cases you'll want to pick the same set of markets as the app, but you have the flexibility to make changes as needed.</span></span> 

<span data-ttu-id="be1b7-109">詳しい情報と利用可能な市場の一覧については、「[市場の選択の定義](define-pricing-and-market-selection.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="be1b7-109">For more info and a full list of the available markets, see [Define market selection](define-pricing-and-market-selection.md).</span></span>

## <a name="visibility"></a><span data-ttu-id="be1b7-110">表示</span><span class="sxs-lookup"><span data-stu-id="be1b7-110">Visibility</span></span>

<span data-ttu-id="be1b7-111">アドオンをユーザーが購入できるようにするかどうかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-111">You can determine whether your add-on should be offered for purchase to customers.</span></span> 

<span data-ttu-id="be1b7-112">既定のオプションは **[親製品のストア登録情報に表示することができます]** です。</span><span class="sxs-lookup"><span data-stu-id="be1b7-112">The default option is **Can be displayed in the parent product’s Store listing**.</span></span> <span data-ttu-id="be1b7-113">アドオンをすべてのユーザーに提供する場合は、このオプションをオンのままにしておきます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-113">Leave this option checked for add-ons that will be made available to any customer.</span></span> 

<span data-ttu-id="be1b7-114">広範囲に公開したくないアドオンについては、**[ストアに表示しない]** と、次のいずれかのオプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-114">For add-ons that you don't want to make broadly available, select **Hidden in the Store** and one of the following options:</span></span>

-   <span data-ttu-id="be1b7-115">**[親製品内のみから購入することができます]**: このオプションを選ぶと、ユーザーはアプリ内からアドオンを購入できますが、アドオンはアプリのストア登録情報ページには表示されません。</span><span class="sxs-lookup"><span data-stu-id="be1b7-115">**Available for purchase from within the parent product only**: Choosing this option allows any customer to purchase the add-on from within your app, but the add-on will not be displayed in your app's Store listing.</span></span> <span data-ttu-id="be1b7-116">初期の内部テスト期間中など、一般に広く公開されていない場合にのみ、このオプションを使います。</span><span class="sxs-lookup"><span data-stu-id="be1b7-116">Use this only when the offer is not broadly available, for example during initial periods of internal testing.</span></span>
-   <span data-ttu-id="be1b7-117">**[購入の停止: 直接リンクを知っているユーザーは製品のストア登録情報を表示できます。ただし、製品をダウンロードできるのは、以前にその製品を所有していたか、またはプロモーション コードを持っている場合で、かつ Windows 10 デバイスを使用している場合のみです。このアドオンは、親製品のストア登録情報には表示されません]**: このオプションを選ぶと、アドオンはアプリの登録情報ページに表示されず、新しいユーザーはアドオンを購入することができません。</span><span class="sxs-lookup"><span data-stu-id="be1b7-117">**Stop acquisition: Any customer with a direct link can see the product’s Store listing, but they can only download it if they owned the product before, or have a promotional code and are using a Windows 10 device. This add-on is not displayed in the parent product's listing**: Choosing this option means that the add-on won't be displayed in your app's listing, and no new customers may purchase the add-on.</span></span> <span data-ttu-id="be1b7-118">ただし、**このオプションは、Windows 8.1 またはそれ以前のバージョンのユーザーについてはサポートされていません**。</span><span class="sxs-lookup"><span data-stu-id="be1b7-118">However, **this option is not supported for customers on Windows 8.1 or earlier**.</span></span> <span data-ttu-id="be1b7-119">アプリが Windows 8.1 またはそれ以前のバージョンで利用できる場合、それらのユーザーは引き続きアドオンを購入できます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-119">If your app is available on Windows 8.1 or earlier, the add-on will still be available for purchase to those customers.</span></span> <span data-ttu-id="be1b7-120">Windows 8.1 またはそれ以前バージョンのユーザーに対して、このアドオンの提供を停止するには、アプリを更新してアドオンを提供するコードを削除し、新しいアプリの提出パッケージを公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="be1b7-120">To stop offering the add-on to customers on Windows 8.1 or earlier, you'll need to update your app to remove the code that offers the add-on, then publish a new submission for the app.</span></span> <span data-ttu-id="be1b7-121">アプリが Windows 8.1 またはそれ以前のバージョンを対象としていない場合でも、この方法をお勧めします。利用できないようにすることを選択したアドオンをユーザーに提供しないことは、ユーザーのエクスペリエンス向上につながります。</span><span class="sxs-lookup"><span data-stu-id="be1b7-121">This is recommended even if your app doesn't target Windows 8.1 or earlier; it's a better experience for your customers if you never offer them an add-on that you've opted to make unavailable.</span></span>
    
 > [!NOTE] 
 > <span data-ttu-id="be1b7-122">**[購入の停止]** オプションを選んだ場合や、アプリのコードからアドオンを削除するアプリの更新プログラムを提出した場合でも、オペレーティング システムに関係なく、アドオンを購入済みのユーザーには影響しません。</span><span class="sxs-lookup"><span data-stu-id="be1b7-122">Choosing the **Stop acquisition** option, and/or submitting an app update that removes the add-on from your app's code, does not affect customers who have already purchased the add-on, regardless of their operating system.</span></span>


## <a name="schedule"></a><span data-ttu-id="be1b7-123">スケジュール</span><span class="sxs-lookup"><span data-stu-id="be1b7-123">Schedule</span></span>

<span data-ttu-id="be1b7-124">既定では (**[表示]** セクションで **[ストアに表示しない]** のオプションのいずれかを選択した場合を除き)、アドオンが認定に合格して公開プロセスが完了すると、そのアプリはすぐにユーザーが利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="be1b7-124">By default (unless you have selected one of the **Hidden in the Store** options in the **Visibility** section), your add-on will be available to customers as soon as it passes certification and complete the publishing process.</span></span> <span data-ttu-id="be1b7-125">他の日付を選択するには、**[オプションの表示]** を選択してこのセクションを展開します。</span><span class="sxs-lookup"><span data-stu-id="be1b7-125">To choose other dates, select **Show options** to expand this section.</span></span> 

<span data-ttu-id="be1b7-126">詳しくは、「[正確なリリース スケジュールの構成](configure-precise-release-scheduling.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="be1b7-126">For more info, see [Configure precise release scheduling](configure-precise-release-scheduling.md).</span></span>


## <a name="pricing"></a><span data-ttu-id="be1b7-127">価格設定</span><span class="sxs-lookup"><span data-stu-id="be1b7-127">Pricing</span></span>

<span data-ttu-id="be1b7-128">開発者は (**[表示]** セクションで **[購入の停止]** オプションを選んだ場合を除き)、アドオンの基本価格として、**[無料]** または用意されている価格帯 (0.99 米ドル～) のいずれかを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="be1b7-128">You must select a base price for your add-on (unless you have selected the **Stop acquisition** option in the **Visibility** section), choosing either **Free** or one of the available price tiers (starting at .99 USD).</span></span>

<span data-ttu-id="be1b7-129">価格変更をスケジュールして、アドオンの価格を変更する日時を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-129">You can also schedule price changes to indicate the date and time at which the add-on’s price should change.</span></span> <span data-ttu-id="be1b7-130">さらに、これらの変更を特定の市場向けにカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-130">Additionally, you have the option to customize these changes for specific markets.</span></span> 

<span data-ttu-id="be1b7-131">詳しくは、「[アプリの価格の設定とスケジュール](set-and-schedule-app-pricing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="be1b7-131">For more info, see [Set and schedule app pricing](set-and-schedule-app-pricing.md).</span></span>


## <a name="sale-pricing"></a><span data-ttu-id="be1b7-132">セール価格</span><span class="sxs-lookup"><span data-stu-id="be1b7-132">Sale pricing</span></span>

<span data-ttu-id="be1b7-133">期間限定でアドオンを割引価格で提供する場合は、特売を作成し、そのスケジュールを設定できます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-133">If you want to offer your add-on at a reduced price for a limited period of time, you can create and schedule a sale.</span></span> <span data-ttu-id="be1b7-134">詳しくは、「[アプリとアドオンの販売](put-apps-and-add-ons-on-sale.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="be1b7-134">For more info, see [Put apps and add-ons on sale](put-apps-and-add-ons-on-sale.md).</span></span>


## <a name="publish-date"></a><span data-ttu-id="be1b7-135">公開日</span><span class="sxs-lookup"><span data-stu-id="be1b7-135">Publish date</span></span>

<span data-ttu-id="be1b7-136">既定では、既に説明したように [**[スケジュール]** セクション](#schedule)で日付を構成した場合を除き、申請が認定に合格するとすぐに公開プロセスが開始されます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-136">By default, your submission will begin the publishing process as soon as it passes certification, unless you have configured dates in the [**Schedule** section](#schedule) described above.</span></span> 

<span data-ttu-id="be1b7-137">アドオンがストアに公開される日時を制御するには、**[スケジュール]** セクションを使います。</span><span class="sxs-lookup"><span data-stu-id="be1b7-137">To control when your add-on should be published to the Store, use the **Schedule** section.</span></span> <span data-ttu-id="be1b7-138">ほとんどの申請では、このセクションを使ってリリースをスケジュールし、**[公開日]** セクションは既定のオプションである **[認定後すぐにこの申請を公開]** に設定したままにします。</span><span class="sxs-lookup"><span data-stu-id="be1b7-138">For most submissions, you should use that section to schedule your release, and leave the **Publish date** section set to the default option, **Publish this submission as soon as it passes certification**.</span></span> <span data-ttu-id="be1b7-139">この設定にしても、**[スケジュール]** セクションで設定した日付より前に申請が公開されることはありません。</span><span class="sxs-lookup"><span data-stu-id="be1b7-139">This will not cause the submission to be published earlier than the date(s) that you set in the **Schedule** section.</span></span> <span data-ttu-id="be1b7-140">**[スケジュール]** セクションで選択した日付は、ユーザーがストアでアドオンを利用できるようになる時期を決定します。</span><span class="sxs-lookup"><span data-stu-id="be1b7-140">The dates you selected in the **Schedule** section will determine when your add-on becomes available to customers in the Store.</span></span>

<span data-ttu-id="be1b7-141">まだリリース日を設定せず、手動で公開プロセスを開始するまで申請を非公開のままにする場合は、**[手動でこの申請を公開]** を選択できます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-141">If you don’t want to set a release date yet, and you prefer your submission to remain unpublished until you manually decide to start the publishing process, you can choose **Publish this submission manually.**</span></span> <span data-ttu-id="be1b7-142">このオプションを選択した場合、開発者が指示するまで申請は公開されません。</span><span class="sxs-lookup"><span data-stu-id="be1b7-142">Choosing this option means that your selection won’t be published until you indicate that it should be.</span></span> <span data-ttu-id="be1b7-143">アドオンが認定に合格した後、認定のステータス ページで **[今すぐ公開]** を選択するか、以下に説明するように特定の日付を選択すると、申請を公開することができます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-143">After your add-on passes certification, you can publish it by selecting **Publish now** on the certification status page, or by selecting a specific date as described below.</span></span>

<span data-ttu-id="be1b7-144">申請が特定の日付まで公開されないようにするには、**[次の予定日に公開する \[日付\]]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-144">Choose **No sooner than \[date\]** to ensure that the submission is not published until a certain date.</span></span> <span data-ttu-id="be1b7-145">このオプションを選ぶと、申請は指定された日付の当日またはその日以降に、できるだけ早くリリースされます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-145">With this option, your submission will be released as soon as possible on or after the date you specify.</span></span> <span data-ttu-id="be1b7-146">日付は 24 時間以上先の日付にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="be1b7-146">The date must be at least 24 hours in the future.</span></span> <span data-ttu-id="be1b7-147">日付と同時に、申請を公開し始める時刻を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="be1b7-147">Along with the date, you can also specify the time at which the submission should begin to be published.</span></span>
 
> [!NOTE]
> <span data-ttu-id="be1b7-148">認定または公開に遅延が生じると、実際のリリース日が、希望する日付よりも後になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="be1b7-148">Delays during certification or publishing could cause the actual release date to be later than the date you request.</span></span> <span data-ttu-id="be1b7-149">Microsoft Store ではアドオン (更新プログラム) が特定の日にリリースされることを保証できません。</span><span class="sxs-lookup"><span data-stu-id="be1b7-149">The Microsoft Store cannot guarantee that your add-on (or update) will be available on a specific date.</span></span>  



 




