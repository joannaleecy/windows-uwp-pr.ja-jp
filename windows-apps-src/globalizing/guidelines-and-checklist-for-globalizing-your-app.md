---
author: DelfCo
Description: "広範なユーザー向けにアプリをグローバル化したり、特定の市場を対象にアプリをローカライズするときは、次のベスト プラクティスに従ってください。"
Search.Refinement.TopicID: 180
title: "グローバリゼーションとローカライズのガイドライン"
ms.assetid: 0342DC3F-DDD1-4DD4-872E-A4EC340CAE79
label: Do's and don'ts
template: detail.hbs
ms.author: bobdel
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: a5b3945f67ec1aa52b588b6364dbd04533968d24
ms.lasthandoff: 02/07/2017

---

# <a name="globalization-and-localization-dos-and-donts"></a>グローバリゼーションとローカライズの推奨と非推奨
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

広範なユーザー向けにアプリをグローバル化したり、特定の市場を対象にアプリをローカライズするときは、次のベスト プラクティスに従ってください。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**Globalization**](https://msdn.microsoft.com/library/windows/apps/br206813)</li>
<li>[**Globalization.NumberFormatting**](https://msdn.microsoft.com/library/windows/apps/br226136)</li>
<li>[**Globalization.DateTimeFormatting**](https://msdn.microsoft.com/library/windows/apps/br206859)</li>
<li>[**Resources**](https://msdn.microsoft.com/library/windows/apps/br206022)</li>
<li>[**Resources.Core**](https://msdn.microsoft.com/library/windows/apps/br225039)</li>
</ul>
</div>



## <a name="globalization"></a>グローバリゼーション

グローバル化に適した UI の用語と画像が選択され、[**Globalization**](https://msdn.microsoft.com/library/windows/apps/br206813) API を使ってアプリ データがフォーマットされ、場所や言語に基づく前提のない、異なる市場に簡単に適応できるアプリを準備します。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">推奨事項</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>数値、日付、時刻、住所、電話番号には正しい形式を使う。</p></td>
<td align="left"><p>数値、日付、時刻などのデータに使われる形式は、カルチャ、地域、言語、市場により異なります。 数値、日付、時刻、またはその他のデータを表示している場合は、[<strong>グローバリゼーション</strong>](https://msdn.microsoft.com/library/windows/apps/br206813) API を使用して、特定のユーザーに適した形式を取得します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>国際的な用紙サイズをサポートする。</p></td>
<td align="left"><p>最も一般的な用紙サイズは国によって異なるため、用紙サイズによって変化する機能 (印刷など) を含める場合には、必ず一般的な国際サイズをサポートし、テストしてください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>国際的な計測単位と通貨をサポートする。</p></td>
<td align="left"><p>使われる単位と尺度は国によって異なりますが、最も使われているのはメートル法とヤード ポンド法です。 長さ、温度、範囲などの計測を扱う場合は、[<strong>CurrenciesInUse</strong>](https://msdn.microsoft.com/library/windows/apps/br206793) プロパティを使用して、正しいシステム計測を取得します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>テキストとフォントを正しく表示する。</p></td>
<td align="left"><p>テキストに適したフォント、フォント サイズ、方向は、市場によって異なります。</p>
<p>詳細については、「[<strong>レイアウトとフォントを調整し、RTL をサポートする</strong>](adjust-layout-and-fonts--and-support-rtl.md)」をご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>文字エンコードに Unicode を使う。</p></td>
<td align="left"><p>既定では、最近のバージョンの Microsoft Visual Studio は、すべてのドキュメントに Unicode 文字エンコードを使います。 別のエディターを使っている場合は、適切な Unicode 文字エンコードでソース ファイルが保存されるようにしてください。 Windows ランタイム API はどれも、UTF-16 エンコードの文字列を返します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>入力の言語を記録する。</p></td>
<td align="left"><p>アプリがユーザーにテキスト入力を求めるときに、入力の言語が記録されるようにします。 こうすると、その入力が後で表示されるときに適切な書式設定でユーザーに提示されます。 [<strong>CurrentInputMethodLanguage</strong>](https://msdn.microsoft.com/library/windows/apps/hh700658) プロパティを使用して、現在の入力言語を取得します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>言語からユーザーの位置を想定する、または位置からユーザーの言語を想定することはしない。</p></td>
<td align="left"><p>Windows では、ユーザーの言語と位置は別の概念です。 特定の地理的な言語バリアント (en-gb (英国で話される英語) など) を話しても、住んでいる国または地域はまったく異なる場合があります。 UI テキストなどのためにアプリがユーザーの言語について認識する必要があるか、ライセンス問題などのためにアプリがユーザーの位置について認識する必要があるかを検討してください。</p>
<p>詳細については、「[<strong>言語と地域を管理する</strong>](manage-language-and-region.md)」をご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left"><p>俗語や比喩を使わない。</p></td>
<td align="left"><p>一部のカルチャや年齢などの集団にしか伝わらない言葉は、その集団の人しか使わないので、理解や翻訳が難しい場合があります。 同様に、比喩も人によって伝わったり伝わらなかったりします。 たとえば、&quot;ブルーバード&quot; はスキーをする人には伝わりますが、スキーをしない人には伝わりません。 アプリをローカライズしてくだけた表現を使うことを計画している場合は、ローカライズ担当者に翻訳対象の意味と口調を十分に説明してください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>専門的な用語、省略形、略語を使わない。</p></td>
<td align="left"><p>専門用語は、専門知識のないユーザーや他のカルチャまたは地域の人々には意図が伝わりにくく、翻訳も困難です。 このような言葉は日常会話では使われません。 専門用語は、ハードウェアとソフトウェアの問題を特定するため、エラー メッセージ内でよく使われます。 専門用語が必要な場合があるかもしれませんが、普通の言葉に置き換えることが望まれます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>不快感を与えかねない画像を使わない。</p></td>
<td align="left"><p>自分が所属するカルチャでは妥当な画像でも、別のカルチャでは不快感を与えたり、誤って解釈されたりすることがあります。 宗教的なシンボル、動物、国旗や政治運動に関連付けられる色の組み合わせなどは避けてください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>地図や、地域についての言及では、政治的侵害を避ける。</p></td>
<td align="left"><p>地図には論争の的になっている地域や国境が含まれている可能性があり、それらはしばしば政治的な侵害のきっかけになります。 国家の選択に使う UI は、必ず &quot;国/地域&quot; という名称にしてください。 (住所フォームなどで) &quot;国&quot; という名称の一覧に領有権未決の領域を含めると、トラブルになりかねません。</p></td>
</tr>
<tr class="even">
<td align="left"><p>言語タグを比較する目的で文字列比較を単独で使わない。</p></td>
<td align="left"><p>BCP-47 言語タグは複雑です。 言語タグの比較では、スクリプト情報、前のタグ、複数の地域バリアントの対応付けに伴う問題など、多数の問題が発生します。 Windows のリソース管理システムでは、対応付けが自動的に行われます。 開発者はどの言語で作られたリソース セットでも指定でき、システムがユーザーとアプリのために適切なものを選びます。</p>
<p>リソース管理の詳細については、「[<strong>アプリ リソースの定義</strong>](https://msdn.microsoft.com/library/windows/apps/xaml/hh965321)」をご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>並べ替えが常にアルファベット順で行われると想定しない。</p></td>
<td align="left"><p>ラテン文字を使わない言語の場合、並べ替えは発音、ペン ストロークの数などの要素に基づいて行われます。 ラテン文字を使う言語でも、常にアルファベット順の並べ替えを行うわけではありません。 たとえば、一部のカルチャでは電話帳はアルファベット順では並んでいない場合があります。 システムによって並べ替えが自動的に行われますが、自分で独自の並べ替えアルゴリズムを作る場合は、必ず、アプリの対象市場で使われている並べ替え方法を考慮してください。</p></td>
</tr>
</tbody>
</table>

 

## <a name="localization"></a>ローカライズ

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">推奨事項</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>UI 文字列や画像などのリソースをコードから分離する。</p></td>
<td align="left"><p>アプリは、文字列や画像などのリソースがコードから分離されるように設計してください。 こうすることで、さまざまなスケール ファクター、アクセシビリティ オプション、ユーザーとコンピューターに関する多くのコンテキストに対して、それらの保守、ローカライズ、カスタマイズを個別に行うことができます。</p>
<p>文字列リソースはアプリのコードから分離し、言語に依存しない単一のコードベースを作ってください。 文字列は、常にアプリのコードやマークアップから分離し、リソース ファイル (ResW や ResJSON ファイルなど) に入れてください。</p>
<p>Windows のリソース インフラストラクチャを使って、ユーザーの実行時環境に最適なリソースが選ばれるように処理してください。</p></td>
</tr>
<tr class="even">
<td align="left"><p>他のローカライズ可能なリソース ファイルを分離する。</p></td>
<td align="left"><p>ローカライズが必要な他のファイル (翻訳するテキストを含んだ画像やカルチャ上の配慮のために変更が必要な画像など) は、言語名でタグ化されたフォルダーに入れてください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>既定の言語を設定し、既定の言語で作られているものも含め、すべてのリソースをマークする。</p></td>
<td align="left"><p>常に、アプリ マニフェスト (package.appxmanifest) で、アプリの既定の言語を適切に設定します。 アプリでサポートされる言語のどれもユーザーが話さない場合、使われる言語は既定の言語によって決定されます。 既定の言語リソースをその言語でマークしてください (例: en-us/Logo.png)。こうすることで、システムはリソースで使われている言語と、個々の状況でそのリソースがどのように使われるかを判断できます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>ローカライズが必要なアプリ リソースを特定する。</p></td>
<td align="left"><p>他の市場向けにアプリをローカライズすることになった場合には、何を変更する必要があるでしょうか。 テキスト文字列を他の言語に翻訳する必要があります。 他のカルチャに合わせて画像を変更する必要がある場合もあります。 アプリが使う他のリソース (オーディオやビデオなど) にローカライズがどのような影響を与えるかを考慮してください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>リソースを参照するには、コードとマークアップでリソース識別子を使ってください。</p></td>
<td align="left"><p>文字列リテラル、または画像の特定のファイル名をマークアップに含めるのではなく、リソースの参照を利用してください。 必ず、リソースごとに一意の識別子を使ってください。 詳細については、「[<strong>修飾子を使用してリソースに名前をつける方法</strong>](https://msdn.microsoft.com/library/windows/apps/xaml/Hh965324)」をご覧ください。</p>
<p>システムが変更されて、異なるセットの修飾子の使用が始まるときに発生するイベントをリッスンします。 正しいリソースが読み込まれるようにドキュメントを再処理します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>テキスト サイズを拡大できるようにする。</p></td>
<td align="left"><p>翻訳されるとテキスト サイズが大きくなる可能性があるため、テキスト バッファーは動的に割り当ててください。 静的なバッファーを使う必要がある場合は、(英語文字列の長さを倍にするなどの方法で) それらを特大サイズにし、文字列が翻訳された時点で起きる可能性がある拡大に対応してください。 ユーザー インターフェイスに利用可能な領域が制限されることもあります。 ローカライズされた言語に対応するには、文字列の長さが、日本語に必要となりそうな長さよりも約 40% 長くします。 単一の語句のように非常に短い文字列の場合、必要領域が約 300% も増える可能性があります。 さらに、コントロール内で複数行のサポートとテキストの折り返しを有効にすると、各文字列を表示するための領域を増やすことができます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>左右反転をサポートする。</p></td>
<td align="left"><p>テキストの配置と読み取りは、英語のように左から右の順にも、アラビア語やヘブライ語のように右から左の順 (RTL) にも行うことができます。 読み取り順が自国語とは異なる言語に製品をローカライズする場合は、UI 要素のレイアウトが左右反転をサポートする必要があります。 戻るボタン、UI 切り替え効果、画像などのアイテムですら、左右反転が必要になることがあります。</p>
<p>詳細については、「[<strong>レイアウトとフォントを調整し、RTL をサポートする</strong>](adjust-layout-and-fonts--and-support-rtl.md)」をご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left"><p>文字列にコメントする。</p></td>
<td align="left"><p>文字列に適切にコメントを入れ、翻訳が必要な文字列だけをローカライズ担当者に提供してください。 過剰なローカライズは、よく問題を引き起こします。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>短い文字列を使う。</p></td>
<td align="left"><p>文字列を短くすると翻訳が簡単になり、翻訳データを再使用できます。 翻訳データを再使用すると、同じ文字列はローカライズ担当者に再び送られることがないため、コストを節約できます。</p>
<p>8,192 文字を超える文字列は、一部のローカライズ ツールではサポートされない可能性があります。このため、文字列は 4,000 文字以内に抑えてください。</p></td>
</tr>
<tr class="even">
<td align="left"><p>文全体が入った文字列を提供する。</p></td>
<td align="left"><p>単語の訳は文におけるその位置によって変化する可能性があるため、文を個々の単語に分割せず、文全体が入った文字列を提供してください。 1 つのフレーズが複数のパラメーターから構成される場合、どの言語でもパラメーターの順序は変わらないと想定してはなりません。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>画像ファイルとオーディオ ファイルをローカライズ用に最適化する。</p></td>
<td align="left"><p>画像内にテキストを入れることやオーディオ ファイルに音声を入れることを避けると、ローカライズ コストが抑えられます。 読み取り順が自国語とは異なる言語にローカライズする場合は、左右対称の画像や効果を使うと左右反転をサポートしやすくなります。</p></td>
</tr>
<tr class="even">
<td align="left"><p>文字列は異なるコンテキストで再使用しない。</p></td>
<td align="left"><p>文字列は異なるコンテキストで再使用してはなりません。&quot;オン&quot; や &quot;オフ&quot; などの簡単な語句でも、コンテキストに基づいて別の翻訳がなされる可能性があります。</p></td>
</tr>
</tbody>
</table>

 

## <a name="related-articles"></a>関連記事


**サンプル**
* [アプリ リソースとローカライズのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=254478)
* [グローバリゼーション設定サンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231608)
 

 




