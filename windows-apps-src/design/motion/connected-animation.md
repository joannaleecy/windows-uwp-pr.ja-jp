---
author: mijacobs
description: 接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。
title: 接続型アニメーション
template: detail.hbs
ms.author: jimwalk
ms.date: 10/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 31e940c87626a05ee6911d3ffda36ab8dfd3fad0
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4318028"
---
# <a name="connected-animation-for-uwp-apps"></a>UWP アプリ用の接続型アニメーション

接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。 これにより、ユーザーはコンテキストを維持して、ビューの間の継続性を実現することができます。

接続型のアニメーションでは、要素を UI コンテンツが途切れることがなく、画面上で、ソース ビュー内の場所から新しいビュー内の宛先への変更時に 2 つのビューの間で「続行」が表示されます。 これは、ビューの間で共通のコンテンツが強調され、移行の一環として、優れた美しさを持つで動的な効果を作成します。

> **重要な Api**: [ConnectedAnimation クラス](/uwp/api/windows.ui.xaml.media.animation.connectedanimation)、 [ConnectedAnimationService クラス](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)

## <a name="see-it-in-action"></a>実際の動作を見る

この短いビデオでは、アプリは、アニメーション化し、「再開」を次のページのヘッダーの一部となる項目のイメージに接続型アニメーションを使用します。 この効果を利用すると、画面の切り替えでユーザー コンテキストを維持することができます。

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

## <a name="configure-connected-animation"></a>接続型アニメーションを構成します。

