---
author: mtoepke
title: UWP DirectX ゲームの入力待ち時間の最適化
description: 入力待ち時間は、ゲームの操作性に大きな影響を与えるため、最適化するとゲームがより洗練されたものに感じられます。
ms.assetid: e18cd1a8-860f-95fb-098d-29bf424de0c0
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, 入力待ち時間
ms.localizationpriority: medium
ms.openlocfilehash: a2e92dc10dbcdc3a511c1b1a1271ae759cc03c60
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6646063"
---
#  <a name="optimize-input-latency-for-universal-windows-platform-uwp-directx-games"></a><span data-ttu-id="fc071-104">ユニバーサル Windows プラットフォーム (UWP) DirectX ゲームの入力待ち時間の最適化</span><span class="sxs-lookup"><span data-stu-id="fc071-104">Optimize input latency for Universal Windows Platform (UWP) DirectX games</span></span>



<span data-ttu-id="fc071-105">入力待ち時間は、ゲームの操作性に大きな影響を与えるため、最適化するとゲームがより洗練されたものに感じられます。</span><span class="sxs-lookup"><span data-stu-id="fc071-105">Input latency can significantly impact the experience of a game, and optimizing it can make a game feel more polished.</span></span> <span data-ttu-id="fc071-106">また、適切な入力イベントの最適化によってバッテリー残量を節約できます。</span><span class="sxs-lookup"><span data-stu-id="fc071-106">Additionally, proper input event optimization can improve battery life.</span></span> <span data-ttu-id="fc071-107">適切な CoreDispatcher 入力イベント処理オプションを選択して、ゲームで入力ができる限り滑らかに処理されるようにする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="fc071-107">Learn how to choose the right CoreDispatcher input event processing options to make sure your game handles input as smoothly as possible.</span></span>

## <a name="input-latency"></a><span data-ttu-id="fc071-108">入力待ち時間</span><span class="sxs-lookup"><span data-stu-id="fc071-108">Input latency</span></span>


<span data-ttu-id="fc071-109">入力待ち時間は、システムがユーザー入力に応答するのにかかる時間です。</span><span class="sxs-lookup"><span data-stu-id="fc071-109">Input latency is the time it takes for the system to respond to user input.</span></span> <span data-ttu-id="fc071-110">応答は多くの場合、画面に表示される変更内容、またはオーディオ フィードバックにより聞こえる内容です。</span><span class="sxs-lookup"><span data-stu-id="fc071-110">The response is often a change in what's displayed on the screen, or what's heard through audio feedback.</span></span>

<span data-ttu-id="fc071-111">すべての入力イベントは、タッチ ポインター、マウス ポインター、キーボード イベントのいずれから生成されたものであっても、イベント ハンドラーによって処理されるメッセージを生成します。</span><span class="sxs-lookup"><span data-stu-id="fc071-111">Every input event, whether it comes from a touch pointer, mouse pointer, or keyboard, generates a message to be processed by an event handler.</span></span> <span data-ttu-id="fc071-112">現在のタッチ デジタイザーとゲーム用機器は、イベントの入力を最低でもポインターごとに 100 Hz で通知できます。つまり、アプリはポインター (キーストローク) ごとに 1 秒間で 100 イベント以上を受け取る場合があることになります。</span><span class="sxs-lookup"><span data-stu-id="fc071-112">Modern touch digitizers and gaming peripherals report input events at a minimum of 100 Hz per pointer, which means that apps can receive 100 events or more per second per pointer (or keystroke).</span></span> <span data-ttu-id="fc071-113">この更新速度は、複数のポインターが同時に発生した場合や高精度の入力デバイス (たとえば、ゲームのマウスなど) が使用されている場合は速くなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-113">This rate of updates is amplified if multiple pointers are happening concurrently, or a higher precision input device is used (for example, a gaming mouse).</span></span> <span data-ttu-id="fc071-114">イベント メッセージ キューは、すぐにいっぱいになる場合があります。</span><span class="sxs-lookup"><span data-stu-id="fc071-114">The event message queue can fill up very quickly.</span></span>

<span data-ttu-id="fc071-115">シナリオに最適な方法でイベントが処理されるように、ゲームの入力待ち時間の必要を理解することが重要です。</span><span class="sxs-lookup"><span data-stu-id="fc071-115">It's important to understand the input latency demands of your game so that events are processed in a way that is best for the scenario.</span></span> <span data-ttu-id="fc071-116">1 つのソリューションがすべてのゲームに当てはまるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="fc071-116">There is no one solution for all games.</span></span>

## <a name="power-efficiency"></a><span data-ttu-id="fc071-117">電源効率</span><span class="sxs-lookup"><span data-stu-id="fc071-117">Power efficiency</span></span>


