---
title: フライト スティック
description: フライト スティックからの入力を読み取るには、Windows.Gaming.Input フライト スティック API を使用します。
ms.assetid: DC633F6B-FDC9-4D6E-8401-305861F31192
ms.date: 03/06/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, フライト スティック
ms.localizationpriority: medium
ms.openlocfilehash: 5eceb30c62f1e803397aff71d59b560c39736cf9
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8345687"
---
# <a name="flight-stick"></a><span data-ttu-id="6151e-104">フライト スティック</span><span class="sxs-lookup"><span data-stu-id="6151e-104">Flight stick</span></span>

<span data-ttu-id="6151e-105">このページでは、[Windows.Gaming.Input.FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One 認定フライト スティックを対象にしたプログラミングの基礎について説明します。</span><span class="sxs-lookup"><span data-stu-id="6151e-105">This page describes the basics of programming for Xbox One-certified flight sticks using [Windows.Gaming.Input.FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) and related APIs for the Universal Windows Platform (UWP).</span></span>

<span data-ttu-id="6151e-106">このページでは、次のことを解説します。</span><span class="sxs-lookup"><span data-stu-id="6151e-106">By reading this page, you'll learn:</span></span>

* <span data-ttu-id="6151e-107">接続されているフライト スティックとそのユーザーの一覧を収集する方法</span><span class="sxs-lookup"><span data-stu-id="6151e-107">how to gather a list of connected flight sticks and their users</span></span>
* <span data-ttu-id="6151e-108">フライト スティックが追加または削除されたことを検出する方法</span><span class="sxs-lookup"><span data-stu-id="6151e-108">how to detect that a flight stick has been added or removed</span></span>
* <span data-ttu-id="6151e-109">1 つ以上のフライト スティックの入力を読み取る方法</span><span class="sxs-lookup"><span data-stu-id="6151e-109">how to read input from one or more flight sticks</span></span>
* <span data-ttu-id="6151e-110">フライト スティックを UI ナビゲーション デバイスとして使用する方法</span><span class="sxs-lookup"><span data-stu-id="6151e-110">how flight sticks behave as UI navigation devices</span></span>

## <a name="overview"></a><span data-ttu-id="6151e-111">概要</span><span class="sxs-lookup"><span data-stu-id="6151e-111">Overview</span></span>

<span data-ttu-id="6151e-112">フライト スティックは、航空機や宇宙船のコックピットにあるフライト スティックの操作感を再現することを重視したゲーム用の入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="6151e-112">Flight sticks are gaming input devices that are valued for reproducing the feel of flight sticks that would be found in a plane or spaceship's cockpit.</span></span> <span data-ttu-id="6151e-113">フライトを迅速かつ正確に制御するのに最適な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="6151e-113">They're the perfect input device for quick and accurate control of flight.</span></span> <span data-ttu-id="6151e-114">フライト スティックは、Windows 10 および Xbox One UWP アプリで [Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) 名前空間によってサポートされています。</span><span class="sxs-lookup"><span data-stu-id="6151e-114">Flight sticks are supported in Windows 10 and Xbox One UWP apps by the [Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) namespace.</span></span>

<span data-ttu-id="6151e-115">Xbox One のフライト スティックには、次のコントロールが装備されています。</span><span class="sxs-lookup"><span data-stu-id="6151e-115">Xbox One flight sticks are equipped with the following controls:</span></span>

* <span data-ttu-id="6151e-116">ロール、ヨー、ピッチに対応したツイスト可能なアナログ ジョイスティック</span><span class="sxs-lookup"><span data-stu-id="6151e-116">A twistable analog joystick capable of roll, pitch, and yaw</span></span>
* <span data-ttu-id="6151e-117">アナログ スロットル</span><span class="sxs-lookup"><span data-stu-id="6151e-117">An analog throttle</span></span>
* <span data-ttu-id="6151e-118">2 つのファイア ボタン</span><span class="sxs-lookup"><span data-stu-id="6151e-118">Two fire buttons</span></span>
* <span data-ttu-id="6151e-119">8 方向デジタル ハット スイッチ</span><span class="sxs-lookup"><span data-stu-id="6151e-119">An 8-way digital hat switch</span></span>
* <span data-ttu-id="6151e-120">**View** ボタンと **Menu** ボタン</span><span class="sxs-lookup"><span data-stu-id="6151e-120">**View** and **Menu** buttons</span></span>

> [!NOTE]
> <span data-ttu-id="6151e-121">**View** ボタンと **Menu** ボタンは、ゲームプレイ コマンドではなく、UI ナビゲーションをサポートするために使用されます。したがって、ジョイスティック ボタンとは異なり、簡単にはアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="6151e-121">The **View** and **Menu** buttons are used to support UI navigation, not gameplay commands, and therefore can't be readily accessed as joystick buttons.</span></span>

### <a name="ui-navigation"></a><span data-ttu-id="6151e-122">UI のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="6151e-122">UI navigation</span></span>

<span data-ttu-id="6151e-123">ユーザー インターフェイスの操作に異なる入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、ほとんどの_物理_入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の_論理_入力デバイスとして同時に機能します。</span><span class="sxs-lookup"><span data-stu-id="6151e-123">In order to ease the burden of supporting the different input devices for user interface navigation and to encourage consistency between games and devices, most _physical_ input devices simultaneously act as separate _logical_ input devices called [UI navigation controllers](ui-navigation-controller.md).</span></span> <span data-ttu-id="6151e-124">UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。</span><span class="sxs-lookup"><span data-stu-id="6151e-124">The UI navigation controller provides a common vocabulary for UI navigation commands across input devices.</span></span>

<span data-ttu-id="6151e-125">フライト スティックは、UI ナビゲーション コント ローラーとして、ナビゲーション コマンドの[必須セット](ui-navigation-controller.md#required-set)を、ジョイスティックと **View**、**Menu**、**FirePrimary**、**FireSecondary** ボタンにマップします。</span><span class="sxs-lookup"><span data-stu-id="6151e-125">As a UI navigation controller, a flight stick maps the [required set](ui-navigation-controller.md#required-set) of navigation commands to the joystick and **View**, **Menu**, **FirePrimary**, and **FireSecondary** buttons.</span></span>

| <span data-ttu-id="6151e-126">ナビゲーション コマンド</span><span class="sxs-lookup"><span data-stu-id="6151e-126">Navigation command</span></span> | <span data-ttu-id="6151e-127">フライト スティックの入力</span><span class="sxs-lookup"><span data-stu-id="6151e-127">Flight stick input</span></span>                  |
| ------------------:| ----------------------------------- |
|                 <span data-ttu-id="6151e-128">上</span><span class="sxs-lookup"><span data-stu-id="6151e-128">Up</span></span> | <span data-ttu-id="6151e-129">ジョイスティック上</span><span class="sxs-lookup"><span data-stu-id="6151e-129">Joystick up</span></span>                         |
|               <span data-ttu-id="6151e-130">下</span><span class="sxs-lookup"><span data-stu-id="6151e-130">Down</span></span> | <span data-ttu-id="6151e-131">ジョイスティック下</span><span class="sxs-lookup"><span data-stu-id="6151e-131">Joystick down</span></span>                       |
|               <span data-ttu-id="6151e-132">左</span><span class="sxs-lookup"><span data-stu-id="6151e-132">Left</span></span> | <span data-ttu-id="6151e-133">ジョイスティック左</span><span class="sxs-lookup"><span data-stu-id="6151e-133">Joystick left</span></span>                       |
|              <span data-ttu-id="6151e-134">右</span><span class="sxs-lookup"><span data-stu-id="6151e-134">Right</span></span> | <span data-ttu-id="6151e-135">ジョイスティック右</span><span class="sxs-lookup"><span data-stu-id="6151e-135">Joystick right</span></span>                      |
|               <span data-ttu-id="6151e-136">ビュー</span><span class="sxs-lookup"><span data-stu-id="6151e-136">View</span></span> | <span data-ttu-id="6151e-137">**View** ボタン</span><span class="sxs-lookup"><span data-stu-id="6151e-137">**View** button</span></span>                     |
|               <span data-ttu-id="6151e-138">Menu</span><span class="sxs-lookup"><span data-stu-id="6151e-138">Menu</span></span> | <span data-ttu-id="6151e-139">**Menu** ボタン</span><span class="sxs-lookup"><span data-stu-id="6151e-139">**Menu** button</span></span>                     |
|             <span data-ttu-id="6151e-140">OK</span><span class="sxs-lookup"><span data-stu-id="6151e-140">Accept</span></span> | <span data-ttu-id="6151e-141">**FirePrimary** ボタン</span><span class="sxs-lookup"><span data-stu-id="6151e-141">**FirePrimary** button</span></span>              |
|             <span data-ttu-id="6151e-142">キャンセル</span><span class="sxs-lookup"><span data-stu-id="6151e-142">Cancel</span></span> | <span data-ttu-id="6151e-143">**FireSecondary** ボタン</span><span class="sxs-lookup"><span data-stu-id="6151e-143">**FireSecondary** button</span></span>            |

<span data-ttu-id="6151e-144">フライト スティックは、ナビゲーション コマンドの[オプション セット](ui-navigation-controller.md#optional-set)はマップしません。</span><span class="sxs-lookup"><span data-stu-id="6151e-144">Flight sticks don't map any of the [optional set](ui-navigation-controller.md#optional-set) of navigation commands.</span></span>

## <a name="detect-and-track-flight-sticks"></a><span data-ttu-id="6151e-145">フライト スティックの検出と追跡</span><span class="sxs-lookup"><span data-stu-id="6151e-145">Detect and track flight sticks</span></span>

<span data-ttu-id="6151e-146">フライト スティックの検出と追跡の方法はゲームパッドの場合とまったく同じですが、[Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) クラスの代わりに [FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) クラスを使用する点だけが異なります。</span><span class="sxs-lookup"><span data-stu-id="6151e-146">Detecting and tracking flight sticks works in exactly the same way as it does for gamepads, except with the [FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) class instead of the [Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) class.</span></span> <span data-ttu-id="6151e-147">詳細については、「[ゲームパッドと振動](gamepad-and-vibration.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6151e-147">See [Gamepad and vibration](gamepad-and-vibration.md) for more information.</span></span>

<!-- Flight sticks are managed by the system, therefore you don't have to create or initialize them. The system provides a list of connected flight sticks and events to notify you when a flight stick is added or removed.

### The flight stick list

The [FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) class provides a static property, [FlightSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick#Windows_Gaming_Input_FlightStick_FlightSticks), which is a read-only list of flight sticks that are currently connected. Because you might only be interested in some of the connected flight sticks, we recommend that you maintain your own collection instead of accessing them through the `FlightSticks` property.

The following example copies all connected flight sticks into a new collection:

```cpp
auto myFlightSticks = ref new Vector<FlightStick^>();

for (auto flightStick : FlightStick::FlightSticks)
{
    // This code assumes that you're interested in all flight sticks.
    myFlightSticks->Append(flightStick);
}
```

### Adding and removing flight sticks

When a flight stick is added or removed, the [FlightStickAdded](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick#Windows_Gaming_Input_FlightStick_FlightStickAdded) and [FlightStickRemoved](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick#Windows_Gaming_Input_FlightStick_FlightStickRemoved) events are raised. You can register handlers for these events to keep track of the flight sticks that are currently connected.

The following example starts tracking a flight stick that's been added:

```cpp
FlightStick::FlightStickAdded += 
    ref new EventHandler<FlightStick^>([] (Platform::Object^, FlightStick^ args)
{
    // This code assumes that you're interested in all new flight sticks.
    myFlightSticks->Append(args);
});
```

The following example stops tracking a flight stick that's been removed:

```cpp
FlightStick::FlightStickRemoved += 
    ref new EventHandler<FlightStick^>([] (Platform::Object^, FlightStick^ args)
{
    unsigned int indexRemoved;

    if (myFlightSticks->IndexOf(args, &indexRemoved))
    {
        myFlightSticks->RemoveAt(indexRemoved);
    }
});
```

### Users and headsets

Each flight stick can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features. To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md). -->

## <a name="reading-the-flight-stick"></a><span data-ttu-id="6151e-148">フライト スティックの読み取り</span><span class="sxs-lookup"><span data-stu-id="6151e-148">Reading the flight stick</span></span>

<span data-ttu-id="6151e-149">目的のフライト スティックを特定したら、入力を収集する準備は完了です。</span><span class="sxs-lookup"><span data-stu-id="6151e-149">After you identify the flight stick that you're interested in, you're ready to gather input from it.</span></span> <span data-ttu-id="6151e-150">ただし、なじみのある一部の他の種類の入力とは違い、フライト スティックはイベントを発生することによって状態の変化を伝えるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="6151e-150">However, unlike some other kinds of input that you might be used to, flight sticks don't communicate state-change by raising events.</span></span> <span data-ttu-id="6151e-151">代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="6151e-151">Instead, you take regular readings of their current state by _polling_ them.</span></span>

### <a name="polling-the-flight-stick"></a><span data-ttu-id="6151e-152">フライト スティックのポーリング</span><span class="sxs-lookup"><span data-stu-id="6151e-152">Polling the flight stick</span></span>

<span data-ttu-id="6151e-153">ポーリングでは、明確な時点におけるフライト スティックのスナップショットをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="6151e-153">Polling captures a snapshot of the flight stick at a precise point in time.</span></span> <span data-ttu-id="6151e-154">入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。</span><span class="sxs-lookup"><span data-stu-id="6151e-154">This approach to input gathering is a good fit for most games because their logic typically runs in a deterministic loop rather than being event-driven.</span></span> <span data-ttu-id="6151e-155">また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="6151e-155">It's also typically simpler to interpret game commands from input gathered all at once than it is from many single inputs gathered over time.</span></span>

<span data-ttu-id="6151e-156">フライト スティックをポーリングするには、[FlightStick.GetCurrentReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick.GetCurrentReading) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6151e-156">You poll a flight stick by calling [FlightStick.GetCurrentReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick.GetCurrentReading).</span></span> <span data-ttu-id="6151e-157">この関数は、フライト スティックの状態を含む [FlightStickReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading) を返します。</span><span class="sxs-lookup"><span data-stu-id="6151e-157">This function returns a [FlightStickReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading) that contains the state of the flight stick.</span></span>

<span data-ttu-id="6151e-158">次の例では、フライト スティックをポーリングして現在の状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="6151e-158">The following example polls a flight stick for its current state:</span></span>

```cpp
auto flightStick = myFlightSticks->GetAt(0);
FlightStickReading reading = flightStick->GetCurrentReading();
```

<span data-ttu-id="6151e-159">読み取りデータには、フライト スティックの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも含まれます。　</span><span class="sxs-lookup"><span data-stu-id="6151e-159">In addition to the flight stick state, each reading includes a timestamp that indicates precisely when the state was retrieved.</span></span> <span data-ttu-id="6151e-160">このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。</span><span class="sxs-lookup"><span data-stu-id="6151e-160">The timestamp is useful for relating to the timing of previous readings or to the timing of the game simulation.</span></span>

### <a name="reading-the-joystick-and-throttle-input"></a><span data-ttu-id="6151e-161">ジョイスティックおよびスロットル入力の読み取り</span><span class="sxs-lookup"><span data-stu-id="6151e-161">Reading the joystick and throttle input</span></span>

<span data-ttu-id="6151e-162">ジョイスティックは、X、Y、Z 軸で -1.0 ～ +1.0 のアナログの読み取り値 (それぞれロール、ピッチ、ヨー) を提供します。</span><span class="sxs-lookup"><span data-stu-id="6151e-162">The joystick provides an analog reading between -1.0 and 1.0 in the X, Y, and Z axes (roll, pitch, and yaw, respectively).</span></span> <span data-ttu-id="6151e-163">ロールの場合、-1.0 の値はジョイスティックを最も左に移動した位置に対応し、1.0 の値はジョイスティックを最も右に移動した位置に対応します。</span><span class="sxs-lookup"><span data-stu-id="6151e-163">For roll, a value of -1.0 corresponds to the left-most joystick position, while a value of 1.0 corresponds to the right-most position.</span></span> <span data-ttu-id="6151e-164">ピッチの場合、-1.0 の値はジョイスティックを最も下に移動した位置に対応し、1.0 の値はジョイスティックを最も上に移動した位置に対応します。</span><span class="sxs-lookup"><span data-stu-id="6151e-164">For pitch, a value of -1.0 corresponds to the bottom-most joystick position, while a value of 1.0 corresponds to the top-most position.</span></span> <span data-ttu-id="6151e-165">ヨーの場合、-1.0 の値は反時計回りに最もひねった位置に対応し、1.0 の値は時計回り最もひねった位置に対応します。</span><span class="sxs-lookup"><span data-stu-id="6151e-165">For yaw, a value of -1.0 corresponds to the most counterclockwise, twisted position, while a value of 1.0 corresponds to the most clockwise position.</span></span>

<span data-ttu-id="6151e-166">すべての軸において、ジョイスティックが中央の位置にあるときには値がほぼ 0.0 になりますが、それ以降の読み取り値の間でも、正確な値が変化するのは正常です。</span><span class="sxs-lookup"><span data-stu-id="6151e-166">In all axes, the value is approximately 0.0 when the joystick is in the center position, but it's normal for the precise value to vary, even between subsequent readings.</span></span> <span data-ttu-id="6151e-167">このバリエーションを軽減するための方法は、このセクションで後ほど説明します。</span><span class="sxs-lookup"><span data-stu-id="6151e-167">Strategies for mitigating this variation are discussed later in this section.</span></span>

<span data-ttu-id="6151e-168">ジョイスティックのロールの値は [FlightStickReading.Roll](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Roll) プロパティから読み取られ、ピッチの値は [FlightStickReading.Pitch](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Pitch) プロパティから読み取られ、ヨーの値は [FlightStickReading.Yaw](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Yaw) プロパティから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="6151e-168">The value of the joystick's roll is read from the [FlightStickReading.Roll](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Roll) property, the value of the pitch is read from the [FlightStickReading.Pitch](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Pitch) property, and the value of the yaw is read from the [FlightStickReading.Yaw](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Yaw) property:</span></span>

```cpp
// Each variable will contain a value between -1.0 and 1.0.
float roll = reading.Roll;
float pitch = reading.Pitch;
float yaw = reading.Yaw;
```

<span data-ttu-id="6151e-169">ジョイスティックの値を読み取るとき、中央の位置で待機中のジョイスティックの値は、一定してニュートラルの 0.0 にはなりません。ジョイスティックを動かし、中央の位置に戻るたびに、0.0 に近い値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="6151e-169">When reading the joystick values, you'll notice that they don't reliably produce a neutral reading of 0.0 when the joystick is at rest in the center position; instead, they'll produce different values near 0.0 each time the joystick is moved and returned to the center position.</span></span> <span data-ttu-id="6151e-170">このばらつきを少なくするために、小さな_デッドゾーン_を実装します。デッドゾーン+は、理想の中央の位置付近の、無視される範囲の値です。</span><span class="sxs-lookup"><span data-stu-id="6151e-170">To mitigate these variations, you can implement a small _deadzone_, which is a range of values near the ideal center position that are ignored.</span></span>

<span data-ttu-id="6151e-171">デッドゾーンを実装する方法の 1 つは、ジョイスティックが中央から移動された距離を特定し、読み取り値が指定した距離以下の場合は無視することです。</span><span class="sxs-lookup"><span data-stu-id="6151e-171">One way to implement a deadzone is to determine how far the joystick has moved from the center, and ignore readings that are nearer than some distance you choose.</span></span> <span data-ttu-id="6151e-172">この距離は、ピタゴラスの定理を使って概算できます (ジョイスティックの読み取り値は、平面値ではなく、本質的に極値であるため正確な計算にはなりません)。</span><span class="sxs-lookup"><span data-stu-id="6151e-172">You can compute the distance roughly&mdash;it's not exact because joystick readings are essentially polar, not planar, values&mdash;just by using the Pythagorean theorem.</span></span> <span data-ttu-id="6151e-173">これで、放射状のデッドゾーンが作られます。</span><span class="sxs-lookup"><span data-stu-id="6151e-173">This produces a radial deadzone.</span></span>

<span data-ttu-id="6151e-174">次の例は、ピタゴラスの定理を使った基本的な放射状のデッドゾーンを示しています。</span><span class="sxs-lookup"><span data-stu-id="6151e-174">The following example demonstrates a basic radial deadzone using the Pythagorean theorem:</span></span>

```cpp
// Choose a deadzone. Readings inside this radius are ignored.
const float deadzoneRadius = 0.1f;
const float deadzoneSquared = deadzoneRadius * deadzoneRadius;

// Pythagorean theorem: For a right triangle, hypotenuse^2 = (opposite side)^2 + (adjacent side)^2
float oppositeSquared = pitch * pitch;
float adjacentSquared = roll * roll;

// Accept and process input if true; otherwise, reject and ignore it.
if ((oppositeSquared + adjacentSquared) < deadzoneSquared)
{
    // Input accepted, process it.
}
```

### <a name="reading-the-buttons-and-hat-switch"></a><span data-ttu-id="6151e-175">ボタンとハット スイッチの読み取り</span><span class="sxs-lookup"><span data-stu-id="6151e-175">Reading the buttons and hat switch</span></span>

<span data-ttu-id="6151e-176">フライト スティックの 2 つのファイア ボタンはそれぞれ、ボタンが押されている (ダウン) か、離されている (アップ) かを示すデジタルの読み取り値を提供します。</span><span class="sxs-lookup"><span data-stu-id="6151e-176">Each of the flight stick's two fire buttons provides a digital reading that indicates whether it's pressed (down) or released (up).</span></span> <span data-ttu-id="6151e-177">効率を高めるため、ボタンの読み取り値は個別のブール値としては表されません。代わりに、読み取り値はすべて、[FlightStickButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickbuttons) 列挙型で表される単一のビットフィールドにパックされます。</span><span class="sxs-lookup"><span data-stu-id="6151e-177">For efficiency, button readings aren't represented as individual boolean values&mdash;instead, they're all packed into a single bitfield that's represented by the [FlightStickButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickbuttons) enumeration.</span></span> <span data-ttu-id="6151e-178">さらに、8 方向ハット スイッチは、[GameControllerSwitchPosition](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerswitchposition) 列挙型で表される単一のビットフィールドにパックされる方向を提供します。</span><span class="sxs-lookup"><span data-stu-id="6151e-178">In addition, the 8-way hat switch provides a direction packed into a single bitfield that's represented by the [GameControllerSwitchPosition](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerswitchposition) enumeration.</span></span>

> [!NOTE]
> <span data-ttu-id="6151e-179">フライト スティックには、**View** ボタンや **Menu** ボタンなど、UI ナビゲーションに使用するボタンも搭載されています。</span><span class="sxs-lookup"><span data-stu-id="6151e-179">Flight sticks are equipped with additional buttons used for UI navigation such as the **View** and **Menu** buttons.</span></span> <span data-ttu-id="6151e-180">これらのボタンは `FlightStickButtons` 列挙型には含まれず、UI ナビゲーション デバイスとしてフライト スティックを利用する場合にのみ読み取られます。</span><span class="sxs-lookup"><span data-stu-id="6151e-180">These buttons are not part of the `FlightStickButtons` enumeration and can only be read by accessing the flight stick as a UI navigation device.</span></span> <span data-ttu-id="6151e-181">詳しくは、「[UI ナビゲーション コントローラー](ui-navigation-controller.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6151e-181">For more information, see [UI navigation controller](ui-navigation-controller.md).</span></span>

<span data-ttu-id="6151e-182">ボタンの値は、[FlightStickReading.Buttons](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Buttons) プロパティから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="6151e-182">The button values are read from the [FlightStickReading.Buttons](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Buttons) property.</span></span> <span data-ttu-id="6151e-183">このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。</span><span class="sxs-lookup"><span data-stu-id="6151e-183">Because this property is a bitfield, bitwise masking is used to isolate the value of the button that you're interested in.</span></span> <span data-ttu-id="6151e-184">対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。</span><span class="sxs-lookup"><span data-stu-id="6151e-184">The button is pressed (down) when the corresponding bit is set; otherwise, it's released (up).</span></span>

<span data-ttu-id="6151e-185">次の例では、**FirePrimary** ボタンが押されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="6151e-185">The following example determines whether the **FirePrimary** button is pressed:</span></span>

```cpp
if (FlightStickButtons::FirePrimary == (reading.Buttons & FlightStickButtons::FirePrimary))
{
    // FirePrimary is pressed.
}
```

<span data-ttu-id="6151e-186">次の例では、**FirePrimary** ボタンが離されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="6151e-186">The following example determines whether the **FirePrimary** button is released:</span></span>

```cpp
if (FlightStickButtons::None == (reading.Buttons & FlightStickButtons::FirePrimary))
{
    // FirePrimary is released (not pressed).
}
```

<span data-ttu-id="6151e-187">場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか (一部が押されていて、一部が押されていない) を特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6151e-187">Sometimes you might want to determine when a button transitions from pressed to released or released to pressed, whether multiple buttons are pressed or released, or if a set of buttons are arranged in a particular way&mdash;some pressed, some not.</span></span> <span data-ttu-id="6151e-188">これらの各状態を検出する方法について詳しくは、「[ボタンの状態遷移の検出](input-practices-for-games.md#detecting-button-transitions)」および「[ボタンの複雑な配置の検出](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6151e-188">For information on how to detect each of these conditions, see [Detecting button transitions](input-practices-for-games.md#detecting-button-transitions) and [Detecting complex button arrangements](input-practices-for-games.md#detecting-complex-button-arrangements).</span></span>

<span data-ttu-id="6151e-189">ハット スイッチの値は、[FlightStickReading.HatSwitch](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.HatSwitch) プロパティから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="6151e-189">The hat switch value is read from the [FlightStickReading.HatSwitch](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.HatSwitch) property.</span></span> <span data-ttu-id="6151e-190">このプロパティもビットフィールドであるため、ここでもビット単位のマスクを使用してハット スイッチの位置を特定します。</span><span class="sxs-lookup"><span data-stu-id="6151e-190">Because this property is also a bitfield, bitwise masking is again used to isolate the position of the hat switch.</span></span>

<span data-ttu-id="6151e-191">次の例では、ハット スイッチが上の位置であるかどうかを特定します。</span><span class="sxs-lookup"><span data-stu-id="6151e-191">The following example determines whether the hat switch is in the up position:</span></span>

```cpp
if (GameControllerSwitchPosition::Up == (reading.HatSwitch & GameControllerSwitchPosition::Up))
{
    // The hat switch is in the up position.
}
```

<span data-ttu-id="6151e-192">次の例では、ハット スイッチが中央の位置であるかどうかを特定します。</span><span class="sxs-lookup"><span data-stu-id="6151e-192">The following example determines if the hat switch is in the center position:</span></span>

```cpp
if (GameControllerSwitchPosition::Center == (reading.HatSwitch & GameControllerSwitchPosition::Center))
{
    // The hat switch is in the center position.
}
```

<!--## Run the InputInterfacingUWP sample

The [InputInterfacingUWP sample _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) demonstrates how to use flight sticks and different kinds of input devices in tandem, as well as how these input devices behave as UI navigation controllers.-->

## <a name="see-also"></a><span data-ttu-id="6151e-193">関連項目</span><span class="sxs-lookup"><span data-stu-id="6151e-193">See also</span></span>

* [<span data-ttu-id="6151e-194">Windows.Gaming.Input.UINavigationController クラス</span><span class="sxs-lookup"><span data-stu-id="6151e-194">Windows.Gaming.Input.UINavigationController class</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller)
* [<span data-ttu-id="6151e-195">Windows.Gaming.Input.IGameController インターフェイス</span><span class="sxs-lookup"><span data-stu-id="6151e-195">Windows.Gaming.Input.IGameController interface</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller)
* [<span data-ttu-id="6151e-196">ゲームの入力プラクティス</span><span class="sxs-lookup"><span data-stu-id="6151e-196">Input practices for games</span></span>](input-practices-for-games.md)