---
xxxxx: Xxxxxxx Xxxxxx xx Xxxxxxx Xxxxxxx Xxxxxxxxxx
xx.xxxxxxx: YXYYYYXY-YXYX-YYYY-XYXX-XYYYYYXYYYYY
xxxxxxxxxxx: 
---

# Xxxxxxx Xxxxxx xx Xxxxxxx Xxxxxxx Xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


\[Xxxx xxxxxxxxxxx xxxxxxx xx xxx-xxxxxxxx xxxxxxx xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxx xxxxxx xx'x xxxxxxxxxxxx xxxxxxxx. Xxxxxxxxx xxxxx xx xxxxxxxxxx, xxxxxxx xx xxxxxxx, xxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xxxx.\]

Xx xxxx Xxxxxxx Xxxxxxx xxxxxxxxx xxxxxx xx xxxxx xx x xxxx-xxxxxxx xxxxxxxx xxxx xx x xxxxxxxxxx xxxxxx (xxxxxx xxxxxx) xxx xxx xxxx XxxxXxxxxx xx xx xxxx xx xxxxxxx xxx xxxxx, xxx xxx xxxxxxxxx xxx/xx xxxxx xx xx xxx xx xxxxx xxxx:

-   (Xxxxxx Y) Xxxxx xxx xxxxx xxxxxxx xxx [Xxxxxxx.XX.Xxxx.XxxxXxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx) xx xxxxxxx xxx xxxxx xx xxx XxxxXxxxxx xxxxxx xxxxxxx. Xxxxxxxx xxxxxxxxx xxxx xx xxx xxxx xxxxxx, xx xxxx xxxxxxxxx xx xxxxx xxx xxxxxxx xxx xxxxxxx xxxxxxxxxxx.
-   (Xxxxxx Y) Xxx [Xxxxxxx.Xxxxxxxxxx.XxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&xx;Xxxxxx&xx; xxx xxxx xxxx xxxxxxxxxxx (xxx xxxx xxx xxxxx xxxx xxxxxxxxxxx). Xx Xxxxxx Y xx xxx xxxxxxxx xx xxx xxxxxxxxxxx xx xxx xxxxxxxx, xxxx xxxx xx x xxxx xxxxxx xxxxxx xx xxxx xx xxxx xxxxxxxxxxx xx xxxxxxxxxx.
-   (Xxxxxx Y) Xxxxxx xxxx xxx xxxxx xxx xxxx xxx xxx xxxxxxxxx. Xxxx xxxxxx xx xxx xxxx xxxxxxxxx xx xxxxxxxxx, xxx xx xxxxxxxxx xxxx xxxxxxxxxxx xxx xxxxx xxxxxxx xxxxxx xxxxxxxxxxx xxxxxxxx xx Xxxxxx Y xx xxxxxxxxx xxxxxxxxx.

Xx xxx xxxx xxxxx xx xxxxx xx x xxxxxxxxxx xxxxxx xxxxxxx xxxxx xxx xx xxxxx xxxxxxx, x XxxxXxxxxx xxxxxx xxxx xxx xxxxxxx xxx xxxxx.

## Xxxxxxxxxx


Xxx Xxxxxxx Xxxxxxx xxxxxxxxxx xxx xxxx xxx xxxxxxxxxxxxx XXX xxxxxxx, xx xxxxxx xxxx xxxxxxxx xxx xxx xx xxxxxx xxxx. Xx xxx Xxxxxxx XXX, xxxx xx xxx xxxxxxxxxx xxx xxxxx XXX xxxxxxx xxxx xxx xxxxxxxxxxx xxxxxxx xxxx xxxx xxxxxxx xx xxx xxxxxxxxxx xxxxxx xxx xx xxx XX xxxxxx. Xx x XXX xxxxxx xxx’x xx xxxx xxxxx, xxxx xx xxxxxxxx xxxxxx xxxxxxx xxxxx xx xxxxxxx xxx xxxxx xx xxxxxxxxxxx xxxx xxxxx XXX xxxxxxx xxxxxx xxx XX xxxxxx-xxxxxxxxxx xxxxxx xxxxxxxx. (Xx XXX xxxxx, xxxx xx xxxxx xx xxxxxxxxxxxxx xxxxxxx xxxxxx xxxxxxxxxx.)

Xxxx xx xxx xxxxxxx xx xxx Xxxxxxx XXX xxx xxxxxx xxxxx xx xxxx xxxxxxx xxx xxxxx xxxxx xx. Xxxxxxx, xxxxxxx xxx xxxxx xxx’x xx xxxxxxx xxx xxxxxxx xxxxx xxxx xx Xxxxxxx.Xxxxxxxxxx.[XxxxxXxxxxXxxxxxx&xx;XXxxxxx, XXxxxxx&xx;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) xxxxxxx xxxx xxx xxx xxxxxxxx xxxxx xxxxx xxx xxxxxxx xxx xxxx xxxxxxxx. Xx'x xxxx xxxx XxxxXxxxxx xxxxxxx xxxx xxx xxxx xx xxxxxxx xx xxxxx xxxxxxx xx xxxxx, xxx xx xxx xxxx xxxx xxxxxxxxx xx xx xxxxxx xxxx XxxxXxxxxx xx xxxx xx xxxx X++ xx x .XXX xxxxxxxx, xxxx xxx xxxx xxx xxx xx xxx xxxxxxxxx xxxxx xxxxxxx.

## (Xxxxxx Y) Xxxxx xxx xxxxx xxxxxxx xxx XxxxXxxxxxxxxx


Xxx xxx xxxx xxxxxx xx xxx xxxx-xxxxxxx xxxxxxxx xxxx xx xxxxx xxx [Xxxxxxx.XX.Xxxx.XxxxXxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx), xxx XxxxXxxxxx xxxx xx xxxx xx xxxxxxx xxxx. Xx xxx xxx xxxxxx xxxxx xxxxxx xx xxx, xxx xxxx xxx xxxxx. Xx xxxxxxx xxxxxxx xxx xxxxx xxxxxx xxx xxx xxxxx xxxxxxxx xxxxxxx xx xxxxx, xxxx xxx xxx xx xxx xxxxx xxxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxx xxx xx xxx xxx XxxxXxxxxxxxxx xx xxxxx x xxxxxxxx-xxxxx xxxxx. Xxxxxx xxxx xxx xxxx xxxxxxxx xx Xxxxx, xxx Xxxxxx.

```csharp
public event EventHandler<Toast> ToastCompletedEvent;
private void OnToastCompleted(Toast args)
{
    var completedEvent = ToastCompletedEvent;
    if (completedEvent != null)
    {
        completedEvent(this, args);
    }
}

public void MakeToastWithDispatcher(string message)
{
    Toast toast = new Toast(message);
    // Assume you have a CoreDispatcher at class scope.
    // Initialize it here, then use it from the background thread.
    var window = Windows.UI.Core.CoreWindow.GetForCurrentThread();
    m_dispatcher = window.Dispatcher;

    Task.Run( () =>
    {
        if (ToastCompletedEvent != null)
        {
            m_dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            new DispatchedHandler(() =>
            {
                this.OnToastCompleted(toast);
            })); // end m_dispatcher.RunAsync
         }
     }); // end Task.Run
}
```

## (Xxxxxx Y) Xxx XxxxxXxxxxxx&xx;Xxxxxx&xx; xxx xxxx xxxx xxxxxxxxxxx


Xxxxxxx xxx xx xxxx xx xxxxx xxxx x xxxxxxxxxx xxxxxx xx xx xxx [Xxxxxxx.Xxxxxxxxxx.XxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&xx;Xxxxxx&xx; xx xxx xxxx xx xxx xxxxx. Xxxxxxx xxxxxxxx xxxx xxxxxxxx xxxxxxxxxxxxx xx xxx xxxxxxx xxxx xxx xxxxxxxx x xxxxx xxx xxxx xxx xx. Xxx xxxxxxxx xx xxxx xxx xxxx xxxxxxxxxxx xx xxxx xxxxx xxxx xxx xxxxxx xx xxxx. X++ xxx .XXX xxxxxxx xxxx xxxx xxxxxxx xxxxxxxxxxxxx xxxx xxxx xx xxxx xxxx xx xxxx xxx xxxxx xx xxxxxxxx. XxxxXxxxxx xxxxxxx xxx’x xxxx xxx xxxxxxxx xxxx xxxxxxxxxxx. Xxxx xxxx xxx xxx xxxxxxxxxx, xxxxx xx xxxxx xxxxx xx xxx xxxxxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxx Xxxxxxx.Xxxxxxxxxx.XxxxxXxxxxxx&xx;Xxxxxx&xx; xx X\#:

```csharp
public sealed Class1
{
// Declare the event
public event EventHandler<Object> ToastCompletedEvent;

    // Raise the event
    public async void MakeToast(string message)
    {
        Toast toast = new Toast(message);
        // Fire the event from a background thread to allow this thread to continue 
        Task.Run(() =>
        {
            if (ToastCompletedEvent != null)
            {
                OnToastCompleted(toast);
            }
        });
    }

    private void OnToastCompleted(Toast args)
    {
        var completedEvent = ToastCompletedEvent;
        if (completedEvent != null)
        {
            completedEvent(this, args);
        }
    }
}
```

Xxx xxxxxxx xxxx xxxxx xx xxx XxxxXxxxxx xxxx xxxx xxxx:

```javascript
toastCompletedEventHandler: function (event) {
   var toastType = event.toast.toastType;
   document.getElementById("toasterOutput").innerHTML = "<p>Made " + toastType + " toast</p>";
}
```

## (Xxxxxx Y) Xxxxxx xxxx xxx xxxxx xxx xxxx


Xxx xxxxxxxxx xxxxxxxxxxx xxxxx xx xxxx-xxxxxxx xxxxx xxxxx xxxx xxxx xxxxx-xxxxxxxxx xxxx xxxxxxxxxxx, xxx xxxx xx xxxxxx xxxx xxx xxxxx xxx xxxx xxxxxxx xxx xxxxx xxxx xx xxxx xxx xxxxxxx. Xxxxxxxxx, xxx xxxx xx xxx xxxx xxxxxx xxxx xx xxxx xxxxxxxxxx xxxxx xxxxxxx xx xxx xxxxx xxx xxxxxxx xxx xxxxxxxx. Xxxx, xxxxx xx xx xxxxxxxxx xxxx xxxx xxxxxx xxxx xxxxxxx xxxxxx xxxxxxxxxxx xxxx xxx xxxxx xxx xxxxxxx. Xxxxxx xxxxxxxxxxx xxxxxxx xx xxxx xxxxxxx. Xxx xxx Xxxxxx Xxxxxx xxxxxxxx xx xxxxx xxxxxxxxx xxxxx xx xxxxxxx xxxxxx xxxxxxxxxxx xx xxxx xxxxxxxxxxx xxx xxxxxxxxx xxxxxxx xxx xxxxx xx xx xxxx x xxxxxxxxxx.

Xxx xxxx xx xxxx xxxxxxx xxxxx xxx xx xxx X\# xx xxxxxx x xxxxx Xxxxxxx Xxxxxxx xxxxxxxxx, xxx xxxx xxx X++ xx xxxxxx x XXX xxx xxx xxxxx xxx xxxx xxxx xxxx xxxxxx XxxxXxxxxx xx xxxxxxx x Xxxxxxx.Xxxxxxxxxx.XxxxxXxxxxXxxxxxx&xx;XXxxxxx, XXxxxxx&xx; xxxxx xxxx'x xxxxxx xx xxx xxxxxxxxx xx xx xxxxx xxxxxxxxx. (Xxx xxx xxxx xxx X++ xx Xxxxxx Xxxxx xx xxxxxx xxx xxxxxxxxx. Xxx xxxxx xxxx xxx xxxxxxx xx xxxxxxxx xxx xxxxxxx xxx xxxxx xxx xxx xxxx.) Xxxx xxxxxxxxxxx xx xxxxx xx Xxxxxxxx x Xxxxxxx Xxxxxxx xx-xxxxxxx xxxxxxxxx xxxxxx (X++/XX) xxx xxxxx xxxxxxx xxx xxxxxxxx.

Xxxx xxxxxxxxxxx xxx xxxxx xxxxx:

-   Xxxx xxx xxxx xxxxxx xxx xxxxx Xxxxxxx Xxxxxxx xxxxxxx. Xxx xxxxx xxxxxxx xx xxxxx xx xxxx [Xxxxxxx.Xxxxxxxxxx.XxxxxXxxxxXxxxxxx&xx;XXxxxxx, XXxxxxx&xx;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) xxx xxx xxxxx xxxxx xx xxx xxxx xxxx'x xxxxxxxx xx XxxxXxxxxx xx xxx xxxxxxxx xxx XXxxxx. Xxxxx xxxxxxx xxx'x xxxxxxxxxxx xxxx XxxxXxxxxx xxxxx xxx xxxxxxxx xxx xxxxx xxxxx.
-   Xxxx xxx xxxxxxxxx xxx xxxx xxxxx xxxxxx, xxxxx x xxxxxx, xxx xxxxxxx xx xxxxx xxxx'x xxxxxx xx xxx Xxxxxxx Xxxxxxx xxxxxxxxx.
-   Xxxxx xxx xxxxxxxx xx xxx xxxxx xxxx xxxxxxxx xxx xxxxx xxx xxxx xxxxxxx.
-   Xxx xxxx xxx xxx XXX xxxx xx xxxxxxxx xxx X xxxxxx xxxx xxx xxx xxxxx xxx xxxx.
-   Xxxxxxxx xxx xxxxx-xxxx xxxxxxx xx xxxx xxx XXX xxxxxxx xxx xxxx xxxx, xxx xxxxxxxxx xxx xxxxx-xxxx XXX xx xxx xxx xxxxxxx.

## Xx xxxxxx xxx Xxxxxxx Xxxxxxx xxxxxxxxx

1.  Yx Xxxxxx Xxxxxx, xx xxx xxxx xxx, xxxxxx **Xxxx &xx; Xxx Xxxxxxx**. Xx xxx **Xxx Xxxxxxx** xxxxxx xxx, xxxxxx **XxxxXxxxxx &xx; Xxxxxxxxx Xxxxxxx** xxx xxxx xxxxxx **Xxxxx Xxx**. Xxxx xxx xxxxxxx XxxxxxxXxxxxxxxxxx xxx xxxx xxxxxx xxx **XX** xxxxxx.
2.  Xxx x X\# Xxxxxxx Xxxxxxx xxxxxxxxx xx xxx xxxxxxxx: Xx Xxxxxxxx Xxxxxxxx, xxxx xxx xxxxxxxx xxxx xxx xxx xxxxxxxx xxx xxxx xxxxxx **Xxx &xx; Xxx Xxxxxxx**. Xxxxxx **Xxxxxx X\# &xx; Xxxxxxx Xxxxx** xxx xxxx xxxxxx **Xxxxxxx Xxxxxxx Xxxxxxxxx**. Xxxx xxx xxxxxxx XxxxxxxXxxxxxxxx xxx xxxx xxxxxx xxx **XX** xxxxxx. XxxxxxxXxxxxxxxx xxxx xx xxx xxxx xxxxxxxxx xxx xxx xxxxxxxxxx xxx xxxx xxxxxx xx xxxxx xxxxx.

    Xx Xxxxxxxx Xxxxxxxx, xxxx xxx xxxxxxxx xxxx xxx xxx xxxxxxxx xxx xxxx xxxxxx **Xxxxxxxxxx**. Xx xxx **Xxxxxxxx Xxxxx** xxxxxx xxx, xxxxxx **Xxxxxxxxxxxxx Xxxxxxxxxx** xx xxx xxxx xxxx, xxx xxxx xx xxx xxx xx xxx xxxxxx xxx, xxx **Xxxxxxxxxxxxx** xx **Xxxxx** xxx **Xxxxxxxx** xx xYY, xYY, xx XXX. Xxxxxx xxx **XX** xxxxxx.

    > **Xxxxxxxxx**  Xxxxxxxx = Xxx XXX xxx’x xxxx xxxxxxx xx'x xxx xxxxx xxx xxx xxxxxx-xxxx XxxYY XXX xxxx xxx'xx xxx xx xxx xxxxxxxx xxxxx.

3.  Xx Xxxxxxxx Xxxxxxxx, xxxxxx xxxxxY.xx xx XxxxxxxXxxxxxxxx.xx xx xxxx xx xxxxxxx xxx xxxx xx xxx xxxxxxx. Xxxxxx Xxxxxx xxxxxxxxxxxxx xxxxxxx xxx xxxxx xx xxx xxxx xx xxxxx xxx xxx xxxx xxxx.
4.  Xx xxx .xx xxxx, xxx x xxxxx xxxxxxxxx xxx xxx Xxxxxxx.Xxxxxxxxxx xxxxxxxxx xx xxxxx XxxxxXxxxxXxxxxxx xxxx xxxxx.
5.  Xxxx xxx xxxxxxx xxxxxxx xxx xxxxx, xxxx xxxxxxxxx xxxx xxx xxxxxxxxxx xx xxxxxx xxx xxxxxx xxxxxxx. Xx XxxxxxxXxxxxxxxx.xx, xxxxxx xx xxxxxxxxx xxx xxx xxxxxxx, xxx xxxxxxx xxx xxx xxx Xxxxx xxxx xxx xxxxxxx xxxxxxxx.

    > **Xxxx**  Xx X\# xxx xxx xxxx xxxx xxxx. Xxxxxxx, xxxxx xxxxxx x xxxxx, xxx xxxx xxxx xxx xxxxxxxx xxxx xxx xxxxxx **Xxxxxxxx &xx; Xxxxxxx Xxxxxxxxx**. Xx xxx xxxx xxxx'x xxxxxxxxx, xxxxxxxx xxxx xxx xxxxxxxxxx xxxxxx xxxxxxxxxxxxx.

    ```csharp
    public interface IToaster
        {
            void MakeToast(String message);
            event TypedEventHandler&lt;Toaster, Toast> ToastCompletedEvent;

        }
        public interface IToast
        {
            String ToastType { get; }
        }
    ```

    Xxx XXxxxx xxxxxxxxx xxx x xxxxxx xxxx xxx xx xxxxxxxxx xx xxxxxxxx xxx xxxx xx xxxxx. Xxx XXxxxxxx xxxxxxxxx xxx x xxxxxx xx xxxx xxxxx, xxx xx xxxxx xx xxxxxxxx xxxx xxx xxxxx xx xxxx. Xxxxxxx xxxx xxxxx xxxxxxx xxx xxxxxxxxxx xxxxx (xxxx xx, xxxx) xx xxxxx, xx'x xxxxx xx x xxxxx xxxxx.

6.  Xxxx, xx xxxx xxxxxxx xxxx xxxxxxxxx xxxxx xxxxxxxxxx, xxx xxx xxxxxx xxx xxxxxx xx xxxx xxxx xxx xxxxxxxxxx xxxx xxx XxxxXxxxxx xxx xxxx xxx'xx xxxxxxx xxxxx.

    ```csharp
    public sealed class Toast : IToast
        {
            private string _toastType;

            public string ToastType
            {
                get
                {
                    return _toastType;
                }
            }
            internal Toast(String toastType)
            {
                _toastType = toastType;
            }

        }
        public sealed class Toaster : IToaster
        {
            public event TypedEventHandler&lt;Toaster, Toast> ToastCompletedEvent;

            private void OnToastCompleted(Toast args)
            {
                var completedEvent = ToastCompletedEvent;
                if (completedEvent != null)
                {
                    completedEvent(this, args);
                }
            }

            public void MakeToast(string message)
            {
                Toast toast = new Toast(message);
                // Fire the event from a thread-pool thread to enable this thread to continue 
                Windows.System.Threading.ThreadPool.RunAsync(
                (IAsyncAction action) =>
                {
                    if (ToastCompletedEvent != null)
                    {
                        OnToastCompleted(toast);
                    }
                });
           }
        }
    ``` 

    Xx xxx xxxxxxxxx xxxx, xx xxxxxx xxx xxxxx xxx xxxx xxxx xx x xxxxxx-xxxx xxxx xxxx xx xxxx xxx xxxxxxxxxxxx. Xxxxxxxx xxx XXX xxxxx xxxxxxx xxxx xxx xxxxx xxx xxxxx xxxxxxx xx xxx xxxxx xxxx, xx xxx’x xxxxxxxxx xx xxxx xxxx xxxxxxx xxx xxxxxx xxxxx’x xx xxx xxxx xxxx xxxxxxx xx xxx xxxxxxx xx xxx xxxxxxxxx.

    > **Xxxx**  Xxx xxxxx xxxx xx xxx xxxxxxxxx xxxx xxxx XxxxxxXxxx.XxxXxxxx xxxxxx xx xxxxxxxxxxx x xxxxxx xxx xx xxxx xxx xxxxx xx x xxxxxxxxxx xxxxxx. Xxx xxxxx xxxxx xxxx xxxxxxxxxx xxxxxx xx xxxxx xx xxx xxxxxxxxx xxxxxxx, xxx xx xxxxx xxxx xxxx xxxxxxx xxx .XXX Xxxx xxxxxxxxx xxxxxxxxxxxxx xxxxxxxx xxxxx/xxxxx xxxxx xxxx xx xxx XX xxxxxx.
  
    ````csharp
    public async void MakeToast(string message)
    {
        Toast toast = new Toast(message)
        await Task.Delay(new Random().Next(1000));
        OnToastCompleted(toast);
    }
    ```

    If you build the project now, it should build cleanly.

## To program the JavaScript app

1.  Now we can add a button to the JavaScript app to cause it to use the class we just defined to make toast. Before we do this, we must add a reference to the ToasterComponent project we just created. In Solution Explorer, open the shortcut menu for the ToasterApplication project, choose **Add &gt; References**, and then choose the **Add New Reference** button. In the Add Reference dialog box, in the left pane under Solution, select the component project, and then in the middle pane, select ToasterComponent. Choose the **OK** button.
2.  In Solution Explorer, open the shortcut menu for the ToasterApplication project and then choose **Set as Startup Project**.
3.  At the end of the default.js file, add a namespace to contain the functions to call the component and be called back by it. The namespace will have two functions, one to make toast and one to handle the toast-complete event. The implementation of makeToast creates a Toaster object, registers the event handler, and makes the toast. So far, the event handler doesn’t do much, as shown here:

    ```javascript
    WinJS.Namespace.define("ToasterApplication"), {
       makeToast: function () {

          var toaster = new ToasterComponent.Toaster();
          //toaster.addEventListener("ontoastcompletedevent", ToasterApplication.toastCompletedEventHandler);
          toaster.ontoastcompletedevent = ToasterApplication.toastCompletedEventHandler;
          toaster.makeToast("Peanut Butter");
       },

       toastCompletedEventHandler: function(event) {
           // The sender of the event (the delegate's first type parameter)
           // is mapped to event.target. The second argument of the delegate
           // is contained in event, which means in this case event is a 
           // Toast class, with a toastType string.
           var toastType = event.toastType;

           document.getElementById('toastOutput').innerHTML = "<p>Made " + toastType + " toast</p>";
        },
    });
    ```

4.  The makeToast function must be hooked up to a button. Update default.html to include a button and some space to output the result of making toast:

    ```html
    <body>
        <h1>Click the button to make toast</h1>
        <button onclick="ToasterApplication.makeToast()">Make Toast!</button>
        <div id="toasterOutput">
            <p>No Toast Yet...</p>
        </div>
    </body>
    ```

    If we weren’t using a TypedEventHandler, we would now be able to run the app on the local machine and click the button to make toast. But in our app, nothing happens. To find out why, let’s debug the managed code that fires the ToastCompletedEvent. Stop the project, and then on the menu bar, choose **Debug &gt; Toaster Application properties**. Change **Debugger Type** to **Managed Only**. Again on the menu bar, choose **Debug &gt; Exceptions**, and then select **Common Language Runtime Exceptions**.

    Now run the app and click the make-toast button. The debugger catches an invalid cast exception. Although it’s not obvious from its message, this exception is occurring because proxies are missing for that interface.

    ![missing proxy](./images/debuggererrormissingproxy.png)

    The first step in creating a proxy and stub for a component is to add a unique ID or GUID to the interfaces. However, the GUID format to use differs depending on whether you're coding in C\#, Visual Basic, or another .NET language, or in C++.

## To generate GUIDs for the component's interfaces (C\# and other .NET languages)

1.  On the menu bar, choose Tools &gt; Create GUID. In the dialog box, select 5. \[Guid(“xxxxxxxx-xxxx...xxxx)\]. Choose the New GUID button and then choose the Copy button.

    ![guid generator tool](./images/guidgeneratortool.png)

2.  Go back to the interface definition, and then paste the new GUID just before the IToaster interface, as shown in the following example. (Don't use the GUID in the example. Every unique interface should have its own GUID.)

    ```cpp
    [Guid("FC198F74-A808-4E2A-9255-264746965B9F")]
        public interface IToaster...
    ```

3.  Add a using directive for the System.Runtime.InteropServices namespace.
4.  Repeat these steps for the IToast interface.

## To generate GUIDs for the component's interfaces (C++)

1.  On the menu bar, choose Tools &gt; Create GUID. In the dialog box, select 3. static const struct GUID = {...}. Choose the New GUID button and then choose the Copy button.

2.  Paste the GUID just before the IToaster interface definition. After you paste, the GUID should resemble the following example. (Don't use the GUID in the example. Every unique interface should have its own GUID.)

    ```cpp 
      <Extensions> <!—Use your own GUIDs!!!-->
        <Extension Category="windows.activatableClass.proxyStub">
          <ProxyStub ClassId="1ecafeff-1ee1-504a-9af5-a68c6fb2b47d">
            <Path>Proxies.dll</Path>
            <Interface Name="IToast" InterfaceId="F8D30778-9EAF-409C-BCCD-C8B24442B09B"/>
            <Interface Name="IToaster"  InterfaceId="E976784C-AADE-4EA4-A4C0-B0C2FD1307C3"/>  
            <Interface Name="ITypedEventHandler_2_ToasterComponent__CToaster_ToasterComponent__CToast" InterfaceId="1ecafeff-1ee1-504a-9af5-a68c6fb2b47d"/>
          </ProxyStub>      
        </Extension>
      </Extensions>
    ```

    Paste the Extensions XML node as a direct child of the Package node, and a peer of, for example, the Resources node.

2.  Before moving on, it’s important to ensure that:

    -   The ProxyStub ClassId is set to the first GUID in the ToasterComponent\_i.c file. Use the first GUID that's defined in this file for the classId. (This might be the same as the GUID for ITypedEventHandler2.)
    -   The Path is the package relative path of the proxy binary. (In this walkthrough, proxies.dll is in the same folder as ToasterApplication.winmd.)
    -   The GUIDs are in the correct format. (This is easy to get wrong.)
    -   The interface IDs in the manifest match the IIDs in ToasterComponent\_i.c file.
    -   The interface names are unique in the manifest. Because these are not used by the system, you can choose the values. It is a good practice to choose interface names that clearly match interfaces that you have defined. For generated interfaces, the names should be indicative of the generated interfaces. You can use the ToasterComponent\_i.c file to help you generate interface names.

3.  If you try to run the solution now, you will get an error that proxies.dll is not part of the payload. Open the shortcut menu for the **References** folder in the ToasterApplication project and then choose **Add Reference**. Select the check box next to the Proxies project. Also, make sure that the check box next to ToasterComponent is also selected. Choose the **OK** button.

    The project should now build. Run the project and verify that you can make toast.

## Related topics

* [Creating Windows Runtime Components in C++](creating-windows-runtime-components-in-cpp.md)

<!--HONumber=Mar16_HO1-->
