---
author: Jwmsft
title: "分割ビュー"
ms.assetid: E9E4537F-1160-4183-9A83-26602FCFDC9A
description: "分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。"
label: Split view
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: eb6744968a4bf06a3766c45b73b428ad690edc06
ms.openlocfilehash: 7fae1477b997508ade92a5bbb977c1d6530a181f

---
# 分割ビュー コントロール

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li><a href="https://msdn.microsoft.com/library/windows/apps/dn864360"><strong>SplitView クラス (XAML)</strong></a></li>
<li><a href="https://msdn.microsoft.com/library/windows/apps/dn919970"><strong>SplitView オブジェクト (HTML)</strong></a></li>
</ul>

</div>
</div>




 分割ビューのコンテンツ領域は常に表示されます。 ウィンドウは展開/折りたたみを行うことも、開いた状態のままにすることもでき、アプリ ウィンドウの右側または左側から表示できます。 このウィンドウには 4 つのモードがあります。

-   **オーバーレイ**

    ウィンドウは開くまで表示されません。 開くと、ウィンドウはコンテンツ領域をオーバーレイします。

-   **インライン**

    ウィンドウは常に表示され、コンテンツ領域をオーバーレイしません。 画面領域はウィンドウとコンテンツ領域に分割されます。

-   **CompactOverlay**

    このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。 閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。 ウィンドウを開くと、ウィンドウはコンテンツ領域をオーバーレイします。

-   **CompactInline**

    このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。 閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。 ウィンドウを開くと、コンテンツを押しのけるようにして、コンテンツの利用可能な領域が小さくなります。

## 適切なコントロールの選択

分割ビュー コントロールは、[ナビゲーション ウィンドウ](nav-pane.md)の作成に使うことができます。 このパターンを構築するには、展開/折りたたみボタン ("ハンバーガー" ボタン) とナビゲーション項目を表すリスト ビューを追加する必要があります。

分割ビュー コントロールを使って、ユーザーが補足的なウィンドウを開いたり閉じたりできる "引き出し" エクスペリエンスを作成することもできます。

## 例

既定の形式の分割ビュー コントロールは、基本的なコンテナーです。 SplitView を使ってハブを表示する Microsoft Edge アプリの例を次に示します。

![Microsoft Edge の分割ビューの例](images/split_view_Edge.png)



## 関連トピック


* [ナビゲーション ウィンドウ パターン](nav-pane.md)
* [リスト ビュー](lists.md)
 

 



<!--HONumber=Aug16_HO3-->


