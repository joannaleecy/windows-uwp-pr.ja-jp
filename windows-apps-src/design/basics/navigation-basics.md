---
author: serenaz
Description: Navigation in Universal Windows Platform (UWP) apps is based on a flexible model of navigation structures, navigation elements, and system-level features.
title: UWP アプリのナビゲーションの基本
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
op-migration-status: ready
ms.author: sezhen
ms.date: 11/27/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3edb7dc28561b5d316a908df951e3052eafc995b
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1654271"
---
# <a name="navigation-design-basics-for-uwp-apps"></a>UWP アプリのナビゲーション デザインの基本

アプリをページの集まりと考えると、*ナビゲーション*は、ページ間およびページ内を移動する動作を表します。 これはユーザー エクスペリエンスの出発点です。これによって、ユーザーは利用するコンテンツと機能を見つけます。 これは非常に重要ですが、適切な設計が難しい場合もあります。

適切な設計が難しいのは、アプリの設計者には膨大な数の選択肢があるからです。 一連のページを順に移動するようにユーザーに求めることができます。 または、ユーザーが任意のページに直接ジャンプできるメニューを提供することもできます。 または、すべてのコンテンツを 1 つのページに配置し、フィルタリングして表示するメカニズムを提供することも可能です。
 
1 つのナビゲーション デザインですべてのアプリに対応することはできませんが、アプリの適切な設計を判断するための原則やガイドラインがあります。 

<figure class="wdg-figure">
  <img alt="Navigation diagram for an app" src="images/navigation_diagram.png" />
  <figcaption>アプリのナビゲーションの図。</figcaption>
</figure> 

## <a name="principles-of-good-navigation"></a>優れたナビゲーションの原則
優れたナビゲーション デザインの基本原則から始めましょう。 

* 一貫性: ユーザーの期待に応えます。
* シンプルさ: 必要以上のことをしないようにします。
* 明確さ: 明確なパスとオプションを提供します。

