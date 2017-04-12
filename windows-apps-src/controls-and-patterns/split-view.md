---
author: Jwmsft
title: "分割ビュー"
ms.assetid: E9E4537F-1160-4183-9A83-26602FCFDC9A
description: "分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。"
label: Split view
template: detail.hbs
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b7488f19109925faa2c9e6b3be528cb2d19846e8
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="split-view-control"></a>分割ビュー コントロール

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**SplitView クラス**](https://msdn.microsoft.com/library/windows/apps/dn864360)</li>
</ul>
</div>

SplitView を使ってハブを表示する Microsoft Edge アプリの例を次に示します。

![Microsoft Edge の分割ビューの例](images/split_view_Edge.png)


 分割ビューのコンテンツ領域は常に表示されます。 ウィンドウは展開/折りたたみを行うことも、開いた状態のままにすることもでき、アプリ ウィンドウの右側または左側から表示できます。 このウィンドウには 4 つのモードがあります。

-   **オーバーレイ**

    ウィンドウは開くまで表示されません。 開くと、ウィンドウはコンテンツ領域をオーバーレイします。

-   **インライン**

    ウィンドウは常に表示され、コンテンツ領域をオーバーレイしません。 画面領域はウィンドウとコンテンツ領域に分割されます。

-   **CompactOverlay**

    このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。 閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。 ウィンドウを開くと、ウィンドウはコンテンツ領域をオーバーレイします。

-   **CompactInline**

    このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。 閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。 ウィンドウを開くと、コンテンツを押しのけるようにして、コンテンツの利用可能な領域が小さくなります。

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

分割ビュー コントロールは、[ナビゲーション ウィンドウ](nav-pane.md)の作成に使うことができます。 このパターンを構築するには、展開/折りたたみボタン ("ハンバーガー" ボタン) とナビゲーション項目を表すリスト ビューを追加する必要があります。

分割ビュー コントロールを使って、ユーザーが補足的なウィンドウを開いたり閉じたりできる "引き出し" エクスペリエンスを作成することもできます。

## <a name="create-a-split-view"></a>分割ビューの作成

以下は、Content の横にインラインでオープン状態の Pane を表示する SplitView コントロールのコードです。
```xaml
<SplitView IsPaneOpen="True"
           DisplayMode="Inline"
           OpenPaneLength="296">
    <SplitView.Pane>
        <TextBlock Text="Pane"
                   FontSize="24"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"/>
    </SplitView.Pane>

    <Grid>
        <TextBlock Text="Content"
                   FontSize="24"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"/>
    </Grid>
</SplitView>
```



## <a name="related-topics"></a>関連トピック
* [ナビゲーション ウィンドウ パターン](nav-pane.md)
* [リスト ビュー](lists.md)
 

 
