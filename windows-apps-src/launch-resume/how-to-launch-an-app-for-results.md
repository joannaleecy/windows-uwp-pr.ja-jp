---
xxxxx: Xxxxxx xx xxx xxx xxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xx xxx xxxx xxxxxxx xxx xxx xxxxxxxx xxxx xxxxxxx xxx xxx. Xxxx xx xxxxxx xxxxxxxxx xx xxx xxx xxxxxxx.
xx.xxxxxxx: XXXYYXYY-XYXX-YXXY-YXXY-YYYYYYYXXYYY
---

# Xxxxxx xx xxx xxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxXxxXxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn956686)
-   [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131)

Xxxxx xxx xx xxxxxx xx xxx xxxx xxxxxxx xxx xxx xxxxxxxx xxxx xxxxxxx xxx xxx. Xxxx xx xxxxxx *xxxxxxxxx xx xxx xxx xxxxxxx*. Xxx xxxxxxx xxxx xxxxx xxx xxx xx xxx [**XxxxxxXxxXxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn956686) xx xxxxxx xx xxx xxx xxxxxxx.

Xxx xxx-xx-xxx xxxxxxxxxxxxx XXXx xx Xxxxxxx YY xxxx xx xxxxxxxx xxx Xxxxxxx xxxx (xxx Xxxxxxx Xxx xxxx) xx xxxxxx xx xxx xxx xxxxxxxx xxxx xxx xxxxx. Xxxx xxxxxxx xxx xx xxxxx xxxx-xx xxxxxxxxx xxxx xxxxxxxx xxxx. Xxxxx xxxxx xxx XXXx, xxxxxxx xxxxx xxxx xxxxx xxxx xxxxxxxx xxx xxxx xx xxx xxxxxxxx xxxx xxx xxx xx xxxxxxx xxxxxxxxxx. Xxx xxxxxxx, xxxx xxx xxxxx xxxxxx x xxxxxx xxxxxxxxxx xxx xx xxxxxx x xxxxxxx, xx xxxxxx x xxxxxxxx xxx xx xxxxxxxx x xxxxxxx xxxxxxx.

Xxx xxx xxxx xxx'xx xxxxxx xxx xxxxxxx xxxx xx xxxxxxxx xx xx xxx xxxxxxxx xxx. Xxx xxx xxxx xxxxxxxx xxx xxx xxxx xx xxxxxxxx xx xx xxx xxxxxxx xxx. Xxx xxxx xxxxxxx xxx xxxx xxxxx xxxx xxx xxxxxxx xxx xxx xxx xxxxxxxx xxx.

## Xxxx Y: Xxxxxxxx xxx xxxxxxxx xx xx xxxxxxx xx xxx xxx xxxx xxx'xx xxxxxx xxx xxxxxxx


Xx xxx Xxxxxxx.xxxxxxxxxxxx xxxx xx xxx xxxxxxxx xxx, xxx x xxxxxxxx xxxxxxxxx xx xxx **&xx;Xxxxxxxxxxx&xx;** xxxxxxx. Xxx xxxxxxx xxxx xxxx x xxxxxxxxx xxxxxxxx xxxxx **xxxx-xxxYxxx**.

Xxx **XxxxxxXxxxxxx** xxxxxxxxx xx xxx xxxxxxxx xxxxxxxxx xxxxxxx xxx xx xxxxx xxxxxx:

-   **xxxxxxxx**—Xxx xxx xxx xx xxxxxxxx xxx xxxxxxx xx xxxxx xxx [**XxxxxxXxxXxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn956686) xxxxxx, xx xxx xxx xxxxxxx xx xxxxx [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476). Xxxx xxx xxx **xxxxxxxx**, xxx xxxxxxxx xxx xxxx xxxxxxxxx xxxxxxx xx xxx xxxxxxxx xxx xxxxxxx. Xx xxx xx xxxx xx xxxxxxxx xxx [**XxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242330) xxxxx xxxxxxxx. Xx xxx xxxxxxxx'x [**XXxxxxxxxxXxxxxXxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/br224728) xxxxxxxx xxxxxxx [**XxxxxxxxxxXxxx.XxxxxxxxXxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224693), xx xx xxx xxxx xx xxx xxxxx xxxxxxxx xx [**XxxxxxxxXxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224742), xxx xxx xxx xxxxxxxx xxx **XxxxxxXxxXxxXxxxxxxXxxxx**.
-   **xxxxxx**—Xxx xxx xxx xx xxxxxxxx xxxx xxx xxxxxxx; xxxx xx, xx xxx xxxxxxx xxxx xx [**XxxxxxXxxXxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn956686).
-   **xxxx**—Xxx xxx xxxxxx xx xxxxxxxx xxx xxxxxxx; xx xxx xxxxxxx xxxx xx [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476).

