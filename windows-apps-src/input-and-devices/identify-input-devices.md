---
Xxxxxxxxxxx: Xxxxxxxx xxx xxxxx xxxxxxx xxxxxxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxx xxx xxxxxxxx xxxxx xxxxxxxxxxxx xxx xxxxxxxxxx.
xxxxx: Xxxxxxxx xxxxx xxxxxxx
xx.xxxxxxx: XYXYYXXX-XYYY-YYXY-XXYY-XXXXXXYYYYXY
xxxxx: Xxxxxxxx xxxxx xxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxx xxxxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.Xxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225648)
-   [**Xxxxxxx.XX.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br208383)
-   [**Xxxxxxx.XX.Xxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242084)

Xxxxxxxx xxx xxxxx xxxxxxx xxxxxxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxx xxx xxxxxxxx xxxxx xxxxxxxxxxxx xxx xxxxxxxxxx.


## <span id="Retrieve_mouse_properties">
            </span>
            <span id="retrieve_mouse_properties">
            </span>
            <span id="RETRIEVE_MOUSE_PROPERTIES">
            </span>Xxxxxxxx xxxxx xxxxxxxxxx


Xxx [**Xxxxxxx.Xxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225648) xxxxxxxxx xxxxxxxx xxx [**XxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225626) xxxxx xxxx xx xxxxxxxx xxx xxxxxxxxxx xxxxxxx xx xxx xx xxxx xxxxxxxxx xxxx. Xxxx xxxxxx x xxx **XxxxxXxxxxxxxxxxx** xxxxxx xxx xxx xxx xxxxxxxxxx xxx'xx xxxxxxxxxx xx.

**Xxxx**  Xxx xxxxxx xxxxxxxx xx xxx xxxxxxxxxx xxxxxxxxx xxxx xxx xxxxx xx xxx xxxxxxxx xxxx: Xxxxxxx xxxxxxxxxx xxxxxx xxx-xxxx xx xx xxxxx xxx xxxxx xxxxxxxx x xxxxxxxx xxxxxxxxxx, xxx xxxxxxx xxxxxxxxxx xxxxxx xxx xxxxxxx xxxxx xxxxxxx xx xxx xxx xxxxx.

 

Xxx xxxxxxxxx xxxx xxxx x xxxxxx xx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xxxxxxxx xx xxxxxxx xxx xxxxxxxxxx xxxxx xxxxxxxxxx xxx xxxxxx.

```CSharp
private void GetMouseProperties()
{
    MouseCapabilities mouseCapabilities = new Windows.Devices.Input.MouseCapabilities();
    MousePresent.Text = mouseCapabilities.MousePresent != 0 ? "Yes" : "No";
    VertWheel.Text = mouseCapabilities.VerticalWheelPresent != 0 ? "Yes" : "No";
    HorzWheel.Text = mouseCapabilities.HorizontalWheelPresent != 0 ? "Yes" : "No";
    SwappedButtons.Text = mouseCapabilities.SwapButtons != 0 ? "Yes" : "No";
    NumButtons.Text = mouseCapabilities.NumberOfButtons.ToString();
}
```

## <span id="Retrieve_keyboard_properties">
            </span>
            <span id="retrieve_keyboard_properties">
            </span>
            <span id="RETRIEVE_KEYBOARD_PROPERTIES">
            </span>Xxxxxxxx xxxxxxxx xxxxxxxxxx


Xxx [**Xxxxxxx.Xxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225648) xxxxxxxxx xxxxxxxx xxx [**XxxxxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225623) xxxxx xxxx xx xxxxxxxx xxxxxxx x xxxxxxxx xx xxxxxxxxx. Xxxx xxxxxx x xxx **XxxxxxxxXxxxxxxxxxxx** xxxxxx xxx xxx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225625) xxxxxxxx.

Xxx xxxxxxxxx xxxx xxxx x [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xxxxxxx xx xxxxxxx xxx xxxxxxxx xxxxxxxx xxx xxxxx.

```CSharp
private void GetKeyboardProperties()
{
    KeyboardCapabilities keyboardCapabilities = new Windows.Devices.Input.KeyboardCapabilities();
    KeyboardPresent.Text = keyboardCapabilities.KeyboardPresent != 0 ? "Yes" : "No";
}
```

## <span id="Retrieve_touch_properties">
            </span>
            <span id="retrieve_touch_properties">
            </span>
            <span id="RETRIEVE_TOUCH_PROPERTIES">
            </span>Xxxxxxxx xxxxx xxxxxxxxxx


Xxx [**Xxxxxxx.Xxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225648) xxxxxxxxx xxxxxxxx xxx [**XxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225644) xxxxx xxxx xx xxxxxxxx xxxxxxx xxx xxxxx xxxxxxxxxx xxx xxxxxxxxx. Xxxx xxxxxx x xxx **XxxxxXxxxxxxxxxxx** xxxxxx xxx xxx xxx xxxxxxxxxx xxx'xx xxxxxxxxxx xx.

**Xxxx**  Xxx xxxxxx xxxxxxxx xx xxx xxxxxxxxxx xxxxxxxxx xxxx xxx xxxxx xx xxx xxxxxxxx xxxxx xxxxxxxxxx: Xxxxxxx xxxxxxxxxx xxxxxx xxx-xxxx xx xx xxxxx xxx xxxxxxxxx xxxxxxxx x xxxxxxxx xxxxxxxxxx, xxx xxxxxxx xxxxxxxxxx xxxxxx xxx xxxxxxx xxxxx xxxxxxx xx xxx xxx xxxxxxxxx.

 

Xxx xxxxxxxxx xxxx xxxx x xxxxxx xx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xxxxxxxx xx xxxxxxx xxx xxxxx xxxxxxxxxx xxx xxxxxx.

```CSharp
private void GetTouchProperties()
{
    TouchCapabilities touchCapabilities = new Windows.Devices.Input.TouchCapabilities();
    TouchPresent.Text = touchCapabilities.TouchPresent != 0 ? "Yes" : "No";
    Contacts.Text = touchCapabilities.Contacts.ToString();
}
```

## <span id="Retrieve_pointer_properties">
            </span>
            <span id="retrieve_pointer_properties">
            </span>
            <span id="RETRIEVE_POINTER_PROPERTIES">
            </span>Xxxxxxxx xxxxxxx xxxxxxxxxx


Xxx [**Xxxxxxx.Xxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225648) xxxxxxxxx xxxxxxxx xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225633) xxxxx xxxx xx xxxxxxxx xxxxxxx xxx xxxxxxxx xxxxxxx xxxxxxx xxxxxxx xxxxx (xxxxx, xxxxxxxx, xxxxx, xx xxx). Xxxx xxxxxx x xxx **XxxxxxxXxxxxx** xxxxxx xxx xxx xxx xxxxxxxxxx xxx'xx xxxxxxxxxx xx.

