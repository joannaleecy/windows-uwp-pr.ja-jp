---
title: People アプリの起動
description: ここでは、ms-people URI スキームについて説明します。 アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。
ms.assetid: 1E604599-26EF-421C-932F-E9935CDB248E
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 46a297c3a611882724b18242d1c6272c3345ffc2
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8348136"
---
# <a name="launch-the-people-app"></a><span data-ttu-id="8320f-105">People アプリの起動</span><span class="sxs-lookup"><span data-stu-id="8320f-105">Launch the People app</span></span>

<span data-ttu-id="8320f-106">ここでは、**ms-people:** URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="8320f-106">This topic describes the **ms-people:** URI scheme.</span></span> <span data-ttu-id="8320f-107">アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。</span><span class="sxs-lookup"><span data-stu-id="8320f-107">Your app can use this URI scheme to launch the People app for specific actions.</span></span>

## <a name="ms-people-uri-scheme-reference"></a><span data-ttu-id="8320f-108">ms-people: URI スキーム リファレンス</span><span class="sxs-lookup"><span data-stu-id="8320f-108">ms-people: URI scheme reference</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="8320f-109">結果</span><span class="sxs-lookup"><span data-stu-id="8320f-109">Results</span></span></th>
<th align="left"><span data-ttu-id="8320f-110">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="8320f-110">URI scheme</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="8320f-111">他のアプリから People アプリのメイン ページを起動できます。</span><span class="sxs-lookup"><span data-stu-id="8320f-111">Allows other apps to launch the People app Main page.</span></span></td>
<td align="left"><span data-ttu-id="8320f-112">ms-people:</span><span class="sxs-lookup"><span data-stu-id="8320f-112">ms-people:</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="8320f-113">他のアプリから People アプリの設定ページを起動できます。</span><span class="sxs-lookup"><span data-stu-id="8320f-113">Allows other apps to launch the People app Settings page.</span></span></td>
<td align="left"><span data-ttu-id="8320f-114">ms-people:settings</span><span class="sxs-lookup"><span data-stu-id="8320f-114">ms-people:settings</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="8320f-115">他のアプリから、検索文字列を指定して People アプリを起動し、検索の結果ページを表示できます。</span><span class="sxs-lookup"><span data-stu-id="8320f-115">Allows other apps to provide a search string that will launch the People app with the result page of the search.</span></span>
<div class="alert">
<p><span data-ttu-id="8320f-116">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="8320f-116">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="8320f-117">構文を正しく入力していない場合や、検索文字列の値が不足している場合、既定の動作ではフィルター処理せずにすべての連絡先の一覧が返されます。</span><span class="sxs-lookup"><span data-stu-id="8320f-117">If you do not enter the syntax correctly, or are missing the search string value, the default behavior is to return a full list of contacts without any filtering.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="8320f-118">ms-people:search?SearchString=&lt;contactsearchinfo&gt;</span><span class="sxs-lookup"><span data-stu-id="8320f-118">ms-people:search?SearchString=&lt;contactsearchinfo&gt;</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="8320f-119">連絡先が見つかった場合は、既存の連絡先カードを起動します。</span><span class="sxs-lookup"><span data-stu-id="8320f-119">Launches to an existing contact card, if the contact is found.</span></span> <span data-ttu-id="8320f-120">または、連絡先が見つからなかった場合は、一時的な連絡先カードを起動します。</span><span class="sxs-lookup"><span data-stu-id="8320f-120">Or, launches to a temporary contact card, if no contact is found.</span></span> <span data-ttu-id="8320f-121">入力パラメーターが指定されていない場合は、People アプリが起動され、連絡先一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="8320f-121">If no input parameter is supplied, we will launch the People App with a contact list.</span></span>
<div class="alert">
<p><span data-ttu-id="8320f-122">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="8320f-122">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="8320f-123">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="8320f-123">The order of the parameters doesn’t matter.</span></span></p>
<p><span data-ttu-id="8320f-124">一致する連絡先が複数ある場合は、最初に一致した連絡先が返されます。</span><span class="sxs-lookup"><span data-stu-id="8320f-124">If there is more than one match, we will return the first match of the contact.</span></span></p>
</div>
<div> 
</div></td>
<td align="left"><span data-ttu-id="8320f-125">ms-people:viewcontact:?ContactId=&lt;contactid&gt;&amp;AggregatedId=&lt;aggid&gt;&amp;PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;&amp;Contact=&lt;contactobj&gt;</span><span class="sxs-lookup"><span data-stu-id="8320f-125">ms-people:viewcontact:?ContactId=&lt;contactid&gt;&amp;AggregatedId=&lt;aggid&gt;&amp;PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;&amp;Contact=&lt;contactobj&gt;</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="8320f-126">People アプリ内の連絡先の保存ページを起動し、指定した連絡先を、指定した電話番号またはメール アドレスと共に保存します。</span><span class="sxs-lookup"><span data-stu-id="8320f-126">Launches to a Save-contact page within the People app to save the given contact with the supplied phone number or email address.</span></span>
<div class="alert">
<p><span data-ttu-id="8320f-127">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="8320f-127">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="8320f-128">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="8320f-128">The order of the parameters doesn’t matter.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="8320f-129">ms-people:savetocontact?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span><span class="sxs-lookup"><span data-stu-id="8320f-129">ms-people:savetocontact?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="8320f-130">People アプリ内の新しい連絡先の追加ページを起動し、指定した連絡先を保存します。</span><span class="sxs-lookup"><span data-stu-id="8320f-130">Launches to the add a new contact page within the People app to save the given contact.</span></span>
<div class="alert"><p><span data-ttu-id="8320f-131">新しい連絡先の保存ページを起動するには、<a href="https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriForResultsAsync_Windows_Foundation_Uri_Windows_System_LauncherOptions_Windows_Foundation_Collections_ValueSet_">LaunchUriForResultsAsync</a> を使用します。</span><span class="sxs-lookup"><span data-stu-id="8320f-131">Use <a href="https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriForResultsAsync_Windows_Foundation_Uri_Windows_System_LauncherOptions_Windows_Foundation_Collections_ValueSet_">LaunchUriForResultsAsync</a> to open the save new contact page.</span></span> <span data-ttu-id="8320f-132"><strong>LaunchUriAsync</strong> を使用すると、People アプリのメイン ページのみが起動します。</span><span class="sxs-lookup"><span data-stu-id="8320f-132">Using <strong>LaunchUriAsync</strong> will only launch the People app Main page.</span></span></p>
<p><span data-ttu-id="8320f-133">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="8320f-133">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="8320f-134">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="8320f-134">The order of the parameters doesn’t matter.</span></span></p>
<p><span data-ttu-id="8320f-135">サポートされているパラメーターはどのような組み合わせでも使用することができます。</span><span class="sxs-lookup"><span data-stu-id="8320f-135">You can use any combination of supported parameters.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="8320f-136">ms-people:savecontacttask?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span><span class="sxs-lookup"><span data-stu-id="8320f-136">ms-people:savecontacttask?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span></span></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesearch-parameter-reference"></a><span data-ttu-id="8320f-137">ms-people:search: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="8320f-137">ms-people:search: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="8320f-138">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8320f-138">Parameter</span></span></th>
<th align="left"><span data-ttu-id="8320f-139">説明</span><span class="sxs-lookup"><span data-stu-id="8320f-139">Description</span></span></th>
<th align="left"><span data-ttu-id="8320f-140">例</span><span class="sxs-lookup"><span data-stu-id="8320f-140">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-141">SearchString</span><span class="sxs-lookup"><span data-stu-id="8320f-141">SearchString</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-142">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-142">Optional.</span></span></p>
<p><span data-ttu-id="8320f-143">連絡先の検索情報の検索文字列です。</span><span class="sxs-lookup"><span data-stu-id="8320f-143">The search string for the contact search information.</span></span></p>
<p><span data-ttu-id="8320f-144">電話番号または連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="8320f-144">The phone number or the contact name.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-145">ms-people:search?SearchString=Smith</span><span class="sxs-lookup"><span data-stu-id="8320f-145">ms-people:search?SearchString=Smith</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peopleviewcontact-parameter-reference"></a><span data-ttu-id="8320f-146">ms-people:viewcontact: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="8320f-146">ms-people:viewcontact: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="8320f-147">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8320f-147">Parameter</span></span></th>
<th align="left"><span data-ttu-id="8320f-148">説明</span><span class="sxs-lookup"><span data-stu-id="8320f-148">Description</span></span></th>
<th align="left"><span data-ttu-id="8320f-149">例</span><span class="sxs-lookup"><span data-stu-id="8320f-149">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-150">ContactId</span><span class="sxs-lookup"><span data-stu-id="8320f-150">ContactId</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-151">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-151">Optional.</span></span></p>
<p><span data-ttu-id="8320f-152">連絡先の連絡先 ID です。</span><span class="sxs-lookup"><span data-stu-id="8320f-152">Contact Id of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-153">ms-people:viewcontact?ContactId={ContactId}</span><span class="sxs-lookup"><span data-stu-id="8320f-153">ms-people:viewcontact?ContactId={ContactId}</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-154">PhoneNumber</span><span class="sxs-lookup"><span data-stu-id="8320f-154">PhoneNumber</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-155">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-155">Optional.</span></span></p>
<p><span data-ttu-id="8320f-156">連絡先の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="8320f-156">Phone number of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-157">ms-people:viewcontact?PhoneNumber=%2014257069326</span><span class="sxs-lookup"><span data-stu-id="8320f-157">ms-people:viewcontact?PhoneNumber=%2014257069326</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-158">Email</span><span class="sxs-lookup"><span data-stu-id="8320f-158">Email</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-159">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-159">Optional.</span></span></p>
<p><span data-ttu-id="8320f-160">連絡先のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="8320f-160">Email of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-161">ms-people:viewcontact?Email=johnsmith@contsco.com</span><span class="sxs-lookup"><span data-stu-id="8320f-161">ms-people:viewcontact?Email=johnsmith@contsco.com</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-162">ContactName</span><span class="sxs-lookup"><span data-stu-id="8320f-162">ContactName</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-163">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-163">Optional.</span></span></p>
<p><span data-ttu-id="8320f-164">連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="8320f-164">Name of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-165">ms-people:viewcontact?ContactName=John%20%Smith</span><span class="sxs-lookup"><span data-stu-id="8320f-165">ms-people:viewcontact?ContactName=John%20%Smith</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-166">Contact</span><span class="sxs-lookup"><span data-stu-id="8320f-166">Contact</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-167">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-167">Optional.</span></span></p>
<p><span data-ttu-id="8320f-168">Contact オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="8320f-168">Contact object.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-169">ms-people:viewcontact?Contact={Serialized Contact}</span><span class="sxs-lookup"><span data-stu-id="8320f-169">ms-people:viewcontact?Contact={Serialized Contact}</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesavetocontact-parameter-reference"></a><span data-ttu-id="8320f-170">ms-people:savetocontact: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="8320f-170">ms-people:savetocontact: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="8320f-171">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8320f-171">Parameter</span></span></th>
<th align="left"><span data-ttu-id="8320f-172">説明</span><span class="sxs-lookup"><span data-stu-id="8320f-172">Description</span></span></th>
<th align="left"><span data-ttu-id="8320f-173">例</span><span class="sxs-lookup"><span data-stu-id="8320f-173">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-174">PhoneNumber</span><span class="sxs-lookup"><span data-stu-id="8320f-174">PhoneNumber</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-175">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-175">Optional.</span></span></p>
<p><span data-ttu-id="8320f-176">連絡先の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="8320f-176">Phone number of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-177">ms-people:savetocontact?PhoneNumber=%2014257069326</span><span class="sxs-lookup"><span data-stu-id="8320f-177">ms-people:savetocontact?PhoneNumber=%2014257069326</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-178">Email</span><span class="sxs-lookup"><span data-stu-id="8320f-178">Email</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-179">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-179">Optional.</span></span></p>
<p><span data-ttu-id="8320f-180">連絡先のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="8320f-180">Email of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-181">ms-people:savetocontact?Email=johnsmith@contsco.com</span><span class="sxs-lookup"><span data-stu-id="8320f-181">ms-people:savetocontact?Email=johnsmith@contsco.com</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-182">ContactName</span><span class="sxs-lookup"><span data-stu-id="8320f-182">ContactName</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-183">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-183">Optional.</span></span></p>
<p><span data-ttu-id="8320f-184">連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="8320f-184">Name of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="8320f-185">ms-people:savetocontact?Email=johnsmith@contsco.com&amp;ContactName= John%20%Smith</span><span class="sxs-lookup"><span data-stu-id="8320f-185">ms-people:savetocontact?Email=johnsmith@contsco.com&amp;ContactName= John%20%Smith</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesavecontacttask-parameter-reference"></a><span data-ttu-id="8320f-186">ms-people:savecontacttask: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="8320f-186">ms-people:savecontacttask: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="8320f-187">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8320f-187">Parameter</span></span></th>
<th align="left"><span data-ttu-id="8320f-188">説明</span><span class="sxs-lookup"><span data-stu-id="8320f-188">Description</span></span></th>

