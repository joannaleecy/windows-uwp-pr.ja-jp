---
author: jnHs
Description: The Microsoft Store reaches customers in over 200 countries and regions around the world.
title: 市場の選択の定義
ms.assetid: FBE7507B-DBF3-4FCB-8377-DB01660E75F8
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, UWP, 市場, 国, 地域
ms.localizationpriority: medium
ms.openlocfilehash: ef7136868fc9c212640c142db2751bd6e9a0b179
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6975667"
---
# <a name="define-market-selection"></a><span data-ttu-id="06854-103">市場の選択の定義</span><span class="sxs-lookup"><span data-stu-id="06854-103">Define market selection</span></span>


<span data-ttu-id="06854-104">Microsoft Store は、世界中の 200 以上の国と地域のお客様が利用できます。</span><span class="sxs-lookup"><span data-stu-id="06854-104">The Microsoft Store reaches customers in over 200 countries and regions around the world.</span></span> <span data-ttu-id="06854-105">アプリを提供する市場を選択して、市場ごとまたは市場のグループごとに、[価格と使用可能状況](set-app-pricing-and-availability.md)の多くの機能をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="06854-105">You can choose the markets in which you'd like to offer your app, with the option to customize many [pricing and availability](set-app-pricing-and-availability.md) features per market or per group of markets.</span></span>

