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
# <a name="launch-the-people-app"></a>People アプリの起動

このトピックで説明します、 **ms ユーザー。** URI スキーム。 アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。

## <a name="ms-people-uri-scheme-reference"></a>ms-people:URI スキームの参照

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">結果</th>
<th align="left">URI スキーム</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">他のアプリから People アプリのメイン ページを起動できます。</td>
<td align="left">ms-people:</td>
</tr>
<tr class="even">
<td align="left">他のアプリから People アプリの設定ページを起動できます。</td>
<td align="left">ms-people:settings</td>
</tr>
<tr class="odd">
<td align="left">他のアプリから、検索文字列を指定して People アプリを起動し、検索の結果ページを表示できます。
<div class="alert">
<p>パラメーターは、大文字と小文字が区別されます。</p>
<p>構文を正しく入力していない場合や、検索文字列の値が不足している場合、既定の動作ではフィルター処理せずにすべての連絡先の一覧が返されます。</p>
</div>
<div>
</div></td>
<td align="left">ms-people:search?SearchString=&lt;contactsearchinfo&gt;</td>
</tr>
<tr class="even">
<td align="left">連絡先が見つかった場合は、既存の連絡先カードを起動します。 または、連絡先が見つからなかった場合は、一時的な連絡先カードを起動します。 入力パラメーターが指定されていない場合は、People アプリが起動され、連絡先一覧が表示されます。
<div class="alert">
<p>パラメーターは、大文字と小文字が区別されます。</p>
<p>パラメーターの順序に意味はありません。</p>
<p>一致する連絡先が複数ある場合は、最初に一致した連絡先が返されます。</p>
</div>
<div> 
</div></td>
<td align="left">ms-ユーザー: viewcontact でしょうか。ContactId =&lt;contactid&gt;&amp;AggregatedId =&lt;aggid&gt;&amp;PhoneNumber = &lt;phonenum&gt;&amp;電子メール =&lt;電子メール&gt; &amp;ContactName =&lt;名前&gt;&amp;連絡先 =&lt;contactobj&gt;</td>
</tr>
<tr class="odd">
<td align="left">People アプリ内の連絡先の保存ページを起動し、指定した連絡先を、指定した電話番号またはメール アドレスと共に保存します。
<div class="alert">
<p>パラメーターは、大文字と小文字が区別されます。</p>
<p>パラメーターの順序に意味はありません。</p>
</div>
<div>
</div></td>
<td align="left">ms-people:savetocontact?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</td>
</tr>
<tr class="even">
<td align="left">People アプリ内の新しい連絡先の追加ページを起動し、指定した連絡先を保存します。
<div class="alert"><p>新しい連絡先の保存ページを起動するには、<a href="https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriForResultsAsync_Windows_Foundation_Uri_Windows_System_LauncherOptions_Windows_Foundation_Collections_ValueSet_">LaunchUriForResultsAsync</a> を使用します。 <strong>LaunchUriAsync</strong> を使用すると、People アプリのメイン ページのみが起動します。</p>
<p>パラメーターは、大文字と小文字が区別されます。</p>
<p>パラメーターの順序に意味はありません。</p>
<p>サポートされているパラメーターはどのような組み合わせでも使用することができます。</p>
</div>
<div>
</div></td>
<td align="left">ms-people:savecontacttask?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesearch-parameter-reference"></a>ms-people:search: のパラメーター リファレンス

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">パラメーター</th>
<th align="left">説明</th>
<th align="left">例</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b>SearchString</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の検索情報の検索文字列です。</p>
<p>電話番号または連絡先の名前です。</p></td>
<td align="left"><p>ms-people:search?SearchString=Smith</p></td>
</tr>
</tbody>
</table>

