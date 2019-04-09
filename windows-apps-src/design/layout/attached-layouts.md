---
Description: ItemsRepeater コントロールなどのコンテナーで使用するために接続されているレイアウトを定義することができます。
title: AttachedLayout
label: AttachedLayout
template: detail.hbs
ms.date: 03/13/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 6ff73b13acb5f5970bb79755b0bf5706fb12545a
ms.sourcegitcommit: c10d7843ccacb8529cb1f53948ee0077298a886d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2019
ms.locfileid: "58913992"
---
# <a name="attached-layouts"></a>接続されているレイアウト

別のオブジェクトには、そのレイアウト ロジックをデリゲートするコンテナー (パネルなど) は、その子要素のレイアウト動作を提供する添付レイアウト オブジェクトに依存します。  UI (列内で整列させる表示されるテーブルの行の項目など) のさまざまな部分の間でのレイアウトの側面をより簡単に共有または、接続されているレイアウト モデルは、実行時に項目のレイアウトを変更するアプリケーションの柔軟性を提供します。

このトピックで、接続されているレイアウト (仮想化と非仮想化)、概念と詳細については、必要になるクラスを作成する手順について説明し、上のトレードオフそれらの間を決定する際に考慮する必要があります。

| **Windows UI ライブラリを入手する** |
| - |
| このコントロールは、Windows の UI ライブラリを新しいコントロール、および UWP アプリの UI 機能を含む NuGet パッケージの一部として含まれています。 インストール手順を含む詳細については、次を参照してください。、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)します。 |

> **重要な API**:

> * [ScrollViewer](/uwp/api/windows.ui.xaml.controls.scrollviewer)
> * [ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater)
> * [レイアウト](/uwp/api/microsoft.ui.xaml.controls.layout)
>     * [NonVirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout)
>     * [VirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)
> * [LayoutContext](/uwp/api/microsoft.ui.xaml.controls.layoutcontext)
>     * [NonVirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayoutcontext)
>     * [VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext)
> * [LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel) (プレビュー)

## <a name="key-concepts"></a>主要概念

レイアウトを実行するには、すべての要素の 2 つの質問に応答することが必要です。

1. どのような***サイズ***この要素になりますか?

2. どのような***位置***この要素のでしょうか。

XAML のレイアウト システムは、これらの質問の回答はのディスカッションの一部として対象について簡単に[カスタム パネル](/windows/uwp/design/layout/custom-panels-overview)します。

### <a name="containers-and-context"></a>コンテナーとコンテキスト

概念的には、XAML の[パネル](/uwp/api/windows.ui.xaml.controls.panel)フレームワークで 2 つの重要な役割を塗りつぶします。

1. 子要素を含めることができ、要素のツリーの分岐が導入されています。
2. 特定のレイアウトの戦略は、これらの子に適用されます。

このため、XAML 内のパネルが多くの場合、レイアウトが厳密に言うと同義はレイアウトだけです。

[ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater)動作と同様に、パネルが、パネルとは異なり、UIElement の子をプログラムで追加または削除できるようにする Children プロパティは公開されません。  代わりに、その子の有効期間はデータ項目のコレクションに対応するためにフレームワークによって自動的に管理されます。  それから派生していないパネルが動作し、パネルのように、フレームワークによって処理されます。

> [!NOTE]
> [LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel)パネルで、添付するには、そのロジックをデリゲートする派生コンテナー[レイアウト](/uwp/api/microsoft.ui.xaml.controls.layoutpanel.layout)オブジェクト。  LayoutPanel が*プレビュー*だけでは、現在ご利用いただけます、*プレリリース*WinUI パッケージを削除します。

#### <a name="containers"></a>コンテナー

概念的には、[パネル](/uwp/api/windows.ui.xaml.controls.panel)要素のコンテナーであり、ピクセルをレンダリングする機能もありますが、[バック グラウンド](/uwp/api/windows.ui.xaml.controls.panel.background)します。  パネルは、使いやすいパッケージに共通のレイアウト ロジックをカプセル化する方法を提供します。

概念**レイアウトがアタッチされている**コンテナーの 2 つのロールとレイアウトの明確な区別します。  コンテナーを別のオブジェクトのレイアウト ロジックを委任する場合はそのオブジェクトを呼び出す接続されているレイアウト次のスニペットに示すよう。 コンテナーから継承する[FrameworkElement](/uwp/api/windows.ui.xaml.frameworkelement)など、LayoutPanel XAML のレイアウト プロセス (高さや幅など) への入力を提供する共通のプロパティを自動的に公開します。

```xaml
<LayoutPanel>
    <LayoutPanel.Layout>
        <UniformGridLayout/>
    </LayoutPanel.Layout>
    <Button Content="1"/>
    <Button Content="2"/>
    <Button Content="3"/>
</LayoutPanel>
```

レイアウトの処理中に、コンテナーが関連付けられているに依存*UniformGridLayout*を測定し、その子を配置します。

#### <a name="per-container-state"></a>コンテナーごとの状態

添付のレイアウトでレイアウト オブジェクトの 1 つのインスタンスが関連付けられている*多く*コンテナーは、次のスニペットのようにそのため、する必要がありますいないに依存したりは、ホスト コンテナーを直接参照します。  次に、例を示します。

```xaml
<!-- ... --->
<Page.Resources>
    <ExampleLayout x:Name="exampleLayout"/>
<Page.Resources>

<LayoutPanel x:Name="example1" Layout="{StaticResource exampleLayout}"/>
<LayoutPanel x:Name="example2" Layout="{StaticResource exampleLayout}"/>
<!-- ... --->
```

このような状況の*ExampleLayout*そのレイアウトの計算にし、その状態が格納されている、他の 1 つのパネル内の要素のレイアウトに影響を回避するために使用する状態を慎重に検討する必要があります。  MeasureOverride、ArrangeOverride ロジックは、の値によって異なります。 カスタム パネルに似ていますがなります、*静的*プロパティ。

#### <a name="layoutcontext"></a>LayoutContext

目的、 [LayoutContext](/uwp/api/microsoft.ui.xaml.controls.layoutcontext)ような課題が処理することです。  2 つの間の直接の依存関係を導入することがなく、子要素を取得するなど、ホスト コンテナーとやり取りできるように、接続されているレイアウトを提供します。 コンテキスト、レイアウトが必要ですが、コンテナーの子要素に関連する状態を保存することもできます。

非仮想化の単純なレイアウトは、多くの場合、問題ないように、任意の状態を維持するためには必要ありません。 ただし、グリッドなどのより複雑なレイアウトは、メジャーの間で状態を維持し、値を再計算を回避するために呼び出しを配置する選択できます。

レイアウトの仮想化*多くの場合、* メジャーの間のいくつかの状態を維持し、反復的なレイアウト パスの間にも配置する必要があります。

#### <a name="initializing-and-uninitializing-per-container-state"></a>初期化と初期化解除、コンテナーごとの状態

レイアウトは、コンテナーに関連付けられている場合、 [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore)メソッドは呼び出され、状態を格納するオブジェクトを初期化する機会を提供します。

同様に、ときに、レイアウトから削除される、コンテナー、 [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore)メソッドが呼び出されます。  これにより、そのコンテナーに関連付けられている必要があるが、状態をクリーンアップする機会がレイアウト。

レイアウトの状態のオブジェクトをと共に格納されているし、でコンテナーから取得できる、 [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate)コンテキストのプロパティ。

### <a name="ui-virtualization"></a>UI の仮想化

