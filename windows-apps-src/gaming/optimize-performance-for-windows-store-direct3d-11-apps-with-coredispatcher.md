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
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5867648"
---
#  <a name="optimize-input-latency-for-universal-windows-platform-uwp-directx-games"></a>ユニバーサル Windows プラットフォーム (UWP) DirectX ゲームの入力待ち時間の最適化



入力待ち時間は、ゲームの操作性に大きな影響を与えるため、最適化するとゲームがより洗練されたものに感じられます。 また、適切な入力イベントの最適化によってバッテリー残量を節約できます。 適切な CoreDispatcher 入力イベント処理オプションを選択して、ゲームで入力ができる限り滑らかに処理されるようにする方法を説明します。

## <a name="input-latency"></a>入力待ち時間


入力待ち時間は、システムがユーザー入力に応答するのにかかる時間です。 応答は多くの場合、画面に表示される変更内容、またはオーディオ フィードバックにより聞こえる内容です。

すべての入力イベントは、タッチ ポインター、マウス ポインター、キーボード イベントのいずれから生成されたものであっても、イベント ハンドラーによって処理されるメッセージを生成します。 現在のタッチ デジタイザーとゲーム用機器は、イベントの入力を最低でもポインターごとに 100 Hz で通知できます。つまり、アプリはポインター (キーストローク) ごとに 1 秒間で 100 イベント以上を受け取る場合があることになります。 この更新速度は、複数のポインターが同時に発生した場合や高精度の入力デバイス (たとえば、ゲームのマウスなど) が使用されている場合は速くなります。 イベント メッセージ キューは、すぐにいっぱいになる場合があります。

シナリオに最適な方法でイベントが処理されるように、ゲームの入力待ち時間の必要を理解することが重要です。 1 つのソリューションがすべてのゲームに当てはまるわけではありません。

## <a name="power-efficiency"></a>電源効率


入力待ち時間のコンテキストでは、"電源効率" はゲームにより使われる GPU の量を表します。 使う GPU リソースが少ないゲームほど電源効率が良く、バッテリー残量が節約されます。 これは CPU についても同じです。

ゲームがユーザー エクスペリエンスを下げずに画面全体を描画できるのが 1 秒あたり 60 秒未満の場合 (現在のほとんどのディスプレイでは最大のレンダリング速度)、描画速度を下げると電源効率が良くなることが多くあります。 ゲームによってはユーザー入力に応答してのみ画面を更新するため、そのようなゲームでは 1 秒あたり 60 フレームで同じコンテンツを繰り返し描画しないでください。

## <a name="choosing-what-to-optimize-for"></a>最適化のための選択


DirectX アプリを設計するときは、いくつかの選択が必要です。 スムーズなアニメーションを表示するため、アプリは 1 秒あたりの 60 フレームをレンダリングする必要があるでしょうか。それとも、入力に応答してのみレンダリングすればよいでしょうか。 入力待ち時間をできる限り短くする必要があるでしょうか。それともある程度の遅延は許容されるでしょうか。 ユーザーはアプリに効率的なバッテリー使用量を期待するでしょうか。

これらの質問に対する答えによって、アプリは次のいずれかのシナリオに分類されると思われます。

1.  必要に応じてレンダリングする:  このカテゴリのゲームでは、特定の種類の入力に応答して画面を更新すれば十分です。 同じフレームが繰り返しレンダリングされないため、電源効率が優れており、ほとんどの時間が入力の待機に費やされるため、入力待ち時間も短くなります。 このカテゴリに当てはまるアプリの例としては、ボード ゲームやニュース リーダーなどがあります。
2.  必要に応じてレンダリングし、一時的なアニメーションも表示する:  このシナリオは最初のシナリオと似ていますが、特定の種類の入力によって、ユーザーからの後続の入力に依存しないアニメーションが開始されるという点が異なります。 同じフレームが繰り返しレンダリングされないため、電源効率が優れており、ゲームがアニメーションを表示していないときは入力待ち時間が短くなります。 このカテゴリに当てはまるアプリの例としては、お子様向けのインタラクティブなゲームや、各移動をアニメーション表示するボード ゲームなどがあります。
3.  1 秒あたり 60 フレームをレンダリングする:  このシナリオでは、ゲームは絶えず画面を更新します。 ディスプレイに表示可能な最大数のフレームがレンダリングされるため、電源効率は低くなります。 コンテンツを表示しているときは、DirectX によりスレッドがブロックされるため、入力待ち時間は長くなります。 そのようにすることで、スレッドはユーザーに表示可能な数より多くのフレームをディスプレイに送ることができなくなります。 このカテゴリに当てはまるゲームの例としては、ガン シューティング ゲーム、リアルタイム戦略ゲーム、物理学ベースのゲームなどがあります。
4.  1 秒あたり 60 フレームをレンダリングし、入力待ち時間を最小限に抑える:  シナリオ 3 と似ていて、アプリは絶えず画面を更新するため、電源効率は低くなります。 異なるのは、ゲームが別個のスレッドで入力に応答するため、入力の処理時にディスプレイへのグラフィックの表示がブロックされないという点です。 オンライン マルチプレーヤー ゲーム、戦闘ゲーム、リズム/タイミング ゲームは、かなり厳密なイベント ウィンドウ内で移動入力をサポートするため、このカテゴリに当てはまると考えられます。

