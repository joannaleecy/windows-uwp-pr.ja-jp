---
author: Jwmsft
Description: メディア プレーヤーには、オーディオおよびビデオ コンテンツのコントロールを管理するためのカスタマイズ可能な XAML トランスポート コントロールがあります。
title: カスタム メディア トランスポート コントロールを作成する
ms.assetid: 6643A108-A6EB-42BC-B800-22EABD7B731B
label: Create custom media transport controls
template: detail.hbs
---
# カスタム トランスポート コントロールを作成する

MediaElement には、ユニバーサル Windows プラットフォーム (UWP) アプリ内でオーディオおよびビデオ コンテンツのコントロールを管理するためのカスタマイズ可能な XAML トランスポート コントロールがあります。 ここでは、MediaTransportControls テンプレートをカスタマイズする方法を示します。 オーバーフロー メニューの操作方法、カスタム ボタンの追加方法、スライダーの変更方法、色の変更方法について説明します。

始める前に、MediaElement クラスと MediaTransportControls クラスについて理解している必要があります。 詳しくは、「MediaElement コントロール ガイド」をご覧ください。 

> **ヒント:**
            &nbsp;&nbsp;このトピックの例は、[メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)を基にしています。 サンプルをダウンロードし、詳細なコードを参照して実行することができます。

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926)
-   [**MediaElement.AreTransportControlsEnabled**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aretransportcontrolsenabled.aspx)
-   [**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677)

## テンプレートをカスタマイズする必要がある状況

**MediaElement** には、変更しなくてもほとんどのビデオおよびオーディオ再生アプリで正常に動作するように設計されているトランスポート コントロールが組み込まれています。 これらのコントロールは、[**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) クラスによって提供され、再生、停止、メディアのナビゲーション、音量の調節、全画面表示の切り替え、2 台目のデバイスへのキャスト、字幕の有効化、オーディオ トラックの切り替え、再生速度の調整を行うためのボタンが含まれています。 MediaTransportControls には、各ボタンを表示し、有効にするかどうかを制御できるプロパティがあります。 [
            **IsCompact**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.iscompact.aspx) プロパティを設定して、コントロールを 1 行に表示するか、2 行に表示するかを指定することもできます。

ただし、コントロールの外観をさらにカスタマイズしたり、動作を変更したりする必要があるシナリオも考えられます。 例をいくつか紹介します。
- アイコン、スライダーの動作、色を変更する。
- 使用頻度の低いコマンド ボタンをオーバーフロー メニューに移動する。
- コントロールのサイズが変更されたときに、コマンドをドロップ アウトする順序を変更する。
- 既定のセットには含まれていないコマンド ボタンを提供する。

コントロールの外観をカスタマイズするには、既定のテンプレートを変更します。 コントロールの動作を変更したり、新しいコマンドを追加したりするには、MediaTransportControls から派生したカスタム コントロールを作成できます。

>**ヒント:**
            &nbsp;&nbsp;カスタマイズ可能なコントロール テンプレートは XAML プラットフォームの強力な機能ですが、考慮すべき影響もあります。 テンプレートをカスタマイズすると、アプリの静的な部分となるため、Microsoft によって行われるプラットフォームの更新を受け取らなくなります。 Microsoft によってテンプレートの更新が加えられた場合、更新されたテンプレートを利用するには、新しいテンプレートを取得して再変更する必要があります。

## テンプレートの構造

[
            **ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.controltemplate.aspx) は既定のスタイルに含まれます。 トランスポート コントロールの既定のスタイルは、「[**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) クラス」リファレンス ページに示されています。 この既定のスタイルをプロジェクトにコピーして変更できます。 ControlTemplate は、他の XAML コントロール テンプレートと同様のセクションに分かれています。
- テンプレートの最初のセクションには、MediaTransportControls のさまざまなコンポーネントの [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) 定義が含まれています。
- 2 番目のセクションでは、MediaTransportControls が使うさまざまな表示状態が定義されています。
- 3 番目のセクションには、さまざまな MediaTransportControls 要素をまとめて保持し、コンポーネントのレイアウトを定義する [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) が含まれています。

