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
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5748272"
---
# <a name="touch-controls-for-games"></a><span data-ttu-id="ee5bf-104">ゲームのタッチ コントロール</span><span class="sxs-lookup"><span data-stu-id="ee5bf-104">Touch controls for games</span></span>



<span data-ttu-id="ee5bf-105">ここでは、DirectX を使うユニバーサル Windows プラットフォーム (UWP) C++ ゲームに、基本的なタッチ コントロールを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-105">Learn how to add basic touch controls to your Universal Windows Platform (UWP) C++ game with DirectX.</span></span> <span data-ttu-id="ee5bf-106">具体的には、平面に固定されたカメラを動かすタッチ ベースのコントロールを、指またはスタイラスでドラッグするとカメラの視点がシフトする Direct3D 環境に追加する方法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-106">We show you how to add touch-based controls to move a fixed-plane camera in a Direct3D environment, where dragging with a finger or stylus shifts the camera perspective.</span></span>

<span data-ttu-id="ee5bf-107">これらのコントロールは、プレイヤーが地図やプレイフィールドなどの 3D 環境でドラッグしてスクロールまたはパンを行うゲームに組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-107">You can incorporate these controls in games where you want the player to drag to scroll or pan over a 3D environment, such as a map or playfield.</span></span> <span data-ttu-id="ee5bf-108">たとえば、戦略ゲームやパズル ゲームでは、これらのコントロールを使って、プレイヤーが左右にパンすることで画面より大きいゲーム環境を確認できるようにすることが可能です。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-108">For example, in a strategy or puzzle game, you can use these controls to let the player view a game environment that is larger than the screen by panning left or right.</span></span>

> <span data-ttu-id="ee5bf-109">**注:** コードは、マウス ベースのパン コントロールでも動作します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-109">**Note**Our code also works with mouse-based panning controls.</span></span> <span data-ttu-id="ee5bf-110">ポインター関連のイベントは、Windows ランタイム API で抽象化されるため、タッチまたはマウス ベースのポインター イベントを処理できます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-110">The pointer related events are abstracted by the Windows Runtime APIs, so they can handle either touch- or mouse-based pointer events.</span></span>

 

## <a name="objectives"></a><span data-ttu-id="ee5bf-111">目標</span><span class="sxs-lookup"><span data-stu-id="ee5bf-111">Objectives</span></span>


-   <span data-ttu-id="ee5bf-112">DirectX ゲームで平面に固定されたカメラをパンする簡単なタッチ ドラッグ コントロールを作成する。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-112">Create a simple touch drag control for panning a fixed-plane camera in a DirectX game.</span></span>

## <a name="set-up-the-basic-touch-event-infrastructure"></a><span data-ttu-id="ee5bf-113">基本的なタッチ イベントのインフラストラクチャのセットアップ</span><span class="sxs-lookup"><span data-stu-id="ee5bf-113">Set up the basic touch event infrastructure</span></span>


<span data-ttu-id="ee5bf-114">まず、この例ではコントローラーの基本型として、**CameraPanController** を定義します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-114">First, we define our basic controller type, the **CameraPanController**, in this case.</span></span> <span data-ttu-id="ee5bf-115">ここでは、コントローラーを抽象的な概念、つまりユーザーが実行できる動作のセットとして定義します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-115">Here, we define a controller as an abstract idea, the set of behaviors the user can perform.</span></span>

<span data-ttu-id="ee5bf-116">**CameraPanController** クラスは、カメラ コントローラーの状態に関する情報を定期的に更新したコレクションであり、アプリが自身の更新ループからこの情報を取得できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-116">The **CameraPanController** class is a regularly refreshed collection of information about the camera controller state, and provides a way for our app to obtain that information from its update loop.</span></span>

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

<span data-ttu-id="ee5bf-117">次に、カメラ コントローラーの状態を定義するヘッダーと、カメラ コントローラーの操作を実装する基本的なメソッドとイベント ハンドラーを作ります。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-117">Now, let's create a header that defines the state of the camera controller, and the basic methods and event handlers that implement the camera controller interactions.</span></span>

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