UI の仮想化まで UI オブジェクトの作成を遅らせることを意味する_必要な場合_します。  パフォーマンスを最適化することをお勧めします。  スクロールしないシナリオを決定する_必要なときに_アプリ固有の項目の任意の数に基づく可能性があります。  アプリのような場合、使用を検討する必要があります、 [x: 負荷](../../xaml-platform/x-load-attribute.md)します。 レイアウトでは、特別な処理は必要ありません。

リストなどのスクロール ベースのシナリオで決定する_必要なときに_「でしょう、ユーザーに表示される」レイアウト プロセス中に配置された場所に大きく依存され、特別な考慮事項を必要とする多くの場合、に基づいて。  このシナリオでは、このドキュメントの焦点です。

> [!NOTE]
> このドキュメントでカバーされていません、スクロールしないシナリオで UI の仮想化シナリオのスクロールを有効にするのと同じ機能を適用できます。  たとえば、データ ドリブン ツール バー コントロールが示さ、リサイクル/表示領域をオーバーフロー メニューと要素の移動で使用可能な領域の変更に応答コマンドの有効期間を管理します。

## <a name="getting-started"></a>作業の開始

最初に、レイアウトを作成する必要がありますが、UI の仮想化をサポートする必要があるかどうかを決定します。

**点に留意してください.**

1. 非仮想化のレイアウトは、作成者に簡単です。 項目の数を小さくする場合は、非仮想化のレイアウトを作成し、ことをお勧めします。
2. プラットフォームで動作する添付のレイアウトのセットを提供する、 [ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater#change-the-layout-of-items)と[LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel)一般的なニーズをカバーします。  これらを理解して、カスタム レイアウトを定義する必要があるかを決定する前にします。
3. 仮想化のレイアウトは、常に、いくつか追加の CPU とメモリ コスト/複雑さ/オーバーヘッド非仮想化のレイアウトと比較があります。  3 倍のビューポートのサイズを一般に、子レイアウトが管理する必要がある場合は領域に合わせて可能性があります、向上率化レイアウトから表示できない可能性があります。 3 倍のサイズで、このドキュメントの後半で詳しく説明は、非同期の性質により、Windows と仮想化への影響のスクロールします、です。

> [!TIP]
> 既定の設定の参照のポイントとして、 [ListView](/uwp/api/windows.ui.xaml.controls.listview) (と[ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)) がリサイクル先頭がないことまで、項目の数は、3 倍の現在のビューポートのサイズを入力するだけで十分です。

**基本の種類を選択します。**

![接続されているレイアウト階層](images/xaml-attached-layout-hierarchy.png)

基本[レイアウト](/uwp/api/microsoft.ui.xaml.controls.layout)型添付のレイアウトを作成するための開始点として機能する 2 つの派生型には。

1. [NonVirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout)
2. [VirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)

## <a name="non-virtualizing-layout"></a>非仮想化のレイアウト

非仮想化のレイアウトを作成するためのアプローチは、ユーザーが作成するには理解、[カスタム パネル](/windows/uwp/design/layout/custom-panels-overview)します。  同じ概念が適用されます。  主な違いは、 [NonVirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayoutcontext)使用へのアクセスを[子](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayoutcontext.children)コレクション、およびレイアウトの選択状態を保存することがあります。

1. 基本型から派生[NonVirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout) (パネル) の代わりにします。
2. *(省略可能)* 依存関係プロパティを定義する場合の変更は、レイアウトが無効にします。
3. _(**新規**/省略可能)_ の一部として、レイアウトに必要な任意の状態オブジェクトの初期化、 [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore)します。 使用して、ホスト コンテナーを格納すること、 [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate)コンテキストを提供します。
4. オーバーライド、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout.measureoverride)を呼び出すと、[メジャー](/uwp/api/windows.ui.xaml.uielement.measure)メソッドのすべての子にします。
5. オーバーライド、 [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout.arrangeoverride)を呼び出すと、[配置](/uwp/api/windows.ui.xaml.uielement.arrange)メソッドのすべての子にします。
6. *(**新規**/省略可能)* の一部として保存された状態をクリーンアップ、 [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore)します。

### <a name="example-a-simple-stack-layout-varying-sized-items"></a>以下に例を示します。単純なスタック レイアウト (さまざまなサイズの項目)

![MyStackLayout](images/xaml-attached-layout-mystacklayout.png)

さまざまなサイズの項目の非常に基本的な非仮想化スタック レイアウトを次に示します。 レイアウトの動作を調整するすべてのプロパティが不足しています。 次の実装では、レイアウトはコンテナーによって提供されるコンテキスト オブジェクトに依存する方法を示しています。

1. 子の数を取得し、
2. 各子要素のインデックスを使用してアクセスします。

```csharp
public class MyStackLayout : NonVirtualizingLayout
{
    protected override Size MeasureOverride(NonVirtualizingLayoutContext context, Size availableSize)
    {
        double extentHeight = 0.0;
        foreach (var element in context.Children)
        {
            element.Measure(availableSize);
            extentHeight += element.DesiredSize.Height;
        }

        return new Size(availableSize.Width, extentHeight);
    }

    protected override Size ArrangeOverride(NonVirtualizingLayoutContext context, Size finalSize)
    {
        double offset = 0.0;
        foreach (var element in context.Children)
        {
            element.Arrange(
                new Rect(0, offset, finalSize.Width, element.DesiredSize.Height));
            offset += element.DesiredSize.Height;
        }

        return finalSize;
    }
}
```

```xaml
 <LayoutPanel MaxWidth="196">
    <LayoutPanel.Layout>
        <local:MyStackLayout/>
    </LayoutPanel.Layout>

    <Button HorizontalAlignment="Stretch">1</Button>
    <Button HorizontalAlignment="Right">2</Button>
    <Button HorizontalAlignment="Center">3</Button>
    <Button>4</Button>

</LayoutPanel>
```

## <a name="virtualizing-layouts"></a>レイアウトの仮想化

非仮想化のレイアウトと同様に、仮想化のレイアウトの大まかな手順は、同じです。  複雑さの多くは要素で、ビューポート内を通知し、実現する必要がありますを決定します。

1. 基本型から派生[VirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)します。
2. (省略可能)依存関係プロパティの定義時に変更がレイアウトが無効にします。
3. 一部として、レイアウトで必要な任意の状態オブジェクトの初期化、 [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore)します。 使用して、ホスト コンテナーを格納すること、 [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate)コンテキストを提供します。
4. 上書き、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride)を呼び出すと、[メジャー](/uwp/api/windows.ui.xaml.uielement.measure)メソッドを実現する必要があります。
   1. [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat) (例: 適用されるデータ バインド)、フレームワークによって準備された UIElement を取得するメソッドを使用します。
5. 上書き、 [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride)を呼び出すと、[配置](/uwp/api/windows.ui.xaml.uielement.arrange)実現された各子のメソッド。
6. (省略可能)いずれかをクリーンアップするには、一部として状態を保存、 [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore)します。

> [!TIP]
> によって返される値、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)仮想化されたコンテンツのサイズとして使用されます。

仮想化のレイアウトを作成するときに考慮すべき 2 つの一般的な方法はあります。  ほとんどのどちらかを選択するかどうかは、「方法はサイズを決定する要素の」に依存します。  最終的なサイズを決定十分のデータ セットまたはデータ自体内の項目のインデックスを把握するかどうかは、考えてみましょう。 その**データ依存型**します。  これらより簡単に作成します。  ただし、項目は作成したことを言うと、UI の測定のサイズを決定する唯一の方法は場合は、**コンテンツに依存する**します。  これらは複雑です。

