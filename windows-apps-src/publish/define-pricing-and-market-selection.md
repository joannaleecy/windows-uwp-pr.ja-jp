---
author: jnHs
Description: The Microsoft Store reaches customers in over 200 countries and regions around the world.
title: 市場の選択の定義
ms.assetid: FBE7507B-DBF3-4FCB-8377-DB01660E75F8
ms.author: wdg-dev-content
ms.date: 06/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 市場, 国, 地域
ms.localizationpriority: medium
ms.openlocfilehash: dd8cdb1f69a9a8a73700483f04d17f64de337347
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4390307"
---
# <a name="define-market-selection"></a><span data-ttu-id="0ce28-103">市場の選択の定義</span><span class="sxs-lookup"><span data-stu-id="0ce28-103">Define market selection</span></span>


<span data-ttu-id="0ce28-104">Microsoft Store は、世界中の 200 以上の国と地域のお客様が利用できます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-104">The Microsoft Store reaches customers in over 200 countries and regions around the world.</span></span> <span data-ttu-id="0ce28-105">アプリを提供する市場を選択して、市場ごとまたは市場のグループごとに、[価格と使用可能状況](set-app-pricing-and-availability.md)の多くの機能をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-105">You can choose the markets in which you'd like to offer your app, with the option to customize many [pricing and availability](set-app-pricing-and-availability.md) features per market or per group of markets.</span></span>

