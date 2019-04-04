---
description: 接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。
title: 接続型アニメーション
template: detail.hbs
ms.date: 10/04/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a205fb151d1c9e6614dc97ccde639e43720aa8a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618197"
---
# <a name="connected-animation-for-uwp-apps"></a>UWP アプリ用の接続型アニメーション

接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。 これにより、ユーザーはコンテキストを維持して、ビューの間の継続性を実現することができます。

アニメーションの結び要素は、新しいビューにその先に、ソース ビュー内の場所から、画面上で飛行の UI コンテンツの変更中に 2 つのビューの間には、[続行] が表示されます。 これにより、ビューの間の一般的なコンテンツを強調し、遷移の一部として美しいおよび動的な効果を作成します。

> **重要な Api**:[ConnectedAnimation クラス](/uwp/api/windows.ui.xaml.media.animation.connectedanimation)、 [ConnectedAnimationService クラス](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)

## <a name="see-it-in-action"></a>実際の動作を見る

この短いビデオでは、アプリは、「継続」次のページのヘッダーの一部となる項目のイメージをアニメーション化するのにアニメーションの結び付けを使用します。 この効果を利用すると、画面の切り替えでユーザー コンテキストを維持することができます。

![接続型アニメーション](images/connected-animations/example.gif)

<!-- 
<iframe width=640 height=360 src='https://microsoft.sharepoint.com/portals/hub/_layouts/15/VideoEmbedHost.aspx?chId=552c725c%2De353%2D4118%2Dbd2b%2Dc2d0584c9848&amp;vId=b2daa5ee%2Dbe15%2D4503%2Db541%2D1328a6587c36&amp;width=640&amp;height=360&amp;autoPlay=false&amp;showInfo=true' allowfullscreen></iframe>
-->

## <a name="video-summary"></a>ビデオの概要

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev005/player]

## <a name="connected-animation-and-the-fluent-design-system"></a>接続型アニメーションと Fluent Design System

 Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。 接続型アニメーションは、アプリに動きを加える Fluent Design System コンポーネントです。 詳しくは、[UWP 用の Fluent Design の概要に関するページ](../fluent-design-system/index.md)をご覧ください。

## <a name="why-connected-animation"></a>接続型アニメーションを使用する理由

ページ間を移動するときには、移動後にどのような新しいコンテンツが表示されるか、その新しいコンテンツがページを移動するユーザーの目的とどのように関連しているかを、ユーザーが理解できるようにすることが重要です。 接続型アニメーションを利用すると、2 つのビューで共有されているコンテンツにユーザーを注目させることによって、2 つのビューの間の関係を強調する強力な視覚的メタファが実現されます。 また、接続型アニメーションによって、ページを移動するときに、視覚的に注目を引く効果や洗練された視覚効果を発生させることができます。このことは、アプリのモーション デザインを特徴付ける際に役立ちます。

## <a name="when-to-use-connected-animation"></a>接続型アニメーションを使用するタイミング

一般に、接続型アニメーションはページを変更するとき使用されます。ただし、UI のコンテンツを変更するときに、そのコンテンツが維持されるようにユーザーに対して表示する必要がある場合は、接続型アニメーションをどのようなエクスペリエンスにでも適用できます。 ソース ビューと切り替え先のビューの間で UI の画像や他の UI の要素が共有されている場合は、必ず、[ドリル インによるナビゲーション切り替え](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)ではなく、接続型アニメーションの使用を検討してください。

## <a name="configure-connected-animation"></a>アニメーションの結び付けを構成します。

> [!IMPORTANT]
> この機能では、アプリのターゲット バージョンの Windows 10、バージョンは 1809 である必要があります ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。 構成プロパティは、以前の Sdk でご利用いただけません。 SDK 17763 より前の最小バージョンを対象にするアダプティブ コードまたは条件付き XAML を使用します。 詳細については、[バージョン アダプティブ アプリ](/windows/uwp/debug-test-perf/version-adaptive-apps)を参照してください。

以降では、Windows 10、バージョンは 1809、アニメーションの結び付けさらに具体化 Fluent デザインのアニメーションを提供することで構成調整と旧バージョンと順方向専用のページ ナビゲーション。

アニメーションは、の構成を指定するには、構成プロパティ、ConnectedAnimation を設定します。 (紹介の例として、次のセクションでします。)

