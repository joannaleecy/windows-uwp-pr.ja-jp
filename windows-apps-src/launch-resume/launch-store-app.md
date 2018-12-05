---
title: Microsoft Store アプリの起動
description: ここでは、ms-windows-store URI スキームについて説明します。 アプリは、この URI スキームを使用して、ストア内の特定のページに Microsoft Store アプリを起動することができます。
ms.assetid: 9A9C6576-1637-47D1-AC3B-D1A20D49E0FF
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f64a290443ed5e45a5379b13f70dcc1ea2f57fa9
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8689506"
---
# <a name="launch-the-microsoft-store-app"></a>Microsoft Store アプリの起動



ここでは、**ms-windows-store:** URI スキームについて説明します。 アプリは、この URI スキームを使用して、 [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476)メソッドを使用して、ストア内の特定のページに Microsoft Store アプリを起動することができます。

この例では、ゲームのページにストアを開く方法を示します。

```cs
bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store://navigatetopage/?Id=Games"));
```

## <a name="ms-windows-store-uri-scheme-reference"></a>ms-windows-store: URI スキーム リファレンス

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
<p>これらの値は、[パートナー センター](https://partner.microsoft.com/dashboard)で各アプリのアプリ管理] セクションで [<a href="https://msdn.microsoft.com/library/windows/apps/mt148561.aspx">アプリ id</a> ] ページで確認できます。</p>
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

 

 