<span data-ttu-id="0ce28-106">やすく、アプリのユーザーに適した、世界中には、[グローバリゼーションのガイドライン](../design/globalizing/guidelines-and-checklist-for-globalizing-your-app.md)と[ローカライズ可能なアプリ](../design/globalizing/prepare-your-app-for-localization.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0ce28-106">For info to help make your app suitable for customers around the world, see [Guidelines for globalization](../design/globalizing/guidelines-and-checklist-for-globalizing-your-app.md) and [Make your app localizable](../design/globalizing/prepare-your-app-for-localization.md).</span></span>

> [!NOTE]
> <span data-ttu-id="0ce28-107">このトピックはアプリについて説明していますが、アドオンの市場の選択にも同じプロセスを使います。</span><span class="sxs-lookup"><span data-stu-id="0ce28-107">Although this topic refers to apps, market selection for add-on submissions uses the same process.</span></span>

## <a name="markets"></a><span data-ttu-id="0ce28-108">市場</span><span class="sxs-lookup"><span data-stu-id="0ce28-108">Markets</span></span>

<span data-ttu-id="0ce28-109">既定では、アプリは販売できるすべての市場 (今後追加される可能性のある市場も含む) にその基本価格で公開されます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-109">By default, we'll offer your app in all possible markets, including any future markets that we may add later, at its base price.</span></span>

<span data-ttu-id="0ce28-110">必要に応じて、アプリを提供する特定の市場を定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-110">If you prefer, you can define the specific markets in which you'd like to offer your app.</span></span> <span data-ttu-id="0ce28-111">これを行うには、**[価格と使用可能状況]** ページの **[市場]** セクションで **[オプションの表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="0ce28-111">To do so, select **Show options** in the **Markets** section on the **Pricing and availability** page.</span></span> <span data-ttu-id="0ce28-112">**[市場の選択]** ポップアップ ウィンドウが表示されます。ここで、アプリを提供する市場を選択できます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-112">This will display the **Market selection** popup window, where you can choose the markets in which to offer your app.</span></span>

<span data-ttu-id="0ce28-113">既定では、すべての市場が選択されています。</span><span class="sxs-lookup"><span data-stu-id="0ce28-113">By default, all markets are selected.</span></span> <span data-ttu-id="0ce28-114">市場を 1 つずつ選択解除して除外するか、**[すべて選択解除]** をクリックしてから、必要な市場を 1 つずつ選んで追加できます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-114">You can unselect individual markets to exclude them, or you can click **Unselect all** and then add individual markets of your choice.</span></span> <span data-ttu-id="0ce28-115">検索バーで特定の市場を検索できます。また、ドロップダウンを **[すべての市場]** から **[Xbox の市場]** に変更すると、Xbox 向けの製品を販売できる市場だけを表示できます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-115">You can search for a particular market in the search bar, and you can also change the dropdown from **All markets** to **Xbox markets** if you only want to view the markets in which you can sell Xbox products.</span></span> <span data-ttu-id="0ce28-116">完了したら、**[OK]** をクリックして選択を保存します。</span><span class="sxs-lookup"><span data-stu-id="0ce28-116">Once you’ve finished, click **OK** to save your selections.</span></span>

<span data-ttu-id="0ce28-117">ここで選択した設定は、新規にアプリを入手するユーザーにのみ適用されます。特定の市場でユーザーが既にアプリを入手している場合、後でその市場からアプリを削除しても、既にアプリを所有しているユーザーは引き続きアプリを使うことができます。ただし、今後提出される更新プログラムを受け取ることはできず、その市場で新規ユーザーがアプリを入手することもできません。</span><span class="sxs-lookup"><span data-stu-id="0ce28-117">Note that your selections here apply only to new acquisitions; if someone already has your app in a certain market, and you later remove that market, the people who already have the app in that market can continue to use it, but they won’t get the updates you submit, and no new customers in that market can get your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="0ce28-118">開発者には、それぞれの国または地域の法的要件をすべて満たす責任があります。これは、それらの要件がこのドキュメントや Windows デベロッパー センター ダッシュボードに記載されていなくても同様です。</span><span class="sxs-lookup"><span data-stu-id="0ce28-118">It is your responsibility to meet any local legal requirements, even if those requirements aren't listed here or in the Windows Dev Center dashboard.</span></span>

<span data-ttu-id="0ce28-119">すべての市場を選んだ場合でも、現地の法律、規制、またはその他の要因により、特定のアプリが一部の国と地域に公開されないことがあります。</span><span class="sxs-lookup"><span data-stu-id="0ce28-119">Keep in mind that even if you select all markets, local laws and restrictions or other factors may prevent certain apps from being listed in some countries and regions.</span></span> <span data-ttu-id="0ce28-120">また、一部の市場には年齢区分に関する特定の要件が存在することがあります。</span><span class="sxs-lookup"><span data-stu-id="0ce28-120">Also, some markets may have specific requirements related to age ratings.</span></span> <span data-ttu-id="0ce28-121">アプリがこれらの要件を満たしていない場合、その市場でアプリを提供できなくなります。</span><span class="sxs-lookup"><span data-stu-id="0ce28-121">If your app doesn’t meet these requirements, we won't be able to offer your app in that market.</span></span> <span data-ttu-id="0ce28-122">詳しくは、「[年齢区分](age-ratings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ce28-122">See [Age ratings](age-ratings.md) for more info.</span></span>

> [!NOTE]
> <span data-ttu-id="0ce28-123">Windows 8 または Windows 8.1 をターゲットとするアプリでは、いくつかの個別の市場が 1 つの "その他の国と地域" 市場として扱われます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-123">For apps targeting Windows 8 or Windows 8.1, some individual markets are treated as one single "Rest of World" market.</span></span> <span data-ttu-id="0ce28-124">詳しくは、「[Windows 8.x の "その他の国と地域" 市場](#rest-of-world-markets-for-windows-8x)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ce28-124">For more info, see ["Rest of World" markets for Windows 8.x](#rest-of-world-markets-for-windows-8x).</span></span>

<span data-ttu-id="0ce28-125">また、今後ストアに追加される市場にアプリを提供するかどうかを指定するチェック ボックスも用意されています。</span><span class="sxs-lookup"><span data-stu-id="0ce28-125">You will also see a checkbox that lets you indicate whether to offer your app in any market that the Store may add in the future.</span></span> <span data-ttu-id="0ce28-126">このチェック ボックスをオンにしておくと、後で新しい市場が追加されたときに、申請時に指定したアプリの基本価格と一般公開日がそれらの市場で使われます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-126">If you leave this box checked, and we later add new markets, the base price and general availability date for your submission will be used for your app in those markets.</span></span> <span data-ttu-id="0ce28-127">これを避けるには、このチェック ボックスをオフにすると、今後追加される市場でアプリが公開されることはなくなります (後でいつでもアプリを追加できます)。</span><span class="sxs-lookup"><span data-stu-id="0ce28-127">If you don't want this to happen, you can uncheck this box, in which case we will not list your app in any future markets (though you can always add them later).</span></span>
 

## <a name="microsoft-store-consumer-markets"></a><span data-ttu-id="0ce28-128">Microsoft ストアのユーザー市場</span><span class="sxs-lookup"><span data-stu-id="0ce28-128">Microsoft Store consumer markets</span></span>

<span data-ttu-id="0ce28-129">以下に挙げる市場の中から、アプリ (またはアドオン) を公開する市場を 1 つ以上選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-129">You can choose to list your app (or add-on) in one or more of the following markets.</span></span> <span data-ttu-id="0ce28-130">アスタリスクで市場 Xbox one では、Microsoft Store のサポートします。**Xbox**は、**市場の選択**は、ポップアップ ウィンドウで、名前の横に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-130">The markets with an asterisk support the Microsoft Store on Xbox One; you'll see **Xbox** next to their names in the **Market selection** popup window.</span></span>


<table>
  
  <tr>
    <td><span data-ttu-id="0ce28-131">アフガニスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-131">Afghanistan</span></span></td>
    <td><span data-ttu-id="0ce28-132">オーランド諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-132">Åland Islands</span></span></td>
    <td><span data-ttu-id="0ce28-133">アルバニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-133">Albania</span></span></td>
    <td><span data-ttu-id="0ce28-134">アルジェリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-134">Algeria</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-135">米領サモア</span><span class="sxs-lookup"><span data-stu-id="0ce28-135">American Samoa</span></span></td>
    <td><span data-ttu-id="0ce28-136">アンドラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-136">Andorra</span></span></td>
    <td><span data-ttu-id="0ce28-137">アンゴラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-137">Angola</span></span></td>
    <td><span data-ttu-id="0ce28-138">アンギラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-138">Anguilla</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-139">南極</span><span class="sxs-lookup"><span data-stu-id="0ce28-139">Antarctica</span></span></td>
    <td><span data-ttu-id="0ce28-140">アンティグア・バーブーダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-140">Antigua and Barbuda</span></span></td>
    <td><span data-ttu-id="0ce28-141">アルゼンチン</span><span class="sxs-lookup"><span data-stu-id="0ce28-141">Argentina</span></span></td>
    <td><span data-ttu-id="0ce28-142">アルメニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-142">Armenia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-143">アルバ</span><span class="sxs-lookup"><span data-stu-id="0ce28-143">Aruba</span></span></td>
    <td><span data-ttu-id="0ce28-144">オーストラリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-144">Australia</span></span></td>
    <td><span data-ttu-id="0ce28-145">オーストリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-145">Austria</span></span></td>
    <td><span data-ttu-id="0ce28-146">アゼルバイジャン</span><span class="sxs-lookup"><span data-stu-id="0ce28-146">Azerbaijan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-147">バハマ</span><span class="sxs-lookup"><span data-stu-id="0ce28-147">Bahamas</span></span></td>
    <td><span data-ttu-id="0ce28-148">バーレーン</span><span class="sxs-lookup"><span data-stu-id="0ce28-148">Bahrain</span></span></td>
    <td><span data-ttu-id="0ce28-149">バングラデシュ</span><span class="sxs-lookup"><span data-stu-id="0ce28-149">Bangladesh</span></span></td>
    <td><span data-ttu-id="0ce28-150">バルバドス</span><span class="sxs-lookup"><span data-stu-id="0ce28-150">Barbados</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-151">ベラルーシ</span><span class="sxs-lookup"><span data-stu-id="0ce28-151">Belarus</span></span></td>
    <td><span data-ttu-id="0ce28-152">ベルギー</span><span class="sxs-lookup"><span data-stu-id="0ce28-152">Belgium</span></span></td>
    <td><span data-ttu-id="0ce28-153">ベリーズ</span><span class="sxs-lookup"><span data-stu-id="0ce28-153">Belize</span></span></td>
    <td><span data-ttu-id="0ce28-154">ベナン</span><span class="sxs-lookup"><span data-stu-id="0ce28-154">Benin</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-155">バミューダ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-155">Bermuda</span></span></td>
    <td><span data-ttu-id="0ce28-156">ブータン</span><span class="sxs-lookup"><span data-stu-id="0ce28-156">Bhutan</span></span></td>
    <td><span data-ttu-id="0ce28-157">ボリビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-157">Bolivia</span></span></td>
    <td><span data-ttu-id="0ce28-158">ボネール島</span><span class="sxs-lookup"><span data-stu-id="0ce28-158">Bonaire</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-159">ボスニア・ヘルツェゴビナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-159">Bosnia and Herzegovina</span></span></td>
    <td><span data-ttu-id="0ce28-160">ボツワナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-160">Botswana</span></span></td>
    <td><span data-ttu-id="0ce28-161">ブーベ島</span><span class="sxs-lookup"><span data-stu-id="0ce28-161">Bouvet Island</span></span></td>
    <td><span data-ttu-id="0ce28-162">ブラジル</span><span class="sxs-lookup"><span data-stu-id="0ce28-162">Brazil</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-163">英領インド洋地域</span><span class="sxs-lookup"><span data-stu-id="0ce28-163">British Indian Ocean Territory</span></span></td>
    <td><span data-ttu-id="0ce28-164">英領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-164">British Virgin Islands</span></span></td>
    <td><span data-ttu-id="0ce28-165">ブルネイ</span><span class="sxs-lookup"><span data-stu-id="0ce28-165">Brunei</span></span></td>
    <td><span data-ttu-id="0ce28-166">ブルガリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-166">Bulgaria</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-167">ブルキナファソ</span><span class="sxs-lookup"><span data-stu-id="0ce28-167">Burkina Faso</span></span></td>
    <td><span data-ttu-id="0ce28-168">ブルンジ</span><span class="sxs-lookup"><span data-stu-id="0ce28-168">Burundi</span></span></td>
    <td><span data-ttu-id="0ce28-169">カーボベルデ</span><span class="sxs-lookup"><span data-stu-id="0ce28-169">Cabo Verde</span></span></td>
    <td><span data-ttu-id="0ce28-170">カンボジア</span><span class="sxs-lookup"><span data-stu-id="0ce28-170">Cambodia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-171">カメルーン</span><span class="sxs-lookup"><span data-stu-id="0ce28-171">Cameroon</span></span></td>
    <td><span data-ttu-id="0ce28-172">カナダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-172">Canada</span></span></td>
    <td><span data-ttu-id="0ce28-173">ケイマン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-173">Cayman Islands</span></span></td>
    <td><span data-ttu-id="0ce28-174">中央アフリカ共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-174">Central African Republic</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-175">チャド</span><span class="sxs-lookup"><span data-stu-id="0ce28-175">Chad</span></span></td>
    <td><span data-ttu-id="0ce28-176">チリ</span><span class="sxs-lookup"><span data-stu-id="0ce28-176">Chile</span></span></td>
    <td><span data-ttu-id="0ce28-177">中国</span><span class="sxs-lookup"><span data-stu-id="0ce28-177">China</span></span></td>
    <td><span data-ttu-id="0ce28-178">クリスマス島</span><span class="sxs-lookup"><span data-stu-id="0ce28-178">Christmas Island</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-179">ココス諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-179">Cocos (Keeling) Islands</span></span></td>
    <td><span data-ttu-id="0ce28-180">コロンビア \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-180">Colombia \*</span></span></td>
    <td><span data-ttu-id="0ce28-181">コモロ</span><span class="sxs-lookup"><span data-stu-id="0ce28-181">Comoros</span></span></td>
    <td><span data-ttu-id="0ce28-182">コンゴ共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-182">Congo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-183">コンゴ民主共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-183">Congo (DRC)</span></span></td>
    <td><span data-ttu-id="0ce28-184">クック諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-184">Cook Islands</span></span></td>
    <td><span data-ttu-id="0ce28-185">コスタリカ</span><span class="sxs-lookup"><span data-stu-id="0ce28-185">Costa Rica</span></span></td>
    <td><span data-ttu-id="0ce28-186">コートジボワール</span><span class="sxs-lookup"><span data-stu-id="0ce28-186">Côte d’Ivoire</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-187">クロアチア</span><span class="sxs-lookup"><span data-stu-id="0ce28-187">Croatia</span></span></td>
    <td><span data-ttu-id="0ce28-188">キュラソー島</span><span class="sxs-lookup"><span data-stu-id="0ce28-188">Curaçao</span></span></td>
    <td><span data-ttu-id="0ce28-189">キプロス</span><span class="sxs-lookup"><span data-stu-id="0ce28-189">Cyprus</span></span></td>
    <td><span data-ttu-id="0ce28-190">チェコ共和国 \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-190">Czech Republic \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-191">デンマーク \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-191">Denmark \*</span></span></td>
    <td><span data-ttu-id="0ce28-192">ジブチ</span><span class="sxs-lookup"><span data-stu-id="0ce28-192">Djibouti</span></span></td>
    <td><span data-ttu-id="0ce28-193">ドミニカ国</span><span class="sxs-lookup"><span data-stu-id="0ce28-193">Dominica</span></span></td>
    <td><span data-ttu-id="0ce28-194">ドミニカ共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-194">Dominican Republic</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-195">エクアドル</span><span class="sxs-lookup"><span data-stu-id="0ce28-195">Ecuador</span></span></td>
    <td><span data-ttu-id="0ce28-196">エジプト</span><span class="sxs-lookup"><span data-stu-id="0ce28-196">Egypt</span></span></td>
    <td><span data-ttu-id="0ce28-197">エルサルバドル</span><span class="sxs-lookup"><span data-stu-id="0ce28-197">El Salvador</span></span></td>
    <td><span data-ttu-id="0ce28-198">赤道ギニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-198">Equatorial Guinea</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-199">エリトリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-199">Eritrea</span></span></td>
    <td><span data-ttu-id="0ce28-200">エストニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-200">Estonia</span></span></td>
    <td><span data-ttu-id="0ce28-201">エチオピア</span><span class="sxs-lookup"><span data-stu-id="0ce28-201">Ethiopia</span></span></td>
    <td><span data-ttu-id="0ce28-202">フォークランド諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-202">Falkland Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-203">フェロー諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-203">Faroe Islands</span></span></td>
    <td><span data-ttu-id="0ce28-204">フィジー</span><span class="sxs-lookup"><span data-stu-id="0ce28-204">Fiji</span></span></td>
    <td><span data-ttu-id="0ce28-205">フィンランド \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-205">Finland \*</span></span></td>
    <td><span data-ttu-id="0ce28-206">フランス \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-206">France \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-207">フランス領ギアナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-207">French Guiana</span></span></td>
    <td><span data-ttu-id="0ce28-208">フランス領ポリネシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-208">French Polynesia</span></span></td>
    <td><span data-ttu-id="0ce28-209">フランス領南極地方</span><span class="sxs-lookup"><span data-stu-id="0ce28-209">French Southern and Antarctic Lands</span></span></td>
    <td><span data-ttu-id="0ce28-210">ガボン</span><span class="sxs-lookup"><span data-stu-id="0ce28-210">Gabon</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-211">ガンビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-211">Gambia</span></span></td>
    <td><span data-ttu-id="0ce28-212">ジョージア</span><span class="sxs-lookup"><span data-stu-id="0ce28-212">Georgia</span></span></td>
    <td><span data-ttu-id="0ce28-213">ドイツ \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-213">Germany \*</span></span></td>
    <td><span data-ttu-id="0ce28-214">ガーナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-214">Ghana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-215">ジブラルタル</span><span class="sxs-lookup"><span data-stu-id="0ce28-215">Gibraltar</span></span></td>
    <td><span data-ttu-id="0ce28-216">ギリシャ \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-216">Greece \*</span></span></td>
    <td><span data-ttu-id="0ce28-217">グリーンランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-217">Greenland</span></span></td>
    <td><span data-ttu-id="0ce28-218">グレナダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-218">Grenada</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-219">グアドループ</span><span class="sxs-lookup"><span data-stu-id="0ce28-219">Guadeloupe</span></span></td>
    <td><span data-ttu-id="0ce28-220">グアム</span><span class="sxs-lookup"><span data-stu-id="0ce28-220">Guam</span></span></td>
    <td><span data-ttu-id="0ce28-221">グアテマラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-221">Guatemala</span></span></td>
    <td><span data-ttu-id="0ce28-222">ガーンジー島</span><span class="sxs-lookup"><span data-stu-id="0ce28-222">Guernsey</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-223">ギニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-223">Guinea</span></span></td>
    <td><span data-ttu-id="0ce28-224">ギニアビサウ</span><span class="sxs-lookup"><span data-stu-id="0ce28-224">Guinea-Bissau</span></span></td>
    <td><span data-ttu-id="0ce28-225">ガイアナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-225">Guyana</span></span></td>
    <td><span data-ttu-id="0ce28-226">ハイチ</span><span class="sxs-lookup"><span data-stu-id="0ce28-226">Haiti</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-227">ハード・マクドナルド諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-227">Heard Island and McDonald Islands</span></span></td>
    <td><span data-ttu-id="0ce28-228">ホンジュラス</span><span class="sxs-lookup"><span data-stu-id="0ce28-228">Honduras</span></span></td>
    <td><span data-ttu-id="0ce28-229">香港特別行政区 \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-229">Hong Kong SAR \*</span></span></td>
    <td><span data-ttu-id="0ce28-230">ハンガリー \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-230">Hungary \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-231">アイスランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-231">Iceland</span></span></td>
    <td><span data-ttu-id="0ce28-232">インド \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-232">India \*</span></span></td>
    <td><span data-ttu-id="0ce28-233">インドネシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-233">Indonesia</span></span></td>
    <td><span data-ttu-id="0ce28-234">イラク</span><span class="sxs-lookup"><span data-stu-id="0ce28-234">Iraq</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-235">アイルランド \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-235">Ireland \*</span></span></td>
    <td><span data-ttu-id="0ce28-236">マン島</span><span class="sxs-lookup"><span data-stu-id="0ce28-236">Isle of Man</span></span></td>
    <td><span data-ttu-id="0ce28-237">イスラエル \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-237">Israel \*</span></span></td>
    <td><span data-ttu-id="0ce28-238">イタリア \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-238">Italy \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-239">ジャマイカ</span><span class="sxs-lookup"><span data-stu-id="0ce28-239">Jamaica</span></span></td>
    <td><span data-ttu-id="0ce28-240">日本 \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-240">Japan \*</span></span></td>
    <td><span data-ttu-id="0ce28-241">ジャージー島</span><span class="sxs-lookup"><span data-stu-id="0ce28-241">Jersey</span></span></td>
    <td><span data-ttu-id="0ce28-242">ヨルダン</span><span class="sxs-lookup"><span data-stu-id="0ce28-242">Jordan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-243">カザフスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-243">Kazakhstan</span></span></td>
    <td><span data-ttu-id="0ce28-244">ケニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-244">Kenya</span></span></td>
    <td><span data-ttu-id="0ce28-245">キリバス</span><span class="sxs-lookup"><span data-stu-id="0ce28-245">Kiribati</span></span></td>
    <td><span data-ttu-id="0ce28-246">韓国 \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-246">Korea \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-247">クウェート</span><span class="sxs-lookup"><span data-stu-id="0ce28-247">Kuwait</span></span></td>
    <td><span data-ttu-id="0ce28-248">キルギス</span><span class="sxs-lookup"><span data-stu-id="0ce28-248">Kyrgyzstan</span></span></td>
    <td><span data-ttu-id="0ce28-249">ラオス</span><span class="sxs-lookup"><span data-stu-id="0ce28-249">Laos</span></span></td>
    <td><span data-ttu-id="0ce28-250">ラトビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-250">Latvia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-251">レバノン</span><span class="sxs-lookup"><span data-stu-id="0ce28-251">Lebanon</span></span></td>
    <td><span data-ttu-id="0ce28-252">レソト</span><span class="sxs-lookup"><span data-stu-id="0ce28-252">Lesotho</span></span></td>
    <td><span data-ttu-id="0ce28-253">リベリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-253">Liberia</span></span></td>
    <td><span data-ttu-id="0ce28-254">リビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-254">Libya</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-255">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="0ce28-255">Liechtenstein</span></span></td>
    <td><span data-ttu-id="0ce28-256">リトアニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-256">Lithuania</span></span></td>
    <td><span data-ttu-id="0ce28-257">ルクセンブルク</span><span class="sxs-lookup"><span data-stu-id="0ce28-257">Luxembourg</span></span></td>
    <td><span data-ttu-id="0ce28-258">マカオ</span><span class="sxs-lookup"><span data-stu-id="0ce28-258">Macao SAR</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-259">マケドニア (旧ユーゴスラビア共和国)</span><span class="sxs-lookup"><span data-stu-id="0ce28-259">Macedonia, FYRO</span></span></td>
    <td><span data-ttu-id="0ce28-260">マダガスカル</span><span class="sxs-lookup"><span data-stu-id="0ce28-260">Madagascar</span></span></td>
    <td><span data-ttu-id="0ce28-261">マラウイ</span><span class="sxs-lookup"><span data-stu-id="0ce28-261">Malawi</span></span></td>
    <td><span data-ttu-id="0ce28-262">マレーシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-262">Malaysia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-263">モルディブ</span><span class="sxs-lookup"><span data-stu-id="0ce28-263">Maldives</span></span></td>
    <td><span data-ttu-id="0ce28-264">マリ</span><span class="sxs-lookup"><span data-stu-id="0ce28-264">Mali</span></span></td>
    <td><span data-ttu-id="0ce28-265">マルタ</span><span class="sxs-lookup"><span data-stu-id="0ce28-265">Malta</span></span></td>
    <td><span data-ttu-id="0ce28-266">マーシャル諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-266">Marshall Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-267">マルチニーク島</span><span class="sxs-lookup"><span data-stu-id="0ce28-267">Martinique</span></span></td>
    <td><span data-ttu-id="0ce28-268">モーリタニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-268">Mauritania</span></span></td>
    <td><span data-ttu-id="0ce28-269">モーリシャス</span><span class="sxs-lookup"><span data-stu-id="0ce28-269">Mauritius</span></span></td>
    <td><span data-ttu-id="0ce28-270">マイヨット島</span><span class="sxs-lookup"><span data-stu-id="0ce28-270">Mayotte</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-271">メキシコ \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-271">Mexico \*</span></span></td>
    <td><span data-ttu-id="0ce28-272">ミクロネシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-272">Micronesia</span></span></td>
    <td><span data-ttu-id="0ce28-273">モルドバ</span><span class="sxs-lookup"><span data-stu-id="0ce28-273">Moldova</span></span></td>
    <td><span data-ttu-id="0ce28-274">モナコ</span><span class="sxs-lookup"><span data-stu-id="0ce28-274">Monaco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-275">モンゴル</span><span class="sxs-lookup"><span data-stu-id="0ce28-275">Mongolia</span></span></td>
    <td><span data-ttu-id="0ce28-276">モンテネグロ</span><span class="sxs-lookup"><span data-stu-id="0ce28-276">Montenegro</span></span></td>
    <td><span data-ttu-id="0ce28-277">モンセラット</span><span class="sxs-lookup"><span data-stu-id="0ce28-277">Montserrat</span></span></td>
    <td><span data-ttu-id="0ce28-278">モロッコ</span><span class="sxs-lookup"><span data-stu-id="0ce28-278">Morocco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-279">モザンビーク</span><span class="sxs-lookup"><span data-stu-id="0ce28-279">Mozambique</span></span></td>
    <td><span data-ttu-id="0ce28-280">ミャンマー</span><span class="sxs-lookup"><span data-stu-id="0ce28-280">Myanmar</span></span></td>
    <td><span data-ttu-id="0ce28-281">ナミビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-281">Namibia</span></span></td>
    <td><span data-ttu-id="0ce28-282">ナウル</span><span class="sxs-lookup"><span data-stu-id="0ce28-282">Nauru</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-283">ネパール</span><span class="sxs-lookup"><span data-stu-id="0ce28-283">Nepal</span></span></td>
    <td><span data-ttu-id="0ce28-284">オランダ \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-284">Netherlands \*</span></span></td>
    <td><span data-ttu-id="0ce28-285">ニューカレドニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-285">New Caledonia</span></span></td>
    <td><span data-ttu-id="0ce28-286">ニュージーランド \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-286">New Zealand \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-287">ニカラグア</span><span class="sxs-lookup"><span data-stu-id="0ce28-287">Nicaragua</span></span></td>
    <td><span data-ttu-id="0ce28-288">ニジェール</span><span class="sxs-lookup"><span data-stu-id="0ce28-288">Niger</span></span></td>
    <td><span data-ttu-id="0ce28-289">ナイジェリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-289">Nigeria</span></span></td>
    <td><span data-ttu-id="0ce28-290">ニウエ</span><span class="sxs-lookup"><span data-stu-id="0ce28-290">Niue</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-291">ノーフォーク島</span><span class="sxs-lookup"><span data-stu-id="0ce28-291">Norfolk Island</span></span></td>
    <td><span data-ttu-id="0ce28-292">北マリアナ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-292">Northern Mariana Islands</span></span></td>
    <td><span data-ttu-id="0ce28-293">ノルウェー \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-293">Norway \*</span></span></td>
    <td><span data-ttu-id="0ce28-294">オマーン</span><span class="sxs-lookup"><span data-stu-id="0ce28-294">Oman</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-295">パキスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-295">Pakistan</span></span></td>
    <td><span data-ttu-id="0ce28-296">パラオ</span><span class="sxs-lookup"><span data-stu-id="0ce28-296">Palau</span></span></td>
    <td><span data-ttu-id="0ce28-297">パレスチナ自治政府</span><span class="sxs-lookup"><span data-stu-id="0ce28-297">Palestinian Authority</span></span></td>
    <td><span data-ttu-id="0ce28-298">パナマ</span><span class="sxs-lookup"><span data-stu-id="0ce28-298">Panama</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-299">パプアニューギニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-299">Papua New Guinea</span></span></td>
    <td><span data-ttu-id="0ce28-300">パラグアイ</span><span class="sxs-lookup"><span data-stu-id="0ce28-300">Paraguay</span></span></td>
    <td><span data-ttu-id="0ce28-301">ペルー</span><span class="sxs-lookup"><span data-stu-id="0ce28-301">Peru</span></span></td>
    <td><span data-ttu-id="0ce28-302">フィリピン</span><span class="sxs-lookup"><span data-stu-id="0ce28-302">Philippines</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-303">ピトケアン島</span><span class="sxs-lookup"><span data-stu-id="0ce28-303">Pitcairn Islands</span></span></td>
    <td><span data-ttu-id="0ce28-304">ポーランド \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-304">Poland \*</span></span></td>
    <td><span data-ttu-id="0ce28-305">ポルトガル \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-305">Portugal \*</span></span></td>
    <td><span data-ttu-id="0ce28-306">カタール</span><span class="sxs-lookup"><span data-stu-id="0ce28-306">Qatar</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-307">レユニオン</span><span class="sxs-lookup"><span data-stu-id="0ce28-307">Réunion</span></span></td>
    <td><span data-ttu-id="0ce28-308">ルーマニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-308">Romania</span></span></td>
    <td><span data-ttu-id="0ce28-309">ロシア \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-309">Russia \*</span></span></td>
    <td><span data-ttu-id="0ce28-310">ルワンダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-310">Rwanda</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-311">サン・バルテルミー</span><span class="sxs-lookup"><span data-stu-id="0ce28-311">Saint Barthélemy</span></span></td>
    <td><span data-ttu-id="0ce28-312">セントヘレナ、アセンションおよびトリスタンダクーニャ</span><span class="sxs-lookup"><span data-stu-id="0ce28-312">Saint Helena, Ascension and Tristan da Cunha</span></span></td>
    <td><span data-ttu-id="0ce28-313">セントクリストファー・ネイビス</span><span class="sxs-lookup"><span data-stu-id="0ce28-313">Saint Kitts and Nevis</span></span></td>
    <td><span data-ttu-id="0ce28-314">セントルシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-314">Saint Lucia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-315">サンマルタン島 (フランス領)</span><span class="sxs-lookup"><span data-stu-id="0ce28-315">Saint Martin (French Part)</span></span></td>
    <td><span data-ttu-id="0ce28-316">サンピエール・ミクロン</span><span class="sxs-lookup"><span data-stu-id="0ce28-316">Saint Pierre and Miquelon</span></span></td>
    <td><span data-ttu-id="0ce28-317">セントビンセントおよびグレナディーン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-317">Saint Vincent and the Grenadines</span></span></td>
    <td><span data-ttu-id="0ce28-318">サモア独立国</span><span class="sxs-lookup"><span data-stu-id="0ce28-318">Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-319">サンマリノ</span><span class="sxs-lookup"><span data-stu-id="0ce28-319">San Marino</span></span></td>
    <td><span data-ttu-id="0ce28-320">サントメ・プリンシペ</span><span class="sxs-lookup"><span data-stu-id="0ce28-320">São Tomé and Príncipe</span></span></td>
    <td><span data-ttu-id="0ce28-321">サウジアラビア \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-321">Saudi Arabia \*</span></span></td>
    <td><span data-ttu-id="0ce28-322">セネガル</span><span class="sxs-lookup"><span data-stu-id="0ce28-322">Senegal</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-323">セルビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-323">Serbia</span></span></td>
    <td><span data-ttu-id="0ce28-324">セーシェル</span><span class="sxs-lookup"><span data-stu-id="0ce28-324">Seychelles</span></span></td>
    <td><span data-ttu-id="0ce28-325">シエラレオネ</span><span class="sxs-lookup"><span data-stu-id="0ce28-325">Sierra Leone</span></span></td>
    <td><span data-ttu-id="0ce28-326">シンガポール \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-326">Singapore \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-327">サンマルタン島 (オランダ領)</span><span class="sxs-lookup"><span data-stu-id="0ce28-327">Sint Maarten (Dutch Part)</span></span></td>
    <td><span data-ttu-id="0ce28-328">スロバキア \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-328">Slovakia \*</span></span></td>
    <td><span data-ttu-id="0ce28-329">スロベニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-329">Slovenia</span></span></td>
    <td><span data-ttu-id="0ce28-330">ソロモン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-330">Solomon Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-331">ソマリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-331">Somalia</span></span></td>
    <td><span data-ttu-id="0ce28-332">南アフリカ \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-332">South Africa \*</span></span></td>
    <td><span data-ttu-id="0ce28-333">サウスジョージア・サウスサンドウィッチ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-333">South Georgia and the South Sandwich Islands</span></span></td>
    <td><span data-ttu-id="0ce28-334">スペイン \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-334">Spain \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-335">スリランカ</span><span class="sxs-lookup"><span data-stu-id="0ce28-335">Sri Lanka</span></span></td>
    <td><span data-ttu-id="0ce28-336">スリナム</span><span class="sxs-lookup"><span data-stu-id="0ce28-336">Suriname</span></span></td>
    <td><span data-ttu-id="0ce28-337">スバールバル諸島、ヤンマイエン島</span><span class="sxs-lookup"><span data-stu-id="0ce28-337">Svalbard and Jan Mayen</span></span></td>
    <td><span data-ttu-id="0ce28-338">スワジランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-338">Swaziland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-339">スウェーデン \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-339">Sweden \*</span></span></td>
    <td><span data-ttu-id="0ce28-340">スイス \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-340">Switzerland \*</span></span></td>
    <td><span data-ttu-id="0ce28-341">Taiwan \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-341">Taiwan \*</span></span></td>
    <td><span data-ttu-id="0ce28-342">タジキスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-342">Tajikistan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-343">タンザニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-343">Tanzania</span></span></td>
    <td><span data-ttu-id="0ce28-344">タイ</span><span class="sxs-lookup"><span data-stu-id="0ce28-344">Thailand</span></span></td>
    <td><span data-ttu-id="0ce28-345">ティモール・レステ</span><span class="sxs-lookup"><span data-stu-id="0ce28-345">Timor-Leste</span></span></td>
    <td><span data-ttu-id="0ce28-346">トーゴ</span><span class="sxs-lookup"><span data-stu-id="0ce28-346">Togo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-347">トケラウ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-347">Tokelau</span></span></td>
    <td><span data-ttu-id="0ce28-348">トンガ</span><span class="sxs-lookup"><span data-stu-id="0ce28-348">Tonga</span></span></td>
    <td><span data-ttu-id="0ce28-349">トリニダード・トバゴ</span><span class="sxs-lookup"><span data-stu-id="0ce28-349">Trinidad and Tobago</span></span></td>
    <td><span data-ttu-id="0ce28-350">チュニジア</span><span class="sxs-lookup"><span data-stu-id="0ce28-350">Tunisia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-351">トルコ \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-351">Turkey \*</span></span></td>
    <td><span data-ttu-id="0ce28-352">トルクメニスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-352">Turkmenistan</span></span></td>
    <td><span data-ttu-id="0ce28-353">タークス・カイコス諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-353">Turks and Caicos Islands</span></span></td>
    <td><span data-ttu-id="0ce28-354">ツバル</span><span class="sxs-lookup"><span data-stu-id="0ce28-354">Tuvalu</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-355">その他の米領諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-355">U.S. Minor Outlying Islands</span></span></td>
    <td><span data-ttu-id="0ce28-356">米領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-356">U.S. Virgin Islands</span></span></td>
    <td><span data-ttu-id="0ce28-357">ウガンダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-357">Uganda</span></span></td>
    <td><span data-ttu-id="0ce28-358">ウクライナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-358">Ukraine</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-359">アラブ首長国連邦 \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-359">United Arab Emirates \*</span></span></td>
    <td><span data-ttu-id="0ce28-360">英国 \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-360">United Kingdom \*</span></span></td>
    <td><span data-ttu-id="0ce28-361">米国 \*</span><span class="sxs-lookup"><span data-stu-id="0ce28-361">United States \*</span></span></td>
    <td><span data-ttu-id="0ce28-362">ウルグアイ</span><span class="sxs-lookup"><span data-stu-id="0ce28-362">Uruguay</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-363">ウズベキスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-363">Uzbekistan</span></span></td>
    <td><span data-ttu-id="0ce28-364">バヌアツ</span><span class="sxs-lookup"><span data-stu-id="0ce28-364">Vanuatu</span></span></td>
    <td><span data-ttu-id="0ce28-365">バチカン市国</span><span class="sxs-lookup"><span data-stu-id="0ce28-365">Vatican City</span></span></td>
    <td><span data-ttu-id="0ce28-366">ベネズエラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-366">Venezuela</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-367">ベトナム</span><span class="sxs-lookup"><span data-stu-id="0ce28-367">Vietnam</span></span></td>
    <td><span data-ttu-id="0ce28-368">ワリス・フテュナ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-368">Wallis and Futuna</span></span></td>
    <td><span data-ttu-id="0ce28-369">Western Sahara (Disputed)</span><span class="sxs-lookup"><span data-stu-id="0ce28-369">Western Sahara (Disputed)</span></span></td>
    <td><span data-ttu-id="0ce28-370">イエメン</span><span class="sxs-lookup"><span data-stu-id="0ce28-370">Yemen</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-371">ザンビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-371">Zambia</span></span></td>
    <td><span data-ttu-id="0ce28-372">ジンバブエ</span><span class="sxs-lookup"><span data-stu-id="0ce28-372">Zimbabwe</span></span></td>
    <td></td>
    <td></td>
  </tr>
</table>


## <a name="price-considerations-for-specific-markets"></a><span data-ttu-id="0ce28-373">特定の市場の価格に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="0ce28-373">Price considerations for specific markets</span></span>

<span data-ttu-id="0ce28-374">ギフトカードや携帯電話会社による課金などの支払方法は、有料アプリおよびアプリ内購入アイテムの販売の増加に役立つ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0ce28-374">Payment methods such as gift cards and mobile operator billing can help increase sales of paid apps and in-app purchase items.</span></span> <span data-ttu-id="0ce28-375">このような支払い方法を可能にするためのコストは高額になるため、下の表に示す国/地域および支払い方法については、ストア手数料に Commerce Expansion Adjustment (商取引拡大調整) を加え、純収益から差し引いて、有料アプリやアプリ内購入トランザクションに対して支払われるアプリの収益を計算します。</span><span class="sxs-lookup"><span data-stu-id="0ce28-375">Due to the higher costs to enable such payment methods, a Commerce Expansion Adjustment is added to the Store Fee deducted from Net Receipts to calculate the App Proceeds payable for paid apps and in-app purchase transactions in the countries/regions and using the payment methods in the tables below.</span></span> <span data-ttu-id="0ce28-376">お客様のアプリが利用可能な国/地域で Commerce Expansion Adjustment (商取引拡大調整) が適用されるかどうかを考慮し、それを市場の価格設定戦略に組み込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0ce28-376">You may want to consider if the Commerce Expansion Adjustment applies in a country/region where your app is available and factor that into your market pricing strategy.</span></span> <span data-ttu-id="0ce28-377">Commerce Expansion Adjustment について詳しくは、「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ce28-377">Details about the Commerce Expansion Adjustment can be found in the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement).</span></span>

<span data-ttu-id="0ce28-378">Commerce Expansion Adjustment は、有効日現在、指定された国/地域および支払い方法で処理されるすべての取引に適用されます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-378">The Commerce Expansion Adjustment will be applied to all transactions processed for the specified Country/Region and Payment Methods as of the Effective Date.</span></span> <span data-ttu-id="0ce28-379">この情報は毎月更新され、新しい国/地域および支払方法で Commerce Expansion Adjustment が有効になった日から 30 日以内に、その国/地域および支払方法が一覧表示されます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-379">This information will be updated monthly; new countries/regions and payment methods will be listed within thirty (30) days after the Commerce Expansion Adjustment takes effect for that country/region and payment method.</span></span>

&nbsp;

| <span data-ttu-id="0ce28-380">国/地域</span><span class="sxs-lookup"><span data-stu-id="0ce28-380">Country/region</span></span>       | <span data-ttu-id="0ce28-381">支払い方法</span><span class="sxs-lookup"><span data-stu-id="0ce28-381">Payment method</span></span>  | <span data-ttu-id="0ce28-382">Commerce Expansion Adjustment (商取引拡大調整)</span><span class="sxs-lookup"><span data-stu-id="0ce28-382">Commerce Expansion Adjustment</span></span> | <span data-ttu-id="0ce28-383">有効日</span><span class="sxs-lookup"><span data-stu-id="0ce28-383">Effective date</span></span> |
|----------------------|-----------------|-------------------------------|----------------|
| <span data-ttu-id="0ce28-384">アルゼンチン</span><span class="sxs-lookup"><span data-stu-id="0ce28-384">Argentina</span></span>            | <span data-ttu-id="0ce28-385">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-385">Gift card</span></span>       | <span data-ttu-id="0ce28-386">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-386">2.24%</span></span>                         | <span data-ttu-id="0ce28-387">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-387">March 2016</span></span>     |
| <span data-ttu-id="0ce28-388">オーストラリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-388">Australia</span></span>            | <span data-ttu-id="0ce28-389">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-389">Gift card</span></span>       | <span data-ttu-id="0ce28-390">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-390">2.24%</span></span>                         | <span data-ttu-id="0ce28-391">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-391">March 2016</span></span>     |
| <span data-ttu-id="0ce28-392">オーストリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-392">Austria</span></span>              | <span data-ttu-id="0ce28-393">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-393">Gift card</span></span>       | <span data-ttu-id="0ce28-394">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-394">2.24%</span></span>                         | <span data-ttu-id="0ce28-395">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-395">March 2016</span></span>     |
| <span data-ttu-id="0ce28-396">ベルギー</span><span class="sxs-lookup"><span data-stu-id="0ce28-396">Belgium</span></span>              | <span data-ttu-id="0ce28-397">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-397">Gift card</span></span>       | <span data-ttu-id="0ce28-398">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-398">2.24%</span></span>                         | <span data-ttu-id="0ce28-399">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-399">March 2016</span></span>     |
| <span data-ttu-id="0ce28-400">ブラジル</span><span class="sxs-lookup"><span data-stu-id="0ce28-400">Brazil</span></span>               | <span data-ttu-id="0ce28-401">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-401">Gift card</span></span>       | <span data-ttu-id="0ce28-402">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-402">2.24%</span></span>                         | <span data-ttu-id="0ce28-403">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-403">March 2016</span></span>     |
| <span data-ttu-id="0ce28-404">カナダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-404">Canada</span></span>               | <span data-ttu-id="0ce28-405">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-405">Gift card</span></span>       | <span data-ttu-id="0ce28-406">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-406">2.24%</span></span>                         | <span data-ttu-id="0ce28-407">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-407">March 2016</span></span>     |
| <span data-ttu-id="0ce28-408">チリ</span><span class="sxs-lookup"><span data-stu-id="0ce28-408">Chile</span></span>                | <span data-ttu-id="0ce28-409">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-409">Gift card</span></span>       | <span data-ttu-id="0ce28-410">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-410">2.24%</span></span>                         | <span data-ttu-id="0ce28-411">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-411">March 2016</span></span>     |
| <span data-ttu-id="0ce28-412">中国</span><span class="sxs-lookup"><span data-stu-id="0ce28-412">China</span></span>                | <span data-ttu-id="0ce28-413">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-413">Gift card</span></span>       | <span data-ttu-id="0ce28-414">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-414">2.24%</span></span>                         | <span data-ttu-id="0ce28-415">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-415">March 2016</span></span>     |
| <span data-ttu-id="0ce28-416">コロンビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-416">Colombia</span></span>             | <span data-ttu-id="0ce28-417">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-417">Gift card</span></span>       | <span data-ttu-id="0ce28-418">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-418">2.24%</span></span>                         | <span data-ttu-id="0ce28-419">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-419">March 2016</span></span>     |
| <span data-ttu-id="0ce28-420">チェコ共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-420">Czech Republic</span></span>       | <span data-ttu-id="0ce28-421">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-421">Gift card</span></span>       | <span data-ttu-id="0ce28-422">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-422">2.24%</span></span>                         | <span data-ttu-id="0ce28-423">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-423">March 2016</span></span>     |
| <span data-ttu-id="0ce28-424">デンマーク</span><span class="sxs-lookup"><span data-stu-id="0ce28-424">Denmark</span></span>              | <span data-ttu-id="0ce28-425">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-425">Gift card</span></span>       | <span data-ttu-id="0ce28-426">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-426">2.24%</span></span>                         | <span data-ttu-id="0ce28-427">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-427">March 2016</span></span>     |
| <span data-ttu-id="0ce28-428">フィンランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-428">Finland</span></span>              | <span data-ttu-id="0ce28-429">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-429">Gift card</span></span>       | <span data-ttu-id="0ce28-430">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-430">2.24%</span></span>                         | <span data-ttu-id="0ce28-431">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-431">March 2016</span></span>     |
| <span data-ttu-id="0ce28-432">フランス</span><span class="sxs-lookup"><span data-stu-id="0ce28-432">France</span></span>               | <span data-ttu-id="0ce28-433">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-433">Gift card</span></span>       | <span data-ttu-id="0ce28-434">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-434">2.24%</span></span>                         | <span data-ttu-id="0ce28-435">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-435">March 2016</span></span>     |
| <span data-ttu-id="0ce28-436">ドイツ</span><span class="sxs-lookup"><span data-stu-id="0ce28-436">Germany</span></span>              | <span data-ttu-id="0ce28-437">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-437">Gift card</span></span>       | <span data-ttu-id="0ce28-438">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-438">2.24%</span></span>                         | <span data-ttu-id="0ce28-439">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-439">March 2016</span></span>     |
| <span data-ttu-id="0ce28-440">ギリシャ</span><span class="sxs-lookup"><span data-stu-id="0ce28-440">Greece</span></span>               | <span data-ttu-id="0ce28-441">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-441">Gift card</span></span>       | <span data-ttu-id="0ce28-442">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-442">2.24%</span></span>                         | <span data-ttu-id="0ce28-443">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-443">March 2016</span></span>     |
| <span data-ttu-id="0ce28-444">香港</span><span class="sxs-lookup"><span data-stu-id="0ce28-444">Hong Kong</span></span>            | <span data-ttu-id="0ce28-445">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-445">Gift card</span></span>       | <span data-ttu-id="0ce28-446">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-446">2.24%</span></span>                         | <span data-ttu-id="0ce28-447">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-447">March 2016</span></span>     |
| <span data-ttu-id="0ce28-448">ハンガリー</span><span class="sxs-lookup"><span data-stu-id="0ce28-448">Hungary</span></span>              | <span data-ttu-id="0ce28-449">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-449">Gift card</span></span>       | <span data-ttu-id="0ce28-450">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-450">2.24%</span></span>                         | <span data-ttu-id="0ce28-451">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-451">March 2016</span></span>     |
| <span data-ttu-id="0ce28-452">インド</span><span class="sxs-lookup"><span data-stu-id="0ce28-452">India</span></span>                | <span data-ttu-id="0ce28-453">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-453">Gift card</span></span>       | <span data-ttu-id="0ce28-454">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-454">2.24%</span></span>                         | <span data-ttu-id="0ce28-455">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-455">March 2016</span></span>     |
| <span data-ttu-id="0ce28-456">アイルランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-456">Ireland</span></span>              | <span data-ttu-id="0ce28-457">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-457">Gift card</span></span>       | <span data-ttu-id="0ce28-458">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-458">2.24%</span></span>                         | <span data-ttu-id="0ce28-459">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-459">March 2016</span></span>     |
| <span data-ttu-id="0ce28-460">イスラエル</span><span class="sxs-lookup"><span data-stu-id="0ce28-460">Israel</span></span>               | <span data-ttu-id="0ce28-461">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-461">Gift card</span></span>       | <span data-ttu-id="0ce28-462">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-462">2.24%</span></span>                         | <span data-ttu-id="0ce28-463">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-463">March 2016</span></span>     |
| <span data-ttu-id="0ce28-464">イタリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-464">Italy</span></span>                | <span data-ttu-id="0ce28-465">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-465">Gift card</span></span>       | <span data-ttu-id="0ce28-466">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-466">2.24%</span></span>                         | <span data-ttu-id="0ce28-467">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-467">March 2016</span></span>     |
| <span data-ttu-id="0ce28-468">日本</span><span class="sxs-lookup"><span data-stu-id="0ce28-468">Japan</span></span>                | <span data-ttu-id="0ce28-469">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-469">Gift card</span></span>       | <span data-ttu-id="0ce28-470">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-470">2.24%</span></span>                         | <span data-ttu-id="0ce28-471">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-471">March 2016</span></span>     |
| <span data-ttu-id="0ce28-472">メキシコ</span><span class="sxs-lookup"><span data-stu-id="0ce28-472">Mexico</span></span>               | <span data-ttu-id="0ce28-473">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-473">Gift card</span></span>       | <span data-ttu-id="0ce28-474">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-474">2.24%</span></span>                         | <span data-ttu-id="0ce28-475">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-475">March 2016</span></span>     |
| <span data-ttu-id="0ce28-476">オランダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-476">Netherlands</span></span>          | <span data-ttu-id="0ce28-477">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-477">Gift card</span></span>       | <span data-ttu-id="0ce28-478">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-478">2.24%</span></span>                         | <span data-ttu-id="0ce28-479">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-479">March 2016</span></span>     |
| <span data-ttu-id="0ce28-480">ニュージーランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-480">New Zealand</span></span>          | <span data-ttu-id="0ce28-481">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-481">Gift card</span></span>       | <span data-ttu-id="0ce28-482">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-482">2.24%</span></span>                         | <span data-ttu-id="0ce28-483">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-483">March 2016</span></span>     |
| <span data-ttu-id="0ce28-484">ポーランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-484">Poland</span></span>               | <span data-ttu-id="0ce28-485">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-485">Gift card</span></span>       | <span data-ttu-id="0ce28-486">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-486">2.24%</span></span>                         | <span data-ttu-id="0ce28-487">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-487">March 2016</span></span>     |
| <span data-ttu-id="0ce28-488">ポルトガル</span><span class="sxs-lookup"><span data-stu-id="0ce28-488">Portugal</span></span>             | <span data-ttu-id="0ce28-489">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-489">Gift card</span></span>       | <span data-ttu-id="0ce28-490">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-490">2.24%</span></span>                         | <span data-ttu-id="0ce28-491">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-491">March 2016</span></span>     |
| <span data-ttu-id="0ce28-492">ロシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-492">Russia</span></span>               | <span data-ttu-id="0ce28-493">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-493">Gift card</span></span>       | <span data-ttu-id="0ce28-494">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-494">2.24%</span></span>                         | <span data-ttu-id="0ce28-495">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-495">March 2016</span></span>     |
| <span data-ttu-id="0ce28-496">サウジアラビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-496">Saudi Arabia</span></span>         | <span data-ttu-id="0ce28-497">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-497">Gift card</span></span>       | <span data-ttu-id="0ce28-498">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-498">2.24%</span></span>                         | <span data-ttu-id="0ce28-499">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-499">March 2016</span></span>     |
| <span data-ttu-id="0ce28-500">シンガポール</span><span class="sxs-lookup"><span data-stu-id="0ce28-500">Singapore</span></span>            | <span data-ttu-id="0ce28-501">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-501">Gift card</span></span>       | <span data-ttu-id="0ce28-502">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-502">2.24%</span></span>                         | <span data-ttu-id="0ce28-503">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-503">March 2016</span></span>     |
| <span data-ttu-id="0ce28-504">スロバキア</span><span class="sxs-lookup"><span data-stu-id="0ce28-504">Slovakia</span></span>             | <span data-ttu-id="0ce28-505">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-505">Gift card</span></span>       | <span data-ttu-id="0ce28-506">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-506">2.24%</span></span>                         | <span data-ttu-id="0ce28-507">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-507">March 2016</span></span>     |
| <span data-ttu-id="0ce28-508">南アフリカ</span><span class="sxs-lookup"><span data-stu-id="0ce28-508">South Africa</span></span>         | <span data-ttu-id="0ce28-509">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-509">Gift card</span></span>       | <span data-ttu-id="0ce28-510">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-510">2.24%</span></span>                         | <span data-ttu-id="0ce28-511">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-511">March 2016</span></span>     |
| <span data-ttu-id="0ce28-512">韓国</span><span class="sxs-lookup"><span data-stu-id="0ce28-512">South Korea</span></span>          | <span data-ttu-id="0ce28-513">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-513">Gift card</span></span>       | <span data-ttu-id="0ce28-514">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-514">2.24%</span></span>                         | <span data-ttu-id="0ce28-515">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-515">March 2016</span></span>     |
| <span data-ttu-id="0ce28-516">スペイン</span><span class="sxs-lookup"><span data-stu-id="0ce28-516">Spain</span></span>                | <span data-ttu-id="0ce28-517">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-517">Gift card</span></span>       | <span data-ttu-id="0ce28-518">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-518">2.24%</span></span>                         | <span data-ttu-id="0ce28-519">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-519">March 2016</span></span>     |
| <span data-ttu-id="0ce28-520">スウェーデン</span><span class="sxs-lookup"><span data-stu-id="0ce28-520">Sweden</span></span>               | <span data-ttu-id="0ce28-521">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-521">Gift card</span></span>       | <span data-ttu-id="0ce28-522">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-522">2.24%</span></span>                         | <span data-ttu-id="0ce28-523">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-523">March 2016</span></span>     |
| <span data-ttu-id="0ce28-524">スイス</span><span class="sxs-lookup"><span data-stu-id="0ce28-524">Switzerland</span></span>          | <span data-ttu-id="0ce28-525">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-525">Gift card</span></span>       | <span data-ttu-id="0ce28-526">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-526">2.24%</span></span>                         | <span data-ttu-id="0ce28-527">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-527">March 2016</span></span>     |
| <span data-ttu-id="0ce28-528">台湾</span><span class="sxs-lookup"><span data-stu-id="0ce28-528">Taiwan</span></span>               | <span data-ttu-id="0ce28-529">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-529">Gift card</span></span>       | <span data-ttu-id="0ce28-530">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-530">2.24%</span></span>                         | <span data-ttu-id="0ce28-531">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-531">March 2016</span></span>     |
| <span data-ttu-id="0ce28-532">トルコ</span><span class="sxs-lookup"><span data-stu-id="0ce28-532">Turkey</span></span>               | <span data-ttu-id="0ce28-533">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-533">Gift card</span></span>       | <span data-ttu-id="0ce28-534">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-534">2.24%</span></span>                         | <span data-ttu-id="0ce28-535">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-535">March 2016</span></span>     |
| <span data-ttu-id="0ce28-536">アラブ首長国連邦</span><span class="sxs-lookup"><span data-stu-id="0ce28-536">United Arab Emirates</span></span> | <span data-ttu-id="0ce28-537">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-537">Gift card</span></span>       | <span data-ttu-id="0ce28-538">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-538">2.24%</span></span>                         | <span data-ttu-id="0ce28-539">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-539">March 2016</span></span>     |
| <span data-ttu-id="0ce28-540">英国</span><span class="sxs-lookup"><span data-stu-id="0ce28-540">United Kingdom</span></span>       | <span data-ttu-id="0ce28-541">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-541">Gift card</span></span>       | <span data-ttu-id="0ce28-542">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-542">2.24%</span></span>                         | <span data-ttu-id="0ce28-543">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-543">March 2016</span></span>     |
| <span data-ttu-id="0ce28-544">米国</span><span class="sxs-lookup"><span data-stu-id="0ce28-544">United States</span></span>        | <span data-ttu-id="0ce28-545">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="0ce28-545">Gift card</span></span>       | <span data-ttu-id="0ce28-546">2.24%</span><span class="sxs-lookup"><span data-stu-id="0ce28-546">2.24%</span></span>                         | <span data-ttu-id="0ce28-547">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="0ce28-547">March 2016</span></span>     |

 

## <a name="rest-of-world-markets-for-windows-8x"></a><span data-ttu-id="0ce28-548">Windows 8.x の "その他の国と地域" 市場</span><span class="sxs-lookup"><span data-stu-id="0ce28-548">"Rest of World" markets for Windows 8.x</span></span>

<span data-ttu-id="0ce28-549">アプリには、Windows をターゲットとするパッケージが含まれている場合、8.x することが重要市場の番号が windows ストアを使用してユーザーの 1 つ「残りの部分の地域」市場として扱うことに注意してください 8.x、Windows デベロッパー センターでの個別の市場として表示される場合でもダッシュ ボード (以前のストア ダッシュ ボードではなくすべての市場のグループ化する 1 つの「残りの部分の国と地域」市場オプションがあった場合)。</span><span class="sxs-lookup"><span data-stu-id="0ce28-549">If your app includes packages targeting Windows 8.x, it's important to be aware that a number of markets are treated as a single "Rest of World" market for customers using the Store on Windows 8.x, even though they are shown as individual markets in the Windows Dev Center dashboard (as opposed to the earlier Store dashboard, where there was one "Rest of World" market option to group all of these markets).</span></span>

<span data-ttu-id="0ce28-550">アプリを申請するときに、既定の項目を選択したままにしている場合、この問題について心配する必要はありません。アプリは可能なすべての市場に公開されます。</span><span class="sxs-lookup"><span data-stu-id="0ce28-550">If you leave the default selection when submitting your app, you don't have to worry about this, and your app will be available to all possible markets.</span></span> <span data-ttu-id="0ce28-551">ただし、特定の市場を除外する場合、これらの "その他の国と地域" 市場のいずれかの市場を除外すると、Windows 8 または Windows 8.1 ユーザー向けの "その他の国と地域" 市場のどの市場にもアプリが公開されないことを意味することに留意してください。</span><span class="sxs-lookup"><span data-stu-id="0ce28-551">However, if you want to exclude certain markets, keep in mind that excluding even one of these "Rest of World" markets means that your app won't be available in any of the "Rest of World" markets for customers on Windows 8 or Windows 8.1.</span></span>

<span data-ttu-id="0ce28-552">Windows 8.x 向けの "その他の国と地域" に含まれている市場は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="0ce28-552">The markets that are included in "Rest of World" for Windows 8.x are the following:</span></span>


<table>
  <tr>
    <td><span data-ttu-id="0ce28-553">アフガニスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-553">Afghanistan</span></span></td>
    <td><span data-ttu-id="0ce28-554">オーランド諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-554">Åland Islands</span></span></td>
    <td><span data-ttu-id="0ce28-555">アルバニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-555">Albania</span></span></td>
    <td><span data-ttu-id="0ce28-556">アメリカ領サモア</span><span class="sxs-lookup"><span data-stu-id="0ce28-556">American Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-557">アンドラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-557">Andorra</span></span></td>
    <td><span data-ttu-id="0ce28-558">アンゴラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-558">Angola</span></span></td>
    <td><span data-ttu-id="0ce28-559">アンギラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-559">Anguilla</span></span></td>
    <td><span data-ttu-id="0ce28-560">南極</span><span class="sxs-lookup"><span data-stu-id="0ce28-560">Antarctica</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-561">アンティグア・バーブーダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-561">Antigua and Barbuda</span></span></td>
    <td><span data-ttu-id="0ce28-562">アルメニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-562">Armenia</span></span></td>
    <td><span data-ttu-id="0ce28-563">アルバ</span><span class="sxs-lookup"><span data-stu-id="0ce28-563">Aruba</span></span></td>
    <td><span data-ttu-id="0ce28-564">アゼルバイジャン</span><span class="sxs-lookup"><span data-stu-id="0ce28-564">Azerbaijan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-565">バハマ</span><span class="sxs-lookup"><span data-stu-id="0ce28-565">Bahamas</span></span></td>
    <td><span data-ttu-id="0ce28-566">バングラデシュ</span><span class="sxs-lookup"><span data-stu-id="0ce28-566">Bangladesh</span></span></td>
    <td><span data-ttu-id="0ce28-567">バルバドス</span><span class="sxs-lookup"><span data-stu-id="0ce28-567">Barbados</span></span></td>
    <td><span data-ttu-id="0ce28-568">ベラルーシ</span><span class="sxs-lookup"><span data-stu-id="0ce28-568">Belarus</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-569">ベリーズ</span><span class="sxs-lookup"><span data-stu-id="0ce28-569">Belize</span></span></td>
    <td><span data-ttu-id="0ce28-570">ベナン</span><span class="sxs-lookup"><span data-stu-id="0ce28-570">Benin</span></span></td>
    <td><span data-ttu-id="0ce28-571">バミューダ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-571">Bermuda</span></span></td>
    <td><span data-ttu-id="0ce28-572">ブータン</span><span class="sxs-lookup"><span data-stu-id="0ce28-572">Bhutan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-573">ボリビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-573">Bolivia</span></span></td>
    <td><span data-ttu-id="0ce28-574">ボネール島</span><span class="sxs-lookup"><span data-stu-id="0ce28-574">Bonaire</span></span></td>
    <td><span data-ttu-id="0ce28-575">ボスニア・ヘルツェゴビナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-575">Bosnia and Herzegovina</span></span></td>
    <td><span data-ttu-id="0ce28-576">ボツワナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-576">Botswana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-577">ブーベ島</span><span class="sxs-lookup"><span data-stu-id="0ce28-577">Bouvet Island</span></span></td>
    <td><span data-ttu-id="0ce28-578">英領インド洋地域</span><span class="sxs-lookup"><span data-stu-id="0ce28-578">British Indian Ocean Territory</span></span></td>
    <td><span data-ttu-id="0ce28-579">英領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-579">British Virgin Islands</span></span></td>
    <td><span data-ttu-id="0ce28-580">ブルネイ</span><span class="sxs-lookup"><span data-stu-id="0ce28-580">Brunei</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-581">ブルキナファソ</span><span class="sxs-lookup"><span data-stu-id="0ce28-581">Burkina Faso</span></span></td>
    <td><span data-ttu-id="0ce28-582">ブルンジ</span><span class="sxs-lookup"><span data-stu-id="0ce28-582">Burundi</span></span></td>
    <td><span data-ttu-id="0ce28-583">カーボベルデ</span><span class="sxs-lookup"><span data-stu-id="0ce28-583">Cabo Verde</span></span></td>
    <td><span data-ttu-id="0ce28-584">カンボジア</span><span class="sxs-lookup"><span data-stu-id="0ce28-584">Cambodia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-585">カメルーン</span><span class="sxs-lookup"><span data-stu-id="0ce28-585">Cameroon</span></span></td>
    <td><span data-ttu-id="0ce28-586">ケイマン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-586">Cayman Islands</span></span></td>
    <td><span data-ttu-id="0ce28-587">中央アフリカ共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-587">Central African Republic</span></span></td>
    <td><span data-ttu-id="0ce28-588">チャド</span><span class="sxs-lookup"><span data-stu-id="0ce28-588">Chad</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-589">クリスマス島</span><span class="sxs-lookup"><span data-stu-id="0ce28-589">Christmas Island</span></span></td>
    <td><span data-ttu-id="0ce28-590">ココス諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-590">Cocos (Keeling) Islands</span></span></td>
    <td><span data-ttu-id="0ce28-591">コモロ</span><span class="sxs-lookup"><span data-stu-id="0ce28-591">Comoros</span></span></td>
    <td><span data-ttu-id="0ce28-592">コンゴ共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-592">Congo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-593">コンゴ民主共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-593">Congo (DRC)</span></span></td>
    <td><span data-ttu-id="0ce28-594">クック諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-594">Cook Islands</span></span></td>
    <td><span data-ttu-id="0ce28-595">コートジボワール</span><span class="sxs-lookup"><span data-stu-id="0ce28-595">Côte d’Ivoire</span></span></td>
    <td><span data-ttu-id="0ce28-596">キュラソー島</span><span class="sxs-lookup"><span data-stu-id="0ce28-596">Curaçao</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-597">ジブチ</span><span class="sxs-lookup"><span data-stu-id="0ce28-597">Djibouti</span></span></td>
    <td><span data-ttu-id="0ce28-598">ドミニカ国</span><span class="sxs-lookup"><span data-stu-id="0ce28-598">Dominica</span></span></td>
    <td><span data-ttu-id="0ce28-599">ドミニカ共和国</span><span class="sxs-lookup"><span data-stu-id="0ce28-599">Dominican Republic</span></span></td>
    <td><span data-ttu-id="0ce28-600">エクアドル</span><span class="sxs-lookup"><span data-stu-id="0ce28-600">Ecuador</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-601">エルサルバドル</span><span class="sxs-lookup"><span data-stu-id="0ce28-601">El Salvador</span></span></td>
    <td><span data-ttu-id="0ce28-602">赤道ギニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-602">Equatorial Guinea</span></span></td>
    <td><span data-ttu-id="0ce28-603">エリトリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-603">Eritrea</span></span></td>
    <td><span data-ttu-id="0ce28-604">エチオピア</span><span class="sxs-lookup"><span data-stu-id="0ce28-604">Ethiopia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-605">フォークランド諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-605">Falkland Islands</span></span></td>
    <td><span data-ttu-id="0ce28-606">フェロー諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-606">Faroe Islands</span></span></td>
    <td><span data-ttu-id="0ce28-607">フィジー</span><span class="sxs-lookup"><span data-stu-id="0ce28-607">Fiji</span></span></td>
    <td><span data-ttu-id="0ce28-608">フランス領ギアナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-608">French Guiana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-609">フランス領ポリネシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-609">French Polynesia</span></span></td>
    <td><span data-ttu-id="0ce28-610">フランス領南極地方</span><span class="sxs-lookup"><span data-stu-id="0ce28-610">French Southern and Antarctic Lands</span></span></td>
    <td><span data-ttu-id="0ce28-611">ガボン</span><span class="sxs-lookup"><span data-stu-id="0ce28-611">Gabon</span></span></td>
    <td><span data-ttu-id="0ce28-612">ガンビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-612">Gambia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-613">ジョージア</span><span class="sxs-lookup"><span data-stu-id="0ce28-613">Georgia</span></span></td>
    <td><span data-ttu-id="0ce28-614">ガーナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-614">Ghana</span></span></td>
    <td><span data-ttu-id="0ce28-615">ジブラルタル</span><span class="sxs-lookup"><span data-stu-id="0ce28-615">Gibraltar</span></span></td>
    <td><span data-ttu-id="0ce28-616">グリーンランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-616">Greenland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-617">グレナダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-617">Grenada</span></span></td>
    <td><span data-ttu-id="0ce28-618">グアドループ</span><span class="sxs-lookup"><span data-stu-id="0ce28-618">Guadeloupe</span></span></td>
    <td><span data-ttu-id="0ce28-619">グアム</span><span class="sxs-lookup"><span data-stu-id="0ce28-619">Guam</span></span></td>
    <td><span data-ttu-id="0ce28-620">グアテマラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-620">Guatemala</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-621">ガーンジー島</span><span class="sxs-lookup"><span data-stu-id="0ce28-621">Guernsey</span></span></td>
    <td><span data-ttu-id="0ce28-622">ギニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-622">Guinea</span></span></td>
    <td><span data-ttu-id="0ce28-623">ギニアビサウ</span><span class="sxs-lookup"><span data-stu-id="0ce28-623">Guinea-Bissau</span></span></td>
    <td><span data-ttu-id="0ce28-624">ガイアナ</span><span class="sxs-lookup"><span data-stu-id="0ce28-624">Guyana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-625">ハイチ</span><span class="sxs-lookup"><span data-stu-id="0ce28-625">Haiti</span></span></td>
    <td><span data-ttu-id="0ce28-626">ハード・マクドナルド諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-626">Heard Island and McDonald Islands</span></span></td>
    <td><span data-ttu-id="0ce28-627">ホンジュラス</span><span class="sxs-lookup"><span data-stu-id="0ce28-627">Honduras</span></span></td>
    <td><span data-ttu-id="0ce28-628">アイスランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-628">Iceland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-629">マン島</span><span class="sxs-lookup"><span data-stu-id="0ce28-629">Isle of Man</span></span></td>
    <td><span data-ttu-id="0ce28-630">ジャマイカ</span><span class="sxs-lookup"><span data-stu-id="0ce28-630">Jamaica</span></span></td>
    <td><span data-ttu-id="0ce28-631">ジャージー島</span><span class="sxs-lookup"><span data-stu-id="0ce28-631">Jersey</span></span></td>
    <td><span data-ttu-id="0ce28-632">ケニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-632">Kenya</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-633">キリバス</span><span class="sxs-lookup"><span data-stu-id="0ce28-633">Kiribati</span></span></td>
    <td><span data-ttu-id="0ce28-634">キルギス</span><span class="sxs-lookup"><span data-stu-id="0ce28-634">Kyrgyzstan</span></span></td>
    <td><span data-ttu-id="0ce28-635">ラオス</span><span class="sxs-lookup"><span data-stu-id="0ce28-635">Laos</span></span></td>
    <td><span data-ttu-id="0ce28-636">レソト</span><span class="sxs-lookup"><span data-stu-id="0ce28-636">Lesotho</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-637">リベリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-637">Liberia</span></span></td>
    <td><span data-ttu-id="0ce28-638">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="0ce28-638">Liechtenstein</span></span></td>
    <td><span data-ttu-id="0ce28-639">マカオ</span><span class="sxs-lookup"><span data-stu-id="0ce28-639">Macao SAR</span></span></td>
    <td><span data-ttu-id="0ce28-640">マケドニア (旧ユーゴスラビア共和国)</span><span class="sxs-lookup"><span data-stu-id="0ce28-640">Macedonia, FYRO</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-641">マダガスカル</span><span class="sxs-lookup"><span data-stu-id="0ce28-641">Madagascar</span></span></td>
    <td><span data-ttu-id="0ce28-642">マラウイ</span><span class="sxs-lookup"><span data-stu-id="0ce28-642">Malawi</span></span></td>
    <td><span data-ttu-id="0ce28-643">モルディブ</span><span class="sxs-lookup"><span data-stu-id="0ce28-643">Maldives</span></span></td>
    <td><span data-ttu-id="0ce28-644">マリ</span><span class="sxs-lookup"><span data-stu-id="0ce28-644">Mali</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-645">マーシャル諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-645">Marshall Islands</span></span></td>
    <td><span data-ttu-id="0ce28-646">マルチニーク島</span><span class="sxs-lookup"><span data-stu-id="0ce28-646">Martinique</span></span></td>
    <td><span data-ttu-id="0ce28-647">モーリタニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-647">Mauritania</span></span></td>
    <td><span data-ttu-id="0ce28-648">モーリシャス</span><span class="sxs-lookup"><span data-stu-id="0ce28-648">Mauritius</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-649">マイヨット島</span><span class="sxs-lookup"><span data-stu-id="0ce28-649">Mayotte</span></span></td>
    <td><span data-ttu-id="0ce28-650">ミクロネシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-650">Micronesia</span></span></td>
    <td><span data-ttu-id="0ce28-651">モルドバ</span><span class="sxs-lookup"><span data-stu-id="0ce28-651">Moldova</span></span></td>
    <td><span data-ttu-id="0ce28-652">モナコ</span><span class="sxs-lookup"><span data-stu-id="0ce28-652">Monaco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-653">モンゴル</span><span class="sxs-lookup"><span data-stu-id="0ce28-653">Mongolia</span></span></td>
    <td><span data-ttu-id="0ce28-654">モンテネグロ</span><span class="sxs-lookup"><span data-stu-id="0ce28-654">Montenegro</span></span></td>
    <td><span data-ttu-id="0ce28-655">モンセラット</span><span class="sxs-lookup"><span data-stu-id="0ce28-655">Montserrat</span></span></td>
    <td><span data-ttu-id="0ce28-656">モロッコ</span><span class="sxs-lookup"><span data-stu-id="0ce28-656">Morocco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-657">モザンビーク</span><span class="sxs-lookup"><span data-stu-id="0ce28-657">Mozambique</span></span></td>
    <td><span data-ttu-id="0ce28-658">ミャンマー</span><span class="sxs-lookup"><span data-stu-id="0ce28-658">Myanmar</span></span></td>
    <td><span data-ttu-id="0ce28-659">ナミビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-659">Namibia</span></span></td>
    <td><span data-ttu-id="0ce28-660">ナウル</span><span class="sxs-lookup"><span data-stu-id="0ce28-660">Nauru</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-661">ネパール</span><span class="sxs-lookup"><span data-stu-id="0ce28-661">Nepal</span></span></td>
    <td><span data-ttu-id="0ce28-662">ニューカレドニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-662">New Caledonia</span></span></td>
    <td><span data-ttu-id="0ce28-663">ニカラグア</span><span class="sxs-lookup"><span data-stu-id="0ce28-663">Nicaragua</span></span></td>
    <td><span data-ttu-id="0ce28-664">ニジェール</span><span class="sxs-lookup"><span data-stu-id="0ce28-664">Niger</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-665">ナイジェリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-665">Nigeria</span></span></td>
    <td><span data-ttu-id="0ce28-666">ニウエ</span><span class="sxs-lookup"><span data-stu-id="0ce28-666">Niue</span></span></td>
    <td><span data-ttu-id="0ce28-667">ノーフォーク島</span><span class="sxs-lookup"><span data-stu-id="0ce28-667">Norfolk Island</span></span></td>
    <td><span data-ttu-id="0ce28-668">北マリアナ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-668">Northern Mariana Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-669">パラオ</span><span class="sxs-lookup"><span data-stu-id="0ce28-669">Palau</span></span></td>
    <td><span data-ttu-id="0ce28-670">パレスチナ自治政府</span><span class="sxs-lookup"><span data-stu-id="0ce28-670">Palestinian Authority</span></span></td>
    <td><span data-ttu-id="0ce28-671">パナマ</span><span class="sxs-lookup"><span data-stu-id="0ce28-671">Panama</span></span></td>
    <td><span data-ttu-id="0ce28-672">パプアニューギニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-672">Papua New Guinea</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-673">パラグアイ</span><span class="sxs-lookup"><span data-stu-id="0ce28-673">Paraguay</span></span></td>
    <td><span data-ttu-id="0ce28-674">ピトケアン島</span><span class="sxs-lookup"><span data-stu-id="0ce28-674">Pitcairn Islands</span></span></td>
    <td><span data-ttu-id="0ce28-675">レユニオン</span><span class="sxs-lookup"><span data-stu-id="0ce28-675">Réunion</span></span></td>
    <td><span data-ttu-id="0ce28-676">ルワンダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-676">Rwanda</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-677">サン・バルテルミー</span><span class="sxs-lookup"><span data-stu-id="0ce28-677">Saint Barthélemy</span></span></td>
    <td><span data-ttu-id="0ce28-678">セントヘレナ、アセンションおよびトリスタンダクーニャ</span><span class="sxs-lookup"><span data-stu-id="0ce28-678">Saint Helena, Ascension and Tristan da Cunha</span></span></td>
    <td><span data-ttu-id="0ce28-679">セントクリストファー・ネイビス</span><span class="sxs-lookup"><span data-stu-id="0ce28-679">Saint Kitts and Nevis</span></span></td>
    <td><span data-ttu-id="0ce28-680">セントルシア</span><span class="sxs-lookup"><span data-stu-id="0ce28-680">Saint Lucia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-681">サンマルタン島 (フランス領)</span><span class="sxs-lookup"><span data-stu-id="0ce28-681">Saint Martin (French Part)</span></span></td>
    <td><span data-ttu-id="0ce28-682">サンピエール・ミクロン</span><span class="sxs-lookup"><span data-stu-id="0ce28-682">Saint Pierre and Miquelon</span></span></td>
    <td><span data-ttu-id="0ce28-683">セントビンセントおよびグレナディーン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-683">Saint Vincent and the Grenadines</span></span></td>
    <td><span data-ttu-id="0ce28-684">サモア独立国</span><span class="sxs-lookup"><span data-stu-id="0ce28-684">Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-685">サンマリノ</span><span class="sxs-lookup"><span data-stu-id="0ce28-685">San Marino</span></span></td>
    <td><span data-ttu-id="0ce28-686">サントメ・プリンシペ</span><span class="sxs-lookup"><span data-stu-id="0ce28-686">São Tomé and Príncipe</span></span></td>
    <td><span data-ttu-id="0ce28-687">セネガル</span><span class="sxs-lookup"><span data-stu-id="0ce28-687">Senegal</span></span></td>
    <td><span data-ttu-id="0ce28-688">セーシェル</span><span class="sxs-lookup"><span data-stu-id="0ce28-688">Seychelles</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-689">シエラレオネ</span><span class="sxs-lookup"><span data-stu-id="0ce28-689">Sierra Leone</span></span></td>
    <td><span data-ttu-id="0ce28-690">サンマルタン島 (オランダ領)</span><span class="sxs-lookup"><span data-stu-id="0ce28-690">Sint Maarten (Dutch Part)</span></span></td>
    <td><span data-ttu-id="0ce28-691">ソロモン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-691">Solomon Islands</span></span></td>
    <td><span data-ttu-id="0ce28-692">ソマリア</span><span class="sxs-lookup"><span data-stu-id="0ce28-692">Somalia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-693">サウスジョージア・サウスサンドウィッチ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-693">South Georgia and the South Sandwich Islands</span></span></td>
    <td><span data-ttu-id="0ce28-694">スリナム</span><span class="sxs-lookup"><span data-stu-id="0ce28-694">Suriname</span></span></td>
    <td><span data-ttu-id="0ce28-695">スバールバル諸島、ヤンマイエン島</span><span class="sxs-lookup"><span data-stu-id="0ce28-695">Svalbard and Jan Mayen</span></span></td>
    <td><span data-ttu-id="0ce28-696">スワジランド</span><span class="sxs-lookup"><span data-stu-id="0ce28-696">Swaziland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-697">タジキスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-697">Tajikistan</span></span></td>
    <td><span data-ttu-id="0ce28-698">タンザニア</span><span class="sxs-lookup"><span data-stu-id="0ce28-698">Tanzania</span></span></td>
    <td><span data-ttu-id="0ce28-699">ティモール・レステ</span><span class="sxs-lookup"><span data-stu-id="0ce28-699">Timor-Leste</span></span></td>
    <td><span data-ttu-id="0ce28-700">トーゴ</span><span class="sxs-lookup"><span data-stu-id="0ce28-700">Togo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-701">トケラウ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-701">Tokelau</span></span></td>
    <td><span data-ttu-id="0ce28-702">トンガ</span><span class="sxs-lookup"><span data-stu-id="0ce28-702">Tonga</span></span></td>
    <td><span data-ttu-id="0ce28-703">トルクメニスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-703">Turkmenistan</span></span></td>
    <td><span data-ttu-id="0ce28-704">タークス・カイコス諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-704">Turks and Caicos Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-705">ツバル</span><span class="sxs-lookup"><span data-stu-id="0ce28-705">Tuvalu</span></span></td>
    <td><span data-ttu-id="0ce28-706">ウガンダ</span><span class="sxs-lookup"><span data-stu-id="0ce28-706">Uganda</span></span></td>
    <td><span data-ttu-id="0ce28-707">その他の米領諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-707">U.S. Minor Outlying Islands</span></span></td>
    <td><span data-ttu-id="0ce28-708">米領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-708">U.S. Virgin Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-709">ウズベキスタン</span><span class="sxs-lookup"><span data-stu-id="0ce28-709">Uzbekistan</span></span></td>
    <td><span data-ttu-id="0ce28-710">バチカン市国</span><span class="sxs-lookup"><span data-stu-id="0ce28-710">Vatican City</span></span></td>
    <td><span data-ttu-id="0ce28-711">ベネズエラ</span><span class="sxs-lookup"><span data-stu-id="0ce28-711">Venezuela</span></span></td>
    <td><span data-ttu-id="0ce28-712">ベトナム</span><span class="sxs-lookup"><span data-stu-id="0ce28-712">Vietnam</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-713">バヌアツ</span><span class="sxs-lookup"><span data-stu-id="0ce28-713">Vanuatu</span></span></td>
    <td><span data-ttu-id="0ce28-714">ワリス・フテュナ諸島</span><span class="sxs-lookup"><span data-stu-id="0ce28-714">Wallis and Futuna</span></span></td>
    <td><span data-ttu-id="0ce28-715">イエメン</span><span class="sxs-lookup"><span data-stu-id="0ce28-715">Yemen</span></span></td>
    <td><span data-ttu-id="0ce28-716">ザンビア</span><span class="sxs-lookup"><span data-stu-id="0ce28-716">Zambia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="0ce28-717">ジンバブエ</span><span class="sxs-lookup"><span data-stu-id="0ce28-717">Zimbabwe</span></span></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>

> [!NOTE]
> <span data-ttu-id="0ce28-718">開発者アカウントを登録できる国と地域の一覧については、「[アカウントの種類、場所、料金](account-types-locations-and-fees.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ce28-718">For a list of the countries and regions in which you can register for a developer account, see [Account types, locations, and fees](account-types-locations-and-fees.md).</span></span>
