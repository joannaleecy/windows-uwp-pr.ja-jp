---
Description: This topic describes the use of contact geometry for touch targeting and provides best practices for targeting in Windows Runtime apps.
title: ターゲット設定
ms.assetid: 93ad2232-97f3-42f5-9e45-3fc2143ac4d2
label: Targeting
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6e8425232512650d5c80bf6fee9745b261aee8d9
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8738968"
---
# <a name="guidelines-for-targeting"></a>ターゲット設定のガイドライン


Windows のタッチ補正では、タッチ デジタイザーで検出されるそれぞれの指が接触する領域全体を使います。 デジタイザーから伝えられる、より広く複雑なこの入力データのセットを使うと、ユーザーが意図した (または意図した可能性が高い) ターゲットをより正確に特定できます。

> **重要な API**: [**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)、[**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、[**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)

このトピックでは、タッチ補正のための接触形状の使用について説明し、UWP アプリでのターゲット設定のベスト プラクティスを紹介します。

## <a name="measurements-and-scaling"></a>サイズと表示スケール


画面サイズとピクセル密度が変わっても一貫性が維持されるように、ターゲット サイズはすべて物理単位 (ミリメートル) で表されます。 物理単位は、次の式でピクセルに変換できます。

ピクセル数 = ピクセル密度 × サイズ

次の例ではこの式を使って、135 ppi (pixel per inch) のディスプレイと 1x の表示スケール プラトーでの 9 mm ターゲットのピクセル サイズを計算します。

ピクセル数 = 135 ppi × 9 mm

ピクセル数 = 135 ppi × (0.03937 インチ/mm × 9 mm)

ピクセル数 = 135 ppi × 0.35433 インチ

ピクセル数 = 48 ピクセル

この結果は、システムで定義されている各表示スケール プラトーに従って調整する必要があります。

## <a name="thresholds"></a>しきい値


操作の結果を判断するために距離と時間のしきい値を使うことがあります。

たとえば、タッチ ダウンが検出されたとき、オブジェクトがタッチ ダウン ポイントから 2.7 mm 未満の範囲でドラッグされて、タッチ ダウンから 0.1 秒以内に指が上げられた場合は、タップが登録されます。 この 2.7 mm のしきい値を超えて指を動かすと、オブジェクトはドラッグされ、選択または移動されます (詳しくは、「[クロススライドのガイドライン](guidelines-for-cross-slide.md)」をご覧ください)。 アプリによっては、0.1 秒より長く押し続けると自己説明操作が実行されることもあります (詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください)。

## <a name="target-sizes"></a>ターゲット サイズ


一般に、タッチ ターゲットのサイズを一辺 9 mm 以上の正方形に設定します (1.0x のスケール プラトーで 135 ppi のディスプレイで 48x48 ピクセル)。 一辺 7 mm 未満の正方形であるタッチ ターゲットを使わないようにしてください。

次の図は、ターゲット サイズが一般には外観上のターゲット、実際のターゲット サイズ、実際のターゲットと他の指定可能なターゲットの間の余白の組み合わせで決まることを示しています。

![外観上のターゲット、実際のターゲット、余白の推奨サイズを示す図。](images/targeting-size.png)

タッチ ターゲットのコンポーネントの最小サイズと推奨サイズを次の表に示します。

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">ターゲット コンポーネント</th>
<th align="left">最小サイズ</th>
<th align="left">推奨サイズ</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">余白</td>
<td align="left">2 mm</td>
<td align="left">適用できません。</td>
</tr>
<tr class="even">
<td align="left">外観上のターゲット サイズ</td>
<td align="left">&lt;実際のサイズの 60%</td>
<td align="left">実際のサイズの 90 ～ 100%
<p>ほとんどのユーザーは一辺 4.2 mm の正方形 (7 mm の推奨の最小ターゲットのサイズの 60%) よりも小さい場合、外観上のターゲットがタッチ可能であると実感しません。</p></td>
</tr>
<tr class="odd">
<td align="left">実際のターゲット サイズ</td>
<td align="left">7 mm の正方形</td>
<td align="left">一辺 9 mm 以上の正方形 (48 x 48 ピクセル @ 1x)</td>
</tr>
<tr class="even">
<td align="left">全体的なターゲット サイズ</td>
<td align="left">11 x 11 mm (約 60 ピクセル: 3 個の 20 ピクセル グリッド @ 1x)</td>
<td align="left">13.5 x 13.5 mm (72 x 72 ピクセル @ 1x)
<p>これは、実際のターゲットと余白を組み合わせたサイズをそれぞれの最小サイズより大きくする必要があることを意味します。</p></td>
</tr>
</tbody>
</table>

 

表に示したターゲット サイズの推奨サイズは、個々のシナリオの必要に応じて調整できます。 この推奨サイズの設定では、次の点が考慮されています。

-   タッチの頻度: 繰り返しタッチされたり、頻繁にタッチされたりするターゲットは、最小サイズより大きくするようにしてください。
-   エラー防止: 誤ってタッチすると重大な結果をもたらすターゲットは、大きな余白を取り、コンテンツ領域の端から離して配置する必要があります。 特に当てはまるのは頻繁にタッチされるターゲットです。
-   コンテンツ領域での位置
-   フォーム ファクターと画面サイズ
-   指の位置
-   タッチの視覚エフェクト
-   ハードウェアとタッチ デジタイザー

## <a name="targeting-assistance"></a>ターゲット設定支援


Windows では、ここで示した最小サイズや推奨する余白サイズを適用できない状況に対応するためのターゲット設定支援機能を提供しています。対象となるのは、Web ページ上のハイパーリンク、カレンダー コントロール、ドロップダウン リストとコンボ ボックス、テキスト選択などです。

このようにターゲット設定プラットフォームを強化し、ユーザー インターフェイスの動作を視覚的なフィードバック (不明瞭解消 UI) と連携させることで、ユーザーがより正確に、また安心して操作できるようになります。 詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。

タッチ可能な要素を推奨の最小ターゲット サイズより小さくする必要がある場合は、次のテクニックを使ってターゲット設定で発生する問題を最小化できます。

## <a name="tethering"></a>テザー


テザーとは、入力接点がオブジェクトに直接触れていなくても、ユーザーがそのオブジェクトにつながっているか操作していることをユーザーに示すために使われる視覚的な合図 (接点からオブジェクトの境界の四角形までを結ぶコネクタ) です。 テザーは次の場合に使われます。

-   タッチによる接触がオブジェクトまでの近接しきい値の範囲内で最初に検出され、そのオブジェクトがそのタッチのターゲットとして最も可能性が高いと特定された場合。
-   タッチによる接触がオブジェクトから離れたが、その接触が近接しきい値内にとどまっている場合。

この機能は、JavaScript を使った UWP アプリの開発者には公開されていません。

## <a name="scrubbing"></a>スクラブ


スクラブとは、ターゲットのフィールド内をタッチし、そのまま指を持ち上げずに目的のターゲットまでスライドさせてそのターゲットを選ぶことを意味します。 この操作は "指を離すことによるアクティブ化" とも呼ばれます。この場合、アクティブ化されるオブジェクトは、指が画面から離れたときに最後にタッチされたオブジェクトです。

スクラブ操作を設計するときは、次のガイドラインに従ってください。

-   スクラブは、不明瞭解消 UI と併用します。 詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。
-   スクラブ対象のタッチ ターゲットの推奨最小サイズは、20 ピクセル (3.75 mm @ 1x サイズ) です。
-   スクラブは、Web ページなどのパン対応サーフェイスで実行されたときに優先されます。
-   スクラブ対象ターゲットは互いに近づける必要があります。
-   ユーザーがドラッグによってスクラブ対象ターゲットから指を離すと、操作は取り消されます。
-   ターゲットによって実行される操作が破棄的でなければ (カレンダーでの日付の切り替えなど)、スクラブ対象ターゲットに対してテザーが指定されます。
-   テザーは、水平、垂直のいずれかの方向で指定されます。

## <a name="related-articles"></a>関連記事


**サンプル**
* [基本的な入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [待機時間が短い入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [ユーザー操作モードのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)

**サンプルのアーカイブ**
* [入力: XAML ユーザー入力イベントのサンプル](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [入力: デバイス機能のサンプル](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [入力: タッチのヒット テストのサンプル](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [XAML のスクロール、パン、ズームのサンプルに関するページ](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [入力: 簡略化されたインクのサンプル](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [入力: Windows 8 のジェスチャのサンプルに関するページ](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [入力: 操作とジェスチャ (C++) のサンプルに関するページ](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [DirectX タッチ入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 




