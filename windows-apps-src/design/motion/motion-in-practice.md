---
author: jwmsft
Description: Learn how Fluent motion fundamentals come together in your app.
title: 実践的なモーション -  UWP アプリのアニメーション
label: Motion in practice
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 87a17d3f73887c9b1b5029e2096c5b41c9444c4e
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1843865"
---
# <a name="bringing-it-together"></a>まとめる

> [!IMPORTANT]
> この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

タイミング、イージング、方向、および重力は、連携して Fluent モーションの基礎となります。 それぞれが、互いのコンテキストで考慮され、アプリのコンテキストで適切に適用される必要があります。

アプリに Fluent モーションの基礎を適用する 3 つの方法を次に示します。

:::row::: :::column::: **暗黙的なアニメーション**

        Automatic tween and timing between values in a parameter change to achieve very simple Fluent motion using the standardized values.
    :::column-end:::
    :::column:::
        **Built-in animation**

        System components, such as common controls and shared motion, are "Fluent by default". Fundamentals have been applied in a manner consistent with their implied usage.
    :::column-end:::
    :::column:::
        **Custom animation following guidance recommendations**

        There may be times when the system does not yet provide an exact motion solution for your scenario. In those cases, use the baseline fundamental recommendations as a starting point for your experiences.
    :::column-end:::
:::row-end:::

### **<a name="transition-example"></a>切り替えの例**

![機能的なアニメーション](images/pageRefresh.gif)

:::row::: :::column::: <b>方向前方アウト:</b><br>
        フェード アウト: 150 m、イージング: 既定加速

        <b>Direction Forward In:</b><br>
        Slide up 150px: 300ms; Easing: Default Decelerate
    :::column-end:::
    :::column:::
         <b>Direction Backward Out:</b><br>
        Slide down 150px: 150ms; Easing: Default Accelerate
      
        <b>Direction Backward In:</b><br>
        Fade in: 300ms; Easing: Default Decelerate
    :::column-end:::
:::row-end:::

 ### **<a name="object-example"></a>オブジェクトの例**

 ![300 ミリ秒のモーション](images/control.gif)
 
:::row::: :::column::: <b>方向展開:</b><br>
        拡大: 300 ミリ秒、イージング: 標準 :::column-end::: :::column::: <b>方向コントラクト:</b><br>
        拡大: 150 ミリ秒、イージング: 既定加速 :::column-end::: :::row-end:::

## <a name="related-articles"></a>関連記事

- [モーションの概要](index.md)
- [タイミングとイージング](timing-and-easing.md)
- [方向性と重力](directionality-and-gravity.md)