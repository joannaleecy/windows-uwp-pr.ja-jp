---
author: Karl-Bridge-Microsoft
ms.author: kbridge
title: 視線の操作
Description: Learn how to design and optimize your UWP apps to provide the best experience possible for users who rely on gaze input from eye and head trackers.
label: Gaze interactions
template: detail.hbs
keywords: 視線, 視線追跡, 頭の追跡, 視線ポイント, 入力, ユーザーの操作, アクセシビリティ, ユーザビリティ
ms.date: 05/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
pm-contact: Jake Cohen
dev-contact: Austin Hodges
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 2c7af1decbac405246f4250cf45c2f03bfafb899
ms.sourcegitcommit: 588171ea8cb629d2dd6aa2080e742dc8ce8584e5
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/17/2018
ms.locfileid: "1895088"
---
# <a name="gaze-interactions-and-eye-tracking-in-uwp-apps"></a><span data-ttu-id="20334-103">UWP アプリでの視線の操作と視線追跡</span><span class="sxs-lookup"><span data-stu-id="20334-103">Gaze interactions and eye tracking in UWP apps</span></span>

![視線追跡ヒーロー](images/gaze/eyecontrolbanner1.png)

<span data-ttu-id="20334-105">ユーザーの視線、注意、および場所とユーザーの目の動きに基づくプレゼンスを追跡するためのサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="20334-105">Provide support for tracking a user's gaze, attention, and presence based on the location and movement of their eyes.</span></span>

