---
title: コントロールの追加
description: 次は、ゲーム サンプルで 3-D ゲームにムーブ/ルック コントロールを実装する方法と、タッチ コントローラー用、マウス コントローラー用、ゲーム コントローラー用の基本的なコントロールを開発する方法について説明します。
ms.assetid: f9666abb-151a-74b4-ae0b-ef88f1f252f8
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, コントロール, 入力
ms.localizationpriority: medium
ms.openlocfilehash: 369aa076184f79aa1e43c3aac11706982a6be268
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/04/2019
ms.locfileid: "9045641"
---
# <a name="add-controls"></a>コントロールの追加


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](https://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

優れた ユニバーサル Windows プラットフォーム (UWP) ゲームは、幅広いインターフェイスをサポートしています。 潜在的なプレイヤーが物理的なボタンのない、接続されている場合、Xbox コント ローラーでの PC とタブレットで windows 10 を必要があります、または高性能マウス/ゲーム キーボード付属の最新デスクトップ ゲーム機かもしれません。 このゲームでは、コントロールは [**MoveLookController**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp) クラスで実装されます。 このクラスは、3 種類のすべての入力 (マウスとキーボード、タッチ、ゲームパッド) を 1 つのコントローラーのに集約します。 最終的には、一人称視点のシューティング ゲームで使用するジャンル標準のムーブ/ルック コントロールが、複数のデバイスで利用できるようになります。

> [!NOTE]
> コントロールの詳細ついては、「[ゲームのムーブ/ルック コントロール](tutorial--adding-move-look-controls-to-your-directx-game.md)」と「[ゲームのタッチ コントロール](tutorial--adding-touch-controls-to-your-directx-game.md)」を参照してください。


## <a name="objective"></a>目標

この時点で、レンダリングするゲームは完成していますが、プレイヤーが動き回ったり、ターゲットを撃ったりすることはできません。 ここでは、UWP DirectX ゲームで次の種類の入力について、一人称視点のシューティング ゲームのムーブ/ルック コントロールを実装する方法を見てみましょう。
- マウスとキーボード
- タッチ
- ゲームパッド

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="common-control-behaviors"></a>コントロールの共通の動作


タッチ コントロールとマウス/キーボード コントロールのコア実装は、よく似ています。 UWP アプリでは、ポインターは画面上の単なる点です。 これは、マウスをスライドするか、タッチ スクリーンで指をスライドすることで動かせます。 このため、単一のイベント セットを登録でき、プレイヤーがポインターを動かして押すのにマウスとタッチ スクリーンのどちらを使っているかを気にする必要はありません。

このゲーム サンプルの **MoveLookController** クラスを初期化すると、ポインターに固有の 4 つのイベントとマウスに固有の 1 つのイベントが登録されます。

イベント | 説明
:------ | :-------
[**CoreWindow::PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208278) | マウスの左または右ボタンが押された (そして押され続けた) か、タッチ画面がタッチされました。
[**CoreWindow::PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) |マウスが動かされたか、タッチ画面でドラッグ操作が行われました。
[**CoreWindow::PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) |マウスの左ボタンが離されたか、タッチ画面に触れているオブジェクトが離されました。
[**CoreWindow::PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208275) |ポインターがメイン ウィンドウの外に動かされました。
[**Windows::Devices::Input::MouseMoved**](https://msdn.microsoft.com/library/windows/apps/hh758356) | マウスが一定の距離動かされました。 現在の X-Y 位置ではなく、マウス移動のデルタ値にのみ注目します。


これらのイベント ハンドラーは、アプリケーション ウィンドウ内で **MoveLookController** が初期化されるとすぐに、ユーザー入力の待機を開始するように設定されています。
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

[**InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L68-L92) のコード一式は GitHub で確認できます。


ゲームがいつ特定の入力を待機する必要があるかを判断するために、**MoveLookController** クラスには、コントローラーの種類に関係なく、コントローラーに固有の次の 3 つの状態があります。

状態 | 説明
:----- | :-------
**None** | これは、コントローラーの初期化された状態です。 ゲームではコントローラーの入力を予期していないため、すべての入力は無視されます。
**WaitForInput** | コントローラーは、プレイヤーが、マウスの左クリック、タッチ イベント、ゲームパッドのメニュー ボタンのいずれかを使用して、ゲームからのメッセージを確認するのを待っています。
**Active** | コントローラーはアクティブなゲーム プレイ モードです。



### <a name="waitforinput-state-and-pausing-the-game"></a>WaitForInput 状態とゲームの一時停止

ゲームが一時停止されると、ゲームは **WaitForInput** 状態になります。 これは、プレイヤーがゲームのメイン ウィンドウの外にポインターを動かすか、一時停止ボタン (P キーまたはゲームパッドの**スタート** ボタン) を押したときに発生します。 **MoveLookController** は、この押し操作を登録し、[**IsPauseRequested**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L107-L127) メソッドを呼び出すときにゲーム ループに通知します。 その時点で、**IsPauseRequested** が **true** を返すと、ゲーム ループは **MoveLookController** の **WaitForPress** を呼び出して、コントローラーを **WaitForInput** 状態にします。 


**WaitForInput** 状態になると、ゲームは、**Active**状態 に戻るまで、ほぼすべてのゲームプレイ入力イベントの処理を停止します。 一時停止ボタンは例外で、このボタンを押すと、ゲームはアクティブ状態に戻ります。 一時停止ボタン以外の**アクティブな**状態に戻るには、ゲーム、プレイヤー必要がメニュー項目を選択します。 ある 



### <a name="the-active-state"></a>Active 状態

**Active** 状態では、**MoveLookController** インスタンスは、有効になっているすべての入力デバイスからの入力イベントを処理し、プレイヤーの意図を解釈しています。 この結果、**Update** がゲーム ループから呼び出された後に、プレイヤーのビューの速度とルック方向を更新し、更新データをゲームと共有します。


すべてのポインター入力は、**Active** 状態で追跡され、ポインターの操作に応じて異なるポインター ID が設定されます。
[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208278) イベントが受け取られると、**MoveLookController** は、ウィンドウで作成されたポインターの ID 値を取得します。 ポインター ID は、特定の種類の入力を表します。 たとえば、マルチタッチ デバイスでは、複数の異なるアクティブ入力が同時に行われる場合があります。 ID は、プレイヤーが使っている入力を追跡するために使われます。 タッチ スクリーンのムーブ四角形内にイベントがある場合、ポインター ID が割り当てられ、ムーブ四角形内のポインター イベントが追跡されます。 ファイア四角形内の他のポインター イベントは、別のポインター ID で別途追跡されます。


> [!NOTE]
> マウスおよびゲームパッドの右サムスティックからの入力には、別途処理される別の ID もあります。

ポインター イベントをゲームの特定の操作にマップした後は、**MoveLookController** オブジェクトとゲームのメイン ループで共有されているデータを更新します。

このゲーム サンプルの [**Update**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1005-L1096) メソッドは、呼び出されると、入力を処理し、速度とルック方向の変数 (**m\_velocity** と **m\_lookdirection**) を更新します。この後、ゲーム ループは、[**Velocity**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L906-L909) および [**LookDirection**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L913-L923) パブリック メソッドを呼び出すことで、これらの変数を取得します。

> [!NOTE]
> [**Update**](#the-update-method) メソッドの詳細については、このページで後で説明します。




ゲーム ループは、**MoveLookController** インスタンスの **IsFiring** メソッドを呼び出すことで、プレイヤーが弾を撃っているかどうかをテストできます。 **MoveLookController** は、プレイヤーが 3 種類の入力のいずれかでファイア ボタンを押したかどうかを確認します。

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









次は、3 種類のコントロールのそれぞれの実装について少し詳しく説明します。

## <a name="adding-relative-mouse-controls"></a>相対マウス コントロールの追加


マウス移動が検出された場合は、その移動を使ってカメラの新しいピッチとヨーを特定します。 そのためには、相対マウス コントロールを実装します。相対マウス コントロールでは、動作の絶対 x-y ピクセル座標を記録するのではなく、マウスが移動した相対距離 (移動の開始から停止までのデルタ) を処理します。

これを行うには、[**MouseMoved**](https://msdn.microsoft.com/library/windows/apps/hh758356) イベントによって返される [**Windows::Device::Input::MouseEventArgs::MouseDelta**](https://msdn.microsoft.com/library/windows/apps/hh758358) 引数オブジェクトの [**MouseDelta::X**](https://msdn.microsoft.com/library/windows/apps/hh758353) フィールドと **MouseDelta::Y** フィールドを調べて、X (横方向の動作) と Y (縦方向の動作) の座標の変化を取得します。

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

## <a name="adding-touch-support"></a>タッチのサポートの追加

タッチ コントロールは、タブレット ユーザーのサポートに優れています。 このゲームでは、特定のゲーム内アクションに合わせて画面の特定領域にゾーンを設定することでタッチ入力を収集します。
このゲームのタッチ入力では、3 つのゾーンを使用します。

![ムーブ/ルックのタッチ画面のレイアウト](images/simple-dx-game-controls-touchzones.png)

次のコマンドは、タッチ コントロールの動作をまとめたものです。
ユーザー入力 | アクション
:------- | :--------
ムーブ四角形 | タッチ入力は仮想ジョイスティックに変換され、垂直方向のモーションは前/後の位置モーションに変換され、水平方向のモーションは左/右の位置モーションに変換されます。
ファイア四角形 | 球体を発射します。
ムーブ四角形とファイア四角形の外部をタッチ | カメラ ビューの回転角度 (ピッチとヨー) を変更します。

**MoveLookController** は、ポインター ID を確認してイベントがどこで発生したかを判断し、次のいずれかの処理を実行します。

-   [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) イベントがムーブまたはファイア四角形で発生した場合は、コントローラーのポインターの位置を更新します。
-   [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) イベントが画面の残りの部分 (ルック コントロールとして定義されている部分) のどこかで発生した場合は、ルック方向ベクトルのピッチとヨーの変化を計算します。


タッチ コントロールを実装すると、前に Direct2D を使って描画した四角形が、ムーブ、ファイア、ルックの各ゾーンの場所をプレイヤーに示します。


![タッチ コントロール](images/simple-dx-game-controls-showzones.png)


次に、各コントロールを実装する方法を見てみましょう。


### <a name="move-and-fire-controller"></a>ムーブおよびファイア コントローラー
画面左下のセクションのムーブ コントローラーの四角形は、方向パッドとして使用されます。 この領域内で親指を左右にスライドさせると、プレイヤーが左右に移動し、上下にスライドさせると、カメラが前後に移動します。
これを設定した後、画面の右下のセクションのファイア コントローラーをタップすると、球体が発射されます。

[**SetMoveRect**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L843-L853) メソッドと [**SetFireRect**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L857-L867) メソッドは、画面上で各四角形の左上隅と右下隅の位置を指定する 2 つの 2D ベクトルを使用して、入力の四角形を作成します。 


次に、**m\_fireUpperLeft** と **m\_fireLowerRight** にパラメーターが割り当てられます。これは、ユーザーが四角形の内部をタッチしているかどうかを判断するのに役立ちます。 
```cpp
m_fireUpperLeft  = upperLeft;
m_fireLowerRight = lowerRight;
```

画面のサイズが変更される場合、これらの四角形は適切なサイズで再描画されます。


コントロールのゾーンを設定したら、次はユーザーが実際にコントロールを使用しているかどうかを判断します。
これを行うには、ユーザーがポインターを押したとき、移動したとき、離したときに対応するいくつかのイベント ハンドラーを **MoveLookController::InitWindow** メソッド内に設定します。

```cpp
window->PointerPressed +=
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerPressed);

window->PointerMoved +=
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerMoved);

window->PointerReleased +=
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerReleased);
```


まず、[**OnPointerPressed**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L179-L313) メソッド使用して、ユーザーが最初にムーブ四角形またはファイア四角形内を押したときの動作を決定します。
ここで、ユーザーがコントロールにタッチしているかどうか、およびポインターが既にそのコントローラー内にあるかどうかを確認します。 これが特定のコントロールにタッチした最初の指である場合は、次の処理を行います。
- タッチの位置を 2D ベクトルとして **m \_moveFirstDown** または **m\_fireFirstDown** に格納します。
- ポインター ID を **m \_movePointerID** または **m\_firePointerID** に割り当てます。
- コントロールのアクティブなポインターが取得できたら、適切な **InUse** フラグ (**m\_moveInUse** または **m\_fireInUse**) を `true` に設定します。


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


ユーザーがムーブ コントロールとファイア コントロールのいずれにタッチしているかを特定できたら、プレイヤーが押した指を移動しているかどうかを確認します。
[**MoveLookController::OnPointerMoved**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L317-L395) メソッドを使用して、どのポインターが移動したかを確認した後、新しい位置を 2D ベクトルとして格納します。  


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


ユーザーはコントロール内のジェスチャを行った後、ポインターを離します。 [**MoveLookController::OnPointerReleased**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) メソッドを使用して、離されたポインターを特定し、一連のリセットを実行します。


ムーブ コントロールが離された場合は、次の処理を行います。
- すべての方向へのプレイヤーの速度を `0` に設定し、ゲーム内でのプレイヤーの移動を防ぎます。
- ユーザーはもうムーブ コントローラーにタッチしていないため、**m\_moveInUse** を `false` に切り替えます。
- ムーブ コントローラーにはポインターがなくなったため、ムーブ ポインター ID を `0` に設定します。

```cpp
       if (pointerID == m_movePointerID)
        {
            m_velocity = XMFLOAT3(0, 0, 0);      // Stop on release.
            m_moveInUse = false;
            m_movePointerID = 0;
        }
```


ファイア コントロールが離された場合、ファイア コントロールにポインターがなくなったため、必要な処理は **m_fireInUse** フラグを `false` に切り替えて、ファイア ポインター ID を `0` に設定します。
```cpp
        else if (pointerID == m_firePointerID)
        {
            m_fireInUse = false;
            m_firePointerID = 0;
        }
```

### <a name="look-controller"></a>ルック コントローラー
画面の使用されていない領域用のタッチ デバイスのポインター イベントは、ルック コントローラーとして扱います。 このゾーンで指をスライドさせると、プレイヤー カメラのピッチとヨー (回転) が変化します。


**MoveLookController::OnPointerPressed** イベントがタッチ デバイスのこの領域で発生し、ゲームの状態が **Active** に設定されている場合は、ポインター ID が割り当てられます。

```cpp
    if (!m_lookInUse)   // If no pointer is in this control yet:
    {
        m_lookLastPoint = position;                   // Save the pointer for a later move.
        m_lookPointerID = pointerID;                  // Store the pointer using this control.
        m_lookLastDelta.x = m_lookLastDelta.y = 0;    // These are for smoothing.
        m_lookInUse = true;
    }
```
**MoveLookController::OnPointerPressed** メソッドのコード一式については、[GitHub](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L252-L259) で確認できます。




ここで、**MoveLookController** は、ルック領域に対応する特定の変数に、イベントを発生させたポインターのポインターの ID を割り当てます。 ルック領域で発生するタッチ、 **m \_lookpointerid**変数イベントを発生させたポインターの ID に設定されています。 ブール変数 **m\_lookInUse** も、コントロールがまだ離されていないことを示すために設定されます。

次は、このゲーム サンプルで [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) タッチ スクリーン イベントを処理する方法を見てみましょう。


**MoveLookController::OnPointerMoved** メソッド内で、どのような種類のポインター ID がイベントに割り当てられているかを確認します。 **m_lookPointerID** の場合は、ポインターの位置の変更を計算します。
このデルタを使用して、どの程度の回転を変更する必要があるかを計算します。 最後に、プレイヤーの回転を変更するためにゲームで使用される **m \_pitch** と **m \_yaw** を更新します。 

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





確認する最後の要素は、このゲーム サンプルで [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) タッチ スクリーン イベントがどのように処理されているかです。
ユーザーがタッチ ジェスチャを終了し、画面から指を離すと、[**MoveLookController::OnPointerReleased**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) が開始されます。
[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) イベントを発生させたポインターの ID が前に記録されたムーブ ポインターの ID である場合は、プレイヤーがルック領域から指を離したため、**MoveLookController** は速度を `0` に設定します。

```cpp
    else if (pointerID == m_lookPointerID)
    {
        m_lookInUse = false;
        m_lookPointerID = 0;
    }
```





## <a name="adding-mouse-and-keyboard-support"></a>マウスとキーボードのサポートの追加


このゲームには、キーボードとマウス用に次のコントロール レイアウトが含まれています。

ユーザー入力 | アクション
:------- | :--------
W | プレイヤーを前へ移動します。
A | プレイヤーを左へ移動します。
S | プレイヤーを後ろへ移動します。
D | プレイヤーを右へ移動します。
X | ビューを上へ移動します。
Space キー | ビューを下へ移動します。
P | ゲームを一時停止します。
マウスの移動 | カメラ ビューの回転角度 (ピッチとヨー) を変更します。
マウスの左ボタン | 球体を発射します。


キーボードを使用するために、ゲーム サンプルは、[**MoveLookController::InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L84-L88) メソッド内で 2 つの新しいイベント [**CoreWindow::KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208271) と [**CoreWindow::KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208270) を登録します。 これらのイベントは、キーを押す操作と離す操作を処理します。

```cpp
window->KeyDown +=
        ref new TypedEventHandler<CoreWindow^, KeyEventArgs^>(this, &MoveLookController::OnKeyDown);

window->KeyUp +=
        ref new TypedEventHandler<CoreWindow^, KeyEventArgs^>(this, &MoveLookController::OnKeyUp);
```

マウスは、ポインターを使いますが、タッチ コントロールとは扱いが少し異なります。 このコントロール レイアウトに合わせて、**MoveLookController** は、マウスが移動されるたびにカメラを回転させ、マウスの左ボタンが押されたときに発射します。


これは、**MoveLookController** の [**OnPointerPressed**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L179-L313) メソッドで処理されます。

このメソッドで、[`Windows::Devices::Input::PointerDeviceType`](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Input.PointerDeviceType) 列挙型を使って、使用されているポインター デバイスの種類を確認します。 ゲームが **Active** であり、**PointerDeviceType** が **Touch** ではない場合は、マウス入力と見なします。

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

プレイヤーがいずれかのマウス ボタンを押すことをやめると、[CoreWindow::PointerReleased](https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreWindow.PointerReleased) マウス イベントが発生し、[MoveLookController::OnPointerReleased](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L441-L500) メソッドが呼び出されて、入力が完了します。 ここで、押していたマウスの左ボタンから指を離した場合、球体の発射は停止します。 ルックは常に有効であるため、ゲームでは同じマウス ポインターを使い続けて、進行中のルック イベントを追跡します。

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



次に、サポートしている最後のコントロールの種類である、ゲームパッドを見てみましょう。 ゲームパッドは、ポインター オブジェクトを使わないため、タッチ コントロールやマウス コントロールとは別に処理されます。 このため、いくつかの新しいイベント ハンドラーとメソッドを追加する必要があります。

## <a name="adding-gamepad-support"></a>ゲームパッドのサポートの追加


このゲームでは、ゲームパッドのサポートは [Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) API の呼び出しによって追加されます。 この一連の API は、レーシング ハンドルやフライト スティックなどの、ゲーム コントローラー入力へのアクセスを提供します。 


このゲームのゲームパッド コントロールは次のようになります。

ユーザー入力 | アクション
:------- | :--------
左アナログ スティック | プレイヤーを移動します。
右アナログ スティック | カメラ ビューの回転角度 (ピッチとヨー) を変更します。
右トリガー | 球体を発射します。
スタート/メニュー ボタン | ゲームを一時停止または再開します。




[**InitWindow**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L68-L103) メソッドに、ゲームパッドが[追加された](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1100-L1105)か、[削除された](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1109-L1114)かを判断するために 2 つの新しいイベントを追加します。 これらのイベントは **m_gamepadsChanged** プロパティを更新します。 これは、既知のゲームパッドの一覧が変更されたかどうかをチェックする**UpdatePollingDevices**メソッドで使用されます。 

```cpp
    // Detect gamepad connection and disconnection events.
    Gamepad::GamepadAdded +=
        ref new EventHandler<Gamepad^>(this, &MoveLookController::OnGamepadAdded);

    Gamepad::GamepadRemoved +=
        ref new EventHandler<Gamepad^>(this, &MoveLookController::OnGamepadRemoved);
```

> [!NOTE]
> UWP アプリは、アプリがフォーカスにないときに、Xbox One コント ローラーから入力を受け取ることはできません。

### <a name="the-updatepollingdevices-method"></a>UpdatePollingDevices メソッド

**MoveLookController** インスタンスの [**UpdatePollingDevices**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L654-L782) メソッドは、すぐにゲームパッドが接続されているかどうかを確認します。 ゲームパッドが接続されている場合は、[**Gamepad.GetCurrentReading**](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.GetCurrentReading) を使用して、その状態の読み取りを開始します。 これによって [**GamepadReading**](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.GamepadReading) 構造体が返され、クリックされていたボタンや移動したサムスティックを確認できます。


ゲームの状態が **WaitForInput** である場合、ゲームを再開できるように、コントローラーのスタート/メニュー ボタンのみをリッスンします。


状態が **Active** である場合は、ユーザーの入力を確認し、どのようなゲーム内アクションが発生する必要があるかを特定します。
たとえば、ユーザーが特定の方向に左アナログ スティックを動かした場合、これによって、ゲームはスティックを動かした方向にプレイヤーを移動する必要があることを認知します。 特定の方向へのスティックの動きは、**デッド ゾーン**の半径より大きく登録される必要があります。大きく登録されないと、何も起きません。 このデッド ゾーンの半径は、"ドリフト" を防止するために必要です。この機能では、プレイヤーの指がスティック上にあるときに、指のわずかな動きをコントローラーが感知します。 デッド ゾーンがない場合、ユーザーはコントロールの感度が高すぎると感じることがあります。


サム スティックの入力は、x 軸と y 軸の両方について -1 ～ 1 の範囲です。 次の定数は、サムスティックのデッドゾーンの半径を指定します。

```cpp
#define THUMBSTICK_DEADZONE 0.25f
```

この変数を使用して、アクション可能なサムスティックの入力の処理を開始します。 いずれかの軸で値が [-1, -.26] または [.26, 1] から移動が発生します。

![サムスティックのデッド ゾーン](images/simple-dx-game-controls-deadzone.png)

**UpdatePollingDevices** メソッドの次の部分は、左右のサム スティックを処理します。
各スティックの X と Y の値について、デッド ゾーンの外側であるかどうかがチェックされます。 いずれかまたは両方がこれに該当する場合、対応するコンポーネントを更新します。
たとえば、左サムスティックが X 軸に沿って左に移動された場合、**m_moveCommand**ベクトルの **x** コンポーネントに -1 を加算します。 このベクトルは、すべてのデバイスのすべての動きを集計するために使用されるもので、後でプレイヤーが移動する場所を計算するために使用されます。 


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

左スティックが動きを制御するのと同様に、右スティックはカメラの回転を制御します。


右サムスティックの動作は、マウスとキーボード コントロールの設定でのマウス移動の動作と一致します。
スティックがデッド ゾーン外にある場合は、ポインターの現在の位置と、ユーザーが現在見ようとしている位置の差を計算します。
このポインターの位置の変化 (**pointerDelta**) を使用して、後で **Update** メソッドで適用されるカメラの回転のピッチとヨーが更新されます。
**pointerDelta** ベクトルには見覚えがあるかもしれません。これは、マウスとタッチ入力でポインターの位置の変化を追跡するために、[MoveLookController::OnPointerMoved](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L318-L395) メソッドでも使用されています。


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

このゲームのコントロールは、球体を発射する機能がなければ完成しません。


この **UpdatePollingDevices** メソッドは、右のトリガーが押されているかどうかも確認します。 右のトリガーが押された場合、**m_firePressed** プロパティは true になり、球体の発射を開始する必要があることをゲームに通知します。
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


## <a name="the-update-method"></a>Update メソッド

締めくくりとして、[**Update**](https://github.com/Microsoft/Windows-universal-samples/blob/ef073ed8a2007d113af1d88eddace479e3bf0e07/SharedContent/cpp/GameContent/MoveLookController.cpp#L1005-L1096) メソッドについて深く掘り下げてみましょう。
このメソッドは、プレイヤーがサポートされている入力を使用して行ったすべての動きや回転をマージして、ゲーム ループがアクセスする速度ベクトルを生成し、ピッチとヨーの値を更新します。


**Update** メソッドは、[**UpdatePollingDevices**](#the-updatepollingdevices-method) を呼び出してコントローラーの状態を更新することから処理を開始します。 また、このメソッドは、ゲームパッドからのすべての入力を収集し、その動きを **m_moveCommand** ベクトルに追加します。 

このサンプルの **Update** メソッドでは、以下の入力の確認を実行します。
- プレイヤーがムーブ コントローラーの四角形を使用している場合は、ポインターの位置の変化を確認し、それを使用してユーザーがコントローラーのデッド ゾーンの外側にポインターを移動したかどうかを計算します。 デッド ゾーンの外側である場合、仮想ジョイスティックの値を使用して **m_moveCommand** ベクトル プロパティが更新されます。
- 移動のキーボード入力のいずれかが押されている場合、**m_moveCommand** ベクトルの対応するコンポーネントに `1.0f` または `-1.0f` の値が追加されます。`1.0f` は前進、`-1.0f` は後退です。


すべての移動入力を考慮した後、**m_moveCommand** ベクトルに対していくつかの計算を実行し、ゲーム ワールドでのプレイヤーの方向を表す新しいベクトルを生成します。
次に、ワールドでの動きを取得し、それをその方向への速度としてプレイヤーに適用します。
最後に、**m_moveCommand** ベクトルを `(0.0f, 0.0f, 0.0f)` にリセットして、次のゲーム フレームを処理できるようにすべてを準備します。


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


## <a name="next-steps"></a>次の手順

これで、コントロールが追加されましたが、臨場感のあるゲームを作成するためにもう 1 つ追加しなければならない機能として、サウンドがあります。
ミュージックとサウンド効果はどのゲームでも重要であるため、次の「[サウンドの追加](tutorial--adding-sound.md)」で詳しく説明します。
 

 

 