<span data-ttu-id="fc071-118">入力待ち時間のコンテキストでは、"電源効率" はゲームにより使われる GPU の量を表します。</span><span class="sxs-lookup"><span data-stu-id="fc071-118">In the context of input latency, "power efficiency" refers to how much a game uses the GPU.</span></span> <span data-ttu-id="fc071-119">使う GPU リソースが少ないゲームほど電源効率が良く、バッテリー残量が節約されます。</span><span class="sxs-lookup"><span data-stu-id="fc071-119">A game that uses less GPU resources is more power efficient and allows for longer battery life.</span></span> <span data-ttu-id="fc071-120">これは CPU についても同じです。</span><span class="sxs-lookup"><span data-stu-id="fc071-120">This also holds true for the CPU.</span></span>

<span data-ttu-id="fc071-121">ゲームがユーザー エクスペリエンスを下げずに画面全体を描画できるのが 1 秒あたり 60 秒未満の場合 (現在のほとんどのディスプレイでは最大のレンダリング速度)、描画速度を下げると電源効率が良くなることが多くあります。</span><span class="sxs-lookup"><span data-stu-id="fc071-121">If a game can draw the whole screen at less than 60 frames per second (currently, the maximum rendering speed on most displays) without degrading the user's experience, it will be more power efficient by drawing less often.</span></span> <span data-ttu-id="fc071-122">ゲームによってはユーザー入力に応答してのみ画面を更新するため、そのようなゲームでは 1 秒あたり 60 フレームで同じコンテンツを繰り返し描画しないでください。</span><span class="sxs-lookup"><span data-stu-id="fc071-122">Some games only update the screen in response to user input, so those games should not draw the same content repeatedly at 60 frames per second.</span></span>

## <a name="choosing-what-to-optimize-for"></a><span data-ttu-id="fc071-123">最適化のための選択</span><span class="sxs-lookup"><span data-stu-id="fc071-123">Choosing what to optimize for</span></span>


<span data-ttu-id="fc071-124">DirectX アプリを設計するときは、いくつかの選択が必要です。</span><span class="sxs-lookup"><span data-stu-id="fc071-124">When designing a DirectX app, you need to make some choices.</span></span> <span data-ttu-id="fc071-125">スムーズなアニメーションを表示するため、アプリは 1 秒あたりの 60 フレームをレンダリングする必要があるでしょうか。それとも、入力に応答してのみレンダリングすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="fc071-125">Does the app need to render 60 frames per second to present smooth animation, or does it only need to render in response to input?</span></span> <span data-ttu-id="fc071-126">入力待ち時間をできる限り短くする必要があるでしょうか。それともある程度の遅延は許容されるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="fc071-126">Does it need to have the lowest possible input latency, or can it tolerate a little bit of delay?</span></span> <span data-ttu-id="fc071-127">ユーザーはアプリに効率的なバッテリー使用量を期待するでしょうか。</span><span class="sxs-lookup"><span data-stu-id="fc071-127">Will my users expect my app to be judicious about battery usage?</span></span>

<span data-ttu-id="fc071-128">これらの質問に対する答えによって、アプリは次のいずれかのシナリオに分類されると思われます。</span><span class="sxs-lookup"><span data-stu-id="fc071-128">The answers to these questions will likely align your app with one of the following scenarios:</span></span>

