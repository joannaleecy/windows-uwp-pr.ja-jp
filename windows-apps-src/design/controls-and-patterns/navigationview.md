---
Description: NavigationView は、アプリの最上位レベルのナビゲーション パターンを実装するアダプティブ コントロールです。
title: ナビゲーション ビュー
template: detail.hbs
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: yulikl
design-contact: kimsea
dev-contact: ''
doc-status: Published
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 4ba3a45701d82ad0b43591469bf390190ec18db0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642227"
---
# <a name="navigation-view"></a>ナビゲーション ビュー

NavigationView コントロールは、アプリの最上位レベルのナビゲーションを提供します。 両方をサポートし、さまざまな画面サイズに適応_上部_と_左_ナビゲーション スタイル。

![上部のナビゲーション](images/nav-view-header.png)<br/>
_ナビゲーション ビューには、上部と左側のナビゲーション ウィンドウまたはメニューの両方がサポートしています_

> **プラットフォーム Api**:[Windows.UI.Xaml.Controls.NavigationView クラス](/uwp/api/windows.ui.xaml.controls.navigationview)
>
> **Windows UI ライブラリ Api**:[Microsoft.UI.Xaml.Controls.NavigationView クラス](/uwp/api/microsoft.ui.xaml.controls.navigationview)
>
> NavigationView の一部の機能など_上部_ナビゲーション、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

NavigationView は適しているアダプティブ ナビゲーション コントロールを示します。

- アプリ全体で一貫性のあるナビゲーション エクスペリエンスを提供します。
- 小さい windows の実際の画面を保持します。
- 多くのナビゲーション カテゴリへのアクセスを整理します。

その他のナビゲーション パターンを参照してください。[ナビゲーション設計の基本](../basics/navigation-basics.md)します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/XAML-controls-gallery-app-icon.png" alt="XAML controls gallery" width="168"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/NavigationView">アプリを開き、NavigationView の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="display-modes"></a>表示モード

> PaneDisplayMode プロパティには、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。

PaneDisplayMode プロパティを使用して、さまざまなナビゲーション スタイルを構成したり、NavigationView のモードを表示できます。

:::row:::
    :::column:::
    ### <a name="top"></a>Top
    ウィンドウは、コンテンツ上に配置されます。</br>
    `PaneDisplayMode="Top"`
    :::column-end:::
    :::column span="2":::
    ![上部のナビゲーションの例](images/displaymode-top.png)
    :::column-end:::
:::row-end:::

お勧め_上部_ナビゲーションとき。

- 5 または同様に重要な少なくの最上位レベルのナビゲーション カテゴリとカテゴリをドロップダウン リストのオーバーフロー メニューに最終的には重要度の低いと見なされます追加最上位レベルのナビゲーションであります。
- 画面上のすべてのナビゲーション オプションを表示する必要があります。
- アプリのコンテンツのスペースを追加するとします。
- アイコンは、アプリのナビゲーションのカテゴリを明確に記述ことはできません。