このテーブルには、使用可能な構成について説明します。 これらのアニメーションに適用されるモーション原則の詳細については、[の方向や重力](index.md)を参照してください。

| [GravityConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration) |
| - |
| 既定の構成では、これは"進む"ナビゲーション推奨します。 |
アプリ (A B から) での前方移動している間、ユーザー、物理的に"pull がページ外"に接続されている要素が表示されます。 そうでは、要素は、z 座標で前方に移動するが表示され、重力を保留中の影響を少しで、削除します。 重力の影響をなくすためには、要素は速度の向上し、を迅速に、最後の位置。 「スケールと dip」アニメーションになります。 |

| [DirectConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration) |
| - |
| ユーザーはアプリ (B) では後方移動したときにアニメーションがより直接的にします。 接続されている要素は、直線的には減速 3 次ベジエ イージング関数を使用して、B から変換します。 旧バージョンと visual アフォー ダンスは、できるだけ高速、ナビゲーションのフローのコンテキストを維持しながら、ユーザーを以前の状態に返します。 |

| [BasicConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.basicconnectedanimationconfiguration) |
| - |
| これは、既定値 (および専用) Windows 10、バージョンは 1809 より前のバージョンで使用されるアニメーション ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk))。 |

### <a name="connectedanimationservice-configuration"></a>ConnectedAnimationService 構成

[ConnectedAnimationService](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)クラス全体のサービスではなく、個々 のアニメーションに適用される 2 つのプロパティがあります。

- [DefaultDuration](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.defaultduration)
- [DefaultEasingFunction](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.defaulteasingfunction)

さまざまな効果を実現するためにいくつかの構成は ConnectedAnimationService でこれらのプロパティを無視して、独自の値を使用して、代わりに、この表で説明します。

| 構成 | 保護に努めています DefaultDuration でしょうか。 | 保護に努めています DefaultEasingFunction でしょうか。 |
| - | - | - |
| 重力 | 〇 | ○* <br/> **A から B への基本的な変換がこのイージング関数を使用しますが、"重力 dip"が、独自のイージング関数。*  |
| ダイレクト | X <br/> *超える 150ms をアニメーション化します。*| X <br/> *イージング関数は、減速を使用します。* |
| 基本 | 〇 | 〇 |

## <a name="how-to-implement-connected-animation"></a>アニメーションの結び付けを実装する方法

接続型アニメーションのセットアップでは、次の 2 つの手順を実行します。

1. *準備*ソース ページで、システムに、ソース要素がアニメーションの結び付けに参加することを示すアニメーション オブジェクト。
1. *開始*ターゲット要素への参照を渡して、移動先ページのアニメーション。

元のページからの移動時に呼び出す[ConnectedAnimationService.GetForCurrentView](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getforcurrentview) ConnectedAnimationService のインスタンスを取得します。 アニメーションを準備するには、呼び出す[PrepareToAnimate](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.preparetoanimate)このインスタンスし、一意のキーと、移行で使用する UI 要素を渡します。 一意のキーを使用して、移動先ページでは後で、アニメーションを取得できます。

```csharp
ConnectedAnimationService.GetForCurrentView()
    .PrepareToAnimate("forwardAnimation", SourceImage);
```

ナビゲーションが発生したときに、移動先ページで、アニメーションを起動します。 アニメーションを開始するには、[ConnectedAnimation.TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) を呼び出します。 アニメーションの作成時に指定した一意のキーを使用して [ConnectedAnimationService.GetAnimation](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getanimation) を呼び出すことにより、適切なアニメーションのインスタンスを取得できます。

```csharp
ConnectedAnimation animation =
    ConnectedAnimationService.GetForCurrentView().GetAnimation("forwardAnimation");
if (animation != null)
{
    animation.TryStart(DestinationImage);
}
```

### <a name="forward-navigation"></a>"進む"ナビゲーション

この例では、ConnectedAnimationService を使用して、2 つのページ (Page_B に Page_A)"進む"ナビゲーションの遷移を作成する方法を示します。

"進む"ナビゲーション推奨されるアニメーションの構成が[GravityConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration)します。 設定する必要はありませんは、既定値は、これは、[構成](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.configuration)プロパティを別の構成を指定しない場合。

ソース ページでアニメーションを設定します。

```xaml
<!-- Page_A.xaml -->

<Image x:Name="SourceImage"
       HorizontalAlignment="Left" VerticalAlignment="Top"
       Width="200" Height="200"
       Stretch="Fill"
       Source="Assets/StoreLogo.png"
       PointerPressed="SourceImage_PointerPressed"/>
```

