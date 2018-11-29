---
title: 未加工のゲーム コントローラー
description: ほとんどすべての種類のゲーム コントローラーから入力を読み取るには、Windows.Gaming.Input 未加工のゲーム コントローラー API を使用します。
ms.assetid: 2A466C16-1F51-4D8D-AD13-704B6D3C7BEC
ms.date: 03/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, 未加工のゲーム コントローラー
ms.localizationpriority: medium
ms.openlocfilehash: 7b5f4d49ad49cf9f9065fe17788456e9dd2a4a4e
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7992595"
---
# <a name="raw-game-controller"></a><span data-ttu-id="abcaf-104">未加工のゲーム コントローラー</span><span class="sxs-lookup"><span data-stu-id="abcaf-104">Raw game controller</span></span>

<span data-ttu-id="abcaf-105">このページでは、[Windows.Gaming.Input.RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、ほとんどすべての種類のゲーム コントローラー向けプログラミングの基礎について説明します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-105">This page describes the basics of programming for nearly any type of game controller using [Windows.Gaming.Input.RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) and related APIs for the Universal Windows Platform (UWP).</span></span>

<span data-ttu-id="abcaf-106">このページでは、次のことを解説します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-106">By reading this page, you'll learn:</span></span>

* <span data-ttu-id="abcaf-107">接続されている未加工のゲーム コントローラーとそのユーザーの一覧を収集する方法</span><span class="sxs-lookup"><span data-stu-id="abcaf-107">how to gather a list of connected raw game controllers and their users</span></span>
* <span data-ttu-id="abcaf-108">未加工のゲーム コントローラーが追加または削除されたことを検出する方法</span><span class="sxs-lookup"><span data-stu-id="abcaf-108">how to detect that a raw game controller has been added or removed</span></span>
* <span data-ttu-id="abcaf-109">未加工のゲーム コントローラーの機能を取得する方法</span><span class="sxs-lookup"><span data-stu-id="abcaf-109">how to get the capabilities of a raw game controller</span></span>
* <span data-ttu-id="abcaf-110">未加工のゲーム コントローラーからの入力を読み取る方法</span><span class="sxs-lookup"><span data-stu-id="abcaf-110">how to read input from a raw game controller</span></span>

## <a name="overview"></a><span data-ttu-id="abcaf-111">概要</span><span class="sxs-lookup"><span data-stu-id="abcaf-111">Overview</span></span>

<span data-ttu-id="abcaf-112">未加工のゲーム コントローラーは、さまざまな種類の一般的なゲーム コントローラーの入力を備えた、ゲーム コントローラーの汎用的な表現です。</span><span class="sxs-lookup"><span data-stu-id="abcaf-112">A raw game controller is a generic representation of a game controller, with inputs found on many different kinds of common game controllers.</span></span> <span data-ttu-id="abcaf-113">これらの入力は、名前のないボタン、スイッチ、軸の単純な配列として公開されます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-113">These inputs are exposed as simple arrays of unnamed buttons, switches, and axes.</span></span> <span data-ttu-id="abcaf-114">未加工のゲーム コントローラーを使用すると、ユーザーが使っているコントローラーの種類に関係なく、カスタム入力マッピングを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-114">Using a raw game controller, you can allow customers to create custom input mappings no matter what type of controller they're using.</span></span>

<span data-ttu-id="abcaf-115">[RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) クラスは、他の入力クラス ([ArcadeStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick)、[FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) など) がニーズを満たさない場合のシナリオに対応することを目的としています。つまり、ユーザーがさまざまな種類のゲーム コントローラーを使用することが予想され、より汎用的なクラスが必要な場合は、このクラスが適しています。</span><span class="sxs-lookup"><span data-stu-id="abcaf-115">The [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) class is really meant for scenarios when the other input classes ([ArcadeStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick), [FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick), and so on) don't meet your needs&mdash;if you want something more generic, anticipating that customers will use many different types of game controllers, then this class is for you.</span></span>

## <a name="detect-and-track-raw-game-controllers"></a><span data-ttu-id="abcaf-116">未加工のゲーム コントローラーの検出と追跡</span><span class="sxs-lookup"><span data-stu-id="abcaf-116">Detect and track raw game controllers</span></span>

<span data-ttu-id="abcaf-117">未加工のゲーム コントローラーの検出と追跡の方法はゲームパッドの場合とまったく同じですが、[Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) クラスの代わりに [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) クラスを使用する点だけが異なります。</span><span class="sxs-lookup"><span data-stu-id="abcaf-117">Detecting and tracking raw game controllers works in exactly the same way as it does for gamepads, except with the [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) class instead of the [Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) class.</span></span> <span data-ttu-id="abcaf-118">詳細については、「[ゲームパッドと振動](gamepad-and-vibration.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="abcaf-118">See [Gamepad and vibration](gamepad-and-vibration.md) for more information.</span></span>

<!-- Raw game controllers are managed by the system, therefore you don't have to create or initialize them. The system provides a list of connected raw game controllers and events to notify you when a raw game controller is added or removed.

### The raw game controller list

The [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) class provides a static property, [RawGameControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_RawGameControllers), which is a read-only list of raw game controllers that are currently connected. Because you might only be interested in some of the connected raw game controllers, we recommend that you maintain your own collection instead of accessing them through the **RawGameControllers** property.

The following example copies all connected raw game controllers into a new collection:

```cpp
auto myRawGameControllers = ref new Vector<RawGameController^>();

for (auto rawGameController : RawGameController::RawGameControllers)
{
    // This code assumes that you're interested in all raw game controllers.
    myRawGameControllers->Append(rawGameController);
}
```

### Adding and removing raw game controllers

When a raw game controller is added or removed, the [RawGameControllerAdded](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_RawGameControllerAdded) and [RawGameControllerRemoved](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_RawGameControllerRemoved) events are raised. You can register handlers for these events to keep track of the raw game controllers that are currently connected.

The following example starts tracking a raw game controller that's been added:

```cpp
RawGameController::RawGameControllerAdded += 
    ref new EventHandler<RawGameController^>(
        [] (Platform::Object^, RawGameController^ args)
{
    // This code assumes that you're interested in all new raw game controllers.
    myRawGameControllers->Append(args);
});
```

The following example stops tracking a raw game controller that's been removed:

```cpp
RawGameController::RawGameControllerRemoved +=
    ref new EventHandler<RawGameController^>(
        [] (Platform::Object^, RawGameController^ args)
{
    unsigned int indexRemoved;

    if (myRawGameControllers->IndexOf(args, &indexRemoved))
    {
        myRawGameControllers->RemoveAt(indexRemoved);
    }
});
```

### Users and headsets

Each raw game controller can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features. To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md). -->

## <a name="get-the-capabilities-of-a-raw-game-controller"></a><span data-ttu-id="abcaf-119">未加工のゲーム コントローラーの機能の取得</span><span class="sxs-lookup"><span data-stu-id="abcaf-119">Get the capabilities of a raw game controller</span></span>

<span data-ttu-id="abcaf-120">対象となる未加工のゲーム コントローラーを特定した後、コントローラーの機能に関する情報を収集できます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-120">After you identify the raw game controller that you're interested in, you can gather information on the capabilities of the controller.</span></span> <span data-ttu-id="abcaf-121">未加工のゲーム コントローラー上のボタンの数は [RawGameController.ButtonCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.ButtonCount) を、アナログ軸の数は [RawGameController.AxisCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.AxisCount) を、スイッチの数は [RawGameController.SwitchCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.SwitchCount) を使用して取得できます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-121">You can get the number of buttons on the raw game controller with [RawGameController.ButtonCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.ButtonCount), the number of analog axes with [RawGameController.AxisCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.AxisCount), and the number of switches with [RawGameController.SwitchCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.SwitchCount).</span></span> <span data-ttu-id="abcaf-122">さらに、[RawGameController.GetSwitchKind](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetSwitchKind_System_Int32_) を使用してスイッチの種類を取得できます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-122">Additionally, you can get the type of a switch using [RawGameController.GetSwitchKind](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetSwitchKind_System_Int32_).</span></span>

<span data-ttu-id="abcaf-123">次の例では、未加工のゲーム コントローラーの入力の数を取得します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-123">The following example gets the input counts of a raw game controller:</span></span>

```cpp
auto rawGameController = myRawGameControllers->GetAt(0);
int buttonCount = rawGameController->ButtonCount;
int axisCount = rawGameController->AxisCount;
int switchCount = rawGameController->SwitchCount;
```

<span data-ttu-id="abcaf-124">次の例では、各スイッチの種類を特定します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-124">The following example determines the type of each switch:</span></span>

```cpp
for (uint32_t i = 0; i < switchCount; i++)
{
    GameControllerSwitchKind mySwitch = rawGameController->GetSwitchKind(i);
}
```

## <a name="reading-the-raw-game-controller"></a><span data-ttu-id="abcaf-125">未加工のゲーム コントローラーの読み取り</span><span class="sxs-lookup"><span data-stu-id="abcaf-125">Reading the raw game controller</span></span>

<span data-ttu-id="abcaf-126">未加工のゲーム コントローラーの入力の数を確認したら、ゲーム コントローラーからの入力を収集する準備は完了です。</span><span class="sxs-lookup"><span data-stu-id="abcaf-126">After you know the number of inputs on a raw game controller, you're ready to gather input from it.</span></span> <span data-ttu-id="abcaf-127">ただし、なじみのある一部の他の種類の入力とは違い、未加工のゲーム コントローラーはイベントを発生することによって状態の変化を伝えるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="abcaf-127">However, unlike some other kinds of input that you might be used to, a raw game controller doesn't communicate state-change by raising events.</span></span> <span data-ttu-id="abcaf-128">代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="abcaf-128">Instead, you take regular readings of its current state by _polling_ it.</span></span>

### <a name="polling-the-raw-game-controller"></a><span data-ttu-id="abcaf-129">未加工のゲーム コントローラーのポーリング</span><span class="sxs-lookup"><span data-stu-id="abcaf-129">Polling the raw game controller</span></span>

<span data-ttu-id="abcaf-130">ポーリングでは、明確な時点における未加工のゲーム コントローラーのスナップショットをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="abcaf-130">Polling captures a snapshot of the raw game controller at a precise point in time.</span></span> <span data-ttu-id="abcaf-131">入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。</span><span class="sxs-lookup"><span data-stu-id="abcaf-131">This approach to input gathering is a good fit for most games because their logic typically runs in a deterministic loop rather than being event-driven.</span></span> <span data-ttu-id="abcaf-132">また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="abcaf-132">It's also typically simpler to interpret game commands from input gathered all at once than it is from many single inputs gathered over time.</span></span>

<span data-ttu-id="abcaf-133">未加工のゲーム コントローラーをポーリングするには、[RawGameController.GetCurrentReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetCurrentReading_System_Boolean___Windows_Gaming_Input_GameControllerSwitchPosition___System_Double___) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-133">You poll a raw game controller by calling [RawGameController.GetCurrentReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetCurrentReading_System_Boolean___Windows_Gaming_Input_GameControllerSwitchPosition___System_Double___).</span></span> <span data-ttu-id="abcaf-134">この関数は、未加工のゲーム コントローラーの状態を格納する、ボタン、スイッチ、軸の配列を設定します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-134">This function populates arrays for buttons, switches, and axes that contain the state of the raw game controller.</span></span>

<span data-ttu-id="abcaf-135">次の例では、未加工のゲーム コントローラーをポーリングして現在の状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-135">The following example polls a raw game controller for its current state:</span></span>

```cpp
Platform::Array<bool>^ currentButtonReading =
    ref new Platform::Array<bool>(buttonCount);

Platform::Array<GameControllerSwitchPosition>^ currentSwitchReading =
    ref new Platform::Array<GameControllerSwitchPosition>(switchCount);

Platform::Array<double>^ currentAxisReading = ref new Platform::Array<double>(axisCount);

rawGameController->GetCurrentReading(
    currentButtonReading,
    currentSwitchReading,
    currentAxisReading);
```

<span data-ttu-id="abcaf-136">さまざまな種類のコントローラー間で各配列内のどの位置にどの入力値が保持されるかは保証されていません。そのため、[RawGameController.GetButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetButtonLabel_System_Int32_) メソッドと [RawGameController.GetSwitchKind](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetSwitchKind_System_Int32_) メソッドを使用して、どの入力がどれであるかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="abcaf-136">There is no guarantee of which position in each array will hold which input value among different types of controllers, so you'll need to check which input is which using the methods [RawGameController.GetButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetButtonLabel_System_Int32_) and [RawGameController.GetSwitchKind](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetSwitchKind_System_Int32_).</span></span>

<span data-ttu-id="abcaf-137">**GetButtonLabel** は、ボタンの機能ではなく、物理的なボタンに印字されているテキストや記号を通知します。したがって、UI の補助として使用し、ボタンによって実行される機能についてプレイヤーにヒントを提供する場合に最適です。</span><span class="sxs-lookup"><span data-stu-id="abcaf-137">**GetButtonLabel** will tell you the text or symbol that's printed on the physical button, rather than the button's function&mdash;therefore, it's best used as an aid for UI for cases where you want to give the player hints about which buttons perform which functions.</span></span> <span data-ttu-id="abcaf-138">**GetSwitchKind** は、スイッチの名前ではなく、スイッチの種類 (つまり、スイッチの位置の数) を通知します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-138">**GetSwitchKind** will tell you the type of switch (that is, how many positions it has), but not the name.</span></span>

<span data-ttu-id="abcaf-139">軸やスイッチのラベルを取得するための標準化された方法はないため、自分でこれらをテストして、どの入力がどれであるかを特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="abcaf-139">There is no standardized way to get the label of an axis or switch, so you'll need to test these yourself to determine which input is which.</span></span>

<span data-ttu-id="abcaf-140">特定のコントローラーをサポートする必要がある場合は、[RawGameController.HardwareProductId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareProductId) と [RawGameController.HardwareVendorId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareVendorId) を取得して、それらがコントローラーに合致しているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-140">If you have a specific controller that you want to support, you can get the [RawGameController.HardwareProductId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareProductId) and [RawGameController.HardwareVendorId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareVendorId) and check if they match that controller.</span></span> <span data-ttu-id="abcaf-141">各配列内の各入力の位置は、同じ **HardwareProductId** と **HardwareVendorId** を持つすべてのコントローラーで同じであるため、同じ種類の異なるコントローラー間でのロジックの一貫性に関する問題について心配する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="abcaf-141">The position of each input in each array is the same for every controller with the same **HardwareProductId** and **HardwareVendorId**, so you don't have to worry about your logic potentially being inconsistent among different controllers of the same type.</span></span>

<span data-ttu-id="abcaf-142">読み取りデータでは、未加工のゲーム コントローラーの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも返されます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-142">In addition to the raw game controller state, each reading returns a timestamp that indicates precisely when the state was retrieved.</span></span> <span data-ttu-id="abcaf-143">このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。</span><span class="sxs-lookup"><span data-stu-id="abcaf-143">The timestamp is useful for relating to the timing of previous readings or to the timing of the game simulation.</span></span>

### <a name="reading-the-buttons-and-switches"></a><span data-ttu-id="abcaf-144">ボタンやスイッチの読み取り</span><span class="sxs-lookup"><span data-stu-id="abcaf-144">Reading the buttons and switches</span></span>

<span data-ttu-id="abcaf-145">未加工のゲーム コントローラーのボタンはそれぞれ、ボタンが押されている (ダウン) か、離されている (アップ) かを示すデジタルの読み取り値を提供します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-145">Each of the raw game controller's buttons provides a digital reading that indicates whether it's pressed (down) or released (up).</span></span> <span data-ttu-id="abcaf-146">ボタンの読み取り値は、1 つの配列内の個々のブール値として表されます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-146">Button readings are represented as individual Boolean values in a single array.</span></span> <span data-ttu-id="abcaf-147">各ボタンのラベルは、[RawGameController.GetButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetButtonLabel_System_Int32_) と、配列内のブール値のインデックスを使用して検出できます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-147">The label for each button can be found using [RawGameController.GetButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetButtonLabel_System_Int32_) with the index of the Boolean value in the array.</span></span> <span data-ttu-id="abcaf-148">各値は [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) として表されます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-148">Each value is represented as a [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel).</span></span>

<span data-ttu-id="abcaf-149">次の例では、**XboxA** ボタンが押されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-149">The following example determines whether the **XboxA** button is pressed:</span></span>

```cpp
for (uint32_t i = 0; i < buttonCount; i++)
{
    if (currentButtonReading[i])
    {
        GameControllerButtonLabel buttonLabel = rawGameController->GetButtonLabel(i);

        if (buttonLabel == GameControllerButtonLabel::XboxA)
        {
            // XboxA is pressed.
        }
    }
}
```

<span data-ttu-id="abcaf-150">場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか (一部が押されていて、一部が押されていない) を特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="abcaf-150">Sometimes you might want to determine when a button transitions from pressed to released or released to pressed, whether multiple buttons are pressed or released, or if a set of buttons are arranged in a particular way&mdash;some pressed, some not.</span></span> <span data-ttu-id="abcaf-151">これらの各状態を検出する方法について詳しくは、「[ボタンの状態遷移の検出](input-practices-for-games.md#detecting-button-transitions)」および「[ボタンの複雑な配置の検出](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="abcaf-151">For information on how to detect each of these conditions, see [Detecting button transitions](input-practices-for-games.md#detecting-button-transitions) and [Detecting complex button arrangements](input-practices-for-games.md#detecting-complex-button-arrangements).</span></span>

<span data-ttu-id="abcaf-152">スイッチの値は、[GameControllerSwitchPosition](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerswitchposition) の配列として提供されます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-152">Switch values are provided as an array of [GameControllerSwitchPosition](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerswitchposition).</span></span> <span data-ttu-id="abcaf-153">このプロパティはビットフィールドであるため、ビット単位のマスクを使用してスイッチの方向を特定します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-153">Because this property is a bitfield, bitwise masking is used to isolate the direction of the switch.</span></span>

<span data-ttu-id="abcaf-154">次の例では、各スイッチが上の位置であるかどうかを特定します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-154">The following example determines whether each switch is in the up position:</span></span>

```cpp
for (uint32_t i = 0; i < switchCount; i++)
{
    if (GameControllerSwitchPosition::Up ==
        (currentSwitchReading[i] & GameControllerSwitchPosition::Up))
    {
        // The switch is in the up position.
    }
}
```

### <a name="reading-the-analog-inputs-sticks-triggers-throttles-and-so-on"></a><span data-ttu-id="abcaf-155">アナログ入力 (スティック、トリガー、スロットルなど) の読み取り</span><span class="sxs-lookup"><span data-stu-id="abcaf-155">Reading the analog inputs (sticks, triggers, throttles, and so on)</span></span>

<span data-ttu-id="abcaf-156">アナログ軸は、0.0 ～ 1.0 の読み取り値を提供します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-156">An analog axis provides a reading between 0.0 and 1.0.</span></span> <span data-ttu-id="abcaf-157">これには、標準的なスティックの場合は X と Y、フライト スティックの場合は X、Y、Z 軸 (それぞれロール、ピッチ、ヨー) など、スティックの各次元の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-157">This includes each dimension on a stick such as X and Y for standard sticks or even X, Y, and Z axes (roll, pitch, and yaw, respectively) for flight sticks.</span></span>

<span data-ttu-id="abcaf-158">この値は、アナログ トリガー、スロットル、その他のアナログ入力の種類を表すことができます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-158">The values can represent analog triggers, throttles, or any other type of analog input.</span></span> <span data-ttu-id="abcaf-159">これらの値にラベルは提供されないため、さまざまな入力デバイスでコードをテストし、想定している動作に正しく合致しているかどうかを確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="abcaf-159">These values are not provided with labels, so we suggest that your code is tested with a variety of input devices to ensure that they match correctly with your assumptions.</span></span>

<span data-ttu-id="abcaf-160">どの軸も、スティックが中央の位置にある場合、値は約 0.5 になりますが、正確な値は、後続の読み取り値間であっても、異なるのが普通です。このばらつきを緩和する対策については、このセクションで後ほど説明します。</span><span class="sxs-lookup"><span data-stu-id="abcaf-160">In all axes, the value is approximately 0.5 for a stick when it is in the center position, but it's normal for the precise value to vary, even between subsequent readings; strategies for mitigating this variation are discussed later in this section.</span></span>

<span data-ttu-id="abcaf-161">次の例は、Xbox コントローラーからアナログ値を読み取る方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="abcaf-161">The following example shows how to read the analog values from an Xbox controller:</span></span>

```cpp
// Xbox controllers have 6 axes: 2 for each stick and one for each trigger.
float leftStickX = currentAxisReading[0];
float leftStickY = currentAxisReading[1];
float rightStickX = currentAxisReading[2];
float rightStickY = currentAxisReading[3];
float leftTrigger = currentAxisReading[4];
float rightTrigger = currentAxisReading[5];
```

<span data-ttu-id="abcaf-162">スティックの値を読み取るとき、中央の位置で待機中のサムスティックの値は、一定してニュートラルの 0.5 にはなりません。スティックを動かし、中央の位置に戻るたびに、0.5 に近い値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-162">When reading the stick values, you'll notice that they don't reliably produce a neutral reading of 0.5 when at rest in the center position; instead, they'll produce different values near 0.5 each time the stick is moved and returned to the center position.</span></span> <span data-ttu-id="abcaf-163">このばらつきを少なくするために、小さな_デッドゾーン_を実装します。デッドゾーン+は、理想の中央の位置付近の、無視される範囲の値です。</span><span class="sxs-lookup"><span data-stu-id="abcaf-163">To mitigate these variations, you can implement a small _deadzone_, which is a range of values near the ideal center position that are ignored.</span></span>

<span data-ttu-id="abcaf-164">デッドゾーンを実装する方法の 1 つは、スティックが中央から移動された距離を特定し、読み取り値が指定した距離以下の場合は無視することです。</span><span class="sxs-lookup"><span data-stu-id="abcaf-164">One way to implement a deadzone is to determine how far the stick has moved from the center, and ignore readings that are nearer than some distance you choose.</span></span> <span data-ttu-id="abcaf-165">この距離は、ピタゴラスの定理を使って概算できます (スティックの読み取り値は、平面値ではなく、本質的に極値であるため正確な計算にはなりません)。</span><span class="sxs-lookup"><span data-stu-id="abcaf-165">You can compute the distance roughly&mdash;it's not exact because stick readings are essentially polar, not planar, values&mdash;just by using the Pythagorean theorem.</span></span> <span data-ttu-id="abcaf-166">これで、放射状のデッドゾーンが作られます。</span><span class="sxs-lookup"><span data-stu-id="abcaf-166">This produces a radial deadzone.</span></span>

<span data-ttu-id="abcaf-167">次の例は、ピタゴラスの定理を使った基本的な放射状のデッドゾーンを示しています。</span><span class="sxs-lookup"><span data-stu-id="abcaf-167">The following example demonstrates a basic radial deadzone using the Pythagorean theorem:</span></span>

```cpp
// Choose a deadzone. Readings inside this radius are ignored.
const float deadzoneRadius = 0.1f;
const float deadzoneSquared = deadzoneRadius * deadzoneRadius;

// Pythagorean theorem: For a right triangle, hypotenuse^2 = (opposite side)^2 + (adjacent side)^2
float oppositeSquared = leftStickY * leftStickY;
float adjacentSquared = leftStickX * leftStickX;

// Accept and process input if true; otherwise, reject and ignore it.
if ((oppositeSquared + adjacentSquared) < deadzoneSquared)
{
    // Input accepted, process it.
}
```

<!--## Run the RawGameControllerUWP sample

The [RawGameControllerUWP sample (GitHub)](TODO: Link) demonstrates how to use raw game controllers. TODO: More information-->

## <a name="see-also"></a><span data-ttu-id="abcaf-168">関連項目</span><span class="sxs-lookup"><span data-stu-id="abcaf-168">See also</span></span>

* [<span data-ttu-id="abcaf-169">ゲームの入力</span><span class="sxs-lookup"><span data-stu-id="abcaf-169">Input for games</span></span>](input-for-games.md)
* [<span data-ttu-id="abcaf-170">ゲームの入力プラクティス</span><span class="sxs-lookup"><span data-stu-id="abcaf-170">Input practices for games</span></span>](input-practices-for-games.md)
* [<span data-ttu-id="abcaf-171">Windows.Gaming.Input 名前空間</span><span class="sxs-lookup"><span data-stu-id="abcaf-171">Windows.Gaming.Input namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input)
* [<span data-ttu-id="abcaf-172">Windows.Gaming.Input.RawGameController クラス</span><span class="sxs-lookup"><span data-stu-id="abcaf-172">Windows.Gaming.Input.RawGameController class</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller)
* [<span data-ttu-id="abcaf-173">Windows.Gaming.Input.IGameController インターフェイス</span><span class="sxs-lookup"><span data-stu-id="abcaf-173">Windows.Gaming.Input.IGameController interface</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller)
* [<span data-ttu-id="abcaf-174">Windows.Gaming.Input.IGameControllerBatteryInfo インターフェイス</span><span class="sxs-lookup"><span data-stu-id="abcaf-174">Windows.Gaming.Input.IGameControllerBatteryInfo interface</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontrollerbatteryinfo)