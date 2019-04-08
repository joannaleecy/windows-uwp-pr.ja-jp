---
Description: シミュレートし、キーボード、マウス、タッチ、ペン、および UWP アプリでのゲーム パッドなどのデバイスからの入力を自動化します。
title: 入力の挿入によるユーザー入力のシミュレート
label: Input injection
template: detail.hbs
keywords: デバイス, デジタイザー, 入力, 操作, 挿入
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: de3f0b1377d4f4209dc012ff56adb2de9c68625f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602327"
---
# <a name="simulate-user-input-through-input-injection"></a><span data-ttu-id="1ceb8-104">入力の挿入によるユーザー入力のシミュレート</span><span class="sxs-lookup"><span data-stu-id="1ceb8-104">Simulate user input through input injection</span></span>

<span data-ttu-id="1ceb8-105">UWP アプリケーションで、キーボード、マウス、タッチ、ペン、ゲームパッドなどのデバイスからユーザー入力をシミュレートし、自動化します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-105">Simulate and automate user input from devices such as keyboard, mouse, touch, pen, and gamepad in your UWP applications.</span></span>

> <span data-ttu-id="1ceb8-106">**重要な API**:[**Windows.UI.Input.Preview.Injection**](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection)</span><span class="sxs-lookup"><span data-stu-id="1ceb8-106">**Important APIs**: [**Windows.UI.Input.Preview.Injection**](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection)</span></span>

## <a name="overview"></a><span data-ttu-id="1ceb8-107">概要</span><span class="sxs-lookup"><span data-stu-id="1ceb8-107">Overview</span></span>

<span data-ttu-id="1ceb8-108">入力の挿入により、UWP アプリケーションは、さまざまな入力デバイスからの入力をシミュレートし、アプリのクライアント領域の外部など任意の場所にその入力を送信します (レジストリ エディターなど、管理者特権で実行されているアプリにも送信されます)。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-108">Input injection enables your UWP application to simulate input from a variety of input devices and direct that input anywhere, including outside your app's client area (even to apps running with Adminstrator privileges, such as the Registry Editor).</span></span>

<span data-ttu-id="1ceb8-109">入力の挿入は、アクセシビリティ、テスト (アドホック、自動)、リモート アクセスおよびサポート機能を含む機能を提供する必要のあるツールや UWP アプリに有用です。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-109">Input injection is useful for UWP apps and tools that need to provide functionality that includes accessibility, testing (ad-hoc, automated), and remote access and support features.</span></span>

## <a name="setup"></a><span data-ttu-id="1ceb8-110">セットアップ</span><span class="sxs-lookup"><span data-stu-id="1ceb8-110">Setup</span></span>

<span data-ttu-id="1ceb8-111">UWP アプリで入力の挿入 API を使用するには、次のコードをアプリ マニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-111">To use the input injection APIs in your UWP app you'll need to add the following to the app manifest:</span></span>

