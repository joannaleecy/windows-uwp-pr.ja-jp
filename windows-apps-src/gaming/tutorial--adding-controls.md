---
author: abbycar
title: コントロールの追加
description: 次は、ゲーム サンプルで 3-D ゲームにムーブ/ルック コントロールを実装する方法と、タッチ コントローラー用、マウス コントローラー用、ゲーム コントローラー用の基本的なコントロールを開発する方法について説明します。
ms.assetid: f9666abb-151a-74b4-ae0b-ef88f1f252f8
ms.author: abigailc
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, コントロール, 入力
ms.localizationpriority: medium
ms.openlocfilehash: 4aaacee011b3732b8d1456935239d7a4a5405a4d
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5944170"
---
# <a name="add-controls"></a><span data-ttu-id="2cd12-104">コントロールの追加</span><span class="sxs-lookup"><span data-stu-id="2cd12-104">Add controls</span></span>


<span data-ttu-id="2cd12-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="2cd12-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="2cd12-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="2cd12-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="2cd12-107">優れた ユニバーサル Windows プラットフォーム (UWP) ゲームは、幅広いインターフェイスをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="2cd12-107">A good Universal Windows Platform (UWP) game supports a wide variety of interfaces.</span></span> <span data-ttu-id="2cd12-108">潜在的なプレイヤーが windows 10 を持っている搭載で物理的なボタンのない、PC、Xbox コント ローラー、タブレット、または高性能マウス/ゲーム キーボード付属の最新デスクトップ ゲーム機かもしれません。</span><span class="sxs-lookup"><span data-stu-id="2cd12-108">A potential player might have Windows10 on a tablet with no physical buttons, a PC with an Xbox controller attached, or the latest desktop gaming rig with a high-performance mouse and gaming keyboard.</span></span> <span data-ttu-id="2cd12-109">このゲームでは、コントロールは [**MoveLookController**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp) クラスで実装されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-109">In our game the controls are implemented in the [**MoveLookController**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp) class.</span></span> <span data-ttu-id="2cd12-110">このクラスは、3 種類のすべての入力 (マウスとキーボード、タッチ、ゲームパッド) を 1 つのコントローラーのに集約します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-110">This class aggregates all three types of input (mouse and keyboard, touch, and gamepad) into a single controller.</span></span> <span data-ttu-id="2cd12-111">最終的には、一人称視点のシューティング ゲームで使用するジャンル標準のムーブ/ルック コントロールが、複数のデバイスで利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-111">The end result is a first-person shooter that uses genre standard move-look controls that work with multiple devices.</span></span>

