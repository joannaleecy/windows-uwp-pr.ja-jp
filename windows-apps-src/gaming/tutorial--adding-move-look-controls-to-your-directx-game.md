---
xxxxx: Xxxx-xxxx xxxxxxxx xxx xxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxxxxxxxxxx xxxxx xxx xxxxxxxx xxxx-xxxx xxxxxxxx (xxxx xxxxx xx xxxxxxxxx xxxxxxxx) xx xxxx XxxxxxX xxxx.
xx.xxxxxxx: YxYxYYYx-YxxY-YxYY-xxYY-YYYYxYYxxYYY
---

# <span id="dev_gaming.tutorial__adding_move-look_controls_to_your_directx_game">
            </span>Xxxx-xxxx xxxxxxxx xxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxx xx xxx xxxxxxxxxxx xxxxx xxx xxxxxxxx xxxx-xxxx xxxxxxxx (xxxx xxxxx xx xxxxxxxxx xxxxxxxx) xx xxxx XxxxxxX xxxx.

Xx xxxx xxxxxxx xxxx-xxxx xxxxxxx xxx xxxxx xxxxxxx, xxxx xxx xxxx xxxxxxxxxx xxxxxxx xx xxx xxxxx-xxxx xxxxxxx xx xxx xxxxxx xxxx xxxxxxx xxxx x xxxxxxxxxxx xxxxx, xxx xxx xxxx xxxxxxxxxx xxxxxxx xxx xxx xxxxxxxxx xx xxx xxxxxx, xxxx xxx xxxxxx xxxxxxxxx xx xxx xxxx xxxxx xxx xxxxxx xxxxxxx xx xxxx xxxx.

Xx xxxx xx xx xxxxxxxxxx xxxxxxx xxxxxxx xx xxx, xxxxx xx xx xxxx xxx: xxx xxxxxxxx (xx xxx xxxxx-xxxxx xxxxxxxxxxx xxxxx xxx) xxxxxxxx xxxx xxxx xx xxxx YX xxxxx, xxx xxxxxxx xx xx xxxx xxxx xxxx xxxx xxxxxxx xx xxxxxx xxxxxxx xx xxxxxxxx, xx xxxxxxxx xxxx xxx xxxxx. Xxx xxxxx (xx xxxxx xxxxxxx) xxxxxxxx xxxx xxxx. Xxx xxx xxxx xxxx xx xxxx xx x xxxxxxxxx -- xxxx xx xxxxx, xx xx xxxx, xx xxxxxxxxx xx xxxx xxxxx. Xx xxxxx xx x xxxxxx xx xxxx xxxx, xxx xxxxx xxx xxx xxxxx xx xxxxxx xxxx xxxxxx xxxx xx xxxx xxxxxx, xxx xxxx xxxxx xxx xxxxxxx xxx xx xxxx xxxxxxx xx, xx xxxx xx xxxx xxxx xxxx xx. Xx xxxxxx xxx xxxxxx, xxx xxxxx xxxx xxx xxxxxx xxxx xxxxxxxx xx xxx xxxxxx, xxx xxxx xxxx xx xxxxx xx xxx xxxx xxxx. Xxx xxx xxx xxx xxxx xx x xxxx xxxxxxxxx xxxxxxx xxxxxx xxx xxxxxxxxxx YX xxxxxxxxxxxx!

Xxxxx xxxxxxxx xxx xxxxxxxx xxxxx xx XXXX xxxxxxxx xx xxxxxx, xxxxx xxx X, X, X, xxx X xxxx xxx xxxx xxx x-x xxxxx xxxxx xxxxxx xxxxxxxx, xxx xxx xxxxx xx xxxx xx xxxxxxx xxxxxx xxxxxxxx xxxxxx xxx x xxx x xxxx.

## Xxxxxxxxxx


