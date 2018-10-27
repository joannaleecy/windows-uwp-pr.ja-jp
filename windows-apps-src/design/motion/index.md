---
author: mijacobs
Description: Purposeful, well-designed motion brings your app to life and makes the experience feel crafted and polished. Help users understand context changes, and tie experiences together with visual transitions.
title: UWP アプリでのモーションとアニメーション
ms.assetid: 21AA1335-765E-433A-85D8-560B340AE966
label: Motion
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: jeffarn
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: def37c31ef0a64a9b1017d40d281457513fba0db
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5697455"
---
# <a name="motion-for-uwp-apps"></a>UWP アプリのモーション

![ヒーロー イメージ](images/header-motion2.svg)

Fluent モーションはアプリで目的を果たします。 これは、ユーザーの動作に基づいてインテリジェントなフィードバックを提供し、UI にアクティブな印象を与え、アプリ内でユーザーのナビゲーションを誘導します。 Fluent モーションは、ユーザーとそのデジタル エクスペリエンス間の感情面の結び付きを生み出します。 マイクロソフトでは、ユーザーが既に現実世界から認識している自然な動きの基盤のうえに構築し、そこからシステムを拡張します。

## <a name="fluent-motion-principles"></a>Fluent モーションの原則

### <a name="physical"></a>物理

動作中のオブジェクトは、現実世界でのオブジェクトの動作を示します。 滑らかで応答性の高い動きによって、自然な操作性を感じさせるエクスペリエンスが実現され、感情面の結び付きが生みだされ、個性が追加されます。

![物理モーションの UI の例](images/Physical.gif)
> タッチで UI を操作すると、UI の動きが、操作の速度に直接関連します。 また、タッチは直接操作であるため、操作するオブジェクトが周囲のオブジェクトに影響します。

### <a name="functional"></a>機能性

モーションは目的を果たし、確信があります。 複雑さに関してユーザーをサポートし、階層を確立する手助けをします。 モーションは、パフォーマンスが向上した印象を与え、体感する待ち時間を隠蔽することでユーザー エクスペリエンスを最適化します。

![機能的なモーションの UI の例](images/functional.gif)
> ページ切り替えは、目的に特化されています。 ページが相互に関連する方法に関するヒントを提供します。 パフォーマンスが最適でない場合でも速く感じられるような方法で移動します。

### <a name="continuous"></a>継続性

ポイントからポイントへの滑らか動きは、自然に目を引きつけ、ユーザーを誘導します。 適切にユーザーのタスクをまとめて、よりコンシューマブルで親しみやすく感じられるようにします。

![継続的なモーションの UI の例](images/continuous3.gif)
> オブジェクトは、シーン間を移動したり、シーン内でモーフィングして継続性を提供し、ユーザーがコンテキストを維持できるようにします。

### <a name="contextual"></a>状況依存

インテリジェントなモーションは、UI を操作する方法に沿った方法でユーザーにフィードバックを提供します。 操作はユーザーを中心にしています。 動きはフォーム ファクターに適切であると感じられ、シナリオに基づいて設計されています。 各ユーザーにとって快適である必要があります。

![状況依存のモーションの UI の例](images/Contextual.gif)
> アニメーションはユーザーの操作に沿ったものである必要があります。 コンテキスト メニューは、ユーザーがアクティブ化したポイントから展開されます。 

## <a name="motion-articles"></a>モーションの記事

:::row:::
    :::column:::
        ### [Timing and easing](timing-and-easing.md)
        Timing and easing are important elements that make motion feel natural for objects entering, exiting, or moving within the UI.
    :::column-end:::
    :::column:::
        ### [Directionality and gravity](directionality-and-gravity.md)
        Directional signals help provide a solid mental model of the journey a user takes across experiences. Directional movement is subject to forces like gravity, which reinforces the natural feel of the movement.
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        ### [Page transitions](page-transitions.md)
        Page transitions navigate users between pages in an app, providing feedback about the relationship between pages. They help users understand where they are in the navigation hierarchy.
    :::column-end:::
    :::column:::
        ### [Connected animation](connected-animation.md)
        Connected animations let you create a dynamic and compelling navigation experience by animating the transition of an element between two different views.
    :::column-end:::
:::row-end:::