> [!NOTE]
> <span data-ttu-id="2cd12-112">コントロールの詳細ついては、「[ゲームのムーブ/ルック コントロール](tutorial--adding-move-look-controls-to-your-directx-game.md)」と「[ゲームのタッチ コントロール](tutorial--adding-touch-controls-to-your-directx-game.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2cd12-112">For more info about controls, see [Move-look controls for games](tutorial--adding-move-look-controls-to-your-directx-game.md) and [Touch controls for games](tutorial--adding-touch-controls-to-your-directx-game.md).</span></span>


## <a name="objective"></a><span data-ttu-id="2cd12-113">目標</span><span class="sxs-lookup"><span data-stu-id="2cd12-113">Objective</span></span>

<span data-ttu-id="2cd12-114">この時点で、レンダリングするゲームは完成していますが、プレイヤーが動き回ったり、ターゲットを撃ったりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="2cd12-114">At this point we have a game that renders, but we can't move our player around or shoot the targets.</span></span> <span data-ttu-id="2cd12-115">ここでは、UWP DirectX ゲームで次の種類の入力について、一人称視点のシューティング ゲームのムーブ/ルック コントロールを実装する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="2cd12-115">We'll take a look at how our game implements first person shooter move-look controls for the following types of input in our UWP DirectX game.</span></span>
- <span data-ttu-id="2cd12-116">マウスとキーボード</span><span class="sxs-lookup"><span data-stu-id="2cd12-116">Mouse and keyboard</span></span>
- <span data-ttu-id="2cd12-117">タッチ</span><span class="sxs-lookup"><span data-stu-id="2cd12-117">Touch</span></span>
- <span data-ttu-id="2cd12-118">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="2cd12-118">Gamepad</span></span>

>[!Note]
><span data-ttu-id="2cd12-119">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="2cd12-119">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="2cd12-120">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="2cd12-120">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="2cd12-121">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2cd12-121">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="common-control-behaviors"></a><span data-ttu-id="2cd12-122">コントロールの共通の動作</span><span class="sxs-lookup"><span data-stu-id="2cd12-122">Common control behaviors</span></span>


<span data-ttu-id="2cd12-123">タッチ コントロールとマウス/キーボード コントロールのコア実装は、よく似ています。</span><span class="sxs-lookup"><span data-stu-id="2cd12-123">Touch controls and mouse/keyboard controls have a very similar core implementation.</span></span> <span data-ttu-id="2cd12-124">UWP アプリでは、ポインターは画面上の単なる点です。</span><span class="sxs-lookup"><span data-stu-id="2cd12-124">In a UWP app, a pointer is simply a point on the screen.</span></span> <span data-ttu-id="2cd12-125">これは、マウスをスライドするか、タッチ スクリーンで指をスライドすることで動かせます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-125">You can move it by sliding the mouse or sliding your finger on the touch screen.</span></span> <span data-ttu-id="2cd12-126">このため、単一のイベント セットを登録でき、プレイヤーがポインターを動かして押すのにマウスとタッチ スクリーンのどちらを使っているかを気にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="2cd12-126">As a result, you can register for a single set of events, and not worry about whether the player is using a mouse or a touch screen to move and press the pointer.</span></span>

<span data-ttu-id="2cd12-127">このゲーム サンプルの **MoveLookController** クラスを初期化すると、ポインターに固有の 4 つのイベントとマウスに固有の 1 つのイベントが登録されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-127">When the **MoveLookController** class in the game sample is initialized, it registers for four pointer-specific events and one mouse-specific event:</span></span>

<span data-ttu-id="2cd12-128">イベント</span><span class="sxs-lookup"><span data-stu-id="2cd12-128">Event</span></span> | <span data-ttu-id="2cd12-129">説明</span><span class="sxs-lookup"><span data-stu-id="2cd12-129">Description</span></span>
:------ | :-------
[**<span data-ttu-id="2cd12-130">CoreWindow::PointerPressed</span><span class="sxs-lookup"><span data-stu-id="2cd12-130">CoreWindow::PointerPressed</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208278) | <span data-ttu-id="2cd12-131">マウスの左または右ボタンが押された (そして押され続けた) か、タッチ画面がタッチされました。</span><span class="sxs-lookup"><span data-stu-id="2cd12-131">The left or right mouse button was pressed (and held), or the touch surface was touched.</span></span>
[**<span data-ttu-id="2cd12-132">CoreWindow::PointerMoved</span><span class="sxs-lookup"><span data-stu-id="2cd12-132">CoreWindow::PointerMoved</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208276) |<span data-ttu-id="2cd12-133">マウスが動かされたか、タッチ画面でドラッグ操作が行われました。</span><span class="sxs-lookup"><span data-stu-id="2cd12-133">The mouse moved, or a drag action was made on the touch surface.</span></span>
[**<span data-ttu-id="2cd12-134">CoreWindow::PointerReleased</span><span class="sxs-lookup"><span data-stu-id="2cd12-134">CoreWindow::PointerReleased</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208279) |<span data-ttu-id="2cd12-135">マウスの左ボタンが離されたか、タッチ画面に触れているオブジェクトが離されました。</span><span class="sxs-lookup"><span data-stu-id="2cd12-135">The left mouse button was released, or the object contacting the touch surface was lifted.</span></span>
[**<span data-ttu-id="2cd12-136">CoreWindow::PointerExited</span><span class="sxs-lookup"><span data-stu-id="2cd12-136">CoreWindow::PointerExited</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208275) |<span data-ttu-id="2cd12-137">ポインターがメイン ウィンドウの外に動かされました。</span><span class="sxs-lookup"><span data-stu-id="2cd12-137">The pointer moved out of the main window.</span></span>
[**<span data-ttu-id="2cd12-138">Windows::Devices::Input::MouseMoved</span><span class="sxs-lookup"><span data-stu-id="2cd12-138">Windows::Devices::Input::MouseMoved</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh758356) | <span data-ttu-id="2cd12-139">マウスが一定の距離動かされました。</span><span class="sxs-lookup"><span data-stu-id="2cd12-139">The mouse moved a certain distance.</span></span> <span data-ttu-id="2cd12-140">現在の X-Y 位置ではなく、マウス移動のデルタ値にのみ注目します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-140">Be aware that we are only interested in mouse movement delta values, and not the current X-Y position.</span></span>


<span data-ttu-id="2cd12-141">これらのイベント ハンドラーは、アプリケーション ウィンドウ内で **MoveLookController** が初期化されるとすぐに、ユーザー入力の待機を開始するように設定されています。</span><span class="sxs-lookup"><span data-stu-id="2cd12-141">These event handlers are set to start listening for user input as soon as the **MoveLookController** is initialized in the application window.</span></span>
```cpp
void MoveLookController::InitWindow(_In_ CoreWindow^ window)
{
    ResetState();

    window->PointerPressed +=
        ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerPressed);

    window->PointerMoved +=
        ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerMoved);

    window->PointerReleased +=
        ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerReleased);

    window->PointerExited +=
        ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerExited);

    // There is a separate handler for mouse only relative mouse movement events.
    MouseDevice::GetForCurrentView()->MouseMoved +=
        ref new TypedEventHandler<MouseDevice^, MouseEventArgs^>(this, &MoveLookController::OnMouseMoved);
    //
    // ...
    //
}
```

<span data-ttu-id="2cd12-142">[**InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L68-L92) のコード一式は GitHub で確認できます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-142">Complete code for [**InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L68-L92) can be seen on GitHub.</span></span>


<span data-ttu-id="2cd12-143">ゲームがいつ特定の入力を待機する必要があるかを判断するために、**MoveLookController** クラスには、コントローラーの種類に関係なく、コントローラーに固有の次の 3 つの状態があります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-143">To determine when the game should be listening for certain input, the **MoveLookController** class has three controller-specific states, regardless of the controller type:</span></span>

<span data-ttu-id="2cd12-144">状態</span><span class="sxs-lookup"><span data-stu-id="2cd12-144">State</span></span> | <span data-ttu-id="2cd12-145">説明</span><span class="sxs-lookup"><span data-stu-id="2cd12-145">Description</span></span>
:----- | :-------
**<span data-ttu-id="2cd12-146">None</span><span class="sxs-lookup"><span data-stu-id="2cd12-146">None</span></span>** | <span data-ttu-id="2cd12-147">これは、コントローラーの初期化された状態です。</span><span class="sxs-lookup"><span data-stu-id="2cd12-147">This is the initialized state for the controller.</span></span> <span data-ttu-id="2cd12-148">ゲームではコントローラーの入力を予期していないため、すべての入力は無視されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-148">All input is ignored since the game is not anticipating any controller input.</span></span>
**<span data-ttu-id="2cd12-149">WaitForInput</span><span class="sxs-lookup"><span data-stu-id="2cd12-149">WaitForInput</span></span>** | <span data-ttu-id="2cd12-150">コントローラーは、プレイヤーが、マウスの左クリック、タッチ イベント、ゲームパッドのメニュー ボタンのいずれかを使用して、ゲームからのメッセージを確認するのを待っています。</span><span class="sxs-lookup"><span data-stu-id="2cd12-150">The controller is waiting for the player to acknowledge a message from the game by either using a left mouse click, a touch event, ot the menu button on a gamepad.</span></span>
**<span data-ttu-id="2cd12-151">Active</span><span class="sxs-lookup"><span data-stu-id="2cd12-151">Active</span></span>** | <span data-ttu-id="2cd12-152">コントローラーはアクティブなゲーム プレイ モードです。</span><span class="sxs-lookup"><span data-stu-id="2cd12-152">The controller is in active game play mode.</span></span>



### <a name="waitforinput-state-and-pausing-the-game"></a><span data-ttu-id="2cd12-153">WaitForInput 状態とゲームの一時停止</span><span class="sxs-lookup"><span data-stu-id="2cd12-153">WaitForInput state and pausing the game</span></span>

<span data-ttu-id="2cd12-154">ゲームが一時停止されると、ゲームは **WaitForInput** 状態になります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-154">The game enters the **WaitForInput** state when the game has been paused.</span></span> <span data-ttu-id="2cd12-155">これは、プレイヤーがゲームのメイン ウィンドウの外にポインターを動かすか、一時停止ボタン (P キーまたはゲームパッドの**スタート** ボタン) を押したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-155">This happens when the player moves the pointer outside the main window of the game, or presses the pause button (the P key or the gamepad **Start** button).</span></span> <span data-ttu-id="2cd12-156">**MoveLookController** は、この押し操作を登録し、[**IsPauseRequested**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L107-L127) メソッドを呼び出すときにゲーム ループに通知します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-156">The **MoveLookController** registers the press, and informs the game loop when it calls the [**IsPauseRequested**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L107-L127) method.</span></span> <span data-ttu-id="2cd12-157">その時点で、**IsPauseRequested** が **true** を返すと、ゲーム ループは **MoveLookController** の **WaitForPress** を呼び出して、コントローラーを **WaitForInput** 状態にします。</span><span class="sxs-lookup"><span data-stu-id="2cd12-157">At that point if **IsPauseRequested** returns **true**, the game loop then calls **WaitForPress** on the **MoveLookController** to move the controller into the **WaitForInput** state.</span></span> 


<span data-ttu-id="2cd12-158">**WaitForInput** 状態になると、ゲームは、**Active**状態 に戻るまで、ほぼすべてのゲームプレイ入力イベントの処理を停止します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-158">Once in the **WaitForInput** state, the game stops processing almost all gameplay input events until it returns to the **Active** state.</span></span> <span data-ttu-id="2cd12-159">一時停止ボタンは例外で、このボタンを押すと、ゲームはアクティブ状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-159">The exception is the pause button, with a press of this causing the game to go back to the active state.</span></span> <span data-ttu-id="2cd12-160">一時停止ボタン以外は**アクティブ**状態に戻るには、ゲームの順序で、プレイヤーする必要があるメニュー項目を選択します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-160">Other than the pause button, in order for the game to go back to the **Active** state the player needs to select a menu item.</span></span> 



### <a name="the-active-state"></a><span data-ttu-id="2cd12-161">Active 状態</span><span class="sxs-lookup"><span data-stu-id="2cd12-161">The Active state</span></span>

<span data-ttu-id="2cd12-162">**Active** 状態では、**MoveLookController** インスタンスは、有効になっているすべての入力デバイスからの入力イベントを処理し、プレイヤーの意図を解釈しています。</span><span class="sxs-lookup"><span data-stu-id="2cd12-162">During the **Active** state, the **MoveLookController** instance is processing events from all enabled input devices and interpreting the player's intentions.</span></span> <span data-ttu-id="2cd12-163">この結果、**Update** がゲーム ループから呼び出された後に、プレイヤーのビューの速度とルック方向を更新し、更新データをゲームと共有します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-163">As a result, it updates the velocity and look direction of the player's view and shares the updated data with the game after **Update** is called from the game loop.</span></span>


<span data-ttu-id="2cd12-164">すべてのポインター入力は、**Active** 状態で追跡され、ポインターの操作に応じて異なるポインター ID が設定されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-164">All pointer input is tracked in the **Active** state, with different pointer IDs corresponding to different pointer actions.</span></span>
<span data-ttu-id="2cd12-165">[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208278) イベントが受け取られると、**MoveLookController** は、ウィンドウで作成されたポインターの ID 値を取得します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-165">When a [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208278) event is received, the **MoveLookController** obtains the pointer ID value created by the window.</span></span> <span data-ttu-id="2cd12-166">ポインター ID は、特定の種類の入力を表します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-166">The pointer ID represents a specific type of input.</span></span> <span data-ttu-id="2cd12-167">たとえば、マルチタッチ デバイスでは、複数の異なるアクティブ入力が同時に行われる場合があります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-167">For example, on a multi-touch device, there may be several different active inputs at the same time.</span></span> <span data-ttu-id="2cd12-168">ID は、プレイヤーが使っている入力を追跡するために使われます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-168">The IDs are used to keep track of which input the player is using.</span></span> <span data-ttu-id="2cd12-169">タッチ スクリーンのムーブ四角形内にイベントがある場合、ポインター ID が割り当てられ、ムーブ四角形内のポインター イベントが追跡されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-169">If one event is in the move rectangle of the touch screen, a pointer ID is assigned to track any pointer events in the move rectangle.</span></span> <span data-ttu-id="2cd12-170">ファイア四角形内の他のポインター イベントは、別のポインター ID で別途追跡されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-170">Other pointer events in the fire rectangle are tracked separately, with a separate pointer ID.</span></span>


> [!NOTE]
> <span data-ttu-id="2cd12-171">マウスおよびゲームパッドの右サムスティックからの入力には、別途処理される別の ID もあります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-171">Input from the mouse and right thumbstick of a gamepad also have IDs that are handled separately.</span></span>

<span data-ttu-id="2cd12-172">ポインター イベントをゲームの特定の操作にマップした後は、**MoveLookController** オブジェクトとゲームのメイン ループで共有されているデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-172">After the pointer events have been mapped to a specific game action, it's time to update the data the **MoveLookController** object shares with the main game loop.</span></span>

<span data-ttu-id="2cd12-173">このゲーム サンプルの [**Update**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1005-L1096) メソッドは、呼び出されると、入力を処理し、速度とルック方向の変数 (**m\_velocity** と **m\_lookdirection**) を更新します。この後、ゲーム ループは、[**Velocity**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L906-L909) および [**LookDirection**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L913-L923) パブリック メソッドを呼び出すことで、これらの変数を取得します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-173">When called, the [**Update**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1005-L1096) method in the game sample processes the input and updates the velocity and look direction variables (**m\_velocity** and **m\_lookdirection**), which the game loop then retrieves by calling the public [**Velocity**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L906-L909) and [**LookDirection**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L913-L923) methods.</span></span>

> [!NOTE]
> <span data-ttu-id="2cd12-174">[**Update**](#the-update-method) メソッドの詳細については、このページで後で説明します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-174">More details about the [**Update**](#the-update-method) method can be seen later on this page.</span></span>




<span data-ttu-id="2cd12-175">ゲーム ループは、**MoveLookController** インスタンスの **IsFiring** メソッドを呼び出すことで、プレイヤーが弾を撃っているかどうかをテストできます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-175">The game loop can test to see if the player is firing by calling the **IsFiring** method on the **MoveLookController** instance.</span></span> <span data-ttu-id="2cd12-176">**MoveLookController** は、プレイヤーが 3 種類の入力のいずれかでファイア ボタンを押したかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-176">The **MoveLookController** checks to see if the player has pressed the fire button on one of the three input types.</span></span>

```cpp
bool MoveLookController::IsFiring()
{
    if (m_state == MoveLookControllerState::Active)
    {
        if (m_autoFire)
        {
            return (m_fireInUse || (m_mouseInUse && m_mouseLeftInUse) || PollingFireInUse());
        }
        else
        {
            if (m_firePressed)
            {
                m_firePressed = false;
                return true;
            }
        }
    }
    return false;
}
```









<span data-ttu-id="2cd12-177">次は、3 種類のコントロールのそれぞれの実装について少し詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-177">Now, let's look at the implementation of each of the three control types in a little more detail.</span></span>

## <a name="adding-relative-mouse-controls"></a><span data-ttu-id="2cd12-178">相対マウス コントロールの追加</span><span class="sxs-lookup"><span data-stu-id="2cd12-178">Adding relative mouse controls</span></span>


<span data-ttu-id="2cd12-179">マウス移動が検出された場合は、その移動を使ってカメラの新しいピッチとヨーを特定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-179">If mouse movement is detected, we want to use that movement to determine the new pitch and yaw of the camera.</span></span> <span data-ttu-id="2cd12-180">そのためには、相対マウス コントロールを実装します。相対マウス コントロールでは、動作の絶対 x-y ピクセル座標を記録するのではなく、マウスが移動した相対距離 (移動の開始から停止までのデルタ) を処理します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-180">We do that by implementing relative mouse controls, where we handle the relative distance the mouse has moved—the delta between the start of the movement and the stop—as opposed to recording the absolute x-y pixel coordinates of the motion.</span></span>

<span data-ttu-id="2cd12-181">これを行うには、[**MouseMoved**](https://msdn.microsoft.com/library/windows/apps/hh758356) イベントによって返される [**Windows::Device::Input::MouseEventArgs::MouseDelta**](https://msdn.microsoft.com/library/windows/apps/hh758358) 引数オブジェクトの [**MouseDelta::X**](https://msdn.microsoft.com/library/windows/apps/hh758353) フィールドと **MouseDelta::Y** フィールドを調べて、X (横方向の動作) と Y (縦方向の動作) の座標の変化を取得します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-181">To do that, we obtain the changes in the X (the horizontal motion) and the Y (the vertical motion) coordinates by examining the [**MouseDelta::X**](https://msdn.microsoft.com/library/windows/apps/hh758353) and **MouseDelta::Y** fields on the [**Windows::Device::Input::MouseEventArgs::MouseDelta**](https://msdn.microsoft.com/library/windows/apps/hh758358) argument object returned by the [**MouseMoved**](https://msdn.microsoft.com/library/windows/apps/hh758356) event.</span></span>

```cpp
void MoveLookController::OnMouseMoved(
    _In_ MouseDevice^ /* mouseDevice */,
    _In_ MouseEventArgs^ args
    )
{
    // Handle Mouse Input via dedicated relative movement handler.

    switch (m_state)
    {
    case MoveLookControllerState::Active:
        XMFLOAT2 mouseDelta;
        mouseDelta.x = static_cast<float>(args->MouseDelta.X);
        mouseDelta.y = static_cast<float>(args->MouseDelta.Y);

        XMFLOAT2 rotationDelta;
        rotationDelta.x  = mouseDelta.x * MoveLookConstants::RotationGain;   // scale for control sensitivity
        rotationDelta.y  = mouseDelta.y * MoveLookConstants::RotationGain;

        // Update our orientation based on the command.
        m_pitch -= rotationDelta.y;
        m_yaw   += rotationDelta.x;

        // Limit pitch to straight up or straight down.
        float limit = XM_PI / 2.0f - 0.01f;
        m_pitch = __max(-limit, m_pitch);
        m_pitch = __min(+limit, m_pitch);

        // Keep longitude in same range by wrapping.
        if (m_yaw >  XM_PI)
        {
            m_yaw -= XM_PI * 2.0f;
        }
        else if (m_yaw < -XM_PI)
        {
            m_yaw += XM_PI * 2.0f;
        }
        break;
    }
}
```

## <a name="adding-touch-support"></a><span data-ttu-id="2cd12-182">タッチのサポートの追加</span><span class="sxs-lookup"><span data-stu-id="2cd12-182">Adding touch support</span></span>

<span data-ttu-id="2cd12-183">タッチ コントロールは、タブレット ユーザーのサポートに優れています。</span><span class="sxs-lookup"><span data-stu-id="2cd12-183">Touch controls are great for supporting users with tablets.</span></span> <span data-ttu-id="2cd12-184">このゲームでは、特定のゲーム内アクションに合わせて画面の特定領域にゾーンを設定することでタッチ入力を収集します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-184">This game gathers touch input by zoning off certain areas of the screen with each aligning to specific in-game actions.</span></span>
<span data-ttu-id="2cd12-185">このゲームのタッチ入力では、3 つのゾーンを使用します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-185">This game's touch input uses three zones.</span></span>

![ムーブ/ルックのタッチ画面のレイアウト](images/simple-dx-game-controls-touchzones.png)

<span data-ttu-id="2cd12-187">次のコマンドは、タッチ コントロールの動作をまとめたものです。</span><span class="sxs-lookup"><span data-stu-id="2cd12-187">The following commands summarize our touch control behavior.</span></span>
<span data-ttu-id="2cd12-188">ユーザー入力</span><span class="sxs-lookup"><span data-stu-id="2cd12-188">User input</span></span> | <span data-ttu-id="2cd12-189">アクション</span><span class="sxs-lookup"><span data-stu-id="2cd12-189">Action</span></span>
:------- | :--------
<span data-ttu-id="2cd12-190">ムーブ四角形</span><span class="sxs-lookup"><span data-stu-id="2cd12-190">Move rectangle</span></span> | <span data-ttu-id="2cd12-191">タッチ入力は仮想ジョイスティックに変換され、垂直方向のモーションは前/後の位置モーションに変換され、水平方向のモーションは左/右の位置モーションに変換されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-191">Touch input is converted into a virtual joystick where the vertical motion will be translated into forward/backward position motion and horizontal motion will be translated into left/right position motion.</span></span>
<span data-ttu-id="2cd12-192">ファイア四角形</span><span class="sxs-lookup"><span data-stu-id="2cd12-192">Fire rectangle</span></span> | <span data-ttu-id="2cd12-193">球体を発射します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-193">Fire a sphere.</span></span>
<span data-ttu-id="2cd12-194">ムーブ四角形とファイア四角形の外部をタッチ</span><span class="sxs-lookup"><span data-stu-id="2cd12-194">Touch outside of move and fire rectangle</span></span> | <span data-ttu-id="2cd12-195">カメラ ビューの回転角度 (ピッチとヨー) を変更します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-195">Change the rotation (the pitch and yaw) of the camera view.</span></span>

<span data-ttu-id="2cd12-196">**MoveLookController** は、ポインター ID を確認してイベントがどこで発生したかを判断し、次のいずれかの処理を実行します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-196">The **MoveLookController** checks the pointer ID to determine where the event occurred, and takes one of the following actions:</span></span>

-   <span data-ttu-id="2cd12-197">[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) イベントがムーブまたはファイア四角形で発生した場合は、コントローラーのポインターの位置を更新します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-197">If the [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) event occurred in the move or fire rectangle, update the pointer position for the controller.</span></span>
-   <span data-ttu-id="2cd12-198">[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) イベントが画面の残りの部分 (ルック コントロールとして定義されている部分) のどこかで発生した場合は、ルック方向ベクトルのピッチとヨーの変化を計算します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-198">If the [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) event occurred somewhere in the rest of the screen (defined as the look controls), calculate the change in pitch and yaw of the look direction vector.</span></span>


<span data-ttu-id="2cd12-199">タッチ コントロールを実装すると、前に Direct2D を使って描画した四角形が、ムーブ、ファイア、ルックの各ゾーンの場所をプレイヤーに示します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-199">Once we've implemented our touch controls, the rectangles we drew earlier using Direct2D will indicate to players where the move, fire, and look zones are.</span></span>


![タッチ コントロール](images/simple-dx-game-controls-showzones.png)


<span data-ttu-id="2cd12-201">次に、各コントロールを実装する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="2cd12-201">Now let's take a look at how we implement each control.</span></span>


### <a name="move-and-fire-controller"></a><span data-ttu-id="2cd12-202">ムーブおよびファイア コントローラー</span><span class="sxs-lookup"><span data-stu-id="2cd12-202">Move and fire controller</span></span>
<span data-ttu-id="2cd12-203">画面左下のセクションのムーブ コントローラーの四角形は、方向パッドとして使用されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-203">The move controller rectangle in the lower left quadrant of the screen is used as a directional pad.</span></span> <span data-ttu-id="2cd12-204">この領域内で親指を左右にスライドさせると、プレイヤーが左右に移動し、上下にスライドさせると、カメラが前後に移動します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-204">Sliding your thumb left and right within this space moves the player left and right, while up and down moves the camera forward and backward.</span></span>
<span data-ttu-id="2cd12-205">これを設定した後、画面の右下のセクションのファイア コントローラーをタップすると、球体が発射されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-205">After setting this up, tapping the fire controller in the lower right quadrant of the screen fires a sphere.</span></span>

<span data-ttu-id="2cd12-206">[**SetMoveRect**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L843-L853) メソッドと [**SetFireRect**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L857-L867) メソッドは、画面上で各四角形の左上隅と右下隅の位置を指定する 2 つの 2D ベクトルを使用して、入力の四角形を作成します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-206">The [**SetMoveRect**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L843-L853) and [**SetFireRect**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L857-L867) methods create our input rectangles, taking two, 2D vectors to specify each rectangles' upper left and lower right corner positions on the screen.</span></span> 


<span data-ttu-id="2cd12-207">次に、**m\_fireUpperLeft** と **m\_fireLowerRight** にパラメーターが割り当てられます。これは、ユーザーが四角形の内部をタッチしているかどうかを判断するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-207">The parameters are then assigned to **m\_fireUpperLeft** and **m\_fireLowerRight** that will help us determine if the user is touching within on of the rectangles.</span></span> 
```cpp
m_fireUpperLeft  = upperLeft;
m_fireLowerRight = lowerRight;
```

<span data-ttu-id="2cd12-208">画面のサイズが変更される場合、これらの四角形は適切なサイズで再描画されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-208">If the screen is resized, these rectangles are redrawn to the approperiate size.</span></span>


<span data-ttu-id="2cd12-209">コントロールのゾーンを設定したら、次はユーザーが実際にコントロールを使用しているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-209">Now that we've zoned off our controls, it's time to determine when a user is actually using them.</span></span>
<span data-ttu-id="2cd12-210">これを行うには、ユーザーがポインターを押したとき、移動したとき、離したときに対応するいくつかのイベント ハンドラーを **MoveLookController::InitWindow** メソッド内に設定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-210">To do this, we set up some event handlers in the **MoveLookController::InitWindow** method for when the user presses, moves, or releases their pointer.</span></span>

```cpp
window->PointerPressed +=
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerPressed);

window->PointerMoved +=
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerMoved);

window->PointerReleased +=
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerReleased);
```


<span data-ttu-id="2cd12-211">まず、[**OnPointerPressed**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L179-L313) メソッド使用して、ユーザーが最初にムーブ四角形またはファイア四角形内を押したときの動作を決定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-211">We'll first determine what happens when the user first presses within the move or fire rectangles using the [**OnPointerPressed**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L179-L313) method.</span></span>
<span data-ttu-id="2cd12-212">ここで、ユーザーがコントロールにタッチしているかどうか、およびポインターが既にそのコントローラー内にあるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-212">Here we check where they're touching a control and if a pointer is already in that controller.</span></span> <span data-ttu-id="2cd12-213">これが特定のコントロールにタッチした最初の指である場合は、次の処理を行います。</span><span class="sxs-lookup"><span data-stu-id="2cd12-213">If this is the first finger to touch the specific control, we do the following.</span></span>
- <span data-ttu-id="2cd12-214">タッチの位置を 2D ベクトルとして **m \_moveFirstDown** または **m\_fireFirstDown** に格納します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-214">Store the location of the touchdown in **m\_moveFirstDown** or **m\_fireFirstDown** as a 2D vector.</span></span>
- <span data-ttu-id="2cd12-215">ポインター ID を **m \_movePointerID** または **m\_firePointerID** に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-215">Assign the pointer ID to **m\_movePointerID** or **m\_firePointerID**.</span></span>
- <span data-ttu-id="2cd12-216">コントロールのアクティブなポインターが取得できたら、適切な **InUse** フラグ (**m\_moveInUse** または **m\_fireInUse**) を `true` に設定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-216">Set the proper **InUse** flag (**m\_moveInUse** or **m\_fireInUse**) to `true` since we now have an active pointer for that control.</span></span>


```cpp
    PointerPoint^ point = args->CurrentPoint;
    uint32 pointerID = point->PointerId;
    Point pointerPosition = point->Position;
    PointerPointProperties^ pointProperties = point->Properties;
    auto pointerDevice = point->PointerDevice;
    auto pointerDeviceType = pointerDevice->PointerDeviceType;

    XMFLOAT2 position = XMFLOAT2(pointerPosition.X, pointerPosition.Y);

    case MoveLookControllerState::Active:
        switch (pointerDeviceType)
        {
        case Windows::Devices::Input::PointerDeviceType::Touch:
            // Check to see if this pointer is in the move control.
            if (position.x > m_moveUpperLeft.x &&
                position.x < m_moveLowerRight.x &&
                position.y > m_moveUpperLeft.y &&
                position.y < m_moveLowerRight.y)
            {
                if (!m_moveInUse)         // If no pointer is in this control yet:
                {
                    // Process a DPad touch down event.
                    m_moveFirstDown = position;                 // Save the location of the initial contact
                    m_movePointerID = pointerID;                // Store the pointer using this control
                    m_moveInUse = true;                         // Set InUse flag to signal there is an active move pointer
                }
            }
            // Check to see if this pointer is in the fire control.
            else if (position.x > m_fireUpperLeft.x &&
                position.x < m_fireLowerRight.x &&
                position.y > m_fireUpperLeft.y &&
                position.y < m_fireLowerRight.y)
            {
                if (!m_fireInUse)
                {
                    m_fireLastPoint = position;     // Save the location of the initial contact
                    m_firePointerID = pointerID;    // Store the pointer using this control
                    m_fireInUse = true;             // Set InUse flag to signal there is an active fire pointer
                }
            }
            ...
```


<span data-ttu-id="2cd12-217">ユーザーがムーブ コントロールとファイア コントロールのいずれにタッチしているかを特定できたら、プレイヤーが押した指を移動しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-217">Now that we've determined whether the user is touching a move or fire control, we see if the player is making any movements with their pressed finger.</span></span>
<span data-ttu-id="2cd12-218">[**MoveLookController::OnPointerMoved**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L317-L395) メソッドを使用して、どのポインターが移動したかを確認した後、新しい位置を 2D ベクトルとして格納します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-218">Using the [**MoveLookController::OnPointerMoved**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L317-L395) method, we check what pointer has moved and then store its new position as a 2D vector.</span></span>  


```cpp
    PointerPoint^ point = args->CurrentPoint;
    uint32 pointerID = point->PointerId;
    Point pointerPosition = point->Position;
    PointerPointProperties^ pointProperties = point->Properties;
    auto pointerDevice = point->PointerDevice;

    XMFLOAT2 position = XMFLOAT2(pointerPosition.X, pointerPosition.Y);     // convert to allow math
    
    switch (m_state)
    {
    case MoveLookControllerState::Active:
        // Decide which control this pointer is operating.
        
        // Move control
        if (pointerID == m_movePointerID)
        {
            m_movePointerPosition = position;       // Save the current position.
        }
        // Look control
        else if (pointerID == m_lookPointerID)
        {
            // ...
        }
        // Fire control
        else if (pointerID == m_firePointerID)
        {
            m_fireLastPoint = position;
        }
```


<span data-ttu-id="2cd12-219">ユーザーはコントロール内のジェスチャを行った後、ポインターを離します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-219">Once the user has made their gestures within the controls, they'll release the pointer.</span></span> <span data-ttu-id="2cd12-220">[**MoveLookController::OnPointerReleased**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) メソッドを使用して、離されたポインターを特定し、一連のリセットを実行します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-220">Using the [**MoveLookController::OnPointerReleased**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) method, we determine which pointer has been released and do a series of resets.</span></span>


<span data-ttu-id="2cd12-221">ムーブ コントロールが離された場合は、次の処理を行います。</span><span class="sxs-lookup"><span data-stu-id="2cd12-221">If the move control has been released, we do the following.</span></span>
- <span data-ttu-id="2cd12-222">すべての方向へのプレイヤーの速度を `0` に設定し、ゲーム内でのプレイヤーの移動を防ぎます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-222">Set the velocity of the player to `0` in all directions to prevent them from moving in the game.</span></span>
- <span data-ttu-id="2cd12-223">ユーザーはもうムーブ コントローラーにタッチしていないため、**m\_moveInUse** を `false` に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-223">Switch **m\_moveInUse** to `false` since the user is no longer touching the move controller.</span></span>
- <span data-ttu-id="2cd12-224">ムーブ コントローラーにはポインターがなくなったため、ムーブ ポインター ID を `0` に設定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-224">Set the move pointer ID to `0` since there's no longer a pointer in the move controller.</span></span>

```cpp
       if (pointerID == m_movePointerID)
        {
            m_velocity = XMFLOAT3(0, 0, 0);      // Stop on release.
            m_moveInUse = false;
            m_movePointerID = 0;
        }
```


<span data-ttu-id="2cd12-225">ファイア コントロールが離された場合、ファイア コントロールにポインターがなくなったため、必要な処理は **m_fireInUse** フラグを `false` に切り替えて、ファイア ポインター ID を `0` に設定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-225">For the fire control, if it has been released all we do is switch the **m_fireInUse** flag to `false` and the fire pointer ID to `0` since there's no longer a pointer in the fire control.</span></span>
```cpp
        else if (pointerID == m_firePointerID)
        {
            m_fireInUse = false;
            m_firePointerID = 0;
        }
```

### <a name="look-controller"></a><span data-ttu-id="2cd12-226">ルック コントローラー</span><span class="sxs-lookup"><span data-stu-id="2cd12-226">Look controller</span></span>
<span data-ttu-id="2cd12-227">画面の使用されていない領域用のタッチ デバイスのポインター イベントは、ルック コントローラーとして扱います。</span><span class="sxs-lookup"><span data-stu-id="2cd12-227">We treat touch device pointer events for the unused regions of the screen as the look controller.</span></span> <span data-ttu-id="2cd12-228">このゾーンで指をスライドさせると、プレイヤー カメラのピッチとヨー (回転) が変化します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-228">Sliding your finger around this zone changes the pitch and yaw (rotation) of the player camera.</span></span>


<span data-ttu-id="2cd12-229">**MoveLookController::OnPointerPressed** イベントがタッチ デバイスのこの領域で発生し、ゲームの状態が **Active** に設定されている場合は、ポインター ID が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-229">If the **MoveLookController::OnPointerPressed** event is raised on a touch device in this region and the game state is set to **Active**, it's assigned a pointer ID.</span></span>

```cpp
    if (!m_lookInUse)   // If no pointer is in this control yet:
    {
        m_lookLastPoint = position;                   // Save the pointer for a later move.
        m_lookPointerID = pointerID;                  // Store the pointer using this control.
        m_lookLastDelta.x = m_lookLastDelta.y = 0;    // These are for smoothing.
        m_lookInUse = true;
    }
```
<span data-ttu-id="2cd12-230">**MoveLookController::OnPointerPressed** メソッドのコード一式については、[GitHub](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L252-L259) で確認できます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-230">You can see the complete code for the **MoveLookController::OnPointerPressed** method on [GitHub](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L252-L259).</span></span>




<span data-ttu-id="2cd12-231">ここで、**MoveLookController** は、ルック領域に対応する特定の変数に、イベントを発生させたポインターのポインターの ID を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-231">Here the **MoveLookController** assigns the pointer ID for the pointer that fired the event to a specific variable that corresponds to the look region.</span></span> <span data-ttu-id="2cd12-232">ルック領域内でタッチが発生した場合、**m\_lookPointerID** 変数は、そのイベントを発生させたポインターの ID に設定されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-232">In the case of a touch occuring in the look region, the **m\_lookPointerID** variable is set to the pointer ID that fired the event.</span></span> <span data-ttu-id="2cd12-233">ブール変数 **m\_lookInUse** も、コントロールがまだ離されていないことを示すために設定されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-233">A boolean variable, **m\_lookInUse**, is also set to indicate that the control has not yet been released.</span></span>

<span data-ttu-id="2cd12-234">次は、このゲーム サンプルで [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) タッチ スクリーン イベントを処理する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="2cd12-234">Now, let's look at how the game sample handles the [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) touch screen event.</span></span>


<span data-ttu-id="2cd12-235">**MoveLookController::OnPointerMoved** メソッド内で、どのような種類のポインター ID がイベントに割り当てられているかを確認します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-235">Within the **MoveLookController::OnPointerMoved** method, we check to see what kind of pointer ID has been assigned to the event.</span></span> <span data-ttu-id="2cd12-236">**m_lookPointerID** の場合は、ポインターの位置の変更を計算します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-236">If it's **m_lookPointerID**, we calculate the change in position of the pointer.</span></span>
<span data-ttu-id="2cd12-237">このデルタを使用して、どの程度の回転を変更する必要があるかを計算します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-237">We then use this delta to calculate how much the rotation should change.</span></span> <span data-ttu-id="2cd12-238">最後に、プレイヤーの回転を変更するためにゲームで使用される **m \_pitch** と **m \_yaw** を更新します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-238">Finally we're at a point where we can update the **m\_pitch** and **m\_yaw** to be used in the game to change the player rotation.</span></span> 

```cpp
    else if (pointerID == m_lookPointerID)     // This is the look pointer.
    {
        // Look control
        XMFLOAT2 pointerDelta;
        pointerDelta.x = position.x - m_lookLastPoint.x;        // How far did the pointer move.
        pointerDelta.y = position.y - m_lookLastPoint.y;

        XMFLOAT2 rotationDelta;
        rotationDelta.x = pointerDelta.x * MoveLookConstants::RotationGain;       // Scale for control sensitivity.
        rotationDelta.y = pointerDelta.y * MoveLookConstants::RotationGain;
        m_lookLastPoint = position;                             // Save for the next time through.

        // Update our orientation based on the command.
        m_pitch -= rotationDelta.y;
        m_yaw   += rotationDelta.x;

        // Limit pitch to straight up or straight down.
        float limit = XM_PI / 2.0f - 0.01f;
        m_pitch = __max(-limit, m_pitch);
        m_pitch = __min(+limit, m_pitch);M_PI / 2.0f, m_pitch);
        }
```





<span data-ttu-id="2cd12-239">確認する最後の要素は、このゲーム サンプルで [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) タッチ スクリーン イベントがどのように処理されているかです。</span><span class="sxs-lookup"><span data-stu-id="2cd12-239">The last piece we'll look at is how the game sample handles the [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) touch screen event.</span></span>
<span data-ttu-id="2cd12-240">ユーザーがタッチ ジェスチャを終了し、画面から指を離すと、[**MoveLookController::OnPointerReleased**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) が開始されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-240">Once the user has finished the touch gesture and removed their finger from the screen, [**MoveLookController::OnPointerReleased**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) is initiated.</span></span>
<span data-ttu-id="2cd12-241">[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) イベントを発生させたポインターの ID が前に記録されたムーブ ポインターの ID である場合は、プレイヤーがルック領域から指を離したため、**MoveLookController** は速度を `0` に設定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-241">If the ID of the pointer that fired the [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) event is the ID of the previously recorded move pointer, the **MoveLookController** sets the velocity to `0` because the player has stopped touching the look area.</span></span>

```cpp
    else if (pointerID == m_lookPointerID)
    {
        m_lookInUse = false;
        m_lookPointerID = 0;
    }
```





## <a name="adding-mouse-and-keyboard-support"></a><span data-ttu-id="2cd12-242">マウスとキーボードのサポートの追加</span><span class="sxs-lookup"><span data-stu-id="2cd12-242">Adding mouse and keyboard support</span></span>


<span data-ttu-id="2cd12-243">このゲームには、キーボードとマウス用に次のコントロール レイアウトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2cd12-243">This game has the following control layout for keyboard and mouse.</span></span>

<span data-ttu-id="2cd12-244">ユーザー入力</span><span class="sxs-lookup"><span data-stu-id="2cd12-244">User input</span></span> | <span data-ttu-id="2cd12-245">アクション</span><span class="sxs-lookup"><span data-stu-id="2cd12-245">Action</span></span>
:------- | :--------
<span data-ttu-id="2cd12-246">W</span><span class="sxs-lookup"><span data-stu-id="2cd12-246">W</span></span> | <span data-ttu-id="2cd12-247">プレイヤーを前へ移動します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-247">Move player forward</span></span>
<span data-ttu-id="2cd12-248">A</span><span class="sxs-lookup"><span data-stu-id="2cd12-248">A</span></span> | <span data-ttu-id="2cd12-249">プレイヤーを左へ移動します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-249">Move player left</span></span>
<span data-ttu-id="2cd12-250">S</span><span class="sxs-lookup"><span data-stu-id="2cd12-250">S</span></span> | <span data-ttu-id="2cd12-251">プレイヤーを後ろへ移動します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-251">Move player backward</span></span>
<span data-ttu-id="2cd12-252">D</span><span class="sxs-lookup"><span data-stu-id="2cd12-252">D</span></span> | <span data-ttu-id="2cd12-253">プレイヤーを右へ移動します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-253">Move player right</span></span>
<span data-ttu-id="2cd12-254">X</span><span class="sxs-lookup"><span data-stu-id="2cd12-254">X</span></span> | <span data-ttu-id="2cd12-255">ビューを上へ移動します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-255">Move view up</span></span>
<span data-ttu-id="2cd12-256">Space キー</span><span class="sxs-lookup"><span data-stu-id="2cd12-256">Space bar</span></span> | <span data-ttu-id="2cd12-257">ビューを下へ移動します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-257">Move view down</span></span>
<span data-ttu-id="2cd12-258">P</span><span class="sxs-lookup"><span data-stu-id="2cd12-258">P</span></span> | <span data-ttu-id="2cd12-259">ゲームを一時停止します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-259">Pause the game</span></span>
<span data-ttu-id="2cd12-260">マウスの移動</span><span class="sxs-lookup"><span data-stu-id="2cd12-260">Mouse movement</span></span> | <span data-ttu-id="2cd12-261">カメラ ビューの回転角度 (ピッチとヨー) を変更します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-261">Change the rotation (the pitch and yaw) of the camera view</span></span>
<span data-ttu-id="2cd12-262">マウスの左ボタン</span><span class="sxs-lookup"><span data-stu-id="2cd12-262">Left mouse button</span></span> | <span data-ttu-id="2cd12-263">球体を発射します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-263">Fire a sphere</span></span>


<span data-ttu-id="2cd12-264">キーボードを使用するために、ゲーム サンプルは、[**MoveLookController::InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L84-L88) メソッド内で 2 つの新しいイベント [**CoreWindow::KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208271) と [**CoreWindow::KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208270) を登録します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-264">To use the keyboard, the game sample registers two new events, [**CoreWindow::KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208271) and [**CoreWindow::KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208270), within the [**MoveLookController::InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L84-L88) method.</span></span> <span data-ttu-id="2cd12-265">これらのイベントは、キーを押す操作と離す操作を処理します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-265">These events handle the press and release of a key.</span></span>

```cpp
window->KeyDown +=
        ref new TypedEventHandler<CoreWindow^, KeyEventArgs^>(this, &MoveLookController::OnKeyDown);

window->KeyUp +=
        ref new TypedEventHandler<CoreWindow^, KeyEventArgs^>(this, &MoveLookController::OnKeyUp);
```

<span data-ttu-id="2cd12-266">マウスは、ポインターを使いますが、タッチ コントロールとは扱いが少し異なります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-266">The mouse is treated a little differently from the touch controls even though it uses a pointer.</span></span> <span data-ttu-id="2cd12-267">このコントロール レイアウトに合わせて、**MoveLookController** は、マウスが移動されるたびにカメラを回転させ、マウスの左ボタンが押されたときに発射します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-267">To align with our control layout, the **MoveLookController** rotates the camera whenever the mouse is moved, and fires when the left mouse button is pressed.</span></span>


<span data-ttu-id="2cd12-268">これは、**MoveLookController** の [**OnPointerPressed**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L179-L313) メソッドで処理されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-268">This is handled in the [**OnPointerPressed**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L179-L313) method of the **MoveLookController**.</span></span>

<span data-ttu-id="2cd12-269">このメソッドで、[`Windows::Devices::Input::PointerDeviceType`](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Input.PointerDeviceType) 列挙型を使って、使用されているポインター デバイスの種類を確認します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-269">In this method we check to see what type of pointer device is being used with the [`Windows::Devices::Input::PointerDeviceType`](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Input.PointerDeviceType) enum.</span></span> <span data-ttu-id="2cd12-270">ゲームが **Active** であり、**PointerDeviceType** が **Touch** ではない場合は、マウス入力と見なします。</span><span class="sxs-lookup"><span data-stu-id="2cd12-270">If the game is **Active** and the **PointerDeviceType** isn't **Touch**, we assume it's mouse input.</span></span>

```cpp
    case MoveLookControllerState::Active:
        switch (pointerDeviceType)
        {
        case Windows::Devices::Input::PointerDeviceType::Touch:
            // Behavior for touch controls
        
        default:
        // Behavior for mouse controls
            bool rightButton = pointProperties->IsRightButtonPressed;
            bool leftButton = pointProperties->IsLeftButtonPressed;

            if (!m_autoFire && (!m_mouseLeftInUse && leftButton))
            {
                m_firePressed = true;
            }

            if (!m_mouseInUse)
            {
                m_mouseInUse = true;
                m_mouseLastPoint = position;
                m_mousePointerID = pointerID;
                m_mouseLeftInUse = leftButton;
                m_mouseRightInUse = rightButton;
                m_lookLastDelta.x = m_lookLastDelta.y = 0;          // These are for smoothing.
            }
            break;
        }
```

<span data-ttu-id="2cd12-271">プレイヤーがいずれかのマウス ボタンを押すことをやめると、[CoreWindow::PointerReleased](https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreWindow.PointerReleased) マウス イベントが発生し、[MoveLookController::OnPointerReleased](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) メソッドが呼び出されて、入力が完了します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-271">When the player stops pressing one of the mouse buttons, the [CoreWindow::PointerReleased](https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreWindow.PointerReleased) mouse event is raised, calling the [MoveLookController::OnPointerReleased](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) method, and the input is complete.</span></span> <span data-ttu-id="2cd12-272">ここで、押していたマウスの左ボタンから指を離した場合、球体の発射は停止します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-272">At this point, spheres will stop firing if the left mouse button was being pressed and is now released.</span></span> <span data-ttu-id="2cd12-273">ルックは常に有効であるため、ゲームでは同じマウス ポインターを使い続けて、進行中のルック イベントを追跡します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-273">Because look is always enabled, the game continues to use the same mouse pointer to track the ongoing look events.</span></span>

```cpp
    case MoveLookControllerState::Active:
        // Touch points
        if (pointerID == m_movePointerID)
        {
            // Stop movement
        }
        else if (pointerID == m_lookPointerID)
        {
            // Stop look rotation
        }
        // Fire button has been released
        else if (pointerID == m_firePointerID)
        {
            // Stop firing
        }
        // Mouse point
        else if (pointerID == m_mousePointerID)
        {
            bool rightButton = pointProperties->IsRightButtonPressed;
            bool leftButton = pointProperties->IsLeftButtonPressed;

            // Mouse no longer in use so stop firing
            m_mouseInUse = false;

            // Don't clear the mouse pointer ID so that Move events still result in Look changes.
            // m_mousePointerID = 0;
            m_mouseLeftInUse = leftButton;
            m_mouseRightInUse = rightButton;
        }
        break;
    }
}
```



<span data-ttu-id="2cd12-274">次に、サポートしている最後のコントロールの種類である、ゲームパッドを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="2cd12-274">Now let's look at the last control type we'll be supporting: gamepads.</span></span> <span data-ttu-id="2cd12-275">ゲームパッドは、ポインター オブジェクトを使わないため、タッチ コントロールやマウス コントロールとは別に処理されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-275">Gamepads are handled separately from the touch and mouse controls since they doesn't use the pointer object.</span></span> <span data-ttu-id="2cd12-276">このため、いくつかの新しいイベント ハンドラーとメソッドを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-276">Because of this, a few new event handlers and methods will need to be added.</span></span>

## <a name="adding-gamepad-support"></a><span data-ttu-id="2cd12-277">ゲームパッドのサポートの追加</span><span class="sxs-lookup"><span data-stu-id="2cd12-277">Adding gamepad support</span></span>


<span data-ttu-id="2cd12-278">このゲームでは、ゲームパッドのサポートは [Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) API の呼び出しによって追加されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-278">For this game, gamepad support is added by calls to the [Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) APIs.</span></span> <span data-ttu-id="2cd12-279">この一連の API は、レーシング ハンドルやフライト スティックなどの、ゲーム コントローラー入力へのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-279">This set of APIs provides access to game controller inputs like racing wheels and flight sticks.</span></span> 


<span data-ttu-id="2cd12-280">このゲームのゲームパッド コントロールは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-280">The following will be our gamepad controls.</span></span>

<span data-ttu-id="2cd12-281">ユーザー入力</span><span class="sxs-lookup"><span data-stu-id="2cd12-281">User input</span></span> | <span data-ttu-id="2cd12-282">アクション</span><span class="sxs-lookup"><span data-stu-id="2cd12-282">Action</span></span>
:------- | :--------
<span data-ttu-id="2cd12-283">左アナログ スティック</span><span class="sxs-lookup"><span data-stu-id="2cd12-283">Left analog stick</span></span> | <span data-ttu-id="2cd12-284">プレイヤーを移動します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-284">Move player</span></span>
<span data-ttu-id="2cd12-285">右アナログ スティック</span><span class="sxs-lookup"><span data-stu-id="2cd12-285">Right analog stick</span></span> | <span data-ttu-id="2cd12-286">カメラ ビューの回転角度 (ピッチとヨー) を変更します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-286">Change the rotation (the pitch and yaw) of the camera view</span></span>
<span data-ttu-id="2cd12-287">右トリガー</span><span class="sxs-lookup"><span data-stu-id="2cd12-287">Right trigger</span></span> | <span data-ttu-id="2cd12-288">球体を発射します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-288">Fire a sphere</span></span>
<span data-ttu-id="2cd12-289">スタート/メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="2cd12-289">Start/Menu button</span></span> | <span data-ttu-id="2cd12-290">ゲームを一時停止または再開します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-290">Pause or resume the game</span></span>




<span data-ttu-id="2cd12-291">[**InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L68-L103) メソッドに、ゲームパッドが[追加された](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1100-L1105)か、[削除された](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1109-L1114)かを判断するために 2 つの新しいイベントを追加します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-291">In the [**InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L68-L103) method, we add two new events to determine if a gamepad has been [added](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1100-L1105) or [removed](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1109-L1114).</span></span> <span data-ttu-id="2cd12-292">これらのイベントは **m_gamepadsChanged** プロパティを更新します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-292">These events update the **m_gamepadsChanged** property.</span></span> <span data-ttu-id="2cd12-293">これは、既知のゲームパッドの一覧が変更されたかどうかをチェックする**UpdatePollingDevices**メソッドで使用されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-293">This is used in the **UpdatePollingDevices** method to check if the list of known gamepads has changed.</span></span> 

```cpp
    // Detect gamepad connection and disconnection events.
    Gamepad::GamepadAdded +=
        ref new EventHandler<Gamepad^>(this, &MoveLookController::OnGamepadAdded);

    Gamepad::GamepadRemoved +=
        ref new EventHandler<Gamepad^>(this, &MoveLookController::OnGamepadRemoved);
```

### <a name="the-updatepollingdevices-method"></a><span data-ttu-id="2cd12-294">UpdatePollingDevices メソッド</span><span class="sxs-lookup"><span data-stu-id="2cd12-294">The UpdatePollingDevices method</span></span>

<span data-ttu-id="2cd12-295">**MoveLookController** インスタンスの [**UpdatePollingDevices**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L654-L782) メソッドは、すぐにゲームパッドが接続されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-295">The [**UpdatePollingDevices**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L654-L782) method of the **MoveLookController** instance immediately checks to see if a gamepad is connected.</span></span> <span data-ttu-id="2cd12-296">ゲームパッドが接続されている場合は、[**Gamepad.GetCurrentReading**](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.GetCurrentReading) を使用して、その状態の読み取りを開始します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-296">If one is, we'll start reading its state with [**Gamepad.GetCurrentReading**](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.GetCurrentReading).</span></span> <span data-ttu-id="2cd12-297">これによって [**GamepadReading**](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.GamepadReading) 構造体が返され、クリックされていたボタンや移動したサムスティックを確認できます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-297">This returns the [**GamepadReading**](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.GamepadReading) struct, allowing us to check what buttons have been clicked or thumbsticks moved.</span></span>


<span data-ttu-id="2cd12-298">ゲームの状態が **WaitForInput** である場合、ゲームを再開できるように、コントローラーのスタート/メニュー ボタンのみをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="2cd12-298">If the state of the game is **WaitForInput**, we only listen for the Start/Menu button of the controller so that the game can be resumed.</span></span>


<span data-ttu-id="2cd12-299">状態が **Active** である場合は、ユーザーの入力を確認し、どのようなゲーム内アクションが発生する必要があるかを特定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-299">If it's **Active**, we check the user's input and determine what in-game action needs to happen.</span></span>
<span data-ttu-id="2cd12-300">たとえば、ユーザーが特定の方向に左アナログ スティックを動かした場合、これによって、ゲームはスティックを動かした方向にプレイヤーを移動する必要があることを認知します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-300">For instance, if the user moved the left analog stick in a specific direction, this lets the game know we need to move the player in the direction the stick is being moved.</span></span> <span data-ttu-id="2cd12-301">特定の方向へのスティックの動きは、**デッド ゾーン**の半径より大きく登録される必要があります。大きく登録されないと、何も起きません。</span><span class="sxs-lookup"><span data-stu-id="2cd12-301">The movement of the stick in a specific direction must register as larger than the radius of the **dead zone**; otherwise, nothing will happen.</span></span> <span data-ttu-id="2cd12-302">このデッド ゾーンの半径は、"ドリフト" を防止するために必要です。この機能では、プレイヤーの指がスティック上にあるときに、指のわずかな動きをコントローラーが感知します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-302">This dead zone radius is necessary to prevent "drifting," which is when the controller picks up small movements from the player's thumb as it rests on the stick.</span></span> <span data-ttu-id="2cd12-303">デッド ゾーンがない場合、ユーザーはコントロールの感度が高すぎると感じることがあります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-303">Without dead zones, the controls can appear too sensitive to the user.</span></span>


<span data-ttu-id="2cd12-304">サム スティックの入力は、x 軸と y 軸の両方について -1 ～ 1 の範囲です。</span><span class="sxs-lookup"><span data-stu-id="2cd12-304">Thumbstick input is between -1 and 1 for both the x and y axis.</span></span> <span data-ttu-id="2cd12-305">次の定数は、サムスティックのデッドゾーンの半径を指定します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-305">The following consant specifies the radius of the thumbstick dead zone.</span></span>

```cpp
#define THUMBSTICK_DEADZONE 0.25f
```

<span data-ttu-id="2cd12-306">この変数を使用して、アクション可能なサムスティックの入力の処理を開始します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-306">Using this variable, we'll then begin processing actionable thumbstick input.</span></span> <span data-ttu-id="2cd12-307">いずれかの軸で値が [-1, -.26] または [.26, 1] から移動が発生します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-307">Movement would occur with a value from [-1, -.26] or [.26, 1] on either axis.</span></span>

![サムスティックのデッド ゾーン](images/simple-dx-game-controls-deadzone.png)

<span data-ttu-id="2cd12-309">**UpdatePollingDevices** メソッドの次の部分は、左右のサム スティックを処理します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-309">This piece of the **UpdatePollingDevices** method handles the left and right thumbsticks.</span></span>
<span data-ttu-id="2cd12-310">各スティックの X と Y の値について、デッド ゾーンの外側であるかどうかがチェックされます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-310">Each stick's X and Y values are checked to see if they are outside of the dead zone.</span></span> <span data-ttu-id="2cd12-311">いずれかまたは両方がこれに該当する場合、対応するコンポーネントを更新します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-311">If one or both are, we'll update the corresponding component.</span></span>
<span data-ttu-id="2cd12-312">たとえば、左サムスティックが X 軸に沿って左に移動された場合、**m_moveCommand**ベクトルの **x** コンポーネントに -1 を加算します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-312">For example, if the left thumbstick is being moved left along the X axis, we'll add -1 to the **x** component of the **m_moveCommand** vector.</span></span> <span data-ttu-id="2cd12-313">このベクトルは、すべてのデバイスのすべての動きを集計するために使用されるもので、後でプレイヤーが移動する場所を計算するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-313">This vector is what will be used to aggregate all movements across all devices and will later be used to calculate where the player should move.</span></span> 


```cpp
        // Use the left thumbstick to control the eye point position (position of the player)

        // Check if left thumbstick is outside of dead zone on x axis
        if (reading.LeftThumbstickX > THUMBSTICK_DEADZONE ||
            reading.LeftThumbstickX < -THUMBSTICK_DEADZONE)
        {
            // Get value of left thumbstick's position on x axis
            float x = static_cast<float>(reading.LeftThumbstickX);
            // Set the x of the move vector to 1 if the stick is being moved right.
            // Set to -1 if moved left. 
            m_moveCommand.x -= (x > 0) ? 1 : -1;
        }

        // Check if left thumbstick is outside of dead zone on y axis
        if (reading.LeftThumbstickY > THUMBSTICK_DEADZONE ||
            reading.LeftThumbstickY < -THUMBSTICK_DEADZONE)
        {
            // Get value of left thumbstick's position on y axis
            float y = static_cast<float>(reading.LeftThumbstickY);
            // Set the y of the move vector to 1 if the stick is being moved forward.
            // Set to -1 if moved backwards. 
            m_moveCommand.y += (y > 0) ? 1 : -1;
        }

```

<span data-ttu-id="2cd12-314">左スティックが動きを制御するのと同様に、右スティックはカメラの回転を制御します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-314">Similar to how the left stick controls movement, the right stick controls the rotation of the camera.</span></span>


<span data-ttu-id="2cd12-315">右サムスティックの動作は、マウスとキーボード コントロールの設定でのマウス移動の動作と一致します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-315">The right thumb stick behavior aligns with the behavior of mouse movement in our mouse and keyboard control setup.</span></span>
<span data-ttu-id="2cd12-316">スティックがデッド ゾーン外にある場合は、ポインターの現在の位置と、ユーザーが現在見ようとしている位置の差を計算します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-316">If the stick is outside of the dead zone, we calculate the difference between the current pointer position and where the user is now trying to look.</span></span>
<span data-ttu-id="2cd12-317">このポインターの位置の変化 (**pointerDelta**) を使用して、後で **Update** メソッドで適用されるカメラの回転のピッチとヨーが更新されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-317">This change in pointer position (**pointerDelta**) is then used to update the pitch and yaw of the camera rotation that later get applied in our **Update** method.</span></span>
<span data-ttu-id="2cd12-318">**pointerDelta** ベクトルには見覚えがあるかもしれません。これは、マウスとタッチ入力でポインターの位置の変化を追跡するために、[MoveLookController::OnPointerMoved](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L318-L395) メソッドでも使用されています。</span><span class="sxs-lookup"><span data-stu-id="2cd12-318">The **pointerDelta** vector may look familiar because it's also used in the [MoveLookController::OnPointerMoved](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L318-L395) method to keep track of change in pointer position for our mouse and touch inputs.</span></span>


```cpp
        // Use the right thumbstick to control the look at position

        XMFLOAT2 pointerDelta;

        // Check if right thumbstick is outside of deadzone on x axis
        if (reading.RightThumbstickX > THUMBSTICK_DEADZONE ||
            reading.RightThumbstickX < -THUMBSTICK_DEADZONE)
        {
            float x = static_cast<float>(reading.RightThumbstickX);
            // Register the change in the pointer along the x axis
            pointerDelta.x = x * x * x; 
        }
        // No actionable thumbstick movement. Register no change in pointer.
        else
        {
            pointerDelta.x = 0.0f;
        }
        // Check if right thumbstick is outside of deadzone on y axis
        if (reading.RightThumbstickY > THUMBSTICK_DEADZONE ||
            reading.RightThumbstickY < -THUMBSTICK_DEADZONE)
        {
            float y = static_cast<float>(reading.RightThumbstickY);
            // Register the change in the pointer along the y axis
            pointerDelta.y = y * y * y;
        }
        else
        {
            pointerDelta.y = 0.0f;
        }

        XMFLOAT2 rotationDelta;
        rotationDelta.x = pointerDelta.x *  0.08f;       // Scale for control sensitivity.
        rotationDelta.y = pointerDelta.y *  0.08f;

        // Update our orientation based on the command.
        m_pitch += rotationDelta.y;
        m_yaw += rotationDelta.x;

        // Limit pitch to straight up or straight down.
        m_pitch = __max(-XM_PI / 2.0f, m_pitch);
        m_pitch = __min(+XM_PI / 2.0f, m_pitch);
```

<span data-ttu-id="2cd12-319">このゲームのコントロールは、球体を発射する機能がなければ完成しません。</span><span class="sxs-lookup"><span data-stu-id="2cd12-319">The game's controls wouldn't be complete without the ability to fire spheres!</span></span>


<span data-ttu-id="2cd12-320">この **UpdatePollingDevices** メソッドは、右のトリガーが押されているかどうかも確認します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-320">This **UpdatePollingDevices** method also checks if the right trigger is being pressed.</span></span> <span data-ttu-id="2cd12-321">右のトリガーが押された場合、**m_firePressed** プロパティは true になり、球体の発射を開始する必要があることをゲームに通知します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-321">If it is, our **m_firePressed** property is flipped to true, signaling to the game that spheres should start firing.</span></span>
```cpp
    if (reading.RightTrigger > TRIGGER_DEADZONE)
    {
        if (!m_autoFire && !m_gamepadTriggerInUse)
        {
            m_firePressed = true;
        }

        m_gamepadTriggerInUse = true;
    }
    else
    {
        m_gamepadTriggerInUse = false;
    }
```


## <a name="the-update-method"></a><span data-ttu-id="2cd12-322">Update メソッド</span><span class="sxs-lookup"><span data-stu-id="2cd12-322">The Update method</span></span>

<span data-ttu-id="2cd12-323">締めくくりとして、[**Update**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1005-L1096) メソッドについて深く掘り下げてみましょう。</span><span class="sxs-lookup"><span data-stu-id="2cd12-323">To wrap things up, let's dig deeper into the [**Update**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1005-L1096) method.</span></span>
<span data-ttu-id="2cd12-324">このメソッドは、プレイヤーがサポートされている入力を使用して行ったすべての動きや回転をマージして、ゲーム ループがアクセスする速度ベクトルを生成し、ピッチとヨーの値を更新します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-324">This method merges any movements or rotations that the player made with any supported input to generate a velocity vector and update our pitch and yaw values for our game loop to access.</span></span>


<span data-ttu-id="2cd12-325">**Update** メソッドは、[**UpdatePollingDevices**](#the-updatepollingdevices-method) を呼び出してコントローラーの状態を更新することから処理を開始します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-325">The **Update** method kicks things off by calling [**UpdatePollingDevices**](#the-updatepollingdevices-method) to update the state of the controller.</span></span> <span data-ttu-id="2cd12-326">また、このメソッドは、ゲームパッドからのすべての入力を収集し、その動きを **m_moveCommand** ベクトルに追加します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-326">This method also gathers any input from a gamepad and adds its movements to the **m_moveCommand** vector.</span></span> 

<span data-ttu-id="2cd12-327">このサンプルの **Update** メソッドでは、以下の入力の確認を実行します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-327">In our **Update** method we then perform the following input checks.</span></span>
- <span data-ttu-id="2cd12-328">プレイヤーがムーブ コントローラーの四角形を使用している場合は、ポインターの位置の変化を確認し、それを使用してユーザーがコントローラーのデッド ゾーンの外側にポインターを移動したかどうかを計算します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-328">If the player is using the move controller rectangle, we'll then determine the change in pointer position and use that to calculate if the user has moved the pointer out of the controller's dead zone.</span></span> <span data-ttu-id="2cd12-329">デッド ゾーンの外側である場合、仮想ジョイスティックの値を使用して **m_moveCommand** ベクトル プロパティが更新されます。</span><span class="sxs-lookup"><span data-stu-id="2cd12-329">If outside of the dead zone, the **m_moveCommand** vector property is then updated with the virtual joystick value.</span></span>
- <span data-ttu-id="2cd12-330">移動のキーボード入力のいずれかが押されている場合、**m_moveCommand** ベクトルの対応するコンポーネントに `1.0f` または `-1.0f` の値が追加されます。`1.0f` は前進、`-1.0f` は後退です。</span><span class="sxs-lookup"><span data-stu-id="2cd12-330">If any of the movement keyboard inputs are pressed, a value of `1.0f` or `-1.0f` are added in the corresponding component of the **m_moveCommand** vector &mdash; `1.0f` for forward, and `-1.0f` for backward.</span></span>


<span data-ttu-id="2cd12-331">すべての移動入力を考慮した後、**m_moveCommand** ベクトルに対していくつかの計算を実行し、ゲーム ワールドでのプレイヤーの方向を表す新しいベクトルを生成します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-331">Once all movement input has been taken into account, we then run the **m_moveCommand** vector through some calculations to generate a new vector that represents the direction of the player with regards to the game world.</span></span>
<span data-ttu-id="2cd12-332">次に、ワールドでの動きを取得し、それをその方向への速度としてプレイヤーに適用します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-332">We then take our movements in relation to the world and apply them to the player as velocity in that direction.</span></span>
<span data-ttu-id="2cd12-333">最後に、**m_moveCommand** ベクトルを `(0.0f, 0.0f, 0.0f)` にリセットして、次のゲーム フレームを処理できるようにすべてを準備します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-333">Finally we reset the **m_moveCommand** vector to `(0.0f, 0.0f, 0.0f)` so that everything is ready for the next game frame.</span></span>


```cpp
void MoveLookController::Update()
{
    // Get any gamepad input and update state
    UpdatePollingDevices();

    // Get change in 
    if (m_moveInUse)
    {
        XMFLOAT2 pointerDelta;

        pointerDelta.x = m_movePointerPosition.x - m_moveFirstDown.x;
        pointerDelta.y = m_movePointerPosition.y - m_moveFirstDown.y;

        // Figure out the command from the virtual joystick.
        XMFLOAT3 commandDirection = XMFLOAT3(0.0f, 0.0f, 0.0f);
        if (fabsf(pointerDelta.x) > 16.0f)         // Leave 32 pixel-wide dead spot for being still.
            m_moveCommand.x -= pointerDelta.x/fabsf(pointerDelta.x);

        if (fabsf(pointerDelta.y) > 16.0f)
            m_moveCommand.y -= pointerDelta.y/fabsf(pointerDelta.y);
    }

    // Poll our state bits set by the keyboard input events.
    if (m_forward)
    {
        m_moveCommand.y += 1.0f;
    }
    if (m_back)
    {
        m_moveCommand.y -= 1.0f;
    }
    if (m_left)
    {
        m_moveCommand.x += 1.0f;
    }
    if (m_right)
    {
        m_moveCommand.x -= 1.0f;
    }
    if (m_up)
    {
        m_moveCommand.z += 1.0f;
    }
    if (m_down)
    {
        m_moveCommand.z -= 1.0f;
    }

    // Make sure that 45deg cases are not faster.
    if (fabsf(m_moveCommand.x) > 0.1f ||
        fabsf(m_moveCommand.y) > 0.1f ||
        fabsf(m_moveCommand.z) > 0.1f)
    {
        XMStoreFloat3(&m_moveCommand, XMVector3Normalize(XMLoadFloat3(&m_moveCommand)));
    }

    // Rotate command to align with our direction (world coordinates).
    XMFLOAT3 wCommand;
    wCommand.x =  m_moveCommand.x * cosf(m_yaw) - m_moveCommand.y * sinf(m_yaw);
    wCommand.y =  m_moveCommand.x * sinf(m_yaw) + m_moveCommand.y * cosf(m_yaw);
    wCommand.z =  m_moveCommand.z;

    // Scale for sensitivity adjustment.
    // Our velocity is based on the command. Y is up.
    m_velocity.x = -wCommand.x * MoveLookConstants::MovementGain;
    m_velocity.z =  wCommand.y * MoveLookConstants::MovementGain;
    m_velocity.y =  wCommand.z * MoveLookConstants::MovementGain;

    // Clear movement input accumulator for use during next frame.
    m_moveCommand = XMFLOAT3(0.0f, 0.0f, 0.0f);
}
```


## <a name="next-steps"></a><span data-ttu-id="2cd12-334">次の手順</span><span class="sxs-lookup"><span data-stu-id="2cd12-334">Next steps</span></span>

<span data-ttu-id="2cd12-335">これで、コントロールが追加されましたが、臨場感のあるゲームを作成するためにもう 1 つ追加しなければならない機能として、サウンドがあります。</span><span class="sxs-lookup"><span data-stu-id="2cd12-335">Now that we have added our controls, there's another feature we need to add to create an immersive game: sound!</span></span>
<span data-ttu-id="2cd12-336">ミュージックとサウンド効果はどのゲームでも重要であるため、次の「[サウンドの追加](tutorial--adding-sound.md)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="2cd12-336">Music and sound effects are important to any game, so let's discuss [adding sound](tutorial--adding-sound.md) next.</span></span>
 

 

 




