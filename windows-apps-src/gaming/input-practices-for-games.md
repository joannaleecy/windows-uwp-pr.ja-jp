---
author: eliotcowley
title: ゲームの入力プラクティス
description: 入力デバイスを効果的に使用するためのパターンと手法について説明します。
ms.assetid: CBAD3345-3333-4924-B6D8-705279F52676
ms.author: elcowle
ms.date: 11/20/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力
ms.localizationpriority: medium
ms.openlocfilehash: ed0d611c761315e42decb89e1a5a5ad84f4b067a
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6843518"
---
# <a name="input-practices-for-games"></a><span data-ttu-id="450fc-104">ゲームの入力プラクティス</span><span class="sxs-lookup"><span data-stu-id="450fc-104">Input practices for games</span></span>

<span data-ttu-id="450fc-105">このページでは、ユニバーサル Windows プラットフォーム (UWP) ゲームで入力デバイスを効果的に使用するためのパターンと手法について説明します。</span><span class="sxs-lookup"><span data-stu-id="450fc-105">This page describes patterns and techniques for effectively using input devices in Universal Windows Platform (UWP) games.</span></span>

<span data-ttu-id="450fc-106">このページでは、次のことを解説します。</span><span class="sxs-lookup"><span data-stu-id="450fc-106">By reading this page, you'll learn:</span></span>

* <span data-ttu-id="450fc-107">プレイヤーと、そのプレイヤーが現在使用中の入力デバイスとナビゲーション デバイスを追跡する方法</span><span class="sxs-lookup"><span data-stu-id="450fc-107">how to track players and which input and navigation devices they're currently using</span></span>
* <span data-ttu-id="450fc-108">ボタンの状態遷移 (押してから離す、離してから押す) を検出する方法</span><span class="sxs-lookup"><span data-stu-id="450fc-108">how to detect button transitions (pressed-to-released, released-to-pressed)</span></span>
* <span data-ttu-id="450fc-109">1 回のテストでボタンの複雑な配置を検出する方法</span><span class="sxs-lookup"><span data-stu-id="450fc-109">how to detect complex button arrangements with a single test</span></span>

## <a name="choosing-an-input-device-class"></a><span data-ttu-id="450fc-110">入力デバイス クラスの選択</span><span class="sxs-lookup"><span data-stu-id="450fc-110">Choosing an input device class</span></span>

<span data-ttu-id="450fc-111">利用できる入力 API には、[ArcadeStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick)、[FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick)、[Gamepad](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad) など多くの種類が存在します。</span><span class="sxs-lookup"><span data-stu-id="450fc-111">There are many different types of input APIs available to you, such as [ArcadeStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick), [FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick), and [Gamepad](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad).</span></span> <span data-ttu-id="450fc-112">ゲームに使用する API をどのように決定すればよいのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="450fc-112">How do you decide which API to use for your game?</span></span>

<span data-ttu-id="450fc-113">ゲームに最も適切な入力を提供する API 選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-113">You should choose whichever API gives you the most appropriate input for your game.</span></span> <span data-ttu-id="450fc-114">たとえば、2D プラットフォームのゲームを作成する場合は、通常、**Gamepad** クラスを使用するだけで対応でき、その他のクラスで利用可能な追加機能を使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="450fc-114">For example, if you're making a 2D platform game, you can probably just use the **Gamepad** class and not bother with the extra functionality available via other classes.</span></span> <span data-ttu-id="450fc-115">このクラスは、ゲームのサポートをゲームパッドのみに制限し、コードを追加することなく、多くの異なるゲームパッドで動作する一貫したインターフェイスを提供します。</span><span class="sxs-lookup"><span data-stu-id="450fc-115">This would restrict the game to supporting gamepads only and provide a consistent interface that will work across many different gamepads with no need for additional code.</span></span>

<span data-ttu-id="450fc-116">その一方で、複雑なフライトやレーシングのシミュレーションでは、すべての [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) オブジェクトを基準として列挙し、熱心なプレイヤーが所有しているあらゆるニッチ デバイス (シングル プレイヤー用の独立したペダルやスロットルなどのデバイス) を確実にサポートできます。</span><span class="sxs-lookup"><span data-stu-id="450fc-116">On the other hand, for complex flight and racing simulations, you might want to enumerate all of the [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) objects as a baseline to make sure they support any niche device that enthusiast players might have, including devices such as separate pedals or throttle that are still used by a single player.</span></span> 

