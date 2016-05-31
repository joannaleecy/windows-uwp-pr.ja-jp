---
author: Jwmsft
title: 分割ビュー
ms.assetid: E9E4537F-1160-4183-9A83-26602FCFDC9A
description: 分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。
label: Split view
template: detail.hbs
---

# SplitView コントロールのガイドライン



**重要な API**

-   [**SplitView クラス (XAML)**](https://msdn.microsoft.com/library/windows/apps/dn864360)
-   [**SplitView オブジェクト (HTML)**](https://msdn.microsoft.com/library/windows/apps/dn919970)

分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。 コンテンツ領域は常に表示されます。 ウィンドウは展開/折りたたみを行うことも、開いた状態のままにすることもでき、アプリ ウィンドウの右側または左側から表示できます。 このウィンドウには 4 つのモードがあります。

-   **オーバーレイ**

    ウィンドウは開くまで表示されません。 開くと、ウィンドウはコンテンツ領域をオーバーレイします。

-   **インライン**

    ウィンドウは常に表示され、コンテンツ領域をオーバーレイしません。 画面領域はウィンドウとコンテンツ領域に分割されます。

-   **CompactOverlay**

    このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。 閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。 ウィンドウを開くと、ウィンドウはコンテンツ領域をオーバーレイします。

-   **CompactInline**

    このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。 閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。 ウィンドウを開くと、コンテンツを押しのけるようにして、コンテンツの利用可能な領域が小さくなります。

## <span id="Is_this_the_right_control_"></span><span id="is_this_the_right_control_"></span><span id="IS_THIS_THE_RIGHT_CONTROL_"></span>適切なコントロールの選択

分割ビュー コントロールは、[ナビゲーション ウィンドウ](nav-pane.md)の作成に使うことができます。 このパターンを構築するには、展開/折りたたみボタン ("ハンバーガー" ボタン) とナビゲーション項目を表すリスト ビューを追加する必要があります。

分割ビュー コントロールを使って、ユーザーが補足的なウィンドウを開いたり閉じたりできる "引き出し" エクスペリエンスを作成することもできます。

## <span id="Examples"></span><span id="examples"></span><span id="EXAMPLES"></span>例

既定の形式の分割ビュー コントロールは、基本的なコンテナーです。 SplitView を使ってハブを表示する Microsoft Edge アプリの例を次に示します。

![Microsoft Edge の分割ビューの例](images/split_view_Edge.png)



## <span id="related_topics"></span>関連トピック


* [ナビゲーション ウィンドウ パターン](nav-pane.md)
* [リスト ビュー](lists.md)
 

 


<!--HONumber=May16_HO2-->


