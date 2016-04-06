---
Description: どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。 たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコンテンツ デザインの基本
ms.assetid: 3102530A-E0D1-4C55-AEFF-99443D39D567
label: コンテンツ デザインの基本
template: detail.hbs
---

#  UWP アプリのコンテンツ デザインの基本


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。 ナビゲーション要素はコンテンツへのアクセスを提供します。コマンド要素はユーザーがコンテンツを操作できるようにし、コンテンツ要素は実際のコンテンツを表示します。

この記事では、3 つのコンテンツ シナリオでのコンテンツの設計に関する推奨事項を示します。

## <span id="Design_for_the_right_content_scenario"></span><span id="design_for_the_right_content_scenario"></span><span id="DESIGN_FOR_THE_RIGHT_CONTENT_SCENARIO"></span>適切なコンテンツ シナリオの設計


次の 3 つの主要なコンテンツ シナリオがあります。

-   **使用**: コンテンツを使用する、主に一方向のエクスペリエンス。 使用は、読む、音楽を聴く、ビデオを見る、写真や画像を表示するなどのタスクです。
-   **作成**: 新しいコンテンツの作成が焦点となる、主に一方向のエクスペリエンス。 作成は、写真やビデオの撮影のように何かをゼロから作る、描画アプリで新しい画像を作る、新しいドキュメントを開くなどに分かれます。
-   **対話型**: コンテンツの使用、作成、修正を含む、2 方向のコンテンツ エクスペリエンス。

## <span id="Consumption-focused_apps"></span><span id="consumption-focused_apps"></span><span id="CONSUMPTION-FOCUSED_APPS"></span>使用に重点を置いたアプリ


使用に重点を置いたアプリでは、コンテンツ要素の優先順位が最も高く、ユーザーが目的のコンテンツを探すために必要な [ナビゲーション要素](navigation-basics.md) が次に続きます。 使用に重点を置いたアプリの例として、ムービー プレーヤー、読書アプリ、音楽アプリ、フォト ビューアーなどがあります。

![ニュースリーダー アプリ](images/news-reader/v2/newsreader-v2-tablet-phone.png)

使用に重点を置いたアプリに関する一般的な推奨事項:

-   専用の [ナビゲーション](navigation-basics.md) ページとコンテンツ表示ページを作成し、ユーザーが探していたコンテンツを見つけたときに、無駄な情報がない専用のページでそのコンテンツを表示できるようにすることを検討します。
-   コンテンツを画面全体に拡張し、その他のすべての UI 要素を非表示にする、全画面表示のオプションを作成することを検討します。

## <span id="Creation-focused_apps"></span><span id="creation-focused_apps"></span><span id="CREATION-FOCUSED_APPS"></span>作成に重点を置いたアプリ


コンテンツと [コマンド](commanding-basics.md) 要素は、作成に重点を置いたアプリでは最も重要な UI 要素です。コマンド要素により、ユーザーは新しいコンテンツを作成することができます。 この例には、ペイント アプリ、写真編集アプリ、ビデオ編集アプリ、ワード プロセッシング アプリがあります。

例として、コマンド バーを使ってツールや写真操作オプションにアクセスできるようにするフォト アプリのデザインを以下に示します。 すべてのコマンドがコマンド バーにあるため、アプリは画面のスペースのほとんどをそのコンテンツ (編集する写真) に充てることができます。

![アクティブなキャンバスを使った写真編集アプリの設計例](images/photo-editor/uap-photo-tabletphone-sbs.png)

作成に重点を置いたアプリに関する一般的な推奨事項:

-   [ナビゲーション](navigation-basics.md) 要素の使用を最小限に抑えます。
-   [コマンド](commanding-basics.md) 要素は、作成に重点を置いたアプリで特に重要です。 ユーザーは多くのコマンドを実行するため、コマンド履歴/元に戻す機能を提供することをお勧めします。

