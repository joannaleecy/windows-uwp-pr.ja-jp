---
author: Jwmsft
Description: Navigation in Universal Windows Platform (UWP) apps is based on a flexible model of navigation structures, navigation elements, and system-level features.
title: UWP アプリのナビゲーションの基本
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 7/16/2018
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 04e5ff8025850c3ee69a0b04691af3c6e8c4e24b
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7419991"
---
# <a name="navigation-design-basics-for-uwp-apps"></a>UWP アプリのナビゲーション デザインの基本

![ナビゲーションの基本のヘッダー](images/nav/navigation-basics-header.jpg)

アプリをページの集まりと考えると、*ナビゲーション*は、ページ間およびページ内を移動する動作を表します。 これはユーザー エクスペリエンスの出発点です。これによって、ユーザーは利用するコンテンツと機能を見つけます。 これは非常に重要ですが、適切な設計が難しい場合もあります。

ナビゲーションに関して行うことができる膨大な数の選択肢があります。 以下を行うことができます。

:::row:::
    :::column:::
        ![navigation example 1](images/nav/nav-1.svg)

        Require users to go through a series of pages in order.
    :::column-end:::
    :::column:::
        ![navigation example 2](images/nav/nav-2.svg)

        Provide a menu that allows users to jump directly to any page.
    :::column-end:::
    :::column:::
        ![navigation example 3](images/nav/nav-3.svg)

        Place everything on a single page and provide filtering mechanisms for viewing content.
    :::column-end:::
:::row-end:::

1 つのナビゲーション デザインですべてのアプリに対応することはできませんが、アプリの適切な設計を判断するための原則やガイドラインがあります。

## <a name="principles-of-good-navigation"></a>優れたナビゲーションの原則

優れたナビゲーション デザインの基本原則から始めましょう。

- **一貫性:** ユーザーの期待に応えます。
- **シンプルさ:** 必要以上のことをしないようにします。
- **明確さ:** 明確なパスとオプションを提供します。

### <a name="consistency"></a>一貫性