1. <span data-ttu-id="1ceb8-112">**[Package.appxmanifest]** ファイルを右クリックして **[コードの表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-112">Right click the **Package.appxmanifest** file and select **View code**.</span></span>
1. <span data-ttu-id="1ceb8-113">次を `Package` ノードに挿入します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-113">Insert the following into the `Package` node:</span></span>
    - `xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"`
    - `IgnorableNamespaces="rescap"`
1. <span data-ttu-id="1ceb8-114">次を `Capabilities` ノードに挿入します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-114">Insert the following into the `Capabilities` node:</span></span>
    - `<rescap:Capability Name="inputInjectionBrokered" />`

## <a name="duplicate-user-input"></a><span data-ttu-id="1ceb8-115">重複したユーザー入力</span><span class="sxs-lookup"><span data-stu-id="1ceb8-115">Duplicate user input</span></span>

| ![タッチ入力の挿入のサンプル](images/injection/touch-input-injection.gif) | 
|:--:|
| <span data-ttu-id="1ceb8-117">*タッチ入力インジェクション サンプル*</span><span class="sxs-lookup"><span data-stu-id="1ceb8-117">*Touch input injection sample*</span></span> |

<span data-ttu-id="1ceb8-118">この例では、入力の挿入の API ([Windows.UI.Input.Preview.Injection](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection)) を使用してアプリの 1 つの領域でマウス入力のイベントをリッスンし、別の領域で対応するタッチ入力のイベントをシミュレートする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-118">In this example, we demonstrate how to use the input injection APIs ([Windows.UI.Input.Preview.Injection](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection)) to listen for mouse input events in one region of an app, and simulate corresponding touch input events in another region.</span></span>

<span data-ttu-id="1ceb8-119">**このサンプルをからダウンロード[インジェクション サンプルの入力 (タッチをマウスの場合)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-input-injection-mouse-to-touch.zip)**</span><span class="sxs-lookup"><span data-stu-id="1ceb8-119">**Download this sample from [Input injection sample (mouse to touch)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-input-injection-mouse-to-touch.zip)**</span></span>

1. <span data-ttu-id="1ceb8-120">まず、UI を設定します (MainPage.xaml)。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-120">First, we set up the UI (MainPage.xaml).</span></span>

    <span data-ttu-id="1ceb8-121">2 つのグリッド領域 (マウス入力用に 1 つとタッチ入力用に 1 つ) があり、それぞれ 4 つのボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-121">We have two Grid areas (one for mouse input and one for injected touch input), each with four buttons.</span></span>
       > [!NOTE] The Grid background must be assigned a value (`Transparent`, in this case), otherwise pointer events are not detected.

    <span data-ttu-id="1ceb8-122">入力領域でマウスのクリックが検出されると、対応するタッチ イベントが入力の挿入領域に挿入されます。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-122">When any mouse clicks are detected in the input area, a corresponding touch event is injected into the input injection area.</span></span> <span data-ttu-id="1ceb8-123">挿入の入力からのボタンのクリックはタイトル領域で報告されます。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-123">Button clicks from inject input are reported in the title area.</span></span>

    ```xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel Grid.Row="0"
                    Margin="10">
            <TextBlock Style="{ThemeResource TitleTextBlockStyle}" 
                       Name="titleText"
                       Text="Touch input injection"
                       HorizontalTextAlignment="Center" />
            <TextBlock Style="{ThemeResource BodyTextBlockStyle}"
                       Name="statusText"
                       HorizontalTextAlignment="Center" />
        </StackPanel>
        <Grid HorizontalAlignment="Center"
                        Grid.Row="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <TextBlock Grid.Column="0" 
                       Grid.Row="0" 
                       Style="{ThemeResource CaptionTextBlockStyle}"
                       Text="User mouse input area"/>
            <!-- Background must be set to something, otherwise pointer events are not detected. -->
            <Grid Name="ContainerInput" 
                  Grid.Column="0" 
                  Grid.Row="1"
                  HorizontalAlignment="Stretch" 
                  Background="Transparent" 
                  BorderBrush="Green" 
                  BorderThickness="2" 
                  MinHeight="100" MinWidth="300" 
                  Margin="10">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <Button Name="B1" 
                        Grid.Column="0" 
                        HorizontalAlignment="Center" 
                        Width="50" Height="50"
                        Content="B1" />
                <Button Name="B2" 
                        Grid.Column="1" 
                        HorizontalAlignment="Center" 
                        Width="50" Height="50"
                        Content="B2" />
                <Button Name="B3" 
                        Grid.Column="2" 
                        HorizontalAlignment="Center" 
                        Width="50" Height="50"
                        Content="B3" />
                <Button Name="B4" 
                        Grid.Column="3" 
                        HorizontalAlignment="Center" 
                        Width="50" Height="50"
                        Content="B4" />
            </Grid>
            <TextBlock Grid.Column="1" 
                       Grid.Row="0"                         
                       Style="{ThemeResource CaptionTextBlockStyle}"
                       Text="Injected touch input area"/>
            <Grid Name="ContainerInject"
                  Grid.Column="1"  
                  Grid.Row="1"
                  HorizontalAlignment="Stretch"
                  BorderBrush="Red" 
                  BorderThickness="2" 
                  MinHeight="100" MinWidth="300" 
                  Margin="10">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <Button Name="B1i" Click="Button_Click_Injected"
                        Content="B1i"
                        Grid.Column="0" 
                        HorizontalAlignment="Center" 
                        Width="50" Height="50" />
                <Button Name="B2i" Click="Button_Click_Injected"
                        Content="B2i"
                        Grid.Column="1" 
                        HorizontalAlignment="Center" 
                        Width="50" Height="50" />
                <Button Name="B3i" Click="Button_Click_Injected"
                        Content="B3i"
                        Grid.Column="2" 
                        HorizontalAlignment="Center" 
                        Width="50" Height="50" />
                <Button Name="B4i" Click="Button_Click_Injected"
                        Content="B4i"
                        Grid.Column="3" 
                        HorizontalAlignment="Center" 
                        Width="50" Height="50" />
            </Grid>
        </Grid>
    </Grid>
    ```

2. <span data-ttu-id="1ceb8-124">次に、アプリを初期化します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-124">Next, we initialize our app.</span></span>
    
    <span data-ttu-id="1ceb8-125">このスニペットでは、グローバル オブジェクトを宣言し、ボタン クリック イベントで処理済みとしてマークされている可能性があるマウスの入力領域内でポインター イベント ([AddHandler](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.addhandler)) のリスナーを宣言します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-125">In this snippet, we declare our global objects and declare listeners for pointer events ([AddHandler](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.addhandler)) within the mouse input area that might be marked as handled in the button click events.</span></span>

    <span data-ttu-id="1ceb8-126">[InputInjector](https://docs.microsoft.com/api/windows.ui.input.preview.injection.inputinjector) オブジェクトは入力データを送信するための仮想入力デバイスを表します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-126">The [InputInjector](https://docs.microsoft.com/api/windows.ui.input.preview.injection.inputinjector) object represents the virtual input device for sending the input data.</span></span>

    <span data-ttu-id="1ceb8-127">`ContainerInput_PointerPressed` ハンドラーで、Touch Injection 関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-127">In the `ContainerInput_PointerPressed` handler we call the touch injection function.</span></span>

    <span data-ttu-id="1ceb8-128">`ContainerInput_PointerReleased` ハンドラーで、UninitializeTouchInjection を呼び出して [InputInjector](https://docs.microsoft.com/api/windows.ui.input.preview.injection.inputinjector) オブジェクトをシャットダウンします。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-128">In the `ContainerInput_PointerReleased` handler, we call UninitializeTouchInjection to shut down the [InputInjector](https://docs.microsoft.com/api/windows.ui.input.preview.injection.inputinjector) object.</span></span>

    ```csharp
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// The virtual input device.
        /// </summary>
        InputInjector _inputInjector;

        /// <summary>
        /// Initialize the app, set the window size, 
        /// and add pointer input handlers for the container.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize =
                new Size(600, 200);
            ApplicationView.PreferredLaunchWindowingMode =
                ApplicationViewWindowingMode.PreferredLaunchViewSize;

            // Button handles PointerPressed/PointerReleased in 
            // the Tapped routed event, but we need the container Grid 
            // to handle them also. Add a handler for both 
            // PointerPressedEvent and PointerReleasedEvent on the input Grid 
            // and set handledEventsToo to true.
            ContainerInput.AddHandler(PointerPressedEvent,
                new PointerEventHandler(ContainerInput_PointerPressed), true);
            ContainerInput.AddHandler(PointerReleasedEvent,
                new PointerEventHandler(ContainerInput_PointerReleased), true);
        }

        /// <summary>
        /// PointerReleased handler for all pointer conclusion events.
        /// PointerPressed and PointerReleased events do not always occur 
        /// in pairs, so your app should listen for and handle any event that 
        /// might conclude a pointer down (such as PointerExited, PointerCanceled, 
        /// and PointerCaptureLost).  
        /// </summary>
        /// <param name="sender">Source of the click event</param>
        /// <param name="e">Event args for the button click routed event</param>
        private void ContainerInput_PointerReleased(
            object sender, PointerRoutedEventArgs e)
        {
            // Prevent most handlers along the event route from handling event again.
            e.Handled = true;

            // Shut down the virtual input device.
            _inputInjector.UninitializeTouchInjection();
        }

        /// <summary>
        /// PointerPressed handler.
        /// PointerPressed and PointerReleased events do not always occur 
        /// in pairs. Your app should listen for and handle any event that 
        /// might conclude a pointer down (such as PointerExited, 
        /// PointerCanceled, and PointerCaptureLost).  
        /// </summary>
        /// <param name="sender">Source of the click event</param>
        /// <param name="e">Event args for the button click routed event</param>
        private void ContainerInput_PointerPressed(
            object sender, PointerRoutedEventArgs e)
        {
            // Prevent most handlers along the event route from 
            // handling the same event again.
            e.Handled = true;

            InjectTouchForMouse(e.GetCurrentPoint(ContainerInput));

        }
        ...
    }
    ```
3. <span data-ttu-id="1ceb8-129">タッチ入力の挿入関数は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-129">Here's the touch input injection function.</span></span>

    <span data-ttu-id="1ceb8-130">まず、[TryCreate](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.inputinjector.trycreate) を呼び出して、[InputInjector](https://docs.microsoft.com/api/windows.ui.input.preview.injection.inputinjector) オブジェクトを初期化します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-130">First, we call [TryCreate](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.inputinjector.trycreate) to instantiate the [InputInjector](https://docs.microsoft.com/api/windows.ui.input.preview.injection.inputinjector) object.</span></span>

    <span data-ttu-id="1ceb8-131">次に、`Default` の [InjectedInputVisualizationMode](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.injectedinputvisualizationmode) で [InitializeTouchInjection](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.inputinjector.initializetouchinjection) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-131">Then, we call [InitializeTouchInjection](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.inputinjector.initializetouchinjection) with an [InjectedInputVisualizationMode](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.injectedinputvisualizationmode) of `Default`.</span></span>

    <span data-ttu-id="1ceb8-132">挿入のポイントを計算した後で、[InjectedInputTouchInfo](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.injectedinputtouchinfo) を呼び出して、挿入するタッチ ポイントの一覧を初期化します (たとえば、マウス入力ポインターに対応する 1 つのタッチ ポイントを作成します)。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-132">After calculating the point of injection, we call [InjectedInputTouchInfo](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.injectedinputtouchinfo) to initialize the list of touch points to inject (for this example, we create one touch point corresponding to the mouse input pointer).</span></span>

    <span data-ttu-id="1ceb8-133">まず、[InjectTouchInput](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.inputinjector.injecttouchinput) を 2 回呼び出します。1 回目はポインター ダウン用で、2 回目はポインター アップ用です。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-133">Finally, we call [InjectTouchInput](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.inputinjector.injecttouchinput) twice, the first for a pointer down and the second for a pointer up.</span></span>

    ```csharp
    /// <summary>
    /// Inject touch input on injection target corresponding 
    /// to mouse click on input target.
    /// </summary>
    /// <param name="pointerPoint">The mouse click pointer.</param>
    private void InjectTouchForMouse(PointerPoint pointerPoint)
    {
        // Create the touch injection object.
        _inputInjector = InputInjector.TryCreate();

        if (_inputInjector != null)
        {
            _inputInjector.InitializeTouchInjection(
                InjectedInputVisualizationMode.Default);

            // Create a unique pointer ID for the injected touch pointer.
            // Multiple input pointers would require more robust handling.
            uint pointerId = pointerPoint.PointerId + 1;

            // Get the bounding rectangle of the app window.
            Rect appBounds =
                Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds;

            // Get the top left screen coordinates of the app window rect.
            Point appBoundsTopLeft = new Point(appBounds.Left, appBounds.Top);

            // Get a reference to the input injection area.
            GeneralTransform injectArea =
                ContainerInject.TransformToVisual(Window.Current.Content);

            // Get the top left screen coordinates of the input injection area.
            Point injectAreaTopLeft = injectArea.TransformPoint(new Point(0, 0));

            // Get the screen coordinates (relative to the input area) 
            // of the input pointer.
            int pointerPointX = (int)pointerPoint.Position.X;
            int pointerPointY = (int)pointerPoint.Position.Y;

            // Create the point for input injection and calculate its screen location.
            Point injectionPoint =
                new Point(
                    appBoundsTopLeft.X + injectAreaTopLeft.X + pointerPointX,
                    appBoundsTopLeft.Y + injectAreaTopLeft.Y + pointerPointY);

            // Create a touch data point for pointer down.
            // Each element in the touch data list represents a single touch contact. 
            // For this example, we're mirroring a single mouse pointer.
            List<InjectedInputTouchInfo> touchData =
                new List<InjectedInputTouchInfo>
                {
                    new InjectedInputTouchInfo
                    {
                        Contact = new InjectedInputRectangle
                        {
                            Left = 30, Top = 30, Bottom = 30, Right = 30
                        },
                        PointerInfo = new InjectedInputPointerInfo
                        {
                            PointerId = pointerId,
                            PointerOptions =
                            InjectedInputPointerOptions.PointerDown |
                            InjectedInputPointerOptions.InContact |
                            InjectedInputPointerOptions.New,
                            TimeOffsetInMilliseconds = 0,
                            PixelLocation = new InjectedInputPoint
                            {
                                PositionX = (int)injectionPoint.X ,
                                PositionY = (int)injectionPoint.Y
                            }
                    },
                    Pressure = 1.0,
                    TouchParameters =
                        InjectedInputTouchParameters.Pressure |
                        InjectedInputTouchParameters.Contact
                }
            };

            // Inject the touch input. 
            _inputInjector.InjectTouchInput(touchData);

            // Create a touch data point for pointer up.
            touchData = new List<InjectedInputTouchInfo>
            {
                new InjectedInputTouchInfo
                {
                    PointerInfo = new InjectedInputPointerInfo
                    {
                        PointerId = pointerId,
                        PointerOptions = InjectedInputPointerOptions.PointerUp
                    }
                }
            };

            // Inject the touch input. 
            _inputInjector.InjectTouchInput(touchData);
        }
    }
    ```

4. <span data-ttu-id="1ceb8-134">最後に、入力の挿入領域で任意の Button [Click](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.buttonbase) ルーティング イベントを処理し、クリックしたボタンの名前で UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="1ceb8-134">Finally, we handle any Button [Click](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.buttonbase) routed events in the input injection area and update the UI with the name of the button clicked.</span></span>

## <a name="see-also"></a><span data-ttu-id="1ceb8-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="1ceb8-135">See also</span></span>

### <a name="topic-samples"></a><span data-ttu-id="1ceb8-136">トピックのサンプル</span><span class="sxs-lookup"><span data-stu-id="1ceb8-136">Topic samples</span></span>

- [<span data-ttu-id="1ceb8-137">入力のインジェクション サンプル (タッチをマウスの場合)</span><span class="sxs-lookup"><span data-stu-id="1ceb8-137">Input injection sample (mouse to touch)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-input-injection-mouse-to-touch.zip)
