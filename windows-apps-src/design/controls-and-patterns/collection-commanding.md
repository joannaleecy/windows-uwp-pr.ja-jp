---
author: mijacobs
description: どのような種類の入力でも、最善のエクスペリエンスが得られるように、そのような操作をコンテキスト コマンドを使って実装する方法。
title: コンテキスト コマンドの実行
ms.assetid: ''
label: Contextual commanding in collections
template: detail.hbs
ms.author: mijacobs
ms.date: 10/25/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: chigy
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: f06d7015fcb208b55fe0cb57b96eaecbc99317cc
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7111849"
---
# <a name="contextual-commanding-for-collections-and-lists"></a>コレクションとリストのコンテキスト コマンドの実行



多くのアプリに、リスト、グリッド、ツリーの形で、ユーザーが操作できるコンテンツのコレクションが含まれています。 たとえば、ユーザーは、項目の削除、名前の変更、フラグ付け、更新ができる可能性があります。 この記事では、どのような種類の入力でも、最善のエクスペリエンスが得られるように、そのような操作をコンテキスト コマンドを使って実装する方法を説明します。  

> **Important API**: [ICommand インターフェイス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand)、[UIElement.ContextFlyout プロパティ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout)、[INotifyPropertyChanged インターフェイス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.data.inotifypropertychanged)

![各種入力方法で、お気に入りのコマンドを実行する](images/ContextualCommand_AddFavorites.png)

## <a name="creating-commands-for-all-input-types"></a>あらゆる種類の入力に対応するコマンドを作成する

ユーザーは[さまざまなデバイスや入力方法](../devices/index.md)を使って UWP アプリを操作できるため、アプリでは入力方法に依存しないコンテキスト メニューと、各種入力方法専用のアクセラレータの両方でコマンドを公開する必要があります。 両方を含めることで、入力方法やデバイスの種類に関わらず、コンテンツに対してコマンドをすばやく呼び出すことができます。

次の表に、いくつかの典型的なコレクションのコマンドと、これらのコマンドを公開する方法を示します。 

| コマンド          | 入力方法を問わない | マウス アクセラレータ | キーボード アクセラレータ | タッチ アクセラレータ |
| ---------------- | -------------- | ----------------- | -------------------- | ----------------- |
| 項目の削除      | コンテキスト メニュー   | ホバー ボタン      | DEL キー              | スワイプして削除   |
| フラグの設定        | コンテキスト メニュー   | ホバー ボタン      | Ctrl + Shift + G         | スワイプしてフラグを設定     |
| データの更新     | コンテキスト メニュー   | なし               | F5 キー               | 引っ張って更新   |
| お気に入りに追加 | コンテキスト メニュー   | ホバー ボタン      | F、Ctrl + S            | スワイプしてお気に入りに追加 |


* **通常は、特定の項目に対するすべてのコマンドをその項目の[コンテキスト メニュー](menus.md)から利用できるようにします。** コンテキスト メニューには、入力の種類にかかわらず、ユーザーがアクセスでき、ユーザーが実行できるコンテキスト コマンドの全部を含めてください。

* **頻繁にアクセスするコマンドについては、入力アクセラレータを使うことを検討してください。** 入力アクセラレータを使うと、ユーザーの入力デバイスに応じて、すばやく操作を実行できます。 次のような入力アクセラレータがあります。
    - スワイプして操作 (タッチ アクセラレータ)
    - 引っ張ってデータを更新 (タッチ アクセラレータ)
    - キーボード ショートカット (キーボード アクセラレータ)
    - アクセス キー (キーボード アクセラレータ)
    - マウスとペンのホバー ボタン (ポインター アクセラレータ)

> [!NOTE]
> ユーザーは、どの種類のデバイスからでも、すべてのコマンドにアクセスできる必要があります。 たとえば、アプリのコマンドがホバー ボタン ポインター アクセラレータでしか公開されない場合、タッチ ユーザーはコマンドにアクセスできません。 少なくとも、すべてのコマンドにアクセスできるコンテキスト メニューを使います。  

## <a name="example-the-podcastobject-data-model"></a>例: PodcastObject データ モデル

推奨されるコマンド実行のデモとして、この記事では、ポッドキャスト アプリ用のポッドキャスト リストを作成します。 コード例では、ユーザーがリストから特定のポッドキャストを "お気に入り" に追加できるようにする方法を示しています。