<span data-ttu-id="450fc-117">そこから、入力クラスの **FromGameController** メソッド ([Gamepad.FromGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.fromgamecontroller) など) を使用して、各デバイスが整理されたビューが表示するかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="450fc-117">From there, you can use an input class's **FromGameController** method, such as [Gamepad.FromGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.fromgamecontroller), to see if each device has a more curated view.</span></span> <span data-ttu-id="450fc-118">たとえば、デバイスが **Gamepad** でもある場合、それを反映するようにボタン マッピング UI を調整し、選択可能ないくつかの適切な既定のボタン マッピングを提供できます </span><span class="sxs-lookup"><span data-stu-id="450fc-118">For example, if the device is also a **Gamepad**, then you might want to adjust the button mapping UI to reflect that, and provide some sensible default button mappings to choose from.</span></span> <span data-ttu-id="450fc-119">(これは、**RawGameController** のみを使用している場合、プレイヤーがゲームパッド入力を手動で構成することが必要になるのとは対照的です)。</span><span class="sxs-lookup"><span data-stu-id="450fc-119">(This is in contrast to requiring the player to manually configure the gamepad inputs if you're only using **RawGameController**.)</span></span> 

<span data-ttu-id="450fc-120">代わりに、**RawGameController** のベンダー ID (VID) と製品 ID (PID) を参照し (それぞれ [HardwareVendorId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareVendorId) と [HardwareProductId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareProductId) を使用)、一般的なデバイスの推奨されるボタン マッピングを提供できます。その一方で、プレイヤーが手動でマッピングすることにより将来の未知のデバイスとの互換性を維持できます。</span><span class="sxs-lookup"><span data-stu-id="450fc-120">Alternatively, you can look at the vendor ID (VID) and product ID (PID) of a **RawGameController** (using [HardwareVendorId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareVendorId) and [HardwareProductId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareProductId), respectively) and provide suggested button mappings for popular devices while still remaining compatible with unknown devices that come out in the future via manual mappings by the player.</span></span>

## <a name="keeping-track-of-connected-controllers"></a><span data-ttu-id="450fc-121">接続されているコントローラーの追跡</span><span class="sxs-lookup"><span data-stu-id="450fc-121">Keeping track of connected controllers</span></span>

