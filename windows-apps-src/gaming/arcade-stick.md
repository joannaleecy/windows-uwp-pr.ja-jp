---
author: mithom
title: アーケード スティック
description: アーケード スティックの検出と読み取りには、Windows.Gaming.Input アーケード スティック API を使用します。
ms.assetid: 2E52232F-3014-4C8C-B39D-FAC478BA3E01
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP、ゲーム、アーケード スティック、入力
ms.openlocfilehash: b0411dcf1fd75ec7dc31d29a39e95f5c26073953
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243278"
---
# <a name="arcade-stick"></a><span data-ttu-id="03a69-104">アーケード スティック</span><span class="sxs-lookup"><span data-stu-id="03a69-104">Arcade stick</span></span>

<span data-ttu-id="03a69-105">このページでは、[Windows.Gaming.Input.ArcadeStick][arcadestick] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One アーケード スティックを対象にしたプログラミングの基礎について説明します。</span><span class="sxs-lookup"><span data-stu-id="03a69-105">This page describes the basics of programming for Xbox One arcade sticks using [Windows.Gaming.Input.ArcadeStick][arcadestick] and related APIs for the Universal Windows Platform (UWP).</span></span>

<span data-ttu-id="03a69-106">ここでは、次の項目について紹介します。</span><span class="sxs-lookup"><span data-stu-id="03a69-106">By reading this page, you'll learn:</span></span>
* <span data-ttu-id="03a69-107">接続されているアーケード スティックとそのユーザーの一覧を収集する方法</span><span class="sxs-lookup"><span data-stu-id="03a69-107">how to gather a list of connected arcade sticks and their users</span></span>
* <span data-ttu-id="03a69-108">アーケード スティックが追加または削除されたことを検出する方法</span><span class="sxs-lookup"><span data-stu-id="03a69-108">how to detect that an arcade stick has been added or removed</span></span>
* <span data-ttu-id="03a69-109">1 つ以上のアーケード スティックの入力を読み取る方法</span><span class="sxs-lookup"><span data-stu-id="03a69-109">how to read input from one or more arcade sticks</span></span>
* <span data-ttu-id="03a69-110">ナビゲーション デバイスとしてのアーケード スティックの動作</span><span class="sxs-lookup"><span data-stu-id="03a69-110">how arcade sticks behave as a navigation device</span></span>


## <a name="arcade-stick-overview"></a><span data-ttu-id="03a69-111">アーケード スティックの概要</span><span class="sxs-lookup"><span data-stu-id="03a69-111">Arcade stick overview</span></span>

<span data-ttu-id="03a69-112">アーケード スティックは、店頭のアーケード マシンの雰囲気を再現し、デジタルにより高い精度で制御できる入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="03a69-112">Arcade sticks are input devices valued for reproducing the feel of stand-up arcade machines and for their high-precision digital controls.</span></span> <span data-ttu-id="03a69-113">アーケード スティックは、格闘ゲームなどのアーケード ゲームに最適な入力デバイスで、完全デジタル制御に対応しているあらゆるゲームに適しています。</span><span class="sxs-lookup"><span data-stu-id="03a69-113">Arcade sticks are the perfect input device for head-to-head-fighting and other arcade-style games, and are suitable for any game that works well with all-digital controls.</span></span> <span data-ttu-id="03a69-114">アーケード スティックは、Windows 10 および Xbox One UWP アプリで [Windows.Gaming.Input][] 名前空間によってサポートされています。</span><span class="sxs-lookup"><span data-stu-id="03a69-114">Arcade sticks are supported in Windows 10 and Xbox One UWP apps by the [Windows.Gaming.Input][] namespace.</span></span>

