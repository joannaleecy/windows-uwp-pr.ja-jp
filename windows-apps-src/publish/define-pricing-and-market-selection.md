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
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2882688"
---
# <a name="define-market-selection"></a><span data-ttu-id="7e341-103">市場の選択の定義</span><span class="sxs-lookup"><span data-stu-id="7e341-103">Define market selection</span></span>


<span data-ttu-id="7e341-104">Microsoft Store は、世界中の 200 以上の国と地域のお客様が利用できます。</span><span class="sxs-lookup"><span data-stu-id="7e341-104">The Microsoft Store reaches customers in over 200 countries and regions around the world.</span></span> <span data-ttu-id="7e341-105">アプリを提供する市場を選択して、市場ごとまたは市場のグループごとに、[価格と使用可能状況](set-app-pricing-and-availability.md)の多くの機能をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="7e341-105">You can choose the markets in which you'd like to offer your app, with the option to customize many [pricing and availability](set-app-pricing-and-availability.md) features per market or per group of markets.</span></span>

<span data-ttu-id="7e341-106">世界中のお客様に適したアプリをするための情報] は、[グローバル化するためのガイドライン](../design/globalizing/guidelines-and-checklist-for-globalizing-your-app.md)と[ローカライズ可能なアプリをように](../design/globalizing/prepare-your-app-for-localization.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7e341-106">For info to help make your app suitable for customers around the world, see [Guidelines for globalization](../design/globalizing/guidelines-and-checklist-for-globalizing-your-app.md) and [Make your app localizable](../design/globalizing/prepare-your-app-for-localization.md).</span></span>

> [!NOTE]
> <span data-ttu-id="7e341-107">このトピックはアプリについて説明していますが、アドオンの市場の選択にも同じプロセスを使います。</span><span class="sxs-lookup"><span data-stu-id="7e341-107">Although this topic refers to apps, market selection for add-on submissions uses the same process.</span></span>

## <a name="markets"></a><span data-ttu-id="7e341-108">市場</span><span class="sxs-lookup"><span data-stu-id="7e341-108">Markets</span></span>

<span data-ttu-id="7e341-109">既定では、アプリは販売できるすべての市場 (今後追加される可能性のある市場も含む) にその基本価格で公開されます。</span><span class="sxs-lookup"><span data-stu-id="7e341-109">By default, we'll offer your app in all possible markets, including any future markets that we may add later, at its base price.</span></span>

<span data-ttu-id="7e341-110">必要に応じて、アプリを提供する特定の市場を定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="7e341-110">If you prefer, you can define the specific markets in which you'd like to offer your app.</span></span> <span data-ttu-id="7e341-111">これを行うには、**[価格と使用可能状況]** ページの **[市場]** セクションで **[オプションの表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7e341-111">To do so, select **Show options** in the **Markets** section on the **Pricing and availability** page.</span></span> <span data-ttu-id="7e341-112">**[市場の選択]** ポップアップ ウィンドウが表示されます。ここで、アプリを提供する市場を選択できます。</span><span class="sxs-lookup"><span data-stu-id="7e341-112">This will display the **Market selection** popup window, where you can choose the markets in which to offer your app.</span></span>

<span data-ttu-id="7e341-113">既定では、すべての市場が選択されています。</span><span class="sxs-lookup"><span data-stu-id="7e341-113">By default, all markets are selected.</span></span> <span data-ttu-id="7e341-114">市場を 1 つずつ選択解除して除外するか、**[すべて選択解除]** をクリックしてから、必要な市場を 1 つずつ選んで追加できます。</span><span class="sxs-lookup"><span data-stu-id="7e341-114">You can unselect individual markets to exclude them, or you can click **Unselect all** and then add individual markets of your choice.</span></span> <span data-ttu-id="7e341-115">検索バーで特定の市場を検索できます。また、ドロップダウンを **[すべての市場]** から **[Xbox の市場]** に変更すると、Xbox 向けの製品を販売できる市場だけを表示できます。</span><span class="sxs-lookup"><span data-stu-id="7e341-115">You can search for a particular market in the search bar, and you can also change the dropdown from **All markets** to **Xbox markets** if you only want to view the markets in which you can sell Xbox products.</span></span> <span data-ttu-id="7e341-116">完了したら、**[OK]** をクリックして選択を保存します。</span><span class="sxs-lookup"><span data-stu-id="7e341-116">Once you’ve finished, click **OK** to save your selections.</span></span>

<span data-ttu-id="7e341-117">ここで選択した設定は、新規にアプリを入手するユーザーにのみ適用されます。特定の市場でユーザーが既にアプリを入手している場合、後でその市場からアプリを削除しても、既にアプリを所有しているユーザーは引き続きアプリを使うことができます。ただし、今後提出される更新プログラムを受け取ることはできず、その市場で新規ユーザーがアプリを入手することもできません。</span><span class="sxs-lookup"><span data-stu-id="7e341-117">Note that your selections here apply only to new acquisitions; if someone already has your app in a certain market, and you later remove that market, the people who already have the app in that market can continue to use it, but they won’t get the updates you submit, and no new customers in that market can get your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7e341-118">開発者には、それぞれの国または地域の法的要件をすべて満たす責任があります。これは、それらの要件がこのドキュメントや Windows デベロッパー センター ダッシュボードに記載されていなくても同様です。</span><span class="sxs-lookup"><span data-stu-id="7e341-118">It is your responsibility to meet any local legal requirements, even if those requirements aren't listed here or in the Windows Dev Center dashboard.</span></span>

<span data-ttu-id="7e341-119">すべての市場を選んだ場合でも、現地の法律、規制、またはその他の要因により、特定のアプリが一部の国と地域に公開されないことがあります。</span><span class="sxs-lookup"><span data-stu-id="7e341-119">Keep in mind that even if you select all markets, local laws and restrictions or other factors may prevent certain apps from being listed in some countries and regions.</span></span> <span data-ttu-id="7e341-120">また、一部の市場には年齢区分に関する特定の要件が存在することがあります。</span><span class="sxs-lookup"><span data-stu-id="7e341-120">Also, some markets may have specific requirements related to age ratings.</span></span> <span data-ttu-id="7e341-121">アプリがこれらの要件を満たしていない場合、その市場でアプリを提供できなくなります。</span><span class="sxs-lookup"><span data-stu-id="7e341-121">If your app doesn’t meet these requirements, we won't be able to offer your app in that market.</span></span> <span data-ttu-id="7e341-122">詳しくは、「[年齢区分](age-ratings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e341-122">See [Age ratings](age-ratings.md) for more info.</span></span>

> [!NOTE]
> <span data-ttu-id="7e341-123">Windows 8 または Windows 8.1 をターゲットとするアプリでは、いくつかの個別の市場が 1 つの "その他の国と地域" 市場として扱われます。</span><span class="sxs-lookup"><span data-stu-id="7e341-123">For apps targeting Windows 8 or Windows 8.1, some individual markets are treated as one single "Rest of World" market.</span></span> <span data-ttu-id="7e341-124">詳しくは、「[Windows 8.x の "その他の国と地域" 市場](#rest-of-world-markets-for-windows-8x)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e341-124">For more info, see ["Rest of World" markets for Windows 8.x](#rest-of-world-markets-for-windows-8x).</span></span>

<span data-ttu-id="7e341-125">また、今後ストアに追加される市場にアプリを提供するかどうかを指定するチェック ボックスも用意されています。</span><span class="sxs-lookup"><span data-stu-id="7e341-125">You will also see a checkbox that lets you indicate whether to offer your app in any market that the Store may add in the future.</span></span> <span data-ttu-id="7e341-126">このチェック ボックスをオンにしておくと、後で新しい市場が追加されたときに、申請時に指定したアプリの基本価格と一般公開日がそれらの市場で使われます。</span><span class="sxs-lookup"><span data-stu-id="7e341-126">If you leave this box checked, and we later add new markets, the base price and general availability date for your submission will be used for your app in those markets.</span></span> <span data-ttu-id="7e341-127">これを避けるには、このチェック ボックスをオフにすると、今後追加される市場でアプリが公開されることはなくなります (後でいつでもアプリを追加できます)。</span><span class="sxs-lookup"><span data-stu-id="7e341-127">If you don't want this to happen, you can uncheck this box, in which case we will not list your app in any future markets (though you can always add them later).</span></span>
 

## <a name="microsoft-store-consumer-markets"></a><span data-ttu-id="7e341-128">Microsoft ストア コンシューマー市場</span><span class="sxs-lookup"><span data-stu-id="7e341-128">Microsoft Store consumer markets</span></span>

<span data-ttu-id="7e341-129">以下に挙げる市場の中から、アプリ (またはアドオン) を公開する市場を 1 つ以上選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="7e341-129">You can choose to list your app (or add-on) in one or more of the following markets.</span></span> <span data-ttu-id="7e341-130">アスタリスクのサポートは Xbox 1 つ上の Microsoft ストアとの市場**市場の選択**ポップアップ ウィンドウで、名前の横にある**Xbox**が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7e341-130">The markets with an asterisk support the Microsoft Store on Xbox One; you'll see **Xbox** next to their names in the **Market selection** popup window.</span></span>


<table>
  
  <tr>
    <td><span data-ttu-id="7e341-131">アフガニスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-131">Afghanistan</span></span></td>
    <td><span data-ttu-id="7e341-132">オーランド諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-132">Åland Islands</span></span></td>
    <td><span data-ttu-id="7e341-133">アルバニア</span><span class="sxs-lookup"><span data-stu-id="7e341-133">Albania</span></span></td>
    <td><span data-ttu-id="7e341-134">アルジェリア</span><span class="sxs-lookup"><span data-stu-id="7e341-134">Algeria</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-135">米領サモア</span><span class="sxs-lookup"><span data-stu-id="7e341-135">American Samoa</span></span></td>
    <td><span data-ttu-id="7e341-136">アンドラ</span><span class="sxs-lookup"><span data-stu-id="7e341-136">Andorra</span></span></td>
    <td><span data-ttu-id="7e341-137">アンゴラ</span><span class="sxs-lookup"><span data-stu-id="7e341-137">Angola</span></span></td>
    <td><span data-ttu-id="7e341-138">アンギラ</span><span class="sxs-lookup"><span data-stu-id="7e341-138">Anguilla</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-139">南極</span><span class="sxs-lookup"><span data-stu-id="7e341-139">Antarctica</span></span></td>
    <td><span data-ttu-id="7e341-140">アンティグア・バーブーダ</span><span class="sxs-lookup"><span data-stu-id="7e341-140">Antigua and Barbuda</span></span></td>
    <td><span data-ttu-id="7e341-141">アルゼンチン</span><span class="sxs-lookup"><span data-stu-id="7e341-141">Argentina</span></span></td>
    <td><span data-ttu-id="7e341-142">アルメニア</span><span class="sxs-lookup"><span data-stu-id="7e341-142">Armenia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-143">アルバ</span><span class="sxs-lookup"><span data-stu-id="7e341-143">Aruba</span></span></td>
    <td><span data-ttu-id="7e341-144">オーストラリア</span><span class="sxs-lookup"><span data-stu-id="7e341-144">Australia</span></span></td>
    <td><span data-ttu-id="7e341-145">オーストリア</span><span class="sxs-lookup"><span data-stu-id="7e341-145">Austria</span></span></td>
    <td><span data-ttu-id="7e341-146">アゼルバイジャン</span><span class="sxs-lookup"><span data-stu-id="7e341-146">Azerbaijan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-147">バハマ</span><span class="sxs-lookup"><span data-stu-id="7e341-147">Bahamas</span></span></td>
    <td><span data-ttu-id="7e341-148">バーレーン</span><span class="sxs-lookup"><span data-stu-id="7e341-148">Bahrain</span></span></td>
    <td><span data-ttu-id="7e341-149">バングラデシュ</span><span class="sxs-lookup"><span data-stu-id="7e341-149">Bangladesh</span></span></td>
    <td><span data-ttu-id="7e341-150">バルバドス</span><span class="sxs-lookup"><span data-stu-id="7e341-150">Barbados</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-151">ベラルーシ</span><span class="sxs-lookup"><span data-stu-id="7e341-151">Belarus</span></span></td>
    <td><span data-ttu-id="7e341-152">ベルギー</span><span class="sxs-lookup"><span data-stu-id="7e341-152">Belgium</span></span></td>
    <td><span data-ttu-id="7e341-153">ベリーズ</span><span class="sxs-lookup"><span data-stu-id="7e341-153">Belize</span></span></td>
    <td><span data-ttu-id="7e341-154">ベナン</span><span class="sxs-lookup"><span data-stu-id="7e341-154">Benin</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-155">バミューダ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-155">Bermuda</span></span></td>
    <td><span data-ttu-id="7e341-156">ブータン</span><span class="sxs-lookup"><span data-stu-id="7e341-156">Bhutan</span></span></td>
    <td><span data-ttu-id="7e341-157">ボリビア</span><span class="sxs-lookup"><span data-stu-id="7e341-157">Bolivia</span></span></td>
    <td><span data-ttu-id="7e341-158">ボネール島</span><span class="sxs-lookup"><span data-stu-id="7e341-158">Bonaire</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-159">ボスニア・ヘルツェゴビナ</span><span class="sxs-lookup"><span data-stu-id="7e341-159">Bosnia and Herzegovina</span></span></td>
    <td><span data-ttu-id="7e341-160">ボツワナ</span><span class="sxs-lookup"><span data-stu-id="7e341-160">Botswana</span></span></td>
    <td><span data-ttu-id="7e341-161">ブーベ島</span><span class="sxs-lookup"><span data-stu-id="7e341-161">Bouvet Island</span></span></td>
    <td><span data-ttu-id="7e341-162">ブラジル</span><span class="sxs-lookup"><span data-stu-id="7e341-162">Brazil</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-163">英領インド洋地域</span><span class="sxs-lookup"><span data-stu-id="7e341-163">British Indian Ocean Territory</span></span></td>
    <td><span data-ttu-id="7e341-164">英領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-164">British Virgin Islands</span></span></td>
    <td><span data-ttu-id="7e341-165">ブルネイ</span><span class="sxs-lookup"><span data-stu-id="7e341-165">Brunei</span></span></td>
    <td><span data-ttu-id="7e341-166">ブルガリア</span><span class="sxs-lookup"><span data-stu-id="7e341-166">Bulgaria</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-167">ブルキナファソ</span><span class="sxs-lookup"><span data-stu-id="7e341-167">Burkina Faso</span></span></td>
    <td><span data-ttu-id="7e341-168">ブルンジ</span><span class="sxs-lookup"><span data-stu-id="7e341-168">Burundi</span></span></td>
    <td><span data-ttu-id="7e341-169">カーボベルデ</span><span class="sxs-lookup"><span data-stu-id="7e341-169">Cabo Verde</span></span></td>
    <td><span data-ttu-id="7e341-170">カンボジア</span><span class="sxs-lookup"><span data-stu-id="7e341-170">Cambodia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-171">カメルーン</span><span class="sxs-lookup"><span data-stu-id="7e341-171">Cameroon</span></span></td>
    <td><span data-ttu-id="7e341-172">カナダ</span><span class="sxs-lookup"><span data-stu-id="7e341-172">Canada</span></span></td>
    <td><span data-ttu-id="7e341-173">ケイマン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-173">Cayman Islands</span></span></td>
    <td><span data-ttu-id="7e341-174">中央アフリカ共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-174">Central African Republic</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-175">チャド</span><span class="sxs-lookup"><span data-stu-id="7e341-175">Chad</span></span></td>
    <td><span data-ttu-id="7e341-176">チリ</span><span class="sxs-lookup"><span data-stu-id="7e341-176">Chile</span></span></td>
    <td><span data-ttu-id="7e341-177">中国</span><span class="sxs-lookup"><span data-stu-id="7e341-177">China</span></span></td>
    <td><span data-ttu-id="7e341-178">クリスマス島</span><span class="sxs-lookup"><span data-stu-id="7e341-178">Christmas Island</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-179">ココス諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-179">Cocos (Keeling) Islands</span></span></td>
    <td><span data-ttu-id="7e341-180">コロンビア \*</span><span class="sxs-lookup"><span data-stu-id="7e341-180">Colombia \*</span></span></td>
    <td><span data-ttu-id="7e341-181">コモロ</span><span class="sxs-lookup"><span data-stu-id="7e341-181">Comoros</span></span></td>
    <td><span data-ttu-id="7e341-182">コンゴ共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-182">Congo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-183">コンゴ民主共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-183">Congo (DRC)</span></span></td>
    <td><span data-ttu-id="7e341-184">クック諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-184">Cook Islands</span></span></td>
    <td><span data-ttu-id="7e341-185">コスタリカ</span><span class="sxs-lookup"><span data-stu-id="7e341-185">Costa Rica</span></span></td>
    <td><span data-ttu-id="7e341-186">コートジボワール</span><span class="sxs-lookup"><span data-stu-id="7e341-186">Côte d’Ivoire</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-187">クロアチア</span><span class="sxs-lookup"><span data-stu-id="7e341-187">Croatia</span></span></td>
    <td><span data-ttu-id="7e341-188">キュラソー島</span><span class="sxs-lookup"><span data-stu-id="7e341-188">Curaçao</span></span></td>
    <td><span data-ttu-id="7e341-189">キプロス</span><span class="sxs-lookup"><span data-stu-id="7e341-189">Cyprus</span></span></td>
    <td><span data-ttu-id="7e341-190">チェコ共和国 \*</span><span class="sxs-lookup"><span data-stu-id="7e341-190">Czech Republic \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-191">デンマーク \*</span><span class="sxs-lookup"><span data-stu-id="7e341-191">Denmark \*</span></span></td>
    <td><span data-ttu-id="7e341-192">ジブチ</span><span class="sxs-lookup"><span data-stu-id="7e341-192">Djibouti</span></span></td>
    <td><span data-ttu-id="7e341-193">ドミニカ国</span><span class="sxs-lookup"><span data-stu-id="7e341-193">Dominica</span></span></td>
    <td><span data-ttu-id="7e341-194">ドミニカ共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-194">Dominican Republic</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-195">エクアドル</span><span class="sxs-lookup"><span data-stu-id="7e341-195">Ecuador</span></span></td>
    <td><span data-ttu-id="7e341-196">エジプト</span><span class="sxs-lookup"><span data-stu-id="7e341-196">Egypt</span></span></td>
    <td><span data-ttu-id="7e341-197">エルサルバドル</span><span class="sxs-lookup"><span data-stu-id="7e341-197">El Salvador</span></span></td>
    <td><span data-ttu-id="7e341-198">赤道ギニア</span><span class="sxs-lookup"><span data-stu-id="7e341-198">Equatorial Guinea</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-199">エリトリア</span><span class="sxs-lookup"><span data-stu-id="7e341-199">Eritrea</span></span></td>
    <td><span data-ttu-id="7e341-200">エストニア</span><span class="sxs-lookup"><span data-stu-id="7e341-200">Estonia</span></span></td>
    <td><span data-ttu-id="7e341-201">エチオピア</span><span class="sxs-lookup"><span data-stu-id="7e341-201">Ethiopia</span></span></td>
    <td><span data-ttu-id="7e341-202">フォークランド諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-202">Falkland Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-203">フェロー諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-203">Faroe Islands</span></span></td>
    <td><span data-ttu-id="7e341-204">フィジー</span><span class="sxs-lookup"><span data-stu-id="7e341-204">Fiji</span></span></td>
    <td><span data-ttu-id="7e341-205">フィンランド \*</span><span class="sxs-lookup"><span data-stu-id="7e341-205">Finland \*</span></span></td>
    <td><span data-ttu-id="7e341-206">フランス \*</span><span class="sxs-lookup"><span data-stu-id="7e341-206">France \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-207">フランス領ギアナ</span><span class="sxs-lookup"><span data-stu-id="7e341-207">French Guiana</span></span></td>
    <td><span data-ttu-id="7e341-208">フランス領ポリネシア</span><span class="sxs-lookup"><span data-stu-id="7e341-208">French Polynesia</span></span></td>
    <td><span data-ttu-id="7e341-209">フランス領南極地方</span><span class="sxs-lookup"><span data-stu-id="7e341-209">French Southern and Antarctic Lands</span></span></td>
    <td><span data-ttu-id="7e341-210">ガボン</span><span class="sxs-lookup"><span data-stu-id="7e341-210">Gabon</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-211">ガンビア</span><span class="sxs-lookup"><span data-stu-id="7e341-211">Gambia</span></span></td>
    <td><span data-ttu-id="7e341-212">ジョージア</span><span class="sxs-lookup"><span data-stu-id="7e341-212">Georgia</span></span></td>
    <td><span data-ttu-id="7e341-213">ドイツ \*</span><span class="sxs-lookup"><span data-stu-id="7e341-213">Germany \*</span></span></td>
    <td><span data-ttu-id="7e341-214">ガーナ</span><span class="sxs-lookup"><span data-stu-id="7e341-214">Ghana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-215">ジブラルタル</span><span class="sxs-lookup"><span data-stu-id="7e341-215">Gibraltar</span></span></td>
    <td><span data-ttu-id="7e341-216">ギリシャ \*</span><span class="sxs-lookup"><span data-stu-id="7e341-216">Greece \*</span></span></td>
    <td><span data-ttu-id="7e341-217">グリーンランド</span><span class="sxs-lookup"><span data-stu-id="7e341-217">Greenland</span></span></td>
    <td><span data-ttu-id="7e341-218">グレナダ</span><span class="sxs-lookup"><span data-stu-id="7e341-218">Grenada</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-219">グアドループ</span><span class="sxs-lookup"><span data-stu-id="7e341-219">Guadeloupe</span></span></td>
    <td><span data-ttu-id="7e341-220">グアム</span><span class="sxs-lookup"><span data-stu-id="7e341-220">Guam</span></span></td>
    <td><span data-ttu-id="7e341-221">グアテマラ</span><span class="sxs-lookup"><span data-stu-id="7e341-221">Guatemala</span></span></td>
    <td><span data-ttu-id="7e341-222">ガーンジー島</span><span class="sxs-lookup"><span data-stu-id="7e341-222">Guernsey</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-223">ギニア</span><span class="sxs-lookup"><span data-stu-id="7e341-223">Guinea</span></span></td>
    <td><span data-ttu-id="7e341-224">ギニアビサウ</span><span class="sxs-lookup"><span data-stu-id="7e341-224">Guinea-Bissau</span></span></td>
    <td><span data-ttu-id="7e341-225">ガイアナ</span><span class="sxs-lookup"><span data-stu-id="7e341-225">Guyana</span></span></td>
    <td><span data-ttu-id="7e341-226">ハイチ</span><span class="sxs-lookup"><span data-stu-id="7e341-226">Haiti</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-227">ハード・マクドナルド諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-227">Heard Island and McDonald Islands</span></span></td>
    <td><span data-ttu-id="7e341-228">ホンジュラス</span><span class="sxs-lookup"><span data-stu-id="7e341-228">Honduras</span></span></td>
    <td><span data-ttu-id="7e341-229">香港特別行政区 \*</span><span class="sxs-lookup"><span data-stu-id="7e341-229">Hong Kong SAR \*</span></span></td>
    <td><span data-ttu-id="7e341-230">ハンガリー \*</span><span class="sxs-lookup"><span data-stu-id="7e341-230">Hungary \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-231">アイスランド</span><span class="sxs-lookup"><span data-stu-id="7e341-231">Iceland</span></span></td>
    <td><span data-ttu-id="7e341-232">インド \*</span><span class="sxs-lookup"><span data-stu-id="7e341-232">India \*</span></span></td>
    <td><span data-ttu-id="7e341-233">インドネシア</span><span class="sxs-lookup"><span data-stu-id="7e341-233">Indonesia</span></span></td>
    <td><span data-ttu-id="7e341-234">イラク</span><span class="sxs-lookup"><span data-stu-id="7e341-234">Iraq</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-235">アイルランド \*</span><span class="sxs-lookup"><span data-stu-id="7e341-235">Ireland \*</span></span></td>
    <td><span data-ttu-id="7e341-236">マン島</span><span class="sxs-lookup"><span data-stu-id="7e341-236">Isle of Man</span></span></td>
    <td><span data-ttu-id="7e341-237">イスラエル \*</span><span class="sxs-lookup"><span data-stu-id="7e341-237">Israel \*</span></span></td>
    <td><span data-ttu-id="7e341-238">イタリア \*</span><span class="sxs-lookup"><span data-stu-id="7e341-238">Italy \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-239">ジャマイカ</span><span class="sxs-lookup"><span data-stu-id="7e341-239">Jamaica</span></span></td>
    <td><span data-ttu-id="7e341-240">日本 \*</span><span class="sxs-lookup"><span data-stu-id="7e341-240">Japan \*</span></span></td>
    <td><span data-ttu-id="7e341-241">ジャージー島</span><span class="sxs-lookup"><span data-stu-id="7e341-241">Jersey</span></span></td>
    <td><span data-ttu-id="7e341-242">ヨルダン</span><span class="sxs-lookup"><span data-stu-id="7e341-242">Jordan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-243">カザフスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-243">Kazakhstan</span></span></td>
    <td><span data-ttu-id="7e341-244">ケニア</span><span class="sxs-lookup"><span data-stu-id="7e341-244">Kenya</span></span></td>
    <td><span data-ttu-id="7e341-245">キリバス</span><span class="sxs-lookup"><span data-stu-id="7e341-245">Kiribati</span></span></td>
    <td><span data-ttu-id="7e341-246">韓国 \*</span><span class="sxs-lookup"><span data-stu-id="7e341-246">Korea \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-247">クウェート</span><span class="sxs-lookup"><span data-stu-id="7e341-247">Kuwait</span></span></td>
    <td><span data-ttu-id="7e341-248">キルギス</span><span class="sxs-lookup"><span data-stu-id="7e341-248">Kyrgyzstan</span></span></td>
    <td><span data-ttu-id="7e341-249">ラオス</span><span class="sxs-lookup"><span data-stu-id="7e341-249">Laos</span></span></td>
    <td><span data-ttu-id="7e341-250">ラトビア</span><span class="sxs-lookup"><span data-stu-id="7e341-250">Latvia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-251">レバノン</span><span class="sxs-lookup"><span data-stu-id="7e341-251">Lebanon</span></span></td>
    <td><span data-ttu-id="7e341-252">レソト</span><span class="sxs-lookup"><span data-stu-id="7e341-252">Lesotho</span></span></td>
    <td><span data-ttu-id="7e341-253">リベリア</span><span class="sxs-lookup"><span data-stu-id="7e341-253">Liberia</span></span></td>
    <td><span data-ttu-id="7e341-254">リビア</span><span class="sxs-lookup"><span data-stu-id="7e341-254">Libya</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-255">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="7e341-255">Liechtenstein</span></span></td>
    <td><span data-ttu-id="7e341-256">リトアニア</span><span class="sxs-lookup"><span data-stu-id="7e341-256">Lithuania</span></span></td>
    <td><span data-ttu-id="7e341-257">ルクセンブルク</span><span class="sxs-lookup"><span data-stu-id="7e341-257">Luxembourg</span></span></td>
    <td><span data-ttu-id="7e341-258">マカオ</span><span class="sxs-lookup"><span data-stu-id="7e341-258">Macao SAR</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-259">マケドニア (旧ユーゴスラビア共和国)</span><span class="sxs-lookup"><span data-stu-id="7e341-259">Macedonia, FYRO</span></span></td>
    <td><span data-ttu-id="7e341-260">マダガスカル</span><span class="sxs-lookup"><span data-stu-id="7e341-260">Madagascar</span></span></td>
    <td><span data-ttu-id="7e341-261">マラウイ</span><span class="sxs-lookup"><span data-stu-id="7e341-261">Malawi</span></span></td>
    <td><span data-ttu-id="7e341-262">マレーシア</span><span class="sxs-lookup"><span data-stu-id="7e341-262">Malaysia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-263">モルディブ</span><span class="sxs-lookup"><span data-stu-id="7e341-263">Maldives</span></span></td>
    <td><span data-ttu-id="7e341-264">マリ</span><span class="sxs-lookup"><span data-stu-id="7e341-264">Mali</span></span></td>
    <td><span data-ttu-id="7e341-265">マルタ</span><span class="sxs-lookup"><span data-stu-id="7e341-265">Malta</span></span></td>
    <td><span data-ttu-id="7e341-266">マーシャル諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-266">Marshall Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-267">マルチニーク島</span><span class="sxs-lookup"><span data-stu-id="7e341-267">Martinique</span></span></td>
    <td><span data-ttu-id="7e341-268">モーリタニア</span><span class="sxs-lookup"><span data-stu-id="7e341-268">Mauritania</span></span></td>
    <td><span data-ttu-id="7e341-269">モーリシャス</span><span class="sxs-lookup"><span data-stu-id="7e341-269">Mauritius</span></span></td>
    <td><span data-ttu-id="7e341-270">マイヨット島</span><span class="sxs-lookup"><span data-stu-id="7e341-270">Mayotte</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-271">メキシコ \*</span><span class="sxs-lookup"><span data-stu-id="7e341-271">Mexico \*</span></span></td>
    <td><span data-ttu-id="7e341-272">ミクロネシア</span><span class="sxs-lookup"><span data-stu-id="7e341-272">Micronesia</span></span></td>
    <td><span data-ttu-id="7e341-273">モルドバ</span><span class="sxs-lookup"><span data-stu-id="7e341-273">Moldova</span></span></td>
    <td><span data-ttu-id="7e341-274">モナコ</span><span class="sxs-lookup"><span data-stu-id="7e341-274">Monaco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-275">モンゴル</span><span class="sxs-lookup"><span data-stu-id="7e341-275">Mongolia</span></span></td>
    <td><span data-ttu-id="7e341-276">モンテネグロ</span><span class="sxs-lookup"><span data-stu-id="7e341-276">Montenegro</span></span></td>
    <td><span data-ttu-id="7e341-277">モンセラット</span><span class="sxs-lookup"><span data-stu-id="7e341-277">Montserrat</span></span></td>
    <td><span data-ttu-id="7e341-278">モロッコ</span><span class="sxs-lookup"><span data-stu-id="7e341-278">Morocco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-279">モザンビーク</span><span class="sxs-lookup"><span data-stu-id="7e341-279">Mozambique</span></span></td>
    <td><span data-ttu-id="7e341-280">ミャンマー</span><span class="sxs-lookup"><span data-stu-id="7e341-280">Myanmar</span></span></td>
    <td><span data-ttu-id="7e341-281">ナミビア</span><span class="sxs-lookup"><span data-stu-id="7e341-281">Namibia</span></span></td>
    <td><span data-ttu-id="7e341-282">ナウル</span><span class="sxs-lookup"><span data-stu-id="7e341-282">Nauru</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-283">ネパール</span><span class="sxs-lookup"><span data-stu-id="7e341-283">Nepal</span></span></td>
    <td><span data-ttu-id="7e341-284">オランダ \*</span><span class="sxs-lookup"><span data-stu-id="7e341-284">Netherlands \*</span></span></td>
    <td><span data-ttu-id="7e341-285">ニューカレドニア</span><span class="sxs-lookup"><span data-stu-id="7e341-285">New Caledonia</span></span></td>
    <td><span data-ttu-id="7e341-286">ニュージーランド \*</span><span class="sxs-lookup"><span data-stu-id="7e341-286">New Zealand \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-287">ニカラグア</span><span class="sxs-lookup"><span data-stu-id="7e341-287">Nicaragua</span></span></td>
    <td><span data-ttu-id="7e341-288">ニジェール</span><span class="sxs-lookup"><span data-stu-id="7e341-288">Niger</span></span></td>
    <td><span data-ttu-id="7e341-289">ナイジェリア</span><span class="sxs-lookup"><span data-stu-id="7e341-289">Nigeria</span></span></td>
    <td><span data-ttu-id="7e341-290">ニウエ</span><span class="sxs-lookup"><span data-stu-id="7e341-290">Niue</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-291">ノーフォーク島</span><span class="sxs-lookup"><span data-stu-id="7e341-291">Norfolk Island</span></span></td>
    <td><span data-ttu-id="7e341-292">北マリアナ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-292">Northern Mariana Islands</span></span></td>
    <td><span data-ttu-id="7e341-293">ノルウェー \*</span><span class="sxs-lookup"><span data-stu-id="7e341-293">Norway \*</span></span></td>
    <td><span data-ttu-id="7e341-294">オマーン</span><span class="sxs-lookup"><span data-stu-id="7e341-294">Oman</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-295">パキスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-295">Pakistan</span></span></td>
    <td><span data-ttu-id="7e341-296">パラオ</span><span class="sxs-lookup"><span data-stu-id="7e341-296">Palau</span></span></td>
    <td><span data-ttu-id="7e341-297">パレスチナ自治政府</span><span class="sxs-lookup"><span data-stu-id="7e341-297">Palestinian Authority</span></span></td>
    <td><span data-ttu-id="7e341-298">パナマ</span><span class="sxs-lookup"><span data-stu-id="7e341-298">Panama</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-299">パプアニューギニア</span><span class="sxs-lookup"><span data-stu-id="7e341-299">Papua New Guinea</span></span></td>
    <td><span data-ttu-id="7e341-300">パラグアイ</span><span class="sxs-lookup"><span data-stu-id="7e341-300">Paraguay</span></span></td>
    <td><span data-ttu-id="7e341-301">ペルー</span><span class="sxs-lookup"><span data-stu-id="7e341-301">Peru</span></span></td>
    <td><span data-ttu-id="7e341-302">フィリピン</span><span class="sxs-lookup"><span data-stu-id="7e341-302">Philippines</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-303">ピトケアン島</span><span class="sxs-lookup"><span data-stu-id="7e341-303">Pitcairn Islands</span></span></td>
    <td><span data-ttu-id="7e341-304">ポーランド \*</span><span class="sxs-lookup"><span data-stu-id="7e341-304">Poland \*</span></span></td>
    <td><span data-ttu-id="7e341-305">ポルトガル \*</span><span class="sxs-lookup"><span data-stu-id="7e341-305">Portugal \*</span></span></td>
    <td><span data-ttu-id="7e341-306">カタール</span><span class="sxs-lookup"><span data-stu-id="7e341-306">Qatar</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-307">レユニオン</span><span class="sxs-lookup"><span data-stu-id="7e341-307">Réunion</span></span></td>
    <td><span data-ttu-id="7e341-308">ルーマニア</span><span class="sxs-lookup"><span data-stu-id="7e341-308">Romania</span></span></td>
    <td><span data-ttu-id="7e341-309">ロシア \*</span><span class="sxs-lookup"><span data-stu-id="7e341-309">Russia \*</span></span></td>
    <td><span data-ttu-id="7e341-310">ルワンダ</span><span class="sxs-lookup"><span data-stu-id="7e341-310">Rwanda</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-311">サン・バルテルミー</span><span class="sxs-lookup"><span data-stu-id="7e341-311">Saint Barthélemy</span></span></td>
    <td><span data-ttu-id="7e341-312">セントヘレナ、アセンションおよびトリスタンダクーニャ</span><span class="sxs-lookup"><span data-stu-id="7e341-312">Saint Helena, Ascension and Tristan da Cunha</span></span></td>
    <td><span data-ttu-id="7e341-313">セントクリストファー・ネイビス</span><span class="sxs-lookup"><span data-stu-id="7e341-313">Saint Kitts and Nevis</span></span></td>
    <td><span data-ttu-id="7e341-314">セントルシア</span><span class="sxs-lookup"><span data-stu-id="7e341-314">Saint Lucia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-315">サンマルタン島 (フランス領)</span><span class="sxs-lookup"><span data-stu-id="7e341-315">Saint Martin (French Part)</span></span></td>
    <td><span data-ttu-id="7e341-316">サンピエール・ミクロン</span><span class="sxs-lookup"><span data-stu-id="7e341-316">Saint Pierre and Miquelon</span></span></td>
    <td><span data-ttu-id="7e341-317">セントビンセントおよびグレナディーン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-317">Saint Vincent and the Grenadines</span></span></td>
    <td><span data-ttu-id="7e341-318">サモア独立国</span><span class="sxs-lookup"><span data-stu-id="7e341-318">Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-319">サンマリノ</span><span class="sxs-lookup"><span data-stu-id="7e341-319">San Marino</span></span></td>
    <td><span data-ttu-id="7e341-320">サントメ・プリンシペ</span><span class="sxs-lookup"><span data-stu-id="7e341-320">São Tomé and Príncipe</span></span></td>
    <td><span data-ttu-id="7e341-321">サウジアラビア \*</span><span class="sxs-lookup"><span data-stu-id="7e341-321">Saudi Arabia \*</span></span></td>
    <td><span data-ttu-id="7e341-322">セネガル</span><span class="sxs-lookup"><span data-stu-id="7e341-322">Senegal</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-323">セルビア</span><span class="sxs-lookup"><span data-stu-id="7e341-323">Serbia</span></span></td>
    <td><span data-ttu-id="7e341-324">セーシェル</span><span class="sxs-lookup"><span data-stu-id="7e341-324">Seychelles</span></span></td>
    <td><span data-ttu-id="7e341-325">シエラレオネ</span><span class="sxs-lookup"><span data-stu-id="7e341-325">Sierra Leone</span></span></td>
    <td><span data-ttu-id="7e341-326">シンガポール \*</span><span class="sxs-lookup"><span data-stu-id="7e341-326">Singapore \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-327">サンマルタン島 (オランダ領)</span><span class="sxs-lookup"><span data-stu-id="7e341-327">Sint Maarten (Dutch Part)</span></span></td>
    <td><span data-ttu-id="7e341-328">スロバキア \*</span><span class="sxs-lookup"><span data-stu-id="7e341-328">Slovakia \*</span></span></td>
    <td><span data-ttu-id="7e341-329">スロベニア</span><span class="sxs-lookup"><span data-stu-id="7e341-329">Slovenia</span></span></td>
    <td><span data-ttu-id="7e341-330">ソロモン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-330">Solomon Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-331">ソマリア</span><span class="sxs-lookup"><span data-stu-id="7e341-331">Somalia</span></span></td>
    <td><span data-ttu-id="7e341-332">南アフリカ \*</span><span class="sxs-lookup"><span data-stu-id="7e341-332">South Africa \*</span></span></td>
    <td><span data-ttu-id="7e341-333">サウスジョージア・サウスサンドウィッチ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-333">South Georgia and the South Sandwich Islands</span></span></td>
    <td><span data-ttu-id="7e341-334">スペイン \*</span><span class="sxs-lookup"><span data-stu-id="7e341-334">Spain \*</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-335">スリランカ</span><span class="sxs-lookup"><span data-stu-id="7e341-335">Sri Lanka</span></span></td>
    <td><span data-ttu-id="7e341-336">スリナム</span><span class="sxs-lookup"><span data-stu-id="7e341-336">Suriname</span></span></td>
    <td><span data-ttu-id="7e341-337">スバールバル諸島、ヤンマイエン島</span><span class="sxs-lookup"><span data-stu-id="7e341-337">Svalbard and Jan Mayen</span></span></td>
    <td><span data-ttu-id="7e341-338">スワジランド</span><span class="sxs-lookup"><span data-stu-id="7e341-338">Swaziland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-339">スウェーデン \*</span><span class="sxs-lookup"><span data-stu-id="7e341-339">Sweden \*</span></span></td>
    <td><span data-ttu-id="7e341-340">スイス \*</span><span class="sxs-lookup"><span data-stu-id="7e341-340">Switzerland \*</span></span></td>
    <td><span data-ttu-id="7e341-341">Taiwan \*</span><span class="sxs-lookup"><span data-stu-id="7e341-341">Taiwan \*</span></span></td>
    <td><span data-ttu-id="7e341-342">タジキスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-342">Tajikistan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-343">タンザニア</span><span class="sxs-lookup"><span data-stu-id="7e341-343">Tanzania</span></span></td>
    <td><span data-ttu-id="7e341-344">タイ</span><span class="sxs-lookup"><span data-stu-id="7e341-344">Thailand</span></span></td>
    <td><span data-ttu-id="7e341-345">ティモール・レステ</span><span class="sxs-lookup"><span data-stu-id="7e341-345">Timor-Leste</span></span></td>
    <td><span data-ttu-id="7e341-346">トーゴ</span><span class="sxs-lookup"><span data-stu-id="7e341-346">Togo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-347">トケラウ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-347">Tokelau</span></span></td>
    <td><span data-ttu-id="7e341-348">トンガ</span><span class="sxs-lookup"><span data-stu-id="7e341-348">Tonga</span></span></td>
    <td><span data-ttu-id="7e341-349">トリニダード・トバゴ</span><span class="sxs-lookup"><span data-stu-id="7e341-349">Trinidad and Tobago</span></span></td>
    <td><span data-ttu-id="7e341-350">チュニジア</span><span class="sxs-lookup"><span data-stu-id="7e341-350">Tunisia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-351">トルコ \*</span><span class="sxs-lookup"><span data-stu-id="7e341-351">Turkey \*</span></span></td>
    <td><span data-ttu-id="7e341-352">トルクメニスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-352">Turkmenistan</span></span></td>
    <td><span data-ttu-id="7e341-353">タークス・カイコス諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-353">Turks and Caicos Islands</span></span></td>
    <td><span data-ttu-id="7e341-354">ツバル</span><span class="sxs-lookup"><span data-stu-id="7e341-354">Tuvalu</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-355">その他の米領諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-355">U.S. Minor Outlying Islands</span></span></td>
    <td><span data-ttu-id="7e341-356">米領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-356">U.S. Virgin Islands</span></span></td>
    <td><span data-ttu-id="7e341-357">ウガンダ</span><span class="sxs-lookup"><span data-stu-id="7e341-357">Uganda</span></span></td>
    <td><span data-ttu-id="7e341-358">ウクライナ</span><span class="sxs-lookup"><span data-stu-id="7e341-358">Ukraine</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-359">アラブ首長国連邦 \*</span><span class="sxs-lookup"><span data-stu-id="7e341-359">United Arab Emirates \*</span></span></td>
    <td><span data-ttu-id="7e341-360">英国 \*</span><span class="sxs-lookup"><span data-stu-id="7e341-360">United Kingdom \*</span></span></td>
    <td><span data-ttu-id="7e341-361">米国 \*</span><span class="sxs-lookup"><span data-stu-id="7e341-361">United States \*</span></span></td>
    <td><span data-ttu-id="7e341-362">ウルグアイ</span><span class="sxs-lookup"><span data-stu-id="7e341-362">Uruguay</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-363">ウズベキスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-363">Uzbekistan</span></span></td>
    <td><span data-ttu-id="7e341-364">バヌアツ</span><span class="sxs-lookup"><span data-stu-id="7e341-364">Vanuatu</span></span></td>
    <td><span data-ttu-id="7e341-365">バチカン市国</span><span class="sxs-lookup"><span data-stu-id="7e341-365">Vatican City</span></span></td>
    <td><span data-ttu-id="7e341-366">ベネズエラ</span><span class="sxs-lookup"><span data-stu-id="7e341-366">Venezuela</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-367">ベトナム</span><span class="sxs-lookup"><span data-stu-id="7e341-367">Vietnam</span></span></td>
    <td><span data-ttu-id="7e341-368">ワリス・フテュナ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-368">Wallis and Futuna</span></span></td>
    <td><span data-ttu-id="7e341-369">Western Sahara (Disputed)</span><span class="sxs-lookup"><span data-stu-id="7e341-369">Western Sahara (Disputed)</span></span></td>
    <td><span data-ttu-id="7e341-370">イエメン</span><span class="sxs-lookup"><span data-stu-id="7e341-370">Yemen</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-371">ザンビア</span><span class="sxs-lookup"><span data-stu-id="7e341-371">Zambia</span></span></td>
    <td><span data-ttu-id="7e341-372">ジンバブエ</span><span class="sxs-lookup"><span data-stu-id="7e341-372">Zimbabwe</span></span></td>
    <td></td>
    <td></td>
  </tr>
</table>


## <a name="price-considerations-for-specific-markets"></a><span data-ttu-id="7e341-373">特定の市場の価格に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="7e341-373">Price considerations for specific markets</span></span>

<span data-ttu-id="7e341-374">ギフトカードや携帯電話会社による課金などの支払方法は、有料アプリおよびアプリ内購入アイテムの販売の増加に役立つ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7e341-374">Payment methods such as gift cards and mobile operator billing can help increase sales of paid apps and in-app purchase items.</span></span> <span data-ttu-id="7e341-375">このような支払い方法を可能にするためのコストは高額になるため、下の表に示す国/地域および支払い方法については、ストア手数料に Commerce Expansion Adjustment (商取引拡大調整) を加え、純収益から差し引いて、有料アプリやアプリ内購入トランザクションに対して支払われるアプリの収益を計算します。</span><span class="sxs-lookup"><span data-stu-id="7e341-375">Due to the higher costs to enable such payment methods, a Commerce Expansion Adjustment is added to the Store Fee deducted from Net Receipts to calculate the App Proceeds payable for paid apps and in-app purchase transactions in the countries/regions and using the payment methods in the tables below.</span></span> <span data-ttu-id="7e341-376">お客様のアプリが利用可能な国/地域で Commerce Expansion Adjustment (商取引拡大調整) が適用されるかどうかを考慮し、それを市場の価格設定戦略に組み込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7e341-376">You may want to consider if the Commerce Expansion Adjustment applies in a country/region where your app is available and factor that into your market pricing strategy.</span></span> <span data-ttu-id="7e341-377">Commerce Expansion Adjustment について詳しくは、「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e341-377">Details about the Commerce Expansion Adjustment can be found in the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement).</span></span>

<span data-ttu-id="7e341-378">Commerce Expansion Adjustment は、有効日現在、指定された国/地域および支払い方法で処理されるすべての取引に適用されます。</span><span class="sxs-lookup"><span data-stu-id="7e341-378">The Commerce Expansion Adjustment will be applied to all transactions processed for the specified Country/Region and Payment Methods as of the Effective Date.</span></span> <span data-ttu-id="7e341-379">この情報は毎月更新され、新しい国/地域および支払方法で Commerce Expansion Adjustment が有効になった日から 30 日以内に、その国/地域および支払方法が一覧表示されます。</span><span class="sxs-lookup"><span data-stu-id="7e341-379">This information will be updated monthly; new countries/regions and payment methods will be listed within thirty (30) days after the Commerce Expansion Adjustment takes effect for that country/region and payment method.</span></span>

&nbsp;

| <span data-ttu-id="7e341-380">国/地域</span><span class="sxs-lookup"><span data-stu-id="7e341-380">Country/region</span></span>       | <span data-ttu-id="7e341-381">支払い方法</span><span class="sxs-lookup"><span data-stu-id="7e341-381">Payment method</span></span>  | <span data-ttu-id="7e341-382">Commerce Expansion Adjustment (商取引拡大調整)</span><span class="sxs-lookup"><span data-stu-id="7e341-382">Commerce Expansion Adjustment</span></span> | <span data-ttu-id="7e341-383">有効日</span><span class="sxs-lookup"><span data-stu-id="7e341-383">Effective date</span></span> |
|----------------------|-----------------|-------------------------------|----------------|
| <span data-ttu-id="7e341-384">アルゼンチン</span><span class="sxs-lookup"><span data-stu-id="7e341-384">Argentina</span></span>            | <span data-ttu-id="7e341-385">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-385">Gift card</span></span>       | <span data-ttu-id="7e341-386">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-386">2.24%</span></span>                         | <span data-ttu-id="7e341-387">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-387">March 2016</span></span>     |
| <span data-ttu-id="7e341-388">オーストラリア</span><span class="sxs-lookup"><span data-stu-id="7e341-388">Australia</span></span>            | <span data-ttu-id="7e341-389">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-389">Gift card</span></span>       | <span data-ttu-id="7e341-390">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-390">2.24%</span></span>                         | <span data-ttu-id="7e341-391">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-391">March 2016</span></span>     |
| <span data-ttu-id="7e341-392">オーストリア</span><span class="sxs-lookup"><span data-stu-id="7e341-392">Austria</span></span>              | <span data-ttu-id="7e341-393">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-393">Gift card</span></span>       | <span data-ttu-id="7e341-394">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-394">2.24%</span></span>                         | <span data-ttu-id="7e341-395">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-395">March 2016</span></span>     |
| <span data-ttu-id="7e341-396">ベルギー</span><span class="sxs-lookup"><span data-stu-id="7e341-396">Belgium</span></span>              | <span data-ttu-id="7e341-397">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-397">Gift card</span></span>       | <span data-ttu-id="7e341-398">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-398">2.24%</span></span>                         | <span data-ttu-id="7e341-399">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-399">March 2016</span></span>     |
| <span data-ttu-id="7e341-400">ブラジル</span><span class="sxs-lookup"><span data-stu-id="7e341-400">Brazil</span></span>               | <span data-ttu-id="7e341-401">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-401">Gift card</span></span>       | <span data-ttu-id="7e341-402">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-402">2.24%</span></span>                         | <span data-ttu-id="7e341-403">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-403">March 2016</span></span>     |
| <span data-ttu-id="7e341-404">カナダ</span><span class="sxs-lookup"><span data-stu-id="7e341-404">Canada</span></span>               | <span data-ttu-id="7e341-405">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-405">Gift card</span></span>       | <span data-ttu-id="7e341-406">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-406">2.24%</span></span>                         | <span data-ttu-id="7e341-407">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-407">March 2016</span></span>     |
| <span data-ttu-id="7e341-408">チリ</span><span class="sxs-lookup"><span data-stu-id="7e341-408">Chile</span></span>                | <span data-ttu-id="7e341-409">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-409">Gift card</span></span>       | <span data-ttu-id="7e341-410">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-410">2.24%</span></span>                         | <span data-ttu-id="7e341-411">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-411">March 2016</span></span>     |
| <span data-ttu-id="7e341-412">中国</span><span class="sxs-lookup"><span data-stu-id="7e341-412">China</span></span>                | <span data-ttu-id="7e341-413">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-413">Gift card</span></span>       | <span data-ttu-id="7e341-414">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-414">2.24%</span></span>                         | <span data-ttu-id="7e341-415">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-415">March 2016</span></span>     |
| <span data-ttu-id="7e341-416">コロンビア</span><span class="sxs-lookup"><span data-stu-id="7e341-416">Colombia</span></span>             | <span data-ttu-id="7e341-417">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-417">Gift card</span></span>       | <span data-ttu-id="7e341-418">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-418">2.24%</span></span>                         | <span data-ttu-id="7e341-419">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-419">March 2016</span></span>     |
| <span data-ttu-id="7e341-420">チェコ共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-420">Czech Republic</span></span>       | <span data-ttu-id="7e341-421">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-421">Gift card</span></span>       | <span data-ttu-id="7e341-422">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-422">2.24%</span></span>                         | <span data-ttu-id="7e341-423">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-423">March 2016</span></span>     |
| <span data-ttu-id="7e341-424">デンマーク</span><span class="sxs-lookup"><span data-stu-id="7e341-424">Denmark</span></span>              | <span data-ttu-id="7e341-425">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-425">Gift card</span></span>       | <span data-ttu-id="7e341-426">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-426">2.24%</span></span>                         | <span data-ttu-id="7e341-427">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-427">March 2016</span></span>     |
| <span data-ttu-id="7e341-428">フィンランド</span><span class="sxs-lookup"><span data-stu-id="7e341-428">Finland</span></span>              | <span data-ttu-id="7e341-429">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-429">Gift card</span></span>       | <span data-ttu-id="7e341-430">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-430">2.24%</span></span>                         | <span data-ttu-id="7e341-431">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-431">March 2016</span></span>     |
| <span data-ttu-id="7e341-432">フランス</span><span class="sxs-lookup"><span data-stu-id="7e341-432">France</span></span>               | <span data-ttu-id="7e341-433">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-433">Gift card</span></span>       | <span data-ttu-id="7e341-434">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-434">2.24%</span></span>                         | <span data-ttu-id="7e341-435">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-435">March 2016</span></span>     |
| <span data-ttu-id="7e341-436">ドイツ</span><span class="sxs-lookup"><span data-stu-id="7e341-436">Germany</span></span>              | <span data-ttu-id="7e341-437">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-437">Gift card</span></span>       | <span data-ttu-id="7e341-438">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-438">2.24%</span></span>                         | <span data-ttu-id="7e341-439">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-439">March 2016</span></span>     |
| <span data-ttu-id="7e341-440">ギリシャ</span><span class="sxs-lookup"><span data-stu-id="7e341-440">Greece</span></span>               | <span data-ttu-id="7e341-441">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-441">Gift card</span></span>       | <span data-ttu-id="7e341-442">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-442">2.24%</span></span>                         | <span data-ttu-id="7e341-443">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-443">March 2016</span></span>     |
| <span data-ttu-id="7e341-444">香港</span><span class="sxs-lookup"><span data-stu-id="7e341-444">Hong Kong</span></span>            | <span data-ttu-id="7e341-445">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-445">Gift card</span></span>       | <span data-ttu-id="7e341-446">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-446">2.24%</span></span>                         | <span data-ttu-id="7e341-447">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-447">March 2016</span></span>     |
| <span data-ttu-id="7e341-448">ハンガリー</span><span class="sxs-lookup"><span data-stu-id="7e341-448">Hungary</span></span>              | <span data-ttu-id="7e341-449">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-449">Gift card</span></span>       | <span data-ttu-id="7e341-450">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-450">2.24%</span></span>                         | <span data-ttu-id="7e341-451">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-451">March 2016</span></span>     |
| <span data-ttu-id="7e341-452">インド</span><span class="sxs-lookup"><span data-stu-id="7e341-452">India</span></span>                | <span data-ttu-id="7e341-453">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-453">Gift card</span></span>       | <span data-ttu-id="7e341-454">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-454">2.24%</span></span>                         | <span data-ttu-id="7e341-455">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-455">March 2016</span></span>     |
| <span data-ttu-id="7e341-456">アイルランド</span><span class="sxs-lookup"><span data-stu-id="7e341-456">Ireland</span></span>              | <span data-ttu-id="7e341-457">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-457">Gift card</span></span>       | <span data-ttu-id="7e341-458">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-458">2.24%</span></span>                         | <span data-ttu-id="7e341-459">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-459">March 2016</span></span>     |
| <span data-ttu-id="7e341-460">イスラエル</span><span class="sxs-lookup"><span data-stu-id="7e341-460">Israel</span></span>               | <span data-ttu-id="7e341-461">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-461">Gift card</span></span>       | <span data-ttu-id="7e341-462">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-462">2.24%</span></span>                         | <span data-ttu-id="7e341-463">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-463">March 2016</span></span>     |
| <span data-ttu-id="7e341-464">イタリア</span><span class="sxs-lookup"><span data-stu-id="7e341-464">Italy</span></span>                | <span data-ttu-id="7e341-465">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-465">Gift card</span></span>       | <span data-ttu-id="7e341-466">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-466">2.24%</span></span>                         | <span data-ttu-id="7e341-467">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-467">March 2016</span></span>     |
| <span data-ttu-id="7e341-468">日本</span><span class="sxs-lookup"><span data-stu-id="7e341-468">Japan</span></span>                | <span data-ttu-id="7e341-469">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-469">Gift card</span></span>       | <span data-ttu-id="7e341-470">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-470">2.24%</span></span>                         | <span data-ttu-id="7e341-471">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-471">March 2016</span></span>     |
| <span data-ttu-id="7e341-472">メキシコ</span><span class="sxs-lookup"><span data-stu-id="7e341-472">Mexico</span></span>               | <span data-ttu-id="7e341-473">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-473">Gift card</span></span>       | <span data-ttu-id="7e341-474">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-474">2.24%</span></span>                         | <span data-ttu-id="7e341-475">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-475">March 2016</span></span>     |
| <span data-ttu-id="7e341-476">オランダ</span><span class="sxs-lookup"><span data-stu-id="7e341-476">Netherlands</span></span>          | <span data-ttu-id="7e341-477">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-477">Gift card</span></span>       | <span data-ttu-id="7e341-478">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-478">2.24%</span></span>                         | <span data-ttu-id="7e341-479">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-479">March 2016</span></span>     |
| <span data-ttu-id="7e341-480">ニュージーランド</span><span class="sxs-lookup"><span data-stu-id="7e341-480">New Zealand</span></span>          | <span data-ttu-id="7e341-481">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-481">Gift card</span></span>       | <span data-ttu-id="7e341-482">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-482">2.24%</span></span>                         | <span data-ttu-id="7e341-483">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-483">March 2016</span></span>     |
| <span data-ttu-id="7e341-484">ポーランド</span><span class="sxs-lookup"><span data-stu-id="7e341-484">Poland</span></span>               | <span data-ttu-id="7e341-485">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-485">Gift card</span></span>       | <span data-ttu-id="7e341-486">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-486">2.24%</span></span>                         | <span data-ttu-id="7e341-487">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-487">March 2016</span></span>     |
| <span data-ttu-id="7e341-488">ポルトガル</span><span class="sxs-lookup"><span data-stu-id="7e341-488">Portugal</span></span>             | <span data-ttu-id="7e341-489">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-489">Gift card</span></span>       | <span data-ttu-id="7e341-490">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-490">2.24%</span></span>                         | <span data-ttu-id="7e341-491">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-491">March 2016</span></span>     |
| <span data-ttu-id="7e341-492">ロシア</span><span class="sxs-lookup"><span data-stu-id="7e341-492">Russia</span></span>               | <span data-ttu-id="7e341-493">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-493">Gift card</span></span>       | <span data-ttu-id="7e341-494">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-494">2.24%</span></span>                         | <span data-ttu-id="7e341-495">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-495">March 2016</span></span>     |
| <span data-ttu-id="7e341-496">サウジアラビア</span><span class="sxs-lookup"><span data-stu-id="7e341-496">Saudi Arabia</span></span>         | <span data-ttu-id="7e341-497">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-497">Gift card</span></span>       | <span data-ttu-id="7e341-498">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-498">2.24%</span></span>                         | <span data-ttu-id="7e341-499">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-499">March 2016</span></span>     |
| <span data-ttu-id="7e341-500">シンガポール</span><span class="sxs-lookup"><span data-stu-id="7e341-500">Singapore</span></span>            | <span data-ttu-id="7e341-501">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-501">Gift card</span></span>       | <span data-ttu-id="7e341-502">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-502">2.24%</span></span>                         | <span data-ttu-id="7e341-503">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-503">March 2016</span></span>     |
| <span data-ttu-id="7e341-504">スロバキア</span><span class="sxs-lookup"><span data-stu-id="7e341-504">Slovakia</span></span>             | <span data-ttu-id="7e341-505">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-505">Gift card</span></span>       | <span data-ttu-id="7e341-506">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-506">2.24%</span></span>                         | <span data-ttu-id="7e341-507">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-507">March 2016</span></span>     |
| <span data-ttu-id="7e341-508">南アフリカ</span><span class="sxs-lookup"><span data-stu-id="7e341-508">South Africa</span></span>         | <span data-ttu-id="7e341-509">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-509">Gift card</span></span>       | <span data-ttu-id="7e341-510">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-510">2.24%</span></span>                         | <span data-ttu-id="7e341-511">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-511">March 2016</span></span>     |
| <span data-ttu-id="7e341-512">韓国</span><span class="sxs-lookup"><span data-stu-id="7e341-512">South Korea</span></span>          | <span data-ttu-id="7e341-513">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-513">Gift card</span></span>       | <span data-ttu-id="7e341-514">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-514">2.24%</span></span>                         | <span data-ttu-id="7e341-515">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-515">March 2016</span></span>     |
| <span data-ttu-id="7e341-516">スペイン</span><span class="sxs-lookup"><span data-stu-id="7e341-516">Spain</span></span>                | <span data-ttu-id="7e341-517">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-517">Gift card</span></span>       | <span data-ttu-id="7e341-518">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-518">2.24%</span></span>                         | <span data-ttu-id="7e341-519">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-519">March 2016</span></span>     |
| <span data-ttu-id="7e341-520">スウェーデン</span><span class="sxs-lookup"><span data-stu-id="7e341-520">Sweden</span></span>               | <span data-ttu-id="7e341-521">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-521">Gift card</span></span>       | <span data-ttu-id="7e341-522">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-522">2.24%</span></span>                         | <span data-ttu-id="7e341-523">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-523">March 2016</span></span>     |
| <span data-ttu-id="7e341-524">スイス</span><span class="sxs-lookup"><span data-stu-id="7e341-524">Switzerland</span></span>          | <span data-ttu-id="7e341-525">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-525">Gift card</span></span>       | <span data-ttu-id="7e341-526">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-526">2.24%</span></span>                         | <span data-ttu-id="7e341-527">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-527">March 2016</span></span>     |
| <span data-ttu-id="7e341-528">台湾</span><span class="sxs-lookup"><span data-stu-id="7e341-528">Taiwan</span></span>               | <span data-ttu-id="7e341-529">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-529">Gift card</span></span>       | <span data-ttu-id="7e341-530">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-530">2.24%</span></span>                         | <span data-ttu-id="7e341-531">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-531">March 2016</span></span>     |
| <span data-ttu-id="7e341-532">トルコ</span><span class="sxs-lookup"><span data-stu-id="7e341-532">Turkey</span></span>               | <span data-ttu-id="7e341-533">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-533">Gift card</span></span>       | <span data-ttu-id="7e341-534">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-534">2.24%</span></span>                         | <span data-ttu-id="7e341-535">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-535">March 2016</span></span>     |
| <span data-ttu-id="7e341-536">アラブ首長国連邦</span><span class="sxs-lookup"><span data-stu-id="7e341-536">United Arab Emirates</span></span> | <span data-ttu-id="7e341-537">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-537">Gift card</span></span>       | <span data-ttu-id="7e341-538">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-538">2.24%</span></span>                         | <span data-ttu-id="7e341-539">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-539">March 2016</span></span>     |
| <span data-ttu-id="7e341-540">英国</span><span class="sxs-lookup"><span data-stu-id="7e341-540">United Kingdom</span></span>       | <span data-ttu-id="7e341-541">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-541">Gift card</span></span>       | <span data-ttu-id="7e341-542">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-542">2.24%</span></span>                         | <span data-ttu-id="7e341-543">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-543">March 2016</span></span>     |
| <span data-ttu-id="7e341-544">米国</span><span class="sxs-lookup"><span data-stu-id="7e341-544">United States</span></span>        | <span data-ttu-id="7e341-545">ギフト カード</span><span class="sxs-lookup"><span data-stu-id="7e341-545">Gift card</span></span>       | <span data-ttu-id="7e341-546">2.24%</span><span class="sxs-lookup"><span data-stu-id="7e341-546">2.24%</span></span>                         | <span data-ttu-id="7e341-547">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="7e341-547">March 2016</span></span>     |

 

## <a name="rest-of-world-markets-for-windows-8x"></a><span data-ttu-id="7e341-548">Windows 8.x の "その他の国と地域" 市場</span><span class="sxs-lookup"><span data-stu-id="7e341-548">"Rest of World" markets for Windows 8.x</span></span>

<span data-ttu-id="7e341-549">アプリには、Windows を対象とするパッケージが含まれている場合、8.x が市場の数値が windows ストアを使用して顧客の 1 つ「残りの世界」market として扱われることに注意すべき重要な Windows デベロッパー センター内の個々 の市場として表示されている場合でも、8.xダッシュ ボード (以前のストア ダッシュ ボードではなく「残りの世界」市場オプションをすべてこのような市場のグループ化があった場合)。</span><span class="sxs-lookup"><span data-stu-id="7e341-549">If your app includes packages targeting Windows 8.x, it's important to be aware that a number of markets are treated as a single "Rest of World" market for customers using the Store on Windows 8.x, even though they are shown as individual markets in the Windows Dev Center dashboard (as opposed to the earlier Store dashboard, where there was one "Rest of World" market option to group all of these markets).</span></span>

<span data-ttu-id="7e341-550">アプリを申請するときに、既定の項目を選択したままにしている場合、この問題について心配する必要はありません。アプリは可能なすべての市場に公開されます。</span><span class="sxs-lookup"><span data-stu-id="7e341-550">If you leave the default selection when submitting your app, you don't have to worry about this, and your app will be available to all possible markets.</span></span> <span data-ttu-id="7e341-551">ただし、特定の市場を除外する場合、これらの "その他の国と地域" 市場のいずれかの市場を除外すると、Windows 8 または Windows 8.1 ユーザー向けの "その他の国と地域" 市場のどの市場にもアプリが公開されないことを意味することに留意してください。</span><span class="sxs-lookup"><span data-stu-id="7e341-551">However, if you want to exclude certain markets, keep in mind that excluding even one of these "Rest of World" markets means that your app won't be available in any of the "Rest of World" markets for customers on Windows 8 or Windows 8.1.</span></span>

<span data-ttu-id="7e341-552">Windows 8.x 向けの "その他の国と地域" に含まれている市場は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7e341-552">The markets that are included in "Rest of World" for Windows 8.x are the following:</span></span>


<table>
  <tr>
    <td><span data-ttu-id="7e341-553">アフガニスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-553">Afghanistan</span></span></td>
    <td><span data-ttu-id="7e341-554">オーランド諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-554">Åland Islands</span></span></td>
    <td><span data-ttu-id="7e341-555">アルバニア</span><span class="sxs-lookup"><span data-stu-id="7e341-555">Albania</span></span></td>
    <td><span data-ttu-id="7e341-556">アメリカ領サモア</span><span class="sxs-lookup"><span data-stu-id="7e341-556">American Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-557">アンドラ</span><span class="sxs-lookup"><span data-stu-id="7e341-557">Andorra</span></span></td>
    <td><span data-ttu-id="7e341-558">アンゴラ</span><span class="sxs-lookup"><span data-stu-id="7e341-558">Angola</span></span></td>
    <td><span data-ttu-id="7e341-559">アンギラ</span><span class="sxs-lookup"><span data-stu-id="7e341-559">Anguilla</span></span></td>
    <td><span data-ttu-id="7e341-560">南極</span><span class="sxs-lookup"><span data-stu-id="7e341-560">Antarctica</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-561">アンティグア・バーブーダ</span><span class="sxs-lookup"><span data-stu-id="7e341-561">Antigua and Barbuda</span></span></td>
    <td><span data-ttu-id="7e341-562">アルメニア</span><span class="sxs-lookup"><span data-stu-id="7e341-562">Armenia</span></span></td>
    <td><span data-ttu-id="7e341-563">アルバ</span><span class="sxs-lookup"><span data-stu-id="7e341-563">Aruba</span></span></td>
    <td><span data-ttu-id="7e341-564">アゼルバイジャン</span><span class="sxs-lookup"><span data-stu-id="7e341-564">Azerbaijan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-565">バハマ</span><span class="sxs-lookup"><span data-stu-id="7e341-565">Bahamas</span></span></td>
    <td><span data-ttu-id="7e341-566">バングラデシュ</span><span class="sxs-lookup"><span data-stu-id="7e341-566">Bangladesh</span></span></td>
    <td><span data-ttu-id="7e341-567">バルバドス</span><span class="sxs-lookup"><span data-stu-id="7e341-567">Barbados</span></span></td>
    <td><span data-ttu-id="7e341-568">ベラルーシ</span><span class="sxs-lookup"><span data-stu-id="7e341-568">Belarus</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-569">ベリーズ</span><span class="sxs-lookup"><span data-stu-id="7e341-569">Belize</span></span></td>
    <td><span data-ttu-id="7e341-570">ベナン</span><span class="sxs-lookup"><span data-stu-id="7e341-570">Benin</span></span></td>
    <td><span data-ttu-id="7e341-571">バミューダ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-571">Bermuda</span></span></td>
    <td><span data-ttu-id="7e341-572">ブータン</span><span class="sxs-lookup"><span data-stu-id="7e341-572">Bhutan</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-573">ボリビア</span><span class="sxs-lookup"><span data-stu-id="7e341-573">Bolivia</span></span></td>
    <td><span data-ttu-id="7e341-574">ボネール島</span><span class="sxs-lookup"><span data-stu-id="7e341-574">Bonaire</span></span></td>
    <td><span data-ttu-id="7e341-575">ボスニア・ヘルツェゴビナ</span><span class="sxs-lookup"><span data-stu-id="7e341-575">Bosnia and Herzegovina</span></span></td>
    <td><span data-ttu-id="7e341-576">ボツワナ</span><span class="sxs-lookup"><span data-stu-id="7e341-576">Botswana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-577">ブーベ島</span><span class="sxs-lookup"><span data-stu-id="7e341-577">Bouvet Island</span></span></td>
    <td><span data-ttu-id="7e341-578">英領インド洋地域</span><span class="sxs-lookup"><span data-stu-id="7e341-578">British Indian Ocean Territory</span></span></td>
    <td><span data-ttu-id="7e341-579">英領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-579">British Virgin Islands</span></span></td>
    <td><span data-ttu-id="7e341-580">ブルネイ</span><span class="sxs-lookup"><span data-stu-id="7e341-580">Brunei</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-581">ブルキナファソ</span><span class="sxs-lookup"><span data-stu-id="7e341-581">Burkina Faso</span></span></td>
    <td><span data-ttu-id="7e341-582">ブルンジ</span><span class="sxs-lookup"><span data-stu-id="7e341-582">Burundi</span></span></td>
    <td><span data-ttu-id="7e341-583">カーボベルデ</span><span class="sxs-lookup"><span data-stu-id="7e341-583">Cabo Verde</span></span></td>
    <td><span data-ttu-id="7e341-584">カンボジア</span><span class="sxs-lookup"><span data-stu-id="7e341-584">Cambodia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-585">カメルーン</span><span class="sxs-lookup"><span data-stu-id="7e341-585">Cameroon</span></span></td>
    <td><span data-ttu-id="7e341-586">ケイマン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-586">Cayman Islands</span></span></td>
    <td><span data-ttu-id="7e341-587">中央アフリカ共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-587">Central African Republic</span></span></td>
    <td><span data-ttu-id="7e341-588">チャド</span><span class="sxs-lookup"><span data-stu-id="7e341-588">Chad</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-589">クリスマス島</span><span class="sxs-lookup"><span data-stu-id="7e341-589">Christmas Island</span></span></td>
    <td><span data-ttu-id="7e341-590">ココス諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-590">Cocos (Keeling) Islands</span></span></td>
    <td><span data-ttu-id="7e341-591">コモロ</span><span class="sxs-lookup"><span data-stu-id="7e341-591">Comoros</span></span></td>
    <td><span data-ttu-id="7e341-592">コンゴ共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-592">Congo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-593">コンゴ民主共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-593">Congo (DRC)</span></span></td>
    <td><span data-ttu-id="7e341-594">クック諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-594">Cook Islands</span></span></td>
    <td><span data-ttu-id="7e341-595">コートジボワール</span><span class="sxs-lookup"><span data-stu-id="7e341-595">Côte d’Ivoire</span></span></td>
    <td><span data-ttu-id="7e341-596">キュラソー島</span><span class="sxs-lookup"><span data-stu-id="7e341-596">Curaçao</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-597">ジブチ</span><span class="sxs-lookup"><span data-stu-id="7e341-597">Djibouti</span></span></td>
    <td><span data-ttu-id="7e341-598">ドミニカ国</span><span class="sxs-lookup"><span data-stu-id="7e341-598">Dominica</span></span></td>
    <td><span data-ttu-id="7e341-599">ドミニカ共和国</span><span class="sxs-lookup"><span data-stu-id="7e341-599">Dominican Republic</span></span></td>
    <td><span data-ttu-id="7e341-600">エクアドル</span><span class="sxs-lookup"><span data-stu-id="7e341-600">Ecuador</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-601">エルサルバドル</span><span class="sxs-lookup"><span data-stu-id="7e341-601">El Salvador</span></span></td>
    <td><span data-ttu-id="7e341-602">赤道ギニア</span><span class="sxs-lookup"><span data-stu-id="7e341-602">Equatorial Guinea</span></span></td>
    <td><span data-ttu-id="7e341-603">エリトリア</span><span class="sxs-lookup"><span data-stu-id="7e341-603">Eritrea</span></span></td>
    <td><span data-ttu-id="7e341-604">エチオピア</span><span class="sxs-lookup"><span data-stu-id="7e341-604">Ethiopia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-605">フォークランド諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-605">Falkland Islands</span></span></td>
    <td><span data-ttu-id="7e341-606">フェロー諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-606">Faroe Islands</span></span></td>
    <td><span data-ttu-id="7e341-607">フィジー</span><span class="sxs-lookup"><span data-stu-id="7e341-607">Fiji</span></span></td>
    <td><span data-ttu-id="7e341-608">フランス領ギアナ</span><span class="sxs-lookup"><span data-stu-id="7e341-608">French Guiana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-609">フランス領ポリネシア</span><span class="sxs-lookup"><span data-stu-id="7e341-609">French Polynesia</span></span></td>
    <td><span data-ttu-id="7e341-610">フランス領南極地方</span><span class="sxs-lookup"><span data-stu-id="7e341-610">French Southern and Antarctic Lands</span></span></td>
    <td><span data-ttu-id="7e341-611">ガボン</span><span class="sxs-lookup"><span data-stu-id="7e341-611">Gabon</span></span></td>
    <td><span data-ttu-id="7e341-612">ガンビア</span><span class="sxs-lookup"><span data-stu-id="7e341-612">Gambia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-613">ジョージア</span><span class="sxs-lookup"><span data-stu-id="7e341-613">Georgia</span></span></td>
    <td><span data-ttu-id="7e341-614">ガーナ</span><span class="sxs-lookup"><span data-stu-id="7e341-614">Ghana</span></span></td>
    <td><span data-ttu-id="7e341-615">ジブラルタル</span><span class="sxs-lookup"><span data-stu-id="7e341-615">Gibraltar</span></span></td>
    <td><span data-ttu-id="7e341-616">グリーンランド</span><span class="sxs-lookup"><span data-stu-id="7e341-616">Greenland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-617">グレナダ</span><span class="sxs-lookup"><span data-stu-id="7e341-617">Grenada</span></span></td>
    <td><span data-ttu-id="7e341-618">グアドループ</span><span class="sxs-lookup"><span data-stu-id="7e341-618">Guadeloupe</span></span></td>
    <td><span data-ttu-id="7e341-619">グアム</span><span class="sxs-lookup"><span data-stu-id="7e341-619">Guam</span></span></td>
    <td><span data-ttu-id="7e341-620">グアテマラ</span><span class="sxs-lookup"><span data-stu-id="7e341-620">Guatemala</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-621">ガーンジー島</span><span class="sxs-lookup"><span data-stu-id="7e341-621">Guernsey</span></span></td>
    <td><span data-ttu-id="7e341-622">ギニア</span><span class="sxs-lookup"><span data-stu-id="7e341-622">Guinea</span></span></td>
    <td><span data-ttu-id="7e341-623">ギニアビサウ</span><span class="sxs-lookup"><span data-stu-id="7e341-623">Guinea-Bissau</span></span></td>
    <td><span data-ttu-id="7e341-624">ガイアナ</span><span class="sxs-lookup"><span data-stu-id="7e341-624">Guyana</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-625">ハイチ</span><span class="sxs-lookup"><span data-stu-id="7e341-625">Haiti</span></span></td>
    <td><span data-ttu-id="7e341-626">ハード・マクドナルド諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-626">Heard Island and McDonald Islands</span></span></td>
    <td><span data-ttu-id="7e341-627">ホンジュラス</span><span class="sxs-lookup"><span data-stu-id="7e341-627">Honduras</span></span></td>
    <td><span data-ttu-id="7e341-628">アイスランド</span><span class="sxs-lookup"><span data-stu-id="7e341-628">Iceland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-629">マン島</span><span class="sxs-lookup"><span data-stu-id="7e341-629">Isle of Man</span></span></td>
    <td><span data-ttu-id="7e341-630">ジャマイカ</span><span class="sxs-lookup"><span data-stu-id="7e341-630">Jamaica</span></span></td>
    <td><span data-ttu-id="7e341-631">ジャージー島</span><span class="sxs-lookup"><span data-stu-id="7e341-631">Jersey</span></span></td>
    <td><span data-ttu-id="7e341-632">ケニア</span><span class="sxs-lookup"><span data-stu-id="7e341-632">Kenya</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-633">キリバス</span><span class="sxs-lookup"><span data-stu-id="7e341-633">Kiribati</span></span></td>
    <td><span data-ttu-id="7e341-634">キルギス</span><span class="sxs-lookup"><span data-stu-id="7e341-634">Kyrgyzstan</span></span></td>
    <td><span data-ttu-id="7e341-635">ラオス</span><span class="sxs-lookup"><span data-stu-id="7e341-635">Laos</span></span></td>
    <td><span data-ttu-id="7e341-636">レソト</span><span class="sxs-lookup"><span data-stu-id="7e341-636">Lesotho</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-637">リベリア</span><span class="sxs-lookup"><span data-stu-id="7e341-637">Liberia</span></span></td>
    <td><span data-ttu-id="7e341-638">リヒテンシュタイン</span><span class="sxs-lookup"><span data-stu-id="7e341-638">Liechtenstein</span></span></td>
    <td><span data-ttu-id="7e341-639">マカオ</span><span class="sxs-lookup"><span data-stu-id="7e341-639">Macao SAR</span></span></td>
    <td><span data-ttu-id="7e341-640">マケドニア (旧ユーゴスラビア共和国)</span><span class="sxs-lookup"><span data-stu-id="7e341-640">Macedonia, FYRO</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-641">マダガスカル</span><span class="sxs-lookup"><span data-stu-id="7e341-641">Madagascar</span></span></td>
    <td><span data-ttu-id="7e341-642">マラウイ</span><span class="sxs-lookup"><span data-stu-id="7e341-642">Malawi</span></span></td>
    <td><span data-ttu-id="7e341-643">モルディブ</span><span class="sxs-lookup"><span data-stu-id="7e341-643">Maldives</span></span></td>
    <td><span data-ttu-id="7e341-644">マリ</span><span class="sxs-lookup"><span data-stu-id="7e341-644">Mali</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-645">マーシャル諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-645">Marshall Islands</span></span></td>
    <td><span data-ttu-id="7e341-646">マルチニーク島</span><span class="sxs-lookup"><span data-stu-id="7e341-646">Martinique</span></span></td>
    <td><span data-ttu-id="7e341-647">モーリタニア</span><span class="sxs-lookup"><span data-stu-id="7e341-647">Mauritania</span></span></td>
    <td><span data-ttu-id="7e341-648">モーリシャス</span><span class="sxs-lookup"><span data-stu-id="7e341-648">Mauritius</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-649">マイヨット島</span><span class="sxs-lookup"><span data-stu-id="7e341-649">Mayotte</span></span></td>
    <td><span data-ttu-id="7e341-650">ミクロネシア</span><span class="sxs-lookup"><span data-stu-id="7e341-650">Micronesia</span></span></td>
    <td><span data-ttu-id="7e341-651">モルドバ</span><span class="sxs-lookup"><span data-stu-id="7e341-651">Moldova</span></span></td>
    <td><span data-ttu-id="7e341-652">モナコ</span><span class="sxs-lookup"><span data-stu-id="7e341-652">Monaco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-653">モンゴル</span><span class="sxs-lookup"><span data-stu-id="7e341-653">Mongolia</span></span></td>
    <td><span data-ttu-id="7e341-654">モンテネグロ</span><span class="sxs-lookup"><span data-stu-id="7e341-654">Montenegro</span></span></td>
    <td><span data-ttu-id="7e341-655">モンセラット</span><span class="sxs-lookup"><span data-stu-id="7e341-655">Montserrat</span></span></td>
    <td><span data-ttu-id="7e341-656">モロッコ</span><span class="sxs-lookup"><span data-stu-id="7e341-656">Morocco</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-657">モザンビーク</span><span class="sxs-lookup"><span data-stu-id="7e341-657">Mozambique</span></span></td>
    <td><span data-ttu-id="7e341-658">ミャンマー</span><span class="sxs-lookup"><span data-stu-id="7e341-658">Myanmar</span></span></td>
    <td><span data-ttu-id="7e341-659">ナミビア</span><span class="sxs-lookup"><span data-stu-id="7e341-659">Namibia</span></span></td>
    <td><span data-ttu-id="7e341-660">ナウル</span><span class="sxs-lookup"><span data-stu-id="7e341-660">Nauru</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-661">ネパール</span><span class="sxs-lookup"><span data-stu-id="7e341-661">Nepal</span></span></td>
    <td><span data-ttu-id="7e341-662">ニューカレドニア</span><span class="sxs-lookup"><span data-stu-id="7e341-662">New Caledonia</span></span></td>
    <td><span data-ttu-id="7e341-663">ニカラグア</span><span class="sxs-lookup"><span data-stu-id="7e341-663">Nicaragua</span></span></td>
    <td><span data-ttu-id="7e341-664">ニジェール</span><span class="sxs-lookup"><span data-stu-id="7e341-664">Niger</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-665">ナイジェリア</span><span class="sxs-lookup"><span data-stu-id="7e341-665">Nigeria</span></span></td>
    <td><span data-ttu-id="7e341-666">ニウエ</span><span class="sxs-lookup"><span data-stu-id="7e341-666">Niue</span></span></td>
    <td><span data-ttu-id="7e341-667">ノーフォーク島</span><span class="sxs-lookup"><span data-stu-id="7e341-667">Norfolk Island</span></span></td>
    <td><span data-ttu-id="7e341-668">北マリアナ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-668">Northern Mariana Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-669">パラオ</span><span class="sxs-lookup"><span data-stu-id="7e341-669">Palau</span></span></td>
    <td><span data-ttu-id="7e341-670">パレスチナ自治政府</span><span class="sxs-lookup"><span data-stu-id="7e341-670">Palestinian Authority</span></span></td>
    <td><span data-ttu-id="7e341-671">パナマ</span><span class="sxs-lookup"><span data-stu-id="7e341-671">Panama</span></span></td>
    <td><span data-ttu-id="7e341-672">パプアニューギニア</span><span class="sxs-lookup"><span data-stu-id="7e341-672">Papua New Guinea</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-673">パラグアイ</span><span class="sxs-lookup"><span data-stu-id="7e341-673">Paraguay</span></span></td>
    <td><span data-ttu-id="7e341-674">ピトケアン島</span><span class="sxs-lookup"><span data-stu-id="7e341-674">Pitcairn Islands</span></span></td>
    <td><span data-ttu-id="7e341-675">レユニオン</span><span class="sxs-lookup"><span data-stu-id="7e341-675">Réunion</span></span></td>
    <td><span data-ttu-id="7e341-676">ルワンダ</span><span class="sxs-lookup"><span data-stu-id="7e341-676">Rwanda</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-677">サン・バルテルミー</span><span class="sxs-lookup"><span data-stu-id="7e341-677">Saint Barthélemy</span></span></td>
    <td><span data-ttu-id="7e341-678">セントヘレナ、アセンションおよびトリスタンダクーニャ</span><span class="sxs-lookup"><span data-stu-id="7e341-678">Saint Helena, Ascension and Tristan da Cunha</span></span></td>
    <td><span data-ttu-id="7e341-679">セントクリストファー・ネイビス</span><span class="sxs-lookup"><span data-stu-id="7e341-679">Saint Kitts and Nevis</span></span></td>
    <td><span data-ttu-id="7e341-680">セントルシア</span><span class="sxs-lookup"><span data-stu-id="7e341-680">Saint Lucia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-681">サンマルタン島 (フランス領)</span><span class="sxs-lookup"><span data-stu-id="7e341-681">Saint Martin (French Part)</span></span></td>
    <td><span data-ttu-id="7e341-682">サンピエール・ミクロン</span><span class="sxs-lookup"><span data-stu-id="7e341-682">Saint Pierre and Miquelon</span></span></td>
    <td><span data-ttu-id="7e341-683">セントビンセントおよびグレナディーン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-683">Saint Vincent and the Grenadines</span></span></td>
    <td><span data-ttu-id="7e341-684">サモア独立国</span><span class="sxs-lookup"><span data-stu-id="7e341-684">Samoa</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-685">サンマリノ</span><span class="sxs-lookup"><span data-stu-id="7e341-685">San Marino</span></span></td>
    <td><span data-ttu-id="7e341-686">サントメ・プリンシペ</span><span class="sxs-lookup"><span data-stu-id="7e341-686">São Tomé and Príncipe</span></span></td>
    <td><span data-ttu-id="7e341-687">セネガル</span><span class="sxs-lookup"><span data-stu-id="7e341-687">Senegal</span></span></td>
    <td><span data-ttu-id="7e341-688">セーシェル</span><span class="sxs-lookup"><span data-stu-id="7e341-688">Seychelles</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-689">シエラレオネ</span><span class="sxs-lookup"><span data-stu-id="7e341-689">Sierra Leone</span></span></td>
    <td><span data-ttu-id="7e341-690">サンマルタン島 (オランダ領)</span><span class="sxs-lookup"><span data-stu-id="7e341-690">Sint Maarten (Dutch Part)</span></span></td>
    <td><span data-ttu-id="7e341-691">ソロモン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-691">Solomon Islands</span></span></td>
    <td><span data-ttu-id="7e341-692">ソマリア</span><span class="sxs-lookup"><span data-stu-id="7e341-692">Somalia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-693">サウスジョージア・サウスサンドウィッチ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-693">South Georgia and the South Sandwich Islands</span></span></td>
    <td><span data-ttu-id="7e341-694">スリナム</span><span class="sxs-lookup"><span data-stu-id="7e341-694">Suriname</span></span></td>
    <td><span data-ttu-id="7e341-695">スバールバル諸島、ヤンマイエン島</span><span class="sxs-lookup"><span data-stu-id="7e341-695">Svalbard and Jan Mayen</span></span></td>
    <td><span data-ttu-id="7e341-696">スワジランド</span><span class="sxs-lookup"><span data-stu-id="7e341-696">Swaziland</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-697">タジキスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-697">Tajikistan</span></span></td>
    <td><span data-ttu-id="7e341-698">タンザニア</span><span class="sxs-lookup"><span data-stu-id="7e341-698">Tanzania</span></span></td>
    <td><span data-ttu-id="7e341-699">ティモール・レステ</span><span class="sxs-lookup"><span data-stu-id="7e341-699">Timor-Leste</span></span></td>
    <td><span data-ttu-id="7e341-700">トーゴ</span><span class="sxs-lookup"><span data-stu-id="7e341-700">Togo</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-701">トケラウ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-701">Tokelau</span></span></td>
    <td><span data-ttu-id="7e341-702">トンガ</span><span class="sxs-lookup"><span data-stu-id="7e341-702">Tonga</span></span></td>
    <td><span data-ttu-id="7e341-703">トルクメニスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-703">Turkmenistan</span></span></td>
    <td><span data-ttu-id="7e341-704">タークス・カイコス諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-704">Turks and Caicos Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-705">ツバル</span><span class="sxs-lookup"><span data-stu-id="7e341-705">Tuvalu</span></span></td>
    <td><span data-ttu-id="7e341-706">ウガンダ</span><span class="sxs-lookup"><span data-stu-id="7e341-706">Uganda</span></span></td>
    <td><span data-ttu-id="7e341-707">その他の米領諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-707">U.S. Minor Outlying Islands</span></span></td>
    <td><span data-ttu-id="7e341-708">米領バージン諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-708">U.S. Virgin Islands</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-709">ウズベキスタン</span><span class="sxs-lookup"><span data-stu-id="7e341-709">Uzbekistan</span></span></td>
    <td><span data-ttu-id="7e341-710">バチカン市国</span><span class="sxs-lookup"><span data-stu-id="7e341-710">Vatican City</span></span></td>
    <td><span data-ttu-id="7e341-711">ベネズエラ</span><span class="sxs-lookup"><span data-stu-id="7e341-711">Venezuela</span></span></td>
    <td><span data-ttu-id="7e341-712">ベトナム</span><span class="sxs-lookup"><span data-stu-id="7e341-712">Vietnam</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-713">バヌアツ</span><span class="sxs-lookup"><span data-stu-id="7e341-713">Vanuatu</span></span></td>
    <td><span data-ttu-id="7e341-714">ワリス・フテュナ諸島</span><span class="sxs-lookup"><span data-stu-id="7e341-714">Wallis and Futuna</span></span></td>
    <td><span data-ttu-id="7e341-715">イエメン</span><span class="sxs-lookup"><span data-stu-id="7e341-715">Yemen</span></span></td>
    <td><span data-ttu-id="7e341-716">ザンビア</span><span class="sxs-lookup"><span data-stu-id="7e341-716">Zambia</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="7e341-717">ジンバブエ</span><span class="sxs-lookup"><span data-stu-id="7e341-717">Zimbabwe</span></span></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>

> [!NOTE]
> <span data-ttu-id="7e341-718">開発者アカウントを登録できる国と地域の一覧については、「[アカウントの種類、場所、料金](account-types-locations-and-fees.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e341-718">For a list of the countries and regions in which you can register for a developer account, see [Account types, locations, and fees](account-types-locations-and-fees.md).</span></span>
