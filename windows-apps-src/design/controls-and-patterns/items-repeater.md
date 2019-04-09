---
Description: ItemsRepeater は、軽量のコントロールを生成し、項目のコレクションの表現です。
title: ItemsRepeater
label: ItemsRepeater
template: detail.hbs
ms.date: 02/01/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3344230bc52013825d94cfbe3668acfa0d7a2e13
ms.sourcegitcommit: c10d7843ccacb8529cb1f53948ee0077298a886d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2019
ms.locfileid: "58914002"
---
# <a name="itemsrepeater"></a>ItemsRepeater

使用して、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)エクスペリエンスをカスタム コレクションを作成するには柔軟なレイアウト システム、カスタム ビュー、および仮想化を使用します。

異なり[ListView](/uwp/api/windows.ui.xaml.controls.listview)、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)包括的なエンド ユーザー エクスペリエンスを提供しない既定の UI は持たず、フォーカスや選択した場合、ユーザーの相互作用に関するポリシーが用意されていません。 代わりに、独自の一意のコレクション ベースのエクスペリエンスとカスタム コントロールの作成に使用できる構成要素になります。 組み込みのポリシーではない、必要なエクスペリエンスを構築するポリシーをアタッチするを使用します。 たとえば、keyboarding ポリシーでは、選択ポリシーなどを使用するレイアウトを定義できます。

考えることができます[ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)よう ListView に完全に制御ではなく、データドリブンのパネルでは、概念的として。 表示するデータ項目のコレクション、各データ項目の UI 要素を生成する項目テンプレート、要素のサイズし、配置方法を決定するレイアウトを指定します。 次 ItemsRepeater は、データ ソースに基づいて子要素を生成し、レイアウトと項目テンプレートで指定したとおりに表示されます。 表示される項目を同種にする ItemsRepeater データ テンプレート セレクターで指定した条件に基づいてデータ項目を表すコンテンツを読み込むことができますので必要はありません。

| **Windows UI ライブラリを入手する** |
| - |
| このコントロールは、Windows の UI ライブラリを新しいコントロール、および UWP アプリの UI 機能を含む NuGet パッケージの一部として含まれています。 インストール手順を含む詳細については、次を参照してください。、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)します。 |

> **重要な API**:[ItemsRepeater クラス](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)、 [ScrollViewer クラス](/uwp/api/windows.ui.xaml.controls.scrollviewer)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

使用して、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)データのコレクションに対するカスタムの表示を作成します。 基本的な一連の項目を表示する使用できますが、多くの場合、カスタム コントロールのテンプレートの表示要素として使用する場合があります。

リストまたは最小限のカスタマイズにグリッドにデータを表示する、ボックスの制御が必要な場合は、使用を検討して、 [ListView](/uwp/api/windows.ui.xaml.controls.listview)または[GridView](/uwp/api/windows.ui.xaml.controls.gridview)します。

ItemsRepeater の組み込みアイテム コレクションではありません。 別のデータ ソースへのバインドではなく、直接、項目のコレクションを提供する必要があるかどうかより高ポリシー エクスペリエンスが必要な可能性があり、使用する必要があります[ListView](/uwp/api/windows.ui.xaml.controls.listview)または[GridView](/uwp/api/windows.ui.xaml.controls.gridview)します。

[ItemsControl](/uwp/api/windows.ui.xaml.controls.itemscontrol) ItemsRepeater 両方が、エクスペリエンスのカスタマイズ可能なコレクションを有効にする、ItemsRepeater に仮想化の UI レイアウトがサポートしている場合に ItemsControl はありません。 ItemsControl のではなく ItemsRepeater をかどうかを使用したことをお勧めします。 そのデータから、いくつかの項目を表示またはコントロールを作成するカスタム コレクションのみにします。

> [!NOTE]
> ItemsControl は、ニーズを満たすし、ItemsRepeater が思うような状況があればのフィードバックを送信してください、 [Windows UI ライブラリ GitHub プロジェクト](https://github.com/Microsoft/microsoft-ui-xaml/issues)お知らせします。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p>ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして、アプリを開きを参照してください、 <a href="xamlcontrolsgallery:/item/ItemsRepeater">ItemsRepeater</a>アクションにします。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="scrolling-with-itemsrepeater"></a>ItemsRepeater とスクロール

[ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)から派生していない[コントロール](/uwp/api/windows.ui.xaml.controls.control)コントロール テンプレートがあるないため、します。 したがって、スクロール、ListView などの組み込みが含まれていないか、コレクションの他のコントロールの操作を行います。

ラップしてスクロール機能を提供する必要があります、ItemsRepeater を使用すると、 [ScrollViewer](/uwp/api/windows.ui.xaml.controls.scrollviewer)コントロール。

## <a name="create-an-itemsrepeater"></a>作成、ItemsRepeater

使用する、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)、ItemsSource プロパティを設定して表示するデータを指定する必要があります。 設定して項目を表示する方法を指示し、 [ItemTemplate](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.itemtemplate)プロパティ。

### <a name="itemssource"></a>ItemsSource

ビューを設定するには、設定、 [ItemsSource](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.itemssource)プロパティをデータ項目のコレクション。 ここでは、ItemsSource は、コレクションのインスタンスに直接コードで設定されます。

```csharp
ObservableCollection<string> Items = new ObservableCollection<string>();

ItemsRepeater itemsRepeater1 = new ItemsRepeater();
itemsRepeater1.ItemsSource = Items;
```