<span data-ttu-id="ee5bf-118">プライベート フィールドには、カメラ コントローラーの現在の状態が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-118">The private fields contain the current state of the camera controller.</span></span> <span data-ttu-id="ee5bf-119">ここでその内容を確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-119">Let's review them.</span></span>

-   <span data-ttu-id="ee5bf-120">**m\_position** は、シーン空間内のカメラの位置です。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-120">**m\_position** is the position of the camera in the scene space.</span></span> <span data-ttu-id="ee5bf-121">この例では、z 座標値は 0 に固定されています。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-121">In this example, the z-coordinate value is fixed at 0.</span></span> <span data-ttu-id="ee5bf-122">DirectX::XMFLOAT2 を使ってこの値を表すこともできますが、このサンプルの目的と今後の拡張性を考慮して、ここでは DirectX::XMFLOAT3 を使います。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-122">We could use a DirectX::XMFLOAT2 to represent this value, but for the purposes of this sample and future extensibility, we use a DirectX::XMFLOAT3.</span></span> <span data-ttu-id="ee5bf-123">この値は、**get\_Position** プロパティを通じてアプリ自体に渡し、それに従ってアプリがビューポートを更新できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-123">We pass this value through the **get\_Position** property to the app itself so it can update the viewport accordingly.</span></span>
-   <span data-ttu-id="ee5bf-124">**m\_panInUse** は、パン操作がアクティブかどうかを示すブール値です。より具体的には、プレイヤーが画面をタッチしてカメラを動かしているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-124">**m\_panInUse** is a Boolean value that indicates whether a pan operation is active; or, more specifically, whether the player is touching the screen and moving the camera.</span></span>
-   <span data-ttu-id="ee5bf-125">**m\_panPointerID** は、ポインターの一意の ID です。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-125">**m\_panPointerID** is a unique ID for the pointer.</span></span> <span data-ttu-id="ee5bf-126">これはこのサンプルでは使いませんが、コントローラーの状態クラスと特定のポインターを関連付けることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-126">We won't use this in the sample, but it's a good practice to associate your controller state class with a specific pointer.</span></span>
-   <span data-ttu-id="ee5bf-127">**m\_panFirstDown** は、カメラのパン操作中にプレイヤーが最初に画面をタッチまたはマウスをクリックした画面上の点です。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-127">**m\_panFirstDown** is the point on the screen where the player first touched the screen or clicked the mouse during the camera pan action.</span></span> <span data-ttu-id="ee5bf-128">この値は、画面がタッチされているときや、マウスが少し揺れている場合に、ビューが不安定にならないようデッド ゾーンを設定するために後で使います。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-128">We use this value later to set a dead zone to prevent jitter when the screen is touched, or if the mouse shakes a little.</span></span>
-   <span data-ttu-id="ee5bf-129">**m\_panPointerPosition** は、プレイヤーがポインターを現在動かしたばかりの画面上の点です。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-129">**m\_panPointerPosition** is the point on the screen where the player has currently moved the pointer.</span></span> <span data-ttu-id="ee5bf-130">これは、**m\_panFirstDown** と比較して確認することで、プレイヤーが移動したい方向を判断するために使います。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-130">We use it to determine what direction the player wanted to move by examining it relative to **m\_panFirstDown**.</span></span>
-   <span data-ttu-id="ee5bf-131">**m\_panCommand** は、カメラ コントローラーに対して計算された最終的なコマンドであり、up、down、left、または right です。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-131">**m\_panCommand** is the final computed command for the camera controller: up, down, left, or right.</span></span> <span data-ttu-id="ee5bf-132">x-y 平面に固定されたカメラを操作しているため、これは、DirectX::XMFLOAT2 にすることも可能です。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-132">Because we are working with a camera fixed to the x-y plane, this could be a DirectX::XMFLOAT2 value instead.</span></span>

<span data-ttu-id="ee5bf-133">次の 3 つのイベント ハンドラーを使って、カメラ コントローラーの状態情報を更新します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-133">We use these 3 event handlers to update the camera controller state info.</span></span>