### <a name="the-layout-process"></a>レイアウトの処理

データまたはコンテンツに依存するレイアウトを作成するかどうかは、レイアウト プロセスと Windows の非同期のスクロールの影響を理解する必要があります。

(上) スタートアップから画面に UI を表示するためにフレームワークによって実行される手順の簡略化されたビューです。

1. マークアップを解析します。

2. 要素のツリーを生成します。

3. レイアウト パスを実行します。

4. レンダリング パスを実行します。

UI の仮想化、手順 2. で通常行う必要がある要素を作成する遅延または 1 回早期終了その決定されてそのための十分なコンテンツが作成された、ビューポートを入力します。 仮想コンテナー (例: ItemsRepeater) は、このプロセスをドライブに接続されているレイアウトに従います。 接続されているレイアウトを提供します、 [VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext)化レイアウトが必要な追加情報を明らかになります。

**RealizationRect (つまりビューポート)**

Windows 上のスクロールは、UI スレッドに非同期発生します。 フレームワークのレイアウトでは管理されません。  代わりに、相互作用と移動は、システムのコンポジターで発生します。 このアプローチの利点は、60 fps で、コンテンツをパンできる常に行われます。  ただしの課題は、""、ビューポート、レイアウトから見たが実際に画面に表示がどのような基準とした若干古い可能性があることです。 ユーザーが迅速にスクロールする場合の新しいコンテンツおよび「を黒にパン」を生成する UI スレッドの速度が値を上回る可能性があります。 このためは、仮想化レイアウトのビューポートを超える領域を埋めるに十分な準備済みの要素の追加のバッファーを生成する必要があります。 提供する際、ユーザーがスクロール中にさらに高い負荷がまだコンテンツ。

![四角形の実現](images/xaml-attached-layout-realizationrect.png)

要素の作成は高コストであるために、コンテナーを仮想化 (例: [ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater)) で接続されているレイアウトは、最初に、 [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)ビューポートに一致します。 アイドル時、コンテナーは、ますます大きく実現可変噴出口を使用して、レイアウトを繰り返し呼び出すことで準備済みのコンテンツのバッファーを拡張可能性があります。 この動作は、パフォーマンスを最適化する高速スタートアップ時間と良好なパンのエクスペリエンス間のバランスを取るように試みます。 ItemsRepeater により生成される最大バッファー サイズはによって制御されます。 その[VerticalCacheLength](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.verticalcachelength)と[HorizontalCacheLength](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.verticalcachelength)プロパティ。

**(リサイクル) 要素を再利用**

サイズし、位置を埋める要素をレイアウトが必要です、 [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)たびに実行します。 既定では、 [VirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)各レイアウト パスの最後に、未使用の要素をリサイクルします。

[VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext)の一部として、レイアウトに渡される、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride)と[ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride)追加情報を提供します。仮想化のレイアウトが必要です。 最もよく使用されるものを提供しますが、機能です。

1. データ内の項目の数を照会 ([ItemCount](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.itemcount))。
2. 項目を使用して、特定の取得、 [GetItemAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getitemat)メソッド。
3. 取得、 [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)ビューポートを表すし、レイアウトの塗りつぶしのバッファーが要素を実現します。
4. 要求で特定の品目の UIElement、 [GetOrCreateElement](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)メソッド。

指定されたインデックスの要素を要求すると、そのパス レイアウトの「使用中」としてマークするには、その要素が発生します。 要素が存在しない場合は実現され、自動的に (例: 増やして UI ツリーを任意のデータ バインディングなどの処理、DataTemplate に定義します。) 使用できるように準備します。  それ以外の場合、既存のインスタンスのプールから取得されます。

各測定パスの末尾には、任意の既存実現「使用中」としてマークされていない要素が再利用できると見なされるに自動的にしない限り、オプションを[SuppressAutoRecycle](/uwp/api/microsoft.ui.xaml.controls.elementrealizationoptions)要素を使用して取得したときに使用された、[GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)メソッド。 フレームワークは自動的にリサイクル プールに移動され、使用できるようにします。 これは、可能性があります、その後によってプルされる使用するための別のコンテナー。 フレームワークは、この問題を回避可能な場合は親の再指定要素に関連付けられているいくつかのコストを試みます。

先頭の要素が実現四角形内には不要になった各メジャーの仮想化のレイアウトを知っている場合、ことができます最適化の再利用します。 フレームワークの既定の動作に頼るにします。 レイアウトを使用してプールのリサイクルに要素を事前移動できます、 [RecycleElement](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recycleelement)メソッド。  レイアウトを後で発行するときに、既存の要素を新しい要素を要求する前にこのメソッドを呼び出すことにより、 [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)要素に関連付けられていない既にインデックスの要求。

VirtualizingLayoutContext レイアウトの作成者がコンテンツに依存するレイアウトの作成用に設計された 2 つの追加のプロパティを提供します。 後で詳しく説明するは。

1. A [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex)オプションを提供する_入力_レイアウトにします。
2. A [LayoutOrigin](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.layoutorigin)は省略可能な_出力_のレイアウト。

## <a name="data-dependent-virtualizing-layouts"></a>データ依存の仮想化のレイアウト

仮想化のレイアウトは、表示するコンテンツを測定することがなくすべての項目のサイズはわかっている場合は簡単です。  このドキュメントを参照としてレイアウトを仮想化するには、このカテゴリに**データ レイアウト**通常必要になるため、データを検査します。  アプリが選択既知のサイズ - 視覚的に表現おそらくため、データに基づくデータの一部で、デザインによって決定された以前またはします。

一般的な方法は、レイアウトには。

1. サイズとすべての項目の位置を計算します。
2. 一部として、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride):
   1. 使用して、 [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)ビューポート内の項目の順序を決定します。
   2. 持つ項目を表す UIElement の取得、 [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)メソッド。
   3. [メジャー](/uwp/api/windows.ui.xaml.uielement.measure)事前に計算されたサイズの UIElement です。
3. 一部として、 [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride)、[配置](/uwp/api/windows.ui.xaml.uielement.arrange)各こと、また UIElement は、事前計算済みの位置で実現します。

> [!NOTE]
> データのレイアウト方法は、多くの場合と互換性のある_データ仮想化_します。  具体的には、唯一のデータがメモリに読み込まれるはそのデータには、ユーザーに表示される内容を入力する必要です。  データ仮想化はされていないユーザーがそのデータが常駐をスクロールすると、データの遅延または増分読み込みを参照します。  代わりに、ようにビューからスクロールされたときに、項目がメモリから解放されるときを参照しています。  データのレイアウトの一部は、期待どおりの作業用のデータ仮想化にできなくなると、すべてのデータ項目を調査するデータのレイアウトを持ちます。  すべての要素が同じサイズであることを前提としている UniformGridLayout などのレイアウトは例外です。

> [!TIP]
> さまざまな状況で他のユーザーによって使用されるコントロール ライブラリのカスタム コントロールを作成する場合は、するオプションが可能性がありますいないデータ レイアウトにします。

### <a name="example-xbox-activity-feed-layout"></a>以下に例を示します。レイアウトの Xbox アクティビティ フィード