ItemsSource プロパティを、XAML でコレクションにバインドすることもできます。 データ バインディングについて詳しくは、「[データ バインディングの概要](https://msdn.microsoft.com/windows/uwp/data-binding/data-binding-quickstart)」をご覧ください。


```xaml
<ItemsRepeater ItemsSource="{x:Bind Items}"/>
```

### <a name="data-template"></a>データ テンプレート

項目のデータ テンプレートによって、データの表示方法を定義します。 既定では、項目は、これがバインドされている、TextBlock を使用してデータ オブジェクトの文字列表現としてビューに表示されます。 しかし、通常はもっとリッチな表現でデータを表示する必要があります。 定義するアイテムの表示方法だけを指定する、 [DataTemplate](/uwp/api/windows.ui.xaml.datatemplate)します。 DataTemplate の XAML では、個々の項目を表示するために使うコントロールのレイアウトと外観を定義します。 レイアウト内のコントロールでは、データ オブジェクトのプロパティにバインドすることも、静的コンテンツをインラインで定義することもできます。 割り当てるように、DataTemplate、 [ItemTemplate](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.itemtemplate) ItemsRepeater のプロパティ。

この例では、データ オブジェクトは、単純な文字列です。 DataTemplate を使用して、テキストの左側にイメージを追加して、青緑に文字列を表示する TextBlock のスタイルを設定します。

> [!NOTE]
> DataTemplate で [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) を使う場合、DataTemplate に DataType (`x:DataType`) を指定する必要があります。

```xaml
<DataTemplate x:DataType="x:String">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="47"/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Image Source="Assets/placeholder.png" Width="32" Height="32"
               HorizontalAlignment="Left"/>
        <TextBlock Text="{x:Bind}" Foreground="Teal"
                   FontSize="15" Grid.Column="1"/>
    </Grid>
</DataTemplate>
```

このデータ テンプレートを使用して表示されるときに、項目はどのように表示されるかを示します。

![データ テンプレートを使用して表示される項目](images/listview-itemstemplate.png)

多数のアイテムを表示する場合、項目のデータ テンプレートで使用される要素の数のパフォーマンスに大きな影響を与えることができます。 詳細な情報とデータ テンプレートを使用して、リスト内の項目の外観を定義する方法の例については、次を参照してください。[項目コンテナーとテンプレート](item-containers-templates.md)します。

> [!TIP]
> ItemsRepeater は、ListView やその他のコントロールのコレクションのような項目コンテナーの DataTemplate の内容をラップしません。 代わりに、ItemsRepeater は、DataTemplate 内の定義のみを表示します。 アイテムとしてリスト ビュー アイテムを同じ見た目をしたい場合は、データ テンプレートで、ListViewItem のように、コンテナーを使用できます。 ItemsRepeater が ListViewItem のビジュアルが表示されますがなさない複数選択チェック ボックスを表示または選択範囲のように、その他の機能を使用します。
>
> 同様に、実際のコントロールのコレクションの場合は、データの収集などのボタン (`List<Button>`)、コントロールを表示する、DataTemplate に ContentPresenter を配置することができます。

#### <a name="datatemplateselector"></a>DataTemplateSelector

ビューに表示する項目は、同じ型である必要はありません。 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)使用できる、 **DataTemplateSelector**を指定した条件に基づいてデータ項目を表すデータ テンプレートを読み込めません。 詳細と例については、次を参照してください。 [DataTemplateSelector](/uwp/api/windows.ui.xaml.controls.datatemplateselector)します。

> [!NOTE]
> 派生した独自のクラスを実装するために DataTemplate または DataTemplateSelector を使用する代わりに、 [Microsoft.UI.Xaml.Controls.ElementFactory](/uwp/api/microsoft.ui.xaml.controls.elementfactory)が要求されたときにコンテンツを生成する責任を負います。

## <a name="configure-the-data-source"></a>データ ソースを構成します。

使用して、 [ItemsSource](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.itemssource)プロパティを使用して項目のコンテンツを生成するコレクションを指定します。 ItemsSource を設定するには任意の型を実装する**IEnumerable**します。 データ ソースによって実装される追加のコレクション インターフェイスは、データと対話する ItemsRepeater に可能な機能を決定します。

この一覧は、使用可能なインターフェイスとそれぞれの使用を検討する場合に表示されます。

- [IEnumerable](/dotnet/api/system.collections.generic.ienumerable-1)(.NET)/ [IIterable](/uwp/api/windows.foundation.collections.iiterable_t_)

  - 小規模の静的なデータ セットを使用できます。

    データ ソースには、少なくとも、IEnumerable を実装する必要があります/IIterable インターフェイス。 これはすべてサポートされている場合、コントロールはインデックス値を使用して項目にアクセスするために使用できるコピーを作成するとすべてを反復処理します。

- [IReadonlyList](/dotnet/api/system.collections.generic.ireadonlylist-1)(.NET)/ [IVectorView](/uwp/api/windows.foundation.collections.ivectorview_t_)

  - 静的で読み取り専用のデータ セットを使用できます。

    コントロールの項目にアクセスすることにより、インデックスを内部の冗長コピーを回避できます。