以下に、この記事で作業するポッドキャスト オブジェクトの定義を示します。 

```csharp
public class PodcastObject : INotifyPropertyChanged
{
    // The title of the podcast
    public String Title { get; set; }

    // The podcast's description
    public String Description { get; set; }

    // Describes if the user has set this podcast as a favorite
    public bool IsFavorite
    {
        get
        {
            return _isFavorite;
        }
        set
        {
            _isFavorite = value;
            OnPropertyChanged("IsFavorite");
        }
    }
    private bool _isFavorite = false;

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(String property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
```

PodcastObject は [INotifyPropertyChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Data.INotifyPropertyChanged) を実装して、ユーザーが IsFavorite プロパティの設定を切り替えたときに、プロパティの変更に応答するようにしています。

## <a name="defining-commands-with-the-icommand-interface"></a>ICommand インターフェイスを使ったコマンドの定義

[ICommand インターフェイス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand) を使うと、複数の入力の種類に利用できるコマンドを定義できます。 たとえば、Delete キーが押されたときと、コンテキスト メニューで [削除] が右クリックされたときの 2 種類のイベント ハンドラーで同じ削除コマンドのコードを記述するのではなく、[ICommand](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand) として削除ロジックを 1 度実装したら、各種入力方法でこの削除ロジックを利用可能にできます。

"お気に入り" の操作を表す ICommand を定義する必要があります。 ポッドキャストをお気に入りに追加するには、コマンドの [Execute](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand.Execute) メソッドを使います。 特定のポッドキャストがコマンドのパラメーターを介して実行メソッドに渡されます。これは、CommandParameter プロパティを使ってバインドできます。

```csharp
public class FavoriteCommand: ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true;
    }
    public void Execute(object parameter)
    {
        // Perform the logic to "favorite" an item.
        (parameter as PodcastObject).IsFavorite = true;
    }
}
```

複数のコレクションや要素で同じコマンドを使うには、コマンドをページやアプリのリソースとして保存します。

```xaml
<Application.Resources>
    <local:FavoriteCommand x:Key="favoriteCommand" />
</Application.Resources>
```

コマンドを実行するには、コマンドの [Execute](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand.Execute) メソッドを呼び出します。

```csharp
// Favorite the item using the defined command
var favoriteCommand = Application.Current.Resources["favoriteCommand"] as ICommand;
favoriteCommand.Execute(PodcastObject);
```


## <a name="creating-a-usercontrol-to-respond-to-a-variety-of-inputs"></a>さまざまな入力に応答する UserControl の作成

項目のリストがあり、各項目が複数の入力方法に応答する場合、項目の [UserControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.UserControl) を定義し、これを使って項目のコンテキスト メニューとイベント ハンドラーを定義することで、コードを簡潔にできます。 

Visual Studio で UserControl を作る手順は次のとおりです。
1. ソリューション エクスプローラーで、プロジェクトを右クリックします。 コンテキスト メニューが表示されます。
2. **[追加]、[新しい項目]** の順に選びます。 <br />**[新しい項目の追加]** ダイアログが表示されます。 
3. 項目の一覧から [UserControl] を選択します。 任意の名前を付けて、**[追加]** をクリックします。 Visual Studio によって UserControl のスタブが生成されます。 

この記事のポッドキャストの例では、各ポッドキャストはリストにまとめられて表示され、さまざまな方法でポッドキャストを ”お気に入り” に追加できるようになります。 ユーザーは次の操作によって、ポッドキャストを ”お気に入り” にすることができます。
- コンテキスト メニューの呼び出し
- キーボード ショートカットの実行
- ホバー ボタンの表示
- スワイプ ジェスチャの実行

これらの動作をカプセル化して、FavoriteCommand を使えるように、リスト内のポッドキャストを表す "PodcastUserControl" という名前の新しい [UserControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.UserControl) を作りましょう。

PodcastUserControl は PodcastObject のフィールドを TextBlocks として表示し、さまざまなユーザーの操作に応答します。 この記事では、この PodcastUserControl を参照し、拡張していきます。

