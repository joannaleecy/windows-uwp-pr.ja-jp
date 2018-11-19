---
author: mtoepke
title: ゲームのタッチ コントロール
description: ここでは、DirectX を使うユニバーサル Windows プラットフォーム (UWP) C++ ゲームに、基本的なタッチ コントロールを追加する方法について説明します。
ms.assetid: 9d40e6e4-46a9-97e9-b848-522d61e8e109
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, タッチ, コントロール, DirectX, 入力
ms.localizationpriority: medium
ms.openlocfilehash: 53c4a91f3ef20c11783796c3ca362f74b3f39adb
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7285724"
---
# <a name="touch-controls-for-games"></a>ゲームのタッチ コントロール



ここでは、DirectX を使うユニバーサル Windows プラットフォーム (UWP) C++ ゲームに、基本的なタッチ コントロールを追加する方法について説明します。 具体的には、平面に固定されたカメラを動かすタッチ ベースのコントロールを、指またはスタイラスでドラッグするとカメラの視点がシフトする Direct3D 環境に追加する方法を紹介します。

これらのコントロールは、プレイヤーが地図やプレイフィールドなどの 3D 環境でドラッグしてスクロールまたはパンを行うゲームに組み込むことができます。 たとえば、戦略ゲームやパズル ゲームでは、これらのコントロールを使って、プレイヤーが左右にパンすることで画面より大きいゲーム環境を確認できるようにすることが可能です。

> **注:** コードは、マウス ベースのパン コントロールでも動作します。 ポインター関連のイベントは、Windows ランタイム API で抽象化されるため、タッチまたはマウス ベースのポインター イベントを処理できます。

 

## <a name="objectives"></a>目標


-   DirectX ゲームで平面に固定されたカメラをパンする簡単なタッチ ドラッグ コントロールを作成する。

## <a name="set-up-the-basic-touch-event-infrastructure"></a>基本的なタッチ イベントのインフラストラクチャのセットアップ


まず、この例ではコントローラーの基本型として、**CameraPanController** を定義します。 ここでは、コントローラーを抽象的な概念、つまりユーザーが実行できる動作のセットとして定義します。

**CameraPanController** クラスは、カメラ コントローラーの状態に関する情報を定期的に更新したコレクションであり、アプリが自身の更新ループからこの情報を取得できるようにします。

```cpp
using namespace Windows::UI::Core;
using namespace Windows::System;
using namespace Windows::Foundation;
using namespace Windows::Devices::Input;
#include <directxmath.h>

// Methods to get input from the UI pointers
ref class CameraPanController
{
}
```

次に、カメラ コントローラーの状態を定義するヘッダーと、カメラ コントローラーの操作を実装する基本的なメソッドとイベント ハンドラーを作ります。

```cpp
ref class CameraPanController
{
private:
    // Properties of the controller object
    DirectX::XMFLOAT3 m_position;               // the position of the camera

    // Properties of the camera pan control
    bool m_panInUse;                
    uint32 m_panPointerID;          
    DirectX::XMFLOAT2 m_panFirstDown;           
    DirectX::XMFLOAT2 m_panPointerPosition;   
    DirectX::XMFLOAT3 m_panCommand;         
    
internal:
    // Accessor to set the position of the controller
    void SetPosition( _In_ DirectX::XMFLOAT3 pos );

       // Accessor to set the fixed "look point" of the controller
       DirectX::XMFLOAT3 get_FixedLookPoint();

    // Returns the position of the controller object
    DirectX::XMFLOAT3 get_Position();

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

    // Set up the Controls supported by this controller
    void Initialize( _In_ Windows::UI::Core::CoreWindow^ window );

    void Update( Windows::UI::Core::CoreWindow ^window );

};  // Class CameraPanController
```

プライベート フィールドには、カメラ コントローラーの現在の状態が含まれています。 ここでその内容を確認してみましょう。