> **注:**
            &nbsp;&nbsp;テンプレートの変更について詳しくは、「[コントロール テンプレート]()」をご覧ください。 テキスト エディターか、IDE の同様のエディターを使って、\(*Program Files*)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\\(*SDK version*)\Generic にある XAML ファイルを開くことができます。 各コントロールの既定のスタイルとテンプレートは、**generic.xaml** ファイルで定義されています。 MediaTransportControls テンプレートは、generic.xaml で "MediaTransportControls" を検索すると見つけることができます。

以下のセクションでは、トランスポート コントロールの主な要素のいくつかをカスタマイズする方法について説明します。 
- [
              **Slider**
            ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx): ユーザーがメディアをスクラブし、進行状況も表示できるようにします。
- [
              **CommandBar**
            ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx): すべてのボタンが含まれています。
詳しくは、MediaTransportControls リファレンス トピックの構造セクションをご覧ください。 

## トランスポート コントロールをカスタマイズする

MediaTransportControls の外観のみを変更する場合、既定のコントロールのスタイルとテンプレートのコピーを作成し、変更することができます。 ただし、コントロールの機能を追加または変更する場合は、MediaTransportControls から派生した新しいクラスを作成する必要があります。

### コントロールのテンプレートの再適用

**MediaTransportControls の既定のスタイルとテンプレートをカスタマイズするには**
1. 「MediaTransportControls スタイルとテンプレート」に示されている既定のスタイルを、プロジェクトの ResourceDictionary にコピーします。
2. 次のように、Style に、識別するための x:Key 値を指定します。 
```xaml
<Style TargetType="MediaTransportControls" x:Key="myTransportControlsStyle">
    <!-- Style content ... -->
</Style>
```
3. UI に MediaElement を MediaTransportControls と共に追加します。
4. 次に示すように、MediaTransportControls 要素の Style プロパティを、カスタム Style リソースに設定します。 
```xaml
<MediaElement AreTransportControlsEnabled="True">
    <MediaElement.TransportControls>
        <MediaTransportControls Style="{StaticResource myTransportControlsStyle}"/>
    </MediaElement.TransportControls>
</MediaElement>
```

スタイルとテンプレートの変更について詳しくは、「[コントロールのスタイル]()」と「[コントロール テンプレート]()」をご覧ください。

### 派生コントロールの作成

トランスポート コントロールの機能を追加または変更するには、MediaTransportControls から派生した新しいクラスを作成する必要があります。 [メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)と、このページの他の例では、`CustomMediaTransportControls` という名前の派生クラスが使用されています。

**MediaTransportControls から派生した新しいクラスを作成するには**
1. プロジェクトに新しいクラス ファイルを追加します。
    - Visual Studio で、[プロジェクト] の [クラスの追加] をクリックします。 [新しい項目の追加] ダイアログ ボックスが開きます。
    - [新しい項目の追加] ダイアログで、クラス ファイルの名前を入力し、[追加] をクリックします。 (メディア トランスポート コントロールのサンプルでは、このクラスに `CustomMediaTransportControls` という名前を付けています。)
2. このクラスのコードを変更して、MediaTransportControls クラスから派生クラスを作成します。
```csharp
public sealed class CustomMediaTransportControls : MediaTransportControls
{
}
```
3. [
            **MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) の既定のスタイルをプロジェクトの [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.resourcedictionary.aspx) にコピーします。 これが変更する対象のスタイルとテンプレートです。
