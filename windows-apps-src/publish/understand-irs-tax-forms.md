---
author: jnHs
Description: "マイクロソフトが発行する税関連の書類について、どのような開発者がその書類を受け取るのか、いつ書類が利用できるようになるのかなどを説明します。"
title: "マイクロソフトが発行する IRS の税関連の書類について"
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 1e475b96-f953-457c-864f-b6f4cb4c309f
ms.openlocfilehash: bffb666184f52e6e6491d8651414ecbc269352b8
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="understand-irs-tax-forms-issued-by-microsoft"></a><span data-ttu-id="4b324-104">マイクロソフトが発行する IRS の税関連の書類について</span><span class="sxs-lookup"><span data-stu-id="4b324-104">Understand IRS tax forms issued by Microsoft</span></span>

<span data-ttu-id="4b324-105">開発者は、所在地および受け取っている売上高や支払い額に応じて、毎年マイクロソフトから 1 種類以上の税関連の書類を受け取る可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4b324-105">Depending on your location and the amount of sales and/or payments you receive, you may receive one or more tax forms from Microsoft each year.</span></span> <span data-ttu-id="4b324-106">マイクロソフトはこれらの書類を発行し、米国内国歳入庁 (IRS) に提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b324-106">Microsoft is required to issue these forms and file them with the Internal Revenue Service (IRS).</span></span>

<span data-ttu-id="4b324-107">ここでは、どのような開発者が書類を受け取り、いつ利用可能になるのかなど、これらの書類について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="4b324-107">Below, we'll explain more about these forms, including who will receive them and when they are made available.</span></span>

## <a name="types-of-tax-forms"></a><span data-ttu-id="4b324-108">税関連の書類の種類</span><span class="sxs-lookup"><span data-stu-id="4b324-108">Types of tax forms</span></span>

| <span data-ttu-id="4b324-109">IRS の税関連の書類</span><span class="sxs-lookup"><span data-stu-id="4b324-109">IRS tax form</span></span> | <span data-ttu-id="4b324-110">説明</span><span class="sxs-lookup"><span data-stu-id="4b324-110">Description</span></span> | <span data-ttu-id="4b324-111">利用可能時期</span><span class="sxs-lookup"><span data-stu-id="4b324-111">Availability</span></span> |
|--------------|-------------|--------------|
|<span data-ttu-id="4b324-112">1099-MISC、1099-K</span><span class="sxs-lookup"><span data-stu-id="4b324-112">1099-MISC, 1099-K</span></span> | <span data-ttu-id="4b324-113">マイクロソフトのマーケットプレースへの参加に関する販売アクティビティや開発者への支払いに関連します。</span><span class="sxs-lookup"><span data-stu-id="4b324-113">Related to sales activity and/or payments made to you for participation in Microsoft's marketplaces</span></span> | <span data-ttu-id="4b324-114">書類には **1 月 31 日**までの消印が押されます。また、同時に .pdf コピーがデベロッパー センターで利用可能になります (**[ダッシュボード]、[アカウント設定]、[税プロファイル]** の順に移動します)。</span><span class="sxs-lookup"><span data-stu-id="4b324-114">Printed forms will be postmarked on or before **January 31**, and .pdf copies will be available in Dev Center (**Dashboard > Account settings > Tax profile**) at the same time</span></span> |
|<span data-ttu-id="4b324-115">1042-S</span><span class="sxs-lookup"><span data-stu-id="4b324-115">1042-S</span></span> | <span data-ttu-id="4b324-116">米国の源泉徴収税の対象になる開発者への支払いに関連します。</span><span class="sxs-lookup"><span data-stu-id="4b324-116">Related to payments made to you that are subject to United States withholding tax.</span></span> | <span data-ttu-id="4b324-117">書類には **3 月 15 日**までの消印が押されます。また、同時に .pdf コピーがデベロッパー センターで利用可能になります (**[ダッシュボード]、[アカウント設定]、[税プロファイル]** の順に移動します)。</span><span class="sxs-lookup"><span data-stu-id="4b324-117">Printed forms will be postmarked on or before **March 15**, and .pdf copies will be available in Dev Center (**Dashboard > Account settings > Tax profile**) at the same time</span></span> |

