---
author: TylerMSFT
title: People アプリの起動
description: このトピックでは、ms-people URI スキームについて説明します。 アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。
ms.assetid: 1E604599-26EF-421C-932F-E9935CDB248E
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 75f0a47400acaedf57737852f5e822d7907c1d6d
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1663642"
---
# <a name="launch-the-people-app"></a><span data-ttu-id="e9ff0-105">People アプリの起動</span><span class="sxs-lookup"><span data-stu-id="e9ff0-105">Launch the People app</span></span>

<span data-ttu-id="e9ff0-106">ここでは、**ms-people:** URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-106">This topic describes the **ms-people:** URI scheme.</span></span> <span data-ttu-id="e9ff0-107">アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-107">Your app can use this URI scheme to launch the People app for specific actions.</span></span>

## <a name="ms-people-uri-scheme-reference"></a><span data-ttu-id="e9ff0-108">ms-people: URI スキーム リファレンス</span><span class="sxs-lookup"><span data-stu-id="e9ff0-108">ms-people: URI scheme reference</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e9ff0-109">結果</span><span class="sxs-lookup"><span data-stu-id="e9ff0-109">Results</span></span></th>
<th align="left"><span data-ttu-id="e9ff0-110">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="e9ff0-110">URI scheme</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e9ff0-111">他のアプリから People アプリのメイン ページを起動できます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-111">Allows other apps to launch the People app Main page.</span></span></td>
<td align="left"><span data-ttu-id="e9ff0-112">ms-people:</span><span class="sxs-lookup"><span data-stu-id="e9ff0-112">ms-people:</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e9ff0-113">他のアプリから People アプリの設定ページを起動できます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-113">Allows other apps to launch the People app Settings page.</span></span></td>
<td align="left"><span data-ttu-id="e9ff0-114">ms-people:settings</span><span class="sxs-lookup"><span data-stu-id="e9ff0-114">ms-people:settings</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e9ff0-115">他のアプリから、検索文字列を指定して People アプリを起動し、検索の結果ページを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-115">Allows other apps to provide a search string that will launch the People app with the result page of the search.</span></span>
<div class="alert">
<p><span data-ttu-id="e9ff0-116">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-116">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="e9ff0-117">構文を正しく入力していない場合や、検索文字列の値が不足している場合、既定の動作ではフィルター処理せずにすべての連絡先の一覧が返されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-117">If you do not enter the syntax correctly, or are missing the search string value, the default behavior is to return a full list of contacts without any filtering.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="e9ff0-118">ms-people:search?SearchString=&lt;contactsearchinfo&gt;</span><span class="sxs-lookup"><span data-stu-id="e9ff0-118">ms-people:search?SearchString=&lt;contactsearchinfo&gt;</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e9ff0-119">連絡先が見つかった場合は、既存の連絡先カードを起動します。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-119">Launches to an existing contact card, if the contact is found.</span></span> <span data-ttu-id="e9ff0-120">または、連絡先が見つからなかった場合は、一時的な連絡先カードを起動します。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-120">Or, launches to a temporary contact card, if no contact is found.</span></span> <span data-ttu-id="e9ff0-121">入力パラメーターが指定されていない場合は、People アプリが起動され、連絡先一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-121">If no input parameter is supplied, we will launch the People App with a contact list.</span></span>
<div class="alert">
<p><span data-ttu-id="e9ff0-122">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-122">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="e9ff0-123">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-123">The order of the parameters doesn’t matter.</span></span></p>
<p><span data-ttu-id="e9ff0-124">一致する連絡先が複数ある場合は、最初に一致した連絡先が返されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-124">If there is more than one match, we will return the first match of the contact.</span></span></p>
</div>
<div> 
</div></td>
<td align="left"><span data-ttu-id="e9ff0-125">ms-people:viewcontact:?ContactId=&lt;contactid&gt;&amp;AggregatedId=&lt;aggid&gt;&amp;PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;&amp;Contact=&lt;contactobj&gt;</span><span class="sxs-lookup"><span data-stu-id="e9ff0-125">ms-people:viewcontact:?ContactId=&lt;contactid&gt;&amp;AggregatedId=&lt;aggid&gt;&amp;PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;&amp;Contact=&lt;contactobj&gt;</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e9ff0-126">People アプリ内の連絡先の保存ページを起動し、指定した連絡先を、指定した電話番号またはメール アドレスと共に保存します。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-126">Launches to a Save-contact page within the People app to save the given contact with the supplied phone number or email address.</span></span>
<div class="alert">
<p><span data-ttu-id="e9ff0-127">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-127">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="e9ff0-128">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-128">The order of the parameters doesn’t matter.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="e9ff0-129">ms-people:savetocontact?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span><span class="sxs-lookup"><span data-stu-id="e9ff0-129">ms-people:savetocontact?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e9ff0-130">People アプリ内の新しい連絡先の追加ページを起動し、指定した連絡先を保存します。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-130">Launches to the add a new contact page within the People app to save the given contact.</span></span>
<div class="alert"><p><span data-ttu-id="e9ff0-131">新しい連絡先の保存ページを起動するには、<a href="https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriForResultsAsync_Windows_Foundation_Uri_Windows_System_LauncherOptions_Windows_Foundation_Collections_ValueSet_">LaunchUriForResultsAsync</a> を使用します。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-131">Use <a href="https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriForResultsAsync_Windows_Foundation_Uri_Windows_System_LauncherOptions_Windows_Foundation_Collections_ValueSet_">LaunchUriForResultsAsync</a> to open the save new contact page.</span></span> <span data-ttu-id="e9ff0-132"><strong>LaunchUriAsync</strong> を使用すると、People アプリのメイン ページのみが起動します。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-132">Using <strong>LaunchUriAsync</strong> will only launch the People app Main page.</span></span></p>
<p><span data-ttu-id="e9ff0-133">パラメーターは、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-133">The parameters are case sensitive.</span></span></p>
<p><span data-ttu-id="e9ff0-134">パラメーターの順序に意味はありません。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-134">The order of the parameters doesn’t matter.</span></span></p>
<p><span data-ttu-id="e9ff0-135">サポートされているパラメーターはどのような組み合わせでも使用することができます。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-135">You can use any combination of supported parameters.</span></span></p>
</div>
<div>
</div></td>
<td align="left"><span data-ttu-id="e9ff0-136">ms-people:savecontacttask?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span><span class="sxs-lookup"><span data-stu-id="e9ff0-136">ms-people:savecontacttask?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</span></span></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesearch-parameter-reference"></a><span data-ttu-id="e9ff0-137">ms-people:search: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="e9ff0-137">ms-people:search: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e9ff0-138">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9ff0-138">Parameter</span></span></th>
<th align="left"><span data-ttu-id="e9ff0-139">説明</span><span class="sxs-lookup"><span data-stu-id="e9ff0-139">Description</span></span></th>
<th align="left"><span data-ttu-id="e9ff0-140">例</span><span class="sxs-lookup"><span data-stu-id="e9ff0-140">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-141">SearchString</span><span class="sxs-lookup"><span data-stu-id="e9ff0-141">SearchString</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-142">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-142">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-143">連絡先の検索情報の検索文字列です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-143">The search string for the contact search information.</span></span></p>
<p><span data-ttu-id="e9ff0-144">電話番号または連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-144">The phone number or the contact name.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-145">ms-people:search?SearchString=Smith</span><span class="sxs-lookup"><span data-stu-id="e9ff0-145">ms-people:search?SearchString=Smith</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peopleviewcontact-parameter-reference"></a><span data-ttu-id="e9ff0-146">ms-people:viewcontact: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="e9ff0-146">ms-people:viewcontact: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e9ff0-147">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9ff0-147">Parameter</span></span></th>
<th align="left"><span data-ttu-id="e9ff0-148">説明</span><span class="sxs-lookup"><span data-stu-id="e9ff0-148">Description</span></span></th>
<th align="left"><span data-ttu-id="e9ff0-149">例</span><span class="sxs-lookup"><span data-stu-id="e9ff0-149">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-150">ContactId</span><span class="sxs-lookup"><span data-stu-id="e9ff0-150">ContactId</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-151">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-151">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-152">連絡先の連絡先 ID です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-152">Contact Id of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-153">ms-people:viewcontact?ContactId={ContactId}</span><span class="sxs-lookup"><span data-stu-id="e9ff0-153">ms-people:viewcontact?ContactId={ContactId}</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-154">PhoneNumber</span><span class="sxs-lookup"><span data-stu-id="e9ff0-154">PhoneNumber</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-155">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-155">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-156">連絡先の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-156">Phone number of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-157">ms-people:viewcontact?PhoneNumber=%2014257069326</span><span class="sxs-lookup"><span data-stu-id="e9ff0-157">ms-people:viewcontact?PhoneNumber=%2014257069326</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-158">Email</span><span class="sxs-lookup"><span data-stu-id="e9ff0-158">Email</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-159">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-159">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-160">連絡先のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-160">Email of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-161">ms-people:viewcontact?Email=johnsmith@contsco.com</span><span class="sxs-lookup"><span data-stu-id="e9ff0-161">ms-people:viewcontact?Email=johnsmith@contsco.com</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-162">ContactName</span><span class="sxs-lookup"><span data-stu-id="e9ff0-162">ContactName</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-163">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-163">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-164">連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-164">Name of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-165">ms-people:viewcontact?ContactName=John%20%Smith</span><span class="sxs-lookup"><span data-stu-id="e9ff0-165">ms-people:viewcontact?ContactName=John%20%Smith</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-166">Contact</span><span class="sxs-lookup"><span data-stu-id="e9ff0-166">Contact</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-167">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-167">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-168">Contact オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-168">Contact object.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-169">ms-people:viewcontact?Contact={Serialized Contact}</span><span class="sxs-lookup"><span data-stu-id="e9ff0-169">ms-people:viewcontact?Contact={Serialized Contact}</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesavetocontact-parameter-reference"></a><span data-ttu-id="e9ff0-170">ms-people:savetocontact: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="e9ff0-170">ms-people:savetocontact: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e9ff0-171">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9ff0-171">Parameter</span></span></th>
<th align="left"><span data-ttu-id="e9ff0-172">説明</span><span class="sxs-lookup"><span data-stu-id="e9ff0-172">Description</span></span></th>
<th align="left"><span data-ttu-id="e9ff0-173">例</span><span class="sxs-lookup"><span data-stu-id="e9ff0-173">Example</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-174">PhoneNumber</span><span class="sxs-lookup"><span data-stu-id="e9ff0-174">PhoneNumber</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-175">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-175">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-176">連絡先の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-176">Phone number of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-177">ms-people:savetocontact?PhoneNumber=%2014257069326</span><span class="sxs-lookup"><span data-stu-id="e9ff0-177">ms-people:savetocontact?PhoneNumber=%2014257069326</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-178">Email</span><span class="sxs-lookup"><span data-stu-id="e9ff0-178">Email</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-179">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-179">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-180">連絡先のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-180">Email of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-181">ms-people:savetocontact?Email=johnsmith@contsco.com</span><span class="sxs-lookup"><span data-stu-id="e9ff0-181">ms-people:savetocontact?Email=johnsmith@contsco.com</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-182">ContactName</span><span class="sxs-lookup"><span data-stu-id="e9ff0-182">ContactName</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-183">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-183">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-184">連絡先の名前です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-184">Name of the contact.</span></span></p></td>
<td align="left"><p><span data-ttu-id="e9ff0-185">ms-people:savetocontact?Email=johnsmith@contsco.com&amp;ContactName= John%20%Smith</span><span class="sxs-lookup"><span data-stu-id="e9ff0-185">ms-people:savetocontact?Email=johnsmith@contsco.com&amp;ContactName= John%20%Smith</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesavecontacttask-parameter-reference"></a><span data-ttu-id="e9ff0-186">ms-people:savecontacttask: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="e9ff0-186">ms-people:savecontacttask: parameter reference</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e9ff0-187">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9ff0-187">Parameter</span></span></th>
<th align="left"><span data-ttu-id="e9ff0-188">説明</span><span class="sxs-lookup"><span data-stu-id="e9ff0-188">Description</span></span></th>

