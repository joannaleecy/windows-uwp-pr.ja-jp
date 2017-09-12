---
author: Jwmsft
Description: "リスト ビューで引っ張って更新パターンを使います。"
title: "引っ張って更新"
label: Pull-to-refresh
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: aaeb1e74-b795-4015-bf41-02cb1d6f467e
pm-contact: predavid
design-contact: kimsea
dev-contact: stpete
doc-status: Published
ms.openlocfilehash: 51a8c9a2e4618e054374308918a74cf2095119ef
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="pull-to-refresh"></a>引っ張って更新

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

引っ張って更新パターンを使うと、より多くのデータを取得するためにタッチ操作でデータのリストを引き下げることができます。 引っ張って更新はモバイル アプリで広く使われていますが、タッチ スクリーンを備えたすべてのデバイスで役に立ちます。 [操作イベント](../input-and-devices/touch-interactions.md#manipulation-events)を処理して、アプリに引っ張って更新を実装できます。

> **重要な API**: [ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、[GridView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)

「[引っ張って更新のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620635)」に、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) コントロールを拡張してこのパターンをサポートする方法を示しています。 この記事では、このサンプルを使って引っ張って更新を実装する際の重要ポイントを説明します。

![引っ張って更新のサンプル](images/ptr-phone-1.png)

## <a name="is-this-the-right-pattern"></a>適切なパターンの選択

ユーザーが定期的に更新するデータのリストやグリッドがあり、アプリがモバイルやタッチ操作主体のデバイスで実行されることが多いときは、引っ張って更新パターンを使います。

## <a name="implement-pull-to-refresh"></a>引っ張って更新を実装する

引っ張って更新を実装するには、操作イベントを処理してユーザーがリストを下に引っ張ったときに検出し、視覚的なフィードバックを表示し、データを更新する必要があります。 ここでは、「[引っ張って更新のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620635)」でこれらがどのように行われているかを見ていきます。 ここではすべてのコードを示さないため、GitHub でサンプルをダウンロードするか、コードを表示してください。

引っ張って更新のサンプルでは、**ListView** コントロールを拡張するカスタム コントロール `RefreshableListView` を作成します。 このコントロールは、更新インジケーターを追加して視覚的なフィードバックを表示し、リスト ビューの内部スクロール ビューアーに対する操作イベントを処理します。 また、リストが引っ張られたときとデータを更新する必要があるときに通知する 2 つのイベントを追加します。 RefreshableListView は、データを更新する必要があることだけを通知します。 アプリでイベントを処理してデータを更新する必要があります。そのコードはアプリごとに異なります。

RefreshableListView は、更新が必要な時期と更新インジケーターを非表示にする方法を判断する "自動更新" モードを提供します。 自動更新はオンまたはオフにできます。
- オフ: `PullThreshold` を超えている間にリストがリリースされる場合にのみ更新が要求されます。 ユーザーがスクロール領域から離れると、インジケーターがアニメーション化されて非表示になります。 利用可能な場合、ステータス バー インジケーターが表示されます (電話)。
- 点灯: `PullThreshold` を超えると、リリースされるかどうかにかかわらずすぐに更新が要求されます。 インジケーターは新しいデータが取得されるまで表示されたままで、その後、アニメーション化されて非表示になります。 データの取得が完了すると、**Deferral** を使ってアプリに通知されます。

> **注**&nbsp;&nbsp;サンプルのコードは、[GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) にも適用されます。 GridView を変更するには、ListView ではなく GridView からカスタム クラスを派生し、GridView の既定のテンプレートを変更します。

## <a name="add-a-refresh-indicator"></a>更新インジケーターを追加する

アプリが引っ張って更新をサポートしていることがユーザーにわかるように、視覚的なフィードバックを表示することが重要です。 RefreshableListView には、XAML でインジケーターを表示するように設定できる `RefreshIndicatorContent` プロパティがあります。 また、`RefreshIndicatorContent` を設定しない場合にフォールバックする既定のテキスト インジケータも含まれています。

以下に、更新インジケーターの推奨ガイドラインを示します。

![更新インジケーターのガイドライン](images/ptr-redlines-1.png)

**リスト ビューのテンプレートを変更する**

引っ張って更新のサンプルでは、更新インジケーターを追加することで、`RefreshableListView` コントロールのテンプレートが標準の **ListView** テンプレートを変更しています。 更新インジケーターは、[ItemsPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemspresenter.aspx) の上の [Grid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.aspx) に配置されます。これはリスト項目が表示される部分です。

> **注意**&nbsp;&nbsp;`DefaultRefreshIndicatorContent` テキスト ボックスは、`RefreshIndicatorContent` プロパティが設定されていない場合にのみ表示されるテキストのフォールバック インジケーターを提供します。

次に、ListView の既定のテンプレートから変更されたコントロール テンプレートの一部を示します。

**XAML**
```xaml
<!-- Styles/Styles.xaml -->
<Grid x:Name="ScrollerContent" VerticalAlignment="Top">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>
    <Border x:Name="RefreshIndicator" VerticalAlignment="Top" Grid.Row="1">
        <Grid>
            <TextBlock x:Name="DefaultRefreshIndicatorContent" HorizontalAlignment="Center" 
                       Foreground="White" FontSize="20" Margin="20, 35, 20, 20"/>
            <ContentPresenter Content="{TemplateBinding RefreshIndicatorContent}"></ContentPresenter>
        </Grid>
    </Border>
    <ItemsPresenter FooterTransitions="{TemplateBinding FooterTransitions}" 
                    FooterTemplate="{TemplateBinding FooterTemplate}" 
                    Footer="{TemplateBinding Footer}" 
                    HeaderTemplate="{TemplateBinding HeaderTemplate}" 
                    Header="{TemplateBinding Header}" 
                    HeaderTransitions="{TemplateBinding HeaderTransitions}" 
                    Padding="{TemplateBinding Padding}"
                    Grid.Row="1"
                    x:Name="ItemsPresenter"/>
</Grid>
```

**XAML でコンテンツを設定する**

リスト ビュー用の XAML で、更新インジケーターのコンテンツを設定します。 設定する XAML コンテンツは、更新インジケーターの [ContentPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentpresenter.aspx) (`<ContentPresenter Content="{TemplateBinding RefreshIndicatorContent}">`) によって表示されます。 このコンテンツを設定しない場合、代わりに既定のテキスト インジケータが表示されます。

**XAML**
```xaml
<!-- MainPage.xaml -->
<c:RefreshableListView
    <!-- ... See sample for removed code. -->
    AutoRefresh="{x:Bind Path=UseAutoRefresh, Mode=OneWay}"
    ItemsSource="{x:Bind Items}"
    PullProgressChanged="listView_PullProgressChanged"
    RefreshRequested="listView_RefreshRequested">

    <c:RefreshableListView.RefreshIndicatorContent>
        <Grid Height="100" Background="Transparent">
            <FontIcon
                Margin="0,0,0,30"
                HorizontalAlignment="Center"
                VerticalAlignment="Bottom"
                FontFamily="Segoe MDL2 Assets"
                FontSize="20"
                Glyph="&#xE72C;"
                RenderTransformOrigin="0.5,0.5">
                <FontIcon.RenderTransform>
                    <RotateTransform x:Name="SpinnerTransform" Angle="0" />
                </FontIcon.RenderTransform>
            </FontIcon>
        </Grid>
    </c:RefreshableListView.RefreshIndicatorContent>
    
    <!-- ... See sample for removed code. -->

</c:RefreshableListView>
```

**スピンをアニメーション化する**

リストが引き下げられると、RefreshableListView の `PullProgressChanged` イベントが発生します。 アプリでこのイベントを処理して、更新インジケーターを制御します。 サンプルでは、このストーリー ボードはインジケーターの [RotateTransform](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.rotatetransform.aspx) をアニメーション化し、更新インジケーターを回転させます。 

**XAML**
```xaml
<!-- MainPage.xaml -->
<Storyboard x:Name="SpinnerStoryboard">
    <DoubleAnimation
        Duration="00:00:00.5"
        FillBehavior="HoldEnd"
        From="0"
        RepeatBehavior="Forever"
        Storyboard.TargetName="SpinnerTransform"
        Storyboard.TargetProperty="Angle"
        To="360" />
</Storyboard>
```

## <a name="handle-scroll-viewer-manipulation-events"></a>スクロール ビューアー操作イベントを処理する

リスト ビュー コントロールのテンプレートには、ユーザーがリスト項目をスクロールできるようにする組み込みの [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) が含まれています。 引っ張って更新を実装するには、いくつかの関連するイベントのほか、組み込みのスクロール ビューアーでの操作イベントを処理する必要があります。 操作イベントについて詳しくは、「[タッチ操作](../input-and-devices/touch-interactions.md)」をご覧ください。

** OnApplyTemplate**

スクロール ビューアーおよびその他のテンプレート パーツにアクセスして、イベント ハンドラーを追加してそれらを後でコードで呼び出せるようにするには、[OnApplyTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.onapplytemplate.aspx) メソッドをオーバーライドする必要があります。 OnApplyTemplate で、[GetTemplateChild](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.gettemplatechild.aspx) を呼び出してコントロール テンプレートの名前付きパーツへの参照を取得します。これはコードの後半で使用できるように保存できます。

サンプルでは、テンプレート パーツを格納するために使う変数はプライベート変数領域で宣言されています。 OnApplyTemplate メソッドでそれらを取得した後、[DirectManipulationStarted](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.directmanipulationstarted.aspx)、[DirectManipulationCompleted](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.directmanipulationcompleted.aspx)、[ViewChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.viewchanged.aspx)、および [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントのイベント ハンドラーを追加します。

**DirectManipulationStarted**

引っ張って更新アクションを開始するには、ユーザーが引き下げ始めるときに、コンテンツがスクロール ビューアーの一番上にスクロールされている必要があります。 そうでない場合は、リスト内で上にパンするために引っ張っていると見なされます。 このハンドラーのコードは、操作がスクロール ビューアーの一番上のコンテンツから開始されたかどうかを判断します。その結果、リストが更新されることがあります。 それに応じて、コントロールの '更新可能' 状態が設定されます。 

コントロールが更新可能な場合、アニメーションのイベント ハンドラーも追加されます。

**DirectManipulationCompleted**

ユーザーがリストを引き下げることを停止したら、このハンドラーのコードは、操作中に更新がアクティブ化されたかどうかを確認します。 更新がアクティブ化された場合、`RefreshRequested` イベントが発生し、`RefreshCommand` コマンドが実行されます。

アニメーションのイベント ハンドラーも削除されます。

`AutoRefresh` プロパティの値に基づいて、リストはすぐにアニメーション化に戻るか、更新が完了するのを待ってからアニメーション化に戻ります。 [Deferral](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.aspx) オブジェクトを使って、更新の完了をマークします。 その時点で、更新インジケーター UI は非表示です。

DirectManipulationCompleted イベント ハンドラーのこの部分で `RefreshRequested`イベントを発生させ、必要な場合は Deferral を取得します。

**C#**
```csharp
if (this.RefreshRequested != null)
{
    RefreshRequestedEventArgs refreshRequestedEventArgs = new RefreshRequestedEventArgs(
        this.AutoRefresh ? new DeferralCompletedHandler(RefreshCompleted) : null);
    this.RefreshRequested(this, refreshRequestedEventArgs);
    if (this.AutoRefresh)
    {
        m_scrollerContent.ManipulationMode = ManipulationModes.None;
        if (!refreshRequestedEventArgs.WasDeferralRetrieved)
        {
            // The Deferral object was not retrieved in the event handler.
            // Animate the content up right away.
            this.RefreshCompleted();
        }
    }
}
```

**ViewChanged**

2 つのケースが ViewChanged イベント ハンドラーで処理されます。

1 つ目に、スクロール ビューアーのズームによりビューが変更された場合、コントロールの "更新可能な" 状態がキャンセルされます。

2 つ目に、自動更新の最後にコンテンツのアニメーション化が完了した場合、パディングの四角形が非表示になって、スクロール ビューアーによるタッチ操作が再び有効になり、[VerticalOffset](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticaloffset.aspx) が 0 に設定されます。

**PointerPressed**

引っ張って更新が行われるのは、タッチ操作によってリストが引き下げられたときだけです。 PointerPressed イベント ハンドラーで、どの種類のポインターがイベントを発生させたかをチェックし、それがタッチ ポインターであったかどうかを示す変数 (`m_pointerPressed`) を設定します。 この変数は DirectManipulationStarted ハンドラーで使われます。 ポインターがタッチ ポインターでない場合は、DirectManipulationStarted ハンドラーは何もせずに戻ります。

## <a name="add-pull-and-refresh-events"></a>引っ張って更新のイベントを追加する

'RefreshableListView' は 2 つのイベントを追加します。これらをアプリで処理して、データを更新し、更新インジケーターを管理することができます。

イベントについて詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/windows/uwp/xaml-platform/events-and-routed-events-overview)」をご覧ください。

**RefreshRequested**

'RefreshRequested' イベントは、ユーザーがリストを更新するために引っ張ったことをアプリに通知します。 このイベントを処理して、新しいデータを取得し、リストを更新します。

サンプルのイベント ハンドラーを次に示します。 重要なのは、リスト ビューの `AutoRefresh` プロパティを確認し、**true** の場合は Deferral を取得することです。 Deferral を使うと、更新インジケーターは停止せず、更新が完了するまで非表示になります。

**C#**
```csharp
private async void listView_RefreshRequested(object sender, RefreshableListView.RefreshRequestedEventArgs e)
{
    using (Deferral deferral = listView.AutoRefresh ? e.GetDeferral() : null)
    {
        await FetchAndInsertItemsAsync(_rand.Next(1, 5));

        if (SpinnerStoryboard.GetCurrentState() != Windows.UI.Xaml.Media.Animation.ClockState.Stopped)
        {
            SpinnerStoryboard.Stop();
        }
    }
}
```

**PullProgressChanged**

サンプルでは、アプリによって更新インジケーターのコンテンツが提供および制御されます。 更新インジケーターを起動、停止、およびをリセットできるように、ユーザーがリストを引っ張ったことを 'PullProgressChanged' イベントが通知します。 

## <a name="composition-animations"></a>コンポジションのアニメーション

既定では、スクロール バーが一番上に達するとスクロール ビューアーのコンテンツは停止します。 ユーザーがリストを引き下げ続けられるようにするには、ビジュアル レイヤーにアクセスし、リストのコンテンツをアニメーション化する必要があります。 サンプルでは、このために[コンポジション アニメーション](https://msdn.microsoft.com/windows/uwp/composition/composition-animation)、具体的には[数式アニメーション](https://msdn.microsoft.com/windows/uwp/composition/composition-animation#expression-animations)を使います。

サンプルでは、主に `CompositionTarget_Rendering` イベント ハンドラーと `UpdateCompositionAnimations` メソッドがこの処理を行います。

## <a name="related-articles"></a>関連記事

- [コントロールのスタイル](styling-controls.md)
- [タッチ操作](../input-and-devices/touch-interactions.md)
- [リスト ビューとグリッド ビュー](listview-and-gridview.md)
- [リスト ビュー項目テンプレート](listview-item-templates.md)
- [数式アニメーション](https://msdn.microsoft.com/windows/uwp/composition/composition-animation#expression-animations)