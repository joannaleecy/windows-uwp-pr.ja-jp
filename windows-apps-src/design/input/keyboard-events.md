---
Description: アプリでハードウェア キーボードやソフトウェア キーボードからのキーボード操作に応答するには、キーボード イベント ハンドラーとクラス イベント ハンドラーの両方を使います。
title: キーボード イベント
ms.assetid: ac500772-d6ed-4a3a-825b-210a9c3c8f59
label: Keyboard events
template: detail.hbs
keywords: キーボード, ゲームパッド, リモート, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作, キーのリリース, キーの押下
ms.date: 03/29/2017
ms.topic: article
pm-contact: chigy
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 9ff4e7d01d907112558993f52c8a214c91f7d499
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610457"
---
# <a name="keyboard-events"></a>キーボード イベント

## <a name="keyboard-events-and-focus"></a>キーボード イベントとフォーカス

次のキーボード イベントは、ハードウェア キーボードとタッチ キーボードの両方で発生します。

| イベント                                      | 説明                    |
|--------------------------------------------|--------------------------------|
| [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) | キーが押されると発生します。  |
| [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942)     | キーが離されると発生します。 |

> [!IMPORTANT]
> 一部の Windows ランタイム コントロールでは、入力イベントが内部で処理されます。 このような場合は、イベント リスナーに関連付けられているハンドラーが呼び出されないため、入力イベントが発生しないように見えることがあります。 通常、これらのキーのサブセットはクラス ハンドラーで処理され、基本的なキーボード アクセシビリティのビルトイン サポートが提供されます。 たとえば、[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) クラスでは、Space キーと Enter キーの [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982) イベント (および [**OnPointerPressed**](https://msdn.microsoft.com/library/windows/apps/hh967989)) がオーバーライドされ、コントロールの [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントにルーティングされます。 キーの押下がコントロール クラスで処理された場合、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントは発生しません。  
> これで、ボタンの実行に対応するキーボード操作が組み込まれ、ボタンを指でタップした場合やマウスでクリックした場合と同様の動作がサポートされます。 Space キーと Enter キー以外のキーについては、通常どおり [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) と [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。 クラス ベースのイベント処理の動作について詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」(特に「コントロールの入力イベント ハンドラー」セクション) をご覧ください。


UI のコントロールに入力フォーカスがあるときにだけ、キーボード イベントが生成されます。 個々のコントロールは、ユーザーがレイアウト上でコントロールを直接クリックまたはタップするか、Tab キーを使ってコンテンツ領域内のタブ順に入ると、フォーカスを取得します。

コントロールの [**Focus**](https://msdn.microsoft.com/library/windows/apps/hh702161) メソッドを呼び出して、フォーカスを適用することもできます。 これは、UI が読み込まれたときに既定ではキーボード フォーカスが設定されないため、ショートカット キーを実装する場合に必要です。 詳しくは、このトピックの「**ショートカット キーの例**」をご覧ください。

コントロールが入力フォーカスを受け取るには、コントロールが有効にされ、表示されている必要があります。また、[**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/br209422) プロパティ値と [**HitTestVisible**](https://msdn.microsoft.com/library/windows/apps/br208933) プロパティ値が **true** に設定されている必要もあります。 これは、ほとんどのコントロールの既定の状態です。 コントロールに入力フォーカスがあると、このトピックで後ほど説明するように、キーボード入力イベントを発生させ、応答することもできます。 また、[**GotFocus**](https://msdn.microsoft.com/library/windows/apps/br208927) イベントと [**LostFocus**](https://msdn.microsoft.com/library/windows/apps/br208943) イベントを処理して、フォーカスを受け取るコントロールやフォーカスを失うコントロールに応答することもできます。

既定では、コントロールのタブ順は、Extensible Application Markup Language (XAML) 内の出現順になっています。 ただし、[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/br209461) プロパティを使って、この順序を変更できます。 詳しくは、「[キーボード アクセシビリティの実装](https://msdn.microsoft.com/library/windows/apps/hh868161)」をご覧ください。

## <a name="keyboard-event-handlers"></a>キーボード イベント ハンドラー


入力イベント ハンドラーは、次の情報を提供するデリゲートを実装します。

-   イベントのセンダー。 センダーは、イベント ハンドラーがアタッチされているオブジェクトを報告します。
-   イベント データ。 キーボード イベントの場合、イベント データは [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072) のインスタンスです。 ハンドラーのデリゲートは [**KeyEventHandler**](https://msdn.microsoft.com/library/windows/apps/br227904) です。 ハンドラーに関するほとんどのシナリオで、最もよく使われる **KeyRoutedEventArgs** のプロパティは、[**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074) です。場合によっては、[**KeyStatus**](https://msdn.microsoft.com/library/windows/apps/hh943075) も使われます。
-   [**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810)します。 キーボード イベントはルーティング イベントであるため、イベント データには **OriginalSource** があります。 イベントがオブジェクト ツリーをバブルアップするように意図的に設定した場合、**OriginalSource** がセンダーではなく対象のオブジェクトとなる場合があります。 ただし、この動作は設計によって異なります。 センダーではなく **OriginalSource** を使う方法について詳しくは、このトピックの「キーボード ルーティング イベント」または「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」をご覧ください。

### <a name="attaching-a-keyboard-event-handler"></a>キーボード イベント ハンドラーのアタッチ

イベントがメンバーとして含まれているオブジェクトに対して、キーボード イベント ハンドラー関数をアタッチできます。 [  **UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) 派生クラスにもアタッチできます。 XAML で [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントのハンドラーをアタッチする方法を次の例に示します。

```xaml
<Grid KeyUp="Grid_KeyUp">
  ...
</Grid>
```

コードを使ってイベント ハンドラーをアタッチすることもできます。 詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」をご覧ください。

### <a name="defining-a-keyboard-event-handler"></a>キーボード イベント ハンドラーの定義

次の例は、前の例でアタッチした [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーの定義の一部です。

```csharp
void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
{
    //handling code here
}
```

```vb
Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As KeyRoutedEventArgs)
    ' handling code here
End Sub
```

```c++
void MyProject::MainPage::Grid_KeyUp(
  Platform::Object^ sender,
  Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
  {
      //handling code here
  }
```

### <a name="using-keyroutedeventargs"></a>KeyRoutedEventArgs の使用

キーボード イベントはいずれもイベント データに [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072) を使います。**KeyRoutedEventArgs** には次のプロパティがあります。

-   [**キー**](https://msdn.microsoft.com/library/windows/apps/hh943074)
-   [**KeyStatus**](https://msdn.microsoft.com/library/windows/apps/hh943075)
-   [**処理**](https://msdn.microsoft.com/library/windows/apps/hh943073)
-   [**OriginalSource** ](https://msdn.microsoft.com/library/windows/apps/br208810) (から継承された[ **RoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br208809))

### <a name="key"></a>Key

キーが押されると、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントが発生します。 同様に、キーが離されると、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。 通常、特定のキー値を処理するにはイベントをリッスンします。 押されたキーまたは離されたキーを特定するには、イベント データの [**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074) 値を調べます。 **Key** は [**VirtualKey**](https://msdn.microsoft.com/library/windows/apps/br241812) 値を返します。 **VirtualKey** 列挙体には、サポートされているすべてのキーが含まれています。

### <a name="modifier-keys"></a>修飾キー

修飾キーは、Ctrl、Shift など、一般的に他のキーと組み合わせて押されるキーです。 アプリでは、これらのキーの組み合わせをキーボード ショートカットとして使って、アプリ コマンドを呼び出すことができます。

ショートカット キーの組み合わせを検出するには、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベント ハンドラーや [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーでコードを使います。 目的とする修飾キーが押された状態を追跡することができます。 修飾キー以外のキーのキーボード イベントが発生した場合は、同時に修飾キーが押された状態になっていないかどうかを調べることができます。

> [!NOTE]
> Alt キーは **VirtualKey.Menu** 値で表されます。

 

### <a name="shortcut-keys-example"></a>ショートカット キーの例


ショートカット キーを実装する方法を次の例で示します。 この例では、ユーザーは [Play]、[Pause]、[Stop] の各ボタンまたは Ctrl + P、Ctrl + A、Ctrl + S の各キーボード ショートカットを使って、メディアの再生を制御できます。 ボタンの XAML では、ボタン ラベルのヒントや [**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/br209081) プロパティを使って、ショートカット キーを示します。 このアプリ内の説明は、アプリの操作性とアクセシビリティを向上させるために重要です。 詳しくは、「[キーボードのアクセシビリティ](https://msdn.microsoft.com/library/windows/apps/mt244347)」をご覧ください。

ページが読み込まれるときに、入力フォーカスをページそのものに設定していることにも注目してください。 この手順を実行しなければ、最初の入力フォーカスがどのコントロールにも設定されず、ユーザーが手動で入力フォーカスを設定する (Tab キーを使ってコントロールを選ぶ、コントロールをクリックするなど) までアプリで入力イベントが発生しません。

```xaml
<Grid KeyDown="Grid_KeyDown">

  <Grid.RowDefinitions>
    <RowDefinition Height="Auto" />
    <RowDefinition Height="Auto" />
  </Grid.RowDefinitions>

  <MediaElement x:Name="DemoMovie" Source="xbox.wmv"
    Width="500" Height="500" Margin="20" HorizontalAlignment="Center" />

  <StackPanel Grid.Row="1" Margin="10"
    Orientation="Horizontal" HorizontalAlignment="Center">

    <Button x:Name="PlayButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+P"
      AutomationProperties.AcceleratorKey="Control P">
      <TextBlock>Play</TextBlock>
    </Button>

    <Button x:Name="PauseButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+A"
      AutomationProperties.AcceleratorKey="Control A">
      <TextBlock>Pause</TextBlock>
    </Button>

    <Button x:Name="StopButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+S"
      AutomationProperties.AcceleratorKey="Control S">
      <TextBlock>Stop</TextBlock>
    </Button>

  </StackPanel>

</Grid>
```

```c++
//showing implementations but not header definitions
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
    (void) e;    // Unused parameter
    this->Loaded+=ref new RoutedEventHandler(this,&amp;MainPage::ProgrammaticFocus);
}
void MainPage::ProgrammaticFocus(Object^ sender, RoutedEventArgs^ e) {
    this->Focus(Windows::UI::Xaml::FocusState::Programmatic);
}

void KeyboardSupport::MainPage::MediaButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    FrameworkElement^ fe = safe_cast<FrameworkElement^>(sender);
    if (fe->Name == "PlayButton") {DemoMovie->Play();}
    if (fe->Name == "PauseButton") {DemoMovie->Pause();}
    if (fe->Name == "StopButton") {DemoMovie->Stop();}
}


bool KeyboardSupport::MainPage::IsCtrlKeyPressed()
{
    auto ctrlState = CoreWindow::GetForCurrentThread()->GetKeyState(VirtualKey::Control);
    return (ctrlState & CoreVirtualKeyStates::Down) == CoreVirtualKeyStates::Down;
}

void KeyboardSupport::MainPage::Grid_KeyDown(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
{
    if (e->Key == VirtualKey::Control) isCtrlKeyPressed = true;
}


void KeyboardSupport::MainPage::Grid_KeyUp(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
{
    if (IsCtrlKeyPressed()) {
        if (e->Key==VirtualKey::P) { DemoMovie->Play(); }
        if (e->Key==VirtualKey::A) { DemoMovie->Pause(); }
        if (e->Key==VirtualKey::S) { DemoMovie->Stop(); }
    }
}
```

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    // Set the input focus to ensure that keyboard events are raised.
    this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
}

private void MediaButton_Click(object sender, RoutedEventArgs e)
{
    switch ((sender as Button).Name)
    {
        case "PlayButton": DemoMovie.Play(); break;
        case "PauseButton": DemoMovie.Pause(); break;
        case "StopButton": DemoMovie.Stop(); break;
    }
}

private static bool IsCtrlKeyPressed()
{
    var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
    return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
}

private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
{
    if (IsCtrlKeyPressed())
    {
        switch (e.Key)
        {
            case VirtualKey.P: DemoMovie.Play(); break;
            case VirtualKey.A: DemoMovie.Pause(); break;
            case VirtualKey.S: DemoMovie.Stop(); break;
        }
    }
}
```

```VisualBasic
Private isCtrlKeyPressed As Boolean
Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)

End Sub

Private Function IsCtrlKeyPressed As Boolean
    Dim ctrlState As CoreVirtualKeyStates = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
    Return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
End Function

Private Sub Grid_KeyDown(sender As Object, e As KeyRoutedEventArgs)
    If IsCtrlKeyPressed() Then
        Select Case e.Key
            Case Windows.System.VirtualKey.P
                DemoMovie.Play()
            Case Windows.System.VirtualKey.A
                DemoMovie.Pause()
            Case Windows.System.VirtualKey.S
                DemoMovie.Stop()
        End Select
    End If
End Sub

Private Sub MediaButton_Click(sender As Object, e As RoutedEventArgs)
    Dim fe As FrameworkElement = CType(sender, FrameworkElement)
    Select Case fe.Name
        Case "PlayButton"
            DemoMovie.Play()
        Case "PauseButton"
            DemoMovie.Pause()
        Case "StopButton"
            DemoMovie.Stop()
    End Select
End Sub
```

> [!NOTE]
> XAML で [**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/hh759762) または [**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/hh759763) を設定すると、(その特定の操作を呼び出すためのショートカット キーを説明する) 文字列情報が提供されます。 この情報は、ナレーターなどの Microsoft UI オートメーション クライアントによってキャプチャされ、通常は、直接ユーザーに提供されます。
>
> **AutomationProperties.AcceleratorKey** または **AutomationProperties.AccessKey** を設定しても、それだけでは操作は実行されません。 実際にアプリにキーボード ショートカットの動作を実装するには、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントまたは [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントのハンドラーをアタッチする必要があります。 また、アクセス キーの下線も自動的には追加されません。 UI で下線付きのテキストを表示する場合は、インラインの [**Underline**](https://msdn.microsoft.com/library/windows/apps/br209982) 書式設定として、ニーモニックの特定のキーのテキストに明示的に下線を表示する必要があります。

 

## <a name="keyboard-routed-events"></a>キーボード ルーティング イベント


[  **KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) や、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) などの特定のイベントがルーティング イベントです。 ルーティング イベントでは、バブル ルーティング方式が採用されています。 バブル ルーティング方式では、子オブジェクトで発生したイベントが、オブジェクト ツリー内で上位にある親オブジェクトに順にルーティング (バブルアップ) されます。 つまり、同じイベントを処理し、同じイベント データを操作する機会が増えることを意味します。

次の XAML の例では、1 つの [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) と 2 つの [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) オブジェクトについて、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントを処理します。 この場合、どちらかの **Button** オブジェクトにフォーカスがある間にキーを離すと、**KeyUp** イベントが発生します。 イベントはその後、親 **Canvas** までバブルアップされます。

```xaml
<StackPanel KeyUp="StackPanel_KeyUp">
  <Button Name="ButtonA" Content="Button A"/>
  <Button Name="ButtonB" Content="Button B"/>
  <TextBlock Name="statusTextBlock"/>
</StackPanel>
```

次の例は、前に示した XAML コンテンツに対応する [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーの実装方法を示しています。

```csharp
void StackPanel_KeyUp(object sender, KeyRoutedEventArgs e)
{
    statusTextBlock.Text = String.Format(
        "The key {0} was pressed while focus was on {1}",
        e.Key.ToString(), (e.OriginalSource as FrameworkElement).Name);
}
```

このハンドラーで [**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810) プロパティが使われていることに注意してください。 この例では、**OriginalSource** がイベントの発生元のオブジェクトを報告します。 **StackPanel** はコントロールではなく、フォーカスを受け取ることもできないため、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) がこのオブジェクトになることはありません。 **StackPanel** 内の 2 つのボタンのどちらか 1 つのみがイベントの発生元である可能性がありますが、発生元を調べるにはどうすればよいでしょうか。 親オブジェクトのイベントを処理する場合は、**OriginalSource** を使って、実際のイベント ソース オブジェクトを判別します。

### <a name="the-handled-property-in-event-data"></a>イベント データ内の Handled プロパティ

イベント処理の方針によっては、1 つのイベント ハンドラーだけがバブル イベントに応答するようにした方がよい場合もあります。 たとえば、[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) コントロールの 1 つに、特定の [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) ハンドラーをアタッチすると、最初にそのイベントを処理するのは、このハンドラーがアタッチされたコントロールになります。 このとき、親パネルではイベントが処理されないようにします。 このようなシナリオでは、イベント データ内の [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) プロパティを使います。

ルーティング イベント データ クラスの [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) プロパティは、イベント ルート上で先に登録された別のハンドラーが既に処理を実行したことを示すためのプロパティで、 ルーティング イベント システムの動作に影響します。 イベント ハンドラー内で **Handled** を **true** に設定すると、そのイベントのルーティングはそこで終了し、上位の親要素にイベントは送信されません。

### <a name="addhandler-and-already-handled-keyboard-events"></a>AddHandler イベントと処理済みキーボード イベント

特殊な方法を利用して、既に処理済みとしてマークされているイベントに対して処理を実行できるハンドラーをアタッチすることができます。 この手法を使用して、 [ **AddHandler** ](https://msdn.microsoft.com/library/windows/apps/hh702399) XAML 属性または言語固有の構文を使用して、c + = などのハンドラーを追加するためのではなく、ハンドラーを登録するメソッド\#します。

一般的に、この方法には、**AddHandler** API が [**RoutedEvent**](https://msdn.microsoft.com/library/windows/apps/br208808) 型のパラメーターを受け取るという制限があります。このパラメーターで対象のルーティング イベントを識別します。 一部のルーティング イベントには **RoutedEvent** 識別子がないため、[**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) の状態でも処理できるルーティング イベントを識別する場合に考慮する必要があります。 [  **UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) の [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントには、ルーティング イベント識別子 ([**KeyDownEvent**](https://msdn.microsoft.com/library/windows/apps/hh702416) と [**KeyUpEvent**](https://msdn.microsoft.com/library/windows/apps/hh702418)) があります。 これに対し、[**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/br209706) などのイベントにはルーティング イベント識別子がないため、**AddHandler** を使う手法には利用できません。

### <a name="overriding-keyboard-events-and-behavior"></a>キーボード イベントと動作のオーバーライド

特定のコントロールのキー イベント (たとえば [**GridView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridView) など) をオーバーライドして、キーボードとゲームパッドを含むさまざまな入力デバイスに一貫したフォーカス ナビゲーションを提供できます。

次の例では、私たちのコントロールをサブクラス化とオーバーライド KeyDown 動作を GridView にフォーカスを移動するコンテンツの任意の方向キーが押されたときにします。

```csharp
public class CustomGridView : GridView
  {
    protected override void OnKeyDown(KeyRoutedEventArgs e)
    {
      // Override arrow key behaviors.
      if (e.Key != Windows.System.VirtualKey.Left && e.Key !=
        Windows.System.VirtualKey.Right && e.Key !=
          Windows.System.VirtualKey.Down && e.Key !=
            Windows.System.VirtualKey.Up)
              base.OnKeyDown(e);
      else
        FocusManager.TryMoveFocus(FocusNavigationDirection.Down);
    }
  }
```

> [!NOTE]
> GridView がレイアウトのみに使用されている場合には、[**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsControl) と [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsWrapGrid) などの、他のコントロールの使用を検討します。

## <a name="commanding"></a>コマンド実行

ごく一部の UI 要素では、コマンド実行が組み込みでサポートされています。 コマンド実行の基になる実装では、入力に関連するルーティング イベントを使います。 この方法では、1 つのコマンド ハンドラーを呼び出して、特定のポインター操作、特定のショートカット キーなどの関連する UI 入力を処理できます。

UI 要素でコマンド実行を使うことができる場合は、個々の入力イベントではなく、コマンド実行 API を使うことを検討してください。 詳しくは、「[**ButtonBase.Command**](https://msdn.microsoft.com/library/windows/apps/br227740)」をご覧ください。

[  **ICommand**](https://msdn.microsoft.com/library/windows/apps/br227885) を実装して、通常のイベント ハンドラーから呼び出すコマンド機能をカプセル化することもできます。 この方法では、**Command** プロパティを利用できない場合でも、コマンド実行を使うことができます。

## <a name="text-input-and-controls"></a>テキスト入力とコントロール

キーボード イベントに固有の処理で対応するコントロールもあります。 たとえば、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) は、キーボードを使って入力されたテキストをキャプチャし、表示するためのコントロールです。 このコントロールでは、キーボード操作をキャプチャするために、固有のロジックで [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) と [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) が使われます。また、テキストが実際に変化した場合には、固有の [**TextChanged**](https://msdn.microsoft.com/library/windows/apps/br209706) イベントを発生させます。

また、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) などのテキスト入力の処理を目的としたコントロールに、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) や [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) のハンドラーを追加することも通常どおりできます。 ただし、コントロールは、その設計上、キー イベントを通じて伝達されたすべてのキー値に応答するわけではありません。 動作はコントロールによって異なります。

たとえば、[**ButtonBase**](https://msdn.microsoft.com/library/windows/apps/br227736) ([**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) の基底クラス) では、Space キーや Enter キーの操作を確認するために [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) が処理されます。 **ButtonBase** では **KeyUp** を、[**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントを発生させるマウスの左ボタンを押す操作と同等と見なします。 このイベント処理は、**ButtonBase** が仮想メソッド [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983) をオーバーライドする際に実現されます。 この実装では、[**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) が **true** に設定されます。 このため、あるボタンの親がキー イベント (たとえば Space バー) をリッスンしていても、既に処理されたイベントをハンドラーで受け取ることはありません。

別の例としては、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) があります。 方向キーなどの一部のキーは **TextBox** ではテキストと見なされず、コントロール UI 動作に固有のキーと見なされます。 **TextBox** は、これらのイベント ケースを処理済みとしてマークします。

カスタム コントロールで [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982) / [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983) をオーバーライドすると、キー イベントに対する同様のオーバーライド動作を独自に実装できます。 カスタム コントロールで特定のショートカット キーを処理する場合、または [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) の説明で示したシナリオのようなコントロールの動作またはフォーカスの動作を使う場合、**OnKeyDown** / **OnKeyUp** のオーバーライドにこのロジックを組み込む必要があります。

## <a name="the-touch-keyboard"></a>タッチ キーボード

テキスト入力コントロールでは、タッチ キーボードが自動的にサポートされます。 ユーザーがタッチ入力を使って、テキスト コントロールに入力フォーカスを設定すると、タッチ キーボードが自動的に表示されます。 入力フォーカスがテキスト コントロールにないときには、タッチ キーボードが表示されません。

タッチ キーボードが表示されると、フォーカスがある要素をユーザーが見ることができるように、UI が自動的に再配置されます。 この場合、他の重要な UI 領域が画面の表示領域外に移動することがあります。 ただし、タッチ キーボードが表示されたときの既定の動作を無効にして、独自に UI を調整することができます。 詳しくは、[タッチ キーボードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)をご覧ください。

テキスト入力を必要とするカスタム コントロールを、標準のテキスト入力コントロールからの派生コントロールとして作成しない場合は、適切な UI オートメーション コントロール パターンを実装してタッチ キーボードを追加し、サポートできます。 詳しくは、[タッチ キーボードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)をご覧ください。

タッチ キーボードのキーが押されると、ハードウェア キーボードのキーが押されたとき同様に、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。 ただし、タッチ キーボードでは、Ctrl + A、Ctrl + Z、Ctrl + X、Ctrl + C、Ctrl + V に対応する入力イベントは発生しません。これらは、入力コントロールでテキストを操作するために予約されています。

ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの入力値の種類を設定することで、ユーザーがより速く簡単にアプリにデータを入力できるようになります。 入力値の種類は、コントロールが予期しているテキスト入力の種類のヒントとなるため、システムが、その入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。 たとえば、テキスト ボックスが 4 桁の PIN の入力専用の場合は、[**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) プロパティを [**Number**](https://msdn.microsoft.com/library/windows/apps/hh702028) に設定します。 これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。 詳しくは、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」をご覧ください。

## <a name="related-articles"></a>関連記事

**開発者向け**
* [キーボードの相互作用](keyboard-interactions.md)
* [入力デバイスの識別](identify-input-devices.md)
* [タッチ キーボードの存在に応答します。](respond-to-the-presence-of-the-touch-keyboard.md)

**デザイナー向け**
* [キーボードの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/hh972345)

**サンプル**
* [タッチ キーボードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)
* [基本的な入力サンプル](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [低待機時間の入力サンプル](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)

**サンプルのアーカイブ**
* [入力サンプル](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [入力:デバイス機能のサンプル](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [入力:タッチ キーボードのサンプル](https://go.microsoft.com/fwlink/p/?linkid=246019)
* [外観に応答して、スクリーン キーボードのサンプル](https://go.microsoft.com/fwlink/p/?linkid=231633)
* [XAML テキスト編集のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=251417)
 

 
