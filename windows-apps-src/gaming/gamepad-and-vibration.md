---
title: ゲームパッドと振動
description: ゲームパッドの検出、読み取り、およびゲームパッドへの振動とリアル コマンドの送信には、Windows.Gaming.Input ゲームパッド API を使用します。
ms.assetid: BB03BB8E-255F-4AE8-AC43-1E519CA860FE
ms.date: 09/06/2018
ms.topic: article
keywords: Windows 10, UWP, ゲーム, ゲームパッド, 振動
ms.localizationpriority: medium
ms.openlocfilehash: e65b22039c381bd333516bd9f98c60bbddb9621c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646927"
---
# <a name="gamepad-and-vibration"></a><span data-ttu-id="177c8-104">ゲームパッドと振動</span><span class="sxs-lookup"><span data-stu-id="177c8-104">Gamepad and vibration</span></span>

<span data-ttu-id="177c8-105">このページでは、[Windows.Gaming.Input.Gamepad][gamepad] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One ゲームパッドを対象にしたプログラミングの基礎について説明します。</span><span class="sxs-lookup"><span data-stu-id="177c8-105">This page describes the basics of programming for Xbox One gamepads using [Windows.Gaming.Input.Gamepad][gamepad] and related APIs for the Universal Windows Platform (UWP).</span></span>

<span data-ttu-id="177c8-106">ここでは、次の項目について紹介します。</span><span class="sxs-lookup"><span data-stu-id="177c8-106">By reading this page, you'll learn:</span></span>

* <span data-ttu-id="177c8-107">接続されているゲームパッドとそのユーザーの一覧を収集する方法</span><span class="sxs-lookup"><span data-stu-id="177c8-107">how to gather a list of connected gamepads and their users</span></span>
* <span data-ttu-id="177c8-108">ゲームパッドが追加または削除されたことを検出する方法</span><span class="sxs-lookup"><span data-stu-id="177c8-108">how to detect that a gamepad has been added or removed</span></span>
* <span data-ttu-id="177c8-109">1 つ以上のゲームパッドの入力を読み取る方法</span><span class="sxs-lookup"><span data-stu-id="177c8-109">how to read input from one or more gamepads</span></span>
* <span data-ttu-id="177c8-110">振動とリアル コマンドを送信する方法</span><span class="sxs-lookup"><span data-stu-id="177c8-110">how to send vibration and impulse commands</span></span>
* <span data-ttu-id="177c8-111">ゲーム パッドを UI ナビゲーション デバイスとして動作する方法</span><span class="sxs-lookup"><span data-stu-id="177c8-111">how gamepads behave as UI navigation devices</span></span>

## <a name="gamepad-overview"></a><span data-ttu-id="177c8-112">ゲームパッドの概要</span><span class="sxs-lookup"><span data-stu-id="177c8-112">Gamepad overview</span></span>

<span data-ttu-id="177c8-113">Xbox ワイヤレス コントローラーや Xbox ワイヤレス コントローラー S などのゲームパッドは、汎用のゲーム入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="177c8-113">Gamepads like the Xbox Wireless Controller and Xbox Wireless Controller S are general-purpose gaming input devices.</span></span> <span data-ttu-id="177c8-114">ゲームパッドは Xbox One の標準入力デバイスです。一般的に、キーボードやマウスを好まない Windows のゲーマーが選びます。</span><span class="sxs-lookup"><span data-stu-id="177c8-114">They're the standard input device on Xbox One and a common choice for Windows gamers when they don't favor a keyboard and mouse.</span></span> <span data-ttu-id="177c8-115">ゲームパッドは、Windows 10 および Xbox UWP アプリで [Windows.Gaming.Input][] 名前空間によってサポートされています。</span><span class="sxs-lookup"><span data-stu-id="177c8-115">Gamepads are supported in Windows 10 and Xbox UWP apps by the [Windows.Gaming.Input][] namespace.</span></span>

<span data-ttu-id="177c8-116">Xbox One ゲームパッドかが装備、方向パッド (パッド);**A**、 **B**、 **X**、 **Y**、**ビュー**、および**メニュー**ボタンは左と右側のサムスティック、エンジン、およびトリガーです。4 つの振動モーターの合計。</span><span class="sxs-lookup"><span data-stu-id="177c8-116">Xbox One gamepads are equipped with a directional pad (or D-pad); **A**, **B**, **X**, **Y**, **View**, and **Menu** buttons; left and right thumbsticks, bumpers, and triggers; and a total of four vibration motors.</span></span> <span data-ttu-id="177c8-117">どちらのサムスティックも、X 軸と Y 軸のデュアル アナログの読み取り値を提供し、内側に押すとボタンとしても機能します。</span><span class="sxs-lookup"><span data-stu-id="177c8-117">Both thumbsticks provide dual analog readings in the X and Y axes, and also act as a button when pressed inward.</span></span> <span data-ttu-id="177c8-118">各トリガーでは、どの程度はプルバックを表すアナログの読み取りを提供します。</span><span class="sxs-lookup"><span data-stu-id="177c8-118">Each trigger provides an analog reading that represents how far it's pulled back.</span></span>

<!-- > [!NOTE]
> The Xbox Elite Wireless Controller is equipped with four additional **Paddle** buttons on its underside. These can be used to provide redundant access to game commands that are difficult to use together (such as the right thumbstick together with any of the **A**, **B**, **X**, or **Y** buttons) or to provide dedicated access to additional commands. -->

> [!NOTE]
> <span data-ttu-id="177c8-119">`Windows.Gaming.Input.Gamepad` Xbox 360 ゲーム パッド、Xbox One ゲームパッドの標準として同じコントロール レイアウトをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="177c8-119">`Windows.Gaming.Input.Gamepad` also supports Xbox 360 gamepads, which have the same control layout as standard Xbox One gamepads.</span></span>

### <a name="vibration-and-impulse-triggers"></a><span data-ttu-id="177c8-120">振動とリアル トリガー</span><span class="sxs-lookup"><span data-stu-id="177c8-120">Vibration and impulse triggers</span></span>

<span data-ttu-id="177c8-121">Xbox One ゲームパッドには、強弱のゲームパッドの振動を生むための独立した 2 つのモーターと、トリガーごとに鋭い振動を生む 2 つの専用のモーターがあります (この独自の機能のために、Xbox One ゲームパッドのトリガーは_リアル トリガー_と呼ばれています)。</span><span class="sxs-lookup"><span data-stu-id="177c8-121">Xbox One gamepads provide two independent motors for strong and subtle gamepad vibration as well as two dedicated motors for providing sharp vibration to each trigger (this unique feature is the reason that Xbox One gamepad triggers are referred to as _impulse triggers_).</span></span>

> [!NOTE]
> <span data-ttu-id="177c8-122">Xbox 360 のゲーム パッドが装備されていない_インパルス トリガー_します。</span><span class="sxs-lookup"><span data-stu-id="177c8-122">Xbox 360 gamepads are not equipped with _impulse triggers_.</span></span>