</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-189">Company</span><span class="sxs-lookup"><span data-stu-id="8320f-189">Company</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-190">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-190">Optional.</span></span></p>
<p><span data-ttu-id="8320f-191">連絡先の会社名です。</span><span class="sxs-lookup"><span data-stu-id="8320f-191">Company name of the contact.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-192">FirstName</span><span class="sxs-lookup"><span data-stu-id="8320f-192">FirstName</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-193">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-193">Optional.</span></span></p>
<p><span data-ttu-id="8320f-194">連絡先の名です。</span><span class="sxs-lookup"><span data-stu-id="8320f-194">First name of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-195">HomeAddressCity</span><span class="sxs-lookup"><span data-stu-id="8320f-195">HomeAddressCity</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-196">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-196">Optional.</span></span></p>
<p><span data-ttu-id="8320f-197">自宅の住所の都市名です。</span><span class="sxs-lookup"><span data-stu-id="8320f-197">City of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-198">HomeAddressCountry</span><span class="sxs-lookup"><span data-stu-id="8320f-198">HomeAddressCountry</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-199">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-199">Optional.</span></span></p>
<p><span data-ttu-id="8320f-200">自宅の住所の国です。</span><span class="sxs-lookup"><span data-stu-id="8320f-200">Country of the home address.</span></span></p></td>

