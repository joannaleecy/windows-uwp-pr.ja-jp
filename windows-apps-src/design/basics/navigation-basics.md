---
author: QuinnRadich
Description: Navigation in Universal Windows Platform (UWP) apps is based on a flexible model of navigation structures, navigation elements, and system-level features.
title: UWP アプリのナビゲーションの基本
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
op-migration-status: ready
ms.author: quradic
ms.date: 7/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: b731910f53a6152554b74e946374234b827f4a86
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3958782"
---
# <a name="navigation-design-basics-for-uwp-apps"></a>UWP アプリのナビゲーション デザインの基本

![ナビゲーションの基本のヘッダー](images/nav/navigation-basics-header.jpg)

アプリをページの集まりと考えると、*ナビゲーション*は、ページ間およびページ内を移動する動作を表します。 これはユーザー エクスペリエンスの出発点です。これによって、ユーザーは利用するコンテンツと機能を見つけます。 これは非常に重要ですが、適切な設計が難しい場合もあります。

ナビゲーションに関して行うことができる膨大な数の選択肢があります。 以下を行うことができます。

:::row:::
    :::column:::
        ![ナビゲーション例 1](images/nav/nav-1.svg)

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

ナビゲーションは、ユーザーの期待に沿ったものである必要があります。 [標準のコントロール](#use-the-right-controls)のユーザーを理解している、アイコンの次の標準的な規則を使用して、場所、およびスタイルができるナビゲーション予測可能な直感的なユーザー向け。

![ページ コンポーネントのイメージ](images/nav/page-components.svg)

> ユーザーは特定の UI 要素が標準の位置にあることを期待します。

### <a name="simplicity"></a>シンプルさ

ナビゲーション項目が少ないほど、ユーザーの意思決定がシンプルになります。 重要な移動先に簡単にアクセスできるようにして、重要度の低い項目を非表示にすることで、ユーザーは目的の場所にすばやく移動できるようになります。

:::row:::
    :::column:::
        ![実行例](images/nav/do.svg)

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
        ![フラット構造で配置されたページ](images/nav/flat-lateral-structure.svg)
    :::column-end:::
    :::column span =「2」::。
        ### Flat/lateral

        In a flat/lateral structure, pages exist side-by-side. You can go from one page to another in any order.

        We recommend using a flat structure when:

        - The pages can be viewed in any order.
        - The pages are clearly distinct from each other and don't have an obvious parent/child relationship.
        - There are less than 8 pages in the group. <br>
        (When there are more pages, it might be difficult for users to understand how the pages are unique or to understand their current location within the group. If you don't think that's an issue for your app, go ahead and make the pages peers. Otherwise, consider using a hierarchical structure to break the pages into two or more smaller groups.)

    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![階層構造で配置されたページ](images/nav/hierarchical-structure.svg)
    :::column-end:::
    :::column span =「2」::。
        ### Hierarchical

        In a hierarchical structure, pages are organized into a tree-like structure. Each child page has one parent, but a parent can have one or more child pages. To reach a child page, you travel through the parent.

        Hierarchical structures are good for organizing complex content that spans lots of pages. The downside is some navigation overhead: the deeper the structure, the more clicks it takes to get from page to page.

        We recommend a hierarchical structure when:
        
        - Pages should be traversed in a specific order.
        - There is a clear parent-child relationship between pages.
        - There are more than 7 pages in the group.
        
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![ハイブリッド構造のアプリ](images/nav/combining-structures.svg)
    :::column-end:::
    :::column span =「2」::。
        ### Combining structures

        You don't have choose to one structure or the other; many well-design apps use both. An app can use flat structures for top-level pages that can be viewed in any order, and hierarchical structures for pages that have more complex relationships.

        If your navigation structure has multiple levels, we recommend that peer-to-peer navigation elements only link to the peers within their current subtree. Consider the adjacent illustration, which shows a navigation structure that has two levels:

        - At level 1, the peer-to-peer navigation element should provide access to pages A, B, C, and D.
        - At level 2, the peer-to-peer navigation elements for the A2 pages should only link to the other A2 pages. They should not link to level 2 pages in the C subtree.
    :::column-end:::
:::row-end:::

## <a name="use-the-right-controls"></a>適切なコントロールを使用する

ページの構造を決定したら、ユーザーがページ間をどのように移動するかを決定する必要があります。 UWP にはさまざまなナビゲーション コントロールが用意されていて、アプリで一貫性があり信頼性が高いナビゲーション エクスペリエンスを提供するために役立ちます。

:::row:::
    :::column:::
        ![フレーム画像](images/nav/thumbnail-frame.svg)
    :::column-end:::
    :::column span =「2」:::[**フレーム**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Frame)

        With few exceptions, any app that has multiple pages uses a frame. Typically, an app has a main page that contains the frame and a primary navigation element, such as a navigation view control. When the user selects a page, the frame loads and displays it.
:::row-end:::

:::row:::
    :::column:::
        ![タブとピボットのイメージ](images/nav/thumbnail-tabs-pivot.svg)
    :::column-end:::
    :::column span =「2」:::[**上部のナビゲーションとタブ**](../controls-and-patterns/navigationview.md)

        Displays a horizontal list of links to pages at the same level. The [NavigationView](../controls-and-patterns/navigationview.md) control implements the top navigation and tabs patterns.
        
        Use top navigation when:

        - You want to show all navigation options on the screen.
        - You desire more space for your app's content.
        - Icons cannot clearly describe your navigation categories.
        
        Use tabs when:

        - You want to preserve navigation history and page state.
        - You expect users to switch between tabs frequently.

:::row-end:::

:::row:::
    :::column:::
        ![navview イメージ](images/nav/thumbnail-navview.svg)
    :::column-end:::
    :::column span =「2」:::[**左側のナビゲーション**](../controls-and-patterns/navigationview.md)

        Displays a vertical list of links to top-level pages. Use when:
        
        - The pages exist at the top level.
        - There are many navigation items (more than 5)
        - You don't expect users to switch between pages frequently.
        
:::row-end:::

:::row:::
    :::column:::
        ![マスター/詳細の画像](images/nav/thumbnail-master-detail.svg)
    :::column-end:::
    :::column span =「2」:::[**マスター/詳細**](../controls-and-patterns/master-details.md)

        Displays a list (master view) of items. Selecting an item displays its corresponding page in the details section. Use when:
        
        - You expect users to switch between child items frequently.
        - You want to enable the user to perform high-level operations, such as deleting or sorting, on individual items or groups of items, and also want to enable the user to view or update the details for each item.

        Master/details is well suited for email inboxes, contact lists, and data entry.
:::row-end:::

:::row:::
    :::column:::
        ![ハイパーリンクとボタンの画像](images/nav/thumbnail-hyperlinks-buttons.svg)
    :::column-end:::
    :::column span =「2」:::[**ハイパーリンク**](../controls-and-patterns/hyperlinks.md)

        Embedded navigation elements can appear in a page's content. Unlike other navigation elements, which should be consistent across the pages, content-embedded navigation elements are unique from page to page.
:::row-end:::

## <a name="next-add-navigation-code-to-your-app"></a>次の手順: アプリにナビゲーションのコードを追加する

次の記事「[基本的なナビゲーションを実装する](navigate-between-two-pages.md)」では、アプリで 2 つのページ間で基本的なナビゲーションを行うための、Frame コントロールを使用するために必要なコードを示します。