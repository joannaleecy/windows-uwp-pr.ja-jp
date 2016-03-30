---
Xxxxxxxxxxx: Xxxxx xxx xx xxxxxxxx xx x xxxxx xxx xxxx xxxx-xx-xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
xxxxx: Xxxx-xx-xxxx xxxxxxxxxx xxxxxxx xxx xxxxx
xx.xxxxxxx: YXYYYXYX-YYYX-YYYY-YYYY-YYYYYXYXXYYY
xxxxx: Xxxx-xx-xxxx xxxxxxxxxx xxxxxxx xxx xxxxx
xxxxxxxx: xxxxxx.xxx
---

# <span id="dev_navigation.peer-to-peer_navigation_between_two_pages">
            </span>Xxxx-xx-xxxx xxxxxxxxxx xxxxxxx xxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxx xx xxxxxxxx xx x xxxxx xxx xxxx xxxx-xx-xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.

![xxx-xxxx xxxx-xx-xxxx xxxxxxxxxx xxxxxxx](images/nav-peertopeer-2page.png)


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.XX.Xxxx.Xxxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242682)
-   [**Xxxxxxx.XX.Xxxx.Xxxxxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/br227503)
-   [**Xxxxxxx.XX.Xxxx.Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243300)


## <span id="Create_the_blank_app">
            </span>
            <span id="create_the_blank_app">
            </span>
            <span id="CREATE_THE_BLANK_APP">
            </span>Xxxxxx xxx xxxxx xxx


1.  Xx xxx Xxxxxxxxx Xxxxxx Xxxxxx xxxx, xxxxxx **Xxxx &xx; Xxx Xxxxxxx**.
2.  Xx xxx xxxx xxxx xx xxx **Xxx Xxxxxxx** xxxxxx xxx, xxxxxx xxx **Xxxxxx X# -&xx; Xxxxxxx -&xx; Xxxxxxxxx** xx xxx **Xxxxxx X++ -&xx; Xxxxxxx -&xx; Xxxxxxxxx** xxxx.
3.  Xx xxx xxxxxx xxxx, xxxxxx **Xxxxx Xxx**.
4.  Xx xxx **Xxxx** xxx, xxxxx **XxxXxxY**, xxx xxxx xxxxxx xxx **XX** xxxxxx.

    Xxx xxxxxxxx xx xxxxxxx xxx xxx xxxxxxx xxxxx xxxxxx xx **Xxxxxxxx Xxxxxxxx**.

    **Xxxxxxxxx**  Xxxx xxx xxx Xxxxxx Xxxxxx xxx xxx xxxxx xxxx, xx xxxxxxx xxx xx xxxxxx x xxxxxxxxx xxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxx xxxx xxxxxx xxx xxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn706236).

     

5.  Xx xxx xxx xxxxxxx, xxxxxx **Xxxxx** &xx; **Xxxxx Xxxxxxxxx** xxxx xxx xxxx, xx xxxxx XY.

    X xxxxx xxxx xx xxxxxxxxx.

6.  Xxxxx Xxxxx+XY xx xxxx xxxxxxxxx xxx xxxxxx xx Xxxxxx Xxxxxx.

## <span id="Add_basic_pages">
            </span>
            <span id="add_basic_pages">
            </span>
            <span id="ADD_BASIC_PAGES">
            </span>Xxx xxxxx xxxxx


Xxxx, xxx xxx xxxxxxx xxxxx xx xxx xxxxxxx.

Xx xxx xxxxxxxxx xxxxx xxx xxxxx xx xxx xxx xxxxx xx xxxxxxxx xxxxxxx.

1.  Xx **Xxxxxxxx Xxxxxxxx**, xxxxx-xxxxx xxx **XxxxxXxx** xxxxxxx xxxx xx xxxx xxx xxxxxxxx xxxx.
2.  Xxxxxx **Xxx** &xx; **Xxx Xxxx** xxxx xxx xxxxxxxx xxxx.
3.  Xx xxx **Xxx Xxx Xxxx** xxxxxx xxx, xxxxxx **Xxxxx Xxxx** xx xxx xxxxxx xxxx.
4.  Xx xxx **Xxxx** xxx, xxxxx **XxxxY** (xx **XxxxY**) xxx xxxxx xxx **Xxx** xxxxxx.

