---
title: ゲームのムーブ/ルック コントロール
description: ここでは、マウスとキーボードの従来のムーブ/ルック コントロール (マウスルック コントロールとも呼ばれます) を DirectX ゲームに追加する方法について説明します。
ms.assetid: 4b4d967c-3de9-8a97-ae68-0327f00cc933
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, ムーブ/ルック, コントロール
ms.localizationpriority: medium
ms.openlocfilehash: 222f46bbda165442003aecea0bbd138bcb844a3b
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8789785"
---
# <a name="span-iddevgamingtutorialaddingmove-lookcontrolstoyourdirectxgamespanmove-look-controls-for-games"></a><span id="dev_gaming.tutorial__adding_move-look_controls_to_your_directx_game"></span>ゲームのムーブ/ルック コントロール



ここでは、マウスとキーボードの従来のムーブ/ルック コントロール (マウスルック コントロールとも呼ばれます) を DirectX ゲームに追加する方法について説明します。

さらに、タッチ デバイスでのムーブ/ルックのサポートについても説明します。タッチ デバイスでは、ムーブ コントローラーは画面の左下の部分として定義され、方向入力と同じように動作します。ルック コントローラーは、画面の残りの部分に対して定義されます。カメラは、中心をプレイヤーがその領域内で最後にタッチした場所に合わせます。

このコントロールの概念に詳しくない場合は、キーボード (またはタッチ ベースの方向入力ボックス) は、この 3D 空間内で足を制御し、足が前後または左右にしか動けないかのように機能するものと考えてください。 マウス (またはタッチ ポインター) は、頭を制御します。 頭を動かして、ある方向 (左、右、上、下、またはその平面のどこか) を見ます。 視界の中にターゲットがある場合、マウスを使ってカメラ ビューの中心をそのターゲットに合わせてから、前進キーを押してターゲットに向かって前進するか、後退キーを押してターゲットから後退します。 ターゲットの周りを旋回するには、カメラ ビューの中心をターゲットに合わせたまま、左右に動きます。 このように、この制御方法は 3D 環境のナビゲートに非常に有効です。

これらのコントロールは、ゲームでは一般的に WASD コントロールと呼ばれます。WASD コントロールでは、x-z 平面に固定されたカメラを動かすのに W、A、S、D のキーを使用し、x 軸と y 軸を中心としたカメラの回転を制御するのにマウスを使用します。

## <a name="objectives"></a>目標


-   マウス/キーボード用とタッチ スクリーン用の両方の基本的なムーブ/ルック コントロールを DirectX ゲームに追加する。
-   3D 環境のナビゲートに使う主観カメラを実装する。

## <a name="a-note-on-touch-control-implementations"></a>タッチ コントロールの実装に関する注意


タッチ コントロールには、2 つのコントローラーを実装します。1 つはカメラの視点に相対的な x-z 平面の動きを扱うムーブ コントローラー、もう 1 つはカメラの視点を合わせるためのルック コントローラーです。 ムーブ コントローラーはキーボードの WASD ボタンに相当し、ルック コントローラーはマウスに相当します。 ただし、タッチ コントロールでは、方向入力、または仮想的な WASD ボタンとして機能する画面の領域を定義する必要があります。画面の残りの部分は、ルック コントロール用の入力領域として機能します。

画面は次のようになります。

![ムーブ/ルック コントローラーのレイアウト](images/movelook-touch.png)

タッチ ポインター (マウスではなく) を画面の左下で動かす場合、上方向に動かすとカメラは前方に動きます。 下方向に動かすとカメラは後方に動きます。 ムーブ コントローラーのポインター領域内でポインターを左右に動かす場合にも同じことが当てはまります。 この領域外ではルック コントローラーになるため、カメラを単にタッチまたはドラッグして、希望の向きにします。

## <a name="set-up-the-basic-input-event-infrastructure"></a>基本的な入力イベントのインフラストラクチャのセットアップ


まず、マウスとキーボードからの入力イベントの処理と、その入力に基づいたカメラの視点の更新を行うコントロール クラスを作成する必要があります。 実装するのはムーブ/ルック コントロールであるため、**MoveLookController** という名前を付けます。

```cpp
using namespace Windows::UI::Core;
using namespace Windows::System;
using namespace Windows::Foundation;
using namespace Windows::Devices::Input;
#include <DirectXMath.h>

// Methods to get input from the UI pointers
ref class MoveLookController
{
};  // class MoveLookController
```

