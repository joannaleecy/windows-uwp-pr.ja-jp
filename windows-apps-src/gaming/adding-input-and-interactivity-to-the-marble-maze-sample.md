---
title: Marble Maze サンプルへの入力と対話機能の追加
description: 入力デバイスを操作するときに留意する必要がある主なプラクティスについて説明します。
ms.assetid: b946bf62-c0ca-f9ec-1a87-8195b89a5ab4
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, サンプル
ms.localizationpriority: medium
ms.openlocfilehash: d545f696a93bfa8416e1a772ecc015867a3615c2
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/04/2019
ms.locfileid: "9045448"
---
# <a name="adding-input-and-interactivity-to-the-marble-maze-sample"></a><span data-ttu-id="a2082-104">Marble Maze サンプルへの入力と対話機能の追加</span><span class="sxs-lookup"><span data-stu-id="a2082-104">Adding input and interactivity to the Marble Maze sample</span></span>




<span data-ttu-id="a2082-105">ユニバーサル Windows プラットフォーム (UWP) ゲームは、デスクトップ コンピューター、ノート PC、タブレットなど、さまざまなデバイスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-105">Universal Windows Platform (UWP) games run on a wide variety of devices, such as desktop computers, laptops, and tablets.</span></span> <span data-ttu-id="a2082-106">デバイスに備わっている入力機構と制御機構も多岐にわたります。</span><span class="sxs-lookup"><span data-stu-id="a2082-106">A device can have a plethora of input and control mechanisms.</span></span> <span data-ttu-id="a2082-107">このドキュメントでは、入力デバイスを扱う際に考慮する必要のある主な手法について説明すると共に、それらが Marble Maze でどのように適用されているかを紹介します。</span><span class="sxs-lookup"><span data-stu-id="a2082-107">This document describes the key practices to keep in mind when you work with input devices and shows how Marble Maze applies these practices.</span></span>

