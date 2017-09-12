---
author: mijacobs
title: "画面のサイズとレスポンシブ デザインのブレークポイント"
description: .
ms.assetid: BF42E810-CDC8-47D2-9C30-BAA19DCBE2DA
label: Screen sizes and break points
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b56cdeeb9a3c3d3ca89e19d8057e3d93241e6c3c
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
#  <a name="screen-sizes-and-break-points-for-responsive-design"></a>画面のサイズとレスポンシブ デザインのブレークポイント

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

対象デバイスと、Windows 10 エコシステム全体での画面サイズの数はあまりに多いため、そのそれぞれのために UI を最適化しても意味がありません。 その代わり、360、640、1024、および 1366 epx という 4 種類の主要なキー幅 ("ブレークポイント" とも呼ばれます) を設計することをお勧めします。

> [!TIP]
> 特定のブレークポイント向けに設計するときは、アプリ (アプリのウィンドウ) で使用できる画面領域の量向けに設計します。 アプリが全画面表示で実行されているときは、アプリ ウィンドウが画面と同じサイズですが、それ以外の状況では、画面より小さいサイズです。
 

次の表は、さまざまなサイズ クラスを説明し、これらのサイズ クラスを調整するため一般的な推奨事項を示します。

![レスポンシブ デザインのブレークポイント](images/rsp-design/rspd-breakpoints.png)

<table>
<colgroup>
<col width="25%" />
<col width="25%" />
<col width="25%" />
<col width="25%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">サイズ クラス</th>
<th align="left">小</th>
<th align="left">中</th>
<th align="left">大</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;">一般的な画面サイズ (対角線)</td>
<td style="vertical-align:top;">4&quot; ～ 6"&quot;</td>
<td style="vertical-align:top;">7&quot; ～ 12&quot;、またはテレビ</td>
<td style="vertical-align:top;">13&quot; 以上</td>
</tr>
<tr class="even">
<td style="vertical-align:top;">一般的なデバイス</td>
<td style="vertical-align:top;">電話</td>
<td style="vertical-align:top;">ファブレット、タブレット、テレビ</td>
<td style="vertical-align:top;">PC、ノート PC、Surface Hub</td>
</tr>
<tr class="odd">
<td style="vertical-align:top;">有効なピクセル単位の一般的なウィンドウ サイズ</td>
<td style="vertical-align:top;">320 x 569、360 x 640、480 x 854</td>
<td style="vertical-align:top;">960 x 540、1024 x 640</td>
<td style="vertical-align:top;">1366 x 768、1920 x 1080</td>
</tr>
<tr class="even">
<td style="vertical-align:top;">有効ピクセル単位でのウィンドウの幅のブレークポイント</td>
<td style="vertical-align:top;">640 ピクセル以下</td>
<td style="vertical-align:top;">641 ピクセル～ 1007 ピクセル</td>
<td style="vertical-align:top;">1008 ピクセル以上</td>
</tr>
<tr class="odd">
<td style="vertical-align:top;">一般的な推奨事項</td>
<td style="vertical-align:top;"><ul>
<li>タブ要素を中央に配置します。</li>
<li>ウィンドウの左右の余白を 12 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</li>
<li>手に届きやすいように[アプリ バー](../controls-and-patterns/app-bars.md)をウィンドウの下部にドッキングします。</li>
<li>一度に 1 列/地域を使います。</li>
<li>検索を表すアイコンを使います (検索ボックスを表示しない)。</li>
<li>[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)をオーバーレイ モードにして画面領域を節約します。</li>
<li>[マスター/詳細要素](../controls-and-patterns/master-details.md)を使用している場合は、上下に並べる表示モードを使用して画面領域を節約します。</li>
</ul></td>
<td style="vertical-align:top;"><ul>
<li>タブ要素を左揃えにします。</li>
<li>ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</li>
<li>[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</li>
<li>最大 2 列/領域</li>
<li>検索ボックスを表示します。</li>
<li>アイコンの幅の狭いストリップが常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を小片モードにします。</li>
<li>[テレビのエクスペリエンス](http://go.microsoft.com/fwlink/?LinkId=760736)の調整を検討します。</li>
</ul></td>
<td style="vertical-align:top;"><ul>
<li>タブ要素を左揃えにします。</li>
<li>ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</li>
<li>[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</li>
<li>最大 3 列/領域</li>
<li>検索ボックスを表示します。</li>
<li>常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を固定モードにします。</li>
</ul></td>
</tr>
</tbody>
</table>

互換性のある Windows 10 Mobile デバイスの新しいエクスペリエンスである[**電話用 Continuum**](http://go.microsoft.com/fwlink/p/?LinkID=699431) を利用すると、ユーザーは電話をモニター、マウス、およびキーボードに接続して、その電話をノート PC のように使うことができます。 特定のブレークポイント向けに設計するときは、この新機能に注意してください。携帯電話が常に小さいサイズのクラスで維持されるわけではありません。
 