<span data-ttu-id="03a69-115">Xbox One アーケード スティックは、8 方向のデジタル ジョイスティック、6 個の**操作**ボタン、および 2 個の**特殊**ボタンを搭載しています。完全デジタル入力デバイスで、アナログ制御やバイブレーションはサポートしません。</span><span class="sxs-lookup"><span data-stu-id="03a69-115">Xbox One arcade sticks are equipped with an 8-way digital joystick, six **action** buttons, and two **special** buttons; they're all-digital input devices that don't support analog controls or vibration.</span></span> <span data-ttu-id="03a69-116">Xbox One アーケード スティックアーケード スティックには、UI 操作のサポートに使用する **ビュー** ボタンと**メニュー** ボタンも搭載されていますが、これらのボタンはゲームプレイ コマンドのサポートを意図したものではなく、ジョイスティック ボタンとしてすぐに利用できるものではありません。</span><span class="sxs-lookup"><span data-stu-id="03a69-116">Xbox One arcade sticks are also equipped with **view** and **menu** buttons used to support UI navigation but they're not intended to support gameplay commands and can't be readily accessed as joystick buttons.</span></span>

### <a name="ui-navigation"></a><span data-ttu-id="03a69-117">UI のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="03a69-117">UI navigation</span></span>

<span data-ttu-id="03a69-118">ユーザー インターフェイスの操作にさまざまな入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、ほとんどの物理__ 入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の論理__ 入力デバイスとして同時に機能します。</span><span class="sxs-lookup"><span data-stu-id="03a69-118">In order to ease the burden of supporting many different input devices for user interface navigation and to encourage consistency between games and devices, most _physical_ input devices simultaneously act as a separate _logical_ input device called a [UI navigation controller](ui-navigation-controller.md).</span></span> <span data-ttu-id="03a69-119">UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。</span><span class="sxs-lookup"><span data-stu-id="03a69-119">The UI navigation controller provides a common vocabulary for UI navigation commands across input devices.</span></span>