Xbox アクティビティ フィードの UI では、各行が後続の行では、反転 2 つの幅が狭いタイルの後に、ワイド タイルには、繰り返しパターンを使用します。 このレイアウトでは、すべての項目のサイズは、アイテムの位置で、データ セットと、タイルの既知のサイズ (ワイド vs を絞り込む) の関数です。

![Xbox アクティビティ フィード](images/xaml-attached-layout-activityfeedscreenshot.png)

どのようなカスタムの仮想化を示すために、アクティビティ フィード用の UI があります。 一般的なアプローチを使用していきます次のコードがかかる場合があります、**データ レイアウト**します。

<table>
<td>
    <p>ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして、アプリを開きを参照してください、 <a href="xamlcontrolsgallery:/item/ItemsRepeater">ItemsRepeater</a>のこのサンプル レイアウトで動作します。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

#### <a name="implementation"></a>実装

```csharp
/// <summary>
///  This is a custom layout that displays elements in two different sizes
///  wide (w) and narrow (n). There are two types of rows 
///  odd rows - narrow narrow wide
///  even rows - wide narrow narrow
///  This pattern repeats.
/// </summary>

public class ActivityFeedLayout : VirtualizingLayout // STEP #1 Inherit from base attached layout
{
    // STEP #2 - Parameterize the layout
    #region Layout parameters

    // We'll cache copies of the dependency properties to avoid calling GetValue during layout since that
    // can be quite expensive due to the number of times we'd end up calling these.
    private double _rowSpacing;
    private double _colSpacing;
    private Size _minItemSize = Size.Empty;

    /// <summary>
    /// Gets or sets the size of the whitespace gutter to include between rows
    /// </summary>
    public double RowSpacing
    {
        get { return _rowSpacing; }
        set { SetValue(RowSpacingProperty, value); }
    }

    /// <summary>
    /// Gets or sets the size of the whitespace gutter to include between items on the same row
    /// </summary>
    public double ColumnSpacing
    {
        get { return _colSpacing; }
        set { SetValue(ColumnSpacingProperty, value); }
    }

    public Size MinItemSize
    {
        get { return _minItemSize; }
        set { SetValue(MinItemSizeProperty, value); }
    }

    public static readonly DependencyProperty RowSpacingProperty =
        DependencyProperty.Register(
            nameof(RowSpacing),
            typeof(double),
            typeof(ActivityFeedLayout),
            new PropertyMetadata(0, OnPropertyChanged));

    public static readonly DependencyProperty ColumnSpacingProperty =
        DependencyProperty.Register(
            nameof(ColumnSpacing),
            typeof(double),
            typeof(ActivityFeedLayout),
            new PropertyMetadata(0, OnPropertyChanged));

    public static readonly DependencyProperty MinItemSizeProperty =
        DependencyProperty.Register(
            nameof(MinItemSize),
            typeof(Size),
            typeof(ActivityFeedLayout),
            new PropertyMetadata(Size.Empty, OnPropertyChanged));

    private static void OnPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
        var layout = obj as ActivityFeedLayout;
        if (args.Property == RowSpacingProperty)
        {
            layout._rowSpacing = (double)args.NewValue;
        }
        else if (args.Property == ColumnSpacingProperty)
        {
            layout._colSpacing = (double)args.NewValue;
        }
        else if (args.Property == MinItemSizeProperty)
        {
            layout._minItemSize = (Size)args.NewValue;
        }
        else
        {
            throw new InvalidOperationException("Don't know what you are talking about!");
        }

        layout.InvalidateMeasure();
    }

    #endregion

    #region Setup / teardown // STEP #3: Initialize state

    protected override void InitializeForContextCore(VirtualizingLayoutContext context)
    {
        base.InitializeForContextCore(context);

        var state = context.LayoutState as ActivityFeedLayoutState;
        if (state == null)
        {
            // Store any state we might need since (in theory) the layout could be in use by multiple
            // elements simultaneously
            // In reality for the Xbox Activity Feed there's probably only a single instance.
            context.LayoutState = new ActivityFeedLayoutState();
        }
    }

    protected override void UninitializeForContextCore(VirtualizingLayoutContext context)
    {
        base.UninitializeForContextCore(context);

        // clear any state
        context.LayoutState = null;
    }

    #endregion

    #region Layout // STEP #4,5 - Measure and Arrange

    protected override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
    {
        if (this.MinItemSize == Size.Empty)
        {
            var firstElement = context.GetOrCreateElementAt(0);
            firstElement.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            // setting the member value directly to skip invalidating layout
            this._minItemSize = firstElement.DesiredSize;
        }

        // Determine which rows need to be realized.  We know every row will have the same height and
        // only contain 3 items.  Use that to determine the index for the first and last item that
        // will be within that realization rect.
        var firstRowIndex = Math.Max(
            (int)(context.RealizationRect.Y / (this.MinItemSize.Height + this.RowSpacing)) - 1,
            0);
        var lastRowIndex = Math.Min(
            (int)(context.RealizationRect.Bottom / (this.MinItemSize.Height + this.RowSpacing)) + 1,
            (int)(context.ItemCount / 3));

        // Determine which items will appear on those rows and what the rect will be for each item
        var state = context.LayoutState as ActivityFeedLayoutState;
        state.LayoutRects.Clear();

        // Save the index of the first realized item.  We'll use it as a starting point during arrange.
        state.FirstRealizedIndex = firstRowIndex * 3;

        // ideal item width that will expand/shrink to fill available space
        double desiredItemWidth = Math.Max(this.MinItemSize.Width, (availableSize.Width - this.ColumnSpacing * 3) / 4);

        // Foreach item between the first and last index,
        //     Call GetElementOrCreateElementAt which causes an element to either be realized or retrieved
        //       from a recycle pool
        //     Measure the element using an appropriate size
        //
        // Any element that was previously realized which we don't retrieve in this pass (via a call to
        // GetElementOrCreateAt) will be automatically cleared and set aside for later re-use.
        // Note: While this work fine, it does mean that more elements than are required may be
        // created because it isn't until after our MeasureOverride completes that the unused elements
        // will be recycled and available to use.  We could avoid this by choosing to track the first/last
        // index from the previous layout pass.  The diff between the previous range and current range
        // would represent the elements that we can pre-emptively make available for re-use by calling
        // context.RecycleElement(element).
        for (int rowIndex = firstRowIndex; rowIndex < lastRowIndex; rowIndex++)
        {
            int firstItemIndex = rowIndex * 3;
            var boundsForCurrentRow = CalculateLayoutBoundsForRow(rowIndex, desiredItemWidth);

            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                var index = firstItemIndex + columnIndex;
                var rect = boundsForCurrentRow[index % 3];
                var container = context.GetOrCreateElementAt(index);

                container.Measure(
                    new Size(boundsForCurrentRow[columnIndex].Width, boundsForCurrentRow[columnIndex].Height));

                state.LayoutRects.Add(boundsForCurrentRow[columnIndex]);
            }
        }

        // Calculate and return the size of all the content (realized or not) by figuring out
        // what the bottom/right position of the last item would be.
        var extentHeight = ((int)(context.ItemCount / 3) - 1) * (this.MinItemSize.Height + this.RowSpacing) + this.MinItemSize.Height;

        // Report this as the desired size for the layout
        return new Size(desiredItemWidth * 4 + this.ColumnSpacing * 2, extentHeight);
    }

    protected override Size ArrangeOverride(VirtualizingLayoutContext context, Size finalSize)
    {
        // walk through the cache of containers and arrange
        var state = context.LayoutState as ActivityFeedLayoutState;
        var virtualContext = context as VirtualizingLayoutContext;
        int currentIndex = state.FirstRealizedIndex;

        foreach (var arrangeRect in state.LayoutRects)
        {
            var container = virtualContext.GetOrCreateElementAt(currentIndex);
            container.Arrange(arrangeRect);
            currentIndex++;
        }

        return finalSize;
    }

    #endregion
    #region Helper methods

    private Rect[] CalculateLayoutBoundsForRow(int rowIndex, double desiredItemWidth)
    {
        var boundsForRow = new Rect[3];

        var yoffset = rowIndex * (this.MinItemSize.Height + this.RowSpacing);
        boundsForRow[0].Y = boundsForRow[1].Y = boundsForRow[2].Y = yoffset;
        boundsForRow[0].Height = boundsForRow[1].Height = boundsForRow[2].Height = this.MinItemSize.Height;

        if (rowIndex % 2 == 0)
        {
            // Left tile (narrow)
            boundsForRow[0].X = 0;
            boundsForRow[0].Width = desiredItemWidth;
            // Middle tile (narrow)
            boundsForRow[1].X = boundsForRow[0].Right + this.ColumnSpacing;
            boundsForRow[1].Width = desiredItemWidth;
            // Right tile (wide)
            boundsForRow[2].X = boundsForRow[1].Right + this.ColumnSpacing;
            boundsForRow[2].Width = desiredItemWidth * 2 + this.ColumnSpacing;
        }
        else
        {
            // Left tile (wide)
            boundsForRow[0].X = 0;
            boundsForRow[0].Width = (desiredItemWidth * 2 + this.ColumnSpacing);
            // Middle tile (narrow)
            boundsForRow[1].X = boundsForRow[0].Right + this.ColumnSpacing;
            boundsForRow[1].Width = desiredItemWidth;
            // Right tile (narrow)
            boundsForRow[2].X = boundsForRow[1].Right + this.ColumnSpacing;
            boundsForRow[2].Width = desiredItemWidth;
        }

        return boundsForRow;
    }

    #endregion
}

internal class ActivityFeedLayoutState
{
    public int FirstRealizedIndex { get; set; }

    /// <summary>
    /// List of layout bounds for items starting with the
    /// FirstRealizedIndex.
    /// </summary>
    public List<Rect> LayoutRects
    {
        get
        {
            if (_layoutRects == null)
            {
                _layoutRects = new List<Rect>();
            }

            return _layoutRects;
        }
    }

    private List<Rect> _layoutRects;
}
```