- [IList](/dotnet/api/system.collections.generic.ilist-1)(.NET)/ [IVector](/uwp/api/windows.foundation.collections.ivector_t_)

  - 静的なデータ セットを使用できます。

    コントロールの項目にアクセスすることにより、インデックスを内部の冗長コピーを回避できます。

    **警告**:一覧およびベクトルを実装しなくても変更[INotifyCollectionChanged](/dotnet/api/system.collections.specialized.inotifycollectionchanged) UI に反映されません。

- [INotifyCollectionChanged](/dotnet/api/system.collections.specialized.inotifycollectionchanged)(.NET)

  - 変更通知をサポートすることをお勧めします。

    観察し、データ ソースでの変更に反応し、UI の変更を反映させるコントロールを有効にします。

- [IObservableVector](/uwp/api/windows.foundation.collections.iobservablevector_t_)

  - 変更通知をサポートしています

    ように、 **INotifyCollectionChanged**インターフェイス、これにより、コントロールを確認し、データ ソースでの変更に対応します。

    **警告**:Windows.Foundation.IObservableVector\<T > '移動' 操作をサポートしていません。 これには、項目の UI のビジュアルの状態が失われる可能性があります。  たとえば、現在選択されている、または 'Remove' を 'Add' 後に、移動を実現する場所にフォーカスがある項目を使用して、フォーカスを失って、選択できなくなります。

    Platform.Collections.Vector\<T > IObservableVector を使用して\<T > とはこの同じ制限があります。 サポート '移動' アクションが必要です。 使用している場合、 **INotifyCollectionChanged**インターフェイス。  .NET ObservableCollection\<T > クラスで使用**INotifyCollectionChanged**します。

- [IKeyIndexMapping](/uwp/api/microsoft.ui.xaml.controls.ikeyindexmapping)

  - ときに一意識別子は各項目を関連付けることができます。  コレクションの変更操作として 'Reset' を使用する場合にお勧めします。

    ハード リセット' のアクションの一部として受信した後、既存の UI を非常に効率的に回復するコントロールできるように、 **INotifyCollectionChanged**または**IObservableVector**イベント。 リセットを受信した後、コントロールは、既に作成してその要素に現在のデータを関連付ける、指定された一意の ID を使用します。 インデックスのマッピングにキーがないコントロールは、データの UI の作成の最初からやり直す必要があると仮定する必要があります。

IKeyIndexMapping、以外に、上に示したインターフェイスは、ListView および GridView のように ItemsRepeater で同じ動作を提供します。


次のインターフェイス、ItemsSource に ListView と GridView コントロールで特別な機能を有効にする現在効果はありません、ItemsRepeater で。

- [ISupportIncrementalLoading](/uwp/api/windows.ui.xaml.data.isupportincrementalloading)
- [IItemsRangeInfo](/uwp/api/windows.ui.xaml.data.iitemsrangeinfo)
- [ISelectionInfo](/uwp/api/windows.ui.xaml.data.iselectioninfo)

> [!TIP]
> ご意見をお寄せください 皆さんに、 [Windows UI ライブラリ GitHub プロジェクト](https://github.com/Microsoft/microsoft-ui-xaml/issues)します。 など、自分の考えを既存の提案の追加を検討する[#374](https://github.com/Microsoft/microsoft-ui-xaml/issues/374):ItemsRepeater の増分読み込みのサポートを追加します。

ユーザーがスクロール アップまたはスケール ダウン、データを増分読み込みする他の方法では ScrollViewer のビューポートの位置を観察し、ビューポートの範囲に近づくとデータを読み込みます。

```xaml
<ScrollViewer ViewChanged="ScrollViewer_ViewChanged">
    <ItemsRepeater ItemsSource="{x:Bind MyItemsSource}" .../>
</ScrollViewer>
```

```csharp
private async void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
{
    if (!e.IsIntermediate)
    {
        var scroller = (ScrollViewer)sender;
        var distanceToEnd = scroller.ExtentHeight - (scroller.VerticalOffset + scroller.ViewportHeight);

        // trigger if within 2 viewports of the end
        if (distanceToEnd <= 2.0 * scroller.ViewportHeight
                && MyItemsSource.HasMore && !itemsSource.Busy)
        {
            // show an indeterminate progress UI
            myLoadingIndicator.Visibility = Visibility.Visible;

            await MyItemsSource.LoadMoreItemsAsync(/*DataFetchSize*/);

            loadingIndicator.Visibility = Visibility.Collapsed;
        }
    }
}
```

## <a name="change-the-layout-of-items"></a>項目のレイアウト変更

項目が表示されている、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)配置されるか、[レイアウト](/uwp/api/microsoft.ui.xaml.controls.layout)サイズとその子要素の配置を管理するオブジェクト。 ItemsRepeater を併用すると、レイアウト オブジェクトには、UI の仮想化ができるようにします。 用意されたレイアウトは[StackLayout](/uwp/api/microsoft.ui.xaml.controls.stacklayout)と[UniformGridLayout](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout)します。 既定では、ItemsRepeater は縦方向の StackLayout を使用します。

### <a name="stacklayout"></a>StackLayout

[StackLayout](/uwp/api/microsoft.ui.xaml.controls.stacklayout)要素を水平方向または垂直方向の向きを設定する 1 行に整列します。

設定することができます、[間隔](/en-us/uwp/api/microsoft.ui.xaml.controls.stacklayout.spacing)項目間のスペースの量を調整するプロパティ。 間隔がレイアウトの方向に適用される[向き](/uwp/api/microsoft.ui.xaml.controls.stacklayout.orientation)します。

![スタック レイアウト間隔](images/stack-layout.png)

