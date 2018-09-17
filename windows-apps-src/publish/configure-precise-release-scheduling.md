---
author: jnHs
Description: You can set the precise date and time that your app should become available in the Store, giving you greater flexibility and the ability to customize dates for different markets.
title: 正確なリリース スケジュールの構成
ms.author: wdg-dev-content
ms.date: 05/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, スケジュール, リリース日, 日付, 公開
ms.localizationpriority: medium
ms.openlocfilehash: 84466f907bad7e38506e1bf81b89eb631675093c
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3990095"
---
# <a name="configure-precise-release-scheduling"></a><span data-ttu-id="1629f-103">正確なリリース スケジュールの構成</span><span class="sxs-lookup"><span data-stu-id="1629f-103">Configure precise release scheduling</span></span>

<span data-ttu-id="1629f-104">[[価格および使用可能状況]](set-app-pricing-and-availability.md) ページの **[スケジュール]** セクションでは、アプリをストアで利用可能にする正確な日付と時刻を設定でき、市場ごとに日付を柔軟にカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="1629f-104">The **Schedule** section on the [Pricing and availability](set-app-pricing-and-availability.md) page lets you set the precise date and time that your app should become available in the Store, giving you greater flexibility and the ability to customize dates for different markets.</span></span>

> [!NOTE]
> <span data-ttu-id="1629f-105">このトピックはアプリについて説明していますが、アドオンのリリース スケジュールにも同じプロセスを使います。</span><span class="sxs-lookup"><span data-stu-id="1629f-105">Although this topic refers to apps, release scheduling for add-on submissions uses the same process.</span></span>

<span data-ttu-id="1629f-106">さらに、ストアでの製品の公開を終了する日付を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="1629f-106">You can additionally opt to set a date when the product should no longer be available in the Store.</span></span> <span data-ttu-id="1629f-107">この場合、ストアの検索や参照によって製品を見つけることはできなくなりますが、直接リンクを知っているユーザーであれば、製品のストア登録情報を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="1629f-107">Note that this means that the product can no longer be found in the Store via searching or browsing, but any customer with a direct link can see the product's Store listing.</span></span> <span data-ttu-id="1629f-108">製品をダウンロードできるのは、その製品を既に所有しているか、[プロモーション コード](generate-promotional-codes.md)を持っていて、かつ Windows 10 デバイスを使っている場合だけです。</span><span class="sxs-lookup"><span data-stu-id="1629f-108">They can only download it if they already own the product or if they have a [promotional code](generate-promotional-codes.md) and are using a Windows 10 device.</span></span>

