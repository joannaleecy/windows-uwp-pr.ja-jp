---
author: Jwmsft
Description: パンとスクロールを行うと、画面の境界外のコンテンツを拡張表示することができます。
title: スクロール バーのガイドライン
ms.assetid: 1BFF0E81-BF9C-43F7-95F6-EFC6BDD5EC31
label: Scroll bars
template: detail.hbs
---
# スクロール バー

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**ScrollViewer クラス**](https://msdn.microsoft.com/library/windows/apps/br209527)
-   [**ZoomMode プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.zoommode.aspx)

パンとスクロールを行うと、画面の境界外のコンテンツを拡張表示することができます。

スクロール ビューアー コントロールは、ビューポート内に適合する量のコンテンツと、一方または両方のスクロール バーからなります。 パンとズームのためにタッチ ジェスチャを使うことができ (操作中にのみスクロール バーはフェードインします)、またスクロールのためにポインターを使うことができます。 フリック ジェスチャでは、慣性を伴ってパンします。

**注**  Windows: 検出された入力デバイスに基づいて、次の 2 種類のパン表示モードが使われます。パン インジケーター (タッチを使う場合) とスクロール バー (マウス、タッチパッド、キーボード、スタイラスなど、その他の入力デバイスを使う場合) です。

![標準的なスクロール バーとパン インジケーター コントロールの外観のサンプル](images/SCROLLBAR.png)

## 例

[
            **ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx) を使って、実際のサイズよりも小さな領域にコンテンツを表示できるようにします。 スクロール ビューアーのコンテンツがまったく表示されないと、スクロール ビューアーは、表示されるコンテンツ領域を移動するためにユーザーが使用できるスクロール バーを表示します。 範囲は、スクロール ビューアーのすべてのコンテンツを指します。** ビューポートは、コンテンツの表示領域を指します。**

![標準的なスクロール バー コントロールを示すスクリーンショット](images/ScrollBar_Standard.jpg)

## スクロール ビューアーを作成する

次の XAML は、スクロール ビューアーに画像を配置し、ズームを有効にする方法を示しています。

```xaml
<ScrollViewer ZoomMode="Enabled" MaxZoomFactor="10" 
              HorizontalScrollMode="Enabled" HorizontalScrollBarVisibility="Visible"
              Height="200" Width="200">
    <Image Source="Assets/Logo.png" Height="400" Width="400"/>
</ScrollViewer>
```

## コントロール テンプレートにおける ScrollViewer

ScrollViewer コントロールが他のコントロールの複合パートとして存在するのは一般的です。 ScrollViewer パーツは、サポートのための [**ScrollContentPresenter**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollcontentpresenter.aspx) クラスと共に、ホスト コントロールのレイアウト スペースが展開されたコンテンツのサイズより小さく制限されている場合にのみ、スクロール バーと、ビューポートを表示します。 多くの場合、リストがこれに該当するため、[**ListView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx) と [**GridView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx) テンプレートは常に ScrollViewer を含めます。 [
              **TextBox**
            ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx) と [**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) もまたテンプレートに ScrollViewer を含みます。

**ScrollViewer** パーツがコントロール内に存在するとき、ホスト コントロールには通常、特定の入力イベントとコンテンツをスクロールできるようになる操作に対するイベント処理が組み込まれています。 たとえば、GridView がスワイプ ジェスチャを解釈すると、これにより、コンテンツは水平方向にスクロールします。 ホスト コントロールが受け取る入力イベントと直接操作は、コントロールで処理されると見なされ、[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.pointerpressed.aspx) などのより低レベルのイベントは発生せず、どの親コンテナーにもバブル ルーティングされません。 コントロール クラスとイベントの **On*** 仮想メソッドをオーバーライドするか、コントロールを再テンプレート化することで、組み込みのコントロール処理の一部を変更することができます。 ただし、いずれの場合も、元の既定の動作を再現するのは簡単ではありません。この動作では、通常、コントロールはイベントやユーザーの入力動作と入力ジェスチャに予期したとおりに対応します。 そのため、入力イベントの発生が本当に必要かどうかを検討することをお勧めします。 コントロールで処理されない他の入力イベントや入力ジェスチャがあるかどうかを調査して、アプリやコントロール操作の設計では、それらを使う場合があります。

ScrollViewer を含むコントロールが ScrollViewer パーツ内の動作やプロパティの一部に影響を与えることができるように、ScrollViewer ではスタイルで設定でき、テンプレートのバインドで使用できる多数の XAML 添付プロパティを定義します。 添付プロパティについて詳しくは、「[添付プロパティの概要](../xaml-platform/attached-properties-overview.md)」をご覧ください。

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

たとえば、ListView の組み込みのスクロール ビューアーで垂直スクロール バーが常に表示されるようにする方法を次に示します。
```xaml
<ListView ScrollViewer.VerticalScrollBarVisibility="Visible"/> 
```

ScrollViewer が XAML で明示的である場合、コード例に示すように、添付プロパティ構文を使用する必要はありません。 属性構文 (たとえば `<ScrollViewer VerticalScrollBarVisibility="Visible"/>`) を使うだけです。


## 推奨事項

-   コンテンツ領域が 1 つのビューポート境界 (垂直方向または水平方向) を超えている場合は、単一軸のパンを使います。 コンテンツ領域が両方のビューポート境界 (垂直方向と水平方向) を超えている場合は、2 軸のパンを使います。
-   リスト ボックス、ドロップダウン リスト、テキスト入力ボックス、グリッド ビュー、リスト ビュー、ハブ コントロールの組み込みのスクロール機能を使います。 こうしたコントロールでは、同時に表示する項目が多すぎる場合に、ユーザーが項目のリストを水平方向、垂直方向のいずれかにスクロールできます。
-   ユーザーがより大きな領域の周囲で両方向にパンすること、そしておそらくズームできるようにする場合、たとえばユーザーが (画面に適合するサイズに設定されたイメージではなく) フル サイズのイメージをパンおよびズームできるようにする場合には、スクロール ビューアー内にイメージを配置します。
-   ユーザーが長いテキスト パスをスクロールする場合、垂直方向にのみスクロールするようにスクロール ビューアーを構成します。
-   1 つのオブジェクトのみを含める場合にスクロール ビューアーを使います。 1 つのオブジェクトをレイアウト パネルとし、その任意の数のオブジェクトを含めることができる点に注意してください。

## 関連トピック

**開発者向け (XAML)**
* [**ScrollViewer クラス**](https://msdn.microsoft.com/library/windows/apps/br209527)


<!--HONumber=May16_HO2-->