1.  <span data-ttu-id="fc071-129">必要に応じてレンダリングする: </span><span class="sxs-lookup"><span data-stu-id="fc071-129">Render on demand.</span></span> <span data-ttu-id="fc071-130">このカテゴリのゲームでは、特定の種類の入力に応答して画面を更新すれば十分です。</span><span class="sxs-lookup"><span data-stu-id="fc071-130">Games in this category only need to update the screen in response to specific types of input.</span></span> <span data-ttu-id="fc071-131">同じフレームが繰り返しレンダリングされないため、電源効率が優れており、ほとんどの時間が入力の待機に費やされるため、入力待ち時間も短くなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-131">Power efficiency is excellent because the app doesn’t render identical frames repeatedly, and input latency is low because the app spends most of its time waiting for input.</span></span> <span data-ttu-id="fc071-132">このカテゴリに当てはまるアプリの例としては、ボード ゲームやニュース リーダーなどがあります。</span><span class="sxs-lookup"><span data-stu-id="fc071-132">Board games and news readers are examples of apps that might fall into this category.</span></span>
2.  <span data-ttu-id="fc071-133">必要に応じてレンダリングし、一時的なアニメーションも表示する: </span><span class="sxs-lookup"><span data-stu-id="fc071-133">Render on demand with transient animations.</span></span> <span data-ttu-id="fc071-134">このシナリオは最初のシナリオと似ていますが、特定の種類の入力によって、ユーザーからの後続の入力に依存しないアニメーションが開始されるという点が異なります。</span><span class="sxs-lookup"><span data-stu-id="fc071-134">This scenario is similar to the first scenario except that certain types of input will start an animation that isn’t dependent on subsequent input from the user.</span></span> <span data-ttu-id="fc071-135">同じフレームが繰り返しレンダリングされないため、電源効率が優れており、ゲームがアニメーションを表示していないときは入力待ち時間が短くなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-135">Power efficiency is good because the game doesn’t render identical frames repeatedly, and input latency is low while the game is not animating.</span></span> <span data-ttu-id="fc071-136">このカテゴリに当てはまるアプリの例としては、お子様向けのインタラクティブなゲームや、各移動をアニメーション表示するボード ゲームなどがあります。</span><span class="sxs-lookup"><span data-stu-id="fc071-136">Interactive children’s games and board games that animate each move are examples of apps that might fall into this category.</span></span>
3.  <span data-ttu-id="fc071-137">1 秒あたり 60 フレームをレンダリングする: </span><span class="sxs-lookup"><span data-stu-id="fc071-137">Render 60 frames per second.</span></span> <span data-ttu-id="fc071-138">このシナリオでは、ゲームは絶えず画面を更新します。</span><span class="sxs-lookup"><span data-stu-id="fc071-138">In this scenario, the game is constantly updating the screen.</span></span> <span data-ttu-id="fc071-139">ディスプレイに表示可能な最大数のフレームがレンダリングされるため、電源効率は低くなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-139">Power efficiency is poor because it renders the maximum number of frames the display can present.</span></span> <span data-ttu-id="fc071-140">コンテンツを表示しているときは、DirectX によりスレッドがブロックされるため、入力待ち時間は長くなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-140">Input latency is high because DirectX blocks the thread while content is being presented.</span></span> <span data-ttu-id="fc071-141">そのようにすることで、スレッドはユーザーに表示可能な数より多くのフレームをディスプレイに送ることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-141">Doing so prevents the thread from sending more frames to the display than it can show to the user.</span></span> <span data-ttu-id="fc071-142">このカテゴリに当てはまるゲームの例としては、ガン シューティング ゲーム、リアルタイム戦略ゲーム、物理学ベースのゲームなどがあります。</span><span class="sxs-lookup"><span data-stu-id="fc071-142">First person shooters, real-time strategy games, and physics-based games are examples of apps that might fall into this category.</span></span>
4.  <span data-ttu-id="fc071-143">1 秒あたり 60 フレームをレンダリングし、入力待ち時間を最小限に抑える: </span><span class="sxs-lookup"><span data-stu-id="fc071-143">Render 60 frames per second and achieve the lowest possible input latency.</span></span> <span data-ttu-id="fc071-144">シナリオ 3 と似ていて、アプリは絶えず画面を更新するため、電源効率は低くなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-144">Similar to scenario 3, the app is constantly updating the screen, so power efficiency will be poor.</span></span> <span data-ttu-id="fc071-145">異なるのは、ゲームが別個のスレッドで入力に応答するため、入力の処理時にディスプレイへのグラフィックの表示がブロックされないという点です。</span><span class="sxs-lookup"><span data-stu-id="fc071-145">The difference is that the game responds to input on a separate thread, so that input processing isn’t blocked by presenting graphics to the display.</span></span> <span data-ttu-id="fc071-146">オンライン マルチプレーヤー ゲーム、戦闘ゲーム、リズム/タイミング ゲームは、かなり厳密なイベント ウィンドウ内で移動入力をサポートするため、このカテゴリに当てはまると考えられます。</span><span class="sxs-lookup"><span data-stu-id="fc071-146">Online multiplayer games, fighting games, or rhythm/timing games might fall into this category because they support move inputs within extremely tight event windows.</span></span>

## <a name="implementation"></a><span data-ttu-id="fc071-147">実装</span><span class="sxs-lookup"><span data-stu-id="fc071-147">Implementation</span></span>


<span data-ttu-id="fc071-148">ほとんどの DirectX ゲームは、ゲーム ループと呼ばれるものによって動きます。</span><span class="sxs-lookup"><span data-stu-id="fc071-148">Most DirectX games are driven by what is known as the game loop.</span></span> <span data-ttu-id="fc071-149">基本的なアルゴリズムは、ユーザーがゲームやアプリを終了するまで以下のステップを実行することです。</span><span class="sxs-lookup"><span data-stu-id="fc071-149">The basic algorithm is to perform these steps until the user quits the game or app:</span></span>

