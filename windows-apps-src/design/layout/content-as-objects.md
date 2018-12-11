---
description: ''
title: オブジェクトとしてのコンテンツ
template: detail.hbs
ms.localizationpriority: medium
ms.openlocfilehash: 37ba5093f2d7cfe268be40413b889801daf00967
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8898680"
---
# <a name="content-as-objects"></a>オブジェクトとしてのコンテンツ

 

要素の深度、つまり z オーダーを操作し、視覚的な階層を作成すると、アプリを簡単に使用できるようになります。  

> 注: この記事は、Windows 10 RS2 の新機能に関する初期段階の下書きです。 機能名、用語、および機能は最終版ではありません。 

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
    ![フラット レイアウト](images/content-as-objects/flat-layout.png)
    
  </div>
</div>
</div>

Windows 10 RS2 では、深度という文字通り別の次元が追加されました。 

![レイアウトの深度](images/content-as-objects/depth-in-layout2.png)


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
    ![レイアウトの深度](images/content-as-objects/elements-forward-backward.png) 
    
  </div>
</div>
</div>

## <a name="how-does-it-work"></a>その場合、どのように処理されますか?
> TODO: 要素の z オーダーの制御方法を簡単に説明します。 z オーダーを明示的にハードコードするために、セマンティック ランク付けシステムはありますか? 項目を 1 つのレイヤーから別のレイヤーにどのように移動しますか? システムが自動的に処理する内容、デザイナー/開発者が気を付けることは何ですか? 

## <a name="the-four-layers-of-a-typical-app-layers"></a>一般的なアプリの 4 つのレイヤー

<p>一般的なアプリには 4 つのレイヤーがあります。</p>
<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
  **背景の後** <br/>
このレイヤーはアプリの背後に配置されます。  要素をこのレイヤーに移動する場合は、非対話型の要素にすることをお勧めします。 このレイヤーの要素は、視差が最も少なく、アプリ ウィンドウにクリップされます。 TODO: このレイヤーは拡大縮小しますか? 

<p>背景要素の例には、コンテンツ背後の画像、TODO: 例、TODO: 例が含まれます。</p>
  </div>
  <div class="side-by-side-content-right">
    ![アプリの背景の後のレイヤー](images/content-as-objects/elements-forward-backward.png)
    
  </div>
</div>
</div>

<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
  **パッシブ レイヤー** <br/>
これはアプリの基本レイヤーで、UI 要素が既定で配置されています。  要素はこのレイヤー上をリアルタイムに移動し (視差なし)、アプリ ウィンドウにクリップされます。倍率は 100% です。 

<p>要素の例: アプリの背景、テキスト、アプリ ナビゲーション UI などのセカンダリ UI。</p>
  </div>
  <div class="side-by-side-content-right">
    ![アプリのパッシブ レイヤー](images/content-as-objects/elements-forward-backward.png)
    
  </div>
</div>
</div>

<p></p>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
  **行動喚起** <br/>
このレイヤーは、パッシブ レイヤーの要素よりも上位に順位付けされた対話型の項目向けです。 このレイヤーの要素は、中程度の視差があり、アプリ ウィンドウにクリップされます。 TODO: このレイヤーの要素は拡大縮小しますか、ドロップ シャドウはありますか?

<p>要素の例: リスト、グリッド、プライマリ コマンド (TODO: ...など)。</p> 
  </div>
  <div class="side-by-side-content-right">
    ![アプリの行動喚起レイヤー](images/content-as-objects/elements-forward-backward.png)
    
  </div>
</div>
</div>

<p></p>
<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
  **ヒーロー レイヤー** <br/>
このレイヤーは、そのときの画面上で優先順位の最も高い要素向けです。  このレイヤーの要素はアプリ ウィンドウの境界を分割したり、拡大縮小したり、ドロップ シャドウを自動的に追加したりできます。

<p>要素の例: 写真要素、現在選択されている項目。</p>  
  </div>
  <div class="side-by-side-content-right">
    ![アプリのヒーロー レイヤー](images/content-as-objects/elements-forward-backward.png)
    
  </div>
</div>
</div>



<!--
Depth is meaningful; it establishes visual and interactive hierarchy for users to efficiently complete tasks. Depth orients users in our system. 
-->

## <a name="example-tbd"></a>例: TBD
> TODO: z オーダーを使用する一般的な UI パターンの調整方法を示します。 図とコードを示す必要があります。 

## <a name="download-the-code-samples"></a>コード サンプルのダウンロード
>TODO: この機能を示すサンプルにリンクします。 


## <a name="related-articles"></a>関連記事
* [コンテンツの基本](../basics/content-basics.md)
