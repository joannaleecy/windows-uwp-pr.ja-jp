---
title: 相対マウス移動
description: 相対マウス制御を使用して、ゲーム内でのマウス移動の間隔をピクセル デルタとして追跡します。相対マウス制御ではシステム カーソルが使われず、画面の絶対座標は返されません。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, マウス, 入力
ms.assetid: 08c35e05-2822-4a01-85b8-44edb9b6898f
ms.localizationpriority: medium
ms.openlocfilehash: 71985841e6c0fa764201c179fb12408581823e5e
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7966222"
---
# <a name="relative-mouse-movement-and-corewindow"></a><span data-ttu-id="26595-104">相対マウス移動と CoreWindow</span><span class="sxs-lookup"><span data-stu-id="26595-104">Relative mouse movement and CoreWindow</span></span>

<span data-ttu-id="26595-105">ゲームでは、マウスが、多くのプレイヤーにとって馴染みのある一般的な制御手段として使われています。ファーストパーソン シューティング ゲームやサード パーソン シューティング ゲーム、リアルタイムの戦略ゲームなど、さまざまなジャンルのゲームでマウスは不可欠な存在となっています。</span><span class="sxs-lookup"><span data-stu-id="26595-105">In games, the mouse is a common control option that is familiar to many players, and is likewise essential to many genres of games, including first- and third-person shooters, and real-time strategy games.</span></span> <span data-ttu-id="26595-106">ここでは、相対マウス制御の実装について説明します。相対マウス制御では、システム カーソルは使われません。画面の絶対座標を取得するのではなく、マウス移動の間隔をピクセル デルタとして追跡します。</span><span class="sxs-lookup"><span data-stu-id="26595-106">Here we discuss the implementation of relative mouse controls, which don't use the system cursor and don't return absolute screen coordinates; instead, they track the pixel delta between mouse movements.</span></span>

<span data-ttu-id="26595-107">ゲームをはじめとする一部のアプリでは、一般的な入力デバイスとしてマウスが使われます。</span><span class="sxs-lookup"><span data-stu-id="26595-107">Some apps, such as games, use the mouse as a more general input device.</span></span> <span data-ttu-id="26595-108">たとえば、3D モデラーは、マウス入力を使い、仮想トラックボールをシミュレーションすることによって 3D オブジェクトの向きを設定します。また、ゲームでは、マウスに似たコントローラーを使って、ビュー カメラの方向を変更します。</span><span class="sxs-lookup"><span data-stu-id="26595-108">For example, a 3-D modeler might use mouse input to orient a 3-D object by simulating a virtual trackball; or a game might use the mouse to change the direction of the viewing camera via mouse-look controls.</span></span> 

<span data-ttu-id="26595-109">このようなシナリオでは、相対マウス データが必要となります。</span><span class="sxs-lookup"><span data-stu-id="26595-109">In these scenarios, the app requires relative mouse data.</span></span> <span data-ttu-id="26595-110">相対マウス値は、ウィンドウ (または画面) 内の絶対 xy 座標値ではなく、前回のフレームを起点としたマウスの移動距離を表します。</span><span class="sxs-lookup"><span data-stu-id="26595-110">Relative mouse values represent how far the mouse moved since the last frame, rather than the absolute x-y coordinate values within a window or screen.</span></span> <span data-ttu-id="26595-111">画面座標を基準としたカーソルの位置は 3D のオブジェクトやシーンでは意味をなさないため、マウス カーソルを非表示にするケースも少なくありません。</span><span class="sxs-lookup"><span data-stu-id="26595-111">Also, apps often hide the mouse cursor since the position of the cursor with respect to the screen coordinates is not relevant when manipulating a 3-D object or scene.</span></span> 

<span data-ttu-id="26595-112">相対 3D オブジェクト/シーン操作モードに移行させるような操作がユーザーによって行われたとき、アプリは次のことを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="26595-112">When the user takes an action that moves the app into a relative 3-D object/scene manipulation mode, the app must:</span></span> 
- <span data-ttu-id="26595-113">既定のマウス処理を無視する。</span><span class="sxs-lookup"><span data-stu-id="26595-113">Ignore default mouse handling.</span></span>
- <span data-ttu-id="26595-114">相対マウス処理を有効にする。</span><span class="sxs-lookup"><span data-stu-id="26595-114">Enable relative mouse handling.</span></span>
- <span data-ttu-id="26595-115">null ポインター (nullptr) を設定してマウス カーソルを非表示にする。</span><span class="sxs-lookup"><span data-stu-id="26595-115">Hide the mouse cursor by setting it a null pointer (nullptr).</span></span> 