**PodcastUserControl.xaml**
```xaml
<UserControl
    x:Class="ContextCommanding.PodcastUserControl"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    IsTabStop="True" UseSystemFocusVisuals="True"
    >
    <Grid Margin="12,0,12,0">
        <StackPanel>
            <TextBlock Text="{x:Bind PodcastObject.Title, Mode=OneWay}" Style="{StaticResource TitleTextBlockStyle}" />
            <TextBlock Text="{x:Bind PodcastObject.Description, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}" />
            <TextBlock Text="{x:Bind PodcastObject.IsFavorite, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}"/>
        </StackPanel>
    </Grid>
</UserControl>
```

**PodcastUserControl.xaml.cs**
```csharp
public sealed partial class PodcastUserControl : UserControl
{
    public static readonly DependencyProperty PodcastObjectProperty =
        DependencyProperty.Register(
            "PodcastObject",
            typeof(PodcastObject),
            typeof(PodcastUserControl),
            new PropertyMetadata(null));

    public PodcastObject PodcastObject
    {
        get { return (PodcastObject)GetValue(PodcastObjectProperty); }
        set { SetValue(PodcastObjectProperty, value); }
    }

    public PodcastUserControl()
    {
        this.InitializeComponent();

        // TODO: We will add event handlers here.
    }
}
```

この PodcastUserControl では、PodcastObject への参照を DependencyProperty として維持しています。 これで、PodcastObjects を PodcastUserControl にバインドできるようになります。

いくつか PodcastObjects を生成したら、PodcastObjects を ListView にバインドして、ポッドキャストのリストを作成できます。 PodcastUserControl オブジェクトは、PodcastObjects の視覚エフェクトを記述します。したがって、ListView の ItemTemplate を使って設定します。

**MainPage.xaml**
```xaml
<ListView x:Name="ListOfPodcasts"
            ItemsSource="{x:Bind podcasts}">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="local:PodcastObject">
            <local:PodcastUserControl PodcastObject="{x:Bind Mode=OneWay}" />
        </DataTemplate>
    </ListView.ItemTemplate>
    <ListView.ItemContainerStyle>
        <!-- The PodcastUserControl will entirely fill the ListView item and handle tabbing within itself. -->
        <Style TargetType="ListViewItem" BasedOn="{StaticResource ListViewItemRevealStyle}">
            <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            <Setter Property="Padding" Value="0"/>
            <Setter Property="IsTabStop" Value="False"/>
        </Style>
    </ListView.ItemContainerStyle>
</ListView>
```

## <a name="creating-context-menus"></a>コンテキスト メニューの作成

コンテキスト メニューは、ユーザーの要求に応じて、コマンドやオプションの一覧を表示します。 コンテキスト メニューは、アタッチされた要素に関連するコンテキスト コマンドを提供します。また、通常、その項目固有のセカンダリ操作のために予約されています。

![項目のコンテキスト メニューを表示する](images/ContextualCommand_RightClick.png)

ユーザーは、以下の "コンテキスト アクション" を使ってコンテキスト メニューを呼び出すことができます。

| 入力    | コンテキスト アクション                          |
| -------- | --------------------------------------- |
| マウス    | 右クリック                             |
| キーボード | Shift + F10、メニュー ボタン                  |
| タッチ    | 項目を長押し                      |
| ペン      | バレル ボタンを押す、項目を長押し |
| ゲームパッド  | メニュー ボタン                             |

**ユーザーはさまざまな種類の入力方法でコンテキスト メニューを開く可能性があるため、リストの項目に対して実行できるコンテキスト コマンドの全部をコンテキスト メニューに含めてください。**

### <a name="contextflyout"></a>ContextFlyout

UIElement クラスによって定義される [ContextFlyout プロパティ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout) を利用すると、すべての入力の種類で使えるコンテキスト メニューを簡単に作成できます。 コンテキスト メニューを表すポップアップは MenuFlyout を使って提供します。上記で定義した “コンテキスト操作” をユーザーが実行すると、項目に対応する MenuFlyout が表示されます。

ContextFlyout を PodcastUserControl に追加します。 ContextFlyout として指定された MenuFlyout には、ポッドキャストをお気に入りに追加するための項目が 1 つだけ含まれています。 この MenuFlyoutItem では上記で定義した favoriteCommand を使い、CommandParamter が PodcastObject にバインドされていることに注意してください。