Xx xxxx xxxxxxxx-xxxxxxxxx xxxxxxx, xxx xxx xxx xx xxxxxxxx xxxx xxx xxxxxxx. Xxxx xxxxxxxxxx xxx xxxxx xxxxxx xxx **XxXxxxxxxxx** xxxxxx, xxxxxxxxx xxxxx, xxxxxxx xx xxxx xx xxxxxx xxxx xxx "xxxxxxxx xxx xxxxxxx" xxxx xxx xxx xxx xxxxx xxxx xxxx xxx xxx xxxxx xx xxxxxxxxx.

```xaml
<Applications>
   <Application ...>

     <Extensions>
       <uap:Extension Category="windows.protocol">
         <uap:Protocol Name="test-app2app" ReturnResults="always">
           <uap:DisplayName>Test app-2-app</uap:DisplayName>
         </uap:Protocol>
       </uap:Extension>
     </Extensions>

   </Application>
</Applications>
```

## Xxxx Y: Xxxxxxxx Xxxxxxxxxxx.XxXxxxxxxxx xx xxx xxx xxxx xxx'xx xxxxxx xxx xxxxxxx


Xx xxxx xxxxxx xxxx xxx xxxxxxx xxxxx xx xxx xxxxxxxx xxx, xxxxxx xx xxxxxx xxx `App` xxxxx xxxxxxx xx Xxx.xxxx.xx.

Xx xx xxx xxxx xxxx xxx xxxx xxxx xxxxxxx xx x xxxxxx xxxxxxx, xxxx xxxxxxxx xxxxx xx xxxxx xxx xxxx xxx xxxxxx-xxxxxx xxxx. Xx xxxx xxxx xxxxxxx, x xxxx xxxxx **XxxxxxxxXxxXxxxxxxXxxx** xx xxxxxxxxx xxxx xxx xxx xx xxxxxxxxx xxx xxxxxxx. Xxxxxx xxxx xxx **xxxxx** xxxxxxxxx xx xxxxxxxx xx xxx xxx xx xxx xxxx.

```cs
using Windows.ApplicationModel.Activation;
...
protected override void OnActivated(IActivatedEventArgs args)
{
    // Window management
    Frame rootFrame = Window.Current.Content as Frame;
    if (rootFrame == null)
    {
        rootFrame = new Frame();
        Window.Current.Content = rootFrame;
    }

    // Code specific to launch for results
    var protocolForResultsArgs = (ProtocolForResultsActivatedEventArgs)args;
    // Open the page that we created to handle activation for results.
    rootFrame.Navigate(typeof(LaunchedForResultsPage), protocolForResultsArgs);

    // Ensure the current window is active.
    Window.Current.Activate();
}
```

Xxxxxxx xxx xxxxxxxx xxxxxxxxx xx xxx Xxxxxxx.xxxxxxxxxxxx xxxx xxxxxxxxx **XxxxxxXxxxxxx** xx **xxxxxx**, xxx xxxx xxxx xxxxx xxx xxxx `args` xxxxxxxx xx [**XxxxxxxxXxxXxxxxxxXxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn906905) xxxx xxxxxxxxxx xxxx xxxx **XxxxxxxxXxxXxxxxxxXxxxxxxxxXxxxxXxxx** xxxx xx xxxx xx **XxXxxxxxxxx** xxx xxxx xxx. Xx xxxx xxx xxx xx xxxxxxxxx xx xxxx xxxxx xxxx xxxxxxxxx xxx xxxxxxx, xxx xxx xxxxx xxxxxxx [**XXxxxxxxxxXxxxxXxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/br224728) xxxxxxxx xxxxxxx [**XxxxxxxxxxXxxx.XxxxxxxxXxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224693) xx xxxx xxxxxxx xxx xxx xxx xxxxxxxx xxx xxxxxxx.

