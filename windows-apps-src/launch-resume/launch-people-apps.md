---
title: People アプリの起動
description: このトピックでは、ms-people URI スキームについて説明します。 アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。
ms.assetid: 1E604599-26EF-421C-932F-E9935CDB248E
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: ab10acab42ab3f03121a7c5a462cb651b0f3f31b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595567"
---
# <a name="launch-the-people-app"></a><span data-ttu-id="fac67-105">People アプリの起動</span><span class="sxs-lookup"><span data-stu-id="fac67-105">Launch the People app</span></span>

<span data-ttu-id="fac67-106">このトピックで説明します、 **ms ユーザー。** URI スキーム。</span><span class="sxs-lookup"><span data-stu-id="fac67-106">This topic describes the **ms-people:** URI scheme.</span></span> <span data-ttu-id="fac67-107">アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。</span><span class="sxs-lookup"><span data-stu-id="fac67-107">Your app can use this URI scheme to launch the People app for specific actions.</span></span>

## <a name="ms-people-uri-scheme-reference"></a><span data-ttu-id="fac67-108">ms-people:URI スキームの参照</span><span class="sxs-lookup"><span data-stu-id="fac67-108">ms-people: URI scheme reference</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="fac67-109">結果</span><span class="sxs-lookup"><span data-stu-id="fac67-109">Results</span></span></th>
<th align="left"><span data-ttu-id="fac67-110">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="fac67-110">URI scheme</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-111">他のアプリから People アプリのメイン ページを起動できます。</span><span class="sxs-lookup"><span data-stu-id="fac67-111">Allows other apps to launch the People app Main page.</span></span></td>
<td align="left"><span data-ttu-id="fac67-112">ms-people:</span><span class="sxs-lookup"><span data-stu-id="fac67-112">ms-people:</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-113">他のアプリから People アプリの設定ページを起動できます。</span><span class="sxs-lookup"><span data-stu-id="fac67-113">Allows other apps to launch the People app Settings page.</span></span></td>
<td align="left"><span data-ttu-id="fac67-114">ms-people:settings</span><span class="sxs-lookup"><span data-stu-id="fac67-114">ms-people:settings</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-115">他のアプリから、検索文字列を指定して People アプリを起動し、検索の結果ページを表示できます。</span><span class="sxs-lookup"><span data-stu-id="fac67-115">Allows other apps to provide a search string that will launch the People app with the result page of the search.</span></span>
<div class="alert">
<p><span data-ttu-id="fac67-116">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="fac67-116">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="fac67-117">構文を正しく入力していない場合や、検索文字列の値が不足している場合、既定の動作ではフィルター処理せずにすべての連絡先の一覧が返されます。</span><span class="sxs-lookup"><span data-stu-id="fac67-117">If you do not enter the syntax correctly, or are missing the search string value, the default behavior is to return a full list of contacts without any filtering.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="fac67-118">ms-people:search?SearchString=&lt;contactsearchinfo&gt;</span><span class="sxs-lookup"><span data-stu-id="fac67-118">ms-people:search?SearchString=&lt;contactsearchinfo&gt;</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-119">連絡先が見つかった場合は、既存の連絡先カードを起動します。</span><span class="sxs-lookup"><span data-stu-id="fac67-119">Launches to an existing contact card, if the contact is found.</span></span> <span data-ttu-id="fac67-120">または、連絡先が見つからなかった場合は、一時的な連絡先カードを起動します。</span><span class="sxs-lookup"><span data-stu-id="fac67-120">Or, launches to a temporary contact card, if no contact is found.</span></span> <span data-ttu-id="fac67-121">入力パラメーターが指定されていない場合は、People アプリが起動され、連絡先一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="fac67-121">If no input parameter is supplied, we will launch the People App with a contact list.</span></span>
<div class="alert">
<p><span data-ttu-id="fac67-122">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="fac67-122">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="fac67-123">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="fac67-123">The order of the parameters doesn’t matter.</span></span></p>
<p><span data-ttu-id="fac67-124">一致する連絡先が複数ある場合は、最初に一致した連絡先が返されます。</span><span class="sxs-lookup"><span data-stu-id="fac67-124">If there is more than one match, we will return the first match of the contact.</span></span></p>
</div>
<div> 
</div></td>
<td align="left"><span data-ttu-id="fac67-125">ms-ユーザー: viewcontact でしょうか。ContactId =&lt;contactid&gt;&amp;AggregatedId =&lt;aggid&gt;&amp;PhoneNumber = &lt;phonenum&gt;&amp;電子メール =&lt;電子メール&gt; &amp;ContactName =&lt;名前&gt;&amp;連絡先 =&lt;contactobj&gt;</span><span class="sxs-lookup"><span data-stu-id="fac67-125">ms-people:viewcontact?ContactId=&lt;contactid&gt;&amp;AggregatedId=&lt;aggid&gt;&amp;PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;&amp;Contact=&lt;contactobj&gt;</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-126">People アプリ内の連絡先の保存ページを起動し、指定した連絡先を、指定した電話番号またはメール アドレスと共に保存します。</span><span class="sxs-lookup"><span data-stu-id="fac67-126">Launches to a Save-contact page within the People app to save the given contact with the supplied phone number or email address.</span></span>
<div class="alert">
<p><span data-ttu-id="fac67-127">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="fac67-127">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="fac67-128">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="fac67-128">The order of the parameters doesn’t matter.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="fac67-129">ms-people:savetocontact?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span><span class="sxs-lookup"><span data-stu-id="fac67-129">ms-people:savetocontact?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-130">People アプリ内の新しい連絡先の追加ページを起動し、指定した連絡先を保存します。</span><span class="sxs-lookup"><span data-stu-id="fac67-130">Launches to the add a new contact page within the People app to save the given contact.</span></span>
<div class="alert"><p><span data-ttu-id="fac67-131">新しい連絡先の保存ページを起動するには、<a href="https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriForResultsAsync_Windows_Foundation_Uri_Windows_System_LauncherOptions_Windows_Foundation_Collections_ValueSet_">LaunchUriForResultsAsync</a> を使用します。</span><span class="sxs-lookup"><span data-stu-id="fac67-131">Use <a href="https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriForResultsAsync_Windows_Foundation_Uri_Windows_System_LauncherOptions_Windows_Foundation_Collections_ValueSet_">LaunchUriForResultsAsync</a> to open the save new contact page.</span></span> <span data-ttu-id="fac67-132"><strong>LaunchUriAsync</strong> を使用すると、People アプリのメイン ページのみが起動します。</span><span class="sxs-lookup"><span data-stu-id="fac67-132">Using <strong>LaunchUriAsync</strong> will only launch the People app Main page.</span></span></p>
<p><span data-ttu-id="fac67-133">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="fac67-133">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="fac67-134">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="fac67-134">The order of the parameters doesn’t matter.</span></span></p>
<p><span data-ttu-id="fac67-135">サポートされているパラメーターはどのような組み合わせでも使用することができます。</span><span class="sxs-lookup"><span data-stu-id="fac67-135">You can use any combination of supported parameters.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="fac67-136">ms-people:savecontacttask?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span><span class="sxs-lookup"><span data-stu-id="fac67-136">ms-people:savecontacttask?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span></span></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesearch-parameter-reference"></a><span data-ttu-id="fac67-137">ms-people:search: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="fac67-137">ms-people:search: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="fac67-138">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fac67-138">Parameter</span></span></th>
<th align="left"><span data-ttu-id="fac67-139">説明</span><span class="sxs-lookup"><span data-stu-id="fac67-139">Description</span></span></th>
<th align="left"><span data-ttu-id="fac67-140">例</span><span class="sxs-lookup"><span data-stu-id="fac67-140">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-141"><b>SearchString</b></span><span class="sxs-lookup"><span data-stu-id="fac67-141"><b>SearchString</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-142">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-142">Optional.</span></span></p>
<p><span data-ttu-id="fac67-143">連絡先の検索情報の検索文字列です。</span><span class="sxs-lookup"><span data-stu-id="fac67-143">The search string for the contact search information.</span></span></p>
<p><span data-ttu-id="fac67-144">電話番号または連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="fac67-144">The phone number or the contact name.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-145">ms-people:search?SearchString=Smith</span><span class="sxs-lookup"><span data-stu-id="fac67-145">ms-people:search?SearchString=Smith</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peopleviewcontact-parameter-reference"></a><span data-ttu-id="fac67-146">ms-people:viewcontact: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="fac67-146">ms-people:viewcontact: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="fac67-147">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fac67-147">Parameter</span></span></th>
<th align="left"><span data-ttu-id="fac67-148">説明</span><span class="sxs-lookup"><span data-stu-id="fac67-148">Description</span></span></th>
<th align="left"><span data-ttu-id="fac67-149">例</span><span class="sxs-lookup"><span data-stu-id="fac67-149">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-150"><b>ContactId</b></span><span class="sxs-lookup"><span data-stu-id="fac67-150"><b>ContactId</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-151">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-151">Optional.</span></span></p>
<p><span data-ttu-id="fac67-152">連絡先の連絡先 ID です。</span><span class="sxs-lookup"><span data-stu-id="fac67-152">Contact Id of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-153">ms-people:viewcontact?ContactId={ContactId}</span><span class="sxs-lookup"><span data-stu-id="fac67-153">ms-people:viewcontact?ContactId={ContactId}</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-154"><b>PhoneNumber</b></span><span class="sxs-lookup"><span data-stu-id="fac67-154"><b>PhoneNumber</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-155">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-155">Optional.</span></span></p>
<p><span data-ttu-id="fac67-156">連絡先の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="fac67-156">Phone number of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-157">ms-people:viewcontact?PhoneNumber=%2014257069326</span><span class="sxs-lookup"><span data-stu-id="fac67-157">ms-people:viewcontact?PhoneNumber=%2014257069326</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-158"><b>メール</b></span><span class="sxs-lookup"><span data-stu-id="fac67-158"><b>Email</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-159">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-159">Optional.</span></span></p>
<p><span data-ttu-id="fac67-160">連絡先のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="fac67-160">Email of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-161">ms-people:viewcontact?Email=johnsmith@contsco.com</span><span class="sxs-lookup"><span data-stu-id="fac67-161">ms-people:viewcontact?Email=johnsmith@contsco.com</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-162"><b>ContactName</b></span><span class="sxs-lookup"><span data-stu-id="fac67-162"><b>ContactName</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-163">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-163">Optional.</span></span></p>
<p><span data-ttu-id="fac67-164">連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="fac67-164">Name of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-165">ms-people:viewcontact?ContactName=John%20%Smith</span><span class="sxs-lookup"><span data-stu-id="fac67-165">ms-people:viewcontact?ContactName=John%20%Smith</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-166"><b>Contact</b></span><span class="sxs-lookup"><span data-stu-id="fac67-166"><b>Contact</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-167">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-167">Optional.</span></span></p>
<p><span data-ttu-id="fac67-168">Contact オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="fac67-168">Contact object.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-169">ms-people:viewcontact?Contact={Serialized Contact}</span><span class="sxs-lookup"><span data-stu-id="fac67-169">ms-people:viewcontact?Contact={Serialized Contact}</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesavetocontact-parameter-reference"></a><span data-ttu-id="fac67-170">ms-people:savetocontact: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="fac67-170">ms-people:savetocontact: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="fac67-171">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fac67-171">Parameter</span></span></th>
<th align="left"><span data-ttu-id="fac67-172">説明</span><span class="sxs-lookup"><span data-stu-id="fac67-172">Description</span></span></th>
<th align="left"><span data-ttu-id="fac67-173">例</span><span class="sxs-lookup"><span data-stu-id="fac67-173">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-174"><b>PhoneNumber</b></span><span class="sxs-lookup"><span data-stu-id="fac67-174"><b>PhoneNumber</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-175">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-175">Optional.</span></span></p>
<p><span data-ttu-id="fac67-176">連絡先の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="fac67-176">Phone number of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-177">ms-people:savetocontact?PhoneNumber=%2014257069326</span><span class="sxs-lookup"><span data-stu-id="fac67-177">ms-people:savetocontact?PhoneNumber=%2014257069326</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-178"><b>メール</b></span><span class="sxs-lookup"><span data-stu-id="fac67-178"><b>Email</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-179">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-179">Optional.</span></span></p>
<p><span data-ttu-id="fac67-180">連絡先のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="fac67-180">Email of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-181">ms-people:savetocontact?Email=johnsmith@contsco.com</span><span class="sxs-lookup"><span data-stu-id="fac67-181">ms-people:savetocontact?Email=johnsmith@contsco.com</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-182"><b>ContactName</b></span><span class="sxs-lookup"><span data-stu-id="fac67-182"><b>ContactName</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-183">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-183">Optional.</span></span></p>
<p><span data-ttu-id="fac67-184">連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="fac67-184">Name of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="fac67-185">ms-people:savetocontact?Email=johnsmith@contsco.com&amp;ContactName= John%20%Smith</span><span class="sxs-lookup"><span data-stu-id="fac67-185">ms-people:savetocontact?Email=johnsmith@contsco.com&amp;ContactName= John%20%Smith</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesavecontacttask-parameter-reference"></a><span data-ttu-id="fac67-186">ms-people:savecontacttask: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="fac67-186">ms-people:savecontacttask: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="fac67-187">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fac67-187">Parameter</span></span></th>
<th align="left"><span data-ttu-id="fac67-188">説明</span><span class="sxs-lookup"><span data-stu-id="fac67-188">Description</span></span></th>

