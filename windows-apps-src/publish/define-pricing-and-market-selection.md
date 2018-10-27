---
author: jnHs
Description: The Microsoft Store reaches customers in over 200 countries and regions around the world.
title: 市場の選択の定義
ms.assetid: FBE7507B-DBF3-4FCB-8377-DB01660E75F8
ms.author: wdg-dev-content
ms.date: 06/07/2018
ms.topic: article
keywords: Windows 10, UWP, 市場, 国, 地域
ms.localizationpriority: medium
ms.openlocfilehash: c50f20b3e86f1868732be74b0d35933658dc3ceb
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5697610"
---
# <a name="define-market-selection"></a><span data-ttu-id="e9ff6-103">市場の選択の定義</span><span class="sxs-lookup"><span data-stu-id="e9ff6-103">Define market selection</span></span>


<span data-ttu-id="e9ff6-104">Microsoft Store は、世界中の 200 以上の国と地域のお客様が利用できます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-104">The Microsoft Store reaches customers in over 200 countries and regions around the world.</span></span> <span data-ttu-id="e9ff6-105">アプリを提供する市場を選択して、市場ごとまたは市場のグループごとに、[価格と使用可能状況](set-app-pricing-and-availability.md)の多くの機能をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-105">You can choose the markets in which you'd like to offer your app, with the option to customize many [pricing and availability](set-app-pricing-and-availability.md) features per market or per group of markets.</span></span>

