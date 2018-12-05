---
Description: Respond to mouse input in your apps by handling the same basic pointer events that you use for touch and pen input.
title: マウス操作
ms.assetid: C8A158EF-70A9-4BA2-A270-7D08125700AC
label: Mouse
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9ad801dee43607b4fb6e75bd30f612682e1214ff
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8734256"
---
# <a name="mouse-interactions"></a>マウス操作


ユニバーサル Windows プラットフォーム (UWP) アプリの設計をタッチ入力用に最適化し、既定の基本的なマウスのサポートを利用します。

 

![マウス](images/input-patterns/input-mouse.jpg)



マウス入力は、ポイントとクリックの正確さが求められるユーザー操作に最適です。 この固有の正確さは、タッチの本来の不正確さに合わせて最適化されている Windows の UI でも当然サポートされています。

マウス入力とタッチ入力が異なるのは、タッチでは UI 要素に対して直接実行される物理的なジェスチャ (スワイプ、スライド、ドラッグ、回転など) を通じて、それらのオブジェクトへの直接の操作をより正確にエミュレートする機能があることです。 マウスによる操作では、オブジェクトのサイズ変更や回転を実行するためにハンドルを使用するなど、他の UI アフォーダンスが必要になることが普通です。

このトピックでは、マウス操作の設計時の考慮事項について説明します。

## <a name="the-uwp-app-mouse-language"></a>UWP アプリのマウス言語


システム内では一貫して、マウス操作の簡単なセットが使われます。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">用語</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>ホバーによる説明の表示</p></td>
<td align="left"><p>要素にホバーすると、詳しい情報や説明を伝える視覚効果 (ヒントなど) が表示されます。操作はコミットされません。</p></td>
</tr>
<tr class="even">
<td align="left"><p>左クリックによるプライマリ操作</p></td>
<td align="left"><p>要素の左クリックにより、プライマリ操作 (アプリの起動、コマンドの実行など) が呼び出されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>スクロールによるビューの変更</p></td>
<td align="left"><p>スクロール バーを表示し、コンテンツ領域内で上下左右に移動します。 スクロール バーのクリック、またはマウス ホイールの回転により、スクロールできます。 スクロール バーは、コンテンツ領域内の現在のビューの位置を示します (タッチによるパンでも同様の UI が表示されます)。</p></td>
</tr>
<tr class="even">
<td align="left"><p>右クリックによる選択とコマンド</p></td>
<td align="left"><p>右クリックして、ナビゲーション バー (使用できる場合) と、グローバル コマンドを含むアプリ バーを表示します。 要素を右クリックして選択し、その要素に対応する状況依存のコマンドを備えたアプリ バーを表示します。</p>
<div class="alert">
<strong>注:</strong>の選択やアプリ バーのコマンドが適切な UI 動作ではない場合は、コンテキスト メニューを表示するを右クリックします。 ただし、すべてのコマンド動作にアプリ バーを使うことを強くお勧めします。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>ズームの UI コマンド</p></td>
<td align="left"><p>アプリ バーに UI コマンドを表示するか (+、- など)、Ctrl キーを押しながらマウス ホイールを回転させて、ズームのためのピンチ ジェスチャとストレッチ ジェスチャをエミュレートします。</p></td>
</tr>
<tr class="even">
<td align="left"><p>回転の UI コマンド</p></td>
<td align="left"><p>アプリ バーに UI コマンドを表示するか、Ctrl キーと Shift キーを押しながらマウス ホイールを回転させて、回転のための回転ジェスチャをエミュレートします。 画面全体を回転させるには、デバイスを回転させます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>左クリックとドラッグによる移動</p></td>
<td align="left"><p>要素を左クリックしてドラッグし、移動します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>左クリックとドラッグによるテキストの選択</p></td>
<td align="left"><p>選択可能なテキスト内を左クリックしてドラッグし、選択します。 単語を選択するには、ダブルクリックします。</p></td>
</tr>
</tbody>
</table>

## <a name="mouse-events"></a>マウス イベント

アプリでマウス入力に応答するには、タッチ入力やペン入力で使うのと同じ基本的なポインター イベントを処理します。