:::row:::
    :::column:::
    ### <a name="left"></a>Left
    ウィンドウが展開され、コンテンツの左に配置します。</br>
    `PaneDisplayMode="Left"`
    :::column-end:::
    :::column span="2":::
    ![展開の左側のナビゲーション ウィンドウの例](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

お勧め_左_ナビゲーションとき。

- 5 ~ 10 同じくらい重要な最上位レベルのナビゲーションのカテゴリがあります。
- ナビゲーション項目の他のアプリのコンテンツの領域が少なく、非常に目立つをします。

:::row:::
    :::column:::
    ### <a name="leftcompact"></a>LeftCompact
    ウィンドウには、開かれ、コンテンツの左側に配置されるまでにアイコンのみが表示されます。</br>
    `PaneDisplayMode="LeftCompact"`
    :::column-end:::
    :::column span="2":::
    ![Compact の左側のナビゲーション ウィンドウの例](images/displaymode-leftcompact.png)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
    ### <a name="leftminimal"></a>LeftMinimal
    ウィンドウが開かれるまで、メニュー ボタンのみが表示されます。 開かれると、コンテンツの左側に配置されます。</br>
    `PaneDisplayMode="LeftMinimal"`
    :::column-end:::
    :::column span="2":::
    ![最小限の左側のナビゲーション ウィンドウの例](images/displaymode-leftminimal.png)
    :::column-end:::
:::row-end:::

### <a name="auto"></a>Auto

既定では、PaneDisplayMode が自動に設定されます。自動モードでは、ナビゲーション ビューは LeftMinimal、ウィンドウの幅が狭い LeftCompact、するときの間で適応し、左のウィンドウが広くなるよう。 詳細については、次を参照してください。、[アダプティブ動作](#adaptive-behavior)セクション。

![左側のナビゲーション アダプティブの既定の動作](images/displaymode-auto.png)<br/>
_ナビゲーション ビューの既定のアダプティブ動作_

## <a name="anatomy"></a>構造

これらのイメージの表示ウィンドウで、ヘッダー、および構成されている場合、コントロールのコンテンツ領域のレイアウト_上部_または_左_ナビゲーション。

![上部のナビゲーション ビューのレイアウト](images/topnav-anatomy.png)<br/>
_上部のナビゲーション レイアウト_

![左側のナビゲーション ビューのレイアウト](images/leftnav-anatomy.png)<br/>
_左側のナビゲーション レイアウト_

### <a name="pane"></a>ウィンドウ

PaneDisplayMode プロパティを使用すると、コンテンツの上またはコンテンツの左側のウィンドウを移動します。

NavigationView のペインに含めることができます。

- [NavigationViewItem](/uwp/api/windows.ui.xaml.controls.navigationviewitem)オブジェクト。 特定のページに移動するためのナビゲーション項目。
- [NavigationViewItemSeparator](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)オブジェクト。 ナビゲーション項目をグループ化するための区切り記号。 設定、[不透明度](/uwp/api/windows.ui.xaml.uielement.opacity)プロパティを空白として区切り記号を表示するために 0 にします。
- [NavigationViewItemHeader](/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)オブジェクト。 アイテムのグループのラベル付けのヘッダー。
- 省略可能な[AutoSuggestBox](auto-suggest-box.md)アプリ レベルの検索を許可するコントロール。 コントロールを割り当てる、 [NavigationView.AutoSuggestBox](/uwp/api/windows.ui.xaml.controls.navigationview.autosuggestbox)プロパティ。
- [アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション)。 設定項目を非表示、 [IsSettingsVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを**false**します。

左側のウィンドウも含まれています。

- 開き、終了、ウィンドウを切り替えるメニュー ボタン。 [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。

ナビゲーション ビューには、ウィンドウの左上隅に配置される戻るボタンがあります。 ただし、自動的に下位のナビゲーションを処理し、戻るスタックにコンテンツを追加します。 下位ナビゲーションを有効にするを参照してください、[下位ナビゲーション](#backwards-navigation)セクション。

上および左のウィンドウの位置に対して詳細な ペインの構造を次に示します。

#### <a name="top-navigation-pane"></a>上部のナビゲーション ウィンドウ

![ナビゲーション ビューの上部ペインの構造](images/navview-pane-anatomy-horizontal.png)

1. ヘッダー
1. ナビゲーション項目
1. 区切り記号
1. AutoSuggestBox (省略可能)
1. (省略可能) の設定 ボタン

#### <a name="left-navigation-pane"></a>左側のナビゲーション ウィンドウ

![ナビゲーション ビューの左ペインの構造](images/navview-pane-anatomy-vertical.png)

1. メニュー ボタン
1. ナビゲーション項目
1. 区切り記号
1. ヘッダー
1. AutoSuggestBox (省略可能)
1. (省略可能) の設定 ボタン

#### <a name="pane-footer"></a>ウィンドウのフッター

配置できる自由形式ペインのフッターにコンテンツに追加することによって、 [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter)プロパティ。

:::row:::
    :::column:::
    ![ウィンドウ フッター top nav](images/navview-freeform-footer-top.png)<br>
     _上部ペインのフッター_<br>
    :::column-end:::
    :::column:::
    ![ウィンドウ フッターの左側のナビゲーション](images/navview-freeform-footer-left.png)<br>
    _左側のウィンドウのフッター_<br>
    :::column-end:::
:::row-end:::

#### <a name="pane-title-and-header"></a>ウィンドウのタイトルとヘッダー

ウィンドウのヘッダー領域のテキスト コンテンツを配置するには設定して、 [PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle)プロパティ。 文字列を受け取り、メニュー ボタンの横にあるテキストが表示されます。

イメージやロゴなどの非テキスト コンテンツを追加することができますに配置する任意の要素のウィンドウのヘッダーに追加することによって、 [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティ。

PaneTitle と PaneHeader の両方は設定されている場合、メニュー ボタン、メニュー ボタンに最も近い PaneTitle の横にあるコンテンツが水平方向に積み上げ横します。

:::row:::
    :::column:::
    ![ウィンドウのヘッダー top nav](images/navview-freeform-header-top.png)<br>
     _上部のウィンドウのヘッダー_<br>
    :::column-end:::
    :::column:::
    ![ウィンドウのヘッダーの左側のナビゲーション](images/navview-freeform-header-left.png)<br>
    _左側のウィンドウのヘッダー_<br>
    :::column-end:::
:::row-end:::

#### <a name="pane-content"></a>ウィンドウのコンテンツ

配置できます自由形式ペインでコンテンツに追加することによって、 [PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティ。

:::row:::
    :::column:::
    ![カスタム ウィンドウ コンテンツ top nav](images/navview-freeform-pane-top.png)<br>
     _上部のウィンドウのカスタム コンテンツ_<br>
    :::column-end:::
    :::column:::
    ![左のナビゲーション ウィンドウのカスタム コンテンツ](images/navview-freeform-pane-left.png)<br>
    _左側のウィンドウのカスタム コンテンツ_<br>
    :::column-end:::
:::row-end:::

### <a name="header"></a>Header

ページ タイトルを追加するには設定して、[ヘッダー](/uwp/api/windows.ui.xaml.controls.navigationview.header)プロパティ。

![ナビゲーション ビューのヘッダー領域の例](images/nav-header.png)<br/>
_ナビゲーション ビューのヘッダー_

ヘッダー領域は、ナビゲーション ボタンで、左側のウィンドウの位置に垂直方向に揃えて配置され、上部のウィンドウの位置にウィンドウの下にあります。 52 の固定の高さがピクセルです。 これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。 ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。

ヘッダーでは、NavigationView は最小限の表示モードで、いつでも表示されます。 ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。 ヘッダーを非表示にするには設定、 [AlwaysShowHeader](/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader)プロパティを**false**します。

### <a name="content"></a>コンテンツ

![ナビゲーション ビューのコンテンツ領域の例](images/nav-content.png)<br/>
_ナビゲーション ビューのコンテンツ_

コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。

12 px の余白、コンテンツ エリアをお勧めときに、NavigationView は**最小限**モードと 24px 余白のそれ以外の場合。

## <a name="adaptive-behavior"></a>アダプティブ動作

既定では、ナビゲーション ビューは自動的に使用可能な画面領域の量に基づくの表示モードを変更します。 [CompactModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.compactmodethresholdwidth)と[ExpandedModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.expandedmodethresholdwidth)プロパティが表示モードを変更するブレークポイントを指定します。 状況に応じたディスプレイのモードの動作をカスタマイズするこれらの値を変更することができます。

### <a name="default"></a>Default

既定値に PaneDisplayMode を設定すると**自動**、アダプティブの動作では説明します。

- 大規模なウィンドウの幅で展開されている左側のウィンドウ (1008px 以上)。
- A アイコン専用のままにした中規模のウィンドウの幅でのナビゲーション ウィンドウ (LeftCompact) (641px 1007px に)。
- メニュー ボタンしか (LeftMinimal) 小さいウィンドウの幅で (640 ピクセル以下)。

アダプティブの動作のウィンドウ サイズの詳細については、次を参照してください。[画面サイズやブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)します。

![左側のナビゲーション アダプティブの既定の動作](images/displaymode-auto.png)<br/>
_ナビゲーション ビューの既定のアダプティブ動作_

### <a name="minimal"></a>最小

2 つ目の一般的なアダプティブ パターンでは、大規模なウィンドウの幅、および両方の中規模の大小のウィンドウ幅でのメニュー ボタンのみで展開の左側のウィンドウを使用します。

この場合にお勧めします。

- 小さいウィンドウの幅でのアプリのコンテンツのスペースを追加するとします。
- ナビゲーションのカテゴリは、アイコンで明確に表すことができません。

![左側のナビゲーション最小限アダプティブの動作](images/adaptive-behavior-minimal.png)<br/>
_ナビゲーション ビューの「最小」アダプティブ動作_

この動作を構成するには、CompactModeThresholdWidth を折りたたむには、ウィンドウ幅に設定します。 ここでは、640 に 1007 の既定値から変更されます。 値が競合しないことを確認する ExpandedModeThresholdWidth を設定することも必要があります。

```xaml
<NavigationView CompactModeThresholdWidth="1007" ExpandedModeThresholdWidth="1007"/>
```

### <a name="compact"></a>コンパクト

3 番目の一般的なアダプティブ パターンでは、大規模なウィンドウの幅、および、LeftCompact、アイコンのみ、両方の中規模の大小のウィンドウ幅でのナビゲーション ウィンドウで展開されている左側のウィンドウを使用します。

この場合にお勧めします。

- 常に表示される画面上のすべてのナビゲーション オプションは重要です。
- ナビゲーションのカテゴリは、アイコンで明確に表現できます。

![左側のナビゲーションがアダプティブの動作を最適化します。](images/adaptive-behavior-compact.png)<br/>
_ナビゲーション ビュー"compact"のアダプティブ動作_

この動作を構成するには、CompactModeThresholdWidth を 0 に設定します。

```xaml
<NavigationView CompactModeThresholdWidth="0"/>
```

### <a name="no-adaptive-behavior"></a>アダプティブ動作はありません。

自動アダプティブの動作を無効にするには、自動以外の値に PaneDisplayMode を設定します。ここでは、設定されているウィンドウの幅に関係なく、LeftMinimal にメニュー ボタンのみが示すようにします。

![左側のナビゲーション アダプティブ動作はありません。](images/adaptive-behavior-none.png)<br/>
_ナビゲーション ビュー PaneDisplayMode LeftMinimal に設定_

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

既に説明したように、_表示モード_ セクションで、常に展開されている、常にコンパクトまたは常に最低限の上部を常にウィンドウを設定することができます。 管理することも、表示モード自分でアプリ コード。 この例は、次のセクションに表示されます。

### <a name="top-to-left-navigation"></a>上左のナビゲーションから

アプリの上部のナビゲーションを使用するとナビゲーション項目をウィンドウの幅が減少としてをオーバーフロー メニューに折りたたみます。 アプリのウィンドウが狭いときにすべての項目をオーバーフロー メニューに折りたたむことのではなく、LeftMinimal のナビゲーションに上から PaneDisplayMode を切り替える優れたユーザー エクスペリエンスを提供できます。

大きなウィンドウ サイズと小さな左側のナビゲーションの上部のナビゲーションを使用することをお勧めします。 ときにウィンドウのサイズを設定します。

- 等しく重要度を付けるの左側のナビゲーションを折りたたむ場合、このセット内の 1 つのカテゴリは、画面に収まらない、ように同時に、表示される均等に重要なナビゲーションを最上位カテゴリのセットがあります。
- 小さいウィンドウのサイズにできる限りはるかコンテンツ領域として保持します。

この例は、使用する方法を示します、 [VisualStateManager](/uwp/api/Windows.UI.Xaml.VisualStateManager)と[AdaptiveTrigger.MinWindowWidth](/uwp/api/windows.ui.xaml.adaptivetrigger.minwindowwidth)上部と LeftMinimal ナビゲーション間を切り替えるプロパティ。

![上または左アダプティブ動作 1 の例](images/navigation-top-to-left.png)

```xaml
<Grid >
    <NavigationView x:Name="NavigationViewControl" >
        <NavigationView.MenuItems>
            <NavigationViewItem Content="A" x:Name="A" />
            <NavigationViewItem Content="B" x:Name="B" />
            <NavigationViewItem Content="C" x:Name="C" />
        </NavigationView.MenuItems>
    </NavigationView>

    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState>
                <VisualState.StateTriggers>
                    <AdaptiveTrigger
                        MinWindowWidth="{x:Bind NavigationViewControl.CompactModeThresholdWidth}" />
                </VisualState.StateTriggers>

                <VisualState.Setters>
                    <Setter Target="NavigationViewControl.PaneDisplayMode" Value="Top"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Grid>

```

> [!TIP]
> AdaptiveTrigger.MinWindowWidth を使用する場合は、ウィンドウが指定した最小幅より広い表示状態がトリガーされます。 つまり、既定の XAML 定義の幅の狭いウィンドウ、VisualState ウィンドウが広くなるときに適用される変更を定義します。 既定の PaneDisplayMode ナビゲーション ビューが自動的には、そのため場合ウィンドウの幅は CompactModeThresholdWidth、小さい LeftMinimal ナビゲーションが使用されます。 ウィンドウが大きくし、VisualState には、既定値よりも優先されます上部のナビゲーションを使用します。

## <a name="navigation"></a>ナビゲーション

ナビゲーション ビューでは、自動的にすべてのナビゲーションのタスクを実行しません。 ナビゲーション ビューが選択されている項目を表示し、発生させます、ユーザーがナビゲーション項目をタップする、 [ItemInvoked](/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked)イベント。 タップ結果が、新しい項目が選択されている場合、 [SelectionChanged](/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged)イベントも発生します。

要求されたナビゲーションに関連するタスクを実行するのいずれかのイベントを処理することができます。 アプリの目的の動作に依存する 1 つを処理する必要がありますとします。 通常、要求されたページに移動し、これらのイベントへの応答でナビゲーション ビューのヘッダーを更新します。

**ItemInvoked**が既に選択されている場合でも、ユーザーが、ナビゲーション項目をタップするたびに発生です。 (項目呼び出すこともできますと同等のマウス、キーボード、またはその他の入力を使用して操作します。 詳細については、次を参照してください[入力との相互作用](../input/index.md)。)。ItemInvoked ハンドラーで移動する場合は、既定では、ページが再読み込みされますと重複するエントリ、ナビゲーション スタックに追加されます。 項目が呼び出されたときに、移動する場合は、ページの再読み込みを禁止またはページが再読み込みされるときに、重複するエントリがナビゲーション バック スタックで作成しないことを確認する必要があります。 (コード例を参照してください)。

**SelectionChanged**されていない、現在選択されている項目を呼び出すユーザーまたは選択した項目をプログラムで変更することで、発生することができます。 ユーザーに項目が呼び出されるため、選択の変更が発生した場合、ItemInvoked イベントに最初に発生します。 選択の変更がプログラムの場合は、ItemInvoked は発生しません。

### <a name="backwards-navigation"></a>逆方向のナビゲーション

NavigationView は組み込みの戻るボタン。ただし、"進む"ナビゲーションと同様には下位ナビゲーションを自動的に実行します。 ユーザーが、[戻る] ボタンをタップすると、 [BackRequested](/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested)イベントが発生します。 旧バージョンとナビゲーションを実行するには、このイベントを処理します。 詳細情報とコード例については、次を参照してください。[ナビゲーション履歴内を後方に向かってとナビゲーション](../basics/navigation-history-and-backwards-navigation.md)します。

最小限またはコンパクト モードでナビゲーション ビュー ウィンドウがフライアウトとして開きます。 ここでは、[戻る] ボタンをクリックするとはウィンドウを閉じるし、発生させる、 **PaneClosing**イベント代わりにします。

非表示にするか、これらのプロパティを設定して、[戻る] ボタンを無効にします。

- [IsBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible): を表示し、[戻る] ボタンを非表示に使用します。 このプロパティの値には、 [NavigationViewBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationviewbackbuttonvisible)列挙体に設定されていると**自動**既定では。 ボタンが折りたたまれているときに領域なし用に予約されてレイアウトにします。
- [IsBackEnabled](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled): を使用して有効にする、または [戻る] ボタンを無効にします。 このプロパティをデータ バインドをできます、 [CanGoBack](/uwp/api/windows.ui.xaml.controls.frame.cangoback)ナビゲーション フレームのプロパティ。 **BackRequested**場合は発生しません**IsBackEnabled**は**false**します。

:::row:::
    :::column:::
        ![Navigation view back button in the left navigation pane](images/leftnav-back.png)<br/>
        _The back button in the left navigation pane_
    :::column-end:::
    :::column:::
        ![Navigation view back button in the top navigation pane](images/topnav-back.png)<br/>
        _The back button in the top navigation pane_
    :::column-end:::
:::row-end:::

## <a name="code-example"></a>コードの例

この例では、大きなウィンドウ サイズで、上部のナビゲーション ウィンドウとサイズの小さいウィンドウの左側のナビゲーション ウィンドウの両方で NavigationView を使用する方法を示します。 削除することで左ナビゲーションに対応ができる、_上部_VisualStateManager でナビゲーション設定します。

例では、多くの一般的なシナリオに対応するナビゲーション データを設定することをお勧めの方法を示します。 下位 NavigationView の戻るボタンとキーボード ナビゲーションを使用したナビゲーションを実装する方法も示します。

このコードでは、アプリがページに移動する次の名前が含まれていると想定します。_ホームページ_、 _AppsPage_、 _GamesPage_、 _MusicPage_、 _MyContentPage_、および_SettingsPage_. これらのページのコードは表示されません。

> [!IMPORTANT]
> アプリのページに関する情報が格納されている、 [ValueTuple](https://docs.microsoft.com/dotnet/api/system.valuetuple)します。 この構造体では、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要がありますが必要です。 以前のバージョンの Windows 10 を対象に NavigationView の WinUI バージョンを使用する場合は、使用、 [System.ValueTuple NuGet パッケージ](https://www.nuget.org/packages/System.ValueTuple/)代わりにします。

> [!IMPORTANT]
> このコードは、使用する方法を示します、 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)NavigationView のバージョン。 NavigationView のプラットフォームのバージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。 プラットフォームのバージョンを使用するすべての参照を削除`muxc:`します。

```xaml
<!-- xmlns:muxc="using:Microsoft.UI.Xaml.Controls" -->
<Grid>
    <muxc:NavigationView x:Name="NavView"
                         Loaded="NavView_Loaded"
                         ItemInvoked="NavView_ItemInvoked"
                         BackRequested="NavView_BackRequested">
        <muxc:NavigationView.MenuItems>
            <muxc:NavigationViewItem Tag="home" Icon="Home" Content="Home"/>
            <muxc:NavigationViewItemSeparator/>
            <muxc:NavigationViewItemHeader x:Name="MainPagesHeader"
                                           Content="Main pages"/>
            <muxc:NavigationViewItem Tag="apps" Content="Apps">
                <muxc:NavigationViewItem.Icon>
                    <FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xEB3C;"/>
                </muxc:NavigationViewItem.Icon>
            </muxc:NavigationViewItem>
            <muxc:NavigationViewItem Tag="games" Content="Games">
                <muxc:NavigationViewItem.Icon>
                    <FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xE7FC;"/>
                </muxc:NavigationViewItem.Icon>
            </muxc:NavigationViewItem>
            <muxc:NavigationViewItem Tag="music" Icon="Audio" Content="Music"/>
        </muxc:NavigationView.MenuItems>

        <muxc:NavigationView.AutoSuggestBox>
            <!-- See AutoSuggestBox documentation for
                 more info about how to implement search. -->
            <AutoSuggestBox x:Name="NavViewSearchBox" QueryIcon="Find"/>
        </muxc:NavigationView.AutoSuggestBox>

        <ScrollViewer>
            <Frame x:Name="ContentFrame" Padding="12,0,12,24" IsTabStop="True"
                   NavigationFailed="ContentFrame_NavigationFailed"/>
        </ScrollViewer>
    </muxc:NavigationView>

    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState>
                <VisualState.StateTriggers>
                    <AdaptiveTrigger
                        MinWindowWidth="{x:Bind NavView.CompactModeThresholdWidth}"/>
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <!-- Remove the next 3 lines for left-only navigation. -->
                    <Setter Target="NavView.PaneDisplayMode" Value="Top"/>
                    <Setter Target="NavViewSearchBox.Width" Value="200"/>
                    <Setter Target="MainPagesHeader.Visibility" Value="Collapsed"/>
                    <!-- Leave the next line for left-only navigation. -->
                    <Setter Target="ContentFrame.Padding" Value="24,0,24,24"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Grid>
```

> [!IMPORTANT]
> このコードは、使用する方法を示します、 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)NavigationView のバージョン。 NavigationView のプラットフォームのバージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。 プラットフォームのバージョンを使用するすべての参照を削除`muxc`します。

```csharp
// Add "using" for WinUI controls.
// using muxc = Microsoft.UI.Xaml.Controls;

private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
{
    throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
}

// List of ValueTuple holding the Navigation Tag and the relative Navigation Page
private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
{
    ("home", typeof(HomePage)),
    ("apps", typeof(AppsPage)),
    ("games", typeof(GamesPage)),
    ("music", typeof(MusicPage)),
};

private void NavView_Loaded(object sender, RoutedEventArgs e)
{
    // You can also add items in code.
    NavView.MenuItems.Add(new muxc.NavigationViewItemSeparator());
    NavView.MenuItems.Add(new muxc.NavigationViewItem
    {
        Content = "My content",
        Icon = new SymbolIcon((Symbol)0xF1AD),
        Tag = "content"
    });
    _pages.Add(("content", typeof(MyContentPage)));

    // Add handler for ContentFrame navigation.
    ContentFrame.Navigated += On_Navigated;

    // NavView doesn't load any page by default, so load home page.
    NavView.SelectedItem = NavView.MenuItems[0];
    // If navigation occurs on SelectionChanged, this isn't needed.
    // Because we use ItemInvoked to navigate, we need to call Navigate
    // here to load the home page.
    NavView_Navigate("home", new EntranceNavigationTransitionInfo());

    // Add keyboard accelerators for backwards navigation.
    var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
    goBack.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(goBack);

    // ALT routes here
    var altLeft = new KeyboardAccelerator
    {
        Key = VirtualKey.Left,
        Modifiers = VirtualKeyModifiers.Menu
    };
    altLeft.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(altLeft);
}

private void NavView_ItemInvoked(muxc.NavigationView sender,
                                 muxc.NavigationViewItemInvokedEventArgs args)
{
    if (args.IsSettingsInvoked == true)
    {
        NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
    }
    else if (args.InvokedItemContainer != null)
    {
        var navItemTag = args.InvokedItemContainer.Tag.ToString();
        NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
    }
}

<!-- NavView_SelectionChanged is not used in this example, but is shown for completeness.
     You will typically handle either ItemInvoked or SelectionChanged to perform navigation,
     but not both. -->
private void NavView_SelectionChanged(muxc.NavigationView sender,
                                      muxc.NavigationViewSelectionChangedEventArgs args)
{
    if (args.IsSettingsSelected == true)
    {
        NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
    }
    else if (args.SelectedItemContainer != null)
    {
        var navItemTag = args.SelectedItemContainer.Tag.ToString();
        NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
    }
}

private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
{
    Type _page = null;
    if (navItemTag == "settings")
    {
        _page = typeof(SettingsPage);
    }
    else
    {
        var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
        _page = item.Page;
    }
    // Get the page type before navigation so you can prevent duplicate
    // entries in the backstack.
    var preNavPageType = ContentFrame.CurrentSourcePageType;

    // Only navigate if the selected page isn't currently loaded.
    if (!(_page is null) && !Type.Equals(preNavPageType, _page))
    {
        ContentFrame.Navigate(_page, null, transitionInfo);
    }
}

private void NavView_BackRequested(muxc.NavigationView sender,
                                   muxc.NavigationViewBackRequestedEventArgs args)
{
    On_BackRequested();
}

private void BackInvoked(KeyboardAccelerator sender,
                         KeyboardAcceleratorInvokedEventArgs args)
{
    On_BackRequested();
    args.Handled = true;
}

private bool On_BackRequested()
{
    if (!ContentFrame.CanGoBack)
        return false;

    // Don't go back if the nav pane is overlayed.
    if (NavView.IsPaneOpen &&
        (NavView.DisplayMode == muxc.NavigationViewDisplayMode.Compact ||
         NavView.DisplayMode == muxc.NavigationViewDisplayMode.Minimal))
        return false;

    ContentFrame.GoBack();
    return true;
}

private void On_Navigated(object sender, NavigationEventArgs e)
{
    NavView.IsBackEnabled = ContentFrame.CanGoBack;

    if (ContentFrame.SourcePageType == typeof(SettingsPage))
    {
        // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
        NavView.SelectedItem = (muxc.NavigationViewItem)NavView.SettingsItem;
        NavView.Header = "Settings";
    }
    else if (ContentFrame.SourcePageType != null)
    {
        var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

        NavView.SelectedItem = NavView.MenuItems
            .OfType<muxc.NavigationViewItem>()
            .First(n => n.Tag.Equals(item.Tag));

        NavView.Header =
            ((muxc.NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
    }
}
```

次に示します、 [C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/index)のバージョン、 **NavView_ItemInvoked**からハンドラー、C#上記のコード例です。 手法 C +/cli WinRT ハンドラーでは、する必要があります最初に格納する (のタグで、 [ **NavigationViewItem**](/uwp/api/windows.ui.xaml.controls.navigationviewitem)) 移動するページの完全な型名。 ハンドラーで、その値をボックス化解除になると、 [ **::interop::typename** ](/uwp/api/windows.ui.xaml.interop.typename)オブジェクト、および変換先のページに移動するに使用します。 という名前のマッピングの変数の必要はありません`_pages`に表示される、C#の例の場合とは、タグの中の値は有効な型のことを確認する単体テストを作成することでしょう。 参照してください[c++ IInspectable をボックス化とボックス化解除のスカラー値/cli WinRT](/windows/uwp/cpp-and-winrt-apis/boxing)します。

```cppwinrt
void MainPage::NavView_ItemInvoked(Windows::Foundation::IInspectable const & /* sender */, Windows::UI::Xaml::Controls::NavigationViewItemInvokedEventArgs const & args)
{
    if (args.IsSettingsInvoked())
    {
        // Navigate to Settings.
    }
    else if (args.InvokedItemContainer())
    {
        Windows::UI::Xaml::Interop::TypeName pageTypeName;
        pageTypeName.Name = unbox_value<hstring>(args.InvokedItemContainer().Tag());
        pageTypeName.Kind = Windows::UI::Xaml::Interop::TypeKind::Primitive;
        ContentFrame().Navigate(pageTypeName, nullptr);
    }
}
```

## <a name="navigation-view-customization"></a>ナビゲーション ビューのカスタマイズ

### <a name="pane-backgrounds"></a>ウィンドウの背景

既定では、NavigationView のウィンドウは、表示モードによって異なる背景を使用します。

- ペインは、solid グレー色 (左モード) のコンテンツと並行して、左側に展開するとします。
- ウィンドウでは、(Top、最小、または Compact モード) でコンテンツの上にオーバーレイとして開いているときにアプリ内のアクリルを使用します。

ウィンドウの背景を変更するには、各モードで背景の描画に使用される XAML テーマ リソースをオーバーライドできます。 (この手法は使用 PaneBackground プロパティを 1 つではなくさまざまな表示モードのさまざまな背景をサポートするために)。

テーマ リソースが各表示モードで使用されるかを示します。

| 表示モード | テーマ リソース |
| ------------ | -------------- |
| Left | NavigationViewExpandedPaneBackground |
| LeftCompact<br/>LeftMinimal | NavigationViewDefaultPaneBackground |
| Top | NavigationViewTopPaneBackground |

この例では、App.xaml でテーマのリソースを上書きする方法を示します。 テーマのリソースを上書きするときにする必要があります常に少なくとも、"Default"、「ハイコントラスト」のリソース ディクショナリとディクショナリ「淡色」または「濃色」のリソースに応じて提供します。 詳細については、次を参照してください。 [ResourceDictionary.ThemeDictionaries](/uwp/api/windows.ui.xaml.resourcedictionary.themedictionaries)します。

> [!IMPORTANT]
> このコードは、使用する方法を示します、 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)AcrylicBrush のバージョン。 AcrylicBrush のプラットフォームのバージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは 16299 以上の SDK である必要があります。 プラットフォームのバージョンを使用するすべての参照を削除`muxm:`します。

```xaml
<Application
    <!-- ... -->
    xmlns:muxm="using:Microsoft.UI.Xaml.Media">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <XamlControlsResources xmlns="using:Microsoft.UI.Xaml.Controls"/>
                <ResourceDictionary>
                    <ResourceDictionary.ThemeDictionaries>
                        <ResourceDictionary x:Key="Default">
                            <!-- The "Default" theme dictionary is used unless a specific
                                 light, dark, or high contrast dictionary is provided. These
                                 resources should be tested with both the light and dark themes,
                                 and specific light or dark resources provided as needed. -->
                            <muxm:AcrylicBrush x:Key="NavigationViewDefaultPaneBackground"
                                   BackgroundSource="Backdrop"
                                   TintColor="LightSlateGray"
                                   TintOpacity=".6"/>
                            <muxm:AcrylicBrush x:Key="NavigationViewTopPaneBackground"
                                   BackgroundSource="Backdrop"
                                   TintColor="{ThemeResource SystemAccentColor}"
                                   TintOpacity=".6"/>
                            <LinearGradientBrush x:Key="NavigationViewExpandedPaneBackground"
                                     StartPoint="0.5,0" EndPoint="0.5,1">
                                <GradientStop Color="LightSlateGray" Offset="0.0" />
                                <GradientStop Color="White" Offset="1.0" />
                            </LinearGradientBrush>
                        </ResourceDictionary>
                        <ResourceDictionary x:Key="HighContrast">
                            <!-- Always include a "HighContrast" dictionary when you override
                                 theme resources. This empty dictionary ensures that the 
                                 default high contrast resources are used when the user
                                 turns on high contrast mode. -->
                        </ResourceDictionary>
                    </ResourceDictionary.ThemeDictionaries>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

## <a name="related-topics"></a>関連トピック

- [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [マスター/詳細](master-details.md)
- [ナビゲーションの基本](../basics/navigation-basics.md)
- [Fluent デザイン for UWP の概要](../fluent-design-system/index.md)