```csharp
// Page_A.xaml.cs

private void SourceImage_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    // Navigate to detail page.
    // Suppress the default animation to avoid conflict with the connected animation.
    Frame.Navigate(typeof(Page_B), null, new SuppressNavigationTransitionInfo());
}

protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
{
    ConnectedAnimationService.GetForCurrentView()
        .PrepareToAnimate("forwardAnimation", SourceImage);
    // You don't need to explicitly set the Configuration property because
    // the recommended Gravity configuration is default.
    // For custom animation, use:
    // animation.Configuration = new BasicConnectedAnimationConfiguration();
}
```

移動先ページでアニメーションを開始します。

```xaml
<!-- Page_B.xaml -->

<Image x:Name="DestinationImage"
       Width="400" Height="400"
       Stretch="Fill"
       Source="Assets/StoreLogo.png" />
```

```csharp
// Page_B.xaml.cs

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    ConnectedAnimation animation =
        ConnectedAnimationService.GetForCurrentView().GetAnimation("forwardAnimation");
    if (animation != null)
    {
        animation.TryStart(DestinationImage);
    }
}
```

### <a name="back-navigation"></a>戻るナビゲーション

戻るナビゲーション (Page_A に Page_B) のため、同じ手順に従いますが、元とコピー先のページが取り消されます。

ユーザーがバックアップに移動したときに、以前の状態に、できるだけ早く返されるアプリが期待されます。 そのため、推奨される構成は[DirectConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration)します。 このアニメーションは高速より直接的にあり、減速のイージングを使用します。

ソース ページでアニメーションを設定します。

```csharp
// Page_B.xaml.cs

protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
{
    if (e.NavigationMode == NavigationMode.Back)
    {
        ConnectedAnimationService.GetForCurrentView()
            .PrepareToAnimate("backAnimation", DestinationImage);

        // Use the recommended configuration for back animation.
        animation.Configuration = new DirectConnectedAnimationConfiguration();
    }
}
```

移動先ページでアニメーションを開始します。

```csharp
// Page_A.xaml.cs

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    ConnectedAnimation animation =
        ConnectedAnimationService.GetForCurrentView().GetAnimation("backAnimation");
    if (animation != null)
    {
        animation.TryStart(SourceImage);
    }
}
```

までの時間は起動時に、アニメーションが設定されていると、ソース要素は、アプリで他の UI の上に固定表示されます。 その他の遷移のアニメーションを同時に実行できます。 このため、ソース要素の存在を無駄になる可能性がありますので、2 つの手順の間 ~ 250 以上のミリ秒の待機することはできません。 アニメーションを準備しても、アニメーションを 3 秒以内に開始しないと、システムによってアニメーションが破棄され、後続の [TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) の呼び出しは失敗します。

## <a name="connected-animation-in-list-and-grid-experiences"></a>リスト エクスペリエンスとグリッド エクスペリエンスでの接続型アニメーション

多くの場合、リスト コントロールやグリッド コントロール間の切り替えで接続型アニメーションの作成が必要になります。 2 つのメソッドを使用するには[ListView](/uwp/api/windows.ui.xaml.controls.listview)と[GridView](/uwp/api/windows.ui.xaml.controls.gridview)、 [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation)と[trystartconnectedanimationasync です](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync)、このプロセスが簡略化します。

たとえば、データ テンプレート内に "PortraitEllipse" という名前の要素を含んでいる **ListView** があるとします。

