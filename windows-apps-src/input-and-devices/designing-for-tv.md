---
Description: Design your app so that it looks good and functions well on your television.
title: Designing for Xbox and TV
ms.assetid: 780209cb-3e8a-4cf7-8f80-8b8f449580bf
label: Designing for Xbox and TV
template: detail.hbs
isNew: true
---
<!--Note to Eliot from Linda: see my comments by searching on v-lcap; after your review, I recommend removing all commented out text unless you think you may need it later; it just gets in the way of an already long doc-->

> \[This article describes a feature that's not yet available. This feature may be substantially modified before its commercial release. Microsoft makes no warranties, express or implied, with respect to the information provided here.\]

# Designing for Xbox and TV

Design your Universal Windows Platform (UWP) app so that it looks good and functions well on Xbox One and television screens.

## Overview

The Universal Windows Platform lets you create delightful experiences across multiple Windows 10 devices. 
Most of the functionality provided by the UWP framework enables apps to use the same user interface (UI) across these devices, without additional work. 
However, tailoring and optimizing your app to work great on Xbox One and TV screens requires special considerations.

The experience of sitting on your couch across the room, using a gamepad or remote to interact with your TV, is called the **10-foot experience**. 
It is so named because the user is generally sitting approximately 10 feet away from the screen. 
This provides unique challenges that aren't present in, say, the *2-foot* experience, or interacting with a PC. 
If you are developing an app for Xbox One or any other device that outputs to the TV screen and uses a controller for input, you should always keep this in mind.

Not all of the steps in this article are required to make your app work well for 10-foot experiences, but understanding them and making the appropriate decisions for your app will result in a better 10-foot experience tailored for your app's specific needs. 
As you bring your app to life in the 10-foot environment, consider the following design principles.

### Simple

Designing for the 10-foot environment presents a unique set of challenges. Resolution and viewing distance can make it difficult for people to process too much information. 
Try to keep your design clean, reduced to the simplest possible components. The amount of information displayed on a TV should be comparable to what you'd see on a mobile phone, rather than on a desktop.

![Xbox One home screen](images/designing-for-tv/xbox-home-screen.png)

### Coherent

UWP apps in the 10-foot environment should be intuitive and easy to use. Make the focus clear and unmistakable. 
Arrange content so that movement across the space is consistent and predictable. Give people the shortest path to what they want to do.

![Xbox One Movies app](images/designing-for-tv/xbox-movies-app.png)

_**All movies shown in the screenshot are available on Microsoft Movies & TV.**_  

### Captivating

The most immersive, cinematic experiences take place on the big screen. Edge-to-edge scenery, elegant motion, and vibrant use of color and typography take your apps to the next level. Be bold and beautiful.

![Xbox One Avatar app](images/designing-for-tv/xbox-avatar-app.png)

### Optimizations for the 10-foot experience

Now that you know the principles of good UWP app design for the 10-foot experience, read through the following overview of the specific ways you can optimize your app and make for a great user experience.
<!--[v-lcap] I recommend shortening the descriptions to the bare minimum, and focusing on the rest in the actual sections. I also rearranged the order of this table to map to the order you have in the document.-->


| Feature        | Description           |
| -------------------------------------------------------------- |--------------------------------|
| [UI element sizing](#ui-element-sizing)  | The Universal Windows Platform uses [scaling and effective pixels](..\layout\design-and-ui-intro.md#effective-pixels-and-scaling) to scale the UI according to the viewing distance. When a UWP app is running on Xbox One, it uses an appropriate default scale factor to make all the UI elements, such as text and common controls, easily visible from your couch across the room. Understanding sizing and applying it across your UI will help optimize your app for the 10-foot environment.  |
|  [TV-safe area](#tv-safe-area) | Not all TVs display content all the way to the edge of the screen due to historical as well as technological reasons. The UWP will automatically avoid displaying any UI in unsafe areas (areas close to the edges of the screen) by default. However, this creates a "boxed-in" effect in which the UI looks letterboxed. For your app to be truly immersive on TV, you will want to modify it so that it extends to the edges of the screen on TVs that support it. |
| [Colors](#colors)  |  The UWP supports color themes, and an app that respects the system theme will default to **dark** on Xbox One. If your app has a specific color theme, you should consider that some colors don't work well for TV and should be avoided. For the best possible results, consider creating a TV-specific color palette for your app. |
| [Gamepad and remote control](#gamepad-and-remote-control)      | Making sure that your app works well with gamepad and remote is the most important step in optimizing for 10-foot experiences. Properly supporting keyboard interaction and navigation helps get gamepad and remote control input working relatively well. However, there are gamepad and remote-specific improvements that you can make to optimize the user interaction experience on a device where their actions are somewhat limited. |
| [Mouse mode](#mouse-mode)|In some user interfaces, such as maps and drawing surfaces, it is not possible or practical to use XY focus navigation. For these interfaces, the UWP provides **mouse mode** to let the gamepad/remote navigate freely, like a mouse on a desktop computer.|
| [Focus visual](#focus-visual)  | The focus visual is the border around the UI element that currently has focus. This helps orient the user so that they can easily navigate your UI without getting lost. While focus visual works across multiple Windows 10 devices, you will want to make sure that it is easy to see on TV and that it defaults to a location that the user will interact with often. If the focus is not clearly visible, the user could get lost in your UI and not have a great experience. Also, take advantage of [Light dismiss overlay](#light-dismiss-overlay) to call attention to UI that a user is currently interacting with.  |
| [XY focus navigation and interaction](#xy-focus-navigation-and-interaction) | The UWP provides **XY focus navigation** that allows the user to navigate around your app's UI. However, this limits the user to navigating up, down, left, and right. Recommendations for dealing with this and other considerations are outlined in this section. You may also need to utilize [focus engagement](#focus-engagement) (by pressing the **Enter/Select** button to interact with a UI element) to use certain controls, such as sliders. This cuts down on the number of clicks required to get from one side of the screen to the other. | 
| [Guidelines for UI controls](#guidelines-for-ui-controls)  |  There are certain improvements you can make to your app that make sense for all Windows 10 devices, not just Xbox One or other 10-foot experiences. Rather than only improving the 10-foot experience, consider applying these best practices across all devices supported by the UWP, which are particularly beneficial for TV.  |

<!--[v-lcap] "Focus engagement" is an H2 section that precedes "XY focus"; I recommend either putting it in its own row in the table ahead of XY focus, or changing it to an H3 section under "XY focus," whichever makes more sense; just as long as the overview table  matches what you do-->

<!--| [Sound](../style/sound.md)  |  Sounds play a key role in the 10-foot experience, helping to immerse and give feedback to the user. The UWP provides functionality that automatically turns on sounds for common controls when the app is running on Xbox One. Find out more about the sound support built into the UWP and learn how to take advantage of it. |-->


<!--[v-lcap] I had to put this table into markdown because the links weren't rendering in HTML.
<table>
    <tr>
        <td> [Gamepad and remote control](#gamepad-and-remote-control)</td>
        <td>Making sure that your app works well with gamepad and remote is the most important step in optimizing for 10-foot experiences. Properly supporting keyboard interaction and navigation helps get gamepad and remote control input working relatively well. However, there are gamepad and remote-specific improvements that you can make to optimize the user interaction experience on a device where their actions are somewhat limited.
        </td>
    </tr>
    <tr>
        <td>[XY focus navigation and interaction](#xy-focus-navigation-and-interaction)</td>
        <td>The UWP provides **XY focus navigation** that allows the user to navigate around your app's UI. However, this limits the user to navigating up, down, left, and right. Recommendations for dealing with this and other considerations are outlined in this section. You may also need to utilize [focus engagement](#focus-engagement) (by pressing the **Enter/Select** button to interact with a UI element) to use certain controls, such as sliders. This cuts down on the number of clicks required to get from one side of the screen to the other.
        </td>
    </tr>
    <tr>
        <td>[Mouse mode](#mouse-mode)</td>
        <td>In some user interfaces, such as maps and drawing surfaces, it is not possible or practical to use XY focus navigation. For these interfaces, the UWP provides **mouse mode** to let the gamepad/remote navigate freely, like a mouse on a desktop computer.
        </td>
    </tr>
    <tr>
        <td>[Focus visual](#focus-visual)</td>
        <td>The focus visual is the border around the UI element that currently has focus. This helps orient the user so that they can easily navigate your UI without getting lost. While focus visual works across multiple Windows 10 devices, you will want to make sure that it is easy to see on TV and that it defaults to a location that the user will interact with often. If the focus is not clearly visible, the user could get lost in your UI and not have a great experience. Also, take advantage of [Light dismiss overlay](#light-dismiss-overlay) to call attention to UI that a user is currently interacting with.
        </td>
    </tr>
    <tr>
        <td>[UI element sizing](#ui-element-sizing)</td>
        <td>
            The Universal Windows Platform uses [scaling and effective pixels](..\layout\design-and-ui-intro.md#effective-pixels-and-scaling) to scale the UI according to the viewing distance. 
            When a UWP app is running on Xbox One, it uses an appropriate default scale factor in order to make all the UI elements, such as text and common controls, easily visible from your couch across the room. 
            Understanding sizing and applying it across your UI will help optimize your app for the 10-foot environment.
        </td>
    </tr>
    <tr>
        <td>[TV-safe area](#tv-safe-area)</td>
        <td>
            Not all TVs display content all the way to the edge of the screen due to historical as well as technological reasons. 
            The UWP will automatically avoid displaying any UI in unsafe areas (areas close to the edges of the screen) by default. However, this creates a "boxed-in" effect in which the UI looks letterboxed. 
            For your app to be truly immersive on TV, you will want to modify it so that it extends to the edges of the screen on TVs that support it.
        </td>
    </tr>
    <tr>
        <td>[Colors](#colors)</td>
        <td>
            The UWP supports color themes, and an app that respects the system theme will default to **dark** on Xbox One. 
            If your app has a specific color theme, you should consider that some colors don't work well for TV and should be avoided. 
            For the best possible results, consider creating a TV-specific color palette for your app.
        </td>
    </tr>
    <tr>
        <td>[Sound](../style/sound.md)</td>
        <td>
            Sounds play a key role in the 10-foot experience, helping to immerse and give feedback to the user. The UWP provides functionality that automatically turns on sounds for common controls when the app is running on Xbox One. Find out more about the sound support built into the UWP and learn how to take advantage of it.
        </td>
    </tr>
    <tr>
        <td>[Guidelines for UI controls](#guidelines-for-ui-controls)</td>
        <td>
            There are certain improvements you can make to your app that make sense for all Windows 10 devices, not just Xbox One or other 10-foot experiences. 
            Rather than only improving the 10-foot experience, consider applying these best practices across all devices supported by the UWP, which are particularly beneficial for TV.
        </td>
    </tr>
</table>-->

<!--### Gamepad and remote interaction

Users of your TV app won't be interacting with the UI with a high-precision input device such as a mouse, and this needs to be taken into account when designing your app's interface. Visibility of the **focus visual** (the border highlighting the UI element that the user is currently navigated to) is also key to making sure that the user doesn't get lost.

#### [Gamepad and remote control](#gamepad-and-remote-control)

Making sure that your app works well with gamepad and remote is the most important step in optimizing for TV. As mentioned in [Running UWP apps on Xbox One](#running-uwp-apps-on-xbox-one), properly supporting keyboard interaction and navigation helps get gamepad and remote control input working relatively well. However, there are gamepad- and remote-specific improvements that you can make to optimize the user interaction experience on a device where their actions are somewhat limited.

#### [Focus visual](#focus-visual)

While focus visual works across multiple Windows 10 devices, you will want to make sure that it is easy to see on TV and that it defaults to a location that the user will interact with often. If the focus is not clearly visible, the user could get lost in your UI and not have a great experience.

#### [2D focus navigation and interaction](#2d-focus-navigation-and-interaction)

UWP provides 2D navigation that allows the user to navigate around your app's UI. However, this limits the user to navigating up, down, left, and right. Recommendations for dealing with this and other considerations are outlined in [2D navigation best practices](#2d-navigation-best-practices). You may also need to utilize [focus engagement](#focus-engagement) (pressing the **Enter/Accept** button to interact with a UI element) to use certain controls, such as sliders. This cuts down on the number of clicks required to get from one side of the screen to the other.

#### [Mouse mode](#mouse-mode)

In some user interfaces, such as maps and drawing surfaces, it is not possible or practical to use 2D navigation. For these interfaces, UWP provides **mouse mode** to let the gamepad/remote navigate freely, like a mouse on a desktop computer.

### Layout and content density

Unlike with desktop apps, in which the user is close to the screen, a user interacting with your app on TV will likely be sitting in a couch across the room. Because of this, reducing content density is important so that the user can easily navigate your app. Remember: simplicity is key.

#### [UI element sizing](#ui-element-sizing)

The Universal Windows Platform uses [scaling and effective pixels](../layout/grid.md) to scale the UI according to the viewing distance. When a UWP app is running on Xbox One, it uses an appropriate default scale factor in order to make all the UI elements, such as text and common controls, easily visible from your couch across the room. Understanding sizing and applying it across your UI will help optimize your app for TV.

#### [TV-safe area](#tv-safe-area)

Not all TVs display content all the way to the edge of the screen due to historical as well as technological reasons. UWP will automatically avoid displaying any UI in unsafe areas (areas close to the edges of the screen) by default. However, this creates a "boxed-in" effect in which the UI looks letterboxed. For your app to be truly immersive on TV, you will want to modify it so that it extends to the edges of the screen on TVs that support it.

### Styles for TV

When designing for TV, there are special considerations in regards to color and sound. The styles you use may work great for other devices, but might need some optimizing to make them shine on TV.

#### [Colors](#colors)

UWP supports color themes, and an app that respects the system theme will default to **dark** on Xbox One. If your app has a specific color theme, you should consider that some colors don't work well for TV and should be avoided. For the best possible results, consider creating a TV-specific color palette for your app.

#### [Sound](../style/sound.md)

Sounds play a key role in TV apps, helping immerse the user in the interactive experience. Find out more about the sound support built into UWP and learn how to take advantage of it.

### [Improvements for all platforms](#improvements-for-all-platforms)

There are certain improvements you can make to your app that make sense for all Windows 10 platforms, not just Xbox One or other TV experiences. Rather than only improving the TV experience, consider applying these best practices that apply across all platforms UWP supports, and are particularly beneficial for TV.
-->

<!--## Running UWP apps on Xbox One

Some features for UWP in the 10-foot environment are built-in, and you will get these without any additional work once you properly port to Xbox One. However, there are other optimizations you may want to consider making so that your app performs as well as it can on Xbox. Learn about these features in the following sections.

### Gamepad and remote control support

Arrow key and tab stop behavior (pressing **Tab** to get to the next UI element) on keyboard informs how 2D navigation moves focus through the **D-pad** on a game controller or remote. The **Enter** and **Space** keys are also automatically mapped to the **Enter/Accept** key (see [Gamepad and remote control](#gamepad-and-remote-control)).

The quality of gamepad and remote behavior that you get out of the box depends on how well keyboard is supported in your app, and thus may vary greatly from app to app. A good way to ensure that your app will work well with gamepad/remote is to make sure that it works well with keyboard on PC, and then test with gamepad/remote to find weak spots in your UI.

### TV-safe area

Using the [VisibleBounds](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.applicationview.visiblebounds.aspx) functionality of UWP (for more information, see [TV-safe area](#tv-safe-area)), the following will be done automatically for your app:

* All UI elements are drawn inside the TV-safe area
* The page's background colors are drawn all the way to the edges of the TV

![TV-safe area](images/designing-for-tv/tv-safe-area.png)

### UI scaling

UWP supports proper scaling of UI based on the settings of the system on which the app is currently running. On desktop, this setting can be found in **Settings > System > Display** as a sliding value. This same setting exists on phone as well if the device supports it.

![Change the size of text, apps, and other items](images/designing-for-tv/ui-scaling.png)

On Xbox One there is no such system setting, however in order for UWP UI elements to be sized appropriately for TV, they are scaled at a default of **200%**. As long as UI elements are appropriately sized for other platforms, they will be appropriately sized for TV as well. For more information, see [UI element sizing](#ui-element-sizing).


### Focus visual

The same focus visual can be used for keyboard as well as game controller input, and will always be highly visible on any platform that supports focus visual, including Xbox One and the 10-foot experience. For more information, see [Focus visual](#focus-visual).

### Sound

UWP provides functionality that automatically turns on sounds for common controls when the app is running on Xbox One. This helps provide feedback to the user that they have interacted with the app in some way. For more information, see [Sound](../style/sound.md).

### Accent color and high contrast colors

As long as your app uses a brush resource such as **SystemControlForegroundAccentBrush**, or a color resource (**SystemAccentColor**), or instead calls accent colors directly through the [UIColorType.Accent*](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.uicolortype.aspx) API, those colors are replaced with accent colors appropriate for TV. High contrast brush colors are also pulled in from the system the same way as on PC and phone, but with TV-appropriate colors.

### Light dismiss overlay

In order to call the user's attention to the UI elements that the user is currently manipulating with the game controller or remote control, UWP automatically adds a "smoke" layer that covers areas outside of the popup UI when the app is running on Xbox One. This requires no extra work, but is something to keep in mind when designing your UI.
-->

## UI element sizing

Because the user of an app in the 10-foot environment is using a remote control or gamepad and is sitting several feet away from the screen, there are some UI considerations that need to be factored into your design. 
Make sure that the UI has an appropriate content density and is not too cluttered so that the user can easily navigate and select elements. Remember: simplicity is key.

### Scale factor and adaptive layout

**Scale factor** helps with ensuring that UI elements are displayed with the right sizing for the device on which the app is running. 
On desktop, this setting can be found in **Settings > System > Display** as a sliding value. 
This same setting exists on phone as well if the device supports it.

![Change the size of text, apps, and other items](images/designing-for-tv/ui-scaling.png) 

On Xbox One, there is no such system setting; however, for UWP UI elements to be sized appropriately for TV, they are scaled at a default of **200%**. 
As long as UI elements are appropriately sized for other devices, they will be appropriately sized for TV. 
Xbox One renders your app at 1080p (1920 x 1080 pixels). Therefore, when bringing an app from other devices such as PC, 
ensure that the UI looks great at 960 x 540 px at 100% scale utilizing [adaptive techniques](https://msdn.microsoft.com/en-us/windows/uwp/layout/screen-sizes-and-breakpoints-for-responsive-design).

Designing for Xbox is a little different from designing for PC because you only need to worry about one resolution, 1920 x 1080. 
It doesn't matter if the user has a TV that has better resolution&mdash;UWP apps will always scale to 1080p.

Correct asset sizes from the 200% set will also be pulled in for your app when running on Xbox One, regardless of TV resolution.

### Content density

When designing your app, remember that the user will be viewing the UI from a distance and interacting with it by using a remote or game controller, which takes more time to navigate than using mouse or touch input.

#### Sizes of UI controls

Interactive UI elements should be sized at a minimum height of 32 epx (effective pixels). This is the default for common UWP controls, and when used at 200% scale, it ensures that UI elements are visible from a distance and helps reduce content density. 

<!--For more information about effective pixels, see [Effective pixels](../layout/grid.md#effective-pixels).-->

![UWP button at 100% and 200% scale](images/designing-for-tv/button-100-200.png)

#### Number of clicks

When the user is navigating from one edge of the TV screen to the other, it should take no more than **six clicks** to simplify your UI. Again, the principle of **simplicity** applies here. For more details, see [Path of least clicks](#path-of-least-clicks).

![6 icons across](images/designing-for-tv/six-clicks.png)

### Text sizes

To make your UI visible from a distance, use the following rules of thumb:

* Main text and reading content: 15 epx minimum
* Non-critical text and supplemental content: 12 epx minimum

When using larger text in your UI, pick a size that does not limit screen real estate too much, taking up space that other content could potentially fill.

### Opting out of scale factor

We recommend that your app take advantage of scale factor support, which will help it run appropriately on all devices by scaling for each device type. 
However, it is possible to opt out of this behavior and design all of your UI at 100% scale. Note that you cannot change the scale factor to anything other than 100%.

You can opt out of scale factor by using the following code snippet:

```csharp
bool result = Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```

`result` will inform you whether you successfully opted out.

Please be sure to calculate the appropriate sizes of UI elements by doubling the *effective* pixel values mentioned in this topic to *actual* pixel values.

## TV-safe area

Not all TVs display content all the way to the edges of the screen due to historical and technological reasons. By default, the UWP will avoid displaying any UI content in TV-unsafe areas and instead will only draw the page background.

The TV-unsafe area is represented by the blue area in the following image.

![TV-unsafe area](images/designing-for-tv/tv-unsafe-area.png)

You can set the background to a static or themed color, or to an image, as the following code snippets demonstrate.

### Theme color

```xml
<Page x:Class="Sample.MainPage"
      Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"/>
```

### Image

```xml
<Page x:Class="Sample.MainPage"
      Background="\Assets\Background.png"/>
```

This is what your app will look like without additional work.

![TV-safe area](images/designing-for-tv/tv-safe-area.png)

This is not optimal because it gives the app a "boxed-in" effect, with parts of the UI such as the nav pane and grid seemingly cut off. However, you can make optimizations to extend parts of the UI to the edges of the screen to give the app a more cinematic effect.

### Drawing UI to the edge

We recommend that you use certain UI elements to extend to the edges of the screen to provide more immersion to the user. These include [ScrollViewers](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx), [nav panes](https://msdn.microsoft.com/en-us/windows/uwp/controls-and-patterns/nav-pane), and [CommandBars](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx).

On the other hand, it's also important that interactive elements and text always avoid the screen edges to ensure that they won't be cut off on some TVs. We recommend that you draw only non-essential visuals within 5% of the screen edges. As mentioned in [UI element sizing](#ui-element-sizing), a UWP app following the Xbox One console's default scale factor of 200% will utilize an area of 960 x 540 epx, so in your app's UI, you should avoid putting essential UI in the following areas:

- 27 epx from the top and bottom
- 48 epx from the left and right sides

There are two ways to have UI extend to the screen edges: *core window bounds* and *negative margins*.

### Core window bounds

For UWP apps targeting only the 10-foot experience, using core window bounds is a more straightforward option.

In the `OnLaunched` method of `App.xaml.cs`, add the following code:

```csharp
Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode
    (Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
```

With this line of code, the app window will extend to the edges of the screen, so you will need to move all interactive and essential UI into the TV-safe area described earlier. Transient UI, such as context menus and opened [ComboBoxes](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.combobox.aspx), will automatically remain inside the TV-safe area.

![Core window bounds](images/designing-for-tv/core-window-bounds.png)

### Negative margins

For UWP apps targeting a range of devices such as mobile, desktop, and Xbox One, negative margins may be a more intuitive method for tailoring adaptive layouts. 
We recommend that you create a [custom trigger](#custom-visual-state-trigger-for-xbox-one) and modify the margins for TV layouts.

#### Pane backgrounds 

<!--[v-lcap] Do you mean "panel" or "pane" in this title and paragraph? 03-29-16 - updated to "pane" per Chigusa-->

Navigation panes are typically drawn near the edge of the screen, so the background should extend into the TV-unsafe area so as not to introduce awkward gaps. 
You can do this with negative margins on the [SplitView](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.splitview.aspx) control, 
which is commonly used as a nav pane building block, and positive margins on the `SplitView`'s content to keep it within the TV-safe area.

![Nav pane extended to edges of screen](images/designing-for-tv/tv-safe-areas-2.png)

Here, the nav pane's background has been extended to the edges of the screen, while its navigation items are kept in the TV-safe area. 
The content of the `SplitView` (in this case, a grid of items) has been extended to the bottom of the screen so that it looks like it continues and isn't cut off, while the top of the grid is still within the TV-safe area. Later in this section you will learn how to keep the focused item in the TV-safe area as well.

The following code snippet achieves this effect:

```xml
<SplitView x:Name="RootSplitView"
           Margin="-48, -27">
            <SplitView.Pane>
                 <ListView x:Name="NavMenuList"
                           Margin="0,75,0,27"
                           ContainerContentChanging=
                                "NavMenuItemContainerContentChanging"
                           ItemContainerStyle="{StaticResource 
                                NavMenuItemContainerStyle}"
                           ItemTemplate="{StaticResource NavMenuItemTemplate}"
                           ItemInvoked="NavMenuList_ItemInvoked"/>
            </SplitView.Pane>
            <Frame x:Name="frame"
                   Margin="0,27,48,27"
                   Navigating="OnNavigatingToPage"
                   Navigated="OnNavigatedToPage"/>
    </SplitView>
```

[CommandBar](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) is another example of a pane that is commonly positioned near one or more edges of the app, and as such on TV its background should extend to the edges of the screen. It also usually contains a **More** button, represented by "..." on the right side, which should remain in the TV-safe area. Following are a few different strategies to achieve the desired interactions and visual effects.

**Option 1**: Change the `CommandBar` background color to either transparent or the same color as the page background:

```xml
<CommandBar x:Name="topbar" 
            Background="{ThemeResource SystemControlBackgroundAltHighBrush}">
            ...
</CommandBar>
```

Doing this will make the `CommandBar` look like it is on top of the same background as the rest of the page, so the background seamlessly flows to the edge of the screen.

**Option 2**: Add a background rectangle whose fill is the same color as the `CommandBar` background, and extend it to the edges of the screen with negative margins:

```xml
<Rectangle VerticalAlignment="Top" 
            HorizontalAlignment="Stretch" 
            Margin="0,-27,-48,0"      
            Fill="{ThemeResource SystemControlBackgroundChromeMediumBrush}"/>
<CommandBar x:Name="topbar" 
            VerticalAlignment="Top" 
            HorizontalContentAlignment="Stretch">
            ...
</CommandBar>
```

> **Note**&nbsp;&nbsp;If using this approach, be aware that the **More** button changes the height of the opened `CommandBar` if necessary, in order to show the labels of the `AppBarButton`s below their icons. We recommend that you move the labels to the *right* of their icons to avoid this resizing.

#### Background images and media elements

Most images and other media elements don't contain critical information at their edges, so it's safe to draw these UI elements to the edges of the screen to provide an immersive experience. The following code snippet shows an example of drawing an image to the edges of the screen:

```xml
<Image Source="\Assets\HeaderBackground.png" 
       Stretch="Uniform" 
       Height="227" 
       VerticalAlignment="Top" 
       Margin="-48,-27,-48,0"/>
```

You can of course do the same thing for media, such as videos.

#### Scrolling ends of lists and grids

It's common for lists and grids to contain more items than can fit onscreen at the same time. When this is the case, we recommend that you extend the list or grid to the edge of the screen. Horizontally scrolling lists and grids should extend to the right edge, and vertically scrolling ones should extend to the bottom.

![TV safe area grid cutoff](images/designing-for-tv/tv-safe-area-grid-cutoff.png)

While a list or grid is extended like this, it's important to keep the focus visual and its associated item inside the TV-safe area.

![Scrolling grid focus should be kept in TV-safe area](images/designing-for-tv/scrolling-grid-focus.png)

The UWP has functionality that will keep the focus visual inside the [VisibleBounds](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.applicationview.visiblebounds.aspx), but you need to add padding to ensure that the list/grid items can scroll into view of the safe area. Specifically, you add a positive margin to the [ListView](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.listview.aspx) or [GridView](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)'s [ItemsPresenter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.itemspresenter.aspx), as in the following code snippet:

```xml
<Style x:Key="TitleSafeListViewStyle" 
       TargetType="ListView">
    <Setter Property="Margin" 
            Value="0,0,0,-27"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ListView">
                    <Border BorderBrush="{TemplateBinding BorderBrush}" 
                            Background="{TemplateBinding Background}" 
                            BorderThickness="{TemplateBinding BorderThickness}">
                        <ScrollViewer x:Name="ScrollViewer"
                                      TabNavigation="{TemplateBinding TabNavigation}"
                                      HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}"
                                      HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}"
                                      IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}"
                                      VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}"
                                      VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}"
                                      IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}"
                                      IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}"
                                      IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}"
                                      ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}"
                                      IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}"
                                      BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}"
                                      AutomationProperties.AccessibilityView="Raw">
                            <ItemsPresenter Header="{TemplateBinding Header}"
                                            HeaderTemplate="{TemplateBinding HeaderTemplate}"
                                            HeaderTransitions="{TemplateBinding HeaderTransitions}"
                                            Footer="{TemplateBinding Footer}"
                                            FooterTemplate="{TemplateBinding FooterTemplate}"
                                            FooterTransitions="{TemplateBinding FooterTransitions}"
                                            Padding="{TemplateBinding Padding}" 
                                            Margin="0,27,0,27"/>
                    </ScrollViewer>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

You would put the previous code snippet in either the page or app resources, and then access it in the following way:

```xml
<Page>
    <Grid>
        <ListView Style="{StaticResource TitleSafeListViewStyle}"
                  ... />
```

> **Note**&nbsp;&nbsp;This code snippet is specifically for `ListView`s; for a `GridView` style, set the [TargetType](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.controltemplate.targettype.aspx) attribute for both the [ControlTemplate](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.controltemplate.aspx) and the [Style](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.style.aspx) to `GridView`.


### Custom visual state trigger for Xbox One <a name="custom-visual-state-trigger-for-xbox-one"></a>

To tailor your UWP app for the 10-foot experience, we recommend that you make layout changes when the app detects that it has been launched on an Xbox console. This can be done by using a custom visual state trigger, as in the following code snippet:

```xml
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
        <VisualState>
            <VisualState.StateTriggers>
                <triggers:DeviceFamilyTrigger DeviceFamily="Windows.Xbox"/>
            </VisualState.StateTriggers>
            <VisualState.Setters>
                <Setter Target="RootSplitView.Margin" 
                        Value="-48,-27"/>
                <Setter Target="RootSplitView.OpenPaneLength" 
                        Value="368"/>
                <Setter Target="RootSplitView.CompactPaneLength" 
                        Value="96"/>
                <Setter Target="NavMenuList.Margin" 
                        Value="0,75,0,27"/>
                <Setter Target="Frame.Margin" 
                        Value="0,27,48,27"/>
                <Setter Target="NavMenuList.ItemContainerStyle" 
                        Value="{StaticResource NavMenuItemContainerXboxStyle}"/>
            </VisualState.Setters>
        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

To create the trigger, add the following class to your app. This is the class that is referenced by the XAML code earlier:

```csharp
class DeviceFamilyTrigger : StateTriggerBase
{
    private string _currentDeviceFamily, _queriedDeviceFamily;

    public string DeviceFamily
    {
        get
        {
            return _queriedDeviceFamily;
        }
        
        set
        {
            _queriedDeviceFamily = value;
            _currentDeviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;
            SetActive(_queriedDeviceFamily == _currentDeviceFamily);
        }
    }
}
```

After you've added your custom trigger, your app will automatically make the layout modifications you specified in your XAML code whenever it detects that it is running on an Xbox One console.

## Colors

By default, the Universal Windows Platform doesn't do anything to alter your app's colors. That said, there are improvements that you can make to the set of colors your app uses to improve the visual experience on TV.

### Application theme

You can choose an **Application theme** (dark or light) according to what is right for your app, or you can opt out of theming. Read more about general recommendations for themes in [Color themes](../style/color.md#color-themes).

The UWP also allows apps to dynamically set the theme based on the system settings provided by the devices on which they run. 
While the UWP always respects the theme settings specified by the user, each device also provides an appropriate default theme. 
Because of the nature of Xbox One, which is expected to have more *media* experiences than *productivity* experiences, it defaults to a dark system theme. 
If your app's theme is based on the system settings, expect it to default to dark on Xbox One.

### Accent color

The UWP provides a convenient way to expose the **accent color** that the user has selected from their system settings.

On Xbox One, the user is able to select a user color, just as they can select an accent color on a PC. 
As long as your app calls these accent colors through brushes or color resources, the color that the user selected in the system settings will be used. Note that accent colors on Xbox One are per user, not per system.

Please also note that the set of user colors on Xbox One is not the same as that on PCs, phones, and other devices. 
This is partly due to the fact that these colors are hand-picked to make for the best 10-foot experience on Xbox One, following the same methodologies and strategies explained in this article.

As long as your app uses a brush resource such as **SystemControlForegroundAccentBrush**, or a color resource (**SystemAccentColor**), or instead calls accent colors directly through the [UIColorType.Accent*](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.uicolortype.aspx) API, those colors are replaced with accent colors appropriate for TV. High contrast brush colors are also pulled in from the system the same way as on a PC and phone, but with TV-appropriate colors.

To learn more about accent color in general, see [Accent color](../style/color.md#accent-color).

### Color variance among TVs

When designing for TV, note that colors display quite differently depending on the TV on which they are rendered. Don't assume colors will look exactly as they do on your monitor. If your app relies on subtle differences in color to differentiate parts of the UI, colors could blend together and users could get confused. Try to use colors that are different enough that users will be able to clearly differentiate them, regardless of the TV they are using.

### TV-safe colors

A color's RGB values represent intensities for red, green, and blue. TVs don't handle extreme intensities very well; therefore, you should avoid using these colors when designing for the 10-foot experience. They can produce an odd banded effect, or appear washed out on certain TVs. Additionally, high-intensity colors may cause blooming (nearby pixels start drawing the same colors). 

While there are different schools of thought in what are considered TV-safe colors, colors within the RGB values of 16-235 (or 10-EB in hexadecimal) are generally safe to use for TV.

![TV-safe color range](images/designing-for-tv/tv-safe-colors.png)

### Fixing TV-unsafe colors

Fixing TV-unsafe colors individually by adjusting their RGB values to be within the TV-safe range is typically referred to as **color clamping**. This method may be appropriate for an app that doesn't use a rich color palette. However, fixing colors this way may cause colors to collide with each other, which doesn't provide for the best 10-foot experience.

Instead, we recommend that you use **scaling** after you have ensured that your colors are TV-safe by using a method such as color clamping to optimize your color palette for TV. 

<!--[v-lcap] This seems to contradict what you just said in the previous sentence-->

This involves scaling all of your colors' RGB values by a certain factor to get them within the TV-safe range. 
Scaling all of your app's colors helps prevent color collision and makes for a better 10-foot experience.

![Clamping vs. scaling](images/designing-for-tv/clamping-vs-scaling.png)

### Assets

When making changes to colors, make sure to also update assets accordingly. If your app uses a color in XAML that is supposed to look the same as an asset color, but you only update the XAML code, your assets will look off-color.

### UWP color sample

[UWP color themes](../style/color.md#color-themes) are designed around the app's background being either **black** for the dark theme or **white** for the light theme. Because neither black nor white are TV-safe, these colors needed to be fixed by using *clamping*. After they were fixed, all the other colors needed to be adjusted through *scaling* to retain the necessary contrast.

<!--[v-lcap to eliot]why is the above paragraph in the past tense?-->

The following sample code provides a color theme that has been optimized for TV use:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="ApplicationPageBackgroundThemeBrush" 
                                 Color="#FF101010"/>
                <Color x:Key="SystemAltHighColor">#FF101010</Color>
                <Color x:Key="SystemAltLowColor">#33101010</Color>
                <Color x:Key="SystemAltMediumColor">#99101010</Color>
                <Color x:Key="SystemAltMediumHighColor">#CC101010</Color>
                <Color x:Key="SystemAltMediumLowColor">#66101010</Color>
                <Color x:Key="SystemBaseHighColor">#FFEBEBEB</Color>
                <Color x:Key="SystemBaseLowColor">#33EBEBEB</Color>
                <Color x:Key="SystemBaseMediumColor">#99EBEBEB</Color>
                <Color x:Key="SystemBaseMediumHighColor">#CCEBEBEB</Color>
                <Color x:Key="SystemBaseMediumLowColor">#66EBEBEB</Color>
                <Color x:Key="SystemChromeAltLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeBlackHighColor">#FF101010</Color>
                <Color x:Key="SystemChromeBlackLowColor">#33101010</Color>
                <Color x:Key="SystemChromeBlackMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeBlackMediumColor">#CC101010</Color>
                <Color x:Key="SystemChromeDisabledHighColor">#FF333333</Color>
                <Color x:Key="SystemChromeDisabledLowColor">#FF858585</Color>
                <Color x:Key="SystemChromeHighColor">#FF767676</Color>
                <Color x:Key="SystemChromeLowColor">#FF1F1F1F</Color>
                <Color x:Key="SystemChromeMediumColor">#FF262626</Color>
                <Color x:Key="SystemChromeMediumLowColor">#FF2B2B2B</Color>
                <Color x:Key="SystemChromeWhiteColor">#FFEBEBEB</Color>
                <Color x:Key="SystemListLowColor">#19EBEBEB</Color>
                <Color x:Key="SystemListMediumColor">#33EBEBEB</Color>
            </ResourceDictionary>
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="ApplicationPageBackgroundThemeBrush" 
                                 Color="#FFEBEBEB" /> 
                <Color x:Key="SystemAltHighColor">#FFEBEBEB</Color>
                <Color x:Key="SystemAltLowColor">#33EBEBEB</Color>
                <Color x:Key="SystemAltMediumColor">#99EBEBEB</Color>
                <Color x:Key="SystemAltMediumHighColor">#CCEBEBEB</Color>
                <Color x:Key="SystemAltMediumLowColor">#66EBEBEB</Color>
                <Color x:Key="SystemBaseHighColor">#FF101010</Color>
                <Color x:Key="SystemBaseLowColor">#33101010</Color>
                <Color x:Key="SystemBaseMediumColor">#99101010</Color>
                <Color x:Key="SystemBaseMediumHighColor">#CC101010</Color>
                <Color x:Key="SystemBaseMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeAltLowColor">#FF1F1F1F</Color>
                <Color x:Key="SystemChromeBlackHighColor">#FF101010</Color>
                <Color x:Key="SystemChromeBlackLowColor">#33101010</Color>
                <Color x:Key="SystemChromeBlackMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeBlackMediumColor">#CC101010</Color>
                <Color x:Key="SystemChromeDisabledHighColor">#FFCCCCCC</Color>
                <Color x:Key="SystemChromeDisabledLowColor">#FF7A7A7A</Color>
                <Color x:Key="SystemChromeHighColor">#FFB2B2B2</Color>
                <Color x:Key="SystemChromeLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeMediumColor">#FFCCCCCC</Color>
                <Color x:Key="SystemChromeMediumLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeWhiteColor">#FFEBEBEB</Color>
                <Color x:Key="SystemListLowColor">#19101010</Color>
                <Color x:Key="SystemListMediumColor">#33101010</Color>
            </ResourceDictionary> 
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

> **Note**&nbsp;&nbsp;The light theme **SystemChromeMediumLowColor** and **SystemChromeMediumLowColor** are the same color on purpose and not caused as a result of clamping. 

<!--[v-lcap] Double check that you didn't mean to say something else in the sentence above-->

> **Note**&nbsp;&nbsp;Hexadecimal colors are specified in **ARGB** (Alpha Red Green Blue).

We don't recommend using TV-safe colors on a monitor able to display the full range without clamping because the colors will look washed out. Instead, load the resource dictionary (previous sample) when your app is running on Xbox but *not* other platforms. In the `OnLaunched` method of `App.xaml.cs`, add the following check:

```csharp
if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox")
{ 
    this.Resources.MergedDictionaries.Add(new ResourceDictionary 
    { 
        Source = new Uri("ms-appx:///TenFootStylesheet.xaml") 
    }); 
}
```

This will ensure that the correct colors will display on whichever device the app is running, providing the user with a better, more aesthetically pleasing experience.

<!--### Light dismiss overlay

In order to call the user's attention to the UI elements that the user is currently manipulating with the game controller or remote control, UWP automatically adds a "smoke" layer that covers areas outside of the popup UI when the app is running on Xbox One. This requires no extra work, but is something to keep in mind when designing your UI.
-->

## Gamepad and remote control

Just like keyboard and mouse are for PC, and touch is for phone and tablet, gamepad and remote control are the main input devices for the 10-foot experience. 
This section introduces what the hardware buttons are and what they do. 
In [XY focus navigation and interaction](#xy-focus-navigation-and-interaction) and [Mouse mode](#mouse-mode), you will learn how to optimize your app when using these input devices.

The quality of gamepad and remote behavior that you get out-of-the-box depends on how well keyboard is supported in your app. A good way to ensure that your app will work well with gamepad/remote is to make sure that it works well with keyboard on PC, and then test with gamepad/remote to find weak spots in your UI.

### Hardware buttons

Throughout this document, buttons will be referred to by the names given in the following diagram.

![Gamepad and remote buttons diagram](images/designing-for-tv/hardware-buttons-gamepad-remote.png)

As you can see from the diagram, there are some buttons that are supported on gamepad that are not supported on remote control, and vice versa. While you can use buttons that are only supported on one input device to make navigating the UI faster, be aware that using them for critical interactions may create a situation where the user is unable to interact with certain parts of the UI.

The following table lists all of the hardware buttons supported by UWP apps, and which input device supports them.

| Button                    | Gamepad   | Remote control    |
|---------------------------|-----------|-------------------|
| A/Select button           | Yes       | Yes               |
| B/Back button             | Yes       | Yes               |
| Directional pad (D-pad)   | Yes       | Yes               |
| Menu button               | Yes       | Yes               |
| View button               | Yes       | Yes               |
| X and Y buttons           | Yes       | No                |
| Left stick                | Yes       | No                |
| Right stick               | Yes       | No                |
| Left and right triggers   | Yes       | No                |
| Left and right bumpers    | Yes       | No                |
| OneGuide button           | No        | Yes               |
| Volume button             | No        | Yes               |
| Channel button            | No        | Yes               |
| Media control buttons     | No        | Yes               |
| Mute button               | No        | Yes               |

### Built-in button support

The UWP automatically maps existing keyboard input behavior to gamepad and remote control input. The following table lists these built-in mappings.

| Keyboard              | Gamepad/remote                        |
|-----------------------|---------------------------------------|
| Arrow keys            | D-pad (also left stick on gamepad)    |
| Spacebar              | A/Select button                       |
| Enter                 | A/Select button                       |
| Escape                | B/Back button*                        |

\*When neither the [KeyDown](https://msdn.microsoft.com/library/windows/apps/br208941) nor [KeyUp](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.uielement.keyup.aspx) events for the B button are handled by the app, the [SystemNavigationManager.BackRequested](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.systemnavigationmanager.backrequested.aspx) event will be fired, which will result in back navigation within the app.

### Accelerator support

Accelerator buttons are buttons that can be used to speed up navigation through a UI. However, these buttons may be unique to a certain input device, so keep in mind that not all users will be able to use these functions. In fact, gamepad is currently the only input device that supports accelerator functions for UWP apps on Xbox One.

The following table lists the accelerator support built into the UWP, as well as that which you can implement on your own. Utilize these behaviors in your custom UI to provide a consistent and friendly user experience.

| Interaction   | Keyboard   | Gamepad      | Built-in for:  | Recommended for: |
|---------------|------------|--------------|----------------|------------------|
| Panning       | None       | Right stick  | None           |      [ScrollViewer](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) |
| Page up/down  | Page up/down | Left/right triggers | None | `ScrollViewer` and list/grid
| Page left/right | None | Left/right bumpers | [Pivot](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.pivot.aspx) | `ScrollViewer`
| Zoom in/out        | Ctrl +/- | Left/right triggers | `ScrollViewer` | Views that support zooming in and out

<!--[v-lcap] Had to move this table into markdown to get the links to work
<table>
    <tr>
        <th>Interaction</th>
        <th>Keyboard</th>
        <th>Gamepad</th>
        <th>Built-in for:</th>
        <th>Recommended for:</th>
    </tr>
    <tr>
        <td>Panning</td>
        <td>None</td>
        <td>Right stick</td>
        <td>None</td>
        <td>[ScrollViewer](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx)</td>
    </tr>
    <tr>
        <td>Page up/down</td>
        <td>Page up/down</td>
        <td>Left/right triggers</td>
        <td>None</td>
        <td>`ScrollViewer` and list/grid</td>
    </tr>
    <tr>
        <td>Page left/right</td>
        <td>None</td>
        <td>Left/right bumpers</td>
        <td>[Pivot](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.pivot.aspx).</td>
        <td>`ScrollViewer`</td>
    </tr>
    <tr>
        <td>Zoom in/out</td>
        <td>Ctrl +/-</td>
        <td>Left/right triggers</td>
        <td>`ScrollViewer`</td>
        <td>Views that support zooming in and out
    </tr>
</table>-->

## Mouse mode

As described in [XY focus navigation and interaction](#xy-focus-navigation-and-interaction), on Xbox One the focus is moved by using an XY navigation system, allowing the user to shift the focus from control to control by moving up, down, left, and right. 
However, some controls, such as [WebView](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.aspx) and 
[MapControl](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.maps.mapcontrol.aspx), 
require a mouse-like interaction where users can freely move the pointer inside the boundaries of the control. 
There are also some apps where it makes sense for the user to be able to move the pointer across the entire page, having an experience with gamepad/remote similar to what users can find on a PC with a mouse.

For these scenarios, you should request a pointer (mouse mode) for the entire page, or on a control inside a page. 
For example, your app could have a page that has a `WebView` control that uses mouse mode only while inside the control, and XY focus navigation everywhere else. 
To request a pointer, you can specify whether you want it **when a control or page is engaged** or **when a page has focus**.

> **Note**&nbsp;&nbsp;Requesting a pointer when a control gets focus is not supported.

The following diagram shows the button mappings for gamepad/remote in mouse mode.

![Button mappings for gamepad/remote in mouse mode](images/designing-for-tv/mouse-mode.png)

> **Note**&nbsp;&nbsp;Mouse mode is only supported on Xbox One with gamepad/remote. On other device families and input types it is silently ignored.

Use the `RequiresPointer` property on a control or page to activate mouse mode on it. `RequiresPointer` has three possible values: `Never` (the default value), `WhenEngaged`, and `WhenFocused`.

> **Note**&nbsp;&nbsp;`RequiresPointer` is a new API and not yet documented. 

<!--TODO: Link to doc-->

### Activating mouse mode on a control

When the user engages a control with `RequiresPointer="WhenEngaged"`, mouse mode is activated on the control until the user disengages it. The following code snippet demonstrates a simple `MapControl` that activates mouse mode when engaged:

```xml
<Page>
    <Grid>
        <MapControl IsEngagementRequired="true" 
                    RequiresPointer="WhenEngaged"/>
    </Grid>
</Page> 
```

> **Note**&nbsp;&nbsp;If a control activates mouse mode when engaged, it must also require engagement with `IsEngagementRequired="true"`; otherwise, mouse mode will never be activated.

When a control is in mouse mode, its nested controls will be in mouse mode as well. The requested mode of its children will be ignored&mdash;it's impossible for a parent to be in mouse mode but a child not to be.

Additionally, the requested mode of a control is only inspected when it gets focus, so the mode won't change dynamically while it has focus.

### Activating mouse mode on a page

When a page has the property `RequiresPointer="WhenFocused"`, mouse mode will be activated for the whole page when it gets focus. The following code snippet demonstrates giving a page this property:

```xml
<Page RequiresPointer="WhenFocused">
    ...
</Page> 
```

> **Note**&nbsp;&nbsp;The `WhenFocused` value is only supported on [Page](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.page.aspx) objects. If you try to set this value on a control, an exception will be thrown.

## Focus visual

The focus visual is the border around the UI element that currently has focus. This helps orient the user so that they can easily navigate your UI without getting lost.

With a visual update and numerous customization options added to focus visual, developers can trust that a single focus visual will work well on PCs and Xbox One, as well as on any other Windows 10 devices that support keyboard and/or gamepad/remote.

While the same focus visual can be used across different platforms, the context in which the user encounters it is slightly different for the 10-foot experience. You should assume that the user is not paying full attention to the entire TV screen, and therefore it is important that the currently focused element is clearly visible to the user at all times to avoid the frustration of searching for the visual.

It is also important to keep in mind that the focus visual is displayed by default when using a gamepad or remote control, but *not* a keyboard. Thus, even if you don't implement it, it will appear when you run your app on Xbox One.

### Initial focus visual placement

When launching an app or navigating to a page, place the focus on a UI element that makes sense as the first element on which the user would take action. For example, a photo app may place focus on the first item in the gallery, and a music app navigated to a detailed view of a song might place focus on the play button for ease of playing music.

Try to put initial focus in the top left region of your app (or top right for a right-to-left flow). Most users tend to focus on that corner first because that's where app content flow generally begins.

### Making focus clearly visible

One focus visual should always be visible on the screen so that the user can pick up where they left off without searching for the focus. Similarly, there should be a focusable item onscreen at all times&mdash;for example, don't use pop-ups with only text and no focusable elements.

### Light dismiss overlay

To call the user's attention to the UI elements that the user is currently manipulating with the game controller or remote control, the UWP automatically adds a "smoke" layer that covers areas outside of the popup UI when the app is running on Xbox One. This requires no extra work, but is something to keep in mind when designing your UI.

## Focus engagement

Focus engagement is intended to make it easier to use a gamepad or remote to interact with an app. 

> **Note**&nbsp;&nbsp;Setting focus engagement does not impact keyboard or other input devices.

When the property `IsFocusEngagementEnabled` on a [FrameworkElement](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.aspx) object is set to `True`, it marks the control as requiring focus engagement. This means that the user must press the **A/Select** button to "engage" the control and interact with it. When they are finished, they can press the **B/Back** button to disengage the control and navigate out of it.

> **Note**&nbsp;&nbsp;`IsFocusEngagementEnabled` is a new API and not yet documented.

### Focus trapping

Focus trapping is what happens when a user attempts to navigate an app's UI but becomes "trapped" within a control, making it difficult or even impossible to move outside of that control.

The following example shows UI that creates focus trapping.

![Buttons to the left and right of a horizontal slider](images/designing-for-tv/focus-engagement-focus-trapping.png)

If the user wants to navigate from the left button to the right button, it would be logical to assume that all they'd have to do is press right on the D-pad/left stick twice. 
However, if the [Slider](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.slider.aspx) doesn't require engagement, the following behavior would occur: when the user presses right the first time, focus would shift to the `Slider`, and when they press right again, the `Slider`'s handle would move to the right. The user would keep moving the handle to the right and wouldn't be able to get to the button.

There are several approaches to getting around this issue. One is to design a different layout, similar to the real estate app example in [XY focus navigation and interaction](#xy-focus-navigation-and-interaction) where we relocated the **Previous** and **Next** buttons above the `ListView`. Stacking the controls vertically instead of horizontally as in the following image would solve the problem.

![Buttons above and below a horizontal slider](images/designing-for-tv/focus-engagement-focus-trapping-2.png)

Now the user can navigate to each of the controls by pressing up and down on the D-pad/left stick, and when the `Slider` has focus, they can press left and right to move the `Slider` handle, as expected.

Another approach to solving this problem is to require engagement on the `Slider`. If you set `IsFocusEngagementEnabled="True"`, this will result in the following behavior.

![Requiring focus engagement on slider so user can navigate to button on the right](images/designing-for-tv/focus-engagement-slider.png)

When the `Slider` requires focus engagement, the user can get to the button on the right simply by pressing right on the D-pad/left stick twice. This solution is great because it requires no UI adjustment and produces the expected behavior.

### Items controls

Aside from the [Slider](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.slider.aspx) control, there are other controls which you may want to require engagement, such as:

- [ListBox](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)
- [ListView](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.listview.aspx)
- [GridView](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)
- [FlipView](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.controls.flipview)

Unlike the `Slider` control, these controls don't trap focus within themselves; however, they can cause usability issues when they contain large amounts of data. The following is an example of a `ListView` that contains a large amount of data.

![ListView with large amount of data and buttons above and below](images/designing-for-tv/focus-engagement-list-and-grid-controls.png)

Similar to the `Slider` example, let's try to navigate from the button at the top to the button at the bottom with a gamepad/remote. 
Starting with focus on the top button, pressing down on the D-pad/stick will place the focus on the first item in the `ListView` ("Item 1"). 
When the user presses down again, the next item in the list gets focus, not the button on the bottom. 
To get to the button, the user must navigate through every item in the `ListView` first. 
If the `ListView` contains a large amount of data, this could be inconvenient and not an optimal user experience.

To solve this problem, set the property `IsFocusEngagementEnabled="True"` on the `ListView` to require engagement on it. 
This will allow the user to quickly skip over the `ListView` by simply pressing down. However, 
they will not be able to scroll through the list or choose an item from it unless they engage it by pressing the **A/Select** button when it has focus, and then pressing the **B/Back** button to disengage.

![ListView with engagement required](images/designing-for-tv/focus-engagement-list-and-grid-controls-2.png)

#### ScrollViewer

Slightly different from these controls is the [ScrollViewer](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx), 
which has its own quirks to consider. If you have a `ScrollViewer` with focusable content, by default navigating to the `ScrollViewer` will allow you to move through its focusable elements. Like in a `ListView`, you must scroll through each item to navigate outside of the `ScrollViewer`. 

If the `ScrollViewer` has *no* focusable content&mdash;for example, if it only contains text&mdash;you can set `IsFocusEngagementEnabled="True"` so the user can engage the `ScrollViewer` by using the **A/Select** button. After they have engaged, they can scroll through the text by using the **D-pad/left stick**, and then press the **B/Back** button to disengage when they're finished.

Another approach would be to set `IsTabStop="True"` on the `ScrollViewer` so that the user doesn't have to engage the control&mdash;they can simply place 
focus on it and then scroll by using the **D-pad/left stick** when there are no focusable elements within the `ScrollViewer`.

### Focus engagement defaults

Some controls cause focus trapping commonly enough to warrant their default settings to require focus engagement, while others have focus engagement turned off by default but can benefit from turning it on. The following table lists these controls and their default focus engagement behaviors.

| Control               | Focus engagement default  |
|-----------------------|---------------------------|
| CalendarDatePicker    | On                        |
| FlipView              | Off                       |
| GridView              | Off                       |
| ListBox               | Off                       |
| ListView              | Off                       |
| ScrollViewer          | Off                       |
| SemanticZoom          | Off                       |
| Slider                | On                        |

All other UWP controls will result in no behavioral or visual changes when `IsFocusEngagementEnabled="True"`.

## XY focus navigation and interaction

If your app supports proper focus navigation for keyboard, this will translate well to gamepad and remote control. 
Navigation with the arrow keys is mapped to the **D-pad** (as well as the **left stick** on gamepad), and interaction with UI elements is mapped to the **Enter/Select** key 
(see [Gamepad and remote control](#gamepad-and-remote-control)). For keyboard design guidance, see [Keyboard interactions](keyboard-interactions.md).

If keyboard support is implemented properly, your app will work reasonably well; however, there may be some extra work required to support every scenario. Think about your app's specific needs to provide the best user experience possible.

<!--### Focus placement

The focus visual should be initially placed on the UI element that makes sense as the first element on which the user would take action. For more information, see [Focus visual](#focus-visual).
-->

### Inaccessible UI

Because XY focus navigation limits the user to moving up, down, left, and right, you may end up with scenarios where parts of the UI are inaccessible. 
The following diagram illustrates an example of the kind of UI layout that XY focus navigation doesn't support. 
Note that the element in the middle is not accessible by using gamepad/remote because the vertical and horizontal navigation will be prioritized and the middle element will never be high enough priority to get focus.

![Elements in four corners with inaccessible element in middle](images/designing-for-tv/2d-navigation-best-practices-ui-layout-to-avoid.png)

If for some reason rearranging the UI is not possible, use one of the techniques discussed in the next section to override the default focus behavior.

### Overriding the default navigation <a name="overriding-the-default-navigation"></a>

While the UWP tries to ensure that D-pad/left stick navigation makes sense to the user, it cannot guarantee behavior that is optimized for your app's intentions. 
The best way to ensure that navigation is optimized for your app is to test it with a gamepad and confirm that every UI element can be accessed by the user in a manner that makes sense for your app's scenarios. In case your app's scenarios call for a behavior not achieved through the XY focus navigation provided, consider following the recommendations in the following sections and/or overriding the behavior to place the focus on a logical item.

The following code snippet shows how you might override the XY focus navigation behavior:

```xml
<StackPanel>
    <Button x:Name="MyBtnLeft" 
            Content="Search" />
    <Button x:Name="MyBtnRight" 
            Content="Delete"/>
    <Button x:Name="MyBtnTop" 
            Content="Update" />
    <Button x:Name="MyBtnDown" 
            Content="Undo" />
    <Button Content="Home"  
            XYFocusLeft="{x:Bind MyBtnLeft}" 
            XYFocusRight="{x:Bind MyBtnRight}"
            XYFocusDown="{x:Bind MyBtnDown}"
            XYFocusUp="{x:Bind MyBtnTop}" />
</StackPanel>
```

In this case, when focus is on the `Home` button and the user navigates to the left, focus will move to the `MyBtnLeft` button; if the user navigates to the right, focus will move to the `MyBtnRight` button; and so on.

To prevent the focus from moving from a control in a certain direction, use the `XYFocus*` property to point it at the same control:

```xml
<Button Name="HomeButton"  
        Content="Home"  
        XYFocusLeft ="{x:Bind HomeButton}" />
```

### Path of least clicks <a name="path-of-least-clicks"></a>

Try to allow the user to perform the most common tasks in the least number of clicks. In the following example, the [TextBlock](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) is placed between the **Play** button (which initially gets focus) and a commonly used element, so that an unnecessary element is placed in between priority tasks.

![Navigation best practices provide path with least clicks](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks.png)

In the following example, the [TextBlock](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) is placed above the **Play** button instead. 
Simply rearranging the UI so that unnecessary elements are not placed in between priority tasks will greatly improve your app's usability.

![TextBlock moved above Play button so that it is no longer between priority tasks](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks-2.png)

<!--### Nested UI elements

When UI elements are nested inside other UI elements, the default behavior is that the user will not be able to access the nested UI elements.

One of the main scenarios is when there is UI that displays when the user hovers over a nested UI element with the mouse, but does not display otherwise.

![UI elements displaying when mouse hovers over them](images/designing-for-tv/2d-navigation-best-practices-ui-elements-display-on-mouse-hover.png)

The recommended way to handle this scenario for gamepad/remote input is to place these UI elements in a `ContextFlyout` that displays when the user presses the **Menu** button.
-->
<!--#### UI elements that always display

The second scenario is when there is UI that always displays. **TODO: Fill in this section when I get more info**
-->

### CommandBar and ContextFlyout

When using a [CommandBar](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx), keep in mind the issue of scrolling through a list as mentioned in [Problem: UI elements located after long scrolling list/grid](#problem-ui-elements-located-after-long-scrolling-list-grid). The following image shows a UI layout with the `CommandBar` on the bottom of a list/grid. The user would need to scroll all the way down through the list/grid to reach the `CommandBar`.

![CommandBar at bottom of list/grid](images/designing-for-tv/2d-navigation-best-practices-commandbar-and-contextflyout.png)

What if you put the `CommandBar` *above* the list/grid? While a user who scrolled down the list/grid would have to scroll back up to reach the `CommandBar`, it is slightly less navigation than the previous configuration. Note that this is assuming that your app's initial focus is placed next to or above the `CommandBar`; this approach won't work as well if the initial focus is below the list/grid. If these `CommandBar` items are global action items that don't have to be accessed very often (such as a **Sync** button), it may be acceptable to have them above the list/grid.

If your app has a `CommandBar` whose items need to be readily accessible by users, you may want to consider placing these items inside a `ContextFlyout` and removing them from the `CommandBar`. 

<!--The `ContextFlyout` can be accessed by pressing the **Menu** button, providing a very convenient way for the user to access these actions quickly.-->

While you can't stack a `CommandBar`'s items vertically, placing them against the scroll direction (for example, to the left or right of a vertically scrolling list, or the top or bottom of a horizontally scrolling list) is another option you may want to consider if it works well for your UI layout.

<!--### Navigation pane
A navigation pane (also known as a *hamburger menu*) is a navigation control commonly used in UWP apps. Typically it is a pane with several options to choose from in a list-style menu that will take the user to different pages. Generally this pane starts out collapsed to save space, and the user can open it by clicking on a button.
While nav panes are very accessible with mouse and touch, gamepad/remote makes them less accessible since the user has to navigate to a button to open the pane. Therefore, a good practice is to have the **Menu** button open the nav pane, as well as allow the user to open it by navigating all the way to the left of the page. This will provide the user with very easy access to the contents of the pane. See [Nav panes](https://msdn.microsoft.com/en-us/windows/uwp/controls-and-patterns/nav-pane). TO DO: Is this the right link?--> 
<!--TODO: Image of nav pane-->

### UI layout challenges

Some UI layouts are more challenging due to the nature of XY focus navigation, and should be evaluated on a case-by-case basis. While there is no single "right" way, and which solution you choose is up to your app's specific needs, there are some techniques that you can employ to make a great TV experience.

To understand this better, let's look at an imaginary app that illustrates some of these issues and techniques to overcome them.

> **Note**&nbsp;&nbsp;This fake app is meant to illustrate UI problems and potential solutions to them, and is not intended to show the best user experience for your particular app.

The following is an imaginary real estate app which shows a list of houses available for sale, a map, a description of a property, and other information. This app poses three challenges that you can overcome by using the following techniques:

- [UI rearrange](#ui-rearrange)
- [Focus engagement](#engagement)
- [Mouse mode](#mouse-mode)

![Fake real estate app](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app.png)

#### Problem: UI elements located after long scrolling list/grid <a name="problem-ui-elements-located-after-long-scrolling-list-grid"></a>

The [ListView](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.listview.aspx) of properties shown in the following image is a very long scrolling list. If [engagement](#focus-engagement) is *not* required on the `ListView`, when the user navigates to the list, focus will be placed on the first item in the list. For the user to reach the **Previous** or **Next** button, they must go through all the items in the list. In cases like this where requiring the user to traverse the entire list is painful&mdash;that is, when the list is not short enough for this experience to be acceptable&mdash;you may want to consider other options.

![Real estate app: list with 50 items takes 51 clicks to reach buttons below](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app-list.png)

#### Solutions

##### UI rearrange <a name="ui-rearrange"></a>

Unless your initial focus is placed at the bottom of the page, UI elements placed above a long scrolling list are typically more easily accessible than if placed below. 
If this new layout works for other devices, changing the layout for all device families instead of doing special UI changes just for Xbox One might be a less costly approach. 
Additionally, placing UI elements against the scrolling direction (that is, horizontally to a vertically scrolling list, or vertically to a horizontally scrolling list) will make for even better accessibility.

![Real estate app: place buttons above long scrolling list](images/designing-for-tv/2d-focus-navigation-and-interaction-ui-rearrange.png)

##### Focus engagement <a name="engagement"></a>

When engagement is *required*, the entire `ListView` becomes a single focus target. The user will be able to bypass the contents of the list to get to the next focusable element. Read more about what controls support engagement and how to use them in [Focus engagement](#focus-engagement).

![Real estate app: set engagement to required so that it only takes 1 click to reach Previous/Next buttons](images/designing-for-tv/2d-focus-navigation-and-interaction-engagement.png)

#### Problem: ScrollViewer without any focusable elements

Because XY focus navigation relies on navigating to one focusable UI element at a time, 
a [ScrollViewer](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) that doesn't contain any focusable elements (such as one with only text, as in this example) may cause a scenario where the user isn't able to view all of the content in the `ScrollViewer`. 
For solutions to this and other related scenarios, see [Focus engagement](#focus-engagement).

![Real estate app: ScrollViewer with only text](images/designing-for-tv/2d-focus-navigation-and-interaction-scrollviewer.png)

#### Problem: Free-scrolling UI

When your app requires a freely scrolling UI, such as a drawing surface or, in this example, a map, XY focus navigation simply doesn't work. 
In such cases, you can turn on [mouse mode](#mouse-mode) to allow the user to navigate freely inside a UI element.

![Map UI element using mouse mode](images/designing-for-tv/map-mouse-mode.png)

<!--## 2D navigation best practices

Since 2D navigation only lets the user navigate up, down, left, and right, but not diagonally, certain UI layouts work better than others. This section describes some common issues related to navigation and their recommended solutions. Please note that there is no single "right" way to solve these problems, and always think about how to solve them for your app's specific scenarios.

### UI layouts to avoid

The following diagram illustrates an example of the kind of UI layout that 2D navigation doesn't support. Note that the element in the middle is not accessible using gamepad/remote because the vertical and horizontal navigation will be prioritized and the middle element will never be high enough priority to get focus.

![Elements in four corners with inaccessible element in middle](images/designing-for-tv/2d-navigation-best-practices-ui-layout-to-avoid.png)

If for some reason rearranging the UI is not possible, use one of the techniques discussed in [Overriding the default navigation](#overriding-the-default-navigation) to override the default focus behavior.

### CommandBar and ContextFlyout

When using a [CommandBar](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx), keep in mind the issue of scrolling through a list as mentioned in [Problem: UI elements located after long scrolling list/grid](#problem-ui-elements-located-after-long-scrolling-list-grid). The following image shows a UI layout with the `CommandBar` on the bottom of a list/grid. The user would need to scroll all the way down through the list/grid to reach the `CommandBar`.

![CommandBar at bottom of list/grid](images/designing-for-tv/2d-navigation-best-practices-commandbar-and-contextflyout.png)

Now compare this to the following configuration, which puts the `CommandBar` *above* the list/grid. While a user who scrolled down the list/grid would have to scroll back up to reach the `CommandBar`, it is slightly less navigation than the previous configuration. Note that this is assuming that your app's initial focus is placed next to or above the `CommandBar`; this approach won't work as well if the initial focus is below the list/grid. If these `CommandBar` items are global action items that don't have to be accessed very often (such as a **Sync** button), it may be acceptable to have them above the list/grid as in this example.

![CommandBar above list/grid](images/designing-for-tv/2d-navigation-best-practices-commandbar-and-contextflyout-2.png)

If your app has a `CommandBar` whose items need to be readily accessible by users, you may want to consider placing these items inside a `ContextFlyout` and removing them from the `CommandBar`. The `ContextFlyout` can be accessed by pressing the **Menu** button, providing a very convenient way for the user to access these actions quickly.

While you can't stack a `CommandBar`'s items vertically, placing them against the scroll direction (for example, to the left or right of a vertically scrolling list, or the top or bottom of a horizontally scrolling list) is another option you may want to consider if it works well for your UI layout.

### Path of least clicks <a name="path-of-least-clicks"></a>

Try to allow the user to perform the most common tasks in the least number of clicks. In the following example, there is a [TextBlock](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) between the **Play** button and a commonly used element, adding an extra click to get from the initially focused element to the commonly used element.

![TextBlock adds extra click to get to commonly used element](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks.png)

Simply rearranging the UI so that unnecessary elements are not placed in between priority tasks will greatly improve your app's usability.

![TextBlock moved above Play button so that it is no longer between priority tasks](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks-2.png)

### Nested UI elements

When UI elements are nested inside other UI elements, the default behavior is that the user will not be able to access the nested UI elements. There are two main scenarios involving nested UI, and the solutions for them are slightly different.

#### UI elements that display on mouse hover

The first scenario is when there is UI that displays when the user hovers over an element with the mouse, but does not display otherwise.

![UI elements displaying when mouse hovers over them](images/designing-for-tv/2d-navigation-best-practices-ui-elements-display-on-mouse-hover.png)

The recommended way to handle this scenario for gamepad/remote input is to place these UI elements in a `ContextFlyout` that displays when the user presses the **Menu** button.

#### UI elements that always display

The second scenario is when there is UI that always displays. **TODO: Fill in this section when I get more info**

### Navigation pane

A navigation pane (also known as a *hamburger menu*) is a navigation control commonly used in UWP apps. Typically it is a pane with several options to choose from in a list-style menu that will take the user to different pages. Generally this pane starts out collapsed to save space, and the user can open it by clicking on a button.

While nav panes are very accessible with mouse and touch, gamepad/remote makes them less accessible since the user has to navigate to a button to open the pane. Therefore, a good practice is to have the **Menu** button open the nav pane, as well as allow the user to open it by navigating all the way to the left of the page. This will provide the user with very easy access to the contents of the pane. See [Nav panes](https://msdn.microsoft.com/en-us/windows/uwp/controls-and-patterns/nav-pane) TODO: Is this the right link? for more information.

TODO: Image of nav pane
-->

## Guidelines for UI controls

The Universal Windows Platform provides many functionalities that improve the user experience on all devices, some of which particularly benefit the 10-foot experience. The following list describes examples of such improvements you can make to your app's UI.

### Pivot control

The [Pivot](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.pivot.aspx) control has properties you can set that make it so headers won't wrap around the screen like they do on phone and tablet. This is a better experience for large-screen displays such as TV, because header wrapping can be distracting to users. For more information, see [Tabs and pivots](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/tabs-pivot).

### Navigation pane

The UWP allows for a consistent look and feel across all devices. For more information about how nav panes behave in different screen sizes as well as best practices for gamepad/remote navigation, see [Nav panes](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/nav-pane).

### CommandBar labels

The [CommandBar](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) control has a property that causes the labels next to icons to always be displayed. This works well for the 10-foot experience because it minimizes the number of clicks for the user to see what the buttons do. This is also a great model for other device types to follow.

### Tooltip

The [Tooltip](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.tooltip.aspx) control was introduced as a way to provide more information in the UI when the user hovers the mouse over, or taps and holds their figure on, an element. For gamepad and remote, `Tooltip` appears after a brief moment when the element gets focus, stays onscreen for a short time, and then disappears. This behavior could be distracting if too many `Tooltip`s are used. Try to avoid using Tooltip when designing for TV.

### Button styles

While the standard UWP buttons work well on TV, some visual styles of buttons call attention to the UI better, which you may want to consider for all platforms, particularly in the 10-foot experience, which benefits from clearly communicating where the focus is located. To read more about these styles, see [Buttons](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/buttons).

<!--### Sort and filter lists and grids

The visual style for sorting and filtering list and grid items on UWP has been updated for 10-foot scenarios. Read more about how to use this UI functionality [here](TODO: Add link).
-->

### Nested UI elements

When UI elements are nested inside other UI elements, the default behavior is that the user will not be able to access the nested UI elements.

One of the main scenarios is when there is UI that displays when the user hovers over a nested UI element with the mouse, but it does not display otherwise.

![UI elements displaying when mouse hovers over them](images/designing-for-tv/2d-navigation-best-practices-ui-elements-display-on-mouse-hover.png)

The recommended way to handle this scenario for gamepad/remote input is to place these UI elements in a `ContextFlyout`.

<!--[v-lcap] This doc just ends abruptly. I recommended adding a short summary as well as links to related topics, or at least to the parent topic in this set or the next level up-->

<!--### Drag and drop

TODO: Are we including this?
-->


<!--HONumber=Mar16_HO5-->