1.  <span data-ttu-id="fc071-150">入力の処理</span><span class="sxs-lookup"><span data-stu-id="fc071-150">Process input</span></span>
2.  <span data-ttu-id="fc071-151">ゲーム状態の更新</span><span class="sxs-lookup"><span data-stu-id="fc071-151">Update the game state</span></span>
3.  <span data-ttu-id="fc071-152">ゲーム コンテンツの描画</span><span class="sxs-lookup"><span data-stu-id="fc071-152">Draw the game content</span></span>

<span data-ttu-id="fc071-153">DirectX ゲームのコンテンツがレンダリングされて画面に表示する準備ができると、ゲーム ループはスリープ状態を解除してもう一度入力を処理する前に GPU が新しいフレームを受け取る準備ができるまで待機します。</span><span class="sxs-lookup"><span data-stu-id="fc071-153">When the content of a DirectX game is rendered and ready to be presented to the screen, the game loop waits until the GPU is ready to receive a new frame before waking up to process input again.</span></span>

<span data-ttu-id="fc071-154">ここでは、単純なジグソー パズル ゲームで反復処理を行うことで、ゲーム ループの実装方法を上記のシナリオごとに説明します。</span><span class="sxs-lookup"><span data-stu-id="fc071-154">We’ll show the implementation of the game loop for each of the scenarios mentioned earlier by iterating on a simple jigsaw puzzle game.</span></span> <span data-ttu-id="fc071-155">各実装で説明する決定ポイント、利点、妥協点は、アプリを最適化して入力待ち時間を短縮して電源効率を上げる際のガイドとなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-155">The decision points, benefits, and tradeoffs discussed with each implementation can serve as a guide to help you optimize your apps for low latency input and power efficiency.</span></span>

## <a name="scenario-1-render-on-demand"></a><span data-ttu-id="fc071-156">シナリオ 1: オンデマンドでレンダリングする</span><span class="sxs-lookup"><span data-stu-id="fc071-156">Scenario 1: Render on demand</span></span>


<span data-ttu-id="fc071-157">ジグソー パズル ゲームの最初の反復処理では、ユーザーがパズルのピースを移動した場合にのみ画面を更新します。</span><span class="sxs-lookup"><span data-stu-id="fc071-157">The first iteration of the jigsaw puzzle game only updates the screen when a user moves a puzzle piece.</span></span> <span data-ttu-id="fc071-158">ユーザーは、パズルのピースをドラッグして動かしたり、ピースを選んで適切な移動先をタッチすることではめ込む可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fc071-158">A user can either drag a puzzle piece into place or snap it into place by selecting it and then touching the correct destination.</span></span> <span data-ttu-id="fc071-159">2 番目のケースでは、パズルのピースはアニメーションやエフェクトなしで移動先にジャンプします。</span><span class="sxs-lookup"><span data-stu-id="fc071-159">In the second case, the puzzle piece will jump to the destination with no animation or effects.</span></span>