-   Xxx xxxxx xxxx-xxxx xxxxxxxx xx xxxx XxxxxxX xxxx xxx xxxx xxxxx xxx xxxxxxxx, xxx xxxxx xxxxxxx.
-   Xxxxxxxxx x xxxxx-xxxxxx xxxxxx xxxx xx xxxxxxxx x YX xxxxxxxxxxx.

## X xxxx xx xxxxx xxxxxxx xxxxxxxxxxxxxxx


Xxx xxxxx xxxxxxxx, xx xxxxxxxxx xxx xxxxxxxxxxx: xxx xxxx xxxxxxxxxx, xxxxx xxxxxxx xxxxxxxx xx xxx x-x xxxxx xxxxxxxx xx xxx xxxxxx'x xxxx xxxxx; xxx xxx xxxx xxxxxxxxxx, xxxxx xxxx xxx xxxxxx'x xxxx xxxxx. Xxx xxxx xxxxxxxxxx xxxx xx xxx xxxxxxxx XXXX xxxxxxx, xxx xxx xxxx xxxxxxxxxx xxxx xx xxx xxxxx. Xxx xxx xxxxx xxxxxxxx, xx xxxx xx xxxxxx x xxxxxx xx xxx xxxxxx xxxx xxxxxx xx xxx xxxxxxxxxxx xxxxxx, xx xxx xxxxxxx XXXX xxxxxxx, xxxx xxx xxxxxxxxx xx xxx xxxxxx xxxxxxx xx xxx xxxxx xxxxx xxx xxx xxxx xxxxxxxx.

Xxx xxxxxx xxxxx xxxx xxxx.

![xxx xxxx-xxxx xxxxxxxxxx xxxxxx](images/movelook-touch.png)

Xxxx xxx xxxx xxx xxxxx xxxxxxx (xxx xxx xxxxx!) xx xxx xxxxx xxxx xx xxx xxxxxx, xxx xxxxxxxx xxxxxxx xxxx xxxx xxx xxxxxx xxxx xxxxxxx. Xxx xxxxxxxx xxxxxxxxx xxxx xxxx xxx xxxxxx xxxx xxxxxxxxx. Xxx xxxx xxxxx xxx xxxx xxx xxxxx xxxxxxxx xxxxxx xxx xxxx xxxxxxxxxx'x xxxxxxx xxxxx. Xxxxxxx xx xxxx xxxxx, xxx xx xxxxxxx x xxxx xxxxxxxxxx -- xxx xxxx xxxxx xx xxxx xxx xxxxxx xx xxxxx xxx'x xxxx xx xx xxxx.

## Xxx xx xxx xxxxx xxxxx xxxxx xxxxxxxxxxxxxx


Xxxxx, xx xxxx xxxxxx xxx xxxxxxx xxxxx xxxx xx xxx xx xxxxxx xxxxx xxxxxx xxxx xxx xxxxx xxx xxxxxxxx, xxx xxxxxx xxx xxxxxx xxxxxxxxxxx xxxxx xx xxxx xxxxx. Xxxxxxx xx'xx xxxxxxxxxxxx xxxx-xxxx xxxxxxxx, xx xxxx xx **XxxxXxxxXxxxxxxxxx**.

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

Xxx, xxx'x xxxxxx x xxxxxx xxxx xxxxxxx xxx xxxxx xx xxx xxxx-xxxx xxxxxxxxxx xxx xxx xxxxx-xxxxxx xxxxxx, xxxx xxx xxxxx xxxxxxx xxx xxxxx xxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxx xxx xxxx xxxxxx xxx xxxxx xx xxx xxxxxx.

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

Xxx xxxx xxxxxxxx Y xxxxxx xx xxxxxxx xxxxxx. Xxx'x xxxxxx xxx xxxxxxx xx xxxx xxx.

Xxxxx, xx xxxxxx xxxx xxxxxx xxxxxx xxxx xxxx xxx xxxxxxx xxxx xxxxx xxx xxxxxx xxxx.

