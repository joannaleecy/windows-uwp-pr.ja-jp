---
author: QuinnRadich
Description: Use alignment, margin, and padding properties to arrange the layout of elements on a page.
title: レイアウトの配置、余白、およびパディング
ms.author: quradic
ms.date: 03/19/2018
ms.topic: article
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4ce80e0ce4eb51876a0a0ecf632a7c47e8894aac
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6840133"
---
# <a name="alignment-margin-padding"></a>配置、余白、パディング

UWP アプリでは、ほとんどのユーザー インターフェイス (UI) 要素は [**FrameworkElement**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.FrameworkElement) クラスから継承します。 すべての FrameworkElement にサイズ、配置、余白、およびパディングのプロパティがあり、これらは画面のレイアウト動作に影響します。 次のガイダンスでは、これらのレイアウト プロパティを使用して、アプリの UI が読みやすく、任意のコンテキストで使いやすいことを確認する方法の概要を示します。

## <a name="dimensions-height-width"></a>サイズ (高さ、幅)
適切なサイズでは、すべてのコンテンツが明確で読みやすくなります。 プライマリ コンテンツを判読するためにユーザーがスクロールまたはズームする必要がありません。

![サイズを示す図](images/dimensions.svg)

- [**Height**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.height) と [**Width**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.width) は要素のサイズを指定します。 既定値は、数学的に NaN (非数) です。 柔軟な動作のために[有効ピクセル単位](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)で測定された固定値を設定することも、**自動サイズ変更**または[比例サイズ変更](layout-panels.md#grid)を行うこともできます。

- [**ActualHeight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.actualheight) と [**ActualWidth**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.actualwidth) は、実行時の要素のサイズを指定する読み取り専用プロパティです。 柔軟なレイアウトが拡大または縮小する場合、[**SizeChanged**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.sizechanged) イベントで値が変化します。 なお、[**RenderTransform**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.rendertransform) では ActualHeight と ActualWidth 値は変更されません。

- [**MinWidth**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.minwidth)/[**MaxWidth**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.maxwidth) と [**MinHeight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.minheight)/[**MaxHeight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.maxheight) は柔軟なサイズ変更が有効な場合に、要素のサイズを制限する値を指定します。

- [**フォントサイズ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.fontsize)およびその他のテキストのプロパティはテキスト要素のレイアウトのサイズを制御します。 テキストの要素には、明示的に宣言されたサイズはありませんが、計算された ActualWidth と ActualHeight があります。 

## <a name="alignment"></a>配置
配置は、UI の外観を揃え、整理し、バランスをとり、また視覚的な階層と関係を確立するためにも使用することができます。

![配置を示す図](images/alignment.svg)

- [**HorizontalAlignment**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.horizontalalignment) と [**VerticalAlignment**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.verticalalignment) プロパティは、親コンテナー内の要素の配置方法を指定します。
    - **HorizontalAlignment** の値は、**Left**、**Center**、**Right**、**Stretch** です。
    - **VerticalAlignment** の値は、**Top**、**Center**、**Bottom**、**Stretch** です。

- **Stretch** は、両方のプロパティの既定値であり、要素が親コンテナーで提供されたスペース全体に配置されます。 実数の Height と Width は、Stretch の値をキャンセルし、代わりに Center 値として機能します。 Button などの一部のコントロールでは、その既定のスタイルで既定の Stretch 値がオーバーライドされます。

- [**HorizontalContentAlignment**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.horizontalcontentalignment) と [**VerticalContentAlignment**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.verticalcontentalignment) は、コンテナー内の子要素の配置方法を指定します。

- 配置は、レイアウト パネル内のクリッピングに影響します。 たとえば、`HorizontalAlignment="Left"` では、コンテンツが ActualWidth より大きい場合に要素の右側がクリップされます。

- テキスト要素は [**TextAlignment**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.textalignment) プロパティを使用します。 一般には、既定値の左揃えの使用をお勧めします。 テキストのスタイルについて詳しくは、「[文字体裁](../style/typography.md)」をご覧ください。

## <a name="margin-and-padding"></a>余白とパディング
余白とパディングのプロパティは、UI がごちゃごちゃしすぎたり、まばらすぎたりして見えないようにします。またペンやタッチなどの特定の入力を使用しやすくすることもできます。 コンテナーとそのコンテンツの余白とパディングを表示した図は次のとおりです。

![xaml 余白とパディングの図](images/xaml-layout-margins-padding.svg)

### <a name="margin"></a>余白
[**Margin**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.margin) は、要素を囲む空白のスペースの量を制御します。 Margin は、ActualHeight と ActualWidth にピクセルを追加せず、入力イベントのヒット テストとソースのための要素の一部と見なされることもありません。

- 余白の値は均等または別個です。 `Margin="20"` を使用すると、左右と上下の端で要素に 20 ピクセルの均等な余白が適用されます。 `Margin="0,10,5,25"` を使用すると、値は、左、上、右、下に (この順番で) 適用されます。 

- 余白は加算できます。 2 つの要素がともに、10 ピクセルの均等な余白を指定し、いずれかの向きで隣り合うピアである場合、それらの間の距離は 20 ピクセルです。

- 負の余白も使用できます。 ただし、負の余白を使用すると、クリッピングやピアの過剰な描画が発生することが多いため、負の余白の使用は一般的な手法ではありません。

- 余白の値は最後に制約があり、コンテナーが要素をクリップまたは制約する場合があるため、余白には注意してください。 余白の値は、要素のレンダリングが表示されない原因になる可能性があります。Margin を適用すると要素のサイズを 0 に制限できます。

### <a name="padding"></a>パディング
[**Padding**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.padding) は、要素の内側の境界線と、その子コンテンツまたは要素の間のスペースの量を制御します。 正の Padding 値は、要素のコンテンツ領域が小さくなります。 

Margin とは異なり、Padding は FrameworkElement のプロパティではありません。 いくつかのクラスがあり、それぞれ独自の Padding プロパティを定義しています。

-   [**Control.Padding**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.padding): すべての [**Control**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls) 派生クラスに継承されます。 コンテンツのないコントロールもあるため、それらのコントロールでは、プロパティを設定しても効果はありません。 コントロールに境界線がある場合は、パディングがその内部に適用されます。
-   [**Border.Padding**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border.padding): [**BorderThickness**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border.borderthickness)/[**BorderBrush**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border.borderbrush) によって作成された四角形の線と [**Child**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border.child) 要素の間のスペースを定義します。
-   [**ItemsPresenter.Padding**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemspresenter.padding): 指定されたパディングを各項目の周囲に配置して、アイテム コントロールの項目の外観を向上させます。
-   [**TextBlock.Padding**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.padding) および [**RichTextBlock.Padding**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richtextblock.padding): テキスト要素のテキストの周囲まで境界ボックスを拡大します。 これらのテキスト要素には、**背景**がないため、視覚的な表示が難しい場合があります。 このため、代わりに [**Block**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.block) コンテナーで  [**Margin**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.block.margin) 設定を使用します。

このような場合のそれぞれで、要素に Margin プロパティもあります。 Margin と Padding の両方が適用される場合、これらは加算可能です。外部のコンテナーと内部のコンテンツの間に見える距離は、余白とパディングを加算したものになります。

### <a name="example"></a>例
実際のコントロールで、Margin と Padding の効果を見てみましょう。 Margin と Padding が既定値の 0 である、Grid 内の TextBox を以下に示します。

![余白とパディングが 0 である TextBox](images/xaml-layout-textbox-no-margins-padding.svg)

同じ TextBox と Grid で、TextBox の Margin と Padding の値を、この XAML で示されているように設定した場合を以下に示します。

```xaml
<Grid BorderBrush="Blue" BorderThickness="4" Width="200">
    <TextBox Text="This is text in a TextBox." Margin="20" Padding="24,16"/>
</Grid>
```

![余白とパディングを正の値に設定した TextBox](images/xaml-layout-textbox-with-margins-padding.svg)


## <a name="style-resources"></a>Style リソース
コントロールに対して各プロパティ値を個別に設定する必要はありません。 通常、プロパティ値を [**Style**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Style) リソースとしてグループ化し、Style をコントロールに適用する方が効率的です。 これは、特に、同じプロパティ値を多くのコントロールに適用する必要がある場合に当てはまります。 スタイルの使用について詳しくは、「[XAML スタイル](../controls-and-patterns/xaml-styles.md)」をご覧ください。

## <a name="general-recommendations"></a>一般的な推奨事項
- 測定値のみを特定の主要な要素に適用し、その他の要素の柔軟なレイアウト動作を使用します。 これにより、ウィンドウの幅が変更されたときに [応答性の高い UI](responsive-design.md) が提供されます。

- 測定値を使用する場合、**すべてのサイズ、余白、およびパディングは 4 epx の増分になる必要があります**。 アプリをすべてのデバイスや画面サイズで読みやすいようにするために UWP で [有効ピクセルとスケーリング](../basics/design-and-ui-intro.md#effective-pixels-and-scaling) を使用する場合、4 の倍数単位で UI 要素を拡張します。 4 の増分で値を使用すると、ピクセル全体で調整することにより最適なレンダリングが得られます。

- 小さいウィンドウ幅 (640 ピクセル未満) の場合、ガターが 12 epx でより大きいウィンドウ幅の場合、ガターを 24 epx にすることをお勧めします。

![推奨ガター](images/12-gutter.svg)

## <a name="related-topics"></a>関連トピック
* [**FrameworkElement.Height**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.height)
* [**FrameworkElement.Width**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.width)
* [**FrameworkElement.HorizontalAlignment**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.horizontalalignment)
* [**FrameworkElement.VerticalAlignment**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.verticalalignment)
* [**FrameworkElement.Margin**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.margin)
* [**Control.Padding**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.padding)
