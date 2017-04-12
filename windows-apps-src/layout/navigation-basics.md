---
author: mijacobs
Description: "ユニバーサル Windows プラットフォーム (UWP) アプリのナビゲーションは、ナビゲーション構造、ナビゲーション要素、システム レベルの機能から成る柔軟なモデルに基づいています。"
title: "UWP アプリのナビゲーション デザインの基本 (Windows アプリ)"
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 6397949c4c763db9d406790a6ffcb7f8ad94b7aa
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
#  <a name="navigation-design-basics-for-uwp-apps"></a>UWP アプリのナビゲーション デザインの基本

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

ユニバーサル Windows プラットフォーム (UWP) アプリのナビゲーションは、ナビゲーション構造、ナビゲーション要素、システム レベルの機能から成る柔軟なモデルに基づいています。 これら全体で、アプリ、ページ、コンテンツ間での移動の際にさまざまな直感的なユーザー エクスペリエンスを実現します。

場合によっては、アプリのコンテンツと機能のすべてを単一ページに配置して、ユーザーがパンするだけでそのコンテンツ内を移動できるようにすることができます。 ただし、ほとんどのアプリは通常、複数ページのコンテンツと、それをユーザーが利用するための機能を備えています。 アプリに複数のページがある場合は、適切なナビゲーション エクスペリエンスを提供する必要があります。

UWP アプリにおいて効果的で便利なマルチページ ナビゲーション エクスペリエンスを実現するには、以下の要素が必要です (詳細は後述)。

-   **適切なナビゲーション構造**

    直感的なナビゲーション エクスペリエンスを作成するためには、ユーザーにとってわかりやすいナビゲーション構造を構築することが重要です。

-   **互換性のあるナビゲーション要素** (選択した構造をサポートする要素)

    ナビゲーション要素を使うと、ユーザーは必要なコンテンツにアクセスすることができ、アプリ内のどの位置にいるかを把握することもできます。 ただし、ナビゲーション要素は、コンテンツやコマンド実行要素用に使うことができる領域を占有します。そのため、アプリの構造に最適なナビゲーション要素を使うことが重要になります。

-   **システム レベルのナビゲーション機能 ("戻る" など) に対する適切な応答**

    直感的な操作性を感じさせる一貫したエクスペリエンスを実現するには、予測可能な方法で、システム レベルのナビゲーション機能に応答します。

## <a name="build-the-right-navigation-structure"></a>適切なナビゲーション構造を構築する


ページのグループから構成されるコレクションとしてアプリを見てみましょう。各ページには、コンテンツや機能の固有のセットが含まれます。 たとえば、写真アプリには、写真を撮影するためのページ、画像を編集するためのページ、画像ライブラリを管理するためのページが含まれている場合があります。 これらのページをグループに配置する方法によって、アプリのナビゲーション構造が定義されます。 ページのグループを配置する一般的な方法には、次の 2 つがあります。

<table class="uwpd-noborder uwpd-top-aligned-table">
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">階層に配置する</th>
<th align="left">ピアとして配置する</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="text-align: center;"><p><img src="images/nav/nav-pages-hiearchy.png" alt="Pages arranged in a hierarchy" /></p></td>
<td style="text-align: center;"><p><img src="images/nav/nav-pages-peer.png" alt="Pages arranged as peers" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align: top">ページは、ツリー状の構造に配置されます。 それぞれの子ページの親は 1 つだけですが、親ページは 1 つ以上の子ページを持つことができます。 子ページにアクセスするには、親ページを経由します。 </td>
<td style="vertical-align: top"> ページは、並列の関係で配置されます。 どのような順序でもページ間を移動できます。 </td>
</tr>
</tbody>
</table>

 

一般的なアプリでは両方の配置方法を使います。たとえば、一部のページはピアとして配置され、他のページは階層に配置されます。

![ハイブリッド構造のアプリ](images/nav/nav-hybridstructure.png.png)

では、どのような場合にページを階層に配置し、どのような場合にページをピアとして配置すればよいでしょうか。 この質問に答えるには、グループ内のページ数、特定の順序でページ間を移動する必要があるかどうか、およびページ間の関係を考慮する必要があります。 一般に、構造がフラットであれば、構造を理解しやすくなり、すばやい移動が可能になります。ただし、深い階層が適している場合もあります。



