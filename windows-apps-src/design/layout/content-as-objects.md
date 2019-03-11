---
description: ''
title: オブジェクトとしてのコンテンツ
template: detail.hbs
ms.localizationpriority: medium
ms.openlocfilehash: ed2ac8530d69929cc0e0e921cfb1cc5368058cd2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593117"
---
# <a name="content-as-objects"></a>オブジェクトとしてのコンテンツ

 

要素の深度、つまり z オーダーを操作し、視覚的な階層を作成すると、アプリを簡単に使用できるようになります。  

> 注:この記事では、Windows 10 RS2 の新機能の初期ドラフトです。 機能名、用語、および機能は最終版ではありません。 

## <a name="why-visual-hierarchy-is-important"></a>視覚的な階層が重要な理由

注意を必要とする要求が絶えず表示されます。 画面上のすべての要素が表示され、テキストのすべての文字列が読み取れ、すべてのボタンがクリックできます。 視覚的な環境がより混乱かつ複雑になるにつれて、状況を把握し、何が起こっているかを理解するのに時間がかかります。  

このため、ユーザー インターフェイスの要素を慎重に選択し、UI 要素間で分かりやすい視覚的な階層を確立するレイアウトを作成することが重要です。 <!-- Every element is competing for the user's attention, and every time you add an element, you add a mental tax to the user. -->

視覚的な階層を分かりやすくすると、最も重要な要素が明確になり、要素間の関係が確立されます。 視覚的な階層が優れていると、ページのレイアウトを一目で理解し、実行しようとしているタスクに集中できます。 

<p></p>


<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
  <p>それでは、分かりやすい視覚的な階層はどのように作成するのでしょうか。 以前のバージョンの Windows 10 では、視覚的な階層を定義するために、空白、位置、および文字体裁を使用することができました。 </p>
  </div>
  <div class="side-by-side-content-right">
    <a href="images/content-as-objects/flat-layout.png">フラットなレイアウト</a>
    
  </div>
</div>
</div>

Windows 10 RS2 では、深度という文字通り別の次元が追加されました。 

<a href="images/content-as-objects/depth-in-layout2.png">レイアウト内での深度</a>


## <a name="use-depth-to-establish-a-hierarchy"></a>深度を使用して階層を確立する 

<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
     <p>深度 (z オーダー) を他のデザイン ツール (空白、位置、文字体裁) と共に使用すると、階層を確立できます。 最も重要な要素を一番手前のレイヤーに昇格します。重要度の低い UI を表示するには、下位のレイヤーを使用します。 

    The relative importance of an element can change throughout an experience, so you can bring elements forward as they become more important and backward as they become less important. 
    </p>
  </div>
  <div class="side-by-side-content-right">
    <a href="images/content-as-objects/elements-forward-backward.png">レイアウト内での深度</a> 
    
  </div>
</div>
</div>

## <a name="how-does-it-work"></a>その場合、どのように処理されますか?
> TODO:要素の z オーダーを制御する方法の簡単な説明。 z オーダーを明示的にハードコードするために、セマンティック ランク付けシステムはありますか? 項目を 1 つのレイヤーから別のレイヤーにどのように移動しますか? システムが自動的に処理する内容、デザイナー/開発者が気を付けることは何ですか? 

## <a name="the-four-layers-of-a-typical-app-layers"></a>一般的なアプリの 4 つのレイヤー

<p>一般的なアプリには 4 つのレイヤーがあります。</p>
<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<b>バック グラウンドを超えて</b>アプリの背後にあるこのレイヤーに存在します。  要素をこのレイヤーに移動する場合は、非対話型の要素にすることをお勧めします。 このレイヤーの要素は、視差が最も少なく、アプリ ウィンドウにクリップされます。 TODO:この層はスケールですか。 

<p>背景要素の例では、コンテンツ、TODO の背後にあるイメージを含めます。例では、TODO:例です。</p>
  </div>
  <div class="side-by-side-content-right">
    <a href="images/content-as-objects/elements-forward-backward.png">以外にも、アプリのレイヤーをバック グラウンドします。</a>
    
  </div>
</div>
</div>

<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<b>パッシブ レイヤー</b>アプリの基本レイヤーは、この既定ではどこで UI 要素。  要素はこのレイヤー上をリアルタイムに移動し (視差なし)、アプリ ウィンドウにクリップされます。倍率は 100% です。 

<p>要素の例:アプリの背景、テキスト、アプリのナビゲーション UI などのセカンダリ UI。</p>
  </div>
  <div class="side-by-side-content-right">
    <a href="images/content-as-objects/elements-forward-backward.png">アプリのパッシブ レイヤー</a>
    
  </div>
</div>
</div>

<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<b>行動喚起</b>この層はパッシブ レイヤー要素の上に優先する対話型の項目。 このレイヤーの要素は、中程度の視差があり、アプリ ウィンドウにクリップされます。 TODO:この層のスケールの要素のドロップ シャドウがあるか

<p>要素の例: リスト、グリッド、主要なコマンド (TODO:Such as.)。</p> 
  </div>
  <div class="side-by-side-content-right">
    <a href="images/content-as-objects/elements-forward-backward.png">アプリのアクション呼び出しレイヤー</a>
    
  </div>
</div>
</div>

<p></p>
<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<b>Hero レイヤー</b>時にこのレイヤーでは、画面上の最高の優先度要素をします。  このレイヤーの要素はアプリ ウィンドウの境界を分割したり、拡大縮小したり、ドロップ シャドウを自動的に追加したりできます。

<p>要素の例: 写真要素、現在選択されている項目。</p>  
  </div>
  <div class="side-by-side-content-right">
    <a href="images/content-as-objects/elements-forward-backward.png">アプリのヒーロー レイヤー</a>
    
  </div>
</div>
</div>



<!--
Depth is meaningful; it establishes visual and interactive hierarchy for users to efficiently complete tasks. Depth orients users in our system. 
-->

## <a name="example-tbd"></a>以下に例を示します。TBD
> TODO:Z オーダーを使用する一般的な UI パターンを調整する方法を示します。 図とコードを示す必要があります。 

## <a name="download-the-code-samples"></a>コード サンプルのダウンロード
>TODO:この機能を示すサンプルへのリンクします。 


## <a name="related-articles"></a>関連記事
* [コンテンツの基本](../basics/content-basics.md)