### <a name="optional-managing-the-item-to-uielement-mapping"></a>(省略可能)UIElement のマッピングに項目を管理します。

既定で、 [VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext)実現された要素となるデータ ソース内のインデックス間のマッピングを保持します。  このマッピング自体をするためのオプションを常に要求を管理するレイアウトを選択できます[SuppressAutoRecycle](/uwp/api/microsoft.ui.xaml.controls.elementrealizationoptions)経由の要素を取得するときに、 [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)メソッドの既定値を実行できなくなります。自動リサイクル動作します。  1 つの方向に制限は、スクロールと見なされる場合、項目が (つまり知る最初と最後の要素のインデックスは市外をする必要があるすべての要素を把握するのに十分な連続したは常には使用のみ場合に、たとえば、レイアウトを選択できます。lized)。

#### <a name="example-xbox-activity-feed-measure"></a>以下に例を示します。メジャーの Xbox アクティビティ フィード

次のスニペットは、マッピングを管理する前の例で MeasureOverride に追加できる追加のロジックを示しています。

```csharp
    protected override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
    {
        //...

        // Determine which items will appear on those rows and what the rect will be for each item
        var state = context.LayoutState as ActivityFeedLayoutState;
        state.LayoutRects.Clear();

         // Recycle previously realized elements that we know we won't need so that they can be used to
        // fill in gaps without requiring us to realize additional elements.
        var newFirstRealizedIndex = firstRowIndex * 3;
        var newLastRealizedIndex = lastRowIndex * 3 + 3;
        for (int i = state.FirstRealizedIndex; i < newFirstRealizedIndex; i++)
        {
            context.RecycleElement(state.IndexToElementMap.Get(i));
            state.IndexToElementMap.Clear(i);
        }

        for (int i = state.LastRealizedIndex; i < newLastRealizedIndex; i++)
        {
            context.RecycleElement(context.IndexElementMap.Get(i));
            state.IndexToElementMap.Clear(i);
        }

        // ...

        // Foreach item between the first and last index,
        //     Call GetElementOrCreateElementAt which causes an element to either be realized or retrieved
        //       from a recycle pool
        //     Measure the element using an appropriate size
        //
        for (int rowIndex = firstRowIndex; rowIndex < lastRowIndex; rowIndex++)
        {
            int firstItemIndex = rowIndex * 3;
            var boundsForCurrentRow = CalculateLayoutBoundsForRow(rowIndex, desiredItemWidth);

            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                var index = firstItemIndex + columnIndex;
                var rect = boundsForCurrentRow[index % 3];
                UIElement container = null;
                if (state.IndexToElementMap.Contains(index))
                {
                    container = state.IndexToElementMap.Get(index);
                }
                else
                {
                    container = context = context.GetOrCreateElementAt(index, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
                    state.IndexToElementMap.Add(index, container);
                }

                container.Measure(
                    new Size(boundsForCurrentRow[columnIndex].Width, boundsForCurrentRow[columnIndex].Height));

                state.LayoutRects.Add(boundsForCurrentRow[columnIndex]);
            }
        }

        // ...
   }

internal class ActivityFeedLayoutState
{
    // ...
    Dictionary<int, UIElement> IndexToElementMap { get; set; }
    // ...
}
```

## <a name="content-dependent-virtualizing-layouts"></a>コンテンツに依存する仮想化のレイアウト

実際のサイズを確認する項目用の UI コンテンツを測定する必要がありますまず場合は、**コンテンツに依存するレイアウト**します。  項目のサイズを示すレイアウトではなく、各項目のサイズする必要がありますレイアウトとしては、そのも考えることができます。 このカテゴリに分類される仮想化のレイアウトは複雑です。

> [!NOTE]
> レイアウトのコンテンツに依存しないデータの仮想化を解除 (しないでください)。

### <a name="estimations"></a>見積もり

コンテンツに依存するレイアウトは、実現されていないコンテンツのサイズと実際のコンテンツの位置の両方を推測する推定に依存します。 これらの推定が変わると、スクロール可能な領域内の位置を定期的にシフトする実際のコンテンツが発生します。 これは、ユーザー エクスペリエンスは非常に面倒で少し目障りな感じ可能性がない場合は軽減。 潜在的な問題と軽減策がここで説明します。

> [!NOTE]
> すべての項目を考慮し、またはそうでないことに気付きました、すべてのアイテムとその位置の正確なサイズを把握しているデータ レイアウトでは、すべてこれらの問題を回避できます。

**アンカーのスクロール**

XAML コントロールのサポートをスクロールすることで急激なビューポート シフトを軽減するためのメカニズムを提供する[アンカーのスクロール](/uwp/api/windows.ui.xaml.controls.iscrollanchorprovider)実装することによって、 [IScrollAnchorPovider](/uwp/api/windows.ui.xaml.controls.iscrollanchorprovider)インターフェイス。 ユーザーがコンテンツを操作すると、スクロール コントロールは継続的に追跡にオプトインされた候補のセットから要素を選択します。 レイアウト中にアンカー要素の位置を移動する場合、スクロール コントロールは、ビューポートを維持するために、ビューポートを自動的に移動します。

