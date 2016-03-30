---
Xxxxxxxxxxx: Xxxxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xx xxxxx xx x xxxxxxxx xxxxx xx xxxxxxxxxx xxxxxxxxxx, xxxxxxxxxx xxxxxxxx, xxx xxxxxx-xxxxx xxxxxxxx.
xxxxx: Xxxxxxxxxx xxxxxx xxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx
xx.xxxxxxx: xYYYYxYx-YYYx-YYYx-xYxx-YYYYYYYxxYxY
xxXxx: xxxx
xxxxx: Xxxxxxx xxx xxxxxxxxx xxxxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

#  Xxxxxxxxxx xxxxxxx xxx xxxxxxxxx xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xx xxx Xxx, xxxxxxxxxx xxx xxxxx xxxxxxx xxxxx xxx xxxxxxxxxx xxxxxxx, xxxx xx xxxxxx xx xxxxxxxx, xxxxxxx, xxxxx, xxxxxx xxxxx xx xxxxx, xxx xx xx. Xxx xxxxxxxxxx xxxxxxxxxx xxx xxxx xxxxxx xxxx xxxxxxx xx xxxxxxx. Xxxxxxx, xxxxx xx xxx xxxxxxxxxx xxxxxxxxxx xxxxxxxxxx: xxxx. Xxxx xxxxxxxx xxxxxxx x xxxx xxxxxx xxxx xxxxxxx xxx xxxx xxx xxxxxxxxxx xx xxx xxxxxxx.

Xxx xxxxxxx xxxxxxx, xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxxxx x xxxxxxxxxx xxxx xxxxxxxxxx xxxxxx xxx xxxxxxxxxx xxx xxxx'x xxxxxxxxxx xxxxxxx xxxxxx xx xxx xxx, xxxxxxxxx xx xxx xxxxxx, xxxx xxx xx xxx.

Xxx XX xxx xxx xxxxxx xxxx xxxxxx xx xxxxxxxxx xxx xxxx xxxx xxxxxx xxx xxxxx xxxxxx xxxx, xxx xxx xxxxxxxxxx xxxxxxxxxx xx xxxxxx xxx xxxxxxxxxx xxxxxx xxxxxxx xxx XXX xxxx.

Xxxx xxx xxx xxxxxxx xxxx xxxxxxx xxxx xxx xxxx xxxxxx XX:


<table>
    <tr>
        <td colspan="2">Xxxxxxx</td>
        <td>Xxxx xxxxxx xxxxxxxx</td>
     </tr>
    <tr>
        <td>Xxxxx</td>
        <td>![system back on a phone](images/back-systemback-phone.png)</td>
        <td>
        <ul>
<li>Xxxxxx xxxxxxx.</li>
<li>X xxxxxxxx xx xxxxxxxx xxxxxx xx xxx xxxxxx xx xxx xxxxxx.</li>
<li>Xxxxxx xxxx xxxxxxxxxx xxxxxx xxx xxx xxx xxxxxxx xxxx.</li>
</ul>
</td>
     </tr>
     <tr>
        <td>Xxxxxx</td>
        <td>![system back on a tablet (in tablet mode)](images/back-systemback-tablet.png)</td>
        <td>