-   <span data-ttu-id="ee5bf-134">**OnPointerPressed** は、プレイヤーが指でタッチ画面を押し、その押された座標にポインターが動いたときに、アプリが呼び出すイベント ハンドラーです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-134">**OnPointerPressed** is an event handler that our app calls when the players presses a finger onto the touch surface and the pointer is moved to the coordinates of the press.</span></span>
-   <span data-ttu-id="ee5bf-135">**OnPointerMoved** は、プレイヤーが指でタッチ画面をスワイプしたときに、アプリが呼び出すイベント ハンドラーです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-135">**OnPointerMoved** is an event handler that our app calls when the player swipes a finger across the touch surface.</span></span> <span data-ttu-id="ee5bf-136">これは、ドラッグ パスの新しい座標で更新されます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-136">It updates with the new coordinates of the drag path.</span></span>
-   <span data-ttu-id="ee5bf-137">**OnPointerReleased** は、プレイヤーが指をタッチ画面から離したときに、アプリが呼び出すイベント ハンドラーです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-137">**OnPointerReleased** is an event handler that our app calls when the player removes the pressing finger from the touch surface.</span></span>

<span data-ttu-id="ee5bf-138">最後に、次のメソッドとプロパティを使って、カメラ コントローラーの状態情報の初期化、アクセス、更新を行います。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-138">Finally, we use these methods and properties to initialize, access, and update the camera controller state information.</span></span>