値、 [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex)に提供されるレイアウトは、その現在選択されているアンカー要素のスクロール コントロールが選択を反映可能性があります。 また、開発者が明示的に使用して、インデックスの要素を実現することを要求した場合、 [GetOrCreateElement](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.getorcreateelement)メソッドを[ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)、として、そのインデックスが指定し、 [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex)次のレイアウト パスにします。 これにより、開発者は、要素のことを認識し、後で要求を使用して表示にする起動される可能性が高いシナリオに備えるレイアウト、 [StartBringIntoView](/uwp/api/windows.ui.xaml.uielement.startbringintoview)メソッド。

[RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex)はコンテンツに依存するレイアウトはその項目の位置を推定するときに最初に位置する必要がありますデータ ソース内の項目のインデックスです。 他の実現された項目の配置の開始点としてサービスを提供する必要があります。

**スクロール バーへの影響**

スクロールがアンカーを使用してもレイアウトの見積もりがでさまざまなバリエーションにより、おそらく異なる場合、コンテンツのサイズ、スクロール バーのつまみの位置に見えますがやや大きく変化します。  Thumb をドラッグしているときに、マウス ポインターの位置を追跡するために表示されない場合は、ユーザーに不快にできます。

より正確なレイアウトにできる、ツールは、見積もり、ほど、ユーザーがジャンプ スクロールバーのつまみ表示されます。

### <a name="layout-corrections"></a>レイアウトの修正

現実の見積もりを合理化するには、コンテンツに依存するレイアウトを準備する必要があります。  例: にスクロールすると、コンテンツとレイアウトの上部には、最初の要素が認識しています、起動元の要素に対する要素の予想される位置は原因は原点 (x: 0 以外のどこかに表示することがあります。、y:0)。 この場合、レイアウトが使用できる、 [LayoutOrigin](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.layoutorigin)新しいレイアウトの配信元として、計算される位置を設定するプロパティ。  最終的な結果は、スクロールをスクロール コントロールのビューポート自動的に調整されたコンテンツの位置のアカウントにレイアウトによって報告されたアンカーに似ています。

![LayoutOrigin を修正します。](images/xaml-attached-layout-origincorrection.png)

### <a name="disconnected-viewports"></a>切断されたビューポート

サイズがレイアウトから返された[MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride)メソッドは、連続する各レイアウトの変更の可能性あり、コンテンツのサイズで最善の推測を表します。  レイアウトが、更新された継続的に再評価するユーザーがスクロール[RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)します。

ユーザーが非常に迅速に thumb をドラッグし、可能な限り大きなように表示するレイアウトの観点から、ビューポートにジャンプ前の位置が、これで現在の位置を重複しないです。  これは、非同期の性質により、スクロールします。 要素に状態が現在実現されていないと、レイアウトによって追跡される現在の範囲外のレイアウトの推定は項目の表示になることを要求するレイアウトを利用しているアプリのこともできます。

レイアウトを検出されると、その推定値が正しくないや予期しないビューポートの shift キーを表示、開始位置の方向を変更が必要です。  XAML コントロールの一部として出荷される仮想化のレイアウトより少ない制限に表示されるコンテンツの性質上に配置すると、コンテンツに依存するレイアウトとして開発されています。


### <a name="example-simple-virtualizing-stack-layout-for-variable-sized-items"></a>以下に例を示します。可変サイズの項目の単純な仮想化スタック レイアウト

次の例では項目を可変サイズの単純なスタック レイアウトを示しています。

* UI の仮想化をサポートしています
* ツールは、見積もりを使用して実現されていない項目のサイズを推測するには
* 不連続のビューポート シフトする可能性がある場合を認識し、
* これらのシフトに対応するレイアウトの修正を適用します。

**使い方:マークアップ**

```xaml
<ScrollViewer>

  <ItemsRepeater x:Name="repeater" >
    <ItemsRepeater.Layout>

      <local:VirtualizingStackLayout />

    </ItemsRepeater.Layout>
    <ItemsRepeater.ItemTemplate>
      <DataTemplate x:Key="item">
        <UserControl IsTabStop="True" UseSystemFocusVisuals="True" Margin="5">
          <StackPanel BorderThickness="1" Background="LightGray" Margin="5">
            <Image x:Name="recipeImage" Source="{Binding ImageUri}"  Width="100" Height="100"/>
              <TextBlock x:Name="recipeDescription"
                         Text="{Binding Description}"
                         TextWrapping="Wrap"
                         Margin="10" />
          </StackPanel>
        </UserControl>
      </DataTemplate>
    </ItemsRepeater.ItemTemplate>
  </ItemsRepeater>

</ScrollViewer>
```

**分離コード:Main.cs**

```csharp
string _lorem = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam laoreet erat vel massa rutrum, eget mollis massa vulputate. Vivamus semper augue leo, eget faucibus nulla mattis nec. Donec scelerisque lacus at dui ultricies, eget auctor ipsum placerat. Integer aliquet libero sed nisi eleifend, nec rutrum arcu lacinia. Sed a sem et ante gravida congue sit amet ut augue. Donec quis pellentesque urna, non finibus metus. Proin sed ornare tellus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam laoreet erat vel massa rutrum, eget mollis massa vulputate. Vivamus semper augue leo, eget faucibus nulla mattis nec. Donec scelerisque lacus at dui ultricies, eget auctor ipsum placerat. Integer aliquet libero sed nisi eleifend, nec rutrum arcu lacinia. Sed a sem et ante gravida congue sit amet ut augue. Donec quis pellentesque urna, non finibus metus. Proin sed ornare tellus.";

var rnd = new Random();
var data = new ObservableCollection<Recipe>(Enumerable.Range(0, 300).Select(k =>
               new Recipe
               {
                   ImageUri = new Uri(string.Format("ms-appx:///Images/recipe{0}.png", k % 8 + 1)),
                   Description = k + " - " + _lorem.Substring(0, rnd.Next(50, 350))
               }));

repeater.ItemsSource = data;
```

**コード:VirtualizingStackLayout.cs**