<ul>
<li>Xxxxxx xxxxxxx xx Xxxxxx xxxx.

    Not available in Desktop mode. Title bar back button can be enabled, instead. See [PC, Laptop, Tablet](#PC).

    Users can switch between running in Tablet mode and Desktop mode by going to **Settings &gt; System &gt; Tablet mode** and setting **Make Windows more touch-friendly when using your device as a tablet**.</li>

<li> X xxxxxxxx xxxxxx xx xxx xxxxxxxxxx xxx xx xxx xxxxxx xx xxx xxxxxx.</li>
<li>Xxxxxx xxxx xxxxxxxxxx xxxxxx xxx xxx xxx xxxxxxx xxxx.</li></ul>        
        </td>
     </tr>
    <tr>
        <td>XX, Xxxxxx, Xxxxxx</td>
        <td>![system back on a pc or laptop](images/back-systemback-pc.png)</td>
        <td>
<ul>
<li>Xxxxxxxx xx Xxxxxxx xxxx.

    Not available in Tablet mode. See [Tablet](#Tablet).

    Disabled by default. Must opt in to enable it.

    Users can switch between running in Tablet mode and Desktop mode by going to **Settings &gt; System &gt; Tablet mode** and setting **Make Windows more touch-friendly when using your device as a tablet**.</li>

<li>X xxxxxxxx xxxxxx xx xxx xxxxx xxx xx xxx xxx.</li>
<li>Xxxx xxxxxxxxxx xxxxxx xxx xxx xxxx. Xxxx xxx xxxxxxx xxx-xx-xxx xxxxxxxxxx.</li></ul>        
        </td>
     </tr>
    <tr>
        <td>Xxxxxxx Xxx</td>
        <td>![system back on a surface hub](images/nav/nav-back-surfacehub.png)</td>
        <td>
<ul>
<li>Xxxxxxxx.</li>
<li>Xxxxxxxx xx xxxxxxx. Xxxx xxx xx xx xxxxxx xx.</li>
<li>X xxxxxxxx xxxxxx xx xxx xxxxx xxx xx xxx xxx.</li>
<li>Xxxx xxxxxxxxxx xxxxxx xxx xxx xxxx. Xxxx xxx xxxxxxx xxx-xx-xxx xxxxxxxxxx.</li></ul>        
        </td>
     </tr>     
<table>


Xxxx xxx xxxx xxxxxxxxxxx xxxxx xxxxx xxxx xxx'x xxxx xx x xxxx xxxxxx XX, xxx xxxxx xxxxxxx xxx xxxxx xxxx xxxxxxxxxxxxx.


<table>
<tr><td colspan="3">Xxxxx xxxxxxx</td></tr>
<tr><td>Xxxxxxxx</td><td>![keyboard](images/keyboard-wireframe.png)</td><td>Xxxxxxx xxx + Xxxxxxxxx</td></tr>
<tr><td>Xxxxxxx</td><td>![speech](images/speech-wireframe.png)</td><td>Xxx, "Xxx Xxxxxxx, xx xxxx"</td></tr>
</table>
 

Xxxx xxxx xxx xxxx xx x xxxxx, xxxxxx, xx xx x XX xx xxxxxx xxxx xxx xxxxxx xxxx xxxxxxx, xxx xxxxxx xxxxxxxx xxxx xxx xxxx xxx xxxx xxxxxx xx xxxxxxx. Xxx xxxx xxxxxxx xxx xxxx xxxxxx xx xxxxxxxx xx xxx xxxxxxxx xxxxxxxx xx xxx xxx'x xxxxxxxxxx xxxxxxx. Xx'x xx xx xxx xx xxxxxx xxxxx xxxxxxxxxx xxxxxxx xx xxx xx xxx xxxxxxxxxx xxxxxxx xxx xxx xx xxxxxxx xx xxx xxxx xxxxxx xxxxx.


## <span id="Enable_system_back_navigation_support">
            </span>
            <span id="enable_system_back_navigation_support">
            </span>
            <span id="ENABLE_SYSTEM_BACK_NAVIGATION_SUPPORT">
            </span>Xxx xx xxxxxx xxxxxx xxxx xxxxxxxxxx xxxxxxx


Xxxx xxxx xxxxxx xxxx xxxxxxxxxx xxx xxx xxxxxxxx xxx xxxxxxxx xxxxxx xxxx xxxxxxx. Xx xxxx xx xxxxxxxxxxx x xxxxxxxx xxx xxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn893596) xxxxx xxx xxxxxxxx x xxxxxxxxxxxxx xxxxxxx.

Xxxx xx xxxxxxxx x xxxxxx xxxxxxxx xxx xxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn893596) xxxxx xx xxx Xxx.xxxx xxxx-xxxxxx xxxx. Xxx xxx xxxxxxxx xxx xxxx xxxxx xx xxxx xxxx xx xxx xxxx xx xxxxxxx xxxxxxxx xxxxx xxxx xxxx xxxxxxxxxx, xx xxx xxxx xx xxxxxxx xxxx-xxxxx xxxx xxxxxx xxxxxxxxxx xxx xxxx.

```CSharp
Windows::UI::Core::SystemNavigationManager::GetForCurrentView()->
    BackRequested += ref new Windows::Foundation::EventHandler<
    Windows::UI::Core::BackRequestedEventArgs^>(
        this, &amp;App::App_BackRequested);
```

```CSharp
Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += 
    App_BackRequested;
```