</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-189"><b>企業</b></span><span class="sxs-lookup"><span data-stu-id="fac67-189"><b>Company</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-190">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-190">Optional.</span></span></p>
<p><span data-ttu-id="fac67-191">連絡先の会社名です。</span><span class="sxs-lookup"><span data-stu-id="fac67-191">Company name of the contact.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-192"><b>firstName</b></span><span class="sxs-lookup"><span data-stu-id="fac67-192"><b>FirstName</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-193">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-193">Optional.</span></span></p>
<p><span data-ttu-id="fac67-194">連絡先の名です。</span><span class="sxs-lookup"><span data-stu-id="fac67-194">First name of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-195"><b>HomeAddressCity</b></span><span class="sxs-lookup"><span data-stu-id="fac67-195"><b>HomeAddressCity</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-196">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-196">Optional.</span></span></p>
<p><span data-ttu-id="fac67-197">自宅の住所の都市名です。</span><span class="sxs-lookup"><span data-stu-id="fac67-197">City of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-198"><b>HomeAddressCountry</b></span><span class="sxs-lookup"><span data-stu-id="fac67-198"><b>HomeAddressCountry</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-199">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-199">Optional.</span></span></p>
<p><span data-ttu-id="fac67-200">自宅の住所の国です。</span><span class="sxs-lookup"><span data-stu-id="fac67-200">Country of the home address.</span></span></p></td>

