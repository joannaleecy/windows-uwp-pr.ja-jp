---
author: mijacobs
Description: Good icons harmonize with typography and with the rest of the design language. They don’t mix metaphors, and they communicate only what’s needed, as speedily and simply as possible.
title: アイコン
ms.assetid: b90ac02d-5467-4304-99bd-292d6272a014
label: Icons
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
design-contact: Judysa
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 61157ad23eb55447137531922ea23fa0120e2b98
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1653921"
---
# <a name="icons-for-uwp-apps"></a>UWP アプリのアイコン



優れたアイコンは、文字の体裁やその他のデザイン言語と調和するものです。 アイコンは比喩と混用しないようにします。優れたアイコンは、できるだけすばやくシンプルに、必要なことのみを伝えます。 

## <a name="linear-scaling-size-ramps"></a>線形のスケーリングのサイズの見本 

<table>
    <tr> 
        <td>16 ピクセル x 16 ピクセル</td>
        <td>24 ピクセル x 24 ピクセル</td>
        <td>32 ピクセル x 32 ピクセル</td>
        <td>48 ピクセル x 48 ピクセル</td>
    </tr>
    <tr> 
        <td><img src="images/icons-16x16.png" alt="Icons at 16x16 effective pixels" /></td>
        <td><img src="images/icons-24x24.png" alt="Icons at 24x24 effective pixels" /></td>
        <td><img src="images/icons-32x32.png" alt="Icons at 32x32 effective pixels" /></td>
        <td><img src="images/icons-48x48.png" alt="Icons at 48x48 effective pixels" /></td>
    </tr>
</table>

## <a name="common-shapes"></a>一般的な形状

アイコンは通常、余白を少なく、スペースを最大限に使用します。 下記の図形は基本的な形状のサイズを決めるためのヒントとなります。 

![32 ピクセル x 32 ピクセルのグリッド](images/icons-common-shapes.png)

アイコンの向きに対応した図形を使用して、これらの基本的なパラメーターをヒントとして構成します。 アイコンは必ずしも図形内側に完全に合わせて埋める必要はありません。最適なバランスを取るために適宜調整します。 

<table class="uwpd-noborder">
    <tr>
        <td>円形<td>
        <td>正方形</td>
        <td>三角形</td>
    </tr>
    <tr>
        <td><img src="images/icons-common-shapes-examples-1.png" alt="A circle" /><td>
        <td><img src="images/icons-common-shapes-examples-2.png" alt="A square" /></td>
        <td><img src="images/icons-common-shapes-examples-3.png" alt="A triangle " /></td>
    </tr>
        <tr>
        <td>横型の長方形<td>
        <td colspan="2">縦型の長方形</td>        
        </tr>
    <tr>
        <td><img src="images/icons-common-shapes-examples-4.png" alt="A horizontal rectangle" /><td>
        <td colspan="2"><img src="images/icons-common-shapes-examples-5.png" alt="A vertical rectangle" /></td>
         
    </tr>

</table>

## <a name="angles"></a>角度

同じグリッドや線の太さなどをはじめ、アイコンは共通的な要素で構成されています。 

これらの共通の角度を使って図形を作成すると、Microsoft のすべてのアイコンとの一貫性を保つことができ、アイコンが正しくレンダリングされます。 

これらの線の組み合わせ、合体、回転、反転を使って、アイコンを作成します。 

<table>
    <tr>
        <td><b>1:1</b><br/>45°</td>
        <td><b>1:2</b><br />26.57° (垂直)<br/>63.43° (水平)</td>
        <td><b>1:3</b><br/>18.43° (垂直)<br/>71.57° (水平)</td>
        <td><b>1:4</b><br/>14.04° (垂直)<br/>75.96° (水平)</td>
    </tr>
    <tr>
        
        <td><img src="images/icons-grid-1-1.png" alt="1:1" /></td>
        <td><img src="images/icons-grid-1-2.png" alt="1:2" /></td>
        <td><img src="images/icons-grid-1-3.png" alt="1:3" /></td>
        <td><img src="images/icons-grid-1-4.png" alt="1:4" /></td>
    </tr>  
</table>

<p>例をいくつか紹介します。</p>