Xxxx'x xxx xxxxxxxxxxxxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn893596) xxxxx xxxxxxx xxxx xxxxx [**XxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn996568) xx xxx xxxx xxxxx xx xxx xxx.

Xxxx xxxxxxx xx xxxxxxx xx x xxxxxx xxxx xxxxx. Xx xxx xx-xxx xxxx xxxxx xx xxxxx, xxx xxxxxx xxxxx xxxxxxxx xx xxx xxxxxxxx xxx xx xxx xxx xxxxx xx xx xxx Xxxxx xxxxxx. Xxxxx xx xx xxx xxxx xxxxx xx Xxxxxxx xxxx xxx xxx xxxx xxxxx xx xxx xxx xxxx xxxx xxx xx-xxx xxxx xxxxx xx xxxxxxxx.

```CSharp
void App::App_BackRequested(
    Platform::Object^ sender, 
    Windows::UI::Core::BackRequestedEventArgs^ e)
{
    Frame^ rootFrame = dynamic_cast<Frame^>(Window::Current->Content);
    if (rootFrame == nullptr)
        return;

    // Navigate back if possible, and if the event has not
    // already been handled.
    if (rootFrame->CanGoBack &amp;&amp; e->Handled == false)
    {
        e->Handled = true;
        rootFrame->GoBack();
    }
}
```

```CSharp
private void App_BackRequested(object sender, 
    Windows.UI.Core.BackRequestedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;
    if (rootFrame == null)
        return;

    // Navigate back if possible, and if the event has not 
    // already been handled .
    if (rootFrame.CanGoBack &amp;&amp; e.Handled == false)
    {
        e.Handled = true;
        rootFrame.GoBack();
    }
}
```
## <span id="Enable_the_title_bar_back_button">
            </span>
            <span id="enable_the_title_bar_back_button">
            </span>
            <span id="ENABLE_THE_TITLE_BAR_BACK_BUTTON">
            </span>Xxx xx xxxxxx xxx xxxxx xxx xxxx xxxxxx


Xxxxxxx xxxx xxxxxxx Xxxxxxx xxxx (xxxxxxxxx XXx xxx xxxxxxx, xxx xxxx xxxx xxxxxxx) xxx xxxx xxx xxxxxxx xxxxxxx (**Xxxxxxxx &xx; Xxxxxx &xx; Xxxxxx xxxx**), xx xxx xxxxxxx x xxxxxx xxxxxxxxxx xxx xxxx xxx xxxxxx xxxx xxxxxx.

Xx Xxxxxxx xxxx, xxxxx xxx xxxx xx x xxxxxx xxxx x xxxxx xxx. Xxx xxx xxxxxxx xx xxxxxxxxxxx xxxx xxxxxx xxx xxxx xxx xxxx xx xxxxxxxxx xx xxxx xxxxx xxx.

Xxx xxxxx xxx xxxx xxxxxx xx xxxx xxxxxxxxx xx xxxx xxxxxxx xx xxxxxxx xx Xxxxxxx xxxx, xxx xxxx xxxxxxxx xx-xxx xxxxxxxxxx xxxxxxx—xx xxxx xxx xxxxxxx xxx-xx-xxx xxxxxxxxxx xxxxxxx.

**Xxxxxxxxx**  Xxx xxxxx xxx xxxx xxxxxx xx xxx xxxxxxxxx xx xxxxxxx. Xxx xxxx xxx xx.

 

|                                                             |                                                        |
|-------------------------------------------------------------|--------------------------------------------------------|
| ![xx xxxxxx xxxx xx xxxxxxx xxxx](images/nav-noback-pc.png) | ![xxxxxx xxxx xx xxxxxxx xxxx](images/nav-back-pc.png) |
| Xxxxxxx xxxx, xx xxxx xxxxxxxxxx.                           | Xxxxxxx xxxx, xxxx xxxxxxxxxx xxxxxxx.                 |

 

Xxxxxxxx xxx [**XxXxxxxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br227508) xxxxx xxx xxx [**XxxXxxxXxxxXxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn986448) xx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn986276) xx xxx xxxx-xxxxxx xxxx xxx xxxx xxxx xxxx xxx xxxx xx xxxxxx xxx xxxxx xxx xxxx xxxxxx.

Xxx xxxx xxxxxxx, xx xxxx xxxx xxxx xx xxx xxxx xxxxx xxx xxxxxx xxx xxxx xxxxxx xx xxx [**XxxXxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242685) xxxxxxxx xx xxx xxxxx xxx x xxxxx xx **xxxx**.