</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-189">Company</span><span class="sxs-lookup"><span data-stu-id="e9ff0-189">Company</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-190">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-190">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-191">連絡先の会社名です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-191">Company name of the contact.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-192">FirstName</span><span class="sxs-lookup"><span data-stu-id="e9ff0-192">FirstName</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-193">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-193">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-194">連絡先の名です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-194">First name of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-195">HomeAddressCity</span><span class="sxs-lookup"><span data-stu-id="e9ff0-195">HomeAddressCity</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-196">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-196">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-197">自宅の住所の都市名です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-197">City of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-198">HomeAddressCountry</span><span class="sxs-lookup"><span data-stu-id="e9ff0-198">HomeAddressCountry</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-199">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-199">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-200">自宅の住所の国です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-200">Country of the home address.</span></span></p></td>

</tr>
<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-201">HomeAddressState</span><span class="sxs-lookup"><span data-stu-id="e9ff0-201">HomeAddressState</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-202">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-202">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-203">自宅の住所の州の名前です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-203">State of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-204">HomeAddressStreet</span><span class="sxs-lookup"><span data-stu-id="e9ff0-204">HomeAddressStreet</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-205">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-205">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-206">自宅の住所の番地です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-206">Street of the home address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-207">HomeAddressZipCode</span><span class="sxs-lookup"><span data-stu-id="e9ff0-207">HomeAddressZipCode</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-208">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-208">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-209">自宅の住所の郵便番号です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-209">Zip Code of the home address.</span></span></p></td>

