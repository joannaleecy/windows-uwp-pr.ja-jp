---
author: jwmsft
Description: NavigationView is an adaptive control that implements top-level navigation patterns for your app.
title: ナビゲーション ビュー
template: detail.hbs
ms.author: jimwalk
ms.date: 10/02/2018
ms.topic: article
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: ''
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 8503c8cde942129c4e7ad6994afb6cd9b29f19a1
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5871359"
---
# <a name="navigation-view"></a>ナビゲーション ビュー

NavigationView コントロールでは、アプリのトップレベルのナビゲーションを提供します。 これは、さまざまな画面サイズに合わせて変化して、_上部_と_左側_のナビゲーションのスタイルをサポートしています。

![上部のナビゲーション](images/nav-view-header.png)<br/>
_ナビゲーション ビューは、上部と左側のナビゲーション ウィンドウまたはメニューの両方をサポートしています_

> **プラットフォーム Api**: [Windows.UI.Xaml.Controls.NavigationView クラス](/uwp/api/windows.ui.xaml.controls.navigationview)
>
> **Windows UI ライブラリ Api**: [Microsoft.UI.Xaml.Controls.NavigationView クラス](/uwp/api/microsoft.ui.xaml.controls.navigationview)
>
> _上部_のナビゲーションなど、NavigationView の一部の機能に必要な Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

NavigationView に適していますが、アダプティブ ナビゲーション コントロールを示します。

- アプリ全体で一貫性のあるナビゲーション エクスペリエンスを提供します。
- 幅が狭いウィンドウには、画面領域を保持します。
- 多くのナビゲーション カテゴリへのアクセスを編成します。

その他のナビゲーション パターンは、[ナビゲーション デザインの基本](../basics/navigation-basics.md)を参照してください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/XAML-controls-gallery-app-icon.png" alt="XAML controls gallery" width="168"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/NavigationView">アプリを開き、NavigationView の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="display-modes"></a>表示モード

> PaneDisplayMode が必要な Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。

PaneDisplayMode プロパティを使用して、さまざまなナビゲーションのスタイルを構成したり、NavigationView の表示モード、できます。

:::row:::
    :::column:::
    ### <a name="top"></a>Top
    ウィンドウはコンテンツの上に配置されます。</br>
    `PaneDisplayMode="Top"`
    :::column-end:::
    :::column span="2":::
    ![上部のナビゲーションの例](images/displaymode-top.png)
    :::column-end:::
:::row-end:::

_上部_のナビゲーションをお勧めする場合。

- 5 または均等に重要ですが、以下のトップレベルのナビゲーション カテゴリと、ドロップダウン オーバーフロー メニューにたどり着きますカテゴリは、重要度の低いと見なされる追加トップレベルのナビゲーションがあります。
- 画面上のすべてのナビゲーション オプションを表示する必要があります。
- アプリ コンテンツのスペースを追加するとします。
- アイコンは、アプリのナビゲーションのカテゴリを明確に記述ことはできません。