```csharp
// This is a sample layout that stacks elements one after
// the other where each item can be of variable height. This is
// also a virtualizing layout - we measure and arrange only elements
// that are in the viewport. Not measuring/arranging all elements means
// that we do not have the complete picture and need to estimate sometimes.
// For example the size of the layout (extent) is an estimation based on the
// average heights we have seen so far. Also, if you drag the mouse thumb
// and yank it quickly, then we estimate what goes in the new viewport.

// The layout caches the bounds of everything that are in the current viewport.
// During measure, we might get a suggested anchor (or start index), we use that
// index to start and layout the rest of the items in the viewport relative to that
// index. Note that since we are estimating, we can end up with negative origin when
// the viewport is somewhere in the middle of the extent. This is achieved by setting the
// LayoutOrigin property on the context. Once this is set, future viewport will account
// for the origin.
public class VirtualizingStackLayout : VirtualizingLayout
{
    // Estimation state
    List<double> m_estimationBuffer = Enumerable.Repeat(0d, 100).ToList();
    int m_numItemsUsedForEstimation = 0;
    double m_totalHeightForEstimation = 0;

    // State to keep track of realized bounds
    int m_firstRealizedDataIndex = 0;
    List<Rect> m_realizedElementBounds = new List<Rect>();

    Rect m_lastExtent = new Rect();

    protected override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
    {
        var viewport = context.RealizationRect;
        DebugTrace("MeasureOverride: Viewport " + viewport);

        // Remove bounds for elements that are now outside the viewport.
        // Proactive recycling elements means we can reuse it during this measure pass again.
        RemoveCachedBoundsOutsideViewport(viewport);

        // Find the index of the element to start laying out from - the anchor
        int startIndex = GetStartIndex(context, availableSize);

        // Measure and layout elements starting from the start index, forward and backward.
        Generate(context, availableSize, startIndex, forward:true);
        Generate(context, availableSize, startIndex, forward:false);

        // Estimate the extent size. Note that this can have a non 0 origin.
        m_lastExtent = EstimateExtent(context, availableSize);
        context.LayoutOrigin = new Point(m_lastExtent.X, m_lastExtent.Y);
        return new Size(m_lastExtent.Width, m_lastExtent.Height);
    }

    protected override Size ArrangeOverride(VirtualizingLayoutContext context, Size finalSize)
    {
        DebugTrace("ArrangeOverride: Viewport" + context.RealizationRect);
        for (int realizationIndex = 0; realizationIndex < m_realizedElementBounds.Count; realizationIndex++)
        {
            int currentDataIndex = m_firstRealizedDataIndex + realizationIndex;
            DebugTrace("Arranging " + currentDataIndex);

            // Arrange the child. If any alignment needs to be done, it
            // can be done here.
            var child = context.GetOrCreateElementAt(currentDataIndex);
            var arrangeBounds = m_realizedElementBounds[realizationIndex];
            arrangeBounds.X -= m_lastExtent.X;
            arrangeBounds.Y -= m_lastExtent.Y;
            child.Arrange(arrangeBounds);
        }

        return finalSize;
    }

    // The data collection has changed, since we are maintaining the bounds of elements
    // in the viewport, we will update the list to account for the collection change.
    protected override void OnItemsChangedCore(VirtualizingLayoutContext context, object source, NotifyCollectionChangedEventArgs args)
    {
        InvalidateMeasure();
        if (m_realizedElementBounds.Count > 0)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    OnItemsAdded(args.NewStartingIndex, args.NewItems.Count);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    OnItemsRemoved(args.OldStartingIndex, args.OldItems.Count);
                    OnItemsAdded(args.NewStartingIndex, args.NewItems.Count);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    OnItemsRemoved(args.OldStartingIndex, args.OldItems.Count);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    m_realizedElementBounds.Clear();
                    m_firstRealizedDataIndex = 0;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    // Figure out which index to use as the anchor and start laying out around it.
    private int GetStartIndex(VirtualizingLayoutContext context, Size availableSize)
    {
        int startDataIndex = -1;
        var recommendedAnchorIndex = context.RecommendedAnchorIndex;
        bool isSuggestedAnchorValid = recommendedAnchorIndex != -1;

        if (isSuggestedAnchorValid)
        {
            if (IsRealized(recommendedAnchorIndex))
            {
                startDataIndex = recommendedAnchorIndex;
            }
            else
            {
                ClearRealizedRange();
                startDataIndex = recommendedAnchorIndex;
            }
        }
        else
        {
            // Find the first realized element that is visible in the viewport.
            startDataIndex = GetFirstRealizedDataIndexInViewport(context.RealizationRect);
            if (startDataIndex < 0)
            {
                startDataIndex = EstimateIndexForViewport(context.RealizationRect, context.ItemCount);
                ClearRealizedRange();
            }
        }

        // We have an anchorIndex, realize and measure it and
        // figure out its bounds.
        if (startDataIndex != -1 & context.ItemCount > 0)
        {
            if (m_realizedElementBounds.Count == 0)
            {
                m_firstRealizedDataIndex = startDataIndex;
            }

            var newAnchor = EnsureRealized(startDataIndex);
            DebugTrace("Measuring start index " + startDataIndex);
            var desiredSize = MeasureElement(context, startDataIndex, availableSize);

            var bounds = new Rect(
                0,
                newAnchor ?
                    (m_totalHeightForEstimation / m_numItemsUsedForEstimation) * startDataIndex : GetCachedBoundsForDataIndex(startDataIndex).Y,
                availableSize.Width,
                desiredSize.Height);
            SetCachedBoundsForDataIndex(startDataIndex, bounds);
        }

        return startDataIndex;
    }


    private void Generate(VirtualizingLayoutContext context, Size availableSize, int anchorDataIndex, bool forward)
    {
        // Generate forward or backward from anchorIndex until we hit the end of the viewport
        int step = forward ? 1 : -1;
        int previousDataIndex = anchorDataIndex;
        int currentDataIndex = previousDataIndex + step;
        var viewport = context.RealizationRect;
        while (IsDataIndexValid(currentDataIndex, context.ItemCount) &&
            ShouldContinueFillingUpSpace(previousDataIndex, forward, viewport))
        {
            EnsureRealized(currentDataIndex);
            DebugTrace("Measuring " + currentDataIndex);
            var desiredSize = MeasureElement(context, currentDataIndex, availableSize);
            var previousBounds = GetCachedBoundsForDataIndex(previousDataIndex);
            Rect currentBounds = new Rect(0,
                                          forward ? previousBounds.Y + previousBounds.Height : previousBounds.Y - desiredSize.Height,
                                          availableSize.Width,
                                          desiredSize.Height);
            SetCachedBoundsForDataIndex(currentDataIndex, currentBounds);
            previousDataIndex = currentDataIndex;
            currentDataIndex += step;
        }
    }

    // Remove bounds that are outside the viewport, leaving one extra since our
    // generate stops after generating one extra to know that we are outside the
    // viewport.
    private void RemoveCachedBoundsOutsideViewport(Rect viewport)
    {
        int firstRealizedIndexInViewport = 0;
        while (firstRealizedIndexInViewport < m_realizedElementBounds.Count &&
               !Intersects(m_realizedElementBounds[firstRealizedIndexInViewport], viewport))
        {
            firstRealizedIndexInViewport++;
        }

        int lastRealizedIndexInViewport = m_realizedElementBounds.Count - 1;
        while (lastRealizedIndexInViewport >= 0 &&
            !Intersects(m_realizedElementBounds[lastRealizedIndexInViewport], viewport))
        {
            lastRealizedIndexInViewport--;
        }

        if (firstRealizedIndexInViewport > 0)
        {
            m_firstRealizedDataIndex += firstRealizedIndexInViewport;
            m_realizedElementBounds.RemoveRange(0, firstRealizedIndexInViewport);
        }

        if (lastRealizedIndexInViewport >= 0 && lastRealizedIndexInViewport < m_realizedElementBounds.Count - 2)
        {
            m_realizedElementBounds.RemoveRange(lastRealizedIndexInViewport + 2, m_realizedElementBounds.Count - lastRealizedIndexInViewport - 3);
        }
    }

    private bool Intersects(Rect bounds, Rect viewport)
    {
        return !(bounds.Bottom < viewport.Top ||
            bounds.Top > viewport.Bottom);
    }

    private bool ShouldContinueFillingUpSpace(int dataIndex, bool forward, Rect viewport)
    {
        var bounds = GetCachedBoundsForDataIndex(dataIndex);
        return forward ?
            bounds.Y < viewport.Bottom :
            bounds.Y > viewport.Top;
    }

    private bool IsDataIndexValid(int currentDataIndex, int itemCount)
    {
        return currentDataIndex >= 0 && currentDataIndex < itemCount;
    }

    private int EstimateIndexForViewport(Rect viewport, int dataCount)
    {
        double averageHeight = m_totalHeightForEstimation / m_numItemsUsedForEstimation;
        int estimatedIndex = (int)(viewport.Top / averageHeight);
        // clamp to an index within the collection
        estimatedIndex = Math.Max(0, Math.Min(estimatedIndex, dataCount));
        return estimatedIndex;
    }

    private int GetFirstRealizedDataIndexInViewport(Rect viewport)
    {
        int index = -1;
        if (m_realizedElementBounds.Count > 0)
        {
            for (int i = 0; i < m_realizedElementBounds.Count; i++)
            {
                if (m_realizedElementBounds[i].Y < viewport.Bottom &&
                   m_realizedElementBounds[i].Bottom > viewport.Top)
                {
                    index = m_firstRealizedDataIndex + i;
                    break;
                }
            }
        }

        return index;
    }

    private Size MeasureElement(VirtualizingLayoutContext context, int index, Size availableSize)
    {
        var child = context.GetOrCreateElementAt(index);
        child.Measure(availableSize);

        int estimationBufferIndex = index % m_estimationBuffer.Count;
        bool alreadyMeasured = m_estimationBuffer[estimationBufferIndex] != 0;
        if (!alreadyMeasured)
        {
            m_numItemsUsedForEstimation++;
        }

        m_totalHeightForEstimation -= m_estimationBuffer[estimationBufferIndex];
        m_totalHeightForEstimation += child.DesiredSize.Height;
        m_estimationBuffer[estimationBufferIndex] = child.DesiredSize.Height;

        return child.DesiredSize;
    }

    private bool EnsureRealized(int dataIndex)
    {
        if (!IsRealized(dataIndex))
        {
            int realizationIndex = RealizationIndex(dataIndex);
            Debug.Assert(dataIndex == m_firstRealizedDataIndex - 1 ||
                dataIndex == m_firstRealizedDataIndex + m_realizedElementBounds.Count ||
                m_realizedElementBounds.Count == 0);

            if (realizationIndex == -1)
            {
                m_realizedElementBounds.Insert(0, new Rect());
            }
            else
            {
                m_realizedElementBounds.Add(new Rect());
            }

            if (m_firstRealizedDataIndex > dataIndex)
            {
                m_firstRealizedDataIndex = dataIndex;
            }

            return true;
        }

        return false;
    }

    // Figure out the extent of the layout by getting the number of items remaining
    // above and below the realized elements and getting an estimation based on
    // average item heights seen so far.
    private Rect EstimateExtent(VirtualizingLayoutContext context, Size availableSize)
    {
        double averageHeight = m_totalHeightForEstimation / m_numItemsUsedForEstimation;

        Rect extent = new Rect(0, 0, availableSize.Width, context.ItemCount * averageHeight);

        if (context.ItemCount > 0 && m_realizedElementBounds.Count > 0)
        {
            extent.Y = m_firstRealizedDataIndex == 0 ?
                            m_realizedElementBounds[0].Y :
                            m_realizedElementBounds[0].Y - (m_firstRealizedDataIndex - 1) * averageHeight;

            int lastRealizedIndex = m_firstRealizedDataIndex + m_realizedElementBounds.Count;
            if (lastRealizedIndex == context.ItemCount - 1)
            {
                var lastBounds = m_realizedElementBounds[m_realizedElementBounds.Count - 1];
                extent.Y = lastBounds.Bottom;
            }
            else
            {
                var lastBounds = m_realizedElementBounds[m_realizedElementBounds.Count - 1];
                int lastRealizedDataIndex = m_firstRealizedDataIndex + m_realizedElementBounds.Count;
                int numItemsAfterLastRealizedIndex = context.ItemCount - lastRealizedDataIndex;
                extent.Height = lastBounds.Bottom + numItemsAfterLastRealizedIndex * averageHeight - extent.Y;
            }
        }

        DebugTrace("Extent " + extent + " with average height " + averageHeight);
        return extent;
    }

    private bool IsRealized(int dataIndex)
    {
        int realizationIndex = dataIndex - m_firstRealizedDataIndex;
        return realizationIndex >= 0 && realizationIndex < m_realizedElementBounds.Count;
    }

    // Index in the m_realizedElementBounds collection
    private int RealizationIndex(int dataIndex)
    {
        return dataIndex - m_firstRealizedDataIndex;
    }

    private void OnItemsAdded(int index, int count)
    {
        // Using the old indexes here (before it was updated by the collection change)
        // if the insert data index is between the first and last realized data index, we need
        // to insert items.
        int lastRealizedDataIndex = m_firstRealizedDataIndex + m_realizedElementBounds.Count - 1;
        int newStartingIndex = index;
        if (newStartingIndex > m_firstRealizedDataIndex &&
            newStartingIndex <= lastRealizedDataIndex)
        {
            // Inserted within the realized range
            int insertRangeStartIndex = newStartingIndex - m_firstRealizedDataIndex;
            for (int i = 0; i < count; i++)
            {
                // Insert null (sentinel) here instead of an element, that way we do not
                // end up creating a lot of elements only to be thrown out in the next layout.
                int insertRangeIndex = insertRangeStartIndex + i;
                int dataIndex = newStartingIndex + i;
                // This is to keep the contiguousness of the mapping
                m_realizedElementBounds.Insert(insertRangeIndex, new Rect());
            }
        }
        else if (index <= m_firstRealizedDataIndex)
        {
            // Items were inserted before the realized range.
            // We need to update m_firstRealizedDataIndex;
            m_firstRealizedDataIndex += count;
        }
    }

    private void OnItemsRemoved(int index, int count)
    {
        int lastRealizedDataIndex = m_firstRealizedDataIndex + m_realizedElementBounds.Count - 1;
        int startIndex = Math.Max(m_firstRealizedDataIndex, index);
        int endIndex = Math.Min(lastRealizedDataIndex, index + count - 1);
        bool removeAffectsFirstRealizedDataIndex = (index <= m_firstRealizedDataIndex);

        if (endIndex >= startIndex)
        {
            ClearRealizedRange(RealizationIndex(startIndex), endIndex - startIndex + 1);
        }

        if (removeAffectsFirstRealizedDataIndex &&
            m_firstRealizedDataIndex != -1)
        {
            m_firstRealizedDataIndex -= count;
        }
    }

    private void ClearRealizedRange(int startRealizedIndex, int count)
    {
        m_realizedElementBounds.RemoveRange(startRealizedIndex, count);
        if (startRealizedIndex == 0)
        {
            m_firstRealizedDataIndex = m_realizedElementBounds.Count == 0 ? 0 : m_firstRealizedDataIndex + count;
        }
    }

    private void ClearRealizedRange()
    {
        m_realizedElementBounds.Clear();
        m_firstRealizedDataIndex = 0;
    }

    private Rect GetCachedBoundsForDataIndex(int dataIndex)
    {
        return m_realizedElementBounds[RealizationIndex(dataIndex)];
    }

    private void SetCachedBoundsForDataIndex(int dataIndex, Rect bounds)
    {
        m_realizedElementBounds[RealizationIndex(dataIndex)] = bounds;
    }

    private Rect GetCachedBoundsForRealizationIndex(int relativeIndex)
    {
        return m_realizedElementBounds[relativeIndex];
    }

    void DebugTrace(string message, params object[] args)
    {
        Debug.WriteLine(message, args);
    }
}
```

## <a name="related-articles"></a>関連記事

- [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)
- [ScrollViewer](/uwp/api/windows.ui.xaml.controls.scrollviewer)