## <span id="Apps_with_interactive_content"></span><span id="apps_with_interactive_content"></span><span id="APPS_WITH_INTERACTIVE_CONTENT"></span>対話型コンテンツを含むアプリ


対話型コンテンツを含むアプリでは、ユーザーはコンテンツを作成、表示、編集します。多くのアプリはこのカテゴリに分類されます。 これらの種類のアプリの例には、基幹業務アプリ、在庫管理アプリ、ユーザーがレシピを作成または変更できる料理のアプリなどがあります。

![コラボレーション ツールの設計、対話型コンテンツを含むアプリ](images/collaboration-tool/uap-collaboration-tabphone-700.png)

これらの種類のアプリでは、次の 3 つすべての UI 要素のバランスを取る必要があります。

-   [ナビゲーション](navigation-basics.md) 要素を使用すると、ユーザーがコンテンツを見つけて表示しやすくなります。 コンテンツの表示と検索が最も重要なシナリオである場合は、ナビゲーション要素、フィルター処理と並べ替え、検索を優先します。
-   [コマンド](commanding-basics.md) 要素により、ユーザーはコンテンツを作成、編集、操作することができます。

対話型コンテンツを使ったアプリに関する一般的な推奨事項:

-   3 つすべてが重要であるときに、ナビゲーション、コンテンツ、およびコマンド要素のバランスを取ることは困難である場合があります。 可能であれば、コンテンツの閲覧、作成、編集用の別の画面を作成するか、モード スイッチを提供することを検討します。

## <span id="Commonly_used_content_elements"></span><span id="commonly_used_content_elements"></span><span id="COMMONLY_USED_CONTENT_ELEMENTS"></span>よく使われるコンテンツ要素


コンテンツの表示によく使われるいくつかの UI 要素を次に示します。 UI 要素の全一覧については、「[コントロールと UI 要素](https://msdn.microsoft.com/library/windows/apps/dn611856)」をご覧ください。

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">カテゴリ</th>
<th align="left">要素</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">オーディオとビデオ</td>
<td align="left">[Media playback and transport controls](../controls-and-patterns/media-playback.md)</td>
<td align="left">オーディオとビデオを再生します。</td>
</tr>
<tr class="even">
<td align="left">画像ビューアー</td>
<td align="left">[Flip view](../controls-and-patterns/flipview.md)、[image](../controls-and-patterns/images-imagebrushes.md)</td>
<td align="left">画像を表示します。 FlipView は、コレクション内の画像 (アルバム内の写真や製品の詳細ページ内の項目など) を一度に 1 つずつ表示します。</td>
</tr>
<tr class="odd">
<td align="left">リスト</td>
<td align="left">[drop-down list, list box, list view and grid view](../controls-and-patterns/lists.md)</td>
<td align="left">対話型のリストまたはグリッド内に項目を表示します。 これらの要素を使うと、ユーザーは新着の一覧からムービーを選んだり、在庫を管理したりすることができます。</td>
</tr>
<tr class="even">
<td align="left">テキストとテキスト入力</td>
<td align="left"><p>[Text block](../controls-and-patterns/text-block.md)、[text box](../controls-and-patterns/text-box.md)、[rich edit box](../controls-and-patterns/rich-edit-box.md)</p>
</td>
<td align="left">テキストを表示します。 一部の要素を使うと、ユーザーがテキストを編集することができます。 詳しくは、「[Text controls](../controls-and-patterns/text-controls.md)」をご覧ください。</td>
</tr>
</tbody>
</table>

 

\[この記事には、ユニバーサル Windows プラットフォーム (UWP) アプリと Windows 10 に固有の情報が含まれています。 Windows 8.1 のガイダンスについては、[Windows 8.1 ガイドラインの PDF](https://go.microsoft.com/fwlink/p/?linkid=258743) ファイルをダウンロードしてください。\]

 

 






<!--HONumber=Mar16_HO1-->


