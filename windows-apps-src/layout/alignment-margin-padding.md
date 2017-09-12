---
author: Jwmsft
Description: "ページ上の要素のレイアウトに影響する配置、余白、およびパディングを使います。"
title: "ユニバーサル Windows プラットフォーム (UWP) アプリの配置、余白、およびパディング"
ms.assetid: 9412ABD4-3674-4865-B07D-64C7C26E4842
label: Alignment, margin, and padding
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 2023959126195116cf05443070326fddd512425b
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="alignment-margin-and-padding"></a>配置、余白、およびパディング

サイズのプロパティ (幅、高さ、および制約) に加え、要素は、配置、余白、パディングのプロパティも含むことができ、これらは、要素がレイアウト パスに移動し、UI に表示されるときにレイアウト動作に影響を与えます。 配置、余白、パディングのプロパティとサイズのプロパティの間には関係があり、ここには、[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) オブジェクトが配置されるときに一般的なロジックの流れがあります。これによって、各値は、状況に応じて使用されたり、無視されたりします。

## <a name="alignment-properties"></a>配置プロパティ

[**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/br208720) プロパティと [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/br208749) プロパティは、親要素に割り当てられたレイアウト スペース内で子要素がどのように配置されるかを説明します。 これらのプロパティを一緒に使って、コンテナーのレイアウト ロジックはコンテナー (パネルまたはコントロール) 内に子要素を配置できます。 配置プロパティは、アダプティブ レイアウトのコンテナーに目的のレイアウトのヒントを与えることが目的であるため、基本的に、[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) の子に設定され、別の **FrameworkElement** コンテナーの親によって解釈されます。 配置の値は、向きの 2 つの端のいずれかに揃えて要素を配置するか、または中央に揃えるかを指定できます。 ただし、両方の配置プロパティの既定値は **Stretch** です。 **Stretch** 配置にすると、要素は、レイアウトで提供されたスペース全体に配置されます。 **Stretch** は既定値であるため、明示的な測定値も、レイアウトの測定パスからの [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) 値もない場合は、アダプティブ レイアウトの手法を使う方がより簡単です。 この既定値を使うと、コンテンツの明示的な高さと幅がコンテナー内に収まらなかったり、各コンテナーのサイズを指定するまでにクリップされたりする危険性がありません。

