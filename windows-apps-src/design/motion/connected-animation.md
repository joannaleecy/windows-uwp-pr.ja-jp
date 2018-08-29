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
ms.openlocfilehash: a789a8f082192b79b3e96990827f9a4f6a0eacbc
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2918340"
---
# <a name="connected-animation-for-uwp-apps"></a>UWP アプリ用の接続型アニメーション

## <a name="what-is-connected-animation"></a>接続型アニメーションとは

接続型アニメーションを使用すると、2 つの異なるビューの間で要素が切り替わる様子をアニメーション化することによって、動的で魅力的なナビゲーション エクスペリエンスを作成できます。 これにより、ユーザーはコンテキストを維持して、ビューの間の継続性を実現することができます。
接続型アニメーションでは、UI コンテンツが変化するとき (画面間を移動して、ソース ビュー内の要素の場所から新しいビュー内の切り替え先となる場所が表示されるとき)、要素が 2 つのビューの間で "途切れることなく" 表示されます。 これにより、ビューの間で共通するコンテンツが強調され、要素が切り替わるときに魅力的で動的な効果が発生します。

## <a name="see-it-in-action"></a>実際の動作を見る

この短い動画では、アプリは接続型アニメーションを使用して項目の画像をアニメーション化し、その画像が "途切れることなく" 切り替わり、次のページにあるヘッダーの一部となります。 この効果を利用すると、画面の切り替えでユーザー コンテキストを維持することができます。

![継続的なモーションの UI の例](images/continuous3.gif)

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

## <a name="how-to-implement"></a>実装方法

接続型アニメーションのセットアップでは、次の 2 つの手順を実行します。

1.  ソース ページでアニメーション オブジェクトを*準備*します。この手順では、ソース要素が接続型アニメーションに参加することを、システムに伝えます。 
2.  切り替え先のページでアニメーションを*開始*します。この手順では、切り替え先の要素に参照を渡します。

2 つの手順の間では、ソース要素がアプリの他の UI 上でフリーズしているかのように見えます。このとき、他の切り替えアニメーションを同時に実行できてしまいます。 このため、2 つの手順の間の待機時間は 250 ミリ秒を超えないようにしてください。250 ミリ秒を超えると、ソース要素が存在することで問題が発生する可能性があります。 アニメーションを準備しても、アニメーションを 3 秒以内に開始しないと、システムによってアニメーションが破棄され、後続の **TryStart** の呼び出しは失敗します。

現在の ConnectedAnimationService インスタンスにアクセスするには、**ConnectedAnimationService.GetForCurrentView** を呼び出します。 アニメーションを準備するには、このインスタンスの **PrepareToAnimate** を呼び出し、切り替えで使用する一意のキーと UI 要素への参照を渡します。 一意のキーを使用すると、アニメーションを後で取得することができます。たとえば、別のページ上でアニメーションを取得できます。

```csharp
ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image", SourceImage);
```

アニメーションを開始するには、**ConnectedAnimation.TryStart** を呼び出します。 アニメーションの作成時に指定した一意のキーを使用して **ConnectedAnimationService.GetAnimation** を呼び出すことにより、適切なアニメーションのインスタンスを取得できます。

```csharp
ConnectedAnimation imageAnimation = 
    ConnectedAnimationService.GetForCurrentView().GetAnimation("image");
if (imageAnimation != null)
{
    imageAnimation.TryStart(DestinationImage);
}
```

ConnectedAnimationService を使用して 2 つのページ間の切り替えを作成する完全な例を次に示します。

*SourcePage.xaml*

```xaml
<Image x:Name="SourceImage"
       Width="200"
       Height="200"
       Stretch="Fill"
       Source="Assets/StoreLogo.png" />
```

*SourcePage.xaml.cs*

```csharp
private void NavigateToDestinationPage()
{
    ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image", SourceImage);
    Frame.Navigate(typeof(DestinationPage));
}
```

*DestinationPage.xaml*

