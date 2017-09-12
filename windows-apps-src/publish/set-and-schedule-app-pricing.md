---
author: jnHs
Description: "アプリの基本価格を選択し、価格変更をスケジュールします。 これらのオプションを特定の市場向けにカスタマイズすることもできます。"
title: "アプリの価格の設定とスケジュール"
ms.author: wdg-dev-content
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 65d2fa64e4d442da42b8c546693c61eda817aa18
ms.sourcegitcommit: 968187e803a866b60cda0528718a3d31f07dc54c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/03/2017
---
# <a name="set-and-schedule-app-pricing"></a><span data-ttu-id="636d5-105">アプリの価格の設定とスケジュール</span><span class="sxs-lookup"><span data-stu-id="636d5-105">Set and schedule app pricing</span></span>

<span data-ttu-id="636d5-106">[[価格と使用可能状況]](set-app-pricing-and-availability.md) ページの **[価格設定]** セクションでは、アプリの基本価格を選択できます。</span><span class="sxs-lookup"><span data-stu-id="636d5-106">The **Pricing** section of the [Pricing and availability](set-app-pricing-and-availability.md) page lets you select the base price for an app.</span></span> <span data-ttu-id="636d5-107">[価格変更をスケジュール](#schedule-price-changes)して、アプリの価格を変更する日時を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="636d5-107">You can also [schedule price changes](#schedule-price-changes) to indicate the date and time at which your app’s price should change.</span></span> <span data-ttu-id="636d5-108">さらに、[これらの変更を特定の市場向けにカスタマイズ](#customize-pricing-for-specific-markets)することもできます。</span><span class="sxs-lookup"><span data-stu-id="636d5-108">Additionally, you have the option to [customize these changes for specific markets](#customize-pricing-for-specific-markets).</span></span> 

> [!NOTE]
> <span data-ttu-id="636d5-109">このトピックはアプリについて説明していますが、アドオンの申請の価格設定にも同じプロセスを使います。</span><span class="sxs-lookup"><span data-stu-id="636d5-109">Although this topic refers to apps, price selection for add-on submissions uses the same process.</span></span>

## <a name="base-price"></a><span data-ttu-id="636d5-110">基本価格</span><span class="sxs-lookup"><span data-stu-id="636d5-110">Base price</span></span>

<span data-ttu-id="636d5-111">アプリの **[基本価格]** を選ぶと、特定の市場向けにカスタムの価格を指定しない限り、その基本価格がアプリを販売するすべての市場で使われます。</span><span class="sxs-lookup"><span data-stu-id="636d5-111">When you select your app's **Base price**, that price will be used in every market where your app is sold, unless you specify a custom price for particular market(s).</span></span>

<span data-ttu-id="636d5-112">**[基本価格]** は、**[無料]** に設定するか、利用可能な価格帯から選択することができます。価格帯は、アプリの配布先となるすべての国での販売価格を設定するものです。</span><span class="sxs-lookup"><span data-stu-id="636d5-112">You can set the **Base price** to **Free**, or you can choose an available price tier, which sets the sales price in all the countries where you choose to distribute your app.</span></span> <span data-ttu-id="636d5-113">価格帯は、0.99 米ドルから始まり、増分を追加して段階的に上がっていきます (1.09 米ドル、1.19 米ドルなど)。</span><span class="sxs-lookup"><span data-stu-id="636d5-113">Price tiers start at .99 USD, with additional tiers available at increasing increments (1.09 USD, 1.19 USD, and so on).</span></span> <span data-ttu-id="636d5-114">価格が高くなるにつれ、増分も徐々に大きくなります。</span><span class="sxs-lookup"><span data-stu-id="636d5-114">The increments generally increase as the price gets higher.</span></span> 

> [!NOTE]
> <span data-ttu-id="636d5-115">これらの価格帯はアドオンにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="636d5-115">These price tiers also apply to add-ons.</span></span> 

<span data-ttu-id="636d5-116">各価格帯には、ストアで提供されている 60 を超える通貨それぞれに対応する値があります。</span><span class="sxs-lookup"><span data-stu-id="636d5-116">Each  price tier has a corresponding value in each of the more than 60 currencies offered by the Store.</span></span> <span data-ttu-id="636d5-117">これらの値は、世界中で同等の小売価格でアプリを販売するために使われます。</span><span class="sxs-lookup"><span data-stu-id="636d5-117">We use these values to help you sell your apps at a comparable price point worldwide.</span></span> <span data-ttu-id="636d5-118">基本価格は任意の通貨で選択でき、別の市場では対応する値が自動的に使われます。</span><span class="sxs-lookup"><span data-stu-id="636d5-118">You can select your base price in any currency, and we’ll automatically use the corresponding value for different markets.</span></span>

<span data-ttu-id="636d5-119">すべての通貨での対応する価格を確認するには、**[価格設定]** セクションで **[テーブルの表示]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="636d5-119">In the **Pricing** section, click **view table** to see the corresponding prices in all currencies.</span></span> <span data-ttu-id="636d5-120">これにより、各価格帯に関連付けられている ID 番号も表示されます。この ID は、[Windows ストア申請 API](../monetize/manage-app-submissions.md#price-tiers) を使って価格を入力する場合に必要になります。</span><span class="sxs-lookup"><span data-stu-id="636d5-120">This also displays an ID number associated with each price tier, which you’ll need if you're using the [Windows Store submission API](../monetize/manage-app-submissions.md#price-tiers) to enter prices.</span></span> <span data-ttu-id="636d5-121">**[ダウンロード]** をクリックすると、価格帯の表のコピーを .csv ファイルとしてダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="636d5-121">You can click **Download** to download a copy of the price tier table as a .csv file.</span></span>

<span data-ttu-id="636d5-122">選んだ価格帯には、ユーザーが支払う必要のある売上税や付加価値税が含まれている場合があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="636d5-122">Keep in mind that the price tier you select may include sales or value-added tax that your customers must pay.</span></span> <span data-ttu-id="636d5-123">選択した市場でのアプリの税について詳しくは、「[有料アプリの税金の詳細](tax-details-for-paid-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="636d5-123">To learn more about your app’s tax implications in selected markets, see [Tax details for paid apps](tax-details-for-paid-apps.md).</span></span> <span data-ttu-id="636d5-124">また、[特定の市場の価格に関する考慮事項](define-pricing-and-market-selection.md#price-considerations-for-specific-markets)も確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="636d5-124">You should also review the [price considerations for specific markets](define-pricing-and-market-selection.md#price-considerations-for-specific-markets).</span></span>

## <a name="schedule-price-changes"></a><span data-ttu-id="636d5-125">価格変更のスケジュール</span><span class="sxs-lookup"><span data-stu-id="636d5-125">Schedule price changes</span></span>

<span data-ttu-id="636d5-126">アプリの基本価格を特定の日時に変更する必要がある場合は、価格変更を 1 回以上スケジュールできます。</span><span class="sxs-lookup"><span data-stu-id="636d5-126">You can optionally schedule one or more price changes if you want the base price of your app to change at a specific date and time.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="636d5-127">価格変更は、Windows 10 のユーザーにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="636d5-127">Price changes are only shown to customers on Windows 10.</span></span> <span data-ttu-id="636d5-128">アプリが以前の OS バージョンをサポートしている場合、価格変更は適用されません。</span><span class="sxs-lookup"><span data-stu-id="636d5-128">If your app supports earlier OS versions, the price changes will not apply.</span></span> 
>
> - <span data-ttu-id="636d5-129">Windows 8 のユーザーに対しては、追加の価格変更をスケジュールしても、アプリは常に**基本価格**で提供されます (市場固有の価格も適用されません)。</span><span class="sxs-lookup"><span data-stu-id="636d5-129">For customers on Windows 8, the app will always be offered at its **Base price** (and not any market-specific price), even if you schedule additional price changes.</span></span> 
> - <span data-ttu-id="636d5-130">Windows 8.1 のユーザーと Windows Phone 8.1 以前のユーザーに対しては、該当する市場で追加の価格変更をスケジュールしても、アプリは常にユーザーの市場の初期価格で提供されます。</span><span class="sxs-lookup"><span data-stu-id="636d5-130">For customers on Windows 8.1, and on Windows Phone 8.1 and earlier, the app will always be offered at the initial price for the customer's market, even if you schedule additional price changes in that market.</span></span>
> 
> <span data-ttu-id="636d5-131">価格変更をスケジュールするときは、この点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="636d5-131">Keep this in mind when scheduling price changes.</span></span> <span data-ttu-id="636d5-132">たとえば、最初に低い価格でアプリをリリースし、その後で価格を上げる日付をスケジュールしても、以前の OS バージョンのユーザーがアプリを購入するときは、低い (最初の) 価格が適用されます。</span><span class="sxs-lookup"><span data-stu-id="636d5-132">For example, if you initially release your app at a lower price and then schedule a date on which the price should increase, you customers on earlier OS versions who purchase the app would pay the lower (original) price.</span></span>

<span data-ttu-id="636d5-133">価格変更のオプションを表示するには、**[価格変更のスケジュール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="636d5-133">Click **Schedule a price change** to see the price change options.</span></span> <span data-ttu-id="636d5-134">使用する価格帯を選び、日付、時刻、タイム ゾーンを選択します。</span><span class="sxs-lookup"><span data-stu-id="636d5-134">Choose the price tier you’d like to use, then select the date, time, and time zone.</span></span>

<span data-ttu-id="636d5-135">**[価格変更のスケジュール]** をもう一度クリックして、後続の変更を必要に応じて何度でもスケジュールできます。</span><span class="sxs-lookup"><span data-stu-id="636d5-135">You can click **Schedule a price change again** to schedule as many subsequent changes as you’d like.</span></span>

> [!NOTE]
> <span data-ttu-id="636d5-136">スケジュールされた価格変更は、[セール価格](put-apps-and-add-ons-on-sale.md)とは動作が異なります。</span><span class="sxs-lookup"><span data-stu-id="636d5-136">Scheduled price changes work differently from [Sale pricing](put-apps-and-add-ons-on-sale.md).</span></span> <span data-ttu-id="636d5-137">アプリのセールを開始すると、ストア登録情報を参照しているユーザーに価格が下がっていることが表示され、指定した期間中、ユーザーは割引価格でアプリを購入できるようになります。</span><span class="sxs-lookup"><span data-stu-id="636d5-137">When you put an app on sale, customers viewing your Store listing will see that the price has been reduced, and they'll be able to purchase it at the lower price during the time period that you have selected.</span></span> <span data-ttu-id="636d5-138">セール期間が終了すると、基本価格に戻ります。</span><span class="sxs-lookup"><span data-stu-id="636d5-138">After the sale period is up, it will return to the base price.</span></span>
>
> <span data-ttu-id="636d5-139">価格変更をスケジュールする場合は、価格を調整して高くすることも低くすることもできます。</span><span class="sxs-lookup"><span data-stu-id="636d5-139">With a scheduled price change, you can adjust the price to be either higher or lower.</span></span> <span data-ttu-id="636d5-140">変更は指定日に行われますが、ストアでセールとして表示されることはなく、アプリに新しい基本価格が設定されるだけです。</span><span class="sxs-lookup"><span data-stu-id="636d5-140">The change will take place on the date you specify, but it won’t be displayed as a sale in the Store; the app will just have a new base price.</span></span> 

## <a name="customize-pricing-for-specific-markets"></a><span data-ttu-id="636d5-141">特定の市場向けに価格をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="636d5-141">Customize pricing for specific markets</span></span>

<span data-ttu-id="636d5-142">既定では、上で選択したオプションは、アプリが提供されるすべての市場に適用されます。</span><span class="sxs-lookup"><span data-stu-id="636d5-142">By default, the options you select above will apply to all markets in which your app is offered.</span></span> <span data-ttu-id="636d5-143">特定の市場向けの価格をカスタマイズするには、**[特定の市場向けにカスタマイズする]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="636d5-143">To customize the price for specific markets, select **Customize for specific markets**.</span></span> <span data-ttu-id="636d5-144">**[市場の選択]** ポップアップ ウィンドウが開き、アプリの提供先として選択されているすべての市場の一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="636d5-144">The **Market selection** pop-up window will appear, listing all of the markets in which you’ve chosen to make your app available.</span></span> <span data-ttu-id="636d5-145">[市場] セクションで除外した市場がある場合、それらの市場は表示されません。</span><span class="sxs-lookup"><span data-stu-id="636d5-145">If you excluded any markets in the Markets section, those markets won't be shown here.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="636d5-146">Windows 8 のユーザーに対しては、該当する市場向けに別の価格を選択しても、アプリは常にその市場の**基本価格**で表示されます。</span><span class="sxs-lookup"><span data-stu-id="636d5-146">Customers on Windows 8 will always see the app at its **Base price**, even if you select a different price for their market.</span></span>

<span data-ttu-id="636d5-147">いずれかの市場向けにカスタマイズした価格を追加するには、市場を選択して **[保存]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="636d5-147">To add customize pricing for one market, select it and click **Save**.</span></span> <span data-ttu-id="636d5-148">上の説明と同じ **[基本価格]** と **[価格変更のスケジュール]** のオプションが表示されます。ただし、ここでの選択はその市場に固有になります。</span><span class="sxs-lookup"><span data-stu-id="636d5-148">You’ll then see the same **Base price** and **Schedule a price change** options as described above, but the selections you make will be specific to that market.</span></span>

<span data-ttu-id="636d5-149">複数の市場向けにカスタムの価格を追加するには、"市場グループ"** を作成します。</span><span class="sxs-lookup"><span data-stu-id="636d5-149">To add custom pricing for multiple markets, you’ll create a *market group*.</span></span> <span data-ttu-id="636d5-150">これを行うには、グループに含める市場を選択し、グループの名前を入力します </span><span class="sxs-lookup"><span data-stu-id="636d5-150">To do so, select the markets you wish to include, then enter a name for the group.</span></span> <span data-ttu-id="636d5-151">(この名前は参照用に使われるだけで、ユーザーには表示されません)。完了したら、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="636d5-151">(This name is for your reference only and won’t be visible to any customers.) When you’re finished, click **Save**.</span></span> <span data-ttu-id="636d5-152">上の説明と同じ **[基本価格]** と **[価格変更のスケジュール]** のオプションが表示されます。ただし、ここでの選択はその市場グループに固有になります。</span><span class="sxs-lookup"><span data-stu-id="636d5-152">You’ll then see the same **Base price** and **Schedule a price change** options as described above, but the selections you make will be specific to that market group.</span></span>

> [!NOTE]
> <span data-ttu-id="636d5-153">1 つの市場を、[価格設定] セクションで使う複数の市場グループに含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="636d5-153">A market can’t belong to more than one of the market groups you use in the Pricing section.</span></span>

<span data-ttu-id="636d5-154">さらに他の市場または市場グループ向けにカスタムの価格を追加するには、もう一度 **[特定の市場向けにカスタマイズする]** を選択し、これらの手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="636d5-154">To add custom pricing for an additional market, or an additional market group, select **Customize for specific markets** again and repeat these steps.</span></span> <span data-ttu-id="636d5-155">市場グループに含まれている市場を変更するには、その名前を選択します。</span><span class="sxs-lookup"><span data-stu-id="636d5-155">To change the markets included in a market group, select its name.</span></span> <span data-ttu-id="636d5-156">市場グループ (または個別の市場) 向けの価格を削除するには、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="636d5-156">To remove the pricing for a market group (or individual market), click **Remove**.</span></span>



