---
Description: Learn how to navigate in a basic two page peer-to-peer Universal Windows Platform (UWP) app.
title: Peer-to-peer navigation between two pages
ms.assetid: 0A364C8B-715F-4407-9426-92267E8FB525
label: Peer-to-peer navigation between two pages
template: detail.hbs
---

# <span id="dev_navigation.peer-to-peer_navigation_between_two_pages"></span>Peer-to-peer navigation between two pages


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Learn how to navigate in a basic two page peer-to-peer Universal Windows Platform (UWP) app.

![two-page peer-to-peer navigation example](images/nav-peertopeer-2page.png)


**Important APIs**

-   [**Windows.UI.Xaml.Controls.Frame**](https://msdn.microsoft.com/library/windows/apps/br242682)
-   [**Windows.UI.Xaml.Controls.Page**](https://msdn.microsoft.com/library/windows/apps/br227503)
-   [**Windows.UI.Xaml.Navigation**](https://msdn.microsoft.com/library/windows/apps/br243300)


## <span id="Create_the_blank_app"></span><span id="create_the_blank_app"></span><span id="CREATE_THE_BLANK_APP"></span>Create the blank app


1.  On the Microsoft Visual Studio menu, choose **File &gt; New Project**.
2.  In the left pane of the **New Project** dialog box, choose the **Visual C# -&gt; Windows -&gt; Universal** or the **Visual C++ -&gt; Windows -&gt; Universal** node.
3.  In the center pane, choose **Blank App**.
4.  In the **Name** box, enter **NavApp1**, and then choose the **OK** button.

    The solution is created and the project files appear in **Solution Explorer**.

    **Important**  When you run Visual Studio for the first time, it prompts you to obtain a developer license. For more info, see [Enable your device for development](https://msdn.microsoft.com/library/windows/apps/dn706236).

     

5.  To run the program, choose **Debug** &gt; **Start Debugging** from the menu, or press F5.

    A blank page is displayed.

6.  Press Shift+F5 to stop debugging and return to Visual Studio.

## <span id="Add_basic_pages"></span><span id="add_basic_pages"></span><span id="ADD_BASIC_PAGES"></span>Add basic pages


Next, add two content pages to the project.

Do the following steps two times to add two pages to navigate between.

1.  In **Solution Explorer**, right-click the **BlankApp** project node to open the shortcut menu.
2.  Choose **Add** &gt; **New Item** from the shortcut menu.
3.  In the **Add New Item** dialog box, choose **Blank Page** in the middle pane.
4.  In the **Name** box, enter **Page1** (or **Page2**) and press the **Add** button.

These files should now be listed as part of your NavApp1 project.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">CS</th>
<th align="left">C++</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><ul>
<li>Page1.xaml</li>
<li>Page1.xaml.cs</li>
<li>Page2.xaml</li>
<li>Page2.xaml.cs</li>
</ul></td>
<td align="left"><ul>
<li>Page1.xaml</li>
<li>Page1.xaml.cpp</li>
<li>Page1.xaml.h</li>
<li>Page2.xaml</li>
<li>Page2.xaml.cpp</li>
<li>Page2.xaml.h
<div class="alert">
<strong>Note</strong>
          <p>Functions are declared in the header (.h) file and implemented in the code-behind file (.cpp).</p>
</div>
<div>
 
</div></li>
</ul></td>
</tr>
</tbody>
</table>

 

Add the following content to the UI of Page1.xaml.

-   Add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element named `pageTitle` as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704). Change the [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) property to `Page 1`.

```    XAML
<TextBlock x:Name="pageTitle" Text="Page 1" /></code></pre></td>
    </tr>
    </tbody>
    </table>
```

-   Add the following [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) element as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) and after the `pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element.

    <span codelanguage="XAML"></span>
```    XAML
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">XAML</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
<HyperlinkButton HorizontalAlignment="Center" Content="Click to go to page 2" Click="HyperlinkButton_Click"/></code></pre></td>
    </tr>
    </tbody>
    </table>
```

Add the following code to the `Page1` class in the Page1.xaml code-behind file to handle the `Click` event of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) you added previously. Here, we navigate to Page2.xaml.

<span codelanguage="ManagedCPlusPlus"></span>
```ManagedCPlusPlus
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">C++</th>
</tr>
</thead>
<tbody>
<tr class="odd">
void Page1::HyperlinkButton_Click_nodata(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid));
}
```

```CSharp
private void HyperlinkButton_Click_nodata(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2));
}
```

Make the following changes to the UI of Page2.xaml.

-   Add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element named `pageTitle` as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704). Change the value of the [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) property to `Page 2`.

```    XAML
<TextBlock x:Name="pageTitle" Text="Page 2" /></code></pre></td>
    </tr>
    </tbody>
    </table>