</tr>
<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-201">HomeAddressState</span><span class="sxs-lookup"><span data-stu-id="8320f-201">HomeAddressState</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-202">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-202">Optional.</span></span></p>
<p><span data-ttu-id="8320f-203">自宅の住所の州の名前です。</span><span class="sxs-lookup"><span data-stu-id="8320f-203">State of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-204">HomeAddressStreet</span><span class="sxs-lookup"><span data-stu-id="8320f-204">HomeAddressStreet</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-205">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-205">Optional.</span></span></p>
<p><span data-ttu-id="8320f-206">自宅の住所の番地です。</span><span class="sxs-lookup"><span data-stu-id="8320f-206">Street of the home address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-207">HomeAddressZipCode</span><span class="sxs-lookup"><span data-stu-id="8320f-207">HomeAddressZipCode</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-208">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-208">Optional.</span></span></p>
<p><span data-ttu-id="8320f-209">自宅の住所の郵便番号です。</span><span class="sxs-lookup"><span data-stu-id="8320f-209">Zip Code of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-210">HomePhone</span><span class="sxs-lookup"><span data-stu-id="8320f-210">HomePhone</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-211">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-211">Optional.</span></span></p>
<p><span data-ttu-id="8320f-212">連絡先の自宅電話番号です。</span><span class="sxs-lookup"><span data-stu-id="8320f-212">Home phone of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-213">JobTitle</span><span class="sxs-lookup"><span data-stu-id="8320f-213">JobTitle</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-214">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-214">Optional.</span></span></p>
<p><span data-ttu-id="8320f-215">連絡先の役職です。</span><span class="sxs-lookup"><span data-stu-id="8320f-215">Job title of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-216">LastName</span><span class="sxs-lookup"><span data-stu-id="8320f-216">LastName</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-217">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-217">Optional.</span></span></p>
<p><span data-ttu-id="8320f-218">連絡先の姓です。</span><span class="sxs-lookup"><span data-stu-id="8320f-218">Last name of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-219">MiddleName</span><span class="sxs-lookup"><span data-stu-id="8320f-219">MiddleName</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-220">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-220">Optional.</span></span></p>
<p><span data-ttu-id="8320f-221">連絡先のミドル ネームです。</span><span class="sxs-lookup"><span data-stu-id="8320f-221">Middle name of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-222">MobilePhone</span><span class="sxs-lookup"><span data-stu-id="8320f-222">MobilePhone</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-223">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-223">Optional.</span></span></p>
<p><span data-ttu-id="8320f-224">連絡先の携帯電話番号です。</span><span class="sxs-lookup"><span data-stu-id="8320f-224">Mobile phone number of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-225">Nickname</span><span class="sxs-lookup"><span data-stu-id="8320f-225">Nickname</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-226">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-226">Optional.</span></span></p>
<p><span data-ttu-id="8320f-227">連絡先のニックネームです。</span><span class="sxs-lookup"><span data-stu-id="8320f-227">Nickname of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-228">Notes</span><span class="sxs-lookup"><span data-stu-id="8320f-228">Notes</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-229">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-229">Optional.</span></span></p>
<p><span data-ttu-id="8320f-230">連絡先に関する備考です。</span><span class="sxs-lookup"><span data-stu-id="8320f-230">Notes about the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-231">OtherEmail</span><span class="sxs-lookup"><span data-stu-id="8320f-231">OtherEmail</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-232">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-232">Optional.</span></span></p>
<p><span data-ttu-id="8320f-233">連絡先のその他のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="8320f-233">Other Email of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-234">PersonalEmail</span><span class="sxs-lookup"><span data-stu-id="8320f-234">PersonalEmail</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-235">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-235">Optional.</span></span></p>
<p><span data-ttu-id="8320f-236">連絡先の個人用メール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="8320f-236">Personal Email of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-237">Suffix</span><span class="sxs-lookup"><span data-stu-id="8320f-237">Suffix</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-238">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-238">Optional.</span></span></p>
<p><span data-ttu-id="8320f-239">連絡先のサフィックスです。</span><span class="sxs-lookup"><span data-stu-id="8320f-239">Suffix of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-240">Title</span><span class="sxs-lookup"><span data-stu-id="8320f-240">Title</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-241">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-241">Optional.</span></span></p>
<p><span data-ttu-id="8320f-242">連絡先の敬称です。</span><span class="sxs-lookup"><span data-stu-id="8320f-242">Title of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-243">Website</span><span class="sxs-lookup"><span data-stu-id="8320f-243">Website</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-244">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-244">Optional.</span></span></p>
<p><span data-ttu-id="8320f-245">連絡先の Web サイトです。</span><span class="sxs-lookup"><span data-stu-id="8320f-245">Website of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-246">WorkAddressCity</span><span class="sxs-lookup"><span data-stu-id="8320f-246">WorkAddressCity</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-247">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-247">Optional.</span></span></p>
<p><span data-ttu-id="8320f-248">会社の住所の都市名です。</span><span class="sxs-lookup"><span data-stu-id="8320f-248">City of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-249">WorkAddressCountry</span><span class="sxs-lookup"><span data-stu-id="8320f-249">WorkAddressCountry</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-250">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-250">Optional.</span></span></p>
<p><span data-ttu-id="8320f-251">会社の住所の国です。</span><span class="sxs-lookup"><span data-stu-id="8320f-251">Country of the work address.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-252">WorkAddressState</span><span class="sxs-lookup"><span data-stu-id="8320f-252">WorkAddressState</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-253">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-253">Optional.</span></span></p>
<p><span data-ttu-id="8320f-254">会社の住所の州の名前です。</span><span class="sxs-lookup"><span data-stu-id="8320f-254">State of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-255">WorkAddressStreet</span><span class="sxs-lookup"><span data-stu-id="8320f-255">WorkAddressStreet</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-256">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-256">Optional.</span></span></p>
<p><span data-ttu-id="8320f-257">会社の住所の番地です。</span><span class="sxs-lookup"><span data-stu-id="8320f-257">Street of work address.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-258">WorkAddressZipCode</span><span class="sxs-lookup"><span data-stu-id="8320f-258">WorkAddressZipCode</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-259">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-259">Optional.</span></span></p>
<p><span data-ttu-id="8320f-260">会社の住所の郵便番号です。</span><span class="sxs-lookup"><span data-stu-id="8320f-260">Zip Code of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="8320f-261">WorkEmail</span><span class="sxs-lookup"><span data-stu-id="8320f-261">WorkEmail</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-262">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-262">Optional.</span></span></p>
<p><span data-ttu-id="8320f-263">連絡先の仕事用メール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="8320f-263">Work Email of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="8320f-264">WorkPhone</span><span class="sxs-lookup"><span data-stu-id="8320f-264">WorkPhone</span></span></b></td>
<td align="left"><p><span data-ttu-id="8320f-265">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="8320f-265">Optional.</span></span></p>
<p><span data-ttu-id="8320f-266">連絡先の会社の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="8320f-266">Work phone number of the contact.</span></span></p></td>
</tr>
</tbody>
</table>