### <a name="consistency"></a>一貫性
ナビゲーションは、ユーザーの期待に沿ったものである必要があります。 ユーザーが使い慣れた[標準コントロール](#use-the-right-controls)を使用し、アイコン、場所、スタイルの標準的な規則に従うことで、ナビゲーションがユーザーにとって直感的で予測可能なものになります。

<figure class="wdg-figure">
<img src="images/nav/nav-component-layout.png" alt="Preferred location for navigation elements"/>
  <figcaption>ユーザーは特定の UI 要素が標準の位置にあることを期待します。</figcaption>
</figure> 

### <a name="simplicity"></a>シンプルさ
ナビゲーション項目が少ないほど、ユーザーの意思決定がシンプルになります。 重要な移動先に簡単にアクセスできるようにして、重要度の低い項目を非表示にすることで、ユーザーは目的の場所にすばやく移動できるようになります。

<figure class="wdg-figure">
<img src="images/nav/nav-simple-menus.png" alt="A simple versus a complex menu"/>
  <figcaption> 左側のメニューは項目が少ないため、ユーザーにとって理解しやすく、利用しやすいメニューです。
</figcaption>
</figure> 

### <a name="clarity"></a>明確さ
明確なパスを示すと、ユーザーは論理的なナビゲーションを行うことができます。 ナビゲーション オプションをわかりやすくし、ページ間の関係を明確にすることで、ユーザーが自分の位置を見失うことを防止できます。

<figure class="wdg-figure">
<img src="images/nav/nav-pages.png" alt="Clear paths and destinations"/>
  <figcaption> 移動先にはわかりやすいラベルが付けられているため、ユーザーは自分の位置を知ることができます。
</figcaption>
</figure> 

## <a name="general-recommendations"></a>一般的な推奨事項
一貫性、シンプルさ、明確さという設計原則を念頭に置いて、一般的な推奨事項を作成しましょう。

1. ユーザーのことを考えてください。 アプリ使用時のユーザーの一般的な移動パスを追跡し、ページごとに、ユーザーがそのページを表示している理由と、次にどこに移動しようとしているかを考えてください。 

2. ナビゲーションの深い階層を避けます。 3 レベルを超えるナビゲーションでは、ユーザーは迷ってしまい、深い階層から抜け出せなくなる可能性があります。

3. 「ホッピング」を避けます。 ホッピングとは、関連するコンテンツに移動するために、ユーザーが上のレベルに移動して、それから下のレベルに移動する必要があるナビゲーションを意味します。

## <a name="use-the-right-structure"></a>適切な構造を使う 
ナビゲーションの一般的な原則について説明しました。次に、アプリの構造について考えます。 2 種類の一般的な構造があります。フラット構造と階層構造です。 

### <a name="flatlateral"></a>フラット構造/水平構造
![フラット構造で配置されたページ](images/nav/nav-pages-peer.png)

フラット構造/水平構造では、ページは横方向に存在します。 どのような順序でもページ間を移動できます。 

次のような場合に、フラット構造の使用を推奨します。 
<ul>
<li>ページをどのような順序でも表示できる場合。</li>
<li>各ページはそれぞれ異なるページであり、明確な親/子関係がない場合。</li>
<li>グループ内のページ数が 8 ページよりも少ない場合。<br/>
(ページ数が 8 ページ以上の場合、ページが一意であるかどうかを判断したり、グループ内の現在の位置を把握したりするのが難しくなる場合があります。 このことがアプリでは問題にはならないと考えられる場合は、ページをピアとして作成します。 このことが問題となる可能性がある場合は、階層構造を使って、ページを 2 つ以上の小さなグループに分割することを検討してください。)</li>
</ul>

### <a name="hierarchical"></a>階層構造
![階層構造で配置されたページ](images/nav/nav-pages-hiearchy.png)

階層構造では、ページはツリー状の構造に配置されています。 それぞれの子ページの親は 1 つですが、親ページは 1 つ以上の子ページを持つことができます。 子ページにアクセスするには、親ページを経由します。

階層構造体は、多数のページにわたる複雑なコンテンツを配置する場合に適してします。 欠点は、ナビゲーションのオーバーヘッドが発生することです。階層が深くなると、ページからページへの移動するために、多くのクリックが必要となります。 

次のような場合に、階層構造の使用を推奨します。 
<ul>
<li>特定の順序でページを移動する必要がある場合。</li>
<li>ページ間に明白な親子関係がある場合。</li>
<li>グループ内のページ数が 7 ページを超える場合。</li>
</ul>

### <a name="combining-structures"></a>構造を組み合わせる
![ハイブリッド構造のアプリ](images/nav/nav-hybridstructure.png.png)

1 つの構造のみを選択する必要はありません。優れた設計のアプリの多くは両方を使用しています。 アプリでは、トップレベルのページにはフラット構造を使って、任意の順序で参照できるようにし、複雑な関係のあるページには階層構造を使うことができます。 

ナビゲーション構造に複数のレベルがある場合は、現在のサブツリー内のピアにのみリンクするピア ツー ピアのナビゲーション要素を使うことをお勧めします。 3 つのレベルを持つナビゲーション構造を示す、次の図について考えてみましょう。

![2 つのサブツリーを含むアプリ](images/nav/nav-subtrees.png)
- レベル 1 では、ピア ツー ピアのナビゲーション要素によって、ページ A、B、C、および D へのアクセスが提供されます。
- レベル 2 では、A2 ページのピア ツー ピアのナビゲーション要素は、他の A2 ページにのみリンクしています。 これらのナビゲーション要素は、C サブツリー内にあるレベル 2 のページにはリンクしていません。

![2 つのサブツリーを含むアプリ](images/nav/nav-subtrees2.png)

## <a name="use-the-right-controls"></a>適切なコントロールを使用する
ページの構造を決定したら、ユーザーがページ間をどのように移動するかを決定する必要があります。 UWP にはさまざまなナビゲーション コントロールが用意されていて、アプリで一貫性があり信頼性が高いナビゲーション エクスペリエンスを提供するために役立ちます。 

アプリのナビゲーション要素の数に基づいてナビゲーション コントロールを選択することをお勧めします。 ナビゲーション項目が 5 個以下の場合は、[タブとピボット](../controls-and-patterns/tabs-pivot.md)などのトップレベルのナビゲーションを使用します。 ナビゲーション項目が 6 個以上ある場合は、[ナビゲーション ビュー](../controls-and-patterns/navigationview.md)や[マスター/詳細](../controls-and-patterns/master-details.md)などの左側のナビゲーションを使用します。

<div class="mx-responsive-img">

<table>
<tr>
    <th>コントロール</th>
    <th>説明</th>
</tr>
<tr>
    <td><a href="https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Frame">フレーム</a><br/><br/>
    <img src="images/frame.png" alt="Frame" /></td>
    <td>ページを表示します。 <p>少数の例外を除き、複数のページがあるアプリではフレームを使用します。 通常、アプリにはフレームと、ナビゲーション ビュー コントロールなどの主要なナビゲーション要素を含むメイン ページがあります。 ユーザーがページを選択すると、フレームがページを読み込んで表示します。</p></td>
</tr>
<tr>
    <td><a href="../controls-and-patterns/tabs-pivot.md">タブとピボット</a><br/><br/>
    <img src="images/nav/nav-tabs-sm-300.png" alt="Tab-based navigation" /></td>
    <td>同じレベルにあるページへのリンクの横方向の一覧を表示します。
<p>次の場合に使用します。</p>
<ul>
<li>ページ数が 2 ～ 5 ページの場合。 5 ページを超える場合でもタブ/ピボットを使うことはできますが、すべてのタブ/ピボットを画面に収めることが難しくなることがあります。</li>
<li>ユーザーが頻繁にページ間を切り替えることを前提としている場合。</li>
</ul></td>
</tr>
<tr>
    <td><a href="../controls-and-patterns/navigationview.md">ナビゲーション ビュー</a><br/><br/>
    <img src="images/nav/nav-navpane-4page-thumb.png" alt="A navigation pane" /></td>
    <td>トップレベルのページへのリンクの縦方向の一覧を表示します。
<p>次の場合に使用します。</p>
<ul>
<li>ページがトップレベルに存在する場合。</li>
<li>ナビゲーション項目が多い場合 (5 個以上)。</li>
<li>ユーザーが頻繁にページ間を切り替えることを前提としていない場合。</li>

</ul></td>
</tr>
<tr>
<td><a href="../controls-and-patterns/master-details.md">マスター/詳細</a><br/><br/>
<img src="images/higsecone-masterdetail-thumb.png" alt="Master/details" /></td>
<td>項目の一覧 (マスター ビュー) を表示します。 項目を選ぶと、対応するページが詳細セクションに表示されます。
<p>次の場合に使用します。</p>
<ul>
<li>ユーザーが頻繁に子項目間を切り替えることを前提としている場合。</li>
<li>ユーザーが個々の項目や項目のグループに対して高いレベルの操作 (削除や並べ替えなど) を実行できるようにする場合、およびユーザーが各項目の詳細情報の表示や更新を実行できるようにする場合。</li>
</ul>
<p>マスター/詳細は、メールの受信トレイ、連絡先リスト、データ入力に適しています。</p>
</td>
<tr>
<td><a href="../controls-and-patterns/hub.md">ハブ</a><br/><br/>
<img src="images/hub.png" alt="Hub" /></td>
<td> 順序付けされた項目のセクションをグリッドに表示します。 
<p>次の場合に使用します。</p>
<ul>
<li>ヒーロー画像が含まれる視覚的ナビゲーションを作成する場合。</li>
</ul>
<p>ハブは、閲覧、表示、または購入エクスペリエンスに適しています。</p>
</td>
</tr>
<tr>
<td><a href="../controls-and-patterns/hyperlinks.md">ハイパーリンク</a>と<a href="../controls-and-patterns/buttons.md">ボタン</a></td>
<td> 埋め込まれたナビゲーション要素は、ページのコンテンツに表示されます。 他のナビゲーション要素はページの全体で一貫性がありますが、それとは異なり、コンテンツに埋め込まれたナビゲーション要素はそれぞれのページに固有のナビゲーション要素です。</td>
</tr>
</table>
</div>

## <a name="next-add-navigation-code-to-your-app"></a>次の手順: アプリにナビゲーションのコードを追加する
次の記事「[基本的なナビゲーションを実装する](navigate-between-two-pages.md)」では、アプリで 2 つのページ間で基本的なナビゲーションを行うための、Frame コントロールを使用するために必要なコードを示します。 