<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">次の場合は、階層関係を使うことをお勧めします。
<ul>
<li>ユーザーが特定の順序でページ間を移動する必要がある場合。 その順序を強制的に適用するように階層を配置します。</li>
<li>グループ内の各ページ間には明確な親子関係がある場合。</li>
<li>グループ内のページ数が 7 ページを超える場合。
<p>グループ内のページ数が 7 ページを超える場合、ページが一意であるかどうかを判断したり、グループ内の現在の位置を把握したりするのが難しくなる場合があります。 このことがアプリでは問題にはならないと考えられる場合は、ページをピアとして作成します。 このことが問題となる可能性がある場合は、階層構造を使って、ページを 2 つ以上の小さなグループに分割することを検討してください  (ハブ コントロールを使うと、ページをカテゴリにグループ化できます)。</p></li>
</ul>
  </div>
  <div class="side-by-side-content-right">次の場合は、ピアの関係を使うことをお勧めします。
<ul>
<li>ページをどのような順序でも表示できる場合。</li>
<li>各ページはそれぞれ異なるページであり、明確な親/子関係はありません。</li>
<li><p>グループ内のページ数が 8 ページよりも少ない場合。</p>
<p>グループ内のページ数が 7 ページを超える場合、ページが一意であるかどうかを判断したり、グループ内の現在の位置を把握したりするのが難しくなる場合があります。 このことがアプリでは問題にはならないと考えられる場合は、ページをピアとして作成します。 このことが問題となる可能性がある場合は、階層構造を使って、ページを 2 つ以上の小さなグループに分割することを検討してください  (ハブ コントロールを使うと、ページをカテゴリにグループ化できます)。</p></li>
</ul>
  </div>
</div>
</div>
 

## <a name="use-the-right-navigation-elements"></a>適切なナビゲーション要素の使用


ナビゲーション要素は 2 つのサービスを提供できます。つまり、これらの要素を使うと、ユーザーは必要なコンテンツにアクセスすることができ、要素によっては、アプリ内のどの位置にいるかを把握することができます。 ただし、ナビゲーション要素は、コンテンツやコマンド実行要素用にアプリで使うことができる領域を占有します。そのため、アプリの構造に最適なナビゲーション要素を使うことが重要になります。

### <a name="peer-to-peer-navigation-elements"></a>ピア ツー ピアのナビゲーション要素

ピア ツー ピアのナビゲーション要素によって、同じサブツリーの同じレベルにあるページ間のナビゲーションが有効になります。

![ピア ツー ピアのナビゲーション](images/nav/nav-lateralmovement.png)

ピア ツー ピアのナビゲーションでは、タブまたはナビゲーション ウィンドウを使うことをお勧めします。

<table>
<thead>
<tr class="header">
<th align="left">ナビゲーション要素</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;">[タブとピボット](../controls-and-patterns/tabs-pivot.md)
<p><img src="images/nav/nav-tabs-sm-300.png" alt="Tab-based navigation" /></p></td>
<td style="vertical-align:top;">同じレベルにあるページへのリンクの永続的な一覧を表示します。
<p>タブ/ピボットを使う場合</p>
<ul>
<li><p>ページ数が 2 ～ 5 ページの場合</p>
<p>5 ページを超える場合でもタブ/ピボットを使うことはできますが、すべてのタブ/ピボットを画面に収めることが難しくなることがあります。</p></li>
<li>ユーザーが頻繁にページ間を切り替えることを前提としている場合。</li>
</ul>
<p>このレストラン検索アプリの設計では、タブ/ピボットを使っています。</p>
<p><img src="images/food-truck-finder/uap-foodtruck-tabletphone-sbs-sm-400.png" alt="Example of an app using tabs/pivots pattern" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;">[ナビゲーション ウィンドウ](../controls-and-patterns/nav-pane.md)
<p><img src="images/nav/nav-navpane-4page-thumb.png" alt="A navigation pane" /></p></td>
<td style="vertical-align:top;">トップレベルのページへのリンクの一覧を表示します。
<p>ナビゲーション ウィンドウを使う場合</p>
<ul>
<li>ユーザーが頻繁にページ間を切り替えることを前提としていない場合。</li>
<li>ナビゲーション操作の速度を低下させて、領域を節約する必要がある場合。</li>
<li>ページがトップレベルに存在する場合。</li>
</ul>
<p>このスマート ホーム アプリ機能の設計では、ナビゲーション ウィンドウを使っています。</p>
<p><img src="images/smart-home/uap-smarthome-tabletphone-sbs-sm-400.png" alt="Example of an app that uses a nav pane pattern" /></p>
<p></p></td>
</tr>
</tbody>
</table>

 