次に、ムーブ/ルック コントローラーの状態とその主観カメラを定義するヘッダーと、コントロールを実装してカメラの状態を更新する基本的なメソッドとイベント ハンドラーを作成します。

```cpp
#define ROTATION_GAIN 0.004f    // Sensitivity adjustment for the look controller
#define MOVEMENT_GAIN 0.1f      // Sensitivity adjustment for the move controller

ref class MoveLookController
{
private:
    // Properties of the controller object
    DirectX::XMFLOAT3 m_position;               // The position of the controller
    float m_pitch, m_yaw;           // Orientation euler angles in radians

    // Properties of the Move control
    bool m_moveInUse;               // Specifies whether the move control is in use
    uint32 m_movePointerID;         // Id of the pointer in this control
    DirectX::XMFLOAT2 m_moveFirstDown;          // Point where initial contact occurred
    DirectX::XMFLOAT2 m_movePointerPosition;   // Point where the move pointer is currently located
    DirectX::XMFLOAT3 m_moveCommand;            // The net command from the move control

    // Properties of the Look control
    bool m_lookInUse;               // Specifies whether the look control is in use
    uint32 m_lookPointerID;         // Id of the pointer in this control
    DirectX::XMFLOAT2 m_lookLastPoint;          // Last point (from last frame)
    DirectX::XMFLOAT2 m_lookLastDelta;          // For smoothing

    bool m_forward, m_back;         // States for movement
    bool m_left, m_right;
    bool m_up, m_down;


public:

    // Methods to get input from the UI pointers
    void OnPointerPressed(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::PointerEventArgs^ args
        );

    void OnPointerMoved(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::PointerEventArgs^ args
        );

    void OnPointerReleased(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::PointerEventArgs^ args
        );

    void OnKeyDown(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::KeyEventArgs^ args
        );

    void OnKeyUp(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::KeyEventArgs^ args
        );

    // Set up the Controls that this controller supports
    void Initialize( _In_ Windows::UI::Core::CoreWindow^ window );

    void Update( Windows::UI::Core::CoreWindow ^window );
    
internal:
    // Accessor to set position of controller
    void SetPosition( _In_ DirectX::XMFLOAT3 pos );

    // Accessor to set position of controller
    void SetOrientation( _In_ float pitch, _In_ float yaw );

    // Returns the position of the controller object
    DirectX::XMFLOAT3 get_Position();

    // Returns the point  which the controller is facing
    DirectX::XMFLOAT3 get_LookPoint();


};  // class MoveLookController
```

このコードには、プライベート フィールドのグループが 4 つ含まれています。 それぞれの目的を確認してみましょう。

まず、カメラ ビューに関する更新情報を保持する、便利なフィールドをいくつか定義します。

-   **m\_position** は、3D シーン内のカメラ (とビュー平面) の位置であり、シーンの座標を使います。
-   **m\_pitch** は、カメラのピッチ (ビュー平面の x 軸を中心とする上下の回転) であり、単位はラジアンです。
-   **m\_yaw** は、カメラのヨー (ビュー平面の y 軸を中心とする左右の回転) であり、単位はラジアンです。

次に、コントローラーの状態と位置に関する情報を格納するフィールドを定義してみましょう。 まず、タッチ ベースのムーブ コントローラーに必要なフィールドを定義します。 (ムーブ コントローラーのキーボード実装に関して特別必要なことはありません。 キーボードのイベントと具体的なハンドラーについては先ほど説明しました。)

-   **m\_moveInUse** は、ムーブ コントローラーが使用中かどうかを示します。
-   **m\_movePointerID** は、現在のムーブ ポインターの一意の ID です。 これは、ポインターの ID 値を確認するときにルック ポインターとムーブ ポインターを区別するために使います。
-   **m\_moveFirstDown** は、プレイヤーがムーブ コントローラーのポインター領域で最初にタッチした画面上の点です。 この値は、小さな動きによってビューが不安定にならないようデッド ゾーンを設定するために後で使います。
-   **m\_movePointerPosition** は、プレイヤーがポインターを現在動かしたばかりの画面上の点です。 これは、**m\_moveFirstDown** と比較して確認することで、プレイヤーが移動したい方向を判断するために使います。
-   **m\_moveCommand** は、ムーブ コントローラーに対して計算された最終的なコマンドであり、up (前進)、down (後退)、left (左)、または right (右) です。