## <a name="implementation"></a>実装


ほとんどの DirectX ゲームは、ゲーム ループと呼ばれるものによって動きます。 基本的なアルゴリズムは、ユーザーがゲームやアプリを終了するまで以下のステップを実行することです。

1.  入力の処理
2.  ゲーム状態の更新
3.  ゲーム コンテンツの描画

DirectX ゲームのコンテンツがレンダリングされて画面に表示する準備ができると、ゲーム ループはスリープ状態を解除してもう一度入力を処理する前に GPU が新しいフレームを受け取る準備ができるまで待機します。

ここでは、単純なジグソー パズル ゲームで反復処理を行うことで、ゲーム ループの実装方法を上記のシナリオごとに説明します。 各実装で説明する決定ポイント、利点、妥協点は、アプリを最適化して入力待ち時間を短縮して電源効率を上げる際のガイドとなります。

## <a name="scenario-1-render-on-demand"></a>シナリオ 1: オンデマンドでレンダリングする


ジグソー パズル ゲームの最初の反復処理では、ユーザーがパズルのピースを移動した場合にのみ画面を更新します。 ユーザーは、パズルのピースをドラッグして動かしたり、ピースを選んで適切な移動先をタッチすることではめ込む可能性があります。 2 番目のケースでは、パズルのピースはアニメーションやエフェクトなしで移動先にジャンプします。

