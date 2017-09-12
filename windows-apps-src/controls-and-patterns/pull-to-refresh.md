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
# <a name="pull-to-refresh"></a><span data-ttu-id="cc469-104">引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="cc469-104">Pull to refresh</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="cc469-105">引っ張って更新パターンを使うと、より多くのデータを取得するためにタッチ操作でデータのリストを引き下げることができます。</span><span class="sxs-lookup"><span data-stu-id="cc469-105">The pull-to-refresh pattern lets a user pull down on a list of data using touch in order to retrieve more data.</span></span> <span data-ttu-id="cc469-106">引っ張って更新はモバイル アプリで広く使われていますが、タッチ スクリーンを備えたすべてのデバイスで役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="cc469-106">Pull-to-refresh is widely used on mobile apps, but is useful on any device with a touch screen.</span></span> <span data-ttu-id="cc469-107">[操作イベント](../input-and-devices/touch-interactions.md#manipulation-events)を処理して、アプリに引っ張って更新を実装できます。</span><span class="sxs-lookup"><span data-stu-id="cc469-107">You can handle [manipulation events](../input-and-devices/touch-interactions.md#manipulation-events) to implement pull-to-refresh in your app.</span></span>

> <span data-ttu-id="cc469-108">**重要な API**: [ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、[GridView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)</span><span class="sxs-lookup"><span data-stu-id="cc469-108">**Important APIs**: [ListView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx), [GridView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)</span></span>

<span data-ttu-id="cc469-109">「[引っ張って更新のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620635)」に、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) コントロールを拡張してこのパターンをサポートする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="cc469-109">The [pull-to-refresh sample](http://go.microsoft.com/fwlink/p/?LinkId=620635) shows how to extend a [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) control to support this pattern.</span></span> <span data-ttu-id="cc469-110">この記事では、このサンプルを使って引っ張って更新を実装する際の重要ポイントを説明します。</span><span class="sxs-lookup"><span data-stu-id="cc469-110">In this article, we use this sample to explain the key points of implementing pull-to-refresh.</span></span>

![引っ張って更新のサンプル](images/ptr-phone-1.png)

## <a name="is-this-the-right-pattern"></a><span data-ttu-id="cc469-112">適切なパターンの選択</span><span class="sxs-lookup"><span data-stu-id="cc469-112">Is this the right pattern?</span></span>

<span data-ttu-id="cc469-113">ユーザーが定期的に更新するデータのリストやグリッドがあり、アプリがモバイルやタッチ操作主体のデバイスで実行されることが多いときは、引っ張って更新パターンを使います。</span><span class="sxs-lookup"><span data-stu-id="cc469-113">Use the pull-to-refresh pattern when you have a list or grid of data that the user might want to refresh regularly, and your app is likely to be running on mobile, touch-first devices.</span></span>

## <a name="implement-pull-to-refresh"></a><span data-ttu-id="cc469-114">引っ張って更新を実装する</span><span class="sxs-lookup"><span data-stu-id="cc469-114">Implement pull-to-refresh</span></span>

<span data-ttu-id="cc469-115">引っ張って更新を実装するには、操作イベントを処理してユーザーがリストを下に引っ張ったときに検出し、視覚的なフィードバックを表示し、データを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc469-115">To implement pull-to-refresh, you need to handle manipulation events to detect when a user has pulled the list down, provide visual feedback, and refresh the data.</span></span> <span data-ttu-id="cc469-116">ここでは、「[引っ張って更新のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620635)」でこれらがどのように行われているかを見ていきます。</span><span class="sxs-lookup"><span data-stu-id="cc469-116">Here, we look at how this is done in the [pull-to-refresh sample](http://go.microsoft.com/fwlink/p/?LinkId=620635).</span></span> <span data-ttu-id="cc469-117">ここではすべてのコードを示さないため、GitHub でサンプルをダウンロードするか、コードを表示してください。</span><span class="sxs-lookup"><span data-stu-id="cc469-117">We don't show all the code here, so you should download the sample or view the code on GitHub.</span></span>

<span data-ttu-id="cc469-118">引っ張って更新のサンプルでは、**ListView** コントロールを拡張するカスタム コントロール `RefreshableListView` を作成します。</span><span class="sxs-lookup"><span data-stu-id="cc469-118">The pull-to-refresh sample creates a custom control called `RefreshableListView` that extends the **ListView** control.</span></span> <span data-ttu-id="cc469-119">このコントロールは、更新インジケーターを追加して視覚的なフィードバックを表示し、リスト ビューの内部スクロール ビューアーに対する操作イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="cc469-119">This control adds a refresh indicator to provide visual feedback and handles the manipulation events on the list view's internal scroll viewer.</span></span> <span data-ttu-id="cc469-120">また、リストが引っ張られたときとデータを更新する必要があるときに通知する 2 つのイベントを追加します。</span><span class="sxs-lookup"><span data-stu-id="cc469-120">It also adds 2 events to notify you when the list is pulled and when the data should be refreshed.</span></span> <span data-ttu-id="cc469-121">RefreshableListView は、データを更新する必要があることだけを通知します。</span><span class="sxs-lookup"><span data-stu-id="cc469-121">RefreshableListView only provides notification that the data should be refreshed.</span></span> <span data-ttu-id="cc469-122">アプリでイベントを処理してデータを更新する必要があります。そのコードはアプリごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="cc469-122">You need to handle the event in your app to update the data, and that code will be different for every app.</span></span>

<span data-ttu-id="cc469-123">RefreshableListView は、更新が必要な時期と更新インジケーターを非表示にする方法を判断する "自動更新" モードを提供します。</span><span class="sxs-lookup"><span data-stu-id="cc469-123">RefreshableListView provides an 'auto refresh' mode that determines when the refresh is requested and how the refresh indicator goes out of view.</span></span> <span data-ttu-id="cc469-124">自動更新はオンまたはオフにできます。</span><span class="sxs-lookup"><span data-stu-id="cc469-124">Auto refresh can be on or off.</span></span>
- <span data-ttu-id="cc469-125">オフ: `PullThreshold` を超えている間にリストがリリースされる場合にのみ更新が要求されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-125">Off: A refresh is requested only if the list is released while the `PullThreshold` is exceded.</span></span> <span data-ttu-id="cc469-126">ユーザーがスクロール領域から離れると、インジケーターがアニメーション化されて非表示になります。</span><span class="sxs-lookup"><span data-stu-id="cc469-126">The indicator animates out of view when the user releases the scroller.</span></span> <span data-ttu-id="cc469-127">利用可能な場合、ステータス バー インジケーターが表示されます (電話)。</span><span class="sxs-lookup"><span data-stu-id="cc469-127">The status bar indicator is shown if it's available (on phone).</span></span>
- <span data-ttu-id="cc469-128">点灯: `PullThreshold` を超えると、リリースされるかどうかにかかわらずすぐに更新が要求されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-128">On: A refresh is requested as soon as the `PullThreshold` is exceded, whether released or not.</span></span> <span data-ttu-id="cc469-129">インジケーターは新しいデータが取得されるまで表示されたままで、その後、アニメーション化されて非表示になります。</span><span class="sxs-lookup"><span data-stu-id="cc469-129">The indicator remains in view until the new data is retrieved, then animates out of view.</span></span> <span data-ttu-id="cc469-130">データの取得が完了すると、**Deferral** を使ってアプリに通知されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-130">A **Deferral** is used to notify the app when fetching the data is complete.</span></span>

> <span data-ttu-id="cc469-131">**注**&nbsp;&nbsp;サンプルのコードは、[GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) にも適用されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-131">**Note**&nbsp;&nbsp;The code in sample is also applicable to a [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx).</span></span> <span data-ttu-id="cc469-132">GridView を変更するには、ListView ではなく GridView からカスタム クラスを派生し、GridView の既定のテンプレートを変更します。</span><span class="sxs-lookup"><span data-stu-id="cc469-132">To modify a GridView, derive the custom class from GridView instead of ListView and modify the default GridView template.</span></span>

## <a name="add-a-refresh-indicator"></a><span data-ttu-id="cc469-133">更新インジケーターを追加する</span><span class="sxs-lookup"><span data-stu-id="cc469-133">Add a refresh indicator</span></span>

<span data-ttu-id="cc469-134">アプリが引っ張って更新をサポートしていることがユーザーにわかるように、視覚的なフィードバックを表示することが重要です。</span><span class="sxs-lookup"><span data-stu-id="cc469-134">It's important to provide visual feedback to the user so they know that your app supports pull-to-refresh.</span></span> <span data-ttu-id="cc469-135">RefreshableListView には、XAML でインジケーターを表示するように設定できる `RefreshIndicatorContent` プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="cc469-135">RefreshableListView has a `RefreshIndicatorContent` property that lets you set the indicator visual in your XAML.</span></span> <span data-ttu-id="cc469-136">また、`RefreshIndicatorContent` を設定しない場合にフォールバックする既定のテキスト インジケータも含まれています。</span><span class="sxs-lookup"><span data-stu-id="cc469-136">It also includes a default text indicator that it falls back to if you don't set the `RefreshIndicatorContent`.</span></span>

<span data-ttu-id="cc469-137">以下に、更新インジケーターの推奨ガイドラインを示します。</span><span class="sxs-lookup"><span data-stu-id="cc469-137">Here are recommended guidelines for the refresh indicator.</span></span>

![更新インジケーターのガイドライン](images/ptr-redlines-1.png)

**<span data-ttu-id="cc469-139">リスト ビューのテンプレートを変更する</span><span class="sxs-lookup"><span data-stu-id="cc469-139">Modify the list view template</span></span>**

<span data-ttu-id="cc469-140">引っ張って更新のサンプルでは、更新インジケーターを追加することで、`RefreshableListView` コントロールのテンプレートが標準の **ListView** テンプレートを変更しています。</span><span class="sxs-lookup"><span data-stu-id="cc469-140">In the pull-to-refresh sample, the `RefreshableListView` control template modifies the standard **ListView** template by adding a refresh indicator.</span></span> <span data-ttu-id="cc469-141">更新インジケーターは、[ItemsPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemspresenter.aspx) の上の [Grid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.aspx) に配置されます。これはリスト項目が表示される部分です。</span><span class="sxs-lookup"><span data-stu-id="cc469-141">The refresh indicator is placed in a [Grid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.aspx) above the [ItemsPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemspresenter.aspx), which is the part that shows the list items.</span></span>

> <span data-ttu-id="cc469-142">**注意**&nbsp;&nbsp;`DefaultRefreshIndicatorContent` テキスト ボックスは、`RefreshIndicatorContent` プロパティが設定されていない場合にのみ表示されるテキストのフォールバック インジケーターを提供します。</span><span class="sxs-lookup"><span data-stu-id="cc469-142">**Note**&nbsp;&nbsp;The `DefaultRefreshIndicatorContent` text box provides a text fallback indicator that is shown only if the `RefreshIndicatorContent` property is not set.</span></span>

<span data-ttu-id="cc469-143">次に、ListView の既定のテンプレートから変更されたコントロール テンプレートの一部を示します。</span><span class="sxs-lookup"><span data-stu-id="cc469-143">Here's the part of the control template that's modified from the default ListView template.</span></span>

**<span data-ttu-id="cc469-144">XAML</span><span class="sxs-lookup"><span data-stu-id="cc469-144">XAML</span></span>**
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

**<span data-ttu-id="cc469-145">XAML でコンテンツを設定する</span><span class="sxs-lookup"><span data-stu-id="cc469-145">Set the content in XAML</span></span>**

<span data-ttu-id="cc469-146">リスト ビュー用の XAML で、更新インジケーターのコンテンツを設定します。</span><span class="sxs-lookup"><span data-stu-id="cc469-146">You set the content of the refresh indicator in the XAML for your list view.</span></span> <span data-ttu-id="cc469-147">設定する XAML コンテンツは、更新インジケーターの [ContentPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentpresenter.aspx) (`<ContentPresenter Content="{TemplateBinding RefreshIndicatorContent}">`) によって表示されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-147">The XAML content you set is displayed by the refresh indicator's [ContentPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentpresenter.aspx) (`<ContentPresenter Content="{TemplateBinding RefreshIndicatorContent}">`).</span></span> <span data-ttu-id="cc469-148">このコンテンツを設定しない場合、代わりに既定のテキスト インジケータが表示されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-148">If you don't set this content, the default text indicator is shown instead.</span></span>

**<span data-ttu-id="cc469-149">XAML</span><span class="sxs-lookup"><span data-stu-id="cc469-149">XAML</span></span>**
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

**<span data-ttu-id="cc469-150">スピンをアニメーション化する</span><span class="sxs-lookup"><span data-stu-id="cc469-150">Animate the spinner</span></span>**

<span data-ttu-id="cc469-151">リストが引き下げられると、RefreshableListView の `PullProgressChanged` イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="cc469-151">When the list is pulled down, RefreshableListView's `PullProgressChanged` event occurs.</span></span> <span data-ttu-id="cc469-152">アプリでこのイベントを処理して、更新インジケーターを制御します。</span><span class="sxs-lookup"><span data-stu-id="cc469-152">You handle this event in your app to control the refresh indicator.</span></span> <span data-ttu-id="cc469-153">サンプルでは、このストーリー ボードはインジケーターの [RotateTransform](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.rotatetransform.aspx) をアニメーション化し、更新インジケーターを回転させます。</span><span class="sxs-lookup"><span data-stu-id="cc469-153">In the sample, this storyboard is started to animate the indicator's [RotateTransform](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.rotatetransform.aspx) and spin the refresh indicator.</span></span> 

**<span data-ttu-id="cc469-154">XAML</span><span class="sxs-lookup"><span data-stu-id="cc469-154">XAML</span></span>**
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

## <a name="handle-scroll-viewer-manipulation-events"></a><span data-ttu-id="cc469-155">スクロール ビューアー操作イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="cc469-155">Handle scroll viewer manipulation events</span></span>

<span data-ttu-id="cc469-156">リスト ビュー コントロールのテンプレートには、ユーザーがリスト項目をスクロールできるようにする組み込みの [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="cc469-156">The list view control template includes a built-in [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) that lets a user scroll through the list items.</span></span> <span data-ttu-id="cc469-157">引っ張って更新を実装するには、いくつかの関連するイベントのほか、組み込みのスクロール ビューアーでの操作イベントを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc469-157">To implement pull-to-refresh, you have to handle the manipulation events on the built-in scroll viewer, as well as several related events.</span></span> <span data-ttu-id="cc469-158">操作イベントについて詳しくは、「[タッチ操作](../input-and-devices/touch-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cc469-158">For more info about manipulation events, see [Touch interactions](../input-and-devices/touch-interactions.md).</span></span>

<span data-ttu-id="cc469-159">** OnApplyTemplate**</span><span class="sxs-lookup"><span data-stu-id="cc469-159">** OnApplyTemplate**</span></span>

<span data-ttu-id="cc469-160">スクロール ビューアーおよびその他のテンプレート パーツにアクセスして、イベント ハンドラーを追加してそれらを後でコードで呼び出せるようにするには、[OnApplyTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.onapplytemplate.aspx) メソッドをオーバーライドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc469-160">To get access to the scroll viewer and other template parts so that you can add event handlers and call them later in your code, you must override the [OnApplyTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.onapplytemplate.aspx) method.</span></span> <span data-ttu-id="cc469-161">OnApplyTemplate で、[GetTemplateChild](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.gettemplatechild.aspx) を呼び出してコントロール テンプレートの名前付きパーツへの参照を取得します。これはコードの後半で使用できるように保存できます。</span><span class="sxs-lookup"><span data-stu-id="cc469-161">In OnApplyTemplate, you call [GetTemplateChild](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.gettemplatechild.aspx) to get a reference to a named part in the control template, which you can save to use later in your code.</span></span>

<span data-ttu-id="cc469-162">サンプルでは、テンプレート パーツを格納するために使う変数はプライベート変数領域で宣言されています。</span><span class="sxs-lookup"><span data-stu-id="cc469-162">In the sample, the variables used to store the template parts are declared in the Private Variables region.</span></span> <span data-ttu-id="cc469-163">OnApplyTemplate メソッドでそれらを取得した後、[DirectManipulationStarted](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.directmanipulationstarted.aspx)、[DirectManipulationCompleted](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.directmanipulationcompleted.aspx)、[ViewChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.viewchanged.aspx)、および [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントのイベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="cc469-163">After they are retrieved in the OnApplyTemplate method, event handlers are added for the [DirectManipulationStarted](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.directmanipulationstarted.aspx), [DirectManipulationCompleted](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.directmanipulationcompleted.aspx), [ViewChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.viewchanged.aspx), and [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) events.</span></span>

**<span data-ttu-id="cc469-164">DirectManipulationStarted</span><span class="sxs-lookup"><span data-stu-id="cc469-164">DirectManipulationStarted</span></span>**

<span data-ttu-id="cc469-165">引っ張って更新アクションを開始するには、ユーザーが引き下げ始めるときに、コンテンツがスクロール ビューアーの一番上にスクロールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc469-165">In order to initiate a pull-to-refresh action, the content has to be scrolled to the top of the scroll viewer when the user starts to pull down.</span></span> <span data-ttu-id="cc469-166">そうでない場合は、リスト内で上にパンするために引っ張っていると見なされます。</span><span class="sxs-lookup"><span data-stu-id="cc469-166">Otherwise, it's assumed that the user is pulling in order to pan up in the list.</span></span> <span data-ttu-id="cc469-167">このハンドラーのコードは、操作がスクロール ビューアーの一番上のコンテンツから開始されたかどうかを判断します。その結果、リストが更新されることがあります。</span><span class="sxs-lookup"><span data-stu-id="cc469-167">The code in this handler determines whether the manipulation started with the content at the top of the scroll viewer, and can result in the list being refreshed.</span></span> <span data-ttu-id="cc469-168">それに応じて、コントロールの '更新可能' 状態が設定されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-168">The control's 'refreshable' status is set accordingly.</span></span> 

<span data-ttu-id="cc469-169">コントロールが更新可能な場合、アニメーションのイベント ハンドラーも追加されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-169">If the control can be refreshed, event handlers for animations are also added.</span></span>

**<span data-ttu-id="cc469-170">DirectManipulationCompleted</span><span class="sxs-lookup"><span data-stu-id="cc469-170">DirectManipulationCompleted</span></span>**

<span data-ttu-id="cc469-171">ユーザーがリストを引き下げることを停止したら、このハンドラーのコードは、操作中に更新がアクティブ化されたかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="cc469-171">When the user stops pulling the list down, the code in this handler checks whether a refresh was activated during the manipulation.</span></span> <span data-ttu-id="cc469-172">更新がアクティブ化された場合、`RefreshRequested` イベントが発生し、`RefreshCommand` コマンドが実行されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-172">If a refresh was activated, the `RefreshRequested` event is raised and the `RefreshCommand` command is executed.</span></span>

<span data-ttu-id="cc469-173">アニメーションのイベント ハンドラーも削除されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-173">The event handlers for animations are also removed.</span></span>

<span data-ttu-id="cc469-174">`AutoRefresh` プロパティの値に基づいて、リストはすぐにアニメーション化に戻るか、更新が完了するのを待ってからアニメーション化に戻ります。</span><span class="sxs-lookup"><span data-stu-id="cc469-174">Based on the value of the `AutoRefresh` property, the list can animate back up immediately, or wait until the refresh is complete and then animate back up.</span></span> <span data-ttu-id="cc469-175">[Deferral](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.aspx) オブジェクトを使って、更新の完了をマークします。</span><span class="sxs-lookup"><span data-stu-id="cc469-175">A [Deferral](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.aspx) object is used to to mark the completion of the refresh.</span></span> <span data-ttu-id="cc469-176">その時点で、更新インジケーター UI は非表示です。</span><span class="sxs-lookup"><span data-stu-id="cc469-176">At that point the refresh indicator UI is hidden.</span></span>

<span data-ttu-id="cc469-177">DirectManipulationCompleted イベント ハンドラーのこの部分で `RefreshRequested`イベントを発生させ、必要な場合は Deferral を取得します。</span><span class="sxs-lookup"><span data-stu-id="cc469-177">This part of the DirectManipulationCompleted event handler raises the `RefreshRequested` event and get's the Deferral if needed.</span></span>

**<span data-ttu-id="cc469-178">C#</span><span class="sxs-lookup"><span data-stu-id="cc469-178">C#</span></span>**
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

**<span data-ttu-id="cc469-179">ViewChanged</span><span class="sxs-lookup"><span data-stu-id="cc469-179">ViewChanged</span></span>**

<span data-ttu-id="cc469-180">2 つのケースが ViewChanged イベント ハンドラーで処理されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-180">Two cases are handled in the ViewChanged event handler.</span></span>

<span data-ttu-id="cc469-181">1 つ目に、スクロール ビューアーのズームによりビューが変更された場合、コントロールの "更新可能な" 状態がキャンセルされます。</span><span class="sxs-lookup"><span data-stu-id="cc469-181">First, if the view changed due to the scroll viewer zooming, the control's 'refreshable' status is canceled.</span></span>

<span data-ttu-id="cc469-182">2 つ目に、自動更新の最後にコンテンツのアニメーション化が完了した場合、パディングの四角形が非表示になって、スクロール ビューアーによるタッチ操作が再び有効になり、[VerticalOffset](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticaloffset.aspx) が 0 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-182">Second, if the content finished animating up at the end of an auto refresh, the padding rectangles are hidden, touch interactions with the scroll viewer are re-anabled, the [VerticalOffset](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticaloffset.aspx) is set to 0.</span></span>

**<span data-ttu-id="cc469-183">PointerPressed</span><span class="sxs-lookup"><span data-stu-id="cc469-183">PointerPressed</span></span>**

<span data-ttu-id="cc469-184">引っ張って更新が行われるのは、タッチ操作によってリストが引き下げられたときだけです。</span><span class="sxs-lookup"><span data-stu-id="cc469-184">Pull-to-refresh happens only when the list is pulled down by a touch manipulation.</span></span> <span data-ttu-id="cc469-185">PointerPressed イベント ハンドラーで、どの種類のポインターがイベントを発生させたかをチェックし、それがタッチ ポインターであったかどうかを示す変数 (`m_pointerPressed`) を設定します。</span><span class="sxs-lookup"><span data-stu-id="cc469-185">In the PointerPressed event handler, the code checks what kind of pointer caused the event and sets a variable (`m_pointerPressed`) to indicate whether it was a touch pointer.</span></span> <span data-ttu-id="cc469-186">この変数は DirectManipulationStarted ハンドラーで使われます。</span><span class="sxs-lookup"><span data-stu-id="cc469-186">This variable is used in the DirectManipulationStarted handler.</span></span> <span data-ttu-id="cc469-187">ポインターがタッチ ポインターでない場合は、DirectManipulationStarted ハンドラーは何もせずに戻ります。</span><span class="sxs-lookup"><span data-stu-id="cc469-187">If the pointer is not a touch pointer, the DirectManipulationStarted handler returns without doing anything.</span></span>

## <a name="add-pull-and-refresh-events"></a><span data-ttu-id="cc469-188">引っ張って更新のイベントを追加する</span><span class="sxs-lookup"><span data-stu-id="cc469-188">Add pull and refresh events</span></span>

<span data-ttu-id="cc469-189">'RefreshableListView' は 2 つのイベントを追加します。これらをアプリで処理して、データを更新し、更新インジケーターを管理することができます。</span><span class="sxs-lookup"><span data-stu-id="cc469-189">'RefreshableListView' adds 2 events that you can handle in your app to refresh the data and manage the refresh indicator.</span></span>

<span data-ttu-id="cc469-190">イベントについて詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/windows/uwp/xaml-platform/events-and-routed-events-overview)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cc469-190">For more info about events, see [Events and routed events overview](https://msdn.microsoft.com/windows/uwp/xaml-platform/events-and-routed-events-overview).</span></span>

**<span data-ttu-id="cc469-191">RefreshRequested</span><span class="sxs-lookup"><span data-stu-id="cc469-191">RefreshRequested</span></span>**

<span data-ttu-id="cc469-192">'RefreshRequested' イベントは、ユーザーがリストを更新するために引っ張ったことをアプリに通知します。</span><span class="sxs-lookup"><span data-stu-id="cc469-192">The 'RefreshRequested' event notifies your app that the user has pulled the list to refresh it.</span></span> <span data-ttu-id="cc469-193">このイベントを処理して、新しいデータを取得し、リストを更新します。</span><span class="sxs-lookup"><span data-stu-id="cc469-193">You handle this event to fetch new data and update your list.</span></span>

<span data-ttu-id="cc469-194">サンプルのイベント ハンドラーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="cc469-194">Here's the event handler from the sample.</span></span> <span data-ttu-id="cc469-195">重要なのは、リスト ビューの `AutoRefresh` プロパティを確認し、**true** の場合は Deferral を取得することです。</span><span class="sxs-lookup"><span data-stu-id="cc469-195">The important thing to notice is that it check's the list view's `AutoRefresh` property and get's a Deferral if it's **true**.</span></span> <span data-ttu-id="cc469-196">Deferral を使うと、更新インジケーターは停止せず、更新が完了するまで非表示になります。</span><span class="sxs-lookup"><span data-stu-id="cc469-196">With a Deferral, the refresh indicator is not stopped and hidden until the refresh is complete.</span></span>

**<span data-ttu-id="cc469-197">C#</span><span class="sxs-lookup"><span data-stu-id="cc469-197">C#</span></span>**
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

**<span data-ttu-id="cc469-198">PullProgressChanged</span><span class="sxs-lookup"><span data-stu-id="cc469-198">PullProgressChanged</span></span>**

<span data-ttu-id="cc469-199">サンプルでは、アプリによって更新インジケーターのコンテンツが提供および制御されます。</span><span class="sxs-lookup"><span data-stu-id="cc469-199">In the sample, content for the refresh indicator is provided and controlled by the app.</span></span> <span data-ttu-id="cc469-200">更新インジケーターを起動、停止、およびをリセットできるように、ユーザーがリストを引っ張ったことを 'PullProgressChanged' イベントが通知します。</span><span class="sxs-lookup"><span data-stu-id="cc469-200">The 'PullProgressChanged' event notifies your app when the use is pulling the list so that you can start, stop, and reset the refresh indicator.</span></span> 

## <a name="composition-animations"></a><span data-ttu-id="cc469-201">コンポジションのアニメーション</span><span class="sxs-lookup"><span data-stu-id="cc469-201">Composition animations</span></span>

<span data-ttu-id="cc469-202">既定では、スクロール バーが一番上に達するとスクロール ビューアーのコンテンツは停止します。</span><span class="sxs-lookup"><span data-stu-id="cc469-202">By default, content in a scroll viewer stops when the scrollbar reaches the top.</span></span> <span data-ttu-id="cc469-203">ユーザーがリストを引き下げ続けられるようにするには、ビジュアル レイヤーにアクセスし、リストのコンテンツをアニメーション化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc469-203">To let the user continue to pull the list down, you need to access the visual layer and animate the list content.</span></span> <span data-ttu-id="cc469-204">サンプルでは、このために[コンポジション アニメーション](https://msdn.microsoft.com/windows/uwp/composition/composition-animation)、具体的には[数式アニメーション](https://msdn.microsoft.com/windows/uwp/composition/composition-animation#expression-animations)を使います。</span><span class="sxs-lookup"><span data-stu-id="cc469-204">The sample uses [composition animations](https://msdn.microsoft.com/windows/uwp/composition/composition-animation) for this; specifically, [expression animations](https://msdn.microsoft.com/windows/uwp/composition/composition-animation#expression-animations).</span></span>

<span data-ttu-id="cc469-205">サンプルでは、主に `CompositionTarget_Rendering` イベント ハンドラーと `UpdateCompositionAnimations` メソッドがこの処理を行います。</span><span class="sxs-lookup"><span data-stu-id="cc469-205">In the sample, this work is done primarily in the `CompositionTarget_Rendering` event handler and the `UpdateCompositionAnimations` method.</span></span>

## <a name="related-articles"></a><span data-ttu-id="cc469-206">関連記事</span><span class="sxs-lookup"><span data-stu-id="cc469-206">Related articles</span></span>

- [<span data-ttu-id="cc469-207">コントロールのスタイル</span><span class="sxs-lookup"><span data-stu-id="cc469-207">Styling controls</span></span>](styling-controls.md)
- [<span data-ttu-id="cc469-208">タッチ操作</span><span class="sxs-lookup"><span data-stu-id="cc469-208">Touch interactions</span></span>](../input-and-devices/touch-interactions.md)
- [<span data-ttu-id="cc469-209">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="cc469-209">List view and grid view</span></span>](listview-and-gridview.md)
- [<span data-ttu-id="cc469-210">リスト ビュー項目テンプレート</span><span class="sxs-lookup"><span data-stu-id="cc469-210">List view item templates</span></span>](listview-item-templates.md)
- [<span data-ttu-id="cc469-211">数式アニメーション</span><span class="sxs-lookup"><span data-stu-id="cc469-211">Expression animations</span></span>](https://msdn.microsoft.com/windows/uwp/composition/composition-animation#expression-animations)