**PodcastUserControl.xaml**
```xaml
<UserControl>
    <UserControl.ContextFlyout>
        <MenuFlyout>
            <MenuFlyoutItem Text="Favorite" Command="{StaticResource favoriteCommand}" CommandParameter="{x:Bind PodcastObject, Mode=OneWay}" />
        </MenuFlyout>
    </UserControl.ContextFlyout>
    <Grid Margin="12,0,12,0">
        <!-- ... -->
    </Grid>
</UserControl>

```

また、[ContextRequested イベント](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextRequested) を使って、コンテキスト操作に応答することもできます。 ContextRequested イベントは、ContextFlyout が指定されている場合は発生しません。

## <a name="creating-input-accelerators"></a>入力アクセラレータの作成

コレクション内の各項目のコンテキスト コマンドをすべて含むコンテキスト メニューを用意することをお勧めしますが、よく実行される特定のコマンドをユーザーがすばやく実行できるようにすることも一案です。 たとえば、メール アプリであれば、応答、アーカイブ、フォルダーへ移動、フラグの設定、削除などのセカンダリ コマンドをコンテキスト メニューに表示しますが、最もよく使われるコマンドは削除とフラグの設定です。 最もよく使われるコマンドを特定したら、入力ベースのアクセラレータを使って、これらのコマンドをユーザーが実行しやすくできます。

ポッドキャスト アプリでは、頻繁に実行されるコマンドは ”お気に入り” コマンドです。

### <a name="keyboard-accelerators"></a>キーボード アクセラレータ

#### <a name="shortcuts-and-direct-key-handling"></a>ショートカットと直接キーの処理

![Ctrl キーと F キーを押して操作を実行](images/ContextualCommand_Keyboard.png)

コンテンツの種類に応じて、操作を実行する特定のキーの組み合わせを明らかにします。 たとえば、メール アプリでは、選択されたメールの削除に Del キーが使われる可能性があります。 ポッドキャスト アプリでは、Ctrl + S や F キーによって、後で視聴するためにポッドキャストをお気に入りに追加する可能性があります。 Del キーで削除するなど、よく知られた一般的なキーボード ショートカットがあるコマンドもあれば、アプリまたはドメイン固有のショートカットがあるコマンドもあります。 できればよく知られているショートカットを使用してください。または、ヒントでリマインダー テキストを表示してショートカット コマンドをユーザーに伝えることを検討してください。

[KeyDown](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.KeyDownEvent) イベントを使うことで、アプリはユーザーがキーを押したときに応答できます。 通常ユーザーは、押したキーを放すときではなく、キーを最初に押したときにアプリが応答するものと考えます。

次の例では、KeyDown ハンドラーを PodcastUserControl に追加して、ユーザーが Ctrl + S または F キーを押したときにポッドキャストをお気に入りに追加する方法を示しています。このコードでは、前と同じコマンドを使っています。

**PodcastUserControl.xaml.cs**
```csharp
// Respond to the F and Ctrl+S keys to favorite the focused item.
protected override void OnKeyDown(KeyRoutedEventArgs e)
{
    var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
    var isCtrlPressed = (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down || (ctrlState & CoreVirtualKeyStates.Locked) == CoreVirtualKeyStates.Locked;

    if (e.Key == Windows.System.VirtualKey.F || (e.Key == Windows.System.VirtualKey.S && isCtrlPressed))
    {
        // Favorite the item using the defined command
        var favoriteCommand = Application.Current.Resources["favoriteCommand"] as ICommand;
        favoriteCommand.Execute(PodcastObject);
    }
}
```

### <a name="mouse-accelerators"></a>マウス アクセラレータ

![項目の上にマウス ポインターを重ねてボタンを表示](images/ContextualCommand_HovertoReveal.png)

右クリックのコンテキスト メニューはユーザーにとっておなじみですが、マウスのクリック 1 回で、よく使われるコマンドを実行できるようにしても便利です。 このエクスペリエンスを実現するには、専用のボタンをコレクション項目のキャンバスに含めます。 ユーザーがマウスを使ってすばやく操作できるようにすると同時に、不要な表示をできる限りなくすには、特定のリスト項目内にポインターが置かれたときに、専用のボタンのみが表示されるようにすることができます。

