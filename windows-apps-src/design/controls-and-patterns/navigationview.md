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
ms.openlocfilehash: 9eef1616625ca30b1887e7f317c59f7a75abfeea
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6852446"
---
# <a name="navigation-view"></a>ナビゲーション ビュー

NavigationView コントロールでは、アプリのトップレベルのナビゲーションを提供します。 さまざまな画面サイズに合わせて変化して、_上部_と_左側_のナビゲーションのスタイルをサポートしています。

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
- 多くのナビゲーション カテゴリへのアクセスを構成します。

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

> PaneDisplayMode プロパティには、Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) が必要です。 またはそれ以降、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。

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
- アプリのコンテンツのスペースを追加するとします。
- アイコンは、アプリのナビゲーションのカテゴリを明確に記述ことはできません。

:::row:::
    :::column:::
    ### <a name="left"></a>Left
    ウィンドウが展開され、コンテンツの左側に配置されます。</br>
    `PaneDisplayMode="Left"`
    :::column-end:::
    :::column span="2":::
    ![展開時の左側のナビゲーション ウィンドウの例](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

_左側_のナビゲーションをお勧めする場合。

- 5 ~ 10 均等に重要なトップレベルのナビゲーションのカテゴリがあります。
- ナビゲーションのカテゴリの他のアプリのコンテンツ領域が少なく、非常に掲示する場合します。

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

既定では、PaneDisplayMode が Auto に設定されます。自動モードでは、ナビゲーション ビューは、LeftMinimal、ウィンドウが狭い LeftCompact、するときの間で対応し、幅の広いウィンドウを取得し、まま。 詳しくは、[アダプティブ動作](#adaptive-behavior)を参照してください。

![左側のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)<br/>
_ナビゲーション ビューの既定のアダプティブ動作_

## <a name="anatomy"></a>構造

これらの画像は、ウィンドウ、ヘッダー、およびコンテンツ領域の_上部_または_左側_のナビゲーション用に構成されている場合、コントロールのレイアウトを表示します。

![上部のナビゲーション ビューのレイアウト](images/topnav-anatomy.png)<br/>
_上部のナビゲーションのレイアウト_

![左側のナビゲーション ビューのレイアウト](images/leftnav-anatomy.png)<br/>
_左側のナビゲーションのレイアウト_

### <a name="pane"></a>ウィンドウ

PaneDisplayMode プロパティを使用すると、コンテンツの上またはコンテンツの左側のウィンドウを配置するのにことができます。

NavigationView ウィンドウを含めることができます。

- [NavigationViewItem](/uwp/api/windows.ui.xaml.controls.navigationviewitem)オブジェクト。 特定のページに移動するためのナビゲーション項目。
- [NavigationViewItemSeparator](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)オブジェクト。 ナビゲーション項目をグループ化するための区切り記号です。 [不透明度](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity)のプロパティを領域としての区切り記号をレンダリングする場合は 0 に設定します。
- [NavigationViewItemHeader](/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)オブジェクト。 項目のグループにラベルを付けるためのヘッダー。
- アプリ レベルの検索を許可するオプション[AutoSuggestBox](auto-suggest-box.md)コントロール。 [NavigationView.AutoSuggestBox](/uwp/api/windows.ui.xaml.controls.navigationview.autosuggestbox)プロパティには、コントロールを割り当てます。
- [アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション) 設定項目を非表示に[IsSettingsVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを**false**に設定します。

左側のウィンドウが含まれています。

- 開閉ウィンドウを切り替えるメニュー ボタン。 [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。

ナビゲーション ビューには、ウィンドウの左上隅に配置されている"戻る"ボタンがあります。 ただし、自動的に処理する前に戻るナビゲーションし、バック スタックにコンテンツを追加します。 表示を有効にする前に戻るナビゲーション、[前に戻るナビゲーション](#backwards-navigation)セクション。

上部と左側のウィンドウの位置の詳細ウィンドウの構造を次に示します。

#### <a name="top-navigation-pane"></a>上部のナビゲーション ウィンドウ

![ナビゲーション ビューの上部のウィンドウの構造](images/navview-pane-anatomy-horizontal.png)

1. ヘッダー
1. ナビゲーション項目
1. 区切り文字
1. AutoSuggestBox (省略可能)
1. 設定ボタン (省略可能)

#### <a name="left-navigation-pane"></a>左側のナビゲーション ウィンドウ

![左ペインの構造、ナビゲーション ビュー](images/navview-pane-anatomy-vertical.png)

1. メニュー ボタン
1. ナビゲーション項目
1. 区切り文字
1. ヘッダー
1. AutoSuggestBox (省略可能)
1. 設定ボタン (省略可能)

#### <a name="pane-footer"></a>ウィンドウのフッター

[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter)プロパティを追加することによって、ウィンドウのフッターの自由形式のコンテンツを配置できます。

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

画像やロゴなどのテキスト以外のコンテンツを追加するには、 [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティを追加することによって、ウィンドウのヘッダーで任意の要素を配置できます。

PaneTitle と PaneHeader の両方が設定されている場合、コンテンツは、メニュー ボタンに最も近い PaneTitle、メニュー ボタンの横にある水平方向 stacked します。

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

ウィンドウで自由形式のコンテンツを配置するには、 [PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティに追加します。

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

ヘッダー領域は、左側のウィンドウの位置でナビゲーション ボタンと垂直に揃えし、は、ウィンドウの上部のウィンドウの位置で下に配置します。 固定高さが 52 ピクセルです。 これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。 ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。

ヘッダーは最小限に抑えながら表示モードは、NavigationView はいつでも表示されます。 ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。 ヘッダーを非表示に[AlwaysShowHeader](/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader)プロパティを**false**に設定します。

### <a name="content"></a>コンテンツ

![ナビゲーション ビューのコンテンツ領域の例](images/nav-content.png)<br/>
_ナビゲーション ビューのコンテンツ_

コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。

お勧めします NavigationView が**最小**モードのときは、コンテンツ領域の余白を 12px 24px 余白そうでない場合。

## <a name="adaptive-behavior"></a>アダプティブ動作

既定では、ナビゲーション ビューは自動的に利用可能な画面領域の量に基づいて表示モードを変更します。 [CompactModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.compactmodethresholdwidth)と[ExpandedModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.expandedmodethresholdwidth)プロパティは、表示モードが変化するブレークポイントを指定します。 アダプティブ表示モードの動作をカスタマイズするこれらの値を変更することができます。

### <a name="default"></a>既定値

PaneDisplayMode が**自動**の既定値に設定されている場合、アダプティブ動作は表示されます。

- 大きなウィンドウの幅で展開された左側のウィンドウ (1008 ピクセル以上)。
- A 左、アイコンのみ普通サイズのウィンドウの幅をナビゲーション ウィンドウ (LeftCompact) (641 ピクセル ~ 1007 ピクセル)。
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

この動作を構成するを折りたたむウィンドウ幅を CompactModeThresholdWidth を設定します。 ここでは、640 を 1007 の既定値から変更されます。 値が競合しないようにする ExpandedModeThresholdWidth を設定することもする必要があります。

```xaml
<NavigationView CompactModeThresholdWidth="1007" ExpandedModeThresholdWidth="1007"/>
```

### <a name="compact"></a>コンパクト

3 番目の一般的なアダプティブ パターンでは、大きなウィンドウの幅と、LeftCompact、アイコンのみ両方大小の普通サイズのウィンドウの幅をナビゲーション ウィンドウで、展開時の左側のウィンドウを使用します。

このときをお勧めします。

- 常に画面上のすべてのナビゲーション オプションを表示するのには重要です。
- ナビゲーションのカテゴリは、アイコンを明確に表すことができます。

![左側のナビゲーション コンパクトなアダプティブ動作](images/adaptive-behavior-compact.png)<br/>
_ナビゲーション ビュー"compact"のアダプティブ動作_

この動作を構成するには、CompactModeThresholdWidth を 0 に設定します。

```xaml
<NavigationView CompactModeThresholdWidth="0"/>
```

### <a name="no-adaptive-behavior"></a>アダプティブ動作がないです。

自動のアダプティブ動作を無効にするには、自動以外の値に PaneDisplayMode を設定します。ここでは、設定されているウィンドウの幅に関係なく、LeftMinimal にメニュー ボタンのみが表示されます。

![左側のナビゲーションなしのアダプティブ動作](images/adaptive-behavior-none.png)<br/>
_PaneDisplayMode LeftMinimal に設定とナビゲーション ビュー_

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

前述_の表示モード_のセクションで、上部、常に展開された、常にコンパクトまたは常に最低限に常にするウィンドウを設定できます。 管理することも、表示モード自分で、アプリのコードでします。 この例は、次のセクションに表示されます。

### <a name="top-to-left-navigation"></a>左側のナビゲーションを上

アプリで最上位のナビゲーションを使用する場合のナビゲーション項目をオーバーフロー メニューにウィンドウの幅の減少として折りたたみます。 とき、アプリ ウィンドウが狭い場合は、すべての項目は、オーバーフロー メニューに折りたたむことのではなく、LeftMinimal のナビゲーションを上から PaneDisplayMode を切り替えるユーザー エクスペリエンスの向上を提供できます。

大きなウィンドウのサイズと小さなの左側のナビゲーションでの上部のナビゲーションの使用をお勧めしますウィンドウのサイズを場合。

- その重要度が同じを与えるの左側のナビゲーションを折りたたむこのセットの 1 つのカテゴリが画面に収まらない場合、一緒に表示される均等に重要なトップレベルのナビゲーション カテゴリのセットがあります。
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
> AdaptiveTrigger.MinWindowWidth を使用すると、ウィンドウが指定された最小幅よりも広い場合、表示状態がトリガーされます。 これは、既定の XAML は、幅の狭いウィンドウを定義し、VisualState 幅の広いウィンドウを取得するときに適用される変更を定義することを意味します。 既定の PaneDisplayMode ナビゲーション ビューは、自動、したがってときに、ウィンドウの幅が CompactModeThresholdWidth、小さい LeftMinimal ナビゲーションを使用します。 ウィンドウが大きく、VisualState は、既定値を上書きし、上部のナビゲーションを使用します。

## <a name="navigation"></a>ナビゲーション

ナビゲーション ビューは、自動的にナビゲーション タスクを実行しません。 ナビゲーション項目をタップ、ナビゲーション ビューは、選択された項目と[ItemInvoked](/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked)イベントを発生させます。 タップにより新しいアイテムが選択されていると場合も、 [SelectionChanged](/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged)イベントが発生します。

要求されたナビゲーションに関連するタスクを実行するいずれかのイベントを処理することができます。 2 つを処理する必要がありますは、アプリの目的の動作によって異なります。 通常、要求されたページに移動し、これらのイベントへの応答でナビゲーション ビューのヘッダーを更新します。

**ItemInvoked**がまだ選択されている場合でも、いつでも、ユーザーが、ナビゲーション項目をタップ発生します。 (項目も呼び出せるマウス、キーボード、またはその他の入力を使用して、同等の操作とします。 詳しくは、参照[入力と操作](../input/index.md))。ItemInvoked ハンドラーで移動する場合は、既定では、ページが再読み込みと重複したエントリがナビゲーション スタックに追加します。 呼び出されると、項目を移動する場合は、ページの再読み込みを禁止します。 またはナビゲーション バック スタックに重複するエントリが作成されないである場合、ページが再読み込みすることを確認する必要があります。 (詳しくは、コード例を参照してください)。

ユーザーではない、現在選択されている項目の呼び出しによって、またはをプログラムで選択した項目を変更することは、 **SelectionChanged**を発生させることができます。 ユーザーが項目を呼び出すために選択の変更が発生した場合 ItemInvoked イベントが最初に発生します。 選択の変更がプログラムの場合は、ItemInvoked は発生しません。

### <a name="backwards-navigation"></a>逆方向のナビゲーション

NavigationView は、組み込みの戻るボタンただしと同様に、ナビゲーションがない前に戻るナビゲーションを自動的に実行します。 [戻る] ボタンをタップすると、 [BackRequested](/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested)イベントが発生します。 前に戻るナビゲーションを実行するには、このイベントを処理します。 詳細情報とコード例については、次を参照してください。[ナビゲーション履歴と前に戻るナビゲーション](../basics/navigation-history-and-backwards-navigation.md)します。

最小限またはコンパクト モードでは、ナビゲーション ビューは、ウィンドウがポップアップとして開いて。 この例では、"戻る"ボタンのクリックしてはウィンドウを閉じるし、 **PaneClosing**イベントが発生する代わりにします。

非表示にするか、これらのプロパティを設定して、戻るボタンを無効にできます。

- [IsBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible): と"戻る"ボタンを非表示に使用します。 このプロパティは、 [NavigationViewBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationviewbackbuttonvisible)列挙体の値を受け取り、既定では**自動的**に設定されます。 ボタンが折りたたまれていると領域ない用に予約されてレイアウト。
- [IsBackEnabled](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled): を有効にするまたは戻るボタンを無効にします。 このプロパティには、ナビゲーション フレームの[CanGoBack](/uwp/api/windows.ui.xaml.controls.frame.cangoback)プロパティにデータ バインドできます。 **IsBackEnabled**が**false**の場合、 **BackRequested**は発生しません。

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

この例では、大規模なウィンドウ サイズの上部のナビゲーション ウィンドウと小さなウィンドウ サイズの左側のナビゲーション ウィンドウの両方で NavigationView を使用する方法を示しています。 VisualStateManager で、_上部_のナビゲーションの設定を削除することで左専用のナビゲーションに合わせることができます。

多くの一般的なシナリオに対応するナビゲーション データの設定に推奨される方法の例を示します。 また、前に戻るナビゲーションで NavigationView の"戻る"ボタンとキーボード ナビゲーションを実装する方法を示しています。

このコードでは、アプリがページに移動する次の名前が含まれていると想定しています:_ホームページ_、 _AppsPage_、 _GamesPage_、 _MusicPage_、 _MyContentPage_、および_SettingsPage_します。 これらのページのコードは表示されません。

> [!IMPORTANT]
> アプリのページについては、 [ValueTuple](https://docs.microsoft.com/dotnet/api/system.valuetuple)に格納されます。 この構造体は、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要がありますが必要です。 Windows 10 の以前のバージョンをターゲットに NavigationView の WinUI バージョンを使用する場合は、代わりに[System.ValueTuple NuGet パッケージ](https://www.nuget.org/packages/System.ValueTuple/)を使用できます。

> [!IMPORTANT]
> このコードは、NavigationView の[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)のバージョンを使用する方法を示しています。 NavigationView のプラットフォーム バージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。 プラットフォームのバージョンを使用するすべての参照を削除する`muxc:`します。

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
> このコードは、NavigationView の[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)のバージョンを使用する方法を示しています。 NavigationView のプラットフォーム バージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。 プラットフォームのバージョンを使用するすべての参照を削除する`muxc`します。

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

## <a name="navigation-view-customization"></a>ナビゲーション ビューのカスタマイズ

### <a name="pane-backgrounds"></a>ウィンドウの背景

既定では、NavigationView ウィンドウは、表示モードに応じて、さまざまな背景を使用します。

- ウィンドウは灰色単色 (左モード) では、コンテンツと並行して、左側の展開されたときです。
- ウィンドウは、コンテンツ (上、最小限に抑えながら、またはコンパクト モードで) 上にオーバーレイとして開くときに、アプリ内アクリルを使用します。

ウィンドウの背景を変更するには、各モードの背景をレンダリングするために使用する XAML テーマ リソースを上書きできます。 (この手法が使用 PaneBackground の 1 つのプロパティではなくさまざまな表示モードのさまざまな背景をサポートするために)。

次の表では、どのテーマ リソースを使用して各表示モードを示します。

| 表示モード | テーマ リソース |
| ------------ | -------------- |
| Left | NavigationViewExpandedPaneBackground |
| LeftCompact<br/>LeftMinimal | NavigationViewDefaultPaneBackground |
| Top | NavigationViewTopPaneBackground |

この例では、App.xaml 内のテーマ リソースをオーバーライドする方法を示します。 テーマ リソースをオーバーライドする場合は常を入力してください少なくとも、"Default"と"HighContrast"のリソース ディクショナリとディクショナリ「ライト」または"Dark"のリソースに応じてします。 詳しくは、 [ResourceDictionary.ThemeDictionaries](/uwp/api/windows.ui.xaml.resourcedictionary.themedictionaries)を参照してください。

> [!IMPORTANT]
> このコードは、AcrylicBrush の[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)のバージョンを使用する方法を示しています。 AcrylicBrush のプラットフォーム バージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 16299 以上である必要があります。 プラットフォームのバージョンを使用するすべての参照を削除する`muxm:`します。

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
- [UWP 用 Fluent Design の概要](../fluent-design-system/index.md)