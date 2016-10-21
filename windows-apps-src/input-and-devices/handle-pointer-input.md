---
author: Karl-Bridge-Microsoft
Description: "ユニバーサル Windows プラットフォーム (UWP) アプリで、タッチ、マウス、ペン/スタイラス、タッチパッドなどのポインティング デバイスからの入力データを受信、処理、管理します。"
title: "ポインター入力の処理"
ms.assetid: BDBC9E33-4037-4671-9596-471DCF855C82
label: Handle pointer input
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a2ec5e64b91c9d0e401c48902a18e5496fc987ab
ms.openlocfilehash: 2053062f6a5f850da8983bce2465cd10cdc01d56

---

# ポインター入力の処理

ユニバーサル Windows プラットフォーム (UWP) アプリで、タッチ、マウス、ペン/スタイラス、タッチパッドなどのポインティング デバイスからの入力データを受信、処理、管理します。

**重要な API**

-   [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648)
-   [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br208383)
-   [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)


**重要**  
独自の対話式操作サポートを実装する場合は、ユーザーはアプリの UI 要素を直接操作できる直感的なエクスペリエンスを期待しているということを心に留めておいてください。 カスタムの対話式操作では、「[コントロールの一覧](https://msdn.microsoft.com/library/windows/apps/mt185406)」を手本にして、一貫性と見つけやすさを維持することをお勧めします。 これらのプラットフォーム コントロールでは、標準的な対話式操作、アニメーション化された物理的効果、視覚的フィードバック、アクセシビリティなど、ユニバーサル Windows プラットフォーム (UWP) の完全なユーザー操作エクスペリエンスが提供されます。 はっきりとした明確に定義されている要件があり、基本的な対話式操作ではシナリオがサポートされない場合のみ、カスタムの対話式操作を作ってください。


## ポインター


多くの操作のエクスペリエンスでは、ユーザーがタッチ、マウス、ペン/スタイラス、タッチパッドなどの入力デバイスを使ってポイントすることによって、操作の対象となるオブジェクトを識別します。 これらの入力デバイスによって提供される生のヒューマン インターフェイス デバイス (HID) のデータには、多くの共通するプロパティが含まれているため、情報は統合入力スタックに昇格され、デバイスにとらわれない、統合されたポインター データとして公開されます。 UWP アプリでは、使われている入力デバイスについて意識することなくこのデータを利用できます。

**注**  アプリで必要な場合は、デバイス固有の情報も HID の生データから昇格されます。

 

入力スタックの各入力ポイント (または接触) は、さまざまなポインター イベントで提供される [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) パラメーターによって公開される [**Pointer**](https://msdn.microsoft.com/library/windows/apps/br227968) オブジェクトで表されます。 マルチペンまたはマルチタッチ入力の場合、各接触は固有の入力ポイントとして扱われます。

## ポインター イベント


ポインター イベントは、検出状態 (範囲または接触) やデバイスの種類などの基本情報と、位置、圧力、接触形状などの拡張情報を公開します。 さらに、ユーザーが押したマウス ボタンは何か、ペンの消しゴム ボタンは使われているかなど、特定のデバイスのプロパティも使うことができます。 アプリで入力デバイスとその機能を区別する必要がある場合は、「[入力デバイスの識別](identify-input-devices.md)」をご覧ください。

UWP アプリでは、次のポインター イベントをリッスンすることができます。

**注**  ポインターの入力を特定の UI 要素に制限するには、[**CapturePointer**](https://msdn.microsoft.com/library/windows/apps/br208918) を呼び出します。 要素でポインターがキャプチャされると、ポインターがオブジェクトの境界領域の外部に移動しても、そのオブジェクトだけがポインター入力イベントを受け取ります。 通常、[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベント ハンドラー内でポインターをキャプチャします。これは、**CapturePointer** が成功するには、[**IsInContact**](https://msdn.microsoft.com/library/windows/apps/br227976) (マウスのボタンが押されること、タッチやスタイラスの接触) が true である必要があるためです。

 

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
<td align="left"><p>[<strong>PointerCanceled</strong>](https://msdn.microsoft.com/library/windows/apps/br208964)</p></td>
<td align="left"><p>プラットフォームでポインターが取り消されると発生します。</p>
<ul>
<li>入力サーフェスの範囲内でペンが検出されると、タッチ ポインターは取り消されます。</li>
<li>100 ミリ秒を超えてもアクティブな接触が検出されません。</li>
<li>モニター/ディスプレイが変更されました (解像度、設定、マルチモニター構成)。</li>
<li>デスクトップがロックされているか、ユーザーがログオフしました。</li>
<li>同時に接触した数がデバイスでサポートされる数を超えています。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>PointerCaptureLost</strong>](https://msdn.microsoft.com/library/windows/apps/br208965)</p></td>
<td align="left"><p>別の UI 要素がポインターをキャプチャしたか、ポインターが離されたか、別のポインターがプログラムでキャプチャされたときに発生します。</p>
<div class="alert">
<strong>注</strong>  対応するポインター キャプチャ イベントはありません。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>PointerEntered</strong>](https://msdn.microsoft.com/library/windows/apps/br208968)</p></td>
<td align="left"><p>ポインターが要素の境界領域内に入ったときに発生します。 これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</p>
<ul>
<li>タッチでは、このイベントが発生するには、直接タッチするか、要素の境界領域内に移動することによって、指が接触する必要があります。</li>
<li>マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</li>
<li>タッチと同様に、直接ペンでタッチするか、要素の境界領域内に移動することによって、このイベントが起動されます。 ただし、ペンにはホバー状態 ([<strong>IsInRange</strong>](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、true の場合、このイベントが発生します。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>PointerExited</strong>](https://msdn.microsoft.com/library/windows/apps/br208969)</p></td>
<td align="left"><p>ポインターが要素の境界領域から出たときに発生します。 これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</p>
<ul>
<li>タッチでは、指が接触している必要があり、ポインターが要素の境界領域から外へ移動したときにこのイベントが発生します。</li>
<li>マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</li>
<li>タッチと同様に、ペンでは、要素の境界領域の外へ移動したときにこのイベントが発生します。 ただし、ペンにはホバー状態 ([<strong>IsInRange</strong>](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、状態が true から false に変化したときに、このイベントが発生します。</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>PointerMoved</strong>](https://msdn.microsoft.com/library/windows/apps/br208970)</p></td>
<td align="left"><p>要素の境界領域内で、ポインターの座標、ボタンの状態、圧力、傾き、または接触形状 (たとえば、幅と高さ) が変化したときに発生します。 これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</p>
<ul>
<li>タッチでは、指が接触している必要があり、要素の境界領域内に接触した場合にのみ、このイベントが発生します。</li>
<li>マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</li>
<li>タッチと同様に、ペンでは、要素の境界領域内に接触したときにこのイベントが発生します。 ただし、ペンにはホバー状態 ([<strong>IsInRange</strong>](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、状態が true で、要素の境界領域内にあるときに、このイベントが発生します。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>PointerPressed</strong>](https://msdn.microsoft.com/library/windows/apps/br208971)</p></td>
<td align="left"><p>要素の境界領域内でポインターを押すアクション (タッチして押す、マウス ボタンを押す、ペンで押す、タッチパッドのボタンを押すなど) を行うと発生します。</p>
<p>このイベントのハンドラーから [<strong>CapturePointer</strong>](https://msdn.microsoft.com/library/windows/apps/br208918) を呼び出す必要があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>PointerReleased</strong>](https://msdn.microsoft.com/library/windows/apps/br208972)</p></td>
<td align="left"><p>要素の境界領域内でポインターを離すアクション (タッチを離す、マウス ボタンを離す、ペンを離す、タッチパッドのボタンを離すなど) を行ったとき、またはポインターが境界領域の外部でキャプチャされた場合に発生します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>PointerWheelChanged</strong>](https://msdn.microsoft.com/library/windows/apps/br208973)</p></td>
<td align="left"><p>マウス ホイールが回転したときに発生します。</p>
<p>マウス入力が最初に検出されると、割り当てられている単一ポインターと関連付けられます。 (左ボタン、ホイール、右ボタンのいずれかの) マウス ボタンをクリックすると、[<strong>PointerMoved</strong>](https://msdn.microsoft.com/library/windows/apps/br208970) イベントによってポインターとそのボタンが副次的に関連付けられます。</p></td>
</tr>
</tbody>
</table>

 

## 例


ここでは、基本的なポインター追跡アプリのコード例を示すことによって、ポインター イベントをリッスンして処理し、アクティブなポインターのさまざまなプロパティを取得する方法について説明します。

### UI を作る

この例では、ポインター入力のターゲット オブジェクトとして四角形 (`targetContainer`) を使います。 ポインターの状態が変わると、ターゲットの色が変わります。

ポインターと共に移動する浮動テキスト ブロックに、各ポインターの詳細が表示されます。 ポインター イベント自体は四角形の左側に表示されます (イベントのシーケンスを示すため)。

この例の Extensible Application Markup Language (XAML) を次に示します。

```XAML
<Page
    x:Class="PointerInput.MainPage"
    IsTabStop="false"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:PointerInput"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Name="page">

    <Grid Background="{StaticResource ApplicationForegroundThemeBrush}">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="69.458" />
            <ColumnDefinition Width="80.542"/>
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
        <Button Name="buttonClear"
                Foreground="White"
                Width="100"
                Height="100">
            clear
        </Button>
        <TextBox Name="eventLog" 
                 Grid.Column="1"
                 Grid.Row="0"
                 Grid.RowSpan="3" 
                 Background="#000000" 
                 TextWrapping="Wrap" 
                 Foreground="#FFFFFF" 
                 ScrollViewer.VerticalScrollBarVisibility="Visible" 
                 BorderThickness="0" Grid.ColumnSpan="2"/>
    </Grid>
</Page>
```

### ポインター イベントをリッスンする

ほとんどの場合は、イベント ハンドラーの [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) を介してポインター情報を取得することをお勧めします。

必要なポインターの詳細をイベント引数が公開していない場合は、[**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) の [**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/hh943077) メソッドと [**GetIntermediatePoints**](https://msdn.microsoft.com/library/windows/apps/hh943078) メソッドによって公開される拡張 [**PointerPoint**](https://msdn.microsoft.com/library/windows/apps/br242038) 情報にアクセスできます。

この例では、ポインター入力のターゲット オブジェクトとして四角形 (`targetContainer`) を使います。 ポインターの状態が変わると、ターゲットの色が変わります。

次のコードでは、ターゲット オブジェクトを設定し、グローバル変数を宣言し、ターゲットのさまざまなポインター イベント リスナーを識別しています。

```CSharp
        // For this example, we track simultaneous contacts in case the 
        // number of contacts has reached the maximum supported by the device.
        // Depending on the device, additional contacts might be ignored 
        // (PointerPressed not fired). 
        uint numActiveContacts;
        Windows.Devices.Input.TouchCapabilities touchCapabilities = new Windows.Devices.Input.TouchCapabilities();

        // Dictionary to maintain information about each active contact. 
        // An entry is added during PointerPressed/PointerEntered events and removed 
        // during PointerReleased/PointerCaptureLost/PointerCanceled/PointerExited events.
        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> contacts;

        public MainPage()
        {
            this.InitializeComponent();
            numActiveContacts = 0;
            // Initialize the dictionary.
            contacts = new Dictionary<uint, Windows.UI.Xaml.Input.Pointer>((int)touchCapabilities.Contacts);
            // Declare the pointer event handlers.
            Target.PointerPressed += new PointerEventHandler(Target_PointerPressed);
            Target.PointerEntered += new PointerEventHandler(Target_PointerEntered);
            Target.PointerReleased += new PointerEventHandler(Target_PointerReleased);
            Target.PointerExited += new PointerEventHandler(Target_PointerExited);
            Target.PointerCanceled += new PointerEventHandler(Target_PointerCanceled);
            Target.PointerCaptureLost += new PointerEventHandler(Target_PointerCaptureLost);
            Target.PointerMoved += new PointerEventHandler(Target_PointerMoved);
            Target.PointerWheelChanged += new PointerEventHandler(Target_PointerWheelChanged);

            buttonClear.Click += new RoutedEventHandler(ButtonClear_Click);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            eventLog.Text = "";
        }

```

### ポインター イベントを処理する

次に、UI フィードバックを使って基本的なポインター イベント ハンドラーを示します。

-   このハンドラーは、[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントを管理します。 イベント ログにイベントを追加し、関心のあるポインターを追跡するために使われるポインター配列にポインターを追加し、ポインターの詳細を表示します。

    **注**  [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントと [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントは常に対で発生するわけではありません。 アプリでは、ポインター ダウン アクションを終了させる可能性のあるすべてのイベント ([**PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208969)、[**PointerCanceled**](https://msdn.microsoft.com/library/windows/apps/br208964)、[**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) など) をリッスンして処理する必要があります。

     

```    CSharp
        // PointerPressed and PointerReleased events do not always occur in pairs. 
            // Your app should listen for and handle any event that might conclude a pointer down action 
            // (such as PointerExited, PointerCanceled, and PointerCaptureLost).
            // For this example, we track the number of contacts in case the 
            // number of contacts has reached the maximum supported by the device.
            // Depending on the device, additional contacts might be ignored 
            // (PointerPressed not fired). 
            void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
            {
                Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

                // Update event sequence.
                eventLog.Text += "\nDown: " + ptr.PointerId;

                // Change background color of target when pointer contact detected.
                Target.Fill = new SolidColorBrush(Windows.UI.Colors.Green);

                // Prevent most handlers along the event route from handling the same event again.
                e.Handled = true;

                // Lock the pointer to the target.
                Target.CapturePointer(e.Pointer);

                // Update event sequence.
                eventLog.Text += "\nPointer captured: " + ptr.PointerId;

                // Check if pointer already exists (for example, enter occurred prior to press).
                if (contacts.ContainsKey(ptr.PointerId))
                {
                    return;
                }
                // Add contact to dictionary.
                contacts[ptr.PointerId] = ptr;
                ++numActiveContacts;

                // Display pointer details.
                createInfoPop(e);
            }
```

-   このハンドラーは、[**PointerEntered**](https://msdn.microsoft.com/library/windows/apps/br208968) イベントを管理します。 イベント ログにイベントを追加し、ポインター コレクションにポインターを追加して、ポインターの詳細を表示します。

```    CSharp
        private void Target_PointerEntered(object sender, PointerRoutedEventArgs e)
            {
                Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

                // Update event sequence.
                eventLog.Text += "\nEntered: " + ptr.PointerId;

                if (contacts.Count == 0)
                {
                    // Change background color of target when pointer contact detected.
                    Target.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }

                // Check if pointer already exists (if enter occurred prior to down).
                if (contacts.ContainsKey(ptr.PointerId))
                {
                    return;
                }

                // Add contact to dictionary.
                contacts[ptr.PointerId] = ptr;
                ++numActiveContacts;

                // Prevent most handlers along the event route from handling the same event again.
                e.Handled = true;

                // Display pointer details.
                createInfoPop(e);
            }
```

-   このハンドラーは、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208970) イベントを管理します。 イベント ログにイベントを追加し、ポインターの詳細を更新します。

    **重要**  マウス入力が最初に検出されると、割り当てられている単一ポインターと関連付けられます。 (左ボタン、ホイール、右ボタンのいずれかの) マウス ボタンをクリックすると、[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントによってポインターとそのボタンが副次的に関連付けられます。 [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントは、同じマウス ボタンを離したときにだけ発生します (イベントが完了するまではそのポインターに他のボタンが関連付けられることはありません)。 この排他的な関連付けのために、他のマウス ボタンをクリックした場合は、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208970) イベントによってルーティングされます。

     

```    CSharp
private void Target_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

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
        if (ptr.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
        {
            // To get mouse state, we need extended pointer details.
            // We get the pointer info through the getCurrentPoint method
            // of the event argument. 
            Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(Target);
            if (ptrPt.Properties.IsLeftButtonPressed)
            {
                eventLog.Text += "\nLeft button: " + ptrPt.PointerId;
            }
            if (ptrPt.Properties.IsMiddleButtonPressed)
            {
                eventLog.Text += "\nWheel button: " + ptrPt.PointerId;
            }
            if (ptrPt.Properties.IsRightButtonPressed)
            {
                eventLog.Text += "\nRight button: " + ptrPt.PointerId;
            }
        }

        // Prevent most handlers along the event route from handling the same event again.
        e.Handled = true;

        // Display pointer details.
        updateInfoPop(e);
    }
```

-   このハンドラーは、[**PointerWheelChanged**](https://msdn.microsoft.com/library/windows/apps/br208973) イベントを管理します。 イベント ログにイベントを追加し、ポインター配列にポインターを追加して (必要な場合)、ポインターの詳細を表示します。

```    CSharp
private void Target_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

        // Update event sequence.
        eventLog.Text += "\nMouse wheel: " + ptr.PointerId;

        // Check if pointer already exists (for example, enter occurred prior to wheel).
        if (contacts.ContainsKey(ptr.PointerId))
        {
            return;
        }

        // Add contact to dictionary.
        contacts[ptr.PointerId] = ptr;
        ++numActiveContacts;

        // Prevent most handlers along the event route from handling the same event again.
        e.Handled = true;

        // Display pointer details.
        createInfoPop(e);
    }
```

-   このハンドラーは、デジタイザーとの接触が終了する [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントを管理します。 イベント ログにイベントを追加し、ポインター コレクションからポインターを削除して、ポインターの詳細を更新します。

```    CSharp
void Target_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

        // Update event sequence.
        eventLog.Text += "\nUp: " + ptr.PointerId;

        // If event source is mouse or touchpad and the pointer is still 
        // over the target, retain pointer and pointer details.
        // Return without removing pointer from pointers dictionary.
        // For this example, we assume a maximum of one mouse pointer.
        if (ptr.PointerDeviceType != Windows.Devices.Input.PointerDeviceType.Mouse)
        {
            // Update target UI.
            Target.Fill = new SolidColorBrush(Windows.UI.Colors.Red);

            destroyInfoPop(ptr);

            // Remove contact from dictionary.
            if (contacts.ContainsKey(ptr.PointerId))
            {
                contacts[ptr.PointerId] = null;
                contacts.Remove(ptr.PointerId);
                --numActiveContacts;
            }

            // Release the pointer from the target.
            Target.ReleasePointerCapture(e.Pointer);

            // Update event sequence.
            eventLog.Text += "\nPointer released: " + ptr.PointerId;

            // Prevent most handlers along the event route from handling the same event again.
            e.Handled = true;
        }
        else
        {
            Target.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
        }

    }
```

-   このハンドラーは、デジタイザーとの接触が維持される [**PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208969) イベントを管理します。 イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。

```    CSharp
private void Target_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

        // Update event sequence.
        eventLog.Text += "\nPointer exited: " + ptr.PointerId;

        // Remove contact from dictionary.
        if (contacts.ContainsKey(ptr.PointerId))
        {
            contacts[ptr.PointerId] = null;
            contacts.Remove(ptr.PointerId);
            --numActiveContacts;
        }

        // Update the UI and pointer details.
        destroyInfoPop(ptr);

        if (contacts.Count == 0)
        {
            Target.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
        }
        
        // Prevent most handlers along the event route from handling the same event again.
        e.Handled = true;
    }
```

-   このハンドラーは、[**PointerCanceled**](https://msdn.microsoft.com/library/windows/apps/br208964) イベントを管理します。 イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。

```    CSharp
// Fires for for various reasons, including: 
    //    - Touch contact canceled by pen coming into range of the surface.
    //    - The device doesn&#39;t report an active contact for more than 100ms.
    //    - The desktop is locked or the user logged off. 
    //    - The number of simultaneous contacts exceeded the number supported by the device.
    private void Target_PointerCanceled(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

        // Update event sequence.
        eventLog.Text += "\nPointer canceled: " + ptr.PointerId;

        // Remove contact from dictionary.
        if (contacts.ContainsKey(ptr.PointerId))
        {
            contacts[ptr.PointerId] = null;
            contacts.Remove(ptr.PointerId);
            --numActiveContacts;
        }

        destroyInfoPop(ptr);

        if (contacts.Count == 0)
        {
            Target.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
        }
        // Prevent most handlers along the event route from handling the same event again.
        e.Handled = true;
    }
```

-   このハンドラーは、[**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) イベントを管理します。 イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。

    **注**  [**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) が [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) の代わりに発生することがあります。 ポインターのキャプチャは、さまざまな理由で失われることがあります。

     

```    CSharp
// Fires for for various reasons, including: 
    //    - User interactions
    //    - Programmatic capture of another pointer
    //    - Captured pointer was deliberately released
    // PointerCaptureLost can fire instead of PointerReleased. 
    private void Target_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

        // Update event sequence.
        eventLog.Text += "\nPointer capture lost: " + ptr.PointerId;

        // Remove contact from dictionary.
        if (contacts.ContainsKey(ptr.PointerId))
        {
            contacts[ptr.PointerId] = null;
            contacts.Remove(ptr.PointerId);
            --numActiveContacts;
        }

        destroyInfoPop(ptr);

        if (contacts.Count == 0)
        {
            Target.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
        }
        // Prevent most handlers along the event route from handling the same event again.
        e.Handled = true;
    }
```

### ポインターのプロパティを取得する

前に説明したように、ほとんどの拡張ポインター情報を、[**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) の [**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/hh943077) と [**GetIntermediatePoints**](https://msdn.microsoft.com/library/windows/apps/hh943078) メソッドを介して取得した [**Windows.UI.Input.PointerPoint**](https://msdn.microsoft.com/library/windows/apps/br242038) オブジェクトから取得する必要があります。

-   最初に、ポインターごとに新しい [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) を作ります。

```    CSharp
        void createInfoPop(PointerRoutedEventArgs e)
            {
                TextBlock pointerDetails = new TextBlock();
                Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(Target);
                pointerDetails.Name = ptrPt.PointerId.ToString();
                pointerDetails.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                pointerDetails.Text = queryPointer(ptrPt);

                TranslateTransform x = new TranslateTransform();
                x.X = ptrPt.Position.X + 20;
                x.Y = ptrPt.Position.Y + 20;
                pointerDetails.RenderTransform = x;

                Container.Children.Add(pointerDetails);
            }
```

-   次に、そのポインターと関連付けられた、既にある [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) でポインター情報を更新するための手段を提供します。

```    CSharp
        void updateInfoPop(PointerRoutedEventArgs e)
            {
                foreach (var pointerDetails in Container.Children)
                {
                    if (pointerDetails.GetType().ToString() == "Windows.UI.Xaml.Controls.TextBlock")
                    {
                        TextBlock _TextBlock = (TextBlock)pointerDetails;
                        if (_TextBlock.Name == e.Pointer.PointerId.ToString())
                        {
                            // To get pointer location details, we need extended pointer info.
                            // We get the pointer info through the getCurrentPoint method
                            // of the event argument. 
                            Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(Target);
                            TranslateTransform x = new TranslateTransform();
                            x.X = ptrPt.Position.X + 20;
                            x.Y = ptrPt.Position.Y + 20;
                            pointerDetails.RenderTransform = x;
                            _TextBlock.Text = queryPointer(ptrPt);
                        }
                    }
                }
            }
```

-   最後に、さまざまなポインター プロパティを照会します。

```    CSharp
         String queryPointer(PointerPoint ptrPt)
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

                 GeneralTransform gt = Target.TransformToVisual(page);
                 Point screenPoint;

                 screenPoint = gt.TransformPoint(new Point(ptrPt.Position.X, ptrPt.Position.Y));
                 details += "\nPointer Id: " + ptrPt.PointerId.ToString() +
                     "\nPointer location (parent): " + ptrPt.Position.X + ", " + ptrPt.Position.Y +
                     "\nPointer location (screen): " + screenPoint.X + ", " + screenPoint.Y;
                 return details;
             }
```

### 完全な例

この例の C\# コードを次に示します。 さらに複雑なサンプルへのリンクについては、このページの最後にある関連記事をご覧ください。

```CSharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PointerInput
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // For this example, we track simultaneous contacts in case the 
        // number of contacts has reached the maximum supported by the device.
        // Depending on the device, additional contacts might be ignored 
        // (PointerPressed not fired). 
        uint numActiveContacts;
        Windows.Devices.Input.TouchCapabilities touchCapabilities = new Windows.Devices.Input.TouchCapabilities();

        // Dictionary to maintain information about each active contact. 
        // An entry is added during PointerPressed/PointerEntered events and removed 
        // during PointerReleased/PointerCaptureLost/PointerCanceled/PointerExited events.
        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> contacts;

        public MainPage()
        {
            this.InitializeComponent();
            numActiveContacts = 0;
            // Initialize the dictionary.
            contacts = new Dictionary<uint, Windows.UI.Xaml.Input.Pointer>((int)touchCapabilities.Contacts);
            // Declare the pointer event handlers.
            Target.PointerPressed += new PointerEventHandler(Target_PointerPressed);
            Target.PointerEntered += new PointerEventHandler(Target_PointerEntered);
            Target.PointerReleased += new PointerEventHandler(Target_PointerReleased);
            Target.PointerExited += new PointerEventHandler(Target_PointerExited);
            Target.PointerCanceled += new PointerEventHandler(Target_PointerCanceled);
            Target.PointerCaptureLost += new PointerEventHandler(Target_PointerCaptureLost);
            Target.PointerMoved += new PointerEventHandler(Target_PointerMoved);
            Target.PointerWheelChanged += new PointerEventHandler(Target_PointerWheelChanged);

            buttonClear.Click += new RoutedEventHandler(ButtonClear_Click);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            eventLog.Text = "";
        }


        // PointerPressed and PointerReleased events do not always occur in pairs. 
        // Your app should listen for and handle any event that might conclude a pointer down action 
        // (such as PointerExited, PointerCanceled, and PointerCaptureLost).
        // For this example, we track the number of contacts in case the 
        // number of contacts has reached the maximum supported by the device.
        // Depending on the device, additional contacts might be ignored 
        // (PointerPressed not fired). 
        void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

            // Update event sequence.
            eventLog.Text += "\nDown: " + ptr.PointerId;

            // Change background color of target when pointer contact detected.
            Target.Fill = new SolidColorBrush(Windows.UI.Colors.Green);

            // Prevent most handlers along the event route from handling the same event again.
            e.Handled = true;

            // Lock the pointer to the target.
            Target.CapturePointer(e.Pointer);

            // Update event sequence.
            eventLog.Text += "\nPointer captured: " + ptr.PointerId;

            // Check if pointer already exists (for example, enter occurred prior to press).
            if (contacts.ContainsKey(ptr.PointerId))
            {
                return;
            }
            // Add contact to dictionary.
            contacts[ptr.PointerId] = ptr;
            ++numActiveContacts;

            // Display pointer details.
            createInfoPop(e);
        }

        void Target_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

            // Update event sequence.
            eventLog.Text += "\nUp: " + ptr.PointerId;

            // If event source is mouse or touchpad and the pointer is still 
            // over the target, retain pointer and pointer details.
            // Return without removing pointer from pointers dictionary.
            // For this example, we assume a maximum of one mouse pointer.
            if (ptr.PointerDeviceType != Windows.Devices.Input.PointerDeviceType.Mouse)
            {
                // Update target UI.
                Target.Fill = new SolidColorBrush(Windows.UI.Colors.Red);

                destroyInfoPop(ptr);

                // Remove contact from dictionary.
                if (contacts.ContainsKey(ptr.PointerId))
                {
                    contacts[ptr.PointerId] = null;
                    contacts.Remove(ptr.PointerId);
                    --numActiveContacts;
                }

                // Release the pointer from the target.
                Target.ReleasePointerCapture(e.Pointer);

                // Update event sequence.
                eventLog.Text += "\nPointer released: " + ptr.PointerId;

                // Prevent most handlers along the event route from handling the same event again.
                e.Handled = true;
            }
            else
            {
                Target.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
            }

        }

        private void Target_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

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
            if (ptr.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
            {
                // To get mouse state, we need extended pointer details.
                // We get the pointer info through the getCurrentPoint method
                // of the event argument. 
                Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(Target);
                if (ptrPt.Properties.IsLeftButtonPressed)
                {
                    eventLog.Text += "\nLeft button: " + ptrPt.PointerId;
                }
                if (ptrPt.Properties.IsMiddleButtonPressed)
                {
                    eventLog.Text += "\nWheel button: " + ptrPt.PointerId;
                }
                if (ptrPt.Properties.IsRightButtonPressed)
                {
                    eventLog.Text += "\nRight button: " + ptrPt.PointerId;
                }
            }

            // Prevent most handlers along the event route from handling the same event again.
            e.Handled = true;

            // Display pointer details.
            updateInfoPop(e);
        }

        private void Target_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

            // Update event sequence.
            eventLog.Text += "\nEntered: " + ptr.PointerId;

            if (contacts.Count == 0)
            {
                // Change background color of target when pointer contact detected.
                Target.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
            }

            // Check if pointer already exists (if enter occurred prior to down).
            if (contacts.ContainsKey(ptr.PointerId))
            {
                return;
            }

            // Add contact to dictionary.
            contacts[ptr.PointerId] = ptr;
            ++numActiveContacts;

            // Prevent most handlers along the event route from handling the same event again.
            e.Handled = true;

            // Display pointer details.
            createInfoPop(e);
        }

        private void Target_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

            // Update event sequence.
            eventLog.Text += "\nMouse wheel: " + ptr.PointerId;

            // Check if pointer already exists (for example, enter occurred prior to wheel).
            if (contacts.ContainsKey(ptr.PointerId))
            {
                return;
            }

            // Add contact to dictionary.
            contacts[ptr.PointerId] = ptr;
            ++numActiveContacts;

            // Prevent most handlers along the event route from handling the same event again.
            e.Handled = true;

            // Display pointer details.
            createInfoPop(e);
        }

        // Fires for for various reasons, including: 
        //    - User interactions
        //    - Programmatic capture of another pointer
        //    - Captured pointer was deliberately released
        // PointerCaptureLost can fire instead of PointerReleased. 
        private void Target_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

            // Update event sequence.
            eventLog.Text += "\nPointer capture lost: " + ptr.PointerId;

            // Remove contact from dictionary.
            if (contacts.ContainsKey(ptr.PointerId))
            {
                contacts[ptr.PointerId] = null;
                contacts.Remove(ptr.PointerId);
                --numActiveContacts;
            }

            destroyInfoPop(ptr);

            if (contacts.Count == 0)
            {
                Target.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
            }
            // Prevent most handlers along the event route from handling the same event again.
            e.Handled = true;
        }

        // Fires for for various reasons, including: 
        //    - Touch contact canceled by pen coming into range of the surface.
        //    - The device doesn&#39;t report an active contact for more than 100ms.
        //    - The desktop is locked or the user logged off. 
        //    - The number of simultaneous contacts exceeded the number supported by the device.
        private void Target_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

            // Update event sequence.
            eventLog.Text += "\nPointer canceled: " + ptr.PointerId;

            // Remove contact from dictionary.
            if (contacts.ContainsKey(ptr.PointerId))
            {
                contacts[ptr.PointerId] = null;
                contacts.Remove(ptr.PointerId);
                --numActiveContacts;
            }

            destroyInfoPop(ptr);

            if (contacts.Count == 0)
            {
                Target.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
            }
            // Prevent most handlers along the event route from handling the same event again.
            e.Handled = true;
        }

        private void Target_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;

            // Update event sequence.
            eventLog.Text += "\nPointer exited: " + ptr.PointerId;

            // Remove contact from dictionary.
            if (contacts.ContainsKey(ptr.PointerId))
            {
                contacts[ptr.PointerId] = null;
                contacts.Remove(ptr.PointerId);
                --numActiveContacts;
            }

            // Update the UI and pointer details.
            destroyInfoPop(ptr);

            if (contacts.Count == 0)
            {
                Target.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            
            // Prevent most handlers along the event route from handling the same event again.
            e.Handled = true;
        }

        void createInfoPop(PointerRoutedEventArgs e)
        {
            TextBlock pointerDetails = new TextBlock();
            Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(Target);
            pointerDetails.Name = ptrPt.PointerId.ToString();
            pointerDetails.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            pointerDetails.Text = queryPointer(ptrPt);

            TranslateTransform x = new TranslateTransform();
            x.X = ptrPt.Position.X + 20;
            x.Y = ptrPt.Position.Y + 20;
            pointerDetails.RenderTransform = x;

            Container.Children.Add(pointerDetails);
        }

        void destroyInfoPop(Windows.UI.Xaml.Input.Pointer ptr)
        {
            foreach (var pointerDetails in Container.Children)
            {
                if (pointerDetails.GetType().ToString() == "Windows.UI.Xaml.Controls.TextBlock")
                {
                    TextBlock _TextBlock = (TextBlock)pointerDetails;
                    if (_TextBlock.Name == ptr.PointerId.ToString())
                    {
                        Container.Children.Remove(pointerDetails);
                    }
                }
            }
        }

        void updateInfoPop(PointerRoutedEventArgs e)
        {
            foreach (var pointerDetails in Container.Children)
            {
                if (pointerDetails.GetType().ToString() == "Windows.UI.Xaml.Controls.TextBlock")
                {
                    TextBlock _TextBlock = (TextBlock)pointerDetails;
                    if (_TextBlock.Name == e.Pointer.PointerId.ToString())
                    {
                        // To get pointer location details, we need extended pointer info.
                        // We get the pointer info through the getCurrentPoint method
                        // of the event argument. 
                        Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(Target);
                        TranslateTransform x = new TranslateTransform();
                        x.X = ptrPt.Position.X + 20;
                        x.Y = ptrPt.Position.Y + 20;
                        pointerDetails.RenderTransform = x;
                        _TextBlock.Text = queryPointer(ptrPt);
                    }
                }
            }
        }

         String queryPointer(PointerPoint ptrPt)
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

             GeneralTransform gt = Target.TransformToVisual(page);
             Point screenPoint;

             screenPoint = gt.TransformPoint(new Point(ptrPt.Position.X, ptrPt.Position.Y));
             details += "\nPointer Id: " + ptrPt.PointerId.ToString() +
                 "\nPointer location (parent): " + ptrPt.Position.X + ", " + ptrPt.Position.Y +
                 "\nPointer location (screen): " + screenPoint.X + ", " + screenPoint.Y;
             return details;
         }
    }
}
```

## 関連記事


**サンプル**
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
 

 







<!--HONumber=Aug16_HO3-->


