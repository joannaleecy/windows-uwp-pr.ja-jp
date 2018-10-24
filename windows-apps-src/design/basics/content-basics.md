---
author: mijacobs
Description: An overview of common page patterns and UI elements for displaying content in your UWP app.
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコンテンツ デザインの基本
ms.assetid: 3102530A-E0D1-4C55-AEFF-99443D39D567
label: Content design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 12/1/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 91187b176d32fcc53b51faa7e8c42a10fd4908b8
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5439663"
---
# <a name="content-design-basics-for-uwp-apps"></a>UWP アプリのコンテンツ デザインの基本

どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。 アプリはさまざまな目的で存在するため、コンテンツにも多くの形式があります。たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。 

この記事では、アプリでコンテンツを表示する方法の概要を説明します。 形式にかかわらずコンテンツを表示するために使用できる、一般的なページ パターンと UI 要素について説明します。

## <a name="common-page-patterns"></a>一般的なページ パターン

多くのアプリは、これらの一般的なページ パターンの一部またはすべてを使用して、さまざまな種類のコンテンツを表示します。 また、これらのパターンを自由に組み合わせて、アプリのコンテンツを最適化します。

### <a name="landing"></a>ランディング

![ランディング ページ](images/content-basics/hero-screen.png)

通常、ランディング ページ (ヒーロー画面とも呼ばれる) は、アプリのエクスペリエンスのトップ レベルに表示されます。 大きいサーフェス領域は、ユーザーが参照および使用する可能性があるコンテンツを、アプリが強調表示するためのステージとして機能します。

### <a name="collections"></a>コレクション

![ギャラリー](images/content-basics/gridview.png)

コレクションを使用すると、ユーザーはコンテンツやデータのグループを参照することができます。 [グリッド ビュー](../controls-and-patterns/item-templates-gridview.md)は写真またはメディアを中心とするコンテンツに適していて、[リスト ビュー](../controls-and-patterns/item-templates-listview.md)はテキストが多いコンテンツやデータに適しています。

### <a name="hub"></a>ハブ

![ハブ](images/content-basics/hub.png)

[ハブ](../controls-and-patterns/hub.md)はウィンドウ ショッピング向けに設計されています。 ユーザーは提供されるコンテンツの一部を見ることができます。量を少なくして、多様なコンテンツが表示されます。 たとえば、ハブ セクション 1 にはヒーロー画面、ハブ セクション 2 にはコレクション、ハブ セクション 3 には別のコレクションを含めることができます。

### <a name="masterdetail"></a>マスター/詳細

![マスター/詳細](images/content-basics/master-detail.png)

[マスター/詳細](../controls-and-patterns/master-details.md)モデルは、リスト ビュー (マスター) とコンテンツ ビュー (詳細) で構成されます。 両方のウィンドウは固定されていて、垂直方向にスクロールできます。 リスト項目とコンテンツ ビューの間には明確な関係があります。マスター ビューで項目が選択されると、詳細ビューがそれに応じて更新されます。 詳細ビューのナビゲーションが提供されるだけでなく、マスター ビュー内の項目を追加および削除することができます。

### <a name="details"></a>詳細

![複数のビュー](images/multi-view.png)

ユーザーが探していたコンテンツを見つけたときに、無駄な情報がないページを表示できるように、専用のコンテンツ表示ページを作成することを検討します。 可能であれば、コンテンツを画面全体に拡張し、他のすべての UI 要素を非表示にする、[全画面表示のオプションを作成](../layout/show-multiple-views.md)します。 

画面サイズの変化を調整するために、必要に応じて UI 要素の表示/非表示を切り替える[レスポンシブ デザイン](design-and-ui-intro.md)の作成も検討します。

### <a name="forms"></a>フォーム
![フォーム](images/content-basics/forms.png)

[フォーム](../controls-and-patterns/forms.md)は、ユーザーからデータを収集して送信するコントロールのグループです。 すべてではなくても、ほとんどのアプリが、設定ページ、ログイン ポータル、フィードバック Hub、アカウントの作成などのために、何らかのフォームを使用しています。 

## <a name="common-content-elements"></a>一般的なコンテンツ要素

これらのページ パターンを作成するには、個々のコンテンツ要素を組み合わせて使用する必要があります。 コンテンツの表示によく使われるいくつかの UI 要素を次に示します。 UI 要素の全一覧については、「[コントロールとパターン](../controls-and-patterns/index.md)」をご覧ください。

<div class="mx-responsive-img">
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
<td align="left">オーディオとビデオ<br/><br/>
    <img src="images/content-basics/media-transport.png" alt="media transport control" /></td>
<td align="left"><a href="../controls-and-patterns/media-playback.md">メディア再生コントロールとメディア トランスポート コントロール</a></td>
<td align="left">オーディオとビデオを再生します。</td>
</tr>
<tr class="even">
<td align="left">画像ビューアー<br/><br/>
    <img src="images/content-basics/flipview.jpg" alt="flip view" /></td>
<td align="left"><a href="../controls-and-patterns/flipview.md">フリップ ビュー</a>、<a href="../controls-and-patterns/images-imagebrushes.md">画像</a></td>
<td align="left">画像を表示します。 FlipView は、コレクション内の画像 (アルバム内の写真や製品の詳細ページ内の項目など) を一度に 1 つずつ表示します。</td>
</tr>
<tr class="odd">
<td align="left">コレクション <br/><br/>
    <img src="images/content-basics/listview.png" alt="list view" /></td>
<td align="left"><a href="../controls-and-patterns/lists.md">リスト ビューとグリッド ビュー</a></td>
<td align="left">対話型のリストまたはグリッド内に項目を表示します。 これらの要素を使うと、ユーザーは新着の一覧からムービーを選んだり、在庫を管理したりすることができます。</td>
</tr>
<tr class="even">
<td align="left">テキストとテキスト入力 <br/><br/>
    <img src="images/content-basics/textbox.png" alt="text box" /></td>
<td align="left"><p><a href="../controls-and-patterns/text-block.md">テキスト ブロック</a>、<a href="../controls-and-patterns/text-box.md">テキスト ボックス</a>、<a href="../controls-and-patterns/rich-edit-box.md">リッチ エディット ボックス</a></p>
</td>
<td align="left">テキストを表示します。 一部の要素を使うと、ユーザーがテキストを編集することができます。 詳しくは、「<a href="../controls-and-patterns/text-controls.md">テキスト コントロール</a>」をご覧ください。
<p>テキストの表示方法のガイドラインについては、「[文字体裁](../style/typography.md)」をご覧ください。</p>
</td>
</tr>
<tr class="odd">
<td align="left">マップ<br/><br/>
    <img src="images/content-basics/mapcontrol.png" alt="map control" /></td>
<td align="left"><a href="../../maps-and-location/display-maps.md">MapControl</a></td>
<td align="left">シンボリックまたは写実的な地球のマップを表示します。</td>
</tr>
<tr class="even">
<td align="left">WebView</td>
<td align="left"><a href="../controls-and-patterns/web-view.md">WebView</a></td>
<td align="left">HTML コンテンツをレンダリングします。</td>
</tr>
</tbody>
</table>
</div>