**Xxxx**  Xxx xxxxxx xxxxxxxx xx xxx xxxxxxxxxx xxxxxxxxx xxxx xxx xxxxx xx xxx xxxxxxxx xxxxxxx xxxxxxx: Xxxxxxx xxxxxxxxxx xxxxxx xxx-xxxx xx xx xxxxx xxx xxxxxx xxxxxxxx x xxxxxxxx xxxxxxxxxx, xxx xxxxxxx xxxxxxxxxx xxxxxx xxx xxxxxxx xxxxx xxxxxxx xx xxx xxx xxxxxxx xxxxxx.

 

Xxx xxxxxxxxx xxxx xxxx x xxxxx xx xxxxxxx xxx xxxxxxxxxx xxx xxxxxx xxx xxxx xxxxxxx xxxxxx.

```CSharp
private void GetPointerDevices()
{
    IReadOnlyList<PointerDevice> pointerDevices = Windows.Devices.Input.PointerDevice.GetPointerDevices();
    int gridRow = 0;
    int gridColumn = 0;

    for (int i = 0; i < pointerDevices.Count; i++)
    {
        // Pointer device type.
        TextBlock textBlock1 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock1);
        textBlock1.Text = (i + 1).ToString() + " Pointer Device Type:";
        Grid.SetRow(textBlock1, gridRow);
        Grid.SetColumn(textBlock1, gridColumn);

        TextBlock textBlock2 = new TextBlock();
        textBlock2.Text = pointerDevices[i].PointerDeviceType.ToString();
        Grid_PointerProps.Children.Add(textBlock2);
        Grid.SetRow(textBlock2, gridRow++);
        Grid.SetColumn(textBlock2, gridColumn + 1);

        // Is external?
        TextBlock textBlock3 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock3);
        textBlock3.Text = (i + 1).ToString() + " Is External?";
        Grid.SetRow(textBlock3, gridRow);
        Grid.SetColumn(textBlock3, gridColumn);

        TextBlock textBlock4 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock4);
        textBlock4.Text = pointerDevices[i].IsIntegrated.ToString();
        Grid.SetRow(textBlock4, gridRow++);
        Grid.SetColumn(textBlock4, gridColumn + 1);

        // Maximum contacts.
        TextBlock textBlock5 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock5);
        textBlock5.Text = (i + 1).ToString() + " Max Contacts:";
        Grid.SetRow(textBlock5, gridRow);
        Grid.SetColumn(textBlock5, gridColumn);

        TextBlock textBlock6 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock6);
        textBlock6.Text = pointerDevices[i].MaxContacts.ToString();
        Grid.SetRow(textBlock6, gridRow++);
        Grid.SetColumn(textBlock6, gridColumn + 1);

        // Physical device rectangle.
        TextBlock textBlock7 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock7);
        textBlock7.Text = (i + 1).ToString() + " Physical Device Rect:";
        Grid.SetRow(textBlock7, gridRow);
        Grid.SetColumn(textBlock7, gridColumn);

        TextBlock textBlock8 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock8);
        textBlock8.Text = pointerDevices[i].PhysicalDeviceRect.X.ToString() + "," +
            pointerDevices[i].PhysicalDeviceRect.Y.ToString() + "," +
            pointerDevices[i].PhysicalDeviceRect.Width.ToString() + "," +
            pointerDevices[i].PhysicalDeviceRect.Height.ToString();
        Grid.SetRow(textBlock8, gridRow++);
        Grid.SetColumn(textBlock8, gridColumn + 1);

        // Screen rectangle.
        TextBlock textBlock9 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock9);
        textBlock9.Text = (i + 1).ToString() + " Screen Rect:";
        Grid.SetRow(textBlock9, gridRow);
        Grid.SetColumn(textBlock9, gridColumn);

        TextBlock textBlock10 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock10);
        textBlock10.Text = pointerDevices[i].ScreenRect.X.ToString() + "," +
            pointerDevices[i].ScreenRect.Y.ToString() + "," +
            pointerDevices[i].ScreenRect.Width.ToString() + "," +
            pointerDevices[i].ScreenRect.Height.ToString();
        Grid.SetRow(textBlock10, gridRow++);
        Grid.SetColumn(textBlock10, gridColumn + 1);

        gridColumn += 2;
        gridRow = 0;
    }
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


**Xxxxxxx**
* [Xxxxx xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [Xxx xxxxxxx xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [Xxxx xxxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619894)
**Xxxxxxx xxxxxxx**
* [Xxxxx: Xxxxxx xxxxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231530)
 

 




<!--HONumber=Mar16_HO1-->