<span data-ttu-id="1629f-109">既定では ([[表示]](choose-visibility-options.md#discoverability) セクションで **[この製品をストアで提供しますが、検索はできないようにします]** のオプションのいずれかを選択した場合を除き)、アプリが認定に合格して公開プロセスが完了すると、そのアプリはすぐにユーザーが利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="1629f-109">By default (unless you have selected one of the **Make this app available but not discoverable in the Store** options in the [Visibility](choose-visibility-options.md#discoverability) section), your app will be available to customers as soon as it passes certification and complete the publishing process.</span></span> <span data-ttu-id="1629f-110">他の日付を選択するには、**[オプションの表示]** を選択してこのセクションを展開します。</span><span class="sxs-lookup"><span data-stu-id="1629f-110">To choose other dates, select **Show options** to expand this section.</span></span>

<span data-ttu-id="1629f-111">[[表示]](choose-visibility-options.md#discoverability) セクションで **[この製品をストアで提供しますが、検索はできないようにします]** のオプションのいずれかを選択した場合、**[スケジュール]** セクションで日付を構成することはできません。この場合、アプリはユーザーにリリースされず、構成するリリース日が存在しないためです。</span><span class="sxs-lookup"><span data-stu-id="1629f-111">Note that you won't be able to configure dates in the **Schedule** section if you have selected one of the **Make this app available but not discoverable in the Store** options in the [Visibility](choose-visibility-options.md#discoverability) section, because your app won't be released to customers, so there is no release date to configure.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="1629f-112">[スケジュール] セクションで指定した日付は、Windows 10 のユーザーにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="1629f-112">The dates you specify in the Schedule section only apply to customers on Windows 10.</span></span>
>
><span data-ttu-id="1629f-113">アプリが以前の OS バージョンをサポートしている場合は、アプリが認定に合格して公開プロセスが完了すると、選択したリリース日を過ぎていなくても、該当する OS バージョンのユーザーはそのアプリの登録情報を参照できるようになります。</span><span class="sxs-lookup"><span data-stu-id="1629f-113">If your app supports earlier OS versions, customers on those OS versions will see your app’s listing as soon as it passes certification and completes the publishing process, even if you have selected a later release date.</span></span> <span data-ttu-id="1629f-114">これらのユーザーには、選択した **[購入の停止]** の日付も一切適用されません。これらのユーザーは、([[表示]](choose-visibility-options.md#discoverability) セクションで新しい設定を選択して更新を申請した場合、または **[アプリの概要]** ページで **[アプリの提供を停止する]** を選択した場合を除いて) 引き続きアプリを入手できます。</span><span class="sxs-lookup"><span data-stu-id="1629f-114">Any **Stop acquisition** date you select will not apply to those customers; they will still be able to acquire the app (unless you submit an update with a new selection in the [Visibility](choose-visibility-options.md#discoverability) section, or if you select **Make app unavailable** from the **App overview** page).</span></span>


## <a name="base-schedule"></a><span data-ttu-id="1629f-115">基本スケジュール</span><span class="sxs-lookup"><span data-stu-id="1629f-115">Base schedule</span></span>

<span data-ttu-id="1629f-116">[基本スケジュール] で選択した設定は、後で [[特定の市場向けにカスタマイズする]](#customize-the-schedule-for-specific-markets) を選択して特定の市場 (または市場グループ) 向けの日付を指定しない限り、アプリを提供するすべての市場に適用されます。</span><span class="sxs-lookup"><span data-stu-id="1629f-116">Selections you make for the Base schedule will apply to all markets in which your app is available, unless you later add dates for specific markets (or market groups) by selecting [Customize for specific markets](#customize-the-schedule-for-specific-markets).</span></span>

<span data-ttu-id="1629f-117">ここには、**[リリース]** と **[購入の停止]** の 2 つのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="1629f-117">You’ll see two options here: **Release** and **Stop acquisition**.</span></span> 

## <a name="release"></a><span data-ttu-id="1629f-118">リリース</span><span class="sxs-lookup"><span data-stu-id="1629f-118">Release</span></span>

<span data-ttu-id="1629f-119">**[リリース]** ドロップダウンでは、アプリをストアで利用可能にする日付を設定できます。</span><span class="sxs-lookup"><span data-stu-id="1629f-119">In the **Release** drop-down, you can set when you want your app to be available in the Store.</span></span> <span data-ttu-id="1629f-120">つまり、アプリはストアの検索や参照によって見つけることができ、ユーザーはストア登録情報を表示してアプリを入手できます。</span><span class="sxs-lookup"><span data-stu-id="1629f-120">This means that the app is discoverable in the Store via searching or browsing, and that customers can view its Store listing and acquire the app.</span></span>

>[!NOTE]
> <span data-ttu-id="1629f-121">アプリが公開され、ストアで利用可能になった後は、**[リリース]** の日付を選択することはできません (既にアプリがリリースされているため)。</span><span class="sxs-lookup"><span data-stu-id="1629f-121">After your app has been published and has become available in the Store, you will no longer be able to select a **Release** date (since the app will already have been released).</span></span>

<span data-ttu-id="1629f-122">製品の **[リリース]** スケジュールに関して構成できるオプションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="1629f-122">Here are the options you can configure for a product’s **Release** schedule:</span></span>
- <span data-ttu-id="1629f-123">**[できるだけ早く]**: 製品は、認定されて公開されるとすぐにリリースされます。</span><span class="sxs-lookup"><span data-stu-id="1629f-123">**as soon as possible**: The product will release as soon as it is certified and published.</span></span> <span data-ttu-id="1629f-124">これは既定のオプションです。</span><span class="sxs-lookup"><span data-stu-id="1629f-124">This is the default option.</span></span>
- <span data-ttu-id="1629f-125">**[次の時点]**: 製品は、選択した日時にリリースされます。</span><span class="sxs-lookup"><span data-stu-id="1629f-125">**at**: The product will release on the date and time that you select.</span></span> <span data-ttu-id="1629f-126">次の 2 つの追加オプションがあります。</span><span class="sxs-lookup"><span data-stu-id="1629f-126">You additionally have two options:</span></span>
   - <span data-ttu-id="1629f-127">**[UTC]**: 選択した時刻は世界標準時 (UTC) です。アプリはすべての市場で同時にリリースされます。</span><span class="sxs-lookup"><span data-stu-id="1629f-127">**UTC**: The time you select will be Universal Coordinated Time (UTC) time, so that the app releases at the same time everywhere.</span></span>
   - <span data-ttu-id="1629f-128">**[ローカル]**: 選択した時刻は、市場に関連付けられている各タイム ゾーンの時刻として扱われます </span><span class="sxs-lookup"><span data-stu-id="1629f-128">**Local**: The time you select will be the used in each time zone associated with a market.</span></span> <span data-ttu-id="1629f-129">(複数のタイム ゾーンがある市場では、その市場のタイム ゾーンの 1 つだけが使われます。</span><span class="sxs-lookup"><span data-stu-id="1629f-129">(Note that for markets that include more than one time zone, only one time zone in that market will be used.</span></span> <span data-ttu-id="1629f-130">米国の場合は東部標準時が使われます)。</span><span class="sxs-lookup"><span data-stu-id="1629f-130">For the United States, the Eastern time zone is used.)</span></span>
- <span data-ttu-id="1629f-131">**[スケジュールされていません]**: アプリはストアで利用可能になりません。</span><span class="sxs-lookup"><span data-stu-id="1629f-131">**not scheduled**: The app will not be available in the Store.</span></span> <span data-ttu-id="1629f-132">このオプションを選択した場合は、後からアプリをストアで利用可能にすることができます。利用可能にするには、新しい申請を作成するか、他のいずれかのオプションを選択します。</span><span class="sxs-lookup"><span data-stu-id="1629f-132">If you choose this option, you can make the app available in the Store later by creating a new submission and choosing one of the other options.</span></span>


## <a name="stop-acquisition"></a><span data-ttu-id="1629f-133">購入の停止</span><span class="sxs-lookup"><span data-stu-id="1629f-133">Stop acquisition</span></span>

<span data-ttu-id="1629f-134">**[購入の停止]** ドロップダウンでは、新しいユーザーがストアからアプリを入手したり、登録情報を見つけたりできないようにする日時を設定できます。</span><span class="sxs-lookup"><span data-stu-id="1629f-134">In the **Stop acquisition** dropdown, you can set a date and time when you want to stop allowing new customers to acquire it from the Store or discover its listing.</span></span> <span data-ttu-id="1629f-135">これは、複数のアプリ間で使用可能状況を調整している場合など、新しいユーザーへのアプリの提供を終了する時期を正確に制御する場合に役立つ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1629f-135">This can be useful if you want to precisely control when an app will no longer be offered to new customers, such as when you are coordinating availability between more than one of your apps.</span></span>

<span data-ttu-id="1629f-136">既定では、**[購入の停止]** は [実行しない] に設定されます。</span><span class="sxs-lookup"><span data-stu-id="1629f-136">By default, **Stop acquisition** is set to never.</span></span> <span data-ttu-id="1629f-137">これを変更するには、ドロップダウンの **[次の時点]** を選択し、上で説明したように日付と時刻を指定します。</span><span class="sxs-lookup"><span data-stu-id="1629f-137">To change this, select **at** in the drop-down and specify a date and time, as described above.</span></span> <span data-ttu-id="1629f-138">選択した日時になると、ユーザーはアプリを入手できなくなります。</span><span class="sxs-lookup"><span data-stu-id="1629f-138">At the date and time you select, customers will no longer be able to acquire the app.</span></span>

<span data-ttu-id="1629f-139">重要な点として、このオプションには、[[表示]](choose-visibility-options.md#discoverability) セクションで **[この製品をストアで提供しますが、検索はできないようにします]** を選択し、**[購入の停止: 直接リンクを知っているユーザーは製品のストア登録情報を表示できます。ただし、製品をダウンロードできるのは、以前にその製品を所有していたか、またはプロモーション コードを持っている場合で、かつ Windows 10 デバイスを使用している場合のみです。]** を選択した場合と同じ効果があります。</span><span class="sxs-lookup"><span data-stu-id="1629f-139">It's important to understand that this option has the same impact as selecting **Make this app discoverable but not available** in the [Visibility](choose-visibility-options.md#discoverability) section and choosing **Stop acquisition: Any customer with a direct link can see the product’s Store listing, but they can only download it if they owned the product before or have a promotional code and are using a Windows 10 device.**</span></span> <span data-ttu-id="1629f-140">新しいユーザーへのアプリの提供を完全に停止するには、[アプリの概要] ページで **[アプリの提供を停止する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="1629f-140">To completely stop offering an app to new customers, click **Make app unavailable** from the App overview page.</span></span> <span data-ttu-id="1629f-141">詳しくは、「[アプリをストアから削除する](guidance-for-app-package-management.md#removing-an-app-from-the-store)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1629f-141">For more info, see [Removing an app from the Store](guidance-for-app-package-management.md#removing-an-app-from-the-store).</span></span>

> [!TIP]
> <span data-ttu-id="1629f-142">**[購入の停止]** で日付を選択し、後からもう一度アプリを提供することにした場合は、新しい申請を作成して、**[購入の停止]** を **[実行しない]** に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="1629f-142">If you select a date to **Stop acquisition**, and later decide you'd like to make the app available again, you can create a new submission and change **Stop acquisition** back to **Never**.</span></span> <span data-ttu-id="1629f-143">更新された申請が公開されると、アプリが再び利用可能になります。</span><span class="sxs-lookup"><span data-stu-id="1629f-143">The app will become available again after your updated submission is published.</span></span>

## <a name="customize-the-schedule-for-specific-markets"></a><span data-ttu-id="1629f-144">特定の市場向けにスケジュールをカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="1629f-144">Customize the schedule for specific markets</span></span> 

<span data-ttu-id="1629f-145">既定では、上で選択したオプションは、アプリが提供されるすべての市場に適用されます。</span><span class="sxs-lookup"><span data-stu-id="1629f-145">By default, the options you select above will apply to all markets in which your app is offered.</span></span> <span data-ttu-id="1629f-146">特定の市場向けのスケジュールをカスタマイズするには、**[特定の市場向けにカスタマイズする]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="1629f-146">To customize the price for specific markets, click **Customize for specific markets**.</span></span> <span data-ttu-id="1629f-147">**[市場の選択]** ポップアップ ウィンドウが開き、アプリの提供先として選択されているすべての市場の一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="1629f-147">The **Market selection** pop-up window will appear, listing all of the markets in which you’ve chosen to make your app available.</span></span> <span data-ttu-id="1629f-148">[[市場]](define-pricing-and-market-selection.md) セクションで除外した市場がある場合、それらの市場は表示されません。</span><span class="sxs-lookup"><span data-stu-id="1629f-148">If you excluded any markets in the [Markets](define-pricing-and-market-selection.md) section, those markets will not be shown.</span></span> 

<span data-ttu-id="1629f-149">1 つの市場向けのスケジュールを追加する場合は、その市場を選択して **[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="1629f-149">To add a schedule for one market, select it and click **Save**.</span></span> <span data-ttu-id="1629f-150">上の説明と同じ **[リリース]** と **[購入の停止]** のオプションが表示されます。ただし、ここでの選択はその市場にのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="1629f-150">You’ll then see the same **Release** and **Stop acquisition** options described above, but the selections you make will only apply to that market.</span></span>

<span data-ttu-id="1629f-151">複数の市場に適用するスケジュールを追加するには、"市場グループ"\*\* を作成します。</span><span class="sxs-lookup"><span data-stu-id="1629f-151">To add a schedule that will apply to multiple markets, you’ll create a *market group*.</span></span> <span data-ttu-id="1629f-152">これを行うには、グループに含める市場を選択し、グループの名前を入力します </span><span class="sxs-lookup"><span data-stu-id="1629f-152">To do so, select the markets you wish to include, then enter a name for the group.</span></span> <span data-ttu-id="1629f-153">(この名前は参照用に使われるだけで、ユーザーには表示されません)。たとえば、北米の市場グループを作成する場合は、**[カナダ]**、**[メキシコ]**、**[米国]** を選択し、「**北米**」などの任意の名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="1629f-153">(This name is for your reference only and won’t be visible to any customers.) For example, if you want to create a market group for North America, you can select **Canada**, **Mexico**, and **United States**, and name it **North America** or another name that you choose.</span></span> <span data-ttu-id="1629f-154">市場グループの作成が完了したら、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="1629f-154">When you’re finished creating your market group, click **Save**.</span></span> <span data-ttu-id="1629f-155">上の説明と同じ **[リリース]** と **[購入の停止]** オプションが表示されます。ただし、ここでの選択はその市場グループにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="1629f-155">You’ll then see the same **Release** and **Stop acquisition** options described above, but the selections you make will only apply to that market group.</span></span>

<span data-ttu-id="1629f-156">さらに他の市場または市場グループ向けにカスタム スケジュールを追加するには、もう一度 **[特定の市場向けにカスタマイズする]** をクリックし、これらの手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="1629f-156">To add a custom schedule for an additional market, or an additional market group, just click **Customize for specific markets** again and repeat these steps.</span></span> <span data-ttu-id="1629f-157">市場グループに含まれている市場を変更するには、その名前を選択します。</span><span class="sxs-lookup"><span data-stu-id="1629f-157">To change the markets included in a market group, select its name.</span></span> <span data-ttu-id="1629f-158">市場グループ (または個別の市場) 向けのカスタム スケジュールを削除するには、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="1629f-158">To remove the custom schedule for a market group (or individual market), click **Remove**.</span></span>

> [!NOTE]
> <span data-ttu-id="1629f-159">1 つの市場を、**[スケジュール]** セクションで使う複数の市場グループに含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="1629f-159">A market can’t belong to more than one of the market groups you use in the **Schedule** section.</span></span> 










