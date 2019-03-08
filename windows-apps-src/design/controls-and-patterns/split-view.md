---
title: 分割ビュー
ms.assetid: E9E4537F-1160-4183-9A83-26602FCFDC9A
description: 分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。
label: Split view
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: yulikl
design-contact: kimsea
dev-contact: tpaine
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 9e0c709261b08231fa82af615d5398fd66648d4e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646467"
---
# <a name="split-view-control"></a>分割ビュー コントロール

分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。

> **重要な Api**:[SplitView クラス](https://msdn.microsoft.com/library/windows/apps/dn864360)

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

分割ビュー コントロールを使って、ユーザーが補足的なウィンドウを開いたり閉じたりできる "引き出し" エクスペリエンスを作成することができます。 たとえば、SplitView を使用して[マスター/詳細](master-details.md)パターンを構築できます。

展開/折りたたみボタンとナビゲーション項目のリストを含むナビゲーション メニューを構築する場合は、[NavigationView](navigationview.md) コントロールを使用します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/SplitView">アプリを開き、SplitView の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></li>
    </ul>
</td>
</tr>
</table>

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

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-topics"></a>関連トピック
- [ナビゲーション ウィンドウのパターン](navigationview.md)
- [リスト ビュー](lists.md)
- [マスター/詳細](master-details.md)