この例では、水平方向と 8 ピクセルの間隔、StackLayout を ItemsRepeater.Layout プロパティを設定する方法を示します。

```xaml
<!-- xmlns:muxc="using:Microsoft.UI.Xaml.Controls" -->
<muxc:ItemsRepeater ItemsSource="{x:Bind Items}" ItemTemplate="{StaticResource MyTemplate}">
    <muxc:ItemsRepeater.Layout>
        <muxc:StackLayout Orientation="Horizontal" Spacing="8"/>
    </muxc:ItemsRepeater.Layout>
</muxc:ItemsRepeater>
```

### <a name="uniformgridlayout"></a>UniformGridLayout

[UniformGridLayout](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout)折り返しレイアウトで要素を順番に配置します。 項目が左から右から順にレイアウトときに、[向き](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.orientation)は**水平**、一番上から下へ、印刷の向きがレイアウトと**垂直**。 すべての項目を同じサイズです。

![統一されたグリッド レイアウトの間隔](images/uniform-grid-layout.png)

各行の水平レイアウト内の項目の数は、最小のアイテムの幅の影響を受けます。 項目の最小の高さ、縦方向のレイアウトの各列内の項目の数が反映されます。

- 明示的に設定して使用する最小サイズを指定することができます、 [MinItemHeight](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.minitemheight)と[MinItemWidth](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.minitemwidth)プロパティ。
- 最小サイズを指定しない場合、最初の項目の測定のサイズは、項目ごとの最小サイズと見なされます。

行と列の間に設定して、レイアウトの最小間隔を設定することも、 [MinColumnSpacing](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.mincolumnspacing)と[MinRowSpacing](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.minrowspacing)プロパティ。

![統一されたグリッドのサイズ変更との間隔](images/uniform-grid-sizing-spacing.png)

数の行または列内の項目が特定された場合は、項目の最小サイズとの間隔に基づき、後に未使用領域の行または列の最後の項目の後に残っています (図のように、以前) である可能性があります。 余分なスペースが無視されますになっていることを使用して、各項目のサイズを増やすまたは項目間の余分なスペースを作成するために使用するかどうかを指定できます。 これによって制御されますが、 [ItemsStretch](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.itemsstretch)と[ItemsJustification](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.itemsjustification)プロパティ。

設定することができます、 [ItemsStretch](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.itemsstretch)未使用領域を埋める、アイテムのサイズを増やす方法を指定するプロパティ。

この一覧は、使用可能な値を示します。 定義には、既定値が前提としています**向き**の**水平**します。

- **[なし]**:余分なスペースは、行の終わりに未使用のまま。 これが既定値です。
- **入力**:項目には、使用可能な領域 (垂直方向の場合は高さ) を使用する追加の幅が与えられます。
- **Uniform**:項目が、使用可能な領域を使用する追加の幅を指定して、縦横比を維持するために余分な高さを指定 (高さと幅が切り替わった場合、垂直方向)。

このイメージの効果を示しています、 **ItemsStretch**水平レイアウト内の値。

![統一されたグリッド項目の拡張](images/uniform-grid-item-stretch.png)

ときに**ItemsStretch**は**None**、設定することができます、 [ItemsJustification](/uwp/api/microsoft.ui.xaml.controls.uniformgridlayout.itemsjustification)アイテムを揃えるための領域の使用方法を指定するプロパティ。

この一覧は、使用可能な値を示します。 定義には、既定値が前提としています**向き**の**水平**します。

- **開始**:項目は、行の先頭に配置されます。 余分なスペースは、行の終わりに未使用のまま。 これが既定値です。
- **Center**:項目は、行の中央に揃えて配置されます。 余分なスペースは、先頭と行の末尾に均等に分割されます。
- **終了**:項目は、行の末尾に揃えて配置されます。 余分なスペースは、行の先頭に使用されていないまま。
- **SpaceAround**:項目が均等に分散されます。 等しいメモリ領域のサイズは前に、と後の各項目に追加されます。
- **スペース**:項目が均等に分散されます。 各項目の間と同じメモリ領域のサイズが追加されます。 先頭と行の末尾にスペースは追加されません。
- **SpaceEvenly**:項目は、両方の各項目の間、および開始、行の末尾にある空き領域量が等しいを均等に分散されます。

このイメージの効果を示しています、 **ItemsStretch** (行ではなく列に適用) 垂直レイアウト内の値。

![統一されたグリッド項目の位置揃え](images/uniform-grid-item-justification.png)

> [!TIP]
> **ItemsStretch**プロパティに影響、_メジャー_レイアウトのパスします。 **ItemsJustification**プロパティに影響、_配置_レイアウトのパスします。

この例では、設定、 **ItemsRepeater.Layout**プロパティを**UniformGridLayout**します。

```xaml
<!-- xmlns:muxc="using:Microsoft.UI.Xaml.Controls" -->
<muxc:ItemsRepeater ItemsSource="{x:Bind Items}"
                    ItemTemplate="{StaticResource MyTemplate}">
    <muxc:ItemsRepeater.Layout>
        <muxc:UniformGridLayout MinItemWidth="200"
                                MinColumnSpacing="28"
                                ItemsJustification="SpaceAround"/>
    </muxc:ItemsRepeater.Layout>
</muxc:ItemsRepeater>
```

## <a name="lifecycle-events"></a>ライフ サイクル イベント