-   <span data-ttu-id="ee5bf-139">**Initialize** は、アプリがコントロールを初期化して、表示ウィンドウを定義する [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトにそれらのコントロールを適用するときに呼び出すイベント ハンドラーです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-139">**Initialize** is an event handler that our app calls to initialize the controls and attach them to the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) object that describes your display window.</span></span>
-   <span data-ttu-id="ee5bf-140">**SetPosition** は、アプリがシーン空間内のコントロールの (x、y、z) 座標を設定するときに呼び出すメソッドです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-140">**SetPosition** is a method that our app calls to set the (x, y, and z) coordinates of your controls in the scene space.</span></span> <span data-ttu-id="ee5bf-141">z 座標はこのチュートリアル全体で 0 であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-141">Note that our z-coordinate is 0 throughout this tutorial.</span></span>
-   <span data-ttu-id="ee5bf-142">**get\_Position** は、アプリがシーン空間内のカメラの現在の位置を取得するときにアクセスするプロパティです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-142">**get\_Position** is a property that our app accesses to get the current position of the camera in the scene space.</span></span> <span data-ttu-id="ee5bf-143">このプロパティは、カメラの現在の位置をアプリに伝える手段として使います。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-143">You use this property as the way of communicating the current camera position to the app.</span></span>
-   <span data-ttu-id="ee5bf-144">**get\_FixedLookPoint** は、アプリが現在コントローラーのカメラが向いている点を取得するときにアクセスするプロパティです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-144">**get\_FixedLookPoint** is a property that our app accesses to get the current point toward which the controller camera is facing.</span></span> <span data-ttu-id="ee5bf-145">この例では、x-y 平面に垂直にロックされています。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-145">In this example, it is locked normal to the x-y plane.</span></span>
-   <span data-ttu-id="ee5bf-146">**Update** は、コントローラーの状態を読み取り、カメラの位置を更新するメソッドです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-146">**Update** is a method that reads the controller state and updates the camera position.</span></span> <span data-ttu-id="ee5bf-147">このメソッドをアプリのメイン ループから継続的に呼び出して、カメラ コントローラーのデータとシーン空間内のカメラの位置を更新します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-147">You continually call this &lt;something&gt; from the app's main loop to refresh the camera controller data and the camera position in the scene space.</span></span>

<span data-ttu-id="ee5bf-148">これで、タッチ コントロールの実装に必要なコンポーネントがすべて揃いました。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-148">Now, you have here all the components you need to implement touch controls.</span></span> <span data-ttu-id="ee5bf-149">タッチ ポインターまたはマウス ポインターのイベントがいつどこで発生し、その操作が何かを検出できます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-149">You can detect when and where the touch or mouse pointer events have occurred, and what the action is.</span></span> <span data-ttu-id="ee5bf-150">また、カメラの位置と向きをシーン空間と相対的に設定し、変化を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-150">You can set the position and orientation of the camera relative to the scene space, and track the changes.</span></span> <span data-ttu-id="ee5bf-151">さらに、カメラの新しい位置を呼び出し元アプリに伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-151">Finally, you can communicate the new camera position to the calling app.</span></span>

<span data-ttu-id="ee5bf-152">次は、これらのコンポーネントどうしを接続してみましょう。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-152">Now, let's connect these pieces together.</span></span>

## <a name="create-the-basic-touch-events"></a><span data-ttu-id="ee5bf-153">基本的なタッチ イベントの作成</span><span class="sxs-lookup"><span data-stu-id="ee5bf-153">Create the basic touch events</span></span>


<span data-ttu-id="ee5bf-154">Windows ランタイムのイベント ディスパッチャーは、アプリで処理するイベントを 3 つ提供します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-154">The Windows Runtime event dispatcher provides 3 events we want our app to handle:</span></span>

-   [**<span data-ttu-id="ee5bf-155">PointerPressed</span><span class="sxs-lookup"><span data-stu-id="ee5bf-155">PointerPressed</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208278)
-   [**<span data-ttu-id="ee5bf-156">PointerMoved</span><span class="sxs-lookup"><span data-stu-id="ee5bf-156">PointerMoved</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208276)
-   [**<span data-ttu-id="ee5bf-157">PointerReleased</span><span class="sxs-lookup"><span data-stu-id="ee5bf-157">PointerReleased</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208279)

<span data-ttu-id="ee5bf-158">これらのイベントは、[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) 型に実装されています。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-158">These events are implemented on the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) type.</span></span> <span data-ttu-id="ee5bf-159">ここでは、操作する **CoreWindow** オブジェクトが既にあると想定しています。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-159">We assume that you have a **CoreWindow** object to work with.</span></span> <span data-ttu-id="ee5bf-160">詳しくは、「[UWP C++ アプリで DirectX ビューを表示するための設定方法](https://msdn.microsoft.com/library/windows/apps/hh465077)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-160">For more info, see [How to set up your UWP C++ app to display a DirectX view](https://msdn.microsoft.com/library/windows/apps/hh465077).</span></span>

<span data-ttu-id="ee5bf-161">これらのイベントは Windows ストア アプリの実行中に起動するため、ハンドラーはプライベート フィールドに定義されているカメラ コントローラーの状態情報を更新します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-161">As these events fire while our app is running, the handlers update the camera controller state info defined in our private fields.</span></span>

<span data-ttu-id="ee5bf-162">まず、タッチ ポインターのイベント ハンドラーを設定します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-162">First, let's populate the touch pointer event handlers.</span></span> <span data-ttu-id="ee5bf-163">最初のイベント ハンドラーである **OnPointerPressed** では、ユーザーが画面をタッチまたはマウスをクリックしたときに表示を管理する [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) からポインターの x-y 座標を取得します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-163">In the first event handler, **OnPointerPressed**, we get the x-y coordinates of the pointer from the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) that manages our display when the user touches the screen or clicks the mouse.</span></span>

**<span data-ttu-id="ee5bf-164">OnPointerPressed</span><span class="sxs-lookup"><span data-stu-id="ee5bf-164">OnPointerPressed</span></span>**

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

<span data-ttu-id="ee5bf-165">このハンドラーを使って、現在の **CameraPanController** インスタンスに、**m\_panInUse** を TRUE に設定してカメラ コントローラーをアクティブとして扱う必要があることを伝えます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-165">We use this handler to let the current **CameraPanController** instance know that camera controller should be treated as active by setting **m\_panInUse** to TRUE.</span></span> <span data-ttu-id="ee5bf-166">この方法により、アプリは **Update** を呼び出すときに、現在の位置データを使ってビューポートを更新します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-166">That way, when the app calls **Update** , it will use the current position data to update the viewport.</span></span>

<span data-ttu-id="ee5bf-167">以上で、ユーザーが画面をタッチまたは表示ウィンドウをクリックしたときのカメラの動きを示す基本の値が設定されたので、次は、ユーザーが画面を押してドラッグまたはボタンを押してマウスを動かしたときに何をするかを決める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-167">Now that we've established the base values for the camera movement when the user touches the screen or click-presses in the display window, we must determine what to do when the user either drags the screen press or moves the mouse with button pressed.</span></span>

<span data-ttu-id="ee5bf-168">**OnPointerMoved** イベント ハンドラーは、ポインターが動くたびに、プレイヤーがポインターを画面上でドラッグするティックごとに起動します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-168">The **OnPointerMoved** event handler fires whenever the pointer moves, at every tick that the player drags it on the screen.</span></span> <span data-ttu-id="ee5bf-169">アプリにポインターの現在の位置を知らせ続ける必要があるため、次のように指定します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-169">We need to keep the app aware of the current location of the pointer, and this is how we do it.</span></span>

**<span data-ttu-id="ee5bf-170">OnPointerMoved</span><span class="sxs-lookup"><span data-stu-id="ee5bf-170">OnPointerMoved</span></span>**

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

<span data-ttu-id="ee5bf-171">最後に、プレイヤーが画面から手を離したときに、カメラのパン動作を非アクティブにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-171">Finally, we need to deactivate the camera pan behavior when the player stops touching the screen.</span></span> <span data-ttu-id="ee5bf-172">**m\_panInUse** を FALSE に設定してカメラのパン移動をオフにし、ポインター ID を 0 に設定するには、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) の起動時に呼び出される **OnPointerReleased** を使います。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-172">We use **OnPointerReleased**, which is called when [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208279) is fired, to set **m\_panInUse** to FALSE and turn off the camera pan movement, and set the pointer ID to 0.</span></span>

**<span data-ttu-id="ee5bf-173">OnPointerReleased</span><span class="sxs-lookup"><span data-stu-id="ee5bf-173">OnPointerReleased</span></span>**

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

## <a name="initialize-the-touch-controls-and-the-controller-state"></a><span data-ttu-id="ee5bf-174">タッチ コントロールとコントローラーの状態の初期化</span><span class="sxs-lookup"><span data-stu-id="ee5bf-174">Initialize the touch controls and the controller state</span></span>


<span data-ttu-id="ee5bf-175">次は、イベントをフックして、カメラ コントローラーの状態の基本的なフィールドをすべて初期化しましょう。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-175">Let's hook the events and initialize all the basic state fields of the camera controller.</span></span>

**<span data-ttu-id="ee5bf-176">Initialize</span><span class="sxs-lookup"><span data-stu-id="ee5bf-176">Initialize</span></span>**

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

<span data-ttu-id="ee5bf-177">**Initialize** は、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) インスタンスへの参照をパラメーターとして使い、先ほど作成したイベント ハンドラーをその **CoreWindow** の適切なイベントに登録します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-177">**Initialize** takes a reference to the app's [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) instance as a parameter and registers the event handlers we developed to the appropriate events on that **CoreWindow**.</span></span>

