---
author: Jwmsft
Description: Use the pull-to-refresh control to get new content into a list.
title: 引っ張って更新
label: Pull-to-refresh
template: detail.hbs
ms.author: jimwalk
ms.date: 03/07/2018
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: aaeb1e74-b795-4015-bf41-02cb1d6f467e
pm-contact: predavid
design-contact: kimsea
dev-contact: stpete
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 8b1dd6bd1bc165a79ba123c94e63e1dcfa58ec21
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5687818"
---
# <a name="pull-to-refresh"></a>引っ張って更新

引っ張って更新を使うと、タッチ操作でデータの一覧を引き下げることで、より多くのデータを取得できます。 引っ張って更新は、タッチ スクリーンを備えたデバイスで広く使用されます。 ここに表示されている API を使用して、アプリに引っ張って更新を実装できます。

> **重要な API**: [RefreshContainer](/uwp/api/windows.ui.xaml.controls.refreshcontainer)、[RefreshVisualizer](/uwp/api/windows.ui.xaml.controls.refreshvisualizer)

![引っ張って更新 gif](images/Pull-To-Refresh.gif)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ユーザーが定期的に更新するデータのリストやグリッドがあり、アプリがタッチ操作主体のデバイスで実行されることが多いときは、引っ張って更新を使います。

[RefreshVisualizer](/uwp/api/windows.ui.xaml.controls.refreshvisualizer) を使用して、更新ボタンなど他の方法で呼び出される一貫した更新エクスペリエンスを作成することもできます。

## <a name="refresh-controls"></a>更新コントロール

引っ張って更新は、2 つのコントロールで有効になっています。

- **RefreshContainer** - 引っ張って更新エクスペリエンスのラッパーを提供する ContentControl。 これは、タッチ操作を処理し、その内部更新ビジュアライザーの状態を管理します。
- **RefreshVisualizer** - 次のセクションで説明されている更新の視覚エフェクトをカプセル化します。

メインのコントロールは、ユーザーが更新をトリガするためにプルするコンテンツ全体のラッパーとして配置する **RefreshContainer** です。 RefreshContainer はタッチでのみ機能するため、タッチ インターフェイスを持たないユーザーが使用できる更新ボタンを設定することをお勧めします。 更新ボタンは、コマンド バーまたは更新されるサーフェスに近い場所など、アプリの適切な場所に配置できます。

## <a name="refresh-visualization"></a>更新の視覚エフェクト

既定の更新の視覚エフェクトは、更新が発生したときに通信するために使用される循環進行スピンと、更新が開始された後の更新の進行状況です。 更新ビジュアライザーには、5 つの状態があります。

 ユーザーが更新を開始するために一覧でプル ダウンする必要がある距離を_しきい値_といいます。 ビジュアライザー[状態](/uwp/api/windows.ui.xaml.controls.refreshvisualizer.State) は、このしきい値に関連するプル状態によって決まります。 使用可能な値は、[RefreshVisualizerState](/uwp/api/windows.ui.xaml.controls.refreshvisualizerstate) 列挙に含まれています。

### <a name="idle"></a>アイドル

ビジュアライザーの既定の状態は**アイドル**です。 ユーザーはタッチを介して RefreshContainer と対話しておらず、実行中の更新はありません。

視覚的に、更新ビジュアライザーの証拠はありません。

### <a name="interacting"></a>操作中

ユーザーが PullDirection プロパティで指定された方向にリストをプルすると、しきい値に達する前にビジュアライザーは**対話**状態になります。

- この状態でユーザーがコントロールを離すと、コントロールは**アイドル**に戻ります。

    ![引っ張って更新の事前しきい値](images/ptr-prethreshold.png)

    視覚的に、アイコンは無効 (60% の不透明度) として表示されます。 さらに、アイコンはスクロールの操作で 1 回転します。