<span data-ttu-id="26595-116">相対 3D オブジェクト/シーン操作モードを解除するような操作がユーザーによって行われたとき、アプリは次のことを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="26595-116">When the user takes an action that moves the app out of a relative 3-D object/scene manipulation mode, the app must:</span></span> 
- <span data-ttu-id="26595-117">既定の (絶対座標に基づく) マウス処理を有効にする。</span><span class="sxs-lookup"><span data-stu-id="26595-117">Enable default/absolute mouse handling.</span></span>
- <span data-ttu-id="26595-118">相対マウス処理を無効にする。</span><span class="sxs-lookup"><span data-stu-id="26595-118">Turn off relative mouse handling.</span></span> 
- <span data-ttu-id="26595-119">マウス カーソルを null 以外の値に設定する (表示状態にする)。</span><span class="sxs-lookup"><span data-stu-id="26595-119">Set the mouse cursor to a non-null value (which makes it visible).</span></span>

> **<span data-ttu-id="26595-120">注:</span><span class="sxs-lookup"><span data-stu-id="26595-120">Note</span></span>**  
<span data-ttu-id="26595-121">このパターンでは、カーソルを使わない相対モードに移行したときに、絶対マウス カーソルの位置を保存します。</span><span class="sxs-lookup"><span data-stu-id="26595-121">With this pattern, the location of the absolute mouse cursor is preserved on entering the cursorless relative mode.</span></span> <span data-ttu-id="26595-122">カーソルは、相対マウス移動モードが有効になる前と同じ画面座標位置に再び表示されます。</span><span class="sxs-lookup"><span data-stu-id="26595-122">The cursor re-appears in the same screen coordinate location as it was previous to enabling the relative mouse movement mode.</span></span>

 

## <a name="handling-relative-mouse-movement"></a><span data-ttu-id="26595-123">相対マウス移動の処理</span><span class="sxs-lookup"><span data-stu-id="26595-123">Handling relative mouse movement</span></span>