## <a name="getting-and-setting-the-position-of-the-camera-controller"></a><span data-ttu-id="ee5bf-178">カメラ コントローラーの位置の取得と設定</span><span class="sxs-lookup"><span data-stu-id="ee5bf-178">Getting and setting the position of the camera controller</span></span>


<span data-ttu-id="ee5bf-179">シーン空間内のカメラ コントローラーの位置の取得と設定を行うメソッドをいくつか定義してみましょう。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-179">Let's define some methods to get and set the position of the camera controller in the scene space.</span></span>

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

<span data-ttu-id="ee5bf-180">**SetPosition** は、カメラ コントローラーの位置を特定の点に設定する必要がある場合に、アプリから呼び出すことができるパブリック メソッドです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-180">**SetPosition** is a public method that we can call from our app if we need to set the camera controller position to a specific point.</span></span>

<span data-ttu-id="ee5bf-181">**get\_Position** は、最も重要なパブリック プロパティです。アプリはこのプロパティを使って、シーン空間内のカメラ コントローラーの現在の位置を取得し、その位置に応じてビューポートを更新できます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-181">**get\_Position** is our most important public property: it's the way our app gets the current position of the camera controller in the scene space so it can update the viewport accordingly.</span></span>

<span data-ttu-id="ee5bf-182">**get\_FixedLookPoint** は、この例では、x-y 平面に垂直な視点を取得するパブリック プロパティです。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-182">**get\_FixedLookPoint** is a public property that, in this example, obtains a look point that is normal to the x-y plane.</span></span> <span data-ttu-id="ee5bf-183">固定カメラに対して斜めの角度を作る場合は、このメソッドを変更して、x、y、z 座標値の計算時に三角関数 sin と cos を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-183">You can change this method to use the trigonometric functions, sin and cos, when calculating the x, y, and z coordinate values if you want to create more oblique angles for the fixed camera.</span></span>