-   **m\_position** は、シーン空間内のカメラの位置です。 この例では、z 座標値は 0 に固定されています。 DirectX::XMFLOAT2 を使ってこの値を表すこともできますが、このサンプルの目的と今後の拡張性を考慮して、ここでは DirectX::XMFLOAT3 を使います。 この値は、**get\_Position** プロパティを通じてアプリ自体に渡し、それに従ってアプリがビューポートを更新できるようにします。
-   **m\_panInUse** は、パン操作がアクティブかどうかを示すブール値です。より具体的には、プレイヤーが画面をタッチしてカメラを動かしているかどうかを示します。
-   **m\_panPointerID** は、ポインターの一意の ID です。 これはこのサンプルでは使いませんが、コントローラーの状態クラスと特定のポインターを関連付けることをお勧めします。
-   **m\_panFirstDown** は、カメラのパン操作中にプレイヤーが最初に画面をタッチまたはマウスをクリックした画面上の点です。 この値は、画面がタッチされているときや、マウスが少し揺れている場合に、ビューが不安定にならないようデッド ゾーンを設定するために後で使います。
-   **m\_panPointerPosition** は、プレイヤーがポインターを現在動かしたばかりの画面上の点です。 これは、**m\_panFirstDown** と比較して確認することで、プレイヤーが移動したい方向を判断するために使います。
-   **m\_panCommand** は、カメラ コントローラーに対して計算された最終的なコマンドであり、up、down、left、または right です。 x-y 平面に固定されたカメラを操作しているため、これは、DirectX::XMFLOAT2 にすることも可能です。

次の 3 つのイベント ハンドラーを使って、カメラ コントローラーの状態情報を更新します。

-   **OnPointerPressed** は、プレイヤーが指でタッチ画面を押し、その押された座標にポインターが動いたときに、アプリが呼び出すイベント ハンドラーです。
-   **OnPointerMoved** は、プレイヤーが指でタッチ画面をスワイプしたときに、アプリが呼び出すイベント ハンドラーです。 これは、ドラッグ パスの新しい座標で更新されます。
-   **OnPointerReleased** は、プレイヤーが指をタッチ画面から離したときに、アプリが呼び出すイベント ハンドラーです。

最後に、次のメソッドとプロパティを使って、カメラ コントローラーの状態情報の初期化、アクセス、更新を行います。