(メディア トランスポート コントロールのサンプルでは、"Themes" という新しいフォルダーが作成され、generic.xaml という ResourceDictionary ファイルがそのフォルダーに追加されます。)
4. スタイルの [**TargetType**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.targettype.aspx) を、新しいカスタム コントロール型に変更します。 (サンプルでは、TargetType を `local:CustomMediaTransportControls` に変更しています。)
```xaml
xmlns:local="using:CustomMediaTransportControls">
...
<Style TargetType="local:CustomMediaTransportControls">
```
5. カスタム クラスの [**DefaultStyleKey**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.defaultstylekey.aspx) を設定します。 これにより、TargetType が `local:CustomMediaTransportControls` である Style を使用するようにカスタム クラスに指示します。
```csharp
public sealed class CustomMediaTransportControls : MediaTransportControls
{
    public CustomMediaTransportControls()
    {
        this.DefaultStyleKey = typeof(CustomMediaTransportControls);
    }
}
```
6. XAML マークアップに [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx) を追加し、この MediaElement にカスタム トランスポート コントロールを追加します。 注意が必要な 1 つの点は、既定のボタンを非表示、表示、無効、有効にする API は、カスタマイズされたテンプレートでも機能するという点です。
```xaml
<MediaElement Name="MediaElement1" AreTransportControlsEnabled="True" Source="video.mp4">
    <MediaElement.TransportControls>
        <local:CustomMediaTransportControls x:Name="customMTC"
                                            IsFastForwardButtonVisible="True"
                                            IsFastForwardEnabled="True"
                                            IsFastRewindButtonVisible="True"
                                            IsFastRewindEnabled="True"
                                            IsPlaybackRateButtonVisible="True"
                                            IsPlaybackRateEnabled="True"
                                            IsCompact="False">
        </local:CustomMediaTransportControls>
    </MediaElement.TransportControls>
</MediaElement>
```
これで、コントロールのスタイルとテンプレートを変更してカスタム コントロールの外観を更新し、コントロールのコードを変更して動作を更新できました。

### オーバーフロー メニューを使う

MediaTransportControls のコマンド ボタンをオーバーフロー メニューに移動し、ユーザーが必要になるまでに使用頻度の低いコマンドを非表示にすることができます。

MediaTransportControls テンプレートでは、コマンド ボタンは [**CommandBar**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx) 要素に含まれています。 コマンド バーには、プライマリ コマンドとセカンダリ コマンドの概念があります。 プライマリ コマンドは、既定でコントロールに表示されるボタンであり、常に表示されます (ボタンを無効または非表示にした場合を除く)。 セカンダリ コマンドはオーバーフロー メニューに表示されます。オーバーフロー メニューは、ユーザーが省略記号 (...) ボタンをクリックしたときに表示されます。 詳しくは、「[アプリ バーとコマンド バー](app-bars.md)」をご覧ください。

コマンド バーのプライマリ コマンドの要素をオーバーフロー メニューに移動するには、XAML コントロール テンプレートを編集する必要があります。 

**オーバーフロー メニューにコマンドを移動するには**
1. コントロール テンプレートで、`MediaControlsCommandBar` という名前の CommandBar 要素を検索します。
2. CommandBar の XAML に [**SecondaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) セクションを追加します。 このセクションは、[**PrimaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx) の終了タグの後に配置します。 
```xaml
<CommandBar x:Name="MediaControlsCommandBar" ... >  
  <CommandBar.PrimaryCommands>
...
    <AppBarButton x:Name='PlaybackRateButton'
                    Style='{StaticResource AppBarButtonStyle}'
                    MediaTransportControlsHelper.DropoutOrder='4'
                    Visibility='Collapsed'>
      <AppBarButton.Icon>
        <FontIcon Glyph="&#xEC57;"/>
      </AppBarButton.Icon>
    </AppBarButton>
...
  </CommandBar.PrimaryCommands>
<!-- Add secondary commands (overflow menu) here -->
  <CommandBar.SecondaryCommands>
    ...
  </CommandBar.SecondaryCommands>
</CommandBar>
```
3. このメニューにコマンドを表示するには、目的の [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx) オブジェクトの XAML を PrimaryCommands から切り取って SecondaryCommands に貼り付けます。 この例では、`PlaybackRateButton` をオーバーフロー メニューに移動します。

4. 次に示すように、ボタンにラベルを追加し、スタイル情報を削除します。
オーバーフロー メニューはテキスト ボタンで構成されているため、ボタンにテキスト ラベルを追加し、ボタンの高さと幅を設定するスタイルを削除する必要があります。 そうしないと、ボタンはオーバーフロー メニューに正しく表示されません。
```xaml
<CommandBar.SecondaryCommands>
    <AppBarButton x:Name='PlaybackRateButton'
                  Label='Playback Rate'>
    </AppBarButton>
</CommandBar.SecondaryCommands>
```

> **重要:**
            &nbsp;&nbsp;ボタンをオーバーフロー メニューで使用するには、ボタンを表示して有効にする必要があります。 この例では、IsPlaybackRateButtonVisible プロパティが true ではない場合、PlaybackRateButton 要素はオーバーフロー メニューに表示されません。 IsPlaybackRateEnabled プロパティが true ではない場合、この要素は有効ではありません。 これらのプロパティの設定は、前のセクションに示されています。