- ユーザーがしきい値を超えてリストをプルすると、ビジュアライザーは**操作中**から**保留中**に切り替わります。

    ![しきい値にある引っ張って更新](images/ptr-atthreshold.png)

    視覚的に、アイコンが 100% の不透明度に切り替わり、切り替えの過程でサイズは最大 150％ になり、その後 100％ に戻ります。

### <a name="pending"></a>保留中

ユーザーがしきい値を超えてリストをプルした場合、ビジュアライザーは**保留中**状態になります。

- ユーザーがリストを解放せずにしきい値を超えて戻すと、**操作中**状態に戻ります。
- ユーザーがリストを解放すると、更新要求が開始され、**更新中**状態に切り替わります。

![引っ張って更新の事後しきい値](images/ptr-postthreshold.png)

図で表すと、アイコンはサイズと不透明度のどちらも 100% になります。 この状態では、アイコンはスクロール操作で下に移動し続けますが、回転することはありません。

### <a name="refreshing"></a>更新しています

ユーザーがしきい値を超えてビジュアライザーを解放すると、**更新中**状態になります。

この状態に入ると、**RefreshRequested** イベントが発生します。 これは、アプリのコンテンツの更新を開始する信号です。 イベントの引数 ([RefreshRequestedEventArgs](/uwp/api/windows.ui.xaml.controls.refreshrequestedeventargs)) には、イベント ハンドラーでハンドルを取得する必要がある [Deferral](/uwp/api/windows.foundation.deferral) オブジェクトが含まれています。 その後、更新を実行するコードが完了した時点で、延期を完了とマークする必要があります。

更新が完了すると、ビジュアライザーは**アイドル**状態に戻ります。

図で表すと、アイコンはしきい値の位置に戻り、更新の期間中回転します。 この回転は、更新の進行状況を表示するために使用され、受信したコンテンツのアニメーションによって置き換えられます。

### <a name="peeking"></a>ピーク

ユーザーが、更新が許可されていない開始位置から更新方向でプルすると、ビジュアライザーは**ピーク**状態に入ります。 これは通常、ユーザーがプルを開始したときに ScrollViewer が 0 の位置にない場合に発生します。

- この状態でユーザーがコントロールを離すと、コントロールは**アイドル**に戻ります。

## <a name="pull-direction"></a>プルの方向

既定では、ユーザーはリストを上から下へプルして更新を開始します。 リストまたはグリッドの方向が異なる場合は、更新コンテナーのプル方向を変更して一致させる必要があります。

[PullDirection](/uwp/api/windows.ui.xaml.controls.refreshcontainer.PullDirection) プロパティは、次の [RefreshPullDirection](/uwp/api/windows.ui.xaml.controls.refreshpulldirection) 値のいずれかを取ります。**BottomToTop**、**TopToBottom**、**RightToLeft**、または **LeftToRight**。

プルの方向を変更すると、ビジュアライザーの進行スピンの開始位置は、プルの方向に適した位置で矢印が起動するように自動的に回転します。 必要に応じて、[RefreshVisualizer.Orientation](/uwp/api/windows.ui.xaml.controls.refreshvisualizer.Orientation) プロパティを変更して自動の動作をオーバーライドできます。 ほとんどの場合、既定値の**自動**のままにしておくことをお勧めします。

## <a name="implement-pull-to-refresh"></a>引っ張って更新を実装する

引っ張って更新機能をリストに追加するにはいくつかの手順が必要です。

1. **RefreshContainer** コントロールでリストを折り返します。
1. **RefreshRequested** イベントを処理してコンテンツを更新します。
1. 必要に応じて、**RequestRefresh** (たとえば、ボタンのクリックで) を呼び出して更新を開始します。

> [!NOTE]
> 単体で RefreshVisualizer をインスタンス化することができます。 ただし、タッチ非対応シナリオに対しても、コンテンツを RefreshContainer で折り返し、RefreshContainer.Visualizer プロパティによって提供される RefreshVisualizer を使用することをお勧めします。 この記事では、ビジュアライザーが常に更新コンテナーから取得されることを前提としています。