:::row:::
    :::column:::
    ### <a name="left"></a>Left
    ウィンドウは展開され、コンテンツの左側に配置します。</br>
    `PaneDisplayMode="Left"`
    :::column-end:::
    :::column span="2":::
    ![展開された左側のナビゲーション ウィンドウの例](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

_左側_のナビゲーションをお勧めする場合。

- 5 ~ 10 均等に重要なトップレベルのナビゲーションのカテゴリがあります。
- ナビゲーションのカテゴリの他のアプリのコンテンツ領域が少なく、非常に目立つにします。

:::row:::
    :::column:::
    ### <a name="leftcompact"></a>LeftCompact
    ウィンドウを開くし、コンテンツの左側に配置されるまでアイコンのみを示します。</br>
    `PaneDisplayMode="LeftCompact"`
    :::column-end:::
    :::column span="2":::
    ![コンパクトの左側のナビゲーション ウィンドウの例](images/displaymode-leftcompact.png)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
    ### <a name="leftminimal"></a>LeftMinimal
    ウィンドウが開かれるまで、メニュー ボタンのみが表示されます。 開いているときは、コンテンツの左側に配置されます。</br>
    `PaneDisplayMode="LeftMinimal"`
    :::column-end:::
    :::column span="2":::
    ![最小限の左側のナビゲーション ウィンドウの例](images/displaymode-leftminimal.png)
    :::column-end:::
:::row-end:::

### <a name="auto"></a>自動

既定では、PaneDisplayMode が Auto に設定されます。自動モードでは、ナビゲーション ビューは LeftMinimal、ウィンドウが狭い LeftCompact、するときの間で対応し、幅の広いウィンドウを取得し、まま。 詳しくは、[アダプティブ動作](#adaptive-behavior)を参照してください。

![左側のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)<br/>
_ナビゲーション ビューの既定のアダプティブ動作_

## <a name="anatomy"></a>構造

これらの画像は、ウィンドウ、ヘッダーおよびコンテンツ領域の_上_または_左側_のナビゲーション用に構成されている場合、コントロールのレイアウトを表示します。

![上部のナビゲーション ビューのレイアウト](images/topnav-anatomy.png)<br/>
_上部のナビゲーションのレイアウト_

![左側のナビゲーション ビューのレイアウト](images/leftnav-anatomy.png)<br/>
_左側のナビゲーションのレイアウト_

### <a name="pane"></a>ウィンドウ

PaneDisplayMode プロパティを使用すると、コンテンツの上またはコンテンツの左側のウィンドウを配置するのにことができます。

NavigationView ウィンドウを含めることができます。

- [NavigationViewItem](/uwp/api/windows.ui.xaml.controls.navigationviewitem)オブジェクト。 特定のページに移動するためのナビゲーション項目。
- [NavigationViewItemSeparator](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)オブジェクト。 ナビゲーション項目をグループ化するための区切り記号です。 [不透明度](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity)のプロパティを領域としての区切り文字をレンダリングする場合は 0 に設定します。
- [NavigationViewItemHeader](/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)オブジェクト。 項目のグループにラベルを付けるためのヘッダー。
- アプリ レベルの検索を許可するオプションの[AutoSuggestBox](auto-suggest-box.md)コントロール。 [NavigationView.AutoSuggestBox](/uwp/api/windows.ui.xaml.controls.navigationview.autosuggestbox)プロパティには、コントロールを割り当てます。
- [アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション) 設定項目を非表示に[IsSettingsVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを**false**に設定します。

左側のウィンドウが含まれています。

- 開閉ウィンドウを切り替えるメニュー ボタン。 [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。

ナビゲーション ビューには、ウィンドウの左上隅に配置されている"戻る"ボタンがあります。 ただし、自動的に処理する前に戻るナビゲーションし、バック スタックにコンテンツを追加します。 を有効にする前に戻るナビゲーションを参照してください。、[前に戻るナビゲーション](#backwards-navigation)セクションです。

上部と左側のウィンドウの位置の詳細ウィンドウの構造を次に示します。

#### <a name="top-navigation-pane"></a>上部のナビゲーション ウィンドウ

![ナビゲーション ビューの上部のウィンドウの構造](images/navview-pane-anatomy-horizontal.png)

1. ヘッダー
1. ナビゲーション項目
1. 区切り記号
1. AutoSuggestBox (省略可能)
1. (省略可能) の設定] ボタン

#### <a name="left-navigation-pane"></a>左側のナビゲーション ウィンドウ

![左ペインの構造、ナビゲーション ビュー](images/navview-pane-anatomy-vertical.png)

1. メニュー ボタン
1. ナビゲーション項目
1. 区切り記号
1. ヘッダー
1. AutoSuggestBox (省略可能)
1. (省略可能) の設定] ボタン

#### <a name="pane-footer"></a>ウィンドウのフッター

[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter)プロパティに追加することによって、ウィンドウのフッターの自由形式のコンテンツを配置できます。

:::row:::
    :::column:::
    ![ウィンドウのフッターに目的の上部のナビゲーション](images/navview-freeform-footer-top.png)<br>
     _上部のウィンドウのフッター_<br>
    :::column-end:::
    :::column:::
    ![ウィンドウのフッターに目的の左側のナビゲーション](images/navview-freeform-footer-left.png)<br>
    _左側のウィンドウのフッター_<br>
    :::column-end:::
:::row-end:::

#### <a name="pane-title-and-header"></a>ウィンドウのタイトルとヘッダー

ウィンドウのヘッダー領域でテキスト コンテンツを配置するには、 [PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle)プロパティを設定します。 文字列に移動し、メニュー ボタンの横にあるテキストを表示します。

画像やロゴなどのテキスト以外のコンテンツを追加するには、 [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティに追加することによって、ウィンドウのヘッダーで任意の要素を配置できます。

PaneTitle と PaneHeader の両方が設定されている場合、コンテンツは、メニュー ボタンに最も近い PaneTitle、メニュー ボタンの横にある水平方向に stacked します。

:::row:::
    :::column:::
    ![ウィンドウのヘッダーの上部のナビゲーション](images/navview-freeform-header-top.png)<br>
     _上部のウィンドウのヘッダー_<br>
    :::column-end:::
    :::column:::
    ![ウィンドウのヘッダーの左側のナビゲーション](images/navview-freeform-header-left.png)<br>
    _左側のウィンドウのヘッダー_<br>
    :::column-end:::
:::row-end:::

#### <a name="pane-content"></a>ウィンドウのコンテンツ

[PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティに追加することによって、ウィンドウで自由形式のコンテンツを配置できます。

:::row:::
    :::column:::
    ![ウィンドウ カスタム コンテンツ上部のナビゲーション](images/navview-freeform-pane-top.png)<br>
     _上部のウィンドウのカスタム コンテンツ_<br>
    :::column-end:::
    :::column:::
    ![ナビゲーションの左ペインのカスタム コンテンツ](images/navview-freeform-pane-left.png)<br>
    _左側のウィンドウのカスタム コンテンツ_<br>
    :::column-end:::
:::row-end:::

### <a name="header"></a>ヘッダー

ページ タイトルを追加するには、 [Header](/uwp/api/windows.ui.xaml.controls.navigationview.header)プロパティを設定します。

![ナビゲーション ビューのヘッダー領域の例](images/nav-header.png)<br/>
_ナビゲーション ビューのヘッダー_

ヘッダー領域は、左側のウィンドウの位置、ナビゲーション ボタンと垂直に揃えし、は、ウィンドウの上部のウィンドウの位置で下に配置します。 固定高さが 52 ピクセルです。 これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。 ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。

ヘッダーは最小限に抑えながら表示モードは、NavigationView はいつでも表示されます。 ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。 ヘッダーを非表示に[AlwaysShowHeader](/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader)プロパティを**false**に設定します。

### <a name="content"></a>コンテンツ

![ナビゲーション ビューのコンテンツ領域の例](images/nav-content.png)<br/>
_ナビゲーション ビューのコンテンツ_

コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。

お勧めします NavigationView が**最小**モードのときは、コンテンツ領域の余白を 12px 24px 余白それ以外の場合。

## <a name="adaptive-behavior"></a>アダプティブ動作

既定では、ナビゲーション ビューは自動的に利用可能な画面領域の量に基づいて表示モードを変更します。 [CompactModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.compactmodethresholdwidth)と[ExpandedModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.expandedmodethresholdwidth)プロパティは、表示モードが変化するブレークポイントを指定します。 アダプティブ表示モードの動作をカスタマイズするこれらの値を変更することができます。

### <a name="default"></a>既定値

PaneDisplayMode が**自動**の既定値に設定されている場合、アダプティブ動作は表示されます。

- 大きなウィンドウの幅で展開された左側のウィンドウ (1008 ピクセル以上)。
- A 左、アイコンのみ、普通サイズのウィンドウの幅では、ナビゲーション ウィンドウ (LeftCompact) (641 ピクセル ~ 1007 ピクセル)。
- のみメニュー上のボタン (LeftMinimal) 小さいウィンドウ幅 (640 ピクセル以下以内)。

アダプティブ動作のウィンドウ サイズについて詳しくは、[画面サイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を参照してください。

![左側のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)<br/>
_ナビゲーション ビューの既定のアダプティブ動作_

### <a name="minimal"></a>最小

大きなウィンドウの幅、および両方大小の普通サイズのウィンドウの幅をメニュー ボタンのみで展開された左側のウィンドウを使用する 2 つ目の一般的なアダプティブ パターンです。

このときをお勧めします。

- 小さいウィンドウの幅をアプリのコンテンツのスペースを追加するとします。
- アイコンを含む、ナビゲーションのカテゴリを明確に表示できません。

![左側のナビゲーション最小限のアダプティブ動作](images/adaptive-behavior-minimal.png)<br/>
_ナビゲーション ビューの「最小」アダプティブ動作_

この動作を構成するを折りたたむウィンドウ幅を CompactModeThresholdWidth を設定します。 ここでは、640 に 1007 の既定値から変更されます。 値が競合しないことを確認する ExpandedModeThresholdWidth を設定することもする必要があります。

```xaml
<NavigationView CompactModeThresholdWidth="1007" ExpandedModeThresholdWidth="1007"/>
```

### <a name="compact"></a>コンパクト

3 番目の一般的なアダプティブ パターンでは、大きなウィンドウの幅、そして、LeftCompact、アイコンのみ、両方大小の普通サイズのウィンドウの幅をナビゲーション ウィンドウで、展開時の左側のウィンドウを使用します。

このときをお勧めします。

- 常に画面上のすべてのナビゲーション オプションを表示するのには重要です。
- ナビゲーションのカテゴリは、アイコンを含む明確に表すことができます。

![左側のナビゲーション コンパクトなアダプティブ動作](images/adaptive-behavior-compact.png)<br/>
_ナビゲーション ビュー"compact"のアダプティブ動作_

この動作を構成するには、CompactModeThresholdWidth を 0 に設定します。

```xaml
<NavigationView CompactModeThresholdWidth="0"/>
```

### <a name="no-adaptive-behavior"></a>アダプティブ動作がないです。

自動のアダプティブ動作を無効にするには、PaneDisplayMode を自動以外の値に設定します。ここでは、設定されている、ウィンドウの幅に関係なく、LeftMinimal にメニュー ボタンのみが表示されます。

![左側のナビゲーションなしのアダプティブ動作](images/adaptive-behavior-none.png)<br/>
_PaneDisplayMode LeftMinimal に設定とナビゲーション ビュー_

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

前述_の表示モード_のセクションで、最上位、常に展開された、常にコンパクトなまたは常に最低限に常にするウィンドウを設定できます。 管理することも、表示モード自分で、アプリのコードでします。 この例は、次のセクションに表示されます。

### <a name="top-to-left-navigation"></a>左側のナビゲーションを上

上部のナビゲーションを使用して、アプリで、ナビゲーション項目は、オーバーフロー メニューにウィンドウの幅の減少として折りたたみます。 とき、アプリ ウィンドウが狭い場合は、すべての項目は、オーバーフロー メニューに折りたたむことのではなく、LeftMinimal ナビゲーション、上から PaneDisplayMode を切り替えるユーザー エクスペリエンスの向上を提供できます。

大きなウィンドウのサイズと小さなの左側のナビゲーションでの上部のナビゲーションの使用をお勧めします] ウィンドウのサイズを場合。

- その重要度が同じ権を付与する左側のナビゲーションを折りたたむこのセットの 1 つのカテゴリを画面に収まらない場合、一緒に表示される均等に重要なトップレベルのナビゲーション カテゴリのセットがあります。
- 小さいウィンドウのサイズで可能な領域がはるかにコンテンツを維持したいです。

この例では、上部と LeftMinimal ナビゲーション間を切り替える[VisualStateManager](/uwp/api/Windows.UI.Xaml.VisualStateManager)と[AdaptiveTrigger.MinWindowWidth](/uwp/api/windows.ui.xaml.adaptivetrigger.minwindowwidth)プロパティを使用する方法を示します。

![または左端のアダプティブ動作 1 の例](images/navigation-top-to-left.png)

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
> AdaptiveTrigger.MinWindowWidth を使用すると、ウィンドウが指定された最小幅よりも広い場合、表示状態がトリガーされます。 これは、既定の XAML は、幅の狭いウィンドウを定義し、ウィンドウが広いときに適用される変更を定義する、VisualState ことを意味します。 既定の PaneDisplayMode ナビゲーション ビューは、自動、したがってときに、ウィンドウの幅が CompactModeThresholdWidth、小さい LeftMinimal ナビゲーションを使用します。 ウィンドウが大きくし、既定値をオーバーライドする、VisualState 上部のナビゲーションを使用します。

## <a name="navigation"></a>ナビゲーション

ナビゲーション ビューは、任意のナビゲーションのタスクを自動的に実行しません。 ナビゲーション項目をタップ、ナビゲーション ビューは、選択された項目と[ItemInvoked](/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked)イベントを発生させます。 タップにより新しいアイテムが選択されていると場合も、 [SelectionChanged](/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged)イベントが発生します。

要求されたナビゲーションに関連するタスクを実行するいずれかのイベントを処理することができます。 2 つを処理する必要がありますはアプリに目的の動作とは異なります。 通常、要求されたページに移動し、これらのイベントへの応答でナビゲーション ビューのヘッダーを更新します。

**ItemInvoked**がまだ選択されている場合でも、いつでも、ユーザーが、ナビゲーション項目をタップ発生します。 (項目できるでも呼び出すことでは、マウス、キーボード、またはその他の入力を使用して、同等の操作します。 詳しくは、参照[入力と操作](../input/index.md))。ItemInvoked ハンドラーで移動する場合は、既定では、ページが再読み込みは、され、重複したエントリがナビゲーション スタックに追加されます。 呼び出されると、項目を移動する場合は、ページの再読み込みを禁止しますや、ページの再読み込み時、重複したエントリは、ナビゲーション バック スタックに作成しないことを確認する必要があります。 (詳しくは、コード例を参照してください)。

ユーザーではない、現在選択されている項目の呼び出しによって、またはをプログラムで選択した項目を変更することは、 **SelectionChanged**を発生させることができます。 ユーザーが項目を呼び出すために選択の変更が発生した場合、ItemInvoked イベントが最初に発生します。 選択の変更がプログラムの場合は、ItemInvoked は発生しません。

### <a name="backwards-navigation"></a>逆方向のナビゲーション

NavigationView は、組み込みの戻るボタンただしと同様に、ナビゲーションがない前に戻るナビゲーションを自動的に実行します。 ユーザーが戻るボタンをタップ、 [BackRequested](/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested)イベントが発生します。 前に戻るナビゲーションを実行するには、このイベントを処理します。 詳細情報とコード例については、次を参照してください。[ナビゲーション履歴と前に戻るナビゲーション](../basics/navigation-history-and-backwards-navigation.md)します。

最小限またはコンパクト モードでは、ナビゲーション ビューは、ウィンドウ、ポップアップとして開いて。 この例では、戻るボタンをクリックしてはウィンドウを閉じるし、代わりに**PaneClosing**イベントが発生します。

非表示にするか、これらのプロパティを設定して、戻るボタンを無効にできます。

- [IsBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible): と、戻るボタンを非表示に使用します。 このプロパティは、 [NavigationViewBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationviewbackbuttonvisible)列挙の値を受け取って、既定では**自動的**に設定されます。 ボタンが折りたたまれているとき領域ない用に予約されてレイアウトします。
- [IsBackEnabled](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled): を有効にするまたは戻るボタンを無効にします。 このプロパティには、ナビゲーションのフレームの[CanGoBack](/uwp/api/windows.ui.xaml.controls.frame.cangoback)プロパティにデータ バインドできます。 **IsBackEnabled**が**false**の場合、 **BackRequested**は発生しません。

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

この例では、大規模なウィンドウ サイズの上部のナビゲーション ウィンドウと小さなウィンドウ サイズの左側のナビゲーション ウィンドウの両方で NavigationView を使用する方法を示します。 VisualStateManager の_最上部_のナビゲーションの設定を削除して左専用のナビゲーションに合わせることができます。

多くの一般的なシナリオに対応するナビゲーション データを設定する方法がお勧めの例を示します。 前に戻るナビゲーションで NavigationView の"戻る"ボタンとキーボード ナビゲーションを実装する方法も示します。

このコードでは、アプリがページに移動する次の名前が含まれていると想定しています:_ホームページ_、 _AppsPage_、 _GamesPage_、 _MusicPage_、 _MyContentPage_、および_SettingsPage_します。 これらのページのコードは表示されません。

> [!IMPORTANT]
> アプリのページについては、 [ValueTuple](https://docs.microsoft.com/dotnet/api/system.valuetuple)に格納されます。 この構造体は、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要がありますが必要です。 NavigationView の WinUI バージョンを以前のバージョンの Windows 10 をターゲットに使用する場合は、代わりに、 [System.ValueTuple NuGet パッケージ](https://www.nuget.org/packages/System.ValueTuple/)を使用できます。

> [!IMPORTANT]
> このコードは、NavigationView の[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)のバージョンを使用する方法を示しています。 NavigationView のプラットフォームのバージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。 プラットフォームのバージョンを使用するすべての参照を削除`muxc:`します。

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
> このコードは、NavigationView の[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)のバージョンを使用する方法を示しています。 NavigationView のプラットフォームのバージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。 プラットフォームのバージョンを使用するすべての参照を削除`muxc`します。

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

## <a name="related-topics"></a>関連トピック

- [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [マスター/詳細](master-details.md)
- [ナビゲーションの基本](../basics/navigation-basics.md)
- [UWP 用 Fluent Design の概要](../fluent-design-system/index.md)