## Xxxx Y: Xxx x XxxxxxxxXxxXxxxxxxXxxxxxxxx xxxxx xx xxx xxx xxx xxxxxx xxx xxxxxxx


```cs
private Windows.System.ProtocolForResultsOperation _operation = null;
```

Xxx'xx xxx xxx [**XxxxxxxxXxxXxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn906913) xxxxx xx xxxxxx xxxx xxx xxxxxxxx xxx xx xxxxx xx xxxxxx xxx xxxxxx xx xxx xxxxxxx xxx. Xx xxxx xxxxxxx, xxx xxxxx xx xxxxx xx xxx **XxxxxxxxXxxXxxxxxxXxxx** xxxxx xxxxxxx xxx'xx xxxxxxxx xxx xxxxxx-xxx-xxxxxxx xxxxxxxxx xxxx xxxx xxxx xxx xxxx xxxx xxxxxx xx xx.

## Xxxx Y: Xxxxxxxx XxXxxxxxxxxXx() xx xxx xxx xxx xxxxxx xxx xxxxxxx


Xxxxxxxx xxx [**XxXxxxxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br227508) xxxxxx xx xxx xxxx xxxx xxx'xx xxxxxxx xxxx xxxx xxx xx xxxxxxxx xxx xxxxxxx. Xx xxxx xxxxxx xxxx xxx xxxxxxx xxxxx, xxxxxx xx xxxxxx xxx xxxxx xxx xxx xxxx xxxxxxx xx &xx;xxxxxxxx&xx;.xxxx.xx. Xxxxxx xxxx xxx xxxxxxxxx **xxxxx** xxxxxxxxx xx xxxxxxxx xx xxx xxx xx xxx xxxx:

```cs
using Windows.ApplicationModel.Activation
```

Xxx [**XxxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br243285) xxxxxx xx xxx [**XxXxxxxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br227508) xxxxxx xxxxxxxx xxx xxxx xxxxxx xxxx xxx xxxxxxx xxx. Xxx xxxx xxx xxx xxxxxx YYYXX xxx xx xxxxxx xx x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131) xxxxxx.

Xx xxxx xxxxxxx xxxx, xxx xxxxxxxx xxx xxxxxxx xxx xxxx xxxx xxxx xxx xxxxxxx xxx xx xx xx x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131) xxxxx x xxx xxxxx **XxxxXxxx**, xxxxxxx xxxx'x xxxx xxx xxxxxxx'x xxxxxxx xxx xx xxxxx xx xxxx.

```cs
using Windows.ApplicationModel.Activation;
...
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    var protocolForResultsArgs = e.Parameter as ProtocolForResultsActivatedEventArgs;
    // Set the ProtocolForResultsOperation field.
    _operation = protocolForResultsArgs.ProtocolForResultsOperation; 
    
    if (protocolForResultsArgs.Data.ContainsKey("TestData"))
    {
        string dataFromCaller = protocolForResultsArgs.Data["TestData"] as string;
    }
}
...
private Windows.System.ProtocolForResultsOperation _operation = null;
```

## Xxxx Y: Xxxxx xxxx xx xxxxxx xxxx xx xxx xxxxxxx xxx


Xx xxx xxxxxxxx xxx, xxx [**XxxxxxxxXxxXxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn906913) xx xxxxxx xxxx xx xxx xxxxxxx xxx. Xx xxxx xxxxxxx xxxx, x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131) xxxxxx xx xxxxxxx xxxx xxxxxxxx xxx xxxxx xx xxxxxx xx xxx xxxxxxx xxx. Xxx **XxxxxxxxXxxXxxxxxxXxxxxxxxx** xxxxx xx xxxx xxxx xx xxxx xxx xxxxx xx xxx xxxxxxx xxx.

```cs
    ValueSet result = new ValueSet();
    result["ReturnedData"] = "The returned result";
    _operation.ReportCompleted(result);
```

## Xxxx Y: Xxxxx xxxx xx xxxxxx xxx xxx xxx xxxxxxx xxx xxx xxx xxxxxxxx xxxx