Xxxxx xxxxx xxxxxx xxx xx xxxxxx xx xxxx xx xxxx XxxXxxY xxxxxxx.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XX</th>
<th align="left">X++</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><ul>
<li>XxxxY.xxxx</li>
<li>XxxxY.xxxx.xx</li>
<li>XxxxY.xxxx</li>
<li>XxxxY.xxxx.xx</li>
</ul></td>
<td align="left"><ul>
<li>XxxxY.xxxx</li>
<li>XxxxY.xxxx.xxx</li>
<li>XxxxY.xxxx.x</li>
<li>XxxxY.xxxx</li>
<li>XxxxY.xxxx.xxx</li>
<li>XxxxY.xxxx.x
<div class="alert">
<strong>Xxxx</strong><p>Xxxxxxxxx xxx xxxxxxxx xx xxx xxxxxx (.x) xxxx xxx xxxxxxxxxxx xx xxx xxxx-xxxxxx xxxx (.xxx).</p>
</div>
<div>
 
</div></li>
</ul></td>
</tr>
</tbody>
</table>

 

Xxx xxx xxxxxxxxx xxxxxxx xx xxx XX xx XxxxY.xxxx.

-   Xxx x [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xxxxxxx xxxxx `pageTitle` xx x xxxxx xxxxxxx xx xxx xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br242704). Xxxxxx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br209676) xxxxxxxx xx `Page 1`.

```    XAML
<TextBlock x:Name="pageTitle" Text="Page 1" /></code></pre></td>
    </tr>
    </tbody>
    </table>
```

-   Xxx xxx xxxxxxxxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242739) xxxxxxx xx x xxxxx xxxxxxx xx xxx xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br242704) xxx xxxxx xxx `pageTitle`[**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xxxxxxx.

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

Xxx xxx xxxxxxxxx xxxx xx xxx `Page1` xxxxx xx xxx XxxxY.xxxx xxxx-xxxxxx xxxx xx xxxxxx xxx `Click` xxxxx xx xxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242739) xxx xxxxx xxxxxxxxxx. Xxxx, xx xxxxxxxx xx XxxxY.xxxx.

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

Xxxx xxx xxxxxxxxx xxxxxxx xx xxx XX xx XxxxY.xxxx.

-   Xxx x [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xxxxxxx xxxxx `pageTitle` xx x xxxxx xxxxxxx xx xxx xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br242704). Xxxxxx xxx xxxxx xx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br209676) xxxxxxxx xx `Page 2`.

```    XAML
<TextBlock x:Name="pageTitle" Text="Page 2" /></code></pre></td>
    </tr>
    </tbody>
    </table>
```

-   Xxx xxx xxxxxxxxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242739) xxxxxxx xx x xxxxx xxxxxxx xx xxx xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br242704) xxx xxxxx xxx `pageTitle`[**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xxxxxxx.

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

Xxx xxx xxxxxxxxx xxxx xx xxx `Page2` xxxxx xx xxx XxxxY.xxxx xxxx-xxxxxx xxxx xx xxxxxx xxx `Click` xxxxx xx xxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242739) xxx xxxxx xxxxxxxxxx. Xxxx, xx xxxxxxxx xx XxxxY.xxxx.

**Xxxx**  
Xxx X++ xxxxxxxx, xxx xxxx xxx x `#include` xxxxxxxxx xx xxx xxxxxx xxxx xx xxxx xxxx xxxx xxxxxxxxxx xxxxxxx xxxx. Xxx xxx xxxxx-xxxx xxxxxxxxxx xxxxxxx xxxxxxxxx xxxx, xxxxY.xxxx.x xxxx xxxxxxxx `#include "Page2.xaml.h"`, xx xxxx, xxxxY.xxxx.x xxxxxxxx `#include "Page1.xaml.h"`.

 

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

Xxx xxxx xx'xx xxxxxxxx xxx xxxxxxx xxxxx, xx xxxx xx xxxx XxxxY.xxxx xxxxxxx xxxx xxx xxx xxxxxx.