</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="fac67-201"><b>HomeAddressState</b></span><span class="sxs-lookup"><span data-stu-id="fac67-201"><b>HomeAddressState</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-202">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-202">Optional.</span></span></p>
<p><span data-ttu-id="fac67-203">自宅の住所の州の名前です。</span><span class="sxs-lookup"><span data-stu-id="fac67-203">State of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-204"><b>HomeAddressStreet</b></span><span class="sxs-lookup"><span data-stu-id="fac67-204"><b>HomeAddressStreet</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-205">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-205">Optional.</span></span></p>
<p><span data-ttu-id="fac67-206">自宅の住所の番地です。</span><span class="sxs-lookup"><span data-stu-id="fac67-206">Street of the home address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-207"><b>HomeAddressZipCode</b></span><span class="sxs-lookup"><span data-stu-id="fac67-207"><b>HomeAddressZipCode</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-208">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-208">Optional.</span></span></p>
<p><span data-ttu-id="fac67-209">自宅の住所の郵便番号です。</span><span class="sxs-lookup"><span data-stu-id="fac67-209">Zip Code of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><span data-ttu-id="fac67-210"><b>homephone です。</b></span><span class="sxs-lookup"><span data-stu-id="fac67-210"><b>HomePhone</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-211">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-211">Optional.</span></span></p>
<p><span data-ttu-id="fac67-212">連絡先の自宅電話番号です。</span><span class="sxs-lookup"><span data-stu-id="fac67-212">Home phone of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-213"><b>JobTitle</b></span><span class="sxs-lookup"><span data-stu-id="fac67-213"><b>JobTitle</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-214">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-214">Optional.</span></span></p>
<p><span data-ttu-id="fac67-215">連絡先の役職です。</span><span class="sxs-lookup"><span data-stu-id="fac67-215">Job title of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-216"><b>[氏名]</b></span><span class="sxs-lookup"><span data-stu-id="fac67-216"><b>LastName</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-217">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-217">Optional.</span></span></p>
<p><span data-ttu-id="fac67-218">連絡先の姓です。</span><span class="sxs-lookup"><span data-stu-id="fac67-218">Last name of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-219"><b>MiddleName</b></span><span class="sxs-lookup"><span data-stu-id="fac67-219"><b>MiddleName</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-220">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-220">Optional.</span></span></p>
<p><span data-ttu-id="fac67-221">連絡先のミドル ネームです。</span><span class="sxs-lookup"><span data-stu-id="fac67-221">Middle name of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-222"><b>MobilePhone</b></span><span class="sxs-lookup"><span data-stu-id="fac67-222"><b>MobilePhone</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-223">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-223">Optional.</span></span></p>
<p><span data-ttu-id="fac67-224">連絡先の携帯電話番号です。</span><span class="sxs-lookup"><span data-stu-id="fac67-224">Mobile phone number of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-225"><b>ニックネーム</b></span><span class="sxs-lookup"><span data-stu-id="fac67-225"><b>Nickname</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-226">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-226">Optional.</span></span></p>
<p><span data-ttu-id="fac67-227">連絡先のニックネームです。</span><span class="sxs-lookup"><span data-stu-id="fac67-227">Nickname of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-228"><b>メモ</b></span><span class="sxs-lookup"><span data-stu-id="fac67-228"><b>Notes</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-229">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-229">Optional.</span></span></p>
<p><span data-ttu-id="fac67-230">連絡先に関する備考です。</span><span class="sxs-lookup"><span data-stu-id="fac67-230">Notes about the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-231"><b>OtherEmail</b></span><span class="sxs-lookup"><span data-stu-id="fac67-231"><b>OtherEmail</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-232">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-232">Optional.</span></span></p>
<p><span data-ttu-id="fac67-233">連絡先のその他のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="fac67-233">Other Email of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-234"><b>PersonalEmail</b></span><span class="sxs-lookup"><span data-stu-id="fac67-234"><b>PersonalEmail</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-235">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-235">Optional.</span></span></p>
<p><span data-ttu-id="fac67-236">連絡先の個人用メール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="fac67-236">Personal Email of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-237"><b>サフィックス</b></span><span class="sxs-lookup"><span data-stu-id="fac67-237"><b>Suffix</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-238">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-238">Optional.</span></span></p>
<p><span data-ttu-id="fac67-239">連絡先のサフィックスです。</span><span class="sxs-lookup"><span data-stu-id="fac67-239">Suffix of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-240"><b>タイトル</b></span><span class="sxs-lookup"><span data-stu-id="fac67-240"><b>Title</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-241">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-241">Optional.</span></span></p>
<p><span data-ttu-id="fac67-242">連絡先の敬称です。</span><span class="sxs-lookup"><span data-stu-id="fac67-242">Title of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-243"><b>Web サイト</b></span><span class="sxs-lookup"><span data-stu-id="fac67-243"><b>Website</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-244">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-244">Optional.</span></span></p>
<p><span data-ttu-id="fac67-245">連絡先の Web サイトです。</span><span class="sxs-lookup"><span data-stu-id="fac67-245">Website of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-246"><b>WorkAddressCity</b></span><span class="sxs-lookup"><span data-stu-id="fac67-246"><b>WorkAddressCity</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-247">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-247">Optional.</span></span></p>
<p><span data-ttu-id="fac67-248">会社の住所の都市名です。</span><span class="sxs-lookup"><span data-stu-id="fac67-248">City of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-249"><b>WorkAddressCountry</b></span><span class="sxs-lookup"><span data-stu-id="fac67-249"><b>WorkAddressCountry</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-250">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-250">Optional.</span></span></p>
<p><span data-ttu-id="fac67-251">会社の住所の国です。</span><span class="sxs-lookup"><span data-stu-id="fac67-251">Country of the work address.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-252"><b>WorkAddressState</b></span><span class="sxs-lookup"><span data-stu-id="fac67-252"><b>WorkAddressState</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-253">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-253">Optional.</span></span></p>
<p><span data-ttu-id="fac67-254">会社の住所の州の名前です。</span><span class="sxs-lookup"><span data-stu-id="fac67-254">State of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-255"><b>WorkAddressStreet</b></span><span class="sxs-lookup"><span data-stu-id="fac67-255"><b>WorkAddressStreet</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-256">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-256">Optional.</span></span></p>
<p><span data-ttu-id="fac67-257">会社の住所の番地です。</span><span class="sxs-lookup"><span data-stu-id="fac67-257">Street of work address.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-258"><b>WorkAddressZipCode</b></span><span class="sxs-lookup"><span data-stu-id="fac67-258"><b>WorkAddressZipCode</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-259">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-259">Optional.</span></span></p>
<p><span data-ttu-id="fac67-260">会社の住所の郵便番号です。</span><span class="sxs-lookup"><span data-stu-id="fac67-260">Zip Code of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><span data-ttu-id="fac67-261"><b>勤務</b></span><span class="sxs-lookup"><span data-stu-id="fac67-261"><b>WorkEmail</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-262">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-262">Optional.</span></span></p>
<p><span data-ttu-id="fac67-263">連絡先の仕事用メール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="fac67-263">Work Email of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><span data-ttu-id="fac67-264"><b>住所</b></span><span class="sxs-lookup"><span data-stu-id="fac67-264"><b>WorkPhone</b></span></span></td>
<td align="left"><p><span data-ttu-id="fac67-265">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="fac67-265">Optional.</span></span></p>
<p><span data-ttu-id="fac67-266">連絡先の会社の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="fac67-266">Work phone number of the contact.</span></span></p></td>
</tr>
</tbody>
</table>
