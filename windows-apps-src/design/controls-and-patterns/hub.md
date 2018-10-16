---
author: Jwmsft
Description: The hub control uses a hierarchical navigation pattern to support apps with a relational information architecture.
title: ハブ コントロール
ms.assetid: F1319960-63C6-4A8B-8DA1-451D59A01AC2
label: Hub
template: detail.hbs
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 2440b8589b0bef6471bd0db4a71bb249a19c056f
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4621195"
---
# <a name="hub-controlpattern"></a>ハブ コントロール/パターン

 


ハブ コントロールを使うと、アプリのコンテンツを、関連した別個のセクションやカテゴリに整理できます。 ハブのセクションは、優先順に走査するためのものであり、さらに細かい操作性を実現するための出発点として使うことができます。

> **重要な API**: [Hub クラス](https://msdn.microsoft.com/library/windows/apps/dn251843)、[HubSection クラス](https://msdn.microsoft.com/library/windows/apps/dn251845)

![ハブの例](images/hub_example_tablet.png)

ハブのコンテンツはパノラマ ビューに表示でき、ユーザーは、新しい情報、入手可能な情報、関連する情報がひとめでわかります。 ハブには通常、ページ ヘッダーがあり、各コンテンツ セクションにはセクション ヘッダーがあります。


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ハブ コントロールは、階層に配置された大量のコンテンツを表示する場合に適しています。 ハブは、新しいコンテンツの閲覧と検出の優先順位を設定し、ストアやメディア コレクション内の項目を表示する際に役立ちます。

ハブ コントロールには、コンテンツのナビゲーション パターンを構築するのに適したいくつかの機能があります。

-   **視覚的なナビゲーション**

    ハブを使うと、多様性のある簡潔なスキャンしやすい配列にコンテンツを表示できます。

-   **分類**

    各ハブ セクションでは、コンテンツを論理的な順序に配置できます。

-   **混在したコンテンツの種類**

    コンテンツの種類が混在する場合、資産の可変サイズと比率は共通です。 ハブを使うと、コンテンツの各種類を一意なものにし、各ハブ セクションに整然と配置できます。

-   **ページとコンテンツの可変幅**

    パノラマ モデルであるハブでは、セクション幅を調整できます。 これは異なる深度や量を含んだコンテンツに適してします。

-   **柔軟なアーキテクチャ**

    アプリのアーキテクチャを浅く維持する場合、すべてのチャネル コンテンツをハブ セクションの概要に収めることができます。

ハブは、いくつかある利用可能なナビゲーション要素の 1 つです。ナビゲーション パターンと他のナビゲーション要素について詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリのナビゲーション デザインの基本](../basics/navigation-basics.md)」をご覧ください。

## <a name="hub-architecture"></a>ハブのアーキテクチャ

ハブ コントロールには、リレーショナル情報アーキテクチャを使ったアプリをサポートする階層型ナビゲーション パターンがあります。 ハブはさまざまなカテゴリのコンテンツで構成され、それぞれがアプリのセクション ページに対応付けられています。 セクション ページは、シナリオとセクションに含まれるコンテンツが最適に表現されるような形で表示できます。

![階層型の Food with Friends アプリのワイヤーフレーム](images/navigation_diagram_food_with_friends_app_new.png)

## <a name="layouts-and-panningscrolling"></a>レイアウトとパン/スクロール

コンテンツをハブに配置して移動する方法はたくさんあります。ハブのコンテンツ リストが常にハブのスクロール方向に対して垂直にパンされる点だけ確認してください。

**水平方向のパン**

![水平方向にパンするハブの例](images/controls_hub_horizontal_pan.png)
**垂直方向のパン**

![垂直方向にパンするハブの例](images/controls_hub_vertical_pan.png)
**垂直方向のリストとグリッドのスクロールによる水平方向のパン**

![垂直方向のリストのスクロールによる水平方向にパンするハブの例](images/controls_hub_horizontal_vertical_scroll.png)
**水平方向のリストとグリッドのスクロールによる垂直方向のパン**

![水平方向にパンするハブの例](images/controls_hub_vertical_horizontal_scroll.png)

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Hub">アプリを開き、Hub の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

ハブは、設計上の大きな柔軟性を備えています。 そのため、魅力的で視覚に訴えるさまざまなエクスペリエンスを提供するアプリを設計できます。 最初のグループには、ヒーロー画像やコンテンツ セクションを使うことができます。ヒーローには、最も強調したい内容を失うことなく垂直方向と水平方向にトリミングできる大きい画像を使ってください。 次の例は、1 つのヒーロー画像と、その画像を横長、縦長、狭い幅で表示するためにトリミングする方法を示しています。

![さまざまなウィンドウ サイズに合わせてトリミングされたヒーロー画像](images/hub_hero_cropped2.png)

モバイル デバイスでは、一度に 1 つのハブ セクションを表示できます。

![小型画面上のハブ パターンの例](images/phone_hub_example.png)

## <a name="recommendations"></a>推奨事項

-   ハブ セクションに他のコンテンツがあることがユーザーにわかるように、一定量のコンテンツが見えるようにコンテンツをクリッピングすることをお勧めします。
-   アプリの必要に基づいて、ハブ コントロールに複数のハブ セクションを追加し、各セクションに独自の機能目的を持たせることができます。 たとえば、あるセクションには一連のリンクとコントロールを含め、別のセクションはサムネイルのリポジトリとすることができます。 ユーザーは、ハブ コントロールに組み込まれているジェスチャのサポートを使って、これらのセクション間をパンすることができます。
-   さまざまなウィンドウ サイズに対応できるように、コンテンツを動的に再配置するのが最適です。
-   多くのハブ セクションがある場合は、ハブにセマンティック ズームを追加することを検討します。 これには、アプリが狭い幅に合わせてサイズ変更されたときにセクションを見つけやすくなるという利点もあります。
-   ハブ セクション内の項目から別のハブに移動することはお勧めしません。代わりに、対話型ヘッダーを使って別のセクションまたはページに移動します。
-   ハブを基盤として使って、アプリの必要に合わせてカスタマイズできます。 ハブの次の機能を変更できます。
    -   セクションの数
    -   各セクションのコンテンツの種類
    -   セクションの配置と順序
    -   セクションのサイズ
    -   セクションとセクションの間隔
    -   セクションとハブの上端または下端の間隔
    -   ヘッダーとコンテンツのテキストのスタイルとサイズ
    -   背景、セクション、セクション ヘッダー、セクション コンテンツの色

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [Hub クラス](https://msdn.microsoft.com/library/windows/apps/dn251843)
- [ナビゲーションの基本](../basics/navigation-basics.md)
- [ハブの使用](https://msdn.microsoft.com/library/windows/apps/xaml/dn308518)
- [XAML ハブ コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=310072)
