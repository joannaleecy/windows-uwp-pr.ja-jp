---
author: DelfCo
Description: "グローバリゼーションとは、変更やカスタマイズを加えなくてもさまざまなグローバル市場で適切に動作するようにアプリを設計および開発するプロセスです。"
Search.SourceType: Video
title: "グローバリゼーションとローカライズ"
ms.assetid: c0791eec-5bb8-4a13-8977-61d7d98e35ce
label: Intro
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: 59e02840c72d8bccda7e318197e4bf45ed667fa4
ms.openlocfilehash: a34b682cc903555b9d6f64636c3d1cf7bee75b5d

---

# グローバリゼーションとローカライズ




Windows は世界中で利用されており、文化、地域、言語の異なるユーザーがいます。 ユーザーは、自分の使用言語としてどの言語でも指定でき、複数の言語を指定することもできます。 住んでいる地域として世界中のどの場所を指定することもでき、地域を問わずどの言語でも指定できます。 *グローバリゼーション*と*ローカライズ*によってアプリの適応性を高めることにより、潜在的な市場を拡大することができます。

**グローバリゼーション**とは、変更やカスタマイズを加えなくてもさまざまなグローバル市場で適切に動作するようにアプリを設計および開発するプロセスです。

たとえば次のようなことが可能です。

-   言語が変更されてテキストの長さやフォント サイズが変わってもラベルやテキスト文字列が正しく表示されるようにアプリのレイアウトを設計する。
-   テキストや文化に依存するイメージを、アプリのコードやマークアップにハードコーディングする代わりに、さまざまな地域市場に適応できるリソースから取得する。
-   Globalization API を使って、地域ごとに形式の異なるデータ (数値、日付、時刻、通貨など) を表示する。

**ローカライズ**とは、特定の地域市場の言語、文化、政治の要件にアプリを適応させるプロセスです。

次に例を示します。

-   新しい市場のためにアプリのテキストとラベルを翻訳して、その言語のための独立したリソースを作成する。
-   文化に依存するイメージを必要に応じて変更し、個別のリソースに配置する。

世界に向けてアプリを準備する方法の概略については、ビデオ「[アプリのグローバリゼーションとローカライズの概略](https://channel9.msdn.com/Blogs/One-Dev-Minute/Introduction-to-globalization-and-localization)」をご覧ください。

## 記事
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">記事</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[推奨と非推奨](guidelines-and-checklist-for-globalizing-your-app.md)</p></td>
<td align="left"><p>広範なユーザー向けにアプリをグローバル化したり、特定の市場を対象にアプリをローカライズするときは、次のベスト プラクティスに従ってください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[グローバル対応の形式の使用](use-global-ready-formats.md)</p></td>
<td align="left"><p>日付、時刻、数字、通貨を適切に書式設定することで、グローバル対応のアプリを開発します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[言語と地域の管理](manage-language-and-region.md)</p></td>
<td align="left"><p>Windows で提供される言語と地域についてのさまざまな設定を使って、Windows がアプリの UI リソースをどのように選び、UI 要素のフォーマットをどのように決定するかを制御します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[パターンを使った日付と時刻の書式設定](use-patterns-to-format-dates-and-times.md)</p></td>
<td align="left"><p>希望するどおりの形式で日付と時刻を表示するには、[<strong>Windows.Globalization.DateTimeFormatting</strong>](https://msdn.microsoft.com/library/windows/apps/br206859) API をカスタム パターンとともに使用します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[レイアウトやフォントの調整と RTL のサポート](adjust-layout-and-fonts--and-support-rtl.md)</p></td>
<td align="left"><p>RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを開発します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[ローカライズのためにアプリの準備をする](prepare-your-app-for-localization.md)</p></td>
<td align="left"><p>他の市場、言語、または地域に向けたローカライズのためにアプリを準備します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[UI 文字列をリソースに格納する](put-ui-strings-into-resources.md)</p></td>
<td align="left"><p>UI の文字列リソースをリソース ファイルに格納します。 その後、これらの文字列をコードやマークアップから参照できます。</p></td>
</tr>
</tbody>
</table>

 

当初は Windows 8.x 用に作成されたドキュメントもご覧ください。このドキュメントは、ユニバーサル Windows プラットフォーム (UWP) のアプリや Windows 10 にも適用されます。

-   [アプリのグローバル化](https://msdn.microsoft.com/library/windows/apps/xaml/hh965328)
-   [言語の対応付け](https://msdn.microsoft.com/library/windows/apps/xaml/jj673578.aspx)
-   [NumeralSystem 値](https://msdn.microsoft.com/library/windows/apps/xaml/jj236471.aspx)
-   [国際フォント](https://msdn.microsoft.com/library/windows/apps/xaml/dn263115.aspx)
-   [アプリ リソースとローカライズ](https://msdn.microsoft.com/library/windows/apps/xaml/hh710212.aspx)

 

 






<!--HONumber=Aug16_HO3-->