次の例では、PodcastUserControl 内で直接定義したボタンによって、お気に入りコマンドを提示しています。 なお、この例のボタンでも、以前と同じ FavoriteCommand コマンドを使っています。 このボタンの表示と非表示を切り替えるには、VisualStateManager を使って、ボタンの領域内にポインターが置かれたときと、領域からポインターが外れたときに、表示の状態を切り替えることができます。

**PodcastUserControl.xaml**
```xaml
<UserControl>
    <UserControl.ContextFlyout>
        <!-- ... -->
    </UserControl.ContextFlyout>
    <Grid Margin="12,0,12,0">
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="HoveringStates">
                <VisualState x:Name="HoverButtonsShown">
                    <VisualState.Setters>
                        <Setter Target="hoverArea.Visibility" Value="Visible" />
                    </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="HoverButtonsHidden" />
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>
        <StackPanel>
            <TextBlock Text="{x:Bind PodcastObject.Title, Mode=OneWay}" Style="{StaticResource TitleTextBlockStyle}" />
            <TextBlock Text="{x:Bind PodcastObject.Description, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}" />
            <TextBlock Text="{x:Bind PodcastObject.IsFavorite, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}"/>
        </StackPanel>
        <Grid Grid.Column="1" x:Name="hoverArea" Visibility="Collapsed" VerticalAlignment="Stretch">
            <AppBarButton Icon="OutlineStar" Label="Favorite" Command="{StaticResource favoriteCommand}" CommandParameter="{x:Bind PodcastObject, Mode=OneWay}" IsTabStop="False" VerticalAlignment="Stretch"  />
        </Grid>
    </Grid>
</UserControl>
```

ホバー ボタンは、マウス ポインターが項目に重なったら表示し、項目から外れたら非表示にします。 マウス イベントに応答するには、PodcastUserControl で [PointerEntered](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.PointerEnteredEvent) イベントと [PointerExited](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.PointerExitedEvent) イベントを使います。

**PodcastUserControl.xaml.cs**
```csharp
protected override void OnPointerEntered(PointerRoutedEventArgs e)
{
    base.OnPointerEntered(e);

    // Only show hover buttons when the user is using mouse or pen.
    if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen)
    {
        VisualStateManager.GoToState(this, "HoverButtonsShown", true);
    }
}

protected override void OnPointerExited(PointerRoutedEventArgs e)
{
    base.OnPointerExited(e);

    VisualStateManager.GoToState(this, "HoverButtonsHidden", true);
}
```

ホバー状態で表示されたボタンは、ポインター入力でしかアクセスできません。 このボタンはポインター入力でしか操作できないため、ボタンのアイコンを囲む余白を最小限にするか完全になくして、ポインター入力向けに最適化することもできます。 余白をなくす場合は、ペンとマウスで操作できるように、ボタンのフットプリントを必ず 20 x 20 ピクセル以上にしてください。

### <a name="touch-accelerators"></a>タッチ アクセラレータ

#### <a name="swipe"></a>スワイプ

![項目をスワイプしてコマンドを表示](images/ContextualCommand_Swipe.png)

スワイプによるコマンド実行は、タッチ デバイスを操作しているユーザーが、よく使われるセカンダリ操作をタッチを使って実行できるようにするタッチ アクセラレータです。 スワイプはタッチ ユーザーが、スワイプして削除やスワイプして呼び出すなどの一般的な操作を使って、コンテンツをすばやく自然に操作することを可能にします。 詳しくは、[スワイプによるコマンドの実行](swipe.md)についての記事をご覧ください。

コレクションにスワイプを組み込むには、コマンドをホストする SwipeItems と、項目をラップしてスワイプにより操作できるようにする SwipeControl の 2 つのコンポーネントが必要です。

SwipeItems は、PodcastUserControl 内の Resource として定義できます。 次の例では、SwipeItems に、項目をお気に入りに追加するコマンドが含まれています。

```xaml
<UserControl.Resources>
    <SymbolIconSource x:Key="FavoriteIcon" Symbol="Favorite"/>
    <SwipeItems x:Key="RevealOtherCommands" Mode="Reveal">
        <SwipeItem IconSource="{StaticResource FavoriteIcon}" Text="Favorite" Background="Yellow" Invoked="SwipeItem_Invoked"/>
    </SwipeItems>
</UserControl.Resources>
```