> [!NOTE]
> <span data-ttu-id="a2082-108">このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](https://go.microsoft.com/fwlink/?LinkId=624011)にあります。</span><span class="sxs-lookup"><span data-stu-id="a2082-108">The sample code that corresponds to this document is found in the [DirectX Marble Maze game sample](https://go.microsoft.com/fwlink/?LinkId=624011).</span></span>

 
<span data-ttu-id="a2082-109">このドキュメントでは、ゲームで入力を扱う際に重要となるいくつかの事柄について説明します。取り上げる内容は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a2082-109">Here are some of the key points that this document discusses for when you work with input in your game:</span></span>

-   <span data-ttu-id="a2082-110">可能な限り、多様な入力デバイスをサポートし、ゲーム ユーザーの好みや技量に幅広く対応します。</span><span class="sxs-lookup"><span data-stu-id="a2082-110">When possible, support multiple input devices to enable your game to accommodate a wider range of preferences and abilities among your customers.</span></span> <span data-ttu-id="a2082-111">ゲーム コントローラーやセンサーは、必ずしも使う必要はありませんが、プレーヤーのエクスペリエンスを高めるために使用を強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a2082-111">Although game controller and sensor usage is optional, we strongly recommend it to enhance the player experience.</span></span> <span data-ttu-id="a2082-112">ゲーム コントローラーとセンサー API は、これらの入力デバイスと容易に連携できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="a2082-112">We designed the game controller and sensor APIs to help you more easily integrate these input devices.</span></span>

-   <span data-ttu-id="a2082-113">タッチを初期化するには、ポインターがアクティブ化されたとき、離されたとき、移動されたときなどのウィンドウ イベントを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2082-113">To initialize touch, you must register for window events such as when the pointer is activated, released, and moved.</span></span> <span data-ttu-id="a2082-114">加速度計を初期化するには、アプリケーションの初期化時に [Windows::Devices::Sensors::Accelerometer](https://msdn.microsoft.com/library/windows/apps/br225687) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="a2082-114">To initialize the accelerometer, create a [Windows::Devices::Sensors::Accelerometer](https://msdn.microsoft.com/library/windows/apps/br225687) object when you initialize the application.</span></span> <span data-ttu-id="a2082-115">Xbox コントローラーは初期化を必要としません。</span><span class="sxs-lookup"><span data-stu-id="a2082-115">The Xbox controller doesn't require initialization.</span></span>

-   <span data-ttu-id="a2082-116">1 プレーヤーのゲームでは、接続されているすべての Xbox コントローラーからの入力を結合します。</span><span class="sxs-lookup"><span data-stu-id="a2082-116">For single-player games, consider whether to combine input from all possible Xbox controllers.</span></span> <span data-ttu-id="a2082-117">このようにすることで、入力とその発生元となったコントローラーの関係をトラッキングする手間が省けます。</span><span class="sxs-lookup"><span data-stu-id="a2082-117">This way, you don’t have to track what input comes from which controller.</span></span> <span data-ttu-id="a2082-118">または、このサンプルで行っているように、最後に追加されたコントローラーからの入力のみを追跡します。</span><span class="sxs-lookup"><span data-stu-id="a2082-118">Or, simply track input only from the most recently added controller, as we do in this sample.</span></span>

-   <span data-ttu-id="a2082-119">入力デバイスを処理する前に、Windows イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="a2082-119">Process Windows events before you process input devices.</span></span>

-   <span data-ttu-id="a2082-120">Xbox コントローラーと加速度計では、ポーリングがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="a2082-120">The Xbox controller and the accelerometer support polling.</span></span> <span data-ttu-id="a2082-121">つまり、必要に応じてデータをポーリングできます。</span><span class="sxs-lookup"><span data-stu-id="a2082-121">That is, you can poll for data when you need it.</span></span> <span data-ttu-id="a2082-122">タッチの場合は、入力処理コードで利用できるデータ構造にタッチ イベントを記録します。</span><span class="sxs-lookup"><span data-stu-id="a2082-122">For touch, record touch events in data structures that are available to your input processing code.</span></span>

-   <span data-ttu-id="a2082-123">入力値を共通形式に正規化します。</span><span class="sxs-lookup"><span data-stu-id="a2082-123">Consider whether to normalize input values to a common format.</span></span> <span data-ttu-id="a2082-124">ゲームの他のコンポーネント (物理シミュレーションなど) が入力を解釈する方法を簡略化でき、さまざまな画面解像度で動作するゲームが作成しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="a2082-124">Doing so can simplify how input is interpreted by other components of your game, such as physics simulation, and can make it easier to write games that work on different screen resolutions.</span></span>

## <a name="input-devices-supported-by-marble-maze"></a><span data-ttu-id="a2082-125">Marble Maze でサポートされる入力デバイス</span><span class="sxs-lookup"><span data-stu-id="a2082-125">Input devices supported by Marble Maze</span></span>


<span data-ttu-id="a2082-126">Marble Maze は、メニュー項目の選択に関して Xbox コントローラー、マウス、タッチをサポートし、ゲーム プレイの制御に関して Xbox コントローラー、マウス、タッチ、加速度計をサポートします。</span><span class="sxs-lookup"><span data-stu-id="a2082-126">Marble Maze supports the Xbox controller, mouse, and touch to select menu items, and the Xbox controller, mouse, touch, and the accelerometer to control game play.</span></span> <span data-ttu-id="a2082-127">Marble Maze は、[Windows::Gaming::Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) API を使ってコントローラーの入力をポーリングします。</span><span class="sxs-lookup"><span data-stu-id="a2082-127">Marble Maze uses the [Windows::Gaming::Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) APIs to poll the controller for input.</span></span> <span data-ttu-id="a2082-128">アプリケーションは、タッチ デバイスを通じて指先での入力をトラッキングし、応答することができます。</span><span class="sxs-lookup"><span data-stu-id="a2082-128">Touch enables applications to track and respond to fingertip input.</span></span> <span data-ttu-id="a2082-129">加速度計は、X、Y、Z 軸方向に加えられた力を測定するセンサーです。</span><span class="sxs-lookup"><span data-stu-id="a2082-129">An accelerometer is a sensor that measures the force that is applied along the X, Y, and Z axes.</span></span> <span data-ttu-id="a2082-130">Windows ランタイムを使うと、Windows ランタイムのイベント処理機構を通じてタッチ イベントを受け取るだけでなく、加速度計デバイスの現在の状態をポーリングすることもできます。</span><span class="sxs-lookup"><span data-stu-id="a2082-130">By using the Windows Runtime, you can poll the current state of the accelerometer device, as well as receive touch events through the Windows Runtime event-handling mechanism.</span></span>

> [!NOTE]
> <span data-ttu-id="a2082-131">このドキュメントでは、タッチとマウスの両方の入力をタッチと呼び、ポインター イベントを使うすべてのデバイスをポインターと呼びます。</span><span class="sxs-lookup"><span data-stu-id="a2082-131">This document uses touch to refer to both touch and mouse input and pointer to refer to any device that uses pointer events.</span></span> <span data-ttu-id="a2082-132">タッチとマウスは標準のポインター イベントを利用するため、どちらのデバイスでもメニュー項目の選択とゲーム プレイの制御を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="a2082-132">Because touch and the mouse use standard pointer events, you can use either device to select menu items and control game play.</span></span>

 

> [!NOTE]
> <span data-ttu-id="a2082-133">デバイスを回転させて大理石を転がす際、方向が変わるのを防ぐために、パッケージ マニフェストは、ゲームでサポートされる回転として **Landscape** (横) のみを設定します。</span><span class="sxs-lookup"><span data-stu-id="a2082-133">The package manifest sets **Landscape** as the only supported rotation for the game to prevent the orientation from changing when you rotate the device to roll the marble.</span></span> <span data-ttu-id="a2082-134">パッケージ マニフェストを表示するには、Visual Studio の**ソリューション エクスプローラー**で、**Package.appxmanifest** を開きます。</span><span class="sxs-lookup"><span data-stu-id="a2082-134">To view the package manifest, open **Package.appxmanifest** in the **Solution Explorer** in Visual Studio.</span></span>

 

## <a name="initializing-input-devices"></a><span data-ttu-id="a2082-135">入力デバイスの初期化</span><span class="sxs-lookup"><span data-stu-id="a2082-135">Initializing input devices</span></span>


<span data-ttu-id="a2082-136">Xbox コントローラーは初期化を必要としません。</span><span class="sxs-lookup"><span data-stu-id="a2082-136">The Xbox controller does not require initialization.</span></span> <span data-ttu-id="a2082-137">タッチを初期化するには、ポインターがアクティブになったとき (たとえばプレイヤーがマウス ボタンを押すか画面に触れたとき)、離されたとき、移動されたときなどのウィンドウ イベントを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2082-137">To initialize touch, you must register for windowing events such as when the pointer is activated (for example, the player presses the mouse button or touches the screen), released, and moved.</span></span> <span data-ttu-id="a2082-138">加速度計を初期化するには、アプリケーションの初期化時に [Windows::Devices::Sensors::Accelerometer](https://msdn.microsoft.com/library/windows/apps/br225687) オブジェクトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2082-138">To initialize the accelerometer, you have to create a [Windows::Devices::Sensors::Accelerometer](https://msdn.microsoft.com/library/windows/apps/br225687) object when you initialize the application.</span></span>

<span data-ttu-id="a2082-139">次の例は、**App::SetWindow** メソッドが [Windows::UI::Core::CoreWindow::PointerPressed](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerPressed)、[Windows::UI::Core::CoreWindow::PointerReleased](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerReleased)、[Windows::UI::Core::CoreWindow::PointerMoved](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerMoved) の各ポインター イベントを登録する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a2082-139">The following example shows how the **App::SetWindow** method registers for the [Windows::UI::Core::CoreWindow::PointerPressed](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerPressed), [Windows::UI::Core::CoreWindow::PointerReleased](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerReleased), and [Windows::UI::Core::CoreWindow::PointerMoved](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerMoved) pointer events.</span></span> <span data-ttu-id="a2082-140">これらのイベントは、アプリケーションの初期化中、ゲーム ループの前に登録されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-140">These events are registered during application initialization and before the game loop.</span></span>

<span data-ttu-id="a2082-141">これらのイベントは、イベント ハンドラーを呼び出す別のスレッドで処理されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-141">These events are handled in a separate thread that invokes the event handlers.</span></span>

<span data-ttu-id="a2082-142">アプリケーションの初期化方法について詳しくは、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2082-142">For more information about how the application is initialized, see [Marble Maze application structure](marble-maze-application-structure.md).</span></span>

```cpp
window->PointerPressed += ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(
    this, 
    &App::OnPointerPressed);

window->PointerReleased += ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(
    this, 
    &App::OnPointerReleased);

window->PointerMoved += ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(
    this, 
    &App::OnPointerMoved);
```

<span data-ttu-id="a2082-143">また、**MarbleMazeMain** クラスはタッチ イベントを保持するための **std::map** オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="a2082-143">The **MarbleMazeMain** class also creates a **std::map** object to hold touch events.</span></span> <span data-ttu-id="a2082-144">この map オブジェクトのキーは、入力ポインターを一意に識別する値です。</span><span class="sxs-lookup"><span data-stu-id="a2082-144">The key for this map object is a value that uniquely identifies the input pointer.</span></span> <span data-ttu-id="a2082-145">それぞれのキーは、各タッチ ポイントと画面の中央の間の距離にマップされます。</span><span class="sxs-lookup"><span data-stu-id="a2082-145">Each key maps to the distance between every touch point and the center of the screen.</span></span> <span data-ttu-id="a2082-146">後で迷路の傾きの量を計算するときに、これらの値が使われます。</span><span class="sxs-lookup"><span data-stu-id="a2082-146">Marble Maze later uses these values to calculate the amount by which the maze is tilted.</span></span>

```cpp
typedef std::map<int, XMFLOAT2> TouchMap;
TouchMap        m_touches;
```

<span data-ttu-id="a2082-147">**MarbleMazeMain** クラスは [Accelerometer](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer) オブジェクトを保持します。</span><span class="sxs-lookup"><span data-stu-id="a2082-147">The **MarbleMazeMain** class also holds an [Accelerometer](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer) object.</span></span>

```cpp
Windows::Devices::Sensors::Accelerometer^           m_accelerometer;
```

<span data-ttu-id="a2082-148">**Accelerometer** オブジェクトは、次の例に示すように **MarbleMazeMain** のコンストラクターで初期化されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-148">The **Accelerometer** object is initialized in the **MarbleMazeMain** constructor, as shown in the following example.</span></span> <span data-ttu-id="a2082-149">[Windows::Devices::Sensors::Accelerometer::GetDefault](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer.GetDefault) メソッドは既定の加速度計のインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="a2082-149">The [Windows::Devices::Sensors::Accelerometer::GetDefault](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer.GetDefault) method returns an instance of the default accelerometer.</span></span> <span data-ttu-id="a2082-150">既定の加速度計がない場合、**Accelerometer::GetDefault** は **nullptr** を返します。</span><span class="sxs-lookup"><span data-stu-id="a2082-150">If there is no default accelerometer, **Accelerometer::GetDefault** returns **nullptr**.</span></span>

```cpp
// Returns accelerometer ref if there is one; nullptr otherwise.
m_accelerometer = Windows::Devices::Sensors::Accelerometer::GetDefault();
```

##  <a name="navigating-the-menus"></a><span data-ttu-id="a2082-151">メニューの操作</span><span class="sxs-lookup"><span data-stu-id="a2082-151">Navigating the menus</span></span>

<span data-ttu-id="a2082-152">メニューの操作には、次のようにマウス、タッチ、Xbox コントローラーを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="a2082-152">You can use the mouse, touch, or the Xbox controller to navigate the menus, as follows:</span></span>

-   <span data-ttu-id="a2082-153">アクティブなメニュー項目を変更するには、方向パッドを使います。</span><span class="sxs-lookup"><span data-stu-id="a2082-153">Use the directional pad to change the active menu item.</span></span>
-   <span data-ttu-id="a2082-154">メニュー項目を選択したり現在のメニュー (ハイスコア表など) を閉じたりするには、タッチ、A ボタン、メニュー ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="a2082-154">Use touch, the A button, or the Menu button to pick a menu item or close the current menu, such as the high-score table.</span></span>
-   <span data-ttu-id="a2082-155">ゲームを一時停止または再開するには、メニュー ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="a2082-155">Use the Menu button to pause or resume the game.</span></span>
-   <span data-ttu-id="a2082-156">操作を選択するには、マウスでそのメニュー項目をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a2082-156">Click on a menu item with the mouse to choose that action.</span></span>

###  <a name="tracking-xbox-controller-input"></a><span data-ttu-id="a2082-157">Xbox コントローラーの入力のトラッキング</span><span class="sxs-lookup"><span data-stu-id="a2082-157">Tracking Xbox controller input</span></span>

<span data-ttu-id="a2082-158">デバイスに現在接続されているゲームパッドを追跡するために、**MarbleMazeMain** ではメンバー変数 **m_myGamepads** を定義します。これは、[Windows::Gaming::Input::Gamepad](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad) オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="a2082-158">To keep track of the gamepads currently connected to the device, **MarbleMazeMain** defines a member variable, **m_myGamepads**, which is a collection of [Windows::Gaming::Input::Gamepad](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad) objects.</span></span> <span data-ttu-id="a2082-159">これは、次のようなコンストラクターで初期化されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-159">This is initialized in the constructor like so:</span></span>

```cpp
m_myGamepads = ref new Vector<Gamepad^>();

for (auto gamepad : Gamepad::Gamepads)
{
    m_myGamepads->Append(gamepad);
}
```

<span data-ttu-id="a2082-160">さらに、**MarbleMazeMain** コンストラクターはゲームパッドが追加または削除されたときのイベントを登録します。</span><span class="sxs-lookup"><span data-stu-id="a2082-160">Additionally, the **MarbleMazeMain** constructor registers events for when gamepads are added or removed:</span></span>

```cpp
Gamepad::GamepadAdded += 
    ref new EventHandler<Gamepad^>([=](Platform::Object^, Gamepad^ args)
{
    m_myGamepads->Append(args);
    m_currentGamepadNeedsRefresh = true;
});

Gamepad::GamepadRemoved += 
    ref new EventHandler<Gamepad ^>([=](Platform::Object^, Gamepad^ args)
{
    unsigned int indexRemoved;

    if (m_myGamepads->IndexOf(args, &indexRemoved))
    {
        m_myGamepads->RemoveAt(indexRemoved);
        m_currentGamepadNeedsRefresh = true;
    }
});
```

<span data-ttu-id="a2082-161">ゲームパッドが追加されると、**m_myGamepads** に追加されます。ゲームパッドが削除されると、そのゲームパッドが **m_myGamepads** に存在するかどうかを確認し、存在する場合は削除します。</span><span class="sxs-lookup"><span data-stu-id="a2082-161">When a gamepad is added, it is added to **m_myGamepads**; when a gamepad is removed, we check if the gamepad is in **m_myGamepads**, and if it is, we remove it.</span></span> <span data-ttu-id="a2082-162">どちらの場合も、**m_currentGamepadNeedsRefresh** を **true** に設定し、**m_gamepad** の再割り当てが必要なことを示します。</span><span class="sxs-lookup"><span data-stu-id="a2082-162">In both cases, we set **m_currentGamepadNeedsRefresh** to **true**, indicating that we need to reassign **m_gamepad**.</span></span>

<span data-ttu-id="a2082-163">最後に、ゲームパッドを **m_gamepad** に割り当てて、**m_currentGamepadNeedsRefresh** を **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a2082-163">Finally, we assign a gamepad to **m_gamepad** and set **m_currentGamepadNeedsRefresh** to **false**:</span></span>

```cpp
m_gamepad = GetLastGamepad();
m_currentGamepadNeedsRefresh = false;
```

<span data-ttu-id="a2082-164">**Update** メソッドで、**m_gamepad** を再割り当てする必要があるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="a2082-164">In the **Update** method, we check if **m_gamepad** needs to be reassigned:</span></span>

```cpp
if (m_currentGamepadNeedsRefresh)
{
    auto mostRecentGamepad = GetLastGamepad();

    if (m_gamepad != mostRecentGamepad)
    {
        m_gamepad = mostRecentGamepad;
    }

    m_currentGamepadNeedsRefresh = false;
}
```

<span data-ttu-id="a2082-165">**m_gamepad** を再割り当てする必要がある場合は、次のように定義された **GetLastGamepad** を使用して、最後に追加されたゲームパッドをそれに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="a2082-165">If **m_gamepad** does need to be reassigned, we assign to it the most recently added gamepad, using **GetLastGamepad**, which is defined like so:</span></span>

```cpp
Gamepad^ MarbleMaze::MarbleMazeMain::GetLastGamepad()
{
    Gamepad^ gamepad = nullptr;

    if (m_myGamepads->Size > 0)
    {
        gamepad = m_myGamepads->GetAt(m_myGamepads->Size - 1);
    }

    return gamepad;
}
```

<span data-ttu-id="a2082-166">このメソッドは、単純に最後のゲームパッドを **m_myGamepads** に返します。</span><span class="sxs-lookup"><span data-stu-id="a2082-166">This method simply returns the last gamepad in **m_myGamepads**.</span></span>

<span data-ttu-id="a2082-167">1 台の Windows 10 デバイスには最大 4 つの Xbox コントローラーを接続できます。</span><span class="sxs-lookup"><span data-stu-id="a2082-167">You can connect up to four Xbox controllers to a Windows 10 device.</span></span> <span data-ttu-id="a2082-168">どのコントローラーがアクティブであるかを特定にすることを回避するために、単に最後に追加されたゲームパッドのみを追跡しています。</span><span class="sxs-lookup"><span data-stu-id="a2082-168">To avoid having to figure out which controller is the active one, we simply only track the most recently added gamepad.</span></span> <span data-ttu-id="a2082-169">複数プレイヤーをサポートするゲームでは、各プレイヤーの入力を個別にトラッキングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2082-169">If your game supports more than one player, you have to track input for each player separately.</span></span>

<span data-ttu-id="a2082-170">**MarbleMazeMain::Update** メソッドは、ゲームパッドの入力をポーリングします。</span><span class="sxs-lookup"><span data-stu-id="a2082-170">The **MarbleMazeMain::Update** method polls the gamepad for input:</span></span>

```cpp
if (m_gamepad != nullptr)
{
    m_oldReading = m_newReading;
    m_newReading = m_gamepad->GetCurrentReading();
}
```

<span data-ttu-id="a2082-171">最後のフレームで取得した入力の読み取り値は **m_oldReading** を使用して追跡し、最新の入力の読み取り値は **m_newReading** を使用して追跡します。最新の入力は [gamepad::getcurrentreading](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.GetCurrentReading) を呼び出すことによって取得します。</span><span class="sxs-lookup"><span data-stu-id="a2082-171">We keep track of the input reading we got in the last frame with **m_oldReading**, and the latest input reading with **m_newReading**, which we get by calling [Gamepad::GetCurrentReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.GetCurrentReading).</span></span> <span data-ttu-id="a2082-172">これは [GamepadReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadreading) オブジェクトを返します。このオブジェクトには、ゲームパッドの現在の状態に関する情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a2082-172">This returns a [GamepadReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadreading) object, which contains information about the current state of the gamepad.</span></span>

<span data-ttu-id="a2082-173">ボタンがたった今押されたか、離されたかを確認するために、**MarbleMazeMain::ButtonJustPressed** と **MarbleMazeMain::ButtonJustReleased** を定義しています。これは、このフレームと最後のフレームからのボタンの読み取り値を比較します。</span><span class="sxs-lookup"><span data-stu-id="a2082-173">To check if a button was just pressed or released, we define **MarbleMazeMain::ButtonJustPressed** and **MarbleMazeMain::ButtonJustReleased**, which compare button readings from this frame and the last frame.</span></span> <span data-ttu-id="a2082-174">これによって、ボタンが最初に押されたか、離されたときにのみアクションを実行し、ボタンが押されたままになっているときは実行しないようにできます。</span><span class="sxs-lookup"><span data-stu-id="a2082-174">This way, we can perform an action only at the time when a button is initially pressed or released, and not when it's held:</span></span>

```cpp
bool MarbleMaze::MarbleMazeMain::ButtonJustPressed(GamepadButtons selection)
{
    bool newSelectionPressed = (selection == (m_newReading.Buttons & selection));
    bool oldSelectionPressed = (selection == (m_oldReading.Buttons & selection));
    return newSelectionPressed && !oldSelectionPressed;
}

bool MarbleMaze::MarbleMazeMain::ButtonJustReleased(GamepadButtons selection)
{
    bool newSelectionReleased = 
        (GamepadButtons::None == (m_newReading.Buttons & selection));

    bool oldSelectionReleased = 
        (GamepadButtons::None == (m_oldReading.Buttons & selection));

    return newSelectionReleased && !oldSelectionReleased;
}
```

<span data-ttu-id="a2082-175">[GamepadButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadbuttons) の読み取り値は、ビット単位の演算を使用して比較されます。ボタンが押されたかどうかは、*ビット演算 AND* (&) を使用して確認します。</span><span class="sxs-lookup"><span data-stu-id="a2082-175">[GamepadButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadbuttons) readings are compared using bitwise operations&mdash;we check if a button is pressed using *bitwise and* (&).</span></span> <span data-ttu-id="a2082-176">前回の読み取り値と新しい読み取り値を比較することによって、ボタンがたった今押されたか、離されたかを特定します。</span><span class="sxs-lookup"><span data-stu-id="a2082-176">We determine whether a button was just pressed or released by comparing the old reading and the new reading.</span></span>

<span data-ttu-id="a2082-177">上記の方法を使用して、特定のボタンが押されたかどうかを確認し、必要な対応するアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="a2082-177">Using the above methods, we check if certain buttons have been pressed and perform any corresponding actions that must happen.</span></span> <span data-ttu-id="a2082-178">たとえば、メニュー ボタン (**GamepadButtons::Menu**) が押されたときは、ゲームの状態がアクティブから一時停止、または一時停止からアクティブに変わります。</span><span class="sxs-lookup"><span data-stu-id="a2082-178">For example, when the Menu button (**GamepadButtons::Menu**) is pressed, the game state changes from active to paused or paused to active.</span></span>

```cpp
if (ButtonJustPressed(GamepadButtons::Menu) || m_pauseKeyPressed)
{
    m_pauseKeyPressed = false;

    if (m_gameState == GameState::InGameActive)
    {
        SetGameState(GameState::InGamePaused);
    }  
    else if (m_gameState == GameState::InGamePaused)
    {
        SetGameState(GameState::InGameActive);
    }
}
```

<span data-ttu-id="a2082-179">また、プレイヤーがビュー ボタンを押したかどうかを確認して、ビュー ボタンが押された場合は、ゲームを再起動したり、ハイ スコア表をクリアしたりします。</span><span class="sxs-lookup"><span data-stu-id="a2082-179">We also check if the player presses the View button, in which case we restart the game or clear the high score table:</span></span>

```cpp
if (ButtonJustPressed(GamepadButtons::View) || m_homeKeyPressed)
{
    m_homeKeyPressed = false;

    if (m_gameState == GameState::InGameActive ||
        m_gameState == GameState::InGamePaused ||
        m_gameState == GameState::PreGameCountdown)
    {
        SetGameState(GameState::MainMenu);
        m_inGameStopwatchTimer.SetVisible(false);
        m_preGameCountdownTimer.SetVisible(false);
    }
    else if (m_gameState == GameState::HighScoreDisplay)
    {
        m_highScoreTable.Reset();
    }
}
```

<span data-ttu-id="a2082-180">メイン メニューがアクティブである場合、方向パッドが上方向または下方向へ押されるとアクティブなメニュー項目が変わります。</span><span class="sxs-lookup"><span data-stu-id="a2082-180">If the main menu is active, the active menu item changes when the directional pad is pressed up or down.</span></span> <span data-ttu-id="a2082-181">ユーザーが現在の選択項目を選択すると、該当する UI 要素が選択中としてマークされます。</span><span class="sxs-lookup"><span data-stu-id="a2082-181">If the user chooses the current selection, the appropriate UI element is marked as being chosen.</span></span>

```cpp
// Handle menu navigation.
bool chooseSelection = 
    (ButtonJustPressed(GamepadButtons::A) 
    || ButtonJustPressed(GamepadButtons::Menu));

bool moveUp = ButtonJustPressed(GamepadButtons::DPadUp);
bool moveDown = ButtonJustPressed(GamepadButtons::DPadDown);

switch (m_gameState)
{
case GameState::MainMenu:
    if (chooseSelection)
    {
        m_audio.PlaySoundEffect(MenuSelectedEvent);
        if (m_startGameButton.GetSelected())
        {
            m_startGameButton.SetPressed(true);
        }
        if (m_highScoreButton.GetSelected())
        {
            m_highScoreButton.SetPressed(true);
        }
    }
    if (moveUp || moveDown)
    {
        m_startGameButton.SetSelected(!m_startGameButton.GetSelected());
        m_highScoreButton.SetSelected(!m_startGameButton.GetSelected());
        m_audio.PlaySoundEffect(MenuChangeEvent);
    }
    break;

case GameState::HighScoreDisplay:
    if (chooseSelection || anyPoints)
    {
        SetGameState(GameState::MainMenu);
    }
    break;

case GameState::PostGameResults:
    if (chooseSelection || anyPoints)
    {
        SetGameState(GameState::HighScoreDisplay);
    }
    break;

case GameState::InGamePaused:
    if (m_pausedText.IsPressed())
    {
        m_pausedText.SetPressed(false);
        SetGameState(GameState::InGameActive);
    }
    break;
}
```

### <a name="tracking-touch-and-mouse-input"></a><span data-ttu-id="a2082-182">タッチとマウスによる入力のトラッキング</span><span class="sxs-lookup"><span data-stu-id="a2082-182">Tracking touch and mouse input</span></span>

<span data-ttu-id="a2082-183">タッチとマウスによる入力では、メニュー項目は、ユーザーがその項目をタッチまたはクリックしたときに選択されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-183">For touch and mouse input, a menu item is chosen when the user touches or clicks it.</span></span> <span data-ttu-id="a2082-184">次の例は、**MarbleMazeMain::Update** メソッドがポインターの入力を処理してメニュー項目を選択する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a2082-184">The following example shows how the **MarbleMazeMain::Update** method processes pointer input to select menu items.</span></span> <span data-ttu-id="a2082-185">**m\_pointQueue** メンバー変数は、ユーザーが画面上でタッチまたはクリックした場所をトラッキングします。</span><span class="sxs-lookup"><span data-stu-id="a2082-185">The **m\_pointQueue** member variable tracks the locations where the user touched or clicked on the screen.</span></span> <span data-ttu-id="a2082-186">Marble Maze のポインター入力の収集方法については、このドキュメントの「[ポインターの入力の処理](#processing-pointer-input)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="a2082-186">The way in which Marble Maze collects pointer input is described in greater detail later in this document in the section [Processing pointer input](#processing-pointer-input).</span></span>

```cpp
// Check whether the user chose a button from the UI. 
bool anyPoints = !m_pointQueue.empty();
while (!m_pointQueue.empty())
{
    UserInterface::GetInstance().HitTest(m_pointQueue.front());
    m_pointQueue.pop();
}
```

<span data-ttu-id="a2082-187">**UserInterface::HitTest** メソッドは、指定された点が UI 要素の境界内にあるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="a2082-187">The **UserInterface::HitTest** method determines whether the provided point is located in the bounds of any UI element.</span></span> <span data-ttu-id="a2082-188">このテストに合格した UI 要素はすべて、タッチされているとマークされます。</span><span class="sxs-lookup"><span data-stu-id="a2082-188">Any UI elements that pass this test are marked as being touched.</span></span> <span data-ttu-id="a2082-189">このメソッドは、指定された点が各 UI 要素の境界内にあるかどうかを判断するために **PointInRect** ヘルパー関数を利用します。</span><span class="sxs-lookup"><span data-stu-id="a2082-189">This method uses the **PointInRect** helper function to determine whether the provided point is located in the bounds of each UI element.</span></span>

```cpp
void UserInterface::HitTest(D2D1_POINT_2F point)
{
    for (auto iter = m_elements.begin(); iter != m_elements.end(); ++iter)
    {
        if (!(*iter)->IsVisible())
            continue;

        TextButton* textButton = dynamic_cast<TextButton*>(*iter);
        if (textButton != nullptr)
        {
            D2D1_RECT_F bounds = (*iter)->GetBounds();
            textButton->SetPressed(PointInRect(point, bounds));
        }
    }
}
```

### <a name="updating-the-game-state"></a><span data-ttu-id="a2082-190">ゲームの状態の更新</span><span class="sxs-lookup"><span data-stu-id="a2082-190">Updating the game state</span></span>

<span data-ttu-id="a2082-191">コントローラーとタッチの入力を処理した後、**MarbleMazeMain::Update** メソッドは、いずれかのボタンが押された場合にゲームの状態を更新します。</span><span class="sxs-lookup"><span data-stu-id="a2082-191">After the **MarbleMazeMain::Update** method processes controller and touch input, it updates the game state if any button was pressed.</span></span>

```cpp
// Update the game state if the user chose a menu option. 
if (m_startGameButton.IsPressed())
{
    SetGameState(GameState::PreGameCountdown);
    m_startGameButton.SetPressed(false);
}
if (m_highScoreButton.IsPressed())
{
    SetGameState(GameState::HighScoreDisplay);
    m_highScoreButton.SetPressed(false);
}
```

##  <a name="controlling-game-play"></a><span data-ttu-id="a2082-192">ゲーム プレイの制御</span><span class="sxs-lookup"><span data-stu-id="a2082-192">Controlling game play</span></span>


<span data-ttu-id="a2082-193">ゲーム ループと **MarbleMazeMain::Update** メソッドは、連携してゲーム オブジェクトの状態を更新します。</span><span class="sxs-lookup"><span data-stu-id="a2082-193">The game loop and the **MarbleMazeMain::Update** method work together to update the state of game objects.</span></span> <span data-ttu-id="a2082-194">多様なデバイスからの入力を受け付けるゲームを開発する場合、すべてのデバイスからの入力を一連の変数に蓄積することで保守しやすいコードを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="a2082-194">If your game accepts input from multiple devices, you can accumulate the input from all devices into one set of variables so that you can write code that's easier to maintain.</span></span> <span data-ttu-id="a2082-195">**MarbleMazeMain::Update** メソッドは、すべてのデバイスからの動作を蓄積する一連の変数を定義します。</span><span class="sxs-lookup"><span data-stu-id="a2082-195">The **MarbleMazeMain::Update** method defines one set of variables that accumulates movement from all devices.</span></span>

```cpp
float combinedTiltX = 0.0f;
float combinedTiltY = 0.0f;
```

<span data-ttu-id="a2082-196">入力機構は入力デバイスによって異なります。</span><span class="sxs-lookup"><span data-stu-id="a2082-196">The input mechanism can vary from one input device to another.</span></span> <span data-ttu-id="a2082-197">たとえば、ポインターの入力は Windows ランタイムのイベント処理モデルを使って処理されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-197">For example, pointer input is handled by using the Windows Runtime event-handling model.</span></span> <span data-ttu-id="a2082-198">これに対して、Xbox コントローラーからの入力データは必要なときに自分でポーリングします。</span><span class="sxs-lookup"><span data-stu-id="a2082-198">Conversely, you poll for input data from the Xbox controller when you need it.</span></span> <span data-ttu-id="a2082-199">デバイスごとに定められた入力機構に常に従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a2082-199">We recommend that you always follow the input mechanism that is prescribed for a given device.</span></span> <span data-ttu-id="a2082-200">このセクションでは、Marble Maze が各デバイスからの入力を読み取り、結合された入力値を更新し、結合された入力値を使ってゲームの状態を更新する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a2082-200">This section describes how Marble Maze reads input from each device, how it updates the combined input values, and how it uses the combined input values to update the state of the game.</span></span>

###  <a name="processing-pointer-input"></a><span data-ttu-id="a2082-201">ポインターの入力の処理</span><span class="sxs-lookup"><span data-stu-id="a2082-201">Processing pointer input</span></span>

<span data-ttu-id="a2082-202">ポインターの入力を処理するときは、[Windows::UI::Core::CoreDispatcher::ProcessEvents](https://docs.microsoft.com/uwp/api/windows.ui.core.coredispatcher.processevents) メソッドを呼び出してウィンドウ イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="a2082-202">When you work with pointer input, call the [Windows::UI::Core::CoreDispatcher::ProcessEvents](https://docs.microsoft.com/uwp/api/windows.ui.core.coredispatcher.processevents) method to process window events.</span></span> <span data-ttu-id="a2082-203">このメソッドは、ゲーム ループ内でシーンの更新またはレンダリングの前に呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a2082-203">Call this method in your game loop before you update or render the scene.</span></span> <span data-ttu-id="a2082-204">Marble Maze では、**App::Run** メソッドでこれを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a2082-204">Marble Maze calls this in the **App::Run** method:</span></span> 

```cpp
while (!m_windowClosed)
{
    if (m_windowVisible)
    {
        CoreWindow::GetForCurrentThread()->
            Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

        m_main->Update();

        if (m_main->Render())
        {
            m_deviceResources->Present();
        }
    }
    else
    {
        CoreWindow::GetForCurrentThread()->
            Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
    }
}
```

<span data-ttu-id="a2082-205">ウィンドウが表示されている場合、**CoreProcessEventsOption::ProcessAllIfPresent** を **ProcessEvents** に渡してキュー内のすべてのイベントを処理し、直ちに制御を戻します。それ以外の場合は、**CoreProcessEventsOption::ProcessOneAndAllPending** を渡してキュー内のすべてのイベントを処理し、次の新しいイベントを待機します。</span><span class="sxs-lookup"><span data-stu-id="a2082-205">If the window is visible, we pass **CoreProcessEventsOption::ProcessAllIfPresent** to **ProcessEvents** to process all queued events and return immediately; otherwise, we pass **CoreProcessEventsOption::ProcessOneAndAllPending** to process all queued events and wait for the next new event.</span></span> <span data-ttu-id="a2082-206">イベントの処理後に Marble Maze はレンダリングを行い、次のフレームを表示します。</span><span class="sxs-lookup"><span data-stu-id="a2082-206">After events are processed, Marble Maze renders and presents the next frame.</span></span>

<span data-ttu-id="a2082-207">Windows ランタイムは、イベントが発生するたびに、登録されているハンドラーを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a2082-207">The Windows Runtime calls the registered handler for each event that occurred.</span></span> <span data-ttu-id="a2082-208">**App::SetWindow** メソッドはイベントを登録し、ポインターの情報を **MarbleMazeMain** クラスに転送します。</span><span class="sxs-lookup"><span data-stu-id="a2082-208">The **App::SetWindow** method registers for events and forwards pointer information to the **MarbleMazeMain** class.</span></span>

```cpp
void App::OnPointerPressed(
    Windows::UI::Core::CoreWindow^ sender, 
    Windows::UI::Core::PointerEventArgs^ args)
{
    m_main->AddTouch(args->CurrentPoint->PointerId, args->CurrentPoint->Position);
}

void App::OnPointerReleased(
    Windows::UI::Core::CoreWindow^ sender, 
    Windows::UI::Core::PointerEventArgs^ args)
{
    m_main->RemoveTouch(args->CurrentPoint->PointerId);
}

void App::OnPointerMoved(
    Windows::UI::Core::CoreWindow^ sender, 
    Windows::UI::Core::PointerEventArgs^ args)
{
    m_main->UpdateTouch(args->CurrentPoint->PointerId, args->CurrentPoint->Position);
}
```

<span data-ttu-id="a2082-209">**MarbleMazeMain** クラスは、タッチ イベントを保持する map オブジェクトを更新することによってポインター イベントに対応します。</span><span class="sxs-lookup"><span data-stu-id="a2082-209">The **MarbleMazeMain** class reacts to pointer events by updating the map object that holds touch events.</span></span> <span data-ttu-id="a2082-210">**MarbleMazeMain::AddTouch** メソッドは、ポインターが最初に押されたとき (たとえばタッチ対応デバイス上でユーザーが最初に画面に触れたとき) に呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-210">The **MarbleMazeMain::AddTouch** method is called when the pointer is first pressed, for example, when the user initially touches the screen on a touch-enabled device.</span></span> <span data-ttu-id="a2082-211">**MarbleMazeMain::UpdateTouch** メソッドは、ポインターの位置が移動したときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-211">The **MarbleMazeMain::UpdateTouch** method is called when the pointer position moves.</span></span> <span data-ttu-id="a2082-212">**MarbleMazeMain::RemoveTouch** メソッドは、ポインターが離されたとき (たとえばユーザーが画面に触れるのを止めたとき) に呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="a2082-212">The **MarbleMazeMain::RemoveTouch** method is called when the pointer is released, for example, when the user stops touching the screen.</span></span>

```cpp
void MarbleMazeMain::AddTouch(int id, Windows::Foundation::Point point)
{
    m_touches[id] = PointToTouch(point, m_deviceResources->GetLogicalSize());

    m_pointQueue.push(D2D1::Point2F(point.X, point.Y));
}

void MarbleMazeMain::UpdateTouch(int id, Windows::Foundation::Point point)
{
    if (m_touches.find(id) != m_touches.end())
        m_touches[id] = PointToTouch(point, m_deviceResources->GetLogicalSize());
}

void MarbleMazeMain::RemoveTouch(int id)
{
    m_touches.erase(id);
}
```

<span data-ttu-id="a2082-213">**PointToTouch** 関数は、原点が画面の中心に来るように現在のポインターの位置を変換した後、座標をスケーリングして、およそ -1.0 ～ +1.0 の範囲内になるようにします。</span><span class="sxs-lookup"><span data-stu-id="a2082-213">The **PointToTouch** function translates the current pointer position so that the origin is in the center of the screen, and then scales the coordinates so that they range approximately between -1.0 and +1.0.</span></span> <span data-ttu-id="a2082-214">これにより、入力方法の違いにかかわらず、一貫した方法で容易に迷路の傾きを計算することができます。</span><span class="sxs-lookup"><span data-stu-id="a2082-214">This makes it easier to calculate the tilt of the maze in a consistent way across different input methods.</span></span>

```cpp
inline XMFLOAT2 PointToTouch(Windows::Foundation::Point point, Windows::Foundation::Size bounds)
{
    float touchRadius = min(bounds.Width, bounds.Height);
    float dx = (point.X - (bounds.Width / 2.0f)) / touchRadius;
    float dy = ((bounds.Height / 2.0f) - point.Y) / touchRadius;

    return XMFLOAT2(dx, dy);
}
```

<span data-ttu-id="a2082-215">**MarbleMazeMain::Update** メソッドは、傾き係数を一定のスケーリング値ずつインクリメントすることにより、結合された入力値を更新します。</span><span class="sxs-lookup"><span data-stu-id="a2082-215">The **MarbleMazeMain::Update** method updates the combined input values by incrementing the tilt factor by a constant scaling value.</span></span> <span data-ttu-id="a2082-216">このスケーリング値は、いくつかの値を試して決定されました。</span><span class="sxs-lookup"><span data-stu-id="a2082-216">This scaling value was determined by experimenting with several different values.</span></span>

```cpp
// Account for touch input.
for (TouchMap::const_iterator iter = m_touches.cbegin(); 
    iter != m_touches.cend(); 
    ++iter)
{
    combinedTiltX += iter->second.x * m_touchScaleFactor;
    combinedTiltY += iter->second.y * m_touchScaleFactor;
}
```

### <a name="processing-accelerometer-input"></a><span data-ttu-id="a2082-217">加速度計の入力の処理</span><span class="sxs-lookup"><span data-stu-id="a2082-217">Processing accelerometer input</span></span>

<span data-ttu-id="a2082-218">加速度計の入力を処理するために、**MarbleMazeMain::Update** メソッドは [Windows::Devices::Sensors::Accelerometer::GetCurrentReading](https://msdn.microsoft.com/library/windows/apps/br225699) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a2082-218">To process accelerometer input, the **MarbleMazeMain::Update** method calls the [Windows::Devices::Sensors::Accelerometer::GetCurrentReading](https://msdn.microsoft.com/library/windows/apps/br225699) method.</span></span> <span data-ttu-id="a2082-219">このメソッドは、加速度計の測定値を表す [Windows::Devices::Sensors::AccelerometerReading](https://msdn.microsoft.com/library/windows/apps/br225688) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="a2082-219">This method returns a [Windows::Devices::Sensors::AccelerometerReading](https://msdn.microsoft.com/library/windows/apps/br225688) object, which represents an accelerometer reading.</span></span> <span data-ttu-id="a2082-220">**Windows::Devices::Sensors::AccelerometerReading::AccelerationX** プロパティと **Windows::Devices::Sensors::AccelerometerReading::AccelerationY** プロパティは、X 軸方向と Y 軸方向の重力加速度をそれぞれ保持します。</span><span class="sxs-lookup"><span data-stu-id="a2082-220">The **Windows::Devices::Sensors::AccelerometerReading::AccelerationX** and **Windows::Devices::Sensors::AccelerometerReading::AccelerationY** properties hold the g-force acceleration along the X and Y axes, respectively.</span></span>

<span data-ttu-id="a2082-221">次の例は、**MarbleMazeMain::Update** メソッドが加速度計をポーリングし、結合された入力値の更新を行う方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a2082-221">The following example shows how the **MarbleMazeMain::Update** method polls the accelerometer and updates the combined input values.</span></span> <span data-ttu-id="a2082-222">デバイスを傾けると、重力によって大理石が速く移動します。</span><span class="sxs-lookup"><span data-stu-id="a2082-222">As you tilt the device, gravity causes the marble to move faster.</span></span>

```cpp
// Account for sensors.
if (m_accelerometer != nullptr)
{
    Windows::Devices::Sensors::AccelerometerReading^ reading =
        m_accelerometer->GetCurrentReading();

    if (reading != nullptr)
    {
        combinedTiltX += 
            static_cast<float>(reading->AccelerationX) * m_accelerometerScaleFactor;

        combinedTiltY += 
            static_cast<float>(reading->AccelerationY) * m_accelerometerScaleFactor;
    }
}
```

<span data-ttu-id="a2082-223">ユーザーのコンピューターに加速度計が搭載されているかどうかは不確かなため、加速度計のポーリングを行う前には必ず、有効な [Accelerometer](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer) オブジェクトがあることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="a2082-223">Because you can't be sure that an accelerometer is present on the user’s computer, always ensure that you have a valid [Accelerometer](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer) object before you poll the accelerometer.</span></span>

### <a name="processing-xbox-controller-input"></a><span data-ttu-id="a2082-224">Xbox コントローラーの入力の処理</span><span class="sxs-lookup"><span data-stu-id="a2082-224">Processing Xbox controller input</span></span>

<span data-ttu-id="a2082-225">**MarbleMazeMain::Update** メソッドで、**m_newReading** を使用して、左のアナログ スティックからの入力を処理します。</span><span class="sxs-lookup"><span data-stu-id="a2082-225">In the **MarbleMazeMain::Update** method, we use **m_newReading** to process input from the left analog stick:</span></span>

```cpp
float leftStickX = static_cast<float>(m_newReading.LeftThumbstickX);
float leftStickY = static_cast<float>(m_newReading.LeftThumbstickY);

auto oppositeSquared = leftStickY * leftStickY;
auto adjacentSquared = leftStickX * leftStickX;

if ((oppositeSquared + adjacentSquared) > m_deadzoneSquared)
{
    combinedTiltX += leftStickX * m_controllerScaleFactor;
    combinedTiltY += leftStickY * m_controllerScaleFactor;
}
```

<span data-ttu-id="a2082-226">左のアナログ スティックからの入力がデッド ゾーンの範囲外であるかどうかを確認し、範囲外である場合は、それを **combinedTiltX** と **combinedTiltY** (スケール係数を乗算した値) に追加して、ステージを傾けます。</span><span class="sxs-lookup"><span data-stu-id="a2082-226">We check if the input from the left analog stick is outside of the dead zone, and if it is, we add it to **combinedTiltX** and **combinedTiltY** (multiplied by a scale factor) to tilt the stage.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a2082-227">Xbox コントローラーを使うときは、常にデッド ゾーンを考慮してください。</span><span class="sxs-lookup"><span data-stu-id="a2082-227">When you work with the Xbox controller, always account for the dead zone.</span></span> <span data-ttu-id="a2082-228">デッド ゾーンとは、ゲームパッド間の、最初の移動に対する感度の差異を指します。</span><span class="sxs-lookup"><span data-stu-id="a2082-228">The dead zone refers to the variance among gamepads in their sensitivity to initial movement.</span></span> <span data-ttu-id="a2082-229">小さな移動があったときに、あるコントローラーでは測定値が生成されないのに、別のコントローラーでは測定値が生成されることがあります。</span><span class="sxs-lookup"><span data-stu-id="a2082-229">In some controllers, a small movement may generate no reading, but in others it may generate a measurable reading.</span></span> <span data-ttu-id="a2082-230">これをゲームで考慮するために、サムスティックの最初の移動に対して、移動なしと見なすゾーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="a2082-230">To account for this in your game, create a zone of non-movement for initial thumbstick movement.</span></span> <span data-ttu-id="a2082-231">デッド ゾーンについて詳しくは、「[サムスティックの読み取り](gamepad-and-vibration.md#reading-the-thumbsticks)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2082-231">For more information about the dead zone, see [Reading the thumbsticks](gamepad-and-vibration.md#reading-the-thumbsticks).</span></span>

 

###  <a name="applying-input-to-the-game-state"></a><span data-ttu-id="a2082-232">ゲームの状態への入力の適用</span><span class="sxs-lookup"><span data-stu-id="a2082-232">Applying input to the game state</span></span>

<span data-ttu-id="a2082-233">デバイスは、さまざまな方法で入力値を報告します。</span><span class="sxs-lookup"><span data-stu-id="a2082-233">Devices report input values in different ways.</span></span> <span data-ttu-id="a2082-234">たとえば、ポインターの入力は通常、画面座標で報告されますが、コントローラーの入力の形式は、それとはまったく異なることが考えられます。</span><span class="sxs-lookup"><span data-stu-id="a2082-234">For example, pointer input might be in screen coordinates, and controller input might be in a completely different format.</span></span> <span data-ttu-id="a2082-235">複数のデバイスからの入力を一連の入力値に結合する際の課題の 1 つに、正規化 (共通形式への値の変換) があります。</span><span class="sxs-lookup"><span data-stu-id="a2082-235">One challenge with combining input from multiple devices into one set of input values is normalization, or converting values to a common format.</span></span> <span data-ttu-id="a2082-236">Marble Maze は、値を範囲 \[-1.0, 1.0\] にスケーリングすることによって正規化します。</span><span class="sxs-lookup"><span data-stu-id="a2082-236">Marble Maze normalizes values by scaling them to the range \[-1.0, 1.0\].</span></span> <span data-ttu-id="a2082-237">このセクションで既に説明した **PointToTouch** 関数は、画面座標をおよそ -1.0 ～ +1.0 の範囲内の正規化された値に変換します。</span><span class="sxs-lookup"><span data-stu-id="a2082-237">The **PointToTouch** function, which is previously described in this section, converts screen coordinates to normalized values that range approximately between -1.0 and +1.0.</span></span>

> [!TIP]
> <span data-ttu-id="a2082-238">アプリケーションで用いられる入力方法が 1 つであっても、常に入力値を正規化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a2082-238">Even if your application uses one input method, we recommend that you always normalize input values.</span></span> <span data-ttu-id="a2082-239">そうすることで、ゲームの他のコンポーネント (物理シミュレーションなど) が入力を解釈する方法を簡略化でき、さまざまな画面解像度で動作するゲームが作成しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="a2082-239">Doing so can simplify how input is interpreted by other components of your game, such as physics simulation, and makes it easier to write games that work on different screen resolutions.</span></span>

 

<span data-ttu-id="a2082-240">入力を処理した後、**MarbleMazeMain::Update** メソッドは、大理石に対する迷路の傾きの影響を表すベクターを作成します。</span><span class="sxs-lookup"><span data-stu-id="a2082-240">After the **MarbleMazeMain::Update** method processes input, it creates a vector that represents the effect of the tilt of the maze on the marble.</span></span> <span data-ttu-id="a2082-241">次の例は、Marble Maze が [XMVector3Normalize](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.geometric.xmvector3normalize) 関数を使って正規化された重力ベクターを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a2082-241">The following example shows how Marble Maze uses the [XMVector3Normalize](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.geometric.xmvector3normalize) function to create a normalized gravity vector.</span></span> <span data-ttu-id="a2082-242">**maxTilt** 変数は迷路の傾きの量を制限し、迷路が横向きに傾けられるのを防ぎます。</span><span class="sxs-lookup"><span data-stu-id="a2082-242">The **maxTilt** variable constrains the amount by which the maze tilts and prevents the maze from tilting on its side.</span></span>

```cpp
const float maxTilt = 1.0f / 8.0f;

XMVECTOR gravity = XMVectorSet(
    combinedTiltX * maxTilt, 
    combinedTiltY * maxTilt, 
    1.0f, 
    0.0f);

gravity = XMVector3Normalize(gravity);
```

<span data-ttu-id="a2082-243">シーン オブジェクトの更新を完了するために、Marble Maze は更新された重力ベクターを物理シミュレーションに渡し、前のフレームからの経過時間の物理シミュレーションを更新したうえで、大理石の位置と方向を更新します。</span><span class="sxs-lookup"><span data-stu-id="a2082-243">To complete the update of scene objects, Marble Maze passes the updated gravity vector to the physics simulation, updates the physics simulation for the time that has elapsed since the previous frame, and updates the position and orientation of the marble.</span></span> <span data-ttu-id="a2082-244">大理石が迷路から落ちた場合、**MarbleMazeMain::Update** メソッドは、最後に接触したチェックポイントまで大理石を戻し、物理シミュレーションの状態をリセットします。</span><span class="sxs-lookup"><span data-stu-id="a2082-244">If the marble has fallen through the maze, the **MarbleMazeMain::Update** method places the marble back at the last checkpoint that the marble touched and resets the state of the physics simulation.</span></span>

```cpp
XMFLOAT3A g;
XMStoreFloat3(&g, gravity);
m_physics.SetGravity(g);

if (m_gameState == GameState::InGameActive)
{
    // Only update physics when gameplay is active.
    m_physics.UpdatePhysicsSimulation(static_cast<float>(m_timer.GetElapsedSeconds()));

    // ...Code omitted for simplicity...

}

// ...Code omitted for simplicity...

// Check whether the marble fell off of the maze. 
const float fadeOutDepth = 0.0f;
const float resetDepth = 80.0f;
if (marblePosition.z >= fadeOutDepth)
{
    m_targetLightStrength = 0.0f;
}
if (marblePosition.z >= resetDepth)
{
    // Reset marble.
    memcpy(&marblePosition, &m_checkpoints[m_currentCheckpoint], sizeof(XMFLOAT3));
    oldMarblePosition = marblePosition;
    m_physics.SetPosition((const XMFLOAT3&)marblePosition);
    m_physics.SetVelocity(XMFLOAT3(0, 0, 0));
    m_lightStrength = 0.0f;
    m_targetLightStrength = 1.0f;

    m_resetCamera = true;
    m_resetMarbleRotation = true;
    m_audio.PlaySoundEffect(FallingEvent);
}
```

<span data-ttu-id="a2082-245">このセクションでは、物理シミュレーションのしくみについては説明しません。</span><span class="sxs-lookup"><span data-stu-id="a2082-245">This section does not describe how the physics simulation works.</span></span> <span data-ttu-id="a2082-246">詳しくは、Marble Maze のソースの **Physics.h** と **Physics.cpp** をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2082-246">For details about that, see **Physics.h** and **Physics.cpp** in the Marble Maze sources.</span></span>

## <a name="next-steps"></a><span data-ttu-id="a2082-247">次の手順</span><span class="sxs-lookup"><span data-stu-id="a2082-247">Next steps</span></span>


<span data-ttu-id="a2082-248">オーディオを扱う際の主な手法については、「[Marble Maze サンプルへのオーディオの追加](adding-audio-to-the-marble-maze-sample.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2082-248">Read [Adding audio to the Marble Maze sample](adding-audio-to-the-marble-maze-sample.md) for information about some of the key practices to keep in mind when you work with audio.</span></span> <span data-ttu-id="a2082-249">このドキュメントでは、Marble Maze が Microsoft メディア ファンデーションと XAudio2 を使ってオーディオ リソースの読み込み、ミキシング、再生を行う方法について説明しています。</span><span class="sxs-lookup"><span data-stu-id="a2082-249">The document discusses how Marble Maze uses Microsoft Media Foundation and XAudio2 to load, mix, and play audio resources.</span></span>

## <a name="related-topics"></a><span data-ttu-id="a2082-250">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a2082-250">Related topics</span></span>


* [<span data-ttu-id="a2082-251">Marble Maze のサンプルへのオーディオの追加</span><span class="sxs-lookup"><span data-stu-id="a2082-251">Adding audio to the Marble Maze sample</span></span>](adding-audio-to-the-marble-maze-sample.md)
* [<span data-ttu-id="a2082-252">Marble Maze サンプルへの視覚的なコンテンツの追加</span><span class="sxs-lookup"><span data-stu-id="a2082-252">Adding visual content to the Marble Maze sample</span></span>](adding-visual-content-to-the-marble-maze-sample.md)
* [<span data-ttu-id="a2082-253">Marble Maze、C++ と DirectX での UWP ゲームの開発</span><span class="sxs-lookup"><span data-stu-id="a2082-253">Developing Marble Maze, a UWP game in C++ and DirectX</span></span>](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 