-   **Initialize** は、アプリがコントロールを初期化して、表示ウィンドウを定義する [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトにそれらのコントロールを適用するときに呼び出すイベント ハンドラーです。
-   **SetPosition** は、アプリがシーン空間内のコントロールの (x、y、z) 座標を設定するときに呼び出すメソッドです。 z 座標はこのチュートリアル全体で 0 であることに注意してください。
-   **get\_Position** は、アプリがシーン空間内のカメラの現在の位置を取得するときにアクセスするプロパティです。 このプロパティは、カメラの現在の位置をアプリに伝える手段として使います。
-   **get\_FixedLookPoint** は、アプリが現在コントローラーのカメラが向いている点を取得するときにアクセスするプロパティです。 この例では、x-y 平面に垂直にロックされています。
-   **Update** は、コントローラーの状態を読み取り、カメラの位置を更新するメソッドです。 このメソッドをアプリのメイン ループから継続的に呼び出して、カメラ コントローラーのデータとシーン空間内のカメラの位置を更新します。

これで、タッチ コントロールの実装に必要なコンポーネントがすべて揃いました。 タッチ ポインターまたはマウス ポインターのイベントがいつどこで発生し、その操作が何かを検出できます。 また、カメラの位置と向きをシーン空間と相対的に設定し、変化を追跡できます。 さらに、カメラの新しい位置を呼び出し元アプリに伝えることができます。

次は、これらのコンポーネントどうしを接続してみましょう。

## <a name="create-the-basic-touch-events"></a>基本的なタッチ イベントの作成


Windows ランタイムのイベント ディスパッチャーは、アプリで処理するイベントを 3 つ提供します。

-   [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208278)
-   [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208276)
-   [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279)

これらのイベントは、[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) 型に実装されています。 ここでは、操作する **CoreWindow** オブジェクトが既にあると想定しています。 詳しくは、「[UWP C++ アプリで DirectX ビューを表示するための設定方法](https://msdn.microsoft.com/library/windows/apps/hh465077)」をご覧ください。

これらのイベントは Windows ストア アプリの実行中に起動するため、ハンドラーはプライベート フィールドに定義されているカメラ コントローラーの状態情報を更新します。

まず、タッチ ポインターのイベント ハンドラーを設定します。 最初のイベント ハンドラーである **OnPointerPressed** では、ユーザーが画面をタッチまたはマウスをクリックしたときに表示を管理する [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) からポインターの x-y 座標を取得します。

**OnPointerPressed**

```cpp
void CameraPanController::OnPointerPressed(
                                           _In_ CoreWindow^ sender,
                                           _In_ PointerEventArgs^ args)
{
    // Get the current pointer position.
    uint32 pointerID = args->CurrentPoint->PointerId;
    DirectX::XMFLOAT2 position = DirectX::XMFLOAT2( args->CurrentPoint->Position.X, args->CurrentPoint->Position.Y );

    auto device = args->CurrentPoint->PointerDevice;
    auto deviceType = device->PointerDeviceType;
    

       if ( !m_panInUse )   // If no pointer is in this control yet.
    {
       m_panFirstDown = position;                   // Save the location of the initial contact.
       m_panPointerPosition = position;
       m_panPointerID = pointerID;              // Store the id of the pointer using this control.
       m_panInUse = TRUE;
    }
    
}
```

このハンドラーを使って、現在の **CameraPanController** インスタンスに、**m\_panInUse** を TRUE に設定してカメラ コントローラーをアクティブとして扱う必要があることを伝えます。 この方法により、アプリは **Update** を呼び出すときに、現在の位置データを使ってビューポートを更新します。

以上で、ユーザーが画面をタッチまたは表示ウィンドウをクリックしたときのカメラの動きを示す基本の値が設定されたので、次は、ユーザーが画面を押してドラッグまたはボタンを押してマウスを動かしたときに何をするかを決める必要があります。

**OnPointerMoved** イベント ハンドラーは、ポインターが動くたびに、プレイヤーがポインターを画面上でドラッグするティックごとに起動します。 アプリにポインターの現在の位置を知らせ続ける必要があるため、次のように指定します。

**OnPointerMoved**

```cpp
void CameraPanController::OnPointerMoved(
                                        _In_ CoreWindow ^sender,
                                        _In_ PointerEventArgs ^args)
{
    uint32 pointerID = args->CurrentPoint->PointerId;
    DirectX::XMFLOAT2 position = DirectX::XMFLOAT2( args->CurrentPoint->Position.X, args->CurrentPoint->Position.Y );

    m_panPointerPosition = position;
}
```

最後に、プレイヤーが画面から手を離したときに、カメラのパン動作を非アクティブにする必要があります。 **m\_panInUse** を FALSE に設定してカメラのパン移動をオフにし、ポインター ID を 0 に設定するには、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) の起動時に呼び出される **OnPointerReleased** を使います。

**OnPointerReleased**

```cpp
void CameraPanController::OnPointerReleased(
                                             _In_ CoreWindow ^sender,
                                             _In_ PointerEventArgs ^args)
{
    uint32 pointerID = args->CurrentPoint->PointerId;
    DirectX::XMFLOAT2 position = DirectX::XMFLOAT2( args->CurrentPoint->Position.X, args->CurrentPoint->Position.Y );

    m_panInUse = FALSE;
    m_panPointerID = 0;
}
```

## <a name="initialize-the-touch-controls-and-the-controller-state"></a>タッチ コントロールとコントローラーの状態の初期化


次は、イベントをフックして、カメラ コントローラーの状態の基本的なフィールドをすべて初期化しましょう。

**Initialize**

```cpp
void CameraPanController::Initialize( _In_ CoreWindow^ window )
{

    // Start recieving touch/mouse events.
    window->PointerPressed += 
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &CameraPanController::OnPointerPressed);

    window->PointerMoved += 
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &CameraPanController::OnPointerMoved);

    window->PointerReleased += 
    ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &CameraPanController::OnPointerReleased);


    // Initialize the state of the controller.
    m_panInUse = FALSE;             
    m_panPointerID = 0;

    //  Initialize this as it is reset on every frame.
    m_panCommand = DirectX::XMFLOAT3( 0.0f, 0.0f, 0.0f );

}
```

**Initialize** は、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) インスタンスへの参照をパラメーターとして使い、先ほど作成したイベント ハンドラーをその **CoreWindow** の適切なイベントに登録します。

## <a name="getting-and-setting-the-position-of-the-camera-controller"></a>カメラ コントローラーの位置の取得と設定


シーン空間内のカメラ コントローラーの位置の取得と設定を行うメソッドをいくつか定義してみましょう。