Xxxx xxx xxx.xxxx xxxx-xxxxxx xxxx xxx xxxxxx xxx `OnLaunched` xxxxxxx.

Xxxx, xx xxxxxxx `Page1` xx xxx xxxx xx [**Xxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242694) xxxxxxx xx `MainPage`.

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

**Xxxx**  Xxx xxxx xxxx xxxx xxx xxxxxx xxxxx xx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242694) xx xxxxx xx xxx xxxxxxxxx xx xxx xxxxxxxxxx xx xxx xxx'x xxxxxxx xxxxxx xxxxx xxxxx. Xxxx **Xxxxxxxx** xxxxxxx **xxxx**, xxx xxxxxxxxxx xxxxxxx.

 

Xxx, xxxxx xxx xxx xxx xxx. Xxxxx xxx xxxx xxxx xxxx "Xxxxx xx xx xx xxxx Y". Xxx xxxxxx xxxx xxxx xxxx "Xxxx Y" xx xxx xxx xxxxxx xx xxxxxx xxx xxxxxxxxx xx xxx xxxxx.

## <span id="Frame_and_Page_classes">
            </span>
            <span id="frame_and_page_classes">
            </span>
            <span id="FRAME_AND_PAGE_CLASSES">
            </span>Xxxxx xxx Xxxx xxxxxxx


Xxxxxx xx xxx xxxx xxxxxxxxxxxxx xx xxx xxx, xxx'x xxxx xx xxx xxx xxxxx xx xxxxx xxxxxxx xxxxxxxxxx xxxxxxx xxx xxx xxx.

Xxxxx, x [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242682) (`rootFrame`) xx xxxxxxx xxx xxx xxx xx xxx `App.OnLaunched` xxxxxx xx xxx Xxx.xxxx xxxx-xxxxxx xxxx. Xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242694) xxxxxx xx xxxx xx xxxxxxx xxxxxxx xx xxxx **Xxxxx**.

**Xxxx**  
Xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242682) xxxxx xxxxxxxx xxxxxxx xxxxxxxxxx xxxxxxx xxxx xx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242694), [**XxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn996568), xxx [**XxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242693), xxx xxxxxxxxxx xxxx xx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279543), [**XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279547), xxx [**XxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh967995).

 

Xx xxx xxxxxxx, `Page1` xx xxxxxx xx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242694) xxxxxx. Xxxx xxxxxx xxxx xxx xxxxxxx xx xxx xxx'x xxxxxxx xxxxxx xx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242682) xxx xxxxx xxx xxxxxxx xx xxx xxxx xxx xxxxxxx xxxx xxx **Xxxxx** (XxxxY.xxxx xx xxx xxxxxxx, xx XxxxXxxx.xxxx, xx xxxxxxx).

`Page1` xx x xxxxxxxx xx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br227503) xxxxx. Xxx **Xxxx** xxxxx xxx x xxxx-xxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227504) xxxxxxxx xxxx xxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242682) xxxxxxxxxx xxx **Xxxx**. Xxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227737) xxxxx xxxxxxx xx xxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242739) xxxxx` Frame.Navigate(typeof(Page2))`, xxx **Xxxxx** xx xxx xxx'x xxxxxx xxxxxxxx xxx xxxxxxx xx XxxxY.xxxx.

Xxxxxxxx x xxxx xx xxxxxx xxxx xxx xxxxx, xxxx xxxx xx xxxxx xx x [**XxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298572) xx xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279543) xx [**XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279547) xx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227504).

## <span id="Pass_information_between_pages">
            </span>
            <span id="pass_information_between_pages">
            </span>
            <span id="PASS_INFORMATION_BETWEEN_PAGES">
            </span>Xxxx xxxxxxxxxxx xxxxxxx xxxxx


Xxx xxx xxxxxxxxx xxxxxxx xxx xxxxx, xxx xx xxxxxx xxxxx'x xx xxxxxxxx xxxxxxxxxxx xxx. Xxxxx, xxxx xx xxx xxx xxxxxxxx xxxxx, xxx xxxxx xxxx xx xxxxx xxxxxxxxxxx. Xxx'x xxxx xxxx xxxxxxxxxxx xxxx xxx xxxxx xxxx xx xxx xxxxxx xxxx.

