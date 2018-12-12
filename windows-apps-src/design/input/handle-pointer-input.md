---
Description: Receive, process, and manage input data from pointing devices such as touch, mouse, pen/stylus, and touchpad, in your Universal Windows Platform (UWP) applications.
title: ポインター入力の処理
ms.assetid: BDBC9E33-4037-4671-9596-471DCF855C82
label: Handle pointer input
template: detail.hbs
keywords: ペン, マウス, タッチパッド, タッチ, ポインター, 入力, ユーザー操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: d5a51bd55a081265b4a90dfa662216977d1bded2
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8933380"
---
# <a name="handle-pointer-input"></a>ポインター入力の処理

ユニバーサル Windows プラットフォーム (UWP) アプリケーションで、ポインティング デバイス (タッチ、マウス、ペン/スタイラス、タッチパッドなど) からの入力データを受け取り、処理、管理します。

> [!Important]
> 明確で適切に定義された要件があり、プラットフォーム コントロールが対応している操作ではシナリオがサポートされない場合にのみ、カスタムの操作を作成してください。  
> Windows アプリケーションでの操作エクスペリエンスをカスタマイズすると、ユーザーは、それらのエクスペリエンスは一貫性があり、直感的で、見つけやすいものであることを期待します。 このため、カスタム操作は[プラットフォーム コントロール](../controls-and-patterns/controls-by-function.md)でサポートされている操作に基づいて作成することをお勧めします。 プラットフォーム コントロールには、標準的な操作、アニメーション化された物理的効果、視覚的フィードバック、アクセシビリティなど、ユニバーサル Windows プラットフォーム (UWP) の完全なユーザー操作エクスペリエンスが用意されています。 