コードには、**CoreProcessEventsOption::ProcessOneAndAllPending** を使う [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッド内にシングル スレッドのゲーム ループがあります。 このオプションを使うと、現在キューに入っているすべてのイベントがディスパッチされます。 保留中のイベントがない場合、ゲーム ループはイベントが発生するまで待機します。

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

## <a name="scenario-2-render-on-demand-with-transient-animations"></a>シナリオ 2: 必要に応じてレンダリングし、一時的なアニメーションも表示する


2 番目の反復処理では、ユーザーがパズルのピースを選んでそのピースの適切な移動先をタッチする際、移動先に到達するまで画面にアニメーションが表示されるようにゲームが変更されます。

前のケースと同様、コードには **ProcessOneAndAllPending** を使ってキュー内の入力イベントをディスパッチするシングル スレッドのゲーム ループがあります。 ここで異なるのは、アニメーション時、ループが新しい入力イベントを待機しないように **CoreProcessEventsOption::ProcessAllIfPresent** を使うように変更される点です。 保留中のイベントがない場合、すぐに [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) が返され、アプリがアニメーションで次のフレームを表示できるようになります。 アニメーションが完了したら、ループはもう一度 **ProcessOneAndAllPending** に切り替えられた画面の更新が制限されます。

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

**ProcessOneAndAllPending** と **ProcessAllIfPresent** の切り替えをサポートするため、アプリは状態を追跡してアニメーション中かどうかを認識する必要があります。 ジグソー パズルのアプリでは、GameState クラスでのゲーム ループ中に呼び出すことができる新しいメソッドを追加することでこれを行います。 ゲーム ループのアニメーション ブランチは、GameState の新しい Update メソッドを呼び出してアニメーションの状態を更新します。

## <a name="scenario-3-render-60-frames-per-second"></a>シナリオ 3: 1 秒あたり 60 フレームをレンダリングする


3 番目の反復処理では、ユーザーがパズルに取り組んだ時間の長さを示すタイマーがアプリに表示されます。 ミリ秒まで経過時間が表示されるため、表示を最新の状態に維持するには 1 秒あたりの 60 フレームをレンダリングする必要があります。

シナリオ 1 および 2 と同様、アプリにはシングル スレッドのゲーム ループがあります。 このシナリオで異なるのは、常にレンダリングを行うため、最初の 2 個のシナリオで行ったようにゲーム状態の変化を追跡する必要はないという点です。 このため、イベントの処理に既定で **ProcessAllIfPresent** を使うように設定することができます。 保留中のイベントがない場合、すぐに **ProcessEvents** が返され、次のフレームのレンダリングに進みます。

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

この方法は、レンダリングするタイミングを判断する追加の状態を追跡する必要がないため、最も簡単にゲームを記述できる方法です。 レンダリングが可能な限り速くなると同時に、タイマー間隔において適度な入力応答性が実現されます。

ただし、簡単に開発できる代わりにコストが高くなります。 1 秒あたり 60 フレームのレンダリングには、必要に応じたレンダリングより多くの電力が使われます。 ゲームによりフレームごとに表示内容が変更される場合は、**ProcessAllIfPresent** を使うのが最適です。 さらに、**ProcessEvents** ではなくディスプレイの同期間隔でゲーム ループがブロックされるようになるため、入力待ち時間が最大 16.7 ミリ秒長くなります。 キューがフレームごとに 1 回しか処理されない (60 Hz) ため、一部の入力イベントが破棄される可能性があります。

## <a name="scenario-4-render-60-frames-per-second-and-achieve-the-lowest-possible-input-latency"></a>シナリオ 4: 1 秒あたり 60 フレームをレンダリングし、入力待ち時間を最小限に抑える


ゲームによっては、シナリオ 3 で見られる入力待ち時間を無視するか、相殺することができます。 ただし、ゲームのエクスペリエンスとプレーヤー フィードバックの感覚にとって短い入力待ち時間が重要な場合、1 秒あたり 60 フレームをレンダリングするゲームは別個のスレッドで入力を処理する必要があります。

ジグソー パズル ゲームの 4 番目の反復処理は、ゲーム ループにより入力処理とグラフィック レンダリングを別個のスレッドに分割することで、シナリオ 3 をベースに構築されています。 それぞれ別個のスレッドを用意することで、グラフィック出力により入力が遅延することはなくなりますが、その結果、コードの複雑さが増します。 シナリオ 4 では、[**CoreProcessEventsOption::ProcessUntilQuit**](https://msdn.microsoft.com/library/windows/apps/br208217) を使って [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を呼び出します。これは、新しいイベントを待機し、利用できるすべてのイベントをディスパッチします。 この動作は、ウィンドウが閉じられるか、ゲームが [**CoreWindow::Close**](https://msdn.microsoft.com/library/windows/apps/br208260) を呼び出すまで継続します。

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

Microsoft Visual Studio2015 で**DirectX 11 および XAML アプリ (ユニバーサル Windows)** テンプレートは、ゲーム ループを同様の方法で複数のスレッドに分割します。 [**Windows::UI::Core::CoreIndependentInputSource**](https://msdn.microsoft.com/library/windows/apps/dn298460) オブジェクトを使って、入力処理専用のスレッドが開始され、XAML UI スレッドとは独立したレンダリング スレッドも作成されます。 これらのテンプレートについて詳しくは、「[テンプレートからのユニバーサル Windows プラットフォームおよび DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。

## <a name="additional-ways-to-reduce-input-latency"></a>入力待ち時間を短縮する他の方法


### <a name="use-waitable-swap-chains"></a>waitable スワップ チェーンを使う

DirectX ゲームは、画面上に見える内容を更新することでユーザー入力に反応します。 60 Hz ディスプレイでは、画面は 16.7 ミリ秒 (1 秒/60 フレーム) ごとに更新されます。 図 1 は、1 秒あたり 60 フレームをレンダリングするアプリの、16.7 ミリ秒の更新信号 (VBlank) を基準としたおおよそのライフサイクルと入力イベントに対する応答を示しています。

図 1

![図 1 Directx における入力待ち時間 ](images/input-latency1.png)

Windows8.1、DXGI にスワップ チェーンのアプリを簡単にキュー空のままにするためにヒューリスティックを実装することがなくこの待機時間を減らすことができますが、 **dxgi \_swap\_chain\_flag\_frame\_latency\_waitable\_object**フラグが導入されました。 このフラグによって作成されたスワップ チェーンは、waitable スワップ チェーンと呼ばれます。 図 2 は、waitable スワップ チェーンを使った場合のおおよそのライフサイクルと入力イベントに対する応答を示しています。

図 2

![図 2 Directx waitable における入力待ち時間](images/input-latency2.png)

これらの図からわかるのは、ディスプレイの更新速度により決まる 16.7 ミリ秒という割り当て時間内にゲームが各フレームをレンダリングして表示できる場合、2 つのフル フレームによって入力待ち時間を短縮できる可能性があるということです。 ジグソー パズルのサンプルでは、waitable スワップ チェーンを使い、 を呼び出して現在のキューの制限を制御します。` m_deviceResources->SetMaximumFrameLatency(1);`

 

 