内の項目をホストする場合、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)など、一部のコンテンツの非同期ダウンロードを開始すると、要素に関連付ける選択を追跡するためのメカニズム、項目が表示または表示を停止するときに、何らかのアクションを実行する必要がありますか一部のバック グラウンド タスクを停止します。

仮想化コントロールのため、これが再利用されるときに、要素をライブ ビジュアル ツリーから削除されないことがロード/アンロード イベントに依存できません。 代わりに、その他のイベントは、要素のライフ サイクル管理に提供されます。 この図はの ItemsRepeater でと、関連するイベントが発生したときに、要素のライフ サイクルを示します。

![ライフ サイクル イベントのダイアグラム](images/items-repeater-lifecycle.png)

- [**ElementPrepared** ](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.elementprepared)要素が使用できるように行われるたびに発生します。 これは、要素が既に存在し、リサイクルのキューから再使用されているだけでなく、新しく作成された要素に対して発生します。
- [**ElementClearing** ](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.elementclearing)たびに、要素の範囲外になる場合など、リサイクルのキューに送信されたアイテムの実現に発生します。
- [**ElementIndexChanged** ](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.elementindexchanged
) UIElement を表す項目のインデックスが変更されていることに気付きましたそれぞれに対して行われます。 たとえば、別のアイテムが追加またはデータ ソースの削除、順序の後に続く項目のインデックスは、このイベントを受信します。

この例では、これらのイベントを使用できます ItemsRepeater を使用して項目を表示するカスタム コントロールで項目の選択を追跡するカスタム選択サービスにアタッチする方法を示します。

```xaml
<!-- xmlns:muxc="using:Microsoft.UI.Xaml.Controls" -->
<UserControl ...>
    ...
    <ScrollViewer>
        <muxc:ItemsRepeater ItemsSource="{x:Bind Items}"
                            ItemTemplate="{StaticResource MyTemplate}"
                            ElementPrepared="OnElementPrepared"
                            ElementIndexChanged="OnElementIndexChanged"
                            ElementClearing="OnElementClearing">
        </muxc:ItemsRepeater>
    </ScrollViewer>
    ...
</UserControl>
```

```csharp
interface ISelectable
{
    int SelectionIndex { get; set; }
    void UnregisterSelectionModel(SelectionModel selectionModel);
    void RegisterSelectionModel(SelectionModel selectionModel);
}

private void OnElementPrepared(ItemsRepeater sender, ElementPreparedEventArgs args)
{
    var selectable = args.Element as ISelectable;
    if (selectable != null)
    {
        // Wire up this item to recognize a 'select' and listen for programmatic
        // changes to the selection model to know when to update its visual state.
        selectable.SelectionIndex = args.Index;
        selectable.RegisterSelectionModel(this.SelectionModel);
    }
}

private void OnElementIndexChanged(ItemsRepeater sender, ElementIndexChangedEventArgs args)
{
    var selectable = args.Element as ISelectable;
    if (selectable != null)
    {
        // Sync the ID we use to notify the selection model when the item
        // we represent has changed location in the data source.
        selectable.SelectionIndex = args.NewIndex;
    }
}

private void OnElementClearing(ItemsRepeater sender, ElementClearingEventArgs args)
{
    var selectable = args.Element as ISelectable;
    if (selectable != null)
    {
        // Disconnect handlers to recognize a 'select' and stop
        // listening for programmatic changes to the selection model.
        selectable.UnregisterSelectionModel(this.SelectionModel);
        selectable.SelectionIndex = -1;
    }
}
```

## <a name="sorting-filtering-and-resetting-the-data"></a>データのリセットと並べ替え、フィルター処理

フィルター処理またはデータ セットの並べ替えなどのアクションを実行するときに従来可能性がありますが、新しいデータにデータの前のセットを比較してで細かい変更通知を発行[INotifyCollectionChanged](/uwp/api/windows.ui.xaml.interop.inotifycollectionchanged)します。 ただし、完全に古いデータを新しいデータで置き換えるし、使用してコレクションの変更通知をトリガーしやすく、多くの場合、[リセット](/uwp/api/windows.ui.xaml.interop.notifycollectionchangedaction)アクション代わりにします。

通常、リセットは、既存の子要素をリリースしてやり直すのリセット中に、データが変更する方法に正確に認識があるないために、スクロール位置の 0 から始まるから UI を構築するコントロールをによりします。

ただし、として、コレクションに割り当てられている場合、ItemsSource サポート一意識別子を実装して、 [IKeyIndexMapping](/uwp/api/microsoft.ui.xaml.controls.ikeyindexmapping)インターフェイス、ItemsRepeater をすばやく特定できます。

- 前に、と、リセット後の両方に存在していたデータの再利用可能な Uielement
- 削除された表示される項目以前
- 新しく追加された項目が表示されます

これにより、ItemsRepeater のスクロール位置の 0 から経由で開始することができます。 パフォーマンスを向上させるその結果のリセットを変更していないデータの Uielement を迅速に復元することもできます。

この例は、垂直方向のスタックで項目の一覧を表示する方法を示しています。 場所_MyItemsSource_は、基になる項目のリストをラップするカスタム データ ソース。 これは、公開、_データ_プロパティが、リセットがトリガーされる項目ソースとして使用する新しいリストを再割り当てを使用できます。