> さらに便宜上、更新コンテナーの RequestRefresh と RefreshRequested メンバーを使用します。 `refreshContainer.RequestRefresh()` `refreshContainer.Visualizer.RequestRefresh()` に相当し、いずれかで RefreshContainer.RefreshRequested イベントと RefreshVisualizer.RefreshRequested イベントの両方が発生します。

### <a name="request-a-refresh"></a>更新の要求

更新コンテナーは、ユーザーがタッチ経由でコンテンツを更新するためのタッチ操作を処理します。 更新ボタンまたは音声コントロールなど、タッチ非対応インターフェイス用の他のアフォーダンスを提供することをお勧めします。

更新を開始するには、[RequestRefresh](/uwp/api/windows.ui.xaml.controls.refreshcontainer.RequestRefresh) メソッドを呼び出します。

```csharp
// See the Examples section for the full code.
private void RefreshButtonClick(object sender, RoutedEventArgs e)
{
    RefreshContainer.RequestRefresh();
}
```

RequestRefresh を呼び出すと、ビジュアライザーの状態は直接**アイドル状態**から**更新中**に切り替わります。

### <a name="handle-a-refresh-request"></a>更新要求の処理

必要に応じて新しいコンテンツを取得するには、RefreshRequested イベントを処理します。 イベント ハンドラーで、新しいコンテンツを取得するアプリに固有のコードが必要です。

イベントの引数 ([RefreshRequestedEventArgs](/uwp/api/windows.ui.xaml.controls.refreshrequestedeventargs)) には、[Deferral](/uwp/api/windows.foundation.deferral) オブジェクトが含まれています。 イベント ハンドラーで、延期へのハンドルを取得します。 その後、更新を実行するコードが完了した時点で、延期を完了とマークします。

```csharp
// See the Examples section for the full code.
private async void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
{
    // Respond to a request by performing a refresh and using the deferral object.
    using (var RefreshCompletionDeferral = args.GetDeferral())
    {
        // Do some async operation to refresh the content

         await FetchAndInsertItemsAsync(3);

        // The 'using' statement ensures the deferral is marked as complete.
        // Otherwise, you'd call
        // RefreshCompletionDeferral.Complete();
        // RefreshCompletionDeferral.Dispose();
    }
}
```

### <a name="respond-to-state-changes"></a>状態の変更への対応

必要に応じて、ビジュアライザーの状態の変更に対応できます。 たとえば、複数の更新要求を防ぐために、ビジュアライザーが更新中は更新ボタンを無効にできます。

```csharp
// See the Examples section for the full code.
private void Visualizer_RefreshStateChanged(RefreshVisualizer sender, RefreshStateChangedEventArgs args)
{
    // Respond to visualizer state changes.
    // Disable the refresh button if the visualizer is refreshing.
    if (args.NewState == RefreshVisualizerState.Refreshing)
    {
        RefreshButton.IsEnabled = false;
    }
    else
    {
        RefreshButton.IsEnabled = true;
    }
}
```

## <a name="examples"></a>例

### <a name="using-a-scrollviewer-in-a-refreshcontainer"></a>RefreshContainer での ScrollViewer の使用

この例では、スクロール ビューアーで引っ張って更新を使用する方法を示します。

```xaml
<RefreshContainer>
    <ScrollViewer VerticalScrollMode="Enabled"
                  VerticalScrollBarVisibility="Auto"
                  HorizontalScrollBarVisibility="Auto">
 
        <!-- Scrollviewer content -->

    </ScrollViewer>
</RefreshContainer>
```

### <a name="adding-pull-to-refresh-to-a-listview"></a>ListView に引っ張って更新を追加する

この例では、リスト ビューで引っ張って更新を使用する方法を示します。

