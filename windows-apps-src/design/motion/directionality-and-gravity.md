---
author: jwmsft
Description: Learn how Fluent motion uses directionality and gravity.
title: 方向性と重力 - UWP アプリでのアニメーション
label: Directionality and gravity
template: detail.hbs
ms.author: jimwalk
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 09bccec40c25e5eba06ba7a7c428b7b771f84271
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5991025"
---
# <a name="directionality-and-gravity"></a>方向性と重力

方向指示は、ユーザーがエクスペリエンス全体を通じて行う取り組みの概念的モデルを強固にするために役立ちます。 任意の動きの方向は、空間の連続性だけでなく、空間内のオブジェクトの整合性もサポートすることが重要です。

方向性は重力のような力を受けます。 動きに力を加えるとモーションの自然な操作感が強化されます。

## <a name="direction-of-movement"></a>動きの方向

:::row:::
    :::column:::
        Direction of movement corresponds to physical motion. Just like in nature, objects can move in any world axis - X,Y,Z. This is how we think of the movement of objects on the screen.

        When you move objects, avoid unnatural collisions. Keep in mind where objects come from and go to, and alway support higher level constructs that may be used in the scene, such as scroll direction or layout hierarchy.
    :::column-end:::
    :::column:::
        ![direction backward in](images/Direction.gif)
    :::column-end:::
:::row-end:::

## <a name="direction-of-navigation"></a>ナビゲーションの方向

アプリ内のシーン間のナビゲーションの方向は、概念的なものです。 ユーザーは前後に移動します。 シーンはビューの内外に移動します。 これらの概念は物理的な動きと連携してユーザーを誘導します。

ナビゲーションによりオブジェクトが前のシーンから新しいシーンに移動する場合、オブジェクトは画面上で A から B の単純な移動を行います。 動きがより物理的に感じられるようにするために、標準的なイージングに加えて、重力の感覚が追加されます。

"戻る" ナビゲーションでは、動きが逆になります (B から A)。 ユーザーは戻る移動をしたときに、できるだけ早く以前の状態に戻ることを期待します。 タイミングはより迅速で直接的であり、減速のイージングを使用します。

ここでは、前後のナビゲーション中に選択された項目が画面上に表示されたままになるため、これらの原則が適用されます。

![継続的なモーションの UI の例](images/continuous3.gif)

ナビゲーションにより画面上の項目が置き換えられると、既存のシーンの移動先と、新しいシーンの移動元を示すことが重要です。

これには次のようないくつかの利点があります。

- 空間に対するユーザーの概念的モデルが確立されます。
- 既存のシーンの継続時間により、後続のシーンに対してコンテンツをアニメーション化する準備をするためのより長い時間が提供されます。
- これにより、アプリの体感的なパフォーマンスが向上します。

ナビゲーションに関して考慮すべき目立たない 4 つの方向があります。

:::row:::
    :::column:::
        **Forward-In**

        Celebrate content entering the scene in a manner that does not collide with outgoing content. Content decelerates into the scene.
    :::column-end:::
    :::column:::
        ![direction forward in](images/forwardIN.gif)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        **Forward-Out**

        Content exits quickly. Objects accelerate off screen.
    :::column-end:::
    :::column:::
        ![direction forward out](images/forwardOUT.gif)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        **Backward-In**

        Same as Forward-In, but reversed.
    :::column-end:::
    :::column:::
        ![direction backward in](images/backwardIN.gif)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        **Backward-Out**

        Same as Forward-Out, but reversed.
    :::column-end:::
    :::column:::
        ![direction backward out](images/backwardOUT.gif)
    :::column-end:::
:::row-end:::

## <a name="gravity"></a>重力

重力によりエクスペリエンスがより自然に感じられるようになります。 z 軸上を移動し、画面上のアフォー ダンスでシーンに固定されていないオブジェクトは、重力の影響を受ける可能性があります。 オブジェクトがシーンから開放され、脱出速度に到達する前に、重力がオブジェクトを引き下げ、オブジェクトの移動に伴い軌跡のより自然なカーブが生み出されます。

通常、オブジェクトがあるシーンから別のシーンに移動する必要があるときに、重力が生じます。 このため、接続型アニメーションには重力の概念が使用されます。

ここでは、グリッドの先頭行にある要素が重力の影響を受け、要素がその場所を離れて前方に移動するときに若干下がります。

![逆方向へのイン](images/continuity-photos.gif)

## <a name="related-articles"></a>関連記事

- [モーションの概要](index.md)
- [タイミングとイージング](timing-and-easing.md)