ナビゲーション構造に複数のレベルがある場合は、現在のサブツリー内のピアにのみリンクするピア ツー ピアのナビゲーション要素を使うことをお勧めします。 3 つのレベルを持つナビゲーション構造を示す、次の図について考えてみましょう。

![2 つのサブツリーを含むアプリ](images/nav/nav-subtrees.png)
-   レベル 1 では、ピア ツー ピアのナビゲーション要素によって、ページ A、B、C、および D へのアクセスが提供されます。
-   レベル 2 では、A2 ページのピア ツー ピアのナビゲーション要素は、他の A2 ページにのみリンクしています。 これらのナビゲーション要素は、C サブツリー内にあるレベル 2 のページにはリンクしていません。

![2 つのサブツリーを含むアプリ](images/nav/nav-subtrees2.png)

### <a name="hierarchical-navigation-elements"></a>階層型ナビゲーション要素

階層型ナビゲーション要素は、親ページとその子ページ間のナビゲーションを実現します。

![階層型ナビゲーション](images/nav/nav-verticalmovement.png)

<table>
<thead>
<tr class="header">
<th align="left">ナビゲーション要素</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;">[ハブ](../controls-and-patterns/hub.md)
<p><img src="images/higsecone-hub-thumb.png" alt="Hub" /></p></td>
<td align="left">ハブは、子ページのプレビュー/概要を提供する特殊な種類のナビゲーション コントロールです。 ナビゲーション ウィンドウやタブとは異なり、ページ自体に埋め込まれているリンクやセクション ヘッダーを使って、子ページへのナビゲーションを実現します。
<p>ハブを使う場合</p>
<ul>
<li>ユーザーが、各子ページへ移動せずに、子ページのコンテンツの一部を表示することを前提としている場合。</li>
</ul>
<p>ハブでは検出や調査がサポートされるため、メディア、ニュース リーダー、ショッピング アプリに適しています。</p>
<p></p></td>
</tr>

<tr class="even">
<td style="vertical-align:top;">[マスター/詳細](../controls-and-patterns/master-details.md)
<p><img src="images/higsecone-masterdetail-thumb.png" alt="Master/details" /></p></td>
<td align="left">項目の概要の一覧 (マスター ビュー) が表示されます。 項目を選ぶと、対応する項目ページが詳細セクションに表示されます。
<p>マスター/詳細要素を使う場合</p>
<ul>
<li>ユーザーが頻繁に子項目間を切り替えることを前提としている場合。</li>
<li>ユーザーが個々の項目や項目のグループに対して高いレベルの操作 (削除や並べ替えなど) を実行できるようにする場合、およびユーザーが各項目の詳細情報の表示や更新を実行できるようにする場合。</li>
</ul>
<p>マスター/詳細要素は、メールの受信トレイ、連絡先リスト、データ入力に適しています。</p>
<p>この株式を追跡するアプリの設計では、マスター/詳細パターンを使っています。</p>
<p><img src="images/stock-tracker/uap-finance-tabletphone-sbs-sm.png" alt="Example of a stock trading app that has a master/details pattern" /></p></td>
</tr>
</tbody>
</table>

 

### <a name="historical-navigation-elements"></a>履歴ナビゲーション要素

<table>
<thead>
<tr class="header">
<th align="left">ナビゲーション要素</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;">[戻る](navigation-history-and-backwards-navigation.md)</td>
<td style="vertical-align:top;">ユーザーは、アプリ内のナビゲーション履歴や、デバイスによってはアプリ間を移動できます。 詳しくは、「[ナビゲーション履歴と前に戻る移動](navigation-history-and-backwards-navigation.md)」をご覧ください。</td>
</tr>
</tbody>
</table>

 

### <a name="content-level-navigation-elements"></a>コンテンツ レベルのナビゲーション要素

<table>
<thead>
<tr class="header">
<th align="left">ナビゲーション要素</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;">ハイパーリンクとボタン</td>
<td style="vertical-align:top;">コンテンツに埋め込まれたナビゲーション要素は、ページのコンテンツに表示されます。 他のナビゲーション要素はページのグループやサブツリー全体で一貫性がありますが、それとは異なり、コンテンツに埋め込まれたナビゲーション要素はそれぞれのページに固有のナビゲーション要素です。</td>
</tr>
</tbody>
</table>

 

### <a name="combining-navigation-elements"></a>ナビゲーション要素の連結

ナビゲーション要素を連結してアプリに最適なナビゲーション エクスペリエンスを作成することができます。 たとえば、アプリでトップ レベルのページへのアクセスにはナビゲーション ウィンドウを、第 2 レベルのページへのアクセスにはタブを使用することができます。






 