```xaml
<Image x:Name="DestinationImage"
       Width="400"
       Height="400"
       Stretch="Fill"
       Source="Assets/StoreLogo.png" />
```

*DestinationPage.xaml.cs*

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    ConnectedAnimation imageAnimation = 
        ConnectedAnimationService.GetForCurrentView().GetAnimation("image");
    if (imageAnimation != null)
    {
        imageAnimation.TryStart(DestinationImage);
    }
}
```

## <a name="connected-animation-in-list-and-grid-experiences"></a>リスト エクスペリエンスとグリッド エクスペリエンスでの接続型アニメーション

多くの場合、リスト コントロールやグリッド コントロール間の切り替えで接続型アニメーションの作成が必要になります。 **ListView** と **GridView** の 2 つの新しいメソッドである、**PrepareConnectedAnimation** と **TryStartConnectedAnimationAsync** を使用して、このプロセスを簡略化できます。
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

指定されたリスト項目に対応する楕円を表示する接続型アニメーションを準備するには、一意のキー、項目、および "PortraitEllipse" という名前を指定して、**PrepareConnectedAnimation** メソッドを呼び出します。

```csharp
void PrepareAnimationWithItem(ContactsItem item)
{
     ContactsListView.PrepareConnectedAnimation("portrait", item, "PortraitEllipse");
}
```

また、この要素を切り替え先として使用してアニメーションを開始するには (たとえば、詳細ビューから戻ったときなど)、**TryStartConnectedAnimationAsync** を使用します。 **ListView** のデータ ソースが読み込まれると、**TryStartConnectedAnimationAsync** は、対応する項目コンテナーが作成されるまで、アニメーションが開始されるのを待機します。

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

*連動型アニメーション*は特殊な種類の開始アニメーションで、要素が接続型アニメーションのターゲットと共に表示され、接続型アニメーションの要素と連動してアニメーション化され、画面上を横切って移動します。 連動型アニメーションによって、ビューの切り替え時に視覚的にさらに注目を引く効果が発生し、ソース ビューと切り替え先のビューの間で共有されているコンテキストにユーザーを注目させることができます。 上記の画像では、連動型アニメーションを使用して、項目のキャプション UI がアニメーション化されています。

**TryStart** の 2 つのパラメーター オーバーロードを使用して、連動型の要素を接続型アニメーションに追加します。 次の例では、“DescriptionRoot” という名前のグリッド レイアウトの連動型アニメーションを説明します。このアニメーションは、“CoverImage” という名前の接続型アニメーションの要素と連動して表示されます。

*DestinationPage.xaml*

```xaml
<Grid>
    <Image x:Name="CoverImage" />
    <Grid x:Name="DescriptionRoot" />
</Grid>
```

*DestinationPage.xaml.cs*

```csharp
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
- 接続型アニメーションの準備と開始の間で発生する、ネットワーク要求や他の実行時間の長い非同期操作を待機しないでください。 早めに切り替えを実行するには、必要な情報を事前に読み込んでおく必要があります。または、高解像度の画像が切り替え先のビューに読み込まれるときに、低解像度のプレースホルダー画像を使用する必要があります。
- **ConnectedAnimationService** を使用する場合、**Frame** 内で切り替えアニメーションが使われないようにするには、[SuppressNavigationTransitionInfo](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) を使用します。これは、接続型アニメーションが既定のナビゲーション切り替えとは同時に使用できないアニメーションであるためです。 ナビゲーション切り替えの使用方法について詳しくは、「[NavigationThemeTransition](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)」をご覧ください。


## <a name="download-the-code-samples"></a>コード サンプルのダウンロード

[WindowsUIDevLabs](https://github.com/Microsoft/WindowsUIDevLabs) サンプル ギャラリーの[接続型アニメーションのサンプル](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/ConnectedAnimationSample)をご覧ください。

## <a name="related-articles"></a>関連記事

- [ConnectedAnimation](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimation)
- [ConnectedAnimationService](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.animation.connectedanimation.aspx)
- [NavigationThemeTransition](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)