```

-   Add the following [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) element as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) and after the `pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element.

    <span codelanguage="XAML"></span>
```    XAML
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">XAML</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
<HyperlinkButton HorizontalAlignment="Center" Content="Click to go to page 1" Click="HyperlinkButton_Click"/></code></pre></td>
    </tr>
    </tbody>
    </table>
```

Add the following code to the `Page2` class in the Page2.xaml code-behind file to handle the `Click` event of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) you added previously. Here, we navigate to Page1.xaml.

**Note**  
For C++ projects, you must add a `#include` directive in the header file of each page that references another page. For the inter-page navigation example presented here, page1.xaml.h file contains `#include "Page2.xaml.h"`, in turn, page2.xaml.h contains `#include "Page1.xaml.h"`.

 

<span codelanguage="ManagedCPlusPlus"></span>
```ManagedCPlusPlus
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">C++</th>
</tr>
</thead>
<tbody>
<tr class="odd">
void Page2::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid));
}
```

```CSharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page1));
}
```

Now that we've prepared the content pages, we need to make Page1.xaml display when the app starts.

Open the app.xaml code-behind file and change the `OnLaunched` handler.

Here, we specify `Page1` in the call to [**Frame.Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) instead of `MainPage`.

```ManagedCPlusPlus
/// <summary>
/// Invoked when the application is launched normally by the end user. 
/// Other entry points will be used in specific cases, such as when the 
/// application is launched to open a specific file.
/// </summary>
/// <param name="e">Details about the launch request and process.</param>
void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e)
{
    auto rootFrame = dynamic_cast<Frame^>(Window::Current->Content);

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == nullptr)
    {
        // Create a Frame to act as the navigation context and associate it with
        // a SuspensionManager key
        rootFrame = ref new Frame();

        rootFrame->NavigationFailed += 
            ref new Windows::UI::Xaml::Navigation::NavigationFailedEventHandler(
                this, &amp;App::OnNavigationFailed);

        if (e->PreviousExecutionState == ApplicationExecutionState::Terminated)
        {
            // TODO: Load state from previously suspended application
        }

        
        // Place the frame in the current Window
        Window::Current->Content = rootFrame;

    }

    if (rootFrame->Content == nullptr)
    {
        // When the navigation stack isn&#39;t restored navigate to the first page,
        // configuring the new page by passing required information as a navigation
        // parameter
        rootFrame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid), e->Arguments);
    }

    // Ensure the current window is active
    Window::Current->Activate();
}
```

```CSharp
/// <summary>
/// Invoked when the application is launched normally by the end user. 
/// Other entry points will be used in specific cases, such as when the 
/// application is launched to open a specific file.
/// </summary>
/// <param name="e">Details about the launch request and process.</param>
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == null)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
    }

    if (rootFrame.Content == null)
    {
        // When the navigation stack isn&#39;t restored navigate to the first page,
        // configuring the new page by passing required information as a navigation
        // parameter
        rootFrame.Navigate(typeof(Page1), e.Arguments);
    }
    // Ensure the current window is active
    Window.Current.Activate();
}
```

**Note**  The code here uses the return value of [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) to throw an app exception if the navigation to the app's initial window frame fails. When **Navigate** returns **true**, the navigation happens.

 

Now, build and run the app. Click the link that says "Click to go to page 2". The second page that says "Page 2" at the top should be loaded and displayed in the frame.

## <span id="Frame_and_Page_classes"></span><span id="frame_and_page_classes"></span><span id="FRAME_AND_PAGE_CLASSES"></span>Frame and Page classes


Before we add more functionality to our app, let's look at how the pages we added provide navigation support for the app.

First, a [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) (`rootFrame`) is created for the app in the `App.OnLaunched` method of the App.xaml code-behind file. The [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) method is used to display content in this **Frame**.