<span data-ttu-id="fc071-160">コードには、**CoreProcessEventsOption::ProcessOneAndAllPending** を使う [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッド内にシングル スレッドのゲーム ループがあります。</span><span class="sxs-lookup"><span data-stu-id="fc071-160">The code has a single-threaded game loop within the [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) method that uses **CoreProcessEventsOption::ProcessOneAndAllPending**.</span></span> <span data-ttu-id="fc071-161">このオプションを使うと、現在キューに入っているすべてのイベントがディスパッチされます。</span><span class="sxs-lookup"><span data-stu-id="fc071-161">Using this option dispatches all currently available events in the queue.</span></span> <span data-ttu-id="fc071-162">保留中のイベントがない場合、ゲーム ループはイベントが発生するまで待機します。</span><span class="sxs-lookup"><span data-stu-id="fc071-162">If no events are pending, the game loop waits until one appears.</span></span>

``` syntax
void App::Run()
{
    
    while (!m_windowClosed)
    {
        // Wait for system events or input from the user.
        // ProcessOneAndAllPending will block the thread until events appear and are processed.
        CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);

        // If any of the events processed resulted in a need to redraw the window contents, then we will re-render the
        // scene and present it to the display.
        if (m_updateWindow || m_state->StateChanged())
        {
            m_main->Render();
            m_deviceResources->Present();

            m_updateWindow = false;
            m_state->Validate();
        }
    }
}
```

## <a name="scenario-2-render-on-demand-with-transient-animations"></a><span data-ttu-id="fc071-163">シナリオ 2: 必要に応じてレンダリングし、一時的なアニメーションも表示する</span><span class="sxs-lookup"><span data-stu-id="fc071-163">Scenario 2: Render on demand with transient animations</span></span>


<span data-ttu-id="fc071-164">2 番目の反復処理では、ユーザーがパズルのピースを選んでそのピースの適切な移動先をタッチする際、移動先に到達するまで画面にアニメーションが表示されるようにゲームが変更されます。</span><span class="sxs-lookup"><span data-stu-id="fc071-164">In the second iteration, the game is modified so that when a user selects a puzzle piece and then touches the correct destination for that piece, it animates across the screen until it reaches its destination.</span></span>

<span data-ttu-id="fc071-165">前のケースと同様、コードには **ProcessOneAndAllPending** を使ってキュー内の入力イベントをディスパッチするシングル スレッドのゲーム ループがあります。</span><span class="sxs-lookup"><span data-stu-id="fc071-165">As before, the code has a single-threaded game loop that uses **ProcessOneAndAllPending** to dispatch input events in the queue.</span></span> <span data-ttu-id="fc071-166">ここで異なるのは、アニメーション時、ループが新しい入力イベントを待機しないように **CoreProcessEventsOption::ProcessAllIfPresent** を使うように変更される点です。</span><span class="sxs-lookup"><span data-stu-id="fc071-166">The difference now is that during an animation, the loop changes to use **CoreProcessEventsOption::ProcessAllIfPresent** so that it doesn’t wait for new input events.</span></span> <span data-ttu-id="fc071-167">保留中のイベントがない場合、すぐに [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) が返され、アプリがアニメーションで次のフレームを表示できるようになります。</span><span class="sxs-lookup"><span data-stu-id="fc071-167">If no events are pending, [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) returns immediately and allows the app to present the next frame in the animation.</span></span> <span data-ttu-id="fc071-168">アニメーションが完了したら、ループはもう一度 **ProcessOneAndAllPending** に切り替えられた画面の更新が制限されます。</span><span class="sxs-lookup"><span data-stu-id="fc071-168">When the animation is complete, the loop switches back to **ProcessOneAndAllPending** to limit screen updates.</span></span>

``` syntax
void App::Run()
{

    while (!m_windowClosed)
    {
        // 2. Switch to a continuous rendering loop during the animation.
        if (m_state->Animating())
        {
            // Process any system events or input from the user that is currently queued.
            // ProcessAllIfPresent will not block the thread to wait for events. This is the desired behavior when
            // you are trying to present a smooth animation to the user.
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            m_state->Update();
            m_main->Render();
            m_deviceResources->Present();
        }
        else
        {
            // Wait for system events or input from the user.
            // ProcessOneAndAllPending will block the thread until events appear and are processed.
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);

            // If any of the events processed resulted in a need to redraw the window contents, then we will re-render the
            // scene and present it to the display.
            if (m_updateWindow || m_state->StateChanged())
            {
                m_main->Render();
                m_deviceResources->Present();

                m_updateWindow = false;
                m_state->Validate();
            }
        }
    }
}
```

<span data-ttu-id="fc071-169">**ProcessOneAndAllPending** と **ProcessAllIfPresent** の切り替えをサポートするため、アプリは状態を追跡してアニメーション中かどうかを認識する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fc071-169">To support the transition between **ProcessOneAndAllPending** and **ProcessAllIfPresent**, the app must track state to know if it’s animating.</span></span> <span data-ttu-id="fc071-170">ジグソー パズルのアプリでは、GameState クラスでのゲーム ループ中に呼び出すことができる新しいメソッドを追加することでこれを行います。</span><span class="sxs-lookup"><span data-stu-id="fc071-170">In the jigsaw puzzle app, you do this by adding a new method that can be called during the game loop on the GameState class.</span></span> <span data-ttu-id="fc071-171">ゲーム ループのアニメーション ブランチは、GameState の新しい Update メソッドを呼び出してアニメーションの状態を更新します。</span><span class="sxs-lookup"><span data-stu-id="fc071-171">The animation branch of the game loop drives updates in the state of the animation by calling GameState’s new Update method.</span></span>

## <a name="scenario-3-render-60-frames-per-second"></a><span data-ttu-id="fc071-172">シナリオ 3: 1 秒あたり 60 フレームをレンダリングする</span><span class="sxs-lookup"><span data-stu-id="fc071-172">Scenario 3: Render 60 frames per second</span></span>


<span data-ttu-id="fc071-173">3 番目の反復処理では、ユーザーがパズルに取り組んだ時間の長さを示すタイマーがアプリに表示されます。</span><span class="sxs-lookup"><span data-stu-id="fc071-173">In the third iteration, the app displays a timer that shows the user how long they’ve been working on the puzzle.</span></span> <span data-ttu-id="fc071-174">ミリ秒まで経過時間が表示されるため、表示を最新の状態に維持するには 1 秒あたりの 60 フレームをレンダリングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fc071-174">Because it displays the elapsed time up to the millisecond, it must render 60 frames per second to keep the display up to date.</span></span>

<span data-ttu-id="fc071-175">シナリオ 1 および 2 と同様、アプリにはシングル スレッドのゲーム ループがあります。</span><span class="sxs-lookup"><span data-stu-id="fc071-175">As in scenarios 1 and 2, the app has a single-threaded game loop.</span></span> <span data-ttu-id="fc071-176">このシナリオで異なるのは、常にレンダリングを行うため、最初の 2 個のシナリオで行ったようにゲーム状態の変化を追跡する必要はないという点です。</span><span class="sxs-lookup"><span data-stu-id="fc071-176">The difference with this scenario is that because it’s always rendering, it no longer needs to track changes in the game state as was done in the first two scenarios.</span></span> <span data-ttu-id="fc071-177">このため、イベントの処理に既定で **ProcessAllIfPresent** を使うように設定することができます。</span><span class="sxs-lookup"><span data-stu-id="fc071-177">As a result, it can default to use **ProcessAllIfPresent** for processing events.</span></span> <span data-ttu-id="fc071-178">保留中のイベントがない場合、すぐに **ProcessEvents** が返され、次のフレームのレンダリングに進みます。</span><span class="sxs-lookup"><span data-stu-id="fc071-178">If no events are pending, **ProcessEvents** returns immediately and proceeds to render the next frame.</span></span>

``` syntax
void App::Run()
{

    while (!m_windowClosed)
    {
        if (m_windowVisible)
        {
            // 3. Continuously render frames and process system events and input as they appear in the queue.
            // ProcessAllIfPresent will not block the thread to wait for events. This is the desired behavior when
            // trying to present smooth animations to the user.
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            m_state->Update();
            m_main->Render();
            m_deviceResources->Present();
        }
        else
        {
            // 3. If the window isn't visible, there is no need to continuously render.
            // Process events as they appear until the window becomes visible again.
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
}
```

<span data-ttu-id="fc071-179">この方法は、レンダリングするタイミングを判断する追加の状態を追跡する必要がないため、最も簡単にゲームを記述できる方法です。</span><span class="sxs-lookup"><span data-stu-id="fc071-179">This approach is the easiest way to write a game because there’s no need to track additional state to determine when to render.</span></span> <span data-ttu-id="fc071-180">レンダリングが可能な限り速くなると同時に、タイマー間隔において適度な入力応答性が実現されます。</span><span class="sxs-lookup"><span data-stu-id="fc071-180">It achieves the fastest rendering possible along with reasonable input responsiveness on a timer interval.</span></span>

<span data-ttu-id="fc071-181">ただし、簡単に開発できる代わりにコストが高くなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-181">However, this ease of development comes with a price.</span></span> <span data-ttu-id="fc071-182">1 秒あたり 60 フレームのレンダリングには、必要に応じたレンダリングより多くの電力が使われます。</span><span class="sxs-lookup"><span data-stu-id="fc071-182">Rendering at 60 frames per second uses more power than rendering on demand.</span></span> <span data-ttu-id="fc071-183">ゲームによりフレームごとに表示内容が変更される場合は、**ProcessAllIfPresent** を使うのが最適です。</span><span class="sxs-lookup"><span data-stu-id="fc071-183">It’s best to use **ProcessAllIfPresent** when the game is changing what is displayed every frame.</span></span> <span data-ttu-id="fc071-184">さらに、**ProcessEvents** ではなくディスプレイの同期間隔でゲーム ループがブロックされるようになるため、入力待ち時間が最大 16.7 ミリ秒長くなります。</span><span class="sxs-lookup"><span data-stu-id="fc071-184">It also increases input latency by as much as 16.7 ms because the app is now blocking the game loop on the display’s sync interval instead of on **ProcessEvents**.</span></span> <span data-ttu-id="fc071-185">キューがフレームごとに 1 回しか処理されない (60 Hz) ため、一部の入力イベントが破棄される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fc071-185">Some input events might be dropped because the queue is only processed once per frame (60 Hz).</span></span>

## <a name="scenario-4-render-60-frames-per-second-and-achieve-the-lowest-possible-input-latency"></a><span data-ttu-id="fc071-186">シナリオ 4: 1 秒あたり 60 フレームをレンダリングし、入力待ち時間を最小限に抑える</span><span class="sxs-lookup"><span data-stu-id="fc071-186">Scenario 4: Render 60 frames per second and achieve the lowest possible input latency</span></span>


<span data-ttu-id="fc071-187">ゲームによっては、シナリオ 3 で見られる入力待ち時間を無視するか、相殺することができます。</span><span class="sxs-lookup"><span data-stu-id="fc071-187">Some games may be able to ignore or compensate for the increase in input latency seen in scenario 3.</span></span> <span data-ttu-id="fc071-188">ただし、ゲームのエクスペリエンスとプレーヤー フィードバックの感覚にとって短い入力待ち時間が重要な場合、1 秒あたり 60 フレームをレンダリングするゲームは別個のスレッドで入力を処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fc071-188">However, if low input latency is critical to the game’s experience and sense of player feedback, games that render 60 frames per second need to process input on a separate thread.</span></span>

<span data-ttu-id="fc071-189">ジグソー パズル ゲームの 4 番目の反復処理は、ゲーム ループにより入力処理とグラフィック レンダリングを別個のスレッドに分割することで、シナリオ 3 をベースに構築されています。</span><span class="sxs-lookup"><span data-stu-id="fc071-189">The fourth iteration of the jigsaw puzzle game builds on scenario 3 by splitting the input processing and graphics rendering from the game loop into separate threads.</span></span> <span data-ttu-id="fc071-190">それぞれ別個のスレッドを用意することで、グラフィック出力により入力が遅延することはなくなりますが、その結果、コードの複雑さが増します。</span><span class="sxs-lookup"><span data-stu-id="fc071-190">Having separate threads for each ensures that input is never delayed by graphics output; however, the code becomes more complex as a result.</span></span> <span data-ttu-id="fc071-191">シナリオ 4 では、[**CoreProcessEventsOption::ProcessUntilQuit**](https://msdn.microsoft.com/library/windows/apps/br208217) を使って [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を呼び出します。これは、新しいイベントを待機し、利用できるすべてのイベントをディスパッチします。</span><span class="sxs-lookup"><span data-stu-id="fc071-191">In scenario 4, the input thread calls [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) with [**CoreProcessEventsOption::ProcessUntilQuit**](https://msdn.microsoft.com/library/windows/apps/br208217), which waits for new events and dispatches all available events.</span></span> <span data-ttu-id="fc071-192">この動作は、ウィンドウが閉じられるか、ゲームが [**CoreWindow::Close**](https://msdn.microsoft.com/library/windows/apps/br208260) を呼び出すまで継続します。</span><span class="sxs-lookup"><span data-stu-id="fc071-192">It continues this behavior until the window is closed or the game calls [**CoreWindow::Close**](https://msdn.microsoft.com/library/windows/apps/br208260).</span></span>

``` syntax
void App::Run()
{
    // 4. Start a thread dedicated to rendering and dedicate the UI thread to input processing.
    m_main->StartRenderThread();

    // ProcessUntilQuit will block the thread and process events as they appear until the App terminates.
    CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessUntilQuit);
}

void JigsawPuzzleMain::StartRenderThread()
{
    // If the render thread is already running, then do not start another one.
    if (IsRendering())
    {
        return;
    }

    // Create a task that will be run on a background thread.
    auto workItemHandler = ref new WorkItemHandler([this](IAsyncAction^ action)
    {
        // Notify the swap chain that this app intends to render each frame faster
        // than the display's vertical refresh rate (typically 60 Hz). Apps that cannot
        // deliver frames this quickly should set this to 2.
        m_deviceResources->SetMaximumFrameLatency(1);

        // Calculate the updated frame and render once per vertical blanking interval.
        while (action->Status == AsyncStatus::Started)
        {
            // Execute any work items that have been queued by the input thread.
            ProcessPendingWork();

            // Take a snapshot of the current game state. This allows the renderers to work with a
            // set of values that won't be changed while the input thread continues to process events.
            m_state->SnapState();

            m_sceneRenderer->Render();
            m_deviceResources->Present();
        }

        // Ensure that all pending work items have been processed before terminating the thread.
        ProcessPendingWork();
    });

    // Run the task on a dedicated high priority background thread.
    m_renderLoopWorker = ThreadPool::RunAsync(workItemHandler, WorkItemPriority::High, WorkItemOptions::TimeSliced);
}
```

<span data-ttu-id="fc071-193">Microsoft Visual Studio2015 で**DirectX 11 および XAML アプリ (ユニバーサル Windows)** テンプレートでは、ゲーム ループを同様の方法で複数のスレッドに分割します。</span><span class="sxs-lookup"><span data-stu-id="fc071-193">The **DirectX 11 and XAML App (Universal Windows)** template in Microsoft Visual Studio2015 splits the game loop into multiple threads in a similar fashion.</span></span> <span data-ttu-id="fc071-194">[**Windows::UI::Core::CoreIndependentInputSource**](https://msdn.microsoft.com/library/windows/apps/dn298460) オブジェクトを使って、入力処理専用のスレッドが開始され、XAML UI スレッドとは独立したレンダリング スレッドも作成されます。</span><span class="sxs-lookup"><span data-stu-id="fc071-194">It uses the [**Windows::UI::Core::CoreIndependentInputSource**](https://msdn.microsoft.com/library/windows/apps/dn298460) object to start a thread dedicated to handling input and also creates a rendering thread independent of the XAML UI thread.</span></span> <span data-ttu-id="fc071-195">これらのテンプレートについて詳しくは、「[テンプレートからのユニバーサル Windows プラットフォームおよび DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fc071-195">For more details on these templates, read [Create a Universal Windows Platform and DirectX game project from a template](user-interface.md).</span></span>

## <a name="additional-ways-to-reduce-input-latency"></a><span data-ttu-id="fc071-196">入力待ち時間を短縮する他の方法</span><span class="sxs-lookup"><span data-stu-id="fc071-196">Additional ways to reduce input latency</span></span>


### <a name="use-waitable-swap-chains"></a><span data-ttu-id="fc071-197">waitable スワップ チェーンを使う</span><span class="sxs-lookup"><span data-stu-id="fc071-197">Use waitable swap chains</span></span>

<span data-ttu-id="fc071-198">DirectX ゲームは、画面上に見える内容を更新することでユーザー入力に反応します。</span><span class="sxs-lookup"><span data-stu-id="fc071-198">DirectX games respond to user input by updating what the user sees on-screen.</span></span> <span data-ttu-id="fc071-199">60 Hz ディスプレイでは、画面は 16.7 ミリ秒 (1 秒/60 フレーム) ごとに更新されます。</span><span class="sxs-lookup"><span data-stu-id="fc071-199">On a 60 Hz display, the screen refreshes every 16.7 ms (1 second/60 frames).</span></span> <span data-ttu-id="fc071-200">図 1 は、1 秒あたり 60 フレームをレンダリングするアプリの、16.7 ミリ秒の更新信号 (VBlank) を基準としたおおよそのライフサイクルと入力イベントに対する応答を示しています。</span><span class="sxs-lookup"><span data-stu-id="fc071-200">Figure 1 shows the approximate life cycle and response to an input event relative to the 16.7 ms refresh signal (VBlank) for an app that renders 60 frames per second:</span></span>

<span data-ttu-id="fc071-201">図 1</span><span class="sxs-lookup"><span data-stu-id="fc071-201">Figure 1</span></span>

![<span data-ttu-id="fc071-202">図 1 Directx における入力待ち時間</span><span class="sxs-lookup"><span data-stu-id="fc071-202">figure 1 input latency in directx</span></span> ](images/input-latency1.png)

<span data-ttu-id="fc071-203">Windows8.1、DXGI にスワップ チェーンのアプリを簡単にキューを空に維持するためにヒューリスティックを実装することがなくこの待機時間を減らすことができますが、 **dxgi \_swap\_chain\_flag\_frame\_latency\_waitable\_object**フラグが導入されました。</span><span class="sxs-lookup"><span data-stu-id="fc071-203">In Windows8.1, DXGI introduced the **DXGI\_SWAP\_CHAIN\_FLAG\_FRAME\_LATENCY\_WAITABLE\_OBJECT** flag for the swap chain, which allows apps to easily reduce this latency without requiring them to implement heuristics to keep the Present queue empty.</span></span> <span data-ttu-id="fc071-204">このフラグによって作成されたスワップ チェーンは、waitable スワップ チェーンと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="fc071-204">Swap chains created with this flag are referred to as waitable swap chains.</span></span> <span data-ttu-id="fc071-205">図 2 は、waitable スワップ チェーンを使った場合のおおよそのライフサイクルと入力イベントに対する応答を示しています。</span><span class="sxs-lookup"><span data-stu-id="fc071-205">Figure 2 shows the approximate life cycle and response to an input event when using waitable swap chains:</span></span>

<span data-ttu-id="fc071-206">図 2</span><span class="sxs-lookup"><span data-stu-id="fc071-206">Figure 2</span></span>

![図 2 Directx waitable における入力待ち時間](images/input-latency2.png)

<span data-ttu-id="fc071-208">これらの図からわかるのは、ディスプレイの更新速度により決まる 16.7 ミリ秒という割り当て時間内にゲームが各フレームをレンダリングして表示できる場合、2 つのフル フレームによって入力待ち時間を短縮できる可能性があるということです。</span><span class="sxs-lookup"><span data-stu-id="fc071-208">What we see from these diagrams is that games can potentially reduce input latency by two full frames if they are capable of rendering and presenting each frame within the 16.7 ms budget defined by the display’s refresh rate.</span></span> <span data-ttu-id="fc071-209">ジグソー パズルのサンプルでは、waitable スワップ チェーンを使い、 を呼び出して現在のキューの制限を制御します。</span><span class="sxs-lookup"><span data-stu-id="fc071-209">The jigsaw puzzle sample uses waitable swap chains and controls the Present queue limit by calling:</span></span>` m_deviceResources->SetMaximumFrameLatency(1);`

 

 




