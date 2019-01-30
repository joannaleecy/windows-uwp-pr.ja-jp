---
Description: Panning and scrolling allows users to reach content that extends beyond the bounds of the screen.
title: スクロール ビューアー コントロール
ms.assetid: 1BFF0E81-BF9C-43F7-95F6-EFC6BDD5EC31
label: Scrollbars
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10、UWP
pm-contact: Abarlow, pagildea
design-contact: ksulliv
dev-contact: regisb
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 88b35c4ebc7e3b3f5c047ed5e1cef9d46a011909
ms.sourcegitcommit: a60ab85e9f2f9690e0141050ec3aa51f18ec61ec
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/30/2019
ms.locfileid: "9037024"
---
# <a name="scroll-viewer-controls"></a>スクロール ビューアー コントロール



1 つの領域には収まらない UI コンテンツがある場合は、スクロール ビューアー コントロールを使用します。

> **重要な API**: [ScrollViewer クラス](https://msdn.microsoft.com/library/windows/apps/br209527)、[ScrollBar クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.scrollbar.aspx)

スクロール ビューアーにより、ビューポート (表示可能な領域) の境界外のコンテンツを拡張表示できるようになります。 ユーザーはこのコンテンツを表示するために、タッチ、マウス ホイール、キーボード、ゲームパッドでスクロール ビューアーのサーフェスを操作します。またはマウスやペン カーソルでスクロール ビューアーのスクロールバーを操作します。 以下の画像に、スクロール ビューアー コントロールの例をいくつか示します。

![標準的なスクロールバー コントロールを示すスクリーンショット](images/ScrollBar_Standard.jpg)

状況によって、スクロール ビューアーのスクロールバーは 2 つの視覚化を使用します (以下の画像参照)。左がパン インジケーター、右が従来のスクロールバーです。

![標準的なスクロールバーとパン インジケーター コントロールの外観のサンプル](images/SCROLLBAR.png)

スクロール ビューアーはユーザーの入力方式を理解して、どの視覚化を表示すればよいか判断します。

* たとえば、スクロールバーが直接操作されずに領域がスクロールされると、パン インジケーターが表示されて現在のスクロール位置が示されます。
* マウスかペン カーソルがパン インジケーターの上に移動すると、パン インジケーターが従来のスクロール バーに変形します。  スクロールバーのつまみをドラッグすると、スクロール領域が操作されます。

<!--
<div class="microsoft-internal-note">
See complete redlines in [UNI]http://uni/DesignDepot.FrontEnd/#/ProductNav/3378/0/dv/?t=Windows|Controls|ScrollControls&f=RS2
</div>
-->

![スクロールバーの動作](images/conscious-scroll.gif)

> [!NOTE]
> スクロールバーは、表示されると ScrollViewer 内のコンテンツの上部に 16 ピクセルでオーバーレイされます。 UX を適切に設計するには、このオーバーレイによってインタラクティブなコンテンツが隠れないようにする必要があります。 また、UX を重複させないようにするには、スクロールバーを考慮してビューポートの端のパディングを 16 ピクセル残すようにしてください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/ScrollViewer">アプリを開き、ScrollViewer の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-scroll-viewer"></a>スクロール ビューアーを作成する

ページに垂直スクロールを追加するには、スクロール ビューアーでページのコンテンツをラップします。

```xaml
<Page
    x:Class="App1.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:App1">

    <ScrollViewer>
        <StackPanel>
            <TextBlock Text="My Page Title" Style="{StaticResource TitleTextBlockStyle}"/>
            <!-- more page content -->
        </StackPanel>
    </ScrollViewer>
</Page>
```

この XAML では、水平方向にスクロールを有効にする、スクロール ビューアーに画像を配置およびズームを有効にする方法を示します。

```xaml
<ScrollViewer ZoomMode="Enabled" MaxZoomFactor="10"
              HorizontalScrollMode="Enabled" HorizontalScrollBarVisibility="Visible"
              Height="200" Width="200">
    <Image Source="Assets/Logo.png" Height="400" Width="400"/>
</ScrollViewer>
```

## <a name="scrollviewer-in-a-control-template"></a>コントロール テンプレートにおける ScrollViewer

ScrollViewer コントロールが他のコントロールの複合パートとして存在するのは一般的です。 ScrollViewer パーツは、サポートのための [ScrollContentPresenter](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollcontentpresenter.aspx) クラスと共に、ホスト コントロールのレイアウト スペースが展開されたコンテンツのサイズより小さく制限されている場合にのみ、スクロールバーと、ビューポートを表示します。 多くの場合、リストがこれに該当するため、[ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx) と [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx) テンプレートは常に ScrollViewer を含めます。 [TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx) と [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) もまたテンプレートに ScrollViewer を含みます。

**ScrollViewer** パーツがコントロール内に存在するとき、ホスト コントロールには通常、特定の入力イベントとコンテンツをスクロールできるようになる操作に対するイベント処理が組み込まれています。 たとえば、GridView がスワイプ ジェスチャを解釈すると、これにより、コンテンツは水平方向にスクロールします。 ホスト コントロールが受け取る入力イベントと直接操作は、コントロールで処理されると見なされ、[PointerPressed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.pointerpressed.aspx) などのより低レベルのイベントは発生せず、どの親コンテナーにもバブル ルーティングされません。 コントロール クラスとイベントの **On*** 仮想メソッドをオーバーライドするか、コントロールを再テンプレート化することで、組み込みのコントロール処理の一部を変更することができます。 ただし、いずれの場合も、元の既定の動作を再現するのは簡単ではありません。この動作では、通常、コントロールはイベントやユーザーの入力動作と入力ジェスチャに予期したとおりに対応します。 そのため、入力イベントの発生が本当に必要かどうかを検討することをお勧めします。 コントロールで処理されない他の入力イベントや入力ジェスチャがあるかどうかを調査して、アプリやコントロール操作の設計では、それらを使う場合があります。

ScrollViewer を含むコントロールが ScrollViewer パーツ内の動作やプロパティの一部に影響を与えることができるように、ScrollViewer ではスタイルで設定でき、テンプレートのバインドで使用できる多数の XAML 添付プロパティを定義します。 添付プロパティについて詳しくは、「[添付プロパティの概要](../../xaml-platform/attached-properties-overview.md)」をご覧ください。

**ScrollViewer の XAML 添付プロパティ**

ScrollViewer では、次の XAML 添付プロパティを定義します。

- [ScrollViewer.BringIntoViewOnFocusChange](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.bringintoviewonfocuschange.aspx)
- [ScrollViewer.HorizontalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.horizontalscrollbarvisibility.aspx)
- [ScrollViewer.HorizontalScrollMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.horizontalscrollmode.aspx)
- [ScrollViewer.IsDeferredScrollingEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.isdeferredscrollingenabled.aspx)
- [ScrollViewer.IsHorizontalRailEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.ishorizontalrailenabled.aspx)
- [ScrollViewer.IsHorizontalScrollChainingEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.ishorizontalscrollchainingenabled.aspx)
- [ScrollViewer.IsScrollInertiaEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.isscrollinertiaenabled.aspx)
- [ScrollViewer.IsVerticalRailEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.isverticalrailenabled.aspx)
- [ScrollViewer.IsVerticalScrollChainingEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.isverticalscrollchainingenabled.aspx)
- [ScrollViewer.IsZoomChainingEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.iszoominertiaenabled.aspx)
- [ScrollViewer.IsZoomInertiaEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.iszoominertiaenabled.aspx)
- [ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibilityproperty.aspx)
- [ScrollViewer.VerticalScrollMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.verticalscrollmode.aspx)
- [ScrollViewer.ZoomMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.zoommode.aspx)

これらの XAML 添付プロパティは、ListView または GridView で既定のテンプレートに ScrollViewer が存在しており、テンプレート パーツにアクセスすることなく、コントロールのスクロール動作に影響を与えられるようにするときなど、ScrollViewer が暗黙的である場合を想定したものです。

たとえば、ListView の組み込みのスクロール ビューアーで垂直スクロールバーが常に表示されるようにする方法を次に示します。

```xaml
<ListView ScrollViewer.VerticalScrollBarVisibility="Visible"/>
```

ScrollViewer が XAML で明示的である場合、コード例に示すように、添付プロパティ構文を使用する必要はありません。 属性構文 (たとえば `<ScrollViewer VerticalScrollBarVisibility="Visible"/>`) を使うだけです。


## <a name="dos-and-donts"></a>推奨と非推奨

- できる限り、水平方向ではなく垂直方向のスクロールを設計してください。
- コンテンツ領域が 1 つのビューポート境界 (垂直方向または水平方向) を超えている場合は、単一軸のパンを使います。 コンテンツ領域が両方のビューポート境界 (垂直方向と水平方向) を超えている場合は、2 軸のパンを使います。
- リスト ビュー、グリッド ビュー、コンボ ボックス、リスト ボックス、テキスト入力ボックス、およびハブ コントロールの組み込みのスクロール機能を使います。 こうしたコントロールでは、同時に表示する項目が多すぎる場合に、ユーザーが項目のリストを水平方向、垂直方向のいずれかにスクロールできます。
- ユーザーがより大きな領域の周囲で両方向にパンすること、そしておそらくズームできるようにする場合、たとえばユーザーが (画面に適合するサイズに設定されたイメージではなく) フル サイズのイメージをパンおよびズームできるようにする場合には、スクロール ビューアー内にイメージを配置します。
- ユーザーが長いテキスト パスをスクロールする場合、垂直方向にのみスクロールするようにスクロール ビューアーを構成します。
- 1 つのオブジェクトのみを含める場合にスクロール ビューアーを使います。 1 つのオブジェクトをレイアウト パネルとし、その任意の数のオブジェクトを含めることができる点に注意してください。
- ピボットのスクロール ロジックが競合するのを避けるため、スクロール ビューアー内には[ピボット](tabs-pivot.md) コントロールを配置しないでください。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形ですべての XAML コントロールを参照できます。

## <a name="related-topics"></a>関連トピック

**開発者向け (XAML)**

* [ScrollViewer クラス](https://msdn.microsoft.com/library/windows/apps/br209527)
