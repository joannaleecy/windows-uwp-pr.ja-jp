---
author: eliotcowley
title: アーケード スティック
description: アーケード スティックの検出と読み取りには、Windows.Gaming.Input アーケード スティック API を使用します。
ms.assetid: 2E52232F-3014-4C8C-B39D-FAC478BA3E01
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、アーケード スティック、入力
ms.localizationpriority: medium
ms.openlocfilehash: 13bc03559fb32156f5ff8bb29ed96f8a1e4ac84f
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6665628"
---
# <a name="arcade-stick"></a><span data-ttu-id="7fc0c-104">アーケード スティック</span><span class="sxs-lookup"><span data-stu-id="7fc0c-104">Arcade stick</span></span>

<span data-ttu-id="7fc0c-105">このページでは、[Windows.Gaming.Input.ArcadeStick][arcadestick] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One アーケード スティックを対象にしたプログラミングの基礎について説明します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-105">This page describes the basics of programming for Xbox One arcade sticks using [Windows.Gaming.Input.ArcadeStick][arcadestick] and related APIs for the Universal Windows Platform (UWP).</span></span>

<span data-ttu-id="7fc0c-106">ここでは、次の項目について紹介します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-106">By reading this page, you'll learn:</span></span>

* <span data-ttu-id="7fc0c-107">接続されているアーケード スティックとそのユーザーの一覧を収集する方法</span><span class="sxs-lookup"><span data-stu-id="7fc0c-107">how to gather a list of connected arcade sticks and their users</span></span>
* <span data-ttu-id="7fc0c-108">アーケード スティックが追加または削除されたことを検出する方法</span><span class="sxs-lookup"><span data-stu-id="7fc0c-108">how to detect that an arcade stick has been added or removed</span></span>
* <span data-ttu-id="7fc0c-109">1 つ以上のアーケード スティックの入力を読み取る方法</span><span class="sxs-lookup"><span data-stu-id="7fc0c-109">how to read input from one or more arcade sticks</span></span>
* <span data-ttu-id="7fc0c-110">UI ナビゲーション デバイスとしてのアーケード スティックの動作</span><span class="sxs-lookup"><span data-stu-id="7fc0c-110">how arcade sticks behave as UI navigation devices</span></span>

## <a name="arcade-stick-overview"></a><span data-ttu-id="7fc0c-111">アーケード スティックの概要</span><span class="sxs-lookup"><span data-stu-id="7fc0c-111">Arcade stick overview</span></span>

<span data-ttu-id="7fc0c-112">アーケード スティックは、店頭のアーケード マシンの雰囲気を再現し、デジタルにより高い精度で制御できる入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-112">Arcade sticks are input devices valued for reproducing the feel of stand-up arcade machines and for their high-precision digital controls.</span></span> <span data-ttu-id="7fc0c-113">アーケード スティックは、格闘ゲームなどのアーケード ゲームに最適な入力デバイスで、完全デジタル制御に対応しているあらゆるゲームに適しています。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-113">Arcade sticks are the perfect input device for head-to-head-fighting and other arcade-style games, and are suitable for any game that works well with all-digital controls.</span></span> <span data-ttu-id="7fc0c-114">アーケード スティックは、Windows 10 および Xbox One UWP アプリで [Windows.Gaming.Input][] 名前空間によってサポートされています。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-114">Arcade sticks are supported in Windows 10 and Xbox One UWP apps by the [Windows.Gaming.Input][] namespace.</span></span>

<span data-ttu-id="7fc0c-115">Xbox One アーケード スティックが装備されて、8 方向デジタル ジョイスティック、6 つの**アクション**ボタン (下の画像で A1 A6 として表されます)、および 2 つの**特別な**ボタン (S1 と S2 として表されます)。これらはサポートされていないアナログ制御やバイブレーション デジタルの入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-115">Xbox One arcade sticks are equipped with an 8-way digital joystick, six **Action** buttons (represented as A1-A6 in the image below), and two **Special** buttons (represented as S1 and S2); they're all-digital input devices that don't support analog controls or vibration.</span></span> <span data-ttu-id="7fc0c-116">Xbox One アーケード スティックも UI ナビゲーションをサポートするために使用する**ビュー**と**メニュー**のボタンも搭載されていますが、これらには、ゲームプレイ コマンドのサポートを意図しない、ジョイスティック ボタンとしてすぐにアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-116">Xbox One arcade sticks are also equipped with **View** and **Menu** buttons used to support UI navigation but they're not intended to support gameplay commands and can't be readily accessed as joystick buttons.</span></span>