Xx XxxxY.xxxx, xxxxxxx xxx xxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242739) xxx xxxxx xxxxxxx xxxx xxx xxxxxxxxx [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209635).

Xxxx, xx xxx x [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xxxxx xxx x [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683) (`name`) xxx xxxxxxxx x xxxx xxxxxx.

```XAML
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Text="Enter your name"/>
    <TextBox HorizontalAlignment="Center" Width="200" Name="name"/>
    <HyperlinkButton HorizontalAlignment="Center" Content="Click to go to page 2" Click="HyperlinkButton_Click"/>
</StackPanel>
```

Xx xxx `HyperlinkButton_Click` xxxxx xxxxxxx xx xxx XxxxY.xxxx xxxx-xxxxxx xxxx, xxx x xxxxxxxxx xxxxxxxxxxx xxx `Text` xxxxxxxx xx xxx `name`[**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683) xx xxx `Navigate` xxxxxx.

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

Xx xxx XxxxY.xxxx xxxx-xxxxxx xxxx, xxxxxxxx xxx `OnNavigatedTo` xxxxxx xxxx xxx xxxxxxxxx:

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

Xxx xxx xxx, xxxx xxxx xxxx xx xxx xxxx xxx, xxx xxxx xxxxx xxx xxxx xxxx xxxx **Xxxxx xx xx xx xxxx Y**. Xxxx xxx xxxxxx `this.Frame.Navigate(typeof(Page2), tb1.Text)` xx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227737) xxxxx xx xxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242739), xxx `name.Text` xxxxxxxx xxx xxxxxx xx `Page2` xxx xxx xxxxx xxxx xxx xxxxx xxxx xx xxxx xxx xxx xxxxxxx xxxxxxxxx xx xxx xxxx.

## <span id="Cache_a__page">
            </span>
            <span id="cache_a__page">
            </span>
            <span id="CACHE_A__PAGE">
            </span>Xxxxx x xxxx


Xxxx xxxxxxx xxx xxxxx xx xxx xxxxxx xx xxxxxxx, xxx xxxx xxxxxx xx xx xxxx xxxx xx xxxx xxx.

Xx xxx xxxxx xxxx-xx-xxxx xxxxxxx, xxxxx xx xx xxxx xxxxxx (xx xxxxxxxxxxx xxxx xxxxxxxxxx xx [Xxxx xxxxxx xxxxxxxxxx](navigation-history-and-backwards-navigation.md)), xxx xx xxx xxx xxxxx x xxxx xxxxxx xx `Page2`, xxx [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683) (xxx xxx xxxxx xxxxx) xx `Page1` xxxxx xx xxx xx xxx xxxxxxx xxxxx. Xxx xxx xx xxxx xxxxxx xxxx xx xx xxx xxx [**XxxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227506) xxxxxxxx xx xxxxxxx xxxx x xxxx xx xxxxx xx xxx xxxxx'x xxxx xxxxx.

Xx xxx xxxxxxxxxxx xx `Page1`, xxx [**XxxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227506) xx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243284). Xxxx xxxxxxx xxx xxxxxxx xxx xxxxx xxxxxx xxx xxx xxxx xxxxx xxx xxxx xxxxx xxx xxx xxxxx xx xxxxxxxx.

Xxx [**XxxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227506) xx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243284) xx xxx xxxx xx xxxxxx xxxxx xxxx xxxxxx xxx xxx xxxxx. Xxxxxxx, xxxxx xxxx xxxxxx xxxxx xx xxxxxxx, xxxxxxxxx xx xxx xxxxxx xxxxxx xx x xxxxxx.

**Xxxx**  Xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242683) xxxxxxxx xxxxxxxxx xxx xxxxxx xx xxxxx xx xxx xxxxxxxxxx xxxxxxx xxxx xxx xx xxxxxx xxx xxx xxxxx.

 

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

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx

* [Xxxxxxxxxx xxxxxx xxxxxx xxx XXX xxxx](https://msdn.microsoft.com/library/windows/apps/dn958438)
* [Xxxxxxxxxx xxx xxxx xxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/dn997788)
* [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/dn997766)
 

 




<!--HONumber=Mar16_HO1-->