```ManagedCPlusPlus
void StartPage::OnNavigatedTo(NavigationEventArgs^ e)
{
    auto rootFrame = dynamic_cast<Windows::UI::Xaml::Controls::Frame^>(Window::Current->Content);

    Platform::String^ myPages = "";

    if (rootFrame == nullptr)
        return;

    for each (PageStackEntry^ page in rootFrame->BackStack)
    {
        myPages += page->SourcePageType.ToString() + "\n";
    }
    stackCount->Text = myPages;

    if (rootFrame->CanGoBack)
    {
        // If we have pages in our in-app backstack and have opted in to showing back, do so
        Windows::UI::Core::SystemNavigationManager::GetForCurrentView()->AppViewBackButtonVisibility =
            Windows::UI::Core::AppViewBackButtonVisibility::Visible;
    }
    else
    {
        // Remove the UI from the title bar if there are no pages in our in-app back stack
        Windows::UI::Core::SystemNavigationManager::GetForCurrentView()->AppViewBackButtonVisibility =
            Windows::UI::Core::AppViewBackButtonVisibility::Collapsed;
    }
}
```

```CSharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;

    string myPages = "";
    foreach (PageStackEntry page in rootFrame.BackStack)
    {
        myPages += page.SourcePageType.ToString() + "\n";
    }
    stackCount.Text = myPages;

    if (rootFrame.CanGoBack)
    {
        // Show UI in title bar if opted-in and in-app backstack is not empty.
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = 
            AppViewBackButtonVisibility.Visible;
    }
    else
    {
        // Remove the UI from the title bar if in-app back stack is empty.
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = 
            AppViewBackButtonVisibility.Collapsed;
    }
}
```

### Xxxxxxxxxx xxx xxxxxx xxxx xxxxxxxxxx xxxxxxxx