<table>
    <tr>
        <td><img src="images/icons-angles-examples-1.png" alt="A 1:1 angle example" /></td>
        <td><img src="images/icons-angles-examples-2.png" alt="A 1:2 angle example" /></td>
        <td><img src="images/icons-angles-examples-3.png" alt="A 1:3 angle example" /></td>
        <td><img src="images/icons-angles-examples-4.png" alt="A 1:4 angle example" /></td>
    </tr>
</table>

## <a name="curves"></a>曲線

曲線は円の一部から構成します。ピクセル グリッドにスナップするために必要な場合以外は、ゆがめて使用しないようにします。 

<table>
    <tr>
        <td>円形の 1/4</td>
        <td>円形の 1/8</td>
    </tr>
    <tr>
        <td><img src="images/icons-curves-14circle.png" alt="1/4 circle" /></td>
        <td><img src="images/icons-curves-18circle.png" alt="1/8 circle" /></td>
    </tr>
    <tr>
        <td><img src="images/icons-curves-examples-1.png" alt="1/4 cirlce example" /></td>
        <td><img src="images/icons-curves-examples-2.png" alt="1/8 circle example" /></td>
    </tr>    
</table>

## <a name="geometric-construction"></a>幾何学図形の使用

アイコンを作成する場合には、純粋な幾何学図形のみを使用することをお勧めします。

![幾何学図形のオーバーレイを使ったギターのアイコン ](images/icons-geometric-construction.png)

## <a name="filled-shapes"></a>図形の塗りつぶし 

アイコンは、必要な場合は、塗りつぶされた図形を含めることができますが、32 ピクセル × 32 ピクセルの場合、4 ピクセルを超えないようにします。 円形の塗りつぶしは 6 ピクセル × 6 ピクセルを超えないようにします。 

![5 ピクセル x 8 ピクセルの塗りつぶし ](images/icons-filled-shapes.png)

## <a name="badges"></a>バッジ

「バッジ」は、元になるアイコンの要素との統合を意図することなくアイコンに追加された要素を記述するために使用する一般的な用語です。 これらは通常、状態や操作など、元になるアイコンに関連する情報を示すために使用します。 この他に一般的に使われる用語には、オーバーレイ、注釈、修飾子などがあります。 

![状態を示すバッジ ](images/icons-badge-status.png)

![操作を示すバッジ ](images/icons-badge-action.png)

状態を示すバッジでは、塗りつぶして色を付けたオブジェクトが、元となるアイコンの上で使用されています。操作を示すバッジでは、同じモノクロ スタイルと線の太さでアイコンに統合されています。

<table>
<tr>
    <td>一般的な状態を示すバッジ</td>
    <td>一般的な操作を示すバッジ</td>
</tr>
<tr>
    <td><img src="images/icons-badge-common-states-1.png" alt="Status badge " /></td>
    <td><img src="images/icons-badge-common-states-2.png" alt="Action badge " /></td>
</tr>
</table>
<p></p>

### <a name="badge-color"></a>バッジの色 

色のバッジは、アイコンの状態を示す場合にのみ使用する必要があります。 状態を示すバッジに使用される色は、ユーザーに特定の感情的なメッセージを伝えます。 

<table>
<tr><td>緑 - #128B44</td><td>青 - #2C71B9</td><td>黄 - #FDC214</td></tr>
<tr><td>ポジティブ: 終了、完了 </td><td>中立: ヘルプ、通知 </td><td>注意: 警報、警告 </td></tr>
<tr><td><img src="images/icons-color-inbadging-1.png" alt="Green status" /></td><td><img src="images/icons-color-inbadging-2.png" alt="Blue status" /></td>
<td><img src="images/icons-color-inbadging-3.png" alt="Yellow status" /></td></tr>
</table>
<p></p>

### <a name="badge-position"></a>バッジの位置

状態または操作を示すバッジの既定の位置は、右下です。 その他の位置は、デザイン上やむを得ない場合にのみ使用します。 

### <a name="badge-sizing"></a>バッジのサイズ変更

バッジは 32 ピクセル × 32 ピクセル グリッドで、10 ～ 18 ピクセルのサイズで使用します。 

## <a name="related-articles"></a>関連記事

* [タイルとアイコン アセットのガイドライン](../shell/tiles-and-notifications/app-assets.md)