```xaml
<ListView x:Name="ContactsListView" Loaded="ContactsListView_Loaded">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="vm:ContactsItem">
            <Grid>
                …
                <Ellipse x:Name="PortraitEllipse" … />
            </Grid>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

特定のリスト項目に対応する楕円をアニメーションの結び付けを準備するには、呼び出し、 [PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation)一意キー、アイテム、および"PortraitEllipse"という名前を持つメソッド。

```csharp
void PrepareAnimationWithItem(ContactsItem item)
{
     ContactsListView.PrepareConnectedAnimation("portrait", item, "PortraitEllipse");
}
```

など、詳細ビューから後方に移動すると、変換先として、この要素にアニメーションを開始するには使用[trystartconnectedanimationasync です](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync)します。 ListView のデータ ソースが読み込んだ trystartconnectedanimationasync ですは対応する項目コンテナーが作成されるまで、アニメーションの開始を待機します。

```csharp
private void ContactsListView_Loaded(object sender, RoutedEventArgs e)
{
    ContactsItem item = GetPersistedItem(); // Get persisted item
    if (item != null)
    {
        ContactsListView.ScrollIntoView(item);
        ConnectedAnimation animation =
            ConnectedAnimationService.GetForCurrentView().GetAnimation("portrait");
        if (animation != null)
        {
            await ContactsListView.TryStartConnectedAnimationAsync(
                animation, item, "PortraitEllipse");
        }
    }
}
```

## <a name="coordinated-animation"></a>連動型アニメーション

![連動型アニメーション](images/connected-animations/coordinated_example.gif)

<!--
<iframe width=640 height=360 src='https://microsoft.sharepoint.com/portals/hub/_layouts/15/VideoEmbedHost.aspx?chId=552c725c%2De353%2D4118%2Dbd2b%2Dc2d0584c9848&amp;vId=9066bbbe%2Dcf58%2D4ab4%2Db274%2D595616f5d0a0&amp;width=640&amp;height=360&amp;autoPlay=false&amp;showInfo=true' allowfullscreen></iframe>
-->

A*アニメーションを調整*特殊な種類の開始のアニメーションは、要素が画面上で移動するときに、アニメーションの結び付け要素と連携してアニメーション化、アニメーションの結び付けターゲットと共に表示されます。 連動型アニメーションによって、ビューの切り替え時に視覚的にさらに注目を引く効果が発生し、ソース ビューと切り替え先のビューの間で共有されているコンテキストにユーザーを注目させることができます。 上記の画像では、連動型アニメーションを使用して、項目のキャプション UI がアニメーション化されています。

調整されたアニメーションは、重力構成を使用する場合は、重力がアニメーションの結び付け要素と調整の要素の両方に適用されます。 連携のとれた要素は"swoop"接続されている要素と共に、真の連携した要素を維持します。

**TryStart** の 2 つのパラメーター オーバーロードを使用して、連動型の要素を接続型アニメーションに追加します。 この例では、"CoverImage"という名前のアニメーションの結び付け要素が連携して入力した"DescriptionRoot"という名前のグリッド レイアウトの調整されたアニメーションを示します。

```xaml
<!-- DestinationPage.xaml -->
<Grid>
    <Image x:Name="CoverImage" />
    <Grid x:Name="DescriptionRoot" />
</Grid>
```

```csharp
// DestinationPage.xaml.cs
void OnNavigatedTo(NavigationEventArgs e)
{
    var animationService = ConnectedAnimationService.GetForCurrentView();
    var animation = animationService.GetAnimation("coverImage");

    if (animation != null)
    {
        // Don’t need to capture the return value as we are not scheduling any subsequent
        // animations
        animation.TryStart(CoverImage, new UIElement[] { DescriptionRoot });
     }
}
```

## <a name="dos-and-donts"></a>推奨と非推奨

- 接続型アニメーションは、ソース ページと切り替え先のページの間で要素が共有されている場合に、ページの切り替えで使用してください。
- 使用[GravityConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration) "進む"ナビゲーションの。
- 使用[DirectConnectedAnimationConfiguration](/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration)のナビゲーションをバックアップします。
- ネットワーク要求または他の実行時間の長い非同期の操作を準備して、接続されているアニメーションの開始の間に待機はありません。 早めに切り替えを実行するには、必要な情報を事前に読み込んでおく必要があります。または、高解像度の画像が切り替え先のビューに読み込まれるときに、低解像度のプレースホルダー画像を使用する必要があります。
- 使用[SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo)の遷移のアニメーションを防ぐために、**フレーム**を使用する場合**ConnectedAnimationService**、アニメーションの結び付け以降既定のナビゲーションの切り替えを同時に使用するためのものはありません。 ナビゲーション切り替えの使用方法について詳しくは、「[NavigationThemeTransition](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition)」をご覧ください。

## <a name="download-the-code-samples"></a>コード サンプルのダウンロード

[WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) サンプル ギャラリーの[接続型アニメーションのサンプル](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample)をご覧ください。

## <a name="related-articles"></a>関連記事

[ConnectedAnimation](/uwp/api/windows.ui.xaml.media.animation.connectedanimation)

[ConnectedAnimationService](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)

[NavigationThemeTransition](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition)