## <a name="updating-the-camera-controller-state-information"></a><span data-ttu-id="ee5bf-184">カメラ コントローラーの状態情報の更新</span><span class="sxs-lookup"><span data-stu-id="ee5bf-184">Updating the camera controller state information</span></span>


<span data-ttu-id="ee5bf-185">次は、**m\_panPointerPosition** で追跡したポインターの座標情報を、3D シーン空間における新しい座標情報に変換する計算を実行します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-185">Now, we perform our calculations that convert the pointer coordinate info tracked in **m\_panPointerPosition** into new coordinate info respective of our 3D scene space.</span></span> <span data-ttu-id="ee5bf-186">Windows ストア アプリは、アプリのメイン ループが更新されるたびに、このメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-186">Our app calls this method every time we refresh the main app loop.</span></span> <span data-ttu-id="ee5bf-187">ここで、ビューポートへのプロジェクションの前にビュー マトリックスを更新するためにアプリに渡す新しい位置情報を計算します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-187">In it we compute the new position information we want to pass to the app which is used to update the view matrix before projection into the viewport.</span></span>

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

<span data-ttu-id="ee5bf-188">タッチまたはマウスの揺れでカメラのパンが不適切に動かないように、ポインターの周りに直径 32 ピクセルのデッド ゾーンを設定します。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-188">Because we don't want touch or mouse jitter to make our camera panning jerky, we set a dead zone around the pointer with a diameter of 32 pixels.</span></span> <span data-ttu-id="ee5bf-189">また、速度値もあります。この例では、デッド ゾーンを超えるポインターのピクセル トラバーサルに対して 1:1 です。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-189">We also have a velocity value, which in this case is 1:1 with the pixel traversal of the pointer past the dead zone.</span></span> <span data-ttu-id="ee5bf-190">この動作を調整し、移動速度を低下または上昇させることができます。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-190">You can adjust this behavior to slow down or speed up the rate of movement.</span></span>

## <a name="updating-the-view-matrix-with-the-new-camera-position"></a><span data-ttu-id="ee5bf-191">カメラの新しい位置によるビュー マトリックスの更新</span><span class="sxs-lookup"><span data-stu-id="ee5bf-191">Updating the view matrix with the new camera position</span></span>


<span data-ttu-id="ee5bf-192">これで、カメラのフォーカスが合っているシーン空間の座標の取得ができます。この座標は、アプリに指定した時間ごとに更新されます (たとえばアプリのメイン ループでは 60 秒ごと)。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-192">We can now obtain a scene space coordinate that our camera is focused on, and which is updated whenever you tell your app to do so (every 60 seconds in the main app loop, for example).</span></span> <span data-ttu-id="ee5bf-193">次の疑似コードは、実装できる呼び出し動作を示しています。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-193">This pseudocode suggests the calling behavior you can implement:</span></span>

```cpp
 myCameraPanController->Update( m_window ); 

 // Update the view matrix based on the camera position.
 myCamera->MyMethodToComputeViewMatrix(
        myController->get_Position(),        // The position in the 3D scene space.
        myController->get_FixedLookPoint(),      // The point in the space we are looking at.
        DirectX::XMFLOAT3( 0, 1, 0 )                    // The axis that is "up" in our space.
        );  
```

<span data-ttu-id="ee5bf-194">これで、</span><span class="sxs-lookup"><span data-stu-id="ee5bf-194">Congratulations!</span></span> <span data-ttu-id="ee5bf-195">一連の簡単なカメラ パンのタッチ コントロールがゲームに実装されました。</span><span class="sxs-lookup"><span data-stu-id="ee5bf-195">You've implemented a simple set of camera panning touch controls in your game.</span></span>


 

 

 