[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) イベントを使うと、ポインター入力デバイスごとに別々のコードを記述しなくても、基本的な入力機能を実装できます。 ただし、このオブジェクトのポインター イベント、ジェスチャ イベント、操作イベントを使って、各デバイスの特別な機能 (マウス ホイール イベントなど) を利用することもできます。

**サンプル:** この機能では、[アプリのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=264996)の動作を参照してください。


- [入力: デバイス機能のサンプル](https://go.microsoft.com/fwlink/p/?linkid=231530)

- [入力サンプル](https://go.microsoft.com/fwlink/p/?linkid=226855)

- [入力: GestureRecognizer によるジェスチャと操作](https://go.microsoft.com/fwlink/p/?LinkID=231605)

## <a name="guidelines-for-visual-feedback"></a>視覚的なフィードバックのガイドライン


-   移動イベントまたはホバー イベントを通じてマウスが検出されたら、マウス固有の UI を表示して、要素によって公開されている機能を示します。 マウスが一定の期間動かされなかった場合や、ユーザーがタッチ操作を始めた場合は、マウス UI を徐々に非表示にします。 これにより、UI の簡潔さが保たれます。
-   ホバーのフィードバックにカーソルを使わないでください。要素によるフィードバックで十分です (以下の「カーソル」をご覧ください)。
-   静的テキストなど、要素で対話式操作がサポートされていない場合は、視覚的なフィードバックを返さないでください。
-   マウス操作ではフォーカス用の四角形を使わないでください。 これはキーボード操作専用です。
-   同じ入力対象を表すすべての要素に対して視覚的なフィードバックを同時に表示します。
-   パン、回転、ズームなど、タッチ ベースの操作をエミュレートするためのボタンを提供します (+、- など)。

視覚的なフィードバックに関する一般的なガイダンスについては、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。


## <a name="cursors"></a>カーソル


マウス ポインターとして利用できる標準のカーソル セットが用意されています。 これらが要素のプライマリ操作を示すために使われます。

標準のカーソルには、それぞれ対応する既定の画像が関連付けられています。 ユーザーまたはアプリは、標準のカーソルに関連付けられている既定の画像をいつでも変更できます。 カーソル画像は、[**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) 関数を使って指定します。

マウス カーソルをカスタマイズする必要がある場合は、以下のガイドラインに従ってください。

-   クリック可能な要素には常に矢印カーソル (![矢印カーソル](images/cursor-arrow.png)) を使います。 リンクなどのインタラクティブな要素には手の形のポインティング カーソル (![手の形のポインティング カーソル](images/cursor-pointinghand.png)) を使いません。 代わりに、前に説明したホバー効果を使います。
-   選択可能なテキストにはテキスト カーソル (![テキスト カーソル](images/cursor-text.png)) を使います。
-   ドラッグやトリミングなど、移動がメインの操作である場合は、移動カーソル (![移動カーソル](images/cursor-move.png)) を使います。 スタート画面のタイルなどでのナビゲーションがメインの操作である場合は、要素に対して移動カーソルを使いません。
-   サイズ変更ができるオブジェクトに対しては、横、縦、対角線のサイズ変更カーソル (![縦のサイズ変更カーソル](images/cursor-vertical.png), ![横のサイズ変更カーソル](images/cursor-horizontal.png), ![対角線のサイズ変更カーソル (左下、右上)](images/cursor-diagonal2.png), ![対角線のサイズ変更カーソル (左上、右下)](images/cursor-diagonal1.png)) を使います。
-   地図など、固定キャンバス内のコンテンツのパンを行うときは、手でつかむ形のカーソル (![手でつかむ形のカーソル (開いた状態)](images/cursor-pan1.png), ![手でつかむ形のカーソル (つかんだ状態)](images/cursor-pan2.png)) を使います。

## <a name="related-articles"></a>関連記事

* [ポインター入力の処理](handle-pointer-input.md)
* [入力デバイスの識別](identify-input-devices.md)

**サンプル**
* [基本的な入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [待機時間が短い入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [ユーザー操作モードのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)

**サンプルのアーカイブ**
* [入力: デバイス機能のサンプル](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [入力: XAML ユーザー入力イベントのサンプル](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [XAML のスクロール、パン、ズームのサンプル](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [入力: GestureRecognizer によるジェスチャと操作](https://go.microsoft.com/fwlink/p/?LinkID=231605)
 
 

 