### カスタム ボタンの追加

MediaTransportControls をカスタマイズする理由の 1 つは、コントロールにカスタム コマンドを追加するためです。 コマンドをプライマリ コマンドとセカンダリ コマンドのどちらとして追加するかに関係なく、コマンド ボタンを作成し、その動作を変更する手順は同じです。 [メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)では、"評価" ボタンをプライマリ コマンドに追加しています。 

**カスタム コマンド ボタンを追加するには**
1. AppBarButton オブジェクトを作成し、コントロール テンプレートの CommandBar に追加します。 
```xaml
<AppBarButton x:Name="LikeButton" 
              Icon="Like" 
              Style="{StaticResource AppBarButtonStyle}" 
              MediaTransportControlsHelper.DropoutOrder="3"
              VerticalAlignment="Center" />
```
    You must add it to the CommandBar in the appropriate location. (For more info, see the Working with the overflow menu section.) How it's positioned in the UI is determined by where the button is in the markup. For example, if you want this button to appear as the last element in the primary commands, add it at the very end of the primary commands list.
    
    You can also customize the icon for the button. For more info, see the [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx) reference.

2. [
            **OnApplyTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.onapplytemplate.aspx) のオーバーライドで、テンプレートからボタンを取得し、その [**Click**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントのハンドラーを登録します。 次のコードを `CustomMediaTransportControls` クラスに追加します。 
```csharp
public sealed class CustomMediaTransportControls :  MediaTransportControls
{
    // ...

    protected override void OnApplyTemplate() 
    { 
        // Find the custom button and create an event handler for its Click event. 
        var likeButton = GetTemplateChild("LikeButton") as Button; 
        likeButton.Click += LikeButton_Click; 
        base.OnApplyTemplate(); 
    } 

    //...
}
```

3. Click イベント ハンドラーに、ボタンがクリックされたときに発生するアクションを実行するコードを追加します。
このクラスのコード全体を次に示します。
```csharp
public sealed class CustomMediaTransportControls : MediaTransportControls
{
    public event EventHandler< EventArgs> Liked;

    public CustomMediaTransportControls() 
    {
        this.DefaultStyleKey = typeof(CustomMediaTransportControls);
    }

    protected override void OnApplyTemplate()
    {
        // Find the custom button and create an event handler for its Click event. 
        var likeButton = GetTemplateChild("LikeButton") as Button;
        likeButton.Click += LikeButton_Click;
        base.OnApplyTemplate();
    }

    private void LikeButton_Click(object sender, RoutedEventArgs e)
    {
        // Raise an event on the custom control when 'like' is clicked. 
        var handler = Liked;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
}
```

### スライダーを変更する

MediaTransportControls の "seek" コントロールは、[**Slider**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx) 要素により提供されます。 このコントロールをカスタマイズする 1 つの方法として、シーク動作の細かさを変更できます。 

既定のシーク スライダーは 100 の部分に分かれているため、シーク動作はその数のセクションに限定されます。 シーク スライダーの細かさを変更するには、[**MediaOpened**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.mediaopened.aspx) イベント ハンドラーで XAML ビジュアル ツリーから Slider を取得します。 この例では、[**VisualTreeHelper**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.visualtreehelper.aspx) を使って Slider への参照を取得し、メディアが 120 分より長い場合に、スライダーの既定のステップ間隔を 1% から 0.1% (1000 ステップ) に変更する方法を示しています。 MediaElement には、`MediaElement1` という名前が付けられています。

```csharp
private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
{
  FrameworkElement transportControlsTemplateRoot = (FrameworkElement)VisualTreeHelper.GetChild(MediaElement1.TransportControls, 0);
  Slider sliderControl = (Slider)transportControlsTemplateRoot.FindName("ProgressSlider");
  if (sliderControl != null && MediaElement1.NaturalDuration.TimeSpan.TotalMinutes > 120)
  {
    // Default is 1%. Change to 0.1% for more granular seeking.
    sliderControl.StepFrequency = 0.1;
  }
}
```



## 関連記事

- [メディア再生](media-playback.md)


<!--HONumber=May16_HO2-->