<span data-ttu-id="06854-106">やすく、アプリのユーザーに適した、世界中には、[グローバリゼーションのガイドライン](../design/globalizing/guidelines-and-checklist-for-globalizing-your-app.md)と[ローカライズ可能なアプリ](../design/globalizing/prepare-your-app-for-localization.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="06854-106">For info to help make your app suitable for customers around the world, see [Guidelines for globalization](../design/globalizing/guidelines-and-checklist-for-globalizing-your-app.md) and [Make your app localizable](../design/globalizing/prepare-your-app-for-localization.md).</span></span>

> [!NOTE]
> <span data-ttu-id="06854-107">このトピックはアプリについて説明していますが、アドオンの市場の選択にも同じプロセスを使います。</span><span class="sxs-lookup"><span data-stu-id="06854-107">Although this topic refers to apps, market selection for add-on submissions uses the same process.</span></span>

## <a name="markets"></a><span data-ttu-id="06854-108">市場</span><span class="sxs-lookup"><span data-stu-id="06854-108">Markets</span></span>

<span data-ttu-id="06854-109">既定では、アプリは販売できるすべての市場 (今後追加される可能性のある市場も含む) にその基本価格で公開されます。</span><span class="sxs-lookup"><span data-stu-id="06854-109">By default, we'll offer your app in all possible markets, including any future markets that we may add later, at its base price.</span></span>

<span data-ttu-id="06854-110">必要に応じて、アプリを提供する特定の市場を定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="06854-110">If you prefer, you can define the specific markets in which you'd like to offer your app.</span></span> <span data-ttu-id="06854-111">これを行うには、**[価格と使用可能状況]** ページの **[市場]** セクションで **[オプションの表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="06854-111">To do so, select **Show options** in the **Markets** section on the **Pricing and availability** page.</span></span> <span data-ttu-id="06854-112">**[市場の選択]** ポップアップ ウィンドウが表示されます。ここで、アプリを提供する市場を選択できます。</span><span class="sxs-lookup"><span data-stu-id="06854-112">This will display the **Market selection** popup window, where you can choose the markets in which to offer your app.</span></span>

<span data-ttu-id="06854-113">既定では、すべての市場が選択されています。</span><span class="sxs-lookup"><span data-stu-id="06854-113">By default, all markets are selected.</span></span> <span data-ttu-id="06854-114">市場を 1 つずつ選択解除して除外するか、**[すべて選択解除]** をクリックしてから、必要な市場を 1 つずつ選んで追加できます。</span><span class="sxs-lookup"><span data-stu-id="06854-114">You can unselect individual markets to exclude them, or you can click **Unselect all** and then add individual markets of your choice.</span></span> <span data-ttu-id="06854-115">検索バーで特定の市場を検索できます。また、ドロップダウンを **[すべての市場]** から **[Xbox の市場]** に変更すると、Xbox 向けの製品を販売できる市場だけを表示できます。</span><span class="sxs-lookup"><span data-stu-id="06854-115">You can search for a particular market in the search bar, and you can also change the dropdown from **All markets** to **Xbox markets** if you only want to view the markets in which you can sell Xbox products.</span></span> <span data-ttu-id="06854-116">完了したら、**[OK]** をクリックして選択を保存します。</span><span class="sxs-lookup"><span data-stu-id="06854-116">Once you’ve finished, click **OK** to save your selections.</span></span>

<span data-ttu-id="06854-117">ここで選択した設定は、新規にアプリを入手するユーザーにのみ適用されます。特定の市場でユーザーが既にアプリを入手している場合、後でその市場からアプリを削除しても、既にアプリを所有しているユーザーは引き続きアプリを使うことができます。ただし、今後提出される更新プログラムを受け取ることはできず、その市場で新規ユーザーがアプリを入手することもできません。</span><span class="sxs-lookup"><span data-stu-id="06854-117">Note that your selections here apply only to new acquisitions; if someone already has your app in a certain market, and you later remove that market, the people who already have the app in that market can continue to use it, but they won’t get the updates you submit, and no new customers in that market can get your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="06854-118">それらの要件は、ここで、またはパートナー センターに記載されていない場合でもを地域の法的要件を満たすためにご自身の責任です。</span><span class="sxs-lookup"><span data-stu-id="06854-118">It is your responsibility to meet any local legal requirements, even if those requirements aren't listed here or in Partner Center.</span></span>

<span data-ttu-id="06854-119">すべての市場を選んだ場合でも、現地の法律、規制、またはその他の要因により、特定のアプリが一部の国と地域に公開されないことがあります。</span><span class="sxs-lookup"><span data-stu-id="06854-119">Keep in mind that even if you select all markets, local laws and restrictions or other factors may prevent certain apps from being listed in some countries and regions.</span></span> <span data-ttu-id="06854-120">また、一部の市場には年齢区分に関する特定の要件が存在することがあります。</span><span class="sxs-lookup"><span data-stu-id="06854-120">Also, some markets may have specific requirements related to age ratings.</span></span> <span data-ttu-id="06854-121">アプリがこれらの要件を満たしていない場合、その市場でアプリを提供できなくなります。</span><span class="sxs-lookup"><span data-stu-id="06854-121">If your app doesn’t meet these requirements, we won't be able to offer your app in that market.</span></span> <span data-ttu-id="06854-122">詳しくは、「[年齢区分](age-ratings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06854-122">See [Age ratings](age-ratings.md) for more info.</span></span>

> [!NOTE]
> <span data-ttu-id="06854-123">以前に公開されたアプリの Windows8 または Windows8.1 を対象とするパッケージが含まれている場合は、いくつかの個別の市場が 1 つの単一の「残りの部分の国と地域」市場として扱われます。</span><span class="sxs-lookup"><span data-stu-id="06854-123">For previously-published apps that include packages targeting Windows8 or Windows8.1, some individual markets are treated as one single "Rest of World" market.</span></span> <span data-ttu-id="06854-124">詳しくは、「[Windows 8.x の "その他の国と地域" 市場](#rest-of-world-markets-for-windows-8x)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06854-124">For more info, see ["Rest of World" markets for Windows 8.x](#rest-of-world-markets-for-windows-8x).</span></span>

<span data-ttu-id="06854-125">また、今後ストアに追加される市場にアプリを提供するかどうかを指定するチェック ボックスも用意されています。</span><span class="sxs-lookup"><span data-stu-id="06854-125">You will also see a checkbox that lets you indicate whether to offer your app in any market that the Store may add in the future.</span></span> <span data-ttu-id="06854-126">このチェック ボックスをオンにしておくと、後で新しい市場が追加されたときに、申請時に指定したアプリの基本価格と一般公開日がそれらの市場で使われます。</span><span class="sxs-lookup"><span data-stu-id="06854-126">If you leave this box checked, and we later add new markets, the base price and general availability date for your submission will be used for your app in those markets.</span></span> <span data-ttu-id="06854-127">これを避けるには、このチェック ボックスをオフにすると、今後追加される市場でアプリが公開されることはなくなります (後でいつでもアプリを追加できます)。</span><span class="sxs-lookup"><span data-stu-id="06854-127">If you don't want this to happen, you can uncheck this box, in which case we will not list your app in any future markets (though you can always add them later).</span></span>
 

## <a name="microsoft-store-consumer-markets"></a><span data-ttu-id="06854-128">Microsoft ストアのユーザー市場</span><span class="sxs-lookup"><span data-stu-id="06854-128">Microsoft Store consumer markets</span></span>

<span data-ttu-id="06854-129">以下に挙げる市場の中から、アプリ (またはアドオン) を公開する市場を 1 つ以上選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="06854-129">You can choose to list your app (or add-on) in one or more of the following markets.</span></span> <span data-ttu-id="06854-130">アスタリスクで市場は Xbox One では、Microsoft Store をサポートします。**Xbox**は、**市場の選択**は、ポップアップ ウィンドウで、名前の横に表示されます。</span><span class="sxs-lookup"><span data-stu-id="06854-130">The markets with an asterisk support the Microsoft Store on Xbox One; you'll see **Xbox** next to their names in the **Market selection** popup window.</span></span>


<table>
  
  <tr>
    <td><span data-ttu-id="06854-131">アフガニスタン</span><span class="sxs-lookup"><span data-stu-id="06854-131">Afghanistan</span></span></td>
    <td><span data-ttu-id="06854-132">オーランド諸島</span><span class="sxs-lookup"><span data-stu-id="06854-132">Åland Islands</span></span></td>
    <td><span data-ttu-id="06854-133">アルバニア</span><span class="sxs-lookup"><span data-stu-id="06854-133">Albania</span></span></td>
    <td><span data-ttu-id="06854-134">アルジェリア</span><span class="sxs-lookup"><span data-stu-id="06854-134">Algeria</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-135">米領サモア</span><span class="sxs-lookup"><span data-stu-id="06854-135">American Samoa</span></span></td>
    <td><span data-ttu-id="06854-136">アンドラ</span><span class="sxs-lookup"><span data-stu-id="06854-136">Andorra</span></span></td>
    <td><span data-ttu-id="06854-137">アンゴラ</span><span class="sxs-lookup"><span data-stu-id="06854-137">Angola</span></span></td>
    <td><span data-ttu-id="06854-138">アンギラ</span><span class="sxs-lookup"><span data-stu-id="06854-138">Anguilla</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-139">南極</span><span class="sxs-lookup"><span data-stu-id="06854-139">Antarctica</span></span></td>
    <td><span data-ttu-id="06854-140">アンティグア・バーブーダ</span><span class="sxs-lookup"><span data-stu-id="06854-140">Antigua and Barbuda</span></span></td>
    <td><span data-ttu-id="06854-141">アルゼンチン</span><span class="sxs-lookup"><span data-stu-id="06854-141">Argentina</span></span></td>
    <td><span data-ttu-id="06854-142">アルメニア</span><span class="sxs-lookup"><span data-stu-id="06854-142">Armenia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-143">アルバ</span><span class="sxs-lookup"><span data-stu-id="06854-143">Aruba</span></span></td>
    <td><span data-ttu-id="06854-144">オーストラリア</span><span class="sxs-lookup"><span data-stu-id="06854-144">Australia</span></span></td>
    <td><span data-ttu-id="06854-145">オーストリア</span><span class="sxs-lookup"><span data-stu-id="06854-145">Austria</span></span></td>
    <td><span data-ttu-id="06854-146">アゼルバイジャン</span><span class="sxs-lookup"><span data-stu-id="06854-146">Azerbaijan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-147">バハマ</span><span class="sxs-lookup"><span data-stu-id="06854-147">Bahamas</span></span></td>
    <td><span data-ttu-id="06854-148">バーレーン</span><span class="sxs-lookup"><span data-stu-id="06854-148">Bahrain</span></span></td>
    <td><span data-ttu-id="06854-149">バングラデシュ</span><span class="sxs-lookup"><span data-stu-id="06854-149">Bangladesh</span></span></td>
    <td><span data-ttu-id="06854-150">バルバドス</span><span class="sxs-lookup"><span data-stu-id="06854-150">Barbados</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-151">ベラルーシ</span><span class="sxs-lookup"><span data-stu-id="06854-151">Belarus</span></span></td>
    <td><span data-ttu-id="06854-152">ベルギー</span><span class="sxs-lookup"><span data-stu-id="06854-152">Belgium</span></span></td>
    <td><span data-ttu-id="06854-153">ベリーズ</span><span class="sxs-lookup"><span data-stu-id="06854-153">Belize</span></span></td>
    <td><span data-ttu-id="06854-154">ベナン</span><span class="sxs-lookup"><span data-stu-id="06854-154">Benin</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-155">バミューダ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-155">Bermuda</span></span></td>
    <td><span data-ttu-id="06854-156">ブータン</span><span class="sxs-lookup"><span data-stu-id="06854-156">Bhutan</span></span></td>
    <td><span data-ttu-id="06854-157">ボリビア</span><span class="sxs-lookup"><span data-stu-id="06854-157">Bolivia</span></span></td>
    <td><span data-ttu-id="06854-158">ボネール島</span><span class="sxs-lookup"><span data-stu-id="06854-158">Bonaire</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-159">ボスニア・ヘルツェゴビナ</span><span class="sxs-lookup"><span data-stu-id="06854-159">Bosnia and Herzegovina</span></span></td>
    <td><span data-ttu-id="06854-160">ボツワナ</span><span class="sxs-lookup"><span data-stu-id="06854-160">Botswana</span></span></td>
    <td><span data-ttu-id="06854-161">ブーベ島</span><span class="sxs-lookup"><span data-stu-id="06854-161">Bouvet Island</span></span></td>
    <td><span data-ttu-id="06854-162">ブラジル</span><span class="sxs-lookup"><span data-stu-id="06854-162">Brazil</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-163">英領インド洋地域</span><span class="sxs-lookup"><span data-stu-id="06854-163">British Indian Ocean Territory</span></span></td>
    <td><span data-ttu-id="06854-164">英領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-164">British Virgin Islands</span></span></td>
    <td><span data-ttu-id="06854-165">ブルネイ</span><span class="sxs-lookup"><span data-stu-id="06854-165">Brunei</span></span></td>
    <td><span data-ttu-id="06854-166">ブルガリア</span><span class="sxs-lookup"><span data-stu-id="06854-166">Bulgaria</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-167">ブルキナファソ</span><span class="sxs-lookup"><span data-stu-id="06854-167">Burkina Faso</span></span></td>
    <td><span data-ttu-id="06854-168">ブルンジ</span><span class="sxs-lookup"><span data-stu-id="06854-168">Burundi</span></span></td>
    <td><span data-ttu-id="06854-169">カーボベルデ</span><span class="sxs-lookup"><span data-stu-id="06854-169">Cabo Verde</span></span></td>
    <td><span data-ttu-id="06854-170">カンボジア</span><span class="sxs-lookup"><span data-stu-id="06854-170">Cambodia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-171">カメルーン</span><span class="sxs-lookup"><span data-stu-id="06854-171">Cameroon</span></span></td>
    <td><span data-ttu-id="06854-172">カナダ</span><span class="sxs-lookup"><span data-stu-id="06854-172">Canada</span></span></td>
    <td><span data-ttu-id="06854-173">ケイマン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-173">Cayman Islands</span></span></td>
    <td><span data-ttu-id="06854-174">中央アフリカ共和国</span><span class="sxs-lookup"><span data-stu-id="06854-174">Central African Republic</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-175">チャド</span><span class="sxs-lookup"><span data-stu-id="06854-175">Chad</span></span></td>
    <td><span data-ttu-id="06854-176">チリ</span><span class="sxs-lookup"><span data-stu-id="06854-176">Chile</span></span></td>
    <td><span data-ttu-id="06854-177">中国</span><span class="sxs-lookup"><span data-stu-id="06854-177">China</span></span></td>
    <td><span data-ttu-id="06854-178">クリスマス島</span><span class="sxs-lookup"><span data-stu-id="06854-178">Christmas Island</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-179">ココス諸島</span><span class="sxs-lookup"><span data-stu-id="06854-179">Cocos (Keeling) Islands</span></span></td>
    <td><span data-ttu-id="06854-180">コロンビア \*</span><span class="sxs-lookup"><span data-stu-id="06854-180">Colombia \*</span></span></td>
    <td><span data-ttu-id="06854-181">コモロ</span><span class="sxs-lookup"><span data-stu-id="06854-181">Comoros</span></span></td>
    <td><span data-ttu-id="06854-182">コンゴ共和国</span><span class="sxs-lookup"><span data-stu-id="06854-182">Congo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-183">コンゴ民主共和国</span><span class="sxs-lookup"><span data-stu-id="06854-183">Congo (DRC)</span></span></td>
    <td><span data-ttu-id="06854-184">クック諸島</span><span class="sxs-lookup"><span data-stu-id="06854-184">Cook Islands</span></span></td>
    <td><span data-ttu-id="06854-185">コスタリカ</span><span class="sxs-lookup"><span data-stu-id="06854-185">Costa Rica</span></span></td>
    <td><span data-ttu-id="06854-186">コートジボワール</span><span class="sxs-lookup"><span data-stu-id="06854-186">Côte d’Ivoire</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-187">クロアチア</span><span class="sxs-lookup"><span data-stu-id="06854-187">Croatia</span></span></td>
    <td><span data-ttu-id="06854-188">キュラソー島</span><span class="sxs-lookup"><span data-stu-id="06854-188">Curaçao</span></span></td>
    <td><span data-ttu-id="06854-189">キプロス</span><span class="sxs-lookup"><span data-stu-id="06854-189">Cyprus</span></span></td>
    <td><span data-ttu-id="06854-190">チェコ共和国 \*</span><span class="sxs-lookup"><span data-stu-id="06854-190">Czech Republic \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-191">デンマーク \*</span><span class="sxs-lookup"><span data-stu-id="06854-191">Denmark \*</span></span></td>
    <td><span data-ttu-id="06854-192">ジブチ</span><span class="sxs-lookup"><span data-stu-id="06854-192">Djibouti</span></span></td>
    <td><span data-ttu-id="06854-193">ドミニカ国</span><span class="sxs-lookup"><span data-stu-id="06854-193">Dominica</span></span></td>
    <td><span data-ttu-id="06854-194">ドミニカ共和国</span><span class="sxs-lookup"><span data-stu-id="06854-194">Dominican Republic</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-195">エクアドル</span><span class="sxs-lookup"><span data-stu-id="06854-195">Ecuador</span></span></td>
    <td><span data-ttu-id="06854-196">エジプト</span><span class="sxs-lookup"><span data-stu-id="06854-196">Egypt</span></span></td>
    <td><span data-ttu-id="06854-197">エルサルバドル</span><span class="sxs-lookup"><span data-stu-id="06854-197">El Salvador</span></span></td>
    <td><span data-ttu-id="06854-198">赤道ギニア</span><span class="sxs-lookup"><span data-stu-id="06854-198">Equatorial Guinea</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-199">エリトリア</span><span class="sxs-lookup"><span data-stu-id="06854-199">Eritrea</span></span></td>
    <td><span data-ttu-id="06854-200">エストニア</span><span class="sxs-lookup"><span data-stu-id="06854-200">Estonia</span></span></td>
    <td><span data-ttu-id="06854-201">エチオピア</span><span class="sxs-lookup"><span data-stu-id="06854-201">Ethiopia</span></span></td>
    <td><span data-ttu-id="06854-202">フォークランド諸島</span><span class="sxs-lookup"><span data-stu-id="06854-202">Falkland Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-203">フェロー諸島</span><span class="sxs-lookup"><span data-stu-id="06854-203">Faroe Islands</span></span></td>
    <td><span data-ttu-id="06854-204">フィジー</span><span class="sxs-lookup"><span data-stu-id="06854-204">Fiji</span></span></td>
    <td><span data-ttu-id="06854-205">フィンランド \*</span><span class="sxs-lookup"><span data-stu-id="06854-205">Finland \*</span></span></td>
    <td><span data-ttu-id="06854-206">フランス \*</span><span class="sxs-lookup"><span data-stu-id="06854-206">France \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-207">フランス領ギアナ</span><span class="sxs-lookup"><span data-stu-id="06854-207">French Guiana</span></span></td>
    <td><span data-ttu-id="06854-208">フランス領ポリネシア</span><span class="sxs-lookup"><span data-stu-id="06854-208">French Polynesia</span></span></td>
    <td><span data-ttu-id="06854-209">フランス領南極地方</span><span class="sxs-lookup"><span data-stu-id="06854-209">French Southern and Antarctic Lands</span></span></td>
    <td><span data-ttu-id="06854-210">ガボン</span><span class="sxs-lookup"><span data-stu-id="06854-210">Gabon</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-211">ガンビア</span><span class="sxs-lookup"><span data-stu-id="06854-211">Gambia</span></span></td>
    <td><span data-ttu-id="06854-212">ジョージア</span><span class="sxs-lookup"><span data-stu-id="06854-212">Georgia</span></span></td>
    <td><span data-ttu-id="06854-213">ドイツ \*</span><span class="sxs-lookup"><span data-stu-id="06854-213">Germany \*</span></span></td>
    <td><span data-ttu-id="06854-214">ガーナ</span><span class="sxs-lookup"><span data-stu-id="06854-214">Ghana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-215">ジブラルタル</span><span class="sxs-lookup"><span data-stu-id="06854-215">Gibraltar</span></span></td>
    <td><span data-ttu-id="06854-216">ギリシャ \*</span><span class="sxs-lookup"><span data-stu-id="06854-216">Greece \*</span></span></td>
    <td><span data-ttu-id="06854-217">グリーンランド</span><span class="sxs-lookup"><span data-stu-id="06854-217">Greenland</span></span></td>
    <td><span data-ttu-id="06854-218">グレナダ</span><span class="sxs-lookup"><span data-stu-id="06854-218">Grenada</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-219">グアドループ</span><span class="sxs-lookup"><span data-stu-id="06854-219">Guadeloupe</span></span></td>
    <td><span data-ttu-id="06854-220">グアム</span><span class="sxs-lookup"><span data-stu-id="06854-220">Guam</span></span></td>
    <td><span data-ttu-id="06854-221">グアテマラ</span><span class="sxs-lookup"><span data-stu-id="06854-221">Guatemala</span></span></td>
    <td><span data-ttu-id="06854-222">ガーンジー島</span><span class="sxs-lookup"><span data-stu-id="06854-222">Guernsey</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-223">ギニア</span><span class="sxs-lookup"><span data-stu-id="06854-223">Guinea</span></span></td>
    <td><span data-ttu-id="06854-224">ギニアビサウ</span><span class="sxs-lookup"><span data-stu-id="06854-224">Guinea-Bissau</span></span></td>
    <td><span data-ttu-id="06854-225">ガイアナ</span><span class="sxs-lookup"><span data-stu-id="06854-225">Guyana</span></span></td>
    <td><span data-ttu-id="06854-226">ハイチ</span><span class="sxs-lookup"><span data-stu-id="06854-226">Haiti</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-227">ハード・マクドナルド諸島</span><span class="sxs-lookup"><span data-stu-id="06854-227">Heard Island and McDonald Islands</span></span></td>
    <td><span data-ttu-id="06854-228">ホンジュラス</span><span class="sxs-lookup"><span data-stu-id="06854-228">Honduras</span></span></td>
    <td><span data-ttu-id="06854-229">香港特別行政区 \*</span><span class="sxs-lookup"><span data-stu-id="06854-229">Hong Kong SAR \*</span></span></td>
    <td><span data-ttu-id="06854-230">ハンガリー \*</span><span class="sxs-lookup"><span data-stu-id="06854-230">Hungary \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-231">アイスランド</span><span class="sxs-lookup"><span data-stu-id="06854-231">Iceland</span></span></td>
    <td><span data-ttu-id="06854-232">インド \*</span><span class="sxs-lookup"><span data-stu-id="06854-232">India \*</span></span></td>
    <td><span data-ttu-id="06854-233">インドネシア</span><span class="sxs-lookup"><span data-stu-id="06854-233">Indonesia</span></span></td>
    <td><span data-ttu-id="06854-234">イラク</span><span class="sxs-lookup"><span data-stu-id="06854-234">Iraq</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-235">アイルランド \*</span><span class="sxs-lookup"><span data-stu-id="06854-235">Ireland \*</span></span></td>
    <td><span data-ttu-id="06854-236">マン島</span><span class="sxs-lookup"><span data-stu-id="06854-236">Isle of Man</span></span></td>
    <td><span data-ttu-id="06854-237">イスラエル \*</span><span class="sxs-lookup"><span data-stu-id="06854-237">Israel \*</span></span></td>
    <td><span data-ttu-id="06854-238">イタリア \*</span><span class="sxs-lookup"><span data-stu-id="06854-238">Italy \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-239">ジャマイカ</span><span class="sxs-lookup"><span data-stu-id="06854-239">Jamaica</span></span></td>
    <td><span data-ttu-id="06854-240">日本 \*</span><span class="sxs-lookup"><span data-stu-id="06854-240">Japan \*</span></span></td>
    <td><span data-ttu-id="06854-241">ジャージー島</span><span class="sxs-lookup"><span data-stu-id="06854-241">Jersey</span></span></td>
    <td><span data-ttu-id="06854-242">ヨルダン</span><span class="sxs-lookup"><span data-stu-id="06854-242">Jordan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-243">カザフスタン</span><span class="sxs-lookup"><span data-stu-id="06854-243">Kazakhstan</span></span></td>
    <td><span data-ttu-id="06854-244">ケニア</span><span class="sxs-lookup"><span data-stu-id="06854-244">Kenya</span></span></td>
    <td><span data-ttu-id="06854-245">キリバス</span><span class="sxs-lookup"><span data-stu-id="06854-245">Kiribati</span></span></td>
    <td><span data-ttu-id="06854-246">韓国 \*</span><span class="sxs-lookup"><span data-stu-id="06854-246">Korea \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-247">クウェート</span><span class="sxs-lookup"><span data-stu-id="06854-247">Kuwait</span></span></td>
    <td><span data-ttu-id="06854-248">キルギス</span><span class="sxs-lookup"><span data-stu-id="06854-248">Kyrgyzstan</span></span></td>
    <td><span data-ttu-id="06854-249">ラオス</span><span class="sxs-lookup"><span data-stu-id="06854-249">Laos</span></span></td>
    <td><span data-ttu-id="06854-250">ラトビア</span><span class="sxs-lookup"><span data-stu-id="06854-250">Latvia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-251">レバノン</span><span class="sxs-lookup"><span data-stu-id="06854-251">Lebanon</span></span></td>
    <td><span data-ttu-id="06854-252">レソト</span><span class="sxs-lookup"><span data-stu-id="06854-252">Lesotho</span></span></td>
    <td><span data-ttu-id="06854-253">リベリア</span><span class="sxs-lookup"><span data-stu-id="06854-253">Liberia</span></span></td>
    <td><span data-ttu-id="06854-254">リビア</span><span class="sxs-lookup"><span data-stu-id="06854-254">Libya</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-255">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="06854-255">Liechtenstein</span></span></td>
    <td><span data-ttu-id="06854-256">リトアニア</span><span class="sxs-lookup"><span data-stu-id="06854-256">Lithuania</span></span></td>
    <td><span data-ttu-id="06854-257">ルクセンブルク</span><span class="sxs-lookup"><span data-stu-id="06854-257">Luxembourg</span></span></td>
    <td><span data-ttu-id="06854-258">マカオ</span><span class="sxs-lookup"><span data-stu-id="06854-258">Macao SAR</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-259">マケドニア (旧ユーゴスラビア共和国)</span><span class="sxs-lookup"><span data-stu-id="06854-259">Macedonia, FYRO</span></span></td>
    <td><span data-ttu-id="06854-260">マダガスカル</span><span class="sxs-lookup"><span data-stu-id="06854-260">Madagascar</span></span></td>
    <td><span data-ttu-id="06854-261">マラウイ</span><span class="sxs-lookup"><span data-stu-id="06854-261">Malawi</span></span></td>
    <td><span data-ttu-id="06854-262">マレーシア</span><span class="sxs-lookup"><span data-stu-id="06854-262">Malaysia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-263">モルディブ</span><span class="sxs-lookup"><span data-stu-id="06854-263">Maldives</span></span></td>
    <td><span data-ttu-id="06854-264">マリ</span><span class="sxs-lookup"><span data-stu-id="06854-264">Mali</span></span></td>
    <td><span data-ttu-id="06854-265">マルタ</span><span class="sxs-lookup"><span data-stu-id="06854-265">Malta</span></span></td>
    <td><span data-ttu-id="06854-266">マーシャル諸島</span><span class="sxs-lookup"><span data-stu-id="06854-266">Marshall Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-267">マルチニーク島</span><span class="sxs-lookup"><span data-stu-id="06854-267">Martinique</span></span></td>
    <td><span data-ttu-id="06854-268">モーリタニア</span><span class="sxs-lookup"><span data-stu-id="06854-268">Mauritania</span></span></td>
    <td><span data-ttu-id="06854-269">モーリシャス</span><span class="sxs-lookup"><span data-stu-id="06854-269">Mauritius</span></span></td>
    <td><span data-ttu-id="06854-270">マイヨット島</span><span class="sxs-lookup"><span data-stu-id="06854-270">Mayotte</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-271">メキシコ \*</span><span class="sxs-lookup"><span data-stu-id="06854-271">Mexico \*</span></span></td>
    <td><span data-ttu-id="06854-272">ミクロネシア</span><span class="sxs-lookup"><span data-stu-id="06854-272">Micronesia</span></span></td>
    <td><span data-ttu-id="06854-273">モルドバ</span><span class="sxs-lookup"><span data-stu-id="06854-273">Moldova</span></span></td>
    <td><span data-ttu-id="06854-274">モナコ</span><span class="sxs-lookup"><span data-stu-id="06854-274">Monaco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-275">モンゴル</span><span class="sxs-lookup"><span data-stu-id="06854-275">Mongolia</span></span></td>
    <td><span data-ttu-id="06854-276">モンテネグロ</span><span class="sxs-lookup"><span data-stu-id="06854-276">Montenegro</span></span></td>
    <td><span data-ttu-id="06854-277">モンセラット</span><span class="sxs-lookup"><span data-stu-id="06854-277">Montserrat</span></span></td>
    <td><span data-ttu-id="06854-278">モロッコ</span><span class="sxs-lookup"><span data-stu-id="06854-278">Morocco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-279">モザンビーク</span><span class="sxs-lookup"><span data-stu-id="06854-279">Mozambique</span></span></td>
    <td><span data-ttu-id="06854-280">ミャンマー</span><span class="sxs-lookup"><span data-stu-id="06854-280">Myanmar</span></span></td>
    <td><span data-ttu-id="06854-281">ナミビア</span><span class="sxs-lookup"><span data-stu-id="06854-281">Namibia</span></span></td>
    <td><span data-ttu-id="06854-282">ナウル</span><span class="sxs-lookup"><span data-stu-id="06854-282">Nauru</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-283">ネパール</span><span class="sxs-lookup"><span data-stu-id="06854-283">Nepal</span></span></td>
    <td><span data-ttu-id="06854-284">オランダ \*</span><span class="sxs-lookup"><span data-stu-id="06854-284">Netherlands \*</span></span></td>
    <td><span data-ttu-id="06854-285">ニューカレドニア</span><span class="sxs-lookup"><span data-stu-id="06854-285">New Caledonia</span></span></td>
    <td><span data-ttu-id="06854-286">ニュージーランド \*</span><span class="sxs-lookup"><span data-stu-id="06854-286">New Zealand \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-287">ニカラグア</span><span class="sxs-lookup"><span data-stu-id="06854-287">Nicaragua</span></span></td>
    <td><span data-ttu-id="06854-288">ニジェール</span><span class="sxs-lookup"><span data-stu-id="06854-288">Niger</span></span></td>
    <td><span data-ttu-id="06854-289">ナイジェリア</span><span class="sxs-lookup"><span data-stu-id="06854-289">Nigeria</span></span></td>
    <td><span data-ttu-id="06854-290">ニウエ</span><span class="sxs-lookup"><span data-stu-id="06854-290">Niue</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-291">ノーフォーク島</span><span class="sxs-lookup"><span data-stu-id="06854-291">Norfolk Island</span></span></td>
    <td><span data-ttu-id="06854-292">北マリアナ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-292">Northern Mariana Islands</span></span></td>
    <td><span data-ttu-id="06854-293">ノルウェー \*</span><span class="sxs-lookup"><span data-stu-id="06854-293">Norway \*</span></span></td>
    <td><span data-ttu-id="06854-294">オマーン</span><span class="sxs-lookup"><span data-stu-id="06854-294">Oman</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-295">パキスタン</span><span class="sxs-lookup"><span data-stu-id="06854-295">Pakistan</span></span></td>
    <td><span data-ttu-id="06854-296">パラオ</span><span class="sxs-lookup"><span data-stu-id="06854-296">Palau</span></span></td>
    <td><span data-ttu-id="06854-297">パレスチナ自治政府</span><span class="sxs-lookup"><span data-stu-id="06854-297">Palestinian Authority</span></span></td>
    <td><span data-ttu-id="06854-298">パナマ</span><span class="sxs-lookup"><span data-stu-id="06854-298">Panama</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-299">パプアニューギニア</span><span class="sxs-lookup"><span data-stu-id="06854-299">Papua New Guinea</span></span></td>
    <td><span data-ttu-id="06854-300">パラグアイ</span><span class="sxs-lookup"><span data-stu-id="06854-300">Paraguay</span></span></td>
    <td><span data-ttu-id="06854-301">ペルー</span><span class="sxs-lookup"><span data-stu-id="06854-301">Peru</span></span></td>
    <td><span data-ttu-id="06854-302">フィリピン</span><span class="sxs-lookup"><span data-stu-id="06854-302">Philippines</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-303">ピトケアン島</span><span class="sxs-lookup"><span data-stu-id="06854-303">Pitcairn Islands</span></span></td>
    <td><span data-ttu-id="06854-304">ポーランド \*</span><span class="sxs-lookup"><span data-stu-id="06854-304">Poland \*</span></span></td>
    <td><span data-ttu-id="06854-305">ポルトガル \*</span><span class="sxs-lookup"><span data-stu-id="06854-305">Portugal \*</span></span></td>
    <td><span data-ttu-id="06854-306">カタール</span><span class="sxs-lookup"><span data-stu-id="06854-306">Qatar</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-307">レユニオン</span><span class="sxs-lookup"><span data-stu-id="06854-307">Réunion</span></span></td>
    <td><span data-ttu-id="06854-308">ルーマニア</span><span class="sxs-lookup"><span data-stu-id="06854-308">Romania</span></span></td>
    <td><span data-ttu-id="06854-309">ロシア \*</span><span class="sxs-lookup"><span data-stu-id="06854-309">Russia \*</span></span></td>
    <td><span data-ttu-id="06854-310">ルワンダ</span><span class="sxs-lookup"><span data-stu-id="06854-310">Rwanda</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-311">サン・バルテルミー</span><span class="sxs-lookup"><span data-stu-id="06854-311">Saint Barthélemy</span></span></td>
    <td><span data-ttu-id="06854-312">セントヘレナ、アセンションおよびトリスタンダクーニャ</span><span class="sxs-lookup"><span data-stu-id="06854-312">Saint Helena, Ascension and Tristan da Cunha</span></span></td>
    <td><span data-ttu-id="06854-313">セントクリストファー・ネイビス</span><span class="sxs-lookup"><span data-stu-id="06854-313">Saint Kitts and Nevis</span></span></td>
    <td><span data-ttu-id="06854-314">セントルシア</span><span class="sxs-lookup"><span data-stu-id="06854-314">Saint Lucia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-315">サンマルタン島 (フランス領)</span><span class="sxs-lookup"><span data-stu-id="06854-315">Saint Martin (French Part)</span></span></td>
    <td><span data-ttu-id="06854-316">サンピエール・ミクロン</span><span class="sxs-lookup"><span data-stu-id="06854-316">Saint Pierre and Miquelon</span></span></td>
    <td><span data-ttu-id="06854-317">セントビンセントおよびグレナディーン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-317">Saint Vincent and the Grenadines</span></span></td>
    <td><span data-ttu-id="06854-318">サモア独立国</span><span class="sxs-lookup"><span data-stu-id="06854-318">Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-319">サンマリノ</span><span class="sxs-lookup"><span data-stu-id="06854-319">San Marino</span></span></td>
    <td><span data-ttu-id="06854-320">サントメ・プリンシペ</span><span class="sxs-lookup"><span data-stu-id="06854-320">São Tomé and Príncipe</span></span></td>
    <td><span data-ttu-id="06854-321">サウジアラビア \*</span><span class="sxs-lookup"><span data-stu-id="06854-321">Saudi Arabia \*</span></span></td>
    <td><span data-ttu-id="06854-322">セネガル</span><span class="sxs-lookup"><span data-stu-id="06854-322">Senegal</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-323">セルビア</span><span class="sxs-lookup"><span data-stu-id="06854-323">Serbia</span></span></td>
    <td><span data-ttu-id="06854-324">セーシェル</span><span class="sxs-lookup"><span data-stu-id="06854-324">Seychelles</span></span></td>
    <td><span data-ttu-id="06854-325">シエラレオネ</span><span class="sxs-lookup"><span data-stu-id="06854-325">Sierra Leone</span></span></td>
    <td><span data-ttu-id="06854-326">シンガポール \*</span><span class="sxs-lookup"><span data-stu-id="06854-326">Singapore \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-327">サンマルタン島 (オランダ領)</span><span class="sxs-lookup"><span data-stu-id="06854-327">Sint Maarten (Dutch Part)</span></span></td>
    <td><span data-ttu-id="06854-328">スロバキア \*</span><span class="sxs-lookup"><span data-stu-id="06854-328">Slovakia \*</span></span></td>
    <td><span data-ttu-id="06854-329">スロベニア</span><span class="sxs-lookup"><span data-stu-id="06854-329">Slovenia</span></span></td>
    <td><span data-ttu-id="06854-330">ソロモン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-330">Solomon Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-331">ソマリア</span><span class="sxs-lookup"><span data-stu-id="06854-331">Somalia</span></span></td>
    <td><span data-ttu-id="06854-332">南アフリカ \*</span><span class="sxs-lookup"><span data-stu-id="06854-332">South Africa \*</span></span></td>
    <td><span data-ttu-id="06854-333">サウスジョージア・サウスサンドウィッチ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-333">South Georgia and the South Sandwich Islands</span></span></td>
    <td><span data-ttu-id="06854-334">スペイン \*</span><span class="sxs-lookup"><span data-stu-id="06854-334">Spain \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-335">スリランカ</span><span class="sxs-lookup"><span data-stu-id="06854-335">Sri Lanka</span></span></td>
    <td><span data-ttu-id="06854-336">スリナム</span><span class="sxs-lookup"><span data-stu-id="06854-336">Suriname</span></span></td>
    <td><span data-ttu-id="06854-337">スバールバル諸島、ヤンマイエン島</span><span class="sxs-lookup"><span data-stu-id="06854-337">Svalbard and Jan Mayen</span></span></td>
    <td><span data-ttu-id="06854-338">スワジランド</span><span class="sxs-lookup"><span data-stu-id="06854-338">Swaziland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-339">スウェーデン \*</span><span class="sxs-lookup"><span data-stu-id="06854-339">Sweden \*</span></span></td>
    <td><span data-ttu-id="06854-340">スイス \*</span><span class="sxs-lookup"><span data-stu-id="06854-340">Switzerland \*</span></span></td>
    <td><span data-ttu-id="06854-341">台湾 \*</span><span class="sxs-lookup"><span data-stu-id="06854-341">Taiwan \*</span></span></td>
    <td><span data-ttu-id="06854-342">タジキスタン</span><span class="sxs-lookup"><span data-stu-id="06854-342">Tajikistan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-343">タンザニア</span><span class="sxs-lookup"><span data-stu-id="06854-343">Tanzania</span></span></td>
    <td><span data-ttu-id="06854-344">タイ</span><span class="sxs-lookup"><span data-stu-id="06854-344">Thailand</span></span></td>
    <td><span data-ttu-id="06854-345">ティモール・レステ</span><span class="sxs-lookup"><span data-stu-id="06854-345">Timor-Leste</span></span></td>
    <td><span data-ttu-id="06854-346">トーゴ</span><span class="sxs-lookup"><span data-stu-id="06854-346">Togo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-347">トケラウ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-347">Tokelau</span></span></td>
    <td><span data-ttu-id="06854-348">トンガ</span><span class="sxs-lookup"><span data-stu-id="06854-348">Tonga</span></span></td>
    <td><span data-ttu-id="06854-349">トリニダード・トバゴ</span><span class="sxs-lookup"><span data-stu-id="06854-349">Trinidad and Tobago</span></span></td>
    <td><span data-ttu-id="06854-350">チュニジア</span><span class="sxs-lookup"><span data-stu-id="06854-350">Tunisia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-351">トルコ \*</span><span class="sxs-lookup"><span data-stu-id="06854-351">Turkey \*</span></span></td>
    <td><span data-ttu-id="06854-352">トルクメニスタン</span><span class="sxs-lookup"><span data-stu-id="06854-352">Turkmenistan</span></span></td>
    <td><span data-ttu-id="06854-353">タークス・カイコス諸島</span><span class="sxs-lookup"><span data-stu-id="06854-353">Turks and Caicos Islands</span></span></td>
    <td><span data-ttu-id="06854-354">ツバル</span><span class="sxs-lookup"><span data-stu-id="06854-354">Tuvalu</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-355">その他の米領諸島</span><span class="sxs-lookup"><span data-stu-id="06854-355">U.S. Minor Outlying Islands</span></span></td>
    <td><span data-ttu-id="06854-356">米領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-356">U.S. Virgin Islands</span></span></td>
    <td><span data-ttu-id="06854-357">ウガンダ</span><span class="sxs-lookup"><span data-stu-id="06854-357">Uganda</span></span></td>
    <td><span data-ttu-id="06854-358">ウクライナ</span><span class="sxs-lookup"><span data-stu-id="06854-358">Ukraine</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-359">アラブ首長国連邦 \*</span><span class="sxs-lookup"><span data-stu-id="06854-359">United Arab Emirates \*</span></span></td>
    <td><span data-ttu-id="06854-360">英国 \*</span><span class="sxs-lookup"><span data-stu-id="06854-360">United Kingdom \*</span></span></td>
    <td><span data-ttu-id="06854-361">米国 \*</span><span class="sxs-lookup"><span data-stu-id="06854-361">United States \*</span></span></td>
    <td><span data-ttu-id="06854-362">ウルグアイ</span><span class="sxs-lookup"><span data-stu-id="06854-362">Uruguay</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-363">ウズベキスタン</span><span class="sxs-lookup"><span data-stu-id="06854-363">Uzbekistan</span></span></td>
    <td><span data-ttu-id="06854-364">バヌアツ</span><span class="sxs-lookup"><span data-stu-id="06854-364">Vanuatu</span></span></td>
    <td><span data-ttu-id="06854-365">バチカン市国</span><span class="sxs-lookup"><span data-stu-id="06854-365">Vatican City</span></span></td>
    <td><span data-ttu-id="06854-366">ベネズエラ</span><span class="sxs-lookup"><span data-stu-id="06854-366">Venezuela</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-367">ベトナム</span><span class="sxs-lookup"><span data-stu-id="06854-367">Vietnam</span></span></td>
    <td><span data-ttu-id="06854-368">ワリス・フテュナ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-368">Wallis and Futuna</span></span></td>
    <td><span data-ttu-id="06854-369">西サハラ (紛争中)</span><span class="sxs-lookup"><span data-stu-id="06854-369">Western Sahara (Disputed)</span></span></td>
    <td><span data-ttu-id="06854-370">イエメン</span><span class="sxs-lookup"><span data-stu-id="06854-370">Yemen</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-371">ザンビア</span><span class="sxs-lookup"><span data-stu-id="06854-371">Zambia</span></span></td>
    <td><span data-ttu-id="06854-372">ジンバブエ</span><span class="sxs-lookup"><span data-stu-id="06854-372">Zimbabwe</span></span></td>
    <td></td>
    <td></td>
  </tr>
</table>


## <a name="price-considerations-for-specific-markets"></a><span data-ttu-id="06854-373">特定の市場の価格に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="06854-373">Price considerations for specific markets</span></span>

<span data-ttu-id="06854-374">ギフトカードや携帯電話会社による課金などの支払方法は、有料アプリおよびアプリ内購入アイテムの販売の増加に役立つ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="06854-374">Payment methods such as gift cards and mobile operator billing can help increase sales of paid apps and in-app purchase items.</span></span> <span data-ttu-id="06854-375">このような支払い方法を可能にするためのコストは高額になるため、下の表に示す国/地域および支払い方法については、ストア手数料に Commerce Expansion Adjustment (商取引拡大調整) を加え、純収益から差し引いて、有料アプリやアプリ内購入トランザクションに対して支払われるアプリの収益を計算します。</span><span class="sxs-lookup"><span data-stu-id="06854-375">Due to the higher costs to enable such payment methods, a Commerce Expansion Adjustment is added to the Store Fee deducted from Net Receipts to calculate the App Proceeds payable for paid apps and in-app purchase transactions in the countries/regions and using the payment methods in the tables below.</span></span> <span data-ttu-id="06854-376">お客様のアプリが利用可能な国/地域で Commerce Expansion Adjustment (商取引拡大調整) が適用されるかどうかを考慮し、それを市場の価格設定戦略に組み込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="06854-376">You may want to consider if the Commerce Expansion Adjustment applies in a country/region where your app is available and factor that into your market pricing strategy.</span></span> <span data-ttu-id="06854-377">Commerce Expansion Adjustment について詳しくは、「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06854-377">Details about the Commerce Expansion Adjustment can be found in the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement).</span></span>

<span data-ttu-id="06854-378">Commerce Expansion Adjustment は、有効日現在、指定された国/地域および支払い方法で処理されるすべての取引に適用されます。</span><span class="sxs-lookup"><span data-stu-id="06854-378">The Commerce Expansion Adjustment will be applied to all transactions processed for the specified Country/Region and Payment Methods as of the Effective Date.</span></span> <span data-ttu-id="06854-379">この情報は毎月更新され、新しい国/地域および支払方法で Commerce Expansion Adjustment が有効になった日から 30 日以内に、その国/地域および支払方法が一覧表示されます。</span><span class="sxs-lookup"><span data-stu-id="06854-379">This information will be updated monthly; new countries/regions and payment methods will be listed within thirty (30) days after the Commerce Expansion Adjustment takes effect for that country/region and payment method.</span></span>

&nbsp;

| <span data-ttu-id="06854-380">国/地域</span><span class="sxs-lookup"><span data-stu-id="06854-380">Country/region</span></span>       | <span data-ttu-id="06854-381">支払い方法</span><span class="sxs-lookup"><span data-stu-id="06854-381">Payment method</span></span>  | <span data-ttu-id="06854-382">Commerce Expansion Adjustment (商取引拡大調整)</span><span class="sxs-lookup"><span data-stu-id="06854-382">Commerce Expansion Adjustment</span></span> | <span data-ttu-id="06854-383">有効日</span><span class="sxs-lookup"><span data-stu-id="06854-383">Effective date</span></span> |
|----------------------|-----------------|-------------------------------|----------------|
| <span data-ttu-id="06854-384">アルゼンチン</span><span class="sxs-lookup"><span data-stu-id="06854-384">Argentina</span></span>            | <span data-ttu-id="06854-385">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-385">Gift card</span></span>       | <span data-ttu-id="06854-386">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-386">2.24%</span></span>                         | <span data-ttu-id="06854-387">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-387">March 2016</span></span>     |
| <span data-ttu-id="06854-388">オーストラリア</span><span class="sxs-lookup"><span data-stu-id="06854-388">Australia</span></span>            | <span data-ttu-id="06854-389">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-389">Gift card</span></span>       | <span data-ttu-id="06854-390">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-390">2.24%</span></span>                         | <span data-ttu-id="06854-391">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-391">March 2016</span></span>     |
| <span data-ttu-id="06854-392">オーストリア</span><span class="sxs-lookup"><span data-stu-id="06854-392">Austria</span></span>              | <span data-ttu-id="06854-393">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-393">Gift card</span></span>       | <span data-ttu-id="06854-394">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-394">2.24%</span></span>                         | <span data-ttu-id="06854-395">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-395">March 2016</span></span>     |
| <span data-ttu-id="06854-396">ベルギー</span><span class="sxs-lookup"><span data-stu-id="06854-396">Belgium</span></span>              | <span data-ttu-id="06854-397">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-397">Gift card</span></span>       | <span data-ttu-id="06854-398">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-398">2.24%</span></span>                         | <span data-ttu-id="06854-399">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-399">March 2016</span></span>     |
| <span data-ttu-id="06854-400">ブラジル</span><span class="sxs-lookup"><span data-stu-id="06854-400">Brazil</span></span>               | <span data-ttu-id="06854-401">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-401">Gift card</span></span>       | <span data-ttu-id="06854-402">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-402">2.24%</span></span>                         | <span data-ttu-id="06854-403">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-403">March 2016</span></span>     |
| <span data-ttu-id="06854-404">カナダ</span><span class="sxs-lookup"><span data-stu-id="06854-404">Canada</span></span>               | <span data-ttu-id="06854-405">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-405">Gift card</span></span>       | <span data-ttu-id="06854-406">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-406">2.24%</span></span>                         | <span data-ttu-id="06854-407">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-407">March 2016</span></span>     |
| <span data-ttu-id="06854-408">チリ</span><span class="sxs-lookup"><span data-stu-id="06854-408">Chile</span></span>                | <span data-ttu-id="06854-409">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-409">Gift card</span></span>       | <span data-ttu-id="06854-410">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-410">2.24%</span></span>                         | <span data-ttu-id="06854-411">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-411">March 2016</span></span>     |
| <span data-ttu-id="06854-412">中国</span><span class="sxs-lookup"><span data-stu-id="06854-412">China</span></span>                | <span data-ttu-id="06854-413">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-413">Gift card</span></span>       | <span data-ttu-id="06854-414">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-414">2.24%</span></span>                         | <span data-ttu-id="06854-415">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-415">March 2016</span></span>     |
| <span data-ttu-id="06854-416">コロンビア</span><span class="sxs-lookup"><span data-stu-id="06854-416">Colombia</span></span>             | <span data-ttu-id="06854-417">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-417">Gift card</span></span>       | <span data-ttu-id="06854-418">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-418">2.24%</span></span>                         | <span data-ttu-id="06854-419">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-419">March 2016</span></span>     |
| <span data-ttu-id="06854-420">チェコ共和国</span><span class="sxs-lookup"><span data-stu-id="06854-420">Czech Republic</span></span>       | <span data-ttu-id="06854-421">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-421">Gift card</span></span>       | <span data-ttu-id="06854-422">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-422">2.24%</span></span>                         | <span data-ttu-id="06854-423">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-423">March 2016</span></span>     |
| <span data-ttu-id="06854-424">デンマーク</span><span class="sxs-lookup"><span data-stu-id="06854-424">Denmark</span></span>              | <span data-ttu-id="06854-425">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-425">Gift card</span></span>       | <span data-ttu-id="06854-426">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-426">2.24%</span></span>                         | <span data-ttu-id="06854-427">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-427">March 2016</span></span>     |
| <span data-ttu-id="06854-428">フィンランド</span><span class="sxs-lookup"><span data-stu-id="06854-428">Finland</span></span>              | <span data-ttu-id="06854-429">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-429">Gift card</span></span>       | <span data-ttu-id="06854-430">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-430">2.24%</span></span>                         | <span data-ttu-id="06854-431">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-431">March 2016</span></span>     |
| <span data-ttu-id="06854-432">フランス</span><span class="sxs-lookup"><span data-stu-id="06854-432">France</span></span>               | <span data-ttu-id="06854-433">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-433">Gift card</span></span>       | <span data-ttu-id="06854-434">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-434">2.24%</span></span>                         | <span data-ttu-id="06854-435">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-435">March 2016</span></span>     |
| <span data-ttu-id="06854-436">ドイツ</span><span class="sxs-lookup"><span data-stu-id="06854-436">Germany</span></span>              | <span data-ttu-id="06854-437">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-437">Gift card</span></span>       | <span data-ttu-id="06854-438">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-438">2.24%</span></span>                         | <span data-ttu-id="06854-439">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-439">March 2016</span></span>     |
| <span data-ttu-id="06854-440">ギリシャ</span><span class="sxs-lookup"><span data-stu-id="06854-440">Greece</span></span>               | <span data-ttu-id="06854-441">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-441">Gift card</span></span>       | <span data-ttu-id="06854-442">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-442">2.24%</span></span>                         | <span data-ttu-id="06854-443">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-443">March 2016</span></span>     |
| <span data-ttu-id="06854-444">香港</span><span class="sxs-lookup"><span data-stu-id="06854-444">Hong Kong</span></span>            | <span data-ttu-id="06854-445">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-445">Gift card</span></span>       | <span data-ttu-id="06854-446">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-446">2.24%</span></span>                         | <span data-ttu-id="06854-447">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-447">March 2016</span></span>     |
| <span data-ttu-id="06854-448">ハンガリー</span><span class="sxs-lookup"><span data-stu-id="06854-448">Hungary</span></span>              | <span data-ttu-id="06854-449">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-449">Gift card</span></span>       | <span data-ttu-id="06854-450">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-450">2.24%</span></span>                         | <span data-ttu-id="06854-451">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-451">March 2016</span></span>     |
| <span data-ttu-id="06854-452">インド</span><span class="sxs-lookup"><span data-stu-id="06854-452">India</span></span>                | <span data-ttu-id="06854-453">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-453">Gift card</span></span>       | <span data-ttu-id="06854-454">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-454">2.24%</span></span>                         | <span data-ttu-id="06854-455">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-455">March 2016</span></span>     |
| <span data-ttu-id="06854-456">アイルランド</span><span class="sxs-lookup"><span data-stu-id="06854-456">Ireland</span></span>              | <span data-ttu-id="06854-457">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-457">Gift card</span></span>       | <span data-ttu-id="06854-458">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-458">2.24%</span></span>                         | <span data-ttu-id="06854-459">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-459">March 2016</span></span>     |
| <span data-ttu-id="06854-460">イスラエル</span><span class="sxs-lookup"><span data-stu-id="06854-460">Israel</span></span>               | <span data-ttu-id="06854-461">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-461">Gift card</span></span>       | <span data-ttu-id="06854-462">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-462">2.24%</span></span>                         | <span data-ttu-id="06854-463">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-463">March 2016</span></span>     |
| <span data-ttu-id="06854-464">イタリア</span><span class="sxs-lookup"><span data-stu-id="06854-464">Italy</span></span>                | <span data-ttu-id="06854-465">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-465">Gift card</span></span>       | <span data-ttu-id="06854-466">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-466">2.24%</span></span>                         | <span data-ttu-id="06854-467">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-467">March 2016</span></span>     |
| <span data-ttu-id="06854-468">日本</span><span class="sxs-lookup"><span data-stu-id="06854-468">Japan</span></span>                | <span data-ttu-id="06854-469">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-469">Gift card</span></span>       | <span data-ttu-id="06854-470">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-470">2.24%</span></span>                         | <span data-ttu-id="06854-471">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-471">March 2016</span></span>     |
| <span data-ttu-id="06854-472">メキシコ</span><span class="sxs-lookup"><span data-stu-id="06854-472">Mexico</span></span>               | <span data-ttu-id="06854-473">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-473">Gift card</span></span>       | <span data-ttu-id="06854-474">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-474">2.24%</span></span>                         | <span data-ttu-id="06854-475">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-475">March 2016</span></span>     |
| <span data-ttu-id="06854-476">オランダ</span><span class="sxs-lookup"><span data-stu-id="06854-476">Netherlands</span></span>          | <span data-ttu-id="06854-477">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-477">Gift card</span></span>       | <span data-ttu-id="06854-478">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-478">2.24%</span></span>                         | <span data-ttu-id="06854-479">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-479">March 2016</span></span>     |
| <span data-ttu-id="06854-480">ニュージーランド</span><span class="sxs-lookup"><span data-stu-id="06854-480">New Zealand</span></span>          | <span data-ttu-id="06854-481">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-481">Gift card</span></span>       | <span data-ttu-id="06854-482">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-482">2.24%</span></span>                         | <span data-ttu-id="06854-483">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-483">March 2016</span></span>     |
| <span data-ttu-id="06854-484">ポーランド</span><span class="sxs-lookup"><span data-stu-id="06854-484">Poland</span></span>               | <span data-ttu-id="06854-485">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-485">Gift card</span></span>       | <span data-ttu-id="06854-486">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-486">2.24%</span></span>                         | <span data-ttu-id="06854-487">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-487">March 2016</span></span>     |
| <span data-ttu-id="06854-488">ポルトガル</span><span class="sxs-lookup"><span data-stu-id="06854-488">Portugal</span></span>             | <span data-ttu-id="06854-489">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-489">Gift card</span></span>       | <span data-ttu-id="06854-490">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-490">2.24%</span></span>                         | <span data-ttu-id="06854-491">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-491">March 2016</span></span>     |
| <span data-ttu-id="06854-492">ロシア</span><span class="sxs-lookup"><span data-stu-id="06854-492">Russia</span></span>               | <span data-ttu-id="06854-493">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-493">Gift card</span></span>       | <span data-ttu-id="06854-494">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-494">2.24%</span></span>                         | <span data-ttu-id="06854-495">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-495">March 2016</span></span>     |
| <span data-ttu-id="06854-496">サウジアラビア</span><span class="sxs-lookup"><span data-stu-id="06854-496">Saudi Arabia</span></span>         | <span data-ttu-id="06854-497">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-497">Gift card</span></span>       | <span data-ttu-id="06854-498">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-498">2.24%</span></span>                         | <span data-ttu-id="06854-499">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-499">March 2016</span></span>     |
| <span data-ttu-id="06854-500">シンガポール</span><span class="sxs-lookup"><span data-stu-id="06854-500">Singapore</span></span>            | <span data-ttu-id="06854-501">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-501">Gift card</span></span>       | <span data-ttu-id="06854-502">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-502">2.24%</span></span>                         | <span data-ttu-id="06854-503">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-503">March 2016</span></span>     |
| <span data-ttu-id="06854-504">スロバキア</span><span class="sxs-lookup"><span data-stu-id="06854-504">Slovakia</span></span>             | <span data-ttu-id="06854-505">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-505">Gift card</span></span>       | <span data-ttu-id="06854-506">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-506">2.24%</span></span>                         | <span data-ttu-id="06854-507">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-507">March 2016</span></span>     |
| <span data-ttu-id="06854-508">南アフリカ</span><span class="sxs-lookup"><span data-stu-id="06854-508">South Africa</span></span>         | <span data-ttu-id="06854-509">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-509">Gift card</span></span>       | <span data-ttu-id="06854-510">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-510">2.24%</span></span>                         | <span data-ttu-id="06854-511">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-511">March 2016</span></span>     |
| <span data-ttu-id="06854-512">韓国</span><span class="sxs-lookup"><span data-stu-id="06854-512">South Korea</span></span>          | <span data-ttu-id="06854-513">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-513">Gift card</span></span>       | <span data-ttu-id="06854-514">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-514">2.24%</span></span>                         | <span data-ttu-id="06854-515">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-515">March 2016</span></span>     |
| <span data-ttu-id="06854-516">スペイン</span><span class="sxs-lookup"><span data-stu-id="06854-516">Spain</span></span>                | <span data-ttu-id="06854-517">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-517">Gift card</span></span>       | <span data-ttu-id="06854-518">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-518">2.24%</span></span>                         | <span data-ttu-id="06854-519">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-519">March 2016</span></span>     |
| <span data-ttu-id="06854-520">スウェーデン</span><span class="sxs-lookup"><span data-stu-id="06854-520">Sweden</span></span>               | <span data-ttu-id="06854-521">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-521">Gift card</span></span>       | <span data-ttu-id="06854-522">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-522">2.24%</span></span>                         | <span data-ttu-id="06854-523">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-523">March 2016</span></span>     |
| <span data-ttu-id="06854-524">スイス</span><span class="sxs-lookup"><span data-stu-id="06854-524">Switzerland</span></span>          | <span data-ttu-id="06854-525">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-525">Gift card</span></span>       | <span data-ttu-id="06854-526">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-526">2.24%</span></span>                         | <span data-ttu-id="06854-527">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-527">March 2016</span></span>     |
| <span data-ttu-id="06854-528">台湾</span><span class="sxs-lookup"><span data-stu-id="06854-528">Taiwan</span></span>               | <span data-ttu-id="06854-529">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-529">Gift card</span></span>       | <span data-ttu-id="06854-530">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-530">2.24%</span></span>                         | <span data-ttu-id="06854-531">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-531">March 2016</span></span>     |
| <span data-ttu-id="06854-532">トルコ</span><span class="sxs-lookup"><span data-stu-id="06854-532">Turkey</span></span>               | <span data-ttu-id="06854-533">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-533">Gift card</span></span>       | <span data-ttu-id="06854-534">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-534">2.24%</span></span>                         | <span data-ttu-id="06854-535">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-535">March 2016</span></span>     |
| <span data-ttu-id="06854-536">アラブ首長国連邦</span><span class="sxs-lookup"><span data-stu-id="06854-536">United Arab Emirates</span></span> | <span data-ttu-id="06854-537">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-537">Gift card</span></span>       | <span data-ttu-id="06854-538">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-538">2.24%</span></span>                         | <span data-ttu-id="06854-539">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-539">March 2016</span></span>     |
| <span data-ttu-id="06854-540">英国</span><span class="sxs-lookup"><span data-stu-id="06854-540">United Kingdom</span></span>       | <span data-ttu-id="06854-541">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-541">Gift card</span></span>       | <span data-ttu-id="06854-542">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-542">2.24%</span></span>                         | <span data-ttu-id="06854-543">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-543">March 2016</span></span>     |
| <span data-ttu-id="06854-544">米国</span><span class="sxs-lookup"><span data-stu-id="06854-544">United States</span></span>        | <span data-ttu-id="06854-545">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="06854-545">Gift card</span></span>       | <span data-ttu-id="06854-546">2.24%</span><span class="sxs-lookup"><span data-stu-id="06854-546">2.24%</span></span>                         | <span data-ttu-id="06854-547">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="06854-547">March 2016</span></span>     |

 

## <a name="rest-of-world-markets-for-windows-8x"></a><span data-ttu-id="06854-548">Windows 8.x の "その他の国と地域" 市場</span><span class="sxs-lookup"><span data-stu-id="06854-548">"Rest of World" markets for Windows 8.x</span></span>

<span data-ttu-id="06854-549">以前に公開されたアプリが Windows をターゲットとするパッケージを含むかどうか 8.x はさまざまな市場が windows ストアを使っているユーザーの単一「残りの部分の国と地域」市場として扱うことに注意する重要な 8.x、個別の市場として表示されている場合でもパートナー センター。</span><span class="sxs-lookup"><span data-stu-id="06854-549">If your previously-published app includes packages targeting Windows 8.x, it's important to be aware that a number of markets are treated as a single "Rest of World" market for customers using the Store on Windows 8.x, even though they are shown as individual markets in Partner Center.</span></span>

<span data-ttu-id="06854-550">アプリを提出するときに既定の市場の選択が終了した場合、この問題について心配する必要はなく、アプリがすべての市場で使用できます。</span><span class="sxs-lookup"><span data-stu-id="06854-550">If you leave the default market selection when submitting your app, you don't have to worry about this, and your app will be available to all possible markets.</span></span> <span data-ttu-id="06854-551">ただし、特定の市場を除外する場合は、以下の「残りの部分の国と地域」市場のいずれかのでも、アプリを*任意*のユーザー向けに Windows8 または Windows8.1「残りの部分の国と地域」市場で利用可能にしないことを意味することに留意してください。</span><span class="sxs-lookup"><span data-stu-id="06854-551">However, if you want to exclude certain markets, keep in mind that excluding even one of these "Rest of World" markets means that your app won't be available in *any* of the "Rest of World" markets for customers on Windows8 or Windows8.1.</span></span>

<span data-ttu-id="06854-552">Windows 8.x 向けの "その他の国と地域" に含まれている市場は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="06854-552">The markets that are included in "Rest of World" for Windows 8.x are the following:</span></span>

<table>
  <tr>
    <td><span data-ttu-id="06854-553">アフガニスタン</span><span class="sxs-lookup"><span data-stu-id="06854-553">Afghanistan</span></span></td>
    <td><span data-ttu-id="06854-554">オーランド諸島</span><span class="sxs-lookup"><span data-stu-id="06854-554">Åland Islands</span></span></td>
    <td><span data-ttu-id="06854-555">アルバニア</span><span class="sxs-lookup"><span data-stu-id="06854-555">Albania</span></span></td>
    <td><span data-ttu-id="06854-556">アメリカ領サモア</span><span class="sxs-lookup"><span data-stu-id="06854-556">American Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-557">アンドラ</span><span class="sxs-lookup"><span data-stu-id="06854-557">Andorra</span></span></td>
    <td><span data-ttu-id="06854-558">アンゴラ</span><span class="sxs-lookup"><span data-stu-id="06854-558">Angola</span></span></td>
    <td><span data-ttu-id="06854-559">アンギラ</span><span class="sxs-lookup"><span data-stu-id="06854-559">Anguilla</span></span></td>
    <td><span data-ttu-id="06854-560">南極</span><span class="sxs-lookup"><span data-stu-id="06854-560">Antarctica</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-561">アンティグア・バーブーダ</span><span class="sxs-lookup"><span data-stu-id="06854-561">Antigua and Barbuda</span></span></td>
    <td><span data-ttu-id="06854-562">アルメニア</span><span class="sxs-lookup"><span data-stu-id="06854-562">Armenia</span></span></td>
    <td><span data-ttu-id="06854-563">アルバ</span><span class="sxs-lookup"><span data-stu-id="06854-563">Aruba</span></span></td>
    <td><span data-ttu-id="06854-564">アゼルバイジャン</span><span class="sxs-lookup"><span data-stu-id="06854-564">Azerbaijan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-565">バハマ</span><span class="sxs-lookup"><span data-stu-id="06854-565">Bahamas</span></span></td>
    <td><span data-ttu-id="06854-566">バングラデシュ</span><span class="sxs-lookup"><span data-stu-id="06854-566">Bangladesh</span></span></td>
    <td><span data-ttu-id="06854-567">バルバドス</span><span class="sxs-lookup"><span data-stu-id="06854-567">Barbados</span></span></td>
    <td><span data-ttu-id="06854-568">ベラルーシ</span><span class="sxs-lookup"><span data-stu-id="06854-568">Belarus</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-569">ベリーズ</span><span class="sxs-lookup"><span data-stu-id="06854-569">Belize</span></span></td>
    <td><span data-ttu-id="06854-570">ベナン</span><span class="sxs-lookup"><span data-stu-id="06854-570">Benin</span></span></td>
    <td><span data-ttu-id="06854-571">バミューダ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-571">Bermuda</span></span></td>
    <td><span data-ttu-id="06854-572">ブータン</span><span class="sxs-lookup"><span data-stu-id="06854-572">Bhutan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-573">ボリビア</span><span class="sxs-lookup"><span data-stu-id="06854-573">Bolivia</span></span></td>
    <td><span data-ttu-id="06854-574">ボネール島</span><span class="sxs-lookup"><span data-stu-id="06854-574">Bonaire</span></span></td>
    <td><span data-ttu-id="06854-575">ボスニア・ヘルツェゴビナ</span><span class="sxs-lookup"><span data-stu-id="06854-575">Bosnia and Herzegovina</span></span></td>
    <td><span data-ttu-id="06854-576">ボツワナ</span><span class="sxs-lookup"><span data-stu-id="06854-576">Botswana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-577">ブーベ島</span><span class="sxs-lookup"><span data-stu-id="06854-577">Bouvet Island</span></span></td>
    <td><span data-ttu-id="06854-578">英領インド洋地域</span><span class="sxs-lookup"><span data-stu-id="06854-578">British Indian Ocean Territory</span></span></td>
    <td><span data-ttu-id="06854-579">英領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-579">British Virgin Islands</span></span></td>
    <td><span data-ttu-id="06854-580">ブルネイ</span><span class="sxs-lookup"><span data-stu-id="06854-580">Brunei</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-581">ブルキナファソ</span><span class="sxs-lookup"><span data-stu-id="06854-581">Burkina Faso</span></span></td>
    <td><span data-ttu-id="06854-582">ブルンジ</span><span class="sxs-lookup"><span data-stu-id="06854-582">Burundi</span></span></td>
    <td><span data-ttu-id="06854-583">カーボベルデ</span><span class="sxs-lookup"><span data-stu-id="06854-583">Cabo Verde</span></span></td>
    <td><span data-ttu-id="06854-584">カンボジア</span><span class="sxs-lookup"><span data-stu-id="06854-584">Cambodia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-585">カメルーン</span><span class="sxs-lookup"><span data-stu-id="06854-585">Cameroon</span></span></td>
    <td><span data-ttu-id="06854-586">ケイマン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-586">Cayman Islands</span></span></td>
    <td><span data-ttu-id="06854-587">中央アフリカ共和国</span><span class="sxs-lookup"><span data-stu-id="06854-587">Central African Republic</span></span></td>
    <td><span data-ttu-id="06854-588">チャド</span><span class="sxs-lookup"><span data-stu-id="06854-588">Chad</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-589">クリスマス島</span><span class="sxs-lookup"><span data-stu-id="06854-589">Christmas Island</span></span></td>
    <td><span data-ttu-id="06854-590">ココス諸島</span><span class="sxs-lookup"><span data-stu-id="06854-590">Cocos (Keeling) Islands</span></span></td>
    <td><span data-ttu-id="06854-591">コモロ</span><span class="sxs-lookup"><span data-stu-id="06854-591">Comoros</span></span></td>
    <td><span data-ttu-id="06854-592">コンゴ共和国</span><span class="sxs-lookup"><span data-stu-id="06854-592">Congo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-593">コンゴ民主共和国</span><span class="sxs-lookup"><span data-stu-id="06854-593">Congo (DRC)</span></span></td>
    <td><span data-ttu-id="06854-594">クック諸島</span><span class="sxs-lookup"><span data-stu-id="06854-594">Cook Islands</span></span></td>
    <td><span data-ttu-id="06854-595">コートジボワール</span><span class="sxs-lookup"><span data-stu-id="06854-595">Côte d’Ivoire</span></span></td>
    <td><span data-ttu-id="06854-596">キュラソー島</span><span class="sxs-lookup"><span data-stu-id="06854-596">Curaçao</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-597">ジブチ</span><span class="sxs-lookup"><span data-stu-id="06854-597">Djibouti</span></span></td>
    <td><span data-ttu-id="06854-598">ドミニカ国</span><span class="sxs-lookup"><span data-stu-id="06854-598">Dominica</span></span></td>
    <td><span data-ttu-id="06854-599">ドミニカ共和国</span><span class="sxs-lookup"><span data-stu-id="06854-599">Dominican Republic</span></span></td>
    <td><span data-ttu-id="06854-600">エクアドル</span><span class="sxs-lookup"><span data-stu-id="06854-600">Ecuador</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-601">エルサルバドル</span><span class="sxs-lookup"><span data-stu-id="06854-601">El Salvador</span></span></td>
    <td><span data-ttu-id="06854-602">赤道ギニア</span><span class="sxs-lookup"><span data-stu-id="06854-602">Equatorial Guinea</span></span></td>
    <td><span data-ttu-id="06854-603">エリトリア</span><span class="sxs-lookup"><span data-stu-id="06854-603">Eritrea</span></span></td>
    <td><span data-ttu-id="06854-604">エチオピア</span><span class="sxs-lookup"><span data-stu-id="06854-604">Ethiopia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-605">フォークランド諸島</span><span class="sxs-lookup"><span data-stu-id="06854-605">Falkland Islands</span></span></td>
    <td><span data-ttu-id="06854-606">フェロー諸島</span><span class="sxs-lookup"><span data-stu-id="06854-606">Faroe Islands</span></span></td>
    <td><span data-ttu-id="06854-607">フィジー</span><span class="sxs-lookup"><span data-stu-id="06854-607">Fiji</span></span></td>
    <td><span data-ttu-id="06854-608">フランス領ギアナ</span><span class="sxs-lookup"><span data-stu-id="06854-608">French Guiana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-609">フランス領ポリネシア</span><span class="sxs-lookup"><span data-stu-id="06854-609">French Polynesia</span></span></td>
    <td><span data-ttu-id="06854-610">フランス領南極地方</span><span class="sxs-lookup"><span data-stu-id="06854-610">French Southern and Antarctic Lands</span></span></td>
    <td><span data-ttu-id="06854-611">ガボン</span><span class="sxs-lookup"><span data-stu-id="06854-611">Gabon</span></span></td>
    <td><span data-ttu-id="06854-612">ガンビア</span><span class="sxs-lookup"><span data-stu-id="06854-612">Gambia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-613">ジョージア</span><span class="sxs-lookup"><span data-stu-id="06854-613">Georgia</span></span></td>
    <td><span data-ttu-id="06854-614">ガーナ</span><span class="sxs-lookup"><span data-stu-id="06854-614">Ghana</span></span></td>
    <td><span data-ttu-id="06854-615">ジブラルタル</span><span class="sxs-lookup"><span data-stu-id="06854-615">Gibraltar</span></span></td>
    <td><span data-ttu-id="06854-616">グリーンランド</span><span class="sxs-lookup"><span data-stu-id="06854-616">Greenland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-617">グレナダ</span><span class="sxs-lookup"><span data-stu-id="06854-617">Grenada</span></span></td>
    <td><span data-ttu-id="06854-618">グアドループ</span><span class="sxs-lookup"><span data-stu-id="06854-618">Guadeloupe</span></span></td>
    <td><span data-ttu-id="06854-619">グアム</span><span class="sxs-lookup"><span data-stu-id="06854-619">Guam</span></span></td>
    <td><span data-ttu-id="06854-620">グアテマラ</span><span class="sxs-lookup"><span data-stu-id="06854-620">Guatemala</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-621">ガーンジー島</span><span class="sxs-lookup"><span data-stu-id="06854-621">Guernsey</span></span></td>
    <td><span data-ttu-id="06854-622">ギニア</span><span class="sxs-lookup"><span data-stu-id="06854-622">Guinea</span></span></td>
    <td><span data-ttu-id="06854-623">ギニアビサウ</span><span class="sxs-lookup"><span data-stu-id="06854-623">Guinea-Bissau</span></span></td>
    <td><span data-ttu-id="06854-624">ガイアナ</span><span class="sxs-lookup"><span data-stu-id="06854-624">Guyana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-625">ハイチ</span><span class="sxs-lookup"><span data-stu-id="06854-625">Haiti</span></span></td>
    <td><span data-ttu-id="06854-626">ハード・マクドナルド諸島</span><span class="sxs-lookup"><span data-stu-id="06854-626">Heard Island and McDonald Islands</span></span></td>
    <td><span data-ttu-id="06854-627">ホンジュラス</span><span class="sxs-lookup"><span data-stu-id="06854-627">Honduras</span></span></td>
    <td><span data-ttu-id="06854-628">アイスランド</span><span class="sxs-lookup"><span data-stu-id="06854-628">Iceland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-629">マン島</span><span class="sxs-lookup"><span data-stu-id="06854-629">Isle of Man</span></span></td>
    <td><span data-ttu-id="06854-630">ジャマイカ</span><span class="sxs-lookup"><span data-stu-id="06854-630">Jamaica</span></span></td>
    <td><span data-ttu-id="06854-631">ジャージー島</span><span class="sxs-lookup"><span data-stu-id="06854-631">Jersey</span></span></td>
    <td><span data-ttu-id="06854-632">ケニア</span><span class="sxs-lookup"><span data-stu-id="06854-632">Kenya</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-633">キリバス</span><span class="sxs-lookup"><span data-stu-id="06854-633">Kiribati</span></span></td>
    <td><span data-ttu-id="06854-634">キルギス</span><span class="sxs-lookup"><span data-stu-id="06854-634">Kyrgyzstan</span></span></td>
    <td><span data-ttu-id="06854-635">ラオス</span><span class="sxs-lookup"><span data-stu-id="06854-635">Laos</span></span></td>
    <td><span data-ttu-id="06854-636">レソト</span><span class="sxs-lookup"><span data-stu-id="06854-636">Lesotho</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-637">リベリア</span><span class="sxs-lookup"><span data-stu-id="06854-637">Liberia</span></span></td>
    <td><span data-ttu-id="06854-638">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="06854-638">Liechtenstein</span></span></td>
    <td><span data-ttu-id="06854-639">マカオ</span><span class="sxs-lookup"><span data-stu-id="06854-639">Macao SAR</span></span></td>
    <td><span data-ttu-id="06854-640">マケドニア (旧ユーゴスラビア共和国)</span><span class="sxs-lookup"><span data-stu-id="06854-640">Macedonia, FYRO</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-641">マダガスカル</span><span class="sxs-lookup"><span data-stu-id="06854-641">Madagascar</span></span></td>
    <td><span data-ttu-id="06854-642">マラウイ</span><span class="sxs-lookup"><span data-stu-id="06854-642">Malawi</span></span></td>
    <td><span data-ttu-id="06854-643">モルディブ</span><span class="sxs-lookup"><span data-stu-id="06854-643">Maldives</span></span></td>
    <td><span data-ttu-id="06854-644">マリ</span><span class="sxs-lookup"><span data-stu-id="06854-644">Mali</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-645">マーシャル諸島</span><span class="sxs-lookup"><span data-stu-id="06854-645">Marshall Islands</span></span></td>
    <td><span data-ttu-id="06854-646">マルチニーク島</span><span class="sxs-lookup"><span data-stu-id="06854-646">Martinique</span></span></td>
    <td><span data-ttu-id="06854-647">モーリタニア</span><span class="sxs-lookup"><span data-stu-id="06854-647">Mauritania</span></span></td>
    <td><span data-ttu-id="06854-648">モーリシャス</span><span class="sxs-lookup"><span data-stu-id="06854-648">Mauritius</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-649">マイヨット島</span><span class="sxs-lookup"><span data-stu-id="06854-649">Mayotte</span></span></td>
    <td><span data-ttu-id="06854-650">ミクロネシア</span><span class="sxs-lookup"><span data-stu-id="06854-650">Micronesia</span></span></td>
    <td><span data-ttu-id="06854-651">モルドバ</span><span class="sxs-lookup"><span data-stu-id="06854-651">Moldova</span></span></td>
    <td><span data-ttu-id="06854-652">モナコ</span><span class="sxs-lookup"><span data-stu-id="06854-652">Monaco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-653">モンゴル</span><span class="sxs-lookup"><span data-stu-id="06854-653">Mongolia</span></span></td>
    <td><span data-ttu-id="06854-654">モンテネグロ</span><span class="sxs-lookup"><span data-stu-id="06854-654">Montenegro</span></span></td>
    <td><span data-ttu-id="06854-655">モンセラット</span><span class="sxs-lookup"><span data-stu-id="06854-655">Montserrat</span></span></td>
    <td><span data-ttu-id="06854-656">モロッコ</span><span class="sxs-lookup"><span data-stu-id="06854-656">Morocco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-657">モザンビーク</span><span class="sxs-lookup"><span data-stu-id="06854-657">Mozambique</span></span></td>
    <td><span data-ttu-id="06854-658">ミャンマー</span><span class="sxs-lookup"><span data-stu-id="06854-658">Myanmar</span></span></td>
    <td><span data-ttu-id="06854-659">ナミビア</span><span class="sxs-lookup"><span data-stu-id="06854-659">Namibia</span></span></td>
    <td><span data-ttu-id="06854-660">ナウル</span><span class="sxs-lookup"><span data-stu-id="06854-660">Nauru</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-661">ネパール</span><span class="sxs-lookup"><span data-stu-id="06854-661">Nepal</span></span></td>
    <td><span data-ttu-id="06854-662">ニューカレドニア</span><span class="sxs-lookup"><span data-stu-id="06854-662">New Caledonia</span></span></td>
    <td><span data-ttu-id="06854-663">ニカラグア</span><span class="sxs-lookup"><span data-stu-id="06854-663">Nicaragua</span></span></td>
    <td><span data-ttu-id="06854-664">ニジェール</span><span class="sxs-lookup"><span data-stu-id="06854-664">Niger</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-665">ナイジェリア</span><span class="sxs-lookup"><span data-stu-id="06854-665">Nigeria</span></span></td>
    <td><span data-ttu-id="06854-666">ニウエ</span><span class="sxs-lookup"><span data-stu-id="06854-666">Niue</span></span></td>
    <td><span data-ttu-id="06854-667">ノーフォーク島</span><span class="sxs-lookup"><span data-stu-id="06854-667">Norfolk Island</span></span></td>
    <td><span data-ttu-id="06854-668">北マリアナ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-668">Northern Mariana Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-669">パラオ</span><span class="sxs-lookup"><span data-stu-id="06854-669">Palau</span></span></td>
    <td><span data-ttu-id="06854-670">パレスチナ自治政府</span><span class="sxs-lookup"><span data-stu-id="06854-670">Palestinian Authority</span></span></td>
    <td><span data-ttu-id="06854-671">パナマ</span><span class="sxs-lookup"><span data-stu-id="06854-671">Panama</span></span></td>
    <td><span data-ttu-id="06854-672">パプアニューギニア</span><span class="sxs-lookup"><span data-stu-id="06854-672">Papua New Guinea</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-673">パラグアイ</span><span class="sxs-lookup"><span data-stu-id="06854-673">Paraguay</span></span></td>
    <td><span data-ttu-id="06854-674">ピトケアン島</span><span class="sxs-lookup"><span data-stu-id="06854-674">Pitcairn Islands</span></span></td>
    <td><span data-ttu-id="06854-675">レユニオン</span><span class="sxs-lookup"><span data-stu-id="06854-675">Réunion</span></span></td>
    <td><span data-ttu-id="06854-676">ルワンダ</span><span class="sxs-lookup"><span data-stu-id="06854-676">Rwanda</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-677">サン・バルテルミー</span><span class="sxs-lookup"><span data-stu-id="06854-677">Saint Barthélemy</span></span></td>
    <td><span data-ttu-id="06854-678">セントヘレナ、アセンションおよびトリスタンダクーニャ</span><span class="sxs-lookup"><span data-stu-id="06854-678">Saint Helena, Ascension and Tristan da Cunha</span></span></td>
    <td><span data-ttu-id="06854-679">セントクリストファー・ネイビス</span><span class="sxs-lookup"><span data-stu-id="06854-679">Saint Kitts and Nevis</span></span></td>
    <td><span data-ttu-id="06854-680">セントルシア</span><span class="sxs-lookup"><span data-stu-id="06854-680">Saint Lucia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-681">サンマルタン島 (フランス領)</span><span class="sxs-lookup"><span data-stu-id="06854-681">Saint Martin (French Part)</span></span></td>
    <td><span data-ttu-id="06854-682">サンピエール・ミクロン</span><span class="sxs-lookup"><span data-stu-id="06854-682">Saint Pierre and Miquelon</span></span></td>
    <td><span data-ttu-id="06854-683">セントビンセントおよびグレナディーン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-683">Saint Vincent and the Grenadines</span></span></td>
    <td><span data-ttu-id="06854-684">サモア独立国</span><span class="sxs-lookup"><span data-stu-id="06854-684">Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-685">サンマリノ</span><span class="sxs-lookup"><span data-stu-id="06854-685">San Marino</span></span></td>
    <td><span data-ttu-id="06854-686">サントメ・プリンシペ</span><span class="sxs-lookup"><span data-stu-id="06854-686">São Tomé and Príncipe</span></span></td>
    <td><span data-ttu-id="06854-687">セネガル</span><span class="sxs-lookup"><span data-stu-id="06854-687">Senegal</span></span></td>
    <td><span data-ttu-id="06854-688">セーシェル</span><span class="sxs-lookup"><span data-stu-id="06854-688">Seychelles</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-689">シエラレオネ</span><span class="sxs-lookup"><span data-stu-id="06854-689">Sierra Leone</span></span></td>
    <td><span data-ttu-id="06854-690">サンマルタン島 (オランダ領)</span><span class="sxs-lookup"><span data-stu-id="06854-690">Sint Maarten (Dutch Part)</span></span></td>
    <td><span data-ttu-id="06854-691">ソロモン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-691">Solomon Islands</span></span></td>
    <td><span data-ttu-id="06854-692">ソマリア</span><span class="sxs-lookup"><span data-stu-id="06854-692">Somalia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-693">サウスジョージア・サウスサンドウィッチ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-693">South Georgia and the South Sandwich Islands</span></span></td>
    <td><span data-ttu-id="06854-694">スリナム</span><span class="sxs-lookup"><span data-stu-id="06854-694">Suriname</span></span></td>
    <td><span data-ttu-id="06854-695">スバールバル諸島、ヤンマイエン島</span><span class="sxs-lookup"><span data-stu-id="06854-695">Svalbard and Jan Mayen</span></span></td>
    <td><span data-ttu-id="06854-696">スワジランド</span><span class="sxs-lookup"><span data-stu-id="06854-696">Swaziland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-697">タジキスタン</span><span class="sxs-lookup"><span data-stu-id="06854-697">Tajikistan</span></span></td>
    <td><span data-ttu-id="06854-698">タンザニア</span><span class="sxs-lookup"><span data-stu-id="06854-698">Tanzania</span></span></td>
    <td><span data-ttu-id="06854-699">ティモール・レステ</span><span class="sxs-lookup"><span data-stu-id="06854-699">Timor-Leste</span></span></td>
    <td><span data-ttu-id="06854-700">トーゴ</span><span class="sxs-lookup"><span data-stu-id="06854-700">Togo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-701">トケラウ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-701">Tokelau</span></span></td>
    <td><span data-ttu-id="06854-702">トンガ</span><span class="sxs-lookup"><span data-stu-id="06854-702">Tonga</span></span></td>
    <td><span data-ttu-id="06854-703">トルクメニスタン</span><span class="sxs-lookup"><span data-stu-id="06854-703">Turkmenistan</span></span></td>
    <td><span data-ttu-id="06854-704">タークス・カイコス諸島</span><span class="sxs-lookup"><span data-stu-id="06854-704">Turks and Caicos Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-705">ツバル</span><span class="sxs-lookup"><span data-stu-id="06854-705">Tuvalu</span></span></td>
    <td><span data-ttu-id="06854-706">ウガンダ</span><span class="sxs-lookup"><span data-stu-id="06854-706">Uganda</span></span></td>
    <td><span data-ttu-id="06854-707">その他の米領諸島</span><span class="sxs-lookup"><span data-stu-id="06854-707">U.S. Minor Outlying Islands</span></span></td>
    <td><span data-ttu-id="06854-708">米領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="06854-708">U.S. Virgin Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-709">ウズベキスタン</span><span class="sxs-lookup"><span data-stu-id="06854-709">Uzbekistan</span></span></td>
    <td><span data-ttu-id="06854-710">バチカン市国</span><span class="sxs-lookup"><span data-stu-id="06854-710">Vatican City</span></span></td>
    <td><span data-ttu-id="06854-711">ベネズエラ</span><span class="sxs-lookup"><span data-stu-id="06854-711">Venezuela</span></span></td>
    <td><span data-ttu-id="06854-712">ベトナム</span><span class="sxs-lookup"><span data-stu-id="06854-712">Vietnam</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-713">バヌアツ</span><span class="sxs-lookup"><span data-stu-id="06854-713">Vanuatu</span></span></td>
    <td><span data-ttu-id="06854-714">ワリス・フテュナ諸島</span><span class="sxs-lookup"><span data-stu-id="06854-714">Wallis and Futuna</span></span></td>
    <td><span data-ttu-id="06854-715">イエメン</span><span class="sxs-lookup"><span data-stu-id="06854-715">Yemen</span></span></td>
    <td><span data-ttu-id="06854-716">ザンビア</span><span class="sxs-lookup"><span data-stu-id="06854-716">Zambia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="06854-717">ジンバブエ</span><span class="sxs-lookup"><span data-stu-id="06854-717">Zimbabwe</span></span></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>

> [!NOTE]
> <span data-ttu-id="06854-718">開発者アカウントを登録できる国と地域の一覧については、「[アカウントの種類、場所、料金](account-types-locations-and-fees.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="06854-718">For a list of the countries and regions in which you can register for a developer account, see [Account types, locations, and fees](account-types-locations-and-fees.md).</span></span>
