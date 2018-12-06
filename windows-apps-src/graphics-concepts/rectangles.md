---
title: 矩形
description: Direct3D および Windows のプログラミングにおいて、画面上のオブジェクトは境界矩形として示されます。
ms.assetid: 3B78AE66-2C1A-4191-BDCA-D737E33460BA
keywords:
- 矩形
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: aa94eb00058ba3297e7ca7cc4f93581d9281fd1c
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8749857"
---
# <a name="rectangles"></a>矩形


Direct3D および Windows のプログラミングにおいて、画面上のオブジェクトは境界矩形として示されます。 境界矩形のサイドは、常に画面のサイドと平行になっています。そのため、矩形は左上隅と右下隅の 2 つのポイントで描画されます。

## <a name="span-idboundingrectanglesspanspan-idboundingrectanglesspanspan-idboundingrectanglesspanbounding-rectangles"></a><span id="Bounding_rectangles"></span><span id="bounding_rectangles"></span><span id="BOUNDING_RECTANGLES"></span>境界矩形


ほとんどのアプリケーションは、画面に情報を伝えたり、ヒット検出を実行したりする場合、[**RECT**](https://msdn.microsoft.com/library/windows/desktop/dd162897) 構造体 (または typedef されているエイリアス) を使って、利用する境界矩形に関する情報を伝えます。 C++ の場合、**RECT** 構造体は次のように定義されます。

```
typedef struct tagRECT { 
    LONG    left;    // This is the upper-left corner x-coordinate.
    LONG    top;     // The upper-left corner y-coordinate.
    LONG    right;   // The lower-right corner x-coordinate.
    LONG    bottom;  // The lower-right corner y-coordinate.
} RECT, *PRECT, NEAR *NPRECT, FAR *LPRECT; 
```

上記の例では、left メンバーと top メンバーが境界矩形の左上隅における x 座標と y 座標になります。 同様に、right メンバーと bottom メンバーが右下隅の座標を構成します。 次の図は、これらの値を視覚化したものです。

![left、top、right、bottom の値で境界が設定された矩形の図](images/rect.png)

右端のピクセルの列と下端のピクセルの行は、RECT に含まれていません。 たとえば、メンバー {10, 10, 138, 138} の RECT をロックすると、結果として幅と高さが 128 ピクセルのオブジェクトになります。

効率的で一貫性があり、簡単に利用できるため、すべての Direct3D の表示関数は矩形と連携します。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[座標系とジオメトリ](coordinate-systems-and-geometry.md)

 

 