> [!NOTE]
> 一般的なレイアウトの原則として、特定の主要な要素にのみ測定値を適用し、他の要素にはアダプティブ レイアウト動作を使うことが最善です。 こうすると、ユーザーが最上位アプリのウィンドウ サイズを指定するときに柔軟なレイアウト動作を提供できます。このようなサイズ指定は、いつでも実行できるのが普通です。

 
1 つのアダプティブ コンテナー内に [**Height**](https://msdn.microsoft.com/library/windows/apps/br208718) 値と [**Width**](https://msdn.microsoft.com/library/windows/apps/br208751) 値、またはクリッピングがある場合は、**Stretch** が配置の値として設定されていても、レイアウトは、そのコンテナーの動作によって制御されます。 パネルでは、**Height** と **Width** によって防止されている **Stretch** 値は、値が **Center** の場合と同様に機能します。

自然な、または計算された高さと幅の値がない場合、これらのサイズの値は数学的に **NaN** (数値ではない) です。 要素は、レイアウト コンテナーからサイズが与えられるのを待ちます。 レイアウトの実行後は、配置が使用された要素の **Stretch** 要素の [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/br208707) プロパティと [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/br208709) プロパティに値があります。 **NaN** 値は、子要素の [**Height**](https://msdn.microsoft.com/library/windows/apps/br208718) と [**Width**](https://msdn.microsoft.com/library/windows/apps/br208751) に残るため、アプリ ウィンドウのサイズ設定などのレイアウト関連の変更により、もう一度レイアウト サイクルが発生する場合などに、アダプティブ動作を再び実行できます。

[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) などのテキスト要素には、通常、明示的に宣言された幅はありませんが、[**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/br208709) で照会できる計算された幅があり、この幅によっても、**Stretch** 配置が取り消されます。 ([**FontSize**](https://msdn.microsoft.com/library/windows/apps/br209657) プロパティとその他のテキスト プロパティだけでなく、テキスト自体も既に、意図したレイアウト サイズのヒントになっています。 通常は、テキストを拡大する必要はありません。) コントロール内のコンテンツとして使われるテキストにも同じ効果があります。表示する必要のあるテキストが存在すると、**ActualWidth** が計算され、これによっても、目的の幅とサイズが、含んでいるコントロールまで縮小されます。 テキスト要素には、行ごとのフォント サイズ、改行、およびその他のテキスト プロパティに基づく [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/br208707) もあります。

[**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) などのパネルには既に、レイアウトの他のロジック (行と列の定義、および描画先のセルを示すために要素に設定された [**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/hh759795) などの添付プロパティ) があります。 この場合、配置プロパティは、そのセルの領域内でコンテンツがどのように配置されるかに影響しますが、セルの構造とサイズ指定は、**Grid** の設定によって制御されます。

項目のコントロールによって項目が表示される場合があり、この場合は、データが項目の基本型です。 ここでは、[**ItemsPresenter**](https://msdn.microsoft.com/library/windows/apps/br242843) が関与します。 データ自体は [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) 派生型ではありませんが、**ItemsPresenter** は、この派生型です。このため、プレゼンターの [**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/br208720) と [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/br208749) を設定でき、その配置が、項目コントロールで表示されるときにデータ項目に適用されます。

配置プロパティは、親レイアウト コンテナーのサイズに余分なスペースがある場合にのみ効果があります。 既にレイアウト コンテナーでコンテンツがクリッピングされている場合、配置は、クリッピングが適用される要素の領域に影響を与える可能性があります。 たとえば、`HorizontalAlignment="Left"` を設定すると、要素の適正なサイズがクリッピングされます。

## <a name="margin"></a>余白

[**Margin**](https://msdn.microsoft.com/library/windows/apps/br208724) プロパティは、レイアウトの状態で要素とピアとの間隔を説明し、さらに、要素と、その要素を含むコンテナーのコンテンツ領域の間の距離について説明します。 要素を、サイズが [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/br208707) と [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/br208709) である境界ボックスまたは四角形であると考える場合は、**Margin** レイアウトが、その四角形の外側に適用され、**ActualHeight** と **ActualWidth** にピクセルは追加されません。 また、余白は、入力イベントのヒット テストとソースの目的のために要素の一部と見なされることもありません。

一般的なレイアウト動作では、[**Margin**](https://msdn.microsoft.com/library/windows/apps/br208724) 値のコンポーネントは最後に制約され、[**Height**](https://msdn.microsoft.com/library/windows/apps/br208718) と [**Width**](https://msdn.microsoft.com/library/windows/apps/br208751) が既に 0 までに制約された後にのみ制約されます。 したがって、コンテナーが既にクリッピングしたり、要素を制約したりしている場合は余白に注意してください。注意していないと、余白が原因で要素が表示されなくなる場合があります (余白が適用された後に要素のサイズのいずれかが 0 に制約されているため)。

各余白の値は、`Margin="20"` などの構文を使って均等にすることができます。 この構文を使用すると、20 ピクセルの均等な余白が要素に適用され、左右と上下の端に 20 ピクセルの余白が作成されます。 余白の値は、4 つの異なる値にすることもでき、それぞれの値は左、上、右、下に (この順序で) 適用される異なる余白を表します。 たとえば、`Margin="0,10,5,25"` と記述します。 [**Margin**](https://msdn.microsoft.com/library/windows/apps/br208724) プロパティの基になる型は [**Thickness**](https://msdn.microsoft.com/library/windows/apps/br208864) 構造で、そのプロパティは、[**Left**](https://msdn.microsoft.com/library/windows/apps/hh673893) 値、[**Top**](https://msdn.microsoft.com/library/windows/apps/hh673840) 値、[**Right**](https://msdn.microsoft.com/library/windows/apps/hh673881) 値、および [**Bottom**](https://msdn.microsoft.com/library/windows/apps/hh673775) 値を個別の **Double** 値として保持しています。

余白は加算できます。 たとえば、2 つの要素がそれぞれ、10 ピクセルの均等な余白を指定し、いずれかの向きで隣り合うピアである場合、要素間の距離は 20 ピクセルです。

負の余白も使用できます。 ただし、負の余白を使用すると、クリッピングやピアの過剰な描画が発生することが多いため、負の余白の使用は一般的な手法ではありません。

[**Margin**](https://msdn.microsoft.com/library/windows/apps/br208724) プロパティを適切に使用すると、要素の描画位置と、隣り合う要素と子の描画位置を非常に細かく制御できます。 Visual Studio で XAML デザイナー内の要素をドラッグしてその位置を設定すると、変更された XAML に、その要素の **Margin** の値があるのがわかります。この値を使って、位置の変更が元の XAML へとシリアル化されています。

[**Block**](https://msdn.microsoft.com/library/windows/apps/br244379) クラスは、[**Paragraph**](https://msdn.microsoft.com/library/windows/apps/br244503) の基本クラスであり、[**Margin**](https://msdn.microsoft.com/library/windows/apps/jj191725) プロパティも備えています。 このクラスには、その **Paragraph** の位置が親コンテナー内でどのように設定されるかについて同様の効果があります。この親コンテナーは、通常は [**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/br227565) オブジェクトまたは [**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/br227548) オブジェクトです。また、この効果は、複数の段落の位置が、[**RichTextBlock.Blocks**](https://msdn.microsoft.com/library/windows/apps/br244347) コレクションの他の **Block** のピアに対してどのように設定されるかにも及びます。

## <a name="padding"></a>余白

**Padding** プロパティは、要素と、それに含まれる子要素またはコンテンツの間の距離を説明します。 コンテンツは、複数の子を持つことができる要素である場合、すべてのコンテンツを囲む単一の境界ボックスとして処理されます。 たとえば、2 つの項目を含む [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/br242803) がある場合は、[**Padding**](https://msdn.microsoft.com/library/windows/apps/br209459) が、これらの項目を含む境界ボックスの周りに適用されます。 **Padding** は、コンテナーの測定パスと配置パスの計算では、利用可能なサイズから減算されます。また、コンテナー自体でそれを含む要素のレイアウト パスが実行されるときは、目的のサイズの値の一部です。 [**Margin**](https://msdn.microsoft.com/library/windows/apps/br208724) とは異なり、**Padding** は [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) のプロパティではありません。実際は、複数のクラスがあり、それぞれが独自の **Padding** プロパティを定義しています。

-   [**Control.Padding**](https://msdn.microsoft.com/library/windows/apps/br209459): すべての [**Control**](https://msdn.microsoft.com/library/windows/apps/br209390) 派生クラスに継承されます。 コンテンツのないコントロールもあるため、一部のコントロール ([**AppBarSeparator**](https://msdn.microsoft.com/library/windows/apps/dn279268) など) では、プロパティを設定しても効果はありません。 コントロールに境界線がある場合 ([**Control.BorderThickness**](https://msdn.microsoft.com/library/windows/apps/br209399) を参照) は、パディングがその内部に適用されます。
-   [**Border.Padding**](https://msdn.microsoft.com/library/windows/apps/br209263): [**BorderThickness**](https://msdn.microsoft.com/library/windows/apps/br209256)/[**BorderBrush**](https://msdn.microsoft.com/library/windows/apps/br209254) によって作成された四角形の線と [**Child**](https://msdn.microsoft.com/library/windows/apps/br209258) 要素の間のスペースを定義します。
-   [**ItemsPresenter.Padding**](https://msdn.microsoft.com/library/windows/apps/hh968021): 指定された余白を各項目の周囲に配置して、項目コントロールの項目に生成されるビジュアルの外観を向上させます。
-   [**TextBlock.Padding**](https://msdn.microsoft.com/library/windows/apps/br209673) および [**RichTextBlock.Padding**](https://msdn.microsoft.com/library/windows/apps/br227596): テキスト要素のテキストの周囲まで境界ボックスを拡大します。 これらのテキスト要素には **Background** がありません。このため、テキストのパディングと、テキスト要素のコンテナーが適用した他のレイアウト動作を判別しにくい場合があります。 この理由により、テキスト要素のパディングはほとんど使用されず、含まれる [**Block**](https://msdn.microsoft.com/library/windows/apps/br244379) コンテナーに [**Margin**](https://msdn.microsoft.com/library/windows/apps/jj191725) 設定を使用する方が一般的です ([**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/br227565) の場合)。

このような場合のそれぞれで、同じ要素に **Margin** プロパティもあります。 余白とパディングの両方が適用される場合、いずれも、外部のコンテナーと内部のコンテンツの間に見える距離は余白とパディングを加算したものであるという意味で、加算可能です。 コンテンツ、要素、またはコンテナーに適用されるさまざまなバックグラウンド値がある場合、余白が終了し、パディングが開始されるポイントは、表示によって判別できる可能性があります。

## <a name="dimensions-height-width"></a>サイズ (高さ、幅)

[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) の [**Height**](https://msdn.microsoft.com/library/windows/apps/br208718) プロパティと [**Width**](https://msdn.microsoft.com/library/windows/apps/br208751) プロパティは、多くの場合、レイアウト パスの実行時の配置、余白、およびパディングのプロパティの動作に影響します。 特に、実数 **Height** および **Width** 値は、**Stretch** の配置を取り消すと同時に、レイアウトの測定のパスで確立される [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) 値のコンポーネントの候補として昇格されます。 **Height** と **Width** には、次の制約プロパティがあります。**Height** 値は、[**MinHeight**](https://msdn.microsoft.com/library/windows/apps/br208731) と [**MaxHeight**](https://msdn.microsoft.com/library/windows/apps/br208726) で制約でき、**Width** 値は、[**MinWidth**](https://msdn.microsoft.com/library/windows/apps/br208733) と [**MaxWidth**](https://msdn.microsoft.com/library/windows/apps/br208728) で制約できます。 また、[**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/br208709) と [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/br208707) は、レイアウト パスの完了後にのみ有効な値を含む、計算された読み取り専用プロパティです。 サイズと、制約プロパティまたは集計プロパティの相関方法について詳しくは、[**FrameworkElement.Height**](https://msdn.microsoft.com/library/windows/apps/br208718) と [**FrameworkElement.Width**](https://msdn.microsoft.com/library/windows/apps/br208751) の注釈をご覧ください。

## <a name="related-topics"></a>関連トピック

**リファレンス**

* [**FrameworkElement.Height**](https://msdn.microsoft.com/library/windows/apps/br208718)
* [**FrameworkElement.Width**](https://msdn.microsoft.com/library/windows/apps/br208751)
* [**FrameworkElement.HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/br208720)
* [**FrameworkElement.VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/br208749)
* [**FrameworkElement.Margin**](https://msdn.microsoft.com/library/windows/apps/br208724)
* [**Control.Padding**](https://msdn.microsoft.com/library/windows/apps/br209459)