-   **x\_xxxxxxxx** xx xxx xxxxxxxx xx xxx xxxxxx (xxx xxxxxxxxx xxx xxxxxxxxx) xx xxx YX xxxxx, xxxxx xxxxx xxxxxxxxxxx.
-   **x\_xxxxx** xx xxx xxxxx xx xxx xxxxxx, xx xxx xx-xxxx xxxxxxxx xxxxxx xxx xxxxxxxxx'x x-xxxx, xx xxxxxxx.
-   **x\_xxx** xx xxx xxx xx xxx xxxxxx, xx xxx xxxx-xxxxx xxxxxxxx xxxxxx xxx xxxxxxxxx'x x-xxxx, xx xxxxxxx.

Xxx, xxx'x xxxxxx xxx xxxxxx xxxx xx xxx xx xxxxx xxxx xxxxx xxx xxxxxx xxx xxxxxxxx xx xxx xxxxxxxxxxx. Xxxxx, xx'xx xxxxxx xxx xxxxxx xx xxxx xxx xxx xxxxx-xxxxx xxxx xxxxxxxxxx. (Xxxxx'x xxxxxxx xxxxxxx xxxxxx xxx xxx xxxxxxxx xxxxxxxxxxxxxx xx xxx xxxx xxxxxxxxxx. Xx xxxx xxxx xxxxxxxx xxxxxx xxxx xxxxxxxx xxxxxxxx.)

-   **x\_xxxxXxXxx** xxxxxxxxx xxxxxxx xxx xxxx xxxxxxxxxx xx xx xxx.
-   **x\_xxxxXxxxxxxXX** xx xxx xxxxxx XX xxx xxx xxxxxxx xxxx xxxxxxx. Xx xxx xx xx xxxxxxxxxxxxx xxxxxxx xxx xxxx xxxxxxx xxx xxx xxxx xxxxxxx xxxx xx xxxxx xxx xxxxxxx XX xxxxx.
-   **x\_xxxxXxxxxXxxx** xx xxx xxxxx xx xxx xxxxxx xxxxx xxx xxxxxx xxxxx xxxxxxx xxx xxxx xxxxxxxxxx xxxxxxx xxxx. Xx xxx xxxx xxxxx xxxxx xx xxx x xxxx xxxx xx xxxx xxxx xxxxxxxxx xxxx xxxxxxxxx xxx xxxx.
-   **x\_xxxxXxxxxxxXxxxxxxx** xx xxx xxxxx xx xxx xxxxxx xxx xxxxxx xxx xxxxxxxxx xxxxx xxx xxxxxxx xx. Xx xxx xx xx xxxxxxxxx xxxx xxxxxxxxx xxx xxxxxx xxxxxx xx xxxx xx xxxxxxxxx xx xxxxxxxx xx **x\_xxxxXxxxxXxxx**.
-   **x\_xxxxXxxxxxx** xx xxx xxxxx xxxxxxxx xxxxxxx xxx xxx xxxx xxxxxxxxxx: xx (xxxxxxx), xxxx (xxxx), xxxx, xx xxxxx.

Xxx, xx xxxxxx xxx xxxxxx xx xxx xxx xxx xxxx xxxxxxxxxx, xxxx xxx xxxxx xxx xxxxx xxxxxxxxxxxxxxx.

-   **x\_xxxxXxXxx** xxxxxxxxx xxxxxxx xxx xxxx xxxxxxx xx xx xxx.
-   **x\_xxxxXxxxxxxXX** xx xxx xxxxxx XX xxx xxx xxxxxxx xxxx xxxxxxx. Xx xxx xx xx xxxxxxxxxxxxx xxxxxxx xxx xxxx xxxxxxx xxx xxx xxxx xxxxxxx xxxx xx xxxxx xxx xxxxxxx XX xxxxx.
-   **x\_xxxxXxxxXxxxx** xx xxx xxxx xxxxx, xx xxxxx xxxxxxxxxxx, xxxx xxx xxxxxxxx xx xxx xxxxxxxx xxxxx.
-   **x\_xxxxXxxxXxxxx** xx xxx xxxxxxxx xxxxxxxxxx xxxxxxx xxx xxxxxxx **x\_xxxxxxxx** xxx **x\_xxxxXxxxXxxxx**.

Xxxxxxx, xx xxxxxx Y Xxxxxxx xxxxxx xxx xxx Y xxxxxxx xx xxxxxxxx, xxxxx xx xxx xx xxxxxxxx xxx xxxxxxx xxxxx xx xxxx xxxxxxxxxxx xxxx xxxxxx (xx xx xxx):

-   **x\_xxxxxxx**, **x\_xxxx**, **x\_xxxx**, **x\_xxxxx**, **x\_xx** xxx **x\_xxxx**.

Xx xxx xxx Y xxxxx xxxxxxxx xx xxxxxxx xxx xxxxx xxxx xx xxx xx xxxxxx xxx xxxxx xx xxx xxxxxxxxxxx:

-   **XxXxxxxxxXxxxxxx**. Xxx xxxxxx xxxxxxx xxx xxxx xxxxx xxxxxx xxxx xxx xxxxxxx xx xxx xxxx xxxxxx, xx xxxxxxx xxx xxxxxx.
-   **XxXxxxxxxXxxxx**. Xxx xxxxxx xxxxx xxx xxxxx xxxx xxx xxxxxxx xx xxx xxxx xxxxxx, xx xxxxxxx xxx xxxxx xxxxxxx xx xxx xxxxxx.
-   **XxXxxxxxxXxxxxxxx**. Xxx xxxxxx xxxxxxxx xxx xxxx xxxxx xxxxxx xxxx xxx xxxxxxx xx xxx xxxx xxxxxx, xx xxxxxxx xxxxxxxx xxx xxxxxx.
-   **XxXxxXxxx**. Xxx xxxxxx xxxxxxx x xxx.
-   **XxXxxXx**. Xxx xxxxxx xxxxxxxx x xxx.

Xxx xxxxxxx, xx xxx xxxxx xxxxxxx xxx xxxxxxxxxx xx xxxxxxxxxx, xxxxxx, xxx xxxxxx xxx xxxxxxxxxxx' xxxxx xxxx.

-   **Xxxxxxxxxx**. Xxx xxx xxxxx xxxx xxxxx xxxxxxx xx xxxxxxxxxx xxx xxxxxxxx xxx xxxxxx xxxx xx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxx.
-   **XxxXxxxxxxx**. Xxx xxx xxxxx xxxx xxxxxx xx xxx xxx (x, x, xxx x) xxxxxxxxxxx xx xxx xxxxxxxx xx xxx xxxxx xxxxx.
-   **XxxXxxxxxxxxxx**. Xxx xxx xxxxx xxxx xxxxxx xx xxx xxx xxxxx xxx xxx xx xxx xxxxxx.
-   **xxx\_Xxxxxxxx**. Xxx xxx xxxxxxxx xxxx xxxxxxxx xx xxx xxx xxxxxxx xxxxxxxx xx xxx xxxxxx xx xxx xxxxx xxxxx. Xxx xxx xxxx xxxxxxxx xx xxx xxxxxx xx xxxxxxxxxxxxx xxx xxxxxxx xxxxxx xxxxxxxx xx xxx xxx.
-   **xxx\_XxxxXxxxx**. Xxx xxx xxxxxxxx xxxx xxxxxxxx xx xxx xxx xxxxxxx xxxxx xxxxxx xxxxx xxx xxxxxxxxxx xxxxxx xx xxxxxx.
-   **Xxxxxx**. Xxxxx xxx xxxxx xx xxx xxxx xxx xxxx xxxxxxxxxxx xxx xxxxxxx xxx xxxxxx xxxxxxxx. Xxx xxxxxxxxxxx xxxx xxxx xxxxxx xxxx xxx xxx'x xxxx xxxx xx xxxxxxx xxx xxxxxx xxxxxxxxxx xxxx xxx xxx xxxxxx xxxxxxxx xx xxx xxxxx xxxxx.

Xxx, xxx xxxx xxxx xxx xxx xxxxxxxxxx xxx xxxx xx xxxxxxxxx xxxx xxxx-xxxx xxxxxxxx. Xx, xxx'x xxxxxxx xxxxx xxxxxx xxxxxxxx.

## Xxxxxx xxx xxxxx xxxxx xxxxxx


Xxx Xxxxxxx Xxxxxxx xxxxx xxxxxxxxxx xxxxxxxx Y xxxxxx xx xxxx xxxxxxxxx xx xxx **XxxxXxxxXxxxxxxxxx** xxxxx xx xxxxxx:

-   [**XxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208278)
-   [**XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br208276)
-   [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208279)
-   [**XxxXx**](https://msdn.microsoft.com/library/windows/apps/br208271)
-   [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br208270)

Xxxxx xxxxxx xxx xxxxxxxxxxx xx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxx. Xx xxxxxx xxxx xxx xxxx x **XxxxXxxxxx** xxxxxx xx xxxx xxxx. Xx xxx xxx'x xxxx xxx xx xxxxxx xxx, xxx [Xxx xx xxx xx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) X++ xxx xx xxxxxxx x XxxxxxX xxxx](https://msdn.microsoft.com/library/windows/apps/hh465077).

Xx xxxxx xxxxxx xxxx xxxxx xxx xxx xx xxxxxxx, xxx xxxxxxxx xxxxxx xxx xxxxxxxxxxx' xxxxx xxxx xxxxxxx xx xxx xxxxxxx xxxxxx.

Xxxxx, xxx'x xxxxxxxx xxx xxxxx xxx xxxxx xxxxxxx xxxxx xxxxxxxx. Xx xxx xxxxx xxxxx xxxxxxx, **XxXxxxxxxXxxxxxx()**, xx xxx xxx x-x xxxxxxxxxxx xx xxx xxxxxxx xxxx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxx xxxxxxx xxx xxxxxxx xxxx xxx xxxx xxxxxx xxx xxxxx xx xxxxxxx xxx xxxxxx xx xxx xxxx xxxxxxxxxx xxxxxx.

**XxXxxxxxxXxxxxxx**

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

Xxxx xxxxx xxxxxxx xxxxxx xxxxxxx xxx xxxxxxx xx xxx xxx xxxxx (xxx xxx xxxxxxxx xx xxxx xxxxxx, xxxxx xxxxxxxx xxxx xxxxx xxx xxxxx) xxx xx xx xx xx xxx xxxx xxxxxxxxxx xxxx. Xx xxxx xxxxxxxx xxx xxxx, xx xxxxxx xxxxxxx xxx xxxxxxx xxx xxxx xxxxxxx, xxxxxxxxxxxx, xxxxxxx xxxx xxxxx xx xxxxxxxxx xx x xxxxxxxx xxxx xx xxxx xxxxx, xx xxxxxxx xx **x\_xxxxXxXxx** xx xxxxx. Xx xx, xxx xxxxxxx xxxxxxxx xxx xxxxx xx xxx xxxx xxxxxxxxxx xxxx xxxxx xxx xxxxx xxxxxxxx xxx xxxx **x\_xxxxXxXxx** xx xxxx, xx xxxx xxxx xxxx xxxxxxx xx xxxxxx xxxxx, xx xxx'x xxxxxxxxx xxx xxxxx xxxxxxxx xx xxx xxxx xxxxxxxxxx xxxxx xxxxxxxxxxx. Xx xxxx xxxxxxx xxx xxxx xxxxxxxxxx xxxxxxx XX xx xxx xxxxxxx xxxxxxx'x XX.

Xx xxx xxxxxxx xx xxx xxxxx xx xx xxx xxxxx xxxxxxx xxx'x xx xxx xxxx xxxxxxxxxx xxxx, xx xxxx xx xx xxx xxxx xxxxxxxxxx xxxx. Xx xxxx **x\_xxxxXxxxXxxxx** xx xxx xxxxxxx xxxxxxxx xxxxx xxx xxxx xxxxxxx xxx xxxxx xxxxxx xx xxxxxxx xxx xxxxxxx, xxxxxx xxx xxxxx, xxx xxxxxxx xxx xxxx xxxxxxxxxx'x xxxxxxx XX xx xxx xxxxxxx xxxxxxx XX. Xx xxxx xxxx xxx xxxxx xx xxx xxxx xxxxxxxxxx xx xxxxxx.

**XxXxxxxxxXxxxx**

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

Xxx **XxXxxxxxxXxxxx** xxxxx xxxxxxx xxxxx xxxxxxxx xxx xxxxxxx xxxxx (xx xxxx xxxx, xx x xxxxx xxxxxx xxxxxxx xx xxxxx xxxxxxx, xx xx xxx xxxxx xxxxxxx xx xxxxx xxxxx xxxxx xxx xxxx xxxxxx xx xxxxxxx). Xx xxx xxxxxxx XX xx xxx xxxx xx xxx xxxx xxxxxxxxxx xxxxxxx'x XX, xxxx xx'x xxx xxxx xxxxxxx; xxxxxxxxx, xx xxxxx xx xx'x xxx xxxx xxxxxxxxxx xxxx'x xxx xxxxxx xxxxxxx.

Xx xx'x xxx xxxx xxxxxxxxxx, xx xxxx xxxxxx xxx xxxxxxx xxxxxxxx. Xx xxxx xxxxxxxx xx xx xxxx xxx [**XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br208276) xxxxx xxxxx xxxxxx, xxxxxxx xx xxxx xx xxxxxxx xxx xxxxx xxxxxxxx xxxx xxx xxxxx xxx xx xxxxxxxx xxxx xxx **XxXxxxxxxXxxxxxx** xxxxx xxxxxxx.

Xx xx'x xxx xxxx xxxxxxxxxx, xxxxxx xxx x xxxxxx xxxx xxxxxxxxxxx. Xx xxxx xx xxxxxxxxx x xxx xxxx xxxxx xxx xxxxxx xxx xxxxxx xx xx, xx xx xxxxxxxxx xxx xxxxx xxxxxxx xxx xxxx xxxx xxxxx xxx xxx xxxxxxx xxxxxx xxxxxxxx, xxx xxxx xx xxxxxxxx xxxxxx xxx xxxxx xxxxxx, xxxxx xx xxx xxxxx xx xxxx xxx xxxx xxxxxxxxx xxxxxxx xx xxxxxx xxxxxxxx xx xxx xxxxxxxx xx xxx xxxxxx xxxxxxxx. Xxxxx xxxx xxxxx, xx xxxxxxxxx xxx xxxxx xxx xxx xxx.

Xxxxxxx, xx xxxx xx xxxxxxxxxx xxx xxxx xx xxxx xxxxxxxxxx xxxxxxxxx xxxx xxx xxxxxx xxxxx xxxxxx xxx xxxxx xx xxxxxxxx xxx xxxxxx. Xx xxx **XxXxxxxxxXxxxxxxx**, xxxxx xx xxxx xxxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208279) xx xxxxx, xx xxx **x\_xxxxXxXxx** xx **x\_xxxxXxXxx** xx XXXXX xxx xxxx xxx xxx xxxxxx xxx xxxxxxxx, xxx xx xxxx xxx xxx xxxxxxx XX.

**XxXxxxxxxXxxxxxxx**

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

Xx xxx, xx xxxxxxx xxx xxx xxxxx xxxxxx xxxxxx. Xxx, xxx'x xxxxxx xxx xxx xxxxx xxxxxx xxx x xxxxxxxx-xxxxx xxxx xxxxxxxxxx.

**XxXxxXxxx**

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

Xx xxxx xx xxx xx xxxxx xxxx xx xxxxxxx, xxxx xxxxx xxxxxxx xxxx xxx xxxxxxxxxxxxx xxxxxxxxxxx xxxx xxxxx xx xxxx.

**XxXxxXx**

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

Xxx xxxx xxx xxx xx xxxxxxxx, xxxx xxxxx xxxxxxx xxxx xx xxxx xx xxxxx. Xxxx xx xxxx **Xxxxxx**, xx xxxxxx xxxxx xxxxxxxxxxx xxxx xxxxxx, xxx xxxx xxx xxxxxx xxxxxxxxxxx. Xxxx xx x xxx xxxxxxx xxxx xxx xxxxx xxxxxxxxxxxxxx!

## Xxxxxxxxxx xxx xxxxx xxxxxxxx xxx xxx xxxxxxxxxx xxxxx


Xxx'x xxxx xx xxx xxxxxx xxx, xxx xxxxxxxxxx xxx xxx xxxxxxxxxx xxxxx xxxxxx.

**Xxxxxxxxxx**

```cpp
void MoveLookController::Initialize( _In_ CoreWindow^ window )
{

    // Opt in to recieve touch/mouse events.
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

**Xxxxxxxxxx** xxxxx x xxxxxxxxx xx xxx xxx'x [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxxxxxx xx x xxxxxxxxx xxx xxxxxxxxx xxx xxxxx xxxxxxxx xx xxxxxxxxx xx xxx xxxxxxxxxxx xxxxxx xx xxxx **XxxxXxxxxx**. Xx xxxxxxxxxxx xxx xxxx xxx xxxx xxxxxxx'x XXx, xxxx xxx xxxxxxx xxxxxx xxx xxx xxxxx xxxxxx xxxx xxxxxxxxxx xxxxxxxxxxxxxx xx xxxx, xxx xxxx xxx xxxxxx xxxxxxx xxxxxxxx xxxxx xxxx xxx xxx xxxxxx.

## Xxxxxxx xxx xxxxxxx xxx xxxxxxxx xxx xxxxxxxxxxx xx xxx xxxxxx


Xxx'x xxxxxx xxxx xxxxxxx xx xxx xxx xxx xxx xxxxxxxx xx xxx xxxxxx xxxx xxxxxxx xx xxx xxxxxxxx.

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

## Xxxxxxxx xxx xxxxxxxxxx xxxxx xxxx


Xxx, xx xxxxxxx xxx xxxxxxxxxxxx xxxx xxxxxxx xxx xxxxxxx xxxxxxxxxx xxxx xxxxxxx xx **x\_xxxxXxxxxxxXxxxxxxx** xxxx xxx xxxxxxxxxx xxxxxxxxxxx xxxxxxxxxx xx xxx xxxxx xxxxxxxxxx xxxxxx. Xxx xxx xxxxx xxxx xxxxxx xxxxx xxxx xx xxxxxxx xxx xxxx xxx xxxx. Xx, xx xx xxxx xxxx xx xxxxxxx xxx xxx xxxx xxxxx xxxxxxxx xxxx xx xxxx xx xxxx xx xxx xxx xxx xxxxxxxx xxx xxxx xxxxxx xxxxxx xxxxxxxxxx xxxx xxx xxxxxxxx.

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

Xxxxxxx xx xxx'x xxxx xxxxxxx xxxxxxxx xxxx xxx xxxxxx xxxx xxx xxxxx-xxxxx xxxx xxxxxxxxxx, xx xxx x xxxxxxx xxxx xxxx xxxxxx xxx xxxxxxx xxxx x xxxxxxxx xx YY xxxxxx. Xx xxxx xxx xxxxxxxx, xxxxx xx xxx xxxxxxx xxxxx xxxx x xxxxxxxx xxxx xxxx. (Xxx xxx xxxxxx xxxx xxxxxxxx xx xxxx xxxxxx, xx xxxx xxxx xx xxxxx xx xxx xxxx xx xxxxxxxx xxxxx xx xxx xxxxxxxx xxx xxxxxxx xxxxx xx xxx xxxx xxxxxxxxxx xxxx.)

Xxxx xx xxxxxxx xxx xxxxxxxx, xx xxxx xxxxxxxxx xxx xxxxxxxxxxx xxxxxxxx xxxx xxx xxxx xxx xxxx xxxxxxxxxxx xxxx xxx xxxxxxxx xx xxx xxxxxx xxxx xxxxx xx xxxx xx xxx xxxxxx xxxx xxxxxxxx xxx xxxx xxxxxx xxx xxx xxxxx. Xxxxx, xx xxxxxx xxx x xxxxxxxxxx, xxxxxxx xx xx xxxxx-xxxx xx xxxx xxxx xx xxxxx xxxx xxx xxxx xxxxxxxxxx, xxx xxxx xxxxx xxxxxxx xx xxx xxxxxxxx xxxxxxxxx xx xxx xxxxx, xx x xxxxxx xxxxx xxxxx xxxxx xxx xxxxxxx xxxx. Xxxx, xx xxxx xxx x xxx x xxxx, xxxxxxx xx xx/xxxx xxx xxxxx xx xxxxx xxxx xxxxxx (xxxx xx x x-xxxx xxxxxxxx) xx xxx xxxx xxxxxxxxxx xxxxxx xxxxxxxxx xxxx x xxxxxx xxxxxx xxxx xxxxx xxx xxxx xxxxx xxxx xx xxx xx xxx xxxxxx (xxx x-xxxx).

Xxx xxxxx xxxxxxxx xx xxx xxxx xxxxx xxx xxx xxxxxx xx xxx xxxx xxxxxxxx xxxx xxx xxxxxxxxxx xxxxxxxx, xxx xxxx xx xxxx xx xxxx xx xxx xxxxxxxx xxxx xx xxxxx xxx **xxx\_Xxxxxxxx** xxxxxx (xxxx xxxxxx xxxxxx xxx xxxxx xxx xxxx xxxxx). Xxxxx xxxx, xx xxxxx xxx xxxx xxxxxxx xx xxxx.

## Xxxxxxxx xxx xxxx xxxxxx xxxx xxx xxx xxxxxx xxxxxxxx


Xx xxx xxxxxx x xxxxx xxxxx xxxxxxxxxx xxxx xxx xxxxxx xx xxxxxxx xx, xxx xxxxx xx xxxxxxx xxxxxxxx xxx xxxx xxxx xxx xx xx xx (xxxxx YY xxxxxxx xx xxx xxxx xxx xxxx, xxx xxxxxxx). Xxxx xxxxxxxxxx xxxxxxxx xxx xxxxxxx xxxxxxxx xxx xxx xxxxxxxxx:

```cpp
myMoveLookController->Update( m_window );   

// Update the view matrix based on the camera position.
myFirstPersonCamera->SetViewParameters(
                 myMoveLookController->get_Position(),       // Point we are at
                 myMoveLookController->get_LookPoint(),      // Point to look towards
                 DirectX::XMFLOAT3( 0, 1, 0 )                   // Up-vector
                 ); 
```

Xxxxxxxxxxxxxxx! Xxx'xx xxxxxxxxxxx xxxxx xxxx-xxxx xxxxxxxx xxx xxxx xxxxx xxxxxxx xxx xxxxxxxx/xxxxx xxxxx xxxxx xxxxxxxx xx xxxx xxxx!

> **Xxxx**  
Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

 

 




<!--HONumber=Mar16_HO1-->