**Note**  
The [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) class supports various navigation methods such as [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694), [**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568), and [**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693), and properties such as [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543), [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547), and [**BackStackDepth**](https://msdn.microsoft.com/library/windows/apps/hh967995).

 

In our example, `Page1` is passed to the [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) method. This method sets the content of the app's current window to the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) and loads the content of the page you specify into the **Frame** (Page1.xaml in our example, or MainPage.xaml, by default).

`Page1` is a subclass of the [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) class. The **Page** class has a read-only [**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504) property that gets the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) containing the **Page**. When the [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) event handler of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) calls` Frame.Navigate(typeof(Page2))`, the **Frame** in the app's window displays the content of Page2.xaml.

Whenever a page is loaded into the frame, that page is added as a [**PageStackEntry**](https://msdn.microsoft.com/library/windows/apps/dn298572) to the [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543) or [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547) of the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504).

## <span id="Pass_information_between_pages"></span><span id="pass_information_between_pages"></span><span id="PASS_INFORMATION_BETWEEN_PAGES"></span>Pass information between pages


Our app navigates between two pages, but it really doesn't do anything interesting yet. Often, when an app has multiple pages, the pages need to share information. Let's pass some information from the first page to the second page.

In Page1.xaml, replace the the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) you added earlier with the following [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635).

Here, we add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) label and a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) (`name`) for entering a text string.

```XAML
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Text="Enter your name"/>
    <TextBox HorizontalAlignment="Center" Width="200" Name="name"/>
    <HyperlinkButton HorizontalAlignment="Center" Content="Click to go to page 2" Click="HyperlinkButton_Click"/>
</StackPanel>
```

In the `HyperlinkButton_Click` event handler of the Page1.xaml code-behind file, add a parameter referencing the `Text` property of the `name` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) to the `Navigate` method.

```ManagedCPlusPlus
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid), name->Text);
}
```

```CSharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2), name.Text);
}
```

In the Page2.xaml code-behind file, override the `OnNavigatedTo` method with the following:

```ManagedCPlusPlus
void Page2::OnNavigatedTo(NavigationEventArgs^ e)
{
    if (dynamic_cast<Platform::String^>(e->Parameter) != nullptr)
    {
        greeting->Text = "Hi," + e->Parameter->ToString();
    }
    else
    {
        greeting->Text = "Hi!";
    }
    ::Windows::UI::Xaml::Controls::Page::OnNavigatedTo(e);
}
```

```CSharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if (e.Parameter is string)
    {
        greeting.Text = "Hi, " + e.Parameter.ToString();
    }
    else
    {
        greeting.Text = "Hi!";
    }
    base.OnNavigatedTo(e);
}
```

Run the app, type your name in the text box, and then click the link that says **Click to go to page 2**. When you called `this.Frame.Navigate(typeof(Page2), tb1.Text)` in the [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) event of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739), the `name.Text` property was passed to `Page2` and the value from the event data is used for the message displayed on the page.

## <span id="Cache_a__page"></span><span id="cache_a__page"></span><span id="CACHE_A__PAGE"></span>Cache a page


Page content and state is not cached by default, you must enable it in each page of your app.

In our basic peer-to-peer example, there is no back button (we demonstrate back navigation in [Back button navigation](navigation-history-and-backwards-navigation.md)), but if you did click a back button on `Page2`, the [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) (and any other field) on `Page1` would be set to its default state. One way to work around this is to use the [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) property to specify that a page be added to the frame's page cache.

In the constructor of `Page1`, set [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) to [**Enabled**](https://msdn.microsoft.com/library/windows/apps/br243284). This retains all content and state values for the page until the page cache for the frame is exceeded.

Set [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) to [**Required**](https://msdn.microsoft.com/library/windows/apps/br243284) if you want to ignore cache size limits for the frame. However, cache size limits might be crucial, depending on the memory limits of a device.

**Note**  The [**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) property specifies the number of pages in the navigation history that can be cached for the frame.

 

```ManagedCPlusPlus
Page1::Page1()
{
    this->InitializeComponent();
    this->NavigationCacheMode = Windows::UI::Xaml::Navigation::NavigationCacheMode::Enabled;
}
```

```CSharp
public Page1()
{
    this.InitializeComponent();
    this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
}
```

## <span id="related_topics"></span>Related articles

* [Navigation design basics for UWP apps](https://msdn.microsoft.com/library/windows/apps/dn958438)
* [Guidelines for tabs and pivots](https://msdn.microsoft.com/library/windows/apps/dn997788)
* [Guidelines for navigation panes](https://msdn.microsoft.com/library/windows/apps/dn997766)
 

 






<!--HONumber=Mar16_HO1-->