次に、ルック コントローラーに使うフィールドを、マウス実装とタッチ実装の両方に対して定義します。

-   **m\_lookInUse** は、ルック コントロールが使用中かどうかを示します。
-   **m\_lookPointerID** は、現在のルック ポインターの一意の ID です。 これは、ポインターの ID 値を確認するときにルック ポインターとムーブ ポインターを区別するために使います。
-   **m\_lookLastPoint** は、シーンの座標内の、前のフレーム内でキャプチャされた最後の点です。
-   **m\_lookLastDelta** は、現在の **m\_position** と **m\_lookLastPoint** との違いを計算した値です。

最後に、6 段階の動きに対して次の 6 つのブール値を定義します。これらの値は、それぞれの方向移動操作の現在の状態 (オンまたはオフ) を示すために使います。

-   **m\_forward**、**m\_back**、**m\_left**、**m\_right**、**m\_up**、**m\_down**。

これら 6 つのイベント ハンドラーを使って、次のコントローラーの状態を更新するための入力データをキャプチャします。

-   **OnPointerPressed**。 プレイヤーが、ポインターがゲーム画面にある状態でマウスの左ボタンを押したか、画面にタッチしました。
-   **OnPointerMoved**。 プレイヤーが、ポインターがゲーム画面にある状態でマウスを動かしたか、画面上でタッチ ポインターをドラッグしました。
-   **OnPointerReleased**。 プレイヤーが、ポインターがゲーム画面にある状態でマウスの左ボタンを離したか、画面から手を離しました。
-   **OnKeyDown**。 プレイヤーがキーを押しました。
-   **OnKeyUp**。 プレイヤーがキーを離しました。

最後に、次のメソッドとプロパティを使って、コントローラーの状態情報の初期化、アクセス、更新を行います。