<span data-ttu-id="03a69-120">UI ナビゲーション コントローラーとして、アーケード スティックは、ナビゲーション コマンドの[必須セット](ui-navigation-controller.md#required-set)をジョイスティックと**ビュー** ボタン、**メニュー** ボタン、**アクション 1**  ボタン、および**アクション 2** ボタンにマップします。</span><span class="sxs-lookup"><span data-stu-id="03a69-120">As a UI navigation controller, arcade sticks map the [required set](ui-navigation-controller.md#required-set) of navigation commands to the joystick and **view**, **menu**, **action 1**, and **action 2** buttons.</span></span>

| <span data-ttu-id="03a69-121">ナビゲーション コマンド</span><span class="sxs-lookup"><span data-stu-id="03a69-121">Navigation command</span></span> | <span data-ttu-id="03a69-122">アーケード スティック入力</span><span class="sxs-lookup"><span data-stu-id="03a69-122">Arcade stick input</span></span>  |
| ------------------:| ------------------- |
|                 <span data-ttu-id="03a69-123">Up</span><span class="sxs-lookup"><span data-stu-id="03a69-123">Up</span></span> | <span data-ttu-id="03a69-124">スティックを上</span><span class="sxs-lookup"><span data-stu-id="03a69-124">Stick up</span></span>            |
|               <span data-ttu-id="03a69-125">Down</span><span class="sxs-lookup"><span data-stu-id="03a69-125">Down</span></span> | <span data-ttu-id="03a69-126">スティックを下</span><span class="sxs-lookup"><span data-stu-id="03a69-126">Stick down</span></span>          |
|               <span data-ttu-id="03a69-127">Left</span><span class="sxs-lookup"><span data-stu-id="03a69-127">Left</span></span> | <span data-ttu-id="03a69-128">スティックを左</span><span class="sxs-lookup"><span data-stu-id="03a69-128">Stick left</span></span>          |
|              <span data-ttu-id="03a69-129">Right</span><span class="sxs-lookup"><span data-stu-id="03a69-129">Right</span></span> | <span data-ttu-id="03a69-130">スティックを右</span><span class="sxs-lookup"><span data-stu-id="03a69-130">Stick right</span></span>         |
|               <span data-ttu-id="03a69-131">View</span><span class="sxs-lookup"><span data-stu-id="03a69-131">View</span></span> | <span data-ttu-id="03a69-132">ビュー ボタン</span><span class="sxs-lookup"><span data-stu-id="03a69-132">View button</span></span>         |
|               <span data-ttu-id="03a69-133">Menu</span><span class="sxs-lookup"><span data-stu-id="03a69-133">Menu</span></span> | <span data-ttu-id="03a69-134">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="03a69-134">Menu button</span></span>         |
|             <span data-ttu-id="03a69-135">Accept</span><span class="sxs-lookup"><span data-stu-id="03a69-135">Accept</span></span> | <span data-ttu-id="03a69-136">アクション 1 ボタン</span><span class="sxs-lookup"><span data-stu-id="03a69-136">Action 1 button</span></span>     |
|             <span data-ttu-id="03a69-137">Cancel</span><span class="sxs-lookup"><span data-stu-id="03a69-137">Cancel</span></span> | <span data-ttu-id="03a69-138">アクション 2 ボタン</span><span class="sxs-lookup"><span data-stu-id="03a69-138">Action 2 button</span></span>     |

<span data-ttu-id="03a69-139">アーケード スティックは、ナビゲーション コマンドの[オプション セット](ui-navigation-controller.md#optional-set)はマップしません。</span><span class="sxs-lookup"><span data-stu-id="03a69-139">Arcade sticks don't map any of the [optional set](ui-navigation-controller.md#optional-set) of navigation commands.</span></span>


## <a name="detect-and-track-arcade-sticks"></a><span data-ttu-id="03a69-140">アーケード スティックの検出と追跡</span><span class="sxs-lookup"><span data-stu-id="03a69-140">Detect and track arcade sticks</span></span>

<span data-ttu-id="03a69-141">アーケード スティックはシステムによって管理されるため、アーケード スティックを自分で作成したり初期化する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="03a69-141">Arcade sticks are managed by the system, therefore you don't have to create or initialize them.</span></span> <span data-ttu-id="03a69-142">接続されているアーケード スティックとイベントの一覧はシステムによって提供され、アーケード スティックが追加または削除されると通知されます。</span><span class="sxs-lookup"><span data-stu-id="03a69-142">The system provides a list of connected arcades sticks and events to notify you when an arcade stick is added or removed.</span></span>

### <a name="the-arcade-sticks-list"></a><span data-ttu-id="03a69-143">アーケード スティックの一覧</span><span class="sxs-lookup"><span data-stu-id="03a69-143">The arcade sticks list</span></span>

<span data-ttu-id="03a69-144">[ArcadeStick][] クラスには静的プロパティである [ArcadeStick][] が用意されています。これは、現在接続されているアーケード スティックの読み取り専用リストです。</span><span class="sxs-lookup"><span data-stu-id="03a69-144">The [ArcadeStick][] class provides a static property, [ArcadeSticks][], which is a read-only list of arcade sticks that are currently connected.</span></span> <span data-ttu-id="03a69-145">接続されているアーケード スティックの一部しか必要ない場合もあるため、`ArcadeSticks` プロパティを利用してデバイスにアクセスするのではなく、独自のコレクションを保持しておくことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="03a69-145">Because you might only be interested in some of the connected arcade sticks, its recommended that you maintain your own collection instead of accessing them through the `ArcadeSticks` property.</span></span>

<span data-ttu-id="03a69-146">次の例では、接続されているすべてのアーケード スティックを新しいコレクションにコピーします。</span><span class="sxs-lookup"><span data-stu-id="03a69-146">The following example copies all connected arcade sticks into a new collection.</span></span>
```cpp
auto myArcadeSticks = ref new Vector<ArcadeStick^>();

for (auto arcadestick : ArcadeStick::ArcadeSticks)
{
    // This code assumes that you're interested in all arcade sticks.
    myArcadeSticks->Append(arcadestick);
}
```

### <a name="adding-and-removing-arcade-sticks"></a><span data-ttu-id="03a69-147">アーケード スティックの追加と削除</span><span class="sxs-lookup"><span data-stu-id="03a69-147">Adding and removing arcade sticks</span></span>

<span data-ttu-id="03a69-148">アーケード スティックを追加または削除すると、[ArcadeStickAdded][] および [ArcadeStickRemoved][] イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="03a69-148">When an arcade stick is added or removed the [ArcadeStickAdded][] and [ArcadeStickRemoved][] events are raised.</span></span> <span data-ttu-id="03a69-149">これらのイベントのハンドラーを登録することで、現在接続されているアーケード スティックを追跡できます。</span><span class="sxs-lookup"><span data-stu-id="03a69-149">You can register handlers for these events to keep track of the arcade sticks that are currently connected.</span></span>

<span data-ttu-id="03a69-150">次の例では、追加されたアーケード スティックの追跡を開始します。</span><span class="sxs-lookup"><span data-stu-id="03a69-150">The following example starts tracking an arcade stick that's been added.</span></span>
```cpp
ArcadeStick::ArcadeStickAdded += ref new EventHandler<ArcadeStick^>(Platform::Object^, ArcadeStick^ args)
{
    // This code assumes that you're interested in all new arcade sticks.
    myArcadeSticks->Append(args);
}
```

<span data-ttu-id="03a69-151">次の例では、削除されたアーケード スティックの追跡を停止します。</span><span class="sxs-lookup"><span data-stu-id="03a69-151">The following example stops tracking an arcade stick that's been removed.</span></span>
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

### <a name="users-and-headsets"></a><span data-ttu-id="03a69-152">ユーザーとヘッドセット</span><span class="sxs-lookup"><span data-stu-id="03a69-152">Users and headsets</span></span>

<span data-ttu-id="03a69-153">各アーケード スティックは、ユーザー アカウントと関連付けることでユーザーの ID をユーザーのゲームプレイにリンクできます。また、ボイス チャットやゲーム内機能を円滑化するためにヘッドセットをアタッチすることもできます。</span><span class="sxs-lookup"><span data-stu-id="03a69-153">Each arcade stick can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features.</span></span> <span data-ttu-id="03a69-154">ユーザーとの連携およびヘッドセット操作について詳しくは、[ユーザーおよびそのデバイスの追跡](input-practices-for-games.md#tracking-users-and-their-devices)と、[ヘッドセット](headset.md)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03a69-154">To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md).</span></span>


## <a name="reading-the-arcade-stick"></a><span data-ttu-id="03a69-155">アーケード スティックの読み取り</span><span class="sxs-lookup"><span data-stu-id="03a69-155">Reading the arcade stick</span></span>

<span data-ttu-id="03a69-156">目的のアーケード スティックを特定したら、入力を収集する準備は完了です。</span><span class="sxs-lookup"><span data-stu-id="03a69-156">After you identify the arcade stick that you're interested in, you're ready to gather input from it.</span></span> <span data-ttu-id="03a69-157">ただし、なじみのある一部の他の種類の入力とは違い、アーケード スティックはイベントを発生することによって状態の変化を伝えるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="03a69-157">However, unlike some other kinds of input that you might be used to, arcade sticks don't communicate state-change by raising events.</span></span> <span data-ttu-id="03a69-158">代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="03a69-158">Instead, you take regular readings of their current state by _polling_ them.</span></span>

### <a name="polling-the-arcade-stick"></a><span data-ttu-id="03a69-159">アーケード スティックのポーリング</span><span class="sxs-lookup"><span data-stu-id="03a69-159">Polling the arcade stick</span></span>

<span data-ttu-id="03a69-160">ポーリングでは、明確な時点におけるアーケード スティックのスナップショットをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="03a69-160">Polling captures a snapshot of the arcade stick at a precise point in time.</span></span> <span data-ttu-id="03a69-161">入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="03a69-161">This approach to input gathering is a good fit for most games because their logic typically runs in a deterministic loop rather than being event-driven; its also typically simpler to interpret game commands from input gathered all at once than it is from many single inputs gathered over time.</span></span>

<span data-ttu-id="03a69-162">アーケード スティックをポーリングするには、[GetCurrentReading][] を呼び出します。この関数はアーケード スティックの状態が格納された [ArcadeStickReading][] を返します。</span><span class="sxs-lookup"><span data-stu-id="03a69-162">You poll an arcade stick by calling [GetCurrentReading][]; this function returns an [ArcadeStickReading][] that contains the state of the arcade stick.</span></span>

<span data-ttu-id="03a69-163">次の例では、アーケード スティックをポーリングして現在の状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="03a69-163">The following example polls an arcade stick for its current state.</span></span>
```cpp
auto arcadestick = myArcadeSticks[0];

ArcadeStickReading reading = arcadestick->GetCurrentReading();
```

<span data-ttu-id="03a69-164">読み取りデータには、アーケード スティックの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも含まれます。　</span><span class="sxs-lookup"><span data-stu-id="03a69-164">In addition to the arcade stick state, each reading includes a timestamp that indicates precisely when the state was retrieved.</span></span> <span data-ttu-id="03a69-165">このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。</span><span class="sxs-lookup"><span data-stu-id="03a69-165">The timestamp is useful for relating to the timing of previous readings or to the timing of the game simulation.</span></span>

### <a name="reading-the-buttons"></a><span data-ttu-id="03a69-166">ボタンの読み取り</span><span class="sxs-lookup"><span data-stu-id="03a69-166">Reading the buttons</span></span>

<span data-ttu-id="03a69-167">アーケード スティックの各ボタン (ジョイスティックの 4 方向、6 個の**操作**ボタン、2 個の**特殊**ボタン) は、デジタルの読み取り値によって、押されている (ダウン) か離されている (アップ) かを示します。</span><span class="sxs-lookup"><span data-stu-id="03a69-167">Each of the arcade stick buttons--the four directions of the joystick, six **action** buttons, and two **special** buttons--provide a digital reading that indicates whether its pressed (down), or released (up).</span></span> <span data-ttu-id="03a69-168">効率を高めるため、ボタンの読み取り値は個別のブール値としては表されません。代わりに、読み取り値はすべて、[ArcadeStickButtons][] 列挙型で表される単一のビットフィールドにパックされます。</span><span class="sxs-lookup"><span data-stu-id="03a69-168">For efficiency, button readings aren't represented as individual boolean values; instead they're all packed into a single bitfield that's represented by the [ArcadeStickButtons][] enumeration.</span></span>

> <span data-ttu-id="03a69-169">**注**    アーケード スティックには、**ビュー** ボタンや**メニュー** ボタンなど、他にも UI 操作に使用するボタンが搭載されています。</span><span class="sxs-lookup"><span data-stu-id="03a69-169">**Note**    Arcade sticks are equipped with additional buttons used for UI navigation such as the **view** and **menu** buttons.</span></span> <span data-ttu-id="03a69-170">これらのボタンは `ArcadeStickButtons` 列挙型には含まれず、UI ナビゲーション デバイスとしてアーケード スティックを利用する場合にしか、読み取られません。</span><span class="sxs-lookup"><span data-stu-id="03a69-170">These buttons are not a part of the `ArcadeStickButtons` enumeration and can only be read by accessing the arcade stick as a UI navigation device.</span></span> <span data-ttu-id="03a69-171">詳しくは、「[UI ナビゲーション デバイス](ui-navigation-controller.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03a69-171">For more information, see [UI Navigation Device](ui-navigation-controller.md).</span></span>

<span data-ttu-id="03a69-172">ボタンの値は、[ArcadeStickReading][] 構造体の `Buttons` プロパティから読み取ります。</span><span class="sxs-lookup"><span data-stu-id="03a69-172">The button values are read from the `Buttons` property of the [ArcadeStickReading][] structure.</span></span> <span data-ttu-id="03a69-173">このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。</span><span class="sxs-lookup"><span data-stu-id="03a69-173">Because this property is a bitfield, bitwise masking is used to isolate the value of the button that you're interested in.</span></span> <span data-ttu-id="03a69-174">対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。</span><span class="sxs-lookup"><span data-stu-id="03a69-174">The button is pressed (down) when the corresponding bit is set; otherwise its released (up).</span></span>

<span data-ttu-id="03a69-175">次の例では、アクション 1 ボタンが押されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="03a69-175">The following example determines whether the Action 1 button is pressed.</span></span>
```cpp
if (ArcadeStickButtons::Action1 == (reading.Buttons & ArcadeStickButtons::Action1))
{
    // Action 1 is pressed
}
```

<span data-ttu-id="03a69-176">次の例では、アクション 1 ボタンが離されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="03a69-176">The following example determines whether the Action 1 button is released.</span></span>
```cpp
if (ArcadeStickButtons::None == (reading.Buttons & ArcadeStickButtons::Action1))
{
    // Action 1 is released (not pressed)
}
```

<span data-ttu-id="03a69-177">場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか (一部が押されていて、一部が押されていない) を特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="03a69-177">Sometimes you might want to determine when a button transitions from pressed to released or released to pressed, whether multiple buttons are pressed or released, or if a set of buttons are arranged in a particular way--some pressed, some not.</span></span> <span data-ttu-id="03a69-178">これらの状態を検出する方法について詳しくは、「[Detecting button transitions (ボタンの移行の検出)](input-practices-for-games.md#detecting-button-transitions)」および「[Detecting complex button arrangements (複雑なボタンのパターンの検出)](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03a69-178">For information on how to detect these conditions, see [Detecting button transitions](input-practices-for-games.md#detecting-button-transitions) and [Detecting complex button arrangements](input-practices-for-games.md#detecting-complex-button-arrangements).</span></span>

## <a name="run-the-inputinterfacing-sample"></a><span data-ttu-id="03a69-179">InputInterfacing サンプルの実行</span><span class="sxs-lookup"><span data-stu-id="03a69-179">Run the InputInterfacing sample</span></span>

<span data-ttu-id="03a69-180">[InputInterfacingUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) は、アーケード スティックと、種類の異なる入力デバイスとを組み合わせて使用する方法と、これらの入力デバイスが UI ナビゲーション コントローラーとしてどのように動作するかを示します。</span><span class="sxs-lookup"><span data-stu-id="03a69-180">The [InputInterfacingUWP sample _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) demonstrates how to use arcade sticks and different kinds of input devices in tandem, as well as how these input devices behave as UI navigation controllers.</span></span>


## <a name="see-also"></a><span data-ttu-id="03a69-181">参照</span><span class="sxs-lookup"><span data-stu-id="03a69-181">See also</span></span>
<span data-ttu-id="03a69-182">[Windows.Gaming.Input.UINavigationController][]
[Windows.Gaming.Input.IGameController][]</span><span class="sxs-lookup"><span data-stu-id="03a69-182">[Windows.Gaming.Input.UINavigationController][]
[Windows.Gaming.Input.IGameController][]</span></span>

[<span data-ttu-id="03a69-183">Windows.Gaming.Input</span><span class="sxs-lookup"><span data-stu-id="03a69-183">Windows.Gaming.Input</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.aspx
[<span data-ttu-id="03a69-184">Windows.Gaming.Input.IGameController</span><span class="sxs-lookup"><span data-stu-id="03a69-184">Windows.Gaming.Input.IGameController</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[<span data-ttu-id="03a69-185">Windows.Gaming.Input.UINavigationController</span><span class="sxs-lookup"><span data-stu-id="03a69-185">Windows.Gaming.Input.UINavigationController</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.aspx
[<span data-ttu-id="03a69-186">arcadestick</span><span class="sxs-lookup"><span data-stu-id="03a69-186">arcadestick</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.aspx
[<span data-ttu-id="03a69-187">arcadesticks</span><span class="sxs-lookup"><span data-stu-id="03a69-187">arcadesticks</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadesticks.aspx
[<span data-ttu-id="03a69-188">arcadestickadded</span><span class="sxs-lookup"><span data-stu-id="03a69-188">arcadestickadded</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadestickadded.aspx
[<span data-ttu-id="03a69-189">arcadestickremoved</span><span class="sxs-lookup"><span data-stu-id="03a69-189">arcadestickremoved</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadestickremoved.aspx
[<span data-ttu-id="03a69-190">getcurrentreading</span><span class="sxs-lookup"><span data-stu-id="03a69-190">getcurrentreading</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.getcurrentreading.aspx
[<span data-ttu-id="03a69-191">arcadestickreading</span><span class="sxs-lookup"><span data-stu-id="03a69-191">arcadestickreading</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestickreading.aspx
[<span data-ttu-id="03a69-192">arcadestickbuttons</span><span class="sxs-lookup"><span data-stu-id="03a69-192">arcadestickbuttons</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestickbuttons.aspx