<span data-ttu-id="177c8-123">詳しくは、「[振動とリアル トリガーの概要](#vibration-and-impulse-triggers-overview)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="177c8-123">For more information, see [Vibration and impulse triggers overview](#vibration-and-impulse-triggers-overview).</span></span>

### <a name="thumbstick-deadzones"></a><span data-ttu-id="177c8-124">サムスティックのデッドゾーン</span><span class="sxs-lookup"><span data-stu-id="177c8-124">Thumbstick deadzones</span></span>

<span data-ttu-id="177c8-125">中央の位置で待機中のサムスティックは、常に安定してニュートラルな X 軸と Y 軸の読み取り値を生成することが理想的ですが、</span><span class="sxs-lookup"><span data-stu-id="177c8-125">A thumbstick at rest in the center position would ideally produce the same, neutral reading in the X and Y axes every time.</span></span> <span data-ttu-id="177c8-126">機械的な力とサムスティックの感度のために、中央の位置での実際の読み取り値は、理想的なニュートラルの値の近似値でしかなく、読み取りごとに異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="177c8-126">However, due to mechanical forces and the sensitivity of the thumbstick, actual readings in the center position only approximate the ideal neutral value and can vary between subsequent readings.</span></span> <span data-ttu-id="177c8-127">このため、小さなを常に使用する必要があります_デッドゾーン_&mdash;は無視されますが、理想的な中央の位置に近い値の範囲&mdash;を補正するため、製造の相違点、機械的な損傷では、またはその他の gamepad問題です。</span><span class="sxs-lookup"><span data-stu-id="177c8-127">For this reason, you must always use a small _deadzone_&mdash;a range of values near the ideal center position that are ignored&mdash;to compensate for manufacturing differences, mechanical wear, or other gamepad issues.</span></span>

<span data-ttu-id="177c8-128">デッドゾーンを大きくすることは、意図する入力と意図しない入力とを分ける簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="177c8-128">Larger deadzones offer a simple strategy for separating intentional input from unintentional input.</span></span>

<span data-ttu-id="177c8-129">詳しくは、「[サムスティックの読み取り](#reading-the-thumbsticks)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="177c8-129">For more information, see [Reading the thumbsticks](#reading-the-thumbsticks).</span></span>

### <a name="ui-navigation"></a><span data-ttu-id="177c8-130">UI のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="177c8-130">UI navigation</span></span>

<span data-ttu-id="177c8-131">ユーザー インターフェイスの操作に異なる入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、_ほとんどの物理_入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の論理_入力デバイスとして同時に機能します_。</span><span class="sxs-lookup"><span data-stu-id="177c8-131">In order to ease the burden of supporting the different input devices for user interface navigation and to encourage consistency between games and devices, most _physical_ input devices simultaneously act as a separate _logical_ input device called a [UI navigation controller](ui-navigation-controller.md).</span></span> <span data-ttu-id="177c8-132">UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。</span><span class="sxs-lookup"><span data-stu-id="177c8-132">The UI navigation controller provides a common vocabulary for UI navigation commands across input devices.</span></span>

<span data-ttu-id="177c8-133">ゲームパッドのマップを UI ナビゲーション コント ローラーとして、[セットに必要な](ui-navigation-controller.md#required-set)左のサムスティック、ナビゲーション コマンドのパッド、**ビュー**、**メニュー**、 **、** および**B**ボタン。</span><span class="sxs-lookup"><span data-stu-id="177c8-133">As a UI navigation controller, gamepads map the [required set](ui-navigation-controller.md#required-set) of navigation commands to the left thumbstick, D-pad, **View**, **Menu**, **A**, and **B** buttons.</span></span>

| <span data-ttu-id="177c8-134">ナビゲーション コマンド</span><span class="sxs-lookup"><span data-stu-id="177c8-134">Navigation command</span></span> | <span data-ttu-id="177c8-135">ゲームパッド入力</span><span class="sxs-lookup"><span data-stu-id="177c8-135">Gamepad input</span></span>                       |
| ------------------:| ----------------------------------- |
|                 <span data-ttu-id="177c8-136">Up</span><span class="sxs-lookup"><span data-stu-id="177c8-136">Up</span></span> | <span data-ttu-id="177c8-137">左スティックを上/方向パッドを上</span><span class="sxs-lookup"><span data-stu-id="177c8-137">Left thumbstick up / D-pad up</span></span>       |
|               <span data-ttu-id="177c8-138">Down</span><span class="sxs-lookup"><span data-stu-id="177c8-138">Down</span></span> | <span data-ttu-id="177c8-139">左スティックを下/方向パッドを下</span><span class="sxs-lookup"><span data-stu-id="177c8-139">Left thumbstick down / D-pad down</span></span>   |
|               <span data-ttu-id="177c8-140">Left</span><span class="sxs-lookup"><span data-stu-id="177c8-140">Left</span></span> | <span data-ttu-id="177c8-141">左スティックを左/方向パッドを左</span><span class="sxs-lookup"><span data-stu-id="177c8-141">Left thumbstick left / D-pad left</span></span>   |
|              <span data-ttu-id="177c8-142">右</span><span class="sxs-lookup"><span data-stu-id="177c8-142">Right</span></span> | <span data-ttu-id="177c8-143">左スティックを右/方向パッドを右</span><span class="sxs-lookup"><span data-stu-id="177c8-143">Left thumbstick right / D-pad right</span></span> |
|               <span data-ttu-id="177c8-144">ビュー</span><span class="sxs-lookup"><span data-stu-id="177c8-144">View</span></span> | <span data-ttu-id="177c8-145">表示ボタン</span><span class="sxs-lookup"><span data-stu-id="177c8-145">View button</span></span>                         |
|               <span data-ttu-id="177c8-146">Menu</span><span class="sxs-lookup"><span data-stu-id="177c8-146">Menu</span></span> | <span data-ttu-id="177c8-147">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="177c8-147">Menu button</span></span>                         |
|             <span data-ttu-id="177c8-148">OK</span><span class="sxs-lookup"><span data-stu-id="177c8-148">Accept</span></span> | <span data-ttu-id="177c8-149">A ボタン</span><span class="sxs-lookup"><span data-stu-id="177c8-149">A button</span></span>                            |
|             <span data-ttu-id="177c8-150">Cancel</span><span class="sxs-lookup"><span data-stu-id="177c8-150">Cancel</span></span> | <span data-ttu-id="177c8-151">B ボタン</span><span class="sxs-lookup"><span data-stu-id="177c8-151">B button</span></span>                            |

<span data-ttu-id="177c8-152">また、ゲームパッドはナビゲーション コマンドのすべての[オプション セット](ui-navigation-controller.md#optional-set)をその他の入力にマップします。</span><span class="sxs-lookup"><span data-stu-id="177c8-152">Additionally, gamepads map all of the [optional set](ui-navigation-controller.md#optional-set) of navigation commands to the remaining inputs.</span></span>

| <span data-ttu-id="177c8-153">ナビゲーション コマンド</span><span class="sxs-lookup"><span data-stu-id="177c8-153">Navigation command</span></span> | <span data-ttu-id="177c8-154">ゲームパッド入力</span><span class="sxs-lookup"><span data-stu-id="177c8-154">Gamepad input</span></span>          |
| ------------------:| ---------------------- |
|            <span data-ttu-id="177c8-155">PageUp</span><span class="sxs-lookup"><span data-stu-id="177c8-155">Page Up</span></span> | <span data-ttu-id="177c8-156">左トリガー</span><span class="sxs-lookup"><span data-stu-id="177c8-156">Left trigger</span></span>           |
|          <span data-ttu-id="177c8-157">PageDown</span><span class="sxs-lookup"><span data-stu-id="177c8-157">Page Down</span></span> | <span data-ttu-id="177c8-158">右トリガー</span><span class="sxs-lookup"><span data-stu-id="177c8-158">Right trigger</span></span>          |
|          <span data-ttu-id="177c8-159">Page Left</span><span class="sxs-lookup"><span data-stu-id="177c8-159">Page Left</span></span> | <span data-ttu-id="177c8-160">L ボタン</span><span class="sxs-lookup"><span data-stu-id="177c8-160">Left bumper</span></span>            |
|         <span data-ttu-id="177c8-161">Page Right</span><span class="sxs-lookup"><span data-stu-id="177c8-161">Page Right</span></span> | <span data-ttu-id="177c8-162">R ボタン</span><span class="sxs-lookup"><span data-stu-id="177c8-162">Right bumper</span></span>           |
|          <span data-ttu-id="177c8-163">Scroll Up</span><span class="sxs-lookup"><span data-stu-id="177c8-163">Scroll Up</span></span> | <span data-ttu-id="177c8-164">右スティックを上</span><span class="sxs-lookup"><span data-stu-id="177c8-164">Right thumbstick up</span></span>    |
|        <span data-ttu-id="177c8-165">Scroll Down</span><span class="sxs-lookup"><span data-stu-id="177c8-165">Scroll Down</span></span> | <span data-ttu-id="177c8-166">右スティックを下</span><span class="sxs-lookup"><span data-stu-id="177c8-166">Right thumbstick down</span></span>  |
|        <span data-ttu-id="177c8-167">Scroll Left</span><span class="sxs-lookup"><span data-stu-id="177c8-167">Scroll Left</span></span> | <span data-ttu-id="177c8-168">右スティックを左</span><span class="sxs-lookup"><span data-stu-id="177c8-168">Right thumbstick left</span></span>  |
|       <span data-ttu-id="177c8-169">Scroll Right</span><span class="sxs-lookup"><span data-stu-id="177c8-169">Scroll Right</span></span> | <span data-ttu-id="177c8-170">右スティックを右</span><span class="sxs-lookup"><span data-stu-id="177c8-170">Right thumbstick right</span></span> |
|          <span data-ttu-id="177c8-171">Context 1</span><span class="sxs-lookup"><span data-stu-id="177c8-171">Context 1</span></span> | <span data-ttu-id="177c8-172">X ボタン</span><span class="sxs-lookup"><span data-stu-id="177c8-172">X Button</span></span>               |
|          <span data-ttu-id="177c8-173">Context 2</span><span class="sxs-lookup"><span data-stu-id="177c8-173">Context 2</span></span> | <span data-ttu-id="177c8-174">Y ボタン</span><span class="sxs-lookup"><span data-stu-id="177c8-174">Y Button</span></span>               |
|          <span data-ttu-id="177c8-175">Context 3</span><span class="sxs-lookup"><span data-stu-id="177c8-175">Context 3</span></span> | <span data-ttu-id="177c8-176">左スティックを押す</span><span class="sxs-lookup"><span data-stu-id="177c8-176">Left thumbstick press</span></span>  |
|          <span data-ttu-id="177c8-177">Context 4</span><span class="sxs-lookup"><span data-stu-id="177c8-177">Context 4</span></span> | <span data-ttu-id="177c8-178">右スティックを押す</span><span class="sxs-lookup"><span data-stu-id="177c8-178">Right thumbstick press</span></span> |

## <a name="detect-and-track-gamepads"></a><span data-ttu-id="177c8-179">ゲームパッドの検出と追跡</span><span class="sxs-lookup"><span data-stu-id="177c8-179">Detect and track gamepads</span></span>

<span data-ttu-id="177c8-180">ゲームパッドはシステムによって管理されるため、ゲームパッドを自分で作成したり初期化する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="177c8-180">Gamepads are managed by the system, therefore you don't have to create or initialize them.</span></span> <span data-ttu-id="177c8-181">接続されているゲームパッドとイベントの一覧はシステムによって提供され、ゲームパッドが追加または削除されると通知されます。</span><span class="sxs-lookup"><span data-stu-id="177c8-181">The system provides a list of connected gamepads and events to notify you when a gamepad is added or removed.</span></span>

### <a name="the-gamepads-list"></a><span data-ttu-id="177c8-182">ゲームパッドの一覧</span><span class="sxs-lookup"><span data-stu-id="177c8-182">The gamepads list</span></span>

<span data-ttu-id="177c8-183">[Gamepad][] クラスには静的プロパティである [Gamepad][] が用意されています。これは、現在接続されているゲームパッドの読み取り専用リストです。</span><span class="sxs-lookup"><span data-stu-id="177c8-183">The [Gamepad][] class provides a static property, [Gamepads][], which is a read-only list of gamepads that are currently connected.</span></span> <span data-ttu-id="177c8-184">接続されているゲームパッドの一部に興味のみあります、ためには、通じてそれらへのアクセスではなく、独自のコレクションを管理することをお勧め、`Gamepads`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="177c8-184">Because you might only be interested in some of the connected gamepads, it's recommended that you maintain your own collection instead of accessing them through the `Gamepads` property.</span></span>

<span data-ttu-id="177c8-185">次の例では、接続されているすべてのゲームパッドを新しいコレクションにコピーします。</span><span class="sxs-lookup"><span data-stu-id="177c8-185">The following example copies all connected gamepads into a new collection.</span></span> <span data-ttu-id="177c8-186">バック グラウンドで他のスレッドがこのコレクションにアクセスするため (で、 [GamepadAdded][]と[GamepadRemoved][]イベント)、任意のコードを読み取るまたは更新プログラムに関するロックを配置する必要がある、コレクションです。</span><span class="sxs-lookup"><span data-stu-id="177c8-186">Note that because other threads in the background will be accessing this collection (in the [GamepadAdded][] and [GamepadRemoved][] events), you need to place a lock around any code that reads or updates the collection.</span></span>

```cpp
auto myGamepads = ref new Vector<Gamepad^>();
critical_section myLock{};

for (auto gamepad : Gamepad::Gamepads)
{
    // Check if the gamepad is already in myGamepads; if it isn't, add it.
    critical_section::scoped_lock lock{ myLock };
    auto it = std::find(begin(myGamepads), end(myGamepads), gamepad);

    if (it == end(myGamepads))
    {
        // This code assumes that you're interested in all gamepads.
        myGamepads->Append(gamepad);
    }
}
```

```cs
private readonly object myLock = new object();
private List<Gamepad> myGamepads = new List<Gamepad>();
private Gamepad mainGamepad;

private void GetGamepads()
{
    lock (myLock)
    {
        foreach (var gamepad in Gamepad.Gamepads)
        {
            // Check if the gamepad is already in myGamepads; if it isn't, add it.
            bool gamepadInList = myGamepads.Contains(gamepad);

            if (!gamepadInList)
            {
                // This code assumes that you're interested in all gamepads.
                myGamepads.Add(gamepad);
            }
        }
    }   
}
```

### <a name="adding-and-removing-gamepads"></a><span data-ttu-id="177c8-187">ゲームパッドの追加と削除</span><span class="sxs-lookup"><span data-stu-id="177c8-187">Adding and removing gamepads</span></span>

<span data-ttu-id="177c8-188">ゲームパッドを追加または削除されると、ときに、 [GamepadAdded][]と[GamepadRemoved][]イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="177c8-188">When a gamepad is added or removed, the [GamepadAdded][] and [GamepadRemoved][] events are raised.</span></span> <span data-ttu-id="177c8-189">これらのイベントハンドラーを登録することで、現在接続されているゲームパッドを追跡できます。</span><span class="sxs-lookup"><span data-stu-id="177c8-189">You can register handlers for these events to keep track of the gamepads that are currently connected.</span></span>

<span data-ttu-id="177c8-190">次の例では、追加されたゲームパッドの追跡を開始します。</span><span class="sxs-lookup"><span data-stu-id="177c8-190">The following example starts tracking a gamepad that's been added.</span></span>

```cpp
Gamepad::GamepadAdded += ref new EventHandler<Gamepad^>(Platform::Object^, Gamepad^ args)
{
    // Check if the just-added gamepad is already in myGamepads; if it isn't, add
    // it.
    critical_section::scoped_lock lock{ myLock };
    auto it = std::find(begin(myGamepads), end(myGamepads), args);

    if (it == end(myGamepads))
    {
        // This code assumes that you're interested in all new gamepads.
        myGamepads->Append(args);
    }
}
```

```cs
Gamepad.GamepadAdded += (object sender, Gamepad e) =>
{
    // Check if the just-added gamepad is already in myGamepads; if it isn't, add
    // it.
    lock (myLock)
    {
        bool gamepadInList = myGamepads.Contains(e);

        if (!gamepadInList)
        {
            myGamepads.Add(e);
        }
    }
};
```

<span data-ttu-id="177c8-191">次の例では、削除されているゲームパッドの追跡を停止します。</span><span class="sxs-lookup"><span data-stu-id="177c8-191">The following example stops tracking a gamepad that's been removed.</span></span> <span data-ttu-id="177c8-192">削除したときに追跡しているゲームパッドする動作を処理する必要もありますたとえば、このコードはのみ 1 つのゲーム パッドからの入力を追跡し、だけに設定`nullptr`が削除されたとき。</span><span class="sxs-lookup"><span data-stu-id="177c8-192">You'll also need to handle what happens to the gamepads that you're tracking when they're removed; for example, this code only tracks input from one gamepad, and simply sets it to `nullptr` when it's removed.</span></span> <span data-ttu-id="177c8-193">すべてのフレーム、ゲームパッドがアクティブである場合とどのゲームパッド コント ローラーの接続および切断されたときからの入力を収集する更新プログラムを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="177c8-193">You'll need to check every frame if your gamepad is active, and update which gamepad you're gathering input from when controllers are connected and disconnected.</span></span>

```cpp
Gamepad::GamepadRemoved += ref new EventHandler<Gamepad^>(Platform::Object^, Gamepad^ args)
{
    unsigned int indexRemoved;
    critical_section::scoped_lock lock{ myLock };

    if(myGamepads->IndexOf(args, &indexRemoved))
    {
        if (m_gamepad == myGamepads->GetAt(indexRemoved))
        {
            m_gamepad = nullptr;
        }

        myGamepads->RemoveAt(indexRemoved);
    }
}
```

```cs
Gamepad.GamepadRemoved += (object sender, Gamepad e) =>
{
    lock (myLock)
    {
        int indexRemoved = myGamepads.IndexOf(e);

        if (indexRemoved > -1)
        {
            if (mainGamepad == myGamepads[indexRemoved])
            {
                mainGamepad = null;
            }

            myGamepads.RemoveAt(indexRemoved);
        }
    }
};
```

<span data-ttu-id="177c8-194">参照してください[ゲームのプラクティスを入力](input-practices-for-games.md)詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="177c8-194">See [Input practices for games](input-practices-for-games.md) for more information.</span></span>

### <a name="users-and-headsets"></a><span data-ttu-id="177c8-195">ユーザーとヘッドセット</span><span class="sxs-lookup"><span data-stu-id="177c8-195">Users and headsets</span></span>

<span data-ttu-id="177c8-196">各ゲームパッドは、ユーザー アカウントと関連付けることでユーザーの ID をユーザーのゲームプレイにリンクできます。また、ボイス チャットやゲーム内機能を円滑化するためにヘッドセットをアタッチすることもできます。</span><span class="sxs-lookup"><span data-stu-id="177c8-196">Each gamepad can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features.</span></span> <span data-ttu-id="177c8-197">ユーザーとの連携およびヘッドセット操作について詳しくは、[ユーザーおよびそのデバイスの追跡](input-practices-for-games.md#tracking-users-and-their-devices)と、[ヘッドセット](headset.md)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="177c8-197">To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md).</span></span>

## <a name="reading-the-gamepad"></a><span data-ttu-id="177c8-198">ゲームパッドの読み取り</span><span class="sxs-lookup"><span data-stu-id="177c8-198">Reading the gamepad</span></span>

<span data-ttu-id="177c8-199">目的のゲームパッドを特定したら、入力を収集する準備は完了です。</span><span class="sxs-lookup"><span data-stu-id="177c8-199">After you identify the gamepad that you're interested in, you're ready to gather input from it.</span></span> <span data-ttu-id="177c8-200">ただし、なじみのある一部の他の種類の入力とは違い、ゲームパッドはイベントを発生することによって状態の変化を伝えるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="177c8-200">However, unlike some other kinds of input that you might be used to, gamepads don't communicate state-change by raising events.</span></span> <span data-ttu-id="177c8-201">代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="177c8-201">Instead, you take regular readings of their current state by _polling_ them.</span></span>

### <a name="polling-the-gamepad"></a><span data-ttu-id="177c8-202">ゲームパッドのポーリング</span><span class="sxs-lookup"><span data-stu-id="177c8-202">Polling the gamepad</span></span>

<span data-ttu-id="177c8-203">ポーリングでは、明確な時点におけるナビゲーション デバイスのスナップショットをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="177c8-203">Polling captures a snapshot of the navigation device at a precise point in time.</span></span> <span data-ttu-id="177c8-204">入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="177c8-204">This approach to input gathering is a good fit for most games because their logic typically runs in a deterministic loop rather than being event-driven; it's also typically simpler to interpret game commands from input gathered all at once than it is from many single inputs gathered over time.</span></span>

<span data-ttu-id="177c8-205">ゲームパッドをポーリングするには、[GetCurrentReading][] を呼び出します。この関数はゲームパッドの状態が格納された [GamepadReading][] を返します。</span><span class="sxs-lookup"><span data-stu-id="177c8-205">You poll a gamepad by calling [GetCurrentReading][]; this function returns a [GamepadReading][] that contains the state of the gamepad.</span></span>

<span data-ttu-id="177c8-206">次の例では、ゲームパッドをポーリングして現在の状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="177c8-206">The following example polls a gamepad for its current state.</span></span>

```cpp
auto gamepad = myGamepads[0];

GamepadReading reading = gamepad->GetCurrentReading();
```

```cs
Gamepad gamepad = myGamepads[0];

GamepadReading reading = gamepad.GetCurrentReading();
```

<span data-ttu-id="177c8-207">読み取りデータには、ゲームパッドの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも含まれます。　</span><span class="sxs-lookup"><span data-stu-id="177c8-207">In addition to the gamepad state, each reading includes a timestamp that indicates precisely when the state was retrieved.</span></span> <span data-ttu-id="177c8-208">このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。</span><span class="sxs-lookup"><span data-stu-id="177c8-208">The timestamp is useful for relating to the timing of previous readings or to the timing of the game simulation.</span></span>

### <a name="reading-the-thumbsticks"></a><span data-ttu-id="177c8-209">サムスティックの読み取り</span><span class="sxs-lookup"><span data-stu-id="177c8-209">Reading the thumbsticks</span></span>

<span data-ttu-id="177c8-210">各サムスティックは、X 軸と Y 軸で -1.0 ～ +1.0 のアナログの読み取り値を提供します。</span><span class="sxs-lookup"><span data-stu-id="177c8-210">Each thumbstick provides an analog reading between -1.0 and +1.0 in the X and Y axes.</span></span> <span data-ttu-id="177c8-211">X 軸では、-1.0 の値はサムスティックを最も左に移動した位置に対応し、+1.0 の値はサムスティックを最も右に移動した位置に対応します。</span><span class="sxs-lookup"><span data-stu-id="177c8-211">In the X axis, a value of -1.0 corresponds to the left-most thumbstick position; a value of +1.0 corresponds to right-most position.</span></span> <span data-ttu-id="177c8-212">Y 軸では、-1.0 の値はサムスティックを最も下に移動した位置に対応し、+1.0 の値はサムスティックを最も上に移動した位置に対応します。</span><span class="sxs-lookup"><span data-stu-id="177c8-212">In the Y axis, a value of -1.0 corresponds to the bottom-most thumbstick position; a value of +1.0 corresponds to the top-most position.</span></span> <span data-ttu-id="177c8-213">両方の軸で、値は約、後続の読み取り; の間、スティックは、中央の位置を変えるには、正確な値は 0.0 があってもこのバリエーションを緩和するための戦略は、このセクションで後で説明します。</span><span class="sxs-lookup"><span data-stu-id="177c8-213">In both axes, the value is approximately 0.0 when the stick is in the center position, but it's normal for the precise value to vary, even between subsequent readings; strategies for mitigating this variation are discussed later in this section.</span></span>

<span data-ttu-id="177c8-214">左のサムスティックの X 軸の値は、[GamepadReading][] 構造体の `LeftThumbstickX` プロパティから読み取られ、Y 軸の値は `LeftThumbstickY` プロパティから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="177c8-214">The value of the left thumbstick's X axis is read from the `LeftThumbstickX` property of the [GamepadReading][] structure; the value of the Y axis is read from the `LeftThumbstickY` property.</span></span> <span data-ttu-id="177c8-215">右のサムスティックの X 軸の値は、`RightThumbstickX` プロパティから読み取られ、Y 軸の値は `RightThumbstickY` プロパティから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="177c8-215">The value of the right thumbstick's X axis is read from the `RightThumbstickX` property; the value of the Y axis is read from the `RightThumbstickY` property.</span></span>

```cpp
float leftStickX = reading.LeftThumbstickX;   // returns a value between -1.0 and +1.0
float leftStickY = reading.LeftThumbstickY;   // returns a value between -1.0 and +1.0
float rightStickX = reading.RightThumbstickX; // returns a value between -1.0 and +1.0
float rightStickY = reading.RightThumbstickY; // returns a value between -1.0 and +1.0
```

```cs
double leftStickX = reading.LeftThumbstickX;   // returns a value between -1.0 and +1.0
double leftStickY = reading.LeftThumbstickY;   // returns a value between -1.0 and +1.0
double rightStickX = reading.RightThumbstickX; // returns a value between -1.0 and +1.0
double rightStickY = reading.RightThumbstickY; // returns a value between -1.0 and +1.0
```

<span data-ttu-id="177c8-216">サムスティックの値を読み取るとき、中央の位置で待機中のサムスティックの値は、一定してニュートラルの 0.0 にはなりません。サムスティックを動かし、中央の位置に戻るたびに、0.0 に近い値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="177c8-216">When reading the thumbstick values, you'll notice that they don't reliably produce a neutral reading of 0.0 when the thumbstick is at rest in the center position; instead, they'll produce different values near 0.0 each time the thumbstick is moved and returned to the center position.</span></span> <span data-ttu-id="177c8-217">このばらつきを少なくするために、小さな_デッドゾーン_を実装します。デッドゾーン+は、理想の中央の位置付近の、無視される範囲の値です。</span><span class="sxs-lookup"><span data-stu-id="177c8-217">To mitigate these variations, you can implement a small _deadzone_, which is a range of values near the ideal center position that are ignored.</span></span> <span data-ttu-id="177c8-218">デッドゾーンを実装する方法の 1 つは、サムスティックが中央から移動された距離を特定し、読み取り値が指定した距離以下の場合は無視することです。</span><span class="sxs-lookup"><span data-stu-id="177c8-218">One way to implement a deadzone is to determine how far from center the thumbstick has moved, and ignoring the readings that are nearer than some distance you choose.</span></span> <span data-ttu-id="177c8-219">おおよその距離を計算できます&mdash;スティックの測定値は基本的に、極座標、いない平面の値であるために、正確なことはありません&mdash;ピタゴラスの定理を使用するだけで。</span><span class="sxs-lookup"><span data-stu-id="177c8-219">You can compute the distance roughly&mdash;it's not exact because thumbstick readings are essentially polar, not planar, values&mdash;just by using the Pythagorean theorem.</span></span> <span data-ttu-id="177c8-220">これで、放射状のデッドゾーンが作られます。</span><span class="sxs-lookup"><span data-stu-id="177c8-220">This produces a radial deadzone.</span></span>

<span data-ttu-id="177c8-221">次の例は、ピタゴラスの定理を使った基本的な放射状のデッドゾーンを示しています。</span><span class="sxs-lookup"><span data-stu-id="177c8-221">The following example demonstrates a basic radial deadzone using the Pythagorean theorem.</span></span>

```cpp
float leftStickX = reading.LeftThumbstickX;   // returns a value between -1.0 and +1.0
float leftStickY = reading.LeftThumbstickY;   // returns a value between -1.0 and +1.0

// choose a deadzone -- readings inside this radius are ignored.
const float deadzoneRadius = 0.1;
const float deadzoneSquared = deadzoneRadius * deadzoneRadius;

// Pythagorean theorem -- for a right triangle, hypotenuse^2 = (opposite side)^2 + (adjacent side)^2
auto oppositeSquared = leftStickY * leftStickY;
auto adjacentSquared = leftStickX * leftStickX;

// accept and process input if true; otherwise, reject and ignore it.
if ((oppositeSquared + adjacentSquared) > deadzoneSquared)
{
    // input accepted, process it
}
```

```cs
double leftStickX = reading.LeftThumbstickX;   // returns a value between -1.0 and +1.0
double leftStickY = reading.LeftThumbstickY;   // returns a value between -1.0 and +1.0

// choose a deadzone -- readings inside this radius are ignored.
const double deadzoneRadius = 0.1;
const double deadzoneSquared = deadzoneRadius * deadzoneRadius;

// Pythagorean theorem -- for a right triangle, hypotenuse^2 = (opposite side)^2 + (adjacent side)^2
double oppositeSquared = leftStickY * leftStickY;
double adjacentSquared = leftStickX * leftStickX;

// accept and process input if true; otherwise, reject and ignore it.
if ((oppositeSquared + adjacentSquared) > deadzoneSquared)
{
    // input accepted, process it
}
```

<span data-ttu-id="177c8-222">各サムスティックは、内側に押すことでボタンとしても機能します。この入力の読み取りの詳細については、「[ボタンの読み取り](#reading-the-buttons)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="177c8-222">Each thumbstick also acts as a button when pressed inward; for more information on reading this input, see [Reading the buttons](#reading-the-buttons).</span></span>

### <a name="reading-the-triggers"></a><span data-ttu-id="177c8-223">トリガーの読み取り</span><span class="sxs-lookup"><span data-stu-id="177c8-223">Reading the triggers</span></span>

<span data-ttu-id="177c8-224">トリガーは、0.0 (完全に離された状態) ～ 1.0 (完全に押された状態) の浮動小数点値として表されます。</span><span class="sxs-lookup"><span data-stu-id="177c8-224">The triggers are represented as floating-point values between 0.0 (fully released) and 1.0 (fully depressed).</span></span> <span data-ttu-id="177c8-225">左のトリガーの値は、[GamepadReading][] 構造体の `LeftTrigger` プロパティから、右のトリガーの値は `RightTrigger` プロパティから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="177c8-225">The value of the left trigger is read from the `LeftTrigger` property of the [GamepadReading][] structure; the value of the right trigger is read from the `RightTrigger` property.</span></span>

```cpp
float leftTrigger  = reading.LeftTrigger;  // returns a value between 0.0 and 1.0
float rightTrigger = reading.RightTrigger; // returns a value between 0.0 and 1.0
```

```cs
double leftTrigger = reading.LeftTrigger;  // returns a value between 0.0 and 1.0
double rightTrigger = reading.RightTrigger; // returns a value between 0.0 and 1.0
```

### <a name="reading-the-buttons"></a><span data-ttu-id="177c8-226">ボタンの読み取り</span><span class="sxs-lookup"><span data-stu-id="177c8-226">Reading the buttons</span></span>

<span data-ttu-id="177c8-227">各ゲームパッド ボタン&mdash;4 つの方向パッド、左端と右端のエンジン、左および右のサムスティック キーを押して、 **A**、 **B**、 **X**、 **Y**、**ビュー**、および**メニュー**&mdash;(ダウン) 押されたまたは (up) をリリースしたかどうかを示すデジタル閲覧を提供します。</span><span class="sxs-lookup"><span data-stu-id="177c8-227">Each of the gamepad buttons&mdash;the four directions of the D-pad, left and right bumpers, left and right thumbstick press, **A**, **B**, **X**, **Y**, **View**, and **Menu**&mdash;provides a digital reading that indicates whether it's pressed (down) or released (up).</span></span> <span data-ttu-id="177c8-228">効率性、ボタンの測定値がない個々 のブール値として表されます。代わりに、すべて豊富で表される 1 つのビット フィールドに、 [GamepadButtons][]列挙体。</span><span class="sxs-lookup"><span data-stu-id="177c8-228">For efficiency, button readings aren't represented as individual boolean values; instead, they're all packed into a single bitfield that's represented by the [GamepadButtons][] enumeration.</span></span>

<!-- > [!NOTE]
> The Xbox Elite Wireless Controller is equipped with four additional **paddle** buttons on its underside. These buttons are also represented in the `GamepadButtons` enumeration and their values are read in the same way as the standard gamepad buttons. -->

<span data-ttu-id="177c8-229">ボタンの値は、[GamepadReading][] 構造体の `Buttons` プロパティから読み取ります。</span><span class="sxs-lookup"><span data-stu-id="177c8-229">The button values are read from the `Buttons` property of the [GamepadReading][] structure.</span></span> <span data-ttu-id="177c8-230">このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。</span><span class="sxs-lookup"><span data-stu-id="177c8-230">Because this property is a bitfield, bitwise masking is used to isolate the value of the button that you're interested in.</span></span> <span data-ttu-id="177c8-231">対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。</span><span class="sxs-lookup"><span data-stu-id="177c8-231">The button is pressed (down) when the corresponding bit is set; otherwise, it's released (up).</span></span>

<span data-ttu-id="177c8-232">次の例では、A ボタンが押されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="177c8-232">The following example determines whether the A button is pressed.</span></span>

```cpp
if (GamepadButtons::A == (reading.Buttons & GamepadButtons::A))
{
    // button A is pressed
}
```

```cs
if (GamepadButtons.A == (reading.Buttons & GamepadButtons.A))
{
    // button A is pressed
}
```

<span data-ttu-id="177c8-233">次の例では、A ボタンが離されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="177c8-233">The following example determines whether the A button is released.</span></span>

```cpp
if (GamepadButtons::None == (reading.Buttons & GamepadButtons::A))
{
    // button A is released
}
```

```cs
if (GamepadButtons.None == (reading.Buttons & GamepadButtons.A))
{
    // button A is released
}
```

<span data-ttu-id="177c8-234">たいことがありますから、ボタンが遷移するときに決定するリリースに押された状態または、複数のボタンが押された状態またはリリースされるかどうか、または特定の方法で一連のボタンが配置されている場合に押されたリリース&mdash;いくつか押すと、失敗します。</span><span class="sxs-lookup"><span data-stu-id="177c8-234">Sometimes you might want to determine when a button transitions from pressed to released or released to pressed, whether multiple buttons are pressed or released, or if a set of buttons is arranged in a particular way&mdash;some pressed, some not.</span></span> <span data-ttu-id="177c8-235">これらの各状態を検出する方法について詳しくは、「[ボタンの状態遷移の検出](input-practices-for-games.md#detecting-button-transitions)」および「[ボタンの複雑な配置の検出](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="177c8-235">For information on how to detect each of these conditions, see [Detecting button transitions](input-practices-for-games.md#detecting-button-transitions) and [Detecting complex button arrangements](input-practices-for-games.md#detecting-complex-button-arrangements).</span></span>

## <a name="run-the-gamepad-input-sample"></a><span data-ttu-id="177c8-236">ゲームパッド入力のサンプルの実行</span><span class="sxs-lookup"><span data-stu-id="177c8-236">Run the gamepad input sample</span></span>

<span data-ttu-id="177c8-237">[GamepadUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/System/GamepadUWP) は、ゲームパッドに接続して、その状態を読み取る方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="177c8-237">The [GamepadUWP sample _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/System/GamepadUWP) demonstrates how to connect to a gamepad and read its state.</span></span>

## <a name="vibration-and-impulse-triggers-overview"></a><span data-ttu-id="177c8-238">振動とリアル トリガーの概要</span><span class="sxs-lookup"><span data-stu-id="177c8-238">Vibration and impulse triggers overview</span></span>

<span data-ttu-id="177c8-239">ゲームパッド内の振動モーターは、触覚的なフィードバックをユーザーに提供することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="177c8-239">The vibration motors inside a gamepad are for providing tactile feedback to the user.</span></span> <span data-ttu-id="177c8-240">ゲームではこの機能を、より高い没入感を生み出す、状態情報 (ダメージを受けたなど) の伝達を助ける、重要なアイテムに近接信号を送るなど、クリエイティブな用途に利用します。</span><span class="sxs-lookup"><span data-stu-id="177c8-240">Games use this ability to create a greater sense of immersion, to help communicate status information (such as taking damage), to signal proximity to important objects, or for other creative uses.</span></span>

<span data-ttu-id="177c8-241">Xbox One ゲームパッドには、独立した振動モーターが合計 4 つ搭載されています。</span><span class="sxs-lookup"><span data-stu-id="177c8-241">Xbox One gamepads are equipped with a total of four independent vibration motors.</span></span> <span data-ttu-id="177c8-242">2 つは、ゲームパッドの本体にある大規模なモーター左側のモーター右モーター穏やかより微妙な振動を提供しますが、大まかな、高 amplitude の振動を提供します。</span><span class="sxs-lookup"><span data-stu-id="177c8-242">Two are large motors located in the gamepad body; the left motor provides rough, high-amplitude vibration, while the right motor provides gentler, more subtle vibration.</span></span> <span data-ttu-id="177c8-243">残り 2 つは小型のモーターで、各トリガー内に 1 つずつ組み込まれていて、トリガーを操作しているユーザーの指に直接、鋭い弾けるような振動を伝えます。Xbox One ゲームパッドのトリガーは、この独自の機能のために、_リアル トリガー_と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="177c8-243">The other two are small motors, one inside each trigger, that provide sharp bursts of vibration directly to the user's trigger fingers; this unique ability of the Xbox One gamepad is the reason its triggers are referred to as _impulse triggers_.</span></span> <span data-ttu-id="177c8-244">これらのモーターが協調することで、幅広い種類の触感を生成できます。</span><span class="sxs-lookup"><span data-stu-id="177c8-244">By orchestrating these motors together, a wide range of tactile sensations can be produced.</span></span>

## <a name="using-vibration-and-impulse"></a><span data-ttu-id="177c8-245">振動とリアル トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="177c8-245">Using vibration and impulse</span></span>

<span data-ttu-id="177c8-246">ゲームパッドの振動は、[Gamepad][] クラスの [Vibration][] プロパティによって制御されます。</span><span class="sxs-lookup"><span data-stu-id="177c8-246">Gamepad vibration is controlled through the [Vibration][] property of the [Gamepad][] class.</span></span> <span data-ttu-id="177c8-247">`Vibration` インスタンスである、 [GamepadVibration][]の 4 つの浮動小数点から成る構造では、ポイント値。 値は各、モーターのいずれかの濃度。</span><span class="sxs-lookup"><span data-stu-id="177c8-247">`Vibration` is an instance of the [GamepadVibration][] structure which is made up of four floating point values; each value represents the intensity of one of the motors.</span></span>

<span data-ttu-id="177c8-248">メンバー、`Gamepad.Vibration`プロパティを直接変更することができます、個別に初期化することをお勧め`GamepadVibration`値し、それをコピーするインスタンス、`Gamepad.Vibration`実際のモーターの強度を変更するプロパティ一度にすべて。</span><span class="sxs-lookup"><span data-stu-id="177c8-248">Although the members of the `Gamepad.Vibration` property can be modified directly, it's recommended that you initialize a separate `GamepadVibration` instance to the values you want, and then copy it into the `Gamepad.Vibration` property to change the actual motor intensities all at once.</span></span>

<span data-ttu-id="177c8-249">次の例は、モーターの強さを一度に変更する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="177c8-249">The following example demonstrates how to change the motor intensities all at once.</span></span>

```cpp
// get the first gamepad
Gamepad^ gamepad = Gamepad::Gamepads->GetAt(0);

// create an instance of GamepadVibration
GamepadVibration vibration;

// ... set vibration levels on vibration struct here

// copy the GamepadVibration struct to the gamepad
gamepad.Vibration = vibration;
```

```cs
// get the first gamepad
Gamepad gamepad = Gamepad.Gamepads[0];

// create an instance of GamepadVibration
GamepadVibration vibration = new GamepadVibration();

// ... set vibration levels on vibration struct here

// copy the GamepadVibration struct to the gamepad
gamepad.Vibration = vibration;
```

### <a name="using-the-vibration-motors"></a><span data-ttu-id="177c8-250">振動モーターの使用</span><span class="sxs-lookup"><span data-stu-id="177c8-250">Using the vibration motors</span></span>

<span data-ttu-id="177c8-251">左右の振動モーターの値は、0.0 (振動なし) ～ 1.0 (最も強い振動) の浮動小数点値になります。</span><span class="sxs-lookup"><span data-stu-id="177c8-251">The left and right vibration motors take floating point values between 0.0 (no vibration) and 1.0 (most intense vibration).</span></span> <span data-ttu-id="177c8-252">左のモーターの強さは、[GamepadVibration][] 構造体の `LeftMotor` プロパティによって設定され、右のモーターの強さは `RightMotor` プロパティによって設定されます。</span><span class="sxs-lookup"><span data-stu-id="177c8-252">The intensity of the left motor is set by the `LeftMotor` property of the [GamepadVibration][] structure; the intensity of the right motor is set by the `RightMotor` property.</span></span>

<span data-ttu-id="177c8-253">次の例では両方の振動モーターの強さを設定し、ゲームパッドの振動を有効にします。</span><span class="sxs-lookup"><span data-stu-id="177c8-253">The following example sets the intensity of both vibration motors and activates gamepad vibration.</span></span>

```cpp
GamepadVibration vibration;
vibration.LeftMotor = 0.80;  // sets the intensity of the left motor to 80%
vibration.RightMotor = 0.25; // sets the intensity of the right motor to 25%
gamepad.Vibration = vibration;
```

```cs
GamepadVibration vibration = new GamepadVibration();
vibration.LeftMotor = 0.80;  // sets the intensity of the left motor to 80%
vibration.RightMotor = 0.25; // sets the intensity of the right motor to 25%
mainGamepad.Vibration = vibration;
```

<span data-ttu-id="177c8-254">この 2 つのモーターは同じではないため、これらのプロパティを同じ値に設定しても、一方のモーターともう一方のモーターの振動は同じになりません。</span><span class="sxs-lookup"><span data-stu-id="177c8-254">Remember that these two motors are not identical so setting these properties to the same value doesn't produce the same vibration in one motor as in the other.</span></span> <span data-ttu-id="177c8-255">左側のモーター、任意の値の右側モーターをより強力な振動低い頻度でが生成&mdash;、同じ値の&mdash;より高い頻度で穏やか振動を生成します。</span><span class="sxs-lookup"><span data-stu-id="177c8-255">For any value, the left motor produces a stronger vibration at a lower frequency than the right motor which&mdash;for the same value&mdash;produces a gentler vibration at a higher frequency.</span></span> <span data-ttu-id="177c8-256">最大値でも、左のモーターでは右のモーターと同じ高い周波数を生成することはできず、右のモーターは左のモーターほど強い力を生み出すことはできません。</span><span class="sxs-lookup"><span data-stu-id="177c8-256">Even at the maximum value, the left motor can't produce the high frequencies of the right motor, nor can the right motor produce the high forces of the left motor.</span></span> <span data-ttu-id="177c8-257">ただし、これらのモーターはゲームパッドの本体によってしっかりと連結しているため、各モーターの特徴は異なり、振動の強度が異なる場合でも、プレイヤーがそれぞれの振動を完全に分けて感じることはありません。</span><span class="sxs-lookup"><span data-stu-id="177c8-257">Still, because the motors are rigidly connected by the gamepad body, players don't experience the vibrations fully independently even though the motors have different characteristics and can vibrate with different intensities.</span></span> <span data-ttu-id="177c8-258">このアレンジによって、モーターがまったく同じ場合よりも、より幅広く表現豊かに触感を生み出すことができます。</span><span class="sxs-lookup"><span data-stu-id="177c8-258">This arrangement allows for a wider, more expressive range of sensations to be produced than if the motors were identical.</span></span>

### <a name="using-the-impulse-triggers"></a><span data-ttu-id="177c8-259">リアル トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="177c8-259">Using the impulse triggers</span></span>

<span data-ttu-id="177c8-260">各リアル トリガーのモーターの値は、0.0 (振動なし) ～ 1.0 (最も強い振動) の浮動小数点値になります。</span><span class="sxs-lookup"><span data-stu-id="177c8-260">Each impulse trigger motor takes a floating point value between 0.0 (no vibration) and 1.0 (most intense vibration).</span></span> <span data-ttu-id="177c8-261">左のトリガー モーターの強さは、[GamepadVibration][] 構造体の `LeftTrigger` プロパティによって設定され、右のトリガー の強さは `RightTrigger` プロパティによって設定されます。</span><span class="sxs-lookup"><span data-stu-id="177c8-261">The intensity of the left trigger motor is set by the `LeftTrigger` property of the [GamepadVibration][] structure; the intensity of the right trigger is set by the `RightTrigger` property.</span></span>

<span data-ttu-id="177c8-262">次の例では両方のリアル トリガーの強さを設定し、有効にします。</span><span class="sxs-lookup"><span data-stu-id="177c8-262">The following example sets intensity of both impulse triggers and activates them.</span></span>

```cpp
GamepadVibration vibration;
vibration.LeftTrigger = 0.75;  // sets the intensity of the left trigger to 75%
vibration.RightTrigger = 0.50; // sets the intensity of the right trigger to 50%
gamepad.Vibration = vibration;
```

```cs
GamepadVibration vibration = new GamepadVibration();
vibration.LeftTrigger = 0.75;  // sets the intensity of the left trigger to 75%
vibration.RightTrigger = 0.50; // sets the intensity of the right trigger to 50%
mainGamepad.Vibration = vibration;
```

<span data-ttu-id="177c8-263">本体のモーターと異なり、トリガー内のこの 2 つの振動モーターは同じであるため、同じ値を設定すると、どちらのモーターでも同じ振動が生成されます。</span><span class="sxs-lookup"><span data-stu-id="177c8-263">Unlike the others, the two vibration motors inside the triggers are identical so they produce the same vibration in either motor for the same value.</span></span> <span data-ttu-id="177c8-264">ただし、これらのモーターは何らかの形で強く連結されてはいないため、プレイヤーは振動を個別に感じます。</span><span class="sxs-lookup"><span data-stu-id="177c8-264">However, because these motors are not rigidly connected in any way, players experience the vibrations independently.</span></span> <span data-ttu-id="177c8-265">このアレンジでは、完全に独立した感覚を両方のトリガーに提供することができ、ゲームパッド本体のモーターよりも、個別の情報を伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="177c8-265">This arrangement allows for fully independent sensations to be directed to both triggers simultaneously, and helps them to convey more specific information than the motors in the gamepad body can.</span></span>

## <a name="run-the-gamepad-vibration-sample"></a><span data-ttu-id="177c8-266">ゲームパッドの振動のサンプルの実行</span><span class="sxs-lookup"><span data-stu-id="177c8-266">Run the gamepad vibration sample</span></span>

<span data-ttu-id="177c8-267">[GamepadVibrationUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/System/GamepadVibrationUWP) では、ゲームパッドの振動モーターとリアル トリガーを使用して、さまざまな効果を生む方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="177c8-267">The [GamepadVibrationUWP sample _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/System/GamepadVibrationUWP) demonstrates how the gamepad vibration motors and impulse triggers are used to produce a variety of effects.</span></span>

## <a name="see-also"></a><span data-ttu-id="177c8-268">関連項目</span><span class="sxs-lookup"><span data-stu-id="177c8-268">See also</span></span>

* <span data-ttu-id="177c8-269">[Windows.Gaming.Input.UINavigationController][]</span><span class="sxs-lookup"><span data-stu-id="177c8-269">[Windows.Gaming.Input.UINavigationController][]</span></span>
* <span data-ttu-id="177c8-270">[Windows.Gaming.Input.IGameController][]</span><span class="sxs-lookup"><span data-stu-id="177c8-270">[Windows.Gaming.Input.IGameController][]</span></span>
* [<span data-ttu-id="177c8-271">ゲームの入力のプラクティス</span><span class="sxs-lookup"><span data-stu-id="177c8-271">Input practices for games</span></span>](input-practices-for-games.md)

[Windows.Gaming.Input]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.aspx
[Windows.Gaming.Input.UINavigationController]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.aspx
[Windows.Gaming.Input.IGameController]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[gamepad]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.aspx
[Gamepad]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.gamepads.aspx
[gamepads]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.gamepads.aspx
[gamepadadded]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.gamepadadded.aspx
[gamepadremoved]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.gamepadremoved.aspx
[getcurrentreading]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.getcurrentreading.aspx
[vibration]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.vibration.aspx
[gamepadreading]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepadreading.aspx
[gamepadbuttons]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepadbuttons.aspx
[gamepadvibration]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepadvibration.aspx
