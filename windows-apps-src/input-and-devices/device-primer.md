---
Description: Getting to know the devices that support Universal Windows Platform (UWP) apps will help you offer the best user experience for each form factor.
title: Device primer for Universal Windows Platform (UWP) apps
ms.assetid: 7665044E-F007-495D-8D56-CE7C2361CDC4
label: Device primer
template: detail.hbs
---

#  Device primer for Universal Windows Platform (UWP) apps


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


![windows-powered devices](images/device-primer/1894834-hig-device-primer-01-500.png)

Getting to know the devices that support Universal Windows Platform (UWP) apps will help you offer the best user experience for each form factor. When designing for a particular device, the main considerations include how the app will appear on that device, where, when, and how the app will be used on that device, and how the user will interact with that device.

## <span id="Phones_and_phablets"></span><span id="phones_and_phablets"></span><span id="PHONES_AND_PHABLETS"></span>Phones and phablets


The most widely-used of all computing devices, phones can do a lot with limited screen real estate and basic inputs. Phones are available in a variety of sizes; larger phones are called phablets. App experiences on phablets are similar to those on phones, but the increased screen real estate of phablets enable some key changes in content consumption.

With Continuum for Phones, a new experience for compatible Windows 10 mobile devices, users can connect their phones to a monitor and even use a mouse and keyboard to make their phones work like a laptop. (For more info, see the [Continuum for Phone article](http://go.microsoft.com/fwlink/p/?LinkID=699431).)

Screen sizes
-   4'' to 5'' for phone
-   5.5'' to 7'' for phablet

![windows phone](images/device-primer/1894834-hig-device-primer-03.png)

Typical usage
-   Primarily used in portrait orientation, mostly due to the ease of holding the phone with one hand and being able to fully interact with it that way, but there are some experiences that work well in landscape, such as viewing photos and video, reading a book, and composing text.
-   Mostly used by just one person, the owner of the device.
-   Always within reach, usually stashed in a pocket or a bag.
-   Used for brief periods of time.
-   Users are often multitasking when using the phone.
-   Text is entered in short bursts.

UI considerations
-   The small size of a phone's screen allows only one frame at a time to be viewed in both portrait and landscape orientations. All hierarchical navigation patterns on a phone use the "drill" model, with the user navigating through single-frame UI layers.

-   Similar to phones, phablets in portrait mode can view only one frame at a time. But with the greater screen real estate available on a phablet, users have the ability to rotate to landscape orientation and stay there, so two app frames can be visible at a time.

-   In both landscape and portrait orientations, be sure that there's enough screen real estate for the app bar when the on-screen keyboard is up.

Inputs
-   Touch
-   Voice

Typical device capabilities
-   Microphone
-   Camera
-   Movement sensors
-   Location sensors

 

## <span id="Tablets"></span><span id="tablets"></span><span id="TABLETS"></span>Tablets


Ultra-portable tablet computers are equipped with touchscreens, cameras, microphones, and accelerometers. Tablet screen sizes usually range from 7” to 13.3”.

Screen sizes
-   7” to 13.3”

![a tablet device](images/device-primer/1894834-hig-device-primer-05.png)

Typical usage
-   About 80% of tablet use is by the owner, with the other 20% being shared use.
-   It’s most commonly used at home as a companion device while watching TV.
-   It’s used for longer periods than phones and phablets.
-   Text is entered in short bursts.

UI considerations
-   In both landscape and portrait orientations, tablets allow two frames at a time.
-   System back is located on the navigation bar.

Inputs
-   Touch
-   Stylus
-   External keyboard (occasionally)
-   Mouse (occasionally)
-   Voice (occasionally)

Typical device capabilities
-   Camera
-   Microphone
-   Movement sensors
-   Location sensors

 

## <span id="PCs_and_laptops"></span><span id="pcs_and_laptops"></span><span id="PCS_AND_LAPTOPS"></span>PCs and laptops


Windows PCs and laptops include a wide array of devices and screen sizes. In general, PCs and laptops can display more info than phone or tablets.

Screen sizes
-   13” and greater

![a pc](images/device-primer/1894834-hig-device-primer-06-349.png)

Typical usage
-   Apps on desktops and laptops see shared use, but by one user at a time, and usually for longer periods.

UI considerations
-   Apps can have a windowed view, the size of which is determined by the user. Depending on window size, there can be between one and three frames. On larger monitors, the app can have more than three frames.

-   When using an app on a desktop or laptop, the user has control over app files. As an app designer, be sure to provide the mechanisms to manage your app’s content. Consider including commands and features such as "Save As", "Recent files", and so on.

-   System back is optional. When an app developer chooses to show it, it appears in the app title bar.

Inputs
-   Mouse
-   Keyboard
-   Touch on laptops and all-in-one desktops.
-   Gamepads, such as the Xbox controller, are sometimes used.

Typical device capabilities
-   Camera
-   Microphone

 

## <span id="Surface_Hub_devices"></span><span id="surface_hub_devices"></span><span id="SURFACE_HUB_DEVICES"></span>Surface Hub devices


Microsoft Surface Hub is a large-screen team collaboration device designed for simultaneous use by multiple users.

Screen sizes
-   55” and 84''

![a surface hub](images/device-primer/1894834-hig-device-primer-07-349.png)

Typical usage
-   Apps on Surface Hub see shared use for short periods of time, such as in meetings.

-   Surface Hub devices are mostly stationary and rarely moved.

UI considerations
-   Apps on Surface Hub can appear in one of four states - full (standard full-screen view), background (hidden from view while the app is still running, available in task switcher), fill (a fixed view that occupies the available stage area), and snapped (variable view that occupies the right or left sides of the stage).
-   In snapped mode or fill modes, the system displays the Skype sidebar and shrinks the app horizontally.
-   System back is optional. When an app developer chooses to show it, it appears in the app title bar.

Inputs
-   Touch
-   Pen
-   Voice
-   Keyboard (on-screen/remote)
-   Touchpad (remote)

Typical device capabilities
-   Camera
-   Microphone

 

## <span id="Windows_IoT_devices"></span><span id="windows_iot_devices"></span><span id="WINDOWS_IOT_DEVICES"></span>Windows IoT devices


Windows IoT devices are an emerging class of devices centered around embedding small electronics, sensors, and connectivity within physical objects. These devices are usually connected through a network or the Internet to report on the real-world data they sense, and in some cases act on it. Devices can either have no screen (also known as “headless” devices) or are connected to a small screen (known as “headed” devices) with a screen size usually 3.5” or smaller.

Screen sizes
-   3.5'' or smaller
-   Some devices have no screen

![an iot device](images/device-primer/1894834-hig-device-primer-02.png)

Typical usage
-   Usually connected through a network or the Internet to report on the real-world data they sense, and in some cases act on it.
-   These devices can only run one application at a time unlike phones or other larger devices.
-   It isn’t something that is interacted with all the time, but instead is available when you need it, out of the way when you don’t.
-   App doesn’t have a dedicated back affordance, that is the developers responsibility.

UI considerations
-   "headless" devices have no screen.
-   Display for “headed” devices is minimal, only showing what is necessary due to limited screen real estate and functionality.
-   Orientation is most times locked, so your app only needs to consider one display direction.

Inputs
-   Variable, depending on the device

Typical device capabilities
-   Variable, depending on the device

 

\[This article contains information that is specific to UWP apps and Windows 10. For Windows 8.1 guidance, please download the [Windows 8.1 guidelines PDF](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

 

 


<!--HONumber=Mar16_HO4-->