</tr>
<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-210">HomePhone</span><span class="sxs-lookup"><span data-stu-id="e9ff0-210">HomePhone</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-211">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-211">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-212">連絡先の自宅電話番号です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-212">Home phone of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-213">JobTitle</span><span class="sxs-lookup"><span data-stu-id="e9ff0-213">JobTitle</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-214">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-214">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-215">連絡先の役職です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-215">Job title of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-216">LastName</span><span class="sxs-lookup"><span data-stu-id="e9ff0-216">LastName</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-217">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-217">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-218">連絡先の姓です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-218">Last name of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-219">MiddleName</span><span class="sxs-lookup"><span data-stu-id="e9ff0-219">MiddleName</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-220">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-220">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-221">連絡先のミドル ネームです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-221">Middle name of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-222">MobilePhone</span><span class="sxs-lookup"><span data-stu-id="e9ff0-222">MobilePhone</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-223">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-223">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-224">連絡先の携帯電話番号です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-224">Mobile phone number of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-225">Nickname</span><span class="sxs-lookup"><span data-stu-id="e9ff0-225">Nickname</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-226">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-226">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-227">連絡先のニックネームです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-227">Nickname of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-228">Notes</span><span class="sxs-lookup"><span data-stu-id="e9ff0-228">Notes</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-229">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-229">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-230">連絡先に関する備考です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-230">Notes about the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-231">OtherEmail</span><span class="sxs-lookup"><span data-stu-id="e9ff0-231">OtherEmail</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-232">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-232">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-233">連絡先のその他のメール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-233">Other Email of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-234">PersonalEmail</span><span class="sxs-lookup"><span data-stu-id="e9ff0-234">PersonalEmail</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-235">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-235">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-236">連絡先の個人用メール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-236">Personal Email of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-237">Suffix</span><span class="sxs-lookup"><span data-stu-id="e9ff0-237">Suffix</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-238">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-238">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-239">連絡先のサフィックスです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-239">Suffix of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-240">Title</span><span class="sxs-lookup"><span data-stu-id="e9ff0-240">Title</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-241">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-241">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-242">連絡先の敬称です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-242">Title of the contact.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-243">Website</span><span class="sxs-lookup"><span data-stu-id="e9ff0-243">Website</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-244">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-244">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-245">連絡先の Web サイトです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-245">Website of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-246">WorkAddressCity</span><span class="sxs-lookup"><span data-stu-id="e9ff0-246">WorkAddressCity</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-247">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-247">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-248">会社の住所の都市名です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-248">City of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-249">WorkAddressCountry</span><span class="sxs-lookup"><span data-stu-id="e9ff0-249">WorkAddressCountry</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-250">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-250">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-251">会社の住所の国です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-251">Country of the work address.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-252">WorkAddressState</span><span class="sxs-lookup"><span data-stu-id="e9ff0-252">WorkAddressState</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-253">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-253">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-254">会社の住所の州の名前です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-254">State of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-255">WorkAddressStreet</span><span class="sxs-lookup"><span data-stu-id="e9ff0-255">WorkAddressStreet</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-256">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-256">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-257">会社の住所の番地です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-257">Street of work address.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-258">WorkAddressZipCode</span><span class="sxs-lookup"><span data-stu-id="e9ff0-258">WorkAddressZipCode</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-259">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-259">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-260">会社の住所の郵便番号です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-260">Zip Code of the work address.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left"><b><span data-ttu-id="e9ff0-261">WorkEmail</span><span class="sxs-lookup"><span data-stu-id="e9ff0-261">WorkEmail</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-262">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-262">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-263">連絡先の仕事用メール アドレスです。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-263">Work Email of the contact.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><b><span data-ttu-id="e9ff0-264">WorkPhone</span><span class="sxs-lookup"><span data-stu-id="e9ff0-264">WorkPhone</span></span></b></td>
<td align="left"><p><span data-ttu-id="e9ff0-265">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-265">Optional.</span></span></p>
<p><span data-ttu-id="e9ff0-266">連絡先の会社の電話番号です。</span><span class="sxs-lookup"><span data-stu-id="e9ff0-266">Work phone number of the contact.</span></span></p></td>
</tr>
</tbody>
</table>
