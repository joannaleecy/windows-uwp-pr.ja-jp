---
author: TylerMSFT
title: "People アプリの起動"
description: "ここでは、ms-people URI スキームについて説明します。 アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。"
ms.assetid: 1E604599-26EF-421C-932F-E9935CDB248E
ms.sourcegitcommit: 39a012976ee877d8834b63def04e39d847036132
ms.openlocfilehash: fd3c38dd0b6df2f430d7be4c40e7131d4ae98616

---

# People アプリの起動


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


ここでは、**ms-people:** URI スキームについて説明します。 アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。

## ms-people: URI スキーム リファレンス


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
**注**  
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
**注**  
<p>パラメーターは、大文字と小文字が区別されます。</p>
<p>パラメーターの順序に意味はありません。</p>
<p>一致する連絡先が複数ある場合は、最初に一致した連絡先が返されます。</p>
</div>
<div>
 
</div></td>
<td align="left">ms-people:viewcontact:?ContactId=&lt;contactid&gt;&amp;AggregatedId=&lt;aggid&gt;&amp;PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;&amp;Contact=&lt;contactobj&gt;</td>
</tr>
<tr class="odd">
<td align="left">People アプリ内の連絡先の保存ページを起動し、指定した連絡先を、指定した電話番号またはメール アドレスと共に保存します。
<div class="alert">
**注**  
<p>パラメーターは、大文字と小文字が区別されます。</p>
<p>パラメーターの順序に意味はありません。</p>
</div>
<div>
 
</div></td>
<td align="left">ms-people:savetocontact?PhoneNumber= &lt;phonenum&gt;&amp;Email=&lt;email&gt;&amp;ContactName=&lt;name&gt;</td>
</tr>
</tbody>
</table>

 

## ms-people:search: のパラメーター リファレンス


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
<td align="left">**SearchString**</td>
<td align="left"><p>省略可能です。</p>
<p>連絡先の検索情報の検索文字列です。</p>
<p>電話番号または連絡先の名前です。</p></td>
<td align="left"><p>ms-people:search?SearchString=Smith</p></td>
</tr>
</tbody>
</table>

 

## ms-people:viewcontact: のパラメーター リファレンス


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
<td align="left">**ContactId**</td>
<td align="left"><p>省略可能です。</p>
<p>連絡先の連絡先 ID です。</p></td>
<td align="left"><p>ms-people:viewcontact?ContactId={ContactId}</p></td>
</tr>
<tr class="even">
<td align="left">**PhoneNumber**</td>
<td align="left"><p>省略可能です。</p>
<p>連絡先の電話番号です。</p></td>
<td align="left"><p>ms-people:viewcontact?PhoneNumber=%2014257069326</p></td>
</tr>
<tr class="odd">
<td align="left">**Email**</td>
<td align="left"><p>省略可能です。</p>
<p>連絡先のメール アドレスです。</p></td>
<td align="left"><p>ms-people:viewcontact?Email=johnsmith@contsco.com</p></td>
</tr>
<tr class="even">
<td align="left">**ContactName**</td>
<td align="left"><p>省略可能です。</p>
<p>連絡先の名前です。</p></td>
<td align="left"><p>ms-people:viewcontact?ContactName=John%20%Smith</p></td>
</tr>
<tr class="odd">
<td align="left">**Contact**</td>
<td align="left"><p>省略可能です。</p>
<p>Contact オブジェクトです。</p></td>
<td align="left"><p>ms-people:viewcontact?Contact={Serialized Contact}</p></td>
</tr>
</tbody>
</table>

 

## ms-people:savetocontact: のパラメーター リファレンス


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
<td align="left">**PhoneNumber**</td>
<td align="left"><p>省略可能です。</p>
<p>連絡先の電話番号です。</p></td>
<td align="left"><p>ms-people:savetocontact?PhoneNumber=%2014257069326</p></td>
</tr>
<tr class="even">
<td align="left">**Email**</td>
<td align="left"><p>省略可能です。</p>
<p>連絡先のメール アドレスです。</p></td>
<td align="left"><p>ms-people:savetocontact?Email=johnsmith@contsco.com</p></td>
</tr>
<tr class="odd">
<td align="left">**ContactName**</td>
<td align="left"><p>省略可能です。</p>
<p>連絡先の名前です。</p></td>
<td align="left"><p>ms-people:savetocontact?Email=johnsmith@contsco.com&amp;ContactName= John%20%Smith</p></td>
</tr>
</tbody>
</table>

 

 

 



<!--HONumber=Jun16_HO4-->