## <a name="important-apis"></a>重要な API
- [Windows.Devices.Input](https://msdn.microsoft.com/library/windows/apps/br225648)
- [Windows.UI.Input](https://msdn.microsoft.com/library/windows/apps/br208383)
- [Windows.UI.Xaml.Input](https://msdn.microsoft.com/library/windows/apps/br242084)

## <a name="pointers"></a>ポインター
ほとんどの操作エクスペリエンスでは、通常ユーザーが、タッチ、マウス、ペン/スタイラス、タッチパッドなどの入力デバイスを使ってポイントすることによって、操作の対象となるオブジェクトを特定します。 これらの入力デバイスによって提供される生のヒューマン インターフェイス デバイス (HID) のデータには、多くの共通するプロパティが含まれているため、データは統合入力スタックに昇格および集約され、デバイスに依存しないポインター データとして公開されます。 このため、UWP アプリケーションでは、使われている入力デバイスを意識することなく、このデータを利用できます。

> [!NOTE]
> アプリで必要な場合は、デバイス固有の情報も HID の生データから昇格されます。
 

入力スタックの各入力ポイント (または接触) は、さまざまなポインター イベント ハンドラーの [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) パラメーターによって公開される [**Pointer**](https://msdn.microsoft.com/library/windows/apps/br227968) オブジェクトで表されます。 マルチペンまたはマルチタッチ入力の場合、各接触は固有の入力ポインターとして扱われます。

## <a name="pointer-events"></a>ポインター イベント


ポインター イベントは、入力デバイスの種類や (範囲または接触の) 検出状態などの基本情報、および位置、圧力、接触形状などの拡張情報を公開します。 さらに、ユーザーが押したマウス ボタンは何か、ペンの消しゴム ボタンは使われているかなど、特定のデバイスのプロパティも使うことができます。 アプリで入力デバイスとその機能を区別する必要がある場合は、「[入力デバイスの識別](identify-input-devices.md)」をご覧ください。

UWP アプリでは、次のポインター イベントをリッスンすることができます。

> [!NOTE]
> ポインターの入力を特定の UI 要素に制限するには、ポインター イベント ハンドラー内で、その要素に対して [**CapturePointer**](https://msdn.microsoft.com/library/windows/apps/br208918) を呼び出します。 要素によってポインターがキャプチャされると、そのオブジェクトだけがポインター入力イベントを受け取ります。これは、ポインターがオブジェクトの境界領域の外部に移動した場合でも同様です。 **CapturePointer** が成功するには、[**IsInContact**](https://msdn.microsoft.com/library/windows/apps/br227976) (マウス ボタンの押下、タッチやスタイラスの接触) が true であることが必要です。
 

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">イベント</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208964"><strong>PointerCanceled</strong></a></p></td>
<td align="left"><p>プラットフォームでポインターが取り消されると発生します。 これは、次のような場合に発生することがあります。</p>
<ul>
<li>入力サーフェスの範囲内でペンが検出されると、タッチ ポインターは取り消されます。</li>
<li>100 ミリ秒を超えてもアクティブな接触が検出されません。</li>
<li>モニター/ディスプレイが変更されました (解像度、設定、マルチモニター構成)。</li>
<li>デスクトップがロックされているか、ユーザーがログオフしました。</li>
<li>同時に接触した数がデバイスでサポートされる数を超えています。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208965"><strong>PointerCaptureLost</strong></a></p></td>
<td align="left"><p>別の UI 要素がポインターをキャプチャしたか、ポインターが離されたか、別のポインターがプログラムでキャプチャされたときに発生します。</p>
<div class="alert">
<strong>注:</strong>対応するポインター キャプチャ イベントはありません。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208968"><strong>PointerEntered</strong></a></p></td>
<td align="left"><p>ポインターが要素の境界領域内に入ったときに発生します。 これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</p>
<ul>
<li>タッチでは、このイベントが発生するには、直接タッチするか、要素の境界領域内に移動することによって、指が接触する必要があります。</li>
<li>マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</li>
<li>タッチと同様に、直接ペンでタッチするか、要素の境界領域内に移動することによって、このイベントが起動されます。 ただし、ペンにはホバー状態 ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、true の場合に、このイベントが発生します。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208969"><strong>PointerExited</strong></a></p></td>
<td align="left"><p>ポインターが要素の境界領域から出たときに発生します。 これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</p>
<ul>
<li>タッチでは、指が接触している必要があり、ポインターが要素の境界領域から外へ移動したときにこのイベントが発生します。</li>
<li>マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</li>
<li>タッチと同様に、ペンでは、要素の境界領域の外へ移動したときにこのイベントが発生します。 ただし、ペンにはホバー状態 ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、状態が true から false に変化したときに、このイベントが発生します。</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208970"><strong>PointerMoved</strong></a></p></td>
<td align="left"><p>要素の境界領域内で、ポインターの座標、ボタンの状態、圧力、傾き、または接触形状 (たとえば、幅と高さ) が変化したときに発生します。 これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</p>
<ul>
<li>タッチでは、指が接触している必要があり、要素の境界領域内に接触した場合にのみ、このイベントが発生します。</li>
<li>マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</li>
<li>タッチと同様に、ペンでは、要素の境界領域内に接触したときにこのイベントが発生します。 ただし、ペンにはホバー状態 ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、状態が true で、要素の境界領域内にあるときに、このイベントが発生します。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208971"><strong>PointerPressed</strong></a></p></td>
<td align="left"><p>要素の境界領域内でポインターを押すアクション (タッチして押す、マウス ボタンを押す、ペンで押す、タッチパッドのボタンを押すなど) を行うと発生します。</p>
<p>このイベントのハンドラーから [CapturePointer](https://msdn.microsoft.com/library/windows/apps/br208918) を呼び出す必要があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208972"><strong>PointerReleased</strong></a></p></td>
<td align="left"><p>要素の境界領域内でポインターを離すアクション (タッチを離す、マウス ボタンを離す、ペンを離す、タッチパッドのボタンを離すなど) を行ったとき、またはポインターが境界領域の外部でキャプチャされた場合に発生します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208973"><strong>PointerWheelChanged</strong></a></p></td>
<td align="left"><p>マウス ホイールが回転したときに発生します。</p>
<p>マウス入力が最初に検出されたときに、マウス入力が、割り当てられている単一のポインターと関連付けられます。 マウス ボタン (左ボタン、ホイール、または右ボタン) をクリックすると、[PointerMoved](https://msdn.microsoft.com/library/windows/apps/br208970) イベントによってポインターとそのボタンの間に 2 番目の関連付けが行われます。</p></td>
</tr>
</tbody>
</table> 

## <a name="pointer-event-example"></a>ポインター イベントの例

ここでは、基本的なポインター追跡アプリのコード スニペットを示し、複数のポインター イベントをリッスンして処理し、関連付けられたポインターのさまざまなプロパティを取得する方法について説明します。

![ポインター アプリケーションの UI](images/pointers/pointers1.gif)

**このサンプルは、「[Pointer input sample (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers.zip)」(ポインター入力のサンプル (基本)) でダウンロードしてください。**

### <a name="create-the-ui"></a>UI を作成する

この例では、ポインター入力を利用するオブジェクトとして [Rectangle](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.shapes.rectangle) (`Target`) を使います。 ポインターの状態が変わると、ターゲットの色が変わります。

ポインターの移動に従って動く浮動の [TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) に、各ポインターの詳細が表示されます。 ポインター イベント自体は、四角形の右側にある [RichTextBlock](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.RichTextBlock) で報告されます。

この例の UI で使われる Extensible Application Markup Language (XAML) を次に示します。 

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="250"/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="320" />
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Canvas Name="Container" 
            Grid.Column="0"
            Grid.Row="1"
            HorizontalAlignment="Center" 
            VerticalAlignment="Center" 
            Margin="245,0" 
            Height="320"  Width="640">
        <Rectangle Name="Target" 
                    Fill="#FF0000" 
                    Stroke="Black" 
                    StrokeThickness="0"
                    Height="320" Width="640" />
    </Canvas>
    <Grid Grid.Column="1" Grid.Row="0" Grid.RowSpan="3">
        <Grid.RowDefinitions>
            <RowDefinition Height="50" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Button Name="buttonClear" 
                Grid.Row="0"
                Content="Clear"
                Foreground="White"
                HorizontalAlignment="Stretch" 
                VerticalAlignment="Stretch">
        </Button>
        <ScrollViewer Name="eventLogScrollViewer" Grid.Row="1" 
                        VerticalScrollMode="Auto" 
                        Background="Black">                
            <RichTextBlock Name="eventLog"  
                        TextWrapping="Wrap" 
                        Foreground="#FFFFFF" 
                        ScrollViewer.VerticalScrollBarVisibility="Visible" 
                        ScrollViewer.HorizontalScrollBarVisibility="Disabled"
                        Grid.ColumnSpan="2">
            </RichTextBlock>
        </ScrollViewer>
    </Grid>
</Grid>
```

### <a name="listen-for-pointer-events"></a>ポインター イベントをリッスンする

ほとんどの場合は、イベント ハンドラーの [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) を介してポインター情報を取得することをお勧めします。

必要なポインターの詳細をイベント引数が公開していない場合は、[**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) の [**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/hh943077) メソッドと [**GetIntermediatePoints**](https://msdn.microsoft.com/library/windows/apps/hh943078) メソッドによって公開される拡張 [**PointerPoint**](https://msdn.microsoft.com/library/windows/apps/br242038) 情報にアクセスできます。

次のコードでは、アクティブな各ポインターを追跡するためのグローバル ディクショナリ オブジェクトを設定し、ターゲット オブジェクトのさまざまなポインター イベント リスナーを識別しています。

```CSharp
// Dictionary to maintain information about each active pointer. 
// An entry is added during PointerPressed/PointerEntered events and removed 
// during PointerReleased/PointerCaptureLost/PointerCanceled/PointerExited events.
Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;

public MainPage()
{
    this.InitializeComponent();

    // Initialize the dictionary.
    pointers = new Dictionary<uint, Windows.UI.Xaml.Input.Pointer>();

    // Declare the pointer event handlers.
    Target.PointerPressed += 
        new PointerEventHandler(Target_PointerPressed);
    Target.PointerEntered += 
        new PointerEventHandler(Target_PointerEntered);
    Target.PointerReleased += 
        new PointerEventHandler(Target_PointerReleased);
    Target.PointerExited += 
        new PointerEventHandler(Target_PointerExited);
    Target.PointerCanceled += 
        new PointerEventHandler(Target_PointerCanceled);
    Target.PointerCaptureLost += 
        new PointerEventHandler(Target_PointerCaptureLost);
    Target.PointerMoved += 
        new PointerEventHandler(Target_PointerMoved);
    Target.PointerWheelChanged += 
        new PointerEventHandler(Target_PointerWheelChanged);

    buttonClear.Click += 
        new RoutedEventHandler(ButtonClear_Click);
}
```

### <a name="handle-pointer-events"></a>ポインター イベントを処理する

次に、UI フィードバックを使って基本的なポインター イベント ハンドラーを示します。

-   このハンドラーは、[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントを管理します。 イベント ログにイベントを追加し、アクティブなポインターのディクショナリにポインターを追加して、ポインターの詳細を表示します。

    > [!NOTE]
    > [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントと [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントは、常にペアで発生するわけではありません。 アプリでは、ポインターの押下を終了させる可能性のあるすべてのイベント ([**PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208969)、[**PointerCanceled**](https://msdn.microsoft.com/library/windows/apps/br208964)、[**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) など) をリッスンして処理する必要があります。      

```csharp
/// <summary>
/// The pointer pressed event handler.
/// PointerPressed and PointerReleased don't always occur in pairs. 
/// Your app should listen for and handle any event that can conclude 
/// a pointer down (PointerExited, PointerCanceled, PointerCaptureLost).
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Down: " + ptrPt.PointerId);

    // Lock the pointer to the target.
    Target.CapturePointer(e.Pointer);

    // Update event log.
    UpdateEventLog("Pointer captured: " + ptrPt.PointerId);

    // Check if pointer exists in dictionary (ie, enter occurred prior to press).
    if (!pointers.ContainsKey(ptrPt.PointerId))
    {
        // Add contact to dictionary.
        pointers[ptrPt.PointerId] = e.Pointer;
    }

    // Change background color of target when pointer contact detected.
    Target.Fill = new SolidColorBrush(Windows.UI.Colors.Green);

    // Display pointer details.
    CreateInfoPop(ptrPt);
}
```

-   このハンドラーは、[**PointerEntered**](https://msdn.microsoft.com/library/windows/apps/br208968) イベントを管理します。 イベント ログにイベントを追加し、ポインター コレクションにポインターを追加して、ポインターの詳細を表示します。

```csharp
/// <summary>
/// The pointer entered event handler.
/// We do not capture the pointer on this event.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerEntered(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Entered: " + ptrPt.PointerId);

    // Check if pointer already exists (if enter occurred prior to down).
    if (!pointers.ContainsKey(ptrPt.PointerId))
    {
        // Add contact to dictionary.
        pointers[ptrPt.PointerId] = e.Pointer;
    }

    if (pointers.Count == 0)
    {
        // Change background color of target when pointer contact detected.
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
    }

    // Display pointer details.
    CreateInfoPop(ptrPt);
}
```

-   このハンドラーは、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208970) イベントを管理します。 イベント ログにイベントを追加し、ポインターの詳細を更新します。

    > [!Important]
    > マウス入力が最初に検出されたときに、マウス入力が、割り当てられている単一のポインターと関連付けられます。 マウス ボタン (左ボタン、ホイール、または右ボタン) をクリックすると、[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントによってポインターとそのボタンの間に 2 番目の関連付けが行われます。 [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントは、同じマウス ボタンを離したときにだけ発生します (イベントが完了するまではそのポインターに他のボタンが関連付けられることはありません)。 この排他的な関連付けのために、他のマウス ボタンをクリックした場合は、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208970) イベントによってルーティングされます。     

```csharp
/// <summary>
/// The pointer moved event handler.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerMoved(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Multiple, simultaneous mouse button inputs are processed here.
    // Mouse input is associated with a single pointer assigned when 
    // mouse input is first detected. 
    // Clicking additional mouse buttons (left, wheel, or right) during 
    // the interaction creates secondary associations between those buttons 
    // and the pointer through the pointer pressed event. 
    // The pointer released event is fired only when the last mouse button 
    // associated with the interaction (not necessarily the initial button) 
    // is released. 
    // Because of this exclusive association, other mouse button clicks are 
    // routed through the pointer move event.          
    if (ptrPt.PointerDevice.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
    {
        if (ptrPt.Properties.IsLeftButtonPressed)
        {
            UpdateEventLog("Left button: " + ptrPt.PointerId);
        }
        if (ptrPt.Properties.IsMiddleButtonPressed)
        {
            UpdateEventLog("Wheel button: " + ptrPt.PointerId);
        }
        if (ptrPt.Properties.IsRightButtonPressed)
        {
            UpdateEventLog("Right button: " + ptrPt.PointerId);
        }
    }

    // Display pointer details.
    UpdateInfoPop(ptrPt);
}
```

-   このハンドラーは、[**PointerWheelChanged**](https://msdn.microsoft.com/library/windows/apps/br208973) イベントを管理します。 イベント ログにイベントを追加し、ポインター配列にポインターを追加して (必要な場合)、ポインターの詳細を表示します。

```csharp
/// <summary>
/// The pointer wheel event handler.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Mouse wheel: " + ptrPt.PointerId);

    // Check if pointer already exists (for example, enter occurred prior to wheel).
    if (!pointers.ContainsKey(ptrPt.PointerId))
    {
        // Add contact to dictionary.
        pointers[ptrPt.PointerId] = e.Pointer;
    }

    // Display pointer details.
    CreateInfoPop(ptrPt);
}
```

-   このハンドラーは、デジタイザーとの接触の終了を示す [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントを管理します。 イベント ログにイベントを追加し、ポインター コレクションからポインターを削除して、ポインターの詳細を更新します。

```csharp
/// <summary>
/// The pointer released event handler.
/// PointerPressed and PointerReleased don't always occur in pairs. 
/// Your app should listen for and handle any event that can conclude 
/// a pointer down (PointerExited, PointerCanceled, PointerCaptureLost).
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
void Target_PointerReleased(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Up: " + ptrPt.PointerId);

    // If event source is mouse or touchpad and the pointer is still 
    // over the target, retain pointer and pointer details.
    // Return without removing pointer from pointers dictionary.
    // For this example, we assume a maximum of one mouse pointer.
    if (ptrPt.PointerDevice.PointerDeviceType != Windows.Devices.Input.PointerDeviceType.Mouse)
    {
        // Update target UI.
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Red);

        DestroyInfoPop(ptrPt);

        // Remove contact from dictionary.
        if (pointers.ContainsKey(ptrPt.PointerId))
        {
            pointers[ptrPt.PointerId] = null;
            pointers.Remove(ptrPt.PointerId);
        }

        // Release the pointer from the target.
        Target.ReleasePointerCapture(e.Pointer);

        // Update event log.
        UpdateEventLog("Pointer released: " + ptrPt.PointerId);
    }
    else
    {
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
    }
}
```

-   このハンドラーは、[**PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208969) イベントを管理します (デジタイザーとの接触を維持する場合)。 イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。

```csharp
/// <summary>
/// The pointer exited event handler.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerExited(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Pointer exited: " + ptrPt.PointerId);

    // Remove contact from dictionary.
    if (pointers.ContainsKey(ptrPt.PointerId))
    {
        pointers[ptrPt.PointerId] = null;
        pointers.Remove(ptrPt.PointerId);
    }

    if (pointers.Count == 0)
    {
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
    }

    // Update the UI and pointer details.
    DestroyInfoPop(ptrPt);
}
```

-   このハンドラーは、[**PointerCanceled**](https://msdn.microsoft.com/library/windows/apps/br208964) イベントを管理します。 イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。

```csharp
/// <summary>
/// The pointer canceled event handler.
/// Fires for various reasons, including: 
///    - Touch contact canceled by pen coming into range of the surface.
///    - The device doesn't report an active contact for more than 100ms.
///    - The desktop is locked or the user logged off. 
///    - The number of simultaneous contacts exceeded the number supported by the device.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerCanceled(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Pointer canceled: " + ptrPt.PointerId);

    // Remove contact from dictionary.
    if (pointers.ContainsKey(ptrPt.PointerId))
    {
        pointers[ptrPt.PointerId] = null;
        pointers.Remove(ptrPt.PointerId);
    }

    if (pointers.Count == 0)
    {
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
    }

    DestroyInfoPop(ptrPt);
}
```

-   このハンドラーは、[**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) イベントを管理します。 イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。

    > [!NOTE]
    > [**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) が [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) の代わりに発生することがあります。 ポインターのキャプチャは、さまざまな理由で失われることがあります。たとえば、ユーザーの操作、プログラムによる別のポインターのキャプチャ、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) の呼び出しなどが原因となります。     

```csharp
/// <summary>
/// The pointer capture lost event handler.
/// Fires for various reasons, including: 
///    - User interactions
///    - Programmatic capture of another pointer
///    - Captured pointer was deliberately released
// PointerCaptureLost can fire instead of PointerReleased. 
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Pointer capture lost: " + ptrPt.PointerId);

    if (pointers.Count == 0)
    {
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
    }

    // Remove contact from dictionary.
    if (pointers.ContainsKey(ptrPt.PointerId))
    {
        pointers[ptrPt.PointerId] = null;
        pointers.Remove(ptrPt.PointerId);
    }

    DestroyInfoPop(ptrPt);
}
```

### <a name="get-pointer-properties"></a>ポインターのプロパティを取得する

前に説明したように、ほとんどの拡張ポインター情報は、[**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) の [**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/hh943077) メソッドと [**GetIntermediatePoints**](https://msdn.microsoft.com/library/windows/apps/hh943078) メソッドで取得した [**Windows.UI.Input.PointerPoint**](https://msdn.microsoft.com/library/windows/apps/br242038) オブジェクトから取得する必要があります。 次のコード スニペットでその方法を示します。

-   最初に、ポインターごとに新しい [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) を作成します。

```csharp
/// <summary>
/// Create the pointer info popup.
/// </summary>
/// <param name="ptrPt">Reference to the input pointer.</param>
void CreateInfoPop(PointerPoint ptrPt)
{
    TextBlock pointerDetails = new TextBlock();
    pointerDetails.Name = ptrPt.PointerId.ToString();
    pointerDetails.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
    pointerDetails.Text = QueryPointer(ptrPt);

    TranslateTransform x = new TranslateTransform();
    x.X = ptrPt.Position.X + 20;
    x.Y = ptrPt.Position.Y + 20;
    pointerDetails.RenderTransform = x;

    Container.Children.Add(pointerDetails);
}
```

-   次に、そのポインターと関連付けられた、既にある [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) でポインター情報を更新するための手段を提供します。

```csharp
/// <summary>
/// Update the pointer info popup.
/// </summary>
/// <param name="ptrPt">Reference to the input pointer.</param>
void UpdateInfoPop(PointerPoint ptrPt)
{
    foreach (var pointerDetails in Container.Children)
    {
        if (pointerDetails.GetType().ToString() == "Windows.UI.Xaml.Controls.TextBlock")
        {
            TextBlock textBlock = (TextBlock)pointerDetails;
            if (textBlock.Name == ptrPt.PointerId.ToString())
            {
                // To get pointer location details, we need extended pointer info.
                // We get the pointer info through the getCurrentPoint method
                // of the event argument. 
                TranslateTransform x = new TranslateTransform();
                x.X = ptrPt.Position.X + 20;
                x.Y = ptrPt.Position.Y + 20;
                pointerDetails.RenderTransform = x;
                textBlock.Text = QueryPointer(ptrPt);
            }
        }
    }
}
```

-   最後に、さまざまなポインター プロパティを照会します。

```csharp
/// <summary>
/// Get pointer details.
/// </summary>
/// <param name="ptrPt">Reference to the input pointer.</param>
/// <returns>A string composed of pointer details.</returns>
String QueryPointer(PointerPoint ptrPt)
{
    String details = "";

    switch (ptrPt.PointerDevice.PointerDeviceType)
    {
        case Windows.Devices.Input.PointerDeviceType.Mouse:
            details += "\nPointer type: mouse";
            break;
        case Windows.Devices.Input.PointerDeviceType.Pen:
            details += "\nPointer type: pen";
            if (ptrPt.IsInContact)
            {
                details += "\nPressure: " + ptrPt.Properties.Pressure;
                details += "\nrotation: " + ptrPt.Properties.Orientation;
                details += "\nTilt X: " + ptrPt.Properties.XTilt;
                details += "\nTilt Y: " + ptrPt.Properties.YTilt;
                details += "\nBarrel button pressed: " + ptrPt.Properties.IsBarrelButtonPressed;
            }
            break;
        case Windows.Devices.Input.PointerDeviceType.Touch:
            details += "\nPointer type: touch";
            details += "\nrotation: " + ptrPt.Properties.Orientation;
            details += "\nTilt X: " + ptrPt.Properties.XTilt;
            details += "\nTilt Y: " + ptrPt.Properties.YTilt;
            break;
        default:
            details += "\nPointer type: n/a";
            break;
    }

    GeneralTransform gt = Target.TransformToVisual(this);
    Point screenPoint;

    screenPoint = gt.TransformPoint(new Point(ptrPt.Position.X, ptrPt.Position.Y));
    details += "\nPointer Id: " + ptrPt.PointerId.ToString() +
        "\nPointer location (target): " + Math.Round(ptrPt.Position.X) + ", " + Math.Round(ptrPt.Position.Y) +
        "\nPointer location (container): " + Math.Round(screenPoint.X) + ", " + Math.Round(screenPoint.Y);

    return details;
}
```

## <a name="primary-pointer"></a>プライマリ ポインター
タッチ デジタイザーやタッチパッドなどの一部の入力デバイスでは、マウスまたはペンといった一般的な単一ポインターよりも多くのポインターをサポートします (Surface Hub での 2 つのペン入力のサポートが代表的な例です)。 

単一のプライマリ ポインターを識別し、区別するには、**[PointerPointerProperties](https://docs.microsoft.com/uwp/api/windows.ui.input.pointerpointproperties)** クラスの読み取り専用の **[IsPrimary](https://docs.microsoft.com/uwp/api/windows.ui.input.pointerpointproperties.IsPrimary)** プロパティを使います (プライマリ ポインターとは、常に入力シーケンスで検出される最初のポインターを指します)。 

プライマリ ポインターを識別することにより、プライマリ ポインターを使って、マウスやペン入力のエミュレート、操作のカスタマイズ、他の特定の機能や UI の提供を行うことができます。

> [!NOTE]
> 入力シーケンスでプライマリ ポインターが離されたり、取り消されたり、または失われたりすると、新しい入力シーケンスが開始されるまでプライマリ入力ポインターは作成されません (入力シーケンスは、すべてのポインターが離されたり、取り消されたり、または失われたりすると終了します)。

## <a name="primary-pointer-animation-example"></a>プライマリ ポインター アニメーションの例

以下のコード スニペットは、特別な視覚的フィードバックを使って、ユーザーがアプリケーションでポインター入力を区別できるようにする方法を示しています。

この特定のアプリでは、色とアニメーションの両方を使って、プライマリ ポインターを強調表示します。

![アニメーション化された視覚的フィードバックを使ったポインター アプリケーション](images/pointers/pointers-usercontrol-animation.gif)

**このサンプルは、「[Pointer input sample (UserControl with animation)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers-animation.zip)」(ポインター入力のサンプル (アニメーションを使った UserControl)) でダウンロードしてください。**

### <a name="visual-feedback"></a>視覚的なフィードバック

ここでは、XAML の **[Ellipse](https://docs.microsoft.com/uwp/api/windows.ui.xaml.shapes.ellipse)** オブジェクトに基づいて、**[UserControl](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol)** を定義します。これにより、各ポインターのキャンバス上の位置が強調表示されます。また、**[Storyboard](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.animation.storyboard)** を使って、プライマリ ポインターに対応する楕円をアニメーション化します。

**XAML を次に示します。**

```xaml
<UserControl
    x:Class="UWP_Pointers.PointerEllipse"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:UWP_Pointers"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    d:DesignHeight="100"
    d:DesignWidth="100">

    <UserControl.Resources>
        <Style x:Key="EllipseStyle" TargetType="Ellipse">
            <Setter Property="Transitions">
                <Setter.Value>
                    <TransitionCollection>
                        <ContentThemeTransition/>
                    </TransitionCollection>
                </Setter.Value>
            </Setter>
        </Style>
        
        <Storyboard x:Name="myStoryboard">
            <!-- Animates the value of a Double property between 
            two target values using linear interpolation over the 
            specified Duration. -->
            <DoubleAnimation
              Storyboard.TargetName="ellipse"
              Storyboard.TargetProperty="(RenderTransform).(ScaleTransform.ScaleY)"  
              Duration="0:0:1" 
              AutoReverse="True" 
              RepeatBehavior="Forever" From="1.0" To="1.4">
            </DoubleAnimation>

            <!-- Animates the value of a Double property between 
            two target values using linear interpolation over the 
            specified Duration. -->
            <DoubleAnimation
              Storyboard.TargetName="ellipse"
              Storyboard.TargetProperty="(RenderTransform).(ScaleTransform.ScaleX)"  
              Duration="0:0:1" 
              AutoReverse="True" 
              RepeatBehavior="Forever" From="1.0" To="1.4">
            </DoubleAnimation>

            <!-- Animates the value of a Color property between 
            two target values using linear interpolation over the 
            specified Duration. -->
            <ColorAnimation 
                Storyboard.TargetName="ellipse" 
                EnableDependentAnimation="True" 
                Storyboard.TargetProperty="(Fill).(SolidColorBrush.Color)" 
                From="White" To="Red"  Duration="0:0:1" 
                AutoReverse="True" RepeatBehavior="Forever"/>
        </Storyboard>
    </UserControl.Resources>

    <Grid x:Name="CompositionContainer">
        <Ellipse Name="ellipse" 
        StrokeThickness="2" 
        Width="{x:Bind Diameter}" 
        Height="{x:Bind Diameter}"  
        Style="{StaticResource EllipseStyle}" />
    </Grid>
</UserControl>
```

コードビハインドを次に示します。
```csharp
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at 
// https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP_Pointers
{
    /// <summary>
    /// Pointer feedback object.
    /// </summary>
    public sealed partial class PointerEllipse : UserControl
    {
        // Reference to the application canvas.
        Canvas canvas;

        /// <summary>
        /// Ellipse UI for pointer feedback.
        /// </summary>
        /// <param name="c">The drawing canvas.</param>
        public PointerEllipse(Canvas c)
        {
            this.InitializeComponent();
            canvas = c;
        }

        /// <summary>
        /// Gets or sets the pointer Id to associate with the PointerEllipse object.
        /// </summary>
        public uint PointerId
        {
            get { return (uint)GetValue(PointerIdProperty); }
            set { SetValue(PointerIdProperty, value); }
        }
        // Using a DependencyProperty as the backing store for PointerId.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointerIdProperty =
            DependencyProperty.Register("PointerId", typeof(uint), 
                typeof(PointerEllipse), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets whether the associated pointer is Primary.
        /// </summary>
        public bool PrimaryPointer
        {
            get { return (bool)GetValue(PrimaryPointerProperty); }
            set
            {
                SetValue(PrimaryPointerProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for PrimaryPointer.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrimaryPointerProperty =
            DependencyProperty.Register("PrimaryPointer", typeof(bool), 
                typeof(PointerEllipse), new PropertyMetadata(false));


        /// <summary>
        /// Gets or sets the ellipse style based on whether the pointer is Primary.
        /// </summary>
        public bool PrimaryEllipse 
        {
            get { return (bool)GetValue(PrimaryEllipseProperty); }
            set
            {
                SetValue(PrimaryEllipseProperty, value);
                if (value)
                {
                    SolidColorBrush fillBrush = 
                        (SolidColorBrush)Application.Current.Resources["PrimaryFillBrush"];
                    SolidColorBrush strokeBrush = 
                        (SolidColorBrush)Application.Current.Resources["PrimaryStrokeBrush"];

                    ellipse.Fill = fillBrush;
                    ellipse.Stroke = strokeBrush;
                    ellipse.RenderTransform = new CompositeTransform();
                    ellipse.RenderTransformOrigin = new Point(.5, .5);
                    myStoryboard.Begin();
                }
                else
                {
                    SolidColorBrush fillBrush = 
                        (SolidColorBrush)Application.Current.Resources["SecondaryFillBrush"];
                    SolidColorBrush strokeBrush = 
                        (SolidColorBrush)Application.Current.Resources["SecondaryStrokeBrush"];
                    ellipse.Fill = fillBrush;
                    ellipse.Stroke = strokeBrush;
                }
            }
        }
        // Using a DependencyProperty as the backing store for PrimaryEllipse.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrimaryEllipseProperty =
            DependencyProperty.Register("PrimaryEllipse", 
                typeof(bool), typeof(PointerEllipse), new PropertyMetadata(false));


        /// <summary>
        /// Gets or sets the diameter of the PointerEllipse object.
        /// </summary>
        public int Diameter
        {
            get { return (int)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Diameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiameterProperty =
            DependencyProperty.Register("Diameter", typeof(int), 
                typeof(PointerEllipse), new PropertyMetadata(120));
    }
}
```

### <a name="create-the-ui"></a>UI を作成する
この例の UI は入力の **[Canvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas)** に制限されます。ここでは、すべてのポインターを追跡し、ポインター カウンターやプライマリ ポインター識別子を含むヘッダー バーと共に、ポインター インジケーターとプライマリ ポインター アニメーションをレンダリングします (該当する場合)。

MainPage.xaml を次に示します。

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" 
                Orientation="Horizontal" 
                Grid.Row="0">
        <StackPanel.Transitions>
            <TransitionCollection>
                <AddDeleteThemeTransition/>
            </TransitionCollection>
        </StackPanel.Transitions>
        <TextBlock x:Name="Header" 
                    Text="Basic pointer tracking sample - IsPrimary" 
                    Style="{ThemeResource HeaderTextBlockStyle}" 
                    Margin="10,0,0,0" />
        <TextBlock x:Name="PointerCounterLabel"
                    VerticalAlignment="Center"                 
                    Style="{ThemeResource BodyTextBlockStyle}"
                    Text="Number of pointers: " 
                    Margin="50,0,0,0"/>
        <TextBlock x:Name="PointerCounter"
                    VerticalAlignment="Center"                 
                    Style="{ThemeResource BodyTextBlockStyle}"
                    Text="0" 
                    Margin="10,0,0,0"/>
        <TextBlock x:Name="PointerPrimaryLabel"
                    VerticalAlignment="Center"                 
                    Style="{ThemeResource BodyTextBlockStyle}"
                    Text="Primary: " 
                    Margin="50,0,0,0"/>
        <TextBlock x:Name="PointerPrimary"
                    VerticalAlignment="Center"                 
                    Style="{ThemeResource BodyTextBlockStyle}"
                    Text="n/a" 
                    Margin="10,0,0,0"/>
    </StackPanel>
    
    <Grid Grid.Row="1">
        <!--The canvas where we render the pointer UI.-->
        <Canvas x:Name="pointerCanvas"/>
    </Grid>
</Grid>
```

### <a name="handle-pointer-events"></a>ポインター イベントを処理する

最後に、MainPage.xaml.cs のコード ビハインドで、基本的なポインター イベント ハンドラーを定義します。 ここでは、コードを再現しません。基本的なコードは前の例で示されているためです。動作するサンプルは「[Pointer input sample (UserControl with animation)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers-animation.zip)」(ポインター入力のサンプル (アニメーションを使った UserControl)) でダウンロードできます。

## <a name="related-articles"></a>関連記事

**トピックのサンプル**
* [ポインター入力のサンプル (基本)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers.zip)
* [ポインター入力のサンプル (アニメーションを使った UserControl)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers-animation.zip)

**その他のサンプル**
* [基本的な入力のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [待機時間が短い入力のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [ユーザー操作モードのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* [フォーカスの視覚効果のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**サンプルのアーカイブ**
* [入力: XAML ユーザー入力イベントのサンプル](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [入力: デバイス機能のサンプル](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [入力: 操作とジェスチャ (C++) のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231605)
* [入力: タッチのヒット テストのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231590)
* [XAML のスクロール、パン、ズームのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [入力: 簡略化されたインクのサンプル](http://go.microsoft.com/fwlink/p/?linkid=246570)