<span data-ttu-id="450fc-122">各コントローラーの型には、接続されているコントローラーのリスト ([Gamepad.Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.Gamepads) など) が含まれていますが、独自のコントローラーのリストを保持することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="450fc-122">While each controller type includes a list of connected controllers (such as [Gamepad.Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.Gamepads)), it is a good idea to maintain your own list of controllers.</span></span> <span data-ttu-id="450fc-123">詳細については、「[ゲームパッドの一覧](gamepad-and-vibration.md#the-gamepads-list)」を参照してください (各コントローラーの型には、それぞれのトピックに類似する名前のセクションがあります)。</span><span class="sxs-lookup"><span data-stu-id="450fc-123">See [The gamepads list](gamepad-and-vibration.md#the-gamepads-list) for more information (each controller type has a similarly named section on its own topic).</span></span>

<span data-ttu-id="450fc-124">それでは、プレイヤーがコントローラーを取り外した場合や、新しいコントローラーを接続した場合は、どうなるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="450fc-124">However, what happens when the player unplugs their controller, or plugs in a new one?</span></span> <span data-ttu-id="450fc-125">これらのイベントを処理し、リストを適宜更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-125">You need to handle these events, and update your list accordingly.</span></span> <span data-ttu-id="450fc-126">詳細については、「[ゲームパッドの追加と削除](gamepad-and-vibration.md#adding-and-removing-gamepads)」を参照してください (ここでも、各コントローラーの型には、それぞれのトピックに類似する名前のセクションがあります)。</span><span class="sxs-lookup"><span data-stu-id="450fc-126">See [Adding and removing gamepads](gamepad-and-vibration.md#adding-and-removing-gamepads) for more information (again, each controller type has a similarly named section on its own topic).</span></span>

<span data-ttu-id="450fc-127">追加および削除のイベントは非同期的に発生するため、コントローラーの一覧を処理するときに誤った結果を取得する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-127">Because the added and removed events are raised asynchronously, you could get incorrect results when dealing with your list of controllers.</span></span> <span data-ttu-id="450fc-128">そのため、コントローラーのリストにアクセスするときは、常に、一度に 1 つのスレッドのみがリストにアクセスできるようにその周囲にロックを配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-128">Therefore, anytime you access your list of controllers, you should put a lock around it so that only one thread can access it at a time.</span></span> <span data-ttu-id="450fc-129">この処理は、**&lt;ppl.h&gt;** の[同時実行ランタイム](https://docs.microsoft.com/cpp/parallel/concrt/concurrency-runtime)、具体的には、[critical_section クラス](https://docs.microsoft.com/cpp/parallel/concrt/reference/critical-section-class)で行うことができます。</span><span class="sxs-lookup"><span data-stu-id="450fc-129">This can be done with the [Concurrency Runtime](https://docs.microsoft.com/cpp/parallel/concrt/concurrency-runtime), specifically the [critical_section class](https://docs.microsoft.com/cpp/parallel/concrt/reference/critical-section-class), in **&lt;ppl.h&gt;**.</span></span>

<span data-ttu-id="450fc-130">もう 1 つ考慮しなければならないのは、接続されているコントローラーのリストは最初は空であり、設定されるのに 1、2 秒かかるという点です。</span><span class="sxs-lookup"><span data-stu-id="450fc-130">Another thing to think about is that the list of connected controllers will initially be empty, and takes a second or two to populate.</span></span> <span data-ttu-id="450fc-131">start メソッドで、現在のゲームパッドを割り当てるだけでは、**null** になります。</span><span class="sxs-lookup"><span data-stu-id="450fc-131">So if you only assign the current gamepad in the start method, it will be **null**!</span></span>

<span data-ttu-id="450fc-132">この問題を解決するには、メイン ゲームパッドを "更新する" メソッドが必要です (シングル プレイヤー ゲームの場合。マルチプレイヤー ゲームではさらに高度な解決策が必要になります)。</span><span class="sxs-lookup"><span data-stu-id="450fc-132">To rectify this, you should have a method that "refreshes" the main gamepad (in a single-player game; multiplayer games will require more sophisticated solutions).</span></span> <span data-ttu-id="450fc-133">コントローラーの追加とコントローラーの削除の両方のイベント ハンドラー、または update メソッドで、このメソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-133">You should then call this method in both your controller added and controller removed event handlers, or in your update method.</span></span>

<span data-ttu-id="450fc-134">次のメソッドは、単にリストの最初のゲームパッド (またはリストが空の場合は **nullptr**) を返します。</span><span class="sxs-lookup"><span data-stu-id="450fc-134">The following method simply returns the first gamepad in the list (or **nullptr** if the list is empty).</span></span> <span data-ttu-id="450fc-135">したがって、コントローラーについて何か処理をする場合は、常に **nullptr** かどうかを確認することを忘れないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-135">Then you just need to remember to check for **nullptr** anytime you do anything with the controller.</span></span> <span data-ttu-id="450fc-136">コントローラーが接続されていない場合にゲームプレイをブロックする (たとえば、ゲームを一時停止する) か、入力を無視して単にゲームプレイを続行させるかは、開発者が決定できます。</span><span class="sxs-lookup"><span data-stu-id="450fc-136">It's up to you whether you want to block gameplay when there's no controller connected (for example, by pausing the game) or simply have gameplay continue, while ignoring input.</span></span>

```cpp
#include <ppl.h>

using namespace Platform::Collections;
using namespace Windows::Gaming::Input;
using namespace concurrency;

Vector<Gamepad^>^ m_myGamepads = ref new Vector<Gamepad^>();

Gamepad^ GetFirstGamepad()
{
    Gamepad^ gamepad = nullptr;
    critical_section::scoped_lock{ m_lock };

    if (m_myGamepads->Size > 0)
    {
        gamepad = m_myGamepads->GetAt(0);
    }

    return gamepad;
}
```

<span data-ttu-id="450fc-137">これらをまとめて、ゲームパッドからの入力を処理する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="450fc-137">Putting it all together, here is an example of how to handle input from a gamepad:</span></span>

```cpp
#include <algorithm>
#include <ppl.h>

using namespace Platform::Collections;
using namespace Windows::Foundation;
using namespace Windows::Gaming::Input;
using namespace concurrency;

static Vector<Gamepad^>^ m_myGamepads = ref new Vector<Gamepad^>();
static Gamepad^          m_gamepad = nullptr;
static critical_section  m_lock{};

void Start()
{
    // Register for gamepad added and removed events.
    Gamepad::GamepadAdded += ref new EventHandler<Gamepad^>(&OnGamepadAdded);
    Gamepad::GamepadRemoved += ref new EventHandler<Gamepad^>(&OnGamepadRemoved);

    // Add connected gamepads to m_myGamepads.
    for (auto gamepad : Gamepad::Gamepads)
    {
        OnGamepadAdded(nullptr, gamepad);
    }
}

void Update()
{
    // Update the current gamepad if necessary.
    if (m_gamepad == nullptr)
    {
        auto gamepad = GetFirstGamepad();

        if (m_gamepad != gamepad)
        {
            m_gamepad = gamepad;
        }
    }

    if (m_gamepad != nullptr)
    {
        // Gather gamepad reading.
    }
}

// Get the first gamepad in the list.
Gamepad^ GetFirstGamepad()
{
    Gamepad^ gamepad = nullptr;
    critical_section::scoped_lock{ m_lock };

    if (m_myGamepads->Size > 0)
    {
        gamepad = m_myGamepads->GetAt(0);
    }

    return gamepad;
}

void OnGamepadAdded(Platform::Object^ sender, Gamepad^ args)
{
    // Check if the just-added gamepad is already in m_myGamepads; if it isn't, 
    // add it.
    critical_section::scoped_lock lock{ m_lock };
    auto it = std::find(begin(m_myGamepads), end(m_myGamepads), args);

    if (it == end(m_myGamepads))
    {
        m_myGamepads->Append(args);
    }
}

void OnGamepadRemoved(Platform::Object^ sender, Gamepad^ args)
{
    // Remove the gamepad that was just disconnected from m_myGamepads.
    unsigned int indexRemoved;
    critical_section::scoped_lock lock{ m_lock };

    if (m_myGamepads->IndexOf(args, &indexRemoved))
    {
        if (m_gamepad == m_myGamepads->GetAt(indexRemoved))
        {
            m_gamepad = nullptr;
        }

        m_myGamepads->RemoveAt(indexRemoved);
    }
}
```

## <a name="tracking-users-and-their-devices"></a><span data-ttu-id="450fc-138">ユーザーおよびそのデバイスの追跡</span><span class="sxs-lookup"><span data-stu-id="450fc-138">Tracking users and their devices</span></span>

<span data-ttu-id="450fc-139">ユーザーの ID をゲームプレイ、成績、設定の変更などのアクティビティにリンクできるように、すべての入力デバイスが [User](https://docs.microsoft.com/uwp/api/windows.system.user) に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="450fc-139">All input devices are associated with a [User](https://docs.microsoft.com/uwp/api/windows.system.user) so that their identity can be linked to their gameplay, achievements, settings changes, and other activities.</span></span> <span data-ttu-id="450fc-140">ユーザーは必要に応じてサインインまたはサインアウトできます。一般的には、前のユーザーがサインアウトした後、入力デバイスをシステムに接続したまま別のユーザーがサインインします。ユーザーがサインインまたはサインアウトするときに、[IGameController.UserChanged](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller.UserChanged) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="450fc-140">Users can sign in or sign out at will, and it's common for a different user to sign in on an input device that remains connected to the system after the previous user has signed out. When a user signs in or out, the [IGameController.UserChanged](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller.UserChanged) event is raised.</span></span> <span data-ttu-id="450fc-141">このイベントのイベント ハンドラーを登録することで、プレイヤーとプレイヤーが使用中のデバイスを追跡できます。</span><span class="sxs-lookup"><span data-stu-id="450fc-141">You can register an event handler for this event to keep track of players and the devices they're using.</span></span>

<span data-ttu-id="450fc-142">ユーザー ID は、入力デバイスを対応する [UI ナビゲーション コント ローラー](ui-navigation-controller.md)に関連付けるための方法でもあります。</span><span class="sxs-lookup"><span data-stu-id="450fc-142">User identity is also the way that an input device is associated with its corresponding [UI navigation controller](ui-navigation-controller.md).</span></span>

<span data-ttu-id="450fc-143">これらの理由から、デバイス クラス ([IGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller) インターフェイスから継承) の [User](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller.User) プロパティを使用して、プレイヤーの入力が追跡され、関係付けられます。</span><span class="sxs-lookup"><span data-stu-id="450fc-143">For these reasons, player input should be tracked and correlated with the [User](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller.User) property of the device class (inherited from the [IGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller) interface).</span></span>

<span data-ttu-id="450fc-144">[UserGamepadPairingUWP (GitHub)](
https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/UserGamepadPairingUWP) サンプルでは、ユーザーとそのユーザーが使用中のデバイスを追跡する方法を示してます。</span><span class="sxs-lookup"><span data-stu-id="450fc-144">The [UserGamepadPairingUWP (GitHub)](
https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/UserGamepadPairingUWP) sample demonstrates how you can keep track of users and the devices they're using.</span></span>

## <a name="detecting-button-transitions"></a><span data-ttu-id="450fc-145">ボタンの状態遷移の検出</span><span class="sxs-lookup"><span data-stu-id="450fc-145">Detecting button transitions</span></span>

<span data-ttu-id="450fc-146">ボタンを最初に押したタイミング、または離したタイミングを把握したい場合があります。正確には、離した状態から押した状態への、または押した状態から離した状態へのボタンの状態遷移のタイミングを把握したい場合があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-146">Sometimes you want to know when a button is first pressed or released; that is, precisely when the button state transitions from released to pressed or from pressed to released.</span></span> <span data-ttu-id="450fc-147">これを判断するには、デバイスの前回読み取り結果を記憶し、現在の読み取り結果と比較して状態変化を確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-147">To determine this, you need to remember the previous device reading and compare the current reading against it to see what's changed.</span></span>

<span data-ttu-id="450fc-148">次の例では、前回の読み取り結果を記憶する基本的な方法を示します。ここで示しているのはゲームパッドですが、アーケード スティック、レース ホイール、その他の種類の入力デバイスでも原理は同じです。</span><span class="sxs-lookup"><span data-stu-id="450fc-148">The following example demonstrates a basic approach for remembering the previous reading; gamepads are shown here, but the principles are the same for arcade stick, racing wheel, and the other input device types.</span></span>

```cpp
Gamepad gamepad;
GamepadReading newReading();
GamepadReading oldReading();

// Called at the start of the game.
void Game::Start()
{
    gamepad = Gamepad::Gamepads[0];
}

// Game::Loop represents one iteration of a typical game loop
void Game::Loop()
{
    // move previous newReading into oldReading before getting next newReading
    oldReading = newReading, newReading = gamepad.GetCurrentReading();

    // process device readings using buttonJustPressed/buttonJustReleased (see below)
}
```

<span data-ttu-id="450fc-149">他の処理を行う前に、`Game::Loop` では `newReading` の既存の値 (前回ループの反復でのゲームパッドの読み取り結果) を `oldReading` に移動して、現在の反復でのゲームパッドの新しい読み取り結果を `newReading` に格納しています。</span><span class="sxs-lookup"><span data-stu-id="450fc-149">Before doing anything else, `Game::Loop` moves the existing value of `newReading` (the gamepad reading from the previous loop iteration) into `oldReading`, then fills `newReading` with a fresh gamepad reading for the current iteration.</span></span> <span data-ttu-id="450fc-150">これにより、ボタンの状態遷移を検出するために必要な情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="450fc-150">This gives you the information you need to detect button transitions.</span></span>

<span data-ttu-id="450fc-151">次の例では、ボタンの状態遷移を検出する基本的な方法を示します。</span><span class="sxs-lookup"><span data-stu-id="450fc-151">The following example demonstrates a basic approach for detecting button transitions:</span></span>

```cpp
bool ButtonJustPressed(const GamepadButtons selection)
{
    bool newSelectionPressed = (selection == (newReading.Buttons & selection));
    bool oldSelectionPressed = (selection == (oldReading.Buttons & selection));

    return newSelectionPressed && !oldSelectionPressed;
}

bool ButtonJustReleased(GamepadButtons selection)
{
    bool newSelectionReleased =
        (GamepadButtons.None == (newReading.Buttons & selection));

    bool oldSelectionReleased =
        (GamepadButtons.None == (oldReading.Buttons & selection));

    return newSelectionReleased && !oldSelectionReleased;
}
```

<span data-ttu-id="450fc-152">上記の 2 つの関数は、まず `newReading` と `oldReading` からボタンの選択状態をブール値で求めています。次に、ブール値の論理演算を実行し、対象となるボタンの状態遷移が発生しているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="450fc-152">These two functions first derive the Boolean state of the button selection from `newReading` and `oldReading`, then perform Boolean logic to determine whether the target transition has occurred.</span></span> <span data-ttu-id="450fc-153">この 2 つの関数は、新しい読み取り結果が目的の状態 (それぞれ押した状態または離した状態) を含み、\*\* かつ、前回の読み取り結果が目的の状態を含まない場合にのみ **true** を返します。それ以外の場合は **false** を返します。</span><span class="sxs-lookup"><span data-stu-id="450fc-153">These functions return **true** only if the new reading contains the target state (pressed or released, respectively) *and* the old reading does not also contain the target state; otherwise, they return **false**.</span></span>

## <a name="detecting-complex-button-arrangements"></a><span data-ttu-id="450fc-154">ボタンの複雑な配置の検出</span><span class="sxs-lookup"><span data-stu-id="450fc-154">Detecting complex button arrangements</span></span>

<span data-ttu-id="450fc-155">入力デバイスの各ボタンは、ボタンが押されている (ダウン) か、離されている (アップ) かどうかを示すデジタルの読み取り結果を提供します。</span><span class="sxs-lookup"><span data-stu-id="450fc-155">Each button of an input device provides a digital reading that indicates whether it's pressed (down) or released (up).</span></span> <span data-ttu-id="450fc-156">効率を高めるため、ボタンの読み取り結果は個別のブール値としては表現しません代わりに、読み取り結果はすべて、[GamepadButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadbuttons) などのデバイス固有の列挙型で表されるビットフィールドにパックされます。</span><span class="sxs-lookup"><span data-stu-id="450fc-156">For efficiency, button readings aren't represented as individual boolean values; instead, they're all packed into bitfields represented by device-specific enumerations such as [GamepadButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadbuttons).</span></span> <span data-ttu-id="450fc-157">特定のボタンを読み取るには、ビット単位のマスクを使用して、目的のボタンの値を切り分けます。</span><span class="sxs-lookup"><span data-stu-id="450fc-157">To read specific buttons, bitwise masking is used to isolate the values that you're interested in.</span></span> <span data-ttu-id="450fc-158">対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。</span><span class="sxs-lookup"><span data-stu-id="450fc-158">A button is pressed (down) when its corresponding bit is set; otherwise, it's released (up).</span></span>

<span data-ttu-id="450fc-159">次の例では、1 つのボタンが押されている状態か離されている状態かを判断する方法を示します。ここで示しているのはゲームパッドですが、アーケード スティック、レース ホイール、その他の種類の入力デバイスでも原理は同じです。</span><span class="sxs-lookup"><span data-stu-id="450fc-159">Recall how single buttons are determined to be pressed or released; gamepads are shown here, but the principles are the same for arcade stick, racing wheel, and the other input device types.</span></span>

```cpp
GamepadReading reading = gamepad.GetCurrentReading();

// Determines whether gamepad button A is pressed.
if (GamepadButtons::A == (reading.Buttons & GamepadButtons::A))
{
    // The A button is pressed.
}

// Determines whether gamepad button A is released.
if (GamepadButtons::None == (reading.Buttons & GamepadButtons::A))
{
    // The A button is released (not pressed).
}
```

<span data-ttu-id="450fc-160">ご覧のように、1 つのボタンの状態を判断するのは簡単ですが、場合によっては、複数のボタンが押されたか離されたか、または一連のボタンの一部押されていて一部離されているような特定の方法で配置されているかどうかを判断したいことがあります。</span><span class="sxs-lookup"><span data-stu-id="450fc-160">As you can see, determining the state of a single button is straight-forward, but sometimes you might want to determine whether multiple buttons are pressed or released, or if a set of buttons are arranged in a particular way&mdash;some pressed, some not.</span></span> <span data-ttu-id="450fc-161">複数のボタンを判断するのは 1 つのボタンを判断するより複雑です。特にボタンの状態が混在する可能性のあるときはなおさらです。ただし、1 つのボタンにも複数のボタンにも同様に当てはめることができる簡単な式を使ってボタン状態を判定できます。</span><span class="sxs-lookup"><span data-stu-id="450fc-161">Testing multiple buttons is more complex than testing single buttons&mdash;especially with the potential of mixed button state&mdash;but there's a simple formula for these tests that applies to single and multiple button tests alike.</span></span>

<span data-ttu-id="450fc-162">次の例では、ゲームパッドのボタン A とボタン B が両方押されているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="450fc-162">The following example determines whether gamepad buttons A and B are both pressed:</span></span>

```cpp
if ((GamepadButtons::A | GamepadButtons::B) == (reading.Buttons & (GamepadButtons::A | GamepadButtons::B))
{
    // The A and B buttons are both pressed.
}
```

<span data-ttu-id="450fc-163">次の例では、ゲームパッドのボタン A とボタン B が両方離されているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="450fc-163">The following example determines whether gamepad buttons A and B are both released:</span></span>

```cpp
if ((GamepadButtons::None == (reading.Buttons & GamepadButtons::A | GamepadButtons::B))
{
    // The A and B buttons are both released (not pressed).
}
```

<span data-ttu-id="450fc-164">次の例では、ゲームパッドのボタン A が押されていてボタン B が離されているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="450fc-164">The following example determines whether gamepad button A is pressed while button B is released:</span></span>

```cpp
if (GamepadButtons::A == (reading.Buttons & (GamepadButtons::A | GamepadButtons::B))
{
    // The A button is pressed and the B button is released (B is not pressed).
}
```

<span data-ttu-id="450fc-165">上記の例すべての式に共通しているのは、テストするボタンの配置を等号演算子の左辺で指定し、状態を検討するボタンを等号演算子の右辺のマスク式で選択していることです。</span><span class="sxs-lookup"><span data-stu-id="450fc-165">The formula that all five of these examples have in common is that the arrangement of buttons to be tested for is specified by the expression on the left-hand side of the equality operator while the buttons to be considered are selected by the masking expression on the right-hand side.</span></span>

<span data-ttu-id="450fc-166">次の例では、上記の例を書き直して、式をより分かりやすく表現する例を示しています。</span><span class="sxs-lookup"><span data-stu-id="450fc-166">The following example demonstrates this formula more clearly by rewriting the previous example:</span></span>

```cpp
auto buttonArrangement = GamepadButtons::A;
auto buttonSelection = (reading.Buttons & (GamepadButtons::A | GamepadButtons::B));

if (buttonArrangement == buttonSelection)
{
    // The A button is pressed and the B button is released (B is not pressed).
}
```

<span data-ttu-id="450fc-167">上記の式は、ボタンの数、配置、テストする状態を問わず、どのような場合でも当てはめることができます。</span><span class="sxs-lookup"><span data-stu-id="450fc-167">This formula can be applied to test any number of buttons in any arrangement of their states.</span></span>

## <a name="get-the-state-of-the-battery"></a><span data-ttu-id="450fc-168">バッテリーの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="450fc-168">Get the state of the battery</span></span>

<span data-ttu-id="450fc-169">[IGameControllerBatteryInfo](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontrollerbatteryinfo) インターフェイスを実装しているゲーム コントローラーの場合は、コントローラー インスタンスで [TryGetBatteryReport](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontrollerbatteryinfo.TryGetBatteryReport) を呼び出すことによって、コントローラーのバッテリーに関する情報を提供する [BatteryReport](https://docs.microsoft.com/uwp/api/windows.devices.power.batteryreport) オブジェクトを取得できます。</span><span class="sxs-lookup"><span data-stu-id="450fc-169">For any game controller that implements the [IGameControllerBatteryInfo](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontrollerbatteryinfo) interface, you can call [TryGetBatteryReport](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontrollerbatteryinfo.TryGetBatteryReport) on the controller instance to get a [BatteryReport](https://docs.microsoft.com/uwp/api/windows.devices.power.batteryreport) object that provides information about the battery in the controller.</span></span> <span data-ttu-id="450fc-170">バッテリーの充電速度 ([ChargeRateInMilliwatts](https://docs.microsoft.com/uwp/api/windows.devices.power.batteryreport.ChargeRateInMilliwatts))、新しいバッテリーの電力容量の見積もり ([DesignCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.DesignCapacityInMilliwattHours))、現在のバッテリーの完全に充電した場合の電力容量 ([FullChargeCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.FullChargeCapacityInMilliwattHours)) などのプロパティを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="450fc-170">You can get properties like the rate that the battery is charging ([ChargeRateInMilliwatts](https://docs.microsoft.com/uwp/api/windows.devices.power.batteryreport.ChargeRateInMilliwatts)), the estimated energy capacity of a new battery ([DesignCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.DesignCapacityInMilliwattHours)), and the fully-charged energy capacity of the current battery ([FullChargeCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.FullChargeCapacityInMilliwattHours)).</span></span>

<span data-ttu-id="450fc-171">詳細なバッテリーのレポートをサポートするゲーム コントローラーの場合、「[バッテリー情報の取得](../devices-sensors/get-battery-info.md)」で説明されているように、この情報に加えて、バッテリーに関するさらに詳しい情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="450fc-171">For game controllers that support detailed battery reporting, you can get this and more information about the battery, as detailed in [Get battery information](../devices-sensors/get-battery-info.md).</span></span> <span data-ttu-id="450fc-172">ただし、ほとんどのゲーム コントローラーはこのレベルのバッテリー レポートをサポートしておらず、代わりに低コストのハードウェアを使用しています。</span><span class="sxs-lookup"><span data-stu-id="450fc-172">However, most game controllers don't support that level of battery reporting, and instead use low-cost hardware.</span></span> <span data-ttu-id="450fc-173">このようなコントローラーでは、次の考慮事項に留意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-173">For these controllers, you'll need to keep the following considerations in mind:</span></span>

* <span data-ttu-id="450fc-174">**ChargeRateInMilliwatts** と **DesignCapacityInMilliwattHours** は常に **NULL** になります。</span><span class="sxs-lookup"><span data-stu-id="450fc-174">**ChargeRateInMilliwatts** and **DesignCapacityInMilliwattHours** will always be **NULL**.</span></span>

* <span data-ttu-id="450fc-175">バッテリ残量の割合は、[RemainingCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.RemainingCapacityInMilliwattHours) / **FullChargeCapacityInMilliwattHours** を計算することによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="450fc-175">You can get the battery percentage by calculating [RemainingCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.RemainingCapacityInMilliwattHours) / **FullChargeCapacityInMilliwattHours**.</span></span> <span data-ttu-id="450fc-176">これらのプロパティの値を無視して、計算される割合のみを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="450fc-176">You should ignore the values of these properties and only deal with the calculated percentage.</span></span>

* <span data-ttu-id="450fc-177">前の項目の割合は、常に次のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="450fc-177">The percentage from the previous bullet point will always be one of the following:</span></span>

    * <span data-ttu-id="450fc-178">100% (フル)</span><span class="sxs-lookup"><span data-stu-id="450fc-178">100% (Full)</span></span>
    * <span data-ttu-id="450fc-179">70% (中)</span><span class="sxs-lookup"><span data-stu-id="450fc-179">70% (Medium)</span></span>
    * <span data-ttu-id="450fc-180">40% (低)</span><span class="sxs-lookup"><span data-stu-id="450fc-180">40% (Low)</span></span>
    * <span data-ttu-id="450fc-181">10% (バッテリー切れ)</span><span class="sxs-lookup"><span data-stu-id="450fc-181">10% (Critical)</span></span>

<span data-ttu-id="450fc-182">コードが、バッテリー残量の割合に基づいて何かアクションを実行する (UI の描画など) 場合、上記の値に準拠しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="450fc-182">If your code performs some action (like drawing UI) based on the percentage of battery life remaining, make sure that it conforms to the values above.</span></span> <span data-ttu-id="450fc-183">たとえば、コントローラーのバッテリー残量が少ないときにプレイヤーに警告を表示する場合は、10% に達したときに表示します。</span><span class="sxs-lookup"><span data-stu-id="450fc-183">For example, if you want to warn the player when the controller's battery is low, do so when it reaches 10%.</span></span>

## <a name="see-also"></a><span data-ttu-id="450fc-184">関連項目</span><span class="sxs-lookup"><span data-stu-id="450fc-184">See also</span></span>

* [<span data-ttu-id="450fc-185">Windows.System.User クラス</span><span class="sxs-lookup"><span data-stu-id="450fc-185">Windows.System.User class</span></span>](https://docs.microsoft.com/uwp/api/windows.system.user)
* [<span data-ttu-id="450fc-186">Windows.Gaming.Input.IGameController インターフェイス</span><span class="sxs-lookup"><span data-stu-id="450fc-186">Windows.Gaming.Input.IGameController interface</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller)
* [<span data-ttu-id="450fc-187">Windows.Gaming.Input.GamepadButtons 列挙型</span><span class="sxs-lookup"><span data-stu-id="450fc-187">Windows.Gaming.Input.GamepadButtons enum</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadbuttons)