> [!IMPORTANT]
> この機能は、アプリのターゲット バージョンは、RS5 である必要があります (Windows SDK バージョン 10.0.NNNNN.0 (Windows 10、バージョン YYMM) 以上。 構成のプロパティでは、以前の Sdk で利用できません。 RS5 より小さい最小バージョンをターゲットにすることができます (Windows SDK バージョン 10.0.NNNNN.0 (Windows 10、バージョン YYMM) を使用してアダプティブ コードや条件付き XAML です。 詳しくは、[バージョン アダプティブ アプリ](/debug-test-perf/version-adaptive-apps)を参照してください。

接続型アニメーションをさらには、Fluent design を具体化以降 RS5 では、アニメーションを提供することによって構成に合わせた具体的には前方と後方ページのナビゲーション。

アニメーションは、構成を指定するには、ConnectedAnimation の構成のプロパティを設定します。 (これの例を示しますが、次のセクションに表示されます)。

次の表では、利用可能な構成について説明します。 これらのアニメーションに適用されるモーションの原則について詳しくは、[方向性と重力](index.md)を参照してください。

| [GravityConnectedAnimationConfiguration]() |
| - |
| これは既定の構成であり、転送のナビゲーションをお勧めします。 |
ユーザーがアプリ (A B から) で前方に移動するように物理的に"ページ"接続されている要素が表示されます。 これによりは、要素は、z 座標で前方に移動する表示され、重力の影響の保留を受けるとしてビットを削除します。 重力の影響をなくすためには、要素は速度を向上し、最終的な位置に高速化します。 結果は、「スケールと dip」のアニメーションです。 |

| [DirectConnectedAnimationConfiguration]() |
| - |
| ユーザーはアプリ (A から b、B) では前に戻る移動したときに、アニメーションはより直接的です。 接続されている要素は、減速三次ベジエ イージング関数を使用する B から線形変換します。 逆方向に視覚的アフォー ダンスは、できるだけ早く、ナビゲーション フローのコンテキストを維持しつつ、ユーザーを以前の状態に返します。 |

| [BasicConnectedAnimationConfiguration]() |
| - |
| これは、既定の (およびのみ) RS5 より前の SDK バージョンで使用されるアニメーション (Windows SDK バージョン 10.0.NNNNN.0 (Windows 10、バージョン YYMM)。 |

### <a name="connectedanimationservice-configuration"></a>ConnectedAnimationService の構成

[ConnectedAnimationService](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)クラスには、全体のサービスではなく、個々 のアニメーションに適用する 2 つのプロパティがあります。

- [DefaultDuration](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.defaultduration)
- [DefaultEasingFunction](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.defaulteasingfunction)

さまざまな効果を実現するためにいくつかの構成は ConnectedAnimationService に対してこれらのプロパティを無視し、代わりに、次の表で説明したように独自の値を使用します。

| 構成 | 点 DefaultDuration かどうか。 | 点 DefaultEasingFunction かどうか。 |
| - | - | - |
| 重力 | はい | ○* <br/> **A から b、b の基本的な翻訳がこのイージング関数を使用しますが、"重力 dip"が、独自のイージング関数。*  |
| 直接 | いいえ <br/> *150 ミリ秒を超えるをアニメーション化します。*| いいえ <br/> *減速のイージング関数を使用します。* |
| 基本 | はい | はい |

## <a name="how-to-implement-connected-animation"></a>接続型アニメーションを実装する方法

接続型アニメーションのセットアップでは、次の 2 つの手順を実行します。

1. *環境の準備*ソース] ページで、システムに、ソース要素が接続型アニメーションに参加することを示すアニメーション オブジェクトです。
1. アニメーションを*開始*先] ページで、切り替え先の要素への参照を渡します。

ソース ページから移動すると、ConnectedAnimationService のインスタンスを取得するのには、 [ConnectedAnimationService.GetForCurrentView](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getforcurrentview)を呼び出します。 アニメーションを準備するには、このインスタンスに[PrepareToAnimate](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.preparetoanimate)を呼び出し、一意のキーと、切り替えで使用する UI 要素に渡します。 一意のキーを使用して、切り替え先のページに後でアニメーションを取得できます。

```csharp
ConnectedAnimationService.GetForCurrentView()
    .PrepareToAnimate("forwardAnimation", SourceImage);
```

ナビゲーションが発生した場合、切り替え先のページでアニメーションを開始します。 アニメーションを開始するには、[ConnectedAnimation.TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) を呼び出します。 アニメーションの作成時に指定した一意のキーを使用して [ConnectedAnimationService.GetAnimation](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice.getanimation) を呼び出すことにより、適切なアニメーションのインスタンスを取得できます。

```csharp
ConnectedAnimation animation =
    ConnectedAnimationService.GetForCurrentView().GetAnimation("forwardAnimation");
if (animation != null)
{
    animation.TryStart(DestinationImage);
}
```

### <a name="forward-navigation"></a>ナビゲーション

この例では、2 つのページ (Page_B に Page_A) 間のナビゲーションが前方の切り替えを作成する ConnectedAnimationService を使用する方法を示します。

ナビゲーションの推奨されるアニメーションの構成では、 [GravityConnectedAnimationConfiguration]()です。 これは、既定では、さまざまな構成を指定する必要がない限り、[構成](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.configuration)プロパティを設定する必要はありません。

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

切り替え先のページでアニメーションを開始します。

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

### <a name="back-navigation"></a>"戻る"ナビゲーション

"戻る"ナビゲーション (Page_A に Page_B) では、同じ手順に従うが、ソースとレプリケーション先のページが逆になります。

ユーザーが戻る移動したとき、できるだけ早く以前の状態に返されるアプリを期待します。 したがって、推奨される構成は、 [DirectConnectedAnimationConfiguration]()です。 このアニメーションはより迅速で直接的であり、減速のイージングを使用します。

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

切り替え先のページでアニメーションを開始します。

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

までの間、アニメーションを設定して開始されたときに、ソース要素には、アプリの他の UI 上でフリーズが表示されます。 その他の切り替え効果のアニメーションを同時に実行できます。 このため、ソース要素のプレゼンスを煩わしいになる可能性がありますので以上 250 ミリ秒を 2 つの手順の間を待機しないでください。 アニメーションを準備しても、アニメーションを 3 秒以内に開始しないと、システムによってアニメーションが破棄され、後続の [TryStart](/uwp/api/windows.ui.xaml.media.animation.connectedanimation.trystart) の呼び出しは失敗します。

## <a name="connected-animation-in-list-and-grid-experiences"></a>リスト エクスペリエンスとグリッド エクスペリエンスでの接続型アニメーション

多くの場合、リスト コントロールやグリッド コントロール間の切り替えで接続型アニメーションの作成が必要になります。 [ListView](/uwp/api/windows.ui.xaml.controls.listview)と[GridView](/uwp/api/windows.ui.xaml.controls.gridview)で[ある PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation)と[TryStartConnectedAnimationAsync](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync)で 2 つのメソッドを使用すると、このプロセスを簡略化します。

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

指定された一覧項目に対応する楕円を接続型アニメーションを準備するには、一意のキー、項目、および"portraitellipse という"名前で[PrepareConnectedAnimation](/uwp/api/windows.ui.xaml.controls.listviewbase.prepareconnectedanimation)メソッドを呼び出します。

```csharp
void PrepareAnimationWithItem(ContactsItem item)
{
     ContactsListView.PrepareConnectedAnimation("portrait", item, "PortraitEllipse");
}
```

この要素と、詳細ビューから戻る移動するときなど、レプリケーション先としてアニメーションを開始するには、 [TryStartConnectedAnimationAsync](/uwp/api/windows.ui.xaml.controls.listviewbase.trystartconnectedanimationasync)を使用します。 ListView のデータ ソースが読み込まれると、TryStartConnectedAnimationAsync は、対応する項目コンテナーが作成されるまで、アニメーションが開始されるのを待機します。

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

*連動型アニメーション*は、特殊な開始アニメーションの要素が画面上で移動するときに、接続型アニメーションの要素と連動してアニメーション化、接続型アニメーションのターゲットと共に表示されます。 連動型アニメーションによって、ビューの切り替え時に視覚的にさらに注目を引く効果が発生し、ソース ビューと切り替え先のビューの間で共有されているコンテキストにユーザーを注目させることができます。 上記の画像では、連動型アニメーションを使用して、項目のキャプション UI がアニメーション化されています。

連動型アニメーションは、重力の構成を使用する場合は、重力が接続型アニメーションの要素と連動型の要素の両方に適用されます。 連動型の要素は"swoop"接続されている要素と一緒に本当に連動型の要素が保持されるようにします。

**TryStart** の 2 つのパラメーター オーバーロードを使用して、連動型の要素を接続型アニメーションに追加します。 この例では、"CoverImage"という名前の接続型アニメーションの要素と連動して入力"DescriptionRoot"という名前のグリッド レイアウトの連動型アニメーションを示します。

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
- ナビゲーションの[GravityConnectedAnimationConfiguration]()を使用します。
- "戻る"ナビゲーションの[DirectConnectedAnimationConfiguration]()を使用します。
- ネットワーク要求や他の実行時間の長い非同期の操作を準備して、接続型アニメーションの開始の間待機しないでください。 早めに切り替えを実行するには、必要な情報を事前に読み込んでおく必要があります。または、高解像度の画像が切り替え先のビューに読み込まれるときに、低解像度のプレースホルダー画像を使用する必要があります。
- 接続型アニメーションは既定のナビゲーションを同時に使用できるものであるために、 **ConnectedAnimationService**を使用している場合は、**フレーム**内の切り替えアニメーションを防ぐために[SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo)を使う遷移します。 ナビゲーション切り替えの使用方法について詳しくは、「[NavigationThemeTransition](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition)」をご覧ください。

## <a name="download-the-code-samples"></a>コード サンプルのダウンロード

[WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) サンプル ギャラリーの[接続型アニメーションのサンプル](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample)をご覧ください。

## <a name="related-articles"></a>関連記事

[ConnectedAnimation](/uwp/api/windows.ui.xaml.media.animation.connectedanimation)

[ConnectedAnimationService](/uwp/api/windows.ui.xaml.media.animation.connectedanimationservice)

[NavigationThemeTransition](/uwp/api/Windows.UI.Xaml.Media.Animation.NavigationThemeTransition)