## <a name="ms-peopleviewcontact-parameter-reference"></a>ms-people:viewcontact: のパラメーター リファレンス

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">パラメーター</th>
<th align="left">説明</th>
<th align="left">例</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b>ContactId</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の連絡先 ID です。</p></td>
<td align="left"><p>ms-people:viewcontact?ContactId={ContactId}</p></td>
</tr>
<tr class="even">
<td align="left"><b>PhoneNumber</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の電話番号です。</p></td>
<td align="left"><p>ms-people:viewcontact?PhoneNumber=%2014257069326</p></td>
</tr>
<tr class="odd">
<td align="left"><b>メール</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先のメール アドレスです。</p></td>
<td align="left"><p>ms-people:viewcontact?Email=johnsmith@contsco.com</p></td>
</tr>
<tr class="even">
<td align="left"><b>ContactName</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の名前です。</p></td>
<td align="left"><p>ms-people:viewcontact?ContactName=John%20%Smith</p></td>
</tr>
<tr class="odd">
<td align="left"><b>Contact</b></td>
<td align="left"><p>(省略可能)。</p>
<p>Contact オブジェクトです。</p></td>
<td align="left"><p>ms-people:viewcontact?Contact={Serialized Contact}</p></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesavetocontact-parameter-reference"></a>ms-people:savetocontact: のパラメーター リファレンス

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">パラメーター</th>
<th align="left">説明</th>
<th align="left">例</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b>PhoneNumber</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の電話番号です。</p></td>
<td align="left"><p>ms-people:savetocontact?PhoneNumber=%2014257069326</p></td>
</tr>
<tr class="even">
<td align="left"><b>メール</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先のメール アドレスです。</p></td>
<td align="left"><p>ms-people:savetocontact?Email=johnsmith@contsco.com</p></td>
</tr>
<tr class="odd">
<td align="left"><b>ContactName</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の名前です。</p></td>
<td align="left"><p>ms-people:savetocontact?Email=johnsmith@contsco.com&amp;ContactName= John%20%Smith</p></td>
</tr>
</tbody>
</table>

## <a name="ms-peoplesavecontacttask-parameter-reference"></a>ms-people:savecontacttask: のパラメーター リファレンス

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">パラメーター</th>
<th align="left">説明</th>

</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b>企業</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の会社名です。</p></td>

</tr>
<tr class="even">
<td align="left"><b>firstName</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の名です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>HomeAddressCity</b></td>
<td align="left"><p>(省略可能)。</p>
<p>自宅の住所の都市名です。</p></td>

</tr>
<tr class="even">
<td align="left"><b>HomeAddressCountry</b></td>
<td align="left"><p>(省略可能)。</p>
<p>自宅の住所の国です。</p></td>

</tr>
<tr class="odd">
<td align="left"><b>HomeAddressState</b></td>
<td align="left"><p>(省略可能)。</p>
<p>自宅の住所の州の名前です。</p></td>

</tr>
<tr class="even">
<td align="left"><b>HomeAddressStreet</b></td>
<td align="left"><p>(省略可能)。</p>
<p>自宅の住所の番地です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>HomeAddressZipCode</b></td>
<td align="left"><p>(省略可能)。</p>
<p>自宅の住所の郵便番号です。</p></td>

</tr>
<tr class="even">
<td align="left"><b>homephone です。</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の自宅電話番号です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>JobTitle</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の役職です。</p></td>
</tr>

<tr class="even">
<td align="left"><b>[氏名]</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の姓です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>MiddleName</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先のミドル ネームです。</p></td>
</tr>

<tr class="even">
<td align="left"><b>MobilePhone</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の携帯電話番号です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>ニックネーム</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先のニックネームです。</p></td>
</tr>

<tr class="even">
<td align="left"><b>メモ</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先に関する備考です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>OtherEmail</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先のその他のメール アドレスです。</p></td>
</tr>

<tr class="even">
<td align="left"><b>PersonalEmail</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の個人用メール アドレスです。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>サフィックス</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先のサフィックスです。</p></td>
</tr>

<tr class="even">
<td align="left"><b>タイトル</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の敬称です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>Web サイト</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の Web サイトです。</p></td>
</tr>

<tr class="even">
<td align="left"><b>WorkAddressCity</b></td>
<td align="left"><p>(省略可能)。</p>
<p>会社の住所の都市名です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>WorkAddressCountry</b></td>
<td align="left"><p>(省略可能)。</p>
<p>会社の住所の国です。</p></td>
</tr>

<tr class="even">
<td align="left"><b>WorkAddressState</b></td>
<td align="left"><p>(省略可能)。</p>
<p>会社の住所の州の名前です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>WorkAddressStreet</b></td>
<td align="left"><p>(省略可能)。</p>
<p>会社の住所の番地です。</p></td>
</tr>

<tr class="even">
<td align="left"><b>WorkAddressZipCode</b></td>
<td align="left"><p>(省略可能)。</p>
<p>会社の住所の郵便番号です。</p></td>
</tr>

<tr class="odd">
<td align="left"><b>勤務</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の仕事用メール アドレスです。</p></td>
</tr>

<tr class="even">
<td align="left"><b>住所</b></td>
<td align="left"><p>(省略可能)。</p>
<p>連絡先の会社の電話番号です。</p></td>
</tr>
</tbody>
</table>