Xxxxxx xxx xxx xxxx xxxxxx xx xxxxx xxxxxx xx xxxx xxxxxxx xxx xx xxxxx xx xxxx xxxxxxx xxxx. Xxxx xxx **xxxxx** xxxxxxxxxx, xxxxx xxx xxxxxxxxx xxx xxx xxxx xx xxxxxxx:

```cs
using System.Threading.Tasks;
using Windows.System;
...

async Task<string> LaunchAppForResults()
{
    var testAppUri = new Uri("test-app2app:"); // The protocol handled by the launched app
    var options = new LauncherOptions();
    options.TargetApplicationPackageFamilyName = "67d987e1-e842-4229-9f7c-98cf13b5da45_yd7nk54bq29ra";

    var inputData = new ValueSet();
    inputData["TestData"] = "Test data";

    string theResult = "";
    LaunchUriResult result = await Windows.System.Launcher.LaunchUriForResultsAsync(testAppUri, options, inputData);
    if (result.Status == LaunchUriStatus.Success &amp;&amp;
        result.Result != null &amp;&amp;
        result.Result.ContainsKey("ReturnedData"))
    {
        ValueSet theValues = result.Result;
        theResult = theValues["ReturnedData"] as string;
    }
    return theResult;
}
```

Xx xxxx xxxxxxx, x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131) xxxxxxxxxx xxx xxx **XxxxXxxx** xx xxxxxx xx xxx xxxxxxxx xxx. Xxx xxxxxxxx xxx xxxxxxx x **XxxxxXxx** xxxx x xxx xxxxx **XxxxxxxxXxxx** xxxx xxxxxxxx xxx xxxxxx xxxxxxxx xx xxx xxxxxx.

Xxx xxxx xxxxx xxx xxxxxx xxx xxx xxxx xxx'xx xxxxxx xxx xxxxxxx xxxxxx xxxxxxx xxxx xxxxxxx xxx. Xxxxxxxxx, [**XxxxxxXxxXxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn906892) xxxx xxxxxx **XxxxxxXxxXxxxxx.XxxXxxxxxxxxxx**.

Xxx'xx xxxx xxx xxxxxx xxxx xx xxx xxxxxxxx xxx xxxx xxx xxx xxx [**XxxxxxXxxxxxxxxxxXxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn893511). Xxx xxx xx xxx xxx xxxxxx xxxx xx xx xxxx xxx xxxxxxxxx xxxx xxxx xxxxxx xxx xxxxxxxx xxx:

```cs
string familyName = Windows.ApplicationModel.Package.Current.Id.FamilyName;
```

## Xxxxxxx


Xxx xxxxxxx xx xxxx xxx-xx xxxxxxxx x "xxxxx xxxxx" xxxxxxxxxxxx xx xxxxxxxxx xx xxx xxx xxxxxxx. Xxx xxx xxxxxx xx xxxx xxx xxxx xxx xxx [**XxxxxxXxxXxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn956686) XXX xxxx xxx xxxxxxxxxxxxxx xxxxxx xx xxx xxx xxxxxxxxxxx xxx xxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131) xxxxx. Xxxxxxx xxxx xxx x **XxxxxXxx** xx xxxxxxx xx YYYXX. Xx xxx xxxx xx xxxx xxxxxx xxxxxxx xx xxxx, xxx xxx xxxxx xxxxx xx xxxxx xxx [**XxxxxxXxxxxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn889985) xxxxx xx xxxxxx xxxx xxxxxx xxxx xxx xxx xxxx xxxxxxx xxxx. Xxx xxxxxxx, xxxxx x **XxxxxXxx** xxxxx `inputData`, xxx xxxxx xxxxx xxx xxxxx xx x xxxx xxxx xxx xxxx xx xxxxx xxxx xxx xxxxxxxx xxx:

```cs
inputData["ImageFileToken"] = SharedStorageAccessManager.AddFile(myFile);
```

Xxxx xxxx xx xx xxx xxxxxxxx xxx xxx **XxxxxxXxxXxxXxxxxxxXxxxx**.

## Xxxxxxx xxxxxx


* [**XxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701476)
* [**XxxxxxXxxXxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn956686)
* [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131)

 

 



<!--HONumber=Mar16_HO1-->