> [!NOTE]
> <span data-ttu-id="4b324-118">注: IRS の税関連書類に記載される住所には、[税プロファイル](setting-up-your-payout-account-and-tax-forms.md#tax-forms)内の住所が利用されます。</span><span class="sxs-lookup"><span data-stu-id="4b324-118">The address listed on IRS tax forms comes from the address in your [Tax profile](setting-up-your-payout-account-and-tax-forms.md#tax-forms).</span></span> <span data-ttu-id="4b324-119">住所を変更した場合は、**[税プロファイル]** の住所も変更するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="4b324-119">If your address has changed, please make sure to update the address in your **Tax profile**.</span></span>

## <a name="for-developers-located-in-the-united-states"></a><span data-ttu-id="4b324-120">米国在住の開発者の場合</span><span class="sxs-lookup"><span data-stu-id="4b324-120">For developers located in the United States</span></span>

<table>
  <tr>
     <th><span data-ttu-id="4b324-121">米国在住の開発者で有料アプリを販売しており、以下の条件を満たす場合</span><span class="sxs-lookup"><span data-stu-id="4b324-121">If I'm a United States developer selling paid apps and ...</span></span> </th>
     <th> <span data-ttu-id="4b324-122">以下の書類を受け取る</span><span class="sxs-lookup"><span data-stu-id="4b324-122">I should receive this form</span></span></th>
  </tr>
  <tr> 
     <td valign="top"><span data-ttu-id="4b324-123">適用される税年度に、**アプリの販売数が 200 個を上回り**、アプリ販売の合計購入金額が **20,000 米国ドルを超えました** (Windows 10 ストア経由でブラジルおよび中国で販売された数は**含まれません**)。</span><span class="sxs-lookup"><span data-stu-id="4b324-123">I had **greater than 200 app sales** with a total purchase amount of these sales **greater than $20,000 USD** in the applicable tax year (**not** counting sales made in Brazil and China through the Windows 10 Store.)</span></span></td>
    <td valign="top"><span data-ttu-id="4b324-124">**1099-K** :</span><span class="sxs-lookup"><span data-stu-id="4b324-124">**1099-K** :</span></span><br>
<span data-ttu-id="4b324-125">提出者: Microsoft Corporation</span><span class="sxs-lookup"><span data-stu-id="4b324-125">Filer: Microsoft Corporation</span></span><br>
<span data-ttu-id="4b324-126">EIN: \*\*\*\*\*4442</span><span class="sxs-lookup"><span data-stu-id="4b324-126">EIN: \*\*\*\*\*4442</span></span><br>
<br><span data-ttu-id="4b324-127">
**重要:** フォーム 1099 K には、開発者に支払われた金額ではなく、**仕入総額**が記載されます。</span><span class="sxs-lookup"><span data-stu-id="4b324-127">
**Important:** Form 1099-K contains **gross purchase** amounts, not payments made to you.</span></span></td>
  </tr>
  <tr> 
     <td valign="top"><span data-ttu-id="4b324-128">Windows 10 ストア経由でブラジルおよび中国で販売したアプリについて、**10 ドル以上の支払い額**を受け取りました。</span><span class="sxs-lookup"><span data-stu-id="4b324-128">I received **at least $10 in payments** for app sales made in Brazil and China through the Windows 10 Store.</span></span><br>
<br>
**<span data-ttu-id="4b324-129">または</span><span class="sxs-lookup"><span data-stu-id="4b324-129">OR</span></span>**<br>
<br>
<span data-ttu-id="4b324-130">適用される税年度に、アプリの売り上げと関連のない 600 ドル以上の支払いをマイクロソフトから受け取りました (インセンティブ支払いや、コンテストまたはプロモーションによる支払いなど)。</span><span class="sxs-lookup"><span data-stu-id="4b324-130">I received at least $600 in payments not related to app sales from Microsoft in the applicable tax year (e.g. incentive payments or payments from a contest or promotion)</span></span></td>
    <td valign="top"><span data-ttu-id="4b324-131">**1099-MISC** :</span><span class="sxs-lookup"><span data-stu-id="4b324-131">**1099-MISC** :</span></span><br>
<span data-ttu-id="4b324-132">支払者: Microsoft Corporation</span><span class="sxs-lookup"><span data-stu-id="4b324-132">Payer: Microsoft Corporation</span></span><br>
<span data-ttu-id="4b324-133">EIN: \*\*\*\*\*4442</span><span class="sxs-lookup"><span data-stu-id="4b324-133">EIN: \*\*\*\*\*4442</span></span><br>
<br><span data-ttu-id="4b324-134">
**重要:** 一部のビジネス エンティティは、マイクロソフトから支払い金額を受け取っているかどうかに関係なく、1099-MISC フォームを受け取りません。</span><span class="sxs-lookup"><span data-stu-id="4b324-134">
**Important:** Certain business entities will not receive 1099-MISC forms regardless of the payment amounts received from Microsoft.</span></span>  <span data-ttu-id="4b324-135">詳細については、税務の専門家にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="4b324-135">Please consult your tax professional for further information.</span></span></td>
  </tr>
  <tr>
    <td valign="top"><span data-ttu-id="4b324-136">上のいずれの理由も該当しません。</span><span class="sxs-lookup"><span data-stu-id="4b324-136">None of the above apply.</span></span></td>
    <td valign="top"><span data-ttu-id="4b324-137">なし</span><span class="sxs-lookup"><span data-stu-id="4b324-137">None</span></span></td>
  </tr>
  <tr>
    <td valign="top">&nbsp;</td>
    <td valign="top">&nbsp;</td>
  </tr>
  <tr>
     <th><span data-ttu-id="4b324-138">米国在住の開発者で有料アプリを販売しており、以下の条件を満たす場合</span><span class="sxs-lookup"><span data-stu-id="4b324-138">If I'm a United States developer selling paid apps and ...</span></span> </th>
     <th> <span data-ttu-id="4b324-139">以下の書類を受け取る</span><span class="sxs-lookup"><span data-stu-id="4b324-139">I should receive this form</span></span></th>
  </tr>
  <tr> 
     <td valign="top"><span data-ttu-id="4b324-140">適用される税年度に、アプリ内広告によって **600 ドル以上の支払い**を受け取りました。</span><span class="sxs-lookup"><span data-stu-id="4b324-140">I received **at least $600 in payments** from ads in apps in the applicable tax year</span></span></td>
    <td valign="top"><span data-ttu-id="4b324-141">**1099-MISC** :</span><span class="sxs-lookup"><span data-stu-id="4b324-141">**1099-MISC** :</span></span><br>
<span data-ttu-id="4b324-142">支払い人: Microsoft Online Inc</span><span class="sxs-lookup"><span data-stu-id="4b324-142">Payer: Microsoft Online Inc</span></span><br>
<span data-ttu-id="4b324-143">EIN: \*\*\*\*\*0505</span><span class="sxs-lookup"><span data-stu-id="4b324-143">EIN: \*\*\*\*\*0505</span></span><br>
<br><span data-ttu-id="4b324-144">
**重要:** 一部のビジネス エンティティは、マイクロソフトから支払い金額を受け取っているかどうかに関係なく、1099-MISC フォームを受け取りません。</span><span class="sxs-lookup"><span data-stu-id="4b324-144">
**Important:** Certain business entities will not receive 1099-MISC forms regardless of the payment amounts received from Microsoft.</span></span>  <span data-ttu-id="4b324-145">詳細については、税務の専門家にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="4b324-145">Please consult your tax professional for further information.</span></span>  </td>
  </tr>
  <tr> 
     <td valign="top"><span data-ttu-id="4b324-146">適用される税年度に、アプリ内広告によって **600 ドル未満の支払い**を受け取りました。</span><span class="sxs-lookup"><span data-stu-id="4b324-146">I received **less than $600 in payments** from ads in apps in the applicable tax year</span></span></td>
     <td valign="top"><span data-ttu-id="4b324-147">なし</span><span class="sxs-lookup"><span data-stu-id="4b324-147">None</span></span></td>
  </tr>
</table>


## <a name="for-developers-located-outside-of-the-united-states"></a><span data-ttu-id="4b324-148">米国外に在住する開発者の場合</span><span class="sxs-lookup"><span data-stu-id="4b324-148">For developers located outside of the United States</span></span>

<table>
  <tr>
    <td valign="top">**<span data-ttu-id="4b324-149">マイクロソフトから 1042-S フォームを受け取りました。</span><span class="sxs-lookup"><span data-stu-id="4b324-149">I received a form 1042-S from Microsoft.</span></span> <span data-ttu-id="4b324-150">これは何のためですか。</span><span class="sxs-lookup"><span data-stu-id="4b324-150">What is it for?</span></span>**</td>
    <td valign="top"><span data-ttu-id="4b324-151">マイクロソフトが 1042-S フォームを送った理由は、米国の税務当局に申告義務があると見なされている、源泉徴収税の対象になった収益を、マイクロソフトが開発者に対して支払ったためです。</span><span class="sxs-lookup"><span data-stu-id="4b324-151">Microsoft has provided you with a 1042-S form or forms because we paid you revenue that is considered reportable to the United States tax authorities and was subject to withholding tax.</span></span>  <span data-ttu-id="4b324-152">フォーム 1042-S は、この報告義務のために使用されます。</span><span class="sxs-lookup"><span data-stu-id="4b324-152">Form 1042-S is used for this reporting requirement.</span></span></td>
  </tr>
  <tr>
    <td valign="top">**<span data-ttu-id="4b324-153">この書類にどのように対応する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="4b324-153">What should I do with the forms?</span></span>**</td>
    <td valign="top"><span data-ttu-id="4b324-154">一般的に、開発者側で特別な対応は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="4b324-154">Generally, no specific action is required on your part.</span></span> <span data-ttu-id="4b324-155">フォーム 1402-S は、開発者が管轄の税務当局に任意の形式の税額控除を申請する場合に役立つ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4b324-155">The form 1042-S may be useful to you if you want to apply to your local tax authorities for any form of tax credit.</span></span>  <span data-ttu-id="4b324-156">このトピックについて詳しくは、税金アドバイザーにお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="4b324-156">You should consult with your own tax advisors to get more information on this topic.</span></span></td>
  </tr>
  <tr>
    <td valign="top">**<span data-ttu-id="4b324-157">W8 フォームをすべて記入した際に支払いが源泉徴収されたのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="4b324-157">Why was tax withheld on my payments when I completed a W8 form?</span></span>**</td>
    <td valign="top"><span data-ttu-id="4b324-158">税金は次のいずれかの場合に源泉徴収されます。</span><span class="sxs-lookup"><span data-stu-id="4b324-158">Taxes will be withheld if either:</span></span><br>
     1. <span data-ttu-id="4b324-159">W8 の租税条約の項がすべて正しく記載されていなかった場合</span><span class="sxs-lookup"><span data-stu-id="4b324-159">You did not complete the tax treaty section of the W8 correctly, or</span></span><br>
     2. <span data-ttu-id="4b324-160">米国との租税条約がない国に在住している場合</span><span class="sxs-lookup"><span data-stu-id="4b324-160">You are resident in a country that does not have a tax treaty with the United States.</span></span>

     You can visit Dev Center at any time to submit an updated W8 form.<br>
     <br>
     **Note:** Not all income is subject to tax withholding.</td>
  </tr>
  <tr>
    <td valign="top">**<span data-ttu-id="4b324-161">適切な条約情報を使って更新した W8 フォームを提出しました。</span><span class="sxs-lookup"><span data-stu-id="4b324-161">I submitted an updated W8 form with valid treaty information.</span></span> <span data-ttu-id="4b324-162">マイクロソフトは源泉徴収された税金を払い戻してくれますか。</span><span class="sxs-lookup"><span data-stu-id="4b324-162">Can Microsoft refund me the tax that was withheld?</span></span>**</td>
    <td valign="top"><span data-ttu-id="4b324-163">源泉徴収された税金を払い戻すことはできません。</span><span class="sxs-lookup"><span data-stu-id="4b324-163">Once tax has been withheld, it cannot be refunded.</span></span> <span data-ttu-id="4b324-164">これらの税金について地域で控除を請求できるかどうか、または IRS から払い戻しを求められるかどうかについては、税金アドバイザーにご相談ください。</span><span class="sxs-lookup"><span data-stu-id="4b324-164">You should discuss with your tax advisers whether you can claim a local credit for these taxes, or whether you can seek a refund from the IRS.</span></span></td>
  </tr>
  <tr>
    <td valign="top">**<span data-ttu-id="4b324-165">フォーム 104-S ではどのような売り上げが報告されますか。</span><span class="sxs-lookup"><span data-stu-id="4b324-165">What sales are reported on form 1042-S?</span></span>**</td>
    <td valign="top"><span data-ttu-id="4b324-166">**源泉徴収の対象として分類された、米国在住の購入者に対する**売り上げのみ報告義務があります。</span><span class="sxs-lookup"><span data-stu-id="4b324-166">Only sales made **to buyers located in the United States that were classified as subject to tax withholding** are reportable.</span></span>  <span data-ttu-id="4b324-167">その他の売り上げはすべて報告義務があるとは見なされていません。</span><span class="sxs-lookup"><span data-stu-id="4b324-167">All other sales are not considered reportable.</span></span></td>
  </tr>
  <tr>
    <td valign="top">**<span data-ttu-id="4b324-168">同じフォーム 1042-S が 3 部同封されていたのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="4b324-168">Why did I get 3 copies of the same form 1042-S in one envelope?</span></span>**</td>
    <td valign="top"><span data-ttu-id="4b324-169">IRS 規則により、次の 3 つの目的で書類を 3 部提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b324-169">IRS regulations require three copies of the form to be provided:</span></span>
<ul>
<li><span data-ttu-id="4b324-170">受取人の記録のため</span><span class="sxs-lookup"><span data-stu-id="4b324-170">One for the recipient's records</span></span></li>
<li><span data-ttu-id="4b324-171">米国連邦政府の所得税申告に提出するため (該当する場合)</span><span class="sxs-lookup"><span data-stu-id="4b324-171">One for filing with a United States Federal tax return (if applicable)</span></span></li>
<li><span data-ttu-id="4b324-172">米国の所得税申告に提出するため (該当する場合)</span><span class="sxs-lookup"><span data-stu-id="4b324-172">One for filing with a United States State tax return (if applicable)</span></span></li>
</ul></td>
  </tr>
</table>


> [!NOTE]
> <span data-ttu-id="4b324-173">**IRS の税関連の書類**に関する質問や懸案事項が他にもある場合は、[サポート チケット](http://aka.ms/storesupport)を作成してください。</span><span class="sxs-lookup"><span data-stu-id="4b324-173">If you have additional questions or concerns related to **IRS tax forms**, please create a [support ticket](http://aka.ms/storesupport).</span></span> <span data-ttu-id="4b324-174">マイクロソフトは特定の税金の事情に関する質問にはお答えできません。これらの質問については、税務の専門家にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="4b324-174">Microsoft cannot answer questions related to your specific tax circumstances; for those questions, please seek advice from your tax professional.</span></span>