-   **Initialize**。 Windows ストア アプリは、コントロールを初期化して、表示ウィンドウを定義する [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトにそれらのコントロールを適用するときに、このイベント ハンドラーを呼び出します。
-   **SetPosition**。 Windows ストア アプリは、シーン空間内のコントロールの (x、y、z) 座標を設定するときに、このメソッドを呼び出します。
-   **SetOrientation**。 Windows ストア アプリは、カメラのピッチとヨーを設定するときに、このメソッドを呼び出します。
-   **get\_Position**。 Windows ストア アプリは、シーン空間内のカメラの現在の位置を取得するときに、このプロパティにアクセスします。 このプロパティは、カメラの現在の位置をアプリに伝える手段として使います。
-   **get\_LookPoint**。 Windows ストア アプリは、現在コントローラーのカメラが向いている点を取得するときに、このプロパティにアクセスします。
-   **Update**。 ムーブ コントローラーとルック コントローラーの状態を読み取り、カメラの位置を更新します。 このメソッドをアプリのメイン ループから継続的に呼び出して、カメラ コントローラーのデータとシーン空間内のカメラの位置を更新します。

これで、ムーブ/ルック コントロールの実装に必要なコンポーネントがすべて揃いました。 次は、これらのコンポーネントどうしを接続してみましょう。

## <a name="create-the-basic-input-events"></a>基本的な入力イベントを作成する


Windows ランタイムのイベント ディスパッチャーは、**MoveLookController** クラスのインスタンスで処理するイベントを 5 つ提供します。

-   [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208278)
-   [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276)
-   [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279)
-   [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208271)
-   [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208270)

これらのイベントは、[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) 型に実装されています。 ここでは、操作する **CoreWindow** オブジェクトが既にあると想定しています。 取得方法が不明な場合は、「[ユニバーサル Windows プラットフォーム (UWP) C++ アプリで DirectX ビューを表示するための設定方法](https://msdn.microsoft.com/library/windows/apps/hh465077)」をご覧ください。

これらのイベントは Windows ストア アプリの実行中に起動するため、ハンドラーはプライベート フィールドに定義されているコントローラーの状態情報を更新します。

まず、マウス ポインターとタッチ ポインターのイベント ハンドラーを設定します。 最初のイベント ハンドラーである **OnPointerPressed()** では、ユーザーがルック コントローラー領域でマウスをクリックまたは画面をタッチすると、表示を管理する [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) からポインターの x-y 座標を取得します。

**OnPointerPressed**

```cpp
void MoveLookController::OnPointerPressed(
_In_ CoreWindow^ sender,
_In_ PointerEventArgs^ args)
{
    // Get the current pointer position.
    uint32 pointerID = args->CurrentPoint->PointerId;
    DirectX::XMFLOAT2 position = DirectX::XMFLOAT2( args->CurrentPoint->Position.X, args->CurrentPoint->Position.Y );

    auto device = args->CurrentPoint->PointerDevice;
    auto deviceType = device->PointerDeviceType;
    if ( deviceType == PointerDeviceType::Mouse )
    {
        // Action, Jump, or Fire
    }

    // Check  if this pointer is in the move control.
    // Change the values  to percentages of the preferred screen resolution.
    // You can set the x value to <preferred resolution> * <percentage of width>
    // for example, ( position.x < (screenResolution.x * 0.15) ).

    if (( position.x < 300 && position.y > 380 ) && ( deviceType != PointerDeviceType::Mouse ))
    {
        if ( !m_moveInUse ) // if no pointer is in this control yet
        {
            // Process a DPad touch down event.
            m_moveFirstDown = position;                 // Save the location of the initial contact.
            m_movePointerPosition = position;
            m_movePointerID = pointerID;                // Store the id of the pointer using this control.
            m_moveInUse = TRUE;
        }
    }
    else // This pointer must be in the look control.
    {
        if ( !m_lookInUse ) // If no pointer is in this control yet...
        {
            m_lookLastPoint = position;                         // save the point for later move
            m_lookPointerID = args->CurrentPoint->PointerId;  // store the id of pointer using this control
            m_lookLastDelta.x = m_lookLastDelta.y = 0;          // these are for smoothing
            m_lookInUse = TRUE;
        }
    }
}
```

このイベント ハンドラーは、ポインターがマウスでないかどうか (このサンプルではマウスとタッチの両方をサポートするため) と、ムーブ コントローラー領域内にあるかどうかを確認します。 両方の条件が true の場合は、**m\_moveInUse** が false かどうかをテストして、ポインターが押されたばかりかどうか、具体的には、このクリックが前のムーブ入力またはルック入力に無関係かどうかを確認します。 無関係な場合、ハンドラーはムーブ コントローラー領域で押し操作が発生した点をキャプチャして **m\_moveInUse** を true に設定し、このハンドラーが再び呼び出されたときにムーブ コントローラーの入力操作の開始位置が上書きされないようにします。 さらに、ムーブ コントローラーのポインター ID を現在のポインターの ID に更新します。

ポインターがマウスの場合、またはタッチ ポインターがムーブ コントローラー領域内にない場合は、ルック コントローラー領域内にある必要があります。 このハンドラーは、ユーザーがマウスのボタンを押した、またはタッチして押した現在の場所に **m\_lookLastPoint** を設定し、差分をリセットして、ルック コントローラーのポインター ID を現在のポインターの ID に更新します。 また、ルック コントローラーの状態をアクティブに設定します。

**OnPointerMoved**

```cpp
void MoveLookController::OnPointerMoved(
    _In_ CoreWindow ^sender,
    _In_ PointerEventArgs ^args)
{
    uint32 pointerID = args->CurrentPoint->PointerId;
    DirectX::XMFLOAT2 position = DirectX::XMFLOAT2(args->CurrentPoint->Position.X, args->CurrentPoint->Position.Y);

    // Decide which control this pointer is operating.
    if (pointerID == m_movePointerID)           // This is the move pointer.
    {
        // Move control
        m_movePointerPosition = position;       // Save the current position.

    }
    else if (pointerID == m_lookPointerID)      // This is the look pointer.
    {
        // Look control

        DirectX::XMFLOAT2 pointerDelta;
        pointerDelta.x = position.x - m_lookLastPoint.x;        // How far did pointer move
        pointerDelta.y = position.y - m_lookLastPoint.y;

        DirectX::XMFLOAT2 rotationDelta;
        rotationDelta.x = pointerDelta.x * ROTATION_GAIN;   // Scale for control sensitivity.
        rotationDelta.y = pointerDelta.y * ROTATION_GAIN;

        m_lookLastPoint = position;                     // Save for the next time through.

                                                        // Update our orientation based on the command.
        m_pitch -= rotationDelta.y;                     // Mouse y increases down, but pitch increases up.
        m_yaw -= rotationDelta.x;                       // Yaw is defined as CCW around the y-axis.

                                                        // Limit the pitch to straight up or straight down.
        m_pitch = (float)__max(-DirectX::XM_PI / 2.0f, m_pitch);
        m_pitch = (float)__min(+DirectX::XM_PI / 2.0f, m_pitch);
    }
}
```

**OnPointerMoved** イベント ハンドラーは、ポインターが動くたび起動します (この場合、タッチ スクリーンのポインターがドラッグされているとき、またはマウスの左ボタンを押しながらマウス ポインターが動かされているとき)。 ポインター ID がムーブ コントローラーのポインターの ID と同じ場合は、ムーブ ポインターになります。違う場合は、アクティブなポインターであるルック コントローラーかどうかを確認します。

ムーブ コントローラーの場合は、単にポインターの位置を更新します。 **OnPointerPressed** イベント ハンドラーでキャプチャした最初の位置と最後の位置を比較するため、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276) イベントが起動を続ける限りポインターの位置を更新し続けます。

ルック コントローラーの場合は、やや複雑になります。 新しい視点を計算してカメラの中心をそこに合わせ、前の視点と現在の画面の位置との差分を計算する必要があります。その後、倍率を乗算します。倍率を調整すると、画面移動の距離に比例して動きが小さくまたは大きく見えるようにすることができます。 その値を使って、ピッチとヨーを計算します。

最後に、プレイヤーがマウスの移動を停止したとき、または画面から手を離したときに、ムーブ コントローラーまたはルック コントローラーの動作を非アクティブにする必要があります。 **m\_moveInUse** または **m\_lookInUse** を FALSE に設定してカメラのパン移動をオフにし、ポインター ID をゼロにするには、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) の起動時に呼び出す **OnPointerReleased** を使います。