![アーケード スティックとジョイスティックの 4 方向、6 つのアクション ボタン (A1-A6) と 2 つの特別なボタン (S1 と S2)](images/arcade-stick-1.png)

### <a name="ui-navigation"></a><span data-ttu-id="7fc0c-118">UI のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="7fc0c-118">UI navigation</span></span>

<span data-ttu-id="7fc0c-119">ユーザー インターフェイスの操作にさまざまな入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、ほとんどの物理__ 入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の論理__ 入力デバイスとして同時に機能します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-119">In order to ease the burden of supporting many different input devices for user interface navigation and to encourage consistency between games and devices, most _physical_ input devices simultaneously act as a separate _logical_ input device called a [UI navigation controller](ui-navigation-controller.md).</span></span> <span data-ttu-id="7fc0c-120">UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-120">The UI navigation controller provides a common vocabulary for UI navigation commands across input devices.</span></span>

<span data-ttu-id="7fc0c-121">UI ナビゲーション コント ローラーとしては、アーケード スティックは、ナビゲーション コマンドの[必須の設定](ui-navigation-controller.md#required-set)をジョイスティックと**ビュー**、**メニュー**の**アクション 1**、および**アクション 2**ボタンにマップされます。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-121">As a UI navigation controller, arcade sticks map the [required set](ui-navigation-controller.md#required-set) of navigation commands to the joystick and **View**, **Menu**, **Action 1**, and **Action 2** buttons.</span></span>

| <span data-ttu-id="7fc0c-122">ナビゲーション コマンド</span><span class="sxs-lookup"><span data-stu-id="7fc0c-122">Navigation command</span></span> | <span data-ttu-id="7fc0c-123">アーケード スティック入力</span><span class="sxs-lookup"><span data-stu-id="7fc0c-123">Arcade stick input</span></span>  |
| ------------------:| ------------------- |
|                 <span data-ttu-id="7fc0c-124">Up</span><span class="sxs-lookup"><span data-stu-id="7fc0c-124">Up</span></span> | <span data-ttu-id="7fc0c-125">スティックを上</span><span class="sxs-lookup"><span data-stu-id="7fc0c-125">Stick up</span></span>            |
|               <span data-ttu-id="7fc0c-126">Down</span><span class="sxs-lookup"><span data-stu-id="7fc0c-126">Down</span></span> | <span data-ttu-id="7fc0c-127">スティックを下</span><span class="sxs-lookup"><span data-stu-id="7fc0c-127">Stick down</span></span>          |
|               <span data-ttu-id="7fc0c-128">Left</span><span class="sxs-lookup"><span data-stu-id="7fc0c-128">Left</span></span> | <span data-ttu-id="7fc0c-129">スティックを左</span><span class="sxs-lookup"><span data-stu-id="7fc0c-129">Stick left</span></span>          |
|              <span data-ttu-id="7fc0c-130">Right</span><span class="sxs-lookup"><span data-stu-id="7fc0c-130">Right</span></span> | <span data-ttu-id="7fc0c-131">スティックを右</span><span class="sxs-lookup"><span data-stu-id="7fc0c-131">Stick right</span></span>         |
|               <span data-ttu-id="7fc0c-132">View</span><span class="sxs-lookup"><span data-stu-id="7fc0c-132">View</span></span> | <span data-ttu-id="7fc0c-133">ビュー ボタン</span><span class="sxs-lookup"><span data-stu-id="7fc0c-133">View button</span></span>         |
|               <span data-ttu-id="7fc0c-134">Menu</span><span class="sxs-lookup"><span data-stu-id="7fc0c-134">Menu</span></span> | <span data-ttu-id="7fc0c-135">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="7fc0c-135">Menu button</span></span>         |
|             <span data-ttu-id="7fc0c-136">Accept</span><span class="sxs-lookup"><span data-stu-id="7fc0c-136">Accept</span></span> | <span data-ttu-id="7fc0c-137">アクション 1 ボタン</span><span class="sxs-lookup"><span data-stu-id="7fc0c-137">Action 1 button</span></span>     |
|             <span data-ttu-id="7fc0c-138">Cancel</span><span class="sxs-lookup"><span data-stu-id="7fc0c-138">Cancel</span></span> | <span data-ttu-id="7fc0c-139">アクション 2 ボタン</span><span class="sxs-lookup"><span data-stu-id="7fc0c-139">Action 2 button</span></span>     |

<span data-ttu-id="7fc0c-140">アーケード スティックは、ナビゲーション コマンドの[オプション セット](ui-navigation-controller.md#optional-set)はマップしません。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-140">Arcade sticks don't map any of the [optional set](ui-navigation-controller.md#optional-set) of navigation commands.</span></span>

## <a name="detect-and-track-arcade-sticks"></a><span data-ttu-id="7fc0c-141">アーケード スティックの検出と追跡</span><span class="sxs-lookup"><span data-stu-id="7fc0c-141">Detect and track arcade sticks</span></span>

<span data-ttu-id="7fc0c-142">検出と追跡のアーケード スティックのまったく同じ方法では、ゲームパッドを除く、[ゲームパッド](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad)のクラスではなく[ArcadeStick][]クラスです。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-142">Detecting and tracking arcade sticks works in exactly the same way as it does for gamepads, except with the [ArcadeStick][] class instead of the [Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) class.</span></span> <span data-ttu-id="7fc0c-143">詳細については、「[ゲームパッドと振動](gamepad-and-vibration.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-143">See [Gamepad and vibration](gamepad-and-vibration.md) for more information.</span></span>

<!-- Arcade sticks are managed by the system, therefore you don't have to create or initialize them. The system provides a list of connected arcades sticks and events to notify you when an arcade stick is added or removed.

### The arcade sticks list

The [ArcadeStick][] class provides a static property, [ArcadeSticks][], which is a read-only list of arcade sticks that are currently connected. Because you might only be interested in some of the connected arcade sticks, it's recommended that you maintain your own collection instead of accessing them through the `ArcadeSticks` property.

The following example copies all connected arcade sticks into a new collection. Note that because other threads in the background will be accessing this collection (in the [ArcadeStickAdded][] and [ArcadeStickRemoved][] events), you need to place a lock around any code that reads or updates the collection.

```cpp
auto myArcadeSticks = ref new Vector<ArcadeStick^>();
critical_section myLock{};

for (auto arcadeStick : ArcadeStick::ArcadeSticks)
{
    // Check if the arcade stick is already in myArcadeSticks; if it isn't, add
    // it.
    critical_section::scoped_lock lock{ myLock };
    auto it = std::find(begin(myArcadeSticks), end(myArcadeSticks), arcadeStick);

    if (it == end(myArcadeSticks))
    {
        // This code assumes that you're interested in all arcade sticks.
        myArcadeSticks->Append(arcadeStick);
    }
}
```

### Adding and removing arcade sticks

When an arcade stick is added or removed the [ArcadeStickAdded][] and [ArcadeStickRemoved][] events are raised. You can register handlers for these events to keep track of the arcade sticks that are currently connected.

The following example starts tracking an arcade stick that's been added.

```cpp
ArcadeStick::ArcadeStickAdded += ref new EventHandler<ArcadeStick^>(Platform::Object^, ArcadeStick^ args)
{
    // Check if the just-added arcade stick is already in myArcadeSticks; if it
    // isn't, add it.
    critical_section::scoped_lock lock{ myLock };
    auto it = std::find(begin(myGamepads), end(myGamepads), args);

    // This code assumes that you're interested in all new arcade sticks.
    myArcadeSticks->Append(args);
}
```

The following example stops tracking an arcade stick that's been removed.

```cpp
ArcadeStick::ArcadeStickRemoved += ref new EventHandler<ArcadeStick^>(Platform::Object^, ArcadeStick^ args)
{
    unsigned int indexRemoved;

    if(myArcadeSticks->IndexOf(args, &indexRemoved))
    {
        myArcadeSticks->RemoveAt(indexRemoved);
    }
}
```

### Users and headsets

Each arcade stick can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features. To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md). -->

## <a name="reading-the-arcade-stick"></a><span data-ttu-id="7fc0c-144">アーケード スティックの読み取り</span><span class="sxs-lookup"><span data-stu-id="7fc0c-144">Reading the arcade stick</span></span>

<span data-ttu-id="7fc0c-145">目的のアーケード スティックを特定したら、入力を収集する準備は完了です。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-145">After you identify the arcade stick that you're interested in, you're ready to gather input from it.</span></span> <span data-ttu-id="7fc0c-146">ただし、なじみのある一部の他の種類の入力とは違い、アーケード スティックはイベントを発生することによって状態の変化を伝えるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-146">However, unlike some other kinds of input that you might be used to, arcade sticks don't communicate state-change by raising events.</span></span> <span data-ttu-id="7fc0c-147">代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-147">Instead, you take regular readings of their current state by _polling_ them.</span></span>

### <a name="polling-the-arcade-stick"></a><span data-ttu-id="7fc0c-148">アーケード スティックのポーリング</span><span class="sxs-lookup"><span data-stu-id="7fc0c-148">Polling the arcade stick</span></span>

<span data-ttu-id="7fc0c-149">ポーリングでは、明確な時点におけるアーケード スティックのスナップショットをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-149">Polling captures a snapshot of the arcade stick at a precise point in time.</span></span> <span data-ttu-id="7fc0c-150">入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-150">This approach to input gathering is a good fit for most games because their logic typically runs in a deterministic loop rather than being event-driven; it's also typically simpler to interpret game commands from input gathered all at once than it is from many single inputs gathered over time.</span></span>

<span data-ttu-id="7fc0c-151">アーケード スティックをポーリングするには、[GetCurrentReading][] を呼び出します。この関数はアーケード スティックの状態が格納された [ArcadeStickReading][] を返します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-151">You poll an arcade stick by calling [GetCurrentReading][]; this function returns an [ArcadeStickReading][] that contains the state of the arcade stick.</span></span>

<span data-ttu-id="7fc0c-152">次の例では、アーケード スティックをポーリングして現在の状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-152">The following example polls an arcade stick for its current state.</span></span>

```cpp
auto arcadestick = myArcadeSticks[0];

ArcadeStickReading reading = arcadestick->GetCurrentReading();
```

<span data-ttu-id="7fc0c-153">読み取りデータには、アーケード スティックの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも含まれます。　</span><span class="sxs-lookup"><span data-stu-id="7fc0c-153">In addition to the arcade stick state, each reading includes a timestamp that indicates precisely when the state was retrieved.</span></span> <span data-ttu-id="7fc0c-154">このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-154">The timestamp is useful for relating to the timing of previous readings or to the timing of the game simulation.</span></span>

### <a name="reading-the-buttons"></a><span data-ttu-id="7fc0c-155">ボタンの読み取り</span><span class="sxs-lookup"><span data-stu-id="7fc0c-155">Reading the buttons</span></span>

<span data-ttu-id="7fc0c-156">アーケード スティックのボタンの各&mdash;ジョイスティック、6 つの**アクション**ボタンと 2 つの**特別な**ボタンの 4 方向&mdash;かどうかが押さ (ダウン) か、離さ (アップ) を示すデジタルの読み取り値を提供します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-156">Each of the arcade stick buttons&mdash;the four directions of the joystick, six **Action** buttons, and two **Special** buttons&mdash;provides a digital reading that indicates whether it's pressed (down) or released (up).</span></span> <span data-ttu-id="7fc0c-157">効率、ボタンの読み取り値がない個別のブール値として表されます。代わりに、すべて豊富な[ArcadeStickButtons][]列挙型で表される単一のビット フィールドにします。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-157">For efficiency, button readings aren't represented as individual boolean values; instead, they're all packed into a single bitfield that's represented by the [ArcadeStickButtons][] enumeration.</span></span>

> [!NOTE]
> <span data-ttu-id="7fc0c-158">アーケード スティックには、**ビュー**と**メニュー**ボタンなどの UI ナビゲーション用に使用するボタンが装備されています。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-158">Arcade sticks are equipped with additional buttons used for UI navigation such as the **View** and **Menu** buttons.</span></span> <span data-ttu-id="7fc0c-159">これらのボタンは `ArcadeStickButtons` 列挙型には含まれず、UI ナビゲーション デバイスとしてアーケード スティックを利用する場合にしか、読み取られません。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-159">These buttons are not a part of the `ArcadeStickButtons` enumeration and can only be read by accessing the arcade stick as a UI navigation device.</span></span> <span data-ttu-id="7fc0c-160">詳しくは、「[UI ナビゲーション デバイス](ui-navigation-controller.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-160">For more information, see [UI Navigation Device](ui-navigation-controller.md).</span></span>

<span data-ttu-id="7fc0c-161">ボタンの値は、[ArcadeStickReading][] 構造体の `Buttons` プロパティから読み取ります。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-161">The button values are read from the `Buttons` property of the [ArcadeStickReading][] structure.</span></span> <span data-ttu-id="7fc0c-162">このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-162">Because this property is a bitfield, bitwise masking is used to isolate the value of the button that you're interested in.</span></span> <span data-ttu-id="7fc0c-163">対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-163">The button is pressed (down) when the corresponding bit is set; otherwise, it's released (up).</span></span>

<span data-ttu-id="7fc0c-164">次の例では、**アクション 1**ボタンが押されているかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-164">The following example determines whether the **Action 1** button is pressed.</span></span>

```cpp
if (ArcadeStickButtons::Action1 == (reading.Buttons & ArcadeStickButtons::Action1))
{
    // Action 1 is pressed
}
```

<span data-ttu-id="7fc0c-165">次の例では、**アクション 1**ボタンが離されたかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-165">The following example determines whether the **Action 1** button is released.</span></span>

```cpp
if (ArcadeStickButtons::None == (reading.Buttons & ArcadeStickButtons::Action1))
{
    // Action 1 is released (not pressed)
}
```

<span data-ttu-id="7fc0c-166">場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか &mdash; (一部が押されていて、一部が押されていない) を特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-166">Sometimes you might want to determine when a button transitions from pressed to released or released to pressed, whether multiple buttons are pressed or released, or if a set of buttons are arranged in a particular way&mdash;some pressed, some not.</span></span> <span data-ttu-id="7fc0c-167">これらの状態を検出する方法について詳しくは、「[Detecting button transitions (ボタンの移行の検出)](input-practices-for-games.md#detecting-button-transitions)」および「[Detecting complex button arrangements (複雑なボタンのパターンの検出)](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-167">For information on how to detect these conditions, see [Detecting button transitions](input-practices-for-games.md#detecting-button-transitions) and [Detecting complex button arrangements](input-practices-for-games.md#detecting-complex-button-arrangements).</span></span>

## <a name="run-the-inputinterfacing-sample"></a><span data-ttu-id="7fc0c-168">InputInterfacing サンプルの実行</span><span class="sxs-lookup"><span data-stu-id="7fc0c-168">Run the InputInterfacing sample</span></span>

<span data-ttu-id="7fc0c-169">[InputInterfacingUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) は、アーケード スティックと、種類の異なる入力デバイスとを組み合わせて使用する方法と、これらの入力デバイスが UI ナビゲーション コントローラーとしてどのように動作するかを示します。</span><span class="sxs-lookup"><span data-stu-id="7fc0c-169">The [InputInterfacingUWP sample _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) demonstrates how to use arcade sticks and different kinds of input devices in tandem, as well as how these input devices behave as UI navigation controllers.</span></span>

## <a name="see-also"></a><span data-ttu-id="7fc0c-170">参照</span><span class="sxs-lookup"><span data-stu-id="7fc0c-170">See also</span></span>

* [<span data-ttu-id="7fc0c-171">Windows.Gaming.Input.UINavigationController</span><span class="sxs-lookup"><span data-stu-id="7fc0c-171">Windows.Gaming.Input.UINavigationController</span></span>][]
* [<span data-ttu-id="7fc0c-172">Windows.Gaming.Input.IGameController</span><span class="sxs-lookup"><span data-stu-id="7fc0c-172">Windows.Gaming.Input.IGameController</span></span>][]
* [<span data-ttu-id="7fc0c-173">ゲームの入力プラクティス</span><span class="sxs-lookup"><span data-stu-id="7fc0c-173">Input practices for games</span></span>](input-practices-for-games.md)

[<span data-ttu-id="7fc0c-174">Windows.Gaming.Input</span><span class="sxs-lookup"><span data-stu-id="7fc0c-174">Windows.Gaming.Input</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.aspx
[<span data-ttu-id="7fc0c-175">Windows.Gaming.Input.IGameController</span><span class="sxs-lookup"><span data-stu-id="7fc0c-175">Windows.Gaming.Input.IGameController</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[<span data-ttu-id="7fc0c-176">Windows.Gaming.Input.UINavigationController</span><span class="sxs-lookup"><span data-stu-id="7fc0c-176">Windows.Gaming.Input.UINavigationController</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.aspx
[<span data-ttu-id="7fc0c-177">arcadestick</span><span class="sxs-lookup"><span data-stu-id="7fc0c-177">arcadestick</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.aspx
[arcadesticks]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadesticks.aspx
[arcadestickadded]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadestickadded.aspx
[arcadestickremoved]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadestickremoved.aspx
[<span data-ttu-id="7fc0c-178">getcurrentreading</span><span class="sxs-lookup"><span data-stu-id="7fc0c-178">getcurrentreading</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.getcurrentreading.aspx
[<span data-ttu-id="7fc0c-179">arcadestickreading</span><span class="sxs-lookup"><span data-stu-id="7fc0c-179">arcadestickreading</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestickreading.aspx
[<span data-ttu-id="7fc0c-180">arcadestickbuttons</span><span class="sxs-lookup"><span data-stu-id="7fc0c-180">arcadestickbuttons</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestickbuttons.aspx