<span data-ttu-id="26595-124">マウスの相対デルタ値にアクセスするには、次のように [MouseDevice::MouseMoved](https://msdn.microsoft.com/library/windows/apps/xaml/windows.devices.input.mousedevice.mousemoved.aspx) イベントに対して登録を行います。</span><span class="sxs-lookup"><span data-stu-id="26595-124">To access relative mouse delta values, register for the [MouseDevice::MouseMoved](https://msdn.microsoft.com/library/windows/apps/xaml/windows.devices.input.mousedevice.mousemoved.aspx) event as shown here.</span></span>


```cpp


// register handler for relative mouse movement events
Windows::Devices::Input::MouseDevice::GetForCurrentView()->MouseMoved +=
        ref new TypedEventHandler<MouseDevice^, MouseEventArgs^>(this, &MoveLookController::OnMouseMoved);


```

```cpp


void MoveLookController::OnMouseMoved(
    _In_ Windows::Devices::Input::MouseDevice^ mouseDevice,
    _In_ Windows::Devices::Input::MouseEventArgs^ args
    )
{
    float2 pointerDelta;
    pointerDelta.x = static_cast<float>(args->MouseDelta.X);
    pointerDelta.y = static_cast<float>(args->MouseDelta.Y);

    float2 rotationDelta;
    rotationDelta = pointerDelta * ROTATION_GAIN;   // scale for control sensitivity

    // update our orientation based on the command
    m_pitch -= rotationDelta.y;                     // mouse y increases down, but pitch increases up
    m_yaw   -= rotationDelta.x;                     // yaw defined as CCW around y-axis

    // limit pitch to straight up or straight down
    float limit = (float)(M_PI/2) - 0.01f;
    m_pitch = (float) __max( -limit, m_pitch );
    m_pitch = (float) __min( +limit, m_pitch );

    // keep longitude in useful range by wrapping
    if ( m_yaw >  M_PI )
        m_yaw -= (float)M_PI*2;
    else if ( m_yaw < -M_PI )
        m_yaw += (float)M_PI*2;
}

```

<span data-ttu-id="26595-125">このコード例では、**OnMouseMoved** というイベント ハンドラーで、マウスの移動に応じた表示をレンダリングしています。</span><span class="sxs-lookup"><span data-stu-id="26595-125">The event handler in this code example, **OnMouseMoved**, renders the view based on the movements of the mouse.</span></span> <span data-ttu-id="26595-126">ハンドラーには、マウス ポインターの位置が、[MouseEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.devices.input.mouseeventargs.aspx) オブジェクトとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="26595-126">The position of the mouse pointer is passed to the handler as a [MouseEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.devices.input.mouseeventargs.aspx) object.</span></span> 

<span data-ttu-id="26595-127">マウスの相対移動の値を処理している間は、[CoreWindow::PointerMoved](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointermoved.aspx) イベントからの絶対マウス データの処理はスキップします。</span><span class="sxs-lookup"><span data-stu-id="26595-127">Skip over processing of absolute mouse data from the [CoreWindow::PointerMoved](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointermoved.aspx) event when your app changes to handling relative mouse movement values.</span></span> <span data-ttu-id="26595-128">ただし、この入力をスキップするのは、(タッチ入力の結果としてではなく) マウス入力の結果として **CoreWindow::PointerMoved** イベントが発生した場合だけです。</span><span class="sxs-lookup"><span data-stu-id="26595-128">However, only skip this input if the **CoreWindow::PointerMoved** event occurred as the result of mouse input (as opposed to touch input).</span></span> <span data-ttu-id="26595-129">カーソルを非表示にするには、[CoreWindow::PointerCursor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointercursor.aspx) を **nullptr** に設定します。</span><span class="sxs-lookup"><span data-stu-id="26595-129">The cursor is hidden by setting the [CoreWindow::PointerCursor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointercursor.aspx) to **nullptr**.</span></span> 

## <a name="returning-to-absolute-mouse-movement"></a><span data-ttu-id="26595-130">絶対マウス移動への復帰</span><span class="sxs-lookup"><span data-stu-id="26595-130">Returning to absolute mouse movement</span></span>

<span data-ttu-id="26595-131">アプリが 3D オブジェクト/シーン操作モードから抜け、相対マウス移動が使われなくなったら (メニュー画面に戻ったときなど)、絶対マウス移動の通常の処理に戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="26595-131">When the app exits the 3-D object or scene manipulation mode and no longer uses relative mouse movement (such as when it returns to a menu screen), return to normal processing of absolute mouse movement.</span></span> <span data-ttu-id="26595-132">この時点で、相対マウス データの読み取りを中止し、標準的なマウス (とポインター) イベントの処理を再開して、[CoreWindow::PointerCursor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointercursor.aspx) を null 以外の値に設定します。</span><span class="sxs-lookup"><span data-stu-id="26595-132">At this time, stop reading relative mouse data, restart the processing of standard mouse (and pointer) events, and set [CoreWindow::PointerCursor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointercursor.aspx) to non-null value.</span></span> 

> **<span data-ttu-id="26595-133">注:</span><span class="sxs-lookup"><span data-stu-id="26595-133">Note</span></span>**  
<span data-ttu-id="26595-134">アプリが 3D オブジェクト/シーン操作モードのとき (カーソルをオフにした状態で相対マウス移動を処理しているとき)、マウスは、チャーム、バック スタック、アプリ バーなどのエッジ UI を呼び出すことができません。</span><span class="sxs-lookup"><span data-stu-id="26595-134">When your app is in the 3-D object/scene manipulation mode (processing relative mouse movements with the cursor off), the mouse cannot invoke edge UI such as the charms, back stack, or app bar.</span></span> <span data-ttu-id="26595-135">したがって、この特殊なモードから抜けるための機構を実装することが重要となります。たとえば、一般には **Esc** キーが使われています。</span><span class="sxs-lookup"><span data-stu-id="26595-135">Therefore, it is important to provide a mechanism to exit this particular mode, such as the commonly used **Esc** key.</span></span>

## <a name="related-topics"></a><span data-ttu-id="26595-136">関連トピック</span><span class="sxs-lookup"><span data-stu-id="26595-136">Related topics</span></span>

* [<span data-ttu-id="26595-137">ゲームのムーブ/ルック コントロール</span><span class="sxs-lookup"><span data-stu-id="26595-137">Move-look controls for games</span></span>](tutorial--adding-move-look-controls-to-your-directx-game.md) 
* [<span data-ttu-id="26595-138">ゲームのタッチ コントロール</span><span class="sxs-lookup"><span data-stu-id="26595-138">Touch controls for games</span></span>](tutorial--adding-touch-controls-to-your-directx-game.md)