**OnPointerReleased**

```cpp
void MoveLookController::OnPointerReleased(
_In_ CoreWindow ^sender,
_In_ PointerEventArgs ^args)
{
    uint32 pointerID = args->CurrentPoint->PointerId;
    DirectX::XMFLOAT2 position = DirectX::XMFLOAT2( args->CurrentPoint->Position.X, args->CurrentPoint->Position.Y );


    if ( pointerID == m_movePointerID )    // This was the move pointer.
    {
        m_moveInUse = FALSE;
        m_movePointerID = 0;
    }
    else if (pointerID == m_lookPointerID ) // This was the look pointer.
    {
        m_lookInUse = FALSE;
        m_lookPointerID = 0;
    }
}
```

今まで処理したのは、すべてタッチ スクリーン イベントでした。 次は、キーボード ベースのムーブ コントローラー用のキー入力イベントを処理しましょう。

**OnKeyDown**

```cpp
void MoveLookController::OnKeyDown(
                                   __in CoreWindow^ sender,
                                   __in KeyEventArgs^ args )
{
    Windows::System::VirtualKey Key;
    Key = args->VirtualKey;

    // Figure out the command from the keyboard.
    if ( Key == VirtualKey::W )     // Forward
        m_forward = true;
    if ( Key == VirtualKey::S )     // Back
        m_back = true;
    if ( Key == VirtualKey::A )     // Left
        m_left = true;
    if ( Key == VirtualKey::D )     // Right
        m_right = true;
}
```

これらのキーのいずれかが押されている限り、このイベント ハンドラーは対応する方向移動状態を true に設定します。

**OnKeyUp**

```cpp
void MoveLookController::OnKeyUp(
                                 __in CoreWindow^ sender,
                                 __in KeyEventArgs^ args)
{
    Windows::System::VirtualKey Key;
    Key = args->VirtualKey;

    // Figure out the command from the keyboard.
    if ( Key == VirtualKey::W )     // forward
        m_forward = false;
    if ( Key == VirtualKey::S )     // back
        m_back = false;
    if ( Key == VirtualKey::A )     // left
        m_left = false;
    if ( Key == VirtualKey::D )     // right
        m_right = false;
}
```

キーが離されると、状態を false にリセットします。 **Update** を呼び出すと、これらの方向移動状態が確認され、それに従ってカメラが動きます。 これは、タッチ実装より少し簡単です。

## <a name="initialize-the-touch-controls-and-the-controller-state"></a>タッチ コントロールとコントローラーの状態の初期化


次は、イベントをフックして、コントローラー状態の全フィールドを初期化しましょう。

**Initialize**