Xx xxx xxxxxx xx xxxxxxx xxxx xxx xxxx xxxxx xxxxxxxxxx, xxx xxxxxxxxxx xxxxxx xx xxxxxxxxxx xxxx xxxxx xxxx. Xx xxxxxxxxx xxxx xxx xxxxxx xxx xxxxxxxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxx:

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Xxxxxxxxxx xxxxxx</th>
<th align="left">Xxx xx xxxxxxxxxx xxxxxxx?</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><strong>Xxxx xx xxxx, xxxxxxxxx xxxx xxxxxx</strong></p></td>
<td align="left"><strong>Xxx</strong><p>Xx xxxx xxxxxxxxxxxx, xxx xxxx xxxxxxxxx xxxx xxxxx Y xx xxx xxx xx xxxxx Y, xxxxxxxx xxxx xxxxxx, xx xxx xxxxxxxxxx xx xxxxx xx xxx xxxxxxxxxx xxxxxxx.</p>
<p><img src="images/nav/nav-pagetopage-diffpeers-imageonly1.png" alt="Navigation across peer groups" /></p>
<p>Xx xxx xxxx xxxxxxxxxxxx, xxx xxxx xxxxxxxxx xxxxxxx xxx xxxx xxxxxx xx xxx xxxx xxxxx, xxxxx xxxxxxxx xxxx xxxxxx, xx xxx xxxxxxxxxx xx xxxxx xx xxx xxxxxxxxxx xxxxxxx.</p>
<p><img src="images/nav/nav-pagetopage-diffpeers-imageonly2.png" alt="Navigation across peer groups" /></p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>Xxxx xx xxxx, xxxx xxxx xxxxx, xx xx-xxxxxx xxxxxxxxxx xxxxxxx</strong></p>
<p>Xxx xxxx xxxxxxxxx xxxx xxx xxxx xx xxxxxxx xxxx xxx xxxx xxxx xxxxx. Xxxxx xx xx xxxxxxxxxx xxxxxxx xxxx xx xxxxxx xxxxxxx (xxxx xx xxxx/xxxxxx xx x xxxxxx xxxxxxxxxx xxxx) xxxx xxxxxxxx xxxxxx xxxxxxxxxx xx xxxx xxxxx.</p></td>
<td align="left"><strong>Xxx</strong><p>Xx xxx xxxxxxxxx xxxxxxxxxxxx, xxx xxxx xxxxxxxxx xxxxxxx xxx xxxxx xx xxx xxxx xxxx xxxxx. Xxx xxxxx xxx'x xxx xxxx xx x xxxxxx xxxxxxxxxx xxxx, xx xxx xxxxxxxxxx xx xxxxx xx xxx xxxxxxxxxx xxxxxxx.</p>
<p><img src="images/nav/nav-pagetopage-samepeer-noosnavelement.png" alt="Navigation within a peer group" /></p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong>Xxxx xx xxxx, xxxx xxxx xxxxx, xxxx xx xx-xxxxxx xxxxxxxxxx xxxxxxx</strong></p>
<p>Xxx xxxx xxxxxxxxx xxxx xxx xxxx xx xxxxxxx xx xxx xxxx xxxx xxxxx. Xxxx xxxxx xxx xxxxx xx xxx xxxx xxxxxxxxxx xxxxxxx. Xxx xxxxxxx, xxxx xxxxx xxx xxx xxxx xxxx/xxxxxx xxxxxxx, xx xxxx xxxxx xxxxxx xx x xxxxxx xxxxxxxxxx xxxx.</p></td>
<td align="left"><strong>Xx</strong><p>Xxxx xxx xxxx xxxxxxx xxxx, xx xxxx xx xxx xxxx xxxx xxxxxx xxx xxxx xxxxxxxxx xx xxx xxxxxxx xxxx xxxxx.</p>
<p><img src="images/nav/nav-pagetopage-samepeer-yesosnavelement.png" alt="Navigation across peer groups when a navigation element is present" /></p></td>
</tr>
<tr class="even">
<td align="left"><strong>Xxxx x xxxxxxxxx XX</strong><p>Xxx xxx xxxxxxxx x xxx-xx xx xxxxx xxxxxx, xxxx xx x xxxxxx, xxxxxx xxxxxx, xx xx-xxxxxx xxxxxxxx, xx xxx xxx xxxxxx x xxxxxxx xxxx, xxxx xx xxxxxxxx xxxxxxxxx xxxx.</p></td>
<td align="left"><strong>Xx</strong><p>Xxxx xxx xxxx xxxxxxx xxx xxxx xxxxxx, xxxxxxx xxx xxxxxxxxx XX (xxxx xxx xx-xxxxxx xxxxxxxx, xxxxxx xxx xxxxxx, xxx) xxx xxxxxx xx xxx xxxx xxxx xxxxxxx xxx xxxxxxxxx XX.</p>
<p><img src="images/back-transui.png" alt="Showing a transient UI" /></p></td>
</tr>
<tr class="odd">
<td align="left"><strong>Xxxxxxxxx xxxxx</strong><p>Xxx xxx xxxxxxxx xxxxxxx xxx xx xx-xxxxxx xxxx, xxxx xx xxx xxxxxxx xxx xxx xxxxxxxx xxxx xx xxxxxx/xxxxxxx xxxx.</p></td>
<td align="left"><strong>Xx.</strong><p>Xxxxxxxxxxx xxxxx xx xxxxxxx xx xxxxxxxxxx xxxxxx x xxxx xxxxx. Xxxx xxx xxxx xxxxxxx xxxx, xxxxxxxx xx xxx xxxx xxxx xxxxxxxx xxx xxxxxxx xxxx xxxx xxx xxx xxxx xxxxxxxxxxx.</p>
<img src="images/nav/nav-enumerate.png" alt="Iterm enumeration" /></td>
</tr>
</tbody>
</table>


### <span id="Resuming">
            </span>
            <span id="resuming">
            </span>
            <span id="RESUMING">
            </span>Xxxxxxxx

Xxxx xxx xxxx xxxxxxxx xx xxxxxxx xxx xxx xxxxxxx xx xxxx xxx, xx xxxxxxxxx xxxxxxxxx xx xxx xxxx xxxx xx xxx xxxxxxxxxx xxxxxxx.


\[Xxxx xxxxxxx xxxxxxxx xxxxxxxxxxx xxxx xx xxxxxxxx xx XXX xxxx xxx Xxxxxxx YY. Xxx Xxxxxxx Y.Y xxxxxxxx, xxxxxx xxxxxxxx xxx [Xxxxxxx Y.Y xxxxxxxxxx XXX](https://go.microsoft.com/fwlink/p/?linkid=258743).\]



 




<!--HONumber=Mar16_HO1-->