```xaml
<ScrollViewer x:Name="sv">
    <ItemsRepeater x:Name="repeater"
                ItemsSource="{x:Bind MyItemsSource}"
                ItemTemplate="{StaticResource MyTemplate}">
       <ItemsRepeater.Layout>
           <StackLayout ItemSpacing="8"/>
       </ItemsRepeater.Layout>
   </ItemsRepeater>
</ScrollViewer>
```

```csharp
public MainPage()
{
    this.InitializeComponent();

    // Similar to an ItemsControl, a developer sets the ItemsRepeater's ItemsSource.
    // Here we provide our custom source that supports unique IDs which enables
    // ItemsRepeater to be smart about handling resets from the data.
    // Unique IDs also make it easy to do things apply sorting/filtering
    // without impacting any state (i.e. selection).
    MyItemsSource myItemsSource = new MyItemsSource(data);

    repeater.ItemsSource = myItemsSource;

    // ...

    // We can sort/filter the data using whatever mechanism makes the
    // most sense (LINQ, database query, etc.) and then reassign
    // it, which in our implementation triggers a reset.
    myItemsSource.Data = someNewData;
}

// ...


public class MyItemsSource : IReadOnlyList<ItemBase>, IKeyIndexMapping, INotifyCollectionChanged
{
    private IList<ItemBase> _data;

    public MyItemsSource(IEnumerable<ItemBase> data)
    {
        if (data == null) throw new ArgumentNullException();

        this._data = data.ToList();
    }

    public IList<ItemBase> Data
    {
        get { return _data; }
        set
        {
            _data = value;

            // Instead of tossing out existing elements and re-creating them,
            // ItemsRepeater will reuse the existing elements and match them up
            // with the data again.
            this.CollectionChanged?.Invoke(
                this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }

    #region IReadOnlyList<T>

    public ItemBase this[int index] => this.Data != null
        ? this.Data[index]
        : throw new IndexOutOfRangeException();

    public int Count => this.Data != null ? this.Data.Count : 0;
    public IEnumerator<ItemBase> GetEnumerator() => this.Data.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    #endregion

    #region INotifyCollectionChanged

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    #endregion

    #region IKeyIndexMapping

    private int lastRequestedIndex = IndexNotFound;
    private const int IndexNotFound = -1;

    // When UniqueIDs are supported, the ItemsRepeater caches the unique ID for each item
    // with the matching UIElement that represents the item.  When a reset occurs the
    // ItemsRepeater pairs up the already generated UIElements with items in the data
    // source.
    // ItemsRepeater uses IndexForUniqueId after a reset to probe the data and identify
    // the new index of an item to use as the anchor.  If that item no
    // longer exists in the data source it may try using another cached unique ID until
    // either a match is found or it determines that all the previously visible items
    // no longer exist.
    public int IndexForUniqueId(string uniqueId)
    {
        // We'll try to increase our odds of finding a match sooner by starting from the
        // position that we know was last requested and search forward.
        var start = lastRequestedIndex;
        for (int i = start; i < this.Count; i++)
        {
            if (this[i].PrimaryKey.Equals(uniqueId))
                return i;
        }

        // Then try searching backward.
        start = Math.Min(this.Count - 1, lastRequestedIndex);
        for (int i = start; i >= 0; i--)
        {
            if (this[i].PrimaryKey.Equals(uniqueId))
                return i;
        }

        return IndexNotFound;
    }

    public string UniqueIdForIndex(int index)
    {
        var key = this[index].PrimaryKey;
        lastRequestedIndex = index;
        return key;
    }

    #endregion
}

```

## <a name="create-a-custom-collection-control"></a>コレクションのカスタム コントロールを作成します。

使用することができます、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)独自の型の各項目を表示するコントロールを備えたカスタム コレクション コントロールを作成します。

> [!NOTE]
> 使用してに似ています**ItemsControl**がから派生するのではなく**ItemsControl**配置して、 **ItemsPresenter** から派生するコントロールテンプレートで**コントロール**を挿入し、 **ItemsRepeater**コントロール テンプレートにします。 カスタム コレクション コントロール"は、" **ItemsRepeater**と"は、" **ItemsControl**します。 つまり、ことを公開するプロパティを明示的に選択する必要がありますではなくこれをサポートしないようにプロパティが継承されます。

この例では、配置、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)という名前のカスタム コントロールのテンプレートで_MediaCollectionView_し、そのプロパティを公開します。