```cpp
void MoveLookController::Initialize( _In_ CoreWindow^ window )
{

    // Opt in to receive touch/mouse events.
    window->PointerPressed += 
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerPressed);

    window->PointerMoved += 
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerMoved);

    window->PointerReleased += 
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &MoveLookController::OnPointerReleased);

    window->CharacterReceived +=
    ref new TypedEventHandler<CoreWindow^, CharacterReceivedEventArgs^>(this, &MoveLookController::OnCharacterReceived);

    window->KeyDown += 
    ref new TypedEventHandler<CoreWindow^, KeyEventArgs^>(this, &MoveLookController::OnKeyDown);

    window->KeyUp += 
    ref new TypedEventHandler<CoreWindow^, KeyEventArgs^>(this, &MoveLookController::OnKeyUp);

    // Initialize the state of the controller.
    m_moveInUse = FALSE;                // No pointer is in the Move control.
    m_movePointerID = 0;

    m_lookInUse = FALSE;                // No pointer is in the Look control.
    m_lookPointerID = 0;

    //  Need to init this as it is reset every frame.
    m_moveCommand = DirectX::XMFLOAT3( 0.0f, 0.0f, 0.0f );

    SetOrientation( 0, 0 );             // Look straight ahead when the app starts.

}
```

**Initialize** は、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) インスタンスへの参照をパラメーターとして使い、先ほど作成したイベント ハンドラーをその **CoreWindow** の適切なイベントに登録します。 このハンドラーは、ムーブ ポインターとルック ポインターの ID を初期化し、タッチ スクリーンのムーブ コントローラー実装用のコマンド ベクターをゼロに設定して、アプリの起動時にカメラが正面を向くように設定します。

## <a name="getting-and-setting-the-position-and-orientation-of-the-camera"></a>カメラの位置と向きの取得と設定


ビューポートに対してカメラの位置の取得と設定を行うメソッドをいくつか定義してみましょう。

```cpp
void MoveLookController::SetPosition( _In_ DirectX::XMFLOAT3 pos )
{
    m_position = pos;
}

// Accessor to set the position of the controller.
void MoveLookController::SetOrientation( _In_ float pitch, _In_ float yaw )
{
    m_pitch = pitch;
    m_yaw = yaw;
}

// Returns the position of the controller object.
DirectX::XMFLOAT3 MoveLookController::get_Position()
{
    return m_position;
}

// Returns the point at which the camera controller is facing.
DirectX::XMFLOAT3 MoveLookController::get_LookPoint()
{
    float y = sinf(m_pitch);        // Vertical
    float r = cosf(m_pitch);        // In the plane
    float z = r*cosf(m_yaw);        // Fwd-back
    float x = r*sinf(m_yaw);        // Left-right
    DirectX::XMFLOAT3 result(x,y,z);
    result.x += m_position.x;
    result.y += m_position.y;
    result.z += m_position.z;

    // Return m_position + DirectX::XMFLOAT3(x, y, z);
    return result;
}
```

## <a name="updating-the-controller-state-info"></a>コントローラーの状態情報の更新


次は、**m\_movePointerPosition** で追跡したポインターの座標情報を、ワールド座標系における新しい座標情報に変換する計算を実行します。 Windows ストア アプリは、アプリのメイン ループが更新されるたびに、このメソッドを呼び出します。 このため、ビュー マトリックスをビューポートへのプロジェクションの前に更新するためにアプリに渡す新しい視点位置情報は、ここで計算します。

