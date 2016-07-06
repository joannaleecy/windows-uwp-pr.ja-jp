---
author: TylerMSFT
title: "Windows ストア アプリの起動"
description: "ここでは、ms-windows-store URI スキームについて説明します。 アプリでこの URI スキームを使って、Windows ストア アプリを起動し、ストア内の特定のページを表示できます。"
ms.assetid: 9A9C6576-1637-47D1-AC3B-D1A20D49E0FF
ms.sourcegitcommit: 39a012976ee877d8834b63def04e39d847036132
ms.openlocfilehash: 9b48aeddb5ddc912fccd07149980655a06535470

---

# Windows ストア アプリの起動


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

ここでは、**ms-windows-store:** URI スキームについて説明します。 アプリでこの URI スキームを使って、Windows ストア アプリを起動し、ストア内の特定のページを表示できます。

## ms-windows-store: URI スキーム リファレンス

<table>
<tr><th>説明</th><th></th><th>URI スキーム</th></tr>
<tr><td>ストアのホーム ページを起動します。</td><td /><td>ms-windows-store://home</td></tr>
<tr><td>ストア内の最上位レベルのカテゴリを起動します。<p>注: すべてのユーザーがすべてのカテゴリにアクセスできるわけではありません。</p>
</td><td /><td>
<p>ms-windows-store://navigatetopage/?Id=Apps </p>
<p>ms-windows-store://navigatetopage/?Id=Games</p>
<p>ms-windows-store://navigatetopage/?Id=Music</p>
<p>ms-windows-store://navigatetopage/?Id=Video</p>
<p>ms-windows-store://navigatetopage/?Id=LOB</p>
</td>
</tr>
<tr>
<td rowspan="4">製品の詳細ページ (PDP) を起動します。 <p>ストア ID を使う方法は Windows 10 のユーザー向けに推奨される一方ですべての OS バージョンで動作しますが、以前の方法 (PFN など) も使うことができます。</p>
<p>Windows デベロッパー センター ダッシュボードにある各アプリの [アプリ管理] セクションの <a href="https://msdn.microsoft.com/library/windows/apps/mt148561.aspx">[アプリ ID]</a> ページでこれらの値を表示できます。</p>
</td>
<td>
ストア ID <p>(推奨)</p>
</td>
<td>
<p>ms-windows-store://pdp/?ProductId=9WZDNCRFHVJL</p>
</td>
</tr>
<tr>
<td>パッケージ ファミリ名 (PFN)</td>
<td>ms-windows-store://pdp/?PFN= Microsoft.Office.OneNote_8wekyb3d8bbwe
</td>
</tr>
<tr>
<td>製品 ID (Windows Phone 7.x/8.x)</td>
<td>ms-windows-store://pdp/?PhoneAppId=ca05b3ab-f157-450c-8c49-a1f127f5e71d </td>
</tr>
<tr>
<td>製品 ID (Windows 8.x)</td>
<td>ms-windows-store://pdp/?AppId=f022389f-f3a6-417e-ad23-704fbdf57117
</td>
</tr>
<tr>
<td rowspan="4">製品のレビューを書くエクスペリエンスを起動します。</td>
<td>ストア ID <p>(推奨)</p></td>
<td>ms-windows-store://review/?ProductId=9WZDNCRFHVJL </td>
</tr>
<tr>
<td>パッケージ ファミリ名 (PFN)</td>
<td>ms-windows-store://review/?PFN= Microsoft.Office.OneNote_8wekyb3d8bbwe
</td>
</tr>
<tr>
<td>製品 ID (Windows Phone 7.x/8.x)</td>
<td>ms-windows-store://reviewapp/?AppId=ca05b3ab-f157-450c-8c49-a1f127f5e71d </td>
</tr>
<tr>
<td>製品 ID (Windows 8.x)</td>
<td>ms-windows-store://review/?AppId=f022389f-f3a6-417e-ad23-704fbdf57117 </td>
</tr>
<tr>
<td>ファイル拡張子に関連付けられた製品の検索を起動します。 </td>
<td />
<td>ms-windows-store://assoc/?FileExt=pdf
</td>
</tr>
<tr>
<td>プロトコルに関連付けられた製品の検索を起動します。</td>
<td />
<td>ms-windows-store://assoc/?Protocol=ms-word </td>
</tr>
<tr>
<td>1 つまたは複数のタグに関連付けられた製品の検索を起動します。 タグはコンマで区切る必要があります。
</td>
<td />
<td>
<p>ms-windows-store://assoc/?Tags=Photos_Rich_Media_Edit </p>
<p>ms-windows-store://assoc/?Tags=Photos_Rich_Media_Edit, Camera_Capture_App</p>
</td>
</tr>
<tr>
<td>
指定されたクエリの検索を起動します。 クエリ内で空白文字を使うことができます。
</td>
<td />
<td>ms-windows-store://search/?query=OneNote </td>
</tr>
<tr>
<td>カテゴリ内で製品の検索を起動します。</td>
<td />
<td>
<p>ms-windows-store://browse/?type=Apps&amp;cat=Productivity</p>
<p>ms-windows-store://browse/?type=Apps&amp;cat=Health+%26+fitness </p>
</td>
</tr>
<tr>
<td>指定した発行元からの製品の検索を起動します。 名前には空白文字を使うことができます。
</td>
<td />
<td>ms-windows-store://publisher/?name=Microsoft Corporation
</td>
</tr>
<tr><td>ダウンロードと更新プログラムに関するページを起動します。</td>
<td />
<td>ms-windows-store://downloadsandupdates </td>
</tr>
<tr>
<td>ストアの設定ページを起動します。</td>
<td />
<td>ms-windows-store://settings </td>
</tr>
</table>

 

 



<!--HONumber=Jun16_HO5-->