```xaml
<!-- xmlns:muxc="using:Microsoft.UI.Xaml.Controls" -->
<Style TargetType="local:MediaCollectionView">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="local:MediaCollectionView">
                <Border
                    Background="{TemplateBinding Background}"
                    BorderBrush="{TemplateBinding BorderBrush}"
                    BorderThickness="{TemplateBinding BorderThickness}">
                    <ScrollViewer x:Name="ScrollViewer">
                        <muxc:ItemsRepeater x:Name="ItemsRepeater"
                                            ItemsSource="{TemplateBinding ItemsSource}"
                                            ItemTemplate="{TemplateBinding ItemTemplate}"
                                            Layout="{TemplateBinding Layout}"
                                            TabFocusNavigation="{TemplateBinding TabFocusNavigation}"/>
                    </ScrollViewer>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

```csharp
public sealed class MediaCollectionView : Control
{
    public object ItemsSource
    {
        get { return (object)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register(nameof(ItemsSource), typeof(object), typeof(MediaCollectionView), new PropertyMetadata(0));

    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set { SetValue(ItemTemplateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ItemTemplate.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ItemTemplateProperty =
        DependencyProperty.Register(nameof(ItemTemplate), typeof(DataTemplate), typeof(MediaCollectionView), new PropertyMetadata(0));

    public Layout Layout
    {
        get { return (Layout)GetValue(LayoutProperty); }
        set { SetValue(LayoutProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Layout.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty LayoutProperty =
        DependencyProperty.Register(nameof(Layout), typeof(Layout), typeof(MediaCollectionView), new PropertyMetadata(0));

    public MediaCollectionView()
    {
        this.DefaultStyleKey = typeof(MediaCollectionView);
    }
}
```

## <a name="display-grouped-items"></a>グループ化された項目を表示します。

入れ子にすることができます、 [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)で、 [ItemTemplate](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.itemtemplate)入れ子になったを作成する別の ItemsRepeater のレイアウトを仮想化します。 フレームワークが表示されない要素のまたは現在のビューポートの近くに不要な実現を最小限に抑えることによってリソースの使用効率がなります。

この例では、垂直方向のスタックにグループ化された項目の一覧を表示する方法を示します。 外部 ItemsRepeater には、各グループが生成されます。 各グループのテンプレートでは、別 ItemsRepeater には、項目が生成されます。

```xaml
<!-- xmlns:muxc="using:Microsoft.UI.Xaml.Controls" -->
<ScrollViewer>
  <muxc:ItemsRepeater ItemsSource="{x:Bind AppNotifications}"
                      Layout="{StaticResource MyGroupLayout}">
    <muxc:ItemsRepeater.ItemTemplate>
      <DataTemplate x:DataType="ExampleApp:AppNotifications">
        <!-- Group -->
        <StackPanel>
          <!-- Header -->
          TextBlock Text="{x:Bind AppTitle}"/>
          <!-- Items -->
          <muxc:ItemsRepeater ItemsSource="{x:Bind Notifications}"
                              Layout="{StaticResource MyItemLayout}"
                              ItemTemplate="{StaticResource MyTemplate}"/>
          <!-- Footer -->
          <Button Content="{x:Bind FooterText}"/>
        </StackPanel>
      </DataTemplate>
    </muxc:ItemsRepeater.ItemTemplate>
  </muxc:ItemsRepeater>
</ScrollViewer>
```

この例では、ユーザー設定を使用して変更できるし、は、次のように水平方向のスクロール リストとして表示されますが、さまざまなカテゴリがあるアプリケーションのレイアウトを示します。

![項目の repeater を入れ子になったレイアウト](images/items-repeater-nested-layout.png)

```xaml
<!-- xmlns:muxc="using:Microsoft.UI.Xaml.Controls" -->
<ScrollViewer>
  <muxc:ItemsRepeater ItemsSource="{x:Bind Categories}"
                      Background="LightGreen">
    <muxc:ItemsRepeater.ItemTemplate>
      <DataTemplate x:DataType="local:Category">
        <StackPanel Margin="12,0">
          <TextBlock Text="{x:Bind Name}" Style="{ThemeResource TitleTextBlockStyle}"/>
          <ScrollViewer HorizontalScrollMode="Enabled"
                                          VerticalScrollMode="Disabled"
                                          HorizontalScrollBarVisibility="Auto" >
            <muxc:ItemsRepeater ItemsSource="{x:Bind Items}"
                                Background="Orange">
              <muxc:ItemsRepeater.ItemTemplate>
                <DataTemplate x:DataType="local:CategoryItem">
                  <Grid Margin="10"
                        Height="60" Width="120"
                        Background="LightBlue">
                    <TextBlock Text="{x:Bind Name}"
                               Style="{StaticResource SubtitleTextBlockStyle}"
                               Margin="4"/>
                  </Grid>
                </DataTemplate>
              </muxc:ItemsRepeater.ItemTemplate>
              <muxc:ItemsRepeater.Layout>
                <muxc:StackLayout Orientation="Horizontal"/>
              </muxc:ItemsRepeater.Layout>
            </muxc:ItemsRepeater>
          </ScrollViewer>
        </StackPanel>
      </DataTemplate>
    </muxc:ItemsRepeater.ItemTemplate>
  </muxc:ItemsRepeater>
</ScrollViewer>
```

## <a name="bringing-an-element-into-view"></a>要素をビューに取り込む

既に、XAML フレームワークは、1) がキーボード フォーカスを受け取るまたは 2) がナレーターのフォーカスを受け取ったときに、ビューに、FrameworkElement を取り込むを処理します。 要素を明示的にビューを表示する必要があるその他のケースである可能性があります。 たとえば、ページ ナビゲーションの後に、UI の状態を復元するかユーザー アクションへの応答で。

仮想化された要素をビューに取り込む手順を以下にします。
1. 項目の UIElement を実現します。
2. 要素が有効な位置を持つようにするためのレイアウトを実行します。
3. 実際の要素を表示する要求を開始します。

次の例では、ページ ナビゲーションの後のフラットな縦方向のリストで項目のスクロール位置の復元の一環として、次の手順を示します。 入れ子になった ItemsRepeaters を使用してデータを階層の場合は、アプローチは、基本的に同じですが、階層の各レベルで行う必要があります。

```xaml
<ScrollViewer x:Name="scrollviewer">
  <ItemsRepeater x:Name="repeater" .../>
</ScrollViewer>
```

```csharp
public class MyPage : Page
{
    // ...

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

            // retrieve saved offset + index(es) of the tracked element and then bring it into view.
            // ... 

            var element = repeater.GetOrCreateElement(index);

            // ensure the item is given a valid position
            element.UpdateLayout();

            element.StartBringIntoView(new BringIntoViewOptions()
            {
                VerticalOffset = relativeVerticalOffset
            });
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);

        // retrieve and save the relative offset and index(es) of the scrollviewer's current anchor element ...
        var anchor = this.scrollviewer.CurrentAnchor;
        var index = this.repeater.GetElementIndex(anchor);
        var anchorBounds = anchor.TransformToVisual(this.scrollviewer).TransformBounds(new Rect(0, 0, anchor.ActualWidth, anchor.ActualHeight));
        relativeVerticalOffset = this.sv.VerticalOffset – anchorBounds.Top;
    }
}

```

## <a name="enable-accessibility"></a>ユーザー補助機能を有効にします。

[ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)既定のアクセシビリティのエクスペリエンスを提供しています。 ドキュメント[UWP アプリのユーザビリティを](/windows/uwp/design/usability)包括的なユーザー エクスペリエンスを提供する豊富なアプリの確認に役立つ情報を提供します。 カスタム コントロールを作成する、ItemsRepeater を使用している場合はありますし、ドキュメントを参照してください[カスタム オートメーション ピア](/windows/uwp/design/accessibility/custom-automation-peers)します。

### <a name="keyboarding"></a>キーボード入力
フォーカスの移動 ItemsRepeater を提供する最小限の keyboarding サポートは XAML のに基づいて[Keyboarding の 2D の方向ナビゲーション](/windows/uwp/design/input/focus-navigation#2d-directional-navigation-for-keyboard)します。

![方向ナビゲーション](/windows/uwp/design/input/images/keyboard/directional-navigation.png)

ItemsRepeater の[XYFocusKeyboardNavigation モード](/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)は_有効_既定。 意図したエクスペリエンスによって共通のサポートの追加を検討する[キーボードの相互作用](/windows/uwp/design/input/keyboard-interactions)Home、End、PageUp、PageDown など。

ItemsRepeater は自動的に、その項目の既定のタブ オーダー (かどうかを仮想化された) かどうかに従うこと、データ内の項目が指定されているのと同じ順序を確認します。 既定で、ItemsRepeater はその[TabFocusNavigation](/uwp/api/windows.ui.xaml.uielement.tabfocusnavigation)プロパティに設定[1 回](/uwp/api/windows.ui.xaml.input.keyboardnavigationmode)の一般的な既定ではなく_ローカル_。

> [!NOTE]
> ItemsRepeater は、最後にフォーカスがある項目を自動的に保存されていません。  これは、ユーザーが使用する場合 Shift + tab 最後の実行可能性がありますが項目を実現することを意味します。

### <a name="announcing-item-x-of-y-in-screen-readers"></a>お知らせ"項目_X_の_Y_"スクリーン リーダーで

値など、適切なオートメーション プロパティの設定を管理する必要がある**PositionInSet**と**SizeOfSet**、まま項目が追加されると、最新の状態を確認してくださいなど、削除、移動します。

カスタム レイアウトの中である可能性がありますいない視覚的な順序を明らかにシーケンスします。  ユーザーは、スクリーン リーダーによって使用される PositionInSet と SizeOfSet プロパティの値が (0 ベースとカウントが自然に一致するように 1 ずつオフセット)、データ内の項目が表示される順序を一致する最小期待します。

これを実現する最善の方法は、アイテム コントロールの実装のオートメーション ピアのことで、 [GetPositionInSetCore](/uwp/api/windows.ui.xaml.automation.peers.automationpeer.getpositioninsetcore)と[GetSizeOfSetCore](/uwp/api/windows.ui.xaml.automation.peers.automationpeer.getsizeofsetcore)メソッドとレポート、データ セット内の項目の位置コントロールで表されます。 実行時の支援技術がアクセスするときに値を計算してのみと、問題以外を最新に保つことになります。 値は、データの順序と一致します。

この例では、そう方法でしたというカスタム コントロールを表示するときに_CardControl_します。

```xaml
<ScrollViewer >
    <ItemsRepeater x:Name="repeater" ItemsSource="{x:Bind MyItemsSource}">
       <ItemsRepeater.ItemTemplate>
           <DataTemplate x:DataType="local:CardViewModel">
               <local:CardControl Item="{x:Bind}"/>
           </DataTemplate>
       </ItemsRepeater.ItemTemplate>
   </ItemsRepeater>
</ScrollViewer>
```

```csharp
internal sealed class CardControl : CardControlBase
{
    protected override AutomationPeer OnCreateAutomationPeer() => new CardControlAutomationPeer(this);

    private sealed class CardControlAutomationPeer : FrameworkElementAutomationPeer
    {
        private readonly CardControl owner;

        public CardControlAutomationPeer(CardControl owner) : base(owner) => this.owner = owner;

        protected override int GetPositionInSetCore()
          => ((ItemsRepeater)owner.Parent)?.GetElementIndex(this.owner) + 1 ?? base.GetPositionInSetCore();

        protected override int GetSizeOfSetCore()
          => ((ItemsRepeater)owner.Parent)?.ItemsSourceView?.Count ?? base.GetSizeOfSetCore();
    }
}
```

## <a name="related-articles"></a>関連記事

- [リスト](lists.md)
- [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)
- [ScrollViewer](/uwp/api/windows.ui.xaml.controls.scrollviewer)