```cpp
void MoveLookController::Update(CoreWindow ^window)
{
    // Check for input from the Move control.
    if (m_moveInUse)
    {
        DirectX::XMFLOAT2 pointerDelta(m_movePointerPosition);
        pointerDelta.x -= m_moveFirstDown.x;
        pointerDelta.y -= m_moveFirstDown.y;

        // Figure out the command from the touch-based virtual joystick.
        if (pointerDelta.x > 16.0f)      // Leave 32 pixel-wide dead spot for being still.
            m_moveCommand.x = 1.0f;
        else
            if (pointerDelta.x < -16.0f)
            m_moveCommand.x = -1.0f;

        if (pointerDelta.y > 16.0f)      // Joystick y is up, so change sign.
            m_moveCommand.y = -1.0f;
        else
            if (pointerDelta.y < -16.0f)
            m_moveCommand.y = 1.0f;
    }

    // Poll our state bits that are set by the keyboard input events.
    if (m_forward)
        m_moveCommand.y += 1.0f;
    if (m_back)
        m_moveCommand.y -= 1.0f;

    if (m_left)
        m_moveCommand.x -= 1.0f;
    if (m_right)
        m_moveCommand.x += 1.0f;

    if (m_up)
        m_moveCommand.z += 1.0f;
    if (m_down)
        m_moveCommand.z -= 1.0f;

    // Make sure that 45 degree cases are not faster.
    DirectX::XMFLOAT3 command = m_moveCommand;
    DirectX::XMVECTOR vector;
    vector = DirectX::XMLoadFloat3(&command);

    if (fabsf(command.x) > 0.1f || fabsf(command.y) > 0.1f || fabsf(command.z) > 0.1f)
    {
        vector = DirectX::XMVector3Normalize(vector);
        DirectX::XMStoreFloat3(&command, vector);
    }
    

    // Rotate command to align with our direction (world coordinates).
    DirectX::XMFLOAT3 wCommand;
    wCommand.x = command.x*cosf(m_yaw) - command.y*sinf(m_yaw);
    wCommand.y = command.x*sinf(m_yaw) + command.y*cosf(m_yaw);
    wCommand.z = command.z;

    // Scale for sensitivity adjustment.
    wCommand.x = wCommand.x * MOVEMENT_GAIN;
    wCommand.y = wCommand.y * MOVEMENT_GAIN;
    wCommand.z = wCommand.z * MOVEMENT_GAIN;

    // Our velocity is based on the command.
    // Also note that y is the up-down axis. 
    DirectX::XMFLOAT3 Velocity;
    Velocity.x = -wCommand.x;
    Velocity.z = wCommand.y;
    Velocity.y = wCommand.z;

    // Integrate
    m_position.x += Velocity.x;
    m_position.y += Velocity.y;
    m_position.z += Velocity.z;

    // Clear movement input accumulator for use during the next frame.
    m_moveCommand = DirectX::XMFLOAT3(0.0f, 0.0f, 0.0f);

}
```

プレイヤーがタッチ ベースのムーブ コントローラーを使う場合に動きが不安定にならないように、ポインターの周りに直径 32 ピクセルの仮想デッド ゾーンを設定します。 また、コマンド値に移動ゲイン速度を加えた速度も追加します  (この動作は、ポインターがムーブ コントローラー領域内で動く距離に基づいて移動速度を低下または上昇させることができるように、任意に調整できます。)

速度を計算するときは、さらに、ムーブ コントローラーとルック コントローラーから受け取った座標を、シーンのビュー マトリックスを計算するメソッドに送信する実際の視点の動きに変換します。 まず、x 座標を反転します。これは、ルック コントローラーで、クリックしてから左または右方向への移動またはドラッグを行うと、カメラがその中心軸の周囲でスイングするように視点がシーン内で反対方向に回転するためです。 次に、y 軸と z 軸を入れ替えます。これは、ムーブ コントローラーで、上/下方向キーを押す、またはタッチ ドラッグ動作 (y 軸動作として読み取られます) を行うと、視点を画面 (z 軸) の中に、または外へ動かすカメラ操作が行われるためです。

プレイヤーの視点の最後の位置は、計算された速度を最後の位置に加えたものであり、この位置は、レンダラーが **get\_Position** メソッドを呼び出すときにレンダラーが読み取ります (通常は各フレームのセットアップ中)。 その後、移動コマンドをゼロにリセットします。

## <a name="updating-the-view-matrix-with-the-new-camera-position"></a>カメラの新しい位置によるビュー マトリックスの更新


カメラのフォーカスが合っているシーン空間の座標を取得できます。この座標は、アプリに指定した時間ごとに更新されます (たとえばアプリのメイン ループでは 60 秒ごと)。 次の疑似コードは、実装できる呼び出し動作を示しています。

```cpp
myMoveLookController->Update( m_window );   

// Update the view matrix based on the camera position.
myFirstPersonCamera->SetViewParameters(
                 myMoveLookController->get_Position(),       // Point we are at
                 myMoveLookController->get_LookPoint(),      // Point to look towards
                 DirectX::XMFLOAT3( 0, 1, 0 )                   // Up-vector
                 ); 
```

これで、 タッチ スクリーン用とキーボード/マウス用の入力タッチ コントロールの両方の基本的なムーブ/ルック コントロールがゲームで実装されました。



 

 




