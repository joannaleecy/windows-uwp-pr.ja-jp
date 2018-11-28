---
title: 画面のサイズとレスポンシブ デザインのブレークポイント
description: Windows 10 エコシステムの多くのデバイス用に UI を最適化するのではなく、ブレークポイントと呼ばれるいくつかの主要な幅カテゴリ用に設計することをお勧めします。
ms.date: 08/30/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 0959c9bc09782538cdb15a68c46b0797d4b7d230
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7849716"
---
#  <a name="screen-sizes-and-breakpoints"></a>画面のサイズとブレークポイント

UWP アプリは、Windows 10 を実行している任意のデバイスで実行できます (電話、タブレット、デスクトップ、テレビなど)。 膨大な数の対象デバイスとデバイスごとに、UI を最適化するのではなく、windows 10 エコシステム全体での画面サイズ、ことお勧めします (「ブレークポイント」とも呼ばれます)、いくつかの主要な幅カテゴリ用に設計します。 
- 小 (640 ピクセル以下)
- 中 (641 ピクセル ～ 1007 ピクセル)
- 大 (1008 ピクセル以上)

> [!TIP]
> 特定のブレークポイント向けに設計するときは、画面のサイズではなく、アプリ (アプリのウィンドウ) で使用できる画面領域の量に対して設計します。 アプリが全画面表示で実行されているときは、アプリ ウィンドウのサイズは画面と同じですが、アプリが全画面表示でないときは、ウィンドウは画面より小さくなります。

## <a name="breakpoints"></a>ブレークポイント
次の表で、さまざまなサイズ クラスとブレークポイントについて説明します。

![レスポンシブ デザインのブレークポイント](images/breakpoints/size-classes.svg)

<table>
<thead>
<tr class="header">
<th align="left">サイズ クラス</th>
<th align="left">ブレークポイント</th>
<th align="left">一般的な画面サイズ (対角線)</th>
<th align="left">デバイス</th>
<th align="left">ウィンドウ サイズ</th>
</tr>
</thead>
<tbody>
<tr class="even">
<td style="vertical-align:top;">小</td>
<td style="vertical-align:top;">640 ピクセル以下</td>
<td style="vertical-align:top;">4&quot; ～ 6&quot;; 20&quot; ～ 65&quot;</td>
<td style="vertical-align:top;">電話、テレビ</td>
<td style="vertical-align:top;">320 x 569、360 x 640、480 x 854</td>
</tr>
<tr class="odd">
<td style="vertical-align:top;">中</td>
<td style="vertical-align:top;">641 ピクセル～ 1007 ピクセル</td>
<td style="vertical-align:top;">7&quot; ～ 12&quot;</td>
<td style="vertical-align:top;">ファブレット、タブレット</td>
<td style="vertical-align:top;">960 x 540</td>
</tr>
<tr class="even">
<td style="vertical-align:top;">大</td>
<td style="vertical-align:top;">1008 ピクセル以上</td>
<td style="vertical-align:top;">13&quot; 以上</td>
<td style="vertical-align:top;">PC、ノート PC、Surface Hub</td>
<td style="vertical-align:top;">1024 x 640、1366 x 768、1920 x 1080</td>
</tr>
</tbody>
</table>

## <a name="why-are-tvs-considered-small"></a>なぜテレビは「小さい」と見なされるのですか。 

ほとんどのテレビは物理的に非常に大きく (40 から 65 インチが一般的)、高解像度 (HD または 4K) ですが、10 フィート (約 3 m) 離れた場所から表示する 1080P のテレビの設計は、机上の 1 フィート (約 30 cm) 離れた場所に置かれる 1080p のモニターの設計とは異なります。 距離を考慮するときに、テレビの 1080 ピクセルは 540 ピクセルのモニターにより近くなります。

UWP の有効ピクセルのシステムでは、視聴距離を自動的に考慮します。 コントロールまたはブレークポイントの範囲のサイズを指定するときは、実際には "有効" ピクセルを使用しています。 たとえば、1080 ピクセル以上に対応するコードを作成する場合は、1080 モニターでそのコードを使用しますが、1080p のテレビでは使用しません。これは、1080p のテレビの物理ピクセルは 1080 ですが、有効ピクセルは 540 しかないためです。 このため、テレビの設計は、携帯電話の設計に似ています。

## <a name="effective-pixels-and-scale-factor"></a>有効ピクセルと倍率

UWP アプリは、すべての Windows 10 デバイスでアプリが判読可能であることを保証するために、UI を自動的に拡大縮小します。 Windows では、ディスプレイの DPI (1 インチあたりのドット数) と、デバイスの視聴距離に基づいて各ディスプレイが自動的に拡大縮小されます。 ユーザーは、**[設定]** > **[ディスプレイ]** > **[拡大縮小とレイアウト]** の設定ページに移動して既定値を上書きできます。 


## <a name="general-recommendations"></a>一般的な推奨事項

### <a name="small"></a>小
- ウィンドウの左右の余白を 12 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。
- 手に届きやすいように[アプリ バー](../controls-and-patterns/app-bars.md)をウィンドウの下部にドッキングします。
- 一度に 1 つの列/領域を使用します。
- 検索を表すアイコンを使います (検索ボックスを表示しない)。
- [ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)をオーバーレイ モードにして画面領域を節約します。
- [マスター/詳細要素](../controls-and-patterns/master-details.md)を使用している場合は、上下に並べる表示モードを使用して画面領域を節約します。

### <a name="medium"></a>中
- ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。
- [アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。
- 最大で 2 つの列/領域を使用します。
- 検索ボックスを表示します。
- アイコンの幅の狭いストリップが常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を小片モードにします。
- [テレビのエクスペリエンス](http://go.microsoft.com/fwlink/?LinkId=760736)の調整を検討します。

### <a name="large"></a>大
- ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。
- [アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。
- 最大で 3 つの列/領域を使用します。
- 検索ボックスを表示します。
- 常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を固定モードにします。

>[!TIP] 
> [**ある電話用 Continuum**](http://go.microsoft.com/fwlink/p/?LinkID=699431)ユーザーはその電話をノートのように機能するモニター、マウス、キーボードに互換性のある windows 10 のモバイル デバイスを接続できます。 特定のブレークポイント向けに設計するときは、この新機能に注意してください。携帯電話が常にそのサイズ クラスで維持されるわけではありません。


