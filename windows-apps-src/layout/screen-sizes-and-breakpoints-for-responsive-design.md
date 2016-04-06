---
title: 'Screen sizes and break points for responsive design'
description: .
ms.assetid: BF42E810-CDC8-47D2-9C30-BAA19DCBE2DA
label: Screen sizes and break points
template: detail.hbs
---

#  Screen sizes and break points for responsive design


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]



The number of device targets and screen sizes across the Windows 10 ecosystem is too great to worry about optimizing your UI for each one. Instead, we recommended designing for a few key widths (also called "breakpoints"): 360, 640, 1024 and 1366 epx.

**Tip**  When designing for specific breakpoints, design for the amount of screen space available to your app (the app's window). When the app is running full-screen, the app window is the same size as the screen, but in other cases, it's smaller.
 

This table describes the different size classes and provides general recommendations for tailoring for those size classes.

![responsive design breakpoints](images/rsp-design/rspd-breakpoints.png)

<table>
<colgroup>
<col width="25%" />
<col width="25%" />
<col width="25%" />
<col width="25%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Size class</th>
<th align="left">small</th>
<th align="left">medium</th>
<th align="left">large</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">Typical screen size (diagonal)</td>
<td align="left">4&quot; to 6&quot;</td>
<td align="left">7&quot; to 12&quot;, or TVs</td>
<td align="left">13&quot; and larger</td>
</tr>
<tr class="even">
<td align="left">Typical devices</td>
<td align="left">Phones</td>
<td align="left">Phablets, tablets, TVs</td>
<td align="left">PCs, laptops, Surface Hubs</td>
</tr>
<tr class="odd">
<td align="left">Common window sizes in effective pixels</td>
<td align="left">320x569, 360x640, 480x854</td>
<td align="left">960x540, 1024x640</td>
<td align="left">1366x768, 1920x1080</td>
</tr>
<tr class="even">
<td align="left">Window width breakpoints in effective pixels</td>
<td align="left">640px or less</td>
<td align="left">641px to 1007px</td>
<td align="left">1008px or greater</td>
</tr>
<tr class="odd">
<td align="left" valign="top">General recommendations</td>
<td align="left" valign="top"><ul>
<li>Center tab elements.</li>
<li>Set left and right window margins to 12px to create a visual separation between the left and right edges of the app window.</li>
<li>Dock [app bars](../controls-and-patterns/app-bars.md) to the bottom of the window for improved reachability</li>
<li>Use one column/region at a time</li>
<li>Use an icon to represent search (don't show a search box).</li>
<li>Put the [navigation pane](../controls-and-patterns/nav-pane.md) in overlay mode to conserve screen space.</li>
<li>If you're using the [master details pattern](../controls-and-patterns/master-details.md), use the stacked presentation mode to save screen space.</li>
</ul></td>
<td align="left" valign="top"><ul>
<li>Make tab elements left-aligned.</li>
<li>Set left and right window margins to 24px to create a visual separation between the left and right edges of the app window.</li>
<li>Put command elements like [app bars](../controls-and-patterns/app-bars.md) at the top of the app window.</li>
<li>Up to two columns/regions</li>
<li>Show the search box.</li>
<li>Put the [navigation pane](../controls-and-patterns/nav-pane.md) into sliver mode so a narrow strip of icons always shows.</li>

</ul></td>
<td align="left" valign="top"><ul>
<li>Make tab elements left-aligned.</li>
<li>Set left and right window margins to 24px to create a visual separation between the left and right edges of the app window.</li>
<li>Put command elements like [app bars](../controls-and-patterns/app-bars.md) at the top of the app window.</li>
<li>Up to three columns/regions</li>
<li>Show the search box.</li>
<li>Put the [navigation pane](../controls-and-patterns/nav-pane.md) into docked mode so that it always shows.</li>
</ul></td>
</tr>
</tbody>
</table>

With [**Continuum for Phones**](http://go.microsoft.com/fwlink/p/?LinkID=699431), a new experience for compatible Windows 10 mobile devices, users can connect their phones to a monitor, mouse and keyboard to make their phones work like laptops. Keep this new capability in mind when designing for specific breakpoints - a mobile phone will not always stay in the small size class.
 


<!--HONumber=Mar16_HO4-->