> [!NOTE]
> <span data-ttu-id="20334-106">[Windows Mixed Reality](https://docs.microsoft.com/windows/mixed-reality/) での視線入力については、「[視線](https://docs.microsoft.com/windows/mixed-reality/gaze)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="20334-106">For gaze input in [Windows Mixed Reality](https://docs.microsoft.com/windows/mixed-reality/), see [Gaze](https://docs.microsoft.com/windows/mixed-reality/gaze).</span></span>

<span data-ttu-id="20334-107">**重要な API**: [Windows.Devices.Input.Preview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview)、[GazeDevicePreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicepreview)、[GazePointPreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazepointpreview)、[GazeInputSourcePreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview)</span><span class="sxs-lookup"><span data-stu-id="20334-107">**Important APIs**: [Windows.Devices.Input.Preview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview), [GazeDevicePreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicepreview), [GazePointPreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazepointpreview), [GazeInputSourcePreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview)</span></span>

## <a name="overview"></a><span data-ttu-id="20334-108">概要</span><span class="sxs-lookup"><span data-stu-id="20334-108">Overview</span></span>

<span data-ttu-id="20334-109">視線入力は、Windows および UWP アプリケーションを操作して使用するための強力な手段です。これは、ALS などの神経原性筋萎縮症や、筋肉や神経の機能障害を含むその他の障碍を持つユーザーの支援技術として特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="20334-109">Gaze input is a powerful way to interact and use Windows and UWP applications that is especially useful as an assistive technology for users with neuro-muscular diseases (such as ALS) and other disabilities involving impaired muscle or nerve functions.</span></span>

<span data-ttu-id="20334-110">さらに、視線入力は、ゲーム (ターゲット把握や追跡を含む) や従来の生産性向上アプリケーション、キオスクだけでなく、従来の入力デバイス (キーボード、マウス、タッチ) が使用できないか、ユーザーの両手を他のタスク (買い袋を持つなど) のために開放することが便利である可能性のあるその他の対話型シナリオで、同様に魅力的な機会をもたらします。</span><span class="sxs-lookup"><span data-stu-id="20334-110">In addition, gaze input offers equally compelling opportunities for both gaming (including target acquisition and tracking) and traditional productivity applications, kiosks, and other interactive scenarios where traditional input devices (keyboard, mouse, touch) are not available, or where it might be useful/helpful to free up the user's hands for other tasks (such as holding shopping bags).</span></span>

> [!NOTE]
> <span data-ttu-id="20334-111">視線追跡ハードウェアのサポートは、**Windows 10 Fall Creators Update** で[視線制御](https://support.microsoft.com/en-us/help/4043921/windows-10-get-started-eye-control)と共に導入されました。視線制御は、ユーザーが目を使用して画面上のポインターを制御し、スクリーン キーボードで入力し、音声合成を使用して人々とやり取りすることができる組み込み機能です。</span><span class="sxs-lookup"><span data-stu-id="20334-111">Support for eye tracking hardware was introduced in **Windows 10 Fall Creators Update** along with [Eye control](https://support.microsoft.com/en-us/help/4043921/windows-10-get-started-eye-control), a built-in feature that lets you use your eyes to control the on-screen pointer, type with the on-screen keyboard, and communicate with people using text-to-speech.</span></span> <span data-ttu-id="20334-112">視線追跡ハードウェアと対話できるアプリケーションを作成するための [UWP API]([Windows.Devices.Input.Preview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview)) のセットは、**Windows 10 April 2018 Update (バージョン 1803、ビルド 17134)** 以降で利用可能です。</span><span class="sxs-lookup"><span data-stu-id="20334-112">A set of [UWP APIs]([Windows.Devices.Input.Preview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview)) for building applications that can interact with eye tracking hardware is available with **Windows 10 April 2018 Update (Version 1803, build 17134)** and newer.</span></span>

## <a name="privacy"></a><span data-ttu-id="20334-113">プライバシー</span><span class="sxs-lookup"><span data-stu-id="20334-113">Privacy</span></span>

<span data-ttu-id="20334-114">視線追跡デバイスで収集された機密性が高い可能性のある個人データのために、UWP アプリケーションのアプリ マニフェストで `gazeInput` 機能を宣言することが必要になります (次の「**セットアップ**」セクションを参照してください)。</span><span class="sxs-lookup"><span data-stu-id="20334-114">Due to the potentially sensitive personal data collected by eye tracking devices, you are required to declare the `gazeInput` capability in the app manifest of your UWP application (see the following **Setup** section).</span></span> <span data-ttu-id="20334-115">宣言すると、アプリが最初に実行されたときに Windows によって自動的にユーザーに同意ダイアログ ボックスが表示されます。ここでは、ユーザーはアプリが視線追跡デバイスと通信して、このデータにアクセスできるようにアクセス許可を付与する必要があります。</span><span class="sxs-lookup"><span data-stu-id="20334-115">When declared, Windows automatically prompts users with a consent dialog (when the app is first run), where the user must grant permission for the app to communicate with the eye-tracking device and access this data.</span></span>

<span data-ttu-id="20334-116">さらに、アプリが視線追跡データを収集、保存、転送する場合は、アプリのプライバシーに関する声明でこれを宣言し、[Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)と[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)の**個人情報**のその他すべての要件に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="20334-116">In addition, if your app collects, stores, or transfers eye tracking data, you must describe this in your app's privacy statement and follow all other requirements for **Personal Information** in the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement) and the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span>

## <a name="setup"></a><span data-ttu-id="20334-117">セットアップ</span><span class="sxs-lookup"><span data-stu-id="20334-117">Setup</span></span>

<span data-ttu-id="20334-118">UWP アプリで視線入力 API を使用するには、次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="20334-118">To use the gaze input APIs in your UWP app you'll need to:</span></span> 

- <span data-ttu-id="20334-119">アプリ マニフェストで `gazeInput` 機能を指定します。</span><span class="sxs-lookup"><span data-stu-id="20334-119">Specify the `gazeInput` capability in the app manifest.</span></span>

    <span data-ttu-id="20334-120">Visual Studio マニフェスト デザイナーで **Package.appxmanifest** ファイルを開くか、または手動で **[コードの表示]** を選択し、次の `DeviceCapability` を `Capabilities` ノードに挿入することで機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="20334-120">Open the **Package.appxmanifest** file with the Visual Studio manifest designer, or add the capability manually by selecting **View code**, and inserting the following `DeviceCapability` into the `Capabilities` node:</span></span>

    ```xaml
    <Capabilities>
       <DeviceCapability Name="gazeInput" />
    </Capabilities>
    ```

- <span data-ttu-id="20334-121">Windows と互換性のある視線追跡デバイスがシステム (組み込みまたは外付け) に接続され、オンになりました。</span><span class="sxs-lookup"><span data-stu-id="20334-121">A Windows-compatible eye-tracking device connected to your system (either built-in or peripheral) and turned on.</span></span>

    <span data-ttu-id="20334-122">サポートされる視線追跡デバイスの一覧については、「[Windows 10 の視線制御の概要](https://support.microsoft.com/help/4043921/windows-10-get-started-eye-control#supported-devices )」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="20334-122">See [Get started with eye control in Windows 10](https://support.microsoft.com/help/4043921/windows-10-get-started-eye-control#supported-devices ) for a list of supported eye-tracking devices.</span></span>

## <a name="basic-eye-tracking"></a><span data-ttu-id="20334-123">基本的な視線追跡</span><span class="sxs-lookup"><span data-stu-id="20334-123">Basic eye tracking</span></span>

<span data-ttu-id="20334-124">この例では、UWP アプリケーション内でユーザーの視線を追跡し、基本的なヒット テストでタイミング関数を使用して、ユーザーが特定の要素で視線のフォーカスをどの程度維持できるかを示す方法を示します。</span><span class="sxs-lookup"><span data-stu-id="20334-124">In this example, we demonstrate how to track the user's gaze within a UWP application and use a timing function with basic hit testing to indicate how well they can maintain their gaze focus on a specific element.</span></span>

<span data-ttu-id="20334-125">小さな楕円を使用して視線のポイントがアプリケーションのビューポート内のどこにあるかを示しますが、[Windows コミュニティ ツールキット](https://docs.microsoft.com/en-us/windows/uwpcommunitytoolkit/)の [RadialProgressBar](https://docs.microsoft.com/en-us/windows/uwpcommunitytoolkit/controls/radialprogressbar) はキャンバス上でランダムに配置されます。</span><span class="sxs-lookup"><span data-stu-id="20334-125">A small ellipse is used to show where the gaze point is within the application viewport, while a [RadialProgressBar](https://docs.microsoft.com/en-us/windows/uwpcommunitytoolkit/controls/radialprogressbar) from the [Windows Community Toolkit](https://docs.microsoft.com/en-us/windows/uwpcommunitytoolkit/) is placed randomly on the canvas.</span></span> <span data-ttu-id="20334-126">進行状況バーで注視フォーカスが検出されると、タイマーが開始し、進行状況バーが 100% に達したときに、キャンバスで、進行状況バーがランダムに移動します。</span><span class="sxs-lookup"><span data-stu-id="20334-126">When gaze focus is detected on the progress bar, a timer is started and the progress bar is randomly relocated on the canvas when the progress bar reaches 100%.</span></span>

![タイマーのサンプルを使用した視線追跡](images/gaze/gaze-input-timed2.gif)

*<span data-ttu-id="20334-128">タイマーのサンプルを使用した視線追跡</span><span class="sxs-lookup"><span data-stu-id="20334-128">Gaze tracking with timer sample</span></span>*

**<span data-ttu-id="20334-129">このサンプルは、「[視線入力のサンプル (基本)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-gazeinput-basic.zip)」でダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="20334-129">Download this sample from [Gaze input sample (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-gazeinput-basic.zip)</span></span>**

1. <span data-ttu-id="20334-130">まず、UI を設定します (MainPage.xaml)。</span><span class="sxs-lookup"><span data-stu-id="20334-130">First, we set up the UI (MainPage.xaml).</span></span>

    ```xaml
    <Page
        x:Class="gazeinput.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:gazeinput"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:controls="using:Microsoft.Toolkit.Uwp.UI.Controls"    
        mc:Ignorable="d">
    
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <Grid x:Name="containerGrid">
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
                           Text="Gaze tracking sample" 
                           Style="{ThemeResource HeaderTextBlockStyle}" 
                           Margin="10,0,0,0" />
                    <TextBlock x:Name="TrackerCounterLabel"
                           VerticalAlignment="Center"                 
                           Style="{ThemeResource BodyTextBlockStyle}"
                           Text="Number of trackers: " 
                           Margin="50,0,0,0"/>
                    <TextBlock x:Name="TrackerCounter"
                           VerticalAlignment="Center"                 
                           Style="{ThemeResource BodyTextBlockStyle}"
                           Text="0" 
                           Margin="10,0,0,0"/>
                    <TextBlock x:Name="TrackerStateLabel"
                           VerticalAlignment="Center"                 
                           Style="{ThemeResource BodyTextBlockStyle}"
                           Text="State: " 
                           Margin="50,0,0,0"/>
                    <TextBlock x:Name="TrackerState"
                           VerticalAlignment="Center"                 
                           Style="{ThemeResource BodyTextBlockStyle}"
                           Text="n/a" 
                           Margin="10,0,0,0"/>
                </StackPanel>
                <Canvas x:Name="gazePositionCanvas" Grid.Row="1">
                    <controls:RadialProgressBar
                        x:Name="GazeRadialProgressBar" 
                        Value="0"
                        Foreground="Blue" 
                        Background="White"
                        Thickness="4"
                        Minimum="0"
                        Maximum="100"
                        Width="100"
                        Height="100"
                        Outline="Gray"
                        Visibility="Collapsed"/>
                    <Ellipse 
                        x:Name="eyeGazePositionEllipse"
                        Width="20" Height="20"
                        Fill="Blue" 
                        Opacity="0.5" 
                        Visibility="Collapsed">
                    </Ellipse>
                </Canvas>
            </Grid>
        </Grid>
    </Page>
    ```

2. <span data-ttu-id="20334-131">次に、アプリを初期化します。</span><span class="sxs-lookup"><span data-stu-id="20334-131">Next, we initialize our app.</span></span>

    <span data-ttu-id="20334-132">このスニペットでは、グローバル オブジェクトを宣言し、[OnNavigatedTo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto) ページ イベントを上書きして[視線デバイス ウォッチャー](https://docs.microsoft.com/en-us/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview)を開始し、[OnNavigatedFrom](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedfrom) ページ イベントを上書きして[視線デバイス ウォッチャー](https://docs.microsoft.com/en-us/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview)を停止します。</span><span class="sxs-lookup"><span data-stu-id="20334-132">In this snippet, we declare our global objects and override the [OnNavigatedTo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedto) page event to start our [gaze device watcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview) and the [OnNavigatedFrom](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page.onnavigatedfrom) page event to stop our [gaze device watcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview).</span></span>

    ```csharp
    using System;
    using Windows.Devices.Input.Preview;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml;
    using Windows.Foundation;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    
    namespace gazeinput
    {
        public sealed partial class MainPage : Page
        {
            /// <summary>
            /// Reference to the user's eyes and head as detected
            /// by the eye-tracking device.
            /// </summary>
            private GazeInputSourcePreview gazeInputSource;
    
            /// <summary>
            /// Dynamic store of eye-tracking devices.
            /// </summary>
            /// <remarks>
            /// Receives event notifications when a device is added, removed, 
            /// or updated after the initial enumeration.
            /// </remarks>
            private GazeDeviceWatcherPreview gazeDeviceWatcher;
    
            /// <summary>
            /// Eye-tracking device counter.
            /// </summary>
            private int deviceCounter = 0;
    
            /// <summary>
            /// Timer for gaze focus on RadialProgressBar.
            /// </summary>
            DispatcherTimer timerGaze = new DispatcherTimer();
    
            /// <summary>
            /// Tracker used to prevent gaze timer restarts.
            /// </summary>
            bool timerStarted = false;
    
            /// <summary>
            /// Initialize the app.
            /// </summary>
            public MainPage()
            {
                InitializeComponent();
            }

            /// <summary>
            /// Override of OnNavigatedTo page event starts GazeDeviceWatcher.
            /// </summary>
            /// <param name="e">Event args for the NavigatedTo event</param>
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                // Start listening for device events on navigation to eye-tracking page.
                StartGazeDeviceWatcher();
            }
    
            /// <summary>
            /// Override of OnNavigatedFrom page event stops GazeDeviceWatcher.
            /// </summary>
            /// <param name="e">Event args for the NavigatedFrom event</param>
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                // Stop listening for device events on navigation from eye-tracking page.
                StopGazeDeviceWatcher();
            }
            ...
        }
    }
    ```

3. <span data-ttu-id="20334-133">次に、視線デバイス ウォッチャーのメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="20334-133">Next, we add our gaze device watcher methods.</span></span> 
    
    <span data-ttu-id="20334-134">`StartGazeDeviceWatcher` で、[CreateWatcher](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview.createwatcher) を呼び出し、視線追跡デバイスのイベント リスナー ([DeviceAdded](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview.added)、[DeviceUpdated](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview.updated)、[DeviceRemoved](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview.removed)) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="20334-134">In `StartGazeDeviceWatcher`, we call [CreateWatcher](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview.createwatcher) and declare the eye-tracking device event listeners ([DeviceAdded](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview.added), [DeviceUpdated](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview.updated), and [DeviceRemoved](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview.removed)).</span></span>

    <span data-ttu-id="20334-135">`DeviceAdded` で、視線追跡デバイスの状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="20334-135">In `DeviceAdded`, we check the state of the eye-tracking device.</span></span> <span data-ttu-id="20334-136">実行可能なデバイスで、デバイス カウントをインクリメントし、視線追跡を有効にします。</span><span class="sxs-lookup"><span data-stu-id="20334-136">If a viable device, we increment our device count and enable gaze tracking.</span></span> <span data-ttu-id="20334-137">詳細については、次の手順を参照してください。</span><span class="sxs-lookup"><span data-stu-id="20334-137">See next step for details.</span></span>

    <span data-ttu-id="20334-138">`DeviceUpdated` では、デバイスが再調整された場合にこのイベントがトリガーされたときにも視線追跡を有効にします。</span><span class="sxs-lookup"><span data-stu-id="20334-138">In `DeviceUpdated`, we also enable gaze tracking as this event is triggered if a device is recalibrated.</span></span>

    <span data-ttu-id="20334-139">`DeviceRemoved` では、デバイス カウンターをデクリメントし、デバイスのイベント ハンドラーを削除します。</span><span class="sxs-lookup"><span data-stu-id="20334-139">In `DeviceRemoved`, we decrement our device counter and remove the device event handlers.</span></span>

    <span data-ttu-id="20334-140">`StopGazeDeviceWatcher` で、視線デバイス ウォッチャーをシャットダウンします。</span><span class="sxs-lookup"><span data-stu-id="20334-140">In `StopGazeDeviceWatcher`, we shut down the gaze device watcher.</span></span> 

```csharp
    /// <summary>
    /// Start gaze watcher and declare watcher event handlers.
    /// </summary>
    private void StartGazeDeviceWatcher()
    {
        if (gazeDeviceWatcher == null)
        {
            gazeDeviceWatcher = GazeInputSourcePreview.CreateWatcher();
            gazeDeviceWatcher.Added += this.DeviceAdded;
            gazeDeviceWatcher.Updated += this.DeviceUpdated;
            gazeDeviceWatcher.Removed += this.DeviceRemoved;
            gazeDeviceWatcher.Start();
        }
    }

    /// <summary>
    /// Shut down gaze watcher and stop listening for events.
    /// </summary>
    private void StopGazeDeviceWatcher()
    {
        if (gazeDeviceWatcher != null)
        {
            gazeDeviceWatcher.Stop();
            gazeDeviceWatcher.Added -= this.DeviceAdded;
            gazeDeviceWatcher.Updated -= this.DeviceUpdated;
            gazeDeviceWatcher.Removed -= this.DeviceRemoved;
            gazeDeviceWatcher = null;
        }
    }

    /// <summary>
    /// Eye-tracking device connected (added, or available when watcher is initialized).
    /// </summary>
    /// <param name="sender">Source of the device added event</param>
    /// <param name="e">Event args for the device added event</param>
    private void DeviceAdded(GazeDeviceWatcherPreview source, 
        GazeDeviceWatcherAddedPreviewEventArgs args)
    {
        if (IsSupportedDevice(args.Device))
        {
            deviceCounter++;
            TrackerCounter.Text = deviceCounter.ToString();
        }
        // Set up gaze tracking.
        TryEnableGazeTrackingAsync(args.Device);
    }

    /// <summary>
    /// Initial device state might be uncalibrated, 
    /// but device was subsequently calibrated.
    /// </summary>
    /// <param name="sender">Source of the device updated event</param>
    /// <param name="e">Event args for the device updated event</param>
    private void DeviceUpdated(GazeDeviceWatcherPreview source,
        GazeDeviceWatcherUpdatedPreviewEventArgs args)
    {
        // Set up gaze tracking.
        TryEnableGazeTrackingAsync(args.Device);
    }

    /// <summary>
    /// Handles disconnection of eye-tracking devices.
    /// </summary>
    /// <param name="sender">Source of the device removed event</param>
    /// <param name="e">Event args for the device removed event</param>
    private void DeviceRemoved(GazeDeviceWatcherPreview source,
        GazeDeviceWatcherRemovedPreviewEventArgs args)
    {
        // Decrement gaze device counter and remove event handlers.
        if (IsSupportedDevice(args.Device))
        {
            deviceCounter--;
            TrackerCounter.Text = deviceCounter.ToString();

            if (deviceCounter == 0)
            {
                gazeInputSource.GazeEntered -= this.GazeEntered;
                gazeInputSource.GazeMoved -= this.GazeMoved;
                gazeInputSource.GazeExited -= this.GazeExited;
            }
        }
    }
```

4. <span data-ttu-id="20334-141">ここでは、デバイスが `IsSupportedDevice` で実行可能であるかどうかを確認し、実行可能であれば、`TryEnableGazeTrackingAsync` で視線追跡を有効にすることを試みます。</span><span class="sxs-lookup"><span data-stu-id="20334-141">Here, we check if the device is viable in `IsSupportedDevice` and, if so, attempt to enable gaze tracking in `TryEnableGazeTrackingAsync`.</span></span>

    <span data-ttu-id="20334-142">`TryEnableGazeTrackingAsync` では、視線のイベント ハンドラーを宣言し、[GazeInputSourcePreview.GetForCurrentView()](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview.getforcurrentview) を呼び出して入力ソースへの参照を取得します (これは UI スレッドで呼び出す必要があります。「[UI スレッドの応答性の確保](https://docs.microsoft.com/windows/uwp/debug-test-perf/keep-the-ui-thread-responsive)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="20334-142">In `TryEnableGazeTrackingAsync`, we declare the gaze event handlers, and call [GazeInputSourcePreview.GetForCurrentView()](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview.getforcurrentview) to get a reference to the input source (this must be called on the UI thread, see [Keep the UI thread responsive](https://docs.microsoft.com/windows/uwp/debug-test-perf/keep-the-ui-thread-responsive)).</span></span>

    > [!NOTE]
    > <span data-ttu-id="20334-143">[GazeInputSourcePreview.GetForCurrentView()](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview.getforcurrentview) は、互換性のある視線追跡デバイスが接続され、アプリケーションで必要な場合にのみ呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="20334-143">You should call [GazeInputSourcePreview.GetForCurrentView()](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview.getforcurrentview) only when a compatible eye-tracking device is connected and required by your application.</span></span> <span data-ttu-id="20334-144">それ以外の場合、同意ダイアログ ボックスは不要です。</span><span class="sxs-lookup"><span data-stu-id="20334-144">Otherwise, the consent dialog is unnecessary.</span></span>

```csharp
    /// <summary>
    /// Initialize gaze tracking.
    /// </summary>
    /// <param name="gazeDevice"></param>
    private async void TryEnableGazeTrackingAsync(GazeDevicePreview gazeDevice)
    {
        // If eye-tracking device is ready, declare event handlers and start tracking.
        if (IsSupportedDevice(gazeDevice))
        {
            timerGaze.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timerGaze.Tick += TimerGaze_Tick;

            SetGazeTargetLocation();

            // This must be called from the UI thread.
            gazeInputSource = GazeInputSourcePreview.GetForCurrentView();

            gazeInputSource.GazeEntered += GazeEntered;
            gazeInputSource.GazeMoved += GazeMoved;
            gazeInputSource.GazeExited += GazeExited;
        }
        // Notify if device calibration required.
        else if (gazeDevice.ConfigurationState ==
                    GazeDeviceConfigurationStatePreview.UserCalibrationNeeded ||
                    gazeDevice.ConfigurationState ==
                    GazeDeviceConfigurationStatePreview.ScreenSetupNeeded)
        {
            // Device isn't calibrated, so invoke the calibration handler.
            System.Diagnostics.Debug.WriteLine(
                "Your device needs to calibrate. Please wait for it to finish.");
            await gazeDevice.RequestCalibrationAsync();
        }
        // Notify if device calibration underway.
        else if (gazeDevice.ConfigurationState == 
            GazeDeviceConfigurationStatePreview.Configuring)
        {
            // Device is currently undergoing calibration.  
            // A device update is sent when calibration complete.
            System.Diagnostics.Debug.WriteLine(
                "Your device is being configured. Please wait for it to finish"); 
        }
        // Device is not viable.
        else if (gazeDevice.ConfigurationState == GazeDeviceConfigurationStatePreview.Unknown)
        {
            // Notify if device is in unknown state.  
            // Reconfigure/recalbirate the device.  
            System.Diagnostics.Debug.WriteLine(
                "Your device is not ready. Please set up your device or reconfigure it."); 
        }
    }

    /// <summary>
    /// Check if eye-tracking device is viable.
    /// </summary>
    /// <param name="gazeDevice">Reference to eye-tracking device.</param>
    /// <returns>True, if device is viable; otherwise, false.</returns>
    private bool IsSupportedDevice(GazeDevicePreview gazeDevice)
    {
        TrackerState.Text = gazeDevice.ConfigurationState.ToString();
        return (gazeDevice.CanTrackEyes &&
                    gazeDevice.ConfigurationState == 
                    GazeDeviceConfigurationStatePreview.Ready);
    }
```

5. <span data-ttu-id="20334-145">次に、視線のイベント ハンドラーを設定します。</span><span class="sxs-lookup"><span data-stu-id="20334-145">Next, we set up our gaze event handlers.</span></span>

    <span data-ttu-id="20334-146">視線追跡の楕円を `GazeEntered` で表示し、`GazeExited` で非表示にします。</span><span class="sxs-lookup"><span data-stu-id="20334-146">We display and hide the gaze tracking ellipse in `GazeEntered` and `GazeExited`, respectively.</span></span>

    <span data-ttu-id="20334-147">`GazeMoved` では、[GazeEnteredPreviewEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeenteredprevieweventargs) の [CurrentPoint](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeenteredprevieweventargs.currentpoint) で提供される [EyeGazePosition](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazepointpreview.eyegazeposition) に基づいて視線追跡の楕円を移動します。</span><span class="sxs-lookup"><span data-stu-id="20334-147">In `GazeMoved`, we move our gaze tracking ellipse based on the [EyeGazePosition](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazepointpreview.eyegazeposition) provided by the [CurrentPoint](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeenteredprevieweventargs.currentpoint) of the [GazeEnteredPreviewEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeenteredprevieweventargs).</span></span> <span data-ttu-id="20334-148">また、[RadialProgressBar](https://docs.microsoft.com/en-us/windows/uwpcommunitytoolkit/controls/radialprogressbar) で視線フォーカスのタイマーを管理します。これにより進行状況バーの位置変更がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="20334-148">We also manage the gaze focus timer on the [RadialProgressBar](https://docs.microsoft.com/en-us/windows/uwpcommunitytoolkit/controls/radialprogressbar), which triggers repositioning of the progress bar.</span></span> <span data-ttu-id="20334-149">詳細については、次の手順を参照してください。</span><span class="sxs-lookup"><span data-stu-id="20334-149">See next step for details.</span></span>

    ```csharp
    /// <summary>
    /// GazeEntered handler.
    /// </summary>
    /// <param name="sender">Source of the gaze entered event</param>
    /// <param name="e">Event args for the gaze entered event</param>
    private void GazeEntered(
        GazeInputSourcePreview sender, 
        GazeEnteredPreviewEventArgs args)
    {
        // Show ellipse representing gaze point.
        eyeGazePositionEllipse.Visibility = Visibility.Visible;

        // Mark the event handled.
        args.Handled = true;
    }

    /// <summary>
    /// GazeExited handler.
    /// Call DisplayRequest.RequestRelease to conclude the 
    /// RequestActive called in GazeEntered.
    /// </summary>
    /// <param name="sender">Source of the gaze exited event</param>
    /// <param name="e">Event args for the gaze exited event</param>
    private void GazeExited(
        GazeInputSourcePreview sender, 
        GazeExitedPreviewEventArgs args)
    {
        // Hide gaze tracking ellipse.
        eyeGazePositionEllipse.Visibility = Visibility.Collapsed;

        // Mark the event handled.
        args.Handled = true;
    }

    /// <summary>
    /// GazeMoved handler translates the ellipse on the canvas to reflect gaze point.
    /// </summary>
    /// <param name="sender">Source of the gaze moved event</param>
    /// <param name="e">Event args for the gaze moved event</param>
    private void GazeMoved(GazeInputSourcePreview sender, GazeMovedPreviewEventArgs args)
    {
        // Update the position of the ellipse corresponding to gaze point.
        if (args.CurrentPoint.EyeGazePosition != null)
        {
            double gazePointX = args.CurrentPoint.EyeGazePosition.Value.X;
            double gazePointY = args.CurrentPoint.EyeGazePosition.Value.Y;

            double ellipseLeft = 
                gazePointX - 
                (eyeGazePositionEllipse.Width / 2.0f);
            double ellipseTop = 
                gazePointY - 
                (eyeGazePositionEllipse.Height / 2.0f) - 
                (int)Header.ActualHeight;

            // Translate transform for moving gaze ellipse.
            TranslateTransform translateEllipse = new TranslateTransform
            {
                X = ellipseLeft,
                Y = ellipseTop
            };

            eyeGazePositionEllipse.RenderTransform = translateEllipse;

            // The gaze point screen location.
            Point gazePoint = new Point(gazePointX, gazePointY);

            // Basic hit test to determine if gaze point is on progress bar.
            bool hitRadialProgressBar = 
                DoesElementContainPoint(
                    gazePoint, 
                    GazeRadialProgressBar.Name, 
                    GazeRadialProgressBar); 

            // Use progress bar thickness for visual feedback.
            if (hitRadialProgressBar)
            {
                GazeRadialProgressBar.Thickness = 10;
            }
            else
            {
                GazeRadialProgressBar.Thickness = 4;
            }

            // Mark the event handled.
            args.Handled = true;
        }
    }
    ```
6. <span data-ttu-id="20334-150">最後に、このアプリの視線フォーカス タイマーを管理するために使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="20334-150">Finally, here are the methods used to manage the gaze focus timer for this app.</span></span>

    `DoesElementContainPoint` <span data-ttu-id="20334-151">は、視線ポインターが進行状況バーを超えているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="20334-151">checks if the gaze pointer is over the progress bar.</span></span> <span data-ttu-id="20334-152">超えている場合は、視線タイマーを開始し、それぞれの視線タイマー ティックで進行状況バーをインクリメントします。</span><span class="sxs-lookup"><span data-stu-id="20334-152">If so, it starts the gaze timer and increments the progress bar on each gaze timer tick.</span></span>

    `SetGazeTargetLocation` <span data-ttu-id="20334-153">は、進行状況バーの最初の場所を設定し、進行状況バーが (視線フォーカス タイマーに応じて) 完了すると、進行状況バーを任意の場所に移動します。</span><span class="sxs-lookup"><span data-stu-id="20334-153">sets the initial location of the progress bar and, if the progress bar completes (depending on the gaze focus timer), moves the progress bar to a random location.</span></span>

    ```csharp
    /// <summary>
    /// Return whether the gaze point is over the progress bar.
    /// </summary>
    /// <param name="gazePoint">The gaze point screen location</param>
    /// <param name="elementName">The progress bar name</param>
    /// <param name="uiElement">The progress bar UI element</param>
    /// <returns></returns>
    private bool DoesElementContainPoint(
        Point gazePoint, string elementName, UIElement uiElement)
    {
        // Use entire visual tree of progress bar.
        IEnumerable<UIElement> elementStack = 
            VisualTreeHelper.FindElementsInHostCoordinates(gazePoint, uiElement, true);
        foreach (UIElement item in elementStack)
        {
            //Cast to FrameworkElement and get element name.
            if (item is FrameworkElement feItem)
            {
                if (feItem.Name.Equals(elementName))
                {
                    if (!timerStarted)
                    {
                        // Start gaze timer if gaze over element.
                        timerGaze.Start();
                        timerStarted = true;
                    }
                    return true;
                }
            }
        }

        // Stop gaze timer and reset progress bar if gaze leaves element.
        timerGaze.Stop();
        GazeRadialProgressBar.Value = 0;
        timerStarted = false;
        return false;
    }

    /// <summary>
    /// Tick handler for gaze focus timer.
    /// </summary>
    /// <param name="sender">Source of the gaze entered event</param>
    /// <param name="e">Event args for the gaze entered event</param>
    private void TimerGaze_Tick(object sender, object e)
    {
        // Increment progress bar.
        GazeRadialProgressBar.Value += 1;

        // If progress bar reaches maximum value, reset and relocate.
        if (GazeRadialProgressBar.Value == 100)
        {
            SetGazeTargetLocation();
        }
    }

    /// <summary>
    /// Set/reset the screen location of the progress bar.
    /// </summary>
    private void SetGazeTargetLocation()
    {
        // Ensure the gaze timer restarts on new progress bar location.
        timerGaze.Stop();
        timersStarted = false;

        // Get the bounding rectangle of the app window.
        Rect appBounds = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds;

        // Translate transform for moving progress bar.
        TranslateTransform translateTarget = new TranslateTransform();

        // Calculate random location within gaze canvas.
            Random random = new Random();
            int randomX = 
                random.Next(
                    0, 
                    (int)appBounds.Width - (int)GazeRadialProgressBar.Width);
            int randomY = 
                random.Next(
                    0, 
                    (int)appBounds.Height - (int)GazeRadialProgressBar.Height - (int)Header.ActualHeight);

        translateTarget.X = randomX;
        translateTarget.Y = randomY;

        GazeRadialProgressBar.RenderTransform = translateTarget;

        // Show progress bar.
        GazeRadialProgressBar.Visibility = Visibility.Visible;
        GazeRadialProgressBar.Value = 0;
    }
    ```

## <a name="see-also"></a><span data-ttu-id="20334-154">関連項目</span><span class="sxs-lookup"><span data-stu-id="20334-154">See also</span></span>

### <a name="resources"></a><span data-ttu-id="20334-155">リソース</span><span class="sxs-lookup"><span data-stu-id="20334-155">Resources</span></span>

- [<span data-ttu-id="20334-156">Windows コミュニティ ツールキットの視線ライブラリ</span><span class="sxs-lookup"><span data-stu-id="20334-156">Windows Community Toolkit Gaze library</span></span>](https://docs.microsoft.com/en-us/windows/uwpcommunitytoolkit/gaze/gazeinteractionlibrary)

### <a name="topic-samples"></a><span data-ttu-id="20334-157">トピックのサンプル</span><span class="sxs-lookup"><span data-stu-id="20334-157">Topic samples</span></span>

- [<span data-ttu-id="20334-158">視線のサンプル (基本) (C#)</span><span class="sxs-lookup"><span data-stu-id="20334-158">Gaze sample (basic) (C#)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-gazeinput-basic.zip)
