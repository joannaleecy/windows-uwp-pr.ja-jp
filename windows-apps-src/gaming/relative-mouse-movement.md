---
author: scottmill
title: "相対マウス移動"
description: "相対マウス制御を使用して、ゲーム内でのマウス移動の間隔をピクセル デルタとして追跡します。相対マウス制御ではシステム カーソルが使われず、画面の絶対座標は返されません。"
ms.author: scotmi
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, マウス, 入力"
ms.assetid: 08c35e05-2822-4a01-85b8-44edb9b6898f
ms.openlocfilehash: dff08052af7f005366f9cb5154b307c13a316953
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="relative-mouse-movement-and-corewindow"></a>相対マウス移動と CoreWindow

ゲームでは、マウスが、多くのプレイヤーにとって馴染みのある一般的な制御手段として使われています。ファーストパーソン シューティング ゲームやサード パーソン シューティング ゲーム、リアルタイムの戦略ゲームなど、さまざまなジャンルのゲームでマウスは不可欠な存在となっています。 ここでは、相対マウス制御の実装について説明します。相対マウス制御では、システム カーソルは使われません。画面の絶対座標を取得するのではなく、マウス移動の間隔をピクセル デルタとして追跡します。

ゲームをはじめとする一部のアプリでは、一般的な入力デバイスとしてマウスが使われます。 たとえば、3D モデラーは、マウス入力を使い、仮想トラックボールをシミュレーションすることによって 3D オブジェクトの向きを設定します。また、ゲームでは、マウスに似たコントローラーを使って、ビュー カメラの方向を変更します。 

このようなシナリオでは、相対マウス データが必要となります。 相対マウス値は、ウィンドウ (または画面) 内の絶対 xy 座標値ではなく、前回のフレームを起点としたマウスの移動距離を表します。 画面座標を基準としたカーソルの位置は 3D のオブジェクトやシーンでは意味をなさないため、マウス カーソルを非表示にするケースも少なくありません。 

相対 3D オブジェクト/シーン操作モードに移行させるような操作がユーザーによって行われたとき、アプリは次のことを実行する必要があります。 
- 既定のマウス処理を無視する。
- 相対マウス処理を有効にする。
- null ポインター (nullptr) を設定してマウス カーソルを非表示にする。 

相対 3D オブジェクト/シーン操作モードを解除するような操作がユーザーによって行われたとき、アプリは次のことを実行する必要があります。 
- 既定の (絶対座標に基づく) マウス処理を有効にする。
- 相対マウス処理を無効にする。 
- マウス カーソルを null 以外の値に設定する (表示状態にする)。

> **注:**  
このパターンでは、カーソルを使わない相対モードに移行したときに、絶対マウス カーソルの位置を保存します。 カーソルは、相対マウス移動モードが有効になる前と同じ画面座標位置に再び表示されます。

 

## <a name="handling-relative-mouse-movement"></a>相対マウス移動の処理


マウスの相対デルタ値にアクセスするには、次のように [MouseDevice::MouseMoved](https://msdn.microsoft.com/library/windows/apps/xaml/windows.devices.input.mousedevice.mousemoved.aspx) イベントに対して登録を行います。


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
    rotationDelta = pointerDelta * ROTATION_GAIN;    // scale for control sensitivity

    // update our orientation based on the command
    m_pitch -= rotationDelta.y;                        // mouse y increases down, but pitch increases up
    m_yaw   -= rotationDelta.x;                        // yaw defined as CCW around y-axis

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

このコード例では、**OnMouseMoved** というイベント ハンドラーで、マウスの移動に応じた表示をレンダリングしています。 ハンドラーには、マウス ポインターの位置が、[MouseEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.devices.input.mouseeventargs.aspx) オブジェクトとして渡されます。 

マウスの相対移動の値を処理している間は、[CoreWindow::PointerMoved](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointermoved.aspx) イベントからの絶対マウス データの処理はスキップします。 ただし、この入力をスキップするのは、(タッチ入力の結果としてではなく) マウス入力の結果として **CoreWindow::PointerMoved** イベントが発生した場合だけです。 カーソルを非表示にするには、[CoreWindow::PointerCursor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointercursor.aspx) を **nullptr** に設定します。 

## <a name="returning-to-absolute-mouse-movement"></a>絶対マウス移動への復帰

アプリが 3D オブジェクト/シーン操作モードから抜け、相対マウス移動が使われなくなったら (メニュー画面に戻ったときなど)、絶対マウス移動の通常の処理に戻す必要があります。 この時点で、相対マウス データの読み取りを中止し、標準的なマウス (とポインター) イベントの処理を再開して、[CoreWindow::PointerCursor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.core.corewindow.pointercursor.aspx) を null 以外の値に設定します。 

> **注:**  
アプリが 3D オブジェクト/シーン操作モードのとき (カーソルをオフにした状態で相対マウス移動を処理しているとき)、マウスは、チャーム、バック スタック、アプリ バーなどのエッジ UI を呼び出すことができません。 したがって、この特殊なモードから抜けるための機構を実装することが重要となります。たとえば、一般には **Esc** キーが使われています。

## <a name="related-topics"></a>関連トピック

* [ゲームのムーブ/ルック コントロール](tutorial--adding-move-look-controls-to-your-directx-game.md) 
* [ゲームのタッチ コントロール](tutorial--adding-touch-controls-to-your-directx-game.md)