```cpp
void CameraPanController::SetPosition( _In_ DirectX::XMFLOAT3 pos )
{
    m_position = pos;
}

// Returns the position of the controller object
DirectX::XMFLOAT3 CameraPanController::get_Position()
{
    return m_position;
}

DirectX::XMFLOAT3 CameraPanController::get_FixedLookPoint()
{
    // For this sample, we don't need to use the trig functions because our
    // look point is fixed. 
    DirectX::XMFLOAT3 result= m_position;
    result.z += 1.0f;
    return result;    

}
```

**SetPosition** は、カメラ コントローラーの位置を特定の点に設定する必要がある場合に、アプリから呼び出すことができるパブリック メソッドです。

**get\_Position** は、最も重要なパブリック プロパティです。アプリはこのプロパティを使って、シーン空間内のカメラ コントローラーの現在の位置を取得し、その位置に応じてビューポートを更新できます。

**get\_FixedLookPoint** は、この例では、x-y 平面に垂直な視点を取得するパブリック プロパティです。 固定カメラに対して斜めの角度を作る場合は、このメソッドを変更して、x、y、z 座標値の計算時に三角関数 sin と cos を使うことができます。

## <a name="updating-the-camera-controller-state-information"></a>カメラ コントローラーの状態情報の更新


次は、**m\_panPointerPosition** で追跡したポインターの座標情報を、3D シーン空間における新しい座標情報に変換する計算を実行します。 Windows ストア アプリは、アプリのメイン ループが更新されるたびに、このメソッドを呼び出します。 ここで、ビューポートへのプロジェクションの前にビュー マトリックスを更新するためにアプリに渡す新しい位置情報を計算します。

```cpp

void CameraPanController::Update( CoreWindow ^window )
{
    if ( m_panInUse )
    {
        pointerDelta.x = m_panPointerPosition.x - m_panFirstDown.x;
        pointerDelta.y = m_panPointerPosition.y - m_panFirstDown.y;

        if ( pointerDelta.x > 16.0f )        // Leave 32 pixel-wide dead spot for being still.
            m_panCommand.x += 1.0f;
        else
            if ( pointerDelta.x < -16.0f )
                m_panCommand.x += -1.0f;

        if ( pointerDelta.y > 16.0f )        
            m_panCommand.y += 1.0f;
        else
            if (pointerDelta.y < -16.0f )
                m_panCommand.y += -1.0f;
    }

       DirectX::XMFLOAT3 command = m_panCommand;
   
    // Our velocity is based on the command.
    DirectX::XMFLOAT3 Velocity;
    Velocity.x =  command.x;
    Velocity.y =  command.y;
    Velocity.z =  0.0f;

    // Integrate
    m_position.x = m_position.x + Velocity.x;
    m_position.y = m_position.y + Velocity.y;
    m_position.z = m_position.z + Velocity.z;

    // Clear the movement input accumulator for use during the next frame.
    m_panCommand = DirectX::XMFLOAT3( 0.0f, 0.0f, 0.0f );

}
```

タッチまたはマウスの揺れでカメラのパンが不適切に動かないように、ポインターの周りに直径 32 ピクセルのデッド ゾーンを設定します。 また、速度値もあります。この例では、デッド ゾーンを超えるポインターのピクセル トラバーサルに対して 1:1 です。 この動作を調整し、移動速度を低下または上昇させることができます。

## <a name="updating-the-view-matrix-with-the-new-camera-position"></a>カメラの新しい位置によるビュー マトリックスの更新


これで、カメラのフォーカスが合っているシーン空間の座標の取得ができます。この座標は、アプリに指定した時間ごとに更新されます (たとえばアプリのメイン ループでは 60 秒ごと)。 次の疑似コードは、実装できる呼び出し動作を示しています。

```cpp
 myCameraPanController->Update( m_window ); 

 // Update the view matrix based on the camera position.
 myCamera->MyMethodToComputeViewMatrix(
        myController->get_Position(),        // The position in the 3D scene space.
        myController->get_FixedLookPoint(),      // The point in the space we are looking at.
        DirectX::XMFLOAT3( 0, 1, 0 )                    // The axis that is "up" in our space.
        );  
```

これで、 一連の簡単なカメラ パンのタッチ コントロールがゲームに実装されました。


 

 

 