<span data-ttu-id="e9ff6-106">やすく、アプリのユーザーに適した、世界中には、[グローバリゼーションのガイドライン](../design/globalizing/guidelines-and-checklist-for-globalizing-your-app.md)と[ローカライズ可能なアプリ](../design/globalizing/prepare-your-app-for-localization.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-106">For info to help make your app suitable for customers around the world, see [Guidelines for globalization](../design/globalizing/guidelines-and-checklist-for-globalizing-your-app.md) and [Make your app localizable](../design/globalizing/prepare-your-app-for-localization.md).</span></span>

> [!NOTE]
> <span data-ttu-id="e9ff6-107">このトピックはアプリについて説明していますが、アドオンの市場の選択にも同じプロセスを使います。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-107">Although this topic refers to apps, market selection for add-on submissions uses the same process.</span></span>

## <a name="markets"></a><span data-ttu-id="e9ff6-108">市場</span><span class="sxs-lookup"><span data-stu-id="e9ff6-108">Markets</span></span>

<span data-ttu-id="e9ff6-109">既定では、アプリは販売できるすべての市場 (今後追加される可能性のある市場も含む) にその基本価格で公開されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-109">By default, we'll offer your app in all possible markets, including any future markets that we may add later, at its base price.</span></span>

<span data-ttu-id="e9ff6-110">必要に応じて、アプリを提供する特定の市場を定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-110">If you prefer, you can define the specific markets in which you'd like to offer your app.</span></span> <span data-ttu-id="e9ff6-111">これを行うには、**[価格と使用可能状況]** ページの **[市場]** セクションで **[オプションの表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-111">To do so, select **Show options** in the **Markets** section on the **Pricing and availability** page.</span></span> <span data-ttu-id="e9ff6-112">**[市場の選択]** ポップアップ ウィンドウが表示されます。ここで、アプリを提供する市場を選択できます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-112">This will display the **Market selection** popup window, where you can choose the markets in which to offer your app.</span></span>

<span data-ttu-id="e9ff6-113">既定では、すべての市場が選択されています。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-113">By default, all markets are selected.</span></span> <span data-ttu-id="e9ff6-114">市場を 1 つずつ選択解除して除外するか、**[すべて選択解除]** をクリックしてから、必要な市場を 1 つずつ選んで追加できます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-114">You can unselect individual markets to exclude them, or you can click **Unselect all** and then add individual markets of your choice.</span></span> <span data-ttu-id="e9ff6-115">検索バーで特定の市場を検索できます。また、ドロップダウンを **[すべての市場]** から **[Xbox の市場]** に変更すると、Xbox 向けの製品を販売できる市場だけを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-115">You can search for a particular market in the search bar, and you can also change the dropdown from **All markets** to **Xbox markets** if you only want to view the markets in which you can sell Xbox products.</span></span> <span data-ttu-id="e9ff6-116">完了したら、**[OK]** をクリックして選択を保存します。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-116">Once you’ve finished, click **OK** to save your selections.</span></span>

<span data-ttu-id="e9ff6-117">ここで選択した設定は、新規にアプリを入手するユーザーにのみ適用されます。特定の市場でユーザーが既にアプリを入手している場合、後でその市場からアプリを削除しても、既にアプリを所有しているユーザーは引き続きアプリを使うことができます。ただし、今後提出される更新プログラムを受け取ることはできず、その市場で新規ユーザーがアプリを入手することもできません。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-117">Note that your selections here apply only to new acquisitions; if someone already has your app in a certain market, and you later remove that market, the people who already have the app in that market can continue to use it, but they won’t get the updates you submit, and no new customers in that market can get your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e9ff6-118">開発者には、それぞれの国または地域の法的要件をすべて満たす責任があります。これは、それらの要件がこのドキュメントや Windows デベロッパー センター ダッシュボードに記載されていなくても同様です。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-118">It is your responsibility to meet any local legal requirements, even if those requirements aren't listed here or in the Windows Dev Center dashboard.</span></span>

<span data-ttu-id="e9ff6-119">すべての市場を選んだ場合でも、現地の法律、規制、またはその他の要因により、特定のアプリが一部の国と地域に公開されないことがあります。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-119">Keep in mind that even if you select all markets, local laws and restrictions or other factors may prevent certain apps from being listed in some countries and regions.</span></span> <span data-ttu-id="e9ff6-120">また、一部の市場には年齢区分に関する特定の要件が存在することがあります。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-120">Also, some markets may have specific requirements related to age ratings.</span></span> <span data-ttu-id="e9ff6-121">アプリがこれらの要件を満たしていない場合、その市場でアプリを提供できなくなります。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-121">If your app doesn’t meet these requirements, we won't be able to offer your app in that market.</span></span> <span data-ttu-id="e9ff6-122">詳しくは、「[年齢区分](age-ratings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-122">See [Age ratings](age-ratings.md) for more info.</span></span>

> [!NOTE]
> <span data-ttu-id="e9ff6-123">Windows8 または Windows8.1 をターゲットとするアプリ、いくつかの個別の市場が 1 つの 1 つ「残りの部分の国と地域」市場として扱われます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-123">For apps targeting Windows8 or Windows8.1, some individual markets are treated as one single "Rest of World" market.</span></span> <span data-ttu-id="e9ff6-124">詳しくは、「[Windows 8.x の "その他の国と地域" 市場](#rest-of-world-markets-for-windows-8x)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-124">For more info, see ["Rest of World" markets for Windows 8.x](#rest-of-world-markets-for-windows-8x).</span></span>

<span data-ttu-id="e9ff6-125">また、今後ストアに追加される市場にアプリを提供するかどうかを指定するチェック ボックスも用意されています。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-125">You will also see a checkbox that lets you indicate whether to offer your app in any market that the Store may add in the future.</span></span> <span data-ttu-id="e9ff6-126">このチェック ボックスをオンにしておくと、後で新しい市場が追加されたときに、申請時に指定したアプリの基本価格と一般公開日がそれらの市場で使われます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-126">If you leave this box checked, and we later add new markets, the base price and general availability date for your submission will be used for your app in those markets.</span></span> <span data-ttu-id="e9ff6-127">これを避けるには、このチェック ボックスをオフにすると、今後追加される市場でアプリが公開されることはなくなります (後でいつでもアプリを追加できます)。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-127">If you don't want this to happen, you can uncheck this box, in which case we will not list your app in any future markets (though you can always add them later).</span></span>
 

## <a name="microsoft-store-consumer-markets"></a><span data-ttu-id="e9ff6-128">Microsoft ストアのユーザー市場</span><span class="sxs-lookup"><span data-stu-id="e9ff6-128">Microsoft Store consumer markets</span></span>

<span data-ttu-id="e9ff6-129">以下に挙げる市場の中から、アプリ (またはアドオン) を公開する市場を 1 つ以上選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-129">You can choose to list your app (or add-on) in one or more of the following markets.</span></span> <span data-ttu-id="e9ff6-130">アスタリスクで市場。 Xbox One では、Microsoft Store をサポートします。**Xbox**は、**市場の選択**は、ポップアップ ウィンドウで、名前の横に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-130">The markets with an asterisk support the Microsoft Store on Xbox One; you'll see **Xbox** next to their names in the **Market selection** popup window.</span></span>


<table>
  
  <tr>
    <td><span data-ttu-id="e9ff6-131">アフガニスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-131">Afghanistan</span></span></td>
    <td><span data-ttu-id="e9ff6-132">オーランド諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-132">Åland Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-133">アルバニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-133">Albania</span></span></td>
    <td><span data-ttu-id="e9ff6-134">アルジェリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-134">Algeria</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-135">米領サモア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-135">American Samoa</span></span></td>
    <td><span data-ttu-id="e9ff6-136">アンドラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-136">Andorra</span></span></td>
    <td><span data-ttu-id="e9ff6-137">アンゴラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-137">Angola</span></span></td>
    <td><span data-ttu-id="e9ff6-138">アンギラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-138">Anguilla</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-139">南極</span><span class="sxs-lookup"><span data-stu-id="e9ff6-139">Antarctica</span></span></td>
    <td><span data-ttu-id="e9ff6-140">アンティグア・バーブーダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-140">Antigua and Barbuda</span></span></td>
    <td><span data-ttu-id="e9ff6-141">アルゼンチン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-141">Argentina</span></span></td>
    <td><span data-ttu-id="e9ff6-142">アルメニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-142">Armenia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-143">アルバ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-143">Aruba</span></span></td>
    <td><span data-ttu-id="e9ff6-144">オーストラリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-144">Australia</span></span></td>
    <td><span data-ttu-id="e9ff6-145">オーストリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-145">Austria</span></span></td>
    <td><span data-ttu-id="e9ff6-146">アゼルバイジャン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-146">Azerbaijan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-147">バハマ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-147">Bahamas</span></span></td>
    <td><span data-ttu-id="e9ff6-148">バーレーン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-148">Bahrain</span></span></td>
    <td><span data-ttu-id="e9ff6-149">バングラデシュ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-149">Bangladesh</span></span></td>
    <td><span data-ttu-id="e9ff6-150">バルバドス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-150">Barbados</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-151">ベラルーシ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-151">Belarus</span></span></td>
    <td><span data-ttu-id="e9ff6-152">ベルギー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-152">Belgium</span></span></td>
    <td><span data-ttu-id="e9ff6-153">ベリーズ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-153">Belize</span></span></td>
    <td><span data-ttu-id="e9ff6-154">ベナン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-154">Benin</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-155">バミューダ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-155">Bermuda</span></span></td>
    <td><span data-ttu-id="e9ff6-156">ブータン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-156">Bhutan</span></span></td>
    <td><span data-ttu-id="e9ff6-157">ボリビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-157">Bolivia</span></span></td>
    <td><span data-ttu-id="e9ff6-158">ボネール島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-158">Bonaire</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-159">ボスニア・ヘルツェゴビナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-159">Bosnia and Herzegovina</span></span></td>
    <td><span data-ttu-id="e9ff6-160">ボツワナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-160">Botswana</span></span></td>
    <td><span data-ttu-id="e9ff6-161">ブーベ島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-161">Bouvet Island</span></span></td>
    <td><span data-ttu-id="e9ff6-162">ブラジル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-162">Brazil</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-163">英領インド洋地域</span><span class="sxs-lookup"><span data-stu-id="e9ff6-163">British Indian Ocean Territory</span></span></td>
    <td><span data-ttu-id="e9ff6-164">英領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-164">British Virgin Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-165">ブルネイ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-165">Brunei</span></span></td>
    <td><span data-ttu-id="e9ff6-166">ブルガリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-166">Bulgaria</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-167">ブルキナファソ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-167">Burkina Faso</span></span></td>
    <td><span data-ttu-id="e9ff6-168">ブルンジ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-168">Burundi</span></span></td>
    <td><span data-ttu-id="e9ff6-169">カーボベルデ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-169">Cabo Verde</span></span></td>
    <td><span data-ttu-id="e9ff6-170">カンボジア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-170">Cambodia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-171">カメルーン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-171">Cameroon</span></span></td>
    <td><span data-ttu-id="e9ff6-172">カナダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-172">Canada</span></span></td>
    <td><span data-ttu-id="e9ff6-173">ケイマン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-173">Cayman Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-174">中央アフリカ共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-174">Central African Republic</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-175">チャド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-175">Chad</span></span></td>
    <td><span data-ttu-id="e9ff6-176">チリ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-176">Chile</span></span></td>
    <td><span data-ttu-id="e9ff6-177">中国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-177">China</span></span></td>
    <td><span data-ttu-id="e9ff6-178">クリスマス島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-178">Christmas Island</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-179">ココス諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-179">Cocos (Keeling) Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-180">コロンビア \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-180">Colombia \*</span></span></td>
    <td><span data-ttu-id="e9ff6-181">コモロ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-181">Comoros</span></span></td>
    <td><span data-ttu-id="e9ff6-182">コンゴ共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-182">Congo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-183">コンゴ民主共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-183">Congo (DRC)</span></span></td>
    <td><span data-ttu-id="e9ff6-184">クック諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-184">Cook Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-185">コスタリカ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-185">Costa Rica</span></span></td>
    <td><span data-ttu-id="e9ff6-186">コートジボワール</span><span class="sxs-lookup"><span data-stu-id="e9ff6-186">Côte d’Ivoire</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-187">クロアチア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-187">Croatia</span></span></td>
    <td><span data-ttu-id="e9ff6-188">キュラソー島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-188">Curaçao</span></span></td>
    <td><span data-ttu-id="e9ff6-189">キプロス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-189">Cyprus</span></span></td>
    <td><span data-ttu-id="e9ff6-190">チェコ共和国 \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-190">Czech Republic \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-191">デンマーク \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-191">Denmark \*</span></span></td>
    <td><span data-ttu-id="e9ff6-192">ジブチ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-192">Djibouti</span></span></td>
    <td><span data-ttu-id="e9ff6-193">ドミニカ国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-193">Dominica</span></span></td>
    <td><span data-ttu-id="e9ff6-194">ドミニカ共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-194">Dominican Republic</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-195">エクアドル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-195">Ecuador</span></span></td>
    <td><span data-ttu-id="e9ff6-196">エジプト</span><span class="sxs-lookup"><span data-stu-id="e9ff6-196">Egypt</span></span></td>
    <td><span data-ttu-id="e9ff6-197">エルサルバドル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-197">El Salvador</span></span></td>
    <td><span data-ttu-id="e9ff6-198">赤道ギニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-198">Equatorial Guinea</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-199">エリトリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-199">Eritrea</span></span></td>
    <td><span data-ttu-id="e9ff6-200">エストニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-200">Estonia</span></span></td>
    <td><span data-ttu-id="e9ff6-201">エチオピア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-201">Ethiopia</span></span></td>
    <td><span data-ttu-id="e9ff6-202">フォークランド諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-202">Falkland Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-203">フェロー諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-203">Faroe Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-204">フィジー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-204">Fiji</span></span></td>
    <td><span data-ttu-id="e9ff6-205">フィンランド \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-205">Finland \*</span></span></td>
    <td><span data-ttu-id="e9ff6-206">フランス \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-206">France \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-207">フランス領ギアナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-207">French Guiana</span></span></td>
    <td><span data-ttu-id="e9ff6-208">フランス領ポリネシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-208">French Polynesia</span></span></td>
    <td><span data-ttu-id="e9ff6-209">フランス領南極地方</span><span class="sxs-lookup"><span data-stu-id="e9ff6-209">French Southern and Antarctic Lands</span></span></td>
    <td><span data-ttu-id="e9ff6-210">ガボン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-210">Gabon</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-211">ガンビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-211">Gambia</span></span></td>
    <td><span data-ttu-id="e9ff6-212">ジョージア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-212">Georgia</span></span></td>
    <td><span data-ttu-id="e9ff6-213">ドイツ \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-213">Germany \*</span></span></td>
    <td><span data-ttu-id="e9ff6-214">ガーナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-214">Ghana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-215">ジブラルタル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-215">Gibraltar</span></span></td>
    <td><span data-ttu-id="e9ff6-216">ギリシャ \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-216">Greece \*</span></span></td>
    <td><span data-ttu-id="e9ff6-217">グリーンランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-217">Greenland</span></span></td>
    <td><span data-ttu-id="e9ff6-218">グレナダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-218">Grenada</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-219">グアドループ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-219">Guadeloupe</span></span></td>
    <td><span data-ttu-id="e9ff6-220">グアム</span><span class="sxs-lookup"><span data-stu-id="e9ff6-220">Guam</span></span></td>
    <td><span data-ttu-id="e9ff6-221">グアテマラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-221">Guatemala</span></span></td>
    <td><span data-ttu-id="e9ff6-222">ガーンジー島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-222">Guernsey</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-223">ギニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-223">Guinea</span></span></td>
    <td><span data-ttu-id="e9ff6-224">ギニアビサウ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-224">Guinea-Bissau</span></span></td>
    <td><span data-ttu-id="e9ff6-225">ガイアナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-225">Guyana</span></span></td>
    <td><span data-ttu-id="e9ff6-226">ハイチ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-226">Haiti</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-227">ハード・マクドナルド諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-227">Heard Island and McDonald Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-228">ホンジュラス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-228">Honduras</span></span></td>
    <td><span data-ttu-id="e9ff6-229">香港特別行政区 \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-229">Hong Kong SAR \*</span></span></td>
    <td><span data-ttu-id="e9ff6-230">ハンガリー \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-230">Hungary \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-231">アイスランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-231">Iceland</span></span></td>
    <td><span data-ttu-id="e9ff6-232">インド \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-232">India \*</span></span></td>
    <td><span data-ttu-id="e9ff6-233">インドネシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-233">Indonesia</span></span></td>
    <td><span data-ttu-id="e9ff6-234">イラク</span><span class="sxs-lookup"><span data-stu-id="e9ff6-234">Iraq</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-235">アイルランド \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-235">Ireland \*</span></span></td>
    <td><span data-ttu-id="e9ff6-236">マン島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-236">Isle of Man</span></span></td>
    <td><span data-ttu-id="e9ff6-237">イスラエル \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-237">Israel \*</span></span></td>
    <td><span data-ttu-id="e9ff6-238">イタリア \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-238">Italy \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-239">ジャマイカ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-239">Jamaica</span></span></td>
    <td><span data-ttu-id="e9ff6-240">日本 \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-240">Japan \*</span></span></td>
    <td><span data-ttu-id="e9ff6-241">ジャージー島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-241">Jersey</span></span></td>
    <td><span data-ttu-id="e9ff6-242">ヨルダン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-242">Jordan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-243">カザフスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-243">Kazakhstan</span></span></td>
    <td><span data-ttu-id="e9ff6-244">ケニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-244">Kenya</span></span></td>
    <td><span data-ttu-id="e9ff6-245">キリバス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-245">Kiribati</span></span></td>
    <td><span data-ttu-id="e9ff6-246">韓国 \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-246">Korea \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-247">クウェート</span><span class="sxs-lookup"><span data-stu-id="e9ff6-247">Kuwait</span></span></td>
    <td><span data-ttu-id="e9ff6-248">キルギス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-248">Kyrgyzstan</span></span></td>
    <td><span data-ttu-id="e9ff6-249">ラオス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-249">Laos</span></span></td>
    <td><span data-ttu-id="e9ff6-250">ラトビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-250">Latvia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-251">レバノン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-251">Lebanon</span></span></td>
    <td><span data-ttu-id="e9ff6-252">レソト</span><span class="sxs-lookup"><span data-stu-id="e9ff6-252">Lesotho</span></span></td>
    <td><span data-ttu-id="e9ff6-253">リベリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-253">Liberia</span></span></td>
    <td><span data-ttu-id="e9ff6-254">リビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-254">Libya</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-255">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-255">Liechtenstein</span></span></td>
    <td><span data-ttu-id="e9ff6-256">リトアニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-256">Lithuania</span></span></td>
    <td><span data-ttu-id="e9ff6-257">ルクセンブルク</span><span class="sxs-lookup"><span data-stu-id="e9ff6-257">Luxembourg</span></span></td>
    <td><span data-ttu-id="e9ff6-258">マカオ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-258">Macao SAR</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-259">マケドニア (旧ユーゴスラビア共和国)</span><span class="sxs-lookup"><span data-stu-id="e9ff6-259">Macedonia, FYRO</span></span></td>
    <td><span data-ttu-id="e9ff6-260">マダガスカル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-260">Madagascar</span></span></td>
    <td><span data-ttu-id="e9ff6-261">マラウイ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-261">Malawi</span></span></td>
    <td><span data-ttu-id="e9ff6-262">マレーシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-262">Malaysia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-263">モルディブ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-263">Maldives</span></span></td>
    <td><span data-ttu-id="e9ff6-264">マリ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-264">Mali</span></span></td>
    <td><span data-ttu-id="e9ff6-265">マルタ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-265">Malta</span></span></td>
    <td><span data-ttu-id="e9ff6-266">マーシャル諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-266">Marshall Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-267">マルチニーク島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-267">Martinique</span></span></td>
    <td><span data-ttu-id="e9ff6-268">モーリタニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-268">Mauritania</span></span></td>
    <td><span data-ttu-id="e9ff6-269">モーリシャス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-269">Mauritius</span></span></td>
    <td><span data-ttu-id="e9ff6-270">マイヨット島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-270">Mayotte</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-271">メキシコ \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-271">Mexico \*</span></span></td>
    <td><span data-ttu-id="e9ff6-272">ミクロネシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-272">Micronesia</span></span></td>
    <td><span data-ttu-id="e9ff6-273">モルドバ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-273">Moldova</span></span></td>
    <td><span data-ttu-id="e9ff6-274">モナコ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-274">Monaco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-275">モンゴル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-275">Mongolia</span></span></td>
    <td><span data-ttu-id="e9ff6-276">モンテネグロ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-276">Montenegro</span></span></td>
    <td><span data-ttu-id="e9ff6-277">モンセラット</span><span class="sxs-lookup"><span data-stu-id="e9ff6-277">Montserrat</span></span></td>
    <td><span data-ttu-id="e9ff6-278">モロッコ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-278">Morocco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-279">モザンビーク</span><span class="sxs-lookup"><span data-stu-id="e9ff6-279">Mozambique</span></span></td>
    <td><span data-ttu-id="e9ff6-280">ミャンマー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-280">Myanmar</span></span></td>
    <td><span data-ttu-id="e9ff6-281">ナミビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-281">Namibia</span></span></td>
    <td><span data-ttu-id="e9ff6-282">ナウル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-282">Nauru</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-283">ネパール</span><span class="sxs-lookup"><span data-stu-id="e9ff6-283">Nepal</span></span></td>
    <td><span data-ttu-id="e9ff6-284">オランダ \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-284">Netherlands \*</span></span></td>
    <td><span data-ttu-id="e9ff6-285">ニューカレドニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-285">New Caledonia</span></span></td>
    <td><span data-ttu-id="e9ff6-286">ニュージーランド \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-286">New Zealand \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-287">ニカラグア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-287">Nicaragua</span></span></td>
    <td><span data-ttu-id="e9ff6-288">ニジェール</span><span class="sxs-lookup"><span data-stu-id="e9ff6-288">Niger</span></span></td>
    <td><span data-ttu-id="e9ff6-289">ナイジェリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-289">Nigeria</span></span></td>
    <td><span data-ttu-id="e9ff6-290">ニウエ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-290">Niue</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-291">ノーフォーク島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-291">Norfolk Island</span></span></td>
    <td><span data-ttu-id="e9ff6-292">北マリアナ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-292">Northern Mariana Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-293">ノルウェー \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-293">Norway \*</span></span></td>
    <td><span data-ttu-id="e9ff6-294">オマーン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-294">Oman</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-295">パキスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-295">Pakistan</span></span></td>
    <td><span data-ttu-id="e9ff6-296">パラオ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-296">Palau</span></span></td>
    <td><span data-ttu-id="e9ff6-297">パレスチナ自治政府</span><span class="sxs-lookup"><span data-stu-id="e9ff6-297">Palestinian Authority</span></span></td>
    <td><span data-ttu-id="e9ff6-298">パナマ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-298">Panama</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-299">パプアニューギニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-299">Papua New Guinea</span></span></td>
    <td><span data-ttu-id="e9ff6-300">パラグアイ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-300">Paraguay</span></span></td>
    <td><span data-ttu-id="e9ff6-301">ペルー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-301">Peru</span></span></td>
    <td><span data-ttu-id="e9ff6-302">フィリピン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-302">Philippines</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-303">ピトケアン島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-303">Pitcairn Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-304">ポーランド \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-304">Poland \*</span></span></td>
    <td><span data-ttu-id="e9ff6-305">ポルトガル \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-305">Portugal \*</span></span></td>
    <td><span data-ttu-id="e9ff6-306">カタール</span><span class="sxs-lookup"><span data-stu-id="e9ff6-306">Qatar</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-307">レユニオン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-307">Réunion</span></span></td>
    <td><span data-ttu-id="e9ff6-308">ルーマニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-308">Romania</span></span></td>
    <td><span data-ttu-id="e9ff6-309">ロシア \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-309">Russia \*</span></span></td>
    <td><span data-ttu-id="e9ff6-310">ルワンダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-310">Rwanda</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-311">サン・バルテルミー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-311">Saint Barthélemy</span></span></td>
    <td><span data-ttu-id="e9ff6-312">セントヘレナ、アセンションおよびトリスタンダクーニャ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-312">Saint Helena, Ascension and Tristan da Cunha</span></span></td>
    <td><span data-ttu-id="e9ff6-313">セントクリストファー・ネイビス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-313">Saint Kitts and Nevis</span></span></td>
    <td><span data-ttu-id="e9ff6-314">セントルシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-314">Saint Lucia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-315">サンマルタン島 (フランス領)</span><span class="sxs-lookup"><span data-stu-id="e9ff6-315">Saint Martin (French Part)</span></span></td>
    <td><span data-ttu-id="e9ff6-316">サンピエール・ミクロン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-316">Saint Pierre and Miquelon</span></span></td>
    <td><span data-ttu-id="e9ff6-317">セントビンセントおよびグレナディーン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-317">Saint Vincent and the Grenadines</span></span></td>
    <td><span data-ttu-id="e9ff6-318">サモア独立国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-318">Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-319">サンマリノ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-319">San Marino</span></span></td>
    <td><span data-ttu-id="e9ff6-320">サントメ・プリンシペ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-320">São Tomé and Príncipe</span></span></td>
    <td><span data-ttu-id="e9ff6-321">サウジアラビア \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-321">Saudi Arabia \*</span></span></td>
    <td><span data-ttu-id="e9ff6-322">セネガル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-322">Senegal</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-323">セルビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-323">Serbia</span></span></td>
    <td><span data-ttu-id="e9ff6-324">セーシェル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-324">Seychelles</span></span></td>
    <td><span data-ttu-id="e9ff6-325">シエラレオネ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-325">Sierra Leone</span></span></td>
    <td><span data-ttu-id="e9ff6-326">シンガポール \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-326">Singapore \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-327">サンマルタン島 (オランダ領)</span><span class="sxs-lookup"><span data-stu-id="e9ff6-327">Sint Maarten (Dutch Part)</span></span></td>
    <td><span data-ttu-id="e9ff6-328">スロバキア \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-328">Slovakia \*</span></span></td>
    <td><span data-ttu-id="e9ff6-329">スロベニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-329">Slovenia</span></span></td>
    <td><span data-ttu-id="e9ff6-330">ソロモン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-330">Solomon Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-331">ソマリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-331">Somalia</span></span></td>
    <td><span data-ttu-id="e9ff6-332">南アフリカ \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-332">South Africa \*</span></span></td>
    <td><span data-ttu-id="e9ff6-333">サウスジョージア・サウスサンドウィッチ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-333">South Georgia and the South Sandwich Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-334">スペイン \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-334">Spain \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-335">スリランカ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-335">Sri Lanka</span></span></td>
    <td><span data-ttu-id="e9ff6-336">スリナム</span><span class="sxs-lookup"><span data-stu-id="e9ff6-336">Suriname</span></span></td>
    <td><span data-ttu-id="e9ff6-337">スバールバル諸島、ヤンマイエン島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-337">Svalbard and Jan Mayen</span></span></td>
    <td><span data-ttu-id="e9ff6-338">スワジランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-338">Swaziland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-339">スウェーデン \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-339">Sweden \*</span></span></td>
    <td><span data-ttu-id="e9ff6-340">スイス \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-340">Switzerland \*</span></span></td>
    <td><span data-ttu-id="e9ff6-341">台湾 \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-341">Taiwan \*</span></span></td>
    <td><span data-ttu-id="e9ff6-342">タジキスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-342">Tajikistan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-343">タンザニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-343">Tanzania</span></span></td>
    <td><span data-ttu-id="e9ff6-344">タイ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-344">Thailand</span></span></td>
    <td><span data-ttu-id="e9ff6-345">ティモール・レステ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-345">Timor-Leste</span></span></td>
    <td><span data-ttu-id="e9ff6-346">トーゴ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-346">Togo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-347">トケラウ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-347">Tokelau</span></span></td>
    <td><span data-ttu-id="e9ff6-348">トンガ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-348">Tonga</span></span></td>
    <td><span data-ttu-id="e9ff6-349">トリニダード・トバゴ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-349">Trinidad and Tobago</span></span></td>
    <td><span data-ttu-id="e9ff6-350">チュニジア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-350">Tunisia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-351">トルコ \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-351">Turkey \*</span></span></td>
    <td><span data-ttu-id="e9ff6-352">トルクメニスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-352">Turkmenistan</span></span></td>
    <td><span data-ttu-id="e9ff6-353">タークス・カイコス諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-353">Turks and Caicos Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-354">ツバル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-354">Tuvalu</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-355">その他の米領諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-355">U.S. Minor Outlying Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-356">米領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-356">U.S. Virgin Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-357">ウガンダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-357">Uganda</span></span></td>
    <td><span data-ttu-id="e9ff6-358">ウクライナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-358">Ukraine</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-359">アラブ首長国連邦 \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-359">United Arab Emirates \*</span></span></td>
    <td><span data-ttu-id="e9ff6-360">英国 \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-360">United Kingdom \*</span></span></td>
    <td><span data-ttu-id="e9ff6-361">米国 \*</span><span class="sxs-lookup"><span data-stu-id="e9ff6-361">United States \*</span></span></td>
    <td><span data-ttu-id="e9ff6-362">ウルグアイ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-362">Uruguay</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-363">ウズベキスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-363">Uzbekistan</span></span></td>
    <td><span data-ttu-id="e9ff6-364">バヌアツ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-364">Vanuatu</span></span></td>
    <td><span data-ttu-id="e9ff6-365">バチカン市国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-365">Vatican City</span></span></td>
    <td><span data-ttu-id="e9ff6-366">ベネズエラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-366">Venezuela</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-367">ベトナム</span><span class="sxs-lookup"><span data-stu-id="e9ff6-367">Vietnam</span></span></td>
    <td><span data-ttu-id="e9ff6-368">ワリス・フテュナ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-368">Wallis and Futuna</span></span></td>
    <td><span data-ttu-id="e9ff6-369">西サハラ (紛争中)</span><span class="sxs-lookup"><span data-stu-id="e9ff6-369">Western Sahara (Disputed)</span></span></td>
    <td><span data-ttu-id="e9ff6-370">イエメン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-370">Yemen</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-371">ザンビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-371">Zambia</span></span></td>
    <td><span data-ttu-id="e9ff6-372">ジンバブエ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-372">Zimbabwe</span></span></td>
    <td></td>
    <td></td>
  </tr>
</table>


## <a name="price-considerations-for-specific-markets"></a><span data-ttu-id="e9ff6-373">特定の市場の価格に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="e9ff6-373">Price considerations for specific markets</span></span>

<span data-ttu-id="e9ff6-374">ギフトカードや携帯電話会社による課金などの支払方法は、有料アプリおよびアプリ内購入アイテムの販売の増加に役立つ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-374">Payment methods such as gift cards and mobile operator billing can help increase sales of paid apps and in-app purchase items.</span></span> <span data-ttu-id="e9ff6-375">このような支払い方法を可能にするためのコストは高額になるため、下の表に示す国/地域および支払い方法については、ストア手数料に Commerce Expansion Adjustment (商取引拡大調整) を加え、純収益から差し引いて、有料アプリやアプリ内購入トランザクションに対して支払われるアプリの収益を計算します。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-375">Due to the higher costs to enable such payment methods, a Commerce Expansion Adjustment is added to the Store Fee deducted from Net Receipts to calculate the App Proceeds payable for paid apps and in-app purchase transactions in the countries/regions and using the payment methods in the tables below.</span></span> <span data-ttu-id="e9ff6-376">お客様のアプリが利用可能な国/地域で Commerce Expansion Adjustment (商取引拡大調整) が適用されるかどうかを考慮し、それを市場の価格設定戦略に組み込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-376">You may want to consider if the Commerce Expansion Adjustment applies in a country/region where your app is available and factor that into your market pricing strategy.</span></span> <span data-ttu-id="e9ff6-377">Commerce Expansion Adjustment について詳しくは、「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-377">Details about the Commerce Expansion Adjustment can be found in the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement).</span></span>

<span data-ttu-id="e9ff6-378">Commerce Expansion Adjustment は、有効日現在、指定された国/地域および支払い方法で処理されるすべての取引に適用されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-378">The Commerce Expansion Adjustment will be applied to all transactions processed for the specified Country/Region and Payment Methods as of the Effective Date.</span></span> <span data-ttu-id="e9ff6-379">この情報は毎月更新され、新しい国/地域および支払方法で Commerce Expansion Adjustment が有効になった日から 30 日以内に、その国/地域および支払方法が一覧表示されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-379">This information will be updated monthly; new countries/regions and payment methods will be listed within thirty (30) days after the Commerce Expansion Adjustment takes effect for that country/region and payment method.</span></span>

&nbsp;

| <span data-ttu-id="e9ff6-380">国/地域</span><span class="sxs-lookup"><span data-stu-id="e9ff6-380">Country/region</span></span>       | <span data-ttu-id="e9ff6-381">支払い方法</span><span class="sxs-lookup"><span data-stu-id="e9ff6-381">Payment method</span></span>  | <span data-ttu-id="e9ff6-382">Commerce Expansion Adjustment (商取引拡大調整)</span><span class="sxs-lookup"><span data-stu-id="e9ff6-382">Commerce Expansion Adjustment</span></span> | <span data-ttu-id="e9ff6-383">有効日</span><span class="sxs-lookup"><span data-stu-id="e9ff6-383">Effective date</span></span> |
|----------------------|-----------------|-------------------------------|----------------|
| <span data-ttu-id="e9ff6-384">アルゼンチン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-384">Argentina</span></span>            | <span data-ttu-id="e9ff6-385">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-385">Gift card</span></span>       | <span data-ttu-id="e9ff6-386">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-386">2.24%</span></span>                         | <span data-ttu-id="e9ff6-387">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-387">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-388">オーストラリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-388">Australia</span></span>            | <span data-ttu-id="e9ff6-389">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-389">Gift card</span></span>       | <span data-ttu-id="e9ff6-390">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-390">2.24%</span></span>                         | <span data-ttu-id="e9ff6-391">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-391">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-392">オーストリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-392">Austria</span></span>              | <span data-ttu-id="e9ff6-393">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-393">Gift card</span></span>       | <span data-ttu-id="e9ff6-394">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-394">2.24%</span></span>                         | <span data-ttu-id="e9ff6-395">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-395">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-396">ベルギー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-396">Belgium</span></span>              | <span data-ttu-id="e9ff6-397">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-397">Gift card</span></span>       | <span data-ttu-id="e9ff6-398">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-398">2.24%</span></span>                         | <span data-ttu-id="e9ff6-399">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-399">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-400">ブラジル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-400">Brazil</span></span>               | <span data-ttu-id="e9ff6-401">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-401">Gift card</span></span>       | <span data-ttu-id="e9ff6-402">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-402">2.24%</span></span>                         | <span data-ttu-id="e9ff6-403">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-403">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-404">カナダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-404">Canada</span></span>               | <span data-ttu-id="e9ff6-405">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-405">Gift card</span></span>       | <span data-ttu-id="e9ff6-406">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-406">2.24%</span></span>                         | <span data-ttu-id="e9ff6-407">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-407">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-408">チリ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-408">Chile</span></span>                | <span data-ttu-id="e9ff6-409">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-409">Gift card</span></span>       | <span data-ttu-id="e9ff6-410">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-410">2.24%</span></span>                         | <span data-ttu-id="e9ff6-411">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-411">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-412">中国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-412">China</span></span>                | <span data-ttu-id="e9ff6-413">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-413">Gift card</span></span>       | <span data-ttu-id="e9ff6-414">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-414">2.24%</span></span>                         | <span data-ttu-id="e9ff6-415">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-415">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-416">コロンビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-416">Colombia</span></span>             | <span data-ttu-id="e9ff6-417">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-417">Gift card</span></span>       | <span data-ttu-id="e9ff6-418">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-418">2.24%</span></span>                         | <span data-ttu-id="e9ff6-419">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-419">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-420">チェコ共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-420">Czech Republic</span></span>       | <span data-ttu-id="e9ff6-421">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-421">Gift card</span></span>       | <span data-ttu-id="e9ff6-422">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-422">2.24%</span></span>                         | <span data-ttu-id="e9ff6-423">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-423">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-424">デンマーク</span><span class="sxs-lookup"><span data-stu-id="e9ff6-424">Denmark</span></span>              | <span data-ttu-id="e9ff6-425">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-425">Gift card</span></span>       | <span data-ttu-id="e9ff6-426">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-426">2.24%</span></span>                         | <span data-ttu-id="e9ff6-427">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-427">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-428">フィンランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-428">Finland</span></span>              | <span data-ttu-id="e9ff6-429">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-429">Gift card</span></span>       | <span data-ttu-id="e9ff6-430">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-430">2.24%</span></span>                         | <span data-ttu-id="e9ff6-431">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-431">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-432">フランス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-432">France</span></span>               | <span data-ttu-id="e9ff6-433">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-433">Gift card</span></span>       | <span data-ttu-id="e9ff6-434">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-434">2.24%</span></span>                         | <span data-ttu-id="e9ff6-435">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-435">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-436">ドイツ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-436">Germany</span></span>              | <span data-ttu-id="e9ff6-437">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-437">Gift card</span></span>       | <span data-ttu-id="e9ff6-438">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-438">2.24%</span></span>                         | <span data-ttu-id="e9ff6-439">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-439">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-440">ギリシャ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-440">Greece</span></span>               | <span data-ttu-id="e9ff6-441">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-441">Gift card</span></span>       | <span data-ttu-id="e9ff6-442">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-442">2.24%</span></span>                         | <span data-ttu-id="e9ff6-443">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-443">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-444">香港</span><span class="sxs-lookup"><span data-stu-id="e9ff6-444">Hong Kong</span></span>            | <span data-ttu-id="e9ff6-445">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-445">Gift card</span></span>       | <span data-ttu-id="e9ff6-446">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-446">2.24%</span></span>                         | <span data-ttu-id="e9ff6-447">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-447">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-448">ハンガリー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-448">Hungary</span></span>              | <span data-ttu-id="e9ff6-449">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-449">Gift card</span></span>       | <span data-ttu-id="e9ff6-450">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-450">2.24%</span></span>                         | <span data-ttu-id="e9ff6-451">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-451">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-452">インド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-452">India</span></span>                | <span data-ttu-id="e9ff6-453">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-453">Gift card</span></span>       | <span data-ttu-id="e9ff6-454">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-454">2.24%</span></span>                         | <span data-ttu-id="e9ff6-455">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-455">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-456">アイルランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-456">Ireland</span></span>              | <span data-ttu-id="e9ff6-457">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-457">Gift card</span></span>       | <span data-ttu-id="e9ff6-458">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-458">2.24%</span></span>                         | <span data-ttu-id="e9ff6-459">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-459">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-460">イスラエル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-460">Israel</span></span>               | <span data-ttu-id="e9ff6-461">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-461">Gift card</span></span>       | <span data-ttu-id="e9ff6-462">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-462">2.24%</span></span>                         | <span data-ttu-id="e9ff6-463">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-463">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-464">イタリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-464">Italy</span></span>                | <span data-ttu-id="e9ff6-465">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-465">Gift card</span></span>       | <span data-ttu-id="e9ff6-466">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-466">2.24%</span></span>                         | <span data-ttu-id="e9ff6-467">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-467">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-468">日本</span><span class="sxs-lookup"><span data-stu-id="e9ff6-468">Japan</span></span>                | <span data-ttu-id="e9ff6-469">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-469">Gift card</span></span>       | <span data-ttu-id="e9ff6-470">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-470">2.24%</span></span>                         | <span data-ttu-id="e9ff6-471">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-471">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-472">メキシコ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-472">Mexico</span></span>               | <span data-ttu-id="e9ff6-473">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-473">Gift card</span></span>       | <span data-ttu-id="e9ff6-474">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-474">2.24%</span></span>                         | <span data-ttu-id="e9ff6-475">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-475">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-476">オランダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-476">Netherlands</span></span>          | <span data-ttu-id="e9ff6-477">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-477">Gift card</span></span>       | <span data-ttu-id="e9ff6-478">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-478">2.24%</span></span>                         | <span data-ttu-id="e9ff6-479">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-479">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-480">ニュージーランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-480">New Zealand</span></span>          | <span data-ttu-id="e9ff6-481">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-481">Gift card</span></span>       | <span data-ttu-id="e9ff6-482">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-482">2.24%</span></span>                         | <span data-ttu-id="e9ff6-483">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-483">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-484">ポーランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-484">Poland</span></span>               | <span data-ttu-id="e9ff6-485">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-485">Gift card</span></span>       | <span data-ttu-id="e9ff6-486">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-486">2.24%</span></span>                         | <span data-ttu-id="e9ff6-487">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-487">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-488">ポルトガル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-488">Portugal</span></span>             | <span data-ttu-id="e9ff6-489">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-489">Gift card</span></span>       | <span data-ttu-id="e9ff6-490">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-490">2.24%</span></span>                         | <span data-ttu-id="e9ff6-491">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-491">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-492">ロシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-492">Russia</span></span>               | <span data-ttu-id="e9ff6-493">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-493">Gift card</span></span>       | <span data-ttu-id="e9ff6-494">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-494">2.24%</span></span>                         | <span data-ttu-id="e9ff6-495">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-495">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-496">サウジアラビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-496">Saudi Arabia</span></span>         | <span data-ttu-id="e9ff6-497">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-497">Gift card</span></span>       | <span data-ttu-id="e9ff6-498">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-498">2.24%</span></span>                         | <span data-ttu-id="e9ff6-499">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-499">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-500">シンガポール</span><span class="sxs-lookup"><span data-stu-id="e9ff6-500">Singapore</span></span>            | <span data-ttu-id="e9ff6-501">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-501">Gift card</span></span>       | <span data-ttu-id="e9ff6-502">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-502">2.24%</span></span>                         | <span data-ttu-id="e9ff6-503">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-503">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-504">スロバキア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-504">Slovakia</span></span>             | <span data-ttu-id="e9ff6-505">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-505">Gift card</span></span>       | <span data-ttu-id="e9ff6-506">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-506">2.24%</span></span>                         | <span data-ttu-id="e9ff6-507">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-507">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-508">南アフリカ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-508">South Africa</span></span>         | <span data-ttu-id="e9ff6-509">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-509">Gift card</span></span>       | <span data-ttu-id="e9ff6-510">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-510">2.24%</span></span>                         | <span data-ttu-id="e9ff6-511">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-511">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-512">韓国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-512">South Korea</span></span>          | <span data-ttu-id="e9ff6-513">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-513">Gift card</span></span>       | <span data-ttu-id="e9ff6-514">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-514">2.24%</span></span>                         | <span data-ttu-id="e9ff6-515">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-515">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-516">スペイン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-516">Spain</span></span>                | <span data-ttu-id="e9ff6-517">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-517">Gift card</span></span>       | <span data-ttu-id="e9ff6-518">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-518">2.24%</span></span>                         | <span data-ttu-id="e9ff6-519">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-519">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-520">スウェーデン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-520">Sweden</span></span>               | <span data-ttu-id="e9ff6-521">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-521">Gift card</span></span>       | <span data-ttu-id="e9ff6-522">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-522">2.24%</span></span>                         | <span data-ttu-id="e9ff6-523">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-523">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-524">スイス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-524">Switzerland</span></span>          | <span data-ttu-id="e9ff6-525">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-525">Gift card</span></span>       | <span data-ttu-id="e9ff6-526">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-526">2.24%</span></span>                         | <span data-ttu-id="e9ff6-527">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-527">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-528">台湾</span><span class="sxs-lookup"><span data-stu-id="e9ff6-528">Taiwan</span></span>               | <span data-ttu-id="e9ff6-529">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-529">Gift card</span></span>       | <span data-ttu-id="e9ff6-530">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-530">2.24%</span></span>                         | <span data-ttu-id="e9ff6-531">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-531">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-532">トルコ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-532">Turkey</span></span>               | <span data-ttu-id="e9ff6-533">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-533">Gift card</span></span>       | <span data-ttu-id="e9ff6-534">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-534">2.24%</span></span>                         | <span data-ttu-id="e9ff6-535">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-535">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-536">アラブ首長国連邦</span><span class="sxs-lookup"><span data-stu-id="e9ff6-536">United Arab Emirates</span></span> | <span data-ttu-id="e9ff6-537">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-537">Gift card</span></span>       | <span data-ttu-id="e9ff6-538">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-538">2.24%</span></span>                         | <span data-ttu-id="e9ff6-539">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-539">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-540">英国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-540">United Kingdom</span></span>       | <span data-ttu-id="e9ff6-541">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-541">Gift card</span></span>       | <span data-ttu-id="e9ff6-542">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-542">2.24%</span></span>                         | <span data-ttu-id="e9ff6-543">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-543">March 2016</span></span>     |
| <span data-ttu-id="e9ff6-544">米国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-544">United States</span></span>        | <span data-ttu-id="e9ff6-545">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="e9ff6-545">Gift card</span></span>       | <span data-ttu-id="e9ff6-546">2.24%</span><span class="sxs-lookup"><span data-stu-id="e9ff6-546">2.24%</span></span>                         | <span data-ttu-id="e9ff6-547">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e9ff6-547">March 2016</span></span>     |

 

## <a name="rest-of-world-markets-for-windows-8x"></a><span data-ttu-id="e9ff6-548">Windows 8.x の "その他の国と地域" 市場</span><span class="sxs-lookup"><span data-stu-id="e9ff6-548">"Rest of World" markets for Windows 8.x</span></span>

<span data-ttu-id="e9ff6-549">アプリには、Windows をターゲットとするパッケージが含まれている場合、8.x することが重要向け windows ストアを使用して 1 つ「残りの部分の国と地域」市場としてさまざまな市場を扱うことに注意してください 8.x、Windows デベロッパー センターでの個別の市場として表示されている場合でもダッシュ ボード (以前のストア ダッシュ ボードではなくすべての市場のグループ化する 1 つの「残りの部分の国と地域」市場オプションがあった場合)。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-549">If your app includes packages targeting Windows 8.x, it's important to be aware that a number of markets are treated as a single "Rest of World" market for customers using the Store on Windows 8.x, even though they are shown as individual markets in the Windows Dev Center dashboard (as opposed to the earlier Store dashboard, where there was one "Rest of World" market option to group all of these markets).</span></span>

<span data-ttu-id="e9ff6-550">アプリを申請するときに、既定の項目を選択したままにしている場合、この問題について心配する必要はありません。アプリは可能なすべての市場に公開されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-550">If you leave the default selection when submitting your app, you don't have to worry about this, and your app will be available to all possible markets.</span></span> <span data-ttu-id="e9ff6-551">ただし、特定の市場を除外するために留意する以下の「残りの部分の国と地域」市場のいずれかのもいることを意味する場合、アプリはありませんで利用可能に Windows8 または Windows8.1 ユーザー向けの「残りの部分の国と地域」市場のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-551">However, if you want to exclude certain markets, keep in mind that excluding even one of these "Rest of World" markets means that your app won't be available in any of the "Rest of World" markets for customers on Windows8 or Windows8.1.</span></span>

<span data-ttu-id="e9ff6-552">Windows 8.x 向けの "その他の国と地域" に含まれている市場は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-552">The markets that are included in "Rest of World" for Windows 8.x are the following:</span></span>


<table>
  <tr>
    <td><span data-ttu-id="e9ff6-553">アフガニスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-553">Afghanistan</span></span></td>
    <td><span data-ttu-id="e9ff6-554">オーランド諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-554">Åland Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-555">アルバニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-555">Albania</span></span></td>
    <td><span data-ttu-id="e9ff6-556">アメリカ領サモア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-556">American Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-557">アンドラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-557">Andorra</span></span></td>
    <td><span data-ttu-id="e9ff6-558">アンゴラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-558">Angola</span></span></td>
    <td><span data-ttu-id="e9ff6-559">アンギラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-559">Anguilla</span></span></td>
    <td><span data-ttu-id="e9ff6-560">南極</span><span class="sxs-lookup"><span data-stu-id="e9ff6-560">Antarctica</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-561">アンティグア・バーブーダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-561">Antigua and Barbuda</span></span></td>
    <td><span data-ttu-id="e9ff6-562">アルメニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-562">Armenia</span></span></td>
    <td><span data-ttu-id="e9ff6-563">アルバ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-563">Aruba</span></span></td>
    <td><span data-ttu-id="e9ff6-564">アゼルバイジャン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-564">Azerbaijan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-565">バハマ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-565">Bahamas</span></span></td>
    <td><span data-ttu-id="e9ff6-566">バングラデシュ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-566">Bangladesh</span></span></td>
    <td><span data-ttu-id="e9ff6-567">バルバドス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-567">Barbados</span></span></td>
    <td><span data-ttu-id="e9ff6-568">ベラルーシ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-568">Belarus</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-569">ベリーズ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-569">Belize</span></span></td>
    <td><span data-ttu-id="e9ff6-570">ベナン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-570">Benin</span></span></td>
    <td><span data-ttu-id="e9ff6-571">バミューダ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-571">Bermuda</span></span></td>
    <td><span data-ttu-id="e9ff6-572">ブータン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-572">Bhutan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-573">ボリビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-573">Bolivia</span></span></td>
    <td><span data-ttu-id="e9ff6-574">ボネール島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-574">Bonaire</span></span></td>
    <td><span data-ttu-id="e9ff6-575">ボスニア・ヘルツェゴビナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-575">Bosnia and Herzegovina</span></span></td>
    <td><span data-ttu-id="e9ff6-576">ボツワナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-576">Botswana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-577">ブーベ島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-577">Bouvet Island</span></span></td>
    <td><span data-ttu-id="e9ff6-578">英領インド洋地域</span><span class="sxs-lookup"><span data-stu-id="e9ff6-578">British Indian Ocean Territory</span></span></td>
    <td><span data-ttu-id="e9ff6-579">英領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-579">British Virgin Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-580">ブルネイ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-580">Brunei</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-581">ブルキナファソ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-581">Burkina Faso</span></span></td>
    <td><span data-ttu-id="e9ff6-582">ブルンジ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-582">Burundi</span></span></td>
    <td><span data-ttu-id="e9ff6-583">カーボベルデ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-583">Cabo Verde</span></span></td>
    <td><span data-ttu-id="e9ff6-584">カンボジア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-584">Cambodia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-585">カメルーン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-585">Cameroon</span></span></td>
    <td><span data-ttu-id="e9ff6-586">ケイマン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-586">Cayman Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-587">中央アフリカ共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-587">Central African Republic</span></span></td>
    <td><span data-ttu-id="e9ff6-588">チャド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-588">Chad</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-589">クリスマス島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-589">Christmas Island</span></span></td>
    <td><span data-ttu-id="e9ff6-590">ココス諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-590">Cocos (Keeling) Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-591">コモロ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-591">Comoros</span></span></td>
    <td><span data-ttu-id="e9ff6-592">コンゴ共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-592">Congo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-593">コンゴ民主共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-593">Congo (DRC)</span></span></td>
    <td><span data-ttu-id="e9ff6-594">クック諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-594">Cook Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-595">コートジボワール</span><span class="sxs-lookup"><span data-stu-id="e9ff6-595">Côte d’Ivoire</span></span></td>
    <td><span data-ttu-id="e9ff6-596">キュラソー島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-596">Curaçao</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-597">ジブチ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-597">Djibouti</span></span></td>
    <td><span data-ttu-id="e9ff6-598">ドミニカ国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-598">Dominica</span></span></td>
    <td><span data-ttu-id="e9ff6-599">ドミニカ共和国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-599">Dominican Republic</span></span></td>
    <td><span data-ttu-id="e9ff6-600">エクアドル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-600">Ecuador</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-601">エルサルバドル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-601">El Salvador</span></span></td>
    <td><span data-ttu-id="e9ff6-602">赤道ギニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-602">Equatorial Guinea</span></span></td>
    <td><span data-ttu-id="e9ff6-603">エリトリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-603">Eritrea</span></span></td>
    <td><span data-ttu-id="e9ff6-604">エチオピア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-604">Ethiopia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-605">フォークランド諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-605">Falkland Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-606">フェロー諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-606">Faroe Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-607">フィジー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-607">Fiji</span></span></td>
    <td><span data-ttu-id="e9ff6-608">フランス領ギアナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-608">French Guiana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-609">フランス領ポリネシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-609">French Polynesia</span></span></td>
    <td><span data-ttu-id="e9ff6-610">フランス領南極地方</span><span class="sxs-lookup"><span data-stu-id="e9ff6-610">French Southern and Antarctic Lands</span></span></td>
    <td><span data-ttu-id="e9ff6-611">ガボン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-611">Gabon</span></span></td>
    <td><span data-ttu-id="e9ff6-612">ガンビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-612">Gambia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-613">ジョージア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-613">Georgia</span></span></td>
    <td><span data-ttu-id="e9ff6-614">ガーナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-614">Ghana</span></span></td>
    <td><span data-ttu-id="e9ff6-615">ジブラルタル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-615">Gibraltar</span></span></td>
    <td><span data-ttu-id="e9ff6-616">グリーンランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-616">Greenland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-617">グレナダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-617">Grenada</span></span></td>
    <td><span data-ttu-id="e9ff6-618">グアドループ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-618">Guadeloupe</span></span></td>
    <td><span data-ttu-id="e9ff6-619">グアム</span><span class="sxs-lookup"><span data-stu-id="e9ff6-619">Guam</span></span></td>
    <td><span data-ttu-id="e9ff6-620">グアテマラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-620">Guatemala</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-621">ガーンジー島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-621">Guernsey</span></span></td>
    <td><span data-ttu-id="e9ff6-622">ギニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-622">Guinea</span></span></td>
    <td><span data-ttu-id="e9ff6-623">ギニアビサウ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-623">Guinea-Bissau</span></span></td>
    <td><span data-ttu-id="e9ff6-624">ガイアナ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-624">Guyana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-625">ハイチ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-625">Haiti</span></span></td>
    <td><span data-ttu-id="e9ff6-626">ハード・マクドナルド諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-626">Heard Island and McDonald Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-627">ホンジュラス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-627">Honduras</span></span></td>
    <td><span data-ttu-id="e9ff6-628">アイスランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-628">Iceland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-629">マン島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-629">Isle of Man</span></span></td>
    <td><span data-ttu-id="e9ff6-630">ジャマイカ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-630">Jamaica</span></span></td>
    <td><span data-ttu-id="e9ff6-631">ジャージー島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-631">Jersey</span></span></td>
    <td><span data-ttu-id="e9ff6-632">ケニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-632">Kenya</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-633">キリバス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-633">Kiribati</span></span></td>
    <td><span data-ttu-id="e9ff6-634">キルギス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-634">Kyrgyzstan</span></span></td>
    <td><span data-ttu-id="e9ff6-635">ラオス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-635">Laos</span></span></td>
    <td><span data-ttu-id="e9ff6-636">レソト</span><span class="sxs-lookup"><span data-stu-id="e9ff6-636">Lesotho</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-637">リベリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-637">Liberia</span></span></td>
    <td><span data-ttu-id="e9ff6-638">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-638">Liechtenstein</span></span></td>
    <td><span data-ttu-id="e9ff6-639">マカオ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-639">Macao SAR</span></span></td>
    <td><span data-ttu-id="e9ff6-640">マケドニア (旧ユーゴスラビア共和国)</span><span class="sxs-lookup"><span data-stu-id="e9ff6-640">Macedonia, FYRO</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-641">マダガスカル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-641">Madagascar</span></span></td>
    <td><span data-ttu-id="e9ff6-642">マラウイ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-642">Malawi</span></span></td>
    <td><span data-ttu-id="e9ff6-643">モルディブ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-643">Maldives</span></span></td>
    <td><span data-ttu-id="e9ff6-644">マリ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-644">Mali</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-645">マーシャル諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-645">Marshall Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-646">マルチニーク島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-646">Martinique</span></span></td>
    <td><span data-ttu-id="e9ff6-647">モーリタニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-647">Mauritania</span></span></td>
    <td><span data-ttu-id="e9ff6-648">モーリシャス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-648">Mauritius</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-649">マイヨット島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-649">Mayotte</span></span></td>
    <td><span data-ttu-id="e9ff6-650">ミクロネシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-650">Micronesia</span></span></td>
    <td><span data-ttu-id="e9ff6-651">モルドバ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-651">Moldova</span></span></td>
    <td><span data-ttu-id="e9ff6-652">モナコ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-652">Monaco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-653">モンゴル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-653">Mongolia</span></span></td>
    <td><span data-ttu-id="e9ff6-654">モンテネグロ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-654">Montenegro</span></span></td>
    <td><span data-ttu-id="e9ff6-655">モンセラット</span><span class="sxs-lookup"><span data-stu-id="e9ff6-655">Montserrat</span></span></td>
    <td><span data-ttu-id="e9ff6-656">モロッコ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-656">Morocco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-657">モザンビーク</span><span class="sxs-lookup"><span data-stu-id="e9ff6-657">Mozambique</span></span></td>
    <td><span data-ttu-id="e9ff6-658">ミャンマー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-658">Myanmar</span></span></td>
    <td><span data-ttu-id="e9ff6-659">ナミビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-659">Namibia</span></span></td>
    <td><span data-ttu-id="e9ff6-660">ナウル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-660">Nauru</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-661">ネパール</span><span class="sxs-lookup"><span data-stu-id="e9ff6-661">Nepal</span></span></td>
    <td><span data-ttu-id="e9ff6-662">ニューカレドニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-662">New Caledonia</span></span></td>
    <td><span data-ttu-id="e9ff6-663">ニカラグア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-663">Nicaragua</span></span></td>
    <td><span data-ttu-id="e9ff6-664">ニジェール</span><span class="sxs-lookup"><span data-stu-id="e9ff6-664">Niger</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-665">ナイジェリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-665">Nigeria</span></span></td>
    <td><span data-ttu-id="e9ff6-666">ニウエ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-666">Niue</span></span></td>
    <td><span data-ttu-id="e9ff6-667">ノーフォーク島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-667">Norfolk Island</span></span></td>
    <td><span data-ttu-id="e9ff6-668">北マリアナ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-668">Northern Mariana Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-669">パラオ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-669">Palau</span></span></td>
    <td><span data-ttu-id="e9ff6-670">パレスチナ自治政府</span><span class="sxs-lookup"><span data-stu-id="e9ff6-670">Palestinian Authority</span></span></td>
    <td><span data-ttu-id="e9ff6-671">パナマ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-671">Panama</span></span></td>
    <td><span data-ttu-id="e9ff6-672">パプアニューギニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-672">Papua New Guinea</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-673">パラグアイ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-673">Paraguay</span></span></td>
    <td><span data-ttu-id="e9ff6-674">ピトケアン島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-674">Pitcairn Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-675">レユニオン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-675">Réunion</span></span></td>
    <td><span data-ttu-id="e9ff6-676">ルワンダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-676">Rwanda</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-677">サン・バルテルミー</span><span class="sxs-lookup"><span data-stu-id="e9ff6-677">Saint Barthélemy</span></span></td>
    <td><span data-ttu-id="e9ff6-678">セントヘレナ、アセンションおよびトリスタンダクーニャ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-678">Saint Helena, Ascension and Tristan da Cunha</span></span></td>
    <td><span data-ttu-id="e9ff6-679">セントクリストファー・ネイビス</span><span class="sxs-lookup"><span data-stu-id="e9ff6-679">Saint Kitts and Nevis</span></span></td>
    <td><span data-ttu-id="e9ff6-680">セントルシア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-680">Saint Lucia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-681">サンマルタン島 (フランス領)</span><span class="sxs-lookup"><span data-stu-id="e9ff6-681">Saint Martin (French Part)</span></span></td>
    <td><span data-ttu-id="e9ff6-682">サンピエール・ミクロン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-682">Saint Pierre and Miquelon</span></span></td>
    <td><span data-ttu-id="e9ff6-683">セントビンセントおよびグレナディーン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-683">Saint Vincent and the Grenadines</span></span></td>
    <td><span data-ttu-id="e9ff6-684">サモア独立国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-684">Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-685">サンマリノ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-685">San Marino</span></span></td>
    <td><span data-ttu-id="e9ff6-686">サントメ・プリンシペ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-686">São Tomé and Príncipe</span></span></td>
    <td><span data-ttu-id="e9ff6-687">セネガル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-687">Senegal</span></span></td>
    <td><span data-ttu-id="e9ff6-688">セーシェル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-688">Seychelles</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-689">シエラレオネ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-689">Sierra Leone</span></span></td>
    <td><span data-ttu-id="e9ff6-690">サンマルタン島 (オランダ領)</span><span class="sxs-lookup"><span data-stu-id="e9ff6-690">Sint Maarten (Dutch Part)</span></span></td>
    <td><span data-ttu-id="e9ff6-691">ソロモン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-691">Solomon Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-692">ソマリア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-692">Somalia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-693">サウスジョージア・サウスサンドウィッチ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-693">South Georgia and the South Sandwich Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-694">スリナム</span><span class="sxs-lookup"><span data-stu-id="e9ff6-694">Suriname</span></span></td>
    <td><span data-ttu-id="e9ff6-695">スバールバル諸島、ヤンマイエン島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-695">Svalbard and Jan Mayen</span></span></td>
    <td><span data-ttu-id="e9ff6-696">スワジランド</span><span class="sxs-lookup"><span data-stu-id="e9ff6-696">Swaziland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-697">タジキスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-697">Tajikistan</span></span></td>
    <td><span data-ttu-id="e9ff6-698">タンザニア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-698">Tanzania</span></span></td>
    <td><span data-ttu-id="e9ff6-699">ティモール・レステ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-699">Timor-Leste</span></span></td>
    <td><span data-ttu-id="e9ff6-700">トーゴ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-700">Togo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-701">トケラウ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-701">Tokelau</span></span></td>
    <td><span data-ttu-id="e9ff6-702">トンガ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-702">Tonga</span></span></td>
    <td><span data-ttu-id="e9ff6-703">トルクメニスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-703">Turkmenistan</span></span></td>
    <td><span data-ttu-id="e9ff6-704">タークス・カイコス諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-704">Turks and Caicos Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-705">ツバル</span><span class="sxs-lookup"><span data-stu-id="e9ff6-705">Tuvalu</span></span></td>
    <td><span data-ttu-id="e9ff6-706">ウガンダ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-706">Uganda</span></span></td>
    <td><span data-ttu-id="e9ff6-707">その他の米領諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-707">U.S. Minor Outlying Islands</span></span></td>
    <td><span data-ttu-id="e9ff6-708">米領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-708">U.S. Virgin Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-709">ウズベキスタン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-709">Uzbekistan</span></span></td>
    <td><span data-ttu-id="e9ff6-710">バチカン市国</span><span class="sxs-lookup"><span data-stu-id="e9ff6-710">Vatican City</span></span></td>
    <td><span data-ttu-id="e9ff6-711">ベネズエラ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-711">Venezuela</span></span></td>
    <td><span data-ttu-id="e9ff6-712">ベトナム</span><span class="sxs-lookup"><span data-stu-id="e9ff6-712">Vietnam</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-713">バヌアツ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-713">Vanuatu</span></span></td>
    <td><span data-ttu-id="e9ff6-714">ワリス・フテュナ諸島</span><span class="sxs-lookup"><span data-stu-id="e9ff6-714">Wallis and Futuna</span></span></td>
    <td><span data-ttu-id="e9ff6-715">イエメン</span><span class="sxs-lookup"><span data-stu-id="e9ff6-715">Yemen</span></span></td>
    <td><span data-ttu-id="e9ff6-716">ザンビア</span><span class="sxs-lookup"><span data-stu-id="e9ff6-716">Zambia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="e9ff6-717">ジンバブエ</span><span class="sxs-lookup"><span data-stu-id="e9ff6-717">Zimbabwe</span></span></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>

> [!NOTE]
> <span data-ttu-id="e9ff6-718">開発者アカウントを登録できる国と地域の一覧については、「[アカウントの種類、場所、料金](account-types-locations-and-fees.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9ff6-718">For a list of the countries and regions in which you can register for a developer account, see [Account types, locations, and fees](account-types-locations-and-fees.md).</span></span>
