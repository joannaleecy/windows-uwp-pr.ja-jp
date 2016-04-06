---
Description: Windows 10 and new developer tools provide the tools, features, and experiences powered by the new Universal Windows Platform (UWP).
title: What is new for developers in Windows 10, RTM - July 2015
---

# What's new for developers in Windows 10, RTM: July 2015


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Windows 10 and new developer tools provide the tools, features, and experiences powered by the new Universal Windows Platform (UWP). After [installing the tools and SDK](https://dev.windows.com/downloads) on Windows 10, you’re ready to either [create a new Universal Windows app](https://msdn.microsoft.com/library/windows/apps/bg124288) or explore how you can use your [existing app code on Windows](https://msdn.microsoft.com/library/windows/apps/mt238321).

Here's a feature-by-feature look at what's new for you in Windows 10, RTM.

## Adaptive layouts


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Multiple Views for tailored content</td>
<td align="left">XAML provides new support for defining tailored views (.xaml files) that share the same code file. This makes it easier for you to create and maintain different views that are tailored to a specific device family or scenario. If your app has distinct UI content, layout, or navigation models that are drastically different for different scenarios, build multiple views. For example, you might use a [<strong>Pivot</strong>](https://msdn.microsoft.com/library/windows/apps/dn608241) with navigation optimized for one-handed use on your mobile app, but use a [<strong>SplitView</strong>](https://msdn.microsoft.com/library/windows/apps/dn864360) with a navigation menu optimized for mouse on your desktop app.</td>
</tr>
<tr class="even">
<td align="left">StateTriggers</td>
<td align="left">Using the new [<strong>VisualState.StateTriggers</strong>](https://msdn.microsoft.com/library/windows/apps/dn890396) feature, you can conditionally set properties based on window height/width or based on a custom trigger. Previously, you had to handle Window [<strong>SizeChanged</strong>](https://msdn.microsoft.com/library/windows/apps/br209055) events in code and call [<strong>VisualStateManager.GoToState</strong>](https://msdn.microsoft.com/library/windows/apps/br209025).</td>
</tr>
<tr class="odd">
<td align="left">Setters</td>
<td align="left"><p>Using the new [<strong>VisualState.Setters</strong>](https://msdn.microsoft.com/library/windows/apps/dn890395) syntax, you can use simplified markup to define property changes in [<strong>VisualStateManager</strong>](https://msdn.microsoft.com/library/windows/apps/br209021). Previously, you had to use a Storyboard and create animations to apply property changes such as changing the orientation of a [<strong>StackPanel</strong>](https://msdn.microsoft.com/library/windows/apps/br209635) from Horizontal to Vertical. In universal Windows apps, you can use this simpler Setter syntax:</p>
<p><code>&lt;setter target=&quot;stackPanel1.Orientation&quot; value=&quot;Vertical&quot; /&gt;</code></p></td>
</tr>
</tbody>
</table>

 

## XAML features


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Compiled data bindings (x:Bind)</td>
<td align="left"><p>In universal Windows apps, you can use the new compiler-based binding mechanism enabled by the x:Bind property. Compiler-based bindings are strongly typed and processed at compile time, which is both faster and provides compile time errors when binding types are mismatched. And because bindings are translated to compiled app code, you can now debug bindings by stepping through code in Visual Studio to diagnose specific binding issues. You can also use x:Bind to bind to a method, like this:</p>
<p><code>&lt;textblock text=&quot;{x:Bind Customer.Address.ToString()}&quot; /&gt;</code></p>
<p>For typical binding scenarios, you can use x:Bind in place of Binding, and get improved performance and maintainability.</p></td>
</tr>
<tr class="even">
<td align="left">Declarative incremental rendering of lists (x:Phase)</td>
<td align="left"><p>In universal Windows apps, the new x:Phase attribute lets you perform incremental, or phased, rendering of lists using XAML instead of code. When panning long lists with complex items, your app might not be able to render items fast enough to keep up with the speed of panning, producing a poor experience for your users. Phased rendering lets you specify the rendering priority of individual elements in a list item, so only the most important parts of the list item are rendered in fast panning scenarios. This produces a smoother panning experience for your user.</p>
<p>In Windows 8.1, you could handle the [<strong>ContainerContentChanging</strong>](https://msdn.microsoft.com/library/windows/apps/dn298914) event and write code to render list items in phases. In UWP apps, you can accomplish phased rendering declaratively using the x:Phase attribute. Used in conjunction with compiled bindings x:Bind, x:Phase lets you easily specify a rendering priority for each bound element in a data template. When panning, the work to render items is time-sliced based on the phase, which enables incremental item rendering.</p></td>
</tr>
<tr class="odd">
<td align="left">Deferred loading of UI elements (x:DeferLoadingStrategy)</td>
<td align="left">In universal Windows apps, the new x:DeferLoadingStrategy directive lets you specify parts of your user interface to be delay-loaded, which improves start-up performance and reduces the memory usage of your app. For example, if your app UI has an element for data validation that is shown only when incorrect data is entered, you can delay loading of that element until it’s needed. Then, the element objects aren’t created when the page is loaded; instead, they’re created only when there’s a data error and they are needed to be added to the page’s visual tree.</td>
</tr>
<tr class="even">
<td align="left">SplitView</td>
<td align="left">The new [<strong>SplitView</strong>](https://msdn.microsoft.com/library/windows/apps/dn864360) control gives you a way to easily show and hide transient content. It’s commonly used for top-level navigation scenarios like the &quot;hamburger menu&quot;, where the navigation content is hidden, and slides in when needed as the result of a user action.</td>
</tr>
<tr class="odd">
<td align="left">RelativePanel</td>
<td align="left">[<strong>RelativePanel</strong>](https://msdn.microsoft.com/library/windows/apps/dn879546) is a new layout panel that lets you position and align child objects in relation to each other or the parent panel. For example, you can specify that some text should always be positioned to the left side of the panel, and a Button should always align below the text. Use <strong>RelativePanel</strong> when creating user interfaces that do not have a clear linear pattern that would call for use a [<strong>StackPanel</strong>](https://msdn.microsoft.com/library/windows/apps/br209635) or [<strong>Grid</strong>](https://msdn.microsoft.com/library/windows/apps/br242704).</td>
</tr>
<tr class="even">
<td align="left">CalendarView</td>
<td align="left">The [<strong>CalendarView</strong>](https://msdn.microsoft.com/library/windows/apps/dn890052) control makes it easy to view and select dates and date ranges using a customizable, month based view. <strong>CalendarView</strong> supports features such as minimum, maximum, and blackout dates to limit which dates can be selected. You can also set custom density bars that can be used to show the general &quot;fullness&quot; of the schedule on a particular day.</td>
</tr>
<tr class="odd">
<td align="left">CalendarDatePicker</td>
<td align="left">[<strong>CalendarDatePicker</strong>](https://msdn.microsoft.com/library/windows/apps/dn950083) is a drop down control that’s optimized for picking a single date from a [<strong>CalendarView</strong>](https://msdn.microsoft.com/library/windows/apps/dn890052) where contextual information like the day of the week or fullness of the calendar is important. It’s similar to the [<strong>DatePicker</strong>](https://msdn.microsoft.com/library/windows/apps/dn298584) control, but the <strong>DatePicker</strong> is optimized for picking a known date, such as a date of birth.</td>
</tr>
<tr class="even">
<td align="left">MediaTransportControls</td>
<td align="left">The new [<strong>MediaTransportControls</strong>](https://msdn.microsoft.com/library/windows/apps/dn831962) class makes it easier to customize the transport controls of a [<strong>MediaElement</strong>](https://msdn.microsoft.com/library/windows/apps/br242926). In Windows 8.1, you could enable <strong>MediaElement</strong>’s built-in transport controls, or create your own transport controls that called <strong>MediaElement</strong> methods. Now you can use the built-in functionality of <strong>MediaTransportControls</strong>, and still easily customize the look to suit your app.</td>
</tr>
<tr class="odd">
<td align="left">Property change notifications</td>
<td align="left"><p>In Universal Windows apps, you can listen for property changes on [<strong>DependencyObject</strong>](https://msdn.microsoft.com/library/windows/apps/br242356)s, even for properties that don’t have corresponding change events.</p>
<p>The notification operates like an event, but is actually exposed as a callback. The callback takes a sender argument just like an event handler, but doesn’t take an event argument. Instead, only the property identifier is passed to indicate which property. With this info your app can define a single handler for multiple property notifications. For more info, see [<strong>RegisterPropertyChangedCallback</strong>](https://msdn.microsoft.com/library/windows/apps/dn831902) and [<strong>UnregisterPropertyChangedCallback</strong>](https://msdn.microsoft.com/library/windows/apps/dn831910).</p></td>
</tr>
<tr class="even">
<td align="left">Maps</td>
<td align="left"><p>The [<strong>MapControl</strong>](https://msdn.microsoft.com/library/windows/apps/dn637004) class been updated to provide aerial 3D imagery and street-level views. These new features and earlier mapping functionality are now available to universal Windows apps. Add mapping to your app with the following APIs:</p>
<ul>
<li>[<strong>Windows.UI.Xaml.Controls.Maps</strong>](https://msdn.microsoft.com/library/windows/apps/dn610751) namespace - Display maps.</li>
<li>[<strong>Windows.Services.Maps</strong>](https://msdn.microsoft.com/library/windows/apps/dn636979) namespace - Find locations and routes.</li>
</ul>
<p>To start using these APIs in a Universal Windows app today, request a key from the [Bing Maps Developer Center](https://www.bingmapsportal.com/). For more info, see [How to authenticate a Maps app](https://msdn.microsoft.com/library/windows/apps/xaml/dn741528). Also new for Windows 10, PC and phone users can download offline maps from the Settings app. When available, offline maps are used by the [<strong>MapControl</strong>](https://msdn.microsoft.com/library/windows/apps/dn637004) to display maps when no internet access is available.</p></td>
</tr>
<tr class="odd">
<td align="left">Input button mapping</td>
<td align="left">The [<strong>Windows.UI.Xaml.Input.KeyRoutedEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/hh943072) class has a new [<strong>OriginalKey</strong>](https://msdn.microsoft.com/library/windows/apps/dn960168) property that, along with a corresponding update to [<strong>Windows.System.VirtualKey</strong>](https://msdn.microsoft.com/library/windows/apps/br241812), enables you to get the original, unmapped input button associated with the keyboard input event.</td>
</tr>
<tr class="even">
<td align="left">Inking</td>
<td align="left"><p>It’s now simpler to use the robust inking functionality in Windows Runtime apps using C++, C#, or Visual Basic, thanks to the [<strong>InkCanvas</strong>](https://msdn.microsoft.com/library/windows/apps/dn858535) control and underlying [<strong>InkPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn922011) classes.</p>
<p>The [<strong>InkCanvas</strong>](https://msdn.microsoft.com/library/windows/apps/dn858535) control defines an overlay area for drawing and rendering ink strokes. The functionality for this control (input, processing, and rendering) comes from the [<strong>InkPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn922011), [<strong>InkStroke</strong>](https://msdn.microsoft.com/library/windows/apps/br208485), [<strong>InkRecognizer</strong>](https://msdn.microsoft.com/library/windows/apps/br208478), and [<strong>InkSynchronizer</strong>](https://msdn.microsoft.com/library/windows/apps/dn903979) classes.</p>
<p></p>
<div class="alert">
<strong>Important</strong>  These classes are not supported in Windows apps using JavaScript.
</div>
<div>
 
</div></td>
</tr>
</tbody>
</table>

 

## Updated XAML features


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">CommandBar and AppBar updates</td>
<td align="left"><p>The [<strong>CommandBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn279427) and [<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) controls have been updated to have a consistent API, behavior and user experience for UWP apps across device families.</p>
<p>The [<strong>CommandBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn279427) control for universal Windows apps has been improved to provide a superset of [<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) functionality and greater flexibility in how you can use it in your app. You should use <strong>CommandBar</strong> for all new universal Windows apps on Windows 10. In a <strong>CommandBar</strong> in Windows 8.1, you could use only controls that implemented [<strong>ICommandBarElement</strong>](https://msdn.microsoft.com/library/windows/apps/dn251969), like [<strong>AppBarButton</strong>](https://msdn.microsoft.com/library/windows/apps/dn279244). In universal Windows apps, you can now put custom content in the <strong>CommandBar</strong> in addition to <strong>AppBarButton</strong>s.</p>
<p>The [<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) control has been updated to let you more easily move your Windows 8.1 apps that use <strong>AppBar</strong> to the Universal Windows Platform. <strong>AppBar</strong> was designed to be used with full-screen apps, and to be invoked using edge gestures. Updates to the control account for issues such as windowed apps and the lack of edge gestures in Window 10.</p>
<p>The Hidden [<strong>AppBar.ClosedDisplayMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn633872), previously only on Windows Phone, is now supported on all device families, letting you choose between different levels of hints for commands. The [<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) shows a minimal hint by default to provide consistency for you when upgrading your Windows 8.1 apps to universal Windows apps where you can no longer rely on the edge gesture support in the platform.</p>
<p><strong>New</strong> [<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) <strong>API:</strong>[<strong>Closing</strong>](https://msdn.microsoft.com/library/windows/apps/dn996483), [<strong>OnClosing</strong>](https://msdn.microsoft.com/library/windows/apps/dn996484), [<strong>Opening</strong>](https://msdn.microsoft.com/library/windows/apps/dn996486), [<strong>OnOpening</strong>](https://msdn.microsoft.com/library/windows/apps/dn996485), [<strong>TemplateSettings</strong>](https://msdn.microsoft.com/library/windows/apps/dn996487).</p>
<p><strong>New</strong> [<strong>CommandBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn279427) <strong>API:</strong>[<strong>CommandBarOverflowPresenterStyle</strong>](https://msdn.microsoft.com/library/windows/apps/dn975227) and [<strong>CommandBarOverflowPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn975225).</p></td>
</tr>
<tr class="even">
<td align="left">GridView updates</td>
<td align="left">Prior to Windows 10, the default [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) layout orientation was horizontal on Windows and vertical on Windows Phone. In UWP apps, <strong>GridView</strong> uses a vertical layout by default for all device families to ensure you have a consistent default experience.</td>
</tr>
<tr class="odd">
<td align="left">AreStickyGroupHeadersEnabled property</td>
<td align="left">When you show grouped data in a [<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) or [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705), the group headers now remain visible when the list is scrolled. This is important in large data sets where the header provides context for the data the user is viewing. However, in cases where there are only a few elements in each group, you might want to have the headers scroll off-screen with the items. You can set the [<strong>AreStickyGroupHeadersEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/dn932028) property on [<strong>ItemsStackPanel</strong>](https://msdn.microsoft.com/library/windows/apps/dn298795) and [<strong>ItemsWrapGrid</strong>](https://msdn.microsoft.com/library/windows/apps/dn298849) to control this behavior.</td>
</tr>
<tr class="even">
<td align="left">GroupHeaderContainerFromItemContainer method</td>
<td align="left">When you show grouped data in an [<strong>ItemsControl</strong>](https://msdn.microsoft.com/library/windows/apps/br242803), you can call the [<strong>GroupHeaderContainerFromItemContainer</strong>](https://msdn.microsoft.com/library/windows/apps/dn903984) method to get a reference to the parent header for the group. For example, if a user deletes the last item in a group, you can get a reference to the group header and remove both the item and group header together.</td>
</tr>
<tr class="odd">
<td align="left">ChoosingGroupHeaderContainer event</td>
<td align="left">The new [<strong>ChoosingGroupHeaderContainer</strong>](https://msdn.microsoft.com/library/windows/apps/dn899082) event on [<strong>ListViewBase</strong>](https://msdn.microsoft.com/library/windows/apps/br242879) lets you set state on the group headers in a [<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) or [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705). For example, you might handle this event to set the [<strong>AutomationProperties.NameProperty</strong>](https://msdn.microsoft.com/library/windows/apps/br209099) on the group header to represent the group in assistive technologies.</td>
</tr>
<tr class="even">
<td align="left">ChoosingItemContainer event</td>
<td align="left">The new [<strong>ChoosingItemContainer</strong>](https://msdn.microsoft.com/library/windows/apps/dn903989) event on [<strong>ListViewBase</strong>](https://msdn.microsoft.com/library/windows/apps/br242879) gives you greater control over UI virtualization in a [<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) or [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705). Use this event in conjunction with the [<strong>ContainerContentChanging</strong>](https://msdn.microsoft.com/library/windows/apps/dn298914) event to maintain your own queue of recycled containers from which to draw upon as needed. For example, if the data source has been reset due to filtering, you can quickly match an already created set of visuals (ItemContainers) with their data to achieve best performance.</td>
</tr>
<tr class="odd">
<td align="left">List scrolling virtualization</td>
<td align="left"><p>The XAML [<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) and [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) controls have a new [<strong>ListViewBase.ChoosingItemContainer</strong>](https://msdn.microsoft.com/library/windows/apps/dn903989) event that improves the performance of the control when a change occurs in the data collection.</p>
<p>Instead of doing a complete reset of the list, which replays the entrance animation, the system now maintains items currently in view, along with focus and selection state; new and removed items in the viewport animate in and out smoothly. After a change in the data collection in which containers are not destroyed, an app can quickly match any &quot;old&quot; items with their previous container and skip further processing of container-lifecycle override methods. Only &quot;new&quot; items are processed and associated with recycled or new containers.</p></td>
</tr>
<tr class="even">
<td align="left">SelectRange method and SelectedRanges property</td>
<td align="left">In Universal Windows apps, [<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) and [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) controls now let you select items in terms of ranges of item indexes instead of item object references. This is a more efficient way to describe item selection because item objects don’t need to be created for each selected item. For more info, see [<strong>ListViewBase.SelectedRanges</strong>](https://msdn.microsoft.com/library/windows/apps/dn904244), [<strong>ListViewBase.SelectRange</strong>](https://msdn.microsoft.com/library/windows/apps/dn904245), and [<strong>ListViewBase.DeselectRange</strong>](https://msdn.microsoft.com/library/windows/apps/dn904241).</td>
</tr>
<tr class="odd">
<td align="left">New ListViewItemPresenter APIs</td>
<td align="left">[<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) and [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) use item presenters to provide the default visuals for selection and focus. In UWP apps, [<strong>ListViewItemPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn298500) and [<strong>GridViewItemPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn279298) have new properties that let you further customize visuals for list items. The new properties are [<strong>CheckBoxBrush</strong>](https://msdn.microsoft.com/library/windows/apps/dn913905), [<strong>CheckMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn913923), [<strong>FocusSecondaryBorderBrush</strong>](https://msdn.microsoft.com/library/windows/apps/dn898370), [<strong>PointerOverForeground</strong>](https://msdn.microsoft.com/library/windows/apps/dn898372), [<strong>PressedBackground</strong>](https://msdn.microsoft.com/library/windows/apps/dn913931), and [<strong>SelectedPressedBackground</strong>](https://msdn.microsoft.com/library/windows/apps/dn913937).</td>
</tr>
<tr class="even">
<td align="left">SemanticZoom updates</td>
<td align="left"><p>The [<strong>SemanticZoom</strong>](https://msdn.microsoft.com/library/windows/apps/hh702601) control now has one consistent behavior for UWP apps across all device families.</p>
<p>The default action to switch between the zoomed in view and the zoomed out view is to tap on a group header in the zoomed in view. This is the same as the behavior on Windows Phone 8.1, but is a change from Windows 8.1, which used the pinch gesture to zoom. To change views using pinch-to- zoom, set [<strong>ScrollViewer.ZoomMode</strong>](https://msdn.microsoft.com/library/windows/apps/br209601)=&quot;Enabled&quot; on the [<strong>SemanticZoom</strong>](https://msdn.microsoft.com/library/windows/apps/hh702601)’s internal [<strong>ScrollViewer</strong>](https://msdn.microsoft.com/library/windows/apps/br209527).</p>
<p>For Universal Windows apps, the zoomed out view replaces the zoomed in view and is the same size as the view that it replaced. This is the same as the behavior on Windows 8.1, but is a change from Windows Phone 8.1, where the zoomed out view took up the full size of the screen and was rendered on top of all other content.</p></td>
</tr>
<tr class="odd">
<td align="left">DatePicker and TimePicker updates</td>
<td align="left">The [<strong>DatePicker</strong>](https://msdn.microsoft.com/library/windows/apps/dn298584) and [<strong>TimePicker</strong>](https://msdn.microsoft.com/library/windows/apps/dn299280) controls now have one consistent implementation for universal Windows apps across all device families. They also have a new look for Windows 10. The popup portion of the now uses [<strong>DatePickerFlyout</strong>](https://msdn.microsoft.com/library/windows/apps/dn625013) and [<strong>TimePickerFlyout</strong>](https://msdn.microsoft.com/library/windows/apps/dn608313) controls on all devices. This is the same as the behavior on Windows Phone 8.1, but is a change from Windows 8.1, which used [<strong>ComboBox</strong>](https://msdn.microsoft.com/library/windows/apps/br209348) controls. Using the flyout controls lets you lets you more easily create customized date and time pickers.</td>
</tr>
<tr class="even">
<td align="left">New ScrollViewer APIs</td>
<td align="left">[<strong>ScrollViewer</strong>](https://msdn.microsoft.com/library/windows/apps/br209527) has new [<strong>DirectManipulationStarted</strong>](https://msdn.microsoft.com/library/windows/apps/dn858544) and [<strong>DirectManipulationCompleted</strong>](https://msdn.microsoft.com/library/windows/apps/dn858543) events to notify your app when touch panning starts and stops. You can handle these events to coordinate your UI with these user actions.</td>
</tr>
<tr class="odd">
<td align="left">MenuFlyout updates</td>
<td align="left">In Universal Windows apps, there are new APIs that let you build better context menus more easily. The new [<strong>MenuFlyout.ShowAt</strong>](https://msdn.microsoft.com/library/windows/apps/dn913174) method lets you specify where you want the flyout to appear in relation to another element. (And your [<strong>MenuFlyout</strong>](https://msdn.microsoft.com/library/windows/apps/dn299030) can even overlap the boundaries of your app’s window.) Use the new [<strong>MenuFlyoutSubItem</strong>](https://msdn.microsoft.com/library/windows/apps/dn913170) class to create cascading menus.</td>
</tr>
<tr class="even">
<td align="left">New Border properties for ContentPresenter, Grid, and StackPanel</td>
<td align="left">Common container controls have new border properties that let you draw a border around them without adding an additional Border element to your XAML. [<strong>ContentPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/br209378), [<strong>Grid</strong>](https://msdn.microsoft.com/library/windows/apps/br242704), and [<strong>StackPanel</strong>](https://msdn.microsoft.com/library/windows/apps/br209635) have these new properties: [<strong>BorderBrush</strong>](https://msdn.microsoft.com/library/windows/apps/dn960179), [<strong>BorderThickness</strong>](https://msdn.microsoft.com/library/windows/apps/dn960181), [<strong>CornerRadius</strong>](https://msdn.microsoft.com/library/windows/apps/dn960183), and [<strong>Padding</strong>](https://msdn.microsoft.com/library/windows/apps/dn960187).</td>
</tr>
<tr class="odd">
<td align="left">New text APIs on ContentPresenter</td>
<td align="left">[<strong>ContentPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/br209378) has new APIs that give you more control over text display: [<strong>LineHeight</strong>](https://msdn.microsoft.com/library/windows/apps/dn903982), [<strong>LineStackingStrategy</strong>](https://msdn.microsoft.com/library/windows/apps/dn831933), [<strong>MaxLines</strong>](https://msdn.microsoft.com/library/windows/apps/dn831935), and [<strong>TextWrapping</strong>](https://msdn.microsoft.com/library/windows/apps/dn831937).</td>
</tr>
<tr class="even">
<td align="left">System Focus Visuals</td>
<td align="left">Focus visuals for XAML controls are now created by the system, instead of being declared as XAML elements in the control template. The focus visuals are not typically needed on mobile devices, and letting the system create and manage them as needed improves app performance. If you need greater control over focus visuals, you can override the system behavior and providing a custom control template that defines focus visuals. See [<strong>UseSystemFocusVisuals</strong>](https://msdn.microsoft.com/library/windows/apps/dn899076) and [<strong>IsTemplateFocusTarget</strong>](https://msdn.microsoft.com/library/windows/apps/dn899074) for more info.</td>
</tr>
<tr class="odd">
<td align="left">PasswordBox.PasswordRevealMode</td>
<td align="left"><p>In Universal Windows apps, the [<strong>PasswordRevealMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn890867) property replaces the [<strong>IsPasswordRevealButtonEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/hh702579) property to provide consistent behavior across device families.</p>
<p></p>
<div class="alert">
<strong>Caution</strong>  Prior to Windows 10, the password reveal button was not shown by default; in Universal Windows apps it is shown by default. If the security of your app requires that the password is always obscured, be sure to set [<strong>PasswordRevealMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn890867) to Hidden.
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left">Control.IsTextScaleFactorEnabled</td>
<td align="left">The [<strong>IsTextScaleFactorEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/dn624997) property that was available on Windows Phone 8.1 is now available for Universal Windows apps across all device families.</td>
</tr>
<tr class="odd">
<td align="left">AutoSuggestBox</td>
<td align="left">The [<strong>AutoSuggestBox</strong>](https://msdn.microsoft.com/library/windows/apps/dn633874) control from Windows Phone 8.1 is now available for Universal Windows apps across all device families, and you should use it instead of [<strong>SearchBox</strong>](https://msdn.microsoft.com/library/windows/apps/dn252771). <strong>AutoSuggestBox</strong> provides suggestions as the user types, and works well with various input types, like touch, keyboard, and Input Method Editors. It also has some new members to make it work better as a search box: the [<strong>QueryIcon</strong>](https://msdn.microsoft.com/library/windows/apps/dn996494) property and the [<strong>QuerySubmitted</strong>](https://msdn.microsoft.com/library/windows/apps/dn996497) event.</td>
</tr>
<tr class="even">
<td align="left">ContentDialog</td>
<td align="left">The [<strong>ContentDialog</strong>](https://msdn.microsoft.com/library/windows/apps/dn633972) control from Windows Phone 8.1 is now available for Universal Windows apps across all device families. <strong>ContentDialog</strong> lets you display a customizable modal dialog that works great across the full spectrum of devices.</td>
</tr>
<tr class="odd">
<td align="left">Pivot</td>
<td align="left">The [<strong>Pivot</strong>](https://msdn.microsoft.com/library/windows/apps/dn608241) control from Windows Phone 8.1 is now available for Universal Windows apps across all device families. You can now use the same <strong>Pivot</strong> control for in your app for mobile and desktop devices. <strong>Pivot</strong> provides adaptive behavior based on the screen size and input type. You can style a <strong>Pivot</strong> control to provide tab-like behavior, with different views of information in each pivot item.</td>
</tr>
</tbody>
</table>

 

## Text


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Windows core text APIs</td>
<td align="left"><p>The new [<strong>Windows.UI.Text.Core</strong>](https://msdn.microsoft.com/library/windows/apps/dn958238) namespace features a client-server system that centralizes the processing of keyboard input into a single server.</p>
<p>You can use it to manipulate the edit buffer of your custom text input control. The text input server ensures that the contents of your text input control and the contents of its own edit buffer are always in sync, via an asynchronous communication channel between the app and the server.</p></td>
</tr>
<tr class="even">
<td align="left">Vector icons</td>
<td align="left">The [<strong>Glyphs</strong>](https://msdn.microsoft.com/library/windows/apps/br209921) element has the new [<strong>IsColorFontEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/dn900468) and [<strong>ColorFontPalleteIndex</strong>](https://msdn.microsoft.com/library/windows/apps/dn900466) properties to support color fonts; now you can use a font file to render font-based icons. When you use <strong>ColorFontPalleteIndex</strong> for color palette switching, a single icon can be rendered with different color sets; for example, to show an enabled and disabled version of the icon.</td>
</tr>
<tr class="odd">
<td align="left">Input Method Editor window events</td>
<td align="left">Users sometimes enter text through an Input Method Editor that shows in a window just below a text input box (typically for East Asian languages). You can use the [<strong>CandidateWindowBoundsChanged</strong>](https://msdn.microsoft.com/library/windows/apps/dn955144) event and [<strong>DesiredCandidateWindowAlignment</strong>](https://msdn.microsoft.com/library/windows/apps/dn955145) property on [<strong>TextBox</strong>](https://msdn.microsoft.com/library/windows/apps/br209683) and [<strong>RichEditBox</strong>](https://msdn.microsoft.com/library/windows/apps/br227548) to make your app UI work better with the IME window.</td>
</tr>
<tr class="even">
<td align="left">Text composition events</td>
<td align="left">[<strong>TextBox</strong>](https://msdn.microsoft.com/library/windows/apps/br209683) and [<strong>RichEditBox</strong>](https://msdn.microsoft.com/library/windows/apps/br227548) have new events to inform your app when text is composed using an Input Method Editor: [<strong>TextCompositionStarted</strong>](https://msdn.microsoft.com/library/windows/apps/dn891458), [<strong>TextCompositionEnded</strong>](https://msdn.microsoft.com/library/windows/apps/dn891457), and [<strong>TextCompositionChanged</strong>](https://msdn.microsoft.com/library/windows/apps/dn891456). You can handle these events to coordinate your app code with the IME text composition process. For example, you could implement inline auto-completion functionality for East Asian languages.</td>
</tr>
<tr class="odd">
<td align="left">Improved handling of bi-directional text</td>
<td align="left"><p>XAML text controls have new API to improve handling of bi-directional text, resulting in better text alignment and paragraph directionality across a variety of input languages.</p>
<p>The default value of the [<strong>TextReadingOrder</strong>](https://msdn.microsoft.com/library/windows/apps/dn949133) property has been changed to <strong>DetectFromContent</strong>, so support for detecting reading order is enabled by default. The <strong>TextReadingOrder</strong> property has also been added to [<strong>PasswordBox</strong>](https://msdn.microsoft.com/library/windows/apps/br227519), [<strong>RichEditBox</strong>](https://msdn.microsoft.com/library/windows/apps/br227548), and [<strong>TextBox</strong>](https://msdn.microsoft.com/library/windows/apps/br209683).</p>
<p>You can set the [<strong>TextAlignment</strong>](https://msdn.microsoft.com/library/windows/apps/br209703) property on text controls to the new <strong>DetectFromContent</strong> value to opt-in to having alignment detected automatically from the content.</p></td>
</tr>
<tr class="even">
<td align="left">Text rendering</td>
<td align="left">In Windows 10, text in XAML apps now renders, in most situations, at nearly twice the speed of Windows 8.1. In most cases, your apps will benefit from this improvement without any changes. In addition to faster rendering, these improvements also reduce typical memory consumption of XAML apps by 5%.</td>
</tr>
</tbody>
</table>

 

## Application model


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Cortana</td>
<td align="left"><p>Extend the basic functionality of <strong>Cortana</strong> with voice commands that launch and execute a single action in an external application.</p>
<p>By integrating the basic functionality of your app, and by providing a central entry point for the user to accomplish most of the tasks without opening your app directly, <strong>Cortana</strong> can act as a liaison between your app and the user. In many cases, this can save the user significant time and effort.</p>
<p>Learn how to [integrate your app into the Cortana canvas](https://msdn.microsoft.com/library/windows/apps/xaml/dn974230). If you need ideas you can refer to the design recommendations and UX guidelines specific to <strong>Cortana</strong> in [Design basics for Universal Windows apps](https://dev.windows.com/design/design-basics).</p></td>
</tr>
<tr class="even">
<td align="left">File Explorer</td>
<td align="left">The new [<strong>Windows.System.Launcher.LaunchFolderAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn889616) methods let you launch File Explorer and display the contents of a folder that you specify.</td>
</tr>
<tr class="odd">
<td align="left">Shared storage</td>
<td align="left">The new [<strong>Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager</strong>](https://msdn.microsoft.com/library/windows/apps/dn889985) class and its methods let you share a file with another app by passing a sharing token when you launch the other app by using URI activation. The target app redeems the token to get the file shared by the source app.</td>
</tr>
<tr class="even">
<td align="left">Settings</td>
<td align="left"><p>Display built-in settings pages by using the ms-settings protocol with the [<strong>LaunchUriAsync</strong>](https://msdn.microsoft.com/library/windows/apps/hh701476) method. For example, the following code displays the page of Wi-Fi settings.</p>
<p><code>bool result = await Launcher.LaunchUriAsync(new Uri(&quot;ms-settings://network/wifi&quot;));</code></p>
<p>For a list of the settings pages that you can display, see [How to display built-in settings pages by using the ms-settings protocol](https://msdn.microsoft.com/library/windows/apps/jj207014.aspx).</p></td>
</tr>
<tr class="odd">
<td align="left">App-to-App communication</td>
<td align="left"><p>New [app-to-app communication](https://msdn.microsoft.com/library/windows/apps/xaml/dn997827) APIs in Windows 10 make it possible for Windows applications (as well as Windows Web applications) to launch each other and exchange data and files.</p>
<p>Using these new APIs, complex tasks that would have required the user to use multiple applications can now be handled seamlessly. For example, your app could launch a social networking app to choose a contact, or launch a checkout application to complete a payment process.</p></td>
</tr>
<tr class="even">
<td align="left">App services</td>
<td align="left">An app service is a way for an app to provide services to other apps in Windows 10. An app service takes the form of a background task. Foreground apps can call an app service in another app to perform tasks in the background. For reference information about the app service API, see [<strong>Windows.ApplicationModel.AppService</strong>](https://msdn.microsoft.com/library/windows/apps/dn921731).</td>
</tr>
<tr class="odd">
<td align="left">App package manifest</td>
<td align="left"><p>Updates to the [package manifest schema](https://msdn.microsoft.com/library/windows/apps/br211474) reference for Windows 10 include elements that have been added, removed, and changed.</p>
<p>See [Element Hierarchy](https://msdn.microsoft.com/library/windows/apps/dn934819) for reference info on all elements, attributes, and types in the schema.</p></td>
</tr>
</tbody>
</table>

 

## Devices


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Microsoft Surface Hub</td>
<td align="left"><p>The Microsoft Surface Hub is a powerful team collaboration device and a large-screen platform for Universal Windows apps that run natively from Surface Hub or from your connected device.</p>
<p>Build your own apps, designed specifically for your business, that take advantage of the large screen, touch and ink input, and extensive onboard hardware like cameras and sensors.</p>
<p>Have a look at the design recommendations and UX guidelines specific to Surface Hub in [Design basics for Universal Windows apps](https://dev.windows.com/design/design-basics). These docs explain responsive design techniques for Universal Windows apps.</p>
<p>For detail on supporting communal shared apps, see [<strong>SharedModeSettings</strong>](https://msdn.microsoft.com/library/windows/apps/dn949019).</p>
<p>For ink input and detail on support for multi-point inking on the new [<strong>InkCanvas</strong>](https://msdn.microsoft.com/library/windows/apps/dn858535) control, see [<strong>Windows.UI.Input.Inking</strong>](https://msdn.microsoft.com/library/windows/apps/br208524) and [<strong>Windows.UI.Input.Inking.Core</strong>](https://msdn.microsoft.com/library/windows/apps/dn958452).</p>
<p>For handling sensor input, see [Integrating devices, printers, and sensors](https://msdn.microsoft.com/library/windows/apps/br229563).</p></td>
</tr>
<tr class="even">
<td align="left">Location</td>
<td align="left"><p>Windows 10 introduces a new method to prompt the user for permission to access their location, [<strong>RequestAccessAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn859152).</p>
<p>The user sets the privacy of their location data with the <strong>location privacy settings</strong> in the <strong>Settings</strong> app. Your app can access the user's location only when:</p>
<ul>
<li><strong>Location for this device</strong> is turned on (not applicable for Windows 10 for phones).</li>
<li>The location services setting “<strong>Location</strong>” is <strong>on</strong>.</li>
<li>Under <strong>Choose apps that can use your location</strong>, your app is set to <strong>on</strong>.</li>
</ul>
<p>It's important to call [<strong>RequestAccessAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn859152) before accessing the user’s location. At that time, your app must be in the foreground and <strong>RequestAccessAsync</strong> must be called from the UI thread. Until the user grants your app permission to their location, your app can't access location data.</p></td>
</tr>
<tr class="odd">
<td align="left">AllJoyn</td>
<td align="left"><p>The [<strong>Windows.Devices.AllJoyn</strong>](https://msdn.microsoft.com/library/windows/apps/dn894971) Windows Runtime namespace introduces Microsoft's implementation of the AllJoyn open source software framework and services. These APIs make it possible for your universal Windows device app to participate with other devices in AllJoyn-driven, Internet of Things (IoT) scenarios. For more details about the AllJoyn C APIs, download the documentation at [The AllSeen Alliance](https://allseenalliance.org/).</p>
<p>Use the [AllJoynCodeGen tool](https://msdn.microsoft.com/library/windows/apps/dn913809) included in this release to generate a Windows component that you can use to enable AllJoyn scenarios in your device app.</p>
<div class="alert">
<strong>Note</strong>  Windows 10 IoT Core is now available for a new class of small devices, allowing you to create “Internet of Things” (IoT) devices using Windows and Visual Studio. Learn more about Windows IoT at [WindowsOnDevices.com](http://www.windowsondevices.com/).
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left">Printing APIs on mobile (XAML)</td>
<td align="left">There is a single, unified set of APIs that let you print from your XAML-based UWP apps across device families, including mobile devices. You can now add printing to your mobile app by using familiar printing-related APIs from the [<strong>Windows.Graphics.Printing</strong>](https://msdn.microsoft.com/library/windows/apps/br226489) and [<strong>Windows.UI.Xaml.Printing</strong>](https://msdn.microsoft.com/library/windows/apps/br243325) namespaces.</td>
</tr>
<tr class="odd">
<td align="left">Battery</td>
<td align="left"><p>The battery APIs in the [<strong>Windows.Devices.Power</strong>](https://msdn.microsoft.com/library/windows/apps/dn895017) namespace let your app learn more about any batteries that are connected to the device that’s running your app.</p>
<p>Create a [<strong>Battery</strong>](https://msdn.microsoft.com/library/windows/apps/dn895004) object to represent an individual battery controller or an aggregate of all battery controllers (when created by [<strong>FromIdAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn895013) or [<strong>AggregateBattery</strong>](https://msdn.microsoft.com/library/windows/apps/dn895011), respectively).</p>
<p>Use the [<strong>GetReport</strong>](https://msdn.microsoft.com/library/windows/apps/dn895015) method to return a [<strong>BatteryReport</strong>](https://msdn.microsoft.com/library/windows/apps/dn895005) object that indicates the charge, capacity, and status of the corresponding batteries.</p></td>
</tr>
<tr class="even">
<td align="left">MIDI devices</td>
<td align="left"><p>The new [<strong>Windows.Devices.Midi</strong>](https://msdn.microsoft.com/library/windows/apps/dn895002) namespace lets you create:</p>
<ul>
<li>Apps that can communicate with external MIDI devices.</li>
<li>Apps and external devices that directly communicate with the Microsoft GS MIDI software synthesizer.</li>
<li>Scenarios where multiple clients simultaneously access a single MIDI port.</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">Custom sensor support</td>
<td align="left">The [<strong>Windows.Devices.Sensors.Custom</strong>](https://msdn.microsoft.com/library/windows/apps/dn895032) namespace allows hardware developers to define new custom sensor types, like a CO2 sensor.</td>
</tr>
<tr class="even">
<td align="left">Host-based Card Emulation (HCE)</td>
<td align="left"><p>Host card emulation enables you to implement NFC card emulation services hosted in the OS and still be able to communicate with the external reader terminal via NFC radio.</p>
<p>Implement a background task to emulate a smartcard via NFC. To trigger the background task, use the [<strong>SmartCardTrigger</strong>](https://msdn.microsoft.com/library/windows/apps/dn624853) class.</p>
<p>The <strong>EmulatorHostApplicationActivated</strong> value in the [<strong>SmartCardTriggerType</strong>](https://msdn.microsoft.com/library/windows/apps/dn608017) enum lets your app know that an HCE event has occurred.</p></td>
</tr>
</tbody>
</table>

 

## Graphics


|                      |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| DirectX              | DirectX 12 in Windows 10 introduces the next version of Microsoft Direct3D, the 3D graphics API at the heart of DirectX. [Direct3D 12 Graphics](https://msdn.microsoft.com/library/windows/desktop/dn903821) enables the efficiency and performance of a low-level, console-like API. Direct3D 12 is faster and more efficient than ever before. It enables richer scenes, more objects, more complex effects, and better use of modern graphics hardware.                                                                                                                                                                                                                                                                                     |
| SoftwareBitmapSource | In Universal Windows apps, you can use the new [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/dn997854) type as a XAML image source. This lets you pass un-encoded images to the XAML framework to be immediately displayed on screen, bypassing image decoding by the XAML framework. You can achieve much faster image rendering, such as rendering low-lag photos directly from the camera, using custom image decoders, capturing frames from DirectX surfaces, or even creating in-memory images from scratch and rendering them all directly in XAML with low latency and low memory overhead.                                                                                                     |
| Perspective Camera   | In universal Windows apps, XAML has a new Transform3D API that lets you apply perspective transforms to a XAML tree (or scene), which transforms all XAML child elements according to that single scene-wide transform (or camera). You could do this previously using MatrixTransform and complex math, but Transform3D greatly simplifies this effect, and also enables the effect to be animated. For more info, see the [**UIElement.Transform3D**](https://msdn.microsoft.com/library/windows/apps/dn906919) property, [**Transform3D**](https://msdn.microsoft.com/library/windows/apps/dn914748), [**CompositeTransform3D**](https://msdn.microsoft.com/library/windows/apps/dn914714), and [**PerspectiveTransform3D**](https://msdn.microsoft.com/library/windows/apps/dn914740). |

 

## Media


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">HTTP Live Streaming</td>
<td align="left">You can use the new [<strong>AdaptiveMediaSource</strong>](https://msdn.microsoft.com/library/windows/apps/dn946912) class to add adaptive video streaming capabilities to your apps. The object is initialized by pointing it to a streaming manifest file. Supported manifest formats include Http Live Streaming (HLS) and Dynamic Adaptive Streaming over HTTP (DASH). Once the object is bound to a XAML media element, adaptive playback begins. Properties of the stream, such as the available, minimum, and maximum bitrates, can be queried and set where appropriate.</td>
</tr>
<tr class="even">
<td align="left">Media Foundation Transcode Video Processor (XVP) support for Media Foundation Transforms (MFTs)</td>
<td align="left"><p>Windows apps that use Media Foundation Transforms (MFTs) can now use the <strong>Media Foundation Transcode Video Processor</strong> (XVP) to convert, scale, and transform raw video data:</p>
<p>The new [MF_XVP_CALLER_ALLOCATES_OUTPUT](https://msdn.microsoft.com/library/windows/desktop/dn803919) attribute enables the output to caller-allocated textures even in Microsoft DirectX Video Acceleration (DXVA) mode.</p>
<p>The new [<strong>IMFVideoProcessorControl2</strong>](https://msdn.microsoft.com/library/windows/desktop/dn800741) interface lets your app enable hardware effects, query for supported hardware effects, and override the rotation operation performed by the video processor.</p></td>
</tr>
<tr class="odd">
<td align="left">Transcoding</td>
<td align="left">The new [<strong>MediaProcessingTrigger</strong>](https://msdn.microsoft.com/library/windows/apps/dn806005) API lets your app perform media transcoding in a background task, so your transcoding operations can continue even when your foreground app has been terminated.</td>
</tr>
<tr class="even">
<td align="left">MediaElement media failure events</td>
<td align="left">In Universal Windows apps, the [<strong>MediaElement</strong>](https://msdn.microsoft.com/library/windows/apps/br242926) will play content containing multiple streams even if there’s an error decoding one of the streams, as long as the media content contains at least one valid stream. For example, if the video stream in a content containing an audio and a video stream fails, the <strong>MediaElement</strong> will still play the audio stream. The [<strong>PartialMediaFailureDetected</strong>](https://msdn.microsoft.com/library/windows/apps/dn889635) event notifies you that one of the streams within a stream could not be decoded. It also lets you know what type of stream failed so that you can reflect that info in your UI. If all of the streams within a media stream fail, the [<strong>MediaFailed</strong>](https://msdn.microsoft.com/library/windows/apps/br227393) event is raised.</td>
</tr>
<tr class="odd">
<td align="left">Support for adaptive video streaming with MediaElement</td>
<td align="left">[<strong>MediaElement</strong>](https://msdn.microsoft.com/library/windows/apps/br242926) has the new [<strong>SetPlaybackSource</strong>](https://msdn.microsoft.com/library/windows/apps/dn899085) method to support adaptive video streaming. Use this method to set your media source to an [<strong>AdaptiveMediaSource</strong>](https://msdn.microsoft.com/library/windows/apps/dn946912).</td>
</tr>
<tr class="even">
<td align="left">Casting with MediaElement and Image</td>
<td align="left">The [<strong>MediaElement</strong>](https://msdn.microsoft.com/library/windows/apps/br242926) and [<strong>Image</strong>](https://msdn.microsoft.com/library/windows/apps/br242752) controls have the new [<strong>GetAsCastingSource</strong>](https://msdn.microsoft.com/library/windows/apps/dn920012) method. You can use this method to programmatically send content from any media or image element to a broader range of remote devices, like Miracast, Bluetooth, and DLNA.This functionality is enabled automatically when you set [<strong>AreTransportControlsEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/dn298977) to true on a <strong>MediaElement</strong>.</td>
</tr>
<tr class="odd">
<td align="left">Media transport controls for desktop apps</td>
<td align="left">The [<strong>ISystemMediaTransportControls</strong>](https://msdn.microsoft.com/library/windows/desktop/dn892299) interface and related APIs allow desktop apps to interact with the built-in system media transport controls. This includes responding to user interactions with the transport control buttons, and updating the transport controls display to show metadata about currently playing media content.</td>
</tr>
<tr class="even">
<td align="left">Random-access JPEG encoding and decoding</td>
<td align="left">New WIC methods [<strong>IWICJpegFrameEncode</strong>](https://msdn.microsoft.com/library/windows/desktop/dn903864) and [<strong>IWICJpegFrameDecode</strong>](https://msdn.microsoft.com/library/windows/desktop/dn903834) enable the encoding and decoding of JPEG images. You can also now enable indexing of the image data, which provides efficient random access to large images at the expense of a larger memory footprint.</td>
</tr>
<tr class="odd">
<td align="left">Overlays for media compositions</td>
<td align="left">The new [<strong>MediaOverlay</strong>](https://msdn.microsoft.com/library/windows/apps/dn764793) and [<strong>MediaOverlayLayer</strong>](https://msdn.microsoft.com/library/windows/apps/dn764795) APIs make it easy to add multiple layers of static or dynamic media content to a media composition. Opacity, position, and timing can be adjusted for each layer, and you can even implement your own custom compositor for input layers.</td>
</tr>
<tr class="even">
<td align="left">New effects framework</td>
<td align="left">The [<strong>Windows.Media.Effects</strong>](https://msdn.microsoft.com/library/windows/apps/dn278802) namespace provides a simple and intuitive framework for adding effects to audio and video streams. The framework includes basic interfaces that you can implement to create custom audio and video effects and insert them into the media pipeline.</td>
</tr>
</tbody>
</table>

 

## Networking


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Sockets</td>
<td align="left"><p>Socket updates include:</p>
<ul>
<li><strong>Socket broker.</strong> The socket broker can establish and close socket connections on behalf of an app in any state of the app lifecycle. This makes apps and the services that they provide more discoverable. For example, by way of the socket broker, a Win32 service can still accept incoming socket connections even when it’s not running.</li>
<li><strong>Throughput improvements.</strong> Socket throughput has been optimized for apps that use the [<strong>Windows.Networking.Sockets</strong>](https://msdn.microsoft.com/library/windows/apps/br226960) namespace.</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">Background Transfer post-processing tasks</td>
<td align="left">New APIs in the [<strong>Windows.Networking.BackgroundTransfer</strong>](https://msdn.microsoft.com/library/windows/apps/br207242) namespace let you register groups of post-processing tasks. Your app can act on the success or failure of background transfers immediately, even if it’s not in the foreground, instead of waiting for the next time the user resumes the app.</td>
</tr>
<tr class="odd">
<td align="left">Bluetooth support for advertisements</td>
<td align="left">With the [<strong>Windows.Devices.Bluetooth.Advertisement</strong>](https://msdn.microsoft.com/library/windows/apps/dn894325) namespace, your apps can send, receive, and filter Bluetooth LE advertisements.</td>
</tr>
<tr class="even">
<td align="left">Wi-Fi Direct API update</td>
<td align="left"><p>The device broker is updated to enable pairing with devices without leaving the app. Additions to the [<strong>Windows.Devices.WiFiDirect</strong>](https://msdn.microsoft.com/library/windows/apps/dn297687) namespace also let a device make itself discoverable to other devices, and let it listen for incoming connection notifications.</p>
<div class="alert">
<strong>Note</strong>  In this release, the Wi-Fi Direct feature improvements are not built into the UX, and they support only push-button pairing. Also, this release supports only one active connection.
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left">JSON support improvements</td>
<td align="left">The [<strong>Windows.Data.Json</strong>](https://msdn.microsoft.com/library/windows/apps/br240639) namespace now better supports existing standard definitions and the developer experience when converting JSON objects during debug sessions.</td>
</tr>
</tbody>
</table>

 

## Security


|                             |                                                                      |
|-----------------------------|----------------------------------------------------------------------|
| ECC encryption              | New APIs in the [**Windows.Security.Cryptography**](https://msdn.microsoft.com/library/windows/apps/br241404) namespace provide support for Elliptical Curve Cryptography (ECC), a public-key cryptography implementation based on elliptical curves over finite fields. ECC is mathematically more complex than RSA, provides smaller key sizes, reduces memory consumption, and improves performance. It offers Microsoft services and customers an alternative to RSA keys and NIST-approved curve parameters. |
| Microsoft Passport          | Microsoft Passport is an alternative method of authentication that replaces passwords with asymmetric cryptography and a gesture. Classes in the [**Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) namespace, such as [**KeyCredentialManager**](https://msdn.microsoft.com/library/windows/apps/dn973043), make it easy for developers to create application using Microsoft Passport without the complexity of cryptography or biometrics.  |
| Microsoft Passport for Work | Microsoft Passport for Work is an alternative method for signing in Windows using your Azure Active Directory account that does not use passwords, smart card, and Virtual Smart Cards. You can choose whether to disable or enable this policy setting. |
| Token Broker                | Token Broker is a new authentication framework that makes it easier for apps to connect to online identity providers (like Facebook). Features such as account username and password management and a streamlined UI provide a greatly improved authentication experience for users. |

 

## System services


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Power</td>
<td align="left"><p>Your Windows desktop application can now be notified when battery saver is engaged or disengaged. By responding to changing power conditions, your application has the opportunity to help extend battery life.</p>
<p>[<strong>GUID_POWER_SAVING_STATUS</strong>](https://msdn.microsoft.com/library/windows/desktop/hh448380): Use this new GUID with the [<strong>PowerSettingRegisterNotification</strong>](https://msdn.microsoft.com/library/windows/desktop/hh769082) function to be notified when battery saver is engaged or disengaged.</p>
<p>[<strong>SYSTEM_POWER_STATUS</strong>](https://msdn.microsoft.com/library/windows/desktop/aa373232): This structure has been updated to support battery saver. The fourth member, <strong>SystemStatusFlag</strong> (previously named Reserved1, now indicates if battery saver is engaged or not. Use the [<strong>GetSystemPowerStatus</strong>](https://msdn.microsoft.com/library/windows/desktop/aa372693) function to retrieve a pointer to this structure.</p></td>
</tr>
<tr class="even">
<td align="left">Version</td>
<td align="left"><p>You can use the [Version Helper functions](https://msdn.microsoft.com/library/windows/desktop/dn424972) to determine the version of the operating system. For Windows 10, these helper functions include a new function, [<strong>IsWindows10OrGreater</strong>](https://msdn.microsoft.com/library/windows/desktop/dn905474). You should use the helper functions rather than the deprecated [<strong>GetVersionEx</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724451) and [<strong>GetVersion</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724439) functions when you want to determine the system version. For more information about how to get the system version, see [Getting the System Version](https://msdn.microsoft.com/library/windows/desktop/ms724429).</p>
<p>If you do use the deprecated [<strong>GetVersionEx</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724451) or [<strong>GetVersion</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724439) function to get version information in an [<strong>OSVERSIONINFOEX</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724833) or [<strong>OSVERSIONINFO</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724834) structure, be aware that the version number that these structures contain increases from 6.3 for Windows 8.1 and Windows Server 2012 R2 to 10.0 for Windows 10. For more information about version numbers for the operating system, see [Operating System Version](https://msdn.microsoft.com/library/windows/desktop/ms724832).</p>
<p>You also need to specifically target Windows 8.1 or Windows 10 in your application to get the correct version information for these versions with the [<strong>GetVersionEx</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724451) or [<strong>GetVersion</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724439) function. For information about how to target your application for these versions of Windows, see [Targeting your application for Windows](https://msdn.microsoft.com/library/windows/desktop/dn481241).</p></td>
</tr>
<tr class="odd">
<td align="left">User information</td>
<td align="left">New APIs in the [<strong>Windows.System</strong>](https://msdn.microsoft.com/library/windows/apps/br241814) namespace make it easy to access information about a user, like their username and account picture. It also provides the ability to respond to user events such as log-in and log-out.</td>
</tr>
<tr class="even">
<td align="left">Memory management and profiling</td>
<td align="left">Support for memory profiling API in [<strong>Windows.System</strong>](https://msdn.microsoft.com/library/windows/apps/br241814) has been extended to all platforms, and their overall functionality has been enhanced with new classes and functions.</td>
</tr>
</tbody>
</table>

 

## Storage


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">File-search APIs available for Windows Phone</td>
<td align="left"><p>As an app publisher, you can register your app to share a storage folder with other apps that you publish by adding extensions to the app manifest. Then call the [<strong>Windows.Storage.ApplicationData.GetPublisherCacheFolder</strong>](https://msdn.microsoft.com/library/windows/apps/dn889607) method to get the shared storage location.</p>
<p>The strong security model of Windows Runtime apps typically prevents apps from sharing data among themselves. But it can be useful for apps from the same publisher to share files and settings on a per-user basis.</p></td>
</tr>
</tbody>
</table>

 

## Tools


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Live Visual Tree in Visual Studio</td>
<td align="left">Visual Studio has a new Live Visual Tree feature. You can use it while debugging to quickly understand the state of your app’s visual tree, and discover how element properties were set. It also lets you change property values while your app is running, so you can tweak and experiment without having to re-launch.</td>
</tr>
<tr class="even">
<td align="left">Trace logging</td>
<td align="left"><p>[TraceLogging](https://msdn.microsoft.com/library/windows/desktop/dn904636) is a new event-tracing API for user-mode apps and kernel-mode drivers; it builds on [Event Tracing for Windows](https://msdn.microsoft.com/library/windows/desktop/bb968803) (ETW). This API provides a simplified way to instrument code and include structured data with events without requiring a separate instrumentation manifest XML file.</p>
<p>WinRT, .NET, and C/C++ TraceLogging APIs are available to serve different developer audiences.</p></td>
</tr>
</tbody>
</table>

 

## User Experience


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Speech recognition</td>
<td align="left">Continuous speech recognition for long-form dictation scenarios is now supported by the Universal Windows Platform. See how to enable continuous dictation in the Speech interaction docs.</td>
</tr>
<tr class="even">
<td align="left">Drag-and-drop capabilities between different application platforms</td>
<td align="left"><p>The new [<strong>Windows.ApplicationModel.DataTransfer.DragDrop</strong>](https://msdn.microsoft.com/library/windows/apps/dn894216) namespaces bring drag-and-drop functionality to Universal Windows apps. Previously, common drag-and-drop scenarios for desktop programs—such as dragging a document from a folder into an Outlook email message to attach it—were not possible with universal Windows apps. Using these new APIs, your app can let users easily move data between different Universal Windows apps and the desktop.</p>
<p>To support Drag and Drop between apps, these new APIs have been added to XAML:</p>
<ul>
<li>[<strong>ListViewBase.DragItemsCompleted</strong>](https://msdn.microsoft.com/library/windows/apps/dn831959)</li>
<li>[<strong>UIElement</strong>](https://msdn.microsoft.com/library/windows/apps/br208911): [<strong>CanDrag</strong>](https://msdn.microsoft.com/library/windows/apps/dn903558), [<strong>DragStarting</strong>](https://msdn.microsoft.com/library/windows/apps/dn903560), [<strong>StartDragAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn903562), [<strong>DropCompleted</strong>](https://msdn.microsoft.com/library/windows/apps/dn903561)</li>
<li>[<strong>DragOperationDeferral</strong>](https://msdn.microsoft.com/library/windows/apps/dn831917), [<strong>DragUI</strong>](https://msdn.microsoft.com/library/windows/apps/dn985714), [<strong>DragUIOverride</strong>](https://msdn.microsoft.com/library/windows/apps/dn985715)</li>
<li>[<strong>DragEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/br242372): [<strong>AcceptedOperation</strong>](https://msdn.microsoft.com/library/windows/apps/dn831912), [<strong>DataView</strong>](https://msdn.microsoft.com/library/windows/apps/dn831913), [<strong>DragUIOverride</strong>](https://msdn.microsoft.com/library/windows/apps/dn985710), [<strong>GetDeferral</strong>](https://msdn.microsoft.com/library/windows/apps/dn831914), [<strong>Modifiers</strong>](https://msdn.microsoft.com/library/windows/apps/dn831915)</li>
<li>[<strong>DragItemsCompletedEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/dn831953), [<strong>DropCompletedEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/dn903549), [<strong>DragStartingEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/dn903540)</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">Custom window title bars</td>
<td align="left">For UWP apps for the desktop device family, you can now use the [<strong>ApplicationViewTitleBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn906115) class with the [<strong>ApplicationView.TitleBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn906131) property and [<strong>Window.SetTitleBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn965560) method to replace the default Windows title bar content with your own custom XAML content. Your XAML is treated as &quot;system chrome&quot;, so Windows will handle the input events instead of your app. This means the user can still drag and resize the window, even when clicking on your custom title bar content.</td>
</tr>
</tbody>
</table>

 

## Web


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Internet Explorer</td>
<td align="left"><p>Internet Explorer introduces Edge mode: a new &quot;living&quot; document mode designed for maximum interoperability with other modern browsers and contemporary web content. This experimental mode is being progressively rolled out to a randomly chosen set of Windows 10 users. You can manually enable or disable Edge mode through the new IE <strong>about:flags</strong> mechanism. For more info, see:</p>
<ul>
<li>[Living on the Edge – our next step in helping the web just work](http://blogs.msdn.com/b/ie/archive/2014/11/11/living-on-the-edge-our-next-step-in-interoperability.aspx).</li>
<li>[The Internet Explorer for Windows 10 Developer Guide](https://dev.windows.com/microsoft-edge/).</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">WebView Edge mode browsing</td>
<td align="left">The [<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702) control uses the same rendering engine as the new Edge browser. This provides the most accurate, standards-compliant mode of HTML rendering.</td>
</tr>
<tr class="odd">
<td align="left">Off-thread WebView</td>
<td align="left">You can specify a [<strong>WebView.ExecutionMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn932034) to enable processing and display of web content on a separate background thread. This can improve performance in certain, specific scenarios.</td>
</tr>
<tr class="even">
<td align="left">WebView.UnsupportedUriSchemeIdentified event</td>
<td align="left"><p>The new [<strong>WebView.UnsupportedUriSchemeIdentified</strong>](https://msdn.microsoft.com/library/windows/apps/dn974400) event lets you decide how your app should an unsupported URI scheme. You can handle this event to let your app provide custom handling of unsupported URI schemes.</p>
<p>For the HTML WebView control, see the [<strong>MSWebViewUnsupportedUriSchemeIdentified</strong>](https://msdn.microsoft.com/library/windows/apps/dn803906.aspx) event.</p></td>
</tr>
<tr class="odd">
<td align="left">WebView.NewWindowRequested event</td>
<td align="left"><p>The new [<strong>WebView.NewWindowRequested</strong>](https://msdn.microsoft.com/library/windows/apps/dn974397) event lets you respond when a script in a WebView requests a new browser window.</p>
<p>For the HTML WebView control, see the [<strong>MSWebViewNewWindowRequested</strong>](https://msdn.microsoft.com/library/windows/apps/dn806030) event.</p></td>
</tr>
<tr class="even">
<td align="left">WebView.PermissionRequested event</td>
<td align="left"><p>The new [<strong>WebView.PermissionRequested</strong>](https://msdn.microsoft.com/library/windows/apps/dn974398) event lets WebView content leverage rich new HTML5 APIs that require special permission from the user, like geolocation.</p>
<p>For the HTML WebView control, see the [<strong>MSWebViewPermissionRequested</strong>](https://msdn.microsoft.com/library/windows/apps/dn806030.aspx) event.</p></td>
</tr>
<tr class="odd">
<td align="left">WebView.UnviewableContentIdentified event</td>
<td align="left"><p>The new [<strong>WebView.UnviewableContentIdentified</strong>](https://msdn.microsoft.com/library/windows/apps/dn299351) event lets you respond when the [<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702) is navigated to non-web content such as a PDF file or Office document.</p>
<p>For the HTML WebView controls, see the [<strong>MSWebViewUnviewableContentIdentified</strong>](https://msdn.microsoft.com/library/windows/apps/dn609716) event.</p></td>
</tr>
<tr class="even">
<td align="left">WebView.AddWebAllowedObject method</td>
<td align="left"><p>You can call the new [<strong>WebView.AddWebAllowedObject</strong>](https://msdn.microsoft.com/library/windows/apps/dn903993) method to inject a WinRT object into a XAML [<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702), and then call its functions from trusted JavaScript hosted in that <strong>WebView</strong>. For example, web content can show system notifications by requesting that its parent app call the [<strong>ToastNotificationManager</strong>](https://msdn.microsoft.com/library/windows/apps/br208642) WinRT API.</p>
<p>For the HTML [<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702) control, see the [<strong>addWebAllowedObject</strong>](https://msdn.microsoft.com/library/windows/apps/dn926632) method.</p></td>
</tr>
<tr class="odd">
<td align="left">WebView.ClearTemporaryWebDataAync method</td>
<td align="left">When a user interacts with web content inside a XAML [<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702), the <strong>WebView</strong> control caches data based on that user's session. You can call the new [<strong>ClearTemporaryWebDataAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn974394) method to clear this cache. For example, you can clear the cache when one user logs out of the app so another user can’t access any data from the previous session.</td>
</tr>
</tbody>
</table>



<!--HONumber=Mar16_HO5-->


