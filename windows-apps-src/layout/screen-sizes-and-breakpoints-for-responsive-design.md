---
author: mijacobs
title: "画面のサイズとレスポンシブ デザインのブレークポイント"
description: .
ms.assetid: BF42E810-CDC8-47D2-9C30-BAA19DCBE2DA
label: Screen sizes and break points
template: detail.hbs
ms.sourcegitcommit: a4e9a90edd2aae9d2fd5d7bead948422d43dad59
ms.openlocfilehash: 153652c9fcc9745bdee087033d65eec2bc860e53

---

#  画面のサイズとレスポンシブ デザインのブレークポイント

対象デバイスと、Windows 10 エコシステム全体での画面サイズの数はあまりに多いため、そのそれぞれのために UI を最適化しても意味がありません。 その代わり、360、640、1024、および 1366 epx という 4 種類の主要なキー幅 ("ブレークポイント" とも呼ばれます) を設計することをお勧めします。


            **ヒント**  特定のブレークポイント向けに設計するときは、アプリ (アプリのウィンドウ) で使用できる画面領域の量向けに設計します。 アプリが全画面表示で実行されているときは、アプリ ウィンドウが画面と同じサイズですが、それ以外の状況では、画面より小さいサイズです。
 

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
<td align="left">一般的な画面サイズ (対角線)</td>
<td align="left">4&quot; ～ 6"&quot;</td>
<td align="left">7&quot; ～ 12&quot;、またはテレビ</td>
<td align="left">13&quot; 以上</td>
</tr>
<tr class="even">
<td align="left">一般的なデバイス</td>
<td align="left">電話</td>
<td align="left">ファブレット、タブレット、テレビ</td>
<td align="left">PC、ノート PC、Surface Hub</td>
</tr>
<tr class="odd">
<td align="left">有効なピクセル単位の一般的なウィンドウ サイズ</td>
<td align="left">320 x 569、360 x 640、480 x 854</td>
<td align="left">960 x 540、1024 x 640</td>
<td align="left">1366 x 768、1920 x 1080</td>
</tr>
<tr class="even">
<td align="left">有効ピクセル単位でのウィンドウの幅のブレークポイント</td>
<td align="left">640 ピクセル以下</td>
<td align="left">641 ピクセル～ 1007 ピクセル</td>
<td align="left">1008 ピクセル以上</td>
</tr>
<tr class="odd">
<td align="left" valign="top">一般的な推奨事項</td>
<td align="left" valign="top"><ul>
<li>タブ要素を中央に配置します。</li>
<li>ウィンドウの左右の余白を 12 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</li>
<li>手に届きやすいように[アプリ バー](../controls-and-patterns/app-bars.md)をウィンドウの下部にドッキングします。</li>
<li>一度に 1 列/地域を使います。</li>
<li>検索を表すアイコンを使います (検索ボックスを表示しない)。</li>
<li>[ナビゲーション ウィンドウ](../controls-and-patterns/nav-pane.md)をオーバーレイ モードにして画面領域を節約します。</li>
<li>[マスター/詳細要素](../controls-and-patterns/master-details.md)を使用している場合は、上下に並べる表示モードを使用して画面領域を節約します。</li>
</ul></td>
<td align="left" valign="top"><ul>
<li>タブ要素を左揃えにします。</li>
<li>ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</li>
<li>[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</li>
<li>最大 2 列/領域</li>
<li>検索ボックスを表示します。</li>
<li>アイコンの幅の狭いストリップが常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/nav-pane.md)を小片モードにします。</li>
<li>[テレビのエクスペリエンス](http://go.microsoft.com/fwlink/?LinkId=760736)の調整を検討します。</li>
</ul></td>
<td align="left" valign="top"><ul>
<li>タブ要素を左揃えにします。</li>
<li>ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</li>
<li>[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</li>
<li>最大 3 列/領域</li>
<li>検索ボックスを表示します。</li>
<li>常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/nav-pane.md)を固定モードにします。</li>
</ul></td>
</tr>
</tbody>
</table>

互換性のある Windows 10 Mobile デバイスの新しいエクスペリエンスである[**電話用 Continuum**](http://go.microsoft.com/fwlink/p/?LinkID=699431) を利用すると、ユーザーは電話をモニター、マウス、およびキーボードに接続して、その電話をノート PC のように使うことができます。 特定のブレークポイント向けに設計するときは、この新機能に注意してください。携帯電話が常に小さいサイズのクラスで維持されるわけではありません。
 



<!--HONumber=Jun16_HO4-->