ナビゲーションは、ユーザーの期待に沿ったものである必要があります。 [標準的なコントロール](#use-the-right-controls)のユーザーを理解している、アイコンの次の標準的な規則を使用して、場所、およびスタイルができるナビゲーション予測可能な直感的なユーザー向け。

![ページ コンポーネントのイメージ](images/nav/page-components.svg)

> ユーザーは特定の UI 要素が標準の位置にあることを期待します。

### <a name="simplicity"></a>シンプルさ

ナビゲーション項目が少ないほど、ユーザーの意思決定がシンプルになります。 重要な移動先に簡単にアクセスできるようにして、重要度の低い項目を非表示にすることで、ユーザーは目的の場所にすばやく移動できるようになります。

:::row:::
    :::column:::
        ![do example](images/nav/do.svg)

        ![navview good](images/nav/navview-good.svg)

        Present navigation items in a familiar navigation menu.
    :::column-end:::
    :::column:::
        ![don't example](images/nav/dont.svg)

        ![navview bad](images/nav/navview-bad.svg)

        Overwhelm users with many navigation options.
    :::column-end:::
:::row-end:::

### <a name="clarity"></a>明確さ

明確なパスを示すと、ユーザーは論理的なナビゲーションを行うことができます。 ナビゲーション オプションをわかりやすくし、ページ間の関係を明確にすることで、ユーザーが自分の位置を見失うことを防止できます。

![実行例](images/nav/clarity-image.svg)

> 移動先にはわかりやすいラベルが付けられているため、ユーザーは自分の位置を知ることができます。

## <a name="general-recommendations"></a>一般的な推奨事項

一貫性、シンプルさ、明確さという設計原則を念頭に置いて、一般的な推奨事項を作成しましょう。

1. ユーザーのことを考えてください。 アプリ使用時のユーザーの一般的な移動パスを追跡し、ページごとに、ユーザーがそのページを表示している理由と、次にどこに移動しようとしているかを考えてください。

2. ナビゲーションの深い階層を避けます。 3 レベルを超えるナビゲーションでは、ユーザーは迷ってしまい、深い階層から抜け出せなくなる可能性があります。

3. 「ホッピング」を避けます。 ホッピングとは、関連するコンテンツに移動するために、ユーザーが上のレベルに移動して、それから下のレベルに移動する必要があるナビゲーションを意味します。

## <a name="use-the-right-structure"></a>適切な構造を使う

ナビゲーションの一般的な原則について説明しました。次に、アプリの構造について考えます。 2 種類の一般的な構造があります。フラット構造と階層構造です。

:::row:::
    :::column:::
        ![Pages arranged in a flat structure](images/nav/flat-lateral-structure.svg)
    :::column-end:::
    :::column span="2":::
        ### Flat/lateral

        In a flat/lateral structure, pages exist side-by-side. You can go from one page to another in any order.

        We recommend using a flat structure when:

        - ページをどのような順序でも表示できる場合。
        - 各ページはそれぞれ異なるページであり、明確な親/子関係はありません。
        - グループには、8 個未満のページがあります。 <br>
        (ページ数が 8 ページ以上の場合、ページが一意であるかどうかを判断したり、グループ内の現在の位置を把握したりするのが難しくなる場合があります。 このことがアプリでは問題にはならないと考えられる場合は、ページをピアとして作成します。 このことが問題となる可能性がある場合は、階層構造を使って、ページを 2 つ以上の小さなグループに分割することを検討してください。)

    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![Pages arranged in a hierarchy](images/nav/hierarchical-structure.svg)
    :::column-end:::
    :::column span="2":::
        ### Hierarchical

        In a hierarchical structure, pages are organized into a tree-like structure. Each child page has one parent, but a parent can have one or more child pages. To reach a child page, you travel through the parent.

        Hierarchical structures are good for organizing complex content that spans lots of pages. The downside is some navigation overhead: the deeper the structure, the more clicks it takes to get from page to page.

        We recommend a hierarchical structure when:
        
        - 特定の順序でページを移動する必要がある場合。
        - ページ間に明白な親子関係がある場合。
        - グループ内のページ数が 7 ページを超える場合。
        
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![an app with a hybrid structure](images/nav/combining-structures.svg)
    :::column-end:::
    :::column span="2":::
        ### Combining structures

        You don't have choose to one structure or the other; many well-design apps use both. An app can use flat structures for top-level pages that can be viewed in any order, and hierarchical structures for pages that have more complex relationships.

        If your navigation structure has multiple levels, we recommend that peer-to-peer navigation elements only link to the peers within their current subtree. Consider the adjacent illustration, which shows a navigation structure that has two levels:

        - レベル 1 では、ピア ツー ピアのナビゲーション要素によって、ページ A、B、C、および D へのアクセスが提供されます。
        - レベル 2 では、A2 ページのピア ツー ピアのナビゲーション要素は、他の A2 ページにのみリンクしています。 これらのナビゲーション要素は、C サブツリー内にあるレベル 2 のページにはリンクしていません。
    :::column-end:::
:::row-end:::

## <a name="use-the-right-controls"></a>適切なコントロールを使用する

ページの構造を決定したら、ユーザーがページ間をどのように移動するかを決定する必要があります。 UWP にはさまざまなナビゲーション コントロールが用意されていて、アプリで一貫性があり信頼性が高いナビゲーション エクスペリエンスを提供するために役立ちます。

:::row:::
    :::column:::
        ![Frame image](images/nav/thumbnail-frame.svg)
    :::column-end:::
    :::column span="2":::
        [**Frame**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Frame)

        With few exceptions, any app that has multiple pages uses a frame. Typically, an app has a main page that contains the frame and a primary navigation element, such as a navigation view control. When the user selects a page, the frame loads and displays it.
:::row-end:::

:::row:::
    :::column:::
        ![tabs and pivot image](images/nav/thumbnail-tabs-pivot.svg)
    :::column-end:::
    :::column span="2":::
        [**Top navigation and tabs**](../controls-and-patterns/navigationview.md)

        Displays a horizontal list of links to pages at the same level. The [NavigationView](../controls-and-patterns/navigationview.md) control implements the top navigation and tabs patterns.
        
        Use top navigation when:

        - 画面上のすべてのナビゲーション オプションを表示します。
        - アプリのコンテンツを追加する領域がしたいです。
        - アイコンは、ナビゲーションのカテゴリを明確に記述ことはできません。
        
        ときにタブを使用します。

        - ナビゲーション履歴とページの状態を保持します。
        - ユーザーがタブを頻繁に切り替えることが予想されます。

:::row-end:::

:::row:::
    :::column:::
        ![navview image](images/nav/thumbnail-navview.svg)
    :::column-end:::
    :::column span="2":::
        [**Left navigation**](../controls-and-patterns/navigationview.md)

        Displays a vertical list of links to top-level pages. Use when:
        
        - ページがトップレベルに存在する場合。
        - 項目が多いナビゲーション (5 個以上)
        - ユーザーが頻繁にページ間を切り替えることを前提としていない場合。
        
:::row-end:::

:::row:::
    :::column:::
        ![Master details image](images/nav/thumbnail-master-detail.svg)
    :::column-end:::
    :::column span="2":::
        [**Master/details**](../controls-and-patterns/master-details.md)

        Displays a list (master view) of items. Selecting an item displays its corresponding page in the details section. Use when:
        
        - ユーザーが頻繁に子項目間を切り替えることを前提としている場合。
        - ユーザーが個々の項目や項目のグループに対して高いレベルの操作 (削除や並べ替えなど) を実行できるようにする場合、およびユーザーが各項目の詳細情報の表示や更新を実行できるようにする場合。

        マスター/詳細は、メールの受信トレイ、連絡先リスト、データ入力に適しています。
:::row-end:::

:::row:::
    :::column:::
        ![Hyperlinks and buttons image](images/nav/thumbnail-hyperlinks-buttons.svg)
    :::column-end:::
    :::column span="2":::
        [**Hyperlinks**](../controls-and-patterns/hyperlinks.md)

        Embedded navigation elements can appear in a page's content. Unlike other navigation elements, which should be consistent across the pages, content-embedded navigation elements are unique from page to page.
:::row-end:::

## <a name="next-add-navigation-code-to-your-app"></a>次の手順: アプリにナビゲーションのコードを追加する

次の記事「[基本的なナビゲーションを実装する](navigate-between-two-pages.md)」では、アプリで 2 つのページ間で基本的なナビゲーションを行うための、Frame コントロールを使用するために必要なコードを示します。