```xaml
<StackPanel Margin="0,40" Width="280">
    <CommandBar OverflowButtonVisibility="Collapsed">
        <AppBarButton x:Name="RefreshButton" Click="RefreshButtonClick"
                      Icon="Refresh" Label="Refresh"/>
        <CommandBar.Content>
            <TextBlock Text="List of items" 
                       Style="{StaticResource TitleTextBlockStyle}"
                       Margin="12,8"/>
        </CommandBar.Content>
    </CommandBar>

    <RefreshContainer x:Name="RefreshContainer">
        <ListView x:Name="ListView1" Height="400">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:ListItemData">
                    <Grid Height="80">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="*" />
                        </Grid.RowDefinitions>
                        <TextBlock Text="{x:Bind Path=Header}"
                                   Style="{StaticResource SubtitleTextBlockStyle}"
                                   Grid.Row="0"/>
                        <TextBlock Text="{x:Bind Path=Date}"
                                   Style="{StaticResource CaptionTextBlockStyle}"
                                   Grid.Row="1"/>
                        <TextBlock Text="{x:Bind Path=Body}"
                                   Style="{StaticResource BodyTextBlockStyle}"
                                   Grid.Row="2"
                                   Margin="0,4,0,0" />
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </RefreshContainer>
</StackPanel>
```

```csharp
public sealed partial class MainPage : Page
{
    public ObservableCollection<ListItemData> Items { get; set; } 
        = new ObservableCollection<ListItemData>();

    public MainPage()
    {
        this.InitializeComponent();

        Loaded += MainPage_Loaded;
        ListView1.ItemsSource = Items;
    }

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        Loaded -= MainPage_Loaded;
        RefreshContainer.RefreshRequested += RefreshContainer_RefreshRequested;
        RefreshContainer.Visualizer.RefreshStateChanged += Visualizer_RefreshStateChanged;

        // Add some initial content to the list.
        await FetchAndInsertItemsAsync(2);
    }

    private void RefreshButtonClick(object sender, RoutedEventArgs e)
    {
        RefreshContainer.RequestRefresh();
    }

    private async void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
    {
        // Respond to a request by performing a refresh and using the deferral object.
        using (var RefreshCompletionDeferral = args.GetDeferral())
        {
            // Do some async operation to refresh the content

            await FetchAndInsertItemsAsync(3);

            // The 'using' statement ensures the deferral is marked as complete.
            // Otherwise, you'd call
            // RefreshCompletionDeferral.Complete();
            // RefreshCompletionDeferral.Dispose();
        }
    }

    private void Visualizer_RefreshStateChanged(RefreshVisualizer sender, RefreshStateChangedEventArgs args)
    {
        // Respond to visualizer state changes.
        // Disable the refresh button if the visualizer is refreshing.
        if (args.NewState == RefreshVisualizerState.Refreshing)
        {
            RefreshButton.IsEnabled = false;
        }
        else
        {
            RefreshButton.IsEnabled = true;
        }
    }

    // App specific code to get fresh data.
    private async Task FetchAndInsertItemsAsync(int updateCount)
    {
        for (int i = 0; i < updateCount; ++i)
        {
            // Simulate delay while we go fetch new items.
            await Task.Delay(1000);
            Items.Insert(0, GetNextItem());
        }
    }

    private ListItemData GetNextItem()
    {
        return new ListItemData()
        {
            Header = "Header " + DateTime.Now.Second.ToString(),
            Date = DateTime.Now.ToLongDateString(),
            Body = DateTime.Now.ToLongTimeString()
        };
    }
}

public class ListItemData
{
    public string Header { get; set; }
    public string Date { get; set; }
    public string Body { get; set; }
}
```

## <a name="related-articles"></a>関連記事

- [タッチ操作](../input/touch-interactions.md)
- [リスト ビューとグリッド ビュー](listview-and-gridview.md)
- [項目コンテナーやテンプレート](item-containers-templates.md)
- [数式アニメーション](../../composition/composition-animation.md)