SwipeControl は項目をラップし、ユーザーがスワイプ ジェスチャを使って項目を操作できるようにしています。 SwipeControl には、RightItems として SwipeItems への参照が含まれていることに注意してください。 ユーザーが右から左へスワイプすると、お気に入りの項目が表示されます。

```xaml
<SwipeControl x:Name="swipeContainer" RightItems="{StaticResource RevealOtherCommands}">
   <!-- The visual state groups moved from the Grid to the SwipeControl, since the SwipeControl wraps the Grid. -->
   <VisualStateManager.VisualStateGroups>
       <VisualStateGroup x:Name="HoveringStates">
           <VisualState x:Name="HoverButtonsShown">
               <VisualState.Setters>
                   <Setter Target="hoverArea.Visibility" Value="Visible" />
               </VisualState.Setters>
           </VisualState>
           <VisualState x:Name="HoverButtonsHidden" />
       </VisualStateGroup>
   </VisualStateManager.VisualStateGroups>
   <Grid Margin="12,0,12,0">
       <Grid.ColumnDefinitions>
           <ColumnDefinition Width="*" />
           <ColumnDefinition Width="Auto" />
       </Grid.ColumnDefinitions>
       <StackPanel>
           <TextBlock Text="{x:Bind PodcastObject.Title, Mode=OneWay}" Style="{StaticResource TitleTextBlockStyle}" />
           <TextBlock Text="{x:Bind PodcastObject.Description, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}" />
           <TextBlock Text="{x:Bind PodcastObject.IsFavorite, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}"/>
       </StackPanel>
       <Grid Grid.Column="1" x:Name="hoverArea" Visibility="Collapsed" VerticalAlignment="Stretch">
           <AppBarButton Icon="OutlineStar" Command="{StaticResource favoriteCommand}" CommandParameter="{x:Bind PodcastObject, Mode=OneWay}" IsTabStop="False" LabelPosition="Collapsed" VerticalAlignment="Stretch"  />
       </Grid>
   </Grid>
</SwipeControl>
```

ユーザーがスワイプしてお気に入りコマンドを呼び出すと、Invoked メソッドが呼び出されます。

```csharp
private void SwipeItem_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
{
    // Favorite the item using the defined command
    var favoriteCommand = Application.Current.Resources["favoriteCommand"] as ICommand;
    favoriteCommand.Execute(PodcastObject);
}
```

#### <a name="pull-to-refresh"></a>引っ張って更新

引っ張って更新を使うと、タッチ操作でデータのコレクションを引き下げることで、より多くのデータを取得できます。 詳しくは、[引っ張って更新](pull-to-refresh.md)についての記事をご覧ください。

### <a name="pen-accelerators"></a>ペン アクセラレータ

ペン入力は、精度の高いポインター入力を実現します。 ユーザーは、ペン ベースのアクセラレータを使って、コンテキスト メニューを開くなどの一般的な操作を実行できます。 コンテキスト メニューを開くには、バレル ボタンを押して画面をタップするか、コンテンツを長押しします。 また、マウスと同様に、ペンを使ってコンテンツにポインターを重ねて、ヒントを表示するなど、UI についての理解を深めたり、セカンダリのホバー操作を表示したりすることもできます。

ペン入力用にアプリを最適化するには、[ペン操作とスタイラス操作](../input/pen-and-stylus-interactions.md)についての記事をご覧ください。


## <a name="dos-and-donts"></a>推奨と非推奨

* どの種類の UWP デバイスでも、ユーザーがすべてのコマンドにアクセスできるようにします。
* コレクション項目に対するコマンド全部にアクセスできるコンテキスト メニューを含めます。 
* 頻繁に使われるコマンドについては、入力アクセラレータを提供します。 
* コマンドの実装には [ICommand インターフェイス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand) を使う。 

## <a name="related-topics"></a>関連トピック
* [ICommand インターフェイス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand)
* [メニューとコンテキスト メニュー](menus.md)
* [スワイプ](swipe.md)
* [引っ張って更新](pull-to-refresh.md)
* [ペン操作とスタイラス操作](../input/pen-and-stylus-interactions.md)
* [ゲームパッドと Xbox 向けにアプリを調整する](../devices/designing-for-tv.md)
