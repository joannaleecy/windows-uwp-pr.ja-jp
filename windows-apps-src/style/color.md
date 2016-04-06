---
Description: Color provides intuitive wayfinding through an app's various levels of information and serves as a crucial tool for reinforcing the interaction model.
title: Color
ms.assetid: 3ba7176f-ac47-498c-80ed-4448edade8ad
label: Color
template: detail.hbs
extraBodyClass: style-color
brief: Color provides intuitive wayfinding through an app's various levels of information and serves as a crucial tool for reinforcing the interaction model.<br /><br />In Windows, color is also personal. Users can choose a color and a light or dark theme to be reflected throughout their experience.
---

# Color for UWP apps
Color provides intuitive wayfinding through an app's various levels of information and serves as a crucial tool for reinforcing the interaction model.

## Accent color

The user can pick a single color called the accent. They have their choice from a curated set of 48 color swatches.


<!-- Alternate version for the dev center. Need to add hex values. -->
<figure>
![Accent colors](images/accentcolorswatch.png)
<figcaption>As a rule of thumb, when the original accent color is used as a background, always put white text overtop.</figcaption>
</figure>

When users choose an accent color, it appears as part of their system theme. The areas affected are Start, Taskbar, window chrome, selected interaction states and hyperlinks within [common controls](https://dev.windows.com/design/controls-patterns). Each app can further incorporate the accent color through their typography, backgrounds, and interactions—or override it to preserve their specific branding.

## Color selection

Once an accent color is selected, light and dark shades of the accent color are created based on HCL values of color luminosity. Apps can use shade variations to create visual hierarchy and to provide an indication of interaction.

![A single accent color with its 6 shades](images/shades.png)

<aside class="aside-dev">
    <div class="aside-dev-title">
    </div>
    <div class="aside-dev-content">
            In XAML, the accent color is exposed as a [theme resource](https://msdn.microsoft.com/en-us/library/windows/apps/Mt187274.aspx) named `SystemAccentColor`. It's also available programmatically from [UISettings.GetColorValue](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.uisettings.getcolorvalue.aspx). You can programmatically access the different shades from [UISettings.GetColorValue](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.uisettings.getcolorvalue.aspx), see the [UIColorType](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.uicolortype.aspx) enum.
    </div>
</aside>

## Color themes

The user may also choose between a light or dark theme for the system (on phone, but tablet and desktop don’t yet have that option—they can provide an in-app setting). Some apps choose to change their theme based on the user’s preference, while others opt out.

Apps using light theme are for scenarios involving productivity apps. Examples would be the suite of apps available with Microsoft Office. Light theme affords the ease of reading long lengths of text in conjunction with prolonged periods of time-at-task.

Dark theme allows more visible contrast of content for apps that are media centric or scenarios where users are presented with an abundance of videos or imagery. In these scenarios, reading is not necessarily the primary task, though a movie watching experience might be, and shown under low-light ambient conditions.

If your app doesn’t quite fit either of these descriptions, consider following the system theme to let the user decide what's right for them.

To make designing for themes easier, Windows provides an additional color palette that automatically adapts to the theme.


<!-- OP version -->
### Light theme
#### Base
![The base light theme](images/themes-light-base.png)
#### Alt
![The alt light theme](images/themes-light-alt.png)
#### List
![The list light theme](images/themes-light-list.png)
#### Chrome
![The chrome light theme](images/themes-light-chrome.png)
### Dark theme
#### Base
![The base dark theme](images/themes-dark-base.png)
#### Alt
![The alt dark theme](images/themes-dark-alt.png)
#### List
![The list dark theme](images/themes-dark-list.png)
#### Chrome
![The chrome dark theme](images/themes-dark-chrome.png)


<aside class="aside-dev">
    <div class="aside-dev-title">
    </div>
    <div class="aside-dev-content">
            Each color is available as a XAML [theme resource](https://msdn.microsoft.com/en-us/library/windows/apps/Mt187274.aspx#the_xaml_color_ramp_and_theme-dependent_brushes) that follows the `System*Color` naming convention (ex: `SystemChromeHighColor`). You can control your app's theme through either [Application.RequestedTheme](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.application.requestedtheme.aspx) or [FrameworkElement.RequestedTheme](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.requestedtheme.aspx).
    </div>
</aside>

## Accessibility

Our palette is optimized for screen usage. We recommend maintaining a minimal contrast ratio for text of 4.5:1 for optimal readability.


<!--HONumber=Mar16_HO5-->


